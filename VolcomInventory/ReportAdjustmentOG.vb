Public Class ReportAdjustmentOG
    Public id_adjustment As String = "-1"
    Public data As DataTable = New DataTable

    Private Sub ReportStockQCStockReportSummary_BeforePrint(sender As Object, e As Printing.PrintEventArgs) Handles MyBase.BeforePrint
        GCList.DataSource = data

        pre_load_mark_horz("241", id_adjustment, "2", "2", XrTable1)
    End Sub
End Class