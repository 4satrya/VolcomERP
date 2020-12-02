Public Class FormTrackingReturnClosingReason
    Private Sub FormTrackingReturnClosingReason_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub SBSave_Click(sender As Object, e As EventArgs) Handles SBSave.Click
        If Not MERemark.Text = "" Then
            For i = 0 To FormTrackingReturn.GVList.RowCount - 1
                If FormTrackingReturn.GVList.IsValidRowHandle(i) Then
                    Dim query As String = ""
                    If Not FormTrackingReturn.GVList.GetRowCellValue(i, "id_wh_awb_det").ToString = "0" Then
                        query = "UPDATE tb_wh_awbill_det_in SET is_active = 2, updated_date = NOW(), updated_by = " + id_user + ", remark = '" + addSlashes(MERemark.EditValue.ToString) + "' WHERE id_wh_awb_det = " + FormTrackingReturn.GVList.GetRowCellValue(i, "id_wh_awb_det").ToString
                        execute_non_query(query, True, "", "", "", "")
                    ElseIf Not FormTrackingReturn.GVList.GetRowCellValue(i, "id_return_note").ToString = "0" Then
                        query = "UPDATE tb_return_note SET is_active = 2, update_date = NOW(), update_by = " + id_user + ", remark = '" + addSlashes(MERemark.EditValue.ToString) + "' WHERE id_return_note = " + FormTrackingReturn.GVList.GetRowCellValue(i, "id_return_note").ToString
                        execute_non_query(query, True, "", "", "", "")
                    End If
                End If
            Next

            infoCustom("Status updated.")

            Close()

            FormTrackingReturn.load_form()
        Else
            stopCustom("Please fill remark.")
        End If
    End Sub

    Private Sub SBCancel_Click(sender As Object, e As EventArgs) Handles SBCancel.Click
        Close()
    End Sub

    Private Sub FormTrackingReturnClosingReason_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub
End Class