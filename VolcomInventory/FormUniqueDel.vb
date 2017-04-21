Public Class FormUniqueDel
    Public id_del As String = "-1"

    Private Sub FormUniqueDel_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Cursor = Cursors.WaitCursor
        Dim query As String = "SELECT w.comp_number AS `WH Account`, w.comp_name AS `WH`,c.comp_number AS `Store Account`, c.comp_name AS `Store`,
        del.pl_sales_order_del_number AS `Delivery`,
        CONCAT(p.product_full_code,detc.pl_sales_order_del_det_counting) AS `Unique Code`, 
        d.design_display_name AS `Description`, cd.code_detail_name AS `Size`
        FROM tb_pl_sales_order_del del 
        INNER JOIN tb_pl_sales_order_del_det det ON det.id_pl_sales_order_del = del.id_pl_sales_order_del
        INNER JOIN tb_pl_sales_order_del_det_counting detc ON detc.id_pl_sales_order_del_det = det.id_pl_sales_order_del_det
        INNER JOIN tb_m_product p ON p.id_product = det.id_product
        INNER JOIN tb_m_product_code pc ON pc.id_product = p.id_product
        INNER JOIN tb_m_code_detail cd ON cd.id_code_detail = pc.id_code_detail
        INNER JOIN tb_m_design d ON d.id_design = p.id_design
        INNER JOIN tb_m_comp_contact cc ON cc.id_comp_contact = del.id_store_contact_to
        INNER JOIN tb_m_comp c ON c.id_comp = cc.id_comp
        INNER JOIN tb_m_comp_contact wc ON wc.id_comp_contact = del.id_comp_contact_from
        INNER JOIN tb_m_comp w ON w.id_comp = wc.id_comp
        WHERE del.id_pl_sales_order_del = " + id_del + "
        ORDER BY del.id_pl_sales_order_del, p.id_product "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCData.DataSource = data
        print(GCData, GVData.GetFocusedRowCellValue("Delivery").ToString)
        Close()
        Cursor = Cursors.Default
    End Sub

    Private Sub FormUniqueDel_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub
End Class