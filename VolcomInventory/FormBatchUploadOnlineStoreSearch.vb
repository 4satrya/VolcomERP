Public Class FormBatchUploadOnlineStoreSearch
    Private Sub FormBatchUploadOnlineStoreSearch_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim where_season As String = ""

        Try
            where_season = If(FormBatchUploadOnlineStore.SLUESeason.EditValue.ToString = "0", "", " AND d.id_season = " + FormBatchUploadOnlineStore.SLUESeason.EditValue.ToString)
        Catch ex As Exception
        End Try

        Dim where_division As String = ""

        Try
            where_division = If(FormBatchUploadOnlineStore.SLUEDivision.EditValue.ToString = "0", "", " AND c.id_code_detail = " + FormBatchUploadOnlineStore.SLUEDivision.EditValue.ToString)
        Catch ex As Exception
        End Try

        Dim data As DataTable = execute_query("
            SELECT 'no' AS is_checked, p.id_product, p.product_full_code, p.product_display_name, s.display_name AS size
            FROM tb_m_product AS p
            LEFT JOIN tb_m_design AS d ON p.id_design = d.id_design
            LEFT JOIN (
	            SELECT c.id_design, c.id_code_detail
	            FROM tb_m_design_code AS c
	            LEFT JOIN tb_m_code_detail AS d ON c.id_code_detail = d.id_code_detail
	            WHERE d.id_code = 32
            ) AS c ON c.id_design = p.id_design
            LEFT JOIN (
			    SELECT c.id_product, d.display_name
			    FROM tb_m_product_code AS c
			    LEFT JOIN tb_m_code_detail AS d ON c.id_code_detail = d.id_code_detail
            ) AS s ON p.id_product = s.id_product
            WHERE d.id_lookup_status_order <> 2 " + where_season + " " + where_division + "
            ORDER BY p.product_full_code ASC
        ", -1, True, "", "", "", "")

        GCProduct.DataSource = data

        GVProduct.BestFitColumns()
    End Sub

    Private Sub SBSelect_Click(sender As Object, e As EventArgs) Handles SBSelect.Click
        GVProduct.ActiveFilterString = "is_checked = 'yes'"

        FormBatchUploadOnlineStore.TEProductCode.EditValue = ""

        Dim out As String = ""

        For i = 0 To GVProduct.RowCount - 1
            out += GVProduct.GetRowCellValue(i, "product_full_code").ToString + ", "
        Next

        If out <> "" Then
            FormBatchUploadOnlineStore.TEProductCode.EditValue = out.Substring(0, out.Length - 2)
        End If

        Close()
    End Sub

    Private Sub FormBatchUploadOnlineStoreSearch_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub
End Class