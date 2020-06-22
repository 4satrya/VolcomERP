Public Class FormSalesBranch
    Private Sub FormSalesBranch_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Sub viewData()

    End Sub

    Private Sub FormSalesBranch_Activated(sender As Object, e As EventArgs) Handles MyBase.Activated
        FormMain.show_rb(Name)
    End Sub

    Private Sub FormSalesBranch_Deactivate(sender As Object, e As EventArgs) Handles MyBase.Deactivate
        FormMain.hide_rb()
    End Sub
End Class