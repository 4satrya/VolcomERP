Imports Microsoft.Office.Interop
Public Class FormProductionRetInSingle
    Public action As String
    Public id_prod_order_ret_in As String = "0"
    Public id_prod_order As String = "-1"
    Public id_comp_contact_to As String
    Public id_comp_contact_from As String
    Public id_prod_order_det_list, id_prod_order_ret_in_det_list As New List(Of String)
    Dim date_start As Date
    Public id_report_status As String
    Public cond_check As Boolean = True
    Public sample_check As String
    Public qty_pl As Decimal
    Public allow_sum As Decimal
    Public id_design As String = "-1"
    Public bof_column As String = get_setup_field("bof_column")
    Public bof_xls As String = get_setup_field("bof_xls_retin")


    Private Sub FormProductionRetOutSingle_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        viewReportStatus() 'get report status
        actionLoad()
    End Sub

    Private Sub FormProductionRetOutSingle_FormClosed(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Sub actionLoad()
        If action = "ins" Then
            TxtRetOutNumber.Text = ""
            BtnPrint.Enabled = False
            BMark.Enabled = False
            BtnAttachment.Enabled = False
            DERet.Text = view_date(0)

            'own source
            Dim id_qc As String = execute_query("SELECT id_qc_dept FROM tb_opt", 0, True, "", "", "", "")
            Dim query_get_comp_name As String = "SELECT b.comp_name, b.comp_number FROM tb_m_comp_contact a "
            query_get_comp_name += "INNER JOIN tb_m_comp b ON a.id_comp = b.id_comp "
            query_get_comp_name += "WHERE a.id_comp_contact = '" + id_qc + "' AND b.id_departement = '" + id_departement_user + "'"
            Try
                Dim data_comp_to As DataTable = execute_query(query_get_comp_name, -1, True, "", "", "", "")
                TxtNameCompTo.Text = data_comp_to(0)("comp_name").ToString
                TxtCodeCompTo.Text = data_comp_to(0)("comp_number").ToString
                id_comp_contact_to = id_qc
            Catch ex As Exception
                TxtNameCompTo.Text = ""
                TxtCodeCompTo.Text = ""
                id_comp_contact_to = "-1"
            End Try
        ElseIf action = "upd" Then
            'Enable/Disable
            BMark.Enabled = True
            BtnBrowsePO.Enabled = False
            GroupControlRet.Enabled = True
            GroupControlListBarcode.Enabled = True
            BtnInfoSrs.Enabled = True

            'View data
            Try
                Dim query As String = "SELECT (h.design_display_name) AS `design_name`, h.id_sample, DATE_FORMAT(a.prod_order_ret_in_date,'%Y-%m-%d') as prod_order_ret_in_datex, a.id_report_status, a.id_prod_order, a.id_prod_order_ret_in, a.prod_order_ret_in_date, "
                query += "g.id_design,a.prod_order_ret_in_note, a.prod_order_ret_in_number,  "
                query += "b.prod_order_number, (c.id_comp_contact) AS id_comp_contact_from, (d.comp_name) AS comp_name_contact_from, (d.comp_number) AS comp_code_contact_from, (d.address_primary) AS comp_address_contact_from, "
                query += "(e.id_comp_contact) AS id_comp_contact_to, (f.comp_name) AS comp_name_contact_to, (f.comp_number) AS comp_code_contact_to,(f.address_primary) AS comp_address_contact_to, ss.season "
                query += "FROM tb_prod_order_ret_in a "
                query += "INNER JOIN tb_prod_order b ON a.id_prod_order = b.id_prod_order "
                query += "INNER JOIN tb_season_delivery del ON del.id_delivery = b.id_delivery "
                query += "INNER JOIN tb_season ss ON ss.id_season = del.id_season "
                query += "INNER JOIN tb_m_comp_contact c ON a.id_comp_contact_from = c.id_comp_contact "
                query += "INNER JOIN tb_m_comp d ON d.id_comp = c.id_comp "
                query += "INNER JOIN tb_m_comp_contact e ON a.id_comp_contact_to = e.id_comp_contact "
                query += "INNER JOIN tb_m_comp f ON e.id_comp = f.id_comp "
                query += "INNER JOIN tb_prod_demand_design g ON g.id_prod_demand_design = b.id_prod_demand_design "
                query += "INNER JOIN tb_m_design h ON g.id_design = h.id_design "
                query += "WHERE a.id_prod_order_ret_in='" + id_prod_order_ret_in + "' "
                Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
                TxtOrderNumber.Text = data.Rows(0)("prod_order_number").ToString
                id_comp_contact_from = data.Rows(0)("id_comp_contact_from").ToString
                TxtCodeCompFrom.Text = data.Rows(0)("comp_code_contact_from").ToString
                TxtNameCompFrom.Text = data.Rows(0)("comp_name_contact_from").ToString
                id_comp_contact_to = data.Rows(0)("id_comp_contact_to").ToString
                TxtCodeCompTo.Text = data.Rows(0)("comp_code_contact_to").ToString
                TxtNameCompTo.Text = data.Rows(0)("comp_name_contact_to").ToString
                MEAdrressCompTo.Text = data.Rows(0)("comp_address_contact_to").ToString
                'Dim start_date_arr() As String = data.Rows(0)("prod_order_ret_in_date").ToString.Split(" ")
                DERet.Text = view_date_from(data.Rows(0)("prod_order_ret_in_datex").ToString, 0)
                TxtRetOutNumber.Text = data.Rows(0)("prod_order_ret_in_number").ToString
                MENote.Text = data.Rows(0)("prod_order_ret_in_note").ToString
                LEReportStatus.ItemIndex = LEReportStatus.Properties.GetDataSourceRowIndex("id_report_status", data.Rows(0)("id_report_status").ToString)
                id_report_status = data.Rows(0)("id_report_status").ToString
                id_prod_order = data.Rows(0)("id_prod_order").ToString
                id_design = data.Rows(0)("id_design").ToString
                pre_viewImages("2", PEView, id_design, False)
                TEDesign.Text = data.Rows(0)("design_name").ToString
                TxtSeason.Text = data.Rows(0)("season").ToString
                PEView.Enabled = True
            Catch ex As Exception
                errorConnection()
            End Try
            view_barcode_list()
            viewDetailReturn()
            check_but()
            allow_status()
        End If
    End Sub
    Sub allow_status()
        If check_edit_report_status(id_report_status, "32", id_prod_order_ret_in) Then
            BtnBrowseContactFrom.Enabled = True
            BtnBrowseContactTo.Enabled = True
            GVRetDetail.OptionsBehavior.Editable = True
            BtnAdd.Enabled = True
            BtnEdit.Enabled = True
            BtnDel.Enabled = True
            MENote.Properties.ReadOnly = False
            BtnSave.Enabled = True
            BScan.Enabled = True
            BDelete.Enabled = True
            BtnInfoSrs.Enabled = True
        Else
            BtnBrowseContactFrom.Enabled = False
            BtnBrowseContactTo.Enabled = False
            GVRetDetail.OptionsBehavior.Editable = False
            BtnAdd.Enabled = False
            BtnEdit.Enabled = False
            BtnDel.Enabled = False
            MENote.Properties.ReadOnly = True
            DERet.Properties.ReadOnly = True
            BtnSave.Enabled = False
            BScan.Enabled = False
            BDelete.Enabled = False
            BtnInfoSrs.Enabled = False
        End If

        'attachment
        If check_attach_report_status(id_report_status, "32", id_prod_order_ret_in) Then
            BtnAttachment.Enabled = True
        Else
            BtnAttachment.Enabled = False
        End If

        If check_print_report_status(id_report_status) Then
            BtnPrint.Enabled = True
        Else
            BtnPrint.Enabled = False
        End If

        'bof column
        If bof_column = "1" And LEReportStatus.EditValue.ToString <> "5" Then
            BtnXlsBOF.Visible = True
        Else
            BtnXlsBOF.Visible = False
        End If

        TxtRetOutNumber.Focus()
    End Sub

    Sub mainVendor()
        'main vendor
        Dim data_vend As DataTable = getMainVendor(id_prod_order)
        Try
            id_comp_contact_from = data_vend.Rows(0)("id_comp_contact").ToString
            TxtCodeCompFrom.Text = data_vend.Rows(0)("comp_number").ToString
            TxtNameCompFrom.Text = data_vend.Rows(0)("comp_name").ToString
        Catch ex As Exception
            id_comp_contact_from = "-1"
            TxtCodeCompFrom.Text = ""
            TxtNameCompFrom.Text = ""
        End Try
    End Sub


    'sub check_but
    Sub check_but()
        'Constraint Status
        If GVRetDetail.RowCount > 0 Then
            BtnEdit.Visible = True
            BtnDel.Visible = True
        Else
            BtnEdit.Visible = False
            BtnDel.Visible = False
        End If
    End Sub
    'View Data
    Sub viewReportStatus()
        Dim query As String = "SELECT * FROM tb_lookup_report_status a ORDER BY a.id_report_status "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        viewLookupQuery(LEReportStatus, query, 0, "report_status", "id_report_status")
    End Sub

    Sub view_barcode_list()
        Dim query As String = "SELECT ('0') AS no, ('') AS ean_code, ('0') AS id_prod_order_det, ('1') AS is_fix "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCBarcode.DataSource = data
        deleteRowsBc()
    End Sub

    Sub viewDetailReturn()
        If action = "ins" Then
            Dim query As String = "CALL view_stock_prod_ret_in_remain('" + id_prod_order + "', '0', '0', '0', '0')"
            Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
            For i As Integer = 0 To (data.Rows.Count - 1)
                id_prod_order_det_list.Add(data.Rows(i)("id_prod_order_det").ToString)
            Next
            GCRetDetail.DataSource = data
        ElseIf action = "upd" Then
            Dim query As String = "CALL view_return_in_prod('" + id_prod_order_ret_in + "', '0')"
            Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
            For i As Integer = 0 To (data.Rows.Count - 1)
                id_prod_order_det_list.Add(data.Rows(i)("id_prod_order_det").ToString)
                id_prod_order_ret_in_det_list.Add(data.Rows(i)("id_prod_order_ret_in_det").ToString)
                For j As Integer = 0 To data.Rows(i)("prod_order_ret_in_det_qty") - 1
                    GVBarcode.AddNewRow()
                    GVBarcode.SetFocusedRowCellValue("ean_code", data.Rows(i)("ean_code"))
                    GVBarcode.SetFocusedRowCellValue("id_prod_order_det", data.Rows(i)("id_prod_order_det"))
                    GVBarcode.SetFocusedRowCellValue("is_fix", "2")
                Next
            Next
            GCRetDetail.DataSource = data
            GCBarcode.RefreshDataSource()
            GVBarcode.RefreshData()
        End If
        check_but()
    End Sub
    'Button
    Private Sub BtnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSave.Click
        Cursor = Cursors.WaitCursor
        ValidateChildren()

        'Cek isi qty
        Dim cond_qty As Boolean = True
        'Dim qty As Decimal
        'For i As Integer = 0 To (GVRetDetail.RowCount - 1)
        '    qty = GVRetDetail.GetRowCellValue(i, "prod_order_ret_in_det_qty")
        '    If qty = 0.0 Then
        '        cond_qty = False
        '    End If
        'Next

        'cek dengan requisition di DB
        For i As Integer = 0 To GVRetDetail.RowCount - 1
            Dim id_prod_order_det_cekya As String = GVRetDetail.GetRowCellValue(i, "id_prod_order_det").ToString
            Dim qty_plya As String = GVRetDetail.GetRowCellValue(i, "prod_order_ret_in_det_qty").ToString
            Dim sample_checkya As String = GVRetDetail.GetRowCellValue(i, "name").ToString + " / Size : " + GVRetDetail.GetRowCellValue(i, "size").ToString
            isAllowRequisition(sample_checkya, id_prod_order_det_cekya, qty_plya)
            If Not cond_check Then
                Exit For
            End If
        Next

        If Not formIsValidInGroup(EPRet, GroupGeneralHeader) Then
            errorInput()
        ElseIf Not cond_qty Or GVRetDetail.RowCount = 0 Then
            errorCustom("Qty can't blank or zero value !")
        ElseIf Not cond_check Then
            errorCustom("- Product : '" + sample_check + "' cannot exceed " + allow_sum.ToString("F2") + ", please check in Info Qty !" + System.Environment.NewLine + "- Use 'receiving QC module' for new item product. ")
            infoQty()
        Else
            Dim query As String
            Dim prod_order_ret_in_number As String = ""
            'addSlashes(TxtRetOutNumber.Text)
            Dim prod_order_ret_in_note As String = addSlashes(MENote.Text)
            Dim id_report_status As String = LEReportStatus.EditValue
            Dim id_prod_order_det, prod_order_ret_in_det_qty, prod_order_ret_in_det_note As String
            Dim id_prod_order_ret_in_det As String
            If action = "ins" Then
                Dim confirm As DialogResult = DevExpress.XtraEditors.XtraMessageBox.Show("Are you sure to continue this process?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
                If confirm = Windows.Forms.DialogResult.Yes Then
                    Cursor = Cursors.WaitCursor
                    Try
                        prod_order_ret_in_number = header_number_prod("5")

                        'Main tbale
                        query = "INSERT INTO tb_prod_order_ret_in(id_prod_order, prod_order_ret_in_number, id_comp_contact_to, id_comp_contact_from, prod_order_ret_in_date, prod_order_ret_in_note, id_report_status) "
                        query += "VALUES('" + id_prod_order + "', '" + prod_order_ret_in_number + "', '" + id_comp_contact_to + "', '" + id_comp_contact_from + "', NOW(), '" + prod_order_ret_in_note + "', '" + id_report_status + "'); SELECT LAST_INSERT_ID(); "
                        id_prod_order_ret_in = execute_query(query, 0, True, "", "", "", "")
                        increase_inc_prod("5")

                        'insert who prepared
                        insert_who_prepared("32", id_prod_order_ret_in, id_user)

                        'Detail return
                        For j As Integer = 0 To (GVRetDetail.RowCount - 1)
                            Try
                                id_prod_order_det = GVRetDetail.GetRowCellValue(j, "id_prod_order_det").ToString
                                prod_order_ret_in_det_qty = decimalSQL(GVRetDetail.GetRowCellValue(j, "prod_order_ret_in_det_qty").ToString)
                                prod_order_ret_in_det_note = GVRetDetail.GetRowCellValue(j, "prod_order_ret_in_det_note").ToString
                                query = "INSERT tb_prod_order_ret_in_det(id_prod_order_ret_in, id_prod_order_det, prod_order_ret_in_det_qty, prod_order_ret_in_det_note) "
                                query += "VALUES('" + id_prod_order_ret_in + "', '" + id_prod_order_det + "', '" + prod_order_ret_in_det_qty + "', '" + prod_order_ret_in_det_note + "') "
                                execute_non_query(query, True, "", "", "", "")
                            Catch ex As Exception
                                'MsgBox(ex.ToString)
                            End Try
                        Next
                        FormProductionRet.viewRetIn()
                        FormProductionRet.GVRetIn.FocusedRowHandle = find_row(FormProductionRet.GVRetIn, "id_prod_order_ret_in", id_prod_order_ret_in)
                        action = "upd"
                        actionLoad()

                        'gen xls
                        exportToBOF(False)

                        infoCustom("Document #" + prod_order_ret_in_number + " was created successfully.")
                    Catch ex As Exception
                        errorConnection()
                    End Try
                    Cursor = Cursors.Default
                End If
            ElseIf action = "upd" Then
                Dim confirm As DialogResult = DevExpress.XtraEditors.XtraMessageBox.Show("Are you sure to continue this process?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
                If confirm = Windows.Forms.DialogResult.Yes Then
                    Cursor = Cursors.WaitCursor
                    Try
                        prod_order_ret_in_number = TxtRetOutNumber.Text

                        'edit main table
                        query = "UPDATE tb_prod_order_ret_in SET id_prod_order = '" + id_prod_order + "', prod_order_ret_in_number = '" + prod_order_ret_in_number + "', id_comp_contact_to = '" + id_comp_contact_to + "', id_comp_contact_from = '" + id_comp_contact_from + "', id_report_status = '" + id_report_status + "', prod_order_ret_in_note = '" + prod_order_ret_in_note + "' WHERE id_prod_order_ret_in = '" + id_prod_order_ret_in + "' "
                        execute_non_query(query, True, "", "", "", "")

                        'edit detail table
                        For j As Integer = 0 To (GVRetDetail.RowCount - 1)
                            Try
                                id_prod_order_ret_in_det = GVRetDetail.GetRowCellValue(j, "id_prod_order_ret_in_det").ToString
                                id_prod_order_det = GVRetDetail.GetRowCellValue(j, "id_prod_order_det").ToString
                                prod_order_ret_in_det_qty = decimalSQL(GVRetDetail.GetRowCellValue(j, "prod_order_ret_in_det_qty").ToString)
                                prod_order_ret_in_det_note = GVRetDetail.GetRowCellValue(j, "prod_order_ret_in_det_note").ToString
                                If id_prod_order_ret_in_det = "0" Then
                                    query = "INSERT tb_prod_order_ret_in_det(id_prod_order_ret_in, id_prod_order_det, prod_order_ret_in_det_qty, prod_order_ret_in_det_note) "
                                    query += "VALUES('" + id_prod_order_ret_in + "', '" + id_prod_order_det + "', '" + prod_order_ret_in_det_qty + "', '" + prod_order_ret_in_det_note + "') "
                                    execute_non_query(query, True, "", "", "", "")
                                Else
                                    query = "UPDATE tb_prod_order_ret_in_det SET id_prod_order_det = '" + id_prod_order_det + "', prod_order_ret_in_det_qty = '" + prod_order_ret_in_det_qty + "', prod_order_ret_in_det_note = '" + prod_order_ret_in_det_note + "' WHERE id_prod_order_ret_in_det = '" + id_prod_order_ret_in_det + "'"
                                    execute_non_query(query, True, "", "", "", "")
                                    id_prod_order_ret_in_det_list.Remove(id_prod_order_ret_in_det)
                                End If
                            Catch ex As Exception
                                ex.ToString()
                            End Try
                        Next

                        'delete sisa
                        For k As Integer = 0 To (id_prod_order_ret_in_det_list.Count - 1)
                            Try
                                query = "DELETE FROM tb_prod_order_ret_in_det WHERE id_prod_order_ret_in_det = '" + id_prod_order_ret_in_det_list(k) + "' "
                                execute_non_query(query, True, "", "", "", "")
                            Catch ex As Exception
                                ex.ToString()
                            End Try
                        Next

                        'View
                        FormProductionRet.viewRetIn()
                        FormProductionRet.GVRetIn.FocusedRowHandle = find_row(FormProductionRet.GVRetIn, "id_prod_order_ret_in", id_prod_order_ret_in)
                        action = "upd"
                        actionLoad()

                        'gen xls
                        exportToBOF(False)

                        infoCustom("Document #" + prod_order_ret_in_number + " was edited successfully.")
                    Catch ex As Exception
                        errorConnection()
                    End Try
                    Cursor = Cursors.Default
                End If
            End If
        End If
        Cursor = Cursors.Default
    End Sub
    Private Sub BtnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCancel.Click
        Close()
    End Sub
    Private Sub BtnBrowsePO_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnBrowsePO.Click
        FormPopUpProd.id_pop_up = "3"
        FormPopUpProd.ShowDialog()
    End Sub
    Private Sub BtnBrowseContactFrom_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnBrowseContactFrom.Click
        FormPopUpContact.id_pop_up = "33"
        FormPopUpContact.ShowDialog()
    End Sub
    Private Sub BtnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnAdd.Click
        FormPopUpProdDet.id_pop_up = "2"
        FormPopUpProdDet.action = "ins"
        FormPopUpProdDet.id_prod_order = id_prod_order
        FormPopUpProdDet.id_ret_in = id_prod_order_ret_in
        FormPopUpProdDet.ShowDialog()
    End Sub
    Private Sub BtnDel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnDel.Click
        If (MessageBox.Show("Are you sure to delete this row?", "Delete Confirmation", MessageBoxButtons.YesNo) <> DialogResult.Yes) Then Return
        Dim id_prod_order_det As String = GVRetDetail.GetFocusedRowCellDisplayText("id_prod_order_det").ToString
        id_prod_order_det_list.Remove(id_prod_order_det)
        deleteRows()
        deleteDetailBc(id_prod_order_det)
    End Sub

    Sub deleteDetailBc(ByVal id_prod_order_det As String)
        'delete detail
        Dim i As Integer = GVBarcode.RowCount - 1
        While (i >= 0)
            Dim id_prod_order_detx As String = ""
            Try
                id_prod_order_detx = GVBarcode.GetRowCellValue(i, "id_prod_order_det").ToString()
            Catch ex As Exception

            End Try
            If id_prod_order_det = id_prod_order_detx Then
                GVBarcode.DeleteRow(i)
            End If
            i = i - 1
        End While
    End Sub
    Private Sub BtnEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnEdit.Click
        FormPopUpProdDet.id_pop_up = "2"
        FormPopUpProdDet.action = "upd"
        FormPopUpProdDet.id_prod_order = id_prod_order
        FormPopUpProdDet.id_ret_in = id_prod_order_ret_in
        FormPopUpProdDet.ShowDialog()
    End Sub
    Private Sub BtnPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnPrint.Click
        Cursor = Cursors.WaitCursor
        GVRetDetail.BestFitColumns()
        ReportProductionRetIn.dt = GCRetDetail.DataSource
        ReportProductionRetIn.id_prod_order_ret_in = id_prod_order_ret_in
        Dim Report As New ReportProductionRetIn()

        ' '... 
        ' ' creating and saving the view's layout to a new memory stream 
        Dim str As System.IO.Stream
        str = New System.IO.MemoryStream()
        GVRetDetail.SaveLayoutToStream(str, DevExpress.Utils.OptionsLayoutBase.FullLayout)
        str.Seek(0, System.IO.SeekOrigin.Begin)
        Report.GVRetDetail.RestoreLayoutFromStream(str, DevExpress.Utils.OptionsLayoutBase.FullLayout)
        str.Seek(0, System.IO.SeekOrigin.Begin)

        'Grid Detail
        ReportStyleGridview(Report.GVRetDetail)

        'Parse val
        Report.LabelPO.Text = TxtOrderNumber.Text
        Report.LabelNo.Text = TxtRetOutNumber.Text
        Report.LabelFrom.Text = TxtCodeCompFrom.Text + "-" + TxtNameCompFrom.Text
        Report.LabelTo.Text = TxtCodeCompTo.Text + "-" + TxtNameCompTo.Text
        Report.LabelDate.Text = DERet.Text
        Report.LabelDel.Visible = False
        Report.LabelRangex.Visible = False
        Report.LabelNote.Text = MENote.Text
        Report.LabelDesign.Text = TEDesign.Text
        Report.LabelSeason.Text = TxtSeason.Text

        'Show the report's preview. 
        Dim Tool As DevExpress.XtraReports.UI.ReportPrintTool = New DevExpress.XtraReports.UI.ReportPrintTool(Report)
        Tool.ShowPreview()
        Cursor = Cursors.Default
    End Sub
    'Validating
    Private Sub TxtOrderNumber_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TxtOrderNumber.Validating
        EP_TE_cant_blank(EPRet, TxtOrderNumber)
        EPRet.SetIconPadding(TxtOrderNumber, 56)
    End Sub
    Private Sub TxtNameCompFrom_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TxtNameCompFrom.Validating
        EP_TE_cant_blank(EPRet, TxtNameCompFrom)
        EPRet.SetIconPadding(TxtNameCompFrom, 30)
    End Sub
    Private Sub TxtNameCompTo_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TxtNameCompTo.Validating
        EP_TE_cant_blank(EPRet, TxtNameCompTo)
        EPRet.SetIconPadding(TxtNameCompTo, 30)
    End Sub
    'Row Manipulation
    Sub focusColumnCode()
        GVRetDetail.FocusedColumn = GVRetDetail.VisibleColumns(0)
        GVRetDetail.ShowEditor()
    End Sub
    Sub newRows()
        GVRetDetail.AddNewRow()
    End Sub
    Sub deleteRows()
        GVRetDetail.DeleteRow(GVRetDetail.FocusedRowHandle)
    End Sub

    Private Sub BMark_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BMark.Click
        FormReportMark.id_report = id_prod_order_ret_in
        FormReportMark.report_mark_type = "32"
        FormReportMark.form_origin = Name
        FormReportMark.ShowDialog()
    End Sub

    Private Sub BtnBrowseContactTo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnBrowseContactTo.Click
        FormPopUpContact.id_pop_up = "34"
        FormPopUpContact.id_departement = id_departement_user
        FormPopUpContact.ShowDialog()
    End Sub

    'DeleteRows
    Sub deleteRowsBc()
        GVBarcode.DeleteRow(GVBarcode.FocusedRowHandle)
    End Sub

    'Focus Column Code
    Sub focusColumnCodeBc()
        GVBarcode.FocusedColumn = GVBarcode.VisibleColumns(0)
        GVBarcode.ShowEditor()
    End Sub
    'New Row
    Sub newRowsBc()
        GVBarcode.AddNewRow()
        GCBarcode.RefreshDataSource()
        GVBarcode.RefreshData()
        GVBarcode.FocusedRowHandle = GVBarcode.RowCount - 1
    End Sub

    Private Sub BScan_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BScan.Click
        MENote.Enabled = False
        BtnBrowsePO.Enabled = False
        BtnBrowseContactFrom.Enabled = False
        BtnBrowseContactTo.Enabled = False
        BtnSave.Enabled = False
        BScan.Enabled = False
        BStop.Enabled = True
        BDelete.Enabled = False
        BtnCancel.Enabled = False
        GVRetDetail.OptionsBehavior.Editable = False
        ControlBox = False
        BtnAdd.Enabled = False
        BtnEdit.Enabled = False
        BtnDel.Enabled = False
        BtnInfoSrs.Enabled = False
        newRowsBc()
        'allowDelete()
    End Sub

    Private Sub BStop_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BStop.Click
        MENote.Enabled = True
        BtnBrowsePO.Enabled = True
        BtnBrowseContactFrom.Enabled = True
        BtnBrowseContactTo.Enabled = True
        BtnSave.Enabled = True
        BScan.Enabled = True
        BStop.Enabled = False
        BtnCancel.Enabled = True
        allowDelete()
        GVRetDetail.OptionsBehavior.Editable = True
        ControlBox = True
        BtnAdd.Enabled = True
        BtnEdit.Enabled = True
        BtnDel.Enabled = True
        BtnInfoSrs.Enabled = True
        For i As Integer = 0 To (GVBarcode.RowCount - 1)
            Dim check_code As String = ""
            Try
                check_code = GVBarcode.GetRowCellValue(i, "ean_code").ToString()
            Catch ex As Exception

            End Try
            If check_code = "" Or check_code = Nothing Or IsDBNull(check_code) Then
                GVBarcode.DeleteRow(i)
            End If
        Next
    End Sub

    Private Sub BDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BDelete.Click
        Dim confirm As DialogResult = DevExpress.XtraEditors.XtraMessageBox.Show("Are you sure want to delete this data?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
        If confirm = Windows.Forms.DialogResult.Yes Then
            Dim id_prod_order_det As String = GVBarcode.GetFocusedRowCellValue("id_prod_order_det").ToString
            deleteRowsBc()
            If id_prod_order_det <> "" Or id_prod_order_det <> Nothing Then
                GVBarcode.ApplyFindFilter("")
                countQty(id_prod_order_det)
            End If
            'allowDelete()
        End If
    End Sub

    Private Sub GVBarcode_HiddenEditor(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GVBarcode.HiddenEditor
        '' MsgBox(GVBarcode.GetFocusedRowCellValue("ean_code").ToString)
        Dim code_check As String = GVBarcode.GetFocusedRowCellValue("ean_code").ToString
        Dim code_found As Boolean = False
        Dim id_prod_order_det As String = ""
        For i As Integer = 0 To (GVRetDetail.RowCount - 1)
            Dim code As String = GVRetDetail.GetRowCellValue(i, "ean_code").ToString
            id_prod_order_det = GVRetDetail.GetRowCellValue(i, "id_prod_order_det").ToString
            If code = code_check Then
                code_found = True
                Exit For
            End If
        Next
        If Not code_found Then
            GVBarcode.SetFocusedRowCellValue("ean_code", "")
            stopCustom("Data not found !")
        Else
            GVBarcode.SetFocusedRowCellValue("is_fix", "2")
            GVBarcode.SetFocusedRowCellValue("id_prod_order_det", id_prod_order_det)
            countQty(id_prod_order_det)
            newRowsBc()
            'allowDelete()
        End If
    End Sub

    Private Sub GVBarcode_CellValueChanged(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles GVBarcode.CellValueChanged
        'MsgBox(GVBarcode.GetFocusedRowCellValue("ean_code").ToString)
        'GVBarcode.AddNewRow()
        'MsgBox("k")
    End Sub

    Private Sub GVBarcode_FocusedColumnChanged(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.FocusedColumnChangedEventArgs) Handles GVBarcode.FocusedColumnChanged
        If Not GVBarcode.FocusedColumn.FieldName = "ean_code" Then
            GVBarcode.FocusedColumn = GVBarcode.Columns("ean_code")
        End If
    End Sub

    Private Sub GVBarcode_CustomColumnDisplayText(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs) Handles GVBarcode.CustomColumnDisplayText
        If e.Column.FieldName = "no" Then
            e.DisplayText = (e.ListSourceRowIndex + 1).ToString()
        End If
    End Sub

    Sub allowDelete()
        If GVBarcode.RowCount <= 0 Then
            BDelete.Enabled = False
        Else
            BDelete.Enabled = True
        End If
    End Sub

    Sub noEdit()
        Try
            Dim is_fix As String = GVBarcode.GetFocusedRowCellDisplayText("is_fix")
            'MsgBox(id_prod_order_rec_det)
            If is_fix <> "2" Then
                GridColumnBarcode.OptionsColumn.AllowEdit = True
            Else
                GridColumnBarcode.OptionsColumn.AllowEdit = False
            End If
            'MsgBox(id_prod_order_rec_det)
        Catch ex As Exception
            'errorCustom(ex.ToString)
        End Try
    End Sub

    Private Sub GVBarcode_FocusedRowChanged(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles GVBarcode.FocusedRowChanged
        noEdit()
    End Sub

    Sub countQty(ByVal id_prod_order_detx As String)
        Dim tot As Decimal = 0.0
        For i As Integer = 0 To GVBarcode.RowCount - 1
            Dim id_prod_order_det As String = GVBarcode.GetRowCellValue(i, "id_prod_order_det").ToString
            If id_prod_order_det = id_prod_order_detx Then
                tot = tot + 1.0
            End If
        Next
        GVRetDetail.FocusedRowHandle = find_row(GVRetDetail, "id_prod_order_det", id_prod_order_detx)
        GVRetDetail.SetFocusedRowCellValue("prod_order_ret_in_det_qty", tot)
        GCRetDetail.RefreshDataSource()
        GVRetDetail.RefreshData()
    End Sub

    Private Sub GVRetDetail_CustomColumnDisplayText(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs) Handles GVRetDetail.CustomColumnDisplayText
        If e.Column.FieldName = "no" Then
            e.DisplayText = (e.ListSourceRowIndex + 1).ToString()
        End If
    End Sub

    Private Sub BtnInfoSrs_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnInfoSrs.Click
        infoQty()
    End Sub

    Sub isAllowRequisition(ByVal sample_name As String, ByVal id_prod_order_det_cek As String, ByVal qty_plx As String)
        cond_check = True
        qty_pl = Decimal.Parse(qty_plx.ToString)
        sample_check = sample_name
        'MsgBox(id_prod_order_det_cek)
        Dim query_check As String = "CALL view_stock_prod_ret_in_remain('" + id_prod_order + "', '" + id_prod_order_det_cek + "', '0', '" + id_prod_order_ret_in + "', '0') "
        Dim data As DataTable = execute_query(query_check, -1, True, "", "", "", "")
        allow_sum = Decimal.Parse(data.Rows(0)("qty"))
        If qty_pl > allow_sum Then
            cond_check = False
        End If
    End Sub

    Sub infoQty()
        FormPopUpProdDet.id_pop_up = "2"
        FormPopUpProdDet.action = "ins"
        FormPopUpProdDet.id_prod_order = id_prod_order
        FormPopUpProdDet.id_ret_in = id_prod_order_ret_in
        FormPopUpProdDet.BtnSave.Visible = False
        FormPopUpProdDet.is_info_form = True
        FormPopUpProdDet.ShowDialog()
    End Sub

    Private Sub PEView_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PEView.DoubleClick
        pre_viewImages("2", PEView, id_design, True)
    End Sub

    Private Sub BtnAttachment_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnAttachment.Click
        Cursor = Cursors.WaitCursor
        FormDocumentUpload.id_report = id_prod_order_ret_in
        FormDocumentUpload.report_mark_type = "32"
        FormDocumentUpload.ShowDialog()
        Cursor = Cursors.Default
    End Sub

    Private Sub BtnXlsBOF_Click(sender As Object, e As EventArgs) Handles BtnXlsBOF.Click
        exportToBOF(True)
    End Sub

    Sub exportToBOF(ByVal show_msg As Boolean)
        If bof_column = "1" Then
            Cursor = Cursors.WaitCursor

            'hide column
            For c As Integer = 0 To GVRetDetail.Columns.Count - 1
                GVRetDetail.Columns(c).Visible = False
            Next
            GridColumnCode.VisibleIndex = 0
            GridColumnQty.VisibleIndex = 1
            GridColumnNumber.VisibleIndex = 2
            GridColumnFrom.VisibleIndex = 3
            GridColumnTo.VisibleIndex = 4
            GridColumnRemark.VisibleIndex = 5
            GVRetDetail.OptionsPrint.PrintFooter = False
            GVRetDetail.OptionsPrint.PrintHeader = False


            'export excel
            Dim path_root As String = ""
            Try
                ' Open the file using a stream reader.
                Using sr As New IO.StreamReader(Application.StartupPath & "\pro_path.txt")
                    ' Read the stream to a string and write the string to the console.
                    path_root = sr.ReadToEnd()
                End Using
            Catch ex As Exception
            End Try

            Dim fileName As String = bof_xls + ".xls"
            Dim exp As String = IO.Path.Combine(path_root, fileName)
            Try
                ExportToExcel(GVRetDetail, exp, show_msg)
            Catch ex As Exception
                stopCustom("Please close your excel file first then try again later")
            End Try

            'show column
            GridColumnNox.VisibleIndex = 0
            GridColumnCode.VisibleIndex = 1
            GridColumnEanCode.VisibleIndex = 2
            GridColumnName.VisibleIndex = 3
            GridColumnSize.VisibleIndex = 4
            GridColumnQty.VisibleIndex = 5
            GridColumnRemark.VisibleIndex = 6
            GridColumnNumber.Visible = False
            GridColumnFrom.Visible = False
            GridColumnTo.Visible = False
            GVRetDetail.OptionsPrint.PrintFooter = True
            GVRetDetail.OptionsPrint.PrintHeader = True
            Cursor = Cursors.Default
        End If
    End Sub

    Private Sub ExportToExcel(ByVal dtTemp As DevExpress.XtraGrid.Views.Grid.GridView, ByVal filepath As String, show_msg As Boolean)
        Dim strFileName As String = filepath
        If System.IO.File.Exists(strFileName) Then
            System.IO.File.Delete(strFileName)
        End If
        Dim _excel As New Excel.Application
        Dim wBook As Excel.Workbook
        Dim wSheet As Excel.Worksheet

        wBook = _excel.Workbooks.Add()
        wSheet = wBook.ActiveSheet()


        Dim colIndex As Integer = 0
        Dim rowIndex As Integer = -1

        ' export the Columns 
        'If CheckBox1.Checked Then
        '    For Each dc In dt.Columns
        '        colIndex = colIndex + 1
        '        wSheet.Cells(1, colIndex) = dc.ColumnName
        '    Next
        'End If

        'export the rows 
        For i As Integer = 0 To dtTemp.RowCount - 1
            rowIndex = rowIndex + 1
            colIndex = 0
            For j As Integer = 0 To dtTemp.VisibleColumns.Count - 1
                colIndex = colIndex + 1
                If j = 0 Then 'code
                    wSheet.Cells(rowIndex + 1, colIndex) = dtTemp.GetRowCellValue(i, "code").ToString
                ElseIf j = 1 Then 'qty
                    wSheet.Cells(rowIndex + 1, colIndex) = dtTemp.GetRowCellValue(i, "prod_order_ret_in_det_qty")
                ElseIf j = 2 Then 'number
                    wSheet.Cells(rowIndex + 1, colIndex) = dtTemp.GetRowCellDisplayText(i, "number").ToString
                ElseIf j = 3 Then 'from
                    wSheet.Cells(rowIndex + 1, colIndex) = dtTemp.GetRowCellDisplayText(i, "from").ToString
                ElseIf j = 4 Then 'to
                    wSheet.Cells(rowIndex + 1, colIndex) = dtTemp.GetRowCellDisplayText(i, "to").ToString
                Else
                    wSheet.Cells(rowIndex + 1, colIndex) = dtTemp.GetRowCellValue(i, "prod_order_ret_in_det_note").ToString
                End If
            Next
        Next

        wSheet.Columns.AutoFit()
        wBook.SaveAs(strFileName, Excel.XlFileFormat.xlExcel5)

        'release the objects
        ReleaseObject(wSheet)
        wBook.Close(False)
        ReleaseObject(wBook)
        _excel.Quit()
        ReleaseObject(_excel)
        ' some time Office application does not quit after automation: so i am calling GC.Collect method.
        GC.Collect()

        If show_msg Then
            infoCustom("File exported successfully")
        End If
    End Sub

    Private Sub GVRetDetail_CustomUnboundColumnData(sender As Object, e As DevExpress.XtraGrid.Views.Base.CustomColumnDataEventArgs) Handles GVRetDetail.CustomUnboundColumnData
        Dim view As DevExpress.XtraGrid.Views.Grid.GridView = TryCast(sender, DevExpress.XtraGrid.Views.Grid.GridView)
        If e.Column.FieldName = "from" AndAlso e.IsGetData Then
            e.Value = TxtCodeCompFrom.Text.ToString
        ElseIf e.Column.FieldName = "to" AndAlso e.IsGetData Then
            e.Value = TxtCodeCompTo.Text.ToString
        ElseIf e.Column.FieldName = "number" AndAlso e.IsGetData Then
            e.Value = TxtRetOutNumber.Text.ToString
        End If
    End Sub

    Private Sub ReleaseObject(ByVal o As Object)
        Try
            While (System.Runtime.InteropServices.Marshal.ReleaseComObject(o) > 0)
            End While
        Catch
        Finally
            o = Nothing
        End Try
    End Sub
End Class