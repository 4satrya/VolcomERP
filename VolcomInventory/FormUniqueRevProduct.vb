﻿Public Class FormUniqueRevProduct
    Public id_pl_prod_order_rec As String = "-1"

    Private Sub FormUniqueRevProduct_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Cursor = Cursors.WaitCursor
        Dim query As String = "
            SELECT CONCAT(vend_c.comp_number, ' - ', vend_c.comp_name) AS `Vendor`, CONCAT(cmf.comp_number, ' - ', cmf.comp_name) AS `From`, CONCAT(cmt.comp_number, ' - ', cmt.comp_name) AS `To`, pr.pl_prod_order_rec_number AS `Receive Product`, CONCAT(c.product_full_code, a.pl_prod_order_rec_det_counting) AS `Unique Code`, c.product_name AS `Description`, cd.code_detail_name AS `Size`
            FROM tb_pl_prod_order_rec_det_counting a 
            INNER JOIN tb_pl_prod_order_rec_det b ON a.id_pl_prod_order_rec_det = b.id_pl_prod_order_rec_det 
            INNER JOIN tb_pl_prod_order_rec pr ON pr.id_pl_prod_order_rec = b.id_pl_prod_order_rec 
            INNER JOIN tb_pl_prod_order p ON p.id_pl_prod_order = pr.id_pl_prod_order
            INNER JOIN tb_prod_order po ON po.id_prod_order = p.id_prod_order
            LEFT JOIN tb_prod_order_wo vend_wo ON vend_wo.id_prod_order = po.id_prod_order AND vend_wo.is_main_vendor='1'
            LEFT JOIN tb_m_ovh_price vend_ovh ON vend_ovh.id_ovh_price = vend_wo.id_ovh_price
            LEFT JOIN tb_m_comp_contact vend_cc On vend_cc.id_comp_contact = vend_ovh.id_comp_contact 
            LEFT JOIN tb_m_comp vend_c ON vend_c.id_comp = vend_cc.id_comp 
            INNER JOIN tb_m_comp_contact cf ON cf.id_comp_contact = pr.id_comp_contact_from
            INNER JOIN tb_m_comp cmf ON cmf.id_comp = cf.id_comp
            INNER JOIN tb_m_comp_contact ct ON ct.id_comp_contact = pr.id_comp_contact_to
            INNER JOIN tb_m_comp cmt ON cmt.id_comp = ct.id_comp
            INNER JOIN tb_m_product c ON a.id_product = c.id_product 
            INNER JOIN tb_m_product_code pc ON pc.id_product = c.id_product 
            INNER JOIN tb_m_code_detail cd ON cd.id_code_detail = pc.id_code_detail 
            WHERE b.id_pl_prod_order_rec = '" + id_pl_prod_order_rec + "' AND a.id_counting_type = '1'
            ORDER BY c.product_full_code ASC, a.pl_prod_order_rec_det_counting ASC
        "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCData.DataSource = data
        GVData.Columns.ColumnByFieldName("Vendor").MaxWidth = 175
        GVData.Columns.ColumnByFieldName("From").MaxWidth = 175
        GVData.Columns.ColumnByFieldName("To").MaxWidth = 175
        GVData.Columns.ColumnByFieldName("Size").MaxWidth = 50
        print(GCData, GVData.GetFocusedRowCellValue("Receive Product").ToString)
        Close()
        Cursor = Cursors.Default
    End Sub

    Private Sub FormUniqueRevProduct_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub
End Class