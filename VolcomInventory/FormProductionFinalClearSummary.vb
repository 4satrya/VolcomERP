Public Class FormProductionFinalClearSummary
    Public id_prod_fc_sum As String = "0"
    Public is_vew As String = "0"

    Private id_report_status As String = "-1"

    Private Sub FormProductionFinalClearSummary_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If id_prod_fc_sum = "0" Then
            load_default()
        Else
            load_form()
        End If
    End Sub

    Private Sub FormProductionFinalClearSummary_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()

        Try
            If Not id_prod_fc_sum = "0" Then
                FormProductionFinalClear.viewSummaryPropose()

                FormProductionFinalClear.GVSum.FocusedRowHandle = find_row(FormProductionFinalClear.GVSum, "id_prod_fc_sum", id_prod_fc_sum)
            End If
        Catch ex As Exception
        End Try
    End Sub

    Sub load_default()
        TENumber.EditValue = "[autogenerate]"
        TECreatedBy.EditValue = get_emp(id_user, "3")
        DECreatedDate.EditValue = Now
        TEUpdatedBy.EditValue = ""
        DEUpdatedDate.EditValue = Nothing
        id_report_status = "-1"
        TEReportStatus.EditValue = ""

        Dim data As DataTable = New DataTable

        data.Columns.Add("id_prod_fc", GetType(String))
        data.Columns.Add("no", GetType(Integer))
        data.Columns.Add("vendor", GetType(String))
        data.Columns.Add("name", GetType(String))
        data.Columns.Add("prod_fc_number", GetType(String))
        data.Columns.Add("pl_category", GetType(String))
        data.Columns.Add("qty_po", GetType(Decimal))
        data.Columns.Add("qty_rec", GetType(Decimal))
        data.Columns.Add("prod_fc_date", GetType(String))

        GCList.DataSource = data

        'controls
        SBAdd.Enabled = True
        SBRemove.Enabled = True
        SBSubmit.Enabled = True
        SBSave.Enabled = True
        SBAttachment.Enabled = False
        SBReset.Enabled = False
        SBPrint.Enabled = False
        SBMark.Enabled = False
    End Sub

    Sub load_form()
        'form
        Dim query As String = "
            SELECT fc_sum.*, IF(fc_sum.id_report_status = 0, 'Draft', sts.report_status) AS report_status
            FROM tb_prod_fc_sum AS fc_sum 
            LEFT JOIN tb_lookup_report_status AS sts ON fc_sum.id_report_status = sts.id_report_status
            WHERE fc_sum.id_prod_fc_sum = " + id_prod_fc_sum + "
        "

        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")

        TENumber.EditValue = data.Rows(0)("number").ToString
        TECreatedBy.EditValue = get_emp(data.Rows(0)("created_by").ToString, "3")
        DECreatedDate.EditValue = data.Rows(0)("created_date")
        TEUpdatedBy.EditValue = If(data.Rows(0)("updated_by").ToString = "", "", get_emp(data.Rows(0)("updated_by").ToString, "3"))
        DEUpdatedDate.EditValue = If(data.Rows(0)("updated_date").ToString = "", Nothing, data.Rows(0)("updated_date"))
        id_report_status = data.Rows(0)("id_report_status")
        TEReportStatus.EditValue = data.Rows(0)("report_status").ToString

        'detail
        Dim query_detail As String = "
            SELECT fc_sum_det.id_prod_fc, 0 AS no, comp.comp_name AS vendor, d.design_display_name AS name, fc.prod_fc_number, cat.pl_category, fc_sum_det.qty_po, fc_sum_det.qty_rec, DATE_FORMAT(fc.prod_fc_date, '%d %b %Y') AS prod_fc_date
            FROM tb_prod_fc_sum_det AS fc_sum_det
            LEFT JOIN tb_prod_fc AS fc ON fc_sum_det.id_prod_fc = fc.id_prod_fc
            LEFT JOIN tb_lookup_pl_category AS cat ON fc.id_pl_category = cat.id_pl_category
            LEFT JOIN tb_prod_order AS po ON fc.id_prod_order = po.id_prod_order
            LEFT JOIN tb_prod_demand_design pdd ON pdd.id_prod_demand_design = po.id_prod_demand_design
            LEFT JOIN tb_m_design d ON d.id_design = pdd.id_design
            LEFT JOIN tb_prod_order_wo AS wo ON wo.id_prod_order = po.id_prod_order AND wo.is_main_vendor = 1
            LEFT JOIN tb_m_ovh_price AS ovh ON ovh.id_ovh_price = wo.id_ovh_price
            LEFT JOIN tb_m_comp_contact AS cc ON cc.id_comp_contact = ovh.id_comp_contact 
            LEFT JOIN tb_m_comp AS comp ON comp.id_comp = cc.id_comp
            WHERE fc_sum_det.id_prod_fc_sum = " + id_prod_fc_sum + "
        "

        Dim data_detail As DataTable = execute_query(query_detail, -1, True, "", "", "", "")

        GCList.DataSource = data_detail

        GVList.BestFitColumns()

        'controls
        If id_report_status = "0" Then
            SBAdd.Enabled = True
            SBRemove.Enabled = True
            SBSubmit.Enabled = True
            SBSave.Enabled = True
            SBAttachment.Enabled = True
            SBReset.Enabled = False
            SBPrint.Enabled = False
            SBMark.Enabled = False
        Else
            SBAdd.Enabled = False
            SBRemove.Enabled = False
            SBSubmit.Enabled = False
            SBSave.Enabled = False
            SBAttachment.Enabled = True
            SBReset.Enabled = True
            SBPrint.Enabled = False
            SBMark.Enabled = True
        End If

        If id_report_status = "5" Or id_report_status = "6" Then
            SBReset.Enabled = False
        End If

        If is_vew = "1" Then
            SBReset.Visible = False
        End If
    End Sub

    Private Sub SBAdd_Click(sender As Object, e As EventArgs) Handles SBAdd.Click
        FormProductionFinalClearSummaryPick.ShowDialog()
    End Sub

    Private Sub SBRemove_Click(sender As Object, e As EventArgs) Handles SBRemove.Click
        GVList.DeleteSelectedRows()
    End Sub

    Private Sub SBSubmit_Click(sender As Object, e As EventArgs) Handles SBSubmit.Click
        If GVList.RowCount <= 0 Then
            errorCustom("No qc report selected")
        Else
            Dim confirm As DialogResult

            confirm = DevExpress.XtraEditors.XtraMessageBox.Show("All data will be locked. Are you sure want to submit ?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)

            If confirm = Windows.Forms.DialogResult.Yes Then
                save("submit")

                Close()
            End If
        End If
    End Sub

    Private Sub SBSave_Click(sender As Object, e As EventArgs) Handles SBSave.Click
        save("draft")

        infoCustom("Data successfully saved")

        load_form()
    End Sub

    Private Sub SBAttachment_Click(sender As Object, e As EventArgs) Handles SBAttachment.Click
        Cursor = Cursors.WaitCursor

        FormDocumentUpload.is_no_delete = If(Not id_report_status = "0", "1", "-1")
        FormDocumentUpload.is_view = If(Not id_report_status = "0", "1", "-1")
        FormDocumentUpload.id_report = id_prod_fc_sum
        FormDocumentUpload.report_mark_type = "222"

        FormDocumentUpload.ShowDialog()

        Cursor = Cursors.Default
    End Sub

    Sub save(type As String)
        Dim query As String = ""

        Dim id_report_status As String = If(type = "submit", "1", "0")

        'tb_prod_fc_sum
        If id_prod_fc_sum = "0" Then
            query = "INSERT INTO tb_prod_fc_sum (created_date, created_by, id_report_status) VALUES (NOW(), " + id_user + ", " + id_report_status + "); SELECT LAST_INSERT_ID();"

            id_prod_fc_sum = execute_query(query, 0, True, "", "", "", "")

            'number
            Dim month_year As DataTable = execute_query("SELECT (SELECT `code` FROM `tb_ot_memo_number_mon` WHERE `month` = DATE_FORMAT(NOW(), '%c')) AS `month`, (SELECT DATE_FORMAT(NOW(), '%Y')) AS `year`", -1, True, "", "", "", "")

            Dim number As String = id_prod_fc_sum + "/QC-PROD/QR/" + month_year.Rows(0)("month").ToString + "/" + month_year.Rows(0)("year").ToString

            query = "UPDATE tb_prod_fc_sum SET number = '" + number + "' WHERE id_prod_fc_sum = " + id_prod_fc_sum

            execute_non_query(query, True, "", "", "", "")
        Else
            query = "UPDATE tb_prod_fc_sum SET updated_date = NOW(), updated_by = " + id_user + ", id_report_status = " + id_report_status + " WHERE id_prod_fc_sum = " + id_prod_fc_sum

            execute_non_query(query, True, "", "", "", "")
        End If

        'tb_prod_fc_sum_det
        execute_non_query("DELETE FROM tb_prod_fc_sum_det WHERE id_prod_fc_sum = " + id_prod_fc_sum, True, "", "", "", "")

        query = "INSERT INTO tb_prod_fc_sum_det (id_prod_fc_sum, id_prod_fc, qty_po, qty_rec) VALUES "

        For i = 0 To GVList.RowCount - 1
            If GVList.IsValidRowHandle(i) Then
                query += "(" + id_prod_fc_sum + ", " + GVList.GetRowCellValue(i, "id_prod_fc").ToString + ", " + decimalSQL(GVList.GetRowCellValue(i, "qty_po").ToString) + ", " + decimalSQL(GVList.GetRowCellValue(i, "qty_rec").ToString) + "), "
            End If
        Next

        query = query.Substring(0, query.Length - 2)

        execute_non_query(query, True, "", "", "", "")

        'submit
        If type = "submit" Then
            submit_who_prepared("222", id_prod_fc_sum, id_user)
        End If
    End Sub

    Private Sub GVList_RowCountChanged(sender As Object, e As EventArgs) Handles GVList.RowCountChanged
        For i = 0 To GVList.RowCount - 1
            If GVList.IsValidRowHandle(i) Then
                GVList.SetRowCellValue(i, "no", i + 1)
            End If
        Next
    End Sub

    Sub view_summary()
        Cursor = Cursors.WaitCursor

        Dim include As String = "0"

        For i = 0 To GVList.RowCount - 1
            If GVList.IsValidRowHandle(i) Then
                include += ", " + GVList.GetRowCellValue(i, "id_prod_fc").ToString
            End If
        Next

        Dim query As String = "
            SELECT 0 AS no, fc.prod_fc_number, po.prod_order_number, comp.comp_name AS vendor, d.design_display_name AS name, rg.range, color.color, qc_report.normal, qc_report.minor, qc_report.major, qc_report.afkir, qty_po.qty_po, qty_rec.qty_rec, fc.prod_fc_date
            FROM tb_prod_order AS po
            LEFT JOIN tb_prod_demand_design pdd ON pdd.id_prod_demand_design = po.id_prod_demand_design
            LEFT JOIN tb_m_design d ON d.id_design = pdd.id_design
            LEFT JOIN (
                SELECT dc_col.id_design, col.display_name AS color
                FROM tb_m_design_code AS dc_col
                LEFT JOIN tb_m_code_detail AS col ON dc_col.id_code_detail = col.id_code_detail
                WHERE col.id_code = 14
            ) color ON d.id_design = color.id_design
            LEFT JOIN tb_season_delivery del ON del.id_delivery = po.id_delivery
            LEFT JOIN tb_season ss ON ss.id_season = del.id_season
            LEFT JOIN tb_range rg ON rg.id_range = ss.id_range
            LEFT JOIN tb_prod_order_wo wo ON wo.id_prod_order = po.id_prod_order AND wo.is_main_vendor=1
            LEFT JOIN tb_m_ovh_price ovh ON ovh.id_ovh_price = wo.id_ovh_price
            LEFT JOIN tb_m_comp_contact cc ON cc.id_comp_contact = ovh.id_comp_contact 
            LEFT JOIN tb_m_comp comp ON comp.id_comp = cc.id_comp
            LEFT JOIN (
	            SELECT fc.id_prod_order, SUM(IF(fc.id_pl_category = 1, fc_det.prod_fc_det_qty, 0)) AS normal, SUM(IF(fc.id_pl_category = 2, fc_det.prod_fc_det_qty, 0)) AS minor, SUM(IF(fc.id_pl_category = 3, fc_det.prod_fc_det_qty, 0)) AS major, SUM(IF(fc.id_pl_category = 4, fc_det.prod_fc_det_qty, 0)) AS afkir
	            FROM tb_prod_fc_det AS fc_det
	            LEFT JOIN tb_prod_fc AS fc ON fc_det.id_prod_fc = fc.id_prod_fc
	            WHERE fc.id_report_status = 6
	            GROUP BY fc.id_prod_order
            ) AS qc_report ON po.id_prod_order = qc_report.id_prod_order
            LEFT JOIN (
	            SELECT po_det.id_prod_order, SUM(po_det.prod_order_qty) AS qty_po
	            FROM tb_prod_order_det AS po_det
	            LEFT JOIN tb_prod_order AS po ON po_det.id_prod_order = po.id_prod_order
	            WHERE po.id_report_status = 6
	            GROUP BY po_det.id_prod_order
            ) AS qty_po ON po.id_prod_order = qty_po.id_prod_order
            LEFT JOIN (
	            SELECT rec.id_prod_order, SUM(rec_det.prod_order_rec_det_qty) AS qty_rec
	            FROM tb_prod_order_rec_det AS rec_det
	            LEFT JOIN tb_prod_order_rec AS rec ON rec_det.id_prod_order_rec = rec.id_prod_order_rec
	            WHERE rec.id_report_status = 6
	            GROUP BY rec.id_prod_order
            ) AS qty_rec ON po.id_prod_order = qty_rec.id_prod_order
            LEFT JOIN (
                SELECT id_prod_order, GROUP_CONCAT(DISTINCT prod_fc_number ORDER BY prod_fc_number ASC SEPARATOR ', ') AS prod_fc_number, GROUP_CONCAT(DISTINCT DATE_FORMAT(prod_fc_date, '%d %b %Y') ORDER BY prod_fc_date ASC SEPARATOR ', ') AS prod_fc_date
                FROM tb_prod_fc
                WHERE id_prod_fc IN (" + include + ")
                GROUP BY id_prod_order
            ) AS fc ON po.id_prod_order = fc.id_prod_order
            WHERE po.id_prod_order IN (SELECT id_prod_order FROM tb_prod_fc WHERE id_prod_fc IN (" + include + "))
            GROUP BY po.id_prod_order
        "

        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")

        GCSummary.DataSource = data

        GVSummary.BestFitColumns()

        Cursor = Cursors.Default
    End Sub

    Private Sub XtraTabControl_SelectedPageChanged(sender As Object, e As DevExpress.XtraTab.TabPageChangedEventArgs) Handles XtraTabControl.SelectedPageChanged
        If XtraTabControl.SelectedTabPageIndex = 1 Then
            view_summary()

            If id_report_status = "0" Or id_report_status = "-1" Then
                SBPrint.Enabled = False
            Else
                SBPrint.Enabled = True
            End If
        Else
            SBPrint.Enabled = False
        End If
    End Sub

    Private Sub GVSummary_RowCountChanged(sender As Object, e As EventArgs) Handles GVSummary.RowCountChanged
        For i = 0 To GVSummary.RowCount - 1
            If GVSummary.IsValidRowHandle(i) Then
                GVSummary.SetRowCellValue(i, "no", i + 1)
            End If
        Next
    End Sub

    Private Sub GVSummary_CustomSummaryCalculate(sender As Object, e As DevExpress.Data.CustomSummaryEventArgs) Handles GVSummary.CustomSummaryCalculate
        Dim item As DevExpress.XtraGrid.GridSummaryItem = TryCast(e.Item, DevExpress.XtraGrid.GridSummaryItem)

        If item.FieldName.ToString = "persentase_reject" Then
            Select Case e.SummaryProcess
                Case DevExpress.Data.CustomSummaryProcess.Finalize
                    Dim percentage As Decimal = 0.00

                    Try
                        If e.IsGroupSummary Then
                            percentage = e.GetGroupSummary(e.GroupRowHandle, GVSummary.GroupSummary.Item(6)) / e.GetGroupSummary(e.GroupRowHandle, GVSummary.GroupSummary.Item(5)) * 100

                            e.TotalValue = Decimal.Round(percentage, 2)
                        ElseIf e.IsTotalSummary Then
                            percentage = GVSummary.Columns("total_reject").SummaryItem.SummaryValue / GVSummary.Columns("qty_rec").SummaryItem.SummaryValue * 100

                            e.TotalValue = Decimal.Round(percentage, 2)
                        End If
                    Catch ex As Exception
                    End Try
            End Select
        End If
    End Sub

    Private Sub SBPrint_Click(sender As Object, e As EventArgs) Handles SBPrint.Click
        If Not check_allow_print(id_report_status, "222", id_prod_fc_sum) Then
            warningCustom("Can't print, please complete all approval on system first")
        Else
            Dim Report As New ReportProductionFinalClearSummary()

            Report.XLDepartement.Text = execute_query("SELECT departement FROM tb_m_departement WHERE id_departement = 4", 0, True, "", "", "", "")
            Report.XLNumber.Text = TENumber.EditValue.ToString

            Report.id = id_prod_fc_sum
            Report.data = GCSummary.DataSource
            Report.id_pre = If(id_report_status = "6", "-1", "1")

            Dim Tool As DevExpress.XtraReports.UI.ReportPrintTool = New DevExpress.XtraReports.UI.ReportPrintTool(Report)

            Tool.ShowPreviewDialog()
        End If
    End Sub

    Private Sub SBMark_Click(sender As Object, e As EventArgs) Handles SBMark.Click
        FormReportMark.id_report = id_prod_fc_sum
        FormReportMark.report_mark_type = "222"
        FormReportMark.is_view = is_vew

        FormReportMark.ShowDialog()
    End Sub

    Private Sub SBReset_Click(sender As Object, e As EventArgs) Handles SBReset.Click
        Dim confirm As DialogResult = DevExpress.XtraEditors.XtraMessageBox.Show("This action will be reset approval and you can update this propose. Are you sure you want to reset this propose ?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)

        If confirm = Windows.Forms.DialogResult.Yes Then
            Try
                Dim query_upd As String = "
                    -- delete report mark
                    DELETE FROM tb_report_mark WHERE report_mark_type = 222 AND id_report = " + id_prod_fc_sum + "; 
                    -- reset confirm
                    UPDATE tb_prod_fc_sum SET id_report_status = 0 WHERE id_prod_fc_sum = " + id_prod_fc_sum + ";
                "

                execute_non_query(query_upd, True, "", "", "", "")

                load_form()
            Catch ex As Exception
                stopCustom(ex.ToString)
                Close()
            End Try
        End If
    End Sub
End Class