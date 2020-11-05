Public Class FormAdditionalCost
    Dim bnew_active As String = "1"
    Dim bedit_active As String = "1"
    Dim bdel_active As String = "1"

    Private Sub FormAdditionalCost_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Sub load_view()
        Dim q As String = "SELECT pps.id_additional_cost_pps,pps.number,pps.created_date,pps.update_date,emp_created.employee_name AS created_by,emp_upd.employee_name AS update_by,sts.id_report_status,sts.report_status
FROM `tb_additional_cost_pps` pps
INNER JOIN tb_m_user usr_created ON usr_created.id_user=pps.created_by
INNER JOIN tb_m_employee emp_created ON usr_created.id_employee=emp_created.id_employee
INNER JOIN tb_m_user usr_upd ON usr_upd.id_user=pps.update_by
INNER JOIN tb_m_employee emp_upd ON usr_upd.id_employee=emp_upd.id_employee
INNER JOIN tb_lookup_report_status sts ON sts.id_report_status=pps.id_report_status"
        Dim dt As DataTable = execute_query(q, -1, True, "", "", "", "")
        GCAdditionalCost.DataSource = dt
        GVAdditionalCost.BestFitColumns()
    End Sub

    Private Sub BRefresh_Click(sender As Object, e As EventArgs) Handles BRefresh.Click
        load_view()
    End Sub

    Private Sub FormAdditionalCost_Activated(sender As Object, e As EventArgs) Handles MyBase.Activated
        FormMain.show_rb(Name)
        check_menu()
    End Sub

    Private Sub FormAdditionalCost_Deactivate(sender As Object, e As EventArgs) Handles MyBase.Deactivate
        FormMain.hide_rb()
    End Sub

    Sub check_menu()
        If GVAdditionalCost.RowCount < 1 Then
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
            bdel_active = "1"
            checkFormAccess(Name)
            button_main(bnew_active, bedit_active, bdel_active)
        End If
    End Sub

    Private Sub GVAdditionalCost_DoubleClick(sender As Object, e As EventArgs) Handles GVAdditionalCost.DoubleClick
        If GVAdditionalCost.RowCount > 0 Then
            FormAdditionalCostDet.id_pps = GVAdditionalCost.GetFocusedRowCellValue("id_additional_cost_pps").ToString
            FormAdditionalCostDet.ShowDialog()
        End If
    End Sub
End Class