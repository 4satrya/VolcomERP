Public Class FormSalesOrderReportDet
    Public id_so As String = "-1"
    Public so_number As String = "-1"
    Public from As String = "-1"
    Public dest_to As String = "-1"
    Public created_date As DateTime = Nothing
    Public id_so_status As String = "-1"
    Public id_design As String = "-1"

    Private Sub FormSalesOrderReportDet_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        TxtFrom.Text = from
        TxtTo.Text = dest_to
        TxtNumber.Text = so_number
        DECreated.EditValue = created_date
        viewDetail()
    End Sub

    Sub viewDetail()
        Cursor = Cursors.WaitCursor
        Dim cond_prod As String = ""
        Dim cond_prod2 As String = ""
        If id_design <> "-1" Then
            cond_prod = "AND d.id_design=" + id_design + " "
            cond_prod2 = "INNER JOIN tb_m_product prod ON prod.id_product = deld.id_product
            INNER JOIN tb_m_design dsg ON dsg.id_design = prod.id_design AND dsg.id_design=" + id_design + " "
        End If

        Dim query As String = "SELECT so.id_sales_order, sod.id_sales_order_det, 
        p.product_full_code AS `barcode`, d.design_code AS `code`, d.design_display_name AS `name`, cd.code_detail_name AS `size`,
        sod.design_price, dpt.design_price_type, 
        SUM(sod.sales_order_det_qty) AS `total_order`, IFNULL(scan.total_trs,0) AS `total_scan`, IFNULL(comp.total_trs,0) AS `total_completed`
        FROM tb_sales_order so 
        INNER JOIN tb_sales_order_det sod ON sod.id_sales_order = so.id_sales_order
        INNER JOIN tb_m_product p ON p.id_product = sod.id_product
        INNER JOIN tb_m_design d ON d.id_design = p.id_design " + cond_prod + "
        INNER JOIN tb_m_design_price dp ON dp.id_design_price = sod.id_design_price
        INNER JOIN tb_lookup_design_price_type dpt ON dpt.id_design_price_type = dp.id_design_price_type
        INNER JOIN tb_m_product_code pc ON pc.id_product = p.id_product
        INNER JOIN tb_m_code_detail cd ON cd.id_code_detail = pc.id_code_detail "
        If id_so_status <> "5" Then
            query += "LEFT JOIN (
	            SELECT deld.id_sales_order_det, SUM(deld.pl_sales_order_del_det_qty) AS `total_trs`
	            FROM tb_pl_sales_order_del del
	            INNER JOIN tb_pl_sales_order_del_det deld ON deld.id_pl_sales_order_del = del.id_pl_sales_order_del
                 " + cond_prod2 + "
	            WHERE del.id_sales_order=" + id_so + " AND del.id_report_status!=5
	            GROUP BY deld.id_sales_order_det
            ) scan ON scan.id_sales_order_det = sod.id_sales_order_det
            LEFT JOIN (
	            SELECT deld.id_sales_order_det, SUM(deld.pl_sales_order_del_det_qty) AS `total_trs`
	            FROM tb_pl_sales_order_del del
	            INNER JOIN tb_pl_sales_order_del_det deld ON deld.id_pl_sales_order_del = del.id_pl_sales_order_del
                " + cond_prod2 + "
	            WHERE del.id_sales_order=" + id_so + " AND del.id_report_status=6
	            GROUP BY deld.id_sales_order_det
            ) comp ON comp.id_sales_order_det = sod.id_sales_order_det "
        Else
            query += "LEFT JOIN (
	            SELECT deld.id_sales_order_det, SUM(deld.fg_trf_det_qty) AS `total_trs`
	            FROM tb_fg_trf del
	            INNER JOIN tb_fg_trf_det deld ON deld.id_fg_trf = del.id_fg_trf
	              " + cond_prod2 + "
                WHERE del.id_sales_order=" + id_so + " AND del.id_report_status!=5
	            GROUP BY deld.id_sales_order_det
            ) scan ON scan.id_sales_order_det = sod.id_sales_order_det
            LEFT JOIN (
	           SELECT deld.id_sales_order_det, SUM(deld.fg_trf_det_qty) AS `total_trs`
	            FROM tb_fg_trf del
	            INNER JOIN tb_fg_trf_det deld ON deld.id_fg_trf = del.id_fg_trf
	            " + cond_prod2 + "
                WHERE del.id_sales_order=" + id_so + " AND del.id_report_status=6
	            GROUP BY deld.id_sales_order_det
            ) comp ON comp.id_sales_order_det = sod.id_sales_order_det "
        End If

        query += "WHERE so.id_sales_order = " + id_so + "
        GROUP BY sod.id_sales_order_det "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCNew.DataSource = data
        GVNew.BestFitColumns()
        Cursor = Cursors.Default
    End Sub

    Private Sub FormSalesOrderReportDet_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
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
End Class