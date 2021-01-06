Public Class FormPayoutZaloraAddCoa
    Public id_payout_zalora_det As String = "-1"

    Private Sub FormPayoutZaloraAddCoa_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        viewCOA()
        TxtAmount.EditValue = 0.00
    End Sub

    Sub viewCOA()
        Dim query As String = "SELECT a.id_acc, a.acc_name, a.acc_description,CONCAT(a.acc_name,' - ', a.acc_description) AS `acc`, a.id_acc_parent, 
        a.id_acc_parent, a.id_acc_cat, a.id_is_det, a.id_status, a.id_comp
        FROM tb_a_acc a WHERE a.id_status=1 AND a.id_is_det=2 AND a.id_coa_type='1' "
        viewSearchLookupQuery(SLECOA, query, "id_acc", "acc", "id_acc")
    End Sub

    Private Sub BtnDiscard_Click(sender As Object, e As EventArgs) Handles BtnDiscard.Click
        Close()
    End Sub

    Private Sub FormPayoutZaloraAddCoa_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub BtnConfirm_Click(sender As Object, e As EventArgs) Handles BtnConfirm.Click
        Dim confirm As DialogResult = DevExpress.XtraEditors.XtraMessageBox.Show("Are you sure you want to save changes this data?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
        If confirm = Windows.Forms.DialogResult.Yes Then
            Cursor = Cursors.WaitCursor
            Dim query As String = "INSERT INTO tb_payout_zalora_det_addition (id_payout_zalora_det, erp_amount, id_acc) 
            VALUES ('" + id_payout_zalora_det + "', '" + decimalSQL(TxtAmount.EditValue.ToString) + "', '" + SLECOA.EditValue.ToString + "'); SELECT LAST_INSERT_ID(); "
            execute_non_query(query, True, "", "", "", "")
            FormPayoutZaloraManualReconSingle.viewDetail()
            FormPayoutZaloraManualReconSingle.getTotal()
            Cursor = Cursors.Default
            Close()
        End If
    End Sub
End Class