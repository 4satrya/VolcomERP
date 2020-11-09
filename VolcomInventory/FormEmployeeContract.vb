Public Class FormEmployeeContract
    Private Sub FormEmployeeContract_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        form_load()
    End Sub

    Private Sub FormEmployeeContract_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub FormEmployeeContract_Activated(sender As Object, e As EventArgs) Handles MyBase.Activated
        FormMain.show_rb(Name)
        checkFormAccess(Name)
    End Sub

    Private Sub FormEmployeeContract_Deactivate(sender As Object, e As EventArgs) Handles MyBase.Deactivate
        FormMain.hide_rb()
    End Sub

    Sub form_load()
        Dim query As String = "
            SELECT c.id_emp_contract, c.id_contract_type, c.employee_name, c.number, c.start_period, c.end_period, c.created_at, e.employee_name AS created_by, l.contract_type
            FROM tb_emp_contract AS c
            LEFT JOIN tb_lookup_contract_type AS l ON c.id_contract_type = l.id_contract_type
            LEFT JOIN tb_m_employee AS e ON c.created_by = e.id_employee
            ORDER BY c.id_emp_contract DESC
        "

        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")

        GCEmployeeContract.DataSource = data

        GVEmployeeContract.BestFitColumns()
    End Sub

    Sub print(id_emp_contract As String)

    End Sub

    Private Sub PrintToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PrintToolStripMenuItem.Click
        print(GVEmployeeContract.GetFocusedRowCellValue("id_emp_contract").ToString)
    End Sub
End Class