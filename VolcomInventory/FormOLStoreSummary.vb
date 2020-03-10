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
        viewComp()
        viewCompGroup()
        viewCompDetail()
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
        sod.id_sales_order_det, sod.item_id, sod.ol_store_id, sod.id_product, prod.product_full_code AS `code`, prod.product_display_name AS `name`, sz.code_detail_name AS `size`, sod.id_design_price, sod.design_price, sod.sales_order_det_qty AS `order_qty`, sod.sales_order_det_note,
        IFNULL(del.id_pl_sales_order_del,0) AS `id_del`,del.pl_sales_order_del_number AS `del_number`, del.pl_sales_order_del_date AS `del_date`, del.report_status AS `del_status`,
        IFNULL(ro.id_sales_return_order,0) AS `id_ro`, ro.sales_return_order_number AS `ro_number`, ro.sales_return_order_date as `ro_date`, ro.report_status AS `ro_status`,
        IFNULL(ret.id_sales_return,0) AS `id_ret`,ret.sales_return_number AS `ret_number`, ret.sales_return_date AS `ret_date`, ret.report_status AS `ret_status`,
        IFNULL(inv.id_sales_pos,0) AS `id_inv`,inv.sales_pos_number AS `inv_number`, inv.sales_pos_date AS `inv_date`, inv.report_status AS `inv_status`,
        IFNULL(cn.id_sales_pos,0) AS `id_cn`, cn.sales_pos_number AS `cn_number`, cn.sales_pos_date AS `cn_date`, cn.report_status AS `cn_status`,
        IFNULL(rec_pay.id_rec_payment,0) AS `id_rec_pay`,rec_pay.`number` AS `rec_pay_number`, rec_pay.date_created AS `rec_pay_date`,IF(inv.is_close_rec_payment=1,'Paid','Pending') AS `rec_pay_status`,
        '0' AS `report_mark_type`, 
        IFNULL(stt.`status`, 'Pending') AS `ol_store_status`, IFNULL(stt.status_date, sales_order_ol_shop_date) AS `ol_store_date`,
        so.sales_order_ol_shop_date,  so.`customer_name` , so.`shipping_name` , so.`shipping_address`, so.`shipping_phone` , so.`shipping_city` , 
        so.`shipping_post_code` , so.`shipping_region` , so.`payment_method`, so.`tracking_code`
        FROM tb_sales_order so
        INNER JOIN tb_sales_order_det sod ON sod.id_sales_order = so.id_sales_order
        LEFT JOIN (
            SELECT * FROM (
	            SELECT stt.id_sales_order_det, stt.`status`, stt.status_date 
	            FROM tb_sales_order_det_status stt
	            ORDER BY stt.status_date DESC
            ) a
            GROUP BY a.id_sales_order_det
        ) stt ON stt.id_sales_order_det = sod.id_sales_order_det
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
End Class