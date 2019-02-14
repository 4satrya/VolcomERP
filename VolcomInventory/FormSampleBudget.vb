Public Class FormSampleBudget
    Dim bnew_active As String = "1"
    Dim bedit_active As String = "1"
    Dim bdel_active As String = "1"

    Sub check_menu()
        bnew_active = "0"
        bedit_active = "0"
        bdel_active = "0"

        checkFormAccess(Name)
        button_main(bnew_active, bedit_active, bdel_active)
    End Sub

    Private Sub FormPurcReq_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub FormPurcReq_Deactivate(sender As Object, e As EventArgs) Handles MyBase.Deactivate
        FormMain.hide_rb()
    End Sub

    Private Sub FormPurcReq_Activated(sender As Object, e As EventArgs) Handles MyBase.Activated
        FormMain.show_rb(Name)
        check_menu()
    End Sub

    Private Sub BSearch_Click(sender As Object, e As EventArgs) Handles BSearch.Click
        load_budget()
    End Sub

    Private Sub FormSampleBudget_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        DEYearBudget.EditValue = Now
        DEStart.EditValue = Now
        DEUntil.EditValue = Now
    End Sub

    Sub load_budget()
        Dim query As String = "SELECT 'no' AS is_check,spb.id_sample_purc_budget,spb.description,spb.`year`,spb.value_rp,spb.value_usd,GROUP_CONCAT(cd.code_detail_name) AS division
FROM `tb_sample_purc_budget` spb
INNER JOIN `tb_sample_purc_budget_div` spd ON spd.`id_sample_purc_budget`=spb.`id_sample_purc_budget`
INNER JOIN tb_m_code_detail cd ON cd.`id_code_detail`=spd.`id_code_division`
WHERE spb.`is_active`='1' AND spb.year='" & Date.Parse(DEYearBudget.EditValue.ToString).ToString("yyyy") & "'
GROUP BY spb.`id_sample_purc_budget`"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCBudgetList.DataSource = data
        GVBudgetList.BestFitColumns()
    End Sub

    Private Sub BNewBudget_Click(sender As Object, e As EventArgs) Handles BNewBudget.Click
        FormSampleBudgetDet.ShowDialog()
    End Sub
End Class