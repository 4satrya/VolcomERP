Public Class ReportSalesReturn
    Public Shared id_pre As String = "-1"
    Public Shared id_sales_return As String = "-1"
    Public Shared dt As DataTable


    Private Sub ReportSalesReturn_BeforePrint(ByVal sender As System.Object, ByVal e As System.Drawing.Printing.PrintEventArgs) Handles MyBase.BeforePrint
        GridControl1.DataSource = dt
        If id_pre = "-1" Then
            load_mark_horz("46", id_sales_return, "2", "1", XrTable1)
        Else
            pre_load_mark_horz("46", id_sales_return, "2", "2", XrTable1)
        End If
    End Sub

    Private Sub GridView1_CustomColumnDisplayText(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs) Handles GridView1.CustomColumnDisplayText
        'If e.Column.FieldName = "no" Then
        '    e.DisplayText = (e.ListSourceRowIndex + 1).ToString()
        'End If
    End Sub
End Class