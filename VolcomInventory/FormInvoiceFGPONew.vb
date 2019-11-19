﻿Public Class FormInvoiceFGPONew
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
        Dim query As String = "SELECT po.`id_prod_order`,po.`prod_order_number`,dsg.`design_display_name`,dsg.`design_code`
FROM tb_prod_order_rec_det recd 
INNER JOIN tb_prod_order_rec rec ON rec.`id_prod_order_rec`=recd.`id_prod_order_rec` AND rec.`id_report_status`=6
INNER JOIN tb_prod_order_det pod ON pod.`id_prod_order_det`=recd.`id_prod_order_det`
INNER JOIN tb_prod_order po ON po.`id_prod_order`=pod.`id_prod_order`
INNER JOIN tb_prod_demand_design pdd ON pdd.`id_prod_demand_design`=po.`id_prod_demand_design`
INNER JOIN tb_m_design dsg ON dsg.`id_design`=pdd.`id_design`
WHERE po.`id_report_status`='6'
GROUP BY po.`id_prod_order`"
        viewSearchLookupQuery(SLEFGPO, query, "id_prod_order", "design_display_name", "id_prod_order")
    End Sub

    Private Sub BtnSave_Click(sender As Object, e As EventArgs) Handles BtnSave.Click
        If SLETypeInvoice.EditValue.ToString = "2" Then 'payment
            'search qty order dikurangi sudah payment
            Dim query As String = ""
        ElseIf SLETypeInvoice.EditValue.ToString = "3" Then 'Extra

        ElseIf SLETypeInvoice.EditValue.ToString = "4" Then 'over memo

        End If
    End Sub

    Private Sub FormInvoiceFGPONew_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        view_type()
        view_fgpo()
    End Sub
End Class