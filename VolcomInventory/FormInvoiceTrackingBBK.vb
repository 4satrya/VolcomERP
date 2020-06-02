Public Class FormInvoiceTrackingBBK
    Public rmt As String = "-1"
    Public id_report As String = "-1"

    Private Sub FormInvoiceTrackingBBK_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Cursor = Cursors.WaitCursor
        Dim query As String = "SELECT r.id_pn AS `id_bbk`, r.date_created, r.date_payment, r.number, r.value, stt.report_status
        FROM tb_pn r
        INNER JOIN tb_pn_det rd ON rd.id_pn=r.id_pn
        INNER JOIN tb_lookup_report_status stt ON stt.id_report_status = r.id_report_status
        WHERE rd.report_mark_type='" + rmt + "' AND rd.id_report=" + id_report + " "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCData.DataSource = data
        GVData.BestFitColumns()
        Cursor = Cursors.Default
    End Sub

    Private Sub FormInvoiceTrackingBBK_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub BtnDiscard_Click(sender As Object, e As EventArgs) Handles BtnDiscard.Click
        Close()
    End Sub

    Private Sub BtnPrint_Click(sender As Object, e As EventArgs) Handles BtnPrint.Click
        Cursor = Cursors.WaitCursor
        print_raw(GCData, "")
        Cursor = Cursors.Default
    End Sub

    Private Sub GVData_DoubleClick(sender As Object, e As EventArgs) Handles GVData.DoubleClick
        If GVData.RowCount > 0 And GVData.FocusedRowHandle >= 0 Then
            Cursor = Cursors.WaitCursor
            Dim bbk As New ClassShowPopUp()
            bbk.report_mark_type = "159"
            bbk.id_report = GVData.GetFocusedRowCellValue("id_bbk").ToString
            bbk.show()
            Cursor = Cursors.Default
        End If
    End Sub
End Class