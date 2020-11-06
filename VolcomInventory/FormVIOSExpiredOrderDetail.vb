Public Class FormVIOSExpiredOrderDetail
    Public id As String = "-1"

    Private Sub FormVIOSExpiredOrderDetail_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Cursor = Cursors.WaitCursor

        Cursor = Cursors.Default
    End Sub

    Private Sub FormVIOSExpiredOrderDetail_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub
End Class