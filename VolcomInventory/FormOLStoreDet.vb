Public Class FormOLStoreDet
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
        Dim query As String = "SELECT so.id_sales_order, sod.id_sales_order_det,  so.sales_order_number,so.sales_order_ol_shop_number, so.sales_order_date, so.sales_order_ol_shop_date,
        '' AS `code`, '' AS `name`, '' AS `item_id`, '' AS `ol_store_id`, sod.sales_order_det_qty, sod.id_design_price, sod.design_price, 
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
End Class