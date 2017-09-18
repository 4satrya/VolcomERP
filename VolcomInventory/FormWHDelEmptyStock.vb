Public Class FormWHDelEmptyStock
    Public id_store As String = "-1"
    Public store_code As String = ""
    Public store As String = ""

    Private Sub FormWHDelEmptyStock_Activated(sender As Object, e As EventArgs) Handles MyBase.Activated
        FormMain.show_rb(Name)
        checkFormAccess(Name)
    End Sub

    Private Sub FormWHDelEmptyStock_Deactivate(sender As Object, e As EventArgs) Handles MyBase.Deactivate
        FormMain.hide_rb()
    End Sub

    Private Sub FormWHDelEmptyStock_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ActiveControl = TxtStoreCode
    End Sub

    Private Sub TxtStoreCode_KeyDown(sender As Object, e As KeyEventArgs) Handles TxtStoreCode.KeyDown
        If e.KeyCode = Keys.Enter Then
            Cursor = Cursors.WaitCursor
            Dim query_cond As String = "AND comp.id_comp_cat=6 "
            Dim data As DataTable = get_company_by_code(addSlashes(TxtStoreCode.Text), query_cond)
            If data.Rows.Count = 0 Then
                stopCustom("Account not found!")
                id_store = "-1"
                store_code = ""
                store = ""
                TxtStoreCode.Text = ""
                TxtStore.Text = ""
                TxtStoreCode.Focus()
                GCData.DataSource = Nothing
            Else
                id_store = data.Rows(0)("id_comp").ToString
                TxtStore.Text = data.Rows(0)("comp_name").ToString
                store_code = data.Rows(0)("comp_number").ToString
                store = data.Rows(0)("comp_name").ToString
                GCData.DataSource = Nothing
                BtnView.Focus()
            End If
            Cursor = Cursors.Default
        Else
            id_store = "-1"
            store_code = ""
            store = ""
            TxtStore.Text = ""
            GCData.DataSource = Nothing
        End If
    End Sub

    Private Sub BtnView_Click(sender As Object, e As EventArgs) Handles BtnView.Click
        viewNonInvStock()
    End Sub

    Sub viewNonInvStock()
        Cursor = Cursors.WaitCursor
        Dim query As String = "CALL view_wh_non_stock_inv(" + id_store + ") "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCData.DataSource = data
        Cursor = Cursors.Default
    End Sub

    Sub checkFocus()
        If XTCStock.SelectedTabPageIndex = 0 Then
            TxtStoreCode.Focus()
        End If
    End Sub

    Private Sub XTCStock_SelectedPageChanged(sender As Object, e As DevExpress.XtraTab.TabPageChangedEventArgs) Handles XTCStock.SelectedPageChanged
        checkFocus()
    End Sub
End Class