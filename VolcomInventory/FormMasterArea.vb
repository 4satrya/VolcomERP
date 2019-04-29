Public Class FormMasterArea
    Dim bnew_active As String = "1"
    Dim bedit_active As String = "1"
    Dim bdel_active As String = "1"
    Public quick_edit As String = "-1"
    Public id_pop_up As String = "-1"

    Private Sub FormArea_FormClosing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        Dispose()
    End Sub

    Private Sub FormArea_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        apply_skin()
        view_country()

        If quick_edit = "1" Then
            PanelControlTop.Visible = True
        End If

        If id_pop_up = "1" Then
            XTRegion.PageVisible = False
            XTCity.PageVisible = False
            XTState.PageVisible = False
        End If
    End Sub

    Sub view_country()
        Dim data As DataTable = execute_query("SELECT id_country,country, country_display_name FROM tb_m_country ORDER BY country", -1, True, "", "", "", "")
        GCCountry.DataSource = data
        check_menu()
        If data.Rows.Count > 0 Then
            'show all
            bnew_active = "1"
            bedit_active = "1"
            bdel_active = "1"
            checkFormAccess(Name)
            button_main(bnew_active, bedit_active, bdel_active)
            '
            XTState.PageEnabled = True
            XTRegion.PageEnabled = True
            XTCity.PageEnabled = True
            view_region(GVCountry.GetFocusedRowCellDisplayText("id_country").ToString)
            LCountry.Text = GVCountry.GetFocusedRowCellDisplayText("country").ToString
        Else
            'hide all except new
            bnew_active = "1"
            bedit_active = "0"
            bdel_active = "0"
            checkFormAccess(Name)
            button_main(bnew_active, bedit_active, bdel_active)
            '
            XTRegion.PageEnabled = False
            XTState.PageEnabled = False
            XTCity.PageEnabled = False
        End If
    End Sub

    Sub view_region(ByVal id_country As String)
        Dim data As DataTable = execute_query(String.Format("SELECT id_region,region FROM tb_m_region WHERE id_country='{0}' ORDER BY region", id_country), -1, True, "", "", "", "")
        GCRegion.DataSource = data
        check_menu()
        If data.Rows.Count > 0 Then
            'enable ribbon delete edit
            XTState.PageEnabled = True
            XTCity.PageEnabled = True
            view_state(GVRegion.GetFocusedRowCellDisplayText("id_region").ToString)
            LRegion.Text = GVRegion.GetFocusedRowCellDisplayText("region").ToString
        Else
            'disable ribbon delete edit
            XTState.PageEnabled = False
            XTCity.PageEnabled = False
        End If
    End Sub

    Sub view_state(ByVal id_region As String)
        Dim data As DataTable = execute_query(String.Format("SELECT id_state,state FROM tb_m_state WHERE id_region='{0}' ORDER BY state", id_region), -1, True, "", "", "", "")
        GCState.DataSource = data
        check_menu()
        If data.Rows.Count > 0 Then
            'enable ribbon delete edit
            XTCity.PageEnabled = True
            view_city(GVState.GetFocusedRowCellDisplayText("id_state").ToString)
            LState.Text = GVState.GetFocusedRowCellDisplayText("state").ToString
        Else
            XTCity.PageEnabled = False
            'disable ribbon delete edit
        End If
    End Sub
    Sub view_city(ByVal id_state As String)
        Dim data As DataTable = execute_query(String.Format("SELECT id_city,city FROM tb_m_city WHERE id_state='{0}' ORDER BY city", id_state), -1, True, "", "", "", "")
        GCCity.DataSource = data
        check_menu()
        If data.Rows.Count > 0 Then
            'enable ribbon delete edit
        Else
            'disable ribbon delete edit
        End If
    End Sub

    Private Sub GVCountry_RowClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Grid.RowClickEventArgs) Handles GVCountry.RowClick
        view_region(GVCountry.GetFocusedRowCellDisplayText("id_country").ToString)
        LCountry.Text = GVCountry.GetFocusedRowCellDisplayText("country").ToString
    End Sub

    Private Sub GVRegion_RowClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Grid.RowClickEventArgs) Handles GVRegion.RowClick
        view_state(GVRegion.GetFocusedRowCellDisplayText("id_region").ToString)
        LState.Text = GVRegion.GetFocusedRowCellDisplayText("region").ToString
    End Sub

    Private Sub GVState_RowClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Grid.RowClickEventArgs) Handles GVState.RowClick
        view_city(GVState.GetFocusedRowCellDisplayText("id_state").ToString)
        LState.Text = GVState.GetFocusedRowCellDisplayText("state").ToString
    End Sub

    Private Sub FormMasterArea_Activated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Activated
        If quick_edit = "-1" Then
            FormMain.show_rb(Name)
            checkFormAccess(Name)
            button_main(bnew_active, bedit_active, bdel_active)
        End If
    End Sub

    Private Sub FormMasterArea_Deactivate(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Deactivate
        If quick_edit = "-1" Then
            FormMain.hide_rb()
        End If
    End Sub

    Private Sub XTCArea_SelectedPageChanged(ByVal sender As System.Object, ByVal e As DevExpress.XtraTab.TabPageChangedEventArgs) Handles XTCArea.SelectedPageChanged
        check_menu()
    End Sub
    Sub check_menu()
        If XTCArea.SelectedTabPageIndex = 0 Then
            'country
            If GVCountry.RowCount < 1 Then
                'hide all except new
                bnew_active = "1"
                bedit_active = "0"
                bdel_active = "0"
                checkFormAccess(Name)
                button_main(bnew_active, bedit_active, bdel_active)
                '
            Else
                'show all
                bnew_active = "1"
                bedit_active = "1"
                bdel_active = "1"
                checkFormAccess(Name)
                button_main(bnew_active, bedit_active, bdel_active)
                '
            End If
        ElseIf XTCArea.SelectedTabPageIndex = 1 Then
            'region
            If GVRegion.RowCount < 1 Then
                'hide all except new
                bnew_active = "1"
                bedit_active = "0"
                bdel_active = "0"
                checkFormAccess(Name)
                button_main(bnew_active, bedit_active, bdel_active)
                '
            Else
                'show all
                bnew_active = "1"
                bedit_active = "1"
                bdel_active = "1"
                checkFormAccess(Name)
                button_main(bnew_active, bedit_active, bdel_active)
                '
            End If
        ElseIf XTCArea.SelectedTabPageIndex = 2 Then
            'state
            If GVState.RowCount < 1 Then
                'hide all except new
                bnew_active = "1"
                bedit_active = "0"
                bdel_active = "0"
                checkFormAccess(Name)
                button_main(bnew_active, bedit_active, bdel_active)
                '
            Else
                'show all
                bnew_active = "1"
                bedit_active = "1"
                bdel_active = "1"
                checkFormAccess(Name)
                button_main(bnew_active, bedit_active, bdel_active)
                '
            End If
        Else
            'city
            If GVCity.RowCount < 1 Then
                'hide all except new
                bnew_active = "1"
                bedit_active = "0"
                bdel_active = "0"
                checkFormAccess(Name)
                button_main(bnew_active, bedit_active, bdel_active)
                '
            Else
                'show all
                bnew_active = "1"
                bedit_active = "1"
                bdel_active = "1"
                checkFormAccess(Name)
                button_main(bnew_active, bedit_active, bdel_active)
                '
            End If
        End If
    End Sub

    Private Sub GVCountry_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GVCountry.DoubleClick
        Cursor = Cursors.WaitCursor
        If GVCountry.RowCount > 0 Then
            FormMain.but_edit()
        End If
        Cursor = Cursors.Default
    End Sub

    Private Sub BtnAdd_Click(sender As Object, e As EventArgs) Handles BtnAdd.Click
        Cursor = Cursors.WaitCursor
        'country
        FormMasterCountrySingle.id_country = "-1"
        FormMasterCountrySingle.ShowDialog()
        Cursor = Cursors.Default
    End Sub

    Private Sub BtnEdit_Click(sender As Object, e As EventArgs) Handles BtnEdit.Click
        Cursor = Cursors.WaitCursor
        'country
        FormMasterCountrySingle.id_country = GVCountry.GetFocusedRowCellDisplayText("id_country").ToString
        FormMasterCountrySingle.ShowDialog()
        Cursor = Cursors.Default
    End Sub

    Private Sub BtnDelete_Click(sender As Object, e As EventArgs) Handles BtnDelete.Click
        Cursor = Cursors.WaitCursor
        'country
        Dim confirm As DialogResult = DevExpress.XtraEditors.XtraMessageBox.Show("Are you sure want to delete this country?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)

        Dim id_country As String = GVCountry.GetFocusedRowCellDisplayText("id_country").ToString
        If confirm = Windows.Forms.DialogResult.Yes Then
            Cursor = Cursors.WaitCursor
            Try
                Dim query As String = String.Format("DELETE FROM tb_m_country WHERE id_country = '{0}'", id_country)
                execute_non_query(query, True, "", "", "", "")
                view_country()
            Catch ex As Exception
                DevExpress.XtraEditors.XtraMessageBox.Show("This country already used.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
            Cursor = Cursors.Default
        End If
        Cursor = Cursors.Default
    End Sub

    Private Sub FormMasterArea_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        If id_pop_up = "1" Then
            FormMasterEmployeeNewDet.viewCountry()
        End If

        If id_pop_up = "2" Then
            FormEmployeePpsDet.viewCountry()
        End If
    End Sub
End Class