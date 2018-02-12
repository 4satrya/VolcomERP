Public Class FormSalesReturnOrderOLSingle
    Private Sub FormSalesReturnOrderOLSingle_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim query As String = "CALL view_stock_ol_store2('" + FormSalesReturnOrderOLDet.id_sales_order + "'," + FormSalesReturnOrderOLDet.id_store + ") "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCList.DataSource = data
        GVList.FocusedColumn = GridColumnOrder
    End Sub

    Private Sub FormSalesReturnOrderOLSingle_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub BtnOK_Click(sender As Object, e As EventArgs) Handles BtnOK.Click
        makeSafeGV(GVList)
        GVList.ActiveFilterString = "[order]>0"
        If GVList.RowCount > 0 Then
            'check exist item
            Dim cond_exists As Boolean = False
            Dim err_exist As String = ""
            For i As Integer = 0 To ((GVList.RowCount - 1) - GetGroupRowCount(GVList))
                Dim id_product_cek As String = GVList.GetRowCellValue(i, "id_product").ToString
                Dim code_cek As String = GVList.GetRowCellValue(i, "code").ToString
                Dim name_cek As String = GVList.GetRowCellValue(i, "name").ToString
                Dim size_cek As String = GVList.GetRowCellValue(i, "size").ToString
                FormSalesReturnOrderOLDet.GVItemList.ActiveFilterString = "[id_product]='" + id_product_cek + "'"
                If FormSalesReturnOrderOLDet.GVItemList.RowCount > 0 Then
                    cond_exists = True
                    err_exist = code_cek + "/" + name_cek + "/ Size " + size_cek + " already exist. "
                    Exit For
                End If
            Next
            FormSalesReturnOrderOLDet.GVItemList.ActiveFilterString = ""

            If cond_exists Then
                stopCustom(err_exist)
                GVList.ActiveFilterString = ""
            Else
                For ls As Integer = 0 To ((GVList.RowCount - 1) - GetGroupRowCount(GVList))
                    Dim newRow As DataRow = (TryCast(FormSalesReturnOrderOLDet.GCItemList.DataSource, DataTable)).NewRow()
                    newRow("code") = GVList.GetRowCellValue(ls, "code").ToString
                    newRow("name") = GVList.GetRowCellValue(ls, "name").ToString
                    newRow("size") = GVList.GetRowCellValue(ls, "size").ToString
                    newRow("sales_return_order_det_qty") = GVList.GetRowCellValue(ls, "order")
                    newRow("amount") = GVList.GetRowCellValue(ls, "order") * GVList.GetRowCellValue(ls, "design_price")
                    newRow("design_price_type") = GVList.GetRowCellValue(ls, "design_price_type")
                    newRow("design_price") = GVList.GetRowCellValue(ls, "design_price")
                    newRow("id_design") = GVList.GetRowCellValue(ls, "id_design").ToString
                    newRow("id_product") = GVList.GetRowCellValue(ls, "id_product").ToString
                    newRow("id_design_price") = GVList.GetRowCellValue(ls, "id_design_price").ToString
                    newRow("id_sales_return_order") = "0"

                    TryCast(FormSalesReturnOrderOLDet.GCItemList.DataSource, DataTable).Rows.Add(newRow)
                    FormSalesReturnOrderOLDet.GCItemList.RefreshDataSource()
                    FormSalesReturnOrderOLDet.GVItemList.RefreshData()
                Next
                Close()
            End If
        Else
            stopCustom("Order qty can't blank!")
            GVList.ActiveFilterString = ""
        End If
    End Sub

    Private Sub GVList_CellValueChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles GVList.CellValueChanged
        If e.Column.FieldName = "order" Then
            Cursor = Cursors.WaitCursor
            Dim row_foc As String = e.RowHandle.ToString
            Dim avail As Integer = GVList.GetRowCellValue(row_foc, "qty").ToString
            Dim val_foc As Integer = e.Value
            If val_foc > avail Then
                stopCustom("Order can't exceed : " + avail.ToString + " pcs.")
                GVList.SetRowCellValue(row_foc, "order", GVList.ActiveEditor.OldEditValue)
                GVList.FocusedColumn = GridColumnOrder
            End If
            Cursor = Cursors.Default
        End If
    End Sub
End Class