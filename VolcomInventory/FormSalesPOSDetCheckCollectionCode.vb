Public Class FormSalesPOSDetCheckCollectionCode
    Private Sub FormSalesPOSDetCheckCollectionCode_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'get koleksi unik
        Dim dt_code As DataTable
        If FormSalesPOSDet.id_menu = "2" Or FormSalesPOSDet.id_menu = "5" Then 'credit note
            Dim dsg As New ClassDesign()
            dt_code = dsg.dataMasterCNUnique(FormSalesPOSDet.id_comp)
        Else 'invoice
            Dim dsg As New ClassDesign()
            dt_code = dsg.dataMasterSalUnique(FormSalesPOSDet.id_comp)
        End If


        Dim tb1 = FormSalesPOSDet.data_temp_unique.AsEnumerable()
        Dim tb2 = dt_code.AsEnumerable()

        Dim query = From table1 In tb1
                    Group Join table_tmp In tb2 On table1("code").ToString Equals table_tmp("full_code").ToString
                    Into Group
                    From y1 In Group.DefaultIfEmpty()
                    Select New With
                    {
                        .id_product = If(y1 Is Nothing, "", y1("id_product")),
                        .is_unique_report = If(y1 Is Nothing, "", y1("is_unique_report")),
                        .id_pl_prod_order_rec_det_unique = If(y1 Is Nothing, "", y1("id_pl_prod_order_rec_det_unique")),
                        .full_code = table1.Field(Of String)("code"),
                        .code = If(y1 Is Nothing, "", y1("code")),
                        .counting = If(y1 Is Nothing, "", y1("counting")),
                        .name = If(y1 Is Nothing, "", y1("name")),
                        .size = If(y1 Is Nothing, "", y1("size")),
                        .qty = table1("qty"),
                        .status = If(y1 Is Nothing, "Product not found", "OK")
                    }
        GCData.DataSource = Nothing
        GCData.DataSource = query.ToList()
        GCData.RefreshDataSource()
        GVData.BestFitColumns()

    End Sub

    Private Sub GVData_RowCellStyle(sender As Object, e As DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs) Handles GVData.RowCellStyle
        Dim stt As String = sender.GetRowCellValue(e.RowHandle, sender.Columns("status")).ToString
        If stt <> "OK" Then
            e.Appearance.BackColor = Color.Salmon
            e.Appearance.BackColor2 = Color.Salmon
        Else
            e.Appearance.BackColor = Color.White
            e.Appearance.BackColor2 = Color.White
        End If
    End Sub

    Private Sub FormSalesPOSDetCheckCollectionCode_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub BtnDiscard_Click(sender As Object, e As EventArgs) Handles BtnDiscard.Click
        Close()
    End Sub

    Private Sub BtnPrint_Click(sender As Object, e As EventArgs) Handles BtnPrint.Click
        Cursor = Cursors.WaitCursor
        print_raw(GCData, "")
        Cursor = Cursors.Default
    End Sub

    Private Sub BtnProceed_Click(sender As Object, e As EventArgs) Handles BtnProceed.Click
        makeSafeGV(GVData)
        GVData.ActiveFilterString = "[status]='OK'"

        If GVData.RowCount <= 0 Then
            stopCustom("No product can be processed")
            makeSafeGV(GVData)
        Else
            Dim confirm As DialogResult = DevExpress.XtraEditors.XtraMessageBox.Show("Please make sure :" + System.Environment.NewLine + "- Only 'OK' status will include in invoice list." + System.Environment.NewLine + "- If you want to cancell please click 'No' button, and then click 'Print' button to export to multiple formats provided." + System.Environment.NewLine + "Are you sure you want to continue this process?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
            If confirm = Windows.Forms.DialogResult.Yes Then
                Cursor = Cursors.WaitCursor
                'record unique code
                FormSalesPOSDet.viewDetailCode()
                makeSafeGV(GVData)
                GVData.ActiveFilterString = "[status]='OK' AND [is_unique_report]='1' "
                For i As Integer = 0 To GVData.RowCount - 1
                    Dim newRow As DataRow = (TryCast(FormSalesPOSDet.GCCode.DataSource, DataTable)).NewRow()
                    newRow("id_sales_pos_det_counting") = "0"
                    newRow("id_sales_pos") = "0"
                    newRow("id_product") = GVData.GetRowCellValue(i, "id_product").ToString
                    newRow("id_pl_prod_order_rec_det_unique") = GVData.GetRowCellValue(i, "id_pl_prod_order_rec_det_unique").ToString
                    newRow("counting_code") = GVData.GetRowCellValue(i, "counting").ToString
                    newRow("full_code") = GVData.GetRowCellValue(i, "full_code").ToString
                    newRow("code") = GVData.GetRowCellValue(i, "code").ToString
                    newRow("name") = GVData.GetRowCellValue(i, "name").ToString
                    newRow("size") = GVData.GetRowCellValue(i, "size").ToString
                    TryCast(FormSalesPOSDet.GCCode.DataSource, DataTable).Rows.Add(newRow)
                    FormSalesPOSDet.GCCode.RefreshDataSource()
                    FormSalesPOSDet.GVCode.RefreshData()
                Next

                'check SOH
                makeSafeGV(GVData)
                GVData.ActiveFilterString = "[status]='OK'"
                'group
                GridColumnMainCode.GroupIndex = 0
                GVData.CollapseAllGroups()
                'create datatable
                'col code
                Dim data_edit As New DataTable
                Dim col_code As New DataColumn("code")
                col_code.DataType = System.Type.GetType("System.String")
                data_edit.Columns.Add(col_code)
                'col qty
                Dim col_qty As New DataColumn("qty")
                col_qty.DataType = System.Type.GetType("System.Decimal")
                data_edit.Columns.Add(col_qty)
                'col prc-string supaya ke baca tidak isi di prosedur checkSOH
                Dim col_prc As New DataColumn("price")
                col_prc.DataType = System.Type.GetType("System.String")
                data_edit.Columns.Add(col_prc)

                For c As Integer = 1 To GetGroupRowCount(GVData)
                    Dim rh As Integer = c * -1
                    Dim qty As Decimal = Convert.ToDecimal(GVData.GetGroupSummaryValue(rh, TryCast(GVData.GroupSummary(0), DevExpress.XtraGrid.GridGroupSummaryItem)))
                    Dim code As String = GVData.GetGroupRowValue(rh).ToString
                    Dim R As DataRow = data_edit.NewRow
                    R("code") = code
                    R("qty") = qty
                    R("price") = ""
                    data_edit.Rows.Add(R)
                Next
                makeSafeGV(GVData)
                FormSalesPOSDet.checkSOH(data_edit)

                Close()
                Cursor = Cursors.Default
            Else
                makeSafeGV(GVData)
            End If
        End If
    End Sub
End Class