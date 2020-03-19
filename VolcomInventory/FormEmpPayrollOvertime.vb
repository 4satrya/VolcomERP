Public Class FormEmpPayrollOvertime
    Public id_periode As String = "-1"
    Public id_report_status As String = "0"

    Private Sub FormEmpPayrollOvertime_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub FormEmpPayrollOvertime_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'load_payroll_periode()
        load_payroll_ot()
        load_payroll_dp()

        id_report_status = execute_query("SELECT id_report_status FROM tb_emp_payroll WHERE id_payroll = '" + FormEmpPayroll.GVPayrollPeriode.GetFocusedRowCellValue("id_payroll").ToString + "'", 0, True, "", "", "", "")

        If id_report_status = "0" Then
            SBPrint.Enabled = False
        Else
            SBPrint.Enabled = True
        End If
    End Sub

    Sub load_payroll_periode()
        Dim query As String = "SELECT p.id_payroll,p.ot_periode_start,p.ot_periode_end,DATE_FORMAT(`ot_periode_end`,'%M %Y') as periode FROM tb_emp_payroll p WHERE id_payroll_type = 1"
        viewLookupQuery(LEPayrollPeriode, query, 0, "periode", "id_payroll")
        If Not id_periode = "-1" Then
            LEPayrollPeriode.ItemIndex = LEPayrollPeriode.Properties.GetDataSourceRowIndex("id_payroll", id_periode)
        End If
    End Sub

    Sub load_payroll_ot()
        Dim id_payroll As String = id_periode

        'get id_payroll if dw
        If FormEmpPayroll.GVPayrollPeriode.GetFocusedRowCellValue("id_payroll_type").ToString = "4" Then
            id_payroll = execute_query("
                SELECT id_payroll 
                FROM tb_emp_payroll
                WHERE periode_start = (SELECT periode_start FROM tb_emp_payroll WHERE id_payroll = " + id_payroll + ") AND periode_end = (SELECT periode_end FROM tb_emp_payroll WHERE id_payroll = " + id_payroll + ") AND id_payroll_type = 1
                LIMIT 1
            ", 0, True, "", "", "", "")
        End If

        'where organic or dw
        Dim where_staff As String = If(FormEmpPayroll.GVPayrollPeriode.GetFocusedRowCellValue("id_payroll_type").ToString = "4", "IFNULL(sts.`id_employee_status`, sts_ori.`id_employee_status`) = 3", "IFNULL(sts.`id_employee_status`, sts_ori.`id_employee_status`) <> 3")

        'where wages dw
        Dim where_wages As String = "IF(p.increase = 0.00, (SELECT (" + If(FormEmpPayroll.GVPayrollPeriode.GetFocusedRowCellValue("id_payroll_type").ToString = "4", "sal.`basic_salary` * (IFNULL(dep.total_workdays, dep_ori.total_workdays))", "sal.`basic_salary` + sal.`allow_job` + sal.`allow_meal` + sal.`allow_trans`") + ") FROM tb_emp_payroll_det AS pd LEFT JOIN tb_m_employee_salary AS sal ON pd.id_salary = sal.id_employee_salary WHERE pd.id_employee = p.`id_employee` AND pd.id_payroll = '" & id_periode & "'), p.increase)"

        Dim query As String = "SELECT p.id_payroll_ot,p.`id_payroll`,IF(IFNULL(dep.is_office_payroll, dep_ori.is_office_payroll) = '2', 'STORE', 'OFFICE') AS group_report,p.`id_employee`,p.`id_ot_type`,DATE_FORMAT(p.`ot_start`, '%d %M %Y') AS ot_date, DATE_FORMAT(p.`ot_start`, '%d %b %Y %H:%i:%s') AS ot_start, DATE_FORMAT(p.`ot_end`, '%d %b %Y %H:%i:%s') AS ot_end,p.`total_break`,ROUND((TIMESTAMPDIFF(MINUTE, p.`ot_start`, p.`ot_end`) / 60) - p.`total_break`, 1) AS total_hour_actual,p.`total_hour`,p.`total_point`,IF(p.`is_day_off`=1,'Yes','No') AS day_off,IFNULL(dep.departement, dep_ori.departement) AS departement,IF(dep.id_departement = 17, IFNULL(sub.departement_sub, sub_ori.departement_sub), IFNULL(dep.departement, dep_ori.departement)) AS departement_sub,IFNULL(emp_pos.employee_position,emp.`employee_position`) AS employee_position,IFNULL(sts.`employee_status`, sts_ori.`employee_status`) AS employee_status,emp.`employee_name`,emp.`employee_code`,CONCAT(IF(ott.`is_event` = 1, 'Event ', ''), ott.`ot_type`) AS ot_type, ROUND(IF(ott.`is_event` = 1, p.wages_per_point, (" + where_wages + " * (pay.ot_reg_pembilang / pay.ot_reg_penyebut))),10) AS wages_per_point, ROUND(IF(ott.`is_event` = 1, p.`total_point` * p.wages_per_point, p.`total_point` * (" + where_wages + " * (pay.ot_reg_pembilang / pay.ot_reg_penyebut))),10) AS wages_per_point_total, p.note, dep.is_office_payroll, ott.`id_ot_type`
                FROM tb_emp_payroll_ot p
                LEFT JOIN `tb_lookup_ot_type` ott ON ott.`id_ot_type`=p.`id_ot_type`
                LEFT JOIN tb_m_employee emp ON emp.`id_employee`=p.`id_employee`
                LEFT JOIN (
                    SELECT * FROM (
                        SELECT id_employee, id_departement, id_departement_sub, employee_position, employee_position_date
                        FROM tb_m_employee_position
                        WHERE employee_position_date <= (SELECT periode_end FROM tb_emp_payroll WHERE id_payroll = '" & id_payroll & "')
                        ORDER BY id_employee_position DESC
                    ) AS tab
                    GROUP BY id_employee
                ) AS emp_pos ON p.id_employee = emp_pos.id_employee
                LEFT JOIN tb_m_departement dep ON dep.id_departement=emp_pos.id_departement
                LEFT JOIN tb_m_departement dep_ori ON dep_ori.id_departement = emp.id_departement
                LEFT JOIN tb_m_departement_sub sub ON sub.`id_departement_sub`=emp_pos.`id_departement_sub`
                LEFT JOIN tb_m_departement_sub sub_ori ON sub_ori.id_departement_sub = emp.id_departement_sub
                LEFT JOIN tb_emp_payroll pay ON p.`id_payroll`=pay.`id_payroll`
                LEFT JOIN (
                    SELECT * FROM (
                        SELECT det.*, lookup.employee_status 
                        FROM tb_m_employee_status_det AS det
                        LEFT JOIN tb_lookup_employee_status AS lookup ON det.id_employee_status = lookup.id_employee_status
                        LEFT JOIN tb_m_employee AS emp ON det.id_employee = emp.id_employee
		                LEFT JOIN tb_m_departement AS dep ON emp.id_departement = dep.id_departement
                        WHERE det.start_period <= IF(dep.is_store = 2, (SELECT periode_end FROM tb_emp_payroll WHERE id_payroll = '" & id_payroll & "'), (SELECT store_periode_end FROM tb_emp_payroll WHERE id_payroll = '" & id_payroll & "'))
                        ORDER BY det.id_employee_status_det DESC
                    ) AS tab
                    GROUP BY id_employee
                ) AS sts ON p.id_employee = sts.id_employee
                LEFT JOIN `tb_lookup_employee_status` sts_ori ON sts_ori.`id_employee_status`=emp.`id_employee_status`
                WHERE p.`id_payroll`='" & id_payroll & "' AND " + where_staff + "
                ORDER BY emp.id_employee_status ASC, emp.employee_code ASC, p.`ot_start` ASC"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCOvertime.DataSource = data
        GVOvertime.BestFitColumns()
    End Sub
    Sub load_payroll_dp()
        Dim query As String = "SELECT ot_det.id_employee, employee.employee_code, employee.employee_name, dep.departement, employee.employee_position, employee_status.employee_status, DATE_FORMAT(ot.ot_date, '%d %M %Y') AS ot_date, DATE_FORMAT(ot_det.start_work, '%l:%i:%s %p') AS ot_start, DATE_FORMAT(ot_det.end_work, '%l:%i:%s %p') AS ot_end, ot_det.break_hours AS total_break, ot_det.overtime_hours, 0.0 AS total_hour, ot.ot_note AS note, IF((IFNULL(ot_det.is_day_off, (IF(((SELECT id_schedule_type FROM tb_emp_schedule WHERE id_employee = ot_det.id_employee AND DATE = ot.ot_date) = 1) AND (SELECT id_emp_holiday FROM tb_emp_holiday WHERE emp_holiday_date = ot.ot_date AND id_religion IN (0, IF(dep.is_store = 1, 0, employee.id_religion))) IS NULL, 2, 1)))) = 1, 'Yes', 'No') AS is_day_off, dep.is_store, ot_type.is_point_ho, IFNULL(ot_det.only_dp, IF(salary.salary > (SELECT (ump + 1000000) AS ump FROM tb_emp_payroll WHERE ump IS NOT NULL ORDER BY periode_end DESC LIMIT 1), 'yes', 'no')) AS only_dp
            FROM tb_ot_det AS ot_det
            LEFT JOIN tb_ot AS ot ON ot_det.id_ot = ot.id_ot
            LEFT JOIN tb_lookup_ot_type AS ot_type ON ot.id_ot_type = ot_type.id_ot_type
            LEFT JOIN tb_m_employee AS employee ON ot_det.id_employee = employee.id_employee
            LEFT JOIN tb_m_departement dep ON dep.`id_departement`=employee.`id_departement`
            LEFT JOIN tb_lookup_employee_status AS employee_status ON employee.id_employee_status = employee_status.id_employee_status
            LEFT JOIN (
                SELECT id_employee, (basic_salary + allow_job + allow_meal + allow_trans + allow_house + allow_car) AS salary
                FROM tb_m_employee
            ) AS salary ON ot_det.id_employee = salary.id_employee
            WHERE ot_det.conversion_type = 2 AND ot_det.is_valid = 1 AND ot.id_check_status = 6 AND ot.id_payroll = " + id_periode + "
            ORDER BY employee.id_employee_status ASC, employee.employee_code ASC, ot.ot_date ASC"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCDP.DataSource = data
        GVDP.BestFitColumns()
        calculatePoint()
    End Sub
    Private Sub BAdd_Click(sender As Object, e As EventArgs) Handles BAdd.Click
        load_add()
    End Sub

    Sub load_add()
        FormEmpPayrollOvertimeDet.id_overtime = "-1"
        FormEmpPayrollOvertimeDet.ShowDialog()
    End Sub

    Private Sub LEPayrollPeriode_EditValueChanged(sender As Object, e As EventArgs) Handles LEPayrollPeriode.EditValueChanged
        load_payroll_ot()
        load_payroll_dp()
    End Sub

    Private Sub BEdit_Click(sender As Object, e As EventArgs) Handles BEdit.Click
        FormEmpPayrollOvertimeDet.id_overtime = GVOvertime.GetFocusedRowCellValue("id_payroll_ot").ToString
        FormEmpPayrollOvertimeDet.ShowDialog()
    End Sub

    Private Sub FormEmpPayrollOvertime_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.Add Then
            load_add()
        End If
    End Sub

    Private Sub BDelete_Click(sender As Object, e As EventArgs) Handles BDelete.Click
        Dim confirm As DialogResult
        confirm = DevExpress.XtraEditors.XtraMessageBox.Show("Are you sure want to delete this ?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)

        If confirm = DialogResult.Yes Then
            Dim query As String = "DELETE FROM tb_emp_payroll_ot WHERE id_payroll_ot='" & GVOvertime.GetFocusedRowCellValue("id_payroll_ot").ToString & "'"
            execute_non_query(query, True, "", "", "", "")
            load_payroll_ot()
        End If
    End Sub

    Private Sub BOvertimeWindow_Click(sender As Object, e As EventArgs) Handles BOvertimeWindow.Click
        Dim editor As DevExpress.XtraEditors.LookUpEdit = CType(LEPayrollPeriode, DevExpress.XtraEditors.LookUpEdit)
        Dim row As DataRowView = CType(editor.Properties.GetDataSourceRowByKeyValue(editor.EditValue), DataRowView)

        FormEmpPayrollOvertimePick.date_start = Date.Parse(row("ot_periode_start").ToString).ToString("yyyy-MM-dd")
        FormEmpPayrollOvertimePick.date_end = Date.Parse(row("ot_periode_end").ToString).ToString("yyyy-MM-dd")
        FormEmpPayrollOvertimePick.ShowDialog()
    End Sub

    Private Sub BRefresh_Click(sender As Object, e As EventArgs) Handles BRefresh.Click
        load_payroll_ot()
        load_payroll_dp()
    End Sub

    Private Sub SBPrint_Click(sender As Object, e As EventArgs) Handles SBPrint.Click
        Dim id_payroll As String = FormEmpPayroll.GVPayrollPeriode.GetFocusedRowCellValue("id_payroll").ToString

        Dim id_report_status As String = execute_query("SELECT id_report_status FROM tb_emp_payroll WHERE id_payroll = " + FormEmpPayroll.GVPayrollPeriode.GetFocusedRowCellValue("id_payroll").ToString, 0, True, "", "", "", "")

        Dim report As ReportEmpPayrollOvertime = New ReportEmpPayrollOvertime

        report.id_payroll = id_payroll
        report.id_pre = If(id_report_status = "6", "-1", "1")
        report.XLPeriod.Text = Date.Parse(FormEmpPayroll.GVPayrollPeriode.GetFocusedRowCellValue("periode_end").ToString).ToString("MMMM yyyy")
        report.XLType.Text = FormEmpPayroll.GVPayrollPeriode.GetFocusedRowCellValue("payroll_type_name").ToString

        Dim tool As DevExpress.XtraReports.UI.ReportPrintTool = New DevExpress.XtraReports.UI.ReportPrintTool(report)
        tool.ShowPreview()
    End Sub

    Private Sub GVOvertime_CustomDrawRowFooter(sender As Object, e As DevExpress.XtraGrid.Views.Base.RowObjectCustomDrawEventArgs) Handles GVOvertime.CustomDrawRowFooter
        e.Graphics.FillRectangle(New SolidBrush(Color.White), e.Bounds)

        e.Handled = True

        Dim format As StringFormat = e.Appearance.GetStringFormat.Clone

        format.Alignment = StringAlignment.Near

        If GVOvertime.GetGroupRowDisplayText(e.RowHandle).Contains("Group") Then
            e.Graphics.DrawString("Grand Total: " + GVOvertime.GetGroupRowValue(e.RowHandle), e.Appearance.GetFont, e.Appearance.GetForeBrush(e.Cache), e.Bounds, format)
        Else
            If GVOvertime.GetGroupRowDisplayText(e.RowHandle).Contains("SOGO") Then
                e.Graphics.DrawString("Total " + GVOvertime.GetGroupRowDisplayText(e.RowHandle), e.Appearance.GetFont, e.Appearance.GetForeBrush(e.Cache), e.Bounds, format)
            Else
                If Not GVOvertime.GetGroupRowDisplayText(e.RowHandle).Contains("Sub") Then
                    e.Graphics.DrawString("Total " + GVOvertime.GetGroupRowDisplayText(e.RowHandle), e.Appearance.GetFont, e.Appearance.GetForeBrush(e.Cache), e.Bounds, format)
                End If
            End If
        End If

        e.Handled = True
    End Sub

    Private Sub GVOvertime_CustomDrawRowFooterCell(sender As Object, e As DevExpress.XtraGrid.Views.Grid.FooterCellCustomDrawEventArgs) Handles GVOvertime.CustomDrawRowFooterCell
        Dim view As DevExpress.XtraGrid.Views.Grid.GridView = sender

        If view.GetGroupRowDisplayText(e.RowHandle).Contains("Sub Departement") And Not view.GetGroupRowValue(e.RowHandle).ToString.Contains("SOGO") Then
            e.Appearance.ForeColor = Color.White
            e.Handled = True
        End If
    End Sub

    Private Sub GVOvertime_CustomDrawGroupRow(sender As Object, e As DevExpress.XtraGrid.Views.Base.RowObjectCustomDrawEventArgs) Handles GVOvertime.CustomDrawGroupRow
        Dim info As DevExpress.XtraGrid.Views.Grid.ViewInfo.GridGroupRowInfo = TryCast(e.Info, DevExpress.XtraGrid.Views.Grid.ViewInfo.GridGroupRowInfo)

        If info.Column.Caption = "Sub Departement" And Not info.EditValue.ToString.Contains("SOGO") Then
            info.GroupText = " "
        End If
    End Sub

    Private Sub GVOvertime_RowCellClick(sender As Object, e As DevExpress.XtraGrid.Views.Grid.RowCellClickEventArgs) Handles GVOvertime.RowCellClick
        If id_report_status = "0" And GVOvertime.GetFocusedRowCellValue("id_ot_type").ToString = "1" Then
            If e.Button = MouseButtons.Right And e.Column.FieldName = "wages_per_point" Then
                PMSalary.ClearLinks()

                Dim query As String = "
                SELECT IF(sal_det.id_employee_status = 3, ((sal_det.basic_salary + sal_det.allow_job + sal_det.allow_meal + sal_det.allow_trans + sal_det.allow_house + sal_det.allow_car) * dep.total_workdays), (sal_det.basic_salary + sal_det.allow_job + sal_det.allow_meal + sal_det.allow_trans)) AS salary, DATE_FORMAT(sal.effective_date, '%d %M %Y') AS effective_date
                FROM tb_employee_sal_pps_det AS sal_det
                LEFT JOIN tb_employee_sal_pps AS sal ON sal_det.id_employee_sal_pps = sal.id_employee_sal_pps
                LEFT JOIN tb_m_departement AS dep ON sal_det.id_departement = dep.id_departement
                WHERE sal.id_report_status = 6 AND sal_det.id_employee = " + GVOvertime.GetFocusedRowCellValue("id_employee").ToString + "
                ORDER BY sal.id_employee_sal_pps DESC
            "

                Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")

                For i = 0 To data.Rows.Count - 1
                    Dim item As DevExpress.XtraBars.BarButtonItem = New DevExpress.XtraBars.BarButtonItem

                    item.Caption = Format(data.Rows(i)("salary"), "##,##0") + " (" + data.Rows(i)("effective_date").ToString + " *Fixed Salary)"

                    AddHandler item.ItemClick, AddressOf itemClick

                    PMSalary.AddItem(item)
                Next

                PMSalary.ShowPopup(Control.MousePosition)
            End If
        End If
    End Sub

    Sub itemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs)
        Dim salary As Decimal = Decimal.Parse(System.Text.RegularExpressions.Regex.Replace(e.Item.Caption.ToString, "\((.*)\)", "").ToString().Replace(".", "").Replace(" ", ""))

        execute_non_query("UPDATE tb_emp_payroll_ot SET increase = '" + decimalSQL(salary) + "' WHERE id_payroll_ot = " + GVOvertime.GetFocusedRowCellValue("id_payroll_ot").ToString, True, "", "", "", "")

        load_payroll_ot()
    End Sub

    Sub calculatePoint()
        For i = 0 To GVDP.RowCount - 1
            If GVDP.IsValidRowHandle(i) Then
                Dim overtime_hours As String = GVDP.GetRowCellValue(i, "overtime_hours").ToString

                If Not overtime_hours = "" Then
                    Dim is_day_off As String = If(GVDP.GetRowCellValue(i, "is_day_off").ToString = "Yes", "1", "2")
                    Dim is_store As String = GVDP.GetRowCellValue(i, "is_store").ToString

                    If GVDP.GetRowCellValue(i, "is_point_ho").ToString = "1" Then
                        is_store = "2"
                    End If

                    GVDP.SetRowCellValue(i, "total_hour", FormEmpOvertimeVerification.calc_point(Decimal.Parse(overtime_hours), is_day_off, is_store))
                Else
                    GVDP.SetRowCellValue(i, "total_hour", "")
                End If

                Dim only_dp As String = GVDP.GetRowCellValue(i, "only_dp").ToString

                If only_dp = "yes" Then
                    GVDP.SetRowCellValue(i, "total_hour", overtime_hours)
                End If
            End If
        Next
    End Sub
End Class