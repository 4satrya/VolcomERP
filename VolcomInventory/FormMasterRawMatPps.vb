Public Class FormMasterRawMatPps
    Public data_insert_parameter As New DataTable
    Public action As String
    Public id_pps As String
    Public id_method As String
    'Dim material_image_path As String = "\\192.168.1.30\dataapp\material\"
    Dim material_image_path As String = get_setup_field("pic_path_mat") & "\"
    Dim material_image_path_pps As String = get_setup_field("pic_path_mat") & "\pps\"
    Public id_pop_up As String = "-1"
    'revise
    Public is_revise As String = "-1"
    Public id_mat_det_revise As String = "-1"

    Private Sub BClose_Click(sender As Object, e As EventArgs) Handles BClose.Click
        Close()
    End Sub

    Private Sub FormMasterRawMatPps_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub FormMasterRawMatPps_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        TEFOBPrice.EditValue = 0.0000

        load_form()
    End Sub

    Sub generateCode()
        Dim id_code, code, query As String
        Dim code_full As String = ""

        For i As Integer = 0 To GVCodeMaterial.RowCount - 1
            code = ""
            id_code = ""
            Try
                id_code = GVCodeMaterial.GetRowCellValue(i, "value").ToString
            Catch ex As Exception
                id_code = ""
            End Try

            If Not id_code = "" Or id_code = "0" Then
                query = String.Format("SELECT code FROM tb_m_code_detail WHERE id_code_detail='" & id_code & "'")
                code = execute_query(query, 0, True, "", "", "", "")
            End If
            code_full += code
        Next
        'TxtMaterialCode.Text = code_full
        TxtMaterialFullCode.Text = TxtMaterialTypeCode.Text + code_full
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

    Sub load_mat_cat()
        Dim q As String = "SELECT mat.id_mat,mat.`mat_code`,mat.mat_name,mat.mat_display_name,uom.`uom`
