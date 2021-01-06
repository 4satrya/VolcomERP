Public Class FormPayoutZaloraManualRecon
    Public id_payout_zalora_cat As String = "-1"
    Public id As String = "-1"

    Private Sub FormPayoutZaloraManualRecon_Load(sender As Object, e As EventArgs) Handles MyBase.Load
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

    Private Sub BtnConfirm_Click(sender As Object, e As EventArgs) Handles BtnConfirm.Click
        If MEReason.Text = "" Then
            warningCustom("Please fill reason field")
        Else
            Dim confirm As DialogResult = DevExpress.XtraEditors.XtraMessageBox.Show("Are you sure you want to save changes this data?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
            If confirm = Windows.Forms.DialogResult.Yes Then
                Cursor = Cursors.WaitCursor
                Dim manual_recon_reason As String = addSlashes(MEReason.Text)
                Dim id_acc As String = SLECOA.EditValue.ToString
                If Not FormMain.SplashScreenManager1.IsSplashFormVisible Then
                    FormMain.SplashScreenManager1.ShowWaitForm()
                End If
                For i As Integer = 0 To FormPayoutZaloraDet.GVData.RowCount - 1
                    FormMain.SplashScreenManager1.SetWaitFormDescription("Updating " + i.ToString + " of " + FormPayoutZaloraDet.GVData.RowCount.ToString)
                    Dim id_det As String = FormPayoutZaloraDet.GVData.GetRowCellValue(i, "id_payout_zalora_det").ToString
                    Dim erp_amount As String = ""
                    If CEAmountZalora.EditValue = True Then
                        erp_amount = decimalSQL(FormPayoutZaloraDet.GVData.GetRowCellValue(i, "amount").ToString)
                    Else
                        erp_amount = decimalSQL(TxtAmount.EditValue.ToString)
                    End If
                    Dim query As String = "DELETE FROM tb_payout_zalora_det_addition WHERE id_payout_zalora_det='" + id_det + "' ;
                    UPDATE tb_payout_zalora_det 
                    SET erp_amount='" + erp_amount + "', is_manual_recon=1, manual_recon_reason='" + manual_recon_reason + "', id_acc='" + id_acc + "'
                    WHERE id_payout_zalora_det='" + id_det + "'; "
                    execute_non_query(query, True, "", "", "", "")
                Next
                FormMain.SplashScreenManager1.CloseWaitForm()
                FormPayoutZaloraDet.CESelectAll.EditValue = False
                FormPayoutZaloraDet.viewSummary()
                FormPayoutZaloraDet.viewDetailRecon(id_payout_zalora_cat)
                Close()
                Cursor = Cursors.Default
            End If
        End If
    End Sub

    Private Sub BtnDiscard_Click(sender As Object, e As EventArgs) Handles BtnDiscard.Click
        Close()
    End Sub

    Private Sub FormPayoutZaloraManualRecon_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub CEAmountZalora_CheckedChanged(sender As Object, e As EventArgs) Handles CEAmountZalora.CheckedChanged
        If CEAmountZalora.EditValue = True Then
            TxtAmount.EditValue = 0.00
            TxtAmount.Enabled = False
        Else
            TxtAmount.Enabled = True
        End If
    End Sub
End Class