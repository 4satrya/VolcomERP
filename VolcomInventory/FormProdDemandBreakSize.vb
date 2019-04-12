Public Class FormProdDemandBreakSize
    Public id_pdd As String = "-1"

    Private Sub FormProdDemandBreakSize_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        viewData()
    End Sub

    Sub viewData()
        Dim query As String = "SELECT p.id_product, cd.code_detail_name AS `size`, p.prod_demand_product_qty AS `qty`
        FROM "
        query += "tb_prod_demand_product p "
        query += "INNER JOIN tb_m_product prod ON prod.id_product = p.id_product
        INNER JOIN tb_m_product_code pc ON pc.id_product = prod.id_product
        INNER JOIN tb_m_code_detail cd ON cd.id_code_detail = pc.id_code_detail
        WHERE "
        query += "p.id_prod_demand_design=" + id_pdd + " "
        query += "ORDER BY cd.id_code_detail ASC "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCData.DataSource = data
        GVData.BestFitColumns()
    End Sub

    Private Sub FormProdDemandBreakSize_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub
End Class