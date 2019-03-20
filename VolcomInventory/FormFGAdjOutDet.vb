Public Class FormFGAdjOutDet 
    Public id_adj_out_fg As String
    Public action As String
    Public id_report_status As String
    Public total_amount As Double

    Private Sub FormFGAdjOutDet_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        viewReportStatus()
        viewCurrency()
        actionLoad()
    End Sub

    Sub actionLoad()
        If action = "ins" Then
            TxtAdjDate.Text = view_date(0)
            TxtAdjNumber.Text = header_number_sales("13")
            BMark.Enabled = False
            BtnPrint.Enabled = False
            viewDetailReturn()
            PCEdit.Visible = True
        ElseIf action = "upd" Then
            PCEdit.Visible = False
            BtnCancel.Text = "Close"
            GVDetail.OptionsBehavior.AutoExpandAllGroups = True

            'Fetch from db main
            Dim query As String = "SELECT *, DATE_FORMAT(a.adj_out_fg_date, '%Y-%m-%d') AS adj_out_fg_datex FROM tb_adj_out_fg a "
            query += "INNER JOIN tb_lookup_currency b ON a.id_currency = b.id_currency "
            query += "INNER JOIN tb_lookup_report_status c ON a.id_report_status = c.id_report_status "
            query += "WHERE a.id_adj_out_fg = '" + id_adj_out_fg + "' "
            Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")

            ''tampung ke form
            id_adj_out_fg = data.Rows(0)("id_adj_out_fg").ToString
            TxtAdjNumber.Text = data.Rows(0)("adj_out_fg_number").ToString
            TxtAdjDate.Text = view_date_from(data.Rows(0)("adj_out_fg_datex").ToString, 0)
            MENote.Text = data.Rows(0)("adj_out_fg_note").ToString
            LEReportStatus.ItemIndex = LEReportStatus.Properties.GetDataSourceRowIndex("id_report_status", data.Rows(0)("id_report_status").ToString)
            LECurrency.ItemIndex = LECurrency.Properties.GetDataSourceRowIndex("id_currency", data.Rows(0)("id_currency").ToString)

            'based on sttatus
            id_report_status = data.Rows(0)("id_report_status").ToString
            If check_edit_report_status(id_report_status, "42", id_adj_out_fg) Then
                BMark.Enabled = True
                BtnSave.Enabled = True
                BtnPrint.Enabled = False
                MENote.Properties.ReadOnly = False
            Else
                BMark.Enabled = True
                BtnSave.Enabled = False
                BtnPrint.Enabled = False
                MENote.Properties.ReadOnly = True
            End If

            If check_print_report_status(id_report_status) Then
                BtnPrint.Enabled = True
            Else
                BtnPrint.Enabled = False
            End If

            'Fetch db detail
            viewDetailReturn()

            'disable changing stock
            BtnAdd.Enabled = False
            BtnEdit.Enabled = False
            BtnDel.Enabled = False

            'get Total
            total_amount = Double.Parse(GVDetail.Columns("adj_out_fg_det_amount").SummaryItem.SummaryValue.ToString)
            METotSay.Text = ConvertCurrencyToEnglish(total_amount, LECurrency.EditValue.ToString)
        End If
        check_but()
    End Sub

    Sub check_but()
        If GVDetail.RowCount > 0 Then
            BtnDel.Visible = True
            BtnEdit.Visible = True
        Else
            BtnDel.Visible = False
            BtnEdit.Visible = False
        End If
    End Sub

    Sub viewReportStatus()
        'MsgBox("Aewww")
        Dim query As String = "SELECT * FROM tb_lookup_report_status a ORDER BY a.id_report_status "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        viewLookupQuery(LEReportStatus, query, 0, "report_status", "id_report_status")
    End Sub

    Sub viewCurrency()
        Dim id_currency_default As String = execute_query("SELECT id_currency_default FROM tb_opt LIMIT 1", 0, True, "", "", "", "")
        Dim query As String = "SELECT * FROM tb_lookup_currency WHERE id_currency = '" + id_currency_default + "' ORDER BY id_currency ASC"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        viewLookupQuery(LECurrency, query, 0, "currency", "id_currency")
    End Sub

    Private Sub FormFGAdjOutDet_FormClosed(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub BtnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCancel.Click
        Close()
    End Sub

    Sub viewDetailReturn()
        Dim query As String = ""
        query += "CALL view_fg_adj_out('" + id_adj_out_fg + "')"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCDetail.DataSource = data
        GVDetail.BestFitColumns()
        'GVDetail.Columns("id_product").GroupIndex = 0
    End Sub

    'Row Manipulation
    Sub focusColumnCode()
        GVDetail.FocusedColumn = GVDetail.VisibleColumns(0)
        GVDetail.ShowEditor()
    End Sub
    Sub newRows()
        GVDetail.AddNewRow()
        cantEdit()
    End Sub
    Sub deleteRows()
        GVDetail.DeleteRow(GVDetail.FocusedRowHandle)
        GCDetail.RefreshDataSource()
        GVDetail.RefreshData()
        cantEdit()
    End Sub

    Sub cantEdit()
        Dim id_product_curr As String = ""
        Dim id_drawer_curr As String = ""
        Try
            'id_product_curr = GVDetail.GetFocusedRowCellDisplayText("id_product").ToString()
            id_drawer_curr = GVDetail.GetFocusedRowCellDisplayText("id_wh_drawer").ToString()
        Catch ex As Exception

        End Try
        If GVDetail.RowCount < 1 Or id_drawer_curr = "" Then
            BtnEdit.Enabled = False
            BtnDel.Enabled = False
        Else
            If check_edit_report_status(id_report_status, "42", id_adj_out_fg) Or action = "ins" Then
                BtnEdit.Enabled = True
                BtnDel.Enabled = True
            End If
        End If
    End Sub

    Private Sub LECurrency_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles LECurrency.Validating
        EP_LE_cant_blank(EPAdj, LECurrency)
    End Sub

    Private Sub LEReportStatus_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles LEReportStatus.Validating
        EP_LE_cant_blank(EPAdj, LEReportStatus)
    End Sub

    Private Sub BtnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnAdd.Click
        Cursor = Cursors.WaitCursor

        FormFGAdjOutSingle.id_pop_up = "1"
        FormFGAdjOutSingle.action = "ins"
        FormFGAdjOutSingle.SLEWH.Enabled = True
        FormFGAdjOutSingle.SLELocator.Enabled = True
        FormFGAdjOutSingle.SLERack.Enabled = True
        FormFGAdjOutSingle.SLEDrawer.Enabled = True
        FormFGAdjOutSingle.allow_all_locator = False
        FormFGAdjOutSingle.allow_all_rack = False
        FormFGAdjOutSingle.allow_all_drawer = False
        FormFGAdjOutSingle.allow_all_wh = False
        FormFGAdjOutSingle.GroupControlInput.Visible = True
        If action = "ins" Then
            FormFGAdjOutSingle.id_adj_out_fg = "0"
        Else
            FormFGAdjOutSingle.id_adj_out_fg = "-1"
        End If
        FormFGAdjOutSingle.ShowDialog()
        Cursor = Cursors.Default
    End Sub

    Private Sub GVDetail_FocusedRowChanged(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles GVDetail.FocusedRowChanged
        cantEdit()
    End Sub

    Private Sub BtnDel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnDel.Click
        Dim confirm As String = ""
        confirm = "Are you sure to delete this data?"
        If (MessageBox.Show(confirm, "Delete Confirmation", MessageBoxButtons.YesNo) <> DialogResult.Yes) Then Return
        Dim id_product As String = GVDetail.GetFocusedRowCellValue("id_product").ToString
        Dim id_adj_out_fg_det As String = GVDetail.GetFocusedRowCellDisplayText("id_adj_out_fg_det").ToString
        Dim id_wh_drawer As String = GVDetail.GetFocusedRowCellDisplayText("id_wh_drawer").ToString
        Dim adj_out_fg_det_qty As String = GVDetail.GetFocusedRowCellValue("adj_out_fg_det_qty").ToString
        Try
            deleteRows()
            total_amount = Double.Parse(GVDetail.Columns("adj_out_fg_det_amount").SummaryItem.SummaryValue.ToString)
            METotSay.Text = ConvertCurrencyToEnglish(total_amount, LECurrency.EditValue.ToString)
        Catch ex As Exception
            errorConnection()
        End Try
    End Sub

    Private Sub BtnEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnEdit.Click
        Cursor = Cursors.WaitCursor
        Dim id_wh_locator_curr As String = GVDetail.GetFocusedRowCellDisplayText("id_wh_locator").ToString
        Dim id_wh_rack_curr As String = GVDetail.GetFocusedRowCellDisplayText("id_wh_rack").ToString
        Dim id_wh_drawer_curr As String = GVDetail.GetFocusedRowCellDisplayText("id_wh_drawer").ToString
        Dim wh_drawer_curr As String = GVDetail.GetFocusedRowCellDisplayText("wh_drawer").ToString
        Dim id_wh_curr As String = GVDetail.GetFocusedRowCellDisplayText("id_comp").ToString
        Dim id_product_edit As String = GVDetail.GetFocusedRowCellDisplayText("id_product").ToString
        Dim name_edit As String = GVDetail.GetFocusedRowCellDisplayText("name").ToString
        Dim code_edit As String = GVDetail.GetFocusedRowCellDisplayText("code").ToString
        Dim qty As Decimal = GVDetail.GetFocusedRowCellValue("adj_out_fg_det_qty")
        Dim remark As String = GVDetail.GetFocusedRowCellDisplayText("adj_out_fg_det_note").ToString
        Dim id_adj_out_fg_det As String = GVDetail.GetFocusedRowCellDisplayText("id_adj_out_fg_det").ToString
        Dim price As Decimal = GVDetail.GetFocusedRowCellValue("adj_out_fg_det_price")

        FormFGAdjOutSingle.TEUnitPrice.EditValue = price
        FormFGAdjOutSingle.id_product_edit = id_product_edit
        FormFGAdjOutSingle.pl_mrs_det_qty = qty
        FormFGAdjOutSingle.pl_mrs_det_note = remark
        FormFGAdjOutSingle.id_wh_locator_edit = id_wh_locator_curr
        FormFGAdjOutSingle.id_wh_rack_edit = id_wh_rack_curr
        FormFGAdjOutSingle.id_wh_drawer_edit = id_wh_drawer_curr
        FormFGAdjOutSingle.id_wh = id_wh_curr
        FormFGAdjOutSingle.id_pop_up = "1"
        FormFGAdjOutSingle.action = "upd"
        FormFGAdjOutSingle.GroupControlInput.Visible = True
        FormFGAdjOutSingle.id_adj_out_fg = id_adj_out_fg
        FormFGAdjOutSingle.BtnChoose.Text = "Update"
        FormFGAdjOutSingle.ShowDialog()

        Cursor = Cursors.Default
    End Sub

    Private Sub BtnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSave.Click
        Cursor = Cursors.WaitCursor
        ValidateChildren()
        Dim cond_qty As Boolean = True
        GVDetail.OptionsBehavior.AutoExpandAllGroups = True
        If Not formIsValidInGroup(EPAdj, GroupGeneralHeader) Then
            errorInput()
        ElseIf Not cond_qty Or GVDetail.RowCount = 0 Then
            errorCustom("Error : " + System.Environment.NewLine + "- Data can't blank. " + System.Environment.NewLine + "- Qty can't blank or zero value !")
        Else
            'Main var
            Dim query As String = ""
            Dim query2 As String = ""
            Dim adj_out_fg_number As String = addSlashes(TxtAdjNumber.Text)
            Dim adj_out_fg_note As String = addSlashes(MENote.Text)
            Dim id_report_status As String = LEReportStatus.EditValue
            Dim succes As Boolean = False
            Dim adj_out_fg_total As String = decimalSQL(GVDetail.Columns("adj_out_fg_det_amount").SummaryItem.SummaryValue.ToString)
            Dim id_currency As String = LECurrency.EditValue.ToString
            If action = "ins" Then
                'Main table
                query = "INSERT INTO tb_adj_out_fg(adj_out_fg_number, adj_out_fg_date, adj_out_fg_note, id_report_status, adj_out_fg_total, id_currency) "
                query += "VALUES('" + adj_out_fg_number + "', NOW(), '" + adj_out_fg_note + "', '" + id_report_status + "', '" + adj_out_fg_total + "', '" + id_currency + "'); SELECT LAST_INSERT_ID();"
                id_adj_out_fg = execute_query(query, 0, True, "", "", "", "")
                'MsgBox(id_product_return)

                increase_inc_sales("13")

                'preapred default
                submit_who_prepared("42", id_adj_out_fg, id_user)

                'detail table
                For i As Integer = 0 To GVDetail.RowCount - 1
                    Try
                        Dim adj_out_fg_det_note As String = GVDetail.GetRowCellValue(i, "adj_out_fg_det_note").ToString
                        Dim adj_out_fg_det_qty As String = decimalSQL(GVDetail.GetRowCellValue(i, "adj_out_fg_det_qty").ToString)
                        Dim id_wh_drawer As String = GVDetail.GetRowCellValue(i, "id_wh_drawer").ToString
                        Dim id_product As String = GVDetail.GetRowCellValue(i, "id_product").ToString
                        Dim adj_out_fg_det_price As String = decimalSQL(GVDetail.GetRowCellValue(i, "adj_out_fg_det_price").ToString)

                        'INSERT TB DETAIL
                        query = "INSERT tb_adj_out_fg_det(id_adj_out_fg, adj_out_fg_det_note, adj_out_fg_det_qty, id_wh_drawer, id_product, adj_out_fg_det_price) "
                        query += "VALUES('" + id_adj_out_fg + "','" + adj_out_fg_det_note + "', '" + adj_out_fg_det_qty + "', '" + id_wh_drawer + "', '" + id_product + "', '" + adj_out_fg_det_price + "') "
                        execute_non_query(query, True, "", "", "", "")

                        'INSERT TB PL STORAGE
                        Dim query_upd_storage As String = "INSERT INTO tb_storage_fg(id_wh_drawer, id_storage_category, id_product, bom_unit_price, storage_product_qty, storage_product_datetime, storage_product_notes,id_stock_status, report_mark_type, id_report) "
                        query_upd_storage += "VALUES('" + id_wh_drawer + "', '2', '" + id_product + "', '" + decimalSQL(adj_out_fg_det_price.ToString) + "', '" + decimalSQL(adj_out_fg_det_qty) + "', NOW(), 'Adjustment Out : " + adj_out_fg_number + "','2','42','" + id_adj_out_fg + "')"
                        execute_non_query(query_upd_storage, True, "", "", "", "")
                    Catch ex As Exception
                    End Try
                Next

                FormFGAdj.XTCAdj.SelectedTabPageIndex = 1
                FormFGAdj.viewAdjOut()
                Close()
            ElseIf action = "upd" Then
                Try
                    'update main table
                    query = "UPDATE tb_adj_out_fg SET adj_out_fg_number = '" + adj_out_fg_number + "', adj_out_fg_note = '" + adj_out_fg_note + "', id_report_status = '" + id_report_status + "', adj_out_fg_total = '" + adj_out_fg_total + "', id_currency = '" + id_currency + "' WHERE id_adj_out_fg = '" + id_adj_out_fg + "' "
                    execute_non_query(query, True, "", "", "", "")
                    FormFGAdj.XTCAdj.SelectedTabPageIndex = 1
                    FormFGAdj.viewAdjOut()
                    Close()
                Catch ex As Exception
                    errorCustom(ex.ToString)
                End Try
            End If
        End If
        Cursor = Cursors.Default
    End Sub

    Private Sub GVDetail_CustomColumnDisplayText(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs) Handles GVDetail.CustomColumnDisplayText
        'If e.Column.FieldName = "id_product" Then
        '    Dim rowhandle As Integer = e.RowHandle
        '    If GVDetail.IsGroupRow(rowhandle) Then
        '        rowhandle = GVDetail.GetDataRowHandleByGroupRowHandle(rowhandle)
        '        e.DisplayText = GVDetail.GetRowCellDisplayText(rowhandle, "name")
        '    End If
        'End If
        If e.Column.FieldName = "no" Then
            e.DisplayText = (e.ListSourceRowIndex + 1).ToString()
        End If
    End Sub

    Private Sub BMark_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BMark.Click
        FormReportMark.id_report = id_adj_out_fg
        FormReportMark.report_mark_type = "42"
        FormReportMark.form_origin = Name
        FormReportMark.ShowDialog()
    End Sub

    Private Sub BtnPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnPrint.Click
        Cursor = Cursors.WaitCursor
        ReportFGAdjOut.id_adj_out_fg = id_adj_out_fg
        Dim Report As New ReportFGAdjOut()

        Dim str As System.IO.Stream
        str = New System.IO.MemoryStream()
        GVDetail.SaveLayoutToStream(str, DevExpress.Utils.OptionsLayoutBase.FullLayout)
        str.Seek(0, System.IO.SeekOrigin.Begin)
        Report.GVDetail.RestoreLayoutFromStream(str, DevExpress.Utils.OptionsLayoutBase.FullLayout)
        str.Seek(0, System.IO.SeekOrigin.Begin)

        ' Show the report's preview. 
        Dim Tool As DevExpress.XtraReports.UI.ReportPrintTool = New DevExpress.XtraReports.UI.ReportPrintTool(Report)
        Tool.ShowPreview()
        Cursor = Cursors.Default
    End Sub

    Private Sub SimpleButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SimpleButton1.Click
        
    End Sub
End Class