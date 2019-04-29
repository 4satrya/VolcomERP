Public Class FormSalesTargetProposeDet
    Public id As String = "-1"
    Public is_view As String = "-1"
    Dim id_report_status As String = "-1"
    Dim is_confirm As String = "-1"
    Dim rmt As String = "191"

    Private Sub FormSalesTargetProposeDet_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        TxtTotalInput.EditValue = 0.0
        viewReportStatus()
        actionLoad()
    End Sub

    Sub viewReportStatus()
        Dim query As String = "SELECT * FROM tb_lookup_report_status a ORDER BY a.id_report_status "
        'Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        viewLookupQuery(LEReportStatus, query, 0, "report_status", "id_report_status")
    End Sub

    Sub actionLoad()
        Cursor = Cursors.WaitCursor
        'main
        Dim t As New ClassSalesTarget()
        Dim query As String = t.queryMain("AND t.id_sales_trg_propose=" + id + " ", "1")
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        TxtNumber.Text = data.Rows(0)("number").ToString
        TxtYear.Text = data.Rows(0)("year").ToString
        MENote.Text = data.Rows(0)("note").ToString
        DECreated.EditValue = data.Rows(0)("created_date")
        DEUpdated.EditValue = data.Rows(0)("updated_date")
        TxtUpdatedBy.Text = data.Rows(0)("updated_by_name").ToString
        LEReportStatus.ItemIndex = LEReportStatus.Properties.GetDataSourceRowIndex("id_report_status", data.Rows(0)("id_report_status").ToString)
        id_report_status = data.Rows(0)("id_report_status").ToString
        is_confirm = data.Rows(0)("is_confirm").ToString

        'detail
        viewDetail()
        allow_status()
        Cursor = Cursors.Default
    End Sub

    Sub viewDetail()
        Cursor = Cursors.WaitCursor
        Dim query As String = "CALL view_sales_trg_propose(" + id + ") "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCData.DataSource = data
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
            BtnPrint.Visible = False
            MENote.Enabled = False
            GVData.OptionsBehavior.ReadOnly = False
            BtnAdd.Visible = True
            BtnEdit.Visible = True
            BtnDelete.Visible = True
            BtnImportFromExcel.Visible = True
            BtnChangeHead.Enabled = True
        Else
            BtnConfirm.Visible = False
            BtnMark.Visible = True
            MENote.Enabled = False
            BtnPrint.Visible = True
            MENote.Enabled = False
            GVData.OptionsBehavior.ReadOnly = True
            BtnAdd.Visible = False
            BtnEdit.Visible = False
            BtnDelete.Visible = False
            BtnImportFromExcel.Visible = False
            BtnChangeHead.Enabled = False
        End If

        If id_report_status = "6" Then
            BtnCancell.Visible = False
        ElseIf id_report_status = "5" Then
            BtnCancell.Visible = False
            BtnConfirm.Visible = False
            MENote.Enabled = False
            BtnPrint.Visible = False
            MENote.Enabled = False
            GVData.OptionsBehavior.ReadOnly = True
            BtnAdd.Visible = False
            BtnEdit.Visible = False
            BtnDelete.Visible = False
            BtnImportFromExcel.Visible = False
            BtnChangeHead.Enabled = False
        End If
    End Sub

    Private Sub BtnAdd_Click(sender As Object, e As EventArgs) Handles BtnAdd.Click
        Cursor = Cursors.WaitCursor
        FormSalesTargetProposeAdd.ShowDialog()
        Cursor = Cursors.Default
    End Sub

    Private Sub BtnEdit_Click(sender As Object, e As EventArgs) Handles BtnEdit.Click

    End Sub

    Private Sub BtnDelete_Click(sender As Object, e As EventArgs) Handles BtnDelete.Click

    End Sub

    Private Sub BtnImportFromExcel_Click(sender As Object, e As EventArgs) Handles BtnImportFromExcel.Click

    End Sub

    Private Sub BtnConfirm_Click(sender As Object, e As EventArgs) Handles BtnConfirm.Click
        makeSafeGV(GVData)
        If GVData.RowCount <= 0 Then
            stopCustom("No propose were made. If you want to cancel this propose, please click 'Cancel Propose'")
        Else
            Dim confirm As DialogResult = DevExpress.XtraEditors.XtraMessageBox.Show("Are you sure you want to confirm this Propose ?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
            If confirm = Windows.Forms.DialogResult.Yes Then
                Cursor = Cursors.WaitCursor

                'update confirm
                Dim query As String = "UPDATE tb_sales_trg_propose SET is_confirm=1 WHERE id_sales_trg_propose='" + id + "'"
                execute_non_query(query, True, "", "", "", "")

                'submit approval 
                submit_who_prepared(rmt, id, id_user)
                BtnConfirm.Visible = False
                actionLoad()
                infoCustom("Propose sales target submitted. Waiting for approval.")
                Cursor = Cursors.Default
            End If
        End If
    End Sub

    Private Sub BtnCancell_Click(sender As Object, e As EventArgs) Handles BtnCancell.Click
        Dim confirm As DialogResult = DevExpress.XtraEditors.XtraMessageBox.Show("Are you sure you want to cancelled this propose ?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
        If confirm = Windows.Forms.DialogResult.Yes Then
            Cursor = Cursors.WaitCursor
            Dim query As String = "UPDATE tb_sales_trg_propose SET id_report_status=5 WHERE id_sales_trg_propose='" + id + "'"
            execute_non_query(query, True, "", "", "", "")

            'nonaktif mark
            Dim queryrm = String.Format("UPDATE tb_report_mark SET report_mark_lead_time=NULL,report_mark_start_datetime=NULL WHERE report_mark_type='{0}' AND id_report='{1}' AND id_report_status>'1'", rmt, id, "5")
            execute_non_query(queryrm, True, "", "", "", "")

            FormSalesTargetPropose.viewPropose()
            FormSalesTargetPropose.GVData.FocusedRowHandle = find_row(FormSalesTargetPropose.GVData, "id_sales_trg_propose", id)
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
            'Dim gv As DevExpress.XtraGrid.Views.Grid.GridView = Nothing
            'gv = GVData
            'ReportFGProposePriceDetail.dt = GCData.DataSource
            'ReportFGProposePriceDetail.id = id
            'If id_report_status <> "6" Then
            '    ReportFGProposePriceDetail.is_pre = "1"
            'Else
            '    ReportFGProposePriceDetail.is_pre = "-1"
            'End If
            'ReportFGProposePriceDetail.id_report_status = LEReportStatus.EditValue.ToString

            'ReportFGProposePriceDetail.rmt = rmt
            'Dim Report As New ReportFGProposePriceDetail()

            ''... 
            '' creating And saving the view's layout to a new memory stream 
            'Dim str As System.IO.Stream
            'str = New System.IO.MemoryStream()
            'gv.SaveLayoutToStream(str, DevExpress.Utils.OptionsLayoutBase.FullLayout)
            'str.Seek(0, System.IO.SeekOrigin.Begin)
            'Report.GVData.RestoreLayoutFromStream(str, DevExpress.Utils.OptionsLayoutBase.FullLayout)
            'str.Seek(0, System.IO.SeekOrigin.Begin)

            ''style
            'Report.GVData.OptionsPrint.UsePrintStyles = True
            'Report.GVData.AppearancePrint.FilterPanel.BackColor = Color.Transparent
            'Report.GVData.AppearancePrint.FilterPanel.ForeColor = Color.Black
            'Report.GVData.AppearancePrint.FilterPanel.Font = New Font("Tahoma", 5, FontStyle.Regular)

            'Report.GVData.AppearancePrint.GroupFooter.BackColor = Color.Transparent
            'Report.GVData.AppearancePrint.GroupFooter.ForeColor = Color.Black
            'Report.GVData.AppearancePrint.GroupFooter.Font = New Font("Tahoma", 5, FontStyle.Bold)

            'Report.GVData.AppearancePrint.GroupRow.BackColor = Color.Transparent
            'Report.GVData.AppearancePrint.GroupRow.ForeColor = Color.Black
            'Report.GVData.AppearancePrint.GroupRow.Font = New Font("Tahoma", 5, FontStyle.Bold)


            'Report.GVData.AppearancePrint.HeaderPanel.BackColor = Color.Transparent
            'Report.GVData.AppearancePrint.HeaderPanel.ForeColor = Color.Black
            'Report.GVData.AppearancePrint.HeaderPanel.Font = New Font("Tahoma", 5, FontStyle.Bold)

            'Report.GVData.AppearancePrint.FooterPanel.BackColor = Color.Transparent
            'Report.GVData.AppearancePrint.FooterPanel.ForeColor = Color.Black
            'Report.GVData.AppearancePrint.FooterPanel.Font = New Font("Tahoma", 5.3, FontStyle.Bold)

            'Report.GVData.AppearancePrint.Row.Font = New Font("Tahoma", 5.3, FontStyle.Regular)

            'Report.GVData.OptionsPrint.ExpandAllDetails = True
            'Report.GVData.OptionsPrint.UsePrintStyles = True
            'Report.GVData.OptionsPrint.PrintDetails = True
            'Report.GVData.OptionsPrint.PrintFooter = True

            'Report.LabelNumber.Text = TxtNumber.Text
            'Report.LabelSeason.Text = SLESeason.Text
            'Report.LabelDivision.Text = TxtDivision.Text
            'Report.LabelSource.Text = TxtSource.Text.ToUpper
            'Report.LabelType.Text = TxtType.Text.ToUpper
            'Report.LabelDate.Text = DECreated.Text.ToUpper
            'Report.LabelStatus.Text = LEReportStatus.Text.ToUpper
            'Report.LNote.Text = MENote.Text

            '' Show the report's preview. 
            'Dim Tool As DevExpress.XtraReports.UI.ReportPrintTool = New DevExpress.XtraReports.UI.ReportPrintTool(Report)
            'Tool.ShowPreviewDialog()
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

    Private Sub FormSalesTargetProposeDet_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub GVData_CustomColumnDisplayText(sender As Object, e As DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs)
        If e.Column.FieldName = "no" Then
            e.DisplayText = (e.ListSourceRowIndex + 1).ToString()
        End If
    End Sub

    Private Sub BtnChangeHead_Click(sender As Object, e As EventArgs) Handles BtnChangeHead.Click
        Cursor = Cursors.WaitCursor
        FormSalesTargetProposeNew.action = "upd"
        FormSalesTargetProposeNew.id = id
        FormSalesTargetProposeNew.ShowDialog()
        Cursor = Cursors.Default
    End Sub
End Class