Public Class FormReportBalanceTaxSummaryDet
    Public id_summary As String = "-1"

    Private Sub FormReportBalanceTaxSummaryDet_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        view_report_status()

        form_load()
    End Sub

    Private Sub FormReportBalanceTaxSummaryDet_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub SBGenerateSummary_Click(sender As Object, e As EventArgs) Handles SBGenerateSummary.Click
        Dim data As DataTable = execute_query("CALL view_summary_tax_pph('" + Date.Parse(DEDateFrom.EditValue.ToString).ToString("yyyy-MM-dd") + "', '" + Date.Parse(DEDateTo.EditValue.ToString).ToString("yyyy-MM-dd") + "')", -1, True, "", "", "", "")

        GCSummary.DataSource = data

        'numbering
        Dim last_tag_description As String = "0"

        Dim no As Integer = 0

        For i = 0 To data.Rows.Count - 1
            If Not data.Rows(i)("tag_description").ToString = last_tag_description Then
                no = 0
            End If

            no = no + 1

            data.Rows(i)("no") = no

            last_tag_description = data.Rows(i)("tag_description").ToString
        Next

        GVSummary.BestFitColumns()
    End Sub

    Sub view_report_status()
        Dim query As String = "
            SELECT 0 AS id_report_status, '' AS report_status
            UNION ALL
            SELECT id_report_status, report_status
            FROM tb_lookup_report_status
        "

        viewSearchLookupQuery(SLUEReportStatus, query, "id_report_status", "report_status", "id_report_status")
    End Sub

    Private Sub SBMark_Click(sender As Object, e As EventArgs) Handles SBMark.Click
        Cursor = Cursors.WaitCursor

        FormReportMark.report_mark_type = "284"
        FormReportMark.id_report = id_summary

        FormReportMark.ShowDialog()

        Cursor = Cursors.Default
    End Sub

    Private Sub SBSubmit_Click(sender As Object, e As EventArgs) Handles SBSubmit.Click
        Dim confirm As DialogResult

        confirm = DevExpress.XtraEditors.XtraMessageBox.Show("All data will be locked. Are you sure want to submit ?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)

        If confirm = Windows.Forms.DialogResult.Yes Then
            Dim period_from As String = Date.Parse(DEDateFrom.EditValue.ToString).ToString("yyyy-MM-dd")
            Dim period_to As String = Date.Parse(DEDateTo.EditValue.ToString).ToString("yyyy-MM-dd")

            Dim query As String = "INSERT INTO tb_tax_pph_summary (period_from, period_to, id_report_status, created_at, created_by) VALUES ('" + period_from + "', '" + period_to + "', 1, NOW(), " + id_employee_user + "); SELECT LAST_INSERT_ID();"

            id_summary = execute_query(query, 0, True, "", "", "", "")

            Dim query_detail As String = "INSERT INTO tb_tax_pph_summary_det (id_summary, tag_description, id_tax_report, tax_report, balance) VALUES "

            For i = 0 To GVSummary.RowCount - 1
                If GVSummary.IsValidRowHandle(i) Then
                    query_detail = query_detail + "(" + id_summary + ", '" + GVSummary.GetRowCellValue(i, "tag_description").ToString + "', '" + GVSummary.GetRowCellValue(i, "id_tax_report").ToString + "', '" + GVSummary.GetRowCellValue(i, "tax_report").ToString + "', '" + GVSummary.GetRowCellValue(i, "balance").ToString + "'), "
                End If
            Next

            query_detail = query_detail.Substring(0, query_detail.Length - 2)

            execute_non_query(query_detail, True, "", "", "", "")

            execute_non_query("UPDATE tb_tax_pph_summary SET `number` = CONCAT('SUMPPH', LPAD(" + id_summary + ", 7, '0'))  WHERE id_summary = " + id_summary + ";", True, "", "", "", "")

            submit_who_prepared("284", id_summary, id_user)

            infoCustom("Saved.")

            form_load()
        End If
    End Sub

    Sub form_load()
        TENumber.EditValue = "[autogenerate]"

        DEDateFrom.EditValue = Now
        DEDateTo.EditValue = Now

        TECreatedBy.EditValue = get_emp(id_employee_user, "2")
        TECreatedAt.EditValue = DateTime.Parse(execute_query("SELECT NOW()", 0, True, "", "", "", "")).ToString("dd MMMM yyyy HH:mm:ss")
        SLUEReportStatus.EditValue = "0"

        If Not id_summary = "-1" Then
            Dim query As String = "
                SELECT s.number, DATE_FORMAT(s.period_from, '%d %M %Y') AS period_from, DATE_FORMAT(s.period_to, '%d %M %Y') AS period_to, s.id_report_status, e.employee_name AS created_by, DATE_FORMAT(s.created_at, '%d %M %Y %H:%i:%s') AS created_at
                FROM tb_tax_pph_summary AS s
                LEFT JOIN tb_m_employee AS e ON s.created_by = e.id_employee
                WHERE s.id_summary = " + id_summary + "
            "

            Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")

            TENumber.EditValue = data.Rows(0)("number").ToString
            DEDateFrom.EditValue = data.Rows(0)("period_from").ToString
            DEDateTo.EditValue = data.Rows(0)("period_to").ToString
            TECreatedBy.EditValue = data.Rows(0)("created_by").ToString
            TECreatedAt.EditValue = data.Rows(0)("created_at").ToString
            SLUEReportStatus.EditValue = data.Rows(0)("id_report_status").ToString

            Dim query_detail As String = "
                SELECT 0 AS `no`, tag_description, id_tax_report, tax_report, balance
                FROM tb_tax_pph_summary_det
                WHERE id_summary = " + id_summary + "
            "

            Dim data_detail As DataTable = execute_query(query_detail, -1, True, "", "", "", "")

            'numbering
            Dim last_tag_description As String = "0"

            Dim no As Integer = 0

            For i = 0 To data_detail.Rows.Count - 1
                If Not data_detail.Rows(i)("tag_description").ToString = last_tag_description Then
                    no = 0
                End If

                no = no + 1

                data_detail.Rows(i)("no") = no

                last_tag_description = data_detail.Rows(i)("tag_description").ToString
            Next

            GCSummary.DataSource = data_detail
        End If

        'controls
        If SLUEReportStatus.EditValue.ToString = "0" Then
            SBPrint.Visible = False
            SBMark.Visible = False
            SBSubmit.Visible = True

            DEDateFrom.ReadOnly = False
            DEDateTo.ReadOnly = False
            SBGenerateSummary.Enabled = True
        Else
            SBPrint.Visible = True
            SBMark.Visible = True
            SBSubmit.Visible = False

            DEDateFrom.ReadOnly = True
            DEDateTo.ReadOnly = True
            SBGenerateSummary.Enabled = False
        End If
    End Sub

    Private Sub SBPrint_Click(sender As Object, e As EventArgs) Handles SBPrint.Click
        Dim report As New ReportBalanceTaxSummary()

        report.id_summary = id_summary
        report.data = GCSummary.DataSource
        report.id_pre = If(SLUEReportStatus.EditValue.ToString = "6", "-1", "1")

        report.XLNumber.Text = TENumber.Text
        report.XLPeriod.Text = report.XLPeriod.Text.Replace("[period_from]", DEDateFrom.Text)
        report.XLPeriod.Text = report.XLPeriod.Text.Replace("[period_to]", DEDateTo.Text)

        Dim tool As DevExpress.XtraReports.UI.ReportPrintTool = New DevExpress.XtraReports.UI.ReportPrintTool(report)

        tool.ShowPreviewDialog()
    End Sub
End Class