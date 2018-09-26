Public Class FormProdDemandRevSingle
    Private Sub FormProdDemandRevSingle_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        actionLoad()
    End Sub

    Sub viewLineType()
        Dim query As String = "SELECT * FROM tb_lookup_pd_type WHERE id_pd_type<3 ORDER BY id_pd_type ASC "
        viewSearchLookupQuery(SLETypeLineList, query, "id_pd_type", "pd_type", "id_pd_type")
    End Sub

    Sub actionLoad()
        viewLineType()
        Dim query As String = "SELECT  dp.id_prod_demand_design_rev, pdd.id_prod_demand_design, pdd.id_design,d.design_code AS `code`, d.design_display_name AS `name`, po.prod_order_number,
        IFNULL(po.ordered,0) AS `ordered`,
        IFNULL(rec.received,0) AS `received`, 'No' AS `is_select`
        FROM tb_prod_demand_design pdd
        INNER JOIN tb_m_design d ON d.id_design = pdd.id_design
        LEFT JOIN (
	        SELECT po.id_prod_demand_design, po.prod_order_number, SUM(pod.prod_order_qty) AS `ordered`
	        FROM tb_prod_order po 
	        INNER JOIN tb_prod_order_det pod ON pod.id_prod_order = po.id_prod_order
	        WHERE po.id_report_status=6
	        GROUP BY po.id_prod_demand_design
        ) po ON po.id_prod_demand_design = pdd.id_prod_demand_design
        LEFT JOIN (
	        SELECT po.id_prod_demand_design, SUM(rd.prod_order_rec_det_qty) AS `received` 
	        FROM tb_prod_order_rec_det rd
	        INNER JOIN tb_prod_order_rec r ON r.id_prod_order_rec = rd.id_prod_order_rec
	        INNER JOIN tb_prod_order_det pod ON pod.id_prod_order_det = rd.id_prod_order_det
	        INNER JOIN tb_prod_order po ON po.id_prod_order = pod.id_prod_order
	        WHERE r.id_report_status=6
	        GROUP BY po.id_prod_demand_design
        ) rec ON rec.id_prod_demand_design = pdd.id_prod_demand_design
        LEFT JOIN (
	        SELECT rd.id_prod_demand_design, rd.id_prod_demand_design_rev
	        FROM tb_prod_demand_design_rev rd
	        INNER JOIN tb_prod_demand_rev r ON r.id_prod_demand_rev = rd.id_prod_demand_rev
	        WHERE r.id_prod_demand_rev=" + FormProdDemandRevDet.id + "
        ) dp ON dp.id_prod_demand_design = pdd.id_prod_demand_design
        WHERE pdd.id_prod_demand=" + FormProdDemandRevDet.id_prod_demand + " AND ISNULL(dp.id_prod_demand_design_rev) AND pdd.is_void=2 "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCDesign.DataSource = data
        GVDesign.BestFitColumns()
    End Sub

    Private Sub FormProdDemandRevSingle_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub BtnRevise_Click(sender As Object, e As EventArgs) Handles BtnRevise.Click
        ok(False)
    End Sub

    Private Sub BtnDrop_Click(sender As Object, e As EventArgs) Handles BtnDrop.Click
        ok(True)
    End Sub

    Sub ok(ByVal is_drop As Boolean)
        Cursor = Cursors.WaitCursor
        If GVDesign.RowCount > 0 And GVDesign.FocusedRowHandle >= 0 Then
            If GVDesign.GetFocusedRowCellValue("received") > 0 Then
                stopCustom("Can't revise because " + GVDesign.GetFocusedRowCellValue("name").ToString + " already received in QC")
            Else
                If Not is_drop Then
                    'insert detail
                    Dim query_det_new As String = "CALL generate_pd_rev_line_list('" + FormProdDemandRevDet.id + "','" + GVDesign.GetFocusedRowCellValue("id_prod_demand_design").ToString + "', '" + SLETypeLineList.EditValue.ToString + "', '" + GVDesign.GetFocusedRowCellValue("id_design").ToString + "')"
                    execute_non_query(query_det_new, True, "", "", "", "")
                Else
                    'drop - data pake existing pd
                    'insert detail
                    Dim query_det_new As String = "CALL generate_pd_drop_line_list('" + FormProdDemandRevDet.id + "','" + GVDesign.GetFocusedRowCellValue("id_prod_demand_design").ToString + "')"
                    execute_non_query(query_det_new, True, "", "", "", "")
                End If
                FormProdDemandRevDet.viewDetail()
                actionLoad()
            End If
        Else
            stopCustom("No item selected")
        End If
        Cursor = Cursors.Default
    End Sub




End Class