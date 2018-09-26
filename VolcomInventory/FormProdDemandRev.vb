Public Class FormProdDemandRev
    Dim bnew_active As String = "1"
    Dim bedit_active As String = "1"
    Dim bdel_active As String = "1"

    Private Sub FormProdDemandRev_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        viewData()
    End Sub

    Sub viewData()
        Cursor = Cursors.WaitCursor
        Dim r As New ClassProdDemand
        Dim query As String = r.queryMainRev("-1", "2")
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCData.DataSource = data
        GVData.BestFitColumns()
        Cursor = Cursors.Default
    End Sub

    Private Sub FormProdDemandRev_Activated(sender As Object, e As EventArgs) Handles MyBase.Activated
        FormMain.show_rb(Name)
        check_menu()
    End Sub

    Private Sub FormProdDemandRev_Deactivate(sender As Object, e As EventArgs) Handles MyBase.Deactivate
        FormMain.hide_rb()
    End Sub

    Private Sub FormProdDemandRev_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Sub check_menu()
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

    Private Sub GVData_FocusedRowChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles GVData.FocusedRowChanged
        noManipulating()
    End Sub

    Private Sub GVData_DoubleClick(sender As Object, e As EventArgs) Handles GVData.DoubleClick
        Cursor = Cursors.WaitCursor
        FormMain.but_edit()
        Cursor = Cursors.Default
    End Sub
End Class