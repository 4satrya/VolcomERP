Imports DevExpress.XtraEditors
Imports System
Imports System.Windows.Forms
Imports DevExpress.XtraPrinting
Imports System.Xml

Public Class FormMain
    Public connection_problem As Boolean = False
    Dim id_super_user As String = "0"

    Sub badgeVisible()
        If (RibbonControl.SelectedPage.ToString = "General" Or RibbonControl.SelectedPage.ToString = "") And Badge1.Properties.Text > "0" Then
            Badge1.Visible = True
        Else
            Badge1.Visible = False
        End If
    End Sub

    Private Sub RibbonControl_SelectedPageChanged(sender As Object, e As EventArgs) Handles RibbonControl.SelectedPageChanged
        badgeVisible()
    End Sub

    '--------------GENERAL FUNCTION--------------------------------
    Private Sub FormMain_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'here global setting
        'Dim arguments As String() = Environment.GetCommandLineArgs()
        'MsgBox("GetCommandLineArgs: " + arguments(1).ToString)

        My.Application.ChangeCulture("en-US")
        My.Application.Culture.NumberFormat.NumberDecimalSeparator = ","
        My.Application.Culture.NumberFormat.NumberGroupSeparator = "."
        WindowState = FormWindowState.Maximized
        Cursor = Cursors.WaitCursor

        ShowInTaskbar = False
        Visible = False
        Opacity = 0
        Badge1.Visible = False

        apply_skin()

        Try
            DashboardToolStripMenuItem.Visible = False
            read_database_configuration()
            check_connection(True, "", "", "", "")
            check_pic_location()
            If get_setup_field("auto_update") = "1" Then
                check_and_update_version()
            End If
            'show hide login
            'LoginToolStripMenuItem.Visible = True
        Catch ex As Exception
            connection_problem = True

            FormDatabase.TopMost = True
            FormDatabase.Show()
            FormDatabase.Focus()
            FormDatabase.TopMost = False

            LoginToolStripMenuItem.Visible = False
            DashboardToolStripMenuItem.Visible = False
        End Try

        'change connection shortkey & role superuser
        id_super_user = get_setup_field("id_role_super_admin")
        For Each ex As Control In Me.Controls
            AddHandler ex.KeyDown, AddressOf FormMain_KeyUp
        Next


        '
        NotifyIconVI.ShowBalloonTip(2000, "Information", "Volcom ERP is now running." + Environment.NewLine + "Right click at volcom icon for more option.", ToolTipIcon.Info)
        Cursor = Cursors.Default
    End Sub
    '----------- check version
    Sub check_and_update_version()
        Dim update_url As String = get_setup_field("update_address")
        Dim web As New Net.WebClient
        Dim LatestVersion As String = web.DownloadString(update_url & "version.txt") 'To download the Lastest Version from a specified URL.
        If Application.ProductVersion.ToString < LatestVersion Then
            infoCustom("New version of application is available! System will automatically update to new version.")
            My.Computer.Network.DownloadFile(update_url & "setup.exe", Application.StartupPath & "\setup.exe", "", "", True, 100, True)
            My.Computer.Network.DownloadFile(update_url & "SetupVolcomERP.msi", Application.StartupPath & "\SetupVolcomERP.msi", "", "", True, 100, True)
            infoCustom("File downloaded. Begin installing new version.")
            Process.Start(Application.StartupPath & "\setup.exe")
            Application.Exit()
        End If
    End Sub

    Sub checkChangePass()
        If is_change_pass_user = "2" Then
            infoCustom("Welcome to Volcom ERP System. Please setup your account first.")
            FormAccount.Text = "First Login Configuration"
            FormAccount.BtnCancel.Visible = False
            FormAccount.ShowDialog()
        End If
    End Sub
    '=========HIDE WHEN MINIMIZED
    Private Sub FormMain_Resize(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Resize
        If WindowState = FormWindowState.Minimized Then
            Me.Hide()
        End If
    End Sub

    '-----------------------CHANGE CONNECTION (Admin Only)
    Private Sub FormMain_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyUp

    End Sub

    '-----------------------Notification
    Private Sub TimerNotif_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TimerNotif.Tick
        ' Try
        Dim query_notif As String = "CALL view_notif_list('" + id_user + "', 'AND notif_det.is_read=2') "
            Dim data_notif As DataTable = execute_query(query_notif, -1, True, "", "", "", "")
            checkTotalNotif(data_notif.Rows.Count)
            For i As Integer = 0 To data_notif.Rows.Count - 1
                If data_notif.Rows(i)("id_type").ToString = "2" Then
                    showNotify(data_notif(i)("notif_title").ToString, data_notif(i)("notif_content").ToString, "2#" + data_notif(i)("notif_frm_to").ToString + "#" + data_notif(i)("id_notif_det").ToString + "#" + data_notif(i)("id_report").ToString + "#" + data_notif(i)("report_number").ToString + "#" + data_notif(i)("notif_tag").ToString)
                Else
                    showNotify(data_notif(i)("notif_title").ToString, data_notif(i)("notif_content").ToString, data_notif.Rows(i)("id_type").ToString)
                End If
            Next
        '  Catch ex As Exception
        'errorConnection()
        'End Try
    End Sub

    Sub checkNumberNotif()
        Dim query_notif As String = "SELECT get_number_notif('" + id_user + "', '3') AS jum"
        Dim data_notif As DataTable = execute_query(query_notif, -1, True, "", "", "", "")
        checkTotalNotif(data_notif.Rows(0)("jum"))
    End Sub

    Sub checkTotalNotif(ByVal n_par As Integer)
        If n_par <= 0 Then
            Badge1.Properties.Text = "0"
            Badge1.Visible = False
        Else
            If n_par > 99 Then
                Badge1.Properties.TextMargin = New Padding(3, 0, 0, 0)
            ElseIf n_par >= 10 And n_par <= 99 Then
                Badge1.Properties.TextMargin = New Padding(4, 0, 0, 0)
            Else
                Badge1.Properties.TextMargin = New Padding(6, 0, 0, 0)
            End If
            Badge1.Properties.Text = n_par.ToString
            badgeVisible()
        End If
    End Sub

    Private Sub AlertControlNotif_AlertClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.Alerter.AlertClickEventArgs) Handles AlertControlNotif.AlertClick
        Cursor = Cursors.WaitCursor
        If e.Info.Tag.ToString = "1" Then
            Try
                FormWork.MdiParent = Me
                FormWork.Show()
                FormWork.WindowState = FormWindowState.Maximized
                FormWork.Focus()
                FormWork.XTCGeneral.SelectedTabPageIndex = 0
                FormWork.view_mark_need()
            Catch ex As Exception
                errorProcess()
            End Try
        ElseIf e.Info.Tag.ToString = "2"
            Dim col_foc_str As String() = Split(e.Info.Tag.ToString, "#")
            Dim frm As String = col_foc_str(1)
            Dim id_notif_det As String = col_foc_str(2)
            Dim id_report As String = col_foc_str(3)
            Dim report_number As String = col_foc_str(4)
            Dim notif_tag As String = col_foc_str(5)
            frmNotif(frm, id_report, report_number, notif_tag)
        ElseIf e.Info.Tag.ToString = "3" Then
            Try
                FormFGDesignList.MdiParent = Me
                FormFGDesignList.id_pop_up = "1"
                FormFGDesignList.Show()
                FormFGDesignList.WindowState = FormWindowState.Maximized
                FormFGDesignList.Focus()
                FormFGDesignList.viewData()
            Catch ex As Exception
                errorProcess()
            End Try
        Else
            'no action
        End If
        Cursor = Cursors.Default
    End Sub

    'check pic location
    Sub check_pic_location()
        'picture location
        Dim err_pic As String = "-1"
        Try
            Dim pic_path_mat As String = get_setup_field("pic_path_mat")
            Dim pic_path_sample As String = get_setup_field("pic_path_sample")
            Dim pic_path_design As String = get_setup_field("pic_path_design")
            Dim pic_path_logo As String = get_setup_field("pic_path_logo")

            If pic_path_mat = "" Or pic_path_sample = "" Or pic_path_design = "" Or pic_path_logo = "" Then
                err_pic = "1"
            Else
                If Not System.IO.Directory.Exists(pic_path_sample) Or Not System.IO.Directory.Exists(pic_path_mat) Or Not System.IO.Directory.Exists(pic_path_design) Or Not System.IO.Directory.Exists(pic_path_logo) Then
                    err_pic = "1"
                Else
                    If Not System.IO.File.Exists(pic_path_mat & "\default.jpg") Or Not System.IO.File.Exists(pic_path_sample & "\default.jpg") Or Not System.IO.File.Exists(pic_path_design & "\default.jpg") Or Not System.IO.File.Exists(pic_path_logo & "\default.jpg") Then
                        err_pic = "2"
                    End If
                End If
            End If
        Catch ex As Exception
            'err_pic = "1"
            MsgBox(ex.ToString)
        End Try
        '
        If err_pic <> "-1" Then
            LoginToolStripMenuItem.Visible = False
            FormSetupPicLocation.TopMost = True
            FormSetupPicLocation.Show()
            FormSetupPicLocation.Focus()
            FormSetupPicLocation.TopMost = False
        Else
            LoginToolStripMenuItem.Visible = True
            DashboardToolStripMenuItem.Visible = False
            loadImgPath()
        End If
    End Sub
    'Show Ribbon
    Sub show_rb(ByVal formnamex As String)
        formName = formnamex
        RPSubMenu.Visible = True
        RibbonControl.SelectedPage = RPSubMenu

        If formName = "FormMasterCompany" Then
            BBContact.Visibility = DevExpress.XtraBars.BarItemVisibility.Always
        End If
        If formName = "FormAccess" Or formName = "FormMarkAssign" Then
            BBMapping.Visibility = DevExpress.XtraBars.BarItemVisibility.Always
        End If
        If formName = "FormAccess" Or formName = "FormMasterSample" Or formName = "FormFGDesignList" Then
            BBDuplicate.Visibility = DevExpress.XtraBars.BarItemVisibility.Always
        End If
        If formName = "FormMasterWH" Then
            If FormMasterWH.XTCWHMain.SelectedTabPageIndex = 0 Then
                BBNew.Visibility = DevExpress.XtraBars.BarItemVisibility.Always
                BBEdit.Visibility = DevExpress.XtraBars.BarItemVisibility.Always
                BBDelete.Visibility = DevExpress.XtraBars.BarItemVisibility.Always
                'BBSwitch.Visibility = DevExpress.XtraBars.BarItemVisibility.Never
            Else
                BBNew.Visibility = DevExpress.XtraBars.BarItemVisibility.Never
                BBEdit.Visibility = DevExpress.XtraBars.BarItemVisibility.Never
                BBDelete.Visibility = DevExpress.XtraBars.BarItemVisibility.Never
                'BBSwitch.Visibility = DevExpress.XtraBars.BarItemVisibility.Always
            End If
        End If

        If formName = "FormWork" Or formName = "FormAccountingFYear" Then
            BBNew.Visibility = DevExpress.XtraBars.BarItemVisibility.Never
            BBEdit.Visibility = DevExpress.XtraBars.BarItemVisibility.Never
            BBDelete.Visibility = DevExpress.XtraBars.BarItemVisibility.Never

            BBView.Visibility = DevExpress.XtraBars.BarItemVisibility.Always
        End If

        If formName = "FormAccountingSummary" Or formName = "FormMasterDesignCOP" Or formName = "FormSalesOrderList" Or formName = "FormSalesOrderSvcLevel" Or formName = "FormWHImportDO" Or formName = "FormWHSvcLevel" Then
            BBNew.Visibility = DevExpress.XtraBars.BarItemVisibility.Never
            BBEdit.Visibility = DevExpress.XtraBars.BarItemVisibility.Never
            BBDelete.Visibility = DevExpress.XtraBars.BarItemVisibility.Never
        End If

        If formName = "FormMatStockOpname" Then
            BBView.Visibility = DevExpress.XtraBars.BarItemVisibility.Always
        End If

        If formName = "FormFGStockOpnameStore" Or formName = "FormFGStockOpnameWH" Then
            BBView.Visibility = DevExpress.XtraBars.BarItemVisibility.Always
        End If

        If formName = "FormFGTrfReceive" Then
            BBNew.Visibility = DevExpress.XtraBars.BarItemVisibility.Never
            BBDelete.Visibility = DevExpress.XtraBars.BarItemVisibility.Never
        End If

        If formName = "FormProductionWOList" Or formName = "FormFGDistScheme" Or formName = "FormFGLineList" Or formName = "FormFGTracking" Or formName = "FormFGStock" Or formName = "FormMatStock" Or formName = "FormSalesWeekly" Or formName = "FormFGWoffList" Or formName = "FormFGDistSchemaSetup" Or formName = "FormFGProdList" Or formName = "FormSamplePLExport" Or formName = "FormFGWHAllocLog" Or formName = "FormEmpReview" Or formName = "FormProductionSummary" Then
            RGAreaManage.Visible = False
        End If

        If formName = "FormSampleStock" Then
            BBSwitch.Visibility = DevExpress.XtraBars.BarItemVisibility.Always
            BBNew.Visibility = DevExpress.XtraBars.BarItemVisibility.Never
            BBDelete.Visibility = DevExpress.XtraBars.BarItemVisibility.Never
            BBEdit.Visibility = DevExpress.XtraBars.BarItemVisibility.Never
            BBRefresh.Visibility = DevExpress.XtraBars.BarItemVisibility.Never
        End If

        If formName = "FormAccountingJournal" Then
            BBDelete.Visibility = DevExpress.XtraBars.BarItemVisibility.Never
            BBRefresh.Visibility = DevExpress.XtraBars.BarItemVisibility.Never
        End If

        If formName = "FormSOHSum" Then
            BBNew.Visibility = DevExpress.XtraBars.BarItemVisibility.Never
            BBEdit.Visibility = DevExpress.XtraBars.BarItemVisibility.Never
            BBDelete.Visibility = DevExpress.XtraBars.BarItemVisibility.Never

            BBRefresh.Visibility = DevExpress.XtraBars.BarItemVisibility.Never
            RGAreaManage.Visible = False
        End If
        If formName = "FormSOHPrice" Then
            BBNew.Visibility = DevExpress.XtraBars.BarItemVisibility.Never
            BBDelete.Visibility = DevExpress.XtraBars.BarItemVisibility.Never
        End If

        'edit only
        If formName = "FormMasterProduct" Then
            BBNew.Visibility = DevExpress.XtraBars.BarItemVisibility.Never
            BBDelete.Visibility = DevExpress.XtraBars.BarItemVisibility.Never
        End If

        If formName = "FormGuide" Then
            RGAreaManage.Visible = False
            RGAreaPrint.Visible = False
        End If

        If formName = "FormNotification" Then
            BBNew.Visibility = DevExpress.XtraBars.BarItemVisibility.Never
            BBEdit.Visibility = DevExpress.XtraBars.BarItemVisibility.Never
            BBDelete.Visibility = DevExpress.XtraBars.BarItemVisibility.Never
            RGAreaPrint.Visible = False
        End If

        If formName = "FormEmpLeave" Then
            BBDelete.Visibility = DevExpress.XtraBars.BarItemVisibility.Never
        End If
        ''mapping COA
        'If formName = "FormSamplePurchase" _
        'Or formName = "FormSampleReceive" _
        'Or formName = "FormSampleAdjustment" _
        'Or formName = "FormMatPurchase" _
        'Or formName = "FormMatRecPurc" _
        'Or formName = "FormMatWO" _
        'Or formName = "FormMatRecWO" _
        'Or formName = "FormMatRet" _
        'Or formName = "FormMatAdj" _
        'Or formName = "FormMatPL" _
        'Then
        '    BBMappingCOA.Visibility = DevExpress.XtraBars.BarItemVisibility.Always
        'End If

        'hide all except print n close
        If formName = "FormBarcodeProduct" Then
            RGAreaManage.Visible = False
        End If
    End Sub
    'Hide Ribbon
    Sub hide_rb()
        RPSubMenu.Visible = False

        If formName = "FormMasterCompany" Then
            BBContact.Visibility = DevExpress.XtraBars.BarItemVisibility.Never
        End If
        If formName = "FormAccess" Or formName = "FormMarkAssign" Then
            BBMapping.Visibility = DevExpress.XtraBars.BarItemVisibility.Never
        End If
        If formName = "FormAccess" Or formName = "FormMasterSample" Or formName = "FormFGDesignList" Then
            BBDuplicate.Visibility = DevExpress.XtraBars.BarItemVisibility.Never
        End If

        If formName = "FormMasterWH" Or formName = "FormMasterDesignCOP" Then
            BBNew.Visibility = DevExpress.XtraBars.BarItemVisibility.Always
            BBEdit.Visibility = DevExpress.XtraBars.BarItemVisibility.Always
            BBDelete.Visibility = DevExpress.XtraBars.BarItemVisibility.Always
            'BBSwitch.Visibility = DevExpress.XtraBars.BarItemVisibility.Never
        End If

        If formName = "FormWork" Or formName = "FormAccountingFYear" Then
            BBNew.Visibility = DevExpress.XtraBars.BarItemVisibility.Always
            BBEdit.Visibility = DevExpress.XtraBars.BarItemVisibility.Always
            BBDelete.Visibility = DevExpress.XtraBars.BarItemVisibility.Always

            BBView.Visibility = DevExpress.XtraBars.BarItemVisibility.Never
        End If

        If formName = "FormAccountingSummary" Or formName = "FormSalesOrderList" Or formName = "FormSalesOrderSvcLevel" Or formName = "FormWHImportDO" Or formName = "FormWHSvcLevel" Then
            BBNew.Visibility = DevExpress.XtraBars.BarItemVisibility.Always
            BBEdit.Visibility = DevExpress.XtraBars.BarItemVisibility.Always
            BBDelete.Visibility = DevExpress.XtraBars.BarItemVisibility.Always
        End If

        If formName = "FormMatStockOpname" Then
            BBView.Visibility = DevExpress.XtraBars.BarItemVisibility.Never
        End If
        If formName = "FormFGStockOpnameStore" Or formName = "FormFGStockOpnameWH" Then
            BBView.Visibility = DevExpress.XtraBars.BarItemVisibility.Never
        End If

        If formName = "FormFGTrfReceive" Then
            BBNew.Visibility = DevExpress.XtraBars.BarItemVisibility.Always
            BBDelete.Visibility = DevExpress.XtraBars.BarItemVisibility.Always
        End If

        If formName = "FormProductionWOList" Or formName = "FormFGDistScheme" Or formName = "FormFGLineList" Or formName = "FormFGTracking" Or formName = "FormFGStock" Or formName = "FormMatStock" Or formName = "FormSalesWeekly" Or formName = "FormFGWoffList" Or formName = "FormFGDistSchemaSetup" Or formName = "FormFGProdList" Or formName = "FormSamplePLExport" Or formName = "FormFGWHAllocLog" Or formName = "FormEmpReview" Or formName = "FormProductionSummary" Then
            RGAreaManage.Visible = True
        End If

        If formName = "FormSampleStock" Then
            BBSwitch.Visibility = DevExpress.XtraBars.BarItemVisibility.Never
            BBNew.Visibility = DevExpress.XtraBars.BarItemVisibility.Always
            BBDelete.Visibility = DevExpress.XtraBars.BarItemVisibility.Always
            BBEdit.Visibility = DevExpress.XtraBars.BarItemVisibility.Always
            BBRefresh.Visibility = DevExpress.XtraBars.BarItemVisibility.Always
        End If

        If formName = "FormAccountingJournal" Then
            BBDelete.Visibility = DevExpress.XtraBars.BarItemVisibility.Always
            BBRefresh.Visibility = DevExpress.XtraBars.BarItemVisibility.Always
        End If

        If formName = "FormSOHSum" Then
            BBNew.Visibility = DevExpress.XtraBars.BarItemVisibility.Always
            BBEdit.Visibility = DevExpress.XtraBars.BarItemVisibility.Always
            BBDelete.Visibility = DevExpress.XtraBars.BarItemVisibility.Always

            BBRefresh.Visibility = DevExpress.XtraBars.BarItemVisibility.Always
            RGAreaManage.Visible = True
        End If
        If formName = "FormSOHPrice" Then
            BBNew.Visibility = DevExpress.XtraBars.BarItemVisibility.Always
            BBDelete.Visibility = DevExpress.XtraBars.BarItemVisibility.Always
        End If

        'edit only
        If formName = "FormMasterProduct" Then
            BBNew.Visibility = DevExpress.XtraBars.BarItemVisibility.Always
            BBDelete.Visibility = DevExpress.XtraBars.BarItemVisibility.Always
        End If


        If formName = "FormGuide" Then
            RGAreaManage.Visible = True
            RGAreaPrint.Visible = True
        End If

        If formName = "FormNotification" Then
            BBNew.Visibility = DevExpress.XtraBars.BarItemVisibility.Always
            BBEdit.Visibility = DevExpress.XtraBars.BarItemVisibility.Always
            BBDelete.Visibility = DevExpress.XtraBars.BarItemVisibility.Always
            RGAreaPrint.Visible = True
        End If

        If formName = "FormEmpLeave" Then
            BBDelete.Visibility = DevExpress.XtraBars.BarItemVisibility.Always
        End If
        ''mapping COA
        'If formName = "FormSamplePurchase" _
        'Or formName = "FormSampleReceive" _
        'Or formName = "FormSampleAdjustment" _
        'Or formName = "FormMatPurchase" _
        'Or formName = "FormMatRecPurc" _
        'Or formName = "FormMatWO" _
        'Or formName = "FormMatRecWO" _
        'Or formName = "FormMatRet" _
        'Or formName = "FormMatAdj" _
        'Or formName = "FormMatPL" _
        'Then
        '    BBMappingCOA.Visibility = DevExpress.XtraBars.BarItemVisibility.Never
        'End If

        'hide all excep print n close
        If formName = "FormBarcodeProduct" Then
            RGAreaManage.Visible = True
        End If

        formName = ""

        'set 0 progress bar
        BEProgress.EditValue = 0
    End Sub
    '-------------STRIP MENU -------------------------------
    'Exit Strip
    Private Sub ExitToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExitToolStripMenuItem.Click
        NotifyIconVI.Visible = False
        Application.Exit()
    End Sub
    'Dashboard Strip
    Private Sub DashboardToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DashboardToolStripMenuItem.Click
        Show()
        WindowState = FormWindowState.Maximized
        BringToFront()
        Activate()
        'For Eac h openForm In Application.OpenForms()
        '    openForm.BringToFront()
        'Next
        Focus()
    End Sub
    'Login Strip
    Private Sub LoginToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LoginToolStripMenuItem.Click
        FormLogin.Show()
    End Sub
    'Logout Strip
    Sub logOut()
        Dim confirm As DialogResult = XtraMessageBox.Show("Are you sure to logout this system?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
        If confirm = Windows.Forms.DialogResult.Yes Then
            logOutCmd()
        End If
    End Sub

    Sub logOutCmd()
        Try
            TESearchNavbar.Text = Nothing
            'close all form
            For Each frm In MdiChildren
                If frm.Name <> "FormMain" Then
                    frm.Close()
                End If
            Next

            'log
            Dim u As New ClassUser()
            u.logLogin("2")

            id_user = Nothing
            id_role_login = Nothing
            username_user = Nothing
            name_user = Nothing
            is_change_pass_user = Nothing
            restartMenu()
            DashboardToolStripMenuItem.Visible = False
            LogoutToolStripMenuItem.Visible = False
            LoginToolStripMenuItem.Visible = True
            ShowInTaskbar = False
            Visible = False
            TimerNotif.Enabled = False
            Badge1.Visible = False
            Opacity = 0


            'close all notif
            Dim array = AlertControlNotif.AlertFormList.ToArray()
            If array.Count() > 0 Then
                For i As Integer = 0 To array.Count() - 1
                    array(i).Close()
                Next
            End If
            NotifyIconVI.ShowBalloonTip(2000, "Information", "You're already logout from system." + Environment.NewLine + "Right click here for more option.", ToolTipIcon.Info)
        Catch ex As Exception
            errorProcess()
        End Try
    End Sub

    Private Sub LogoutToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LogoutToolStripMenuItem.Click
        Show()
        WindowState = FormWindowState.Maximized
        logOut()
    End Sub
    Private Sub BBLogout_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles BBLogout.ItemClick
        logOut()
    End Sub
    '---------------SUBMENU (ADD/EDIT/DELETE)---------------------------------
    'New Data
    Private Sub BBNew_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles BBNew.ItemClick
        Cursor = Cursors.WaitCursor
        If formName = "FormMasterArea" Then
            'AREA
            If FormMasterArea.XTCArea.SelectedTabPageIndex = 0 Then
                'country
                FormMasterCountrySingle.id_country = "-1"
                FormMasterCountrySingle.ShowDialog()
            ElseIf FormMasterArea.XTCArea.SelectedTabPageIndex = 1 Then
                'state
                FormMasterRegionSingle.id_region = "-1"
                FormMasterRegionSingle.id_country = FormMasterArea.GVCountry.GetFocusedRowCellDisplayText("id_country").ToString
                FormMasterRegionSingle.ShowDialog()
            ElseIf FormMasterArea.XTCArea.SelectedTabPageIndex = 2 Then
                'state
                FormMasterStateSingle.id_state = "-1"
                FormMasterStateSingle.id_region = FormMasterArea.GVRegion.GetFocusedRowCellDisplayText("id_region").ToString
                FormMasterStateSingle.ShowDialog()
            Else
                'city
                FormMasterCitySingle.id_city = "-1"
                FormMasterCitySingle.id_state = FormMasterArea.GVState.GetFocusedRowCellDisplayText("id_state").ToString
                FormMasterCitySingle.ShowDialog()
            End If
        ElseIf formName = "FormMasterCompany" Then
            'COMPANY
            FormMasterCompanySingle.id_company = "-1"
            FormMasterCompanySingle.ShowDialog()
        ElseIf formName = "FormMasterCompanyCategory" Then
            'COMPANY CATEGORY
            FormMasterCompanyCategorySingle.id_company_category = "-1"
            FormMasterCompanyCategorySingle.ShowDialog()
        ElseIf formName = "FormMasterDepartement" Then
            'DEPARTMENT
            FormMasterDepartementSingle.id_departement = "-1"
            FormMasterDepartementSingle.ShowDialog()
        ElseIf formName = "FormMasterRawMaterialCat" Then
            'OLD MATERIAL CATEGORY
            FormMasterRawMaterialCatSingle.action = "ins"
            FormMasterRawMaterialCatSingle.ShowDialog()
        ElseIf formName = "FormMasterItemColor" Then
            'OLD ITEM COLOR
            FormMasterItemColorSingle.action = "ins"
            FormMasterItemColorSingle.ShowDialog()
        ElseIf formName = "FormMasterItemSize" Then
            'OLD ITEM SIZE
            FormMasterItemSizeSingle.action = "ins"
            FormMasterItemSizeSingle.ShowDialog()
        ElseIf formName = "FormMasterUser" Then
            'USER
            FormMasterUserSingle.id_user = "-1"
            FormMasterUserSingle.ShowDialog()
        ElseIf formName = "FormAccess" Then
            'ACCESS
            If FormAccess.XTCMenuManage.SelectedTabPageIndex = 2 Then 'new role
                FormAccessRoleSingle.action = "ins"
                FormAccessRoleSingle.LabelRole.Text = "Add New Role"
                FormAccessRoleSingle.ShowDialog()
            ElseIf FormAccess.XTCMenuManage.SelectedTabPageIndex = 1 Then 'new menu
                FormAccessMenuSingle.action = "ins"
                FormAccessMenuSingle.ShowDialog()
            ElseIf FormAccess.XTCMenuManage.SelectedTabPageIndex = 0 Then 'new form
                If FormAccess.XTCForm.SelectedTabPageIndex = 0 Then 'new Form
                    FormAccessFrmSingle.action = "ins"
                    FormAccessFrmSingle.ShowDialog()
                ElseIf FormAccess.XTCForm.SelectedTabPageIndex = 1 Then 'new form control
                    FormAccessProcessSingle.action = "ins"
                    FormAccessProcessSingle.id_form = FormAccess.GVForm.GetFocusedRowCellDisplayText("id_form").ToString()
                    FormAccessProcessSingle.is_required = False
                    FormAccessProcessSingle.LabelTitle.Text = FormAccess.GVForm.GetFocusedRowCellDisplayText("form_name").ToString
                    FormAccessProcessSingle.ShowDialog()
                End If
            End If
        ElseIf formName = "FormSeason" Then
            'SEASON
            If FormSeason.XTCMainSeason.SelectedTabPageIndex = 0 Then 'Internal Season
                If FormSeason.XTCSeason.SelectedTabPageIndex = 0 Then
                    'new range
                    FormRangeSingle.action = "ins"
                    FormRangeSingle.ShowDialog()
                ElseIf FormSeason.XTCSeason.SelectedTabPageIndex = 1 Then
                    'new season
                    FormSeasonSingle.action = "ins"
                    FormSeasonSingle.ShowDialog()
                ElseIf FormSeason.XTCSeason.SelectedTabPageIndex = 2 Then
                    'new delivery
                    FormDeliverySingle.action = "ins"
                    FormDeliverySingle.GCtrlDelivery.Text = "Range " + FormSeason.range_season.ToString + " - Season " + FormSeason.season.ToString
                    FormDeliverySingle.ShowDialog()
                End If
            Else 'Origin Season
                FormSeasonorignSingle.action = "ins"
                FormSeasonorignSingle.ShowDialog()
            End If
        ElseIf formName = "FormMasterUOM" Then
            'UOM
            FormMasterUOM.PCUOM.Visible = True
            FormMasterUOM.TxtUOM.Text = ""
            FormMasterUOM.ErrorProviderUom.SetError(FormMasterUOM.TxtUOM, "")
            FormMasterUOM.action = "ins"
        ElseIf formName = "FormMasterRawMat" Then
            'OLD RAW MATERIAL
            If FormMasterRawMat.XTCRawMat.SelectedTabPageIndex = 0 Then 'new raw mat old
                FormMasterRawMatSingle.action = "ins"
                FormMasterRawMatSingle.ShowDialog()
            ElseIf FormMasterRawMat.XTCRawMat.SelectedTabPageIndex = 1 Then 'new raw mat lot old
                FormMasterRawMatLotSingle.action = "ins"
                FormMasterRawMatLotSingle.loadku = 0
                FormMasterRawMatLotSingle.ShowDialog()
            ElseIf FormMasterRawMat.XTCRawMat.SelectedTabPageIndex = 2 Then 'new raw mat supplier old
                FormMasterRawMatSupplierSingle.action = "ins"
                FormMasterRawMatSupplierSingle.id_raw_mat_detail = FormMasterRawMat.GVLot.GetFocusedRowCellDisplayText("id_raw_mat_detail").ToString
                FormMasterRawMatSupplierSingle.ShowDialog()
            End If
        ElseIf formName = "FormSetupRawMatCode" Then
            'OLD CODE
            FormSetupRawMatCodeSingle.action = "ins"
            FormSetupRawMatCodeSingle.ShowDialog()
        ElseIf formName = "FormMasterRawMaterial" Then
            'NEW MASTER RAW MATERIAL
            If FormMasterRawMaterial.XTCMaterialType.SelectedTabPageIndex = 0 Then 'new raw material
                FormMasterRawMaterialSingle.action = "ins"
                FormMasterRawMaterialSingle.ShowDialog()
            ElseIf FormMasterRawMaterial.XTCMaterialType.SelectedTabPageIndex = 1 Then 'new raw material detail
                FormMasterRawMaterialDetSingle.action = "ins"

                FormMasterRawMaterialDetSingle.id_mat = FormMasterRawMaterial.GVRawMat.GetFocusedRowCellValue("id_mat").ToString
                FormMasterRawMaterialDetSingle.LabelPrintedName.Text = FormMasterRawMaterial.GVRawMat.GetFocusedRowCellDisplayText("mat_display_name").ToString
                FormMasterRawMaterialDetSingle.TxtMaterialTypeCode.Text = FormMasterRawMaterial.GVRawMat.GetFocusedRowCellDisplayText("mat_code").ToString

                FormMasterRawMaterialDetSingle.ShowDialog()
            End If
        ElseIf formName = "FormMasterOVH" Then
            'OVH
            FormMasterOVHSingle.id_ovh = "-1"
            FormMasterOVHSingle.ShowDialog()
        ElseIf formName = "FormProdDemand" Then
            'PRODUCTION DEMAND
            FormProdDemandSingle.action = "ins"
            FormProdDemandSingle.id_report_status = "-1"
            FormProdDemandSingle.ShowDialog()
        ElseIf formName = "FormMasterCode" Then
            'MASTER CODE
            If FormMasterCode.XTCCode.SelectedTabPageIndex = 0 Then
                'code
                FormMasterCodeSingle.id_code = "-1"
                FormMasterCodeSingle.ShowDialog()
            ElseIf FormMasterCode.XTCCode.SelectedTabPageIndex = 1 Then
                'code detail
                FormMasterCodeDetSingle.id_code_det = "-1"
                FormMasterCodeDetSingle.id_code = FormMasterCode.GVCode.GetFocusedRowCellDisplayText("id_code").ToString
                FormMasterCodeDetSingle.ShowDialog()
            End If
        ElseIf formName = "FormTemplateCode" Then
            'MASTER CODE TEMPLATE
            If FormTemplateCode.XTCTemplateCode.SelectedTabPageIndex = 0 Then
                'code
                FormTemplateCodeSingle.id_template_code = "-1"
                FormTemplateCodeSingle.ShowDialog()
            End If
        ElseIf formName = "FormMasterSample" Then
            'MASTER SAMPLE
            FormMasterSampleDet.id_sample = "-1"
            FormMasterSampleDet.ShowDialog()
        ElseIf formName = "FormMasterProduct" Then
            'MASTER PRODUCT
            If FormMasterProduct.XTCProduct.SelectedTabPageIndex = 0 Then
                'design
                FormMasterDesignSingle.id_design = "-1"
                FormMasterDesignSingle.ShowDialog()
            ElseIf FormMasterProduct.XTCProduct.SelectedTabPageIndex = 1 Then
                'product
                FormMasterProductDet.id_product = "-1"
                FormMasterProductDet.id_design = FormMasterProduct.GVDesign.GetFocusedRowCellDisplayText("id_design").ToString
                FormMasterProductDet.ShowDialog()
            End If
        ElseIf formName = "FormBOM" Then
            'BOM
            If FormBOM.XTCBOMSelection.SelectedTabPageIndex = 0 Then
                'Try
                FormBOMDesignSingle.id_pop_up = "-1"
                FormBOMDesignSingle.id_design = FormBOM.GVDesign.GetFocusedRowCellValue("id_design").ToString
                FormBOMDesignSingle.TEQtyPD.EditValue = FormBOM.GVDesign.GetFocusedRowCellValue("qty")
                'FormBOMDesignSingle.id_prod_demand_design = FormBOM.GVDesign.GetFocusedRowCellValue("id_prod_demand_design").ToString
                FormBOMDesignSingle.ShowDialog()
                'Catch ex As Exception
                'stopCustom("Please try again later.")
                'End Try
            ElseIf FormBOM.XTCBOMSelection.SelectedTabPageIndex = 1 Then
                FormBOMSingle.id_bom = "-1"
                FormBOMSingle.id_product = FormBOM.GVProduct.GetFocusedRowCellDisplayText("id_product").ToString
                FormBOMSingle.ShowDialog()
            ElseIf FormBOM.XTCBOMSelection.SelectedTabPageIndex = 2 Then
                Try
                    FormBOMSingle.id_pop_up = "1"
                    FormBOMSingle.id_bom_approve = "-1"
                    FormBOMSingle.id_design = FormBOM.GVPerDesign.GetFocusedRowCellDisplayText("id_design").ToString
                    FormBOMSingle.ShowDialog()
                Catch ex As Exception
                    stopCustom("Please try again later.")
                End Try
            End If
        ElseIf formName = "FormSamplePL" Then
            'PACKING LIST SAMPLE
            FormSamplePLSingle.action = "ins"
            FormSamplePLSingle.id_pl_sample_purc = "-1"
            FormSamplePLSingle.id_comp_contact_to = "-1"
            FormSamplePLSingle.id_comp_contact_from = "-1"
            FormSamplePLSingle.id_sample_purc = "-1"
            FormSamplePLSingle.ShowDialog()
        ElseIf formName = "FormSamplePurchase" Then
            'purchase sample
            If FormSamplePurchase.XTCTabReceive.SelectedTabPageIndex = 0 Then
                'normal
                FormSamplePurchaseDet.id_sample_purc = "-1"
                FormSamplePurchaseDet.ShowDialog()
            Else
                'from planning
                FormSamplePurchaseDet.id_sample_plan = FormSamplePurchase.GVSamplePlan.GetFocusedRowCellDisplayText("id_sample_plan").ToString
                FormSamplePurchaseDet.id_sample_purc = "-1"
                FormSamplePurchaseDet.ShowDialog()
            End If
        ElseIf formName = "FormSampleReceive" Then
            'receive sample
            If FormSampleReceive.XTCTabReceive.SelectedTabPageIndex = 0 Then
                FormSampleReceiveDet.id_receive = "-1"
                FormSampleReceiveDet.ShowDialog()
            Else
                FormSampleReceiveDet.id_receive = "-1"
                FormSampleReceiveDet.id_order = FormSampleReceive.GVSamplePurchaseNeed.GetFocusedRowCellDisplayText("id_sample_purc").ToString
                FormSampleReceiveDet.ShowDialog()
            End If
        ElseIf formName = "FormSamplePR" Then
            'Payment Request Sample
            If FormSamplePR.XTCTabPR.SelectedTabPageIndex = 0 Then
                FormSamplePRDet.id_pr = "-1"
                FormSamplePRDet.ShowDialog()
            ElseIf FormSamplePR.XTCTabPR.SelectedTabPageIndex = 1 Then
                FormSamplePRDet.id_pr = "-1"
                FormSamplePRDet.id_purc = FormSamplePR.GVSamplePurchaseNeed.GetFocusedRowCellDisplayText("id_sample_purc").ToString
                FormSamplePRDet.ShowDialog()
            ElseIf FormSamplePR.XTCTabPR.SelectedTabPageIndex = 2 Then
                FormSamplePRDet.id_pr = "-1"
                FormSamplePRDet.id_rec = FormSamplePR.GVMatReceive.GetFocusedRowCellDisplayText("id_sample_purc_rec").ToString
                FormSamplePRDet.ShowDialog()
            End If
        ElseIf formName = "FormMasterWH" Then
            'WH & LOCATOR
            If FormMasterWH.XTCWH.SelectedTabPageIndex = 1 Then 'Locator
                FormMasterWHSingle.id_wh_locator = FormMasterWH.GVLocator.GetFocusedRowCellDisplayText("id_wh_locator").ToString
                FormMasterWHSingle.action = "ins"
                FormMasterWHSingle.ShowDialog()
            ElseIf FormMasterWH.XTCWH.SelectedTabPageIndex = 2 Then 'Rack
                FormMasterWHRackSingle.id_wh_rack = FormMasterWH.GVRack.GetFocusedRowCellDisplayText("id_wh_rack").ToString
                FormMasterWHRackSingle.action = "ins"
                FormMasterWHRackSingle.ShowDialog()
            ElseIf FormMasterWH.XTCWH.SelectedTabPageIndex = 3 Then 'Drawer
                FormMasterWHDrawerSingle.id_wh_drawer = FormMasterWH.GVDrawer.GetFocusedRowCellDisplayText("id_wh_drawer").ToString
                FormMasterWHDrawerSingle.action = "ins"
                FormMasterWHDrawerSingle.ShowDialog()
            End If
        ElseIf formName = "FormSampleReceipt" Then
            'RECEIPT SAMPLE
            FormSampleReceiptSingle.action = "ins"
            FormSampleReceiptSingle.id_receipt_sample = "-1"
            FormSampleReceiptSingle.id_comp_contact_to = "-1"
            FormSampleReceiptSingle.id_comp_contact_from = "-1"
            FormSampleReceiptSingle.id_pl_sample_purc = "-1"
            FormSampleReceiptSingle.ShowDialog()
        ElseIf formName = "FormSampleRet" Then
            'RETURN SAMPLE
            If FormSampleRet.XTCReturn.SelectedTabPageIndex = 0 Then 'returnOut
                FormSampleRetOutSingle.action = "ins"
                FormSampleRetOutSingle.ShowDialog()
            ElseIf FormSampleRet.XTCReturn.SelectedTabPageIndex = 1 Then 'Return In
                FormSampleRetInSingle.action = "ins"
                FormSampleRetInSingle.ShowDialog()
            End If
        ElseIf formName = "FormSamplePLDel" Then
            'PACKING LIST DELIVERY SAMPLE
            If FormSamplePLDel.XTCPL.SelectedTabPageIndex = 0 Then 'based on PL
                FormSamplePLDelSingle.id_comp_from = get_company_from(id_user)
                FormSamplePLDelSingle.action = "ins"
                FormSamplePLDelSingle.id_comp_contact_to = "-1"
                FormSamplePLDelSingle.id_comp_contact_from = "-1"
                FormSamplePLDelSingle.ShowDialog()
            ElseIf FormSamplePLDel.XTCPL.SelectedTabPageIndex = 1 Then 'based on SRS
                FormSamplePLDelSingle.id_comp_from = get_company_from(id_user)
                FormSamplePLDelSingle.id_comp_to = FormSamplePLDel.GVReq.GetFocusedRowCellValue("id_comp_to").ToString
                FormSamplePLDelSingle.SPDuration.Text = FormSamplePLDel.GVReq.GetFocusedRowCellValue("sample_requisition_duration").ToString
                FormSamplePLDelSingle.BtnPopSRS.Enabled = False
                FormSamplePLDelSingle.id_sample_requisition = FormSamplePLDel.GVReq.GetFocusedRowCellDisplayText("id_sample_requisition").ToString
                FormSamplePLDelSingle.TEDivision.Text = FormSamplePLDel.GVReq.GetFocusedRowCellDisplayText("division").ToString
                FormSamplePLDelSingle.TxtSRSNumber.Text = FormSamplePLDel.GVReq.GetFocusedRowCellDisplayText("sample_requisition_number").ToString
                FormSamplePLDelSingle.action = "ins"
                FormSamplePLDelSingle.id_comp_contact_to = "-1"
                FormSamplePLDelSingle.id_comp_contact_from = "-1"
                FormSamplePLDelSingle.ShowDialog()
            End If
        ElseIf formName = "FormSampleReq" Then
            'SAMPLE REQUISITION 
            FormSampleReqSingle.action = "ins"
            FormSampleReqSingle.id_comp_contact_to = "-1"
            FormSampleReqSingle.id_comp_contact_from = "-1"
            FormSampleReqSingle.ShowDialog()
        ElseIf formName = "FormMarkAssign" Then
            'Assign for mark
            FormMarkAssignSingle.id_mark_asg = "-1"
            FormMarkAssignSingle.ShowDialog()
        ElseIf formName = "FormSamplePlan" Then
            'Sample Planning
            FormSamplePlanDet.id_sample_plan = "-1"
            FormSamplePlanDet.ShowDialog()
        ElseIf formName = "FormMatPurchase" Then
            'Material Purchase
            FormMatPurchaseDet.id_purc = "-1"
            FormMatPurchaseDet.ShowDialog()
        ElseIf formName = "FormSampleReturn" Then
            'SAMPLE RETURN
            If FormSampleReturn.XTCReturn.SelectedTabPageIndex = 0 Then
                FormSampleReturnSingle.id_comp_to = get_company_from(id_user)
                FormSampleReturnSingle.action = "ins"
                FormSampleReturnSingle.id_comp_contact_to = "-1"
                FormSampleReturnSingle.id_comp_contact_from = "-1"
                FormSampleReturnSingle.ShowDialog()
            ElseIf FormSampleReturn.XTCReturn.SelectedTabPageIndex = 1 Then
                FormSampleReturnSingle.id_comp_to = get_company_from(id_user)
                FormSampleReturnSingle.id_pl_sample_del = FormSampleReturn.GVPL.GetFocusedRowCellDisplayText("id_pl_sample_del").ToString
                FormSampleReturnSingle.id_comp_contact_from = FormSampleReturn.GVPL.GetFocusedRowCellDisplayText("id_comp_contact_to").ToString
                FormSampleReturnSingle.TxtCodeUserFrom.Text = FormSampleReturn.GVPL.GetFocusedRowCellValue("employee_code").ToString
                FormSampleReturnSingle.TxtNameUserFrom.Text = FormSampleReturn.GVPL.GetFocusedRowCellValue("employee_name").ToString
                FormSampleReturnSingle.TxtCodeDeptFrom.Text = FormSampleReturn.GVPL.GetFocusedRowCellValue("departement_code").ToString
                FormSampleReturnSingle.TxtNameDeptFrom.Text = FormSampleReturn.GVPL.GetFocusedRowCellValue("departement").ToString
                FormSampleReturnSingle.TxtCodeCompFrom.Text = FormSampleReturn.GVPL.GetFocusedRowCellValue("comp_code_to").ToString
                FormSampleReturnSingle.TxtNameCompFrom.Text = FormSampleReturn.GVPL.GetFocusedRowCellValue("comp_name_to").ToString
                FormSampleReturnSingle.TEDivision.Text = FormSampleReturn.GVPL.GetFocusedRowCellValue("division").ToString
                FormSampleReturnSingle.TxtPLSampleDelNumber.Text = FormSampleReturn.GVPL.GetFocusedRowCellValue("pl_sample_del_number").ToString
                FormSampleReturnSingle.BtnInfoPL.Enabled = True
                FormSampleReturnSingle.BtnPopPLDel.Enabled = False

                FormSampleReturnSingle.action = "ins"
                FormSampleReturnSingle.ShowDialog()
            End If
        ElseIf formName = "FormMatWO" Then
            'Material Purchase
            FormMatWODet.id_purc = "-1"
            FormMatWODet.ShowDialog()
        ElseIf formName = "FormMatRecPurc" Then
            'Material Purchase Receive
            If FormMatRecPurc.XTCTabReceive.SelectedTabPageIndex = 0 Then 'based on Rec
                FormMatRecPurcDet.id_order = "-1"
                FormMatRecPurcDet.ShowDialog()
            Else 'based on PO
                FormMatRecPurcDet.id_order = FormMatRecPurc.GVMatPurchase.GetFocusedRowCellValue("id_mat_purc").ToString
                FormMatRecPurcDet.ShowDialog()
            End If
        ElseIf formName = "FormMatRecWO" Then
            'Material WO Receive
            If FormMatRecWO.XTCTabReceive.SelectedTabPageIndex = 0 Then 'based on Rec
                FormMatRecWODet.id_order = "-1"
                FormMatRecWODet.ShowDialog()
            Else 'based on WO
                FormMatRecWODet.id_order = FormMatRecWO.GVMatWO.GetFocusedRowCellValue("id_mat_wo").ToString
                FormMatRecWODet.ShowDialog()
            End If
        ElseIf formName = "FormMatRet" Then
            'Material Return
            If FormMatRet.XTCReturnMat.SelectedTabPageIndex = 0 Then 'purchase
                If FormMatRet.XTCReturnPruchase.SelectedTabPageIndex = 0 Then 'ret out
                    FormMatRetOutDet.action = "ins"
                    FormMatRetOutDet.id_mat_purc_ret_out = "-1"
                    FormMatRetOutDet.ShowDialog()
                Else 'ret in
                    FormMatRetInDet.action = "ins"
                    FormMatRetInDet.id_mat_purc_ret_in = "-1"
                    FormMatRetInDet.ShowDialog()
                End If
            Else 'production
                If FormMatRet.XTCReturnProd.SelectedTabPageIndex = 0 Then 'ret in
                    FormMatRetInProd.action = "ins"
                    FormMatRetInProd.id_mat_prod_ret_in = "-1"
                    FormMatRetInProd.ShowDialog()
                End If
            End If
        ElseIf formName = "FormProduction" Then
            'Production
            If FormProduction.XTCTabProduction.SelectedTabPageIndex = 0 Then 'prod order
                FormProductionDet.id_prod_order = "-1"
                FormProductionDet.ShowDialog()
            Else 'prod demand design
                Dim query_check As String = "SELECT COUNT(id_prod_order) FROM tb_prod_order pro LEFT JOIN tb_prod_demand_design pd_desg ON pd_desg.id_prod_demand_design=pro.id_prod_demand_design "
                query_check += " WHERE pro.id_report_status!=5 AND pd_desg.id_design='" & FormProduction.GVDesign.GetFocusedRowCellValue("id_design").ToString & "'"
                Dim jml_po As String = execute_query(query_check, 0, True, "", "", "", "")

                If jml_po = "0" Then
                    FormProductionDet.id_prod_demand_design = FormProduction.GVDesign.GetFocusedRowCellValue("id_prod_demand_design").ToString
                    FormProductionDet.is_pd_base = "1"
                    FormProductionDet.ShowDialog()
                Else
                    stopCustom("PO with this design already created, please cancel it first.")
                End If
            End If
        ElseIf formName = "FormMatPL" Then
            If FormMatPL.XTCPL.SelectedTabPageIndex = 0 Then 'Production
                If FormMatPL.XTCTabProduction.SelectedTabPageIndex = 0 Then 'list PL
                    FormMatPLSingle.action = "ins"
                    FormMatPLSingle.id_comp_from = get_company_from(id_user)
                    FormMatPLSingle.id_comp_contact_to = "-1"
                    FormMatPLSingle.id_comp_contact_from = "-1"
                    FormMatPLSingle.ShowDialog()
                Else 'from MRS
                    FormMatPLSingle.action = "ins"
                    FormMatPLSingle.id_comp_from = get_company_from(id_user)
                    FormMatPLSingle.id_comp_contact_to = FormMatPL.GVMRS.GetFocusedRowCellValue("id_comp_name_req_from").ToString
                    FormMatPLSingle.BtnPopSRS.Enabled = False
                    FormMatPLSingle.id_mrs = FormMatPL.GVMRS.GetFocusedRowCellDisplayText("id_prod_order_mrs").ToString
                    FormMatPLSingle.TxtSRSNumber.Text = FormMatPL.GVMRS.GetFocusedRowCellDisplayText("prod_order_mrs_number").ToString
                    FormMatPLSingle.id_comp_contact_from = "-1"
                    FormMatPLSingle.ShowDialog()
                End If
            ElseIf FormMatPL.XTCPL.SelectedTabPageIndex = 1 Then 'WO
                If FormMatPL.XTCPLWO.SelectedTabPageIndex = 0 Then 'list WO
                    FormMatPLSingle.action = "ins"
                    FormMatPLSingle.id_comp_from = get_company_from(id_user)
                    FormMatPLSingle.id_comp_contact_to = "-1"
                    FormMatPLSingle.id_comp_contact_from = "-1"
                    FormMatPLSingle.is_other = "1"
                    FormMatPLSingle.ShowDialog()
                Else 'from WO
                    FormMatPLSingle.action = "ins"
                    FormMatPLSingle.id_comp_from = get_company_from(id_user)
                    FormMatPLSingle.id_comp_contact_to = FormMatPL.GVMRSWO.GetFocusedRowCellValue("id_comp_name_req_from").ToString
                    FormMatPLSingle.BtnPopSRS.Enabled = False
                    FormMatPLSingle.id_mrs = FormMatPL.GVMRSWO.GetFocusedRowCellDisplayText("id_prod_order_mrs").ToString
                    FormMatPLSingle.TxtSRSNumber.Text = FormMatPL.GVMRSWO.GetFocusedRowCellDisplayText("prod_order_mrs_number").ToString
                    FormMatPLSingle.id_comp_contact_from = "-1"
                    FormMatPLSingle.is_other = "1"
                    FormMatPLSingle.ShowDialog()
                End If
            ElseIf FormMatPL.XTCPL.SelectedTabPageIndex = 2 Then 'Other
                If FormMatPL.XTCPLOther.SelectedTabPageIndex = 0 Then 'list PL
                    FormMatPLSingle.action = "ins"
                    FormMatPLSingle.id_comp_from = get_company_from(id_user)
                    FormMatPLSingle.id_comp_contact_to = "-1"
                    FormMatPLSingle.id_comp_contact_from = "-1"
                    FormMatPLSingle.is_other = "1"
                    FormMatPLSingle.ShowDialog()
                Else 'from MRS
                    FormMatPLSingle.action = "ins"
                    FormMatPLSingle.id_comp_from = get_company_from(id_user)
                    FormMatPLSingle.id_comp_contact_to = FormMatPL.GVMRSOther.GetFocusedRowCellValue("id_comp_name_req_from").ToString
                    FormMatPLSingle.BtnPopSRS.Enabled = False
                    FormMatPLSingle.id_mrs = FormMatPL.GVMRSOther.GetFocusedRowCellDisplayText("id_prod_order_mrs").ToString
                    FormMatPLSingle.TxtSRSNumber.Text = FormMatPL.GVMRSOther.GetFocusedRowCellDisplayText("prod_order_mrs_number").ToString
                    FormMatPLSingle.id_comp_contact_from = "-1"
                    FormMatPLSingle.is_other = "1"
                    FormMatPLSingle.ShowDialog()
                End If
            End If
        ElseIf formName = "FormMatMRS" Then
            If FormMatMRS.XTCMRS.SelectedTabPageIndex = 0 Then 'mat wo
                FormMatMRSDet.id_mrs = "-1"
                FormMatMRSDet.mrs_type = "2"
                FormMatMRSDet.ShowDialog()
            ElseIf FormMatMRS.XTCMRS.SelectedTabPageIndex = 1 Then 'other
                FormMatMRSDet.id_mrs = "-1"
                FormMatMRSDet.mrs_type = "1"
                FormMatMRSDet.ShowDialog()
            End If
        ElseIf formName = "FormSampleAdjustment" Then
            If FormSampleAdjustment.XTCAdj.SelectedTabPageIndex = 0 Then 'In
                FormSampleAdjustmentInSingle.action = "ins"
                FormSampleAdjustmentInSingle.ShowDialog()
            ElseIf FormSampleAdjustment.XTCAdj.SelectedTabPageIndex = 1 Then 'Out
                FormSampleAdjustmentOutSingle.action = "ins"
                FormSampleAdjustmentOutSingle.ShowDialog()
            End If
        ElseIf formName = "FormMatAdj" Then
            If FormMatAdj.XTCAdj.SelectedTabPageIndex = 0 Then 'In
                FormMatAdjInSingle.action = "ins"
                FormMatAdjInSingle.ShowDialog()
            ElseIf FormMatAdj.XTCAdj.SelectedTabPageIndex = 1 Then 'Out
                FormMatAdjOutSingle.action = "ins"
                FormMatAdjOutSingle.ShowDialog()
            End If
        ElseIf formName = "FormMatPR" Then
            'Payment Request Material
            If FormMatPR.XTCTabPR.SelectedTabPageIndex = 0 Then
                FormMatPRDet.id_pr = "-1"
                FormMatPRDet.ShowDialog()
            ElseIf FormMatPR.XTCTabPR.SelectedTabPageIndex = 1 Then
                FormMatPRDet.id_pr = "-1"
                FormMatPRDet.id_purc = FormMatPR.GVMatPurchaseNeed.GetFocusedRowCellDisplayText("id_mat_purc").ToString
                FormMatPRDet.ShowDialog()
            ElseIf FormMatPR.XTCTabPR.SelectedTabPageIndex = 2 Then
                FormMatPRDet.id_pr = "-1"
                FormMatPRDet.id_rec = FormMatPR.GVMatReceive.GetFocusedRowCellDisplayText("id_mat_purc_rec").ToString
                FormMatPRDet.ShowDialog()
            End If
        ElseIf formName = "FormMatPRWO" Then
            'Payment Request WO Material
            If FormMatPRWO.XTCTabPR.SelectedTabPageIndex = 0 Then
                FormMatPRWODet.id_pr = "-1"
                FormMatPRWODet.ShowDialog()
            ElseIf FormMatPRWO.XTCTabPR.SelectedTabPageIndex = 1 Then
                FormMatPRWODet.id_pr = "-1"
                FormMatPRWODet.id_purc = FormMatPRWO.GVMatPurchaseNeed.GetFocusedRowCellDisplayText("id_mat_wo").ToString
                FormMatPRWODet.ShowDialog()
            ElseIf FormMatPRWO.XTCTabPR.SelectedTabPageIndex = 2 Then
                FormMatPRWODet.id_pr = "-1"
                FormMatPRWODet.id_rec = FormMatPRWO.GVMatReceive.GetFocusedRowCellDisplayText("id_mat_wo_rec").ToString
                FormMatPRWODet.ShowDialog()
            End If
        ElseIf formName = "FormProductionRec" Then
            'Material Purchase Receive
            If FormProductionRec.XTCTabReceive.SelectedTabPageIndex = 0 Then 'based on Rec
                FormProductionRecDet.id_order = "-1"
                FormProductionRecDet.ShowDialog()
            Else 'based on PO
                FormProductionRecDet.id_order = FormProductionRec.GVProd.GetFocusedRowCellValue("id_prod_order").ToString
                FormProductionRecDet.ShowDialog()
            End If
        ElseIf formName = "FormProductionRet" Then
            'FG Return
            If FormProductionRet.XTCReturn.SelectedTabPageIndex = 0 Then 'ret out
                FormProductionRetOutSingle.action = "ins"
                FormProductionRetOutSingle.id_prod_order_ret_out = "0"
                FormProductionRetOutSingle.ShowDialog()
            Else 'ret in
                FormProductionRetInSingle.action = "ins"
                FormProductionRetInSingle.id_prod_order_ret_in = "0"
                FormProductionRetInSingle.ShowDialog()
            End If
        ElseIf formName = "FormProductionPLToWH" Then
            If FormProductionPLToWH.XTCPL.SelectedTabPageIndex = 0 Then
                FormProductionPLToWHDet.action = "ins"
                FormProductionPLToWHDet.id_pl_prod_order = "0"
                FormProductionPLToWHDet.ShowDialog()
            Else
                Dim cost As Decimal = FormProductionPLToWH.GVProd.GetFocusedRowCellValue("design_cop")
                If cost > 0 Then
                    FormProductionPLToWHDet.action = "ins"
                    FormProductionPLToWHDet.id_pl_prod_order = "0"
                    FormProductionPLToWHDet.id_prod_order = FormProductionPLToWH.GVProd.GetFocusedRowCellValue("id_prod_order").ToString
                    FormProductionPLToWHDet.ShowDialog()
                Else
                    stopCustom("Packing list can't continue process, because there is no cost for this style.")
                End If
            End If
        ElseIf formName = "FormMatInvoice" Then
            If FormMatInvoice.XTCTabGeneral.SelectedTabPageIndex = 0 Then 'invoice
                If FormMatInvoice.XTCTabProduction.SelectedTabPageIndex = 0 Then 'ret out
                    FormMatInvoiceDet.id_invoice = "-1"
                    FormMatInvoiceDet.ShowDialog()
                Else 'PL
                    FormMatInvoiceDet.id_invoice = "-1"
                    FormMatInvoiceDet.id_prod_order_wo = FormMatInvoice.GVProdPL.GetFocusedRowCellValue("id_pl_mrs").ToString
                    FormMatInvoiceDet.ShowDialog()
                End If
            Else ' retur
                If FormMatInvoice.XTCRetur.SelectedTabPageIndex = 0 Then 'ret out
                    FormMatInvoiceReturDet.id_retur = "-1"
                    FormMatInvoiceReturDet.ShowDialog()
                Else 'PL
                    FormMatInvoiceReturDet.id_retur = "-1"
                    FormMatInvoiceReturDet.id_invoice = FormMatInvoice.GVInvoice.GetFocusedRowCellValue("id_inv_pl_mrs").ToString
                    FormMatInvoiceReturDet.ShowDialog()
                End If
            End If
        ElseIf formName = "FormAccounting" Then
            If FormAccounting.XTCGeneral.SelectedTabPageIndex = 0 Then
                FormAccountingAcc.id_acc = "-1"
                FormAccountingAcc.ShowDialog()
            Else
                FormAccountingAcc.id_acc = "-1"
                FormAccountingAcc.id_parent = FormAccounting.TreeList1.FocusedNode("id_acc_parent").ToString()
                FormAccountingAcc.ShowDialog()
            End If
        ElseIf formName = "FormAccountingJournal" Then
            FormAccountingJournalBill.id_trans = "-1"
            FormAccountingJournalBill.ShowDialog()
        ElseIf formName = "FormProductionPLToWHRec" Then
            If FormProductionPLToWHRec.XTCPL.SelectedTabPageIndex = 0 Then
                FormProductionPLToWHRecDet.action = "ins"
                FormProductionPLToWHRecDet.id_pl_prod_order_rec = "0"
                FormProductionPLToWHRecDet.ShowDialog()
            Else
                FormProductionPLToWHRecDet.action = "ins"
                FormProductionPLToWHRecDet.id_pl_prod_order_rec = "0"
                FormProductionPLToWHRecDet.id_pl_prod_order = FormProductionPLToWHRec.GVProd.GetFocusedRowCellValue("id_pl_prod_order").ToString
                FormProductionPLToWHRecDet.id_pd_alloc = FormProductionPLToWHRec.GVProd.GetFocusedRowCellValue("id_pd_alloc").ToString
                FormProductionPLToWHRecDet.ShowDialog()
            End If
        ElseIf formName = "FormSalesTarget" Then
            'SALES TARGET
            If FormSalesTarget.XTCSalesTarget.SelectedTabPageIndex = 0 Then
                FormSalesTargetDet.action = "ins"
                FormSalesTargetDet.id_sales_target = "-1"
                FormSalesTargetDet.ShowDialog()
            End If
        ElseIf formName = "FormSalesOrder" Then
            'SALES OrDEER
            If FormSalesOrder.XTCSOGeneral.SelectedTabPageIndex = 0 Then
                FormSalesOrderDet.action = "ins"
                FormSalesOrderDet.id_sales_order = "-1"
                FormSalesOrderDet.ShowDialog()
            ElseIf FormSalesOrder.XTCSOGeneral.SelectedTabPageIndex = 1 Then
                FormSalesOrderGen.action = "ins"
                FormSalesOrderGen.id_sales_order_gen = "-1"
                FormSalesOrderGen.ShowDialog()
            End If
        ElseIf formName = "FormSalesDelOrder" Then
            'SALES DELIVERY ORDER
            If FormSalesDelOrder.XTCDO.SelectedTabPageIndex = 0 Then
                FormSalesDelOrderDet.action = "ins"
                FormSalesDelOrderDet.ShowDialog()
            ElseIf FormSalesDelOrder.XTCDO.SelectedTabPageIndex = 1 Then
                FormSalesDelOrderDet.id_sales_order = FormSalesDelOrder.GVSalesOrder.GetFocusedRowCellValue("id_sales_order").ToString
                FormSalesDelOrderDet.action = "ins"
                FormSalesDelOrderDet.ShowDialog()
            End If
        ElseIf formName = "FormSalesReturnOrder" Then
            'SALES RETURN ORDER
            FormSalesReturnOrderDet.action = "ins"
            FormSalesReturnOrderDet.id_sales_return_order = "-1"
            FormSalesReturnOrderDet.ShowDialog()
        ElseIf formName = "FormSalesReturn" Then
            'SALES RETURN
            If FormSalesReturn.XTCSalesReturn.SelectedTabPageIndex = 0 Then
                FormSalesReturnDet.action = "ins"
                FormSalesReturnDet.ShowDialog()
            ElseIf FormSalesReturn.XTCSalesReturn.SelectedTabPageIndex = 1 Then
                FormSalesReturnDet.id_sales_return_order = FormSalesReturn.GVSalesReturnOrder.GetFocusedRowCellValue("id_sales_return_order").ToString
                FormSalesReturnDet.action = "ins"
                FormSalesReturnDet.ShowDialog()
            End If
        ElseIf formName = "FormSalesPOS" Then
            'SALES POS
            FormSalesPOSDet.action = "ins"
            FormSalesPOSDet.ShowDialog()
        ElseIf formName = "FormSalesReturnQC" Then
            'SALES RETURN QC
            If FormSalesReturnQC.XTCReturnQC.SelectedTabPageIndex = 0 Then
                FormSalesReturnQCDet.action = "ins"
                FormSalesReturnQCDet.ShowDialog()
            Else
                FormSalesReturnQCDet.action = "ins"
                FormSalesReturnQCDet.id_sales_return = FormSalesReturnQC.GVSalesReturn.GetFocusedRowCellValue("id_sales_return").ToString
                FormSalesReturnQCDet.ShowDialog()
            End If
        ElseIf formName = "FormSalesInvoice" Then
            'SALES INVOICE
            FormSalesInvoiceNew.ShowDialog()
        ElseIf formName = "FormAccountingJournalAdj" Then
            FormAccountingJournalAdjDet.id_trans = "-1"
            FormAccountingJournalAdjDet.ShowDialog()
        ElseIf formName = "FormProdPRWO" Then
            If FormProdPRWO.XTCTabPR.SelectedTabPageIndex = 0 Then
                FormProdPRWODet.id_pr = "-1"
                FormProdPRWODet.ShowDialog()
            ElseIf FormProdPRWO.XTCTabPR.SelectedTabPageIndex = 1 Then
                FormProdPRWODet.id_pr = "-1"
                FormProdPRWODet.id_prod_order_wo = FormProdPRWO.GVProdWO.GetFocusedRowCellValue("id_prod_order_wo").ToString
                FormProdPRWODet.ShowDialog()
            End If
        ElseIf formName = "FormFGStockOpnameStore" Then
            'STORE STOCK OPNAME
            FormFGStockOpnameStoreDet.action = "ins"
            FormFGStockOpnameStoreDet.ShowDialog()
        ElseIf formName = "FormFGMissing" Then
            'MISSING FG
            If FormFGMissing.XTCFGMissing.SelectedTabPageIndex = 0 Then
                FormFGMissingDet.action = "ins"
                FormFGMissingDet.id_pop_up = "1"
                FormFGMissingDet.ShowDialog()
            ElseIf FormFGMissing.XTCFGMissing.SelectedTabPageIndex = 1 Then
                FormFGMissingWHDet.action = "ins"
                FormFGMissingWHDet.id_pop_up = "1"
                FormFGMissingWHDet.ShowDialog()
            End If
        ElseIf formName = "FormFGMissingInvoice" Then
            'MISSING FG INVOICE
            FormFGMissingInvoiceNew.ShowDialog()
        ElseIf formName = "FormFGStockOpnameWH" Then
            'WH STOCK OPNAME
            FormFGStockOpnameWHDet.action = "ins"
            FormFGStockOpnameWHDet.ShowDialog()
        ElseIf formName = "FormMatStockOpname" Then
            FormMatStockOpnameDet.id_mat_so = "-1"
            FormMatStockOpnameDet.ShowDialog()
        ElseIf formName = "FormFGAdj" Then
            'FG ADJ
            If FormFGAdj.XTCAdj.SelectedTabPageIndex = 0 Then 'In
                FormFGAdjInDet.action = "ins"
                FormFGAdjInDet.ShowDialog()
            ElseIf FormFGAdj.XTCAdj.SelectedTabPageIndex = 1 Then 'Out
                FormFGAdjOutDet.action = "ins"
                FormFGAdjOutDet.ShowDialog()
            End If
        ElseIf formName = "FormFGTrf" Then
            'FG Transfer Future
            FormFGTrfDet.action = "ins"
            FormFGTrfDet.ShowDialog()
        ElseIf formName = "FormFGTrfNew" Then
            'FG Transfer
            If FormFGTrfNew.XTCTrf.SelectedTabPageIndex = 0 Then
                FormFGTrfNewDet.action = "ins"
                FormFGTrfNewDet.ShowDialog()
            ElseIf FormFGTrfNew.XTCTrf.SelectedTabPageIndex = 1 Then
                FormFGTrfNewDet.id_sales_order = FormFGTrfNew.GVSalesOrder.GetFocusedRowCellValue("id_sales_order").ToString
                FormFGTrfNewDet.action = "ins"
                FormFGTrfNewDet.ShowDialog()
            End If
        ElseIf formName = "FormMasterEmployee" Then
            'Master Employee
            FormMasterEmployeeNewDet.action = "ins"
            FormMasterEmployeeNewDet.ShowDialog()
            'FormMasterEmployeeDet.action = "ins"
            'FormMasterEmployeeDet.ShowDialog()
        ElseIf formName = "FormSampleDel" Then
            'Delivery Sample Never Returned
            FormSampleDelDet.action = "ins"
            FormSampleDelDet.ShowDialog()
        ElseIf formName = "FormSampleDelRec" Then
            'REC Delivery Sample
            If FormSampleDelRec.XTCSampleDelRec.SelectedTabPageIndex = 0 Then
                FormSampleDelRecDet.action = "ins"
                FormSampleDelRecDet.ShowDialog()
            ElseIf FormSampleDelRec.XTCSampleDelRec.SelectedTabPageIndex = 1 Then
                FormSampleDelRecDet.action = "ins"
                FormSampleDelRecDet.id_sample_del = FormSampleDelRec.GVSampleDel.GetFocusedRowCellValue("id_sample_del").ToString
                FormSampleDelRecDet.ShowDialog()
            End If
        ElseIf formName = "FormSampleOrder" Then
            ' SALES ORDER SAMPLE
            FormSampleOrderDet.action = "ins"
            FormSampleOrderDet.ShowDialog()
        ElseIf formName = "FormSampleDelOrder" Then
            'DELIVERY ORDER FOR SAMPLE SALES
            If FormSampleDelOrder.XTCSampleDelOrder.SelectedTabPageIndex = 0 Then
                FormSampleDelOrderDet.action = "ins"
                FormSampleDelOrderDet.ShowDialog()
            ElseIf FormSampleDelOrder.XTCSampleDelOrder.SelectedTabPageIndex = 1 Then
                FormSampleDelOrderDet.id_sample_order = FormSampleDelOrder.GVSampleOrder.GetFocusedRowCellValue("id_sample_order").ToString
                FormSampleDelOrderDet.action = "ins"
                FormSampleDelOrderDet.id_store_contact_to = FormSampleDelOrder.GVSampleOrder.GetFocusedRowCellValue("id_store_contact_to").ToString
                FormSampleDelOrderDet.id_store_to = FormSampleDelOrder.GVSampleOrder.GetFocusedRowCellValue("id_store_to").ToString
                FormSampleDelOrderDet.TxtCodeCompTo.Text = FormSampleDelOrder.GVSampleOrder.GetFocusedRowCellValue("store_number_to").ToString
                FormSampleDelOrderDet.TxtNameCompTo.Text = FormSampleDelOrder.GVSampleOrder.GetFocusedRowCellValue("store_name_to").ToString
                FormSampleDelOrderDet.MEAdrressCompTo.Text = FormSampleDelOrder.GVSampleOrder.GetFocusedRowCellValue("store_address_to").ToString
                FormSampleDelOrderDet.TxtSampleOrder.Text = FormSampleDelOrder.GVSampleOrder.GetFocusedRowCellValue("sample_order_number").ToString
                FormSampleDelOrderDet.id_so_status = FormSampleDelOrder.GVSampleOrder.GetFocusedRowCellValue("id_so_status").ToString
                FormSampleDelOrderDet.id_so_type = FormSampleDelOrder.GVSampleOrder.GetFocusedRowCellValue("id_so_type").ToString
                FormSampleDelOrderDet.viewSampleOrder()
                FormSampleDelOrderDet.GroupControlListItem.Enabled = True
                FormSampleDelOrderDet.BtnInfoSrs.Enabled = True
                FormSampleDelOrderDet.ShowDialog()
            End If
        ElseIf formName = "FormSampleStockOpname" Then
            FormSampleStockOpnameDet.action = "ins"
            FormSampleStockOpnameDet.ShowDialog()
        ElseIf formName = "FormFGCodeReplace" Then
            'CODE REPLACEMENT
            If FormFGCodeReplace.XTCFGCodeReplace.SelectedTabPageIndex = 0 Then
                FormFGCodeReplaceStoreDet.action = "ins"
                FormFGCodeReplaceStoreDet.ShowDialog()
            ElseIf FormFGCodeReplace.XTCFGCodeReplace.SelectedTabPageIndex = 1 Then
                FormFGCodeReplaceWHDet.action = "ins"
                FormFGCodeReplaceWHDet.ShowDialog()
            End If
        ElseIf formName = "FormSalesCreditNote" Then
            'CREDIT NOTE
            FormSalesCreditNoteDet.action = "ins"
            FormSalesCreditNoteDet.ShowDialog()
        ElseIf formName = "FormFGMissingCreditNote" Then
            'MISSING CREDIT NOTE
            If FormFGMissingCreditNote.XTCFGMissingCN.SelectedTabPageIndex = 0 Then
                FormFGMissingCreditNoteStoreDet.action = "ins"
                FormFGMissingCreditNoteStoreDet.ShowDialog()
            ElseIf FormFGMissingCreditNote.XTCFGMissingCN.SelectedTabPageIndex = 1 Then

            End If
        ElseIf formName = "FormSOHPeriode" Then
            'CREDIT NOTE
            FormSOHPeriodeDet.id_soh_periode = "-1"
            FormSOHPeriodeDet.ShowDialog()
        ElseIf formName = "FormSOH" Then
            'CREDIT NOTE
            FormSOHDet.id_soh = "-1"
            FormSOHDet.ShowDialog()
        ElseIf formName = "FormFGWoff" Then
            'FG Write Off
            FormFGWoffDet.action = "ins"
            FormFGWoffDet.ShowDialog()
        ElseIf formName = "FormFGProposePrice" Then
            'FG PROPOSE PRICE
            FormFGProposePriceDet.action = "ins"
            FormFGProposePriceDet.ShowDialog()
        ElseIf formName = "FormMasterRetCode" Then
            'RETURN CODE
            FormMasterRetCodeDet.action = "ins"
            FormMasterRetCodeDet.ShowDialog()
        ElseIf formName = "FormSampleOrdered" Then
            ' SAMPLE ORDER
            FormSampleOrderedDet.action = "ins"
            FormSampleOrderedDet.ShowDialog()
        ElseIf formName = "FormMasterRateStore" Then
            'RATE STORE
            FormMasterRateStoreDet.action = "ins"
            FormMasterRateStoreDet.ShowDialog()
        ElseIf formName = "FormProdQCAdj" Then
            'QC ADj
            If FormProdQCAdj.XTCAdj.SelectedTabPageIndex = 0 Then 'adj in
                FormProdQCAdjIn.id_adj_in = "-1"
                FormProdQCAdjIn.ShowDialog()
            ElseIf FormProdQCAdj.XTCAdj.SelectedTabPageIndex = 1 Then 'adj out
                FormProdQCAdjOut.id_adj_out = "-1"
                FormProdQCAdjOut.ShowDialog()
            End If
        ElseIf formName = "FormSalesPromo" Then
            'Sales Promo
            FormSalesPromoDet.action = "ins"
            FormSalesPromoDet.ShowDialog()
        ElseIf formName = "FormFGSalesOrderReff" Then
            FormFGSalesOrderReffDet.action = "ins"
            FormFGSalesOrderReffDet.ShowDialog()
        ElseIf formName = "FormMasterComputer" Then
            FormMasterComnputerDet.action = "ins"
            FormMasterComnputerDet.ShowDialog()
        ElseIf formName = "FormAccountingFakturScan" Then
            FormAccountingFakturScanSingle.action = "ins"
            FormAccountingFakturScanSingle.ShowDialog()
        ElseIf formName = "FormFGBorrowQCReq" Then
            'BORROW REQ FIR QC PRODUCT
            FormFGBorrowQCReqSingle.action = "ins"
            FormFGBorrowQCReqSingle.ShowDialog()
        ElseIf formName = "FormWHAWBill" Then
            If FormWHAWBill.XTCAwb.SelectedTabPageIndex = 0 Then
                again_awb = "1"
                While again_awb = "1"
                    again_awb = "2"
                    FormWHAWBillDet.id_awb = "-1"
                    FormWHAWBillDet.id_awb_type = "1"
                    FormWHAWBillDet.ShowDialog()
                End While
            Else
                again_awb = "1"
                While again_awb = "1"
                    again_awb = "2"
                    FormWHAWBillIn.id_awb = "-1"
                    FormWHAWBillIn.id_awb_type = "2"
                    FormWHAWBillIn.ShowDialog()
                End While
            End If
        ElseIf formName = "FormMasterPrice" Then
            FormMasterPriceSingle.action = "ins"
            FormMasterPriceSingle.ShowDialog()
        ElseIf formName = "FormSamplePLToWH" Then
            'PACKING LIST SAMPLE
            FormSamplePLToWHDet.action = "ins"
            FormSamplePLToWHDet.ShowDialog()
        ElseIf formName = "FormMasterPriceSample" Then
            'MASTER PRICE SAMPLE
            FormMasterPriceSampleSingle.action = "ins"
            FormMasterPriceSampleSingle.ShowDialog()
        ElseIf formName = "FormFGWHAlloc" Then
            'INVENTORY ALLOCATION
            FormFGWHAllocDet.action = "ins"
            FormFGWHAllocDet.ShowDialog()
        ElseIf formName = "FormSampleReturnPL" Then
            'Return Internal sale
            FormSampleReturnPLDet.action = "ins"
            FormSampleReturnPLDet.ShowDialog()
        ElseIf formName = "FormFGDesignList" Then
            'DESIGN LIST
            FormMasterDesignSingle.id_pop_up = "5"
            FormMasterDesignSingle.id_season_par = FormFGDesignList.SLESeason.EditValue.ToString
            FormMasterDesignSingle.form_name = "FormFGDesignList"
            FormMasterDesignSingle.WindowState = FormWindowState.Maximized
            FormMasterDesignSingle.ShowDialog()
        ElseIf formName = "FormEmpShift" Then
            'DESIGN LIST
            FormEmpShiftDet.id_shift = "-1"
            FormEmpShiftDet.ShowDialog()
        ElseIf formName = "FormEmpInitialize" Then
            FormEmpInitialize.addUser()
        ElseIf formName = "FormEmpHoliday" Then
            'DESIGN LIST
            FormEmpHolidayDet.id_holiday = "-1"
            FormEmpHolidayDet.ShowDialog()
        ElseIf formName = "FormFGRepair" Then
            'Repair
            FormFGRepairDet.action = "ins"
            FormFGRepairDet.ShowDialog()
        ElseIf formName = "FormFGRepairRec" Then
            'Repair receive
            If FormFGRepairRec.XTCRepairRec.SelectedTabPageIndex = 1 Then
                FormFGRepairRecDet.id_fg_repair_select = FormFGRepairRec.GVRepairList.GetFocusedRowCellValue("id_fg_repair").ToString
                FormFGRepairRecDet.action = "ins"
                FormFGRepairRecDet.ShowDialog()
            End If
        ElseIf formName = "FormFGRepairReturn" Then
            'Return Repair
            FormFGRepairReturnDet.action = "ins"
            FormFGRepairReturnDet.ShowDialog()
        ElseIf formName = "FormFGRepairReturnRec" Then
            ''Repair return receive
            If FormFGRepairReturnRec.XTCRepairRec.SelectedTabPageIndex = 1 Then
                FormFGRepairReturnRecDet.id_fg_repair_return_select = FormFGRepairReturnRec.GVRepairList.GetFocusedRowCellValue("id_fg_repair_return").ToString
                FormFGRepairReturnRecDet.action = "ins"
                FormFGRepairReturnRecDet.ShowDialog()
            End If
        ElseIf formName = "FormEmpEmail" Then
            'Email List
            FormEmpEmailDet.type = "2"
            FormEmpEmailDet.ShowDialog()
        ElseIf formName = "FormEmpLeave" Then
            'Leave
            FormEmpLeaveDet.id_emp_leave = "-1"
            FormEmpLeaveDet.ShowDialog()
        ElseIf formName = "FormEmpDP" Then
            'Leave
            FormEmpDPDet.id_emp_dp = "-1"
            FormEmpDPDet.ShowDialog()
        ElseIf formName = "FormEmpChSchedule" Then
            'Leave
            FormEmpChScheduleDet.id_ch_sch = "-1"
            FormEmpChScheduleDet.ShowDialog()
        ElseIf formName = "FormEmpAttnAssign" Then
            'assign schedule with approval
            FormEmpAttnAssignDet.id_emp_assign_sch = "-1"
            FormEmpAttnAssignDet.ShowDialog()
        Else
            RPSubMenu.Visible = False
        End If
        Cursor = Cursors.Default
    End Sub
    'Edit Data
    Private Sub BBEdit_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles BBEdit.ItemClick
        but_edit()
    End Sub
    Sub but_edit()
        If BBEdit.Enabled = True And BBEdit.Visibility = DevExpress.XtraBars.BarItemVisibility.Always Then
            Cursor = Cursors.WaitCursor
            If formName = "FormMasterArea" Then
                If FormMasterArea.XTCArea.SelectedTabPageIndex = 0 Then
                    'country
                    FormMasterCountrySingle.id_country = FormMasterArea.GVCountry.GetFocusedRowCellDisplayText("id_country").ToString
                    FormMasterCountrySingle.ShowDialog()
                ElseIf FormMasterArea.XTCArea.SelectedTabPageIndex = 1 Then
                    'state
                    FormMasterRegionSingle.id_country = FormMasterArea.GVCountry.GetFocusedRowCellDisplayText("id_country").ToString
                    FormMasterRegionSingle.id_region = FormMasterArea.GVRegion.GetFocusedRowCellDisplayText("id_region").ToString
                    FormMasterRegionSingle.ShowDialog()
                ElseIf FormMasterArea.XTCArea.SelectedTabPageIndex = 2 Then
                    'state
                    FormMasterStateSingle.id_region = FormMasterArea.GVRegion.GetFocusedRowCellDisplayText("id_region").ToString
                    FormMasterStateSingle.id_state = FormMasterArea.GVState.GetFocusedRowCellDisplayText("id_state").ToString
                    FormMasterStateSingle.ShowDialog()
                Else
                    'city
                    FormMasterCitySingle.id_state = FormMasterArea.GVState.GetFocusedRowCellDisplayText("id_state").ToString
                    FormMasterCitySingle.id_city = FormMasterArea.GVCity.GetFocusedRowCellDisplayText("id_city").ToString
                    FormMasterCitySingle.ShowDialog()
                End If
            ElseIf formName = "FormMasterCompany" Then
                '
                FormMasterCompanySingle.id_company = FormMasterCompany.GVCompany.GetFocusedRowCellDisplayText("id_comp").ToString
                FormMasterCompanySingle.ShowDialog()
            ElseIf formName = "FormMasterCompanyCategory" Then
                '
                FormMasterCompanyCategorySingle.id_company_category = FormMasterCompanyCategory.GVCompanyCategory.GetFocusedRowCellDisplayText("id_comp_cat").ToString
                FormMasterCompanyCategorySingle.ShowDialog()
            ElseIf formName = "FormMasterDepartement" Then
                '
                FormMasterDepartementSingle.id_departement = FormMasterDepartement.GVDepartment.GetFocusedRowCellDisplayText("id_departement").ToString
                FormMasterDepartementSingle.ShowDialog()
            ElseIf formName = "FormMasterRawMaterialCat" Then
                '
                FormMasterRawMaterialCatSingle.id_mat_cat = FormMasterRawMaterialCat.GridViewMasterItemCategory.GetFocusedRowCellDisplayText("id_mat_cat").ToString
                FormMasterRawMaterialCatSingle.action = "upd"
                FormMasterRawMaterialCatSingle.ShowDialog()
            ElseIf formName = "FormMasterItemColor" Then
                '
                FormMasterItemColorSingle.action = "upd"
                FormMasterItemColorSingle.id_item_color = FormMasterItemColor.GVItemColor.GetFocusedRowCellDisplayText("id_item_color").ToString
                FormMasterItemColorSingle.ShowDialog()
            ElseIf formName = "FormMasterItemSize" Then
                '
                FormMasterItemSizeSingle.action = "upd"
                FormMasterItemSizeSingle.id_item_size = FormMasterItemSize.GVItemSize.GetFocusedRowCellDisplayText("id_item_size").ToString
                FormMasterItemSizeSingle.ShowDialog()
            ElseIf formName = "FormMasterUser" Then
                FormMasterUserSingle.id_user = FormMasterUser.GVUser.GetFocusedRowCellDisplayText("id_user").ToString
                FormMasterUserSingle.ShowDialog()
            ElseIf formName = "FormAccess" Then
                If FormAccess.XTCMenuManage.SelectedTabPageIndex = 2 Then 'Edit role
                    FormAccessRoleSingle.id_role = FormAccess.GVRole.GetFocusedRowCellDisplayText("id_role").ToString
                    FormAccessRoleSingle.action = "upd"
                    FormAccessRoleSingle.LabelRole.Text = "Edit Role"
                    FormAccessRoleSingle.TxtRoleName.Text = FormAccess.GVRole.GetFocusedRowCellDisplayText("role").ToString
                    FormAccessRoleSingle.ShowDialog()
                ElseIf FormAccess.XTCMenuManage.SelectedTabPageIndex = 1 Then 'Edit menu
                    FormAccessMenuSingle.id_menu = FormAccess.GVMenu.GetFocusedRowCellDisplayText("id_menu").ToString
                    FormAccessMenuSingle.TxtMenuName.Text = FormAccess.GVMenu.GetFocusedRowCellDisplayText("menu_name").ToString
                    FormAccessMenuSingle.MEDescription.Text = FormAccess.GVMenu.GetFocusedRowCellDisplayText("description_menu_name").ToString
                    FormAccessMenuSingle.action = "upd"
                    FormAccessMenuSingle.ShowDialog()
                ElseIf FormAccess.XTCMenuManage.SelectedTabPageIndex = 0 Then 'Edit form
                    If FormAccess.XTCForm.SelectedTabPageIndex = 0 Then 'Edit Form
                        FormAccessProcessSingle.LabelTitle.Text = FormAccess.GVForm.GetFocusedRowCellDisplayText("form_name").ToString
                        FormAccessFrmSingle.id_form = FormAccess.GVForm.GetFocusedRowCellDisplayText("id_form").ToString
                        FormAccessFrmSingle.TxtFormName.Text = FormAccess.GVForm.GetFocusedRowCellDisplayText("form_name").ToString
                        FormAccessFrmSingle.action = "upd"
                        FormAccessFrmSingle.ShowDialog()
                    ElseIf FormAccess.XTCForm.SelectedTabPageIndex = 1 Then 'Edit Form Control
                        Dim is_view As String = FormAccess.GVProcess.GetFocusedRowCellDisplayText("is_view").ToString
                        If is_view = "1" Then
                            FormAccessProcessSingle.is_required = True
                            FormAccessProcessSingle.id_form = FormAccess.GVForm.GetFocusedRowCellDisplayText("id_form").ToString()
                        Else
                            FormAccessProcessSingle.is_required = False
                            FormAccessProcessSingle.id_form = FormAccess.GVForm.GetFocusedRowCellDisplayText("id_form").ToString()
                        End If
                        FormAccessProcessSingle.LabelTitle.Text = FormAccess.GVForm.GetFocusedRowCellDisplayText("form_name").ToString
                        FormAccessProcessSingle.id_form_control = FormAccess.GVProcess.GetFocusedRowCellDisplayText("id_form_control").ToString
                        FormAccessProcessSingle.TxtDescription.Text = FormAccess.GVProcess.GetFocusedRowCellDisplayText("description_form_control").ToString
                        FormAccessProcessSingle.action = "upd"
                        FormAccessProcessSingle.ShowDialog()
                    End If
                End If
            ElseIf formName = "FormSeason" Then
                If FormSeason.XTCMainSeason.SelectedTabPageIndex = 0 Then 'edit internal season
                    If FormSeason.XTCSeason.SelectedTabPageIndex = 0 Then
                        'edit range
                        FormRangeSingle.action = "upd"
                        FormRangeSingle.id_season_par = TryCast(XTMDI.SelectedPage.MdiChild, FormSeason).GVRange.GetFocusedRowCellDisplayText("id_season").ToString
                        FormRangeSingle.id_range = TryCast(XTMDI.SelectedPage.MdiChild, FormSeason).GVRange.GetFocusedRowCellDisplayText("id_range").ToString
                        FormRangeSingle.TxtRange.Text = TryCast(XTMDI.SelectedPage.MdiChild, FormSeason).GVRange.GetFocusedRowCellDisplayText("range").ToString
                        FormRangeSingle.ShowDialog()
                    ElseIf FormSeason.XTCSeason.SelectedTabPageIndex = 1 Then
                        'edit season
                        FormSeasonSingle.action = "upd"
                        FormSeasonSingle.id_season = FormSeason.GVSeason.GetFocusedRowCellDisplayText("id_season").ToString
                        FormSeasonSingle.ShowDialog()
                    ElseIf FormSeason.XTCSeason.SelectedTabPageIndex = 2 Then
                        'edit delivery
                        FormDeliverySingle.action = "upd"
                        FormDeliverySingle.id_delivery = FormSeason.GVDelivery.GetFocusedRowCellDisplayText("id_delivery").ToString
                        FormDeliverySingle.GCtrlDelivery.Text = "Range " + FormSeason.range_season.ToString + " - Season " + FormSeason.season.ToString
                        FormDeliverySingle.ShowDialog()
                    End If
                Else 'edit origin season
                    FormSeasonorignSingle.action = "upd"
                    FormSeasonorignSingle.id_season_orign = FormSeason.GVOrignSeason.GetFocusedRowCellDisplayText("id_season_orign").ToString
                    FormSeasonorignSingle.TxtSeason.Text = FormSeason.GVOrignSeason.GetFocusedRowCellDisplayText("season_orign").ToString
                    FormSeasonorignSingle.TxtSeasonPrintedName.Text = FormSeason.GVOrignSeason.GetFocusedRowCellDisplayText("season_orign_display").ToString
                    'LECountry.ItemIndex = FormSeasonorignSingle.LECountry.Properties.GetDataSourceRowIndex("id_country", FormSeason.GVOrignSeason.GetFocusedRowCellDisplayText("id_country").ToString)
                    FormSeasonorignSingle.id_country = FormSeason.GVOrignSeason.GetFocusedRowCellDisplayText("id_country").ToString
                    FormSeasonorignSingle.season_orign_year = FormSeason.GVOrignSeason.GetFocusedRowCellDisplayText("season_orign_year").ToString
                    FormSeasonorignSingle.ShowDialog()
                End If
            ElseIf formName = "FormMasterUOM" Then
                '
                FormMasterUOM.PCUOM.Visible = True
                FormMasterUOM.ErrorProviderUom.SetError(FormMasterUOM.TxtUOM, "")
                FormMasterUOM.action = "upd"
                FormMasterUOM.getDataUpd()
            ElseIf formName = "FormMasterRawMat" Then
                If FormMasterRawMat.XTCRawMat.SelectedTabPageIndex = 0 Then 'edit raw mat
                    FormMasterRawMatSingle.action = "upd"
                    FormMasterRawMatSingle.id_raw_mat = FormMasterRawMat.GVRawMat.GetFocusedRowCellDisplayText("id_raw_mat").ToString
                    FormMasterRawMatSingle.ShowDialog()
                ElseIf FormMasterRawMat.XTCRawMat.SelectedTabPageIndex = 1 Then 'edit detail raw mat
                    FormMasterRawMatLotSingle.action = "upd"
                    FormMasterRawMatLotSingle.loadku = 0
                    FormMasterRawMatLotSingle.id_raw_mat_detail = FormMasterRawMat.GVLot.GetFocusedRowCellDisplayText("id_raw_mat_detail").ToString
                    FormMasterRawMatLotSingle.ShowDialog()
                ElseIf FormMasterRawMat.XTCRawMat.SelectedTabPageIndex = 2 Then 'edit raw mat supplier
                    FormMasterRawMatSupplierSingle.action = "upd"
                    FormMasterRawMatSupplierSingle.id_raw_mat_detail = FormMasterRawMat.GVLot.GetFocusedRowCellDisplayText("id_raw_mat_detail").ToString
                    FormMasterRawMatSupplierSingle.id_raw_mat_supplier = FormMasterRawMat.GVSupplier.GetFocusedRowCellDisplayText("id_raw_mat_supplier").ToString
                    FormMasterRawMatSupplierSingle.ShowDialog()
                End If
            ElseIf formName = "FormSetupRawMatCode" Then
                Cursor = Cursors.WaitCursor
                FormSetupRawMatCodeSingle.action = "upd"
                FormSetupRawMatCodeSingle.id_raw_mat_code = FormSetupRawMatCode.GVCodeType.GetFocusedRowCellDisplayText("id_raw_mat_code").ToString
                FormSetupRawMatCodeSingle.ShowDialog()
                Cursor = Cursors.Default
            ElseIf formName = "FormMasterRawMaterial" Then 'EDIT MASTER RAW MATERIAL
                If FormMasterRawMaterial.XTCList.SelectedTabPageIndex = 0 Then
                    If FormMasterRawMaterial.XTCMaterialType.SelectedTabPageIndex = 0 Then 'edit raw material
                        FormMasterRawMaterialSingle.action = "upd"
                        FormMasterRawMaterialSingle.id_mat = FormMasterRawMaterial.GVRawMat.GetFocusedRowCellDisplayText("id_mat").ToString
                        FormMasterRawMaterialSingle.ShowDialog()
                    ElseIf FormMasterRawMaterial.XTCMaterialType.SelectedTabPageIndex = 1 Then 'edit raw material detail
                        FormMasterRawMaterialDetSingle.action = "upd"

                        FormMasterRawMaterialDetSingle.id_mat = FormMasterRawMaterial.GVRawMat.GetFocusedRowCellValue("id_mat").ToString
                        FormMasterRawMaterialDetSingle.LabelPrintedName.Text = FormMasterRawMaterial.GVRawMat.GetFocusedRowCellDisplayText("mat_display_name").ToString
                        FormMasterRawMaterialDetSingle.TxtMaterialTypeCode.Text = FormMasterRawMaterial.GVRawMat.GetFocusedRowCellDisplayText("mat_code").ToString

                        FormMasterRawMaterialDetSingle.id_mat_det = FormMasterRawMaterial.GVMatDetail.GetFocusedRowCellDisplayText("id_mat_det").ToString
                        FormMasterRawMaterialDetSingle.ShowDialog()
                    End If
                ElseIf FormMasterRawMaterial.XTCList.SelectedTabPageIndex = 1
                    FormMasterRawMaterialDetSingle.action = "upd"

                    FormMasterRawMaterialDetSingle.id_mat = FormMasterRawMaterial.GVListMat.GetFocusedRowCellValue("id_mat").ToString
                    FormMasterRawMaterialDetSingle.LabelPrintedName.Text = FormMasterRawMaterial.GVListMat.GetFocusedRowCellDisplayText("mat_display_name").ToString
                    FormMasterRawMaterialDetSingle.TxtMaterialTypeCode.Text = FormMasterRawMaterial.GVListMat.GetFocusedRowCellDisplayText("mat_code").ToString

                    FormMasterRawMaterialDetSingle.id_mat_det = FormMasterRawMaterial.GVListMat.GetFocusedRowCellDisplayText("id_mat_det").ToString
                    FormMasterRawMaterialDetSingle.ShowDialog()
                End If
            ElseIf formName = "FormMasterOVH" Then
                FormMasterOVHSingle.id_ovh = FormMasterOVH.GVOVH.GetFocusedRowCellDisplayText("id_ovh").ToString
                FormMasterOVHSingle.ShowDialog()
            ElseIf formName = "FormProdDemand" Then
                FormProdDemandSingle.id_prod_demand = FormProdDemand.GVProdDemand.GetFocusedRowCellValue("id_prod_demand").ToString
                FormProdDemandSingle.id_prod_demand_ref = FormProdDemand.GVProdDemand.GetFocusedRowCellValue("id_prod_demand_ref").ToString
                FormProdDemandSingle.id_season = FormProdDemand.GVProdDemand.GetFocusedRowCellValue("id_season").ToString
                FormProdDemandSingle.TxtProdDemandNumber.Text = FormProdDemand.GVProdDemand.GetFocusedRowCellValue("prod_demand_number").ToString
                FormProdDemandSingle.ButtonEdit1.Text = FormProdDemand.GVProdDemand.GetFocusedRowCellValue("prod_demand_number_ref").ToString
                FormProdDemandSingle.MENote.Text = FormProdDemand.GVProdDemand.GetFocusedRowCellValue("prod_demand_note").ToString
                FormProdDemandSingle.id_report_status = FormProdDemand.GVProdDemand.GetFocusedRowCellValue("id_report_status").ToString
                FormProdDemandSingle.id_pd_type = FormProdDemand.GVProdDemand.GetFocusedRowCellValue("id_pd_type").ToString
                FormProdDemandSingle.id_division = FormProdDemand.GVProdDemand.GetFocusedRowCellValue("id_division").ToString
                FormProdDemandSingle.DEForm.EditValue = FormProdDemand.GVProdDemand.GetFocusedRowCellValue("prod_demand_date")
                FormProdDemandSingle.action = "upd"
                FormProdDemandSingle.id_pd = FormProdDemand.GVProdDemand.GetFocusedRowCellValue("is_pd").ToString
                FormProdDemandSingle.ShowDialog()
            ElseIf formName = "FormMasterCode" Then
                '
                If FormMasterCode.XTCCode.SelectedTabPageIndex = 0 Then
                    'code
                    FormMasterCodeSingle.id_code = FormMasterCode.GVCode.GetFocusedRowCellDisplayText("id_code").ToString
                    FormMasterCodeSingle.ShowDialog()
                ElseIf FormMasterCode.XTCCode.SelectedTabPageIndex = 1 Then
                    'code detail
                    FormMasterCodeDetSingle.id_code_det = FormMasterCode.GVCodeDetail.GetFocusedRowCellDisplayText("id_code_detail").ToString
                    FormMasterCodeDetSingle.id_code = FormMasterCode.GVCode.GetFocusedRowCellDisplayText("id_code").ToString
                    FormMasterCodeDetSingle.ShowDialog()
                End If
            ElseIf formName = "FormTemplateCode" Then
                '
                If FormTemplateCode.XTCTemplateCode.SelectedTabPageIndex = 0 Then
                    'code
                    FormTemplateCodeSingle.id_template_code = FormTemplateCode.GVTemplateCode.GetFocusedRowCellDisplayText("id_template_code").ToString
                    FormTemplateCodeSingle.ShowDialog()
                End If
            ElseIf formName = "FormMasterSample" Then
                '
                FormMasterSampleDet.id_sample = FormMasterSample.GVSample.GetFocusedRowCellDisplayText("id_sample").ToString
                FormMasterSampleDet.ShowDialog()
            ElseIf formName = "FormMasterProduct" Then
                '
                If FormMasterProduct.XTCProduct.SelectedTabPageIndex = 0 Then
                    'design
                    FormMasterDesignSingle.id_design = FormMasterProduct.GVDesign.GetFocusedRowCellDisplayText("id_design").ToString
                    FormMasterDesignSingle.WindowState = FormWindowState.Maximized
                    FormMasterDesignSingle.form_name = "FormMasterProduct"
                    FormMasterDesignSingle.ShowDialog()
                ElseIf FormMasterProduct.XTCProduct.SelectedTabPageIndex = 1 Then
                    'product
                    FormMasterProductDet.id_product = FormMasterProduct.GVProduct.GetFocusedRowCellDisplayText("id_product").ToString
                    FormMasterProductDet.id_design = FormMasterProduct.GVDesign.GetFocusedRowCellDisplayText("id_design").ToString
                    FormMasterProductDet.ShowDialog()
                End If
            ElseIf formName = "FormBOM" Then
                '
                If FormBOM.XTCBOMSelection.SelectedTabPageIndex = 1 Then
                    FormBOMSingle.id_bom = FormBOM.GVBOM.GetFocusedRowCellDisplayText("id_bom").ToString
                    FormBOMSingle.id_product = FormBOM.GVProduct.GetFocusedRowCellDisplayText("id_product").ToString
                    FormBOMSingle.ShowDialog()
                ElseIf FormBOM.XTCBOMSelection.SelectedTabPageIndex = 2 Then 'per design
                    FormBOMSingle.id_pop_up = "1"
                    FormBOMSingle.id_bom_approve = FormBOM.GVBOMPerDesign.GetFocusedRowCellValue("id_bom_approve").ToString
                    FormBOMSingle.id_design = FormBOM.GVPerDesign.GetFocusedRowCellDisplayText("id_design").ToString
                    FormBOMSingle.ShowDialog()
                Else ' per PD
                    'Try
                    If FormBOM.GVDesign.FocusedRowHandle < 0 Then
                        stopCustom("Please select proper design first!")
                    Else
                        FormBOMDesignSingle.id_pop_up = "1"
                        FormBOMDesignSingle.id_design = FormBOM.GVDesign.GetFocusedRowCellValue("id_design").ToString
                        FormBOMDesignSingle.TEQtyPD.EditValue = FormBOM.GVDesign.GetFocusedRowCellValue("qty")
                        FormBOMDesignSingle.id_prod_demand_design = FormBOM.GVDesign.GetFocusedRowCellValue("id_prod_demand_design").ToString
                        FormBOMDesignSingle.ShowDialog()
                    End If

                    'Catch ex As Exception
                    'stopCustom("Please select proper design first!")
                    'End Try
                End If
            ElseIf formName = "FormSamplePL" Then
                'PACKING LIST SAMPLE
                FormSamplePLSingle.action = "upd"
                FormSamplePLSingle.id_pl_sample_purc = FormSamplePL.GVPL.GetFocusedRowCellDisplayText("id_pl_sample_purc").ToString
                FormSamplePLSingle.id_comp_contact_to = FormSamplePL.GVPL.GetFocusedRowCellDisplayText("id_comp_contact_to").ToString
                FormSamplePLSingle.id_comp_contact_from = FormSamplePL.GVPL.GetFocusedRowCellDisplayText("id_comp_contact_from").ToString
                FormSamplePLSingle.id_sample_purc = FormSamplePL.GVPL.GetFocusedRowCellDisplayText("id_sample_purc").ToString
                FormSamplePLSingle.ShowDialog()
            ElseIf formName = "FormSamplePurchase" Then
                '
                FormSamplePurchaseDet.id_sample_purc = FormSamplePurchase.GVSamplePurchase.GetFocusedRowCellDisplayText("id_sample_purc").ToString
                FormSamplePurchaseDet.ShowDialog()
            ElseIf formName = "FormSampleReceive" Then
                '
                FormSampleReceiveDet.id_receive = FormSampleReceive.GVSampleReceive.GetFocusedRowCellDisplayText("id_sample_purc_rec").ToString
                FormSampleReceiveDet.ShowDialog()
            ElseIf formName = "FormSamplePR" Then
                '
                FormSamplePRDet.id_pr = FormSamplePR.GVSamplePR.GetFocusedRowCellDisplayText("id_pr_sample_purc").ToString
                FormSamplePRDet.ShowDialog()
            ElseIf formName = "FormMasterWH" Then
                'WAREHOUSE & LOCATOR
                If FormMasterWH.XTCWH.SelectedTabPageIndex = 1 Then 'Locator
                    FormMasterWHSingle.id_wh_locator = FormMasterWH.GVLocator.GetFocusedRowCellDisplayText("id_wh_locator").ToString
                    FormMasterWHSingle.action = "upd"
                    FormMasterWHSingle.ShowDialog()
                ElseIf FormMasterWH.XTCWH.SelectedTabPageIndex = 2 Then 'Rack
                    FormMasterWHRackSingle.id_wh_rack = FormMasterWH.GVRack.GetFocusedRowCellDisplayText("id_wh_rack").ToString
                    FormMasterWHRackSingle.action = "upd"
                    FormMasterWHRackSingle.ShowDialog()
                ElseIf FormMasterWH.XTCWH.SelectedTabPageIndex = 3 Then 'Drawer
                    FormMasterWHDrawerSingle.id_wh_drawer = FormMasterWH.GVDrawer.GetFocusedRowCellDisplayText("id_wh_drawer").ToString
                    FormMasterWHDrawerSingle.action = "upd"
                    FormMasterWHDrawerSingle.ShowDialog()
                End If
            ElseIf formName = "FormSampleReceipt" Then
                'RECEIPT SAMPLE
                FormSampleReceiptSingle.action = "upd"
                FormSampleReceiptSingle.id_pl_sample_purc = FormSampleReceipt.GVReceipt.GetFocusedRowCellDisplayText("id_pl_sample_purc").ToString
                FormSampleReceiptSingle.ShowDialog()
            ElseIf formName = "FormSampleRet" Then
                'RETURN SAMPLE
                If FormSampleRet.XTCReturn.SelectedTabPageIndex = 0 Then 'returnIn
                    FormSampleRetOutSingle.action = "upd"
                    FormSampleRetOutSingle.id_sample_purc_ret_out = FormSampleRet.GVRetOut.GetFocusedRowCellDisplayText("id_sample_purc_ret_out")
                    FormSampleRetOutSingle.ShowDialog()
                ElseIf FormSampleRet.XTCReturn.SelectedTabPageIndex = 1 Then 'Return Out
                    FormSampleRetInSingle.action = "upd"
                    FormSampleRetInSingle.id_sample_purc_ret_in = FormSampleRet.GVRetIn.GetFocusedRowCellDisplayText("id_sample_purc_ret_in")
                    FormSampleRetInSingle.ShowDialog()
                End If
            ElseIf formName = "FormSamplePLDel" Then
                'PACKING LIST SAMPLE DELIVERY
                FormSamplePLDelSingle.action = "upd"
                FormSamplePLDelSingle.id_pl_sample_del = FormSamplePLDel.GVPL.GetFocusedRowCellDisplayText("id_pl_sample_del").ToString
                FormSamplePLDelSingle.id_comp_contact_to = FormSamplePLDel.GVPL.GetFocusedRowCellDisplayText("id_comp_contact_to").ToString
                FormSamplePLDelSingle.id_comp_contact_from = FormSamplePLDel.GVPL.GetFocusedRowCellDisplayText("id_comp_contact_from").ToString
                FormSamplePLDelSingle.ShowDialog()
            ElseIf formName = "FormSampleReq" Then
                'SAMPLE REQUISITION
                FormSampleReqSingle.action = "upd"
                FormSampleReqSingle.id_sample_requisition = FormSampleReq.GVReq.GetFocusedRowCellDisplayText("id_sample_requisition").ToString
                FormSampleReqSingle.ShowDialog()
            ElseIf formName = "FormMarkAssign" Then
                'Assing Mark
                FormMarkAssignSingle.id_mark_asg = FormMarkAssign.GVMarkAssign.GetFocusedRowCellDisplayText("id_mark_asg")
                FormMarkAssignSingle.ShowDialog()
            ElseIf formName = "FormSamplePlan" Then
                'Sample Plan
                FormSamplePlanDet.id_sample_plan = FormSamplePlan.GVSamplePurchase.GetFocusedRowCellDisplayText("id_sample_plan")
                FormSamplePlanDet.ShowDialog()
            ElseIf formName = "FormMatPurchase" Then
                'Material Purchase
                FormMatPurchaseDet.id_purc = FormMatPurchase.GVMatPurchase.GetFocusedRowCellDisplayText("id_mat_purc")
                FormMatPurchaseDet.ShowDialog()
            ElseIf formName = "FormSampleReturn" Then
                'SAMPLE RETURN
                FormSampleReturnSingle.action = "upd"
                FormSampleReturnSingle.id_sample_return = FormSampleReturn.GVRetSample.GetFocusedRowCellDisplayText("id_sample_return").ToString
                FormSampleReturnSingle.id_comp_contact_to = FormSampleReturn.GVRetSample.GetFocusedRowCellValue("id_comp_contact_to").ToString
                FormSampleReturnSingle.id_comp_contact_from = FormSampleReturn.GVRetSample.GetFocusedRowCellValue("id_comp_contact_from").ToString
                FormSampleReturnSingle.ShowDialog()
            ElseIf formName = "FormMatWO" Then
                'Material WO
                FormMatWODet.id_purc = FormMatWO.GVMatWO.GetFocusedRowCellDisplayText("id_mat_wo")
                FormMatWODet.ShowDialog()
            ElseIf formName = "FormMatRecPurc" Then
                'Receive Material Purchase
                FormMatRecPurcDet.id_receive = FormMatRecPurc.GVMatRecPurc.GetFocusedRowCellDisplayText("id_mat_purc_rec")
                FormMatRecPurcDet.ShowDialog()
            ElseIf formName = "FormMatRecWO" Then
                'Receive Material Purchase
                FormMatRecWODet.id_receive = FormMatRecWO.GVMatRecPurc.GetFocusedRowCellDisplayText("id_mat_wo_rec")
                FormMatRecWODet.ShowDialog()
            ElseIf formName = "FormMatRet" Then
                'RETURN Mat
                If FormMatRet.XTCReturnMat.SelectedTabPageIndex = 0 Then 'ret purchase
                    If FormMatRet.XTCReturnPruchase.SelectedTabPageIndex = 0 Then 'return Out
                        FormMatRetOutDet.action = "upd"
                        FormMatRetOutDet.id_mat_purc_ret_out = FormMatRet.GVRetOut.GetFocusedRowCellDisplayText("id_mat_purc_ret_out")
                        FormMatRetOutDet.ShowDialog()
                    ElseIf FormMatRet.XTCReturnPruchase.SelectedTabPageIndex = 1 Then 'Return In
                        FormMatRetInDet.action = "upd"
                        FormMatRetInDet.id_mat_purc_ret_in = FormMatRet.GVRetIn.GetFocusedRowCellDisplayText("id_mat_purc_ret_in")
                        FormMatRetInDet.ShowDialog()
                    End If
                ElseIf FormMatRet.XTCReturnMat.SelectedTabPageIndex = 1 Then 'ret production
                    If FormMatRet.XTCReturnProd.SelectedTabPageIndex = 0 Then 'return In
                        FormMatRetInProd.action = "upd"
                        FormMatRetInProd.id_mat_prod_ret_in = FormMatRet.GVRetInProd.GetFocusedRowCellDisplayText("id_mat_prod_ret_in")
                        FormMatRetInProd.ShowDialog()
                    End If
                End If
            ElseIf formName = "FormSampleAdjustment" Then
                'SAMPLE ADJUSTMENT
                If FormSampleAdjustment.XTCAdj.SelectedTabPageIndex = "0" Then
                    FormSampleAdjustmentInSingle.action = "upd"
                    FormSampleAdjustmentInSingle.id_adj_in_sample = FormSampleAdjustment.GVAdjSampleIn.GetFocusedRowCellDisplayText("id_adj_in_sample").ToString
                    FormSampleAdjustmentInSingle.ShowDialog()
                ElseIf FormSampleAdjustment.XTCAdj.SelectedTabPageIndex = "1" Then
                    FormSampleAdjustmentOutSingle.action = "upd"
                    FormSampleAdjustmentOutSingle.id_adj_out_sample = FormSampleAdjustment.GVAdjOutSample.GetFocusedRowCellDisplayText("id_adj_out_sample").ToString
                    FormSampleAdjustmentOutSingle.ShowDialog()
                End If
            ElseIf formName = "FormMatAdj" Then
                'MATERIAL ADJUSTMENT
                If FormMatAdj.XTCAdj.SelectedTabPageIndex = "0" Then
                    FormMatAdjInSingle.action = "upd"
                    FormMatAdjInSingle.id_adj_in_mat = FormMatAdj.GVAdjIn.GetFocusedRowCellDisplayText("id_adj_in_mat").ToString
                    FormMatAdjInSingle.ShowDialog()
                ElseIf FormMatAdj.XTCAdj.SelectedTabPageIndex = "1" Then
                    FormMatAdjOutSingle.action = "upd"
                    FormMatAdjOutSingle.id_adj_out_mat = FormMatAdj.GVAdjOut.GetFocusedRowCellDisplayText("id_adj_out_mat").ToString
                    FormMatAdjOutSingle.ShowDialog()
                End If
            ElseIf formName = "FormProduction" Then
                'Production
                If FormProduction.XTCTabProduction.SelectedTabPageIndex = 0 Then 'prod order
                    FormProductionDet.id_prod_order = FormProduction.GVProd.GetFocusedRowCellDisplayText("id_prod_order").ToString
                    FormProductionDet.ShowDialog()
                End If
            ElseIf formName = "FormMatPL" Then
                If FormMatPL.XTCPL.SelectedTabPageIndex = 0 Then 'Production
                    FormMatPLSingle.action = "upd"
                    FormMatPLSingle.id_pl_mrs = FormMatPL.GVProdPL.GetFocusedRowCellDisplayText("id_pl_mrs").ToString
                    FormMatPLSingle.id_comp_contact_to = FormMatPL.GVProdPL.GetFocusedRowCellDisplayText("id_comp_contact_to").ToString
                    FormMatPLSingle.id_comp_contact_from = FormMatPL.GVProdPL.GetFocusedRowCellDisplayText("id_comp_contact_from").ToString
                    FormMatPLSingle.ShowDialog()
                ElseIf FormMatPL.XTCPL.SelectedTabPageIndex = 1 Then 'wo
                    FormMatPLSingle.action = "upd"
                    FormMatPLSingle.is_other = "1"
                    FormMatPLSingle.id_pl_mrs = FormMatPL.GVPLWO.GetFocusedRowCellDisplayText("id_pl_mrs").ToString
                    FormMatPLSingle.id_comp_contact_to = FormMatPL.GVPLWO.GetFocusedRowCellDisplayText("id_comp_contact_to").ToString
                    FormMatPLSingle.id_comp_contact_from = FormMatPL.GVPLWO.GetFocusedRowCellDisplayText("id_comp_contact_from").ToString
                    FormMatPLSingle.ShowDialog()
                ElseIf FormMatPL.XTCPL.SelectedTabPageIndex = 2 Then 'Other
                    FormMatPLSingle.action = "upd"
                    FormMatPLSingle.is_other = "1"
                    FormMatPLSingle.id_pl_mrs = FormMatPL.GVPLOther.GetFocusedRowCellDisplayText("id_pl_mrs").ToString
                    FormMatPLSingle.id_comp_contact_to = FormMatPL.GVPLOther.GetFocusedRowCellDisplayText("id_comp_contact_to").ToString
                    FormMatPLSingle.id_comp_contact_from = FormMatPL.GVPLOther.GetFocusedRowCellDisplayText("id_comp_contact_from").ToString
                    FormMatPLSingle.ShowDialog()
                End If
            ElseIf formName = "FormMatMRS" Then
                If FormMatMRS.XTCMRS.SelectedTabPageIndex = 0 Then 'mat wo
                    FormMatMRSDet.id_mrs = FormMatMRS.GVMRSWO.GetFocusedRowCellDisplayText("id_prod_order_mrs").ToString
                    FormMatMRSDet.mrs_type = "2"
                    FormMatMRSDet.id_comp_req_from = FormMatMRS.GVMRSWO.GetFocusedRowCellValue("id_comp_name_req_from").ToString
                    FormMatMRSDet.id_comp_req_to = FormMatMRS.GVMRSWO.GetFocusedRowCellValue("id_comp_name_req_to").ToString
                    FormMatMRSDet.TEMRSNumber.Text = FormMatMRS.GVMRSWO.GetFocusedRowCellValue("prod_order_mrs_number").ToString
                    FormMatMRSDet.ShowDialog()
                ElseIf FormMatMRS.XTCMRS.SelectedTabPageIndex = 1 Then 'other
                    FormMatMRSDet.id_mrs = FormMatMRS.GVMRS.GetFocusedRowCellDisplayText("id_prod_order_mrs").ToString
                    FormMatMRSDet.mrs_type = "1"
                    FormMatMRSDet.id_comp_req_from = FormMatMRS.GVMRS.GetFocusedRowCellValue("id_comp_name_req_from").ToString
                    FormMatMRSDet.id_comp_req_to = FormMatMRS.GVMRS.GetFocusedRowCellValue("id_comp_name_req_to").ToString
                    FormMatMRSDet.TEMRSNumber.Text = FormMatMRS.GVMRS.GetFocusedRowCellValue("prod_order_mrs_number").ToString
                    FormMatMRSDet.ShowDialog()
                End If
            ElseIf formName = "FormMatPR" Then
                FormMatPRDet.id_pr = FormMatPR.GVMatPR.GetFocusedRowCellDisplayText("id_pr_mat_purc").ToString
                FormMatPRDet.ShowDialog()
            ElseIf formName = "FormMatPRWO" Then
                FormMatPRWODet.id_pr = FormMatPRWO.GVMatPRWO.GetFocusedRowCellDisplayText("id_pr_mat_wo").ToString
                FormMatPRWODet.ShowDialog()
            ElseIf formName = "FormProductionRec" Then
                'Receive QC FG
                FormProductionRecDet.id_receive = FormProductionRec.GVProdRec.GetFocusedRowCellDisplayText("id_prod_order_rec")
                FormProductionRecDet.ShowDialog()
            ElseIf formName = "FormProductionRet" Then
                'RETURN FG
                If FormProductionRet.XTCReturn.SelectedTabPageIndex = 0 Then 'return Out
                    FormProductionRetOutSingle.action = "upd"
                    FormProductionRetOutSingle.id_prod_order_ret_out = FormProductionRet.GVRetOut.GetFocusedRowCellDisplayText("id_prod_order_ret_out")
                    FormProductionRetOutSingle.ShowDialog()
                ElseIf FormProductionRet.XTCReturn.SelectedTabPageIndex = 1 Then 'Return In
                    FormProductionRetInSingle.action = "upd"
                    FormProductionRetInSingle.id_prod_order_ret_in = FormProductionRet.GVRetIn.GetFocusedRowCellDisplayText("id_prod_order_ret_in")
                    FormProductionRetInSingle.ShowDialog()
                End If
            ElseIf formName = "FormProductionPLToWH" Then
                FormProductionPLToWHDet.action = "upd"
                FormProductionPLToWHDet.id_pl_prod_order = FormProductionPLToWH.GVPL.GetFocusedRowCellDisplayText("id_pl_prod_order")
                FormProductionPLToWHDet.ShowDialog()
            ElseIf formName = "FormMatInvoice" Then
                If FormMatInvoice.XTCTabGeneral.SelectedTabPageIndex = 0 Then 'invoice
                    'Mat Invoice
                    FormMatInvoiceDet.id_invoice = FormMatInvoice.GVProdInvoice.GetFocusedRowCellValue("id_inv_pl_mrs").ToString
                    FormMatInvoiceDet.id_comp_to = FormMatInvoice.GVProdInvoice.GetFocusedRowCellValue("id_comp_contact_to").ToString

                    FormMatInvoiceDet.TEWONumber.Text = FormMatInvoice.GVProdInvoice.GetFocusedRowCellValue("prod_order_wo_number").ToString
                    FormMatInvoiceDet.TEPONumber.Text = FormMatInvoice.GVProdInvoice.GetFocusedRowCellValue("prod_order_number").ToString
                    FormMatInvoiceDet.TEDesign.Text = FormMatInvoice.GVProdInvoice.GetFocusedRowCellValue("design_name").ToString

                    FormMatInvoiceDet.id_prod_order_wo = FormMatInvoice.GVProdInvoice.GetFocusedRowCellValue("id_prod_order_wo").ToString
                    FormMatInvoiceDet.ShowDialog()
                Else 'retur
                    FormMatInvoiceReturDet.id_retur = FormMatInvoice.GVRetur.GetFocusedRowCellValue("id_inv_pl_mrs_ret").ToString
                    FormMatInvoiceReturDet.id_invoice = FormMatInvoice.GVRetur.GetFocusedRowCellValue("id_inv_pl_mrs").ToString
                    FormMatInvoiceReturDet.id_comp_to = FormMatInvoice.GVRetur.GetFocusedRowCellValue("id_comp_contact_from").ToString

                    FormMatInvoiceReturDet.TEReturNumber.Text = FormMatInvoice.GVRetur.GetFocusedRowCellValue("inv_pl_mrs_ret_number").ToString
                    FormMatInvoiceReturDet.TEInvNumber.Text = FormMatInvoice.GVRetur.GetFocusedRowCellValue("inv_pl_mrs_number").ToString
                    FormMatInvoiceReturDet.TEWONumber.Text = FormMatInvoice.GVRetur.GetFocusedRowCellValue("prod_order_wo_number").ToString
                    FormMatInvoiceReturDet.TEPONumber.Text = FormMatInvoice.GVRetur.GetFocusedRowCellValue("prod_order_number").ToString
                    FormMatInvoiceReturDet.TEDesign.Text = FormMatInvoice.GVRetur.GetFocusedRowCellValue("design_name").ToString

                    FormMatInvoiceReturDet.id_prod_wo = FormMatInvoice.GVRetur.GetFocusedRowCellValue("id_prod_order_wo").ToString
                    FormMatInvoiceReturDet.ShowDialog()
                End If
            ElseIf formName = "FormAccounting" Then
                If FormAccounting.XTCGeneral.SelectedTabPageIndex = 0 Then 'view master
                    FormAccountingAcc.id_acc = FormAccounting.GVAcc.GetFocusedRowCellValue("id_acc").ToString
                    FormAccountingAcc.ShowDialog()
                Else
                    FormAccountingAcc.id_acc = FormAccounting.TreeList1.FocusedNode("id_acc").ToString
                    FormAccountingAcc.ShowDialog()
                End If
            ElseIf formName = "FormAccountingJournal" Then
                FormAccountingJournalBill.id_trans = FormAccountingJournal.GVAccTrans.GetFocusedRowCellValue("id_acc_trans").ToString
                FormAccountingJournalBill.TEUserEntry.Text = FormAccountingJournal.GVAccTrans.GetFocusedRowCellValue("employee_name").ToString
                FormAccountingJournalBill.ShowDialog()
            ElseIf formName = "FormProductionPLToWHRec" Then
                FormProductionPLToWHRecDet.action = "upd"
                FormProductionPLToWHRecDet.id_pl_prod_order_rec = FormProductionPLToWHRec.GVPL.GetFocusedRowCellDisplayText("id_pl_prod_order_rec")
                FormProductionPLToWHRecDet.ShowDialog()
            ElseIf formName = "FormSalesTarget" Then
                'SALES TARGET
                If FormSalesTarget.XTCSalesTarget.SelectedTabPageIndex = 0 Then
                    FormSalesTargetDet.action = "upd"
                    FormSalesTargetDet.id_sales_target = FormSalesTarget.GVSalesTarget.GetFocusedRowCellValue("id_sales_target").ToString
                    FormSalesTargetDet.ShowDialog()
                End If
            ElseIf formName = "FormSalesOrder" Then
                'SALES ORDER
                If FormSalesOrder.XTCSOGeneral.SelectedTabPageIndex = 0 Then
                    FormSalesOrderDet.action = "upd"
                    FormSalesOrderDet.id_sales_order = FormSalesOrder.GVSalesOrder.GetFocusedRowCellValue("id_sales_order").ToString
                    FormSalesOrderDet.ShowDialog()
                ElseIf FormSalesOrder.XTCSOGeneral.SelectedTabPageIndex = 1 Then
                    FormSalesOrderGen.action = "upd"
                    FormSalesOrderGen.id_sales_order_gen = FormSalesOrder.GVGen.GetFocusedRowCellValue("id_sales_order_gen").ToString
                    FormSalesOrderGen.ShowDialog()
                End If
            ElseIf formName = "FormSalesDelOrder" Then
                'SALES DELIVERY ORDER
                FormSalesDelOrderDet.action = "upd"
                FormSalesDelOrderDet.id_pl_sales_order_del = FormSalesDelOrder.GVSalesDelOrder.GetFocusedRowCellValue("id_pl_sales_order_del").ToString
                FormSalesDelOrderDet.ShowDialog()
            ElseIf formName = "FormSalesReturnOrder" Then
                'SALES RETURN ORDER
                FormSalesReturnOrderDet.action = "upd"
                FormSalesReturnOrderDet.id_sales_return_order = FormSalesReturnOrder.GVSalesReturnOrder.GetFocusedRowCellValue("id_sales_return_order").ToString
                FormSalesReturnOrderDet.ShowDialog()
            ElseIf formName = "FormSalesReturn" Then
                'SALES RETURN
                FormSalesReturnDet.action = "upd"
                FormSalesReturnDet.id_sales_return = FormSalesReturn.GVSalesReturn.GetFocusedRowCellValue("id_sales_return").ToString
                FormSalesReturnDet.ShowDialog()
            ElseIf formName = "FormSalesPOS" Then
                'SALES POS
                FormSalesPOSDet.action = "upd"
                FormSalesPOSDet.id_sales_pos = FormSalesPOS.GVSalesPOS.GetFocusedRowCellValue("id_sales_pos").ToString
                FormSalesPOSDet.ShowDialog()
            ElseIf formName = "FormSalesReturnQC" Then
                'SALES RETURN QC
                FormSalesReturnQCDet.action = "upd"
                FormSalesReturnQCDet.id_sales_return_qc = FormSalesReturnQC.GVSalesReturnQC.GetFocusedRowCellValue("id_sales_return_qc").ToString
                FormSalesReturnQCDet.ShowDialog()
            ElseIf formName = "FormProdPRWO" Then
                FormProdPRWODet.id_pr = FormProdPRWO.GVMatPR.GetFocusedRowCellValue("id_pr_prod_order").ToString
                'FormProdPRWODet.id_prod_order = FormProdPRWO.GVMatPR.GetFocusedRowCellValue("id_prod_order")
                'FormProdPRWODet.id_prod_order_wo = FormProdPRWO.GVMatPR.GetFocusedRowCellValue("id_prod_order_wo")
                FormProdPRWODet.ShowDialog()
            ElseIf formName = "FormSalesInvoice" Then
                'SALES INVOICE
                FormSalesInvoiceDet.action = "upd"
                FormSalesInvoiceDet.id_sales_invoice = FormSalesInvoice.GVSalesInvoice.GetFocusedRowCellValue("id_sales_invoice").ToString
                FormSalesInvoiceDet.ShowDialog()
            ElseIf formName = "FormFGStockOpnameStore" Then
                'STORE STOCK OPNAME
                FormFGStockOpnameStoreDet.action = "upd"
                FormFGStockOpnameStoreDet.id_fg_so_store = FormFGStockOpnameStore.GVSOStore.GetFocusedRowCellValue("id_fg_so_store").ToString
                FormFGStockOpnameStoreDet.ShowDialog()
            ElseIf formName = "FormFGMissing" Then
                'FG MIssing
                If FormFGMissing.XTCFGMissing.SelectedTabPageIndex = 0 Then
                    FormFGMissingDet.action = "upd"
                    FormFGMissingDet.id_fg_missing = FormFGMissing.GVFGMissing.GetFocusedRowCellValue("id_sales_pos").ToString
                    FormFGMissingDet.ShowDialog()
                ElseIf FormFGMissing.XTCFGMissing.SelectedTabPageIndex = 1 Then
                    FormFGMissingWHDet.action = "upd"
                    FormFGMissingWHDet.id_fg_missing = FormFGMissing.GVMissingWH.GetFocusedRowCellValue("id_sales_pos").ToString
                    FormFGMissingWHDet.ShowDialog()
                End If
            ElseIf formName = "FormFGMissingInvoice" Then
                'FG MISSING INVOICE 
                FormFGMissingInvoiceDet.action = "upd"
                FormFGMissingInvoiceDet.id_fg_missing_invoice = FormFGMissingInvoice.GVFGMissingInvoice.GetFocusedRowCellValue("id_fg_missing_invoice").ToString
                FormFGMissingInvoiceDet.ShowDialog()
            ElseIf formName = "FormFGStockOpnameWH" Then
                'WH STOCK OPNAME
                FormFGStockOpnameWHDet.action = "upd"
                FormFGStockOpnameWHDet.id_fg_so_wh = FormFGStockOpnameWH.GVSOWH.GetFocusedRowCellValue("id_fg_so_wh").ToString
                FormFGStockOpnameWHDet.ShowDialog()
            ElseIf formName = "FormMatStockOpname" Then
                If Not FormMatStockOpname.GVMatPR.IsGroupRow(FormMatStockOpname.GVMatPR.FocusedRowHandle) Then
                    FormMatStockOpnameDet.id_mat_so = FormMatStockOpname.GVMatPR.GetFocusedRowCellValue("id_mat_so").ToString
                    FormMatStockOpnameDet.ShowDialog()
                End If
            ElseIf formName = "FormFGAdj" Then
                'FG ADJUSTMENT
                If FormFGAdj.XTCAdj.SelectedTabPageIndex = "0" Then
                    FormFGAdjInDet.action = "upd"
                    FormFGAdjInDet.id_adj_in_fg = FormFGAdj.GVAdjIn.GetFocusedRowCellValue("id_adj_in_fg").ToString
                    FormFGAdjInDet.ShowDialog()
                ElseIf FormFGAdj.XTCAdj.SelectedTabPageIndex = "1" Then
                    FormFGAdjOutDet.action = "upd"
                    FormFGAdjOutDet.id_adj_out_fg = FormFGAdj.GVAdjOut.GetFocusedRowCellDisplayText("id_adj_out_fg").ToString
                    FormFGAdjOutDet.ShowDialog()
                End If
            ElseIf formName = "FormFGTrf" Then
                'FG Transfer Future
                FormFGTrfDet.action = "upd"
                FormFGTrfDet.id_fg_trf = FormFGTrf.GVFGTrf.GetFocusedRowCellValue("id_fg_trf").ToString
                FormFGTrfDet.ShowDialog()
            ElseIf formName = "FormFGTrfNew" Then
                'FG Transfer
                FormFGTrfNewDet.action = "upd"
                FormFGTrfNewDet.id_fg_trf = FormFGTrfNew.GVFGTrf.GetFocusedRowCellValue("id_fg_trf").ToString
                FormFGTrfNewDet.ShowDialog()
            ElseIf formName = "FormFGTrfReceive" Then
                'FG Transfer
                FormFGTrfDet.id_type = "1"
                FormFGTrfDet.action = "upd"
                FormFGTrfDet.id_fg_trf = FormFGTrfReceive.GVFGTrf.GetFocusedRowCellValue("id_fg_trf").ToString
                FormFGTrfDet.ShowDialog()
            ElseIf formName = "FormMasterEmployee" Then
                'Master Employee
                FormMasterEmployeeNewDet.id_employee = FormMasterEmployee.GVEmployee.GetFocusedRowCellValue("id_employee").ToString
                FormMasterEmployeeNewDet.action = "upd"
                FormMasterEmployeeNewDet.ShowDialog()
            ElseIf formName = "FormSampleDel" Then
                'PL Sample Delivery
                FormSampleDelDet.action = "upd"
                FormSampleDelDet.id_sample_del = FormSampleDel.GVSampleDel.GetFocusedRowCellValue("id_sample_del").ToString
                FormSampleDelDet.ShowDialog()
            ElseIf formName = "FormSampleDelRec" Then
                'Rec PL Sample Delivery
                FormSampleDelRecDet.action = "upd"
                FormSampleDelRecDet.id_sample_del_rec = FormSampleDelRec.GVSampleDelRec.GetFocusedRowCellValue("id_sample_del_rec").ToString
                FormSampleDelRecDet.ShowDialog()
            ElseIf formName = "FormSampleOrder" Then
                'Sales Order Sample
                FormSampleOrderDet.action = "upd"
                FormSampleOrderDet.id_sample_order = FormSampleOrder.GVSampleOrder.GetFocusedRowCellValue("id_sample_order").ToString
                FormSampleOrderDet.ShowDialog()
            ElseIf formName = "FormSampleDelOrder" Then
                'DELIVERY ORDER SAMPLE FOR SALES
                If FormSampleDelOrder.XTCSampleDelOrder.SelectedTabPageIndex = 0 Then
                    FormSampleDelOrderDet.id_pl_sample_order_del = FormSampleDelOrder.GVSampleDelOrder.GetFocusedRowCellValue("id_pl_sample_order_del").ToString
                    FormSampleDelOrderDet.action = "upd"
                    FormSampleDelOrderDet.ShowDialog()
                End If
            ElseIf formName = "FormFGCodeReplace" Then
                'CODE REPLACEMENT FG STORE
                If FormFGCodeReplace.XTCFGCodeReplace.SelectedTabPageIndex = 0 Then
                    FormFGCodeReplaceStoreDet.action = "upd"
                    FormFGCodeReplaceStoreDet.id_fg_code_replace_store = FormFGCodeReplace.GVFGCodeReplaceStore.GetFocusedRowCellValue("id_fg_code_replace_store").ToString
                    FormFGCodeReplaceStoreDet.ShowDialog()
                ElseIf FormFGCodeReplace.XTCFGCodeReplace.SelectedTabPageIndex = 1 Then
                    FormFGCodeReplaceWHDet.action = "upd"
                    FormFGCodeReplaceWHDet.id_fg_code_replace_wh = FormFGCodeReplace.GVFGCodeReplaceWH.GetFocusedRowCellValue("id_fg_code_replace_wh").ToString
                    FormFGCodeReplaceWHDet.ShowDialog()
                End If
            ElseIf formName = "FormSampleStockOpname" Then
                'Sales Order Sample
                FormSampleStockOpnameDet.action = "upd"
                FormSampleStockOpnameDet.id_sample_so = FormSampleStockOpname.GVSOWH.GetFocusedRowCellValue("id_sample_so").ToString
                FormSampleStockOpnameDet.ShowDialog()
            ElseIf formName = "FormSalesCreditNote" Then
                'CREDIT NOTE SALES
                FormSalesCreditNoteDet.action = "upd"
                FormSalesCreditNoteDet.id_sales_pos = FormSalesCreditNote.GVSalesPOS.GetFocusedRowCellValue("id_sales_pos").ToString
                FormSalesCreditNoteDet.ShowDialog()
            ElseIf formName = "FormFGMissingCreditNote" Then
                'CREDIT NOTE MISSING
                If FormFGMissingCreditNote.XTCFGMissingCN.SelectedTabPageIndex = 0 Then
                    FormFGMissingCreditNoteStoreDet.action = "upd"
                    FormFGMissingCreditNoteStoreDet.id_sales_pos = FormFGMissingCreditNote.GVFGMissingCNStore.GetFocusedRowCellValue("id_sales_pos").ToString
                    FormFGMissingCreditNoteStoreDet.ShowDialog()
                End If
            ElseIf formName = "FormSOHPeriode" Then
                'SOH PERIODE
                FormSOHPeriodeDet.id_soh_periode = FormSOHPeriode.GVSOHPeriode.GetFocusedRowCellValue("id_soh_periode").ToString
                FormSOHPeriodeDet.ShowDialog()
            ElseIf formName = "FormSOH" Then
                'SOH
                FormSOHDet.id_soh = FormSOH.BGVSOH.GetFocusedRowCellValue("id_soh").ToString
                FormSOHDet.ShowDialog()
            ElseIf formName = "FormSOHPrice" Then
                'SOH PRICE
                FormSOHPriceDet.id_soh_periode = FormSOHPrice.GVSOHPeriode.GetFocusedRowCellValue("id_soh_periode").ToString
                FormSOHPriceDet.TERange.Text = FormSOHPrice.GVSOHPeriode.GetFocusedRowCellValue("soh_periode").ToString
                FormSOHPriceDet.TERangeDesc.Text = FormSOHPrice.GVSOHPeriode.GetFocusedRowCellDisplayText("date_start").ToString + " - " + FormSOHPrice.GVSOHPeriode.GetFocusedRowCellDisplayText("date_end").ToString
                FormSOHPriceDet.ShowDialog()
            ElseIf formName = "FormFGWoff" Then
                'FG WRITE OFF
                FormFGWoffDet.id_fg_woff = FormFGWoff.GVFGWoff.GetFocusedRowCellValue("id_fg_woff").ToString
                FormFGWoffDet.action = "upd"
                FormFGWoffDet.ShowDialog()
            ElseIf formName = "FormFGProposePrice" Then
                'FG PROPOSE PRICE
                FormFGProposePriceDet.id_fg_propose_price = FormFGProposePrice.GVFGPropose.GetFocusedRowCellValue("id_fg_propose_price").ToString
                FormFGProposePriceDet.action = "upd"
                FormFGProposePriceDet.ShowDialog()
            ElseIf formName = "FormMasterRetCode" Then
                'MASTER RET CODE
                FormMasterRetCodeDet.id_ret_code = FormMasterRetCode.GVRetCode.GetFocusedRowCellValue("id_ret_code").ToString
                FormMasterRetCodeDet.action = "upd"
                FormMasterRetCodeDet.ShowDialog()
            ElseIf formName = "FormMasterDesignCOP" Then
                'MASTER RET CODE
                FormProductionCOP.id_design = FormMasterDesignCOP.BGVDesign.GetFocusedRowCellValue("id_design").ToString
                FormProductionCOP.ShowDialog()
            ElseIf formName = "FormSampleOrdered" Then
                'SAMPLE ORDERED
                FormSampleOrderedDet.id_sample_ordered = FormSampleOrdered.GVSampleOrder.GetFocusedRowCellValue("id_sample_ordered").ToString
                FormSampleOrderedDet.ShowDialog()
            ElseIf formName = "FormMasterRateStore" Then
                'MASTER RATE STORE
                FormMasterRateStoreDet.id_store_rate = FormMasterRateStore.GVStoreRate.GetFocusedRowCellValue("id_store_rate").ToString
                FormMasterRateStoreDet.action = "upd"
                FormMasterRateStoreDet.ShowDialog()
            ElseIf formName = "FormProdQCAdj" Then
                'QC Adj In
                If FormProdQCAdj.XTCAdj.SelectedTabPageIndex = 0 Then
                    If FormProdQCAdj.GVAdjIn.RowCount > 0 Then
                        FormProdQCAdjIn.id_adj_in = FormProdQCAdj.GVAdjIn.GetFocusedRowCellValue("id_prod_order_qc_adj_in").ToString
                        FormProdQCAdjIn.ShowDialog()
                    Else
                        stopCustom("Nothing to edit.")
                    End If
                Else
                    If FormProdQCAdj.GVAdjOut.RowCount > 0 Then
                        FormProdQCAdjOut.id_adj_out = FormProdQCAdj.GVAdjOut.GetFocusedRowCellValue("id_prod_order_qc_adj_out").ToString
                        FormProdQCAdjOut.ShowDialog()
                    Else
                        stopCustom("Nothing to edit.")
                    End If
                End If
            ElseIf formName = "FormSalesPromo" Then
                'Sales Promo
                FormSalesPromoDet.id_sales_pos = FormSalesPromo.GVSalesPOS.GetFocusedRowCellValue("id_sales_pos").ToString
                FormSalesPromoDet.action = "upd"
                FormSalesPromoDet.ShowDialog()
            ElseIf formName = "FormFGSalesOrderReff" Then
                FormFGSalesOrderReffDet.action = "upd"
                FormFGSalesOrderReffDet.id_fg_so_reff = FormFGSalesOrderReff.GVSOReff.GetFocusedRowCellValue("id_fg_so_reff").ToString
                FormFGSalesOrderReffDet.ShowDialog()
            ElseIf formName = "FormMasterComputer" Then
                'MASTER COMPUTER
                FormMasterComnputerDet.id_computer = FormMasterComputer.GVComputer.GetFocusedRowCellValue("id_computer").ToString
                FormMasterComnputerDet.action = "upd"
                FormMasterComnputerDet.ShowDialog()
            ElseIf formName = "FormAccountingFakturScan" Then
                FormAccountingFakturScanSingle.action = "upd"
                FormAccountingFakturScanSingle.id_acc_fak_scan = FormAccountingFakturScan.GVFak.GetFocusedRowCellValue("id_acc_fak_scan").ToString
                FormAccountingFakturScanSingle.ShowDialog()
            ElseIf formName = "FormFGBorrowQCReq" Then
                FormFGBorrowQCReqSingle.action = "upd"
                FormFGBorrowQCReqSingle.id_borrow_qc_req = FormFGBorrowQCReq.GVBorrowReq.GetFocusedRowCellValue("id_borrow_qc_req").ToString
                FormFGBorrowQCReqSingle.ShowDialog()
            ElseIf formName = "FormWHAWBill"
                If FormWHAWBill.XTCAwb.SelectedTabPageIndex = 0 Then
                    FormWHAWBillDet.id_awb = FormWHAWBill.GVAWBill.GetFocusedRowCellValue("id_awbill").ToString
                    FormWHAWBillDet.id_awb_type = "1"
                    FormWHAWBillDet.ShowDialog()
                Else
                    FormWHAWBillIn.id_awb = FormWHAWBill.GVAwbillIn.GetFocusedRowCellValue("id_awbill").ToString
                    FormWHAWBillIn.id_awb_type = "2"
                    FormWHAWBillIn.ShowDialog()
                End If
            ElseIf formName = "FormMasterPrice" Then
                FormMasterPriceSingle.action = "upd"
                FormMasterPriceSingle.id_fg_price = FormMasterPrice.GVPrice.GetFocusedRowCellValue("id_fg_price").ToString
                FormMasterPriceSingle.ShowDialog()
            ElseIf formName = "FormFGDesignList" Then
                FormMasterDesignSingle.id_pop_up = "5"
                FormMasterDesignSingle.form_name = "FormFGDesignList"
                FormMasterDesignSingle.id_design = FormFGDesignList.GVDesign.GetFocusedRowCellValue("id_design").ToString
                FormMasterDesignSingle.WindowState = FormWindowState.Maximized
                FormMasterDesignSingle.ShowDialog()
            ElseIf formName = "FormSamplePLToWH" Then
                'PACING LIST SAMPLE
                FormSamplePLToWHDet.action = "upd"
                FormSamplePLToWHDet.id_sample_pl = FormSamplePLToWH.GVSamplePL.GetFocusedRowCellValue("id_sample_pl").ToString
                FormSamplePLToWHDet.ShowDialog()
            ElseIf formName = "FormMasterPriceSample" Then
                FormMasterPriceSampleSingle.action = "upd"
                FormMasterPriceSampleSingle.id_sample_price = FormMasterPriceSample.GVPrice.GetFocusedRowCellValue("id_sample_price").ToString
                FormMasterPriceSampleSingle.ShowDialog()
            ElseIf formName = "FormFGWHAlloc" Then
                'INVENTORY ALLOCATION
                FormFGWHAllocDet.action = "upd"
                FormFGWHAllocDet.id_fg_wh_alloc = FormFGWHAlloc.GVFGWHAlloc.GetFocusedRowCellValue("id_fg_wh_alloc").ToString
                FormFGWHAllocDet.ShowDialog()
            ElseIf formName = "FormSampleReturnPL" Then
                'PACKING LIST SAMPLE
                FormSampleReturnPLDet.action = "upd"
                FormSampleReturnPLDet.id_sample_pl = FormSampleReturnPL.GVSamplePL.GetFocusedRowCellValue("id_sample_pl_ret").ToString
                FormSampleReturnPLDet.ShowDialog()
            ElseIf formName = "FormEmpShift" Then
                'Template Shift Employee
                FormEmpShiftDet.id_shift = FormEmpShift.GVShift.GetFocusedRowCellValue("id_shift").ToString
                FormEmpShiftDet.ShowDialog()
            ElseIf formName = "FormEmpHoliday" Then
                'Template Shift Employee
                FormEmpHolidayDet.id_holiday = FormEmpHoliday.GVHoliday.GetFocusedRowCellValue("id_emp_holiday").ToString
                FormEmpHolidayDet.ShowDialog()
            ElseIf formName = "FormFGRepair" Then
                'Repair
                FormFGRepairDet.action = "upd"
                FormFGRepairDet.id_fg_repair = FormFGRepair.GVRepair.GetFocusedRowCellValue("id_fg_repair").ToString
                FormFGRepairDet.ShowDialog()
            ElseIf formName = "FormFGRepairRec" Then
                'Repair rec
                FormFGRepairRecDet.action = "upd"
                FormFGRepairRecDet.id_fg_repair_rec = FormFGRepairRec.GVRepairRec.GetFocusedRowCellValue("id_fg_repair_rec").ToString
                FormFGRepairRecDet.ShowDialog()
            ElseIf formName = "FormFGRepairReturn" Then
                'Return Repair
                FormFGRepairReturnDet.action = "upd"
                FormFGRepairReturnDet.id_fg_repair_return = FormFGRepairReturn.GVRepairReturn.GetFocusedRowCellValue("id_fg_repair_return").ToString
                FormFGRepairReturnDet.ShowDialog()
            ElseIf formName = "FormFGRepairReturnRec" Then
                'Repair return rec
                FormFGRepairReturnRecDet.action = "upd"
                FormFGRepairReturnRecDet.id_fg_repair_return_rec = FormFGRepairReturnRec.GVRepairRec.GetFocusedRowCellValue("id_fg_repair_return_rec").ToString
                FormFGRepairReturnRecDet.ShowDialog()
            ElseIf formName = "FormEmpLeave" Then
                'Leave employee
                If FormEmpLeave.GVLeave.RowCount > 0 Then
                    FormEmpLeaveDet.id_emp_leave = FormEmpLeave.GVLeave.GetFocusedRowCellValue("id_emp_leave").ToString
                    FormEmpLeaveDet.ShowDialog()
                End If
            ElseIf formName = "FormEmpEmail" Then
                Dim type As String = FormEmpEmail.GVEmail.GetFocusedRowCellValue("type").ToString
                If type = "1" Then
                    FormEmpEmailDet.id = FormEmpEmail.GVEmail.GetFocusedRowCellValue("id_employee").ToString
                Else
                    FormEmpEmailDet.id = FormEmpEmail.GVEmail.GetFocusedRowCellValue("id_other_email").ToString
                End If

                FormEmpEmailDet.type = type

                FormEmpEmailDet.ShowDialog()
            ElseIf formName = "FormEmpDP" Then
                'Leave employee
                If FormEmpDP.GVLeave.RowCount > 0 Then
                    FormEmpDPDet.id_emp_dp = FormEmpDP.GVLeave.GetFocusedRowCellValue("id_dp").ToString
                    FormEmpDPDet.ShowDialog()
                End If
            ElseIf formName = "FormEmpChSchedule" Then
                'Leave
                FormEmpChScheduleDet.id_ch_sch = FormEmpChSchedule.BGVChangeSch.GetFocusedRowCellValue("id_emp_ch_schedule").ToString
                FormEmpChScheduleDet.ShowDialog()
            ElseIf formName = "FormEmpAttnAssign" Then
                'Propose schedule with approval
                FormEmpAttnAssignDet.id_emp_assign_sch = FormEmpAttnAssign.GVAttnAssign.GetFocusedRowCellValue("id_assign_sch").ToString
                FormEmpAttnAssignDet.ShowDialog()
            Else
                RPSubMenu.Visible = False
            End If
            Cursor = Cursors.Default
        End If
    End Sub
    'Delete Data
    Private Sub BBDelete_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles BBDelete.ItemClick
        Dim confirm As DialogResult
        Dim query As String

        If formName = "FormMasterArea" Then
            If FormMasterArea.XTCArea.SelectedTabPageIndex = 0 Then
                'country
                confirm = XtraMessageBox.Show("Are you sure want to delete this country?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)

                Dim id_country As String = FormMasterArea.GVCountry.GetFocusedRowCellDisplayText("id_country").ToString
                If confirm = Windows.Forms.DialogResult.Yes Then
                    Cursor = Cursors.WaitCursor
                    Try
                        query = String.Format("DELETE FROM tb_m_country WHERE id_country = '{0}'", id_country)
                        execute_non_query(query, True, "", "", "", "")
                        FormMasterArea.view_country()
                    Catch ex As Exception
                        XtraMessageBox.Show("This country already used.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End Try
                    Cursor = Cursors.Default
                End If
            ElseIf FormMasterArea.XTCArea.SelectedTabPageIndex = 1 Then
                'region
                confirm = XtraMessageBox.Show("Are you sure want to delete this region?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)

                Dim id_region As String = FormMasterArea.GVRegion.GetFocusedRowCellDisplayText("id_region").ToString
                If confirm = Windows.Forms.DialogResult.Yes Then
                    Cursor = Cursors.WaitCursor
                    Try
                        query = String.Format("DELETE FROM tb_m_region WHERE id_region = '{0}'", id_region)
                        execute_non_query(query, True, "", "", "", "")
                        FormMasterArea.view_region(FormMasterArea.GVCountry.GetFocusedRowCellDisplayText("id_country").ToString)
                    Catch ex As Exception
                        XtraMessageBox.Show("This region already used.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End Try
                    Cursor = Cursors.Default
                End If
            ElseIf FormMasterArea.XTCArea.SelectedTabPageIndex = 2 Then
                'state
                confirm = XtraMessageBox.Show("Are you sure want to delete this state?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)

                Dim id_state As String = FormMasterArea.GVState.GetFocusedRowCellDisplayText("id_state").ToString
                If confirm = Windows.Forms.DialogResult.Yes Then
                    Cursor = Cursors.WaitCursor
                    Try
                        query = String.Format("DELETE FROM tb_m_state WHERE id_state = '{0}'", id_state)
                        execute_non_query(query, True, "", "", "", "")
                        FormMasterArea.view_state(FormMasterArea.GVRegion.GetFocusedRowCellDisplayText("id_region").ToString)
                    Catch ex As Exception
                        XtraMessageBox.Show("This state already used.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End Try
                    Cursor = Cursors.Default
                End If
            Else
                'city
                confirm = XtraMessageBox.Show("Are you sure want to delete this city?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)

                Dim id_city As String = FormMasterArea.GVCity.GetFocusedRowCellDisplayText("id_city").ToString
                If confirm = Windows.Forms.DialogResult.Yes Then
                    Cursor = Cursors.WaitCursor
                    Try
                        query = String.Format("DELETE FROM tb_m_city WHERE id_city = '{0}'", id_city)
                        execute_non_query(query, True, "", "", "", "")
                        FormMasterArea.view_city(FormMasterArea.GVState.GetFocusedRowCellDisplayText("id_state").ToString)
                    Catch ex As Exception
                        XtraMessageBox.Show("This city already used.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End Try
                    Cursor = Cursors.Default
                End If
            End If
        ElseIf formName = "FormMasterCompany" Then
            '
            confirm = XtraMessageBox.Show("Are you sure want to delete this company ?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
            Dim id_company As String = FormMasterCompany.GVCompany.GetFocusedRowCellDisplayText("id_comp").ToString

            If confirm = Windows.Forms.DialogResult.Yes Then
                Cursor = Cursors.WaitCursor
                Try
                    query = String.Format("DELETE FROM tb_m_comp WHERE id_comp = '{0}'", id_company)
                    execute_non_query(query, True, "", "", "", "")
                    FormMasterCompany.view_company()
                Catch ex As Exception
                    errorDelete()
                End Try
                Cursor = Cursors.Default
            End If
        ElseIf formName = "FormMasterCompanyCategory" Then
            '
            confirm = XtraMessageBox.Show("Are you sure want to delete this company cateogry?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
            Dim id_company_category As String = FormMasterCompanyCategory.GVCompanyCategory.GetFocusedRowCellDisplayText("id_comp_cat").ToString

            If confirm = Windows.Forms.DialogResult.Yes Then
                Cursor = Cursors.WaitCursor
                Try
                    query = String.Format("DELETE FROM tb_m_comp_cat WHERE id_comp_cat = '{0}'", id_company_category)
                    execute_non_query(query, True, "", "", "", "")
                    FormMasterCompanyCategory.view_company_category()
                Catch ex As Exception
                    XtraMessageBox.Show("Server Disconnected on delete category company. Please wait a moment.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End Try
                Cursor = Cursors.Default
            End If
        ElseIf formName = "FormMasterDepartement" Then
            '
            confirm = XtraMessageBox.Show("Are you sure want to delete this departement ?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
            Dim id_departement As String = FormMasterDepartement.GVDepartment.GetFocusedRowCellDisplayText("id_departement").ToString

            If confirm = Windows.Forms.DialogResult.Yes Then
                Cursor = Cursors.WaitCursor
                Try
                    query = String.Format("DELETE FROM tb_m_departement WHERE id_departement = '{0}'", id_departement)
                    execute_non_query(query, True, "", "", "", "")
                    FormMasterDepartement.view_department()
                Catch ex As Exception
                    errorDelete()
                End Try
                Cursor = Cursors.Default
            End If
        ElseIf formName = "FormMasterRawMaterialCat" Then
            '
            confirm = XtraMessageBox.Show("Are you sure want to delete this data?" & Environment.NewLine & "This action will delete all operation under this data.", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
            If confirm = Windows.Forms.DialogResult.Yes Then
                Cursor = Cursors.WaitCursor
                Try
                    Dim id_mat_cat As String = FormMasterRawMaterialCat.GridViewMasterItemCategory.GetFocusedRowCellDisplayText("id_mat_cat").ToString
                    query = String.Format("DELETE FROM tb_m_mat_cat WHERE id_mat_cat='{0}'", id_mat_cat)
                    execute_non_query(query, True, "", "", "", "")
                    logData("tb_m_mat_cat", 3)
                    FormMasterRawMaterialCat.view_master_item_category()
                Catch ex As Exception
                    errorDelete()
                End Try
                Cursor = Cursors.Default
            End If
        ElseIf formName = "FormMasterItemColor" Then
            '
            confirm = XtraMessageBox.Show("Are you sure want to delete this data?" & Environment.NewLine & "This action will delete all operation under this data.", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
            If confirm = Windows.Forms.DialogResult.Yes Then
                Cursor = Cursors.WaitCursor
                Try
                    Dim id_item_color As String = FormMasterItemSize.GVItemSize.GetFocusedRowCellDisplayText("id_item_color").ToString
                    query = String.Format("DELETE FROM tb_m_item_color WHERE id_item_color='{0}'", id_item_color)
                    execute_non_query(query, True, "", "", "", "")
                    FormMasterItemColor.viewMasterItemColor()
                Catch ex As Exception
                    errorConnection()
                End Try
                Cursor = Cursors.Default
            End If
        ElseIf formName = "FormMasterItemSize" Then
            '
            confirm = XtraMessageBox.Show("Are you sure want to delete this data?" & Environment.NewLine & "This action will delete all operation under this data.", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
            If confirm = Windows.Forms.DialogResult.Yes Then
                Cursor = Cursors.WaitCursor
                Try
                    Dim id_item_size As String = FormMasterItemSize.GVItemSize.GetFocusedRowCellDisplayText("id_item_size").ToString
                    query = String.Format("DELETE FROM tb_m_item_size WHERE id_item_size='{0}'", id_item_size)
                    execute_non_query(query, True, "", "", "", "")
                    FormMasterItemSize.viewMasterItemSize()
                Catch ex As Exception
                    errorConnection()
                End Try
                Cursor = Cursors.Default
            End If
        ElseIf formName = "FormMasterUser" Then
            confirm = XtraMessageBox.Show("Are you sure want to delete this user ?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
            Dim id_user As String = FormMasterUser.GVUser.GetFocusedRowCellDisplayText("id_user").ToString

            If confirm = Windows.Forms.DialogResult.Yes Then
                Cursor = Cursors.WaitCursor
                Try
                    query = String.Format("DELETE FROM tb_m_user WHERE id_user = '{0}'", id_user)
                    execute_non_query(query, True, "", "", "", "")
                    logData("tb_m_user", 3)
                    FormMasterUser.view_user()
                Catch ex As Exception
                    errorDelete()
                End Try
                Cursor = Cursors.Default
            End If
        ElseIf formName = "FormAccess" Then
            If FormAccess.XTCMenuManage.SelectedTabPageIndex = 2 Then 'Delete Role
                confirm = XtraMessageBox.Show("Are you sure want to delete this role ?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
                Dim id_role As String = FormAccess.GVRole.GetFocusedRowCellDisplayText("id_role").ToString

                If confirm = Windows.Forms.DialogResult.Yes Then
                    Cursor = Cursors.WaitCursor
                    Try
                        query = String.Format("DELETE FROM tb_m_role WHERE id_role = '{0}'", id_role)
                        execute_non_query(query, True, "", "", "", "")
                        logData("tb_m_role", 3)
                        FormAccess.viewRole()
                    Catch ex As Exception
                        errorDelete()
                    End Try
                    Cursor = Cursors.Default
                End If
            ElseIf FormAccess.XTCMenuManage.SelectedTabPageIndex = 1 Then 'Delete Menu
                confirm = XtraMessageBox.Show("Are you sure want to delete this menu ?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
                Dim id_menu As String = FormAccess.GVMenu.GetFocusedRowCellDisplayText("id_menu").ToString

                If confirm = Windows.Forms.DialogResult.Yes Then
                    Cursor = Cursors.WaitCursor
                    Try
                        query = String.Format("DELETE FROM tb_menu WHERE id_menu = '{0}'", id_menu)
                        execute_non_query(query, True, "", "", "", "")
                        logData("tb_menu", 3)
                        FormAccess.viewMenu()
                    Catch ex As Exception
                        errorDelete()
                    End Try
                    Cursor = Cursors.Default
                End If
            ElseIf FormAccess.XTCMenuManage.SelectedTabPageIndex = 0 Then 'Delete Form
                If FormAccess.XTCForm.SelectedTabPageIndex = 0 Then 'Form
                    confirm = XtraMessageBox.Show("Are you sure want to delete this form data?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
                    Dim id_form As String = FormAccess.GVForm.GetFocusedRowCellDisplayText("id_form").ToString

                    If confirm = Windows.Forms.DialogResult.Yes Then
                        Cursor = Cursors.WaitCursor
                        Try
                            query = String.Format("DELETE FROM tb_menu_form WHERE id_form = '{0}'", id_form)
                            execute_non_query(query, True, "", "", "", "")
                            logData("tb_menu_form", 3)
                            FormAccess.viewForm()
                        Catch ex As Exception
                            errorDelete()
                        End Try
                        Cursor = Cursors.Default
                    End If
                ElseIf FormAccess.XTCForm.SelectedTabPageIndex = 1 Then 'Form Process/Control
                    Dim is_view As String = FormAccess.GVProcess.GetFocusedRowCellDisplayText("is_view").ToString
                    If is_view = "1" Then
                        XtraMessageBox.Show("Cannot delete, because this data is required process", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Else
                        confirm = XtraMessageBox.Show("Are you sure want to delete this data?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
                        Dim id_form_control As String = FormAccess.GVProcess.GetFocusedRowCellDisplayText("id_form_control").ToString

                        If confirm = Windows.Forms.DialogResult.Yes Then
                            Cursor = Cursors.WaitCursor
                            Try
                                query = String.Format("DELETE FROM tb_menu_form_control WHERE id_form_control = '{0}'", id_form_control)
                                execute_non_query(query, True, "", "", "", "")
                                logData("tb_menu_form_control", 3)
                                FormAccess.viewFormControl()
                            Catch ex As Exception
                                errorDelete()
                            End Try
                            Cursor = Cursors.Default
                        End If
                    End If
                End If
            End If
        ElseIf formName = "FormSeason" Then
            confirm = XtraMessageBox.Show("Are you sure want to delete this data?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
            If confirm = Windows.Forms.DialogResult.Yes Then
                If FormSeason.XTCMainSeason.SelectedTabPageIndex = 0 Then 'delete season internal
                    If FormSeason.XTCSeason.SelectedTabPageIndex = 0 Then  'delete range
                        Try
                            Dim id_range As String = FormSeason.GVRange.GetFocusedRowCellDisplayText("id_range").ToString
                            query = String.Format("DELETE FROM tb_range WHERE id_range='{0}'", id_range)
                            execute_non_query(query, True, "", "", "", "")
                            logData("tb_range", 3)
                            FormSeason.viewRange()
                        Catch ex As Exception
                            errorDelete()
                        End Try
                    ElseIf FormSeason.XTCSeason.SelectedTabPageIndex = 1 Then  'delete season
                        Try
                            Dim id_season As String = FormSeason.GVSeason.GetFocusedRowCellDisplayText("id_season").ToString
                            query = String.Format("DELETE FROM tb_season WHERE id_season='{0}'", id_season)
                            execute_non_query(query, True, "", "", "", "")
                            logData("tb_season", 3)
                            FormSeason.viewSeason()
                        Catch ex As Exception
                            errorDelete()
                        End Try
                    ElseIf FormSeason.XTCSeason.SelectedTabPageIndex = 2 Then 'delete delivery
                        Try
                            Dim id_delivery As String = FormSeason.GVDelivery.GetFocusedRowCellDisplayText("id_delivery").ToString
                            query = String.Format("DELETE FROM tb_season_delivery WHERE id_delivery='{0}'", id_delivery)
                            execute_non_query(query, True, "", "", "", "")
                            logData("tb_season_delivery", 3)
                            FormSeason.viewDelivery(FormSeason.id_season)
                        Catch ex As Exception
                            errorDelete()
                        End Try
                    End If
                Else 'delete season origin
                    Try
                        Dim id_season_origin As String = FormSeason.GVOrignSeason.GetFocusedRowCellDisplayText("id_season_orign").ToString
                        query = String.Format("DELETE FROM tb_season_orign WHERE id_season_orign = '{0}'", id_season_origin)
                        execute_non_query(query, True, "", "", "", "")
                        logData("tb_season_orign", 3)
                        FormSeason.viewSeasonOrign()
                    Catch ex As Exception
                        errorDelete()
                    End Try
                End If
            End If
        ElseIf formName = "FormMasterUOM" Then
            Cursor = Cursors.WaitCursor
            confirm = XtraMessageBox.Show("Are you sure want to delete this data?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
            If confirm Then
                Try
                    Dim id_uom As String = FormMasterUOM.GVUOM.GetFocusedRowCellDisplayText("id_uom").ToString
                    query = String.Format("DELETE FROM tb_m_uom WHERE id_uom='{0}'", id_uom)
                    execute_non_query(query, True, "", "", "", "")
                    FormMasterUOM.viewUOM()
                Catch ex As Exception
                    errorConnection()
                End Try
            End If
            Cursor = Cursors.Default
        ElseIf formName = "FormMasterRawMat" Then
            Cursor = Cursors.WaitCursor
            If FormMasterRawMat.XTCRawMat.SelectedTabPageIndex = 0 Then ' DELETE RAW MAT
                confirm = XtraMessageBox.Show("Are you sure want to delete this data?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
                If confirm = Windows.Forms.DialogResult.Yes Then
                    Try
                        Dim id_raw_mat As String = FormMasterRawMat.GVRawMat.GetFocusedRowCellDisplayText("id_raw_mat").ToString
                        query = String.Format("DELETE FROM tb_m_raw_mat WHERE id_raw_mat='{0}'", id_raw_mat)
                        execute_non_query(query, True, "", "", "", "")
                        FormMasterRawMat.viewRawMat()
                    Catch ex As Exception
                        errorConnection()
                    End Try
                End If
            ElseIf FormMasterRawMat.XTCRawMat.SelectedTabPageIndex = 2 Then ' DELETE RAW MAT SUPPLIER
                confirm = XtraMessageBox.Show("Are you sure want to delete this data?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
                If confirm = Windows.Forms.DialogResult.Yes Then
                    Try
                        Dim id_raw_mat_supplier As String = FormMasterRawMat.GVSupplier.GetFocusedRowCellDisplayText("id_raw_mat_supplier").ToString
                        query = "DELETE FROM tb_m_raw_mat_supplier WHERE id_raw_mat_supplier ='" + id_raw_mat_supplier + "'"
                        execute_non_query(query, True, "", "", "", "")
                        FormMasterRawMat.viewRawMatSupplier()
                    Catch ex As Exception
                        errorConnection()
                    End Try
                End If
            End If
            Cursor = Cursors.Default
        ElseIf formName = "FormSetupRawMatCode" Then
            Cursor = Cursors.WaitCursor
            confirm = XtraMessageBox.Show("Are you sure want to delete this data?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
            If confirm = Windows.Forms.DialogResult.Yes Then
                Try
                    Dim id_raw_mat_code As String = FormSetupRawMatCode.GVCodeType.GetFocusedRowCellDisplayText("id_raw_mat_code").ToString
                    query = "DELETE FROM tb_m_raw_mat_code WHERE id_raw_mat_code ='" + id_raw_mat_code + "'"
                    execute_non_query(query, True, "", "", "", "")
                    FormSetupRawMatCode.viewCodeType(1, FormSetupRawMatCode.GCCodeType)
                Catch ex As Exception
                    errorConnection()
                End Try
            End If
            Cursor = Cursors.Default
        ElseIf formName = "FormMasterRawMaterial" Then 'DELETE MASTER RAW MATERIAL
            Cursor = Cursors.WaitCursor
            If FormMasterRawMaterial.XTCMaterialType.SelectedTabPageIndex = 0 Then 'delete raw material type
                confirm = XtraMessageBox.Show("Are you sure want to delete this material type?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
                If confirm = Windows.Forms.DialogResult.Yes Then
                    Try
                        Dim id_mat As String = FormMasterRawMaterial.GVRawMat.GetFocusedRowCellDisplayText("id_mat").ToString
                        query = "DELETE FROM tb_m_mat WHERE id_mat ='" + id_mat + "'"
                        execute_non_query(query, True, "", "", "", "")
                        logData("tb_m_mat", 3)
                        FormMasterRawMaterial.viewMat()
                    Catch ex As Exception
                        errorConnection()
                    End Try
                End If
            ElseIf FormMasterRawMaterial.XTCMaterialType.SelectedTabPageIndex = 1 Then 'delete raw material detail
                confirm = XtraMessageBox.Show("Are you sure want to delete this material detail?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
                If confirm = Windows.Forms.DialogResult.Yes Then
                    Try
                        Dim id_mat_det As String = FormMasterRawMaterial.GVMatDetail.GetFocusedRowCellDisplayText("id_mat_det").ToString
                        query = "DELETE FROM tb_m_mat_det WHERE id_mat_det ='" + id_mat_det + "'"
                        execute_non_query(query, True, "", "", "", "")
                        logData("tb_m_mat_det", 3)
                        FormMasterRawMaterial.viewMatDetail()
                    Catch ex As Exception
                        errorConnection()
                    End Try
                End If
            End If
            Cursor = Cursors.Default
        ElseIf formName = "FormMasterOVH" Then
            Cursor = Cursors.WaitCursor
            confirm = XtraMessageBox.Show("Are you sure want to delete this data?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
            If confirm = Windows.Forms.DialogResult.Yes Then
                Try
                    Dim id_ovh As String = FormMasterOVH.GVOVH.GetFocusedRowCellDisplayText("id_ovh").ToString
                    query = String.Format("DELETE FROM tb_m_ovh WHERE id_ovh='{0}'", id_ovh)
                    execute_non_query(query, True, "", "", "", "")
                    logData("tb_m_ovh", 3)
                    FormMasterOVH.view_ovh()
                Catch ex As Exception
                    errorConnection()
                End Try
            End If
            Cursor = Cursors.Default
        ElseIf formName = "FormProdDemand" Then
            Dim id_report_status As String = FormProdDemand.GVProdDemand.GetFocusedRowCellValue("id_report_status").ToString
            Dim id_prod_demand As String = FormProdDemand.GVProdDemand.GetFocusedRowCellDisplayText("id_prod_demand").ToString
            If Not check_edit_report_status(id_report_status, "9", id_prod_demand) Or id_report_status = "5" Then
                stopCustom("This data already locked.")
            Else
                Cursor = Cursors.WaitCursor
                confirm = XtraMessageBox.Show("Are you sure want to delete this data?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
                If confirm = Windows.Forms.DialogResult.Yes Then
                    Try
                        query = String.Format("DELETE FROM tb_prod_demand WHERE id_prod_demand ='{0}'", id_prod_demand)
                        execute_non_query(query, True, "", "", "", "")

                        'del mark
                        delete_all_mark_related("9", id_prod_demand)

                        logData("tb_prod_demand", 3)
                        FormProdDemand.viewProdDemand()
                    Catch ex As Exception
                        errorConnection()
                    End Try
                End If
                Cursor = Cursors.Default
            End If
        ElseIf formName = "FormMasterCode" Then
            '
            confirm = XtraMessageBox.Show("Are you sure want to delete this data?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
            If confirm = Windows.Forms.DialogResult.Yes Then
                If FormMasterCode.XTCCode.SelectedTabPageIndex = 0 Then  'delete code
                    Try
                        Dim id_code As String = FormMasterCode.GVCode.GetFocusedRowCellDisplayText("id_code").ToString
                        query = String.Format("DELETE FROM tb_m_code WHERE id_code='{0}'", id_code)
                        execute_non_query(query, True, "", "", "", "")
                        FormMasterCode.view_code()
                    Catch ex As Exception
                        errorDelete()
                    End Try
                ElseIf FormMasterCode.XTCCode.SelectedTabPageIndex = 1 Then 'delete code detail
                    Try
                        Dim id_code_detail As String = FormMasterCode.GVCodeDetail.GetFocusedRowCellDisplayText("id_code_detail").ToString
                        query = String.Format("DELETE FROM tb_m_code_detail WHERE id_code_detail='{0}'", id_code_detail)
                        execute_non_query(query, True, "", "", "", "")
                        FormMasterCode.view_code_detail(FormMasterCode.GVCode.GetFocusedRowCellDisplayText("id_code").ToString)
                    Catch ex As Exception
                        errorDelete()
                    End Try
                End If
            End If
        ElseIf formName = "FormTemplateCode" Then
            '
            confirm = XtraMessageBox.Show("Are you sure want to delete this data?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
            If confirm = Windows.Forms.DialogResult.Yes Then
                If FormTemplateCode.XTCTemplateCode.SelectedTabPageIndex = 0 Then  'delete code
                    Try
                        Dim id_template_code As String = FormTemplateCode.GVTemplateCode.GetFocusedRowCellDisplayText("id_template_code").ToString
                        query = String.Format("DELETE FROM tb_template_code WHERE id_template_code='{0}'", id_template_code)
                        execute_non_query(query, True, "", "", "", "")
                        FormTemplateCode.view_template()
                    Catch ex As Exception
                        errorDelete()
                    End Try
                End If
            End If
        ElseIf formName = "FormMasterSample" Then
            '
            confirm = XtraMessageBox.Show("Are you sure want to delete this sample ?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
            Dim id_sample As String = FormMasterSample.GVSample.GetFocusedRowCellDisplayText("id_sample").ToString

            If confirm = Windows.Forms.DialogResult.Yes Then
                Cursor = Cursors.WaitCursor
                Try
                    query = String.Format("DELETE FROM tb_m_sample WHERE id_sample = '{0}'", id_sample)
                    execute_non_query(query, True, "", "", "", "")
                    FormMasterSample.view_sample()
                Catch ex As Exception
                    errorDelete()
                End Try
                Cursor = Cursors.Default
            End If
        ElseIf formName = "FormMasterProduct" Then
            '
            confirm = XtraMessageBox.Show("Are you sure want to delete this data?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
            If confirm = Windows.Forms.DialogResult.Yes Then
                If FormMasterProduct.XTCProduct.SelectedTabPageIndex = 0 Then  'delete design
                    Try
                        Dim id_design As String = FormMasterProduct.GVDesign.GetFocusedRowCellDisplayText("id_design").ToString
                        query = String.Format("DELETE FROM tb_m_design WHERE id_design='{0}'", id_design)
                        execute_non_query(query, True, "", "", "", "")
                        FormMasterProduct.view_design()
                    Catch ex As Exception
                        errorDelete()
                    End Try
                ElseIf FormMasterProduct.XTCProduct.SelectedTabPageIndex = 1 Then 'delete product
                    Try
                        Dim id_product As String = FormMasterProduct.GVProduct.GetFocusedRowCellDisplayText("id_product").ToString
                        query = String.Format("DELETE FROM tb_m_product WHERE id_product='{0}'", id_product)
                        execute_non_query(query, True, "", "", "", "")
                        FormMasterProduct.view_product(FormMasterProduct.GVDesign.GetFocusedRowCellDisplayText("id_design").ToString)
                    Catch ex As Exception
                        errorDelete()
                    End Try
                End If
            End If
        ElseIf formName = "FormBOM" Then
            '
            If FormBOM.XTCBOMSelection.SelectedTabPageIndex = "2" Then
                If check_edit_report_status(FormBOM.GVBOMPerDesign.GetFocusedRowCellDisplayText("id_report_status"), "79", FormBOM.GVBOMPerDesign.GetFocusedRowCellDisplayText("id_bom_approve")) Then
                    confirm = XtraMessageBox.Show("Are you sure want to delete this BOM ?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
                    Dim id_bom_approve As String = FormBOM.GVBOMPerDesign.GetFocusedRowCellDisplayText("id_bom_approve").ToString

                    If confirm = Windows.Forms.DialogResult.Yes Then
                        Cursor = Cursors.WaitCursor
                        Try
                            query = String.Format("DELETE FROM tb_bom WHERE id_bom_approve = '{0}'", id_bom_approve)
                            execute_non_query(query, True, "", "", "", "")

                            query = String.Format("DELETE FROM tb_bom_approve WHERE id_bom_approve = '{0}'", id_bom_approve)
                            execute_non_query(query, True, "", "", "", "")

                            'del mark
                            delete_all_mark_related("79", id_bom_approve)
                            FormBOM.show_bom_per_design(FormBOM.GVPerDesign.GetFocusedRowCellDisplayText("id_design").ToString)
                        Catch ex As Exception
                            errorDelete()
                        End Try
                        Cursor = Cursors.Default
                    End If
                Else
                    stopCustom("BOM already processed.")
                End If
            Else
                If check_edit_report_status(FormBOM.GVBOM.GetFocusedRowCellDisplayText("id_report_status"), "8", FormBOM.GVBOM.GetFocusedRowCellDisplayText("id_bom")) Then
                    confirm = XtraMessageBox.Show("Are you sure want to delete this BOM ?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
                    Dim id_bom As String = FormBOM.GVBOM.GetFocusedRowCellDisplayText("id_bom").ToString

                    If confirm = Windows.Forms.DialogResult.Yes Then
                        Cursor = Cursors.WaitCursor
                        Try
                            query = String.Format("DELETE FROM tb_bom WHERE id_bom = '{0}'", id_bom)
                            execute_non_query(query, True, "", "", "", "")

                            'del mark
                            delete_all_mark_related("8", id_bom)

                            FormBOM.view_bom(FormBOM.GVProduct.GetFocusedRowCellDisplayText("id_product").ToString)
                        Catch ex As Exception
                            errorDelete()
                        End Try
                        Cursor = Cursors.Default
                    End If
                Else
                    stopCustom("BOM already processed.")
                End If
            End If
        ElseIf formName = "FormSamplePL" Then
            'PACKING LIST RECEIVING SAMPLE
            If check_edit_report_status(FormSamplePL.GVPL.GetFocusedRowCellDisplayText("id_report_status"), "3", FormSamplePL.GVPL.GetFocusedRowCellDisplayText("id_pl_sample_purc")) Then
                confirm = XtraMessageBox.Show("Are you sure want to delete this Packing List ?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
                Dim id_pl_sample_purc As String = FormSamplePL.GVPL.GetFocusedRowCellDisplayText("id_pl_sample_purc").ToString

                If confirm = Windows.Forms.DialogResult.Yes Then
                    Cursor = Cursors.WaitCursor
                    Try
                        query = String.Format("DELETE FROM tb_pl_sample_purc WHERE id_pl_sample_purc = '{0}'", id_pl_sample_purc)
                        execute_non_query(query, True, "", "", "", "")

                        'del mark
                        delete_all_mark_related("3", id_pl_sample_purc)

                        FormSamplePL.viewPL()
                    Catch ex As Exception
                        errorDelete()
                    End Try
                    Cursor = Cursors.Default
                End If
            Else
                stopCustom("Packing list already processed.")
            End If
        ElseIf formName = "FormSamplePurchase" Then
            '
            If check_edit_report_status(FormSamplePurchase.GVSamplePurchase.GetFocusedRowCellDisplayText("id_report_status"), "1", FormSamplePurchase.GVSamplePurchase.GetFocusedRowCellDisplayText("id_sample_purc")) Then
                confirm = XtraMessageBox.Show("Are you sure want to delete this purchase sample ?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
                Dim id_sample_purc As String = FormSamplePurchase.GVSamplePurchase.GetFocusedRowCellDisplayText("id_sample_purc").ToString

                If confirm = Windows.Forms.DialogResult.Yes Then
                    Cursor = Cursors.WaitCursor
                    Try
                        query = String.Format("DELETE FROM tb_sample_purc WHERE id_sample_purc = '{0}'", id_sample_purc)
                        execute_non_query(query, True, "", "", "", "")

                        'del mark
                        delete_all_mark_related("1", id_sample_purc)

                        FormSamplePurchase.view_sample_purc()
                    Catch ex As Exception
                        errorDelete()
                    End Try
                    Cursor = Cursors.Default
                End If
            Else
                stopCustom("Purchase already processed.")
            End If
        ElseIf formName = "FormSampleReceive" Then
            '
            If check_edit_report_status(FormSampleReceive.GVSampleReceive.GetFocusedRowCellDisplayText("id_report_status"), "2", FormSampleReceive.GVSampleReceive.GetFocusedRowCellDisplayText("id_sample_purc_rec")) Then
                confirm = XtraMessageBox.Show("Are you sure want to delete this receive sample ?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
                Dim id_sample_purc_rec As String = FormSampleReceive.GVSampleReceive.GetFocusedRowCellDisplayText("id_sample_purc_rec").ToString

                If confirm = Windows.Forms.DialogResult.Yes Then
                    Cursor = Cursors.WaitCursor
                    Try
                        query = String.Format("DELETE FROM tb_sample_purc_rec WHERE id_sample_purc_rec = '{0}'", id_sample_purc_rec)
                        execute_non_query(query, True, "", "", "", "")

                        'del mark
                        delete_all_mark_related("2", id_sample_purc_rec)

                        FormSampleReceive.view_sample_rec()
                    Catch ex As Exception
                        errorDelete()
                    End Try
                    Cursor = Cursors.Default
                End If
            Else
                stopCustom("Receive already processed.")
            End If
        ElseIf formName = "FormSamplePR" Then
            '
            If check_edit_report_status(FormSamplePR.GVSamplePR.GetFocusedRowCellDisplayText("id_report_status"), "4", FormSamplePR.GVSamplePR.GetFocusedRowCellDisplayText("id_pr_sample_purc")) Then
                confirm = XtraMessageBox.Show("Are you sure want to delete this payment requisition ?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
                Dim id_pr_sample_purc As String = FormSamplePR.GVSamplePR.GetFocusedRowCellDisplayText("id_pr_sample_purc").ToString

                If confirm = Windows.Forms.DialogResult.Yes Then
                    Cursor = Cursors.WaitCursor
                    Try
                        query = String.Format("DELETE FROM tb_pr_sample_purc WHERE id_pr_sample_purc = '{0}'", id_pr_sample_purc)
                        execute_non_query(query, True, "", "", "", "")

                        'del mark
                        delete_all_mark_related("4", id_pr_sample_purc)

                        FormSamplePR.view_sample_pr()
                    Catch ex As Exception
                        errorDelete()
                    End Try
                    Cursor = Cursors.Default
                End If
            Else
                stopCustom("Payment Request already processed.")
            End If
        ElseIf formName = "FormMasterWH" Then
            'WAREHOUSE & LOCATOR
            If FormMasterWH.XTCWH.SelectedTabPageIndex = 1 Then 'Locator
                confirm = XtraMessageBox.Show("Are you sure want to delete this data ?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
                Dim id_wh_locator As String = FormMasterWH.GVLocator.GetFocusedRowCellDisplayText("id_wh_locator").ToString

                If confirm = Windows.Forms.DialogResult.Yes Then
                    Cursor = Cursors.WaitCursor
                    Try
                        query = String.Format("DELETE FROM tb_m_wh_locator WHERE id_wh_locator = '{0}'", id_wh_locator)
                        execute_non_query(query, True, "", "", "", "")
                        FormMasterWH.viewWHLocator()
                    Catch ex As Exception
                        errorDelete()
                    End Try
                    Cursor = Cursors.Default
                End If
            ElseIf FormMasterWH.XTCWH.SelectedTabPageIndex = 2 Then 'Rack
                confirm = XtraMessageBox.Show("Are you sure want to delete this data ?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
                Dim id_wh_rack As String = FormMasterWH.GVRack.GetFocusedRowCellDisplayText("id_wh_rack").ToString

                If confirm = Windows.Forms.DialogResult.Yes Then
                    Cursor = Cursors.WaitCursor
                    Try
                        query = String.Format("DELETE FROM tb_m_wh_rack WHERE id_wh_rack = '{0}'", id_wh_rack)
                        execute_non_query(query, True, "", "", "", "")
                        FormMasterWH.viewRack()
                    Catch ex As Exception
                        errorDelete()
                    End Try
                    Cursor = Cursors.Default
                End If
            ElseIf FormMasterWH.XTCWH.SelectedTabPageIndex = 3 Then 'Drawer
                confirm = XtraMessageBox.Show("Are you sure want to delete this data ?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
                Dim id_wh_drawer As String = FormMasterWH.GVDrawer.GetFocusedRowCellDisplayText("id_wh_drawer").ToString

                If confirm = Windows.Forms.DialogResult.Yes Then
                    Cursor = Cursors.WaitCursor
                    Try
                        query = String.Format("DELETE FROM tb_m_wh_drawer WHERE id_wh_drawer = '{0}'", id_wh_drawer)
                        execute_non_query(query, True, "", "", "", "")
                        FormMasterWH.viewDrawer()
                    Catch ex As Exception
                        errorDelete()
                    End Try
                    Cursor = Cursors.Default
                End If
            End If
        ElseIf formName = "FormSampleRet" Then
            'RETURN SAMPLE
            If FormSampleRet.XTCReturn.SelectedTabPageIndex = 0 Then  'delete return out
                confirm = XtraMessageBox.Show("Are you sure want to delete this data?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
                If confirm = Windows.Forms.DialogResult.Yes Then
                    Try
                        Dim id_sample_purc_ret_out As String = FormSampleRet.GVRetOut.GetFocusedRowCellDisplayText("id_sample_purc_ret_out").ToString
                        query = String.Format("DELETE FROM tb_sample_purc_ret_out WHERE id_sample_purc_ret_out='{0}'", id_sample_purc_ret_out)
                        execute_non_query(query, True, "", "", "", "")
                        FormSampleRet.viewRetOut()
                    Catch ex As Exception
                        errorDelete()
                    End Try
                End If
            ElseIf FormSampleRet.XTCReturn.SelectedTabPageIndex = 1 Then 'delete return in
                confirm = XtraMessageBox.Show("Are you sure want to delete this data?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
                If confirm = Windows.Forms.DialogResult.Yes Then
                    Try
                        Dim id_sample_purc_ret_in As String = FormSampleRet.GVRetIn.GetFocusedRowCellDisplayText("id_sample_purc_ret_in").ToString
                        query = String.Format("DELETE FROM tb_sample_purc_ret_in WHERE id_sample_purc_ret_in='{0}'", id_sample_purc_ret_in)
                        execute_non_query(query, True, "", "", "", "")
                        FormSampleRet.viewRetIn()
                    Catch ex As Exception
                        errorDelete()
                    End Try
                End If
            End If
        ElseIf formName = "FormSamplePLDel" Then
            'PACKING LIST RECEIVING SAMPLE Delivery
            Dim id_pl_sample_del As String = FormSamplePLDel.GVPL.GetFocusedRowCellDisplayText("id_pl_sample_del").ToString
            Dim id_report_status As String = FormSamplePLDel.GVPL.GetFocusedRowCellDisplayText("id_report_status").ToString

            If Not check_edit_report_status(id_report_status, "10", id_pl_sample_del) Or id_report_status = "5" Then
                stopCustom("This data already locked.")
            Else
                confirm = XtraMessageBox.Show("Are you sure want to delete this Packing List ?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
                If confirm = Windows.Forms.DialogResult.Yes Then
                    Cursor = Cursors.WaitCursor
                    Try
                        Cursor = Cursors.WaitCursor

                        'stock
                        Dim query_cancel As String = "SELECT * FROM tb_pl_sample_del a "
                        query_cancel += "INNER JOIN tb_pl_sample_del_det b ON a.id_pl_sample_del = b.id_pl_sample_del "
                        query_cancel += "INNER JOIN tb_sample_requisition_det c ON b.id_sample_requisition_det = c.id_sample_requisition_det "
                        query_cancel += "WHERE a.id_pl_sample_del = '" + id_pl_sample_del + "' "
                        Dim data As DataTable = execute_query(query_cancel, -1, True, "", "", "", "")
                        For i As Integer = 0 To (data.Rows.Count - 1)
                            Dim id_wh_drawer As String = data.Rows(i)("id_wh_drawer").ToString
                            Dim id_sample As String = data.Rows(i)("id_sample").ToString
                            Dim pl_sample_del_det_qty As String = data.Rows(i)("pl_sample_del_det_qty").ToString
                            Dim pl_sample_del_number As String = data.Rows(i)("pl_sample_del_number").ToString
                            Dim id_sample_price As String = data.Rows(i)("id_sample_price").ToString
                            Dim sample_price As Decimal = data.Rows(i)("sample_price")

                            Dim query_upd_storage As String = "INSERT tb_storage_sample(id_wh_drawer, id_storage_category, id_sample, qty_sample, datetime_storage_sample, storage_sample_notes,id_report,report_mark_type,id_stock_status,id_sample_price,sample_price) "
                            query_upd_storage += "VALUES('" + id_wh_drawer + "', '1', '" + id_sample + "', '" + pl_sample_del_det_qty + "', NOW(), 'Out sample was cancelled, PL : " + pl_sample_del_number + "','" + id_pl_sample_del + "','10','2','" + id_sample_price + "','" + decimalSQL(sample_price.ToString) + "')"
                            execute_non_query(query_upd_storage, True, "", "", "", "")
                        Next

                        'main
                        query = String.Format("DELETE FROM tb_pl_sample_del WHERE id_pl_sample_del = '{0}'", id_pl_sample_del)
                        execute_non_query(query, True, "", "", "", "")

                        'del mark
                        delete_all_mark_related("10", id_pl_sample_del)

                        'Refresh data
                        FormSamplePLDel.viewPL()
                        FormSamplePLDel.viewSampleReq()
                        Cursor = Cursors.Default
                    Catch ex As Exception
                        Cursor = Cursors.Default
                        errorDelete()
                    End Try
                    Cursor = Cursors.Default
                End If
            End If
        ElseIf formName = "FormSampleReq" Then
            'SAMPLE REQUISITION
            Dim id_sample_requisition As String = FormSampleReq.GVReq.GetFocusedRowCellDisplayText("id_sample_requisition").ToString
            Dim id_report_status As String = FormSampleReq.GVReq.GetFocusedRowCellValue("id_report_status").ToString

            If Not check_edit_report_status(id_report_status, "11", id_sample_requisition) Or id_report_status = "5" Then
                stopCustom("This data already locked.")
            Else
                confirm = XtraMessageBox.Show("Are you sure want to delete this data ?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
                If confirm = Windows.Forms.DialogResult.Yes Then
                    Cursor = Cursors.WaitCursor
                    Try
                        Cursor = Cursors.WaitCursor
                        query = String.Format("DELETE FROM tb_sample_requisition WHERE id_sample_requisition = '{0}'", id_sample_requisition)
                        execute_non_query(query, True, "", "", "", "")

                        'del mark
                        delete_all_mark_related("11", id_sample_requisition)

                        FormSampleReq.viewSampleReq()
                        Cursor = Cursors.Default
                    Catch ex As Exception
                        Cursor = Cursors.Default
                        errorDelete()
                    End Try
                    Cursor = Cursors.Default
                End If
            End If
        ElseIf formName = "FormMarkAssign" Then
            confirm = XtraMessageBox.Show("Are you sure want to delete this assign?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
            If confirm = Windows.Forms.DialogResult.Yes Then
                Try
                    Dim id_mark_asg As String = FormMarkAssign.GVMarkAssign.GetFocusedRowCellDisplayText("id_mark_asg")
                    query = String.Format("DELETE FROM tb_mark_asg WHERE id_mark_asg='{0}'", id_mark_asg)
                    execute_non_query(query, True, "", "", "", "")
                    FormMarkAssign.view_asg()
                Catch ex As Exception
                    errorDelete()
                End Try
            End If
        ElseIf formName = "FormSamplePlan" Then
            '
            'check first
            If check_edit_report_status(FormSamplePlan.GVSamplePurchase.GetFocusedRowCellDisplayText("id_report_status"), "12", FormSamplePlan.GVSamplePurchase.GetFocusedRowCellDisplayText("id_sample_plan")) Then
                confirm = XtraMessageBox.Show("Are you sure want to delete this sample plan?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
                If confirm = Windows.Forms.DialogResult.Yes Then
                    Try
                        Dim id_sample_plan As String = FormSamplePlan.GVSamplePurchase.GetFocusedRowCellDisplayText("id_sample_plan")
                        query = String.Format("DELETE FROM tb_sample_plan WHERE id_sample_plan='{0}'", id_sample_plan)
                        execute_non_query(query, True, "", "", "", "")

                        'del mark
                        delete_all_mark_related("12", id_sample_plan)

                        FormSamplePlan.view_sample_plan()
                    Catch ex As Exception
                        errorDelete()
                    End Try
                End If
            Else
                stopCustom("This Sample Planning already marked")
            End If
        ElseIf formName = "FormSampleReturn" Then
            'SAMPLE RETURN
            Dim id_sample_return As String = FormSampleReturn.GVRetSample.GetFocusedRowCellDisplayText("id_sample_return").ToString
            Dim id_report_status As String = FormSampleReturn.GVRetSample.GetFocusedRowCellValue("id_report_status").ToString

            If Not check_edit_report_status(id_report_status, "14", id_sample_return) Or id_report_status = "5" Then
                stopCustom("This data already locked.")
            Else
                confirm = XtraMessageBox.Show("Are you sure want to delete this data ?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
                If confirm = Windows.Forms.DialogResult.Yes Then
                    Cursor = Cursors.WaitCursor
                    Try
                        Cursor = Cursors.WaitCursor

                        'main
                        query = String.Format("DELETE FROM tb_sample_return WHERE id_sample_return = '{0}'", id_sample_return)
                        execute_non_query(query, True, "", "", "", "")

                        'del mark
                        delete_all_mark_related("14", id_sample_return)

                        'Refresh data
                        FormSampleReturn.viewSampleReturn()
                        FormSampleReturn.viewPl()
                        Cursor = Cursors.Default
                    Catch ex As Exception
                        Cursor = Cursors.Default
                        errorDelete()
                    End Try
                    Cursor = Cursors.Default
                End If
            End If
        ElseIf formName = "FormMatWO" Then
            '
            'check first
            If check_edit_report_status(FormMatWO.GVMatWO.GetFocusedRowCellDisplayText("id_report_status"), "15", FormMatWO.GVMatWO.GetFocusedRowCellDisplayText("id_mat_wo")) Then
                confirm = XtraMessageBox.Show("Are you sure want to delete this work order?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
                If confirm = Windows.Forms.DialogResult.Yes Then
                    Try
                        Dim id_mat_wo As String = FormMatWO.GVMatWO.GetFocusedRowCellDisplayText("id_mat_wo")
                        query = String.Format("DELETE FROM tb_mat_wo WHERE id_mat_wo='{0}'", id_mat_wo)
                        execute_non_query(query, True, "", "", "", "")

                        'del mark
                        delete_all_mark_related("15", id_mat_wo)

                        FormMatWO.view_mat_purc()
                    Catch ex As Exception
                        errorDelete()
                    End Try
                End If
            Else
                stopCustom("This Work Order already marked")
            End If
        ElseIf formName = "FormMatPurchase" Then
            'check first
            If check_edit_report_status(FormMatPurchase.GVMatPurchase.GetFocusedRowCellDisplayText("id_report_status"), "15", FormMatPurchase.GVMatPurchase.GetFocusedRowCellDisplayText("id_mat_purc")) Then
                confirm = XtraMessageBox.Show("Are you sure want to delete this purchase order?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
                If confirm = Windows.Forms.DialogResult.Yes Then
                    Try
                        Dim id_mat_purc As String = FormMatPurchase.GVMatPurchase.GetFocusedRowCellDisplayText("id_mat_purc")
                        query = String.Format("DELETE FROM tb_mat_purc WHERE id_mat_purc='{0}'", id_mat_purc)
                        execute_non_query(query, True, "", "", "", "")

                        'del mark
                        delete_all_mark_related("13", id_mat_purc)

                        FormMatPurchase.view_mat_purc()
                    Catch ex As Exception
                        errorDelete()
                    End Try
                End If
            Else
                stopCustom("This purchase already marked")
            End If
        ElseIf formName = "FormMatRecPurc" Then
            '
            'check first
            If check_edit_report_status(FormMatRecPurc.GVMatRecPurc.GetFocusedRowCellDisplayText("id_report_status"), "16", FormMatRecPurc.GVMatRecPurc.GetFocusedRowCellDisplayText("id_mat_purc_rec")) Then
                confirm = XtraMessageBox.Show("Are you sure want to delete this receive?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
                If confirm = Windows.Forms.DialogResult.Yes Then
                    Try
                        Dim id_mat_purc_rec As String = FormMatRecPurc.GVMatRecPurc.GetFocusedRowCellDisplayText("id_mat_purc_rec")
                        query = String.Format("DELETE FROM tb_mat_purc_rec WHERE id_mat_purc_rec='{0}'", id_mat_purc_rec)
                        execute_non_query(query, True, "", "", "", "")

                        'del mark
                        delete_all_mark_related("16", id_mat_purc_rec)

                        FormMatRecPurc.view_mat_rec_purc()
                    Catch ex As Exception
                        errorDelete()
                    End Try
                End If
            Else
                stopCustom("This Receive already marked")
            End If
        ElseIf formName = "FormMatRecWO" Then
            '
            'check first
            If check_edit_report_status(FormMatRecWO.GVMatRecPurc.GetFocusedRowCellDisplayText("id_report_status"), "17", FormMatRecWO.GVMatRecPurc.GetFocusedRowCellDisplayText("id_mat_wo_rec")) Then
                confirm = XtraMessageBox.Show("Are you sure want to delete this receive?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
                If confirm = Windows.Forms.DialogResult.Yes Then
                    Try
                        Dim id_mat_wo_rec As String = FormMatRecWO.GVMatRecPurc.GetFocusedRowCellDisplayText("id_mat_wo_rec")
                        query = String.Format("DELETE FROM tb_mat_wo_rec WHERE id_mat_wo_rec='{0}'", id_mat_wo_rec)
                        execute_non_query(query, True, "", "", "", "")

                        'del mark
                        delete_all_mark_related("17", id_mat_wo_rec)

                        FormMatRecWO.view_mat_rec_purc()
                    Catch ex As Exception
                        errorDelete()
                    End Try
                End If
            Else
                stopCustom("This Receive already marked")
            End If
        ElseIf formName = "FormMatRet" Then
            If FormMatRet.XTCReturnMat.SelectedTabPageIndex = 0 Then 'purchase
                'Return Mat
                If FormMatRet.XTCReturnPruchase.SelectedTabPageIndex = 0 Then 'return Out
                    If check_edit_report_status(FormMatRet.GVRetOut.GetFocusedRowCellDisplayText("id_report_status"), "18", FormMatRet.GVRetOut.GetFocusedRowCellDisplayText("id_mat_purc_ret_out")) Then
                        confirm = XtraMessageBox.Show("Are you sure want to delete this return?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
                        If confirm = Windows.Forms.DialogResult.Yes Then
                            Try
                                Dim id_mat_purc_ret_out As String = FormMatRet.GVRetOut.GetFocusedRowCellDisplayText("id_mat_purc_ret_out")
                                query = String.Format("DELETE FROM tb_mat_purc_ret_out WHERE id_mat_purc_ret_out='{0}'", id_mat_purc_ret_out)
                                execute_non_query(query, True, "", "", "", "")

                                'del mark
                                delete_all_mark_related("18", id_mat_purc_ret_out)

                                FormMatRet.viewRetOut()
                            Catch ex As Exception
                                errorDelete()
                            End Try
                        End If
                    Else
                        stopCustom("This Return already marked")
                    End If
                ElseIf FormMatRet.XTCReturnPruchase.SelectedTabPageIndex = 1 Then 'Return In
                    If check_edit_report_status(FormMatRet.GVRetIn.GetFocusedRowCellDisplayText("id_report_status"), "19", FormMatRet.GVRetIn.GetFocusedRowCellDisplayText("id_mat_purc_ret_in")) Then
                        confirm = XtraMessageBox.Show("Are you sure want to delete this return?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
                        If confirm = Windows.Forms.DialogResult.Yes Then
                            Try
                                Dim id_mat_purc_ret_in As String = FormMatRet.GVRetIn.GetFocusedRowCellDisplayText("id_mat_purc_ret_in")
                                query = String.Format("DELETE FROM tb_mat_purc_ret_in WHERE id_mat_purc_ret_in='{0}'", id_mat_purc_ret_in)
                                execute_non_query(query, True, "", "", "", "")

                                'del mark
                                delete_all_mark_related("19", id_mat_purc_ret_in)

                                FormMatRet.viewRetIn()
                            Catch ex As Exception
                                errorDelete()
                            End Try
                        End If
                    Else
                        stopCustom("This Return already marked")
                    End If
                End If
            ElseIf FormMatRet.XTCReturnMat.SelectedTabPageIndex = 1 Then 'production
                If FormMatRet.XTCReturnProd.SelectedTabPageIndex = 0 Then 'return in
                    If check_edit_report_status(FormMatRet.GVRetInProd.GetFocusedRowCellDisplayText("id_report_status"), "47", FormMatRet.GVRetInProd.GetFocusedRowCellDisplayText("id_mat_prod_ret_in")) Then
                        confirm = XtraMessageBox.Show("Are you sure want to delete this return?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
                        If confirm = Windows.Forms.DialogResult.Yes Then
                            Try
                                Dim id_mat_prod_ret_in As String = FormMatRet.GVRetInProd.GetFocusedRowCellDisplayText("id_mat_prod_ret_in")
                                query = String.Format("DELETE FROM tb_mat_prod_ret_in WHERE id_mat_prod_ret_in='{0}'", id_mat_prod_ret_in)
                                execute_non_query(query, True, "", "", "", "")

                                'del mark
                                delete_all_mark_related("47", id_mat_prod_ret_in)

                                FormMatRet.viewRetInProd()
                            Catch ex As Exception
                                errorDelete()
                            End Try
                        End If
                    Else
                        stopCustom("This Return already marked")
                    End If
                End If
            End If
        ElseIf formName = "FormSampleAdjustment" Then
            'SAMPLE Adjustment
            If FormSampleAdjustment.XTCAdj.SelectedTabPageIndex = 0 Then 'Adj In
                Dim id_adj_in_sample As String = FormSampleAdjustment.GVAdjSampleIn.GetFocusedRowCellDisplayText("id_adj_in_sample").ToString
                Dim id_report_status As String = FormSampleAdjustment.GVAdjSampleIn.GetFocusedRowCellValue("id_report_status").ToString

                If Not check_edit_report_status(id_report_status, "20", id_adj_in_sample) Or id_report_status = "5" Then
                    stopCustom("This data already locked.")
                Else
                    confirm = XtraMessageBox.Show("Are you sure want to delete this data ?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
                    If confirm = Windows.Forms.DialogResult.Yes Then
                        Cursor = Cursors.WaitCursor
                        Try
                            Cursor = Cursors.WaitCursor
                            'main
                            query = String.Format("DELETE FROM tb_adj_in_sample WHERE id_adj_in_sample = '{0}'", id_adj_in_sample)
                            execute_non_query(query, True, "", "", "", "")

                            'del mark
                            delete_all_mark_related("20", id_adj_in_sample)

                            'Refresh data
                            FormSampleAdjustment.viewAdjInSample()
                            Cursor = Cursors.Default
                        Catch ex As Exception
                            Cursor = Cursors.Default
                            errorDelete()
                        End Try
                        Cursor = Cursors.Default
                    End If
                End If
            ElseIf FormSampleAdjustment.XTCAdj.SelectedTabPageIndex = 1 Then 'Adj Out
                Dim id_adj_out_sample As String = FormSampleAdjustment.GVAdjOutSample.GetFocusedRowCellDisplayText("id_adj_out_sample").ToString
                Dim id_report_status As String = FormSampleAdjustment.GVAdjOutSample.GetFocusedRowCellValue("id_report_status").ToString

                If Not check_edit_report_status(id_report_status, "21", id_adj_out_sample) Or id_report_status = "5" Then
                    stopCustom("This data already locked.")
                Else
                    confirm = XtraMessageBox.Show("Are you sure want to delete this data ?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
                    If confirm = Windows.Forms.DialogResult.Yes Then
                        Cursor = Cursors.WaitCursor
                        Try
                            'stock
                            Dim query_cancel As String = "SELECT * FROM tb_adj_out_sample a "
                            query_cancel += "INNER JOIN tb_adj_out_sample_det b ON a.id_adj_out_sample = b.id_adj_out_sample "
                            query_cancel += "WHERE a.id_adj_out_sample = '" + id_adj_out_sample + "' "
                            Dim data As DataTable = execute_query(query_cancel, -1, True, "", "", "", "")

                            Dim jum_ins_i As Integer = 0
                            Dim query_drawer_stock As String = ""
                            If data.Rows.Count > 0 Then
                                query_drawer_stock = "INSERT tb_storage_sample(id_wh_drawer, id_storage_category, id_sample, id_sample_price, sample_price, qty_sample, datetime_storage_sample, storage_sample_notes, report_mark_type, id_report, id_stock_status) VALUES "
                            End If
                            For i As Integer = 0 To (data.Rows.Count - 1)
                                Dim id_wh_drawer As String = data.Rows(i)("id_wh_drawer").ToString
                                Dim id_sample As String = data.Rows(i)("id_sample").ToString
                                Dim adj_out_sample_det_qty As String = decimalSQL(data.Rows(i)("adj_out_sample_det_qty").ToString)
                                Dim adj_out_sample_number As String = data.Rows(i)("adj_out_sample_number").ToString
                                Dim id_sample_price As String = data.Rows(i)("id_sample_price").ToString
                                Dim adj_out_sample_det_price As String = decimalSQL(data.Rows(i)("adj_out_sample_det_price").ToString)

                                'insert stock
                                If jum_ins_i > 0 Then
                                    query_drawer_stock += ", "
                                End If
                                query_drawer_stock += "('" + id_wh_drawer + "', '1', '" + id_sample + "', '" + id_sample_price + "', '" + adj_out_sample_det_price + "','" + adj_out_sample_det_qty + "', NOW(), 'Adjusment Out Cancelled Order No: " + adj_out_sample_number + "', '21', '" + id_adj_out_sample + "', '2') "
                                jum_ins_i = jum_ins_i + 1
                            Next
                            If jum_ins_i > 0 Then
                                execute_non_query(query_drawer_stock, True, "", "", "", "")
                            End If

                            'main
                            query = String.Format("DELETE FROM tb_adj_out_sample WHERE id_adj_out_sample = '{0}'", id_adj_out_sample)
                            execute_non_query(query, True, "", "", "", "")

                            'del mark
                            delete_all_mark_related("21", id_adj_out_sample)

                            'Refresh data
                            FormSampleAdjustment.viewAdjOutSample()
                            Cursor = Cursors.Default
                        Catch ex As Exception
                            errorDelete()
                        End Try
                        Cursor = Cursors.Default
                    End If
                End If
            End If
        ElseIf formName = "FormMatAdj" Then
            'Material Adjustment
            If FormMatAdj.XTCAdj.SelectedTabPageIndex = 0 Then 'Adj In
                Dim id_adj_in_mat As String = FormMatAdj.GVAdjIn.GetFocusedRowCellDisplayText("id_adj_in_mat").ToString
                Dim id_report_status As String = FormMatAdj.GVAdjIn.GetFocusedRowCellValue("id_report_status").ToString

                If Not check_edit_report_status(id_report_status, "26", id_adj_in_mat) Or id_report_status = "5" Then
                    stopCustom("This data already locked.")
                Else
                    confirm = XtraMessageBox.Show("Are you sure want to delete this data ?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
                    If confirm = Windows.Forms.DialogResult.Yes Then
                        Cursor = Cursors.WaitCursor
                        Try
                            Cursor = Cursors.WaitCursor

                            'Dim query_cancel As String = "SELECT * FROM tb_adj_in_mat a "
                            'query_cancel += "INNER JOIN tb_adj_in_mat_det b ON a.id_adj_in_mat = b.id_adj_in_mat "
                            'query_cancel += "WHERE a.id_adj_in_mat = '" + id_adj_in_mat + "' "
                            'Dim data As DataTable = execute_query(query_cancel, -1, True, "", "", "", "")
                            'For i As Integer = 0 To (data.Rows.Count - 1)
                            '    Dim id_wh_drawer As String = data.Rows(i)("id_wh_drawer").ToString
                            '    Dim id_mat_det As String = data.Rows(i)("id_mat_det").ToString
                            '    Dim id_mat_det_price As String = data.Rows(i)("id_mat_det_price").ToString
                            '    Dim adj_in_mat_det_qty As String = decimalSQL(data.Rows(i)("adj_in_mat_det_qty").ToString)
                            '    Dim adj_in_mat_det_price As String = decimalSQL(data.Rows(i)("adj_in_mat_det_price").ToString)
                            '    Dim adj_in_mat_number As String = data.Rows(i)("adj_in_mat_number").ToString

                            '    Dim query_upd_storage As String = "INSERT tb_storage_mat(id_wh_drawer, id_storage_category, id_mat_det,id_mat_det_price,price, storage_mat_qty, storage_mat_datetime, storage_mat_notes,report_mark_type,id_report,id_stock_status) "
                            '    query_upd_storage += "VALUES('" + id_wh_drawer + "', '1', '" + id_mat_det + "','" + id_mat_det_price + "'," + adj_in_mat_det_price + ",'" + adj_in_mat_det_qty + "', NOW(), 'Material Adjustment In cancelled, Adjustment In : " + adj_in_mat_number + "','26','" & id_adj_in_mat & "','2')"
                            '    execute_non_query(query_upd_storage, True, "", "", "", "")
                            'Next
                            'main
                            query = String.Format("DELETE FROM tb_adj_in_mat WHERE id_adj_in_mat = '{0}'", id_adj_in_mat)
                            execute_non_query(query, True, "", "", "", "")
                            'del mark
                            delete_all_mark_related("26", id_adj_in_mat)
                            'Refresh
                            FormMatAdj.viewAdjIn()
                            Cursor = Cursors.Default
                        Catch ex As Exception
                            Cursor = Cursors.Default
                            errorDelete()
                        End Try
                        Cursor = Cursors.Default
                    End If
                End If
            ElseIf FormMatAdj.XTCAdj.SelectedTabPageIndex = 1 Then 'Adj Out
                Dim id_adj_out_mat As String = FormMatAdj.GVAdjOut.GetFocusedRowCellDisplayText("id_adj_out_mat").ToString
                Dim id_report_status As String = FormMatAdj.GVAdjOut.GetFocusedRowCellValue("id_report_status").ToString

                If Not check_edit_report_status(id_report_status, "27", id_adj_out_mat) Or id_report_status = "5" Then
                    stopCustom("This data already locked.")
                Else
                    confirm = XtraMessageBox.Show("Are you sure want to delete this data ?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
                    If confirm = Windows.Forms.DialogResult.Yes Then
                        Cursor = Cursors.WaitCursor
                        Try
                            Cursor = Cursors.WaitCursor
                            'stock
                            Dim query_cancel As String = "SELECT * FROM tb_adj_out_mat a "
                            query_cancel += "INNER JOIN tb_adj_out_mat_det b ON a.id_adj_out_mat = b.id_adj_out_mat "
                            query_cancel += "WHERE a.id_adj_out_mat = '" + id_adj_out_mat + "' "
                            Dim data As DataTable = execute_query(query_cancel, -1, True, "", "", "", "")
                            For i As Integer = 0 To (data.Rows.Count - 1)
                                Dim id_wh_drawer As String = data.Rows(i)("id_wh_drawer").ToString
                                Dim id_mat_det As String = data.Rows(i)("id_mat_det").ToString
                                Dim adj_out_mat_det_qty As Decimal = data.Rows(i)("adj_out_mat_det_qty")
                                Dim id_mat_det_price As String = data.Rows(i)("id_mat_det_price").ToString
                                Dim adj_out_mat_det_price As Decimal = data.Rows(i)("adj_out_mat_det_price")
                                Dim adj_out_mat_number As String = data.Rows(i)("adj_out_mat_number").ToString
                                Dim query_upd_storage As String = "INSERT tb_storage_mat(id_wh_drawer, id_storage_category, id_mat_det, storage_mat_qty, storage_mat_datetime, storage_mat_notes,id_mat_det_price,price,id_stock_status,report_mark_type,id_report) "
                                query_upd_storage += "VALUES('" + id_wh_drawer + "', '1', '" + id_mat_det + "', '" + decimalSQL(adj_out_mat_det_qty.ToString) + "', NOW(), 'Material Adjustment Out cancelled, Adjustment In : " + adj_out_mat_number + "','" & id_mat_det_price & "','" & decimalSQL(adj_out_mat_det_price.ToString) & "','2','27','" & id_adj_out_mat & "')"
                                execute_non_query(query_upd_storage, True, "", "", "", "")
                            Next

                            'main
                            query = String.Format("DELETE FROM tb_adj_out_mat WHERE id_adj_out_mat = '{0}'", id_adj_out_mat)
                            execute_non_query(query, True, "", "", "", "")

                            'del mark
                            delete_all_mark_related("27", id_adj_out_mat)

                            'Refresh data
                            FormMatAdj.viewAdjOut()
                            Cursor = Cursors.Default
                        Catch ex As Exception
                            Cursor = Cursors.Default
                            errorDelete()
                        End Try
                        Cursor = Cursors.Default
                    End If
                End If
            End If
        ElseIf formName = "FormMatPR" Then
            'PR MAT PURCHASE
            Dim id_pr_mat_purc As String = FormMatPR.GVMatPR.GetFocusedRowCellDisplayText("id_pr_mat_purc").ToString
            Dim id_report_status As String = FormMatPR.GVMatPR.GetFocusedRowCellValue("id_report_status").ToString
            If Not check_edit_report_status(id_report_status, "24", id_pr_mat_purc) Or id_report_status = "5" Then
                stopCustom("This data already locked.")
            Else
                confirm = XtraMessageBox.Show("Are you sure want to delete this payment requisition ?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
                If confirm = Windows.Forms.DialogResult.Yes Then
                    Cursor = Cursors.WaitCursor
                    Try
                        query = String.Format("DELETE FROM tb_pr_mat_purc WHERE id_pr_mat_purc = '{0}'", id_pr_mat_purc)
                        execute_non_query(query, True, "", "", "", "")

                        'del mark
                        delete_all_mark_related("24", id_pr_mat_purc)

                        FormMatPR.view_mat_pr()
                        FormMatPR.view_mat_purc()
                        FormMatPR.view_mat_rec()
                    Catch ex As Exception
                        errorDelete()
                    End Try
                    Cursor = Cursors.Default
                End If
            End If
        ElseIf formName = "FormMatPRWO" Then
            'PR MAT WO
            Dim id_pr_mat_wo As String = FormMatPRWO.GVMatPRWO.GetFocusedRowCellDisplayText("id_pr_mat_wo").ToString
            Dim id_report_status As String = FormMatPRWO.GVMatPRWO.GetFocusedRowCellValue("id_report_status").ToString
            If Not check_edit_report_status(id_report_status, "25", id_pr_mat_wo) Or id_report_status = "5" Then
                stopCustom("This data already locked.")
            Else
                confirm = XtraMessageBox.Show("Are you sure want to delete this payment requisition ?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
                If confirm = Windows.Forms.DialogResult.Yes Then
                    Cursor = Cursors.WaitCursor
                    Try
                        query = String.Format("DELETE FROM tb_pr_mat_wo WHERE id_pr_mat_wo = '{0}'", id_pr_mat_wo)
                        execute_non_query(query, True, "", "", "", "")

                        'del mark
                        delete_all_mark_related("25", id_pr_mat_wo)

                        FormMatPRWO.view_mat_pr()
                        FormMatPRWO.view_mat_wo()
                        FormMatPRWO.view_mat_rec()
                    Catch ex As Exception
                        errorDelete()
                    End Try
                    Cursor = Cursors.Default
                End If
            End If
        ElseIf formName = "FormMatPRWO" Then
            'PR MAT WO
            Dim id_pr_mat_wo As String = FormMatPRWO.GVMatPRWO.GetFocusedRowCellDisplayText("id_pr_mat_wo").ToString
            Dim id_report_status As String = FormMatPRWO.GVMatPRWO.GetFocusedRowCellValue("id_report_status").ToString
            If Not check_edit_report_status(id_report_status, "25", id_pr_mat_wo) Or id_report_status = "5" Then
                stopCustom("This data already locked.")
            Else
                confirm = XtraMessageBox.Show("Are you sure want to delete this payment requisition ?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
                If confirm = Windows.Forms.DialogResult.Yes Then
                    Cursor = Cursors.WaitCursor
                    Try
                        query = String.Format("DELETE FROM tb_pr_mat_wo WHERE id_pr_mat_wo = '{0}'", id_pr_mat_wo)
                        execute_non_query(query, True, "", "", "", "")

                        'del mark
                        delete_all_mark_related("25", id_pr_mat_wo)

                        FormMatPRWO.view_mat_pr()
                        FormMatPRWO.view_mat_wo()
                        FormMatPRWO.view_mat_rec()
                    Catch ex As Exception
                        errorDelete()
                    End Try
                    Cursor = Cursors.Default
                End If
            End If
        ElseIf formName = "FormProduction" Then
            'RETURN Mat
            If FormProduction.XTCTabProduction.SelectedTabPageIndex = 0 Then 'prod_order
                If check_edit_report_status(FormProduction.GVProd.GetFocusedRowCellDisplayText("id_report_status"), "22", FormProduction.GVProd.GetFocusedRowCellDisplayText("id_prod_order")) Then
                    confirm = XtraMessageBox.Show("Are you sure want to delete this production order?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
                    If confirm = Windows.Forms.DialogResult.Yes Then
                        Try
                            Dim id_prod_order As String = FormProduction.GVProd.GetFocusedRowCellDisplayText("id_prod_order")
                            query = String.Format("DELETE FROM tb_prod_order WHERE id_prod_order='{0}'", id_prod_order)
                            execute_non_query(query, True, "", "", "", "")

                            'del mark
                            delete_all_mark_related("22", id_prod_order)

                            FormProduction.view_production_order()
                        Catch ex As Exception
                            errorDelete()
                        End Try
                    End If
                Else
                    stopCustom("This Production Order already marked")
                End If
            End If
        ElseIf formName = "FormMatPL" Then
            'Mat PL
            If FormMatPL.XTCPL.SelectedTabPageIndex = 0 Then 'production
                If check_edit_report_status(FormMatPL.GVProdPL.GetFocusedRowCellDisplayText("id_report_status"), "30", FormMatPL.GVProdPL.GetFocusedRowCellDisplayText("id_pl_mrs")) Then
                    confirm = XtraMessageBox.Show("Are you sure want to delete this packing list ?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
                    If confirm = Windows.Forms.DialogResult.Yes Then
                        Try
                            Dim id_pl_mrs As String = FormMatPL.GVProdPL.GetFocusedRowCellDisplayText("id_pl_mrs")

                            'stock
                            Dim query_cancel As String = "SELECT b.id_wh_drawer,c.id_mat_det,CAST(IFNULL(b.pl_mrs_det_qty,0) AS DECIMAL(13,2)) as pl_mrs_det_qty,a.pl_mrs_number,b.id_mat_det_price,CAST(IFNULL(b.pl_mrs_det_price,0) AS DECIMAL(13,2)) as pl_mrs_det_price FROM tb_pl_mrs a "
                            query_cancel += "INNER JOIN tb_pl_mrs_det b ON a.id_pl_mrs = b.id_pl_mrs "
                            query_cancel += "INNER JOIN tb_prod_order_mrs_det c ON b.id_prod_order_mrs_det = c.id_prod_order_mrs_det "
                            query_cancel += "WHERE a.id_pl_mrs = '" + id_pl_mrs + "' "
                            Dim data As DataTable = execute_query(query_cancel, -1, True, "", "", "", "")
                            For i As Integer = 0 To (data.Rows.Count - 1)
                                Dim id_wh_drawer As String = data.Rows(i)("id_wh_drawer").ToString
                                Dim id_mat_det As String = data.Rows(i)("id_mat_det").ToString
                                Dim pl_mrs_det_qty As Decimal = data.Rows(i)("pl_mrs_det_qty")
                                Dim pl_mrs_number As String = data.Rows(i)("pl_mrs_number").ToString
                                Dim id_mat_det_price As String = data.Rows(i)("id_mat_det_price").ToString
                                Dim pl_mrs_det_price As Decimal = data.Rows(i)("pl_mrs_det_price")
                                Dim query_upd_storage As String = "INSERT tb_storage_mat(id_wh_drawer, id_storage_category, id_mat_det, storage_mat_qty, storage_mat_datetime, storage_mat_notes,id_mat_det_price,price,id_stock_status,report_mark_type,id_report) "
                                query_upd_storage += "VALUES('" + id_wh_drawer + "', '1', '" + id_mat_det + "', '" + decimalSQL(pl_mrs_det_qty.ToString) + "', NOW(), 'Out material was cancelled, PL : " + pl_mrs_number + "','" & id_mat_det_price & "','" & decimalSQL(pl_mrs_det_price.ToString) & "','2','30','" & id_pl_mrs & "')"
                                execute_non_query(query_upd_storage, True, "", "", "", "")
                            Next

                            query = String.Format("DELETE FROM tb_pl_mrs WHERE id_pl_mrs='{0}'", id_pl_mrs)
                            execute_non_query(query, True, "", "", "", "")

                            'del mark
                            delete_all_mark_related("30", id_pl_mrs)

                            FormMatPL.viewPL()
                        Catch ex As Exception
                            errorDelete()
                        End Try
                    End If
                Else
                    stopCustom("This Packing List already processed.")
                End If
            ElseIf FormMatPL.XTCPL.SelectedTabPageIndex = 1 Then 'wo
                If check_edit_report_status(FormMatPL.GVPLWO.GetFocusedRowCellDisplayText("id_report_status"), "30", FormMatPL.GVPLWO.GetFocusedRowCellDisplayText("id_pl_mrs")) Then
                    confirm = XtraMessageBox.Show("Are you sure want to delete this packing list?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
                    If confirm = Windows.Forms.DialogResult.Yes Then
                        'Try
                        Dim id_pl_mrs As String = FormMatPL.GVPLWO.GetFocusedRowCellDisplayText("id_pl_mrs")

                        'stock
                        Dim query_cancel As String = "SELECT b.id_wh_drawer,c.id_mat_det,CAST(IFNULL(b.pl_mrs_det_qty,0) AS DECIMAL(13,2)) as pl_mrs_det_qty,a.pl_mrs_number,b.id_mat_det_price,CAST(IFNULL(b.pl_mrs_det_price,0) AS DECIMAL(13,2)) as pl_mrs_det_price FROM tb_pl_mrs a "
                        query_cancel += "INNER JOIN tb_pl_mrs_det b ON a.id_pl_mrs = b.id_pl_mrs "
                        query_cancel += "INNER JOIN tb_prod_order_mrs_det c ON b.id_prod_order_mrs_det = c.id_prod_order_mrs_det "
                        query_cancel += "WHERE a.id_pl_mrs = '" + id_pl_mrs + "' "
                        Dim data As DataTable = execute_query(query_cancel, -1, True, "", "", "", "")
                        For i As Integer = 0 To (data.Rows.Count - 1)
                            Dim id_wh_drawer As String = data.Rows(i)("id_wh_drawer").ToString
                            Dim id_mat_det As String = data.Rows(i)("id_mat_det").ToString
                            Dim pl_mrs_det_qty As Decimal = data.Rows(i)("pl_mrs_det_qty")
                            Dim pl_mrs_number As String = data.Rows(i)("pl_mrs_number").ToString
                            Dim id_mat_det_price As String = data.Rows(i)("id_mat_det_price").ToString
                            Dim pl_mrs_det_price As Decimal = data.Rows(i)("pl_mrs_det_price")
                            Dim query_upd_storage As String = "INSERT tb_storage_mat(id_wh_drawer, id_storage_category, id_mat_det, storage_mat_qty, storage_mat_datetime, storage_mat_notes,id_mat_det_price,price,id_stock_status,report_mark_type,id_report) "

                            query_upd_storage += "VALUES('" + id_wh_drawer + "', '1', '" + id_mat_det + "', '" + decimalSQL(pl_mrs_det_qty.ToString) + "', NOW(), 'Out material was cancelled, PL : " + pl_mrs_number + "','" & id_mat_det_price & "','" & decimalSQL(pl_mrs_det_price.ToString) & "','2','30','" & id_pl_mrs & "')"
                            execute_non_query(query_upd_storage, True, "", "", "", "")
                        Next

                        query = String.Format("DELETE FROM tb_pl_mrs WHERE id_pl_mrs='{0}'", id_pl_mrs)
                        execute_non_query(query, True, "", "", "", "")

                        'del mark
                        delete_all_mark_related("30", id_pl_mrs)

                        FormMatPL.viewPLWO()
                        'Catch ex As Exception
                        'errorDelete()
                        ' End Try
                    End If
                Else
                    stopCustom("This Packing List already processed.")
                End If
            ElseIf FormMatPL.XTCPL.SelectedTabPageIndex = 2 Then 'other
                If check_edit_report_status(FormMatPL.GVPLOther.GetFocusedRowCellDisplayText("id_report_status"), "30", FormMatPL.GVPLOther.GetFocusedRowCellDisplayText("id_pl_mrs")) Then
                    confirm = XtraMessageBox.Show("Are you sure want to delete this packing list?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
                    If confirm = Windows.Forms.DialogResult.Yes Then
                        Try
                            Dim id_pl_mrs As String = FormMatPL.GVPLOther.GetFocusedRowCellDisplayText("id_pl_mrs")

                            'stock
                            Dim query_cancel As String = "SELECT b.id_wh_drawer,c.id_mat_det,CAST(IFNULL(b.pl_mrs_det_qty,0) AS DECIMAL(13,2)) as pl_mrs_det_qty,a.pl_mrs_number,b.id_mat_det_price,CAST(IFNULL(b.pl_mrs_det_price,0) AS DECIMAL(13,2)) as pl_mrs_det_price FROM tb_pl_mrs a "
                            query_cancel += "INNER JOIN tb_pl_mrs_det b ON a.id_pl_mrs = b.id_pl_mrs "
                            query_cancel += "INNER JOIN tb_prod_order_mrs_det c ON b.id_prod_order_mrs_det = c.id_prod_order_mrs_det "
                            query_cancel += "WHERE a.id_pl_mrs = '" + id_pl_mrs + "' "
                            Dim data As DataTable = execute_query(query_cancel, -1, True, "", "", "", "")
                            For i As Integer = 0 To (data.Rows.Count - 1)
                                Dim id_wh_drawer As String = data.Rows(i)("id_wh_drawer").ToString
                                Dim id_mat_det As String = data.Rows(i)("id_mat_det").ToString
                                Dim pl_mrs_det_qty As Decimal = data.Rows(i)("pl_mrs_det_qty")
                                Dim pl_mrs_number As String = data.Rows(i)("pl_mrs_number").ToString
                                Dim id_mat_det_price As String = data.Rows(i)("id_mat_det_price").ToString
                                Dim pl_mrs_det_price As Decimal = data.Rows(i)("pl_mrs_det_price")
                                Dim query_upd_storage As String = "INSERT tb_storage_mat(id_wh_drawer, id_storage_category, id_mat_det, storage_mat_qty, storage_mat_datetime, storage_mat_notes,id_mat_det_price,price,id_stock_status,report_mark_type,id_report) "

                                query_upd_storage += "VALUES('" + id_wh_drawer + "', '1', '" + id_mat_det + "', '" + decimalSQL(pl_mrs_det_qty.ToString) + "', NOW(), 'Out material was cancelled, PL : " + pl_mrs_number + "','" & id_mat_det_price & "','" & decimalSQL(pl_mrs_det_price.ToString) & "','2','30','" & id_pl_mrs & "')"
                                execute_non_query(query_upd_storage, True, "", "", "", "")
                            Next

                            query = String.Format("DELETE FROM tb_pl_mrs WHERE id_pl_mrs='{0}'", id_pl_mrs)
                            execute_non_query(query, True, "", "", "", "")

                            'del mark
                            delete_all_mark_related("30", id_pl_mrs)

                            FormMatPL.viewPLOther()
                        Catch ex As Exception
                            errorDelete()
                        End Try
                    End If
                Else
                    stopCustom("This Packing List already processed.")
                End If
            End If
        ElseIf formName = "FormMatMRS" Then
            'MRS Material
            If FormMatMRS.XTCMRS.SelectedTabPageIndex = 0 Then 'wo
                If check_edit_report_status(FormMatMRS.GVMRSWO.GetFocusedRowCellDisplayText("id_report_status"), "29", FormMatMRS.GVMRSWO.GetFocusedRowCellDisplayText("id_prod_order_mrs")) Then
                    confirm = XtraMessageBox.Show("Are you sure want to delete this Material Requesition?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
                    If confirm = Windows.Forms.DialogResult.Yes Then
                        Try
                            Dim id_mrs As String = FormMatMRS.GVMRSWO.GetFocusedRowCellDisplayText("id_prod_order_mrs")
                            query = String.Format("DELETE FROM tb_prod_order_mrs WHERE id_prod_order_mrs='{0}'", id_mrs)
                            execute_non_query(query, True, "", "", "", "")

                            'del mark
                            delete_all_mark_related("29", id_mrs)

                            FormMatMRS.view_mrs_wo()
                        Catch ex As Exception
                            errorDelete()
                        End Try
                    End If
                Else
                    stopCustom("This Material Requisition already processed.")
                End If
            Else 'other
                If check_edit_report_status(FormMatMRS.GVMRS.GetFocusedRowCellDisplayText("id_report_status"), "29", FormMatMRS.GVMRS.GetFocusedRowCellDisplayText("id_prod_order_mrs")) Then
                    confirm = XtraMessageBox.Show("Are you sure want to delete this Material Requesition?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
                    If confirm = Windows.Forms.DialogResult.Yes Then
                        Try
                            Dim id_mrs As String = FormMatMRS.GVMRS.GetFocusedRowCellDisplayText("id_prod_order_mrs")
                            query = String.Format("DELETE FROM tb_prod_order_mrs WHERE id_prod_order_mrs='{0}'", id_mrs)
                            execute_non_query(query, True, "", "", "", "")

                            'del mark
                            delete_all_mark_related("29", id_mrs)

                            FormMatMRS.view_mrs()
                        Catch ex As Exception
                            errorDelete()
                        End Try
                    End If
                Else
                    stopCustom("This Material Requisition already processed.")
                End If
            End If
        ElseIf formName = "FormProductionRec" Then
            'Receiving QC
            '
            'check first
            If check_edit_report_status(FormProductionRec.GVProdRec.GetFocusedRowCellDisplayText("id_report_status"), "28", FormProductionRec.GVProdRec.GetFocusedRowCellDisplayText("id_prod_order_rec")) Then
                confirm = XtraMessageBox.Show("Are you sure want to delete this receive?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
                If confirm = Windows.Forms.DialogResult.Yes Then
                    Try
                        Dim id_prod_order_rec As String = FormProductionRec.GVProdRec.GetFocusedRowCellDisplayText("id_prod_order_rec")
                        query = String.Format("DELETE FROM tb_prod_order_rec WHERE id_prod_order_rec='{0}'", id_prod_order_rec)
                        execute_non_query(query, True, "", "", "", "")

                        'del mark
                        delete_all_mark_related("28", id_prod_order_rec)

                        FormProductionRec.view_prod_order_rec()
                        FormProductionRec.view_prod_order()
                    Catch ex As Exception
                        errorDelete()
                    End Try
                End If
            Else
                stopCustom("This Receive already marked")
            End If
        ElseIf formName = "FormProductionRet" Then
            'RETURN FG
            If FormProductionRet.XTCReturn.SelectedTabPageIndex = 0 Then 'return Out
                If check_edit_report_status(FormProductionRet.GVRetOut.GetFocusedRowCellValue("id_report_status"), "31", FormProductionRet.GVRetOut.GetFocusedRowCellDisplayText("id_prod_order_ret_out")) Then
                    confirm = XtraMessageBox.Show("Are you sure want to delete this return?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
                    If confirm = Windows.Forms.DialogResult.Yes Then
                        Try
                            Dim id_prod_order_ret_out As String = FormProductionRet.GVRetOut.GetFocusedRowCellDisplayText("id_prod_order_ret_out")
                            query = String.Format("DELETE FROM tb_prod_order_ret_out WHERE id_prod_order_ret_out='{0}'", id_prod_order_ret_out)
                            execute_non_query(query, True, "", "", "", "")

                            'del mark
                            delete_all_mark_related("31", id_prod_order_ret_out)

                            FormProductionRet.viewRetOut()
                        Catch ex As Exception
                            errorDelete()
                        End Try
                    End If
                Else
                    stopCustom("This Return already marked")
                End If
            ElseIf FormProductionRet.XTCReturn.SelectedTabPageIndex = 1 Then 'return In
                If check_edit_report_status(FormProductionRet.GVRetIn.GetFocusedRowCellValue("id_report_status"), "32", FormProductionRet.GVRetIn.GetFocusedRowCellDisplayText("id_prod_order_ret_in")) Then
                    confirm = XtraMessageBox.Show("Are you sure want to delete this return?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
                    If confirm = Windows.Forms.DialogResult.Yes Then
                        Try
                            Dim id_prod_order_ret_in As String = FormProductionRet.GVRetIn.GetFocusedRowCellDisplayText("id_prod_order_ret_in")
                            query = String.Format("DELETE FROM tb_prod_order_ret_in WHERE id_prod_order_ret_in='{0}'", id_prod_order_ret_in)
                            execute_non_query(query, True, "", "", "", "")

                            'del mark
                            delete_all_mark_related("32", id_prod_order_ret_in)

                            FormProductionRet.viewRetIn()
                        Catch ex As Exception
                            errorDelete()
                        End Try
                    End If
                Else
                    stopCustom("This Return already marked")
                End If
            End If
        ElseIf formName = "FormProductionPLToWH" Then
            If check_edit_report_status(FormProductionPLToWH.GVPL.GetFocusedRowCellValue("id_report_status"), "33", FormProductionPLToWH.GVPL.GetFocusedRowCellDisplayText("id_pl_prod_order")) Then
                confirm = XtraMessageBox.Show("Are you sure want to delete this data?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
                If confirm = Windows.Forms.DialogResult.Yes Then
                    Try
                        Dim id_pl_prod_order As String = FormProductionPLToWH.GVPL.GetFocusedRowCellDisplayText("id_pl_prod_order")
                        query = String.Format("DELETE FROM tb_pl_prod_order WHERE id_pl_prod_order ='{0}'", id_pl_prod_order)
                        execute_non_query(query, True, "", "", "", "")

                        'del mark
                        delete_all_mark_related("33", id_pl_prod_order)

                        FormProductionPLToWH.viewPL()
                        FormProductionPLToWH.view_sample_purc()
                    Catch ex As Exception
                        errorDelete()
                    End Try
                End If
            Else
                stopCustom("This data already marked")
            End If
        ElseIf formName = "FormMatInvoice" Then
            'Invoice Material PL MRS
            If FormMatInvoice.XTCTabGeneral.SelectedTabPageIndex = 0 Then 'invoice
                If check_edit_report_status(FormMatInvoice.GVProdInvoice.GetFocusedRowCellDisplayText("id_report_status"), "34", FormMatInvoice.GVProdInvoice.GetFocusedRowCellDisplayText("id_inv_pl_mrs")) Then
                    confirm = XtraMessageBox.Show("Are you sure want to delete this invoice?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
                    If confirm = Windows.Forms.DialogResult.Yes Then
                        Try
                            Dim id_invoice As String = FormMatInvoice.GVProdInvoice.GetFocusedRowCellDisplayText("id_inv_pl_mrs")
                            query = String.Format("DELETE FROM tb_inv_pl_mrs WHERE id_inv_pl_mrs='{0}'", id_invoice)
                            execute_non_query(query, True, "", "", "", "")

                            'del mark
                            delete_all_mark_related("34", id_invoice)

                            FormMatInvoice.viewInv()
                        Catch ex As Exception
                            errorDelete()
                        End Try
                    End If
                Else
                    stopCustom("This invoice already processed.")
                End If
            Else 'retur
                If check_edit_report_status(FormMatInvoice.GVRetur.GetFocusedRowCellDisplayText("id_report_status"), "35", FormMatInvoice.GVRetur.GetFocusedRowCellDisplayText("id_inv_pl_mrs_ret")) Then
                    confirm = XtraMessageBox.Show("Are you sure want to delete this invoice?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
                    If confirm = Windows.Forms.DialogResult.Yes Then
                        Try
                            Dim id_retur As String = FormMatInvoice.GVRetur.GetFocusedRowCellDisplayText("id_inv_pl_mrs_ret")
                            query = String.Format("DELETE FROM tb_inv_pl_mrs_ret WHERE id_inv_pl_mrs_ret='{0}'", id_retur)
                            execute_non_query(query, True, "", "", "", "")

                            'del mark
                            delete_all_mark_related("35", id_retur)

                            FormMatInvoice.view_retur()
                        Catch ex As Exception
                            errorDelete()
                        End Try
                    End If
                Else
                    stopCustom("This invoice already processed.")
                End If
            End If
        ElseIf formName = "FormAccountingJournal" Then
            errorCustom("You can't delete journal entry.")
        ElseIf formName = "FormProductionPLToWHRec" Then
            If check_edit_report_status(FormProductionPLToWHRec.GVPL.GetFocusedRowCellValue("id_report_status"), "37", FormProductionPLToWHRec.GVPL.GetFocusedRowCellDisplayText("id_pl_prod_order_rec")) Then
                confirm = XtraMessageBox.Show("Are you sure want to delete this data?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
                If confirm = Windows.Forms.DialogResult.Yes Then
                    Try
                        Dim id_pl_prod_order_rec As String = FormProductionPLToWHRec.GVPL.GetFocusedRowCellDisplayText("id_pl_prod_order_rec")
                        query = String.Format("DELETE FROM tb_pl_prod_order_rec WHERE id_pl_prod_order_rec ='{0}'", id_pl_prod_order_rec)
                        execute_non_query(query, True, "", "", "", "")

                        'del mark
                        delete_all_mark_related("37", id_pl_prod_order_rec)

                        FormProductionPLToWHRec.viewPL()
                        FormProductionPLToWHRec.view_sample_purc()
                    Catch ex As Exception
                        errorDelete()
                    End Try
                End If
            Else
                stopCustom("This data already marked")
            End If
        ElseIf formName = "FormSalesTarget" Then
            'SALES TARGET
            If check_edit_report_status(FormSalesTarget.GVSalesTarget.GetFocusedRowCellValue("id_report_status"), "38", FormSalesTarget.GVSalesTarget.GetFocusedRowCellValue("id_sales_target")) Then
                confirm = XtraMessageBox.Show("Are you sure want to delete this data?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
                If confirm = Windows.Forms.DialogResult.Yes Then
                    Try
                        Dim id_sales_target As String = FormSalesTarget.GVSalesTarget.GetFocusedRowCellValue("id_sales_target")
                        query = String.Format("DELETE FROM tb_sales_target WHERE id_sales_target ='{0}'", id_sales_target)
                        execute_non_query(query, True, "", "", "", "")

                        'del mark
                        delete_all_mark_related("38", id_sales_target)

                        FormSalesTarget.viewSalesTarget()
                    Catch ex As Exception
                        errorDelete()
                    End Try
                End If
            Else
                stopCustom("This data already marked")
            End If
        ElseIf formName = "FormSalesOrder" Then
            'SALES ORDER
            If FormSalesOrder.XTCSOGeneral.SelectedTabPageIndex = 0 Then
                If check_edit_report_status(FormSalesOrder.GVSalesOrder.GetFocusedRowCellValue("id_report_status"), "39", FormSalesOrder.GVSalesOrder.GetFocusedRowCellValue("id_sales_order")) Then
                    confirm = XtraMessageBox.Show("Are you sure want to delete this data?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
                    If confirm = Windows.Forms.DialogResult.Yes Then
                        Try
                            Dim id_sales_order As String = FormSalesOrder.GVSalesOrder.GetFocusedRowCellValue("id_sales_order")

                            'cancel reserve
                            Dim cancel As New ClassSalesOrder()
                            cancel.cancelReservedStock(id_sales_order)

                            'del so
                            query = String.Format("DELETE FROM tb_sales_order WHERE id_sales_order ='{0}'", id_sales_order)
                            execute_non_query(query, True, "", "", "", "")

                            'del mark
                            delete_all_mark_related("39", id_sales_order)
                            FormSalesOrder.viewSalesOrder()
                        Catch ex As Exception
                            errorDelete()
                        End Try
                    End If
                Else
                    stopCustom("This data already marked")
                End If
            ElseIf FormSalesOrder.XTCSOGeneral.SelectedTabPageIndex = 1 Then
                If Not FormSalesOrder.GVGen.GetFocusedRowCellValue("is_submit").ToString = "1" Then
                    If check_edit_report_status(FormSalesOrder.GVGen.GetFocusedRowCellValue("id_report_status"), "88", FormSalesOrder.GVGen.GetFocusedRowCellValue("id_sales_order_gen")) Then
                        confirm = XtraMessageBox.Show("Are you sure want to delete this data?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
                        If confirm = Windows.Forms.DialogResult.Yes Then
                            Try
                                Dim id_sales_order_gen As String = FormSalesOrder.GVGen.GetFocusedRowCellValue("id_sales_order_gen")

                                query = String.Format("DELETE FROM tb_sales_order_gen WHERE id_sales_order_gen ='{0}'", id_sales_order_gen)
                                execute_non_query(query, True, "", "", "", "")

                                'del mark
                                delete_all_mark_related("88", id_sales_order_gen)
                                FormSalesOrder.viewSalesOrderGen()
                            Catch ex As Exception
                                errorDelete()
                            End Try
                        End If
                    Else
                        stopCustom("This data already marked")
                    End If
                Else
                    stopCustom("This data already submitted")
                End If
            End If
        ElseIf formName = "FormSalesDelOrder" Then
            'SALES DEL ORDER
            If check_edit_report_status(FormSalesDelOrder.GVSalesDelOrder.GetFocusedRowCellValue("id_report_status"), "43", FormSalesDelOrder.GVSalesDelOrder.GetFocusedRowCellValue("id_pl_sales_order_del")) Then
                confirm = XtraMessageBox.Show("Are you sure want to delete this data?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
                If confirm = Windows.Forms.DialogResult.Yes Then
                    Try
                        Dim id_pl_sales_order_del As String = FormSalesDelOrder.GVSalesDelOrder.GetFocusedRowCellValue("id_pl_sales_order_del")

                        'del mark
                        delete_all_mark_related("43", id_pl_sales_order_del)

                        'del data
                        query = String.Format("DELETE FROM tb_pl_sales_order_del WHERE id_pl_sales_order_del ='{0}'", id_pl_sales_order_del)
                        execute_non_query(query, True, "", "", "", "")

                        FormSalesDelOrder.viewSalesDelOrder()
                    Catch ex As Exception
                        errorDelete()
                    End Try
                End If
            Else
                stopCustom("This data already marked")
            End If
        ElseIf formName = "FormSalesReturnOrder" Then
            'SALES RETURN ORDER
            If check_edit_report_status(FormSalesReturnOrder.GVSalesReturnOrder.GetFocusedRowCellValue("id_report_status"), "45", FormSalesReturnOrder.GVSalesReturnOrder.GetFocusedRowCellValue("id_sales_return_order")) Then
                confirm = XtraMessageBox.Show("Are you sure want to delete this data?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
                If confirm = Windows.Forms.DialogResult.Yes Then
                    Try
                        Dim id_sales_return_order As String = FormSalesReturnOrder.GVSalesReturnOrder.GetFocusedRowCellValue("id_sales_return_order")
                        query = String.Format("DELETE FROM tb_sales_return_order WHERE id_sales_return_order ='{0}'", id_sales_return_order)
                        execute_non_query(query, True, "", "", "", "")

                        'del mark
                        delete_all_mark_related("45", id_sales_return_order)
                        FormSalesReturnOrder.viewSalesReturnOrder()
                    Catch ex As Exception
                        errorDelete()
                    End Try
                End If
            Else
                stopCustom("This data already marked")
            End If
        ElseIf formName = "FormSalesReturn" Then
            'SALES RETURN
            If check_edit_report_status(FormSalesReturn.GVSalesReturn.GetFocusedRowCellValue("id_report_status"), "46", FormSalesReturn.GVSalesReturn.GetFocusedRowCellValue("id_sales_return")) Then
                confirm = XtraMessageBox.Show("Are you sure want to delete this data?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
                If confirm = Windows.Forms.DialogResult.Yes Then
                    Try
                        Dim id_sales_return As String = FormSalesReturn.GVSalesReturn.GetFocusedRowCellValue("id_sales_return")

                        'cancel reserved
                        Dim stc_cancel As ClassSalesReturn = New ClassSalesReturn()
                        stc_cancel.cancelReservedStock(id_sales_return)

                        'delete
                        query = String.Format("DELETE FROM tb_sales_return WHERE id_sales_return ='{0}'", id_sales_return)
                        execute_non_query(query, True, "", "", "", "")

                        'del mark
                        delete_all_mark_related("46", id_sales_return)
                        FormSalesReturn.viewSalesReturn()
                        FormSalesReturn.viewSalesReturnOrder()
                    Catch ex As Exception
                        errorDelete()
                    End Try
                End If
            Else
                stopCustom("This data already marked")
            End If
        ElseIf formName = "FormSalesPOS" Then
            'SALES POS
            If check_edit_report_status(FormSalesPOS.GVSalesPOS.GetFocusedRowCellValue("id_report_status"), "48", FormSalesPOS.GVSalesPOS.GetFocusedRowCellValue("id_sales_pos")) Then
                confirm = XtraMessageBox.Show("Are you sure want to delete this data?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
                If confirm = Windows.Forms.DialogResult.Yes Then
                    Try
                        Dim id_sales_pos As String = FormSalesPOS.GVSalesPOS.GetFocusedRowCellValue("id_sales_pos")

                        'rollback stock
                        Dim rsv_stock As ClassSalesInv = New ClassSalesInv()
                        rsv_stock.cancelReservedStock(id_sales_pos, "48")

                        'del data
                        query = String.Format("DELETE FROM tb_sales_pos WHERE id_sales_pos ='{0}'", id_sales_pos)
                        execute_non_query(query, True, "", "", "", "")

                        'del mark
                        delete_all_mark_related("48", id_sales_pos)
                        FormSalesPOS.viewSalesPOS()
                    Catch ex As Exception
                        errorDelete()
                    End Try
                End If
            Else
                stopCustom("This data already marked")
            End If
        ElseIf formName = "FormSalesReturnQC" Then
            'SALES RETURN QC
            If check_edit_report_status(FormSalesReturnQC.GVSalesReturnQC.GetFocusedRowCellValue("id_report_status"), "49", FormSalesReturnQC.GVSalesReturnQC.GetFocusedRowCellValue("id_sales_return_qc")) Then
                confirm = XtraMessageBox.Show("Are you sure want to delete this data?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
                If confirm = Windows.Forms.DialogResult.Yes Then
                    Try
                        Dim id_sales_return_qc As String = FormSalesReturnQC.GVSalesReturnQC.GetFocusedRowCellValue("id_sales_return_qc").ToString
                        query = String.Format("DELETE FROM tb_sales_return_qc WHERE id_sales_return_qc ='{0}'", id_sales_return_qc)
                        execute_non_query(query, True, "", "", "", "")

                        'del mark
                        delete_all_mark_related("49", id_sales_return_qc)
                        FormSalesReturnQC.viewSalesReturnQC()
                        FormSalesReturnQC.viewSalesReturn()
                        'FormSalesReturnQC.viewSalesReturnOrder()
                    Catch ex As Exception
                        errorDelete()
                    End Try
                End If
            Else
                stopCustom("This data already marked")
            End If
        ElseIf formName = "FormAccountingJournalAdj" Then
            If check_edit_report_status(FormAccountingJournalAdj.GVAccTrans.GetFocusedRowCellValue("id_report_status"), "40", FormAccountingJournalAdj.GVAccTrans.GetFocusedRowCellDisplayText("id_acc_trans_adj")) Then
                confirm = XtraMessageBox.Show("Are you sure want to delete this adjustment?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
                If confirm = Windows.Forms.DialogResult.Yes Then
                    Try
                        Dim id_acc_trans_adj As String = FormAccountingJournalAdj.GVAccTrans.GetFocusedRowCellDisplayText("id_acc_trans_adj")
                        query = String.Format("DELETE FROM tb_a_acc_trans_adj WHERE id_acc_trans_adj ='{0}'", id_acc_trans_adj)
                        execute_non_query(query, True, "", "", "", "")

                        'del mark
                        delete_all_mark_related("40", id_acc_trans_adj)

                        FormAccountingJournalAdj.view_jurnal()
                    Catch ex As Exception
                        errorDelete()
                    End Try
                End If
            Else
                stopCustom("This data already marked")
            End If
        ElseIf formName = "FormProdPRWO" Then
            If FormProdPRWO.XTCTabPR.SelectedTabPageIndex = 0 Then
                If check_edit_report_status(FormProdPRWO.GVMatPR.GetFocusedRowCellValue("id_report_status"), "50", FormProdPRWO.GVMatPR.GetFocusedRowCellDisplayText("id_pr_prod_order")) Then
                    confirm = XtraMessageBox.Show("Are you sure want to delete this payment request?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
                    If confirm = Windows.Forms.DialogResult.Yes Then
                        Try
                            Dim id_pr_prod_order As String = FormProdPRWO.GVMatPR.GetFocusedRowCellDisplayText("id_pr_prod_order")
                            query = String.Format("DELETE FROM tb_pr_prod_order WHERE id_pr_prod_order ='{0}'", id_pr_prod_order)
                            execute_non_query(query, True, "", "", "", "")

                            'del mark
                            delete_all_mark_related("50", id_pr_prod_order)

                            FormProdPRWO.view_pr()
                        Catch ex As Exception
                            errorDelete()
                        End Try
                    End If
                Else
                    stopCustom("This data already processed.")
                End If
            End If
        ElseIf formName = "FormSalesInvoice" Then
            'SALES INVOICE
            If check_edit_report_status(FormSalesInvoice.GVSalesInvoice.GetFocusedRowCellValue("id_report_status"), "51", FormSalesInvoice.GVSalesInvoice.GetFocusedRowCellValue("id_sales_invoice")) Then
                confirm = XtraMessageBox.Show("Are you sure want to delete this data?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
                If confirm = Windows.Forms.DialogResult.Yes Then
                    Try
                        Dim id_sales_invoice As String = FormSalesInvoice.GVSalesInvoice.GetFocusedRowCellValue("id_sales_invoice").ToString
                        query = String.Format("DELETE FROM tb_sales_invoice WHERE id_sales_invoice ='{0}'", id_sales_invoice)
                        execute_non_query(query, True, "", "", "", "")

                        'del mark
                        delete_all_mark_related("51", id_sales_invoice)
                        FormSalesInvoice.viewSalesInvoice()
                        'FormSalesReturnQC.viewSalesReturnOrder()
                    Catch ex As Exception
                        errorDelete()
                    End Try
                End If
            Else
                stopCustom("This data already marked")
            End If
        ElseIf formName = "FormFGStockOpnameStore" Then
            If check_edit_report_status(FormFGStockOpnameStore.GVSOStore.GetFocusedRowCellValue("id_report_status"), "53", FormFGStockOpnameStore.GVSOStore.GetFocusedRowCellValue("id_fg_so_store")) Then
                confirm = XtraMessageBox.Show("Are you sure want to delete this data?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
                If confirm = Windows.Forms.DialogResult.Yes Then
                    Try
                        Dim id_fg_so_store As String = FormFGStockOpnameStore.GVSOStore.GetFocusedRowCellValue("id_fg_so_store").ToString
                        query = String.Format("DELETE FROM tb_fg_so_store WHERE id_fg_so_store ='{0}'", id_fg_so_store)
                        execute_non_query(query, True, "", "", "", "")

                        'del mark
                        delete_all_mark_related("53", id_fg_so_store)
                        FormFGStockOpnameStore.viewSoStore()
                        'FormSalesReturnQC.viewSalesReturnOrder()
                    Catch ex As Exception
                        errorDelete()
                    End Try
                End If
            Else
                stopCustom("This data already marked")
            End If
        ElseIf formName = "FormFGMissing" Then
            'FG MISSING
            If FormFGMissing.XTCFGMissing.SelectedTabPageIndex = 0 Then
                If check_edit_report_status(FormFGMissing.GVFGMissing.GetFocusedRowCellValue("id_report_status"), "54", FormFGMissing.GVFGMissing.GetFocusedRowCellValue("id_sales_pos")) Then
                    confirm = XtraMessageBox.Show("Are you sure want to delete this data?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
                    If confirm = Windows.Forms.DialogResult.Yes Then
                        Try
                            Dim id_fg_missing As String = FormFGMissing.GVFGMissing.GetFocusedRowCellValue("id_sales_pos").ToString

                            'cancelled
                            Dim cancel_rsv_stock As ClassSalesInv = New ClassSalesInv()
                            cancel_rsv_stock.cancelReservedStock(id_fg_missing, "54")


                            query = String.Format("DELETE FROM tb_sales_pos WHERE id_sales_pos ='{0}'", id_fg_missing)
                            execute_non_query(query, True, "", "", "", "")

                            'utk missing terkait stock opname
                            query = String.Format("UPDATE tb_fg_so_store SET id_sales_pos_ref=NULL WHERE id_sales_pos_ref='{0}'", id_fg_missing)
                            execute_non_query(query, True, "", "", "", "")

                            'del mark
                            delete_all_mark_related("54", id_fg_missing)
                            FormFGMissing.viewFGMissing()
                        Catch ex As Exception
                            errorDelete()
                        End Try
                    End If
                Else
                    stopCustom("This data already marked")
                End If
            ElseIf FormFGMissing.XTCFGMissing.SelectedTabPageIndex = 1 Then
                If check_edit_report_status(FormFGMissing.GVMissingWH.GetFocusedRowCellValue("id_report_status"), "77", FormFGMissing.GVMissingWH.GetFocusedRowCellValue("id_sales_pos")) Then
                    confirm = XtraMessageBox.Show("Are you sure want to delete this data?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
                    If confirm = Windows.Forms.DialogResult.Yes Then
                        Try
                            Dim id_fg_missing As String = FormFGMissing.GVMissingWH.GetFocusedRowCellValue("id_sales_pos").ToString
                            query = String.Format("DELETE FROM tb_sales_pos WHERE id_sales_pos ='{0}'", id_fg_missing)
                            execute_non_query(query, True, "", "", "", "")

                            'del mark
                            delete_all_mark_related("77", id_fg_missing)

                            'update ref in stock opname
                            query = String.Format("UPDATE tb_sales_pos SET id_sales_pos_ref=NULL WHERE id_sales_pos_ref ='{0}'", id_fg_missing)
                            execute_non_query(query, True, "", "", "", "")

                            FormFGMissing.viewFGMissingWH()
                        Catch ex As Exception
                            errorDelete()
                        End Try
                    End If
                Else
                    stopCustom("This data already marked")
                End If
            End If
        ElseIf formName = "FormFGMissingInvoice" Then
            'FG MISSING INVOICE
            If check_edit_report_status(FormFGMissingInvoice.GVFGMissingInvoice.GetFocusedRowCellValue("id_report_status"), "55", FormFGMissingInvoice.GVFGMissingInvoice.GetFocusedRowCellValue("id_fg_missing_invoice")) Then
                confirm = XtraMessageBox.Show("Are you sure want to delete this data?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
                If confirm = Windows.Forms.DialogResult.Yes Then
                    Try
                        Dim id_fg_missing_invoice As String = FormFGMissingInvoice.GVFGMissingInvoice.GetFocusedRowCellValue("id_fg_missing_invoice").ToString
                        query = String.Format("DELETE FROM tb_fg_missing_invoice WHERE id_fg_missing_invoice ='{0}'", id_fg_missing_invoice)
                        execute_non_query(query, True, "", "", "", "")

                        query = String.Format("UPDATE tb_fg_so_store SET id_sales_pos_ref=NULL WHERE id_sales_pos_ref='{0}'", id_fg_missing_invoice)
                        execute_non_query(query, True, "", "", "", "")
                        'del mark
                        delete_all_mark_related("55", id_fg_missing_invoice)
                        FormFGMissingInvoice.viewFGMissingInvoice()
                        'FormSalesReturnQC.viewSalesReturnOrder()
                    Catch ex As Exception
                        errorDelete()
                    End Try
                End If
            Else
                stopCustom("This data already marked")
            End If
        ElseIf formName = "FormFGStockOpnameWH" Then
            'WH STOCK OPNAME
            If check_edit_report_status(FormFGStockOpnameWH.GVSOWH.GetFocusedRowCellValue("id_report_status"), "56", FormFGStockOpnameWH.GVSOWH.GetFocusedRowCellValue("id_fg_so_wh")) Then
                confirm = XtraMessageBox.Show("Are you sure want to delete this data?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
                If confirm = Windows.Forms.DialogResult.Yes Then
                    Try
                        Dim id_fg_so_wh As String = FormFGStockOpnameWH.GVSOWH.GetFocusedRowCellValue("id_fg_so_wh").ToString
                        query = String.Format("DELETE FROM tb_fg_so_wh WHERE id_fg_so_wh ='{0}'", id_fg_so_wh)
                        execute_non_query(query, True, "", "", "", "")

                        'del mark
                        delete_all_mark_related("56", id_fg_so_wh)
                        FormFGStockOpnameWH.viewSOWH()
                        'FormSalesReturnQC.viewSalesReturnOrder()
                    Catch ex As Exception
                        errorDelete()
                    End Try
                End If
            Else
                stopCustom("This data already marked")
            End If
        ElseIf formName = "FormMatStockOpname" Then
            If check_edit_report_status(FormMatStockOpname.GVMatPR.GetFocusedRowCellValue("id_report_status"), "52", FormMatStockOpname.GVMatPR.GetFocusedRowCellDisplayText("id_mat_so")) Then
                confirm = XtraMessageBox.Show("Are you sure want to delete this stock opname?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
                If confirm = Windows.Forms.DialogResult.Yes Then
                    Try
                        Dim id_mat_so As String = FormMatStockOpname.GVMatPR.GetFocusedRowCellDisplayText("id_mat_so")
                        query = String.Format("DELETE FROM tb_mat_so WHERE id_mat_so ='{0}'", id_mat_so)
                        execute_non_query(query, True, "", "", "", "")

                        'del mark
                        delete_all_mark_related("52", id_mat_so)

                        FormMatStockOpname.view_so()
                    Catch ex As Exception
                        errorDelete()
                    End Try
                End If
            Else
                stopCustom("This data already marked")
            End If
        ElseIf formName = "FormFGAdj" Then
            'FG Adjustment
            If FormFGAdj.XTCAdj.SelectedTabPageIndex = 0 Then 'Adj In
                Dim id_adj_in_fg As String = FormFGAdj.GVAdjIn.GetFocusedRowCellValue("id_adj_in_fg").ToString
                Dim id_report_status As String = FormFGAdj.GVAdjIn.GetFocusedRowCellValue("id_report_status").ToString

                If Not check_edit_report_status(id_report_status, "41", id_adj_in_fg) Or id_report_status = "5" Then
                    stopCustom("This data already locked.")
                Else
                    confirm = XtraMessageBox.Show("Are you sure want to delete this data ?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
                    If confirm = Windows.Forms.DialogResult.Yes Then
                        Cursor = Cursors.WaitCursor
                        Try
                            Cursor = Cursors.WaitCursor

                            'main
                            query = String.Format("DELETE FROM tb_adj_in_fg WHERE id_adj_in_fg = '{0}'", id_adj_in_fg)
                            execute_non_query(query, True, "", "", "", "")
                            'del mark
                            delete_all_mark_related("41", id_adj_in_fg)
                            'Refresh
                            FormFGAdj.viewAdjIn()
                            Cursor = Cursors.Default
                        Catch ex As Exception
                            Cursor = Cursors.Default
                            errorDelete()
                        End Try
                        Cursor = Cursors.Default
                    End If
                End If
            ElseIf FormFGAdj.XTCAdj.SelectedTabPageIndex = 1 Then 'Adj Out
                Dim id_adj_out_fg As String = FormFGAdj.GVAdjOut.GetFocusedRowCellDisplayText("id_adj_out_fg").ToString
                Dim id_report_status As String = FormFGAdj.GVAdjOut.GetFocusedRowCellValue("id_report_status").ToString

                If Not check_edit_report_status(id_report_status, "42", id_adj_out_fg) Or id_report_status = "5" Then
                    stopCustom("This data already locked.")
                Else
                    confirm = XtraMessageBox.Show("Are you sure want to delete this data ?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
                    If confirm = Windows.Forms.DialogResult.Yes Then
                        Cursor = Cursors.WaitCursor
                        Try
                            Cursor = Cursors.WaitCursor
                            'stock
                            Dim query_cancel As String = "SELECT * FROM tb_adj_out_fg a "
                            query_cancel += "INNER JOIN tb_adj_out_fg_det b ON a.id_adj_out_fg = b.id_adj_out_fg "
                            query_cancel += "WHERE a.id_adj_out_fg = '" + id_adj_out_fg + "' "
                            Dim data As DataTable = execute_query(query_cancel, -1, True, "", "", "", "")
                            For i As Integer = 0 To (data.Rows.Count - 1)
                                Dim id_wh_drawer As String = data.Rows(i)("id_wh_drawer").ToString
                                Dim id_product As String = data.Rows(i)("id_product").ToString
                                Dim adj_out_fg_det_qty As Decimal = data.Rows(i)("adj_out_fg_det_qty")
                                Dim bom_unit_price As Decimal = data.Rows(i)("adj_out_fg_det_price")
                                Dim adj_out_fg_number As String = data.Rows(i)("adj_out_fg_number").ToString

                                Dim query_upd_storage As String = "INSERT tb_storage_fg(id_wh_drawer, id_storage_category, id_product, storage_product_qty, storage_product_datetime, storage_product_notes, bom_unit_price, id_stock_status, report_mark_type, id_report) "
                                query_upd_storage += "VALUES('" + id_wh_drawer + "', '1', '" + id_product + "', '" + decimalSQL(adj_out_fg_det_qty.ToString) + "', NOW(), 'Finished Goods Adjustment Out cancelled, Adjustment Out : " + adj_out_fg_number + "','" & decimalSQL(bom_unit_price.ToString) & "','2','42','" & id_adj_out_fg & "')"
                                execute_non_query(query_upd_storage, True, "", "", "", "")
                            Next

                            'main
                            query = String.Format("DELETE FROM tb_adj_out_fg WHERE id_adj_out_fg = '{0}'", id_adj_out_fg)
                            execute_non_query(query, True, "", "", "", "")

                            'del mark
                            delete_all_mark_related("42", id_adj_out_fg)

                            'Refresh data
                            FormFGAdj.viewAdjOut()
                            Cursor = Cursors.Default
                        Catch ex As Exception
                            Cursor = Cursors.Default
                            errorDelete()
                        End Try
                        Cursor = Cursors.Default
                    End If
                End If
            End If
        ElseIf formName = "FormFGTrf" Then
            'FG TRF
            If check_edit_report_status(FormFGTrf.GVFGTrf.GetFocusedRowCellValue("id_report_status"), "57", FormFGTrf.GVFGTrf.GetFocusedRowCellValue("id_fg_trf")) Then
                confirm = XtraMessageBox.Show("Are you sure want to delete this data?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
                If confirm = Windows.Forms.DialogResult.Yes Then
                    Try
                        Dim id_fg_trf As String = FormFGTrf.GVFGTrf.GetFocusedRowCellValue("id_fg_trf").ToString
                        Dim query_drawer As String = "SELECT c.fg_trf_number, b.id_product, a.id_wh_drawer, a.fg_trf_det_drawer_qty, a.bom_unit_price FROM tb_fg_trf_det_drawer a "
                        query_drawer += "INNER JOIN tb_fg_trf_det b ON a.id_fg_trf_det = b.id_fg_trf_det "
                        query_drawer += "INNER JOIN tb_fg_trf c ON c.id_fg_trf = b.id_fg_trf "
                        query_drawer += "WHERE b.id_fg_trf = '" + id_fg_trf + "' "
                        Dim data_drawer As DataTable = execute_query(query_drawer, -1, True, "", "", "", "")

                        'prepare rollback stock
                        Dim query_drawer_stock As String = ""
                        Dim jum_ins_c As Integer = 0
                        If data_drawer.Rows.Count > 0 Then
                            query_drawer_stock = "INSERT INTO tb_storage_fg(id_wh_drawer, id_storage_category, id_product, storage_product_qty, storage_product_datetime, storage_product_notes, bom_unit_price, report_mark_type, id_report, id_stock_status) VALUES "
                        End If
                        For c As Integer = 0 To (data_drawer.Rows.Count - 1)
                            If c > 0 Then
                                query_drawer_stock += ", "
                            End If
                            query_drawer_stock += "('" + data_drawer(c)("id_wh_drawer").ToString + "', '1', '" + data_drawer(c)("id_product").ToString + "', '" + decimalSQL(data_drawer(c)("fg_trf_det_drawer_qty").ToString) + "', NOW(), 'Finished Goods Transfer No: " + data_drawer(c)("fg_trf_number").ToString + ", has been canceled', '" + decimalSQL(data_drawer(c)("bom_unit_price").ToString) + "', '57', '" + id_fg_trf + "', '2') "
                        Next

                        'excequte rollback
                        If data_drawer.Rows.Count > 0 Then
                            execute_non_query(query_drawer_stock, True, "", "", "", "")
                        End If

                        query = String.Format("DELETE FROM tb_fg_trf WHERE id_fg_trf ='{0}'", id_fg_trf)
                        execute_non_query(query, True, "", "", "", "")

                        'del mark
                        delete_all_mark_related("57", id_fg_trf)
                        FormFGTrf.viewFGTrf()
                    Catch ex As Exception
                        errorDelete()
                    End Try
                End If
            Else
                stopCustom("This data already marked")
            End If
        ElseIf formName = "FormFGTrfNew" Then
            'FG TRF
            If check_edit_report_status(FormFGTrfNew.GVFGTrf.GetFocusedRowCellValue("id_report_status"), "57", FormFGTrfNew.GVFGTrf.GetFocusedRowCellValue("id_fg_trf")) Then
                confirm = XtraMessageBox.Show("Are you sure want to delete this data?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
                If confirm = Windows.Forms.DialogResult.Yes Then
                    Try
                        Dim id_fg_trf As String = FormFGTrfNew.GVFGTrf.GetFocusedRowCellValue("id_fg_trf").ToString

                        query = String.Format("DELETE FROM tb_fg_trf WHERE id_fg_trf ='{0}'", id_fg_trf)
                        execute_non_query(query, True, "", "", "", "")

                        'del mark
                        delete_all_mark_related("57", id_fg_trf)
                        FormFGTrfNew.viewFGTrf()
                    Catch ex As Exception
                        errorDelete()
                    End Try
                End If
            Else
                stopCustom("This data already marked")
            End If
        ElseIf formName = "FormMasterEmployee" Then
            'employee
            confirm = XtraMessageBox.Show("Are you sure want to delete this employee?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)

            Dim id_employee As String = FormMasterEmployee.GVEmployee.GetFocusedRowCellValue("id_employee").ToString
            Dim employee_code As String = FormMasterEmployee.GVEmployee.GetFocusedRowCellValue("employee_code").ToString
            If confirm = Windows.Forms.DialogResult.Yes Then
                Cursor = Cursors.WaitCursor
                Try
                    query = String.Format("DELETE FROM tb_m_employee WHERE id_employee = '{0}'", id_employee)
                    execute_non_query(query, True, "", "", "", "")

                    'delete fp
                    Try
                        Dim fp As New ClassFingerPrint()
                        Dim data_fp As DataTable = fp.get_fp_register()
                        fp.ip = data_fp.Rows(0)("ip").ToString
                        fp.port = data_fp.Rows(0)("port").ToString
                        fp.connect()
                        fp.disable_fp()
                        fp.deleteUserInfo(employee_code)
                        fp.refresh_fp()
                        fp.enable_fp()
                        fp.disconnect()
                    Catch ex As Exception
                        stopCustom(ex.ToString)
                    End Try

                    FormMasterEmployee.viewEmployee("-1")
                Catch ex As Exception
                    XtraMessageBox.Show("This employee already used.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End Try
                Cursor = Cursors.Default
            End If
        ElseIf formName = "FormSampleDel" Then
            'PL SQAMPE DELIVERY (HANDOVER TO WH)
            If check_edit_report_status(FormSampleDel.GVSampleDel.GetFocusedRowCellValue("id_report_status"), "60", FormSampleDel.GVSampleDel.GetFocusedRowCellValue("id_sample_del")) Then
                confirm = XtraMessageBox.Show("Are you sure want to delete this data?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
                If confirm = Windows.Forms.DialogResult.Yes Then
                    Try
                        Dim id_sample_del As String = FormSampleDel.GVSampleDel.GetFocusedRowCellValue("id_sample_del").ToString
                        Dim query_drawer As String = "SELECT c.sample_del_number, b.id_sample, a.id_wh_drawer, a.sample_del_det_drawer_qty, a.id_sample_price, a.sample_price FROM tb_sample_del_det_drawer a "
                        query_drawer += "INNER JOIN tb_sample_del_det b ON a.id_sample_del_det = b.id_sample_del_det "
                        query_drawer += "INNER JOIN tb_sample_del c ON c.id_sample_del = b.id_sample_del "
                        query_drawer += "WHERE b.id_sample_del = '" + id_sample_del + "' "
                        Dim data_drawer As DataTable = execute_query(query_drawer, -1, True, "", "", "", "")

                        'prepare rollback stock
                        Dim query_drawer_stock As String = ""
                        Dim jum_ins_c As Integer = 0
                        If data_drawer.Rows.Count > 0 Then
                            query_drawer_stock = "INSERT tb_storage_sample(id_wh_drawer, id_storage_category, id_sample, qty_sample, datetime_storage_sample, storage_sample_notes, id_sample_price, sample_price, report_mark_type, id_report, id_stock_status) VALUES "
                        End If
                        For c As Integer = 0 To (data_drawer.Rows.Count - 1)
                            If c > 0 Then
                                query_drawer_stock += ", "
                            End If
                            query_drawer_stock += "('" + data_drawer(c)("id_wh_drawer").ToString + "', '1', '" + data_drawer(c)("id_sample").ToString + "', '" + decimalSQL(data_drawer(c)("sample_del_det_drawer_qty").ToString) + "', NOW(), 'PL Sample Delivery No: " + data_drawer(c)("sample_del_number").ToString + ", has been canceled', '" + data_drawer(c)("id_sample_price").ToString + "','" + decimalSQL(data_drawer(c)("sample_price").ToString) + "', '60', '" + id_sample_del + "', '2') "
                        Next

                        'excequte rollback
                        If data_drawer.Rows.Count > 0 Then
                            execute_non_query(query_drawer_stock, True, "", "", "", "")
                        End If

                        query = String.Format("DELETE FROM tb_sample_del WHERE id_sample_del ='{0}'", id_sample_del)
                        execute_non_query(query, True, "", "", "", "")

                        'del mark
                        delete_all_mark_related("60", id_sample_del)
                        FormSampleDel.viewSampleDel()
                    Catch ex As Exception
                        errorDelete()
                    End Try
                End If
            Else
                stopCustom("This data already marked")
            End If
        ElseIf formName = "FormSampleDelRec" Then
            'REC PL SQAMPE DELIVERY (HANDOVER TO WH)
            If check_edit_report_status(FormSampleDelRec.GVSampleDelRec.GetFocusedRowCellValue("id_report_status"), "61", FormSampleDelRec.GVSampleDelRec.GetFocusedRowCellValue("id_sample_del_rec")) Then
                confirm = XtraMessageBox.Show("Are you sure want to delete this data?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
                If confirm = Windows.Forms.DialogResult.Yes Then
                    Try
                        Dim id_sample_del_rec As String = FormSampleDelRec.GVSampleDelRec.GetFocusedRowCellValue("id_sample_del_rec").ToString

                        query = String.Format("DELETE FROM tb_sample_del_rec WHERE id_sample_del_rec ='{0}'", id_sample_del_rec)
                        execute_non_query(query, True, "", "", "", "")

                        'del mark
                        delete_all_mark_related("61", id_sample_del_rec)
                        FormSampleDelRec.viewSampleDelRec()
                        FormSampleDelRec.viewSampleDel()
                    Catch ex As Exception
                        errorDelete()
                    End Try
                End If
            Else
                stopCustom("This data already marked")
            End If
        ElseIf formName = "FormSampleOrder" Then
            'Sales SAMPLE ORDER
            If check_edit_report_status(FormSampleOrder.GVSampleOrder.GetFocusedRowCellValue("id_report_status"), "62", FormSampleOrder.GVSampleOrder.GetFocusedRowCellValue("id_sample_order")) Then
                confirm = XtraMessageBox.Show("Are you sure want to delete this data?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
                If confirm = Windows.Forms.DialogResult.Yes Then
                    Try
                        Dim id_sample_order As String = FormSampleOrder.GVSampleOrder.GetFocusedRowCellValue("id_sample_order").ToString

                        query = String.Format("DELETE FROM tb_sample_order WHERE id_sample_order ='{0}'", id_sample_order)
                        execute_non_query(query, True, "", "", "", "")

                        'del mark
                        delete_all_mark_related("62", id_sample_order)
                        FormSampleOrder.viewSampleOrder()
                    Catch ex As Exception
                        errorDelete()
                    End Try
                End If
            Else
                stopCustom("This data already marked")
            End If
        ElseIf formName = "FormSampleDelOrder" Then
            'DELIVERY ORDER SAMPLE FOR SALES
            If FormSampleDelOrder.XTCSampleDelOrder.SelectedTabPageIndex = 0 Then
                If check_edit_report_status(FormSampleDelOrder.GVSampleDelOrder.GetFocusedRowCellValue("id_report_status"), "63", FormSampleDelOrder.GVSampleDelOrder.GetFocusedRowCellValue("id_pl_sample_order_del")) Then
                    confirm = XtraMessageBox.Show("Are you sure want to delete this data?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
                    If confirm = Windows.Forms.DialogResult.Yes Then
                        Try
                            Dim id_pl_sample_order_del As String = FormSampleDelOrder.GVSampleDelOrder.GetFocusedRowCellValue("id_pl_sample_order_del").ToString

                            'prepare rollback stock
                            Dim query_c As ClassSampleDelOrder = New ClassSampleDelOrder
                            Dim query_drawer As String = query_c.queryDetailDrawer("AND a1.id_pl_sample_order_del = ''" + id_pl_sample_order_del + "''", "1")
                            Dim data_drawer As DataTable = execute_query(query_drawer, -1, True, "", "", "", "")
                            Dim query_drawer_stock As String = ""
                            Dim jum_ins_c As Integer = 0
                            If data_drawer.Rows.Count > 0 Then
                                query_drawer_stock = "INSERT tb_storage_sample(id_wh_drawer, id_storage_category, id_sample, qty_sample, datetime_storage_sample, storage_sample_notes, id_sample_price, sample_price, report_mark_type, id_report, id_stock_status) VALUES "
                            End If
                            For c As Integer = 0 To (data_drawer.Rows.Count - 1)
                                If c > 0 Then
                                    query_drawer_stock += ", "
                                End If
                                query_drawer_stock += "('" + data_drawer(c)("id_wh_drawer").ToString + "', '1', '" + data_drawer(c)("id_sample").ToString + "', '" + decimalSQL(data_drawer(c)("qty_all_sample").ToString) + "', NOW(), 'Delivery Order Sample No: " + data_drawer(c)("pl_sample_order_del_number").ToString + ", has been canceled', '" + data_drawer(c)("id_sample_price").ToString + "','" + decimalSQL(data_drawer(c)("sample_price").ToString) + "', '63', '" + id_pl_sample_order_del + "', '2') "
                            Next
                            'excequte rollback
                            If data_drawer.Rows.Count > 0 Then
                                execute_non_query(query_drawer_stock, True, "", "", "", "")
                            End If

                            'delete DO
                            query = String.Format("DELETE FROM tb_pl_sample_order_del WHERE id_pl_sample_order_del ='{0}'", id_pl_sample_order_del)
                            execute_non_query(query, True, "", "", "", "")

                            'del mark
                            delete_all_mark_related("63", id_pl_sample_order_del)
                            FormSampleDelOrder.viewSampleDelOrder()
                            FormSampleDelOrder.viewSampleOrder()
                        Catch ex As Exception
                            errorDelete()
                        End Try
                    End If
                Else
                    stopCustom("This data already marked")
                End If
            End If

        ElseIf formName = "FormSampleStockOpname" Then
            'Sales SAMPLE ORDER
            If FormSampleStockOpname.GVSOWH.GetFocusedRowCellValue("id_lock").ToString = "2" Then
                stopCustom("This opname already locked")
            Else
                If check_edit_report_status(FormSampleStockOpname.GVSOWH.GetFocusedRowCellValue("id_report_status"), "64", FormSampleStockOpname.GVSOWH.GetFocusedRowCellValue("id_sample_so")) Then
                    confirm = XtraMessageBox.Show("Are you sure want to delete this opname?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
                    If confirm = Windows.Forms.DialogResult.Yes Then
                        Try
                            Dim id_sample_so As String = FormSampleStockOpname.GVSOWH.GetFocusedRowCellValue("id_sample_so").ToString

                            query = String.Format("DELETE FROM tb_sample_so WHERE id_sample_so ='{0}'", id_sample_so)
                            execute_non_query(query, True, "", "", "", "")

                            'del mark
                            delete_all_mark_related("64", id_sample_so)
                            FormSampleStockOpname.viewSOWH()
                        Catch ex As Exception
                            errorDelete()
                        End Try
                    End If
                Else
                    stopCustom("This opname already marked")
                End If
            End If
        ElseIf formName = "FormFGCodeReplace" Then
            If FormFGCodeReplace.XTCFGCodeReplace.SelectedTabPageIndex = 0 Then
                'CODE REPLACEMENT
                If check_edit_report_status(FormFGCodeReplace.GVFGCodeReplaceStore.GetFocusedRowCellValue("id_report_status"), "65", FormFGCodeReplace.GVFGCodeReplaceStore.GetFocusedRowCellValue("id_fg_code_replace_store")) Then
                    confirm = XtraMessageBox.Show("Are you sure want to delete this data?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
                    If confirm = Windows.Forms.DialogResult.Yes Then
                        Try
                            Dim id_fg_code_replace_store As String = FormFGCodeReplace.GVFGCodeReplaceStore.GetFocusedRowCellValue("id_fg_code_replace_store").ToString

                            query = String.Format("DELETE FROM tb_fg_code_replace_store WHERE id_fg_code_replace_store ='{0}'", id_fg_code_replace_store)
                            execute_non_query(query, True, "", "", "", "")

                            'del mark
                            delete_all_mark_related("65", id_fg_code_replace_store)
                            FormFGCodeReplace.viewCodeReplaceStore()
                        Catch ex As Exception
                            errorDelete()
                        End Try
                    End If
                Else
                    stopCustom("This data already marked")
                End If
            ElseIf FormFGCodeReplace.XTCFGCodeReplace.SelectedTabPageIndex = 1 Then
                If check_edit_report_status(FormFGCodeReplace.GVFGCodeReplaceWH.GetFocusedRowCellValue("id_report_status"), "68", FormFGCodeReplace.GVFGCodeReplaceWH.GetFocusedRowCellValue("id_fg_code_replace_wh")) Then
                    confirm = XtraMessageBox.Show("Are you sure want to delete this data?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
                    If confirm = Windows.Forms.DialogResult.Yes Then
                        Try
                            Dim id_fg_code_replace_wh As String = FormFGCodeReplace.GVFGCodeReplaceWH.GetFocusedRowCellValue("id_fg_code_replace_wh").ToString

                            query = String.Format("DELETE FROM tb_fg_code_replace_wh WHERE id_fg_code_replace_wh ='{0}'", id_fg_code_replace_wh)
                            execute_non_query(query, True, "", "", "", "")

                            'del mark
                            delete_all_mark_related("68", id_fg_code_replace_wh)
                            FormFGCodeReplace.viewCodeReplaceWH()
                        Catch ex As Exception
                            errorDelete()
                        End Try
                    End If
                Else
                    stopCustom("This data already marked")
                End If
            End If
        ElseIf formName = "FormSalesCreditNote" Then
            If check_edit_report_status(FormSalesCreditNote.GVSalesPOS.GetFocusedRowCellValue("id_report_status"), "66", FormSalesCreditNote.GVSalesPOS.GetFocusedRowCellValue("id_sales_pos")) Then
                confirm = XtraMessageBox.Show("Are you sure want to delete this data?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
                If confirm = Windows.Forms.DialogResult.Yes Then
                    Try
                        Dim id_sales_pos As String = FormSalesCreditNote.GVSalesPOS.GetFocusedRowCellValue("id_sales_pos").ToString

                        query = String.Format("DELETE FROM tb_sales_pos WHERE id_sales_pos ='{0}'", id_sales_pos)
                        execute_non_query(query, True, "", "", "", "")

                        'del mark
                        delete_all_mark_related("66", id_sales_pos)
                        FormSalesCreditNote.viewSalesPOS()
                    Catch ex As Exception
                        errorDelete()
                    End Try
                End If
            Else
                stopCustom("This data already marked")
            End If
        ElseIf formName = "FormFGMissingCreditNote" Then
            'MISSING CREDIT NOTE
            If FormFGMissingCreditNote.XTCFGMissingCN.SelectedTabPageIndex = 0 Then
                If check_edit_report_status(FormFGMissingCreditNote.GVFGMissingCNStore.GetFocusedRowCellValue("id_report_status"), "67", FormFGMissingCreditNote.GVFGMissingCNStore.GetFocusedRowCellValue("id_sales_pos")) Then
                    confirm = XtraMessageBox.Show("Are you sure want to delete this data?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
                    If confirm = Windows.Forms.DialogResult.Yes Then
                        Try
                            Dim id_sales_pos As String = FormFGMissingCreditNote.GVFGMissingCNStore.GetFocusedRowCellValue("id_sales_pos").ToString

                            query = String.Format("DELETE FROM tb_sales_pos WHERE id_sales_pos ='{0}'", id_sales_pos)
                            execute_non_query(query, True, "", "", "", "")

                            'del mark
                            delete_all_mark_related("67", id_sales_pos)
                            FormFGMissingCreditNote.viewFGMissingStoreCN()
                        Catch ex As Exception
                            errorDelete()
                        End Try
                    End If
                Else
                    stopCustom("This data already marked")
                End If
            ElseIf FormFGMissingCreditNote.XTCFGMissingCN.SelectedTabPageIndex = 1 Then

            End If
        ElseIf formName = "FormSOHPeriode" Then
            confirm = XtraMessageBox.Show("Are you sure want to delete this periode?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
            If confirm = Windows.Forms.DialogResult.Yes Then
                Try
                    Dim id_soh_periode As String = FormSOHPeriode.GVSOHPeriode.GetFocusedRowCellValue("id_soh_periode").ToString

                    query = String.Format("DELETE FROM tb_soh_periode WHERE id_soh_periode ='{0}'", id_soh_periode)
                    execute_non_query(query, True, "", "", "", "")

                    'del mark
                    FormSOHPeriode.view_soh()
                Catch ex As Exception
                    errorDelete()
                End Try
            End If
        ElseIf formName = "FormSOH" Then
            confirm = XtraMessageBox.Show("Are you sure want to delete this SOH ?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
            If confirm = Windows.Forms.DialogResult.Yes Then
                Try
                    Dim id_soh As String = FormSOH.BGVSOH.GetFocusedRowCellValue("id_soh").ToString

                    query = String.Format("DELETE FROM tb_soh WHERE id_soh ='{0}'", id_soh)
                    execute_non_query(query, True, "", "", "", "")

                    'del mark
                    FormSOH.view_soh_periode(FormSOH.LESOHPeriode.EditValue)
                Catch ex As Exception
                    errorDelete()
                End Try
            End If
        ElseIf formName = "FormFGWoff" Then
            If check_edit_report_status(FormFGWoff.GVFGWoff.GetFocusedRowCellValue("id_report_status"), "69", FormFGWoff.GVFGWoff.GetFocusedRowCellValue("id_fg_woff")) Then
                confirm = XtraMessageBox.Show("Are you sure want to delete?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
                If confirm = Windows.Forms.DialogResult.Yes Then
                    Try
                        Dim id_fg_woff As String = FormFGWoff.GVFGWoff.GetFocusedRowCellValue("id_fg_woff").ToString

                        'rollback reserved stock
                        Dim query_c As ClassFGWoff = New ClassFGWoff()
                        Dim query_roll As String = query_c.queryRollbackStock(id_fg_woff)
                        execute_non_query(query_roll, True, "", "", "", "")

                        'delete write off
                        query = String.Format("DELETE FROM tb_fg_woff WHERE id_fg_woff ='{0}'", id_fg_woff)
                        execute_non_query(query, True, "", "", "", "")

                        'del mark
                        FormFGWoff.viewFGWoff()
                    Catch ex As Exception
                        errorDelete()
                    End Try
                End If
            Else
                stopCustom("This data already marked")
            End If
        ElseIf formName = "FormFGProposePrice" Then
            If check_edit_report_status(FormFGProposePrice.GVFGPropose.GetFocusedRowCellValue("id_report_status").ToString, "70", FormFGProposePrice.GVFGPropose.GetFocusedRowCellValue("id_fg_propose_price")) Then
                confirm = XtraMessageBox.Show("Are you sure want to delete?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
                If confirm = Windows.Forms.DialogResult.Yes Then
                    Try
                        Dim id_fg_propose_price As String = FormFGProposePrice.GVFGPropose.GetFocusedRowCellValue("id_fg_propose_price").ToString

                        'delete write off
                        query = String.Format("DELETE FROM tb_fg_propose_price WHERE id_fg_propose_price ='{0}'", id_fg_propose_price)
                        execute_non_query(query, True, "", "", "", "")

                        'del mark
                        FormFGProposePrice.viewPropose()
                    Catch ex As Exception
                        errorDelete()
                    End Try
                End If
            Else
                stopCustom("This data already marked")
            End If
        ElseIf formName = "FormMasterRetCode" Then
            confirm = XtraMessageBox.Show("Are you sure want to delete?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
            If confirm = Windows.Forms.DialogResult.Yes Then
                Try
                    Dim id_ret_code As String = FormMasterRetCode.GVRetCode.GetFocusedRowCellValue("id_ret_code").ToString

                    'delete write off
                    query = String.Format("DELETE FROM tb_lookup_ret_code WHERE id_ret_code ='{0}'", id_ret_code)
                    execute_non_query(query, True, "", "", "", "")

                    'del mark
                    FormMasterRetCode.viewRetCode()
                Catch ex As Exception
                    errorDelete()
                End Try
            End If
        ElseIf formName = "FormMasterRateStore" Then
            confirm = XtraMessageBox.Show("Are you sure want to delete?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
            If confirm = Windows.Forms.DialogResult.Yes Then
                Try
                    Dim id_store_rate As String = FormMasterRateStore.GVStoreRate.GetFocusedRowCellValue("id_store_rate").ToString

                    'delete write off
                    query = String.Format("DELETE FROM tb_lookup_store_rate WHERE id_store_rate ='{0}'", id_store_rate)
                    execute_non_query(query, True, "", "", "", "")

                    'del mark
                    FormMasterRateStore.viewRate()
                Catch ex As Exception
                    errorDelete()
                End Try
            End If
        ElseIf formName = "FormSampleOrdered" Then
            If check_edit_report_status(FormSampleOrdered.GVSampleOrder.GetFocusedRowCellValue("id_report_status").ToString, "71", FormSampleOrdered.GVSampleOrder.GetFocusedRowCellValue("id_sample_ordered")) Then
                confirm = XtraMessageBox.Show("Are you sure want to delete?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
                If confirm = Windows.Forms.DialogResult.Yes Then
                    Try
                        Dim id_sample_ordered As String = FormSampleOrdered.GVSampleOrder.GetFocusedRowCellValue("id_sample_ordered").ToString

                        'delete sample ordered
                        query = String.Format("DELETE FROM tb_sample_ordered WHERE id_sample_ordered ='{0}'", id_sample_ordered)
                        execute_non_query(query, True, "", "", "", "")

                        'del mark
                        FormSampleOrdered.viewSampleOrder()
                    Catch ex As Exception
                        errorDelete()
                    End Try
                End If
            Else
                stopCustom("This data already marked")
            End If
        ElseIf formName = "FormProdQCAdj" Then
            If FormProdQCAdj.XTCAdj.SelectedTabPageIndex = 0 Then 'QC adj IN
                If check_edit_report_status(FormProdQCAdj.GVAdjIn.GetFocusedRowCellValue("id_report_status"), "72", FormProdQCAdj.GVAdjIn.GetFocusedRowCellValue("id_prod_order_qc_adj_in")) Then
                    confirm = XtraMessageBox.Show("Are you sure want to delete?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
                    If confirm = Windows.Forms.DialogResult.Yes Then
                        Try
                            Dim id_qc_adj_in As String = FormProdQCAdj.GVAdjIn.GetFocusedRowCellValue("id_prod_order_qc_adj_in").ToString

                            'delete write off
                            query = String.Format("DELETE FROM tb_prod_order_qc_adj_in WHERE id_prod_order_qc_adj_in ='{0}'", id_qc_adj_in)
                            execute_non_query(query, True, "", "", "", "")
                            '
                            delete_all_mark_related("72", id_qc_adj_in)
                            'del mark
                            FormProdQCAdj.viewAdjIn()
                        Catch ex As Exception
                            errorDelete()
                        End Try
                    End If
                Else
                    stopCustom("This data already marked")
                End If
            Else  'QC adj OUT
                If check_edit_report_status(FormProdQCAdj.GVAdjOut.GetFocusedRowCellValue("id_report_status"), "73", FormProdQCAdj.GVAdjOut.GetFocusedRowCellValue("id_prod_order_qc_adj_out")) Then
                    confirm = XtraMessageBox.Show("Are you sure want to delete?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
                    If confirm = Windows.Forms.DialogResult.Yes Then
                        Try
                            Dim id_qc_adj_out As String = FormProdQCAdj.GVAdjOut.GetFocusedRowCellValue("id_prod_order_qc_adj_out").ToString

                            'delete write off
                            query = String.Format("DELETE FROM tb_prod_order_qc_adj_out WHERE id_prod_order_qc_adj_out ='{0}'", id_qc_adj_out)
                            execute_non_query(query, True, "", "", "", "")
                            '
                            delete_all_mark_related("73", id_qc_adj_out)
                            'del mark
                            FormProdQCAdj.viewAdjOut()
                        Catch ex As Exception
                            errorDelete()
                        End Try
                    End If
                Else
                    stopCustom("This data already marked")
                End If
            End If
        ElseIf formName = "FormSalesPromo" Then
            If check_edit_report_status(FormSalesPromo.GVSalesPOS.GetFocusedRowCellValue("id_report_status").ToString, "76", FormSalesPromo.GVSalesPOS.GetFocusedRowCellValue("id_sales_pos")) Then
                confirm = XtraMessageBox.Show("Are you sure want to delete?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
                If confirm = Windows.Forms.DialogResult.Yes Then
                    Try
                        Dim id_sales_pos As String = FormSalesPromo.GVSalesPOS.GetFocusedRowCellValue("id_sales_pos").ToString

                        'rollback stock
                        Dim rsv_stock As ClassSalesInv = New ClassSalesInv()
                        rsv_stock.cancelReservedStock(id_sales_pos, "76")

                        'delete sample ordered
                        query = String.Format("DELETE FROM tb_sales_pos WHERE id_sales_pos ='{0}'", id_sales_pos)
                        execute_non_query(query, True, "", "", "", "")

                        'del mark
                        delete_all_mark_related("76", id_sales_pos)
                        FormSalesPromo.viewSalesPOS()
                    Catch ex As Exception
                        errorDelete()
                    End Try
                End If
            Else
                stopCustom("This data already marked")
            End If
        ElseIf formName = "FormFGSalesOrderReff" Then
            If check_edit_report_status(FormFGSalesOrderReff.GVSOReff.GetFocusedRowCellValue("id_report_status"), "75", FormFGSalesOrderReff.GVSOReff.GetFocusedRowCellValue("id_fg_so_reff")) Then
                confirm = XtraMessageBox.Show("Are you sure want to delete?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
                If confirm = Windows.Forms.DialogResult.Yes Then
                    Try
                        Dim id_fg_so_reff As String = FormFGSalesOrderReff.GVSOReff.GetFocusedRowCellValue("id_fg_so_reff").ToString

                        'delete 
                        query = String.Format("DELETE FROM tb_fg_so_reff WHERE id_fg_so_reff ='{0}'", id_fg_so_reff)
                        execute_non_query(query, True, "", "", "", "")

                        'del mark
                        delete_all_mark_related("75", id_fg_so_reff)

                        'del mark
                        FormFGSalesOrderReff.viewSOReff()
                    Catch ex As Exception
                        errorDelete()
                    End Try
                End If
            Else
                stopCustom("This data already marked")
            End If
        ElseIf formName = "FormMasterComputer"
            confirm = XtraMessageBox.Show("Are you sure want to delete?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
            If confirm = Windows.Forms.DialogResult.Yes Then
                Try
                    Dim id_computer As String = FormMasterComputer.GVComputer.GetFocusedRowCellValue("id_computer").ToString

                    'delete
                    query = String.Format("DELETE FROM tb_m_computer WHERE id_computer ='{0}'", id_computer)
                    execute_non_query(query, True, "", "", "", "")

                    'del mark
                    FormMasterComputer.viewComputer()
                Catch ex As Exception
                    errorDelete()
                End Try
            End If
        ElseIf formName = "FormAccountingFakturScan" Then
            confirm = XtraMessageBox.Show("Are you sure want to delete this data ?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
            Dim id_acc_fak_scan As String = FormAccountingFakturScan.GVFak.GetFocusedRowCellValue("id_acc_fak_scan").ToString

            If confirm = Windows.Forms.DialogResult.Yes Then
                Cursor = Cursors.WaitCursor
                Try
                    query = String.Format("DELETE FROM tb_a_acc_fak_scan WHERE id_acc_fak_scan = '{0}'", id_acc_fak_scan)
                    execute_non_query(query, True, "", "", "", "")
                    FormAccountingFakturScan.viewTrans()
                Catch ex As Exception
                    errorDelete()
                End Try
                Cursor = Cursors.Default
            End If
        ElseIf formName = "FormFGBorrowQCReq" Then
            'BORROW REQ FOR QC FRODICT
            confirm = XtraMessageBox.Show("Are you sure want to delete this data ?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
            Dim id_borrow_qc_req As String = FormFGBorrowQCReq.GVBorrowReq.GetFocusedRowCellValue("id_borrow_qc_req").ToString

            If confirm = Windows.Forms.DialogResult.Yes Then
                Cursor = Cursors.WaitCursor
                Try
                    query = String.Format("DELETE FROM tb_fg_borrow_qc_req WHERE id_borrow_qc_req = '{0}'", id_borrow_qc_req)
                    execute_non_query(query, True, "", "", "", "")
                    FormFGBorrowQCReq.viewBorrowReq()
                Catch ex As Exception
                    errorDelete()
                End Try
                Cursor = Cursors.Default
            End If
        ElseIf formName = "FormWHAWBill" Then
            If FormWHAWBill.XTCAwb.SelectedTabPageIndex = 0 Then
                confirm = XtraMessageBox.Show("Are you sure want to delete this data ?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
                Dim id_awbill As String = FormWHAWBill.GVAWBill.GetFocusedRowCellValue("id_awbill").ToString

                If confirm = Windows.Forms.DialogResult.Yes Then
                    Cursor = Cursors.WaitCursor
                    Try
                        query = String.Format("DELETE FROM tb_wh_awbill WHERE id_awbill = '{0}'", id_awbill)
                        execute_non_query(query, True, "", "", "", "")
                        FormWHAWBill.load_outbound()
                    Catch ex As Exception
                        errorDelete()
                    End Try
                    Cursor = Cursors.Default
                End If
            Else
                confirm = XtraMessageBox.Show("Are you sure want to delete this data ?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
                Dim id_awbill As String = FormWHAWBill.GVAwbillIn.GetFocusedRowCellValue("id_awbill").ToString

                If confirm = Windows.Forms.DialogResult.Yes Then
                    Cursor = Cursors.WaitCursor
                    Try
                        query = String.Format("DELETE FROM tb_wh_awbill WHERE id_awbill = '{0}'", id_awbill)
                        execute_non_query(query, True, "", "", "", "")
                        FormWHAWBill.load_inbound()
                    Catch ex As Exception
                        errorDelete()
                    End Try
                    Cursor = Cursors.Default
                End If
            End If
        ElseIf formName = "FormMasterPrice" Then
            If check_edit_report_status(FormMasterPrice.GVPrice.GetFocusedRowCellValue("id_report_status").ToString, "82", FormMasterPrice.GVPrice.GetFocusedRowCellValue("id_fg_price")) Then
                confirm = XtraMessageBox.Show("Are you sure want to delete?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
                If confirm = Windows.Forms.DialogResult.Yes Then
                    Try
                        Dim id_fg_price As String = FormMasterPrice.GVPrice.GetFocusedRowCellValue("id_fg_price").ToString

                        'delete write off
                        query = String.Format("DELETE FROM tb_fg_price WHERE id_fg_price ='{0}'", id_fg_price)
                        execute_non_query(query, True, "", "", "", "")

                        'del mark
                        delete_all_mark_related("82", id_fg_price)
                        FormMasterPrice.viewPrice()
                    Catch ex As Exception
                        errorDelete()
                    End Try
                End If
            Else
                stopCustom("This data already marked")
            End If
        ElseIf formName = "FormSamplePLToWH" Then
            'PACING LIST SAMPLE
            If check_edit_report_status(FormSamplePLToWH.GVSamplePL.GetFocusedRowCellValue("id_sample_pl").ToString, "85", FormSamplePLToWH.GVSamplePL.GetFocusedRowCellValue("id_sample_pl")) Then
                confirm = XtraMessageBox.Show("Are you sure want to delete?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
                If confirm = Windows.Forms.DialogResult.Yes Then
                    Try
                        Dim id_sample_pl As String = FormSamplePLToWH.GVSamplePL.GetFocusedRowCellValue("id_sample_pl").ToString

                        'rollback stock
                        Dim rsv_stock As ClassSamplePLtoWH = New ClassSamplePLtoWH()
                        rsv_stock.cancelReservedStock(id_sample_pl, "85")

                        'delete 
                        query = String.Format("DELETE FROM tb_sample_pl WHERE id_sample_pl ='{0}'", id_sample_pl)
                        execute_non_query(query, True, "", "", "", "")

                        'del mark
                        delete_all_mark_related("85", id_sample_pl)
                        FormSamplePLToWH.viewSamplePL()
                    Catch ex As Exception
                        errorDelete()
                    End Try
                End If
            Else
                stopCustom("This data already marked")
            End If
        ElseIf formName = "FormMasterPriceSample" Then
            If check_edit_report_status(FormMasterPriceSample.GVPrice.GetFocusedRowCellValue("id_report_status").ToString, "86", FormMasterPriceSample.GVPrice.GetFocusedRowCellValue("id_sample_price")) Then
                confirm = XtraMessageBox.Show("Are you sure want to delete?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
                If confirm = Windows.Forms.DialogResult.Yes Then
                    Try
                        Dim id_sample_price As String = FormMasterPriceSample.GVPrice.GetFocusedRowCellValue("id_sample_price").ToString

                        'delete write off
                        query = String.Format("DELETE FROM tb_sample_price WHERE id_sample_price ='{0}'", id_sample_price)
                        execute_non_query(query, True, "", "", "", "")

                        'del mark
                        delete_all_mark_related("86", id_sample_price)
                        FormMasterPriceSample.viewPrice()
                    Catch ex As Exception
                        errorDelete()
                    End Try
                End If
            Else
                stopCustom("This data already marked")
            End If
        ElseIf formName = "FormFGWHAlloc" Then
            'INVENTORY ALLOCATION
            If check_edit_report_status(FormFGWHAlloc.GVFGWHAlloc.GetFocusedRowCellValue("id_report_status").ToString, "87", FormFGWHAlloc.GVFGWHAlloc.GetFocusedRowCellValue("id_fg_wh_alloc")) Then
                confirm = XtraMessageBox.Show("Are you sure you want to delete?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
                If confirm = Windows.Forms.DialogResult.Yes Then
                    Try
                        Dim id_fg_wh_alloc As String = FormFGWHAlloc.GVFGWHAlloc.GetFocusedRowCellValue("id_fg_wh_alloc").ToString
                        Dim is_submit As String = FormFGWHAlloc.GVFGWHAlloc.GetFocusedRowCellValue("is_submit").ToString

                        'cancel reserved
                        If is_submit = "1" Then
                            'cancelled
                            Dim cancel_rsv_stock As ClassFGWHAlloc = New ClassFGWHAlloc()
                            cancel_rsv_stock.cancelReservedStock(id_fg_wh_alloc)
                        End If

                        'delete 
                        query = String.Format("DELETE FROM tb_fg_wh_alloc WHERE id_fg_wh_alloc ='{0}'", id_fg_wh_alloc)
                        execute_non_query(query, True, "", "", "", "")

                        'del mark
                        delete_all_mark_related("87", id_fg_wh_alloc)
                        FormFGWHAlloc.viewFGWHAlloc()
                    Catch ex As Exception
                        errorDelete()
                    End Try
                End If
            Else
                stopCustom("This data already marked")
            End If
        ElseIf formName = "FormSampleReturnPL" Then
            'PACING LIST SAMPLE
            If check_edit_report_status(FormSampleReturnPL.GVSamplePL.GetFocusedRowCellValue("id_report_status").ToString, "89", FormSampleReturnPL.GVSamplePL.GetFocusedRowCellValue("id_sample_pl_ret")) Then
                confirm = XtraMessageBox.Show("Are you sure want to delete?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
                If confirm = Windows.Forms.DialogResult.Yes Then
                    Try
                        Dim id_sample_pl_ret As String = FormSampleReturnPL.GVSamplePL.GetFocusedRowCellValue("id_sample_pl_ret").ToString
                        'delete 
                        query = String.Format("DELETE FROM tb_sample_pl_ret WHERE id_sample_pl_ret ='{0}'", id_sample_pl_ret)
                        execute_non_query(query, True, "", "", "", "")

                        'del mark
                        delete_all_mark_related("89", id_sample_pl_ret)
                        FormSampleReturnPL.viewSamplePL()
                    Catch ex As Exception
                        errorDelete()
                    End Try
                End If
            Else
                stopCustom("This data already marked")
            End If
        ElseIf formName = "FormFGDesignList" Then
            confirm = XtraMessageBox.Show("Are you sure want to delete?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
            If confirm = Windows.Forms.DialogResult.Yes Then
                Try
                    Dim id_design As String = FormFGDesignList.GVDesign.GetFocusedRowCellValue("id_design").ToString
                    query = String.Format("DELETE FROM tb_m_design WHERE id_design='{0}'", id_design)
                    execute_non_query(query, True, "", "", "", "")
                    FormFGDesignList.viewData()
                Catch ex As Exception
                    errorDelete()
                End Try
            End If
        ElseIf formName = "FormEmpShift" Then
            confirm = XtraMessageBox.Show("Are you sure want to delete?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
            If confirm = DialogResult.Yes Then
                Try
                    Dim id_shift As String = FormEmpShift.GVShift.GetFocusedRowCellValue("id_shift").ToString
                    query = String.Format("DELETE FROM tb_emp_shift WHERE id_shift='{0}'", id_shift)
                    execute_non_query(query, True, "", "", "", "")
                    FormEmpShift.load_schedule()
                Catch ex As Exception
                    errorDelete()
                End Try
            End If
        ElseIf formName = "FormEmpHoliday" Then
            confirm = XtraMessageBox.Show("Are you sure want to delete?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
            If confirm = DialogResult.Yes Then
                Try
                    Dim id_holiday As String = FormEmpHoliday.GVHoliday.GetFocusedRowCellValue("id_emp_holiday").ToString
                    query = String.Format("DELETE FROM tb_emp_holiday WHERE id_emp_holiday='{0}'", id_holiday)
                    execute_non_query(query, True, "", "", "", "")
                    FormEmpHoliday.view_holiday()
                Catch ex As Exception
                    errorDelete()
                End Try
            End If
        ElseIf formName = "FormFGRepair" Then
            If check_edit_report_status(FormFGRepair.GVRepair.GetFocusedRowCellValue("id_report_status").ToString, "91", FormFGRepair.GVRepair.GetFocusedRowCellValue("id_fg_repair")) Then
                confirm = XtraMessageBox.Show("Are you sure want to delete?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
                If confirm = Windows.Forms.DialogResult.Yes Then
                    Try
                        Dim id_fg_repair As String = FormFGRepair.GVRepair.GetFocusedRowCellValue("id_fg_repair").ToString

                        'cancel reserve
                        Dim cancel As New ClassFGRepair()
                        cancel.cancelReservedStock(id_fg_repair)

                        query = String.Format("DELETE FROM tb_fg_repair WHERE id_fg_repair='{0}'", id_fg_repair)
                        execute_non_query(query, True, "", "", "", "")
                        FormFGRepair.viewData()
                    Catch ex As Exception
                        errorDelete()
                    End Try
                End If
            Else
                stopCustom("This data already marked")
            End If
        ElseIf formName = "FormFGRepairRec" Then
            If check_edit_report_status(FormFGRepairRec.GVRepairRec.GetFocusedRowCellValue("id_report_status").ToString, "92", FormFGRepairRec.GVRepairRec.GetFocusedRowCellValue("id_fg_repair_rec")) Then
                confirm = XtraMessageBox.Show("Are you sure want to delete?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
                If confirm = Windows.Forms.DialogResult.Yes Then
                    Try
                        Dim id_fg_repair_rec As String = FormFGRepairRec.GVRepairRec.GetFocusedRowCellValue("id_fg_repair_rec").ToString

                        query = String.Format("DELETE FROM tb_fg_repair_rec WHERE id_fg_repair_rec='{0}'", id_fg_repair_rec)
                        execute_non_query(query, True, "", "", "", "")
                        FormFGRepairRec.viewData()
                        FormFGRepairRec.viewRepairList()
                    Catch ex As Exception
                        errorDelete()
                    End Try
                End If
            Else
                stopCustom("This data already marked")
            End If
        ElseIf formName = "FormFGRepairReturnRec" Then
            If check_edit_report_status(FormFGRepairReturnRec.GVRepairRec.GetFocusedRowCellValue("id_report_status").ToString, "94", FormFGRepairReturnRec.GVRepairRec.GetFocusedRowCellValue("id_fg_repair_return_rec")) Then
                confirm = XtraMessageBox.Show("Are you sure want to delete?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
                If confirm = Windows.Forms.DialogResult.Yes Then
                    Try
                        Dim id_fg_repair_return_rec As String = FormFGRepairReturnRec.GVRepairRec.GetFocusedRowCellValue("id_fg_repair_return_rec").ToString

                        query = String.Format("DELETE FROM tb_fg_repair_return_rec WHERE id_fg_repair_return_rec='{0}'", id_fg_repair_return_rec)
                        execute_non_query(query, True, "", "", "", "")
                        FormFGRepairReturnRec.viewData()
                        FormFGRepairReturnRec.viewRepairList()
                    Catch ex As Exception
                        errorDelete()
                    End Try
                End If
            Else
                stopCustom("This data already marked")
            End If
        ElseIf formName = "FormFGRepairReturn" Then
            If check_edit_report_status(FormFGRepairReturn.GVRepairReturn.GetFocusedRowCellValue("id_report_status").ToString, "93", FormFGRepairReturn.GVRepairReturn.GetFocusedRowCellValue("id_fg_repair_return")) Then
                confirm = XtraMessageBox.Show("Are you sure want to delete?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
                If confirm = Windows.Forms.DialogResult.Yes Then
                    Try
                        Dim id_fg_repair_return As String = FormFGRepairReturn.GVRepairReturn.GetFocusedRowCellValue("id_fg_repair_return").ToString

                        'cancel reserve
                        Dim cancel As New ClassFGRepairReturn()
                        cancel.cancelReservedStock(id_fg_repair_return)

                        query = String.Format("DELETE FROM tb_fg_repair_return WHERE id_fg_repair_return='{0}'", id_fg_repair_return)
                        execute_non_query(query, True, "", "", "", "")
                        FormFGRepairReturn.viewData()
                    Catch ex As Exception
                        errorDelete()
                    End Try
                End If
            Else
                stopCustom("This data already marked")
            End If
        ElseIf formName = "FormEmpEmail" Then
            Dim type As String = FormEmpEmail.GVEmail.GetFocusedRowCellValue("type").ToString
            If type = "1" Then
                stopCustom("You don't have permission to delete this data")
            Else
                Dim id As String = FormEmpEmail.GVEmail.GetFocusedRowCellValue("id_other_email").ToString
                confirm = XtraMessageBox.Show("Are you sure want to delete?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
                If confirm = Windows.Forms.DialogResult.Yes Then
                    Dim query_del As String = "DELETE FROM tb_m_other_email WHERE id_other_email='" + id + "'"
                    execute_non_query(query_del, True, "", "", "", "")
                    FormEmpEmail.viewEmployee("-1")
                End If
            End If
        ElseIf formName = "FormEmpLeave" Then
            '
        ElseIf formName = "FormEmpDP" Then
            If check_edit_report_status(FormEmpDP.GVLeave.GetFocusedRowCellValue("id_report_status").ToString, "97", FormEmpDP.GVLeave.GetFocusedRowCellValue("id_dp")) Then
                Dim id As String = FormEmpDP.GVLeave.GetFocusedRowCellValue("id_dp").ToString
                confirm = XtraMessageBox.Show("Are you sure want to delete?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
                If confirm = DialogResult.Yes Then
                    Dim query_del As String = "DELETE FROM tb_emp_dp WHERE id_dp='" + id + "'"
                    execute_non_query(query_del, True, "", "", "", "")
                    FormEmpDP.load_dp()
                End If
            Else
                stopCustom("This report already appoved.")
            End If
        Else
            RPSubMenu.Visible = False
        End If
    End Sub
    'Print Data
    Private Sub BBPrint_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles BBPrint.ItemClick
        Cursor = Cursors.WaitCursor
        If formName = "FormMasterArea" Then
            If FormMasterArea.XTCArea.SelectedTabPageIndex = 0 Then
                'country
                print(FormMasterArea.GCCountry, "List Country")
            ElseIf FormMasterArea.XTCArea.SelectedTabPageIndex = 1 Then
                'state
                print(FormMasterArea.GCState, "List State of " & FormMasterArea.GVCountry.GetFocusedRowCellDisplayText("country").ToString)
            Else
                'city
                print(FormMasterArea.GCCity, "List City of " & FormMasterArea.GVState.GetFocusedRowCellDisplayText("state").ToString)
            End If
        ElseIf formName = "FormMasterCompany" Then
            '
            print(FormMasterCompany.GCCompany, "List Company")
        ElseIf formName = "FormMasterCompanyCategory" Then
            '
            print(FormMasterCompanyCategory.GCCompanyCategory, "Company Category")
        ElseIf formName = "FormMasterDepartement" Then
            '
            print(FormMasterDepartement.GCDepartement, "List Departement")
        ElseIf formName = "FormMasterRawMaterialCat" Then
            '
            print(FormMasterRawMaterialCat.GridControlMasterItemCategory, "Master Item Category")
        ElseIf formName = "FormMasterItemColor" Then
            '
            print(FormMasterItemColor.GCItemColor, "Master Item Color")
        ElseIf formName = "FormMasterItemSize" Then
            '
            print(FormMasterItemSize.GCItemSize, "Master Item Size")
        ElseIf formName = "FormMasterUser" Then
            print(FormMasterUser.GCUser, "List User")
        ElseIf formName = "FormAccess" Then
            If FormAccess.XTCMenuManage.SelectedTabPageIndex = 2 Then 'Print Role
                print(FormAccess.GCRole, "List Role")
            ElseIf FormAccess.XTCMenuManage.SelectedTabPageIndex = 1 Then 'Print Menu
                print(FormAccess.GCMenu, "List Menu")
            ElseIf FormAccess.XTCMenuManage.SelectedTabPageIndex = 0 Then 'Print Form
                If FormAccess.XTCForm.SelectedTabPageIndex = 0 Then 'Form
                    print(FormAccess.GCForm, "List Form")
                ElseIf FormAccess.XTCForm.SelectedTabPageIndex = 1 Then 'Form Control
                    print(FormAccess.GCProcess, "List Process " + FormAccess.GVForm.GetFocusedRowCellDisplayText("form_name").ToString)
                End If
            End If
        ElseIf formName = "FormSeason" Then
            If FormSeason.XTCMainSeason.SelectedTabPageIndex = 0 Then 'PRINT INTERNAL SEASON
                If FormSeason.XTCSeason.SelectedTabPageIndex = 0 Then  'print range
                    print(FormSeason.GCRange, "List Range")
                    'ElseIf FormSeason.XTCSeason.SelectedTabPageIndex = 1 Then  'print season
                    '    print(FormSeason.GCSeason, "List Season")
                ElseIf FormSeason.XTCSeason.SelectedTabPageIndex = 2 Then 'print delivery
                    print(FormSeason.GCDelivery, FormSeason.delivery_title)
                End If
            Else 'PRINT ORIGIN SEASON
                print(FormSeason.GCOrignSeason, "List Season Origin")
            End If
        ElseIf formName = "FormMasterUOM" Then
            print(FormMasterUOM.GCUOM, "Unit Of Measure")
        ElseIf formName = "FormMasterRawMat" Then
            If FormMasterRawMat.XTCRawMat.SelectedTabPageIndex = 0 Then 'print raw mat
                print(FormMasterRawMat.GCRawMat, "List Raw Material")
            ElseIf FormMasterRawMat.XTCRawMat.SelectedTabPageIndex = 1 Then 'print raw mat lot
                print(FormMasterRawMat.GCLot, "Detail Lot " + System.Globalization.CultureInfo.CurrentCulture.TextInfo.ToTitleCase(FormMasterRawMat.GVRawMat.GetFocusedRowCellDisplayText("raw_mat").ToString))
            ElseIf FormMasterRawMat.XTCRawMat.SelectedTabPageIndex = 2 Then 'print raw mat supplier
                print(FormMasterRawMat.GCSupplier, "Detail Supplier " + System.Globalization.CultureInfo.CurrentCulture.TextInfo.ToTitleCase(FormMasterRawMat.GVLot.GetFocusedRowCellDisplayText("raw_mat_detail").ToString))
            End If
        ElseIf formName = "FormMasterRawMaterial" Then
            If FormMasterRawMaterial.XTCList.SelectedTabPageIndex = 0 Then
                If FormMasterRawMaterial.XTCMaterialType.SelectedTabPageIndex = 0 Then
                    print(FormMasterRawMaterial.GCRawMat, "List Raw Material")
                ElseIf FormMasterRawMaterial.XTCMaterialType.SelectedTabPageIndex = 1 Then
                    print(FormMasterRawMaterial.GCMatDetail, "List Detail Material : " + FormMasterRawMaterial.GVRawMat.GetFocusedRowCellDisplayText("mat_name").ToString)
                End If
            ElseIf FormMasterRawMaterial.XTCList.SelectedTabPageIndex = 1 Then
                print(FormMasterRawMaterial.GCListMat, "List Raw Material")
            End If

        ElseIf formName = "FormMasterOVH" Then
            print(FormMasterOVH.GCOVH, "Overhead")
        ElseIf formName = "FormMasterCode" Then
            '
            If FormMasterCode.XTCCode.SelectedTabPageIndex = 0 Then
                'code
                print(FormMasterCode.GCCode, "Master Code")
            ElseIf FormMasterCode.XTCCode.SelectedTabPageIndex = 1 Then
                'code detail
                print(FormMasterCode.GCCodeDetail, FormMasterCode.LabelCodeContent.Text)
            End If
        ElseIf formName = "FormTemplateCode" Then
            '
            If FormTemplateCode.XTCTemplateCode.SelectedTabPageIndex = 0 Then
                'code
                print(FormTemplateCode.GCTemplateCode, "Template Code")
            ElseIf FormTemplateCode.XTCTemplateCode.SelectedTabPageIndex = 1 Then
                'code detail
                print(FormTemplateCode.GCTemplateCodeDet, FormTemplateCode.LabelTemplate.Text)
            End If
        ElseIf formName = "FormMasterProduct" Then
            '
            If FormMasterProduct.XTCProduct.SelectedTabPageIndex = 0 Then
                'design
                print(FormMasterProduct.GCDesign, "List Design")
            ElseIf FormMasterProduct.XTCProduct.SelectedTabPageIndex = 1 Then
                'product
                print(FormMasterProduct.GCProduct, FormMasterProduct.LabelPrintedName.Text)
            End If
        ElseIf formName = "FormMasterSample" Then
            '
            print(FormMasterSample.GCSample, "Sample List")
        ElseIf formName = "FormBOM" Then
            '
            If FormBOM.XTCBOMSelection.SelectedTabPageIndex = 1 Then
                ReportBOM.id_bom = FormBOM.GVBOM.GetFocusedRowCellDisplayText("id_bom").ToString
                ReportBOM.product_name = FormBOM.GVProduct.GetFocusedRowCellDisplayText("product_name").ToString & " - " & FormBOM.GVProduct.GetFocusedRowCellDisplayText("Size").ToString
                ReportBOM.bom_name = FormBOM.GVBOM.GetFocusedRowCellDisplayText("bom_name").ToString
                ReportBOM.bom_date = FormBOM.GVBOM.GetFocusedRowCellDisplayText("bom_date_created").ToString
                ReportBOM.bom_term = FormBOM.GVBOM.GetFocusedRowCellDisplayText("term_production").ToString

                Dim Report As New ReportBOM()
                ' Show the report's preview. 
                Dim Tool As DevExpress.XtraReports.UI.ReportPrintTool = New DevExpress.XtraReports.UI.ReportPrintTool(Report)
                Tool.ShowPreview()
            ElseIf FormBOM.XTCBOMSelection.SelectedTabPageIndex = 0 Then
                print(FormBOM.GCBOMDesign, "Bill Of Material - " & FormBOM.GVDesign.GetFocusedRowCellValue("design_name").ToString & " - " & FormBOM.GVDesign.GetFocusedRowCellValue("design_code").ToString)
            ElseIf FormBOM.XTCBOMSelection.SelectedTabPageIndex = 2 Then
                print(FormBOM.GCCompPerDesign, "Bill Of Material - " & FormBOM.GVPerDesign.GetFocusedRowCellValue("design_name").ToString & " - " & FormBOM.GVPerDesign.GetFocusedRowCellValue("design_code").ToString)
            End If
        ElseIf formName = "FormProdDemand" Then
            'PRODUCTION DEMAND
            print(FormProdDemand.GCProdDemand, "Production Demand List")
            'ReportProdDemand.id_prod_demand = FormProdDemand.GVProdDemand.GetFocusedRowCellDisplayText("id_prod_demand").ToString
            'ReportProdDemand.prod_demand_number = FormProdDemand.GVProdDemand.GetFocusedRowCellDisplayText("prod_demand_number").ToString
            'ReportProdDemand.season = FormProdDemand.GVProdDemand.GetFocusedRowCellDisplayText("season").ToString

            'Dim Report As New ReportProdDemand()
            'Report.Landscape = True
            '' Show the report's preview. 
            'Dim Tool As DevExpress.XtraReports.UI.ReportPrintTool = New DevExpress.XtraReports.UI.ReportPrintTool(Report)
            'Tool.ShowPreview()
        ElseIf formName = "FormSamplePL" Then
            'PACKING LIST RECEIVING SAMPLE 
            print(FormSamplePL.GCPL, "Packing List To Storage")
        ElseIf formName = "FormSamplePLDel" Then
            'PACKING LIST RECEIVING SAMPLE 
            print(FormSamplePLDel.GCPL, "Packing List Sample Borrow")
        ElseIf formName = "FormSamplePurchase" Then
            '
            print(FormSamplePurchase.GCSamplePurchase, "List Purchase Order Sample")
        ElseIf formName = "FormSampleReceive" Then
            '
            print(FormSampleReceive.GCSampleReceive, "List Receiving Report Sample")
        ElseIf formName = "FormSamplePR" Then
            '
            print(FormSamplePR.GCSamplePR, "List Payment Requistion  Sample")
        ElseIf formName = "FormMasterWH" Then
            'WAREHOUSE & LOCATOR
            If FormMasterWH.XTCWH.SelectedTabPageIndex = 0 Then
                'Warehouse
                print(FormMasterWH.GCWH, "List Warehouse")
            ElseIf FormMasterWH.XTCWH.SelectedTabPageIndex = 1 Then
                'Locator
                print(FormMasterWH.GCWHLocator, "List Locator - " + FormMasterWH.GVWH.GetFocusedRowCellDisplayText("comp_name").ToString)
            ElseIf FormMasterWH.XTCWH.SelectedTabPageIndex = 2 Then
                'Rack
                print(FormMasterWH.GCRack, "List Rack - " + FormMasterWH.GVWH.GetFocusedRowCellDisplayText("comp_name").ToString + "/" + FormMasterWH.GVLocator.GetFocusedRowCellDisplayText("wh_locator").ToString)
            ElseIf FormMasterWH.XTCWH.SelectedTabPageIndex = 3 Then
                'Drawer
                print(FormMasterWH.GCDrawer, "List Drawer - " + FormMasterWH.GVWH.GetFocusedRowCellDisplayText("comp_name").ToString + "/" + FormMasterWH.GVLocator.GetFocusedRowCellDisplayText("wh_locator").ToString + "/" + FormMasterWH.GVRack.GetFocusedRowCellDisplayText("wh_rack").ToString)
            End If
        ElseIf formName = "FormSampleReceipt" Then
            'Receipt Sample
            print(FormSampleReceipt.GCReceipt, "List Sample Receipt")
        ElseIf formName = "FormSampleRet" Then
            'RETURN SAMPLE
            If FormSampleRet.XTCReturn.SelectedTabPageIndex = 0 Then 'returnIn
                print(FormSampleRet.GCRetOut, "List Return Out")
            ElseIf FormSampleRet.XTCReturn.SelectedTabPageIndex = 1 Then 'Return Out
                print(FormSampleRet.GCRetIn, "List Return In")
            End If
        ElseIf formName = "FormSampleReq" Then
            'REQ SAMPLE
            print(FormSampleReq.GCReq, "Sample Borrow Requisition")
        ElseIf formName = "FormMarkAssign" Then
            'Assign mark
            print(FormMarkAssign.GCMarkAssign, "Mapping Approval System")
        ElseIf formName = "FormSamplePlan" Then
            'Planning Sample
            print(FormSamplePlan.GCSamplePurchase, "List Planning Sample")
        ElseIf formName = "FormMatPurchase" Then
            'Purchase Material
            print(FormMatPurchase.GCMatPurchase, "List Purchase Material")
        ElseIf formName = "FormMatWO" Then
            'Purchase Material
            print(FormMatWO.GCMatWO, "List Work Order Material")
        ElseIf formName = "FormMatRecPurc" Then
            'Receive Material Purchase
            If FormMatRecPurc.XTCTabReceive.SelectedTabPageIndex = 0 Then
                print(FormMatRecPurc.GCMatRecPurc, "List Receive Material Purchase")
            Else 'based on PO
                print(FormMatRecPurc.GCMatPurchase, "List Material Purchase Waiting To Receive")
            End If
        ElseIf formName = "FormMatRecWO" Then
            'Receive Material WO
            If FormMatRecWO.XTCTabReceive.SelectedTabPageIndex = 0 Then ' based on receive
                print(FormMatRecWO.GCListPurchase, "List Receive Material Work Order")
            Else 'based on WO
                print(FormMatRecWO.GCMatWO, "List Material Work Order Waiting To Receive")
            End If
        ElseIf formName = "FormMatRet" Then
            If FormMatRet.XTCReturnMat.SelectedTabPageIndex = 0 Then 'purchase
                'Return Mat
                If FormMatRet.XTCReturnPruchase.SelectedTabPageIndex = 0 Then 'return Out
                    print(FormMatRet.GCRetOut, "List Return Out Material Purchasing")
                ElseIf FormMatRet.XTCReturnPruchase.SelectedTabPageIndex = 1 Then 'return In
                    print(FormMatRet.GCRetIn, "List Return In Material Purchasing")
                End If
            ElseIf FormMatRet.XTCReturnMat.SelectedTabPageIndex = 1 Then 'production
                If FormMatRet.XTCReturnProd.SelectedTabPageIndex = 0 Then 'return In
                    print(FormMatRet.GCRetInProd, "List Return In Material Production")
                End If
            End If
        ElseIf formName = "FormSampleReturn" Then
            'RETURN SAMPLE
            If FormSampleReturn.XTCReturn.SelectedTabPageIndex = 0 Then 'returnIn
                print(FormSampleReturn.GCRetSample, "Return Sample Borrow")
            ElseIf FormSampleReturn.XTCReturn.SelectedTabPageIndex = 1 Then 'Return Out
                'print(FormSampleRet.GCRetIn, "List Return In")
            End If
        ElseIf formName = "FormSampleAdjustment" Then
            'ADJUSTMENT SAMPLE
            If FormSampleAdjustment.XTCAdj.SelectedTabPageIndex = 0 Then 'In
                print(FormSampleAdjustment.GCAdjSampleIn, "Adjusment In")
            ElseIf FormSampleAdjustment.XTCAdj.SelectedTabPageIndex = 1 Then 'Out
                print(FormSampleAdjustment.GCAdjOutSample, "Adjusment Out")
            End If
        ElseIf formName = "FormMatAdj" Then
            'ADJUSTMENT Material
            If FormMatAdj.XTCAdj.SelectedTabPageIndex = 0 Then 'In
                print(FormMatAdj.GCAdjIn, "List Adjusment In")
            ElseIf FormMatAdj.XTCAdj.SelectedTabPageIndex = 1 Then 'Out
                print(FormMatAdj.GCAdjOut, "List Adjusment Out")
            End If
        ElseIf formName = "FormMatPR" Then
            'PR PO MATERIAL 
            If FormMatPR.XTCTabPR.SelectedTabPageIndex = 0 Then 'List PR
                print(FormMatPR.GCMatPR, "Payment Requisition PO Material")
            ElseIf FormMatPR.XTCTabPR.SelectedTabPageIndex = 1 Then 'List PO
                print(FormMatPR.GCMatPurchaseNeed, "PO Need Payment Requisition")
            ElseIf FormMatPR.XTCTabPR.SelectedTabPageIndex = 2 Then 'List Rec
                print(FormMatPR.GCMatReceive, "Receiving Need Payment Requisition")
            End If
        ElseIf formName = "FormMatPRWO" Then
            'PR WO MATERIAL 
            If FormMatPRWO.XTCTabPR.SelectedTabPageIndex = 0 Then 'List PR
                print(FormMatPRWO.GCMatPRWO, "Payment Requisition WO Material")
            ElseIf FormMatPRWO.XTCTabPR.SelectedTabPageIndex = 1 Then 'List PO
                print(FormMatPRWO.GCMatPurchaseNeed, "WO Need Payment Requisition")
            ElseIf FormMatPRWO.XTCTabPR.SelectedTabPageIndex = 2 Then 'List Rec
                print(FormMatPRWO.GCMatReceive, "Receiving Need Payment Requisition")
            End If
        ElseIf formName = "FormProduction" Then
            If FormProduction.XTCTabProduction.SelectedTabPageIndex = 0 Then
                print(FormProduction.GCProd, "Production Order")
            ElseIf FormProduction.XTCTabProduction.SelectedTabPageIndex = 1 Then

            ElseIf FormProduction.XTCTabProduction.SelectedTabPageIndex = 2 Then
                print(FormProduction.GCProdWO, "Production Order WO")
            ElseIf FormProduction.XTCTabProduction.SelectedTabPageIndex = 3 Then
                print(FormProduction.GCMRS, "Production Order MRS")
            End If
        ElseIf formName = "FormMatPL" Then
            'Packing list material
            If FormMatPL.XTCPL.SelectedTabPageIndex = 0 Then 'Prod MRS
                If FormMatPL.XTCTabProduction.SelectedTabPageIndex = 0 Then 'list PL
                    print(FormMatPL.GCProdPL, "Packing List Material For Production")
                ElseIf FormMatPL.XTCTabProduction.SelectedTabPageIndex = 1 Then 'list MRS
                    print(FormMatPL.GCMRS, "List Material Request For Production")
                End If
            ElseIf FormMatPL.XTCPL.SelectedTabPageIndex = 1 Then 'Out
                If FormMatPL.XTCPLOther.SelectedTabPageIndex = 0 Then
                    print(FormMatPL.GCPLOther, "Packing List Material Other")
                ElseIf FormMatPL.XTCPLOther.SelectedTabPageIndex = 0 Then
                    print(FormMatPL.GCMRSOther, "List Material Request Other")
                End If
            End If
        ElseIf formName = "FormMatMRS" Then
            'Material Requisition : Other
            print(FormMatPL.GCProdPL, "List Material Requisiton")
        ElseIf formName = "FormProductionRec" Then
            'Receive FG QC
            If FormProductionRec.XTCTabReceive.SelectedTabPageIndex = 0 Then
                print(FormProductionRec.GCProdRec, "List Receiving Finished Goods in QC")
            Else 'based on PO
                print(FormProductionRec.GCProd, "List Production Order Waiting To Receive")
            End If
        ElseIf formName = "FormProductionRet" Then
            'Return Production
            If FormProductionRet.XTCReturn.SelectedTabPageIndex = 0 Then 'return Out
                print(FormProductionRet.GCRetOut, "List Return Out Finished Goods")
            ElseIf FormProductionRet.XTCReturn.SelectedTabPageIndex = 1 Then 'return In
                print(FormProductionRet.GCRetIn, "List Return In Finished Goods")
            End If
        ElseIf formName = "FormProductionPLToWH" Then
            If FormProductionPLToWH.XTCPL.SelectedTabPageIndex = 0 Then
                print(FormProductionPLToWH.GCPL, "Packing List Finished Goods")
            ElseIf FormProductionPLToWH.XTCPL.SelectedTabPageIndex = 1 Then
                '
            End If
        ElseIf formName = "FormMatInvoice" Then
            'Invoice Material PL MRS
            If FormMatInvoice.XTCTabGeneral.SelectedTabPageIndex = 0 Then
                If FormMatInvoice.XTCTabProduction.SelectedTabPageIndex = 0 Then
                    print(FormMatInvoice.GCProdInvoice, "List Invoice Material.")
                Else 'based on PL
                    print(FormMatInvoice.GCProdPL, "List Packing List Material.")
                End If
            ElseIf FormMatInvoice.XTCTabGeneral.SelectedTabPageIndex = 0 Then
                If FormMatInvoice.XTCRetur.SelectedTabPageIndex = 0 Then
                    print(FormMatInvoice.GCRetur, "List Invoice Retur Material.")
                Else 'based on invoice
                    print(FormMatInvoice.GCInvoice, "List Invoice Material.")
                End If
            End If
        ElseIf formName = "FormAccounting" Then
            print(FormAccounting.GCAcc, "Chart Of Account")
        ElseIf formName = "FormAccountingJournal" Then
            If FormAccountingJournal.XTCJurnal.SelectedTabPageIndex = 0 Then
                print(FormAccountingJournal.GCAccTrans, "Journal Transaction")
            Else
                print(FormAccountingJournal.GCJournalDet, "Journal Transaction")
            End If
        ElseIf formName = "FormAccountingJournalAdj" Then
            print(FormAccountingJournalAdj.GCAccTrans, "Adjustment Journal")
        ElseIf formName = "FormProductionPLToWHRec" Then
            If FormProductionPLToWHRec.XTCPL.SelectedTabPageIndex = 0 Then
                print(FormProductionPLToWHRec.GCPL, "List Receiving Finished Goods in WH")
            ElseIf FormProductionPLToWHRec.XTCPL.SelectedTabPageIndex = 1 Then
                print(FormProductionPLToWHRec.GCProd, "List Waiting Receive Finished Goods")
            End If
        ElseIf formName = "FormSalesTarget" Then
            'SALES TARGET
            If FormSalesTarget.XTCSalesTarget.SelectedTabPageIndex = 0 Then
                print(FormSalesTarget.GCSalesTarget, "List Sales Target")
            End If
        ElseIf formName = "FormSalesOrder" Then
            'SALES ORDER
            If FormSalesOrder.XTCSOGeneral.SelectedTabPageIndex = 0 Then
                print(FormSalesOrder.GCSalesOrder, "List Prepare Order")
            ElseIf FormSalesOrder.XTCSOGeneral.SelectedTabPageIndex = 1 Then
                print(FormSalesOrder.GCGen, "Generate Prepare Order")
            End If
        ElseIf formName = "FormSalesDelOrder" Then
            'SALES DEL ORDER
            If FormSalesDelOrder.XTCDO.SelectedTabPageIndex = 0 Then
                print(FormSalesDelOrder.GCSalesDelOrder, "TRANSACTION LIST - DELIVERY")
            ElseIf FormSalesDelOrder.XTCDO.SelectedTabPageIndex = 1 Then
                print(FormSalesDelOrder.GCSalesOrder, "PREPARE ORDER LIST")
            ElseIf FormSalesDelOrder.XTCDO.SelectedTabPageIndex = 2 Then
                print(FormSalesDelOrder.GCNewPrepare, "PREPARE ORDER REFERENCE - " + FormSalesDelOrder.TxtNoParam.Text.ToUpper + "")
            End If
        ElseIf formName = "FormSalesReturnOrder" Then
            'SALES RETURN ORDER
            print(FormSalesReturnOrder.GCSalesReturnOrder, "List Return Order")
        ElseIf formName = "FormSalesReturn" Then
            'SALES REUTNR
            If FormSalesReturn.XTCSalesReturn.SelectedTabPageIndex = 0 Then
                print(FormSalesReturn.GCSalesReturn, "List Return From Store")
            ElseIf FormSalesDelOrder.XTCSalesDelOrder.SelectedTabPageIndex = 1 Then
                'print(FormSalesDelOrder.GCSalesOrder, "List Waiting To Delivery Order")
                'FormSalesDelOrderPrintOpt.ShowDialog()
            End If
        ElseIf formName = "FormSalesPOS" Then
            'SALES VRTUAL POS
            print(FormSalesPOS.GCSalesPOS, "Sales Invoice")
        ElseIf formName = "FormSalesReturnQC" Then
            'SALES RETURN QC
            print(FormSalesReturnQC.GCSalesReturnQC, "List Quality Control Return Product")
        ElseIf formName = "FormProdPRWO" Then
            'PR Prod WO
            If FormProdPRWO.XTCTabPR.SelectedTabPageIndex = 0 Then 'List PR
                print(FormProdPRWO.GCMatPR, "Payment Requisition WO Production")
            ElseIf FormProdPRWO.XTCTabPR.SelectedTabPageIndex = 1 Then 'List WO
                print(FormProdPRWO.GCProdWO, "WO Production Need Payment Requisition")
            End If
        ElseIf formName = "FormSalesInvoice" Then
            'SALES INVOICE
            print(FormSalesInvoice.GCSalesInvoice, "Sales Invoice")
        ElseIf formName = "FormFGStockOpnameStore" Then
            'STORE STOCK OPNAME
            print(FormFGStockOpnameStore.GCSOStore, "Store Stock Opname")
        ElseIf formName = "FormFGMissing" Then
            'FG MISSING
            If FormFGMissing.XTCFGMissing.SelectedTabPageIndex = 0 Then
                print(FormFGMissing.GCFGMissing, "Missing Finished Goods In Store")
            ElseIf FormFGMissing.XTCFGMissing.SelectedTabPageIndex = 1 Then
                print(FormFGMissing.GCMissingWH, "Missing Finished Goods In Warehouse")
            End If
        ElseIf formName = "FormFGMissingInvoice" Then
            'FG Missing INVOICE
            print(FormFGMissingInvoice.GCFGMissingInvoice, "Missing Finished Goods Invoice")
        ElseIf formName = "FormFGStockOpnameWH" Then
            'WH STOCK OPNAME
            print(FormFGStockOpnameWH.GCSOWH, "WH Stock Opname")
        ElseIf formName = "FormMatStockOpname" Then
            'Material Stock Opname
            print(FormMatStockOpname.GCMatPR, "List Material Stock Opname")
        ElseIf formName = "FormMatStockOpname" Then
            'Material Stock Opname
            FormMatStockOpname.Close()
            FormMatStockOpname.Dispose()
        ElseIf formName = "FormFGAdj" Then
            'ADJUSTMENT FG
            If FormFGAdj.XTCAdj.SelectedTabPageIndex = 0 Then 'In
                print(FormFGAdj.GCAdjIn, "List Adjusment In Finished Goods")
            ElseIf FormFGAdj.XTCAdj.SelectedTabPageIndex = 1 Then 'Out
                print(FormFGAdj.GCAdjOut, "List Adjusment Out Finished Goods")
            End If
        ElseIf formName = "FormFGTrf" Then
            'FG Transfer Future
            print(FormFGTrf.GCFGTrf, "Finished Goods Transfer")
        ElseIf formName = "FormFGTrfNew" Then
            'FG Transfer
            If FormFGTrfNew.XTCTrf.SelectedTabPageIndex = 0 Then
                print(FormFGTrfNew.GCFGTrf, "TRANSACTION LIST - TRANSFER")
            ElseIf FormFGTrfNew.XTCTrf.SelectedTabPageIndex = 1 Then
                print(FormFGTrfNew.GCSalesOrder, "PREPARE ORDER LIST")
            End If
        ElseIf formName = "FormFGTrfRec" Then
            'FG Transfer Rec
            print(FormFGTrfReceive.GCFGTrf, "Receive Finished Goods Transfer")
        ElseIf formName = "FormFGTracking" Then
            'FG Tracking
            Cursor = Cursors.WaitCursor
            print(FormFGTracking.GCTracking, "Tracking Product " + FormFGTracking.LabelTitle.Text)
            Cursor = Cursors.Default
        ElseIf formName = "FormFGStock" Then
            'FG STOCK
            Cursor = Cursors.WaitCursor
            If FormFGStock.XTCFGStock.SelectedTabPageIndex = 0 Then
                '... 
                ' creating and saving the view's layout to a new memory stream 
                Dim str As System.IO.Stream
                str = New System.IO.MemoryStream()
                FormFGStock.BGVFGStock.SaveLayoutToStream(str, DevExpress.Utils.OptionsLayoutBase.FullLayout)
                str.Seek(0, System.IO.SeekOrigin.Begin)
                ReportFGStockSum.str_param = str
                ReportFGStockSum.dt = FormFGStock.dt_sum
                Dim Report As New ReportFGStockSum()
                Report.BandedGridView1.RestoreLayoutFromStream(str, DevExpress.Utils.OptionsLayoutBase.FullLayout)
                str.Seek(0, System.IO.SeekOrigin.Begin)

                Report.LabelDesign.Text = FormFGStock.label_design_selected_stock_sum
                Report.LabelWH.Text = FormFGStock.label_wh_selected_stock_sum
                Report.LabelLocator.Text = FormFGStock.label_locator_selected_stock_sum
                Report.LabelRack.Text = FormFGStock.label_rack_selected_stock_sum
                Report.LabelDrawer.Text = FormFGStock.label_drawer_selected_stock_sum

                ReportStyleBanded(Report.BandedGridView1)

                ' Show the report's preview. 
                Dim Tool As DevExpress.XtraReports.UI.ReportPrintTool = New DevExpress.XtraReports.UI.ReportPrintTool(Report)
                Tool.ShowPreview()
            ElseIf FormFGStock.XTCFGStock.SelectedTabPageIndex = 1 Then
                'modify period
                Dim period_from As String = ""
                Dim period_until As String = ""
                If FormFGStock.date_from_selected = "0000-01-01" Then
                    period_from = "-"
                Else
                    period_from = DateTime.Parse(FormFGStock.date_from_selected).ToString("dd MMM yyyy")
                End If
                If FormFGStock.date_until_selected = "9999-01-01" Then
                    period_until = "-"
                Else
                    period_until = DateTime.Parse(FormFGStock.date_until_selected).ToString("dd MMM yyyy")
                End If


                '... 
                ' creating and saving the view's layout to a new memory stream 
                Dim str As System.IO.Stream
                str = New System.IO.MemoryStream()
                FormFGStock.BandedGridViewFGStockCard.SaveLayoutToStream(str, DevExpress.Utils.OptionsLayoutBase.FullLayout)
                str.Seek(0, System.IO.SeekOrigin.Begin)
                ReportFGStockCard.str_param = str
                ReportFGStockCard.dt = FormFGStock.dt
                Dim Report As New ReportFGStockCard()
                Report.BandedGridView1.RestoreLayoutFromStream(str, DevExpress.Utils.OptionsLayoutBase.FullLayout)
                str.Seek(0, System.IO.SeekOrigin.Begin)

                Report.LabelWH.Text = FormFGStock.SLEWH.Text.ToUpper
                Report.LabelProduct.Text = FormFGStock.TxtCodeDsgSC.Text + " - " + FormFGStock.LabelControl5.Text
                Report.LabelPeriod.Text = period_from + " - " + period_until
                ReportStyleBanded(Report.BandedGridView1)
                Report.BandedGridView1.ColumnPanelRowHeight = 40

                ' Show the report's preview. 
                Dim Tool As DevExpress.XtraReports.UI.ReportPrintTool = New DevExpress.XtraReports.UI.ReportPrintTool(Report)
                Tool.ShowPreview()
            ElseIf FormFGStock.XTCFGStock.SelectedTabPageIndex = 2 Then
                'modify period
                Dim period_from As String = ""
                Dim period_until As String = ""
                If FormFGStock.date_from_selected_stock_store = "0000-01-01" Then
                    period_from = ""
                Else
                    period_from = DateTime.Parse(FormFGStock.date_from_selected_stock_store).ToString("dd MMM yyyy")
                End If
                If FormFGStock.date_until_selected_stock_store = "9999-01-01" Then
                    period_until = "-"
                Else
                    period_until = DateTime.Parse(FormFGStock.date_until_selected_stock_store).ToString("dd MMM yyyy")
                End If


                '... 
                ' creating and saving the view's layout to a new memory stream 
                Dim str As System.IO.Stream
                str = New System.IO.MemoryStream()
                FormFGStock.BGVFGStockStore.SaveLayoutToStream(str, DevExpress.Utils.OptionsLayoutBase.FullLayout)
                str.Seek(0, System.IO.SeekOrigin.Begin)
                ReportFGStockStore.dt = FormFGStock.dt_store
                Dim Report As New ReportFGStockStore()
                Report.BandedGridView1.RestoreLayoutFromStream(str, DevExpress.Utils.OptionsLayoutBase.FullLayout)
                str.Seek(0, System.IO.SeekOrigin.Begin)
                Report.LabelWH.Text = FormFGStock.label_store_selected_stock_store
                Report.LabelProduct.Text = FormFGStock.label_design_selected_stock_store
                Report.LabelPeriod.Text = "Stock Per " + period_until
                ReportStyleBanded(Report.BandedGridView1)


                ' Show the report's preview. 
                Dim Tool As DevExpress.XtraReports.UI.ReportPrintTool = New DevExpress.XtraReports.UI.ReportPrintTool(Report)
                Tool.ShowPreview()
            ElseIf FormFGStock.XTCFGStock.SelectedTabPageIndex = 3 Then 'QC STOCK
                'modify period
                Dim period_until As String = ""
                If FormFGStock.date_until_selected_stock_qc = "9999-01-01" Then
                    period_until = "-"
                Else
                    period_until = "Per-" + DateTime.Parse(FormFGStock.date_until_selected_stock_qc).ToString("dd MMM yyyy")
                End If

                '... 
                ' creating and saving the view's layout to a new memory stream 
                Dim str As System.IO.Stream
                str = New System.IO.MemoryStream()
                FormFGStock.BGVFGStockQC.SaveLayoutToStream(str, DevExpress.Utils.OptionsLayoutBase.FullLayout)
                str.Seek(0, System.IO.SeekOrigin.Begin)
                ReportFGStockQC.dt = FormFGStock.dt_qc
                Dim Report As New ReportFGStockQC()
                Report.BandedGridView1.RestoreLayoutFromStream(str, DevExpress.Utils.OptionsLayoutBase.FullLayout)
                str.Seek(0, System.IO.SeekOrigin.Begin)
                Report.LabelDesign.Text = FormFGStock.label_design_selected_stock_qc
                Report.LabelPeriod.Text = period_until
                ReportStyleBanded(Report.BandedGridView1)

                ' Show the report's preview. 
                Dim Tool As DevExpress.XtraReports.UI.ReportPrintTool = New DevExpress.XtraReports.UI.ReportPrintTool(Report)
                Tool.ShowPreview()
            End If
            Cursor = Cursors.Default
        ElseIf formName = "FormMatStock" Then
            'FG STOCK
            Cursor = Cursors.WaitCursor
            If FormMatStock.XTCFGStock.SelectedTabPageIndex = 0 Then
                If FormMatStock.GroupControlStockSum.Enabled = False Then 'not yet
                    stopCustom("Data not found.")
                Else
                    '... 
                    ' creating and saving the view's layout to a new memory stream 
                    Dim str As System.IO.Stream
                    str = New System.IO.MemoryStream()
                    FormMatStock.BGVFGStock.SaveLayoutToStream(str, DevExpress.Utils.OptionsLayoutBase.FullLayout)
                    str.Seek(0, System.IO.SeekOrigin.Begin)
                    ReportMatStockSum.str_param = str
                    ReportMatStockSum.dt = FormMatStock.dt_sum
                    Dim Report As New ReportMatStockSum()
                    Report.BandedGridView1.RestoreLayoutFromStream(str, DevExpress.Utils.OptionsLayoutBase.FullLayout)
                    str.Seek(0, System.IO.SeekOrigin.Begin)

                    Report.LabelDesign.Text = FormMatStock.label_design_selected_stock_sum
                    Report.LabelWH.Text = FormMatStock.label_wh_selected_stock_sum
                    Report.LabelLocator.Text = FormMatStock.label_locator_selected_stock_sum
                    Report.LabelRack.Text = FormMatStock.label_rack_selected_stock_sum
                    Report.LabelDrawer.Text = FormMatStock.label_drawer_selected_stock_sum
                    ReportStyleBanded(Report.BandedGridView1)

                    ' Show the report's preview. 
                    Dim Tool As DevExpress.XtraReports.UI.ReportPrintTool = New DevExpress.XtraReports.UI.ReportPrintTool(Report)
                    Tool.ShowPreview()
                End If
            ElseIf FormMatStock.XTCFGStock.SelectedTabPageIndex = 1 Then
                If FormMatStock.GroupControlTraccking.Enabled = False Then 'not yet
                    stopCustom("Data not found.")
                Else
                    'modify period
                    Dim period_from As String = ""
                    Dim period_until As String = ""
                    If FormMatStock.date_from_selected = "0000-01-01" Then
                        period_from = "-"
                    Else
                        period_from = DateTime.Parse(FormMatStock.date_from_selected).ToString("dd MMM yyyy")
                    End If
                    If FormMatStock.date_until_selected = "9999-01-01" Then
                        period_until = "-"
                    Else
                        period_until = DateTime.Parse(FormMatStock.date_until_selected).ToString("dd MMM yyyy")
                    End If

                    '... 
                    ' creating and saving the view's layout to a new memory stream 
                    Dim str As System.IO.Stream
                    str = New System.IO.MemoryStream()
                    FormMatStock.BandedGridViewFGStockCard.SaveLayoutToStream(str, DevExpress.Utils.OptionsLayoutBase.FullLayout)
                    str.Seek(0, System.IO.SeekOrigin.Begin)
                    ReportMatStockCard.str_param = str
                    ReportMatStockCard.dt = FormMatStock.dt
                    Dim Report As New ReportMatStockCard()
                    Report.BandedGridView1.RestoreLayoutFromStream(str, DevExpress.Utils.OptionsLayoutBase.FullLayout)
                    Report.LabelWH.Text = FormMatStock.comp_name_label_selected
                    Report.LabelProduct.Text = FormMatStock.label_mat_selected
                    Report.LabelPeriod.Text = period_from + " / " + period_until
                    str.Seek(0, System.IO.SeekOrigin.Begin)
                    ReportStyleBanded(Report.BandedGridView1)

                    ' Show the report's preview. 
                    Dim Tool As DevExpress.XtraReports.UI.ReportPrintTool = New DevExpress.XtraReports.UI.ReportPrintTool(Report)
                    Tool.ShowPreview()
                End If
            ElseIf FormMatStock.XTCFGStock.SelectedTabPageIndex = 2 Then
                If FormMatStock.GroupControlStockWo.Enabled = False Then 'not yet
                    stopCustom("Data not found.")
                Else
                    'modify period
                    Dim period_from As String = ""
                    Dim period_until As String = ""
                    If FormMatStock.date_from_selected_stock_vendor = "0000-01-01" Then
                        period_from = "-"
                    Else
                        period_from = DateTime.Parse(FormMatStock.date_from_selected_stock_vendor).ToString("dd MMM yyyy")
                    End If
                    If FormMatStock.date_until_selected_stock_vendor = "9999-01-01" Then
                        period_until = "-"
                    Else
                        period_until = DateTime.Parse(FormMatStock.date_until_selected_stock_vendor).ToString("dd MMM yyyy")
                    End If

                    '... 
                    ' creating and saving the view's layout to a new memory stream 
                    Dim str As System.IO.Stream
                    str = New System.IO.MemoryStream()
                    FormMatStock.BGVStockWO.SaveLayoutToStream(str, DevExpress.Utils.OptionsLayoutBase.FullLayout)
                    str.Seek(0, System.IO.SeekOrigin.Begin)
                    ReportMatStockWO.str_param = str
                    ReportMatStockWO.dt = FormMatStock.dt_store
                    Dim Report As New ReportMatStockWO()
                    Report.BandedGridView1.RestoreLayoutFromStream(str, DevExpress.Utils.OptionsLayoutBase.FullLayout)
                    Report.LabelWH.Text = FormMatStock.label_vendor_selected_stock_vendor
                    Report.LabelProduct.Text = FormMatStock.label_mat_selected_stock_vendor
                    Report.LabelPeriod.Text = period_from + " / " + period_until
                    str.Seek(0, System.IO.SeekOrigin.Begin)
                    ReportStyleBanded(Report.BandedGridView1)

                    ' Show the report's preview. 
                    Dim Tool As DevExpress.XtraReports.UI.ReportPrintTool = New DevExpress.XtraReports.UI.ReportPrintTool(Report)
                    Tool.ShowPreview()
                End If
            ElseIf FormMatStock.XTCFGStock.SelectedTabPageIndex = 3 Then 'BOM
                If FormMatStock.GCStockBOM.Enabled = False Then 'not yet
                    stopCustom("Data not found.")
                Else
                    'modify period
                    Dim period_from As String = ""
                    Dim period_until As String = ""
                    period_from = Date.Parse(FormMatStock.DEFromBOM.EditValue.ToString).ToString("dd MMM yyyy")
                    period_until = Date.Parse(FormMatStock.DEUntilBOM.EditValue.ToString).ToString("dd MMM yyyy")

                    '... 
                    ' creating and saving the view's layout to a new memory stream 
                    Dim str As System.IO.Stream
                    str = New System.IO.MemoryStream()
                    FormMatStock.BGVStockBOM.SaveLayoutToStream(str, DevExpress.Utils.OptionsLayoutBase.FullLayout)
                    str.Seek(0, System.IO.SeekOrigin.Begin)
                    ReportMatStockCard.str_param = str
                    ReportMatStockCard.dt = FormMatStock.GCStockBOM.DataSource
                    Dim Report As New ReportMatStockCard()
                    Report.BandedGridView1.RestoreLayoutFromStream(str, DevExpress.Utils.OptionsLayoutBase.FullLayout)
                    Report.LabelWH.Text = "ALL"
                    Report.LabelProduct.Text = FormMatStock.SLEMatBOM.Text
                    Report.LabelPeriod.Text = period_from + " / " + period_until
                    str.Seek(0, System.IO.SeekOrigin.Begin)
                    ReportStyleBanded(Report.BandedGridView1)

                    ' Show the report's preview. 
                    Dim Tool As DevExpress.XtraReports.UI.ReportPrintTool = New DevExpress.XtraReports.UI.ReportPrintTool(Report)
                    Tool.ShowPreview()
                End If
            End If
            Cursor = Cursors.Default
        ElseIf formName = "FormAccountingSummary" Then
            print_tree(FormAccountingSummary.TreeList1, "Summary Account")
        ElseIf formName = "FormSampleStock" Then
            If FormSampleStock.XTCWHMain.SelectedTabPageIndex = 0 Then 'stock
                'prepare
                Dim period As String = ""
                If FormSampleStock.date_until_stock_selected = "9999-12-01" Then
                    period = FormSampleStock.date_default
                Else
                    period = FormSampleStock.date_until_stock_selected
                End If

                '... 
                ' creating and saving the view's layout to a new memory stream 
                Dim str As System.IO.Stream
                str = New System.IO.MemoryStream()
                FormSampleStock.GVSample.SaveLayoutToStream(str, DevExpress.Utils.OptionsLayoutBase.FullLayout)
                str.Seek(0, System.IO.SeekOrigin.Begin)
                ReportSampleStock.dt = FormSampleStock.dt_stock
                Dim Report As New ReportSampleStock()
                Report.GridView1.RestoreLayoutFromStream(str, DevExpress.Utils.OptionsLayoutBase.FullLayout)
                Report.LabelWH.Text = FormSampleStock.wh_stock_selected
                Report.LabelLocator.Text = FormSampleStock.locator_stock_selected
                Report.LabelRack.Text = FormSampleStock.rack_stock_selected
                Report.LabelDrawer.Text = FormSampleStock.drawer_stock_selected
                Report.LabelPeriod.Text = period
                str.Seek(0, System.IO.SeekOrigin.Begin)
                ReportStyleGridview(Report.GridView1)

                ' Show the report's preview. 
                Dim Tool As DevExpress.XtraReports.UI.ReportPrintTool = New DevExpress.XtraReports.UI.ReportPrintTool(Report)
                Tool.ShowPreview()
            Else
            End If
        ElseIf formName = "FormMasterEmployee" Then
            print(FormMasterEmployee.GCEmployee, "Employee List")
        ElseIf formName = "FormSampleDel" Then
            'PL SAMPLE DELIVERY
            print(FormSampleDel.GCSampleDel, "Packing List Delivery Sample")
        ElseIf formName = "FormSampleDelRec" Then
            'REC PL SAMPLE DELIVERY
            If FormSampleDelRec.XTCSampleDelRec.SelectedTabPageIndex = 0 Then
                print(FormSampleDelRec.GCSampleDelRec, "Receive PL Delivery Sample")
            ElseIf FormSampleDelRec.XTCSampleDelRec.SelectedTabPageIndex = 1 Then
                print(FormSampleDelRec.GCSampleDel, "Waiting to Receive PL Delivery Sample")
            End If
        ElseIf formName = "FormSampleOrder" Then
            'SALES ORDER SAMPKE
            print(FormSampleOrder.GCSampleOrder, "Sales Order Sample")
        ElseIf formName = "FormSampleDelOrder" Then
            'DELIVERY ORDER SAMPLE FOR SALES
            If FormSampleDelOrder.XTCSampleDelOrder.SelectedTabPageIndex = 0 Then
                print(FormSampleDelOrder.GCSampleDelOrder, "Delivery Order Sample")
            ElseIf FormSampleDelOrder.XTCSampleDelOrder.SelectedTabPageIndex = 1 Then
                print(FormSampleDelOrder.GCSampleOrder, "Waiting to Delivery")
            End If
        ElseIf formName = "FormFGCodeReplace" Then
            'CODE REPLACEMENT
            If FormFGCodeReplace.XTCFGCodeReplace.SelectedTabPageIndex = 0 Then
                print(FormFGCodeReplace.GCFGCodeReplaceStore, "Code Replacement In Store")
            ElseIf FormFGCodeReplace.XTCFGCodeReplace.SelectedTabPageIndex = 1 Then
                print(FormFGCodeReplace.GCFGCodeReplaceWH, "Code Replacement In WH")
            End If
        ElseIf formName = "FormAccountingListPR" Then
            'Accounting List PR
            print(FormAccountingListPR.GCPaymentList, "List Open Payment Request")
        ElseIf formName = "FormSampleStockOpname" Then
            'Accounting List PR
            print(FormSampleStockOpname.GCSOWH, "List Stock Opname")
        ElseIf formName = "FormSalesWeekly" Then
            'SALES MONTHLY/WEEKLY
            If FormSalesWeekly.XTCPOS.SelectedTabPageIndex = 0 Then
                'modify period
                Dim period_from As String = ""
                Dim period_until As String = ""
                If FormSalesWeekly.date_from_selected = "0000-01-01" Then
                    period_from = "-"
                Else
                    period_from = DateTime.Parse(FormSalesWeekly.date_from_selected).ToString("dd MMM yyyy")
                End If
                If FormSalesWeekly.date_until_selected = "9999-01-01" Then
                    period_until = "-"
                Else
                    period_until = DateTime.Parse(FormSalesWeekly.date_until_selected).ToString("dd MMM yyyy")
                End If


                ReportSalesPosDaily.dt = FormSalesWeekly.dt
                Dim Report As New ReportSalesPosDaily()

                ' '... 
                ' ' creating and saving the view's layout to a new memory stream 
                Dim str As System.IO.Stream
                str = New System.IO.MemoryStream()
                FormSalesWeekly.GVSalesPOS.SaveLayoutToStream(str, DevExpress.Utils.OptionsLayoutBase.FullLayout)
                str.Seek(0, System.IO.SeekOrigin.Begin)
                Report.GridView1.RestoreLayoutFromStream(str, DevExpress.Utils.OptionsLayoutBase.FullLayout)
                str.Seek(0, System.IO.SeekOrigin.Begin)

                Dim str2 As System.IO.Stream
                str2 = New System.IO.MemoryStream()
                FormSalesWeekly.GVSalesPOSDet.SaveLayoutToStream(str2, DevExpress.Utils.OptionsLayoutBase.FullLayout)
                str2.Seek(0, System.IO.SeekOrigin.Begin)
                Report.GridView2.RestoreLayoutFromStream(str2, DevExpress.Utils.OptionsLayoutBase.FullLayout)
                str2.Seek(0, System.IO.SeekOrigin.Begin)
                ReportStyleGridview(Report.GridView1)

                If FormSalesWeekly.label_type_selected = "1" Then
                    Report.GridView1.AppearancePrint.Row.Font = New Font("Segoe UI", 7, FontStyle.Italic)
                ElseIf FormSalesWeekly.label_type_selected = "2" Then
                    Report.GridView1.AppearancePrint.Row.Font = New Font("Segoe UI", 7, FontStyle.Regular)
                End If


                'Grid Detail
                ReportStyleGridview(Report.GridView2)

                Report.LabelPeriod.Text = period_from + " / " + period_until
                Report.LabelWH.Text = FormSalesWeekly.label_store_selected



                '' Show the report's preview. 
                Dim Tool As DevExpress.XtraReports.UI.ReportPrintTool = New DevExpress.XtraReports.UI.ReportPrintTool(Report)
                Tool.ShowPreview()
            ElseIf FormSalesWeekly.XTCPOS.SelectedTabPageIndex = 1 Then
                'modify period
                Dim period_from As String = ""
                Dim period_until As String = ""
                If FormSalesWeekly.date_from_weekly_selected = "0000-01-01" Then
                    period_from = "-"
                Else
                    period_from = DateTime.Parse(FormSalesWeekly.date_from_weekly_selected).ToString("dd MMM yyyy")
                End If
                If FormSalesWeekly.date_until_weekly_selected = "9999-01-01" Then
                    period_until = "-"
                Else
                    period_until = DateTime.Parse(FormSalesWeekly.date_until_weekly_selected).ToString("dd MMM yyyy")
                End If

                '... 
                ' creating and saving the view's layout to a new memory stream 
                Dim str As System.IO.Stream
                str = New System.IO.MemoryStream()
                FormSalesWeekly.BGVSalesPOSWeekly.SaveLayoutToStream(str, DevExpress.Utils.OptionsLayoutBase.FullLayout)
                str.Seek(0, System.IO.SeekOrigin.Begin)
                ReportSalesPOSWeekly.dt = FormSalesWeekly.dt_weekly
                Dim Report As New ReportSalesPOSWeekly()
                Report.BandedGridView1.RestoreLayoutFromStream(str, DevExpress.Utils.OptionsLayoutBase.FullLayout)
                str.Seek(0, System.IO.SeekOrigin.Begin)

                Report.LabelPeriod.Text = period_from + " / " + period_until
                Report.LabelBegin.Text = FormSalesWeekly.day_weekly_selected

                ReportStyleBanded(Report.BandedGridView1)

                ' Show the report's preview. 
                Dim Tool As DevExpress.XtraReports.UI.ReportPrintTool = New DevExpress.XtraReports.UI.ReportPrintTool(Report)
                Tool.ShowPreview()
            ElseIf FormSalesWeekly.XTCPOS.SelectedTabPageIndex = 2 Then
                'modify period


                '... 
                ' creating and saving the view's layout to a new memory stream 
                Dim str As System.IO.Stream
                str = New System.IO.MemoryStream()
                FormSalesWeekly.BGVSalesPOSMonthly.SaveLayoutToStream(str, DevExpress.Utils.OptionsLayoutBase.FullLayout)
                str.Seek(0, System.IO.SeekOrigin.Begin)
                ReportSalesPOSMonthly.dt = FormSalesWeekly.dt_monthly
                Dim Report As New ReportSalesPOSMonthly()
                Report.BandedGridView1.RestoreLayoutFromStream(str, DevExpress.Utils.OptionsLayoutBase.FullLayout)
                str.Seek(0, System.IO.SeekOrigin.Begin)
                Report.LabelPeriod.Text = FormSalesWeekly.label_from_monthly_selected + "/" + FormSalesWeekly.label_until_monthly_selected

                ReportStyleBanded(Report.BandedGridView1)

                ' Show the report's preview. 
                Dim Tool As DevExpress.XtraReports.UI.ReportPrintTool = New DevExpress.XtraReports.UI.ReportPrintTool(Report)
                Tool.ShowPreview()
            End If
        ElseIf formName = "FormSalesCreditNote" Then
            'CREDIT NOTE
            print(FormSalesCreditNote.GCSalesPOS, "Credit Note")
        ElseIf formName = "FormSOH" Then
            'SOH
            print(FormSOH.GCSOH, "SOH Compare")
        ElseIf formName = "FormSOHPeriode" Then
            'SOH Periode
            print(FormSOHPeriode.GCSOHPeriode, "SOH Periode")
        ElseIf formName = "FormSOHSum" Then
            'SOH Periode
            print(FormSOHSum.GCSumSOH, "SOH Summary")
        ElseIf formName = "FormSOHPrice" Then
            'SOH Price
            print(FormSOHPrice.GCSOHPeriode, "SOH Price Range")
        ElseIf formName = "FormFGWoff" Then
            'Write OFF
            print(FormFGWoff.GCFGWoff, "Write Off Finished Goods")
        ElseIf formName = "FormFGWoffList" Then
            'Write Off LIst
            Cursor = Cursors.WaitCursor
            '... 
            ' creating and saving the view's layout to a new memory stream 
            Dim str As System.IO.Stream
            str = New System.IO.MemoryStream()
            FormFGWoffList.BGVFGStock.SaveLayoutToStream(str, DevExpress.Utils.OptionsLayoutBase.FullLayout)
            str.Seek(0, System.IO.SeekOrigin.Begin)
            ReportFGWoffList.dt = FormFGWoffList.GCFGStock.DataSource
            Dim Report As New ReportFGWoffList()
            Report.BandedGridView1.RestoreLayoutFromStream(str, DevExpress.Utils.OptionsLayoutBase.FullLayout)
            str.Seek(0, System.IO.SeekOrigin.Begin)

            Report.LabelProduct.Text = FormFGWoffList.label_design_selected_stock_sum
            Report.LabelPeriod.Text = FormFGWoffList.label_date_until_selected_stock_sum

            ReportStyleBanded(Report.BandedGridView1)

            ' Show the report's preview. 
            Dim Tool As DevExpress.XtraReports.UI.ReportPrintTool = New DevExpress.XtraReports.UI.ReportPrintTool(Report)
            Tool.ShowPreview()
            Cursor = Cursors.Default
        ElseIf formName = "FormFGProposePrice" Then
            'FormFGProposePrice
            print(FormFGProposePrice.GCFGPropose, "Propose Price")
        ElseIf formName = "FormFGLineList" Then
            'LINE LIST
            Cursor = Cursors.WaitCursor
            print(FormFGLineList.GCLineList, FormFGLineList.SLESeason.Text.ToString.ToUpper + " LINE LIST" + System.Environment.NewLine + "TYPE : " + FormFGLineList.SLETypeLineList.Text.ToUpper)
            'If FormFGLineList.BGVLineList.RowCount > 0 Then
            '    '... 
            '    ' creating and saving the view's layout to a new memory stream 
            '    Dim str As System.IO.Stream
            '    str = New System.IO.MemoryStream()
            '    FormFGLineList.BGVLineList.SaveLayoutToStream(str, DevExpress.Utils.OptionsLayoutBase.FullLayout)
            '    str.Seek(0, System.IO.SeekOrigin.Begin)
            '    ReportFGLineList.dt = FormFGLineList.GCLineList.DataSource
            '    ReportFGLineList.img_cond = FormFGLineList.CheckImg.EditValue
            '    Dim Report As New ReportFGLineList()
            '    Report.AdvBandedGridView1.RestoreLayoutFromStream(str, DevExpress.Utils.OptionsLayoutBase.FullLayout)
            '    str.Seek(0, System.IO.SeekOrigin.Begin)


            '    Report.LabelSeason.Text = FormFGLineList.SLESeason.Text.ToString
            '    Report.LabelType.Text = FormFGLineList.SLETypeLineList.Text.ToString
            '    ReportStyleBanded(Report.AdvBandedGridView1)
            '    Report.AdvBandedGridView1.AppearancePrint.HeaderPanel.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap

            '    ' Show the report's preview. 
            '    Dim Tool As DevExpress.XtraReports.UI.ReportPrintTool = New DevExpress.XtraReports.UI.ReportPrintTool(Report)
            '    Tool.ShowPreview()
            'End If
            Cursor = Cursors.Default
        ElseIf formName = "FormMasterRetCode" Then
            print(FormMasterRetCode.GCRetCode, "Return Code")
        ElseIf formName = "FormMasterRateStore" Then
            print(FormMasterRateStore.GCStoreRate, "Rate Store")
        ElseIf formName = "FormFGProdList" Then
            'Product List for Production Dept
            print(FormFGProdList.GCProdList, "Product List - " + FormFGProdList.SLESeason.Text.ToString + "")
        ElseIf formName = "FormBarcodeProduct" Then
            If FormBarcodeProduct.GVProdList.RowCount > 0 Then
                If Not FormBarcodeProduct.GVProdList.IsGroupRow(FormBarcodeProduct.GVProdList.FocusedRowHandle) Then
                    FormBarcodeProductPrint.id_product = FormBarcodeProduct.GVProdList.GetFocusedRowCellValue("id_product").ToString
                    FormBarcodeProductPrint.ShowDialog()
                End If
            End If
        ElseIf formName = "FormMasterDesignCOP" Then
            'Product List for Production Dept
            print(FormMasterDesignCOP.GCDesign, "List Design COP")
        ElseIf formName = "FormSampleOrdered" Then
            'SAMPLE ORDERD
            print(FormSampleOrdered.GCSampleOrder, "Sample Order List")
        ElseIf formName = "FormFGDistScheme" Then
            'DISTRIBUTION SCHEME
            print(FormFGDistScheme.GCDS, "DISTRIBUTION SCHEME - SEASON : " + FormFGDistScheme.SLESeason.Text + " - TYPE : " + FormFGDistScheme.SLEType.Text.ToUpper + "")
        ElseIf formName = "FormProdQCAdj" Then
            If FormProdQCAdj.XTCAdj.SelectedTabPageIndex = 0 Then 'QC adj in
                print(FormProdQCAdj.GCAdjIn, "List QC Adjustment In")
            Else
                print(FormProdQCAdj.GCAdjOut, "List QC Adjustment Out")
            End If
        ElseIf formName = "FormSalesPromo" Then
            'Sales Promo
            print(FormSalesPromo.GCSalesPOS, "List Invoice Sales Promo Marketing")
        ElseIf formName = "FormFGSalesOrderReff" Then
            'SAMPLE ORDERD
            print(FormFGSalesOrderReff.GCSOReff, "Analysis of New Product Order List")
        ElseIf formName = "FormSalesOrderList" Then
            'PREPARE ORDER LIST
            If FormSalesOrderList.XTCWHMonitor.SelectedTabPageIndex = 0 Then
                If FormSalesOrderList.XTCPrepareList.SelectedTabPageIndex = 0 Then
                    print(FormSalesOrderList.GCSalesOrder, "Prepare Order List")
                ElseIf FormSalesOrderList.XTCPrepareList.SelectedTabPageIndex = 1 Then
                    print(FormSalesOrderList.GCSalesOrderHist, "Prepare Order History : " + FormSalesOrderList.DateEditFrom.Text + "-" + FormSalesOrderList.DateEditUntil.Text)
                End If
            ElseIf FormSalesOrderList.XTCWHMonitor.SelectedTabPageIndex = 1 Then
                print(FormSalesOrderList.GCNewPrepare, "Prepare Order New Product : " + FormSalesOrderList.TxtNoParam.Text)
            End If
        ElseIf formName = "FormSalesOrderSvcLevel" Then
            'SERVICE LEVEL
            If FormSalesOrderSvcLevel.XTCSvcLevel.SelectedTabPageIndex = 0 Then
                'PREPARE ORDER
                Dim awal As String = FormSalesOrderSvcLevel.DEFrom.Text
                If awal = "" Then
                    awal = "-"
                End If
                Dim akhir As String = FormSalesOrderSvcLevel.DEUntil.Text
                If akhir = "" Then
                    akhir = "-"
                End If
                Dim period As String = "Period : " + awal + " until " + akhir
                print(FormSalesOrderSvcLevel.GCSalesOrder, "Prepare Order" + System.Environment.NewLine + period)
            ElseIf FormSalesOrderSvcLevel.XTCSvcLevel.SelectedTabPageIndex = 1 Then
                'RETURN ORDER
                Dim awal As String = FormSalesOrderSvcLevel.DEFromRet.Text
                If awal = "" Then
                    awal = "-"
                End If
                Dim akhir As String = FormSalesOrderSvcLevel.DEUntilRet.Text
                If akhir = "" Then
                    akhir = "-"
                End If
                Dim period As String = "Period : " + awal + " until " + akhir
                print(FormSalesOrderSvcLevel.GCSalesReturnOrder, "Return Order" + System.Environment.NewLine + period)
            ElseIf FormSalesOrderSvcLevel.XTCSvcLevel.SelectedTabPageIndex = 2 Then
                'RECEIVED
                Dim awal As String = FormSalesOrderSvcLevel.DEFromRec.Text
                If awal = "" Then
                    awal = "-"
                End If
                Dim akhir As String = FormSalesOrderSvcLevel.DEUntilRec.Text
                If akhir = "" Then
                    akhir = "-"
                End If
                Dim period As String = "Period : " + awal + " until " + akhir
                print(FormSalesOrderSvcLevel.GCPL, "Received Product" + System.Environment.NewLine + period)
            ElseIf FormSalesOrderSvcLevel.XTCSvcLevel.SelectedTabPageIndex = 3 Then
                'DO
                Dim awal As String = FormSalesOrderSvcLevel.DEFromDO.Text
                If awal = "" Then
                    awal = "-"
                End If
                Dim akhir As String = FormSalesOrderSvcLevel.DEUntilDO.Text
                If akhir = "" Then
                    akhir = "-"
                End If
                Dim period As String = "Period : " + awal + " until " + akhir
                print(FormSalesOrderSvcLevel.GCSalesDelOrder, "Delivery Order" + System.Environment.NewLine + period)
            ElseIf FormSalesOrderSvcLevel.XTCSvcLevel.SelectedTabPageIndex = 4 Then
                'RETURN
                Dim awal As String = FormSalesOrderSvcLevel.DEFromReturn.Text
                If awal = "" Then
                    awal = "-"
                End If
                Dim akhir As String = FormSalesOrderSvcLevel.DEUntilReturn.Text
                If akhir = "" Then
                    akhir = "-"
                End If
                Dim period As String = "Period : " + awal + " until " + akhir
                print(FormSalesOrderSvcLevel.GCSalesReturn, "Return" + System.Environment.NewLine + period)
            ElseIf FormSalesOrderSvcLevel.XTCSvcLevel.SelectedTabPageIndex = 5 Then
                'RETURN QC
                Dim awal As String = FormSalesOrderSvcLevel.DEFromReturnQC.Text
                If awal = "" Then
                    awal = "-"
                End If
                Dim akhir As String = FormSalesOrderSvcLevel.DEUntilReturnQC.Text
                If akhir = "" Then
                    akhir = "-"
                End If
                Dim period As String = "Period : " + awal + " until " + akhir
                print(FormSalesOrderSvcLevel.GCSalesReturnQC, "Return QC" + System.Environment.NewLine + period)
            ElseIf FormSalesOrderSvcLevel.XTCSvcLevel.SelectedTabPageIndex = 6 Then
                'TRF
                Dim awal As String = FormSalesOrderSvcLevel.DEFromTrf.Text
                If awal = "" Then
                    awal = "-"
                End If
                Dim akhir As String = FormSalesOrderSvcLevel.DEUntilTrf.Text
                If akhir = "" Then
                    akhir = "-"
                End If
                Dim period As String = "Period : " + awal + " until " + akhir
                print(FormSalesOrderSvcLevel.GCFGTrf, "Transfer" + System.Environment.NewLine + period)
            End If
        ElseIf formName = "FormMasterComputer" Then
            'MASTER COMPUTER
            print(FormMasterComputer.GCComputer, "COMPUTER INFO")
        ElseIf formName = "FormAccountingFakturScan" Then
            'FAKTUR SCAN
            print(FormAccountingFakturScan.GCFak, "FAKTUR SCAN")
        ElseIf formName = "FormFGBorrowQCReq" Then
            'BORRWOW REQ FOR QC FG
            print(FormFGBorrowQCReq.GCBorrowReq, "BORROW REQUEST FOR QC PRODUCT")
        ElseIf formName = "FormWHAWBill" Then
            'AWBill
            If FormWHAWBill.XTCAwb.SelectedTabPageIndex = 0 Then
                print(FormWHAWBill.GCAWBill, "Outbound Delivery")
            Else
                print(FormWHAWBill.GCAwbillIn, "Inbound Delivery")
            End If
        ElseIf formName = "FormMasterPrice" Then
            'MASTER PRICE
            If FormMasterPrice.XTCPrice.SelectedTabPageIndex = 0 Then
                print(FormMasterPrice.GCBrowsePrice, "MASTER PRODUCT" + System.Environment.NewLine + "SEASON : " + FormMasterPrice.SLESeason.Text.ToUpper + " / " + "DEL : " + FormMasterPrice.SLEDel.Text.ToUpper + " / " + "DATE : " + FormMasterPrice.DEFrom.Text.ToUpper)
            ElseIf FormMasterPrice.XTCPrice.SelectedTabPageIndex = 1 Then
                print(FormMasterPrice.GCPrice, "IMPORT PRICE FROM EXCEL")
            End If
        ElseIf formName = "FormWHImportDO" Then
            'IMPOT DO
            print(FormWHImportDO.GCImportDO, "DELIVERY ORDER LIST")
        ElseIf formName = "FormFGDesignList" Then
            'DESIGN LIST
            print(FormFGDesignList.GCDesign, FormFGDesignList.SLESeason.Text.ToString.ToUpper)
        ElseIf formName = "FormWHSvcLevel" Then
            If FormWHSvcLevel.XTCSvcLelel.SelectedTabPageIndex = 0 Then
                print(FormWHSvcLevel.GCBySO, "SERVICE LEVEL BY PREPARE ORDER" + System.Environment.NewLine + "PERIOD : " + FormWHSvcLevel.DEFrom.Text + " - " + FormWHSvcLevel.DEUntil.Text)
            ElseIf FormWHSvcLevel.XTCSvcLelel.SelectedTabPageIndex = 1 Then
                print(FormWHSvcLevel.GCByCode, "SERVICE LEVEL BY CODE" + System.Environment.NewLine + "PERIOD : " + FormWHSvcLevel.DEFromCode.Text + " - " + FormWHSvcLevel.DEUntilCode.Text)
            ElseIf FormWHSvcLevel.XTCSvcLelel.SelectedTabPageIndex = 2 Then
                print(FormWHSvcLevel.GCByAcco, "SERVICE LEVEL BY ACCOUNT" + System.Environment.NewLine + "PERIOD : " + FormWHSvcLevel.DEFromAcc.Text + " - " + FormWHSvcLevel.DEUntilAcc.Text)
            End If
        ElseIf formName = "FormSamplePLToWH" Then
            'PL SAMPLE
            print(FormSamplePLToWH.GCSamplePL, "PACKING LIST SAMPLE")
        ElseIf formName = "FormMasterPriceSample" Then
            'MASTER PRICE SAMPLE
            If FormMasterPriceSample.XTCPrice.SelectedTabPageIndex = 0 Then
                print(FormMasterPriceSample.GCBrowsePrice, "MASTER SAMPLE PRICE" + System.Environment.NewLine + "SEASON : " + FormMasterPriceSample.SLESeason.Text.ToUpper + " / " + "DATE : " + FormMasterPriceSample.DEFrom.Text.ToUpper)
            ElseIf FormMasterPriceSample.XTCPrice.SelectedTabPageIndex = 1 Then
                print(FormMasterPriceSample.GCPrice, "IMPORT SAMPLE PRICE FROM EXCEL")
            End If
        ElseIf formName = "FormSamplePLExport" Then
            print(FormSamplePLExport.GCSample, "PACKING LIST DETAIL")
        ElseIf formName = "FormFGWHAlloc" Then
            print(FormFGWHAlloc.GCFGWHAlloc, "INVENTORY ALLOCATION")
        ElseIf formName = "FormFGWHAllocLog" Then
            FormFGWHAllocLog.ActiveControl = Nothing
            print(FormFGWHAllocLog.GCFGWHAlloc, "INVENTORY ALLOCATION LOG" + System.Environment.NewLine + FormFGWHAllocLog.DEFrom.Text + " - " + FormFGWHAllocLog.DEUntil.Text)
        ElseIf formName = "FormSampleReturnPL" Then
            print(FormSampleReturnPL.GCSamplePL, "RETURN TO WH LIST")
        ElseIf formName = "FormWHCargoRate" Then
            If FormWHCargoRate.XTCRate.SelectedTabPageIndex = 0 Then
                print(FormWHCargoRate.GCCompany, "Cargo Rate Outbound")
            Else
                print(FormWHCargoRate.GCCompanyIn, "Cargo Rate Inbound")
            End If
        ElseIf formName = "FormEmpShift" Then
            print(FormEmpShift.GCShift, "Template Shift")
        ElseIf formName = "FormEmpAttnInd" Then
            print(FormEmpAttnInd.GCEmployee, "Employee List")
        ElseIf formName = "FormEmpHoliday" Then
            If FormEmpHoliday.XTCHoliday.SelectedTabPageIndex = 0 Then
                print(FormEmpHoliday.GCHoliday, "Holiday List")
            Else
                print(FormEmpHoliday.GCSum, "Holiday List")
            End If
        ElseIf formName = "FormFGRepair" Then
            print(FormFGRepair.GCRepair, "Repair Product")
        ElseIf formName = "FormFGRepairRec" Then
            print(FormFGRepairRec.GCRepairRec, "Receive Repair Product")
        ElseIf formName = "FormFGRepairReturn" Then
            print(FormFGRepairReturn.GCRepairReturn, "Return Repair Product")
        ElseIf formName = "FormFGRepairReturnRec" Then
            print(FormFGRepairReturnRec.GCRepairRec, "Receive Repair Product (WH)")
        ElseIf formName = "FormEmpEmail" Then
            FormEmpEmail.GVEmail.ActiveFilterString = "Not IsNullOrEmpty([email_lokal]) Or Not IsNullOrEmpty([email_external]) OR Not IsNullOrEmpty([email_other])"
            print(FormEmpEmail.GCEmail, "Email List")
            FormEmpEmail.GVEmail.ActiveFilterString = ""
        ElseIf formName = "FormEmpLeave" Then
            print(FormEmpLeave.GCLeave, "List Cuti")
        ElseIf formName = "FormEmpDP" Then
            print(FormEmpDP.GCLeave, "List DP")
        ElseIf formName = "FormProductionSummary" Then
            If FormProductionSummary.XTCSum.SelectedTabPageIndex = 0 Then
                print(FormProductionSummary.GCDesign, "APPROVED ORDER")
            ElseIf FormProductionSummary.XTCSum.SelectedTabPageIndex = 1 Then
                print(FormProductionSummary.GCDesign, "APPROVED ORDER")
            End If
        Else
            RPSubMenu.Visible = False
        End If
        Cursor = Cursors.Default
    End Sub
    'Close Menu
    Private Sub BBClose_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles BBClose.ItemClick
        If formName = "FormMasterArea" Then
            FormMasterArea.Close()
        ElseIf formName = "FormMasterCompany" Then
            '
            FormMasterCompany.Close()
        ElseIf formName = "FormMasterCompanyCategory" Then
            '
            FormMasterCompanyCategory.Close()
        ElseIf formName = "FormMasterDepartement" Then
            '
            FormMasterDepartement.Close()
        ElseIf formName = "FormMasterRawMaterialCat" Then
            '
            FormMasterRawMaterialCat.Close()
            FormMasterRawMaterialCat.Dispose()
        ElseIf formName = "FormMasterItemColor" Then
            '
            FormMasterItemColor.Close()
            FormMasterItemColor.Dispose()
        ElseIf formName = "FormMasterItemSize" Then
            '
            FormMasterItemSize.Close()
            FormMasterItemSize.Dispose()
        ElseIf formName = "FormMasterUser" Then
            '
            FormMasterUser.Close()
        ElseIf formName = "FormSeason" Then
            '
            FormSeason.Close()
            FormSeason.Dispose()
        ElseIf formName = "FormMasterUOM" Then
            '
            FormMasterUOM.Close()
            FormMasterUOM.Dispose()
        ElseIf formName = "FormMasterRawMaterial" Then
            '
            FormMasterRawMaterial.Close()
            FormMasterRawMaterial.Dispose()
        ElseIf formName = "FormSetupRawMatCode" Then
            FormSetupRawMatCode.Close()
            FormMasterRawMat.Dispose()
        ElseIf formName = "FormMasterOVH" Then
            FormMasterOVH.Close()
            FormMasterOVH.Dispose()
        ElseIf formName = "FormProdDemand" Then
            FormProdDemand.Close()
            FormProdDemand.Dispose()
        ElseIf formName = "FormMasterCode" Then
            '
            FormMasterCode.Close()
            FormMasterCode.Dispose()
        ElseIf formName = "FormTemplateCode" Then
            FormTemplateCode.Close()
            FormTemplateCode.Dispose()
        ElseIf formName = "FormMasterProduct" Then
            '
            FormMasterProduct.Close()
            FormMasterProduct.Dispose()
        ElseIf formName = "FormMasterSample" Then
            '
            FormMasterSample.Close()
            FormMasterSample.Dispose()
        ElseIf formName = "FormBOM" Then
            '
            FormBOM.Close()
            FormBOM.Dispose()
        ElseIf formName = "FormAccess" Then
            '
            FormAccess.Close()
            FormAccess.Dispose()
        ElseIf formName = "FormSamplePL" Then
            'PACKING LIST SAMPLE
            FormSamplePL.Close()
            FormSamplePL.Dispose()
        ElseIf formName = "FormSamplePLDel" Then
            'PACKING LIST SAMPLE Del
            FormSamplePLDel.Close()
            FormSamplePLDel.Dispose()
        ElseIf formName = "FormSamplePurchase" Then
            '
            FormSamplePurchase.Close()
            FormSamplePurchase.Dispose()
        ElseIf formName = "FormSampleReceive" Then
            '
            FormSampleReceive.Close()
            FormSampleReceive.Dispose()
        ElseIf formName = "FormMasterWH" Then
            'WAREHOUSE & LOCATOR
            FormMasterWH.Close()
            FormMasterWH.Dispose()
        ElseIf formName = "FormSampleReceipt" Then
            'Receipt Sample
            FormSampleReceipt.Close()
            FormSampleReceipt.Dispose()
        ElseIf formName = "FormSampleRet" Then
            'RETURN SAMPLE
            FormSampleRet.Close()
            FormSampleRet.Dispose()
        ElseIf formName = "FormSampleReq" Then
            'REQ SAMPLE
            FormSampleReq.Close()
            FormSampleReq.Dispose()
        ElseIf formName = "FormMarkAssign" Then
            'Assign mark
            FormMarkAssign.Close()
            FormMarkAssign.Dispose()
        ElseIf formName = "FormSamplePlan" Then
            'Planning Sample
            FormSamplePlan.Close()
            FormSamplePlan.Dispose()
        ElseIf formName = "FormWork" Then
            'Work
            FormWork.Close()
            FormWork.Dispose()
        ElseIf formName = "FormMatPurchase" Then
            'Material Purchase
            FormMatPurchase.Close()
            FormMatPurchase.Dispose()
        ElseIf formName = "FormMatWO" Then
            'Material Purchase
            FormMatWO.Close()
            FormMatWO.Dispose()
        ElseIf formName = "FormMatRecPurc" Then
            'Receive Purchase Material
            FormMatRecPurc.Close()
            FormMatRecPurc.Dispose()
        ElseIf formName = "FormMatRecWO" Then
            'Receive WO Material
            FormMatRecWO.Close()
            FormMatRecWO.Dispose()
        ElseIf formName = "FormMatRet" Then
            'Return Mat
            FormMatRet.Close()
            FormMatRet.Dispose()
        ElseIf formName = "FormSampleReturn" Then
            'Sample Return
            FormSampleReturn.Close()
            FormSampleReturn.Dispose()
        ElseIf formName = "FormSampleAdjustment" Then
            'Sample Adjustment
            FormSampleAdjustment.Close()
            FormSampleAdjustment.Dispose()
        ElseIf formName = "FormMatAdj" Then
            'Mat Adjustment
            FormMatAdj.Close()
            FormMatAdj.Dispose()
        ElseIf formName = "FormMatPR" Then
            'PR PO Material
            FormMatPR.Close()
            FormMatPR.Dispose()
        ElseIf formName = "FormMatPRWO" Then
            'PR WO Material
            FormMatPRWO.Close()
            FormMatPRWO.Dispose()
        ElseIf formName = "FormProduction" Then
            'Form Production
            FormProduction.Close()
            FormProduction.Dispose()
        ElseIf formName = "FormMatPL" Then
            'Material Packing List
            FormMatPL.Close()
            FormMatPL.Dispose()
        ElseIf formName = "FormMatMRS" Then
            'Material Requisition
            FormMatMRS.Close()
            FormMatMRS.Dispose()
        ElseIf formName = "FormProductionRec" Then
            'Form Production Rec QC
            FormProductionRec.Close()
            FormProductionRec.Dispose()
        ElseIf formName = "FormProductionRet" Then
            'Return FG
            FormProductionRet.Close()
            FormProductionRet.Dispose()
        ElseIf formName = "FormProductionPLToWH" Then
            'PL To WH
            FormProductionPLToWH.Close()
            FormProductionPLToWH.Dispose()
        ElseIf formName = "FormMatInvoice" Then
            'Invoice material PL
            FormMatInvoice.Close()
            FormMatInvoice.Dispose()
        ElseIf formName = "FormAccounting" Then
            FormAccounting.Close()
            FormAccounting.Dispose()
        ElseIf formName = "FormProductionPLToWHRec" Then
            'Rec PL To WH
            FormProductionPLToWHRec.Close()
            FormProductionPLToWHRec.Dispose()
        ElseIf formName = "FormSalesTarget" Then
            'SALEES TARGET
            FormSalesTarget.Close()
            FormSalesTarget.Dispose()
        ElseIf formName = "FormSalesOrder" Then
            'SALEES ORDER
            FormSalesOrder.Close()
            FormSalesOrder.Dispose()
        ElseIf formName = "FormSalesDelOrder" Then
            FormSalesDelOrder.Close()
            FormSalesDelOrder.Dispose()
        ElseIf formName = "FormSalesReturnOrder" Then
            'SALEES RETURN ORDER
            FormSalesReturnOrder.Close()
            FormSalesReturnOrder.Dispose()
        ElseIf formName = "FormSalesReturn" Then
            'SALES RETURN
            FormSalesReturn.Close()
            FormSalesReturn.Dispose()
        ElseIf formName = "FormSalesPOS" Then
            'SALES POS
            FormSalesPOS.Close()
            FormSalesPOS.Dispose()
        ElseIf formName = "FormSalesReturnQC" Then
            'SALES RETURN QC
            FormSalesReturnQC.Close()
            FormSalesReturnQC.Dispose()
        ElseIf formName = "FormAccountingJournal" Then
            'Journal
            FormAccountingJournal.Close()
            FormAccountingJournal.Dispose()
        ElseIf formName = "FormAccountingJournalAdj" Then
            'Adjustment Journal
            FormAccountingJournalAdj.Close()
            FormAccountingJournalAdj.Dispose()
        ElseIf formName = "FormProdPRWO" Then
            'Rec PL To WH
            FormProdPRWO.Close()
            FormProdPRWO.Dispose()
        ElseIf formName = "FormSalesInvoice" Then
            'SALES INVOICE
            FormSalesInvoice.Close()
            FormSalesInvoice.Dispose()
        ElseIf formName = "FormFGStockOpnameStore" Then
            'STORE STOCK OPNAME
            FormFGStockOpnameStore.Close()
            FormFGStockOpnameStore.Dispose()
        ElseIf formName = "FormFGMissing" Then
            'FG MISSING
            FormFGMissing.Close()
            FormFGMissing.Dispose()
        ElseIf formName = "FormFGMissingInvoice" Then
            'FG Missing INVOICE
            FormFGMissingInvoice.Close()
            FormFGMissingInvoice.Dispose()
        ElseIf formName = "FormFGStockOpnameWH" Then
            'WH STOCK OPNAME
            FormFGStockOpnameWH.Close()
            FormFGStockOpnameWH.Dispose()
        ElseIf formName = "FormMatStockOpname" Then
            'Material Stock Opname
            FormMatStockOpname.Close()
            FormMatStockOpname.Dispose()
        ElseIf formName = "FormFGAdj" Then
            'FG Adjustment
            FormFGAdj.Close()
            FormFGAdj.Dispose()
        ElseIf formName = "FormFGTrf" Then
            'FG Transfer Future
            FormFGTrf.Close()
            FormFGTrf.Dispose()
        ElseIf formName = "FormFGTrfNew" Then
            'FG Transfer
            FormFGTrfNew.Close()
            FormFGTrfNew.Dispose()
        ElseIf formName = "FormFGTrfReceive" Then
            'FG Transfer
            FormFGTrfReceive.Close()
            FormFGTrfReceive.Dispose()
        ElseIf formName = "FormFGTracking" Then
            'FG TRACKING
            FormFGTracking.Close()
            FormFGTracking.Dispose()
        ElseIf formName = "FormFGStock" Then
            'FG STOCK
            FormFGStock.Close()
            FormFGStock.Dispose()
        ElseIf formName = "FormMatStock" Then
            'Mat STOCK
            FormMatStock.Close()
            FormMatStock.Dispose()
        ElseIf formName = "FormAccountingSummary" Then
            'Summary Accounting
            FormAccountingSummary.Close()
            FormAccountingSummary.Dispose()
        ElseIf formName = "FormAccountingFYear" Then
            'Financial Year Accounting
            FormAccountingFYear.Close()
            FormAccountingFYear.Dispose()
        ElseIf formName = "FormSampleStock" Then
            'Sample Stock
            FormSampleStock.Close()
            FormSampleStock.Dispose()
        ElseIf formName = "FormMasterEmployee" Then
            'Master Employee
            FormMasterEmployee.Close()
            FormMasterEmployee.Dispose()
        ElseIf formName = "FormSampleDel" Then
            'PL Sample Delivery
            FormSampleDel.Close()
            FormSampleDel.Dispose()
        ElseIf formName = "FormSampleDelRec" Then
            'REC PL Sample Delivery
            FormSampleDelRec.Close()
            FormSampleDelRec.Dispose()
        ElseIf formName = "FormSamplePrintBarcode" Then
            FormSamplePrintBarcode.Close()
            FormSamplePrintBarcode.Dispose()
        ElseIf formName = "FormSampleOrder" Then
            'SALES ORDER SAMPLE
            FormSampleOrder.Close()
            FormSampleOrder.Dispose()
        ElseIf formName = "FormSampleDelOrder" Then
            'DELIVERY ORDER SAMPLE
            FormSampleDelOrder.Close()
            FormSampleDelOrder.Dispose()
        ElseIf formName = "FormSampleStockOpname" Then
            'SAMPLE SO
            FormSampleStockOpname.Close()
            FormSampleStockOpname.Dispose()
        ElseIf formName = "FormAccountingListPR" Then
            'LIST PR ACCOUNTING
            FormAccountingListPR.Close()
            FormAccountingListPR.Dispose()
        ElseIf formName = "FormFGCodeReplace" Then
            'CODE REPLACEMENT
            FormFGCodeReplace.Close()
            FormFGCodeReplace.Dispose()
        ElseIf formName = "FormSalesWeekly" Then
            'CODE REPLACEMENT
            FormSalesWeekly.Close()
            FormSalesWeekly.Dispose()
        ElseIf formName = "FormSalesCreditNote" Then
            'CREDITN NOTE
            FormSalesCreditNote.Close()
            FormSalesCreditNote.Dispose()
        ElseIf formName = "FormFGMissingCreditNote" Then
            'MISSING CREDIT NOTE
            FormFGMissingCreditNote.Close()
            FormFGMissingCreditNote.Dispose()
        ElseIf formName = "FormSOH" Then
            'SOH
            FormSOH.Close()
            FormSOH.Dispose()
        ElseIf formName = "FormSOHPeriode" Then
            'SOH Periode
            FormSOHPeriode.Close()
            FormSOHPeriode.Dispose()
        ElseIf formName = "FormSOHSum" Then
            'SOH Periode
            FormSOHSum.Close()
            FormSOHSum.Dispose()
        ElseIf formName = "FormSOHPrice" Then
            'SOH Price
            FormSOHPrice.Close()
            FormSOHPrice.Dispose()
        ElseIf formName = "FormFGWoff" Then
            ' Write Off Finished Goods
            FormFGWoff.Close()
            FormFGWoff.Dispose()
        ElseIf formName = "FormFGWoffList" Then
            ' WRITE OFF LIST FG
            FormFGWoffList.Close()
            FormFGWoffList.Dispose()
        ElseIf formName = "FormFGProposePrice" Then
            'PROPOSE PRICE
            FormFGProposePrice.Close()
            FormFGProposePrice.Dispose()
        ElseIf formName = "FormFGLineList" Then
            'LINE LIST
            FormFGLineList.Close()
            FormFGLineList.Dispose()
        ElseIf formName = "FormFGDistSchemaSetup" Then
            'DIST SCHEMA SETUP
            FormFGDistSchemaSetup.Close()
            FormFGDistSchemaSetup.Dispose()
        ElseIf formName = "FormMasterRetCode" Then
            'MASTER RETURN CODE
            FormMasterRetCode.Close()
            FormMasterRetCode.Dispose()
        ElseIf formName = "FormMasterRateStore" Then
            'MASTER RATE STORE
            FormMasterRateStore.Close()
            FormMasterRateStore.Dispose()
        ElseIf formName = "FormFGProdList" Then
            FormFGProdList.Close()
            FormFGProdList.Dispose()
        ElseIf formName = "FormBarcodeProduct" Then
            FormBarcodeProduct.Close()
            FormBarcodeProduct.Dispose()
        ElseIf formName = "FormMasterDesignCOP" Then
            FormMasterDesignCOP.Close()
            FormMasterDesignCOP.Dispose()
        ElseIf formName = "" Then
            'SAMPLE ORDER
            FormSampleOrdered.Close()
            FormSampleOrdered.Dispose()
        ElseIf formName = "FormFGDistScheme" Then
            'DISTRIBUTION SCHEME
            FormFGDistScheme.Close()
            FormFGDistScheme.Dispose()
        ElseIf formName = "FormProdQCAdj" Then
            'QC Adj 
            FormProdQCAdj.Close()
            FormProdQCAdj.Dispose()
        ElseIf formName = "FormFGSalesOrderReff" Then
            'Analaisis SO New
            FormFGSalesOrderReff.Close()
            FormFGSalesOrderReff.Dispose()
        ElseIf formName = "FormSalesPromo" Then
            'Sales Promo
            FormSalesPromo.Close()
            FormSalesPromo.Dispose()
        ElseIf formName = "FormSalesOrderList" Then
            'Prepare order
            FormSalesOrderList.Close()
            FormSalesOrderList.Dispose()
        ElseIf formName = "FormGuide" Then
            'USER GUIDE
            FormGuide.Close()
            FormGuide.Dispose()
        ElseIf formName = "FormMasterComputer" Then
            'MASTER COMPUTER
            FormMasterComputer.Close()
            FormMasterComputer.Dispose()
        ElseIf formName = "FormNotification" Then
            'NOTIFICATION
            FormNotification.Close()
            FormNotification.Dispose()
        ElseIf formName = "FormAccountingFakturScan" Then
            'FAKTUR SCAN
            FormAccountingFakturScan.Close()
            FormAccountingFakturScan.Dispose()
        ElseIf formName = "FormFGBorrowQCReq" Then
            'BORROW REQ
            FormFGBorrowQCReq.Close()
            FormFGBorrowQCReq.Dispose()
        ElseIf formName = "FormWHAWBill" Then
            'AIRWAYS BILL
            FormWHAWBill.Close()
            FormWHAWBill.Dispose()
        ElseIf formName = "FormSalesOrderSvcLevel" Then
            'SERVICE LEVEL
            FormSalesOrderSvcLevel.Close()
            FormSalesOrderSvcLevel.Dispose()
        ElseIf formName = "FormMasterPrice" Then
            'MASTER PRICE FROM excel
            FormMasterPrice.Close()
            FormMasterPrice.Dispose()
        ElseIf formName = "FormMasterPriceSample" Then
            'MASTER PRICE SAMPLE FROM excel
            FormMasterPriceSample.Close()
            FormMasterPriceSample.Dispose()
        ElseIf formName = "FormWHImportDO" Then
            'Import DO
            FormWHImportDO.Close()
            FormWHImportDO.Dispose()
        ElseIf formName = "FormFGDesignList" Then
            'DESIGN LIST
            FormFGDesignList.Close()
            FormFGDesignList.Dispose()
        ElseIf formName = "FormWHSvcLevel" Then
            'SERVICE LEVEL
            FormWHSvcLevel.Close()
            FormWHSvcLevel.Dispose()
        ElseIf formName = "FormSamplePLToWH" Then
            'PL SAMPLE
            FormSamplePLToWH.Close()
            FormSamplePLToWH.Dispose()
        ElseIf formName = "FormSamplePLExport" Then
            FormSamplePLExport.Close()
            FormSamplePLExport.Dispose()
        ElseIf formName = "FormFGWHAlloc" Then
            FormFGWHAlloc.Close()
            FormFGWHAlloc.Dispose()
        ElseIf formName = "FormFGWHAllocLog" Then
            FormFGWHAllocLog.Close()
            FormFGWHAllocLog.Dispose()
        ElseIf formName = "FormSampleReturnPL" Then
            'RETURN INTERNAL SALE
            FormSampleReturnPL.Close()
            FormSampleReturnPL.Dispose()
        ElseIf formName = "FormWHCargoRate" Then
            'Cargo Rate
            FormWHCargoRate.Close()
            FormWHCargoRate.Dispose()
        ElseIf formName = "FormEmpFP" Then
            FormEmpFP.Close()
            FormEmpFP.Dispose()
        ElseIf formName = "FormEmpShift" Then
            'Employee Shift
            FormEmpShift.Close()
            FormEmpShift.Dispose()
        ElseIf formName = "FormEmpSchedule" Then
            'Employee Shift
            FormEmpSchedule.Close()
            FormEmpSchedule.Dispose()
        ElseIf formName = "FormEmpAttnInd" Then
            'Employee Attn Report Individual
            FormEmpAttnInd.Close()
            FormEmpAttnInd.Dispose()
        ElseIf formName = "FormEmpAttnSum" Then
            'Employee Attn Report Summary
            FormEmpAttnSum.Close()
            FormEmpAttnSum.Dispose()
        ElseIf formName = "FormEmpReview" Then
            FormEmpReview.Close()
            FormEmpReview.Dispose()
        ElseIf formName = "FormEmpHoliday" Then
            'Employee Holiday
            FormEmpHoliday.Close()
            FormEmpHoliday.Dispose()
        ElseIf formName = "FormFGRepair" Then
            FormFGRepair.Close()
            FormFGRepair.Dispose()
        ElseIf formName = "FormFGRepairRec" Then
            FormFGRepairRec.Close()
            FormFGRepairRec.Dispose()
        ElseIf formName = "FormFGRepairReturn" Then
            FormFGRepairReturn.Close()
            FormFGRepairReturn.Dispose()
        ElseIf formName = "FormFGRepairReturnRec" Then
            FormFGRepairReturnRec.Close()
            FormFGRepairReturnRec.Dispose()
        ElseIf formName = "FormEmpEmail" Then
            FormEmpEmail.Close()
            FormEmpEmail.Dispose()
        ElseIf formName = "FormEmpDP" Then
            FormEmpDP.Close()
            FormEmpDP.Dispose()
        ElseIf formName = "FormEmpLeave" Then
            FormEmpLeave.Close()
            FormEmpLeave.Dispose()
        ElseIf formName = "FormProductionSummary" Then
            FormProductionSummary.Close()
            FormProductionSummary.Dispose()
        Else
            RPSubMenu.Visible = False
        End If
    End Sub
    'Duplicate Data
    Private Sub BBDuplicate_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles BBDuplicate.ItemClick
        If formName = "FormMasterProduct" Then
            If FormMasterProduct.XTCProduct.SelectedTabPageIndex = 0 Then
                'design
                FormMasterDesignSingle.dupe = "1"
                FormMasterDesignSingle.id_design = FormMasterProduct.GVDesign.GetFocusedRowCellDisplayText("id_design").ToString
                FormMasterDesignSingle.ShowDialog()
            ElseIf FormMasterProduct.XTCProduct.SelectedTabPageIndex = 1 Then
                'product
                FormMasterProductDet.id_product = FormMasterProduct.GVProduct.GetFocusedRowCellDisplayText("id_product").ToString
                FormMasterProductDet.id_design = FormMasterProduct.GVDesign.GetFocusedRowCellDisplayText("id_design").ToString
                FormMasterProductDet.dupe = "1"
                FormMasterProductDet.ShowDialog()
            End If
        ElseIf formName = "FormBOM" Then
            'call form dupe
            FormBOMDuplicate.ShowDialog()
        ElseIf formName = "FormAccess" Then
            'call form dupe
            Dim confirm As DialogResult = XtraMessageBox.Show("Duplicate menu only available for this process (only BarButtonItem type) : " + System.Environment.NewLine + "- BBNew" + System.Environment.NewLine + "- BBEdit" + System.Environment.NewLine + "- BBDelete" + System.Environment.NewLine + "- BBPrint" + System.Environment.NewLine + "- BBRefresh" + System.Environment.NewLine + "Are you sure to continue this process ?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
            If confirm = Windows.Forms.DialogResult.Yes Then
                Try
                    Cursor = Cursors.WaitCursor

                    Dim id_form As String = FormAccess.GVForm.GetFocusedRowCellDisplayText("id_form").ToString
                    'BBNew
                    Dim query As String = "INSERT INTO tb_menu_form_control(id_form, description_form_control, id_form_control_type, is_view, form_control_name) "
                    query += "VALUES ('" + id_form + "', 'Insert', '1', '2', 'BBNew')"
                    execute_non_query(query, True, "", "", "", "")
                    'BBEdit
                    query = "INSERT INTO tb_menu_form_control(id_form, description_form_control, id_form_control_type, is_view, form_control_name) "
                    query += "VALUES ('" + id_form + "', 'Edit', '1', '2', 'BBEdit')"
                    execute_non_query(query, True, "", "", "", "")
                    'BBDelete
                    query = "INSERT INTO tb_menu_form_control(id_form, description_form_control, id_form_control_type, is_view, form_control_name) "
                    query += "VALUES ('" + id_form + "', 'Delete', '1', '2', 'BBDelete')"
                    execute_non_query(query, True, "", "", "", "")
                    'BBPrint
                    query = "INSERT INTO tb_menu_form_control(id_form, description_form_control, id_form_control_type, is_view, form_control_name) "
                    query += "VALUES ('" + id_form + "', 'Print', '1', '2', 'BBPrint')"
                    execute_non_query(query, True, "", "", "", "")
                    FormAccess.viewFormControl()
                    'BBRefresh
                    'query = "INSERT INTO tb_menu_form_control(id_form, description_form_control, id_form_control_type, is_view, form_control_name) "
                    'query += "VALUES ('" + id_form + "', 'Refresh', '1', '2', 'BBRefresh')"
                    'execute_non_query(query, True, "", "", "", "")
                    'FormAccess.viewFormControl()

                    Cursor = Cursors.Default
                Catch ex As Exception
                    Cursor = Cursors.Default
                    errorConnection()
                End Try
            End If
        ElseIf formName = "FormMasterSample" Then
            '
            FormMasterSampleDet.dupe = "1"
            FormMasterSampleDet.id_sample = FormMasterSample.GVSample.GetFocusedRowCellDisplayText("id_sample").ToString
            FormMasterSampleDet.ShowDialog()
        ElseIf formName = "FormFGDesignList" Then
            'LINE LIST DESIGN
            FormMasterDesignSingle.id_pop_up = "5"
            FormMasterDesignSingle.WindowState = FormWindowState.Maximized
            FormMasterDesignSingle.form_name = "FormFGDesignList"
            FormMasterDesignSingle.dupe = "1"
            Dim id_dsg_param As String = "-1"
            Try
                id_dsg_param = FormFGDesignList.GVDesign.GetFocusedRowCellValue("id_design").ToString
            Catch ex As Exception
            End Try
            FormMasterDesignSingle.id_design = id_dsg_param
            FormMasterDesignSingle.ShowDialog()
        End If
    End Sub
    'Contact 
    Private Sub BBContact_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles BBContact.ItemClick
        Cursor = Cursors.WaitCursor
        Try
            FormMasterCompanyContact.id_company = FormMasterCompany.GVCompany.GetFocusedRowCellDisplayText("id_comp").ToString
            FormMasterCompanyContact.ShowDialog()
        Catch ex As Exception

        End Try
        Cursor = Cursors.Default
    End Sub
    'Mapping User
    Private Sub BBMapping_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles BBMapping.ItemClick
        If formName = "FormAccess" Then
            Cursor = Cursors.WaitCursor
            Try
                'FormAccessMappingSingle.id_menu = FormAccess.GVMenu.GetFocusedRowCellDisplayText("id_menu").ToString
                'FormMasterUserMappingSingle.LabelDescriptionContent.Text = FormAccess.GVMenu.GetFocusedRowCellDisplayText("description_menu_name").ToString
                'FormMasterUserMappingSingle.LabelMenuName.Text = FormAccess.GVMenu.GetFocusedRowCellDisplayText("menu_name").ToString
                FormAccessMappingSingle.ShowDialog()
            Catch ex As Exception
                errorProcess()
                Close()
            End Try
            Cursor = Cursors.Default
        ElseIf formName = "FormMarkAssign" Then
            Cursor = Cursors.WaitCursor
            Try
                FormMarkAssignUser.id_mark_asg = FormMarkAssign.GVMarkAssign.GetFocusedRowCellDisplayText("id_mark_asg").ToString
                FormMarkAssignUser.ShowDialog()
            Catch ex As Exception
                errorProcess()
                Close()
            End Try
            Cursor = Cursors.Default
        End If
    End Sub
    'Refresh
    Private Sub BBRefresh_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles BBRefresh.ItemClick
        If formName = "FormSamplePlan" Then
            FormSamplePlan.view_sample_plan()
        ElseIf formName = "FormMasterProduct" Then
            FormMasterProduct.view_design()
        ElseIf formName = "FormSamplePurchase" Then
            If FormSamplePurchase.XTCTabReceive.SelectedTabPageIndex = 0 Then
                FormSamplePurchase.view_sample_purc()
            ElseIf FormSamplePurchase.XTCTabReceive.SelectedTabPageIndex = 1 Then
                FormSamplePurchase.view_sample_plan()
            End If
        ElseIf formName = "FormSampleReceive" Then
            If FormSampleReceive.XTCTabReceive.SelectedTabPageIndex = 0 Then
                FormSampleReceive.view_sample_rec()
            ElseIf FormSampleReceive.XTCTabReceive.SelectedTabPageIndex = 1 Then
                FormSampleReceive.view_sample_purc()
            End If
        ElseIf formName = "FormSamplePR" Then
            If FormSamplePR.XTCTabPR.SelectedTabPageIndex = 0 Then
                FormSamplePR.view_sample_pr()
            ElseIf FormSamplePR.XTCTabPR.SelectedTabPageIndex = 1 Then
                FormSamplePR.view_sample_purc()
            ElseIf FormSamplePR.XTCTabPR.SelectedTabPageIndex = 2 Then
                FormSamplePR.view_sample_rec()
            End If
        ElseIf formName = "FormMasterSample" Then
            FormMasterSample.view_sample()
        ElseIf formName = "FormMasterWH" Then
            'WAREHOUSE & LOCATOR
            If FormMasterWH.XTCWH.SelectedTabPageIndex = 0 Then
                FormMasterWH.viewWH()
            ElseIf FormMasterWH.XTCWH.SelectedTabPageIndex = 1 Then
                FormMasterWH.viewWHLocator()
            ElseIf FormMasterWH.XTCWH.SelectedTabPageIndex = 1 Then
                FormMasterWH.viewRack()
            ElseIf FormMasterWH.XTCWH.SelectedTabPageIndex = 3 Then
                FormMasterWH.viewDrawer()
            End If
        ElseIf formName = "FormSampleRet" Then
            'RETURN SAMPLE
            If FormSampleRet.XTCReturn.SelectedTabPageIndex = 0 Then 'returnIn
                FormSampleRet.viewRetOut()
            ElseIf FormSampleRet.XTCReturn.SelectedTabPageIndex = 1 Then 'Return Out
                FormSampleRet.viewRetIn()
            End If
        ElseIf formName = "FormSamplePLDel" Then
            'PL SAMPLE DEL
            If FormSamplePLDel.XTCPL.SelectedTabPageIndex = 0 Then
                FormSamplePLDel.viewPL()
            ElseIf FormSamplePLDel.XTCPL.SelectedTabPageIndex = 1 Then
                FormSamplePLDel.viewSampleReq()
            End If
        ElseIf formName = "FormSamplePL" Then
            'PL SAMPLE
            FormSamplePL.viewPL()
        ElseIf formName = "FormSampleReq" Then
            'SAMPLE REQ
            FormSampleReq.viewSampleReq()
        ElseIf formName = "FormMatPurchase" Then
            'Material Purchase
            If FormMatPurchase.XtraTabControl1.SelectedTabPageIndex = 0 Then 'purchase order
                FormMatPurchase.view_mat_purc()
            ElseIf FormMatPurchase.XtraTabControl1.SelectedTabPageIndex = 1 Then 'prod demand
                FormMatPurchase.viewProdDemand()
            End If
        ElseIf formName = "FormMatWO" Then
            'Material WO
            FormMatWO.view_mat_purc()
        ElseIf formName = "FormMatRecPurc" Then
            'Receive Material Purchase
            If FormMatRecPurc.XTCTabReceive.SelectedTabPageIndex = 0 Then 'based on Rec
                FormMatRecPurc.view_mat_rec_purc()
            Else 'based on PO
                FormMatRecPurc.view_mat_purc()
            End If
        ElseIf formName = "FormMatRecWO" Then
            'Receive Material WO
            If FormMatRecPurc.XTCTabReceive.SelectedTabPageIndex = 0 Then 'based on Rec
                FormMatRecWO.view_mat_rec_purc()
            Else 'based on Wo
                FormMatRecWO.view_mat_wo()
            End If
        ElseIf formName = "FormSampleReq" Then
            'SAMPLE REQ
            FormSampleReq.viewSampleReq()
        ElseIf formName = "FormSampleReturn" Then
            'RETURN SAMPLEFromDelivery
            If FormSampleReturn.XTCReturn.SelectedTabPageIndex = 0 Then 'List Return
                'MsgBox("Aw1")
                FormSampleReturn.viewSampleReturn()
            ElseIf FormSampleReturn.XTCReturn.SelectedTabPageIndex = 1 Then 'Not yet returned
                'MsgBox("Aw2")
                FormSampleReturn.viewPl()
            End If
        ElseIf formName = "FormMatRet" Then
            'Return Mat
            If FormMatRet.XTCReturnMat.SelectedTabPageIndex = 0 Then 'return purchasing
                If FormMatRet.XTCReturnPruchase.SelectedTabPageIndex = 0 Then 'return Out
                    FormMatRet.viewRetOut()
                ElseIf FormMatRet.XTCReturnPruchase.SelectedTabPageIndex = 1 Then 'return In
                    FormMatRet.viewRetIn()
                End If
            ElseIf FormMatRet.XTCReturnMat.SelectedTabPageIndex = 1 Then 'return production
                If FormMatRet.XTCReturnProd.SelectedTabPageIndex = 0 Then 'return In
                    FormMatRet.viewRetInProd()
                End If
            End If
        ElseIf formName = "FormSampleAdjustment" Then
            'Sample Adjustment
            If FormSampleAdjustment.XTCAdj.SelectedTabPageIndex = 0 Then 'List Adj In
                'MsgBox("Aw1")
                FormSampleAdjustment.viewAdjInSample()
            ElseIf FormSampleAdjustment.XTCAdj.SelectedTabPageIndex = 1 Then 'List Adj Out
                'MsgBox("Aw2")
                FormSampleAdjustment.viewAdjOutSample()
            End If
        ElseIf formName = "FormMatAdj" Then
            'Material Adjustment
            If FormMatAdj.XTCAdj.SelectedTabPageIndex = 0 Then 'List Adj In
                FormMatAdj.viewAdjIn()
            ElseIf FormMatAdj.XTCAdj.SelectedTabPageIndex = 1 Then 'List Adj Out
                FormMatAdj.viewAdjOut()
            End If
        ElseIf formName = "FormMatPR" Then
            'PR Mat PO
            If FormMatPR.XTCTabPR.SelectedTabPageIndex = 0 Then 'List PR
                FormMatPR.view_mat_pr()
            ElseIf FormMatPR.XTCTabPR.SelectedTabPageIndex = 1 Then 'List PO
                FormMatPR.view_mat_purc()
            ElseIf FormMatPR.XTCTabPR.SelectedTabPageIndex = 2 Then 'List Rec
                FormMatPR.view_mat_rec()
            End If
        ElseIf formName = "FormMatPRWO" Then
            'PR Mat WO
            If FormMatPRWO.XTCTabPR.SelectedTabPageIndex = 0 Then 'List PR
                FormMatPRWO.view_mat_pr()
            ElseIf FormMatPRWO.XTCTabPR.SelectedTabPageIndex = 1 Then 'List PO
                FormMatPRWO.view_mat_wo()
            ElseIf FormMatPRWO.XTCTabPR.SelectedTabPageIndex = 2 Then 'List Rec
                FormMatPRWO.view_mat_rec()
            End If
        ElseIf formName = "FormProduction" Then
            If FormProduction.XTCTabProduction.SelectedTabPageIndex = 0 Then ' prod order
                FormProduction.view_production_order()
            ElseIf FormProduction.XTCTabProduction.SelectedTabPageIndex = 1 Then ' prod demand
                FormProduction.viewProdDemand()
            ElseIf FormProduction.XTCTabProduction.SelectedTabPageIndex = 2 Then ' prod WO
                FormProduction.view_wo()
            ElseIf FormProduction.XTCTabProduction.SelectedTabPageIndex = 3 Then ' prod MRS
                FormProduction.view_mrs()
            End If
        ElseIf formName = "FormMatPL" Then
            If FormMatPL.XTCPL.SelectedTabPageIndex = 0 Then
                If FormMatPL.XTCTabProduction.SelectedTabPageIndex = 0 Then
                    FormMatPL.viewPL()
                ElseIf FormMatPL.XTCTabProduction.SelectedTabPageIndex = 1 Then
                    FormMatPL.viewMRS()
                End If
            ElseIf FormMatPL.XTCPL.SelectedTabPageIndex = 1 Then
                If FormMatPL.XTCPLOther.SelectedTabPageIndex = 0 Then
                    FormMatPL.viewPLOther()
                ElseIf FormMatPL.XTCPLOther.SelectedTabPageIndex = 1 Then
                    FormMatPL.view_mrs_other()
                End If
            End If
        ElseIf formName = "FormMatMRS" Then
            'Material Requisition : Other
            If FormMatMRS.XTCMRS.SelectedTabPageIndex = 0 Then 'mat wo
                FormMatMRS.view_mrs_wo()
            ElseIf FormMatMRS.XTCMRS.SelectedTabPageIndex = 1 Then 'other
                FormMatMRS.view_mrs()
            End If
        ElseIf formName = "FormProductionRec" Then
            'Receive FG QC
            If FormProductionRec.XTCTabReceive.SelectedTabPageIndex = 0 Then 'based on Rec
                FormProductionRec.view_prod_order_rec()
            Else 'based on Prod Order
                FormProductionRec.view_prod_order()
            End If
        ElseIf formName = "FormProductionRet" Then
            'Return FG
            If FormProductionRet.XTCReturn.SelectedTabPageIndex = 0 Then 'return Out
                FormProductionRet.viewRetOut()
            ElseIf FormProductionRet.XTCReturn.SelectedTabPageIndex = 1 Then 'return In
                FormProductionRet.viewRetIn()
            End If
        ElseIf formName = "FormProductionPLToWH" Then
            'PL FG To WH
            If FormProductionPLToWH.XTCPL.SelectedTabPageIndex = 0 Then
                FormProductionPLToWH.viewPL()
            ElseIf FormProductionPLToWH.XTCPL.SelectedTabPageIndex = 1 Then
                '
            End If
        ElseIf formName = "FormMatInvoice" Then
            'Mat Invoice
            If FormMatInvoice.XTCTabGeneral.SelectedTabPageIndex = 0 Then 'inv
                If FormMatInvoice.XTCTabProduction.SelectedTabPageIndex = 0 Then 'based inv
                    FormMatInvoice.viewInv()
                Else 'PL
                    FormMatInvoice.viewPL()
                End If
            Else 'retur
                If FormMatInvoice.XTCRetur.SelectedTabPageIndex = 0 Then 'based retur
                    FormMatInvoice.view_retur()
                Else 'inv
                    FormMatInvoice.viewInv_retur()
                End If
            End If
        ElseIf formName = "FormAccounting" Then
            If FormAccounting.XTCGeneral.SelectedTabPageIndex = 0 Then 'master
                FormAccounting.view_acc()
            Else
                FormAccounting.CreateNodes(FormAccounting.TreeList1)
            End If
        ElseIf formName = "FormAccountingJournal" Then
            If FormAccountingJournal.XTCJurnal.SelectedTabPageIndex = 0 Then
                FormAccountingJournal.view_entry(FormAccountingJournal.LEBilling.EditValue.ToString, Now.ToString("yyy-MM-dd"), Now.ToString("yyy-MM-dd"))
            Else
                FormAccountingJournal.view_det(Now.ToString("yyy-MM-dd"), Now.ToString("yyy-MM-dd"))
            End If
        ElseIf formName = "FormAccountingJournalAdj" Then
            FormAccountingJournalAdj.view_jurnal()
        ElseIf formName = "FormProductionPLToWHRec" Then
            'REC PL FG To WH
            If FormProductionPLToWHRec.XTCPL.SelectedTabPageIndex = 0 Then
                FormProductionPLToWHRec.viewPL()
            ElseIf FormProductionPLToWHRec.XTCPL.SelectedTabPageIndex = 1 Then
                FormProductionPLToWHRec.view_sample_purc()
            End If
        ElseIf formName = "FormSalesTarget" Then
            'SALES TARGET
            If FormSalesTarget.XTCSalesTarget.SelectedTabPageIndex = 0 Then
                FormSalesTarget.viewSalesTarget()
            End If
        ElseIf formName = "FormSalesOrder" Then
            'SALES Order
            If FormSalesOrder.XTCSOGeneral.SelectedTabPageIndex = 0 Then
                FormSalesOrder.viewSalesOrder()
            ElseIf FormSalesOrder.XTCSOGeneral.SelectedTabPageIndex = 1 Then
                FormSalesOrder.viewSalesOrderGen()
            End If
        ElseIf formName = "FormSalesDelOrder" Then
            'Sales Del Order
            If FormSalesDelOrder.XTCDO.SelectedTabPageIndex = 0 Then
                FormSalesDelOrder.viewSalesDelOrder()
            ElseIf FormSalesDelOrder.XTCDO.SelectedTabPageIndex = 1 Then
                FormSalesDelOrder.viewSalesOrder()
            ElseIf FormSalesDelOrder.XTCDO.SelectedTabPageIndex = 2 Then
                FormSalesDelOrder.viewrRef()
            End If
        ElseIf formName = "FormSalesReturnOrder" Then
            'SALES RETURN Order
            FormSalesReturnOrder.viewSalesReturnOrder()
        ElseIf formName = "FormSalesReturn" Then
            'SALES RETURN
            If FormSalesReturn.XTCSalesReturn.SelectedTabPageIndex = 0 Then
                FormSalesReturn.viewSalesReturn()
            ElseIf FormSalesReturn.XTCSalesReturn.SelectedTabPageIndex = 1 Then
                FormSalesReturn.viewSalesReturnOrder()
            End If
        ElseIf formName = "FormSalesPOS" Then
            'SALES VRTUAL POS
            FormSalesPOS.viewSalesPOS()
        ElseIf formName = "FormSalesReturnQC" Then
            'SALES RETURN QC
            If FormSalesReturnQC.XTCReturnQC.SelectedTabPageIndex = 0 Then
                FormSalesReturnQC.viewSalesReturnQC()
            Else
                FormSalesReturnQC.viewSalesReturn()
            End If
        ElseIf formName = "FormProdPRWO" Then
            'REC PL FG To WH
            If FormProdPRWO.XTCTabPR.SelectedTabPageIndex = 0 Then 'list
                FormProdPRWO.view_pr()
            ElseIf FormProdPRWO.XTCTabPR.SelectedTabPageIndex = 1 Then 'wo
                FormProdPRWO.view_wo()
            End If
        ElseIf formName = "FormSalesInvoice" Then
            'SALES INVOCIE
            FormSalesInvoice.viewSalesInvoice()
        ElseIf formName = "FormFGStockOpnameStore" Then
            'STORE STOCK OPNAME
            FormFGStockOpnameStore.viewSoStore()
        ElseIf formName = "FormFGMissing" Then
            'FG MISSING
            If FormFGMissing.XTCFGMissing.SelectedTabPageIndex = 0 Then
                FormFGMissing.viewFGMissing()
            ElseIf FormFGMissing.XTCFGMissing.SelectedTabPageIndex = 1 Then
                FormFGMissing.viewFGMissingWH()
            End If
        ElseIf formName = "FormFGMissingInvoice" Then
            'FG MISSING INVOCIE
            FormFGMissingInvoice.viewFGMissingInvoice()
        ElseIf formName = "FormFGStockOpnameWH" Then
            'WH STOCK OPNAME
            FormFGStockOpnameWH.viewSOWH()
        ElseIf formName = "FormFGAdj" Then
            'FG Adjustment
            If FormFGAdj.XTCAdj.SelectedTabPageIndex = 0 Then 'List Adj In
                FormFGAdj.viewAdjIn()
            ElseIf FormFGAdj.XTCAdj.SelectedTabPageIndex = 1 Then 'List Adj Out
                FormFGAdj.viewAdjOut()
            End If
        ElseIf formName = "FormFGTrf" Then
            'FG Transfer Future
            FormFGTrf.viewFGTrf()
        ElseIf formName = "FormFGTrfNew" Then
            'FG Transfer Future
            If FormFGTrfNew.XTCTrf.SelectedTabPageIndex = 0 Then
                FormFGTrfNew.viewFGTrf()
            ElseIf FormFGTrfNew.XTCTrf.SelectedTabPageIndex = 1 Then
                FormFGTrfNew.viewSalesOrder()
            End If
        ElseIf formName = "FormFGTrfReceive" Then
            'FG Transfer Rec
            FormFGTrfReceive.viewFGTrf()
        ElseIf formName = "FormAccountingSummary" Then
            'summary accounting
            FormAccountingSummary.CreateNodes(FormAccountingSummary.TreeList1)
        ElseIf formName = "FormMasterEmployee" Then
            'employee
            FormMasterEmployee.viewEmployee("-1")
        ElseIf formName = "FormSampleDel" Then
            'PL SAMPLE DEL
            FormSampleDel.viewSampleDel()
        ElseIf formName = "FormSampleDelRec" Then
            'REC PL SAMPLE DEL
            If FormSampleDelRec.XTCSampleDelRec.SelectedTabPageIndex = 0 Then
                FormSampleDelRec.viewSampleDelRec()
            ElseIf FormSampleDelRec.XTCSampleDelRec.SelectedTabPageIndex = 1 Then
                FormSampleDelRec.viewSampleDel()
            End If
        ElseIf formName = "FormSampleBarcode" Then
            'BARCODE
            FormSamplePrintBarcode.view_sample()
        ElseIf formName = "FormSampleOrder" Then
            'SALES ORDER SAMPLE
            FormSampleOrder.viewSampleOrder()
        ElseIf formName = "FormSampleDelOrder" Then
            'DELIVERY ORDER SAMPLE FOR SALES
            If FormSampleDelOrder.XTCSampleDelOrder.SelectedTabPageIndex = 0 Then
                FormSampleDelOrder.viewSampleDelOrder()
            ElseIf FormSampleDelOrder.XTCSampleDelOrder.SelectedTabPageIndex = 1 Then
                FormSampleDelOrder.viewSampleOrder()
            End If
        ElseIf formName = "FormFGCodeReplace" Then
            'CODE REPLACEMENT
            If FormFGCodeReplace.XTCFGCodeReplace.SelectedTabPageIndex = 0 Then
                FormFGCodeReplace.viewCodeReplaceStore()
            ElseIf FormFGCodeReplace.XTCFGCodeReplace.SelectedTabPageIndex = 1 Then
                FormFGCodeReplace.viewCodeReplaceWH()
            End If
        ElseIf formName = "FormAccountingListPR" Then
            'List PR accounting
            FormAccountingListPR.view_list_pr()
        ElseIf formName = "FormSampleStockOpname" Then
            'List PR accounting
            FormSampleStockOpname.viewSOWH()
        ElseIf formName = "FormSalesCreditNote" Then
            'CREDIT NOTE
            FormSalesCreditNote.viewSalesPOS()
        ElseIf formName = "FormFGMissingCreditNote" Then
            'MISSING CREDIT NOTE
            FormFGMissingCreditNote.viewFGMissingStoreCN()
        ElseIf formName = "FormSOH" Then
            'SOH
            FormSOH.view_soh_periode(FormSOH.LESOHPeriode.EditValue)
        ElseIf formName = "FormSOHPeriode" Then
            'SOH Periode
            FormSOHPeriode.view_soh()
        ElseIf formName = "FormSOHPrice" Then
            'SOH Periode
            FormSOHPrice.view_soh()
        ElseIf formName = "FormFGWoff" Then
            'WRITEOFF
            FormFGWoff.viewFGWoff()
        ElseIf formName = "FormFGProposePrice" Then
            'FG Propose
            FormFGProposePrice.viewPropose()
        ElseIf formName = "FormMasterRetCode" Then
            'MASTER RET CODE
            FormMasterRetCode.viewRetCode()
        ElseIf formName = "FormMasterRateStore" Then
            'MASTER RATE STORE
            FormMasterRateStore.viewRate()
        ElseIf formName = "FormMasterDesignCOP" Then
            'MASTER DESIGN COP
            FormMasterDesignCOP.view_design()
        ElseIf formName = "FormSampleOrdered" Then
            'SAMPLE ORDERED
            FormSampleOrdered.viewSampleOrder()
        ElseIf formName = "FormProdQCAdj" Then
            If FormProdQCAdj.XTCAdj.SelectedTabPageIndex = 0 Then 'QC adj IN
                FormProdQCAdj.viewAdjIn()
            Else 'QC adj OUT
                FormProdQCAdj.viewAdjOut()
            End If
        ElseIf formName = "FormFGSalesOrderReff" Then
            'SALES ORDER REFF
            FormFGSalesOrderReff.viewSOReff()
        ElseIf formName = "FormSalesPromo" Then
            'SALES PROMO
            FormSalesPromo.viewSalesPOS()
        ElseIf formName = "FormSalesOrderList" Then
            'PREPARE ORDER LIST
            Cursor = Cursors.WaitCursor
            If FormSalesOrderList.XTCWHMonitor.SelectedTabPageIndex = 0 Then 'list
                FormSalesOrderList.viewSalesOrder()
            ElseIf FormSalesOrderList.XTCWHMonitor.SelectedTabPageIndex = 1 Then 'ref
                FormSalesOrderList.viewNewPrepare(FormSalesOrderList.TxtNoParam.Text)
            End If
            Cursor = Cursors.Default
        ElseIf formName = "FormSalesOrderSvcLevel" Then
            'SERVICE LEVEL
            If FormSalesOrderSvcLevel.XTCSvcLevel.SelectedTabPageIndex = 0 Then
                'PREPARE ORDER
                FormSalesOrderSvcLevel.viewSalesOrder()
            ElseIf FormSalesOrderSvcLevel.XTCSvcLevel.SelectedTabPageIndex = 1 Then
                'RETURN ORDER
                FormSalesOrderSvcLevel.viewReturnOrder()
            ElseIf FormSalesOrderSvcLevel.XTCSvcLevel.SelectedTabPageIndex = 2 Then
                'RECEIVED
                FormSalesOrderSvcLevel.viewRecProduct()
            ElseIf FormSalesOrderSvcLevel.XTCSvcLevel.SelectedTabPageIndex = 3 Then
                'DO
                FormSalesOrderSvcLevel.viewDO()
            ElseIf FormSalesOrderSvcLevel.XTCSvcLevel.SelectedTabPageIndex = 4 Then
                'RETURN
                FormSalesOrderSvcLevel.viewReturn()
            ElseIf FormSalesOrderSvcLevel.XTCSvcLevel.SelectedTabPageIndex = 5 Then
                'RETURN QC
                FormSalesOrderSvcLevel.viewReturnQC()
            ElseIf FormSalesOrderSvcLevel.XTCSvcLevel.SelectedTabPageIndex = 6 Then
                'TRF
                FormSalesOrderSvcLevel.viewTrf()
            End If
        ElseIf formName = "FormMasterComputer" Then
            'MASTER COMPUTER
            Cursor = Cursors.WaitCursor
            FormMasterComputer.viewComputer()
            Cursor = Cursors.Default
        ElseIf formName = "FormNotification" Then
            'NOTIFICATION
            FormNotification.viewNotif()
        ElseIf formName = "FormAccountingFakturScan" Then
            'FAKTURSCAN
            FormAccountingFakturScan.viewTrans()
        ElseIf formName = "FormFGBorrowQCReq" Then
            'BORRWOW REQ FOR QC FG
            FormFGBorrowQCReq.viewBorrowReq()
        ElseIf formName = "FormWHAWBill" Then
            'FormWHAWBill
            If FormWHAWBill.XTCAwb.SelectedTabPageIndex = 0 Then
                FormWHAWBill.load_outbound()
            Else
                FormWHAWBill.load_inbound()
            End If
        ElseIf formName = "FormMasterPrice" Then
            'MASTER PRICE
            FormMasterPrice.viewPrice()
        ElseIf formName = "FormMasterPriceSample" Then
            'MASTER PRICE SAMPLe
            FormMasterPriceSample.viewPrice()
        ElseIf formName = "FormWHImportDO" Then
            'IMPORT DO
            FormWHImportDO.viewDOList()
        ElseIf formName = "FormMasterRawMaterial" Then
            If FormMasterRawMaterial.XTCList.SelectedTabPageIndex = 0 Then
                If FormMasterRawMaterial.XTCMaterialType.SelectedTabPageIndex = 0 Then
                    FormMasterRawMaterial.viewMat()
                Else
                    FormMasterRawMaterial.viewMatDetail()
                End If
            ElseIf FormMasterRawMaterial.XTCList.SelectedTabPageIndex = 1 Then
                FormMasterRawMaterial.viewMatDetailList()
            End If
        ElseIf formName = "FormFGDesignList" Then
            FormFGDesignList.viewData()
        ElseIf formName = "FormWHSvcLevel" Then
            If FormWHSvcLevel.XTCSvcLelel.SelectedTabPageIndex = 0 Then
                FormWHSvcLevel.viewSvcBySO()
            ElseIf FormWHSvcLevel.XTCSvcLelel.SelectedTabPageIndex = 1 Then
                FormWHSvcLevel.viewSvcByCode()
            ElseIf FormWHSvcLevel.XTCSvcLelel.SelectedTabPageIndex = 2 Then
                FormWHSvcLevel.viewSvcByAcc()
            End If
        ElseIf formName = "FormFGWHAlloc" Then
            'INVENTORY ALLOCATION
            FormFGWHAlloc.viewFGWHAlloc()
        ElseIf formName = "FormSamplePLToWH" Then
            'PL SAMPLE
            FormSamplePLToWH.viewSamplePL()
        ElseIf formName = "FormSampleReturnPL" Then
            'Return From Internal Sale
            FormSampleReturnPL.viewSamplePL()
        ElseIf formName = "FormWHCargoRate" Then
            'Cargo Rate
            If FormWHCargoRate.XTCRate.SelectedTabPageIndex = 0 Then
                FormWHCargoRate.load_cargo_rate()
            Else
                FormWHCargoRate.load_cargo_rate_in()
            End If
        ElseIf formName = "FormEmpFP" Then
            FormEmpFP.viewFP()
        ElseIf formName = "FormEmpShift" Then
            'Shift employee
            FormEmpShift.load_schedule()
        ElseIf formName = "FormFGRepair" Then
            FormFGRepair.viewData()
        ElseIf formName = "FormFGRepairRec" Then
            If FormFGRepairRec.XTCRepairRec.SelectedTabPageIndex = 0 Then
                FormFGRepairRec.viewData()
            Else
                FormFGRepairRec.viewRepairList()
            End If
        ElseIf formName = "FormFGRepairReturn" Then
            FormFGRepairReturn.viewData()
        ElseIf formName = "FormEmpEmail" Then
            FormEmpEmail.viewEmployee("-1")
        ElseIf formName = "FormFGRepairReturnRec" Then
            If FormFGRepairReturnRec.XTCRepairRec.SelectedTabPageIndex = 0 Then
                FormFGRepairReturnRec.viewData()
            Else
                FormFGRepairReturnRec.viewRepairList()
            End If
        ElseIf formName = "FormEmpLeave" Then
            FormEmpLeave.load_sum()
        ElseIf formName = "FormEmpDP" Then
            FormEmpDP.load_dp()
        End If
    End Sub
    'Switch
    Private Sub BBSwitch_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles BBSwitch.ItemClick
        If formName = "FormMasterWH" Then
            'WAREHOUSE & LOCATOR
            If FormMasterWH.XTCWHMain.SelectedTabPageIndex = 1 Then
                'Try
                If FormMasterWH.XTCStock.SelectedTabPageIndex = 0 Then
                    Dim id_wh_drawer As Integer = FormMasterWH.SLEDrawer.EditValue
                    If id_wh_drawer > 0 Or id_wh_drawer <> Nothing Then
                        FormSampleStorageIn.action = "upd"
                        FormSampleStorageIn.id_sample = FormMasterWH.GVSample.GetFocusedRowCellDisplayText("id_sample").ToString
                        FormSampleStorageIn.ShowDialog()
                    Else
                        errorCustom("Cannot switch locator, please Select detail drawer !")
                    End If
                ElseIf FormMasterWH.XTCStock.SelectedTabPageIndex = 1 Then
                    Dim id_wh_drawer As Integer = FormMasterWH.SLEDrawerStockMat.EditValue
                    If id_wh_drawer > 0 Or id_wh_drawer <> Nothing Then
                        FormMatStorageIn.action = "upd"
                        FormMatStorageIn.id_mat_det = FormMasterWH.GVMatStock.GetFocusedRowCellDisplayText("id_mat_det").ToString
                        FormMatStorageIn.ShowDialog()
                    Else
                        errorCustom("Cannot switch locator, please Select detail drawer !")
                    End If
                ElseIf FormMasterWH.XTCStock.SelectedTabPageIndex = 2 Then
                    Dim id_wh_drawer As Integer = FormMasterWH.SLEDrawerStockFG.EditValue
                    If id_wh_drawer > 0 Or id_wh_drawer <> Nothing Then
                        FormProductionStorageIn.action = "upd"
                        FormProductionStorageIn.id_product = FormMasterWH.GVFGStock.GetFocusedRowCellValue("id_product").ToString
                        FormProductionStorageIn.colorku = FormMasterWH.GVFGStock.GetFocusedRowCellValue("color").ToString
                        FormProductionStorageIn.sizeku = FormMasterWH.GVFGStock.GetFocusedRowCellValue("size").ToString
                        FormProductionStorageIn.id_bomx = FormMasterWH.GVFGStock.GetFocusedRowCellValue("id_bom").ToString
                        FormProductionStorageIn.bom_unit_pricex = FormMasterWH.GVFGStock.GetFocusedRowCellValue("bom_unit_price").ToString
                        FormProductionStorageIn.jumx = FormMasterWH.GVFGStock.GetFocusedRowCellValue("qty_all_product").ToString
                        FormProductionStorageIn.id_sample = FormMasterWH.GVFGStock.GetFocusedRowCellValue("id_sample").ToString
                        FormProductionStorageIn.ShowDialog()
                    Else
                        errorCustom("Cannot switch locator, please Select detail drawer !")
                    End If
                End If
                'Catch ex As Exception

                'End Try
            End If
        ElseIf formName = "FormSampleStock" Then
            Dim id_wh_drawer As Integer = FormSampleStock.SLEDrawer.EditValue
            Dim id_sample_par As String = "-1"
            Try
                id_sample_par = FormSampleStock.GVSample.GetFocusedRowCellValue("id_sample").ToString
            Catch ex As Exception
            End Try

            If id_wh_drawer > 0 Or id_wh_drawer <> Nothing Or id_sample_par <> "-1" Then
                FormSampleStorageIn.action = "upd"
                FormSampleStorageIn.id_sample = id_sample_par
                FormSampleStorageIn.ShowDialog()
            Else
                errorCustom("Cannot switch locator, please Select detail drawer !")
            End If
        End If
    End Sub
    ' view
    Private Sub BBView_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles BBView.ItemClick
        Cursor = Cursors.WaitCursor
        If formName = "FormWork" Then
            If FormWork.XTCGeneral.SelectedTabPageIndex = 0 Then
            ElseIf FormWork.XTCGeneral.SelectedTabPageIndex = 1 Then
                'sample
                If FormWork.XTCSample.SelectedTabPageIndex = 0 Then
                    'purchase
                    FormViewSamplePurchase.id_sample_purc = FormWork.GVSamplePurchase.GetFocusedRowCellDisplayText("id_sample_purc").ToString
                    FormViewSamplePurchase.ShowDialog()
                ElseIf FormWork.XTCSample.SelectedTabPageIndex = 1 Then
                    'receive
                    FormViewSampleReceive.id_receive = FormWork.GVSampleReceive.GetFocusedRowCellDisplayText("id_sample_purc_rec").ToString
                    FormViewSampleReceive.ShowDialog()
                ElseIf FormWork.XTCSample.SelectedTabPageIndex = 2 Then
                    'packing list
                    FormViewSamplePL.id_pl_sample_purc = FormWork.GVSamplePL.GetFocusedRowCellDisplayText("id_pl_sample_purc").ToString
                    FormViewSamplePL.ShowDialog()
                ElseIf FormWork.XTCSample.SelectedTabPageIndex = 3 Then
                    'paymen requisition
                    FormViewSamplePR.id_pr = FormWork.GVSamplePR.GetFocusedRowCellDisplayText("id_pr_sample_purc").ToString
                    FormViewSamplePR.ShowDialog()
                ElseIf FormWork.XTCSample.SelectedTabPageIndex = 4 Then
                    'sample requisition
                    FormViewSampleReq.id_sample_requisition = FormWork.GVSampleReq.GetFocusedRowCellValue("id_sample_requisition").ToString
                    FormViewSampleReq.ShowDialog()
                ElseIf FormWork.XTCSample.SelectedTabPageIndex = 5 Then
                    'PL Sample Del
                    FormViewSamplePLDel.action = "upd"
                    FormViewSamplePLDel.id_pl_sample_del = FormWork.GVSamplePLDel.GetFocusedRowCellDisplayText("id_pl_sample_del").ToString
                    FormViewSamplePLDel.id_comp_contact_to = FormWork.GVSamplePLDel.GetFocusedRowCellDisplayText("id_comp_contact_to").ToString
                    FormViewSamplePLDel.id_comp_contact_from = FormWork.GVSamplePLDel.GetFocusedRowCellDisplayText("id_comp_contact_from").ToString
                    FormViewSamplePLDel.ShowDialog()
                ElseIf FormWork.XTCSample.SelectedTabPageIndex = 6 Then
                    'Sample Return From Delivery
                    FormViewSampleReturn.action = "upd"
                    FormViewSampleReturn.id_sample_return = FormWork.GVRetSample.GetFocusedRowCellDisplayText("id_sample_return").ToString
                    FormViewSampleReturn.ShowDialog()
                ElseIf FormWork.XTCSample.SelectedTabPageIndex = 7 Then
                    'Adj In Sample
                    FormViewSampleAdjIn.action = "upd"
                    FormViewSampleAdjIn.id_adj_in_sample = FormWork.GVAdjSampleIn.GetFocusedRowCellDisplayText("id_adj_in_sample").ToString
                    FormViewSampleAdjIn.ShowDialog()
                ElseIf FormWork.XTCSample.SelectedTabPageIndex = 8 Then
                    'Adj Out Sample
                    FormViewSampleAdjOut.action = "upd"
                    FormViewSampleAdjOut.id_adj_out_sample = FormWork.GVAdjOutSample.GetFocusedRowCellDisplayText("id_adj_out_sample").ToString
                    FormViewSampleAdjOut.ShowDialog()
                ElseIf FormWork.XTCSample.SelectedTabPageIndex = 9 Then
                    'PL SAMPLE DELIVERY
                    FormViewSampleDel.id_sample_del = FormWork.GVSampleDel.GetFocusedRowCellValue("id_sample_del").ToString
                    FormViewSampleDel.ShowDialog()
                ElseIf FormWork.XTCSample.SelectedTabPageIndex = 10 Then
                    'REC PL SAMPLE DELIVERY
                    FormViewSampleDelRec.id_sample_del_rec = FormWork.GVSampleDelRec.GetFocusedRowCellValue("id_sample_del_rec").ToString
                    FormViewSampleDelRec.ShowDialog()
                ElseIf FormWork.XTCSample.SelectedTabPageIndex = 11 Then
                    'SALES ORDER SAMPLE
                    FormViewSampleOrder.id_sample_order = FormWork.GVSampleOrder.GetFocusedRowCellValue("id_sample_order").ToString
                    FormViewSampleOrder.ShowDialog()
                ElseIf FormWork.XTCSample.SelectedTabPageIndex = 12 Then
                    'DELIVERY ORDER SAMPLE
                    FormViewSampleDelOrder.id_pl_sample_order_del = FormWork.GVSampleDelOrder.GetFocusedRowCellValue("id_pl_sample_order_del").ToString
                    FormViewSampleDelOrder.ShowDialog()
                End If
            ElseIf FormWork.XTCGeneral.SelectedTabPageIndex = 2 Then
                If FormWork.XTCMaterial.SelectedTabPageIndex = 0 Then
                    'PO
                ElseIf FormWork.XTCMaterial.SelectedTabPageIndex = 1 Then
                    'rEC
                ElseIf FormWork.XTCMaterial.SelectedTabPageIndex = 2 Then
                    'PR PO
                    FormViewMatPR.id_pr = FormWork.GVMatPRPO.GetFocusedRowCellValue("id_pr_mat_purc").ToString
                    FormViewMatPR.ShowDialog()
                ElseIf FormWork.XTCMaterial.SelectedTabPageIndex = 3 Then
                    'PR WO
                    FormViewMatPRWO.id_pr = FormWork.GVMatPRWO.GetFocusedRowCellValue("id_pr_mat_wo").ToString
                    FormViewMatPRWO.ShowDialog()
                ElseIf FormWork.XTCMaterial.SelectedTabPageIndex = 4 Then
                    'Adj In Material
                    FormViewMatAdjIn.action = "upd"
                    FormViewMatAdjIn.id_adj_in_mat = FormWork.GVMatAdjIn.GetFocusedRowCellDisplayText("id_adj_in_mat").ToString
                    FormViewMatAdjIn.ShowDialog()
                ElseIf FormWork.XTCMaterial.SelectedTabPageIndex = 5 Then
                    'Adj Out Materal
                    FormViewMatAdjOut.action = "upd"
                    FormViewMatAdjOut.id_adj_out_mat = FormWork.GVMatAdjOut.GetFocusedRowCellDisplayText("id_adj_out_mat").ToString
                    FormViewMatAdjOut.ShowDialog()
                End If
            ElseIf FormWork.XTCGeneral.SelectedTabPageIndex = 3 Then
                If FormWork.XTCProduction.SelectedTabPageIndex = 0 Then
                    'prod demand
                    FormViewProdDemand.report_mark_type = FormWork.GVProdDemand.GetFocusedRowCellValue("report_mark_type").ToString
                    FormViewProdDemand.id_prod_demand = FormWork.GVProdDemand.GetFocusedRowCellDisplayText("id_prod_demand").ToString
                    FormViewProdDemand.ShowDialog()
                ElseIf FormWork.XTCProduction.SelectedTabPageIndex = 3 Then
                    'prod FG QC
                    FormViewProductionRec.id_receive = FormWork.GVProdRec.GetFocusedRowCellDisplayText("id_prod_order_rec").ToString
                    FormViewProductionRec.ShowDialog()
                ElseIf FormWork.XTCProduction.SelectedTabPageIndex = 4 Then
                    'return out FG QC
                    FormViewProductionRetOut.id_prod_order_ret_out = FormWork.GVProdRetOut.GetFocusedRowCellDisplayText("id_prod_order_ret_out").ToString
                    FormViewProductionRetOut.ShowDialog()
                ElseIf FormWork.XTCProduction.SelectedTabPageIndex = 5 Then
                    'return in FG QC
                    FormViewProductionRetIn.id_prod_order_ret_in = FormWork.GVProdRetIn.GetFocusedRowCellDisplayText("id_prod_order_ret_in").ToString
                    FormViewProductionRetIn.ShowDialog()
                ElseIf FormWork.XTCProduction.SelectedTabPageIndex = 6 Then
                    'PL FG TO WH
                    Dim id As String = "-1"
                    Try
                        id = FormWork.GVProdPLToWH.GetFocusedRowCellValue("id_pl_prod_order").ToString
                    Catch ex As Exception
                    End Try
                    If id <> "-1" And id <> "" Then
                        FormViewProductionPLToWH.id_pl_prod_order = id
                        FormViewProductionPLToWH.ShowDialog()
                    End If
                ElseIf FormWork.XTCProduction.SelectedTabPageIndex = 7 Then
                    'PL FG TO WH
                    FormViewProductionPLToWHRec.id_pl_prod_order_rec = FormWork.GVProdPLToWHRec.GetFocusedRowCellDisplayText("id_pl_prod_order_rec").ToString
                    FormViewProductionPLToWHRec.ShowDialog()
                End If
            ElseIf FormWork.XTCGeneral.SelectedTabPageIndex = 4 Then
                If FormWork.XTCSales.SelectedTabPageIndex = 0 Then
                    'SALES TARGET
                ElseIf FormWork.XTCSales.SelectedTabPageIndex = 1 Then
                    'PROPOSE PRICE
                    FormViewFGProposePrice.id_fg_propose_price = FormWork.GVFGPropose.GetFocusedRowCellValue("id_fg_propose_price").ToString
                    FormViewFGProposePrice.ShowDialog()
                ElseIf FormWork.XTCSales.SelectedTabPageIndex = 2 Then
                    'SALES ORDER
                    FormViewSalesOrder.id_sales_order = FormWork.GVSalesOrder.GetFocusedRowCellValue("id_sales_order").ToString
                    FormViewSalesOrder.ShowDialog()
                ElseIf FormWork.XTCSales.SelectedTabPageIndex = 3 Then
                    'SALES DEL ORDER
                    FormViewSalesDelOrder.id_pl_sales_order_del = FormWork.GVSalesDelOrder.GetFocusedRowCellValue("id_pl_sales_order_del").ToString
                    FormViewSalesDelOrder.ShowDialog()
                ElseIf FormWork.XTCSales.SelectedTabPageIndex = 4 Then
                    'SALES Return ORDER
                    FormViewSalesReturnOrder.id_sales_return_order = FormWork.GVSalesReturnOrder.GetFocusedRowCellValue("id_sales_return_order").ToString
                    FormViewSalesReturnOrder.ShowDialog()
                ElseIf FormWork.XTCSales.SelectedTabPageIndex = 5 Then
                    'SALES Return
                    FormViewSalesReturn.id_sales_return = FormWork.GVSalesReturn.GetFocusedRowCellValue("id_sales_return").ToString
                    FormViewSalesReturn.ShowDialog()
                ElseIf FormWork.XTCSales.SelectedTabPageIndex = 6 Then
                    'SALES POS
                    FormViewSalesPOS.id_sales_pos = FormWork.GVSalesPOS.GetFocusedRowCellValue("id_sales_pos").ToString
                    FormViewSalesPOS.ShowDialog()
                ElseIf FormWork.XTCSales.SelectedTabPageIndex = 7 Then
                    'SALES CREDIT NOTE
                    FormViewSalesCreditNote.id_sales_pos = FormWork.GVSalesCreditNote.GetFocusedRowCellValue("id_sales_pos").ToString
                    FormViewSalesCreditNote.ShowDialog()
                ElseIf FormWork.XTCSales.SelectedTabPageIndex = 8 Then
                    'SALES Return QC
                    FormViewSalesReturnQC.id_sales_return_qc = FormWork.GVSalesReturnQC.GetFocusedRowCellValue("id_sales_return_qc").ToString
                    FormViewSalesReturnQC.ShowDialog()
                ElseIf FormWork.XTCSales.SelectedTabPageIndex = 9 Then
                    'SALES Invoice
                    FormViewSalesInvoice.id_sales_invoice = FormWork.GVSalesInvoice.GetFocusedRowCellValue("id_sales_invoice").ToString
                    FormViewSalesInvoice.ShowDialog()
                ElseIf FormWork.XTCSales.SelectedTabPageIndex = 10 Then
                    'FG SO STORE
                    FormViewFGStockOpname.id_fg_so_store = FormWork.GVSOStore.GetFocusedRowCellValue("id_fg_so_store").ToString
                    FormViewFGStockOpname.ShowDialog()
                ElseIf FormWork.XTCSales.SelectedTabPageIndex = 11 Then
                    'FG MISSING
                    FormViewFGMissing.id_fg_missing = FormWork.GVFGMissing.GetFocusedRowCellValue("id_sales_pos").ToString
                    FormViewFGMissing.ShowDialog()
                ElseIf FormWork.XTCSales.SelectedTabPageIndex = 12 Then
                    'FG MISSING CREDIT NOTE STORE
                    FormViewFGMissingCreditNoteStore.id_sales_pos = FormWork.GVFGMissingCNStore.GetFocusedRowCellValue("id_sales_pos").ToString
                    FormViewFGMissingCreditNoteStore.ShowDialog()
                ElseIf FormWork.XTCSales.SelectedTabPageIndex = 13 Then
                    'FG SO WH
                    FormViewFGStockOpnameWH.id_fg_so_wh = FormWork.GVFGSOWH.GetFocusedRowCellValue("id_fg_so_wh").ToString
                    FormViewFGStockOpnameWH.ShowDialog()
                ElseIf FormWork.XTCSales.SelectedTabPageIndex = 14 Then
                    'FG ADJ IN
                    FormViewFGAdjIn.id_adj_in_fg = FormWork.GVFGAdjIn.GetFocusedRowCellValue("id_adj_in_fg").ToString
                    FormViewFGAdjIn.ShowDialog()
                ElseIf FormWork.XTCSales.SelectedTabPageIndex = 15 Then
                    'FG ADJ OUT
                    FormViewFGAdjOut.id_adj_out_fg = FormWork.GVFGAdjOut.GetFocusedRowCellValue("id_adj_out_fg").ToString
                    FormViewFGAdjOut.ShowDialog()
                ElseIf FormWork.XTCSales.SelectedTabPageIndex = 16 Then
                    'FG TRF
                    FormViewFGTrf.id_fg_trf = FormWork.GVFGTrf.GetFocusedRowCellValue("id_fg_trf").ToString
                    FormViewFGTrf.ShowDialog()
                ElseIf FormWork.XTCSales.SelectedTabPageIndex = 17 Then
                    'FG TRF REC
                    FormViewFGTrf.id_type = "1"
                    FormViewFGTrf.id_fg_trf = FormWork.GVFGTrfRec.GetFocusedRowCellValue("id_fg_trf").ToString
                    FormViewFGTrf.ShowDialog()
                ElseIf FormWork.XTCSales.SelectedTabPageIndex = 18 Then
                    'CODE REPLACEMENT STORE
                    FormViewFGCodeReplaceStore.id_fg_code_replace_store = FormWork.GVFGCodeReplaceStore.GetFocusedRowCellValue("id_fg_code_replace_store").ToString
                    FormViewFGCodeReplaceStore.ShowDialog()
                ElseIf FormWork.XTCSales.SelectedTabPageIndex = 19 Then
                    'CODE REPLACEMENT Wh
                    FormViewFGCodeReplaceWH.id_fg_code_replace_wh = FormWork.GVFGCodeReplaceWH.GetFocusedRowCellValue("id_fg_code_replace_wh").ToString
                    FormViewFGCodeReplaceWH.ShowDialog()
                ElseIf FormWork.XTCSales.SelectedTabPageIndex = 20 Then
                    'WRITE OFF FG
                    FormViewFGWoff.id_fg_woff = FormWork.GVFGWoff.GetFocusedRowCellValue("id_fg_woff").ToString
                    FormViewFGWoff.ShowDialog()
                End If
            End If
        ElseIf formName = "FormFGStockOpnameStore" Then
            FormViewFGStockOpname.id_fg_so_store = FormFGStockOpnameStore.GVSOStore.GetFocusedRowCellValue("id_fg_so_store").ToString
            FormViewFGStockOpname.ShowDialog()
        ElseIf formName = "FormFGStockOpnameWH" Then
            FormViewFGStockOpnameWH.id_fg_so_wh = FormFGStockOpnameWH.GVSOWH.GetFocusedRowCellValue("id_fg_so_wh").ToString
            FormViewFGStockOpnameWH.ShowDialog()
        ElseIf formName = "FormMatStockOpname" Then
            If Not FormMatStockOpname.GVMatPR.IsGroupRow(FormMatStockOpname.GVMatPR.FocusedRowHandle) Then
                If Not FormMatStockOpname.GVMatPR.GetFocusedRowCellValue("id_lock") = "1" Then
                    FormMatStockOpnameResultDet.id_mat_so = FormMatStockOpname.GVMatPR.GetFocusedRowCellValue("id_mat_so").ToString
                    FormMatStockOpnameResultDet.ShowDialog()
                Else
                    warningCustom("This opname Not done yet.")
                End If
            End If
        ElseIf formName = "FormAccountingFYear" Then
            FormAccountingFYearDet.id_acc_fy = FormAccountingFYear.GVAcc.GetFocusedRowCellValue("id_acc_fy").ToString
            FormAccountingFYearDet.ShowDialog()
        ElseIf formName = "FormAccountingListPR" Then
            Dim showpopup As ClassShowPopUp = New ClassShowPopUp()
            showpopup.report_mark_type = FormAccountingListPR.GVPaymentList.GetFocusedRowCellValue("report_mark_type").ToString()
            showpopup.id_report = FormAccountingListPR.GVPaymentList.GetFocusedRowCellValue("id_report").ToString()
            showpopup.is_payment = "1"
            showpopup.show()
        End If
        Cursor = Cursors.Default
    End Sub

    '-------- mapping COA button menu ------------
    Private Sub BBMappingCOA_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles BBMappingCOA.ItemClick
        If formName = "FormSamplePurchase" Then
            FormMappingCOA.report_mark_type = "1"
            FormMappingCOA.ShowDialog()
        ElseIf formName = "FormSampleReceive" Then
            FormMappingCOA.report_mark_type = "2"
            FormMappingCOA.ShowDialog()
        ElseIf formName = "FormMatPurchase" Then
            FormMappingCOA.report_mark_type = "13"
            FormMappingCOA.ShowDialog()
        ElseIf formName = "FormMatRecPurc" Then
            FormMappingCOA.report_mark_type = "16"
            FormMappingCOA.ShowDialog()
        ElseIf formName = "FormMatWO" Then
            FormMappingCOA.report_mark_type = "15"
            FormMappingCOA.ShowDialog()
        ElseIf formName = "FormMatRecWO" Then
            FormMappingCOA.report_mark_type = "17"
            FormMappingCOA.ShowDialog()
        ElseIf formName = "FormMatRet" Then
            If FormMatRet.XTCReturnPruchase.SelectedTabPageIndex = 0 Then 'ret out
                FormMappingCOA.report_mark_type = "18"
                FormMappingCOA.ShowDialog()
            Else 'ret in
                FormMappingCOA.report_mark_type = "19"
                FormMappingCOA.ShowDialog()
            End If
        ElseIf formName = "FormMatAdj" Then
            If FormMatAdj.XTCAdj.SelectedTabPageIndex = 0 Then 'adj in
                FormMappingCOA.report_mark_type = "26"
                FormMappingCOA.ShowDialog()
            Else 'adj out
                FormMappingCOA.report_mark_type = "27"
                FormMappingCOA.ShowDialog()
            End If
        ElseIf formName = "FormSampleAdjustment" Then
            If FormSampleAdjustment.XTCAdj.SelectedTabPageIndex = 0 Then 'adj in
                FormMappingCOA.report_mark_type = "20"
                FormMappingCOA.ShowDialog()
            Else 'adj out
                FormMappingCOA.report_mark_type = "21"
                FormMappingCOA.ShowDialog()
            End If
        ElseIf formName = "FormMatPL" Then
            If FormMatPL.XTCPL.SelectedTabPageIndex = 0 Then 'prod
                FormMappingCOA.report_mark_type = "30"
                FormMappingCOA.ShowDialog()
            ElseIf FormMatPL.XTCPL.SelectedTabPageIndex = 1 Then 'wo mat
                FormMappingCOA.report_mark_type = "30"
                FormMappingCOA.ShowDialog()
            ElseIf FormMatPL.XTCPL.SelectedTabPageIndex = 2 Then 'other
                FormMappingCOA.report_mark_type = "30"
                FormMappingCOA.ShowDialog()
            End If
        ElseIf formName = "FormMatInvoice" Then
            If FormMatInvoice.XTCTabGeneral.SelectedTabPageIndex = 0 Then 'invoice
                FormMappingCOA.report_mark_type = "34"
                FormMappingCOA.ShowDialog()
            ElseIf FormMatInvoice.XTCTabGeneral.SelectedTabPageIndex = 1 Then 'return invoice
                FormMappingCOA.report_mark_type = "35"
                FormMappingCOA.ShowDialog()
            End If
        End If
    End Sub
    '------------LINK MENU---------------------------------
    'MASTER Area
    Private Sub NBArea_LinkClicked(ByVal sender As System.Object, ByVal e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles NBArea.LinkClicked
        Cursor = Cursors.WaitCursor
        Try
            FormMasterArea.MdiParent = Me
            FormMasterArea.Show()
            FormMasterArea.WindowState = FormWindowState.Maximized
            FormMasterArea.Focus()
            RPSubMenu.Visible = True
            RibbonControl.SelectedPage = RPSubMenu
        Catch ex As Exception
            errorProcess()
        End Try
        Cursor = Cursors.Default
    End Sub
    'MASTER ITEM CATEGORY
    Private Sub NavBarItemItemCategory_LinkClicked(ByVal sender As Object, ByVal e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles NavBarItemItemCategory.LinkClicked
        Cursor = Cursors.WaitCursor
        Try
            FormMasterRawMaterialCat.MdiParent = Me
            FormMasterRawMaterialCat.Show()
            FormMasterRawMaterialCat.WindowState = FormWindowState.Maximized
            FormMasterRawMaterialCat.Focus()
        Catch ex As Exception
            errorProcess()
        End Try
        Cursor = Cursors.Default
    End Sub
    'MASTER ITEM SIZE
    Private Sub NavBarItemItemSize_LinkClicked(ByVal sender As System.Object, ByVal e As DevExpress.XtraNavBar.NavBarLinkEventArgs)
        Cursor = Cursors.WaitCursor
        Try
            FormMasterItemSize.MdiParent = Me
            FormMasterItemSize.Show()
            FormMasterItemSize.WindowState = FormWindowState.Maximized
            FormMasterItemSize.Focus()
        Catch ex As Exception
            errorProcess()
        End Try
        Cursor = Cursors.Default
    End Sub
    'MASTER ITEM COLOR-
    Private Sub NBIItemColor_LinkClicked(ByVal sender As System.Object, ByVal e As DevExpress.XtraNavBar.NavBarLinkEventArgs)
        Cursor = Cursors.WaitCursor
        Try
            FormMasterItemColor.MdiParent = Me
            FormMasterItemColor.Show()
            FormMasterItemColor.WindowState = FormWindowState.Maximized
            FormMasterItemColor.Focus()
        Catch ex As Exception
            errorProcess()
        End Try
        Cursor = Cursors.Default
    End Sub
    'MASTER Company Category
    Private Sub NBCompany_category_LinkClicked(ByVal sender As System.Object, ByVal e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles NBCompany_category.LinkClicked
        Cursor = Cursors.WaitCursor
        Try
            FormMasterCompanyCategory.MdiParent = Me
            FormMasterCompanyCategory.Show()
            FormMasterCompanyCategory.WindowState = FormWindowState.Maximized
            FormMasterCompanyCategory.Focus()
        Catch ex As Exception
            errorProcess()
        End Try
        Cursor = Cursors.Default
    End Sub
    'Master UOM
    Private Sub NBUom_LinkClicked(ByVal sender As System.Object, ByVal e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles NBUom.LinkClicked
        Cursor = Cursors.WaitCursor
        Try
            FormMasterUOM.MdiParent = Me
            FormMasterUOM.Show()
            FormMasterUOM.WindowState = FormWindowState.Maximized
            FormMasterUOM.Focus()
        Catch ex As Exception
            errorProcess()
        End Try
        Cursor = Cursors.Default
    End Sub
    'Season
    Private Sub NBSeason_LinkClicked(ByVal sender As System.Object, ByVal e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles NBSeason.LinkClicked
        Cursor = Cursors.WaitCursor
        Try
            FormSeason.MdiParent = Me
            FormSeason.Show()
            FormSeason.WindowState = FormWindowState.Maximized
            FormSeason.Focus()
        Catch ex As Exception
            errorProcess()
        End Try
        Cursor = Cursors.Default
    End Sub
    'Master Departement
    Private Sub NBDepartement_LinkClicked(ByVal sender As System.Object, ByVal e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles NBDepartement.LinkClicked
        Cursor = Cursors.WaitCursor
        Try
            FormMasterDepartement.MdiParent = Me
            FormMasterDepartement.Show()
            FormMasterDepartement.WindowState = FormWindowState.Maximized
            FormMasterDepartement.Focus()
        Catch ex As Exception
            errorProcess()
        End Try
        Cursor = Cursors.Default
    End Sub
    'Master User
    Private Sub NBUser_LinkClicked(ByVal sender As System.Object, ByVal e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles NBUser.LinkClicked
        Cursor = Cursors.WaitCursor
        Try
            FormMasterUser.MdiParent = Me
            FormMasterUser.Show()
            FormMasterUser.WindowState = FormWindowState.Maximized
            FormMasterUser.Focus()
        Catch ex As Exception
            errorProcess()
        End Try
        Cursor = Cursors.Default
    End Sub
    'Master Access
    Private Sub NBAccessUser_LinkClicked(ByVal sender As System.Object, ByVal e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles NBAccessUser.LinkClicked
        Try
            FormAccess.MdiParent = Me
            FormAccess.Show()
            FormAccess.WindowState = FormWindowState.Maximized
            FormAccess.Focus()
            BBMapping.Visibility = DevExpress.XtraBars.BarItemVisibility.Never
        Catch ex As Exception
            errorProcess()
            Close()
        End Try
    End Sub
    'Master Company
    Private Sub BBCompContact_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles BBCompContact.ItemClick
        Cursor = Cursors.WaitCursor
        Try
            FormMasterCompanyContact.id_company = FormMasterCompany.GVCompany.GetFocusedRowCellDisplayText("id_company").ToString
            FormMasterCompanyContact.ShowDialog()
        Catch ex As Exception

        End Try
        Cursor = Cursors.Default
    End Sub
    'Company
    Private Sub NBCompany_LinkClicked(ByVal sender As System.Object, ByVal e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles NBCompany.LinkClicked
        Cursor = Cursors.WaitCursor
        Try
            FormMasterCompany.MdiParent = Me
            FormMasterCompany.Show()
            FormMasterCompany.WindowState = FormWindowState.Maximized
            FormMasterCompany.Focus()
            FormMasterCompany.Visible = True
        Catch ex As Exception
        End Try
        Cursor = Cursors.Default
    End Sub
    'Master Raw Material
    Private Sub NBRawMaterial_LinkClicked(ByVal sender As System.Object, ByVal e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles NBRawMaterial.LinkClicked
        Cursor = Cursors.WaitCursor
        Try
            FormMasterRawMaterial.MdiParent = Me
            FormMasterRawMaterial.Show()
            FormMasterRawMaterial.WindowState = FormWindowState.Maximized
            FormMasterRawMaterial.Focus()
        Catch ex As Exception
            errorProcess()
        End Try
        Cursor = Cursors.Default
    End Sub
    'Master OVH
    Private Sub NBOVH_LinkClicked(ByVal sender As System.Object, ByVal e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles NBOVH.LinkClicked
        Cursor = Cursors.WaitCursor
        Try
            FormMasterOVH.MdiParent = Me
            FormMasterOVH.Show()
            FormMasterOVH.WindowState = FormWindowState.Maximized
            FormMasterOVH.Focus()
        Catch ex As Exception
            errorProcess()
        End Try
        Cursor = Cursors.Default
    End Sub
    'Setup Raw Mat Code
    Private Sub NBRawMatCode_LinkClicked(ByVal sender As System.Object, ByVal e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles NBRawMatCode.LinkClicked
        Cursor = Cursors.WaitCursor
        Try
            FormSetupRawMatCode.MdiParent = Me
            FormSetupRawMatCode.Show()
            FormSetupRawMatCode.WindowState = FormWindowState.Maximized
            FormSetupRawMatCode.Focus()
        Catch ex As Exception
            errorProcess()
            FormSetupRawMatCode.Dispose()
        End Try
        Cursor = Cursors.Default
    End Sub
    'Production Demand
    Private Sub NBProdDemand_LinkClicked(ByVal sender As System.Object, ByVal e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles NBProdDemand.LinkClicked
        Cursor = Cursors.WaitCursor
        Try
            FormProdDemand.MdiParent = Me
            FormProdDemand.Show()
            FormProdDemand.WindowState = FormWindowState.Maximized
            FormProdDemand.Focus()
        Catch ex As Exception
            errorProcess()
            FormProdDemand.Dispose()
        End Try
        Cursor = Cursors.Default
    End Sub
    'Link Code
    Private Sub NBCode_LinkClicked(ByVal sender As System.Object, ByVal e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles NBCode.LinkClicked
        Cursor = Cursors.WaitCursor
        Try
            FormMasterCode.MdiParent = Me
            FormMasterCode.Show()
            FormMasterCode.WindowState = FormWindowState.Maximized
            FormMasterCode.Focus()
        Catch ex As Exception
            errorProcess()
        End Try
        Cursor = Cursors.Default
    End Sub
    'Link Code Template
    Private Sub NBCodeTemplate_LinkClicked(ByVal sender As System.Object, ByVal e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles NBCodeTemplate.LinkClicked
        Cursor = Cursors.WaitCursor
        Try
            FormTemplateCode.MdiParent = Me
            FormTemplateCode.Show()
            FormTemplateCode.WindowState = FormWindowState.Maximized
            FormTemplateCode.Focus()
        Catch ex As Exception
            errorProcess()
        End Try
        Cursor = Cursors.Default
    End Sub
    'Link Sample
    Private Sub NBSample_LinkClicked(ByVal sender As System.Object, ByVal e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles NBSample.LinkClicked
        Cursor = Cursors.WaitCursor
        Try
            FormMasterSample.MdiParent = Me
            FormMasterSample.Show()
            FormMasterSample.WindowState = FormWindowState.Maximized
            FormMasterSample.Focus()
        Catch ex As Exception
            errorProcess()
        End Try
        Cursor = Cursors.Default
    End Sub
    'Link Product
    Private Sub NBProduct_LinkClicked(ByVal sender As System.Object, ByVal e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles NBProduct.LinkClicked
        Cursor = Cursors.WaitCursor
        Try
            FormMasterProduct.MdiParent = Me
            FormMasterProduct.Show()
            FormMasterProduct.WindowState = FormWindowState.Maximized
            FormMasterProduct.Focus()
        Catch ex As Exception
            errorProcess()
        End Try
        Cursor = Cursors.Default
    End Sub
    'Link BOM
    Private Sub NBBom_LinkClicked(ByVal sender As System.Object, ByVal e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles NBBom.LinkClicked
        Cursor = Cursors.WaitCursor
        Try
            FormBOM.MdiParent = Me
            FormBOM.Show()
            FormBOM.WindowState = FormWindowState.Maximized
            FormBOM.Focus()
        Catch ex As Exception
            errorProcess()
        End Try
        Cursor = Cursors.Default
    End Sub
    'Link Picture Location
    Private Sub NBPicLocation_LinkClicked(ByVal sender As System.Object, ByVal e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles NBPicLocation.LinkClicked
        Cursor = Cursors.WaitCursor
        Try
            FormSetupPicLocation.ShowDialog()
            FormBOM.Focus()
        Catch ex As Exception
            errorProcess()
        End Try
        Cursor = Cursors.Default
    End Sub
    'Link Accounnt Edit
    Private Sub BBEditAccount_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles BBEditAccount.ItemClick
        FormAccount.change = True
        FormAccount.ShowDialog()
    End Sub
    'Master Raw Material Category
    Private Sub NBRawMatCat_LinkClicked(ByVal sender As System.Object, ByVal e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles NBRawMatCat.LinkClicked
        Cursor = Cursors.WaitCursor
        Try
            FormMasterRawMaterialCat.MdiParent = Me
            FormMasterRawMaterialCat.Show()
            FormMasterRawMaterialCat.WindowState = FormWindowState.Maximized
            FormMasterRawMaterialCat.Focus()
        Catch ex As Exception
            errorProcess()
        End Try
        Cursor = Cursors.Default
    End Sub
    'Sample Packing List
    Private Sub NBPLSample_LinkClicked(ByVal sender As System.Object, ByVal e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles NBPLSample.LinkClicked
        Cursor = Cursors.WaitCursor
        Try
            FormSamplePL.MdiParent = Me
            FormSamplePL.Show()
            FormSamplePL.WindowState = FormWindowState.Maximized
            FormSamplePL.Focus()
        Catch ex As Exception
            errorProcess()
        End Try
        Cursor = Cursors.Default
    End Sub
    'header number
    Private Sub NBHeadNumber_LinkClicked(ByVal sender As System.Object, ByVal e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles NBHeadNumber.LinkClicked
        Cursor = Cursors.WaitCursor
        'Try
        FormSetupNumberHeader.ShowDialog()
        FormSetupNumberHeader.Focus()
        'Catch ex As Exception
        '    errorProcess()
        'End Try
        Cursor = Cursors.Default
    End Sub
    'Sample Purchase
    Private Sub NBSamplePurchase_LinkClicked(ByVal sender As System.Object, ByVal e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles NBSamplePurchase.LinkClicked
        Cursor = Cursors.WaitCursor
        Try
            FormSamplePurchase.MdiParent = Me
            FormSamplePurchase.Show()
            FormSamplePurchase.WindowState = FormWindowState.Maximized
            FormSamplePurchase.Focus()
        Catch ex As Exception
            errorProcess()
        End Try
        Cursor = Cursors.Default
    End Sub
    'Sample Receive
    Private Sub NBSampleReceive_LinkClicked(ByVal sender As System.Object, ByVal e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles NBSampleReceive.LinkClicked
        Cursor = Cursors.WaitCursor
        Try
            FormSampleReceive.MdiParent = Me
            FormSampleReceive.Show()
            FormSampleReceive.WindowState = FormWindowState.Maximized
            FormSampleReceive.Focus()
        Catch ex As Exception
            errorProcess()
        End Try
        Cursor = Cursors.Default
    End Sub
    'Sample PR
    Private Sub NBSamplePR_LinkClicked(ByVal sender As System.Object, ByVal e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles NBSamplePR.LinkClicked
        Cursor = Cursors.WaitCursor
        Try
            FormSamplePR.MdiParent = Me
            FormSamplePR.Show()
            FormSamplePR.WindowState = FormWindowState.Maximized
            FormSamplePR.Focus()
        Catch ex As Exception
            errorProcess()
        End Try
        Cursor = Cursors.Default
    End Sub
    'Master Warehouse & LOcator
    Private Sub NBWH_LinkClicked(ByVal sender As System.Object, ByVal e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles NBWH.LinkClicked
        Cursor = Cursors.WaitCursor
        Try
            FormMasterWH.Dispose()
            FormMasterWH.MdiParent = Me
            FormMasterWH.Show()
            FormMasterWH.WindowState = FormWindowState.Maximized
            FormMasterWH.Focus()
        Catch ex As Exception
            errorProcess()
        End Try
        Cursor = Cursors.Default
    End Sub
    'Receipt Sample
    Private Sub NBReceiptSample_LinkClicked(ByVal sender As System.Object, ByVal e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles NBReceiptSample.LinkClicked
        Cursor = Cursors.WaitCursor
        Try
            FormSampleReceipt.MdiParent = Me
            FormSampleReceipt.Show()
            FormSampleReceipt.WindowState = FormWindowState.Maximized
            FormSampleReceipt.Focus()
        Catch ex As Exception
            errorProcess()
        End Try
        Cursor = Cursors.Default
    End Sub
    'Return Sample
    Private Sub NBROSample_LinkClicked(ByVal sender As System.Object, ByVal e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles NBROSample.LinkClicked
        Cursor = Cursors.WaitCursor
        Try
            FormSampleRet.MdiParent = Me
            FormSampleRet.Show()
            FormSampleRet.WindowState = FormWindowState.Maximized
            FormSampleRet.Focus()
        Catch ex As Exception
            errorProcess()
        End Try
        Cursor = Cursors.Default
    End Sub

    Private Sub NBWork_LinkClicked(ByVal sender As System.Object, ByVal e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles NBWork.LinkClicked
        Cursor = Cursors.WaitCursor
        Try
            FormWork.MdiParent = Me
            FormWork.Show()
            FormWork.WindowState = FormWindowState.Maximized
            FormWork.Focus()
        Catch ex As Exception
            errorProcess()
        End Try
        Cursor = Cursors.Default
    End Sub
    'Packing List Delivery
    Private Sub NBPLDel_LinkClicked(ByVal sender As System.Object, ByVal e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles NBPLDel.LinkClicked
        Cursor = Cursors.WaitCursor
        Try
            FormSamplePLDel.MdiParent = Me
            FormSamplePLDel.Show()
            FormSamplePLDel.WindowState = FormWindowState.Maximized
            FormSamplePLDel.Focus()
        Catch ex As Exception
            errorProcess()
        End Try
        Cursor = Cursors.Default
    End Sub
    'Sample Requisition
    Private Sub NBReqSample_LinkClicked(ByVal sender As System.Object, ByVal e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles NBReqSample.LinkClicked
        Cursor = Cursors.WaitCursor
        Try
            FormSampleReq.MdiParent = Me
            FormSampleReq.Show()
            FormSampleReq.WindowState = FormWindowState.Maximized
            FormSampleReq.Focus()
        Catch ex As Exception
            errorProcess()
        End Try
        Cursor = Cursors.Default
    End Sub
    Private Sub NBMarkAssign_LinkClicked(ByVal sender As System.Object, ByVal e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles NBMarkAssign.LinkClicked
        Cursor = Cursors.WaitCursor
        Try
            FormMarkAssign.MdiParent = Me
            FormMarkAssign.Show()
            FormMarkAssign.WindowState = FormWindowState.Maximized
            FormMarkAssign.Focus()
        Catch ex As Exception
            errorProcess()
        End Try
        Cursor = Cursors.Default
    End Sub

    Private Sub NBSamplePlan_LinkClicked(ByVal sender As System.Object, ByVal e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles NBSamplePlan.LinkClicked
        Cursor = Cursors.WaitCursor
        Try
            FormSamplePlan.MdiParent = Me
            FormSamplePlan.Show()
            FormSamplePlan.WindowState = FormWindowState.Maximized
            FormSamplePlan.Focus()
        Catch ex As Exception
            errorProcess()
        End Try
        Cursor = Cursors.Default
    End Sub

    Private Sub NBMatPurchase_LinkClicked(ByVal sender As System.Object, ByVal e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles NBMatPurchase.LinkClicked
        Cursor = Cursors.WaitCursor
        Try
            FormMatPurchase.MdiParent = Me
            FormMatPurchase.Show()
            FormMatPurchase.WindowState = FormWindowState.Maximized
            FormMatPurchase.Focus()
        Catch ex As Exception
            errorProcess()
        End Try
        Cursor = Cursors.Default
    End Sub

    Private Sub NBReturnSample_LinkClicked(ByVal sender As System.Object, ByVal e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles NBReturnSample.LinkClicked
        Cursor = Cursors.WaitCursor
        Try
            FormSampleReturn.MdiParent = Me
            FormSampleReturn.Show()
            FormSampleReturn.WindowState = FormWindowState.Maximized
            FormSampleReturn.Focus()
        Catch ex As Exception
            errorProcess()
        End Try
        Cursor = Cursors.Default
    End Sub

    Private Sub NBMatWO_LinkClicked(ByVal sender As System.Object, ByVal e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles NBMatWO.LinkClicked
        Cursor = Cursors.WaitCursor
        Try
            FormMatWO.MdiParent = Me
            FormMatWO.Show()
            FormMatWO.WindowState = FormWindowState.Maximized
            FormMatWO.Focus()
        Catch ex As Exception
            errorProcess()
        End Try
        Cursor = Cursors.Default
    End Sub

    Private Sub NBMatRecPurc_LinkClicked(ByVal sender As System.Object, ByVal e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles NBMatRecPurc.LinkClicked
        Cursor = Cursors.WaitCursor
        Try
            FormMatRecPurc.MdiParent = Me
            FormMatRecPurc.Show()
            FormMatRecPurc.WindowState = FormWindowState.Maximized
            FormMatRecPurc.Focus()
        Catch ex As Exception
            errorProcess()
        End Try
        Cursor = Cursors.Default
    End Sub

    Private Sub NBMatRecWO_LinkClicked(ByVal sender As System.Object, ByVal e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles NBMatRecWO.LinkClicked
        Cursor = Cursors.WaitCursor
        Try
            FormMatRecWO.MdiParent = Me
            FormMatRecWO.Show()
            FormMatRecWO.WindowState = FormWindowState.Maximized
            FormMatRecWO.Focus()
        Catch ex As Exception
            errorProcess()
        End Try
        Cursor = Cursors.Default
    End Sub

    Private Sub NBMatRet_LinkClicked(ByVal sender As System.Object, ByVal e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles NBMatRet.LinkClicked
        Cursor = Cursors.WaitCursor
        Try
            FormMatRet.MdiParent = Me
            FormMatRet.Show()
            FormMatRet.WindowState = FormWindowState.Maximized
            FormMatRet.Focus()
        Catch ex As Exception
            errorProcess()
        End Try
        Cursor = Cursors.Default
    End Sub

    Private Sub NBAdjSample_LinkClicked(ByVal sender As System.Object, ByVal e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles NBAdjSample.LinkClicked
        Cursor = Cursors.WaitCursor
        Try
            FormSampleAdjustment.MdiParent = Me
            FormSampleAdjustment.Show()
            FormSampleAdjustment.WindowState = FormWindowState.Maximized
            FormSampleAdjustment.Focus()
        Catch ex As Exception
            errorProcess()
        End Try
        Cursor = Cursors.Default
    End Sub

    Private Sub NBProdOrder_LinkClicked(ByVal sender As System.Object, ByVal e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles NBProdOrder.LinkClicked
        Cursor = Cursors.WaitCursor
        Try
            FormProduction.MdiParent = Me
            FormProduction.Show()
            FormProduction.WindowState = FormWindowState.Maximized
            FormProduction.Focus()
        Catch ex As Exception
            errorProcess()
        End Try
        Cursor = Cursors.Default
    End Sub

    Private Sub NBMatPR_LinkClicked(ByVal sender As System.Object, ByVal e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles NBMatPR.LinkClicked
        Cursor = Cursors.WaitCursor
        'Try
        FormMatPR.MdiParent = Me
        FormMatPR.Show()
        FormMatPR.WindowState = FormWindowState.Maximized
        FormMatPR.Focus()
        ' Catch ex As Exception
        'errorProcess()
        'End Try
        Cursor = Cursors.Default
    End Sub

    Private Sub NBMatPRWO_LinkClicked(ByVal sender As System.Object, ByVal e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles NBMatPRWO.LinkClicked
        Cursor = Cursors.WaitCursor
        FormMatPRWO.MdiParent = Me
        FormMatPRWO.Show()
        FormMatPRWO.WindowState = FormWindowState.Maximized
        FormMatPRWO.Focus()
        Cursor = Cursors.Default
    End Sub

    Private Sub NBAdjMat_LinkClicked(ByVal sender As System.Object, ByVal e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles NBAdjMat.LinkClicked
        Cursor = Cursors.WaitCursor
        FormMatAdj.MdiParent = Me
        FormMatAdj.Show()
        FormMatAdj.WindowState = FormWindowState.Maximized
        FormMatAdj.Focus()
        Cursor = Cursors.Default
    End Sub

    Private Sub NBProdRec_LinkClicked(ByVal sender As System.Object, ByVal e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles NBProdRec.LinkClicked
        Cursor = Cursors.WaitCursor
        FormProductionRec.MdiParent = Me
        FormProductionRec.Show()
        FormProductionRec.WindowState = FormWindowState.Maximized
        FormProductionRec.Focus()
        Cursor = Cursors.Default
    End Sub

    Private Sub NBProdReturn_LinkClicked(ByVal sender As System.Object, ByVal e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles NBProdReturn.LinkClicked
        Cursor = Cursors.WaitCursor
        FormProductionRet.MdiParent = Me
        FormProductionRet.Show()
        FormProductionRet.WindowState = FormWindowState.Maximized
        FormProductionRet.Focus()
        Cursor = Cursors.Default
    End Sub

    Private Sub NBMatPL_LinkClicked(ByVal sender As System.Object, ByVal e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles NBMatPL.LinkClicked
        Cursor = Cursors.WaitCursor
        Try
            FormMatPL.MdiParent = Me
            FormMatPL.Show()
            FormMatPL.WindowState = FormWindowState.Maximized
            FormMatPL.Focus()
        Catch ex As Exception
            errorProcess()
        End Try
        Cursor = Cursors.Default
    End Sub

    Private Sub NBMatMRS_LinkClicked(ByVal sender As System.Object, ByVal e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles NBMatMRS.LinkClicked
        Cursor = Cursors.WaitCursor
        Try
            FormMatMRS.MdiParent = Me
            FormMatMRS.Show()
            FormMatMRS.WindowState = FormWindowState.Maximized
            FormMatMRS.Focus()
        Catch ex As Exception
            errorProcess()
        End Try
        Cursor = Cursors.Default
    End Sub

    Private Sub NBProdPLToWH_LinkClicked(ByVal sender As System.Object, ByVal e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles NBProdPLToWH.LinkClicked
        Cursor = Cursors.WaitCursor
        Try
            FormProductionPLToWH.MdiParent = Me
            FormProductionPLToWH.Show()
            FormProductionPLToWH.WindowState = FormWindowState.Maximized
            FormProductionPLToWH.Focus()
        Catch ex As Exception
            errorProcess()
        End Try
        Cursor = Cursors.Default
    End Sub

    Private Sub NBMatInvoice_LinkClicked(ByVal sender As System.Object, ByVal e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles NBMatInvoice.LinkClicked
        Cursor = Cursors.WaitCursor
        Try
            FormMatInvoice.MdiParent = Me
            FormMatInvoice.Show()
            FormMatInvoice.WindowState = FormWindowState.Maximized
            FormMatInvoice.Focus()
        Catch ex As Exception
            errorProcess()
        End Try
        Cursor = Cursors.Default
    End Sub

    Private Sub NBAcc_LinkClicked(ByVal sender As System.Object, ByVal e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles NBAcc.LinkClicked
        Cursor = Cursors.WaitCursor
        Try
            FormAccounting.MdiParent = Me
            FormAccounting.Show()
            FormAccounting.WindowState = FormWindowState.Maximized
            FormAccounting.Focus()
        Catch ex As Exception
            errorProcess()
        End Try
        Cursor = Cursors.Default
    End Sub

    Private Sub NBAccJounal_LinkClicked(ByVal sender As System.Object, ByVal e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles NBAccJournal.LinkClicked
        Cursor = Cursors.WaitCursor
        Try
            FormAccountingJournal.MdiParent = Me
            FormAccountingJournal.Show()
            FormAccountingJournal.WindowState = FormWindowState.Maximized
            FormAccountingJournal.Focus()
        Catch ex As Exception
            errorProcess()
        End Try
        Cursor = Cursors.Default
    End Sub

    Private Sub NBProdRecWH_LinkClicked(ByVal sender As System.Object, ByVal e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles NBProdRecWH.LinkClicked
        Cursor = Cursors.WaitCursor
        Try
            FormProductionPLToWHRec.MdiParent = Me
            FormProductionPLToWHRec.Show()
            FormProductionPLToWHRec.WindowState = FormWindowState.Maximized
            FormProductionPLToWHRec.Focus()
        Catch ex As Exception
            errorProcess()
        End Try
        Cursor = Cursors.Default
    End Sub

    Private Sub NBSalesTarget_LinkClicked(ByVal sender As System.Object, ByVal e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles NBSalesTarget.LinkClicked
        Cursor = Cursors.WaitCursor
        Try
            FormSalesTarget.MdiParent = Me
            FormSalesTarget.Show()
            FormSalesTarget.WindowState = FormWindowState.Maximized
            FormSalesTarget.Focus()
        Catch ex As Exception
            errorProcess()
        End Try
        Cursor = Cursors.Default
    End Sub

    Private Sub NBSalesOrder_LinkClicked(ByVal sender As System.Object, ByVal e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles NBSalesOrder.LinkClicked
        Cursor = Cursors.WaitCursor
        'Try
        FormSalesOrder.MdiParent = Me
        FormSalesOrder.Show()
        FormSalesOrder.WindowState = FormWindowState.Maximized
        FormSalesOrder.Focus()
        'Catch ex As Exception
        'errorProcess()
        'End Try
        Cursor = Cursors.Default
    End Sub

    Private Sub NBSalesDelOrder_LinkClicked(ByVal sender As System.Object, ByVal e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles NBSalesDelOrder.LinkClicked
        Cursor = Cursors.WaitCursor
        Try
            FormSalesDelOrder.MdiParent = Me
            FormSalesDelOrder.Show()
            FormSalesDelOrder.WindowState = FormWindowState.Maximized
            FormSalesDelOrder.Focus()
        Catch ex As Exception
            errorProcess()
        End Try
        Cursor = Cursors.Default
    End Sub

    Private Sub NBSalesReturnOrder_LinkClicked(ByVal sender As System.Object, ByVal e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles NBSalesReturnOrder.LinkClicked
        Cursor = Cursors.WaitCursor
        Try
            FormSalesReturnOrder.MdiParent = Me
            FormSalesReturnOrder.Show()
            FormSalesReturnOrder.WindowState = FormWindowState.Maximized
            FormSalesReturnOrder.Focus()
        Catch ex As Exception
            errorProcess()
        End Try
        Cursor = Cursors.Default
    End Sub

    Private Sub NBProdWOPR_LinkClicked(ByVal sender As System.Object, ByVal e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles NBProdWOPR.LinkClicked
        Cursor = Cursors.WaitCursor
        Try
            FormProdPRWO.MdiParent = Me
            FormProdPRWO.Show()
            FormProdPRWO.WindowState = FormWindowState.Maximized
            FormProdPRWO.Focus()
        Catch ex As Exception
            errorProcess()
        End Try
        Cursor = Cursors.Default
    End Sub
    Private Sub NBJournalAdj_LinkClicked(ByVal sender As System.Object, ByVal e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles NBJournalAdj.LinkClicked
        Cursor = Cursors.WaitCursor
        Try
            FormAccountingJournalAdj.MdiParent = Me
            FormAccountingJournalAdj.Show()
            FormAccountingJournalAdj.WindowState = FormWindowState.Maximized
            FormAccountingJournalAdj.Focus()
        Catch ex As Exception
            errorProcess()
        End Try
        Cursor = Cursors.Default
    End Sub

    Private Sub NBSalesReturn_LinkClicked(ByVal sender As System.Object, ByVal e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles NBSalesReturn.LinkClicked
        Cursor = Cursors.WaitCursor
        Try
            FormSalesReturn.MdiParent = Me
            FormSalesReturn.Show()
            FormSalesReturn.WindowState = FormWindowState.Maximized
            FormSalesReturn.Focus()
        Catch ex As Exception
            errorProcess()
        End Try
        Cursor = Cursors.Default
    End Sub

    Private Sub NBSalesPOS_LinkClicked(ByVal sender As System.Object, ByVal e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles NBSalesPOS.LinkClicked
        Cursor = Cursors.WaitCursor
        Try
            FormSalesPOS.MdiParent = Me
            FormSalesPOS.Show()
            FormSalesPOS.WindowState = FormWindowState.Maximized
            FormSalesPOS.Focus()
        Catch ex As Exception
            errorProcess()
        End Try
        Cursor = Cursors.Default
    End Sub

    Private Sub NBReturnQC_LinkClicked(ByVal sender As System.Object, ByVal e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles NBSalesReturnQC.LinkClicked
        Cursor = Cursors.WaitCursor
        Try
            FormSalesReturnQC.MdiParent = Me
            FormSalesReturnQC.Show()
            FormSalesReturnQC.WindowState = FormWindowState.Maximized

            FormSalesReturnQC.Focus()
        Catch ex As Exception
            errorProcess()
        End Try
        Cursor = Cursors.Default
    End Sub

    Private Sub NBSalesInvoice_LinkClicked(ByVal sender As System.Object, ByVal e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles NBSalesInvoice.LinkClicked
        Cursor = Cursors.WaitCursor
        Try
            FormSalesInvoice.MdiParent = Me
            FormSalesInvoice.Show()
            FormSalesInvoice.WindowState = FormWindowState.Maximized
            FormSalesInvoice.Focus()
        Catch ex As Exception
            errorProcess()
        End Try
        Cursor = Cursors.Default
    End Sub

    Private Sub NBFGSoStore_LinkClicked(ByVal sender As System.Object, ByVal e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles NBFGSoStore.LinkClicked
        Cursor = Cursors.WaitCursor
        Try
            FormFGStockOpnameStore.MdiParent = Me
            FormFGStockOpnameStore.Show()
            FormFGStockOpnameStore.WindowState = FormWindowState.Maximized
            FormFGStockOpnameStore.Focus()
        Catch ex As Exception
            errorProcess()
        End Try
        Cursor = Cursors.Default
    End Sub

    Private Sub NBFGMissing_LinkClicked(ByVal sender As System.Object, ByVal e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles NBFGMissing.LinkClicked
        Cursor = Cursors.WaitCursor
        Try
            FormFGMissing.MdiParent = Me
            FormFGMissing.Show()
            FormFGMissing.WindowState = FormWindowState.Maximized
            FormFGMissing.Focus()
        Catch ex As Exception
            errorProcess()
        End Try
        Cursor = Cursors.Default
    End Sub

    Private Sub NBFGMissingInvoice_LinkClicked(ByVal sender As System.Object, ByVal e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles NBFGMissingInvoice.LinkClicked
        Cursor = Cursors.WaitCursor
        Try
            FormFGMissingInvoice.MdiParent = Me
            FormFGMissingInvoice.Show()
            FormFGMissingInvoice.WindowState = FormWindowState.Maximized
            FormFGMissingInvoice.Focus()
        Catch ex As Exception
            errorProcess()
        End Try
        Cursor = Cursors.Default
    End Sub

    Private Sub NBFGSOWH_LinkClicked(ByVal sender As System.Object, ByVal e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles NBFGSOWH.LinkClicked
        Cursor = Cursors.WaitCursor
        Try
            FormFGStockOpnameWH.MdiParent = Me
            FormFGStockOpnameWH.Show()
            FormFGStockOpnameWH.WindowState = FormWindowState.Maximized
            FormFGStockOpnameWH.Focus()
        Catch ex As Exception
            errorProcess()
        End Try
        Cursor = Cursors.Default
    End Sub

    Private Sub NBMatSO_LinkClicked(ByVal sender As System.Object, ByVal e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles NBMatSO.LinkClicked
        Cursor = Cursors.WaitCursor
        Try
            FormMatStockOpname.MdiParent = Me
            FormMatStockOpname.Show()
            FormMatStockOpname.WindowState = FormWindowState.Maximized
            FormMatStockOpname.Focus()
        Catch ex As Exception
            errorProcess()
        End Try
        Cursor = Cursors.Default
    End Sub

    Private Sub NBFGAdj_LinkClicked(ByVal sender As System.Object, ByVal e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles NBFGAdj.LinkClicked
        Cursor = Cursors.WaitCursor
        Try
            FormFGAdj.MdiParent = Me
            FormFGAdj.Show()
            FormFGAdj.WindowState = FormWindowState.Maximized
            FormFGAdj.Focus()
        Catch ex As Exception
            errorProcess()
        End Try
        Cursor = Cursors.Default
    End Sub

    Private Sub NBFGTrf_LinkClicked(ByVal sender As System.Object, ByVal e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles NBFGTrf.LinkClicked
        Cursor = Cursors.WaitCursor
        Try
            FormFGTrf.MdiParent = Me
            FormFGTrf.Show()
            FormFGTrf.WindowState = FormWindowState.Maximized
            FormFGTrf.Focus()
        Catch ex As Exception
            errorProcess()
        End Try
        Cursor = Cursors.Default
    End Sub

    Private Sub NBFGTrfRec_LinkClicked(ByVal sender As System.Object, ByVal e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles NBFGTrfRec.LinkClicked
        Cursor = Cursors.WaitCursor
        Try
            FormFGTrfReceive.MdiParent = Me
            FormFGTrfReceive.Show()
            FormFGTrfReceive.WindowState = FormWindowState.Maximized
            FormFGTrfReceive.Focus()
        Catch ex As Exception
            errorProcess()
        End Try
        Cursor = Cursors.Default
    End Sub

    Private Sub NBFGTracking_LinkClicked(ByVal sender As System.Object, ByVal e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles NBFGTracking.LinkClicked
        Cursor = Cursors.WaitCursor
        Try
            FormFGTracking.MdiParent = Me
            FormFGTracking.Show()
            FormFGTracking.WindowState = FormWindowState.Maximized
            FormFGTracking.Focus()
        Catch ex As Exception
            errorProcess()
        End Try
        Cursor = Cursors.Default
    End Sub

    Private Sub NBFGStock_LinkClicked(ByVal sender As System.Object, ByVal e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles NBFGStock.LinkClicked
        Cursor = Cursors.WaitCursor
        Try
            FormFGStock.MdiParent = Me
            FormFGStock.Show()
            FormFGStock.WindowState = FormWindowState.Maximized
            FormFGStock.Focus()
        Catch ex As Exception
            errorProcess()
        End Try
        Cursor = Cursors.Default
    End Sub

    Private Sub NBAccSum_LinkClicked(ByVal sender As System.Object, ByVal e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles NBAccSum.LinkClicked
        Cursor = Cursors.WaitCursor
        Try
            FormAccountingSummary.MdiParent = Me
            FormAccountingSummary.Show()
            FormAccountingSummary.WindowState = FormWindowState.Maximized
            FormAccountingSummary.Focus()
        Catch ex As Exception
            errorProcess()
        End Try
        Cursor = Cursors.Default
    End Sub

    Private Sub NBAccFY_LinkClicked(ByVal sender As System.Object, ByVal e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles NBAccFY.LinkClicked
        Cursor = Cursors.WaitCursor
        Try
            FormAccountingFYear.MdiParent = Me
            FormAccountingFYear.Show()
            FormAccountingFYear.WindowState = FormWindowState.Maximized
            FormAccountingFYear.Focus()
        Catch ex As Exception
            errorProcess()
        End Try
        Cursor = Cursors.Default
    End Sub

    Private Sub NBMatStock_LinkClicked(ByVal sender As System.Object, ByVal e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles NBMatStock.LinkClicked
        Cursor = Cursors.WaitCursor
        Try
            FormMatStock.MdiParent = Me
            FormMatStock.Show()
            FormMatStock.WindowState = FormWindowState.Maximized
            FormMatStock.Focus()
        Catch ex As Exception
            errorProcess()
        End Try
        Cursor = Cursors.Default
    End Sub

    Private Sub NBSampleStock_LinkClicked(ByVal sender As System.Object, ByVal e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles NBSampleStock.LinkClicked
        Cursor = Cursors.WaitCursor
        Try
            FormSampleStock.MdiParent = Me
            FormSampleStock.Show()
            FormSampleStock.WindowState = FormWindowState.Maximized
            FormSampleStock.Focus()
        Catch ex As Exception
            errorProcess()
        End Try
        Cursor = Cursors.Default
    End Sub

    Private Sub NBEmployee_LinkClicked(ByVal sender As System.Object, ByVal e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles NBEmployee.LinkClicked
        Cursor = Cursors.WaitCursor
        Try
            FormMasterEmployee.MdiParent = Me
            FormMasterEmployee.Show()
            FormMasterEmployee.WindowState = FormWindowState.Maximized
            FormMasterEmployee.Focus()
        Catch ex As Exception
            errorProcess()
        End Try
        Cursor = Cursors.Default
    End Sub

    'Feedback
    Private Sub BBFeedback_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles BBFeedback.ItemClick
        Cursor = Cursors.WaitCursor
        Try
            FormFeedback.ShowDialog()
            FormFeedback.WindowState = FormWindowState.Maximized
            FormFeedback.Focus()
        Catch ex As Exception
            errorProcess()
        End Try
        Cursor = Cursors.Default
    End Sub

    'Delivery Sample To Warehouse
    Private Sub NBSampleDelivery_LinkClicked(ByVal sender As System.Object, ByVal e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles NBSampleDelivery.LinkClicked
        Cursor = Cursors.WaitCursor
        Try
            FormSampleDel.MdiParent = Me
            FormSampleDel.Show()
            FormSampleDel.WindowState = FormWindowState.Maximized
            FormSampleDel.Focus()
        Catch ex As Exception
            errorProcess()
        End Try
        Cursor = Cursors.Default
    End Sub

    Private Sub BBAbout_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles BBAbout.ItemClick
        about()
        If id_role_login = id_super_user Then
            FormSuperUser.ShowDialog()
        End If
    End Sub

    Sub about()
        infoCustom("Version " + Application.ProductVersion.ToString)
    End Sub

    'Rec Delivery Sample To Warehouse
    Private Sub NBSampleDelRec_LinkClicked(ByVal sender As System.Object, ByVal e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles NBSampleDelRec.LinkClicked
        Cursor = Cursors.WaitCursor
        Try
            FormSampleDelRec.MdiParent = Me
            FormSampleDelRec.Show()
            FormSampleDelRec.WindowState = FormWindowState.Maximized
            FormSampleDelRec.Focus()
        Catch ex As Exception
            errorProcess()
        End Try
        Cursor = Cursors.Default
    End Sub
    'Barcode Sample
    Private Sub NBSampleBarcode_LinkClicked(ByVal sender As System.Object, ByVal e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles NBSampleBarcode.LinkClicked
        Cursor = Cursors.WaitCursor
        Try
            FormSamplePrintBarcode.MdiParent = Me
            FormSamplePrintBarcode.Show()
            FormSamplePrintBarcode.WindowState = FormWindowState.Maximized
            FormSamplePrintBarcode.Focus()
        Catch ex As Exception
            errorProcess()
        End Try
        Cursor = Cursors.Default
    End Sub

    'Sample Order
    Private Sub NBSampleOrder_LinkClicked(ByVal sender As System.Object, ByVal e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles NBSampleOrder.LinkClicked
        Cursor = Cursors.WaitCursor
        Try
            FormSampleOrder.MdiParent = Me
            FormSampleOrder.Show()
            FormSampleOrder.WindowState = FormWindowState.Maximized
            FormSampleOrder.Focus()
        Catch ex As Exception
            errorProcess()
        End Try
        Cursor = Cursors.Default
    End Sub

    'Sample Delivery Order
    Private Sub NBSampleDelOrder_LinkClicked(ByVal sender As System.Object, ByVal e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles NBSampleDelOrder.LinkClicked
        Cursor = Cursors.WaitCursor
        Try
            FormSampleDelOrder.MdiParent = Me
            FormSampleDelOrder.Show()
            FormSampleDelOrder.WindowState = FormWindowState.Maximized
            FormSampleDelOrder.Focus()
        Catch ex As Exception
            errorProcess()
        End Try
        Cursor = Cursors.Default
    End Sub

    Private Sub NBSampleStockOpname_LinkClicked(ByVal sender As System.Object, ByVal e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles NBSampleStockOpname.LinkClicked
        Cursor = Cursors.WaitCursor
        Try
            FormSampleStockOpname.MdiParent = Me
            FormSampleStockOpname.Show()
            FormSampleStockOpname.WindowState = FormWindowState.Maximized
            FormSampleStockOpname.Focus()
        Catch ex As Exception
            errorProcess()
        End Try
        Cursor = Cursors.Default
    End Sub

    Private Sub NBFGCodeReplace_LinkClicked(ByVal sender As System.Object, ByVal e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles NBFGCodeReplace.LinkClicked
        Cursor = Cursors.WaitCursor
        Try
            FormFGCodeReplace.MdiParent = Me
            FormFGCodeReplace.Show()
            FormFGCodeReplace.WindowState = FormWindowState.Maximized
            FormFGCodeReplace.Focus()
        Catch ex As Exception
            errorProcess()
        End Try
        Cursor = Cursors.Default
    End Sub

    Private Sub NBPayment_LinkClicked(ByVal sender As System.Object, ByVal e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles NBPayment.LinkClicked
        Cursor = Cursors.WaitCursor
        Try
            FormAccountingListPR.MdiParent = Me
            FormAccountingListPR.Show()
            FormAccountingListPR.WindowState = FormWindowState.Maximized
            FormAccountingListPR.Focus()
        Catch ex As Exception
            errorProcess()
        End Try
        Cursor = Cursors.Default
    End Sub

    Private Sub BBPay_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles BBPay.ItemClick
        If formName = "FormAccountingListPR" Then
            FormAccountingListPR.GVPaymentList.ActiveFilterString = String.Empty
            FormAccountingListPR.GVPaymentList.ActiveFilterString = "is_check='yes'"
            FormAccountingListPR.GVPaymentList.UpdateCurrentRow()

            FormAccountingListPRPay.ShowDialog()
        End If
    End Sub

    Private Sub NBSalesWeekly_LinkClicked(ByVal sender As System.Object, ByVal e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles NBSalesWeekly.LinkClicked
        Cursor = Cursors.WaitCursor
        Try
            FormSalesWeekly.MdiParent = Me
            FormSalesWeekly.Show()
            FormSalesWeekly.WindowState = FormWindowState.Maximized
            FormSalesWeekly.Focus()
        Catch ex As Exception
            errorProcess()
        End Try
        Cursor = Cursors.Default
    End Sub

    'CREDIT NOTE
    Private Sub NBSalesCreditNote_LinkClicked(ByVal sender As System.Object, ByVal e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles NBSalesCreditNote.LinkClicked
        Cursor = Cursors.WaitCursor
        Try
            FormSalesCreditNote.MdiParent = Me
            FormSalesCreditNote.Show()
            FormSalesCreditNote.WindowState = FormWindowState.Maximized
            FormSalesCreditNote.Focus()
        Catch ex As Exception
            errorProcess()
        End Try
        Cursor = Cursors.Default
    End Sub

    'MISSING CREDIT NOTE
    Private Sub NBFGMissingCreditNote_LinkClicked(ByVal sender As System.Object, ByVal e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles NBFGMissingCreditNote.LinkClicked
        Cursor = Cursors.WaitCursor
        Try
            FormFGMissingCreditNote.MdiParent = Me
            FormFGMissingCreditNote.Show()
            FormFGMissingCreditNote.WindowState = FormWindowState.Maximized
            FormFGMissingCreditNote.Focus()
        Catch ex As Exception
            errorProcess()
        End Try
        Cursor = Cursors.Default
    End Sub

    Private Sub NBSOHPeriode_LinkClicked(ByVal sender As System.Object, ByVal e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles NBSOHPeriode.LinkClicked
        Cursor = Cursors.WaitCursor
        Try
            FormSOHPeriode.MdiParent = Me
            FormSOHPeriode.Show()
            FormSOHPeriode.WindowState = FormWindowState.Maximized
            FormSOHPeriode.Focus()
        Catch ex As Exception
            errorProcess()
        End Try
        Cursor = Cursors.Default
    End Sub

    Private Sub NBSOH_LinkClicked(ByVal sender As System.Object, ByVal e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles NBSOH.LinkClicked
        Cursor = Cursors.WaitCursor
        Try
            FormSOH.MdiParent = Me
            FormSOH.Show()
            FormSOH.WindowState = FormWindowState.Maximized
            FormSOH.Focus()
        Catch ex As Exception
            errorProcess()
        End Try
        Cursor = Cursors.Default
    End Sub

    Private Sub NBSOHPrice_LinkClicked(ByVal sender As System.Object, ByVal e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles NBSOHPrice.LinkClicked
        Cursor = Cursors.WaitCursor
        Try
            FormSOHPrice.MdiParent = Me
            FormSOHPrice.Show()
            FormSOHPrice.WindowState = FormWindowState.Maximized
            FormSOHPrice.Focus()
        Catch ex As Exception
            errorProcess()
        End Try
        Cursor = Cursors.Default
    End Sub

    Private Sub NBSOHSum_LinkClicked(ByVal sender As System.Object, ByVal e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles NBSOHSum.LinkClicked
        Cursor = Cursors.WaitCursor
        Try
            FormSOHSum.MdiParent = Me
            FormSOHSum.Show()
            FormSOHSum.WindowState = FormWindowState.Maximized
            FormSOHSum.Focus()
        Catch ex As Exception
            errorProcess()
        End Try
        Cursor = Cursors.Default
    End Sub

    Private Sub NBFGWoff_LinkClicked(ByVal sender As System.Object, ByVal e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles NBFGWoff.LinkClicked
        Cursor = Cursors.WaitCursor
        Try
            FormFGWoff.MdiParent = Me
            FormFGWoff.Show()
            FormFGWoff.WindowState = FormWindowState.Maximized
            FormFGWoff.Focus()
        Catch ex As Exception
            errorProcess()
        End Try
        Cursor = Cursors.Default
    End Sub

    Private Sub NBFGWoffList_LinkClicked(ByVal sender As System.Object, ByVal e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles NBFGWoffList.LinkClicked
        Cursor = Cursors.WaitCursor
        Try
            FormFGWoffList.MdiParent = Me
            FormFGWoffList.Show()
            FormFGWoffList.WindowState = FormWindowState.Maximized
            FormFGWoffList.Focus()
        Catch ex As Exception
            errorProcess()
        End Try
        Cursor = Cursors.Default
    End Sub

    Private Sub NBProposePrice_LinkClicked(ByVal sender As System.Object, ByVal e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles NBProposePrice.LinkClicked
        Cursor = Cursors.WaitCursor
        Try
            FormFGProposePrice.MdiParent = Me
            FormFGProposePrice.Show()
            FormFGProposePrice.WindowState = FormWindowState.Maximized
            FormFGProposePrice.Focus()
        Catch ex As Exception
            errorProcess()
        End Try
        Cursor = Cursors.Default
    End Sub

    Private Sub NBFGLineList_LinkClicked(ByVal sender As System.Object, ByVal e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles NBFGLineList.LinkClicked
        Cursor = Cursors.WaitCursor
        Try
            FormFGLineList.MdiParent = Me
            FormFGLineList.Show()
            FormFGLineList.WindowState = FormWindowState.Maximized
            FormFGLineList.Focus()
        Catch ex As Exception
            errorProcess()
        End Try
        Cursor = Cursors.Default
    End Sub

    Private Sub NBDistSchemaSetup_LinkClicked(ByVal sender As System.Object, ByVal e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles NBDistSchemaSetup.LinkClicked
        Cursor = Cursors.WaitCursor
        Try
            FormFGDistSchemaSetup.MdiParent = Me
            FormFGDistSchemaSetup.Show()
            FormFGDistSchemaSetup.WindowState = FormWindowState.Maximized
            FormFGDistSchemaSetup.Focus()
        Catch ex As Exception
            errorProcess()
        End Try
        Cursor = Cursors.Default
    End Sub

    Private Sub NBFGLineListDsg_LinkClicked(ByVal sender As System.Object, ByVal e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles NBFGLineListDsg.LinkClicked
        Cursor = Cursors.WaitCursor
        Try
            FormFGLineList.MdiParent = Me
            FormFGLineList.id_pop_up = "2"
            FormFGLineList.Show()
            FormFGLineList.WindowState = FormWindowState.Maximized
            FormFGLineList.Focus()
        Catch ex As Exception
            errorProcess()
        End Try
        Cursor = Cursors.Default
    End Sub

    Private Sub NBRetCode_LinkClicked(ByVal sender As System.Object, ByVal e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles NBRetCode.LinkClicked
        Cursor = Cursors.WaitCursor
        Try
            FormMasterRetCode.MdiParent = Me
            FormMasterRetCode.Show()
            FormMasterRetCode.WindowState = FormWindowState.Maximized
            FormMasterRetCode.Focus()
        Catch ex As Exception
            errorProcess()
        End Try
        Cursor = Cursors.Default
    End Sub

    Private Sub NBFGProdList_LinkClicked(ByVal sender As System.Object, ByVal e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles NBFGProdList.LinkClicked
        Cursor = Cursors.WaitCursor
        Try
            FormFGProdList.MdiParent = Me
            FormFGProdList.Show()
            FormFGProdList.WindowState = FormWindowState.Maximized
            FormFGProdList.Focus()
        Catch ex As Exception
            errorProcess()
        End Try
        Cursor = Cursors.Default
    End Sub

    Private Sub NBPrintBarcode_LinkClicked(ByVal sender As System.Object, ByVal e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles NBPrintBarcode.LinkClicked
        Cursor = Cursors.WaitCursor
        Try
            FormBarcodeProduct.MdiParent = Me
            FormBarcodeProduct.Show()
            FormBarcodeProduct.WindowState = FormWindowState.Maximized
            FormBarcodeProduct.Focus()
        Catch ex As Exception
            errorProcess()
        End Try
        Cursor = Cursors.Default
    End Sub

    Private Sub NBDesignList_LinkClicked(ByVal sender As System.Object, ByVal e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles NBDesignList.LinkClicked
        Cursor = Cursors.WaitCursor
        Try
            FormMasterDesignCOP.MdiParent = Me
            FormMasterDesignCOP.Show()
            FormMasterDesignCOP.WindowState = FormWindowState.Maximized
            FormMasterDesignCOP.Focus()
        Catch ex As Exception
            errorProcess()
        End Try
        Cursor = Cursors.Default
    End Sub


    Private Sub NBSampleOrdered_LinkClicked(ByVal sender As System.Object, ByVal e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles NBSampleOrdered.LinkClicked
        Cursor = Cursors.WaitCursor
        Try
            FormSampleOrdered.MdiParent = Me
            FormSampleOrdered.Show()
            FormSampleOrdered.WindowState = FormWindowState.Maximized
            FormSampleOrdered.Focus()
        Catch ex As Exception
            errorProcess()
        End Try
        Cursor = Cursors.Default
    End Sub

    Private Sub NBFGDS_LinkClicked(ByVal sender As System.Object, ByVal e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles NBFGDS.LinkClicked
        Cursor = Cursors.WaitCursor
        Try
            FormFGDistScheme.MdiParent = Me
            FormFGDistScheme.Show()
            FormFGDistScheme.WindowState = FormWindowState.Maximized
            FormFGDistScheme.Focus()
        Catch ex As Exception
            errorProcess()
        End Try
        Cursor = Cursors.Default
    End Sub

    Private Sub NBRateStore_LinkClicked(ByVal sender As System.Object, ByVal e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles NBRateStore.LinkClicked
        Cursor = Cursors.WaitCursor
        Try
            FormMasterRateStore.MdiParent = Me
            FormMasterRateStore.Show()
            FormMasterRateStore.WindowState = FormWindowState.Maximized
            FormMasterRateStore.Focus()
        Catch ex As Exception
            errorProcess()
        End Try
        Cursor = Cursors.Default
    End Sub
    'Private Sub NBAccMap_LinkClicked(ByVal sender As System.Object, ByVal e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles NBAccMap.LinkClicked
    '    Cursor = Cursors.WaitCursor
    '    Try
    '        FormAccountingMapping.MdiParent = Me
    '        FormAccountingMapping.Show()
    '        FormAccountingMapping.WindowState = FormWindowState.Maximized
    '        FormAccountingMapping.Focus()
    '    Catch ex As Exception
    '        errorProcess()
    '    End Try
    '    Cursor = Cursors.Default
    'End Sub

    'Private Sub NBBilling_LinkClicked(ByVal sender As System.Object, ByVal e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles NBBilling.LinkClicked
    '    Cursor = Cursors.WaitCursor
    '    Try
    '        FormBilling.MdiParent = Me
    '        FormBilling.Show()
    '        FormBilling.WindowState = FormWindowState.Maximized
    '        FormBilling.Focus()
    '    Catch ex As Exception
    '        errorProcess()
    '    End Try
    '    Cursor = Cursors.Default
    'End Sub

    Private Sub NBAdjQC_LinkClicked(ByVal sender As System.Object, ByVal e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles NBAdjQC.LinkClicked
        Cursor = Cursors.WaitCursor
        Try
            FormProdQCAdj.MdiParent = Me
            FormProdQCAdj.Show()
            FormProdQCAdj.WindowState = FormWindowState.Maximized
            FormProdQCAdj.Focus()
        Catch ex As Exception
            errorProcess()
        End Try
        Cursor = Cursors.Default
    End Sub

    Private Sub NBFGSOReff_LinkClicked(ByVal sender As System.Object, ByVal e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles NBFGSOReff.LinkClicked
        Cursor = Cursors.WaitCursor
        Try
            FormFGSalesOrderReff.MdiParent = Me
            FormFGSalesOrderReff.Show()
            FormFGSalesOrderReff.WindowState = FormWindowState.Maximized
            FormFGSalesOrderReff.Focus()
        Catch ex As Exception
            errorProcess()
        End Try
        Cursor = Cursors.Default
    End Sub

    Private Sub NavBarItem1_LinkClicked(ByVal sender As System.Object, ByVal e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles NBSalesOrderList.LinkClicked
        Cursor = Cursors.WaitCursor
        Try
            FormSalesOrderList.MdiParent = Me
            FormSalesOrderList.Show()
            FormSalesOrderList.WindowState = FormWindowState.Maximized
            FormSalesOrderList.Focus()
        Catch ex As Exception
            errorProcess()
        End Try
        Cursor = Cursors.Default
    End Sub

    Private Sub NBFGTrfNew_LinkClicked(ByVal sender As System.Object, ByVal e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles NBFGTrfNew.LinkClicked
        Cursor = Cursors.WaitCursor
        Try
            FormFGTrfNew.MdiParent = Me
            FormFGTrfNew.Show()
            FormFGTrfNew.WindowState = FormWindowState.Maximized
            FormFGTrfNew.Focus()
        Catch ex As Exception
            errorProcess()
        End Try
        Cursor = Cursors.Default
    End Sub

    Private Sub BBToggleMenu_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles BBToggleMenu.ItemClick
        If PCMenu.Visible = False Then
            PCMenu.Visible = True
        Else
            PCMenu.Visible = False
        End If
    End Sub

    Private Sub TESearchNavbar_EditValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TESearchNavbar.EditValueChanged
        For Each group As DevExpress.XtraNavBar.NavBarGroup In NBProdRet.Groups
            For Each link As DevExpress.XtraNavBar.NavBarItemLink In group.ItemLinks
                If link.Enabled = True Then
                    link.Visible = link.Caption.ToLower.Contains(TESearchNavbar.Text.ToLower)
                    If group.VisibleItemLinks.Count = 0 Then
                        group.Visible = False
                    Else
                        group.Visible = True
                    End If
                End If
            Next link
        Next group
    End Sub

    Private Sub NBSalesPromo_LinkClicked(ByVal sender As System.Object, ByVal e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles NBSalesPromo.LinkClicked
        Cursor = Cursors.WaitCursor
        Try
            FormSalesPromo.MdiParent = Me
            FormSalesPromo.Show()
            FormSalesPromo.WindowState = FormWindowState.Maximized
            FormSalesPromo.Focus()
        Catch ex As Exception
            errorProcess()
        End Try
        Cursor = Cursors.Default
    End Sub

    Private Sub TESearchNavbar_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TESearchNavbar.KeyUp

    End Sub

    Private Sub BBGuide_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BBGuide.ItemClick
        Cursor = Cursors.WaitCursor
        Try
            FormGuide.MdiParent = Me
            FormGuide.Show()
            FormGuide.WindowState = FormWindowState.Maximized
            FormGuide.Focus()
        Catch ex As Exception
            errorProcess()
        End Try
        Cursor = Cursors.Default
    End Sub

    Private Sub NBComputer_LinkClicked(sender As Object, e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles NBComputer.LinkClicked
        Cursor = Cursors.WaitCursor
        Try
            FormMasterComputer.MdiParent = Me
            FormMasterComputer.Show()
            FormMasterComputer.WindowState = FormWindowState.Maximized
            FormMasterComputer.Focus()
        Catch ex As Exception
            errorProcess()
        End Try
        Cursor = Cursors.Default
    End Sub

    Private Sub AboutToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AboutToolStripMenuItem.Click
        about()
    End Sub

    Private Sub BBNotif_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BBNotif.ItemClick
        Cursor = Cursors.WaitCursor
        Try
            FormNotification.MdiParent = Me
            FormNotification.Show()
            FormNotification.WindowState = FormWindowState.Maximized
            FormNotification.Focus()
        Catch ex As Exception
            errorProcess()
        End Try
        Cursor = Cursors.Default
    End Sub

    Private Sub NBScanEFactur_LinkClicked(sender As Object, e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles NBScanEFactur.LinkClicked
        Cursor = Cursors.WaitCursor
        Try
            FormAccountingFakturScan.MdiParent = Me
            FormAccountingFakturScan.Show()
            FormAccountingFakturScan.WindowState = FormWindowState.Maximized
            FormAccountingFakturScan.Focus()
        Catch ex As Exception
            errorProcess()
        End Try
        Cursor = Cursors.Default
    End Sub

    Private Sub NBBorrowQCRec_LinkClicked(sender As Object, e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles NBBorrowQCRec.LinkClicked
        Cursor = Cursors.WaitCursor
        Try
            FormFGBorrowQCReq.MdiParent = Me
            FormFGBorrowQCReq.Show()
            FormFGBorrowQCReq.WindowState = FormWindowState.Maximized
            FormFGBorrowQCReq.Focus()
        Catch ex As Exception
            errorProcess()
        End Try
        Cursor = Cursors.Default
    End Sub

    'season non merch
    Private Sub NBSeasonNonMerch_LinkClicked(sender As Object, e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles NBSeasonNonMerch.LinkClicked
        Cursor = Cursors.WaitCursor
        Try
            FormSeason.is_md = "2"
            FormSeason.MdiParent = Me
            FormSeason.Show()
            FormSeason.WindowState = FormWindowState.Maximized
            FormSeason.Focus()
        Catch ex As Exception
            errorProcess()
        End Try
        Cursor = Cursors.Default
    End Sub

    Private Sub NBLineListNonMerch_LinkClicked(sender As Object, e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles NBLineListNonMerch.LinkClicked
        Cursor = Cursors.WaitCursor
        Try
            FormFGLineList.MdiParent = Me
            FormFGLineList.id_pop_up = "3"
            FormFGLineList.Show()
            FormFGLineList.WindowState = FormWindowState.Maximized
            FormFGLineList.Focus()
        Catch ex As Exception
            errorProcess()
        End Try
        Cursor = Cursors.Default
    End Sub

    Private Sub NBSalesOrderCat_LinkClicked(sender As Object, e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles NBSalesOrderCat.LinkClicked
        Cursor = Cursors.WaitCursor
        Try
            FormSalesOrderCat.MdiParent = Me
            FormSalesOrderCat.Show()
            FormSalesOrderCat.WindowState = FormWindowState.Maximized
            FormSalesOrderCat.Focus()
        Catch ex As Exception
            errorProcess()
        End Try
        Cursor = Cursors.Default
    End Sub

    Private Sub NBAWB_LinkClicked(sender As Object, e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles NBAWB.LinkClicked
        Cursor = Cursors.WaitCursor
        Try
            FormWHAWBill.MdiParent = Me
            FormWHAWBill.Show()
            FormWHAWBill.WindowState = FormWindowState.Maximized
            FormWHAWBill.Focus()
        Catch ex As Exception
            errorProcess()
        End Try
        Cursor = Cursors.Default
    End Sub

    Private Sub NBCargoRate_LinkClicked(sender As Object, e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles NBCargoRate.LinkClicked
        Cursor = Cursors.WaitCursor
        Try
            FormWHCargoRate.MdiParent = Me
            FormWHCargoRate.Show()
            FormWHCargoRate.WindowState = FormWindowState.Maximized
            FormWHCargoRate.Focus()
        Catch ex As Exception
            errorProcess()
        End Try
        Cursor = Cursors.Default
    End Sub

    Private Sub NBSalesOrderSvcLevel_LinkClicked(sender As Object, e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles NBSalesOrderSvcLevel.LinkClicked
        Cursor = Cursors.WaitCursor
        Try
            FormSalesOrderSvcLevel.MdiParent = Me
            FormSalesOrderSvcLevel.Show()
            FormSalesOrderSvcLevel.WindowState = FormWindowState.Maximized
            FormSalesOrderSvcLevel.Focus()
        Catch ex As Exception
            errorProcess()
        End Try
        Cursor = Cursors.Default
    End Sub

    Private Sub NBMasterPrice_LinkClicked(sender As Object, e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles NBMasterPrice.LinkClicked
        Cursor = Cursors.WaitCursor
        Try
            FormMasterPrice.MdiParent = Me
            FormMasterPrice.Show()
            FormMasterPrice.WindowState = FormWindowState.Maximized
            FormMasterPrice.Focus()
        Catch ex As Exception
            errorProcess()
        End Try
        Cursor = Cursors.Default
    End Sub

    Private Sub NBImportDO_LinkClicked(sender As Object, e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles NBImportDO.LinkClicked
        Cursor = Cursors.WaitCursor
        Try
            FormWHImportDO.MdiParent = Me
            FormWHImportDO.Show()
            FormWHImportDO.WindowState = FormWindowState.Maximized
            FormWHImportDO.Focus()
        Catch ex As Exception
            errorProcess()
        End Try
        Cursor = Cursors.Default
    End Sub

    Private Sub NBDesignLineList_LinkClicked(sender As Object, e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles NBDesignLineList.LinkClicked
        Cursor = Cursors.WaitCursor
        Try
            FormFGDesignList.MdiParent = Me
            FormFGDesignList.Show()
            FormFGDesignList.WindowState = FormWindowState.Maximized
            FormFGDesignList.Focus()
        Catch ex As Exception
            errorProcess()
        End Try
        Cursor = Cursors.Default
    End Sub

    Private Sub NBWHSvcLevel_LinkClicked(sender As Object, e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles NBWHSvcLevel.LinkClicked
        Cursor = Cursors.WaitCursor
        Try
            FormWHSvcLevel.MdiParent = Me
            FormWHSvcLevel.Show()
            FormWHSvcLevel.WindowState = FormWindowState.Maximized
            FormWHSvcLevel.Focus()
        Catch ex As Exception
            errorProcess()
        End Try
        Cursor = Cursors.Default
    End Sub

    Private Sub NBTestBC_LinkClicked(sender As Object, e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles NBTestBC.LinkClicked
        barcodeaa.ShowDialog()
    End Sub

    Private Sub NBSamplePL_LinkClicked(sender As Object, e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles NBSamplePL.LinkClicked
        Cursor = Cursors.WaitCursor
        Try
            FormSamplePLToWH.MdiParent = Me
            FormSamplePLToWH.Show()
            FormSamplePLToWH.WindowState = FormWindowState.Maximized
            FormSamplePLToWH.Focus()
        Catch ex As Exception
            errorProcess()
        End Try
        Cursor = Cursors.Default
    End Sub

    Private Sub NBMasterSamplePrice_LinkClicked(sender As Object, e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles NBMasterSamplePrice.LinkClicked
        Cursor = Cursors.WaitCursor
        Try
            FormMasterPriceSample.MdiParent = Me
            FormMasterPriceSample.Show()
            FormMasterPriceSample.WindowState = FormWindowState.Maximized
            FormMasterPriceSample.Focus()
        Catch ex As Exception
            errorProcess()
        End Try
        Cursor = Cursors.Default
    End Sub

    Private Sub NBSamplePriceRet_LinkClicked(sender As Object, e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles NBSamplePriceRet.LinkClicked
        Cursor = Cursors.WaitCursor
        Try
            FormSamplePLExport.MdiParent = Me
            FormSamplePLExport.Show()
            FormSamplePLExport.WindowState = FormWindowState.Maximized
            FormSamplePLExport.Focus()
        Catch ex As Exception
            errorProcess()
        End Try
        Cursor = Cursors.Default
    End Sub

    Private Sub NBFGWHAlloc_LinkClicked(sender As Object, e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles NBFGWHAlloc.LinkClicked
        Cursor = Cursors.WaitCursor
        Try
            FormFGWHAlloc.MdiParent = Me
            FormFGWHAlloc.Show()
            FormFGWHAlloc.WindowState = FormWindowState.Maximized
            FormFGWHAlloc.Focus()
        Catch ex As Exception
            errorProcess()
        End Try
        Cursor = Cursors.Default
    End Sub
    Private Sub NBProdWO_LinkClicked(sender As Object, e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles NBProdWO.LinkClicked
        Cursor = Cursors.WaitCursor
        Try
            FormProductionWOList.MdiParent = Me
            FormProductionWOList.Show()
            FormProductionWOList.WindowState = FormWindowState.Maximized
            FormProductionWOList.Focus()
        Catch ex As Exception
            errorProcess()
        End Try
        Cursor = Cursors.Default
    End Sub

    Private Sub NBFGWHAllocLog_LinkClicked(sender As Object, e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles NBFGWHAllocLog.LinkClicked
        Cursor = Cursors.WaitCursor
        Try
            FormFGWHAllocLog.MdiParent = Me
            FormFGWHAllocLog.Show()
            FormFGWHAllocLog.WindowState = FormWindowState.Maximized
            FormFGWHAllocLog.Focus()
        Catch ex As Exception
            errorProcess()
        End Try
        Cursor = Cursors.Default
    End Sub

    Private Sub NBProdRet_Click(sender As Object, e As EventArgs) Handles NBProdRet.Click

    End Sub

    Private Sub NBStockQC_LinkClicked(sender As Object, e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles NBStockQC.LinkClicked
        Cursor = Cursors.WaitCursor
        Try
            FormFGStock.MdiParent = Me
            FormFGStock.id_pop_up = "1"
            FormFGStock.Show()
            FormFGStock.WindowState = FormWindowState.Maximized
            FormFGStock.Focus()
        Catch ex As Exception
            errorProcess()
        End Try
        Cursor = Cursors.Default
    End Sub
    Private Sub NBSamplePLRet_LinkClicked(sender As Object, e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles NBSamplePLRet.LinkClicked
        Cursor = Cursors.WaitCursor
        Try
            FormSampleReturnPL.MdiParent = Me
            FormSampleReturnPL.Show()
            FormSampleReturnPL.WindowState = FormWindowState.Maximized
            FormSampleReturnPL.Focus()
        Catch ex As Exception
            errorProcess()
        End Try
        Cursor = Cursors.Default
    End Sub

    Private Sub NBDesignListApp_LinkClicked(sender As Object, e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles NBDesignListApp.LinkClicked
        Cursor = Cursors.WaitCursor
        Try
            FormFGDesignList.MdiParent = Me
            FormFGDesignList.id_pop_up = "1"
            FormFGDesignList.Show()
            FormFGDesignList.WindowState = FormWindowState.Maximized
            FormFGDesignList.Focus()
        Catch ex As Exception
            errorProcess()
        End Try
        Cursor = Cursors.Default
    End Sub

    Private Sub NBInitializeFP_LinkClicked_1(sender As Object, e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles NBInitializeFP.LinkClicked
        Cursor = Cursors.WaitCursor
        Try
            FormEmpInitialize.MdiParent = Me
            FormEmpInitialize.Show()
            FormEmpInitialize.WindowState = FormWindowState.Maximized
            FormEmpInitialize.Focus()
        Catch ex As Exception
            errorProcess()
        End Try
        Cursor = Cursors.Default
    End Sub


    Private Sub NBShift_LinkClicked(sender As Object, e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles NBShift.LinkClicked
        Cursor = Cursors.WaitCursor
        Try
            FormEmpShift.MdiParent = Me
            FormEmpShift.Show()
            FormEmpShift.WindowState = FormWindowState.Maximized
            FormEmpShift.Focus()
        Catch ex As Exception
            errorProcess()
        End Try
        Cursor = Cursors.Default
    End Sub


    Private Sub NBFPSetup_LinkClicked_1(sender As Object, e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles NBFPSetup.LinkClicked
        Cursor = Cursors.WaitCursor
        Try
            FormEmpFP.MdiParent = Me
            FormEmpFP.Show()
            FormEmpFP.WindowState = FormWindowState.Maximized
            FormEmpFP.Focus()
        Catch ex As Exception
            errorProcess()
        End Try
        Cursor = Cursors.Default
    End Sub

    Private Sub NBHoliday_LinkClicked(sender As Object, e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles NBHoliday.LinkClicked
        Cursor = Cursors.WaitCursor
        Try
            FormEmpHoliday.MdiParent = Me
            FormEmpHoliday.Show()
            FormEmpHoliday.WindowState = FormWindowState.Maximized
            FormEmpHoliday.Focus()
        Catch ex As Exception
            errorProcess()
        End Try
        Cursor = Cursors.Default
    End Sub

    Private Sub NBSchedule_LinkClicked(sender As Object, e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles NBSchedule.LinkClicked
        Cursor = Cursors.WaitCursor
        Try
            FormEmpSchedule.MdiParent = Me
            FormEmpSchedule.Show()
            FormEmpSchedule.WindowState = FormWindowState.Maximized
            FormEmpSchedule.Focus()
        Catch ex As Exception
            errorProcess()
        End Try
        Cursor = Cursors.Default
    End Sub

    Private Sub NBAttnInd_LinkClicked(sender As Object, e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles NBAttnInd.LinkClicked
        Cursor = Cursors.WaitCursor
        Try
            FormEmpAttnInd.MdiParent = Me
            FormEmpAttnInd.Show()
            FormEmpAttnInd.WindowState = FormWindowState.Maximized
            FormEmpAttnInd.Focus()
        Catch ex As Exception
            errorProcess()
        End Try
        Cursor = Cursors.Default
    End Sub

    Private Sub NBAttnSum_LinkClicked(sender As Object, e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles NBAttnSum.LinkClicked
        Cursor = Cursors.WaitCursor
        Try
            FormEmpAttnSum.MdiParent = Me
            FormEmpAttnSum.Show()
            FormEmpAttnSum.WindowState = FormWindowState.Maximized
            FormEmpAttnSum.Focus()
        Catch ex As Exception
            errorProcess()
        End Try
        Cursor = Cursors.Default
    End Sub

    Private Sub NBEmpReview_LinkClicked(sender As Object, e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles NBEmpReview.LinkClicked
        Cursor = Cursors.WaitCursor
        Try
            FormEmpReview.MdiParent = Me
            FormEmpReview.Show()
            FormEmpReview.WindowState = FormWindowState.Maximized
            FormEmpReview.Focus()
        Catch ex As Exception
            errorProcess()
        End Try
        Cursor = Cursors.Default
    End Sub

    Private Sub NBAttnLog_LinkClicked(sender As Object, e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles NBAttnLog.LinkClicked
        Cursor = Cursors.WaitCursor
        Try
            FormEmpAttn.MdiParent = Me
            FormEmpAttn.Show()
            FormEmpAttn.WindowState = FormWindowState.Maximized
            FormEmpAttn.Focus()
        Catch ex As Exception
            errorProcess()
        End Try
        Cursor = Cursors.Default
    End Sub

    Private Sub NBFGRepair_LinkClicked(sender As Object, e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles NBFGRepair.LinkClicked
        Cursor = Cursors.WaitCursor
        Try
            FormFGRepair.MdiParent = Me
            FormFGRepair.Show()
            FormFGRepair.WindowState = FormWindowState.Maximized
            FormFGRepair.Focus()
        Catch ex As Exception
            errorProcess()
        End Try
        Cursor = Cursors.Default
    End Sub

    Private Sub NBFGRepairRec_LinkClicked(sender As Object, e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles NBFGRepairRec.LinkClicked
        Cursor = Cursors.WaitCursor
        Try
            FormFGRepairRec.MdiParent = Me
            FormFGRepairRec.Show()
            FormFGRepairRec.WindowState = FormWindowState.Maximized
            FormFGRepairRec.Focus()
        Catch ex As Exception
            errorProcess()
        End Try
        Cursor = Cursors.Default
    End Sub

    Private Sub NBFGRepairReturn_LinkClicked(sender As Object, e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles NBFGRepairReturn.LinkClicked
        Cursor = Cursors.WaitCursor
        Try
            FormFGRepairReturn.MdiParent = Me
            FormFGRepairReturn.Show()
            FormFGRepairReturn.WindowState = FormWindowState.Maximized
            FormFGRepairReturn.Focus()
        Catch ex As Exception
            errorProcess()
        End Try
        Cursor = Cursors.Default
    End Sub

    Private Sub NBFGRepairReturnRec_LinkClicked(sender As Object, e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles NBFGRepairReturnRec.LinkClicked
        Cursor = Cursors.WaitCursor
        Try
            FormFGRepairReturnRec.MdiParent = Me
            FormFGRepairReturnRec.Show()
            FormFGRepairReturnRec.WindowState = FormWindowState.Maximized
            FormFGRepairReturnRec.Focus()
        Catch ex As Exception
            errorProcess()
        End Try
        Cursor = Cursors.Default
    End Sub

    Private Sub NBAttnSumDept_LinkClicked(sender As Object, e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles NBAttnSumDept.LinkClicked
        Cursor = Cursors.WaitCursor
        Try
            FormEmpAttnSum.MdiParent = Me
            FormEmpAttnSum.view_one_dept = True
            FormEmpAttnSum.Show()
            FormEmpAttnSum.WindowState = FormWindowState.Maximized
            FormEmpAttnSum.Focus()
        Catch ex As Exception
            errorProcess()
        End Try
        Cursor = Cursors.Default
    End Sub

    Private Sub NBEmpEmail_LinkClicked(sender As Object, e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles NBEmpEmail.LinkClicked
        Cursor = Cursors.WaitCursor
        Try
            FormEmpEmail.MdiParent = Me
            FormEmpEmail.Show()
            FormEmpEmail.WindowState = FormWindowState.Maximized
            FormEmpEmail.Focus()
        Catch ex As Exception
            errorProcess()
        End Try
        Cursor = Cursors.Default
    End Sub

    Private Sub NBEmpLeave_LinkClicked(sender As Object, e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles NBEmpLeave.LinkClicked
        Cursor = Cursors.WaitCursor
        Try
            FormEmpLeave.is_propose = "-1"
            FormEmpLeave.is_hrd = "1"
            FormEmpLeave.MdiParent = Me
            FormEmpLeave.Show()
            FormEmpLeave.WindowState = FormWindowState.Maximized
            FormEmpLeave.Focus()
        Catch ex As Exception
            errorProcess()
        End Try
        Cursor = Cursors.Default
    End Sub

    Private Sub NBScheduleSecurity_LinkClicked(sender As Object, e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles NBScheduleSecurity.LinkClicked
        Cursor = Cursors.WaitCursor
        Try
            FormEmpSchedule.is_security = "1"
            FormEmpSchedule.MdiParent = Me
            FormEmpSchedule.Show()
            FormEmpSchedule.WindowState = FormWindowState.Maximized
            FormEmpSchedule.Focus()
        Catch ex As Exception
            errorProcess()
        End Try
        Cursor = Cursors.Default
    End Sub

    Private Sub NBLeavePropose_LinkClicked(sender As Object, e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles NBLeavePropose.LinkClicked
        Cursor = Cursors.WaitCursor
        Try
            FormEmpLeave.is_propose = "1"
            FormEmpLeave.MdiParent = Me
            FormEmpLeave.Show()
            FormEmpLeave.WindowState = FormWindowState.Maximized
            FormEmpLeave.Focus()
        Catch ex As Exception
            errorProcess()
        End Try
        Cursor = Cursors.Default
    End Sub

    Private Sub NBEmpLeaveRemaining_LinkClicked(sender As Object, e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles NBEmpLeaveRemaining.LinkClicked
        Cursor = Cursors.WaitCursor
        Try
            FormEmpLeaveStock.MdiParent = Me
            FormEmpLeaveStock.Show()
            FormEmpLeaveStock.WindowState = FormWindowState.Maximized
            FormEmpLeaveStock.Focus()
        Catch ex As Exception
            errorProcess()
        End Try
        Cursor = Cursors.Default
    End Sub

    Private Sub NBDP_LinkClicked(sender As Object, e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles NBDP.LinkClicked
        Cursor = Cursors.WaitCursor
        Try
            FormEmpDP.MdiParent = Me
            FormEmpDP.Show()
            FormEmpDP.WindowState = FormWindowState.Maximized
            FormEmpDP.Focus()
        Catch ex As Exception
            errorProcess()
        End Try
        Cursor = Cursors.Default
    End Sub

    Private Sub FormMain_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        'log
        Dim u As New ClassUser()
        u.logLogin("2")
    End Sub

    Private Sub NBChSchedule_LinkClicked(sender As Object, e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles NBChSchedule.LinkClicked
        Cursor = Cursors.WaitCursor
        Try
            FormEmpChSchedule.MdiParent = Me
            FormEmpChSchedule.Show()
            FormEmpChSchedule.WindowState = FormWindowState.Maximized
            FormEmpChSchedule.Focus()
        Catch ex As Exception
            errorProcess()
        End Try
        Cursor = Cursors.Default
    End Sub

    Private Sub NBSchedulePropose_LinkClicked(sender As Object, e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles NBSchedulePropose.LinkClicked
        Cursor = Cursors.WaitCursor
        Try
            FormEmpAttnAssign.MdiParent = Me
            FormEmpAttnAssign.Show()
            FormEmpAttnAssign.WindowState = FormWindowState.Maximized
            FormEmpAttnAssign.Focus()
        Catch ex As Exception
            errorProcess()
        End Try
        Cursor = Cursors.Default
    End Sub

    Private Sub NBProdReport_LinkClicked(sender As Object, e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles NBProdReport.LinkClicked
        Cursor = Cursors.WaitCursor
        Try
            FormProductionSummary.MdiParent = Me
            FormProductionSummary.Show()
            FormProductionSummary.WindowState = FormWindowState.Maximized
            FormProductionSummary.Focus()
        Catch ex As Exception
            errorProcess()
        End Try
        Cursor = Cursors.Default
    End Sub

    Private Sub NBAttnStore_LinkClicked(sender As Object, e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles NBAttnStore.LinkClicked
        Cursor = Cursors.WaitCursor
        Try
            FormEmpAttnSum.MdiParent = Me
            FormEmpAttnSum.view_store = True
            FormEmpAttnSum.Show()
            FormEmpAttnSum.WindowState = FormWindowState.Maximized
            FormEmpAttnSum.Focus()
        Catch ex As Exception
            errorProcess()
        End Try
        Cursor = Cursors.Default
    End Sub

    Private Sub NBSpecialReceiving_LinkClicked(sender As Object, e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles NBSpecialReceiving.LinkClicked
        Cursor = Cursors.WaitCursor
        Try
            FormProductionSpecialRec.MdiParent = Me
            FormProductionSpecialRec.Show()
            FormProductionSpecialRec.WindowState = FormWindowState.Maximized
            FormProductionSpecialRec.Focus()
        Catch ex As Exception
            errorProcess()
        End Try
        Cursor = Cursors.Default
    End Sub
End Class