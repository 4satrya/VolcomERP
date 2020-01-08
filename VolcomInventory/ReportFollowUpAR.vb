﻿Public Class ReportFollowUpAR
    Public id_follow_up_recap As String = "0"

    Private Sub ReportFollowUpAR_BeforePrint(sender As Object, e As Printing.PrintEventArgs) Handles MyBase.BeforePrint
        XrLabelYear.Text = "Tahun " + execute_query("SELECT YEAR(follow_up_date) AS follow_up_date FROM tb_follow_up_recap WHERE id_follow_up_recap = " + id_follow_up_recap, 0, True, "", "", "", "")

        Dim query As String = "
            SELECT (@no := IF(@last_group <> `group`, (@no + 1), @no)) AS `no`, `group`, `amount`, `due_date`, `follow_up_date`, `follow_up`, `follow_up_result`, (@last_group := `group`) AS `last_group`
            FROM (
                SELECT rd.group, rd.amount, DATE_FORMAT(rd.due_date, '%d %M %Y') AS due_date, DATE_FORMAT(rd.follow_up_date, '%d %M %Y') AS follow_up_date, rd.follow_up, rd.follow_up_result
                FROM tb_follow_up_recap_det AS rd
                LEFT JOIN tb_follow_up_recap AS r ON rd.id_follow_up_recap = r.id_follow_up_recap
                WHERE r.id_follow_up_recap = " + id_follow_up_recap + "
                ORDER BY rd.id_comp_group, rd.due_date, rd.follow_up_date
            ) AS tb, (SELECT @no := 0) AS `no`, (SELECT @last_group := '') AS last_group
        "

        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")

        GCActive.DataSource = data

        GVActive.BestFitColumns()

        'mark
        Dim id_pre As String = execute_query("SELECT IF(id_report_status = 6, -1, 1) AS id_pre FROM tb_follow_up_recap WHERE id_follow_up_recap = " + id_follow_up_recap, 0, True, "", "", "", "")

        If id_pre = "-1" Then
            load_mark_horz("234", id_follow_up_recap, "2", "1", XrTable1)
        Else
            pre_load_mark_horz("234", id_follow_up_recap, "2", "2", XrTable1)
        End If

        'force align left
        For i = 0 To XrTable1.Rows.Count - 1
            For j = 0 To XrTable1.Rows.Item(i).Cells.Count - 1
                XrTable1.Rows.Item(i).Cells.Item(j).Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0)
                XrTable1.Rows.Item(i).Cells.Item(j).TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
            Next
        Next
    End Sub

    Private Sub GVActive_CustomSummaryCalculate(sender As Object, e As DevExpress.Data.CustomSummaryEventArgs) Handles GVActive.CustomSummaryCalculate
        Dim item As DevExpress.XtraGrid.GridSummaryItem = TryCast(e.Item, DevExpress.XtraGrid.GridSummaryItem)

        If item.FieldName.ToString = "group" Then
            Select Case e.SummaryProcess
                Case DevExpress.Data.CustomSummaryProcess.Finalize
                    e.TotalValue = "Total " + GVActive.GetRowCellValue(e.RowHandle, "group").ToString
            End Select
        End If
    End Sub
End Class