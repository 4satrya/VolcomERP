﻿Public Class FormPurchaseReturnDet
    Public id As String = "-1"
    Public action As String = ""
    Public id_purc_order As String = "-1"
    Dim id_report_status As String = "-1"
    Public is_view As String = "-1"
    Dim created_date As String = ""

    Private Sub FormPurchaseReturnDet_Load(sender As Object, e As EventArgs) Handles MyBase.Load
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
            'cek coa
            Dim qcoa As String = "SELECT * 
            FROM tb_opt_purchasing o
            INNER JOIN tb_a_acc d ON d.id_acc = o.acc_coa_receive 
            INNER JOIN tb_a_acc k ON k.id_acc = o.acc_coa_hutang 
            WHERE !ISNULL(d.id_acc) AND !ISNULL(k.id_acc) "
            Dim dcoa As DataTable = execute_query(qcoa, -1, True, "", "", "", "")
            If dcoa.Rows.Count <= 0 Then
                warningCustom("The account hasn't been mapped yet. Please contact accounting department.")
                Close()
            End If

            'purc order detail
            TxtNumber.Text = "[auto generate]"
            DECreated.EditValue = getTimeDB()
            viewDetail
        Else
            XTCReturn.SelectedTabPageIndex = 0

            Dim r As New ClassPurcReturn()
            Dim query As String = r.queryMain("AND ret.id_purc_return='" + id + "' ", "1")
            Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")

            id_report_status = data.Rows(0)("id_report_status").ToString
            TxtNumber.Text = data.Rows(0)("number").ToString
            created_date = DateTime.Parse(data.Rows(0)("created_date")).ToString("yyyy-MM-dd HH:mm:ss")
            DECreated.EditValue = data.Rows(0)("created_date")
            MENote.Text = data.Rows(0)("note").ToString
            LEReportStatus.ItemIndex = LEReportStatus.Properties.GetDataSourceRowIndex("id_report_status", data.Rows(0)("id_report_status").ToString)
            id_purc_order = data.Rows(0)("id_purc_order").ToString
            TxtOrderNumber.Text = data.Rows(0)("purc_order_number").ToString
            TxtVendor.Text = data.Rows(0)("vendor").ToString

            viewDetail()
            allow_status()
        End If
    End Sub

    Sub viewDetail()
        Cursor = Cursors.WaitCursor
        Dim query As String = ""
        If action = "ins" Then
            query = "SELECT pod.id_purc_order_det,req.purc_req_number, req.id_departement,d.departement, pod.id_item, i.item_desc, i.id_uom, u.uom, pod.`value`, 
            pod.qty AS `qty_order`, 0 AS `qty`
            FROM tb_purc_order_det pod
            INNER JOIN tb_item i ON i.id_item = pod.id_item
            INNER JOIN tb_m_uom u ON u.id_uom = i.id_uom
            INNER JOIN tb_purc_req_det reqd ON reqd.id_purc_req_det = pod.id_purc_req_det
            INNER JOIN tb_purc_req req ON req.id_purc_req = reqd.id_purc_req
            INNER JOIN tb_m_departement d ON d.id_departement = req.id_departement
            WHERE pod.id_purc_order=" + id_purc_order + " "
            Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
            GCDetail.DataSource = data
            GVDetail.BestFitColumns()
        ElseIf action = "upd" Then

        End If
        Cursor = Cursors.Default
    End Sub

    Sub viewSummary()

    End Sub

    Sub viewOrderDetails()
        Cursor = Cursors.WaitCursor
        Dim po As New ClassPurcOrder()
        Dim query As String = po.queryOrderDetails(id_purc_order, "")
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCOrderDetail.DataSource = data
        GVOrderDetail.BestFitColumns()
        Cursor = Cursors.Default
    End Sub

    Sub allow_status()
        BtnCancell.Visible = True
        BtnMark.Visible = True
        BtnAttachment.Visible = True
        BtnPrint.Visible = True
        GVSummary.OptionsBehavior.Editable = False
        GVDetail.OptionsBehavior.Editable = False

        If check_edit_report_status(id_report_status, "148", id) Then
            BtnSave.Visible = False
            MENote.Enabled = True
        Else
            BtnSave.Visible = False
            MENote.Enabled = False
        End If

        If id_report_status = "6" Then
            BtnCancell.Visible = False
            BtnViewJournal.Visible = True
            BtnViewJournal.BringToFront()
        ElseIf id_report_status = "5" Then
            BtnCancell.Visible = False
        End If
    End Sub

    Private Sub FormPurchaseReturnDet_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub BtnCancell_Click(sender As Object, e As EventArgs) Handles BtnCancell.Click
        Dim confirm As DialogResult = DevExpress.XtraEditors.XtraMessageBox.Show("Are you sure you want to cancell this process ?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
        If confirm = Windows.Forms.DialogResult.Yes Then
            Cursor = Cursors.WaitCursor
            Dim query As String = "UPDATE tb_purc_return SET id_report_status=5 WHERE id_purc_return='" + id + "'"
            execute_non_query(query, True, "", "", "", "")

            'nonaktif mark
            Dim queryrm = String.Format("UPDATE tb_report_mark SET report_mark_lead_time=NULL,report_mark_start_datetime=NULL WHERE report_mark_type='{0}' AND id_report='{1}' AND id_report_status>'1'", 152, id, "5")
            execute_non_query(queryrm, True, "", "", "", "")

            'cancell out
            '?

            FormPurcReturn.viewReturn()
            FormPurcReturn.GVReturn.FocusedRowHandle = find_row(FormPurcReturn.GVReturn, "id_purc_return", id)
            actionLoad()
            Cursor = Cursors.Default
        End If
    End Sub

    Private Sub BtnPrint_Click(sender As Object, e As EventArgs) Handles BtnPrint.Click
        'Cursor = Cursors.WaitCursor
        'If id_report_status = "6" Then
        '    Dim gcx As DevExpress.XtraGrid.GridControl = Nothing
        '    Dim gvx As DevExpress.XtraGrid.Views.Grid.GridView = Nothing
        '    If XTCReceive.SelectedTabPageIndex = 0 Then
        '        gcx = GCSummary
        '        gvx = GVSummary
        '    ElseIf XTCReceive.SelectedTabPageIndex = 1 Then
        '        gcx = GCDetail
        '        gvx = GVDetail
        '    ElseIf XTCReceive.SelectedTabPageIndex = 2 Then
        '        gcx = GCOrderDetail
        '        gvx = GVOrderDetail
        '    End If
        '    ReportPurcReceive.id = id
        '    ReportPurcReceive.dt = gcx.DataSource
        '    Dim Report As New ReportPurcReceive()

        '    ' '... 
        '    ' ' creating and saving the view's layout to a new memory stream 
        '    Dim str As System.IO.Stream
        '    str = New System.IO.MemoryStream()
        '    gvx.SaveLayoutToStream(str, DevExpress.Utils.OptionsLayoutBase.FullLayout)
        '    str.Seek(0, System.IO.SeekOrigin.Begin)
        '    Report.GVData.RestoreLayoutFromStream(str, DevExpress.Utils.OptionsLayoutBase.FullLayout)
        '    str.Seek(0, System.IO.SeekOrigin.Begin)

        '    'Grid Detail
        '    ReportStyleGridview(Report.GVData)

        '    'Parse val
        '    Report.LabelNumber.Text = TxtOrderNumber.Text.ToUpper
        '    Report.LabelOrderNumber.Text = TxtOrderNumber.Text.ToUpper
        '    Report.LabelVendor.Text = TxtVendor.Text.ToUpper
        '    Report.LabelDate.Text = DECreated.Text.ToString
        '    Report.LNote.Text = MENote.Text.ToString
        '    If XTCReceive.SelectedTabPageIndex = 2 Then
        '        Report.LabelNumber.Visible = False
        '        Report.LabelDate.Visible = False
        '        Report.LNote.Visible = False
        '        Report.LNotex.Visible = False
        '        Report.XrLabel11.Visible = False
        '        Report.XrLabel10.Visible = False
        '        Report.XrLabel18.Visible = False
        '        Report.LabelTitle.Text = "ORDER DETAILS"
        '        Report.XrTable1.Visible = False   '
        '    End If

        '    'Show the report's preview. 
        '    Dim Tool As DevExpress.XtraReports.UI.ReportPrintTool = New DevExpress.XtraReports.UI.ReportPrintTool(Report)
        '    Tool.ShowPreviewDialog()
        'Else
        '    If XTCReceive.SelectedTabPageIndex = 0 Then
        '        print_raw_no_export(GCSummary)
        '    ElseIf XTCReceive.SelectedTabPageIndex = 1 Then
        '        print_raw_no_export(GCDetail)
        '    ElseIf XTCReceive.SelectedTabPageIndex = 2 Then
        '        print_raw_no_export(GCOrderDetail)
        '    End If
        'End If
        'Cursor = Cursors.Default
    End Sub

    Private Sub BtnAttachment_Click(sender As Object, e As EventArgs) Handles BtnAttachment.Click
        attach
    End Sub

    Sub attach()
        Cursor = Cursors.WaitCursor
        FormDocumentUpload.report_mark_type = "152"
        FormDocumentUpload.id_report = id
        FormDocumentUpload.is_only_pdf = True
        If is_view = "1" Or Not check_edit_report_status(id_report_status, "152", id) Then
            FormDocumentUpload.is_view = "1"
        End If
        FormDocumentUpload.ShowDialog()
        Cursor = Cursors.Default
    End Sub

    Private Sub BtnMark_Click(sender As Object, e As EventArgs) Handles BtnMark.Click
        Cursor = Cursors.WaitCursor
        FormReportMark.report_mark_type = "152"
        FormReportMark.id_report = id
        FormReportMark.is_view = is_view
        FormReportMark.form_origin = Name
        FormReportMark.ShowDialog()
        Cursor = Cursors.Default
    End Sub

    Private Sub GVDetail_CustomColumnDisplayText(sender As Object, e As DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs) Handles GVDetail.CustomColumnDisplayText
        If e.Column.FieldName = "no" Then
            e.DisplayText = (e.ListSourceRowIndex + 1).ToString()
        End If
    End Sub

    Private Sub GVSummary_CustomColumnDisplayText(sender As Object, e As DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs) Handles GVSummary.CustomColumnDisplayText
        If e.Column.FieldName = "no" Then
            e.DisplayText = (e.ListSourceRowIndex + 1).ToString()
        End If
    End Sub

    Private Sub GVOrderDetail_CustomColumnDisplayText(sender As Object, e As DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs) Handles GVOrderDetail.CustomColumnDisplayText
        If e.Column.FieldName = "no" Then
            e.DisplayText = (e.ListSourceRowIndex + 1).ToString()
        End If
    End Sub

    Private Sub XTCReturn_SelectedPageChanged(sender As Object, e As DevExpress.XtraTab.TabPageChangedEventArgs) Handles XTCReturn.SelectedPageChanged
        If XTCReturn.SelectedTabPageIndex = 0 Then
        ElseIf XTCReturn.SelectedTabPageIndex = 1 Then
            viewSummary()
        ElseIf XTCReturn.SelectedTabPageIndex = 2 Then
            viewOrderDetails()
        End If
    End Sub


    Public Sub custom_cell(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Grid.RowStyleEventArgs)
        Dim View As DevExpress.XtraGrid.Views.Grid.GridView = sender

        If CEShowHighlight.EditValue = True Then
            Dim currview As DevExpress.XtraGrid.Views.Grid.GridView = TryCast(sender, DevExpress.XtraGrid.Views.Grid.GridView)
            Dim qty_remaining As String = "0"
            Try
                qty_remaining = currview.GetRowCellValue(e.RowHandle, "qty_remaining")
            Catch ex As Exception
                qty_remaining = "0"
            End Try

            If qty_remaining > 0 Then
                e.Appearance.BackColor = Color.Yellow
            Else
                e.Appearance.BackColor = Color.Empty
            End If
        Else
            e.Appearance.BackColor = Color.Empty
        End If
    End Sub

    Private Sub CEShowHighlight_CheckedChanged(sender As Object, e As EventArgs) Handles CEShowHighlight.CheckedChanged
        AddHandler GVOrderDetail.RowStyle, AddressOf custom_cell
        GVOrderDetail.Focus()
    End Sub

    Private Sub BtnSave_Click(sender As Object, e As EventArgs) Handles BtnSave.Click

    End Sub

    Private Sub BtnViewJournal_Click(sender As Object, e As EventArgs) Handles BtnViewJournal.Click
        Cursor = Cursors.WaitCursor
        Dim id_acc_trans As String = ""
        Try
            id_acc_trans = execute_query("SELECT ad.id_acc_trans FROM tb_a_acc_trans_det ad
            WHERE ad.report_mark_type=152 AND ad.id_report=" + id + "
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

    Private Sub GVDetail_CellValueChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles GVDetail.CellValueChanged
        Cursor = Cursors.WaitCursor
        Dim rh As Integer = e.RowHandle
        Dim id_departement As String = GVDetail.GetRowCellValue(rh, "id_departement").ToString
        Dim id_purc_order_det As String = GVDetail.GetRowCellValue(rh, "id_purc_order_det").ToString
        Dim id_item As String = GVDetail.GetRowCellValue(rh, "id_item").ToString
        If e.Column.FieldName = "qty" Then
            If e.Value > 0 Then
                Dim old_value As Decimal = GVSummary.ActiveEditor.OldEditValue
                Dim err As String = ""

                'cek rec
                Dim drec As DataTable = getAllowedRec(id_purc_order, "AND pod.id_purc_order_det=" + id_purc_order_det + " ")
                If e.Value > drec.Rows(0)("qty_bal") Then
                    err += "- Quantity of return  must not exceed the permitted : " + drec.Rows(0)("qty_bal").ToString + System.Environment.NewLine
                End If

                'cek stok
                Dim st As New ClassPurcItemStock
                Dim date_until_selected As String = "9999-01-01"
                Dim cond As String = "AND i.id_departement=" + id_departement + " AND i.id_item = '" + id_item + "' "
                Dim qst As String = st.queryGetStock(cond, date_until_selected)
                Dim dst As DataTable = execute_query(qst, -1, True, "", "", "", "")
                If e.Value > dst.Rows(0)("qty") Then
                    err += "- Quantity of return must not exceed available stock : " + dst.Rows(0)("qty").ToString + System.Environment.NewLine
                End If

                If err <> "" Then
                    warningCustom("Cannot return this item." + System.Environment.NewLine + err)
                    GVSummary.SetRowCellValue(rh, "qty", old_value)
                End If
                GVSummary.BestFitColumns()
            End If
        End If
    End Sub

    Function getAllowedRec(ByVal id_purc_order As String, ByVal cond As String)
        Dim query As String = "SELECT pod.id_purc_order_det, (IFNULL(rd.qty,0)-IFNULL(ret.qty,0)) AS `qty_bal`
        FROM tb_purc_order_det pod
        LEFT JOIN (
	        SELECT rd.id_purc_order_det, SUM(rd.qty) AS `qty` 
	        FROM tb_purc_rec_det rd
	        INNER JOIN tb_purc_rec r ON r.id_purc_rec = rd.id_purc_rec
	        WHERE r.id_purc_order=" + id_purc_order + " AND r.id_report_status!=5 
	        GROUP BY rd.id_purc_order_det
        ) rd ON rd.id_purc_order_det = pod.id_purc_order_det
        LEFT JOIN (
	        SELECT rd.id_purc_order_det, SUM(rd.qty) AS `qty` 
	        FROM tb_purc_return_det rd
	        INNER JOIN tb_purc_return r ON r.id_purc_return = rd.id_purc_return
	        WHERE r.id_purc_order=" + id_purc_order + " AND r.id_report_status!=5 
	        GROUP BY rd.id_purc_order_det
        ) ret ON ret.id_purc_order_det = pod.id_purc_order_det
        WHERE pod.id_purc_order=" + id_purc_order + " " + cond
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        Return data
    End Function
End Class