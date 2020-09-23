Public Class FormPayoutHistoryDetail
    Public id As String = "-1"
    Public rmt As String = "264"
    Public id_report_status As String = "-1"

    Private Sub FormPayoutHistoryDetail_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Cursor = Cursors.WaitCursor
        Dim query As String = "SELECT * FROM tb_list_payout_trans t WHERE t.id_list_payout_trans=" + id + " "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        TxtNumber.Text = data.Rows(0)("number").ToString
        DECreated.EditValue = data.Rows(0)("generate_date")
        id_report_status = data.Rows(0)("id_report_status").ToString
        viewData()
        Cursor = Cursors.Default
    End Sub

    Sub viewData()
        Cursor = Cursors.WaitCursor
        Dim query As String = "SELECT t.settlement_date, t.pay_type, t.bank, t.id AS `id_order`, t.sales_order_ol_shop_number, sp.customer_name, t.checkout_id, 
        t.payment, t.trans_fee, sp.sales_pos_number AS `invoice_number`, sh.number AS `ship_invoice_number`, t.invoice_amount, t.calculate_fee, t.other_price,
        IFNULL(v.id_list_payout_ver,0) AS `id_list_payout_ver`, v.number AS `reconcile_number`
        FROM tb_list_payout t 
        LEFT JOIN (
	        SELECT so.id_sales_order_ol_shop, GROUP_CONCAT(DISTINCT sp.sales_pos_number) AS `sales_pos_number`, so.customer_name
	        FROM tb_list_payout_det t  
	        INNER JOIN tb_sales_pos sp ON sp.id_sales_pos = t.id_sales_pos
	        INNER JOIN tb_pl_sales_order_del d ON d.id_pl_sales_order_del = sp.id_pl_sales_order_del
	        INNER JOIN tb_sales_order so ON so.id_sales_order = d.id_sales_order
	        WHERE t.id_list_payout_trans=" + id + "
	        GROUP BY so.id_sales_order_ol_shop
        ) sp ON sp.id_sales_order_ol_shop = t.id
        LEFT JOIN (
            SELECT s.id_invoice_ship, s.id_report, s.number, s.value 
            FROM tb_invoice_ship s 
            GROUP BY s.id_report
        ) sh ON sh.id_report = t.id
        LEFT JOIN (
            SELECT s.id_list_payout_ver, s.checkout_id, s.number
            FROM tb_list_payout_ver s
            GROUP BY s.id_list_payout_ver
        ) v ON v.checkout_id = t.checkout_id
        WHERE t.id_list_payout_trans=" + id + " "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCData.DataSource = data
        Cursor = Cursors.Default
    End Sub

    Private Sub BtnClose_Click(sender As Object, e As EventArgs) Handles BtnClose.Click
        Close()
    End Sub

    Private Sub FormPayoutHistoryDetail_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub BtnPrint_Click(sender As Object, e As EventArgs) Handles BtnPrint.Click
        Cursor = Cursors.WaitCursor
        GVData.BestFitColumns()
        Dim gv As DevExpress.XtraGrid.Views.Grid.GridView = Nothing
        gv = GVData
        ReportPayout.dt = GCData.DataSource
        ReportPayout.id = id
        Dim Report As New ReportPayout()

        '... 
        ' creating And saving the view's layout to a new memory stream 
        Dim str As System.IO.Stream
        str = New System.IO.MemoryStream()
        gv.SaveLayoutToStream(str, DevExpress.Utils.OptionsLayoutBase.FullLayout)
        str.Seek(0, System.IO.SeekOrigin.Begin)
        Report.GVData.RestoreLayoutFromStream(str, DevExpress.Utils.OptionsLayoutBase.FullLayout)
        str.Seek(0, System.IO.SeekOrigin.Begin)

        'style
        ReportStyleBanded(GVData)

        Report.LabelNumber.Text = TxtNumber.Text
        Report.LabelDate.Text = DECreated.Text.ToUpper

        ' Show the report's preview. 
        Dim Tool As DevExpress.XtraReports.UI.ReportPrintTool = New DevExpress.XtraReports.UI.ReportPrintTool(Report)
        Tool.ShowPreviewDialog()
        Cursor = Cursors.Default
    End Sub

    Private Sub GVData_CustomColumnDisplayText(sender As Object, e As DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs) Handles GVData.CustomColumnDisplayText
        If e.Column.FieldName = "no" Then
            e.DisplayText = (e.ListSourceRowIndex + 1).ToString()
        End If
    End Sub

    Private Sub BtnMark_Click(sender As Object, e As EventArgs) Handles BtnMark.Click
        Cursor = Cursors.WaitCursor
        If AllowOpenMark(rmt, id, id_report_status) Then
            FormReportMark.id_report = id
            FormReportMark.report_mark_type = rmt
            FormReportMark.form_origin = Name
            FormReportMark.ShowDialog()
        Else
            stopCustom("Data not found")
        End If
        Cursor = Cursors.Default
    End Sub

    Private Sub RepositoryItemHyperLinkEdit1_Click(sender As Object, e As EventArgs) Handles RepositoryItemHyperLinkEdit1.Click
        If GVData.RowCount > 0 And GVData.FocusedRowHandle >= 0 Then
            Cursor = Cursors.WaitCursor
            Dim id_ver As String = GVData.GetFocusedRowCellValue("id_list_payout_ver").ToString
            If id_ver <> "0" Then
                FormPayoutVerDet.id = id_ver
                FormPayoutVerDet.ShowDialog()
            End If
            Cursor = Cursors.Default
        End If
    End Sub

    Private Sub GVData_RowCellStyle(sender As Object, e As DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs) Handles GVData.RowCellStyle
        If GVData.GetRowCellValue(e.RowHandle, "id_list_payout_ver") > 0 Then
            e.Appearance.BackColor = Color.Yellow
        Else
            e.Appearance.BackColor = Color.Empty
        End If
    End Sub
End Class