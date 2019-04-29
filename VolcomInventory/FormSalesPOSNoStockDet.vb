Public Class FormSalesPOSNoStockDet
    Public id As String = "-1"
    Public action As String = ""
    Dim id_report_status As String = "-1"
    Public id_comp As String = "-1"
    Public is_view As String = "-1"
    Dim created_date As String = ""
    Public is_from_inv As String = "-1"

    Private Sub FormSalesPOSNoStockDet_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        viewReportStatus()
        actionLoad()
    End Sub

    Sub viewReportStatus()
        Dim query As String = "SELECT * FROM tb_lookup_report_status a ORDER BY a.id_report_status "
        'Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        viewLookupQuery(LEReportStatus, query, 0, "report_status", "id_report_status")
    End Sub

    Sub actionLoad()
        If action = "ins" Then
            'REQ detail
            TxtNumber.Text = "[auto generate]"
            DECreated.EditValue = getTimeDB()
            viewDetail()

            'load from invoice
            If is_from_inv = "1" Then
                BtnBrowse.Enabled = False
                id_comp = FormSalesPOSDet.id_comp
                TxtCompNumber.Text = FormSalesPOSDet.TxtCodeCompFrom.Text
                TxtCompName.Text = FormSalesPOSDet.TxtNameCompFrom.Text
                DEStart.EditValue = FormSalesPOSDet.DEStart.EditValue
                DEEnd.EditValue = FormSalesPOSDet.DEEnd.EditValue
                DEStart.Enabled = False
                DEEnd.Enabled = False

                'load detail
                For i As Integer = 0 To ((FormSalesPOSDet.GVItemList.RowCount - 1) - GetGroupRowCount(FormSalesPOSDet.GVItemList))
                    Dim newRow As DataRow = (TryCast(GCData.DataSource, DataTable)).NewRow()
                    newRow("id_product") = FormSalesPOSDet.GVItemList.GetRowCellValue(i, "id_product").ToString
                    newRow("code") = FormSalesPOSDet.GVItemList.GetRowCellValue(i, "code").ToString
                    newRow("name") = FormSalesPOSDet.GVItemList.GetRowCellValue(i, "name").ToString
                    newRow("size") = FormSalesPOSDet.GVItemList.GetRowCellValue(i, "size").ToString
                    newRow("id_design_price") = FormSalesPOSDet.GVItemList.GetRowCellValue(i, "id_design_price_retail").ToString
                    newRow("design_price") = FormSalesPOSDet.GVItemList.GetRowCellValue(i, "design_price_retail")
                    newRow("qty") = FormSalesPOSDet.GVItemList.GetRowCellValue(i, "sales_pos_det_qty")
                    newRow("note") = ""
                    TryCast(GCData.DataSource, DataTable).Rows.Add(newRow)
                    GCData.RefreshDataSource()
                    GVData.RefreshData()
                Next

                'editing
                GVData.OptionsBehavior.Editable = True
                GridColumn4.OptionsColumn.AllowEdit = True
                GridColumn7.OptionsColumn.AllowEdit = True
            End If
        Else
            Dim ns As New ClassSalesPOS()
            Dim query As String = ns.queryMainNoStock("AND ns.id_sales_pos_no_stock='" + id + "' ", "1")
            Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")

            id_report_status = data.Rows(0)("id_report_status").ToString
            TxtNumber.Text = data.Rows(0)("number").ToString
            created_date = DateTime.Parse(data.Rows(0)("created_date")).ToString("yyyy-MM-dd HH:mm:ss")
            DECreated.EditValue = data.Rows(0)("created_date")
            MENote.Text = data.Rows(0)("note").ToString
            DEStart.EditValue = data.Rows(0)("period_from")
            DEEnd.EditValue = data.Rows(0)("period_until")
            LEReportStatus.ItemIndex = LEReportStatus.Properties.GetDataSourceRowIndex("id_report_status", data.Rows(0)("id_report_status").ToString)
            id_comp = data.Rows(0)("id_comp").ToString
            TxtCompNumber.Text = data.Rows(0)("comp_number").ToString
            TxtCompName.Text = data.Rows(0)("comp_name").ToString

            viewDetail()
            allow_status()
        End If
    End Sub

    Sub viewDetail()
        Dim query As String = "SELECT nsd.id_sales_pos_no_stock_det, nsd.id_sales_pos_no_stock, nsd.id_product, prod.product_full_code AS `code`, dsg.design_display_name AS `name`, cd.code_detail_name AS `size`,
        nsd.qty, nsd.id_design_price, nsd.design_price, nsd.note
        FROM tb_sales_pos_no_stock_det nsd
        INNER JOIN tb_m_product prod ON prod.id_product = nsd.id_product
        INNER JOIN tb_m_product_code pc ON pc.id_product = prod.id_product
        INNER JOIN tb_m_code_detail cd ON cd.id_code_detail = pc.id_code_detail
        INNER JOIN tb_m_design dsg ON dsg.id_design = prod.id_design
        WHERE nsd.id_sales_pos_no_stock=" + id + " "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCData.DataSource = data
        GVData.BestFitColumns()
    End Sub

    Sub allow_status()
        BtnCancell.Visible = True
        BtnMark.Visible = True
        BtnAttachment.Visible = True
        BtnPrint.Visible = True
        GVData.OptionsBehavior.Editable = False
        PanelControlNav.Visible = False
        BtnBrowse.Enabled = False
        BtnSave.Visible = False
        MENote.Enabled = False
        DEStart.Enabled = False
        DEEnd.Enabled = False

        If id_report_status = "6" Then
            BtnCancell.Visible = True
            BtnPrint.Visible = True
        ElseIf id_report_status = "5" Then
            BtnCancell.Visible = False
            BtnPrint.Visible = False
        End If

        If FormSalesPOSNoStock.id_menu = "2" Then
            BtnCancell.Visible = False
        End If
    End Sub

    Private Sub FormSalesPOSNoStockDet_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub


    Function checkVerify() As Boolean
        Dim query As String = "SELECT * FROM tb_sales_pos_no_stock_det d WHERE d.id_sales_pos_no_stock=" + id + " AND d.is_verified=1 "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        If data.Rows.Count > 0 Then
            Return True
        Else
            Return False
        End If
    End Function

    Private Sub BtnCancell_Click(sender As Object, e As EventArgs) Handles BtnCancell.Click
        Dim is_verified As Boolean = checkVerify()
        If Not is_verified Then
            Dim confirm As DialogResult = DevExpress.XtraEditors.XtraMessageBox.Show("Are you sure you want to cancell this process ?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
            If confirm = Windows.Forms.DialogResult.Yes Then
                Cursor = Cursors.WaitCursor
                'update status
                Dim query As String = "UPDATE tb_sales_pos_no_stock SET id_report_status=5 WHERE id_sales_pos_no_stock='" + id + "'"
                execute_non_query(query, True, "", "", "", "")

                'nonaktif mark
                Dim queryrm = String.Format("UPDATE tb_report_mark SET report_mark_lead_time=NULL,report_mark_start_datetime=NULL WHERE report_mark_type='{0}' AND id_report='{1}' AND id_report_status>'1'", 158, id, "5")
                execute_non_query(queryrm, True, "", "", "", "")

                'refresh
                FormSalesPOSNoStock.viewData()
                FormSalesPOSNoStock.GVData.FocusedRowHandle = find_row(FormSalesPOSNoStock.GVData, "id_sales_pos_no_stock", id)
                actionLoad()
                Cursor = Cursors.Default
            End If
        Else
            warningCustom("Can't cancel because this transaction is being verified.")
        End If
    End Sub

    Private Sub BtnPrint_Click(sender As Object, e As EventArgs) Handles BtnPrint.Click
        Cursor = Cursors.WaitCursor
        If id_report_status = "6" Then
            'Dim gcx As DevExpress.XtraGrid.GridControl = Nothing
            'Dim gvx As DevExpress.XtraGrid.Views.Grid.GridView = Nothing
            'gcx = GCData
            'gvx = GVData
            'ReportItemReq.id = id
            'ReportItemReq.dt = gcx.DataSource
            'Dim Report As New ReportItemReq()

            '... 
            ' ' creating and saving the view's layout to a new memory stream 
            'Dim str As System.IO.Stream
            'str = New System.IO.MemoryStream()
            'gvx.SaveLayoutToStream(str, DevExpress.Utils.OptionsLayoutBase.FullLayout)
            'str.Seek(0, System.IO.SeekOrigin.Begin)
            'Report.GVData.RestoreLayoutFromStream(str, DevExpress.Utils.OptionsLayoutBase.FullLayout)
            'str.Seek(0, System.IO.SeekOrigin.Begin)

            'Grid Detail
            'ReportStyleGridview(Report.GVData)

            '    'Parse val
            'Report.LabelNumber.Text = TxtNumber.Text.ToUpper
            'Report.LabelDept.Text = TxtDept.Text.ToUpper
            'Report.LabelDate.Text = DECreated.Text.ToString
            'Report.LNote.Text = MENote.Text.ToString


            'Show the report's preview. 
            'Dim Tool As DevExpress.XtraReports.UI.ReportPrintTool = New DevExpress.XtraReports.UI.ReportPrintTool(Report)
            'Tool.ShowPreviewDialog()
        Else
            print_raw_no_export(GCData)
        End If
        Cursor = Cursors.Default
    End Sub

    Private Sub BtnAttachment_Click(sender As Object, e As EventArgs) Handles BtnAttachment.Click
        attach
    End Sub

    Sub attach()
        Cursor = Cursors.WaitCursor
        FormDocumentUpload.report_mark_type = "158"
        FormDocumentUpload.id_report = id
        Dim is_verified As Boolean = checkVerify()
        If is_verified Or id_report_status = "5" Then
            FormDocumentUpload.is_view = "1"
        End If
        FormDocumentUpload.ShowDialog()
        Cursor = Cursors.Default
    End Sub

    Private Sub BtnMark_Click(sender As Object, e As EventArgs) Handles BtnMark.Click
        Cursor = Cursors.WaitCursor
        FormReportMark.report_mark_type = "158"
        FormReportMark.id_report = id
        FormReportMark.form_origin = Name
        FormReportMark.ShowDialog()
        Cursor = Cursors.Default
    End Sub

    Private Sub GVData_CustomColumnDisplayText(sender As Object, e As DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs) Handles GVData.CustomColumnDisplayText
        If e.Column.FieldName = "no" Then
            e.DisplayText = (e.ListSourceRowIndex + 1).ToString()
        End If
    End Sub

    Private Sub BtnAdd_Click(sender As Object, e As EventArgs) Handles BtnAdd.Click
        Cursor = Cursors.WaitCursor
        FormSalesPOSNoStockAdd.ShowDialog()
        Cursor = Cursors.Default
    End Sub

    Private Sub BtnDelete_Click(sender As Object, e As EventArgs) Handles BtnDelete.Click
        If GVData.RowCount > 0 And GVData.FocusedRowHandle >= 0 Then
            Dim confirm As DialogResult = DevExpress.XtraEditors.XtraMessageBox.Show("Are you sure you want to delete this item ?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
            If confirm = Windows.Forms.DialogResult.Yes Then
                Cursor = Cursors.WaitCursor
                GVData.DeleteRow(GVData.FocusedRowHandle)
                CType(GCData.DataSource, DataTable).AcceptChanges()
                GCData.RefreshDataSource()
                GVData.RefreshData()
                Cursor = Cursors.Default
            End If
        End If
    End Sub

    Private Sub BtnBrowse_Click(sender As Object, e As EventArgs) Handles BtnBrowse.Click
        Cursor = Cursors.WaitCursor
        FormPopUpContact.id_pop_up = "89"
        FormPopUpContact.ShowDialog()
        Cursor = Cursors.Default
    End Sub

    Private Sub DEStart_EditValueChanged(sender As Object, e As EventArgs) Handles DEStart.EditValueChanged
        Try
            DEEnd.Properties.MinValue = DEStart.EditValue
        Catch ex As Exception
        End Try
    End Sub

    Private Sub DEStart_KeyDown(sender As Object, e As KeyEventArgs) Handles DEStart.KeyDown
        If e.KeyCode = Keys.Enter Then
            DEEnd.Focus()
        End If
    End Sub

    Private Sub BtnSave_Click(sender As Object, e As EventArgs) Handles BtnSave.Click
        makeSafeGV(GVData)
        If GVData.Columns("qty").SummaryItem.SummaryValue <= 0 Or DEStart.EditValue = Nothing Or DEEnd.EditValue = Nothing Or id_comp = "-1" Then
            warningCustom("Please complete all data")
        Else
            Dim confirm As DialogResult = DevExpress.XtraEditors.XtraMessageBox.Show("Are you sure you want to continue this process?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
            If confirm = Windows.Forms.DialogResult.Yes Then
                Cursor = Cursors.WaitCursor
                BtnSave.Enabled = False
                Dim period_from As String = DateTime.Parse(DEStart.EditValue.ToString).ToString("yyyy-MM-dd")
                Dim period_until As String = DateTime.Parse(DEEnd.EditValue.ToString).ToString("yyyy-MM-dd")
                Dim note As String = addSlashes(MENote.Text)

                'query main
                Dim qm As String = "INSERT INTO tb_sales_pos_no_stock(id_comp, created_date,created_by, period_from, period_until, note, id_report_status) VALUES
                ('" + id_comp + "', NOW(), '" + id_user + "', '" + period_from + "', '" + period_until + "', '" + note + "', 6); SELECT LAST_INSERT_ID(); "
                id = execute_query(qm, 0, True, "", "", "", "")
                execute_non_query("CALL gen_number(" + id + ",158); ", True, "", "", "", "")

                'query det
                Dim qd As String = "INSERT INTO tb_sales_pos_no_stock_det(id_sales_pos_no_stock, id_product, id_design_price, design_price, qty, note) VALUES "
                For d As Integer = 0 To ((GVData.RowCount - 1) - GetGroupRowCount(GVData))
                    Dim id_product As String = GVData.GetRowCellValue(d, "id_product").ToString
                    Dim id_design_price As String = GVData.GetRowCellValue(d, "id_design_price").ToString
                    Dim design_price As String = decimalSQL(GVData.GetRowCellValue(d, "design_price").ToString)
                    Dim qty As String = decimalSQL(GVData.GetRowCellValue(d, "qty").ToString)
                    Dim note_detail As String = addSlashes(GVData.GetRowCellValue(d, "note").ToString)

                    If d > 0 Then
                        qd += ", "
                    End If
                    qd += "('" + id + "', '" + id_product + "', '" + id_design_price + "', '" + design_price + "', '" + qty + "', '" + note_detail + "') "
                Next
                If GVData.RowCount > 0 Then
                    execute_non_query(qd, True, "", "", "", "")
                End If

                'submit
                submit_who_prepared(158, id, id_user)

                'refresh
                action = "upd"
                actionLoad()
                FormSalesPOSNoStock.viewData()
                FormSalesPOSNoStock.GVData.FocusedRowHandle = find_row(FormSalesPOSNoStock.GVData, "id_sales_pos_no_stock", id)
                infoCustom("Transaction : " + TxtNumber.Text.ToString + " was created successfully")
                Cursor = Cursors.Default
            End If
        End If
    End Sub
End Class