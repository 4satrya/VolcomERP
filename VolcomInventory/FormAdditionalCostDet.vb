Public Class FormAdditionalCostDet
    Public id_pps As String = "-1"

    Private Sub FormAdditionalCostDet_Load(sender As Object, e As EventArgs) Handles MyBase.Load

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

            End If
        Next
    End Sub

    Private Sub BDel_Click(sender As Object, e As EventArgs) Handles BDel.Click

    End Sub

    Private Sub BAdd_Click(sender As Object, e As EventArgs) Handles BAdd.Click

    End Sub
End Class