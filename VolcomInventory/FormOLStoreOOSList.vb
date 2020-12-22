Public Class FormOLStoreOOSList
    Private Sub FormOLStoreOOSList_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub FormOLStoreOOSList_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub BtnDiscard_Click(sender As Object, e As EventArgs) Handles BtnDiscard.Click
        Close()
    End Sub

    Private Sub BtnProceed_Click(sender As Object, e As EventArgs) Handles BtnProceed.Click
        proceed()
    End Sub

    Sub proceed()
        Cursor = Cursors.WaitCursor

        Cursor = Cursors.Default
    End Sub
End Class