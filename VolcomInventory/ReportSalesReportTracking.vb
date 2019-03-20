Public Class ReportSalesReportTracking
    Public Shared dt As DataTable

    Private Sub ReportPurcOrder_BeforePrint(sender As Object, e As Printing.PrintEventArgs) Handles MyBase.BeforePrint
        GCListDesign.DataSource = dt
    End Sub
End Class