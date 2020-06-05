Public Class FormPayoutHistoryDetail
    Public id As String = "-1"

    Private Sub FormPayoutHistoryDetail_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Cursor = Cursors.WaitCursor
        Dim query As String = "SELECT * FROM tb_list_payout_trans t WHERE t.id_list_payout_trans=" + id + " "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        TxtNumber.Text = data.Rows(0)("number").ToString
        DECreated.EditValue = data.Rows(0)("generate_date")
        viewData()
        Cursor = Cursors.Default
    End Sub

    Sub viewData()
        Cursor = Cursors.WaitCursor
        Dim query As String = "SELECT t.settlement_date, t.pay_type, t.bank, t.id AS `id_order`, t.sales_order_ol_shop_number, sp.customer_name, t.checkout_id, 
        t.payment, t.trans_fee, sp.sales_pos_number AS `invoice_number`, t.invoice_amount, t.calculate_fee 
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
End Class