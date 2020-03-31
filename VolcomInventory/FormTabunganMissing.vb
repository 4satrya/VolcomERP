Public Class FormTabunganMissing
    Private Sub FormTabunganMissing_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim query As String = "
            (SELECT d.id_employee, e.id_departement, p.departement, e.employee_code, e.employee_name, e.employee_position, e.id_employee_status, s.employee_status, e.id_employee_active, a.employee_active, SUM(d.deduction) AS total
            FROM tb_emp_payroll_deduction AS d
            LEFT JOIN tb_emp_payroll AS l ON d.id_payroll = l.id_payroll
            LEFT JOIN tb_m_employee AS e ON d.id_employee = e.id_employee
            LEFT JOIN tb_m_departement AS p ON e.id_departement = p.id_departement
            LEFT JOIN tb_lookup_employee_status AS s ON e.id_employee_status = s.id_employee_status
            LEFT JOIN tb_lookup_employee_active AS a ON e.id_employee_active = a.id_employee_active
            WHERE l.id_report_status = 6 AND d.id_salary_deduction IN (6, 13)
            GROUP BY d.id_employee)
            UNION ALL
            (SELECT t.id_employee, e.id_departement, p.departement, e.employee_code, e.employee_name, e.employee_position, e.id_employee_status, s.employee_status, e.id_employee_active, a.employee_active, SUM(t.amount) AS total
            FROM tb_tabungan_missing AS t
            LEFT JOIN tb_m_employee AS e ON t.id_employee = e.id_employee
            LEFT JOIN tb_m_departement AS p ON e.id_departement = p.id_departement
            LEFT JOIN tb_lookup_employee_status AS s ON e.id_employee_status = s.id_employee_status
            LEFT JOIN tb_lookup_employee_active AS a ON e.id_employee_active = a.id_employee_active
            GROUP BY t.id_employee)
        "

        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")

        GCList.DataSource = data

        GVList.BestFitColumns()
    End Sub

    Private Sub FormTabunganMissing_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub FormTabunganMissing_Activated(sender As Object, e As EventArgs) Handles MyBase.Activated
        FormMain.show_rb(Name)
        checkFormAccess(Name)
        button_main("0", "0", "0")
    End Sub

    Private Sub FormTabunganMissing_Deactivate(sender As Object, e As EventArgs) Handles MyBase.Deactivate
        FormMain.hide_rb()
    End Sub

    Private Sub GVList_FocusedRowChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles GVList.FocusedRowChanged
        If GVList.GetFocusedRowCellValue("id_employee") IsNot Nothing Then
            Dim id_employee As String = GVList.GetFocusedRowCellValue("id_employee").ToString

            Dim query As String = "
                SELECT 0 AS no, tb.*
                FROM (
                    (
                        SELECT CONCAT('Payroll ', DATE_FORMAT(p.periode_end, '%M %Y')) AS description, d.deduction AS amount, IF(m.is_store = 1, p.store_periode_end, p.periode_end) AS `date`
                        FROM tb_emp_payroll_deduction AS d
                        LEFT JOIN tb_emp_payroll AS p ON d.id_payroll = p.id_payroll
                        LEFT JOIN tb_m_employee AS e ON d.id_employee = e.id_employee
		                LEFT JOIN tb_m_departement AS m ON e.id_departement = m.id_departement
                        WHERE p.id_report_status = 6 AND d.id_salary_deduction IN (6, 13) AND d.id_employee = " + id_employee + "
                    )
                    UNION ALL
                    (
                        SELECT description, amount, `date`
                        FROM tb_tabungan_missing 
                        WHERE id_employee = " + id_employee + "
                    )
                ) AS tb
                ORDER BY tb.date
            "

            Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")

            GCMissing.DataSource = data

            GVMissing.BestFitColumns()

            'numbering
            Dim no As Integer = 0

            For i = 0 To GVMissing.RowCount - 1
                If GVMissing.IsValidRowHandle(i) Then
                    no = no + 1

                    GVMissing.SetRowCellValue(i, "no", no)
                End If
            Next
        End If
    End Sub

    Sub print()

    End Sub
End Class