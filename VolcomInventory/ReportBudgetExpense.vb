Public Class ReportBudgetExpense
    Public Shared id As String = "-1"
    Public Shared dt As DataTable

    Private Sub ReportBudgetExpense_BeforePrint(sender As Object, e As Printing.PrintEventArgs) Handles MyBase.BeforePrint
        GCData.DataSource = dt
        load_mark_horz("136", id, "2", "1", XrTable1)
    End Sub
End Class