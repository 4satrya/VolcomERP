Public Class FormInvoiceFGPONew
    Private Sub FormInvoiceFGPONew_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub BtnCancel_Click(sender As Object, e As EventArgs) Handles BtnCancel.Click
        Close()
    End Sub

    Sub view_type()
        Dim query As String = "SELECT id_type,pn_type FROM tb_pn_type WHERE is_payment =1"
        viewSearchLookupQuery(SLETypeInvoice, query, "id_type", "pn_type", "id_type")
    End Sub

    Sub view_fgpo()
        Dim query As String = "SELECT po.`id_prod_order`,po.`prod_order_number`,dsg.`design_display_name`,dsg.`design_code`,CONCAT(po.`prod_order_number`,' - ',dsg.`design_display_name`) AS view_po
FROM tb_prod_order_rec_det recd 
INNER JOIN tb_prod_order_rec rec ON rec.`id_prod_order_rec`=recd.`id_prod_order_rec` AND rec.`id_report_status`=6
INNER JOIN tb_prod_order_det pod ON pod.`id_prod_order_det`=recd.`id_prod_order_det`
INNER JOIN tb_prod_order po ON po.`id_prod_order`=pod.`id_prod_order`
INNER JOIN tb_prod_demand_design pdd ON pdd.`id_prod_demand_design`=po.`id_prod_demand_design`
INNER JOIN tb_m_design dsg ON dsg.`id_design`=pdd.`id_design`
WHERE po.`id_report_status`='6'
GROUP BY po.`id_prod_order`"
        viewSearchLookupQuery(SLEFGPO, query, "id_prod_order", "view_po", "id_prod_order")
    End Sub

    Sub fill_grid()
        If SLETypeInvoice.EditValue.ToString = "2" Then 'payment
            'search qty order - qty after paid
            Dim query As String = "SELECT pod.`id_prod_order`,SUM(pod.`prod_order_qty`)-IFNULL(pn.qty_rec_paid,0) AS qty_po
FROM tb_prod_order_det pod
INNER JOIN tb_prod_order po ON po.`id_prod_order`=pod.`id_prod_order` AND po.`id_report_status`=6
LEFT JOIN 
(
	SELECT rec.`id_prod_order`,SUM(pnd.`qty`) AS qty_rec_paid FROM tb_pn_fgpo_det pnd 
	INNER JOIN tb_pn_fgpo pn ON pn.`id_pn_fgpo`=pnd.`id_pn_fgpo` AND pn.`type`='2' AND pn.`id_report_status`!=5 AND pnd.`report_mark_type`='28'
	INNER JOIN tb_prod_order_rec rec ON rec.`id_prod_order_rec`=pnd.`id_report`
	WHERE rec.`id_prod_order`='" & SLEFGPO.EditValue.ToString & "'
	GROUP BY rec.`id_prod_order`
)pn ON pn.id_prod_order=po.id_prod_order
WHERE po.id_prod_order='" & SLEFGPO.EditValue.ToString & "'
GROUP BY pod.`id_prod_order`
HAVING qty_po > 0"
            Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
            If data.Rows(0)("qty_po") > 0 Then
                Dim q_det As String = "-- normal
