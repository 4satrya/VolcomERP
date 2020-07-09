Public Class FormExternalUser
    Private Sub FormExternalUser_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        load_form()
    End Sub

    Sub load_form()
        Dim data As DataTable = execute_query("
            SELECT u.id_user, u.name_external, u.position_external, u.username, s.store_name, t.st_user_code
            FROM tb_m_user AS u
            LEFT JOIN tb_m_store AS s ON u.id_store = s.id_store
            LEFT JOIN tb_st_user AS t ON u.id_user = t.id_user
            WHERE u.is_external_user = 1
        ", -1, True, "", "", "", "")

        GCExternalUser.DataSource = data

        GVExternalUser.BestFitColumns()
    End Sub

    Private Sub FormExternalUser_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub FormExternalUser_Activated(sender As Object, e As EventArgs) Handles MyBase.Activated
        FormMain.show_rb(Name)
        checkFormAccess(Name)
        button_main("1", "1", "0")
    End Sub

    Private Sub FormExternalUser_Deactivate(sender As Object, e As EventArgs) Handles MyBase.Deactivate
        FormMain.hide_rb()
    End Sub

    Private Sub GVExternalUser_DoubleClick(sender As Object, e As EventArgs) Handles GVExternalUser.DoubleClick
        FormMain.but_edit()
    End Sub
End Class