Public Class FormBankWithdrawalCompen
    Public id_comp As String = "-1"
    '
    Private Sub FormBankWithdrawalCompen_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        load_data()
    End Sub

    Sub load_data()
        Dim q As String = "SELECT c.comp_name,c.comp_number,c.id_comp,pd.`id_sales_pos`,coa.acc_name,coa.acc_description,c.`id_acc_ar`,p.report_mark_type,cc.id_comp,p.`sales_pos_number`,CAST(IF(typ.`is_receive_payment`=2,-1,1) * ((p.`sales_pos_total`*((100-p.sales_pos_discount)/100))-p.`sales_pos_potongan`) AS DECIMAL(15,2)) AS amount
FROM tb_sales_pos_det pd 
INNER JOIN tb_sales_pos p ON p.`id_sales_pos`=pd.`id_sales_pos` 
INNER JOIN tb_lookup_memo_type typ ON typ.`id_memo_type`=p.`id_memo_type`
INNER JOIN tb_m_comp_contact cc ON cc.id_comp_contact=p.id_comp_contact_bill
INNER JOIN tb_m_comp c ON c.id_comp=cc.id_comp
INNER JOIN tb_a_acc coa ON coa.id_acc = p.id_acc_ar
LEFT JOIN
(
    SELECT pnd.`id_report`,pnd.`report_mark_type`,pn.`id_pn`
    FROM tb_pn_det pnd
    INNER JOIN tb_pn pn ON pn.`id_pn`=pnd.`id_pn`
    WHERE pnd.report_mark_type='117' OR pnd.`report_mark_type`='183' 
)pn ON pn.id_report=p.id_sales_pos AND p.report_mark_type=pn.report_mark_type
WHERE ISNULL(pn.id_pn) AND (p.report_mark_type='117' OR p.report_mark_type='183') AND p.is_close_rec_payment='2'
AND p.`id_report_status`=6
AND cc.id_comp='" & id_comp & "'
GROUP BY p.`id_sales_pos`"
        Dim dt As DataTable = execute_query(q, -1, True, "", "", "", "")
        GCPending.DataSource = dt
        GVPending.BestFitColumns()
    End Sub

    Private Sub FormBankWithdrawalCompen_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub BPick_Click(sender As Object, e As EventArgs) Handles BPick.Click
        If GVPending.RowCount > 0 Then
            'check
            Dim already As Boolean = False
            For i As Integer = 0 To FormBankWithdrawalDet.GVList.RowCount - 1
                If FormBankWithdrawalDet.GVList.GetRowCellValue(i, "id_report").ToString = GVPending.GetFocusedRowCellValue("id_sales_pos").ToString And FormBankWithdrawalDet.GVList.GetRowCellValue(i, "report_mark_type").ToString = GVPending.GetFocusedRowCellValue("report_mark_type").ToString Then
                    already = True
                End If
            Next
            If already Then
                warningCustom("This invoice already choosen")
            Else
                Dim newRow As DataRow = (TryCast(FormBankWithdrawalDet.GCList.DataSource, DataTable)).NewRow()
                newRow("id_report") = GVPending.GetFocusedRowCellValue("id_sales_pos").ToString
                newRow("report_mark_type") = GVPending.GetFocusedRowCellValue("report_mark_type").ToString
                newRow("id_acc") = GVPending.GetFocusedRowCellValue("id_acc_ar").ToString
                newRow("acc_name") = GVPending.GetFocusedRowCellValue("acc_name").ToString
                newRow("acc_description") = GVPending.GetFocusedRowCellValue("acc_description").ToString
                newRow("vendor") = GVPending.GetFocusedRowCellValue("comp_name").ToString
                newRow("id_dc") = "2"
                newRow("dc_code") = "K"
                newRow("id_comp") = GVPending.GetFocusedRowCellValue("id_comp").ToString
                newRow("comp_number") = GVPending.GetFocusedRowCellValue("comp_number").ToString
                newRow("number") = GVPending.GetFocusedRowCellValue("sales_pos_number").ToString
                newRow("total_pay") = GVPending.GetFocusedRowCellValue("amount")
                newRow("kurs") = 1
                newRow("id_currency") = "1"
                newRow("currency") = "Rp"
                newRow("val_bef_kurs") = -GVPending.GetFocusedRowCellValue("amount")
                newRow("value") = -GVPending.GetFocusedRowCellValue("amount")
                newRow("value_view") = -GVPending.GetFocusedRowCellValue("amount")
                newRow("balance_due") = -GVPending.GetFocusedRowCellValue("amount")
                newRow("note") = GVPending.GetFocusedRowCellValue("sales_pos_number").ToString
                TryCast(FormBankWithdrawalDet.GCList.DataSource, DataTable).Rows.Add(newRow)
                Close()
            End If
        End If
    End Sub
End Class