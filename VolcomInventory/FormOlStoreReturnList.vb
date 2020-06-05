Public Class FormOlStoreReturnList
    Dim bnew_active As String = "0"
    Dim bedit_active As String = "0"
    Dim bdel_active As String = "0"

    Private Sub FormSalesPOS_Activated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Activated
        FormMain.show_rb(Name)
        check_menu()
    End Sub

    Private Sub FormSalesPOS_Deactivate(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Deactivate
        FormMain.hide_rb()
    End Sub

    Private Sub FormOlStoreReturnList_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        view_comp_group()
        view_order()
        viewRequest()

        If id_role_login = get_setup_field("id_role_super_admin") Then
            BtnRefund.Visible = True
        End If
    End Sub

    Sub view_comp_group()
        Dim q As String = "SELECT 0 AS id_comp_group,'ALL' AS comp_group,'ALL' AS description
UNION
SELECT id_comp_group,comp_group,description FROM tb_m_comp_group"
        viewSearchLookupQuery(SLECompGroup, q, "id_comp_group", "description", "id_comp_group")
    End Sub

    Sub view_order()
        Dim q As String = "SELECT 'ALL' AS sales_order_ol_shop_number
UNION
SELECT sales_order_ol_shop_number
FROM tb_ol_store_ret WHERE id_report_status=6
GROUP BY sales_order_ol_shop_number"
        viewSearchLookupQuery(SLEOrder, q, "sales_order_ol_shop_number", "sales_order_ol_shop_number", "sales_order_ol_shop_number")
    End Sub

    Sub viewRequest()
        Cursor = Cursors.WaitCursor
        Dim r As New ClassRequestRetOLStore()
        Dim query As String = r.queryMain("-1", "2")
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCRequest.DataSource = data
        Cursor = Cursors.Default
    End Sub

    Sub check_menu()
        'hide all except new
        bnew_active = "0"
        bedit_active = "0"
        bdel_active = "0"
        checkFormAccess(Name)
        button_main(bnew_active, bedit_active, bdel_active)
    End Sub

    Private Sub BSearch_Click(sender As Object, e As EventArgs) Handles BSearch.Click
        view_list()
    End Sub

    Sub view_list()
        Dim q_where As String = " WHERE "

        If SLEOrder.EditValue.ToString = "ALL" Then
            q_where += " 1=1"
        Else
            q_where += " r.sales_order_ol_shop_number='" & SLEOrder.EditValue.ToString & "'"
        End If

        If SLECompGroup.EditValue.ToString = "0" Then
            q_where += " AND 1=1"
        Else
            q_where += " AND r.id_comp_group='" & SLEOrder.EditValue.ToString & "'"
        End If

        Dim q As String = "SELECT 'no' AS is_check,r.id_comp_group,cg.comp_group,rl.id_ol_store_ret_list,r.`number`,r.`ret_req_number`,sd.`item_id`,r.`sales_order_ol_shop_number`,r.`ret_req_number`,p.`product_display_name`,cd.`code_detail_name` AS size,stt.`ol_store_ret_stt`,emp.`employee_name`,rl.`update_date`,CONCAT(p.`product_full_code`,plc.`pl_sales_order_del_det_counting`) AS full_code, rd.id_sales_order_det, 
rq.rek_no, rq.rek_name, rq.rek_bank, rq.rek_branch, rq.ret_req_number AS `request_ref`, rq.id_ol_store_ret_req
FROM tb_ol_store_ret_list rl
INNER JOIN tb_ol_store_ret_det rd ON rd.`id_ol_store_ret_det`=rl.id_ol_store_ret_det
INNER JOIN `tb_pl_sales_order_del_det_counting` plc ON rd.`id_pl_sales_order_del_det_counting`=plc.id_pl_sales_order_del_det_counting
INNER JOIN tb_ol_store_ret r ON r.`id_ol_store_ret`=rd.`id_ol_store_ret` AND r.id_report_status='6'
INNER JOIN tb_ol_store_ret_req rq ON rq.id_ol_store_ret_req = r.id_ol_store_ret_req
INNER JOIN tb_sales_order_det sd ON sd.`id_sales_order_det`=rd.id_sales_order_det
INNER JOIN tb_m_product p ON p.`id_product`=sd.`id_product`
INNER JOIN tb_m_product_code pc ON pc.`id_product`=p.`id_product`
INNER JOIN tb_m_code_detail cd ON cd.`id_code_detail`=pc.`id_code_detail` AND cd.`id_code`='33'
INNER JOIN tb_lookup_ol_store_ret_stt stt ON stt.id_ol_store_ret_stt=rl.id_ol_store_ret_stt
INNER JOIN tb_m_comp_group cg ON cg.id_comp_group=r.id_comp_group
LEFT JOIN tb_m_user usr ON usr.id_user=rl.`update_by`
LEFT JOIN tb_m_employee emp ON emp.`id_employee`=usr.`id_employee` " & q_where
        Dim dt As DataTable = execute_query(q, -1, True, "", "", "", "")
        GCList.DataSource = dt
        GVList.BestFitColumns()
    End Sub

    Private Sub BUpdateStatus_Click(sender As Object, e As EventArgs) Handles BUpdateStatus.Click
        Cursor = Cursors.WaitCursor
        GVList.ActiveFilterString = "[is_check]='yes' "
        Dim problem As Boolean = False
        Dim str_problem As String = ""
        'check first
        For i As Integer = 0 To GVList.RowCount - 1
            Dim q As String = "SELECT * FROM tb_ol_store_ret_list rl INNER JOIN tb_lookup_ol_store_ret_stt stt ON stt.id_ol_store_ret_stt=rl.id_ol_store_ret_stt WHERE stt.is_only_cs=1 AND rl.id_ol_store_ret_list='" & GVList.GetRowCellValue(i, "id_ol_store_ret_list").ToString & "'"
            Dim dt As DataTable = execute_query(q, -1, True, "", "", "", "")
            If dt.Rows.Count = 0 Then
                problem = True
                str_problem += GVList.GetRowCellValue(i, "full_code").ToString & ";"
            End If
        Next

        If GVList.RowCount <= 0 Then
            warningCustom("Please select item first.")
        ElseIf problem Then
            warningCustom("Status already locked for unique code : " & str_problem)
        Else
            FormOlStoreReturnListUpdate.ShowDialog()
        End If
        GVList.ActiveFilterString = ""
        Cursor = Cursors.Default
    End Sub

    Private Sub BtnPrint_Click(sender As Object, e As EventArgs) Handles BtnPrint.Click
        Cursor = Cursors.WaitCursor
        print_raw(GCRequest, "")
        Cursor = Cursors.Default
    End Sub

    Private Sub BtnRefresh_Click(sender As Object, e As EventArgs) Handles BtnRefresh.Click
        viewRequest()
    End Sub

    Private Sub BtnNew_Click(sender As Object, e As EventArgs) Handles BtnNew.Click
        Cursor = Cursors.WaitCursor
        FormRequestRetOLStore.action = "ins"
        FormRequestRetOLStore.ShowDialog()
        Cursor = Cursors.Default
    End Sub

    Private Sub GVRequest_DoubleClick(sender As Object, e As EventArgs) Handles GVRequest.DoubleClick
        If GVRequest.FocusedRowHandle >= 0 Then
            Cursor = Cursors.WaitCursor
            FormRequestRetOLStore.id = GVRequest.GetFocusedRowCellValue("id_ol_store_ret_req").ToString
            FormRequestRetOLStore.action = "upd"
            FormRequestRetOLStore.ShowDialog()
            Cursor = Cursors.Default
        End If
    End Sub

    Private Sub BtnRefund_Click(sender As Object, e As EventArgs) Handles BtnRefund.Click
        FormMain.SplashScreenManager1.ShowWaitForm()

        'creat obj
        Dim rf As New ClassOLStoreRefund()

        'cek CN
        FormMain.SplashScreenManager1.SetWaitFormDescription("Checking credit note")
        rf.createCN()


        'cek ROR
        FormMain.SplashScreenManager1.SetWaitFormDescription("Checking return order")
        rf.createROR()

        view_list()
        FormMain.SplashScreenManager1.CloseWaitForm()
    End Sub

    Private Sub DetailRefundToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DetailRefundToolStripMenuItem.Click
        Cursor = Cursors.WaitCursor
        FormOlStoreDetailRefund.id = GVList.GetFocusedRowCellValue("id_ol_store_ret_req").ToString
        FormOlStoreDetailRefund.ShowDialog()
        Cursor = Cursors.Default
    End Sub
End Class