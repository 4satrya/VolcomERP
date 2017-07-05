Imports DevExpress.XtraEditors

Public Class FormLogin
    'Load
    Private Sub FormLogin_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        TxtUsername.Focus()
        apply_skin()
        For Each ex As Control In Me.Controls
            AddHandler ex.KeyDown, AddressOf FormLogin_KeyUp
        Next
    End Sub
    'Form Close
    Private Sub FormLogin_FormClosed(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub
    'Close Btn
    Private Sub BtnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnClose.Click
        FormMain.NotifyIconVI.Visible = False
        End
    End Sub
    'Login
    Private Sub BtnLogin_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnLogin.Click
        ValidateChildren()
        If Not formIsValid(EPLogin) Then
            errorInput()
        Else
            Dim query As String
            Dim username As String = addSlashes(TxtUsername.Text)
            Dim password As String = addSlashes(TxtPassword.Text)
            Dim data As DataTable
            Try
                Cursor = Cursors.WaitCursor
                query = String.Format("SELECT * FROM tb_m_user a INNER JOIN tb_m_employee b ON a.id_employee = b.id_employee WHERE a.username = '{0}' AND a.password=MD5('{1}') AND b.id_employee_active=1", username, password)
                data = execute_query(query, -1, True, "", "", "", "")
                If data.Rows.Count > 0 Then
                    id_user = data.Rows(0)("id_user").ToString
                    id_role_login = data.Rows(0)("id_role").ToString
                    name_user = data.Rows(0)("employee_name").ToString
                    code_user = data.Rows(0)("employee_code").ToString
                    username_user = data.Rows(0)("username").ToString
                    id_employee_user = data.Rows(0)("id_employee").ToString
                    id_departement_user = data.Rows(0)("id_departement").ToString
                    is_change_pass_user = data.Rows(0)("is_change").ToString
                    Dim show_notif As String = data.Rows(0)("show_notif").ToString
                    checkMenu() 'check menu based on role

                    'log
                    Dim u As New ClassUser()
                    u.logLogin("1")

                    Close()
                    FormMain.Visible = True
                    FormMain.Opacity = 100
                    'FormMain.Badge1.Visible = True
                    FormMain.BringToFront()
                    FormMain.Focus()

                    FormMain.checkNumberNotif()
                    Dim interval As Integer = Integer.Parse(get_setup_field("load_notif").ToString)
                    FormMain.TimerNotif.Interval = interval
                    If show_notif = "1" Then
                        FormMain.TimerNotif.Enabled = True
                    Else
                        FormMain.TimerNotif.Enabled = False
                    End If

                    FormMain.LoginToolStripMenuItem.Visible = False
                    FormMain.LogoutToolStripMenuItem.Visible = True
                    FormMain.DashboardToolStripMenuItem.Visible = True
                    FormMain.checkChangePass()
                Else
                    XtraMessageBox.Show("Login failure, please check your input !", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If
                Cursor = Cursors.Default
            Catch ex As Exception
                errorConnection()
                Close()
            End Try
        End If
    End Sub
    'Validating Username
    Private Sub TxtUsername_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TxtUsername.Validating
        EP_TE_cant_blank(EPLogin, TxtUsername)
    End Sub
    'Validating Password
    Private Sub TxtPassword_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TxtPassword.Validating
        EP_TE_cant_blank(EPLogin, TxtPassword)
    End Sub
    Private Sub FormLogin_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs)
        'testing purpose
        If e.KeyCode = Keys.F1 Then
            TxtUsername.Text = "catur"
            TxtPassword.Text = "catur"
        ElseIf e.KeyCode = Keys.F2 Then
            TxtUsername.Text = "sfinance"
            TxtPassword.Text = "sfinance"
        ElseIf e.KeyCode = Keys.F3 Then
            TxtUsername.Text = "director"
            TxtPassword.Text = "director"
        ElseIf e.KeyCode = Keys.F4 Then
            TxtUsername.Text = "smarketing"
            TxtPassword.Text = "smarketing"
        End If

        'If get_setup_field("login_shortkey") = "1" Then

        'End If
    End Sub

End Class