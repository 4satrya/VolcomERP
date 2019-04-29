Public Class FormItemCatMapping
    Dim bnew_active As String = "1"
    Dim bedit_active As String = "1"
    Dim bdel_active As String = "1"

    Private Sub FormItemCatMapping_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        generalMapping()
        viewDept()
        viewCat()
        viewPropose()
    End Sub

    Sub generalMapping()
        'load general account-current
        Dim qcg As String = "SELECT h.acc_name AS `code_hutang`, h.acc_description AS `name_hutang`,
        r.acc_name AS `code_inv_store`, r.acc_description AS `name_inv_store`,
        t.acc_name AS `code_inv_wh`, t.acc_description AS `name_inv_wh`
        FROM tb_opt_purchasing o
        LEFT JOIN tb_a_acc h ON h.id_acc = o.acc_coa_hutang
        LEFT JOIN tb_a_acc r ON r.id_acc = o.acc_coa_receive
        LEFT JOIN tb_a_acc t ON t.id_acc = o.acc_coa_trf "
        Dim dcg As DataTable = execute_query(qcg, -1, True, "", "", "", "")
        TxtCurrentCodeInvStore.Text = dcg.Rows(0)("code_inv_store").ToString
        TxtCurrentDescInvStore.Text = dcg.Rows(0)("name_inv_store").ToString
        TxtCurrentCodeHutang.Text = dcg.Rows(0)("code_hutang").ToString
        TxtCurrentDescHutang.Text = dcg.Rows(0)("name_hutang").ToString
        TxtCurrentCodeInvWH.Text = dcg.Rows(0)("code_inv_wh").ToString
        TxtCurrentDescInvWH.Text = dcg.Rows(0)("name_inv_wh").ToString
    End Sub

    Sub viewMapping()
        Cursor = Cursors.WaitCursor

        'load general mapp
        generalMapping()

        'dept
        Dim dept As String = ""
        If LEDeptSum.EditValue.ToString <> "0" Then
            dept = "AND m.id_departement='" + LEDeptSum.EditValue.ToString + "' "
        Else
            dept = ""
        End If

        'cat
        Dim cat As String = ""
        If SLECat.EditValue.ToString <> "0" Then
            cat = "AND m.id_item_cat='" + SLECat.EditValue.ToString + "' "
        Else
            cat = ""
        End If


        Dim map As New ClassItemCat()
        Dim query As String = map.queryMapping("AND 1=1 " + dept + cat, "1")
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCMapping.DataSource = data
        GVMapping.BestFitColumns()
        Cursor = Cursors.Default
    End Sub

    Sub viewPropose()
        Dim m As New ClassItemCat()
        Dim query As String = m.queryMappingPropose("-1", "2")
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCPropose.DataSource = data
        GVPropose.BestFitColumns()
    End Sub

    Sub viewDept()
        Cursor = Cursors.WaitCursor
        Dim query As String = "SELECT 0 as id_departement, 'All departement' as departement UNION  "
        query += "(SELECT id_departement,departement FROM tb_m_departement a ORDER BY a.departement ASC) "
        viewLookupQuery(LEDeptSum, query, 0, "departement", "id_departement")
        Cursor = Cursors.Default
    End Sub

    Sub viewCat()
        Cursor = Cursors.WaitCursor
        Dim query As String = "SELECT 0 AS `id_item_cat`, 'All Category' AS `item_cat`
        UNION ALL
        SELECT c.id_item_cat, c.item_cat FROM tb_item_cat c ORDER BY id_item_cat ASC"
        viewSearchLookupQuery(SLECat, query, "id_item_cat", "item_cat", "id_item_cat")
        Cursor = Cursors.Default
    End Sub

    Private Sub FormItemCatMapping_Activated(sender As Object, e As EventArgs) Handles MyBase.Activated
        FormMain.show_rb(Name)
        check_menu()
    End Sub

    Sub check_menu()
        If XTCMapping.SelectedTabPageIndex = 0 Then
            bnew_active = "0"
            bedit_active = "0"
            bdel_active = "0"
            button_main(bnew_active, bedit_active, bdel_active)
        ElseIf XTCMapping.SelectedTabPageIndex = 1 Then
            If GVPropose.RowCount < 1 Then
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
            Dim indeks As Integer = GVPropose.FocusedRowHandle
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


    Private Sub FormItemCatMapping_Deactivate(sender As Object, e As EventArgs) Handles MyBase.Deactivate
        FormMain.hide_rb()
    End Sub

    Private Sub XTCMapping_SelectedPageChanged(sender As Object, e As DevExpress.XtraTab.TabPageChangedEventArgs) Handles XTCMapping.SelectedPageChanged
        check_menu()
    End Sub

    Private Sub GVPropose_DoubleClick(sender As Object, e As EventArgs) Handles GVPropose.DoubleClick
        If GVPropose.RowCount > 0 And GVPropose.FocusedRowHandle >= 0 Then
            FormMain.but_edit()
        End If
    End Sub

    Private Sub BtnView_Click(sender As Object, e As EventArgs) Handles BtnView.Click
        viewMapping()
    End Sub

    Private Sub LEDeptSum_EditValueChanged(sender As Object, e As EventArgs) Handles LEDeptSum.EditValueChanged
        GCMapping.DataSource = Nothing
    End Sub

    Private Sub LECat_EditValueChanged(sender As Object, e As EventArgs)
        GCMapping.DataSource = Nothing
    End Sub

    Private Sub SLECat_EditValueChanged(sender As Object, e As EventArgs) Handles SLECat.EditValueChanged
        GCMapping.DataSource = Nothing
    End Sub
End Class