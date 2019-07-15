Public Class FormPurcOrder
    Dim bnew_active As String = "1"
    Dim bedit_active As String = "1"
    Dim bdel_active As String = "1"
    '
    Public is_purc_dep As String = "-1"

    Private Sub FormPurcOrder_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub FormPurcOrder_Deactivate(sender As Object, e As EventArgs) Handles MyBase.Deactivate
        FormMain.hide_rb()
    End Sub

    Private Sub FormPurcOrder_Activated(sender As Object, e As EventArgs) Handles MyBase.Activated
        FormMain.show_rb(Name)
        check_menu()
    End Sub
    '
    Sub check_menu()
        If XTCPO.SelectedTabPageIndex = 0 Then
            bnew_active = "0"
            bedit_active = "0"
            bdel_active = "0"
            checkFormAccess(Name)
            button_main(bnew_active, bedit_active, bdel_active)
        Else
            bnew_active = "0"
            bedit_active = "0"
            bdel_active = "0"
            checkFormAccess(Name)
            button_main(bnew_active, bedit_active, bdel_active)
        End If
    End Sub

    Sub load_po_status()
        Dim query As String = "SELECT '1' AS `id_po_status`,'Waiting' AS `po_status`
                                UNION
                                SELECT '2' AS `id_po_status`,'PO Created' AS `po_status`
                                UNION
                                SELECT '3' AS `id_po_status`,'All' AS `po_status`"
        viewSearchLookupQuery(LEPOStatus, query, "id_po_status", "po_status", "id_po_status")
    End Sub

    Private Sub FormPurcOrder_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        load_vendor()
        load_vendor_list_po()
        load_po_item()

        '
        load_dep()
        load_item_cat()
        load_item()
        load_po_status()
        loadImgPath()
        load_expense_type()
        '
        load_rec_status()
        '
        check_menu()
    End Sub

    Sub load_rec_status()
        Dim query As String = "SELECT '0' AS `id_rec_status`,'All' AS `rec_status`
                                UNION
                                SELECT '1' AS `id_rec_status`,'Open' AS `rec_status`
                                UNION
                                SELECT '2' AS `id_rec_status`,'Closed' AS `rec_status`"
        viewSearchLookupQuery(SLERecStatus, query, "id_rec_status", "rec_status", "id_rec_status")
    End Sub

    Sub load_expense_type()
        Dim query As String = "SELECT id_expense_type,expense_type FROM `tb_lookup_expense_type`"
        viewSearchLookupQuery(SLEExpenseType, query, "id_expense_type", "expense_type", "id_expense_type")
    End Sub

    Sub load_po()
        Dim where_string As String = ""

        If Not SLEVendor.EditValue.ToString = "0" Then
            where_string = " AND c.id_comp='" & SLEVendor.EditValue.ToString & "'"
        End If

        If SLERecStatus.EditValue.ToString = "1" Then
            where_string = " AND po.is_close_rec='2'"
        ElseIf SLERecStatus.EditValue.ToString = "2" Then
            where_string = " AND po.is_close_rec='1'"
        End If

        Dim query As String = "SELECT 'no' AS is_check,po.est_date_receive,po.id_purc_order,c.comp_number,c.comp_name,cc.contact_person,cc.contact_number,po.purc_order_number,po.date_created,emp_cre.employee_name AS emp_created,po.last_update,emp_upd.employee_name AS emp_updated ,po.pay_due_date,po.date_created
