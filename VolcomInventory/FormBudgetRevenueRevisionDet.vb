Public Class FormBudgetRevenueRevisionDet
    Public id As String = "-1"
    Public is_view As String = "-1"
    Dim id_report_status As String = "-1"
    Dim is_confirm As String = "-1"
    Dim id_departement As String = "-1"
    Dim created_date As String = ""

    Private Sub FormBudgetRevenueRevisionDet_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        viewReportStatus()
        actionLoad()
        RepositoryItemTextEdit2.Enabled = False
    End Sub

    Sub viewReportStatus()
        Dim query As String = "SELECT * FROM tb_lookup_report_status a ORDER BY a.id_report_status "
        'Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        viewLookupQuery(LEReportStatus, query, 0, "report_status", "id_report_status")
    End Sub

    Sub actionLoad()
        Dim br As New ClassBudgetRevPropose()
        Dim query As String = br.queryMainRev("AND p.id_b_revenue_revision='" + id + "' ", "1")
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")

        id_report_status = data.Rows(0)("id_report_status").ToString
        is_confirm = data.Rows(0)("is_confirm").ToString
        TxtNumber.Text = data.Rows(0)("number").ToString
        created_date = DateTime.Parse(data.Rows(0)("created_date")).ToString("yyyy-MM-dd HH:mm:ss")
        DECreated.EditValue = data.Rows(0)("created_date")
        TxtYear.Text = data.Rows(0)("year").ToString
        MENote.Text = data.Rows(0)("note").ToString
        LEReportStatus.ItemIndex = LEReportStatus.Properties.GetDataSourceRowIndex("id_report_status", data.Rows(0)("id_report_status").ToString)

        viewDetail()
        showInfo()
        allow_status()
    End Sub

    Sub viewRevisionDetail()
        If SplitContainerControl1.PanelVisibility = DevExpress.XtraEditors.SplitPanelVisibility.Both Then
            Dim query As String = "SELECT c.comp_number AS `code`, c.comp_name AS `description`,
            DATE_FORMAT(rd.month,'%M %Y') AS `month`, rd.value_expense_old, rd.value_expense_new
            FROM tb_b_revenue_revision_det rd 
            INNER JOIN tb_m_comp c ON c.id_comp = rd.id_store
            WHERE rd.id_b_revenue_revision=" + id + "
            ORDER BY c.id_comp ASC, rd.month ASC "
            Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
            GCRev.DataSource = data
            GVRev.BestFitColumns()
        End If
    End Sub

    Sub viewDetail()
        Dim query As String = ""
        query = "SELECT c.id_comp, c.comp_number, c.comp_name, cg.comp_group,
        IFNULL(v.`1_budget`,0) AS `1_budget`,
        IFNULL(v.`2_budget`,0) AS `2_budget`,
        IFNULL(v.`3_budget`,0) AS `3_budget`,
        IFNULL(v.`4_budget`,0) AS `4_budget`,
        IFNULL(v.`5_budget`,0) AS `5_budget`,
        IFNULL(v.`6_budget`,0) AS `6_budget`,
        IFNULL(v.`7_budget`,0) AS `7_budget`,
        IFNULL(v.`8_budget`,0) AS `8_budget`,
        IFNULL(v.`9_budget`,0) AS `9_budget`,
        IFNULL(v.`10_budget`,0) AS `10_budget`,
        IFNULL(v.`11_budget`,0) AS `11_budget`,
        IFNULL(v.`12_budget`,0) AS `12_budget`,
        IFNULL(r.`1_rev`,IFNULL(v.`1_budget`,0)) AS `1_actual`,
        IFNULL(r.`2_rev`,IFNULL(v.`2_budget`,0)) AS `2_actual`,
        IFNULL(r.`3_rev`,IFNULL(v.`3_budget`,0)) AS `3_actual`,
        IFNULL(r.`4_rev`,IFNULL(v.`4_budget`,0)) AS `4_actual`,
        IFNULL(r.`5_rev`,IFNULL(v.`5_budget`,0)) AS `5_actual`,
        IFNULL(r.`6_rev`,IFNULL(v.`6_budget`,0)) AS `6_actual`,
        IFNULL(r.`7_rev`,IFNULL(v.`7_budget`,0)) AS `7_actual`,
        IFNULL(r.`8_rev`,IFNULL(v.`8_budget`,0)) AS `8_actual`,
        IFNULL(r.`9_rev`,IFNULL(v.`9_budget`,0)) AS `9_actual`,
        IFNULL(r.`10_rev`,IFNULL(v.`10_budget`,0)) AS `10_actual`,
        IFNULL(r.`11_rev`,IFNULL(v.`11_budget`,0)) AS `11_actual`,
        IFNULL(r.`12_rev`,IFNULL(v.`12_budget`,0)) AS `12_actual`
        FROM tb_m_comp c 
        INNER JOIN tb_m_comp_group cg ON cg.id_comp_group = c.id_comp_group
        LEFT JOIN (
	        SELECT c.id_comp,
	        SUM(case when r.`month` = '1' THEN rl.val END) AS `1_budget`,
	        SUM(case when r.`month` = '2' THEN rl.val END) AS `2_budget`,
	        SUM(case when r.`month` = '3' THEN rl.val END) AS `3_budget`,
	        SUM(case when r.`month` = '4' THEN rl.val END) AS `4_budget`,
	        SUM(case when r.`month` = '5' THEN rl.val END) AS `5_budget`,
	        SUM(case when r.`month` = '6' THEN rl.val END) AS `6_budget`,
	        SUM(case when r.`month` = '7' THEN rl.val END) AS `7_budget`,
	        SUM(case when r.`month` = '8' THEN rl.val END) AS `8_budget`,
	        SUM(case when r.`month` = '9' THEN rl.val END) AS `9_budget`,
	        SUM(case when r.`month` = '10' THEN rl.val END) AS `10_budget`,
	        SUM(case when r.`month` = '11' THEN rl.val END) AS `11_budget`,
	        SUM(case when r.`month` = '12' THEN rl.val END) AS `12_budget` 
	        FROM tb_b_revenue r
	        INNER JOIN tb_m_comp c ON c.id_comp = r.id_store
	        INNER JOIN (
		        SELECT lg.id_b_revenue, lg.`month`, lg.value_new AS `val`
		        FROM (
			        SELECT l.id_b_revenue, r.`month`, l.value_old, l.value_new 
			        FROM tb_b_revenue_log l
			        INNER JOIN tb_b_revenue r ON r.id_b_revenue = l.id_b_revenue
			        WHERE r.`year`='" + TxtYear.Text + "' AND l.log_date<='" + created_date + "'
			        ORDER BY l.id_b_revenue_log DESC
		        ) lg
		        GROUP BY lg.id_b_revenue
	        ) rl ON rl.id_b_revenue = r.id_b_revenue
	        WHERE r.YEAR='" + TxtYear.Text + "' AND r.is_active=1
	        GROUP BY r.id_store
        ) v ON v.id_comp = c.id_comp
        LEFT JOIN (
	        SELECT rd.id_store, 
	        SUM(case when rd.`month` = '1' THEN rd.value_expense_new END) AS `1_rev`,
	        SUM(case when rd.`month` = '2' THEN rd.value_expense_new END) AS `2_rev`,
	        SUM(case when rd.`month` = '3' THEN rd.value_expense_new END) AS `3_rev`,
	        SUM(case when rd.`month` = '4' THEN rd.value_expense_new END) AS `4_rev`,
	        SUM(case when rd.`month` = '5' THEN rd.value_expense_new END) AS `5_rev`,
	        SUM(case when rd.`month` = '6' THEN rd.value_expense_new END) AS `6_rev`,
	        SUM(case when rd.`month` = '7' THEN rd.value_expense_new END) AS `7_rev`,
	        SUM(case when rd.`month` = '8' THEN rd.value_expense_new END) AS `8_rev`,
	        SUM(case when rd.`month` = '9' THEN rd.value_expense_new END) AS `9_rev`,
	        SUM(case when rd.`month` = '10' THEN rd.value_expense_new END) AS `10_rev`,
	        SUM(case when rd.`month` = '11' THEN rd.value_expense_new END) AS `11_rev`,
	        SUM(case when rd.`month` = '12' THEN rd.value_expense_new END) AS `12_rev`  
	        FROM tb_b_revenue_revision_det rd
	        INNER JOIN tb_m_comp c ON c.id_comp = rd.id_store
	        WHERE rd.id_b_revenue_revision=" + id + "
	        GROUP BY rd.id_store
        ) r ON r.id_store = c.id_comp
        WHERE c.id_comp_cat=6 "
        If id_report_status <> "6" And id_report_status <> "5" Then
            query += "AND c.is_active=1 "
        End If
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCData.DataSource = data
        GVData.BestFitColumns()
    End Sub

    Sub allow_status()
        BtnAttachment.Visible = True
        BtnCancell.Visible = True
        If is_confirm = "2" Then
            BtnConfirm.Visible = True
            BtnMark.Visible = False
            MENote.Enabled = True
            GVData.OptionsBehavior.Editable = True
        Else
            BtnConfirm.Visible = False
            BtnMark.Visible = True
            MENote.Enabled = False
            GVData.OptionsBehavior.Editable = False
        End If

        If id_report_status = "6" Then
            BtnCancell.Visible = False
            GVData.OptionsBehavior.Editable = False
        ElseIf id_report_status = "5" Then
            BtnCancell.Visible = False
            BtnConfirm.Visible = False
            MENote.Enabled = False
            BtnPrint.Visible = False
            GVData.OptionsBehavior.Editable = False
        End If
    End Sub

    Private Sub FormBudgetRevenueRevisionDet_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub MENote_EditValueChanged(sender As Object, e As EventArgs) Handles MENote.EditValueChanged
        If is_confirm = 2 And id_report_status = "1" Then
            Dim query_upd As String = "UPDATE tb_b_expense_revision SET note='" + addSlashes(MENote.Text) + "' WHERE id_b_expense_revision='" + id + "' "
            execute_non_query(query_upd, True, "", "", "", "")
            FormBudgetExpenseRevision.viewData()
            FormBudgetExpenseRevision.GVData.FocusedRowHandle = find_row(FormBudgetExpenseRevision.GVData, "id_b_expense_revision", id)
        End If
    End Sub

    Sub confirm()
        Cursor = Cursors.WaitCursor
        Dim cond_rev As Boolean = False
        makeSafeGV(GVData)
        GVData.ActiveFilterString = "[var]<>0"
        If GVData.RowCount > 0 Then
            cond_rev = True
        End If

        'cek upload
        Dim cond_attach As Boolean = False
        Dim qf As String = "SELECT * FROM tb_doc d WHERE d.report_mark_type=147 AND d.id_report=" + id + " "
        Dim df As DataTable = execute_query(qf, -1, True, "", "", "", "")
        If df.Rows.Count > 0 Then
            cond_attach = True
        End If


        If MENote.Text = "" Then
            GVData.ActiveFilterString = ""
            warningCustom("Mohon isi alasan revisi anggaran")
            makeSafeGV(GVData)
        ElseIf Not cond_rev Then
            GVData.ActiveFilterString = ""
            warningCustom("Tidak ada revisi yang dilakukan. Jika ingin membatalkan revisi, silahkan klik tombol 'Cancel Propose'")
            makeSafeGV(GVData)
        ElseIf Not cond_attach Then
            warningCustom("Silahkan upload terlebih dahulu dokumen anggaran (format : PDF) yang sudah disetujui Manajemen")
            attach()
            makeSafeGV(GVData)
        Else
            Dim confirm As DialogResult = DevExpress.XtraEditors.XtraMessageBox.Show("Anda yakin ingin melakukan revisi anggaran?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
            If confirm = Windows.Forms.DialogResult.Yes Then
                Cursor = Cursors.WaitCursor
                'update confirm
                Dim query As String = "UPDATE tb_b_revenue_revision SET is_confirm=1 WHERE id_b_revenue_revision='" + id + "'"
                execute_non_query(query, True, "", "", "", "")

                'submit approval
                submit_who_prepared(147, id, id_user)
                BtnConfirm.Visible = False
                GVData.ActiveFilterString = ""
                actionLoad()
                infoCustom("Revisi anggaran sudah diajukan. Menunggu persetujuan.")
                Cursor = Cursors.Default
            Else
                GVData.ActiveFilterString = ""
            End If
        End If
        Cursor = Cursors.Default
    End Sub

    Private Sub BtnConfirm_Click(sender As Object, e As EventArgs) Handles BtnConfirm.Click
        confirm()
    End Sub

    Private Sub BtnCancell_Click(sender As Object, e As EventArgs) Handles BtnCancell.Click
        Dim confirm As DialogResult = DevExpress.XtraEditors.XtraMessageBox.Show("Anda yakin ingin membatalkan revisi ini ?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
        If confirm = Windows.Forms.DialogResult.Yes Then
            Cursor = Cursors.WaitCursor
            Dim query As String = "UPDATE tb_b_revenue_revision SET id_report_status=5 WHERE id_b_revenue_revision='" + id + "'"
            execute_non_query(query, True, "", "", "", "")

            'nonaktif mark
            Dim queryrm = String.Format("UPDATE tb_report_mark SET report_mark_lead_time=NULL,report_mark_start_datetime=NULL WHERE report_mark_type='{0}' AND id_report='{1}' AND id_report_status>'1'", 147, id, "5")
            execute_non_query(queryrm, True, "", "", "", "")

            FormBudgetRevPropose.viewRevision()
            FormBudgetRevPropose.GVRevision.FocusedRowHandle = find_row(FormBudgetRevPropose.GVRevision, "id_b_revenue_revision", id)
            actionLoad()
            Cursor = Cursors.Default
        End If
    End Sub

    Private Sub BtnPrint_Click(sender As Object, e As EventArgs) Handles BtnPrint.Click
        CEShowDetail.EditValue = True
        If id_report_status = "6" Then
            'Cursor = Cursors.WaitCursor
            'ReportBudgetExpenseRevision.id = id
            'ReportBudgetExpenseRevision.dt = GCRev.DataSource
            'Dim Report As New ReportBudgetExpenseRevision()

            '' '... 
            '' ' creating and saving the view's layout to a new memory stream 
            'Dim str As System.IO.Stream
            'str = New System.IO.MemoryStream()
            'GVRev.SaveLayoutToStream(str, DevExpress.Utils.OptionsLayoutBase.FullLayout)
            'str.Seek(0, System.IO.SeekOrigin.Begin)
            'Report.GVRev.RestoreLayoutFromStream(str, DevExpress.Utils.OptionsLayoutBase.FullLayout)
            'str.Seek(0, System.IO.SeekOrigin.Begin)

            ''Grid Detail
            'ReportStyleGridview(Report.GVRev)

            ''Parse val
            'Report.LabelNumber.Text = TxtNumber.Text.ToUpper
            'Report.LabelYear.Text = TxtYear.Text.ToUpper
            'Report.LabelDept.Text = TxtDepartement.Text.ToUpper
            'Report.LabelDate.Text = DECreated.Text.ToString
            'Report.LNote.Text = MENote.Text
            'Report.LabelTotalBefore.Text = TxtTotalBefore.Text
            'Report.LabelTotalAfter.Text = TxtTotalAfter.Text

            ''Show the report's preview. 
            'Dim Tool As DevExpress.XtraReports.UI.ReportPrintTool = New DevExpress.XtraReports.UI.ReportPrintTool(Report)
            'Tool.PrintingSystem.SetCommandVisibility(DevExpress.XtraPrinting.PrintingSystemCommand.ExportFile, DevExpress.XtraPrinting.CommandVisibility.None)
            'Tool.PrintingSystem.SetCommandVisibility(DevExpress.XtraPrinting.PrintingSystemCommand.SendFile, DevExpress.XtraPrinting.CommandVisibility.None)
            'Tool.ShowRibbonPreviewDialog()
            'Cursor = Cursors.Default
        Else
            print_raw_no_export(GCRev)
        End If
        CEShowDetail.EditValue = False
    End Sub

    Private Sub BtnAttachment_Click(sender As Object, e As EventArgs) Handles BtnAttachment.Click
        attach
    End Sub

    Sub attach()
        Cursor = Cursors.WaitCursor
        FormDocumentUpload.report_mark_type = "147"
        FormDocumentUpload.id_report = id
        FormDocumentUpload.is_only_pdf = True
        If is_view = "1" Or id_report_status = "6" Or id_report_status = "5" Or is_confirm = "1" Then
            FormDocumentUpload.is_view = "1"
        End If
        FormDocumentUpload.ShowDialog()
        Cursor = Cursors.Default
    End Sub

    Private Sub BtnMark_Click(sender As Object, e As EventArgs) Handles BtnMark.Click
        Cursor = Cursors.WaitCursor
        FormReportMark.report_mark_type = "147"
        FormReportMark.id_report = id
        FormReportMark.is_view = "1"
        FormReportMark.form_origin = Name
        FormReportMark.ShowDialog()
        Cursor = Cursors.Default
    End Sub

    Private Sub GVData_CellValueChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles GVData.CellValueChanged
        Cursor = Cursors.WaitCursor
        Dim old_val As Decimal = GVData.ActiveEditor.OldEditValue
        Dim row_foc As Integer = e.RowHandle
        Dim col_name As String = e.Column.FieldName.ToString
        Dim month_arr As String() = Split(col_name, "_")
        Dim month_only As String = month_arr(0)
        Dim month As String = month_only
        Dim id_store As String = GVData.GetRowCellValue(row_foc, "id_comp").ToString
        Dim value_expense_old As String = decimalSQL(GVData.GetRowCellValue(row_foc, month_only + "_budget").ToString)
        Dim value_expense_new As String = decimalSQL(e.Value.ToString)
        If GVData.GetRowCellValue(row_foc, col_name) <> GVData.GetRowCellValue(row_foc, month_only + "_budget") Then
            'insert
            Dim qi As String = "DELETE FROM tb_b_revenue_revision_det WHERE id_b_revenue_revision='" + id + "' AND id_store='" + id_store + "' AND month='" + month + "'; 
            INSERT INTO tb_b_revenue_revision_det(id_b_revenue_revision, id_store, month, value_expense_old, value_expense_new) VALUES 
            (" + id + "," + id_store + ", '" + month + "', '" + value_expense_old + "', '" + value_expense_new + "'); "
            execute_non_query(qi, True, "", "", "", "")

            'refresh
            GVData.RefreshData()
            GVData.BestFitColumns()
            viewRevisionDetail()
            updateTotal()
            showInfo()
        Else
            Dim query_del As String = "DELETE FROM tb_b_revenue_revision_det WHERE id_b_revenue_revision='" + id + "' AND id_store='" + id_store + "' AND month='" + month + "' "
            execute_non_query(query_del, True, "", "", "", "")

            'refresh
            viewDetail()
            GVData.BestFitColumns()
            GVData.FocusedRowHandle = row_foc
            GVData.FocusedColumn = GVData.Columns(col_name)
            GVData.CloseEditor()
            viewRevisionDetail()
            updateTotal()
            showInfo()
        End If
        Cursor = Cursors.Default
    End Sub

    Sub updateTotal()
        Dim new_total As String = decimalSQL(GVData.Columns("total_actual").SummaryItem.SummaryValue.ToString)
        Dim query_upd As String = "UPDATE tb_b_expense_revision SET value_expense_total='" + new_total + "' WHERE id_b_expense_revision='" + id + "' "
        execute_non_query(query_upd, True, "", "", "", "")
        FormBudgetExpenseRevision.viewData()
        FormBudgetExpenseRevision.GVData.FocusedRowHandle = find_row(FormBudgetExpenseRevision.GVData, "id_b_expense_revision", id)
    End Sub

    Sub showInfo()
        TxtTotalBefore.Text = GVData.Columns("total_budget").SummaryText
        TxtTotalAfter.Text = GVData.Columns("total_actual").SummaryText
    End Sub

    Private Sub CEShowDetail_CheckedChanged(sender As Object, e As EventArgs) Handles CEShowDetail.CheckedChanged
        If CEShowDetail.EditValue = True Then
            SplitContainerControl1.PanelVisibility = DevExpress.XtraEditors.SplitPanelVisibility.Both
        Else
            SplitContainerControl1.PanelVisibility = DevExpress.XtraEditors.SplitPanelVisibility.Panel1
        End If
    End Sub

    Private Sub SplitContainerControl1_Panel2_VisibleChanged(sender As Object, e As EventArgs) Handles SplitContainerControl1.Panel2.VisibleChanged
        If SplitContainerControl1.Panel2.Visible = True Then
            viewRevisionDetail()
        End If
    End Sub

    Public Sub custom_cell(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs)
        Dim View As DevExpress.XtraGrid.Views.Grid.GridView = sender

        Dim currview As DevExpress.XtraGrid.Views.Grid.GridView = TryCast(sender, DevExpress.XtraGrid.Views.Grid.GridView)
        For i As Integer = 1 To 12
            If e.Column.FieldName.ToString = i.ToString + "_budget" Or e.Column.FieldName.ToString = i.ToString + "_actual" Then
                If currview.GetRowCellValue(e.RowHandle, i.ToString + "_budget") <> currview.GetRowCellValue(e.RowHandle, i.ToString + "_actual") Then
                    If CEShowHiglights.EditValue = True Then
                        If e.Column.FieldName.ToString = i.ToString + "_actual" Then
                            e.Appearance.BackColor = Color.LightSeaGreen
                            'Else
                            'e.Appearance.BackColor = Color.Crimson
                        End If
                    Else
                        If e.Column.FieldName.ToString <> i.ToString + "_budget" Then
                            e.Appearance.BackColor = Color.Empty
                        End If
                    End If
                Else
                    If e.Column.FieldName.ToString <> i.ToString + "_budget" Then
                        e.Appearance.BackColor = Color.Empty
                    End If
                End If
            End If
        Next
    End Sub

    Private Sub CEShowHiglights_CheckedChanged(sender As Object, e As EventArgs) Handles CEShowHiglights.CheckedChanged
        AddHandler GVData.RowCellStyle, AddressOf custom_cell
        GCData.Focus()
    End Sub
End Class