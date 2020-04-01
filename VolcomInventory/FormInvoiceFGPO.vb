Public Class FormInvoiceFGPO
    Dim bnew_active As String = "1"
    Dim bedit_active As String = "1"
    Dim bdel_active As String = "1"

    Dim id_pay_type_po As String = "-1"

    Dim is_all_vendor As String = "-1"

    Private Sub FormInvoiceFGPO_Deactivate(sender As Object, e As EventArgs) Handles MyBase.Deactivate
        FormMain.hide_rb()
    End Sub

    Private Sub FormInvoiceFGPO_Activated(sender As Object, e As EventArgs) Handles MyBase.Activated
        FormMain.show_rb(Name)
        check_menu()
    End Sub

    Sub check_menu()
        bnew_active = "1"
        bedit_active = "1"
        bdel_active = "1"
        checkFormAccess(Name)
        button_main(bnew_active, bedit_active, bdel_active)
    End Sub

    Private Sub FormInvoiceFGPO_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        load_vendor()
        load_list("0")
    End Sub

    Sub load_vendor()
        Dim query As String = "SELECT 0 AS id_comp,'All' as comp_name
                                UNION
                                SELECT c.id_comp,CONCAT(c.comp_number,' - ',c.comp_name) as comp_name  
                                FROM tb_m_comp c
                                WHERE c.id_comp_cat='1' "
        viewSearchLookupQuery(SLEVendorPayment, query, "id_comp", "comp_name", "id_comp")
    End Sub

    Sub load_list(ByVal is_filter_design As String)
        Dim q_pay As String = "SELECT id_acc_dp,id_acc_ap FROM tb_m_comp WHERE id_comp='" & SLEVendorPayment.EditValue.ToString & "'"
        Dim dt_pay As DataTable = execute_query(q_pay, -1, True, "", "", "", "")
        If Not SLEVendorPayment.EditValue.ToString = "0" AndAlso (dt_pay.Rows(0)("id_acc_dp").ToString = "" Or dt_pay.Rows(0)("id_acc_ap").ToString = "") Then
            warningCustom("Please set this vendor DP/AP account first")
        Else
            Dim query_where As String = ""

            If SLEVendorPayment.EditValue.ToString = "0" Then
                is_all_vendor = "1"
            Else
                query_where = " AND c.id_comp = '" & SLEVendorPayment.Properties.View.GetFocusedRowCellValue("id_comp").ToString & "'"
            End If
            '
            If XTCInvoiceFGPO.SelectedTabPageIndex = 0 Then
                'list payment
                Dim query As String = "SELECT pn.*,pnt.pn_type,sts.report_status,emp.`employee_name`,c.`comp_number`,c.`comp_name`,det.amount,det.amount_vat,det.total_amount 
,det.report_number,det.inv_number
FROM tb_pn_fgpo pn
INNER JOIN tb_m_user usr ON usr.`id_user`=pn.`created_by`
INNER JOIN tb_m_employee emp ON emp.`id_employee`=usr.`id_employee`
INNER JOIN tb_m_comp c ON c.`id_comp`=pn.`id_comp`
INNER JOIN (
	SELECT id_pn_fgpo,SUM(`value`) AS amount,SUM(`vat`) AS amount_vat,SUM(`value`+`vat`) AS total_amount 
        ,GROUP_CONCAT(pnd.report_number) AS report_number,GROUP_CONCAT(pnd.inv_number) AS inv_number
    FROM tb_pn_fgpo_det pnd 
	GROUP BY pnd.`id_pn_fgpo`
) det ON det.id_pn_fgpo=pn.`id_pn_fgpo`
INNER JOIN tb_pn_type pnt ON pnt.id_type=pn.type
INNER JOIN tb_lookup_report_status sts ON sts.id_report_status=pn.id_report_status
WHERE 1=1 " & query_where
                Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
                GCBPL.DataSource = data
                GVBPL.BestFitColumns()
            ElseIf XTCInvoiceFGPO.SelectedTabPageIndex = 1 Then
                If XTCDP.SelectedTabPageIndex = 0 Then
                    'list DP
                    Dim query As String = "SELECT pn.*,sts.report_status,emp.`employee_name`,c.`comp_number`,c.`comp_name`,det.amount,det.amount_vat,det.total_amount
