Public Class FormSalesReturnDetNew
    Public allow As Boolean = True

    Private Sub FormSalesReturnDetNew_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim query As String = "SELECT * FROM tb_lookup_ret_type a ORDER BY a.id_ret_type ASC "
        viewLookupQuery(LookUpEdit1, query, 0, "ret_type", "id_ret_type")
        ActiveControl = LookUpEdit1
    End Sub

    Private Sub FormSalesReturnDetNew_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Sub chooses()
        Cursor = Cursors.WaitCursor

        If LookUpEdit1.EditValue.ToString = "2" Then
            FormMenuAuth.type = "1"
            FormMenuAuth.ShowDialog()
            If Not allow Then
                Cursor = Cursors.Default
                Exit Sub
            End If
        End If

        FormSalesReturnDet.id_sales_return_order = FormSalesReturn.GVSalesReturnOrder.GetFocusedRowCellValue("id_sales_return_order").ToString
        FormSalesReturnDet.action = "ins"
        FormSalesReturnDet.id_ret_type = LookUpEdit1.EditValue.ToString
        FormSalesReturnDet.TxtReturnType.Text = LookUpEdit1.Text.ToString
        FormSalesReturnDet.ShowDialog()
        Close()
        Cursor = Cursors.Default
    End Sub

    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs) Handles SimpleButton1.Click
        chooses()
    End Sub
End Class