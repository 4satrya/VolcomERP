Public Class FormPurcReq
    Dim bnew_active As String = "1"
    Dim bedit_active As String = "1"
    Dim bdel_active As String = "1"
    '
    Public is_purc_dep As String = "-1"
    '
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

    Sub check_menu()
        If GVPurcReq.RowCount < 1 Then
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

    Private Sub FormPurcReq_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        load_dep()
        load_req()
        load_status()
        '
        check_menu()
    End Sub

    Sub load_status()
        Dim query As String = "SELECT '0' AS `id_status`,'All' AS `status`
                                UNION
                                SELECT '1' AS `id_status`,'Waiting for PO' AS `status`
                                UNION
                                SELECT '2' AS `id_status`,'PO on Process' AS `status`
                                UNION
                                SELECT '3' AS `id_status`,'PO complete, waiting to receive' AS `status`
                                UNION
                                SELECT '4' AS `id_status`,'Partial receiving' AS `status`
                                UNION
                                SELECT '5' AS `id_status`,'Complete' AS `status`
                                UNION 
                                SELECT '6' AS `id_status`,'Unable to fulfill' AS `status`"
        viewSearchLookupQuery(SLEStatus, query, "id_status", "status", "id_status")
    End Sub

    Sub load_item_list()
        Dim query_where As String = ""
        '
        If SLEStatus.EditValue.ToString = "1" Then 'waiting PO
            query_where = " WHERE IFNULL(po.qty,0) = 0 AND prd.is_unable_fulfill!=1 "
        ElseIf SLEStatus.EditValue.ToString = "2" Then 'PO On Process
            query_where = " WHERE IFNULL(po.qty,0) > 0 AND IFNULL(po_complete.qty,0)=0 AND prd.is_unable_fulfill!=1 "
        ElseIf SLEStatus.EditValue.ToString = "3" Then 'PO complete, waiting to receive
            query_where = " WHERE IFNULL(po_complete.qty,0) > 0 AND IFNULL(rec.qty,0)=0 AND prd.is_unable_fulfill!=1 "
        ElseIf SLEStatus.EditValue.ToString = "4" Then 'Partial Receiving
            query_where = " WHERE IFNULL(rec.qty,0) >'0' AND prd.qty<IFNULL(rec.qty,0) AND prd.is_unable_fulfill!=1 "
        ElseIf SLEStatus.EditValue.ToString = "5" Then 'complete
            query_where = " WHERE IFNULL(rec.qty,0)>=prd.qty AND prd.is_unable_fulfill!=1 "
        ElseIf SLEStatus.EditValue.ToString = "6" Then 'unable to fulfill
            query_where = " WHERE prd.is_unable_fulfill=1 "
        End If
        '
        If Not SLEDepartement.EditValue.ToString = "0" Then
            If SLEStatus.EditValue.ToString = "0" Then
                query_where += " WHERE "
            Else
                query_where += " AND "
            End If
            query_where += " pr.id_departement='" & SLEDepartement.EditValue.ToString & "'"
        End If
        '
        Dim query As String = "SELECT 'no' AS is_check,prd.`id_purc_req_det`,prd.value AS val_pr,dep.departement,pr.date_created,prd.`id_purc_req`,prd.qty AS qty_pr,pr.`purc_req_number`,it.id_item,it.item_desc,uom.uom,cat.item_cat
