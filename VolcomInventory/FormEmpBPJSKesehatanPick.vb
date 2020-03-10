Public Class FormEmpBPJSKesehatanPick
    Private Sub FormEmpBPJSKesehatanPick_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        load_employee()
    End Sub

    Private Sub FormEmpBPJSKesehatanPick_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Sub load_employee()
        Dim include As String = "0, "

        For i = 0 To FormEmpBPJSKesehatanDet.GVInput.RowCount - 1
            If FormEmpBPJSKesehatanDet.GVInput.IsValidRowHandle(i) Then
                include += FormEmpBPJSKesehatanDet.GVInput.GetRowCellValue(i, "id_employee").ToString + ", "
            End If
        Next

        include = include.Substring(0, include.Length - 2)

        Dim where_dw As String = ""

        Dim id_payroll_type As String = execute_query("SELECT id_payroll_type FROM tb_emp_payroll WHERE id_payroll = " + FormEmpBPJSKesehatanDet.SLUEPayroll.EditValue.ToString, 0, True, "", "", "", "")

        If id_payroll_type = "1" Then
            where_dw = "AND e.id_employee_status IN (1, 2)"
        ElseIf id_payroll_type = "4" Then
            where_dw = "AND e.id_employee_status IN (3)"
        End If

        Dim query As String = "
            SELECT 'no' AS is_check, e.id_departement, e.id_departement_sub, d.departement, IF(d.id_departement = 17, ds.departement_sub, d.departement) AS departement_sub, e.id_employee, e.employee_code, e.employee_name, e.employee_position, e.employee_bpjs_kesehatan, DATE_FORMAT(e.employee_dob, '%d %M %Y') AS employee_dob, e.id_employee_status, sts.employee_status, ac.employee_active, IF(e.id_employee_status = 3, (e.basic_salary * d.total_workdays), (e.basic_salary + e.allow_job + e.allow_meal + e.allow_trans)) AS fixed_salary, CAST(IF((SELECT fixed_salary) < py.ump, (py.ump * 0.01), IF((SELECT fixed_salary) >= py.bpjs_max, py.bpjs_max * 0.01, (SELECT fixed_salary) * 0.01)) AS DECIMAL(13, 0)) AS bpjs_kesehatan_contribution
            FROM tb_m_employee AS e
            LEFT JOIN tb_m_departement AS d ON e.id_departement = d.id_departement
            LEFT JOIN tb_m_departement_sub AS ds ON e.id_departement_sub = ds.id_departement_sub
            LEFT JOIN tb_lookup_employee_status AS sts ON e.id_employee_status = sts.id_employee_status
            LEFT JOIN tb_emp_payroll AS py ON py.id_payroll = " + FormEmpBPJSKesehatanDet.SLUEPayroll.EditValue.ToString + "
            LEFT JOIN tb_lookup_employee_active AS ac ON e.id_employee_active = ac.id_employee_active
            WHERE e.is_bpjs_volcom = 1 AND e.basic_salary > 0 AND e.id_employee NOT IN (" + include + ") " + where_dw + "
            ORDER BY d.departement ASC, e.id_employee_level ASC, e.employee_code ASC
        "

        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")

        GCEmployee.DataSource = data

        GVEmployee.ActiveFilterString = "[employee_active] = 'Active'"

        GVEmployee.BestFitColumns()
    End Sub

    Private Sub SBAdd_Click(sender As Object, e As EventArgs) Handles SBAdd.Click
        GVEmployee.ActiveFilterString = "[is_check] = 'yes'"

        GVEmployee.ApplyFindFilter("")

        If GVEmployee.RowCount < 1 Then
            errorCustom("No employee selected.")
        Else
            Dim data As DataTable = FormEmpBPJSKesehatanDet.GCInput.DataSource

            For i = 0 To GVEmployee.RowCount - 1
                If GVEmployee.IsValidRowHandle(i) Then
                    data.Rows.Add(
                        GVEmployee.GetRowCellValue(i, "id_departement").ToString,
                        GVEmployee.GetRowCellValue(i, "id_departement_sub").ToString,
                        GVEmployee.GetRowCellValue(i, "departement").ToString,
                        GVEmployee.GetRowCellValue(i, "departement_sub").ToString,
                        GVEmployee.GetRowCellValue(i, "id_employee").ToString,
                        GVEmployee.GetRowCellValue(i, "employee_code").ToString,
                        GVEmployee.GetRowCellValue(i, "employee_name").ToString,
                        GVEmployee.GetRowCellValue(i, "employee_position").ToString,
                        GVEmployee.GetRowCellValue(i, "employee_bpjs_kesehatan").ToString,
                        GVEmployee.GetRowCellValue(i, "employee_dob").ToString,
                        GVEmployee.GetRowCellValue(i, "id_employee_status").ToString,
                        GVEmployee.GetRowCellValue(i, "employee_status").ToString,
                        GVEmployee.GetRowCellValue(i, "fixed_salary"),
                        GVEmployee.GetRowCellValue(i, "bpjs_kesehatan_contribution")
                    )
                End If
            Next

            FormEmpBPJSKesehatanDet.GCInput.DataSource = data

            Close()
        End If

        GVEmployee.ActiveFilterString = ""
    End Sub

    Private Sub SBClose_Click(sender As Object, e As EventArgs) Handles SBClose.Click
        Close()
    End Sub
End Class