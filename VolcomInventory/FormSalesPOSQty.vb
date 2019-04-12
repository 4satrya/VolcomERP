Public Class FormSalesPOSQty
    Public action As String = "-1"
    Public id_product As String = "-1"

    Private Sub FormSalesPOSQty_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        TxtAdd.EditValue = 0.00
        TxtPrice.EditValue = 0.00
        If action = "ins" Then
            ActiveControl = TxtCode
        ElseIf action = "upd" Then
            TxtCode.Enabled = False
            id_product = FormSalesPOSDet.GVItemList.GetFocusedRowCellValue("id_product").ToString
            TxtCode.Text = FormSalesPOSDet.GVItemList.GetFocusedRowCellValue("code").ToString
            TxtDesign.Text = FormSalesPOSDet.GVItemList.GetFocusedRowCellValue("name").ToString
            TxtSize.Text = FormSalesPOSDet.GVItemList.GetFocusedRowCellValue("size").ToString
            TxtPrice.EditValue = FormSalesPOSDet.GVItemList.GetFocusedRowCellValue("design_price_retail")
            TxtAdd.EditValue = FormSalesPOSDet.GVItemList.GetFocusedRowCellValue("sales_pos_det_qty")
            ActiveControl = TxtAdd
        End If
    End Sub

    Sub setQty()
        Cursor = Cursors.WaitCursor
        If id_product = "-1" Then
            warningCustom("Please complete all data")
        Else
            If action = "upd" Then
                Dim data_filter_cek As DataRow() = FormSalesPOSDet.dt_stock_store.Select("[id_product]='" + id_product + "' ")
                If data_filter_cek.Length <= 0 Then
                    warningCustom("Stock not found")
                    TxtAdd.Focus()
                Else
                    If FormSalesPOSDet.is_block_no_stock = "1" Then
                        If data_filter_cek(0)("qty_all_product") = 0 Then
                            warningCustom("No stock available")
                        ElseIf TxtAdd.EditValue > data_filter_cek(0)("qty_all_product") Then
                            warningCustom("Quantity can't exceed " + data_filter_cek(0)("qty_all_product").ToString)
                        Else
                            FormSalesPOSDet.GVItemList.SetFocusedRowCellValue("sales_pos_det_qty", TxtAdd.EditValue)
                            FormSalesPOSDet.GVItemList.SetFocusedRowCellValue("note", "OK")
                            FormSalesPOSDet.GCItemList.RefreshDataSource()
                            FormSalesPOSDet.GVItemList.RefreshData()
                            FormSalesPOSDet.calculate()
                            Close()
                        End If
                    Else
                        FormSalesPOSDet.GVItemList.SetFocusedRowCellValue("sales_pos_det_qty", TxtAdd.EditValue)
                        FormSalesPOSDet.GVItemList.SetFocusedRowCellValue("note", "OK")
                        FormSalesPOSDet.GCItemList.RefreshDataSource()
                        FormSalesPOSDet.GVItemList.RefreshData()
                        FormSalesPOSDet.calculate()
                        Close()
                    End If
                End If
            End If
        End If
        Cursor = Cursors.Default
    End Sub

    Private Sub FormSalesPOSQty_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub BtnAdd_Click(sender As Object, e As EventArgs) Handles BtnAdd.Click
        setQty()
    End Sub

    Private Sub TxtAdd_KeyDown(sender As Object, e As KeyEventArgs) Handles TxtAdd.KeyDown
        If e.KeyCode = Keys.Enter Then
            If TxtAdd.EditValue <= 0 Then
                warningCustom("Please input quantity")
                TxtAdd.EditValue = 0.00
                TxtAdd.Focus()
            Else
                setQty()
            End If
        End If
    End Sub
End Class