Public Class FormMasterRawMatPps
    Public data_insert_parameter As New DataTable
    Public action As String
    Public id_pps As String
    Public id_mat As String
    Public id_method As String
    'Dim material_image_path As String = "\\192.168.1.30\dataapp\material\"
    Dim material_image_path_pps As String = get_setup_field("pic_path_mat") & "\pps\"
    Public id_pop_up As String = "-1"

    Private Sub BClose_Click(sender As Object, e As EventArgs) Handles BClose.Click
        Close()
    End Sub

    Private Sub FormMasterRawMatPps_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub FormMasterRawMatPps_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        load_form()
    End Sub

    Private Sub viewTemplate(ByVal lookup As DevExpress.XtraEditors.SearchLookUpEdit)
        Dim query As String = "SELECT id_template_code,template_code FROM tb_template_code ORDER BY template_code ASC"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")

        lookup.Properties.DataSource = Nothing
        lookup.Properties.DataSource = data

        lookup.Properties.DisplayMember = "template_code"
        lookup.Properties.ValueMember = "id_template_code"
        Try
            lookup.EditValue = get_setup_field("id_code_template_mat_det")
        Catch ex As Exception
            lookup.EditValue = data.Rows(0)("id_template_code").ToString
        End Try
    End Sub

    Sub loadIsiParam()
        Cursor = Cursors.WaitCursor

        data_insert_parameter.Clear()

        If data_insert_parameter.Columns.Count < 2 Then
            data_insert_parameter.Columns.Add("code")
            data_insert_parameter.Columns.Add("value")
        End If

        GCCodeMaterial.DataSource = data_insert_parameter

        Try
            add_combo_grid_val(GVCodeMaterial, 0)
            view_value_code(GVCodeMaterial, 1)
        Catch ex As Exception
        End Try

        Cursor = Cursors.Default
    End Sub
    Private Sub add_combo_grid_val(ByVal grid As DevExpress.XtraGrid.Views.Grid.GridView, ByVal col As Integer)
        Dim lookup As New DevExpress.XtraEditors.Repository.RepositoryItemSearchLookUpEdit

        lookup.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor

        Dim query As String = String.Format("SELECT id_code,code_name as Code,description as Description FROM tb_m_code")
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")

        lookup.DataSource = Nothing
        lookup.DataSource = data
        lookup.PopulateViewColumns()
        lookup.NullText = ""
        lookup.View.Columns("id_code").Visible = False
        lookup.DisplayMember = "Code"
        lookup.ValueMember = "id_code"

        grid.Columns(col).ColumnEdit = lookup
    End Sub

    Sub view_value_code(ByVal grid As DevExpress.XtraGrid.Views.Grid.GridView, ByVal col As Integer)
        Dim lookup As New DevExpress.XtraEditors.Repository.RepositoryItemSearchLookUpEdit

        lookup.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor

        Dim query As String = String.Format("SELECT id_code,id_code_detail,CODE,display_name,code_detail_name,CONCAT(CODE,' - ',code_detail_name) AS value FROM tb_m_code_detail")
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")

        lookup.DataSource = Nothing
        lookup.DataSource = data
        lookup.PopulateViewColumns()
        lookup.NullText = ""
        lookup.View.Columns("id_code_detail").Visible = False
        lookup.View.Columns("value").Visible = False
        lookup.View.Columns("id_code").Visible = False
        '
        lookup.View.Columns("CODE").Caption = "Code"
        lookup.View.Columns("display_name").Caption = "Short Description"
        lookup.View.Columns("code_detail_name").Caption = "Description"

        lookup.DisplayMember = "value"
        lookup.ValueMember = "id_code_detail"

        grid.Columns(col).ColumnEdit = lookup
    End Sub

    Sub load_form()
        'checkFormAccess(Name)
        loadIsiParam()
        viewTemplate(LETemplate)

        viewSearchLookupQuery(SLERange, "SELECT * FROM tb_range", "id_range", "range", "id_range")

        If action = "ins" Then
            id_method = "0"
            TxtName.Text = FormMasterRawMaterial.GVRawMat.GetFocusedRowCellDisplayText("mat_name").ToString
            TxtDisplayName.Text = FormMasterRawMaterial.GVRawMat.GetFocusedRowCellDisplayText("mat_display_name").ToString
        ElseIf action = "upd" Then
            'others
            BViewImage.Enabled = True

            'image
            If System.IO.File.Exists(material_image_path_pps & id_pps & ".jpg") Then
                PictureEdit1.LoadAsync(material_image_path_pps & id_pps & ".jpg")
            Else
                PictureEdit1.LoadAsync(material_image_path_pps & "default" & ".jpg")
            End If

            'material detail
            Dim query As String = "SELECT * FROM tb_m_mat_det_pps WHERE id_mat_det_pps = '" + id_pps + "'"
            Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
            TxtName.Text = data.Rows(0)("mat_det_name").ToString
            TxtDisplayName.Text = data.Rows(0)("mat_det_display_name").ToString
            TxtMaterialFullCode.Text = data.Rows(0)("mat_det_code").ToString
            LEMethod.ItemIndex = LEMethod.Properties.GetDataSourceRowIndex("id_method", data.Rows(0)("id_method").ToString)
            TxtLifetime.Text = data.Rows(0)("lifetime").ToString
            id_method = data.Rows(0)("id_method").ToString
            SLERange.EditValue = data.Rows(0)("id_range").ToString
            'code
            'code prepare
            query = String.Format("SELECT cd.id_code as id_code,cd.id_code_detail as id_code_detail FROM tb_m_mat_det_pps_code mdpc
INNER JOIN tb_m_code_detail cd WHERE  mdpc.id_code_detail = cd.id_code_detail AND mdpc.id_mat_det_pps = '{0}'", id_pps)
            Dim data_value As DataTable = execute_query(query, -1, True, "", "", "", "")

            If Not data_value.Rows.Count = 0 Then
                Dim id_check As String = "1"
                For i As Integer = 0 To data_value.Rows.Count - 1
                    If data_insert_parameter.Select("code = '" + data_value.Rows(i)("id_code").ToString + "'").Length = 0 Then
                        id_check = "2"
                    End If
                Next
                If id_check = "2" Then 'old
                    data_insert_parameter.Clear()
                    For i As Integer = 0 To data_value.Rows.Count - 1
                        data_insert_parameter.Rows.Add(data_value.Rows(i)("id_code").ToString, data_value.Rows(i)("id_code_detail").ToString)
                    Next
                Else
                    For x As Integer = 0 To data_insert_parameter.Rows.Count - 1
                        For i As Integer = 0 To data_value.Rows.Count - 1
                            If data_insert_parameter.Rows(x)("code").ToString = data_value.Rows(i)("id_code").ToString Then
                                data_insert_parameter.Rows(x)("value") = data_value.Rows(i)("id_code_detail").ToString
                            End If
                        Next
                    Next
                End If
            End If
        End If
    End Sub
End Class