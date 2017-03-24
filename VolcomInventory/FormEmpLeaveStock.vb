Public Class FormEmpLeaveStock
    Dim bnew_active As String = "1"
    Dim bedit_active As String = "1"
    Dim bdel_active As String = "1"

    Private Sub FormEmpAttnSum_Activated(sender As Object, e As EventArgs) Handles MyBase.Activated
        FormMain.show_rb(Name)
        checkFormAccess(Name)
        button_main(bnew_active, bedit_active, bdel_active)
    End Sub

    Private Sub FormEmpAttnSum_Deactivate(sender As Object, e As EventArgs) Handles MyBase.Deactivate
        FormMain.hide_rb()
    End Sub

    Private Sub FormEmpAttnSum_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub FormEmpLeaveStock_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        For Each t As DevExpress.XtraTab.XtraTabPage In XTCLeaveRemaining.TabPages
            XTCLeaveRemaining.SelectedTabPage = t
        Next t
        XTCLeaveRemaining.SelectedTabPage = XTCLeaveRemaining.TabPages(0)

        viewDept()
    End Sub

    Sub viewDept()
        Dim query As String = "SELECT 0 as id_departement, 'All departement' as departement UNION (SELECT id_departement,departement FROM tb_m_departement a ORDER BY a.departement ASC) "
        '
        viewLookupQuery(LEDeptSum, query, 0, "departement", "id_departement")
    End Sub

    Sub viewEmp(ByVal LE As DevExpress.XtraEditors.SearchLookUpEdit, ByVal id_dept As String)
        Dim dept_search As String = ""
        If Not id_dept = "0" Then
            dept_search = " AND id_departement='" & id_dept & "'"
        End If
        Dim query As String = "SELECT '0' as id_employee,'-' as employee_code,'All Employee' as employee_name UNION SELECT id_employee,employee_code,employee_name FROM tb_m_employee WHERE 1=1 " & dept_search
        viewSearchLookupQuery(LE, query, "id_employee", "employee_name", "id_employee")
    End Sub

    Private Sub LEDeptSum_EditValueChanged(sender As Object, e As EventArgs) Handles LEDeptSum.EditValueChanged
        Try
            viewEmp(LEEmpSum, LEDeptSum.EditValue.ToString)
        Catch ex As Exception
        End Try
    End Sub

    Private Sub BViewSum_Click(sender As Object, e As EventArgs) Handles BViewSum.Click
        Dim dep_search As String = ""
        Dim emp_search As String = ""

        If XTCLeaveRemaining.SelectedTabPageIndex = 0 Then
            If Not LEDeptSum.EditValue.ToString = "0" Then
                dep_search = " AND emp.id_departement='" & LEDeptSum.EditValue.ToString & "' "
            End If

            If Not LEEmpSum.EditValue.ToString = "0" Then
                emp_search = " AND emp.id_employee='" & LEEmpSum.EditValue.ToString & "' "
            End If

            Dim query As String = "SELECT emp.id_employee,emp.employee_position,emp.employee_code,emp.employee_name,emp.id_departement,dep.departement,lvl.employee_level,active.employee_active
                                ,SUM(IF(emp_sl.type='1',IF(emp_sl.plus_minus=1,emp_sl.qty,-emp_sl.qty),0)) AS qty_leave
                                ,SUM(IF(emp_sl.type='2',IF(emp_sl.plus_minus=1,emp_sl.qty,-emp_sl.qty),0)) AS qty_dp
                                ,SUM(IFNULL(adv.qty_leave,0)) AS adv_leave
                                FROM tb_m_employee emp
                                LEFT JOIN tb_emp_stock_leave emp_sl ON emp.id_employee=emp_sl.id_emp AND emp_sl.is_process_exp = '2' 
                                LEFT JOIN tb_lookup_employee_level lvl ON lvl.id_employee_level=emp.id_employee_level
                                LEFT JOIN tb_m_departement dep ON dep.id_departement=emp.id_departement
                                LEFT JOIN tb_lookup_employee_active active ON active.id_employee_active=emp.id_employee_active
                                LEFT JOIN
                                (
                                    SELECT emp.id_employee,emp.employee_position,emp.employee_code,emp.employee_name,emp.id_departement,dep.departement,lvl.employee_level,active.employee_active
                                    ,(SUM(adv.qty)) AS qty_leave
                                    ,3 AS `type`,'Advance Leave' AS type_ket,NULL AS date_expired
                                    FROM tb_emp_stock_leave_adv adv
                                    INNER JOIN tb_m_employee emp ON emp.id_employee=adv.id_emp
                                    INNER JOIN tb_lookup_employee_level lvl ON lvl.id_employee_level=emp.id_employee_level
                                    INNER JOIN tb_m_departement dep ON dep.id_departement=emp.id_departement
                                    INNER JOIN tb_lookup_employee_active active ON active.id_employee_active=emp.id_employee_active
                                    WHERE 1=1
                                    " & dep_search & "
                                    " & emp_search & "
                                    GROUP BY id_emp
                                    HAVING -(SUM(adv.qty)) < 0   
                                ) adv ON adv.id_employee = emp.id_employee
                                WHERE 1=1
                                " & dep_search & "
                                " & emp_search & "
                                GROUP BY emp.id_employee"
            Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
            Console.WriteLine(query)
            GCSum.DataSource = data
            GVSum.BestFitColumns()
            GVSum.ExpandAllGroups()
        ElseIf XTCLeaveRemaining.SelectedTabPageIndex = 1 Then
            If Not LEDeptSum.EditValue.ToString = "0" Then
                dep_search = " AND emp.id_departement='" & LEDeptSum.EditValue.ToString & "' "
            End If
            If Not LEEmpSum.EditValue.ToString = "0" Then
                emp_search = " AND emp.id_employee='" & LEEmpSum.EditValue.ToString & "' "
            End If

            Dim query As String = "SELECT emp.id_employee,emp.employee_position,emp.employee_code,emp.employee_name,emp.id_departement,dep.departement,lvl.employee_level,active.employee_active
                                ,SUM(IF(emp_sl.plus_minus=1,emp_sl.qty,-emp_sl.qty)) AS qty_leave
                                ,emp_sl.type,IF(emp_sl.type='1','Leave','DP') AS type_ket,emp_sl.date_expired
                                FROM tb_emp_stock_leave emp_sl
                                INNER JOIN tb_m_employee emp ON emp.id_employee=emp_sl.id_emp
                                INNER JOIN tb_lookup_employee_level lvl ON lvl.id_employee_level=emp.id_employee_level
                                INNER JOIN tb_m_departement dep ON dep.id_departement=emp.id_departement
                                INNER JOIN tb_lookup_employee_active active ON active.id_employee_active=emp.id_employee_active
                                WHERE emp_sl.is_process_exp = '2'
                                " & dep_search & "
                                " & emp_search & "
                                GROUP BY emp_sl.id_emp,emp_sl.type,emp_sl.date_expired
                                HAVING SUM(IF(emp_sl.plus_minus=1,emp_sl.qty,-emp_sl.qty)) > 0
                                UNION
                                SELECT emp.id_employee,emp.employee_position,emp.employee_code,emp.employee_name,emp.id_departement,dep.departement,lvl.employee_level,active.employee_active
                                ,-(SUM(adv.qty)) AS qty_leave
                                ,3 AS `type`,'Advance Leave' AS type_ket,NULL AS date_expired
                                FROM tb_emp_stock_leave_adv adv
                                INNER JOIN tb_m_employee emp ON emp.id_employee=adv.id_emp
                                INNER JOIN tb_lookup_employee_level lvl ON lvl.id_employee_level=emp.id_employee_level
                                INNER JOIN tb_m_departement dep ON dep.id_departement=emp.id_departement
                                INNER JOIN tb_lookup_employee_active active ON active.id_employee_active=emp.id_employee_active
                                WHERE 1=1
                                " & dep_search & "
                                " & emp_search & "
                                GROUP BY id_emp
                                HAVING -(SUM(adv.qty)) < 0"
            Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
            GCSchedule.DataSource = data
            GVSchedule.BestFitColumns()
            GVSchedule.ExpandAllGroups()
        End If
    End Sub
End Class