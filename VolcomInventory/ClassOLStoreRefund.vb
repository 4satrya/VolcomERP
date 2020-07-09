Public Class ClassOLStoreRefund
    Sub createCN()
        Dim report_mark_type As String = "118"
        Dim qcn As String = "SELECT spd.id_sales_pos, so.sales_order_ol_shop_number AS `order_number`,
        sp.id_store_contact_from, sp.sales_pos_discount, sp.sales_pos_vat, sp.id_acc_ar, sp.id_acc_sales, sp.id_acc_sales_return
        FROM tb_ol_store_ret_list l
        INNER JOIN tb_ol_store_ret_det rd ON rd.id_ol_store_ret_det = l.id_ol_store_ret_det
        INNER JOIN tb_sales_order_det sod ON sod.id_sales_order_det = rd.id_sales_order_det
        INNER JOIN tb_sales_order so ON so.id_sales_order = sod.id_sales_order
        INNER JOIN tb_pl_sales_order_del_det dd ON dd.id_sales_order_det = sod.id_sales_order_det
        INNER JOIN tb_sales_pos_det spd ON spd.id_pl_sales_order_del_det = dd.id_pl_sales_order_del_det
        INNER JOIN tb_sales_pos sp ON sp.id_sales_pos = spd.id_sales_pos
        WHERE l.id_ol_store_ret_stt=6
        GROUP BY spd.id_sales_pos,so.sales_order_ol_shop_number "
        Dim dcn As DataTable = execute_query(qcn, -1, True, "", "", "", "")
        If dcn.Rows.Count > 0 Then
            For c As Integer = 0 To dcn.Rows.Count - 1
                FormMain.SplashScreenManager1.SetWaitFormDescription("Create credit note : " + (c + 1).ToString + " of " + dcn.Rows.Count.ToString)
                'main
                Dim id_so_type As String = "0"
                Dim id_inv_type As String = "0"
                Dim id_memo_type As String = "2"
                Dim qm As String = "INSERT INTO tb_sales_pos(id_store_contact_from, sales_pos_date, sales_pos_note, id_report_status, id_so_type, sales_pos_total, sales_pos_due_date, sales_pos_start_period, sales_pos_end_period, sales_pos_discount, sales_pos_potongan, sales_pos_vat, id_memo_type, id_inv_type, id_sales_pos_ref, report_mark_type, id_acc_ar, id_acc_sales, id_acc_sales_return) 
                VALUES('" + dcn.Rows(c)("id_store_contact_from").ToString + "', NOW(), '', 1, '" + id_so_type + "',0, NOW(), NOW(), NOW(), '" + decimalSQL(dcn.Rows(c)("sales_pos_discount").ToString) + "', 0, '" + dcn.Rows(c)("sales_pos_vat").ToString + "', '" + id_memo_type + "', '" + id_inv_type + "', '" + dcn.Rows(c)("id_sales_pos").ToString + "', '118', '" + dcn.Rows(c)("id_acc_ar").ToString + "', '" + dcn.Rows(c)("id_acc_sales").ToString + "', '" + dcn.Rows(c)("id_acc_sales_return").ToString + "'); SELECT LAST_INSERT_ID(); "
                Dim id_cn As String = execute_query(qm, 0, True, "", "", "", "")
                'gen number
                execute_non_query("CALL gen_number(" + id_cn + ", " + report_mark_type + ");", True, "", "", "", "")
                'detail
                Dim qd As String = "INSERT INTO tb_sales_pos_det(id_sales_pos, id_product, id_design_price, design_price, sales_pos_det_qty, id_design_price_retail, design_price_retail, note, id_sales_pos_det_ref, id_ol_store_ret_list) 
                SELECT '" + id_cn + "', p.id_product, id.id_design_price, id.design_price, IF((SUM(id.sales_pos_det_qty)-IFNULL(cn.jum_cn,0))<=0,0,-1)  AS qty,
                id.id_design_price_retail, id.design_price_retail, 'OK' AS `note`, id.id_sales_pos_det AS `id_sales_pos_det_ref`, l.id_ol_store_ret_list
                FROM tb_ol_store_ret_list l
                INNER JOIN tb_ol_store_ret_det rd ON rd.id_ol_store_ret_det = l.id_ol_store_ret_det
                INNER JOIN tb_ol_store_ret r ON r.id_ol_store_ret = rd.id_ol_store_ret
                INNER JOIN tb_pl_sales_order_del_det dd ON dd.id_sales_order_det = rd.id_sales_order_det
                INNER JOIN tb_pl_sales_order_del d ON d.id_pl_sales_order_del = dd.id_pl_sales_order_del
                INNER JOIN tb_m_comp_contact cc ON cc.id_comp_contact = d.id_store_contact_to
                INNER JOIN tb_m_comp c ON c.id_comp = cc.id_comp
                INNER JOIN tb_sales_pos_det id ON id.id_pl_sales_order_del_det = dd.id_pl_sales_order_del_det
                INNER JOIN tb_sales_pos i ON i.id_sales_pos = id.id_sales_pos
                INNER JOIN tb_m_product p ON p.id_product = id.id_product
                INNER JOIN tb_m_product_code pc ON pc.id_product = p.id_product
                INNER JOIN tb_m_code_detail cd ON cd.id_code_detail = pc.id_code_detail
                INNER JOIN tb_m_design_price prc ON prc.id_design_price = id.id_design_price_retail
                INNER JOIN tb_lookup_design_price_type pt ON pt.id_design_price_type = prc.id_design_price_type
                LEFT JOIN (
	                SELECT spd.id_sales_pos_det_ref AS `id_sales_pos_det`, SUM(spd.sales_pos_det_qty)*-1 AS `jum_cn`
	                FROM tb_sales_pos sp
	                INNER JOIN tb_sales_pos_det spd ON spd.id_sales_pos = sp.id_sales_pos
	                WHERE sp.id_sales_pos_ref=" + dcn.Rows(c)("id_sales_pos").ToString + " AND sp.id_report_status!=5
	                GROUP BY spd.id_sales_pos_det_ref
                ) cn ON cn.id_sales_pos_det = id.id_sales_pos_det
                WHERE l.id_ol_store_ret_stt=6 AND  r.sales_order_ol_shop_number='" + dcn.Rows(c)("order_number").ToString + "' AND i.id_sales_pos=" + dcn.Rows(c)("id_sales_pos").ToString + " 
                GROUP BY id.id_sales_pos_det
                HAVING qty=-1 ;
                -- update total qty
                UPDATE tb_sales_pos main
                INNER JOIN (
                    SELECT pd.id_sales_pos,ABS(SUM(pd.sales_pos_det_qty)) AS `total`, ABS(SUM(pd.sales_pos_det_qty * pd.design_price_retail)) AS `total_amount`
                    FROM tb_sales_pos_det pd
                    WHERE pd.id_sales_pos=" + id_cn + "
                    GROUP BY pd.id_sales_pos
                ) src ON src.id_sales_pos = main.id_sales_pos
                SET main.sales_pos_total_qty = src.total, main.sales_pos_total=src.total_amount; "
                execute_non_query(qd, True, "", "", "", "")
                'submit prepared
                Dim id_user_prepared_inv As String = get_opt_acc_field("invoice_prepared_by")
                submit_who_prepared(report_mark_type, id_cn, id_user_prepared_inv)
                'nonaktif mark
                Dim queryrm = String.Format("UPDATE tb_report_mark SET report_mark_lead_time=NULL,report_mark_start_datetime=NULL WHERE report_mark_type='{0}' AND id_report='{1}' AND id_report_status>'1'", report_mark_type, id_cn)
                execute_non_query(queryrm, True, "", "", "", "")
                'journal draft
                Dim acc As New ClassAccounting()
                acc.generateJournalSalesDraftWithMapping(id_cn, report_mark_type)
                'cek detail jum
                Dim id_stt As String = ""
                Dim qjum As String = "SELECT id_sales_pos FROM tb_sales_pos_det WHERE id_sales_pos='" + id_cn + "' "
                Dim djum As DataTable = execute_query(qjum, -1, True, "", "", "", "")
                If djum.Rows.Count > 0 Then
                    id_stt = "6"
                Else
                    id_stt = "5"
                End If
                If id_stt = "6" Then
                    'complete
                    Dim stc_in As ClassSalesInv = New ClassSalesInv()
                    stc_in.completeInStock(id_cn, report_mark_type)
                    'update status
                    Dim qu As String = "-- update status di return center
                    UPDATE tb_ol_store_ret_list main
                    INNER JOIN (
	                    SELECT d.id_ol_store_ret_list 
	                    FROM tb_sales_pos_det d
	                    WHERE d.id_sales_pos=" + id_cn + "
	                    GROUP BY d.id_ol_store_ret_list
                    ) src ON src.id_ol_store_ret_list = main.id_ol_store_ret_list
                    SET main.id_ol_store_ret_stt=7;
                    INSERT INTO tb_sales_order_det_status(id_sales_order_det, `status`, `status_date`, `input_status_date`, is_internal)
                    SELECT rd.id_sales_order_det, stt.ol_store_ret_stt, NOW(), NOW(),1
                    FROM tb_sales_pos_det d
                    INNER JOIN tb_ol_store_ret_list rl ON rl.id_ol_store_ret_list = d.id_ol_store_ret_list
                    INNER JOIN tb_ol_store_ret_det rd ON rd.id_ol_store_ret_det = rl.id_ol_store_ret_det
                    JOIN tb_lookup_ol_store_ret_stt stt ON stt.id_ol_store_ret_stt=7
                    WHERE d.id_sales_pos=" + id_cn + "
                    GROUP BY rd.id_sales_order_det;
                    -- update sttatus trans
                    UPDATE tb_sales_pos SET id_report_status=6 WHERE id_sales_pos=" + id_cn + ";"
                    execute_non_query(qu, True, "", "", "", "")
                Else
                    'cancel
                    Dim qu As String = "UPDATE tb_sales_pos SET id_report_status=5 WHERE id_sales_pos=" + id_cn + ";"
                    execute_non_query(qu, True, "", "", "", "")
                End If
            Next
        End If
    End Sub

    Sub createROR()
        Dim report_mark_type As String = "119"
        'Dim id_wh_contact_normal As String = get_setup_field("id_wh_contact_normal")
        'Dim id_wh_contact_sale As String = get_setup_field("id_wh_contact_sale")
        Dim id_user_prepared As String = get_opt_sales_field("default_so_online_prepared_by")
        Dim query As String = "SELECT so.id_sales_order,so.sales_order_ol_shop_number AS `order_number`, so.customer_name, 
        c.comp_number, c.comp_name, c.id_comp, cc.id_comp_contact, c.id_drawer_def, IF(c.id_store_type=3, 2, c.id_store_type) AS `id_store_type`,
        cg.id_wh_contact_normal, cg.id_wh_contact_sale
        FROM tb_ol_store_ret_list l
        INNER JOIN tb_ol_store_ret_det rd ON rd.id_ol_store_ret_det = l.id_ol_store_ret_det
        INNER JOIN tb_pl_sales_order_del_det dd ON dd.id_sales_order_det = rd.id_sales_order_det
        INNER JOIN tb_pl_sales_order_del d ON d.id_pl_sales_order_del = dd.id_pl_sales_order_del
        INNER JOIN tb_m_comp_contact cc ON cc.id_comp_contact = d.id_store_contact_to
        INNER JOIN tb_m_comp c ON c.id_comp = cc.id_comp
        INNER JOIN tb_m_comp_group cg ON cg.id_comp_group = c.id_comp_group
        INNER JOIN tb_lookup_store_type t ON t.id_store_type = c.id_store_type
        INNER JOIN tb_sales_order_det sod ON sod.id_sales_order_det = dd.id_sales_order_det
        INNER JOIN tb_sales_order so ON so.id_sales_order = sod.id_sales_order 
        LEFT JOIN (
	        SELECT spd.id_ol_store_ret_list 
            FROM tb_sales_return_order_det spd
	        INNER JOIN tb_sales_return_order sp ON sp.id_sales_return_order = spd.id_sales_return_order
	        WHERE sp.id_report_status!=5 AND !ISNULL(spd.id_ol_store_ret_list)
	        GROUP BY spd.id_ol_store_ret_list
        ) e ON e.id_ol_store_ret_list = l.id_ol_store_ret_list 
        WHERE l.id_ol_store_ret_stt=7 AND ISNULL(e.id_ol_store_ret_list)
        GROUP BY c.id_comp, so.id_sales_order "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        If data.Rows.Count > 0 Then
            For i As Integer = 0 To data.Rows.Count - 1
                FormMain.SplashScreenManager1.SetWaitFormDescription("Create return order : " + (i + 1).ToString + " of " + data.Rows.Count.ToString)
                Dim qcek As String = "CALL view_stock_ol_store3(" + data.Rows(i)("id_sales_order").ToString + ", " + data.Rows(i)("id_comp").ToString + "); "
                Dim dcek As DataTable = execute_query(qcek, -1, True, "", "", "", "")
                If dcek.Rows.Count > 0 Then
                    'cek wh
                    Dim id_wh_contact_to As String = ""
                    If data.Rows(i)("id_store_type").ToString = "1" Then
                        id_wh_contact_to = data.Rows(i)("id_wh_contact_normal").ToString
                    Else
                        id_wh_contact_to = data.Rows(i)("id_wh_contact_sale").ToString
                    End If
                    'Main tbale
                    Dim query_ins As String = "INSERT INTO tb_sales_return_order(id_store_contact_to, id_wh_contact_to, id_sales_order, sales_return_order_number, sales_return_order_date, sales_return_order_note, id_report_status, sales_return_order_est_date, id_order_type) "
                    query_ins += "VALUES('" + data.Rows(i)("id_comp_contact").ToString + "','" + id_wh_contact_to + "', '" + data.Rows(i)("id_sales_order").ToString + "', '" + header_number_sales("4") + "', NOW(), '1', '1', NOW(), '2'); SELECT LAST_INSERT_ID(); "
                    Dim id_sales_return_order As String = execute_query(query_ins, 0, True, "", "", "", "")
                    increase_inc_sales("4")

                    'insert who prepared
                    insert_who_prepared(report_mark_type, id_sales_return_order, id_user_prepared)

                    'detail
                    For d As Integer = 0 To (dcek.Rows.Count - 1)
                        'cek stok
                        Dim qst As String = " SELECT f.id_product, IFNULL(SUM(IF(f.id_storage_category=2, CONCAT('-', f.storage_product_qty), f.storage_product_qty)),0) AS `qty` 
	                    FROM tb_storage_fg f 
	                    WHERE f.id_wh_drawer=" + data.Rows(i)("id_drawer_def").ToString + " AND f.id_product='" + dcek.Rows(d)("id_product").ToString + "'
	                    GROUP BY f.id_product "
                        Dim dst As DataTable = execute_query(qst, -1, True, "", "", "", "")
                        If dst.Rows(0)("qty") > 0 Then
                            Dim query_det As String = "INSERT INTO tb_sales_return_order_det(id_sales_return_order, id_sales_order_det, id_product, id_design_price, design_price, sales_return_order_det_qty, sales_return_order_det_note, id_return_cat, id_ol_store_ret_list) 
                            VALUES('" + id_sales_return_order + "', '" + dcek.Rows(d)("id_sales_order_det").ToString + "', '" + dcek.Rows(d)("id_product").ToString + "', '" + dcek.Rows(d)("id_design_price").ToString + "', '" + decimalSQL(dcek.Rows(d)("design_price").ToString) + "', '" + decimalSQL(dcek.Rows(d)("sales_return_order_det_qty").ToString) + "', '', '1', '" + dcek.Rows(d)("id_ol_store_ret_list").ToString + "' ); "
                            execute_non_query(query_det, True, "", "", "", "")
                        End If
                    Next

                    'reserved qty
                    Dim ro As New ClassSalesReturnOrder
                    ro.reservedStock(id_sales_return_order)

                    'cek detail jum
                    Dim id_stt As String = ""
                    Dim qjum As String = "SELECT id_sales_return_order FROM tb_sales_return_order_det WHERE id_sales_return_order='" + id_sales_return_order + "' "
                    Dim djum As DataTable = execute_query(qjum, -1, True, "", "", "", "")
                    If djum.Rows.Count > 0 Then
                        id_stt = "6"
                    Else
                        id_stt = "5"
                    End If

                    If id_stt = "5" Then
                        Dim ror As New ClassSalesReturnOrder()
                        ro.cancelReservedStock(id_sales_return_order)
                        Dim qstt As String = "UPDATE tb_sales_return_order SET id_report_status='5' WHERE id_sales_return_order ='" + id_sales_return_order + "'; "
                        execute_non_query(qstt, True, "", "", "", "")
                    ElseIf id_stt = "6" Then
                        'update stt in return centre
                        Dim qstt As String = "UPDATE tb_ol_store_ret_list main
                            INNER JOIN (
                               SELECT d.id_ol_store_ret_list 
                               FROM tb_sales_return_order_det d
                               WHERE d.id_sales_return_order=" + id_sales_return_order + "
                               GROUP BY d.id_ol_store_ret_list
                            ) src ON src.id_ol_store_ret_list = main.id_ol_store_ret_list
                            SET main.id_ol_store_ret_stt=8;
                            INSERT INTO tb_sales_order_det_status(id_sales_order_det, `status`, `status_date`, `input_status_date`, is_internal)
                            SELECT rd.id_sales_order_det, stt.ol_store_ret_stt, NOW(), NOW(),1
                            FROM tb_sales_return_order_det d
                            INNER JOIN tb_ol_store_ret_list rl ON rl.id_ol_store_ret_list = d.id_ol_store_ret_list
                            INNER JOIN tb_ol_store_ret_det rd ON rd.id_ol_store_ret_det = rl.id_ol_store_ret_det
                            JOIN tb_lookup_ol_store_ret_stt stt ON stt.id_ol_store_ret_stt=8
                            WHERE d.id_sales_return_order=" + id_sales_return_order + "
                            GROUP BY rd.id_sales_order_det; 
                            UPDATE tb_sales_return_order SET id_report_status='6' WHERE id_sales_return_order ='" + id_sales_return_order + "'; "
                        execute_non_query(qstt, True, "", "", "", "")

                        'send mail for process return
                        Try

                        Catch ex As Exception

                        End Try
                    End If
                End If
            Next
        End If
    End Sub
End Class
