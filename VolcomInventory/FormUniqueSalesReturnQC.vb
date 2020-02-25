Public Class FormUniqueSalesReturnQC
    Public id_sales_return_qc As String = "-1"

    Private Sub FormUniqueSalesReturnQC_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Cursor = Cursors.WaitCursor
        Dim query As String = "
            SELECT 1 AS `#`, CONCAT(cmf.comp_number, ' - ', cmf.comp_name) AS `Return From`, CONCAT(cmt.comp_number, ' - ', cmt.comp_name) AS `Destination`, s.sales_return_qc_number AS `Return Transfer`, CONCAT(c.product_full_code, a.sales_return_qc_det_counting) AS `Unique Code`, c.product_name AS `Description`, cd.code_detail_name AS `Size`, rj.reject_type AS `Reject`
            FROM tb_sales_return_qc_det_counting a 
            INNER JOIN tb_sales_return_qc_det b ON a.id_sales_return_qc_det = b.id_sales_return_qc_det 
            INNER JOIN tb_sales_return_qc s ON b.id_sales_return_qc = s.id_sales_return_qc
            INNER JOIN tb_m_product c ON c.id_product = b.id_product 
            INNER JOIN tb_m_product_code pc ON pc.id_product = c.id_product 
            INNER JOIN tb_m_code_detail cd ON cd.id_code_detail = pc.id_code_detail 
            INNER JOIN tb_m_comp_contact cf ON cf.id_comp_contact = s.id_store_contact_from
            INNER JOIN tb_m_comp cmf ON cmf.id_comp = cf.id_comp
            INNER JOIN tb_m_comp_contact ct ON ct.id_comp_contact = s.id_comp_contact_to
            INNER JOIN tb_m_comp cmt ON cmt.id_comp = ct.id_comp
            LEFT JOIN tb_sales_return_det_counting d0 ON d0.id_sales_return_det_counting = a.id_sales_return_det_counting 
            LEFT JOIN tb_pl_prod_order_rec_det_counting d ON d.id_pl_prod_order_rec_det_unique = d0.id_pl_prod_order_rec_det_unique 
            LEFT JOIN tb_m_reject_type rj ON rj.id_reject_type = a.id_reject_type 
            WHERE b.id_sales_return_qc = '" + id_sales_return_qc + "'
            ORDER BY c.product_full_code ASC, a.sales_return_qc_det_counting ASC
        "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCData.DataSource = data
        GVData.Columns.ColumnByFieldName("#").MaxWidth = 30
        GVData.Columns.ColumnByFieldName("Return From").MaxWidth = 325
        GVData.Columns.ColumnByFieldName("Destination").MaxWidth = 325
        GVData.Columns.ColumnByFieldName("Size").MaxWidth = 50

        'number
        For i = 0 To GVData.RowCount - 1
            GVData.SetRowCellValue(i, "#", i + 1)
        Next

        print(GCData, GVData.GetFocusedRowCellValue("Return Transfer").ToString)
        Close()
        Cursor = Cursors.Default
    End Sub

    Private Sub FormUniqueSalesReturnQC_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub
End Class