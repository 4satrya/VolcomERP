Public Class FormOLStoreDet
    Dim id_wh_induk_normal As String = "-1"
    Dim id_wh_induk_normal_cc As String = "-1"
    Dim id_wh_induk_sale As String = "-1"
    Dim id_wh_induk_sale_cc As String = "-1"
    Dim is_use_virtual_account As String = "2"
    Dim id_user_prepared As String = "-1"
    Dim id_drawer_online_normal As String = "-1"
    Dim id_drawer_online_sale As String = "-1"

    Private Sub BtnBrowseFile_Click(sender As Object, e As EventArgs) Handles BtnBrowseFile.Click
        Cursor = Cursors.WaitCursor
        FormImportExcel.id_pop_up = "41"
        FormImportExcel.ShowDialog()
        Cursor = Cursors.Default
    End Sub

    Private Sub FormOLStoreDet_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        viewCompGroup()
        viewDetail()
    End Sub

    Sub viewDetail()
        Dim query As String = "SELECT so.id_sales_order, sod.id_sales_order_det, 
        so.id_warehouse_contact_to, '0' AS `id_wh_drawer`, '' AS `comp`,
        so.id_store_contact_to,  '' AS `store`,
        so.sales_order_number,so.sales_order_ol_shop_number, so.sales_order_date, so.sales_order_ol_shop_date,
        sod.id_product,'' AS `code`, '' AS `name`, '' AS `item_id`, '' AS `ol_store_id`, sod.sales_order_det_qty, 0 AS `id_design_cat`,sod.id_design_price, sod.design_price, CAST(0 AS DECIMAL(15,2)) AS `design_cop`, sod.ol_store_sku,
        so.customer_name, so.shipping_name, so.shipping_address, so.shipping_phone, so.shipping_city, 
        so.shipping_post_code, so.shipping_region, so.payment_method, so.tracking_code, 0 AS `no`, '' AS `status`
        FROM tb_sales_order so
        INNER JOIN tb_sales_order_det sod ON sod.id_sales_order = so.id_sales_order
        WHERE so.id_sales_order=0 "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCDetail.DataSource = data
        GVDetail.BestFitColumns()
    End Sub

    Sub viewCompGroup()
        Dim query As String = "SELECT g.id_comp_group, g.description
        FROM tb_m_comp c 
        INNER JOIN tb_m_comp_group g ON g.id_comp_group = c.id_comp_group
        WHERE c.id_commerce_type=2 AND c.is_active=1
        GROUP BY c.id_comp_group "
        viewSearchLookupQuery(SLECompGroup, query, "id_comp_group", "description", "id_comp_group")
    End Sub

    Private Sub FormOLStoreDet_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub BtnDiscard_Click(sender As Object, e As EventArgs) Handles BtnDiscard.Click
        Close()
    End Sub

    Function dataWHInduk(ByVal id_store_type_par As String) As DataTable
        Dim query As String = "SELECT wh.id_comp, whc.id_comp_contact, wh.comp_number, wh.id_drawer_def
        FROM tb_m_comp c 
        INNER JOIN tb_m_comp whv ON whv.id_comp = c.id_wh
        INNER JOIN tb_m_comp wh ON wh.id_comp = whv.id_wh_group
        INNER JOIN tb_m_comp_contact whc ON whc.id_comp = wh.id_comp AND whc.is_default=1
        WHERE c.id_comp_group='" + SLECompGroup.EditValue.ToString + "' AND c.id_store_type=" + id_store_type_par + " AND c.is_active=1 "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        Return data
    End Function

    Dim id_so_created As String = ""
    Private Sub BtnCreate_Click(sender As Object, e As EventArgs) Handles BtnCreate.Click
        Dim confirm As DialogResult = DevExpress.XtraEditors.XtraMessageBox.Show("Are you sure you want to create order?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
        If confirm = Windows.Forms.DialogResult.Yes Then
            'load gudang induk
            is_use_virtual_account = get_setup_field("is_use_virtual_account")
            If is_use_virtual_account = "1" Then
                Dim dt_normal As DataTable = dataWHInduk("1")
                id_wh_induk_normal = dt_normal.Rows(0)("id_comp").ToString
                id_wh_induk_normal_cc = dt_normal(0)("id_comp_contact").ToString
                id_drawer_online_normal = dt_normal.Rows(0)("id_drawer_def").ToString
                Dim dt_sale As DataTable = dataWHInduk("2")
                id_wh_induk_sale = dt_sale.Rows(0)("id_comp").ToString
                id_wh_induk_sale_cc = dt_sale.Rows(0)("id_comp_contact").ToString
                id_drawer_online_sale = dt_sale.Rows(0)("id_drawer_def").ToString
                id_user_prepared = get_opt_sales_field("default_so_online_prepared_by")
            End If

            'temp bof declare
            id_so_created = ""
            Dim bof_column As String = get_setup_field("bof_column")

            makeSafeGV(GVDetail)
            makeSafeGV(GVProduct)

            'checkstock harus di grup
            FormMain.SplashScreenManager1.ShowWaitForm()
            FormMain.SplashScreenManager1.SetWaitFormDescription("Checking stock availibility")
            Dim cond_stock As Boolean = True
            For i As Integer = 0 To GVProduct.RowCount - 1
                Dim id_product As String = GVProduct.GetRowCellValue(i, "id_product").ToString
                Dim id_wh_drawer As String = GVProduct.GetRowCellValue(i, "id_wh_drawer").ToString
                Dim query As String = "SELECT f.id_wh_drawer, f.id_product, IFNULL(SUM(IF(f.id_storage_category=2, CONCAT('-', f.storage_product_qty), f.storage_product_qty)),0) AS `available_qty` 
                FROM tb_storage_fg f
                WHERE f.id_wh_drawer='" + id_wh_drawer + "' AND f.id_product='" + id_product + "' "
                Dim dt As DataTable = execute_query(query, -1, True, "", "", "", "")
                If dt.Rows.Count > 0 Then
                    If GVProduct.GetRowCellValue(i, "qty") > dt.Rows(0)("available_qty") Then
                        cond_stock = False
                        GVProduct.SetRowCellValue(i, "status", "Qty can't exceed : " + dt.Rows(0)("available_qty").ToString + " ")
                    Else
                        GVProduct.SetRowCellValue(i, "status", "OK")
                    End If
                Else
                    cond_stock = False
                    GVProduct.SetRowCellValue(i, "status", "No available qty")
                End If
            Next
            FormMain.SplashScreenManager1.CloseWaitForm()

            If Not cond_stock Then
                stopCustom("Can't procees these order, please make sure available stock ")
                GridColumnProdStatus.VisibleIndex = 100
                XTCOrder.SelectedTabPageIndex = 1
            Else
                FormMain.SplashScreenManager1.ShowWaitForm()
                createOrder("1")
                createOrder("2")

                'temp bof
                If bof_column = "1" Then
                    Dim so As New ClassSalesOrder()
                    Dim res As String = so.generateXLSForBOF(id_so_created)
                    'Console.WriteLine(id_so_created + "/" + res)
                    FormMain.SplashScreenManager1.SetWaitFormDescription("Export data to BOF : " + res)
                End If

                'refresh view
                FormOLStore.XtraTabControl1.SelectedTabPageIndex = 0
                FormOLStore.SLECompDetail.EditValue = "0"
                FormOLStore.setDateNow()
                FormOLStore.viewSummary()
                FormMain.SplashScreenManager1.CloseWaitForm()
                infoCustom("Order successfully created")
                Close()
            End If
        End If
    End Sub


    Sub createOrder(ByVal id_store_type As String)
        Dim id_order_last As String = ""
        Dim order_last As String = ""

        'virtual ada trf alokasi
        If is_use_virtual_account = "1" Then
            makeSafeGV(GVProduct)
            Dim is_error As String = "2"
            Dim id_order_trf As String = "-1"
            Dim id_trf As String = "-1"

            'delete storage jika sebelumnya ada eror trf
            Dim qcek As String = "SELECT * FROM tb_ol_store_order_log_generate WHERE is_delete=2"
            Dim dcek As DataTable = execute_query(qcek, -1, True, "", "", "", "")
            If dcek.Rows.Count > 0 Then
                'delete stok
                FormMain.SplashScreenManager1.SetWaitFormDescription("Clean data allocation transfer")
                For d As Integer = 0 To dcek.Rows.Count - 1
                    Dim qdel As String = "DELETE FROM tb_storage_fg WHERE report_mark_type=57 AND id_report=" + dcek.Rows(d)("id_trf").ToString + ";
                    UPDATE tb_ol_store_order_log_generate SET is_delete=1 WHERE id_log='" + dcek.Rows(d)("id_log").ToString + "'; "
                    execute_non_query(qdel, True, "", "", "", "")
                Next
            End If

            Try
                Dim id_contact_to As String = ""
                If id_store_type = "1" Then
                    FormMain.SplashScreenManager1.SetWaitFormDescription("Create transfer alloction for Normal Product")
                    id_contact_to = id_wh_induk_normal_cc
                Else
                    FormMain.SplashScreenManager1.SetWaitFormDescription("Create transfer alloction for Sale Product")
                    id_contact_to = id_wh_induk_sale_cc
                End If
                GVProduct.ActiveFilterString = "[id_design_cat]=" + id_store_type + ""


                For p As Integer = 0 To GVProduct.RowCount - 1
                    If p = 0 Then
                        'create header order trf
                        Dim id_warehouse_contact_to As String = GVProduct.GetRowCellValue(p, "id_comp_contact_from").ToString
                        Dim qord As String = "INSERT INTO tb_sales_order(id_store_contact_to, id_warehouse_contact_to, sales_order_number, sales_order_date, sales_order_note, id_so_type, id_report_status, id_so_status, id_user_created, is_transfer_data) 
                        VALUES('" + id_contact_to + "', '" + id_warehouse_contact_to + "', '', NOW(), 'Order Trf for Order Zalora by ERP', 0, 1, 5, '" + id_user_prepared + "',1); SELECT LAST_INSERT_ID(); "
                        id_order_trf = execute_query(qord, 0, True, "", "", "", "")

                        'create header trf
                        Dim qtrf As String = "INSERT INTO tb_fg_trf(id_comp_contact_from, id_comp_contact_to, id_sales_order, fg_trf_number, fg_trf_date, fg_trf_date_rec, fg_trf_note, id_report_status, id_report_status_rec, id_wh_drawer, last_update, last_update_by)
                        VALUES('" + id_warehouse_contact_to + "', '" + id_contact_to + "', '" + id_order_trf + "','',NOW(), NOW(),'Trf for Order Zalora by ERP',1,1,getCompByContact(" + id_contact_to + ", 4),NOW(), '" + id_user_prepared + "'); SELECT LAST_INSERT_ID(); "
                        id_trf = execute_query(qtrf, 0, True, "", "", "", "")
                        execute_non_query("CALL gen_number(" + id_trf + ", 57);", True, "", "", "", "")
                    End If

                    'detail insert order trf
                    Dim id_product As String = GVProduct.GetRowCellValue(p, "id_product").ToString
                    Dim id_design_price As String = GVProduct.GetRowCellValue(p, "id_design_price").ToString
                    Dim design_price As String = decimalSQL(GVProduct.GetRowCellValue(p, "design_price").ToString)
                    Dim qty As String = decimalSQL(GVProduct.GetRowCellValue(p, "qty").ToString)
                    Dim note As String = ""
                    Dim qord_detail As String = "INSERT INTO tb_sales_order_det(id_sales_order, id_product, id_design_price, design_price, sales_order_det_qty, sales_order_det_note, item_id, ol_store_id) 
                    VALUES('" + id_order_trf + "', '" + id_product + "', '" + id_design_price + "', '" + design_price + "', '" + qty + "', '" + note + "', '',''); SELECT LAST_INSERT_ID(); "
                    Dim id_order_detail As String = execute_query(qord_detail, 0, True, "", "", "", "")

                    'detail insert trf
                    Dim qtrf_detail As String = "INSERT INTO tb_fg_trf_det(id_fg_trf, id_product, id_sales_order_det, fg_trf_det_qty, fg_trf_det_qty_rec, fg_trf_det_qty_stored, fg_trf_det_note)
                    VALUES('" + id_trf + "', '" + id_product + "', '" + id_order_detail + "', '" + qty + "', '" + qty + "', '" + qty + "', '');"
                    execute_non_query(qtrf_detail, True, "", "", "", "")
                Next
                If id_trf <> "-1" Then
                    Dim qry_complete_trf As String = "
                    -- manajemen stok
	                DELETE FROM tb_storage_fg WHERE report_mark_type=57 AND id_report=" + id_trf + ";
                    INSERT INTO tb_storage_fg(id_wh_drawer, id_storage_category, id_product, bom_unit_price, report_mark_type, id_report, storage_product_qty, storage_product_datetime, storage_product_notes, id_stock_status, report_mark_type_ref, id_report_ref)
	                SELECT (getCompByContact(trf.id_comp_contact_from, 4)) AS `drawer`, '2', trf_det.id_product, IFNULL(dsg.design_cop,0), '57' AS `report_mark_type`, trf.id_fg_trf AS `id_report`, trf_det.fg_trf_det_qty, NOW(), '', '1', NULL, NULL 
	                FROM tb_fg_trf trf 
	                INNER JOIN tb_fg_trf_det trf_det ON trf_det.id_fg_trf = trf.id_fg_trf 
	                INNER JOIN tb_m_product prod ON prod.id_product = trf_det.id_product 
	                INNER JOIN tb_m_design dsg ON dsg.id_design = prod.id_design 
	                WHERE trf.id_fg_trf=" + id_trf + " AND trf_det.fg_trf_det_qty>0
                    UNION ALL 
	                SELECT (trf.id_wh_drawer) AS `drawer`, '1', trf_det.id_product, IFNULL(dsg.design_cop,0), '57' AS `report_mark_type`, trf.id_fg_trf AS `id_report`, trf_det.fg_trf_det_qty, NOW(), '', '1', NULL, NULL 
	                FROM tb_fg_trf trf 
	                INNER JOIN tb_fg_trf_det trf_det ON trf_det.id_fg_trf = trf.id_fg_trf 
	                INNER JOIN tb_m_product prod ON prod.id_product = trf_det.id_product 
	                INNER JOIN tb_m_design dsg ON dsg.id_design = prod.id_design 
	                WHERE trf.id_fg_trf=" + id_trf + " AND trf_det.fg_trf_det_qty>0;
                    -- update order trf & trf status
                    UPDATE tb_sales_order SET id_report_status=6 WHERE id_sales_order = " + id_order_trf + ";
                    UPDATE tb_fg_trf SET id_report_status=6 WHERE id_fg_trf=" + id_trf + "; "
                    execute_non_query(qry_complete_trf, True, "", "", "", "")
                End If
            Catch ex As Exception
                is_error = "1"
                execute_non_query("INSERT INTO tb_ol_store_order_log_generate(log, log_time, id_trf) VALUES('" + addSlashes(ex.ToString) + "', NOW(), '" + id_trf + "')", True, "", "", "", "")
            End Try
            GVProduct.ActiveFilterString = ""

            If is_error = "1" Then
                FormMain.SplashScreenManager1.CloseWaitForm()
                Cursor = Cursors.Default
                stopCustom("Problem with allocation transfer. Please try again later")
                Exit Sub
            End If
        End If

        makeSafeGV(GVDetail)
        GVDetail.ActiveFilterString = "[id_design_cat]='" + id_store_type + "' "
                GridColumnOrderNumber.SortOrder = DevExpress.Data.ColumnSortOrder.Ascending
        For i As Integer = 0 To GVDetail.RowCount - 1
            If id_store_type = "1" Then
                FormMain.SplashScreenManager1.SetWaitFormDescription("Normal account : " + (i + 1).ToString + " of " + GVDetail.RowCount.ToString)
            Else
                FormMain.SplashScreenManager1.SetWaitFormDescription("Sale account : " + (i + 1).ToString + " of " + GVDetail.RowCount.ToString)
            End If

            Dim id_wh_drawer As String = ""
            If is_use_virtual_account = "1" Then
                If id_store_type = "1" Then
                    id_wh_drawer = id_drawer_online_normal
                Else
                    id_wh_drawer = id_drawer_online_sale
                End If
            Else
                id_wh_drawer = GVDetail.GetRowCellValue(i, "id_wh_drawer").ToString
            End If
            Dim id_warehouse_contact_to As String = ""
            If is_use_virtual_account = "1" Then
                If id_store_type = "1" Then
                    id_warehouse_contact_to = id_wh_induk_normal_cc
                Else
                    id_warehouse_contact_to = id_wh_induk_sale_cc
                End If
            Else
                id_warehouse_contact_to = GVDetail.GetRowCellValue(i, "id_warehouse_contact_to").ToString
            End If
            Dim id_store_contact_to As String = GVDetail.GetRowCellValue(i, "id_store_contact_to").ToString
            Dim sales_order_ol_shop_number As String = GVDetail.GetRowCellValue(i, "sales_order_ol_shop_number").ToString.Trim
            Dim sales_order_ol_shop_date As String = DateTime.Parse(GVDetail.GetRowCellValue(i, "sales_order_ol_shop_date").ToString).ToString("yyyy-MM-dd HH:mm:ss")
            Dim sales_order_note As String = ""
            Dim id_so_type As String = "0"
            Dim id_so_status As String = "6"
            Dim id_report_status As String = "1"
            Dim id_user_created As String = id_user
            Dim ol_store_sku As String = addSlashes(GVDetail.GetRowCellValue(i, "ol_store_sku").ToString)
            Dim customer_name As String = addSlashes(GVDetail.GetRowCellValue(i, "customer_name").ToString)
            Dim shipping_name As String = addSlashes(GVDetail.GetRowCellValue(i, "shipping_name").ToString)
            Dim shipping_address = addSlashes(GVDetail.GetRowCellValue(i, "shipping_address").ToString)
            Dim shipping_phone = addSlashes(GVDetail.GetRowCellValue(i, "shipping_phone").ToString)
            Dim shipping_city = addSlashes(GVDetail.GetRowCellValue(i, "shipping_city").ToString)
            Dim shipping_post_code = addSlashes(GVDetail.GetRowCellValue(i, "shipping_post_code").ToString)
            Dim shipping_region = addSlashes(GVDetail.GetRowCellValue(i, "shipping_region").ToString)
            Dim payment_method = addSlashes(GVDetail.GetRowCellValue(i, "payment_method").ToString)
            Dim tracking_code = addSlashes(GVDetail.GetRowCellValue(i, "tracking_code").ToString)

            'cek order baru atau lama
            If order_last <> sales_order_ol_shop_number Then
                'new order
                Dim query_main As String = "INSERT INTO tb_sales_order(id_store_contact_to, id_warehouse_contact_to, sales_order_number, sales_order_ol_shop_number, 
                sales_order_date, sales_order_ol_shop_date, sales_order_note, id_so_type, id_so_status, id_report_status, id_user_created, 
                customer_name, shipping_name, shipping_address, shipping_phone, shipping_city, shipping_post_code, shipping_region, payment_method, tracking_code) 
                VALUES('" + id_store_contact_to + "', '" + id_warehouse_contact_to + "', '', '" + sales_order_ol_shop_number + "',
                NOW(), '" + sales_order_ol_shop_date + "', '" + sales_order_note + "', '" + id_so_type + "', '" + id_so_status + "', '" + id_report_status + "', '" + id_user_created + "',
                '" + customer_name + "', '" + shipping_name + "', '" + shipping_address + "', '" + shipping_phone + "', '" + shipping_city + "', '" + shipping_post_code + "', '" + shipping_region + "', '" + payment_method + "', '" + tracking_code + "'); 
                SELECT LAST_INSERT_ID(); "
                id_order_last = execute_query(query_main, 0, True, "", "", "", "")

                'submit who prepared
                submit_who_prepared("39", id_order_last, id_user)

                If id_so_created <> "" Then
                    id_so_created += "OR "
                End If

                'temp bof
                id_so_created += "so.id_sales_order='" + id_order_last + "' "
            End If

            'detail & reserved
            Dim id_product As String = GVDetail.GetRowCellValue(i, "id_product").ToString
            Dim id_design_price As String = GVDetail.GetRowCellValue(i, "id_design_price").ToString
            Dim design_price As String = decimalSQL(GVDetail.GetRowCellValue(i, "design_price").ToString)
            Dim design_cop As String = decimalSQL(GVDetail.GetRowCellValue(i, "design_cop").ToString)
            Dim item_id As String = GVDetail.GetRowCellValue(i, "item_id").ToString.Trim
            Dim ol_store_id As String = GVDetail.GetRowCellValue(i, "ol_store_id").ToString.Trim
            Dim sales_order_det_qty As String = decimalSQL(GVDetail.GetRowCellValue(i, "sales_order_det_qty").ToString)
            Dim sales_order_det_note As String = ""
            Dim query_det As String = "INSERT tb_sales_order_det(id_sales_order, id_product, id_design_price, design_price, 
            item_id, ol_store_id, sales_order_det_qty, sales_order_det_note, ol_store_sku) 
            VALUES('" + id_order_last + "', '" + id_product + "', '" + id_design_price + "', '" + design_price + "',
            '" + item_id + "', '" + ol_store_id + "', '" + sales_order_det_qty + "', '" + sales_order_det_note + "', '" + ol_store_sku + "'); 
            INSERT INTO tb_storage_fg(id_wh_drawer, id_storage_category, id_product, bom_unit_price, report_mark_type, id_report, storage_product_qty, storage_product_datetime, storage_product_notes, id_stock_status) 
            VALUES('" + id_wh_drawer + "', 2, '" + id_product + "', '" + design_cop + "', 39, '" + id_order_last + "', '" + sales_order_det_qty + "', NOW(), '', 2); "
            execute_non_query(query_det, True, "", "", "", "")

            'initial 
            order_last = sales_order_ol_shop_number
        Next
    End Sub
End Class