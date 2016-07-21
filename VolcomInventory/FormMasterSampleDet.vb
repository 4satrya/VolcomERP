Public Class FormMasterSampleDet
    Public data_insert_parameter As New DataTable
    Public id_sample As String = "-1"
    Dim sample_image_path As String = get_setup_field("pic_path_sample") & "\"
    Dim action_code As String
    Dim use_unique_code As String
    Public dupe As String = "-1"

    Private Sub BSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BSave.Click
        Cursor = Cursors.WaitCursor
        Dim id_status_nr, id_sample_tersimpan, query, sample_name, sample_display_name, sample_us_code, sample_code, sample_uom, sample_season, sample_season_orign, sample_fabrication As String
        sample_name = addSlashes(TEName.Text)
        sample_display_name = addSlashes(TEDisplayName.Text)
        sample_us_code = addSlashes(TEUSCode.Text)
        sample_code = addSlashes(TESampleCode.Text)
        sample_uom = LEUOM.EditValue
        sample_season = LESeason.EditValue
        sample_season_orign = LESeasonOrign.EditValue
        sample_fabrication = addSlashes(MESampleFabrication.Text)
        id_status_nr = LEStatus.EditValue
        'validate
        EP_TE_cant_blank(EPMasterSample, TEName)
        EP_TE_cant_blank(EPMasterSample, TEDisplayName)
        EP_TE_cant_blank(EPMasterSample, TESampleCode)
        EP_TE_cant_blank(EPMasterSample, TEUSCode)
        '

        If id_sample <> "-1" Then
            If dupe = "-1" Then
                'edit
                If Not formIsValidInPanel(EPMasterSample, PanC1) Or Not formIsValidInPanel(EPMasterSample, PanC2) Then
                    errorInput()
                Else
                    query = String.Format("UPDATE tb_m_sample SET sample_name='{0}',sample_display_name='{1}',sample_code='{2}',sample_us_code='{3}',id_uom='{4}',id_season='{5}',id_season_orign='{6}', sample_fabrication='{7}',id_status_nr='{9}' WHERE id_sample='{8}'", sample_name, sample_display_name, sample_code, sample_us_code, sample_uom, sample_season, sample_season_orign, sample_fabrication, id_sample, id_status_nr)
                    execute_non_query(query, True, "", "", "", "")
                    If Not PictureEdit1.EditValue Is Nothing Then
                        save_image_ori(PictureEdit1, sample_image_path, id_sample & ".jpg")
                    End If
                    query = String.Format("DELETE FROM tb_m_sample_code WHERE id_sample='" & id_sample & "'")
                    execute_non_query(query, True, "", "", "", "")
                    For i As Integer = 0 To GVCodeSample.RowCount - 1
                        Try
                            If Not GVCodeSample.GetRowCellValue(i, "value").ToString = "" Or GVCodeSample.GetRowCellValue(i, "value").ToString = "0" Then
                                query = String.Format("INSERT INTO tb_m_sample_code(id_sample,id_code_detail) VALUES('{0}','{1}')", id_sample, GVCodeSample.GetRowCellValue(i, "value").ToString)
                                execute_non_query(query, True, "", "", "", "")
                            End If
                        Catch ex As Exception
                        End Try
                    Next
                    FormMasterSample.view_sample()
                    FormMasterSample.GVSample.FocusedRowHandle = find_row(FormMasterSample.GVSample, "id_sample", id_sample)
                    'Close()
                    'Dispose()
                    infoCustom("Sample saved.")
                    actionLoad()
                End If
            Else
                'insert
                If Not formIsValidInPanel(EPMasterSample, PanC2) Then
                    errorInput()
                ElseIf TEDisplayName.Text = "" Or TESampleCode.Text = "" Then
                    errorInput()
                Else
                    query = String.Format("INSERT INTO tb_m_sample(sample_name,sample_display_name,sample_code,sample_us_code,id_uom,id_season,id_season_orign, sample_fabrication, id_status_nr) VALUES('{0}','{1}','{2}','{3}','{4}','{5}','{6}', '{7}', '{8}');SELECT LAST_INSERT_ID()", sample_name, sample_display_name, sample_code, sample_us_code, sample_uom, sample_season, sample_season_orign, sample_fabrication, id_status_nr)
                    id_sample_tersimpan = execute_query(query, 0, True, "", "", "", "")

                    'insert default price
                    query = String.Format("INSERT INTO tb_m_sample_price(id_sample,sample_price_name,id_currency,id_comp_contact,sample_price,sample_price_date,is_default_cost,is_buy_price) VALUES('{0}','Default Price','1',(SELECT id_comp_contact FROM tb_m_comp_contact LIMIT 1),'0',DATE(NOW()),'1','1')", id_sample_tersimpan)
                    execute_non_query(query, True, "", "", "", "")

                    'insert default retail price
                    Dim query_ret_price As String = "INSERT INTO tb_m_sample_ret_price(id_sample, id_design_price_type, sample_ret_price_name, id_currency, sample_ret_price, sample_ret_price_date, sample_ret_price_start_date, is_print, id_user) VALUES "
                    query_ret_price += "('" + id_sample_tersimpan + "', '1', 'Default', '1', 0, DATE(NOW()), DATE(NOW()), 1, '" + id_user + "') "
                    execute_non_query(query_ret_price, True, "", "", "", "")

                    'cek image
                    If Not PictureEdit1.EditValue Is Nothing Then
                        save_image_ori(PictureEdit1, sample_image_path, id_sample_tersimpan & ".jpg")
                    End If
                    query = String.Format("DELETE FROM tb_m_sample_code WHERE id_sample='" & id_sample_tersimpan & "'")
                    execute_non_query(query, True, "", "", "", "")
                    For i As Integer = 0 To GVCodeSample.RowCount - 1
                        Try
                            If Not GVCodeSample.GetRowCellValue(i, "value").ToString = "" Or GVCodeSample.GetRowCellValue(i, "value").ToString = 0 Then
                                query = String.Format("INSERT INTO tb_m_sample_code(id_sample,id_code_detail) VALUES('{0}','{1}')", id_sample_tersimpan, GVCodeSample.GetRowCellValue(i, "value").ToString)
                                execute_non_query(query, True, "", "", "", "")
                            End If
                        Catch ex As Exception
                        End Try
                    Next
                    FormMasterSample.view_sample()
                    FormMasterSample.GVSample.FocusedRowHandle = find_row(FormMasterSample.GVSample, "id_sample", id_sample_tersimpan)
                    'Close()
                    'Dispose()
                    infoCustom("Sample saved.")
                    id_sample = id_sample_tersimpan
                    dupe = "-1"
                    actionLoad()
                End If
            End If
        Else
            'insert
            If Not formIsValidInPanel(EPMasterSample, PanC1) Or Not formIsValidInPanel(EPMasterSample, PanC2) Then
                errorInput()
            Else
                query = String.Format("INSERT INTO tb_m_sample(sample_name,sample_display_name,sample_code,sample_us_code,id_uom,id_season,id_season_orign, sample_fabrication) VALUES('{0}','{1}','{2}','{3}','{4}','{5}','{6}', '{7}');SELECT LAST_INSERT_ID()", sample_name, sample_display_name, sample_code, sample_us_code, sample_uom, sample_season, sample_season_orign, sample_fabrication)
                id_sample_tersimpan = execute_query(query, 0, True, "", "", "", "")
                'insert default price
                query = String.Format("INSERT INTO tb_m_sample_price(id_sample,sample_price_name,id_currency,id_comp_contact,sample_price,sample_price_date,is_default_cost,is_buy_price) VALUES('{0}','Default Price','1',(SELECT id_comp_contact FROM tb_m_comp_contact LIMIT 1),'0',DATE(NOW()),'1','1')", id_sample_tersimpan)
                execute_non_query(query, True, "", "", "", "")

                'insert default retail price
                Dim query_ret_price As String = "INSERT INTO tb_m_sample_ret_price(id_sample, id_design_price_type, sample_ret_price_name, id_currency, sample_ret_price, sample_ret_price_date, sample_ret_price_start_date, is_print, id_user) VALUES "
                query_ret_price += "('" + id_sample_tersimpan + "', '1', 'Default', '1', 0, DATE(NOW()), DATE(NOW()), 1, '" + id_user + "') "
                execute_non_query(query_ret_price, True, "", "", "", "")

                'cek image
                If Not PictureEdit1.EditValue Is Nothing Then
                    save_image_ori(PictureEdit1, sample_image_path, id_sample_tersimpan & ".jpg")
                End If
                query = String.Format("DELETE FROM tb_m_sample_code WHERE id_sample='" & id_sample_tersimpan & "'")
                execute_non_query(query, True, "", "", "", "")
                For i As Integer = 0 To GVCodeSample.RowCount - 1
                    Try
                        If Not GVCodeSample.GetRowCellValue(i, "value").ToString = "" Or GVCodeSample.GetRowCellValue(i, "value").ToString = 0 Then
                            query = String.Format("INSERT INTO tb_m_sample_code(id_sample,id_code_detail) VALUES('{0}','{1}')", id_sample_tersimpan, GVCodeSample.GetRowCellValue(i, "value").ToString)
                            execute_non_query(query, True, "", "", "", "")
                        End If
                    Catch ex As Exception
                    End Try
                Next
                FormMasterSample.view_sample()
                FormMasterSample.GVSample.FocusedRowHandle = find_row(FormMasterSample.GVSample, "id_sample", id_sample_tersimpan)
                'Close()
                'Dispose()
                infoCustom("Sample saved.")
                id_sample = id_sample_tersimpan
                actionLoad()
            End If
        End If
        Cursor = Cursors.Default
    End Sub

    'View UOM
    Private Sub viewUOM(ByVal lookup As DevExpress.XtraEditors.LookUpEdit)
        Dim query As String = "SELECT id_uom,uom FROM tb_m_uom ORDER BY id_uom ASC"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")

        lookup.Properties.DataSource = Nothing
        lookup.Properties.DataSource = data

        lookup.Properties.DisplayMember = "uom"
        lookup.Properties.ValueMember = "id_uom"
        lookup.ItemIndex = 0
    End Sub
    'View Status normal/reject
    Private Sub viewNR(ByVal lookup As DevExpress.XtraEditors.LookUpEdit)
        Dim query As String = "SELECT id_status_nr,status_nr FROM tb_lookup_status_nr ORDER BY id_status_nr ASC"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")

        lookup.Properties.DataSource = Nothing
        lookup.Properties.DataSource = data

        lookup.Properties.DisplayMember = "status_nr"
        lookup.Properties.ValueMember = "id_status_nr"
        lookup.ItemIndex = 0
    End Sub
    'View Season
    Private Sub viewSeason(ByVal lookup As DevExpress.XtraEditors.SearchLookUpEdit)
        Dim query As String = "SELECT id_season,season FROM tb_season ORDER BY id_season DESC"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")

        lookup.Properties.DataSource = Nothing
        lookup.Properties.DataSource = data

        lookup.Properties.DisplayMember = "season"
        lookup.Properties.ValueMember = "id_season"
        lookup.EditValue = data.Rows(0)("id_season").ToString
    End Sub
    'View Season Orign
    Private Sub viewSeasonOrign(ByVal lookup As DevExpress.XtraEditors.SearchLookUpEdit)
        Dim query As String = "SELECT id_season_orign,season_orign FROM tb_season_orign ORDER BY id_season_orign DESC"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")

        lookup.Properties.DataSource = Nothing
        lookup.Properties.DataSource = data

        lookup.Properties.DisplayMember = "season_orign"
        lookup.Properties.ValueMember = "id_season_orign"
        lookup.EditValue = data.Rows(0)("id_season_orign").ToString
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
            lookup.EditValue = get_setup_field("id_code_template_sample")
        Catch ex As Exception
            lookup.EditValue = data.Rows(0)("id_template_code").ToString
        End Try
    End Sub
    Sub load_isi_param()
        Cursor = Cursors.WaitCursor

        data_insert_parameter.Clear()

        If data_insert_parameter.Columns.Count < 2 Then
            data_insert_parameter.Columns.Add("code")
            data_insert_parameter.Columns.Add("value")
        End If

        GCCodeSample.DataSource = data_insert_parameter
        DNCodeSample.DataSource = data_insert_parameter

        Try
            add_combo_grid_val(GVCodeSample, 0)
            view_value_code(GVCodeSample, 1)
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
        lookup.ReadOnly = True
        lookup.PopulateViewColumns()
        lookup.NullText = ""
        lookup.View.Columns("id_code").Visible = False
        lookup.DisplayMember = "Code"
        lookup.ValueMember = "id_code"

        grid.Columns(col).ColumnEdit = lookup
    End Sub
    Private Sub FormMasterSampleDet_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        actionLoad()
    End Sub
    Sub actionLoad()
        Cursor = Cursors.WaitCursor
        viewUOM(LEUOM)
        viewNR(LEStatus)
        viewSeason(LESeason)
        viewSeasonOrign(LESeasonOrign)
        load_isi_param()
        viewTemplate(LETemplate)
        load_template(LETemplate.EditValue)
        If id_sample <> "-1" Then
            view_sample_price(id_sample)
            view_movement(id_sample)
            view_sample_note(id_sample)
            'edit
            pre_viewImages("1", PictureEdit1, id_sample, False)
            BViewImage.Visible = True

            Try
                Dim query As String = String.Format("SELECT * FROM tb_m_sample WHERE id_sample = '{0}'", id_sample)
                Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")

                TEName.Text = data.Rows(0)("sample_name").ToString
                TEDisplayName.Text = data.Rows(0)("sample_display_name").ToString
                TEUSCode.Text = data.Rows(0)("sample_us_code").ToString
                TESampleCode.Text = data.Rows(0)("sample_code").ToString
                MESampleFabrication.Text = data.Rows(0)("sample_fabrication").ToString
                LEUOM.EditValue = Nothing
                LEUOM.ItemIndex = LEUOM.Properties.GetDataSourceRowIndex("id_uom", data.Rows(0)("id_uom").ToString)
                '
                LEStatus.EditValue = Nothing
                LEStatus.ItemIndex = LEStatus.Properties.GetDataSourceRowIndex("id_status_nr", data.Rows(0)("id_status_nr").ToString)
                '
                LESeason.EditValue = data.Rows(0)("id_season").ToString
                LESeasonOrign.EditValue = data.Rows(0)("id_season_orign").ToString

                query = String.Format("SELECT tb_m_code_detail.id_code as id_code,tb_m_sample_code.id_code_detail as id_code_detail FROM tb_m_sample_code,tb_m_code_detail WHERE  tb_m_sample_code.id_code_detail = tb_m_code_detail.id_code_detail AND tb_m_sample_code.id_sample = '{0}'", id_sample)
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
                XTPPrice.PageVisible = True
                XTPNote.PageVisible = True
                'XTPMovement.PageVisible = True
                'XTPUnique.PageVisible = True

                'UNIQUE PROCESS
                LabelLastGenerate.Text = data.Rows(0)("inc_code").ToString
                If IsDBNull(data.Rows(0)("use_unique_code")) Then
                    action_code = "ins"
                    Dim query_default As String = "SELECT sample_unique_digit_counting FROM tb_opt "
                    Dim digit_counting As String = execute_query(query_default, 0, True, "", "", "", "")
                    SpDigitCounting.Text = digit_counting
                    SpDigitCounting.Enabled = True
                    LEIsUseUnique.Enabled = True
                Else
                    action_code = "upd"
                    SpDigitCounting.Text = data.Rows(0)("digit_code").ToString
                    SpDigitCounting.Enabled = False
                    LEIsUseUnique.Enabled = False
                    Dim query_list_unique As String = "SELECT CONCAT(b.sample_code, COALESCE(a.sample_unique_code, '')) AS sample_full_code FROM tb_m_sample_unique a "
                    query_list_unique += "INNER JOIN tb_m_sample b ON a.id_sample = b.id_sample "
                    query_list_unique += "WHERE a.id_sample = '" + id_sample + "' "
                    Dim data_list_unique As DataTable = execute_query(query_list_unique, -1, True, "", "", "", "")
                    GCUniqueTable.DataSource = data_list_unique
                End If
                use_unique_code = data.Rows(0)("use_unique_code").ToString

                'duplicate
                If dupe <> "-1" Then
                    XTPPrice.PageVisible = False
                    XTPNote.PageVisible = False
                    TEDisplayName.Text = ""
                    TESampleCode.Text = ""
                End If
            Catch ex As Exception
                errorConnection()
            End Try
        Else
            XTPPrice.PageVisible = False
            XTPMovement.PageVisible = False
            XTPUnique.PageVisible = False
            XTPNote.PageVisible = False
        End If
        Cursor = Cursors.Default
    End Sub
    Private Sub GVCodeSample_CellValueChanged(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles GVCodeSample.CellValueChanged
        If e.Column.Name.ToString <> "ColCodeParam" Then
            Exit Sub
        Else
            Dim cellValue As String = e.Value.ToString()

            Dim query As String = String.Format("SELECT id_code,id_code_detail,CODE as Code,code_detail_name as Name,display_name as 'Printed Name',CONCAT(CODE,' - ',code_detail_name) AS value FROM tb_m_code_detail WHERE id_code='" & cellValue.ToString & "'")
            Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
            GVCodeSample.SetRowCellValue(e.RowHandle, GVCodeSample.Columns("value"), data.Rows(0)("id_code").ToString)
        End If
    End Sub
    Sub viewAnswer()
        Dim query As String = "SELECT * FROM tb_lookup_answer ORDER BY id_answer "
        viewLookupQuery(LEIsUseUnique, query, 1, "answer", "id_answer")
    End Sub
    Sub view_value_code(ByVal grid As DevExpress.XtraGrid.Views.Grid.GridView, ByVal col As Integer)
        Dim lookup As New DevExpress.XtraEditors.Repository.RepositoryItemSearchLookUpEdit

        lookup.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor

        Dim query As String = String.Format("SELECT id_code,id_code_detail,CODE as Code,code_detail_name as Name,display_name as 'Printed Name',CONCAT(CODE,' - ',code_detail_name) AS value FROM tb_m_code_detail")
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")

        lookup.DataSource = Nothing
        lookup.DataSource = data
        lookup.PopulateViewColumns()
        lookup.NullText = ""
        lookup.View.Columns("id_code_detail").Visible = False
        lookup.View.Columns("value").Visible = False
        lookup.View.Columns("id_code").Visible = False
        lookup.DisplayMember = "value"
        lookup.ValueMember = "id_code_detail"

        grid.Columns(col).ColumnEdit = lookup
    End Sub
    Private clone As DataView = Nothing
    Private Sub GVCodeSample_ShownEditor(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GVCodeSample.ShownEditor
        Dim view As DevExpress.XtraGrid.Views.Grid.GridView = CType(sender, DevExpress.XtraGrid.Views.Grid.GridView)
        Try
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
        Catch ex As Exception
        End Try
    End Sub

    Private Sub GVCodeSample_HiddenEditor(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GVCodeSample.HiddenEditor
        If clone IsNot Nothing Then
            clone.Dispose()
            clone = Nothing
        End If
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

    Private Sub LETemplate_EditValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LETemplate.EditValueChanged
        load_template(LETemplate.EditValue)
    End Sub

    Private Sub BGenerate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BGenerate.Click
        Dim id_code, code, query As String
        Dim code_full As String = ""

        'code 
        For i As Integer = 0 To GVCodeSample.RowCount - 1
            code = ""
            id_code = ""
            Try
                id_code = GVCodeSample.GetRowCellValue(i, "value").ToString
            Catch ex As Exception
                id_code = ""
            End Try

            If Not id_code = "" Or id_code = "0" Then
                Try
                    query = String.Format("SELECT is_include_code FROM tb_m_code,tb_m_code_detail WHERE tb_m_code.id_code=tb_m_code_detail.id_code AND tb_m_code_detail.id_code_detail='" & id_code & "'")
                    code = execute_query(query, 0, True, "", "", "", "")
                Catch ex As Exception
                    code = "False"
                End Try

                If code = "True" Then
                    query = String.Format("SELECT code FROM tb_m_code_detail WHERE id_code_detail='" & id_code & "'")
                    code = execute_query(query, 0, True, "", "", "", "")
                Else
                    code = ""
                End If
            End If
            code_full += code
        Next
        TESampleCode.Text = code_full

        'display name
        Dim string_name As String = ""

        For i As Integer = 0 To GVCodeSample.RowCount - 1
            code = ""
            id_code = ""
            Try
                id_code = GVCodeSample.GetRowCellValue(i, "value").ToString
            Catch ex As Exception
                id_code = ""
            End Try

            If Not id_code = "" Or id_code = "0" Then
                query = String.Format("SELECT tb_m_code.is_include_name FROM tb_m_code,tb_m_code_detail WHERE tb_m_code.id_code=tb_m_code_detail.id_code AND tb_m_code_detail.id_code_detail='" & id_code & "'")
                code = execute_query(query, 0, True, "", "", "", "")
                If code.ToString = "True" Then
                    query = String.Format("SELECT display_name FROM tb_m_code_detail WHERE id_code_detail='" & id_code & "'")
                    code = execute_query(query, 0, True, "", "", "", "")
                    string_name += " " & code
                End If
            End If
        Next

        Dim disp As String = TEName.Text.ToUpper & string_name.ToUpper
        If disp.Length > 23 Then
            TEDisplayName.Text = disp.Substring(0, 23)
            LabelPrintedName.Text = disp.Substring(0, 23)
        Else
            TEDisplayName.Text = disp
            LabelPrintedName.Text = disp
        End If

    End Sub
    Private Sub TEDisplayName_EditValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TEDisplayName.EditValueChanged
        LabelPrintedName.Text = TEDisplayName.Text
    End Sub

    Private Sub TEName_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TEName.Validating
        EP_TE_cant_blank(EPMasterSample, TEName)
    End Sub

    Private Sub TEDisplayName_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TEDisplayName.Validating
        EP_TE_cant_blank(EPMasterSample, TEDisplayName)
    End Sub

    Private Sub TEUSCode_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TEUSCode.Validating
        EP_TE_cant_blank(EPMasterSample, TEUSCode)
    End Sub

    Private Sub TESampleCode_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TESampleCode.Validating
        EP_TE_cant_blank(EPMasterSample, TESampleCode)
    End Sub

    Private Sub FormMasterSampleDet_FormClosed(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    '========================begin code price===================

    Private Sub BAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BAdd.Click
        FormSamplePriceSingle.id_sample = id_sample
        FormSamplePriceSingle.ShowDialog()
    End Sub

    Sub view_sample_price(ByVal id_samplex As String)
        Dim query As String = "SELECT tb_lookup_currency.id_currency,tb_lookup_currency.currency,tb_m_sample_price.id_sample_price,tb_m_sample_price.sample_price_name,tb_m_sample_price.sample_price,tb_m_sample_price.sample_price_date,tb_m_comp.comp_name,IF(tb_m_sample_price.is_default_cost=1,'yes','no') AS is_default_cost,IF(tb_m_sample_price.is_buy_price=1,'yes','no') AS is_buy_price FROM tb_m_sample_price,tb_m_comp,tb_m_comp_contact,tb_lookup_currency WHERE tb_m_sample_price.id_currency=tb_lookup_currency.id_currency AND tb_m_sample_price.id_comp_contact=tb_m_comp_contact.id_comp_contact AND tb_m_comp_contact.id_comp=tb_m_comp.id_comp AND tb_m_sample_price.id_sample='" & id_samplex & "' ORDER BY tb_m_sample_price.id_sample_price DESC"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCSamplePrice.DataSource = data

        If data.Rows.Count < 1 Then
            Bdelete.Visible = False
            BSetDefault.Visible = False
        Else
            Bdelete.Visible = True
            BSetDefault.Visible = True
        End If
    End Sub

    Private Sub Bedit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BSetDefault.Click
        'FormSamplePriceSingle.id_sample = id_sample
        'FormSamplePriceSingle.id_sample_price = GVSamplePrice.GetFocusedRowCellDisplayText("id_sample_price").ToString
        'FormSamplePriceSingle.ShowDialog()

        'change default cost 
        Dim id_sample_price As String = GVSamplePrice.GetFocusedRowCellDisplayText("id_sample_price").ToString
        Dim query, res As String
        'check first
        query = String.Format("SELECT count(id_storage_sample) FROM tb_storage_sample WHERE id_sample='{0}' ", id_sample)
        res = execute_query(query, 0, True, "", "", "", "")

        If Not get_setup_field("id_currency_default") = GVSamplePrice.GetFocusedRowCellDisplayText("id_currency").ToString Then
            stopCustom("Please choose price using default currency.")
        ElseIf Not res = "0" Then
            stopCustom("Sample already stored by default cost.")
        Else
            Dim confirm As DialogResult

            confirm = DevExpress.XtraEditors.XtraMessageBox.Show("Are you sure want to change sample cost to this price?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
            If confirm = Windows.Forms.DialogResult.Yes Then
                Cursor = Cursors.WaitCursor
                Try
                    query = String.Format("UPDATE tb_m_sample_price SET is_default_cost='2' WHERE id_sample='{1}'; UPDATE tb_m_sample_price SET is_default_cost='1' WHERE id_sample_price = '{0}'", id_sample_price, id_sample)
                    execute_non_query(query, True, "", "", "", "")
                    view_sample_price(id_sample)
                    infoCustom("Default cost changed.")
                Catch ex As Exception
                    DevExpress.XtraEditors.XtraMessageBox.Show("Please check your connection.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End Try
                Cursor = Cursors.Default
            End If
        End If
    End Sub
    Private Sub Bdelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Bdelete.Click
        'delete
        Dim confirm As DialogResult
        Dim query As String
        confirm = DevExpress.XtraEditors.XtraMessageBox.Show("Are you sure want to delete this data?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)

        Dim id_sample_price As String = GVSamplePrice.GetFocusedRowCellDisplayText("id_sample_price").ToString
        If confirm = Windows.Forms.DialogResult.Yes Then
            Cursor = Cursors.WaitCursor
            Try
                query = String.Format("DELETE FROM tb_m_sample_price WHERE id_sample_price = '{0}'", id_sample_price)
                execute_non_query(query, True, "", "", "", "")
                view_sample_price(id_sample)
            Catch ex As Exception
                DevExpress.XtraEditors.XtraMessageBox.Show("This data already used. Can't delete.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
            Cursor = Cursors.Default
        End If
    End Sub
    '================== code movement =================
    Sub view_movement(ByVal id_samplex As String)
        Dim query As String = "SELECT a.id_sample_movement,d.movement_category,c.comp_name,a.sample_movement_qty,a.sample_movement_tot_price,CONCAT(DATE(a.sample_movement_datetime),' ',TIME(a.sample_movement_datetime)) AS datetimex "
        query += "FROM tb_m_sample_movement a, tb_m_comp_contact b, tb_m_comp c, tb_lookup_movement_category d "
        query += "WHERE a.id_comp_contact = b.id_comp_contact And b.id_comp = c.id_comp "
        query += "AND d.id_movement_category = a.id_movement_category "
        query += "AND a.id_sample = '" & id_samplex & "'"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCSampleMovement.DataSource = data
    End Sub

    Private Sub BViewImage_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BViewImage.Click
        Try
            pre_viewImages("1", PictureEdit1, id_sample, True)
        Catch ex As Exception
        End Try
    End Sub

    Private Sub PictureEdit1_Modified(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureEdit1.Modified
        BViewImage.Visible = False
    End Sub

    Private Sub XTCDetSample_SelectedPageChanged(ByVal sender As System.Object, ByVal e As DevExpress.XtraTab.TabPageChangedEventArgs) Handles XTCDetSample.SelectedPageChanged
        If XTCDetSample.SelectedTabPageIndex = "3" Then
            viewAnswer()
            If action_code = "ins" Then
                LEIsUseUnique.ItemIndex = 1
            Else
                LEIsUseUnique.Properties.GetDataSourceRowIndex("id_answer", use_unique_code)
            End If
        End If
    End Sub
    'Btn Save
    Private Sub BtnGenerateCode_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnGenerateCode.Click
        Dim confirm As DialogResult = DevExpress.XtraEditors.XtraMessageBox.Show("Are you sure want to generate code?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
        If confirm = Windows.Forms.DialogResult.Yes Then
            saveCode()
        End If
    End Sub
    Sub saveCode()
        Cursor = Cursors.WaitCursor
        BtnGenerateCode.Enabled = False
        GCUniqueTable.Enabled = False
        Dim inc_code As Integer = Integer.Parse(LabelLastGenerate.Text)
        Dim digit_code As String = Integer.Parse(SpDigitCounting.Text)
        use_unique_code = LEIsUseUnique.EditValue
        Dim qty As Integer = Integer.Parse(SPNumberGenerate.Text)
        Dim qty_plus_inc As Integer = inc_code + qty
        Dim max_qty As String = ""
        Dim query As String
        For i As Integer = 1 To Integer.Parse(digit_code)
            max_qty = max_qty + "9"
        Next
        If qty_plus_inc > Integer.Parse(max_qty) Then
            errorCustom("Maximum generate code : " + max_qty.ToString)
            GCUniqueTable.Enabled = True
        Else
            Try
                query = "UPDATE tb_m_sample SET digit_code = '" + digit_code + "', use_unique_code = '" + use_unique_code + "' WHERE id_sample = '" + id_sample + "' "
                execute_non_query(query, True, "", "", "", "")
                If use_unique_code = "1" Then
                    query = "CALL generate_code_unique('1', '" + qty.ToString + "', '" + id_sample + "', '" + digit_code + "',True) "
                Else
                    query = "CALL generate_code_unique('1', '" + qty.ToString + "', '" + id_sample + "', '" + digit_code + "',False) "
                End If
                execute_non_query(query, True, "", "", "", "")
                actionLoad()
            Catch ex As Exception
                MsgBox(ex.ToString)
                'errorConnection()
            End Try
        End If
        GCUniqueTable.Enabled = True
        BtnGenerateCode.Enabled = True
        Cursor = Cursors.Default
    End Sub
    'Reset
    Private Sub BtnReset_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnReset.Click
        Dim confirm As DialogResult = DevExpress.XtraEditors.XtraMessageBox.Show("Are you sure want to reset all code?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
        If confirm = Windows.Forms.DialogResult.Yes Then
            Cursor = Cursors.WaitCursor
            Try
                Dim query As String = "DELETE FROM tb_m_sample_unique WHERE id_sample = '" + id_sample + "' "
                execute_non_query(query, True, "", "", "", "")
                query = "UPDATE tb_m_sample SET digit_code = NULL, use_unique_code = NULL, inc_code = DEFAULT WHERE id_sample = '" + id_sample + "' "
                execute_non_query(query, True, "", "", "", "")
                GCUniqueTable.DataSource = Nothing
                LEIsUseUnique.ItemIndex = 1
                actionLoad()
            Catch ex As Exception
                errorCustom("Reset failed, this data currently used")
            End Try
            Cursor = Cursors.Default
        End If
    End Sub

    Private Sub BAddNote_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BAddNote.Click
        FormMasterSampleDetNote.id_sample = id_sample
        FormMasterSampleDetNote.ShowDialog()
    End Sub

    Private Sub BEditNote_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BEditNote.Click
        FormMasterSampleDetNote.id_sample = id_sample
        FormMasterSampleDetNote.id_sample_note = GVNote.GetFocusedRowCellDisplayText("id_sample_note").ToString
        FormMasterSampleDetNote.ShowDialog()
    End Sub

    Private Sub BDeleteNote_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BDeleteNote.Click
        'delete
        Dim confirm As DialogResult
        Dim query As String
        confirm = DevExpress.XtraEditors.XtraMessageBox.Show("Are you sure want to delete this note?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)

        Dim id_sample_note As String = GVNote.GetFocusedRowCellDisplayText("id_sample_note").ToString
        If confirm = Windows.Forms.DialogResult.Yes Then
            Cursor = Cursors.WaitCursor
            Try
                query = String.Format("DELETE FROM tb_m_sample_note WHERE id_sample_note = '{0}'", id_sample_note)
                execute_non_query(query, True, "", "", "", "")
                view_sample_note(id_sample)
            Catch ex As Exception
                DevExpress.XtraEditors.XtraMessageBox.Show("This data already used. Can't delete.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
            Cursor = Cursors.Default
        End If
    End Sub
    Sub view_sample_note(ByVal id_samplex As String)
        Dim query As String = "SELECT a.id_sample_note,a.sample_note,CONCAT(DATE(a.sample_note_datetime),' ',TIME(a.sample_note_datetime)) AS sample_note_datetime "
        query += "FROM tb_m_sample_note a "
        query += "WHERE a.id_sample = '" & id_samplex & "'"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCNote.DataSource = data
        If data.Rows.Count > 0 Then
            BEditNote.Visible = True
            BDeleteNote.Visible = True
        Else
            BEditNote.Visible = False
            BDeleteNote.Visible = False
        End If
    End Sub

    Private Sub GVNote_CustomColumnDisplayText(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs) Handles GVNote.CustomColumnDisplayText
        If e.Column.FieldName = "no" Then
            e.DisplayText = (e.ListSourceRowIndex + 1).ToString()
        End If
    End Sub

    Private Sub BRefreshCode_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BRefreshCode.Click
        load_isi_param()
        load_template(LETemplate.EditValue)
    End Sub

    Private Sub BeditCode_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BeditCode.Click
        FormCodeTemplateEdit.id_pop_up = "1"
        FormCodeTemplateEdit.id_template_code = LETemplate.EditValue.ToString
        FormCodeTemplateEdit.ShowDialog()
    End Sub

    Private Sub BSetFOBPrice_Click(sender As Object, e As EventArgs) Handles BSetFOBPrice.Click
        'change default cost 
        Dim id_sample_price As String = GVSamplePrice.GetFocusedRowCellDisplayText("id_sample_price").ToString
        Dim query As String

        Dim confirm As DialogResult

        confirm = DevExpress.XtraEditors.XtraMessageBox.Show("Are you sure want to change sample FOB price to this price?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)

        If confirm = Windows.Forms.DialogResult.Yes Then
            Cursor = Cursors.WaitCursor
            Try
                query = String.Format("UPDATE tb_m_sample_price SET is_buy_price='2' WHERE id_sample='{1}'; UPDATE tb_m_sample_price SET is_buy_price='1' WHERE id_sample_price = '{0}'", id_sample_price, id_sample)
                execute_non_query(query, True, "", "", "", "")
                view_sample_price(id_sample)
                infoCustom("Default FOB Price changed.")
            Catch ex As Exception
                DevExpress.XtraEditors.XtraMessageBox.Show("Please check your connection.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
            Cursor = Cursors.Default
        End If
    End Sub
End Class