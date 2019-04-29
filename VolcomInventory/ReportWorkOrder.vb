Public Class ReportWorkOrder
    Public Shared id_pre As String = "-1"
    Public Shared id_wo As String = "-1"
    Public Shared rmt As String = "-1"
    Public Shared data As DataTable = New DataTable

    Private Sub ReportWorkOrder_BeforePrint(sender As Object, e As Printing.PrintEventArgs) Handles MyBase.BeforePrint
        DataSource = data

        If id_pre = "-1" Then
            load_mark_horz(rmt, id_wo, "2", "1", XrTable1)
        Else
            pre_load_mark_horz(rmt, id_wo, "2", "2", XrTable1)
        End If
    End Sub
End Class