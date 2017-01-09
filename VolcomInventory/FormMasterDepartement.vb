Public Class FormMasterDepartement
    Dim bnew_active As String = "1"
    Dim bedit_active As String = "1"
    Dim bdel_active As String = "1"

    Private Sub FormMasterDepartement_FormClosed(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub FormMasterDepartement_Activated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Activated
        FormMain.show_rb(Name)
        checkFormAccess(Name)
        button_main(bnew_active, bedit_active, bdel_active)
    End Sub

    Sub view_department()
        Dim data As DataTable = execute_query("SELECT dept.*,emp.employee_name,empx.employee_name AS employee_name_asst FROM tb_m_departement dept 
                                                LEFT JOIN tb_m_user usr ON usr.id_user = dept.id_user_head 
                                                LEFT JOIN tb_m_employee emp ON emp.id_employee=usr.id_employee 
                                                LEFT JOIN tb_m_user usrx ON usrx.id_user = dept.id_user_asst_head 
                                                LEFT JOIN tb_m_employee empx ON empx.id_employee=usrx.id_employee 
                                                ORDER BY dept.departement", -1, True, "", "", "", "")
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

    Private Sub FormMasterDepartement_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        apply_skin()
        view_department()
    End Sub

    Private Sub FormMasterDepartement_Deactivate(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Deactivate
        FormMain.hide_rb()
    End Sub
End Class