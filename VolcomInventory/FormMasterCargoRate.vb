Public Class FormMasterCargoRate
    Dim bnew_active As String = "1"
    Dim bedit_active As String = "1"
    Dim bdel_active As String = "1"
    '
    Sub check_but()
        If GVCargoRate.RowCount > 0 Then
            bnew_active = "1"
            bedit_active = "1"
            bdel_active = "1"
        Else
            bnew_active = "1"
            bedit_active = "0"
            bdel_active = "0"
        End If
        checkFormAccess(Name)
        button_main(bnew_active, bedit_active, bdel_active)
    End Sub

    Private Sub FormMasterCargoRate_Activated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Activated
        FormMain.show_rb(Name)
        checkFormAccess(Name)
        button_main(bnew_active, bedit_active, bdel_active)
    End Sub

    Private Sub FormMasterCargoRate_Deactivate(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Deactivate
        FormMain.hide_rb()
    End Sub

    Private Sub FormMasterCargoRate_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        load_cargo_rate()
    End Sub

    Sub load_cargo_rate()
        Dim query As String = ""
        query = "SELECT * FROM tb_m_cargo_rate"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCCargoRate.DataSource = data
    End Sub

    Private Sub GVCargoRate_DoubleClick(sender As Object, e As EventArgs) Handles GVCargoRate.DoubleClick
        If GVCargoRate.RowCount > 0 Then
            FormMasterCargoRateDet.id_cargo_rate = GVCargoRate.GetFocusedRowCellValue("id_cargo_rate").ToString
            FormMasterCargoRateDet.ShowDialog()
        End If
    End Sub
End Class