Public Class FormUniqueCode
    Private Sub FormUniqueCode_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        viewWH()
    End Sub

    Sub viewWH()
        Cursor = Cursors.WaitCursor
        Dim query As String = ""
        query += "SELECT e.id_comp, e.comp_number, e.comp_name, CONCAT_WS(' - ', e.comp_number, e.comp_name) AS comp_name_label 
        FROM tb_m_comp e "
        viewSearchLookupQuery(SLEAccount, query, "id_comp", "comp_name_label", "id_comp")
        Cursor = Cursors.Default
    End Sub

    Private Sub FormUniqueCode_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub BtnPrint_Click(sender As Object, e As EventArgs) Handles BtnPrint.Click
        Cursor = Cursors.WaitCursor
        print_raw(GCData, "")
        Cursor = Cursors.Default
    End Sub

    Sub viewData()
        Cursor = Cursors.WaitCursor
        Dim id_comp As String = SLEAccount.EditValue.ToString
        Dim query As String = "SELECT c.id_product, c.unique_code,p.product_full_code AS `barcode`, p.product_name AS `name`, cd.code_detail_name AS `size`,
        SUM(c.qty) AS `qty_unique` 
        FROM tb_m_unique_code c 
        INNER JOIN tb_m_product p ON p.id_product = c.id_product
        INNER JOIN tb_m_product_code pc ON pc.id_product = p.id_product
        INNER JOIN tb_m_code_detail cd ON cd.id_code_detail = pc.id_code_detail
        WHERE c.id_comp=" + id_comp + "
        GROUP BY c.unique_code
        HAVING qty_unique>0 "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCData.DataSource = data
        GVData.BestFitColumns()
        Cursor = Cursors.Default
    End Sub

    Private Sub BtnView_Click(sender As Object, e As EventArgs) Handles BtnView.Click
        viewData()
    End Sub

    Private Sub SLEAccount_EditValueChanged(sender As Object, e As EventArgs) Handles SLEAccount.EditValueChanged
        GCData.DataSource = Nothing
    End Sub
End Class