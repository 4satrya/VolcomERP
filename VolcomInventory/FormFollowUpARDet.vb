Public Class FormFollowUpARDet
    Public id As String = "-1"
    Public action As String = "-1"

    Private Sub FormFollowUpARDet_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub BtnClose_Click(sender As Object, e As EventArgs) Handles BtnClose.Click
        Close()
    End Sub

    Private Sub FormFollowUpARDet_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        actionLoad()
    End Sub

    Sub actionLoad()
        Cursor = Cursors.WaitCursor
        SLEStoreGroup.Focus()
        If action = "ins" Then

        ElseIf action = "upd" Then

        End If
        Cursor = Cursors.Default
    End Sub

End Class