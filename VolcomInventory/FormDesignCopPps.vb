Public Class FormDesignCopPps
    Dim id_pps As String = "-1"

    Private Sub BtnCancel_Click(sender As Object, e As EventArgs) Handles BtnCancel.Click
        Close()
    End Sub

    Private Sub FormDesignCopPps_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub FormDesignCopPps_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class