SELECT rec.`id_prod_order_rec`,rec.prod_order_rec_number,SUM(recd.`prod_order_rec_det_qty`)-IFNULL(pn.qty_rec_paid,0) AS qty_rec_remaining ,prc.prod_order_wo_det_price, prc.prod_order_wo_vat, prc.kurs
,dsg.design_display_name,prc.id_comp,prc.id_currency,prc.currency,prc.id_acc
FROM tb_prod_order_rec_det recd
INNER JOIN tb_prod_order_rec rec ON rec.`id_prod_order_rec`=recd.`id_prod_order_rec` AND rec.`id_report_status`=6
LEFT JOIN
(
	SELECT pnd.`id_report`,SUM(pnd.`qty`) AS qty_rec_paid FROM tb_pn_fgpo_det pnd 
	INNER JOIN tb_pn_fgpo pn ON pn.`id_pn_fgpo`=pnd.`id_pn_fgpo`
	WHERE pn.`type`='2' AND pn.`id_report_status`!=5 AND pnd.`report_mark_type`='28'
	GROUP BY pnd.`id_report`
) pn ON pn.id_report=rec.id_prod_order_rec
LEFT JOIN 
(
	SELECT wo.`id_prod_order`,IF(cou.is_domestic=1,(SELECT id_acc_hpp_dom FROM tb_opt_accounting),(SELECT id_acc_hpp_int FROM tb_opt_accounting)) AS `id_acc`,c.id_comp,wod.`prod_order_wo_det_price`,wo.`prod_order_wo_vat`,IF(wo.`id_currency`=1,1,wo.`prod_order_wo_kurs`) AS kurs,wo.`id_currency`,cur.currency
	FROM tb_prod_order_wo_det wod
	INNER JOIN tb_prod_order_wo wo ON wo.`id_prod_order_wo`=wod.`id_prod_order_wo`
    INNER JOIN tb_m_ovh_price ovhp ON ovhp.`id_ovh_price`=wo.`id_ovh_price`
    INNER JOIN tb_m_comp_contact cc ON cc.`id_comp_contact`=ovhp.`id_comp_contact`
    INNER JOIN tb_m_comp c ON c.`id_comp`=cc.`id_comp`
    INNER JOIN tb_m_city city ON city.id_city=c.id_city
    INNER JOIN tb_m_state stte ON stte.id_state=city.id_state
    INNER JOIN tb_m_region reg ON reg.id_region=stte.id_region
    INNER JOIN tb_m_country cou ON cou.id_country=reg.id_country
    INNER JOIN tb_lookup_currency cur ON cur.id_currency=wo.id_currency
	WHERE wo.`is_main_vendor`=1 AND wo.`id_prod_order`='" & SLEFGPO.EditValue.ToString & "'
	GROUP BY wo.`id_prod_order`
)prc ON prc.id_prod_order=rec.`id_prod_order`
INNER JOIN tb_prod_order po ON po.id_prod_order=rec.id_prod_order
INNER JOIN tb_prod_demand_design pdd ON pdd.id_prod_demand_design=po.id_prod_demand_design
INNER JOIN tb_m_design dsg ON dsg.id_design=pdd.id_design
WHERE rec.`id_prod_order`='" & SLEFGPO.EditValue.ToString & "' AND rec.is_over_tol=2
GROUP BY rec.`id_prod_order_rec`
HAVING qty_rec_remaining > 0"
                '
                Dim dt_det As DataTable = execute_query(q_det, -1, True, "", "", "", "")
                '
                Dim qty_po As Integer = data.Rows(0)("qty_po")
                Dim qty_rec As Integer = 0
                '
                Try
                    For i As Integer = 0 To dt_det.Rows.Count - 1
                        Dim qty_used As Integer = 0

                        If (qty_po - dt_det.Rows(i)("qty_rec_remaining")) < 0 Then
                            qty_used = dt_det.Rows(i)("qty_rec_remaining") - qty_po
                        Else
                            qty_used = dt_det.Rows(i)("qty_rec_remaining")
                        End If

                        'input ke grid
                        Dim newRow As DataRow = (TryCast(GCInvoice.DataSource, DataTable)).NewRow()
                        newRow("id_report") = dt_det.Rows(i)("id_prod_order_rec").ToString
                        newRow("id_comp") = dt_det.Rows(i)("id_comp").ToString
                        newRow("id_acc") = dt_det.Rows(i)("id_acc").ToString
                        newRow("report_mark_type") = "28"
                        newRow("report_number") = dt_det.Rows(i)("prod_order_rec_number").ToString
                        newRow("info_design") = dt_det.Rows(i)("design_display_name").ToString
                        newRow("qty") = qty_used
                        '
                        newRow("id_currency") = dt_det.Rows(i)("id_currency").ToString
                        newRow("currency") = dt_det.Rows(i)("currency").ToString
                        newRow("kurs") = dt_det.Rows(i)("kurs").ToString
                        newRow("value_bef_kurs") = qty_used * (dt_det.Rows(i)("prod_order_wo_det_price"))
                        '
                        newRow("value") = qty_used * (dt_det.Rows(i)("prod_order_wo_det_price") * dt_det.Rows(i)("kurs"))
                        newRow("vat") = qty_used * ((dt_det.Rows(i)("prod_order_wo_det_price") * dt_det.Rows(i)("prod_order_wo_vat")) * (dt_det.Rows(i)("kurs") / 100))
                        newRow("inv_number") = ""
                        newRow("note") = ""
                        TryCast(GCInvoice.DataSource, DataTable).Rows.Add(newRow)
                        '
                        qty_rec += qty_used
                        qty_po = qty_po - dt_det.Rows(i)("qty_rec_remaining")
                        If qty_po <= 0 Then
                            Exit For
                        End If
                    Next
                Catch ex As Exception
                    MsgBox(ex.ToString)
                End Try

                '
                'If qty_rec > 0 Then
                '    FormInvoiceFGPODP.id_po = SLEFGPO.EditValue.ToString
                '    Close()
                'Else
                '    warningCustom("There is no available qty receiving.")
                'End If
            Else
                warningCustom("There is no remaining payment for this payment type.")
            End If
        ElseIf SLETypeInvoice.EditValue.ToString = "3" Then 'Extra hingga 2%
            'search qty order - qty after paid
            Dim query As String = "SELECT pod.`id_prod_order`,SUM(pod.`prod_order_qty`) AS qty_po
