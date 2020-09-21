Public Class ReportPurcOrderCloseReceiving
    Public id As String = "0"
    Public data As DataTable = New DataTable
    Public id_pre As String = "-1"
    Public report_mark_type As String = "-1"

    Private Sub ReportPurcOrderCloseReceiving_BeforePrint(sender As Object, e As Printing.PrintEventArgs) Handles MyBase.BeforePrint
        GCPO.DataSource = data

        GVPO.BestFitColumns()

        If id_pre = "-1" Then
            load_mark_horz(report_mark_type, id, "2", "1", XrTable1)
        Else
            pre_load_mark_horz(report_mark_type, id, "2", "2", XrTable1)
        End If
    End Sub
End Class