,po.po_date,po.est_rec_date
,IFNULL(rec.qty,0)-IFNULL(ret.qty,0) AS rec_qty, IFNULL(po.qty,0) AS po_qty,prd.is_unable_fulfill, IF(prd.is_unable_fulfill=1,'yes','no') AS unable_fulfill,prd.unable_fulfill_reason
,IF(prd.is_unable_fulfill=1,'Unable to fulfill',IF(IFNULL(po.qty,0)=0,'Waiting for PO',IF(IFNULL(po_complete.qty,0)=0,'PO On Process',IF(IFNULL(rec.qty,0)=0,'PO Complete, waiting to receive',IF(IFNULL(rec.qty,0)>=prd.qty,'Complete','Partial Receiving'))))) AS workstatus
FROM tb_purc_req_det prd
INNER JOIN tb_purc_req pr ON pr.`id_purc_req`=prd.`id_purc_req` AND pr.`id_report_status`='6'
INNER JOIN tb_item it ON it.`id_item`=prd.`id_item`
INNER JOIN tb_item_cat cat ON cat.id_item_cat=it.id_item_cat
INNER JOIN tb_item_coa itc ON itc.id_item_cat=cat.id_item_cat AND itc.id_departement='3'
INNER JOIN tb_m_uom uom ON uom.id_uom=it.id_uom
INNER JOIN tb_m_departement dep ON dep.id_departement=pr.id_departement
LEFT JOIN 
(
	SELECT pod.`id_purc_order_det`,pod.`id_purc_req_det`,SUM(pod.`qty`) AS qty,po.date_created AS po_date,po.est_date_receive AS est_rec_date FROM tb_purc_order_det pod
	INNER JOIN tb_purc_order po ON po.`id_purc_order`=pod.`id_purc_order`
	WHERE po.`id_report_status`!='5'
    GROUP BY pod.`id_purc_req_det`
)po ON po.id_purc_req_det=prd.`id_purc_req_det`
LEFT JOIN 
(
	SELECT pod.`id_purc_order_det`,pod.`id_purc_req_det`,SUM(pod.`qty`) AS qty FROM tb_purc_order_det pod
	INNER JOIN tb_purc_order po ON po.`id_purc_order`=pod.`id_purc_order`
	WHERE po.`id_report_status`='6'
    GROUP BY pod.`id_purc_req_det`
)po_complete ON po_complete.id_purc_req_det=prd.`id_purc_req_det`
LEFT JOIN 
(
	SELECT pod.`id_purc_req_det`,SUM(recd.`qty`) AS qty FROM tb_purc_rec_det recd
    INNER JOIN tb_purc_order_det pod ON recd.id_purc_order_det=pod.id_purc_order_det
	INNER JOIN tb_purc_rec rec ON recd.`id_purc_rec`=rec.id_purc_rec
	WHERE rec.`id_report_status`!='5'
    GROUP BY pod.`id_purc_req_det`
)rec ON rec.id_purc_req_det=prd.`id_purc_req_det`
LEFT JOIN 
(
    SELECT pod.`id_purc_req_det`,SUM(prd.`qty`) AS qty FROM `tb_purc_return_det` prd
    INNER JOIN `tb_purc_return` pr ON pr.id_purc_return=prd.id_purc_return AND pr.id_report_status!='5'
    INNER JOIN tb_purc_order_det pod ON prd.id_purc_order_det=pod.id_purc_order_det
    INNER JOIN tb_purc_order po ON po.`id_purc_order`=pod.`id_purc_order` AND po.`id_report_status`!='5'
    GROUP BY pod.`id_purc_req_det`
)ret ON ret.id_purc_req_det=prd.`id_purc_req_det`  " & query_where
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCItemReqList.DataSource = data
        GVItemReqList.BestFitColumns()
    End Sub

    Sub load_dep()
        Dim query As String = ""
        If is_purc_dep = "1" Then
            query = "SELECT '0' AS id_departement,'ALL' AS departement 
                               UNION
                               SELECT id_departement,departement FROM tb_m_departement"
        Else
            query = "SELECT id_departement,departement FROM tb_m_departement WHERE id_departement='" & id_departement_user & "'"
            query += " UNION ALL "
            query += " SELECT dep.`id_departement`,dep.`departement`
