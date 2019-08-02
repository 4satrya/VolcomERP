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
        Dim query As String = "SELECT pr.*,emp.`employee_name`,type.payroll_type as payroll_type_name,DATE_FORMAT(pr.periode_end,'%M %Y') AS payroll_name, IFNULL((SELECT report_status FROM tb_lookup_report_status WHERE id_report_status = pr.id_report_status), 'Not Submitted') AS report_status FROM tb_emp_payroll pr
                                INNER JOIn tb_emp_payroll_type type ON type.id_payroll_type=pr.id_payroll_type
                                INNER JOIN tb_m_user usr ON usr.id_user=pr.id_user_upd
                                INNER JOIN tb_m_employee emp ON emp.`id_employee`=usr.id_employee
                                ORDER BY pr.periode_end DESC, type.sort ASC"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        '
        GCPayrollPeriode.DataSource = data
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

            'grand total dw
            If GVPayrollPeriode.GetFocusedRowCellValue("id_payroll_type").ToString = "4" Then
                calculate_grandtotal_dw()
            End If

            GVPayroll.BestFitColumns()

            'controls
            Dim id_report_status As String = execute_query("SELECT id_report_status FROM tb_emp_payroll WHERE id_payroll = '" + GVPayrollPeriode.GetFocusedRowCellValue("id_payroll").ToString + "'", 0, True, "", "", "", "")

            If id_report_status = "0" Then
                BGetEmployee.Enabled = True
                BRemoveEmployee.Enabled = True
                BMark.Enabled = False
                BandedGridColumnPending.OptionsColumn.AllowEdit = True
                BandedGridColumnCash.OptionsColumn.AllowEdit = True
                'BReport.Enabled = False
                BPrintSlip.Enabled = False
                SBSendSlip.Enabled = False
                BPrint.Enabled = False
                BReset.Visible = False
                BSubmit.Visible = True
                CMDelEmp.Enabled = True
            Else
                BGetEmployee.Enabled = False
                BRemoveEmployee.Enabled = False
                BMark.Enabled = True
                BandedGridColumnActWorkdaysDW.OptionsColumn.AllowEdit = False
                BandedGridColumnPending.OptionsColumn.AllowEdit = False
                BandedGridColumnCash.OptionsColumn.AllowEdit = False
                'BReport.Enabled = True
                BPrintSlip.Enabled = False
                SBSendSlip.Enabled = False
                BPrint.Enabled = True
                BReset.Visible = True
                BSubmit.Visible = False
                CMDelEmp.Enabled = False
            End If

            If id_report_status = "6" Then
                BPrintSlip.Enabled = True
                SBSendSlip.Enabled = True
                BReset.Visible = False
            End If

            'grid
            If GVPayrollPeriode.GetFocusedRowCellValue("id_payroll_type").ToString = "1" Then
                GBWorkingDays.Visible = True
                GBSalary.Visible = True
                GBBonusAdjustment.Visible = True

                GBDW.Visible = False
            ElseIf GVPayrollPeriode.GetFocusedRowCellValue("id_payroll_type").ToString = "4" Then
                GBWorkingDays.Visible = False
                GBSalary.Visible = False
                GBBonusAdjustment.Visible = False

                GBDW.Visible = True
            End If

            'button
            If GVPayrollPeriode.GetFocusedRowCellValue("id_payroll_type").ToString = "1" Then
                BBonusAdjustment.Visible = True
            Else
                BBonusAdjustment.Visible = False
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
        End If

        Cursor = Cursors.Default
    End Sub

    Sub calculate_grandtotal_dw()
        For i = 0 To GVPayroll.RowCount - 1
            If GVPayroll.IsValidRowHandle(i) Then
                Dim grand_total As Decimal = (GVPayroll.GetRowCellValue(i, "basic_salary") * GVPayroll.GetRowCellValue(i, "actual_workdays")) + GVPayroll.GetRowCellValue(i, "total_ot_wages") - GVPayroll.GetRowCellValue(i, "total_deduction")

                GVPayroll.SetRowCellValue(i, "grand_total", grand_total)
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
        Dim data_payroll_1 As DataTable = data.Clone

        For j = 0 To data.Rows.Count - 1
            If data.Rows(j)("is_office_payroll").ToString = "1" Then
                data_payroll_1.ImportRow(data.Rows(j))
            End If
        Next

        Dim report_office_1 As ReportPayrollAll = New ReportPayrollAll

        report_office_1.PrintingSystem.ContinuousPageNumbering = False

        report_office_1.id_payroll = GVPayrollPeriode.GetFocusedRowCellValue("id_payroll").ToString
        report_office_1.dt = data_payroll_1
        report_office_1.id_pre = If(id_report_status = "6", "-1", "1")
        report_office_1.type = GVPayrollPeriode.GetFocusedRowCellValue("id_payroll_type").ToString

        report_office_1.XLPeriod.Text = Date.Parse(GVPayrollPeriode.GetFocusedRowCellValue("periode_end").ToString).ToString("MMMM yyyy")
        report_office_1.XLType.Text = GVPayrollPeriode.GetFocusedRowCellValue("payroll_type_name").ToString
        report_office_1.XLLocation.Text = "Office"

        report_office_1.CreateDocument()

        'store
        Dim data_payroll_2 As DataTable = data.Clone

        For j = 0 To data.Rows.Count - 1
            If data.Rows(j)("is_office_payroll").ToString = "2" Then
                data_payroll_2.ImportRow(data.Rows(j))
            End If
        Next

        Dim report_office_2 As ReportPayrollAll = New ReportPayrollAll

        report_office_2.id_payroll = GVPayrollPeriode.GetFocusedRowCellValue("id_payroll").ToString
        report_office_2.dt = data_payroll_2
        report_office_2.id_pre = If(id_report_status = "6", "-1", "1")
        report_office_2.type = GVPayrollPeriode.GetFocusedRowCellValue("id_payroll_type").ToString

        report_office_2.XLPeriod.Text = Date.Parse(GVPayrollPeriode.GetFocusedRowCellValue("periode_end").ToString).ToString("MMMM yyyy")
        report_office_2.XLType.Text = GVPayrollPeriode.GetFocusedRowCellValue("payroll_type_name").ToString
        report_office_2.XLLocation.Text = "Store"

        report_office_2.CreateDocument()

        'combine
        Dim list As List(Of DevExpress.XtraPrinting.Page) = New List(Of DevExpress.XtraPrinting.Page)

        'report_office_1
        If already_office Then
            For i = 0 To report_office_1.Pages.Count - 1
                list.Add(report_office_1.Pages(i))
            Next
        End If

        'report_office_2
        If already_store Then
            For i = 0 To report_office_2.Pages.Count - 1
                list.Add(report_office_2.Pages(i))
            Next
        End If

        If already_office Then
            report_office_1.Pages.AddRange(list)

            Dim tool As DevExpress.XtraReports.UI.ReportPrintTool = New DevExpress.XtraReports.UI.ReportPrintTool(report_office_1)

            tool.ShowPreview()
        End If

        If already_store And Not already_office Then
            report_office_2.Pages.AddRange(list)

            Dim tool As DevExpress.XtraReports.UI.ReportPrintTool = New DevExpress.XtraReports.UI.ReportPrintTool(report_office_2)

            tool.ShowPreview()
        End If
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
        'column
        Dim where_adj_c As String = ""

        If Not GVPayrollPeriode.GetFocusedRowCellValue("id_payroll_type").ToString = "1" Then
            where_adj_c = "WHERE id_salary_" + type + "_cat IN (SELECT id_salary_" + type + "_cat FROM tb_lookup_salary_" + type + " WHERE use_dw = 1)"
        End If

        Dim query_adj_c As String = "SELECT salary_" + type + "_cat FROM tb_lookup_salary_" + type + "_cat" + " " + where_adj_c

        Dim data_adj_c As DataTable = execute_query(query_adj_c, -1, True, "", "", "", "")

        For i = 0 To data_adj_c.Rows.Count - 1
            Dim field_name As String = data_adj_c.Rows(i)("salary_" + type + "_cat").ToString + " " + type

            'remove if exist
            GVPayroll.Columns.Remove(GVPayroll.Columns(field_name))

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

    Private Sub BarButtonItem5_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem5.ItemClick
        'bpjstk
        FormEmpPayrollReportBPJSTK.id_payroll = GVPayrollPeriode.GetFocusedRowCellValue("id_payroll").ToString

        FormEmpPayrollReportBPJSTK.ShowDialog()
    End Sub

    Private Sub BarButtonItem4_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem4.ItemClick
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

                                Dim mem As New IO.MemoryStream()

                                Dim report As ReportSalarySlip = New ReportSalarySlip

                                report.where_string = GVPayroll.GetRowCellValue(i, "id_payroll_det").ToString
                                report.id_payroll = GVPayrollPeriode.GetFocusedRowCellValue("id_payroll").ToString

                                report.ExportOptions.Pdf.PasswordSecurityOptions.OpenPassword = GVPayroll.GetRowCellValue(i, "employee_dob").ToString

                                report.ExportToPdf(mem)

                                mem.Seek(0, System.IO.SeekOrigin.Begin)

                                Dim att = New Net.Mail.Attachment(mem, "Salary Slip " + period + ".pdf", "application/pdf")

                                'mail
                                Dim mail As Net.Mail.MailMessage = New Net.Mail.MailMessage()

                                'from
                                Dim from_mail As Net.Mail.MailAddress = New Net.Mail.MailAddress("system@volcom.co.id", "Volcom ERP")

                                mail.From = from_mail

                                'to
                                Dim to_mail As Net.Mail.MailAddress = New Net.Mail.MailAddress(email_personal, employee_name)

                                mail.To.Add(to_mail)

                                mail.Subject = "PT. VOLCOM INDONESIA - SALARY SLIP " + period.ToUpper
                                mail.IsBodyHtml = True
                                mail.Body = "
                                    <p style='font: normal 10.00pt/14.25pt Arial'><b>Dear " + employee_name + ",</b></p>
                                    <br>
                                    <p style='font: normal 10.00pt/14.25pt Arial'>Here is your salary slip in " + period + ".</p>
                                    <br>
                                    <p style='font: normal 10.00pt/14.25pt Arial'>Thank You</p>
                                    <p style='font: normal 10.00pt/14.25pt Arial'><b>Volcom ERP</b></p>
                                "

                                mail.Attachments.Add(att)

                                client.Send(mail)
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
End Class