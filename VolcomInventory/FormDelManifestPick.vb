Public Class FormDelManifestPick
    Public is_block_del_store As String = get_setup_field("is_block_del_store")

    Private Sub FormDelManifestPick_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        view_comp()

        DateEditCreatedDateFrom.EditValue = Now
        DateEditCreatedDateTo.EditValue = Now
    End Sub

    Private Sub FormDelManifestPick_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Sub view_comp()
        Dim query As String = "
            SELECT cg.id_comp_group, CONCAT(cg.comp_group, ' - ', cg.description) AS comp_group
            FROM tb_m_comp AS c
            LEFT JOIN tb_m_comp_group AS cg ON c.id_comp_group = cg.id_comp_group
            WHERE c.id_comp_cat = 6
            GROUP BY c.id_comp_group
        "

        viewSearchLookupQuery(SLUECompanyGroup, query, "id_comp_group", "comp_group", "id_comp_group")
    End Sub

    Private Sub SBView_Click(sender As Object, e As EventArgs) Handles SBView.Click
        Cursor = Cursors.WaitCursor

        'chek invoice
        Dim del As New ClassSalesDelOrder()

        If is_block_del_store = "1" And del.checkUnpaidInvoice(SLUECompanyGroup.EditValue.ToString) Then
            stopCustom("Hold delivery")

            Cursor = Cursors.Default

            Exit Sub
        End If

        Dim query_where As String = "AND c.id_comp_group = " + SLUECompanyGroup.EditValue.ToString + " AND DATE(a.awbill_date) BETWEEN '" + Date.Parse(DateEditCreatedDateFrom.EditValue.ToString).ToString("yyyy-MM-dd") + "' AND '" + Date.Parse(DateEditCreatedDateTo.EditValue.ToString).ToString("yyyy-MM-dd") + "'"

        'not in
        Dim query_in As String = "0, "

        For i = 0 To FormDelManifestDet.GVList.RowCount - 1
            If FormDelManifestDet.GVList.IsValidRowHandle(i) Then
                query_in += FormDelManifestDet.GVList.GetRowCellValue(i, "id_wh_awb_det").ToString + ", "
            End If
        Next

        query_in = query_in.Substring(0, query_in.Length - 2)

        Dim query As String = "
            SELECT *
            FROM (
                SELECT 'no' AS is_select, adet.id_wh_awb_det, c.id_comp_group, a.awbill_date, a.id_awbill, IFNULL(pdelc.combine_number, adet.do_no) AS combine_number, adet.do_no, pdel.pl_sales_order_del_number, c.comp_number, c.comp_name, adet.qty, ct.city, a.weight, a.width, a.length, a.height, ((a.width * a.length * a.height) / 6000) AS volume, a.c_weight
                FROM tb_wh_awbill_det AS adet
                LEFT JOIN tb_wh_awbill AS a ON adet.id_awbill = a.id_awbill
                LEFT JOIN tb_m_comp AS c ON a.id_store = c.id_comp
                LEFT JOIN tb_m_city AS ct ON c.id_city = ct.id_city
                LEFT JOIN tb_pl_sales_order_del AS pdel ON adet.id_pl_sales_order_del = pdel.id_pl_sales_order_del
                LEFT JOIN tb_pl_sales_order_del_combine AS pdelc ON pdel.id_combine = pdelc.id_combine
                WHERE a.id_cargo = " + FormDelManifestDet.SLUE3PL.EditValue.ToString + " AND adet.id_wh_awb_det NOT IN (SELECT x.id_wh_awb_det FROM tb_del_manifest_det AS x LEFT JOIN tb_del_manifest AS y ON x.id_del_manifest = y.id_del_manifest WHERE y.id_report_status <> 5 AND x.id_del_manifest <> " + FormDelManifestDet.id_del_manifest + ") AND adet.id_wh_awb_det NOT IN (" + query_in + ") " + query_where + "
            ) AS tb
            ORDER BY tb.comp_number ASC, tb.id_awbill ASC, tb.combine_number ASC
        "

        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")

        GCList.DataSource = data

        GVList.BestFitColumns()

        Cursor = Cursors.Default
    End Sub

    Private Sub SBAdd_Click(sender As Object, e As EventArgs) Handles SBAdd.Click
        Dim data As DataTable = FormDelManifestDet.GCList.DataSource

        GVList.ActiveFilterString = "[is_select] = 'yes'"

        For i = 0 To GVList.RowCount - 1
            If GVList.IsValidRowHandle(i) Then
                data.Rows.Add(
                    0,
                    GVList.GetRowCellValue(i, "id_wh_awb_det"),
                    GVList.GetRowCellValue(i, "id_comp_group"),
                    GVList.GetRowCellValue(i, "awbill_date"),
                    GVList.GetRowCellValue(i, "id_awbill"),
                    GVList.GetRowCellValue(i, "combine_number").ToString,
                    GVList.GetRowCellValue(i, "do_no").ToString,
                    GVList.GetRowCellValue(i, "pl_sales_order_del_number").ToString,
                    GVList.GetRowCellValue(i, "comp_number"),
                    GVList.GetRowCellValue(i, "comp_name"),
                    GVList.GetRowCellValue(i, "qty"),
                    GVList.GetRowCellValue(i, "city"),
                    GVList.GetRowCellValue(i, "weight"),
                    GVList.GetRowCellValue(i, "width"),
                    GVList.GetRowCellValue(i, "length"),
                    GVList.GetRowCellValue(i, "height"),
                    GVList.GetRowCellValue(i, "volume"),
                    GVList.GetRowCellValue(i, "c_weight")
                )
            End If
        Next

        'sorting
        Dim data_view As DataView = New DataView(data)

        data_view.Sort = "comp_number ASC, id_awbill ASC, combine_number ASC"

        FormDelManifestDet.GCList.DataSource = data_view.ToTable

        FormDelManifestDet.GVList.BestFitColumns()

        Close()
    End Sub

    Private Sub SBClose_Click(sender As Object, e As EventArgs) Handles SBClose.Click
        Close()
    End Sub

    Private Sub DateEditCreatedDateFrom_EditValueChanged(sender As Object, e As EventArgs) Handles DateEditCreatedDateFrom.EditValueChanged
        DateEditCreatedDateTo.Properties.MinValue = DateEditCreatedDateFrom.EditValue
    End Sub
End Class