FROM `tb_purc_req_extra_dep` ext 
INNER JOIN tb_m_departement dep ON dep.`id_departement`=ext.`id_departement`
WHERE ext.id_user='" & id_user & "' "
        End If

        viewSearchLookupQuery(SLEDepartement, query, "id_departement", "departement", "id_departement")
    End Sub

    Sub load_req()
        Dim where_dep As String = ""
        '
        If Not SLEDepartement.EditValue.ToString() = 0 Then
            where_dep = " WHERE dep.id_departement='" & SLEDepartement.EditValue.ToString() & "'"
        End If
        '
        Dim query As String = "SELECT pr.`id_purc_req`,pr.requirement_date,sts.report_status,et.expense_type,pr.id_report_status,dep.`departement`,et.pr_report_mark_type,pr.`purc_req_number`,pr.`note`,empc.`employee_name` AS created_by,pr.`date_created`,empu.`employee_name` AS last_upd_by,pr.`date_last_upd`, pr.`id_report_status` FROM `tb_purc_req` pr
                                INNER JOIN tb_lookup_expense_type et ON et.id_expense_type=pr.id_expense_type
                                INNER JOIN tb_m_departement dep ON dep.id_departement=pr.id_departement
                                INNER JOIN tb_m_user usrc ON usrc.`id_user`=pr.`id_user_created`
                                INNER JOIN tb_m_employee empc ON empc.`id_employee`=usrc.`id_employee`
                                INNER JOIN tb_lookup_report_status sts ON sts.id_report_status=pr.id_report_status
                                LEFT JOIN tb_m_user usru ON usru.`id_user`=pr.`id_user_last_upd`
                                LEFT JOIN tb_m_employee empu ON empu.`id_employee`=usru.`id_employee` " & where_dep & " ORDER BY pr.`id_purc_req` DESC"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCPurcReq.DataSource = data
        GVPurcReq.BestFitColumns()
        check_menu()
    End Sub

    Private Sub BView_Click(sender As Object, e As EventArgs) Handles BView.Click
        load_req()
    End Sub

    Private Sub BViewReqList_Click(sender As Object, e As EventArgs) Handles BViewReqList.Click
        load_item_list()
    End Sub

    Private Sub BBUpdateBudget_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BBUpdateBudget.ItemClick
        For i As Integer = 0 To GVItemReqList.RowCount - 1
            GVItemReqList.SetRowCellValue(i, "workstatus", "On Process")
            'budget remaining
            Dim budget_remaining As Decimal = 0.00
            Dim query_budget As String = "SELECT bex.id_b_expense,bex.`value_expense`,SUM(trx.`value`) AS val_used,bex.`value_expense` - SUM(trx.`value`) AS val_remaining FROM tb_b_expense bex
