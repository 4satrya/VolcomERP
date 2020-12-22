Public Class FormOLStoreSummary
    Private Sub FormOLStoreSummary_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed

    End Sub

    Private Sub FormOLStoreSummary_Deactivate(sender As Object, e As EventArgs) Handles MyBase.Deactivate
        FormMain.hide_rb()
    End Sub

    Private Sub FormOLStoreSummary_Activated(sender As Object, e As EventArgs) Handles MyBase.Activated
        FormMain.show_rb(Name)
        checkFormAccess(Name)
    End Sub

    Private Sub FormOLStoreSummary_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim data_dt As DataTable = execute_query("SELECT DATE(NOW()) AS `dt`", -1, True, "", "", "", "")
        DEFrom.EditValue = data_dt.Rows(0)("dt")
        DEUntil.EditValue = data_dt.Rows(0)("dt")
        DEFromDetail.EditValue = data_dt.Rows(0)("dt")
        DEUntilDetail.EditValue = data_dt.Rows(0)("dt")
        DEUpdatedFrom.EditValue = data_dt.Rows(0)("dt")
        DEUpdatedUntil.EditValue = data_dt.Rows(0)("dt")
        DEExFrom.EditValue = data_dt.Rows(0)("dt")
        DEExUntil.EditValue = data_dt.Rows(0)("dt")
        viewComp()
        viewCompGroup()
        viewCompDetail()
        viewPromo()
        viewPromoNotAll()

        'set caption size
        'propose
        GVPromoDetail.Columns("qty1").Caption = "1" + System.Environment.NewLine + "XXS"
        GVPromoDetail.Columns("qty2").Caption = "2" + System.Environment.NewLine + "XS"
        GVPromoDetail.Columns("qty3").Caption = "3" + System.Environment.NewLine + "S"
        GVPromoDetail.Columns("qty4").Caption = "4" + System.Environment.NewLine + "M"
        GVPromoDetail.Columns("qty5").Caption = "5" + System.Environment.NewLine + "ML"
        GVPromoDetail.Columns("qty6").Caption = "6" + System.Environment.NewLine + "L"
        GVPromoDetail.Columns("qty7").Caption = "7" + System.Environment.NewLine + "XL"
        GVPromoDetail.Columns("qty8").Caption = "8" + System.Environment.NewLine + "XXL"
        GVPromoDetail.Columns("qty9").Caption = "9" + System.Environment.NewLine + "ALL"
        GVPromoDetail.Columns("qty0").Caption = "0" + System.Environment.NewLine + "SM"
        'soh
        GVPromoDetail.Columns("rep_qty1").Caption = "1" + System.Environment.NewLine + "XXS"
        GVPromoDetail.Columns("rep_qty2").Caption = "2" + System.Environment.NewLine + "XS"
        GVPromoDetail.Columns("rep_qty3").Caption = "3" + System.Environment.NewLine + "S"
        GVPromoDetail.Columns("rep_qty4").Caption = "4" + System.Environment.NewLine + "M"
        GVPromoDetail.Columns("rep_qty5").Caption = "5" + System.Environment.NewLine + "ML"
        GVPromoDetail.Columns("rep_qty6").Caption = "6" + System.Environment.NewLine + "L"
        GVPromoDetail.Columns("rep_qty7").Caption = "7" + System.Environment.NewLine + "XL"
        GVPromoDetail.Columns("rep_qty8").Caption = "8" + System.Environment.NewLine + "XXL"
        GVPromoDetail.Columns("rep_qty9").Caption = "9" + System.Environment.NewLine + "ALL"
        GVPromoDetail.Columns("rep_qty0").Caption = "0" + System.Environment.NewLine + "SM"
        'sal
        GVPromoDetail.Columns("sal_qty1").Caption = "1" + System.Environment.NewLine + "XXS"
        GVPromoDetail.Columns("sal_qty2").Caption = "2" + System.Environment.NewLine + "XS"
        GVPromoDetail.Columns("sal_qty3").Caption = "3" + System.Environment.NewLine + "S"
        GVPromoDetail.Columns("sal_qty4").Caption = "4" + System.Environment.NewLine + "M"
        GVPromoDetail.Columns("sal_qty5").Caption = "5" + System.Environment.NewLine + "ML"
        GVPromoDetail.Columns("sal_qty6").Caption = "6" + System.Environment.NewLine + "L"
        GVPromoDetail.Columns("sal_qty7").Caption = "7" + System.Environment.NewLine + "XL"
        GVPromoDetail.Columns("sal_qty8").Caption = "8" + System.Environment.NewLine + "XXL"
        GVPromoDetail.Columns("sal_qty9").Caption = "9" + System.Environment.NewLine + "ALL"
        GVPromoDetail.Columns("sal_qty0").Caption = "0" + System.Environment.NewLine + "SM"
        'bal
        GVPromoDetail.Columns("bal_qty1").Caption = "1" + System.Environment.NewLine + "XXS"
        GVPromoDetail.Columns("bal_qty2").Caption = "2" + System.Environment.NewLine + "XS"
        GVPromoDetail.Columns("bal_qty3").Caption = "3" + System.Environment.NewLine + "S"
        GVPromoDetail.Columns("bal_qty4").Caption = "4" + System.Environment.NewLine + "M"
        GVPromoDetail.Columns("bal_qty5").Caption = "5" + System.Environment.NewLine + "ML"
        GVPromoDetail.Columns("bal_qty6").Caption = "6" + System.Environment.NewLine + "L"
        GVPromoDetail.Columns("bal_qty7").Caption = "7" + System.Environment.NewLine + "XL"
        GVPromoDetail.Columns("bal_qty8").Caption = "8" + System.Environment.NewLine + "XXL"
        GVPromoDetail.Columns("bal_qty9").Caption = "9" + System.Environment.NewLine + "ALL"
        GVPromoDetail.Columns("bal_qty0").Caption = "0" + System.Environment.NewLine + "SM"
    End Sub

    Sub viewCompGroup()
        Cursor = Cursors.WaitCursor
        Dim query As String = "
        SELECT 0 AS id_comp_group, 'ALL' AS comp_group, 'ALL GROUP' AS description
        UNION
        SELECT cg.id_comp_group, cg.comp_group, cg.description 
        FROM tb_m_comp_group cg
        INNER JOIN tb_m_comp c ON c.id_comp_group = cg.id_comp_group AND c.id_commerce_type=2
        GROUP BY cg.id_comp_group "
        viewSearchLookupQuery(SLECompGroup, query, "id_comp_group", "description", "id_comp_group")
        Cursor = Cursors.Default
    End Sub

    Sub viewComp()
        Dim query As String = "SELECT 0 AS `id_comp`, 0 AS `id_comp_contact`, 'ALL' AS `comp_number`, 'ALL STORE' AS `comp_name`
        UNION ALL
        SELECT c.id_comp,cc.id_comp_contact, c.comp_number,c.comp_name 
        FROM tb_m_comp c 
        INNER JOIN tb_m_comp_contact cc ON cc.id_comp = c.id_comp AND cc.is_default=1 
        WHERE c.id_commerce_type=2 AND c.is_active=1 "
        viewSearchLookupQuery(SLEComp, query, "id_comp", "comp_name", "id_comp")
    End Sub

    Sub viewCompDetail()
        Dim query As String = "SELECT 0 AS `id_comp`, 0 AS `id_comp_contact`, 'ALL' AS `comp_number`, 'ALL STORE' AS `comp_name`
        UNION ALL
        SELECT c.id_comp,cc.id_comp_contact, c.comp_number,c.comp_name 
        FROM tb_m_comp c 
        INNER JOIN tb_m_comp_contact cc ON cc.id_comp = c.id_comp AND cc.is_default=1 
        WHERE c.id_commerce_type=2 AND c.is_active=1 " + If(SLECompGroup.EditValue.ToString = "0", "", "AND c.id_comp_group = " + SLECompGroup.EditValue.ToString)
        viewSearchLookupQuery(SLECompDetail, query, "id_comp", "comp_name", "id_comp")
    End Sub

    Sub viewPromo()
        Cursor = Cursors.WaitCursor
        Dim prm As New ClassPromoCollection()
        Dim query As String = "SELECT 0 AS id_ol_promo_collection, 0 AS id_promo, 'All' AS promo, '' AS `number`,
        NOW() AS start_period, NOW() AS end_period
        UNION ALL 
        SELECT p.id_ol_promo_collection, prm.id_promo, p.promo_name AS `promo`, p.`number`,
        p.start_period, p.end_period
        FROM tb_ol_promo_collection p
        INNER JOIN tb_promo prm ON prm.id_promo = p.id_promo
        WHERE p.id_report_status=6
        ORDER BY id_ol_promo_collection DESC "
        viewSearchLookupQuery(SLEPromo, query, "id_ol_promo_collection", "promo", "id_ol_promo_collection") '
        viewSearchLookupQuery(SLEPromoSummary, query, "id_ol_promo_collection", "promo", "id_ol_promo_collection") '
        SLEPromo.EditValue = 0
        SLEPromoSummary.EditValue = 0
        Cursor = Cursors.Default
    End Sub

    Sub viewPromoNotAll()
        Cursor = Cursors.WaitCursor
        Dim prm As New ClassPromoCollection()
        Dim query As String = "SELECT p.id_ol_promo_collection, prm.id_promo, p.promo_name AS `promo`, p.`number`,
        p.start_period, p.end_period
        FROM tb_ol_promo_collection p
        INNER JOIN tb_promo prm ON prm.id_promo = p.id_promo
        WHERE p.id_report_status=6 AND p.is_use_discount_code=2
        ORDER BY id_ol_promo_collection DESC "
        viewSearchLookupQuery(SLEPromoDetail, query, "id_ol_promo_collection", "promo", "id_ol_promo_collection")
        Cursor = Cursors.Default
    End Sub

    Private Sub BtnView_Click(sender As Object, e As EventArgs) Handles BtnView.Click
        viewRmt()
        viewData()
    End Sub

    Sub viewData()
        Cursor = Cursors.WaitCursor
        'Prepare paramater
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

        'group store
        Dim id_comp_group As String = SLECompGroup.EditValue.ToString

        Dim id_comp As String = SLEComp.EditValue.ToString
        Dim query As String = "SELECT so.sales_order_number, so.sales_order_ol_shop_number, so.sales_order_date AS `order_date`, del.pl_sales_order_del_number, del.pl_sales_order_del_date AS `del_date`,ro.sales_return_order_number, ro.sales_return_order_date as `ro_date`, r.sales_return_number, r.sales_return_date AS `ret_date`, inv.sales_pos_number, inv.sales_pos_number AS `inv_date`, cn.sales_pos_cn_number, cn.sales_pos_cn_date AS `cn_date`,
        IF(ISNULL(inv.id_sales_pos),'Pending',IF(inv.id_report_status<5,'Prepared',IF(j.id_status_open=2,'Paid','Invoice Sent'))) AS `paid_status`, '0' AS `report_mark_type`,
        so.id_sales_order, del.id_del,ro.id_ro, r.id_ret, inv.id_inv, cn.id_cn
        FROM tb_sales_order so 
        INNER JOIN tb_m_comp_contact socc ON socc.id_comp_contact = so.id_store_contact_to
        INNER JOIN tb_m_comp c ON c.id_comp = socc.id_comp
        LEFT JOIN (
            SELECT del.id_pl_sales_order_del,
            IF(ISNULL(del.id_pl_sales_order_del),0,GROUP_CONCAT(DISTINCT del.id_pl_sales_order_del ORDER BY del.id_pl_sales_order_del ASC SEPARATOR '#')) AS `id_del`,
            GROUP_CONCAT(DISTINCT del.pl_sales_order_del_number ORDER BY del.id_pl_sales_order_del ASC SEPARATOR ', ') AS `pl_sales_order_del_number`, del.pl_sales_order_del_date,
            del.id_sales_order
            FROM tb_pl_sales_order_del del
            WHERE del.id_report_status=6
            GROUP BY del.id_sales_order
        ) del ON del.id_sales_order = so.id_sales_order
        LEFT JOIN (
            SELECT ro.id_sales_return_order,
            GROUP_CONCAT(DISTINCT ro.sales_return_order_number ORDER BY ro.id_sales_return_order ASC SEPARATOR ', ') AS `sales_return_order_number`,
            IF(ISNULL(ro.id_sales_return_order),0,GROUP_CONCAT(DISTINCT ro.id_sales_return_order ORDER BY ro.id_sales_return_order ASC SEPARATOR '#')) AS `id_ro`, ro.sales_return_order_date,
            ro.id_sales_order
            FROM tb_sales_return_order ro
            WHERE ro.id_report_status=6
            GROUP BY ro.id_sales_order                    
        ) ro ON ro.id_sales_order = so.id_sales_order  
        LEFT JOIN (
            SELECT r.id_sales_return,
            GROUP_CONCAT(DISTINCT r.sales_return_number ORDER BY r.id_sales_return ASC SEPARATOR ', ') AS `sales_return_number`,
            IF(ISNULL(r.id_sales_return),0,GROUP_CONCAT(DISTINCT r.id_sales_return ORDER BY r.id_sales_return ASC SEPARATOR '#')) AS `id_ret`, r.sales_return_date,
            ro.id_sales_order
            FROM tb_sales_return r
            INNER JOIN tb_sales_return_order ro ON ro.id_sales_return_order = r.id_sales_return_order
            WHERE r.id_report_status=6
            GROUP BY ro.id_sales_order      
        ) r ON r.id_sales_order = so.id_sales_order 
        LEFT JOIN (
            SELECT inv.id_sales_pos,
            GROUP_CONCAT(DISTINCT inv.sales_pos_number ORDER BY inv.id_sales_pos ASC SEPARATOR ', ') AS `sales_pos_number`,
            IF(ISNULL(inv.id_sales_pos),0,GROUP_CONCAT(DISTINCT inv.id_sales_pos ORDER BY inv.id_sales_pos ASC SEPARATOR '#')) AS `id_inv`, inv.sales_pos_date, inv.id_report_status,
            del.id_sales_order
            FROM tb_sales_pos inv
            INNER JOIN tb_sales_pos_det invd ON invd.id_sales_pos = inv.id_sales_pos
            INNER JOIN tb_pl_sales_order_del_det deld ON deld.id_pl_sales_order_del_det = invd.id_pl_sales_order_del_det
            INNER JOIN tb_pl_sales_order_del del ON del.id_pl_sales_order_del = deld.id_pl_sales_order_del
            WHERE inv.id_report_status=6 AND inv.id_memo_type=1
            GROUP BY del.id_sales_order  
        ) inv ON inv.id_sales_order = so.id_sales_order 
        LEFT JOIN (
            SELECT cn.id_sales_pos,
            GROUP_CONCAT(DISTINCT cn.sales_pos_number ORDER BY cn.id_sales_pos ASC SEPARATOR ', ') AS `sales_pos_cn_number`,
            IF(ISNULL(cn.id_sales_pos),0,GROUP_CONCAT(DISTINCT cn.id_sales_pos ORDER BY cn.id_sales_pos ASC SEPARATOR '#')) AS `id_cn`, cn.sales_pos_date AS `sales_pos_cn_date`,
            del.id_sales_order
            FROM tb_sales_pos cn
            INNER JOIN tb_sales_pos_det cnd ON cnd.id_sales_pos = cn.id_sales_pos
            INNER JOIN tb_sales_pos_det invd ON invd.id_sales_pos_det = cnd.id_sales_pos_det_ref
            INNER JOIN tb_pl_sales_order_del_det deld ON deld.id_pl_sales_order_del_det = invd.id_pl_sales_order_del_det
            INNER JOIN tb_pl_sales_order_del del ON del.id_pl_sales_order_del = deld.id_pl_sales_order_del
            WHERE cn.id_report_status=6 AND cn.id_memo_type=2
            GROUP BY del.id_sales_order  
        ) cn ON cn.id_sales_order = so.id_sales_order 
        LEFT JOIN (
            SELECT ad.id_acc_trans_det,sod.id_sales_order, ad.id_status_open
            FROM tb_a_acc_trans_det ad
            INNER JOIN tb_a_acc_trans a ON a.id_acc_trans = ad.id_acc_trans
            INNER JOIN tb_a_acc coa ON coa.id_acc = ad.id_acc
            INNER JOIN tb_sales_pos inv ON inv.id_sales_pos = ad.id_report
            INNER JOIN tb_sales_pos_det invd ON invd.id_sales_pos = inv.id_sales_pos
            INNER JOIN tb_pl_sales_order_del_det dd ON dd.id_pl_sales_order_del_det = invd.id_pl_sales_order_del_det
            INNER JOIN tb_sales_order_det sod ON sod.id_sales_order_det = dd.id_sales_order_det
            WHERE a.id_report_status=6 AND (ad.report_mark_type=48 OR ad.report_mark_type=54) AND coa.acc_name LIKE '1113%'
            GROUP BY sod.id_sales_order
        ) j ON j.id_sales_order = so.id_sales_order
        WHERE c.id_comp_group='" + id_comp_group + "' AND c.id_comp=" + id_comp + " AND so.id_report_status=6 AND (so.sales_order_date>='" + date_from_selected + "' AND so.sales_order_date<='" + date_until_selected + "') "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCData.DataSource = data
        Cursor = Cursors.Default
    End Sub

    Sub viewRmt()
        Dim query As String = "SELECT 0 AS report_mark_type, '-Select-' AS  report_mark_type_name UNION ALL
        SELECT rmt.report_mark_type, rmt.report_mark_type_name 
        FROM tb_lookup_report_mark_type rmt 
        WHERE rmt.report_mark_type=39
        OR rmt.report_mark_type=43
        OR rmt.report_mark_type=48
        OR rmt.report_mark_type=118
        OR rmt.report_mark_type=119
        OR rmt.report_mark_type=120 "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        RepoAttach.DataSource = data
        RepoAttach.DisplayMember = "report_mark_type_name"
        RepoAttach.ValueMember = "report_mark_type"
    End Sub

    Sub viewRmtDetail()
        Dim query As String = "SELECT 0 AS report_mark_type, '-Select-' AS  report_mark_type_name 
        UNION ALL
        SELECT rmt.report_mark_type, rmt.report_mark_type_name 
        FROM tb_lookup_report_mark_type rmt 
        WHERE rmt.report_mark_type=39
        OR rmt.report_mark_type=43
        OR rmt.report_mark_type=48
        OR rmt.report_mark_type=118
        OR rmt.report_mark_type=119
        OR rmt.report_mark_type=120
        OR rmt.report_mark_type=162 
        UNION ALL 
        SELECT '162-1' AS report_mark_type, 'Return Payment' AS  report_mark_type_name "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        RepoAttachDetail.DataSource = data
        RepoAttachDetail.DisplayMember = "report_mark_type_name"
        RepoAttachDetail.ValueMember = "report_mark_type"
    End Sub



    Private Sub GVData_CellValueChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles GVData.CellValueChanged
        If e.Column.FieldName = "report_mark_type" Then
            Dim rh As Integer = e.RowHandle
            Dim val As String = e.Value.ToString
            If val <> "0" Then
                'MsgBox(val)
                FormSuperUser.ShowDialog()
                GVData.SetFocusedRowCellValue("report_mark_type", 0)
            End If
        End If
    End Sub


    Private Sub RepoAttach_EditValueChanged(sender As Object, e As EventArgs) Handles RepoAttach.EditValueChanged
        Cursor = Cursors.WaitCursor
        Dim LE As DevExpress.XtraEditors.LookUpEdit = CType(sender, DevExpress.XtraEditors.LookUpEdit)
        Dim val As String = LE.EditValue.ToString
        Dim id As String = ""
        Dim id_arr() As String
        Dim cond As String = ""
        If val <> "0" Then
            If val = "39" Then
                id = GVData.GetFocusedRowCellValue("id_sales_order").ToString
            ElseIf val = "43" Then
                id = GVData.GetFocusedRowCellValue("id_del").ToString
            ElseIf val = "48" Then
                id = GVData.GetFocusedRowCellValue("id_inv").ToString
            ElseIf val = "118" Then
                id = GVData.GetFocusedRowCellValue("id_cn").ToString
            ElseIf val = "119" Then
                id = GVData.GetFocusedRowCellValue("id_ro").ToString
            ElseIf val = "120" Then
                id = GVData.GetFocusedRowCellValue("id_ret").ToString
            End If

            id_arr = id.Split("#")
            FormDocumentUpload.is_view = "1"
            For i = 0 To id_arr.Length - 1
                If i = 0 Then
                    FormDocumentUpload.id_report = id_arr(i).ToString
                Else
                    cond += "OR id_report='" + id_arr(i).ToString + "' "
                End If
            Next
            FormDocumentUpload.report_mark_type = val
            FormDocumentUpload.cond = cond
            FormDocumentUpload.ShowDialog()
            LE.ItemIndex = 0
        End If
        Cursor = Cursors.Default
    End Sub

    Private Sub BtnViewDetail_Click(sender As Object, e As EventArgs) Handles BtnViewDetail.Click
        viewRmtDetail()
        viewDetail("1")
    End Sub

    Sub viewDetail(ByVal type_par As String)
        Cursor = Cursors.WaitCursor
        'Prepare paramater date
        Dim cond_date As String = ""
        Dim date_from_selected As String = "0000-01-01"
        Dim date_until_selected As String = "9999-01-01"
        Try
            date_from_selected = DateTime.Parse(DEFromDetail.EditValue.ToString).ToString("yyyy-MM-dd")
        Catch ex As Exception
        End Try
        Try
            date_until_selected = DateTime.Parse(DEUntilDetail.EditValue.ToString).ToString("yyyy-MM-dd")
        Catch ex As Exception
        End Try
        If type_par = "1" Then
            cond_date = "AND (so.sales_order_date>='" + date_from_selected + "' AND so.sales_order_date<='" + date_until_selected + "') "
        End If
        Dim upd_date_from_selected As String = "0000-01-01"
        Dim upd_date_until_selected As String = "9999-01-01"
        Try
            upd_date_from_selected = DateTime.Parse(DEUpdatedFrom.EditValue.ToString).ToString("yyyy-MM-dd")
        Catch ex As Exception
        End Try
        Try
            upd_date_until_selected = DateTime.Parse(DEUpdatedUntil.EditValue.ToString).ToString("yyyy-MM-dd")
        Catch ex As Exception
        End Try


        Dim id_comp As String = SLECompDetail.EditValue.ToString
        Dim qcomp1 As String = ""
        Dim qcomp2 As String = ""
        If id_comp = "0" Then
            qcomp1 = ""
            qcomp2 = ""
        Else
            qcomp1 = "AND cc.id_comp=" + id_comp + " "
            qcomp2 = "AND c.id_comp=" + id_comp + " "
        End If

        Dim id_comp_group As String = SLECompGroup.EditValue.ToString
        Dim qcomp1_group As String = ""
        Dim qcomp2_group As String = ""
        If id_comp_group = "0" Then
            qcomp1_group = ""
            qcomp2_group = ""
        Else
            qcomp1_group = "AND cc.id_comp_group=" + id_comp_group + " "
            qcomp2_group = "AND c.id_comp_group=" + id_comp_group + " "
        End If

        'having
        Dim cond_having As String = ""
        If type_par = "2" Then
            cond_having = "AND (DATE(ol_store_date)>='" + upd_date_from_selected + "' AND DATE(ol_store_date)<='" + upd_date_until_selected + "') "
        End If

        Dim query As String = "SELECT c.id_comp, c.comp_number, c.comp_name,
        IFNULL(so.id_sales_order,0) AS `id_order`, so.sales_order_number AS `order_number`, so.sales_order_ol_shop_number AS `ol_store_order_number`, so.sales_order_date AS `order_date`, cg.description AS `store_group`,CONCAT(c.comp_number,' - ', c.comp_name) AS `store`, CONCAT(w.comp_number,' - ', w.comp_name) AS `wh`,
        sod.id_sales_order_det, sod.item_id, sod.ol_store_id, sod.id_product, prod.product_full_code AS `code`, prod.product_display_name AS `name`, sz.code_detail_name AS `size`, sod.id_design_price, sod.design_price, sod.sales_order_det_qty AS `order_qty`, sod.sales_order_det_note, sod.discount, prm.promo_name AS `promo`, sod.discount_code, prm.number AS `propose_promo_number`, prm.id_ol_promo_collection,
        IFNULL(del.id_pl_sales_order_del,0) AS `id_del`,del.pl_sales_order_del_number AS `del_number`, del.pl_sales_order_del_date AS `del_date`, del.report_status AS `del_status`, awb_del.awbill_no, awb_del.del_received_date, awb_del.del_received_by,
        IFNULL(ro.id_sales_return_order,0) AS `id_ro`, ro.sales_return_order_number AS `ro_number`, ro.sales_return_order_date as `ro_date`, ro.report_status AS `ro_status`,
        IFNULL(ret.id_sales_return,0) AS `id_ret`,ret.sales_return_number AS `ret_number`, ret.sales_return_date AS `ret_date`, ret.report_status AS `ret_status`,
        IFNULL(inv.id_sales_pos,0) AS `id_inv`,inv.sales_pos_number AS `inv_number`, inv.sales_pos_date AS `inv_date`, inv.report_status AS `inv_status`,
        IFNULL(cn.id_sales_pos,0) AS `id_cn`, cn.sales_pos_number AS `cn_number`, cn.sales_pos_date AS `cn_date`, cn.report_status AS `cn_status`,
        IFNULL(rec_pay.id_rec_payment,0) AS `id_rec_pay`,rec_pay.`number` AS `rec_pay_number`, rec_pay.date_created AS `rec_pay_date`,IF(inv.is_close_rec_payment=1,'Paid','Pending') AS `rec_pay_status`,
        prt.`id_pre_return`, prt.`pre_return_number`, prt.`pre_return_date`, prt.`pre_return_status`,
        ret_cust.`id_ret_cust`,ret_cust.`ret_cust_number`, ret_cust.`ret_cust_date`, ret_cust.`ret_cust_status`, ret_cust.`ret_cust_awb`,
        ret_request.`id_ret_request`, ret_request.`ret_request_awb`,ret_request.`ret_request_number`, ret_request.`ret_request_created_date`,ret_request.`ret_request_date`, ret_request.`ret_request_status`,
        refund.`id_bbk`, refund.`bbk_number`, refund.`bbk_created_date`, refund.`bbk_status`,
        ish.id_invoice_ship, ish.`invoice_ship_number`, 
        ish.`invoice_ship_status`, ish.`invoice_ship_date`, IFNULL(ish.invoice_ship_value,0.00) AS `invoice_ship_value`,
        '0' AS `report_mark_type`, 
        IFNULL(stt.`status`, 'Pending') AS `ol_store_status`, IFNULL(stt.status_date, sales_order_ol_shop_date) AS `ol_store_date`,
        IFNULL(stt_internal.`status`, '-') AS `ol_store_status_internal`, IFNULL(stt_internal.status_date, sales_order_ol_shop_date) AS `ol_store_date_internal`,
        so.sales_order_ol_shop_date,  so.`customer_name` , so.`shipping_name` , so.`shipping_address`, so.`shipping_phone` , so.`shipping_city` , 
        so.`shipping_post_code` , so.`shipping_region` , so.`payment_method`, so.`tracking_code`, cg.lead_time_return, '' AS view_shipping_label
        FROM tb_sales_order so
        INNER JOIN tb_sales_order_det sod ON sod.id_sales_order = so.id_sales_order
        LEFT JOIN tb_ol_promo_collection prm ON prm.id_ol_promo_collection = sod.id_ol_promo_collection
        LEFT JOIN (
            SELECT * FROM (
	            SELECT stt.id_sales_order_det, stt.`status`, stt.status_date 
	            FROM tb_sales_order_det_status stt
                WHERE stt.is_internal=2
	            ORDER BY stt.status_date DESC
            ) a
            GROUP BY a.id_sales_order_det
        ) stt ON stt.id_sales_order_det = sod.id_sales_order_det
        LEFT JOIN (
            SELECT * FROM (
	            SELECT stt.id_sales_order_det, stt.`status`, stt.status_date 
	            FROM tb_sales_order_det_status stt
                WHERE stt.is_internal=1
	            ORDER BY stt.status_date DESC
            ) a
            GROUP BY a.id_sales_order_det
        ) stt_internal ON stt_internal.id_sales_order_det = sod.id_sales_order_det
        LEFT JOIN (
            SELECT so.id_sales_order, so.sales_order_date, del.id_pl_sales_order_del, so.sales_order_number
            FROM tb_sales_order so
            INNER JOIN tb_m_comp_contact cc ON cc.id_comp_contact = so.id_store_contact_to
            INNER JOIN tb_m_comp c ON c.id_comp = cc.id_comp
            LEFT JOIN tb_pl_sales_order_del del ON del.id_sales_order = so.id_sales_order AND del.id_report_status=6 
            WHERE  so.id_report_status=6 AND so.id_prepare_status=2 AND c.id_commerce_type=2 AND ISNULL(del.id_pl_sales_order_del)
            AND (so.sales_order_date>='" + date_from_selected + "' AND so.sales_order_date<='" + date_until_selected + "')
            GROUP BY so.id_sales_order
        ) oc ON oc.id_sales_order = so.id_sales_order
        INNER JOIN tb_m_product prod ON prod.id_product = sod.id_product
        INNER JOIN tb_m_product_code prodcode ON prodcode.id_product = prod.id_product
        INNER JOIN tb_m_code_detail sz ON sz.id_code_detail = prodcode.id_code_detail
        LEFT JOIN (
           SELECT deld.id_sales_order_det, deld.id_pl_sales_order_del_det,del.id_pl_sales_order_del, del.pl_sales_order_del_number, del.pl_sales_order_del_date, del_stt.report_status 
           FROM tb_pl_sales_order_del_det deld
           INNER JOIN tb_pl_sales_order_del del ON del.id_pl_sales_order_del = deld.id_pl_sales_order_del
           INNER JOIN tb_m_comp_contact cc ON cc.id_comp_contact = del.id_store_contact_to
           INNER JOIN tb_m_comp c ON c.id_comp = cc.id_comp
           INNER JOIN tb_lookup_report_status del_stt ON del_stt.id_report_status = del.id_report_status
           WHERE del.id_report_status!=5 AND c.id_commerce_type=2
        ) del ON del.id_sales_order_det = sod.id_sales_order_det
        LEFT JOIN (
           SELECT rod.id_sales_order_det, rod.id_sales_return_order_det,
           ro.id_sales_return_order, ro.sales_return_order_number, ro.sales_return_order_date, ro_stt.report_status
           FROM tb_sales_return_order_det rod
           INNER JOIN tb_sales_return_order ro ON ro.id_sales_return_order = rod.id_sales_return_order
           INNER JOIN tb_m_comp_contact cc ON cc.id_comp_contact = ro.id_store_contact_to
           INNER JOIN tb_m_comp c ON c.id_comp = cc.id_comp
           INNER JOIN tb_lookup_report_status ro_stt ON ro_stt.id_report_status = ro.id_report_status
           WHERE ro.id_report_status!=5 AND c.id_commerce_type=2
        ) ro ON ro.id_sales_order_det = sod.id_sales_order_det
        LEFT JOIN (
           SELECT retd.id_sales_return_order_det, retd.id_sales_return_det,
           ret.id_sales_return, ret.sales_return_number, ret.sales_return_date, ret_stt.report_status 
           FROM tb_sales_return_det retd
           INNER JOIN tb_sales_return ret ON ret.id_sales_return = retd.id_sales_return
           INNER JOIN tb_lookup_report_status ret_stt ON ret_stt.id_report_status = ret.id_report_status
           INNER JOIN tb_m_comp_contact cc ON cc.id_comp_contact = ret.id_store_contact_from
           INNER JOIN tb_m_comp c ON c.id_comp = cc.id_comp
           WHERE ret.id_report_status!=5 AND c.id_commerce_type=2
        ) ret ON ret.id_sales_return_order_det = ro.id_sales_return_order_det
        LEFT JOIN (
           SELECT invd.id_pl_sales_order_del_det, invd.id_sales_pos_det,
           inv.id_sales_pos, inv.sales_pos_number, inv.sales_pos_date, inv_stt.report_status, inv.is_close_rec_payment
           FROM tb_sales_pos_det invd
           INNER JOIN tb_sales_pos inv ON inv.id_sales_pos = invd.id_sales_pos
           INNER JOIN tb_lookup_report_status inv_stt ON inv_stt.id_report_status = inv.id_report_status
           INNER JOIN tb_m_comp_contact cc ON cc.id_comp_contact = inv.id_store_contact_from
           INNER JOIN tb_m_comp c ON c.id_comp = cc.id_comp
           WHERE inv.id_report_status!=5 AND c.id_commerce_type=2
        ) inv ON inv.id_pl_sales_order_del_det = del.id_pl_sales_order_del_det
        LEFT JOIN (
           SELECT cnd.id_sales_pos_det_ref, cn.id_sales_pos,cn.sales_pos_number, cn.sales_pos_date, cn_stt.report_status
           FROM tb_sales_pos cn
           INNER JOIN tb_sales_pos_det cnd ON cnd.id_sales_pos = cn.id_sales_pos
           INNER JOIN tb_lookup_report_status cn_stt ON cn_stt.id_report_status = cn.id_report_status 
           INNER JOIN tb_m_comp_contact cc ON cc.id_comp_contact = cn.id_store_contact_from
           INNER JOIN tb_m_comp c ON c.id_comp = cc.id_comp
           WHERE cn.id_report_status!=5 AND cn.report_mark_type=118 AND c.id_commerce_type=2
           GROUP BY cnd.id_sales_pos_det_ref    
        ) cn ON cn.id_sales_pos_det_ref = inv.id_sales_pos_det
        LEFT JOIN (
          SELECT a.id_report, a.id_rec_payment, a.`number`,a.date_created, SUM(a.`value`) AS `amount`
          FROM
          (
             SELECT rd.id_report, r.id_rec_payment, r.`number`, r.date_created,rd.`value`
             FROM tb_rec_payment_det rd
             INNER JOIN tb_rec_payment r ON r.id_rec_payment = rd.id_rec_payment
             INNER JOIN tb_sales_pos p ON p.id_sales_pos = rd.id_report
             INNER JOIN tb_m_comp_contact cc ON cc.id_comp_contact = p.id_store_contact_from 
             WHERE (rd.report_mark_type=48 OR rd.report_mark_type=54 OR rd.report_mark_type=118) AND r.id_report_status=6
             ORDER BY r.id_rec_payment DESC
          ) a
          GROUP BY a.id_report
        ) rec_pay ON rec_pay.id_report = inv.id_sales_pos
        LEFT JOIN (
            SELECT rd.id_sales_order_det, r.id_ol_store_ret AS `id_pre_return`, 
            r.number AS `pre_return_number`, r.rec_date AS `pre_return_date`, stt.id_report_status, stt.report_status AS `pre_return_status`
            FROM tb_ol_store_ret_det rd
            INNER JOIN tb_ol_store_ret r ON r.id_ol_store_ret = rd.id_ol_store_ret
            INNER JOIN tb_lookup_report_status stt ON stt.id_report_status = r.id_report_status
            WHERE r.id_report_status!=5
            GROUP BY rd.id_sales_order_det
        ) prt ON prt.id_sales_order_det = sod.id_sales_order_det
        LEFT JOIN (
            SELECT rd.id_sales_order_det, c.id_ol_store_cust_ret AS `id_ret_cust`,
            c.number AS `ret_cust_number`, c.created_date AS `ret_cust_date`, stt.id_report_status, stt.report_status AS `ret_cust_status`, aw.awbill_no AS `ret_cust_awb`
            FROM tb_ol_store_cust_ret_det cd
            INNER JOIN tb_ol_store_ret_list l ON l.id_ol_store_ret_list = cd.id_ol_store_ret_list
            INNER JOIN tb_ol_store_ret_det rd ON rd.id_ol_store_ret_det = l.id_ol_store_ret_det
            INNER JOIN tb_ol_store_cust_ret c ON c.id_ol_store_cust_ret = cd.id_ol_store_cust_ret
            INNER JOIN tb_lookup_report_status stt ON stt.id_report_status = c.id_report_status
            LEFT JOIN (
                SELECT d.id_ol_store_cust_ret, m.awbill_no
                FROM tb_wh_awbill_det d
                INNER JOIN tb_wh_awbill m ON m.id_awbill = d.id_awbill
                WHERE !ISNULL(d.id_ol_store_cust_ret)
                GROUP BY d.id_ol_store_cust_ret
            ) aw ON aw.id_ol_store_cust_ret = c.id_ol_store_cust_ret
            WHERE c.id_report_status!=5
            GROUP BY rd.id_sales_order_det
        ) ret_cust ON ret_cust.id_sales_order_det = sod.id_sales_order_det
        LEFT JOIN (
            SELECT sod.id_sales_order_det,a.awbill_no,
            a.rec_by_store_date AS `del_received_date`, a.rec_by_store_person AS `del_received_by`
            FROM tb_wh_awbill a
            INNER JOIN tb_wh_awbill_det ad ON ad.id_awbill = a.id_awbill
            INNER JOIN tb_pl_sales_order_del d ON d.id_pl_sales_order_del = ad.id_pl_sales_order_del
            INNER JOIN tb_sales_order so ON so.id_sales_order = d.id_sales_order
            INNER JOIN tb_sales_order_det sod ON sod.id_sales_order = so.id_sales_order
            INNER JOIN tb_m_comp_contact cc ON cc.id_comp_contact = so.id_store_contact_to
            INNER JOIN tb_m_comp c ON c.id_comp = cc.id_comp AND c.id_commerce_type=2
            WHERE so.id_report_status=6 
            GROUP BY sod.id_sales_order_det
        ) awb_del ON awb_del.id_sales_order_det = sod.id_sales_order_det
        LEFT JOIN (
            SELECT rd.id_sales_order_det, r.id_ol_store_ret_req AS `id_ret_request`, 
            req.awbill_no_return AS `ret_request_awb`, r.ret_req_number AS `ret_request_number`, r.created_date AS `ret_request_created_date`,
            stt.report_status AS `ret_request_status`, r.ret_req_date AS `ret_request_date`
            FROM tb_ol_store_ret_req r
            INNER JOIN tb_ol_store_ret_req_det rd ON rd.id_ol_store_ret_req = r.id_ol_store_ret_req
            INNER JOIN tb_sales_order_det sod ON sod.id_sales_order_det  = rd.id_sales_order_det
            INNER JOIN tb_sales_order so ON so.id_sales_order = sod.id_sales_order
            INNER JOIN tb_m_comp_contact cc ON cc.id_comp_contact = so.id_store_contact_to
            INNER JOIN tb_m_comp c ON c.id_comp = cc.id_comp
            LEFT JOIN (
	           SELECT r.id_ol_store_ret_req, a.awbill_no AS `awbill_no_return`, a.id_store
               FROM tb_wh_awbill_det_in ad
               INNER JOIN tb_wh_awbill a ON a.id_awbill = ad.id_awbill
               INNER JOIN tb_ol_store_ret_req r ON r.id_ol_store_ret_req = ad.id_ol_store_ret_req
               WHERE r.id_report_status=6
               GROUP BY r.id_ol_store_ret_req, a.id_store
            ) req ON req.id_ol_store_ret_req = r.id_ol_store_ret_req AND req.id_store=c.id_comp
            INNER JOIN tb_lookup_report_status stt ON stt.id_report_status = r.id_report_status
            WHERE r.id_report_status=6
            GROUP BY rd.id_sales_order_det
        ) ret_request ON ret_request.id_sales_order_det = sod.id_sales_order_det
        LEFT JOIN (
            SELECT bbk.id_sales_order_det, bbk.id_pn AS `id_bbk`, bbk.number AS `bbk_number`, 
            bbk.date_created AS `bbk_created_date`,  bbk.report_status AS `bbk_status`
            FROM (
	            SELECT dd.id_sales_order_det, bk.id_pn, bk.number, bk.date_created, stt.report_status
	            FROM tb_pn bk
	            INNER JOIN tb_pn_det bkd ON bkd.id_pn = bk.id_pn
	            INNER JOIN tb_sales_pos sp ON sp.id_sales_pos = bkd.id_report
	            INNER JOIN tb_sales_pos_det spd ON spd.id_sales_pos = sp.id_sales_pos
	            INNER JOIN tb_sales_pos_det invd ON invd.id_sales_pos_det = spd.id_sales_pos_det_ref
	            INNER JOIN tb_pl_sales_order_del_det dd ON dd.id_pl_sales_order_del_det = invd.id_pl_sales_order_del_det
                INNER JOIN tb_lookup_report_status stt ON stt.id_report_status = bk.id_report_status
	            WHERE bkd.report_mark_type=118 AND bk.id_report_status!=5
	            ORDER BY bk.id_pn DESC
            ) bbk
            GROUP BY bbk.id_sales_order_det
        ) refund ON refund.id_sales_order_det = sod.id_sales_order_det
        LEFT JOIN (
            SELECT ish.id_report,ish.id_invoice_ship, ish.`number` AS `invoice_ship_number`, 
            stt.report_status AS `invoice_ship_status`, ish.created_date AS `invoice_ship_date`, ish.value AS `invoice_ship_value`
            FROM tb_invoice_ship ish
            INNER JOIN tb_lookup_report_status stt ON stt.id_report_status = ish.id_report_status
            WHERE ish.id_report_status=6 
            GROUP BY ish.id_report
        ) ish ON ish.id_report = so.id_sales_order_ol_shop
        INNER JOIN tb_m_comp_contact socc ON socc.id_comp_contact = so.id_store_contact_to
        INNER JOIN tb_m_comp c ON c.id_comp = socc.id_comp
        INNER JOIN tb_m_comp_group cg ON cg.id_comp_group = c.id_comp_group
        INNER JOIN tb_m_comp_contact wc ON wc.id_comp_contact = so.id_warehouse_contact_to
        INNER JOIN tb_m_comp w ON w.id_comp = wc.id_comp
        WHERE so.id_report_status=6  
        " + cond_date + "
        AND ISNULL(oc.id_sales_order) AND c.id_commerce_type=2 " + qcomp2 + " " + qcomp2_group + "
        HAVING 1=1 
        " + cond_having + " "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCDetail.DataSource = data
        GVDetail.BestFitColumns()
        Cursor = Cursors.Default
    End Sub

    Private Sub RepoAttachDetail_EditValueChanged(sender As Object, e As EventArgs) Handles RepoAttachDetail.EditValueChanged
        Cursor = Cursors.WaitCursor
        Dim LE As DevExpress.XtraEditors.LookUpEdit = CType(sender, DevExpress.XtraEditors.LookUpEdit)
        Dim val As String = LE.EditValue.ToString
        Dim id As String = ""
        'Dim id_arr() As String
        Dim cond As String = ""
        If val <> "0" Then
            If val = "39" Then
                id = GVDetail.GetFocusedRowCellValue("id_order").ToString
            ElseIf val = "43" Then
                id = GVDetail.GetFocusedRowCellValue("id_del").ToString
            ElseIf val = "48" Then
                id = GVDetail.GetFocusedRowCellValue("id_inv").ToString
            ElseIf val = "118" Then
                id = GVDetail.GetFocusedRowCellValue("id_cn").ToString
            ElseIf val = "119" Then
                id = GVDetail.GetFocusedRowCellValue("id_ro").ToString
            ElseIf val = "120" Then
                id = GVDetail.GetFocusedRowCellValue("id_ret").ToString
            ElseIf val = "162" Then
                id = GVDetail.GetFocusedRowCellValue("id_rec_pay").ToString
            ElseIf val = "162-1" Then
                id = GVDetail.GetFocusedRowCellValue("id_ret_pay").ToString
            End If

            'id_arr = id.Split("#")

            'For i = 0 To id_arr.Length - 1
            '    If i = 0 Then
            '        FormDocumentUpload.id_report = id_arr(i).ToString
            '    Else
            '        cond += "OR id_report='" + id_arr(i).ToString + "' "
            '    End If
            'Next

            FormDocumentUpload.is_view = "1"
            FormDocumentUpload.id_report = id
            FormDocumentUpload.report_mark_type = val
            FormDocumentUpload.cond = cond
            FormDocumentUpload.ShowDialog()
            LE.ItemIndex = 0
        End If
        Cursor = Cursors.Default
    End Sub

    Private Sub RepoBtnDetailSO_Click(sender As Object, e As EventArgs) Handles RepoBtnDetailSO.Click
        MsgBox("a")

    End Sub

    Private Sub RepoBtnDetailDel_Click(sender As Object, e As EventArgs) Handles RepoBtnDetailDel.Click
        If GVDetail.RowCount > 0 And GVDetail.FocusedRowHandle >= 0 And GVDetail.GetFocusedRowCellValue("id_del") > 0 Then
            Cursor = Cursors.WaitCursor
            Dim m As New ClassShowPopUp
            m.report_mark_type = "43"
            m.id_report = GVDetail.GetFocusedRowCellValue("id_del").ToString.ToUpper
            m.show()
            Cursor = Cursors.Default
        End If
    End Sub

    Private Sub RepoBtnDetailRO_Click(sender As Object, e As EventArgs) Handles RepoBtnDetailRO.Click
        If GVDetail.RowCount > 0 And GVDetail.FocusedRowHandle >= 0 And GVDetail.GetFocusedRowCellValue("id_ro") > 0 Then
            Cursor = Cursors.WaitCursor
            Dim m As New ClassShowPopUp
            m.report_mark_type = "119"
            m.id_report = GVDetail.GetFocusedRowCellValue("id_ro").ToString.ToUpper
            m.show()
            Cursor = Cursors.Default
        End If
    End Sub

    Private Sub RepoBtnDetailRet_Click(sender As Object, e As EventArgs) Handles RepoBtnDetailRet.Click
        If GVDetail.RowCount > 0 And GVDetail.FocusedRowHandle >= 0 And GVDetail.GetFocusedRowCellValue("id_ret") > 0 Then
            Cursor = Cursors.WaitCursor
            Dim m As New ClassShowPopUp
            m.report_mark_type = "120"
            m.id_report = GVDetail.GetFocusedRowCellValue("id_ret").ToString.ToUpper
            m.show()
            Cursor = Cursors.Default
        End If
    End Sub

    Private Sub RepoBtnDetailRecPayment_Click(sender As Object, e As EventArgs) Handles RepoBtnDetailRecPayment.Click
        If GVDetail.RowCount > 0 And GVDetail.FocusedRowHandle >= 0 And GVDetail.GetFocusedRowCellValue("id_rec_pay") > 0 Then
            Cursor = Cursors.WaitCursor
            Dim m As New ClassShowPopUp
            m.report_mark_type = "162"
            m.id_report = GVDetail.GetFocusedRowCellValue("id_rec_pay").ToString.ToUpper
            m.show()
            Cursor = Cursors.Default
        End If
    End Sub

    Private Sub RepoBtnRetPayment_Click(sender As Object, e As EventArgs) Handles RepoBtnRetPayment.Click
        If GVDetail.RowCount > 0 And GVDetail.FocusedRowHandle >= 0 And GVDetail.GetFocusedRowCellValue("id_ret_pay") > 0 Then
            Cursor = Cursors.WaitCursor
            Dim m As New ClassShowPopUp
            m.report_mark_type = "162"
            m.id_report = GVDetail.GetFocusedRowCellValue("id_ret_pay").ToString.ToUpper
            m.show()
            Cursor = Cursors.Default
        End If
    End Sub

    Private Sub BtnTrackOrder_Click(sender As Object, e As EventArgs) Handles BtnTrackOrder.Click
        Cursor = Cursors.WaitCursor
        FormOLStoreTracking.ShowDialog()
        Cursor = Cursors.Default
    End Sub

    Private Sub RepoBtnDetailInv_Click(sender As Object, e As EventArgs) Handles RepoBtnDetailInv.Click
        If GVDetail.RowCount > 0 And GVDetail.FocusedRowHandle >= 0 And GVDetail.GetFocusedRowCellValue("id_inv") > 0 Then
            Cursor = Cursors.WaitCursor
            Dim m As New ClassShowPopUp
            m.report_mark_type = "48"
            m.id_report = GVDetail.GetFocusedRowCellValue("id_inv").ToString
            m.show()
            Cursor = Cursors.Default
        End If
    End Sub

    Private Sub RepoBtnDetailCN_Click(sender As Object, e As EventArgs) Handles RepoBtnDetailCN.Click
        If GVDetail.RowCount > 0 And GVDetail.FocusedRowHandle >= 0 And GVDetail.GetFocusedRowCellValue("id_cn") > 0 Then
            Cursor = Cursors.WaitCursor
            Dim m As New ClassShowPopUp
            m.report_mark_type = "118"
            m.id_report = GVDetail.GetFocusedRowCellValue("id_cn").ToString
            m.show()
            Cursor = Cursors.Default
        End If
    End Sub

    Private Sub RepoBtnDetailOrder_Click(sender As Object, e As EventArgs) Handles RepoBtnDetailOrder.Click
        If GVDetail.RowCount > 0 And GVDetail.FocusedRowHandle >= 0 And GVDetail.GetFocusedRowCellValue("id_order").ToString > 0 Then
            Cursor = Cursors.WaitCursor
            FormSalesOrderDet.action = "upd"
            FormSalesOrderDet.id_sales_order = GVDetail.GetFocusedRowCellValue("id_order").ToString.ToUpper
            FormSalesOrderDet.ShowDialog()
            Cursor = Cursors.Default
        End If
    End Sub

    Private Sub RepoBtnDetailPickup_Click(sender As Object, e As EventArgs) Handles RepoBtnDetailPickup.Click
        If GVDetail.RowCount > 0 And GVDetail.FocusedRowHandle >= 0 And GVDetail.GetFocusedRowCellValue("id_del") > 0 Then
            Cursor = Cursors.WaitCursor
            'cek bukti pickup
            Dim query As String = "SELECT pd.id_pickup 
            FROM tb_del_pickup_det pd 
            INNER JOIN tb_del_pickup p ON p.id_pickup = pd.id_pickup
            WHERE pd.id_pl_sales_order_del=" + GVDetail.GetFocusedRowCellValue("id_del").ToString + " AND p.id_report_status=6 "
            Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
            If data.Rows.Count > 0 Then
                Dim m As New ClassShowPopUp
                m.report_mark_type = "217"
                m.id_report = data.Rows(0)("id_pickup").ToString
                FormBuktiPickupDet.is_view_attachment = "1"
                m.show()
            Else
                stopCustom("Attachment not found")
            End If
            Cursor = Cursors.Default
        End If
    End Sub

    Private Sub LabelControl5_Click(sender As Object, e As EventArgs) Handles LabelControl5.Click

    End Sub

    Private Sub BtnViewUpdated_Click(sender As Object, e As EventArgs) Handles BtnViewUpdated.Click
        viewRmtDetail()
        viewDetail("2")
    End Sub

    Private Sub SLECompGroup_EditValueChanged(sender As Object, e As EventArgs) Handles SLECompGroup.EditValueChanged
        viewCompDetail()
    End Sub

    Private Sub RepoBtnDetailPreReturn_ButtonClick(sender As Object, e As DevExpress.XtraEditors.Controls.ButtonPressedEventArgs) Handles RepoBtnDetailPreReturn.ButtonClick
        If GVDetail.RowCount > 0 And GVDetail.FocusedRowHandle >= 0 And GVDetail.GetFocusedRowCellValue("id_pre_return").ToString > 0 Then
            Cursor = Cursors.WaitCursor
            Dim m As New ClassShowPopUp()
            m.report_mark_type = "243"
            m.id_report = GVDetail.GetFocusedRowCellValue("id_pre_return").ToString
            m.show()
            Cursor = Cursors.Default
        End If
    End Sub

    Private Sub RepoBtnRetCust_ButtonClick(sender As Object, e As DevExpress.XtraEditors.Controls.ButtonPressedEventArgs) Handles RepoBtnRetCust.ButtonClick
        If GVDetail.RowCount > 0 And GVDetail.FocusedRowHandle >= 0 And GVDetail.GetFocusedRowCellValue("id_ret_cust").ToString > 0 Then
            Cursor = Cursors.WaitCursor
            Dim m As New ClassShowPopUp()
            m.report_mark_type = "245"
            m.id_report = GVDetail.GetFocusedRowCellValue("id_ret_cust").ToString
            m.show()
            Cursor = Cursors.Default
        End If
    End Sub

    Private Sub RepoBtnDetailRetRequest_ButtonClick(sender As Object, e As DevExpress.XtraEditors.Controls.ButtonPressedEventArgs) Handles RepoBtnDetailRetRequest.ButtonClick
        '246
        If GVDetail.RowCount > 0 And GVDetail.FocusedRowHandle >= 0 And GVDetail.GetFocusedRowCellValue("id_ret_request").ToString > 0 Then
            Cursor = Cursors.WaitCursor
            Dim m As New ClassShowPopUp()
            m.report_mark_type = "246"
            m.id_report = GVDetail.GetFocusedRowCellValue("id_ret_request").ToString
            m.show()
            Cursor = Cursors.Default
        End If
    End Sub

    Private Sub RepoBtnRefund_ButtonClick(sender As Object, e As DevExpress.XtraEditors.Controls.ButtonPressedEventArgs) Handles RepoBtnRefund.ButtonClick
        If GVDetail.RowCount > 0 And GVDetail.FocusedRowHandle >= 0 And GVDetail.GetFocusedRowCellValue("id_bbk").ToString > 0 Then
            Cursor = Cursors.WaitCursor
            Dim m As New ClassShowPopUp()
            m.report_mark_type = "159"
            m.id_report = GVDetail.GetFocusedRowCellValue("id_bbk").ToString
            m.show()
            Cursor = Cursors.Default
        End If
    End Sub

    Private Sub LinkProposedPromo_Click(sender As Object, e As EventArgs) Handles LinkProposedPromo.Click
        If GVDetail.RowCount > 0 And GVDetail.FocusedRowHandle >= 0 Then
            Cursor = Cursors.WaitCursor
            Dim id_ol_promo_collection As String = ""
            Try
                id_ol_promo_collection = GVDetail.GetFocusedRowCellValue("id_ol_promo_collection").ToString
            Catch ex As Exception
            End Try
            Dim s As New ClassShowPopUp
            s.id_report = id_ol_promo_collection
            s.report_mark_type = "250"
            s.show()
            Cursor = Cursors.Default
        End If
    End Sub

    Private Sub BtnViewPromo_Click(sender As Object, e As EventArgs) Handles BtnViewPromo.Click
        viewPromoList()
    End Sub

    Sub viewPromoList()
        Cursor = Cursors.WaitCursor

        'filter promo
        Dim id_ol_promo_collection As String = SLEPromo.EditValue.ToString
        Dim cond_promo As String = ""
        If id_ol_promo_collection <> "0" Then
            cond_promo = "AND p.id_ol_promo_collection=" + id_ol_promo_collection + " "
        End If

        Dim query As String = "SELECT prod.id_product, d.id_design, prod.product_full_code, d.design_code, d.design_display_name AS `name`,cd.code_detail_name AS `size`, 
        sod.sales_order_det_qty, sod.design_price, (sod.sales_order_det_qty * sod.design_price) AS `amount`, sod.discount, ((SELECT amount) - sod.discount)  AS `nett`,
        p.id_ol_promo_collection,prm.promo, p.`number` AS `proposed_number`, p.start_period, p.end_period,
        so.id_sales_order_ol_shop, so.sales_order_ol_shop_number, so.sales_order_ol_shop_date, 
        so.id_sales_order, so.sales_order_number, so.sales_order_date, so.customer_name, so.shipping_name, so.shipping_address, so.shipping_city, so.shipping_region, so.shipping_phone, sod.discount_code
        FROM tb_sales_order_det sod
        INNER JOIN tb_sales_order so ON so.id_sales_order = sod.id_sales_order
        LEFT JOIN tb_ol_promo_collection_sku pd ON pd.id_ol_promo_collection_sku = sod.id_ol_promo_collection_sku
        LEFT JOIN tb_ol_promo_collection p ON p.id_ol_promo_collection = sod.id_ol_promo_collection
        INNER JOIN tb_promo prm ON prm.id_promo = p.id_promo
        INNER JOIN tb_m_product prod ON prod.id_product = sod.id_product
        INNER JOIN tb_m_product_code prod_code ON prod_code.id_product = prod.id_product
        INNER JOIN tb_m_code_detail cd ON cd.id_code_detail = prod_code.id_code_detail
        INNER JOIN tb_m_design d ON d.id_design = prod.id_design
        WHERE so.id_report_status=6 AND !ISNULL(sod.id_ol_promo_collection)
        " + cond_promo + "
        ORDER BY so.id_sales_order_ol_shop "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCPromo.DataSource = data
        Cursor = Cursors.Default
    End Sub

    Private Sub LinkSO_Click(sender As Object, e As EventArgs) Handles LinkSO.Click
        If GVPromo.RowCount > 0 And GVPromo.FocusedRowHandle >= 0 Then
            Dim m As New ClassShowPopUp()
            m.id_report = GVPromo.GetFocusedRowCellValue("id_sales_order").ToString
            m.report_mark_type = "39"
            m.show()
        End If
    End Sub

    Private Sub LinkPromoPropose_Click(sender As Object, e As EventArgs) Handles LinkPromoPropose.Click
        If GVPromo.RowCount > 0 And GVPromo.FocusedRowHandle >= 0 Then
            Dim m As New ClassShowPopUp()
            m.id_report = GVPromo.GetFocusedRowCellValue("id_ol_promo_collection").ToString
            m.report_mark_type = "250"
            m.show()
        End If
    End Sub

    Private Sub SLEPromo_EditValueChanged(sender As Object, e As EventArgs) Handles SLEPromo.EditValueChanged
        GCPromo.DataSource = Nothing
    End Sub

    Sub exportToXLS(ByVal path_par As String, ByVal sheet_name_par As String, ByVal gc_par As DevExpress.XtraGrid.GridControl)
        Cursor = Cursors.WaitCursor
        Dim path As String = path_par

        ' Customize export options 
        CType(gc_par.MainView, DevExpress.XtraGrid.Views.Grid.GridView).OptionsPrint.PrintHeader = True
        Dim advOptions As DevExpress.XtraPrinting.XlsxExportOptionsEx = New DevExpress.XtraPrinting.XlsxExportOptionsEx()
        advOptions.AllowSortingAndFiltering = DevExpress.Utils.DefaultBoolean.False
        advOptions.ShowGridLines = DevExpress.Utils.DefaultBoolean.False
        advOptions.AllowGrouping = DevExpress.Utils.DefaultBoolean.False
        advOptions.ShowTotalSummaries = DevExpress.Utils.DefaultBoolean.False
        advOptions.SheetName = sheet_name_par
        advOptions.ExportType = DevExpress.Export.ExportType.DataAware

        Try
            gc_par.ExportToXlsx(path, advOptions)
            Process.Start(path)
            ' Open the created XLSX file with the default application. 
        Catch ex As Exception
            stopCustom(ex.ToString)
        End Try
        Cursor = Cursors.Default
    End Sub

    Private Sub BtnExportToXLS_Click(sender As Object, e As EventArgs) Handles BtnExportToXLS.Click
        If GVDetail.RowCount > 0 Then
            Cursor = Cursors.WaitCursor
            Dim path As String = Application.StartupPath & "\download\"
            'create directory if not exist
            If Not IO.Directory.Exists(path) Then
                System.IO.Directory.CreateDirectory(path)
            End If
            path = path + "ol_store_report_detail.xlsx"
            exportToXLS(path, "ol_store_report_detail", GCDetail)
            Cursor = Cursors.Default
        End If
    End Sub

    Private Sub BtnExportToXLSPromo_Click(sender As Object, e As EventArgs) Handles BtnExportToXLSPromo.Click
        If GVPromo.RowCount > 0 Then
            Cursor = Cursors.WaitCursor
            Dim path As String = Application.StartupPath & "\download\"
            'create directory if not exist
            If Not IO.Directory.Exists(path) Then
                System.IO.Directory.CreateDirectory(path)
            End If
            path = path + "ol_store_report_prm.xlsx"
            exportToXLS(path, "ol_store_report_prm", GCPromo)
            Cursor = Cursors.Default
        End If
    End Sub

    Private Sub RepoBtnInvoiceShip_Click(sender As Object, e As EventArgs) Handles RepoBtnInvoiceShip.Click
        If GVDetail.RowCount > 0 And GVDetail.FocusedRowHandle >= 0 Then
            Dim m As New ClassShowPopUp()
            Dim id As String = GVDetail.GetFocusedRowCellValue("id_invoice_ship").ToString
            m.id_report = id
            m.report_mark_type = "249"
            m.show()
        End If
    End Sub

    Sub viewDetailPromo()
        Cursor = Cursors.WaitCursor
        Dim id_promo As String = SLEPromoDetail.EditValue.ToString
        Dim query As String = "SELECT pd.id_ol_promo_collection_sku, pd.id_ol_promo_collection, 
        n.nomer_urut,prod.id_design, d.design_code AS `code`, d.design_display_name AS `name`, pd.design_price,
        SUBSTRING(prod.product_full_code, 10, 1) AS `size_type`,
        IFNULL(SUM(CASE WHEN SUBSTRING(cd.code,2,1)='1' THEN pd.qty END),0) AS `qty1`,
        IFNULL(SUM(CASE WHEN SUBSTRING(cd.code,2,1)='2' THEN pd.qty END),0) AS `qty2`,
        IFNULL(SUM(CASE WHEN SUBSTRING(cd.code,2,1)='3' THEN pd.qty END),0) AS `qty3`,
        IFNULL(SUM(CASE WHEN SUBSTRING(cd.code,2,1)='4' THEN pd.qty END),0) AS `qty4`,
        IFNULL(SUM(CASE WHEN SUBSTRING(cd.code,2,1)='5' THEN pd.qty END),0) AS `qty5`,
        IFNULL(SUM(CASE WHEN SUBSTRING(cd.code,2,1)='6' THEN pd.qty END),0) AS `qty6`,
        IFNULL(SUM(CASE WHEN SUBSTRING(cd.code,2,1)='7' THEN pd.qty END),0) AS `qty7`,
        IFNULL(SUM(CASE WHEN SUBSTRING(cd.code,2,1)='8' THEN pd.qty END),0) AS `qty8`,
        IFNULL(SUM(CASE WHEN SUBSTRING(cd.code,2,1)='9' THEN pd.qty END),0) AS `qty9`,
        IFNULL(SUM(CASE WHEN SUBSTRING(cd.code,2,1)='0' THEN pd.qty END),0) AS `qty0`,
        SUM(pd.qty) AS `qty`,
        SUM(pd.qty) * pd.design_price AS `amount`,
        IFNULL(sal.qty1,0) AS `sal_qty1`,
        IFNULL(sal.qty2,0) AS `sal_qty2`,
        IFNULL(sal.qty3,0) AS `sal_qty3`,
        IFNULL(sal.qty4,0) AS `sal_qty4`,
        IFNULL(sal.qty5,0) AS `sal_qty5`,
        IFNULL(sal.qty6,0) AS `sal_qty6`,
        IFNULL(sal.qty7,0) AS `sal_qty7`,
        IFNULL(sal.qty8,0) AS `sal_qty8`,
        IFNULL(sal.qty9,0) AS `sal_qty9`,
        IFNULL(sal.qty0,0) AS `sal_qty0`,
        IFNULL(sal.qty,0) AS `sal_qty`,
        IFNULL(sal.qty,0) * pd.design_price AS `sal_amount`,
        IFNULL(rep.rep_qty1,0) AS `rep_qty1`,
        IFNULL(rep.rep_qty2,0) AS `rep_qty2`,
        IFNULL(rep.rep_qty3,0) AS `rep_qty3`,
        IFNULL(rep.rep_qty4,0) AS `rep_qty4`,
        IFNULL(rep.rep_qty5,0) AS `rep_qty5`,
        IFNULL(rep.rep_qty6,0) AS `rep_qty6`,
        IFNULL(rep.rep_qty7,0) AS `rep_qty7`,
        IFNULL(rep.rep_qty8,0) AS `rep_qty8`,
        IFNULL(rep.rep_qty9,0) AS `rep_qty9`,
        IFNULL(rep.rep_qty0,0) AS `rep_qty0`,
        IFNULL(rep.rep_qty,0) AS `rep_qty`,
        IFNULL(rep.rep_qty,0) * pd.design_price AS `rep_amount`,
        IFNULL(SUM(CASE WHEN SUBSTRING(cd.code,2,1)='1' THEN pd.qty END),0)-IFNULL(sal.qty1,0)+IFNULL(rep.rep_qty1,0) AS `bal_qty1`,
        IFNULL(SUM(CASE WHEN SUBSTRING(cd.code,2,1)='2' THEN pd.qty END),0)-IFNULL(sal.qty2,0)+IFNULL(rep.rep_qty2,0) AS `bal_qty2`,
        IFNULL(SUM(CASE WHEN SUBSTRING(cd.code,2,1)='3' THEN pd.qty END),0)-IFNULL(sal.qty3,0)+IFNULL(rep.rep_qty3,0) AS `bal_qty3`,
        IFNULL(SUM(CASE WHEN SUBSTRING(cd.code,2,1)='4' THEN pd.qty END),0)-IFNULL(sal.qty4,0)+IFNULL(rep.rep_qty4,0) AS `bal_qty4`,
        IFNULL(SUM(CASE WHEN SUBSTRING(cd.code,2,1)='5' THEN pd.qty END),0)-IFNULL(sal.qty5,0)+IFNULL(rep.rep_qty5,0) AS `bal_qty5`,
        IFNULL(SUM(CASE WHEN SUBSTRING(cd.code,2,1)='6' THEN pd.qty END),0)-IFNULL(sal.qty6,0)+IFNULL(rep.rep_qty6,0) AS `bal_qty6`,
        IFNULL(SUM(CASE WHEN SUBSTRING(cd.code,2,1)='7' THEN pd.qty END),0)-IFNULL(sal.qty7,0)+IFNULL(rep.rep_qty7,0) AS `bal_qty7`,
        IFNULL(SUM(CASE WHEN SUBSTRING(cd.code,2,1)='8' THEN pd.qty END),0)-IFNULL(sal.qty8,0)+IFNULL(rep.rep_qty8,0) AS `bal_qty8`,
        IFNULL(SUM(CASE WHEN SUBSTRING(cd.code,2,1)='9' THEN pd.qty END),0)-IFNULL(sal.qty9,0)+IFNULL(rep.rep_qty9,0) AS `bal_qty9`,
        IFNULL(SUM(CASE WHEN SUBSTRING(cd.code,2,1)='0' THEN pd.qty END),0)-IFNULL(sal.qty0,0)+IFNULL(rep.rep_qty0,0) AS `bal_qty0`,
        SUM(pd.qty)-IFNULL(sal.qty,0)+IFNULL(rep.rep_qty,0) AS `bal_qty`,
        (SUM(pd.qty)-IFNULL(sal.qty,0)+IFNULL(rep.rep_qty,0)) * pd.design_price AS `bal_amount`,
        pd.id_prod_shopify, pd.current_tag, pd.design_price, design_price_type AS `price_type`
        FROM tb_ol_promo_collection_sku pd
        INNER JOIN tb_m_product prod ON prod.id_product = pd.id_product
        INNER JOIN tb_m_design d ON d.id_design = prod.id_design
        INNER JOIN tb_m_product_code prod_code ON prod_code.id_product = prod.id_product
        INNER JOIN tb_m_code_detail cd ON cd.id_code_detail = prod_code.id_code_detail
        LEFT JOIN tb_m_design_price prc ON prc.id_design_price = pd.id_design_price
        LEFT JOIN tb_lookup_design_price_type pt ON pt.id_design_price_type = prc.id_design_price_type 
        INNER JOIN (
          SELECT @nomer:=@nomer+1 AS `nomer_urut`,a.id_design FROM (
             SELECT d.id_design
             FROM tb_ol_promo_collection_sku pd
             INNER JOIN tb_m_product prod ON prod.id_product = pd.id_product
             INNER JOIN tb_m_design d ON d.id_design = prod.id_design
             WHERE pd.id_ol_promo_collection=" + id_promo + "
             GROUP BY prod.id_design
             ORDER BY d.design_display_name ASC 
          ) a
          JOIN (SELECT @nomer:=0 AS `nox`) AS `n`
        ) n ON n.id_design = prod.id_design
        LEFT JOIN (
	        SELECT d.id_design,  SUBSTRING(prod.product_full_code, 10, 1) AS `size_type`,
	        IFNULL(SUM(CASE WHEN SUBSTRING(cd.code,2,1)='1' THEN spd.sales_pos_det_qty END),0) AS `qty1`,
	        IFNULL(SUM(CASE WHEN SUBSTRING(cd.code,2,1)='2' THEN spd.sales_pos_det_qty END),0) AS `qty2`,
	        IFNULL(SUM(CASE WHEN SUBSTRING(cd.code,2,1)='3' THEN spd.sales_pos_det_qty END),0) AS `qty3`,
	        IFNULL(SUM(CASE WHEN SUBSTRING(cd.code,2,1)='4' THEN spd.sales_pos_det_qty END),0) AS `qty4`,
	        IFNULL(SUM(CASE WHEN SUBSTRING(cd.code,2,1)='5' THEN spd.sales_pos_det_qty END),0) AS `qty5`,
	        IFNULL(SUM(CASE WHEN SUBSTRING(cd.code,2,1)='6' THEN spd.sales_pos_det_qty END),0) AS `qty6`,
	        IFNULL(SUM(CASE WHEN SUBSTRING(cd.code,2,1)='7' THEN spd.sales_pos_det_qty END),0) AS `qty7`,
	        IFNULL(SUM(CASE WHEN SUBSTRING(cd.code,2,1)='8' THEN spd.sales_pos_det_qty END),0) AS `qty8`,
	        IFNULL(SUM(CASE WHEN SUBSTRING(cd.code,2,1)='9' THEN spd.sales_pos_det_qty END),0) AS `qty9`,
	        IFNULL(SUM(CASE WHEN SUBSTRING(cd.code,2,1)='0' THEN spd.sales_pos_det_qty END),0) AS `qty0`,
	        SUM(spd.sales_pos_det_qty) AS `qty`
	        FROM tb_sales_pos sp
	        INNER JOIN tb_sales_pos_det spd ON spd.id_sales_pos = sp.id_sales_pos
	        INNER JOIN tb_pl_sales_order_del_det dd ON dd.id_pl_sales_order_del_det = spd.id_pl_sales_order_del_det
	        INNER JOIN tb_sales_order_det sod ON sod.id_sales_order_det = dd.id_sales_order_det
	        INNER JOIN tb_ol_promo_collection_sku pd ON pd.id_ol_promo_collection_sku = sod.id_ol_promo_collection_sku AND pd.id_ol_promo_collection=" + id_promo + "
	        INNER JOIN tb_m_product prod ON prod.id_product = spd.id_product
	        INNER JOIN tb_m_design d ON d.id_design = prod.id_design
	        INNER JOIN tb_m_product_code prod_code ON prod_code.id_product = prod.id_product
	        INNER JOIN tb_m_code_detail cd ON cd.id_code_detail = prod_code.id_code_detail
	        WHERE sp.id_report_status=6
	        GROUP BY d.id_design, SUBSTRING(prod.product_full_code, 10, 1)
        ) sal ON sal.id_design = d.id_design AND sal.size_type = SUBSTRING(prod.product_full_code, 10, 1)
        LEFT JOIN (
	        SELECT d.id_design,  SUBSTRING(prod.product_full_code, 10, 1) AS `size_type`,
	        IFNULL(SUM(CASE WHEN SUBSTRING(cd.code,2,1)='1' THEN sod.sales_order_det_qty END),0) AS `rep_qty1`,
	        IFNULL(SUM(CASE WHEN SUBSTRING(cd.code,2,1)='2' THEN sod.sales_order_det_qty END),0) AS `rep_qty2`,
	        IFNULL(SUM(CASE WHEN SUBSTRING(cd.code,2,1)='3' THEN sod.sales_order_det_qty END),0) AS `rep_qty3`,
	        IFNULL(SUM(CASE WHEN SUBSTRING(cd.code,2,1)='4' THEN sod.sales_order_det_qty END),0) AS `rep_qty4`,
	        IFNULL(SUM(CASE WHEN SUBSTRING(cd.code,2,1)='5' THEN sod.sales_order_det_qty END),0) AS `rep_qty5`,
	        IFNULL(SUM(CASE WHEN SUBSTRING(cd.code,2,1)='6' THEN sod.sales_order_det_qty END),0) AS `rep_qty6`,
	        IFNULL(SUM(CASE WHEN SUBSTRING(cd.code,2,1)='7' THEN sod.sales_order_det_qty END),0) AS `rep_qty7`,
	        IFNULL(SUM(CASE WHEN SUBSTRING(cd.code,2,1)='8' THEN sod.sales_order_det_qty END),0) AS `rep_qty8`,
	        IFNULL(SUM(CASE WHEN SUBSTRING(cd.code,2,1)='9' THEN sod.sales_order_det_qty END),0) AS `rep_qty9`,
	        IFNULL(SUM(CASE WHEN SUBSTRING(cd.code,2,1)='0' THEN sod.sales_order_det_qty END),0) AS `rep_qty0`,
	        SUM(sod.sales_order_det_qty) AS `rep_qty`
	        FROM tb_sales_order so
	        INNER JOIN tb_sales_order_det sod ON sod.id_sales_order = so.id_sales_order
	        INNER JOIN tb_ol_promo_collection_sku pd ON pd.id_ol_promo_collection_sku = sod.id_ol_promo_collection_sku_replace
	        INNER JOIN tb_m_product prod ON prod.id_product = sod.id_product
	        INNER JOIN tb_m_design d ON d.id_design = prod.id_design
	        INNER JOIN tb_m_product_code prod_code ON prod_code.id_product = prod.id_product
	        INNER JOIN tb_m_code_detail cd ON cd.id_code_detail = prod_code.id_code_detail
	        WHERE so.id_report_status=6 AND !ISNULL(sod.id_ol_promo_collection_sku_replace) AND pd.id_ol_promo_collection=" + id_promo + "
	        GROUP BY d.id_design, SUBSTRING(prod.product_full_code, 10, 1)
        ) rep ON rep.id_design = d.id_design AND rep.size_type = SUBSTRING(prod.product_full_code, 10, 1)
        WHERE pd.id_ol_promo_collection=" + id_promo + "
        GROUP BY d.id_design, SUBSTRING(prod.product_full_code, 10, 1)
        ORDER BY d.design_display_name ASC "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCPromoDetail.DataSource = data
        Cursor = Cursors.Default
    End Sub

    Private Sub BtnExportToXLSPromoDetail_Click(sender As Object, e As EventArgs) Handles BtnExportToXLSPromoDetail.Click
        If GVPromoDetail.RowCount > 0 Then
            Cursor = Cursors.WaitCursor
            'column option creating and saving the view's layout to a new memory stream 
            Dim str As System.IO.Stream
            str = New System.IO.MemoryStream()
            GVPromoDetail.SaveLayoutToStream(str, DevExpress.Utils.OptionsLayoutBase.FullLayout)
            str.Seek(0, System.IO.SeekOrigin.Begin)
            For i As Integer = 0 To GVPromoDetail.Columns.Count - 1
                Try
                    If GVPromoDetail.Columns(i).OwnerBand.ToString = "PROPOSED" Or GVPromoDetail.Columns(i).OwnerBand.ToString = "SALES" Or GVPromoDetail.Columns(i).OwnerBand.ToString = "REPLACE" Or GVPromoDetail.Columns(i).OwnerBand.ToString = "BALANCE" Then
                        GVPromoDetail.Columns(i).Caption = GVPromoDetail.Columns(i).Caption.ToString.Replace(System.Environment.NewLine, " / ")
                    End If
                Catch ex As Exception
                End Try
            Next

            Dim path As String = Application.StartupPath & "\download\"
            'create directory if not exist
            If Not IO.Directory.Exists(path) Then
                System.IO.Directory.CreateDirectory(path)
            End If
            path = path + "ol_store_report_prm_detail.xlsx"
            exportToXLS(path, "ol_store_report_prm_detail", GCPromoDetail)

            'restore column opt
            GVPromoDetail.RestoreLayoutFromStream(str, DevExpress.Utils.OptionsLayoutBase.FullLayout)
            str.Seek(0, System.IO.SeekOrigin.Begin)
            Cursor = Cursors.Default
        End If
    End Sub

    Private Sub BtnViewPromoDetail_Click(sender As Object, e As EventArgs) Handles BtnViewPromoDetail.Click
        viewDetailPromo()
    End Sub

    Private Sub RepoBtnViewShippingLabel_Click(sender As Object, e As EventArgs) Handles RepoBtnViewShippingLabel.Click
        Cursor = Cursors.WaitCursor

        'check store
        Dim id_sod As String = GVDetail.GetFocusedRowCellValue("id_order").ToString

        Dim id_cg As String = execute_query("
            SELECT cm.id_comp_group
            FROM tb_sales_order AS so
            LEFT JOIN tb_m_comp_contact AS ct ON so.id_store_contact_to = ct.id_comp_contact
            LEFT JOIN tb_m_comp AS cm ON ct.id_comp = cm.id_comp
            WHERE so.id_sales_order = " + id_sod + "
        ", 0, True, "", "", "", "")

        If id_cg = "75" Then
            FormSalesOrderShippingLabelPdf.ol_store = "blibli"
            FormSalesOrderShippingLabelPdf.order_id = GVDetail.GetFocusedRowCellValue("ol_store_id").ToString

            FormSalesOrderShippingLabelPdf.ShowDialog()
        ElseIf id_cg = "64" Then
            FormSalesOrderShippingLabelPdf.ol_store = "zalora"
            FormSalesOrderShippingLabelPdf.order_id = GVDetail.GetFocusedRowCellValue("item_id").ToString

            FormSalesOrderShippingLabelPdf.ShowDialog()
        Else
            stopCustom("Not found.")
        End If

        Cursor = Cursors.Default
    End Sub

    Private Sub BtnViewExpiredOrder_Click(sender As Object, e As EventArgs) Handles BtnViewExpiredOrder.Click
        viewExpiredOrder(1)
    End Sub

    Sub viewExpiredOrder(ByVal id_type As String)
        Cursor = Cursors.WaitCursor
        'Prepare paramater date
        Dim cond_date As String = ""
        Dim date_from_selected As String = "0000-01-01"
        Dim date_until_selected As String = "9999-01-01"
        Try
            date_from_selected = DateTime.Parse(DEExFrom.EditValue.ToString).ToString("yyyy-MM-dd")
        Catch ex As Exception
        End Try
        Try
            date_until_selected = DateTime.Parse(DEExUntil.EditValue.ToString).ToString("yyyy-MM-dd")
        Catch ex As Exception
        End Try
        Dim par_date As String = ""
        If id_type = "1" Then
            par_date = "f.order_date>='" + date_from_selected + "' AND f.order_date<='" + date_until_selected + "'"
        Else
            par_date = "DATE(f.input_date)>='" + date_from_selected + "' AND DATE(f.input_date)<='" + date_until_selected + "'"
        End If
        Dim query As String = "SELECT f.id, f.schedule_time, f.checkout_id, f.order_date, f.order_number, f.customer_name, SUM(f.quantity) AS `total_qty_order`,
        f.input_date, f.process_date, f.error_process,TIMESTAMPDIFF(MINUTE,f.order_date,f.schedule_time) AS `diff`
        FROM tb_ol_store_order_fail f 
        WHERE (" + par_date + ")
        GROUP BY f.id
        ORDER BY f.id ASC "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCExpiredOrder.DataSource = data
        GVExpiredOrder.BestFitColumns()
        Cursor = Cursors.Default
    End Sub

    Private Sub BtnExpiredExportToXLS_Click(sender As Object, e As EventArgs) Handles BtnExpiredExportToXLS.Click
        If GVExpiredOrder.RowCount > 0 Then
            Cursor = Cursors.WaitCursor
            Dim path As String = Application.StartupPath & "\download\"
            'create directory if not exist
            If Not IO.Directory.Exists(path) Then
                System.IO.Directory.CreateDirectory(path)
            End If
            path = path + "expired_vios_order.xlsx"
            exportToXLS(path, "expired order", GCExpiredOrder)
            Cursor = Cursors.Default
        End If
    End Sub

    Private Sub BtnViewExpiredOrderBySyncDate_Click(sender As Object, e As EventArgs) Handles BtnViewExpiredOrderBySyncDate.Click
        viewExpiredOrder(2)
    End Sub

    Private Sub GVExpiredOrder_CustomColumnDisplayText(sender As Object, e As DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs) Handles GVExpiredOrder.CustomColumnDisplayText
        If e.Column.FieldName = "no" Then
            e.DisplayText = (e.ListSourceRowIndex + 1).ToString()
        End If
    End Sub

    Private Sub BtnViewPromoSummary_Click(sender As Object, e As EventArgs) Handles BtnViewPromoSummary.Click
        viewPromoSummary()
    End Sub

    Sub viewPromoSummary()
        Cursor = Cursors.WaitCursor
        Dim id As String = SLEPromoSummary.EditValue.ToString
        Dim cond As String = ""
        If id <> "0" Then
            cond = "AND c.id_ol_promo_collection='" + id + "' "
        End If
        Dim query As String = "SELECT c.id_ol_promo_collection, c.number,c.promo_name, c.is_use_discount_code, IF(c.is_use_discount_code=1,'Active', 'Not Active') AS `is_use_discount_code_view`, 
        IFNULL(tc.total_code,0) AS `dc_propose`,IFNULL(o.order_used,0) AS `order_used`, IFNULL(o.total_qty,0) AS `total_qty`
        FROM tb_ol_promo_collection c
        LEFT JOIN (
	        SELECT od.id_ol_promo_collection, COUNT(DISTINCT od.id) AS `order_used`, 
	        SUM(od.sales_order_det_qty) AS `total_qty`
	        FROM tb_ol_store_order od 
	        WHERE !ISNULL(od.id_ol_promo_collection)
	        GROUP BY od.id_ol_promo_collection
        ) o ON o.id_ol_promo_collection = c.id_ol_promo_collection
        LEFT JOIN (
            SELECT dc.id_ol_promo_collection, COUNT(dc.id_ol_promo_collection_disc_code) AS `total_code`
            FROM tb_ol_promo_collection_disc_code dc
            GROUP BY dc.id_ol_promo_collection
        ) tc ON tc.id_ol_promo_collection = c.id_ol_promo_collection
        LEFT JOIN tb_ol_promo_collection_disc_code dc ON dc.id_ol_promo_collection = c.id_ol_promo_collection
        WHERE c.id_report_status=6 " + cond + "
        GROUP BY c.id_ol_promo_collection
        ORDER BY c.id_ol_promo_collection DESC "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCPromoSummary.DataSource = data
        GVPromoSummary.BestFitColumns()
        Cursor = Cursors.Default
    End Sub

    Private Sub GVPromoSummary_DoubleClick(sender As Object, e As EventArgs) Handles GVPromoSummary.DoubleClick
        If GVPromoSummary.RowCount > 0 And GVPromoSummary.FocusedRowHandle >= 0 Then
            Cursor = Cursors.WaitCursor
            SLEPromo.EditValue = GVPromoSummary.GetFocusedRowCellValue("id_ol_promo_collection").ToString
            viewPromoList()
            XTCPromo.SelectedTabPageIndex = 1
            Cursor = Cursors.Default
        End If
    End Sub

    Private Sub RepoLinkPromoSummary_Click(sender As Object, e As EventArgs) Handles RepoLinkPromoSummary.Click
        If GVPromoSummary.RowCount > 0 And GVPromoSummary.FocusedRowHandle >= 0 Then
            Cursor = Cursors.WaitCursor
            Dim id_ol_promo_collection As String = ""
            Try
                id_ol_promo_collection = GVPromoSummary.GetFocusedRowCellValue("id_ol_promo_collection").ToString
            Catch ex As Exception
            End Try
            Dim s As New ClassShowPopUp
            s.id_report = id_ol_promo_collection
            s.report_mark_type = "250"
            s.show()
            Cursor = Cursors.Default
        End If
    End Sub

    Private Sub BtnXLSPromoSummary_Click(sender As Object, e As EventArgs) Handles BtnXLSPromoSummary.Click
        If GVPromoSummary.RowCount > 0 Then
            Cursor = Cursors.WaitCursor
            Dim path As String = Application.StartupPath & "\download\"
            'create directory if not exist
            If Not IO.Directory.Exists(path) Then
                System.IO.Directory.CreateDirectory(path)
            End If
            path = path + "ol_store_report_prm_summ.xlsx"
            exportToXLS(path, "ol_store_report_prm_summ", GCPromoSummary)
            Cursor = Cursors.Default
        End If
    End Sub
End Class