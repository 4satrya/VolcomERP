Public Class FormProductionSpecialRecSingle
    Private Sub SimpleButton2_Click(sender As Object, e As EventArgs) Handles BClose.Click
        Close()
    End Sub

    Private Sub FormProductionSpecialRecSingle_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub BOpenLock_Click(sender As Object, e As EventArgs) Handles BOpenLock.Click
        Dim confirm As DialogResult = DevExpress.XtraEditors.XtraMessageBox.Show("Are you sure want to disable receving tolerance for this PO ?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
        If confirm = DialogResult.Yes Then
            If Not TEMemoNumber.Text = "" Then
                Dim query As String = "UPDATE tb_prod_order SET is_special_rec='1',special_rec_memo='" & TEMemoNumber.Text & "',special_rec_datetime=NOW() WHERE id_prod_order='" & FormProductionSpecialRec.GVProd.GetFocusedRowCellValue("id_prod_order").ToString & "'"
                execute_non_query(query, True, "", "", "", "")
                infoCustom("Receving tolerance disabled")
                Close()
            End If
        End If
    End Sub
End Class