Public Class FormDepartementSub
    Dim bnew_active As String = "1"
    Dim bedit_active As String = "1"
    Dim bdel_active As String = "1"

    Private Sub FormDepartementSub_FormClosed(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub FormDepartementSub_Activated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Activated
        FormMain.show_rb(Name)
        checkFormAccess(Name)
        button_main(bnew_active, bedit_active, bdel_active)
    End Sub

    Private Sub FormDepartementSub_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        view_departement()
    End Sub

    Sub view_departement()
        Dim data As DataTable = execute_query("SELECT subdept.*,dep.`departement`,emp.employee_name AS sub_dept_head,id_usr_head_sub_dept
                                                FROM tb_m_departement_sub subdept
                                                INNER JOIN tb_m_departement dep ON dep.`id_departement`=subdept.`id_departement` 
                                                LEFT JOIN tb_m_user usr ON usr.id_user = subdept.`id_usr_head_sub_dept`	 
                                                LEFT JOIN tb_m_employee emp ON emp.id_employee=usr.id_employee 
                                                ORDER BY subdept.departement_sub", -1, True, "", "", "", "")

        GCDepartement.DataSource = data
        If data.Rows.Count > 0 Then
            'show all
            bnew_active = "1"
            bedit_active = "1"
            bdel_active = "1"
        Else
            'hide all except new
            bnew_active = "1"
            bedit_active = "0"
            bdel_active = "0"
        End If
        GVDepartment.BestFitColumns()
        checkFormAccess(Name)
        button_main(bnew_active, bedit_active, bdel_active)
    End Sub
End Class