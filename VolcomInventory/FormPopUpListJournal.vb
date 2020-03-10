Public Class FormPopUpListJournal
    Public id_ref As String = "-1"
    Public id_pop_up As String = "-1"
    Public title_for_print As String = "-1"
    Private Sub FormPopUpListJournal_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub FormPopUpListJournal_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If id_pop_up = "1" Then 'popup BPL BBK OG
            Dim q As String = "SELECT a.`id_acc_trans`,a.`date_created`,a.`acc_trans_number`,SUM(ad.`debit`) AS debit, SUM(ad.`credit`) AS credit FROM tb_a_acc_trans_det ad
INNER JOIN tb_a_acc_trans a ON a.`id_acc_trans`=ad.`id_acc_trans`
WHERE (ad.report_mark_type_ref='139' OR ad.report_mark_type='202') AND ad.id_report_ref='" & id_ref & "'
GROUP BY a.id_acc_trans"
            Dim dt As DataTable = execute_query(q, -1, True, "", "", "", "")
            GCList.DataSource = dt
            GVList.BestFitColumns()
        End If
    End Sub

    Private Sub VDItemList_Click(sender As Object, e As EventArgs) Handles VDItemList.Click
        If GVList.RowCount > 0 Then
            FormViewJournal.id_trans = GVList.GetFocusedRowCellValue("id_acc_trans").ToString
            FormViewJournal.ShowDialog()
        End If
    End Sub

    Private Sub BPrint_Click(sender As Object, e As EventArgs) Handles BPrint.Click
        print(GCList, title_for_print)
    End Sub
End Class