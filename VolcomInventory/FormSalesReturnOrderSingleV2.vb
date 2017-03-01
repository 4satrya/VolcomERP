Public Class FormSalesReturnOrderSingleV2
    Public id_comp As String = "-1"
    Public id_wh_locator As String = "-1"
    Public id_wh_rack As String = "-1"
    Public id_wh_drawer As String = "-1"
    Public date_param As String = "-1"
    Public id_product As String = "-1"

    Private Sub FormSalesReturnOrderSingleV2_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        viewSeason()
    End Sub

    Sub viewSeason()
        Dim query As String = ""
        query += "SELECT (0) AS `id_season`, (0) AS `range`, ('All Season') AS `season` UNION ALL "
        query += "(SELECT a.id_season, b.range, a.season FROM tb_season a "
        query += "INNER JOIN tb_range b ON a.id_range = b.id_range "
        query += "ORDER BY b.range DESC) "
        viewSearchLookupQuery(SLESeason, query, "id_season", "season", "id_season")
    End Sub

    'VIEW
    Sub viewProduct()
        Dim query As String = "CALL view_stock_fg('" + id_comp + "', '" + id_wh_locator + "', '" + id_wh_rack + "', '" + id_wh_drawer + "', '0', '4', '" + date_param + "') "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCProduct.DataSource = data
        If GVProduct.RowCount > 0 Then
            BtnChoose.Enabled = True
            GVProduct.OptionsBehavior.AutoExpandAllGroups = True
        Else
            BtnChoose.Enabled = False
        End If
        Dim id_season As String = SLESeason.EditValue.ToString
        If id_season = "0" Then
            GVProduct.ActiveFilterString = ""
        Else
            GVProduct.ActiveFilterString = "[id_season]='" + id_season + "'"
        End If
    End Sub

    Private Sub FormSalesReturnOrderSingleV2_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub CheckEditSelAll_CheckedChanged(sender As Object, e As EventArgs) Handles CheckEditSelAll.CheckedChanged
        Dim cek As String = CheckEditSelAll.EditValue.ToString
        For i As Integer = 0 To ((GVProduct.RowCount - 1) - GetGroupRowCount(GVProduct))
            If cek Then
                GVProduct.SetRowCellValue(i, "is_select", "Yes")
            Else
                GVProduct.SetRowCellValue(i, "is_select", "No")
            End If
        Next
    End Sub

    Private Sub BtnChoose_Click(sender As Object, e As EventArgs) Handles BtnChoose.Click
        Cursor = Cursors.WaitCursor
        GVProduct.ActiveFilterString = "[is_select]='Yes'"

        If GVProduct.RowCount > 0 Then
            'check duplicate
            Dim dt_check As DataTable = FormSalesReturnOrderDet.GCItemList.DataSource
            Dim cond As Boolean = True
            For i As Integer = 0 To ((GVProduct.RowCount - 1) - GetGroupRowCount(GVProduct))
                Dim dt_filter As DataRow() = dt_check.Select("[id_product]='" + GVProduct.GetRowCellValue(i, "id_product").ToString + "' ")
                If dt_filter.Length > 0 Then
                    stopCustom(GVProduct.GetRowCellValue(i, "name").ToString + "/Size " + GVProduct.GetRowCellValue(i, "size").ToString + " already exist in order list")
                    GVProduct.FocusedRowHandle = i
                    GVProduct.ActiveFilterString = ""
                    cond = False
                    Exit For
                End If
            Next

            If cond Then
                Dim confirm As DialogResult = DevExpress.XtraEditors.XtraMessageBox.Show("Are you sure want to continue this process ?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
                If confirm = Windows.Forms.DialogResult.Yes Then
                    Cursor = Cursors.WaitCursor
                    For i As Integer = 0 To ((GVProduct.RowCount - 1) - GetGroupRowCount(GVProduct))
                        Dim newRow As DataRow = (TryCast(FormSalesReturnOrderDet.GCItemList.DataSource, DataTable)).NewRow()
                        newRow("id_sales_return_order_det") = "0"
                        newRow("name") = GVProduct.GetRowCellValue(i, "name").ToString
                        newRow("code") = GVProduct.GetRowCellValue(i, "code").ToString
                        newRow("size") = GVProduct.GetRowCellValue(i, "size").ToString
                        newRow("sales_return_order_det_qty") = GVProduct.GetRowCellValue(i, "qty_ord")
                        newRow("design_price_type") = ""
                        newRow("id_design_price") = GVProduct.GetRowCellValue(i, "id_design_price_retail").ToString
                        newRow("design_price") = GVProduct.GetRowCellValue(i, "design_price_retail")
                        newRow("id_return_cat") = "1"
                        newRow("return_cat") = "Return"
                        newRow("amount") = GVProduct.GetRowCellValue(i, "qty_ord") * GVProduct.GetRowCellValue(i, "design_price_retail")
                        newRow("sales_return_order_det_note") = ""
                        newRow("id_design") = GVProduct.GetRowCellValue(i, "id_design").ToString
                        newRow("id_product") = GVProduct.GetRowCellValue(i, "id_product").ToString
                        newRow("id_sample") = "0"
                        TryCast(FormSalesReturnOrderDet.GCItemList.DataSource, DataTable).Rows.Add(newRow)
                        FormSalesReturnOrderDet.GCItemList.RefreshDataSource()
                        FormSalesReturnOrderDet.GVItemList.RefreshData()
                    Next
                    FormSalesReturnOrderDet.check_but()
                    Close()
                    Cursor = Cursors.Default
                End If
            End If
            Cursor = Cursors.Default
        Else
            stopCustom("Nothing item selected")
            GVProduct.ActiveFilterString = ""
        End If
    End Sub

    Private Sub BtnView_Click(sender As Object, e As EventArgs) Handles BtnView.Click
        Cursor = Cursors.WaitCursor
        viewProduct()
        Cursor = Cursors.Default
    End Sub
End Class