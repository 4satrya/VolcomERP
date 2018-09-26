Public Class FormPopUpPD
    Public id_pop_up As String = "-1"
    Private Sub FormPopUpPD_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        viewProdDemand()
    End Sub
    'View Production Demand
    Sub viewProdDemand()
        Dim query As String = "SELECT pd_dsg.id_prod_demand_design, pd_dsg.id_prod_demand, pd.prod_demand_number, pd_dsg.id_design, "
        query += " pd_dsg.prod_demand_design_propose_price, pd_dsg.prod_demand_design_total_cost, pd_dsg.msrp, b.*,c.*"
        query += " FROM  tb_prod_demand_design pd_dsg"
        query += " INNER JOIN tb_prod_demand pd ON pd.id_prod_demand = pd_dsg.id_prod_demand"
        query += " LEFT JOIN tb_prod_demand_product pd_prd ON pd_prd.id_prod_demand_design = pd_dsg.id_prod_demand_design "
        query += " INNER JOIN tb_season b ON pd.id_season = b.id_season "
        query += " INNER JOIN tb_lookup_report_status c ON c.id_report_status = pd.id_report_status "
        query += " WHERE pd.id_report_status = '6' AND pd.is_pd='1' AND pd_dsg.is_void='2' "
        query += " GROUP BY pd_dsg.id_prod_demand"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCProdDemand.DataSource = data
        GVProdDemand.Columns("season").GroupIndex = 0
        If data.Rows.Count > 0 Then
            GVProdDemand.FocusedRowHandle = 0
            view_product()
        End If
    End Sub

    Private Sub GVProdDemand_FocusedRowChanged(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles GVProdDemand.FocusedRowChanged
        Dim focusedRowHandle As Integer = -1
        If e.FocusedRowHandle = DevExpress.XtraGrid.GridControl.NewItemRowHandle OrElse e.FocusedRowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            Return
        End If
        Dim view As DevExpress.XtraGrid.Views.Grid.GridView = CType(sender, DevExpress.XtraGrid.Views.Grid.GridView)
        If e.FocusedRowHandle < 0 Then
            If e.PrevFocusedRowHandle = DevExpress.XtraGrid.GridControl.InvalidRowHandle Then
                focusedRowHandle = 0
            ElseIf Control.MouseButtons = MouseButtons.Left OrElse Control.MouseButtons = MouseButtons.Right Then
                focusedRowHandle = e.PrevFocusedRowHandle
            Else
                Dim prevRow As Integer = view.GetVisibleIndex(e.PrevFocusedRowHandle)
                Dim currRow As Integer = view.GetVisibleIndex(e.FocusedRowHandle)
                If prevRow > currRow Then
                    focusedRowHandle = e.PrevFocusedRowHandle - 1
                Else
                    focusedRowHandle = e.PrevFocusedRowHandle + 1
                End If
                If focusedRowHandle < 0 Then
                    focusedRowHandle = 0
                End If
                If focusedRowHandle >= view.DataRowCount Then
                    focusedRowHandle = view.DataRowCount - 1
                End If
            End If
            If focusedRowHandle < 0 Then
                view.FocusedRowHandle = 0
            Else
                view.FocusedRowHandle = focusedRowHandle
            End If
        End If
    End Sub

    Sub view_product()
        Try
            Dim id_prod_demand As String = GVProdDemand.GetFocusedRowCellDisplayText("id_prod_demand").ToString
            Dim query As String = "CALL view_prod_demand('" & id_prod_demand & "', 0)"
            Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
            GCProduct.DataSource = data
            If data.Rows.Count > 0 Then
                GVProduct.ClearGrouping()
                GVProduct.Columns("category").GroupIndex = 0
                GVProduct.Columns("design_name").GroupIndex = 1
                GVProduct.ExpandAllGroups()
                BChoose.Enabled = True
            Else
                BChoose.Enabled = False
            End If
            '
        Catch ex As Exception
            errorConnection()
        End Try
    End Sub

    Private Sub BCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BCancel.Click
        Close()
    End Sub

    Private Sub FormPopUpPD_FormClosed(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub GVProdDemand_RowClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Grid.RowClickEventArgs) Handles GVProdDemand.RowClick
        If GVProdDemand.RowCount > 0 Then
            view_product()
        End If
    End Sub

    Private Sub BChoose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BChoose.Click
        If id_pop_up = "1" Then 'formproductiondet
            If Not FormProductionDet.id_prod_demand = GVProdDemand.GetFocusedRowCellValue("id_prod_demand").ToString Then
                FormProductionDet.id_prod_demand_design = "-1"
                FormProductionDet.TEDesign.Text = ""
                FormProductionDet.TEDesignCode.Text = ""
                FormProductionDet.TEUSCOde.Text = ""
                FormProductionDet.id_delivery = "-1"
                FormProductionDet.TEDelivery.Text = ""
                FormProductionDet.TESeason.Text = ""
                FormProductionDet.TERange.Text = ""
                FormProductionDet.view_prod_demand_product()
            End If

            FormProductionDet.id_prod_demand = GVProdDemand.GetFocusedRowCellValue("id_prod_demand").ToString
            FormProductionDet.TEPDNo.Text = GVProdDemand.GetFocusedRowCellValue("prod_demand_number").ToString
            FormProductionDet.BPickDesign.Enabled = True
            Close()
        End If
    End Sub
End Class