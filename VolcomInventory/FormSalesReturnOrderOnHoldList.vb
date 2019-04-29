Public Class FormSalesReturnOrderOnHoldList
    Private Sub FormSalesReturnOrderOnHoldList_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Text += " - " + FormSalesReturnOrderDet.TxtCodeCompTo.Text
        Dim id_comp As String = FormSalesReturnOrderDet.id_comp
        Dim ro As New ClassSalesReturnOrder()
        Dim query As String = ro.queryOnHold("AND c.id_comp='" + id_comp + "' AND ISNULL(rof.id_detail_on_hold) ", "1", True, id_comp)
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCOnHold.DataSource = data
        GVOnHold.BestFitColumns()
    End Sub

    Private Sub FormSalesReturnOrderOnHoldList_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub BtnCancell_Click(sender As Object, e As EventArgs) Handles BtnCancell.Click
        Close()
    End Sub

    Private Sub GVOnHold_CellValueChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles GVOnHold.CellValueChanged
        If e.Column.FieldName = "qty_ror" Then
            Cursor = Cursors.WaitCursor
            Dim row_foc As String = e.RowHandle.ToString
            Dim avail As Integer = GVOnHold.GetRowCellValue(row_foc, "qty_soh").ToString
            Dim val_foc As Integer = e.Value
            If val_foc > avail Then
                stopCustom("Order can't exceed : " + avail.ToString + " pcs.")
                GVOnHold.SetRowCellValue(row_foc, "qty_ror", GVOnHold.ActiveEditor.OldEditValue)
                GVOnHold.FocusedColumn = GridColumnqty_ror
            End If
            Cursor = Cursors.Default
        End If
    End Sub

    Private Sub BtnAdd_Click(sender As Object, e As EventArgs) Handles BtnAdd.Click
        Cursor = Cursors.WaitCursor
        GVOnHold.ActiveFilterString = "[qty_ror]>0 "

        If GVOnHold.RowCount > 0 Then
            'check duplicate
            Dim dt_check As DataTable = FormSalesReturnOrderDet.GCItemList.DataSource
            Dim cond As Boolean = True
            For i As Integer = 0 To ((GVOnHold.RowCount - 1) - GetGroupRowCount(GVOnHold))
                Dim dt_filter As DataRow() = dt_check.Select("[id_product]='" + GVOnHold.GetRowCellValue(i, "id_product").ToString + "' ")
                If dt_filter.Length > 0 Then
                    stopCustom(GVOnHold.GetRowCellValue(i, "name").ToString + "/Size " + GVOnHold.GetRowCellValue(i, "size").ToString + " already exist in order list")
                    GVOnHold.FocusedRowHandle = i
                    GVOnHold.ActiveFilterString = ""
                    cond = False
                    Exit For
                End If
            Next

            If cond Then
                Cursor = Cursors.WaitCursor
                FormSalesReturnOrderDet.delNotFoundMyRow()
                For i As Integer = 0 To ((GVOnHold.RowCount - 1) - GetGroupRowCount(GVOnHold))
                    Dim newRow As DataRow = (TryCast(FormSalesReturnOrderDet.GCItemList.DataSource, DataTable)).NewRow()
                    newRow("id_sales_return_order_det") = "0"
                    newRow("name") = GVOnHold.GetRowCellValue(i, "name").ToString
                    newRow("code") = GVOnHold.GetRowCellValue(i, "code").ToString
                    newRow("size") = GVOnHold.GetRowCellValue(i, "size").ToString
                    newRow("sales_return_order_det_qty") = GVOnHold.GetRowCellValue(i, "qty_ror")
                    newRow("qty_avail") = GVOnHold.GetRowCellValue(i, "qty_soh")
                    newRow("design_price_type") = ""
                    newRow("id_design_price") = GVOnHold.GetRowCellValue(i, "id_design_price").ToString
                    newRow("design_price") = GVOnHold.GetRowCellValue(i, "design_price")
                    newRow("id_return_cat") = "1"
                    newRow("return_cat") = "Return"
                    newRow("amount") = GVOnHold.GetRowCellValue(i, "qty_ror") * GVOnHold.GetRowCellValue(i, "design_price")
                    newRow("sales_return_order_det_note") = ""
                    newRow("id_design") = GVOnHold.GetRowCellValue(i, "id_design").ToString
                    newRow("id_product") = GVOnHold.GetRowCellValue(i, "id_product").ToString
                    newRow("id_sample") = "0"
                    newRow("id_detail_on_hold") = GVOnHold.GetRowCellValue(i, "id_sales_return_order_det").ToString
                    TryCast(FormSalesReturnOrderDet.GCItemList.DataSource, DataTable).Rows.Add(newRow)
                    FormSalesReturnOrderDet.GCItemList.RefreshDataSource()
                    FormSalesReturnOrderDet.GVItemList.RefreshData()
                Next
                FormSalesReturnOrderDet.check_but()
                Close()
                Cursor = Cursors.Default
            End If
        Else
            stopCustom("Nothing item selected")
            GVOnHold.ActiveFilterString = ""
        End If



        Cursor = Cursors.Default
    End Sub
End Class