Public Class FormEmpPayroll
    Dim bnew_active As String = "1"
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
        Dim query As String = "SELECT pr.*,emp.`employee_name`,type.payroll_type as payroll_type_name,DATE_FORMAT(pr.periode_end,'%M %Y') AS payroll_name, IFNULL((SELECT report_status FROM tb_lookup_report_status WHERE id_report_status = pr.id_report_status), 'Not Submitted') AS report_status FROM tb_emp_payroll pr
                                INNER JOIn tb_emp_payroll_type type ON type.id_payroll_type=pr.id_payroll_type
                                INNER JOIN tb_m_user usr ON usr.id_user=pr.id_user_upd
                                INNER JOIN tb_m_employee emp ON emp.`id_employee`=usr.id_employee
                                ORDER BY pr.periode_end DESC"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        '
        GCPayrollPeriode.DataSource = data
        '
        check_but()
    End Sub

    Sub check_but()
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

    Private Sub GVPayrollPeriode_FocusedRowChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles GVPayrollPeriode.FocusedRowChanged
        load_payroll_detail()
    End Sub

    Sub load_payroll_detail()
        If GVPayrollPeriode.RowCount > 0 Then
            Dim query As String = "CALL view_payroll('" & GVPayrollPeriode.GetFocusedRowCellValue("id_payroll").ToString & "')"
            Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")

            GCPayroll.DataSource = data
            GVPayroll.BestFitColumns()

            ' controls
            Dim id_report_status As String = execute_query("SELECT id_report_status FROM tb_emp_payroll WHERE id_payroll = '" + GVPayrollPeriode.GetFocusedRowCellValue("id_payroll").ToString + "'", 0, True, "", "", "", "")

            If id_report_status = "0" Then
                BGetEmployee.Enabled = True
                BRemoveEmployee.Enabled = True
                BMark.Enabled = False
                BandedGridColumnCheck.OptionsColumn.AllowEdit = False
                BandedGridColumnPending.OptionsColumn.AllowEdit = True
                BandedGridColumnCash.OptionsColumn.AllowEdit = True
                BReport.Enabled = False
                BPrintSlip.Enabled = False
                BPrint.Enabled = False
                BReset.Visible = False
                BSubmit.Visible = True
                CheckEditSelAll.Enabled = False
            Else
                BGetEmployee.Enabled = False
                BRemoveEmployee.Enabled = False
                BMark.Enabled = True
                BandedGridColumnCheck.OptionsColumn.AllowEdit = False
                BandedGridColumnPending.OptionsColumn.AllowEdit = False
                BandedGridColumnCash.OptionsColumn.AllowEdit = False
                BReport.Enabled = False
                BPrintSlip.Enabled = False
                BPrint.Enabled = False
                BReset.Visible = True
                BSubmit.Visible = False
                CheckEditSelAll.Enabled = False
            End If

            If id_report_status = "6" Then
                BandedGridColumnCheck.OptionsColumn.AllowEdit = True
                BReport.Enabled = True
                BPrintSlip.Enabled = True
                BPrint.Enabled = True
                BReset.Visible = False
                CheckEditSelAll.Enabled = True
            End If
        End If
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
        Dim id_employee As String = GVPayroll.GetFocusedRowCellValue("id_employee").ToString
        Dim id_payroll As String = GVPayrollPeriode.GetFocusedRowCellValue("id_payroll").ToString
        '
        Dim query As String = "DELETE FROM tb_emp_payroll_det WHERE id_employee='" & id_employee & "' AND id_payroll='" & id_payroll & "'"
        execute_non_query(query, True, "", "", "", "")
        load_payroll_detail()
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
        If GVPayroll.RowCount > 0 Then
            Dim confirm As DialogResult
            confirm = DevExpress.XtraEditors.XtraMessageBox.Show("Are you sure want to delete ?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
            If confirm = Windows.Forms.DialogResult.Yes Then
                Dim query As String = "DELETE FROM tb_emp_payroll_det WHERE id_payroll_det='" & GVPayroll.GetFocusedRowCellValue("id_payroll_det").ToString & "'"
                execute_non_query(query, True, "", "", "", "")
                '
                load_payroll_detail()
            End If
        End If
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
            makeSafeGV(GVPayroll)
            GVPayroll.ActiveFilterString = "[is_check]='yes'"
            If GVPayroll.RowCount > 0 Then
                For i As Integer = 0 To GVPayroll.RowCount - 1
                    If i = 0 Then
                        where_string = GVPayroll.GetRowCellValue(i, "id_payroll_det").ToString
                    Else
                        where_string += "," & GVPayroll.GetRowCellValue(i, "id_payroll_det").ToString
                    End If
                Next
                makeSafeGV(GVPayroll)
                '
                ReportSalarySlip.where_string = where_string
                ReportSalarySlip.id_payroll = GVPayrollPeriode.GetFocusedRowCellValue("id_payroll").ToString
                Dim Report As New ReportSalarySlip()
                Dim Tool As DevExpress.XtraReports.UI.ReportPrintTool = New DevExpress.XtraReports.UI.ReportPrintTool(Report)
                Tool.ShowPreviewDialog()
                Cursor = Cursors.Default
            Else
                stopCustom("Please choose employee first.")
                GVPayroll.ActiveFilterString = ""
                Cursor = Cursors.Default
            End If
        End If
    End Sub

    Private Sub GVPayroll_CellValueChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles GVPayroll.CellValueChanged
        If e.Column.FieldName.ToString = "actual_workdays" Then
            If Not e.Value.ToString = "" And GVPayroll.RowCount > 0 Then
                Dim id_det As String = GVPayroll.GetFocusedRowCellValue("id_payroll_det").ToString
                Dim query_upd As String = "UPDATE tb_emp_payroll_det SET actual_workdays='" & decimalSQL(Decimal.Parse(e.Value.ToString).ToString) & "' WHERE id_payroll_det='" & id_det & "'"
                execute_non_query(query_upd, True, "", "", "", "")
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
        End If
    End Sub

    Private Sub BarButtonItem1_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem1.ItemClick
        FormEmpPayrollReportSummary.ShowDialog()
    End Sub

    Private Sub BarButtonItem2_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem2.ItemClick
        FormEmpPayrollReportOTEvent.ShowDialog()
    End Sub

    Private Sub BPrint_Click(sender As Object, e As EventArgs) Handles BPrint.Click

        ReportPayrollAll.id_payroll = GVPayrollPeriode.GetFocusedRowCellValue("id_payroll")
        ReportPayrollAll.dt = GCPayroll.DataSource
        ReportPayrollAll.no_column = no_column
        Dim Report As New ReportPayrollAll()

        ' Show the report's preview. 
        Dim Tool As DevExpress.XtraReports.UI.ReportPrintTool = New DevExpress.XtraReports.UI.ReportPrintTool(Report)
        Tool.ShowPreview()
        '
        ReportPayrollAll2.id_payroll = GVPayrollPeriode.GetFocusedRowCellValue("id_payroll")
        ReportPayrollAll2.dt = GCPayroll.DataSource
        ReportPayrollAll2.no_column = no_column
        Dim Report2 As New ReportPayrollAll2()

        ' Show the report's preview. 
        Dim Tool2 As DevExpress.XtraReports.UI.ReportPrintTool = New DevExpress.XtraReports.UI.ReportPrintTool(Report2)
        Tool2.ShowPreview()
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
End Class