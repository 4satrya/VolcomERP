Public Class TestReport
    Public Shared dt As DataTable

    Private Sub Detail_BeforePrint(sender As Object, e As Printing.PrintEventArgs) Handles Detail.BeforePrint
        MyGridControl1.DataSource = dt
    End Sub
End Class