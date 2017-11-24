Public Class FormAccess
    Dim bnew_active01 As String = "1"
    Dim bedit_active01 As String = "1"
    Dim bdel_active01 As String = "1"
    Dim bnew_active02 As String = "1"
    Dim bedit_active02 As String = "1"
    Dim bdel_active02 As String = "1"
    Dim bnew_active As String = "1"
    Dim bedit_active As String = "1"
    Dim bdel_active As String = "1"
    Dim bnew_active2 As String = "1"
    Dim bedit_active2 As String = "1"
    Dim bdel_active2 As String = "1"
    Dim id_form As String
    Dim bdupe_active As String = "1"
    '-------------------GENERAL---------------------------------
    'Form Load
    Private Sub FormAccess_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        viewForm()
        viewMenu()
        viewRole()
        DEFrom.EditValue = getTimeDB()
        DEUntil.EditValue = getTimeDB()
    End Sub
    'Form Closed
    Private Sub FormAccess_FormClosed(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub
    'Activated
    Private Sub FormAccess_Activated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Activated
        FormMain.show_rb(Name)
        pageChanged()
    End Sub
    'Deadactivated
    Private Sub FormAccess_Deactivate(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Deactivate
        FormMain.hide_rb()
    End Sub
    'Page Changed Main
    Private Sub XTCMenuManage_SelectedPageChanged(ByVal sender As System.Object, ByVal e As DevExpress.XtraTab.TabPageChangedEventArgs) Handles XTCMenuManage.SelectedPageChanged
        pageChanged()
    End Sub
    Sub pageChanged()
        If XTCMenuManage.SelectedTabPageIndex.ToString = "1" Then 'Menu
            FormMain.BBDuplicate.Visibility = DevExpress.XtraBars.BarItemVisibility.Never
            FormMain.BBMapping.Visibility = DevExpress.XtraBars.BarItemVisibility.Never
            checkFormAccess(Name)
            button_main(bnew_active, bedit_active, bdel_active)
        ElseIf XTCMenuManage.SelectedTabPageIndex.ToString = "0" Then 'Form
            FormMain.BBMapping.Visibility = DevExpress.XtraBars.BarItemVisibility.Never
            If XTCForm.SelectedTabPageIndex = 0 Then
                'MsgBox("Tab 1 Form")
                FormMain.BBDuplicate.Visibility = DevExpress.XtraBars.BarItemVisibility.Never
                checkFormAccess(Name)
                button_main(bnew_active01, bedit_active01, bdel_active01)
            Else
                FormMain.BBDuplicate.Visibility = DevExpress.XtraBars.BarItemVisibility.Always
                checkFormAccess(Name)
                button_main(bnew_active02, bedit_active02, bdel_active02)
            End If
        Else 'Role
            FormMain.BBDuplicate.Visibility = DevExpress.XtraBars.BarItemVisibility.Never
            FormMain.BBMapping.Visibility = DevExpress.XtraBars.BarItemVisibility.Always
            checkFormAccess(Name)
            button_main(bnew_active2, bedit_active2, bdel_active2)
        End If
    End Sub
    '-----------------------TAB ROLE------------------------------
    'View Role
    Sub viewRole()
        Dim query As String = "SELECT * FROM tb_m_role ORDER BY role ASC"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCRole.DataSource = data
        If data.Rows.Count > 0 Then
            'show all
            bnew_active2 = "1"
            bedit_active2 = "1"
            bdel_active2 = "1"
        Else
            'hide all except new
            bnew_active2 = "1"
            bedit_active2 = "0"
            bdel_active2 = "0"
        End If
    End Sub
    '----------------------TAB MENU------------------------------
    'View Menu
    Sub viewMenu()
        Dim query As String = "SELECT * FROM tb_menu a INNER JOIN tb_lookup_group_menu b ON a.id_group_menu = b.id_group_menu INNER JOIN tb_menu_caption capt ON capt.`menu_name`=a.`menu_name` ORDER BY a.description_menu_name ASC"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCMenu.DataSource = data
        GVMenu.Columns("group_menu").GroupIndex = 0
        If data.Rows.Count > 0 Then
            'show all
            bnew_active = "1"
            bedit_active = "1"
            bdel_active = "1"
        Else
            'hide all except new
            bnew_active = "1"
            bedit_active = "0"
            bdel_active = "0"
        End If
    End Sub
    'Focus
    Private Sub GVMenu_FocusedRowChanged(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles GVMenu.FocusedRowChanged
        Dim focusedRowHandle As Integer = -1
        If e.FocusedRowHandle = DevExpress.XtraGrid.GridControl.NewItemRowHandle OrElse e.FocusedRowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            Return
        End If
        Dim view As DevExpress.XtraGrid.Views.Grid.GridView = CType(sender, DevExpress.XtraGrid.Views.Grid.GridView)
        If e.FocusedRowHandle < 0 Then
            If e.PrevFocusedRowHandle = DevExpress.XtraGrid.GridControl.InvalidRowHandle Then
                focusedRowHandle = 0
            ElseIf Control.MouseButtons = MouseButtons.Left OrElse Control.MouseButtons = MouseButtons.Right Then
                focusedRowHandle = e.PrevFocusedRowHandle
            Else
                Dim prevRow As Integer = view.GetVisibleIndex(e.PrevFocusedRowHandle)
                Dim currRow As Integer = view.GetVisibleIndex(e.FocusedRowHandle)
                If prevRow > currRow Then
                    focusedRowHandle = e.PrevFocusedRowHandle - 1
                Else
                    focusedRowHandle = e.PrevFocusedRowHandle + 1
                End If
                If focusedRowHandle < 0 Then
                    focusedRowHandle = 0
                End If
                If focusedRowHandle >= view.DataRowCount Then
                    focusedRowHandle = view.DataRowCount - 1
                End If
            End If
            If focusedRowHandle < 0 Then
                view.FocusedRowHandle = 0
            Else
                view.FocusedRowHandle = focusedRowHandle
            End If
        End If
    End Sub
    '------------------- TAB FORM -------------------------------
    Sub viewForm()
        Dim query As String = "SELECT * FROM tb_menu_form a ORDER BY a.form_name ASC "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCForm.DataSource = data
        If data.Rows.Count > 0 Then
            'show all
            bnew_active01 = "1"
            bedit_active01 = "1"
            bdel_active01 = "1"
            XTPFormControl.PageEnabled = True
            id_form = GVForm.GetFocusedRowCellDisplayText("id_form").ToString
            viewFormControl()
            'viewFormControlRequired()
        Else
            'hide all except new
            bnew_active01 = "1"
            bedit_active01 = "0"
            bdel_active01 = "0"
            XTPFormControl.PageEnabled = False
        End If
        checkFormAccess(Name)
        button_main(bnew_active01, bedit_active01, bdel_active01)
    End Sub
    Sub viewFormControl()
        Dim query As String = "SELECT *, (IF(a.is_view = '1', 'Yes', 'No')) AS is_viewx FROM tb_menu_form_control a INNER JOIN tb_lookup_form_control_type b ON a.id_form_control_type = b.id_form_control_type WHERE a.id_form = '" + id_form + "' ORDER BY a.is_view ASC, description_form_control ASC "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCProcess.DataSource = data
        If data.Rows.Count > 0 Then
            'show all
            bnew_active02 = "1"
            bedit_active02 = "1"
            bdel_active02 = "1"
            bdupe_active = "1"

        Else
            'hide all except new
            bnew_active02 = "1"
            bedit_active02 = "0"
            bdel_active02 = "0"
            bdupe_active = "0"
        End If
        checkFormAccess(Name)
        button_main(bnew_active02, bedit_active02, bdel_active02)
        button_main_ext("3", bdupe_active)
    End Sub
    'Sub viewFormControlRequired()
    '    Dim query As String = "SELECT * FROM tb_menu_form_control a INNER JOIN tb_lookup_form_control_type b ON a.id_form_control_type = b.id_form_control_type WHERE a.id_form = '" + id_form + "' AND a.is_view = '1' ORDER BY description_form_control ASC "
    '    Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
    '    GCRequiredProcess.DataSource = data
    'End Sub
    'Page Changed Form
    Private Sub XTCForm_SelectedPageChanged(ByVal sender As System.Object, ByVal e As DevExpress.XtraTab.TabPageChangedEventArgs) Handles XTCForm.SelectedPageChanged
        pageChangedForm()
    End Sub
    Sub pageChangedForm()
        If XTCForm.SelectedTabPageIndex = 0 Then
            FormMain.BBDuplicate.Visibility = DevExpress.XtraBars.BarItemVisibility.Never
            checkFormAccess(Name)
            button_main(bnew_active01, bedit_active01, bdel_active01)
        Else
            FormMain.BBDuplicate.Visibility = DevExpress.XtraBars.BarItemVisibility.Always
            checkFormAccess(Name)
            button_main(bnew_active02, bedit_active02, bdel_active02)
        End If
    End Sub
    'Row Click Data Form
    Private Sub GVForm_RowClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Grid.RowClickEventArgs) Handles GVForm.RowClick
        'id_form = GVForm.GetFocusedRowCellDisplayText("id_form").ToString
        'viewFormControl()
        ''viewFormControlRequired()
        'checkFormAccess(Name)
        'button_main(bnew_active01, bedit_active01, bdel_active01)
    End Sub
    'Required Process Mouse Hover
    Private Sub GCRequiredProcess_MouseHover(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Cursor = Cursors.No
    End Sub
    'Required  Process Mouse :eave
    Private Sub GCRequiredProcess_MouseLeave(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Cursor = Cursors.Default
    End Sub

    Private Sub GVForm_FocusedRowChanged(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles GVForm.FocusedRowChanged
        id_form = GVForm.GetFocusedRowCellDisplayText("id_form").ToString
        viewFormControl()
        checkFormAccess(Name)
        button_main(bnew_active01, bedit_active01, bdel_active01)
    End Sub

    
    Private Sub GVForm_ColumnFilterChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GVForm.ColumnFilterChanged
        id_form = GVForm.GetFocusedRowCellDisplayText("id_form").ToString
        viewFormControl()
        checkFormAccess(Name)
        button_main(bnew_active01, bedit_active01, bdel_active01)
    End Sub

    Private Sub BtnView_Click(sender As Object, e As EventArgs) Handles BtnView.Click
        Dim date_from_selected As String = "0000-01-01"
        Dim date_until_selected As String = "9999-01-01"
        Try
            date_from_selected = DateTime.Parse(DEFrom.EditValue.ToString).ToString("yyyy-MM-dd")
        Catch ex As Exception
        End Try
        Try
            date_until_selected = DateTime.Parse(DEUntil.EditValue.ToString).ToString("yyyy-MM-dd")
        Catch ex As Exception
        End Try
        Dim log As New ClassUser
        Dim query As String = log.queryMain("AND (DATE(l.`time`)>='" + date_from_selected + "' AND DATE(l.`time`)<='" + date_until_selected + "')", "2")
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCLog.DataSource = data
    End Sub
End Class