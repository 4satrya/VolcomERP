Public Class FormSalesOrderSingleV2 
    Public id_store_par As String = "-1"
    Public id_wh_par As String = "-1"
    Public data_par As DataTable

    Private Sub FormSalesOrderSingleV2_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        viewSeason()
        SLESeason.Focus()
    End Sub

    Sub viewSeason()
        Dim query As String = ""
        query += "SELECT (0) AS `id_season`, (0) AS `range`, ('All Season') AS `season` UNION ALL "
        query += "(SELECT a.id_season, b.range, a.season FROM tb_season a "
        query += "INNER JOIN tb_range b ON a.id_range = b.id_range "
        query += "ORDER BY b.range DESC) "
        viewSearchLookupQuery(SLESeason, query, "id_season", "season", "id_season")
    End Sub

    Sub noEdit()
        If GVProdList.FocusedRowHandle >= 0 Then
            Dim id_design_cek As String = GVProdList.GetFocusedRowCellValue("id_design_price").ToString
            If id_design_cek = "0" Then
                GVProdList.Columns("total_order").OptionsColumn.AllowEdit = False
            Else
                GVProdList.Columns("total_order").OptionsColumn.AllowEdit = True
            End If
        End If
    End Sub

    Private Sub BtnView_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnView.Click
        Cursor = Cursors.WaitCursor
        viewList()
        Cursor = Cursors.Default
    End Sub

    Sub viewList()
        Dim query As String = "CALL view_sales_order_prod_list('" + SLESeason.EditValue.ToString + "', '" + id_wh_par + "', '" + id_store_par + "') "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        'MsgBox("Total : " + data_par.Rows.Count.ToString)
        If data_par.Rows.Count = 0 Then
            GCProdList.DataSource = data
        Else
            Dim t1 = data.AsEnumerable()
            Dim t2 = data_par.AsEnumerable()
            Dim except As DataTable = (From _t1 In t1
                                       Group Join _t2 In t2
                        On _t1("id_product") Equals _t2("id_product") Into Group
                                       From _t3 In Group.DefaultIfEmpty()
                                       Where _t3 Is Nothing
                                       Select _t1).CopyToDataTable
            GCProdList.DataSource = except
        End If
        GVProdList.ActiveFilterString = "[design_price]>0 "
        noEdit()
    End Sub

    Sub check_but()
        Dim ix As Integer = GVProdList.FocusedRowHandle

        If GVProdList.RowCount > 0 And ix >= 0 Then
            BtnChoose.Enabled = True
        Else
            BtnChoose.Enabled = False
        End If
    End Sub

    Private Sub GVProdList_FocusedRowChanged(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles GVProdList.FocusedRowChanged
        noEdit()
    End Sub


    Private Sub FormSalesOrderSingleV2_FormClosed(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub CheckEditSelAll_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckEditSelAll.CheckedChanged
        If GVProdList.RowCount > 0 Then
            Dim cek As String = CheckEditSelAll.EditValue.ToString
            For i As Integer = 0 To ((GVProdList.RowCount - 1) - GetGroupRowCount(GVProdList))
                If cek Then
                    GVProdList.SetRowCellValue(i, "is_select", "Yes")
                Else
                    GVProdList.SetRowCellValue(i, "is_select", "No")
                End If
            Next
        End If
    End Sub

    Private Sub GVProdList_CellValueChanged(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles GVProdList.CellValueChanged
        If e.Column.FieldName = "total_order" Then
            Cursor = Cursors.WaitCursor
            Dim row_foc As String = e.RowHandle.ToString
            Dim avail As Integer = GVProdList.GetRowCellValue(row_foc, "total_allow").ToString
            Dim val_foc As Integer = e.Value
            If val_foc > avail Then
                stopCustom("Order can't exceed : " + avail.ToString + " pcs.")
                GVProdList.SetRowCellValue(row_foc, "total_order", GVProdList.ActiveEditor.OldEditValue)
                GVProdList.FocusedColumn = GridColumnOrder
            End If
            Cursor = Cursors.Default
        End If
    End Sub

    Private Sub submitProcess()
        ' makeSafeGV(GVProdList)
        GVProdList.ExpandAllGroups()
        GVProdList.ActiveFilterString = "[total_order]>0 "
        If GVProdList.RowCount > 0 Then
            Dim confirm As DialogResult = DevExpress.XtraEditors.XtraMessageBox.Show("Are you sure you want to choose these item?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
            If confirm = Windows.Forms.DialogResult.Yes Then
                Cursor = Cursors.WaitCursor
                FormSalesOrderDet.delNotFoundMyRow()
                For i As Integer = 0 To ((GVProdList.RowCount - 1) - GetGroupRowCount(GVProdList))
                    Dim newRow As DataRow = (TryCast(FormSalesOrderDet.GCItemList.DataSource, DataTable)).NewRow()
                    newRow("id_sales_order_det") = "0"
                    newRow("name") = GVProdList.GetRowCellValue(i, "design_display_name").ToString
                    newRow("code") = GVProdList.GetRowCellValue(i, "product_full_code").ToString
                    newRow("size") = GVProdList.GetRowCellValue(i, "Size").ToString
                    newRow("sales_order_det_qty") = GVProdList.GetRowCellValue(i, "total_order")

                    If FormSalesOrderDet.LEStatusSO.EditValue.ToString = "8" And FormSalesOrderDet.id_store_type = "1" Then 'jika cat claim dan toko normal => harga normal
                        Dim dtp As DataTable = getNormalPrice(GVProdList.GetRowCellValue(i, "id_design").ToString)
                        If dtp.Rows.Count > 0 Then
                            newRow("id_design_price") = dtp(0)("id_design_price").ToString
                            newRow("design_price") = dtp(0)("design_price")
                            newRow("design_price_type") = dtp(0)("design_price_type").ToString
                            newRow("amount") = dtp(0)("design_price") * GVProdList.GetRowCellValue(i, "total_order")
                        Else
                            newRow("id_design_price") = GVProdList.GetRowCellValue(i, "id_design_price").ToString
                            newRow("design_price") = GVProdList.GetRowCellValue(i, "design_price")
                            newRow("design_price_type") = GVProdList.GetRowCellValue(i, "design_price_type").ToString
                            newRow("amount") = GVProdList.GetRowCellValue(i, "design_price") * GVProdList.GetRowCellValue(i, "total_order")
                        End If
                    Else
                        newRow("id_design_price") = GVProdList.GetRowCellValue(i, "id_design_price").ToString
                        newRow("design_price") = GVProdList.GetRowCellValue(i, "design_price")
                        newRow("design_price_type") = GVProdList.GetRowCellValue(i, "design_price_type").ToString
                        newRow("amount") = GVProdList.GetRowCellValue(i, "design_price") * GVProdList.GetRowCellValue(i, "total_order")
                    End If


                    newRow("sales_order_det_note") = GVProdList.GetRowCellValue(i, "note").ToString
                    newRow("id_design") = GVProdList.GetRowCellValue(i, "id_design").ToString
                    newRow("id_product") = GVProdList.GetRowCellValue(i, "id_product").ToString
                    newRow("id_sample") = GVProdList.GetRowCellValue(i, "id_sample").ToString
                    newRow("is_found") = "1"
                    TryCast(FormSalesOrderDet.GCItemList.DataSource, DataTable).Rows.Add(newRow)
                    FormSalesOrderDet.GCItemList.RefreshDataSource()
                    FormSalesOrderDet.GVItemList.RefreshData()
                    Close()
                Next
                Cursor = Cursors.Default
            Else
                GVProdList.ActiveFilterString = ""
                GVProdList.ActiveFilterString = "[design_price]>0 "
            End If
        Else
            stopCustom("Nothing item selected.")
            GVProdList.ActiveFilterString = ""
        End If
    End Sub

    Private Sub BtnChoose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnChoose.Click
        submitProcess()
    End Sub

    Private Sub SLESeason_KeyDown(sender As Object, e As KeyEventArgs) Handles SLESeason.KeyDown
        If e.KeyCode = Keys.Enter Then
            Cursor = Cursors.WaitCursor
            viewList()
            GCProdList.Focus()
            Cursor = Cursors.Default
        ElseIf (e.KeyCode = Keys.S AndAlso e.Modifiers = Keys.Control) Then
            submitProcess()
        End If
    End Sub

    Private Sub GVProdList_FocusedColumnChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.FocusedColumnChangedEventArgs) Handles GVProdList.FocusedColumnChanged
        Try
            If e.FocusedColumn.ToString = GVProdList.Columns("product_full_code").ToString Then
                GVProdList.FocusedColumn = GridColumnOrder
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub FormSalesOrderSingleV2_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If (e.KeyCode = Keys.S AndAlso e.Modifiers = Keys.Control) Then
            submitProcess()
        End If
    End Sub

    Private Sub GVProdList_KeyDown(sender As Object, e As KeyEventArgs) Handles GVProdList.KeyDown
        If (e.KeyCode = Keys.S AndAlso e.Modifiers = Keys.Control) Then
            submitProcess()
        End If
    End Sub

    Private Sub BtnChoose_KeyDown(sender As Object, e As KeyEventArgs) Handles BtnChoose.KeyDown
        If (e.KeyCode = Keys.S AndAlso e.Modifiers = Keys.Control) Then
            submitProcess()
        End If
    End Sub

    Private Sub GCProdList_KeyDown(sender As Object, e As KeyEventArgs) Handles GCProdList.KeyDown

    End Sub

    Private Sub GVProdList_CustomSummaryCalculate(sender As Object, e As DevExpress.Data.CustomSummaryEventArgs) Handles GVProdList.CustomSummaryCalculate

    End Sub

    Private Sub GVProdList_HiddenEditor(sender As Object, e As EventArgs) Handles GVProdList.HiddenEditor
        GVProdList.RefreshData()
        LabelTotal.Text = GVProdList.Columns("total_order").SummaryItem.SummaryValue.ToString
    End Sub
End Class