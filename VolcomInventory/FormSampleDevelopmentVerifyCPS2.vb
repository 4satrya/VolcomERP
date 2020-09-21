Public Class FormSampleDevelopmentVerifyCPS2
    Public id_po As String = "-1"
    Private Sub FormSampleDevelopmentVerifyCPS2_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs) Handles SimpleButton1.Click
        Close()
    End Sub

    Private Sub BUpdate_Click(sender As Object, e As EventArgs) Handles BUpdate.Click
        If Not MENote.Text = "" Then
            'check already verified
            Dim qc As String = "SELECT cps2_verify FROM tb_prod_order WHERE id_prod_order='" & id_po & "' AND cps2_verify='2'"
            Dim dtc As DataTable = execute_query(qc, -1, True, "", "", "", "")
            '
            If dtc.Rows.Count > 0 Then
                Dim q As String = "UPDATE tb_prod_order SET cps2_verify='1',cps2_verify_by='" & id_user & "',cps2_verify_note='" & addSlashes(MENote.Text) & "',cps2_verify_date=NOW() WHERE id_prod_order='" & id_po & "'"
                execute_non_query(q, True, "", "", "", "")
                '
                Dim nm As New ClassSendEmail
                nm.id_report = id_po
                nm.report_mark_type = "263"
                nm.send_email()
                '
                Close()
            Else
                warningCustom("Already verified.")
            End If
        Else
            warningCustom("Please put some note !")
        End If
    End Sub
End Class