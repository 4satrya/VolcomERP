Public Class ReportSalesDelOrderSlip
    Public Shared id_pl_sales_order_del As String
    Public Shared dt As DataTable
    Public Shared id_pre As String = "-1"

    Private Sub ReportSalesDelOrderSlip_BeforePrint(sender As Object, e As Printing.PrintEventArgs) Handles MyBase.BeforePrint
        GCItemList.DataSource = dt
        If id_pre = "-1" Then
            load_mark_horz("103", id_pl_sales_order_del, "2", "1", XrTable1)
        Else
            pre_load_mark_horz("103", id_pl_sales_order_del, "2", "2", XrTable1)
        End If
    End Sub
End Class