FROM tb_prod_order_det pod
INNER JOIN tb_prod_order po ON po.`id_prod_order`=pod.`id_prod_order` AND po.`id_report_status`=6
WHERE po.id_prod_order='" & SLEFGPO.EditValue.ToString & "'
GROUP BY pod.`id_prod_order`"
            Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
            If data.Rows(0)("qty_po") > 0 Then
                Dim q_det As String = "-- extra
SELECT rec.`id_prod_order_rec`,rec.prod_order_rec_number,SUM(recd.`prod_order_rec_det_qty`)-IFNULL(pn.qty_rec_paid,0) AS qty_rec_remaining,(prc.prod_order_wo_det_price * 0.5) AS prod_order_wo_det_price, prc.prod_order_wo_vat AS prod_order_wo_vat, prc.kurs
,dsg.design_display_name,prc.id_comp,prc.id_currency,prc.currency,prc.id_acc
FROM tb_prod_order_rec_det recd
INNER JOIN tb_prod_order_rec rec ON rec.`id_prod_order_rec`=recd.`id_prod_order_rec` AND rec.`id_report_status`=6
LEFT JOIN
(
	SELECT pnd.`id_report`,SUM(pnd.`qty`) AS qty_rec_paid FROM tb_pn_fgpo_det pnd 
	INNER JOIN tb_pn_fgpo pn ON pn.`id_pn_fgpo`=pnd.`id_pn_fgpo`
	WHERE pn.`type`='3' AND pn.`id_report_status`!=5 AND pnd.`report_mark_type`='28'
	GROUP BY pnd.`id_report`
) pn ON pn.id_report=rec.id_prod_order_rec
LEFT JOIN 
(
	SELECT wo.`id_prod_order`,IF(cou.is_domestic=1,(SELECT id_acc_hpp_dom FROM tb_opt_accounting),(SELECT id_acc_hpp_int FROM tb_opt_accounting)) AS `id_acc`,c.id_comp,wod.`prod_order_wo_det_price`,wo.`prod_order_wo_vat`,IF(wo.`id_currency`=1,1,wo.`prod_order_wo_kurs`) AS kurs,wo.`id_currency`,cur.currency
	FROM tb_prod_order_wo_det wod
	INNER JOIN tb_prod_order_wo wo ON wo.`id_prod_order_wo`=wod.`id_prod_order_wo`
    INNER JOIN tb_m_ovh_price ovhp ON ovhp.`id_ovh_price`=wo.`id_ovh_price`
    INNER JOIN tb_m_comp_contact cc ON cc.`id_comp_contact`=ovhp.`id_comp_contact`
    INNER JOIN tb_m_comp c ON c.`id_comp`=cc.`id_comp`
    INNER JOIN tb_m_city city ON city.id_city=c.id_city
    INNER JOIN tb_m_state stte ON stte.id_state=city.id_state
    INNER JOIN tb_m_region reg ON reg.id_region=stte.id_region
    INNER JOIN tb_m_country cou ON cou.id_country=reg.id_country
    INNER JOIN tb_lookup_currency cur ON cur.id_currency=wo.id_currency
	WHERE wo.`is_main_vendor`=1 AND wo.`id_prod_order`='" & SLEFGPO.EditValue.ToString & "'
	GROUP BY wo.`id_prod_order`
)prc ON prc.id_prod_order=rec.`id_prod_order`
INNER JOIN tb_prod_order po ON po.id_prod_order=rec.id_prod_order
INNER JOIN tb_prod_demand_design pdd ON pdd.id_prod_demand_design=po.id_prod_demand_design
INNER JOIN tb_m_design dsg ON dsg.id_design=pdd.id_design
WHERE rec.`id_prod_order`='" & SLEFGPO.EditValue.ToString & "' AND rec.is_over_tol=2
GROUP BY rec.`id_prod_order_rec`
HAVING qty_rec_remaining > 0"
                '
                Dim dt_det As DataTable = execute_query(q_det, -1, True, "", "", "", "")
                '
                Dim qty_po As Integer = data.Rows(0)("qty_po")
                Dim qty_po_old As Integer = 0
                Dim qty_rec As Integer = 0
                '
                For i As Integer = 0 To dt_det.Rows.Count - 1
                    Dim qty_used As Integer = 0
                    '
                    qty_po_old = qty_po
                    qty_po = qty_po - dt_det.Rows(i)("qty_rec_remaining")
                    '
                    If qty_po < 0 Then
                        If qty_po_old >= 0 Then 'masih ada yang tidak extra
                            qty_used = dt_det.Rows(i)("qty_rec_remaining") - qty_po_old
                        Else 'extra only
                            qty_used = dt_det.Rows(i)("qty_rec_remaining")
                        End If
                        'input ke grid
                        Dim newRow As DataRow = (TryCast(GCInvoice.DataSource, DataTable)).NewRow()
                        newRow("id_report") = dt_det.Rows(i)("id_prod_order_rec").ToString
                        newRow("id_comp") = dt_det.Rows(i)("id_comp").ToString
                        newRow("id_acc") = dt_det.Rows(i)("id_acc").ToString
                        newRow("report_mark_type") = "28"
                        newRow("report_number") = dt_det.Rows(i)("prod_order_rec_number").ToString
                        newRow("info_design") = dt_det.Rows(i)("design_display_name").ToString
                        newRow("qty") = qty_used
                        '
                        newRow("id_currency") = dt_det.Rows(i)("id_currency").ToString
                        newRow("currency") = dt_det.Rows(i)("currency").ToString
                        newRow("kurs") = dt_det.Rows(i)("kurs").ToString
                        newRow("value_bef_kurs") = qty_used * (dt_det.Rows(i)("prod_order_wo_det_price"))
                        '
                        newRow("value") = qty_used * (dt_det.Rows(i)("prod_order_wo_det_price") * dt_det.Rows(i)("kurs"))
                        newRow("vat") = qty_used * ((dt_det.Rows(i)("prod_order_wo_det_price") * dt_det.Rows(i)("prod_order_wo_vat")) * (dt_det.Rows(i)("kurs") / 100))
                        newRow("inv_number") = ""
                        newRow("note") = ""
                        TryCast(GCInvoice.DataSource, DataTable).Rows.Add(newRow)
                        '
                        qty_rec += qty_used
                    End If
                Next
                '
                'If qty_rec > 0 Then
                '    FormInvoiceFGPODP.id_po = SLEFGPO.EditValue.ToString
                '    Close()
                'Else
                '    warningCustom("There is no available extra qty receiving to invoice.")
                'End If
            Else
                warningCustom("There is 0 remaining qty for this payment type.")
            End If
        ElseIf SLETypeInvoice.EditValue.ToString = "4" Then 'over memo
            Dim q_det As String = "-- extra
