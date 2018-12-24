Imports DevExpress.XtraEditors

Public Class FormTestBarcodeScan
    Private Sub FormTestBarcodeScan_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        GCList.DataSource = getProduct("-1")

        'Created Date
        Dim dateNow As DateTime = DateTime.Now

        TECreatedDate.EditValue = dateNow.ToString("dd/MM/yyyy HH:mm:ss")
    End Sub

    Private Sub TECodeInput_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TECodeInput.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            checkProduct()
        End If
    End Sub

    Private Function getProduct(ByVal product_full_code As String) As DataTable
        Dim query As String = "
            SELECT `p`.`id_product`, `p`.`product_name`, `p`.`product_full_code`, `cd`.`code_detail_name`, (1) `quantity`
            FROM `tb_m_product` `p`
            INNER JOIN `tb_m_product_code` `pc` ON `p`.`id_product` = `pc`.`id_product`
            INNER JOIN `tb_m_code_detail` `cd` ON `pc`.`id_code_detail` = `cd`.`id_code_detail`
            WHERE `p`.`product_full_code` = '" + product_full_code + "'
        "

        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")

        Return data
    End Function

    Sub checkProduct()
        Dim data As DataTable = getProduct(TECodeInput.EditValue.ToString)

        If data.Rows.Count > 0 Then
            Dim already As Boolean = False
            Dim i As Integer = 0

            For i = 0 To GVList.RowCount - 1
                If GVList.GetRowCellValue(i, "id_product") = data.Rows(0)("id_product").ToString Then
                    already = True

                    Exit For
                End If
            Next

            If already Then
                Dim quantity As Integer = GVList.GetRowCellValue(i, "quantity") + 1

                GVList.SetRowCellValue(i, "quantity", quantity)

                GVList.RefreshData()
            Else
                Dim newRow As DataRow = (TryCast(GCList.DataSource, DataTable)).NewRow()

                newRow("id_product") = data.Rows(0)("id_product").ToString
                newRow("product_name") = data.Rows(0)("product_name").ToString
                newRow("product_full_code") = data.Rows(0)("product_full_code").ToString
                newRow("code_detail_name") = data.Rows(0)("code_detail_name").ToString
                newRow("quantity") = data.Rows(0)("quantity").ToString

                TryCast(GCList.DataSource, DataTable).Rows.Add(newRow)

                GCList.RefreshDataSource()

                GVList.RefreshData()

                GVList.BestFitColumns()
            End If

            SBSave.Enabled = True
        Else
            XtraMessageBox.Show("Product not found!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If

        TECodeInput.EditValue = ""
    End Sub

    Private Sub SBPrint_Click(sender As Object, e As EventArgs) Handles SBPrint.Click
        CobaReport.dt = GCList.DataSource

        Dim Report As New CobaReport()

        'creating And saving the view's layout to a new memory stream 
        'Dim str As System.IO.Stream
        'str = New System.IO.MemoryStream()
        'GVList.SaveLayoutToStream(str, DevExpress.Utils.OptionsLayoutBase.FullLayout)
        'str.Seek(0, System.IO.SeekOrigin.Begin)
        'Report.GVList.RestoreLayoutFromStream(str, DevExpress.Utils.OptionsLayoutBase.FullLayout)
        'str.Seek(0, System.IO.SeekOrigin.Begin)

        'Grid Detail
        'ReportStyleGridview(Report.GVList)

        'Parse Val
        Report.XLNo.Text = "123"
        'Report.LabelNumber.Text = TxtNumber.Text.ToUpper
        'Report.LabelRequestNo.Text = TxtRequestNo.Text.ToUpper
        'Report.LabelDept.Text = TxtDept.Text.ToUpper
        'Report.LabelDate.Text = DECreated.Text.ToString
        'Report.LNote.Text = MENote.Text.ToString


        'Show the report's preview. 
        Dim Tool As DevExpress.XtraReports.UI.ReportPrintTool = New DevExpress.XtraReports.UI.ReportPrintTool(Report)
        Tool.ShowPreviewDialog()
    End Sub

    Private Sub SBCancel_Click(sender As Object, e As EventArgs) Handles SBCancel.Click
        Me.Close()
        Me.Dispose()
    End Sub

    Private Sub SBSave_Click(sender As Object, e As EventArgs) Handles SBSave.Click
        Cursor = Cursors.WaitCursor

        Dim query As String = ""

        Dim createdDate As DateTime = DateTime.ParseExact(TECreatedDate.EditValue.ToString, "dd/MM/yyyy HH:mm:ss", System.Globalization.DateTimeFormatInfo.InvariantInfo)

        query = "
            INSERT INTO `tb_sales_return_rec` (`number`, `created_date`, `do_number`, `note`, `id_report_status`) VALUES ('" + TENumber.EditValue.ToString + "', '" + createdDate.ToString("yyyy-MM-dd HH:mm:ss") + "', '" + TEDONumber.EditValue.ToString + "', '" + MENote.Text.ToString + "', '6'); SELECT LAST_INSERT_ID();
        "

        Console.WriteLine(query)

        Dim id_sales_return_rec As String = "1"

        For i = 0 To GVList.RowCount - 1
            query = "
                INSERT INTO `tb_sales_return_rec_det` (`id_sales_return_rec`, `id_product`, `qty`) VALUES ('" + id_sales_return_rec + "', '" + GVList.GetRowCellValue(i, "id_product").ToString + "', '" + GVList.GetRowCellValue(i, "quantity").ToString + "');
            "

            Console.WriteLine(query)
        Next

        Cursor = Cursors.Default
    End Sub
End Class