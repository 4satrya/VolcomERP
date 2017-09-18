Public Class FormDeliveryCargo
    Dim bnew_active As String = "1"
    Dim bedit_active As String = "1"
    Dim bdel_active As String = "1"
    '

    Private Sub BViewSum_Click(sender As Object, e As EventArgs) Handles BViewSum.Click

    End Sub

    Sub load_awb()

    End Sub

    Private Sub FormDeliveryCargo_Activated(sender As Object, e As EventArgs) Handles MyBase.Activated
        FormMain.show_rb(Name)
        checkFormAccess(Name)
        button_main(bnew_active, bedit_active, bdel_active)
    End Sub

    Private Sub FormDeliveryCargo_Deactivate(sender As Object, e As EventArgs) Handles MyBase.Deactivate
        FormMain.hide_rb()
    End Sub
End Class