,det.report_number,det.inv_number
 FROM tb_pn_fgpo pn
INNER JOIN tb_m_user usr ON usr.`id_user`=pn.`created_by`
INNER JOIN tb_m_employee emp ON emp.`id_employee`=usr.`id_employee`
INNER JOIN tb_m_comp c ON c.`id_comp`=pn.`id_comp`
INNER JOIN (
	SELECT id_pn_fgpo,SUM(`value`) AS amount,SUM(`vat`) AS amount_vat,SUM(`value`+`vat`) AS total_amount 
    ,GROUP_CONCAT(pnd.report_number) AS report_number,GROUP_CONCAT(pnd.inv_number) AS inv_number
    FROM tb_pn_fgpo_det pnd 
	GROUP BY pnd.`id_pn_fgpo`
) det ON det.id_pn_fgpo=pn.`id_pn_fgpo`
INNER JOIN tb_pn_type pnt ON pnt.id_type=pn.type
INNER JOIN tb_lookup_report_status sts ON sts.id_report_status=pn.id_report_status
WHERE pnt.is_payment=2 " & query_where
                    Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
                    GCDP.DataSource = data
                    GVDP.BestFitColumns()
                ElseIf XTCDP.SelectedTabPageIndex = 1 Then
                    'list FGPO for DP
                    Dim query As String = "SELECT 'no' AS is_check,c.id_acc_dp AS id_acc,dsg.design_code,dsg.design_display_name,po.`id_prod_order`,py.payment,c.comp_number,c.comp_name,po.`prod_order_number`
