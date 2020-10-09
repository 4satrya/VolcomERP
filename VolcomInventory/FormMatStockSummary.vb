Public Class FormMatStockSummary
    Public id_mat_summary As String = "-1"

    Private id_report_status As String = "-1"

    Private Sub FormMatStockSummary_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'header
        Dim query As String = "
            (SELECT s.number, s.start_period, s.end_period, s.created_date, e.employee_name AS created_by, s.id_report_status, r.report_status
            FROM tb_mat_summary AS s
            LEFT JOIN tb_m_employee AS e ON s.created_by = e.id_employee
            LEFT JOIN tb_lookup_report_status AS r ON s.id_report_status = r.id_report_status
            WHERE s.id_mat_summary = " + id_mat_summary + ")

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
            SELECT 0 AS no, d.id_mat_cat, c.mat_cat, d.qty_beg, d.amount_beg, d.qty_receive, d.amount_receive, d.qty_mrs, d.amount_mrs, d.qty_retur, d.amount_retur, d.qty_adj, d.amount_adj, d.qty_ending, d.amount_ending
            FROM tb_mat_summary_det AS d
            LEFT JOIN tb_m_mat_cat AS c ON d.id_mat_cat = c.id_mat_cat
            WHERE d.id_mat_summary = " + id_mat_summary + "
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
            SBAttachment.Enabled = False

            DEStartPeriod.ReadOnly = False
            DEEndPeriod.ReadOnly = False

            SBGenerateSummary.Enabled = True
        Else
            SBSubmit.Enabled = False
            SBPrint.Enabled = True
            SBMark.Enabled = True
            SBAttachment.Enabled = True

            DEStartPeriod.ReadOnly = True
            DEEndPeriod.ReadOnly = True

            SBGenerateSummary.Enabled = False
        End If
    End Sub

    Private Sub FormMatStockSummary_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        FormMatStock.view_stock_summary()

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

        Dim material As DataTable = execute_query("SELECT id_mat_cat, mat_cat FROM tb_m_mat_cat", -1, True, "", "", "", "")

        Dim data_stock As DataTable = execute_query("CALL view_stock_report_mat('" + Date.Parse(DEStartPeriod.EditValue.ToString).ToString("yyyy-MM-dd") + "', '" + Date.Parse(DEEndPeriod.EditValue.ToString).ToString("yyyy-MM-dd") + "')", -1, True, "", "", "", "")

        Dim data As DataTable = CType(GridControlSummary.DataSource, DataTable).Clone

        For i = 0 To material.Rows.Count - 1
            Dim row As DataRow = data.NewRow

            row("no") = i + 1
            row("id_mat_cat") = material.Rows(i)("id_mat_cat").ToString
            row("mat_cat") = material.Rows(i)("mat_cat").ToString
            row("qty_beg") = 0.00
            row("amount_beg") = 0.00
            row("qty_receive") = 0.00
            row("amount_receive") = 0.00
            row("qty_mrs") = 0.00
            row("amount_mrs") = 0.00
            row("qty_retur") = 0.00
            row("amount_retur") = 0.00
            row("qty_adj") = 0.00
            row("amount_adj") = 0.00
            row("qty_ending") = 0.00
            row("amount_ending") = 0.00

            Dim dv_filter As DataView = New DataView(data_stock)

            dv_filter.RowFilter = "id_mat_cat = " + material.Rows(i)("id_mat_cat").ToString + ""

            For j = 0 To dv_filter.Count - 1
                row("qty_beg") += dv_filter(j)("qty_beg")
                row("amount_beg") += dv_filter(j)("amount_beg")
                row("qty_receive") += dv_filter(j)("qty_receive")
                row("amount_receive") += dv_filter(j)("amount_receive")
                row("qty_mrs") += dv_filter(j)("qty_mrs")
                row("amount_mrs") += dv_filter(j)("amount_mrs")
                row("qty_retur") += dv_filter(j)("qty_retur")
                row("amount_retur") += dv_filter(j)("amount_retur")
                row("qty_adj") += dv_filter(j)("qty_adj")
                row("amount_adj") += dv_filter(j)("amount_adj")
                row("qty_ending") += dv_filter(j)("qty_ending")
                row("amount_ending") += dv_filter(j)("amount_ending")
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
                Dim query As String = "INSERT INTO tb_mat_summary (start_period, end_period, created_date, created_by, id_report_status) VALUES ('" + Date.Parse(DEStartPeriod.EditValue.ToString).ToString("yyyy-MM-dd") + "', '" + Date.Parse(DEEndPeriod.EditValue.ToString).ToString("yyyy-MM-dd") + "', NOW(), " + id_employee_user + ", 1); SELECT LAST_INSERT_ID();"

                id_mat_summary = execute_query(query, 0, True, "", "", "", "")

                'detail
                For i = 0 To BandedGridViewSummary.RowCount - 1
                    Dim query_detail As String = "INSERT INTO tb_mat_summary_det (id_mat_summary, id_mat_cat, qty_beg, amount_beg, qty_receive, amount_receive, qty_mrs, amount_mrs, qty_retur, amount_retur, qty_adj, amount_adj, qty_ending, amount_ending) VALUES (" + id_mat_summary + ", " + BandedGridViewSummary.GetRowCellValue(i, "id_mat_cat").ToString + ", " + decimalSQL(BandedGridViewSummary.GetRowCellValue(i, "qty_beg").ToString) + ", " + decimalSQL(BandedGridViewSummary.GetRowCellValue(i, "amount_beg").ToString) + ", " + decimalSQL(BandedGridViewSummary.GetRowCellValue(i, "qty_receive").ToString) + ", " + decimalSQL(BandedGridViewSummary.GetRowCellValue(i, "amount_receive").ToString) + ", " + decimalSQL(BandedGridViewSummary.GetRowCellValue(i, "qty_mrs").ToString) + ", " + decimalSQL(BandedGridViewSummary.GetRowCellValue(i, "amount_mrs").ToString) + ", " + decimalSQL(BandedGridViewSummary.GetRowCellValue(i, "qty_retur").ToString) + ", " + decimalSQL(BandedGridViewSummary.GetRowCellValue(i, "amount_retur").ToString) + ", " + decimalSQL(BandedGridViewSummary.GetRowCellValue(i, "qty_adj").ToString) + ", " + decimalSQL(BandedGridViewSummary.GetRowCellValue(i, "amount_adj").ToString) + ", " + decimalSQL(BandedGridViewSummary.GetRowCellValue(i, "qty_ending").ToString) + ", " + decimalSQL(BandedGridViewSummary.GetRowCellValue(i, "amount_ending").ToString) + ")"

                    execute_non_query(query_detail, True, "", "", "", "")
                Next

                submit_who_prepared("269", id_mat_summary, id_user)

                execute_non_query("CALL gen_number(" + id_mat_summary + ", '269')", True, "", "", "", "")

                infoCustom("Material & Trims - Stock Summary Report submitted.")

                Close()
            End If
        Else
            errorCustom("Empty stock summary.")
        End If
    End Sub

    Private Sub SBPrint_Click(sender As Object, e As EventArgs) Handles SBPrint.Click
        Dim report As ReportMatStockSummary = New ReportMatStockSummary

        report.XLNumber.Text = TENumber.Text
        report.XLStartPeriod.Text = DEStartPeriod.Text
        report.XLEndPeriod.Text = DEEndPeriod.Text
        report.XLCreatedDate.Text = DECreatedDate.Text
        report.XLCreatedBy.Text = TECreatedBy.Text

        report.id_mat_summary = id_mat_summary
        report.data = GridControlSummary.DataSource

        Dim tool As DevExpress.XtraReports.UI.ReportPrintTool = New DevExpress.XtraReports.UI.ReportPrintTool(report)

        tool.ShowPreviewDialog()
    End Sub

    Private Sub SBMark_Click(sender As Object, e As EventArgs) Handles SBMark.Click
        Cursor = Cursors.WaitCursor

        FormReportMark.report_mark_type = "269"
        FormReportMark.id_report = id_mat_summary

        FormReportMark.ShowDialog()

        Cursor = Cursors.Default
    End Sub

    Private Sub SBGenerateSummary_Click(sender As Object, e As EventArgs) Handles SBGenerateSummary.Click
        generate_summary()
    End Sub

    Sub reset_detail()
        Dim query As String = "
            SELECT 0 AS no, d.id_mat_cat, c.mat_cat, d.qty_beg, d.amount_beg, d.qty_receive, d.amount_receive, d.qty_mrs, d.amount_mrs, d.qty_retur, d.amount_retur, d.qty_adj, d.amount_adj, d.qty_ending, d.amount_ending
            FROM tb_mat_summary_det AS d
            LEFT JOIN tb_m_mat_cat AS c ON d.id_mat_cat = c.id_mat_cat
            WHERE d.id_mat_summary = 0
        "

        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")

        GridControlSummary.DataSource = data
    End Sub

    Private Sub SBAttachment_Click(sender As Object, e As EventArgs) Handles SBAttachment.Click
        FormDocumentUpload.is_no_delete = "1"
        FormDocumentUpload.id_report = id_mat_summary
        FormDocumentUpload.report_mark_type = "269"
        FormDocumentUpload.ShowDialog()
    End Sub
End Class