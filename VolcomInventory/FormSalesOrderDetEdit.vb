Public Class FormSalesOrderDetEdit
    Public id_pop_up As String = "-1"
    Dim gv As DevExpress.XtraGrid.Views.Grid.GridView
    Dim column_qty_name As String = ""

    Private Sub FormSalesOrderDetEdit_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If id_pop_up = "-1" Then
            gv = FormSalesOrderDet.GVItemList
            column_qty_name = "sales_order_det_qty"
        ElseIf id_pop_up = "1" Then
            gv = FormSalesReturnOrderDet.GVItemList
            column_qty_name = "sales_return_order_det_qty"
        End If
        TxtCode.Text = gv.GetFocusedRowCellValue("code").ToString
        TxtDesign.Text = gv.GetFocusedRowCellValue("name").ToString
        TxtSize.Text = gv.GetFocusedRowCellValue("size").ToString
        TxtCurrent.EditValue = gv.GetFocusedRowCellValue(column_qty_name)
        TxtAdd.EditValue = 1
        getQty()
        TxtAdd.Focus()
    End Sub

    Private Sub TxtAdd_KeyDown(sender As Object, e As KeyEventArgs) Handles TxtAdd.KeyDown
        If e.KeyCode = Keys.Enter Then
            Dim qty_limit As Integer = gv.GetFocusedRowCellValue("qty_avail")
            Dim qty As Integer = TxtQty.EditValue
            If qty > qty_limit Then
                stopCustom("Can't exceed " + qty_limit.ToString)
                TxtAdd.EditValue = 1
                TxtAdd.Focus()
            Else
                gv.SetFocusedRowCellValue(column_qty_name, qty)
                gv.SetFocusedRowCellValue("amount", qty * gv.GetFocusedRowCellValue("design_price"))
                Close()
            End If
        End If
    End Sub

    Private Sub TextEdit5_Properties_KeyUp(sender As Object, e As KeyEventArgs) Handles TxtAdd.Properties.KeyUp
        getQty()
    End Sub

    Sub getQty()
        Dim curr As Integer = TxtCurrent.EditValue
        Dim add As Integer = 0
        Try
            add = TxtAdd.EditValue
        Catch ex As Exception
        End Try
        TxtQty.EditValue = curr + add
    End Sub

    Private Sub FormSalesOrderDetEdit_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub FormSalesOrderDetEdit_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.Escape Then
            Close()
        End If
    End Sub
End Class