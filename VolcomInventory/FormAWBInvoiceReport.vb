Public Class FormAWBInvoiceReport
    Private Sub BView_Click(sender As Object, e As EventArgs) Handles BView.Click
        laod_awb()
    End Sub

    Sub load_invoice()
        Dim query As String = "SELECT awb.`awbill_inv_no`,c.comp_name,awb.id_cargo FROM tb_wh_awbill awb
INNER JOIN tb_m_comp c ON c.id_comp=awb.`id_cargo`
WHERE NOT ISNULL(awb.`awbill_inv_no`) AND awb.`awbill_inv_no`!=''
GROUP BY awbill_inv_no,awb.id_cargo"
        viewSearchLookupQuery(SLEInvNo, query, "awbill_inv_no", "awbill_inv_no", "awbill_inv_no")
    End Sub

    Sub laod_awb()
        Dim query As String = "SELECT awb.`id_cargo`,awb.`awbill_no`,awb.`cargo_rate`,SUM(awb.`c_weight`) AS c_weight,SUM(awb.`c_tot_price`) AS c_tot_price,awb.`a_weight`,awb.`a_tot_price`,c.comp_name FROM `tb_wh_awbill` awb
INNER JOIN tb_m_comp c ON c.id_comp=awb.`id_cargo`
WHERE awb.`awbill_inv_no`='" & SLEInvNo.EditValue.ToString & "' AND awb.id_cargo='" & SLEInvNo.Properties.View.GetFocusedRowCellValue("id_cargo").ToString & "'
GROUP BY awbill_no"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCAwb.DataSource = data
        GVAwb.BestFitColumns()
    End Sub

    Private Sub FormAWBInvoiceReport_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        load_invoice()
    End Sub

    Private Sub SMMainVendor_Click(sender As Object, e As EventArgs) Handles SMMainVendor.Click
        If GVAwb.RowCount > 0 Then
            FormAWBInvoiceDetail.awbill_no = GVAwb.GetFocusedRowCellValue("awbill_no").ToString
            FormAWBInvoiceDetail.ShowDialog()
        End If
    End Sub

    Private Sub BPrint_Click(sender As Object, e As EventArgs) Handles BPrint.Click
        Dim Report As New ReportDynamic
        ReportDynamic.dt = GCAwb.DataSource
        'header
        Report.LTitle.Text = "Invoice Compare Report"
        Report.XCHead1.Text = "Invoice Number "
        Report.XCHead1Val.Text = SLEInvNo.EditValue.ToString
        'datatable
        ' ' creating and saving the view's layout to a new memory stream 
        Dim str As System.IO.Stream
        str = New System.IO.MemoryStream()
        GVAwb.SaveLayoutToStream(str, DevExpress.Utils.OptionsLayoutBase.FullLayout)
        str.Seek(0, System.IO.SeekOrigin.Begin)
        Report.GVDetail.RestoreLayoutFromStream(str, DevExpress.Utils.OptionsLayoutBase.FullLayout)
        str.Seek(0, System.IO.SeekOrigin.Begin)

        'Grid Detail
        ReportStyleGridview(Report.GVDetail)

        Dim Tool As DevExpress.XtraReports.UI.ReportPrintTool = New DevExpress.XtraReports.UI.ReportPrintTool(Report)
        Tool.ShowPreview()
    End Sub
End Class