﻿Public Class FormInvoiceTrackingBBM
    Public rmt As String = "-1"
    Public id_report As String = "-1"

    Private Sub FormInvoiceTrackingBBM_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Cursor = Cursors.WaitCursor
        Dim query As String = "SELECT r.id_rec_payment, r.date_created, r.date_received, r.number, r.value, stt.report_status
        FROM tb_rec_payment r
        INNER JOIN tb_rec_payment_det rd ON rd.id_rec_payment=r.id_rec_payment
        INNER JOIN tb_lookup_report_status stt ON stt.id_report_status = r.id_report_status
        WHERE rd.report_mark_type='" + rmt + "' AND rd.id_report=" + id_report + " "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCData.DataSource = data
        GVData.BestFitColumns()
        Cursor = Cursors.Default
    End Sub

    Private Sub FormInvoiceTrackingBBM_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
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
            Dim bbm As New ClassShowPopUp()
            bbm.report_mark_type = "162"
            bbm.id_report = GVData.GetFocusedRowCellValue("id_rec_payment").ToString
            bbm.show()
            Cursor = Cursors.Default
        End If
    End Sub
End Class