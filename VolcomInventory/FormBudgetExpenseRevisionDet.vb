Public Class FormBudgetExpenseRevisionDet
    Public id As String = "-1"
    Public is_view As String = "-1"
    Dim id_report_status As String = "-1"
    Dim is_confirm As String = "-1"
    Dim id_departement As String = "-1"
    Dim created_date As String = ""

    Private Sub FormBudgetExpenseRevisionDet_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        viewReportStatus()
        actionLoad()
    End Sub

    Sub viewReportStatus()
        Dim query As String = "SELECT * FROM tb_lookup_report_status a ORDER BY a.id_report_status "
        'Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        viewLookupQuery(LEReportStatus, query, 0, "report_status", "id_report_status")
    End Sub

    Sub actionLoad()
        Dim br As New ClassBudgetExpenseRevision()
        Dim query As String = br.queryMain("AND p.id_b_expense_revision='" + id + "' ", "1")
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")

        id_report_status = data.Rows(0)("id_report_status").ToString
        is_confirm = data.Rows(0)("is_confirm").ToString
        TxtNumber.Text = data.Rows(0)("number").ToString
        created_date = DateTime.Parse(data.Rows(0)("created_date")).ToString("yyyy-MM-dd HH:mm:ss")
        DECreated.EditValue = data.Rows(0)("created_date")
        TxtYear.Text = data.Rows(0)("year").ToString
        id_departement = data.Rows(0)("id_departement").ToString
        TxtDepartement.Text = data.Rows(0)("departement").ToString
        MENote.Text = data.Rows(0)("note").ToString
        LEReportStatus.ItemIndex = LEReportStatus.Properties.GetDataSourceRowIndex("id_report_status", data.Rows(0)("id_report_status").ToString)

        viewDetail()
        showInfo()
        allow_status()
    End Sub

    Sub viewRevisionDetail()
        If SplitContainerControl1.PanelVisibility = DevExpress.XtraEditors.SplitPanelVisibility.Both Then
            Dim query As String = "SELECT coa.acc_name AS `code`, coa.acc_description AS `description`, cat.item_cat, 
            DATE_FORMAT(rd.month,'%M %Y') AS `month`, rd.value_expense_old, rd.value_expense_new
            FROM tb_b_expense_revision_det rd 
            INNER JOIN tb_item_coa c ON c.id_item_coa = rd.id_item_coa
            INNER JOIN tb_item_cat cat ON cat.id_item_cat = c.id_item_cat
            INNER JOIN tb_a_acc coa ON coa.id_acc = c.id_coa_out
            WHERE rd.id_b_expense_revision=" + id + "
            ORDER BY cat.item_cat ASC, rd.month ASC "
            Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
            GCRev.DataSource = data
            GVRev.BestFitColumns()
        End If
    End Sub

    Sub viewDetail()
        Dim query As String = "SELECT c.id_item_coa,coa.acc_name AS `exp_acc`, coa.acc_description AS `exp_description`, cat.item_cat, et.expense_type,
        IFNULL(v.id_b_expense,0) AS `id_b_expense`,
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
        FROM tb_item_coa c
        INNER JOIN tb_item_cat cat ON cat.id_item_cat = c.id_item_cat
        INNER JOIN tb_lookup_expense_type et ON et.id_expense_type = cat.id_expense_type
        INNER JOIN tb_a_acc coa ON coa.id_acc = c.id_coa_out
        LEFT JOIN (
	        SELECT e.id_item_coa, e.id_b_expense,
	        SUM(case when MONTH(em.month) = '1' THEN eml.val END) AS `1_budget`,
	        SUM(case when MONTH(em.month) = '2' THEN eml.val END) AS `2_budget`,
	        SUM(case when MONTH(em.month) = '3' THEN eml.val END) AS `3_budget`,
	        SUM(case when MONTH(em.month) = '4' THEN eml.val END) AS `4_budget`,
	        SUM(case when MONTH(em.month) = '5' THEN eml.val END) AS `5_budget`,
	        SUM(case when MONTH(em.month) = '6' THEN eml.val END) AS `6_budget`,
	        SUM(case when MONTH(em.month) = '7' THEN eml.val END) AS `7_budget`,
	        SUM(case when MONTH(em.month) = '8' THEN eml.val END) AS `8_budget`,
	        SUM(case when MONTH(em.month) = '9' THEN eml.val END) AS `9_budget`,
	        SUM(case when MONTH(em.month) = '10' THEN eml.val END) AS `10_budget`,
	        SUM(case when MONTH(em.month) = '11' THEN eml.val END) AS `11_budget`,
	        SUM(case when MONTH(em.month) = '12' THEN eml.val END) AS `12_budget` 
	        FROM tb_b_expense_month em
	        INNER JOIN (
		        SELECT lg.id_b_expense_month, lg.month, lg.value_new AS `val`
		        FROM (
			        SELECT l.id_b_expense_month, m.month, l.value_old, l.value_new
			        FROM tb_b_expense_month_log l
			        INNER JOIN tb_b_expense_month m ON m.id_b_expense_month = l.id_b_expense_month
			        INNER JOIN tb_b_expense y ON y.id_b_expense = m.id_b_expense
			        INNER JOIN tb_item_coa c ON c.id_item_coa = y.id_item_coa
			        WHERE c.id_departement='" + id_departement + "' AND y.year='" + TxtYear.Text + "' AND l.log_date<='" + created_date + "'
			        ORDER BY l.id_b_expense_month_log DESC
		        ) lg
		        GROUP BY lg.id_b_expense_month
	        ) eml ON eml.id_b_expense_month = em.id_b_expense_month
	        INNER JOIN tb_b_expense e ON e.id_b_expense = em.id_b_expense
	        INNER JOIN tb_item_coa c ON c.id_item_coa = e.id_item_coa
	        WHERE e.year='" + TxtYear.Text + "' AND c.id_departement='" + id_departement + "'
	        GROUP BY e.id_item_coa
        ) v ON v.id_item_coa = c.id_item_coa
        LEFT JOIN (
	        SELECT rd.id_item_coa, rd.id_b_expense,
	        SUM(case when MONTH(rd.month) = '1' THEN rd.value_expense_new END) AS `1_rev`,
	        SUM(case when MONTH(rd.month) = '2' THEN rd.value_expense_new END) AS `2_rev`,
	        SUM(case when MONTH(rd.month) = '3' THEN rd.value_expense_new END) AS `3_rev`,
	        SUM(case when MONTH(rd.month) = '4' THEN rd.value_expense_new END) AS `4_rev`,
	        SUM(case when MONTH(rd.month) = '5' THEN rd.value_expense_new END) AS `5_rev`,
	        SUM(case when MONTH(rd.month) = '6' THEN rd.value_expense_new END) AS `6_rev`,
	        SUM(case when MONTH(rd.month) = '7' THEN rd.value_expense_new END) AS `7_rev`,
	        SUM(case when MONTH(rd.month) = '8' THEN rd.value_expense_new END) AS `8_rev`,
	        SUM(case when MONTH(rd.month) = '9' THEN rd.value_expense_new END) AS `9_rev`,
	        SUM(case when MONTH(rd.month) = '10' THEN rd.value_expense_new END) AS `10_rev`,
	        SUM(case when MONTH(rd.month) = '11' THEN rd.value_expense_new END) AS `11_rev`,
	        SUM(case when MONTH(rd.month) = '12' THEN rd.value_expense_new END) AS `12_rev`  
	        FROM tb_b_expense_revision_det rd
	        INNER JOIN tb_item_coa c ON c.id_item_coa = rd.id_item_coa
	        WHERE rd.id_b_expense_revision='" + id + "'
	        GROUP BY rd.id_item_coa
        ) r ON r.id_item_coa = c.id_item_coa
        WHERE c.id_departement='" + id_departement + "'
        ORDER BY cat.item_cat ASC "
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



    Private Sub FormBudgetExpenseRevisionDet_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
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

    Private Sub BtnConfirm_Click(sender As Object, e As EventArgs) Handles BtnConfirm.Click
        Cursor = Cursors.WaitCursor
        Dim cond_rev As Boolean = False
        makeSafeGV(GVData)
        GVData.ActiveFilterString = "[var]<>0"
        If GVData.RowCount > 0 Then
            cond_rev = True
        End If


        If MENote.Text = "" Then
            GVData.ActiveFilterString = ""
            stopCustom("Please input reason")
        ElseIf Not cond_rev Then
            GVData.ActiveFilterString = ""
            stopCustom("No revisions were made. If you want to cancel this revision, please click 'Cancel Propose'")
        Else
            Dim confirm As DialogResult = DevExpress.XtraEditors.XtraMessageBox.Show("Are you sure you want to confirm this budget ?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
            If confirm = Windows.Forms.DialogResult.Yes Then
                Cursor = Cursors.WaitCursor
                'insert budget tahunan yg direvisi
                Dim qiy As String = "INSERT INTO tb_b_expense_revision_year(id_b_expense_revision, id_b_expense, id_item_coa, value_old, value_new) VALUES "
                For i As Integer = 0 To ((GVData.RowCount - 1) - GetGroupRowCount(GVData))
                    Dim id_b_expense As String = GVData.GetRowCellValue(i, "id_b_expense").ToString
                    If id_b_expense = "0" Then
                        id_b_expense = "NULL"
                    End If
                    Dim value_old As String = decimalSQL(GVData.GetRowCellValue(i, "total_budget").ToString)
                    Dim value_new As String = decimalSQL(GVData.GetRowCellValue(i, "total_actual").ToString)
                    Dim id_item_coa As String = GVData.GetRowCellValue(i, "id_item_coa").ToString

                    If i > 0 Then
                        qiy += ", "
                    End If
                    qiy += "('" + id + "', '" + id_b_expense + "','" + id_item_coa + "', '" + value_old + "', '" + value_new + "') "
                Next
                If GVData.RowCount > 0 Then
                    execute_non_query(qiy, True, "", "", "", "")
                End If

                'update confirm
                Dim query As String = "UPDATE tb_b_expense_revision SET is_confirm=1 WHERE id_b_expense_revision='" + id + "'"
                execute_non_query(query, True, "", "", "", "")

                'submit approval
                submit_who_prepared(138, id, id_user)
                BtnConfirm.Visible = False
                GVData.ActiveFilterString = ""
                actionLoad()
                infoCustom("Revision budget submitted. Waiting for approval.")
                Cursor = Cursors.Default
            Else
                GVData.ActiveFilterString = ""
            End If
        End If
        Cursor = Cursors.Default
    End Sub

    Private Sub BtnCancell_Click(sender As Object, e As EventArgs) Handles BtnCancell.Click
        Dim confirm As DialogResult = DevExpress.XtraEditors.XtraMessageBox.Show("Are you sure you want to cancelled this propose ?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
        If confirm = Windows.Forms.DialogResult.Yes Then
            Cursor = Cursors.WaitCursor
            Dim query As String = "UPDATE tb_b_expense_revision SET id_report_status=5 WHERE id_b_expense_revision='" + id + "'"
            execute_non_query(query, True, "", "", "", "")

            'nonaktif mark
            Dim queryrm = String.Format("UPDATE tb_report_mark SET report_mark_lead_time=NULL,report_mark_start_datetime=NULL WHERE report_mark_type='{0}' AND id_report='{1}' AND id_report_status>'1'", 138, id, "5")
            execute_non_query(queryrm, True, "", "", "", "")

            FormBudgetExpenseRevision.viewData()
            FormBudgetExpenseRevision.GVData.FocusedRowHandle = find_row(FormBudgetExpenseRevision.GVData, "id_b_expense_revision", id)
            actionLoad()
            Cursor = Cursors.Default
        End If
    End Sub

    Private Sub BtnPrint_Click(sender As Object, e As EventArgs) Handles BtnPrint.Click
        If id_report_status = "6" Then
            Cursor = Cursors.WaitCursor
            ReportBudgetExpenseRevision.id = id
            ReportBudgetExpenseRevision.dt = GCData.DataSource
            Dim Report As New ReportBudgetExpenseRevision()

            ' '... 
            ' ' creating and saving the view's layout to a new memory stream 
            Dim str As System.IO.Stream
            str = New System.IO.MemoryStream()
            GVData.SaveLayoutToStream(str, DevExpress.Utils.OptionsLayoutBase.FullLayout)
            str.Seek(0, System.IO.SeekOrigin.Begin)
            Report.GVData.RestoreLayoutFromStream(str, DevExpress.Utils.OptionsLayoutBase.FullLayout)
            str.Seek(0, System.IO.SeekOrigin.Begin)

            'Grid Detail
            ReportStyleGridview(Report.GVData)

            'Parse val
            Report.LabelNumber.Text = TxtNumber.Text.ToUpper
            Report.LabelYear.Text = TxtYear.Text.ToUpper
            Report.LabelDept.Text = TxtDepartement.Text.ToUpper
            Report.LabelDate.Text = DECreated.Text.ToString

            'Show the report's preview. 
            Dim Tool As DevExpress.XtraReports.UI.ReportPrintTool = New DevExpress.XtraReports.UI.ReportPrintTool(Report)
            Tool.PrintingSystem.SetCommandVisibility(DevExpress.XtraPrinting.PrintingSystemCommand.ExportFile, DevExpress.XtraPrinting.CommandVisibility.None)
            Tool.PrintingSystem.SetCommandVisibility(DevExpress.XtraPrinting.PrintingSystemCommand.SendFile, DevExpress.XtraPrinting.CommandVisibility.None)
            Tool.ShowRibbonPreviewDialog()
            Cursor = Cursors.Default
        Else
            print_raw_no_export(GCData)
        End If
    End Sub

    Private Sub BtnAttachment_Click(sender As Object, e As EventArgs) Handles BtnAttachment.Click
        Cursor = Cursors.WaitCursor
        FormDocumentUpload.report_mark_type = "138"
        FormDocumentUpload.id_report = id
        If is_view = "1" Or id_report_status = "6" Or id_report_status = "5" Or is_confirm = "1" Then
            FormDocumentUpload.is_view = "1"
        End If
        FormDocumentUpload.ShowDialog()
        Cursor = Cursors.Default
    End Sub

    Private Sub BtnMark_Click(sender As Object, e As EventArgs) Handles BtnMark.Click
        Cursor = Cursors.WaitCursor
        FormReportMark.report_mark_type = "138"
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
        Dim month As String = TxtYear.Text + "-" + month_only + "-" + "01"
        Dim id_item_coa As String = GVData.GetRowCellValue(row_foc, "id_item_coa").ToString
        Dim id_b_expense As String = GVData.GetRowCellValue(row_foc, "id_b_expense").ToString
        If id_b_expense = "0" Then
            id_b_expense = "NULL "
        End If
        Dim value_expense_old As String = decimalSQL(GVData.GetRowCellValue(row_foc, month_only + "_budget").ToString)
        Dim value_expense_new As String = decimalSQL(e.Value.ToString)
        If GVData.GetRowCellValue(row_foc, col_name) <> GVData.GetRowCellValue(row_foc, month_only + "_budget") Then
            'cari id month
            Dim qm As String = "SELECT IFNULL(m.id_b_expense_month,0) AS id_b_expense_month FROM tb_b_expense_month m
            WHERE m.id_b_expense='" + id_b_expense + "' AND m.month='" + month + "' "
            Dim id_b_expense_month As String = "0"
            Try
                id_b_expense_month = execute_query(qm, 0, True, "", "", "", "")
            Catch ex As Exception
                id_b_expense_month = "0"
            End Try
            If id_b_expense_month = "0" Then
                id_b_expense_month = "NULL"
            End If

            'insert
            Dim qi As String = "DELETE FROM tb_b_expense_revision_det WHERE id_b_expense_revision='" + id + "' AND id_item_coa='" + id_item_coa + "' AND month='" + month + "'; 
            INSERT INTO tb_b_expense_revision_det(id_b_expense_revision, id_b_expense, id_b_expense_month, id_item_coa, month, value_expense_old, value_expense_new) VALUES 
            (" + id + "," + id_b_expense + "," + id_b_expense_month + ", " + id_item_coa + ", '" + month + "', '" + value_expense_old + "', '" + value_expense_new + "'); "
            execute_non_query(qi, True, "", "", "", "")

            'refresh
            GVData.RefreshData()
            GVData.BestFitColumns()
            viewRevisionDetail()
            updateTotal()
            showInfo()
        Else
            Dim query_del As String = "DELETE FROM tb_b_expense_revision_det WHERE id_b_expense_revision='" + id + "' AND id_item_coa='" + id_item_coa + "' AND month='" + month + "' "
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

    Private Sub SplitContainerControl1_SplitterMoved(sender As Object, e As EventArgs) Handles SplitContainerControl1.SplitterMoved
        'GVData.BestFitColumns()
        'GVRev.BestFitColumns()
    End Sub

    Private Sub GVData_RowCellStyle(sender As Object, e As DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs) Handles GVData.RowCellStyle

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
                        Else
                            e.Appearance.BackColor = Color.Crimson
                        End If
                    Else
                        e.Appearance.BackColor = Color.Empty
                    End If
                Else
                    e.Appearance.BackColor = Color.Empty
                End If
            End If
        Next
    End Sub


    Private Sub CEShowHiglights_CheckedChanged(sender As Object, e As EventArgs) Handles CEShowHiglights.CheckedChanged
        AddHandler GVData.RowCellStyle, AddressOf custom_cell
        GCData.Focus()

    End Sub
End Class