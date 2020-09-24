Public Class FormSalesDelOrder 
    Dim bnew_active As String = "1"
    Dim bedit_active As String = "1"
    Dim bdel_active As String = "1"
    Public id_sales_order_gen As String = "-1"
    Dim is_all_order As Boolean = True

    Private Sub FormSalesDelOrder_Activated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Activated
        FormMain.show_rb(Name)
        check_menu()
    End Sub

    Private Sub FormSalesDelOrder_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'date now
        Dim data As DataTable = execute_query("SELECT DATE(NOW()) AS `tgl`", -1, True, "", "", "", "")
        DEFrom.EditValue = data.Rows(0)("tgl")
        DEUntil.EditValue = data.Rows(0)("tgl")

        'load prepare listt
        viewSalesOrder()

        'set notif load
        TimerMonitor.Interval = Integer.Parse(get_setup_field("load_notif"))
    End Sub

    Sub viewSalesOrder()
        Cursor = Cursors.WaitCursor
        Dim query_c As ClassSalesOrder = New ClassSalesOrder()
        Dim query As String = "SELECT a.id_sales_order, a.id_store_contact_to, d.id_commerce_type,d.id_comp AS `id_store`, d.is_use_unique_code, d.id_store_type, d.comp_number AS `store_number`, d.comp_name AS `store`, d.address_primary as `store_address`, CONCAT(d.comp_number,' - ',d.comp_name) AS store_name_to,a.id_report_status, f.report_status, a.id_warehouse_contact_to, CONCAT(wh.comp_number,' - ',wh.comp_name) AS warehouse_name_to, (wh.comp_number) AS warehouse_number_to,  (wh.comp_name) AS `warehouse`, wh.id_drawer_def AS `id_wh_drawer`, drw.wh_drawer_code, drw.wh_drawer, 
        a.sales_order_note, a.sales_order_date, a.sales_order_note, a.sales_order_number, a.sales_order_ol_shop_number, a.sales_order_ol_shop_date, 
        (a.sales_order_date) AS sales_order_date, 
        ps.id_prepare_status, ps.prepare_status, ('No') AS `is_select`, cat.id_so_status, cat.so_status, ot.order_type, del_cat.id_so_cat, del_cat.so_cat, IFNULL(so_item.tot_so,0.00) AS `total_order`, 
        CAST((IFNULL(dord_item.tot_do, 0.00)/IFNULL(so_item.tot_so,0.00)*100) AS DECIMAL(5,2)) AS so_completness,  
        a.id_so_type,prep.id_user, prep.prepared_date, 
        IFNULL(crt.created, 0) AS created_process, 
        gen.id_sales_order_gen, IFNULL(gen.sales_order_gen_reff, '-') AS `sales_order_gen_reff`, a.final_comment, a.final_date, fe.employee_name AS `final_by_name`, eu.period_name, ut.uni_type, ube.employee_code, ube.employee_name, 
        lp.printed_date, IFNULL(lp.printed_by,'-') AS `printed_by`, IFNULL(pri.indeks_order,0) AS `indeks_order`
        FROM tb_sales_order a 
        INNER JOIN tb_m_comp_contact c ON c.id_comp_contact = a.id_store_contact_to 
        INNER JOIN tb_m_comp d ON c.id_comp = d.id_comp 
        INNER JOIN tb_m_comp_group cg ON cg.id_comp_group = d.id_comp_group
        INNER JOIN tb_m_comp_contact wh_c ON wh_c.id_comp_contact = a.id_warehouse_contact_to 
        INNER JOIN tb_m_comp wh ON wh_c.id_comp = wh.id_comp 
        INNER JOIN tb_lookup_report_status f ON f.id_report_status = a.id_report_status 
        INNER JOIN tb_lookup_prepare_status ps ON ps.id_prepare_status = a.id_prepare_status 
        INNER JOIN tb_lookup_so_status cat ON cat.id_so_status = a.id_so_status 
        INNER JOIN tb_lookup_order_type ot ON ot.id_order_type = cat.id_order_type 
        LEFT JOIN ( 
	        SELECT so_det.id_sales_order, SUM(so_det.sales_order_det_qty) AS tot_so  
	        FROM tb_sales_order_det so_det 
	        GROUP BY so_det.id_sales_order 
        ) so_item ON so_item.id_sales_order = a.id_sales_order 
        LEFT JOIN ( 
	        SELECT dord.id_sales_order, SUM(dord_det.pl_sales_order_del_det_qty) AS tot_do 
	        FROM tb_pl_sales_order_del_det dord_det 
	        INNER JOIN tb_pl_sales_order_del dord ON dord.id_pl_sales_order_del = dord_det.id_pl_sales_order_del 
	        WHERE dord.id_report_status!='5' 
	        GROUP BY dord.id_sales_order 
        ) dord_item ON dord_item.id_sales_order = a.id_sales_order 
        Left Join( 
	        Select a.id_report, a.id_user, a.report_mark_datetime AS `prepared_date` 
	        From tb_report_mark a 
	        Where a.report_mark_type ='39' and a.id_report_status='1' 
	        group by a.id_report 
        ) prep On prep.id_report = a.id_sales_order 
        LEFT JOIN tb_lookup_pd_alloc alloc On alloc.id_pd_alloc = d.id_pd_alloc 
        LEFT JOIN tb_lookup_so_cat del_cat On del_cat.id_so_cat = alloc.id_so_cat 
        Left Join( 
	        Select id_sales_order, COUNT(*) As created FROM tb_pl_sales_order_del GROUP BY id_sales_order 
        ) crt On crt.id_sales_order = a.id_sales_order 
        LEFT JOIN tb_sales_order_gen gen ON gen.id_sales_order_gen = a.id_sales_order_gen 
        LEFT JOIN tb_m_wh_drawer drw ON drw.id_wh_drawer = wh.id_drawer_def  
        LEFT JOIN tb_m_user fu ON fu.id_user = a.final_by 
        LEFT JOIN tb_m_employee fe ON fe.id_employee = fu.id_employee 
        LEFT JOIN tb_emp_uni_period eu ON eu.id_emp_uni_period=a.id_emp_uni_period 
        LEFT JOIN tb_lookup_uni_type ut ON ut.id_uni_type = a.id_uni_type 
        LEFT JOIN tb_emp_uni_budget ub ON ub.id_emp_uni_budget = a.id_emp_uni_budget
        LEFT JOIN tb_m_employee ube ON ube.id_employee = ub.id_employee 
        LEFT JOIN (
           SELECT a.id_sales_order, a.log_date AS `printed_date`, e.employee_name AS `printed_by` 
           FROM (
              SELECT * FROM tb_sales_order_log_print lp
              ORDER BY lp.log_date ASC
           ) a 
           INNER JOIN tb_m_user u ON u.id_user = a.id_user
           INNER JOIN tb_m_employee e ON e.id_employee = u.id_employee
           GROUP BY a.id_sales_order
        ) lp ON lp.id_sales_order = a.id_sales_order 
        LEFT JOIN tb_store_priority_order pri ON pri.id_comp = d.id_comp
        WHERE a.id_sales_order>0 
        AND a.id_so_status!=5 AND a.id_report_status='6' AND a.id_prepare_status='1' 
        HAVING so_completness<100
        ORDER BY indeks_order ASC, id_sales_order ASC "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCSalesOrder.DataSource = data
        GVSalesOrder.BestFitColumns()
        GridColumnEmpCode.Visible = False
        GridColumnEmpName.Visible = False
        Cursor = Cursors.Default
    End Sub

    Sub viewUniformOrder()
        Dim query_c As ClassSalesOrder = New ClassSalesOrder()
        Dim query As String = query_c.queryMain("AND a.id_so_status=7 AND a.id_report_status='6' AND a.id_prepare_status='1' ", "1")
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCSalesOrder.DataSource = data
        GridColumnEmpCode.VisibleIndex = 1
        GridColumnEmpName.VisibleIndex = 2
    End Sub

    Sub viewSalesDelOrder()
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

        Dim query_c As ClassSalesDelOrder = New ClassSalesDelOrder()
        Dim query As String = query_c.queryMainLess("AND (a.pl_sales_order_del_date>='" + date_from_selected + "' AND a.pl_sales_order_del_date<='" + date_until_selected + "') ", "2")
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCSalesDelOrder.DataSource = data
        GVSalesDelOrder.BestFitColumns()
        check_menu()
    End Sub

    Private Sub FormSalesDelOrder_Deactivate(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Deactivate
        FormMain.hide_rb()
    End Sub

    Sub noManipulating()
        If XTCDO.SelectedTabPageIndex = 0 Then
            Dim indeks As Integer = 0
            Try
                indeks = GVSalesDelOrder.FocusedRowHandle
            Catch ex As Exception
            End Try
            If indeks < 0 Then
                bnew_active = "1"
                bedit_active = "0"
                bdel_active = "0"
            Else
                bnew_active = "1"
                bedit_active = "1"
                bdel_active = "1"
            End If
        ElseIf XTCDO.SelectedTabPageIndex = 1 Then
            Dim indeks As Integer = 0
            Try
                indeks = GVSalesOrder.FocusedRowHandle
            Catch ex As Exception
            End Try
            If indeks < 0 Then
                bnew_active = "0"
                bedit_active = "0"
                bdel_active = "0"
            Else
                bnew_active = "1"
                bedit_active = "0"
                bdel_active = "0"
            End If
        End If
        checkFormAccess(Name)
        button_main(bnew_active, bedit_active, bdel_active)
    End Sub

    Sub check_menu()
        If XTCDO.SelectedTabPageIndex = 0 Then
            'based on receive
            If GVSalesDelOrder.RowCount < 1 Then
                'hide all except new
                bnew_active = "1"
                bedit_active = "0"
                bdel_active = "0"
                checkFormAccess(Name)
                button_main(bnew_active, bedit_active, bdel_active)
                noManipulating()
            Else
                'show all
                bnew_active = "1"
                bedit_active = "1"
                bdel_active = "1"
                checkFormAccess(Name)
                button_main(bnew_active, bedit_active, bdel_active)
                noManipulating()
            End If
        ElseIf XTCDO.SelectedTabPageIndex = 1 Then
            'based on SO
            If GVSalesOrder.RowCount < 1 Then
                'hide all except new
                bnew_active = "0"
                bedit_active = "0"
                bdel_active = "0"
                checkFormAccess(Name)
                button_main(bnew_active, bedit_active, bdel_active)
            Else
                'show all
                bnew_active = "1"
                bedit_active = "0"
                bdel_active = "0"
                noManipulating()
            End If
        ElseIf XTCDO.SelectedTabPageIndex = 2 Then
            bnew_active = "0"
            bedit_active = "0"
            bdel_active = "0"
            checkFormAccess(Name)
            button_main(bnew_active, bedit_active, bdel_active)
        End If
    End Sub

    Private Sub GVSalesDelOrder_FocusedRowChanged(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles GVSalesDelOrder.FocusedRowChanged
        noManipulating()
    End Sub

    Private Sub XTCSalesDelOrder_SelectedPageChanged(ByVal sender As System.Object, ByVal e As DevExpress.XtraTab.TabPageChangedEventArgs) Handles XTCSalesDelOrder.SelectedPageChanged
        check_menu()
    End Sub

    Private Sub GVSalesOrder_FocusedRowChanged(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs)
        noManipulating()
    End Sub

    Private Sub GVItemList_FocusedRowChanged(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs)

    End Sub

    Private Sub GVItemList_CustomColumnDisplayText(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs)
        If e.Column.FieldName = "no" Then
            e.DisplayText = (e.ListSourceRowIndex + 1).ToString()
        End If
    End Sub

    Private Sub GVSalesDelOrder_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GVSalesDelOrder.DoubleClick
        If GVSalesDelOrder.RowCount > 0 Then
            FormMain.but_edit()
        End If
    End Sub

    Private Sub GVSalesDelOrder_PopupMenuShowing(sender As Object, e As DevExpress.XtraGrid.Views.Grid.PopupMenuShowingEventArgs) Handles GVSalesDelOrder.PopupMenuShowing
        If GVSalesDelOrder.RowCount > 0 And GVSalesDelOrder.FocusedRowHandle >= 0 Then
            Dim id_stt As String = GVSalesDelOrder.GetFocusedRowCellValue("id_report_status").ToString
            If id_stt <> "3" And id_stt <> "4" And id_stt <> "6" Then
                SMPrint.Visible = False
            Else
                SMPrint.Visible = True
            End If

            If id_stt <> "1" And id_stt <> "2" And id_stt <> "3" And id_stt <> "4" And id_stt <> "6" Then
                SMPrePrint.Visible = False
            Else
                SMPrePrint.Visible = True
            End If
            Dim view As DevExpress.XtraGrid.Views.Grid.GridView = CType(sender, DevExpress.XtraGrid.Views.Grid.GridView)
            Dim hitInfo As DevExpress.XtraGrid.Views.Grid.ViewInfo.GridHitInfo = view.CalcHitInfo(e.Point)
            If hitInfo.InRow And hitInfo.RowHandle >= 0 Then
                view.FocusedRowHandle = hitInfo.RowHandle
                ViewMenu.Show(view.GridControl, e.Point)
            End If
        End If
    End Sub

    Private Sub SMPrePrint_Click(sender As Object, e As EventArgs) Handles SMPrePrint.Click
        Cursor = Cursors.WaitCursor
        FormSalesDelOrderDet.id_pre = "1"
        FormMain.but_edit()
        Cursor = Cursors.Default
    End Sub

    Private Sub SMPrint_Click(sender As Object, e As EventArgs) Handles SMPrint.Click
        Cursor = Cursors.WaitCursor
        If XTCDO.SelectedTabPageIndex = 0 Then
            FormSalesDelOrderDet.id_pre = "2"
            FormMain.but_edit()
        Else
            If GVSalesOrder.FocusedRowHandle >= 0 And GVSalesOrder.RowCount > 0 Then
                Dim id As String = GVSalesOrder.GetFocusedRowCellValue("id_sales_order").ToString
                FormViewSalesOrder.id_sales_order = id
                FormViewSalesOrder.is_print = "1"
                FormViewSalesOrder.ShowDialog()
                If is_all_order Then
                    viewSalesOrder()
                Else
                    viewUniformOrder()
                End If
                GVSalesOrder.FocusedRowHandle = find_row(GVSalesOrder, "id_sales_order", id)
            End If
        End If
        Cursor = Cursors.Default
    End Sub

    Private Sub BtnViewNewPrepare_Click(sender As Object, e As EventArgs) Handles BtnViewNewPrepare.Click
        viewrRef()
    End Sub

    Sub viewrRef()
        Cursor = Cursors.WaitCursor
        Dim val As String = addSlashes(TxtNoParam.Text.ToString)
        If val = "" Then
            errorCustom("Data not found !")
        Else
            If id_sales_order_gen = "-1" Then
                Dim query As String = "SELECT id_sales_order_gen FROM tb_sales_order_gen WHERE sales_order_gen_reff='" + val + "' AND id_so_status<>5 LIMIT 1 "
                id_sales_order_gen = "-1"
                Try
                    id_sales_order_gen = execute_query(query, 0, True, "", "", "", "")
                Catch ex As Exception
                End Try
            End If

            If id_sales_order_gen = "-1" Then
                errorCustom("Data not found !")
                GCNewPrepare.DataSource = Nothing
            Else
                Dim rf As New ClassSalesOrder()
                rf.viewReff(id_sales_order_gen, "-1", GCNewPrepare, GVNewPrepare)
                id_sales_order_gen = "-1"
            End If
        End If
        Cursor = Cursors.Default
    End Sub

    Private Sub TxtNoParam_KeyDown(sender As Object, e As KeyEventArgs) Handles TxtNoParam.KeyDown
        If e.KeyCode = Keys.Enter Then
            viewrRef()
        End If
    End Sub

    Private Sub XTCDO_SelectedPageChanged(sender As Object, e As DevExpress.XtraTab.TabPageChangedEventArgs) Handles XTCDO.SelectedPageChanged
        check_menu()
        If XTCDO.SelectedTabPageIndex = 0 Then
            SMPrePrint.Visible = True
        ElseIf XTCDO.SelectedTabPageIndex = 1 Then
            SMPrePrint.Visible = False
            GVSalesOrder.ShowFindPanel()
            GVSalesOrder.ShowFindPanel()
        ElseIf XTCDO.SelectedTabPageIndex = 2 Then
            TxtNoParam.Focus()
        End If
    End Sub

    Private Sub TxtNoParam_ButtonClick(sender As Object, e As DevExpress.XtraEditors.Controls.ButtonPressedEventArgs) Handles TxtNoParam.ButtonClick
        Cursor = Cursors.WaitCursor
        FormSalesOrderRef.id_pop_up = "1"
        FormSalesOrderRef.ShowDialog()
        Cursor = Cursors.Default
    End Sub

    Private Sub TimerMonitor_Tick(sender As Object, e As EventArgs) Handles TimerMonitor.Tick
        Cursor = Cursors.WaitCursor
        viewSalesOrder()
        Cursor = Cursors.Default
    End Sub

    Private Sub CheckEditRefresh_CheckedChanged(sender As Object, e As EventArgs) Handles CheckEditRefresh.CheckedChanged
        Dim cek As String = CheckEditRefresh.EditValue.ToString
        If cek Then
            TimerMonitor.Enabled = True
        Else
            TimerMonitor.Enabled = False
        End If
    End Sub

    Private Sub GVSalesDelOrder_ColumnFilterChanged(sender As Object, e As EventArgs) Handles GVSalesDelOrder.ColumnFilterChanged
        noManipulating()
    End Sub

    Private Sub GVSalesOrder_ColumnFilterChanged(sender As Object, e As EventArgs) Handles GVSalesOrder.ColumnFilterChanged
        noManipulating()
    End Sub

    Private Sub GVSalesOrder_FocusedRowChanged_1(sender As Object, e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles GVSalesOrder.FocusedRowChanged
        noManipulating()
    End Sub

    Private Sub BtnView_Click(sender As Object, e As EventArgs) Handles BtnView.Click
        Cursor = Cursors.WaitCursor
        viewSalesDelOrder()
        Cursor = Cursors.Default
    End Sub

    Private Sub BtnCombineDel_Click(sender As Object, e As EventArgs) Handles BtnCombineDel.Click
        Cursor = Cursors.WaitCursor
        FormSalesDelOrderSlip.action = "ins"
        FormSalesDelOrderSlip.ShowDialog()
        Cursor = Cursors.Default
    End Sub

    Private Sub ViewCombinedDeliveryToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ViewCombinedDeliveryToolStripMenuItem.Click
        Dim id_combine As String = ""
        Try
            id_combine = GVSalesDelOrder.GetFocusedRowCellValue("id_combine").ToString
        Catch ex As Exception
        End Try
        If id_combine = "0" Then
            id_combine = ""
        End If
        If id_combine <> "" Then
            Cursor = Cursors.WaitCursor
            FormSalesDelOrderSlip.action = "upd"
            FormSalesDelOrderSlip.id_pl_sales_order_del_slip = id_combine
            FormSalesDelOrderSlip.ShowDialog()
            Cursor = Cursors.Default
        Else
            stopCustom("Combined delivery not found")
        End If
    End Sub

    Private Sub BtnShowUniform_Click(sender As Object, e As EventArgs) Handles BtnShowUniform.Click
        Cursor = Cursors.WaitCursor
        viewUniformOrder()
        is_all_order = False
        Cursor = Cursors.Default
    End Sub

    Private Sub BtnShowAll_Click(sender As Object, e As EventArgs) Handles BtnShowAll.Click
        Cursor = Cursors.WaitCursor
        viewSalesOrder()
        is_all_order = True
        Cursor = Cursors.Default
    End Sub

    Private Sub FileAttachmentToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles FileAttachmentToolStripMenuItem.Click
        If GVSalesOrder.RowCount > 0 And GVSalesOrder.FocusedRowHandle >= 0 Then
            Cursor = Cursors.WaitCursor
            FormDocumentUpload.report_mark_type = "39"
            FormDocumentUpload.id_report = GVSalesOrder.GetFocusedRowCellValue("id_sales_order").ToString
            FormDocumentUpload.is_view = "1"
            FormDocumentUpload.ShowDialog()
            Cursor = Cursors.Default
        End If
    End Sub

    Private Sub BtnSyncOrder_Click(sender As Object, e As EventArgs) Handles BtnSyncOrder.Click
        Cursor = Cursors.WaitCursor

        'cek freeze
        Dim qf As String = "SELECT c.id_comp ,cm.comp_number, cm.comp_name
        FROM tb_m_comp_volcom_ol c
        INNER JOIN tb_m_comp cm ON cm.id_comp = c.id_comp
        WHERE cm.is_active=2 "
        Dim df As DataTable = execute_query(qf, -1, True, "", "", "", "")
        If df.Rows.Count > 0 Then
            Cursor = Cursors.Default
            stopCustom("WH already freeze")
            Exit Sub
        End If

        Dim is_processed_order As String = get_setup_field("is_processed_order")
        If is_processed_order = "1" Then
            stopCustom("Sync still running")
        Else
            FormMain.SplashScreenManager1.ShowWaitForm()

            'cek allow
            Dim is_must_ok_stock As String = "2"
            is_must_ok_stock = "1"

            Dim ord As New ClassSalesOrder()
            ord.setProceccedWebOrder("1")
            ord.insertLogWebOrder("0", "Start")

            'get order from web
            Dim err As String = ""
            Try
                Dim shop As New ClassShopifyApi()
                shop.get_order_erp()
            Catch ex As Exception
                err = ex.ToString
            End Try
            ord.insertLogWebOrder("0", "Get order from website. " + err)

            'get order yg belum diproses
            Dim qord As String = "SELECT o.id, o.sales_order_ol_shop_number  FROM tb_ol_store_order o
            WHERE o.is_process=2
            GROUP BY o.id "
            Dim dord As DataTable = execute_query(qord, -1, True, "", "", "", "")
            If dord.Rows.Count > 0 Then
                Try
                    For i As Integer = 0 To dord.Rows.Count - 1
                        FormMain.SplashScreenManager1.SetWaitFormDescription("Checking order #" + dord.Rows(i)("sales_order_ol_shop_number").ToString)
                        execute_non_query_long("CALL create_web_order(" + dord.Rows(i)("id").ToString + ", " + is_must_ok_stock + ");", True, "", "", "", "")
                    Next
                Catch ex As Exception
                    ord.insertLogWebOrder("0", ex.ToString)
                    stopCustom(ex.ToString)
                End Try
                ord.setProceccedWebOrder("2")
                ord.insertLogWebOrder("0", "End")
            Else
                ord.setProceccedWebOrder("2")
                ord.insertLogWebOrder("0", "End")
            End If

            FormMain.SplashScreenManager1.SetWaitFormDescription("Loading order")
            viewSalesOrder()
            FormMain.SplashScreenManager1.CloseWaitForm()
            If err = "" Then
                infoCustom("Sync completed.")
            Else
                infoCustom("Problem get order from web. " + err)
            End If
        End If
        Cursor = Cursors.Default
    End Sub

    Private Sub GVSalesOrder_RowCellStyle(sender As Object, e As DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs) Handles GVSalesOrder.RowCellStyle
        If GVSalesOrder.GetRowCellValue(e.RowHandle, "indeks_order") < 0 Then
            e.Appearance.BackColor = Color.Yellow
        Else
            e.Appearance.BackColor = Color.Empty
        End If
    End Sub

    Private Sub DownloadShippingLabelToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DownloadShippingLabelToolStripMenuItem.Click
        Cursor = Cursors.WaitCursor

        'check store
        Dim id_sod As String = GVSalesOrder.GetFocusedRowCellValue("id_sales_order").ToString

        Dim id_cg As String = execute_query("
            SELECT cm.id_comp_group
            FROM tb_sales_order AS so
            LEFT JOIN tb_m_comp_contact AS ct ON so.id_store_contact_to = ct.id_comp_contact
            LEFT JOIN tb_m_comp AS cm ON ct.id_comp = cm.id_comp
            WHERE so.id_sales_order = " + id_sod + "
        ", 0, True, "", "", "", "")

        If id_cg = "75" Then
            Dim item_id As String = execute_query("
                SELECT item_id
                FROM tb_sales_order_det
                WHERE id_sales_order = " + GVSalesOrder.GetFocusedRowCellValue("id_sales_order").ToString + "
                LIMIT 1
            ", 0, True, "", "", "", "")

            FormSalesOrderShippingLabelPdf.ol_store = "blibli"
            FormSalesOrderShippingLabelPdf.order_id = item_id

            FormSalesOrderShippingLabelPdf.ShowDialog()
        ElseIf id_cg = "64" Then
            Dim item_id As String = execute_query("
                SELECT item_id
                FROM tb_sales_order_det
                WHERE id_sales_order = " + GVSalesOrder.GetFocusedRowCellValue("id_sales_order").ToString + "
                LIMIT 1
            ", 0, True, "", "", "", "")

            FormSalesOrderShippingLabelPdf.ol_store = "zalora"
            FormSalesOrderShippingLabelPdf.order_id = item_id

            FormSalesOrderShippingLabelPdf.ShowDialog()
        Else
            stopCustom("Not found.")
        End If

        Cursor = Cursors.Default
    End Sub
End Class