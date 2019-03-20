Public Class FormSampleExpense
    Dim bnew_active As String = "1"
    Dim bedit_active As String = "1"
    Dim bdel_active As String = "1"
    '
    Private Sub FormSampleExpense_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub FormSampleExpense_Deactivate(sender As Object, e As EventArgs) Handles MyBase.Deactivate
        FormMain.hide_rb()
    End Sub

    Private Sub FormSampleExpense_Activated(sender As Object, e As EventArgs) Handles MyBase.Activated
        FormMain.show_rb(Name)
        check_menu()
    End Sub

    Sub check_menu()
        If GVPurchaseList.RowCount < 1 Then
            'hide all except new
            bnew_active = "1"
            bedit_active = "0"
            bdel_active = "0"
            checkFormAccess(Name)
            button_main(bnew_active, bedit_active, bdel_active)
            'noManipulating()
        Else
            'show all
            bnew_active = "1"
            bedit_active = "1"
            bdel_active = "1"
            checkFormAccess(Name)
            button_main(bnew_active, bedit_active, bdel_active)
            'noManipulating()
        End If
    End Sub

    Private Sub BShowList_Click(sender As Object, e As EventArgs) Handles BShowList.Click
        load_purc("2")
    End Sub

    Sub load_purc(ByVal opt As String)
        Dim query As String = "SELECT po.number,emp.`employee_name`,po.`date_created`,po.id_sample_purc_budget,po.`remaining_after`,po.`remaining_before`,po.`id_currency`
,sb.`description` AS budget,sts.`report_status`,cur.`currency`,det.amount,(po.kurs*det.amount) AS amount_rp
FROM tb_sample_po_mat po 
INNER JOIN tb_m_user usr ON usr.`id_user`=po.`created_by`
INNER JOIN tb_m_employee emp ON emp.`id_employee`=usr.`id_employee`
INNER JOIN `tb_lookup_currency` cur ON cur.`id_currency`=po.`id_currency`
INNER JOIN tb_sample_purc_budget sb ON sb.`id_sample_purc_budget`=po.`id_sample_purc_budget`
INNER JOIN tb_lookup_report_status sts ON sts.`id_report_status`=po.`id_report_status`
INNER JOIN 
(
	SELECT pomd.`id_sample_po_mat`,(pomd.`qty`*pomd.`value`) AS amount FROM  tb_sample_po_mat_det pomd
	GROUP BY pomd.`id_sample_po_mat`
) det ON det.id_sample_po_mat=po.`id_sample_po_mat`"
        If opt = "2" Then
            query += " WHERE DATE(po.date_created) <='" & Date.Parse(DEUntil.EditValue.ToString).ToString("yyyy-MM-dd") & "' AND DATE(po.date_created) >='" & Date.Parse(DEStart.EditValue.ToString).ToString("yyyy-MM-dd") & "'
ORDER BY po.id_sample_po_mat DESC"
        End If
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCPurchaseList.DataSource = data
        GVPurchaseList.BestFitColumns()
    End Sub

    Private Sub FormSampleExpense_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        DEStart.EditValue = Now
        DEUntil.EditValue = Now
    End Sub

    Private Sub BShowAll_Click(sender As Object, e As EventArgs) Handles BShowAll.Click
        load_purc("1")
    End Sub

    Private Sub BEdit_Click(sender As Object, e As EventArgs) Handles BEdit.Click
        If GVPurchaseList.RowCount > 0 Then
            FormSampleExpenseDet.id_purc = GVPurchaseList.GetFocusedRowCellValue("id_sample_po_mat")
            FormSampleExpenseDet.ShowDialog()
        End If
    End Sub
End Class