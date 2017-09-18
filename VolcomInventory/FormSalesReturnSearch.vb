Public Class FormSalesReturnSearch
    Public dt As DataTable

    Private Sub FormSalesReturnSearch_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        GCData.DataSource = dt
        GVData.FocusedRowHandle = 0
        ActiveControl = GCData
    End Sub

    Sub choose()
        If GVData.RowCount > 0 And GVData.FocusedRowHandle >= 0 Then
            Cursor = Cursors.WaitCursor
            FormSalesReturnDetProblem.TxtSearch.Text = ""
            FormSalesReturnDetProblem.TxtCode.Text = GVData.GetFocusedRowCellValue("design_code").ToString
            FormSalesReturnDetProblem.TxtBarcode.Text = GVData.GetFocusedRowCellValue("product_code").ToString
            FormSalesReturnDetProblem.TxtSize.Text = GVData.GetFocusedRowCellValue("size").ToString
            FormSalesReturnDetProblem.TxtDesign.Text = GVData.GetFocusedRowCellValue("name").ToString
            FormSalesReturnDetProblem.id_product = GVData.GetFocusedRowCellValue("id_product").ToString
            Close()
            Cursor = Cursors.Default
        End If
    End Sub

    Private Sub FormSalesReturnSearch_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub GVData_DoubleClick(sender As Object, e As EventArgs) Handles GVData.DoubleClick
        choose()
    End Sub

    Private Sub GVData_KeyDown(sender As Object, e As KeyEventArgs) Handles GVData.KeyDown
        If e.KeyCode = Keys.Enter Then
            choose()
        End If
    End Sub
End Class