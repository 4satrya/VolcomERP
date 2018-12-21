﻿Public Class FormItemExpenseDet
    Public id As String = "-1"
    Public action As String = ""
    Public id_comp As String = "-1"
    Dim id_report_status As String = "-1"
    Public is_view As String = "-1"
    Dim is_confirm As String = "2"
    Dim created_date As String = ""

    Private Sub FormItemExpenseDet_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        viewReportStatus()
        viewCOA()
        viewCOARepo()
        viewPaymentMethod()
        actionLoad()
    End Sub

    Sub viewCOA()
        Dim query As String = "SELECT a.id_acc, a.acc_name, a.acc_description, a.id_acc_parent, 
        a.id_acc_parent, a.id_acc_cat, a.id_is_det, a.id_status, a.id_comp
        FROM tb_a_acc a WHERE a.id_status=1 AND a.id_is_det=2 "
        viewSearchLookupQuery(SLEPayFrom, query, "id_acc", "acc_description", "id_acc")
    End Sub

    Sub viewCOARepo()
        Dim query As String = "SELECT a.id_acc, a.acc_name, a.acc_description, a.id_acc_parent, 
        a.id_acc_parent, a.id_acc_cat, a.id_is_det, a.id_status, a.id_comp
        FROM tb_a_acc a WHERE a.id_status=1 AND a.id_is_det=2 "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        RepositoryItemSearchLookUpEdit1.DataSource = Nothing
        RepositoryItemSearchLookUpEdit1.DataSource = data
        RepositoryItemSearchLookUpEdit1.DisplayMember = "acc_description"
        RepositoryItemSearchLookUpEdit1.ValueMember = "id_acc"
    End Sub

    Sub viewPaymentMethod()
        Dim query As String = "SELECT * FROM tb_lookup_payment_purchasing p
        ORDER BY p.id_payment_purchasing ASC "
        viewLookupQuery(LEPaymentMethod, query, 0, "payment_purchasing", "id_payment_purchasing")
    End Sub

    Sub viewReportStatus()
        Dim query As String = "SELECT * FROM tb_lookup_report_status a ORDER BY a.id_report_status "
        'Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        viewLookupQuery(LEReportStatus, query, 0, "report_status", "id_report_status")
    End Sub

    Sub actionLoad()
        If action = "ins" Then
            'purc order detail
            SLEPayFrom.Focus()
            TxtNumber.Text = "[auto generate]"
            DECreated.EditValue = getTimeDB()
            viewDetail()
        Else
            Dim e As New ClassItemExpense()
            Dim query As String = e.queryMain("AND e.id_item_expense ='" + id + "' ", "1")
            Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")

            SLEPayFrom.EditValue = data.Rows(0)("id_acc_from").ToString
            Dim is_pay_later As String = data.Rows(0)("is_pay_later").ToString
            If is_pay_later = "1" Then
                id_comp = data.Rows(0)("id_comp").ToString
                TxtCompNumber.Text = data.Rows(0)("comp_number").ToString
                TxtCompName.Text = data.Rows(0)("comp_name").ToString
                DEDueDate.EditValue = data.Rows(0)("due_date")
                CEPayLater.EditValue = True
            Else
                CEPayLater.EditValue = False
            End If
            LEPaymentMethod.EditValue = data.Rows(0)("id_payment_purchasing").ToString
            id_report_status = data.Rows(0)("id_report_status").ToString
            TxtNumber.Text = data.Rows(0)("number").ToString
            created_date = DateTime.Parse(data.Rows(0)("created_date")).ToString("yyyy-MM-dd HH:mm:ss")
            DECreated.EditValue = data.Rows(0)("created_date")
            MENote.Text = data.Rows(0)("note").ToString
            LEReportStatus.ItemIndex = LEReportStatus.Properties.GetDataSourceRowIndex("id_report_status", data.Rows(0)("id_report_status").ToString)

            viewDetail()
            allow_status()
        End If
    End Sub

    Private Sub CEPayLater_CheckedChanged(sender As Object, e As EventArgs) Handles CEPayLater.CheckedChanged
        If CEPayLater.EditValue = True Then
            BtnBrowse.Enabled = True
            DEDueDate.Enabled = True
        Else
            id_comp = "-1"
            TxtCompName.Text = ""
            TxtCompNumber.Text = ""
            BtnBrowse.Enabled = False
            DEDueDate.Enabled = False
        End If
    End Sub

    Sub viewDetail()
        Cursor = Cursors.WaitCursor
        Dim query As String = "SELECT ed.id_item_expense_det, ed.id_item_expense, 
        ed.id_acc, a.acc_description AS `coa_desc`, ed.description, 
        ed.tax_percent, ed.tax_value, ed.amount 
        FROM tb_item_expense_det ed
        INNER JOIN tb_a_acc a ON a.id_acc = ed.id_acc
        WHERE ed.id_item_expense=" + id + " "
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
        SLEPayFrom.Enabled = False
        CEPayLater.Enabled = False
        BtnBrowse.Enabled = False
        DEDueDate.Enabled = False
        BtnSave.Visible = False
        MENote.Enabled = False

        If id_report_status = "6" Then
            BtnCancell.Visible = False
            BtnViewJournal.Visible = True
            BtnViewJournal.BringToFront()
        ElseIf id_report_status = "5" Then
            BtnCancell.Visible = False
        End If
    End Sub

    Private Sub FormItemExpenseDet_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub BtnCancell_Click(sender As Object, e As EventArgs) Handles BtnCancell.Click
        Dim confirm As DialogResult = DevExpress.XtraEditors.XtraMessageBox.Show("Are you sure you want to cancell this process ?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
        If confirm = Windows.Forms.DialogResult.Yes Then
            Cursor = Cursors.WaitCursor
            Dim query As String = "UPDATE tb_item_expense SET id_report_status=5 WHERE id_item_expense='" + id + "'"
            execute_non_query(query, True, "", "", "", "")

            'nonaktif mark
            Dim queryrm = String.Format("UPDATE tb_report_mark SET report_mark_lead_time=NULL,report_mark_start_datetime=NULL WHERE report_mark_type='{0}' AND id_report='{1}' AND id_report_status>'1'", 157, id, "5")
            execute_non_query(queryrm, True, "", "", "", "")

            FormItemExpense.viewData()
            FormItemExpense.GVData.FocusedRowHandle = find_row(FormItemExpense.GVData, "id_item_expense", id)
            actionLoad()
            Cursor = Cursors.Default
        End If
    End Sub

    Private Sub BtnPrint_Click(sender As Object, e As EventArgs) Handles BtnPrint.Click
        Cursor = Cursors.WaitCursor
        If id_report_status = "6" Then
            'Dim gcx As DevExpress.XtraGrid.GridControl = Nothing
            'Dim gvx As DevExpress.XtraGrid.Views.Grid.GridView = Nothing
            'If XTCReceive.SelectedTabPageIndex = 0 Then
            '    gcx = GCSummary
            '    gvx = GVSummary
            'ElseIf XTCReceive.SelectedTabPageIndex = 1 Then
            '    gcx = GCDetail
            '    gvx = GVDetail
            'ElseIf XTCReceive.SelectedTabPageIndex = 2 Then
            '    gcx = GCOrderDetail
            '    gvx = GVOrderDetail
            'End If
            'ReportPurcReceive.id = id
            'ReportPurcReceive.dt = gcx.DataSource
            'Dim Report As New ReportPurcReceive()

            '' '... 
            '' ' creating and saving the view's layout to a new memory stream 
            'Dim str As System.IO.Stream
            'str = New System.IO.MemoryStream()
            'gvx.SaveLayoutToStream(str, DevExpress.Utils.OptionsLayoutBase.FullLayout)
            'str.Seek(0, System.IO.SeekOrigin.Begin)
            'Report.GVData.RestoreLayoutFromStream(str, DevExpress.Utils.OptionsLayoutBase.FullLayout)
            'str.Seek(0, System.IO.SeekOrigin.Begin)

            ''Grid Detail
            'ReportStyleGridview(Report.GVData)

            ''Parse val
            'Report.LabelNumber.Text = TxtNumber.Text.ToUpper
            'Report.LabelOrderNumber.Text = TxtOrderNumber.Text.ToUpper
            'Report.LabelVendor.Text = TxtVendor.Text.ToUpper
            'Report.LabelDate.Text = DECreated.Text.ToString
            'Report.LNote.Text = MENote.Text.ToString
            'Report.LabelDONumber.Text = TxtDO.Text
            'Report.LabelArrivalDate.Text = DEArrivalDate.Text
            'If XTCReceive.SelectedTabPageIndex = 2 Then
            '    Report.LabelNumber.Visible = False
            '    Report.LabelDate.Visible = False
            '    Report.LNote.Visible = False
            '    Report.LNotex.Visible = False
            '    Report.XrLabel11.Visible = False
            '    Report.XrLabel10.Visible = False
            '    Report.XrLabel18.Visible = False
            '    Report.LabelTitle.Text = "ORDER DETAILS"
            '    Report.XrTable1.Visible = False   '
            '    Report.LabelDONumber.Visible = False
            '    Report.LabelDotDONumber.Visible = False
            '    Report.LabelTitleDONumber.Visible = False
            '    Report.LabelArrivalDate.Visible = False
            '    Report.LabelDotArrivalDate.Visible = False
            '    Report.LabelTitleArrivalDate.Visible = False
            'End If

            ''Show the report's preview. 
            'Dim Tool As DevExpress.XtraReports.UI.ReportPrintTool = New DevExpress.XtraReports.UI.ReportPrintTool(Report)
            'Tool.ShowPreviewDialog()
        Else
            print_raw_no_export(GCData)
        End If
        Cursor = Cursors.Default
    End Sub

    Private Sub BtnAttachment_Click(sender As Object, e As EventArgs) Handles BtnAttachment.Click
        attach()
    End Sub

    Sub attach()
        Cursor = Cursors.WaitCursor
        FormDocumentUpload.report_mark_type = "157"
        FormDocumentUpload.id_report = id
        FormDocumentUpload.is_only_pdf = True
        If is_view = "1" Or Not check_edit_report_status(id_report_status, "157", id) Then
            FormDocumentUpload.is_view = "1"
        End If
        FormDocumentUpload.ShowDialog()
        Cursor = Cursors.Default
    End Sub

    Private Sub BtnMark_Click(sender As Object, e As EventArgs) Handles BtnMark.Click
        Cursor = Cursors.WaitCursor
        FormReportMark.report_mark_type = "157"
        FormReportMark.id_report = id
        FormReportMark.is_view = is_view
        FormReportMark.form_origin = Name
        FormReportMark.ShowDialog()
        Cursor = Cursors.Default
    End Sub

    Private Sub GVData_CustomColumnDisplayText(sender As Object, e As DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs) Handles GVData.CustomColumnDisplayText
        If e.Column.FieldName = "no" Then
            e.DisplayText = (e.ListSourceRowIndex + 1).ToString()
        End If
    End Sub

    Private Sub BtnSave_Click(sender As Object, e As EventArgs) Handles BtnSave.Click

    End Sub

    Private Sub BtnViewJournal_Click(sender As Object, e As EventArgs) Handles BtnViewJournal.Click
        Cursor = Cursors.WaitCursor
        Dim id_acc_trans As String = ""
        Try
            id_acc_trans = execute_query("SELECT ad.id_acc_trans FROM tb_a_acc_trans_det ad
            WHERE ad.report_mark_type=157 AND ad.id_report=" + id + "
            GROUP BY ad.id_acc_trans ", 0, True, "", "", "", "")
        Catch ex As Exception
            id_acc_trans = ""
        End Try

        If id_acc_trans <> "" Then
            Dim s As New ClassShowPopUp()
            FormViewJournal.is_enable_view_doc = False
            FormViewJournal.BMark.Visible = False
            s.id_report = id_acc_trans
            s.report_mark_type = "36"
            s.show()
        Else
            warningCustom("Auto journal not found.")
        End If
        Cursor = Cursors.Default
    End Sub

    Private Sub BtnAdd_Click(sender As Object, e As EventArgs) Handles BtnAdd.Click
        Cursor = Cursors.WaitCursor
        GVData.AddNewRow()
        GVData.FocusedRowHandle = GVData.RowCount - 1
        Cursor = Cursors.Default
    End Sub

    Private Sub BtnDelete_Click(sender As Object, e As EventArgs) Handles BtnDelete.Click
        If GVData.RowCount > 0 And GVData.FocusedRowHandle >= 0 Then
            GVData.DeleteSelectedRows()
        End If
    End Sub
End Class