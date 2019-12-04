Public Class FormProductionFinalClearSummaryPick
    Private Sub FormProductionFinalClearSummaryPick_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        viewSearchLookupQuery(SLUEVendor, "SELECT 0 AS id_comp, 'All Vendor' AS vendor UNION SELECT id_comp, comp_name AS vendor FROM tb_m_comp WHERE id_comp_cat = 1", "id_comp", "vendor", "id_comp")
    End Sub

    Private Sub FormProductionFinalClearSummaryPick_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub SBView_Click(sender As Object, e As EventArgs) Handles SBView.Click
        'vendor
        Dim where_vendor As String = ""

        If Not SLUEVendor.EditValue.ToString = "0" Then
            where_vendor = "AND cc.id_comp = " + SLUEVendor.EditValue.ToString
        End If

        'date
        Dim where_date_from As String = ""

        Try
            If Not DateEditFrom.EditValue.ToString = "" Then
                where_date_from = "AND fc.prod_fc_date >= '" + Date.Parse(DateEditFrom.EditValue.ToString).ToString("yyyy-MM-dd") + "'"
            End If
        Catch ex As Exception
        End Try

        Dim where_date_to As String = ""

        Try
            If Not DateEditTo.EditValue.ToString = "" Then
                where_date_to = "AND fc.prod_fc_date <= '" + Date.Parse(DateEditTo.EditValue.ToString).ToString("yyyy-MM-dd") + "'"
            End If
        Catch ex As Exception
        End Try

        'include id_prod_fc
        Dim where_id_prod_fc As String = "(SELECT sum_det.id_prod_fc FROM tb_prod_fc_sum_det AS sum_det LEFT JOIN tb_prod_fc_sum AS sum ON sum_det.id_prod_fc_sum = sum.id_prod_fc_sum WHERE sum.id_report_status <> 5 AND sum_det.id_prod_fc_sum <> " + FormProductionFinalClearSummary.id_prod_fc_sum + ")"

        For i = 0 To FormProductionFinalClearSummary.GVList.RowCount - 1
            If FormProductionFinalClearSummary.GVList.IsValidRowHandle(i) Then
                where_id_prod_fc += " UNION (SELECT " + FormProductionFinalClearSummary.GVList.GetRowCellValue(i, "id_prod_fc").ToString + " AS id_prod_fc)"
            End If
        Next

        Dim query As String = "
            SELECT 'no' AS is_select, fc.id_prod_fc, comp.comp_name AS vendor, d.design_display_name AS name, fc.prod_fc_number, cat.pl_category, qty_po.qty_po, qty_rec.qty_rec, DATE_FORMAT(fc.prod_fc_date, '%d %b %Y') AS prod_fc_date
            FROM tb_prod_fc AS fc
            LEFT JOIN tb_lookup_pl_category AS cat ON fc.id_pl_category = cat.id_pl_category
            LEFT JOIN tb_prod_order AS po ON fc.id_prod_order = po.id_prod_order
            LEFT JOIN tb_prod_demand_design pdd ON pdd.id_prod_demand_design = po.id_prod_demand_design
            LEFT JOIN tb_m_design d ON d.id_design = pdd.id_design
            LEFT JOIN tb_prod_order_wo AS wo ON wo.id_prod_order = po.id_prod_order AND wo.is_main_vendor = 1
            LEFT JOIN tb_m_ovh_price AS ovh ON ovh.id_ovh_price = wo.id_ovh_price
            LEFT JOIN tb_m_comp_contact AS cc ON cc.id_comp_contact = ovh.id_comp_contact 
            LEFT JOIN tb_m_comp AS comp ON comp.id_comp = cc.id_comp
            LEFT JOIN (
	            SELECT po_det.id_prod_order, SUM(po_det.prod_order_qty) AS qty_po
	            FROM tb_prod_order_det AS po_det
	            LEFT JOIN tb_prod_order AS po ON po_det.id_prod_order = po.id_prod_order
	            WHERE po.id_report_status = 6
	            GROUP BY po_det.id_prod_order
            ) AS qty_po ON po.id_prod_order = qty_po.id_prod_order
            LEFT JOIN (
	            SELECT rec.id_prod_order, SUM(rec_det.prod_order_rec_det_qty) AS qty_rec
	            FROM tb_prod_order_rec_det AS rec_det
	            LEFT JOIN tb_prod_order_rec AS rec ON rec_det.id_prod_order_rec = rec.id_prod_order_rec
	            WHERE rec.id_report_status = 6
	            GROUP BY rec.id_prod_order
            ) AS qty_rec ON po.id_prod_order = qty_rec.id_prod_order
            WHERE fc.id_report_status = 6 AND fc.id_prod_fc NOT IN (SELECT id_prod_fc FROM (" + where_id_prod_fc + ") AS not_include) " + where_vendor + " " + where_date_from + " " + where_date_to + "
        "

        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")

        GCList.DataSource = data

        GVList.BestFitColumns()
    End Sub

    Private Sub SBAdd_Click(sender As Object, e As EventArgs) Handles SBAdd.Click
        GVList.ApplyFindFilter("")

        GVList.ActiveFilterString = "[is_select] = 'yes'"

        If GVList.RowCount <= 0 Then
            errorCustom("No qc report selected")
        Else
            Dim data As DataTable = FormProductionFinalClearSummary.GCList.DataSource

            For i = 0 To GVList.RowCount - 1
                If GVList.IsValidRowHandle(i) Then
                    data.Rows.Add(
                        GVList.GetRowCellValue(i, "id_prod_fc"),
                        0,
                        GVList.GetRowCellValue(i, "vendor"),
                        GVList.GetRowCellValue(i, "name"),
                        GVList.GetRowCellValue(i, "prod_fc_number"),
                        GVList.GetRowCellValue(i, "pl_category"),
                        GVList.GetRowCellValue(i, "qty_po"),
                        GVList.GetRowCellValue(i, "qty_rec"),
                        GVList.GetRowCellValue(i, "prod_fc_date")
                    )
                End If
            Next

            FormProductionFinalClearSummary.GCList.DataSource = data

            FormProductionFinalClearSummary.GVList.BestFitColumns()

            Close()
        End If

        GVList.ActiveFilterString = ""
    End Sub

    Private Sub SBClose_Click(sender As Object, e As EventArgs) Handles SBClose.Click
        Close()
    End Sub
End Class