,SUM(wod.`prod_order_wo_det_qty`) AS qty
,CAST(wod.`prod_order_wo_det_price` * SUM(wod.`prod_order_wo_det_qty`) AS DECIMAL(15,2)) AS po_amount_bef_kurs
,CAST(wod.`prod_order_wo_det_price` *(wo.prod_order_wo_vat/100)*SUM(wod.`prod_order_wo_det_qty`) AS DECIMAL(15,2)) AS po_amount_vat_bef_kurs
,CAST(wod.`prod_order_wo_det_price` * SUM(wod.`prod_order_wo_det_qty`) AS DECIMAL(15,2)) * wo.prod_order_wo_kurs AS po_amount
,CAST(wod.`prod_order_wo_det_price` * (wo.prod_order_wo_vat/100)*SUM(wod.`prod_order_wo_det_qty`) AS DECIMAL(15,2)) * wo.prod_order_wo_kurs AS po_amount_vat
,wo.id_currency,cur.currency,wo.prod_order_wo_kurs
,CAST((py.`dp_amount`/100) * wod.`prod_order_wo_det_price`*SUM(wod.`prod_order_wo_det_qty`) AS DECIMAL(15,2)) AS dp_amount_bef_kurs
,CAST((py.`dp_amount`/100) * (wo.prod_order_wo_vat/100) * wod.`prod_order_wo_det_price` * SUM(wod.`prod_order_wo_det_qty`) AS DECIMAL(15,2)) AS dp_amount_vat_bef_kurs
,CAST((py.`dp_amount`/100) * wod.`prod_order_wo_det_price` * SUM(wod.`prod_order_wo_det_qty`) AS DECIMAL(15,2)) * wo.prod_order_wo_kurs AS dp_amount 
,CAST((py.`dp_amount`/100) * (wo.prod_order_wo_vat/100) * wod.`prod_order_wo_det_price` * SUM(wod.`prod_order_wo_det_qty`) AS DECIMAL(15,2)) * wo.prod_order_wo_kurs AS dp_amount_vat
FROM tb_prod_order_wo_det wod
INNER JOIN tb_prod_order_wo wo ON wo.`id_prod_order_wo`=wod.`id_prod_order_wo`
INNER JOIN tb_lookup_currency cur ON cur.id_currency=wo.id_currency
INNER JOIN tb_m_ovh_price ovhp ON ovhp.id_ovh_price=wo.id_ovh_price
INNER JOIN tb_m_comp_contact cc ON cc.id_comp_contact = ovhp.id_comp_contact
INNER JOIN tb_m_comp c ON c.id_comp=cc.id_comp
INNER JOIN tb_prod_order po ON po.id_prod_order=wo.`id_prod_order` AND po.id_report_status='6'
INNER JOIN tb_prod_demand_design pdd ON pdd.id_prod_demand_design=po.`id_prod_demand_design` 
INNER JOIN tb_m_design dsg ON dsg.id_design=pdd.id_design
INNER JOIN tb_lookup_payment py ON py.`id_payment`=wo.`id_payment` AND py.`dp_amount` > 0
LEFT JOIN 
(
	SELECT id_prod_order FROM `tb_pn_fgpo_det` pnd
	INNER JOIN tb_pn_fgpo pn ON pn.id_pn_fgpo=pnd.id_pn_fgpo
	WHERE pn.id_report_status !=5 AND pn.doc_type=2 AND pn.type=1
	GROUP BY id_prod_order
)dp_paid ON dp_paid.id_prod_order=po.id_prod_order
WHERE wo.`is_main_vendor`='1' AND po.`is_dp_paid`='2' AND ISNULL(dp_paid.id_prod_order) " & query_where & "
GROUP BY wo.`id_prod_order_wo`"
                    Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
                    GCDPFGPO.DataSource = data
                    GVDPFGPO.BestFitColumns()
                    If Not SLEVendorPayment.EditValue.ToString = "0" Then
                        PCDPFGPO.Visible = True
                    Else
                        PCDPFGPO.Visible = False
                    End If
                End If
            ElseIf XTCInvoiceFGPO.SelectedTabPageIndex = 2 Then
                'list payment
                Dim query As String = "SELECT pn.*,pnt.pn_type,sts.report_status,emp.`employee_name`,c.`comp_number`,c.`comp_name`,det.amount,det.amount_vat,det.total_amount 
,det.report_number,det.inv_number
FROM tb_pn_fgpo pn
INNER JOIN tb_m_user usr ON usr.`id_user`=pn.`created_by`
INNER JOIN tb_m_employee emp ON emp.`id_employee`=usr.`id_employee`
INNER JOIN tb_m_comp c ON c.`id_comp`=pn.`id_comp`
INNER JOIN (
	SELECT id_pn_fgpo,SUM(`value`) AS amount,SUM(`vat`) AS amount_vat,SUM(`value`+`vat`) AS total_amount 
        ,GROUP_CONCAT(pnd.report_number) AS report_number,GROUP_CONCAT(pnd.inv_number) AS inv_number
    FROM tb_pn_fgpo_det pnd 
	GROUP BY pnd.`id_pn_fgpo`
) det ON det.id_pn_fgpo=pn.`id_pn_fgpo`
INNER JOIN tb_pn_type pnt ON pnt.id_type=pn.type
INNER JOIN tb_lookup_report_status sts ON sts.id_report_status=pn.id_report_status
WHERE pnt.is_payment=1 " & query_where
                Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
                GCPayment.DataSource = data
                GVPayment.BestFitColumns()
            End If
        End If
        '

    End Sub

    Private Sub BViewPayment_Click(sender As Object, e As EventArgs) Handles BViewPayment.Click
        load_list("0")
    End Sub

    Sub print_list()

    End Sub

    Private Sub BCreateDP_Click(sender As Object, e As EventArgs) Handles BCreateDP.Click
        GVDPFGPO.ActiveFilterString = "[is_check]='yes'"
        If GVDPFGPO.RowCount > 0 Then
            'check if already DP
            Dim id As String = ""
            For i = 0 To GVDPFGPO.RowCount - 1
                If Not i = 0 Then
                    id += ","
                End If
                id += "'" & GVDPFGPO.GetRowCellValue(i, "id_prod_order").ToString & "'"
            Next
            '
            Dim query_check As String = "SELECT * FROM tb_pn_fgpo_det pnd
