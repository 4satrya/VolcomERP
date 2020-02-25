Public Class ReportFGStockRSV
    Public Shared dt As DataTable

    Private Sub ReportFGStockQC_BeforePrint(ByVal sender As System.Object, ByVal e As System.Drawing.Printing.PrintEventArgs) Handles MyBase.BeforePrint
        GCRsv.DataSource = dt
    End Sub
End Class