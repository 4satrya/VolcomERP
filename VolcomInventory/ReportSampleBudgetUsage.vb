Public Class ReportSampleBudgetUsage
    Public Shared dt As DataTable

    Private Sub Detail_BeforePrint(sender As Object, e As Printing.PrintEventArgs) Handles Detail.BeforePrint
        GCBudgetCard.DataSource = dt

        'pre_load_list_horz("13", 2, 1, XrTable1)
    End Sub
End Class