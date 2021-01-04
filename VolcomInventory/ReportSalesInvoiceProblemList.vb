Public Class ReportSalesInvoiceProblemList
    Public Shared id_sales_pos As String = "-1"
    Public Shared rmt As String = "-1"
    Public Shared id_report_status As String = "-1"
    Public Shared data As DataTable = New DataTable

    Private Sub ReportSalesInvoiceProblemList_BeforePrint(sender As Object, e As Printing.PrintEventArgs) Handles MyBase.BeforePrint
        Dim query As String = "CALL view_sales_pos_head_report(" + id_sales_pos + ", " + id_user + "); "
        Dim data_p As DataTable = execute_query(query, -1, True, "", "", "", "")
        DataSource = data_p
        'report status
        Dim itime As String = "2"
        If id_report_status = "1" Then
            itime = "2"
            LabelNotice.Visible = False
        ElseIf id_report_status = "6" Then
            itime = "1"
            LabelNotice.Visible = True
        End If
        GCProbList.DataSource = data
        GVProbList.BestFitColumns()
        pre_load_mark_horz_plain_acc(rmt, id_sales_pos, "(                       )", itime, XrTable1)
    End Sub

    Private Sub GVProbList_CustomColumnDisplayText(sender As Object, e As DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs) Handles GVProbList.CustomColumnDisplayText
        If e.Column.FieldName = "no" Then
            e.DisplayText = (e.ListSourceRowIndex + 1).ToString()
        End If
    End Sub
End Class