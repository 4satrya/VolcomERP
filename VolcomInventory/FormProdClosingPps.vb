﻿Public Class FormProdClosingPps
    Public id_pps As String = "-1"

    Private Sub FormProdClosingPps_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        view_claim_reject()
        view_claim_late()

        load_header()
        load_det()
        load_claim_reject()
        load_claim_late()
    End Sub

    Sub load_header()
        Dim query As String = "SELECT * FROM tb_prod_order_close WHERE id_prod_order_close='" & id_pps & "'"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        If data.Rows.Count > 0 Then

        End If
    End Sub

    Sub view_claim_reject()
        Dim query As String = "SELECT id_claim_reject,description FROM `tb_m_claim_reject` cr
WHERE cr.`is_active`='1'"
        viewSearchLookupRepositoryQuery(RISLERejectClaim, query, 0, "description", "id_claim_reject")
    End Sub

    Sub view_claim_late()
        Dim query As String = "SELECT id_claim_late,description FROM `tb_m_claim_late` cl
WHERE cl.`is_active`='1'"
        viewSearchLookupRepositoryQuery(RISLEClaimLate, query, 0, "description", "id_claim_late")
    End Sub

    Sub load_claim_late()
        Dim query As String = "SELECT s.`season`,rd.`prod_order_rec_det_qty`,r.`id_prod_order`,po.prod_order_number,rec.rec_qty,pod.po_qty
