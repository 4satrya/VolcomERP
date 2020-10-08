Public Class ReportMatStockSummary
    Public id_mat_summary As String = "-1"
    Public data As DataTable = New DataTable

    Private Sub ReportStockQCStockReportSummary_BeforePrint(sender As Object, e As Printing.PrintEventArgs) Handles MyBase.BeforePrint
        GridControlSummary.DataSource = data

        pre_load_mark_horz("269", id_mat_summary, "2", "2", XrTable1)
    End Sub
End Class