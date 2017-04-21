Public Class FormAccessMappingSingle
    Dim check_value As String
    Dim id_form_control As String
    Dim id_role As String = FormAccess.GVRole.GetFocusedRowCellDisplayText("id_role").ToString
    Dim id_form As String
    'Form Load
    Private Sub FormAccessMappingSingle_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        viewMenu()
        LabelRole.Text = FormAccess.GVRole.GetFocusedRowCellDisplayText("role").ToString
    End Sub
    'View Menu
    Sub viewMenu()
        Dim query As String = "SELECT d.id_form_control, d.description_form_control,a.description_menu_name, "
        query += "e.group_menu, IF(!ISNULL(f.id_form_control), 'Yes', 'No') AS is_select, d.is_view, d.id_form, ('No') AS is_changed FROM tb_menu a "
        query += "INNER JOIN tb_menu_involved b ON a.id_menu = b.id_menu "
        query += "INNER JOIN tb_menu_form c ON b.id_form = c.id_form "
        query += "INNER JOIN tb_menu_form_control d ON d.id_form = c.id_form "
        query += "INNER JOIN tb_lookup_group_menu e ON a.id_group_menu = e.id_group_menu "
        query += "LEFT JOIN tb_menu_acc f ON d.id_form_control = f.id_form_control AND f.id_role = '" + id_role + "' "
        query += "ORDER BY d.id_form ASC, d.is_view ASC "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCMenu.DataSource = data
        GVMenu.Columns("group_menu").GroupIndex = 0
        GVMenu.Columns("description_menu_name").GroupIndex = 1
    End Sub
    'When Process Start
    Private Sub processStart()
        GCMenu.Enabled = False
        BtnClose.Enabled = False
        Me.ControlBox = False
    End Sub
    'When Process End
    Private Sub processEnd()
        GCMenu.Enabled = True
        BtnClose.Enabled = True
        Me.ControlBox = True
    End Sub
    'Form Close
    Private Sub FormAccessMappingSingle_FormClosed(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub
    'Form Close
    Private Sub BtnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnClose.Click
        Close()
    End Sub
    Private flag As Boolean = False
    'Btn Save
    Private Sub BtnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSave.Click
        Cursor = Cursors.WaitCursor
        processStart()
        makeSafeGV(GVMenu)
        Dim query As String
        Dim query_cek As String
        Dim jum As Integer
        Dim success As Boolean = False
        Dim checked_var As String
        Dim id_form_control_view As String
        Dim is_changed As String
        'Dim must_view = False
        For i As Integer = 0 To ((GVMenu.RowCount - 1) - GetGroupRowCount(GVMenu))
            id_form_control = GVMenu.GetRowCellValue(i, "id_form_control").ToString
            check_value = GVMenu.GetRowCellValue(i, "is_view").ToString
            id_form = GVMenu.GetRowCellValue(i, "id_form").ToString
            checked_var = GVMenu.GetRowCellDisplayText(i, GridColumnStatus).ToString
            is_changed = GVMenu.GetRowCellValue(i, "is_changed").ToString
            Try
                'too slow broo
                If i = 0 Then
                    query = "DELETE FROM tb_menu_acc WHERE id_role = '" + id_role + "'"
                    execute_non_query(query, True, "", "", "", "")
                End If

                If checked_var = "Checked" Then
                    query = "INSERT INTO tb_menu_acc(id_role, id_form_control) VALUES('{0}', '{1}')"
                    query = String.Format(query, id_role, id_form_control)
                    execute_non_query(query, True, "", "", "", "")

                    If check_value = "2" Then
                        query_cek = "select count(*) from tb_menu_acc a "
                        query_cek += "inner join tb_menu_form_control b on a.id_form_control = b.id_form_control "
                        query_cek += "where a.id_role = '" + id_role + "' and b.id_form = '" + id_form + "' and b.is_view = '1' "
                        jum = execute_query(query_cek, 0, True, "", "", "", "")
                        If jum < 1 Then
                            query_cek = "select id_form_control from tb_menu_form_control where id_form = '" + id_form + "' and is_view = '1' "
                            id_form_control_view = execute_query(query_cek, 0, True, "", "", "", "")
                            query = "insert into tb_menu_acc(id_role, id_form_control) values('{0}', '{1}')"
                            query = String.Format(query, id_role, id_form_control_view)
                            execute_non_query(query, True, "", "", "", "")
                        End If
                    End If
                End If
                logData("tb_menu_acc", 2)
                success = True
            Catch ex As Exception
                success = False
            End Try
            progres_bar_update(i, GVMenu.RowCount - 1)
        Next
        If success Then
            Close()
        Else
            errorConnection()
            Close()
        End If
        FormMain.BEProgress.EditValue = 0
        Cursor = Cursors.Default
    End Sub
    Private Sub CheckEditSelAll_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckEditSelAll.CheckedChanged
        Dim cek As String = CheckEditSelAll.EditValue.ToString
        For i As Integer = 0 To (GVMenu.RowCount - 1)
            Try
                If cek Then
                    GVMenu.SetRowCellValue(i, "is_select", "Yes")
                Else
                    GVMenu.SetRowCellValue(i, "is_select", "No")
                End If
                GVMenu.SetRowCellValue(i, "is_changed", "Yes")
            Catch ex As Exception

            End Try
        Next
    End Sub
    Private Sub RepositoryItemCheckEdit1_EditValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RepositoryItemCheckEdit1.EditValueChanged
        Try
            GVMenu.SetFocusedRowCellValue("is_changed", "Yes")
        Catch ex As Exception
        End Try
    End Sub
    Private Sub BPrint_Click(sender As Object, e As EventArgs) Handles BPrint.Click
        Cursor = Cursors.WaitCursor
        GVMenu.ActiveFilterString = "[is_select]='Yes'"
        print(GCMenu, "Access Menu")
        Cursor = Cursors.Default
    End Sub
End Class