Public Class FormRetOLStoreDet
    Public id As String = "-1"
    Public is_view As String = "-1"
    Dim id_report_status As String = "-1"
    Dim rmt As String = "243"
    Public action As String = "-1"
    Dim scan_mode As String = ""
    Dim dt As DataTable


    Private Sub FormRetOLStoreDet_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        viewCompGroup()
        viewReportStatus()
        actionLoad()
    End Sub

    Sub viewCompGroup()
        Cursor = Cursors.WaitCursor
        Dim query As String = "SELECT cg.id_comp_group, cg.comp_group, cg.description 
        FROM tb_m_comp_group cg
        INNER JOIN tb_m_comp c ON c.id_comp_group = cg.id_comp_group AND c.id_commerce_type=2
        GROUP BY cg.id_comp_group "
        viewSearchLookupQuery(SLECompGroup, query, "id_comp_group", "description", "id_comp_group")
        Cursor = Cursors.Default
    End Sub

    Sub viewReportStatus()
        Dim query As String = "SELECT * FROM tb_lookup_report_status a ORDER BY a.id_report_status "
        'Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        viewLookupQuery(LEReportStatus, query, 0, "report_status", "id_report_status")
    End Sub

    Sub actionLoad()
        Cursor = Cursors.WaitCursor
        If action = "ins" Then
            Dim dt_now As DateTime = getTimeDB()
            DECreated.EditValue = dt_now
            DERecDate.EditValue = dt_now
            SLECompGroup.EditValue = FormRetOlStore.SLECompGroup.EditValue.ToString
            TxtOrderNumber.Text = FormRetOlStore.GVOrderList.GetFocusedRowCellValue("sales_order_ol_shop_number").ToString
            TxtRetRequest.Focus()
            viewDetail()
            viewCollectionCode()
        ElseIf action = "upd" Then
            'main
            Dim query_c As ClassRetOLStore = New ClassRetOLStore()
            Dim query As String = query_c.queryMain("AND r.id_ol_store_ret=" + id + " ", "2")
            Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
            TxtNumber.Text = data.Rows(0)("number").ToString
            DECreated.EditValue = data.Rows(0)("created_date")
            TxtCreatedBy.Text = data.Rows(0)("created_by_name").ToString
            SLECompGroup.EditValue = data.Rows(0)("id_comp_group").ToString
            TxtOrderNumber.Text = data.Rows(0)("sales_order_ol_shop_number").ToString
            TxtRetRequest.Text = data.Rows(0)("ret_req_number").ToString
            DERecDate.EditValue = data.Rows(0)("rec_date")
            MENote.Text = data.Rows(0)("note").ToString
            LEReportStatus.ItemIndex = LEReportStatus.Properties.GetDataSourceRowIndex("id_report_status", data.Rows(0)("id_report_status").ToString)
            id_report_status = data.Rows(0)("id_report_status").ToString

            'detail
            viewDetail()
            allow_status()
        End If
        Cursor = Cursors.Default
    End Sub

    Sub viewDetail()
        Cursor = Cursors.WaitCursor
        Dim query As String = "SELECT d.id_ol_store_ret_det, d.id_ol_store_ret, 
        d.id_sales_order_det, sod.id_product, d.product_full_code, p.product_display_name AS `name`, cd.code_detail_name AS `size`, sod.item_id, sod.ol_store_id,
        d.id_pl_sales_order_del_det_counting
        FROM tb_ol_store_ret_det d 
        INNER JOIN tb_sales_order_det sod ON sod.id_sales_order_det = d.id_sales_order_det
        INNER JOIN tb_m_product p ON p.id_product = sod.id_product
        INNER JOIN tb_m_product_code pc ON pc.id_product = p.id_product
        INNER JOIN tb_m_code_detail cd ON cd.id_code_detail = pc.id_code_detail
        INNER JOIN tb_pl_sales_order_del_det_counting c ON c.id_pl_sales_order_del_det_counting = d.id_pl_sales_order_del_det_counting
        WHERE d.id_ol_store_ret=" + id + " "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCData.DataSource = Data
        GVData.BestFitColumns()
        Cursor = Cursors.Default
    End Sub

    Sub viewCollectionCode()
        Cursor = Cursors.WaitCursor

        Cursor = Cursors.Default
    End Sub

    Sub allow_status()
        BtnAttachment.Visible = True
        BtnCancell.Visible = True
        TxtRetRequest.Enabled = False
        DERecDate.Enabled = False
        MENote.Enabled = False
        BtnSaveChanges.Visible = False
        PanelControlNav.Visible = False
        BtnMark.Visible = True
        BtnPrint.Visible = True
        MENote.Enabled = False

        If id_report_status = "6" Then
            BtnCancell.Visible = False
        ElseIf id_report_status = "5" Then
            BtnCancell.Visible = False
        End If
    End Sub

    Private Sub BtnAdd_Click(sender As Object, e As EventArgs) Handles BtnAdd.Click
        Cursor = Cursors.WaitCursor
        TxtScannedCode.Enabled = True
        Try
            dt.Clear()
        Catch ex As Exception
        End Try
        Dim order_number As String = addSlashes(TxtOrderNumber.Text)
        Dim id_comp_group As String = SLECompGroup.EditValue.ToString
        Dim query As String = "SELECT a.*, (a.qty-IFNULL(s.qty_save,0)) AS `qty_limit`
        FROM (
	        SELECT sod.id_sales_order_det, dc.id_pl_sales_order_del_det_counting,  
	        sod.id_product,CONCAT(p.product_full_code, dc.pl_sales_order_del_det_counting) AS `code_list`, 
	        p.product_display_name AS `name`, cd.code_detail_name AS `size`, sod.item_id, sod.ol_store_id, 
	        COUNT(CONCAT(p.product_full_code, dc.pl_sales_order_del_det_counting)) AS `qty`
	        FROM tb_sales_order so
	        INNER JOIN tb_m_comp_contact cc ON cc.id_comp_contact = so.id_store_contact_to
	        INNER JOIN tb_m_comp c ON c.id_comp = cc.id_comp
	        INNER JOIN tb_sales_order_det sod ON sod.id_sales_order = so.id_sales_order
	        INNER JOIN tb_pl_sales_order_del_det dd ON dd.id_sales_order_det = sod.id_sales_order_det
	        INNER JOIN tb_pl_sales_order_del_det_counting dc ON dc.id_pl_sales_order_del_det = dd.id_pl_sales_order_del_det
	        INNER JOIN tb_m_product p ON p.id_product = dd.id_product
	        INNER JOIN tb_m_product_code pc ON pc.id_product = p.id_product
	        INNER JOIN tb_m_code_detail cd ON cd.id_code_detail = pc.id_code_detail
	        WHERE so.sales_order_ol_shop_number='" + order_number + "' AND c.id_comp_group=" + id_comp_group + " 
	        GROUP BY code_list
        ) a
        LEFT JOIN (
	        SELECT rd.product_full_code, COUNT(rd.product_full_code) AS `qty_save` 
	        FROM tb_ol_store_ret r
	        INNER JOIN tb_ol_store_ret_det rd ON rd.id_ol_store_ret = r.id_ol_store_ret
	        WHERE r.sales_order_ol_shop_number='" + order_number + "' AND r.id_comp_group=" + id_comp_group + " AND r.id_report_status!=5
	        GROUP BY rd.product_full_code
        ) s ON s.product_full_code = a.code_list
        HAVING qty_limit>0 "
        dt = execute_query(query, -1, True, "", "", "", "")
        scan_mode = "add"
        LabelScannedCode.Appearance.ForeColor = Color.Green
        TxtScannedCode.Properties.Appearance.ForeColor = Color.Green
        TxtScannedCode.Focus()
        Cursor = Cursors.Default
    End Sub

    Private Sub BtnDel_Click(sender As Object, e As EventArgs) Handles BtnDel.Click
        Cursor = Cursors.WaitCursor
        scan_mode = "delete"
        LabelScannedCode.Appearance.ForeColor = Color.Red
        TxtScannedCode.Properties.Appearance.ForeColor = Color.Red
        TxtScannedCode.Focus()
        Cursor = Cursors.Default
    End Sub

    Private Sub FormRetOLStoreDet_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub BtnCancell_Click(sender As Object, e As EventArgs) Handles BtnCancell.Click
        Dim confirm As DialogResult = DevExpress.XtraEditors.XtraMessageBox.Show("Are you sure you want to cancelled this transaction ?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
        If confirm = Windows.Forms.DialogResult.Yes Then
            Cursor = Cursors.WaitCursor
            Dim query As String = "UPDATE tb_ol_store_ret SET id_report_status=5 WHERE id_ol_store_ret='" + id + "'"
            execute_non_query(query, True, "", "", "", "")

            'nonaktif mark
            Dim queryrm = String.Format("UPDATE tb_report_mark SET report_mark_lead_time=NULL,report_mark_start_datetime=NULL WHERE report_mark_type='{0}' AND id_report='{1}' AND id_report_status>'1'", rmt, id)
            execute_non_query(queryrm, True, "", "", "", "")

            FormRetOlStore.viewData()
            FormRetOlStore.GVData.FocusedRowHandle = find_row(FormRetOlStore.GVData, "id_ol_store_ret", id)
            actionLoad()
            Cursor = Cursors.Default
        End If
    End Sub

    Private Sub BtnAttachment_Click(sender As Object, e As EventArgs) Handles BtnAttachment.Click
        Cursor = Cursors.WaitCursor
        FormDocumentUpload.report_mark_type = rmt
        FormDocumentUpload.id_report = id
        If is_view = "1" Or id_report_status = "6" Or id_report_status = "5" Then
            FormDocumentUpload.is_view = "1"
        End If
        FormDocumentUpload.ShowDialog()
        Cursor = Cursors.Default
    End Sub

    Private Sub BtnPrint_Click(sender As Object, e As EventArgs) Handles BtnPrint.Click
        Cursor = Cursors.WaitCursor

        Dim report As ReportRetOLStoreDet = New ReportRetOLStoreDet

        report.id = id
        report.id_pre = If(id_report_status = "6", "-1", "1")
        report.data = GCData.DataSource
        report.report_mark_type = rmt

        report.LabelNumber.Text = "NO. " + TxtNumber.Text
        report.LabelStoreGroup.Text = SLECompGroup.Text
        report.LabelOrderNumber.Text = TxtOrderNumber.Text
        report.LabelRetRequest.Text = TxtRetRequest.Text
        report.LabelReceivedDate.Text = DERecDate.Text
        report.LabelCreatedDate.Text = DECreated.Text
        report.LabelCreatedBy.Text = TxtCreatedBy.Text
        report.LabelStatus.Text = LEReportStatus.Text
        report.LabelRemark.Text = MENote.Text

        'Show the report's preview. 
        Dim Tool As DevExpress.XtraReports.UI.ReportPrintTool = New DevExpress.XtraReports.UI.ReportPrintTool(report)
        Tool.ShowPreview()

        Cursor = Cursors.Default
    End Sub

    Private Sub BtnMark_Click(sender As Object, e As EventArgs) Handles BtnMark.Click
        Cursor = Cursors.WaitCursor
        FormReportMark.report_mark_type = rmt
        FormReportMark.id_report = id
        FormReportMark.is_view = is_view
        FormReportMark.form_origin = Name
        FormReportMark.ShowDialog()
        Cursor = Cursors.Default
    End Sub

    Private Sub BtnSaveChanges_Click(sender As Object, e As EventArgs) Handles BtnSaveChanges.Click
        makeSafeGV(GVData)
        If TxtRetRequest.Text = "" Or GVData.RowCount <= 0 Then
            warningCustom("Please complete all data")
        Else
            Dim confirm As DialogResult = DevExpress.XtraEditors.XtraMessageBox.Show("Are you sure you want to save changes this propose ?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
            If confirm = Windows.Forms.DialogResult.Yes Then
                Cursor = Cursors.WaitCursor
                BtnSaveChanges.Enabled = False
                Dim id_comp_group As String = SLECompGroup.EditValue.ToString
                Dim sales_order_ol_shop_number As String = addSlashes(TxtOrderNumber.Text)
                Dim ret_req_number As String = addSlashes(TxtRetRequest.Text)
                Dim rec_date As String = DateTime.Parse(DERecDate.EditValue.ToString).ToString("yyyy-MM-dd")
                Dim note As String = addSlashes(MENote.Text)

                'main 
                Dim query As String = "INSERT INTO tb_ol_store_ret(id_comp_group, sales_order_ol_shop_number, ret_req_number, rec_date, number, created_date, created_by, note, id_report_status) VALUES 
                ('" + id_comp_group + "', '" + sales_order_ol_shop_number + "', '" + ret_req_number + "', '" + rec_date + "', '', NOW(), '" + id_user + "', '" + note + "',1);SELECT LAST_INSERT_ID(); "
                id = execute_query(query, 0, True, "", "", "", "")
                execute_non_query("CALL gen_number(" + id + ", 243); ", True, "", "", "", "")

                'detail
                Dim query_det As String = "INSERT INTO tb_ol_store_ret_det(id_ol_store_ret, id_sales_order_det, id_pl_sales_order_del_det_counting, product_full_code) VALUES "
                For i As Integer = 0 To GVData.RowCount - 1
                    Dim id_sales_order_det As String = GVData.GetRowCellValue(i, "id_sales_order_det").ToString
                    Dim id_pl_sales_order_del_det_counting As String = GVData.GetRowCellValue(i, "id_pl_sales_order_del_det_counting").ToString
                    Dim product_full_code As String = GVData.GetRowCellValue(i, "product_full_code").ToString

                    If i > 0 Then
                        query_det += ","
                    End If
                    query_det += "('" + id + "', '" + id_sales_order_det + "', '" + id_pl_sales_order_del_det_counting + "', '" + product_full_code + "') "
                Next
                If GVData.RowCount > 0 Then
                    execute_non_query(query_det, True, "", "", "", "")
                End If

                'submit
                submit_who_prepared(rmt, id, id_user)

                'refresh
                FormRetOlStore.viewData()
                FormRetOlStore.GVData.FocusedRowHandle = find_row(FormRetOlStore.GVData, "id_ol_store_ret", id)
                action = "upd"
                actionLoad()
                infoCustom("Pre return saved. Waiting for approval")
                Cursor = Cursors.Default
            End If
        End If
    End Sub

    Private Sub GVData_CustomColumnDisplayText(sender As Object, e As DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs) Handles GVData.CustomColumnDisplayText
        If e.Column.FieldName = "no" Then
            e.DisplayText = (e.ListSourceRowIndex + 1).ToString()
        End If
    End Sub

    Private Sub TxtScannedCode_KeyDown(sender As Object, e As KeyEventArgs) Handles TxtScannedCode.KeyDown
        Cursor = Cursors.WaitCursor
        If e.KeyData = Keys.Enter Then
            Dim code As String = addSlashes(TxtScannedCode.Text)
            If scan_mode = "add" Then
                ' add scan
                Dim dtf As DataRow() = dt.Select("[code_list]='" + code + "' ")
                If dtf.Length <= 0 Then
                    stopCustomDialog("Code : " + code + " not found. ")
                    GVData.FocusedRowHandle = GVData.RowCount - 1
                    TxtScannedCode.Text = ""
                    TxtScannedCode.Focus()
                Else
                    makeSafeGV(GVData)
                    Dim tot_qty As Integer = 0
                    GVData.ActiveFilterString = "[product_full_code]='" + code + "'"
                    If GVData.RowCount > 0 Then
                        tot_qty = GVData.RowCount
                    End If
                    GVData.ActiveFilterString = ""
                    If tot_qty < dtf(0)("qty_limit") Then
                        Dim newRow As DataRow = (TryCast(GCData.DataSource, DataTable)).NewRow()
                        newRow("id_ol_store_ret_det") = "0"
                        newRow("id_ol_store_ret") = "0"
                        newRow("id_sales_order_det") = dtf(0)("id_sales_order_det").ToString
                        newRow("id_product") = dtf(0)("id_product").ToString
                        newRow("product_full_code") = dtf(0)("code_list").ToString
                        newRow("name") = dtf(0)("name").ToString
                        newRow("size") = dtf(0)("size").ToString
                        newRow("item_id") = dtf(0)("item_id").ToString
                        newRow("ol_store_id") = dtf(0)("ol_store_id").ToString
                        newRow("id_pl_sales_order_del_det_counting") = dtf(0)("id_pl_sales_order_del_det_counting").ToString
                        TryCast(GCData.DataSource, DataTable).Rows.Add(newRow)
                        GCData.RefreshDataSource()
                        GVData.RefreshData()
                        GVData.FocusedRowHandle = GVData.RowCount - 1
                        TxtScannedCode.Text = ""
                        TxtScannedCode.Focus()
                    Else
                        stopCustomDialog("Maximum scan : " + dtf(0)("qty_limit").ToString)
                        TxtScannedCode.Text = ""
                        TxtScannedCode.Focus()
                    End If
                End If
            Else
                makeSafeGV(GVData)
                GVData.ActiveFilterString = "[product_full_code]='" + code + "'"
                If GVData.RowCount > 0 Then
                    GVData.DeleteSelectedRows()
                    GCData.RefreshDataSource()
                    GVData.RefreshData()
                    GVData.FocusedRowHandle = GVData.RowCount - 1
                    TxtScannedCode.Text = ""
                    TxtScannedCode.Focus()
                Else
                    stopCustomDialog("Code : " + code + " not found. ")
                    GVData.FocusedRowHandle = GVData.RowCount - 1
                    TxtScannedCode.Text = ""
                    TxtScannedCode.Focus()
                End If
                GVData.ActiveFilterString = ""
            End If
        End If
        Cursor = Cursors.Default
    End Sub
End Class