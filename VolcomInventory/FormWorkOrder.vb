Public Class FormWorkOrder
    Public is_worker As String = "-1"
    '
    Dim bnew_active As String = "1"
    Dim bedit_active As String = "1"
    Dim bdel_active As String = "1"

    Private Sub FormWorkOrder_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub FormWorkOrder_Deactivate(sender As Object, e As EventArgs) Handles MyBase.Deactivate
        FormMain.hide_rb()
    End Sub

    Private Sub FormWorkOrder_Activated(sender As Object, e As EventArgs) Handles MyBase.Activated
        FormMain.show_rb(Name)
        check_menu()
    End Sub

    Sub check_menu()
        If GVWorkOrder.RowCount < 1 Then
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

    Private Sub FormWorkOrder_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        view_departement()
        view_work_type()
        '
        If is_worker = "1" Then
            Dim query As String = "SELECT id_work_order_type FROM tb_lookup_work_order_type WHERE id_sub_departement='" & id_departement_sub_user & "'"
            Dim id_type As String = execute_query(query, 0, True, "", "", "", "")
            SLEWorkType.EditValue = id_type
            SLEWorkType.Enabled = False
            '
            BSetWorkStatus.Visible = True
        Else
            BSetWorkStatus.Visible = False
        End If
    End Sub

    Sub load_wo()
        Dim query_where As String = ""

        If Not SLEWorkType.EditValue.ToString = "0" Then
            query_where += " AND wo.id_work_order_type='" & SLEWorkType.EditValue.ToString & "' "
        End If

        If Not SLEDepartement.EditValue.ToString = "0" Then
            query_where += " AND wo.id_departement_created='" & SLEDepartement.EditValue.ToString & "' "
        End If

        If is_worker = "1" Then
            query_where += " AND wo.id_report_status=6 "
        End If

        Dim query As String = "SELECT wot.work_order_type,sts.report_status,wo.`id_work_order`,wo.id_report_status,wo.`id_work_order_type`,wo.`number`,wo.`note`,wo.`created_date`,emp.`employee_name`,dep.`departement`,IF(wo.is_urgent='1','yes','no') as is_urgent,wos.work_order_status FROM tb_work_order wo
INNER JOIN tb_m_user usr ON usr.`id_user`=wo.`created_by`
INNER JOIN tb_m_employee emp ON emp.`id_employee`=usr.`id_employee`
INNER JOIN tb_m_departement dep ON dep.`id_departement`=wo.`id_departement_created`
INNER JOIN tb_lookup_work_order_type wot ON wot.id_work_order_type=wo.id_work_order_type
INNER JOIN tb_lookup_report_status sts ON sts.id_report_status=wo.id_report_status
INNER JOIN tb_lookup_work_order_status wos ON wos.id_work_order_status=wo.id_work_order_status
WHERE 1=1 " & query_where
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCWorkOrder.DataSource = data
        GVWorkOrder.BestFitColumns()
        check_menu()
    End Sub

    Sub view_departement()
        Dim query As String = "SELECT '0' as id_departement, 'All' as departement 
                                UNION
                                SELECT id_departement,departement FROM tb_m_departement"
        viewSearchLookupQuery(SLEDepartement, query, "id_departement", "departement", "id_departement")
    End Sub

    Sub view_work_type()
        Dim query As String = "SELECT '0' as id_work_order_type, 'All' as work_order_type 
                                UNION
                                Select `id_work_order_type`, `work_order_type` FROM tb_lookup_work_order_type"
        viewSearchLookupQuery(SLEWorkType, query, "id_work_order_type", "work_order_type", "id_work_order_type")
    End Sub

    Private Sub BView_Click(sender As Object, e As EventArgs) Handles BView.Click
        load_wo()
    End Sub

    Private Sub BSetWorkStatus_Click(sender As Object, e As EventArgs) Handles BSetWorkStatus.Click
        If GVWorkOrder.RowCount > 0 Then
            Dim id_wo As String = GVWorkOrder.GetFocusedRowCellValue("id_work_order").ToString
            'check if sudah complete jangan kasi
            Dim query_c As String = "SELECT id_work_order_status FROM tb_work_order WHERE id_work_order='" & id_wo & "'"
            Dim idws As String = execute_query(query_c, 0, True, "", "", "", "")
            '
            If idws = "3" Then
                'already complete
                warningCustom("This work order already completed")
            Else
                FormWorkOrderStatus.id_wo = id_wo
                FormWorkOrderStatus.ShowDialog()
            End If
        End If
    End Sub

    Private Sub BWorkHistory_Click(sender As Object, e As EventArgs) Handles BWorkHistory.Click
        If GVWorkOrder.RowCount > 0 Then
            FormWorkOrderStatusHistory.id_wo = GVWorkOrder.GetFocusedRowCellValue("id_work_order").ToString
            FormWorkOrderStatusHistory.ShowDialog()
        End If
    End Sub

    Private Sub GVWorkOrder_DoubleClick(sender As Object, e As EventArgs) Handles GVWorkOrder.DoubleClick
        If GVWorkOrder.RowCount > 0 Then
            FormWorkOrderDet.is_view = "1"
            FormWorkOrderDet.id_wo = GVWorkOrder.GetFocusedRowCellValue("id_work_order").ToString
            FormWorkOrderDet.ShowDialog()
        End If
    End Sub
End Class