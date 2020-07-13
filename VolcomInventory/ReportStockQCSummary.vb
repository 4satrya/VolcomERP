Public Class ReportStockQCSummary
    Public Shared dt As DataTable

    Private Sub ReportStockQCSummary_BeforePrint(ByVal sender As System.Object, ByVal e As System.Drawing.Printing.PrintEventArgs) Handles MyBase.BeforePrint
        GCStockReport.DataSource = dt
    End Sub
End Class