,SUM(pod.qty) AS qty_po,(SUM(pod.qty*(pod.value-pod.discount))-po.disc_value+po.vat_value) AS total_po
,IFNULL(SUM(rec.qty),0) AS qty_rec,IF(ISNULL(rec.id_purc_order_det),0,SUM(rec.qty*(pod.value-pod.discount))-(SUM(rec.qty*(pod.value-pod.discount))/SUM(pod.qty*(pod.value-pod.discount))*po.disc_value)+(SUM(rec.qty*(pod.value-pod.discount))/SUM(pod.qty*(pod.value-pod.discount))*po.vat_value)) AS total_rec
,(IFNULL(SUM(rec.qty*pod.value),0)/SUM(pod.qty*pod.value))*100 AS rec_progress,IF(po.is_close_rec=1,'Closed',IF((IFNULL(SUM(rec.qty),0)/SUM(pod.qty))<=0,'Waiting',IF((IFNULL(SUM(rec.qty),0)/SUM(pod.qty))<1,'Partial','Complete'))) AS rec_status
,po.close_rec_reason
,IFNULL(payment.value,0) AS val_pay
,IF(po.is_close_pay=1,'Closed',IF(DATE(NOW())>po.pay_due_date,'Overdue','Open')) as pay_status
FROM tb_purc_order po
INNER JOIN tb_purc_order_det pod ON pod.`id_purc_order`=po.`id_purc_order`
INNER JOIN tb_m_user usr_cre ON usr_cre.id_user=po.created_by
INNER JOIN tb_m_employee emp_cre ON emp_cre.id_employee=usr_cre.id_employee
INNER JOIN tb_m_user usr_upd ON usr_upd.id_user=po.last_update_by
INNER JOIN tb_m_employee emp_upd ON emp_upd.id_employee=usr_upd.id_employee
INNER JOIN tb_m_comp_contact cc ON cc.id_comp_contact=po.id_comp_contact
INNER JOIN tb_m_comp c ON c.id_comp=cc.id_comp
LEFT JOIN 
( 
	SELECT recd.`id_purc_order_det`,SUM(recd.`qty`) AS qty FROM tb_purc_rec_det recd 
	INNER JOIN tb_purc_rec rec ON rec.`id_purc_rec`=recd.`id_purc_rec` AND rec.`id_report_status`='6'
	GROUP BY recd.`id_purc_order_det`
) rec ON rec.id_purc_order_det=pod.`id_purc_order_det`
LEFT JOIN
(
	SELECT pyd.id_report, SUM(pyd.`value`) AS `value` FROM `tb_payment_det` pyd
	INNER JOIN tb_payment py ON py.id_payment=pyd.id_payment AND py.id_report_status!=5 AND py.report_mark_type='139'
	GROUP BY pyd.id_report
)payment ON payment.id_report=po.id_purc_order
WHERE 1=1 " & where_string & " GROUP BY po.id_purc_order ORDER BY po.id_purc_order DESC"

        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCPO.DataSource = data
        GVPO.BestFitColumns()
    End Sub

    Sub load_dep()
        Dim query As String = "SELECT 0 AS id_departement,'All Departement' AS departement 
                                UNION
                                SELECT id_departement,departement FROM tb_m_departement"
        viewSearchLookupQuery(SLEDepartement, query, "id_departement", "departement", "id_departement")
    End Sub

    Sub load_item_cat()
        Dim query As String = "SELECT 0 AS id_item_cat,'All Category' AS item_cat 
                                UNION
                                SELECT id_item_cat,item_cat FROM tb_item_cat itc WHERE itc.is_active='1'"
        viewSearchLookupQuery(SLEItemCat, query, "id_item_cat", "item_cat", "id_item_cat")
    End Sub

    Sub load_item()
        Dim query_where As String = ""
        '
        If Not SLEItemCat.EditValue.ToString = "0" Then
            query_where = "itm.id_item_cat='" & SLEItemCat.EditValue.ToString & "' AND"
        End If
        '
        Dim query As String = "SELECT '0' AS id_item,'All item' AS item_desc,'All item' AS `item_cat`
                                UNION
                                SELECT itm.id_item,itm.item_desc,itc.`item_cat`
                                FROM tb_item itm
                                INNER JOIN `tb_item_cat` itc ON itc.id_item_cat=itm.id_item_cat AND itc.`is_active`='1'
                                WHERE " & query_where & " itm.`is_active`='1'"
        viewSearchLookupQuery(SLEItem, query, "id_item", "item_desc", "id_item")
    End Sub

    Sub load_po_item()
        Dim query As String = "SELECT 0 AS id_purc_order,'ALL' AS `purc_order_number` ,'ALL' AS `comp_name`,'ALL' AS `comp_number`
