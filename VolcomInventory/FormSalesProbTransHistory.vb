Public Class FormSalesProbTransHistory
    Public id_sales_pos_prob As String = "-1"
    Private Sub FormSalesProbTransHistory_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If id_sales_pos_prob <> "-1" Then
            viewPriceRecon()
            viewInvoice()
        End If
    End Sub

    Private Sub FormSalesProbTransHistory_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Sub viewPriceRecon()
        Cursor = Cursors.WaitCursor
        Dim cond_det As String = ""
        If id_sales_pos_prob <> "-1" Then
            cond_det = "AND rd.id_sales_pos_prob='" + id_sales_pos_prob + "' "
        End If
        Dim query As String = "SELECT r.id_sales_pos_recon, r.number, r.created_date, r.note, r.id_report_status, stt.report_status, r.is_confirm
        FROM tb_sales_pos_recon r
        INNER JOIN tb_sales_pos_recon_det rd ON rd.id_sales_pos_recon = r.id_sales_pos_recon
        INNER JOIN tb_lookup_report_status stt ON stt.id_report_status = r.id_report_status
        WHERE r.id_sales_pos_recon>0 " + cond_det + "
        GROUP BY r.id_sales_pos_recon
        ORDER BY r.id_sales_pos_recon DESC "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCPriceRecon.DataSource = data
        GVPriceRecon.BestFitColumns()
        Cursor = Cursors.Default
    End Sub

    Private Sub GVPriceRecon_DoubleClick(sender As Object, e As EventArgs) Handles GVPriceRecon.DoubleClick
        If GVPriceRecon.RowCount > 0 And GVPriceRecon.FocusedRowHandle >= 0 Then
            Cursor = Cursors.WaitCursor
            FormSalesPosPriceRecon.action = "upd"
            FormSalesPosPriceRecon.id = GVPriceRecon.GetFocusedRowCellValue("id_sales_pos_recon").ToString
            FormSalesPosPriceRecon.ShowDialog()
            Cursor = Cursors.Default
        End If
    End Sub

    Private Sub BtnViewPriceRecon_Click(sender As Object, e As EventArgs) Handles BtnViewPriceRecon.Click
        viewPriceRecon()
    End Sub

    Private Sub BtnViewInv_Click(sender As Object, e As EventArgs) Handles BtnViewInv.Click
        viewInvoice()
    End Sub

    Sub viewInvoice()
        Cursor = Cursors.WaitCursor
        Dim cond_det_price As String = ""
        If id_sales_pos_prob <> "-1" Then
            cond_det_price = "AND spd.id_sales_pos_prob_price='" + id_sales_pos_prob + "' "
        End If
        Dim cond_det As String = ""
        If id_sales_pos_prob <> "-1" Then
            cond_det = "AND spd.id_sales_pos_prob='" + id_sales_pos_prob + "' "
        End If
        Dim query As String = "SELECT sp.id_sales_pos, sp.sales_pos_number, sp.sales_pos_date,sp.sales_pos_start_period, sp.sales_pos_end_period, 
c.id_comp, c.comp_number, c.comp_name, CONCAT(c.comp_number,' - ', c.comp_name) AS `comp`, cg.comp_group,
sp.id_report_status, stt.report_status, 'Price Reconcile' AS `ref_type`, sp.report_mark_type, rmt.report_mark_type_name AS `inv_type`
FROM tb_sales_pos_det spd
INNER JOIN tb_sales_pos sp ON sp.id_sales_pos = spd.id_sales_pos
INNER JOIN tb_lookup_report_status stt ON stt.id_report_status = sp.id_report_status
INNER JOIN tb_m_comp_contact cc ON cc.`id_comp_contact`= IF(sp.id_memo_type=8 OR sp.id_memo_type=9, sp.id_comp_contact_bill,sp.`id_store_contact_from`)
INNER JOIN tb_lookup_report_mark_type rmt ON rmt.report_mark_type=sp.report_mark_type
INNER JOIN tb_m_comp c ON c.`id_comp`=cc.`id_comp`
INNER JOIN tb_m_comp_group cg ON cg.id_comp_group = c.id_comp_group
WHERE 1=1 AND !ISNULL(spd.id_sales_pos_prob_price) " + cond_det_price + "
GROUP BY sp.id_sales_pos
UNION ALL
SELECT sp.id_sales_pos, sp.sales_pos_number, sp.sales_pos_date,sp.sales_pos_start_period, sp.sales_pos_end_period, 
c.id_comp, c.comp_number, c.comp_name, CONCAT(c.comp_number,' - ', c.comp_name) AS `comp`, cg.comp_group,
sp.id_report_status, stt.report_status, 'No Stock' AS `ref_type`, sp.report_mark_type, rmt.report_mark_type_name AS `inv_type`
FROM tb_sales_pos_det spd
INNER JOIN tb_sales_pos sp ON sp.id_sales_pos = spd.id_sales_pos
INNER JOIN tb_lookup_report_status stt ON stt.id_report_status = sp.id_report_status
INNER JOIN tb_m_comp_contact cc ON cc.`id_comp_contact`= IF(sp.id_memo_type=8 OR sp.id_memo_type=9, sp.id_comp_contact_bill,sp.`id_store_contact_from`)
INNER JOIN tb_lookup_report_mark_type rmt ON rmt.report_mark_type=sp.report_mark_type
INNER JOIN tb_m_comp c ON c.`id_comp`=cc.`id_comp`
INNER JOIN tb_m_comp_group cg ON cg.id_comp_group = c.id_comp_group
WHERE 1=1 AND !ISNULL(spd.id_sales_pos_prob) " + cond_det + "
GROUP BY sp.id_sales_pos
ORDER BY id_sales_pos DESC "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCInv.DataSource = data
        GVInv.BestFitColumns()
        Cursor = Cursors.Default
    End Sub

    Private Sub GVInv_DoubleClick(sender As Object, e As EventArgs) Handles GVInv.DoubleClick
        If GVInv.RowCount > 0 And GVInv.FocusedRowHandle >= 0 Then
            Dim m As New ClassShowPopUp
            m.id_report = GVInv.GetFocusedRowCellValue("id_sales_pos").ToString
            m.report_mark_type = GVInv.GetFocusedRowCellValue("report_mark_type").ToString
            m.show()
        End If
    End Sub

    Private Sub BtnPrint_Click(sender As Object, e As EventArgs) Handles BtnPrint.Click
        Cursor = Cursors.WaitCursor
        print(GCPriceRecon, "Price Reconcile List")
        Cursor = Cursors.Default
    End Sub

    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs) Handles BtnPrintInvoice.Click
        Cursor = Cursors.WaitCursor
        print(GCInv, "Invoice List")
        Cursor = Cursors.Default
    End Sub
End Class