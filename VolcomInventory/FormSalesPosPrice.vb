Public Class FormSalesPosPrice
    Public id_design As String = "-1"
    Public id_pop_up As String = "-1"

    Private Sub BtnCancel_Click(sender As Object, e As EventArgs) Handles BtnCancel.Click
        Close()
    End Sub

    Private Sub FormSalesPosPrice_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub FormSalesPosPrice_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim query As String = "SELECT p.id_design_price, p.design_price, pt.design_price_type 
        FROM tb_m_design_price p 
        INNER JOIN tb_lookup_design_price_type pt ON pt.id_design_price_type = p.id_design_price_type 
        WHERE p.id_design='" + id_design + "' ORDER BY p.id_design_price ASC "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        If data.Rows.Count > 0 Then
            GCPrice.DataSource = data
        Else
            stopCustom("Price not found")
            Close()
        End If
    End Sub

    Sub choose()
        If GVPrice.RowCount > 0 And GVPrice.FocusedRowHandle >= 0 Then
            If id_pop_up = "-1" Then
                FormSalesPOSDet.GVItemList.SetFocusedRowCellValue("design_price_retail", GVPrice.GetFocusedRowCellValue("design_price"))
            ElseIf id_pop_up = "1" Then
                FormSalesPOSNoStockAdd.id_design_price = GVPrice.GetFocusedRowCellValue("id_design_price").ToString
                FormSalesPOSNoStockAdd.TxtPrice.EditValue = GVPrice.GetFocusedRowCellValue("design_price")
            End If
            Close()
        End If
    End Sub

    Private Sub BtnChoose_Click(sender As Object, e As EventArgs) Handles BtnChoose.Click
        choose()
    End Sub

    Private Sub GVPrice_DoubleClick(sender As Object, e As EventArgs) Handles GVPrice.DoubleClick
        choose()
    End Sub
End Class