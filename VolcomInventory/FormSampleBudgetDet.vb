Public Class FormSampleBudgetDet
    Dim id_pps As String = "-1"
    Private Sub FormSampleBudgetDet_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        load_before_det()
        load_after_det()

        If id_pps = "-1" Then 'new
            TECreatedBy.Text = ""
            DEDateCreated.EditValue = Now
        End If

        check_but()
    End Sub

    Sub load_before_det()
        Dim query As String = "SELECT ppd.*
,GROUP_CONCAT(DISTINCT IFNULL(cd_after.`id_code_detail`,'')) AS id_division_after
,GROUP_CONCAT(DISTINCT IFNULL(cd_before.`id_code_detail`,'')) AS id_division_before 
,GROUP_CONCAT(DISTINCT IFNULL(cd_after.`code_detail_name`,'')) AS division_after
,GROUP_CONCAT(DISTINCT IFNULL(cd_before.`code_detail_name`,'')) AS division_before 
FROM `tb_sample_budget_pps_det` ppd
LEFT JOIN `tb_sample_budget_pps_div` ppdiv_after ON ppdiv_after.`id_sample_budget_pps_det`=ppd.`id_sample_budget_pps_det` AND ppdiv_after.is_after='1'
LEFT JOIN tb_m_code_detail cd_after ON cd_after.`id_code_detail`=ppdiv_after.`id_code_division`
LEFT JOIN `tb_sample_budget_pps_div` ppdiv_before ON ppdiv_before.`id_sample_budget_pps_det`=ppd.`id_sample_budget_pps_det` AND ppdiv_before.is_after='2'
LEFT JOIN tb_m_code_detail cd_before ON cd_before.`id_code_detail`=ppdiv_before.`id_code_division`
WHERE ppd.id_sample_budget_pps='" & id_pps & "' 
GROUP BY ppd.id_sample_budget_pps_det"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCBefore.DataSource = data
        GVBefore.BestFitColumns()
    End Sub

    Sub load_after_det()
        Dim query As String = "SELECT ppd.*
,GROUP_CONCAT(DISTINCT IFNULL(cd_after.`id_code_detail`,'')) AS id_division_after
,GROUP_CONCAT(DISTINCT IFNULL(cd_before.`id_code_detail`,'')) AS id_division_before 
,GROUP_CONCAT(DISTINCT IFNULL(cd_after.`code_detail_name`,'')) AS division_after
,GROUP_CONCAT(DISTINCT IFNULL(cd_before.`code_detail_name`,'')) AS division_before 
FROM `tb_sample_budget_pps_det` ppd
LEFT JOIN `tb_sample_budget_pps_div` ppdiv_after ON ppdiv_after.`id_sample_budget_pps_det`=ppd.`id_sample_budget_pps_det` AND ppdiv_after.is_after='1'
LEFT JOIN tb_m_code_detail cd_after ON cd_after.`id_code_detail`=ppdiv_after.`id_code_division`
LEFT JOIN `tb_sample_budget_pps_div` ppdiv_before ON ppdiv_before.`id_sample_budget_pps_det`=ppd.`id_sample_budget_pps_det` AND ppdiv_before.is_after='2'
LEFT JOIN tb_m_code_detail cd_before ON cd_before.`id_code_detail`=ppdiv_before.`id_code_division`
WHERE ppd.id_sample_budget_pps='" & id_pps & "' 
GROUP BY ppd.id_sample_budget_pps_det"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCAfter.DataSource = data
        GVAfter.BestFitColumns()
    End Sub

    Private Sub BtnCancel_Click(sender As Object, e As EventArgs) Handles BtnCancel.Click
        Close()
    End Sub

    Private Sub FormSampleBudgetDet_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Sub check_but()
        If GVAfter.RowCount > 0 Then
            BDel.Visible = True
        Else
            BDel.Visible = False
        End If
    End Sub

    Private Sub BDel_Click(sender As Object, e As EventArgs) Handles BDel.Click
        GVAfter.DeleteSelectedRows()
    End Sub

    Private Sub BAdd_Click(sender As Object, e As EventArgs) Handles BAdd.Click
        FormSampleBudgetSingle.ShowDialog()
    End Sub
End Class