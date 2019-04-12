Public Class FormFGRepairReturnRec
    Dim bnew_active As String = "1"
    Dim bedit_active As String = "1"
    Dim bdel_active As String = "1"

    Private Sub FormFGRepairReturnRec_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'date now
        Dim data As DataTable = execute_query("SELECT DATE(NOW()) AS `tgl`", -1, True, "", "", "", "")
        DEFrom.EditValue = data.Rows(0)("tgl")
        DEUntil.EditValue = data.Rows(0)("tgl")

        'list
        viewRepairList()
    End Sub

    Private Sub FormFGRepairReturnRec_Activated(sender As Object, e As EventArgs) Handles MyBase.Activated
        FormMain.show_rb(Name)
        check_menu()
    End Sub

    Private Sub FormFGRepairReturnRec_Deactivate(sender As Object, e As EventArgs) Handles MyBase.Deactivate
        FormMain.hide_rb()
    End Sub

    Sub check_menu()
        If XTCRepairRec.SelectedTabPageIndex = 0 Then
            If GVRepairRec.RowCount < 1 Then
                'hide all except new
                bnew_active = "0"
                bedit_active = "0"
                bdel_active = "0"
                checkFormAccess(Name)
                button_main(bnew_active, bedit_active, bdel_active)
                noManipulating()
            Else
                'show all
                bnew_active = "0"
                bedit_active = "1"
                bdel_active = "1"
                checkFormAccess(Name)
                button_main(bnew_active, bedit_active, bdel_active)
                noManipulating()
            End If
        Else
            If GVRepairRec.RowCount < 1 Then
                'hide all except new
                bnew_active = "0"
                bedit_active = "0"
                bdel_active = "0"
                checkFormAccess(Name)
                button_main(bnew_active, bedit_active, bdel_active)
                noManipulating()
            Else
                'show all
                bnew_active = "1"
                bedit_active = "0"
                bdel_active = "0"
                checkFormAccess(Name)
                button_main(bnew_active, bedit_active, bdel_active)
                noManipulating()
            End If
        End If
    End Sub

    Sub noManipulating()
        If XTCRepairRec.SelectedTabPageIndex = 0 Then
            Dim indeks As Integer = 0
            Try
                indeks = GVRepairRec.FocusedRowHandle
            Catch ex As Exception
            End Try
            If indeks < 0 Then
                bnew_active = "0"
                bedit_active = "0"
                bdel_active = "0"
            Else
                bnew_active = "0"
                bedit_active = "1"
                bdel_active = "1"
            End If
            checkFormAccess(Name)
            button_main(bnew_active, bedit_active, bdel_active)
        Else
            Dim indeks As Integer = 0
            Try
                indeks = GVRepairList.FocusedRowHandle
            Catch ex As Exception
            End Try
            If indeks < 0 Then
                bnew_active = "0"
                bedit_active = "0"
                bdel_active = "0"
            Else
                bnew_active = "1"
                bedit_active = "0"
                bdel_active = "0"
            End If
            checkFormAccess(Name)
            button_main(bnew_active, bedit_active, bdel_active)
        End If
    End Sub

    Private Sub GVRepairRec_FocusedRowChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles GVRepairRec.FocusedRowChanged
        noManipulating()
    End Sub

    Private Sub GVRepairRec_ColumnFilterChanged(sender As Object, e As EventArgs) Handles GVRepairRec.ColumnFilterChanged
        noManipulating()
    End Sub

    Private Sub GVRepairList_ColumnFilterChanged(sender As Object, e As EventArgs) Handles GVRepairList.ColumnFilterChanged
        noManipulating()
    End Sub

    Private Sub GVRepairList_FocusedRowChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles GVRepairList.FocusedRowChanged
        noManipulating()
    End Sub

    Sub viewData()
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

        Dim query_c As New ClassFGRepairReturnRec()
        Dim query As String = query_c.queryMain("AND (rec.fg_repair_return_rec_date>='" + date_from_selected + "' AND rec.fg_repair_return_rec_date<='" + date_until_selected + "') ", "2")
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCRepairRec.DataSource = data
        check_menu()
    End Sub

    Sub viewRepairList()
        Dim query_c As New ClassFGRepairReturnRec()
        Dim query As String = query_c.queryRepairList("AND r.is_from_vendor=2", "1")
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCRepairList.DataSource = data
        check_menu()
    End Sub

    Private Sub BtnView_Click(sender As Object, e As EventArgs) Handles BtnView.Click
        Cursor = Cursors.WaitCursor
        viewData()
        Cursor = Cursors.Default
    End Sub

    Private Sub XTCRepairRec_SelectedPageChanged(sender As Object, e As DevExpress.XtraTab.TabPageChangedEventArgs) Handles XTCRepairRec.SelectedPageChanged
        check_menu()
    End Sub

    Private Sub SMPrePrint_Click(sender As Object, e As EventArgs) Handles SMPrePrint.Click
        'Cursor = Cursors.WaitCursor
        'FormFGRepairRecDet.id_pre = "1"
        'FormMain.but_edit()
        'Cursor = Cursors.Default
    End Sub

    Private Sub SMPrint_Click(sender As Object, e As EventArgs) Handles SMPrint.Click
        'Cursor = Cursors.WaitCursor
        'FormFGRepairRecDet.id_pre = "2"
        'FormMain.but_edit()
        'Cursor = Cursors.Default
    End Sub

    Private Sub GVRepairRec_DoubleClick(sender As Object, e As EventArgs) Handles GVRepairRec.DoubleClick
        If GVRepairRec.FocusedRowHandle >= 0 And GVRepairRec.RowCount > 0 Then
            FormMain.but_edit()
        End If
    End Sub
End Class