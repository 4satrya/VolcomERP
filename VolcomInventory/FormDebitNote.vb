Public Class FormDebitNote
    Dim bnew_active As String = "1"
    Dim bedit_active As String = "1"
    Dim bdel_active As String = "1"

    Private Sub FormDebitNote_Deactivate(sender As Object, e As EventArgs) Handles MyBase.Deactivate
        FormMain.hide_rb()
    End Sub

    Private Sub FormDebitNote_Activated(sender As Object, e As EventArgs) Handles MyBase.Activated
        FormMain.show_rb(Name)
        check_menu()
    End Sub

    Sub check_menu()
        bnew_active = "0"
        bedit_active = "0"
        bdel_active = "0"
        checkFormAccess(Name)
        button_main(bnew_active, bedit_active, bdel_active)
    End Sub

    Private Sub FormDebitNote_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        viewVendor()
    End Sub

    Sub viewVendor()
        Dim query As String = ""
        query += "SELECT ('0') AS id_comp, ('-') AS comp_number, ('All Vendor') AS comp_name, ('ALL Vendor') AS comp_name_label UNION ALL "
        query += "SELECT comp.id_comp,comp.comp_number, comp.comp_name, CONCAT_WS(' - ', comp.comp_number,comp.comp_name) AS comp_name_label FROM tb_m_comp comp "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        viewSearchLookupQuery(SLEVendor, query, "id_comp", "comp_name_label", "id_comp")
    End Sub

    Private Sub BView_Click(sender As Object, e As EventArgs) Handles BView.Click
        load_form()
    End Sub

    Sub load_form()
        If XtraTabControl1.SelectedTabPageIndex = 0 Then
            load_debit_note()
        ElseIf XtraTabControl1.SelectedTabPageIndex = 1 Then
            load_claim_reject()
        ElseIf XtraTabControl1.SelectedTabPageIndex = 2 Then
            load_claim_late()
        End If
    End Sub

    Sub load_debit_note()
        Dim q_where As String = ""
        '
        If Not SLEVendor.EditValue.ToString = "0" Then
            q_where = " WHERE dn.id_comp='" & SLEVendor.EditValue.ToString & "'"
        End If

        Dim query As String = "SELECT dn.id_debit_note,dn.number,dnt.`dn_type`,dn.`created_date`,sts.`report_status`,emp.`employee_name`,comp.`comp_name`,SUM((dnd.claim_percent/100)*dnd.unit_price*dnd.qty) AS amount 
