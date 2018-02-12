Public Class FormPopUpEmployee
    Public id_popup As String = "-1"
    Private Sub FormPopUpEmployee_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        load_emp()
    End Sub
    Sub load_emp()
        Dim query As String = ""
        If id_popup = "7" Then
            Dim id_payroll As String = FormEmpPayroll.GVPayrollPeriode.GetFocusedRowCellValue("id_payroll").ToString
            query = "SELECT emp.id_employee,dep.is_store,emp.employee_code,emp.employee_name,dep.departement,emp.employee_join_date,emp.employee_position,active.employee_active
                    ,IFNULL((salx.basic_salary+salx.allow_job+salx.allow_meal+salx.allow_trans+salx.allow_house+salx.allow_car),0) AS thp_total
                    ,pyd.workdays
                    From tb_m_employee emp
                    INNER Join tb_m_departement dep ON dep.id_departement=emp.id_departement
                    INNER Join tb_lookup_employee_level lvl On lvl.id_employee_level=emp.id_employee_level 
                    INNER Join tb_lookup_employee_active active On active.id_employee_active=emp.id_employee_active
                    INNER JOIN tb_emp_payroll_det pyd ON pyd.`id_employee`=emp.`id_employee` AND pyd.`id_payroll`='" & id_payroll & "'
                    INNER JOIN `tb_m_employee_salary` salx ON salx.`id_employee_salary`=pyd.`id_salary`"
        Else
            query = "Select emp.id_employee,dep.is_store,emp.employee_code,emp.employee_name,dep.departement,emp.employee_join_date,emp.employee_position,active.employee_active
                    ,IFNULL((salx.basic_salary+salx.allow_job+salx.allow_meal+salx.allow_trans+salx.allow_house+salx.allow_car),0) AS thp_total
                    From tb_m_employee emp
                    INNER Join tb_m_departement dep ON dep.id_departement=emp.id_departement
                    INNER Join tb_lookup_employee_level lvl On lvl.id_employee_level=emp.id_employee_level 
                    INNER Join tb_lookup_employee_active active On active.id_employee_active=emp.id_employee_active
                    LEFT JOIN (	
	                    SELECT sal.* FROM (
		                    SELECT * FROM tb_m_employee_salary sal
		                    WHERE is_cancel='2'
		                    ORDER BY sal.`effective_date` DESC,sal.`id_employee_salary` DESC
	                    ) sal GROUP BY id_employee
                    ) salx ON salx.id_employee = emp.`id_employee`"
        End If

        If FormEmpLeave.is_propose = "1" Then
            'Dim id_user_admin_management As String = get_opt_emp_field("id_user_admin_mng").ToString
            'If id_user_admin_management = id_user Then
            '    Dim id_min_lvl As String = get_opt_emp_field("leave_asst_mgr_level").ToString
            '    query += " And lvl.id_employee_level>0 And lvl.id_employee_level <'" & id_min_lvl & "' "
        'Else
        '    query += " AND (dep.id_user_admin='" & id_user & "' OR dep.id_user_admin_backup='" & id_user & "')"
        'End If
        End If
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCEmployee.DataSource = data
        GVEmployee.BestFitColumns()
        '
        GVEmployee.BestFitColumns()
    End Sub

    Private Sub FormPopUpEmployee_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub BCancel_Click(sender As Object, e As EventArgs) Handles BCancel.Click
        Close()
    End Sub

    Private Sub BPick_Click(sender As Object, e As EventArgs) Handles BPick.Click
        pick()
    End Sub

    Sub pick()
        If id_popup = "1" Then
            FormEmpLeaveDet.id_employee = GVEmployee.GetFocusedRowCellValue("id_employee").ToString
            FormEmpLeaveDet.TEEmployeeCode.Text = GVEmployee.GetFocusedRowCellValue("employee_code").ToString
            FormEmpLeaveDet.TEEmployeeName.Text = GVEmployee.GetFocusedRowCellValue("employee_name").ToString
            FormEmpLeaveDet.TEDept.Text = GVEmployee.GetFocusedRowCellValue("departement").ToString
            FormEmpLeaveDet.TEPosition.Text = GVEmployee.GetFocusedRowCellValue("employee_position").ToString
            FormEmpLeaveDet.DEJoinDate.EditValue = GVEmployee.GetFocusedRowCellValue("employee_join_date")
            FormEmpLeaveDet.load_emp_detail()
            Close()
        ElseIf id_popup = "2" Then
            FormEmpLeaveDet.id_employee_change = GVEmployee.GetFocusedRowCellValue("id_employee").ToString
            FormEmpLeaveDet.TEEMployeeChange.Text = GVEmployee.GetFocusedRowCellValue("employee_code").ToString
            FormEmpLeaveDet.TEEmployeeChangeName.Text = GVEmployee.GetFocusedRowCellValue("employee_name").ToString
            Close()
        ElseIf id_popup = "3" Then
            FormEmpDPDet.id_employee = GVEmployee.GetFocusedRowCellValue("id_employee").ToString
            FormEmpDPDet.TEEmployeeCode.Text = GVEmployee.GetFocusedRowCellValue("employee_code").ToString
            FormEmpDPDet.TEEmployeeName.Text = GVEmployee.GetFocusedRowCellValue("employee_name").ToString
            FormEmpDPDet.TEDept.Text = GVEmployee.GetFocusedRowCellValue("departement").ToString
            FormEmpDPDet.TEPosition.Text = GVEmployee.GetFocusedRowCellValue("employee_position").ToString
            FormEmpDPDet.MEDPNote.Focus()
            Close()
        ElseIf id_popup = "4" Then
            FormEmpChScheduleDet.id_employee = GVEmployee.GetFocusedRowCellValue("id_employee").ToString
            FormEmpChScheduleDet.TEEmployeeCode.Text = GVEmployee.GetFocusedRowCellValue("employee_code").ToString
            FormEmpChScheduleDet.TEEmployeeName.Text = GVEmployee.GetFocusedRowCellValue("employee_name").ToString
            FormEmpChScheduleDet.TEDept.Text = GVEmployee.GetFocusedRowCellValue("departement").ToString
            FormEmpChScheduleDet.TEPosition.Text = GVEmployee.GetFocusedRowCellValue("employee_position").ToString
            FormEmpChScheduleDet.MEChNote.Focus()
            Close()
        ElseIf id_popup = "5" Then
            FormEmpPayrollOvertimeDet.id_employee = GVEmployee.GetFocusedRowCellValue("id_employee").ToString
            FormEmpPayrollOvertimeDet.TEEmployeeCode.Text = GVEmployee.GetFocusedRowCellValue("employee_code").ToString
            FormEmpPayrollOvertimeDet.TEEmployeeName.Text = GVEmployee.GetFocusedRowCellValue("employee_name").ToString
            FormEmpPayrollOvertimeDet.is_store_employee = GVEmployee.GetFocusedRowCellValue("is_store").ToString
            FormEmpPayrollOvertimeDet.LEDayoff.Focus()
            Close()
        ElseIf id_popup = "6" Then
            FormEmpPayrollDeductionDet.id_employee = GVEmployee.GetFocusedRowCellValue("id_employee").ToString
            FormEmpPayrollDeductionDet.TEEmployeeCode.Text = GVEmployee.GetFocusedRowCellValue("employee_code").ToString
            FormEmpPayrollDeductionDet.TEEmployeeName.Text = GVEmployee.GetFocusedRowCellValue("employee_name").ToString
            FormEmpPayrollDeductionDet.LEDeductionType.Focus()
            Close()
        ElseIf id_popup = "7" Then
            FormEmpPayrollAdjustmentDet.id_employee = GVEmployee.GetFocusedRowCellValue("id_employee").ToString
            FormEmpPayrollAdjustmentDet.TEEmployeeCode.Text = GVEmployee.GetFocusedRowCellValue("employee_code").ToString
            FormEmpPayrollAdjustmentDet.TEEmployeeName.Text = GVEmployee.GetFocusedRowCellValue("employee_name").ToString
            FormEmpPayrollAdjustmentDet.TETHP.EditValue = GVEmployee.GetFocusedRowCellValue("thp_total")
            FormEmpPayrollAdjustmentDet.TETotalWorkdays.EditValue = GVEmployee.GetFocusedRowCellValue("workdays")
            FormEmpPayrollAdjustmentDet.TEDepartement.Text = GVEmployee.GetFocusedRowCellValue("departement").ToString
            FormEmpPayrollAdjustmentDet.calculate()
            FormEmpPayrollAdjustmentDet.LEType.Focus()
            Close()
        End If
    End Sub

    Private Sub GVEmployee_DoubleClick(sender As Object, e As EventArgs) Handles GVEmployee.DoubleClick
        If GVEmployee.RowCount > 0 Then
            pick()
        End If
    End Sub
    Private Sub FormPopUpEmployee_Shown(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Shown
        GVEmployee.ShowFindPanel()
        GVEmployee.ShowFindPanel()
    End Sub
End Class