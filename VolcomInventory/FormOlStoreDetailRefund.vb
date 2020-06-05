Public Class FormOlStoreDetailRefund
    Public id As String = "-1"

    Private Sub FormOlStoreDetailRefund_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Cursor = Cursors.WaitCursor
        Dim query As String = "SELECT r.id_ol_store_ret_req, r.sales_order_ol_shop_number AS `order_number`, r.number AS `request_number`, 
        r.rek_no, r.rek_name, r.rek_bank, r.rek_branch
        FROM tb_ol_store_ret_req r 
        WHERE r.id_ol_store_ret_req=" + id + " "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        TxtRequestNo.Text = data.Rows(0)("request_number").ToString
        TxtOrderNumber.Text = data.Rows(0)("order_number").ToString
        TxtNoRek.Text = data.Rows(0)("rek_no").ToString
        TxtNameRek.Text = data.Rows(0)("rek_name").ToString
        TxtBank.Text = data.Rows(0)("rek_bank").ToString
        TxtBranch.Text = data.Rows(0)("rek_branch").ToString
        Cursor = Cursors.Default
    End Sub

    Private Sub BtnCancel_Click(sender As Object, e As EventArgs) Handles BtnCancel.Click
        Close()
    End Sub

    Private Sub FormOlStoreDetailRefund_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub BtnSave_Click(sender As Object, e As EventArgs) Handles BtnSave.Click
        Dim rek_no As String = addSlashes(TxtNoRek.Text)
        Dim rek_name As String = addSlashes(TxtNameRek.Text)
        Dim rek_bank As String = addSlashes(TxtBank.Text)
        Dim rek_branch As String = addSlashes(TxtBranch.Text)
        If rek_no = "" Or rek_name = "" Or rek_bank = "" Or rek_branch = "" Then
            stopCustom("Please complete all data")
        Else
            Cursor = Cursors.WaitCursor
            Dim query As String = "UPDATE tb_ol_store_ret_req SET 
            rek_no = '" + rek_no + "',
            rek_name ='" + rek_name + "',
            rek_bank = '" + rek_bank + "',
            rek_branch = '" + rek_branch + "'
            WHERE id_ol_store_ret_req='" + id + "' "
            execute_non_query(query, True, "", "", "", "")
            FormOlStoreReturnList.view_list()
            Close()
            Cursor = Cursors.Default
        End If
    End Sub
End Class