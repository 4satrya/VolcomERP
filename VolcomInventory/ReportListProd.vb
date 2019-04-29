Public Class ReportListProd
    Public Shared dt As DataTable
    Public Shared rmt As String = "-1"

    Private Sub ReportPurcOrder_BeforePrint(sender As Object, e As Printing.PrintEventArgs) Handles MyBase.BeforePrint
        GCProd.DataSource = dt

        If rmt = "-1" Then
            pre_load_list_horz("13", 2, 1, XrTable1)
        Else
            pre_load_list_horz(rmt, 2, 1, XrTable1)
        End If

        rmt = "-1"
    End Sub
End Class