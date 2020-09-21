Public Class FormPurcOrderCloseReceivingList
    Private Sub FormPurcOrderCloseReceivingList_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim in_id As String = "0, "

        For i = 0 To FormPurcOrderCloseReceiving.GVPO.RowCount - 1
            in_id = FormPurcOrderCloseReceiving.GVPO.GetRowCellValue(i, "id_purc_order").ToString + ", "
        Next

        Dim query_where As String = ""

        If FormPurcOrderCloseReceiving.change_type = "close" Then
            query_where = "AND po.is_close_rec = 2 AND IFNULL(rec_report.rec_report_submit, 0) = 0 AND po.id_purc_order NOT IN (SELECT x1.id_purc_order FROM tb_purc_order_close_det x1 LEFT JOIN tb_purc_order_close x2 ON x1.id_close_receiving = x2.id_close_receiving WHERE x2.id_report_status <> 5)"
        ElseIf FormPurcOrderCloseReceiving.change_type = "move" Then
            query_where = "AND rec.qty IS NULL AND po.id_purc_order NOT IN (SELECT x1.id_purc_order FROM tb_purc_order_move_date_det x1 LEFT JOIN tb_purc_order_move_date x2 ON x1.id_receive_date = x2.id_receive_date WHERE x2.id_report_status <> 5)"
        End If

        GCPO.DataSource = execute_query("
            SELECT po.est_date_receive, po.id_purc_order, c.comp_number, c.comp_name, po.purc_order_number, (SUM(pod.qty * (pod.value - pod.discount)) - po.disc_value + po.vat_value) AS total_po, IF(ISNULL(rec.id_purc_order_det), 0, SUM(rec.qty * (pod.value - pod.discount)) - (SUM(rec.qty * (pod.value - pod.discount)) / SUM(pod.qty * (pod.value - pod.discount)) * po.disc_value) + (SUM(rec.qty * (pod.value - pod.discount)) / SUM(pod.qty * (pod.value - pod.discount)) * po.vat_value)) AS total_rec, SUM(pod.qty) AS po_qty, IFNULL(SUM(rec.qty), 0) AS rec_qty, (IFNULL(SUM(rec.qty * pod.value), 0) / SUM(pod.qty * pod.value)) * 100 AS rec_progress, IF(po.is_close_rec = 1, 'Closed', IF((IFNULL(SUM(rec.qty), 0) / SUM(pod.qty)) <= 0, 'Waiting', IF((IFNULL(SUM(rec.qty), 0) / SUM(pod.qty)) < 1, 'Partial', 'Complete'))) AS rec_status, '' AS close_rec_reason, '' AS to_est_date_receive
            FROM tb_purc_order po
            INNER JOIN tb_purc_order_det pod ON pod.`id_purc_order` = po.`id_purc_order`
            INNER JOIN tb_m_user usr_cre ON usr_cre.id_user = po.created_by
            INNER JOIN tb_m_employee emp_cre ON emp_cre.id_employee = usr_cre.id_employee
            INNER JOIN tb_m_comp_contact cc ON cc.id_comp_contact = po.id_comp_contact
            INNER JOIN tb_m_comp c ON c.id_comp = cc.id_comp
            LEFT JOIN 
            ( 
                SELECT recd.`id_purc_order_det`, SUM(recd.`qty`) AS qty 
                FROM tb_purc_rec_det recd 
                INNER JOIN tb_purc_rec rec ON rec.`id_purc_rec` = recd.`id_purc_rec` AND rec.`id_report_status` = '6'
                GROUP BY recd.`id_purc_order_det`
            ) rec ON rec.id_purc_order_det = pod.`id_purc_order_det`
            LEFT JOIN
            (
                SELECT id_purc_order, IFNULL(SUM(IF(id_report_status NOT IN (5, 6), 1, 0)), 0) AS rec_report_submit
                FROM tb_purc_rec
                GROUP BY id_purc_order
            ) rec_report ON po.id_purc_order = rec_report.id_purc_order
            WHERE po.id_purc_order NOT IN (" + in_id.Substring(0, in_id.Length - 2) + ") AND po.id_report_status = 6 " + query_where + "
            GROUP BY po.id_purc_order 
            ORDER BY po.id_purc_order DESC
        ", -1, True, "", "", "", "")

        GVPO.BestFitColumns()
    End Sub

    Private Sub FormPurcOrderCloseReceivingList_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub GVPO_DoubleClick(sender As Object, e As EventArgs) Handles GVPO.DoubleClick
        Dim data As DataTable = FormPurcOrderCloseReceiving.GCPO.DataSource

        Dim n_row As DataRow = data.NewRow

        n_row("est_date_receive") = GVPO.GetFocusedRowCellValue("est_date_receive").ToString
        n_row("id_purc_order") = GVPO.GetFocusedRowCellValue("id_purc_order").ToString
        n_row("comp_number") = GVPO.GetFocusedRowCellValue("comp_number").ToString
        n_row("comp_name") = GVPO.GetFocusedRowCellValue("comp_name").ToString
        n_row("purc_order_number") = GVPO.GetFocusedRowCellValue("purc_order_number").ToString
        n_row("total_po") = GVPO.GetFocusedRowCellValue("total_po").ToString
        n_row("total_rec") = GVPO.GetFocusedRowCellValue("total_rec").ToString
        n_row("rec_progress") = GVPO.GetFocusedRowCellValue("rec_progress").ToString
        n_row("rec_status") = GVPO.GetFocusedRowCellValue("rec_status").ToString
        n_row("po_qty") = GVPO.GetFocusedRowCellValue("po_qty").ToString
        n_row("rec_qty") = GVPO.GetFocusedRowCellValue("rec_qty").ToString
        n_row("close_rec_reason") = ""
        n_row("to_est_date_receive") = DBNull.Value

        data.Rows.Add(n_row)

        FormPurcOrderCloseReceiving.GCPO.DataSource = data

        FormPurcOrderCloseReceiving.GVPO.BestFitColumns()

        Close()
    End Sub
End Class