Public Class ClassSalesBranch
    Public Function queryMain(ByVal condition As String, ByVal order_type As String) As String
        If order_type = "1" Then
            order_type = "ASC "
        ElseIf order_type = "2" Then
            order_type = "DESC "
        End If

        If condition <> "-1" Then
            condition = condition
        Else
            condition = ""
        End If

        Dim query As String = "SELECT b.id_sales_branch, b.number, b.id_coa_tag, ct.tag_description AS `unit`, b.created_date, b.transaction_date, 
        b.id_report_status, stt.report_status, b.note, b.`value`,
        store_normal.id_comp AS `id_store_normal`,b.pros_normal, b.pros_normal_comp,b.rev_normal,
        b.rev_normal_ppn_pros, b.rev_normal_ppn, b.rev_normal_ppn_acc AS `id_coa_ppn_normal`, coa_ppn_normal.acc_name AS `coa_ppn_normal`, coa_ppn_normal.acc_description AS `coa_ppn_normal_desc`,
        b.rev_normal_after_ppn,  b.rev_normal_after_ppn_acc AS `id_coa_pend_normal`, coa_pend_normal.acc_name AS `coa_pend_normal`, coa_pend_normal.acc_description AS `coa_pend_normal_desc`,
        b.comp_rev_normal, b.comp_rev_normal_acc AS `id_coa_hd_normal`,coa_hd_normal.acc_name AS `coa_hd_normal`, coa_hd_normal.acc_description AS `coa_hd_normal_desc`,
        store_sale.id_comp AS `id_store_sale`,b.pros_sale, b.pros_sale_comp, b.rev_sale, 
        b.rev_sale_ppn_pros, b.rev_sale_ppn, b.rev_sale_ppn_acc AS `id_coa_ppn_sale`, coa_ppn_sale.acc_name AS `coa_ppn_sale`, coa_ppn_sale.acc_description AS `coa_ppn_sale_desc`,
        b.rev_sale_after_ppn,  b.rev_sale_after_ppn_acc AS `id_coa_pend_sale`, coa_pend_sale.acc_name AS `coa_pend_sale`, coa_pend_sale.acc_description AS `coa_pend_sale_desc`,
        b.comp_rev_sale, b.comp_rev_sale_acc AS `id_coa_hd_sale`,coa_hd_sale.acc_name AS `coa_hd_sale`, coa_hd_sale.acc_description AS `coa_hd_sale_desc`
        FROM tb_sales_branch b
        INNER JOIN tb_coa_tag ct ON ct.id_coa_tag = b.id_coa_tag
        INNER JOIN tb_lookup_report_status stt ON stt.id_report_status = b.id_report_status
        INNER JOIN tb_a_acc coa_ppn_normal ON coa_ppn_normal.id_acc = b.rev_normal_ppn_acc
        INNER JOIN tb_a_acc coa_pend_normal ON coa_pend_normal.id_acc = b.rev_normal_before_ppn_acc
        INNER JOIN tb_a_acc coa_hd_normal ON coa_hd_normal.id_acc = b.comp_rev_normal_acc
        INNER JOIN tb_m_comp store_normal ON store_normal.id_comp = b.pros_normal_comp
        INNER JOIN tb_a_acc coa_ppn_sale ON coa_ppn_sale.id_acc = b.rev_sale_ppn_acc
        INNER JOIN tb_a_acc coa_pend_sale ON coa_pend_sale.id_acc = b.rev_sale_before_ppn_acc
        INNER JOIN tb_a_acc coa_hd_sale ON coa_hd_sale.id_acc = b.comp_rev_sale_acc
        INNER JOIN tb_m_comp store_sale ON store_sale.id_comp = b.pros_sale_comp
        WHERE b.id_sales_branch>0 "
        query += condition + " "
        query += "ORDER BY b.id_sales_branch " + order_type
        Return query
    End Function
End Class
