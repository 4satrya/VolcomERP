Public Class ClassFGTrf
    Public Function queryMain(ByVal condition As String, ByVal order_type As String) As String
        Dim query As String = "CALL view_fg_trf_main('" + condition + "', '" + order_type + "') "
        Return query
    End Function

    Public Function transactionList(ByVal condition As String, ByVal order_type As String, ByVal is_by_barcode As Boolean) As DataTable
        Dim query As String = ""
        If is_by_barcode Then
            query = "CALL view_fg_trf_main2(""" + condition + """, " + order_type + ")"
        Else
            query = "CALL view_fg_trf_main2_code(""" + condition + """, " + order_type + ")"
        End If
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        Return data
    End Function

    Public Function queryDetail(ByVal id_report_param As String) As String
        Dim query As String = "CALL view_fg_trf('" + id_report_param + "')"
        Return query
    End Function

    Public Sub changeStatus(ByVal id_report_par As String, ByVal id_status_reportx_par As String)
        'rollback stock if cancelled and complerted
        If id_status_reportx_par = "6" Then
            Dim id_so As String = execute_query("SELECT id_sales_order FROM tb_fg_trf WHERE id_fg_trf='" + id_report_par + "' ", 0, True, "", "", "", "")

            Dim query_complete As String = "
             -- delete so first (strage)
            DELETE FROM tb_storage_fg 
            WHERE report_mark_type=39 AND id_report=" + id_so + " AND report_mark_type_ref=57 AND id_report_ref=" + id_report_par + " AND id_storage_category=1 AND id_stock_status=2 ;
            -- delete del first (strage)
            DELETE FROM tb_storage_fg 
            WHERE report_mark_type=57 AND id_report=" + id_report_par + ";
            -- insert storage
            INSERT INTO tb_storage_fg(id_wh_drawer, id_storage_category, id_product, bom_unit_price, report_mark_type, id_report, storage_product_qty, storage_product_datetime, storage_product_notes, id_stock_status, report_mark_type_ref, id_report_ref) "
            query_complete += "SELECT (getCompByContact(trf.id_comp_contact_from, 4)) AS `drawer`, '1', trf_det.id_product, dsg.design_cop, '39' AS `report_mark_type`, trf.id_sales_order AS `id_report`, trf_det.fg_trf_det_qty, NOW(), '', '2', 57, " + id_report_par + " "
            query_complete += "FROM tb_fg_trf trf "
            query_complete += "INNER JOIN tb_fg_trf_det trf_det ON trf_det.id_fg_trf = trf.id_fg_trf "
            query_complete += "INNER JOIN tb_m_product prod ON prod.id_product = trf_det.id_product "
            query_complete += "INNER JOIN tb_m_design dsg ON dsg.id_design = prod.id_design "
            query_complete += "WHERE trf.id_fg_trf=" + id_report_par + " AND trf_det.fg_trf_det_qty >0  "
            query_complete += "UNION ALL "
            query_complete += "SELECT (getCompByContact(trf.id_comp_contact_from, 4)) AS `drawer`, '2', trf_det.id_product, dsg.design_cop, '57' AS `report_mark_type`, trf.id_fg_trf AS `id_report`, trf_det.fg_trf_det_qty, NOW(), '', '1', NULL, NULL "
            query_complete += "FROM tb_fg_trf trf "
            query_complete += "INNER JOIN tb_fg_trf_det trf_det ON trf_det.id_fg_trf = trf.id_fg_trf "
            query_complete += "INNER JOIN tb_m_product prod ON prod.id_product = trf_det.id_product "
            query_complete += "INNER JOIN tb_m_design dsg ON dsg.id_design = prod.id_design "
            query_complete += "WHERE trf.id_fg_trf=" + id_report_par + " AND trf_det.fg_trf_det_qty >0  "
            query_complete += "UNION ALL "
            query_complete += "SELECT (trf.id_wh_drawer) AS `drawer`, '1', trf_det.id_product, dsg.design_cop, '57' AS `report_mark_type`, trf.id_fg_trf AS `id_report`, trf_det.fg_trf_det_qty, NOW(), '', '1', NULL, NULL "
            query_complete += "FROM tb_fg_trf trf "
            query_complete += "INNER JOIN tb_fg_trf_det trf_det ON trf_det.id_fg_trf = trf.id_fg_trf "
            query_complete += "INNER JOIN tb_m_product prod ON prod.id_product = trf_det.id_product "
            query_complete += "INNER JOIN tb_m_design dsg ON dsg.id_design = prod.id_design "
            query_complete += "WHERE trf.id_fg_trf=" + id_report_par + " AND trf_det.fg_trf_det_qty >0  "
            execute_non_query(query_complete, True, "", "", "", "")

            'complete unique
            Dim query_unique As String = "INSERT INTO tb_m_unique_code(`id_comp`,`id_wh_drawer`,`id_product`, `id_fg_trf_det_counting`,`id_pl_prod_order_rec_det_unique`,`id_type`,`unique_code`,
            `id_design_price`,`design_price`,`qty`,`is_unique_report`,`input_date`) 
            SELECT cc.id_comp, t.id_wh_drawer, td.id_product,  tc.id_fg_trf_det_counting,tc.id_pl_prod_order_rec_det_unique, '7', 
            CONCAT(p.product_full_code,tc.fg_trf_det_counting), sod.id_design_price, sod.design_price, 1, 1, NOW() 
            FROM tb_fg_trf_det td
            INNER JOIN tb_fg_trf t ON t.id_fg_trf = td.id_fg_trf
            INNER JOIN tb_sales_order so ON so.id_sales_order = t.id_sales_order
            INNER JOIN tb_fg_trf_det_counting tc ON tc.id_fg_trf_det = td.id_fg_trf_det
            INNER JOIN tb_m_comp_contact cc ON cc.id_comp_contact =  t.id_comp_contact_to
            INNER JOIN tb_m_comp c ON c.id_comp = cc.id_comp
            INNER JOIN tb_m_product p ON p.id_product = td.id_product
            INNER JOIN tb_m_design d ON d.id_design = p.id_design
            INNER JOIN tb_sales_order_det sod ON sod.id_sales_order_det = td.id_sales_order_det
            WHERE t.id_fg_trf=" + id_report_par + " AND d.is_old_design=2  AND t.is_use_unique_code=1 AND so.is_transfer_data=2 "
            execute_non_query(query_unique, True, "", "", "", "")

            'save unreg unique
            execute_non_query("CALL generate_unreg_barcode(" + id_report_par + ",2)", True, "", "", "", "")

            'update to shopify
            Dim is_sync_stock As String = execute_query("
                SELECT so.is_sync_stock
                FROM tb_fg_trf AS trf
                LEFT JOIN tb_sales_order AS so ON trf.id_sales_order = so.id_sales_order
                WHERE trf.id_fg_trf = " + id_report_par + "
            ", 0, True, "", "", "", "")

            If is_sync_stock = "1" Then
                Dim is_vsol_from As String = execute_query("SELECT IF(COUNT(*) = 0, 2, 1) AS is_vsol_from FROM tb_m_comp_volcom_ol WHERE id_comp IN (SELECT k.id_comp FROM tb_fg_trf AS f LEFT JOIN tb_m_comp_contact AS k ON f.id_comp_contact_from = k.id_comp_contact WHERE f.id_fg_trf = " + id_report_par + ")", 0, True, "", "", "", "")
                Dim is_vsol_to As String = execute_query("SELECT IF(COUNT(*) = 0, 2, 1) AS is_vsol_to FROM tb_m_comp_volcom_ol WHERE id_comp IN (SELECT k.id_comp FROM tb_fg_trf AS f LEFT JOIN tb_m_comp_contact AS k ON f.id_comp_contact_to = k.id_comp_contact WHERE f.id_fg_trf = " + id_report_par + ")", 0, True, "", "", "", "")

                If is_vsol_from = "1" Or is_vsol_to = "1" Then
                    Dim cls As ClassShopifyApi = New ClassShopifyApi

                    Dim location_id As String = cls.get_location_id()

                    Dim erp_product As DataTable = execute_query("
                        SELECT prod.product_full_code, trf_det.fg_trf_det_qty, shop.inventory_item_id
                        FROM tb_fg_trf trf
                        INNER JOIN tb_fg_trf_det trf_det ON trf_det.id_fg_trf = trf.id_fg_trf
                        INNER JOIN tb_m_product prod ON prod.id_product = trf_det.id_product
                        INNER JOIN tb_m_design dsg ON dsg.id_design = prod.id_design
                        LEFT JOIN tb_m_product_shopify shop ON prod.product_full_code = shop.sku
                        WHERE trf.id_fg_trf = " + id_report_par + " AND trf_det.fg_trf_det_qty > 0
                    ", -1, True, "", "", "", "")

                    For j = 0 To erp_product.Rows.Count - 1
                        Dim msg As String = "OK"

                        Dim qty As String = Decimal.Round(erp_product.Rows(j)("fg_trf_det_qty"), 0).ToString

                        If is_vsol_from = "1" Then
                            qty = "-" + qty
                        End If

                        If is_vsol_from = "1" And is_vsol_to = "1" Then
                            qty = "0"
                        End If

                        Try
                            cls.add_product(location_id, erp_product.Rows(j)("inventory_item_id").ToString, qty)
                        Catch ex As Exception
                            msg = ex.ToString
                        End Try

                        execute_non_query("INSERT INTO tb_shopify_api_log (report_mark_type, id_report, sku, message, date) VALUES (57, " + id_report_par + ", '" + erp_product.Rows(j)("product_full_code").ToString + "', '" + addSlashes(msg) + "', NOW())", True, "", "", "", "")
                    Next
                End If
            End If
        ElseIf id_status_reportx_par = "5" Then
            'cancel unique
            Dim query_cancel As String = "INSERT INTO tb_m_unique_code(`id_comp`,`id_wh_drawer`,`id_product`, `id_fg_trf_det_counting`,`id_pl_prod_order_rec_det_unique`,`id_type`,`unique_code`,
            `id_design_price`,`design_price`,`qty`,`is_unique_report`,`input_date`) 
            SELECT cc.id_comp, c.id_drawer_def, td.id_product,  tc.id_fg_trf_det_counting,tc.id_pl_prod_order_rec_det_unique, '7', 
            CONCAT(p.product_full_code,tc.fg_trf_det_counting), sod.id_design_price, sod.design_price, 1, 1, NOW() 
            FROM tb_fg_trf_det td
            INNER JOIN tb_fg_trf t ON t.id_fg_trf = td.id_fg_trf
            INNER JOIN tb_sales_order so ON so.id_sales_order = t.id_sales_order
            INNER JOIN tb_fg_trf_det_counting tc ON tc.id_fg_trf_det = td.id_fg_trf_det
            INNER JOIN tb_m_comp_contact cc ON cc.id_comp_contact =  t.id_comp_contact_from
            INNER JOIN tb_m_comp c ON c.id_comp = cc.id_comp
            INNER JOIN tb_m_product p ON p.id_product = td.id_product
            INNER JOIN tb_m_design d ON d.id_design = p.id_design
            INNER JOIN tb_sales_order_det sod ON sod.id_sales_order_det = td.id_sales_order_det
            WHERE t.id_fg_trf=" + id_report_par + " AND d.is_old_design=2  AND t.is_use_unique_code=1 AND so.is_transfer_data=2 "
            execute_non_query(query_cancel, True, "", "", "", "")
        End If
        Dim query As String = String.Format("UPDATE tb_fg_trf SET id_report_status='{0}', id_report_status_rec = '" + id_status_reportx_par + "', last_update=NOW(), last_update_by=" + id_user + " WHERE id_fg_trf ='{1}'", id_status_reportx_par, id_report_par)
        execute_non_query(query, True, "", "", "", "")
    End Sub
End Class
