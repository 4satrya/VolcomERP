Public Class FormSalesOrderGen
    Public action As String = "-1"
    Public id_sales_order_gen As String = "-1"
    Dim is_submit As String = "2"
    Public id_report_status As String = "-1"
    Public id_pre As String = "-1"

    Private Sub FormSalesOrderGen_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        viewSoStatus()
        viewReportStatus()
        actionLoad()
        WindowState = FormWindowState.Maximized
    End Sub

    Sub viewSoStatus()
        Dim query As String = "SELECT a.id_so_status, a.so_status FROM tb_lookup_so_status a "
        query += "INNER JOIN tb_lookup_so_status_acc b ON a.id_so_status = b.id_so_status "
        query += "WHERE b.id_departement='" + id_departement_user + "' "
        query += "ORDER BY a.id_so_status "
        viewLookupQuery(LEStatusSO, query, 0, "so_status", "id_so_status")
    End Sub

    Sub viewReportStatus()
        Dim query As String = "SELECT * FROM tb_lookup_report_status a ORDER BY a.id_report_status "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        viewLookupQuery(LEReportStatus, query, 0, "report_status", "id_report_status")
    End Sub

    Sub actionLoad()
        If action = "ins" Then
            GroupControlItemList.Enabled = False
            BMark.Enabled = False
            DDBPrint.Enabled = False
            BtnAttachment.Enabled = False
            DEForm.Text = view_date(0)
            BtnSave.Text = "Create New"
        ElseIf action = "upd" Then
            GroupControlItemList.Enabled = True
            DDBPrint.Enabled = True
            BtnAttachment.Enabled = True
            BtnSave.Text = "Save Changes"

            'query view based on edit id's
            Dim query_c As ClassSalesOrder = New ClassSalesOrder()
            Dim query As String = query_c.queryMainGen("AND gen.id_sales_order_gen='" + id_sales_order_gen + "' ", "2")
            Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
            id_sales_order_gen = data.Rows(0)("id_sales_order_gen").ToString
            id_report_status = data.Rows(0)("id_report_status").ToString
            LEReportStatus.ItemIndex = LEReportStatus.Properties.GetDataSourceRowIndex("id_report_status", data.Rows(0)("id_report_status").ToString)
            LEStatusSO.ItemIndex = LEStatusSO.Properties.GetDataSourceRowIndex("id_so_status", data.Rows(0)("id_so_status").ToString)
            TxtReff.Text = data.Rows(0)("sales_order_gen_reff").ToString
            DEForm.Text = view_date_from(data.Rows(0)("sales_order_gen_datex").ToString, 0)
            MENote.Text = data.Rows(0)("sales_order_gen_note").ToString
            is_submit = data.Rows(0)("is_submit").ToString

            If is_submit = "1" Then
                TxtReff.Enabled = False
                BMark.Enabled = True
                LEStatusSO.Enabled = False
            Else
                TxtReff.Enabled = True
                BMark.Enabled = False
                LEStatusSO.Enabled = True
            End If

            'detail2
            viewDetail()
            check_but()
            allow_status()

            If id_pre = "1" Then
                prePrinting()
                Close()
            ElseIf id_pre = "2" Then
                Printing()
                Close()
            End If
        End If
    End Sub

    Sub viewDetail()
        Dim query As String = "CALL view_sales_order_gen(" + id_sales_order_gen + ")"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCItemList.DataSource = data

        If is_submit = "2" Then
            'sum
            Dim query_sum As String = "CALL view_sales_order_gen_sum(" + id_sales_order_gen + ")"
            Dim data_sum As DataTable = execute_query(query_sum, -1, True, "", "", "", "")

            Dim query_stock As String = "CALL view_sales_order_prod_list(0, 0, 0)"
            Dim data_stock As DataTable = execute_query(query_stock, -1, True, "", "", "", "")
            Dim tb1 = data_sum.AsEnumerable() 'sum
            Dim tb2 = data_stock.AsEnumerable() 'allow stock fo so

            Dim queryx = From sum In tb1 'left join sum dgn stock menjadi stockjoin
                         Group Join stc In tb2
                         On sum("code") Equals stc("product_full_code") And sum("id_comp_from") Equals stc("id_comp") Into stcjoin = Group
                         From resultstc In stcjoin.DefaultIfEmpty()
                         Select New With
                                {
                                    .code = sum("code").ToString,
                                    .id_product = If(resultstc Is Nothing, "", resultstc("id_product").ToString),
                                    .name = If(resultstc Is Nothing, "", resultstc("design_display_name").ToString),
                                    .size = If(resultstc Is Nothing, "", resultstc("Size").ToString),
                                    .comp_from = If(resultstc Is Nothing, "", resultstc("comp_number").ToString + " - " + resultstc("comp_name").ToString),
                                    .id_comp_from = If(resultstc Is Nothing, "", resultstc("id_comp").ToString),
                                    .id_comp_contact_from = If(resultstc Is Nothing, "", resultstc("id_comp_contact").ToString),
                                    .id_design_price = If(resultstc Is Nothing, "", resultstc("id_design_price").ToString),
                                    .design_price = If(resultstc Is Nothing, "", resultstc("design_price")),
                                    .sales_order_gen_det_qty = sum("sales_order_gen_det_qty"),
                                    .total_allow = If(resultstc Is Nothing, 0, resultstc("total_allow")),
                                    .note = If(resultstc Is Nothing Or sum("sales_order_gen_det_qty") > If(resultstc Is Nothing, 0, resultstc("total_allow")), If(resultstc Is Nothing, "This product is not available for prepare order; ", "") + If(sum("sales_order_gen_det_qty") > If(resultstc Is Nothing, 0, resultstc("total_allow")), "Qty can't exceed " + If(resultstc Is Nothing, 0, resultstc("total_allow")).ToString + ";", ""), "OK")
                                }

            GCSummary.DataSource = queryx.ToList()
            XTPSummary.PageVisible = True
            XTPOrder.PageVisible = False
        Else
            Dim view_reff As New ClassSalesOrder()
            view_reff.viewReff(id_sales_order_gen, "-1", GCNewPrepare, GVNewPrepare)
            XTPSummary.PageVisible = False
            XTPOrder.PageVisible = True
        End If
    End Sub

    Sub check_but()
        Dim id_productx As String = "0"
        Try
            id_productx = GVItemList.GetFocusedRowCellValue("id_product").ToString
        Catch ex As Exception
        End Try
    End Sub

    Sub allow_status()
        If check_edit_report_status(id_report_status, "88", id_sales_order_gen) And is_submit = "2" Then
            MENote.Enabled = True
            BtnSave.Enabled = True
            PanelNavBarcode.Enabled = True
        Else
            MENote.Enabled = False
            BtnSave.Enabled = False
            PanelNavBarcode.Enabled = False
        End If

        'ATTACH
        If check_attach_report_status(id_report_status, "88", id_sales_order_gen) Then
            BtnAttachment.Enabled = True
        Else
            BtnAttachment.Enabled = False
        End If

        If check_pre_print_report_status(id_report_status) Then
            BtnPrePrinting.Enabled = True
        Else
            BtnPrePrinting.Enabled = False
        End If

        If check_print_report_status(id_report_status) Then
            BtnPrinting.Enabled = True
        Else
            BtnPrinting.Enabled = False
        End If
        TxtReff.Focus()
    End Sub

    Private Sub BtnCancel_Click(sender As Object, e As EventArgs) Handles BtnCancel.Click
        Close()
    End Sub

    Private Sub FormFGWHAllocDet_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub BMark_Click(sender As Object, e As EventArgs) Handles BMark.Click
        Cursor = Cursors.WaitCursor
        FormReportMark.report_mark_type = "88"
        FormReportMark.id_report = id_sales_order_gen
        FormReportMark.form_origin = Name
        FormReportMark.ShowDialog()
        Cursor = Cursors.Default
    End Sub

    Private Sub BtnAttachment_Click(sender As Object, e As EventArgs) Handles BtnAttachment.Click
        Cursor = Cursors.WaitCursor
        FormDocumentUpload.report_mark_type = "88"
        FormDocumentUpload.id_report = id_sales_order_gen
        FormDocumentUpload.ShowDialog()
        Cursor = Cursors.Default
    End Sub

    Private Sub GVItemList_CustomColumnDisplayText(sender As Object, e As DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs) Handles GVItemList.CustomColumnDisplayText
        If e.Column.FieldName = "no" Then
            e.DisplayText = (e.ListSourceRowIndex + 1).ToString()
        End If
    End Sub

    Private Sub BtnImport_Click(sender As Object, e As EventArgs) Handles BtnImport.Click
        Cursor = Cursors.WaitCursor
        FormImportExcel.id_pop_up = "21"
        FormImportExcel.ShowDialog()
        Cursor = Cursors.Default
    End Sub

    Private Sub GVSummary_CustomColumnDisplayText(sender As Object, e As DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs) Handles GVSummary.CustomColumnDisplayText
        If e.Column.FieldName = "no" Then
            e.DisplayText = (e.ListSourceRowIndex + 1).ToString()
        End If
    End Sub

    Sub getReport()
        Cursor = Cursors.WaitCursor
        ReportSalesOrderGen.id_sales_order_gen = id_sales_order_gen
        ReportSalesOrderGen.dt = GCNewPrepare.DataSource
        Dim Report As New ReportSalesOrderGen()

        ' '... 
        ' ' creating and saving the view's layout to a new memory stream 
        Dim str As System.IO.Stream
        str = New System.IO.MemoryStream()
        GVNewPrepare.SaveLayoutToStream(str, DevExpress.Utils.OptionsLayoutBase.FullLayout)
        str.Seek(0, System.IO.SeekOrigin.Begin)
        Report.GVNewPrepare.RestoreLayoutFromStream(str, DevExpress.Utils.OptionsLayoutBase.FullLayout)
        str.Seek(0, System.IO.SeekOrigin.Begin)

        'Grid Detail
        ReportStyleBanded(Report.GVNewPrepare)

        'Parse val
        Report.LabelNumber.Text = TxtReff.Text.ToString
        Report.LabelCat.Text = LEStatusSO.Text.ToString
        Report.LabelNote.Text = MENote.Text

        ' Show the report's preview. 
        Dim Tool As DevExpress.XtraReports.UI.ReportPrintTool = New DevExpress.XtraReports.UI.ReportPrintTool(Report)
        Tool.ShowPreview()
        Cursor = Cursors.Default
    End Sub

    Sub prePrinting()
        Cursor = Cursors.WaitCursor
        ReportSalesOrderGen.id_pre = "1"
        getReport()
        Cursor = Cursors.Default
    End Sub

    Sub printing()
        Cursor = Cursors.WaitCursor
        ReportSalesOrderGen.id_pre = "-1"
        getReport()
        Cursor = Cursors.Default
    End Sub

    Private Sub BtnPrint_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BtnPrinting.ItemClick
        Cursor = Cursors.WaitCursor
        printing()
        Cursor = Cursors.Default
    End Sub

    Private Sub BtnPrePrinting_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BtnPrePrinting.ItemClick
        Cursor = Cursors.WaitCursor
        prePrinting()
        Cursor = Cursors.Default
    End Sub

    Private Sub BtnDelete_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub BtnSave_Click(sender As Object, e As EventArgs) Handles BtnSave.Click
        If TxtReff.Text.ToString = "" Then
            stopCustom("Reference number can't blank !")
        Else
            Dim sales_order_gen_reff As String = addSlashes(TxtReff.Text.ToString)
            Dim sales_order_gen_note As String = addSlashes(MENote.Text.ToString)
            Dim id_so_status As String = LEStatusSO.EditValue.ToString
            If action = "ins" Then
                Cursor = Cursors.WaitCursor
                'query main
                Dim query As String = "INSERT INTO tb_sales_order_gen(id_so_status, sales_order_gen_reff, sales_order_gen_date, id_report_status, sales_order_gen_note, is_submit, id_user) "
                query += "VALUES ('" + id_so_status + "', '" + sales_order_gen_reff + "', NOW(), '1', '" + MENote.Text + "', '2', '" + id_user + "'); SELECT LAST_INSERT_ID(); "
                id_sales_order_gen = execute_query(query, 0, True, "", "", "", "")

                action = "upd"
                actionLoad()
                FormSalesOrder.viewSalesOrderGen()
                FormSalesOrder.GVGen.FocusedRowHandle = find_row(FormSalesOrder.GVGen, "id_sales_order_gen", id_sales_order_gen)
                infoCustom("Document #" + TxtReff.Text + " was created succesfully.")
                Cursor = Cursors.Default
            ElseIf action = "upd" Then
                Cursor = Cursors.WaitCursor

                'change tab
                XtraTabControl1.SelectedTabPageIndex = 1

                'check stock again
                viewDetail()

                'find <> OK
                Dim cond_ok As Boolean = True
                GVSummary.ActiveFilterString = "[note]<>'OK' "
                If GVSummary.RowCount > 0 Then
                    cond_ok = False
                End If
                GVSummary.ActiveFilterString = ""
                GCSummary.RefreshDataSource()
                GVSummary.RefreshData()

                'check empty
                Dim cond_gv As Boolean = True
                If GVSummary.RowCount <= 0 Then
                    cond_gv = False
                End If


                If Not cond_ok Then
                    stopCustom("Some item can't exceed qty limit, please see error in column note!")
                ElseIf Not cond_gv Then
                    stopCustom("Item list can't blank, please input your order !")
                Else
                    Dim confirmx As DialogResult = DevExpress.XtraEditors.XtraMessageBox.Show("Qty order will be updated after this process. Are you sure to continue this process?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
                    If confirmx = Windows.Forms.DialogResult.Yes Then
                        Cursor = Cursors.WaitCursor

                        'created so
                        Dim query_main_view As String = "SELECT a.id_comp_contact_from, a.id_comp_contact_to, IFNULL(comp.id_so_type,0) AS `id_so_type`, IF(comp.id_comp_cat=6,'1', '5') `id_so_status` "
                        query_main_view += "FROM tb_sales_order_gen_det a "
                        query_main_view += "INNER JOIN tb_m_comp_contact cc ON cc.id_comp_contact = a.id_comp_contact_to "
                        query_main_view += "INNER JOIN tb_m_comp comp ON comp.id_comp = cc.id_comp "
                        query_main_view += "WHERE a.id_sales_order_gen='" + id_sales_order_gen + "' "
                        query_main_view += "GROUP BY a.id_comp_contact_from, a.id_comp_contact_to "
                        Dim data_main_view As DataTable = execute_query(query_main_view, -1, True, "", "", "", "")
                        If data_main_view.Rows.Count > 0 Then
                            PBC.Properties.Minimum = 0
                            PBC.Properties.Maximum = data_main_view.Rows.Count - 1
                            PBC.Properties.Step = 1
                        End If
                        For i As Integer = 0 To data_main_view.Rows.Count - 1
                            Dim query_so_main As String = "INSERT INTO tb_sales_order(id_sales_order_gen, id_store_contact_to, id_warehouse_contact_to, sales_order_number, sales_order_date, sales_order_note, id_so_type, id_so_status, id_report_status, id_prepare_status, id_user_created) "
                            query_so_main += "VALUES('" + id_sales_order_gen + "', '" + data_main_view.Rows(i)("id_comp_contact_to").ToString + "', '" + data_main_view.Rows(i)("id_comp_contact_from").ToString + "', '" + header_number_sales("2") + "', NOW(), '', '" + data_main_view.Rows(i)("id_so_type").ToString + "', '" + data_main_view.Rows(i)("id_so_status").ToString + "', '1','1', '" + id_user + "'); SELECT LAST_INSERT_ID(); "
                            Dim id_so_created As String = execute_query(query_so_main, 0, True, "", "", "", "")

                            'insert who prepared
                            increase_inc_sales("2")

                            'insert detail
                            Dim query_so_det As String = "INSERT INTO tb_sales_order_det(id_sales_order, id_product, id_design_price, design_price, sales_order_det_qty, sales_order_det_note) "
                            query_so_det += "SELECT " + id_so_created + ", det.id_product, prc.id_design_price, prc.design_price, det.sales_order_gen_det_qty, '' "
                            query_so_det += "FROM tb_sales_order_gen_det det "
                            query_so_det += "INNER JOIN tb_m_product prod ON prod.id_product = det.id_product "
                            query_so_det += "LEFT JOIN ( "
                            query_so_det += "SELECT * FROM ( "
                            query_so_det += "SELECT price.id_design, price.design_price, price.design_price_date, price.id_design_price, price_type.design_price_type "
                            query_so_det += "FROM tb_m_design_price price "
                            query_so_det += "INNER JOIN tb_lookup_design_price_type price_type  "
                            query_so_det += "ON price.id_design_price_type = price_type.id_design_price_type "
                            query_so_det += "INNER JOIN tb_lookup_currency curr ON curr.id_currency = price.id_currency "
                            query_so_det += "INNER JOIN tb_m_user `user` ON user.id_user = price.id_user "
                            query_so_det += "INNER JOIN tb_m_employee emp ON emp.id_employee = user.id_employee "
                            query_so_det += "WHERE price.is_active_wh='1' AND price.design_price_start_date <= NOW() "
                            query_so_det += "ORDER BY price.design_price_start_date DESC ) a "
                            query_so_det += "GROUP BY a.id_design "
                            query_so_det += ") prc ON prc.id_design = prod.id_design "
                            query_so_det += "WHERE det.id_sales_order_gen = '" + id_sales_order_gen + "' AND det.id_comp_contact_from='" + data_main_view.Rows(i)("id_comp_contact_from").ToString + "' AND det.id_comp_contact_to='" + data_main_view.Rows(i)("id_comp_contact_to").ToString + "' AND det.sales_order_gen_det_qty>0 "
                            execute_non_query(query_so_det, True, "", "", "", "")

                            'reserved stock
                            Dim rsv As New ClassSalesOrder()
                            rsv.reservedStock(id_so_created)

                            PBC.PerformStep()
                            PBC.Update()
                        Next

                        'query main upd
                        Dim query_update_main As String = "UPDATE tb_sales_order_gen SET sales_order_gen_note='" + sales_order_gen_note + "', is_submit='1' WHERE id_sales_order_gen='" + id_sales_order_gen + "' "
                        execute_non_query(query_update_main, True, "", "", "", "")

                        'submit mark
                        submit_who_prepared("88", id_sales_order_gen, id_user)

                        action = "upd"
                        actionLoad()
                        FormSalesOrder.viewSalesOrderGen()
                        'FormSalesOrder.viewSalesOrder()
                        FormSalesOrder.GVGen.FocusedRowHandle = find_row(FormSalesOrder.GVGen, "id_sales_order_gen", id_sales_order_gen)
                        infoCustom("Document #" + TxtReff.Text + " was edited succesfully.")
                        Cursor = Cursors.Default
                    End If
                End If
                Cursor = Cursors.Default
            End If
        End If
    End Sub

    Private Sub GVNewPrepare_CustomColumnDisplayText(sender As Object, e As DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs) Handles GVNewPrepare.CustomColumnDisplayText
        If e.Column.FieldName = "NO" Then
            e.DisplayText = (e.ListSourceRowIndex + 1).ToString()
        End If
    End Sub

    Private Sub BtnImportNew_Click(sender As Object, e As EventArgs) Handles BtnImportNew.Click
        Cursor = Cursors.WaitCursor
        FormImportExcel.id_pop_up = "23"
        FormImportExcel.ShowDialog()
        Cursor = Cursors.Default
    End Sub
End Class