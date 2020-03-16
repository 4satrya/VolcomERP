Public Class FormSalesOrder 
    Dim bnew_active As String = "1"
    Dim bedit_active As String = "1"
    Dim bdel_active As String = "1"
    Dim id_season_par As String = "-1"
    Dim super_user As String = get_setup_field("id_role_super_admin")
    Public id_type As String = "-1"
    Public id_user_special = "-1"

    Private Sub FormSalesOrder_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'date now
        Dim data As DataTable = execute_query("SELECT DATE(NOW()) AS `tgl`", -1, True, "", "", "", "")
        DEFrom.EditValue = data.Rows(0)("tgl")
        DEUntil.EditValue = data.Rows(0)("tgl")

        'viewSalesOrder()
        'viewSalesOrderGen()
        'VIEW OPTION
        If id_type = "1" Then 'prepare uniform
            XTPPrepareGenerate.PageVisible = False
            GridColumnPeriodUni.VisibleIndex = 2
            GridColumnPrepareType.VisibleIndex = 3
        End If
    End Sub

    Sub viewSalesOrderGen()
        Dim query_c As ClassSalesOrder = New ClassSalesOrder()
        Dim query As String = ""

        'date
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
        Dim cond As String = "AND (gen.sales_order_gen_date>='" + date_from_selected + "' AND gen.sales_order_gen_date<='" + date_until_selected + "') "

        If id_role_login <> super_user And id_role_login <> "24" Then
            query = query_c.queryMainGen("AND gen.id_user='" + id_user + "' " + cond, "2")
        Else
            query = query_c.queryMainGen(cond, "2")
        End If
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCGen.DataSource = data
        check_menu()
    End Sub


    Sub viewSalesOrder()
        Dim query_c As ClassSalesOrder = New ClassSalesOrder()
        Dim cond As String = "AND ISNULL(a.id_sales_order_gen) "
        If id_role_login <> super_user Then
            cond += "AND a.id_user_created='" + id_user + "' "
        End If

        'date
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
        cond += "AND (a.sales_order_date>='" + date_from_selected + "' AND a.sales_order_date<='" + date_until_selected + "') "

        If id_type = "1" Then 'prepare uniform
            cond += "AND !ISNULL(a.id_emp_uni_period) "
        End If
        'Dim query As String = query_c.queryMain(cond, "2")
        Dim query As String = "SELECT a.id_sales_order, a.id_store_contact_to, d.id_commerce_type,d.id_comp AS `id_store`, d.is_use_unique_code, d.id_store_type, d.comp_number AS `store_number`, d.comp_name AS `store`, d.address_primary as `store_address`, CONCAT(d.comp_number,' - ',d.comp_name) AS store_name_to,a.id_report_status, f.report_status, a.id_warehouse_contact_to, CONCAT(wh.comp_number,' - ',wh.comp_name) AS warehouse_name_to, (wh.comp_number) AS warehouse_number_to,  (wh.comp_name) AS `warehouse`, wh.id_drawer_def AS `id_wh_drawer`, drw.wh_drawer_code, drw.wh_drawer, a.sales_order_note, a.sales_order_date, a.sales_order_note, a.sales_order_number, 
        a.sales_order_ol_shop_number, a.sales_order_ol_shop_date, (a.sales_order_date) AS sales_order_date, ps.id_prepare_status, ps.prepare_status, 
        ('No') AS `is_select`, cat.id_so_status, cat.so_status, ot.order_type, del_cat.id_so_cat, del_cat.so_cat, 
        IFNULL(so_item.tot_so,0.00) AS `total_order`,  IFNULL(an.fg_so_reff_number,'-') AS `fg_so_reff_number`,
        a.id_so_type,prep.id_user, prep.prepared_date, gen.id_sales_order_gen, IFNULL(gen.sales_order_gen_reff, '-') AS `sales_order_gen_reff`, a.final_comment, a.final_date, 
        eu.period_name, ut.uni_type, ube.employee_code, ube.employee_name 
        FROM tb_sales_order a 
        LEFT JOIN ( 
	        SELECT so_det.id_sales_order, SUM(so_det.sales_order_det_qty) AS tot_so  
	        FROM tb_sales_order_det so_det GROUP BY so_det.id_sales_order 
        ) so_item ON so_item.id_sales_order = a.id_sales_order 
        INNER JOIN tb_m_comp_contact c ON c.id_comp_contact = a.id_store_contact_to 
        INNER JOIN tb_m_comp d ON c.id_comp = d.id_comp 
        INNER JOIN tb_m_comp_contact wh_c ON wh_c.id_comp_contact = a.id_warehouse_contact_to 
        INNER JOIN tb_m_comp wh ON wh_c.id_comp = wh.id_comp 
        INNER JOIN tb_lookup_report_status f ON f.id_report_status = a.id_report_status 
        INNER JOIN tb_lookup_prepare_status ps ON ps.id_prepare_status = a.id_prepare_status 
        INNER JOIN tb_lookup_so_status cat ON cat.id_so_status = a.id_so_status 
        INNER JOIN tb_lookup_order_type ot ON ot.id_order_type = cat.id_order_type
        Left JOIN( 
	        Select a.id_report, a.id_user, a.report_mark_datetime AS `prepared_date` 
	        From tb_report_mark a Where a.report_mark_type ='39' and a.id_report_status='1' group by a.id_report 
        ) prep On prep.id_report = a.id_sales_order 
        LEFT JOIN tb_fg_so_reff an On an.id_fg_so_reff = a.id_fg_so_reff 
        LEFT JOIN tb_lookup_pd_alloc alloc On alloc.id_pd_alloc = d.id_pd_alloc 
        LEFT JOIN tb_lookup_so_cat del_cat On del_cat.id_so_cat = alloc.id_so_cat 
        LEFT JOIN tb_sales_order_gen gen ON gen.id_sales_order_gen = a.id_sales_order_gen 
        LEFT JOIN tb_m_wh_drawer drw ON drw.id_wh_drawer = wh.id_drawer_def 
        LEFT JOIN tb_emp_uni_period eu ON eu.id_emp_uni_period=a.id_emp_uni_period 
        LEFT JOIN tb_lookup_uni_type ut ON ut.id_uni_type = a.id_uni_type 
        LEFT JOIN tb_emp_uni_budget ub ON ub.id_emp_uni_budget = a.id_emp_uni_budget
        LEFT JOIN tb_m_employee ube ON ube.id_employee = ub.id_employee 
        WHERE a.id_sales_order>0 " + cond + "
        ORDER BY a.id_sales_order DESC "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCSalesOrder.DataSource = data
        GVSalesOrder.BestFitColumns()
        check_menu()
        RepositoryItemProgressBar1.LookAndFeel.SkinName = "Blue"
    End Sub

    Private Sub FormSalesOrder_Activated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Activated
        FormMain.show_rb(Name)
        check_menu()
    End Sub

    Private Sub FormSalesOrder_Deactivate(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Deactivate
        FormMain.hide_rb()
    End Sub

    Sub noManipulating()
        Try
            Dim indeks As Integer = 0
            If XTCSOGeneral.SelectedTabPageIndex = 0 Then
                indeks = GVSalesOrder.FocusedRowHandle
            Else
                indeks = GVGen.FocusedRowHandle
            End If
            If indeks < 0 Then
                bnew_active = "1"
                bedit_active = "0"
                bdel_active = "0"
            Else
                bnew_active = "1"
                bedit_active = "1"
                bdel_active = "1"
            End If
            checkFormAccess(Name)
            button_main(bnew_active, bedit_active, bdel_active)
        Catch ex As Exception

        End Try
    End Sub

    Sub check_menu()
        If XTCSOGeneral.SelectedTabPageIndex = 0 Then
            'based on receive
            If GVSalesOrder.RowCount < 1 Then
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
        ElseIf XTCSOGeneral.SelectedTabPageIndex = 1 Then
            If GVGen.RowCount < 1 Then
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
        End If
    End Sub

    Private Sub XTCSalesTarget_SelectedPageChanged(ByVal sender As System.Object, ByVal e As DevExpress.XtraTab.TabPageChangedEventArgs) Handles XTCSalesOrder.SelectedPageChanged
        check_menu()
    End Sub

    Private Sub GVSalesOrder_FocusedRowChanged(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles GVSalesOrder.FocusedRowChanged
        GCDetailSO.DataSource = Nothing
        'noManipulating()
        'viewDet()
    End Sub

    Sub viewDet()
        Dim id_sales_order As String = "-1"
        Try
            id_sales_order = GVSalesOrder.GetFocusedRowCellValue("id_sales_order").ToString
        Catch ex As Exception
        End Try
        Dim id_so_status As String = "-1"
        Try
            id_so_status = GVSalesOrder.GetFocusedRowCellValue("id_so_status").ToString
        Catch ex As Exception
        End Try
        view_list_so(id_sales_order, id_so_status)
    End Sub

    Private Sub GVItemList_CustomColumnDisplayText(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs) Handles GVDetailSO.CustomColumnDisplayText
        If e.Column.FieldName = "no" Then
            e.DisplayText = (e.ListSourceRowIndex + 1).ToString()
        End If
    End Sub

    Sub view_list_so(ByVal id_sales_order As String, ByVal id_type_par As String)
        Dim query As String = ""
        If id_type_par >= "1" And id_type_par <= "4" Then
            query = "CALL view_sales_order_limit('" + id_sales_order + "', '0', '0')"
        ElseIf id_type_par = "5" Then
            query = "CALL view_sales_order_limit_for_trf('" + id_sales_order + "', '0', '0')"
        Else
            query = "CALL view_sales_order_limit('" + id_sales_order + "', '0', '0')"
        End If
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCDetailSO.DataSource = data
    End Sub

    Private Sub LabelControl1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub SLESeason_EditValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Cursor = Cursors.WaitCursor
        Cursor = Cursors.Default
    End Sub

    Private Sub SLEDel_EditValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Cursor = Cursors.WaitCursor
        Cursor = Cursors.Default
    End Sub

    Private Sub BtnView_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        'Cursor = Cursors.WaitCursor
        'Dim tracker_no As String = "-1"
        'Try
        '    tracker_no = SLETracker.EditValue.ToString
        'Catch ex As Exception
        'End Try
        'If tracker_no = "-1" Then
        '    stopCustom("Please select tracker number !")
        'Else
        '    infoCustom("Sip bro")
        'End If
        'Cursor = Cursors.Default
    End Sub

    Private Sub GVSalesOrder_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GVSalesOrder.DoubleClick
        If GVSalesOrder.RowCount > 0 Then
            Cursor = Cursors.WaitCursor
            FormMain.but_edit()
            Cursor = Cursors.Default
        End If
    End Sub

    Private Sub XTCSOGeneral_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles XTCSOGeneral.Click

    End Sub

    Private Sub XTCSOGeneral_SelectedPageChanged(sender As Object, e As DevExpress.XtraTab.TabPageChangedEventArgs) Handles XTCSOGeneral.SelectedPageChanged
        check_menu()
    End Sub

    Private Sub GVGen_DoubleClick(sender As Object, e As EventArgs) Handles GVGen.DoubleClick
        If GVGen.FocusedRowHandle >= 0 And GVGen.RowCount > 0 Then
            FormMain.but_edit()
        End If
    End Sub

    Private Sub BtnView_Click_1(sender As Object, e As EventArgs) Handles BtnView.Click
        Cursor = Cursors.WaitCursor
        If XTCSOGeneral.SelectedTabPageIndex = 0 Then
            viewSalesOrder()
        Else
            viewSalesOrderGen()
        End If
        Cursor = Cursors.Default
    End Sub

    Private Sub BtnViewProgress_Click(sender As Object, e As EventArgs) Handles BtnViewProgress.Click
        Cursor = Cursors.WaitCursor
        noManipulating()
        viewDet()
        Cursor = Cursors.Default
    End Sub

    Public Function isWHProcess() As Boolean
        Dim so As New ClassSalesOrder()
        Dim qcek As String = "SELECT a.id_sales_order 
        FROM tb_sales_order a
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
        WHERE a.id_sales_order>0 AND a.id_sales_order='" + GVSalesOrder.GetFocusedRowCellValue("id_sales_order").ToString + "' AND ISNULL(lp.printed_by) "
        'Dim qcek As String = so.queryMain("AND a.id_sales_order='" + GVSalesOrder.GetFocusedRowCellValue("id_sales_order").ToString + "' AND ISNULL(lp.printed_by) ", "1")
        Dim dcek As DataTable = execute_query(qcek, -1, True, "", "", "", "")
        If dcek.Rows.Count > 0 Then
            Return False
        Else
            Return True
        End If
    End Function

    Private Sub CancellOrderToolStripMenuItem_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub CancellOrderToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles CancellOrderToolStripMenuItem1.Click
        If GVSalesOrder.RowCount > 0 And GVSalesOrder.FocusedRowHandle >= 0 Then
            Cursor = Cursors.WaitCursor
            If Not isWHProcess() Then
                FormMenuAuth.type = "3"
                FormMenuAuth.ShowDialog()
            Else
                warningCustom("Already process by Warehouse Department")
            End If
            Cursor = Cursors.Default
        End If
    End Sub

    Private Sub ContextMenuStrip1_Opened(sender As Object, e As EventArgs) Handles ContextMenuStrip1.Opened
        If GVSalesOrder.GetFocusedRowCellValue("id_report_status").ToString <> "6" Then
            CancellOrderToolStripMenuItem1.Enabled = False
        Else
            CancellOrderToolStripMenuItem1.Enabled = True
        End If
    End Sub

    Private Sub BtnCreateNewAlloc_Click(sender As Object, e As EventArgs) Handles BtnCreateNewAlloc.Click
        Cursor = Cursors.WaitCursor
        FormSalesOrderDet.action = "ins"
        FormSalesOrderDet.is_transfer_data = "1"
        FormSalesOrderDet.id_sales_order = "-1"
        FormSalesOrderDet.ShowDialog()
        Cursor = Cursors.Default
    End Sub
End Class