SELECT rec.`id_prod_order_rec`,rec.prod_order_rec_number,SUM(recd.`prod_order_rec_det_qty`)-IFNULL(pn.qty_rec_paid,0) AS qty_rec_remaining, (prc.prod_order_wo_det_price) * (100-overd.discount/100) AS prod_order_wo_det_price, prc.prod_order_wo_vat AS prod_order_wo_vat, prc.kurs
,dsg.design_display_name,prc.id_comp,prc.id_currency,prc.currency,prc.id_acc
FROM tb_prod_order_rec_det recd
INNER JOIN tb_prod_order_rec rec ON rec.`id_prod_order_rec`=recd.`id_prod_order_rec` AND rec.`id_report_status`=6
LEFT JOIN
(
	SELECT pnd.`id_report`,SUM(pnd.`qty`) AS qty_rec_paid FROM tb_pn_fgpo_det pnd 
	INNER JOIN tb_pn_fgpo pn ON pn.`id_pn_fgpo`=pnd.`id_pn_fgpo`
	WHERE pn.`type`='4' AND pn.`id_report_status`!=5 AND pnd.`report_mark_type`='28'
	GROUP BY pnd.`id_report`
) pn ON pn.id_report=rec.id_prod_order_rec
LEFT JOIN 
(
	SELECT wo.`id_prod_order`,IF(cou.is_domestic=1,(SELECT id_acc_hpp_dom FROM tb_opt_accounting),(SELECT id_acc_hpp_int FROM tb_opt_accounting)) AS `id_acc`,c.id_comp,wod.`prod_order_wo_det_price`,wo.`prod_order_wo_vat`,IF(wo.`id_currency`=1,1,wo.`prod_order_wo_kurs`) AS kurs,wo.`id_currency`,cur.currency
	FROM tb_prod_order_wo_det wod
	INNER JOIN tb_prod_order_wo wo ON wo.`id_prod_order_wo`=wod.`id_prod_order_wo`
    INNER JOIN tb_m_ovh_price ovhp ON ovhp.`id_ovh_price`=wo.`id_ovh_price`
    INNER JOIN tb_m_comp_contact cc ON cc.`id_comp_contact`=ovhp.`id_comp_contact`
    INNER JOIN tb_m_comp c ON c.`id_comp`=cc.`id_comp`
    INNER JOIN tb_m_city city ON city.id_city=c.id_city
    INNER JOIN tb_m_state stte ON stte.id_state=city.id_state
    INNER JOIN tb_m_region reg ON reg.id_region=stte.id_region
    INNER JOIN tb_m_country cou ON cou.id_country=reg.id_country
    INNER JOIN tb_lookup_currency cur ON cur.id_currency=wo.id_currency
	WHERE wo.`is_main_vendor`=1 AND wo.`id_prod_order`='" & SLEFGPO.EditValue.ToString & "'
	GROUP BY wo.`id_prod_order`
)prc ON prc.id_prod_order=rec.`id_prod_order`
INNER JOIN tb_prod_order po ON po.id_prod_order=rec.id_prod_order
INNER JOIN `tb_prod_over_memo_det` overd ON overd.id_prod_order=po.id_prod_order
INNER JOIN `tb_prod_over_memo` over ON over.id_prod_over_memo=rec.id_prod_over_memo AND over.id_prod_over_memo=overd.id_prod_over_memo
INNER JOIN tb_prod_demand_design pdd ON pdd.id_prod_demand_design=po.id_prod_demand_design
INNER JOIN tb_m_design dsg ON dsg.id_design=pdd.id_design
WHERE rec.`id_prod_order`='" & SLEFGPO.EditValue.ToString & "' AND rec.is_over_tol=1
GROUP BY rec.`id_prod_order_rec`
HAVING qty_rec_remaining > 0"
            '
            Dim dt_det As DataTable = execute_query(q_det, -1, True, "", "", "", "")
            Dim qty_rec As Integer = 0
            '
            For i As Integer = 0 To dt_det.Rows.Count - 1
                Dim qty_used As Integer = 0
                qty_used = dt_det.Rows(i)("qty_rec_remaining")
                '
                Dim newRow As DataRow = (TryCast(GCInvoice.DataSource, DataTable)).NewRow()
                newRow("id_report") = dt_det.Rows(i)("id_prod_order_rec").ToString
                newRow("id_comp") = dt_det.Rows(i)("id_comp").ToString
                newRow("id_acc") = dt_det.Rows(i)("id_acc").ToString
                newRow("report_mark_type") = "28"
                newRow("report_number") = dt_det.Rows(i)("prod_order_rec_number").ToString
                newRow("info_design") = dt_det.Rows(i)("design_display_name").ToString
                newRow("qty") = qty_used
                '
                newRow("id_currency") = dt_det.Rows(i)("id_currency").ToString
                newRow("currency") = dt_det.Rows(i)("currency").ToString
                newRow("kurs") = dt_det.Rows(i)("kurs").ToString
                newRow("value_bef_kurs") = qty_used * (dt_det.Rows(i)("prod_order_wo_det_price"))
                '
                newRow("value") = qty_used * (dt_det.Rows(i)("prod_order_wo_det_price") * dt_det.Rows(i)("kurs"))
                newRow("vat") = qty_used * ((dt_det.Rows(i)("prod_order_wo_det_price") * dt_det.Rows(i)("prod_order_wo_vat")) * (dt_det.Rows(i)("kurs") / 100))
                newRow("inv_number") = ""
                newRow("note") = ""
                TryCast(GCInvoice.DataSource, DataTable).Rows.Add(newRow)
                '
                qty_rec += qty_used
            Next
            '
            'If qty_rec > 0 Then
            '    FormInvoiceFGPODP.id_po = SLEFGPO.EditValue.ToString
            '    Close()
            'Else
            '    warningCustom("There is no available extra qty receiving to invoice.")
            'End If
        End If
    End Sub

    Private Sub BtnSave_Click(sender As Object, e As EventArgs) Handles BPick.Click
        If GVInvoice.RowCount > 0 Then
            Try
                Dim newRow As DataRow = (TryCast(FormInvoiceFGPODP.GCList.DataSource, DataTable)).NewRow()
                newRow("id_prod_order") = SLEFGPO.EditValue.ToString
                newRow("id_acc") = GVInvoice.GetFocusedRowCellValue("id_acc")
                newRow("id_report") = GVInvoice.GetFocusedRowCellValue("id_report")
                newRow("report_mark_type") = GVInvoice.GetFocusedRowCellValue("report_mark_type")
                newRow("report_number") = GVInvoice.GetFocusedRowCellValue("report_number")
                newRow("info_design") = GVInvoice.GetFocusedRowCellValue("info_design")
                newRow("qty") = GVInvoice.GetFocusedRowCellValue("qty")
                '
                newRow("id_currency") = GVInvoice.GetFocusedRowCellValue("id_currency").ToString
                newRow("kurs") = GVInvoice.GetFocusedRowCellValue("kurs")
                newRow("value_bef_kurs") = GVInvoice.GetFocusedRowCellValue("value_bef_kurs")
                '
                newRow("vat") = GVInvoice.GetFocusedRowCellValue("vat")
                newRow("inv_number") = ""
                newRow("note") = ""
                TryCast(FormInvoiceFGPODP.GCList.DataSource, DataTable).Rows.Add(newRow)
                FormInvoiceFGPODP.id_po = SLEFGPO.EditValue.ToString
                FormInvoiceFGPODP.SLEVendor.EditValue = GVInvoice.GetRowCellValue(0, "id_comp").ToString
                FormInvoiceFGPODP.SLEPayType.EditValue = SLETypeInvoice.EditValue
                Close()
            Catch ex As Exception
                MsgBox(ex.ToString)
            End Try
        Else
            warningCustom("No receiving")
        End If
    End Sub

    Private Sub FormInvoiceFGPONew_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        view_det()

        view_type()
        view_fgpo()
    End Sub

    Sub view_det()
        Dim query As String = "
