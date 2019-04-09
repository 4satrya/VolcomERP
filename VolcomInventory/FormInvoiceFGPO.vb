﻿Public Class FormInvoiceFGPO
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

            ElseIf XTCDP.SelectedTabPageIndex = 1 Then
                'list FGPO for DP
                Dim query As String = "SELECT 'no' AS is_check,po.`id_prod_order`,py.payment,c.comp_number,c.comp_name,po.`prod_order_number`,SUM(wod.`prod_order_wo_det_qty`) AS qty, wod.`prod_order_wo_det_price`*SUM(wod.`prod_order_wo_det_qty`) AS po_amount,(py.`dp_amount`/100) * wod.`prod_order_wo_det_price`*SUM(wod.`prod_order_wo_det_qty`) AS dp_amount FROM tb_prod_order_wo_det wod
INNER JOIN tb_prod_order_wo wo ON wo.`id_prod_order_wo`=wod.`id_prod_order_wo`
INNER JOIN tb_m_ovh_price ovhp ON ovhp.id_ovh_price=wo.id_ovh_price
INNER JOIN tb_m_comp_contact cc ON cc.id_comp_contact = ovhp.id_comp_contact
INNER JOIN tb_m_comp c ON c.id_comp=cc.id_comp
INNER JOIN tb_prod_order po ON po.id_prod_order=wo.`id_prod_order` 
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
                id += GVDPFGPO.GetRowCellValue(i, "id_prod_order").ToString
            Next
            Dim query_check As String = ""

            FormInvoiceFGPODP.ShowDialog()
        End If
        GVDPFGPO.ActiveFilterString = ""
    End Sub
End Class