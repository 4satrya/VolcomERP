Public Class FormRequestRetOLStore
    Public id As String = "-1"
    Public is_view As String = "-1"
    Dim id_report_status As String = "-1"
    Dim rmt As String = "246"
    Public action As String = "-1"
    Dim scan_mode As String = ""
    Dim dt As DataTable
    Dim lead_time_return As Integer = 0
    Dim is_confirm As String = "2"
    Dim source_path As String = get_setup_field("upload_dir")

    Private Sub FormRequestRetOLStore_Load(sender As Object, e As EventArgs) Handles MyBase.Load
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

    Sub checkDate()
        Cursor = Cursors.WaitCursor
        Dim id_group As String = "-1"
        Try
            id_group = SLECompGroup.EditValue.ToString
        Catch ex As Exception
        End Try
        Dim query As String = "SELECT lead_time_return FROM tb_m_comp_group WHERE id_comp_group='" + id_group + "' "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        If data.Rows.Count > 0 Then
            lead_time_return = data.Rows(0)("lead_time_return")
        Else
            lead_time_return = 0
        End If
        Dim diff As Integer = DateDiff("d", DERecByCust.EditValue, DEReqDate.EditValue).ToString
        If diff <= lead_time_return Then
            LabelValidDate.Text = "OK"
            LabelValidDate.ForeColor = Color.Green
        Else
            LabelValidDate.Text = "NOT VALID"
            LabelValidDate.ForeColor = Color.Red
        End If
        'Console.WriteLine(diff.ToString)
        'Console.WriteLine("Lead time :" + lead_time_return.ToString)
        Cursor = Cursors.Default
    End Sub

    Sub actionLoad()
        Cursor = Cursors.WaitCursor
        If action = "ins" Then
            Dim dt_now As DateTime = getTimeDB()
            DECreated.EditValue = dt_now
            DEReqDate.EditValue = dt_now
            DERecByCust.EditValue = dt_now
            SLECompGroup.Focus()
            viewDetail()
        ElseIf action = "upd" Then
            'main
            Dim query_c As ClassRequestRetOLStore = New ClassRequestRetOLStore()
            Dim query As String = query_c.queryMain("AND r.id_ol_store_ret_req=" + id + " ", "2")
            Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
            TxtNumber.Text = data.Rows(0)("number").ToString
            DECreated.EditValue = data.Rows(0)("created_date")
            TxtCreatedBy.Text = data.Rows(0)("created_by_name").ToString
            SLECompGroup.EditValue = data.Rows(0)("id_comp_group").ToString
            TxtOrderNumber.Text = data.Rows(0)("sales_order_ol_shop_number").ToString
            DERecByCust.EditValue = data.Rows(0)("receive_cust_date")
            TxtRetRequest.Text = data.Rows(0)("ret_req_number").ToString
            DEReqDate.EditValue = data.Rows(0)("ret_req_date")
            MENote.Text = data.Rows(0)("note").ToString
            MEReason.Text = data.Rows(0)("ret_reason").ToString
            LEReportStatus.ItemIndex = LEReportStatus.Properties.GetDataSourceRowIndex("id_report_status", data.Rows(0)("id_report_status").ToString)
            id_report_status = data.Rows(0)("id_report_status").ToString
            is_confirm = data.Rows(0)("is_confirm").ToString
            DEOrderDate.EditValue = data.Rows(0)("order_date")
            TxtCustomer.Text = data.Rows(0)("customer_name").ToString
            MEAddress.Text = data.Rows(0)("shipping_address").ToString
            TxtPhone.Text = data.Rows(0)("shipping_phone").ToString

            'detail
            viewDetail()
            allow_status()
        End If
        Cursor = Cursors.Default
    End Sub

    Sub viewDetail()
        Cursor = Cursors.WaitCursor
        Dim query As String = "SELECT d.id_ol_store_ret_req_det, d.id_ol_store_ret_req, 
        d.id_sales_order_det, sod.id_product, p.product_full_code AS `code`,d.product_full_code, p.product_display_name AS `name`, cd.code_detail_name AS `size`, sod.item_id, sod.ol_store_id, dd.design_price, stt.design_cat
        FROM tb_ol_store_ret_req_det d 
        INNER JOIN tb_sales_order_det sod ON sod.id_sales_order_det = d.id_sales_order_det
        INNER JOIN tb_m_product p ON p.id_product = sod.id_product
        INNER JOIN tb_m_product_code pc ON pc.id_product = p.id_product
        INNER JOIN tb_m_code_detail cd ON cd.id_code_detail = pc.id_code_detail
        INNER JOIN tb_pl_sales_order_del_det dd ON dd.id_sales_order_det = sod.id_sales_order_det
        INNER JOIN tb_m_design_price prc ON prc.id_design_price = dd.id_design_price
        INNER JOIN tb_lookup_design_price_type pt ON pt.id_design_price_type = prc.id_design_price_type
        INNER JOIN tb_lookup_design_cat stt ON stt.id_design_cat = pt.id_design_cat
        WHERE d.id_ol_store_ret_req=" + id + " "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCData.DataSource = data
        GVData.BestFitColumns()
        Cursor = Cursors.Default
    End Sub

    Sub allow_status()
        BtnAttachment.Visible = True
        BtnCancell.Visible = True
        SLECompGroup.Enabled = False
        BtnBrowseOrder.Enabled = False
        PanelControlNav.Visible = False
        DEReqDate.Enabled = False

        If is_confirm = "2" And is_view = "-1" Then
            BtnConfirm.Visible = True
            BtnMark.Visible = False
            BtnPrint.Visible = False
            BtnSaveChanges.Visible = True
            TxtRetRequest.Enabled = True
            MEReason.Enabled = True
            MENote.Enabled = True
        Else
            BtnMark.Visible = True
            BtnConfirm.Visible = False
            BtnPrint.Visible = True
            BtnSaveChanges.Visible = False
            TxtRetRequest.Enabled = False
            MEReason.Enabled = False
            MENote.Enabled = False
        End If

        'reset propose
        If is_view = "-1" And is_confirm = "1" Then
            BtnResetPropose.Visible = True
        Else
            BtnResetPropose.Visible = False
        End If

        If id_report_status = "6" Then
            BtnCancell.Visible = False
            BtnResetPropose.Visible = False
            MENote.Enabled = False
            MEReason.Enabled = False
        ElseIf id_report_status = "5" Then
            BtnCancell.Visible = False
            BtnResetPropose.Visible = False
            BtnConfirm.Visible = False
            BtnPrint.Visible = True
            BtnSaveChanges.Visible = False
            TxtRetRequest.Enabled = False
            MEReason.Enabled = False
            MENote.Enabled = False
        End If
    End Sub

    Private Sub TxtRetRequest_EditValueChanged(sender As Object, e As EventArgs) Handles TxtRetRequest.EditValueChanged

    End Sub

    Private Sub FormRequestRetOLStore_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub BtnCancell_Click(sender As Object, e As EventArgs) Handles BtnCancell.Click
        Dim confirm As DialogResult = DevExpress.XtraEditors.XtraMessageBox.Show("Are you sure you want to cancelled this transaction ?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
        If confirm = Windows.Forms.DialogResult.Yes Then
            Cursor = Cursors.WaitCursor
            Dim query As String = "UPDATE tb_ol_store_ret_req SET id_report_status=5 WHERE id_ol_store_ret_req='" + id + "'"
            execute_non_query(query, True, "", "", "", "")

            'nonaktif mark
            Dim queryrm = String.Format("UPDATE tb_report_mark SET report_mark_lead_time=NULL,report_mark_start_datetime=NULL WHERE report_mark_type='{0}' AND id_report='{1}' AND id_report_status>'1'", rmt, id)
            execute_non_query(queryrm, True, "", "", "", "")

            FormOlStoreReturnList.viewRequest()
            FormOlStoreReturnList.GVRequest.FocusedRowHandle = find_row(FormOlStoreReturnList.GVRequest, "id_ol_store_ret_req", id)
            actionLoad()
            Cursor = Cursors.Default
        End If
    End Sub

    Private Sub BtnAttachment_Click(sender As Object, e As EventArgs) Handles BtnAttachment.Click
        Cursor = Cursors.WaitCursor
        FormDocumentUpload.report_mark_type = rmt
        FormDocumentUpload.id_report = id
        If is_view = "1" Or id_report_status = "6" Or id_report_status = "5" Or is_confirm = "1" Then
            FormDocumentUpload.is_view = "1"
        End If
        FormDocumentUpload.ShowDialog()
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

    Sub saveChanges()
        makeSafeGV(GVData)
        checkDate()

        If TxtOrderNumber.Text = "" Or TxtRetRequest.Text = "" Or MEReason.Text = "" Or GVData.RowCount <= 0 Then
            stopCustom("Please complete all data")
        ElseIf LabelValidDate.Text <> "OK" Then
            stopCustom("Request date not valid")
        Else
            Dim id_comp_group As String = SLECompGroup.EditValue.ToString
            Dim sales_order_ol_shop_number As String = addSlashes(TxtOrderNumber.Text)
            Dim receive_cust_date As String = DateTime.Parse(DERecByCust.EditValue.ToString).ToString("yyyy-MM-dd")
            Dim ret_req_number As String = addSlashes(TxtRetRequest.Text)
            Dim ret_req_date As String = DateTime.Parse(DEReqDate.EditValue.ToString).ToString("yyyy-MM-dd")
            Dim note As String = addSlashes(MENote.Text)
            Dim ret_reason As String = addSlashes(MEReason.Text)

            If action = "ins" Then
                Dim confirm As DialogResult = DevExpress.XtraEditors.XtraMessageBox.Show("Are you sure to continue this process?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
                If confirm = Windows.Forms.DialogResult.Yes Then
                    Cursor = Cursors.WaitCursor

                    'main 
                    Dim query As String = "INSERT INTO tb_ol_store_ret_req(id_comp_group, sales_order_ol_shop_number, receive_cust_date, ret_req_number, ret_req_date, created_date, created_by, updated_date, updated_by, note, id_report_status, ret_reason) VALUES 
                    ('" + id_comp_group + "', '" + sales_order_ol_shop_number + "', '" + receive_cust_date + "', '" + ret_req_number + "', '" + ret_req_date + "', NOW(), " + id_user + ", NOW(), " + id_user + ", '" + note + "', 1, '" + ret_reason + "');SELECT LAST_INSERT_ID(); "
                    id = execute_query(query, 0, True, "", "", "", "")
                    execute_non_query("CALL gen_number(" + id + "," + rmt + "); ", True, "", "", "", "")

                    'detail
                    Dim query_det As String = "INSERT INTO tb_ol_store_ret_req_det(id_ol_store_ret_req, id_sales_order_det, product_full_code) VALUES "
                    For i As Integer = 0 To GVData.RowCount - 1
                        Dim id_sales_order_det As String = GVData.GetRowCellValue(i, "id_sales_order_det").ToString
                        Dim product_full_code As String = GVData.GetRowCellValue(i, "product_full_code").ToString

                        If i > 0 Then
                            query_det += ","
                        End If
                        query_det += "('" + id + "', '" + id_sales_order_det + "', '" + product_full_code + "') "
                    Next
                    If GVData.RowCount > 0 Then
                        execute_non_query(query_det, True, "", "", "", "")
                    End If

                    ''refresh
                    FormOlStoreReturnList.viewRequest()
                    FormOlStoreReturnList.GVRequest.FocusedRowHandle = find_row(FormOlStoreReturnList.GVRequest, "id_ol_store_ret_req", id)
                    action = "upd"
                    actionLoad()
                    infoCustom("Request return submitted.")
                    Cursor = Cursors.Default
                End If
            ElseIf action = "upd" Then
                updateHeader()
            End If
        End If
    End Sub

    Sub updateHeader()
        Cursor = Cursors.WaitCursor
        Dim ret_req_number As String = addSlashes(TxtRetRequest.Text)
        Dim note As String = addSlashes(MENote.Text)
        Dim ret_reason As String = addSlashes(MEReason.Text)
        Dim query As String = "UPDATE tb_ol_store_ret_req SET ret_req_number='" + ret_req_number + "', ret_reason='" + ret_reason + "', note='" + note + "'
        WHERE id_ol_store_ret_req='" + id + "' "
        execute_non_query(query, True, "", "", "", "")
        FormOlStoreReturnList.viewRequest()
        FormOlStoreReturnList.GVRequest.FocusedRowHandle = find_row(FormOlStoreReturnList.GVRequest, "id_ol_store_ret_req", id)
        action = "upd"
        actionLoad()
        Cursor = Cursors.Default
    End Sub

    Private Sub BtnSaveChanges_Click(sender As Object, e As EventArgs) Handles BtnSaveChanges.Click
        If action = "ins" Then
            saveChanges()
        ElseIf action = "upd" Then
            updateHeader()
        End If
    End Sub

    Private Sub GVData_CustomColumnDisplayText(sender As Object, e As DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs) Handles GVData.CustomColumnDisplayText
        If e.Column.FieldName = "no" Then
            e.DisplayText = (e.ListSourceRowIndex + 1).ToString()
        End If
    End Sub

    Private Sub BtnBrowseOrder_Click(sender As Object, e As EventArgs) Handles BtnBrowseOrder.Click
        Cursor = Cursors.WaitCursor
        FormOLStoreBrowseOrder.ShowDialog()
        Cursor = Cursors.Default
    End Sub

    Private Sub SLECompGroup_EditValueChanged(sender As Object, e As EventArgs) Handles SLECompGroup.EditValueChanged
        checkDate()
    End Sub

    Private Sub DERecByCust_EditValueChanged(sender As Object, e As EventArgs) Handles DERecByCust.EditValueChanged
        checkDate()
    End Sub

    Private Sub DEReqDate_EditValueChanged(sender As Object, e As EventArgs) Handles DEReqDate.EditValueChanged
        checkDate()
    End Sub

    Private Sub BtnDel_Click(sender As Object, e As EventArgs) Handles BtnDel.Click
        If GVData.RowCount > 0 And GVData.FocusedRowHandle >= 0 Then
            GVData.DeleteRow(GVData.FocusedRowHandle)
            CType(GVData.DataSource, DataTable).AcceptChanges()
            GCData.RefreshDataSource()
            GVData.RefreshData()
        End If
    End Sub

    Private Sub BtnAdd_Click(sender As Object, e As EventArgs) Handles BtnAdd.Click
        Cursor = Cursors.WaitCursor
        FormRequestRetOLStoreSingle.ShowDialog()
        Cursor = Cursors.Default
    End Sub

    Private Sub BtnPrint_Click(sender As Object, e As EventArgs) Handles BtnPrint.Click
        If Not check_allow_print(id_report_status, rmt, id) Then
            warningCustom("Can't print, please complete all approval on system first")
        Else
            Dim report As ReportRequestRetOLStore = New ReportRequestRetOLStore

            report.XTCNumber.Text = TxtNumber.Text
            report.XTCOrderNumber.Text = TxtOrderNumber.Text
            report.XTCRecByCust.Text = DERecByCust.Text
            report.XTCReqDate.Text = DEReqDate.Text
            report.XTCRemark.Text = MENote.Text
            report.XTCReason.Text = MEReason.Text
            report.XTCCustomer.Text = TxtCustomer.Text
            report.XTCAddress.Text = MEAddress.Text
            report.XTCPhone.Text = TxtPhone.Text
            report.XTCOrderDate.Text = DEOrderDate.Text

            report.id = id
            report.data = GCData.DataSource
            report.id_pre = If(id_report_status = "6", "-1", "1")
            report.report_mark_type = rmt

            'image
            Dim data_image As DataTable = execute_query("
                SELECT doc.id_doc,doc.doc_desc,doc.datetime,'yes' as is_download,CONCAT(doc.id_doc,'_" & rmt & "_" & id & "',doc.ext) AS filename,emp.employee_name,doc.is_encrypted
                FROM tb_doc doc
                LEFT JOIN tb_m_user usr ON usr.id_user=doc.id_user_upload
                LEFT JOIN tb_m_employee emp ON emp.id_employee=usr.id_employee
                WHERE doc.report_mark_type='" & rmt & "' AND doc.id_report='" & id & "' AND doc.id_user_upload = (SELECT id_user FROM tb_report_mark WHERE id_report_status = '1' AND id_report = '" & id & "' AND report_mark_type = '" & rmt & "')
            ", -1, True, "", "", "", "")

            Dim path As String = Application.StartupPath & "\download\"

            'create directory if not exist
            If Not IO.Directory.Exists(path) Then
                System.IO.Directory.CreateDirectory(path)
            End If

            Dim x As Integer = 0
            Dim y As Integer = 0

            For i = 0 To data_image.Rows.Count - 1
                If data_image.Rows(i)("is_encrypted").ToString = "1" Then
                    Dim p_file As String = path & data_image.Rows(i)("doc_desc").ToString & "_" & data_image.Rows(i)("filename").ToString

                    CryptFile.DecryptFile(get_setup_field("en_phrase"), source_path & rmt & "\" & data_image.Rows(i)("filename").ToString, p_file)

                    If i = 0 Then
                        report.XrPictureBox.ImageUrl = p_file
                    Else
                        Dim pb As DevExpress.XtraReports.UI.XRPictureBox = New DevExpress.XtraReports.UI.XRPictureBox

                        pb.Sizing = DevExpress.XtraPrinting.ImageSizeMode.StretchImage

                        pb.HeightF = report.XrPictureBox.HeightF
                        pb.WidthF = report.XrPictureBox.WidthF

                        pb.ImageUrl = p_file

                        Dim n As Integer = i Mod 2

                        If n = 0 Then
                            y = y + report.XrPictureBox.HeightF + 10
                            x = 0
                        Else
                            x = report.XrPictureBox.WidthF + 10
                        End If

                        pb.LocationF = New PointF(x, y)

                        report.XPLampiran.Controls.Add(pb)
                    End If

                End If
            Next

            Dim tool As DevExpress.XtraReports.UI.ReportPrintTool = New DevExpress.XtraReports.UI.ReportPrintTool(report)

            tool.ShowPreview()
        End If
    End Sub

    Private Sub BtnConfirm_Click(sender As Object, e As EventArgs) Handles BtnConfirm.Click
        Dim confirm As DialogResult = DevExpress.XtraEditors.XtraMessageBox.Show("Are you sure you want to confirm this request?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
        If confirm = Windows.Forms.DialogResult.Yes Then
            updateHeader()

            'update confirm
            Dim query As String = "UPDATE tb_ol_store_ret_req SET is_confirm=1 WHERE id_ol_store_ret_req='" + id + "'"
            execute_non_query(query, True, "", "", "", "")

            'submit approval 
            submit_who_prepared(rmt, id, id_user)
            BtnConfirm.Visible = False
            FormOlStoreReturnList.viewRequest()
            FormOlStoreReturnList.GVRequest.FocusedRowHandle = find_row(FormOlStoreReturnList.GVRequest, "id_ol_store_ret_req", id)
            action = "upd"
            actionLoad()
            infoCustom("Request submitted. Waiting for approval.")
        End If
    End Sub

    Private Sub BtnResetPropose_Click(sender As Object, e As EventArgs) Handles BtnResetPropose.Click
        Dim query As String = "SELECT * FROM tb_report_mark rm WHERE rm.report_mark_type=" + rmt + " AND rm.id_report_status=2 
        AND rm.is_requisite=2 AND rm.id_mark=2 AND rm.id_report=" + id + " "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        If data.Rows.Count = 0 Then
            Dim confirm As DialogResult = DevExpress.XtraEditors.XtraMessageBox.Show("This action will be reset approval and you can update this propose. Are you sure you want to reset this propose ?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
            If confirm = Windows.Forms.DialogResult.Yes Then
                Dim query_upd As String = "-- delete report mark
                DELETE FROM tb_report_mark WHERE report_mark_type=" + rmt + " AND id_report=" + id + "; 
                -- reset confirm
                UPDATE tb_ol_store_ret_req SET is_confirm=2 WHERE id_ol_store_ret_req=" + id + "; "
                execute_non_query(query_upd, True, "", "", "", "")

                'refresh
                FormFGProposePrice.viewPropose()
                FormFGProposePrice.GVFGPropose.FocusedRowHandle = find_row(FormFGProposePrice.GVFGPropose, "id_fg_propose_price", id)
                actionLoad()
            End If
        Else
            stopCustom("This propose already process")
        End If
    End Sub
End Class