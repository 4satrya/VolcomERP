Public Class FormFGRepairReturn
    Dim bnew_active As String = "1"
    Dim bedit_active As String = "1"
    Dim bdel_active As String = "1"
    Public is_from_vendor As Boolean = False

    Private Sub FormFGRepairReturn_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'date now
        Dim data As DataTable = execute_query("SELECT DATE(NOW()) AS `tgl`", -1, True, "", "", "", "")
        DEFrom.EditValue = data.Rows(0)("tgl")
        DEUntil.EditValue = data.Rows(0)("tgl")

        If is_from_vendor = True Then
            Text = "Receive Repair from Vendor"
        End If
    End Sub

    Private Sub FormFGRepairReturn_Activated(sender As Object, e As EventArgs) Handles MyBase.Activated
        FormMain.show_rb(Name)
        check_menu()
    End Sub

    Private Sub FormFGRepairReturn_Deactivate(sender As Object, e As EventArgs) Handles MyBase.Deactivate
        FormMain.hide_rb()
    End Sub

    Sub check_menu()
        If GVRepairReturn.RowCount < 1 Then
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
            indeks = GVRepairReturn.FocusedRowHandle
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

    Private Sub GVRepairReturn_ColumnFilterChanged(sender As Object, e As EventArgs) Handles GVRepairReturn.ColumnFilterChanged
        noManipulating()
    End Sub

    Private Sub GVRepairReturn_FocusedRowChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles GVRepairReturn.FocusedRowChanged
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

        Dim is_vendor As String = ""
        If is_from_vendor = True Then
            is_vendor = "1"
        Else
            is_vendor = "2"
        End If

        Dim query_c As New ClassFGRepairReturn()
        Dim query As String = query_c.queryMain("AND r.is_from_vendor=" + is_vendor + " AND (r.fg_repair_return_date>='" + date_from_selected + "' AND r.fg_repair_return_date<='" + date_until_selected + "') ", "2")
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCRepairReturn.DataSource = data
        check_menu()
    End Sub

    Private Sub BtnView_Click(sender As Object, e As EventArgs) Handles BtnView.Click
        Cursor = Cursors.WaitCursor
        viewData()
        Cursor = Cursors.Default
    End Sub

    Private Sub SMPrePrint_Click(sender As Object, e As EventArgs) Handles SMPrePrint.Click
        Cursor = Cursors.WaitCursor
        FormFGRepairReturnDet.id_pre = "1"
        FormMain.but_edit()
        Cursor = Cursors.Default
    End Sub

    Private Sub SMPrint_Click(sender As Object, e As EventArgs) Handles SMPrint.Click
        Cursor = Cursors.WaitCursor
        FormFGRepairReturnDet.id_pre = "2"
        FormMain.but_edit()
        Cursor = Cursors.Default
    End Sub

    Private Sub GVRepairReturn_DoubleClick(sender As Object, e As EventArgs) Handles GVRepairReturn.DoubleClick
        If GVRepairReturn.RowCount > 0 And GVRepairReturn.FocusedRowHandle >= 0 Then
            FormMain.but_edit()
        End If
    End Sub
End Class