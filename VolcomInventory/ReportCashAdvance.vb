Public Class ReportCashAdvance
    Public Shared id_ca As String
    Public id_pre As String

    Private Sub ReportCashAdvance_BeforePrint(sender As Object, e As Printing.PrintEventArgs) Handles MyBase.BeforePrint
        If id_pre = "-1" Then
            load_mark_horz("167", id_ca, "2", "1", XrTable1)
        Else
            pre_load_mark_horz("167", id_ca, "2", "2", XrTable1)
        End If
    End Sub
End Class