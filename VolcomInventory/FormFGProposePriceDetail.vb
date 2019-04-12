Public Class FormFGProposePriceDetail
    Public id As String = "-1"
    Public is_view As String = "-1"
    Dim id_report_status As String = "-1"
    Dim is_confirm As String = "-1"
    Dim is_load_break_size As Boolean = False
    Public id_division As String = "-1"
    Public id_source As String = "-1"
    Dim rmt As String = "70"
    Public id_pp_type As String = "-1"


    Private Sub FormFGProposePriceDetail_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        viewReportStatus()
        viewSeason()
        actionLoad()
    End Sub


    Sub viewReportStatus()
        Dim query As String = "SELECT * FROM tb_lookup_report_status a ORDER BY a.id_report_status "
        'Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        viewLookupQuery(LEReportStatus, query, 0, "report_status", "id_report_status")
    End Sub

    Sub viewSeason()
        Dim query As String = "(SELECT a.id_season, a.season, b.range AS `range` FROM tb_season a 
                                INNER JOIN tb_range b ON a.id_range = b.id_range 
                                ORDER BY b.range ASC)"
        viewSearchLookupQuery(SLESeason, query, "id_season", "season", "id_season")
    End Sub


    Sub actionLoad()
        Cursor = Cursors.WaitCursor
        'main
        Dim query_c As ClassFGProposePrice = New ClassFGProposePrice()
        Dim query As String = query_c.queryMain("AND tb_fg_propose_price.id_fg_propose_price=''" + id + "'' ", "2")
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        TxtNumber.Text = data.Rows(0)("fg_propose_price_number").ToString
        id_pp_type = data.Rows(0)("id_pp_type").ToString
        TxtType.Text = data.Rows(0)("pp_type").ToString
        MENote.Text = data.Rows(0)("fg_propose_price_note").ToString
        DECreated.EditValue = data.Rows(0)("fg_propose_price_date")
        is_confirm = data.Rows(0)("is_confirm").ToString
        LEReportStatus.ItemIndex = LEReportStatus.Properties.GetDataSourceRowIndex("id_report_status", data.Rows(0)("id_report_status").ToString)
        id_report_status = data.Rows(0)("id_report_status").ToString
        SLESeason.EditValue = data.Rows(0)("id_season").ToString
        id_division = data.Rows(0)("id_division").ToString
        TxtDivision.Text = data.Rows(0)("division").ToString
        id_source = data.Rows(0)("id_source").ToString
        TxtSource.Text = data.Rows(0)("source").ToString
        TxtMarkup.EditValue = data.Rows(0)("markup_target")


        'detail
        repoPriceMaster()
        repoPricePrint()
        viewDetail(False)
        allow_status()
        Cursor = Cursors.Default
    End Sub

    Sub repoPriceMaster()
        Dim query As String = "SELECT  pt.id_design_price_type AS `id_design_price_type_master`, pt.design_price_type
        FROM tb_lookup_design_price_type pt
        WHERE pt.id_design_price_type>0 "
        If id_pp_type = "1" Then
            query += "AND pt.id_design_price_type=1 "
        Else
            query += "AND (pt.id_design_price_type=1 OR pt.id_design_price_type=4) "
        End If
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        RepoLEPriceMaster.DataSource = Nothing
        RepoLEPriceMaster.DataSource = data
        RepoLEPriceMaster.DisplayMember = "design_price_type"
        RepoLEPriceMaster.ValueMember = "id_design_price_type_master"
    End Sub

    Sub repoPricePrint()
        Dim query As String = "SELECT  pt.id_design_price_type AS `id_design_price_type_print`, pt.design_price_type
        FROM tb_lookup_design_price_type pt
        WHERE pt.id_design_price_type>0 "
        If id_pp_type = "1" Then
            query += "AND pt.id_design_price_type=1 "
        Else
            query += "AND (pt.id_design_price_type=1 OR pt.id_design_price_type=4) "
        End If
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        RepoLEPricePrint.DataSource = Nothing
        RepoLEPricePrint.DataSource = data
        RepoLEPricePrint.DisplayMember = "design_price_type"
        RepoLEPricePrint.ValueMember = "id_design_price_type_print"
    End Sub

    Sub viewDetail(ByVal show_non_aktif As Boolean)
        Cursor = Cursors.WaitCursor

        Dim cond As String = "AND ppd.id_fg_propose_price=" + id + " "
        If Not show_non_aktif Then
            cond += "AND ppd.is_active=1 "
        Else
            GridColumnActive.Visible = True
        End If
        Dim pp As New ClassFGProposePrice
        Dim data As DataTable = pp.dataDetail(cond)
        GCData.DataSource = data

        'opt column
        If id_pp_type = "1" Then 'reguler
            GridColumnSalePrice.OptionsColumn.ReadOnly = True

            GridColumnSalePrice.Visible = False
            GridColumnSalePriceMinAdditional.Visible = False
            GridColumnSetAsMaster.Visible = False
            GridColumnSetAsPrint.Visible = False
            GridColumnMarkUpSale.Visible = False
            GridColumnMarkUpManagRateSale.Visible = False
        Else 'non reguler
            GridColumnSalePrice.OptionsColumn.ReadOnly = False

            GridColumnSalePrice.VisibleIndex = GridColumnPrice.VisibleIndex + 1
            GridColumnSalePriceMinAdditional.VisibleIndex = GridColumnPriceMinAdditional.VisibleIndex + 1
            If is_confirm = "1" Then
                GridColumnSetAsMasterDisplay.VisibleIndex = GridColumnSalePriceMinAdditional.VisibleIndex + 1
                GridColumnSetAsPrintDisplay.VisibleIndex = GridColumnSetAsMasterDisplay.VisibleIndex + 1
            Else
                GridColumnSetAsMaster.VisibleIndex = GridColumnSalePriceMinAdditional.VisibleIndex + 1
                GridColumnSetAsPrint.VisibleIndex = GridColumnSetAsMaster.VisibleIndex + 1
            End If
            GridColumnMarkUpSale.VisibleIndex = GridColumnMarkUpManagRate.VisibleIndex + 1
            GridColumnMarkUpManagRateSale.VisibleIndex = GridColumnMarkUpSale.VisibleIndex + 1
        End If

        GVData.BestFitColumns()
        Cursor = Cursors.Default
    End Sub

    Sub allow_status()
        BtnAttachment.Visible = True
        BtnCancell.Visible = True
        If is_confirm = "2" And is_view = "-1" Then
            BtnConfirm.Visible = True
            BtnMark.Visible = False
            MENote.Enabled = False
            PanelControlNav.Visible = True
            BtnPrint.Visible = False
            BtnSaveChanges.Visible = True
            MENote.Enabled = True
            GridColumnIsSelect.VisibleIndex = 0
            PanelControlSelAll.Visible = True
            GVData.OptionsBehavior.ReadOnly = False
        Else
            BtnConfirm.Visible = False
            BtnMark.Visible = True
            MENote.Enabled = False
            PanelControlNav.Visible = False
            BtnPrint.Visible = True
            BtnSaveChanges.Visible = False
            MENote.Enabled = False
            GridColumnIsSelect.Visible = False
            PanelControlSelAll.Visible = False
            GVData.OptionsBehavior.ReadOnly = True
        End If

        If id_report_status = "6" Then
            BtnCancell.Visible = False
            PanelControlShowNonActive.Visible = True
            XTPRevision.PageVisible = True
        ElseIf id_report_status = "5" Then
            BtnCancell.Visible = False
            BtnConfirm.Visible = False
            MENote.Enabled = False
            BtnPrint.Visible = False
            PanelControlNav.Visible = False
            BtnSaveChanges.Visible = False
            MENote.Enabled = False
            GridColumnIsSelect.Visible = False
            PanelControlSelAll.Visible = False
            GVData.OptionsBehavior.ReadOnly = True
        End If
    End Sub

    Private Sub BtnAdd_Click(sender As Object, e As EventArgs) Handles BtnAdd.Click
        Cursor = Cursors.WaitCursor
        FormFGProposePriceSingle.ShowDialog()
        Cursor = Cursors.Default
    End Sub

    Sub saveChangesDetail()
        Cursor = Cursors.WaitCursor
        makeSafeGV(GVData)
        If GVData.RowCount > 0 Then
            For i As Integer = 0 To (GVData.RowCount - 1)
                Dim id_fg_propose_price_detail As String = GVData.GetRowCellValue(i, "id_fg_propose_price_detail").ToString
                Dim msrp As String = decimalSQL(GVData.GetRowCellValue(i, "msrp").ToString)
                Dim price As String = decimalSQL(GVData.GetRowCellValue(i, "price").ToString)
                Dim sale_price As String = decimalSQL(GVData.GetRowCellValue(i, "sale_price").ToString)
                Dim additional_price As String = decimalSQL(GVData.GetRowCellValue(i, "additional_price").ToString)
                Dim id_design_price_type_master As String = GVData.GetRowCellValue(i, "id_design_price_type_master").ToString
                Dim id_design_price_type_print As String = GVData.GetRowCellValue(i, "id_design_price_type_print").ToString
                Dim remark As String = addSlashes(GVData.GetRowCellValue(i, "remark").ToString)

                Dim query As String = "UPDATE tb_fg_propose_price_detail SET msrp='" + msrp + "', price='" + price + "', sale_price='" + sale_price + "',
                additional_price='" + additional_price + "', id_design_price_type_master='" + id_design_price_type_master + "', id_design_price_type_print='" + id_design_price_type_print + "',
                remark='" + remark + "' WHERE id_fg_propose_price_detail='" + id_fg_propose_price_detail + "' "
                execute_non_query(query, True, "", "", "", "")
            Next
        End If
        Cursor = Cursors.Default
    End Sub

    Private Sub BtnDel_Click(sender As Object, e As EventArgs) Handles BtnDel.Click
        makeSafeGV(GVData)
        saveChangesDetail()
        GVData.ActiveFilterString = "[is_select]='Yes'"
        If GVData.RowCount > 0 Then
            Dim confirm As DialogResult = DevExpress.XtraEditors.XtraMessageBox.Show("Are you sure you want to delete " + GVData.RowCount.ToString + " items ?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
            If confirm = Windows.Forms.DialogResult.Yes Then
                Cursor = Cursors.WaitCursor
                Dim id_ppd As String = ""
                For i As Integer = 0 To (GVData.RowCount - 1)
                    If i > 0 Then
                        id_ppd += "OR "
                    End If
                    id_ppd += "id_fg_propose_price_detail='" + GVData.GetRowCellValue(i, "id_fg_propose_price_detail").ToString + "' "
                Next

                'delete
                Dim query As String = "DELETE FROM tb_fg_propose_price_detail WHERE (" + id_ppd + ")"
                execute_non_query(query, True, "", "", "", "")
                viewDetail(False)
                Cursor = Cursors.Default
            End If
        Else
            stopCustom("No data selected")
        End If
        GVData.ActiveFilterString = ""
    End Sub

    Private Sub BtnUpdateCOP_Click(sender As Object, e As EventArgs) Handles BtnUpdateCOP.Click
        makeSafeGV(GVData)
        saveChangesDetail()
        GVData.ActiveFilterString = "[is_select]='Yes'"
        If GVData.RowCount > 0 Then
            Dim confirm As DialogResult = DevExpress.XtraEditors.XtraMessageBox.Show("This action might update current cost with latest cost.  Are you sure you want to update these COP ?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
            If confirm = Windows.Forms.DialogResult.Yes Then
                Cursor = Cursors.WaitCursor
                'get all data
                Dim pp As New ClassFGProposePrice()
                Dim data As DataTable = pp.dataCOPList(SLESeason.EditValue.ToString, id_source, id_division, False)

                'update per row
                For i As Integer = 0 To (GVData.RowCount - 1)
                    Dim id_fg_propose_price_detail As String = GVData.GetRowCellValue(i, "id_fg_propose_price_detail").ToString
                    Dim id_design As String = GVData.GetRowCellValue(i, "id_design").ToString
                    Dim id_prod_demand_design As String = "NULL"
                    Dim id_cop_status As String = "NULL"
                    Dim qty As String = "0"
                    Dim additional_cost As String = "0"
                    Dim cop_rate_cat As String = "1"
                    Dim cop_kurs As String = "0"
                    Dim cop_value As String = "0"
                    Dim cop_mng_kurs As String = "0"
                    Dim cop_mng_value As String = "0"

                    Dim dt As DataRow() = data.Select("[id_design]='" + id_design + "' ")
                    Dim query As String = ""
                    If dt.Length <= 0 Then
                        query = "UPDATE tb_fg_propose_price_detail SET qty=0, additional_cost=0, cop_date=NOW(), cop_kurs=0, 
                        cop_value=0, cop_mng_kurs=0,cop_mng_value=0 WHERE id_fg_propose_price_detail=" + id_fg_propose_price_detail + " "
                    Else
                        id_prod_demand_design = dt(0)("id_prod_demand_design").ToString
                        id_cop_status = dt(0)("id_cop_status").ToString
                        qty = decimalSQL(dt(0)("qty").ToString)
                        additional_cost = decimalSQL(dt(0)("additional_cost").ToString)
                        cop_rate_cat = dt(0)("cop_rate_cat").ToString
                        cop_kurs = decimalSQL(dt(0)("cop_kurs").ToString)
                        cop_value = decimalSQL(dt(0)("cop_value").ToString)
                        cop_mng_kurs = decimalSQL(dt(0)("cop_mng_kurs").ToString)
                        cop_mng_value = decimalSQL(dt(0)("cop_mng_value").ToString)
                        query = "UPDATE tb_fg_propose_price_detail SET id_prod_demand_design=" + id_prod_demand_design + ", id_cop_status=" + id_cop_status + ",
                        qty=" + qty + ", additional_cost=" + additional_cost + ", cop_date=NOW(), cop_rate_cat='" + cop_rate_cat + "', cop_kurs=" + cop_kurs + ", 
                        cop_value=" + cop_value + ", cop_mng_kurs=" + cop_mng_kurs + ",cop_mng_value=" + cop_mng_value + " 
                        WHERE id_fg_propose_price_detail=" + id_fg_propose_price_detail + " "
                    End If
                    execute_non_query(query, True, "", "", "", "")
                Next

                'refresh
                viewDetail(False)
                Cursor = Cursors.Default
            End If
        Else
            stopCustom("No data selected")
        End If
        GVData.ActiveFilterString = ""
    End Sub

    Private Sub FormFGProposePriceDetail_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub BtnCancell_Click(sender As Object, e As EventArgs) Handles BtnCancell.Click
        Dim confirm As DialogResult = DevExpress.XtraEditors.XtraMessageBox.Show("Are you sure you want to cancelled this propose ?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
        If confirm = Windows.Forms.DialogResult.Yes Then
            Cursor = Cursors.WaitCursor
            Dim query As String = "UPDATE tb_fg_propose_price SET id_report_status=5 WHERE id_fg_propose_price='" + id + "'"
            execute_non_query(query, True, "", "", "", "")

            'nonaktif mark
            Dim queryrm = String.Format("UPDATE tb_report_mark SET report_mark_lead_time=NULL,report_mark_start_datetime=NULL WHERE report_mark_type='{0}' AND id_report='{1}' AND id_report_status>'1'", rmt, id, "5")
            execute_non_query(queryrm, True, "", "", "", "")

            FormFGProposePrice.viewPropose()
            FormFGProposePrice.GVFGPropose.FocusedRowHandle = find_row(FormFGProposePrice.GVFGPropose, "id_fg_propose_price", id)
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

    Private Sub BtnPrint_Click(sender As Object, e As EventArgs) Handles BtnPrint.Click
        Cursor = Cursors.WaitCursor
        If Not check_allow_print(id_report_status, rmt, id) Then
            warningCustom("Can't print, please complete all approval on system first")
        Else
            Dim gv As DevExpress.XtraGrid.Views.Grid.GridView = Nothing
            gv = GVData
            ReportFGProposePriceDetail.dt = GCData.DataSource
            ReportFGProposePriceDetail.id = id
            If id_report_status <> "6" Then
                ReportFGProposePriceDetail.is_pre = "1"
            Else
                ReportFGProposePriceDetail.is_pre = "-1"
            End If
            ReportFGProposePriceDetail.id_report_status = LEReportStatus.EditValue.ToString

            ReportFGProposePriceDetail.rmt = rmt
            Dim Report As New ReportFGProposePriceDetail()

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
            Report.GVData.AppearancePrint.FilterPanel.Font = New Font("Tahoma", 5, FontStyle.Regular)

            Report.GVData.AppearancePrint.GroupFooter.BackColor = Color.Transparent
            Report.GVData.AppearancePrint.GroupFooter.ForeColor = Color.Black
            Report.GVData.AppearancePrint.GroupFooter.Font = New Font("Tahoma", 5, FontStyle.Bold)

            Report.GVData.AppearancePrint.GroupRow.BackColor = Color.Transparent
            Report.GVData.AppearancePrint.GroupRow.ForeColor = Color.Black
            Report.GVData.AppearancePrint.GroupRow.Font = New Font("Tahoma", 5, FontStyle.Bold)


            Report.GVData.AppearancePrint.HeaderPanel.BackColor = Color.Transparent
            Report.GVData.AppearancePrint.HeaderPanel.ForeColor = Color.Black
            Report.GVData.AppearancePrint.HeaderPanel.Font = New Font("Tahoma", 5, FontStyle.Bold)

            Report.GVData.AppearancePrint.FooterPanel.BackColor = Color.Transparent
            Report.GVData.AppearancePrint.FooterPanel.ForeColor = Color.Black
            Report.GVData.AppearancePrint.FooterPanel.Font = New Font("Tahoma", 5.3, FontStyle.Bold)

            Report.GVData.AppearancePrint.Row.Font = New Font("Tahoma", 5.3, FontStyle.Regular)

            Report.GVData.OptionsPrint.ExpandAllDetails = True
            Report.GVData.OptionsPrint.UsePrintStyles = True
            Report.GVData.OptionsPrint.PrintDetails = True
            Report.GVData.OptionsPrint.PrintFooter = True

            Report.LabelNumber.Text = TxtNumber.Text
            Report.LabelSeason.Text = SLESeason.Text
            Report.LabelDivision.Text = TxtDivision.Text
            Report.LabelSource.Text = TxtSource.Text.ToUpper
            Report.LabelType.Text = TxtType.Text.ToUpper
            Report.LabelDate.Text = DECreated.Text.ToUpper
            Report.LabelStatus.Text = LEReportStatus.Text.ToUpper
            Report.LNote.Text = MENote.Text

            ' Show the report's preview. 
            Dim Tool As DevExpress.XtraReports.UI.ReportPrintTool = New DevExpress.XtraReports.UI.ReportPrintTool(Report)
            Tool.ShowPreviewDialog()
        End If
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

    Sub saveHead()
        'head
        Dim fg_propose_price_note As String = addSlashes(MENote.Text)
        Dim query_head As String = "UPDATE tb_fg_propose_price SET fg_propose_price_note='" + fg_propose_price_note + "' 
        WHERE id_fg_propose_price='" + id + "' "
        execute_non_query(query_head, True, "", "", "", "")
    End Sub

    Private Sub BtnSaveChanges_Click(sender As Object, e As EventArgs) Handles BtnSaveChanges.Click
        Dim confirm As DialogResult = DevExpress.XtraEditors.XtraMessageBox.Show("Are you sure you want to save changes this propose ?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
        If confirm = Windows.Forms.DialogResult.Yes Then
            'head
            saveHead()

            'detail
            saveChangesDetail()

            actionLoad()
            FormFGProposePrice.viewPropose()
            FormFGProposePrice.GVFGPropose.FocusedRowHandle = find_row(FormFGProposePrice.GVFGPropose, "id_fg_propose_price", id)
        End If
    End Sub

    Private Sub GVData_CustomColumnDisplayText(sender As Object, e As DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs) Handles GVData.CustomColumnDisplayText
        If e.Column.FieldName = "no" Then
            e.DisplayText = (e.ListSourceRowIndex + 1).ToString()
        End If
    End Sub

    Private Sub CEFreeze_CheckedChanged(sender As Object, e As EventArgs) Handles CEFreeze.CheckedChanged
        If CEFreeze.EditValue = True Then
            If is_confirm = "2" Then
                GridColumnIsSelect.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left
            End If
            GridColumnNo.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left
            GridColumnDesignCode.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left
            GridColumnCodeImport.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left
            GridColumnDesignName.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left
        Else
            GridColumnIsSelect.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.None
            GridColumnNo.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.None
            GridColumnDesignCode.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.None
            GridColumnCodeImport.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.None
            GridColumnDesignName.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.None

            'index
            If is_confirm = "2" Then
                GridColumnIsSelect.VisibleIndex = 0
            End If
            GridColumnNo.VisibleIndex = 1
            GridColumnDesignCode.VisibleIndex = 2
            GridColumnCodeImport.VisibleIndex = 3
            GridColumnDesignName.VisibleIndex = 4
        End If
    End Sub

    Private Sub CESelAll_CheckedChanged(sender As Object, e As EventArgs) Handles CESelAll.CheckedChanged
        Dim res As String = ""
        If CESelAll.EditValue = True Then
            res = "Yes"
        Else
            res = "No"
        End If

        For i As Integer = 0 To (GVData.RowCount - 1) - GetGroupRowCount(GVData)
            GVData.SetRowCellValue(i, "is_select", res)
        Next
    End Sub

    Private Sub GVData_CellValueChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles GVData.CellValueChanged
        GVData.BestFitColumns()
    End Sub

    Private Sub GVData_RowCellStyle(sender As Object, e As DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs) Handles GVData.RowCellStyle
        If e.RowHandle >= 0 Then
            If (e.Column.FieldName = "mark_up") And id_pp_type = "1" Then
                Dim val As Decimal = 0
                Try
                    val = sender.GetRowCellValue(e.RowHandle, sender.Columns("mark_up"))
                Catch ex As Exception
                End Try

                If val >= TxtMarkup.EditValue Then
                    e.Appearance.BackColor = Color.LightSeaGreen
                    e.Appearance.BackColor2 = Color.LightSeaGreen
                Else
                    e.Appearance.BackColor = Color.Crimson
                    e.Appearance.BackColor2 = Color.Crimson
                End If
            ElseIf (e.Column.FieldName = "mark_up_mng") And id_pp_type = "1" Then
                Dim val As Decimal = 0
                Try
                    val = sender.GetRowCellValue(e.RowHandle, sender.Columns("mark_up_mng"))
                Catch ex As Exception
                End Try

                If val >= TxtMarkup.EditValue Then
                    e.Appearance.BackColor = Color.LightSeaGreen
                    e.Appearance.BackColor2 = Color.LightSeaGreen
                Else
                    e.Appearance.BackColor = Color.Crimson
                    e.Appearance.BackColor2 = Color.Crimson
                End If
            End If
        End If
    End Sub

    Private Sub BtnConfirm_Click(sender As Object, e As EventArgs) Handles BtnConfirm.Click
        makeSafeGV(GVData)
        If GVData.RowCount <= 0 Then
            stopCustom("No propose were made. If you want to cancel this propose, please click 'Cancel Propose'")
        Else
            Dim confirm As DialogResult = DevExpress.XtraEditors.XtraMessageBox.Show("Are you sure you want to confirm this Propose Price ?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
            If confirm = Windows.Forms.DialogResult.Yes Then
                Cursor = Cursors.WaitCursor
                'update 
                saveHead()
                saveChangesDetail()

                'update confirm
                Dim query As String = "UPDATE tb_fg_propose_price SET is_confirm=1 WHERE id_fg_propose_price='" + id + "'"
                execute_non_query(query, True, "", "", "", "")

                'submit approval 
                submit_who_prepared(rmt, id, id_user)
                BtnConfirm.Visible = False
                actionLoad()
                infoCustom("Propose Price submitted. Waiting for approval.")
                Cursor = Cursors.Default
            End If
        End If
    End Sub

    Private Sub CEShowNonActive_CheckedChanged(sender As Object, e As EventArgs) Handles CEShowNonActive.CheckedChanged
        If CEShowNonActive.EditValue = True Then
            viewDetail(True)
        Else
            viewDetail(False)
        End If
    End Sub

    Private Sub XTCPP_SelectedPageChanged(sender As Object, e As DevExpress.XtraTab.TabPageChangedEventArgs) Handles XTCPP.SelectedPageChanged
        If XTCPP.SelectedTabPageIndex = 0 Then
        ElseIf XTCPP.SelectedTabPageIndex = 1 Then
            viewRevision()
        End If
    End Sub

    Sub viewRevision()
        Cursor = Cursors.WaitCursor
        Dim query As String = "SELECT r.id_fg_propose_price_rev, 188 AS `rmt`, r.rev_count, d.design_code AS `code`, d.design_display_name AS `name`, ppd.price AS `before_price`, rd.price AS `after_price`
        FROM tb_fg_propose_price_rev r
        INNER JOIN tb_fg_propose_price_rev_det rd ON rd.id_fg_propose_price_rev = r.id_fg_propose_price_rev
        INNER JOIN tb_fg_propose_price_detail ppd ON ppd.id_fg_propose_price_detail = rd.id_fg_propose_price_detail
        INNER JOIN tb_m_design d ON d.id_design = rd.id_design
        WHERE r.id_fg_propose_price=" + id + " AND r.id_report_status=6
        ORDER BY rd.id_fg_propose_price_rev_det ASC "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCRev.DataSource = data
        GVRev.BestFitColumns()
        Cursor = Cursors.Default
    End Sub

    Private Sub RepositoryItemHyperLinkEdit1_Click(sender As Object, e As EventArgs) Handles RepositoryItemHyperLinkEdit1.Click
        If GVRev.RowCount > 0 And GVRev.FocusedRowHandle >= 0 Then
            Dim id_report As String = GVRev.GetFocusedRowCellValue("id_fg_propose_price_rev").ToString
            Dim rmt As String = GVRev.GetFocusedRowCellValue("rmt").ToString
            Dim m As New ClassShowPopUp
            m.id_report = id_report
            m.report_mark_type = rmt
            m.show()
        End If
    End Sub
End Class