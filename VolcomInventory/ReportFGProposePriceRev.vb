Public Class ReportFGProposePriceRev
    Public Shared id As String = "-1"
    Public Shared dt As DataTable
    Public Shared type As String = ""
    Public Shared rmt As String = ""
    Public Shared is_pre As String = "-1"
    Public Shared id_report_status As String = "-1"

    Private Sub ReportFGProposePriceRev_BeforePrint(sender As Object, e As Printing.PrintEventArgs) Handles MyBase.BeforePrint
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

    Private Sub GVData_RowCellStyle(sender As Object, e As DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs) Handles GVData.RowCellStyle
        If type = "2" Then
            Dim currview As DevExpress.XtraGrid.Views.Grid.GridView = TryCast(sender, DevExpress.XtraGrid.Views.Grid.GridView)
            Dim stt As String = "0"
            Try
                stt = currview.GetRowCellValue(e.RowHandle, "id_fg_propose_price_rev_det").ToString
            Catch ex As Exception
                stt = "0"
            End Try

            If stt <> "0" Then
                e.Appearance.BackColor = Color.Gainsboro
                e.Appearance.FontStyleDelta = FontStyle.Regular
            Else
                e.Appearance.BackColor = Color.Empty
                e.Appearance.FontStyleDelta = FontStyle.Regular
            End If
        End If

    End Sub
End Class