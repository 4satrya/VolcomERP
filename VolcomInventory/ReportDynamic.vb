Public Class ReportDynamic
    Public Shared dt As DataTable

    Private Sub ReportDynamic_BeforePrint(sender As Object, e As Printing.PrintEventArgs) Handles MyBase.BeforePrint
        GCDetail.DataSource = dt
    End Sub
End Class