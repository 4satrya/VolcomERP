Public Class FormPopUpEmployee
    Public id_popup As String = "-1"
    Private Sub FormPopUpEmployee_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        load_emp()
    End Sub
    Sub load_emp()
        Dim query As String = "SELECT emp.id_employee,emp.employee_code,emp.employee_name,dep.departement,emp.employee_join_date,emp.employee_position,active.employee_active"
        query += " FROM tb_m_employee emp"
        query += " INNER JOIN tb_m_departement dep ON dep.id_departement=emp.id_departement"
        query += " INNER JOIN tb_lookup_employee_level lvl ON lvl.id_employee_level=emp.id_employee_level "
        query += " INNER JOIN tb_lookup_employee_active active On active.id_employee_active=emp.id_employee_active"
        If FormEmpLeave.is_propose = "1" Then
            Dim id_user_admin_management As String = get_opt_emp_field("id_user_admin_mng").ToString
            If id_user_admin_management = id_user Then
                Dim id_min_lvl As String = get_opt_emp_field("leave_mng_min_level").ToString
                query += " WHERE lvl.id_employee_level>0 AND lvl.id_employee_level <='" & id_min_lvl & "' "
            Else
                query += " WHERE emp.id_departement='" & id_departement_user & "'"
            End If
        End If
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCEmployee.DataSource = data
        GVEmployee.BestFitColumns()
    End Sub

    Private Sub FormPopUpEmployee_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub BCancel_Click(sender As Object, e As EventArgs) Handles BCancel.Click
        Close()
    End Sub

    Private Sub BPick_Click(sender As Object, e As EventArgs) Handles BPick.Click
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
        End If
    End Sub
End Class