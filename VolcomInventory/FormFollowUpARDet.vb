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

    End Sub

    Private Sub DateEdit1_EditValueChanged(sender As Object, e As EventArgs) Handles DEDueDate.EditValueChanged

    End Sub

    Private Sub DateEdit2_EditValueChanged(sender As Object, e As EventArgs) Handles DEFollowUpDate.EditValueChanged

    End Sub
End Class