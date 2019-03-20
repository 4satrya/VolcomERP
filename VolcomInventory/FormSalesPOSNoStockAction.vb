Public Class FormSalesPOSNoStockAction
    Public where_string As String = ""

    Private Sub BtnCancel_Click(sender As Object, e As EventArgs) Handles BtnCancel.Click
        Close()
    End Sub

    Private Sub SimpleButton2_Click(sender As Object, e As EventArgs) Handles BtnVerify.Click
        Dim note As String = addSlashes(MENote.Text)
        If note = "" Then
            warningCustom("All fields are required")
        Else
            Dim confirm As DialogResult = DevExpress.XtraEditors.XtraMessageBox.Show("Are you sure you want to verified these data?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
            If confirm = Windows.Forms.DialogResult.Yes Then
                'query upd 
                Dim query_upd As String = "UPDATE tb_sales_pos_no_stock_det nsd SET nsd.is_verified=1, nsd.verified_note='" + note + "', verified_date=NOW(), verified_by='" + id_user + "' WHERE 1=1 AND (" + where_string + ") "
                execute_non_query(query_upd, True, "", "", "", "")

                'refresh
                makeSafeGV(FormSalesPOSNoStock.GVDetail)
                FormSalesPOSNoStock.viewDetail()
                Close()
            End If
        End If
    End Sub

    Private Sub FormSalesPOSNoStockAction_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub FormSalesPOSNoStockAction_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        MENote.Focus()
    End Sub
End Class