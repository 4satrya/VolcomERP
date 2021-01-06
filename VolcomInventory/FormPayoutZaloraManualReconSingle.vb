Public Class FormPayoutZaloraManualReconSingle
    Public id_payout_zalora_cat As String = "-1"
    Public id As String = "-1"
    Public id_det As String = "-1"

    Private Sub FormPayoutZaloraManualReconSingle_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Cursor = Cursors.WaitCursor
        viewCOA()
        TxtAmount.EditValue = 0.00
        'default coa
        If id_payout_zalora_cat = "3" Or id_payout_zalora_cat = "5" Then
            'fee
            Dim id_coa_default_fee As String = execute_query("SELECT id_acc_default_fee_zalora FROM tb_opt_sales ", 0, True, "", "", "", "")
            SLECOA.EditValue = id_coa_default_fee
        End If

        'view data
        Dim query As String = "SELECT d.id_payout_zalora_det, d.erp_amount, IFNULL(d.id_acc,0) AS `id_acc`, d.manual_recon_reason
FROM tb_payout_zalora_det d WHERE d.id_payout_zalora_det=" + id_det + " "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        TxtAmount.EditValue = data.Rows(0)("erp_amount")
        Dim id_acc As String = data.Rows(0)("id_acc").ToString
        If id_acc <> "0" Then
            SLECOA.EditValue = id_acc
        End If
        MEReason.Text = data.Rows(0)("manual_recon_reason").ToString
        viewDetail()
        getTotal()

        'check jika ada referensi khusus sales rev 
        If id_payout_zalora_cat = "2" And FormPayoutZaloraDet.GVData.GetFocusedRowCellValue("id_sales_pos_det") <> "0" Then
            TxtAmount.Enabled = False
        End If
        'check jika ada referensi khusus refund
        If id_payout_zalora_cat = "4" And FormPayoutZaloraDet.GVData.GetFocusedRowCellValue("id_sales_pos_cn_det") <> "0" Then
            TxtAmount.Enabled = False
        End If
        Cursor = Cursors.Default
    End Sub

    Sub viewDetail()
        Cursor = Cursors.WaitCursor
        'view detail
        Dim qd As String = "SELECT d.id_payout_zalora_det_addition, d.id_payout_zalora_det, d.erp_amount, 
d.id_acc, coa.acc_name, coa.acc_description
FROM tb_payout_zalora_det_addition d 
INNER JOIN tb_a_acc coa ON coa.id_acc = d.id_acc
WHERE d.id_payout_zalora_det=" + id_det + " "
        Dim dd As DataTable = execute_query(qd, -1, True, "", "", "", "")
        GCData.DataSource = dd
        GVData.BestFitColumns()
        Cursor = Cursors.Default
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

    Private Sub BtnDelete_Click(sender As Object, e As EventArgs) Handles BtnDelete.Click
        If GVData.RowCount > 0 And GVData.FocusedRowHandle >= 0 Then
            Dim confirm As DialogResult = DevExpress.XtraEditors.XtraMessageBox.Show("Are you sure you want to delete this row?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
            If confirm = Windows.Forms.DialogResult.Yes Then
                Dim query As String = "DELETE FROM tb_payout_zalora_det_addition WHERE id_payout_zalora_det_addition='" + GVData.GetFocusedRowCellValue("id_payout_zalora_det_addition").ToString + "' "
                execute_non_query(query, True, "", "", "", "")
                viewDetail()
                getTotal()
            End If
        End If
    End Sub

    Private Sub BtnAdd_Click(sender As Object, e As EventArgs) Handles BtnAdd.Click
        Cursor = Cursors.WaitCursor
        FormPayoutZaloraAddCoa.id_payout_zalora_det = id_det
        FormPayoutZaloraAddCoa.ShowDialog()
        Cursor = Cursors.Default
    End Sub

    Sub getTotal()
        Dim main_amount As Decimal = 0.00
        Try
            main_amount = TxtAmount.EditValue
        Catch ex As Exception
        End Try
        Dim add_amount As Decimal = 0.00
        Try
            add_amount = GVData.Columns("erp_amount").SummaryItem.SummaryValue
        Catch ex As Exception
        End Try
        TxtTotal.EditValue = main_amount + add_amount
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
                Dim erp_amount As String = decimalSQL(TxtAmount.EditValue.ToString)
                Dim query As String = "UPDATE tb_payout_zalora_det 
                SET erp_amount='" + erp_amount + "', is_manual_recon=1, manual_recon_reason='" + manual_recon_reason + "', id_acc='" + id_acc + "'
                WHERE id_payout_zalora_det='" + id_det + "'; "
                execute_non_query(query, True, "", "", "", "")
                FormPayoutZaloraDet.CESelectAll.EditValue = False
                FormPayoutZaloraDet.viewSummary()
                FormPayoutZaloraDet.viewDetailRecon(id_payout_zalora_cat)
                Close()
                Cursor = Cursors.Default
            End If
        End If
    End Sub

    Private Sub TxtAmount_EditValueChanged(sender As Object, e As EventArgs) Handles TxtAmount.EditValueChanged
        getTotal()
    End Sub
End Class