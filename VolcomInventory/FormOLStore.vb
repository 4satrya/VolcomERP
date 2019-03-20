Public Class FormOLStore
    Private Sub FormOLStore_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        setDateNow()
        viewComp()
    End Sub

    Sub setDateNow()
        Dim data_dt As DataTable = execute_query("SELECT DATE(NOW()) AS `dt`", -1, True, "", "", "", "")
        DEFrom.EditValue = data_dt.Rows(0)("dt")
        DEUntil.EditValue = data_dt.Rows(0)("dt")
    End Sub

    Sub viewComp()
        Dim query As String = "
        SELECT 0 AS `id_comp`, 0 AS `id_comp_contact`, 'ALL' AS `comp_number`, 'All Store' AS `comp_name`
        UNION ALL
        SELECT c.id_comp,cc.id_comp_contact, c.comp_number,c.comp_name 
        FROM tb_m_comp c 
        INNER JOIN tb_m_comp_contact cc ON cc.id_comp = c.id_comp AND cc.is_default=1 
        WHERE c.id_commerce_type=2 AND c.is_active=1 "
        viewSearchLookupQuery(SLECompDetail, query, "id_comp", "comp_name", "id_comp")
    End Sub

    Private Sub FormOLStore_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub FormOLStore_Deactivate(sender As Object, e As EventArgs) Handles MyBase.Deactivate
        FormMain.hide_rb()
    End Sub

    Private Sub FormOLStore_Activated(sender As Object, e As EventArgs) Handles MyBase.Activated
        FormMain.show_rb(Name)
        checkFormAccess(Name)
    End Sub

    Private Sub BtnViewDetail_Click(sender As Object, e As EventArgs) Handles BtnViewDetail.Click
        If XtraTabControl1.SelectedTabPageIndex = 0 Then
            viewSummary()
        ElseIf XtraTabControl1.SelectedTabPageIndex = 1 Then
            viewDetail()
        ElseIf XtraTabControl1.SelectedTabPageIndex = 2 Then
            viewDetailCancell()
        End If
    End Sub

    Sub viewDetailCancell()
        Cursor = Cursors.WaitCursor
        Dim data As DataTable = mainQuery(True)
        GCCancellOrder.DataSource = data
        GVCancellOrder.BestFitColumns()
        Cursor = Cursors.Default
    End Sub


    Sub viewDetail()
        Cursor = Cursors.WaitCursor
        Dim data As DataTable = mainQuery(False)
        GCDetail.DataSource = data
        GVDetail.BestFitColumns()
        Cursor = Cursors.Default
    End Sub

    Sub viewSummary()
        Cursor = Cursors.WaitCursor

        'Prepare paramater
        Dim date_from_selected As String = "0000-01-01"
        Dim date_until_selected As String = "9999-01-01"
        Try
            date_from_selected = DateTime.Parse(DEFrom.EditValue.ToString).ToString("yyyy-MM-dd")
        Catch ex As Exception
        End Try

        Try
            date_until_selected = DateTime.Parse(DEUntil.EditValue.ToString).ToString("yyyy-MM-dd")
        Catch ex As Exception
        End Try

        'account
        Dim id_comp As String = SLECompDetail.EditValue.ToString
        Dim comp As String = ""
        If id_comp <> "0" Then
            comp = "AND c.id_comp='" + id_comp + "' "
        End If

        Dim query As String = "SELECT 'No' AS `is_select`,c.id_comp, c.comp_number, c.comp_name,
        CONCAT(c.comp_number, ' - ', c.comp_name) AS `store`,
        CONCAT(wh.comp_number, ' - ', wh.comp_name) AS `wh`,
        so.id_sales_order AS `id_order`, so.sales_order_number AS `order_number`, so.sales_order_ol_shop_number AS `ol_store_order_number`, so.sales_order_date AS `order_date`,
        prod.product_full_code AS `code`, prod.product_display_name AS `name`, SUM(sod.sales_order_det_qty) AS `total_order`,
        so.id_prepare_status, stt.prepare_status, so.id_report_status, rs.report_status,
        so.`customer_name` , so.`shipping_name` , so.`shipping_address`, so.`shipping_phone` , so.`shipping_city` , 
        so.`shipping_post_code` , so.`shipping_region` , so.`payment_method`, so.`tracking_code`, 'No' AS `is_select`, IF(ISNULL(doc.id_report),'No', 'Yes') AS `is_attach`
        FROM tb_sales_order so
        INNER JOIN tb_sales_order_det sod ON sod.id_sales_order = so.id_sales_order
        INNER JOIN tb_m_product prod ON prod.id_product = sod.id_product
        INNER JOIN tb_m_comp_contact socc ON socc.id_comp_contact = so.id_store_contact_to
        INNER JOIN tb_m_comp c ON c.id_comp = socc.id_comp
        INNER JOIN tb_m_comp_contact wh_c ON wh_c.id_comp_contact = so.id_warehouse_contact_to 
        INNER JOIN tb_m_comp wh ON wh_c.id_comp = wh.id_comp 
        INNER JOIN tb_lookup_prepare_status stt ON stt.id_prepare_status = so.id_prepare_status
        INNER JOIN tb_lookup_report_status rs ON rs.id_report_status = so.id_report_status
        LEFT JOIN (
            SELECT d.id_report 
            FROM tb_doc d
            INNER JOIN tb_sales_order so ON so.id_sales_order = d.id_report
            WHERE d.report_mark_type=39 AND (so.sales_order_date>='" + date_from_selected + "' AND so.sales_order_date<='" + date_until_selected + "') 
            GROUP BY d.id_report
        ) doc ON doc.id_report = so.id_sales_order
        WHERE so.id_sales_order>0 AND (so.sales_order_date>='" + date_from_selected + "' AND so.sales_order_date<='" + date_until_selected + "') 
        " + comp + " AND c.id_commerce_type=2
        GROUP BY so.id_sales_order 
        ORDER BY so.sales_order_ol_shop_number ASC "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCSummary.DataSource = data
        GVSummary.BestFitColumns()
        Cursor = Cursors.Default
    End Sub


    Function mainQuery(ByVal is_show_cancell As Boolean)
        'Prepare paramater
        Dim date_from_selected As String = "0000-01-01"
        Dim date_until_selected As String = "9999-01-01"
        Try
            date_from_selected = DateTime.Parse(DEFrom.EditValue.ToString).ToString("yyyy-MM-dd")
        Catch ex As Exception
        End Try

        Try
            date_until_selected = DateTime.Parse(DEUntil.EditValue.ToString).ToString("yyyy-MM-dd")
        Catch ex As Exception
        End Try

        'account
        Dim id_comp As String = SLECompDetail.EditValue.ToString
        Dim comp As String = ""
        If id_comp <> "0" Then
            comp = "AND c.id_comp='" + id_comp + "' "
        End If

        Dim query As String = "SELECT 'No' AS `is_select`,c.id_comp, c.comp_number, c.comp_name,
        so.id_sales_order AS `id_order`, so.sales_order_number AS `order_number`, so.sales_order_ol_shop_number AS `ol_store_order_number`, so.sales_order_date AS `order_date`,
        sod.id_sales_order_det, sod.item_id, sod.ol_store_id, sod.id_product, prod.product_full_code AS `code`, prod.product_display_name AS `name`, cd.code_detail_name AS `size`,
        sod.id_design_price, sod.design_price, sod.sales_order_det_qty AS `order_qty`, sod.sales_order_det_note,
        so.id_prepare_status, stt.prepare_status,
        so.`customer_name` , so.`shipping_name` , so.`shipping_address`, so.`shipping_phone` , so.`shipping_city` , 
        so.`shipping_post_code` , so.`shipping_region` , so.`payment_method`, so.`tracking_code`, IFNULL(stt.`status`, '-') AS `ol_store_status`, stt.status_date AS `ol_store_date`
        FROM tb_sales_order so
        INNER JOIN tb_sales_order_det sod ON sod.id_sales_order = so.id_sales_order
        LEFT JOIN tb_pl_sales_order_del_det dd ON dd.id_sales_order_det = sod.id_sales_order_det
        LEFT JOIN tb_pl_sales_order_del d ON d.id_pl_sales_order_del = dd.id_pl_sales_order_del AND d.id_report_status!=5
        INNER JOIN tb_m_product prod ON prod.id_product = sod.id_product
        INNER JOIN tb_m_product_code prod_code ON prod_code.id_product = prod.id_product
        INNER JOIN tb_m_code_detail cd ON cd.id_code_detail = prod_code.id_code_detail
        INNER JOIN tb_m_comp_contact socc ON socc.id_comp_contact = so.id_store_contact_to
        INNER JOIN tb_m_comp c ON c.id_comp = socc.id_comp
        LEFT JOIN (
            SELECT * FROM (
	            SELECT stt.id_sales_order_det, stt.`status`, stt.status_date 
	            FROM tb_sales_order_det_status stt
	            ORDER BY stt.status_date DESC
            ) a
            GROUP BY a.id_sales_order_det
        ) stt ON stt.id_sales_order_det = sod.id_sales_order_det
        INNER JOIN tb_lookup_prepare_status stt ON stt.id_prepare_status = so.id_prepare_status
        WHERE so.id_report_status=6 " + comp + " AND c.id_commerce_type=2
        AND (so.sales_order_date>='" + date_from_selected + "' AND so.sales_order_date<='" + date_until_selected + "') "
        If is_show_cancell Then
            query += "AND so.id_prepare_status=2 AND ISNULL(d.id_pl_sales_order_del) "
        Else
            query += "AND (so.id_prepare_status=1 OR (so.id_prepare_status=2 AND !ISNULL(d.id_pl_sales_order_del))) "
        End If
        query += "ORDER BY so.sales_order_ol_shop_number ASC "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        Return data
    End Function


    Private Sub BtnUpdateStt_Click(sender As Object, e As EventArgs) Handles BtnUpdateStt.Click
        Cursor = Cursors.WaitCursor
        FormImportExcel.id_pop_up = "42"
        FormImportExcel.ShowDialog()
        Cursor = Cursors.Default
    End Sub

    Private Sub EditToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EditToolStripMenuItem.Click
        If GVDetail.RowCount > 0 And GVDetail.FocusedRowHandle >= 0 Then
            Cursor = Cursors.WaitCursor
            FormOLStoreOrderId.Text += " : " + GVDetail.GetFocusedRowCellValue("order_number").ToString
            FormOLStoreOrderId.TxtOrderNumber.Text = GVDetail.GetFocusedRowCellValue("ol_store_order_number").ToString
            FormOLStoreOrderId.TxtItemId.Text = GVDetail.GetFocusedRowCellValue("item_id").ToString
            FormOLStoreOrderId.TxtOLStoreId.Text = GVDetail.GetFocusedRowCellValue("ol_store_id").ToString
            FormOLStoreOrderId.id_main = GVDetail.GetFocusedRowCellValue("id_order").ToString
            FormOLStoreOrderId.id_det = GVDetail.GetFocusedRowCellValue("id_sales_order_det").ToString
            FormOLStoreOrderId.ShowDialog()
            Cursor = Cursors.Default
        End If
    End Sub

    Private Sub BtnExportToBOF_Click(sender As Object, e As EventArgs) Handles BtnExportToBOF.Click
        makeSafeGV(GVSummary)
        GVSummary.ActiveFilterString = "[is_select]='Yes'"
        If GVSummary.RowCount > 0 Then
            Dim id_so As String = ""
            For i As Integer = 0 To GVSummary.RowCount - 1
                If i > 0 Then
                    id_so += "OR "
                End If
                id_so += "so.id_sales_order='" + GVSummary.GetRowCellValue(i, "id_order").ToString + "' "
            Next
            Dim so As New ClassSalesOrder()
            Dim res As String = so.generateXLSForBOF(id_so)
            If res = "True" Then
                infoCustom("File exported successfully")
                viewSummary()
            Else
                stopCustom(res)
            End If
        Else
            stopCustom("No item selected")
        End If
        makeSafeGV(GVSummary)
    End Sub

    Private Sub XtraTabControl1_SelectedPageChanged(sender As Object, e As DevExpress.XtraTab.TabPageChangedEventArgs) Handles XtraTabControl1.SelectedPageChanged

    End Sub

    Private Sub ViewDetailToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ViewDetailToolStripMenuItem.Click
        viewDetailOrder()
    End Sub

    Sub viewDetailOrder()
        If GVSummary.RowCount > 0 And GVSummary.FocusedRowHandle >= 0 Then
            Cursor = Cursors.WaitCursor
            FormSalesOrderDet.id_sales_order = GVSummary.GetFocusedRowCellValue("id_order").ToString
            FormSalesOrderDet.action = "upd"
            FormSalesOrderDet.ShowDialog()
            Cursor = Cursors.Default
        End If
    End Sub

    Private Sub FileAttachmentToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles FileAttachmentToolStripMenuItem.Click
        If GVSummary.RowCount > 0 And GVSummary.FocusedRowHandle >= 0 Then
            Dim id_report_status As String = GVSummary.GetFocusedRowCellValue("id_report_status").ToString
            Dim id_order As String = GVSummary.GetFocusedRowCellValue("id_order").ToString
            FormDocumentUpload.id_report = id_order
            FormDocumentUpload.report_mark_type = "39"
            If id_report_status <> "1" Then
                FormDocumentUpload.is_view = "1"
                FormDocumentUpload.ShowDialog()
            Else
                FormDocumentUpload.ShowDialog()
                viewSummary()
                GVSummary.FocusedRowHandle = find_row(GVSummary, "id_order", id_order)
            End If
        End If
    End Sub

    Private Sub GVSummary_DoubleClick(sender As Object, e As EventArgs) Handles GVSummary.DoubleClick
        viewDetailOrder()
    End Sub

    Private Sub SLECompDetail_EditValueChanged(sender As Object, e As EventArgs) Handles SLECompDetail.EditValueChanged
        GCSummary.DataSource = Nothing
        GCDetail.DataSource = Nothing
        GCCancellOrder.DataSource = Nothing
    End Sub

    Private Sub DEFrom_EditValueChanged(sender As Object, e As EventArgs) Handles DEFrom.EditValueChanged
        GCSummary.DataSource = Nothing
        GCDetail.DataSource = Nothing
        GCCancellOrder.DataSource = Nothing
    End Sub

    Private Sub DEUntil_EditValueChanged(sender As Object, e As EventArgs) Handles DEUntil.EditValueChanged
        GCSummary.DataSource = Nothing
        GCDetail.DataSource = Nothing
        GCCancellOrder.DataSource = Nothing
    End Sub

    Private Sub CESelAll_CheckedChanged(sender As Object, e As EventArgs) Handles CESelAll.CheckedChanged
        If GVSummary.RowCount > 0 Then
            Dim cek As String = CESelAll.EditValue.ToString
            For i As Integer = 0 To ((GVSummary.RowCount - 1) - GetGroupRowCount(GVSummary))
                If cek Then
                    GVSummary.SetRowCellValue(i, "is_select", "Yes")
                Else
                    GVSummary.SetRowCellValue(i, "is_select", "No")
                End If
            Next
        End If
    End Sub

    Private Sub BtnOrderConfirmation_Click(sender As Object, e As EventArgs) Handles BtnOrderConfirmation.Click
        Cursor = Cursors.WaitCursor
        makeSafeGV(GVSummary)
        GVSummary.ActiveFilterString = "[is_select]='Yes'"
        If GVSummary.RowCount > 0 Then
            Dim id_so As String = ""
            For i As Integer = 0 To GVSummary.RowCount - 1
                If i > 0 Then
                    id_so += "OR "
                End If
                id_so += "so.id_sales_order='" + GVSummary.GetRowCellValue(i, "id_order").ToString + "' "
            Next

            'cek order
            Dim query_cek As String = "SELECT so.id_sales_order, so.sales_order_ol_shop_number, so.sales_order_number, so.customer_name,so.tracking_code,
            CONCAT(c.comp_number, ' - ', c.comp_name) AS `store`,
            CONCAT(wh.comp_number, ' - ', wh.comp_name) AS `wh`,
            so.id_report_status, stt.report_status, doc.id_report,
            IF(so.id_report_status!=1 OR ISNULL(doc.id_report), CONCAT(IF(so.id_report_status!=1, CONCAT('Already ', stt.report_status, ' ; '),''), IF(ISNULL(doc.id_report),'No file attached; ','')),'OK') AS `status_check`
            FROM tb_sales_order so
            INNER JOIN tb_lookup_report_status stt ON stt.id_report_status = so.id_report_status
            INNER JOIN tb_m_comp_contact socc ON socc.id_comp_contact = so.id_store_contact_to
            INNER JOIN tb_m_comp c ON c.id_comp = socc.id_comp
            INNER JOIN tb_m_comp_contact wh_c ON wh_c.id_comp_contact = so.id_warehouse_contact_to 
            INNER JOIN tb_m_comp wh ON wh_c.id_comp = wh.id_comp
            LEFT JOIN (
	            SELECT doc.id_report 
	            FROM tb_doc doc
	            WHERE doc.report_mark_type=39 
	            GROUP BY doc.id_report
            ) doc ON doc.id_report = so.id_sales_order
            WHERE so.id_sales_order>0
            AND (" + id_so + ")
            ORDER BY sales_order_ol_shop_number ASC "
            Dim data_cek As DataTable = execute_query(query_cek, -1, True, "", "", "", "")
            Dim data_cek_filter As DataRow() = data_cek.Select("[status_check]<>'OK'")
            If data_cek_filter.Count > 0 Then
                'show alert can't process
                stopCustom("Some order have problem. Click 'OK' to see checking result")
                FormOLStoreAlertConfirm.dt = data_cek
                FormOLStoreAlertConfirm.ShowDialog()
                makeSafeGV(GVSummary)
            Else
                'send email
                Dim confirm As DialogResult = DevExpress.XtraEditors.XtraMessageBox.Show("Are you sure you want to confirm these order?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
                If confirm = Windows.Forms.DialogResult.Yes Then
                    FormMain.SplashScreenManager1.ShowWaitForm()
                    FormMain.SplashScreenManager1.SetWaitFormDescription("Get all orders")

                    Dim query As String = "SELECT so.sales_order_ol_shop_number, so.customer_name, cg.comp_group AS `group_store_code`, cg.description AS `group_store`
                    FROM tb_sales_order so 
                    INNER JOIN tb_m_comp_contact socc ON socc.id_comp_contact = so.id_store_contact_to
                    INNER JOIN tb_m_comp c ON c.id_comp = socc.id_comp
                    INNER JOIN tb_m_comp_group cg ON cg.id_comp_group = c.id_comp_group
                    WHERE so.id_sales_order>0
                    AND (" + id_so + ")
                    GROUP BY so.sales_order_ol_shop_number "
                    Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
                    If data.Rows.Count > 0 Then
                        Dim source_path As String = get_setup_field("upload_dir")
                        For i As Integer = 0 To data.Rows.Count - 1
                            FormMain.SplashScreenManager1.SetWaitFormDescription("Processing order : " + (i + 1).ToString + " of " + data.Rows.Count.ToString)

                            'send email
                            Dim em As New ClassSendEmail()
                            em.report_mark_type = "39"
                            em.id_report = id_so
                            em.design = data.Rows(i)("group_store").ToString
                            em.design_code = data.Rows(i)("sales_order_ol_shop_number").ToString
                            em.comment_by = data.Rows(i)("customer_name").ToString
                            em.comment = source_path
                            em.send_email()

                            'completed status
                            Dim query_comp As String = "UPDATE tb_sales_order so SET so.id_report_status=6 
                            WHERE so.sales_order_ol_shop_number='" + data.Rows(i)("sales_order_ol_shop_number").ToString + "' AND (" + id_so + ") "
                            execute_non_query(query_comp, True, "", "", "", "")
                        Next
                    End If
                    makeSafeGV(GVSummary)
                    viewSummary()
                    FormMain.SplashScreenManager1.CloseWaitForm()
                Else
                    makeSafeGV(GVSummary)
                End If
            End If
        Else
            stopCustom("No item selected")
            makeSafeGV(GVSummary)
        End If
        Cursor = Cursors.Default
    End Sub
End Class