Public Class FormItemCatPropose
    Dim bnew_active As String = "1"
    Dim bedit_active As String = "1"
    Dim bdel_active As String = "1"

    Private Sub FormItemCatPropose_Activated(sender As Object, e As EventArgs) Handles MyBase.Activated
        FormMain.show_rb(Name)
        check_menu()
    End Sub

    Sub check_menu()
        If XTCCat.SelectedTabPageIndex = 0 Then
            bnew_active = "0"
            bedit_active = "0"
            bdel_active = "0"
            button_main(bnew_active, bedit_active, bdel_active)
        ElseIf XTCCat.SelectedTabPageIndex = 1 Then
            If GVData.RowCount < 1 Then
                'hide all except new
                bnew_active = "1"
                bedit_active = "0"
                bdel_active = "0"
                checkFormAccess(Name)
                button_main(bnew_active, bedit_active, bdel_active)
            Else
                'show all
                bnew_active = "1"
                bedit_active = "1"
                bdel_active = "0"
                noManipulating()
            End If
        End If
    End Sub

    Sub noManipulating()
        Try
            Dim indeks As Integer = GVData.FocusedRowHandle
            If indeks < 0 Then
                bnew_active = "1"
                bedit_active = "0"
                bdel_active = "0"
            Else
                bnew_active = "1"
                bedit_active = "1"
                bdel_active = "0"
            End If
            checkFormAccess(Name)
            button_main(bnew_active, bedit_active, bdel_active)
        Catch ex As Exception
        End Try
    End Sub

    Private Sub FormItemCatPropose_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        viewCat()
        viewPropose()
    End Sub

    Sub viewCat()
        Cursor = Cursors.WaitCursor
        Dim cat As New ClassItemCat()
        Dim qm As String = cat.queryMaster("-1", "2")
        Dim dm As DataTable = execute_query(qm, -1, True, "", "", "", "")
        GCItemCat.DataSource = dm
        Cursor = Cursors.Default
    End Sub

    Sub viewPropose()
        Cursor = Cursors.WaitCursor
        Dim cat As New ClassItemCat()
        Dim qm As String = cat.queryMain("-1", "2")
        Dim dm As DataTable = execute_query(qm, -1, True, "", "", "", "")
        GCData.DataSource = dm
        Cursor = Cursors.Default
    End Sub

    Private Sub FormItemCatPropose_Deactivate(sender As Object, e As EventArgs) Handles MyBase.Deactivate
        FormMain.hide_rb()
    End Sub

    Private Sub XTCCat_SelectedPageChanged(sender As Object, e As DevExpress.XtraTab.TabPageChangedEventArgs) Handles XTCCat.SelectedPageChanged
        check_menu()
    End Sub

    Private Sub GVData_DoubleClick(sender As Object, e As EventArgs) Handles GVData.DoubleClick
        If GVData.RowCount > 0 And GVData.FocusedRowHandle >= 0 Then
            FormMain.but_edit()
        End If
    End Sub
End Class