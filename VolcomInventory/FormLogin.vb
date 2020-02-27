Imports DevExpress.XtraEditors

Public Class FormLogin
    'Load
    Private Sub FormLogin_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        TxtUsername.Focus()
        apply_skin()
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
                query = String.Format("SELECT * FROM tb_m_user a INNER JOIN tb_m_employee b ON a.id_employee = b.id_employee WHERE a.username = '{0}' AND a.password=MD5('{1}') AND IF(ISNULL(employee_last_date),b.id_employee_active=1,b.employee_last_date >= DATE(NOW()))", username, password)
                data = execute_query(query, -1, True, "", "", "", "")
                If data.Rows.Count > 0 Then
                    id_user = data.Rows(0)("id_user").ToString
                    is_auto_load_workplace = data.Rows(0)("is_auto_load_workplace").ToString
                    id_role_login = data.Rows(0)("id_role").ToString
                    name_user = data.Rows(0)("employee_name").ToString
                    code_user = data.Rows(0)("employee_code").ToString
                    username_user = data.Rows(0)("username").ToString
                    id_employee_user = data.Rows(0)("id_employee").ToString
                    id_departement_user = data.Rows(0)("id_departement").ToString
                    id_departement_sub_user = data.Rows(0)("id_departement_sub").ToString
                    is_change_pass_user = data.Rows(0)("is_change").ToString
                    Dim show_notif As String = data.Rows(0)("show_notif").ToString
                    checkMenu() 'check menu based on role

                    'log + season
                    Dim u As New ClassUser()
                    If u.logLogin("1") Then
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
                        FormMain.logOutCmd()
                    End If
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
End Class