Public Class FormBudgetExpenseView
    Dim bnew_active As String = "1"
    Dim bedit_active As String = "1"
    Dim bdel_active As String = "1"
    Public is_view As String = "-1"

    Private Sub FormBudgetExpenseView_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        viewDept()
        viewCat()
        viewYear()
    End Sub

    Sub viewDept()
        Cursor = Cursors.WaitCursor
        Dim query As String = ""
        query += "(SELECT id_departement,departement FROM tb_m_departement a ORDER BY a.departement ASC) "
        viewLookupQuery(LEDeptSum, query, 0, "departement", "id_departement")
        Cursor = Cursors.Default
    End Sub

    Sub viewCat()
        Cursor = Cursors.WaitCursor
        Dim query As String = "SELECT 0 AS `id_item_cat`, 'All Category' AS `item_cat`
        UNION ALL
        SELECT c.id_item_cat, c.item_cat FROM tb_item_cat c ORDER BY id_item_cat ASC"
        viewLookupQuery(LECat, query, 0, "item_cat", "id_item_cat")
        Cursor = Cursors.Default
    End Sub

    Sub viewYear()
        Cursor = Cursors.WaitCursor
        Dim query As String = ""
        Dim j As Integer = 0
        Dim dym As DataTable = execute_query("SELECT YEAR(DATE_ADD(NOW(),INTERVAL 10 YEAR)) AS `ym`", -1, True, "", "", "", "")
        For i As Integer = 2018 To dym.Rows(0)("ym")
            If j > 0 Then
                query += "UNION ALL "
            End If
            query += "SELECT " + i.ToString + " AS `year` "
            j += 1
        Next
        viewLookupQuery(LEYear, query, 0, "year", "year")
        Cursor = Cursors.Default
    End Sub

    Private Sub BtnView_Click(sender As Object, e As EventArgs) Handles BtnView.Click
        viewData()
    End Sub

    Sub viewData()
        Cursor = Cursors.WaitCursor
        Dim cond_cat As String = ""
        If LECat.EditValue.ToString <> "0" Then
            cond_cat = "AND c.id_item_cat = '" + LECat.EditValue.ToString + "' "
        End If
        Dim query As String = "SELECT coa.acc_name AS `exp_acc`, coa.acc_description AS `exp_description`, cat.item_cat, et.expense_type,
        IFNULL(SUM(case when MONTH(em.month) = '1' THEN em.value_expense END),0) AS `1_budget`,
        IFNULL(SUM(case when MONTH(em.month) = '2' THEN em.value_expense END),0) AS `2_budget`,
        IFNULL(SUM(case when MONTH(em.month) = '3' THEN em.value_expense END),0) AS `3_budget`,
        IFNULL(SUM(case when MONTH(em.month) = '4' THEN em.value_expense END),0) AS `4_budget`,
        IFNULL(SUM(case when MONTH(em.month) = '5' THEN em.value_expense END),0) AS `5_budget`,
        IFNULL(SUM(case when MONTH(em.month) = '6' THEN em.value_expense END),0) AS `6_budget`,
        IFNULL(SUM(case when MONTH(em.month) = '7' THEN em.value_expense END),0) AS `7_budget`,
        IFNULL(SUM(case when MONTH(em.month) = '8' THEN em.value_expense END),0) AS `8_budget`,
        IFNULL(SUM(case when MONTH(em.month) = '9' THEN em.value_expense END),0) AS `9_budget`,
        IFNULL(SUM(case when MONTH(em.month) = '10' THEN em.value_expense END),0) AS `10_budget`,
        IFNULL(SUM(case when MONTH(em.month) = '11' THEN em.value_expense END),0) AS `11_budget`,
        IFNULL(SUM(case when MONTH(em.month) = '12' THEN em.value_expense END),0) AS `12_budget`,
        0 AS `1_actual`,
        0 AS `2_actual`,
        0 AS `3_actual`,
        0 AS `4_actual`,
        0 AS `5_actual`,
        0 AS `6_actual`,
        0 AS `7_actual`,
        0 AS `8_actual`,
        0 AS `9_actual`,
        0 AS `10_actual`,
        0 AS `11_actual`,
        0 AS `12_actual`
        FROM tb_b_expense_month em
        LEFT JOIN tb_b_expense e ON e.id_b_expense = em.id_b_expense
        LEFT JOIN tb_item_coa c ON c.id_item_coa = e.id_item_coa
        LEFT JOIN tb_item_cat cat ON cat.id_item_cat = c.id_item_cat
        LEFT JOIN tb_lookup_expense_type et ON et.id_expense_type = cat.id_expense_type
        LEFT JOIN tb_a_acc coa ON coa.id_acc = c.id_coa_out
        WHERE c.id_departement='" + LEDeptSum.EditValue.ToString + "' AND e.year='" + LEYear.Text.ToString + "' 
        " + cond_cat + "
        GROUP BY e.id_item_coa "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCData.DataSource = data
        GVData.BestFitColumns()
        Cursor = Cursors.Default
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

    Private Sub FormBudgetExpenseView_Activated(sender As Object, e As EventArgs) Handles MyBase.Activated
        FormMain.show_rb(Name)
        check_menu()
    End Sub

    Private Sub FormBudgetExpenseView_Deactivate(sender As Object, e As EventArgs) Handles MyBase.Deactivate
        FormMain.hide_rb()
    End Sub

    Private Sub CEBudgetHistory_CheckedChanged(sender As Object, e As EventArgs) Handles CEBudgetHistory.CheckedChanged
        If CEBudgetHistory.EditValue = True Then
            GroupControlBudgetRevision.Visible = True
        Else
            GroupControlBudgetRevision.Visible = False
        End If
    End Sub
End Class