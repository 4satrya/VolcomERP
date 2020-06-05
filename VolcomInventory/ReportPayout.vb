Public Class ReportPayout
    Public Shared id As String = "-1"
    Public Shared dt As DataTable
    Public Shared rmt As String = "248"
    Public Shared is_hidden_mark As String = "-1"
    Public Shared id_report_status As String = "-1"

    Private Sub ReportPayout_BeforePrint(sender As Object, e As Printing.PrintEventArgs) Handles MyBase.BeforePrint
        GCData.DataSource = dt
        pre_load_list_horz(rmt, 2, 1, XrTable1)

        'printed date & approved date
        Dim qpd As String = "SELECT DATE_FORMAT(NOW(), '%d/%m/%Y %H:%i') AS `printed_date` "
        Dim dpd As DataTable = execute_query(qpd, -1, True, "", "", "", "")
        DataSource = dpd
    End Sub

    Private Sub GVData_CustomColumnDisplayText(sender As Object, e As DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs) Handles GVData.CustomColumnDisplayText
        If e.Column.FieldName = "no" Then
            e.DisplayText = (e.ListSourceRowIndex + 1).ToString()
        End If
    End Sub
End Class