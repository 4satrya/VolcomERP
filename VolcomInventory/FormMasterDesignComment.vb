Public Class FormMasterDesignComment
    Private Sub BtnCancel_Click(sender As Object, e As EventArgs) Handles BtnCancel.Click
        Close()
    End Sub

    Private Sub FormMasterDesignComment_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub BtnSave_Click(sender As Object, e As EventArgs) Handles BtnSave.Click
        Dim query As String = ""
        If MEComment.Text = "" Then
            stopCustom("Please write the comment first !")
        Else
            query = "INSERT INTO tb_m_design_comment(id_design,id_user,datetime,comment) VALUES('" & FormMasterDesignSingle.id_design & "','" & id_user & "',NOW(),'" & addSlashes(MEComment.Text) & "')"
            execute_non_query(query, True, "", "", "", "")
            Dim mail As ClassSendEmail = New ClassSendEmail
            mail.report_mark_type = "design_comment"
            mail.design = FormMasterDesignSingle.TEName.Text.ToString
            mail.date_string = Now.ToString("dd MMM yyyy H:mm:ss")
            mail.season = FormMasterDesignSingle.LESeason.Text.ToString
            'mail.comment = addSlashes(MEComment.Text)
            mail.comment = MEComment.Text
            mail.comment_by = get_user_identify(id_user, "1")
            mail.send_email()
            FormMasterDesignSingle.load_comment()
            Close()
        End If
    End Sub
End Class