FROM tb_m_mat mat
INNER JOIN tb_m_uom uom ON uom.`id_uom`=mat.`id_uom` "
        viewSearchLookupQuery(SLEMaterialCategory, q, "id_mat", "mat_display_name", "id_mat")
        SLEMaterialCategory.EditValue = Nothing
    End Sub

    Private clone As DataView = Nothing
    Private Sub GVCodeMaterial_ShownEditor(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GVCodeMaterial.ShownEditor
        Dim view As DevExpress.XtraGrid.Views.Grid.GridView = CType(sender, DevExpress.XtraGrid.Views.Grid.GridView)
        If view.FocusedColumn.FieldName = "value" AndAlso TypeOf view.ActiveEditor Is DevExpress.XtraEditors.SearchLookUpEdit Then
            Dim edit As DevExpress.XtraEditors.SearchLookUpEdit
            Dim table As DataTable
            Dim row As DataRow

            edit = CType(view.ActiveEditor, DevExpress.XtraEditors.SearchLookUpEdit)
            Try
                table = CType(edit.Properties.DataSource, DataTable)
            Catch ex As Exception
                table = CType(edit.Properties.DataSource, DataView).Table
            End Try
            clone = New DataView(table)

            row = view.GetDataRow(view.FocusedRowHandle)
            clone.RowFilter = "[id_code] = " + row("code").ToString()
            edit.Properties.DataSource = clone
        End If
    End Sub

    'Hidden Editor
    Private Sub GVCodeMaterial_HiddenEditor(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GVCodeMaterial.HiddenEditor
        If clone IsNot Nothing Then
            clone.Dispose()
            clone = Nothing
        End If
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

    Sub load_contact()
        Dim q As String = "SELECT cc.`id_comp_contact`,cc.`id_comp`,c.`comp_number`,c.comp_name,c.`comp_display_name` ,c.`address_primary`,cat.`comp_cat_name`,cc.`contact_person`
FROM tb_m_comp_contact cc
INNER JOIN tb_m_comp c ON c.`id_comp`=cc.`id_comp`
INNER JOIN tb_m_comp_cat cat ON cat.`id_comp_cat`=c.`id_comp_cat`
WHERE cc.`is_default`=1 AND (c.id_comp_cat=8 OR c.id_comp_cat=1)"
        viewSearchLookupQuery(SLEVendor, q, "id_comp_contact", "comp_display_name", "id_comp_contact")
    End Sub

    Sub load_currency()
        Dim q As String = "SELECT `id_currency`,`currency` FROM `tb_lookup_currency` WHERE `is_active_cop`=1"
        viewSearchLookupQuery(SLECurrency, q, "id_currency", "currency", "id_currency")
    End Sub

    Sub load_form()
        'checkFormAccess(Name)
        load_currency()
        load_contact()
        load_mat_cat()
        loadIsiParam()
        viewTemplate(LETemplate)

        viewSearchLookupQuery(SLERange, "SELECT * FROM tb_range", "id_range", "range", "id_range")

        If action = "ins" Then
            id_method = "0"
            '
            If is_revise = "1" Then
                'revisi lgsg isi
                Dim q As String = "SELECT mdp.id_comp_contact,mdp.id_currency,matd.id_method,matd.`id_mat`,mat.`mat_display_name`,mat.`mat_code`,matd.`mat_det_code`,matd.`mat_det_display_name`,matd.`mat_det_name`,uom.`uom`,matd.`lifetime`,matd.`id_range` ,IFNULL(mdp.`mat_det_price`,0) AS fob_price
FROM `tb_m_mat_det` matd
INNER JOIN tb_m_mat mat ON mat.`id_mat`=matd.`id_mat`
INNER JOIN tb_m_uom uom ON uom.`id_uom`=mat.`id_uom`
LEFT JOIN tb_m_mat_det_price mdp ON mdp.`id_mat_det`=matd.`id_mat_det` AND mdp.`is_default_po`=1
WHERE matd.`id_mat_det`='" & id_mat_det_revise & "'"
                Dim dt As DataTable = execute_query(q, -1, True, "", "", "", "")
                If dt.Rows.Count > 0 Then
                    If IO.File.Exists(material_image_path & id_mat_det_revise & ".jpg") Then
                        PictureEdit1.LoadAsync(material_image_path & id_mat_det_revise & ".jpg")
                    Else
                        PictureEdit1.LoadAsync(material_image_path & "default" & ".jpg")
                    End If
                    '
                    SLECurrency.EditValue = dt.Rows(0)("id_currency").ToString
                    SLEVendor.EditValue = dt.Rows(0)("id_comp_contact").ToString
                    SLEMaterialCategory.EditValue = dt.Rows(0)("id_mat").ToString
                    TxtName.Text = dt.Rows(0)("mat_det_name").ToString
                    TxtDisplayName.Text = dt.Rows(0)("mat_det_display_name").ToString
                    TxtMaterialFullCode.Text = dt.Rows(0)("mat_det_code").ToString
                    TxtLifetime.Text = dt.Rows(0)("lifetime").ToString
                    id_method = dt.Rows(0)("id_method").ToString
                    SLERange.EditValue = dt.Rows(0)("id_range")
                    TEFOBPrice.EditValue = dt.Rows(0)("fob_price")
                    TEUOM.Text = dt.Rows(0)("uom").ToString
                    TxtMaterialTypeCode.Text = dt.Rows(0)("mat_code").ToString
                    '
                    q = String.Format("SELECT cd.id_code as id_code,cd.id_code_detail as id_code_detail FROM tb_m_mat_det_code mdpc
INNER JOIN tb_m_code_detail cd WHERE  mdpc.id_code_detail = cd.id_code_detail AND mdpc.id_mat_det = '{0}'", id_mat_det_revise)
                    Dim data_value As DataTable = execute_query(q, -1, True, "", "", "", "")

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
                LREvise.Visible = True
            Else
                LREvise.Visible = False
            End If
        ElseIf action = "upd" Then
            'others
            BViewImage.Enabled = True

            'image
            If IO.File.Exists(material_image_path_pps & id_pps & ".jpg") Then
                PictureEdit1.LoadAsync(material_image_path_pps & id_pps & ".jpg")
            Else
                PictureEdit1.LoadAsync(material_image_path_pps & "default" & ".jpg")
            End If

            'material detail
            Dim query As String = "SELECT mat.mat_code,mat.`mat_display_name`,uom.`uom`,emp.`employee_name`,emp_u.`employee_name` AS emp_update,pps.*
FROM `tb_m_mat_det_pps` pps
INNER JOIN tb_m_mat mat ON mat.`id_mat`=pps.`id_mat`
INNER JOIN tb_m_uom uom ON uom.`id_uom`=mat.`id_uom`
LEFT JOIN tb_m_user usr ON usr.`id_user`=pps.`created_by`
LEFT JOIN tb_m_employee emp ON emp.`employee_name`=usr.`id_user`
LEFT JOIN tb_m_user usr_u ON usr_u.`id_user`=pps.`last_update_by`
LEFT JOIN tb_m_employee emp_u ON emp_u.`id_employee`=usr_u.`id_employee`
WHERE pps.id_mat_det_pps='" + id_pps + "'"
            Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
            id_mat_det_revise = data.Rows(0)("id_mat_det_revise").ToString
            is_revise = data.Rows(0)("is_revise").ToString
            SLECurrency.EditValue = data.Rows(0)("id_currency").ToString
            SLEVendor.EditValue = data.Rows(0)("id_comp_contact").ToString
            SLEMaterialCategory.EditValue = data.Rows(0)("id_mat").ToString
            TxtName.Text = data.Rows(0)("mat_det_name").ToString
            TxtDisplayName.Text = data.Rows(0)("mat_det_display_name").ToString
            TxtMaterialFullCode.Text = data.Rows(0)("mat_det_code").ToString
            TxtLifetime.Text = data.Rows(0)("lifetime").ToString
            id_method = data.Rows(0)("id_method").ToString
            SLERange.EditValue = data.Rows(0)("id_range").ToString
            TEFOBPrice.EditValue = data.Rows(0)("fob_price")
            TEUOM.Text = data.Rows(0)("uom").ToString
            TxtMaterialTypeCode.Text = data.Rows(0)("mat_code").ToString
            '
            If is_revise = "1" Then
                LREvise.Visible = True
            Else
                LREvise.Visible = False
            End If
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

    Private Sub SLEMaterialCategory_EditValueChanged(sender As Object, e As EventArgs) Handles SLEMaterialCategory.EditValueChanged
        Try
            TxtName.Text = SLEMaterialCategory.Properties.View.GetFocusedRowCellValue("mat_display_name").ToString
            TxtDisplayName.Text = SLEMaterialCategory.Properties.View.GetFocusedRowCellValue("mat_display_name").ToString
            TEUOM.Text = SLEMaterialCategory.Properties.View.GetFocusedRowCellValue("uom").ToString
            TxtMaterialTypeCode.Text = SLEMaterialCategory.Properties.View.GetFocusedRowCellValue("mat_code").ToString
        Catch ex As Exception
            Console.WriteLine(ex.ToString)
        End Try
    End Sub

    Private Sub LETemplate_EditValueChanged(sender As Object, e As EventArgs) Handles LETemplate.EditValueChanged
        load_template(LETemplate.EditValue)
    End Sub

    Sub load_template(ByVal id_template As String)
        Dim query As String = String.Format("SELECT * FROM tb_template_code_det WHERE id_template_code = '{0}'", id_template)
        Dim data_value As DataTable = execute_query(query, -1, True, "", "", "", "")

        data_insert_parameter.Clear()
        If Not data_value.Rows.Count = 0 Then
            For i As Integer = 0 To data_value.Rows.Count - 1
                data_insert_parameter.Rows.Add(data_value.Rows(i)("id_code").ToString)
            Next
        End If
    End Sub

    Private Sub BeditCode_Click(sender As Object, e As EventArgs) Handles BeditCode.Click
        FormCodeTemplateEdit.id_pop_up = "4pps"
        FormCodeTemplateEdit.id_template_code = LETemplate.EditValue.ToString
        FormCodeTemplateEdit.ShowDialog()
    End Sub

    Private Sub BRefreshCode_Click(sender As Object, e As EventArgs) Handles BRefreshCode.Click
        loadIsiParam()
        load_template(LETemplate.EditValue)
    End Sub

    Private Sub BGenerate_Click(sender As Object, e As EventArgs) Handles BGenerate.Click
        generateCode()
    End Sub

    Function validatingFullCode()
        Dim query_jml As String

        query_jml = String.Format("SELECT SUM(jml.jml) AS jml
FROM
(
SELECT COUNT(id_mat_det) AS jml FROM tb_m_mat_det WHERE mat_det_code='{0}' AND id_mat_det!='{2}'
UNION ALL
SELECT COUNT(id_mat_det_pps) AS jml FROM tb_m_mat_det_pps WHERE mat_det_code='{0}' AND id_mat_det_pps!='{1}' AND id_report_status!=5 AND id_report_status!=6
) AS jml", TxtMaterialFullCode.Text, id_pps, id_mat_det_revise)

        Dim jml As String = execute_query(query_jml, 0, True, "", "", "", "")
        If jml = "0" Then
            Return True
        Else
            Return False
        End If
    End Function

    Private Sub BSave_Click(sender As Object, e As EventArgs) Handles BSave.Click
        'validate
        Cursor = Cursors.WaitCursor
        If Not validatingFullCode() Then
            warningCustom("Code already used or already proposed")
        ElseIf SLEMaterialCategory.EditValue = Nothing Then
            warningCustom("Please select material category.")
        ElseIf TEFOBPrice.EditValue = 0 Then
            warningCustom("Please put FOB price.")
        ElseIf TxtMaterialFullCode.Text = "" Then
            warningCustom("Please generate code or fill material code.")
        Else
            Dim query As String
            Dim mat_det_display_name As String = addSlashes(TxtDisplayName.Text)
            Dim mat_det_name As String = addSlashes(TxtName.Text)
            Dim mat_det_code As String = addSlashes(TxtMaterialFullCode.Text)
            Dim id_method As String = "3" 'average
            Dim lifetime As String = TxtLifetime.Text

            Dim is_rev As String = If(is_revise = "-1", "2", "1")
            Dim id_mat_rev As String = If(id_mat_det_revise = "-1", "NULL", "'" & id_mat_det_revise & "'")

            Dim gramasi As String = "0"

            Dim id_fab_type As String = "0"
            Dim is_allow As String = "2"
            If action = "ins" Then
                Try
                    'insert db
                    query = "INSERT INTO tb_m_mat_det_pps(id_mat, mat_det_display_name, mat_det_name, mat_det_code, id_method, lifetime, mat_det_date, allow_design, id_fab_type, gramasi,id_range,id_comp_contact,id_currency,fob_price,created_by,id_mat_det_revise,is_revise) "
                    query += "VALUES('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', DATE(NOW()),'{6}','{7}','{8}','{9}','{10}','{11}','{12}','{13}',{14},'{15}');SELECT LAST_INSERT_ID() "
                    query = String.Format(query, SLEMaterialCategory.EditValue.ToString, mat_det_display_name, mat_det_name, mat_det_code, id_method, lifetime, is_allow, id_fab_type, gramasi, SLERange.EditValue.ToString, SLEVendor.EditValue.ToString, SLECurrency.EditValue.ToString, decimalSQL(TEFOBPrice.EditValue.ToString), id_user, id_mat_rev, is_rev)

                    id_pps = execute_query(query, 0, True, "", "", "", "")

                    'cek image
                    If Not PictureEdit1.EditValue Is Nothing Then
                        save_image_ori(PictureEdit1, material_image_path_pps, id_pps & ".jpg")
                    End If

                    query = String.Format("DELETE FROM tb_m_mat_det_pps_code WHERE id_mat_det_pps='" & id_pps & "'")
                    execute_non_query(query, True, "", "", "", "")
                    For i As Integer = 0 To GVCodeMaterial.RowCount - 1
                        Try
                            If Not GVCodeMaterial.GetRowCellValue(i, "value").ToString = "" Or GVCodeMaterial.GetRowCellValue(i, "value").ToString = 0 Then
                                query = String.Format("INSERT INTO tb_m_mat_det_pps_code(id_mat_det_pps, id_code_detail) VALUES('{0}','{1}')", id_pps, GVCodeMaterial.GetRowCellValue(i, "value").ToString)
                                execute_non_query(query, True, "", "", "", "")
                            End If
                        Catch ex As Exception
                        End Try
                    Next
                    '
                    FormMasterRawMaterial.view_refresh_pps()
                    FormMasterRawMaterial.GVPropose.FocusedRowHandle = find_row(FormMasterRawMaterial.GVPropose, "id_mat_det_pps", id_pps)
                    infoCustom("Raw material proposed.")
                    '
                    action = "upd"
                    load_form()
                Catch ex As Exception
                    errorConnection()
                End Try
            ElseIf action = "upd" Then
                Try
                    'update db
                    query = "UPDATE tb_m_mat_det_pps SET mat_det_display_name = '{0}', mat_det_name='{1}', mat_det_code='{2}', id_method='{3}', "
                    query += "lifetime = '{4}', allow_design='{6}',id_fab_type='{7}',gramasi='{8}',id_range='{9}',id_mat='{10}',last_update_date=NOW(),last_update_by='{11}',id_comp_contact='{12}',id_currency='{13}',fob_price='{14}',id_mat_det_revise={15},is_revise='{16}'  WHERE id_mat_det_pps = '{5}'"
                    query = String.Format(query, mat_det_display_name, mat_det_name, mat_det_code, id_method, lifetime, id_pps, is_allow, id_fab_type, gramasi, SLERange.EditValue.ToString, SLEMaterialCategory.EditValue.ToString, id_user, SLEVendor.EditValue.ToString, SLECurrency.EditValue.ToString, decimalSQL(TEFOBPrice.EditValue.ToString), id_mat_rev, is_rev)
                    execute_non_query(query, True, "", "", "", "")

                    'cek image
                    save_image_ori(PictureEdit1, material_image_path_pps, id_pps & ".jpg")
                    query = String.Format("DELETE FROM tb_m_mat_det_pps_code WHERE id_mat_det_pps='" & id_pps & "'")
                    execute_non_query(query, True, "", "", "", "")
                    For i As Integer = 0 To GVCodeMaterial.RowCount - 1
                        Try
                            If Not GVCodeMaterial.GetRowCellValue(i, "value").ToString = "" Or GVCodeMaterial.GetRowCellValue(i, "value").ToString = 0 Then
                                query = String.Format("INSERT INTO tb_m_mat_det_pps_code(id_mat_det_pps, id_code_detail) VALUES('{0}','{1}')", id_pps, GVCodeMaterial.GetRowCellValue(i, "value").ToString)
                                execute_non_query(query, True, "", "", "", "")
                            End If
                        Catch ex As Exception
                        End Try
                    Next
                    If id_pop_up = "1" Then
                        'FormMatRecPurcDet.refresh_list()
                    ElseIf id_pop_up = "2" Then
                        'FormMatRecWODet.refresh_list()
                    Else
                        FormMasterRawMaterial.view_refresh_pps()
                        FormMasterRawMaterial.GVPropose.FocusedRowHandle = find_row(FormMasterRawMaterial.GVPropose, "id_mat_det_pps", id_pps)
                    End If
                    infoCustom("Raw material updated.")
                    load_form()
                Catch ex As Exception
                    errorConnection()
                End Try
            End If
            Cursor = Cursors.Default
        End If
    End Sub

    Private Sub BMark_Click(sender As Object, e As EventArgs) Handles BMark.Click
        '273
        FormReportMark.id_report = id_pps
        FormReportMark.report_mark_type = "273"
        FormReportMark.form_origin = Name
        FormReportMark.ShowDialog()
    End Sub
End Class