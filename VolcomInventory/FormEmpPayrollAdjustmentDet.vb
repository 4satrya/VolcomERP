Public Class FormEmpPayrollAdjustmentDet
    Public id_payroll As String = "-1"
    Public id_payroll_adj As String = "-1"
    '
    Public id_employee As String = "-1"
    '
    Private Sub TEEmployeeCode_KeyDown(sender As Object, e As KeyEventArgs) Handles TEEmployeeCode.KeyDown
        If e.KeyCode = Keys.Enter Then
            load_emp_detail()
            LEType.Focus()
        End If
    End Sub
    '
    Sub load_emp_detail()
        Dim query As String = "SELECT pyd.workdays,emp.id_employee,dep.is_store,emp.employee_code,emp.employee_name,dep.departement,emp.employee_join_date,emp.employee_position,(salx.basic_salary+salx.allow_job+salx.allow_meal+salx.allow_trans+salx.allow_house+salx.allow_car) AS thp_total
                                FROM tb_m_employee emp 
                                INNER JOIN tb_m_departement dep ON dep.id_departement=emp.id_departement 
                                INNER JOIN tb_lookup_employee_level lvl ON lvl.id_employee_level=emp.id_employee_level  
                                INNER JOIN tb_emp_payroll_det pyd ON pyd.`id_employee`=emp.`id_employee` AND pyd.`id_payroll`='" & id_payroll & "' 
                                INNER JOIN `tb_m_employee_salary` salx ON salx.`id_employee_salary`=pyd.`id_salary`
                                WHERE employee_code='" & TEEmployeeCode.Text & "'"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")

        If data.Rows.Count > 0 Then
            TEDepartement.Text = data.Rows(0)("departement").ToString
            TETotalWorkdays.EditValue = data.Rows(0)("workdays")
            TEEmployeeName.Text = data.Rows(0)("employee_name").ToString
            id_employee = data.Rows(0)("id_employee").ToString
            TETHP.EditValue = data.Rows(0)("thp_total")
        Else
            stopCustom("Karyawan tidak terdapat pada worksheet.")
        End If
    End Sub

    Private Sub FormEmpPayrollAdjustmentDet_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        TETHP.EditValue = 0
        TETotDays.EditValue = 0.00
        TETotalWorkdays.EditValue = 0.00
        TEIncrease.EditValue = 0
        TEAdjustment.EditValue = 0
        '
        id_payroll = FormEmpPayroll.GVPayrollPeriode.GetFocusedRowCellValue("id_payroll").ToString
        load_adjustment()
        '
        If Not id_payroll_adj = "-1" Then 'edit
            Dim query As String = "SELECT pya.*,emp.employee_code,emp.employee_name,dep.departement,pyd.workdays,(salx.basic_salary+salx.allow_job+salx.allow_meal+salx.allow_trans+salx.allow_house+salx.allow_car) AS thp_total
                                    FROM tb_emp_payroll_adj pya 
                                    INNER JOIN tb_m_employee emp ON emp.id_employee=pya.id_employee
                                    INNER JOIN tb_m_departement dep ON dep.id_departement=emp.id_departement 
                                    INNER JOIN tb_emp_payroll_det pyd ON pyd.id_payroll=pya.id_payroll AND pyd.id_employee=pya.id_employee
                                    INNER JOIN tb_m_employee_salary salx ON salx.id_employee_salary=pyd.id_salary
                                    WHERE pya.id_payroll_adj='" & id_payroll_adj & "'"
            Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
            If data.Rows.Count > 0 Then
                TEEmployeeCode.Text = data.Rows(0)("employee_code").ToString
                TEEmployeeName.Text = data.Rows(0)("employee_name").ToString
                TEDepartement.Text = data.Rows(0)("departement").ToString
                id_employee = data.Rows(0)("id_employee").ToString
                '
                TETHP.EditValue = data.Rows(0)("thp_total")
                TETotalWorkdays.EditValue = data.Rows(0)("workdays")
                TETotDays.EditValue = data.Rows(0)("total_days")
                LEType.ItemIndex = LEType.Properties.GetDataSourceRowIndex("id_salary_adjustment", data.Rows(0)("id_salary_adj").ToString)
                '
                TEIncrease.EditValue = data.Rows(0)("increase")
                TEAdjustment.EditValue = data.Rows(0)("value")
                '
                MENote.Text = data.Rows(0)("note").ToString
                calculate()
            End If
        End If
    End Sub
    Sub calculate()
        Try
            If LEType.EditValue.ToString = "1" Then
                TETotDays.Properties.ReadOnly = True
                TEAdjustment.Properties.ReadOnly = False
                LIncrease.Visible = False
                TEIncrease.Visible = False
            ElseIf LEType.EditValue.ToString = "2" Then
                TETotDays.Properties.ReadOnly = False
                TEAdjustment.Properties.ReadOnly = True
                LIncrease.Visible = True
                TEIncrease.Visible = True
                Dim value As Decimal = 0
                Dim increase As Decimal = 0
                '
                Dim total_days As Decimal = 0.00
                Dim total_workdays As Decimal = 0.00
                '
                total_days = TETotDays.EditValue
                total_workdays = TETotalWorkdays.EditValue
                increase = TEIncrease.EditValue
                '
                value = (total_days / total_workdays) * increase
                TEAdjustment.EditValue = value
            Else
                TETotDays.Properties.ReadOnly = False
                TEAdjustment.Properties.ReadOnly = True
                LIncrease.Visible = False
                TEIncrease.Visible = False
                Dim value As Decimal = 0
                Dim thp As Decimal = 0
                '
                Dim total_days As Decimal = 0.00
                Dim total_workdays As Decimal = 0.00
                '
                total_days = TETotDays.EditValue
                total_workdays = TETotalWorkdays.EditValue
                thp = TETHP.EditValue
                '
                value = (total_days / total_workdays) * thp
                TEAdjustment.EditValue = value
            End If
        Catch ex As Exception
            TEAdjustment.EditValue = 0
        End Try
    End Sub
    Sub load_adjustment()
        Dim query As String = "SELECT id_salary_adjustment,description FROM `tb_lookup_salary_adjustment`"
        viewLookupQuery(LEType, query, 0, "description", "id_salary_adjustment")
    End Sub

    Private Sub BPickEmployee_Click(sender As Object, e As EventArgs) Handles BPickEmployee.Click
        FormPopUpEmployee.id_popup = "7"
        FormPopUpEmployee.ShowDialog()
        If Not id_employee = "-1" Then
            LEType.Focus()
        End If
    End Sub

    Private Sub LEType_KeyDown(sender As Object, e As KeyEventArgs) Handles LEType.KeyDown
        If e.KeyCode = Keys.Enter Then
            If LEType.EditValue.ToString = "2" Then
                TEIncrease.Focus()
            Else
                TETotDays.Focus()
            End If
        End If
    End Sub

    Private Sub TETotDays_KeyDown(sender As Object, e As KeyEventArgs) Handles TETotDays.KeyDown
        If e.KeyCode = Keys.Enter Then
            TEAdjustment.Focus()
        End If
    End Sub

    Private Sub MENote_KeyDown(sender As Object, e As KeyEventArgs) Handles MENote.KeyDown
        If e.KeyCode = Keys.Enter Then
            BSave.Focus()
        End If
    End Sub

    Private Sub TEDeduction_KeyDown(sender As Object, e As KeyEventArgs) Handles TEAdjustment.KeyDown
        If e.KeyCode = Keys.Enter Then
            MENote.Focus()
        End If
    End Sub

    Private Sub BCancel_Click(sender As Object, e As EventArgs) Handles BCancel.Click
        Close()
    End Sub

    Private Sub FormEmpPayrollAdjustmentDet_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub BSave_Click(sender As Object, e As EventArgs) Handles BSave.Click
        If Not id_payroll_adj = "-1" Then 'edit
            Dim query As String = "UPDATE tb_emp_payroll_adj SET id_employee='" & id_employee & "',total_days='" & decimalSQL(TETotDays.EditValue.ToString) & "',id_salary_adj='" & LEType.EditValue.ToString & "',note='" & addSlashes(MENote.Text) & "',increase='" & decimalSQL(TEIncrease.EditValue.ToString) & "',value='" & decimalSQL(TEAdjustment.EditValue.ToString) & "' WHERE id_payroll_adj='" & id_payroll_adj & "'"
            execute_non_query(query, True, "", "", "", "")
            '
            FormEmpPayrollAdjustment.load_adjustment()
            Close()
        Else 'new
            Dim query As String = "INSERT INTO tb_emp_payroll_adj(id_employee,id_payroll,total_days,id_salary_adj,increase,value,note) VALUES('" & id_employee & "','" & id_payroll & "','" & decimalSQL(TETotDays.EditValue.ToString) & "','" & LEType.EditValue.ToString & "','" & decimalSQL(TEIncrease.EditValue.ToString) & "','" & decimalSQL(TEAdjustment.EditValue.ToString) & "','" & addSlashes(MENote.Text) & "')"
            execute_non_query(query, True, "", "", "", "")
            '
            FormEmpPayrollAdjustment.load_adjustment()
            Close()
        End If
    End Sub

    Private Sub TETotDays_EditValueChanged(sender As Object, e As EventArgs) Handles TETotDays.EditValueChanged
        calculate()
    End Sub

    Private Sub TETotalWorkdays_EditValueChanged(sender As Object, e As EventArgs) Handles TETotalWorkdays.EditValueChanged
        calculate()
    End Sub

    Private Sub TETHP_EditValueChanged(sender As Object, e As EventArgs) Handles TETHP.EditValueChanged
        calculate()
    End Sub

    Private Sub LEType_EditValueChanged(sender As Object, e As EventArgs) Handles LEType.EditValueChanged
        calculate()
    End Sub

    Private Sub TEIncrease_KeyDown(sender As Object, e As KeyEventArgs) Handles TEIncrease.KeyDown
        If e.KeyCode = Keys.Enter Then
            TETotDays.Focus()
        End If
    End Sub

    Private Sub TEIncrease_EditValueChanged(sender As Object, e As EventArgs) Handles TEIncrease.EditValueChanged
        calculate()
    End Sub
End Class