INNER JOIN `tb_b_expense_trans` trx ON trx.`id_b_expense`=bex.`id_b_expense`
WHERE bex.`id_b_expense` = '" & GVItemReqList.GetRowCellValue(i, "id_b_expense").ToString & "' GROUP BY bex.`id_b_expense`"
            Dim data As DataTable = execute_query(query_budget, -1, True, "", "", "", "")
            If data.Rows.Count > 0 Then
                budget_remaining = data.Rows(0)("val_remaining")
                'cek latest price
                If budget_remaining + GVItemReqList.GetRowCellValue(i, "val_pr") - GVItemReqList.GetRowCellValue(i, "latest_price") > 0 Then
                    'update request if ok
                    GVItemReqList.SetRowCellValue(i, "workstatus", "Done")
                Else
                    GVItemReqList.SetRowCellValue(i, "workstatus", "No Budget")
                End If
            Else
                GVItemReqList.SetRowCellValue(i, "workstatus", "Item budget not found")
            End If
        Next
    End Sub

    Private Sub BBClose_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BBClose.ItemClick
        GVItemReqList.ActiveFilterString = ""
        GVItemReqList.ActiveFilterString = "[is_check]='yes'"
        For i As Integer = 0 To GVItemReqList.RowCount - 1
            If GVItemReqList.GetRowCellValue(i, "is_unable_fulfill").ToString = "1" Then
                'budget return
                Dim query_upd As String = "SET @id_prd = '" & GVItemReqList.GetRowCellValue(i, "id_purc_req_det").ToString & "';
                                            INSERT INTO `tb_b_expense_trans`(`id_b_expense`,`date_trans`,`value`,`is_actual`,`id_report`,`report_mark_type`,`note`)
                                            SELECT 
                                            -- prd.`id_purc_req_det`,(prd.qty*prd.value) as val_req,pod.val as val_po,prec.val as val_rec,pret.val as val_ret,
                                            prd.`id_b_expense`,NOW(),-(IF(ISNULL(prec.val),IFNULL(pod.val,(prd.qty*prd.value)),prec.val-IFNULL(pret.val,0))) AS val,1 AS is_actual,prd.`id_purc_req` AS id_report,'137','Closing Purchase Request' FROM tb_purc_req_det prd
                                            LEFT JOIN 
                                            (
	                                            SELECT pod.id_purc_req_det,SUM(pod.`qty`*pod.`value`) AS val FROM tb_purc_order_det pod 
	                                            INNER JOIN tb_purc_order po ON po.`id_purc_order`=pod.`id_purc_order` AND po.`id_report_status`!='5'
	                                            WHERE pod.`id_purc_req_det`=@id_prd
	                                            GROUP BY pod.id_purc_req_det
                                            )
                                            pod ON pod.`id_purc_req_det`=prd.`id_purc_req_det`
                                            LEFT JOIN 
                                            (
	                                            SELECT pod.id_purc_req_det,SUM(precd.`qty`*pod.`value`) AS val FROM tb_purc_rec_det precd 
	                                            INNER JOIN tb_purc_rec prec ON prec.`id_purc_rec`=precd.`id_purc_rec` AND prec.`id_report_status`!='5'
	                                            INNER JOIN tb_purc_order_det pod ON pod.`id_purc_order_det`=precd.`id_purc_order_det`
	                                            WHERE pod.`id_purc_req_det`=@id_prd
	                                            GROUP BY pod.id_purc_req_det
                                            )
                                            prec ON prec.`id_purc_req_det`=prd.`id_purc_req_det`
                                            LEFT JOIN 
                                            (
	                                            SELECT pod.id_purc_req_det,SUM(pretd.`qty`*pod.`value`) AS val FROM tb_purc_return_det pretd 
	                                            INNER JOIN tb_purc_return pret ON pretd.`id_purc_return`=pret.`id_purc_return` AND pret.`id_report_status`!='5'
	                                            INNER JOIN tb_purc_order_det pod ON pod.`id_purc_order_det`=pretd.`id_purc_order_det`
	                                            WHERE pod.`id_purc_req_det`=@id_prd
	                                            GROUP BY pod.id_purc_req_det
                                            )
                                            pret ON pret.`id_purc_req_det`=prd.`id_purc_req_det`
                                            WHERE pod.`id_purc_req_det`=@id_prd;

                                            UPDATE tb_purc_req_det SET is_close=1 WHERE id_purc_req_det='" & GVItemReqList.GetRowCellValue(i, "id_purc_req_det").ToString & "'"
                execute_non_query(query_upd, True, "", "", "", "")
            End If
        Next
        GVItemReqList.ActiveFilterString = ""
    End Sub

    Private Sub GVPurcReq_DoubleClick(sender As Object, e As EventArgs) Handles GVPurcReq.DoubleClick
        FormPurcReqDet.id_req = GVPurcReq.GetFocusedRowCellValue("id_purc_req").ToString
        FormPurcReqDet.ShowDialog()
    End Sub

    Private Sub GVPurcReq_PopupMenuShowing(sender As Object, e As DevExpress.XtraGrid.Views.Grid.PopupMenuShowingEventArgs) Handles GVPurcReq.PopupMenuShowing
        If GVPurcReq.GetFocusedRowCellValue("id_report_status").ToString = "5" Then
            DuplicateToolStripMenuItem.Visible = True
        Else
            DuplicateToolStripMenuItem.Visible = False
        End If
    End Sub

    Private Sub DuplicateToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DuplicateToolStripMenuItem.Click
        FormPurcReqDet.id_req = GVPurcReq.GetFocusedRowCellValue("id_purc_req").ToString
        FormPurcReqDet.is_duplicate = "1"
        FormPurcReqDet.ShowDialog()
    End Sub
End Class