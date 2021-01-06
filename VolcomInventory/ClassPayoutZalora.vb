Public Class ClassPayoutZalora
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

        ', z.id_acc_default_fee, z.default_comm, z.default_shipping
        Dim query As String = ""
        query += "SELECT z.id_payout_zalora, z.statement_number, z.zalora_created_at, z.opening_balance, 
        z.sales_revenue, z.other_revenue, z.total_fees, z.sales_refund, z.total_refund_fee, z.closing_balance, 
        z.closing_balance, z.guarantee_deposit, z.total_payout,z.sync_date, z.note, z.is_confirm, IF(z.is_confirm=1,'Confirmed', 'Not Confirmed') AS `is_confirm_view`, z.id_report_status, rs.report_status
        FROM tb_payout_zalora z 
        INNER JOIN tb_lookup_report_status rs ON rs.id_report_status = z.id_report_status
        WHERE z.id_payout_zalora>0 "
        query += condition + " "
        query += "ORDER BY z.zalora_created_at DESC "
        Return query
    End Function

    Public Function viewERPPayout(ByVal id As String) As DataTable
        Dim query As String = "SELECT a.`name`, a.id_group,a.`group`, a.id_ref, a.`rmt_ref`, rmt.report_mark_type_name AS `rmt_name_ref`, a.ref, a.amo,a.id_acc, coa.acc_name, coa.acc_description, a.recon_type, a.id_payout_zalora_det_adj, a.id_comp, a.comp_number, a.indeks
