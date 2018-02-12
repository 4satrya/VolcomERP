Public Class FormEmpPayrollDeductionDet
    Public id_payroll_deduction As String = "-1"
    Public id_employee As String = "-1"

    Private Sub FormEmpPayrollDeductionDet_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        TEDeduction.EditValue = 0
        load_deduction()
        '
        If Not id_payroll_deduction = "-1" Then 'edit
            Dim query As String = "SELECT pyd.*,emp.employee_code,emp.employee_name FROM tb_emp_payroll_deduction pyd 
                                    INNER JOIN tb_m_employee emp ON emp.id_employee=pyd.id_employee
                                    WHERE pyd.id_payroll_deduction='" & id_payroll_deduction & "'"
            Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
            If data.Rows.Count > 0 Then
                id_employee = data.Rows(0)("id_employee").ToString
                TEEmployeeCode.Text = data.Rows(0)("employee_code").ToString
                TEEmployeeName.Text = data.Rows(0)("employee_name").ToString
                '
                LEDeductionType.ItemIndex = LEDeductionType.Properties.GetDataSourceRowIndex("id_salary_deduction", data.Rows(0)("id_salary_deduction").ToString)
                TEDeduction.EditValue = data.Rows(0)("deduction")
                MENote.Text = data.Rows(0)("note").ToString
                '
            End If
        End If
    End Sub

    Sub load_deduction()
        Dim query As String = "SELECT id_salary_deduction,description FROM `tb_lookup_salary_deduction`"
        viewLookupQuery(LEDeductionType, query, 0, "description", "id_salary_deduction")
    End Sub

    Private Sub FormEmpPayrollDeductionDet_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub BCancel_Click(sender As Object, e As EventArgs) Handles BCancel.Click
        Close()
    End Sub

    Private Sub BSave_Click(sender As Object, e As EventArgs) Handles BSave.Click
        Dim id_sal_deduction, deduction, note, id_payroll As String

        id_sal_deduction = LEDeductionType.EditValue.ToString
        deduction = TEDeduction.EditValue.ToString
        note = addSlashes(MENote.Text)
        id_payroll = FormEmpPayroll.GVPayrollPeriode.GetFocusedRowCellValue("id_payroll").ToString

        If id_payroll_deduction = "-1" Then 'new
            Dim query As String = "INSERT INTO tb_emp_payroll_deduction(id_payroll,id_employee,id_salary_deduction,deduction,note) VALUES('" & id_payroll & "','" & id_employee & "','" & id_sal_deduction & "','" & deduction & "','" & note & "')"
            execute_non_query(query, True, "", "", "", "")
            Console.WriteLine(query)
            '
            FormEmpPayrollDeduction.load_deduction()
            Close()
        Else
            Dim query As String = "UPDATE tb_emp_payroll_deduction SET id_employee='" & id_employee & "',id_salary_deduction='" & id_sal_deduction & "',deduction='" & deduction & "',note='" & note & "' WHERE id_payroll_deduction='" & id_payroll_deduction & "'"
            execute_non_query(query, True, "", "", "", "")
            Close()
            '
            FormEmpPayrollDeduction.load_deduction()
            Close()
        End If
    End Sub

    Private Sub BPickEmployee_Click(sender As Object, e As EventArgs) Handles BPickEmployee.Click
        FormPopUpEmployee.id_popup = "6"
        FormPopUpEmployee.ShowDialog()
        If Not id_employee = "-1" Then
            LEDeductionType.Focus()
        End If
    End Sub

    Private Sub TEEmployeeCode_KeyDown(sender As Object, e As KeyEventArgs) Handles TEEmployeeCode.KeyDown
        If e.KeyCode = Keys.Enter Then
            load_emp_detail()
            LEDeductionType.Focus()
        End If
    End Sub

    Sub load_emp_detail()
        Dim query As String = "SELECT emp.*,dep.departement FROM tb_m_employee emp 
                                INNER JOIN tb_m_departement dep ON dep.id_departement=emp.id_departement 
                                INNER JOIN tb_lookup_employee_level lvl ON lvl.id_employee_level=emp.id_employee_level  
                                WHERE employee_code='" & TEEmployeeCode.Text & "'"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")

        If data.Rows.Count > 0 Then
            TEEmployeeName.Text = data.Rows(0)("employee_name").ToString
            id_employee = data.Rows(0)("id_employee").ToString
        Else
            stopCustom("Karyawan tidak ditemukan.")
        End If
    End Sub
End Class