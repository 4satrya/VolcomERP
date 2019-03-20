Public Class ReportSalesReturnRecDet
    Public Shared dt As DataTable
    Public Shared id As String

    Private Sub ReportSalesReturnRecDet_BeforePrint(sender As Object, e As Printing.PrintEventArgs) Handles MyBase.BeforePrint
        GCList.DataSource = dt

        load_mark_horz("168", id, "2", "1", XrTable1)
    End Sub
End Class