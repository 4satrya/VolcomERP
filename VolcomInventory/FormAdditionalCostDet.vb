Public Class FormAdditionalCostDet
    Public id_pps As String = "-1"
    Public id_type As String = "1" '1 = est , 2 = realization

    Private Sub FormAdditionalCostDet_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        load_det_cost()
    End Sub

    Sub load_det_cost()
        Dim q As String = ""

        If id_type = "1" Then
            q = "SELECT description,qty_est AS qty,value_est AS `value`
FROM `tb_additional_cost_pps_det` 
WHERE id_additional_cost_pps='" & id_pps & "'"
        Else
            q = "SELECT description,qty AS qty,value AS `value`
FROM `tb_additional_cost_pps_det` 
WHERE id_additional_cost_pps='" & id_pps & "'"
        End If

        Dim dt As DataTable = execute_query(q, -1, True, "", "", "", "")
        GCCostList.DataSource = dt
        check_button()
    End Sub

    Sub check_button()
        If GVCostList.RowCount > 0 Then
            BDel.Visible = True
        Else
            BDel.Visible = False
        End If
    End Sub

    Private Sub BPickArticle_Click(sender As Object, e As EventArgs) Handles BPickArticle.Click
        Dim ok As Boolean = True

        If GVDesignList.RowCount > 0 Then
            Dim confirm As DialogResult = DevExpress.XtraEditors.XtraMessageBox.Show("Reset cost breakdown and reload design list ?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
            If confirm = Windows.Forms.DialogResult.Yes Then
                ok = True
            Else
                ok = False
            End If
        End If

        If ok Then
            Dim q As String = "SELECT dsg.id_design,pdd.id_prod_demand_design,dsg.`design_code`,dsg.`design_display_name`,dsg.prod_order_cop_pd,SUM(pdp.`prod_demand_product_qty`) AS qty
,0 AS qty_sampling
FROM tb_m_design dsg 
INNER JOIN tb_prod_demand_design pdd ON pdd.`id_prod_demand_design`=dsg.id_prod_demand_design_line
INNER JOIN `tb_prod_demand_product` pdp ON pdp.id_prod_demand_design=pdd.id_prod_demand_design
WHERE dsg.`id_design` IN 
(
	SELECT acn.`id_design`
	FROM `tb_additional_cost_need` acn
	INNER JOIN tb_m_design dsg ON dsg.`id_design`=acn.`id_design`
	LEFT JOIN `tb_additional_cost_pps_design` ppsd ON ppsd.`id_design`=dsg.`id_design`
	LEFT JOIN tb_additional_cost_pps pps ON pps.id_additional_cost_pps=ppsd.id_additional_cost_pps AND pps.`id_report_status`!=5
	WHERE ISNULL(pps.`id_additional_cost_pps`)
)
GROUP BY pdd.`id_prod_demand_design`"
            Dim dt As DataTable = execute_query(q, -1, True, "", "", "", "")
            GCDesignList.DataSource = dt
            GVDesignList.BestFitColumns()
            '
            For j = GVCostList.RowCount - 1 To 0 Step -1
                GVCostList.DeleteRow(j)
            Next
            '

        End If
    End Sub

    Private Sub BtnCancel_Click(sender As Object, e As EventArgs) Handles BtnCancel.Click
        Close()
    End Sub

    Private Sub FormAdditionalCostDet_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub BCalculateSampleCOP_Click(sender As Object, e As EventArgs) Handles BCalculateSampleCOP.Click
        For i = 0 To GVDesignList.RowCount - 1
            If GVDesignList.GetRowCellValue(i, "qty_sampling") > 0 Then
                Dim newRow As DataRow = (TryCast(GCCostList.DataSource, DataTable)).NewRow()
                newRow("description") = GVDesignList.GetRowCellValue(i, "design_display_name").ToString
                newRow("qty") = GVDesignList.GetRowCellValue(i, "qty_sampling")
                newRow("value") = GVDesignList.GetRowCellValue(i, "prod_order_cop_pd")
                TryCast(GCCostList.DataSource, DataTable).Rows.Add(newRow)
            End If
        Next
        check_button()
    End Sub

    Private Sub BDel_Click(sender As Object, e As EventArgs) Handles BDel.Click
        If GVCostList.RowCount > 0 Then
            GVCostList.DeleteSelectedRows()
            check_button()
        End If
    End Sub

    Private Sub BAdd_Click(sender As Object, e As EventArgs) Handles BAdd.Click
        Dim newRow As DataRow = (TryCast(GCCostList.DataSource, DataTable)).NewRow()
        newRow("description") = ""
        newRow("qty") = 1
        newRow("value") = 0
        TryCast(GCCostList.DataSource, DataTable).Rows.Add(newRow)
        check_button()
    End Sub

    Private Sub TECostPerUnit_EditValueChanged(sender As Object, e As EventArgs) Handles TECostPerUnit.EditValueChanged

    End Sub
End Class