﻿Public Class FormPayoutZaloraComm
    Public id As String = "-1"
    Public is_view As String = "-1"
    Private Sub FormPayoutZaloraComm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Cursor = Cursors.WaitCursor
        'get commision
        Dim qcom As String = "SELECT SUM(d.erp_amount)+SUM(IFNULL(a.erp_amount,0)) AS `amount` 
        FROM tb_payout_zalora_det d
        INNER JOIN tb_payout_zalora_type t ON t.transaction_type = d.transaction_type
        LEFT JOIN tb_payout_zalora_det_addition a ON a.id_payout_zalora_det = d.id_payout_zalora_det
        WHERE d.id_payout_zalora=" + id + " AND (t.id_payout_zalora_cat=3 OR t.id_payout_zalora_cat=5)
        GROUP BY d.id_payout_zalora "
        Dim dcom As DataTable = execute_query(qcom, -1, True, "", "", "", "")
        TxtLinkComm.EditValue = dcom.Rows(0)("amount")
        'get comm with referemce
        Dim qr As String = "SELECT SUM(a.erp_amount) AS `comm_reff_amo` 
        FROM tb_payout_zalora_det_addition a
        INNER JOIN tb_payout_zalora_det d ON d.id_payout_zalora_det = a.id_payout_zalora_det
        WHERE d.id_payout_zalora='" + id + "'
        GROUP BY d.id_payout_zalora "
        Dim dr As DataTable = execute_query(qr, -1, True, "", "", "", "")
        If dr.Rows.Count > 0 Then
            TxtCommReff.EditValue = dr.Rows(0)("comm_reff_amo")
        Else
            TxtCommReff.EditValue = 0.00
        End If
        'get other expense
        Dim id_acc_default_comm As String = get_opt_sales_field("id_acc_default_fee_zalora")
        Dim qex As String = "SELECT SUM(a.erp_amount) AS `erp_amount`
        FROM (
	        SELECT d.id_payout_zalora, d.erp_amount
	        FROM tb_payout_zalora_det d 
	        INNER JOIN tb_payout_zalora_type t ON t.transaction_type = d.transaction_type
	        WHERE d.id_payout_zalora='" + id + "' AND (t.id_payout_zalora_cat=3 OR t.id_payout_zalora_cat=5) AND d.id_acc<>'" + id_acc_default_comm + "'
	        UNION ALL
	        SELECT d.id_payout_zalora, a.erp_amount
	        FROM tb_payout_zalora_det_addition a
	        INNER JOIN tb_payout_zalora_det d ON d.id_payout_zalora_det = a.id_payout_zalora_det
	        INNER JOIN tb_payout_zalora_type t ON t.transaction_type = d.transaction_type
	        WHERE d.id_payout_zalora='" + id + "' AND (t.id_payout_zalora_cat=3 OR t.id_payout_zalora_cat=5) AND a.id_acc<>'" + id_acc_default_comm + "' AND a.is_use_ref=2
        ) a
        GROUP BY a.id_payout_zalora "
        Dim dex As DataTable = execute_query(qex, -1, True, "", "", "", "")
        If dex.Rows.Count > 0 Then
            TxtOtherExpense.EditValue = dex.Rows(0)("erp_amount")
        Else
            TxtOtherExpense.EditValue = 0.00
        End If
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
        TxtTotalCommInput.EditValue = TxtCommReff.EditValue + TxtOtherExpense.EditValue + TxtComm.EditValue + TxtCommTax.EditValue
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