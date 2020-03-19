Public Class ReportFormInvoiceTracking
    Public data As DataTable = New DataTable

    Private Sub ReportFormInvoiceTracking_BeforePrint(sender As Object, e As Printing.PrintEventArgs) Handles MyBase.BeforePrint
        GCUnpaid.DataSource = data

        For i = 0 To GVUnpaid.Columns.Count - 1
            GVUnpaid.Columns(i).Caption = GVUnpaid.Columns(i).Caption.Replace(" ", Environment.NewLine)
        Next
    End Sub
End Class