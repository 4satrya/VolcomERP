Public Class FormEmpPayroll
    Public is_view As String = "2"
    Dim bnew_active As String = "0"
    Dim bedit_active As String = "0"
    Dim bdel_active As String = "0"
    '
    Public no_column As String = 16
    '
    Private Sub FormEmpPayroll_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        load_payroll()
    End Sub
    '
    Sub load_payroll()
        Dim query As String = "SELECT 'no' AS is_check, pr.*,emp.`employee_name`,type.payroll_type as payroll_type_name,DATE_FORMAT(pr.periode_end,'%M %Y') AS payroll_name, IFNULL((SELECT report_status FROM tb_lookup_report_status WHERE id_report_status = pr.id_report_status), 'Not Submitted') AS report_status, type.is_thr, type.is_dw FROM tb_emp_payroll pr
                                INNER JOIn tb_emp_payroll_type type ON type.id_payroll_type=pr.id_payroll_type
                                INNER JOIN tb_m_user usr ON usr.id_user=pr.id_user_upd
                                INNER JOIN tb_m_employee emp ON emp.`id_employee`=usr.id_employee
                                ORDER BY pr.periode_end DESC, type.sort ASC"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        '
        GCPayrollPeriode.DataSource = data
        GVPayrollPeriode.BestFitColumns()
        '
        check_but()
    End Sub

    Sub check_but()
        If is_view = "2" Then
            If XTCPayroll.SelectedTabPageIndex = 0 Then
                If GVPayrollPeriode.RowCount > 0 Then
                    bnew_active = "1"
                    bedit_active = "1"
                    bdel_active = "1"
                Else
                    bnew_active = "1"
                    bedit_active = "0"
                    bdel_active = "0"
                End If
            Else
                bnew_active = "0"
                bedit_active = "0"
                bdel_active = "0"
            End If
        End If
    End Sub

    Private Sub FormEmpPayroll_Activated(sender As Object, e As EventArgs) Handles MyBase.Activated
        FormMain.show_rb(Name)
        checkFormAccess(Name)
        check_but()
        button_main(bnew_active, bedit_active, bdel_active)
    End Sub

    Private Sub FormEmpPayroll_Deactivate(sender As Object, e As EventArgs) Handles MyBase.Deactivate
        FormMain.hide_rb()
    End Sub

    Private Sub FormEmpPayroll_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub BOvertime_Click(sender As Object, e As EventArgs) Handles BOvertime.Click
        FormEmpPayrollOvertime.id_periode = GVPayrollPeriode.GetFocusedRowCellValue("id_payroll").ToString
        FormEmpPayrollOvertime.ShowDialog()
    End Sub

    Private Sub BGetEmployee_Click(sender As Object, e As EventArgs) Handles BGetEmployee.Click
        FormEmpPayrollEmp.ShowDialog()
    End Sub

    Sub load_payroll_detail()
        Cursor = Cursors.WaitCursor

        If GVPayrollPeriode.RowCount > 0 Then
            Dim query As String = "CALL view_payroll('" & GVPayrollPeriode.GetFocusedRowCellValue("id_payroll").ToString & "')"

            Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")

            GCPayroll.DataSource = data

            adjustment_deduction_column("adjustment")
            adjustment_deduction_column("deduction")

            'check column
            If GBBonusAdjustment.Columns.Count = 1 Then
                GBBonusAdjustment.Visible = False
                BBonusAdjustment.Visible = False
            Else
                GBBonusAdjustment.Visible = True
                BBonusAdjustment.Visible = True
            End If

            If GBDeduction.Columns.Count = 1 Then
                GBDeduction.Visible = False
                BDeduction.Visible = False
            Else
                GBDeduction.Visible = True
                BDeduction.Visible = True
            End If

            'grand total dw
            If GVPayrollPeriode.GetFocusedRowCellValue("id_payroll_type").ToString = "4" Then
                calculate_grandtotal_dw()
            End If

            GVPayroll.BestFitColumns()

            'controls
            Dim id_report_status As String = execute_query("SELECT id_report_status FROM tb_emp_payroll WHERE id_payroll = '" + GVPayrollPeriode.GetFocusedRowCellValue("id_payroll").ToString + "'", 0, True, "", "", "", "")

            Dim is_thr As String = execute_query("SELECT is_thr FROM tb_emp_payroll_type WHERE id_payroll_type = " + GVPayrollPeriode.GetFocusedRowCellValue("id_payroll_type").ToString, 0, True, "", "", "", "")

            Dim is_dw As String = execute_query("SELECT is_dw FROM tb_emp_payroll_type WHERE id_payroll_type = " + GVPayrollPeriode.GetFocusedRowCellValue("id_payroll_type").ToString, 0, True, "", "", "", "")

            If id_report_status = "0" Then
                BGetEmployee.Enabled = True
                BRemoveEmployee.Enabled = True
                BMark.Enabled = False
                BandedGridColumnPending.OptionsColumn.AllowEdit = True
                BandedGridColumnCash.OptionsColumn.AllowEdit = True
                If is_dw = "1" Then
                    BandedGridColumnTotalSalaryTHR.OptionsColumn.AllowEdit = True
                Else
                    BandedGridColumnTotalSalaryTHR.OptionsColumn.AllowEdit = False
                End If
                'BReport.Enabled = False
                BPrintSlip.Enabled = False
                SBSendSlip.Enabled = False
                BPrint.Enabled = False
                BReset.Visible = False
                BSubmit.Visible = True
                CMDelEmp.Enabled = True
                BtnViewJournal.Visible = False
            Else
                BGetEmployee.Enabled = False
                BRemoveEmployee.Enabled = False
                BMark.Enabled = True
                BandedGridColumnActWorkdays.OptionsColumn.AllowEdit = False
                BandedGridColumnActWorkdaysDW.OptionsColumn.AllowEdit = False
                BandedGridColumnPending.OptionsColumn.AllowEdit = False
                BandedGridColumnCash.OptionsColumn.AllowEdit = False
                BandedGridColumnTotalSalaryTHR.OptionsColumn.AllowEdit = False
                'BReport.Enabled = True
                BPrintSlip.Enabled = False
                SBSendSlip.Enabled = False
                BtnViewJournal.Visible = False
                BPrint.Enabled = True
                BReset.Visible = True
                BSubmit.Visible = False
                CMDelEmp.Enabled = False
            End If

            If id_report_status = "6" Then
                BPrintSlip.Enabled = True
                SBSendSlip.Enabled = True
                If is_thr = "2" Then
                    BtnViewJournal.Visible = True
                Else
                    BtnViewJournal.Visible = False
                End If
                BReset.Visible = False
            End If

            'grid
            If is_thr = "2" Then
                If GVPayrollPeriode.GetFocusedRowCellValue("id_payroll_type").ToString = "1" Then
                    GBWorkingDays.Visible = True
                    GBSalary.Visible = True
                    GBOvertime.Visible = True

                    GBDW.Visible = False

                    GBTHR.Visible = False

                    BOvertime.Visible = True

                    BandedGridColumnTotFixedSalary.Visible = False
                    GridColumnHousingAllowance.Visible = True
                    GridColumnVehicleAttndAllowance.Visible = True
                    GridColumnTotTHP.Visible = True
                ElseIf GVPayrollPeriode.GetFocusedRowCellValue("id_payroll_type").ToString = "4" Then
                    GBWorkingDays.Visible = False
                    GBSalary.Visible = False
                    GBOvertime.Visible = True

                    GBTHR.Visible = False

                    GBDW.Visible = True

                    BOvertime.Visible = True
                End If

                BBIBPJSKesehatan.Visibility = DevExpress.XtraBars.BarItemVisibility.Always
                BBIBPJSTK.Visibility = DevExpress.XtraBars.BarItemVisibility.Always
                BBIPajak.Visibility = DevExpress.XtraBars.BarItemVisibility.Always

                BBonusAdjustment.Text = "Bonus / Adjustment"
                BandedGridColumnTotalAdjustment.Caption = "Total Bonus / Adjustment"
                GBBonusAdjustment.Caption = "Bonus / Adjustment"
            Else
                GBWorkingDays.Visible = False
                GBSalary.Visible = True
                GBOvertime.Visible = False

                GBTHR.Visible = True

                GBDW.Visible = False

                BOvertime.Visible = False

                BandedGridColumnTotFixedSalary.Visible = True
                GridColumnHousingAllowance.Visible = False
                GridColumnVehicleAttndAllowance.Visible = False
                GridColumnTotTHP.Visible = False

                If is_dw = "1" Then
                    GBSalary.Visible = False
                End If

                BBIBPJSKesehatan.Visibility = DevExpress.XtraBars.BarItemVisibility.Never
                BBIBPJSTK.Visibility = DevExpress.XtraBars.BarItemVisibility.Never
                'BBIPajak.Visibility = DevExpress.XtraBars.BarItemVisibility.Never

                BBonusAdjustment.Text = "Adjustment"
                BandedGridColumnTotalAdjustment.Caption = "Adjustment"
                GBBonusAdjustment.Caption = "Adjustment"
            End If

            If id_report_status = "0" Then
                check_diff()
            End If
        End If

        GVPayroll.TopRowIndex = 0

        'view
        If is_view = "1" Then
            BandedGridColumnActWorkdaysDW.OptionsColumn.AllowEdit = False
            BandedGridColumnPending.OptionsColumn.AllowEdit = False
            BandedGridColumnCash.OptionsColumn.AllowEdit = False
            BGetEmployee.Visible = False
            BRemoveEmployee.Visible = False
            BReset.Visible = False
            BSubmit.Visible = False
            SBSendSlip.Visible = False
            CheckEditViewSend.Visible = False
        End If

        Cursor = Cursors.Default
    End Sub

    Sub calculate_grandtotal_dw()
        For i = 0 To GVPayroll.RowCount - 1
            If GVPayroll.IsValidRowHandle(i) Then
                Dim grand_total As Decimal = (GVPayroll.GetRowCellValue(i, "basic_salary") * GVPayroll.GetRowCellValue(i, "actual_workdays")) + GVPayroll.GetRowCellValue(i, "total_adjustment") + GVPayroll.GetRowCellValue(i, "total_ot_wages") - GVPayroll.GetRowCellValue(i, "total_deduction")

                GVPayroll.SetRowCellValue(i, "grand_total", grand_total)

                Dim total_salary_dw As Decimal = (GVPayroll.GetRowCellValue(i, "basic_salary") * GVPayroll.GetRowCellValue(i, "actual_workdays"))

                GVPayroll.SetRowCellValue(i, "total_salary_dw", total_salary_dw)
            End If
        Next
    End Sub

    Private Sub GVPayroll_PopupMenuShowing(sender As Object, e As DevExpress.XtraGrid.Views.Grid.PopupMenuShowingEventArgs)
        If GVPayroll.RowCount > 0 And GVPayroll.FocusedRowHandle >= 0 Then
            Dim view As DevExpress.XtraGrid.Views.Grid.GridView = CType(sender, DevExpress.XtraGrid.Views.Grid.GridView)
            Dim hitInfo As DevExpress.XtraGrid.Views.Grid.ViewInfo.GridHitInfo = view.CalcHitInfo(e.Point)
            If hitInfo.InRow And hitInfo.RowHandle >= 0 Then
                view.FocusedRowHandle = hitInfo.RowHandle
                ViewPopWorksheet.Show(view.GridControl, e.Point)
            End If
        End If
    End Sub

    Private Sub CMDelEmp_Click(sender As Object, e As EventArgs) Handles CMDelEmp.Click
        Dim confirm As DialogResult
        confirm = DevExpress.XtraEditors.XtraMessageBox.Show("Are you sure want to delete this employee ?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
        If confirm = Windows.Forms.DialogResult.Yes Then
            Dim id_employee As String = GVPayroll.GetFocusedRowCellValue("id_employee").ToString
            Dim id_payroll As String = GVPayrollPeriode.GetFocusedRowCellValue("id_payroll").ToString
            '
            Dim query As String = "DELETE FROM tb_emp_payroll_det WHERE id_employee='" & id_employee & "' AND id_payroll='" & id_payroll & "'"
            execute_non_query(query, True, "", "", "", "")
            load_payroll_detail()
        End If
    End Sub

    Private Sub BDeduction_Click(sender As Object, e As EventArgs) Handles BDeduction.Click
        FormEmpPayrollDeduction.ShowDialog()
    End Sub

    Private Sub BSetting_Click(sender As Object, e As EventArgs) Handles BSetting.Click
        FormEmpPayrollSetup.ShowDialog()
    End Sub

    Private Sub BBonusAdjustment_Click(sender As Object, e As EventArgs) Handles BBonusAdjustment.Click
        FormEmpPayrollAdjustment.ShowDialog()
    End Sub

    Private Sub BRemoveEmployee_Click(sender As Object, e As EventArgs) Handles BRemoveEmployee.Click
        GVPayroll.ActiveFilterString = "[is_check]='yes'"

        If GVPayroll.RowCount > 0 Then
            Dim confirm As DialogResult
            confirm = DevExpress.XtraEditors.XtraMessageBox.Show("Are you sure want to delete selected employee ?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
            If confirm = Windows.Forms.DialogResult.Yes Then
                Cursor = Cursors.WaitCursor

                For i = 0 To GVPayroll.RowCount - 1
                    If GVPayroll.IsValidRowHandle(i) Then
                        Dim query As String = "DELETE FROM tb_emp_payroll_det WHERE id_payroll_det='" & GVPayroll.GetRowCellValue(i, "id_payroll_det").ToString & "'"
                        execute_non_query(query, True, "", "", "", "")
                    End If
                Next

                load_payroll_detail()

                Cursor = Cursors.Default
            End If
        Else
            stopCustom("Please choose employee first.")
        End If

        GVPayroll.ActiveFilterString = ""
    End Sub

    Private Sub RICEPending_EditValueChanged(sender As Object, e As EventArgs) Handles RICEPending.EditValueChanged
        Dim cepending As DevExpress.XtraEditors.CheckEdit = CType(sender, DevExpress.XtraEditors.CheckEdit)
        If GVPayroll.FocusedColumn.FieldName.ToString = "is_pending" Then
            If cepending.CheckState.ToString = "Checked" Then
                'pending
                Dim query_upd As String = "UPDATE tb_emp_payroll_det SET is_pending='1' WHERE id_payroll_det='" & GVPayroll.GetFocusedRowCellValue("id_payroll_det").ToString & "'"
                execute_non_query(query_upd, True, "", "", "", "")
            Else
                'not pending
                Dim query_upd As String = "UPDATE tb_emp_payroll_det SET is_pending='2' WHERE id_payroll_det='" & GVPayroll.GetFocusedRowCellValue("id_payroll_det").ToString & "'"
                execute_non_query(query_upd, True, "", "", "", "")
            End If
        ElseIf GVPayroll.FocusedColumn.FieldName.ToString = "is_cash" Then
            If cepending.CheckState.ToString = "Checked" Then
                'cash
                Dim query_upd As String = "UPDATE tb_emp_payroll_det SET is_cash='1' WHERE id_payroll_det='" & GVPayroll.GetFocusedRowCellValue("id_payroll_det").ToString & "'"
                execute_non_query(query_upd, True, "", "", "", "")
            Else
                'not cash
                Dim query_upd As String = "UPDATE tb_emp_payroll_det SET is_cash='2' WHERE id_payroll_det='" & GVPayroll.GetFocusedRowCellValue("id_payroll_det").ToString & "'"
                execute_non_query(query_upd, True, "", "", "", "")
            End If
        End If
    End Sub

    Private Sub CheckEditSelAll_CheckedChanged(sender As Object, e As EventArgs) Handles CheckEditSelAll.CheckedChanged
        If GVPayroll.RowCount > 0 Then
            For i As Integer = 0 To ((GVPayroll.RowCount - 1) - GetGroupRowCount(GVPayroll))
                If CheckEditSelAll.Checked = False Then
                    GVPayroll.SetRowCellValue(i, "is_check", "no")
                Else
                    GVPayroll.SetRowCellValue(i, "is_check", "yes")
                End If
            Next
        End If
    End Sub

    Private Sub BUpdateActualWorkingDays_Click(sender As Object, e As EventArgs) Handles BUpdateActualWorkingDays.Click
        makeSafeGV(GVPayroll)
        GVPayroll.ActiveFilterString = "[is_check]='yes'"
        For i As Integer = 0 To GVPayroll.RowCount - 1
            'update actual working days
            infoCustom(GVPayroll.GetRowCellValue(i, "id_employee").ToString)
            'update
            Dim query As String = ""
            progres_bar_update(i, GVPayroll.RowCount - 1)
        Next
        makeSafeGV(GVPayroll)
    End Sub

    Private Sub BPrintSlip_Click(sender As Object, e As EventArgs) Handles BPrintSlip.Click
        Dim where_string As String = ""

        If GVPayroll.RowCount > 0 Then
            Cursor = Cursors.WaitCursor
            'search id det
            'makeSafeGV(GVPayroll)
            GVPayroll.ActiveFilterString = "[is_check]='yes'"
            If GVPayroll.RowCount > 0 Then
                For i As Integer = 0 To GVPayroll.RowCount - 1
                    If GVPayroll.IsValidRowHandle(i) Then
                        If i = 0 Then
                            where_string = GVPayroll.GetRowCellValue(i, "id_payroll_det").ToString
                        Else
                            where_string += "," & GVPayroll.GetRowCellValue(i, "id_payroll_det").ToString
                        End If
                    End If
                Next
                'makeSafeGV(GVPayroll)
                '
                Dim Report As ReportSalarySlip = New ReportSalarySlip
                Report.where_string = where_string
                Report.id_payroll = GVPayrollPeriode.GetFocusedRowCellValue("id_payroll").ToString
                Dim Tool As DevExpress.XtraReports.UI.ReportPrintTool = New DevExpress.XtraReports.UI.ReportPrintTool(Report)
                Tool.ShowPreviewDialog()
                Cursor = Cursors.Default
            Else
                stopCustom("Please choose employee first.")
                Cursor = Cursors.Default
            End If
            GVPayroll.ActiveFilterString = ""
        End If
    End Sub

    Private Sub GVPayroll_CellValueChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles GVPayroll.CellValueChanged
        If e.Column.FieldName.ToString = "actual_workdays" Then
            If Not e.Value.ToString = "" And GVPayroll.RowCount > 0 Then
                Dim id_det As String = GVPayroll.GetFocusedRowCellValue("id_payroll_det").ToString
                Dim query_upd As String = "UPDATE tb_emp_payroll_det SET actual_workdays='" & decimalSQL(Decimal.Parse(e.Value.ToString).ToString) & "' WHERE id_payroll_det='" & id_det & "'"
                execute_non_query(query_upd, True, "", "", "", "")

                load_payroll_detail()
            End If
        ElseIf e.Column.FieldName.ToString = "is_cash" Then
            If Not e.Value.ToString = "" And GVPayroll.RowCount > 0 Then
                Dim id_det As String = GVPayroll.GetFocusedRowCellValue("id_payroll_det").ToString
                Dim is_cash As String = ""
                If GVPayroll.GetFocusedRowCellValue("is_cash").ToString = "yes" Then
                    is_cash = "1"
                Else
                    is_cash = "2"
                End If
                Dim query_upd As String = "UPDATE tb_emp_payroll_det SET is_cash='" & is_cash & "' WHERE id_payroll_det='" & id_det & "'"
                execute_non_query(query_upd, True, "", "", "", "")
            End If
        ElseIf e.Column.FieldName.ToString = "total_salary_thr" Then
            If Not e.Value.ToString = "" And GVPayroll.RowCount > 0 Then
                Dim id_det As String = GVPayroll.GetFocusedRowCellValue("id_payroll_det").ToString
                Dim query_upd As String = "UPDATE tb_emp_payroll_det SET total_salary_thr='" & Integer.Parse(e.Value.ToString) & "' WHERE id_payroll_det='" & id_det & "'"
                execute_non_query(query_upd, True, "", "", "", "")

                load_payroll_detail()
            End If
        End If
    End Sub

    Private Sub BarButtonItem1_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem1.ItemClick
        FormEmpPayrollReportSummary.ShowDialog()
    End Sub

    Private Sub BarButtonItem2_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem2.ItemClick
        FormEmpPayrollReportOTEvent.ShowDialog()
    End Sub

    Private Sub BPrint_Click(sender As Object, e As EventArgs) Handles BPrint.Click
        Dim data As DataTable = GCPayroll.DataSource

        'alphabeth
        Dim alphabet As String() = {"A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z"}

        data.DefaultView.Sort = "departement ASC, departement_sub ASC"
        data = data.DefaultView.ToTable

        Dim iAlphabet As Integer = 0
        Dim iInterger As Integer = 1

        Dim last_departement As String = ""
        Dim last_departement_sub As String = ""

        For i = 0 To data.Rows.Count - 1
            Dim curr_departement As String = System.Text.RegularExpressions.Regex.Replace(data.Rows(i)("departement").ToString, "\(([A-Z])\)", "").ToString()
            Dim curr_departement_sub As String = System.Text.RegularExpressions.Regex.Replace(data.Rows(i)("departement_sub").ToString, "\(([A-Z])\)", "").ToString()

            If i = 0 Then
                last_departement = curr_departement
                last_departement_sub = curr_departement_sub
            End If

            If Not last_departement = curr_departement Then
                iAlphabet += 1
                iInterger = 0
            End If

            If Not last_departement_sub = curr_departement_sub Then
                iInterger += 1
            End If

            data.Rows(i)("departement") = curr_departement + " (" + alphabet(iAlphabet) + ")"
            data.Rows(i)("departement_sub") = curr_departement_sub + " (" + alphabet(iAlphabet) + iInterger.ToString + ")"

            last_departement = curr_departement
            last_departement_sub = curr_departement_sub
        Next

        'report
        Dim id_report_status As String = execute_query("SELECT id_report_status FROM tb_emp_payroll WHERE id_payroll = " + GVPayrollPeriode.GetFocusedRowCellValue("id_payroll").ToString, 0, True, "", "", "", "")

        Dim already_office As Boolean = False
        Dim already_store As Boolean = False

        For j = 0 To data.Rows.Count - 1
            If data.Rows(j)("is_office_payroll").ToString = "1" Then
                already_office = True
            ElseIf data.Rows(j)("is_office_payroll").ToString = "2"
                already_store = True
            End If
        Next

        'office
        Dim data_payroll_office As DataTable = data.Clone

        For j = 0 To data.Rows.Count - 1
            If data.Rows(j)("is_office_payroll").ToString = "1" Then
                data_payroll_office.ImportRow(data.Rows(j))
            End If
        Next

        'store
        Dim data_payroll_store As DataTable = data.Clone

        For j = 0 To data.Rows.Count - 1
            If data.Rows(j)("is_office_payroll").ToString = "2" Then
                data_payroll_store.ImportRow(data.Rows(j))
            End If
        Next

        Dim is_thr As String = execute_query("SELECT is_thr FROM tb_emp_payroll_type WHERE id_payroll_type = " + GVPayrollPeriode.GetFocusedRowCellValue("id_payroll_type").ToString, 0, True, "", "", "", "")

        Dim report As ReportPayrollAll = New ReportPayrollAll

        report.id_payroll = GVPayrollPeriode.GetFocusedRowCellValue("id_payroll").ToString
        report.id_pre = If(id_report_status = "6", "-1", "1")
        report.type = GVPayrollPeriode.GetFocusedRowCellValue("id_payroll_type").ToString
        report.dt_office = data_payroll_office
        report.dt_store = data_payroll_store

        report.XLPeriod.Text = Date.Parse(GVPayrollPeriode.GetFocusedRowCellValue("periode_end").ToString).ToString("MMMM yyyy")
        report.XLType.Text = GVPayrollPeriode.GetFocusedRowCellValue("payroll_type_name").ToString

        If is_thr = "1" Then
            report.XLTitle.Text = "Detail THR"
            report.XLPeriod.Text = "Period " + Date.Parse(GVPayrollPeriode.GetFocusedRowCellValue("periode_end").ToString).ToString("yyyy")
        End If

        If Not already_office Then
            report.DetailReportOffice.Visible = False

            report.DetailReportStore.Level = 0
            report.DetailReportStore.PageBreak = DevExpress.XtraReports.UI.PageBreak.None
        End If

        If Not already_store Then
            report.DetailReportStore.Visible = False

            report.DetailReportOffice.Level = 0
            report.DetailReportOffice.PageBreak = DevExpress.XtraReports.UI.PageBreak.None
        End If

        Dim tool As DevExpress.XtraReports.UI.ReportPrintTool = New DevExpress.XtraReports.UI.ReportPrintTool(report)

        tool.ShowPreview()
    End Sub

    Private Sub BBBcaFormat_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BBBcaFormat.ItemClick
        FormEmpPayrollBCAFormat.ShowDialog()
    End Sub

    Private Sub BSubmit_Click(sender As Object, e As EventArgs) Handles BSubmit.Click
        Cursor = Cursors.WaitCursor

        Dim id_payroll As String = GVPayrollPeriode.GetFocusedRowCellValue("id_payroll").ToString

        Dim confirm As DialogResult

        confirm = DevExpress.XtraEditors.XtraMessageBox.Show("All data will be locked. Are you sure want to submit payroll ?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)

        If confirm = Windows.Forms.DialogResult.Yes Then
            execute_non_query("UPDATE tb_emp_payroll SET id_report_status = 1 WHERE id_payroll = '" + id_payroll + "'", True, "", "", "", "")

            execute_non_query("CALL gen_number(" + id_payroll + ", '192')", True, "", "", "", "")

            submit_who_prepared("192", GVPayrollPeriode.GetFocusedRowCellValue("id_payroll").ToString, id_user)

            load_payroll()

            GVPayrollPeriode.FocusedRowHandle = find_row(GVPayrollPeriode, "id_payroll", id_payroll)

            load_payroll_detail()
        End If

        Cursor = Cursors.Default
    End Sub

    Private Sub BReset_Click(sender As Object, e As EventArgs) Handles BReset.Click
        Cursor = Cursors.WaitCursor

        Dim id_payroll As String = GVPayrollPeriode.GetFocusedRowCellValue("id_payroll").ToString

        Dim confirm As DialogResult

        confirm = DevExpress.XtraEditors.XtraMessageBox.Show("All approval will be reset. Are you sure want to reset payroll ?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)

        If confirm = Windows.Forms.DialogResult.Yes Then
            execute_non_query("UPDATE tb_emp_payroll SET id_report_status = 0, report_number = 0 WHERE id_payroll = '" + id_payroll + "'", True, "", "", "", "")

            'execute_non_query("UPDATE tb_report_mark SET report_mark_lead_time = NULL, report_mark_start_datetime = NULL WHERE report_mark_type = 192 AND id_report = '" + GVPayrollPeriode.GetFocusedRowCellValue("id_payroll").ToString + "'", True, "", "", "", "")

            execute_non_query("DELETE FROM tb_report_mark WHERE report_mark_type = 192 AND id_report = '" + id_payroll + "'", True, "", "", "", "")

            load_payroll()

            GVPayrollPeriode.FocusedRowHandle = find_row(GVPayrollPeriode, "id_payroll", id_payroll)

            load_payroll_detail()
        End If

        Cursor = Cursors.Default
    End Sub

    Private Sub BMark_Click(sender As Object, e As EventArgs) Handles BMark.Click
        Cursor = Cursors.WaitCursor
        FormReportMark.report_mark_type = "192"
        FormReportMark.is_view = "1"
        FormReportMark.id_report = GVPayrollPeriode.GetFocusedRowCellValue("id_payroll").ToString
        FormReportMark.ShowDialog()
        Cursor = Cursors.Default
    End Sub

    Private Sub GVPayrollPeriode_DoubleClick(sender As Object, e As EventArgs) Handles GVPayrollPeriode.DoubleClick
        XTCPayroll.SelectedTabPage = XTPSalaryFormat
    End Sub

    Sub adjustment_deduction_column(type As String)
        'type
        Dim payroll_type As DataTable = execute_query("SELECT is_dw, is_thr FROM tb_emp_payroll_type WHERE id_payroll_type = " + GVPayrollPeriode.GetFocusedRowCellValue("id_payroll_type").ToString, -1, True, "", "", "", "")

        'column
        Dim where_adj_c As String = ""

        Dim query_adj_c As String = "SELECT cat.salary_" + type + "_cat, (SELECT MIN(use_dw) FROM tb_lookup_salary_" + type + " WHERE id_salary_" + type + "_cat = cat.id_salary_" + type + "_cat) AS use_dw, (SELECT MIN(use_thr) FROM tb_lookup_salary_" + type + " WHERE id_salary_" + type + "_cat = cat.id_salary_" + type + "_cat) AS use_thr FROM tb_lookup_salary_" + type + "_cat AS cat"

        Dim data_adj_c As DataTable = execute_query(query_adj_c, -1, True, "", "", "", "")

        For i = 0 To data_adj_c.Rows.Count - 1
            Dim field_name As String = data_adj_c.Rows(i)("salary_" + type + "_cat").ToString + " " + type

            'remove if exist
            GVPayroll.Columns.Remove(GVPayroll.Columns(field_name))

            'dw column
            If payroll_type.Rows(0)("is_dw") = "1" And data_adj_c.Rows(i)("use_dw").ToString = "2" Then
                Continue For
            End If

            'thr column
            If payroll_type.Rows(0)("is_thr") = "1" And data_adj_c.Rows(i)("use_thr").ToString = "2" Then
                Continue For
            End If

            'add column to datasource
            If Not GCPayroll.DataSource.Columns.Contains(field_name) Then
                Dim column_datasource As DataColumn = New DataColumn()

                column_datasource.ColumnName = field_name
                column_datasource.DataType = GetType(Integer)
                column_datasource.DefaultValue = 0

                GCPayroll.DataSource.Columns.Add(column_datasource)
            End If

            'add column to gridview
            Dim column As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()

            column.FieldName = field_name
            column.Caption = data_adj_c.Rows(i)("salary_" + type + "_cat").ToString
            column.Visible = True
            column.OptionsColumn.AllowEdit = False
            column.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            column.DisplayFormat.FormatString = "N0"
            column.SummaryItem.DisplayFormat = "{0:N0}"
            column.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum

            If type = "adjustment" Then
                GBBonusAdjustment.Columns.Add(column)
            ElseIf type = "deduction" Then
                GBDeduction.Columns.Add(column)
            End If

            'add group summary
            Dim group_summary As DevExpress.XtraGrid.GridGroupSummaryItem = New DevExpress.XtraGrid.GridGroupSummaryItem()

            group_summary.DisplayFormat = "{0:N0}"
            group_summary.FieldName = field_name
            group_summary.ShowInGroupColumnFooter = column
            group_summary.SummaryType = DevExpress.Data.SummaryItemType.Sum

            GVPayroll.GroupSummary.Add(group_summary)
        Next

        'move column total
        Dim column_total As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn = GVPayroll.Columns("total_" + type)

        column_total.ColVIndex = 99

        'value
        Dim query_adj_v As String = ""

        If type = "adjustment" Then
            query_adj_v = "
                SELECT adj.id_employee, ladjc.salary_adjustment_cat, ROUND(SUM(adj.value), 0) AS value
                FROM tb_emp_payroll_adj AS adj
                LEFT JOIN tb_lookup_salary_adjustment AS ladj ON adj.id_salary_adj = ladj.id_salary_adjustment
                LEFT JOIN tb_lookup_salary_adjustment_cat AS ladjc ON ladj.id_salary_adjustment_cat = ladjc.id_salary_adjustment_cat
                WHERE adj.id_payroll = " + GVPayrollPeriode.GetFocusedRowCellValue("id_payroll").ToString + "
                GROUP BY adj.id_employee, ladjc.id_salary_adjustment_cat
            "
        ElseIf type = "deduction" Then
            query_adj_v = "
                SELECT adj.id_employee, ladjc.salary_deduction_cat, ROUND(SUM(adj.deduction), 0) AS value
                FROM tb_emp_payroll_deduction AS adj
                LEFT JOIN tb_lookup_salary_deduction AS ladj ON adj.id_salary_deduction = ladj.id_salary_deduction
                LEFT JOIN tb_lookup_salary_deduction_cat AS ladjc ON ladj.id_salary_deduction_cat = ladjc.id_salary_deduction_cat
                WHERE adj.id_payroll = " + GVPayrollPeriode.GetFocusedRowCellValue("id_payroll").ToString + "
                GROUP BY adj.id_employee, ladjc.id_salary_deduction_cat
            "
        End If

        Dim data_adj_v As DataTable = execute_query(query_adj_v, -1, True, "", "", "", "")

        For i = 0 To data_adj_v.Rows.Count - 1
            Dim row As Integer = find_row(GVPayroll, "id_employee", data_adj_v.Rows(i)("id_employee").ToString)

            GVPayroll.SetRowCellValue(row, data_adj_v.Rows(i)("salary_" + type + "_cat").ToString + " " + type, data_adj_v.Rows(i)("value"))
        Next
    End Sub

    Private Sub XTCPayroll_SelectedPageChanged(sender As Object, e As DevExpress.XtraTab.TabPageChangedEventArgs) Handles XTCPayroll.SelectedPageChanged
        If XTCPayroll.SelectedTabPage.Name = "XTPSalaryFormat" Then
            load_payroll_detail()
        End If
    End Sub

    Private Sub BarButtonItem5_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BBIBPJSTK.ItemClick
        'bpjstk
        FormEmpPayrollReportBPJSTK.id_payroll = GVPayrollPeriode.GetFocusedRowCellValue("id_payroll").ToString

        FormEmpPayrollReportBPJSTK.ShowDialog()
    End Sub

    Private Sub BarButtonItem4_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BBIBPJSKesehatan.ItemClick
        'bpjs kesehatan
        FormEmpPayrollReportBPJSKesehatan.id_payroll = GVPayrollPeriode.GetFocusedRowCellValue("id_payroll").ToString

        FormEmpPayrollReportBPJSKesehatan.ShowDialog()
    End Sub

    Private Sub SBSendSlip_Click(sender As Object, e As EventArgs) Handles SBSendSlip.Click
        Dim confirm As DialogResult

        confirm = DevExpress.XtraEditors.XtraMessageBox.Show("Are you sure want to send salary slip ?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)

        If confirm = Windows.Forms.DialogResult.Yes Then
            If GVPayroll.RowCount > 0 Then
                Cursor = Cursors.WaitCursor

                GVPayroll.ActiveFilterString = "[is_check]='yes'"

                If GVPayroll.RowCount > 0 Then
                    Dim is_ssl = get_setup_field("system_email_is_ssl").ToString

                    Dim client As Net.Mail.SmtpClient = New Net.Mail.SmtpClient()

                    If is_ssl = "1" Then
                        client.Port = get_setup_field("system_email_ssl_port").ToString
                        client.DeliveryMethod = Net.Mail.SmtpDeliveryMethod.Network
                        client.UseDefaultCredentials = False
                        client.Host = get_setup_field("system_email_ssl_server").ToString
                        client.EnableSsl = True
                        client.Credentials = New System.Net.NetworkCredential(get_setup_field("system_email_ssl").ToString, get_setup_field("system_email_ssl_pass").ToString)
                    Else
                        client.Port = get_setup_field("system_email_port").ToString
                        client.DeliveryMethod = Net.Mail.SmtpDeliveryMethod.Network
                        client.UseDefaultCredentials = False
                        client.Host = get_setup_field("system_email_server").ToString
                        client.Credentials = New System.Net.NetworkCredential(get_setup_field("system_email").ToString, get_setup_field("system_email_pass").ToString)
                    End If

                    'check personal email
                    Dim already_personal_email As Boolean = True
                    Dim list_personal_email As String = ""

                    For i As Integer = 0 To GVPayroll.RowCount - 1
                        If GVPayroll.IsValidRowHandle(i) Then
                            If GVPayroll.GetRowCellValue(i, "email_personal").ToString = "" Then
                                already_personal_email = False

                                list_personal_email += "- (" + GVPayroll.GetRowCellValue(i, "employee_code").ToString + ") " + GVPayroll.GetRowCellValue(i, "employee_name").ToString + Environment.NewLine
                            End If
                        End If
                    Next

                    If already_personal_email Then
                        For i As Integer = 0 To GVPayroll.RowCount - 1
                            If GVPayroll.IsValidRowHandle(i) Then
                                Dim period As String = Date.Parse(GVPayrollPeriode.GetFocusedRowCellValue("periode_end").ToString).ToString("MMMM yyyy")
                                Dim employee_name As String = GVPayroll.GetRowCellValue(i, "employee_name").ToString
                                Dim email_personal As String = GVPayroll.GetRowCellValue(i, "email_personal").ToString

                                If GVPayrollPeriode.GetFocusedRowCellValue("is_thr").ToString = "1" Then
                                    period = GVPayrollPeriode.GetFocusedRowCellValue("payroll_type_name").ToString.Replace(" Daily Worker", "") + " " + Date.Parse(GVPayrollPeriode.GetFocusedRowCellValue("periode_end").ToString).ToString("yyyy")
                                End If

                                Dim mem As New IO.MemoryStream()

                                Dim report As ReportSalarySlip = New ReportSalarySlip

                                report.where_string = GVPayroll.GetRowCellValue(i, "id_payroll_det").ToString
                                report.id_payroll = GVPayrollPeriode.GetFocusedRowCellValue("id_payroll").ToString

                                report.ExportOptions.Pdf.PasswordSecurityOptions.OpenPassword = GVPayroll.GetRowCellValue(i, "employee_dob").ToString

                                report.ExportToPdf(mem)

                                mem.Seek(0, System.IO.SeekOrigin.Begin)

                                Dim att = New Net.Mail.Attachment(mem, "Slip Gaji " + period + ".pdf", "application/pdf")

                                'mail
                                Dim mail As Net.Mail.MailMessage = New Net.Mail.MailMessage()

                                'from
                                Dim from_mail As Net.Mail.MailAddress = New Net.Mail.MailAddress("system@volcom.co.id", "Volcom ERP")

                                mail.From = from_mail

                                'to
                                Dim to_mail As Net.Mail.MailAddress = New Net.Mail.MailAddress(email_personal, employee_name)

                                mail.To.Add(to_mail)

                                mail.Subject = "PT. VOLCOM INDONESIA - SLIP GAJI " + period.ToUpper
                                mail.IsBodyHtml = True
                                mail.Body = "
                                    <p style='font: normal 10.00pt/14.25pt Arial; margin: 0;'>Yang Terhormat Bapak/Ibu</p>
                                    <p style='font: normal 10.00pt/14.25pt Arial; margin: 0;'>" + employee_name + "</p>
                                    <br>
                                    <p style='font: normal 10.00pt/14.25pt Arial; margin: 0;'>Bersama ini kami lampirkan slip gaji Anda untuk " + If(GVPayrollPeriode.GetFocusedRowCellValue("is_thr").ToString = "1", "", "bulan") + " <b>" + period + "</b>,  slip gaji Anda ini bersifat pribadi dan sangat rahasia.</p>
                                    <p style='font: normal 10.00pt/14.25pt Arial; margin: 0;'>Gunakan password Anda untuk melihat slip gaji tersebut.</p>
                                    <br>
                                    <p style='font: normal 10.00pt/14.25pt Arial; margin: 0;'>Pasword slip gaji Anda adalah ddMmmyyyy (contoh: 01Aug1995)</p>
                                    <br>
                                    <p style='font: normal 10.00pt/14.25pt Arial; margin: 0;'>dd : Dua digit tanggal lahir Anda, contoh: 01</p>
                                    <p style='font: normal 10.00pt/14.25pt Arial; margin: 0;'>Mmm : Tiga huruf pertama bulan lahir Anda dalam bahasa Inggris, contoh: Aug (Huruf pertama adalah huruf besar dan selanjutnya huruf kecil)</p>
                                    <p style='font: normal 10.00pt/14.25pt Arial; margin: 0;'>yyyy : Tahun lahir Anda, contoh: 1995</p>
                                    <br>
                                    <p style='font: normal 10.00pt/14.25pt Arial; margin: 0;'>Demikian kami sampaikan, atas perhatiannya kami ucapkan terimakasih.</p>
                                "

                                mail.Attachments.Add(att)

                                Dim status As String = "1"
                                Dim message As String = ""

                                Try
                                    client.Send(mail)
                                Catch ex As Exception
                                    status = "2"
                                    message = ex.ToString()
                                End Try

                                execute_non_query("INSERT INTO tb_emp_payroll_slip_log (id_payroll_det, status, message, send_to, send_at, send_by) VALUES ('" + GVPayroll.GetRowCellValue(i, "id_payroll_det").ToString + "', '" + status + "', '" + message + "', '" + email_personal + "', NOW(), '" + id_employee_user + "')", True, "", "", "", "")

                                If status = "1" Then
                                    GVPayroll.SetRowCellValue(i, "slip_send", "yes")
                                End If
                            End If
                        Next
                    Else
                        errorCustom("Please complete personal email for : " + Environment.NewLine + list_personal_email)
                    End If

                    Cursor = Cursors.Default
                Else
                    stopCustom("Please choose employee first.")

                    Cursor = Cursors.Default
                End If

                GVPayroll.ActiveFilterString = ""

                For i As Integer = 0 To GVPayroll.RowCount - 1
                    If GVPayroll.IsValidRowHandle(i) Then
                        If GVPayroll.GetRowCellValue(i, "is_check").ToString = "yes" Then
                            GVPayroll.SetRowCellValue(i, "is_check", "no")
                        End If
                    End If
                Next
            End If
        End If
    End Sub

    Private Sub GVPayroll_CustomDrawRowFooter(sender As Object, e As DevExpress.XtraGrid.Views.Base.RowObjectCustomDrawEventArgs) Handles GVPayroll.CustomDrawRowFooter
        e.Graphics.FillRectangle(New SolidBrush(Color.White), e.Bounds)

        Dim format As StringFormat = e.Appearance.GetStringFormat.Clone

        format.Alignment = StringAlignment.Near

        If GVPayroll.GetGroupRowDisplayText(e.RowHandle).Contains("Group") Then
            e.Graphics.DrawString("Grand Total: " + GVPayroll.GetGroupRowValue(e.RowHandle), e.Appearance.GetFont, e.Appearance.GetForeBrush(e.Cache), e.Bounds, format)
        Else
            If GVPayroll.GetGroupRowDisplayText(e.RowHandle).Contains("SOGO") Then
                e.Graphics.DrawString("Total " + GVPayroll.GetGroupRowDisplayText(e.RowHandle), e.Appearance.GetFont, e.Appearance.GetForeBrush(e.Cache), e.Bounds, format)
            Else
                If Not GVPayroll.GetGroupRowDisplayText(e.RowHandle).Contains("Sub") Then
                    e.Graphics.DrawString("Total " + GVPayroll.GetGroupRowDisplayText(e.RowHandle), e.Appearance.GetFont, e.Appearance.GetForeBrush(e.Cache), e.Bounds, format)
                End If
            End If
        End If

        e.Handled = True
    End Sub

    Private Sub GVPayroll_CustomDrawRowFooterCell(sender As Object, e As DevExpress.XtraGrid.Views.Grid.FooterCellCustomDrawEventArgs) Handles GVPayroll.CustomDrawRowFooterCell
        Dim view As DevExpress.XtraGrid.Views.Grid.GridView = sender

        If view.GetGroupRowDisplayText(e.RowHandle).Contains("Sub Departement") And Not view.GetGroupRowValue(e.RowHandle).ToString.Contains("SOGO") Then
            e.Appearance.ForeColor = Color.White
            e.Handled = True
        End If
    End Sub

    Private Sub GVPayroll_CustomDrawGroupRow(sender As Object, e As DevExpress.XtraGrid.Views.Base.RowObjectCustomDrawEventArgs) Handles GVPayroll.CustomDrawGroupRow
        Dim info As DevExpress.XtraGrid.Views.Grid.ViewInfo.GridGroupRowInfo = TryCast(e.Info, DevExpress.XtraGrid.Views.Grid.ViewInfo.GridGroupRowInfo)

        If info.Column.Caption = "Sub Departement" And Not info.EditValue.ToString.Contains("SOGO") Then
            info.GroupText = " "
        End If
    End Sub

    Private Sub BtnAttachment_Click(sender As Object, e As EventArgs) Handles BtnAttachment.Click
        Cursor = Cursors.WaitCursor
        FormDocumentUpload.is_no_delete = "1"
        FormDocumentUpload.id_report = GVPayrollPeriode.GetFocusedRowCellValue("id_payroll").ToString
        FormDocumentUpload.report_mark_type = "192"
        FormDocumentUpload.ShowDialog()
        Cursor = Cursors.Default
    End Sub

    Private Sub CheckEditViewSend_EditValueChanged(sender As Object, e As EventArgs) Handles CheckEditViewSend.EditValueChanged
        Dim slip_sent As DataTable = execute_query("SELECT id_payroll_det FROM tb_emp_payroll_slip_log WHERE id_payroll_det IN (SELECT id_payroll_det FROM tb_emp_payroll_det WHERE id_payroll = " + GVPayrollPeriode.GetFocusedRowCellValue("id_payroll").ToString + ") AND status = 1", -1, True, "", "", "", "")

        For i = 0 To GVPayroll.RowCount - 1
            If GVPayroll.IsValidRowHandle(i) Then
                For j = 0 To slip_sent.Rows.Count - 1
                    If GVPayroll.GetRowCellValue(i, "id_payroll_det").ToString = slip_sent.Rows(j)("id_payroll_det").ToString Then
                        GVPayroll.SetRowCellValue(i, "slip_send", "yes")

                        Exit For
                    End If
                Next
            End If
        Next

        If CheckEditViewSend.EditValue Then
            BandedGridColumnSent.Visible = True
        Else
            BandedGridColumnSent.Visible = False
        End If
    End Sub

    Private Sub BarButtonItem6_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BBIPajak.ItemClick
        FormEmpPayrollReportPajak.id_payroll = GVPayrollPeriode.GetFocusedRowCellValue("id_payroll").ToString
        FormEmpPayrollReportPajak.ShowDialog()
    End Sub

    Private Sub SBExportExcel_Click(sender As Object, e As EventArgs) Handles SBExportExcel.Click
        Dim exist As Boolean = False

        For i = 0 To GVPayrollPeriode.RowCount - 1
            If GVPayrollPeriode.GetRowCellValue(i, "is_check").ToString = "yes" Then
                exist = True
            End If
        Next

        If exist Then
            Dim save As SaveFileDialog = New SaveFileDialog

            save.Filter = "Excel File | *.xls"
            save.ShowDialog()

            If Not save.FileName = "" Then
                Dim op As DevExpress.XtraPrinting.XlsExportOptionsEx = New DevExpress.XtraPrinting.XlsExportOptionsEx

                op.ExportType = DevExpress.Export.ExportType.WYSIWYG

                Dim data As DataTable = execute_query("CALL view_payroll(-1)", -1, True, "", "", "", "")

                For i = 0 To GVPayrollPeriode.RowCount - 1
                    If GVPayrollPeriode.GetRowCellValue(i, "is_check").ToString = "yes" Then
                        Dim data_include As DataTable = execute_query("CALL view_payroll(" + GVPayrollPeriode.GetRowCellValue(i, "id_payroll").ToString + ")", -1, True, "", "", "", "")

                        data.Merge(data_include)
                    End If
                Next

                GCExportExcel.DataSource = data

                GVExportExcel.ExportToXls(save.FileName, op)

                infoCustom("File saved.")
            End If
        Else
            errorCustom("Please select payroll period.")
        End If
    End Sub

    Sub insert_jurnal(ByVal id_payroll As String)
        Dim is_thr As String = execute_query("SELECT is_thr FROM tb_emp_payroll_type WHERE id_payroll_type = (SELECT id_payroll_type FROM tb_emp_payroll WHERE id_payroll = " + id_payroll + ")", 0, True, "", "", "", "")

        If is_thr = "2" Then
            Dim payroll_det As DataTable = execute_query("SELECT DATE_FORMAT(periode_end, '%M %Y') AS periode, report_number FROM tb_emp_payroll WHERE id_payroll = " + id_payroll, -1, True, "", "", "", "")

            Dim data_gaji_map As DataTable = execute_query("SELECT id_acc, id_departement, id_departement_sub, id_comp, (SELECT comp_number FROM tb_m_comp WHERE id_comp = tb_coa_map_departement.id_comp) AS comp_number FROM tb_coa_map_departement WHERE type = 1", -1, True, "", "", "", "")
            Dim data_miss_map As DataTable = execute_query("SELECT id_acc, id_departement, id_departement_sub, id_comp, (SELECT comp_number FROM tb_m_comp WHERE id_comp = tb_coa_map_departement.id_comp) AS comp_number FROM tb_coa_map_departement WHERE type = 2", -1, True, "", "", "", "")

            Dim data_sum As DataTable = execute_query("CALL view_payroll_sum(" + id_payroll + ")", -1, True, "", "", "", "")

            Dim rmt As DataTable = execute_query("SELECT rm.id_user, rm.report_number FROM tb_report_mark rm WHERE rm.report_mark_type = 192 AND rm.id_report = '" + id_payroll + "' AND rm.id_report_status = 1", -1, True, "", "", "", "")

            Dim insert_jurnal As String = "INSERT INTO tb_a_acc_trans(acc_trans_number, report_number, id_bill_type, id_user, date_created, date_reference, acc_trans_note, id_report_status) VALUES ('" + header_number_acc("1") + "', '" + rmt.Rows(0)("report_number").ToString + "', '25', '" + rmt.Rows(0)("id_user").ToString + "', NOW(), (SELECT eff_trans_date FROM tb_emp_payroll WHERE id_payroll = " + id_payroll + "), 'Auto Posting', '6'); SELECT LAST_INSERT_ID(); "

            Dim id_acc_trans As String = execute_query(insert_jurnal, 0, True, "", "", "", "")

            'office
            Dim total_bpjskes As Decimal = 0.00
            Dim total_bpjsjp As Decimal = 0.00
            Dim total_bpjstk As Decimal = 0.00
            Dim total_missing As Decimal = 0.00
            Dim total_cash As Decimal = 0.00

            Dim total_all As Decimal = 0.00

            Dim insert_detail As String = "INSERT INTO tb_a_acc_trans_det (id_acc_trans, id_acc, id_comp, vendor, credit, debit, acc_trans_det_note, report_mark_type, id_report, report_number) VALUES "

            For i = 0 To data_sum.Rows.Count - 1
                If data_sum.Rows(i)("is_office_payroll").ToString = "1" Then
                    Dim salary As Decimal = data_sum.Rows(i)("salary") - data_sum.Rows(i)("d_other")

                    'get id_acc, id_comp, vendor gaji
                    Dim id_acc_gaji As String = ""
                    Dim id_comp As String = ""
                    Dim vendor As String = ""

                    For j = 0 To data_gaji_map.Rows.Count - 1
                        If data_sum.Rows(i)("id_departement").ToString = data_gaji_map.Rows(j)("id_departement").ToString Then
                            id_acc_gaji = data_gaji_map.Rows(j)("id_acc").ToString
                            id_comp = data_gaji_map.Rows(j)("id_comp").ToString
                            vendor = data_gaji_map.Rows(j)("comp_number").ToString

                            Exit For
                        End If
                    Next

                    insert_detail = insert_detail + "('" + id_acc_trans + "', '" + id_acc_gaji + "', '" + id_comp + "', '" + vendor + "', 0, " + decimalSQL(salary) + ", 'Gaji Karyawan " + payroll_det.Rows(0)("periode").ToString + "', 192, '" + id_payroll + "', '" + payroll_det.Rows(0)("report_number").ToString + "'), "

                    total_bpjskes = total_bpjskes + data_sum.Rows(i)("d_bpjskes")
                    total_bpjsjp = total_bpjsjp + data_sum.Rows(i)("d_jaminan_pensiun")
                    total_bpjstk = total_bpjstk + data_sum.Rows(i)("d_bpjstk")
                    total_missing = total_missing + data_sum.Rows(i)("d_missing")
                    total_cash = total_cash + data_sum.Rows(i)("d_meditation_cash")

                    total_all = total_all + salary
                End If
            Next

            total_all = total_all - (total_bpjskes + total_bpjsjp + total_bpjstk + total_missing + total_cash)

            If total_bpjskes > 0 Then
                insert_detail = insert_detail + "('" + id_acc_trans + "', 1153, 1, '000', " + decimalSQL(total_bpjskes) + ", 0, 'Gaji Karyawan " + payroll_det.Rows(0)("periode").ToString + " - Pot. BPJS Kesehatan', 192, '" + id_payroll + "', '" + payroll_det.Rows(0)("report_number").ToString + "'), "
            End If

            If total_bpjsjp > 0 Then
                insert_detail = insert_detail + "('" + id_acc_trans + "', 1153, 1, '000', " + decimalSQL(total_bpjsjp) + ", 0, 'Gaji Karyawan " + payroll_det.Rows(0)("periode").ToString + " - Pot. Jaminan Pensiun', 192, '" + id_payroll + "', '" + payroll_det.Rows(0)("report_number").ToString + "'), "
            End If

            If total_bpjstk > 0 Then
                insert_detail = insert_detail + "('" + id_acc_trans + "', 1153, 1, '000', " + decimalSQL(total_bpjstk) + ", 0, 'Gaji Karyawan " + payroll_det.Rows(0)("periode").ToString + " - Pot. BPJS TK', 192, '" + id_payroll + "', '" + payroll_det.Rows(0)("report_number").ToString + "'), "
            End If

            If total_missing > 0 Then
                insert_detail = insert_detail + "('" + id_acc_trans + "', 1161, 1, '000', " + decimalSQL(total_missing) + ", 0, 'Gaji Karyawan " + payroll_det.Rows(0)("periode").ToString + " - Pot. Tab. Missing Security', 192, '" + id_payroll + "', '" + payroll_det.Rows(0)("report_number").ToString + "'), "
            End If

            If total_cash > 0 Then
                insert_detail = insert_detail + "('" + id_acc_trans + "', 317, 1, '000', " + decimalSQL(total_cash) + ", 0, 'Gaji Karyawan " + payroll_det.Rows(0)("periode").ToString + " - Pot. Kas Bon', 192, '" + id_payroll + "', '" + payroll_det.Rows(0)("report_number").ToString + "'), "
            End If

            If total_all > 0 Then
                insert_detail = insert_detail + "('" + id_acc_trans + "', 1223, 1, '000', " + decimalSQL(total_all) + ", 0, 'Gaji Karyawan " + payroll_det.Rows(0)("periode").ToString + " - Office', 192, '" + id_payroll + "', '" + payroll_det.Rows(0)("report_number").ToString + "'), "
            End If

            'sogo
            total_bpjskes = 0.00
            total_bpjsjp = 0.00
            total_bpjstk = 0.00
            total_missing = 0.00
            total_cash = 0.00

            total_all = 0.00

            For i = 0 To data_sum.Rows.Count - 1
                If data_sum.Rows(i)("id_departement").ToString = "17" Then
                    Dim salary As Decimal = data_sum.Rows(i)("salary") - data_sum.Rows(i)("d_other")

                    'get id_acc, id_comp, vendor gaji
                    Dim id_acc_gaji As String = ""
                    Dim id_comp As String = ""
                    Dim vendor As String = ""

                    For j = 0 To data_gaji_map.Rows.Count - 1
                        If data_sum.Rows(i)("id_departement_sub").ToString = data_gaji_map.Rows(j)("id_departement_sub").ToString Then
                            id_acc_gaji = data_gaji_map.Rows(j)("id_acc").ToString
                            id_comp = data_gaji_map.Rows(j)("id_comp").ToString
                            vendor = data_gaji_map.Rows(j)("comp_number").ToString

                            Exit For
                        End If
                    Next

                    insert_detail = insert_detail + "('" + id_acc_trans + "', '" + id_acc_gaji + "', '" + id_comp + "', '" + vendor + "', 0, " + decimalSQL(salary) + ", 'Gaji Karyawan " + payroll_det.Rows(0)("periode").ToString + "', 192, '" + id_payroll + "', '" + payroll_det.Rows(0)("report_number").ToString + "'), "

                    total_bpjskes = total_bpjskes + data_sum.Rows(i)("d_bpjskes")
                    total_bpjsjp = total_bpjsjp + data_sum.Rows(i)("d_jaminan_pensiun")
                    total_bpjstk = total_bpjstk + data_sum.Rows(i)("d_bpjstk")
                    total_missing = total_missing + data_sum.Rows(i)("d_missing")
                    total_cash = total_cash + data_sum.Rows(i)("d_meditation_cash")

                    total_all = total_all + salary
                End If
            Next

            total_all = total_all - (total_bpjskes + total_bpjsjp + total_bpjstk + total_missing + total_cash)

            If total_bpjskes > 0 Then
                insert_detail = insert_detail + "('" + id_acc_trans + "', 1153, 1, '000', " + decimalSQL(total_bpjskes) + ", 0, 'Gaji Karyawan " + payroll_det.Rows(0)("periode").ToString + " - Pot. BPJS Kesehatan', 192, '" + id_payroll + "', '" + payroll_det.Rows(0)("report_number").ToString + "'), "
            End If

            If total_bpjsjp > 0 Then
                insert_detail = insert_detail + "('" + id_acc_trans + "', 1153, 1, '000', " + decimalSQL(total_bpjsjp) + ", 0, 'Gaji Karyawan " + payroll_det.Rows(0)("periode").ToString + " - Pot. Jaminan Pensiun', 192, '" + id_payroll + "', '" + payroll_det.Rows(0)("report_number").ToString + "'), "
            End If

            If total_bpjstk > 0 Then
                insert_detail = insert_detail + "('" + id_acc_trans + "', 1153, 1, '000', " + decimalSQL(total_bpjstk) + ", 0, 'Gaji Karyawan " + payroll_det.Rows(0)("periode").ToString + " - Pot. BPJS TK', 192, '" + id_payroll + "', '" + payroll_det.Rows(0)("report_number").ToString + "'), "
            End If

            For i = 0 To data_sum.Rows.Count - 1
                If data_sum.Rows(i)("id_departement").ToString = "17" Then
                    'get id_acc, id_comp, vendor missing
                    Dim id_acc_miss As String = ""
                    Dim id_comp As String = ""
                    Dim vendor As String = ""

                    For j = 0 To data_miss_map.Rows.Count - 1
                        If data_sum.Rows(i)("id_departement_sub").ToString = data_miss_map.Rows(j)("id_departement_sub").ToString Then
                            id_acc_miss = data_miss_map.Rows(j)("id_acc").ToString
                            id_comp = data_gaji_map.Rows(j)("id_comp").ToString
                            vendor = data_gaji_map.Rows(j)("comp_number").ToString

                            Exit For
                        End If
                    Next

                    insert_detail = insert_detail + "('" + id_acc_trans + "', " + id_acc_miss + ", '" + id_comp + "', '" + vendor + "', " + decimalSQL(data_sum.Rows(i)("d_missing")) + ", 0, 'Gaji Karyawan " + payroll_det.Rows(0)("periode").ToString + " - Pot. Tab. Missing', 192, '" + id_payroll + "', '" + payroll_det.Rows(0)("report_number").ToString + "'), "
                End If
            Next

            If total_cash > 0 Then
                insert_detail = insert_detail + "('" + id_acc_trans + "', 317, 1, '000', " + decimalSQL(total_cash) + ", 0, 'Gaji Karyawan " + payroll_det.Rows(0)("periode").ToString + " - Pot. Kas Bon', 192, '" + id_payroll + "', '" + payroll_det.Rows(0)("report_number").ToString + "'), "
            End If

            If total_all > 0 Then
                insert_detail = insert_detail + "('" + id_acc_trans + "', 1223, 1, '000', " + decimalSQL(total_all) + ", 0, 'Gaji Karyawan " + payroll_det.Rows(0)("periode").ToString + " - Sogo', 192, '" + id_payroll + "', '" + payroll_det.Rows(0)("report_number").ToString + "'), "
            End If

            execute_non_query(insert_detail.Substring(0, insert_detail.Length - 2), True, "", "", "", "")
        End If
    End Sub

    Sub insert_expense(ByVal id_payroll As String)
        Dim is_thr As String = execute_query("SELECT is_thr FROM tb_emp_payroll_type WHERE id_payroll_type = (SELECT id_payroll_type FROM tb_emp_payroll WHERE id_payroll = " + id_payroll + ")", 0, True, "", "", "", "")

        If is_thr = "2" Then
            Dim payroll_det As DataTable = execute_query("SELECT DATE_FORMAT(periode_end, '%Y') AS year FROM tb_emp_payroll WHERE id_payroll = " + id_payroll, -1, True, "", "", "", "")

            Dim data_sum As DataTable = execute_query("CALL view_payroll_sum(" + id_payroll + ")", -1, True, "", "", "", "")

            Dim year As String = execute_query("SELECT IFNULL((SELECT id_b_expense_opex FROM tb_b_expense_opex WHERE `year` = '" + payroll_det.Rows(0)("year").ToString + "' AND id_item_cat_main = '9'), 0) AS `year`", 0, True, "", "", "", "")

            If Not year = "0" Then
                Dim query As String = "INSERT INTO tb_b_expense_opex_trans (id_b_expense_opex, is_po, id_departement, date_trans, value, id_item, id_report, report_mark_type, note) VALUES "

                For i = 0 To data_sum.Rows.Count - 1
                    Dim id_departement As String = data_sum.Rows(i)("id_departement").ToString
                    Dim salary As Decimal = data_sum.Rows(i)("salary") - data_sum.Rows(i)("d_other")

                    query += "(" + year + ", 2, " + id_departement + ", NOW(), " + decimalSQL(salary) + ", NULL, " + id_payroll + ", 192, 'Biaya Gaji'), "
                Next

                query = query.Substring(0, query.Length - 2)

                execute_non_query(query, True, "", "", "", "")
            End If
        End If
    End Sub

    Private Sub BtnViewJournal_Click(sender As Object, e As EventArgs) Handles BtnViewJournal.Click
        Cursor = Cursors.WaitCursor
        Dim id_acc_trans As String = ""
        Try
            id_acc_trans = execute_query("SELECT ad.id_acc_trans FROM tb_a_acc_trans_det ad
            WHERE ad.report_mark_type = 192 AND ad.id_report = " + GVPayrollPeriode.GetFocusedRowCellValue("id_payroll").ToString + "
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

    Sub check_diff()
        Dim is_thr As String = execute_query("SELECT is_thr FROM tb_emp_payroll_type WHERE id_payroll_type = (SELECT id_payroll_type FROM tb_emp_payroll WHERE id_payroll = " + GVPayrollPeriode.GetFocusedRowCellValue("id_payroll").ToString + ")", 0, True, "", "", "", "")

        Dim dataNew As DataTable = execute_query("
            SELECT *
            FROM (
                SELECT sal.id_employee_salary, sal.id_employee, IF(emp.id_employee_status = 3, (sal.basic_salary * dep.total_workdays), (sal.basic_salary + sal.allow_job + sal.allow_meal + sal.allow_trans)) AS sal
                FROM tb_m_employee_salary AS sal
                LEFT JOIN tb_m_employee AS emp ON sal.id_employee = emp.id_employee
                LEFT JOIN tb_m_departement AS dep ON emp.id_departement = dep.id_departement
                ORDER BY sal.id_employee_salary DESC, sal.effective_date DESC
            ) AS tb
            GROUP BY id_employee
        ", -1, True, "", "", "", "")

        For i = 0 To GVPayroll.RowCount - 1
            If GVPayroll.IsValidRowHandle(i) Then
                For j = 0 To dataNew.Rows.Count - 1
                    If GVPayroll.GetRowCellValue(i, "id_employee").ToString = dataNew.Rows(j)("id_employee").ToString Then
                        If Not GVPayroll.GetRowCellValue(i, "id_salary").ToString = dataNew.Rows(j)("id_employee_salary").ToString Then
                            warningCustom(GVPayroll.GetRowCellValue(i, "employee_name").ToString + " Will Updated.")

                            'update id_salary
                            Dim q_salary As String = "
                                UPDATE tb_emp_payroll_det SET id_salary = " + dataNew.Rows(j)("id_employee_salary").ToString + " WHERE id_employee = " + GVPayroll.GetRowCellValue(i, "id_employee").ToString + " AND id_payroll = " + GVPayrollPeriode.GetFocusedRowCellValue("id_payroll").ToString +
                            ""

                            execute_non_query(q_salary, True, "", "", "", "")

                            If is_thr = "2" Then
                                'update koprasi
                                Dim q_koprasi As String = "
	                                DELETE FROM tb_emp_payroll_deduction
	                                WHERE id_salary_deduction='4' AND id_payroll=" + GVPayrollPeriode.GetFocusedRowCellValue("id_payroll").ToString + " AND id_employee = " + GVPayroll.GetRowCellValue(i, "id_employee").ToString + ";
	
	                                INSERT INTO tb_emp_payroll_deduction(id_payroll,id_salary_deduction,id_employee,deduction)
	                                SELECT py.id_payroll,4 AS `id_salary_deduction`,emp.`id_employee`,py.`koperasi_iuran` AS deduction
	                                FROM `tb_emp_payroll_det` pyd
	                                INNER JOIN `tb_emp_payroll` py ON py.`id_payroll`=pyd.`id_payroll`
	                                INNER JOIN tb_m_employee emp ON emp.`id_employee`=pyd.`id_employee`
	                                WHERE emp.`is_koperasi`='1' AND py.id_payroll=" + GVPayrollPeriode.GetFocusedRowCellValue("id_payroll").ToString + " AND pyd.id_employee = " + GVPayroll.GetRowCellValue(i, "id_employee").ToString + ";
                                "

                                execute_non_query(q_koprasi, True, "", "", "", "")

                                'update jamsostek
                                Dim q_jamsostek As String = "
                                    DELETE pd.* FROM tb_emp_payroll_deduction pd
	                                INNER JOIN tb_lookup_salary_deduction sd ON sd.id_salary_deduction=pd.id_salary_deduction
	                                WHERE sd.is_jamsostek='1' AND pd.id_payroll=" + GVPayrollPeriode.GetFocusedRowCellValue("id_payroll").ToString + " AND pd.id_employee = " + GVPayroll.GetRowCellValue(i, "id_employee").ToString + ";
	                                INSERT INTO tb_emp_payroll_deduction(id_payroll,id_salary_deduction,id_employee,deduction)
	                                SELECT " + GVPayrollPeriode.GetFocusedRowCellValue("id_payroll").ToString + " AS id_payroll,id_salary_deduction,id_employee,deduction FROM
	                                (SELECT emp.`id_employee`
	                                ,IF(emp.`id_employee_status` = 3, (sal.`basic_salary` * dep.total_workdays), (sal.`basic_salary`+sal.`allow_job`+sal.`allow_meal`+sal.`allow_trans`)) AS gp
	                                ,CAST(IF((SELECT gp)<=py.`jp_max`,(SELECT gp)*0.01,py.`jp_max`*0.01) AS DECIMAL(13,2)) AS deduction
	                                ,lsal.`id_salary_deduction`
	                                FROM `tb_emp_payroll_det` pyd
	                                INNER JOIN `tb_emp_payroll` py ON py.`id_payroll`=pyd.`id_payroll`
	                                INNER JOIN tb_m_employee emp ON emp.`id_employee`=pyd.`id_employee`
                                    INNER JOIN tb_m_departement dep ON emp.`id_departement`=dep.`id_departement`
	                                INNER JOIN `tb_m_employee_salary` sal ON sal.`id_employee_salary`=pyd.`id_salary`
	                                INNER JOIN `tb_lookup_salary_deduction` lsal ON lsal.`id_salary_deduction`=2
	                                WHERE emp.`is_jp`='1' AND pyd.`id_payroll`=" + GVPayrollPeriode.GetFocusedRowCellValue("id_payroll").ToString + " AND pyd.id_employee = " + GVPayroll.GetRowCellValue(i, "id_employee").ToString + "
	                                UNION
	                                SELECT emp.`id_employee`
	                                ,IF(emp.`id_employee_status` = 3, (sal.`basic_salary` * dep.total_workdays), (sal.`basic_salary`+sal.`allow_job`+sal.`allow_meal`+sal.`allow_trans`)) AS gp
	                                ,CAST((SELECT gp)*0.02 AS DECIMAL(13,2)) AS deduction
	                                ,lsal.`id_salary_deduction`
	                                FROM `tb_emp_payroll_det` pyd
	                                INNER JOIN `tb_emp_payroll` py ON py.`id_payroll`=pyd.`id_payroll`
	                                INNER JOIN tb_m_employee emp ON emp.`id_employee`=pyd.`id_employee`
                                    INNER JOIN tb_m_departement dep ON emp.`id_departement`=dep.`id_departement`
	                                INNER JOIN `tb_m_employee_salary` sal ON sal.`id_employee_salary`=pyd.`id_salary`
	                                INNER JOIN `tb_lookup_salary_deduction` lsal ON lsal.`id_salary_deduction`=3
	                                WHERE emp.`is_jht`='1' AND pyd.`id_payroll`=" + GVPayrollPeriode.GetFocusedRowCellValue("id_payroll").ToString + " AND pyd.id_employee = " + GVPayroll.GetRowCellValue(i, "id_employee").ToString + ") a;
                                "

                                execute_non_query(q_jamsostek, True, "", "", "", "")

                                'update adjustment
                                Dim q_adj As String = "
                                    SELECT adj.*, dep.total_workdays
                                    FROM tb_emp_payroll_adj AS adj
                                    LEFT JOIN tb_m_employee AS emp ON adj.id_employee = emp.id_employee
                                    LEFT JOIN tb_m_departement AS dep ON emp.id_departement = dep.id_departement
                                    WHERE adj.id_employee = " + GVPayroll.GetRowCellValue(i, "id_employee").ToString + " AND adj.id_payroll = " + GVPayrollPeriode.GetFocusedRowCellValue("id_payroll").ToString + " AND adj.total_days <> 0
                                "

                                Dim d_adj As DataTable = execute_query(q_adj, -1, True, "", "", "", "")

                                For k = 0 To d_adj.Rows.Count - 1
                                    Dim total_days As Decimal = d_adj.Rows(k)("total_days")
                                    Dim workdays As Decimal = d_adj.Rows(k)("total_workdays")
                                    Dim total_salary As Decimal = dataNew.Rows(j)("sal")

                                    Dim value As Decimal = 0

                                    If GVPayrollPeriode.GetFocusedRowCellValue("is_thr").ToString = "1" Then
                                        value = total_days * total_salary
                                    Else
                                        value = (total_days / workdays) * total_salary
                                    End If

                                    Dim q_uadj As String = "UPDATE tb_emp_payroll_adj SET increase = '" + decimalSQL(total_salary) + "', value = '" + decimalSQL(value) + "' WHERE id_payroll_adj = " + d_adj.Rows(k)("id_payroll_adj").ToString

                                    execute_non_query(q_uadj, True, "", "", "", "")
                                Next

                                'update deduction
                                Dim q_ded As String = "
                                    SELECT ded.*, dep.total_workdays
                                    FROM tb_emp_payroll_deduction AS ded
                                    LEFT JOIN tb_m_employee AS emp ON ded.id_employee = emp.id_employee
                                    LEFT JOIN tb_m_departement AS dep ON emp.id_departement = dep.id_departement
                                    WHERE ded.id_employee = " + GVPayroll.GetRowCellValue(i, "id_employee").ToString + " AND ded.id_payroll = " + GVPayrollPeriode.GetFocusedRowCellValue("id_payroll").ToString + " AND ded.total_days <> 0 AND ded.total_days IS NOT NULL
                                "

                                Dim d_ded As DataTable = execute_query(q_ded, -1, True, "", "", "", "")

                                For k = 0 To d_ded.Rows.Count - 1
                                    Dim total_days As Decimal = d_ded.Rows(k)("total_days")
                                    Dim workdays As Decimal = d_ded.Rows(k)("total_workdays")
                                    Dim total_salary As Decimal = dataNew.Rows(j)("sal")

                                    Dim value As Decimal = 0

                                    If GVPayrollPeriode.GetFocusedRowCellValue("is_thr").ToString = "1" Then
                                        value = total_days * total_salary
                                    Else
                                        value = (total_days / workdays) * total_salary
                                    End If

                                    Dim q_uded As String = "UPDATE tb_emp_payroll_deduction SET increase = '" + decimalSQL(total_salary) + "', deduction = '" + decimalSQL(value) + "' WHERE id_payroll_deduction = " + d_ded.Rows(k)("id_payroll_deduction").ToString

                                    execute_non_query(q_uded, True, "", "", "", "")
                                Next
                            End If
                        End If
                    End If
                Next
            End If
        Next
    End Sub
End Class