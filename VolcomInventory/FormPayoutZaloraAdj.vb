Public Class FormPayoutZaloraAdj
    Public id_payout As String = "-1"
    Public id_adj As String = "-1"
    Public is_view As String = "-1"

    Sub viewCOA()
        Dim query As String = "SELECT a.id_acc, a.acc_name, a.acc_description,CONCAT(a.acc_name,' - ', a.acc_description) AS `acc`, a.id_acc_parent, 
        a.id_acc_parent, a.id_acc_cat, a.id_is_det, a.id_status, a.id_comp
        FROM tb_a_acc a WHERE a.id_status=1 AND a.id_is_det=2 AND a.id_coa_type='1' "
        viewSearchLookupQuery(SLECOA, query, "id_acc", "acc", "id_acc")
    End Sub

    Private Sub FormPayoutZaloraAdj_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        viewCOA()
        actionLoad()
    End Sub

    Sub actionLoad()
        Cursor = Cursors.WaitCursor
        If id_adj = "-1" Then
            MENote.Text = ""
            TxtAmount.EditValue = 0.00
            TxtRef.Text = ""
            MENote.Focus()
        Else
            Dim query As String = "SELECT a.id_payout_zalora_det_adj, a.id_payout_zalora, a.id_acc, a.adj_value, a.note, a.report_number
            FROM tb_payout_zalora_det_adj a
            WHERE a.id_payout_zalora_det_adj=" + id_adj + " "
            Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
            MENote.Text = data.Rows(0)("note").ToString
            SLECOA.EditValue = data.Rows(0)("id_acc").ToString
            TxtAmount.EditValue = data.Rows(0)("adj_value")
            TxtRef.Text = data.Rows(0)("report_number")

            If is_view = "1" Then
                MENote.Enabled = False
                SLECOA.Enabled = False
                TxtAmount.Enabled = False
                TxtRef.Enabled = False
                PanelControl1.Visible = False
            End If
        End If
        Cursor = Cursors.Default
    End Sub

    Private Sub FormPayoutZaloraAdj_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub BtnDiscard_Click(sender As Object, e As EventArgs) Handles BtnDiscard.Click
        Close()
    End Sub

    Private Sub BtnConfirm_Click(sender As Object, e As EventArgs) Handles BtnConfirm.Click
        Dim id_payout_zalora As String = id_payout
        Dim id_acc As String = SLECOA.EditValue.ToString
        Dim adj_value As String = decimalSQL(TxtAmount.EditValue.ToString)
        Dim note As String = addSlashes(MENote.Text)
        Dim report_number As String = addSlashes(TxtRef.Text)

        If id_adj = "-1" Then
            'insert
            Dim query As String = "INSERT INTO tb_payout_zalora_det_adj(id_payout_zalora, id_acc, adj_value, note, report_number)
            VALUES('" + id_payout_zalora + "', '" + id_acc + "', '" + adj_value + "', '" + note + "', '" + report_number + "'); "
            execute_non_query(query, True, "", "", "", "")
            FormPayoutZaloraDet.viewERPPayout()
            id_adj = "-1"
            actionLoad()
        Else
            'update
            Dim query As String = "UPDATE tb_payout_zalora_det_adj SET  
            id_payout_zalora='" + id_payout_zalora + "',
            id_acc = '" + id_acc + "', adj_value='" + adj_value + "',
            note='" + note + "', report_number='" + report_number + "'
            WHERE id_payout_zalora_det_adj='" + id_adj + "' "
            execute_non_query(query, True, "", "", "", "")
            FormPayoutZaloraDet.viewERPPayout()
            Close()
        End If
    End Sub
End Class