INNER JOIN tb_pn_fgpo pn ON pnd.`id_pn_fgpo`=pn.`id_pn_fgpo` AND pn.`id_report_status` != 5 
LEFT JOIN tb_prod_order po ON po.`id_prod_order`=pnd.`id_report` 
WHERE pnd.`id_report` IN (" & id & ") AND pnd.report_mark_type='22'"
            Dim data_check As DataTable = execute_query(query_check, -1, True, "", "", "", "")
            If data_check.Rows.Count > 0 Then
                Dim number_already_dp As String = ""
                For i = 0 To data_check.Rows.Count - 1
                    If Not i = 0 Then
                        number_already_dp += ","
                    End If
                    number_already_dp += "'" & data_check.Rows(i)("prod_order_number").ToString & "'"
                Next
                warningCustom("DP FGPO with number : " & number_already_dp & " already process.")
            Else
                FormInvoiceFGPODP.ShowDialog()
            End If
        End If
        GVDPFGPO.ActiveFilterString = ""
    End Sub


    Private Sub BCreateBPLRec_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub BFilterDesign_Click(sender As Object, e As EventArgs)
        load_list("1")
    End Sub

    'Private Sub GVDPFGPO_DoubleClick(sender As Object, e As EventArgs) Handles GVDPFGPO.DoubleClick
    '    If GVDPFGPO.RowCount > 0 Then
    '        FormReportPaymentFGPO.id_fgpo = GVDPFGPO.GetFocusedRowCellValue("id_prod_order").ToString
    '        FormReportPaymentFGPO.ShowDialog()
    '    Else
    '        warningCustom("Please choose FGPO first")
    '    End If
    'End Sub

    Private Sub GVDP_DoubleClick(sender As Object, e As EventArgs) Handles GVDP.DoubleClick
        If GVDP.RowCount > 0 Then
            FormInvoiceFGPODP.id_invoice = GVDP.GetFocusedRowCellValue("id_pn_fgpo").ToString
            FormInvoiceFGPODP.type = "2"
            FormInvoiceFGPODP.ShowDialog()
        End If
    End Sub

    Private Sub GVPayment_DoubleClick(sender As Object, e As EventArgs) Handles GVPayment.DoubleClick
        If GVPayment.RowCount > 0 Then
            FormInvoiceFGPODP.id_invoice = GVPayment.GetFocusedRowCellValue("id_pn_fgpo").ToString
            FormInvoiceFGPODP.type = "2"
            FormInvoiceFGPODP.ShowDialog()
        End If
    End Sub

    Private Sub GVBPL_DoubleClick(sender As Object, e As EventArgs) Handles GVBPL.DoubleClick
        If GVBPL.RowCount > 0 Then
            FormInvoiceFGPODP.id_invoice = GVBPL.GetFocusedRowCellValue("id_pn_fgpo").ToString
            FormInvoiceFGPODP.doc_type = GVBPL.GetFocusedRowCellValue("doc_type").ToString
            FormInvoiceFGPODP.ShowDialog()
        End If
    End Sub

    Private Sub BBBPLUmum_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BBBPLUmum.ItemClick
        FormInvoiceFGPODP.doc_type = "1"
        FormInvoiceFGPODP.ShowDialog()
    End Sub

    Private Sub BBPaymentFGPO_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BBPaymentFGPO.ItemClick
        FormInvoiceFGPODP.doc_type = "2"
        FormInvoiceFGPODP.type = "2"
        FormInvoiceFGPODP.ShowDialog()
    End Sub

    Private Sub BBDPFGPO_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BBDPFGPO.ItemClick
        XTCInvoiceFGPO.SelectedTabPageIndex = 1
    End Sub
End Class