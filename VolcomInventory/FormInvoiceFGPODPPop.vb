Public Class FormInvoiceFGPODPPop
    Public id_po As String = "-1"

    Private Sub BtnSave_Click(sender As Object, e As EventArgs) Handles BtnSave.Click
        GVList.ActiveFilterString = "[is_check]='yes'"
        If GVList.RowCount > 0 Then
            For i = 0 To GVList.RowCount - 1
                Try
                    'check
                    Dim is_already As Boolean = False
                    For j = 0 To FormInvoiceFGPODP.GVList.RowCount - 1
                        If FormInvoiceFGPODP.GVList.GetRowCellValue(i, "id_report").ToString = GVList.GetRowCellValue(i, "id_pn_fgpo_det").ToString And FormInvoiceFGPODP.GVList.GetRowCellValue(i, "report_mark_type").ToString = "199" Then
                            is_already = True
                            Exit For
                        End If
                    Next
                    If is_already = False Then
                        If FormInvoiceFGPODP.doc_type = "2" Then
                            Dim newRow As DataRow = (TryCast(FormInvoiceFGPODP.GCList.DataSource, DataTable)).NewRow()
                            newRow("id_prod_order") = id_po
                            newRow("id_acc") = GVList.GetRowCellValue(i, "id_acc").ToString
                            newRow("id_report") = GVList.GetRowCellValue(i, "id_pn_fgpo").ToString
                            newRow("report_mark_type") = "199"
                            newRow("report_number") = GVList.GetRowCellValue(i, "number").ToString
                            newRow("info_design") = GVList.GetRowCellValue(i, "design_display_name").ToString
                            newRow("qty") = GVList.GetRowCellValue(i, "qty")
                            '
                            newRow("id_currency") = GVList.GetRowCellValue(i, "id_currency").ToString
                            newRow("kurs") = Decimal.Parse(GVList.GetRowCellValue(i, "kurs").ToString)
                            newRow("value_bef_kurs") = GVList.GetRowCellValue(i, "value_bef_kurs") * -1
                            '
                            newRow("pph_percent") = 0
                            newRow("vat") = GVList.GetRowCellValue(i, "vat") * -1
                            newRow("inv_number") = GVList.GetRowCellValue(i, "inv_number").ToString
                            newRow("note") = GVList.GetRowCellValue(i, "note").ToString
                            TryCast(FormInvoiceFGPODP.GCList.DataSource, DataTable).Rows.Add(newRow)
                        Else
                            Dim newRow As DataRow = (TryCast(FormInvoiceFGPODP.GCList.DataSource, DataTable)).NewRow()
                            newRow("id_prod_order") = "0"
                            newRow("id_acc") = GVList.GetRowCellValue(i, "id_acc").ToString
                            newRow("id_report") = GVList.GetRowCellValue(i, "id_pn_fgpo").ToString
                            newRow("report_mark_type") = "199"
                            newRow("report_number") = GVList.GetRowCellValue(i, "number").ToString
                            newRow("info_design") = ""
                            newRow("qty") = GVList.GetRowCellValue(i, "qty")
                            '
                            newRow("id_currency") = GVList.GetRowCellValue(i, "id_currency").ToString
                            newRow("kurs") = Decimal.Parse(GVList.GetRowCellValue(i, "kurs").ToString)
                            newRow("value_bef_kurs") = GVList.GetRowCellValue(i, "value_bef_kurs") * -1
                            '
                            newRow("pph_percent") = 0
                            newRow("vat") = GVList.GetRowCellValue(i, "vat") * -1
                            newRow("inv_number") = GVList.GetRowCellValue(i, "inv_number").ToString
                            newRow("note") = GVList.GetRowCellValue(i, "note").ToString
                            TryCast(FormInvoiceFGPODP.GCList.DataSource, DataTable).Rows.Add(newRow)
                        End If
                    End If
                Catch ex As Exception
                    warningCustom(ex.ToString)
                End Try
            Next
            FormInvoiceFGPODP.calculate()
            Close()
        Else
            warningCustom("Please select DP first")
        End If
        GVList.ActiveFilterString = ""
    End Sub

    Private Sub FormInvoiceFGPODPPop_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub BtnCancel_Click(sender As Object, e As EventArgs) Handles BtnCancel.Click
        Close()
    End Sub

    Private Sub FormInvoiceFGPODPPop_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        load_dp()
    End Sub

    Sub load_dp()
        Dim query As String = ""
        If FormInvoiceFGPODP.doc_type = "2" Then
            query = "SELECT 'no' AS is_check, pnd.id_pn_fgpo_det,pnd.qty, pn.`id_pn_fgpo`,pn.`number`,pnd.id_currency,cur.currency,pnd.kurs,pnd.`value_bef_kurs`,pnd.`vat`,pnd.`inv_number`,pnd.`note` 
