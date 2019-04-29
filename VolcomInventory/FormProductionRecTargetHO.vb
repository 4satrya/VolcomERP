Public Class FormProductionRecTargetHO
    Public id_rec As String = "-1"
    Private Sub FormProductionRecTargetHO_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim query As String = "SELECT IF(del.delivery_date<r.rec_ho_date,IF(del.delivery_date<r.prod_order_rec_date,r.prod_order_rec_date,del.delivery_date),r.rec_ho_date) AS rec_ho_date,del.delivery_date
		FROM tb_prod_order_rec r 
		INNER JOIN tb_prod_order po ON po.id_prod_order=r.id_prod_order AND po.id_report_status='6'
		INNER JOIN tb_prod_demand_design pdd ON pdd.id_prod_demand_design=po.`id_prod_demand_design`
		INNER JOIN tb_m_design dsg ON dsg.`id_design`=pdd.`id_design` AND (dsg.id_lookup_status_order='1' or dsg.id_lookup_status_order='3')
		INNER JOIN `tb_season_delivery` del ON del.`id_delivery`=dsg.`id_delivery`
        WHERE r.id_prod_order_rec='" & id_rec & "'"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        If data.Rows.Count > 0 Then
            DEBefore.EditValue = data.Rows(0)("rec_ho_date")
            DEAfter.EditValue = data.Rows(0)("rec_ho_date")
            DEAfter.Properties.MaxValue = data.Rows(0)("delivery_date")
        End If
    End Sub

    Private Sub FormProductionRecTargetHO_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub BUpdate_Click(sender As Object, e As EventArgs) Handles BUpdate.Click
        If Not DEAfter.Text = "" Then
            Dim query As String = "UPDATE tb_prod_order_rec SET rec_ho_date='" & Date.Parse(DEAfter.EditValue.ToString).ToString("yyyy-MM-dd") & "' WHERE id_prod_order_rec='" & id_rec & "'"
            execute_non_query(query, True, "", "", "", "")
            Close()
        Else
            stopCustom("Please put estimate handover date")
        End If
    End Sub
End Class