Public Class FormMenuAuth
    Public type As String = "-1"

    Private Sub FormMenuAuth_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs) Handles SimpleButton1.Click
        Dim username As String = addSlashes(TxtUsername.Text.ToString)
        Dim password As String = addSlashes(TxtPass.Text.ToString)

        Dim query As String = "SELECT * FROM tb_m_user u 
        INNER JOIN tb_menu_single_acc ms ON ms.id_user = u.id_user AND ms.type=" + type + "
        WHERE u.username='" + username + "' AND password=MD5('" + password + "') "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        If data.Rows.Count > 0 Then
            allowed()
            Close()
        Else
            stopCustom("You do not have access for this menu")
            rejected()
            Close()
        End If
    End Sub

    Private Sub SimpleButton2_Click(sender As Object, e As EventArgs) Handles SimpleButton2.Click
        rejected()
        Close()
    End Sub

    Sub allowed()
        If type = "1" Then
            FormSalesReturnDetNew.allow = True
        End If
    End Sub

    Sub rejected()
        If type = "1" Then
            FormSalesReturnDetNew.allow = False
        End If
    End Sub

    Private Sub FormMenuAuth_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub
End Class