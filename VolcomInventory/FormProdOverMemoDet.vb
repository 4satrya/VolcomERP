Public Class FormProdOverMemoDet
    Public id_prod_over_memo As String = "-1"
    Public is_view As String = "-1"
    Dim id_report_status As String = "-1"
    Public action As String = "-1"

    Private Sub FormProdOverMemoDet_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        viewReportStatus()
        actionLoad()
    End Sub

    Sub actionLoad()
        If action = "ins" Then
            BtnPrint.Visible = False
            BtnAttachment.Visible = False
            BtnMark.Visible = False
            viewDetail()
        ElseIf action = "upd" Then
            BtnPrint.Visible = True
            BtnAttachment.Visible = True
            BtnMark.Visible = True
            Dim query_c As New ClassProdOverMemo()
            Dim query As String = query_c.queryMain("AND m.id_prod_over_memo=" + id_prod_over_memo + "", "2")
            Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")

            TxtMemoNumber.Text = data.Rows(0)("memo_number").ToString
            DECreated.EditValue = data.Rows(0)("created_date")
            DEExpired.EditValue = data.Rows(0)("expired_date")
            MENote.Text = data.Rows(0)("memo_note").ToString
            LEReportStatus.ItemIndex = LEReportStatus.Properties.GetDataSourceRowIndex("id_report_status", data.Rows(0)("id_report_status").ToString)
            id_report_status = data.Rows(0)("id_report_status").ToString
            viewDetail()
            allow_status()
        End If
    End Sub

    'View Data
    Sub viewReportStatus()
        Dim query As String = "SELECT * FROM tb_lookup_report_status a ORDER BY a.id_report_status "
        'Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        viewLookupQuery(LEReportStatus, query, 0, "report_status", "id_report_status")
    End Sub

    Sub viewDetail()
        Dim query As String = "SELECT md.id_prod_over_memo_det, md.id_prod_over_memo, md.id_prod_order, po.prod_order_number, d.design_code AS `code`, d.design_display_name AS `name`, md.remark, md.qty
        FROM tb_prod_over_memo_det md
        INNER JOIN tb_prod_order po ON po.id_prod_order = md.id_prod_order
        INNER JOIN tb_prod_demand_design pdd ON pdd.id_prod_demand_design = po.id_prod_demand_design
        INNER JOIN tb_m_design d ON d.id_design = pdd.id_design
        WHERE md.id_prod_over_memo=" + id_prod_over_memo + " "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCData.DataSource = data
    End Sub

    Sub allow_status()
        TxtMemoNumber.Enabled = False
        MENote.Enabled = False
        BtnSave.Enabled = False
        PanelControlNav.Enabled = False

        If check_print_report_status(id_report_status) Then
            BtnPrint.Enabled = True
        Else
            BtnPrint.Enabled = False
        End If

        If is_view = "1" Then
            BtnSave.Visible = False
        End If
        'if completed
        If id_report_status = "6" Then
            LExpired.Visible = True
            DEExpired.Visible = True
        End If
    End Sub

    Private Sub TxtMemoNumber_Leave(sender As Object, e As EventArgs) Handles TxtMemoNumber.Leave
        Dim number As String = addSlashes(Trim(TxtMemoNumber.Text.ToString))
        Dim qc As String = "SELECT * FROM tb_prod_over_memo m WHERE m.memo_number='" + number + "' AND m.id_report_status!=5 "
        Dim dc As DataTable = execute_query(qc, -1, True, "", "", "", "")
        If dc.Rows.Count > 0 Then
            stopCustom("Memo number already exist !")
            TxtMemoNumber.Text = ""
        End If
    End Sub

    Private Sub BtnAttachment_Click(sender As Object, e As EventArgs) Handles BtnAttachment.Click
        showAttach()
    End Sub

    Sub showAttach()
        Cursor = Cursors.WaitCursor
        FormDocumentUpload.report_mark_type = "126"
        FormDocumentUpload.id_report = id_prod_over_memo
        If is_view = "1" Or id_report_status = "6" Then
            FormDocumentUpload.is_view = "1"
        End If
        FormDocumentUpload.ShowDialog()
        Cursor = Cursors.Default
    End Sub

    Private Sub BtnMark_Click(sender As Object, e As EventArgs) Handles BtnMark.Click
        Cursor = Cursors.WaitCursor
        FormReportMark.report_mark_type = "126"
        FormReportMark.id_report = id_prod_over_memo
        If is_view = "1" Then
            FormReportMark.is_view = "1"
        End If
        FormReportMark.form_origin = Name
        FormReportMark.ShowDialog()
        Cursor = Cursors.Default
    End Sub

    Private Sub BtnDelete_Click(sender As Object, e As EventArgs) Handles BtnDelete.Click
        If GVData.RowCount > 0 And GVData.FocusedRowHandle >= 0 Then
            Cursor = Cursors.WaitCursor
            Dim confirm As DialogResult = DevExpress.XtraEditors.XtraMessageBox.Show("Are you sure you want to delete this PO? ", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
            If confirm = Windows.Forms.DialogResult.Yes Then
                GVData.DeleteRow(GVData.FocusedRowHandle)
                CType(GCData.DataSource, DataTable).AcceptChanges()
                GCData.RefreshDataSource()
                GVData.RefreshData()
            End If
        End If
        Cursor = Cursors.Default
    End Sub

    Private Sub BtnAdd_Click(sender As Object, e As EventArgs) Handles BtnAdd.Click
        Cursor = Cursors.WaitCursor
        FormProdOverMemoSingle.data_par = GCData.DataSource
        FormProdOverMemoSingle.ShowDialog()
        Cursor = Cursors.Default
    End Sub

    Private Sub BtnClose_Click(sender As Object, e As EventArgs) Handles BtnClose.Click
        Close()
    End Sub

    Private Sub FormProdOverMemoDet_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub BtnSave_Click(sender As Object, e As EventArgs) Handles BtnSave.Click
        If TxtMemoNumber.Text = "" Or GVData.RowCount <= 0 Then
            stopCustom("Data can't blank !")
        Else
            Dim confirm As DialogResult = DevExpress.XtraEditors.XtraMessageBox.Show("Are you sure you want to continue this process? ", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
            If confirm = Windows.Forms.DialogResult.Yes Then
                Cursor = Cursors.WaitCursor
                Dim memo_number As String = Trim(addSlashes(TxtMemoNumber.Text))
                Dim lead_time As Integer = get_setup_field("prod_over_lead_time") 'in hour
                Dim memo_note As String = addSlashes(MENote.Text)

                'main
                Dim qi As String = "INSERT INTO tb_prod_over_memo(memo_number, created_date, lead_time, memo_note, id_report_status) 
                VALUES('" + memo_number + "', NOW(), '" + decimalSQL(lead_time.ToString) + "', '" + memo_note + "', 1); SELECT LAST_INSERT_ID(); "
                id_prod_over_memo = execute_query(qi, 0, True, "", "", "", "")

                'detail
                Dim qd As String = "INSERT INTO tb_prod_over_memo_det(id_prod_over_memo, id_prod_order, remark, qty) VALUES "
                For i As Integer = 0 To ((GVData.RowCount - 1) - GetGroupRowCount(GVData))
                    If i > 0 Then
                        qd += ", "
                    End If
                    qd += "('" + id_prod_over_memo + "', '" + GVData.GetRowCellValue(i, "id_prod_order").ToString + "', '" + GVData.GetRowCellValue(i, "remark").ToString + "', '" + decimalSQL(GVData.GetRowCellValue(i, "qty").ToString) + "') "
                Next
                execute_non_query(qd, True, "", "", "", "")

                'refresh
                action = "upd"
                actionLoad()
                FormProdOverMemo.viewData()
                FormProdOverMemo.GVMemo.FocusedRowHandle = find_row(FormProdOverMemo.GVMemo, "id_prod_over_memo", id_prod_over_memo)
                infoCustom("Memo : " + TxtMemoNumber.Text + " created successfully, please upload attachment file !")
                showAttach()
                Cursor = Cursors.Default
            End If
        End If
    End Sub

    Private Sub BtnPrint_Click(sender As Object, e As EventArgs) Handles BtnPrint.Click
        Cursor = Cursors.WaitCursor
        ReportProdOverMemo.id_report = id_prod_over_memo
        ReportProdOverMemo.dt = GCData.DataSource
        Dim Report As New ReportProdOverMemo()

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

        Report.LabelNo.Text = TxtMemoNumber.Text
        Report.LabelDate.Text = DECreated.Text
        Report.LabelNote.Text = MENote.Text

        'Show the report's preview. 
        Dim Tool As DevExpress.XtraReports.UI.ReportPrintTool = New DevExpress.XtraReports.UI.ReportPrintTool(Report)
        Tool.ShowPreviewDialog()
        Cursor = Cursors.Default
    End Sub
End Class