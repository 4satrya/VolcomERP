Public Class FormProdDemandRevDet
    Public id As String = "-1"
    Public id_prod_demand As String = "-1"
    Public is_view As String = "-1"
    Dim id_report_status As String = "-1"
    Dim is_confirm As String = "-1"
    Dim rmt As String = ""

    Private Sub FormProdDemandRevDet_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        viewReportStatus()
        actionLoad()
    End Sub

    Sub viewReportStatus()
        Dim query As String = "SELECT * FROM tb_lookup_report_status a ORDER BY a.id_report_status "
        'Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        viewLookupQuery(LEReportStatus, query, 0, "report_status", "id_report_status")
    End Sub

    Sub actionLoad()
        Dim r As New ClassProdDemand
        Dim query As String = r.queryMainRev("AND r.id_prod_demand_rev='" + id + "' ", "1")
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        id_prod_demand = data.Rows(0)("id_prod_demand").ToString
        TxtProdDemandNumber.Text = data.Rows(0)("prod_demand_number").ToString
        TxtRevision.Text = data.Rows(0)("rev_count").ToString
        MENote.Text = data.Rows(0)("note").ToString
        DECreated.EditValue = data.Rows(0)("created_date")
        is_confirm = data.Rows(0)("is_confirm").ToString
        LEReportStatus.ItemIndex = LEReportStatus.Properties.GetDataSourceRowIndex("id_report_status", data.Rows(0)("id_report_status").ToString)
        id_report_status = data.Rows(0)("id_report_status").ToString
        If data.Rows(0)("id_pd_kind").ToString = "1" Then
            rmt = "143"
        ElseIf data.Rows(0)("id_pd_kind").ToString = "2" Then
            rmt = "144"
        ElseIf data.Rows(0)("id_pd_kind").ToString = "3" Then
            rmt = "145"
        End If

        viewDetail()
        allow_status()
    End Sub

    Sub viewDetail()
        Cursor = Cursors.WaitCursor
        Dim query As String = "CALL view_prod_demand_rev(" + id + ")"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCRevision.DataSource = data
        GVRevision.BestFitColumns()
        Cursor = Cursors.Default
    End Sub

    Sub viewPDAll()
        Cursor = Cursors.WaitCursor
        Dim query As String = "CALL view_prod_demand_rev_all(" + id + ", " + id_prod_demand + ")"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCData.DataSource = data
        GVData.BestFitColumns()
        Cursor = Cursors.Default
    End Sub


    Sub allow_status()
        BtnAttachment.Visible = True
        BtnCancell.Visible = True
        If is_confirm = "2" Then
            BtnConfirm.Visible = True
            BtnMark.Visible = False
            MENote.Enabled = False
            PanelControlNav.Visible = True
        Else
            BtnConfirm.Visible = False
            BtnMark.Visible = True
            MENote.Enabled = False
            PanelControlNav.Visible = False
        End If

        If id_report_status = "6" Then
            BtnCancell.Visible = False
        ElseIf id_report_status = "5" Then
            BtnCancell.Visible = False
            BtnConfirm.Visible = False
            MENote.Enabled = False
            BtnPrint.Visible = False
            PanelControlNav.Visible = False
        End If
    End Sub


    Private Sub FormProdDemandRevDet_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Dim tot_cost As Decimal
    Dim tot_prc As Decimal
    Dim tot_cost_grp As Decimal
    Dim tot_prc_grp As Decimal
    Private Sub GVRevision_CustomSummaryCalculate(sender As Object, e As DevExpress.Data.CustomSummaryEventArgs) Handles GVRevision.CustomSummaryCalculate
        Dim summaryID As String = Convert.ToString(CType(e.Item, DevExpress.XtraGrid.GridSummaryItem).Tag)
        Dim View As DevExpress.XtraGrid.Views.Grid.GridView = CType(sender, DevExpress.XtraGrid.Views.Grid.GridView)

        ' Initialization 
        If e.SummaryProcess = DevExpress.Data.CustomSummaryProcess.Start Then
            tot_cost = 0.0
            tot_prc = 0.0
            tot_cost_grp = 0.0
            tot_prc_grp = 0.0
        End If

        ' Calculation 
        If e.SummaryProcess = DevExpress.Data.CustomSummaryProcess.Calculate Then
            Dim cost As Decimal = CDec(myCoalesce(View.GetRowCellValue(e.RowHandle, "TOTAL COST NON ADDITIONAL").ToString, "0.00"))
            Dim prc As Decimal = CDec(myCoalesce(View.GetRowCellValue(e.RowHandle, "TOTAL AMOUNT NON ADDITIONAL"), "0.00"))
            Select Case summaryID
                Case "a"
                    tot_cost += cost
                    tot_prc += prc
                Case "b"
                    tot_cost_grp += cost
                    tot_prc_grp += prc
            End Select
        End If

        ' Finalization 
        If e.SummaryProcess = DevExpress.Data.CustomSummaryProcess.Finalize Then
            Select Case summaryID
                Case "a" 'total summary
                    Dim sum_res As Decimal = 0.0
                    Try
                        sum_res = tot_prc / tot_cost
                    Catch ex As Exception
                    End Try
                    e.TotalValue = sum_res
                Case "b" 'group summary
                    Dim sum_res As Decimal = 0.0
                    Try
                        sum_res = tot_prc_grp / tot_cost_grp
                    Catch ex As Exception
                    End Try
                    e.TotalValue = sum_res
            End Select
        End If
    End Sub

    Private Sub BtnAdd_Click(sender As Object, e As EventArgs) Handles BtnAdd.Click
        Cursor = Cursors.WaitCursor
        FormProdDemandRevSingle.ShowDialog()
        Cursor = Cursors.Default
    End Sub

    Private Sub BtnCancell_Click(sender As Object, e As EventArgs) Handles BtnCancell.Click
        Dim confirm As DialogResult = DevExpress.XtraEditors.XtraMessageBox.Show("Are you sure you want to cancelled this propose ?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
        If confirm = Windows.Forms.DialogResult.Yes Then
            Cursor = Cursors.WaitCursor
            Dim query As String = "UPDATE tb_prod_demand_rev SET id_report_status=5 WHERE id_prod_demand_rev='" + id + "'"
            execute_non_query(query, True, "", "", "", "")

            'nonaktif mark
            Dim queryrm = String.Format("UPDATE tb_report_mark SET report_mark_lead_time=NULL,report_mark_start_datetime=NULL WHERE report_mark_type='{0}' AND id_report='{1}' AND id_report_status>'1'", rmt, id, "5")
            execute_non_query(queryrm, True, "", "", "", "")

            FormProdDemandRev.viewData()
            FormProdDemandRev.GVData.FocusedRowHandle = find_row(FormProdDemandRev.GVData, "id_prod_demand_rev", id)
            actionLoad()
            Cursor = Cursors.Default
        End If
    End Sub

    Private Sub BtnConfirm_Click(sender As Object, e As EventArgs) Handles BtnConfirm.Click
        Cursor = Cursors.WaitCursor
        'cek file
        Dim cond_exist_file As Boolean = True
        Dim query_file As String = "SELECT * FROM tb_doc d WHERE d.report_mark_type=" + rmt + " AND d.id_report=" + id + ""
        Dim data_file As DataTable = execute_query(query_file, -1, True, "", "", "", "")
        If data_file.Rows.Count <= 0 Then
            cond_exist_file = False
        End If

        If Not cond_exist_file Then
            stopCustom("Please attach document first")
        ElseIf GVRevision.RowCount <= 0 Then
            stopCustom("No revisions were made. If you want to cancel this revision, please click 'Cancel Propose'")
        Else
            Dim confirm As DialogResult = DevExpress.XtraEditors.XtraMessageBox.Show("Are you sure you want to confirm PD revision ?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
            If confirm = Windows.Forms.DialogResult.Yes Then
                Cursor = Cursors.WaitCursor
                'update confirm
                Dim query As String = "UPDATE tb_prod_demand_rev SET is_confirm=1 WHERE id_prod_demand_rev='" + id + "'"
                execute_non_query(query, True, "", "", "", "")

                'submit approval
                submit_who_prepared(rmt, id, id_user)
                BtnConfirm.Visible = False
                actionLoad()
                infoCustom("PD Revision submitted. Waiting for approval.")
                Cursor = Cursors.Default
            End If
        End If
        Cursor = Cursors.Default
    End Sub

    Private Sub BtnPrint_Click(sender As Object, e As EventArgs) Handles BtnPrint.Click
        If id_report_status = "6" Then
            Cursor = Cursors.WaitCursor
            ReportProdDemandRev.id = id
            ReportProdDemandRev.rmt = rmt
            If XTCRevision.SelectedTabPageIndex = 0 Then
                ReportProdDemandRev.dt = GCRevision.DataSource
                ReportProdDemandRev.type = "1"
            ElseIf XTCRevision.SelectedTabPageIndex = 1 Then
                ReportProdDemandRev.dt = GCData.DataSource
                ReportProdDemandRev.type = "2"
            End If
            Dim Report As New ReportProdDemandRev()

            ' '... 
            ' ' creating and saving the view's layout to a new memory stream 
            Dim str As System.IO.Stream
            str = New System.IO.MemoryStream()
            GVData.SaveLayoutToStream(str, DevExpress.Utils.OptionsLayoutBase.FullLayout)
            str.Seek(0, System.IO.SeekOrigin.Begin)
            Report.GVData.RestoreLayoutFromStream(str, DevExpress.Utils.OptionsLayoutBase.FullLayout)
            str.Seek(0, System.IO.SeekOrigin.Begin)

            'Grid Detail
            ReportStyleGridview(Report.GVData)

            'Parse val
            Report.LabelNumber.Text = TxtProdDemandNumber.Text
            Report.LabelRev.Text = TxtRevision.Text

            'Show the report's preview. 
            Dim Tool As DevExpress.XtraReports.UI.ReportPrintTool = New DevExpress.XtraReports.UI.ReportPrintTool(Report)
            Tool.PrintingSystem.SetCommandVisibility(DevExpress.XtraPrinting.PrintingSystemCommand.ExportFile, DevExpress.XtraPrinting.CommandVisibility.None)
            Tool.PrintingSystem.SetCommandVisibility(DevExpress.XtraPrinting.PrintingSystemCommand.SendFile, DevExpress.XtraPrinting.CommandVisibility.None)
            Tool.ShowRibbonPreviewDialog()
            Cursor = Cursors.Default
        Else
            If XTCRevision.SelectedTabPageIndex = 0 Then
                print_raw_no_export(GCRevision)
            ElseIf XTCRevision.SelectedTabPageIndex = 1 Then
                print_raw_no_export(GCData)
            End If
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
        FormReportMark.is_view = "1"
        FormReportMark.form_origin = Name
        FormReportMark.ShowDialog()
        Cursor = Cursors.Default
    End Sub

    Private Sub GVRevision_CustomColumnDisplayText(sender As Object, e As DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs) Handles GVRevision.CustomColumnDisplayText
        If e.Column.FieldName = "NO" Then
            e.DisplayText = (e.ListSourceRowIndex + 1).ToString()
        End If
    End Sub

    Private Sub XTCRevision_SelectedPageChanged(sender As Object, e As DevExpress.XtraTab.TabPageChangedEventArgs) Handles XTCRevision.SelectedPageChanged
        If XTCRevision.SelectedTabPageIndex = 1 Then
            viewPDAll()
        End If
    End Sub

    Dim tot_cost2 As Decimal
    Dim tot_prc2 As Decimal
    Dim tot_cost_grp2 As Decimal
    Dim tot_prc_grp2 As Decimal
    Private Sub GVData_CustomSummaryCalculate(sender As Object, e As DevExpress.Data.CustomSummaryEventArgs) Handles GVData.CustomSummaryCalculate

        Dim summaryID As String = Convert.ToString(CType(e.Item, DevExpress.XtraGrid.GridSummaryItem).Tag)
        Dim View As DevExpress.XtraGrid.Views.Grid.GridView = CType(sender, DevExpress.XtraGrid.Views.Grid.GridView)

        ' Initialization 
        If e.SummaryProcess = DevExpress.Data.CustomSummaryProcess.Start Then
            tot_cost2 = 0.0
            tot_prc2 = 0.0
            tot_cost_grp2 = 0.0
            tot_prc_grp2 = 0.0
        End If

        ' Calculation 
        If e.SummaryProcess = DevExpress.Data.CustomSummaryProcess.Calculate Then
            Dim cost As Decimal = CDec(myCoalesce(View.GetRowCellValue(e.RowHandle, "TOTAL COST NON ADDITIONAL").ToString, "0.00"))
            Dim prc As Decimal = CDec(myCoalesce(View.GetRowCellValue(e.RowHandle, "TOTAL AMOUNT NON ADDITIONAL"), "0.00"))
            Select Case summaryID
                Case "c"
                    tot_cost2 += cost
                    tot_prc2 += prc
                Case "d"
                    tot_cost_grp2 += cost
                    tot_prc_grp2 += prc
            End Select
        End If

        ' Finalization 
        If e.SummaryProcess = DevExpress.Data.CustomSummaryProcess.Finalize Then
            Select Case summaryID
                Case "c" 'total summary
                    Dim sum_res As Decimal = 0.0
                    Try
                        sum_res = tot_prc2 / tot_cost2
                    Catch ex As Exception
                    End Try
                    e.TotalValue = sum_res
                Case "d" 'group summary
                    Dim sum_res As Decimal = 0.0
                    Try
                        sum_res = tot_prc_grp2 / tot_cost_grp2
                    Catch ex As Exception
                    End Try
                    e.TotalValue = sum_res
            End Select
        End If
    End Sub

    Private Sub GVData_CustomColumnDisplayText(sender As Object, e As DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs) Handles GVData.CustomColumnDisplayText
        If e.Column.FieldName = "NO" Then
            e.DisplayText = (e.ListSourceRowIndex + 1).ToString()
        End If
    End Sub

    Private Sub CEShowHighlight_CheckedChanged(sender As Object, e As EventArgs) Handles CEShowHighlight.CheckedChanged
        AddHandler GVData.RowStyle, AddressOf custom_cell
        GCData.Focus()
    End Sub

    Public Sub custom_cell(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Grid.RowStyleEventArgs)
        Dim View As DevExpress.XtraGrid.Views.Grid.GridView = sender

        If CEShowHighlight.EditValue = True Then
            Dim currview As DevExpress.XtraGrid.Views.Grid.GridView = TryCast(sender, DevExpress.XtraGrid.Views.Grid.GridView)
            Dim stt As String = "0"
            Try
                stt = currview.GetRowCellValue(e.RowHandle, "id_pd_status_rev").ToString
            Catch ex As Exception
                stt = "0"
            End Try

            If stt = "1" Then
                e.Appearance.BackColor = Color.Yellow
            ElseIf stt = "2" Then
                e.Appearance.BackColor = Color.Crimson
            Else
                e.Appearance.BackColor = Color.Empty
            End If
        Else
            e.Appearance.BackColor = Color.Empty
        End If
    End Sub

    Private Sub BtnDel_Click(sender As Object, e As EventArgs) Handles BtnDel.Click
        If GVRevision.RowCount > 0 And GVRevision.FocusedRowHandle >= 0 Then
            Dim confirm As DialogResult = DevExpress.XtraEditors.XtraMessageBox.Show("Are you sure you want to delete this article ?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
            If confirm = Windows.Forms.DialogResult.Yes Then
                Dim id_prod_demand_design_rev As String = GVRevision.GetFocusedRowCellValue("id_prod_demand_design_rev").ToString
                Dim query As String = "DELETE FROM tb_prod_demand_design_rev WHERE id_prod_demand_design_rev='" + id_prod_demand_design_rev + "' "
                execute_non_query(query, True, "", "", "", "")
                viewDetail()
            End If
        End If
    End Sub

    Private Sub ViewBreakdownSizeToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ViewBreakdownSizeToolStripMenuItem.Click
        Cursor = Cursors.WaitCursor
        If XTCRevision.SelectedTabPageIndex = 0 Then
            If GVRevision.RowCount > 0 And GVRevision.FocusedRowHandle >= 0 Then
                Dim id_prod_demand_design_rev As String = GVRevision.GetFocusedRowCellValue("id_prod_demand_design_rev").ToString
                Dim id_prod_demand_design As String = GVRevision.GetFocusedRowCellValue("id_prod_demand_design").ToString
                FormProdDemandRevBreakSize.LabelTitle.Text = GVRevision.GetFocusedRowCellValue("DESCRIPTION").ToString
                FormProdDemandRevBreakSize.LabelSubTitle.Text = GVRevision.GetFocusedRowCellValue("CODE").ToString
                FormProdDemandRevBreakSize.id_pdd_rev = id_prod_demand_design_rev
                FormProdDemandRevBreakSize.id_pdd = id_prod_demand_design
                FormProdDemandRevBreakSize.ShowDialog()
            End If
        Else
            If GVData.RowCount > 0 And GVData.FocusedRowHandle >= 0 Then
                Dim id_pd_status_rev As String = ""
                Try
                    id_pd_status_rev = GVData.GetFocusedRowCellValue("id_pd_status_rev").ToString
                Catch ex As Exception
                End Try
                If id_pd_status_rev = "" Then
                    Dim id_prod_demand_design As String = GVData.GetFocusedRowCellValue("id_prod_demand_design").ToString
                    FormProdDemandBreakSize.LabelTitle.Text = GVData.GetFocusedRowCellValue("DESCRIPTION").ToString
                    FormProdDemandBreakSize.LabelSubTitle.Text = GVData.GetFocusedRowCellValue("CODE").ToString
                    FormProdDemandBreakSize.id_pdd = id_prod_demand_design
                    FormProdDemandBreakSize.ShowDialog()
                Else
                    Dim id_prod_demand_design_rev As String = GVData.GetFocusedRowCellValue("id_prod_demand_design_rev").ToString
                    Dim id_prod_demand_design As String = GVData.GetFocusedRowCellValue("id_prod_demand_design").ToString
                    FormProdDemandRevBreakSize.LabelTitle.Text = GVData.GetFocusedRowCellValue("DESCRIPTION").ToString
                    FormProdDemandRevBreakSize.LabelSubTitle.Text = GVData.GetFocusedRowCellValue("CODE").ToString
                    FormProdDemandRevBreakSize.id_pdd_rev = id_prod_demand_design_rev
                    FormProdDemandRevBreakSize.id_pdd = id_prod_demand_design
                    FormProdDemandRevBreakSize.ShowDialog()
                End If
            End If
        End If
        Cursor = Cursors.Default
    End Sub
End Class