,dsg.`design_code`,dsg.`design_display_name`, wo.id_comp,wo.comp_name, wo.id_acc_dp AS id_acc
FROM `tb_pn_fgpo_det` pnd
INNER JOIN tb_pn_fgpo pn ON pn.`id_pn_fgpo`=pnd.`id_pn_fgpo`
INNER JOIN tb_prod_order po ON po.`id_prod_order`=pnd.`id_report` AND pnd.`report_mark_type`='22'
INNER JOIN tb_lookup_currency cur ON cur.id_currency=pnd.id_currency
LEFT JOIN 
(
    SELECT c.`comp_name`,c.id_comp,wo.id_prod_order,c.id_acc_dp
    FROM tb_prod_order_wo wo
    INNER JOIN tb_m_ovh_price ovhp ON ovhp.id_ovh_price=wo.id_ovh_price
    INNER JOIN tb_m_comp_contact cc ON cc.id_comp_contact=ovhp.id_comp_contact
    INNER JOIN tb_m_comp c ON c.`id_comp`=cc.id_comp
    WHERE wo.id_prod_order='" & id_po & "' AND wo.is_main_vendor=1
)wo ON wo.id_prod_order=po.id_prod_order
LEFT JOIN
(
    SELECT id_report FROM `tb_pn_fgpo_det` pnd
    INNER JOIN tb_pn_fgpo pn ON pn.`id_pn_fgpo`=pnd.`id_pn_fgpo`
    WHERE pnd.`report_mark_type`='199' AND pn.id_report_status!=5 AND pnd.id_prod_order='" & id_po & "'
)used ON used.id_report=pnd.id_pn_fgpo
INNER JOIN `tb_prod_demand_design` pdd ON pdd.`id_prod_demand_design`=po.`id_prod_demand_design`
INNER JOIN tb_m_design dsg ON dsg.`id_design`=pdd.`id_design`
WHERE pn.`id_report_status`= '6' AND pnd.`id_report`='" & id_po & "' AND pnd.report_mark_type='22' AND pn.`type`='1' AND ISNULL(used.id_report) AND pn.doc_type='2'"
        Else
            query = "SELECT 'no' AS is_check, pnd.id_pn_fgpo_det,pnd.qty, pn.`id_pn_fgpo`,pn.`number`,pnd.id_currency,cur.currency,pnd.kurs,pnd.`value_bef_kurs`,pnd.`vat`,pnd.`inv_number`,pnd.`note` 
, pn.id_comp,com.comp_name, com.id_acc_dp AS id_acc
FROM `tb_pn_fgpo_det` pnd
INNER JOIN tb_pn_fgpo pn ON pnd.id_pn_fgpo=pn.id_pn_fgpo
INNER JOIN tb_m_comp com ON com.`id_comp`=pn.`id_comp`
INNER JOIN tb_lookup_currency cur ON cur.id_currency=pnd.id_currency
LEFT JOIN
(
    SELECT id_report FROM `tb_pn_fgpo_det` pnd
    INNER JOIN tb_pn_fgpo pn ON pn.`id_pn_fgpo`=pnd.`id_pn_fgpo`
    WHERE pnd.`report_mark_type`='199' AND pn.id_report_status!=5 AND pn.id_comp='" & FormInvoiceFGPODP.SLEVendor.EditValue.ToString & "'
)used ON used.id_report=pnd.id_pn_fgpo
WHERE pn.`id_report_status`= '6' AND pn.id_comp='" & FormInvoiceFGPODP.SLEVendor.EditValue.ToString & "' AND pnd.report_mark_type!='199' AND pn.`type`='1' AND ISNULL(used.id_report) AND pn.doc_type!='2'"
        End If
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCList.DataSource = data
    End Sub
End Class