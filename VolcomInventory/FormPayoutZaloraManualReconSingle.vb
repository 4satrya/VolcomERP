﻿Public Class FormPayoutZaloraManualReconSingle
    Public id_payout_zalora_cat As String = "-1"
    Public id As String = "-1"
    Public id_det As String = "-1"

    Private Sub FormPayoutZaloraManualReconSingle_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        viewCOA()
        TxtAmount.EditValue = 0.00
        'default coa
        If id_payout_zalora_cat = "3" Then
            'fee
            Dim id_coa_default_fee As String = execute_query("SELECT id_acc_default_fee_zalora FROM tb_opt_sales ", 0, True, "", "", "", "")
            SLECOA.EditValue = id_coa_default_fee
        End If
    End Sub

    Sub viewCOA()
        Dim query As String = "SELECT a.id_acc, a.acc_name, a.acc_description,CONCAT(a.acc_name,' - ', a.acc_description) AS `acc`, a.id_acc_parent, 
        a.id_acc_parent, a.id_acc_cat, a.id_is_det, a.id_status, a.id_comp
        FROM tb_a_acc a WHERE a.id_status=1 AND a.id_is_det=2 AND a.id_coa_type='1' "
        viewSearchLookupQuery(SLECOA, query, "id_acc", "acc", "id_acc")
    End Sub

    Private Sub FormPayoutZaloraManualReconSingle_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub BtnDiscard_Click(sender As Object, e As EventArgs) Handles BtnDiscard.Click
        Close()
    End Sub
End Class