UNION
SELECT po.id_purc_order,po.`purc_order_number` ,c.`comp_name`,c.`comp_number`
FROM tb_purc_order po 
INNER JOIN tb_m_comp_contact cc ON cc.`id_comp_contact`=po.`id_comp_contact`
INNER JOIN tb_m_comp c ON c.`id_comp`=cc.`id_comp`
WHERE po.id_report_status='6' AND po.is_close_rec='2'"
        viewSearchLookupQuery(SLEPONumber, query, "id_purc_order", "purc_order_number", "id_purc_order")
    End Sub

    Sub load_req()
        GVPurcReq.ActiveFilterString = ""
        Dim query_where As String = ""
        '
        If Not SLEDepartement.EditValue.ToString = "0" Then 'departement
            query_where += " AND dep.id_departement='" & SLEDepartement.EditValue.ToString & "' "
        End If
        '
        If Not SLEItemCat.EditValue.ToString = "0" Then 'category
            query_where += " AND cat.id_item_cat='" & SLEItemCat.EditValue.ToString & "' "
        End If
        '
        If Not SLEItem.EditValue.ToString = "0" Then 'item
            query_where += " AND itm.id_item='" & SLEItem.EditValue.ToString & "' "
        End If
        '
        If Not LEPOStatus.EditValue.ToString = "3" Then 'item
            If LEPOStatus.EditValue.ToString = "1" Then 'Not created PO
                query_where += " AND IFNULL(po.qty,0) = 0"
            Else 'PO created
                query_where += " AND IFNULL(po.qty,0) > 0"
            End If
        End If
        'expense type
        query_where += " AND cat.id_expense_type='" & SLEExpenseType.EditValue.ToString & "' "
        '
        Dim query As String = "SELECT '-' AS status_val,cat.id_expense_type,rd.item_detail,rd.id_b_expense,rd.id_b_expense_opex,icd.id_vendor_type,icd.item_cat_detail,vt.vendor_type,req.date_created AS pr_created,dep.`departement`,rd.`id_purc_req_det`,req.`id_purc_req`,req.`purc_req_number`,cat.`item_cat`,itm.`item_desc`,rd.`value` AS val_pr,rd.`qty` AS qty_pr,'no' AS is_check 
                                ,IFNULL(po.qty,0) AS qty_po_created,IFNULL(rec.qty,0)-IFNULL(ret.qty,0) AS qty_rec,0.00 AS qty_po,uom.uom,rd.id_item,req.id_item_type,req.id_report_status,typ.item_type,itm.latest_price,rd.ship_destination,rd.ship_address
                                FROM tb_purc_req_det rd 
                                INNER JOIN tb_purc_req req ON req.id_purc_req=rd.id_purc_req
                                INNER JOIN tb_lookup_purc_item_type typ ON typ.id_item_type=req.id_item_type
                                INNER JOIN tb_item itm ON itm.`id_item`=rd.`id_item`
                                INNER JOIN tb_m_uom uom ON uom.id_uom=itm.id_uom
                                INNER JOIN tb_item_cat cat ON cat.`id_item_cat`=itm.`id_item_cat`
                                INNER JOIN tb_m_departement dep ON dep.`id_departement`=req.`id_departement`
                                INNER JOIN tb_item_cat_detail icd ON icd.`id_item_cat_detail`=itm.`id_item_cat_detail`
                                INNER JOIN tb_vendor_type vt ON vt.id_vendor_type=icd.id_vendor_type
                                LEFT JOIN 
                                (
	                                SELECT pod.`id_purc_order_det`,pod.`id_purc_req_det`,SUM(pod.`qty`) as qty FROM tb_purc_order_det pod
	                                INNER JOIN tb_purc_order po ON po.`id_purc_order`=pod.`id_purc_order`
	                                WHERE po.`id_report_status`!='5' AND pod.is_drop='2'
                                    GROUP BY pod.`id_purc_req_det`
                                )po ON po.id_purc_req_det=rd.`id_purc_req_det`
                                LEFT JOIN 
                                (
	                                SELECT pod.`id_purc_req_det`,SUM(recd.`qty`) as qty FROM tb_purc_rec_det recd
                                    INNER JOIN tb_purc_order_det pod ON recd.id_purc_order_det=pod.id_purc_order_det
	                                INNER JOIN tb_purc_rec rec ON recd.`id_purc_rec`=rec.id_purc_rec
	                                WHERE rec.`id_report_status`!='5'
                                    GROUP BY pod.`id_purc_req_det`
                                )rec ON rec.id_purc_req_det=rd.`id_purc_req_det`
                                LEFT JOIN 
                                (
                                    SELECT pod.`id_purc_req_det`,SUM(prd.`qty`) as qty FROM `tb_purc_return_det` prd
                                    INNER JOIN `tb_purc_return` pr ON pr.id_purc_return=prd.id_purc_return AND pr.id_report_status!='5'
                                    INNER JOIN tb_purc_order_det pod ON prd.id_purc_order_det=pod.id_purc_order_det
                                    INNER JOIN tb_purc_order po ON po.`id_purc_order`=pod.`id_purc_order` AND po.`id_report_status`!='5'
                                    GROUP BY pod.`id_purc_req_det`
                                )ret ON ret.id_purc_req_det=rd.`id_purc_req_det`
                                WHERE req.`id_report_status`='6' AND rd.`is_close`='2' AND rd.is_unable_fulfill='2' " & query_where
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCPurcReq.DataSource = data
        GVPurcReq.BestFitColumns()
    End Sub

    Sub load_vendor()
        Dim query As String = "SELECT 0 AS id_comp,'All Vendor' AS comp_number,'All Vendor' AS comp_name
                               UNION
                               SELECT id_comp,comp_number,comp_name FROM tb_m_comp WHERE id_comp_cat='8'"
        viewSearchLookupQuery(SLEVendor, query, "id_comp", "comp_name", "id_comp")
    End Sub

    Private Sub BView_Click(sender As Object, e As EventArgs) Handles BView.Click
        load_po()
    End Sub

    Private Sub SLEItemCat_EditValueChanged(sender As Object, e As EventArgs) Handles SLEItemCat.EditValueChanged
        load_item()
    End Sub

    Private Sub BViewReqList_Click(sender As Object, e As EventArgs) Handles BViewReqList.Click
        load_req()
    End Sub

    Private Sub BCreatePO_Click(sender As Object, e As EventArgs) Handles BCreatePO.Click
        'check first
        Dim is_already_created, is_zero, is_pr_not_match, is_not_match_destination As Boolean

        is_already_created = False
        is_zero = False
        is_pr_not_match = False
        is_not_match_destination = False

        GVPurcReq.ActiveFilterString = ""
        GVPurcReq.ActiveFilterString = "[is_check]='yes'"
        If GVPurcReq.RowCount > 0 Then
            'check destination
            Dim dest_name As String = GVPurcReq.GetRowCellValue(0, "ship_destination").ToString
            Dim dest_address As String = GVPurcReq.GetRowCellValue(0, "ship_address").ToString
            For i As Integer = 0 To GVPurcReq.RowCount - 1
                If Not GVPurcReq.GetRowCellValue(i, "ship_destination").ToString = dest_name Or Not GVPurcReq.GetRowCellValue(i, "ship_address").ToString = dest_address Then
                    is_not_match_destination = True
                End If
            Next

            'fill Qty
            For i As Integer = 0 To GVPurcReq.RowCount - 1
                GVPurcReq.SetRowCellValue(i, "qty_po", GVPurcReq.GetRowCellValue(i, "qty_pr"))
            Next
            '
            For i As Integer = 0 To GVPurcReq.RowCount - 1
                If (GVPurcReq.GetRowCellValue(i, "qty_po_created") > 0) Then
                    'qty PO already not 0
                    is_already_created = True
                    GVPurcReq.SetRowCellValue(i, "status_val", "Already created PO")
                ElseIf (GVPurcReq.GetRowCellValue(i, "qty_po").ToString = "") OrElse (GVPurcReq.GetRowCellValue(i, "qty_po").ToString = "0") Then
                    is_zero = True
                    GVPurcReq.SetRowCellValue(i, "status_val", "Zero Qty")
                    'ElseIf GVPurcReq.GetRowCellValue(i, "val_pr") < GVPurcReq.GetRowCellValue(i, "latest_price") Then
                    '    is_pr_not_match = True
                    '    GVPurcReq.SetRowCellValue(i, "status_val", "Requested price below the latest Price")
                Else
                    GVPurcReq.SetRowCellValue(i, "status_val", "Ok")
                End If
            Next
            '
            If is_zero = True Then
                stopCustom("Please make sure qty not zero.")
            ElseIf is_already_created = True Then
                stopCustom("PO already created.")
            ElseIf is_pr_not_match = True Then
                stopCustom("Requested price is below the latest price.")
            Else
                If is_not_match_destination = True Then
                    warningCustom("Please note that destination address is different !")
                End If
                FormPurcOrderDet.is_pick = "1"
                FormPurcOrderDet.ShowDialog()
            End If
            GVPurcReq.BestFitColumns()
        Else
            warningCustom("Please select item first.")
            GVPurcReq.ActiveFilterString = ""
        End If
    End Sub

    Private Sub GVPO_DoubleClick(sender As Object, e As EventArgs) Handles GVPO.DoubleClick
        If GVPO.RowCount > 0 Then
            FormPurcOrderDet.id_po = GVPO.GetFocusedRowCellValue("id_purc_order").ToString
            FormPurcOrderDet.ShowDialog()
        End If
    End Sub

    Private Sub BCantFulfill_Click(sender As Object, e As EventArgs) Handles BCantFulfill.Click
        'update status to cannot proceed
        GVPurcReq.ActiveFilterString = ""
        GVPurcReq.ActiveFilterString = "[is_check]='yes'"
        FormPurcReqItemUnableFulfill.id_popup = "1"
        FormPurcReqItemUnableFulfill.ShowDialog()
        GVPurcReq.ActiveFilterString = ""
    End Sub

    Private Sub SMClose_Click(sender As Object, e As EventArgs) Handles SMClose.Click
        GVPO.ActiveFilterString = ""
        GVPO.ActiveFilterString = "[is_check]='yes'"
        FormPurcReqItemUnableFulfill.id_popup = "2"
        FormPurcReqItemUnableFulfill.ShowDialog()
        GVPO.ActiveFilterString = ""
    End Sub

    Private Sub CheckEditSelAll_CheckedChanged(sender As Object, e As EventArgs) Handles CheckEditSelAll.CheckedChanged
        If GVPOItem.RowCount > 0 Then
            For i As Integer = 0 To ((GVPOItem.RowCount - 1) - GetGroupRowCount(GVPOItem))
                If CheckEditSelAll.Checked = False Then
                    GVPOItem.SetRowCellValue(i, "is_check", "no")
                Else
                    GVPOItem.SetRowCellValue(i, "is_check", "yes")
                End If
            Next
        End If
    End Sub

    Sub load_vendor_list_po()
        Dim query As String = "SELECT 0 AS `id_comp`,'ALL' AS `comp_number`,'ALL' AS `comp_name`
