Public Class FormOLStoreOOSDetail
    Public id As String = "-1"
    Public id_type As String = "-1"
    Dim id_comp_group As String = "-1"
    Dim id_order As String = "-1"
    Dim id_ol_store_oos_stt As String = "-1"
    Dim id_role_super_user As String = get_setup_field("id_role_super_admin")
    Dim id_api_type As String = "-1"
    Dim id_report_status As String = "-1"
    Public is_view As String = "-1"


    Private Sub FormOLStoreOOSDetail_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        actionLoad()
    End Sub

    Sub actionLoad()
        Cursor = Cursors.WaitCursor
        Dim oos As New ClassOLStore()
        Dim data As DataTable = oos.viewListOOS("AND os.id_ol_store_oos='" + id + "' ")
        TxtOOSNo.Text = data.Rows(0)("number").ToString
        TxtMarketplaceName.Text = data.Rows(0)("comp_group").ToString
        TxtOrderNo.Text = data.Rows(0)("order_number").ToString
        TxtCustomer.Text = data.Rows(0)("customer_name").ToString
        id_ol_store_oos_stt = data.Rows(0)("id_ol_store_oos_stt").ToString
        id_comp_group = data.Rows(0)("id_comp_group").ToString
        id_order = data.Rows(0)("id_order").ToString
        id_api_type = data.Rows(0)("id_api_type").ToString
        allowStatus()
        viewProductList()
        viewRestockList()
        Cursor = Cursors.Default
    End Sub

    Sub viewProductList()
        Cursor = Cursors.WaitCursor
        Dim query As String = "SELECT od.id_product, p.product_full_code AS `code`, p.product_display_name AS `name`, cd.code_detail_name AS `size`,
        SUM(od.ol_order_qty) AS `order_qty`,SUM(od.sales_order_det_qty) AS `so_qty`, IFNULL(st.reserved_qty,0) AS `rsv_qty`,
        (SUM(od.ol_order_qty)-SUM(od.sales_order_det_qty)) AS `no_stock_qty`, od.is_poss_replace, od.id_design_cat
        FROM tb_ol_store_order od 
        INNER JOIN tb_m_product p ON p.id_product = od.id_product
        INNER JOIN tb_m_product_code pc ON pc.id_product = p.id_product
        INNER JOIN tb_m_code_detail cd ON cd.id_code_detail = pc.id_code_detail
        LEFT JOIN (
	        SELECT f.id_product,SUM(IF(f.id_stock_status=2, (IF(f.id_storage_category=1, CONCAT('-', f.storage_product_qty), f.storage_product_qty)),0)) AS `reserved_qty`
	        FROM tb_storage_fg f
	        WHERE f.report_mark_type=278 AND f.id_report=" + id + "
	        GROUP BY f.id_product
        ) st ON st.id_product = od.id_product
        WHERE od.id_ol_store_oos=" + id + "
        GROUP BY od.id_product "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCProduct.DataSource = data
        GVProduct.BestFitColumns()
        viewRestockList()
        Cursor = Cursors.Default
    End Sub

    Sub viewRestockList()
        If GVProduct.RowCount > 0 And GVProduct.FocusedRowHandle >= 0 Then
            Cursor = Cursors.WaitCursor
            Dim query As String = "SELECT so.id_sales_order,so.sales_order_number, stt.id_prepare_status,
            SUM(sod.sales_order_det_qty) AS `qty_too`,IFNULL(t.qty_trf,0) AS `qty_trf`,
            (IFNULL(t.qty_trf,0)-SUM(sod.sales_order_det_qty)) AS `diff_qty`,
            stt.prepare_status, w.comp_number AS `acc_from`, s.comp_number AS `acc_to`
            FROM tb_sales_order so
            INNER JOIN tb_m_comp_contact sc ON sc.id_comp_contact = so.id_store_contact_to
            INNER JOIN tb_m_comp s ON s.id_comp = sc.id_comp
            INNER JOIN tb_m_comp_contact wc ON wc.id_comp_contact = so.id_warehouse_contact_to
            INNER JOIN tb_m_comp w ON w.id_comp = wc.id_comp
            INNER JOIN tb_sales_order_det sod ON sod.id_sales_order = so.id_sales_order
            INNER JOIN tb_lookup_prepare_status stt ON stt.id_prepare_status=so.id_prepare_status
            LEFT JOIN (
	            SELECT sod.id_ol_store_oos_restock,SUM(td.fg_trf_det_qty) AS `qty_trf`
	            FROM tb_sales_order so
	            INNER JOIN tb_sales_order_det sod ON sod.id_sales_order = so.id_sales_order
	            INNER JOIN tb_fg_trf_det td ON td.id_sales_order_det = sod.id_sales_order_det
	            INNER JOIN tb_fg_trf t ON t.id_fg_trf = td.id_fg_trf
	            WHERE t.id_report_status=6 AND so.id_ol_store_oos='" + id + "' AND sod.id_product='" + GVProduct.GetFocusedRowCellValue("id_product").ToString + "'
	            GROUP BY sod.id_ol_store_oos_restock
            ) t ON t.id_ol_store_oos_restock = sod.id_ol_store_oos_restock
            WHERE so.id_report_status=6 AND so.id_ol_store_oos='" + id + "' AND sod.id_product='" + GVProduct.GetFocusedRowCellValue("id_product").ToString + "'
            GROUP BY sod.id_ol_store_oos_restock "
            Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
            GCRestock.DataSource = data
            Cursor = Cursors.Default
        Else
            GCRestock.DataSource = Nothing
        End If
    End Sub

    Sub viewSyncInfo()
        Cursor = Cursors.WaitCursor
        Dim query As String = "SELECT 'no' AS is_checked, vo.id, vo.sales_order_ol_shop_number, vo.sales_order_ol_shop_date, vo.customer_name, vo.shipping_name, vo.shipping_address, vo.shipping_phone, vo.shipping_city, vo.shipping_post_code,
        vo.shipping_region, vo.payment_method, vo.tracking_code, vo.ol_store_sku, vo.ol_store_id, vo.sku, vo.design_price, vo.sales_order_det_qty, vo.is_process, IF(vo.is_process=1,'Yes', 'No') AS `is_process_view`,
        vo.note_price, vo.id_design_cat, vo.id_design_price, vo.id_product, vo.note_stock, vo.note_promo,
        vo.id_report_trf_order, vo.rmt_trf_order, trf_order.sales_order_number AS `trf_order_number`,
        vo.id_report_trf, vo.rmt_trf, trf.fg_trf_number AS `trf_number`,
        vo.id_report_order, vo.rmt_order , actual_order.sales_order_number, vo.fail_reason, vo.id_comp_group, cg.comp_group, cg.description AS `comp_group_name`
        FROM tb_ol_store_order vo
        LEFT JOIN tb_sales_order trf_order ON trf_order.id_sales_order = vo.id_report_trf_order
        LEFT JOIN tb_sales_order actual_order ON actual_order.id_sales_order = vo.id_report_order
        LEFT JOIN tb_fg_trf trf ON trf.id_fg_trf = vo.id_report_trf
        LEFT JOIN tb_m_comp_group cg ON cg.id_comp_group = vo.id_comp_group
        WHERE vo.id='" + id_order + "' AND vo.id_comp_group='" + id_comp_group + "' "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCVolcom.DataSource = data
        Cursor = Cursors.Default
    End Sub

    Sub allowStatus()
        'show button confirm restock
        If id_ol_store_oos_stt = "1" And id_type = "2" Then
            BtnConfirmRestock.Visible = True
            GridColumnbtn_restock.Visible = True
        Else
            BtnConfirmRestock.Visible = False
            GridColumnbtn_restock.Visible = False
        End If
        'show button close order
        If id_ol_store_oos_stt = "3" And id_type = "3" Then
            BtnClosedOrder.Visible = True
            BtnCancellAllOrder.Visible = True
        End If
    End Sub


    Private Sub FormOLStoreOOSDetail_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub BtnSendEmail_Click(sender As Object, e As EventArgs) Handles BtnSendEmail.Click
        Cursor = Cursors.WaitCursor
        FormOLStoreOOSManualEmail.id_ol_store_oos = id
        FormOLStoreOOSManualEmail.id_order = id_order
        FormOLStoreOOSManualEmail.id_comp_group = id_comp_group
        FormOLStoreOOSManualEmail.ShowDialog()
        Cursor = Cursors.Default
    End Sub

    Private Sub BtnLog_Click(sender As Object, e As EventArgs) Handles BtnLog.Click
        Cursor = Cursors.WaitCursor
        FormOLStoreLog.id_order = id_order
        FormOLStoreLog.id_comp_group = id_comp_group
        FormOLStoreLog.ShowDialog()
        Cursor = Cursors.Default
    End Sub

    Private Sub RestockToolStripMenuItem_Click(sender As Object, e As EventArgs)
        Cursor = Cursors.WaitCursor
        'cek masi bisa restok ato ndak

        Cursor = Cursors.Default
    End Sub

    Private Sub RepoBtnRestock_ButtonClick(sender As Object, e As DevExpress.XtraEditors.Controls.ButtonPressedEventArgs) Handles RepoBtnRestock.ButtonClick
        If GVProduct.RowCount > 0 And GVProduct.FocusedRowHandle >= 0 Then
            Cursor = Cursors.WaitCursor
            If GVProduct.GetFocusedRowCellValue("is_poss_replace").ToString = "1" And GVProduct.GetFocusedRowCellValue("no_stock_qty") > 0 Then
                FormOLStoreRestock.id_oos = id
                FormOLStoreRestock.id_product = GVProduct.GetFocusedRowCellValue("id_product").ToString
                FormOLStoreRestock.product_code = GVProduct.GetFocusedRowCellValue("code").ToString
                FormOLStoreRestock.product_name = GVProduct.GetFocusedRowCellValue("name").ToString
                FormOLStoreRestock.product_size = GVProduct.GetFocusedRowCellValue("size").ToString
                FormOLStoreRestock.id_design_cat = GVProduct.GetFocusedRowCellValue("id_design_cat").ToString
                FormOLStoreRestock.id_comp_group = id_comp_group
                FormOLStoreRestock.id_web_order = id_order
                FormOLStoreRestock.ShowDialog()
                viewProductList()
            Else
                stopCustom("Can't restock")
            End If
            Cursor = Cursors.Default
        End If
    End Sub

    Private Sub BtnConfirmRestock_Click(sender As Object, e As EventArgs) Handles BtnConfirmRestock.Click
        Cursor = Cursors.WaitCursor
        'cek open too restock
        Dim oos As New ClassOLStore()
        Dim is_open_restock As Boolean = oos.isRestockOpen(id)
        'cek no stock
        Dim is_no_stock As Boolean = oos.adaNoStock(id_order, id_comp_group)
        'cek fulfill
        Dim is_partial_order As Boolean = oos.isPartialOrder(id_order, id_comp_group)
        'cek valid fullfill & reserved qty
        Dim is_valid_fullfill As Boolean = oos.isValidFullfill(id_order, id_comp_group, id)
        Console.WriteLine(is_open_restock)
        Console.WriteLine(is_no_stock)
        Console.WriteLine(is_partial_order)
        Console.WriteLine(is_valid_fullfill)
        'jika tidak ada yang open restock & tidak ada no stock & valid fulfill lansung sync
        'decision : create SO
        If Not is_open_restock And Not is_no_stock And is_valid_fullfill Then
            Dim confirm As DialogResult = DevExpress.XtraEditors.XtraMessageBox.Show("Decision : Create Sales Order" + System.Environment.NewLine + "Are you sure you want to continue this process?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
            If confirm = Windows.Forms.DialogResult.Yes Then
                'cek on process sync
                Dim is_processed_order As String = get_setup_field("is_processed_order")
                If is_processed_order = "1" Then
                    stopCustom("Sync still running")
                    Cursor = Cursors.Default
                Else
                    If Not FormMain.SplashScreenManager1.IsSplashFormVisible Then
                        FormMain.SplashScreenManager1.ShowWaitForm()
                    End If
                    Dim ord As New ClassSalesOrder()
                    ord.setProceccedWebOrder("1")

                    FormMain.SplashScreenManager1.SetWaitFormDescription("Processing order")
                    Dim err_sync As String = ""
                    Try
                        Dim qry As String = "CALL create_oos_close_stock_grp('" + id + "', '" + id_order + "', '" + id_comp_group + "');CALL create_oos_sync_grp(" + id_order + ", " + id_comp_group + ", " + id + ",4);"
                        execute_non_query_long(qry, True, "", "", "", "")
                    Catch ex As Exception
                        err_sync = addSlashes(ex.ToString)
                        ord.insertLogWebOrder(id_order, "Problem closing order :" + addSlashes(ex.ToString), id_comp_group)
                    End Try


                    'other action
                    FormMain.SplashScreenManager1.SetWaitFormDescription("Other action")
                    Dim err_other_act As String = ""
                    If id_api_type = "2" Then
                        'ZALORA
                        Try
                            Dim zal As New ClassZaloraApi()
                            err_other_act = zal.setRTSPending()
                        Catch ex As Exception
                            err_other_act = "Problem set RTS :" + addSlashes(ex.ToString)
                            ord.insertLogWebOrder(id_order, err_other_act, id_comp_group)
                        End Try
                    End If

                    ord.setProceccedWebOrder("2")
                    FormMain.SplashScreenManager1.CloseWaitForm()
                    FormOLStoreOOS.LEProgress.ItemIndex = FormOLStoreOOS.LEProgress.Properties.GetDataSourceRowIndex("id_ol_store_oos_stt", "0")
                    FormOLStoreOOS.viewData()
                    If err_other_act = "" And err_sync = "" Then
                        infoCustom("Order created successfully")
                        Close()
                    Else
                        actionLoad()
                        stopCustom("There is problem when processing order, please see log.")
                    End If
                End If
            End If
        End If

        'jika tidak ada yang open restock
        ' ada no stock
        ' ada fulfill
        ' valid fullfill
        'decision : email no stock partial item
        If Not is_open_restock And is_no_stock And is_partial_order And is_valid_fullfill Then
            Dim confirm As DialogResult = DevExpress.XtraEditors.XtraMessageBox.Show("Decision : Send email confirmation partial item no stock" + System.Environment.NewLine + "Are you sure you want to continue this process?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
            If confirm = Windows.Forms.DialogResult.Yes Then
                If Not FormMain.SplashScreenManager1.IsSplashFormVisible Then
                    FormMain.SplashScreenManager1.ShowWaitForm()
                End If
                Dim ord As New ClassSalesOrder()

                FormMain.SplashScreenManager1.SetWaitFormDescription("Sending email no stock")
                Dim err_send As String = ""
                Try
                    oos.sendEmailOOS(id_order, id_comp_group)
                    execute_non_query("UPDATE tb_ol_store_oos SET id_ol_store_oos_stt=3, sent_email_date=NOW() WHERE id_ol_store_oos='" + id + "' ", True, "", "", "", "")
                    ord.insertLogWebOrder(id_order, "Evaluate result : No stock;Send Email OOS success; Status=email sent", id_comp_group)
                Catch ex As Exception
                    err_send = addSlashes(ex.ToString)
                    ord.insertLogWebOrder(id_order, "Evaluate result : No stock & Send Email OOS failed. Detail:" + err_send, id_comp_group)
                End Try

                FormMain.SplashScreenManager1.CloseWaitForm()
                FormOLStoreOOS.LEProgress.ItemIndex = FormOLStoreOOS.LEProgress.Properties.GetDataSourceRowIndex("id_ol_store_oos_stt", "0")
                FormOLStoreOOS.viewData()
                If err_send = "" Then
                    infoCustom("Email sent successfully")
                    Close()
                Else
                    actionLoad()
                    stopCustom("There is problem when sending email, please see log.")
                End If
            End If
        End If

        'jika tidak ada yang open restock
        ' semua no stock
        ' ada fulfill
        ' valid fullfill
        'decision : email & close order 
        If Not is_open_restock And is_no_stock And Not is_partial_order And is_valid_fullfill Then
            Dim confirm As DialogResult = DevExpress.XtraEditors.XtraMessageBox.Show("Decision : Send email confirmation all items no stock & closed order" + System.Environment.NewLine + "Are you sure you want to continue this process?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
            If confirm = Windows.Forms.DialogResult.Yes Then
                'cek on process sync
                Dim is_processed_order As String = get_setup_field("is_processed_order")
                If is_processed_order = "1" Then
                    stopCustom("Sync still running")
                    Cursor = Cursors.Default
                Else
                    If Not FormMain.SplashScreenManager1.IsSplashFormVisible Then
                        FormMain.SplashScreenManager1.ShowWaitForm()
                    End If
                    Dim ord As New ClassSalesOrder()

                    'email confirmation
                    FormMain.SplashScreenManager1.SetWaitFormDescription("Sending email no stock")
                    Dim err_send As String = ""
                    Try
                        oos.sendEmailOOS(id_order, id_comp_group)
                        execute_non_query("UPDATE tb_ol_store_oos SET id_ol_store_oos_stt=3, sent_email_date=NOW() WHERE id_ol_store_oos='" + id + "' ", True, "", "", "", "")
                        ord.insertLogWebOrder(id_order, "Evaluate result : No stock;Send Email OOS success; Status=email sent", id_comp_group)
                    Catch ex As Exception
                        err_send = addSlashes(ex.ToString)
                        ord.insertLogWebOrder(id_order, "Evaluate result : No stock & Send Email OOS failed. Detail:" + err_send, id_comp_group)
                    End Try

                    'close order
                    'code here
                    'check jika kosong langsung di closed
                    FormMain.SplashScreenManager1.SetWaitFormDescription("Closing order")
                    Dim err_close As String = ""
                    Try
                        oos.checkOOSEmptyOrder(id_order, id_comp_group)
                    Catch ex As Exception
                        err_close = addSlashes(ex.ToString)
                        ord.insertLogWebOrder(id_order, "Failed close order :" + err_close, id_comp_group)
                    End Try


                    'other action
                    Dim err_other_act As String = ""
                    If id_api_type = "2" Then
                        'ZALORA
                        FormMain.SplashScreenManager1.SetWaitFormDescription("Set to ready to ship")
                        Try
                            Dim zal As New ClassZaloraApi()
                            err_other_act = zal.setRTSPending()
                        Catch ex As Exception
                            err_other_act = addSlashes(ex.ToString)
                            ord.insertLogWebOrder(id_order, "Failed set rts :" + err_other_act, id_comp_group)
                        End Try
                    End If

                    ord.setProceccedWebOrder("2")
                    FormMain.SplashScreenManager1.CloseWaitForm()
                    FormOLStoreOOS.LEProgress.ItemIndex = FormOLStoreOOS.LEProgress.Properties.GetDataSourceRowIndex("id_ol_store_oos_stt", "0")
                    FormOLStoreOOS.viewData()
                    If err_send = "" And err_close = "" And err_other_act = "" Then
                        infoCustom("Email sent successfully and order has been cancelled")
                        Close()
                    Else
                        actionLoad()
                        stopCustom("There is problem, please see log.")
                    End If
                End If
            End If
        End If

        'on process restock
        If is_open_restock Then
            Dim confirm As DialogResult = DevExpress.XtraEditors.XtraMessageBox.Show("Decision : Processing restock in WH" + System.Environment.NewLine + "Are you sure you want to continue this process?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
            If confirm = Windows.Forms.DialogResult.Yes Then
                Dim query As String = "UPDATE tb_ol_store_oos SET id_ol_store_oos_stt=2 WHERE id_ol_store_oos='" + id + "' "
                execute_non_query(query, True, "", "", "", "")
                FormOLStoreOOS.viewData()
                Close()
            End If
        End If
        Cursor = Cursors.Default
    End Sub

    Private Sub FormOLStoreOOSDetail_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.F7 Then
            'show button email
            If id_role_super_user = id_role_login Then
                BtnSendEmail.Visible = True
            End If
        End If
    End Sub

    Private Sub BtnPrintProduct_Click(sender As Object, e As EventArgs) Handles BtnPrintProduct.Click
        Cursor = Cursors.WaitCursor
        print(GCProduct, "Product List")
        Cursor = Cursors.Default
    End Sub

    Private Sub SimpleButton2_Click(sender As Object, e As EventArgs) Handles BtnPrintDetailOrder.Click
        Cursor = Cursors.WaitCursor
        print(GCVolcom, "Sync Info")
        Cursor = Cursors.Default
    End Sub

    Private Sub BtnPrintSyncList_Click(sender As Object, e As EventArgs) Handles BtnPrintSyncList.Click
        Cursor = Cursors.WaitCursor
        print(GCRestock, "Restock Detail")
        Cursor = Cursors.Default
    End Sub

    Private Sub GVProduct_FocusedRowChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles GVProduct.FocusedRowChanged
        viewRestockList()
    End Sub

    Private Sub GVProduct_ColumnFilterChanged(sender As Object, e As EventArgs) Handles GVProduct.ColumnFilterChanged
        viewRestockList()
    End Sub

    Private Sub XTCData_SelectedPageChanged(sender As Object, e As DevExpress.XtraTab.TabPageChangedEventArgs) Handles XTCData.SelectedPageChanged
        If XTCData.SelectedTabPageIndex = 1 Then
            viewSyncInfo()
        End If
    End Sub

    Private Sub BtnClosedOrder_Click(sender As Object, e As EventArgs) Handles BtnClosedOrder.Click
        Cursor = Cursors.WaitCursor
        'cek attachment
        If Not isValidAttachment() Then
            Cursor = Cursors.Default
            warningCustom("Please attach supporting document first")
            showAttachment()
            Exit Sub
        End If

        'cek open too restock
        Dim oos As New ClassOLStore()
        Dim is_open_restock As Boolean = oos.isRestockOpen(id)
        'cek valid fullfill & reserved qty
        Dim is_valid_fullfill As Boolean = oos.isValidFullfill(id_order, id_comp_group, id)

        If Not is_open_restock And is_valid_fullfill Then
            Dim confirm As DialogResult = DevExpress.XtraEditors.XtraMessageBox.Show("Decision : Create Sales Order with partial items" + System.Environment.NewLine + "Are you sure you want to continue this process?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
            If confirm = Windows.Forms.DialogResult.Yes Then
                'cek on process sync
                Dim is_processed_order As String = get_setup_field("is_processed_order")
                If is_processed_order = "1" Then
                    stopCustom("Sync still running")
                    Cursor = Cursors.Default
                Else
                    If Not FormMain.SplashScreenManager1.IsSplashFormVisible Then
                        FormMain.SplashScreenManager1.ShowWaitForm()
                    End If
                    Dim ord As New ClassSalesOrder()
                    ord.setProceccedWebOrder("1")

                    FormMain.SplashScreenManager1.SetWaitFormDescription("Processing order")
                    Dim err_sync As String = ""
                    Try
                        Dim qry As String = "CALL create_oos_close_stock_grp('" + id + "', '" + id_order + "', '" + id_comp_group + "');CALL create_oos_sync_grp(" + id_order + ", " + id_comp_group + ", " + id + ",4);"
                        execute_non_query_long(qry, True, "", "", "", "")
                    Catch ex As Exception
                        err_sync = addSlashes(ex.ToString)
                        ord.insertLogWebOrder(id_order, "Problem closing order :" + addSlashes(ex.ToString), id_comp_group)
                    End Try

                    'other action
                    FormMain.SplashScreenManager1.SetWaitFormDescription("Other action")
                    Dim err_other_act As String = ""
                    If id_api_type = "2" Then
                        'ZALORA
                        Try
                            Dim zal As New ClassZaloraApi()
                            err_other_act = zal.setRTSPending()
                        Catch ex As Exception
                            err_other_act = "Problem set RTS :" + addSlashes(ex.ToString)
                            ord.insertLogWebOrder(id_order, err_other_act, id_comp_group)
                        End Try
                    End If

                    ord.setProceccedWebOrder("2")
                    FormMain.SplashScreenManager1.CloseWaitForm()
                    FormOLStoreOOS.viewData()
                    If err_other_act = "" And err_sync = "" Then
                        infoCustom("Order created successfully")
                        Close()
                    Else
                        actionLoad()
                        stopCustom("There is problem when processing order, please see log.")
                    End If
                End If
            End If
            Else
                stopCustom("Can't proceed this order. Make sure restock in WH already finished")
        End If
        Cursor = Cursors.Default
    End Sub

    Private Sub BtnCancellAllOrder_Click(sender As Object, e As EventArgs) Handles BtnCancellAllOrder.Click
        Cursor = Cursors.WaitCursor
        'cek attachment
        If Not isValidAttachment() Then
            Cursor = Cursors.Default
            warningCustom("Please attach supporting document first")
            showAttachment()
            Exit Sub
        End If

        'cek open too restock
        Dim oos As New ClassOLStore()
        Dim is_open_restock As Boolean = oos.isRestockOpen(id)
        If Not is_open_restock Then
            Dim confirm As DialogResult = DevExpress.XtraEditors.XtraMessageBox.Show("Decision : Cancel order" + System.Environment.NewLine + "Are you sure you want to continue this process?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
            If confirm = Windows.Forms.DialogResult.Yes Then
                'cek on process sync
                Dim is_processed_order As String = get_setup_field("is_processed_order")
                If is_processed_order = "1" Then
                    stopCustom("Sync still running")
                    Cursor = Cursors.Default
                Else
                    If Not FormMain.SplashScreenManager1.IsSplashFormVisible Then
                        FormMain.SplashScreenManager1.ShowWaitForm()
                    End If
                    Dim ord As New ClassSalesOrder()
                    ord.setProceccedWebOrder("1")

                    'closign stock
                    FormMain.SplashScreenManager1.SetWaitFormDescription("Closing stock")
                    Dim err_close_stock As String = ""
                    Try
                        Dim query_close As String = "CALL create_oos_close_stock_grp('" + id + "', '" + id_order + "', '" + id_comp_group + "');
                        UPDATE tb_ol_store_order SET sales_order_det_qty=0 WHERE id='" + id_order + "' AND id_comp_group='" + id_comp_group + "';  "
                        execute_non_query_long(query_close, True, "", "", "", "")
                    Catch ex As Exception
                        err_close_stock = addSlashes(ex.ToString)
                        ord.insertLogWebOrder(id_order, "Problem closing stock :" + err_close_stock, id_comp_group)
                    End Try

                    'closing & cancel order
                    FormMain.SplashScreenManager1.SetWaitFormDescription("Closing order")
                    Dim err_close_order As String = ""
                    Try
                        oos.checkOOSEmptyOrder(id_order, id_comp_group)
                    Catch ex As Exception
                        err_close_order = addSlashes(ex.ToString)
                        ord.insertLogWebOrder(id_order, "Failed close order :" + err_close_order, id_comp_group)
                    End Try

                    'other action
                    Dim err_other_act As String = ""
                    If id_api_type = "2" Then
                        'ZALORA
                        FormMain.SplashScreenManager1.SetWaitFormDescription("Set to ready to ship")
                        Try
                            Dim zal As New ClassZaloraApi()
                            err_other_act = zal.setRTSPending()
                        Catch ex As Exception
                            err_other_act = addSlashes(ex.ToString)
                            ord.insertLogWebOrder(id_order, "Failed set rts :" + err_other_act, id_comp_group)
                        End Try
                    End If

                    ord.setProceccedWebOrder("2")
                    FormMain.SplashScreenManager1.CloseWaitForm()
                    FormOLStoreOOS.viewData()
                    If err_close_stock = "" And err_close_order = "" And err_other_act = "" Then
                        infoCustom("Order has been cancelled")
                        Close()
                    Else
                        actionLoad()
                        stopCustom("There is problem, please see log.")
                    End If
                End If
            End If
        Else
            stopCustom("Can't proceed this order. Make sure restock in WH already finished")
        End If

        Cursor = Cursors.Default
    End Sub

    Private Sub BtnAttachment_Click(sender As Object, e As EventArgs) Handles BtnAttachment.Click
        showAttachment()
    End Sub

    Sub showAttachment()
        Cursor = Cursors.WaitCursor
        FormDocumentUpload.report_mark_type = "278"
        FormDocumentUpload.id_report = id
        FormDocumentUpload.is_no_delete = "1"
        FormDocumentUpload.is_view = is_view
        FormDocumentUpload.ShowDialog()
        Cursor = Cursors.Default
    End Sub

    Function isValidAttachment() As Boolean
        Dim query As String = "SELECT * FROM tb_doc d WHERE d.report_mark_type=278 AND d.id_report='" + id + "' "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        If data.Rows.Count > 0 Then
            Return True
        Else
            Return False
        End If
    End Function
End Class