Select pnd.`id_prod_order`,pnd.id_acc,pnd.`id_report` As id_report,pnd.report_mark_type, pnd.`report_number`, pnd.`info_design`, pnd.`id_pn_fgpo_det`,pnd.value, pnd.`qty`,pnd.`vat`, pnd.`inv_number`,pnd.value_bef_kurs,pnd.kurs,pnd.id_currency,cur.currency, pnd.`note` , '' AS id_comp
FROM tb_pn_fgpo_det pnd
INNER JOIN tb_lookup_currency cur ON cur.id_currency=pnd.id_currency
WHERE pnd.`id_pn_fgpo`='-1'"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCInvoice.DataSource = data
        GVInvoice.BestFitColumns()
    End Sub

    Private Sub BLoad_Click(sender As Object, e As EventArgs) Handles BLoad.Click
        For i = GVInvoice.RowCount - 1 To 0 Step -1
            GVInvoice.DeleteRow(i)
        Next
        fill_grid()
        GVInvoice.BestFitColumns()
        'check if dp on process
        Dim qdp As String = "SELECT * FROM tb_pn_fgpo_det pnd
INNER JOIN tb_pn_fgpo pn ON pn.`id_pn_fgpo`=pnd.`id_pn_fgpo`
WHERE pn.`type`=1 AND pnd.`id_prod_order`='" & SLEFGPO.EditValue.ToString & "' AND pn.`id_report_status`!=5 AND pn.`id_report_status`!=6"
        Dim dtdp As DataTable = execute_query(qdp, -1, True, "", "", "", "")
        If dtdp.Rows.Count > 0 Then
            warningCustom("Please note there are BPL DP waiting to approve, DP will not show if not approved.")
        End If
        '
        load_po()
    End Sub

    Private Sub BPickAll_Click(sender As Object, e As EventArgs) Handles BPickAll.Click
        If GVInvoice.RowCount > 0 Then
            Try
                For i As Integer = 0 To GVInvoice.RowCount - 1
                    Dim newRow As DataRow = (TryCast(FormInvoiceFGPODP.GCList.DataSource, DataTable)).NewRow()
                    newRow("id_prod_order") = SLEFGPO.EditValue.ToString
                    newRow("id_acc") = GVInvoice.GetRowCellValue(i, "id_acc")
                    newRow("id_report") = GVInvoice.GetRowCellValue(i, "id_report")
                    newRow("report_mark_type") = GVInvoice.GetRowCellValue(i, "report_mark_type")
                    newRow("report_number") = GVInvoice.GetRowCellValue(i, "report_number")
                    newRow("info_design") = GVInvoice.GetRowCellValue(i, "info_design")
                    newRow("qty") = GVInvoice.GetRowCellValue(i, "qty")
                    '
                    newRow("id_currency") = GVInvoice.GetRowCellValue(i, "id_currency").ToString
                    newRow("kurs") = GVInvoice.GetRowCellValue(i, "kurs")
                    newRow("value_bef_kurs") = GVInvoice.GetRowCellValue(i, "value_bef_kurs")
                    '
                    newRow("vat") = GVInvoice.GetRowCellValue(i, "vat")
                    newRow("inv_number") = ""
                    newRow("note") = ""
                    TryCast(FormInvoiceFGPODP.GCList.DataSource, DataTable).Rows.Add(newRow)
                Next
                FormInvoiceFGPODP.id_po = SLEFGPO.EditValue.ToString
                FormInvoiceFGPODP.SLEVendor.EditValue = GVInvoice.GetRowCellValue(0, "id_comp").ToString
                FormInvoiceFGPODP.SLEPayType.EditValue = SLETypeInvoice.EditValue
                Close()
            Catch ex As Exception
                MsgBox(ex.ToString)
            End Try

        Else
            warningCustom("No receiving")
        End If
    End Sub

    Private Sub BLoadPO_Click(sender As Object, e As EventArgs) Handles BLoadPO.Click
        load_po()
    End Sub

    Sub load_po()
        Dim id_po As String = SLEFGPO.EditValue.ToString
        Dim query As String = "SET @id_po = '" & id_po & "';

