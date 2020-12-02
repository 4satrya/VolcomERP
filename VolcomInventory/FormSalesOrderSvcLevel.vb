Public Class FormSalesOrderSvcLevel
    Sub viewSalesOrder()
        CheckSelAll.Checked = False

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

        Dim cond_status As String = ""
        If SLEPackingStatus.EditValue.ToString = "0" Then
            cond_status = "AND a.id_prepare_status>0 "
        Else
            cond_status = "AND a.id_prepare_status='" + SLEPackingStatus.EditValue.ToString + "' "
        End If

        'prepare query
        Dim query_c As ClassSalesOrder = New ClassSalesOrder()
        Dim query As String = query_c.queryMain("AND a.id_report_status='6' AND (a.sales_order_date>='" + date_from_selected + "' AND a.sales_order_date<='" + date_until_selected + "') " + cond_status, "1")
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCSalesOrder.DataSource = data
        GVSalesOrder.BestFitColumns()
    End Sub

    Sub viewReturnOrder()
        'Prepare paramater
        Dim date_from_selected As String = "0000-01-01"
        Dim date_until_selected As String = "9999-01-01"
        Try
            date_from_selected = DateTime.Parse(DEFromRet.EditValue.ToString).ToString("yyyy-MM-dd")
        Catch ex As Exception
        End Try

        Try
            date_until_selected = DateTime.Parse(DEUntilRet.EditValue.ToString).ToString("yyyy-MM-dd")
        Catch ex As Exception
        End Try

        Dim cond_status As String = ""
        If SLEPackingStatusRet.EditValue.ToString = "0" Then
            cond_status = "AND a.id_prepare_status>0 "
        Else
            cond_status = "AND a.id_prepare_status='" + SLEPackingStatusRet.EditValue.ToString + "' "
        End If

        'return query
        Dim where_id_comp As String = ""

        If Not SLUEStore.EditValue.ToString = "0" Then
            where_id_comp = " AND d.id_comp = " + SLUEStore.EditValue.ToString + " "
        End If

        Dim query_c As ClassReturn = New ClassReturn()
        Dim query As String = query_c.queryMain("AND a.id_report_status='6' AND (a.sales_return_order_date>='" + date_from_selected + "' AND a.sales_return_order_date<='" + date_until_selected + "') " + cond_status + where_id_comp, "1")
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCSalesReturnOrder.DataSource = data
        GVSalesReturnOrder.BestFitColumns()
    End Sub

    Sub viewRecProduct()
        'Prepare paramater
        Dim date_from_selected As String = "0000-01-01"
        Dim date_until_selected As String = "9999-01-01"
        Try
            date_from_selected = DateTime.Parse(DEFromRec.EditValue.ToString).ToString("yyyy-MM-dd")
        Catch ex As Exception
        End Try

        Try
            date_until_selected = DateTime.Parse(DEUntilRec.EditValue.ToString).ToString("yyyy-MM-dd")
        Catch ex As Exception
        End Try

        Dim cond_status As String = ""
        If SLEStatusRec.EditValue.ToString = "0" Then
            cond_status = "AND (a0.id_report_status=1 OR a0.id_report_status=3 OR a0.id_report_status=5 OR a0.id_report_status=6) "
        Else
            cond_status = "AND a0.id_report_status='" + SLEStatusRec.EditValue.ToString + "' "
        End If

        'prepare query
        Dim query_c As ClassProductionPLToWHRec = New ClassProductionPLToWHRec()
        Dim query As String = query_c.queryMain("AND (a0.pl_prod_order_rec_date>='" + date_from_selected + "' AND a0.pl_prod_order_rec_date<='" + date_until_selected + "') " + cond_status, "1")
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCPL.DataSource = data
    End Sub

    Sub viewDO()
        'Prepare paramater
        Dim date_from_selected As String = "0000-01-01"
        Dim date_until_selected As String = "9999-01-01"
        Try
            date_from_selected = DateTime.Parse(DEFromDO.EditValue.ToString).ToString("yyyy-MM-dd")
        Catch ex As Exception
        End Try

        Try
            date_until_selected = DateTime.Parse(DEUntilDO.EditValue.ToString).ToString("yyyy-MM-dd")
        Catch ex As Exception
        End Try

        Dim cond_status As String = ""
        If SLEStatusDO.EditValue.ToString = "0" Then
            cond_status = "AND (a.id_report_status=1 OR a.id_report_status=3 OR a.id_report_status=5 OR a.id_report_status=6) "
        Else
            cond_status = "AND a.id_report_status='" + SLEStatusDO.EditValue.ToString + "' "
        End If

        'prepare query
        Dim query_c As ClassSalesDelOrder = New ClassSalesDelOrder()
        Dim query As String = query_c.queryMain("AND (a.pl_sales_order_del_date>='" + date_from_selected + "' AND a.pl_sales_order_del_date<='" + date_until_selected + "') " + cond_status, "1")
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCSalesDelOrder.DataSource = data
    End Sub

    Sub viewReturn()
        'Prepare paramater
        Dim date_from_selected As String = "0000-01-01"
        Dim date_until_selected As String = "9999-01-01"
        Try
            date_from_selected = DateTime.Parse(DEFromReturn.EditValue.ToString).ToString("yyyy-MM-dd")
        Catch ex As Exception
        End Try

        Try
            date_until_selected = DateTime.Parse(DEUntilReturn.EditValue.ToString).ToString("yyyy-MM-dd")
        Catch ex As Exception
        End Try

        Dim cond_status As String = ""
        If SLEStatusReturn.EditValue.ToString = "0" Then
            cond_status = "AND (a.id_report_status=1 OR a.id_report_status=3 OR a.id_report_status=5 OR a.id_report_status=6) "
        Else
            cond_status = "AND a.id_report_status='" + SLEStatusReturn.EditValue.ToString + "' "
        End If

        'prepare query
        Dim query_c As ClassSalesReturn = New ClassSalesReturn()
        Dim query As String = query_c.queryMain("AND (a.sales_return_date>='" + date_from_selected + "' AND a.sales_return_date<='" + date_until_selected + "') " + cond_status, "1")
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCSalesReturn.DataSource = data
    End Sub

    Sub viewReturnQC()
        'Prepare paramater
        Dim date_from_selected As String = "0000-01-01"
        Dim date_until_selected As String = "9999-01-01"
        Try
            date_from_selected = DateTime.Parse(DEFromReturnQC.EditValue.ToString).ToString("yyyy-MM-dd")
        Catch ex As Exception
        End Try

        Try
            date_until_selected = DateTime.Parse(DEUntilReturnQC.EditValue.ToString).ToString("yyyy-MM-dd")
        Catch ex As Exception
        End Try

        Dim cond_status As String = ""
        If SLEStatusReturnQC.EditValue.ToString = "0" Then
            cond_status = "AND (a.id_report_status=1 OR a.id_report_status=3 OR a.id_report_status=5 OR a.id_report_status=6) "
        Else
            cond_status = "AND a.id_report_status='" + SLEStatusReturnQC.EditValue.ToString + "' "
        End If

        'prepare query
        Dim query_c As ClassSalesReturnQC = New ClassSalesReturnQC()
        Dim query As String = query_c.queryMain("AND (a.sales_return_qc_date>='" + date_from_selected + "' AND a.sales_return_qc_date<='" + date_until_selected + "') " + cond_status, "1")
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCSalesReturnQC.DataSource = data
    End Sub

    Sub viewTrf()
        'Prepare paramater
        Dim date_from_selected As String = "0000-01-01"
        Dim date_until_selected As String = "9999-01-01"
        Try
            date_from_selected = DateTime.Parse(DEFromTrf.EditValue.ToString).ToString("yyyy-MM-dd")
        Catch ex As Exception
        End Try

        Try
            date_until_selected = DateTime.Parse(DEUntilTrf.EditValue.ToString).ToString("yyyy-MM-dd")
        Catch ex As Exception
        End Try

        Dim cond_status As String = ""
        If SLEStatusTrf.EditValue.ToString = "0" Then
            cond_status = "AND (trf.id_report_status=1 OR trf.id_report_status=3 OR trf.id_report_status=5 OR trf.id_report_status=6) "
        Else
            cond_status = "AND trf.id_report_status=" + SLEStatusTrf.EditValue.ToString + " "
        End If

        'prepare query
        Dim query_c As ClassFGTrf = New ClassFGTrf()
        Dim query As String = query_c.queryMain("AND (trf.fg_trf_date>=''" + date_from_selected + "'' AND trf.fg_trf_date<=''" + date_until_selected + "'') " + cond_status, "1")
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCFGTrf.DataSource = data
    End Sub

    Sub viewNonStock()
        'Prepare paramater
        Dim date_from_selected As String = "0000-01-01"
        Dim date_until_selected As String = "9999-01-01"
        Try
            date_from_selected = DateTime.Parse(DEFromNonStock.EditValue.ToString).ToString("yyyy-MM-dd")
        Catch ex As Exception
        End Try

        Try
            date_until_selected = DateTime.Parse(DEUntilNonStock.EditValue.ToString).ToString("yyyy-MM-dd")
        Catch ex As Exception
        End Try

        Dim cond_status As String = ""
        If SLEStatusNonStock.EditValue.ToString = "0" Then
            cond_status = "AND (del.id_report_status=1 OR del.id_report_status=3 OR del.id_report_status=5 OR del.id_report_status=6) "
        Else
            cond_status = "AND del.id_report_status=" + SLEStatusNonStock.EditValue.ToString + " "
        End If

        'prepare query
        Dim query_c As ClassDelEmpty = New ClassDelEmpty()
        Dim query As String = query_c.queryMain("AND (del.wh_del_empty_date>='" + date_from_selected + "' AND wh_del_empty_date<='" + date_until_selected + "') " + cond_status, "1")
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCNonStock.DataSource = data
    End Sub

    Private Sub BtnView_Click(sender As Object, e As EventArgs) Handles BtnView.Click
        Cursor = Cursors.WaitCursor
        GVSalesOrder.ActiveFilterString = ""
        viewSalesOrder()
        noEdit(6)
        Cursor = Cursors.Default
    End Sub

    Private Sub BtnViewRet_Click(sender As Object, e As EventArgs) Handles BtnViewRet.Click
        Cursor = Cursors.WaitCursor
        viewReturnOrder()
        'noEdit(8)
        Cursor = Cursors.Default
    End Sub

    Private Sub FormSalesOrderSvcLevel_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        viewPackingStatus()
        viewReportStatus()
        view_store()

        'date now
        Dim data_dt As DataTable = execute_query("SELECT DATE(NOW()) AS `dt`", -1, True, "", "", "", "")
        DEFrom.EditValue = data_dt.Rows(0)("dt")
        DEUntil.EditValue = data_dt.Rows(0)("dt")
        DEFromRet.EditValue = data_dt.Rows(0)("dt")
        DEUntilRet.EditValue = data_dt.Rows(0)("dt")
        DEFromRec.EditValue = data_dt.Rows(0)("dt")
        DEUntilRec.EditValue = data_dt.Rows(0)("dt")
        DEFromDO.EditValue = data_dt.Rows(0)("dt")
        DEUntilDO.EditValue = data_dt.Rows(0)("dt")
        DEFromReturn.EditValue = data_dt.Rows(0)("dt")
        DEUntilReturn.EditValue = data_dt.Rows(0)("dt")
        DEFromReturnQC.EditValue = data_dt.Rows(0)("dt")
        DEUntilReturnQC.EditValue = data_dt.Rows(0)("dt")
        DEFromTrf.EditValue = data_dt.Rows(0)("dt")
        DEUntilTrf.EditValue = data_dt.Rows(0)("dt")
        DEFromNonStock.EditValue = data_dt.Rows(0)("dt")
        DEUntilNonStock.EditValue = data_dt.Rows(0)("dt")

        load_surat_jalan()
    End Sub

    Sub viewPackingStatus()
        Dim query As String = "SELECT 0 AS id_prepare_status, 'All Status' AS prepare_status UNION ALL "
        query += "SELECT id_prepare_status,prepare_status FROM tb_lookup_prepare_status a "
        viewSearchLookupQuery(SLEPackingStatus, query, "id_prepare_status", "prepare_status", "id_prepare_status")
        viewSearchLookupQuery(SLEPackingStatusRet, query, "id_prepare_status", "prepare_status", "id_prepare_status")
    End Sub

    Sub viewReportStatus()
        Dim query As String = "SELECT ('0') AS id_report_status, ('All Status') AS report_status UNION ALL "
        query += "SELECT id_report_status, report_status FROM tb_lookup_report_status WHERE id_report_status=1 OR id_report_status=3 OR id_report_status=5 OR id_report_status=6 ORDER BY id_report_status ASC "
        viewSearchLookupQuery(SLEStatusRec, query, "id_report_status", "report_status", "id_report_status")
        viewSearchLookupQuery(SLEStatusDO, query, "id_report_status", "report_status", "id_report_status")
        viewSearchLookupQuery(SLEStatusReturn, query, "id_report_status", "report_status", "id_report_status")
        viewSearchLookupQuery(SLEStatusReturnQC, query, "id_report_status", "report_status", "id_report_status")
        viewSearchLookupQuery(SLEStatusTrf, query, "id_report_status", "report_status", "id_report_status")
        viewSearchLookupQuery(SLEStatusNonStock, query, "id_report_status", "report_status", "id_report_status")
    End Sub

    Private Sub SMView_Click(sender As Object, e As EventArgs) Handles SMView.Click
        If XTCSvcLevel.SelectedTabPageIndex = 0 Then 'prepare order
            Dim id_sales_order_par As String = "-1"
            Dim order_number_par As String = "-1"
            Dim id_so_cat As String = "-1"
            id_sales_order_par = GVSalesOrder.GetFocusedRowCellValue("id_sales_order").ToString()
            order_number_par = GVSalesOrder.GetFocusedRowCellValue("sales_order_number").ToString()
            id_so_cat = GVSalesOrder.GetFocusedRowCellValue("id_so_cat").ToString

            If id_so_cat = "1" Then
                'delivery order
                Cursor = Cursors.WaitCursor
                Try
                    'open menu
                    FormSalesDelOrder.MdiParent = FormMain
                    FormSalesDelOrder.Show()
                    FormSalesDelOrder.WindowState = FormWindowState.Maximized
                    FormSalesDelOrder.Focus()

                    'search
                    FormSalesDelOrder.GVSalesDelOrder.ShowFindPanel()
                    FormSalesDelOrder.GVSalesDelOrder.ApplyFindFilter(order_number_par)
                Catch ex As Exception
                    errorProcess()
                End Try
                Cursor = Cursors.Default
            ElseIf id_so_cat = "2" Then
                'trf
                Cursor = Cursors.WaitCursor
                Try
                    'open menu
                    FormFGTrfNew.MdiParent = FormMain
                    FormFGTrfNew.Show()
                    FormFGTrfNew.WindowState = FormWindowState.Maximized
                    FormFGTrfNew.Focus()

                    'search
                    FormFGTrfNew.GVFGTrf.ShowFindPanel()
                    FormFGTrfNew.GVFGTrf.ApplyFindFilter(order_number_par)
                Catch ex As Exception
                    errorProcess()
                End Try
                Cursor = Cursors.Default
            End If
        ElseIf XTCSvcLevel.SelectedTabPageIndex = 1 Then 'return order
            Dim id_sales_return_order_par As String = "-1"
            Dim order_number_par As String = "-1"
            id_sales_return_order_par = GVSalesReturnOrder.GetFocusedRowCellValue("id_sales_return_order").ToString()
            order_number_par = GVSalesReturnOrder.GetFocusedRowCellValue("sales_return_order_number").ToString()
            Cursor = Cursors.WaitCursor
            Try
                'open menu
                FormSalesReturn.MdiParent = FormMain
                FormSalesReturn.Show()
                FormSalesReturn.WindowState = FormWindowState.Maximized
                FormSalesReturn.Focus()

                'search
                FormSalesReturn.GVSalesReturn.ShowFindPanel()
                FormSalesReturn.GVSalesReturn.ApplyFindFilter(order_number_par)
            Catch ex As Exception
                errorProcess()
            End Try
            Cursor = Cursors.Default
        End If
    End Sub

    Private Sub ViewDetailOrderToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ViewDetailOrderToolStripMenuItem.Click
        If XTCSvcLevel.SelectedTabPageIndex = 0 Then
            Cursor = Cursors.WaitCursor
            Dim sh As ClassShowPopUp = New ClassShowPopUp()
            sh.report_mark_type = "39"
            sh.id_report = GVSalesOrder.GetFocusedRowCellValue("id_sales_order").ToString
            sh.show()
            FormViewSalesOrder.BMark.Visible = False
            Cursor = Cursors.Default
        ElseIf XTCSvcLevel.SelectedTabPageIndex = 1 Then
            Cursor = Cursors.WaitCursor
            Dim id_so As String = GVSalesReturnOrder.GetFocusedRowCellValue("id_sales_order").ToString
            If id_so = "0" Then
                FormViewSalesReturnOrder.id_sales_return_order = GVSalesReturnOrder.GetFocusedRowCellValue("id_sales_return_order").ToString
                FormViewSalesReturnOrder.is_detail_soh = "1"
                FormViewSalesReturnOrder.ShowDialog()
            Else
                FormSalesReturnOrderOLDet.is_view = "1"
                FormSalesReturnOrderOLDet.action = "upd"
                FormSalesReturnOrderOLDet.id_sales_return_order = GVSalesReturnOrder.GetFocusedRowCellValue("id_sales_return_order").ToString()
                FormSalesReturnOrderOLDet.is_detail_soh = "1"
                FormSalesReturnOrderOLDet.ShowDialog()
            End If
            Cursor = Cursors.Default
        End If
    End Sub

    Private Sub UpdatePackingStatusToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles UpdatePackingStatusToolStripMenuItem.Click
        If XTCSvcLevel.SelectedTabPageIndex = 0 Then 'prepare
            Dim id_prepare As String = GVSalesOrder.GetFocusedRowCellValue("id_sales_order").ToString
            Dim id_cur_stt As String = GVSalesOrder.GetFocusedRowCellValue("id_prepare_status").ToString
            If id_cur_stt = "1" Then
                'FormSalesOrderPacking.id_trans = id_prepare
                'FormSalesOrderPacking.id_cur_status = id_cur_stt
                'FormSalesOrderPacking.id_pop_up = "1"
                'FormSalesOrderPacking.ShowDialog()
            Else
                stopCustom("Data already locked.")
            End If
        ElseIf XTCSvcLevel.SelectedTabPageIndex = 1 Then 'return
            Dim id_prepare As String = GVSalesReturnOrder.GetFocusedRowCellValue("id_sales_return_order").ToString
            Dim id_cur_stt As String = GVSalesReturnOrder.GetFocusedRowCellValue("id_prepare_status").ToString
            If id_cur_stt = "1" Then
                'FormSalesOrderPacking.id_trans = id_prepare
                'FormSalesOrderPacking.id_cur_status = id_cur_stt
                'FormSalesOrderPacking.id_pop_up = "2"
                'FormSalesOrderPacking.ShowDialog()
            Else
                stopCustom("Data already locked.")
            End If
        End If
    End Sub

    Private Sub GVSalesOrder_PopupMenuShowing(sender As Object, e As DevExpress.XtraGrid.Views.Grid.PopupMenuShowingEventArgs) Handles GVSalesOrder.PopupMenuShowing
        If GVSalesOrder.RowCount > 0 And GVSalesOrder.FocusedRowHandle >= 0 Then
            UpdatePackingStatusToolStripMenuItem.Visible = True
            Dim view As DevExpress.XtraGrid.Views.Grid.GridView = CType(sender, DevExpress.XtraGrid.Views.Grid.GridView)
            Dim hitInfo As DevExpress.XtraGrid.Views.Grid.ViewInfo.GridHitInfo = view.CalcHitInfo(e.Point)
            If hitInfo.InRow And hitInfo.RowHandle >= 0 Then
                view.FocusedRowHandle = hitInfo.RowHandle
                ViewMenu.Show(view.GridControl, e.Point)
            End If
        End If
    End Sub

    Private Sub FormSalesOrderSvcLevel_Activated(sender As Object, e As EventArgs) Handles MyBase.Activated
        FormMain.show_rb(Name)
        checkFormAccess(Name)
    End Sub

    Private Sub FormSalesOrderSvcLevel_Deactivate(sender As Object, e As EventArgs) Handles MyBase.Deactivate
        FormMain.hide_rb()
    End Sub

    Private Sub GVSalesReturnOrder_PopupMenuShowing(sender As Object, e As DevExpress.XtraGrid.Views.Grid.PopupMenuShowingEventArgs) Handles GVSalesReturnOrder.PopupMenuShowing
        If GVSalesReturnOrder.RowCount > 0 And GVSalesReturnOrder.FocusedRowHandle >= 0 Then
            UpdatePackingStatusToolStripMenuItem.Visible = True
            Dim view As DevExpress.XtraGrid.Views.Grid.GridView = CType(sender, DevExpress.XtraGrid.Views.Grid.GridView)
            Dim hitInfo As DevExpress.XtraGrid.Views.Grid.ViewInfo.GridHitInfo = view.CalcHitInfo(e.Point)
            If hitInfo.InRow And hitInfo.RowHandle >= 0 Then
                view.FocusedRowHandle = hitInfo.RowHandle
                ViewMenu.Show(view.GridControl, e.Point)
            End If
        End If
    End Sub

    Private Sub XTCSvcLevel_SelectedPageChanged(sender As Object, e As DevExpress.XtraTab.TabPageChangedEventArgs) Handles XTCSvcLevel.SelectedPageChanged
        If XTCSvcLevel.SelectedTabPageIndex = 0 Then 'prepare
            SMView.Text = "View Detail Delivery/Transfer"
        ElseIf XTCSvcLevel.SelectedTabPageIndex = 1 Then 'return
            SMView.Text = "View Detail Return"
        End If
    End Sub

    Private Sub BtnViewRec_Click(sender As Object, e As EventArgs) Handles BtnViewRec.Click
        Cursor = Cursors.WaitCursor
        GVPL.ActiveFilterString = ""
        viewRecProduct()
        noEdit(1)
        Cursor = Cursors.Default
    End Sub

    Sub noEdit(ByVal type As String)
        If type = "1" Then 'REC PRODUCT
            If GVPL.FocusedRowHandle >= 0 Then
                Dim alloc_cek As String = GVPL.GetFocusedRowCellValue("id_report_status").ToString
                If alloc_cek = "5" Or alloc_cek = "6" Then
                    GVPL.Columns("is_select").OptionsColumn.AllowEdit = False
                Else
                    GVPL.Columns("is_select").OptionsColumn.AllowEdit = True
                End If
            End If
        ElseIf type = "2" Then 'DEL ORDER
            If GVSalesDelOrder.FocusedRowHandle >= 0 Then
                Dim alloc_cek As String = GVSalesDelOrder.GetFocusedRowCellValue("id_report_status").ToString
                If alloc_cek = "5" Or alloc_cek = "6" Then
                    GVSalesDelOrder.Columns("is_select").OptionsColumn.AllowEdit = False
                Else
                    GVSalesDelOrder.Columns("is_select").OptionsColumn.AllowEdit = True
                End If
            End If
        ElseIf type = "3" Then 'RETURN
            If GVSalesReturn.FocusedRowHandle >= 0 Then
                Dim alloc_cek As String = GVSalesReturn.GetFocusedRowCellValue("id_report_status").ToString
                If alloc_cek = "5" Or alloc_cek = "6" Then
                    GVSalesReturn.Columns("is_select").OptionsColumn.AllowEdit = False
                Else
                    GVSalesReturn.Columns("is_select").OptionsColumn.AllowEdit = True
                End If
            End If
        ElseIf type = "4" Then 'RETURN QC
            If GVSalesReturnQC.FocusedRowHandle >= 0 Then
                Dim alloc_cek As String = GVSalesReturnQC.GetFocusedRowCellValue("id_report_status").ToString
                If alloc_cek = "5" Or alloc_cek = "6" Then
                    GVSalesReturnQC.Columns("is_select").OptionsColumn.AllowEdit = False
                Else
                    GVSalesReturnQC.Columns("is_select").OptionsColumn.AllowEdit = True
                End If
            End If
        ElseIf type = "5" Then 'TRF
            If GVFGTrf.FocusedRowHandle >= 0 Then
                Dim alloc_cek As String = GVFGTrf.GetFocusedRowCellValue("id_report_status").ToString
                If alloc_cek = "5" Or alloc_cek = "6" Then
                    GVFGTrf.Columns("is_select").OptionsColumn.AllowEdit = False
                Else
                    GVFGTrf.Columns("is_select").OptionsColumn.AllowEdit = True
                End If
            End If
        ElseIf type = "6" Then
            If GVSalesOrder.FocusedRowHandle >= 0 Then
                Dim alloc_cek As String = GVSalesOrder.GetFocusedRowCellValue("id_prepare_status").ToString
                Dim ots As Integer = GVSalesOrder.GetFocusedRowCellValue("outstanding")
                If alloc_cek = "2" Then
                    GVSalesOrder.Columns("is_select").OptionsColumn.AllowEdit = False
                Else
                    If ots = 0 Then
                        GVSalesOrder.Columns("is_select").OptionsColumn.AllowEdit = True
                    Else
                        GVSalesOrder.Columns("is_select").OptionsColumn.AllowEdit = False
                    End If
                End If
            End If
        ElseIf type = "7" Then ' non stock inv
            If GVNonStock.FocusedRowHandle >= 0 Then
                Dim alloc_cek As String = GVNonStock.GetFocusedRowCellValue("id_report_status").ToString
                If alloc_cek = "5" Or alloc_cek = "6" Then
                    GVNonStock.Columns("is_select").OptionsColumn.AllowEdit = False
                Else
                    GVNonStock.Columns("is_select").OptionsColumn.AllowEdit = True
                End If
            End If
        ElseIf type = "8" Then 'return order
            If GVSalesReturnOrder.FocusedRowHandle >= 0 Then
                Dim alloc_cek As String = GVSalesReturnOrder.GetFocusedRowCellValue("id_prepare_status").ToString
                Dim ots As Integer = GVSalesReturnOrder.GetFocusedRowCellValue("outstanding")
                If alloc_cek = "2" Then
                    GVSalesReturnOrder.Columns("is_select").OptionsColumn.AllowEdit = False
                Else
                    If ots = 0 Then
                        GVSalesReturnOrder.Columns("is_select").OptionsColumn.AllowEdit = True
                    Else
                        GVSalesReturnOrder.Columns("is_select").OptionsColumn.AllowEdit = False
                    End If
                End If
            End If
        End If
    End Sub

    Private Sub GVPL_FocusedRowChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles GVPL.FocusedRowChanged
        noEdit(1)
    End Sub

    Private Sub BtnUpdateRec_Click(sender As Object, e As EventArgs) Handles BtnUpdateRec.Click
        Cursor = Cursors.WaitCursor
        GVPL.ActiveFilterString = ""
        GVPL.ActiveFilterString = "[is_select]='Yes' "
        If GVPL.RowCount = 0 Then
            stopCustom("Please select document first.")
            GVPL.ActiveFilterString = ""
        Else
            FormChangeStatus.id_pop_up = "1"
            FormChangeStatus.ShowDialog()
        End If
        Cursor = Cursors.Default
    End Sub

    Private Sub GVPL_DoubleClick(sender As Object, e As EventArgs) Handles GVPL.DoubleClick
        If GVPL.FocusedRowHandle >= 0 And GVPL.RowCount > 0 Then
            Cursor = Cursors.WaitCursor
            FormViewProductionPLToWHRec.action = "upd"
            FormViewProductionPLToWHRec.id_pl_prod_order_rec = GVPL.GetFocusedRowCellValue("id_pl_prod_order_rec").ToString
            FormViewProductionPLToWHRec.ShowDialog()
            Cursor = Cursors.Default
        End If
    End Sub

    Private Sub BtnViewDO_Click(sender As Object, e As EventArgs) Handles BtnViewDO.Click
        Cursor = Cursors.WaitCursor
        GVSalesDelOrder.ActiveFilterString = ""
        viewDO()
        noEdit(2)
        Cursor = Cursors.Default
    End Sub

    Private Sub GVSalesDelOrder_FocusedRowChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles GVSalesDelOrder.FocusedRowChanged
        noEdit(2)
    End Sub

    Private Sub BtnUpdateDO_Click(sender As Object, e As EventArgs) Handles BtnUpdateDO.Click
        Cursor = Cursors.WaitCursor
        GVSalesDelOrder.ActiveFilterString = ""
        GVSalesDelOrder.ActiveFilterString = "[is_select]='Yes' "
        If GVSalesDelOrder.RowCount = 0 Then
            stopCustom("Please select document first.")
            GVSalesDelOrder.ActiveFilterString = ""
        Else
            FormChangeStatus.id_pop_up = "2"
            FormChangeStatus.ShowDialog()
        End If
        Cursor = Cursors.Default
    End Sub

    Private Sub GVSalesDelOrder_DoubleClick(sender As Object, e As EventArgs) Handles GVSalesDelOrder.DoubleClick
        viewDetailPreDel()
    End Sub

    Sub viewDetailPreDel()
        If GVSalesDelOrder.FocusedRowHandle >= 0 And GVSalesDelOrder.RowCount > 0 Then
            Cursor = Cursors.WaitCursor
            FormViewSalesDelOrder.action = "upd"
            FormViewSalesDelOrder.id_pl_sales_order_del = GVSalesDelOrder.GetFocusedRowCellValue("id_pl_sales_order_del").ToString
            FormViewSalesDelOrder.ShowDialog()
            Cursor = Cursors.Default
        End If
    End Sub

    Private Sub BtnViewReturn_Click(sender As Object, e As EventArgs) Handles BtnViewReturn.Click
        Cursor = Cursors.WaitCursor
        GVSalesReturn.ActiveFilterString = ""
        viewReturn()
        noEdit(3)
        Cursor = Cursors.Default
    End Sub

    Private Sub GVSalesReturn_FocusedRowChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles GVSalesReturn.FocusedRowChanged
        noEdit(3)
    End Sub

    Private Sub BtnUpdateReturn_Click(sender As Object, e As EventArgs) Handles BtnUpdateReturn.Click
        Cursor = Cursors.WaitCursor
        GVSalesReturn.ActiveFilterString = ""
        GVSalesReturn.ActiveFilterString = "[is_select]='Yes' "
        If GVSalesReturn.RowCount = 0 Then
            stopCustom("Please select document first.")
            GVSalesReturn.ActiveFilterString = ""
        Else
            FormChangeStatus.id_pop_up = "3"
            FormChangeStatus.ShowDialog()
        End If
        Cursor = Cursors.Default
    End Sub

    Private Sub GVSalesReturn_DoubleClick(sender As Object, e As EventArgs) Handles GVSalesReturn.DoubleClick
        If GVSalesReturn.FocusedRowHandle >= 0 And GVSalesReturn.RowCount > 0 Then
            Cursor = Cursors.WaitCursor
            FormViewSalesReturn.action = "upd"
            FormViewSalesReturn.id_sales_return = GVSalesReturn.GetFocusedRowCellValue("id_sales_return").ToString
            FormViewSalesReturn.ShowDialog()
            Cursor = Cursors.Default
        End If
    End Sub

    Private Sub BtnViewReturnQC_Click(sender As Object, e As EventArgs) Handles BtnViewReturnQC.Click
        Cursor = Cursors.WaitCursor
        GVSalesReturnQC.ActiveFilterString = ""
        viewReturnQC()
        noEdit(4)
        Cursor = Cursors.Default
    End Sub

    Private Sub GVSalesReturnQC_FocusedRowChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles GVSalesReturnQC.FocusedRowChanged
        noEdit(4)
    End Sub

    Private Sub BtnUpdateReturnQC_Click(sender As Object, e As EventArgs) Handles BtnUpdateReturnQC.Click
        Cursor = Cursors.WaitCursor
        GVSalesReturnQC.ActiveFilterString = ""
        GVSalesReturnQC.ActiveFilterString = "[is_select]='Yes' "
        If GVSalesReturnQC.RowCount = 0 Then
            stopCustom("Please select document first.")
            GVSalesReturnQC.ActiveFilterString = ""
        Else
            FormChangeStatus.id_pop_up = "4"
            FormChangeStatus.ShowDialog()
        End If
        Cursor = Cursors.Default
    End Sub

    Private Sub GVSalesReturnQC_DoubleClick(sender As Object, e As EventArgs) Handles GVSalesReturnQC.DoubleClick
        If GVSalesReturnQC.FocusedRowHandle >= 0 And GVSalesReturnQC.RowCount > 0 Then
            Cursor = Cursors.WaitCursor
            FormViewSalesReturnQC.action = "upd"
            FormViewSalesReturnQC.id_sales_return_qc = GVSalesReturnQC.GetFocusedRowCellValue("id_sales_return_qc").ToString
            FormViewSalesReturnQC.ShowDialog()
            Cursor = Cursors.Default
        End If
    End Sub

    Private Sub BtnViewTrf_Click(sender As Object, e As EventArgs) Handles BtnViewTrf.Click
        Cursor = Cursors.WaitCursor
        GVFGTrf.ActiveFilterString = ""
        viewTrf()
        noEdit(5)
        Cursor = Cursors.Default
    End Sub

    Private Sub GVFGTrf_FocusedRowChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles GVFGTrf.FocusedRowChanged
        noEdit(5)
    End Sub

    Private Sub BtnUpdateTrf_Click(sender As Object, e As EventArgs) Handles BtnUpdateTrf.Click
        Cursor = Cursors.WaitCursor
        GVFGTrf.ActiveFilterString = ""
        GVFGTrf.ActiveFilterString = "[is_select]='Yes' "
        If GVFGTrf.RowCount = 0 Then
            stopCustom("Please select document first.")
            GVFGTrf.ActiveFilterString = ""
        Else
            FormChangeStatus.id_pop_up = "5"
            FormChangeStatus.ShowDialog()
        End If
        Cursor = Cursors.Default
    End Sub

    Private Sub GVFGTrf_DoubleClick(sender As Object, e As EventArgs) Handles GVFGTrf.DoubleClick
        If GVFGTrf.FocusedRowHandle >= 0 And GVFGTrf.RowCount > 0 Then
            Cursor = Cursors.WaitCursor
            FormViewFGTrf.action = "upd"
            FormViewFGTrf.id_fg_trf = GVFGTrf.GetFocusedRowCellValue("id_fg_trf").ToString
            FormViewFGTrf.ShowDialog()
            Cursor = Cursors.Default
        End If
    End Sub

    Private Sub GVSalesOrder_FocusedRowChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles GVSalesOrder.FocusedRowChanged
        noEdit(6)
    End Sub

    Private Sub GVSalesOrder_ColumnFilterChanged(sender As Object, e As EventArgs) Handles GVSalesOrder.ColumnFilterChanged
        noEdit(6)
    End Sub

    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs) Handles SimpleButton1.Click
        Cursor = Cursors.WaitCursor
        GVSalesOrder.ActiveFilterString = ""
        GVSalesOrder.ActiveFilterString = "[is_select]='Yes' "
        If GVSalesOrder.RowCount = 0 Then
            stopCustom("Please select order first.")
            GVSalesOrder.ActiveFilterString = ""
        Else
            FormSalesOrderPacking.id_pop_up = "4"
            FormSalesOrderPacking.ShowDialog()
        End If
        GVSalesOrder.ActiveFilterString = ""
        Cursor = Cursors.Default
    End Sub

    Private Sub CheckSelAll_CheckedChanged(sender As Object, e As EventArgs) Handles CheckSelAll.CheckedChanged
        If GVSalesOrder.RowCount > 0 Then
            Dim cek As String = CheckSelAll.EditValue.ToString
            For i As Integer = ((GVSalesOrder.RowCount - 1) - GetGroupRowCount(GVSalesOrder)) To 0 Step -1
                Dim id_prepare_status As String = GVSalesOrder.GetRowCellValue(i, "id_prepare_status").ToString
                Dim ots As Integer = GVSalesOrder.GetRowCellValue(i, "outstanding")
                If cek And id_prepare_status = "1" And ots = 0 Then
                    GVSalesOrder.SetRowCellValue(i, "is_select", "Yes")
                Else
                    GVSalesOrder.SetRowCellValue(i, "is_select", "No")
                End If
            Next
        End If
    End Sub

    Private Sub PrintPrepareOrderToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PrintPrepareOrderToolStripMenuItem.Click
        Cursor = Cursors.WaitCursor
        If XTCSvcLevel.SelectedTabPageIndex = 0 Then
            If GVSalesOrder.FocusedRowHandle >= 0 And GVSalesOrder.RowCount > 0 Then
                FormViewSalesOrder.id_sales_order = GVSalesOrder.GetFocusedRowCellValue("id_sales_order").ToString
                FormViewSalesOrder.is_print = "1"
                FormViewSalesOrder.ShowDialog()
            End If
        ElseIf XTCSvcLevel.SelectedTabPageIndex = 1 Then
            If GVSalesReturnOrder.FocusedRowHandle >= 0 And GVSalesReturnOrder.RowCount > 0 Then
                Cursor = Cursors.WaitCursor
                Dim id_so As String = GVSalesReturnOrder.GetFocusedRowCellValue("id_sales_order").ToString
                If id_so = "0" Then
                    FormViewSalesReturnOrder.id_sales_return_order = GVSalesReturnOrder.GetFocusedRowCellValue("id_sales_return_order").ToString
                    FormViewSalesReturnOrder.is_detail_soh = "1"
                    FormViewSalesReturnOrder.is_print = "1"
                    FormViewSalesReturnOrder.ShowDialog()
                Else
                    FormSalesReturnOrderOLDet.is_view = "1"
                    FormSalesReturnOrderOLDet.action = "upd"
                    FormSalesReturnOrderOLDet.id_sales_return_order = GVSalesReturnOrder.GetFocusedRowCellValue("id_sales_return_order").ToString()
                    FormSalesReturnOrderOLDet.is_detail_soh = "1"
                    FormSalesReturnOrderOLDet.is_print = "1"
                    FormSalesReturnOrderOLDet.ShowDialog()
                End If
                Cursor = Cursors.Default
            End If
        End If
        Cursor = Cursors.Default
    End Sub

    Private Sub ViewDetailToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ViewDetailToolStripMenuItem.Click
        viewDetailPreDel()
    End Sub

    Private Sub PrintUniqueCodeToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PrintUniqueCodeToolStripMenuItem.Click
        Cursor = Cursors.WaitCursor
        If GVSalesDelOrder.FocusedRowHandle >= 0 And GVSalesDelOrder.RowCount > 0 Then
            FormUniqueDel.id_del = GVSalesDelOrder.GetFocusedRowCellValue("id_pl_sales_order_del").ToString
            FormUniqueDel.ShowDialog()
        End If
        Cursor = Cursors.Default
    End Sub

    Private Sub BtnViewNonStock_Click(sender As Object, e As EventArgs) Handles BtnViewNonStock.Click
        Cursor = Cursors.WaitCursor
        GVNonStock.ActiveFilterString = ""
        viewNonStock()
        noEdit(7)
        Cursor = Cursors.Default
    End Sub

    Private Sub GVNonStock_FocusedRowChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles GVNonStock.FocusedRowChanged
        noEdit(7)
    End Sub

    Private Sub BtnUpdateStatusNonStock_Click(sender As Object, e As EventArgs) Handles BtnUpdateStatusNonStock.Click
        Cursor = Cursors.WaitCursor
        GVNonStock.ActiveFilterString = ""
        GVNonStock.ActiveFilterString = "[is_select]='Yes' "
        If GVNonStock.RowCount = 0 Then
            stopCustom("Please select document first.")
            GVNonStock.ActiveFilterString = ""
        Else
            FormChangeStatus.id_pop_up = "6"
            FormChangeStatus.ShowDialog()
        End If
        Cursor = Cursors.Default
    End Sub

    Private Sub GVNonStock_DoubleClick(sender As Object, e As EventArgs) Handles GVNonStock.DoubleClick
        If GVNonStock.FocusedRowHandle >= 0 And GVNonStock.RowCount > 0 Then
            Cursor = Cursors.WaitCursor
            FormWHDelEmptyDet.action = "upd"
            FormWHDelEmptyDet.id_wh_del_empty = GVNonStock.GetFocusedRowCellValue("id_wh_del_empty").ToString
            FormWHDelEmptyDet.is_view = "1"
            FormWHDelEmptyDet.ShowDialog()
            Cursor = Cursors.Default
        End If
    End Sub

    Private Sub GVSalesReturnOrder_ColumnFilterChanged(sender As Object, e As EventArgs) Handles GVSalesReturnOrder.ColumnFilterChanged
        'noEdit(8)
    End Sub

    Private Sub GVSalesReturnOrder_FocusedRowChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles GVSalesReturnOrder.FocusedRowChanged
        'noEdit(8)
    End Sub

    Private Sub CheckEdit1_CheckedChanged(sender As Object, e As EventArgs) Handles CheckEdit1.CheckedChanged
        If GVSalesReturnOrder.RowCount > 0 Then
            Dim cek As String = CheckEdit1.EditValue.ToString
            For i As Integer = ((GVSalesReturnOrder.RowCount - 1) - GetGroupRowCount(GVSalesReturnOrder)) To 0 Step -1
                Dim id_prepare_status As String = GVSalesReturnOrder.GetRowCellValue(i, "id_prepare_status").ToString
                Dim ots As Integer = GVSalesReturnOrder.GetRowCellValue(i, "outstanding")
                If cek And id_prepare_status = "1" And ots = 0 Then
                    GVSalesReturnOrder.SetRowCellValue(i, "is_select", "Yes")
                Else
                    GVSalesReturnOrder.SetRowCellValue(i, "is_select", "No")
                End If
            Next
        End If
    End Sub

    Private Sub SimpleButton6_Click(sender As Object, e As EventArgs) Handles SimpleButton6.Click
        Cursor = Cursors.WaitCursor
        GVSalesReturnOrder.ActiveFilterString = ""
        GVSalesReturnOrder.ActiveFilterString = "[is_select]='Yes' "
        If GVSalesReturnOrder.RowCount = 0 Then
            stopCustom("Please select order first.")
            GVSalesReturnOrder.ActiveFilterString = ""
        Else
            'check
            Dim is_valid As Boolean = True

            For i = 0 To GVSalesReturnOrder.RowCount - 1
                Dim alloc_cek As String = GVSalesReturnOrder.GetRowCellValue(i, "id_prepare_status").ToString
                Dim ots As Integer = GVSalesReturnOrder.GetRowCellValue(i, "outstanding").ToString
                If alloc_cek = "2" Then
                    is_valid = False
                Else
                    If Not ots = 0 Then
                        is_valid = False
                    End If
                End If
            Next

            If is_valid Then
                FormSalesOrderPacking.id_pop_up = "5"
                FormSalesOrderPacking.ShowDialog()
            Else
                stopCustom("Some order can't close.")
            End If
        End If
        GVSalesReturnOrder.ActiveFilterString = ""
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
            FormSalesDelOrderSlip.is_view = "1"
            FormSalesDelOrderSlip.action = "upd"
            FormSalesDelOrderSlip.id_pl_sales_order_del_slip = id_combine
            FormSalesDelOrderSlip.ShowDialog()
            Cursor = Cursors.Default
        Else
            stopCustom("Combined delivery not found")
        End If
    End Sub

    Private Sub LogPrintToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles LogPrintToolStripMenuItem.Click
        If GVSalesOrder.FocusedRowHandle >= 0 And GVSalesOrder.RowCount > 0 Then
            Cursor = Cursors.WaitCursor
            Dim id As String = GVSalesOrder.GetFocusedRowCellValue("id_sales_order").ToString
            FormSalesOrderLogPrint.id = id
            FormSalesOrderLogPrint.ShowDialog()
            Cursor = Cursors.Default
        End If
    End Sub

    Private Sub CancellCombinedDeliveryToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CancellCombinedDeliveryToolStripMenuItem.Click
        Cursor = Cursors.WaitCursor
        If GVSalesDelOrder.RowCount > 0 And GVSalesDelOrder.FocusedRowHandle >= 0 Then
            Dim id_combine As String = ""
            Try
                id_combine = GVSalesDelOrder.GetFocusedRowCellValue("id_combine").ToString
            Catch ex As Exception
            End Try
            If id_combine = "0" Then
                id_combine = ""
            End If
            If id_combine <> "" Then
                If statusCombineDel(id_combine) Then
                    Cursor = Cursors.WaitCursor
                    FormSalesDelOrderCancellCombine.id_combine = GVSalesDelOrder.GetFocusedRowCellValue("id_combine").ToString
                    FormSalesDelOrderCancellCombine.LabelCombineNumber.Text = GVSalesDelOrder.GetFocusedRowCellValue("combine_number").ToString
                    FormSalesDelOrderCancellCombine.LabelStore.Text = GVSalesDelOrder.GetFocusedRowCellValue("store").ToString
                    FormSalesDelOrderCancellCombine.id_comp_contact_from = GVSalesDelOrder.GetFocusedRowCellValue("id_comp_contact_from").ToString
                    FormSalesDelOrderCancellCombine.id_store_contact_to = GVSalesDelOrder.GetFocusedRowCellValue("id_store_contact_to").ToString
                    FormSalesDelOrderCancellCombine.ShowDialog()
                    Cursor = Cursors.Default
                Else
                    warningCustom("Combined delivery already process")
                End If
            Else
                warningCustom("Combined delivery not found")
            End If
        End If
        Cursor = Cursors.Default
    End Sub

    Public Function statusCombineDel(ByVal id As String) As Boolean
        Dim query As String = "SELECT id_report_status FROM tb_pl_sales_order_del_combine WHERE id_combine='" + id + "' "
        Dim id_stt As String = execute_query(query, 0, True, "", "", "", "")
        If id_stt <> "1" Then
            Return False
        Else
            Return True
        End If
    End Function

    Private Sub PrintUniqueCodeToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles PrintUniqueCodeToolStripMenuItem1.Click
        Cursor = Cursors.WaitCursor
        If GVPL.FocusedRowHandle >= 0 And GVPL.RowCount > 0 Then
            FormUniqueRevProduct.id_pl_prod_order_rec = GVPL.GetFocusedRowCellValue("id_pl_prod_order_rec").ToString
            FormUniqueRevProduct.ShowDialog()
        End If
        Cursor = Cursors.Default
    End Sub

    Private Sub ToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem1.Click
        Cursor = Cursors.WaitCursor
        If GVSalesReturn.FocusedRowHandle >= 0 And GVSalesReturn.RowCount > 0 Then
            FormUniqueSalesReturn.id_sales_return = GVSalesReturn.GetFocusedRowCellValue("id_sales_return").ToString
            FormUniqueSalesReturn.ShowDialog()
        End If
        Cursor = Cursors.Default
    End Sub

    Private Sub GVSalesReturn_PopupMenuShowing(sender As Object, e As DevExpress.XtraGrid.Views.Grid.PopupMenuShowingEventArgs) Handles GVSalesReturn.PopupMenuShowing
        If GVSalesReturn.GetFocusedRowCellValue("id_ret_type").ToString = "2" Then
            ToolStripMenuItem1.Visible = False
        Else
            ToolStripMenuItem1.Visible = True
        End If
    End Sub

    Private Sub ToolStripMenuItem2_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem2.Click
        Cursor = Cursors.WaitCursor
        If GVSalesReturnQC.FocusedRowHandle >= 0 And GVSalesReturnQC.RowCount > 0 Then
            FormUniqueSalesReturnQC.id_sales_return_qc = GVSalesReturnQC.GetFocusedRowCellValue("id_sales_return_qc").ToString
            FormUniqueSalesReturnQC.ShowDialog()
        End If
        Cursor = Cursors.Default
    End Sub

    Private Sub ToolStripMenuItem3_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem3.Click
        Cursor = Cursors.WaitCursor
        If GVFGTrf.FocusedRowHandle >= 0 And GVFGTrf.RowCount > 0 Then
            FormUniqueFGTrf.id_fg_trf = GVFGTrf.GetFocusedRowCellValue("id_fg_trf").ToString
            FormUniqueFGTrf.fg_trf_number = GVFGTrf.GetFocusedRowCellValue("fg_trf_number").ToString
            FormUniqueFGTrf.ShowDialog()
        End If
        Cursor = Cursors.Default
    End Sub

    Private Sub CancelCombineToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CancelCombineToolStripMenuItem.Click
        If GVSalesReturn.FocusedRowHandle >= 0 And GVSalesReturn.RowCount > 0 Then
            Dim combine_number As String = GVSalesReturn.GetFocusedRowCellValue("combine_number").ToString
            Dim id_store_contact_from As String = GVSalesReturn.GetFocusedRowCellValue("id_store_contact_from").ToString
            Dim id_comp_contact_to As String = GVSalesReturn.GetFocusedRowCellValue("id_comp_contact_to").ToString
            Dim sales_return_store_number As String = GVSalesReturn.GetFocusedRowCellValue("sales_return_store_number").ToString

            If combine_number <> "" Then
                'cek combine status
                Dim id_rs As String = execute_query("SELECT MAX(id_report_status) AS `id_report_status` FROM tb_sales_return WHERE combine_number='" + combine_number + "' ", 0, True, "", "", "", "")
                If id_rs <> "1" Then
                    stopCustom("Can't cancel this combine because already approved ")
                    Exit Sub
                End If


                Dim confirm As DialogResult = DevExpress.XtraEditors.XtraMessageBox.Show("Are you sure you want to cancell combine number : " + combine_number + " ?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
                If confirm = Windows.Forms.DialogResult.Yes Then
                    Cursor = Cursors.WaitCursor
                    Dim query As String = "/*update keterangan rm*/
                    UPDATE tb_report_mark rm 
                    INNER JOIN tb_sales_return r ON r.id_sales_return = rm.id_report
                    SET rm.info_design = ''
                    WHERE (rm.report_mark_type=46 OR rm.report_mark_type=113 OR rm.report_mark_type=120) AND r.combine_number='" + combine_number + "';
                    /*update combine number*/
                    UPDATE tb_sales_return SET combine_number='' WHERE combine_number='" + combine_number + "'; 
                    /*insert log cancell*/
                    INSERT INTO tb_sales_return_cancel_combine_hist(combine_number, id_store_contact_from, id_comp_contact_to, sales_return_store_number, cancelled_date, cancelled_by) 
                    VALUES('" + combine_number + "', '" + id_store_contact_from + "', '" + id_comp_contact_to + "', '" + sales_return_store_number + "', NOW(), " + id_user + "); "
                    execute_non_query(query, True, "", "", "", "")
                    GCSalesReturn.DataSource = Nothing
                    Cursor = Cursors.Default
                End If
            Else
                stopCustom("Combine number not found")
            End If
        End If
    End Sub

    Private Sub ViewPreDel_Opened(sender As Object, e As EventArgs) Handles ViewPreDel.Opened
        If GVSalesDelOrder.RowCount > 0 And GVSalesDelOrder.FocusedRowHandle >= 0 Then
            If GVSalesDelOrder.GetFocusedRowCellValue("is_use_unique_code").ToString = "1" And GVSalesDelOrder.GetFocusedRowCellValue("id_report_status").ToString = "6" Then
                SendEmailConfirmationToolStripMenuItem.Visible = True
            Else
                SendEmailConfirmationToolStripMenuItem.Visible = False
            End If
        End If
    End Sub

    Private Sub SendEmailConfirmationToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SendEmailConfirmationToolStripMenuItem.Click
        If GVSalesDelOrder.RowCount > 0 And GVSalesDelOrder.FocusedRowHandle >= 0 Then
            Dim report_number As String = ""
            Dim id_report As String = ""
            Dim rmt As String = ""
            If GVSalesDelOrder.GetFocusedRowCellValue("id_combine").ToString = "0" Then
                report_number = GVSalesDelOrder.GetFocusedRowCellValue("pl_sales_order_del_number").ToString
                id_report = GVSalesDelOrder.GetFocusedRowCellValue("id_pl_sales_order_del").ToString
                rmt = "43"
            Else
                report_number = GVSalesDelOrder.GetFocusedRowCellValue("combine_number").ToString
                id_report = GVSalesDelOrder.GetFocusedRowCellValue("id_combine").ToString
                rmt = "103"
            End If
            Dim confirm As DialogResult = DevExpress.XtraEditors.XtraMessageBox.Show("Are you sure you want to send delivery confirmation for this delivery : " + report_number + " ?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
            If confirm = Windows.Forms.DialogResult.Yes Then
                Cursor = Cursors.WaitCursor
                Dim d As New ClassSalesDelOrder()
                d.sendDeliveryConfirmationOfflineStore(id_report, rmt)
                Cursor = Cursors.Default
            End If
        End If
    End Sub

    Private Sub LinkManifest_Click(sender As Object, e As EventArgs) Handles LinkManifest.Click
        If GVSalesDelOrder.RowCount > 0 Then
            Cursor = Cursors.WaitCursor
            Dim id_manifest As String = "-1"
            Try
                id_manifest = GVSalesDelOrder.GetFocusedRowCellValue("id_del_manifest").ToString
            Catch ex As Exception
                id_manifest = "-1"
            End Try
            If id_manifest = "" Then
                id_manifest = "-1"
            End If
            If id_manifest <> "-1" Then
                FormDelManifestDet.id_del_manifest = id_manifest
                FormDelManifestDet.ShowDialog()
            End If
            Cursor = Cursors.Default
        End If
    End Sub

    Private Sub load_surat_jalan()
        Try
            FormTrackingReturn.Dispose()
        Catch ex As Exception
        End Try

        FormTrackingReturn.TopLevel = False

        XTPClosingSuratJalan.Controls.Clear()
        XTPClosingSuratJalan.Controls.Add(FormTrackingReturn)

        FormTrackingReturn.for_update = True

        FormTrackingReturn.Show()

        FormTrackingReturn.FormBorderStyle = FormBorderStyle.None
        FormTrackingReturn.Dock = DockStyle.Fill
    End Sub

    Private Sub FormSalesOrderSvcLevel_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
        FormTrackingReturn.Close()
    End Sub

    Private Sub SBInputTanggalPickup_Click(sender As Object, e As EventArgs) Handles SBInputTanggalPickup.Click
        Cursor = Cursors.WaitCursor
        GVSalesReturnOrder.ActiveFilterString = ""
        GVSalesReturnOrder.ActiveFilterString = "[is_select]='Yes' "
        If GVSalesReturnOrder.RowCount = 0 Then
            stopCustom("Please select order first.")
            GVSalesReturnOrder.ActiveFilterString = ""
        Else
            'check
            Dim is_valid As Boolean = True

            For i = 0 To GVSalesReturnOrder.RowCount - 1
                Dim pickup_date As String = GVSalesReturnOrder.GetRowCellValue(i, "pickup_date").ToString
                Dim pickup_date_updated_by As String = GVSalesReturnOrder.GetRowCellValue(i, "pickup_date_updated_by").ToString
                Dim pickup_date_updated_at As String = GVSalesReturnOrder.GetRowCellValue(i, "pickup_date_updated_at").ToString

                If Not pickup_date = "-" Or Not pickup_date_updated_by = "-" Or Not pickup_date_updated_at = "-" Then
                    is_valid = False
                End If
            Next

            If is_valid Then
                FormSalesReturnInputTanggalPickup.ShowDialog()
            Else
                stopCustom("Some order can't input store pick up date.")
            End If
        End If
        GVSalesReturnOrder.ActiveFilterString = ""
        Cursor = Cursors.Default
    End Sub

    Private Sub SBViewAllPickupDate_Click(sender As Object, e As EventArgs) Handles SBViewAllPickupDate.Click
        Cursor = Cursors.WaitCursor
        viewReturnOrderPickupDate()
        'noEdit(8)
        Cursor = Cursors.Default
    End Sub

    Sub viewReturnOrderPickupDate()
        'return query
        Dim query_c As ClassReturn = New ClassReturn()
        Dim query As String = query_c.queryMain("AND a.id_report_status='6' AND mail.id_report IS NOT NULL AND a.pickup_date IS NULL ", "1")
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCSalesReturnOrder.DataSource = data
        GVSalesReturnOrder.BestFitColumns()
    End Sub

    Sub view_store()
        Dim query As String = "
            (SELECT 0 AS id_comp, 'ALL' AS comp_name)
            UNION ALL
            (SELECT id_comp, CONCAT(comp_number, ' - ', comp_name) AS comp_name
            FROM tb_m_comp
            WHERE id_comp_cat = 6)
        "

        viewSearchLookupQuery(SLUEStore, query, "id_comp", "comp_name", "id_comp")
    End Sub

    Private Sub SLUEStore_EditValueChanged(sender As Object, e As EventArgs) Handles SLUEStore.EditValueChanged
        GCSalesReturnOrder.DataSource = Nothing
    End Sub

    Private Sub BarButtonItem1_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem1.ItemClick
        If Not SLUEStore.EditValue.ToString = "0" Then
            GVSalesReturnOrder.ActiveFilterString = "[is_select]='Yes' "

            If GVSalesReturnOrder.RowCount > 0 Then
                Dim already_pickup_date As Boolean = True
                Dim empty_3pl As Boolean = True

                For i = 0 To GVSalesReturnOrder.RowCount - 1
                    If GVSalesReturnOrder.GetRowCellValue(i, "pickup_date").ToString = "-" Then
                        already_pickup_date = False
                    End If

                    If GVSalesReturnOrder.GetRowCellValue(i, "id_3pl_status").ToString = "2" Or GVSalesReturnOrder.GetRowCellValue(i, "id_3pl_status").ToString = "3" Then
                        empty_3pl = False
                    End If
                Next

                If already_pickup_date Then
                    If empty_3pl Then
                        FormSalesReturnOrderMailDet.id_mail_3pl = "-1"
                        'FormSalesReturnOrderMailDet.id_store = SLUEStore.EditValue.ToString
                        FormSalesReturnOrderMailDet.ShowDialog()
                    Else
                        stopCustom("Some order already have 3pl or still waiting.")
                    End If
                Else
                    stopCustom("Some order have empty pick up date.")
                End If
            Else
                stopCustom("Please select order.")
            End If

            GVSalesReturnOrder.ActiveFilterString = ""
        Else
            stopCustom("Please select specific store.")
        End If
    End Sub

    Private Sub BarButtonItem2_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem2.ItemClick
        FormSalesReturnOrderMail.ShowDialog()
    End Sub
End Class