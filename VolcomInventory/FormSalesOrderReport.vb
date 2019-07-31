Public Class FormSalesOrderReport
    Public id_design_new_order As String = "-1"
    Public id_design_all_order As String = "-1"

    Private Sub FormSalesOrderReport_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim now As DateTime = getTimeDB()
        DEFrom.EditValue = now
        DEUntil.EditValue = now
        DEFromAll.EditValue = now
        DEUntilAll.EditValue = now
    End Sub

    Private Sub FormSalesOrderReport_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub FormSalesOrderReport_Activated(sender As Object, e As EventArgs) Handles MyBase.Activated
        FormMain.show_rb(Name)
        checkFormAccess(Name)
    End Sub

    Private Sub FormSalesOrderReport_Deactivate(sender As Object, e As EventArgs) Handles MyBase.Deactivate
        FormMain.hide_rb()
    End Sub

    Private Sub BtnView_Click(sender As Object, e As EventArgs) Handles BtnView.Click
        If CEFindAllProduct.EditValue = False And id_design_new_order = "-1" Then
            stopCustom("Please select product first")
            Exit Sub
        End If
        viewNewOrder()
    End Sub

    Sub viewNewOrder()
        Cursor = Cursors.WaitCursor
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

        'find spesific product
        Dim cond_prod As String = ""
        Dim cond_prod2 As String = ""
        If CEFindAllProduct.EditValue = False Then
            cond_prod = "INNER JOIN tb_m_product prod ON prod.id_product = sod.id_product
            INNER JOIN tb_m_design dsg ON dsg.id_design = prod.id_design AND dsg.id_design=" + id_design_new_order + " "
            cond_prod2 = "INNER JOIN tb_m_product prod ON prod.id_product = deld.id_product
            INNER JOIN tb_m_design dsg ON dsg.id_design = prod.id_design AND dsg.id_design=" + id_design_new_order + " "
        End If

        Dim query As String = "SELECT sog.id_sales_order_gen, sog.id_so_status, sog.sales_order_gen_reff, sog.sales_order_gen_date, sog.sales_order_gen_note, sog.id_report_status, 
        sog.id_user, e.id_employee, e.employee_name,
        SUM(sod.sales_order_det_qty) AS `total_order`, IFNULL(sc.total_trs,0) AS `total_scan`, IFNULL(comp.total_trs,0) AS `total_completed`
        FROM tb_sales_order_gen sog
        INNER JOIN tb_m_user u ON u.id_user = sog.id_user
        INNER JOIN tb_m_employee e ON e.id_employee = u.id_employee
        INNER JOIN tb_sales_order so ON so.id_sales_order_gen = sog.id_sales_order_gen 
        INNER JOIN tb_sales_order_det sod ON sod.id_sales_order = so.id_sales_order
        " + cond_prod + "
        LEFT JOIN (
	        SELECT trs.id_sales_order_gen, SUM(total_trs) AS `total_trs`
	        FROM (
		        SELECT so.id_sales_order_gen, (deld.pl_sales_order_del_det_qty) AS `total_trs`
		        FROM tb_pl_sales_order_del del
		        INNER JOIN tb_sales_order so ON so.id_sales_order = del.id_sales_order
		        INNER JOIN tb_pl_sales_order_del_det deld ON deld.id_pl_sales_order_del = del.id_pl_sales_order_del
		         " + cond_prod2 + "
                WHERE del.id_report_status!=5 AND so.id_so_status=1 AND !ISNULL(so.id_sales_order_gen)
		        AND del.pl_sales_order_del_date>='" + date_from_selected + "'
		        UNION ALL
		        SELECT so.id_sales_order_gen, (deld.fg_trf_det_qty) AS `total_trs`
		        FROM tb_fg_trf del
		        INNER JOIN tb_sales_order so ON so.id_sales_order = del.id_sales_order
		        INNER JOIN tb_fg_trf_det deld ON deld.id_fg_trf = del.id_fg_trf
		        " + cond_prod2 + "
                WHERE del.id_report_status!=5 AND so.id_so_status=5 AND !ISNULL(so.id_sales_order_gen)
		        AND del.fg_trf_date>='" + date_from_selected + "'
	        ) trs 
	        GROUP BY trs.id_sales_order_gen
        ) sc ON sc.id_sales_order_gen = sog.id_sales_order_gen
        LEFT JOIN (
	        SELECT trs.id_sales_order_gen, SUM(total_trs) AS `total_trs`
	        FROM (
		        SELECT so.id_sales_order_gen, (deld.pl_sales_order_del_det_qty) AS `total_trs`
		        FROM tb_pl_sales_order_del del
		        INNER JOIN tb_sales_order so ON so.id_sales_order = del.id_sales_order
		        INNER JOIN tb_pl_sales_order_del_det deld ON deld.id_pl_sales_order_del = del.id_pl_sales_order_del
		        " + cond_prod2 + "
                WHERE del.id_report_status=6 AND so.id_so_status=1 AND !ISNULL(so.id_sales_order_gen)
		        AND del.pl_sales_order_del_date>='" + date_from_selected + "'
		        UNION ALL
		        SELECT so.id_sales_order_gen, (deld.fg_trf_det_qty) AS `total_trs`
		        FROM tb_fg_trf del
		        INNER JOIN tb_sales_order so ON so.id_sales_order = del.id_sales_order
		        INNER JOIN tb_fg_trf_det deld ON deld.id_fg_trf = del.id_fg_trf
		        " + cond_prod2 + "
                WHERE del.id_report_status=6 AND so.id_so_status=5 AND !ISNULL(so.id_sales_order_gen)
		        AND del.fg_trf_date>='" + date_from_selected + "'
	        ) trs 
	        GROUP BY trs.id_sales_order_gen
        ) comp ON comp.id_sales_order_gen = sog.id_sales_order_gen
        WHERE sog.id_report_status=6 AND sog.id_so_status=1 AND (sog.sales_order_gen_date>='" + date_from_selected + "' AND sog.sales_order_gen_date<='" + date_until_selected + "')
        GROUP BY sog.id_sales_order_gen "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCNew.DataSource = data
        GVNew.BestFitColumns()
        If GVNew.RowCount > 0 Then
            CEShowHighlight.Enabled = True
        End If
        Cursor = Cursors.Default
    End Sub

    Private Sub GVNew_DoubleClick(sender As Object, e As EventArgs) Handles GVNew.DoubleClick
        If GVNew.RowCount > 0 And GVNew.FocusedRowHandle >= 0 Then
            Cursor = Cursors.WaitCursor
            FormSalesOrderReportDetNew.id_design = id_design_new_order
            FormSalesOrderReportDetNew.id_gen = GVNew.GetFocusedRowCellValue("id_sales_order_gen").ToString
            FormSalesOrderReportDetNew.gen_number = GVNew.GetFocusedRowCellValue("sales_order_gen_reff").ToString
            FormSalesOrderReportDetNew.ShowDialog()
            Cursor = Cursors.Default
        End If
    End Sub

    Private Sub BtnViewAll_Click(sender As Object, e As EventArgs) Handles BtnViewAll.Click
        If CEFindAllProductSO.EditValue = False And id_design_all_order = "-1" Then
            stopCustom("Please select product first")
            Exit Sub
        End If

        viewAllOrder()
    End Sub

    Sub viewAllOrder()
        Cursor = Cursors.WaitCursor
        Dim date_from_selected As String = "0000-01-01"
        Dim date_until_selected As String = "9999-01-01"
        Try
            date_from_selected = DateTime.Parse(DEFromAll.EditValue.ToString).ToString("yyyy-MM-dd")
        Catch ex As Exception
        End Try
        Try
            date_until_selected = DateTime.Parse(DEUntilAll.EditValue.ToString).ToString("yyyy-MM-dd")
        Catch ex As Exception
        End Try

        'find spesific product
        Dim cond_prod As String = ""
        Dim cond_prod2 As String = ""
        If CEFindAllProductSO.EditValue = False Then
            cond_prod = "INNER JOIN tb_m_product prod ON prod.id_product = sod.id_product
            INNER JOIN tb_m_design dsg ON dsg.id_design = prod.id_design AND dsg.id_design=" + id_design_all_order + " "
            cond_prod2 = "INNER JOIN tb_m_product prod ON prod.id_product = deld.id_product
            INNER JOIN tb_m_design dsg ON dsg.id_design = prod.id_design AND dsg.id_design=" + id_design_all_order + " "
        End If

        Dim query As String = "SELECT so.id_sales_order, so.sales_order_number, sog.sales_order_gen_reff, so.sales_order_date, so.id_so_status, so_stt.so_status, 
        so.id_prepare_status, ps.prepare_status, so.final_comment, so.final_date, ef.employee_name AS `final_by_name`,
        CONCAT(wh.comp_number, ' - ', wh.comp_name) AS `wh`, CONCAT(s.comp_number, ' - ', s.comp_name) AS `destination`,
        SUM(sod.sales_order_det_qty) AS `total_order`, IFNULL(scan.total_trs,0) AS `total_scan`, IFNULL(comp.total_trs,0) AS `total_completed`
        FROM tb_sales_order so
        LEFT JOIN tb_sales_order_gen sog ON sog.id_sales_order_gen = so.id_sales_order_gen
        INNER JOIN tb_lookup_so_status so_stt ON so_stt.id_so_status = so.id_so_status
        INNER JOIN tb_m_comp_contact whc ON whc.id_comp_contact = so.id_warehouse_contact_to
        INNER JOIN tb_m_comp wh ON wh.id_comp = whc.id_comp
        INNER JOIN tb_m_comp_contact sc ON sc.id_comp_contact = so.id_store_contact_to
        INNER JOIN tb_m_comp s ON s.id_comp = sc.id_comp
        INNER JOIN tb_lookup_prepare_status ps ON ps.id_prepare_status = so.id_prepare_status
        INNER JOIN tb_sales_order_det sod ON sod.id_sales_order = so.id_sales_order
        " + cond_prod + "
        LEFT JOIN (
	        SELECT trs.id_sales_order, SUM(total_trs) AS `total_trs`
	        FROM (
		        SELECT so.id_sales_order, (deld.pl_sales_order_del_det_qty) AS `total_trs`
		        FROM tb_pl_sales_order_del del
		        INNER JOIN tb_sales_order so ON so.id_sales_order = del.id_sales_order
		        INNER JOIN tb_pl_sales_order_del_det deld ON deld.id_pl_sales_order_del = del.id_pl_sales_order_del
                " + cond_prod2 + "
		        WHERE del.id_report_status!=5 AND so.id_so_status!=5
		        AND so.sales_order_date>='" + date_from_selected + "'
		        UNION ALL
		        SELECT so.id_sales_order, (deld.fg_trf_det_qty) AS `total_trs`
		        FROM tb_fg_trf del
		        INNER JOIN tb_sales_order so ON so.id_sales_order = del.id_sales_order
		        INNER JOIN tb_fg_trf_det deld ON deld.id_fg_trf = del.id_fg_trf
                " + cond_prod2 + "
		        WHERE del.id_report_status!=5 AND so.id_so_status=5
		        AND so.sales_order_date>='" + date_from_selected + "'
	        ) trs 
	        GROUP BY trs.id_sales_order
        ) scan ON scan.id_sales_order = so.id_sales_order
        LEFT JOIN (
	        SELECT trs.id_sales_order, SUM(total_trs) AS `total_trs`
	        FROM (
		        SELECT so.id_sales_order, (deld.pl_sales_order_del_det_qty) AS `total_trs`
		        FROM tb_pl_sales_order_del del
		        INNER JOIN tb_sales_order so ON so.id_sales_order = del.id_sales_order
		        INNER JOIN tb_pl_sales_order_del_det deld ON deld.id_pl_sales_order_del = del.id_pl_sales_order_del
                " + cond_prod2 + "
		        WHERE del.id_report_status=6 AND so.id_so_status!=5
		        AND so.sales_order_date>='" + date_from_selected + "'
		        UNION ALL
		        SELECT so.id_sales_order, (deld.fg_trf_det_qty) AS `total_trs`
		        FROM tb_fg_trf del
		        INNER JOIN tb_sales_order so ON so.id_sales_order = del.id_sales_order
		        INNER JOIN tb_fg_trf_det deld ON deld.id_fg_trf = del.id_fg_trf
                " + cond_prod2 + "
		        WHERE del.id_report_status=6 AND so.id_so_status=5
		        AND so.sales_order_date>='" + date_from_selected + "'
	        ) trs 
	        GROUP BY trs.id_sales_order
        ) comp ON comp.id_sales_order = so.id_sales_order
        LEFT JOIN tb_m_user u ON u.id_user = so.final_by
        LEFT JOIN tb_m_employee ef ON ef.id_employee = u.id_employee
        WHERE so.id_report_status=6 AND (so.sales_order_date>='" + date_from_selected + "' AND so.sales_order_date<='" + date_until_selected + "')
        GROUP BY so.id_sales_order
        ORDER BY so.id_sales_order ASC "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCAll.DataSource = data
        GVAll.BestFitColumns()
        Cursor = Cursors.Default
    End Sub

    Private Sub GVAll_DoubleClick(sender As Object, e As EventArgs) Handles GVAll.DoubleClick
        If GVAll.RowCount > 0 And GVAll.FocusedRowHandle >= 0 Then
            FormSalesOrderReportDet.id_design = id_design_all_order
            FormSalesOrderReportDet.id_so = GVAll.GetFocusedRowCellValue("id_sales_order").ToString
            FormSalesOrderReportDet.id_so_status = GVAll.GetFocusedRowCellValue("id_so_status").ToString
            FormSalesOrderReportDet.so_number = GVAll.GetFocusedRowCellValue("sales_order_number").ToString
            FormSalesOrderReportDet.from = GVAll.GetFocusedRowCellValue("wh").ToString
            FormSalesOrderReportDet.dest_to = GVAll.GetFocusedRowCellValue("destination").ToString
            FormSalesOrderReportDet.created_date = GVAll.GetFocusedRowCellValue("sales_order_date")
            FormSalesOrderReportDet.ShowDialog()
        End If
    End Sub

    Private Sub DEFrom_EditValueChanged(sender As Object, e As EventArgs) Handles DEFrom.EditValueChanged
        resetNew()
    End Sub

    Sub resetNew()
        GCNew.DataSource = Nothing
        CEShowHighlight.EditValue = False
        CEShowHighlight.Enabled = False
        id_design_new_order = "-1"
        TxtProduct.Text = ""
    End Sub

    Sub resetAllOrder()
        GCAll.DataSource = Nothing
        id_design_all_order = "-1"
        TxtProductSO.Text = ""
    End Sub

    Private Sub DEUntil_EditValueChanged(sender As Object, e As EventArgs) Handles DEUntil.EditValueChanged
        resetNew()
    End Sub

    Private Sub CEShowHighlight_CheckedChanged(sender As Object, e As EventArgs) Handles CEShowHighlight.CheckedChanged
        AddHandler GVNew.RowStyle, AddressOf custom_cell
        GCNew.Focus()
    End Sub

    Public Sub custom_cell(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Grid.RowStyleEventArgs)
        Dim View As DevExpress.XtraGrid.Views.Grid.GridView = sender

        If CEShowHighlight.EditValue = True Then
            Dim currview As DevExpress.XtraGrid.Views.Grid.GridView = TryCast(sender, DevExpress.XtraGrid.Views.Grid.GridView)
            Dim pros_scan As Decimal = 0.00
            Try
                pros_scan = currview.GetRowCellValue(e.RowHandle, "pros_scan")
            Catch ex As Exception
            End Try
            Dim pros_completed As Decimal = 0.00
            Try
                pros_completed = currview.GetRowCellValue(e.RowHandle, "pros_completed")
            Catch ex As Exception
            End Try

            If pros_scan < 100 Or pros_completed < 100 Then
                e.Appearance.BackColor = Color.Yellow
            Else
                e.Appearance.BackColor = Color.Empty
            End If
        Else
            e.Appearance.BackColor = Color.Empty
        End If
    End Sub

    Private Sub CheckEdit1_EditValueChanged(sender As Object, e As EventArgs) Handles CEFindAllProduct.EditValueChanged
        resetNew()
        If CEFindAllProduct.EditValue = True Then
            BtnBrowseProduct.Enabled = False
        Else
            BtnBrowseProduct.Enabled = True
        End If
    End Sub

    Private Sub BtnBrowseProduct_Click(sender As Object, e As EventArgs) Handles BtnBrowseProduct.Click
        Cursor = Cursors.WaitCursor
        FormSearchDesign.id_pop_up = "1"
        FormSearchDesign.ShowDialog()
        Cursor = Cursors.Default
    End Sub

    Private Sub CEFindAllProductSO_EditValueChanged(sender As Object, e As EventArgs) Handles CEFindAllProductSO.EditValueChanged
        resetAllOrder()
        If CEFindAllProductSO.EditValue = True Then
            BtnBrowseProductSO.Enabled = False
        Else
            BtnBrowseProductSO.Enabled = True
        End If
    End Sub

    Private Sub DEFromAll_EditValueChanged(sender As Object, e As EventArgs) Handles DEFromAll.EditValueChanged
        resetAllOrder()
    End Sub

    Private Sub DEUntilAll_EditValueChanged(sender As Object, e As EventArgs) Handles DEUntilAll.EditValueChanged
        resetAllOrder()
    End Sub

    Private Sub BtnBrowseProductSO_Click(sender As Object, e As EventArgs) Handles BtnBrowseProductSO.Click
        Cursor = Cursors.WaitCursor
        FormSearchDesign.id_pop_up = "2"
        FormSearchDesign.ShowDialog()
        Cursor = Cursors.Default
    End Sub
End Class