Public Class FormSalesReturnOrderRevise
    Public id_sales_return_order As String = "-1"
    Public id_sales_return_order_det As String = "-1"
    Public id_product As String = "-1"
    Dim old_qty As Integer = 0

    Private Sub TextEdit5_Properties_KeyUp(sender As Object, e As KeyEventArgs) Handles TxtProcess.Properties.KeyUp, TxtOutstanding.Properties.KeyUp, TxtAdd.Properties.KeyUp

    End Sub

    Private Sub FormSalesReturnOrderRevise_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub FormSalesReturnOrderRevise_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim query As String = "CALL view_sales_return_order_limit('" + id_sales_return_order + "','" + id_sales_return_order_det + "','0')"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        TxtCode.Text = data.Rows(0)("code").ToString
        TxtDesign.Text = data.Rows(0)("name").ToString
        TxtSize.Text = data.Rows(0)("size").ToString
        TxtProcess.EditValue = data.Rows(0)("sales_return_det_qty_view")
        TxtOutstanding.EditValue = data.Rows(0)("sales_return_det_qty_limit")
        getTotalOrder()
        old_qty = TxtAdd.EditValue
        ActiveControl = TxtOutstanding
    End Sub

    Sub getTotalOrder()
        Dim process As Integer = 0
        Try
            process = TxtProcess.EditValue
        Catch ex As Exception

        End Try
        Dim outstand As Integer = 0
        Try
            outstand = TxtOutstanding.EditValue
        Catch ex As Exception

        End Try
        Dim total As Integer = process + outstand
        TxtAdd.EditValue = total
    End Sub

    Private Sub TxtOutstanding_KeyUp(sender As Object, e As KeyEventArgs) Handles TxtOutstanding.KeyUp
        getTotalOrder()
    End Sub

    Private Sub TxtOutstanding_KeyDown(sender As Object, e As KeyEventArgs) Handles TxtOutstanding.KeyDown
        If e.KeyCode = Keys.Enter Then
            If id_product = "-1" Then
                stopCustom("Please input spesific product !")
            Else
                Dim qty As Integer = TxtAdd.EditValue
                Dim dt As DataTable = execute_query("CALL view_stock_fg('" + FormSalesReturnOrderDet.id_comp + "', '" + FormSalesReturnOrderDet.id_wh_locator + "', '" + FormSalesReturnOrderDet.id_wh_rack + "', '" + FormSalesReturnOrderDet.id_wh_drawer + "', '" + id_product + "', '4', '9999-01-01') ", -1, True, "", "", "", "")
                Dim qty_limit As Integer = dt.Rows(0)("qty_all_product")
                If qty > qty_limit Then
                    stopCustom("Can't exceed " + qty_limit.ToString)
                Else
                    Dim query_upd = "UPDATE tb_sales_return_order_det SET sales_return_order_det_qty='" + decimalSQL(qty.ToString) + "' WHERE id_sales_return_order_det='" + id_sales_return_order_det + "' "
                    execute_non_query(query_upd, True, "", "", "", "")
                    FormSalesReturnOrderDet.viewDetail()

                    'log
                    Dim ret As New ClassSalesReturn()
                    ret.orderLog(FormSalesReturnOrderDet.id_sales_return_order, "2", addSlashes(TxtCode.Text) + " " + addSlashes(TxtDesign.Text) + " : From " + old_qty.ToString + " To " + TxtAdd.Text.ToString)

                    Close()
                End If
            End If
        End If
    End Sub
End Class