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
        load_list()
    End Sub

    Sub load_vendor()
        Dim query As String = "SELECT 0 AS id_comp_contact,'All' as comp_name
                                UNION
                                SELECT cc.id_comp_contact,CONCAT(c.comp_number,' - ',c.comp_name) as comp_name  
                                FROM tb_m_comp c
                                INNER JOIN tb_m_comp_contact cc ON cc.`id_comp`=c.`id_comp` AND cc.`is_default`='1'
                                WHERE c.id_comp_cat='1' "
        viewSearchLookupQuery(SLEVendorPayment, query, "id_comp_contact", "comp_name", "id_comp_contact")
    End Sub

    Sub load_list()
        Dim query_vendor As String = ""

        If SLEVendorPayment.EditValue.ToString = "0" Then
            is_all_vendor = "1"
        Else
            query_vendor = " AND c.id_comp = '" & SLEVendorPayment.EditValue.ToString & "'"
        End If
        '
        If XTCInvoiceFGPO.SelectedTabPageIndex = 2 Then
        ElseIf XTCInvoiceFGPO.SelectedTabPageIndex = 1 Then
            If XTCDP.SelectedTabPageIndex = 0 Then
                'list DP
                Dim query As String = "SELECT pn.*,sts.report_status,emp.`employee_name`,c.`comp_number`,c.`comp_name`,acc.`acc_name`,acc.`acc_description`,det.amount FROM tb_pn_fgpo pn
INNER JOIN tb_m_user usr ON usr.`id_user`=pn.`created_by`
INNER JOIN tb_m_employee emp ON emp.`id_employee`=usr.`id_employee`
INNER JOIN tb_m_comp c ON c.`id_comp`=pn.`id_comp`
INNER JOIN `tb_a_acc` acc ON acc.`id_acc`=pn.`id_acc_payfrom`
INNER JOIN (
	SELECT id_pn_fgpo,SUM(`value`) AS amount FROM tb_pn_fgpo_det pnd 
	GROUP BY pnd.`id_pn_fgpo`
) det ON det.id_pn_fgpo=pn.`id_pn_fgpo`
INNER JOIN tb_lookup_report_status sts ON sts.id_report_status=pn.id_report_status
WHERE 1=1 " & query_vendor
                Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
                GCDP.DataSource = data
                GVDP.BestFitColumns()
            ElseIf XTCDP.SelectedTabPageIndex = 1 Then
                'list FGPO for DP
                Dim query As String = "SELECT 'no' AS is_check,dsg.design_code,dsg.design_display_name,po.`id_prod_order`,py.payment,c.comp_number,c.comp_name,po.`prod_order_number`,SUM(wod.`prod_order_wo_det_qty`) AS qty, wod.`prod_order_wo_det_price`*SUM(wod.`prod_order_wo_det_qty`) AS po_amount,(py.`dp_amount`/100) * wod.`prod_order_wo_det_price`*SUM(wod.`prod_order_wo_det_qty`) AS dp_amount FROM tb_prod_order_wo_det wod
INNER JOIN tb_prod_order_wo wo ON wo.`id_prod_order_wo`=wod.`id_prod_order_wo`
INNER JOIN tb_m_ovh_price ovhp ON ovhp.id_ovh_price=wo.id_ovh_price
INNER JOIN tb_m_comp_contact cc ON cc.id_comp_contact = ovhp.id_comp_contact
INNER JOIN tb_m_comp c ON c.id_comp=cc.id_comp
INNER JOIN tb_prod_order po ON po.id_prod_order=wo.`id_prod_order` 
INNER JOIN tb_prod_demand_design pdd ON pdd.id_prod_demand_design=po.`id_prod_demand_design` 
INNER JOIN tb_m_design dsg ON dsg.id_design=pdd.id_design
INNER JOIN tb_lookup_payment py ON py.`id_payment`=wo.`id_payment` AND py.`dp_amount` > 0
WHERE wo.`is_main_vendor`='1' AND po.`is_dp_paid`='2' " & query_vendor & "
GROUP BY wo.`id_prod_order_wo`"
                Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
                GCDPFGPO.DataSource = data
                GVDPFGPO.BestFitColumns()
                '
                If SLEVendorPayment.EditValue.ToString = "0" Then
                    PCDPFGPO.Visible = False
                Else
                    PCDPFGPO.Visible = True
                End If
            End If
        End If
    End Sub

    Private Sub BViewPayment_Click(sender As Object, e As EventArgs) Handles BViewPayment.Click
        load_list()
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
WHERE pnd.`id_report` IN (" & id & ")"
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

    Private Sub GVDP_DoubleClick(sender As Object, e As EventArgs) Handles GVDP.DoubleClick
        If GVDP.RowCount > 0 Then
            FormInvoiceFGPODP.id_dp = GVDP.GetFocusedRowCellValue("id_pn_fgpo").ToString
            FormInvoiceFGPODP.ShowDialog()
        End If
    End Sub
End Class