Public Class FormValidateStock
    Public dt As DataTable
    Private Sub BtnClose_Click(sender As Object, e As EventArgs) Handles BtnClose.Click
        Close()
    End Sub

    Private Sub FormValidateStock_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub FormValidateStock_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        GCData.DataSource = dt
        GVData.BestFitColumns()
    End Sub

    Private Sub BtnPrint_Click(sender As Object, e As EventArgs) Handles BtnPrint.Click
        print_raw(GCData, "")
    End Sub
End Class