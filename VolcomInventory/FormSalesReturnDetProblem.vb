Public Class FormSalesReturnDetProblem
    Public id_product As String = "-1"
    Public id_design As String = "-1"
    Public id_sales_return_problem As String = "-1"
    Public id_type As String = "-1"

    Private Sub FormSalesReturnDetProblem_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If id_type = "1" Or id_type = "2" Then
            PanelSearch.Visible = False
            ActiveControl = TxtRemark
        Else
            ActiveControl = TxtSearch
        End If
    End Sub

    Private Sub FormSalesReturnDetProblem_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs) Handles SimpleButton1.Click
        If id_product <> "-1" Then
            If id_type = "1" Then
                FormSalesReturnDet.GVBarcodeProb.SetRowCellValue(FormSalesReturnDet.GVBarcodeProb.RowCount - 1, "remark", TxtRemark.Text.ToString)
                Close()
            ElseIf id_type = "2" Then
                FormSalesReturnDet.GVBarcodeProb.SetFocusedRowCellValue("remark", TxtRemark.Text.ToString)
                Close()
            Else
                Dim newRow As DataRow = (TryCast(FormSalesReturnDet.GCBarcodeProb.DataSource, DataTable)).NewRow()
                newRow("id_sales_return_problem") = "0"
                newRow("id_product") = id_product
                newRow("design_code") = TxtCode.Text
                newRow("code") = TxtBarcode.Text
                newRow("name") = TxtDesign.Text
                newRow("size") = TxtSize.Text
                newRow("remark") = TxtRemark.Text
                TryCast(FormSalesReturnDet.GCBarcodeProb.DataSource, DataTable).Rows.Add(newRow)
                FormSalesReturnDet.GCBarcodeProb.RefreshDataSource()
                FormSalesReturnDet.GVBarcodeProb.RefreshData()
                Close()
            End If
        Else
            stopCustom("Please input spesific product !")
        End If
    End Sub

    Private Sub TxtRemark_KeyDown(sender As Object, e As KeyEventArgs) Handles TxtRemark.KeyDown
        If e.KeyCode = Keys.Enter Then
            SimpleButton1.Focus()
        End If
    End Sub

    Private Sub TxtSearch_KeyDown(sender As Object, e As KeyEventArgs) Handles TxtSearch.KeyDown
        If e.KeyCode = Keys.Enter Then
            BtnFind.Focus()
        End If
    End Sub

    Private Sub BtnFind_Click(sender As Object, e As EventArgs) Handles BtnFind.Click
        Cursor = Cursors.WaitCursor
        Dim keyword As String = addSlashes(TxtSearch.Text.ToString)
        Dim query As String = "SELECT p.id_product, d.design_code, p.product_full_code AS `product_code`,p.product_full_code AS `code`,
        d.design_display_name AS `name`, cd.code_detail_name AS `size`, d.is_old_design
        FROM tb_m_product p
        INNER JOIN tb_m_product_code pc ON pc.id_product = p.id_product
        INNER JOIN tb_m_code_detail cd ON cd.id_code_detail = pc.id_code_detail
        INNER JOIN tb_m_design d ON d.id_design = p.id_design AND d.id_active=1
        WHERE p.product_full_code LIKE '%" + keyword + "%' OR d.design_code LIKE '%" + keyword + "%' OR d.design_display_name LIKE '%" + keyword + "%' "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        If data.Rows.Count > 0 Then
            FormSalesReturnSearch.dt = data
            FormSalesReturnSearch.ShowDialog()
            TxtRemark.Focus()
        Else
            stopCustom("Data not found")
            TxtSearch.Text = ""
            TxtSearch.Focus()
        End If
        Cursor = Cursors.Default
    End Sub
End Class