Public Class ReportPayoutZalora
    Public id As String = "-1"
    Public report_mark_type As String = "-1"

    Private Sub ReportPayoutZalora_BeforePrint(sender As Object, e As Printing.PrintEventArgs) Handles MyBase.BeforePrint
        pre_load_mark_horz(report_mark_type, id, "2", "2", XrTable1)
    End Sub
End Class