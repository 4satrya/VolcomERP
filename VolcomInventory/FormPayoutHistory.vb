Public Class FormPayoutHistory
    Private Sub FormPayoutHistory_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        viewData()
    End Sub

    Private Sub FormPayoutHistory_Deactivate(sender As Object, e As EventArgs) Handles MyBase.Deactivate

    End Sub

    Sub viewData()
        Cursor = Cursors.WaitCursor
        Dim query As String = "SELECT t.id_list_payout_trans, t.number, SUM(p.payment) AS `amount`, SUM(p.trans_fee) AS `trans_fee`, SUM(p.payment)-SUM(p.trans_fee) AS `nett`, b.number AS `bbm_number`, IFNULL(bap.jum_bap,0) AS `jum_bap`
        FROM tb_list_payout_trans t
        INNER JOIN tb_list_payout p ON p.id_list_payout_trans = t.id_list_payout_trans
        LEFT JOIN tb_rec_payment b ON b.id_list_payout_trans = t.id_list_payout_trans AND b.id_report_status!=5
        LEFT JOIN (
            SELECT d.id_list_payout_trans,COUNT(d.id_list_payout_trans) AS `jum_bap`
            FROM tb_list_payout_det d WHERE !ISNULL(d.id_list_payout_ver)
            GROUP BY d.id_list_payout_trans
        ) bap ON bap.id_list_payout_trans = t.id_list_payout_trans
        GROUP BY p.id_list_payout_trans "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCPayout.DataSource = data
        GVPayout.BestFitColumns()
        Cursor = Cursors.Default
    End Sub

    Private Sub BtnPrint_Click(sender As Object, e As EventArgs) Handles BtnPrint.Click
        Cursor = Cursors.WaitCursor
        print(GCPayout, "Payout List")
        Cursor = Cursors.Default
    End Sub

    Private Sub GVPayout_DoubleClick(sender As Object, e As EventArgs) Handles GVPayout.DoubleClick
        If GVPayout.RowCount > 0 And GVPayout.FocusedRowHandle >= 0 Then
            Cursor = Cursors.WaitCursor
            FormPayoutHistoryDetail.id = GVPayout.GetFocusedRowCellValue("id_list_payout_trans").ToString
            FormPayoutHistoryDetail.ShowDialog()
            Cursor = Cursors.Default
        End If
    End Sub

    Private Sub FormPayoutHistory_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub GVPayout_RowStyle(sender As Object, e As DevExpress.XtraGrid.Views.Grid.RowStyleEventArgs) Handles GVPayout.RowStyle
        If GVPayout.GetRowCellValue(e.RowHandle, "jum_bap") > 0 Then
            e.Appearance.BackColor = Color.Yellow
        Else
            e.Appearance.BackColor = Color.Empty
        End If
    End Sub
End Class