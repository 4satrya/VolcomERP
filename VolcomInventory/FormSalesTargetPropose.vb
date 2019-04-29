Public Class FormSalesTargetPropose
    Dim bnew_active As String = "1"
    Dim bedit_active As String = "1"
    Dim bdel_active As String = "1"
    Public is_new As Boolean = False

    Private Sub FormSalesTargetPropose_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        viewPropose()
    End Sub

    Private Sub FormSalesTargetPropose_Activated(sender As Object, e As EventArgs) Handles MyBase.Activated
        FormMain.show_rb(Name)
        check_menu()
    End Sub

    Private Sub FormSalesTargetPropose_Deactivate(sender As Object, e As EventArgs) Handles MyBase.Deactivate
        FormMain.hide_rb()
    End Sub

    Sub check_menu()
        If XTCPropose.SelectedTabPageIndex = 0 Then
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
                bdel_active = "1"
                noManipulating()
            End If
        ElseIf XTCPropose.SelectedTabPageIndex = 1 Then
            'If GVRev.RowCount < 1 Then
            '    'hide all except new
            '    bnew_active = "1"
            '    bedit_active = "0"
            '    bdel_active = "0"
            '    checkFormAccess(Name)
            '    button_main(bnew_active, bedit_active, bdel_active)
            'Else
            '    'show all
            '    bnew_active = "1"
            '    bedit_active = "1"
            '    bdel_active = "1"
            '    noManipulating()
            'End If
        ElseIf XTCPropose.SelectedTabPageIndex = 2 Then
            'If GVCompare.RowCount < 1 Then
            '    'hide all except new
            '    bnew_active = "0"
            '    bedit_active = "0"
            '    bdel_active = "0"
            '    checkFormAccess(Name)
            '    button_main(bnew_active, bedit_active, bdel_active)
            'Else
            '    'show all
            '    bnew_active = "0"
            '    bedit_active = "0"
            '    bdel_active = "0"
            '    noManipulating()
            'End If
        End If
    End Sub

    Sub noManipulating()
        If XTCPropose.SelectedTabPageIndex = 0 Then
            Dim indeks As Integer = -1
            Try
                indeks = GVData.FocusedRowHandle
            Catch ex As Exception
            End Try
            If indeks < 0 Then
                bnew_active = "1"
                bedit_active = "0"
                bdel_active = "0"
            Else
                bnew_active = "1"
                bedit_active = "1"
                bdel_active = "1"
            End If
            checkFormAccess(Name)
            button_main(bnew_active, bedit_active, bdel_active)
        ElseIf XTCPropose.SelectedTabPageIndex = 1 Then
            'Dim indeks As Integer = -1
            'Try
            '    indeks = GVRev.FocusedRowHandle
            'Catch ex As Exception
            'End Try
            'If indeks < 0 Then
            '    bnew_active = "1"
            '    bedit_active = "0"
            '    bdel_active = "0"
            'Else
            '    bnew_active = "1"
            '    bedit_active = "1"
            '    bdel_active = "1"
            'End If
            'checkFormAccess(Name)
            'button_main(bnew_active, bedit_active, bdel_active)
        ElseIf XTCPropose.SelectedTabPageIndex = 2 Then
            'Dim indeks As Integer = -1
            'Try
            '    indeks = GVCompare.FocusedRowHandle
            'Catch ex As Exception
            'End Try
            'If indeks < 0 Then
            '    bnew_active = "0"
            '    bedit_active = "0"
            '    bdel_active = "0"
            'Else
            '    bnew_active = "0"
            '    bedit_active = "0"
            '    bdel_active = "0"
            'End If
            'checkFormAccess(Name)
            'button_main(bnew_active, bedit_active, bdel_active)
        End If
    End Sub

    Sub viewPropose()
        Cursor = Cursors.WaitCursor
        Dim t As New ClassSalesTarget()
        Dim query As String = t.queryMain("-1", "2")
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCData.DataSource = data
        GVData.BestFitColumns()
        check_menu()
        Cursor = Cursors.Default
    End Sub

    Sub viewRevision()

    End Sub

    Private Sub GVData_DoubleClick(sender As Object, e As EventArgs) Handles GVData.DoubleClick
        If GVData.RowCount > 0 And GVData.FocusedRowHandle >= 0 Then
            Cursor = Cursors.WaitCursor
            FormMain.but_edit()
            Cursor = Cursors.Default
        End If
    End Sub

    Private Sub XTCPropose_SelectedPageChanged(sender As Object, e As DevExpress.XtraTab.TabPageChangedEventArgs) Handles XTCPropose.SelectedPageChanged
        check_menu()
        If XTCPropose.SelectedTabPageIndex = 0 Then
            viewPropose()
        ElseIf XTCPropose.SelectedTabPageIndex = 1 Then
            viewRevision()
        End If
    End Sub

    Sub openNewTrans()
        If is_new Then
            Cursor = Cursors.WaitCursor
            FormMain.but_edit()
            is_new = False
            Cursor = Cursors.Default
        End If
    End Sub
End Class