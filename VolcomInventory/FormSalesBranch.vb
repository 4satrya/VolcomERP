Public Class FormSalesBranch
    Dim bnew_active As String = "1"
    Dim bedit_active As String = "1"
    Dim bdel_active As String = "1"

    Private Sub FormSalesBranch_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        viewData()
    End Sub

    Sub viewData()
        Cursor = Cursors.WaitCursor

        Cursor = Cursors.Default
    End Sub

    Private Sub FormSalesBranch_Activated(sender As Object, e As EventArgs) Handles MyBase.Activated
        FormMain.show_rb(Name)
        check_menu()
    End Sub

    Sub check_menu()
        If GVData.RowCount < 1 Then
            'hide all except new
            bnew_active = "0"
            bedit_active = "0"
            bdel_active = "0"
            checkFormAccess(Name)
            button_main(bnew_active, bedit_active, bdel_active)
        Else
            'show all
            bnew_active = "0"
            bedit_active = "1"
            bdel_active = "0"
            noManipulating()
        End If
    End Sub

    Sub noManipulating()
        Dim indeks As Integer = -1
        Try
            indeks = GVData.FocusedRowHandle
        Catch ex As Exception
        End Try
        If indeks < 0 Then
            bnew_active = "0"
            bedit_active = "0"
            bdel_active = "0"
        Else
            bnew_active = "1"
            bedit_active = "1"
            bdel_active = "1"
        End If
        checkFormAccess(Name)
        button_main(bnew_active, bedit_active, bdel_active)
    End Sub

    Private Sub FormSalesBranch_Deactivate(sender As Object, e As EventArgs) Handles MyBase.Deactivate
        FormMain.hide_rb()
    End Sub
End Class