Public Class FormEmpAttnAssign
    Dim bnew_active As String = "1"
    Dim bedit_active As String = "1"
    Dim bdel_active As String = "1"

    Public is_all As String = "-1"

    Private Sub FormEmpAttnAssign_Activated(sender As Object, e As EventArgs) Handles MyBase.Activated
        FormMain.show_rb(Name)
        checkFormAccess(Name)
        button_main(bnew_active, bedit_active, bdel_active)
    End Sub

    Private Sub FormEmpAttnAssign_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub FormEmpAttnAssign_Deactivate(sender As Object, e As EventArgs) Handles MyBase.Deactivate
        FormMain.hide_rb()
    End Sub

    Private Sub FormEmpAttnAssign_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        load_dept()
    End Sub
    '
    Sub load_dept()
        Dim query As String = "SELECT id_departement,departement FROM tb_m_departement a "
        If Not is_all = "1" Then
            query += "WHERE id_departement='" + id_departement_user + "' ORDER BY a.departement ASC "
        End If

        viewLookupQuery(LEDeptSum, query, 0, "departement", "id_departement")
        LEDeptSum.ItemIndex = 0
    End Sub

    Private Sub BViewSum_Click(sender As Object, e As EventArgs) Handles BViewSum.Click
        load_attn()
    End Sub

    Sub load_attn()
        Dim query As String = "SELECT * FROM tb_emp_assign_sch sch
                                LEFT JOIN tb_m_user usr ON usr.id_user=sch.id_user_propose
                                INNER JOIN tb_m_employee emp ON emp.id_employee=usr.id_employee
                                INNER JOIN tb_m_departement dep ON dep.id_departement=sch.id_departement
                                INNER JOIN tb_lookup_report_status s ON s.id_report_status=sch.id_report_status
                                WHERE sch.id_departement='" & LEDeptSum.EditValue.ToString & "'
                                ORDER BY id_assign_sch DESC"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCAttnAssign.DataSource = data

        GVAttnAssign.BestFitColumns()
    End Sub
End Class