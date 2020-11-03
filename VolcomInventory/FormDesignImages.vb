Public Class FormDesignImages
    Private Sub FormDesignImages_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub FormDesignImages_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub FormDesignImages_Activated(sender As Object, e As EventArgs) Handles MyBase.Activated
        FormMain.show_rb(Name)
        checkFormAccess(Name)
    End Sub

    Private Sub FormDesignImages_Deactivate(sender As Object, e As EventArgs) Handles MyBase.Deactivate
        FormMain.hide_rb()
    End Sub

    Sub view_images()

    End Sub

    Sub browse_images()

    End Sub

    Sub delete_images()

    End Sub

    Sub print_images()

    End Sub
End Class