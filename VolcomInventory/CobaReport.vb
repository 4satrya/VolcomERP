Public Class CobaReport
    Public Shared dt As DataTable

    Private Sub CobaReport_BeforePrint(sender As Object, e As Printing.PrintEventArgs) Handles MyBase.BeforePrint
        GCList.DataSource = dt
    End Sub
End Class