Public Class FormStockQCStockReportSummary
    Public id_wip_summary As String = "-1"

    Private id_report_status As String = "-1"

    Private Sub FormStockQCStockReportSummary_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'header
        Dim query As String = "
            (SELECT s.number, s.start_period, s.end_period, s.created_date, e.employee_name AS created_by, s.id_report_status, r.report_status
            FROM tb_wip_summary AS s
            LEFT JOIN tb_m_employee AS e ON s.created_by = e.id_employee
            LEFT JOIN tb_lookup_report_status AS r ON s.id_report_status = r.id_report_status
            WHERE s.id_wip_summary = " + id_wip_summary + ")

            UNION ALL

            -- default value
            (SELECT '[autogenerate]' AS number, DATE_FORMAT(NOW(), '%Y-%m-01') AS start_period, LAST_DAY(NOW()) AS end_period, NOW() AS created_date, '" + get_emp(id_employee_user, "2") + "' AS created_by, '-1' AS id_report_status, '' AS report_status)
        "

        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")

        TENumber.EditValue = data.Rows(0)("number").ToString
        DEStartPeriod.EditValue = data.Rows(0)("start_period")
        DEEndPeriod.EditValue = data.Rows(0)("end_period")
        DECreatedDate.EditValue = data.Rows(0)("created_date")
        TECreatedBy.EditValue = data.Rows(0)("created_by").ToString
        TEReportStatus.EditValue = data.Rows(0)("report_status").ToString

        id_report_status = data.Rows(0)("id_report_status").ToString

        'detail
        Dim query_detail As String = "
            SELECT 0 AS no, d.id_cop_status, c.cop_status, d.qty_beg, d.qty_rec, d.qty_pis, d.qty_retur_sup, d.qty_retur_wh, d.qty_adj, d.qty_rjk, d.qty_end, d.amount
            FROM tb_wip_summary_det AS d
            LEFT JOIN tb_lookup_cop_status AS c ON d.id_cop_status = c.id_cop_status
            WHERE d.id_wip_summary = " + id_wip_summary + "
        "

        Dim data_detail As DataTable = execute_query(query_detail, -1, True, "", "", "", "")

        'number
        For i = 0 To data_detail.Rows.Count - 1
            data_detail.Rows(i)("no") = i + 1
        Next

        GridControlSummary.DataSource = data_detail

        'controls
        If id_report_status = "-1" Then
            SBSubmit.Enabled = True
            SBPrint.Enabled = False
            SBMark.Enabled = False

            DEStartPeriod.ReadOnly = False
            DEEndPeriod.ReadOnly = False

            SBGenerateSummary.Enabled = True
        Else
            SBSubmit.Enabled = False
            SBPrint.Enabled = True
            SBMark.Enabled = True

            DEStartPeriod.ReadOnly = True
            DEEndPeriod.ReadOnly = True

            SBGenerateSummary.Enabled = False
        End If
    End Sub

    Private Sub FormStockQCStockReportSummary_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        FormStockQC.view_stock_summary()

        Dispose()
    End Sub

    Private Sub SBClose_Click(sender As Object, e As EventArgs) Handles SBClose.Click
        Close()
    End Sub

    Private Sub DEStartPeriod_EditValueChanged(sender As Object, e As EventArgs) Handles DEStartPeriod.EditValueChanged
        If Not DEStartPeriod.EditValue.ToString = "" Then
            DEEndPeriod.Properties.MinValue = DEStartPeriod.EditValue
        End If

        reset_detail()
    End Sub

    Private Sub DEEndPeriod_EditValueChanged(sender As Object, e As EventArgs) Handles DEEndPeriod.EditValueChanged
        reset_detail()
    End Sub

    Sub generate_summary()
        Cursor = Cursors.WaitCursor

        Dim cop_status As DataTable = execute_query("SELECT id_cop_status, cop_status FROM tb_lookup_cop_status", -1, True, "", "", "", "")

        Dim data As DataTable = CType(GridControlSummary.DataSource, DataTable).Clone

        For i = 0 To cop_status.Rows.Count - 1
            Dim data_stock As DataTable = execute_query("CALL view_stock_summary_qc('" + Date.Parse(DEStartPeriod.EditValue.ToString).ToString("yyyy-MM-dd") + "', '" + Date.Parse(DEEndPeriod.EditValue.ToString).ToString("yyyy-MM-dd") + "', '" + cop_status.Rows(i)("id_cop_status").ToString + "')", -1, True, "", "", "", "")

            Dim row As DataRow = data.NewRow

            row("no") = i + 1
            row("id_cop_status") = cop_status.Rows(i)("id_cop_status").ToString
            row("cop_status") = cop_status.Rows(i)("cop_status").ToString
            row("qty_beg") = 0.00
            row("qty_rec") = 0.00
            row("qty_pis") = 0.00
            row("qty_retur_sup") = 0.00
            row("qty_retur_wh") = 0.00
            row("qty_adj") = 0.00
            row("qty_rjk") = 0.00
            row("qty_end") = 0.00
            row("amount") = 0.00

            For j = 0 To data_stock.Rows.Count - 1
                row("qty_beg") += data_stock.Rows(j)("qty_beg")
                row("qty_rec") += data_stock.Rows(j)("qty_rec")
                row("qty_pis") += data_stock.Rows(j)("qty_pis")
                row("qty_retur_sup") += data_stock.Rows(j)("qty_retur_sup")
                row("qty_retur_wh") += data_stock.Rows(j)("qty_retur_wh")
                row("qty_adj") += data_stock.Rows(j)("qty_adj")
                row("qty_rjk") += data_stock.Rows(j)("qty_rjk")
                row("qty_end") += data_stock.Rows(j)("qty_end")
                row("amount") += data_stock.Rows(j)("amount")
            Next

            data.Rows.Add(row)
        Next

        GridControlSummary.DataSource = data

        Cursor = Cursors.Default
    End Sub

    Private Sub SBSubmit_Click(sender As Object, e As EventArgs) Handles SBSubmit.Click
        If BandedGridViewSummary.RowCount > 0 Then
            Dim confirm As DialogResult = DevExpress.XtraEditors.XtraMessageBox.Show("Are you sure want to submit ?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)

            If confirm = DialogResult.Yes Then
                'header
                Dim query As String = "INSERT INTO tb_wip_summary (start_period, end_period, created_date, created_by, id_report_status) VALUES ('" + Date.Parse(DEStartPeriod.EditValue.ToString).ToString("yyyy-MM-dd") + "', '" + Date.Parse(DEEndPeriod.EditValue.ToString).ToString("yyyy-MM-dd") + "', NOW(), " + id_employee_user + ", 1); SELECT LAST_INSERT_ID();"

                id_wip_summary = execute_query(query, 0, True, "", "", "", "")

                'detail
                For i = 0 To BandedGridViewSummary.RowCount - 1
                    Dim query_detail As String = "INSERT INTO tb_wip_summary_det (id_wip_summary, id_cop_status, qty_beg, qty_rec, qty_pis, qty_retur_sup, qty_retur_wh, qty_adj, qty_rjk, qty_end, amount) VALUES (" + id_wip_summary + ", " + BandedGridViewSummary.GetRowCellValue(i, "id_cop_status").ToString + ", " + decimalSQL(BandedGridViewSummary.GetRowCellValue(i, "qty_beg").ToString) + ", " + decimalSQL(BandedGridViewSummary.GetRowCellValue(i, "qty_rec").ToString) + ", " + decimalSQL(BandedGridViewSummary.GetRowCellValue(i, "qty_pis").ToString) + ", " + decimalSQL(BandedGridViewSummary.GetRowCellValue(i, "qty_retur_sup").ToString) + ", " + decimalSQL(BandedGridViewSummary.GetRowCellValue(i, "qty_retur_wh").ToString) + ", " + decimalSQL(BandedGridViewSummary.GetRowCellValue(i, "qty_adj").ToString) + ", " + decimalSQL(BandedGridViewSummary.GetRowCellValue(i, "qty_rjk").ToString) + ", " + decimalSQL(BandedGridViewSummary.GetRowCellValue(i, "qty_end").ToString) + ", " + decimalSQL(BandedGridViewSummary.GetRowCellValue(i, "amount").ToString) + ")"

                    execute_non_query(query_detail, True, "", "", "", "")
                Next

                submit_who_prepared("268", id_wip_summary, id_user)

                execute_non_query("CALL gen_number(" + id_wip_summary + ", '268')", True, "", "", "", "")

                infoCustom("WIP - Stock Summary Report submitted.")

                Close()
            End If
        Else
            errorCustom("Empty stock summary.")
        End If
    End Sub

    Private Sub SBPrint_Click(sender As Object, e As EventArgs) Handles SBPrint.Click
        Dim report As ReportStockQCStockReportSummary = New ReportStockQCStockReportSummary

        report.XLNumber.Text = TENumber.Text
        report.XLStartPeriod.Text = DEStartPeriod.Text
        report.XLEndPeriod.Text = DEEndPeriod.Text
        report.XLCreatedDate.Text = DECreatedDate.Text
        report.XLCreatedBy.Text = TECreatedBy.Text

        report.id_wip_summary = id_wip_summary
        report.data = GridControlSummary.DataSource

        Dim tool As DevExpress.XtraReports.UI.ReportPrintTool = New DevExpress.XtraReports.UI.ReportPrintTool(report)

        tool.ShowPreviewDialog()
    End Sub

    Private Sub SBMark_Click(sender As Object, e As EventArgs) Handles SBMark.Click
        Cursor = Cursors.WaitCursor

        FormReportMark.report_mark_type = "268"
        FormReportMark.id_report = id_wip_summary

        FormReportMark.ShowDialog()

        Cursor = Cursors.Default
    End Sub

    Private Sub SBGenerateSummary_Click(sender As Object, e As EventArgs) Handles SBGenerateSummary.Click
        generate_summary()
    End Sub

    Sub reset_detail()
        Dim query As String = "
            SELECT 0 AS no, d.id_cop_status, c.cop_status, d.qty_beg, d.qty_rec, d.qty_pis, d.qty_retur_sup, d.qty_retur_wh, d.qty_adj, d.qty_rjk, d.qty_end, d.amount
            FROM tb_wip_summary_det AS d
            LEFT JOIN tb_lookup_cop_status AS c ON d.id_cop_status = c.id_cop_status
            WHERE d.id_wip_summary = 0
        "

        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")

        GridControlSummary.DataSource = Data
    End Sub
End Class