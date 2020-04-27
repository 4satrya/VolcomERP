Public Class FormFabricTypeDet
    Private Sub FormFabricTypeDet_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub FormFabricTypeDet_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        TEAge.EditValue = 0
    End Sub
End Class