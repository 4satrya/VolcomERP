Public Class ReportFormInvoiceTrackingSummary
    Public data As DataTable = New DataTable

    Private Sub ReportFormInvoiceTrackingSummary_BeforePrint(sender As Object, e As Printing.PrintEventArgs) Handles MyBase.BeforePrint
        GCSummary.DataSource = data
    End Sub
End Class