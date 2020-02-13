Public Class FormCashAdvanceReconcile
    Public id_ca As String = ""
    Public is_view As String = "1"
    Public lock As Boolean = False

    Private Sub FormCashAdvanceReconcile_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()

        FormCashAdvance.load_cash_advance()
        FormCashAdvance.GVListOpen.FocusedRowHandle = find_row(FormCashAdvance.GVListOpen, "id_cash_advance", id_ca)
    End Sub

    Private Sub FormCashAdvanceReconcile_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        load_form()
    End Sub

    Sub load_form()
        load_type()
        load_employee()
        load_dep()
        '
        load_acc()
        load_comp()
        '
        load_det()
        load_ca()
    End Sub

    Sub load_acc()
        Dim query As String = "SELECT id_acc, acc_name, acc_description FROM tb_a_acc WHERE id_is_det='2'"
        viewSearchLookupRepositoryQuery(RSLECOA, query, 0, "acc_name", "id_acc")
        viewSearchLookupRepositoryQuery(RSLECOABW, query, 0, "acc_name", "id_acc")
        viewSearchLookupRepositoryQuery(RSLECOABD, query, 0, "acc_name", "id_acc")
    End Sub

    Sub load_comp()
        Dim query As String = "SELECT id_comp, comp_number, comp_name FROM tb_m_comp"
        viewSearchLookupRepositoryQuery(RSLEComp, query, 0, "comp_number", "id_comp")
    End Sub

    Sub load_det()
        Dim query As String = ""

        'report
        query = "SELECT *, (SELECT acc_description FROM tb_a_acc WHERE id_acc = tb_cash_advance_report.id_acc) AS acc_description, (SELECT acc_name FROM tb_a_acc WHERE id_acc = tb_cash_advance_report.id_acc) AS acc_name FROM tb_cash_advance_report WHERE id_cash_advance='" & id_ca & "'"
        Dim dataReport As DataTable = execute_query(query, -1, True, "", "", "", "")

        GCJournalDet.DataSource = dataReport
        GVJournalDet.BestFitColumns()

        check_but()

        BMark.Enabled = False
        BPrint.Enabled = False
        SBReset.Enabled = False

        'check status
        query = "
            SELECT ca.*, IF(ca.rb_id_report_status != 6 AND IFNULL(recon.jml, 0) <= 0, 'Open', IF(ca.rb_id_report_status = 6, 'Closed', 'On Process')) AS rb_status FROM tb_cash_advance AS ca
            LEFT JOIN 
            (
                SELECT id_cash_advance, COUNT(id_cash_advance) AS jml FROM tb_cash_advance_report GROUP BY id_cash_advance
                UNION
                SELECT id_cash_advance, COUNT(id_cash_advance) AS jml FROM tb_cash_advance_report_det GROUP BY id_cash_advance
            ) recon ON recon.id_cash_advance = ca.id_cash_advance
             WHERE ca.id_cash_advance = '" & id_ca & "'"
        Dim dataCash As DataTable = execute_query(query, -1, True, "", "", "", "")

        'load status
        TEStatus.EditValue = dataCash.Rows(0)("rb_status").ToString

        'check
        If dataReport.Rows.Count > 0 Then
            lock = True
        End If

        check_lock()

        'report detail
        query = "SELECT *, (SELECT acc_description FROM tb_a_acc WHERE id_acc = tb_cash_advance_report_det.id_acc) AS acc_description, (SELECT acc_name FROM tb_a_acc WHERE id_acc = tb_cash_advance_report_det.id_acc) AS acc_name FROM tb_cash_advance_report_det WHERE id_cash_advance='" & id_ca & "'"
        Dim dataDetail As DataTable = execute_query(query, -1, True, "", "", "", "")

        GVBankWithdrawal.OptionsBehavior.Editable = True
        GVBankDeposit.OptionsBehavior.Editable = True

        If dataDetail.Rows.Count > 0 Then
            If dataDetail.Rows(0)("id_bill_type").ToString = "22" Then
                XTPWithdrawal.PageVisible = True

                GCBankWithdrawal.DataSource = dataDetail
                GVBankWithdrawal.BestFitColumns()

                GVBankWithdrawal.OptionsBehavior.Editable = False
            ElseIf dataDetail.Rows(0)("id_bill_type").ToString = "21"
                XTPDeposit.PageVisible = True

                GCBankDeposit.DataSource = dataDetail
                GVBankDeposit.BestFitColumns()

                GVBankDeposit.OptionsBehavior.Editable = False
            End If
        End If

        BLock.Enabled = True

        If dataReport.Rows.Count > 0 Or dataDetail.Rows.Count > 0 Then
            BSave.Enabled = False
            BLock.Enabled = False
            BMark.Enabled = True
            BPrint.Enabled = True
            SBReset.Enabled = True
        End If

        If dataCash.Rows(0)("rb_id_report_status").ToString = "6" Then
            BtnViewJournal.Enabled = True
            SBReset.Enabled = False
        End If
    End Sub

    Sub check_but()
        If GVJournalDet.RowCount = 0 Then
            BDelete.Visible = False
        Else
            BDelete.Visible = True
        End If
        '
        If GVBankWithdrawal.RowCount = 0 Then
            BDelBBK.Visible = False
        Else
            BDelBBK.Visible = True
        End If
        '
        If GVBankDeposit.RowCount = 0 Then
            BDelBBM.Visible = False
        Else
            BDelBBM.Visible = True
        End If
    End Sub

    Sub load_type()
        Dim query As String = "SELECT id_cash_advance_type,cash_advance_type FROM tb_lookup_cash_advance_type"
        viewSearchLookupQuery(SLEType, query, "id_cash_advance_type", "cash_advance_type", "id_cash_advance_type")
    End Sub

    Sub load_dep()
        Dim query As String = "SELECT id_departement,departement FROM tb_m_departement"
        viewSearchLookupQuery(SLEDepartement, query, "id_departement", "departement", "id_departement")
    End Sub

    Sub load_employee()
        Dim query As String = "SELECT id_employee,id_departement,employee_name FROM tb_m_employee"
        viewSearchLookupQuery(SLEEmployee, query, "id_employee", "employee_name", "id_employee")
    End Sub

    Sub load_ca()
        Dim query As String = "SELECT * FROM tb_cash_advance WHERE id_cash_advance='" & id_ca & "'"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        If data.Rows.Count > 0 Then
            TENumber.Text = data.Rows(0)("number").ToString
            '
            If data.Rows(0)("act_report_back_date").ToString = "" Then
                DEActualReconcileDate.EditValue = Now
            Else
                DEActualReconcileDate.EditValue = data.Rows(0)("act_report_back_date").ToString
            End If
            '
            DEStartReconcile.EditValue = data.Rows(0)("report_back_date")
            DEDueDate.EditValue = data.Rows(0)("report_back_due_date")
            '
            SLEType.EditValue = data.Rows(0)("id_cash_advance_type").ToString
            SLEEmployee.EditValue = data.Rows(0)("id_employee").ToString
            SLEDepartement.EditValue = data.Rows(0)("id_departement").ToString
            '
            TECashInAdvance.EditValue = Math.Round(data.Rows(0)("val_ca"), 2)
            MENote.EditValue = data.Rows(0)("note").ToString
            '
            check_but()
        End If
    End Sub

    Sub check_lock()
        If lock Then
            BDelete.Enabled = False
            BAdd.Enabled = False
            GVJournalDet.OptionsBehavior.Editable = False
            BLock.Text = "Unlock"

            BSave.Enabled = True
        Else
            BDelete.Enabled = True
            BAdd.Enabled = True
            GVJournalDet.OptionsBehavior.Editable = True
            BLock.Text = "Lock"

            GCBankWithdrawal.DataSource = Nothing
            GCBankDeposit.DataSource = Nothing

            XTPWithdrawal.PageVisible = False
            XTPDeposit.PageVisible = False

            BSave.Enabled = False
        End If
    End Sub

    Private Sub BDelete_Click(sender As Object, e As EventArgs) Handles BDelete.Click
        If GVJournalDet.RowCount > 0 Then
            GVJournalDet.DeleteSelectedRows()
        End If
    End Sub

    Private Sub BCancel_Click(sender As Object, e As EventArgs) Handles BCancel.Click
        Close()
    End Sub

    Private Sub BAdd_Click(sender As Object, e As EventArgs) Handles BAdd.Click
        GVJournalDet.AddNewRow()
        GVJournalDet.FocusedRowHandle = GVJournalDet.RowCount - 1
        GVJournalDet.SetRowCellValue(GVJournalDet.RowCount - 1, "id_comp", "1")
        check_but()
    End Sub

    Private Sub BSave_Click(sender As Object, e As EventArgs) Handles BSave.Click
        'check
        Dim acc_selected = True
        Dim val_ok = True
        Dim attachment = True

        If XTPWithdrawal.PageVisible Then
            For i = 0 To GVBankWithdrawal.RowCount - 1
                If GVBankWithdrawal.GetRowCellValue(i, "id_acc").ToString = "" Then
                    acc_selected = False
                End If
            Next
            '
            If Not GVJournalDet.Columns("value").SummaryItem.SummaryValue - GVBankWithdrawal.Columns("value").SummaryItem.SummaryValue = TECashInAdvance.EditValue Then
                val_ok = False
            End If
        ElseIf XTPDeposit.PageVisible Then
            For i = 0 To GVBankDeposit.RowCount - 1
                If GVBankDeposit.GetRowCellValue(i, "id_acc").ToString = "" Then
                    acc_selected = False
                End If
            Next
            '
            If Not GVBankDeposit.Columns("value").SummaryItem.SummaryValue + GVJournalDet.Columns("value").SummaryItem.SummaryValue = TECashInAdvance.EditValue Then
                val_ok = False
            End If
        End If

        'attachment
        'attachment = If(execute_query("SELECT COUNT(*) FROM tb_doc WHERE report_mark_type = 174 AND id_report = " + id_ca, 0, True, "", "", "", "") = "0", False, True)

        'save
        If acc_selected = False Then
            If XTPWithdrawal.PageVisible Then
                XTCCA.SelectedTabPageIndex = 1
            ElseIf XTPDeposit.PageVisible Then
                XTCCA.SelectedTabPageIndex = 2
            End If

            warningCustom("Please check your account")
        ElseIf val_ok = False Then
            If XTPWithdrawal.PageVisible Then
                XTCCA.SelectedTabPageIndex = 1
            ElseIf XTPDeposit.PageVisible Then
                XTCCA.SelectedTabPageIndex = 2
            End If

            warningCustom("Please make sure your cash is balance")
        ElseIf Not attachment Then
            warningCustom("Please add attachment")
        Else
            Dim query As String = ""

            If GVJournalDet.RowCount > 0 Then
                'report
                query = "INSERT INTO tb_cash_advance_report(id_cash_advance,id_acc,id_comp,description,value,note) VALUES"
                For i As Integer = 0 To GVJournalDet.RowCount - 1
                    query += If(Not i = 0, ",", "")

                    query += "('" & id_ca & "','" & GVJournalDet.GetRowCellValue(i, "id_acc").ToString & "','" & GVJournalDet.GetRowCellValue(i, "id_comp").ToString & "','" & GVJournalDet.GetRowCellValue(i, "description").ToString & "','" & decimalSQL(GVJournalDet.GetRowCellValue(i, "value").ToString) & "','" & addSlashes(GVJournalDet.GetRowCellValue(i, "note").ToString) & "')"
                Next

                execute_non_query(query, True, "", "", "", "")
            End If

            'report detail
            Dim id_bill_type As String = ""
            Dim GVSelected As DevExpress.XtraGrid.Views.Grid.GridView = Nothing
            If XTPWithdrawal.PageVisible Then
                id_bill_type = "22"
                GVSelected = GVBankWithdrawal
            ElseIf XTPDeposit.PageVisible Then
                id_bill_type = "21"
                GVSelected = GVBankDeposit
            End If

            If XTPWithdrawal.PageVisible Or XTPDeposit.PageVisible Then
                'loop
                For i As Integer = 0 To GVSelected.RowCount - 1
                    query = "INSERT INTO tb_cash_advance_report_det(id_cash_advance,id_acc,description,value,note,id_bill_type) VALUES ('" & id_ca & "', '" & GVSelected.GetRowCellValue(i, "id_acc").ToString & "', '" & addSlashes(GVSelected.GetRowCellValue(i, "description").ToString) & "', '" & decimalSQL(GVSelected.GetRowCellValue(i, "value").ToString) & "', '" & addSlashes(GVSelected.GetRowCellValue(i, "note").ToString) & "', '" & id_bill_type & "')"
                Next

                execute_non_query(query, True, "", "", "", "")
            End If
            '
            query = "UPDATE tb_cash_advance SET act_report_back_date=NOW() WHERE id_cash_advance='" & id_ca & "'"
            execute_non_query(query, True, "", "", "", "")
            '
            infoCustom("Report saved")

            'add mark
            submit_who_prepared("174", id_ca, id_user)

            load_det()
        End If
    End Sub

    Private Sub RSLECOA_EditValueChanged(sender As Object, e As EventArgs) Handles RSLECOA.EditValueChanged
        Try
            Dim sle As DevExpress.XtraEditors.SearchLookUpEdit = CType(sender, DevExpress.XtraEditors.SearchLookUpEdit)
            GVJournalDet.SetFocusedRowCellValue("description", sle.Properties.View.GetFocusedRowCellValue("acc_description"))
            GVJournalDet.SetFocusedRowCellValue("acc_description", sle.Properties.View.GetFocusedRowCellValue("acc_description"))
        Catch ex As Exception
        End Try
    End Sub

    Private Sub GVJournalDet_InitNewRow(sender As Object, e As DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs) Handles GVJournalDet.InitNewRow
        Dim view As DevExpress.XtraGrid.Views.Grid.GridView = CType(sender, DevExpress.XtraGrid.Views.Grid.GridView)
        view.SetRowCellValue(e.RowHandle, view.Columns("value"), 0.00)
    End Sub

    Private Sub BLock_Click(sender As Object, e As EventArgs) Handles BLock.Click
        If lock Then
            lock = False

            check_lock()
        Else
            If GVJournalDet.RowCount = 0 Then
                'warningCustom("Please insert detail report first")

                lock = True

                check_lock()

                Dim data As DataTable = execute_query("SELECT 0 AS id_cash_advance_report, 0 AS is_val_ca, NULL AS id_acc, '' AS description, '' AS note, " + decimalSQL(TECashInAdvance.EditValue) + " AS value", -1, True, "", "", "", "")
                GCBankDeposit.DataSource = data

                XTPWithdrawal.PageVisible = False
                XTPDeposit.PageVisible = True

                XTCCA.SelectedTabPageIndex = 2
            Else
                Dim acc_selected = True
                Dim value_selected = True

                For i = 0 To GVJournalDet.RowCount - 1
                    If GVJournalDet.GetRowCellValue(i, "id_acc").ToString = "" Then
                        acc_selected = False
                    End If

                    If GVJournalDet.GetRowCellValue(i, "value").ToString = "0" Then
                        value_selected = False
                    End If
                Next

                If acc_selected And value_selected Then
                    Dim rest As Decimal = TECashInAdvance.EditValue - GVJournalDet.Columns("value").SummaryItem.SummaryValue

                    GCBankWithdrawal.DataSource = Nothing
                    GCBankDeposit.DataSource = Nothing

                    If rest > 0 Then
                        Dim data As DataTable = execute_query("SELECT 0 AS id_cash_advance_report, 0 AS is_val_ca, NULL AS id_acc, '' AS description, '' AS note, " + decimalSQL(rest) + " AS value", -1, True, "", "", "", "")
                        GCBankDeposit.DataSource = data

                        XTPWithdrawal.PageVisible = False
                        XTPDeposit.PageVisible = True

                        XTCCA.SelectedTabPageIndex = 2
                    ElseIf rest < 0 Then
                        rest = Math.Abs(rest)

                        Dim data As DataTable = execute_query("SELECT 0 AS id_cash_advance_report, 0 AS is_val_ca, NULL AS id_acc, '' AS description, '' AS note, " + decimalSQL(rest) + " AS value", -1, True, "", "", "", "")
                        GCBankWithdrawal.DataSource = data

                        XTPWithdrawal.PageVisible = True
                        XTPDeposit.PageVisible = False

                        XTCCA.SelectedTabPageIndex = 1
                    End If

                    lock = True

                    check_lock()
                Else
                    If Not acc_selected Then
                        warningCustom("Please insert account")
                    ElseIf Not value_selected Then
                        warningCustom("Value cannot be 0")
                    End If
                End If
            End If
        End If
    End Sub

    Private Sub RSLECOABW_EditValueChanged(sender As Object, e As EventArgs) Handles RSLECOABW.EditValueChanged
        Try
            Dim sle As DevExpress.XtraEditors.SearchLookUpEdit = CType(sender, DevExpress.XtraEditors.SearchLookUpEdit)
            GVBankWithdrawal.SetFocusedRowCellValue("description", sle.Properties.View.GetFocusedRowCellValue("acc_description"))
            GVBankWithdrawal.SetFocusedRowCellValue("acc_description", sle.Properties.View.GetFocusedRowCellValue("acc_description"))
        Catch ex As Exception
        End Try
    End Sub

    Private Sub RSLECOABD_EditValueChanged(sender As Object, e As EventArgs) Handles RSLECOABD.EditValueChanged
        Try
            Dim sle As DevExpress.XtraEditors.SearchLookUpEdit = CType(sender, DevExpress.XtraEditors.SearchLookUpEdit)
            GVBankDeposit.SetFocusedRowCellValue("description", sle.Properties.View.GetFocusedRowCellValue("acc_description"))
            GVBankDeposit.SetFocusedRowCellValue("acc_description", sle.Properties.View.GetFocusedRowCellValue("acc_description"))
        Catch ex As Exception
        End Try
    End Sub

    Private Sub BMark_Click(sender As Object, e As EventArgs) Handles BMark.Click
        FormReportMark.report_mark_type = "174"
        FormReportMark.is_view = is_view
        FormReportMark.id_report = id_ca
        FormReportMark.ShowDialog()
    End Sub

    Private Sub BtnViewJournal_Click(sender As Object, e As EventArgs) Handles BtnViewJournal.Click
        Cursor = Cursors.WaitCursor
        Dim id_acc_trans As String = ""
        Try
            id_acc_trans = execute_query("SELECT ad.id_acc_trans FROM tb_a_acc_trans_det ad
            WHERE ad.report_mark_type=174 AND ad.id_report=" + id_ca + "
            GROUP BY ad.id_acc_trans ", 0, True, "", "", "", "")
        Catch ex As Exception
            id_acc_trans = ""
        End Try

        If id_acc_trans <> "" Then
            Dim s As New ClassShowPopUp()
            FormViewJournal.is_enable_view_doc = False
            FormViewJournal.BMark.Visible = False
            s.id_report = id_acc_trans
            s.report_mark_type = "36"
            s.show()
        Else
            warningCustom("Auto journal not found.")
        End If
        Cursor = Cursors.Default
    End Sub

    Private Sub BPrint_Click(sender As Object, e As EventArgs) Handles BPrint.Click
        Cursor = Cursors.WaitCursor
        ReportCashAdvanceReconcile.id_ca = id_ca
        ReportCashAdvanceReconcile.dt = GCJournalDet.DataSource
        Dim Report As New ReportCashAdvanceReconcile()
        'Parse val
        Report.LNumber.Text = TENumber.Text
        Report.XLEmployee.Text = SLEEmployee.Text
        Report.XLDepartement.Text = SLEDepartement.Text
        Report.XLCashAdvance.Text = "Rp. " + TECashInAdvance.Text
        Report.XLPropose.Text = MENote.Text
        Report.XLTypeCash.Text = SLEType.Text
        Report.XLRecDate.Text = DEStartReconcile.Text
        Report.XLRecDueDate.Text = DEDueDate.Text
        If XTPWithdrawal.PageVisible Then
            Report.XLType.Text = "Bank Withdrawal (BBK)"
            Report.XLAccName.Text = GVBankWithdrawal.GetRowCellValue(0, "acc_name")
            Report.XLAcc.Text = GVBankWithdrawal.GetRowCellValue(0, "acc_description")
            Report.XLTypeNumber.Text = "Rp. " + String.Format("{0:#,##0.00}", GVBankWithdrawal.GetRowCellValue(0, "value"))
        ElseIf XTPDeposit.PageVisible Then
            Report.XLType.Text = "Bank Deposit (BBM)"
            Report.XLAccName.Text = GVBankDeposit.GetRowCellValue(0, "acc_name")
            Report.XLAcc.Text = GVBankDeposit.GetRowCellValue(0, "acc_description")
            Report.XLTypeNumber.Text = "Rp. " + String.Format("{0:#,##0.00}", GVBankDeposit.GetRowCellValue(0, "value"))
        Else
            Report.XLType.Visible = False
            Report.XLAccName.Visible = False
            Report.XLAcc.Visible = False
            Report.XLTypeNumber.Visible = False
        End If

        If TEStatus.EditValue.ToString = "Closed" Then
            Report.id_pre = "-1"
        Else
            Report.id_pre = "1"
        End If

        'Show the report's preview. 
        Dim Tool As DevExpress.XtraReports.UI.ReportPrintTool = New DevExpress.XtraReports.UI.ReportPrintTool(Report)
        Tool.ShowPreview()
        Cursor = Cursors.Default
    End Sub

    Private Sub BAddBBK_Click(sender As Object, e As EventArgs) Handles BAddBBK.Click
        GVBankWithdrawal.AddNewRow()
        GVBankWithdrawal.FocusedRowHandle = GVBankWithdrawal.RowCount - 1
        check_but()
    End Sub

    Private Sub BDelBBK_Click(sender As Object, e As EventArgs) Handles BDelBBK.Click
        If GVBankWithdrawal.RowCount > 0 Then
            GVBankWithdrawal.DeleteSelectedRows()
            check_but()
        End If
    End Sub

    Private Sub BAddBBM_Click(sender As Object, e As EventArgs) Handles BAddBBM.Click
        GVBankDeposit.AddNewRow()
        GVBankDeposit.FocusedRowHandle = GVBankWithdrawal.RowCount - 1
        check_but()
    End Sub

    Private Sub BDelBBM_Click(sender As Object, e As EventArgs) Handles BDelBBM.Click
        If GVBankDeposit.RowCount > 0 Then
            GVBankDeposit.DeleteSelectedRows()
            check_but()
        End If
    End Sub

    Private Sub SBReset_Click(sender As Object, e As EventArgs) Handles SBReset.Click
        Dim confirm As DialogResult

        confirm = DevExpress.XtraEditors.XtraMessageBox.Show("All approval will be reset. Are you sure want to reset ?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)

        If confirm = DialogResult.Yes Then
            Cursor = Cursors.WaitCursor

            Dim query As String = ""

            query = "DELETE FROM tb_cash_advance_report WHERE id_cash_advance = " + id_ca

            execute_non_query(query, True, "", "", "", "")

            query = "DELETE FROM tb_cash_advance_report_det WHERE id_cash_advance = " + id_ca

            execute_non_query(query, True, "", "", "", "")

            query = "UPDATE tb_cash_advance SET act_report_back_date = NULL, rb_id_report_status = 1 WHERE id_cash_advance = " + id_ca

            execute_non_query(query, True, "", "", "", "")

            query = "DELETE FROM tb_report_mark WHERE report_mark_type = 174 AND id_report = " + id_ca

            execute_non_query(query, True, "", "", "", "")

            XTPWithdrawal.PageVisible = False
            XTPDeposit.PageVisible = False

            lock = False

            load_form()

            Cursor = Cursors.Default
        End If
    End Sub

    Private Sub SBAttachment_Click(sender As Object, e As EventArgs) Handles SBAttachment.Click
        Cursor = Cursors.WaitCursor

        Dim is_view As String = execute_query("SELECT IF((SELECT COUNT(*) FROM tb_cash_advance_report WHERE id_cash_advance = " + id_ca + ") = 0, -1, 1) AS is_view", 0, True, "", "", "", "")

        FormDocumentUpload.is_view = is_view
        FormDocumentUpload.id_report = id_ca
        FormDocumentUpload.report_mark_type = "174"
        FormDocumentUpload.ShowDialog()

        Cursor = Cursors.Default
    End Sub

    Private Sub XTCCA_SelectedPageChanged(sender As Object, e As DevExpress.XtraTab.TabPageChangedEventArgs) Handles XTCCA.SelectedPageChanged
        check_but()
    End Sub
End Class