,dsg.design_display_name,dsg.design_code,SUBSTRING(dsg.`design_display_name`,1,CHAR_LENGTH(dsg.`design_display_name`) - 4) AS dsg_name,RIGHT(dsg.`design_display_name`,3) AS color 
,DATE_ADD(wo.prod_order_wo_del_date, INTERVAL IFNULL(ko.lead_time_prod,wo.`prod_order_wo_lead_time`) DAY) AS est_rec_date_ko
,DATE_ADD(wo.prod_order_wo_del_date, INTERVAL wo.`prod_order_wo_lead_time` DAY) AS est_rec_date
,r.`arrive_date`
,ld.`claim_percent`
,wod.prod_order_wo_det_price
,(ld.`claim_percent`/100) * wod.prod_order_wo_det_price AS claim_pc
,SUM(rd.prod_order_rec_det_qty) AS rec_qty_trx
,SUM(rd.prod_order_rec_det_qty) * ((ld.`claim_percent`/100) * wod.prod_order_wo_det_price) AS claim_amo
,r.prod_order_rec_number
,DATEDIFF(r.`arrive_date`,DATE_ADD(wo.prod_order_wo_del_date, INTERVAL IFNULL(ko.lead_time_prod,wo.`prod_order_wo_lead_time`) DAY)) AS late_day
,c.comp_name
FROM tb_prod_order_rec_det rd
INNER JOIN tb_prod_order_rec r ON r.`id_prod_order_rec`=rd.`id_prod_order_rec` AND r.`id_report_status`='6'
INNER JOIN `tb_prod_order_close_det` cd ON cd.`id_prod_order`=r.`id_prod_order`
INNER JOIN tb_prod_order po ON po.`id_prod_order`=cd.`id_prod_order`
LEFT JOIN tb_prod_order_wo wo ON wo.id_prod_order=po.id_prod_order AND wo.is_main_vendor='1' 
LEFT JOIN tb_prod_order_wo_det wod ON wod.id_prod_order_wo=wo.id_prod_order_wo
LEFT JOIN tb_m_ovh_price prc ON prc.id_ovh_price=wo.id_ovh_price
LEFT JOIN tb_m_comp_contact cc ON cc.id_comp_contact=prc.id_comp_contact
LEFT JOIN tb_m_comp c ON c.id_comp=cc.id_comp
INNER JOIN tb_prod_demand_design pdd ON pdd.`id_prod_demand_design`=po.`id_prod_demand_design`
INNER JOIN `tb_season_delivery` sd ON sd.`id_delivery`=pdd.`id_delivery`
INNER JOIN `tb_season` s ON s.`id_season`=sd.`id_season`
INNER JOIN tb_m_design dsg ON dsg.`id_design`=pdd.`id_design`
LEFT JOIN  
( 
    SELECT rec.id_prod_order,SUM(recd.prod_order_rec_det_qty) AS rec_qty
    FROM 
    tb_prod_order_rec_det recd 
    INNER JOIN tb_prod_order_rec rec ON recd.id_prod_order_rec=rec.id_prod_order_rec AND rec.id_report_status=6
    INNER JOIN tb_prod_order_close_det pocd ON pocd.`id_prod_order`=rec.`id_prod_order` AND pocd.`id_prod_order_close`='" & id_pps & "'
    GROUP BY rec.id_prod_order
) rec ON rec.id_prod_order=po.id_prod_order 
LEFT JOIN
(
    SELECT pod.id_prod_order,SUM(pod.prod_order_qty) AS po_qty 
    FROM tb_prod_order_det pod
    INNER JOIN tb_prod_order_close_det pocd ON pocd.`id_prod_order`=pod.`id_prod_order` AND pocd.`id_prod_order_close`='" & id_pps & "'
    GROUP BY pod.`id_prod_order`
) pod ON pod.id_prod_order=cd.`id_prod_order`
LEFT JOIN (
    SELECT id_prod_order,lead_time_prod,lead_time_payment FROM (
	    SELECT kod.* FROM tb_prod_order_ko_det kod
	    INNER JOIN tb_prod_order_close_det pocd ON pocd.`id_prod_order`=kod.`id_prod_order` AND pocd.`id_prod_order_close`='" & id_pps & "'
	    INNER JOIN tb_prod_order_ko ko ON ko.`id_prod_order_ko`=kod.`id_prod_order_ko` AND ko.`is_void`!=1
	    ORDER BY id_prod_order_ko_det DESC
    )ko GROUP BY ko.id_prod_order
) ko ON ko.id_prod_order=po.id_prod_order
INNER JOIN tb_m_claim_late_det ld ON DATEDIFF(r.`arrive_date`,DATE_ADD(wo.prod_order_wo_del_date, INTERVAL IFNULL(ko.lead_time_prod,wo.`prod_order_wo_lead_time`) DAY))>=ld.`min_late` AND IF(ld.max_late=0,TRUE,DATEDIFF(r.`arrive_date`,DATE_ADD(wo.prod_order_wo_del_date, INTERVAL IFNULL(ko.lead_time_prod,wo.`prod_order_wo_lead_time`) DAY))<=ld.max_late)
WHERE cd.`id_prod_order_close`='" & id_pps & "'
GROUP BY rd.`id_prod_order_rec`"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCClaimLate.DataSource = data
        GVClaimLate.BestFitColumns()
    End Sub

    Sub load_claim_reject()
        Dim query As String = "SELECT dsg.`design_code`,dsg.`design_name`,po.`prod_order_number`,plc.`pl_category_sub`,fcd.*,
                                SUM(IF(fc.id_pl_category_sub=1,fcd.prod_fc_det_qty,0)) AS qc_normal,
                                get_claim_reject_percent(pocd.`id_claim_reject`,1) AS p_normal,
                                SUM(IF(fc.id_pl_category_sub=2,fcd.prod_fc_det_qty,0)) AS qc_normal_minor,
                                get_claim_reject_percent(pocd.`id_claim_reject`,2) AS p_normal_minor,
                                SUM(IF(fc.id_pl_category_sub=3,fcd.prod_fc_det_qty,0)) AS qc_minor,
                                get_claim_reject_percent(pocd.`id_claim_reject`,3) AS p_minor,
                                SUM(IF(fc.id_pl_category_sub=4,fcd.prod_fc_det_qty,0)) AS qc_minor_major,
                                get_claim_reject_percent(pocd.`id_claim_reject`,4) AS p_minor_major,
                                SUM(IF(fc.id_pl_category_sub=5,fcd.prod_fc_det_qty,0)) AS qc_major,
                                get_claim_reject_percent(pocd.`id_claim_reject`,5) AS p_major,
                                SUM(IF(fc.id_pl_category_sub=6,fcd.prod_fc_det_qty,0)) AS qc_afkir, 
                                get_claim_reject_percent(pocd.`id_claim_reject`,6) AS p_afkir,
                                ROUND(wo_price.prod_order_wo_det_price * (SUM(IF(fc.id_pl_category_sub=2,fcd.prod_fc_det_qty,0))*(get_claim_reject_percent(pocd.`id_claim_reject`,2)/100))+(SUM(IF(fc.id_pl_category_sub=3,fcd.prod_fc_det_qty,0))*(get_claim_reject_percent(pocd.`id_claim_reject`,3)/100))) AS amo_claim_minor,
                                ROUND(wo_price.prod_order_wo_det_price * (SUM(IF(fc.id_pl_category_sub=4,fcd.prod_fc_det_qty,0))*(get_claim_reject_percent(pocd.`id_claim_reject`,4)/100))+(SUM(IF(fc.id_pl_category_sub=3,fcd.prod_fc_det_qty,0))*(get_claim_reject_percent(pocd.`id_claim_reject`,3)/100))) AS amo_claim_major,
                                ROUND(wo_price.prod_order_wo_det_price * (SUM(IF(fc.id_pl_category_sub=6,fcd.prod_fc_det_qty,0))*(get_claim_reject_percent(pocd.`id_claim_reject`,6)/100))) AS amo_claim_afkir
                                ,rec.qty_rec AS qty_rec,wo_price.qty_order AS qty_order
                                ,wo_price.comp_name
                                ,dsg.design_display_name
                                ,wo_price.prod_order_wo_det_price
                                FROM tb_prod_order_close_det pocd
                                INNER JOIN tb_prod_fc fc ON fc.`id_prod_order`=pocd.`id_prod_order`
                                INNER JOIN tb_prod_fc_det fcd ON fcd.`id_prod_fc`=fc.`id_prod_fc`
                                INNER JOIN tb_prod_order po ON po.`id_prod_order`=pocd.`id_prod_order`
                                INNER JOIN tb_prod_demand_design pdd ON pdd.`id_prod_demand_design`=po.`id_prod_demand_design`
                                INNER JOIN tb_m_design dsg ON dsg.`id_design`=pdd.`id_design`
                                INNER JOIN tb_lookup_pl_category_sub plc ON plc.`id_pl_category_sub`=fc.`id_pl_category_sub`
                                INNER JOIN tb_m_claim_reject_det crd ON crd.`id_claim_reject`=pocd.`id_claim_reject` AND crd.`id_pl_category_sub`=fc.`id_pl_category_sub`
                                LEFT JOIN (
	                                SELECT comp.comp_name,wo.id_prod_order, wo.prod_order_wo_del_date,wo.id_ovh_price,  cur.currency, wo.prod_order_wo_vat, wod.prod_order_wo_det_price, wo.`prod_order_wo_kurs`, SUM(pod.prod_order_qty) AS qty_order
	                                FROM tb_prod_order_wo wo
	                                INNER JOIN tb_prod_order_wo_det wod ON wod.id_prod_order_wo = wo.id_prod_order_wo AND wo.id_report_status!='5'
	                                INNER JOIN tb_prod_order_det pod ON pod.id_prod_order_det = wod.id_prod_order_det
	                                INNER JOIN tb_lookup_currency cur ON cur.id_currency=wo.id_currency
                                    LEFT JOIN tb_m_ovh_price ovh_p ON ovh_p.id_ovh_price=wo.id_ovh_price 
                                     LEFT JOIN tb_m_comp_contact cc ON cc.id_comp_contact=ovh_p.id_comp_contact 
                                    LEFT JOIN tb_m_comp comp ON comp.id_comp=cc.id_comp 
	                                WHERE wo.is_main_vendor=1 
	                                GROUP BY wo.id_prod_order_wo
                                ) wo_price ON wo_price.id_prod_order=po.id_prod_order
                                LEFT JOIN (
	                                SELECT rec.`id_prod_order`,rec.`id_prod_order_rec`,SUM(recd.`prod_order_rec_det_qty`) AS qty_rec,MIN(rec.`arrive_date`) AS first_rec_qc
	                                FROM tb_prod_order_rec rec
	                                INNER JOIN tb_prod_order_rec_det recd ON recd.`id_prod_order_rec`=rec.`id_prod_order_rec` AND rec.`id_report_status`='6'
	                                GROUP BY rec.id_prod_order
                                ) rec ON rec.`id_prod_order`=pocd.`id_prod_order`
                                WHERE pocd.id_prod_order_close = '" & id_pps & "'
                                GROUP BY pocd.`id_prod_order`"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCSumClaimReject.DataSource = data
        GVClaimReject.BestFitColumns()
    End Sub

    Sub load_det()
        Dim query As String = "SELECT pocd.`id_prod_order_close_det`,pocd.`id_prod_order`,IFNULL(rec.qty_rec,0)-IFNULL(retcd.qty,0) AS qty_rec,IFNULL(rec.first_rec_qc,0) AS first_rec_qc,SUM(pod.`prod_order_qty`) AS qty_po
                                ,qcr.qty_normal,qcr.qty_normal_minor,qcr.qty_minor,qcr.qty_minor_major,qcr.qty_major,qcr.qty_afkir
                                ,wo_price.currency,wo_price.prod_order_wo_vat,wo_price.prod_order_wo_det_price,wo_price.`prod_order_wo_kurs`
                                ,DATE_ADD(wo_price.prod_order_wo_del_date, INTERVAL IFNULL(ko.lead_time_prod,wo_price.prod_order_wo_lead_time) DAY) AS est_rec_date
                                ,DATE_ADD(wo_price.prod_order_wo_del_date, INTERVAL ko.lead_time_prod DAY) AS est_rec_date_ko
                                ,IF(DATEDIFF(rec.first_rec_qc,DATE_ADD(wo_price.prod_order_wo_del_date, INTERVAL ko.lead_time_prod DAY))<0,0,DATEDIFF(rec.first_rec_qc,DATE_ADD(wo_price.prod_order_wo_del_date, INTERVAL ko.lead_time_prod DAY))) AS late
                                ,dsg.`design_code`,dsg.`design_name`,po.`prod_order_number`,pocd.`id_claim_late`,pocd.`id_claim_reject`
                                ,wo_price.comp_name
                                FROM tb_prod_order_close_det pocd
                                INNER JOIN tb_prod_order_close poc ON poc.`id_prod_order_close`=pocd.`id_prod_order_close`
                                INNER JOIN tb_prod_order_det pod ON pod.`id_prod_order`=pocd.`id_prod_order`
                                INNER JOIN tb_prod_order po ON po.`id_prod_order`=pod.`id_prod_order` 
                                INNER JOIN tb_prod_demand_design pdd ON pdd.`id_prod_demand_design`=po.`id_prod_demand_design`
                                INNER JOIN tb_m_design dsg ON dsg.`id_design`=pdd.`id_design`
                                LEFT JOIN (
	                                SELECT rec.`id_prod_order`,rec.`id_prod_order_rec`,SUM(recd.`prod_order_rec_det_qty`) AS qty_rec,MIN(rec.`arrive_date`) AS first_rec_qc
	                                FROM tb_prod_order_rec rec
	                                INNER JOIN tb_prod_order_rec_det recd ON recd.`id_prod_order_rec`=rec.`id_prod_order_rec` AND rec.`id_report_status`='6'
	                                GROUP BY rec.id_prod_order
                                ) rec ON rec.`id_prod_order`=pocd.`id_prod_order`
                                LEFT JOIN
                                (
	                                SELECT fc.`id_prod_order`,SUM(IF(fc.id_pl_category_sub=1,fcd.prod_fc_det_qty,0)) AS qty_normal,
	                                SUM(IF(fc.id_pl_category_sub=2,fcd.prod_fc_det_qty,0)) AS qty_normal_minor,
	                                SUM(IF(fc.id_pl_category_sub=3,fcd.prod_fc_det_qty,0)) AS qty_minor,
	                                SUM(IF(fc.id_pl_category_sub=4,fcd.prod_fc_det_qty,0)) AS qty_minor_major,
	                                SUM(IF(fc.id_pl_category_sub=5,fcd.prod_fc_det_qty,0)) AS qty_major,
	                                SUM(IF(fc.id_pl_category_sub=6,fcd.prod_fc_det_qty,0)) AS qty_afkir 
	                                FROM tb_prod_fc_det fcd
	                                INNER JOIN tb_prod_fc fc ON fc.`id_prod_fc`=fcd.`id_prod_fc` AND fc.`id_report_status`=6
	                                WHERE NOT ISNULL(fc.`id_pl_category_sub`)
	                                GROUP BY fc.`id_prod_order`
                                )qcr ON qcr.id_prod_order=po.`id_prod_order`
                                LEFT JOIN (
	                                SELECT comp.comp_name,wo.id_prod_order, wo.prod_order_wo_del_date, wo.prod_order_wo_lead_time,wo.id_ovh_price, cur.currency, wo.prod_order_wo_vat, wod.prod_order_wo_det_price, wo.`prod_order_wo_kurs`
	                                FROM tb_prod_order_wo wo
	                                INNER JOIN tb_prod_order_wo_det wod ON wod.id_prod_order_wo = wo.id_prod_order_wo
	                                INNER JOIN tb_prod_order_det pod ON pod.id_prod_order_det = wod.id_prod_order_det
	                                INNER JOIN tb_lookup_currency cur ON cur.id_currency=wo.id_currency
                                    LEFT JOIN tb_m_ovh_price ovh_p ON ovh_p.id_ovh_price=wo.id_ovh_price 
                                    LEFT JOIN tb_m_comp_contact cc ON cc.id_comp_contact=ovh_p.id_comp_contact 
                                    LEFT JOIN tb_m_comp comp ON comp.id_comp=cc.id_comp 
	                                WHERE wo.is_main_vendor=1 
	                                GROUP BY wo.id_prod_order_wo
                                ) wo_price ON wo_price.id_prod_order=po.id_prod_order
                                LEFT JOIN (
	                                SELECT id_prod_order,lead_time_prod,lead_time_payment FROM (
		                                SELECT * FROM tb_prod_order_ko_det
		                                ORDER BY id_prod_order_ko_det DESC
	                                )ko GROUP BY ko.id_prod_order
                                ) ko ON ko.id_prod_order=po.id_prod_order
                                
                                LEFT JOIN tb_prod_claim_return_det retcd ON retcd.`id_prod_order_det`=pod.`id_prod_order_det`
                                LEFT JOIN tb_prod_claim_return retc ON retc.`id_prod_claim_return`=retcd.`id_prod_claim_return` AND retc.`id_report_status`='6'
                                WHERE pocd.`id_prod_order_close`='" & id_pps & "'
                                GROUP BY pocd.`id_prod_order`"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCProd.DataSource = data
        GVProd.BestFitColumns()
    End Sub

    Private Sub FormProdClosingPps_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub
End Class