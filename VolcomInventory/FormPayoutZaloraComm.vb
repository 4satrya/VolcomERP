Public Class FormPayoutZaloraComm
    Public id As String = "-1"
    Public is_view As String = "-1"
    Private Sub FormPayoutZaloraComm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Cursor = Cursors.WaitCursor
        'get commision
        Dim qcom As String = "SELECT SUM(d.erp_amount) AS `amount` 
        FROM tb_payout_zalora_det d
        INNER JOIN tb_payout_zalora_type t ON t.transaction_type = d.transaction_type
        WHERE d.id_payout_zalora=" + id + " AND (t.id_payout_zalora_cat=3 OR t.id_payout_zalora_cat=5)
        GROUP BY d.id_payout_zalora "
        Dim dcom As DataTable = execute_query(qcom, -1, True, "", "", "", "")
        TxtLinkComm.EditValue = dcom.Rows(0)("amount")
        'get detail tax
        Dim query As String = "SELECT m.comm, m.comm_tax FROM tb_payout_zalora m WHERE m.id_payout_zalora=" + id + " "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        TxtComm.EditValue = data.Rows(0)("comm")
        TxtCommTax.EditValue = data.Rows(0)("comm_tax")
        'get total
        getTotal()

        If is_view = "1" Then
            TxtComm.Enabled = False
            TxtCommTax.Enabled = False
            PanelControl1.Visible = False
        End If
        Cursor = Cursors.Default
    End Sub

    Sub getTotal()
        Cursor = Cursors.WaitCursor
        TxtTotalCommInput.EditValue = TxtComm.EditValue + TxtCommTax.EditValue
        Cursor = Cursors.Default
    End Sub


    Private Sub BtnDiscard_Click(sender As Object, e As EventArgs) Handles BtnDiscard.Click
        Close()
    End Sub

    Private Sub FormPayoutZaloraComm_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub BtnConfirm_Click(sender As Object, e As EventArgs) Handles BtnConfirm.Click
        getTotal()
        If TxtLinkComm.EditValue <> TxtTotalCommInput.EditValue Then
            stopCustom("Total commision must be equal with verified commision")
        Else
            Cursor = Cursors.WaitCursor
            Dim query As String = "UPDATE tb_payout_zalora SET comm='" + decimalSQL(TxtComm.EditValue.ToString) + "',comm_tax='" + decimalSQL(TxtCommTax.EditValue.ToString) + "' WHERE id_payout_zalora='" + id + "' "
            execute_non_query(query, True, "", "", "", "")
            FormPayoutZaloraDet.viewERPPayout()
            Cursor = Cursors.Default
            Close()
        End If
    End Sub

    Private Sub TxtComm_EditValueChanged(sender As Object, e As EventArgs) Handles TxtComm.EditValueChanged
        getTotal()
    End Sub

    Private Sub TxtCommTax_EditValueChanged(sender As Object, e As EventArgs) Handles TxtCommTax.EditValueChanged
        getTotal()
    End Sub

    Private Sub TxtLinkComm_Click(sender As Object, e As EventArgs) Handles TxtLinkComm.Click
        FormPayoutZaloraDet.XTCData.SelectedTabPageIndex = 1
        FormPayoutZaloraDet.GVData.ActiveFilterString = "[id_payout_zalora_cat]='3' OR [id_payout_zalora_cat]='5'"
        Close()
    End Sub
End Class