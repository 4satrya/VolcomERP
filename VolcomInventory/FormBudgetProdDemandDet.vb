Public Class FormBudgetProdDemandDet
    Public id As String = "-1"
    Public is_view As String = "-1"
    Dim id_report_status As String = "-1"
    Dim is_confirm As String = "-1"
    Dim rmt As String = "238"

    Private Sub FormBudgetProdDemandDet_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        viewReportStatus()
        actionLoad()
    End Sub

    Sub viewReportStatus()
        Dim query As String = "SELECT * FROM tb_lookup_report_status a ORDER BY a.id_report_status "
        viewLookupQuery(LEReportStatus, query, 0, "report_status", "id_report_status")
    End Sub


    Sub actionLoad()
        Cursor = Cursors.WaitCursor
        'main
        Dim query_c As ClassBudgetProdDemand = New ClassBudgetProdDemand()
        Dim query As String = query_c.queryMain("AND b.id_b_prod_demand_propose='" + id + "' ", "2")
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        TxtNumber.Text = data.Rows(0)("number").ToString
        DEYearBudget.EditValue = data.Rows(0)("year_input")
        MENote.Text = data.Rows(0)("note").ToString
        DECreated.EditValue = data.Rows(0)("created_date")
        is_confirm = data.Rows(0)("is_confirm").ToString
        LEReportStatus.ItemIndex = LEReportStatus.Properties.GetDataSourceRowIndex("id_report_status", data.Rows(0)("id_report_status").ToString)
        id_report_status = data.Rows(0)("id_report_status").ToString

        'detail
        viewDetail()
        allow_status()
        Cursor = Cursors.Default
    End Sub

    Sub viewDetail()

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
            DEYearBudget.Enabled = True
            GVData.OptionsBehavior.ReadOnly = False
        Else
            BtnConfirm.Visible = False
            BtnMark.Visible = True
            MENote.Enabled = False
            PanelControlNav.Visible = False
            BtnPrint.Visible = True
            BtnSaveChanges.Visible = False
            MENote.Enabled = False
            DEYearBudget.Enabled = False
            GVData.OptionsBehavior.ReadOnly = True
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
            DEYearBudget.Enabled = False
            BtnPrint.Visible = False
            PanelControlNav.Visible = False
            BtnSaveChanges.Visible = False
            MENote.Enabled = False
            GVData.OptionsBehavior.ReadOnly = True
        End If
    End Sub

    Private Sub BtnSaveChanges_Click(sender As Object, e As EventArgs) Handles BtnSaveChanges.Click
        Dim confirm As DialogResult = DevExpress.XtraEditors.XtraMessageBox.Show("Are you sure you want to save changes this propose ?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
        If confirm = Windows.Forms.DialogResult.Yes Then
            'head
            saveHead()

            'detail
            saveChangesDetail()

            actionLoad()
            FormBudgetProdDemand.viewProposeByDate()
            FormBudgetProdDemand.GVProposed.FocusedRowHandle = find_row(FormBudgetProdDemand.GVProposed, "id_b_prod_demand_propose", id)
        End If
    End Sub

    Sub saveHead()
        'head
        Dim year As String = DateTime.Parse(DEYearBudget.EditValue.ToString).ToString("yyyy")
        Dim note As String = addSlashes(MENote.Text)
        Dim query_head As String = "UPDATE tb_b_prod_demand_propose SET year='" + year + "',note='" + note + "' 
        WHERE id_b_prod_demand_propose='" + id + "' "
        execute_non_query(query_head, True, "", "", "", "")
    End Sub

    Sub saveChangesDetail()
        Cursor = Cursors.WaitCursor
        'makeSafeGV(GVData)
        'If GVData.RowCount > 0 Then
        '    For i As Integer = 0 To (GVData.RowCount - 1)
        '        Dim id_fg_propose_price_detail As String = GVData.GetRowCellValue(i, "id_fg_propose_price_detail").ToString
        '        Dim msrp As String = decimalSQL(GVData.GetRowCellValue(i, "msrp").ToString)
        '        Dim price As String = decimalSQL(GVData.GetRowCellValue(i, "price").ToString)
        '        Dim sale_price As String = decimalSQL(GVData.GetRowCellValue(i, "sale_price").ToString)
        '        Dim additional_price As String = decimalSQL(GVData.GetRowCellValue(i, "additional_price").ToString)
        '        Dim id_design_price_type_master As String = GVData.GetRowCellValue(i, "id_design_price_type_master").ToString
        '        Dim id_design_price_type_print As String = GVData.GetRowCellValue(i, "id_design_price_type_print").ToString
        '        Dim remark As String = addSlashes(GVData.GetRowCellValue(i, "remark").ToString)

        '        Dim query As String = "UPDATE tb_fg_propose_price_detail SET msrp='" + msrp + "', price='" + price + "', sale_price='" + sale_price + "',
        '        additional_price='" + additional_price + "', id_design_price_type_master='" + id_design_price_type_master + "', id_design_price_type_print='" + id_design_price_type_print + "',
        '        remark='" + remark + "' WHERE id_fg_propose_price_detail='" + id_fg_propose_price_detail + "' "
        '        execute_non_query(query, True, "", "", "", "")
        '    Next
        'End If
        Cursor = Cursors.Default
    End Sub

    Private Sub BtnConfirm_Click(sender As Object, e As EventArgs) Handles BtnConfirm.Click
        makeSafeGV(GVData)
        If GVData.RowCount <= 0 Then
            stopCustom("No propose were made. If you want to cancel this propose, please click 'Cancel Propose'")
        Else
            Dim confirm As DialogResult = DevExpress.XtraEditors.XtraMessageBox.Show("Are you sure you want to confirm this propose ?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
            If confirm = Windows.Forms.DialogResult.Yes Then
                Cursor = Cursors.WaitCursor
                'update 
                saveHead()
                saveChangesDetail()

                'update confirm
                Dim query As String = "UPDATE tb_b_prod_demand_propose SET is_confirm=1 WHERE id_b_prod_demand_propose='" + id + "'"
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
                UPDATE tb_b_prod_demand_propose SET is_confirm=2 WHERE id_b_prod_demand_propose=" + id + "; "
                execute_non_query(query_upd, True, "", "", "", "")

                'refresh
                actionLoad()
                FormBudgetProdDemand.viewProposeByDate()
                FormBudgetProdDemand.GVProposed.FocusedRowHandle = find_row(FormBudgetProdDemand.GVProposed, "id_b_prod_demand_propose", id)
            End If
        Else
            stopCustom("This propose already process")
        End If
    End Sub

    Private Sub BtnCancell_Click(sender As Object, e As EventArgs) Handles BtnCancell.Click
        Dim confirm As DialogResult = DevExpress.XtraEditors.XtraMessageBox.Show("Are you sure you want to cancelled this propose ?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
        If confirm = Windows.Forms.DialogResult.Yes Then
            Cursor = Cursors.WaitCursor
            Dim query As String = "UPDATE tb_b_prod_demand_propose SET id_report_status=5 WHERE id_b_prod_demand_propose='" + id + "'"
            execute_non_query(query, True, "", "", "", "")

            'nonaktif mark
            Dim queryrm = String.Format("UPDATE tb_report_mark SET report_mark_lead_time=NULL,report_mark_start_datetime=NULL WHERE report_mark_type='{0}' AND id_report='{1}' AND id_report_status>'1'", rmt, id, "5")
            execute_non_query(queryrm, True, "", "", "", "")

            'refresh
            actionLoad()
            FormBudgetProdDemand.viewProposeByDate()
            FormBudgetProdDemand.GVProposed.FocusedRowHandle = find_row(FormBudgetProdDemand.GVProposed, "id_b_prod_demand_propose", id)
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
        'Cursor = Cursors.WaitCursor
        'If XTCDetail.SelectedTabPageIndex = 0 Then
        '    If Not check_allow_print(id_report_status, rmt, id) Then
        '        warningCustom("Can't print, please complete all approval on system first")
        '    Else
        '        Dim gv As DevExpress.XtraGrid.Views.Grid.GridView = Nothing
        '        gv = GVData
        '        ReportFGProposePriceDetail.dt = GCData.DataSource
        '        ReportFGProposePriceDetail.id = id
        '        If id_report_status <> "6" Then
        '            ReportFGProposePriceDetail.is_pre = "1"
        '        Else
        '            ReportFGProposePriceDetail.is_pre = "-1"
        '        End If
        '        ReportFGProposePriceDetail.id_report_status = LEReportStatus.EditValue.ToString

        '        ReportFGProposePriceDetail.rmt = rmt
        '        Dim Report As New ReportFGProposePriceDetail()

        '        '... 
        '        ' creating And saving the view's layout to a new memory stream 
        '        Dim str As System.IO.Stream
        '        str = New System.IO.MemoryStream()
        '        gv.SaveLayoutToStream(str, DevExpress.Utils.OptionsLayoutBase.FullLayout)
        '        str.Seek(0, System.IO.SeekOrigin.Begin)
        '        Report.GVData.RestoreLayoutFromStream(str, DevExpress.Utils.OptionsLayoutBase.FullLayout)
        '        str.Seek(0, System.IO.SeekOrigin.Begin)

        '        'style
        '        Report.GVData.OptionsPrint.UsePrintStyles = True
        '        Report.GVData.AppearancePrint.FilterPanel.BackColor = Color.Transparent
        '        Report.GVData.AppearancePrint.FilterPanel.ForeColor = Color.Black
        '        Report.GVData.AppearancePrint.FilterPanel.Font = New Font("Tahoma", 5, FontStyle.Regular)

        '        Report.GVData.AppearancePrint.GroupFooter.BackColor = Color.WhiteSmoke
        '        Report.GVData.AppearancePrint.GroupFooter.ForeColor = Color.Black
        '        Report.GVData.AppearancePrint.GroupFooter.Font = New Font("Tahoma", 5, FontStyle.Bold)

        '        Report.GVData.AppearancePrint.GroupRow.BackColor = Color.Transparent
        '        Report.GVData.AppearancePrint.GroupRow.ForeColor = Color.Black
        '        Report.GVData.AppearancePrint.GroupRow.Font = New Font("Tahoma", 5, FontStyle.Bold)


        '        Report.GVData.AppearancePrint.HeaderPanel.BackColor = Color.Transparent
        '        Report.GVData.AppearancePrint.HeaderPanel.ForeColor = Color.Black
        '        Report.GVData.AppearancePrint.HeaderPanel.Font = New Font("Tahoma", 5, FontStyle.Bold)

        '        Report.GVData.AppearancePrint.FooterPanel.BackColor = Color.Gainsboro
        '        Report.GVData.AppearancePrint.FooterPanel.ForeColor = Color.Black
        '        Report.GVData.AppearancePrint.FooterPanel.Font = New Font("Tahoma", 5.3, FontStyle.Bold)

        '        Report.GVData.AppearancePrint.Row.Font = New Font("Tahoma", 5.3, FontStyle.Regular)

        '        Report.GVData.OptionsPrint.ExpandAllDetails = True
        '        Report.GVData.OptionsPrint.UsePrintStyles = True
        '        Report.GVData.OptionsPrint.PrintDetails = True
        '        Report.GVData.OptionsPrint.PrintFooter = True

        '        Report.LabelNumber.Text = TxtNumber.Text
        '        Report.LabelSeason.Text = SLESeason.Text
        '        Report.LabelDivision.Text = TxtDivision.Text
        '        Report.LabelSource.Text = TxtSource.Text.ToUpper
        '        Report.LabelType.Text = TxtType.Text.ToUpper
        '        Report.LabelDate.Text = DECreated.Text.ToUpper
        '        Report.LabelStatus.Text = LEReportStatus.Text.ToUpper
        '        Report.LNote.Text = MENote.Text

        '        ' Show the report's preview. 
        '        Dim Tool As DevExpress.XtraReports.UI.ReportPrintTool = New DevExpress.XtraReports.UI.ReportPrintTool(Report)
        '        Tool.ShowPreviewDialog()
        '    End If
        'ElseIf XTCDetail.SelectedTabPageIndex = 1 Then
        '    Dim gv As DevExpress.XtraGrid.Views.Grid.GridView = Nothing
        '    gv = GVAnalysis
        '    ReportFGProposePriceAnalysis.dt = GCAnalysis.DataSource
        '    ReportFGProposePriceAnalysis.id = id
        '    If id_report_status <> "6" Then
        '        ReportFGProposePriceAnalysis.is_pre = "1"
        '    Else
        '        ReportFGProposePriceAnalysis.is_pre = "-1"
        '    End If
        '    ReportFGProposePriceAnalysis.id_report_status = LEReportStatus.EditValue.ToString

        '    ReportFGProposePriceAnalysis.rmt = rmt
        '    Dim Report As New ReportFGProposePriceAnalysis()

        '    '... 
        '    ' creating And saving the view's layout to a new memory stream 
        '    Dim str As System.IO.Stream
        '    str = New System.IO.MemoryStream()
        '    gv.SaveLayoutToStream(str, DevExpress.Utils.OptionsLayoutBase.FullLayout)
        '    str.Seek(0, System.IO.SeekOrigin.Begin)
        '    Report.GVAnalysis.RestoreLayoutFromStream(str, DevExpress.Utils.OptionsLayoutBase.FullLayout)
        '    str.Seek(0, System.IO.SeekOrigin.Begin)

        '    'style
        '    Report.GVAnalysis.OptionsPrint.UsePrintStyles = True
        '    Report.GVAnalysis.AppearancePrint.FilterPanel.BackColor = Color.Transparent
        '    Report.GVAnalysis.AppearancePrint.FilterPanel.ForeColor = Color.Black
        '    Report.GVAnalysis.AppearancePrint.FilterPanel.Font = New Font("Tahoma", 5, FontStyle.Regular)

        '    Report.GVAnalysis.AppearancePrint.GroupFooter.BorderColor = Color.Black
        '    Report.GVAnalysis.AppearancePrint.GroupFooter.BackColor = Color.WhiteSmoke
        '    Report.GVAnalysis.AppearancePrint.GroupFooter.ForeColor = Color.Black
        '    Report.GVAnalysis.AppearancePrint.GroupFooter.Font = New Font("Tahoma", 5, FontStyle.Bold)

        '    Report.GVAnalysis.AppearancePrint.GroupRow.BackColor = Color.Transparent
        '    Report.GVAnalysis.AppearancePrint.GroupRow.ForeColor = Color.Black
        '    Report.GVAnalysis.AppearancePrint.GroupRow.Font = New Font("Tahoma", 5, FontStyle.Bold)

        '    Report.GVAnalysis.AppearancePrint.BandPanel.BorderColor = Color.Black
        '    Report.GVAnalysis.AppearancePrint.BandPanel.BackColor = Color.Transparent
        '    Report.GVAnalysis.AppearancePrint.BandPanel.ForeColor = Color.Black
        '    Report.GVAnalysis.AppearancePrint.BandPanel.Font = New Font("Tahoma", 5, FontStyle.Bold)

        '    Report.GVAnalysis.AppearancePrint.HeaderPanel.BorderColor = Color.Black
        '    Report.GVAnalysis.AppearancePrint.HeaderPanel.BackColor = Color.Transparent
        '    Report.GVAnalysis.AppearancePrint.HeaderPanel.ForeColor = Color.Black
        '    Report.GVAnalysis.AppearancePrint.HeaderPanel.Font = New Font("Tahoma", 5, FontStyle.Bold)

        '    Report.GVAnalysis.AppearancePrint.FooterPanel.BorderColor = Color.Black
        '    Report.GVAnalysis.AppearancePrint.FooterPanel.BackColor = Color.Gainsboro
        '    Report.GVAnalysis.AppearancePrint.FooterPanel.ForeColor = Color.Black
        '    Report.GVAnalysis.AppearancePrint.FooterPanel.Font = New Font("Tahoma", 5.3, FontStyle.Bold)

        '    Report.GVAnalysis.AppearancePrint.Row.Font = New Font("Tahoma", 5.3, FontStyle.Regular)

        '    Report.GVAnalysis.AppearancePrint.Lines.BackColor = Color.Black

        '    Report.GVAnalysis.OptionsPrint.ExpandAllDetails = True
        '    Report.GVAnalysis.OptionsPrint.UsePrintStyles = True
        '    Report.GVAnalysis.OptionsPrint.PrintDetails = True
        '    Report.GVAnalysis.OptionsPrint.PrintFooter = True

        '    Report.LabelNumber.Text = TxtNumber.Text
        '    Report.LabelSeason.Text = SLESeason.Text
        '    Report.LabelDivision.Text = TxtDivision.Text
        '    Report.LabelSource.Text = TxtSource.Text.ToUpper
        '    Report.LabelType.Text = TxtType.Text.ToUpper
        '    Report.LabelDate.Text = DECreated.Text.ToUpper
        '    Report.LabelStatus.Text = LEReportStatus.Text.ToUpper
        '    'Report.LNote.Text = MENote.Text

        '    ' Show the report's preview. 
        '    Dim Tool As DevExpress.XtraReports.UI.ReportPrintTool = New DevExpress.XtraReports.UI.ReportPrintTool(Report)
        '    Tool.ShowPreviewDialog()
        'End If
        'Cursor = Cursors.Default
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
End Class