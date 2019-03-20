Public Class FormFeedbackDet 

    Private Sub MEFeedback_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MEFeedback.Validating
        EP_ME_cant_blank(ErrorProvider1, MEFeedback)
    End Sub


    Private Sub SimpleButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SimpleButton1.Click
        Close()
    End Sub

    Private Sub FormFeedbackDet_FormClosed(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub


    Private Sub BtnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSave.Click
        Cursor = Cursors.WaitCursor
        ValidateChildren()
        If Not formIsValid(ErrorProvider1) Then
            errorInput()
        Else
            Dim query As String = "INSERT INTO feedback(id_user, feedback_time, feedback) VALUES ('" + id_user + "', NOW(), '" + MEFeedback.Text + "')"
            execute_query(query, -1, True, "", "", "", "")
            pushNotif("Feedback", "You have new feedback system", "FormFeedback", "7", id_user, "0", "", "", "NULL")
            pushNotif("Feedback", "You have new feedback system", "FormFeedback", "8", id_user, "0", "", "", "NULL")
            FormFeedback.viewFeedback()
            Close()
        End If
        Cursor = Cursors.Default
    End Sub
End Class