FROM ( 
	-- SALES REVENUE
	(SELECT  CONCAT(c.comp_name,' Per ', DATE_FORMAT(sp.sales_pos_start_period,'%d-%m-%y'),' s/d ', DATE_FORMAT(sp.sales_pos_end_period,'%d-%m-%y'))  AS `name`, 1 AS `id_group`,'Sales Revenue' AS `group`, sp.id_sales_pos AS `id_ref`, sp.report_mark_type AS `rmt_ref`,sp.sales_pos_number AS `ref`, SUM(d.erp_amount) AS `amo`, d.id_acc, 'Auto' AS `recon_type`, d.manual_recon_reason, 0 AS `id_payout_zalora_det_adj`, c.id_comp, c.comp_number, 1 AS `indeks`
	FROM tb_payout_zalora_det d 
	INNER JOIN tb_payout_zalora_type t ON t.transaction_type = d.transaction_type
	INNER JOIN tb_sales_pos_det spd ON spd.id_sales_pos_det = d.id_sales_pos_det
	INNER JOIN tb_sales_pos sp ON sp.id_sales_pos = spd.id_sales_pos
	INNER JOIN tb_m_comp_contact cc ON cc.`id_comp_contact`= IF(sp.id_memo_type=8 OR sp.id_memo_type=9, sp.id_comp_contact_bill,sp.`id_store_contact_from`)
	INNER JOIN tb_m_comp c ON c.`id_comp`=cc.`id_comp` 
	WHERE d.id_payout_zalora=" + id + " AND t.id_payout_zalora_cat=2 AND d.is_manual_recon=2
	GROUP BY d.id_acc, sp.id_sales_pos )
	UNION ALL
	(SELECT cd.manual_recon_reason AS `name`, 1 AS `id_group`, 'Sales Revenue' AS `group`, cd.`id_ref`, cd.`rmt_ref`,cd.`ref`, SUM(cd.erp_amount) AS `amo`, cd.id_acc, 'Manual' AS `recon_type`, cd.manual_recon_reason, 0 AS `id_payout_zalora_det_adj`, cf.id_comp, cf.comp_number, 1 AS `indeks`
	FROM (
		SELECT d.id_payout_zalora_det,d.erp_amount, d.id_acc, d.manual_recon_reason, IFNULL(sp.id_sales_pos,0) AS `id_ref`, IFNULL(sp.report_mark_type,0) AS `rmt_ref`, IFNULL(sp.sales_pos_number,'') AS `ref`
		FROM tb_payout_zalora_det d 
		INNER JOIN tb_payout_zalora_type t ON t.transaction_type = d.transaction_type
        LEFT JOIN tb_sales_pos_det spd ON spd.id_sales_pos_det = d.id_sales_pos_det
        LEFT JOIN tb_sales_pos sp ON sp.id_sales_pos = spd.id_sales_pos
		WHERE d.id_payout_zalora=" + id + " AND (t.id_payout_zalora_cat=2) AND d.is_manual_recon=1
		UNION ALL 
		SELECT a.id_payout_zalora_det,a.erp_amount, a.id_acc, d.manual_recon_reason, 0 AS `id_ref`, 0 AS `rmt_ref`, '' AS `ref`
		FROM tb_payout_zalora_det_addition a 
		INNER JOIN tb_payout_zalora_det d ON d.id_payout_zalora_det = a.id_payout_zalora_det 
		INNER JOIN tb_payout_zalora_type t ON t.transaction_type = d.transaction_type
		WHERE d.id_payout_zalora=" + id + " AND (t.id_payout_zalora_cat=2) AND d.is_manual_recon=1
	) cd
    INNER JOIN tb_m_comp cf ON cf.id_comp=1
	GROUP BY cd.id_acc, cd.manual_recon_reason)
	UNION ALL
	-- komisi
	(SELECT 'Komisi penjualan Zalora' AS `name`, 2 AS `id_group`, 'Commision' AS `group`, 0 AS `id_ref`, 0 AS `rmt_ref`, '' AS `ref`, m.comm AS `amo`, d.id_acc, d.recon_type AS `recon_type`, '' AS manual_recon_reason, 0 AS `id_payout_zalora_det_adj`, cf.id_comp,cf.comp_number, 3 AS `indeks`
	FROM tb_payout_zalora m
	LEFT JOIN (
		SELECT  d.id_payout_zalora, GROUP_CONCAT(DISTINCT IF(d.is_manual_recon=2,'Auto', 'Manual')) AS `recon_type`, GROUP_CONCAT(DISTINCT d.id_acc) AS `id_acc`
		FROM tb_payout_zalora_det d
		INNER JOIN tb_payout_zalora m ON m.id_payout_zalora = d.id_payout_zalora
		INNER JOIN tb_payout_zalora_type t ON t.transaction_type = d.transaction_type
		WHERE d.id_payout_zalora=" + id + " AND (t.id_payout_zalora_cat=3 OR t.id_payout_zalora_cat=5)
		GROUP BY d.id_payout_zalora
	) d ON d.id_payout_zalora = m.id_payout_zalora
    INNER JOIN tb_m_comp cf ON cf.id_comp=1
	WHERE m.id_payout_zalora=" + id + ")
	UNION ALL
	(SELECT 'PPN atas komisi penjualan Zalora' AS `name`, 3 AS `id_group`, 'Commision Tax' AS `group`, 0 AS `id_ref`, 0 AS `rmt_ref`, '' AS `ref`, m.comm_tax AS `amo`, os.id_acc_default_comm_tax_zalora, 'Manual' AS `recon_type`, '' AS manual_recon_reason, 0 AS `id_payout_zalora_det_adj`, cf.id_comp, cf.comp_number, 3 AS `indeks`
	FROM tb_payout_zalora m
	JOIN tb_opt_sales os 
    INNER JOIN tb_m_comp cf ON cf.id_comp=1
	WHERE m.id_payout_zalora=" + id + ")
	UNION ALL
	-- REFUND
	(SELECT  CONCAT(c.comp_name,' Per ', DATE_FORMAT(sp.sales_pos_start_period,'%d-%m-%y'),' s/d ', DATE_FORMAT(sp.sales_pos_end_period,'%d-%m-%y'))  AS `name`, 4 AS `id_group`, 'Refund' AS `group`, sp.id_sales_pos AS `id_ref`, sp.report_mark_type AS `rmt_ref`, sp.sales_pos_number AS `ref`, SUM(d.erp_amount) AS `amo`, d.id_acc, 'Auto' AS `recon_type`, d.manual_recon_reason, 0 AS `id_payout_zalora_det_adj`, c.id_comp, c.comp_number, 2 AS `indeks`
	FROM tb_payout_zalora_det d 
	INNER JOIN tb_payout_zalora_type t ON t.transaction_type = d.transaction_type
	INNER JOIN tb_sales_pos_det spd ON spd.id_sales_pos_det = d.id_sales_pos_cn_det
	INNER JOIN tb_sales_pos sp ON sp.id_sales_pos = spd.id_sales_pos
	INNER JOIN tb_m_comp_contact cc ON cc.`id_comp_contact`= IF(sp.id_memo_type=8 OR sp.id_memo_type=9, sp.id_comp_contact_bill,sp.`id_store_contact_from`)
	INNER JOIN tb_m_comp c ON c.`id_comp`=cc.`id_comp` 
	WHERE d.id_payout_zalora=" + id + " AND t.id_payout_zalora_cat=4 AND d.is_manual_recon=2
	GROUP BY d.id_acc, sp.id_sales_pos )
	UNION ALL
	(SELECT cd.manual_recon_reason AS `name`, 4 AS `id_group`, 'Refund' AS `group`, cd.`id_ref`, cd.`rmt_ref`, cd.`ref`, SUM(cd.erp_amount) AS `amo`, cd.id_acc, 'Manual' AS `recon_type`, cd.manual_recon_reason, 0 AS `id_payout_zalora_det_adj`, cf.id_comp,cf.comp_number, 2 AS `indeks`
	FROM (
		SELECT d.id_payout_zalora_det,d.erp_amount, d.id_acc, d.manual_recon_reason, IFNULL(sp.id_sales_pos,0) AS `id_ref`, IFNULL(sp.report_mark_type,0) AS `rmt_ref`, IFNULL(sp.sales_pos_number,'') AS `ref`
		FROM tb_payout_zalora_det d 
		INNER JOIN tb_payout_zalora_type t ON t.transaction_type = d.transaction_type
        LEFT JOIN tb_sales_pos_det spd ON spd.id_sales_pos_det = d.id_sales_pos_cn_det
        LEFT JOIN tb_sales_pos sp ON sp.id_sales_pos = spd.id_sales_pos
		WHERE d.id_payout_zalora=" + id + " AND (t.id_payout_zalora_cat=4) AND d.is_manual_recon=1
		UNION ALL 
		SELECT a.id_payout_zalora_det,a.erp_amount, a.id_acc, d.manual_recon_reason, 0 AS `id_ref`, 0 AS `rmt_ref`, '' AS `ref`
		FROM tb_payout_zalora_det_addition a 
		INNER JOIN tb_payout_zalora_det d ON d.id_payout_zalora_det = a.id_payout_zalora_det 
		INNER JOIN tb_payout_zalora_type t ON t.transaction_type = d.transaction_type
		WHERE d.id_payout_zalora=" + id + " AND (t.id_payout_zalora_cat=4) AND d.is_manual_recon=1
	) cd
    INNER JOIN tb_m_comp cf ON cf.id_comp=1
	GROUP BY cd.id_acc, cd.manual_recon_reason)
	UNION ALL
	(SELECT a.note AS `name`, 5 AS `id_group`, 'Adjustment' AS `group`, IFNULL(a.id_report,0) AS `id_ref`, IFNULL(a.report_mark_type,0) AS `rmt_ref`, IFNULL(a.report_number,'')  AS `ref`, a.adj_value AS `amo`, a.id_acc, 'Manual' AS `recon_type`, '' AS `manual_recon_reason`, a.id_payout_zalora_det_adj, cf.id_comp, cf.comp_number, 4 AS `indeks`
	FROM tb_payout_zalora_det_adj a
    INNER JOIN tb_m_comp cf ON cf.id_comp=1
	WHERE a.id_payout_zalora=" + id + " AND a.adj_value>0)
)a
INNER JOIN tb_a_acc coa ON coa.id_acc = a.id_acc
LEFT JOIN tb_lookup_report_mark_type rmt ON rmt.report_mark_type = a.rmt_ref
ORDER BY a.indeks ASC "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        Return data
    End Function

End Class