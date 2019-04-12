Public Class ReportBankDeposit
    Public Shared id_deposit As String
    Public id_pre As String
    Public Shared dt As DataTable

    Private Sub ReportBankDeposit_BeforePrint(sender As Object, e As Printing.PrintEventArgs) Handles MyBase.BeforePrint
        GCList.DataSource = dt
        If id_pre = "-1" Then
            load_mark_horz("162", id_deposit, "2", "1", XrTable1)
        Else
            pre_load_mark_horz("162", id_deposit, "2", "2", XrTable1)
        End If
    End Sub
End Class