FROM tb_debit_note_det dnd
INNER JOIN tb_debit_note dn ON dn.`id_debit_note`=dnd.`id_debit_note` 
INNER JOIN tb_lookup_dn_type dnt ON dnt.`id_dn_type`=dn.`id_dn_type`
INNER JOIN tb_lookup_report_status sts ON sts.`id_report_status`=dn.`id_report_status`
INNER JOIN tb_m_user usr ON usr.`id_user`=dn.`created_by`
INNER JOIN tb_m_employee emp ON emp.`id_employee`=usr.`id_employee`
INNER JOIN tb_m_comp comp ON comp.`id_comp`=dn.`id_comp`
" & q_where & "
GROUP BY dnd.`id_debit_note`"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCDebitNote.DataSource = data
        GVDebitNote.BestFitColumns()
    End Sub

    Sub load_claim_late()
        Dim q_where As String = ""
        '
        If Not SLEVendor.EditValue.ToString = "0" Then
            q_where = " AND c.id_comp='" & SLEVendor.EditValue.ToString & "'"
        End If

        Dim query As String = "SELECT 'no' AS is_check,'28' AS report_mark_type,r.`id_prod_order_rec`,s.`season`,rd.`prod_order_rec_det_qty`,r.`id_prod_order`,po.prod_order_number,rec.rec_qty,pod.po_qty
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
,r.id_prod_order
FROM tb_prod_order_rec_det rd
INNER JOIN tb_prod_order_rec r ON r.`id_prod_order_rec`=rd.`id_prod_order_rec` AND r.`id_report_status`='6' AND r.is_claimed_late=2
INNER JOIN tb_prod_order po ON po.`id_prod_order`=r.`id_prod_order`
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
    INNER JOIN tb_prod_order_close_det pocd ON pocd.`id_prod_order`=rec.`id_prod_order`
    INNER JOIN tb_prod_order_close poc ON poc.id_prod_order_close=pocd.id_prod_order_close AND poc.id_report_status='6'
    GROUP BY rec.id_prod_order
) rec ON rec.id_prod_order=po.id_prod_order 
LEFT JOIN
(
    SELECT pod.id_prod_order,SUM(pod.prod_order_qty) AS po_qty 
    FROM tb_prod_order_det pod
    INNER JOIN tb_prod_order_close_det pocd ON pocd.`id_prod_order`=pod.`id_prod_order`
    INNER JOIN tb_prod_order_close poc ON poc.id_prod_order_close=pocd.id_prod_order_close AND poc.id_report_status='6'
    GROUP BY pod.`id_prod_order`
) pod ON pod.id_prod_order=r.`id_prod_order`
LEFT JOIN (
    SELECT id_prod_order,lead_time_prod,lead_time_payment FROM (
	    SELECT kod.* FROM tb_prod_order_ko_det kod
	    INNER JOIN tb_prod_order_close_det pocd ON pocd.`id_prod_order`=kod.`id_prod_order`
        INNER JOIN tb_prod_order_close poc ON poc.id_prod_order_close=pocd.id_prod_order_close AND poc.id_report_status='6'
	    INNER JOIN tb_prod_order_ko ko ON ko.`id_prod_order_ko`=kod.`id_prod_order_ko` AND ko.`is_void`!=1
	    ORDER BY id_prod_order_ko_det DESC
    )ko GROUP BY ko.id_prod_order
) ko ON ko.id_prod_order=po.id_prod_order
LEFT JOIN (
    SELECT id_report FROM tb_debit_note_det dnd
    INNER JOIN tb_debit_note dn ON dn.`id_debit_note`=dnd.`id_debit_note` AND dnd.`report_mark_type`=28 AND dn.`id_report_status`!=5
    GROUP BY dnd.id_report
) dn ON dn.id_report=r.id_prod_order_rec
INNER JOIN tb_m_claim_late_det ld ON DATEDIFF(r.`arrive_date`,DATE_ADD(wo.prod_order_wo_del_date, INTERVAL IFNULL(ko.lead_time_prod,wo.`prod_order_wo_lead_time`) DAY))>=ld.`min_late` AND IF(ld.max_late=0,TRUE,DATEDIFF(r.`arrive_date`,DATE_ADD(wo.prod_order_wo_del_date, INTERVAL IFNULL(ko.lead_time_prod,wo.`prod_order_wo_lead_time`) DAY))<=ld.max_late)
WHERE cl.`id_report_status`='6' AND  ld.`claim_percent` > 0  AND ISNULL(dn.id_report) " & q_where & "
GROUP BY rd.`id_prod_order_rec`"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCClaimLate.DataSource = data
        GVClaimLate.BestFitColumns()
        If SLEVendor.EditValue.ToString = "0" Then
            BCreateDNLate.Visible = False
        Else
            BCreateDNLate.Visible = True
        End If
    End Sub

    Sub load_claim_reject()
        Dim q_where As String = ""
        '
        If Not SLEVendor.EditValue.ToString = "0" Then
            q_where = " AND wo_price.id_comp='" & SLEVendor.EditValue.ToString & "'"
        End If

        Dim query As String = "SELECT 'no' AS is_check,'22' AS report_mark_type,fc.`id_prod_fc`,fc.`prod_fc_number`,po.`id_prod_order`,dsg.`design_code`,dsg.`design_name`,po.`prod_order_number`,plc.`pl_category_sub`,fcd.*,
                                SUM(IF(fc.id_pl_category_sub=1,fcd.prod_fc_det_qty,0)) AS qc_normal,
                                get_claim_reject_percent(ko.`id_claim_reject`,1) AS p_normal,
                                SUM(IF(fc.id_pl_category_sub=2,fcd.prod_fc_det_qty,0)) AS qc_normal_minor,
                                get_claim_reject_percent(ko.`id_claim_reject`,2) AS p_normal_minor,
                                SUM(IF(fc.id_pl_category_sub=3,fcd.prod_fc_det_qty,0)) AS qc_minor,
                                get_claim_reject_percent(ko.`id_claim_reject`,3) AS p_minor,
                                SUM(IF(fc.id_pl_category_sub=4,fcd.prod_fc_det_qty,0)) AS qc_minor_major,
                                get_claim_reject_percent(ko.`id_claim_reject`,4) AS p_minor_major,
                                SUM(IF(fc.id_pl_category_sub=5,fcd.prod_fc_det_qty,0)) AS qc_major,
                                get_claim_reject_percent(ko.`id_claim_reject`,5) AS p_major,
                                SUM(IF(fc.id_pl_category_sub=6,fcd.prod_fc_det_qty,0)) AS qc_afkir, 
                                get_claim_reject_percent(ko.`id_claim_reject`,6) AS p_afkir,
                                wo_price.prod_order_wo_det_price AS unit_price,
                                ROUND(wo_price.prod_order_wo_det_price*((100-IFNULL(recfc.claim_percent,0))/100) * ((SUM(IF(fc.id_pl_category_sub=2,fcd.prod_fc_det_qty,0))*(get_claim_reject_percent(ko.`id_claim_reject`,2)/100))+(SUM(IF(fc.id_pl_category_sub=3,fcd.prod_fc_det_qty,0))*(get_claim_reject_percent(ko.`id_claim_reject`,3)/100)))) AS amo_claim_minor,
                                ROUND(wo_price.prod_order_wo_det_price*((100-IFNULL(recfc.claim_percent,0))/100) * ((SUM(IF(fc.id_pl_category_sub=4,fcd.prod_fc_det_qty,0))*(get_claim_reject_percent(ko.`id_claim_reject`,4)/100))+(SUM(IF(fc.id_pl_category_sub=5,fcd.prod_fc_det_qty,0))*(get_claim_reject_percent(ko.`id_claim_reject`,5)/100)))) AS amo_claim_major,
                                ROUND(wo_price.prod_order_wo_det_price*((100-IFNULL(recfc.claim_percent,0))/100) * (SUM(IF(fc.id_pl_category_sub=6,fcd.prod_fc_det_qty,0))*(get_claim_reject_percent(ko.`id_claim_reject`,6)/100))) AS amo_claim_afkir
                                ,IFNULL(recfc.qty_rec,rec.qty_rec) AS qty_rec,wo_price.qty_order AS qty_order
                                ,wo_price.comp_name
                                ,dsg.design_display_name
                                ,(wo_price.prod_order_wo_det_price*((100-IFNULL(recfc.claim_percent,0))/100)) AS prod_order_wo_det_price -- real price rec
                                ,recfc.prod_order_rec_number,IFNULL(recfc.claim_percent,0) AS rec_discount
                                ,IFNULL(pl_rec.pl_category,'Normal') AS rec_pl_category
                                ,(wo_price.prod_order_wo_det_price*((100-IFNULL(recfc.claim_percent,0))/100)) AS rec_amount_disc
                                ,fc.id_prod_fc AS id_reff,fcs.number AS sum_number
                                FROM tb_prod_fc_sum_det fcsd
                                INNER JOIN tb_prod_fc_sum fcs ON fcs.`id_prod_fc_sum`=fcsd.`id_prod_fc_sum` AND fcs.`id_report_status`='6'
                                INNER JOIN tb_prod_fc fc ON fc.`id_prod_fc`=fcsd.`id_prod_fc` 
                                LEFT JOIN (
                                    SELECT rec.`id_prod_order_rec`,SUM(recd.`prod_order_rec_det_qty`) AS qty_rec,rec.claim_percent,rec.prod_order_rec_number,rec.id_pl_category
                                    FROM tb_prod_order_rec_det recd
                                    INNER JOIN tb_prod_order_rec rec ON rec.`id_prod_order_rec`=recd.`id_prod_order_rec` AND rec.`id_report_status`=6
                                    GROUP BY rec.`id_prod_order_rec`
                                ) recfc ON recfc.`id_prod_order_rec`=fc.`id_prod_order_rec`
                                LEFT JOIN tb_lookup_pl_category pl_rec ON pl_rec.`id_pl_category`=recfc.`id_pl_category`
                                INNER JOIN tb_prod_fc_det fcd ON fcd.`id_prod_fc`=fc.`id_prod_fc` AND fc.id_report_status='6'
                                INNER JOIN tb_prod_order po ON po.`id_prod_order`=fc.`id_prod_order` AND po.is_claimed_reject=2
                                INNER JOIN tb_prod_demand_design pdd ON pdd.`id_prod_demand_design`=po.`id_prod_demand_design`
                                INNER JOIN tb_m_design dsg ON dsg.`id_design`=pdd.`id_design`
                                INNER JOIN tb_lookup_pl_category_sub plc ON plc.`id_pl_category_sub`=fc.`id_pl_category_sub`
                                LEFT JOIN (
                                    SELECT ko.id_prod_order_ko_det,ko.`id_prod_order`,ko.`id_claim_reject` 
                                    FROM (
	                                    SELECT kod.id_prod_order_ko_det,kod.`id_prod_order`,ko.`id_claim_reject` FROM tb_prod_order_ko_det kod
	                                    INNER JOIN tb_prod_order_ko ko ON ko.`id_prod_order_ko`=kod.`id_prod_order_ko` AND ko.is_void='2'AND is_locked='1'
	                                    ORDER BY kod.id_prod_order_ko_det DESC
                                    )ko GROUP BY ko.id_prod_order
                                ) ko ON ko.id_prod_order=po.id_prod_order 
                                INNER JOIN tb_m_claim_reject_det crd ON crd.`id_claim_reject`=ko.`id_claim_reject` AND crd.`id_pl_category_sub`=fc.`id_pl_category_sub`
                                LEFT JOIN (
	                                SELECT comp.id_comp, comp.comp_name,wo.id_prod_order, wo.prod_order_wo_del_date,wo.id_ovh_price,  cur.currency, wo.prod_order_wo_vat, wod.prod_order_wo_det_price, wo.`prod_order_wo_kurs`, SUM(pod.prod_order_qty) AS qty_order
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
                                ) rec ON rec.`id_prod_order`=fc.`id_prod_order`
                                LEFT JOIN (
                                    SELECT id_reff FROM tb_debit_note_det dnd
                                    INNER JOIN tb_debit_note dn ON dn.`id_debit_note`=dnd.`id_debit_note` AND dnd.`report_mark_type`=22 AND dn.`id_report_status`!=5
                                    GROUP BY dnd.id_reff
                                ) dn ON dn.id_reff=fc.id_prod_fc
                                WHERE fc.id_report_status = '6' AND ISNULL(dn.id_reff) " & q_where & "
                                GROUP BY fc.`id_prod_fc`"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCSumClaimReject.DataSource = data
        GVSumClaimReject.BestFitColumns()
        If SLEVendor.EditValue.ToString = "0" Then
            PCDebitNote.Visible = False
        Else
            PCDebitNote.Visible = True
        End If
    End Sub

    Private Sub BCreateDNReject_Click(sender As Object, e As EventArgs) Handles BCreateDNReject.Click
        Cursor = Cursors.WaitCursor
        GVSumClaimReject.ActiveFilterString = "[is_check] = 'yes'"
        If GVSumClaimReject.RowCount > 0 Then
            FormDebitNoteDet.id_dn_type = "1"
            FormDebitNoteDet.ShowDialog()
        Else
            warningCustom("Please select FGPO")
        End If
        GVSumClaimReject.ActiveFilterString = ""
        Cursor = Cursors.Default
    End Sub

    Private Sub BCreateDNLate_Click(sender As Object, e As EventArgs) Handles BCreateDNLate.Click
        Cursor = Cursors.WaitCursor
        GVClaimLate.ActiveFilterString = "[is_check] = 'yes'"
        If GVClaimLate.RowCount > 0 Then
            FormDebitNoteDet.id_dn_type = "2"
            FormDebitNoteDet.ShowDialog()
        Else
            warningCustom("Please select FGPO")
        End If
        GVClaimLate.ActiveFilterString = ""
        Cursor = Cursors.Default
    End Sub

    Private Sub GVDebitNote_DoubleClick(sender As Object, e As EventArgs) Handles GVDebitNote.DoubleClick
        If GVDebitNote.RowCount > 0 Then
            FormDebitNoteDet.id_dn = GVDebitNote.GetFocusedRowCellValue("id_debit_note").ToString
            FormDebitNoteDet.ShowDialog()
        End If
    End Sub

    Private Sub CESelectAll_CheckedChanged(sender As Object, e As EventArgs) Handles CESelectAll.CheckedChanged
        If GVSumClaimReject.RowCount > 0 Then
            Dim cek As String = CESelectAll.EditValue.ToString
            For i As Integer = 0 To ((GVSumClaimReject.RowCount - 1) - GetGroupRowCount(GVSumClaimReject))
                If cek Then
                    GVSumClaimReject.SetRowCellValue(i, "is_check", "yes")
                Else
                    GVSumClaimReject.SetRowCellValue(i, "is_check", "no")
                End If
            Next
        End If
    End Sub
End Class