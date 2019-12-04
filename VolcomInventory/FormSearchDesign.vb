Public Class FormSearchDesign
    Public id_pop_up As String = "-1"

    Private Sub FormSearchDesign_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        TxtCode.Focus()
    End Sub

    Private Sub BtnClose_Click(sender As Object, e As EventArgs) Handles BtnClose.Click
        Close()
    End Sub

    Private Sub FormSearchDesign_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub BtnSearch_Click(sender As Object, e As EventArgs) Handles BtnSearch.Click
        Cursor = Cursors.WaitCursor
        Dim code As String = addSlashes(TxtCode.Text)
        Dim query As String = "SELECT d.id_design, d.design_code AS `code`, d.design_display_name AS `name` 
        FROM tb_m_design d WHERE d.design_code='" + code + "' AND d.id_active=1 "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        If data.Rows.Count > 0 Then
            If id_pop_up = "1" Then
                FormSalesOrderReport.id_design_new_order = data.Rows("0")("id_design").ToString
                FormSalesOrderReport.TxtProduct.Text = data.Rows("0")("code").ToString + " - " + data.Rows("0")("name").ToString
                Close()
            ElseIf id_pop_up = "2" Then
                FormSalesOrderReport.id_design_all_order = data.Rows("0")("id_design").ToString
                FormSalesOrderReport.TxtProductSO.Text = data.Rows("0")("code").ToString + " - " + data.Rows("0")("name").ToString
                Close()
            ElseIf id_pop_up = "3" Then
                FormStockQC.id_dsg = data.Rows("0")("id_design").ToString
                FormStockQC.TxtProduct.Text = data.Rows("0")("code").ToString + " - " + data.Rows("0")("name").ToString
                Close()
            End If
        Else
            stopCustom("Product not found")
            TxtCode.Text = ""
            TxtCode.Focus()
        End If
        Cursor = Cursors.Default
    End Sub
End Class