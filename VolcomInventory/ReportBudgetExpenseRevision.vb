Public Class ReportBudgetExpenseRevision
    Public Shared id As String = "-1"
    Public Shared dt As DataTable

    Private Sub ReportBudgetExpenseRevision_BeforePrint(sender As Object, e As Printing.PrintEventArgs) Handles MyBase.BeforePrint
        GCRev.DataSource = dt
        load_mark_horz("138", id, "2", "1", XrTable1)
    End Sub
End Class