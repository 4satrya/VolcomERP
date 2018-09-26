Imports DevExpress.XtraEditors

Public Class FormMasterRawMaterialDetSingle
    Public data_insert_parameter As New DataTable
    Public action As String
    Public id_mat_det As String
    Public id_mat As String
    Public id_method As String
    'Dim material_image_path As String = "\\192.168.1.30\dataapp\material\"
    Dim material_image_path As String = get_setup_field("pic_path_mat") & "\"
    Public id_pop_up As String = "-1"
    '----GENERAL------------------------
    'Validating Name
    Private Sub TxtName_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TxtName.Validating
        EP_TE_cant_blank(EPMaterial, TxtName)
    End Sub
    'Validating Display Name
    Private Sub TxtDisplayName_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TxtDisplayName.Validating
        EP_TE_cant_blank(EPMaterial, TxtDisplayName)
    End Sub
    'Validating Full Code
    Private Sub TxtMaterialFullCode_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TxtMaterialFullCode.Validating
        validatingFullCode()
    End Sub
    Sub validatingFullCode()
        Dim query_jml As String
        If action = "ins" Then
            'new
            query_jml = String.Format("SELECT COUNT(id_mat_det) FROM tb_m_mat_det WHERE mat_det_code='{0}'", TxtMaterialFullCode.Text)
        Else
            query_jml = String.Format("SELECT COUNT(id_mat_det) FROM tb_m_mat_det WHERE mat_det_code='{0}' AND id_mat_det!='{1}'", TxtMaterialFullCode.Text, id_mat_det)
        End If

        Dim jml As Integer = execute_query(query_jml, 0, True, "", "", "", "")
        If Not jml < 1 Then
            EP_TE_already_used(EPMaterial, TxtMaterialFullCode, "1")
        Else
            EP_TE_cant_blank(EPMaterial, TxtMaterialFullCode)
        End If
    End Sub
    'Material Code
    'Save
    Private Sub BSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BSave.Click
        'validate
        Cursor = Cursors.WaitCursor
        validatingFullCode()
        If Not EPMaterial.GetError(TxtMaterialFullCode).ToString = "" Or Not formIsValidInPanel(EPMaterial, PanC1) Or Not formIsValidInPanel(EPMaterial, PanC2) Then
            errorInput()
        Else
            Dim query As String
            Dim mat_det_display_name As String = addSlashes(TxtDisplayName.Text)
            Dim mat_det_name As String = addSlashes(TxtName.Text)
            Dim mat_det_code As String = addSlashes(TxtMaterialFullCode.Text)
            Dim id_method As String = LEMethod.EditValue.ToString
            Dim lifetime As String = TxtLifetime.Text

            Dim gramasi As String = "0"

            If Not SEGramation.Text = "" Then
                gramasi = decimalSQL(SEGramation.EditValue.ToString)
            End If

            Dim id_fab_type As String = LEFabType.EditValue.ToString
            Dim is_allow As String = "2"
            If CEAllowDesign.Checked = True Then
                is_allow = "1"
            End If

            If action = "ins" Then
                Try
                    'insert db
                    query = "INSERT INTO tb_m_mat_det(id_mat, mat_det_display_name, mat_det_name, mat_det_code, id_method, lifetime, mat_det_date, allow_design, id_fab_type, gramasi,id_range) "
                    query += "VALUES('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', DATE(NOW()),'{6}','{7}','{8}','{9}');SELECT LAST_INSERT_ID() "
                    query = String.Format(query, id_mat, mat_det_display_name, mat_det_name, mat_det_code, id_method, lifetime, is_allow, id_fab_type, gramasi, SLERange.EditValue.ToString)

                    id_mat_det = execute_query(query, 0, True, "", "", "", "")

                    logData("tb_mat_det", 1)

                    query = String.Format("INSERT INTO tb_m_mat_det_price(id_mat_det,mat_det_price_name,id_currency,id_comp_contact,mat_det_price,mat_det_price_date,is_default_cost) VALUES('{0}','Default Price','1',(SELECT id_comp_contact FROM tb_m_comp_contact LIMIT 1),'0',DATE(NOW()),'1')", id_mat_det)
                    execute_non_query(query, True, "", "", "", "")

                    'cek image
                    If Not PictureEdit1.EditValue Is Nothing Then
                        save_image_ori(PictureEdit1, material_image_path, id_mat_det & ".jpg")
                    End If

                    query = String.Format("DELETE FROM tb_m_mat_det_code WHERE id_mat_det='" & id_mat_det & "'")
                    execute_non_query(query, True, "", "", "", "")
                    For i As Integer = 0 To GVCodeMaterial.RowCount - 1
                        Try
                            If Not GVCodeMaterial.GetRowCellValue(i, "value").ToString = "" Or GVCodeMaterial.GetRowCellValue(i, "value").ToString = 0 Then
                                query = String.Format("INSERT INTO tb_m_mat_det_code(id_mat_det, id_code_detail) VALUES('{0}','{1}')", id_mat_det, GVCodeMaterial.GetRowCellValue(i, "value").ToString)
                                execute_non_query(query, True, "", "", "", "")
                            End If
                        Catch ex As Exception
                        End Try
                    Next
                    FormMasterRawMaterial.viewMatDetail()
                    FormMasterRawMaterial.GVMatDetail.FocusedRowHandle = find_row(FormMasterRawMaterial.GVMatDetail, "id_mat_det", id_mat_det)
                    infoCustom("Raw material added.")
                    action = "upd"
                    load_form()
                Catch ex As Exception
                    errorConnection()
                End Try
            ElseIf action = "upd" Then
                Try
                    'update db
                    query = "UPDATE tb_m_mat_det SET mat_det_display_name = '{0}', mat_det_name='{1}', mat_det_code='{2}', id_method='{3}', "
                    query += "lifetime = '{4}', allow_design='{6}',id_fab_type='{7}',gramasi='{8}',id_range='{9}'  WHERE id_mat_det = '{5}'"
                    query = String.Format(query, mat_det_display_name, mat_det_name, mat_det_code, id_method, lifetime, id_mat_det, is_allow, id_fab_type, gramasi, SLERange.EditValue.ToString)
                    execute_non_query(query, True, "", "", "", "")
                    logData("tb_mat_det", 1)

                    'cek image
                    save_image_ori(PictureEdit1, material_image_path, id_mat_det & ".jpg")
                    query = String.Format("DELETE FROM tb_m_mat_det_code WHERE id_mat_det='" & id_mat_det & "'")
                    execute_non_query(query, True, "", "", "", "")
                    For i As Integer = 0 To GVCodeMaterial.RowCount - 1
                        Try
                            If Not GVCodeMaterial.GetRowCellValue(i, "value").ToString = "" Or GVCodeMaterial.GetRowCellValue(i, "value").ToString = 0 Then
                                query = String.Format("INSERT INTO tb_m_mat_det_code(id_mat_det, id_code_detail) VALUES('{0}','{1}')", id_mat_det, GVCodeMaterial.GetRowCellValue(i, "value").ToString)
                                execute_non_query(query, True, "", "", "", "")
                            End If
                        Catch ex As Exception
                        End Try
                    Next
                    If id_pop_up = "1" Then
                        FormMatRecPurcDet.refresh_list()
                    ElseIf id_pop_up = "2" Then
                        FormMatRecWODet.refresh_list()
                    Else
                        FormMasterRawMaterial.viewMatDetail()
                        FormMasterRawMaterial.GVMatDetail.FocusedRowHandle = find_row(FormMasterRawMaterial.GVMatDetail, "id_mat_det", id_mat_det)
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
    'Form Load
    Private Sub FormMasterRawMaterialDetSingle_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        load_form()
    End Sub

    Sub load_form()
        'checkFormAccess(Name)
        viewInventoryMethod()
        viewFabType()

        loadIsiParam()
        viewTemplate(LETemplate)

        viewSearchLookupQuery(SLERange, "SELECT * FROM tb_range", "id_range", "range", "id_range")

        If action = "ins" Then
            id_method = "0"
            TxtName.Text = FormMasterRawMaterial.GVRawMat.GetFocusedRowCellDisplayText("mat_name").ToString
            TxtDisplayName.Text = FormMasterRawMaterial.GVRawMat.GetFocusedRowCellDisplayText("mat_display_name").ToString
        ElseIf action = "upd" Then
            'others
            viewPrice()
            BViewImage.Enabled = True
            'view_movement()
            XTPPrice.PageVisible = True
            XTPMovement.PageVisible = False

            'image
            If System.IO.File.Exists(material_image_path & id_mat_det & ".jpg") Then
                PictureEdit1.LoadAsync(material_image_path & id_mat_det & ".jpg")
            Else
                PictureEdit1.LoadAsync(material_image_path & "default" & ".jpg")
            End If

            'material detail
            Dim query As String = "SELECT * FROM tb_m_mat_det WHERE id_mat_det = '" + id_mat_det + "'"
            Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
            TxtName.Text = data.Rows(0)("mat_det_name").ToString
            TxtDisplayName.Text = data.Rows(0)("mat_det_display_name").ToString
            TxtMaterialFullCode.Text = data.Rows(0)("mat_det_code").ToString
            LEMethod.ItemIndex = LEMethod.Properties.GetDataSourceRowIndex("id_method", data.Rows(0)("id_method").ToString)
            LEFabType.ItemIndex = LEFabType.Properties.GetDataSourceRowIndex("id_fab_type", data.Rows(0)("id_fab_type").ToString)
            TxtLifetime.Text = data.Rows(0)("lifetime").ToString
            SEGramation.EditValue = data.Rows(0)("gramasi").ToString
            id_method = data.Rows(0)("id_method").ToString
            SLERange.EditValue = data.Rows(0)("id_range").ToString

            If data.Rows(0)("allow_design").ToString = "1" Then
                CEAllowDesign.Checked = True
            Else
                CEAllowDesign.Checked = False
            End If

            'code
            'code prepare
            query = String.Format("SELECT tb_m_code_detail.id_code as id_code,tb_m_mat_det_code.id_code_detail as id_code_detail FROM tb_m_mat_det_code,tb_m_code_detail WHERE  tb_m_mat_det_code.id_code_detail = tb_m_code_detail.id_code_detail AND tb_m_mat_det_code.id_mat_det = '{0}'", id_mat_det)
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
            'check if used
            Dim query_check As String = "SELECT mdprice.`id_mat_det` FROM `tb_mat_purc_det` mpd
                                        INNER JOIN `tb_mat_purc` mp ON mp.`id_mat_purc`=mpd.`id_mat_purc` AND mp.`id_report_status`!=5
                                        INNER JOIN `tb_m_mat_det_price` mdprice ON mdprice.`id_mat_det_price`=mpd.`id_mat_det_price`
                                        WHERE mdprice.`id_mat_det` = '" & id_mat_det & "'
                                        UNION
                                        SELECT mdprice.`id_mat_det` FROM `tb_bom_det` bomd
                                        INNER JOIN `tb_m_mat_det_price` mdprice ON mdprice.`id_mat_det_price`=bomd.`id_mat_det_price`
                                        WHERE mdprice.`id_mat_det` = '" & id_mat_det & "'
                                        UNION
                                        SELECT mrsd.`id_mat_det` FROM `tb_prod_order_mrs_det` mrsd
                                        WHERE mrsd.`id_mat_det` = '" & id_mat_det & "'"
            Dim data_check As DataTable = execute_query(query_check, -1, True, "", "", "", "")
            If data_check.Rows.Count > 0 Then
                PCSave.Visible = False
            Else
                PCSave.Visible = True
            End If
            '
        End If
    End Sub
    'View Inventory Method
    Sub viewInventoryMethod()
        Dim query As String = "(SELECT ('0') AS id_method, ('-Select Method-') AS method) "
        query += "UNION ALL "
        query += "(SELECT id_method, method FROM tb_lookup_inventory_method ORDER BY method ASC) "
        viewLookupQuery(LEMethod, query, 0, "method", "id_method")
    End Sub
    'View fabric type
    Sub viewFabType()
        Dim query As String = "SELECT id_fab_type, fab_type FROM tb_lookup_fab_type ORDER BY id_fab_type DESC "
        viewLookupQuery(LEFabType, query, 0, "fab_type", "id_fab_type")
    End Sub
    'View Template
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
    'Load Paramter
    Sub loadIsiParam()
        Cursor = Cursors.WaitCursor

        data_insert_parameter.Clear()

        If data_insert_parameter.Columns.Count < 2 Then
            data_insert_parameter.Columns.Add("code")
            data_insert_parameter.Columns.Add("value")
        End If

        GCCodeMaterial.DataSource = data_insert_parameter
        DNCodeMaterial.DataSource = data_insert_parameter

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
    'Event Edit 
    Private Sub LETemplate_EditValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LETemplate.EditValueChanged
        load_template(LETemplate.EditValue)
    End Sub
    'Load Template
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
    'Shown Editor
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
    'Btn Generate
    Private Sub BGenerate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BGenerate.Click
        generateCode()
    End Sub
    'Generate Code
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
    'Form Closed
    Private Sub FormMasterRawMaterialDetSingle_FormClosed(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub
    'Key Up Code
    'Private Sub TxtMaterialCode_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs)
    '    TxtMaterialFullCode.Text = ""
    '    TxtMaterialFullCode.Text = TxtMaterialTypeCode.Text + TxtMaterialCode.Text
    'End Sub
    '----PRICE-------------------
    'View Price
    Sub viewPrice()
        Dim query As String = "SELECT a.id_mat_det,a.id_mat_det_price,a.mat_det_price,a.mat_det_price_name,a.mat_det_price_date,c.comp_name,a.id_currency,d.currency,IF(a.is_default_cost=1,'yes','no') AS is_default_cost FROM tb_m_mat_det_price a "
        query += "INNER JOIN tb_m_comp_contact b ON a.id_comp_contact = b.id_comp_contact "
        query += "INNER JOIN tb_m_comp c ON c.id_comp = b.id_comp "
        query += "INNER JOIN tb_lookup_currency d ON a.id_currency = d.id_currency "
        query += "WHERE a.id_mat_det = '" + id_mat_det + "' "
        query += "ORDER BY a.mat_det_price_date ASC "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCPrice.DataSource = data
        If data.Rows.Count < 1 Then
            BtnDelete.Visible = False
            BtnEdit.Visible = False
        Else
            BtnDelete.Visible = True
            BtnEdit.Visible = True
        End If
        If id_pop_up = "1" Then
            FormMatRecPurcDet.refresh_list()
        ElseIf id_pop_up = "2" Then
            FormMatRecWODet.refresh_list()
        End If
    End Sub
    'Add Price
    Private Sub BtnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnAdd.Click
        Dim query_, res As String
        'check first
        query_ = String.Format("SELECT count(id_storage_mat) FROM tb_storage_mat WHERE id_mat_det='{0}' ", id_mat_det)
        res = execute_query(query_, 0, True, "", "", "", "")
        If Not res = "0" Then
            stopCustom("Material already used with default cost.")
        Else
            FormMasterRawMaterialPrcSingle.action = "ins"
            FormMasterRawMaterialPrcSingle.ShowDialog()
        End If
    End Sub
    'Delete Price
    Private Sub BtnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnDelete.Click
        Dim query_, res As String
        'check first
        query_ = String.Format("SELECT count(id_storage_mat) FROM tb_storage_mat WHERE id_mat_det='{0}' ", id_mat_det)
        res = execute_query(query_, 0, True, "", "", "", "")
        If Not res = "0" Then
            stopCustom("Material already used with default cost.")
        Else
            Dim confirm As DialogResult = XtraMessageBox.Show("Are you sure want to delete this price?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
            If confirm = Windows.Forms.DialogResult.Yes Then
                Cursor = Cursors.WaitCursor
                Try
                    Dim id_mat_det_price As String = GVPrice.GetFocusedRowCellDisplayText("id_mat_det_price").ToString
                    Dim query As String = String.Format("DELETE FROM tb_m_mat_det_price WHERE id_mat_det_price = '{0}'", id_mat_det_price)
                    execute_non_query(query, True, "", "", "", "")
                    viewPrice()
                Catch ex As Exception
                    errorDelete()
                End Try
                Cursor = Cursors.Default
            End If
        End If
    End Sub
    'Edit Price
    Private Sub BtnEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnEdit.Click
        Dim query_, res As String
        'check first
        query_ = String.Format("SELECT count(id_storage_mat) FROM tb_storage_mat WHERE id_mat_det='{0}' ", id_mat_det)
        res = execute_query(query_, 0, True, "", "", "", "")
        If Not res = "0" Then
            stopCustom("Material already used with default cost.")
        Else
            FormMasterRawMaterialPrcSingle.action = "upd"
            FormMasterRawMaterialPrcSingle.id_mat_det_price = GVPrice.GetFocusedRowCellDisplayText("id_mat_det_price").ToString
            FormMasterRawMaterialPrcSingle.ShowDialog()
        End If
    End Sub
    '----------MOVEMENT-----------------
    Sub viewMovement()
        Dim query As String = "SELECT *, CONCAT(DATE(a.mat_det_movement_datetime),' ',TIME(a.mat_det_movement_datetime)) AS time_movement "
        query += "FROM tb_m_mat_det_movement a "
        query += "INNER JOIN tb_m_comp_contact c ON a.id_comp_contact = c.id_comp_contact "
        query += "INNER JOIN tb_lookup_movement_category d ON a.id_movement_category = d.id_movement_category "
        query += "WHERE a.id_mat_det = '" + id_mat_det + "' "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCMovement.DataSource = data
    End Sub
    'View Image
    Private Sub BViewImage_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BViewImage.Click
        Try
            If System.IO.File.Exists(material_image_path & id_mat_det & ".jpg") Then
                Process.Start(material_image_path & id_mat_det & ".jpg")
            Else
                Process.Start(material_image_path & "default" & ".jpg")
            End If
        Catch ex As Exception
        End Try
    End Sub
    Private Sub PictureEdit1_Modified(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureEdit1.Modified
        BViewImage.Enabled = False
    End Sub

    Private Sub XTCDetSample_SelectedPageChanged(ByVal sender As System.Object, ByVal e As DevExpress.XtraTab.TabPageChangedEventArgs) Handles XTCDetSample.SelectedPageChanged
        If XTCDetSample.SelectedTabPageIndex = 0 Then
            viewInventoryMethod()
            LEMethod.ItemIndex = LEMethod.Properties.GetDataSourceRowIndex("id_method", id_method)
        End If
    End Sub

    Private Sub BSetDefault_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BSetDefault.Click
        Dim id_mat_det_price As String = GVPrice.GetFocusedRowCellDisplayText("id_mat_det_price").ToString
        Dim query, res As String
        'check first
        query = String.Format("SELECT count(id_storage_mat) FROM tb_storage_mat WHERE id_mat_det='{0}' ", id_mat_det)
        res = execute_query(query, 0, True, "", "", "", "")

        If Not get_setup_field("id_currency_default") = GVPrice.GetFocusedRowCellDisplayText("id_currency").ToString Then
            stopCustom("Please choose price using default currency.")
        ElseIf Not res = "0" Then
            stopCustom("Material already stored by default cost.")
        Else
            Dim confirm As DialogResult

            confirm = DevExpress.XtraEditors.XtraMessageBox.Show("Are you sure want to change material cost to this price?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
            If confirm = Windows.Forms.DialogResult.Yes Then
                Cursor = Cursors.WaitCursor
                Try
                    query = String.Format("UPDATE tb_m_mat_det_price SET is_default_cost='2' WHERE id_mat_det='{1}'; UPDATE tb_m_mat_det_price SET is_default_cost='1' WHERE id_mat_det_price = '{0}'", id_mat_det_price, id_mat_det)
                    execute_non_query(query, True, "", "", "", "")
                    viewPrice()
                    infoCustom("Default cost changed.")
                Catch ex As Exception
                    DevExpress.XtraEditors.XtraMessageBox.Show("Please check your connection.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End Try
                Cursor = Cursors.Default
            End If
        End If
    End Sub

    Private Sub BRefreshCode_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BRefreshCode.Click
        loadIsiParam()
        load_template(LETemplate.EditValue)
    End Sub

    Private Sub BeditCode_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BeditCode.Click
        FormCodeTemplateEdit.id_pop_up = "4"
        FormCodeTemplateEdit.id_template_code = LETemplate.EditValue.ToString
        FormCodeTemplateEdit.ShowDialog()
    End Sub
End Class