Public Class FormSalesCreditNotePopInv
    Public id_pop_up As String = "-1"
    Public cond As String = ""

    Private Sub FormSalesCreditNotePopInv_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        viewInvoice()
    End Sub

    Private Sub FormSalesCreditNotePopInv_FormClosed(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub BtnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCancel.Click
        Close()
    End Sub

    Sub viewInvoice()
        Dim query_c As ClassSalesInv = New ClassSalesInv()
        Dim query As String = ""

        Me.WindowState = FormWindowState.Maximized

        'update 3 September 2015
        If id_pop_up = "4" Then
            query = query_c.queryMain("AND a.id_memo_type=''1'' AND a.id_store_contact_from=" + FormSalesPOSDet.id_store_contact_from + "  AND c.id_commerce_type=2 AND a.id_report_status=''6'' " + cond, "1")
        Else
            query = query_c.queryMain("AND (a.id_memo_type=''1'' OR a.id_memo_type=''3'' OR a.id_memo_type=''5'') AND a.id_report_status=''6'' ", "1")
        End If


        'If id_pop_up = "1" Then
        '    query = query_c.queryMain("AND a.id_memo_type=''1'' AND a.id_report_status=''6'' ", "1")
        'ElseIf id_pop_up = "2" Then
        '    query = query_c.queryMain("AND a.id_memo_type=''3'' AND a.id_report_status=''6'' ", "1")
        'ElseIf id_pop_up = "3" Then
        '    query = query_c.queryMain("AND a.id_memo_type=''1'' AND a.id_report_status=''6'' ", "1")
        'End If

        'End update

        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCSalesPOS.DataSource = data
        If GVSalesPOS.RowCount > 0 Then
            GVSalesPOS.BestFitColumns()
            BtnChoose.Enabled = True
        Else
            BtnChoose.Enabled = False
        End If
        viewInvoiceDet()
    End Sub

    Sub viewInvoiceDet()
        Dim id_sales_pos_param As String = "-1"
        Try
            id_sales_pos_param = GVSalesPOS.GetFocusedRowCellValue("id_sales_pos").ToString
        Catch ex As Exception
        End Try

        Dim query_c As ClassSalesInv = New ClassSalesInv()
        Dim query As String = query_c.queryDetail(id_sales_pos_param)
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCItemList.DataSource = data
    End Sub

    Private Sub GVSalesPOS_ColumnFilterChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GVSalesPOS.ColumnFilterChanged
        Cursor = Cursors.WaitCursor
        viewInvoiceDet()
        Cursor = Cursors.Default
    End Sub

    Private Sub GVSalesPOS_FocusedRowChanged(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles GVSalesPOS.FocusedRowChanged
        Cursor = Cursors.WaitCursor
        viewInvoiceDet()
        Cursor = Cursors.Default
    End Sub

    Private Sub BtnChoose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnChoose.Click
        Cursor = Cursors.WaitCursor
        If id_pop_up = "1" Then
            FormSalesCreditNoteDet.id_sales_pos_ref = GVSalesPOS.GetFocusedRowCellValue("id_sales_pos").ToString
            FormSalesCreditNoteDet.id_so_type = GVSalesPOS.GetFocusedRowCellValue("id_so_type").ToString
            FormSalesCreditNoteDet.id_store_contact_from = GVSalesPOS.GetFocusedRowCellValue("id_store_contact_from").ToString
            FormSalesCreditNoteDet.TxtInvoice.Text = GVSalesPOS.GetFocusedRowCellValue("sales_pos_number").ToString
            FormSalesCreditNoteDet.TxtNameCompFrom.Text = GVSalesPOS.GetFocusedRowCellValue("store_name_from").ToString
            FormSalesCreditNoteDet.MEAdrressCompFrom.Text = GVSalesPOS.GetFocusedRowCellValue("store_address_from").ToString
            FormSalesCreditNoteDet.TxtInvStart.Text = GVSalesPOS.GetFocusedRowCellValue("sales_pos_start_periodx").ToString
            FormSalesCreditNoteDet.TxtInvEnd.Text = GVSalesPOS.GetFocusedRowCellValue("sales_pos_end_periodx").ToString
            FormSalesCreditNoteDet.TxtSalesType.Text = GVSalesPOS.GetFocusedRowCellValue("so_type").ToString
            FormSalesCreditNoteDet.SPDiscount.EditValue = GVSalesPOS.GetFocusedRowCellValue("sales_pos_discount").ToString
            FormSalesCreditNoteDet.SPVat.Text = GVSalesPOS.GetFocusedRowCellValue("sales_pos_vat").ToString
            FormSalesCreditNoteDet.id_memo_type_ref = GVSalesPOS.GetFocusedRowCellValue("id_memo_type").ToString
            FormSalesCreditNoteDet.TEMemoType.Text = GVSalesPOS.GetFocusedRowCellValue("memo_type").ToString
            FormSalesCreditNoteDet.action_load_number()
            FormSalesCreditNoteDet.GroupControlList.Enabled = True
            FormSalesCreditNoteDet.viewDetail()
            FormSalesCreditNoteDet.check_but()
            Close()
        ElseIf id_pop_up = "2" Then
            FormFGMissingCreditNoteStoreDet.id_sales_pos_ref = GVSalesPOS.GetFocusedRowCellValue("id_sales_pos").ToString
            FormFGMissingCreditNoteStoreDet.id_so_type = GVSalesPOS.GetFocusedRowCellValue("id_so_type").ToString
            FormFGMissingCreditNoteStoreDet.id_store_contact_from = GVSalesPOS.GetFocusedRowCellValue("id_store_contact_from").ToString
            FormFGMissingCreditNoteStoreDet.TxtInvoice.Text = GVSalesPOS.GetFocusedRowCellValue("sales_pos_number").ToString
            FormFGMissingCreditNoteStoreDet.TxtNameCompFrom.Text = GVSalesPOS.GetFocusedRowCellValue("store_name_from").ToString
            FormFGMissingCreditNoteStoreDet.MEAdrressCompFrom.Text = GVSalesPOS.GetFocusedRowCellValue("store_address_from").ToString
            FormFGMissingCreditNoteStoreDet.TxtInvStart.Text = GVSalesPOS.GetFocusedRowCellValue("sales_pos_start_periodx").ToString
            FormFGMissingCreditNoteStoreDet.TxtInvEnd.Text = GVSalesPOS.GetFocusedRowCellValue("sales_pos_end_periodx").ToString
            FormFGMissingCreditNoteStoreDet.TxtSalesType.Text = GVSalesPOS.GetFocusedRowCellValue("so_type").ToString
            FormFGMissingCreditNoteStoreDet.SPDiscount.EditValue = GVSalesPOS.GetFocusedRowCellValue("sales_pos_discount").ToString
            FormFGMissingCreditNoteStoreDet.SPVat.Text = GVSalesPOS.GetFocusedRowCellValue("sales_pos_vat").ToString
            FormFGMissingCreditNoteStoreDet.GroupControlList.Enabled = True
            FormFGMissingCreditNoteStoreDet.viewDetail()
            FormFGMissingCreditNoteStoreDet.check_but()
            Close()
        ElseIf id_pop_up = "3" Then
            'account here
            FormBillingDet.id_reff = GVSalesPOS.GetFocusedRowCellValue("id_sales_pos").ToString
            Dim id_cc As String = get_company_contact_x(GVSalesPOS.GetFocusedRowCellValue("id_store_contact_from").ToString, "3")
            FormBillingDet.id_cc = id_cc
            FormBillingDet.TEReffNumber.Text = GVSalesPOS.GetFocusedRowCellValue("sales_pos_number").ToString
            FormBillingDet.TECCCode.Text = get_company_x(id_cc, "2")
            FormBillingDet.TECCName.Text = GVSalesPOS.GetFocusedRowCellValue("store_name_from").ToString
            FormBillingDet.TEDisc.EditValue = GVSalesPOS.GetFocusedRowCellValue("sales_pos_discount").ToString
            FormBillingDet.TEVat.Text = GVSalesPOS.GetFocusedRowCellValue("sales_pos_vat").ToString
            FormBillingDet.LECurrency.EditValue = Nothing
            FormBillingDet.LECurrency.ItemIndex = FormBillingDet.LECurrency.Properties.GetDataSourceRowIndex("id_currency", "1")
            FormBillingDet.TEKurs.EditValue = 1
            'due date
            FormBillingDet.TEReffDate.EditValue = GVSalesPOS.GetFocusedRowCellValue("sales_pos_date")
            'date
            FormBillingDet.TEReffDueDate.EditValue = GVSalesPOS.GetFocusedRowCellValue("sales_pos_due_date")
            'insert detail
            For i As Integer = 0 To FormBillingDet.GVBilling.RowCount - 1
                FormBillingDet.GVBilling.DeleteRow(i)
            Next

            For i As Integer = 0 To GVItemList.RowCount - 1
                Dim newRow As DataRow = (TryCast(FormBillingDet.GCBilling.DataSource, DataTable)).NewRow()
                newRow("id_item") = GVItemList.GetRowCellValue(i, "id_product").ToString
                newRow("id_ref") = GVItemList.GetRowCellValue(i, "id_sales_pos_det").ToString
                newRow("description") = GVItemList.GetRowCellValue(i, "name").ToString + " " + GVItemList.GetRowCellValue(i, "color").ToString + " " + GVItemList.GetRowCellValue(i, "size").ToString
                newRow("code") = GVItemList.GetRowCellValue(i, "code")
                newRow("amount") = GVItemList.GetRowCellValue(i, "design_price")
                newRow("amount_valas") = GVItemList.GetRowCellValue(i, "design_price")
                newRow("qty") = GVItemList.GetRowCellValue(i, "sales_pos_det_qty")
                newRow("total_amount") = GVItemList.GetRowCellValue(i, "sales_pos_det_qty") * GVItemList.GetRowCellValue(i, "design_price")

                TryCast(FormBillingDet.GCBilling.DataSource, DataTable).Rows.Add(newRow)
                FormBillingDet.GCBilling.RefreshDataSource()
            Next
            FormBillingDet.calculate()

            Close()
        ElseIf id_pop_up = "4" Then
            FormSalesPOSDet.id_sales_pos_ref = GVSalesPOS.GetFocusedRowCellValue("id_sales_pos").ToString
            FormSalesPOSDet.TxtInvoice.Text = GVSalesPOS.GetFocusedRowCellValue("sales_pos_number").ToString
            FormSalesPOSDet.SPDiscount.EditValue = GVSalesPOS.GetFocusedRowCellValue("sales_pos_discount")
            FormSalesPOSDet.SPVat.EditValue = GVSalesPOS.GetFocusedRowCellValue("sales_pos_vat")
            FormSalesPOSDet.calculate()
            FormSalesPOSDet.viewDetail()
            FormSalesPOSDet.viewDetailCode()
            Close()
        End If
        Cursor = Cursors.Default
    End Sub

    Private Sub GVItemList_CustomColumnDisplayText(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs) Handles GVItemList.CustomColumnDisplayText
        If e.Column.FieldName = "no" Then
            e.DisplayText = (e.ListSourceRowIndex + 1).ToString()
        End If
    End Sub
End Class