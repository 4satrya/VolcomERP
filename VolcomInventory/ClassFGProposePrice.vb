Public Class ClassFGProposePrice
    Public Function queryMain(ByVal condition As String, ByVal order_type As String) As String
        Dim query As String = "CALL view_fg_propose_price_main('" + condition + "', '" + order_type + "') "
        Return query
    End Function

    Public Function dataMainRev(ByVal condition As String, ByVal order_type As String) As DataTable
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

        Dim query As String = "SELECT ppr.id_fg_propose_price_rev, ppr.id_fg_propose_price, pp.fg_propose_price_number, pp.id_pp_type,ppr.rev_count,
        pp.id_season, ss.season, pp.id_source, src.code_detail_name AS `source`, pp.id_division, (dv.code_detail_name) AS division,
        ppr.id_report_status, stt.report_status, ppr.created_date, ppr.note, ppr.is_confirm, ppr.markup_target
        FROM tb_fg_propose_price_rev ppr
        INNER JOIN tb_lookup_report_status stt ON stt.id_report_status = ppr.id_report_status
        INNER JOIN tb_fg_propose_price pp ON pp.id_fg_propose_price = ppr.id_fg_propose_price
        INNER JOIN tb_season ss ON ss.id_season = pp.id_season
        INNER JOIN tb_m_code_detail src ON src.id_code_detail = pp.id_source
        INNER JOIN tb_m_code_detail dv ON dv.id_code_detail = pp.id_division
        WHERE ppr.id_fg_propose_price_rev>0 "
        query += condition + " "
        query += "ORDER BY ppr.id_fg_propose_price_rev " + order_type
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        Return data
    End Function

    Public Function queryDetail(ByVal id_report_param As String) As String
        Dim query As String = "CALL view_fg_propose_price('" + id_report_param + "')"
        Return query
    End Function

    Public Function dataDetail(ByVal condition As String) As DataTable
        'If order_type = "1" Then
        '    order_type = "ASC "
        'ElseIf order_type = "2" Then
        '    order_type = "DESC "
        'End If

        If condition <> "-1" Then
            condition = condition
        Else
            condition = ""
        End If

        Dim query As String = "SELECT 'No' AS `is_select`, '' AS `no`,ppd.id_fg_propose_price_detail, ppd.id_fg_propose_price, 
        ppd.id_design, d.design_code, d.design_code_import, del.id_delivery, del.delivery, d.id_season_orign, ss_org.season_orign_display AS `season_orign`, ctr.id_country, ctr.country_display_name AS `country`,
        src.id_src, src.src AS `source`,cls.id_class, cls.class, d.design_display_name, col.id_color, col.color, sc.size_chart, 
        DATE_FORMAT(d.design_eos,'%b %y') AS `eos_date`, rc.ret_code, DATE_FORMAT(rc.ret_date, '%b %y') AS `ret_date`, CONCAT(PERIOD_DIFF(DATE_FORMAT(rc.ret_date, '%Y%m'),DATE_FORMAT(del.delivery_date, '%Y%m')), ' MTH') AS `age`,
        ppd.id_prod_demand_design, po.id_prod_order,po.prod_order_number, po.vendor, po.qty AS `qty_po`, ppd.`qty`,
        ppd.id_cop_status, cs.cop_status, ppd.msrp, ppd.additional_cost, 
        IF(ppd.cop_rate_cat=1,'BOM', 'Payment') AS `rate_type`,ppd.cop_rate_cat, ppd.cop_kurs, ppd.cop_value, (ppd.cop_value - ppd.additional_cost) AS `cop_value_min_add`,
        ppd.cop_mng_kurs, ppd.cop_mng_value, (ppd.cop_mng_value - ppd.additional_cost) AS `cop_mng_value_min_add`,
        ppd.price, ppd.sale_price, ppd.additional_price, ppd.cop_date,
        ppd.id_design_price_type_master, ptm.design_price_type AS `design_price_type_master`, ppd.id_design_price_type_print, ptp.design_price_type AS `design_price_type_print`,
        ppd.remark, ppd.is_active, sa.status
        FROM tb_fg_propose_price_detail ppd
        INNER JOIN tb_m_design d ON d.id_design = ppd.id_design
        INNER JOIN tb_season_delivery del ON del.id_delivery = d.id_delivery
        INNER JOIN tb_season_orign ss_org ON ss_org.id_season_orign = d.id_season_orign
        INNER JOIN tb_m_country ctr ON ctr.id_country = ss_org.id_country
        LEFT JOIN (
          SELECT d.id_design, cls.id_code_detail AS `id_src`, cls.display_name AS `src` 
          FROM tb_m_design d
          INNER JOIN tb_m_design_code dc ON dc.id_design = d.id_design
          INNER JOIN tb_m_code_detail cls ON cls.id_code_detail = dc.id_code_detail AND cls.id_code=5
          GROUP BY d.id_design
        ) src ON src.id_design = d.id_design
        LEFT JOIN (
          SELECT d.id_design, cls.id_code_detail AS `id_class`, cls.display_name AS `class` 
          FROM tb_m_design d
          INNER JOIN tb_m_design_code dc ON dc.id_design = d.id_design
          INNER JOIN tb_m_code_detail cls ON cls.id_code_detail = dc.id_code_detail AND cls.id_code=30
          GROUP BY d.id_design
        ) cls ON cls.id_design = d.id_design
        LEFT JOIN (
          SELECT d.id_design, cls.id_code_detail AS `id_color`, cls.display_name AS `color` 
          FROM tb_m_design d
          INNER JOIN tb_m_design_code dc ON dc.id_design = d.id_design
          INNER JOIN tb_m_code_detail cls ON cls.id_code_detail = dc.id_code_detail AND cls.id_code=14
          GROUP BY d.id_design
        ) col ON col.id_design = d.id_design
        LEFT JOIN (
	        SELECT pdp.id_prod_demand_design, GROUP_CONCAT(DISTINCT cd.code_detail_name ORDER BY cd.id_code_detail ASC SEPARATOR ',') AS `size_chart`
	        FROM tb_prod_demand_product pdp
	        INNER JOIN tb_m_product prod ON prod.id_product = pdp.id_product
	        INNER JOIN tb_m_product_code prod_code ON prod_code.id_product = prod.id_product
	        INNER JOIN tb_m_code_detail cd ON cd.id_code_detail = prod_code.id_code_detail
	        GROUP BY pdp.id_prod_demand_design
        ) sc ON sc.id_prod_demand_design = ppd.id_prod_demand_design
        INNER JOIN (
	        SELECT po.id_prod_demand_design,po.id_prod_order,po.prod_order_number, c.comp_name AS `vendor`, SUM(pod.prod_order_qty) AS `qty`
	        FROM tb_prod_order po
	        INNER JOIN tb_prod_order_det pod ON pod.id_prod_order = po.id_prod_order
	        INNER JOIN tb_prod_order_wo wo ON wo.id_prod_order = po.id_prod_order AND wo.is_main_vendor=1
	        INNER JOIN tb_m_ovh_price ovhp ON ovhp.id_ovh_price = wo.id_ovh_price
	        INNER JOIN tb_m_comp_contact cc ON cc.id_comp_contact = ovhp.id_comp_contact
	        INNER JOIN tb_m_comp c ON c.id_comp = cc.id_comp
	        WHERE po.id_report_status!=5
	        GROUP BY po.id_prod_demand_design
        ) po ON po.id_prod_demand_design = ppd.id_prod_demand_design
        INNER JOIN tb_lookup_ret_code rc ON rc.id_ret_code = d.id_ret_code
        INNER JOIN tb_lookup_cop_status cs ON cs.id_cop_status = ppd.id_cop_status
        INNER JOIN tb_lookup_status sa ON sa.id_status = ppd.is_active 
        INNER JOIN tb_lookup_design_price_type ptm ON ptm.id_design_price_type = ppd.id_design_price_type_master
        INNER JOIN tb_lookup_design_price_type ptp ON ptp.id_design_price_type = ppd.id_design_price_type_print
        WHERE ppd.id_fg_propose_price_detail>0 "
        query += condition + " "
        query += "ORDER BY d.design_display_name ASC "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        Return data
    End Function

    Public Function dataCOPList(ByVal id_ss As String, ByVal source As String, ByVal div As String, ByVal is_for_add_list As Boolean)
        Dim query As String = "SELECT d.id_design, pdd.id_prod_demand_design,d.design_code AS `code`, cls.id_class,cls.`class`, d.design_display_name AS `name`, 
        IF(d.id_cop_status=1,IF(d.pp_is_approve=1,d.id_cop_status,0),IF(d.final_is_approve=1,d.id_cop_status,0)) AS `id_cop_status`,
        IF(d.id_cop_status=1,IF(d.pp_is_approve=1,'Pre Final','-'),IF(d.final_is_approve=1,'Final','-')) AS `cop_status`,
        IF(d.id_cop_status=1,IF(d.pp_is_approve=1,d.prod_order_cop_mng_addcost,0),IF(d.final_is_approve=1,d.design_cop_addcost,0)) AS `additional_cost`,
        IF(d.id_cop_status=1,IF(d.pp_is_approve=1,d.pp_cop_rate_cat,0),IF(d.final_is_approve=1,d.final_cop_rate_cat,0)) AS `cop_rate_cat`,
        IF(d.id_cop_status=1,IF(d.pp_is_approve=1,IF(d.pp_cop_rate_cat=1,'BOM','Payment'),'-'),IF(d.final_is_approve=1,IF(d.final_cop_rate_cat=1,'BOM','Payment'),'-')) AS `cop_rate_cat_display`,
        IF(d.id_cop_status=1,IF(d.pp_is_approve=1,d.pp_cop_kurs,0),IF(d.final_is_approve=1,d.final_cop_kurs,0)) AS `cop_kurs`,
        IF(d.id_cop_status=1,IF(d.pp_is_approve=1,d.pp_cop_value,0),IF(d.final_is_approve=1,d.final_cop_value,0)) AS `cop_value`,
        IF(d.id_cop_status=1,IF(d.pp_is_approve=1,d.pp_cop_mng_kurs,0),IF(d.final_is_approve=1,d.final_cop_mng_kurs,0)) AS `cop_mng_kurs`,
        IF(d.id_cop_status=1,IF(d.pp_is_approve=1,d.pp_cop_mng_value,0),IF(d.final_is_approve=1,d.final_cop_mng_value,0)) AS `cop_mng_value`,
        po.id_prod_order,pod.po_qty, 0 AS `rec_qty`,
        pod.po_qty  AS `qty`,
        'No' AS `is_select`
        FROM tb_m_design d 
        INNER JOIN (
          SELECT d.id_design, cls.id_code_detail AS `id_class`, cls.display_name AS `class` 
          FROM tb_m_design d
          INNER JOIN tb_m_design_code dc ON dc.id_design = d.id_design
          INNER JOIN tb_m_code_detail cls ON cls.id_code_detail = dc.id_code_detail AND cls.id_code=30
          GROUP BY d.id_design
        ) cls ON cls.id_design = d.id_design
        INNER JOIN (
          SELECT d.id_design, cls.id_code_detail AS `id_src`, cls.display_name AS `src` 
          FROM tb_m_design d
          INNER JOIN tb_m_design_code dc ON dc.id_design = d.id_design
          INNER JOIN tb_m_code_detail cls ON cls.id_code_detail = dc.id_code_detail AND cls.id_code=5
          GROUP BY d.id_design
        ) src ON src.id_design = d.id_design
        INNER JOIN tb_prod_demand_design pdd ON pdd.id_design = d.id_design AND pdd.is_void=2
        INNER JOIN tb_prod_demand pd ON pd.id_prod_demand = pdd.id_prod_demand AND pd.is_pd=1 AND pd.id_division=" + div + " AND pd.id_report_status=6
        INNER JOIN tb_prod_order po ON  po.id_prod_demand_design = pdd.id_prod_demand_design AND po.id_report_status!=5
        INNER JOIN (
	        SELECT pod.id_prod_order, SUM(pod.prod_order_qty) AS `po_qty` 
	        FROM tb_prod_order_det pod
	        INNER JOIN tb_prod_order po ON po.id_prod_order = pod.id_prod_order
	        INNER JOIN tb_prod_demand_design pdd ON pdd.id_prod_demand_design = po.id_prod_demand_design
	        INNER JOIN tb_m_design d ON d.id_design = pdd.id_design
	        WHERE po.id_report_status!=5 AND d.id_season=" + id_ss + "
	        GROUP BY pod.id_prod_order
        ) pod ON pod.id_prod_order = po.id_prod_order
        LEFT JOIN (
	        SELECT pp.id_fg_propose_price,ppd.id_design 
	        FROM tb_fg_propose_price pp
	        INNER JOIN tb_fg_propose_price_detail ppd ON ppd.id_fg_propose_price = pp.id_fg_propose_price
	        WHERE pp.id_report_status!=5
        ) pp ON pp.id_design = d.id_design
        WHERE d.id_season=" + id_ss + " AND (d.id_lookup_status_order=1 OR d.id_lookup_status_order=3) AND src.id_src=" + source + " "
        If is_for_add_list Then
            query += " AND ISNULL(pp.id_fg_propose_price) HAVING id_cop_status>0 "
        End If
        query += "ORDER BY d.design_display_name ASC "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        Return data
    End Function
End Class
