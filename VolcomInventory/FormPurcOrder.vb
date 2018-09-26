Public Class FormPurcOrder
    Dim bnew_active As String = "1"
    Dim bedit_active As String = "1"
    Dim bdel_active As String = "1"
    '
    Public is_purc_dep As String = "-1"
    '
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

    Sub check_menu()
        bnew_active = "0"
        bedit_active = "0"
        bdel_active = "0"
        checkFormAccess(Name)
        button_main(bnew_active, bedit_active, bdel_active)
    End Sub

    Private Sub FormPurcOrder_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        load_vendor()
        '
        load_dep()
        load_item_cat()
        load_item()
        '
        check_menu()
    End Sub

    Sub load_po()

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

    Sub load_req()
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
        Dim query As String = "SELECT req.date_created AS pr_created,dep.`departement`,rd.`id_purc_req_det`,req.`id_purc_req`,req.`purc_req_number`,cat.`item_cat`,itm.`item_desc`,rd.`value` AS val_pr,rd.`qty` AS qty_pr,'no' AS is_check 
                                ,IFNULL(po.qty,0) AS qty_po_created,IFNULL(rec.qty,0) AS qty_rec,0.00 AS qty_po,uom.uom,rd.id_item
                                FROM tb_purc_req_det rd 
                                INNER JOIN tb_purc_req req ON req.id_purc_req=rd.id_purc_req
                                INNER JOIN tb_item itm ON itm.`id_item`=rd.`id_item`
                                INNER JOIN tb_m_uom uom ON uom.id_uom=itm.id_uom
                                INNER JOIN tb_item_cat cat ON cat.`id_item_cat`=itm.`id_item_cat`
                                INNER JOIN tb_m_departement dep ON dep.`id_departement`=req.`id_departement`
                                LEFT JOIN 
                                (
	                                SELECT pod.`id_purc_order_det`,pod.`id_purc_req_det`,pod.`qty` FROM tb_purc_order_det pod
	                                INNER JOIN tb_purc_order po ON po.`id_purc_order`=pod.`id_purc_order`
	                                WHERE po.`id_report_status`!='5'
                                )po ON po.id_purc_req_det=rd.`id_purc_req_det`
                                LEFT JOIN 
                                (
	                                SELECT precd.id_purc_order_det,precd.`id_purc_rec_det`,precd.`qty` FROM tb_purc_rec_det precd
	                                INNER JOIN tb_purc_rec prec ON prec.`id_purc_rec`= precd.`id_purc_rec` AND prec.`id_report_status`!='5'
	                                INNER JOIN tb_purc_order_det pod ON pod.`id_purc_order_det`=precd.`id_purc_order_det`
	                                INNER JOIN tb_purc_order po ON po.`id_purc_order`=pod.`id_purc_order` AND po.`id_report_status`!='5'
                                )rec ON rec.id_purc_order_det=po.`id_purc_order_det`
                                WHERE req.`id_report_status`='6' AND rd.`is_close`='2' " & query_where
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCPurcReq.DataSource = data
    End Sub

    Sub load_vendor()
        Dim query As String = "SELECT 0 AS id_comp,'All Vendor' AS comp_number,'All Vendor' AS comp_name
                               UNION
                               SELECT id_comp,comp_number,comp_name FROM tb_m_comp WHERE id_comp_cat='1'"
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
        Dim is_exceed, is_zero As Boolean

        is_exceed = False
        is_zero = False

        GVPurcReq.ActiveFilterString = "[is_check]='yes'"
        For i As Integer = 0 To GVPurcReq.RowCount - 1
            If (GVPurcReq.GetRowCellValue(i, "qty_po") = 0) Then
                'qty PO zero
                is_zero = True
            ElseIf (GVPurcReq.GetRowCellValue(i, "qty_po") > (GVPurcReq.GetRowCellValue(i, "qty_pr") - GVPurcReq.GetRowCellValue(i, "qty_po_created"))) Then
                is_exceed = True
            End If
        Next
        '
        If is_zero = True Then
            stopCustom("Please make sure qty not zero.")
        ElseIf is_exceed = True Then
            stopCustom("Please make sure qty PO not exceeding requested quantity.")
        Else
            FormPurcOrderDet.is_pick = "1"
            FormPurcOrderDet.ShowDialog()
        End If
    End Sub
End Class