UNION
SELECT c.`id_comp`,c.`comp_number`,c.`comp_name` FROM tb_purc_order po
INNER JOIN tb_m_comp_contact cc ON cc.`id_comp_contact`=po.`id_comp_contact`
INNER JOIN tb_m_comp c ON c.`id_comp`=cc.id_comp
GROUP BY c.id_comp"
        viewSearchLookupQuery(SLEVendorListPO, query, "id_comp", "comp_name", "id_comp")
    End Sub

    Sub load_list_item_po()
        Dim query_where As String = ""

        If Not SLEVendorListPO.EditValue.ToString = "0" Then 'id vendor
            query_where += " AND c.id_comp='" & SLEVendorListPO.EditValue.ToString & "' "
        End If

        If Not SLEPONumber.EditValue.ToString = "0" Then 'id po
            query_where += " AND po.id_purc_order='" & SLEPONumber.EditValue.ToString & "' "
        End If

        Dim query As String = "SELECT 'no' AS is_check,po.`id_purc_order`,po.`id_expense_type`,reqd.`id_b_expense`,reqd.`id_b_expense_opex`,pod.qty AS qty_po,SUM(IFNULL(recd.qty,0.00)) AS qty_rec,IF(pod.is_drop='1','Closed',IF(SUM(IFNULL(recd.qty,0.00))=0,'Waiting',IF(SUM(IFNULL(recd.qty,0.00))<pod.qty,'Partial','Complete'))) AS status_rec,po.date_created,cd.item_cat_detail,po.est_date_receive,po.pay_due_date