SELECT po.id_prod_order,'F.G.PO' AS type,pod.qty AS qty_po,po.prod_order_number AS number,dsg.design_code,dsg.design_display_name,NULL AS created_date
,IFNULL(rec_normal.qty,0) AS qty_rec,IFNULL(rec_extra.qty,0) AS qty_rec_extra,IFNULL(rec_over.qty,0) AS qty_rec_over
,IFNULL(rec_normal.qty*prc.prod_order_wo_det_price*prc.prod_order_wo_kurs,0) AS amount_rec
,IFNULL(rec_extra.qty*(prc.prod_order_wo_det_price*0.5)*prc.prod_order_wo_kurs,0) AS amount_rec_extra
,IFNULL(rec_over.qty*prc.prod_order_wo_det_price*prc.prod_order_wo_kurs*((100-rec_over.`discount`)/100),0) AS amount_rec_over
FROM tb_prod_order po
INNER JOIN
(
	SELECT wo.id_prod_order,wod.prod_order_wo_det_price,wo.`prod_order_wo_kurs`
	FROM `tb_prod_order_wo_det` wod
	INNER JOIN tb_prod_order_wo wo ON wo.`id_prod_order_wo`=wod.`id_prod_order_wo` AND wo.`is_main_vendor`='1' AND wo.`id_report_status`='6' AND wo.`id_prod_order`=@id_po
	LIMIT 1
)prc ON prc.id_prod_order=po.id_prod_order
INNER JOIN 
(
	SELECT pod.`id_prod_order`,SUM(pod.`prod_order_qty`) AS qty FROM tb_prod_order_det pod 
	WHERE pod.`id_prod_order`=@id_po
)pod ON pod.id_prod_order=po.`id_prod_order`
LEFT JOIN
(
	SELECT rec.`id_prod_order`,IF(SUM(recd.`prod_order_rec_det_qty`)>po.qty,po.qty,SUM(recd.`prod_order_rec_det_qty`)) AS qty 
	FROM tb_prod_order_rec_det recd
	INNER JOIN tb_prod_order_rec rec ON rec.`id_prod_order_rec`=recd.`id_prod_order_rec` AND rec.`id_report_status`=6
	INNER JOIN 
	(
		SELECT pod.`id_prod_order`,SUM(pod.`prod_order_qty`) AS qty FROM tb_prod_order_det pod 
		WHERE pod.`id_prod_order`=@id_po
	)po ON po.id_prod_order=rec.`id_prod_order`
	WHERE rec.`id_prod_order`=@id_po AND is_over_tol='2'
)rec_normal ON rec_normal.id_prod_order=po.id_prod_order
LEFT JOIN
(
	SELECT rec.`id_prod_order`,IF(SUM(recd.`prod_order_rec_det_qty`)>po.qty,SUM(recd.`prod_order_rec_det_qty`)-po.qty,0) AS qty 
	FROM tb_prod_order_rec_det recd
	INNER JOIN tb_prod_order_rec rec ON rec.`id_prod_order_rec`=recd.`id_prod_order_rec` AND rec.`id_report_status`=6
	INNER JOIN 
	(
		SELECT pod.`id_prod_order`,SUM(pod.`prod_order_qty`) AS qty FROM tb_prod_order_det pod 
		WHERE pod.`id_prod_order`=@id_po
	)po ON po.id_prod_order=rec.`id_prod_order`
	WHERE rec.`id_prod_order`=@id_po AND is_over_tol='2'
)rec_extra ON rec_extra.id_prod_order=po.id_prod_order
LEFT JOIN
(
	SELECT rec.`id_prod_order`, SUM(recd.`prod_order_rec_det_qty`) AS qty, ovmd.`discount`
	FROM tb_prod_order_rec_det recd
	INNER JOIN tb_prod_order_rec rec ON rec.`id_prod_order_rec`=recd.`id_prod_order_rec` AND rec.`id_report_status`=6
	INNER JOIN `tb_prod_over_memo_det` ovmd ON ovmd.`id_prod_over_memo`=rec.`id_prod_over_memo` AND ovmd.`id_prod_order`=rec.`id_prod_order`
	INNER JOIN tb_prod_over_memo ovm ON ovm.`id_prod_over_memo`=ovmd.id_prod_over_memo AND ovm.`id_report_status`=6
	INNER JOIN 
	(
		SELECT pod.`id_prod_order`,SUM(pod.`prod_order_qty`) AS qty FROM tb_prod_order_det pod 
		WHERE pod.`id_prod_order`=@id_po
	)po ON po.id_prod_order=rec.`id_prod_order`
	WHERE rec.`id_prod_order`=@id_po AND is_over_tol='1'
)rec_over ON rec_over.id_prod_order=po.id_prod_order
INNER JOIN tb_prod_demand_design pdd ON pdd.id_prod_demand_design=po.id_prod_demand_design
INNER JOIN tb_m_design dsg ON dsg.id_design=pdd.id_design
WHERE po.id_prod_order=@id_po
UNION ALL
SELECT pnd.`id_prod_order`,pnt.pn_type AS type,'' AS qty_po,pn.number AS number,'' AS design_code,'' AS design_display_name,pn.created_date
,-SUM(IF(pn.`type`=2 AND pnd.report_mark_type=28,pnd.`qty`,0)) AS qty_rec,-SUM(IF(pn.`type`=3 AND pnd.report_mark_type=28,pnd.`qty`,0)) AS qty_rec_extra,-SUM(IF(pn.`type`=4 AND pnd.report_mark_type=28,pnd.`qty`,0)) AS qty_rec_over
,-SUM(IF(pn.`type`=2 OR pn.`type`=1,pnd.`value`,0)) AS amount_rec,-SUM(IF(pn.`type`=3,pnd.`value`,0)) AS amount_rec_extra,-SUM(IF(pn.`type`=4,pnd.`value`,0)) AS amount_rec_over
FROM tb_pn_fgpo_det pnd
INNER JOIN tb_pn_fgpo pn ON pn.`id_pn_fgpo`=pnd.`id_pn_fgpo` AND pn.`id_report_status`!=5
INNER JOIN tb_pn_type pnt ON pnt.id_type=pn.type
WHERE pnd.`id_prod_order`=@id_po
GROUP BY pnd.id_pn_fgpo"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCRec.DataSource = data
        BGVRec.BestFitColumns()
    End Sub

    Private Sub BLoadHistory_Click(sender As Object, e As EventArgs) Handles BLoadHistory.Click
        Dim id_po As String = SLEFGPO.EditValue.ToString
        Dim query As String = "SELECT pn.`id_pn_fgpo`,pn.number,pnd.`id_report`,pn.created_date,pnd.`report_mark_type`,pnd.report_number AS reff,pn.created_by,emp.employee_name,pnd.`qty`,pnd.`value` AS `value`,pnd.`vat`,typ.pn_type AS `type`
FROM tb_pn_fgpo_det pnd
INNER JOIN tb_pn_fgpo pn ON pn.`id_pn_fgpo`=pnd.`id_pn_fgpo` AND pn.`id_report_status`!=5
INNER JOIN tb_m_user usr ON usr.id_user=pn.created_by
INNER JOIN tb_m_employee emp ON emp.id_employee=usr.id_employee
INNER JOIN `tb_pn_type` typ ON typ.id_type=pn.type
WHERE pnd.`id_prod_order`='" & id_po & "' "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCPayment.DataSource = data
        GVPayment.BestFitColumns()
    End Sub

    Private Sub BPrintInfo_Click(sender As Object, e As EventArgs) Handles BPrintInfo.Click
        print(GCRec, SLEFGPO.Text)
    End Sub
End Class