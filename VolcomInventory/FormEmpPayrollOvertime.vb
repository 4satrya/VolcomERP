Public Class FormEmpPayrollOvertime
    Public id_periode As String = "-1"
    Private Sub FormEmpPayrollOvertime_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        FormEmpPayroll.load_payroll_detail()
        Dispose()
    End Sub

    Private Sub FormEmpPayrollOvertime_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        load_payroll_periode()
        load_payroll_ot()
        load_payroll_dp()
    End Sub

    Sub load_payroll_periode()
        Dim query As String = "SELECT p.id_payroll,p.ot_periode_start,p.ot_periode_end,DATE_FORMAT(`ot_periode_end`,'%M %Y') as periode FROM tb_emp_payroll p"
        viewLookupQuery(LEPayrollPeriode, query, 0, "periode", "id_payroll")
        If Not id_periode = "-1" Then
            LEPayrollPeriode.ItemIndex = LEPayrollPeriode.Properties.GetDataSourceRowIndex("id_payroll", id_periode)
        End If
    End Sub

    Sub load_payroll_ot()
        Dim query As String = "SELECT p.id_payroll_ot,p.`id_payroll`,p.`id_employee`,p.`id_ot_type`,DATE_FORMAT(p.`ot_start`, '%d %M %Y') AS ot_date, DATE_FORMAT(p.`ot_start`, '%l:%i:%s %p') AS ot_start, DATE_FORMAT(p.`ot_end`, '%l:%i:%s %p') AS ot_end,p.`total_break`,p.`total_hour`,p.`total_point`,IF(p.`is_day_off`=1,'Yes','No') AS day_off,emp.employee_position,lvl.`employee_level`,emp.`employee_name`,emp.`employee_code`,CONCAT(IF(ott.`is_event` = 1, 'Event ', ''), ott.`ot_type`) AS ot_type, IF(ott.`is_event` = 1, p.wages_per_point, ((SELECT (sal.`basic_salary` + sal.`allow_job` + sal.`allow_meal` + sal.`allow_trans`) FROM tb_emp_payroll_det AS pd INNER JOIN tb_m_employee_salary AS sal ON pd.id_salary = sal.id_employee_salary WHERE pd.id_employee = p.`id_employee`) * pay.ot_reg_pembilang / pay.ot_reg_penyebut)) AS wages_per_point, IF(ott.`is_event` = 1, p.`total_point` * p.wages_per_point, p.`total_point` * ((SELECT (sal.`basic_salary` + sal.`allow_job` + sal.`allow_meal` + sal.`allow_trans`) FROM tb_emp_payroll_det AS pd INNER JOIN tb_m_employee_salary AS sal ON pd.id_salary = sal.id_employee_salary WHERE pd.id_employee = p.`id_employee`) * pay.ot_reg_pembilang / pay.ot_reg_penyebut)) AS wages_per_point_total, p.note
                                FROM tb_emp_payroll_ot p
                                INNER JOIN `tb_lookup_ot_type` ott ON ott.`id_ot_type`=p.`id_ot_type`
                                INNER JOIN tb_m_employee emp ON emp.`id_employee`=p.`id_employee`
                                INNER JOIN tb_emp_payroll pay ON p.`id_payroll`=pay.`id_payroll`
                                INNER JOIN `tb_lookup_employee_level` lvl ON lvl.`id_employee_level`=emp.`id_employee_level`
                                WHERE p.`id_payroll`='" & LEPayrollPeriode.EditValue.ToString & "'
                                ORDER BY p.`id_employee` ASC, p.`ot_start` ASC"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCOverTime.DataSource = data
        GVOverTime.BestFitColumns()
    End Sub
    Sub load_payroll_dp()
        Dim query As String = "SELECT ot_det.id_employee, employee.employee_code, employee.employee_name, employee.employee_position, employee_level.employee_level, DATE_FORMAT(ot.ot_date, '%d %M %Y') AS ot_date, DATE_FORMAT(ot_det.start_work, '%l:%i:%s %p') AS ot_start, DATE_FORMAT(ot_det.end_work, '%l:%i:%s %p') AS ot_end, ot_det.break_hours AS total_break, (TIMESTAMPDIFF(HOUR, ot_det.start_work, ot_det.end_work) - ot_det.break_hours) AS total_hour, ot.ot_note AS note
                                FROM tb_ot_det AS ot_det
                                LEFT JOIN tb_ot AS ot ON ot_det.id_ot = ot.id_ot
                                LEFT JOIN tb_m_employee AS employee ON ot_det.id_employee = employee.id_employee
                                LEFT JOIN tb_lookup_employee_level AS employee_level ON ot_det.id_employee_level = employee_level.id_employee_level
                                WHERE ot_det.conversion_type = 2 AND ot_det.is_valid = 1 AND ot.id_check_status = 6 AND ot.id_payroll = '" + LEPayrollPeriode.EditValue.ToString + "'
                                ORDER BY ot_det.id_employee ASC, ot.ot_date ASC"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCDP.DataSource = data
        GVDP.BestFitColumns()
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
        FormEmpPayrollOvertimeDet.id_overtime = GVOverTime.GetFocusedRowCellValue("id_payroll_ot").ToString
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
            Dim query As String = "DELETE FROM tb_emp_payroll_ot WHERE id_payroll_ot='" & GVOverTime.GetFocusedRowCellValue("id_payroll_ot").ToString & "'"
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
End Class