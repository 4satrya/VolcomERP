Public Class FormBankWithdrawalDP
    Public report_mark_type As String = "-1"
    Public id_report As String = "-1"

    Private Sub FormBankWithdrawalDP_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If report_mark_type = "139" Then 'OG
            Dim q As String = "SELECT 'no' AS is_check,acc.acc_name,acc.acc_description,pn.number,pnd.id_comp AS id_comp_tag,ct.comp_number AS comp_number_tag,pnd.`id_pn` AS id_report,c.`id_acc_dp` AS id_acc,c.`comp_number`,c.`comp_name`,SUM(pnd.`value`)-IFNULL(already.value,0) AS amount,pn.`note`
FROM tb_pn_det pnd
INNER JOIN tb_pn pn ON pn.`id_pn`=pnd.`id_pn`
INNER JOIN tb_m_comp_contact cc ON cc.`id_comp_contact`=pn.`id_comp_contact`
INNER JOIN tb_m_comp c ON c.`id_comp`=cc.`id_comp`
INNER JOIN tb_m_comp ct ON ct.id_comp=pnd.id_comp
INNER JOIN tb_a_acc acc ON acc.id_acc=c.id_acc_dp
LEFT JOIN 
(
	SELECT pnd.`id_report`,pnd.`value` FROM tb_pn_det pnd
	INNER JOIN tb_pn pn ON pn.`id_pn`=pnd.`id_pn` AND pn.`id_report_status`!=5
	WHERE pnd.report_mark_type='159'
) already ON already.id_report=pn.`id_pn`
WHERE pn.`id_pay_type`=1 AND pn.`id_report_status`=6 AND pn.report_mark_type='" & report_mark_type & "' AND pnd.`id_report`='" & id_report & "'
GROUP BY pnd.`id_pn`
HAVING amount>0"
            Dim dt As DataTable = execute_query(q, -1, True, "", "", "", "")
            GCList.DataSource = dt
            GVList.BestFitColumns()
        End If
    End Sub

    Private Sub FormBankWithdrawalDP_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub BtnCancel_Click(sender As Object, e As EventArgs) Handles BtnCancel.Click
        Close()
    End Sub

    Private Sub BtnSave_Click(sender As Object, e As EventArgs) Handles BtnSave.Click
        GVList.ActiveFilterString = "[is_check]='yes'"
        If GVList.RowCount > 0 Then
            For i = 0 To GVList.RowCount - 1
                'check
                Dim is_already As Boolean = False
                For j = 0 To FormBankWithdrawalDet.GVList.RowCount - 1
                    If FormBankWithdrawalDet.GVList.GetRowCellValue(i, "id_report").ToString = GVList.GetRowCellValue(i, "id_report").ToString And FormBankWithdrawalDet.GVList.GetRowCellValue(i, "report_mark_type").ToString = "159" Then
                        is_already = True
                        Exit For
                    End If
                Next
                If is_already = False Then
                    Dim newRow_pph As DataRow = (TryCast(FormBankWithdrawalDet.GCList.DataSource, DataTable)).NewRow()
                    newRow_pph("id_report") = GVList.GetRowCellValue(i, "id_report").ToString
                    newRow_pph("report_mark_type") = "159"
                    newRow_pph("id_acc") = GVList.GetRowCellValue(i, "id_acc").ToString
                    newRow_pph("acc_name") = GVList.GetRowCellValue(i, "acc_name").ToString
                    newRow_pph("acc_description") = GVList.GetRowCellValue(i, "acc_description").ToString
                    newRow_pph("vendor") = GVList.GetRowCellValue(i, "comp_number").ToString
                    newRow_pph("id_dc") = "2"
                    newRow_pph("dc_code") = "K"
                    newRow_pph("id_comp") = GVList.GetRowCellValue(i, "id_comp_tag").ToString
                    newRow_pph("comp_number") = GVList.GetRowCellValue(i, "comp_number_tag").ToString
                    newRow_pph("number") = GVList.GetRowCellValue(i, "number").ToString
                    newRow_pph("total_pay") = 0
                    newRow_pph("kurs") = 1
                    newRow_pph("id_currency") = "1"
                    newRow_pph("currency") = "Rp"
                    newRow_pph("val_bef_kurs") = GVList.GetRowCellValue(i, "amount")
                    newRow_pph("value") = -GVList.GetRowCellValue(i, "amount")
                    newRow_pph("value_view") = -GVList.GetRowCellValue(i, "amount")
                    newRow_pph("balance_due") = -GVList.GetRowCellValue(i, "amount")
                    newRow_pph("note") = GVList.GetRowCellValue(i, "note").ToString
                    TryCast(FormBankWithdrawalDet.GCList.DataSource, DataTable).Rows.Add(newRow_pph)
                Else
                    warningCustom("Some DP already listed")
                End If
            Next
            Close()
        Else
            warningCustom("Please select DP first")
        End If
    End Sub
End Class