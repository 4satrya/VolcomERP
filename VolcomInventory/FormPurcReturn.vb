Public Class FormPurcReturn
    Dim bnew_active As String = "1"
    Dim bedit_active As String = "1"
    Dim bdel_active As String = "1"

    Private Sub FormPurcReturn_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        load_vendor()
    End Sub

    Sub load_vendor()
        Dim query As String = "SELECT 0 AS id_comp,'All Vendor' AS comp_number,'All Vendor' AS comp_name
                               UNION
                               SELECT id_comp,comp_number,comp_name FROM tb_m_comp WHERE id_comp_cat='1'"
        viewSearchLookupQuery(SLEVendor, query, "id_comp", "comp_name", "id_comp")
    End Sub

    Sub viewOrder()
        Cursor = Cursors.WaitCursor
        Dim where_string As String = ""

        If SLEVendor.EditValue.ToString = "0" Then
            where_string = ""
        Else
            where_string = " AND c.id_comp='" & SLEVendor.EditValue.ToString & "'"
        End If
        where_string += "AND po.id_report_status=6 "

        Dim po As New ClassPurcOrder()
        Dim query As String = po.queryMain(where_string, "1", False)
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCPO.DataSource = data
        GVPO.BestFitColumns()
        check_menu()
        Cursor = Cursors.Default
    End Sub

    Sub viewReturn()
        Cursor = Cursors.WaitCursor
        Dim r As New ClassPurcReturn()
        Dim query As String = r.queryMain("-1", "2")
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCReturn.DataSource = data
        GVReturn.BestFitColumns()
        check_menu()
        Cursor = Cursors.Default
    End Sub

    Private Sub FormPurcReturn_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub FormPurcReturn_Activated(sender As Object, e As EventArgs) Handles MyBase.Activated
        FormMain.show_rb(Name)
        check_menu()
    End Sub

    Private Sub FormPurcReturn_Deactivate(sender As Object, e As EventArgs) Handles MyBase.Deactivate
        FormMain.hide_rb()
    End Sub

    Sub check_menu()
        If XTCReturn.SelectedTabPageIndex = 0 Then
            If GVPO.RowCount < 1 Then
                'hide all except new
                bnew_active = "0"
                bedit_active = "0"
                bdel_active = "0"
                checkFormAccess(Name)
                button_main(bnew_active, bedit_active, bdel_active)
            Else
                'show all
                bnew_active = "1"
                bedit_active = "0"
                bdel_active = "0"
                noManipulating()
            End If
        ElseIf XTCReturn.SelectedTabPageIndex = 1 Then
            If GVReturn.RowCount < 1 Then
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
        End If
    End Sub

    Sub noManipulating()
        Try
            Dim indeks As Integer = 0
            If XTCReturn.SelectedTabPageIndex = 0 Then
                indeks = GVPO.FocusedRowHandle
                If indeks < 0 Then
                    bnew_active = "0"
                    bedit_active = "0"
                    bdel_active = "0"
                Else
                    bnew_active = "1"
                    bedit_active = "0"
                    bdel_active = "0"
                End If
            ElseIf XTCReturn.SelectedTabPageIndex = 1 Then
                indeks = GVReturn.FocusedRowHandle
                If indeks < 0 Then
                    bnew_active = "0"
                    bedit_active = "0"
                    bdel_active = "0"
                Else
                    bnew_active = "0"
                    bedit_active = "1"
                    bdel_active = "0"
                End If
            End If
            checkFormAccess(Name)
            button_main(bnew_active, bedit_active, bdel_active)
        Catch ex As Exception
        End Try
    End Sub

    Private Sub GVPO_FocusedRowChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles GVPO.FocusedRowChanged
        noManipulating()
    End Sub

    Private Sub GVReturn_FocusedRowChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles GVReturn.FocusedRowChanged
        noManipulating()
    End Sub

    Private Sub GVReturn_DoubleClick(sender As Object, e As EventArgs) Handles GVReturn.DoubleClick
        Cursor = Cursors.WaitCursor
        FormMain.but_edit()
        Cursor = Cursors.Default
    End Sub

    Private Sub XTCReturn_SelectedPageChanged(sender As Object, e As DevExpress.XtraTab.TabPageChangedEventArgs) Handles XTCReturn.SelectedPageChanged
        check_menu()
        If XTCReturn.SelectedTabPageIndex = 0 Then
            viewOrder()
        ElseIf XTCReturn.SelectedTabPageIndex = 1 Then
            viewReturn()
        End If
    End Sub

    Private Sub BView_Click(sender As Object, e As EventArgs) Handles BView.Click
        viewOrder()
    End Sub
End Class