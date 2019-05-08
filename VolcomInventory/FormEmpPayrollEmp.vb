﻿Public Class FormEmpPayrollEmp
    Dim id_payroll As String = "-1"
    Dim id_payroll_type As String = "-1"

    Private Sub FormEmpPayrollEmp_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        id_payroll = FormEmpPayroll.GVPayrollPeriode.GetFocusedRowCellValue("id_payroll").ToString
        id_payroll_type = FormEmpPayroll.GVPayrollPeriode.GetFocusedRowCellValue("id_payroll_type").ToString
        If id_payroll_type = "1" Then
            BPickAll.Text = "Insert All Active Employee"
            id_payroll = FormEmpPayroll.GVPayrollPeriode.GetFocusedRowCellValue("id_payroll").ToString()
            load_emp()
        Else
            BPickAll.Text = "Insert All Eligible Employee"
            id_payroll = FormEmpPayroll.GVPayrollPeriode.GetFocusedRowCellValue("id_payroll").ToString()
            load_emp()
        End If
    End Sub
    Sub load_emp()
        Dim query As String = ""

        Dim query_period_start As String = "SELECT periode_start FROM tb_emp_payroll WHERE id_payroll = '" + id_payroll + "'"
        Dim query_period_end As String = "SELECT periode_end FROM tb_emp_payroll WHERE id_payroll = '" + id_payroll + "'"

        If id_payroll_type = "1" Then
            query = "SELECT 'no' AS is_check, emp.id_employee, IF(emp.employee_join_date > (" + query_period_start + "), (SELECT COUNT(*) FROM tb_emp_schedule WHERE id_schedule_type IN (1, 3) AND id_employee = emp.id_employee AND date BETWEEN (" + query_period_start + ") AND (" + query_period_end + ")), IF(emp.employee_last_date < (" + query_period_end + "), (SELECT COUNT(*) FROM tb_emp_schedule WHERE id_schedule_type IN (1, 3) AND id_employee = emp.id_employee AND date BETWEEN (" + query_period_start + ") AND emp.employee_last_date), dep.total_workdays)) AS actual_workdays, dep.total_workdays, dep.is_store, emp.employee_code, emp.employee_name, dep.departement, emp.employee_join_date, emp.employee_position, active.employee_active, salx.*
            FROM tb_m_employee emp
            INNER JOIN tb_m_departement dep ON dep.id_departement = emp.id_departement
            INNER JOIN tb_lookup_employee_level lvl ON lvl.id_employee_level = emp.id_employee_level 
            INNER JOIN tb_lookup_employee_active active ON active.id_employee_active = emp.id_employee_active
            INNER JOIN (	
                SELECT sal.* FROM (
                    SELECT * FROM tb_m_employee_salary sal
                    WHERE is_cancel = '2'
                    ORDER BY sal.`id_employee_salary` DESC
                ) sal GROUP BY id_employee
            ) salx ON salx.id_employee = emp.`id_employee`
            WHERE emp.id_employee NOT IN (SELECT id_employee FROM tb_emp_payroll_det WHERE id_payroll = '" & id_payroll & "')"
        ElseIf id_payroll_type = "2" Then 'thr
            query = "SELECT 'no' AS is_check, emp.id_employee, IF(emp.employee_join_date > (" + query_period_start + "), (SELECT COUNT(*) FROM tb_emp_schedule WHERE id_schedule_type IN (1, 3) AND id_employee = emp.id_employee AND date BETWEEN (" + query_period_start + ") AND (" + query_period_end + ")), IF(emp.employee_last_date < (" + query_period_end + "), (SELECT COUNT(*) FROM tb_emp_schedule WHERE id_schedule_type IN (1, 3) AND id_employee = emp.id_employee AND date BETWEEN (" + query_period_start + ") AND emp.employee_last_date), dep.total_workdays)) AS actual_workdays, dep.total_workdays, dep.is_store, emp.employee_code, emp.employee_name, dep.departement, emp.employee_join_date, emp.employee_position, active.employee_active, salx.*, TIMESTAMPDIFF(MONTH, emp.`employee_join_date`, DATE(NOW())) AS month_diff
            FROM tb_m_employee emp
            INNER JOIN tb_m_departement dep ON dep.id_departement = emp.id_departement
            INNER JOIN tb_lookup_employee_level lvl ON lvl.id_employee_level = emp.id_employee_level 
            INNER JOIN tb_lookup_employee_active active ON active.id_employee_active = emp.id_employee_active
            INNER JOIN (	
                SELECT sal.* FROM (
                    SELECT * FROM tb_m_employee_salary sal
                    WHERE is_cancel = '2'
                    ORDER BY sal.`id_employee_salary` DESC
                ) sal GROUP BY id_employee
            ) salx ON salx.id_employee = emp.`id_employee`
            WHERE 
            emp.id_employee NOT IN (SELECT id_employee FROM tb_emp_payroll_det WHERE id_payroll = '" & id_payroll & "')
            AND emp.`id_employee_active` = '1'
            AND TIMESTAMPDIFF(MONTH, emp.`employee_join_date`, DATE(NOW())) >= (SELECT min_month_bonus FROM tb_opt_emp LIMIT 1)"
        ElseIf id_payroll_type = "3" Then 'bonus
            query = "SELECT 'no' AS is_check, emp.id_employee, IF(emp.employee_join_date > (" + query_period_start + "), (SELECT COUNT(*) FROM tb_emp_schedule WHERE id_schedule_type IN (1, 3) AND id_employee = emp.id_employee AND date BETWEEN (" + query_period_start + ") AND (" + query_period_end + ")), IF(emp.employee_last_date < (" + query_period_end + "), (SELECT COUNT(*) FROM tb_emp_schedule WHERE id_schedule_type IN (1, 3) AND id_employee = emp.id_employee AND date BETWEEN (" + query_period_start + ") AND emp.employee_last_date), dep.total_workdays)) AS actual_workdays, dep.is_store, emp.employee_code, emp.employee_name, dep.departement, emp.employee_join_date, emp.employee_position, active.employee_active, salx.*, TIMESTAMPDIFF(MONTH, emp.`employee_join_date`, DATE(NOW())) AS month_diff
            FROM tb_m_employee emp
            INNER JOIN tb_m_departement dep ON dep.id_departement = emp.id_departement
            INNER JOIN tb_lookup_employee_level lvl ON lvl.id_employee_level = emp.id_employee_level 
            INNER JOIN tb_lookup_employee_active active ON active.id_employee_active = emp.id_employee_active
            INNER JOIN (	
                SELECT sal.* FROM (
                    SELECT * FROM tb_m_employee_salary sal
                    WHERE is_cancel = '2'
                    ORDER BY sal.`id_employee_salary` DESC
                ) sal GROUP BY id_employee
            ) salx ON salx.id_employee = emp.`id_employee`
            WHERE 
            emp.id_employee NOT IN (SELECT id_employee FROM tb_emp_payroll_det WHERE id_payroll = '" & id_payroll & "')
            AND emp.`id_employee_active` = '1'
            AND TIMESTAMPDIFF(MONTH, emp.`employee_join_date`, DATE(NOW())) >= (SELECT min_month_bonus FROM tb_opt_emp LIMIT 1)"
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

    Private Sub GVEmployee_DoubleClick(sender As Object, e As EventArgs) Handles GVEmployee.DoubleClick
        If GVEmployee.RowCount > 0 Then
            pick()
        End If
    End Sub

    Private Sub FormPopUpEmployee_Shown(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Shown
        GVEmployee.ShowFindPanel()
        GVEmployee.ShowFindPanel()
    End Sub

    Sub pick()
        Dim query As String = ""

        Cursor = Cursors.WaitCursor
        GVEmployee.ActiveFilterString = ""
        GVEmployee.ActiveFilterString = "[is_check]='yes'"
        If GVEmployee.RowCount = 0 Then
            stopCustom("Please select order first.")
            GVEmployee.ActiveFilterString = ""
        Else
            query = "INSERT INTO tb_emp_payroll_det(id_payroll,id_employee,id_salary,workdays,actual_workdays) VALUES"
            For i As Integer = 0 To ((GVEmployee.RowCount - 1) - GetGroupRowCount(GVEmployee))
                Dim id_employee As String = GVEmployee.GetRowCellValue(i, "id_employee").ToString
                Dim id_salary As String = GVEmployee.GetRowCellValue(i, "id_employee_salary").ToString
                Dim workdays As String = decimalSQL(GVEmployee.GetRowCellValue(i, "total_workdays").ToString)
                Dim actual_workdays As String = decimalSQL(GVEmployee.GetRowCellValue(i, "actual_workdays").ToString)
                If Not i = 0 Then
                    query += ","
                End If
                query += "('" & id_payroll & "','" & id_employee & "','" & id_salary & "','" & workdays & "','" & actual_workdays & "')"
            Next
            execute_non_query(query, True, "", "", "", "")
        End If
        GVEmployee.ActiveFilterString = ""
        Cursor = Cursors.Default
        FormEmpPayroll.load_payroll_detail()
        infoCustom("Employee listed.")
        Close()
    End Sub

    Private Sub BPickAll_Click(sender As Object, e As EventArgs) Handles BPickAll.Click
        Dim query As String = ""

        Dim query_period_start As String = "SELECT periode_start FROM tb_emp_payroll WHERE id_payroll = '" + id_payroll + "'"
        Dim query_period_end As String = "SELECT periode_end FROM tb_emp_payroll WHERE id_payroll = '" + id_payroll + "'"

        If id_payroll_type = "1" Then
            query = "INSERT INTO tb_emp_payroll_det(id_payroll,id_employee,id_salary,workdays,actual_workdays)
                                SELECT '" & id_payroll & "' as id_payroll,emp.id_employee,salx.id_employee_salary,dep.total_workdays,IF(emp.employee_join_date > (" + query_period_start + "), (SELECT COUNT(*) FROM tb_emp_schedule WHERE id_schedule_type IN (1, 3) AND id_employee = emp.id_employee AND date BETWEEN (" + query_period_start + ") AND (" + query_period_end + ")), IF(emp.employee_last_date < (" + query_period_end + "), (SELECT COUNT(*) FROM tb_emp_schedule WHERE id_schedule_type IN (1, 3) AND id_employee = emp.id_employee AND date BETWEEN (" + query_period_start + ") AND emp.employee_last_date), dep.total_workdays)) AS actual_workdays
                                FROM tb_m_employee emp
                                INNER JOIN tb_m_departement dep ON dep.id_departement=emp.id_departement
                                INNER JOIN tb_lookup_employee_level lvl ON lvl.id_employee_level=emp.id_employee_level 
                                INNER JOIN tb_lookup_employee_active active ON active.id_employee_active=emp.id_employee_active
                                INNER JOIN (	
	                                SELECT sal.* FROM (
		                                SELECT * FROM tb_m_employee_salary sal
		                                WHERE is_cancel='2'
		                                ORDER BY sal.`effective_date` DESC,sal.`id_employee_salary` DESC
	                                ) sal GROUP BY id_employee
                                ) salx ON salx.id_employee = emp.`id_employee`
                                WHERE emp.id_employee_active='1' AND emp.id_employee NOT IN (SELECT id_employee FROM tb_emp_payroll_det WHERE id_payroll='" & id_payroll & "')"
        ElseIf id_payroll_type = "2" Then 'thr
            query = "INSERT INTO tb_emp_payroll_det(id_payroll,id_employee,id_salary,workdays,actual_workdays)
                        SELECT '" & id_payroll & "' AS id_payroll,emp.id_employee,salx.id_employee_salary,dep.total_workdays,IF(emp.employee_join_date > (" + query_period_start + "), (SELECT COUNT(*) FROM tb_emp_schedule WHERE id_schedule_type IN (1, 3) AND id_employee = emp.id_employee AND date BETWEEN (" + query_period_start + ") AND (" + query_period_end + ")), IF(emp.employee_last_date < (" + query_period_end + "), (SELECT COUNT(*) FROM tb_emp_schedule WHERE id_schedule_type IN (1, 3) AND id_employee = emp.id_employee AND date BETWEEN (" + query_period_start + ") AND emp.employee_last_date), dep.total_workdays)) AS actual_workdays
                        FROM tb_m_employee emp
                        INNER JOIN tb_m_departement dep ON dep.id_departement=emp.id_departement
                        INNER JOIN tb_lookup_employee_level lvl ON lvl.id_employee_level=emp.id_employee_level 
                        INNER JOIN tb_lookup_employee_active active ON active.id_employee_active=emp.id_employee_active
                        INNER JOIN (	
	                        SELECT sal.* FROM (
		                        SELECT * FROM tb_m_employee_salary sal
		                        WHERE is_cancel='2'
		                        ORDER BY sal.`effective_date` DESC,sal.`id_employee_salary` DESC
	                        ) sal GROUP BY id_employee
                        ) salx ON salx.id_employee = emp.`id_employee`
                        WHERE emp.id_employee_active='1' AND emp.id_employee NOT IN (SELECT id_employee FROM tb_emp_payroll_det WHERE id_payroll='" & id_payroll & "')
                        AND TIMESTAMPDIFF(MONTH, emp.`employee_join_date`, DATE(NOW())) >= (SELECT min_month_thr FROM tb_opt_emp LIMIT 1)"
        ElseIf id_payroll_type = "3" Then 'bonus
            query = "INSERT INTO tb_emp_payroll_det(id_payroll,id_employee,id_salary,workdays,actual_workdays)
                        SELECT '" & id_payroll & "' AS id_payroll,emp.id_employee,salx.id_employee_salary,dep.total_workdays,IF(emp.employee_join_date > (" + query_period_start + "), (SELECT COUNT(*) FROM tb_emp_schedule WHERE id_schedule_type IN (1, 3) AND id_employee = emp.id_employee AND date BETWEEN (" + query_period_start + ") AND (" + query_period_end + ")), IF(emp.employee_last_date < (" + query_period_end + "), (SELECT COUNT(*) FROM tb_emp_schedule WHERE id_schedule_type IN (1, 3) AND id_employee = emp.id_employee AND date BETWEEN (" + query_period_start + ") AND emp.employee_last_date), dep.total_workdays)) AS actual_workdays
                        FROM tb_m_employee emp
                        INNER JOIN tb_m_departement dep ON dep.id_departement=emp.id_departement
                        INNER JOIN tb_lookup_employee_level lvl ON lvl.id_employee_level=emp.id_employee_level 
                        INNER JOIN tb_lookup_employee_active active ON active.id_employee_active=emp.id_employee_active
                        INNER JOIN (	
	                        SELECT sal.* FROM (
		                        SELECT * FROM tb_m_employee_salary sal
		                        WHERE is_cancel='2'
		                        ORDER BY sal.`effective_date` DESC,sal.`id_employee_salary` DESC
	                        ) sal GROUP BY id_employee
                        ) salx ON salx.id_employee = emp.`id_employee`
                        WHERE emp.id_employee_active='1' AND emp.id_employee NOT IN (SELECT id_employee FROM tb_emp_payroll_det WHERE id_payroll='" & id_payroll & "')
                        AND TIMESTAMPDIFF(MONTH, emp.`employee_join_date`, DATE(NOW())) >= (SELECT min_month_bonus FROM tb_opt_emp LIMIT 1)"
        End If

        execute_non_query(query, True, "", "", "", "")
        infoCustom("Employee listed.")
        FormEmpPayroll.load_payroll_detail()
        Close()
    End Sub
End Class