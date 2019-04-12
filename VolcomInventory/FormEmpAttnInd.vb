Public Class FormEmpAttnInd
    Dim bnew_active As String = "1"
    Dim bedit_active As String = "1"
    Dim bdel_active As String = "1"

    Public is_dep As Boolean = False

    Private Sub FormEmpAttnInd_Activated(sender As Object, e As EventArgs) Handles MyBase.Activated
        FormMain.show_rb(Name)
        checkFormAccess(Name)
        button_main(bnew_active, bedit_active, bdel_active)
    End Sub

    Private Sub FormEmpAttnInd_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub FormEmpAttnInd_Deactivate(sender As Object, e As EventArgs) Handles MyBase.Deactivate
        FormMain.hide_rb()
    End Sub

    Private Sub FormEmpAttnInd_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        load_emp()
    End Sub

    Sub load_emp()
        Dim query As String = "SELECT emp.id_employee,emp.employee_code,emp.employee_name,dep.departement,emp.employee_position,active.employee_active"
        query += " FROM tb_m_employee emp"
        query += " INNER JOIN tb_m_departement dep ON dep.id_departement=emp.id_departement"
        If is_dep = True Then
            query += " AND dep.id_departement='" & id_departement_user & "'"
        End If
        query += " INNER JOIN tb_lookup_employee_active active On active.id_employee_active=emp.id_employee_active"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCEmployee.DataSource = data
        GVEmployee.BestFitColumns()
    End Sub

    Private Sub BViewReport_Click(sender As Object, e As EventArgs) Handles BViewReport.Click
        If GVEmployee.RowCount > 0 Then
            FormEmpAttnIndView.id_employee = GVEmployee.GetFocusedRowCellValue("id_employee").ToString
            FormEmpAttnIndView.TEName.Text = GVEmployee.GetFocusedRowCellValue("employee_name").ToString
            FormEmpAttnIndView.TECode.Text = GVEmployee.GetFocusedRowCellValue("employee_code").ToString
            FormEmpAttnIndView.TEDept.Text = GVEmployee.GetFocusedRowCellValue("departement").ToString
            FormEmpAttnIndView.TEPosition.Text = GVEmployee.GetFocusedRowCellValue("employee_position").ToString
            FormEmpAttnIndView.ShowDialog()
        End If
    End Sub
End Class