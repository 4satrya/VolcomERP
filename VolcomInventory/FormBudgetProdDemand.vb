Public Class FormBudgetProdDemand
    Public last_cond As String = ""
    Private Sub FormBudgetProdDemand_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        DEYearBudget.EditValue = Now
        DEYearProposedBudget.EditValue = Now
        DEFrom.EditValue = Now
        DEUntil.EditValue = Now
    End Sub

    Private Sub FormBudgetProdDemand_Activated(sender As Object, e As EventArgs) Handles MyBase.Activated
        FormMain.show_rb(Name)
        checkFormAccess(Name)
    End Sub

    Private Sub FormBudgetProdDemand_Deactivate(sender As Object, e As EventArgs) Handles MyBase.Deactivate
        FormMain.hide_rb()
    End Sub

    Sub viewAppBudget()
        Cursor = Cursors.WaitCursor
        Dim query As String = "SELECT b.id_b_prod_demand, b.`year`, b.id_season, ss.season, b.`value`, b.is_active 
        FROM tb_b_prod_demand b
        INNER JOIN tb_season ss ON ss.id_season = b.id_season 
        WHERE b.year='" + DEYearBudget.Text + "' "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCApprovedBudget.DataSource = data
        GVApprovedBudget.BestFitColumns()
        Cursor = Cursors.Default
    End Sub

    Private Sub BtnView_Click(sender As Object, e As EventArgs) Handles BtnView.Click
        viewAppBudget()
    End Sub

    Private Sub BtnViewProposeDate_Click(sender As Object, e As EventArgs) Handles BtnViewProposeDate.Click
        viewProposeByDate()
    End Sub

    Sub viewProposeByDate()
        'date
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
        Dim cond As String = "AND (b.created_date>='" + date_from_selected + "' AND b.created_date<='" + date_until_selected + "') "

        viewPropose(cond)
    End Sub

    Private Sub BtnViewYearBudget_Click(sender As Object, e As EventArgs) Handles BtnViewYearBudget.Click
        viewPropose("AND b.year='" + DEYearProposedBudget.Text + "' ")
    End Sub


    Sub viewPropose(ByVal cond_par As String)
        Cursor = Cursors.WaitCursor
        Dim b As New ClassBudgetProdDemand()
        Dim query As String = b.queryMain(cond_par, "2")
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCProposed.DataSource = data
        GVProposed.BestFitColumns()
        last_cond = cond_par
        Cursor = Cursors.Default
    End Sub

    Private Sub GVProposed_DoubleClick(sender As Object, e As EventArgs) Handles GVProposed.DoubleClick
        Cursor = Cursors.WaitCursor
        FormMain.but_edit()
        Cursor = Cursors.Default
    End Sub
End Class