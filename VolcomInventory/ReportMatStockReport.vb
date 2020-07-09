Public Class ReportMatStockReport
    Public Shared dt As DataTable

    Private Sub ReportMatStockReport_BeforePrint(ByVal sender As System.Object, ByVal e As System.Drawing.Printing.PrintEventArgs) Handles MyBase.BeforePrint
        GCStockReport.DataSource = dt
    End Sub
End Class