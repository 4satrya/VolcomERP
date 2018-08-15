Public Class FormBudgetExpenseProposeDet
    Public id As String = "-1"
    Public action As String = ""
    Dim id_report_status As String = "-1"
    Public is_view As String = "-1"
    Dim is_confirm As String = "2"
    Public id_departement As String = "-1"
    Dim is_allow_print As Boolean = False

    Private Sub FormBudgetExpenseProposeDet_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        viewReportStatus()
        viewDept()
        actionLoad()
    End Sub

    'View Data
    Sub viewReportStatus()
        Dim query As String = "SELECT * FROM tb_lookup_report_status a ORDER BY a.id_report_status "
        'Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        viewLookupQuery(LEReportStatus, query, 0, "report_status", "id_report_status")
    End Sub

    Sub viewDept()
        Cursor = Cursors.WaitCursor
        Dim query As String = "SELECT id_departement,departement FROM tb_m_departement a ORDER BY a.departement ASC "
        viewLookupQuery(LEDeptSum, query, 0, "departement", "id_departement")
        Cursor = Cursors.Default
    End Sub

    Sub actionLoad()
        If action = "upd" Then
            Dim query_c As New ClassBudgetExpensePropose()
            Dim query As String = query_c.queryMain("AND p.id_b_expense_propose=" + id + "", "2")
            Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")

            id_report_status = data.Rows(0)("id_report_status").ToString
            is_confirm = data.Rows(0)("is_confirm").ToString
            TxtYear.Text = data.Rows(0)("year").ToString
            TxtTotal.EditValue = data.Rows(0)("value_expense_total")
            TxtNumber.Text = data.Rows(0)("number").ToString
            DECreated.EditValue = data.Rows(0)("created_date")
            MENote.Text = data.Rows(0)("note").ToString
            LEReportStatus.ItemIndex = LEReportStatus.Properties.GetDataSourceRowIndex("id_report_status", data.Rows(0)("id_report_status").ToString)
            LEDeptSum.ItemIndex = LEDeptSum.Properties.GetDataSourceRowIndex("id_departement", data.Rows(0)("id_departement").ToString)
            id_departement = data.Rows(0)("id_departement").ToString
            allow_status()
        Else
            TxtTotal.EditValue = 0.00
            LEDeptSum.ItemIndex = LEDeptSum.Properties.GetDataSourceRowIndex("id_departement", id_departement_user)
            XTCBudget.ShowTabHeader = DevExpress.Utils.DefaultBoolean.False
            ActiveControl = TxtYear
        End If
    End Sub

    Sub viewDetailYearly()
        'total budgwt
        Dim query_c As New ClassBudgetExpensePropose()
        Dim query As String = "SELECT p.value_expense_total FROM tb_b_expense_propose p WHERE p.id_b_expense_propose='" + id + "'"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        TxtTotalYearly.EditValue = data.Rows(0)("value_expense_total")

        'data mapping per dept
        Dim qd As String = "SELECT ic.id_item_coa, ic.id_item_cat, cat.item_cat, ic.id_departement, d.departement,
        ic.id_coa_out,  coa.acc_name AS `exp_acc`, coa.acc_description AS `exp_description`, IFNULL(py.id_b_expense_propose_year,0) AS `id_b_expense_propose_year`, IFNULL(py.value_expense,0) AS `val`
        FROM tb_item_coa ic 
        INNER JOIN tb_item_cat cat ON cat.id_item_cat = ic.id_item_cat
        INNER JOIN tb_m_departement d ON d.id_departement = ic.id_departement
        INNER JOIN tb_a_acc coa ON coa.id_acc = ic.id_coa_out
        LEFT JOIN tb_b_expense_propose_year py ON py.id_item_coa = ic.id_item_coa AND py.id_b_expense_propose=" + id + "
        WHERE ic.id_departement=" + id_departement + " AND ic.is_active=1 ORDER BY cat.item_cat ASC "
        Dim dd As DataTable = execute_query(qd, -1, True, "", "", "", "")
        GCYearlyCat.DataSource = dd
        GVYearlyCat.BestFitColumns()

        'get total cat
        getTotalYearlyCat()
    End Sub

    Sub getTotalYearlyCat()
        Dim query As String = "SELECT IFNULL(SUM(bd.value_expense),0) AS `total` FROM tb_b_expense_propose_year bd WHERE bd.id_b_expense_propose=" + id + ""
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        TxtTotYearlyCat.EditValue = data.Rows(0)("total")
        TxtTotYearlyDiffCat.EditValue = TxtTotalYearly.EditValue - TxtTotYearlyCat.EditValue
    End Sub

    Sub viewDetailMonthly()
        Dim query As String = "CALL view_b_expense_propose_month(" + id + ")"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCMonthly.DataSource = data
        GVMonthly.BestFitColumns()
    End Sub


    Sub allow_status()
        XTCBudget.ShowTabHeader = DevExpress.Utils.DefaultBoolean.False
        BtnAttachment.Visible = True
        BtnCancell.Visible = True
        If is_confirm = "2" Then 'belum confirm
            TxtYear.Enabled = True
            TxtTotal.Enabled = True
            MENote.Enabled = True
            BtnImportXLSYearlyCat.Visible = True
            BtnExportXLSYearlyCat.Visible = True
            BtnDividedYearlyCat.Visible = True
            BtnPrintDraftYearlyCat.Visible = True
            BtnImportXLSMonthly.Visible = True
            BtnExportXLSMonthly.Visible = True
            BtnPrintDraftMonthlyCat.Visible = True
            BtnDividedMonthlyCat.Visible = True
            BtnMark.Visible = False
            GVYearlyCat.OptionsBehavior.Editable = True
            GVMonthly.OptionsBehavior.Editable = True
            GCYearlyCat.ContextMenuStrip = CMSYearlyCat
            GCMonthly.ContextMenuStrip = CMSYearlyCat
        Else
            TxtYear.Enabled = False
            TxtTotal.Enabled = False
            MENote.Enabled = False
            BtnImportXLSYearlyCat.Visible = False
            BtnExportXLSYearlyCat.Visible = False
            BtnDividedYearlyCat.Visible = False
            BtnPrintDraftYearlyCat.Visible = False
            BtnImportXLSMonthly.Visible = False
            BtnExportXLSMonthly.Visible = False
            BtnPrintDraftMonthlyCat.Visible = False
            BtnDividedMonthlyCat.Visible = False
            BtnMark.Visible = True
            GVYearlyCat.OptionsBehavior.Editable = False
            GVMonthly.OptionsBehavior.Editable = False
            GCYearlyCat.ContextMenuStrip = Nothing
            GCMonthly.ContextMenuStrip = Nothing
        End If

        If check_print_report_status(id_report_status) Then
            is_allow_print = True
        Else
            is_allow_print = False
        End If

        If id_report_status = "6" Then
            BtnCancell.Visible = False
            GVMonthly.OptionsBehavior.Editable = False
        ElseIf id_report_status = "5" Then
            TxtYear.Enabled = False
            TxtTotal.Enabled = False
            MENote.Enabled = False
            BtnImportXLSYearlyCat.Visible = False
            BtnExportXLSYearlyCat.Visible = False
            BtnDividedYearlyCat.Visible = False
            BtnPrintDraftYearlyCat.Visible = False
            BtnImportXLSMonthly.Visible = False
            BtnExportXLSMonthly.Visible = False
            BtnPrintDraftMonthlyCat.Visible = False
            BtnDividedMonthlyCat.Visible = False
            BtnCancell.Visible = False
            BtnConfirm.Visible = False
            GVYearlyCat.OptionsBehavior.Editable = False
            GVMonthly.OptionsBehavior.Editable = False
            GCYearlyCat.ContextMenuStrip = Nothing
            GCMonthly.ContextMenuStrip = Nothing
        End If

        If is_view = "1" Then
            XTCBudget.ShowTabHeader = DevExpress.Utils.DefaultBoolean.True
        End If
    End Sub

    Private Sub FormBudgetExpenseProposeDet_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub BtnNext_Click(sender As Object, e As EventArgs) Handles BtnNext.Click
        If XTCBudget.SelectedTabPageIndex = 0 Then
            If is_confirm = "2" And id_report_status <> "5" Then
                'cek budget
                Dim cond As Boolean = True
                Dim query_c As New ClassBudgetExpensePropose()
                Dim check_upd As String = ""
                If action = "upd" Then
                    check_upd = "AND p.id_b_expense_propose!=" + id + " "
                End If
                Dim queryc As String = query_c.queryMain("AND p.year='" + TxtYear.Text + "' AND p.id_departement='" + LEDeptSum.EditValue.ToString + "' AND p.id_report_status!=5 " + check_upd, "2")
                Dim data As DataTable = execute_query(queryc, -1, True, "", "", "", "")
                If data.Rows.Count > 0 Then
                    cond = False
                End If

                If Not cond Then
                    stopCustom("Expense budget : " + TxtYear.Text + " already created")
                    Exit Sub
                ElseIf TxtYear.Text = "" Then
                    stopCustom("Please input year")
                    TxtYear.Focus()
                    Exit Sub
                ElseIf TxtTotal.EditValue <= 0 Then
                    stopCustom("Please input total budget")
                    TxtTotal.Focus()
                    Exit Sub
                Else
                    Cursor = Cursors.WaitCursor
                    Dim id_departement As String = LEDeptSum.EditValue.ToString
                    Dim number As String = ""
                    Dim year As String = TxtYear.Text
                    Dim value_expense_total As String = decimalSQL(TxtTotal.EditValue.ToString)
                    Dim note As String = addSlashes(MENote.Text)

                    If action = "ins" Then
                        Dim query As String = "INSERT INTO tb_b_expense_propose(id_departement, number, created_date, id_created_user, year, value_expense_total, note, id_report_status) 
                    VALUES('" + id_departement + "', '',NOW(),'" + id_user + "', '" + year + "', '" + value_expense_total + "', '" + note + "',1); SELECT LAST_INSERT_ID(); "
                        id = execute_query(query, 0, True, "", "", "", "")

                        'update number
                        Dim qn As String = "CALL gen_number(" + id + ",136)"
                        execute_non_query(qn, True, "", "", "", "")

                        FormBudgetExpensePropose.viewData()
                        FormBudgetExpensePropose.GVData.FocusedRowHandle = find_row(FormBudgetExpensePropose.GVData, "id_b_expense_propose", id)
                        action = "upd"
                        actionLoad()
                    ElseIf action = "upd" Then
                        Dim query As String = "UPDATE tb_b_expense_propose SET year='" + year + "', value_expense_total='" + value_expense_total + "', note='" + note + "'
                    WHERE id_b_expense_propose='" + id + "';
                    UPDATE tb_b_expense_propose_year SET year='" + year + "' WHERE id_b_expense_propose='" + id + "'; "
                        execute_non_query(query, True, "", "", "", "")
                        FormBudgetExpensePropose.viewData()
                        FormBudgetExpensePropose.GVData.FocusedRowHandle = find_row(FormBudgetExpensePropose.GVData, "id_b_expense_propose", id)
                        action = "upd"
                        actionLoad()
                    End If
                    Cursor = Cursors.Default
                End If
            End If
        ElseIf XTCBudget.SelectedTabPageIndex = 1 Then
            If TxtTotYearlyCat.EditValue <> TxtTotalYearly.EditValue Then
                stopCustom("Budget total per category must be equal with annual budget total")
                Exit Sub
            End If
        End If
        XTCBudget.SelectedTabPageIndex = XTCBudget.SelectedTabPageIndex + 1
    End Sub

    Private Sub BtnPrev_Click(sender As Object, e As EventArgs) Handles BtnPrev.Click
        XTCBudget.SelectedTabPageIndex = XTCBudget.SelectedTabPageIndex - 1
    End Sub

    Private Sub XTCBudget_SelectedPageChanged(sender As Object, e As DevExpress.XtraTab.TabPageChangedEventArgs) Handles XTCBudget.SelectedPageChanged
        If XTCBudget.SelectedTabPageIndex = 0 Then 'total budget
            BtnPrint.Visible = False
            BtnPrev.Visible = False
            BtnNext.Visible = True
            BtnConfirm.Visible = False
            TxtYear.Focus()
        ElseIf XTCBudget.SelectedTabPageIndex = 1 Then 'yearly budget
            'print
            If is_allow_print Then
                BtnPrint.Visible = True
            Else
                BtnPrint.Visible = False
            End If


            BtnPrev.Visible = True
            BtnNext.Visible = True
            BtnConfirm.Visible = False
            DividedEquallyToolStripMenuItem.Visible = False

            'data
            viewDetailYearly()
        ElseIf XTCBudget.SelectedTabPageIndex = 2 Then 'monthly budget
            'print
            If is_allow_print Then
                BtnPrint.Visible = True
            Else
                BtnPrint.Visible = False
            End If

            BtnPrev.Visible = True
            BtnNext.Visible = False
            DividedEquallyToolStripMenuItem.Visible = True
            If is_confirm = "2" And id_report_status <> "5" Then
                BtnConfirm.Visible = True
            Else
                BtnConfirm.Visible = False
            End If

            'data
            viewDetailMonthly()
        End If
    End Sub

    Private Sub TxtYear_KeyDown(sender As Object, e As KeyEventArgs) Handles TxtYear.KeyDown
        If e.KeyCode = Keys.Enter Then
            TxtTotal.Focus()
        End If
    End Sub

    Private Sub TxtTotal_KeyDown(sender As Object, e As KeyEventArgs) Handles TxtTotal.KeyDown
        If e.KeyCode = Keys.Enter Then
            MENote.Focus()
        End If
    End Sub

    Private Sub MENote_KeyDown(sender As Object, e As KeyEventArgs) Handles MENote.KeyDown
        If e.KeyCode = Keys.Enter Then
            BtnNext.Focus()
        End If
    End Sub

    Private Sub BtnMark_Click(sender As Object, e As EventArgs) Handles BtnMark.Click
        Cursor = Cursors.WaitCursor
        FormReportMark.report_mark_type = "136"
        FormReportMark.id_report = id
        FormReportMark.is_view = "1"
        FormReportMark.form_origin = Name
        FormReportMark.ShowDialog()
        Cursor = Cursors.Default
    End Sub

    Private Sub BtnCancell_Click(sender As Object, e As EventArgs) Handles BtnCancell.Click
        Dim confirm As DialogResult = DevExpress.XtraEditors.XtraMessageBox.Show("Are you sure you want to cancelled this budget ?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
        If confirm = Windows.Forms.DialogResult.Yes Then
            Cursor = Cursors.WaitCursor
            'status
            Dim query As String = "UPDATE tb_b_expense_propose SET id_report_status=5 WHERE id_b_expense_propose='" + id + "'"
            execute_non_query(query, True, "", "", "", "")

            'nonaktif mark
            Dim queryrm = String.Format("UPDATE tb_report_mark SET report_mark_lead_time=NULL,report_mark_start_datetime=NULL WHERE report_mark_type='{0}' AND id_report='{1}' AND id_report_status>'1'", 136, id, "5")
            execute_non_query(queryrm, True, "", "", "", "")

            'refresg
            FormBudgetExpensePropose.viewData()
            FormBudgetExpensePropose.GVData.FocusedRowHandle = find_row(FormBudgetExpensePropose.GVData, "id_b_expense_propose", id)
            actionLoad()
            Cursor = Cursors.Default
        End If
    End Sub

    Private Sub BtnAttachment_Click(sender As Object, e As EventArgs) Handles BtnAttachment.Click
        Cursor = Cursors.WaitCursor
        FormDocumentUpload.report_mark_type = "136"
        FormDocumentUpload.id_report = id
        If is_view = "1" Or id_report_status = "6" Or id_report_status = "5" Or is_confirm = "1" Then
            FormDocumentUpload.is_view = "1"
        End If
        FormDocumentUpload.ShowDialog()
        Cursor = Cursors.Default
    End Sub

    Private Sub BtnConfirm_Click(sender As Object, e As EventArgs) Handles BtnConfirm.Click
        Cursor = Cursors.WaitCursor
        'cek diff
        Dim cond As Boolean = True
        makeSafeGV(GVMonthly)
        GVMonthly.ActiveFilterString = "[diff]<>0"
        If GVMonthly.RowCount > 0 Then
            cond = False
        End If
        GVMonthly.ActiveFilterString = ""

        If Not cond Then
            stopCustom("Total input is not equal to the annual budget")
        Else
            Dim confirm As DialogResult = DevExpress.XtraEditors.XtraMessageBox.Show("Are you sure you want to confirm this budget ?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
            If confirm = Windows.Forms.DialogResult.Yes Then
                Cursor = Cursors.WaitCursor
                'update confirm
                Dim query As String = "UPDATE tb_b_expense_propose SET is_confirm=1 WHERE id_b_expense_propose='" + id + "'"
                execute_non_query(query, True, "", "", "", "")

                'submit approval
                submit_who_prepared(136, id, id_user)
                BtnConfirm.Visible = False
                action = "upd"
                actionLoad()
                infoCustom("Budget submitted. Waiting for approval.")
                Cursor = Cursors.Default
            End If
        End If
        Cursor = Cursors.Default
    End Sub


    Private Sub GVYearly_CellValueChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles GVYearlyCat.CellValueChanged
        Cursor = Cursors.WaitCursor
        Dim row_foc As String = e.RowHandle.ToString
        Dim old_val As Decimal = GVYearlyCat.ActiveEditor.OldEditValue
        Dim idy As String = GVYearlyCat.GetRowCellValue(row_foc, "id_b_expense_propose_year").ToString
        Dim year As String = TxtYear.Text
        Dim id_item_coa As String = GVYearlyCat.GetRowCellValue(row_foc, "id_item_coa").ToString
        Dim value_expense As String = decimalSQL(e.Value.ToString)
        If ((TxtTotYearlyCat.EditValue - old_val) + e.Value) <= TxtTotalYearly.EditValue Then
            If idy = "0" Then
                Dim query As String = "INSERT INTO tb_b_expense_propose_year(id_b_expense_propose, year, id_item_coa, value_expense)
                VALUES('" + id + "','" + year + "', '" + id_item_coa + "','" + value_expense + "'); "
                execute_non_query(query, True, "", "", "", "")
                GVYearlyCat.RefreshData()
                GVYearlyCat.BestFitColumns()
                getTotalYearlyCat()
            Else
                Dim queryupd As String = "UPDATE tb_b_expense_propose_year SET value_expense='" + value_expense + "'
                WHERE id_b_expense_propose_year='" + idy + "'; "
                execute_non_query(queryupd, True, "", "", "", "")
                GVYearlyCat.RefreshData()
                GVYearlyCat.BestFitColumns()
                viewDetailYearly()
                GVYearlyCat.FocusedRowHandle = find_row(GVYearlyCat, "id_b_expense_propose_year", idy)
            End If
        Else
            stopCustom("Total budget higher than yearly budget.")
            GVYearlyCat.SetRowCellValue(row_foc, "val", old_val)
            GVYearlyCat.RefreshData()
            GVYearlyCat.BestFitColumns()
        End If
        Cursor = Cursors.Default
    End Sub

    Private Sub FillReToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles FillReToolStripMenuItem.Click
        Cursor = Cursors.WaitCursor
        If XTCBudget.SelectedTabPageIndex = 1 Then
            GVYearlyCat.FocusedColumn = GVYearlyCat.Columns("val")
            GVYearlyCat.ShowEditor()
            GVYearlyCat.SetFocusedRowCellValue("val", TxtTotYearlyDiffCat.EditValue)
        ElseIf XTCBudget.SelectedTabPageIndex = 2 Then
            GVMonthly.ShowEditor()
            GVMonthly.SetFocusedRowCellValue(GVMonthly.FocusedColumn.FieldName, GVMonthly.GetFocusedRowCellValue("diff"))
        End If
        Cursor = Cursors.Default
    End Sub

    Private Sub AddWithRemainingQtyToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AddWithRemainingQtyToolStripMenuItem.Click
        Cursor = Cursors.WaitCursor
        If XTCBudget.SelectedTabPageIndex = 1 Then
            GVYearlyCat.FocusedColumn = GVYearlyCat.Columns("val")
            GVYearlyCat.ShowEditor()
            GVYearlyCat.SetFocusedRowCellValue("val", TxtTotYearlyDiffCat.EditValue + GVYearlyCat.ActiveEditor.OldEditValue)
        ElseIf XTCBudget.SelectedTabPageIndex = 2 Then
            GVMonthly.ShowEditor()
            GVMonthly.SetFocusedRowCellValue(GVMonthly.FocusedColumn.FieldName, GVMonthly.GetFocusedRowCellValue("diff") + GVMonthly.ActiveEditor.OldEditValue)
        End If
        Cursor = Cursors.Default
    End Sub

    Private Sub BtnDiffYearly_Click(sender As Object, e As EventArgs) Handles BtnDividedYearlyCat.Click
        Dim confirm As DialogResult = DevExpress.XtraEditors.XtraMessageBox.Show("Are you sure you want to divide equally value for all budget categories?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
        If confirm = Windows.Forms.DialogResult.Yes Then
            Cursor = Cursors.WaitCursor
            Dim val As Decimal = TxtTotalYearly.EditValue / GVYearlyCat.RowCount

            For i As Integer = 0 To ((GVYearlyCat.RowCount - 1) - GetGroupRowCount(GVYearlyCat))
                Dim idy As String = GVYearlyCat.GetRowCellValue(i, "id_b_expense_propose_year").ToString
                If idy = 0 Then
                    Dim query As String = "INSERT INTO tb_b_expense_propose_year(id_b_expense_propose, year, id_item_coa, value_expense) VALUES "
                    query += "('" + id + "', '" + TxtYear.Text + "', '" + GVYearlyCat.GetRowCellValue(i, "id_item_coa").ToString + "','" + decimalSQL(val.ToString) + "') "
                    execute_non_query(query, True, "", "", "", "")
                Else
                    Dim queryupd As String = "UPDATE tb_b_expense_propose_year SET value_expense ='" + decimalSQL(val.ToString) + "'
                    WHERE id_b_expense_propose_year='" + idy + "'"
                    execute_non_query(queryupd, True, "", "", "", "")
                End If

            Next
            viewDetailYearly()
            Cursor = Cursors.Default
        End If
    End Sub

    Private Sub BtnExportXLSYearlyCat_Click(sender As Object, e As EventArgs) Handles BtnExportXLSYearlyCat.Click
        Cursor = Cursors.WaitCursor
        GVYearlyCat.OptionsPrint.PrintFooter = False

        'export excel
        Dim printableComponentLink1 As New DevExpress.XtraPrinting.PrintableComponentLink(New DevExpress.XtraPrinting.PrintingSystem())
        Dim path_root As String = Application.StartupPath & "\download\"
        'create directory if not exist
        If Not IO.Directory.Exists(path_root) Then
            System.IO.Directory.CreateDirectory(path_root)
        End If
        Dim fileName As String = "bex_" + TxtYear.Text + "_" + id + ".xlsx"
        Dim exp As String = IO.Path.Combine(path_root, fileName)
        printableComponentLink1.Component = GCYearlyCat
        printableComponentLink1.CreateDocument()
        printableComponentLink1.ExportToXlsx(exp)
        Dim confirm As DialogResult = DevExpress.XtraEditors.XtraMessageBox.Show("Do you want to open file?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
        If confirm = Windows.Forms.DialogResult.Yes Then
            Process.Start(exp)
        End If
        Cursor = Cursors.Default
    End Sub

    Private Sub BtnImportXLSYearlyCat_Click(sender As Object, e As EventArgs) Handles BtnImportXLSYearlyCat.Click
        Cursor = Cursors.WaitCursor
        FormImportExcel.id_pop_up = "38"
        FormImportExcel.ShowDialog()
        Cursor = Cursors.Default
    End Sub

    Private Sub BtnPrintDraftYearlyCat_Click(sender As Object, e As EventArgs) Handles BtnPrintDraftYearlyCat.Click
        Cursor = Cursors.WaitCursor
        print_raw_no_export(GCYearlyCat)
        Cursor = Cursors.Default
    End Sub

    Private Sub GVYearlyMonth_CellValueChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles GVMonthly.CellValueChanged
        Cursor = Cursors.WaitCursor
        Dim old_val As Decimal = GVMonthly.ActiveEditor.OldEditValue
        Dim row_foc As Integer = e.RowHandle
        Dim id_b_expense_propose_year As String = GVMonthly.GetRowCellValue(row_foc, "id_b_expense_propose_year").ToString
        Dim month_split As String = e.Column.FieldName.ToString
        Dim month As String = GVMonthly.GetRowCellValue(row_foc, "year").ToString + "-" + e.Column.FieldName.ToString + "-" + "01"
        Dim value_expense As String = decimalSQL(e.Value.ToString)
        If GVMonthly.GetRowCellValue(row_foc, "total_input") <= GVMonthly.GetRowCellValue(row_foc, "total_yearly") Then
            Dim query As String = "DELETE FROM tb_b_expense_propose_month WHERE id_b_expense_propose_year='" + id_b_expense_propose_year + "'
            AND month='" + month + "';
            INSERT INTO tb_b_expense_propose_month(id_b_expense_propose_year, month, value_expense) VALUES
            ('" + id_b_expense_propose_year + "', '" + month + "', '" + value_expense + "'); "
            execute_non_query(query, True, "", "", "", "")
            GVMonthly.RefreshData()
            GVMonthly.BestFitColumns()
        Else
            stopCustom("Total input higher than annual budget.")
            GVMonthly.SetRowCellValue(row_foc, month_split, old_val)
            GVMonthly.RefreshData()
            GVMonthly.BestFitColumns()
        End If
        Cursor = Cursors.Default
    End Sub

    Private Sub GVYearlyMonth_ValidateRow(sender As Object, e As DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs) Handles GVMonthly.ValidateRow
        'Dim View As DevExpress.XtraGrid.Views.Grid.GridView = CType(sender, DevExpress.XtraGrid.Views.Grid.GridView)
        'If View.GetRowCellValue(e.RowHandle, "total_input") <= View.GetRowCellValue(e.RowHandle, "total_yearly") Then
        '    e.Valid = False
        'End If
    End Sub

    Private Sub CMSYearlyCat_Opened(sender As Object, e As EventArgs) Handles CMSYearlyCat.Opened
        FillReToolStripMenuItem.Visible = True
        AddWithRemainingQtyToolStripMenuItem.Visible = True
        If XTCBudget.SelectedTabPageIndex = 2 Then
            Dim col As String = GVMonthly.FocusedColumn.FieldName.ToString
            If col = "1" Or col = "2" Or col = "3" Or col = "4" Or col = "5" Or col = "6" Or col = "7" Or col = "8" Or col = "9" Or col = "10" Or col = "11" Or col = "12" Then
                FillReToolStripMenuItem.Visible = True
                AddWithRemainingQtyToolStripMenuItem.Visible = True
            Else
                FillReToolStripMenuItem.Visible = False
                AddWithRemainingQtyToolStripMenuItem.Visible = False
            End If
        End If
    End Sub



    Private Sub DividedEquallyToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DividedEquallyToolStripMenuItem.Click
        If XTCBudget.SelectedTabPageIndex = 2 And GVMonthly.RowCount > 0 Then
            Dim confirm As DialogResult = DevExpress.XtraEditors.XtraMessageBox.Show("Are you sure you want to divide equally value for all month for this category?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
            If confirm = Windows.Forms.DialogResult.Yes Then
                Cursor = Cursors.WaitCursor
                Dim id_b_expense_propose_year As String = GVMonthly.GetFocusedRowCellValue("id_b_expense_propose_year").ToString
                Dim val As String = decimalSQL(GVMonthly.GetFocusedRowCellValue("total_yearly") / 12)
                Dim query As String = "DELETE FROM tb_b_expense_propose_month WHERE id_b_expense_propose_year=" + id_b_expense_propose_year + ";
                INSERT INTO tb_b_expense_propose_month(id_b_expense_propose_year,month,value_expense) VALUES "
                For i As Integer = 1 To 12
                    If i > 1 Then
                        query += ", "
                    End If
                    Dim mth As String = ""
                    If i < 10 Then
                        mth = "0" + i.ToString
                    Else
                        mth = i.ToString
                    End If
                    Dim m As String = GVMonthly.GetFocusedRowCellValue("year").ToString + "-" + mth + "-" + "01"
                    query += "('" + id_b_expense_propose_year + "', '" + m + "', '" + val + "') "
                Next
                execute_non_query(query, True, "", "", "", "")
                viewDetailMonthly()
                GVMonthly.FocusedRowHandle = find_row(GVMonthly, "id_b_expense_propose_year", id_b_expense_propose_year)
                Cursor = Cursors.Default
            End If
        End If
    End Sub

    Private Sub BtnDividedMonthlyCat_Click(sender As Object, e As EventArgs) Handles BtnDividedMonthlyCat.Click
        Dim confirm As DialogResult = DevExpress.XtraEditors.XtraMessageBox.Show("Are you sure you want to divide equally value for all month?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
        If confirm = Windows.Forms.DialogResult.Yes Then
            Cursor = Cursors.WaitCursor
            For j As Integer = 0 To ((GVMonthly.RowCount - 1) - GetGroupRowCount(GVMonthly))
                Dim id_b_expense_propose_year As String = GVMonthly.GetRowCellValue(j, "id_b_expense_propose_year").ToString
                Dim val As String = decimalSQL(GVMonthly.GetRowCellValue(j, "total_yearly") / 12)
                Dim query As String = "DELETE FROM tb_b_expense_propose_month WHERE id_b_expense_propose_year=" + id_b_expense_propose_year + ";
                INSERT INTO tb_b_expense_propose_month(id_b_expense_propose_year,month,value_expense) VALUES "
                For i As Integer = 1 To 12
                    If i > 1 Then
                        query += ", "
                    End If
                    Dim mth As String = ""
                    If i < 10 Then
                        mth = "0" + i.ToString
                    Else
                        mth = i.ToString
                    End If
                    Dim m As String = GVMonthly.GetRowCellValue(j, "year").ToString + "-" + mth + "-" + "01"
                    query += "('" + id_b_expense_propose_year + "', '" + m + "', '" + val + "') "
                Next
                execute_non_query(query, True, "", "", "", "")
            Next
            viewDetailMonthly()
            Cursor = Cursors.Default
        End If
    End Sub

    Private Sub BtnExportXLSMonthly_Click(sender As Object, e As EventArgs) Handles BtnExportXLSMonthly.Click
        Cursor = Cursors.WaitCursor
        'save tampilan awal
        Dim str As System.IO.Stream
        str = New System.IO.MemoryStream()
        GVMonthly.SaveLayoutToStream(str, DevExpress.Utils.OptionsLayoutBase.FullLayout)
        str.Seek(0, System.IO.SeekOrigin.Begin)

        'custom column
        GVMonthly.Columns("1").Caption = "1"
        GVMonthly.Columns("2").Caption = "2"
        GVMonthly.Columns("3").Caption = "3"
        GVMonthly.Columns("4").Caption = "4"
        GVMonthly.Columns("5").Caption = "5"
        GVMonthly.Columns("6").Caption = "6"
        GVMonthly.Columns("7").Caption = "7"
        GVMonthly.Columns("8").Caption = "8"
        GVMonthly.Columns("9").Caption = "9"
        GVMonthly.Columns("10").Caption = "10"
        GVMonthly.Columns("11").Caption = "11"
        GVMonthly.Columns("12").Caption = "12"
        GVMonthly.Columns("total_yearly").VisibleIndex = 3
        GVMonthly.Columns("total_input").Visible = False
        GVMonthly.Columns("diff").Visible = False

        'export excel
        GVMonthly.OptionsPrint.PrintFooter = False
        Dim printableComponentLink1 As New DevExpress.XtraPrinting.PrintableComponentLink(New DevExpress.XtraPrinting.PrintingSystem())
        Dim path_root As String = Application.StartupPath & "\download\"
        'create directory if not exist
        If Not IO.Directory.Exists(path_root) Then
            System.IO.Directory.CreateDirectory(path_root)
        End If
        Dim fileName As String = "bex_m_" + TxtYear.Text + "_" + id + ".xlsx"
        Dim exp As String = IO.Path.Combine(path_root, fileName)
        printableComponentLink1.Component = GCMonthly
        printableComponentLink1.CreateDocument()
        printableComponentLink1.ExportToXlsx(exp)
        Dim confirm As DialogResult = DevExpress.XtraEditors.XtraMessageBox.Show("Do you want to open file?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
        If confirm = Windows.Forms.DialogResult.Yes Then
            Process.Start(exp)
        End If

        'reset tampilan awal
        GVMonthly.RestoreLayoutFromStream(str, DevExpress.Utils.OptionsLayoutBase.FullLayout)
        str.Seek(0, System.IO.SeekOrigin.Begin)
        Cursor = Cursors.Default
    End Sub

    Private Sub BtnImportXLSMonthly_Click(sender As Object, e As EventArgs) Handles BtnImportXLSMonthly.Click
        Cursor = Cursors.WaitCursor
        FormImportExcel.id_pop_up = "39"
        FormImportExcel.ShowDialog()
        Cursor = Cursors.Default
    End Sub

    Private Sub BtnPrintDraftMonthlyCat_Click(sender As Object, e As EventArgs) Handles BtnPrintDraftMonthlyCat.Click
        Cursor = Cursors.WaitCursor
        print_raw_no_export(GCMonthly)
        Cursor = Cursors.Default
    End Sub

    Private Sub BtnPrint_Click(sender As Object, e As EventArgs) Handles BtnPrint.Click
        Dim selected As Integer = XTCBudget.SelectedTabPageIndex
        If selected = 0 Then

        ElseIf selected = 1 Then
            Cursor = Cursors.WaitCursor
            ReportBudgetExpense.id = id
            ReportBudgetExpense.dt = GCYearlyCat.DataSource
            Dim Report As New ReportBudgetExpense()

            ' '... 
            ' ' creating and saving the view's layout to a new memory stream 
            Dim str As System.IO.Stream
            str = New System.IO.MemoryStream()
            GVYearlyCat.SaveLayoutToStream(str, DevExpress.Utils.OptionsLayoutBase.FullLayout)
            str.Seek(0, System.IO.SeekOrigin.Begin)
            Report.GVData.RestoreLayoutFromStream(str, DevExpress.Utils.OptionsLayoutBase.FullLayout)
            str.Seek(0, System.IO.SeekOrigin.Begin)

            'Grid Detail
            ReportStyleGridview(Report.GVData)

            'Parse val
            Report.LabelNumber.Text = TxtNumber.Text.ToUpper
            Report.LabelYear.Text = TxtYear.Text.ToUpper
            Report.LabelDept.Text = LEDeptSum.Text.ToUpper
            Report.LabelDate.Text = DECreated.Text.ToString

            'Show the report's preview. 
            Dim Tool As DevExpress.XtraReports.UI.ReportPrintTool = New DevExpress.XtraReports.UI.ReportPrintTool(Report)
            Tool.PrintingSystem.SetCommandVisibility(DevExpress.XtraPrinting.PrintingSystemCommand.ExportFile, DevExpress.XtraPrinting.CommandVisibility.None)
            Tool.PrintingSystem.SetCommandVisibility(DevExpress.XtraPrinting.PrintingSystemCommand.SendFile, DevExpress.XtraPrinting.CommandVisibility.None)
            Tool.ShowRibbonPreviewDialog()
            Cursor = Cursors.Default
        ElseIf selected = 2 Then
            Cursor = Cursors.WaitCursor
            ReportBudgetExpense.id = id
            ReportBudgetExpense.dt = GCMonthly.DataSource
            Dim Report As New ReportBudgetExpense()

            ' '... 
            ' ' creating and saving the view's layout to a new memory stream 
            Dim str As System.IO.Stream
            str = New System.IO.MemoryStream()
            GVMonthly.SaveLayoutToStream(str, DevExpress.Utils.OptionsLayoutBase.FullLayout)
            str.Seek(0, System.IO.SeekOrigin.Begin)
            Report.GVData.RestoreLayoutFromStream(str, DevExpress.Utils.OptionsLayoutBase.FullLayout)
            str.Seek(0, System.IO.SeekOrigin.Begin)

            'Grid Detail
            ReportStyleGridview(Report.GVData)

            'Parse val
            Report.LabelNumber.Text = TxtNumber.Text.ToUpper
            Report.LabelYear.Text = TxtYear.Text.ToUpper
            Report.LabelDept.Text = LEDeptSum.Text.ToUpper
            Report.LabelDate.Text = DECreated.Text.ToString

            'Show the report's preview. 
            Dim Tool As DevExpress.XtraReports.UI.ReportPrintTool = New DevExpress.XtraReports.UI.ReportPrintTool(Report)
            Tool.PrintingSystem.SetCommandVisibility(DevExpress.XtraPrinting.PrintingSystemCommand.ExportFile, DevExpress.XtraPrinting.CommandVisibility.None)
            Tool.PrintingSystem.SetCommandVisibility(DevExpress.XtraPrinting.PrintingSystemCommand.SendFile, DevExpress.XtraPrinting.CommandVisibility.None)
            Tool.ShowRibbonPreviewDialog()
            Cursor = Cursors.Default
        End If
    End Sub
End Class