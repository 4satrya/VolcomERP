Public Class ReportSalesReturnOrder
    Public Shared id_sales_return_order As String
    Public Shared dt As DataTable
    Public Shared is_hidden_app_list As String = "-1"


    Private Sub ReportSalesOrder_BeforePrint(ByVal sender As System.Object, ByVal e As System.Drawing.Printing.PrintEventArgs) Handles MyBase.BeforePrint
        GridControl1.DataSource = dt
        If is_hidden_app_list = "-1" Then
            load_mark_horz("45", id_sales_return_order, "2", "1", XrTable1)
        End If
    End Sub

    Private Sub GridView1_CustomColumnDisplayText(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs) Handles GridView1.CustomColumnDisplayText
        If e.Column.FieldName = "no" Then
            e.DisplayText = (e.ListSourceRowIndex + 1).ToString()
        End If
    End Sub
End Class