Public Class FormProdDemandRevBreakSize
    Public id_pdd_rev As String = "-1"
    Public id_pdd As String = "-1"

    Private Sub FormProdDemandRevBreakSize_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        viewData()
    End Sub

    Sub viewData()
        Dim query As String = "SELECT p.id_product, cd.code_detail_name AS `size`, p.prod_demand_product_qty AS `qty`
        FROM "
        If XTCData.SelectedTabPageIndex = 0 Then
            query += "tb_prod_demand_product_rev p "
        Else
            query += "tb_prod_demand_product p "
        End If
        query += "INNER JOIN tb_m_product prod ON prod.id_product = p.id_product
        INNER JOIN tb_m_product_code pc ON pc.id_product = prod.id_product
        INNER JOIN tb_m_code_detail cd ON cd.id_code_detail = pc.id_code_detail
        WHERE "
        If XTCData.SelectedTabPageIndex = 0 Then
            query += "p.id_prod_demand_design_rev=" + id_pdd_rev + " "
        Else
            query += "p.id_prod_demand_design=" + id_pdd + " "
        End If
        query += "ORDER BY cd.id_code_detail ASC "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        If XTCData.SelectedTabPageIndex = 0 Then
            GCData.DataSource = data
            GVData.BestFitColumns()
        Else
            GCDataOld.DataSource = data
            GVDataOld.BestFitColumns()
        End If
    End Sub

    Private Sub FormProdDemandRevBreakSize_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub XTCData_SelectedPageChanged(sender As Object, e As DevExpress.XtraTab.TabPageChangedEventArgs) Handles XTCData.SelectedPageChanged
        viewData()
    End Sub
End Class