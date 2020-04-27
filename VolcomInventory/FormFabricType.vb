Public Class FormFabricType
    Dim bnew_active As String = "0"
    Dim bedit_active As String = "0"
    Dim bdel_active As String = "0"

    Sub check_menu()
        bnew_active = "0"
        bedit_active = "0"
        bdel_active = "0"
        checkFormAccess(Name)
        button_main(bnew_active, bedit_active, bdel_active)
    End Sub

    Private Sub FormFabricType_Activated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Activated
        FormMain.show_rb(Name)
        check_menu()
    End Sub

    Private Sub FormFabricType_Deactivate(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Deactivate
        FormMain.hide_rb()
    End Sub

    Private Sub FormFabricType_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub FormFabricType_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub BtnView_Click(sender As Object, e As EventArgs) Handles BtnView.Click
        load_list()
    End Sub

    Sub load_list()
        Dim q As String = "SELECT * FROM tb_m_fabric_type ORDER BY id_fabric_type DESC"
        Dim dt As DataTable = execute_query(q, -1, True, "", "", "", "")
        GCData.DataSource = dt
        GVData.BestFitColumns()
    End Sub
End Class