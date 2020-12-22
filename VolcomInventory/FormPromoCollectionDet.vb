Public Class FormPromoCollectionDet
    Public action As String = "-1"
    Public id As String = "-1"
    Public is_view As String = "-1"
    Dim id_report_status As String = "-1"
    Dim is_confirm As String = "-1"
    Dim rmt As String = "250"
    Public dt As DataTable
    Dim is_use_discount_code As String = "-1"
    Dim id_price_rule As String = "-1"

    Private Sub FormPromoCollectionDet_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        viewReportStatus()
        viewPromoType()
        viewDiscountCodeList()
        actionLoad()
    End Sub

    Private Sub FormPromoCollectionDet_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Sub viewReportStatus()
        Dim query As String = "SELECT * FROM tb_lookup_report_status a ORDER BY a.id_report_status "
        viewLookupQuery(LEReportStatus, query, 0, "report_status", "id_report_status")
    End Sub

    Sub viewPromoType()
        Dim query As String = "SELECT p.id_promo, p.promo FROM tb_promo p ORDER BY p.promo DESC "
        viewSearchLookupQuery(SLEPromoType, query, "id_promo", "promo", "id_promo")
    End Sub

    Sub actionLoad()
        Cursor = Cursors.WaitCursor
        'set caption
        GVBySizeType.Columns("qty1").Caption = "1" + System.Environment.NewLine + "XXS"
        GVBySizeType.Columns("qty2").Caption = "2" + System.Environment.NewLine + "XS"
        GVBySizeType.Columns("qty3").Caption = "3" + System.Environment.NewLine + "S"
        GVBySizeType.Columns("qty4").Caption = "4" + System.Environment.NewLine + "M"
        GVBySizeType.Columns("qty5").Caption = "5" + System.Environment.NewLine + "ML"
        GVBySizeType.Columns("qty6").Caption = "6" + System.Environment.NewLine + "L"
        GVBySizeType.Columns("qty7").Caption = "7" + System.Environment.NewLine + "XL"
        GVBySizeType.Columns("qty8").Caption = "8" + System.Environment.NewLine + "XXL"
        GVBySizeType.Columns("qty9").Caption = "9" + System.Environment.NewLine + "ALL"
        GVBySizeType.Columns("qty0").Caption = "0" + System.Environment.NewLine + "SM"
        If action = "ins" Then
            DEStart.EditValue = Now
            DEEnd.EditValue = Now
            DECreated.EditValue = Now
        Else
            Dim p As New ClassPromoCollection()
            Dim query As String = p.queryMain("AND p.id_ol_promo_collection=" + id + "", "2")
            Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
            SLEPromoType.EditValue = data.Rows(0)("id_promo").ToString
            TxtTag.Text = data.Rows(0)("tag").ToString
            DEStart.EditValue = data.Rows(0)("start_period")
            DEEnd.EditValue = data.Rows(0)("end_period")
            MENote.Text = data.Rows(0)("note").ToString
            TxtNumber.Text = data.Rows(0)("number").ToString
            DECreated.EditValue = data.Rows(0)("created_date")
            TxtCreatedBy.Text = data.Rows(0)("created_by_name").ToString
            LEReportStatus.ItemIndex = LEReportStatus.Properties.GetDataSourceRowIndex("id_report_status", data.Rows(0)("id_report_status").ToString)
            id_report_status = data.Rows(0)("id_report_status").ToString
            is_confirm = data.Rows(0)("is_confirm").ToString
            TxtPromoName.Text = data.Rows(0)("promo_name").ToString
            TxtUseDiscountCode.Text = data.Rows(0)("use_discount_code").ToString
            TxtDiscountTitle.Text = data.Rows(0)("discount_title").ToString
            is_use_discount_code = data.Rows(0)("is_use_discount_code").ToString
            id_price_rule = data.Rows(0)("price_rule_id").ToString

            'properti
            If is_confirm = "2" Then
                'cek date
                Dim min_date As DateTime
                Dim qmin As String = "SELECT DATE(DATE_ADD(c.end_period,INTERVAL 1 DAY)) AS `min_date` FROM tb_ol_promo_collection c WHERE c.id_report_status=6 AND c.is_use_discount_code=2 ORDER BY c.id_ol_promo_collection DESC LIMIT 1 "
                Dim dmin As DataTable = execute_query(qmin, -1, True, "", "", "", "")
                If dmin.Rows.Count > 0 Then
                    min_date = dmin.Rows(0)("min_date")
                Else
                    min_date = getTimeDB()
                End If
                DEStart.Properties.MinValue = min_date
                DEEnd.Properties.MinValue = min_date
            End If

            viewDetail()
            viewDetailProduct()
            allow_status()
        End If
        Cursor = Cursors.Default
    End Sub

    Sub getProductShopify()
        Cursor = Cursors.WaitCursor
        FormMain.SplashScreenManager1.ShowWaitForm()
        FormMain.SplashScreenManager1.SetWaitFormDescription("Get shopify product id")
        Try
            Dim s As New ClassShopifyApi()
            dt = s.get_product()
        Catch ex As Exception
            stopCustom(ex.ToString)
        End Try
        FormMain.SplashScreenManager1.CloseWaitForm()
        Cursor = Cursors.Default
    End Sub

    Sub viewDetail()
        Cursor = Cursors.WaitCursor
        Dim query As String = "SELECT pd.id_ol_promo_collection_sku, pd.id_ol_promo_collection, 
        prod.id_design, d.design_code AS `code`, d.design_display_name AS `name`, 
        GROUP_CONCAT(DISTINCT cd.code_detail_name ORDER BY cd.id_code_detail ASC) AS `size_chart`,
        pd.id_prod_shopify, pd.current_tag, pd.design_price, design_price_type AS `price_type`, SUM(pd.qty) AS `qty`, 
        pd.is_block, IF(pd.is_block=1,'Not Active', 'Active') AS `is_block_view`
        FROM tb_ol_promo_collection_sku pd
        INNER JOIN tb_m_product prod ON prod.id_product = pd.id_product
        INNER JOIN tb_m_design d ON d.id_design = prod.id_design
        INNER JOIN tb_m_product_code prod_code ON prod_code.id_product = prod.id_product
        INNER JOIN tb_m_code_detail cd ON cd.id_code_detail = prod_code.id_code_detail
        LEFT JOIN tb_m_design_price prc ON prc.id_design_price = pd.id_design_price
        LEFT JOIN tb_lookup_design_price_type pt ON pt.id_design_price_type = prc.id_design_price_type 
        WHERE pd.id_ol_promo_collection=" + id + "
        GROUP BY d.id_design
        ORDER BY d.design_display_name ASC "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCData.DataSource = data
        Cursor = Cursors.Default
    End Sub

    Sub viewDetailProduct()
        Cursor = Cursors.WaitCursor
        Dim query As String = "SELECT pd.id_ol_promo_collection_sku, pd.id_ol_promo_collection, 
        prod.id_design, prod.id_product, d.design_code,prod.product_full_code AS `code`, d.design_display_name AS `name`, 
        cd.code_detail_name AS `size`, pd.id_prod_shopify, pd.current_tag, pd.design_price, design_price_type AS `price_type`, pd.qty,
        pd.is_block, IF(pd.is_block=1,'Not Active', 'Active') AS `is_block_view`
        FROM tb_ol_promo_collection_sku pd
        INNER JOIN tb_m_product prod ON prod.id_product = pd.id_product
        INNER JOIN tb_m_design d ON d.id_design = prod.id_design
        INNER JOIN tb_m_product_code prod_code ON prod_code.id_product = prod.id_product
        INNER JOIN tb_m_code_detail cd ON cd.id_code_detail = prod_code.id_code_detail
        LEFT JOIN tb_m_design_price prc ON prc.id_design_price = pd.id_design_price
        LEFT JOIN tb_lookup_design_price_type pt ON pt.id_design_price_type = prc.id_design_price_type 
        WHERE pd.id_ol_promo_collection=" + id + "
        ORDER BY d.design_display_name ASC, prod.product_full_code ASC "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCProduct.DataSource = data
        Cursor = Cursors.Default
    End Sub

    Sub viewProductBySizeType()
        Cursor = Cursors.WaitCursor
        Dim query As String = "SET @nomer=0;
        SELECT pd.id_ol_promo_collection_sku, pd.id_ol_promo_collection, 
        n.nomer_urut,prod.id_design, d.design_code AS `code`, d.design_display_name AS `name`, 
        SUBSTRING(prod.product_full_code, 10, 1) AS `size_type`,
        IFNULL(SUM(CASE WHEN SUBSTRING(cd.code,2,1)='1' THEN pd.qty END),0) AS `qty1`,
        IFNULL(SUM(CASE WHEN SUBSTRING(cd.code,2,1)='2' THEN pd.qty END),0) AS `qty2`,
        IFNULL(SUM(CASE WHEN SUBSTRING(cd.code,2,1)='3' THEN pd.qty END),0) AS `qty3`,
        IFNULL(SUM(CASE WHEN SUBSTRING(cd.code,2,1)='4' THEN pd.qty END),0) AS `qty4`,
        IFNULL(SUM(CASE WHEN SUBSTRING(cd.code,2,1)='5' THEN pd.qty END),0) AS `qty5`,
        IFNULL(SUM(CASE WHEN SUBSTRING(cd.code,2,1)='6' THEN pd.qty END),0) AS `qty6`,
        IFNULL(SUM(CASE WHEN SUBSTRING(cd.code,2,1)='7' THEN pd.qty END),0) AS `qty7`,
        IFNULL(SUM(CASE WHEN SUBSTRING(cd.code,2,1)='8' THEN pd.qty END),0) AS `qty8`,
        IFNULL(SUM(CASE WHEN SUBSTRING(cd.code,2,1)='9' THEN pd.qty END),0) AS `qty9`,
        IFNULL(SUM(CASE WHEN SUBSTRING(cd.code,2,1)='0' THEN pd.qty END),0) AS `qty0`,
        SUM(pd.qty) AS `qty`,
        pd.id_prod_shopify, pd.current_tag, pd.design_price, design_price_type AS `price_type`,
        pd.is_block, IF(pd.is_block=1,'Not Active', 'Active') AS `is_block_view`
        FROM tb_ol_promo_collection_sku pd
        INNER JOIN tb_m_product prod ON prod.id_product = pd.id_product
        INNER JOIN tb_m_design d ON d.id_design = prod.id_design
        INNER JOIN tb_m_product_code prod_code ON prod_code.id_product = prod.id_product
        INNER JOIN tb_m_code_detail cd ON cd.id_code_detail = prod_code.id_code_detail
        LEFT JOIN tb_m_design_price prc ON prc.id_design_price = pd.id_design_price
        LEFT JOIN tb_lookup_design_price_type pt ON pt.id_design_price_type = prc.id_design_price_type 
        INNER JOIN (
	        SELECT @nomer:=@nomer+1 AS `nomer_urut`,a.id_design FROM (
		        SELECT d.id_design
		        FROM tb_ol_promo_collection_sku pd
		        INNER JOIN tb_m_product prod ON prod.id_product = pd.id_product
		        INNER JOIN tb_m_design d ON d.id_design = prod.id_design
		        WHERE pd.id_ol_promo_collection=" + id + "
		        GROUP BY prod.id_design
		        ORDER BY d.design_display_name ASC 
	        ) a
	        JOIN (SELECT @nomer:=0 AS `nox`) AS `n`
        ) n ON n.id_design = prod.id_design
        WHERE pd.id_ol_promo_collection=" + id + "
        GROUP BY d.id_design, SUBSTRING(prod.product_full_code, 10, 1)
        ORDER BY d.design_display_name ASC "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCBySizeType.DataSource = data
        GVBySizeType.BestFitColumns()
        Cursor = Cursors.Default
    End Sub

    Sub allow_status()
        BtnAttachment.Visible = True
        BtnCancell.Visible = True
        BtnExportToXLS.Visible = True
        If is_confirm = "2" And is_view = "-1" Then
            BtnConfirm.Visible = True
            BtnMark.Visible = False
            MENote.Enabled = True
            TxtTag.Enabled = True
            PanelControlAdd.Visible = True
            BtnPrint.Visible = False
            BtnSaveChanges.Visible = True
            MENote.Enabled = True
            GVData.OptionsBehavior.ReadOnly = False
            SLEPromoType.Enabled = True
            If is_use_discount_code = "1" Then
                DEStart.Enabled = False
                DEEnd.Enabled = False
            Else
                DEStart.Enabled = True
                DEEnd.Enabled = True
            End If
            TxtPromoName.Enabled = True
        Else
            BtnConfirm.Visible = False
            BtnMark.Visible = True
            MENote.Enabled = False
            TxtTag.Enabled = False
            PanelControlAdd.Visible = False
            BtnPrint.Visible = True
            BtnSaveChanges.Visible = False
            MENote.Enabled = False
            GVData.OptionsBehavior.ReadOnly = True
            SLEPromoType.Enabled = False
            DEStart.Enabled = False
            DEEnd.Enabled = False
            TxtPromoName.Enabled = False
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
        ElseIf id_report_status = "5" Then
            BtnCancell.Visible = False
            BtnResetPropose.Visible = False
            BtnConfirm.Visible = False
            MENote.Enabled = False
            TxtTag.Enabled = False
            PanelControlAdd.Visible = False
            BtnPrint.Visible = False
            PanelControlAdd.Visible = False
            BtnSaveChanges.Visible = False
            MENote.Enabled = False
            GVData.OptionsBehavior.ReadOnly = True
            SLEPromoType.Enabled = False
            DEStart.Enabled = False
            DEEnd.Enabled = False
            TxtPromoName.Enabled = False
        End If
    End Sub

    Private Sub BtnDel_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub XTCData_SelectedPageChanged(sender As Object, e As DevExpress.XtraTab.TabPageChangedEventArgs) Handles XTCData.SelectedPageChanged
        If XTCData.SelectedTabPageIndex = 2 Then
            viewProductBySizeType()
        End If
    End Sub

    Sub saveHead()
        'head
        Cursor = Cursors.WaitCursor
        Dim id_promo As String = SLEPromoType.EditValue.ToString
        Dim tag As String = addSlashes(TxtTag.Text)
        Dim start_period As String = DateTime.Parse(DEStart.EditValue.ToString).ToString("yyyy-MM-dd HH:mm:ss")
        Dim end_period As String = DateTime.Parse(DEEnd.EditValue.ToString).ToString("yyyy-MM-dd HH:mm:ss")
        Dim note As String = addSlashes(MENote.Text)
        Dim promo_name As String = addSlashes(TxtPromoName.Text)
        If action = "ins" Then
            'Dim query As String = "INSERT INTO tb_ol_promo_collection(id_promo, created_date, created_by, start_period, end_period, id_report_status, note)
            'VALUES('" + id_promo + "', NOW(), '" + id_user + "', '" + start_period + "', '" + end_period + "',1, '" + note + "');SELECT LAST_INSERT_ID(); "
            'id = execute_query(query, 0, True, "", "", "", "")
            'execute_non_query("CALL gen_number(" + id + ", " + rmt + ")", True, "", "", "", "")
            ''refresh
            'refreshData()
        ElseIf action = "upd" Then
            Dim query_head As String = "UPDATE tb_ol_promo_collection SET id_promo='" + id_promo + "',start_period='" + start_period + "', end_period='" + end_period + "', tag='" + tag + "',note='" + note + "',promo_name='" + promo_name + "'
            WHERE id_ol_promo_collection='" + id + "' "
            execute_non_query(query_head, True, "", "", "", "")
            'refresh
            refreshData()
        End If
        Cursor = Cursors.Default
    End Sub

    Sub refreshData()
        actionLoad()
        FormPromoCollection.viewPropose()
        FormPromoCollection.GVData.FocusedRowHandle = find_row(FormPromoCollection.GVData, "id_ol_promo_collection", id)
    End Sub

    Sub showLog(ByVal dtx As DataTable)
        Cursor = Cursors.WaitCursor
        FormPromoCollectionLog.dt = dtx
        FormPromoCollectionLog.ShowDialog()
        Cursor = Cursors.Default
    End Sub

    Private Sub BtnConfirm_Click(sender As Object, e As EventArgs) Handles BtnConfirm.Click
        makeSafeGV(GVData)
        makeSafeGV(GVProduct)

        If GVData.RowCount <= 0 Then
            stopCustom("No propose were made. If you want to cancel this propose, please click 'Cancel Propose'")
        ElseIf Not validateInput() Then
            stopCustom("Please complete all data")
        Else
            Dim confirm As DialogResult = DevExpress.XtraEditors.XtraMessageBox.Show("Are you sure you want to confirm this Propose  ?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
            If confirm = Windows.Forms.DialogResult.Yes Then
                Cursor = Cursors.WaitCursor
                'update 
                saveHead()

                'update confirm
                Dim query As String = "UPDATE tb_ol_promo_collection SET is_confirm=1 WHERE id_ol_promo_collection='" + id + "'"
                execute_non_query(query, True, "", "", "", "")

                'submit approval 
                submit_who_prepared(rmt, id, id_user)
                BtnConfirm.Visible = False
                actionLoad()
                infoCustom("Propose submitted. Waiting for approval.")
                Cursor = Cursors.Default
            End If
        End If
    End Sub

    Private Sub BtnSaveChanges_Click(sender As Object, e As EventArgs) Handles BtnSaveChanges.Click
        If validateInput() Then
            saveHead()
        Else
            stopCustom("Please complete all data")
        End If
    End Sub

    Function validateInput() As Boolean
        If TxtTag.Text = "" Or DEStart.EditValue = Nothing Or DEEnd.EditValue = Nothing Then
            Return False
        Else
            Return True
        End If
    End Function

    Private Sub BtnResetPropose_Click(sender As Object, e As EventArgs) Handles BtnResetPropose.Click
        'reset propose
        Dim query As String = "SELECT * FROM tb_report_mark rm WHERE rm.report_mark_type=" + rmt + " AND rm.id_report_status=2 
        AND rm.is_requisite=2 AND rm.id_mark=2 AND rm.id_report=" + id + " "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        If data.Rows.Count = 0 Then
            Dim confirm As DialogResult = DevExpress.XtraEditors.XtraMessageBox.Show("This action will be reset approval and you can update this propose. Are you sure you want to reset this propose ?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
            If confirm = Windows.Forms.DialogResult.Yes Then
                Dim query_upd As String = "-- delete report mark
                DELETE FROM tb_report_mark WHERE report_mark_type=" + rmt + " AND id_report=" + id + "; 
                -- reset confirm
                UPDATE tb_ol_promo_collection SET is_confirm=2,id_report_status=1 WHERE id_ol_promo_collection=" + id + "; "
                execute_non_query(query_upd, True, "", "", "", "")

                'refresh
                refreshData()
            End If
        Else
            stopCustom("This propose already process")
        End If
    End Sub

    Private Sub BtnCancell_Click(sender As Object, e As EventArgs) Handles BtnCancell.Click
        Dim confirm As DialogResult = DevExpress.XtraEditors.XtraMessageBox.Show("Are you sure you want to cancelled this propose ?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
        If confirm = Windows.Forms.DialogResult.Yes Then
            Cursor = Cursors.WaitCursor
            Dim query As String = "UPDATE tb_ol_promo_collection SET id_report_status=5 WHERE id_ol_promo_collection='" + id + "'"
            execute_non_query(query, True, "", "", "", "")

            'nonaktif mark
            Dim queryrm = String.Format("UPDATE tb_report_mark SET report_mark_lead_time=NULL,report_mark_start_datetime=NULL WHERE report_mark_type='{0}' AND id_report='{1}' AND id_report_status>'1'", rmt, id, "5")
            execute_non_query(queryrm, True, "", "", "", "")

            'refresh
            refreshData()
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

    Private Sub BtnPrint_Click(sender As Object, e As EventArgs) Handles BtnPrint.Click
        If Not check_allow_print(id_report_status, rmt, id) Then
            warningCustom("Can't print, please complete all approval on system first")
        Else
            Dim gv As DevExpress.XtraGrid.Views.Grid.GridView = Nothing
            If XTCData.SelectedTabPageIndex = 0 Then
                gv = GVData
                ReportPromoCollection.dt = GCData.DataSource
            ElseIf XTCData.SelectedTabPageIndex = 1 Then
                gv = GVProduct
                ReportPromoCollection.dt = GCProduct.DataSource
            ElseIf XTCData.SelectedTabPageIndex = 2 Then
                gv = GVBySizeType
                ReportPromoCollection.dt = GCBySizeType.DataSource
            ElseIf XTCData.SelectedTabPageIndex = 3 Then
                gv = GVDiscountCode
                ReportPromoCollection.dt = GCDiscountCode.DataSource
            End If
            ReportPromoCollection.id = id
            If id_report_status <> "6" Then
                ReportPromoCollection.is_pre = "1"
            Else
                ReportPromoCollection.is_pre = "-1"
            End If
            ReportPromoCollection.id_report_status = LEReportStatus.EditValue.ToString
            ReportPromoCollection.rmt = rmt

            Dim Report As New ReportPromoCollection()
            '... 
            ' creating And saving the view's layout to a new memory stream 
            Dim str As System.IO.Stream
            str = New System.IO.MemoryStream()
            gv.SaveLayoutToStream(str, DevExpress.Utils.OptionsLayoutBase.FullLayout)
            str.Seek(0, System.IO.SeekOrigin.Begin)
            Report.GVData.RestoreLayoutFromStream(str, DevExpress.Utils.OptionsLayoutBase.FullLayout)
            str.Seek(0, System.IO.SeekOrigin.Begin)

            'style
            Report.GVData.OptionsPrint.UsePrintStyles = True
            Report.GVData.AppearancePrint.FilterPanel.BackColor = Color.Transparent
            Report.GVData.AppearancePrint.FilterPanel.ForeColor = Color.Black
            Report.GVData.AppearancePrint.FilterPanel.Font = New Font("Tahoma", 8, FontStyle.Regular)

            Report.GVData.AppearancePrint.GroupFooter.BackColor = Color.WhiteSmoke
            Report.GVData.AppearancePrint.GroupFooter.ForeColor = Color.Black
            Report.GVData.AppearancePrint.GroupFooter.Font = New Font("Tahoma", 8, FontStyle.Bold)

            Report.GVData.AppearancePrint.GroupRow.BackColor = Color.Transparent
            Report.GVData.AppearancePrint.GroupRow.ForeColor = Color.Black
            Report.GVData.AppearancePrint.GroupRow.Font = New Font("Tahoma", 8, FontStyle.Bold)


            Report.GVData.AppearancePrint.HeaderPanel.BackColor = Color.Transparent
            Report.GVData.AppearancePrint.HeaderPanel.ForeColor = Color.Black
            Report.GVData.AppearancePrint.HeaderPanel.Font = New Font("Tahoma", 8, FontStyle.Bold)

            Report.GVData.AppearancePrint.FooterPanel.BackColor = Color.Gainsboro
            Report.GVData.AppearancePrint.FooterPanel.ForeColor = Color.Black
            Report.GVData.AppearancePrint.FooterPanel.Font = New Font("Tahoma", 8.3, FontStyle.Bold)

            Report.GVData.AppearancePrint.Row.Font = New Font("Tahoma", 8.3, FontStyle.Regular)

            Report.GVData.OptionsPrint.ExpandAllDetails = True
            Report.GVData.OptionsPrint.UsePrintStyles = True
            Report.GVData.OptionsPrint.PrintDetails = True
            Report.GVData.OptionsPrint.PrintFooter = True

            Report.LabelPromoTyoe.Text = TxtPromoName.Text
            Report.LabelTag.Text = TxtTag.Text.ToUpper
            Report.LabelStartPeriod.Text = DEStart.Text.ToUpper
            Report.LabelEndPeriod.Text = DEEnd.Text.ToUpper
            Report.LabelNumber.Text = TxtNumber.Text.ToUpper
            Report.LabelDate.Text = DECreated.Text.ToUpper
            Report.LabelStatus.Text = LEReportStatus.Text.ToUpper
            Report.LNote.Text = MENote.Text.ToUpper
            Report.LabelDiscountCode.Text = TxtUseDiscountCode.Text.ToUpper + If(is_use_discount_code = "1", " - ", "") + TxtDiscountTitle.Text.ToUpper

            ' Show the report's preview. 
            Dim Tool As DevExpress.XtraReports.UI.ReportPrintTool = New DevExpress.XtraReports.UI.ReportPrintTool(Report)
            Tool.ShowPreviewDialog()
        End If
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

    Private Sub BtnImportExcel_Click(sender As Object, e As EventArgs) Handles BtnImportExcel.Click
        Cursor = Cursors.WaitCursor
        XTCData.SelectedTabPageIndex = 0
        FormImportExcel.id_pop_up = "51"
        FormImportExcel.ShowDialog()
        Cursor = Cursors.Default
    End Sub

    Private Sub GVData_CustomFilterDisplayText(sender As Object, e As DevExpress.XtraEditors.Controls.ConvertEditValueEventArgs) Handles GVData.CustomFilterDisplayText

    End Sub

    Private Sub GVProduct_CustomColumnDisplayText(sender As Object, e As DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs) Handles GVProduct.CustomColumnDisplayText
        If e.Column.FieldName = "no" Then
            e.DisplayText = (e.ListSourceRowIndex + 1).ToString()
        End If
    End Sub

    Private Sub GVData_CustomColumnDisplayText(sender As Object, e As DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs) Handles GVData.CustomColumnDisplayText
        If e.Column.FieldName = "no" Then
            e.DisplayText = (e.ListSourceRowIndex + 1).ToString()
        End If
    End Sub

    Private Sub BtnExportToXLS_Click(sender As Object, e As EventArgs) Handles BtnExportToXLS.Click
        Cursor = Cursors.WaitCursor
        If XTCData.SelectedTabPageIndex = 0 Then
            If GVData.RowCount > 0 Then
                Cursor = Cursors.WaitCursor
                'Dim dt_from As String = DEFromRec.Text.Replace(" ", "")
                'Dim dt_until As String = DEUntilRec.Text.Replace(" ", "")
                Dim path As String = Application.StartupPath & "\download\"
                'create directory if not exist
                If Not IO.Directory.Exists(path) Then
                    System.IO.Directory.CreateDirectory(path)
                End If
                path = path + "promo_coll_" + id + ".xlsx"
                exportToXLS(path, "promo_coll_" + id, GCData)
                Cursor = Cursors.Default
            End If
        ElseIf XTCData.SelectedTabPageIndex = 1 Then
            If GVProduct.RowCount > 0 Then
                Cursor = Cursors.WaitCursor
                'Dim dt_from As String = DEFromRec.Text.Replace(" ", "")
                'Dim dt_until As String = DEUntilRec.Text.Replace(" ", "")
                Dim path As String = Application.StartupPath & "\download\"
                'create directory if not exist
                If Not IO.Directory.Exists(path) Then
                    System.IO.Directory.CreateDirectory(path)
                End If
                path = path + "promo_coll_sku_" + id + ".xlsx"
                exportToXLS(path, "promo_coll_sku_" + id, GCProduct)
                Cursor = Cursors.Default
            End If
        End If
        Cursor = Cursors.Default
    End Sub

    Sub exportToXLS(ByVal path_par As String, ByVal sheet_name_par As String, ByVal gc_par As DevExpress.XtraGrid.GridControl)
        Cursor = Cursors.WaitCursor
        Dim path As String = path_par

        ' Customize export options 
        CType(gc_par.MainView, DevExpress.XtraGrid.Views.Grid.GridView).OptionsPrint.PrintHeader = True
        Dim advOptions As DevExpress.XtraPrinting.XlsxExportOptionsEx = New DevExpress.XtraPrinting.XlsxExportOptionsEx()
        advOptions.AllowSortingAndFiltering = DevExpress.Utils.DefaultBoolean.False
        advOptions.ShowGridLines = DevExpress.Utils.DefaultBoolean.False
        advOptions.AllowGrouping = DevExpress.Utils.DefaultBoolean.False
        advOptions.ShowTotalSummaries = DevExpress.Utils.DefaultBoolean.False
        advOptions.SheetName = sheet_name_par
        advOptions.ExportType = DevExpress.Export.ExportType.DataAware

        Try
            gc_par.ExportToXlsx(path, advOptions)
            Process.Start(path)
            ' Open the created XLSX file with the default application. 
        Catch ex As Exception
            stopCustom(ex.ToString)
        End Try
        Cursor = Cursors.Default
    End Sub

    Private Sub BtnShopifyLog_Click(sender As Object, e As EventArgs) Handles BtnShopifyLog.Click
        Dim qlog As String = "SELECT l.`type`, d.design_code AS `code`, d.design_display_name AS `description`, l.log, l.log_date
        FROM tb_ol_promo_collection_log l
        INNER JOIN tb_m_design d ON d.id_design = l.id_design
        WHERE id_ol_promo_collection='" + id + "' "
        Dim dt_log As DataTable = execute_query(qlog, -1, True, "", "", "", "")
        showLog(dt_log)
    End Sub

    Sub viewDiscountCodeList()
        Dim query As String = "SELECT 0 AS `no`, c.disc_code, c.sync_date, c.sync_by, e.employee_name AS `sync_by_name`,
c.is_additional, IF(c.is_additional=1,'Yes', 'No') AS `is_additional_view`
FROM tb_ol_promo_collection_disc_code c 
INNER JOIN tb_m_user us ON us.id_user = c.sync_by
INNER JOIN tb_m_employee e ON e.id_employee = us.id_employee
WHERE c.id_ol_promo_collection = '" + id + "' "

        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")

        For i = 0 To data.Rows.Count - 1
            data.Rows(i)("no") = i + 1
        Next

        GCDiscountCode.DataSource = data

        GVDiscountCode.BestFitColumns()
    End Sub

    Private Sub BtnSync_Click(sender As Object, e As EventArgs) Handles BtnSync.Click
        If Not FormMain.SplashScreenManager1.IsSplashFormVisible Then
            FormMain.SplashScreenManager1.ShowWaitForm()
        End If
        FormMain.SplashScreenManager1.SetWaitFormCaption("Sync Discount Code")
        Try
            Dim vios As New ClassShopifyApi()
            vios.get_discount_code_addition(id, id_price_rule)
        Catch ex As Exception
            stopCustom("Error sync : " + ex.ToString)
        End Try
        viewDiscountCodeList()
        FormMain.SplashScreenManager1.CloseWaitForm()
    End Sub
End Class