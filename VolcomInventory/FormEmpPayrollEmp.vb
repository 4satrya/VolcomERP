Public Class FormEmpPayrollEmp
    Dim id_payroll As String = "-1"
    Dim id_payroll_type As String = "-1"

    Private Sub FormEmpPayrollEmp_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        id_payroll = FormEmpPayroll.GVPayrollPeriode.GetFocusedRowCellValue("id_payroll").ToString
        id_payroll_type = FormEmpPayroll.GVPayrollPeriode.GetFocusedRowCellValue("id_payroll_type").ToString

        load_emp()
    End Sub
    Sub load_emp()
        Dim query As String = ""

        Dim query_period_start As String = "SELECT periode_start FROM tb_emp_payroll WHERE id_payroll = '" + id_payroll + "'"
        Dim query_period_end As String = "SELECT periode_end FROM tb_emp_payroll WHERE id_payroll = '" + id_payroll + "'"

        Dim payroll_type As DataTable = execute_query("SELECT is_thr, is_dw FROM tb_emp_payroll_type WHERE id_payroll_type = " + id_payroll_type, -1, True, "", "", "", "")

        Dim where_dw As String = ""

        If payroll_type.Rows(0)("is_dw").ToString = "1" Then
            where_dw = "AND emp.id_employee_status = 3"
        Else
            where_dw = "AND emp.id_employee_status != 3"
        End If

        If payroll_type.Rows(0)("is_thr").ToString = "2" Then
            If id_payroll_type = "1" Then
                query = "
                    SELECT emp.id_employee, salx.id_employee_salary, dep.total_workdays, IF(emp.employee_join_date > (" + query_period_start + "), (SELECT COUNT(*) FROM tb_emp_schedule WHERE id_schedule_type IN (1, 3) AND id_employee = emp.id_employee AND date BETWEEN (" + query_period_start + ") AND (" + query_period_end + ")), IF(emp.employee_last_date < (" + query_period_end + "), (SELECT COUNT(*) FROM tb_emp_schedule WHERE id_schedule_type IN (1, 3) AND id_employee = emp.id_employee AND date BETWEEN (" + query_period_start + ") AND emp.employee_last_date), dep.total_workdays)) AS actual_workdays, emp.employee_code, emp.employee_name, emp.id_departement, dep.departement, emp.employee_position, emp.id_employee_level, lvl.employee_level, emp.id_employee_status, sts.employee_status, emp.id_employee_active, active.employee_active, DATE_FORMAT(emp.employee_actual_join_date, '%d %M %Y') AS employee_actual_join_date, DATE_FORMAT(emp.employee_last_date, '%d %M %Y') AS employee_last_date, rlg.religion
                    FROM tb_m_employee AS emp
                    INNER JOIN tb_m_departement AS dep ON dep.id_departement = emp.id_departement
                    INNER JOIN tb_lookup_employee_level AS lvl ON lvl.id_employee_level = emp.id_employee_level 
                    INNER JOIN tb_lookup_employee_status AS sts ON sts.id_employee_status = emp.id_employee_status 
                    INNER JOIN tb_lookup_employee_active AS active ON active.id_employee_active = emp.id_employee_active
                    INNER JOIN (	
                        SELECT MAX(id_employee_salary) AS id_employee_salary, id_employee 
                        FROM tb_m_employee_salary WHERE effective_date <= (" + query_period_end + ")
                        GROUP BY id_employee
                    ) salx ON salx.id_employee = emp.id_employee
                    LEFT JOIN tb_lookup_religion rlg ON rlg.id_religion = emp.id_religion
                    WHERE emp.id_employee NOT IN (SELECT id_employee FROM tb_emp_payroll_det WHERE id_payroll = '" & id_payroll & "') " + where_dw + "
                "
            ElseIf id_payroll_type = "4" Then 'dw
                query = "
                    SELECT emp.id_employee, salx.id_employee_salary, dep.total_workdays, IF(emp.employee_join_date > (" + query_period_start + "), (SELECT COUNT(*) FROM tb_emp_schedule WHERE id_schedule_type IN (1, 3) AND id_employee = emp.id_employee AND date BETWEEN (" + query_period_start + ") AND (" + query_period_end + ")), IF(emp.employee_last_date < (" + query_period_end + "), (SELECT COUNT(*) FROM tb_emp_schedule WHERE id_schedule_type IN (1, 3) AND id_employee = emp.id_employee AND date BETWEEN (" + query_period_start + ") AND emp.employee_last_date), dep.total_workdays)) AS actual_workdays, emp.employee_code, emp.employee_name, emp.id_departement, dep.departement, emp.employee_position, emp.id_employee_level, lvl.employee_level, emp.id_employee_status, sts.employee_status, emp.id_employee_active, active.employee_active, DATE_FORMAT(emp.employee_actual_join_date, '%d %M %Y') AS employee_actual_join_date, DATE_FORMAT(emp.employee_last_date, '%d %M %Y') AS employee_last_date, rlg.religion
                    FROM tb_m_employee AS emp
                    INNER JOIN tb_m_departement AS dep ON dep.id_departement = emp.id_departement
                    INNER JOIN tb_lookup_employee_level AS lvl ON lvl.id_employee_level = emp.id_employee_level 
                    INNER JOIN tb_lookup_employee_status AS sts ON sts.id_employee_status = emp.id_employee_status 
                    INNER JOIN tb_lookup_employee_active AS active ON active.id_employee_active = emp.id_employee_active
                    INNER JOIN (	
                        SELECT MAX(id_employee_salary) AS id_employee_salary, id_employee 
                        FROM tb_m_employee_salary WHERE effective_date <= (" + query_period_end + ")
                        GROUP BY id_employee
                    ) salx ON salx.id_employee = emp.id_employee
                    LEFT JOIN tb_lookup_religion rlg ON rlg.id_religion = emp.id_religion
                    WHERE emp.id_employee NOT IN (SELECT id_employee FROM tb_emp_payroll_det WHERE id_payroll = '" & id_payroll & "') " + where_dw + "
                "
            End If
        Else
            Dim id_religion As String = execute_query("SELECT id_religion FROM tb_emp_payroll_type WHERE id_payroll_type = " & id_payroll_type & "", 0, True, "", "", "", "")

            query = "
                SELECT emp.id_employee, salx.id_employee_salary, 0 AS total_workdays, ROUND(DATEDIFF((" + query_period_end + "), emp.employee_actual_join_date) / 365, 2) AS actual_workdays, emp.employee_code, emp.employee_name, emp.id_departement, dep.departement, emp.employee_position, emp.id_employee_level, lvl.employee_level, emp.id_employee_status, sts.employee_status, emp.id_employee_active, active.employee_active, DATE_FORMAT(emp.employee_actual_join_date, '%d %M %Y') AS employee_actual_join_date, DATE_FORMAT(emp.employee_last_date, '%d %M %Y') AS employee_last_date, rlg.religion
                FROM tb_m_employee AS emp
                INNER JOIN tb_m_departement AS dep ON dep.id_departement = emp.id_departement
                INNER JOIN tb_lookup_employee_level AS lvl ON lvl.id_employee_level = emp.id_employee_level 
                INNER JOIN tb_lookup_employee_status AS sts ON sts.id_employee_status = emp.id_employee_status 
                INNER JOIN tb_lookup_employee_active AS active ON active.id_employee_active = emp.id_employee_active
                INNER JOIN (	
                    SELECT MAX(id_employee_salary) AS id_employee_salary, id_employee 
                    FROM tb_m_employee_salary WHERE effective_date <= (" + query_period_end + ")
                    GROUP BY id_employee
                ) salx ON salx.id_employee = emp.id_employee
                LEFT JOIN tb_lookup_religion rlg ON rlg.id_religion = emp.id_religion
                WHERE emp.id_employee NOT IN (SELECT id_employee FROM tb_emp_payroll_det WHERE id_payroll = '" & id_payroll & "') " + where_dw + " AND TIMESTAMPDIFF(MONTH, emp.employee_actual_join_date, (" + query_period_end + ")) >= (SELECT min_month_thr FROM tb_opt_emp LIMIT 1) AND emp.id_religion IN (" & id_religion & ")
            "
        End If

        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")

        GCEmployee.DataSource = data

        GVEmployee.ActiveFilterString = "[employee_active] = 'Active'"

        GVEmployee.BestFitColumns()

        If payroll_type.Rows(0)("is_thr").ToString = "1" Then
            GCReligion.Visible = True
        End If
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
        GVEmployee.ApplyFindFilter("")

        'get thr dw salary from latest bpjstk
        Dim data_bpjstk As DataTable = New DataTable

        Dim payroll_type As DataTable = execute_query("SELECT is_thr, is_dw FROM tb_emp_payroll_type WHERE id_payroll_type = " + id_payroll_type, -1, True, "", "", "", "")

        If payroll_type.Rows(0)("is_thr").ToString = "1" And payroll_type.Rows(0)("is_dw").ToString = "1" Then
            data_bpjstk = execute_query("CALL view_payroll_bpjstk_detail((SELECT id_payroll FROM tb_emp_payroll WHERE id_payroll_type = 4 AND id_report_status = 6 AND periode_end <= (SELECT periode_end FROM tb_emp_payroll WHERE id_payroll = " + id_payroll + ") ORDER BY id_payroll DESC LIMIT 1))", -1, True, "", "", "", "")
        End If

        If GVEmployee.SelectedRowsCount > 0 Then
            Dim query As String = "INSERT INTO tb_emp_payroll_det(id_payroll, id_employee, id_salary, workdays, actual_workdays, total_salary_thr) VALUES "

            Dim selected_rows As Integer() = GVEmployee.GetSelectedRows()

            For i = 0 To selected_rows.Length - 1
                Dim selected_row As Integer = selected_rows(i)

                If selected_row >= 0 Then
                    Dim id_employee As String = GVEmployee.GetRowCellValue(selected_row, "id_employee").ToString
                    Dim id_salary As String = GVEmployee.GetRowCellValue(selected_row, "id_employee_salary").ToString
                    Dim workdays As String = GVEmployee.GetRowCellValue(selected_row, "total_workdays").ToString
                    Dim actual_workdays As String = GVEmployee.GetRowCellValue(selected_row, "actual_workdays").ToString
                    Dim total_salary_thr As String = "NULL"

                    'get total salary from latest bpjstk
                    For j = 0 To data_bpjstk.Rows.Count - 1
                        If data_bpjstk.Rows(j)("id_employee").ToString = GVEmployee.GetRowCellValue(selected_row, "id_employee").ToString Then
                            total_salary_thr = Decimal.Round(Decimal.Parse(data_bpjstk.Rows(j)("employee_salary").ToString), 0).ToString
                        End If
                    Next

                    query += "('" & id_payroll & "', '" & id_employee & "', '" & id_salary & "', '" & workdays & "', " & decimalSQL(actual_workdays) & ", " + total_salary_thr + "), "
                End If
            Next

            query = query.Substring(0, query.Length - 2)

            execute_non_query(query, True, "", "", "", "")
        Else
            errorCustom("No employee selected.")

            GVEmployee.ActiveFilterString = "[employee_active] = 'Active'"
        End If

        FormEmpPayroll.load_payroll_detail()

        Close()
    End Sub

    Private Sub BPickAll_Click(sender As Object, e As EventArgs) Handles BPickAll.Click
        Dim query As String = ""

        Dim query_period_start As String = "SELECT periode_start FROM tb_emp_payroll WHERE id_payroll = '" + id_payroll + "'"
        Dim query_period_end As String = "SELECT periode_end FROM tb_emp_payroll WHERE id_payroll = '" + id_payroll + "'"

        If id_payroll_type = "1" Then
            query = "
                INSERT INTO tb_emp_payroll_det (id_payroll, id_employee, id_salary, workdays, actual_workdays)
                SELECT '" + id_payroll + "' AS id_payroll, emp.id_employee, salx.id_employee_salary, dep.total_workdays, IF(emp.employee_join_date > (" + query_period_start + "), (SELECT COUNT(*) FROM tb_emp_schedule WHERE id_schedule_type IN (1, 3) AND id_employee = emp.id_employee AND date BETWEEN (" + query_period_start + ") AND (" + query_period_end + ")), IF(emp.employee_last_date < (" + query_period_end + "), (SELECT COUNT(*) FROM tb_emp_schedule WHERE id_schedule_type IN (1, 3) AND id_employee = emp.id_employee AND date BETWEEN (" + query_period_start + ") AND emp.employee_last_date), dep.total_workdays)) AS actual_workdays
                FROM tb_m_employee AS emp
                INNER JOIN tb_m_departement AS dep ON dep.id_departement = emp.id_departement
                INNER JOIN tb_lookup_employee_level AS lvl ON lvl.id_employee_level = emp.id_employee_level 
                INNER JOIN tb_lookup_employee_active AS active ON active.id_employee_active = emp.id_employee_active
                INNER JOIN (	
                    SELECT MAX(id_employee_salary) AS id_employee_salary, id_employee 
                    FROM tb_m_employee_salary WHERE effective_date <= (" + query_period_end + ")
                    GROUP BY id_employee
                ) salx ON salx.id_employee = emp.id_employee
                WHERE ((emp.id_employee_active = '1') OR (emp.employee_last_date BETWEEN (" + query_period_start + ") AND (" + query_period_end + "))) AND emp.id_employee NOT IN (SELECT id_employee FROM tb_emp_payroll_det WHERE id_payroll = '" & id_payroll & "') AND emp.id_employee_status != 3
            "
        ElseIf id_payroll_type = "2" Then 'thr
            query = "
                INSERT INTO tb_emp_payroll_det (id_payroll, id_employee, id_salary, workdays, actual_workdays)
                SELECT '" + id_payroll + "' AS id_payroll, emp.id_employee, salx.id_employee_salary, dep.total_workdays, IF(emp.employee_join_date > (" + query_period_start + "), (SELECT COUNT(*) FROM tb_emp_schedule WHERE id_schedule_type IN (1, 3) AND id_employee = emp.id_employee AND date BETWEEN (" + query_period_start + ") AND (" + query_period_end + ")), IF(emp.employee_last_date < (" + query_period_end + "), (SELECT COUNT(*) FROM tb_emp_schedule WHERE id_schedule_type IN (1, 3) AND id_employee = emp.id_employee AND date BETWEEN (" + query_period_start + ") AND emp.employee_last_date), dep.total_workdays)) AS actual_workdays
                FROM tb_m_employee AS emp
                INNER JOIN tb_m_departement AS dep ON dep.id_departement = emp.id_departement
                INNER JOIN tb_lookup_employee_level AS lvl ON lvl.id_employee_level = emp.id_employee_level 
                INNER JOIN tb_lookup_employee_active AS active ON active.id_employee_active = emp.id_employee_active
                INNER JOIN (	
                    SELECT MAX(id_employee_salary) AS id_employee_salary, id_employee 
                    FROM tb_m_employee_salary WHERE effective_date <= (" + query_period_end + ")
                    GROUP BY id_employee
                ) salx ON salx.id_employee = emp.id_employee
                WHERE ((emp.id_employee_active = '1') OR (emp.employee_last_date BETWEEN (" + query_period_start + ") AND (" + query_period_end + "))) AND emp.id_employee NOT IN (SELECT id_employee FROM tb_emp_payroll_det WHERE id_payroll = '" & id_payroll & "') AND emp.id_employee_status != 3 AND TIMESTAMPDIFF(MONTH, emp.employee_join_date, DATE(NOW())) >= (SELECT min_month_bonus FROM tb_opt_emp LIMIT 1)
            "
        ElseIf id_payroll_type = "3" Then 'bonus
            query = "
                INSERT INTO tb_emp_payroll_det (id_payroll, id_employee, id_salary, workdays, actual_workdays)
                SELECT '" + id_payroll + "' AS id_payroll, emp.id_employee, salx.id_employee_salary, dep.total_workdays, IF(emp.employee_join_date > (" + query_period_start + "), (SELECT COUNT(*) FROM tb_emp_schedule WHERE id_schedule_type IN (1, 3) AND id_employee = emp.id_employee AND date BETWEEN (" + query_period_start + ") AND (" + query_period_end + ")), IF(emp.employee_last_date < (" + query_period_end + "), (SELECT COUNT(*) FROM tb_emp_schedule WHERE id_schedule_type IN (1, 3) AND id_employee = emp.id_employee AND date BETWEEN (" + query_period_start + ") AND emp.employee_last_date), dep.total_workdays)) AS actual_workdays
                FROM tb_m_employee AS emp
                INNER JOIN tb_m_departement AS dep ON dep.id_departement = emp.id_departement
                INNER JOIN tb_lookup_employee_level AS lvl ON lvl.id_employee_level = emp.id_employee_level 
                INNER JOIN tb_lookup_employee_active AS active ON active.id_employee_active = emp.id_employee_active
                INNER JOIN (	
                    SELECT MAX(id_employee_salary) AS id_employee_salary, id_employee 
                    FROM tb_m_employee_salary WHERE effective_date <= (" + query_period_end + ")
                    GROUP BY id_employee
                ) salx ON salx.id_employee = emp.id_employee
                WHERE ((emp.id_employee_active = '1') OR (emp.employee_last_date BETWEEN (" + query_period_start + ") AND (" + query_period_end + "))) AND emp.id_employee NOT IN (SELECT id_employee FROM tb_emp_payroll_det WHERE id_payroll = '" & id_payroll & "') AND emp.id_employee_status != 3 AND TIMESTAMPDIFF(MONTH, emp.employee_join_date, DATE(NOW())) >= (SELECT min_month_bonus FROM tb_opt_emp LIMIT 1)
            "
        ElseIf id_payroll_type = "4" Then 'dw
            query = "
                INSERT INTO tb_emp_payroll_det (id_payroll, id_employee, id_salary, workdays, actual_workdays)
                SELECT '" + id_payroll + "' AS id_payroll, emp.id_employee, salx.id_employee_salary, dep.total_workdays, IF(emp.employee_join_date > (" + query_period_start + "), (SELECT COUNT(*) FROM tb_emp_schedule WHERE id_schedule_type IN (1, 3) AND id_employee = emp.id_employee AND date BETWEEN (" + query_period_start + ") AND (" + query_period_end + ")), IF(emp.employee_last_date < (" + query_period_end + "), (SELECT COUNT(*) FROM tb_emp_schedule WHERE id_schedule_type IN (1, 3) AND id_employee = emp.id_employee AND date BETWEEN (" + query_period_start + ") AND emp.employee_last_date), dep.total_workdays)) AS actual_workdays
                FROM tb_m_employee AS emp
                INNER JOIN tb_m_departement AS dep ON dep.id_departement = emp.id_departement
                INNER JOIN tb_lookup_employee_level AS lvl ON lvl.id_employee_level = emp.id_employee_level 
                INNER JOIN tb_lookup_employee_active AS active ON active.id_employee_active = emp.id_employee_active
                INNER JOIN (	
                    SELECT MAX(id_employee_salary) AS id_employee_salary, id_employee 
                    FROM tb_m_employee_salary WHERE effective_date <= (" + query_period_end + ")
                    GROUP BY id_employee
                ) salx ON salx.id_employee = emp.id_employee
                WHERE ((emp.id_employee_active = '1') OR (emp.employee_last_date BETWEEN (" + query_period_start + ") AND (" + query_period_end + "))) AND emp.id_employee NOT IN (SELECT id_employee FROM tb_emp_payroll_det WHERE id_payroll = '" & id_payroll & "') AND emp.id_employee_status = 3
            "
        End If

        execute_non_query(query, True, "", "", "", "")

        FormEmpPayroll.load_payroll_detail()

        Close()
    End Sub
End Class