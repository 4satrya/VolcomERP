Public Class ReportFGProposePriceDetail
    Public Shared id As String = "-1"
    Public Shared dt As DataTable
    Public Shared rmt As String = ""
    Public Shared is_pre As String = "-1"
    Public Shared id_report_status As String = "-1"

    Private Sub ReportFGProposePriceDetail_BeforePrint(sender As Object, e As Printing.PrintEventArgs) Handles MyBase.BeforePrint
        GCData.DataSource = dt
        If is_pre = "1" Then
            pre_load_mark_horz_pd(rmt, id, "2", "2", XrTable1)
        Else
            load_mark_horz(rmt, id, "2", "1", XrTable1)
        End If

        'sattus
        If id_report_status = "6" Then
            LabelTitleApprovedDate.Visible = True
            LabelDotApprovedDate.Visible = True
            LabelApprovedDate.Visible = True
        End If

        'printed date & approved date
        Dim qpd As String = "SELECT UPPER(DATE_FORMAT(rm.report_mark_datetime, '%d %M %Y')) AS `approved_date`, DATE_FORMAT(NOW(), '%d/%m/%Y %H:%i') AS `printed_date` 
        FROM tb_report_mark rm 
        WHERE rm.id_report=" + id + " AND rm.report_mark_type=" + rmt + " AND rm.id_mark=2
        ORDER BY rm.id_report_mark DESC LIMIT 1 "
        Dim dpd As DataTable = execute_query(qpd, -1, True, "", "", "", "")
        DataSource = dpd
    End Sub

    Private Sub GVData_CustomColumnDisplayText(sender As Object, e As DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs) Handles GVData.CustomColumnDisplayText
        If e.Column.FieldName = "no" Then
            e.DisplayText = (e.ListSourceRowIndex + 1).ToString()
        End If
    End Sub
End Class