,pod.`id_purc_order_det`,po.`purc_order_number`,c.`comp_number`,c.`comp_name`,it.id_item,it.`item_desc`,reqd.`item_detail`,pod.`value`,(pod.`qty`*pod.`value`) AS tot_value
FROM tb_purc_order_det pod
INNER JOIN tb_purc_order po ON po.`id_purc_order`=pod.`id_purc_order` AND po.`id_report_status` = 6 AND po.`is_close_rec`='2'
INNER JOIN tb_purc_req_det reqd ON reqd.`id_purc_req_det`=pod.`id_purc_req_det`
INNER JOIN tb_purc_req req ON req.`id_purc_req`=reqd.`id_purc_req`
INNER JOIN tb_item it ON it.`id_item`=reqd.`id_item`
INNER JOIN tb_item_cat cat ON cat.`id_item_cat`=it.`id_item_cat`
INNER JOIN tb_item_cat_detail cd ON cd.id_item_cat_detail=it.id_item_cat_detail
INNER JOIN tb_m_comp_contact cc ON cc.`id_comp_contact`=po.`id_comp_contact`
INNER JOIN tb_m_comp c ON c.`id_comp`=cc.`id_comp`
LEFT JOIN tb_purc_rec_det recd ON recd.id_purc_order_det=pod.id_purc_order_det
LEFT JOIN tb_purc_rec rec ON rec.id_purc_rec=recd.id_purc_rec AND rec.id_report_status!=5
WHERE req.`id_report_status` = 6 AND reqd.`is_unable_fulfill` = '2' " & query_where & " 
GROUP BY pod.id_purc_order_det"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCPOItem.DataSource = data
        GVPOItem.BestFitColumns()
    End Sub

    Private Sub BViewPOItem_Click(sender As Object, e As EventArgs) Handles BViewPOItem.Click
        load_list_item_po()
    End Sub

    Private Sub BBCloseReceiving_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BBDropPOItem.ItemClick
        GVPOItem.ActiveFilterString = "[is_check]='yes' AND [status_rec]='Waiting'"
        If GVPOItem.RowCount > 0 Then
            Dim confirm As DialogResult = DevExpress.XtraEditors.XtraMessageBox.Show("Apakah anda yakin ingin membatalkan item tersebut?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
            If confirm = DialogResult.Yes Then
                Dim id_det As String = ""
                Dim q_opex As String = ""
                Dim q_capex As String = ""

                For i As Integer = 0 To GVPOItem.RowCount - 1
                    If Not id_det = "" Then
                        id_det += ","
                    End If
                    id_det += GVPOItem.GetRowCellValue(i, "id_purc_order_det").ToString

                    If GVPOItem.GetRowCellValue(i, "id_expense_type").ToString = "1" Then
                        'opex
                        If Not q_opex = "" Then
                            q_opex += ","
                        End If
                        q_opex += "('" & GVPOItem.GetRowCellValue(i, "id_b_expense_opex").ToString & "',NOW(),'-" & decimalSQL(GVPOItem.GetRowCellValue(i, "tot_value").ToString) & "','" & GVPOItem.GetRowCellValue(i, "id_purc_order").ToString & "','139','Cancel order item')"
                    Else
                        'capex
                        If Not q_capex = "" Then
                            q_capex += ","
                        End If
                        q_capex += "('" & GVPOItem.GetRowCellValue(i, "id_b_expense").ToString & "',NOW(),'-" & decimalSQL(GVPOItem.GetRowCellValue(i, "tot_value").ToString) & "','" & GVPOItem.GetRowCellValue(i, "id_purc_order").ToString & "','202','Cancel order item')"
                    End If
                Next
                '
                If Not id_det = "" Then
                    Dim query As String = ""
                    'close
                    query = "UPDATE tb_purc_order_det SET is_drop='1' WHERE id_purc_order_det IN (" & id_det & ")"
                    execute_non_query(query, True, "", "", "", "")
                    'budget remove
                    'opex
                    If Not q_opex = "" Then
                        query = "INSERT INTO tb_b_expense_opex_trans(id_b_expense_opex,date_trans,value_expense,id_report,report_mark_type,note) VALUES " & q_opex
                        execute_non_query(query, True, "", "", "", "")
                    End If
                    'capex
                    If Not q_capex = "" Then
                        query = "INSERT INTO tb_b_expense_trans(id_b_expense,date_trans,value,id_report,report_mark_type,note) VALUES " & q_capex
                        execute_non_query(query, True, "", "", "", "")
                    End If
                    load_list_item_po()
                End If
            End If
        Else
            stopCustom("Pilih item terlebih dahulu, hanya status receiving 'Waiting' yang akan diproses.")
        End If
        GVPOItem.ActiveFilterString = ""
    End Sub
End Class