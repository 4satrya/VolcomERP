Public Class FormSalesOrderReportDetNew
    Public id_gen As String = "-1"
    Public gen_number As String = "-1"
    Public id_design As String = "-1"

    Private Sub FormSalesOrderReportDetNew_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim ttp As String = ""
        If id_design <> "-1" Then
            ttp = " (" + FormSalesOrderReport.TxtProduct.Text + ")"
        Else
            ttp = ""
        End If
        Text = gen_number + ttp + " " + Text
        viewDetail()
    End Sub

    Sub viewDetail()
        Cursor = Cursors.WaitCursor
        Dim cond_prod As String = ""
        Dim cond_prod2 As String = ""
        If id_design <> "-1" Then
            cond_prod = "INNER JOIN tb_m_product prod ON prod.id_product = sod.id_product
            INNER JOIN tb_m_design dsg ON dsg.id_design = prod.id_design AND dsg.id_design=" + id_design + " "
            cond_prod2 = "INNER JOIN tb_m_product prod ON prod.id_product = deld.id_product
            INNER JOIN tb_m_design dsg ON dsg.id_design = prod.id_design AND dsg.id_design=" + id_design + " "
        End If

        Dim query As String = "SELECT so.id_sales_order, so.sales_order_number, so.sales_order_date, so.id_so_status, so_stt.so_status, 
        so.id_prepare_status, ps.prepare_status, so.final_comment, so.final_date, ef.employee_name AS `final_by_name`,
        CONCAT(wh.comp_number, ' - ', wh.comp_name) AS `wh`, CONCAT(s.comp_number, ' - ', s.comp_name) AS `destination`,
        SUM(sod.sales_order_det_qty) AS `total_order`, IFNULL(scan.total_trs,0) AS `total_scan`, IFNULL(comp.total_trs,0) AS `total_completed`
        FROM tb_sales_order so
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
                WHERE del.id_report_status!=5 AND so.id_so_status=1 AND !ISNULL(so.id_sales_order_gen)
		        AND so.id_sales_order_gen=" + id_gen + "
		        UNION ALL
		        SELECT so.id_sales_order, (deld.fg_trf_det_qty) AS `total_trs`
		        FROM tb_fg_trf del
		        INNER JOIN tb_sales_order so ON so.id_sales_order = del.id_sales_order
		        INNER JOIN tb_fg_trf_det deld ON deld.id_fg_trf = del.id_fg_trf
		        " + cond_prod2 + "
                WHERE del.id_report_status!=5 AND so.id_so_status=5 AND !ISNULL(so.id_sales_order_gen)
		        AND so.id_sales_order_gen=" + id_gen + "
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
                WHERE del.id_report_status=6 AND so.id_so_status=1 AND !ISNULL(so.id_sales_order_gen)
		        AND so.id_sales_order_gen=" + id_gen + "
		        UNION ALL
		        SELECT so.id_sales_order, (deld.fg_trf_det_qty) AS `total_trs`
		        FROM tb_fg_trf del
		        INNER JOIN tb_sales_order so ON so.id_sales_order = del.id_sales_order
		        INNER JOIN tb_fg_trf_det deld ON deld.id_fg_trf = del.id_fg_trf
		        " + cond_prod2 + "
                WHERE del.id_report_status=6 AND so.id_so_status=5 AND !ISNULL(so.id_sales_order_gen)
		        AND so.id_sales_order_gen=" + id_gen + "
	        ) trs 
	        GROUP BY trs.id_sales_order
        ) comp ON comp.id_sales_order = so.id_sales_order
        LEFT JOIN tb_m_user u ON u.id_user = so.final_by
        LEFT JOIN tb_m_employee ef ON ef.id_employee = u.id_employee
        WHERE so.id_sales_order_gen=" + id_gen + " AND so.id_report_status=6 
        GROUP BY so.id_sales_order
        ORDER BY so.id_sales_order ASC "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCNew.DataSource = data
        GVNew.BestFitColumns()
        Cursor = Cursors.Default
    End Sub

    Private Sub FormSalesOrderReportDetNew_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub BtnClose_Click(sender As Object, e As EventArgs) Handles BtnClose.Click
        Close()
    End Sub

    Private Sub BtnPrint_Click(sender As Object, e As EventArgs) Handles BtnPrint.Click
        Cursor = Cursors.WaitCursor
        print_raw(GCNew, "")
        Cursor = Cursors.Default
    End Sub

    Private Sub GVNew_DoubleClick(sender As Object, e As EventArgs) Handles GVNew.DoubleClick
        If GVNew.RowCount > 0 And GVNew.FocusedRowHandle >= 0 Then
            FormSalesOrderReportDet.id_design = id_design
            FormSalesOrderReportDet.id_so = GVNew.GetFocusedRowCellValue("id_sales_order").ToString
            FormSalesOrderReportDet.id_so_status = GVNew.GetFocusedRowCellValue("id_so_status").ToString
            FormSalesOrderReportDet.so_number = GVNew.GetFocusedRowCellValue("sales_order_number").ToString
            FormSalesOrderReportDet.from = GVNew.GetFocusedRowCellValue("wh").ToString
            FormSalesOrderReportDet.dest_to = GVNew.GetFocusedRowCellValue("destination").ToString
            FormSalesOrderReportDet.created_date = GVNew.GetFocusedRowCellValue("sales_order_date")
            FormSalesOrderReportDet.ShowDialog()
        End If
    End Sub
End Class