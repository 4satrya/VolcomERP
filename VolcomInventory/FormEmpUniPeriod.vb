Public Class FormEmpUniPeriod
    Dim bnew_active As String = "1"
    Dim bedit_active As String = "1"
    Dim bdel_active As String = "1"

    Private Sub FormEmpUniPeriod_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        viewUniformPeriod()
    End Sub

    Private Sub FormEmpUniPeriod_Activated(sender As Object, e As EventArgs) Handles MyBase.Activated
        FormMain.show_rb(Name)
        check_menu()
    End Sub

    Private Sub FormEmpUniPeriod_Deactivate(sender As Object, e As EventArgs) Handles MyBase.Deactivate
        FormMain.hide_rb()
    End Sub

    Sub check_menu()
        If GVUni.RowCount < 1 Then
            'hide all except new
            bnew_active = "1"
            bedit_active = "0"
            bdel_active = "0"
            checkFormAccess(Name)
            button_main(bnew_active, bedit_active, bdel_active)
            noManipulating()
        Else
            'show all
            bnew_active = "1"
            bedit_active = "1"
            bdel_active = "1"
            checkFormAccess(Name)
            button_main(bnew_active, bedit_active, bdel_active)
            noManipulating()
        End If
    End Sub

    Sub noManipulating()
        Dim indeks As Integer = 0
        Try
            indeks = GVUni.FocusedRowHandle
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
    End Sub

    Sub viewUniformPeriod()
        Cursor = Cursors.WaitCursor

        Dim query_c As ClassEmpUni = New ClassEmpUni()
        Dim query As String = query_c.queryMain("-1", "2")
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCUni.DataSource = data
        check_menu()
        Cursor = Cursors.Default
    End Sub

    Private Sub GVUni_FocusedRowChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles GVUni.FocusedRowChanged

    End Sub

    Private Sub GVUni_DoubleClick(sender As Object, e As EventArgs) Handles GVUni.DoubleClick
        If GVUni.FocusedRowHandle >= 0 And GVUni.RowCount > 0 Then
            FormMain.but_edit()
        End If
    End Sub
End Class