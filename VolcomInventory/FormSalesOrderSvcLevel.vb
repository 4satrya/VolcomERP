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
        Dim query_c As ClassReturn = New ClassReturn()
        Dim query As String = query_c.queryMain("AND a.id_report_status='6' AND (a.sales_return_order_date>='" + date_from_selected + "' AND a.sales_return_order_date<='" + date_until_selected + "') " + cond_status, "1")
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCSalesReturnOrder.DataSource = data
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
        Cursor = Cursors.Default
    End Sub

    Private Sub FormSalesOrderSvcLevel_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        viewPackingStatus()
        viewReportStatus()

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
            FormViewSalesReturnOrder.id_sales_return_order = GVSalesReturnOrder.GetFocusedRowCellValue("id_sales_return_order").ToString
            FormViewSalesReturnOrder.is_detail_soh = "1"
            FormViewSalesReturnOrder.ShowDialog()
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
                FormSalesOrderPacking.id_trans = id_prepare
                FormSalesOrderPacking.id_cur_status = id_cur_stt
                FormSalesOrderPacking.id_pop_up = "2"
                FormSalesOrderPacking.ShowDialog()
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
                If alloc_cek = "2" Then
                    GVSalesOrder.Columns("is_select").OptionsColumn.AllowEdit = False
                Else
                    GVSalesOrder.Columns("is_select").OptionsColumn.AllowEdit = True
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
                If cek And id_prepare_status = "1" Then
                    GVSalesOrder.SetRowCellValue(i, "is_select", "Yes")
                Else
                    GVSalesOrder.SetRowCellValue(i, "is_select", "No")
                End If
            Next
        End If
    End Sub
End Class