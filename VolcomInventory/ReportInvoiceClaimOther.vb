Public Class ReportInvoiceClaimOther
    Public Shared id_invoice As String
    Public id_pre As String
    Public Shared dt As DataTable

    Private Sub Detail_BeforePrint(sender As Object, e As Printing.PrintEventArgs) Handles Detail.BeforePrint
        GCList.DataSource = dt
        If id_pre = "-1" Then
            load_mark_horz("280", id_invoice, "2", "1", XrTable1)
        Else
            pre_load_mark_horz("280", id_invoice, "2", "2", XrTable1)
        End If
    End Sub
End Class