Public Class FormSalesCreditNoteSingle 
    Public id_sales_pos_ref As String = "-1"
    Public id_pop_up = "-1"
    Public action_pop As String = "-1"
    Dim dt As New DataTable

    Private Sub FormSalesCreditNoteSingle_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        viewSalesInv()

        If id_pop_up = "3" Then
            GridColumn4.Visible = False
            GridColumnIsSelect.Visible = False
            CheckEditSelectAll.Visible = False
            If FormSalesPOSDet.TxtOLStoreNumber.Text <> "" Then
                GVItemList.ActiveFilterString = "[ol_store_order]='" + FormSalesPOSDet.TxtOLStoreNumber.Text + "'"
            End If
            GVItemList.FocusedColumn = GridColumn1
        End If

        'inisialisasi jika blm ada
        Try
            dt.Columns.Add("code")
            dt.Columns.Add("name")
            dt.Columns.Add("size")
            dt.Columns.Add("color")
            dt.Columns.Add("sales_pos_det_qty")
            dt.Columns.Add("sales_pos_det_amount")
            dt.Columns.Add("design_price_retail")
            dt.Columns.Add("design_price_type")
            dt.Columns.Add("design_price")
            dt.Columns.Add("id_design")
            dt.Columns.Add("id_product")
            dt.Columns.Add("id_sample")
            dt.Columns.Add("id_design_price")
            dt.Columns.Add("id_sales_pos_det_ref")
            dt.Columns.Add("id_sales_pos_det")
            dt.Columns.Add("id_design_price_retail")
        Catch ex As Exception
        End Try
    End Sub

    Private Sub FormSalesCreditNoteSingle_FormClosed(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub BtnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCancel.Click
        Close()
    End Sub

    Private Sub CheckEditSelectAll_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckEditSelectAll.CheckedChanged
        Dim cek As String = CheckEditSelectAll.EditValue.ToString
        For i As Integer = 0 To ((GVItemList.RowCount - 1) - GetGroupRowCount(GVItemList))
            Try
                If cek Then
                    GVItemList.SetRowCellValue(i, "is_select", "Yes")
                Else
                    GVItemList.SetRowCellValue(i, "is_select", "No")
                End If
                GVItemList.SetRowCellValue(i, "is_changed", "Yes")
            Catch ex As Exception
            End Try
        Next
    End Sub

    Sub viewSalesInv()
        Dim query_c As ClassSalesInv = New ClassSalesInv()
        Dim query As String = query_c.queryDetail(id_sales_pos_ref)

        If action_pop = "ins" Then
            Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
            GCItemList.DataSource = data
        End If
        If GVItemList.RowCount > 0 Then
            GVItemList.BestFitColumns()
            BtnChoose.Enabled = True
        Else
            BtnChoose.Enabled = False
        End If
    End Sub

    Private Sub BtnChoose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnChoose.Click
        Cursor = Cursors.WaitCursor
        dt.Clear()
        makeSafeGV(GVItemList)
        Dim jum_select As Integer = 0
        Dim cond_check As Boolean = True
        Dim cond_general As Boolean = True
        Dim alert_check As String = ""

        If id_pop_up = "1" Then
            For i As Integer = 0 To ((GVItemList.RowCount - 1) - GetGroupRowCount(GVItemList))
                Dim is_select As String = GVItemList.GetRowCellValue(i, "is_select").ToString
                If is_select = "Yes" Then
                    Dim jum_cn As Decimal = 0.0
                    Try
                        jum_cn = Decimal.Parse(GVItemList.GetRowCellValue(i, "sales_pos_det_qty_credit_note").ToString)
                    Catch ex As Exception
                    End Try

                    If jum_cn = 0.0 Then
                        cond_general = False
                    Else
                        jum_select = jum_select + 1

                        'cek exist item
                        For j As Integer = 0 To ((FormSalesCreditNoteDet.GVItemList.RowCount - 1) - GetGroupRowCount(FormSalesCreditNoteDet.GVItemList))
                            Dim id_product_cek As String = "-1"
                            Dim id_design_price_cek As String = "-1"
                            Dim design_price_cek As Decimal = 0.0
                            Try
                                id_product_cek = FormSalesCreditNoteDet.GVItemList.GetRowCellValue(j, "id_product").ToString
                            Catch ex As Exception
                            End Try

                            Try
                                id_design_price_cek = FormSalesCreditNoteDet.GVItemList.GetRowCellValue(j, "id_design_price").ToString
                            Catch ex As Exception
                            End Try

                            Try
                                design_price_cek = Decimal.Parse(FormSalesCreditNoteDet.GVItemList.GetRowCellValue(j, "design_price").ToString)
                            Catch ex As Exception
                            End Try

                            If action_pop = "ins" Then
                                If id_product_cek = GVItemList.GetRowCellValue(i, "id_product").ToString And id_design_price_cek = GVItemList.GetRowCellValue(i, "id_design_price").ToString And design_price_cek = Decimal.Parse(GVItemList.GetRowCellValue(i, "design_price").ToString) Then
                                    alert_check = GVItemList.GetRowCellValue(i, "name").ToString + " / Size : " + GVItemList.GetRowCellValue(i, "size").ToString + ", already choosen !"
                                    cond_check = False
                                    Exit For
                                End If
                            ElseIf action_pop = "upd" Then
                                'update action
                            End If
                        Next


                        If Not cond_check Then
                            Exit For
                        Else
                            Dim R As DataRow = dt.NewRow
                            R("code") = GVItemList.GetRowCellValue(i, "code").ToString
                            R("name") = GVItemList.GetRowCellValue(i, "name").ToString
                            R("size") = GVItemList.GetRowCellValue(i, "size").ToString
                            R("color") = GVItemList.GetRowCellValue(i, "color").ToString
                            R("sales_pos_det_qty") = Decimal.Parse(GVItemList.GetRowCellValue(i, "sales_pos_det_qty_credit_note").ToString)
                            R("sales_pos_det_amount") = Decimal.Parse(GVItemList.GetRowCellValue(i, "sales_pos_det_qty_credit_note").ToString) * Decimal.Parse(GVItemList.GetRowCellValue(i, "design_price_retail").ToString)
                            R("design_price_retail") = Decimal.Parse(GVItemList.GetRowCellValue(i, "design_price_retail").ToString)
                            R("design_price_type") = GVItemList.GetRowCellValue(i, "design_price_type").ToString
                            R("design_price") = Decimal.Parse(GVItemList.GetRowCellValue(i, "design_price").ToString)
                            R("id_design") = GVItemList.GetRowCellValue(i, "id_design").ToString
                            R("id_product") = GVItemList.GetRowCellValue(i, "id_product").ToString
                            R("id_sample") = GVItemList.GetRowCellValue(i, "id_sample").ToString
                            R("id_design_price") = GVItemList.GetRowCellValue(i, "id_design_price").ToString
                            R("id_design_price_retail") = GVItemList.GetRowCellValue(i, "id_design_price_retail").ToString
                            R("id_sales_pos_det_ref") = GVItemList.GetRowCellValue(i, "id_sales_pos_det").ToString
                            R("id_sales_pos_det") = "0"
                            dt.Rows.Add(R)
                        End If
                    End If
                End If
            Next

            If cond_general Then
                If jum_select > 0 Then
                    If cond_check Then
                        For ls As Integer = 0 To (dt.Rows.Count - 1)
                            Dim newRow As DataRow = (TryCast(FormSalesCreditNoteDet.GCItemList.DataSource, DataTable)).NewRow()
                            newRow("code") = dt.Rows(ls)("code").ToString
                            newRow("name") = dt.Rows(ls)("name").ToString
                            newRow("size") = dt.Rows(ls)("size").ToString
                            newRow("color") = dt.Rows(ls)("color").ToString
                            newRow("sales_pos_det_qty") = Decimal.Parse(dt.Rows(ls)("sales_pos_det_qty").ToString)
                            newRow("sales_pos_det_amount") = Decimal.Parse(dt.Rows(ls)("sales_pos_det_amount").ToString)
                            newRow("design_price_retail") = Decimal.Parse(dt.Rows(ls)("design_price_retail").ToString)
                            newRow("design_price_type") = dt.Rows(ls)("design_price_type").ToString
                            newRow("design_price") = Decimal.Parse(dt.Rows(ls)("design_price").ToString)
                            newRow("id_design") = dt.Rows(ls)("id_design").ToString
                            newRow("id_product") = dt.Rows(ls)("id_product").ToString
                            newRow("id_sample") = dt.Rows(ls)("id_sample").ToString
                            newRow("id_design_price") = dt.Rows(ls)("id_design_price").ToString
                            newRow("id_design_price_retail") = dt.Rows(ls)("id_design_price_retail").ToString
                            newRow("id_sales_pos_det_ref") = dt.Rows(ls)("id_sales_pos_det_ref").ToString
                            newRow("id_sales_pos_det") = "0"

                            TryCast(FormSalesCreditNoteDet.GCItemList.DataSource, DataTable).Rows.Add(newRow)
                            FormSalesCreditNoteDet.GCItemList.RefreshDataSource()
                            FormSalesCreditNoteDet.GVItemList.RefreshData()
                            FormSalesCreditNoteDet.getDiscount()
                            FormSalesCreditNoteDet.getNetto()
                            FormSalesCreditNoteDet.getVat()
                            FormSalesCreditNoteDet.getTaxBase()
                        Next
                        FormSalesCreditNoteDet.check_but()
                        Close()
                    Else
                        stopCustom(alert_check)
                    End If
                Else
                    stopCustom("No item selected !")
                End If
            Else
                stopCustom("Input not valid. Make sure Qty Credit Note is not zero.")
            End If
        ElseIf id_pop_up = "2" Then
            For i As Integer = 0 To ((GVItemList.RowCount - 1) - GetGroupRowCount(GVItemList))
                Dim is_select As String = GVItemList.GetRowCellValue(i, "is_select").ToString
                If is_select = "Yes" Then
                    Dim jum_cn As Decimal = 0.0
                    Try
                        jum_cn = Decimal.Parse(GVItemList.GetRowCellValue(i, "sales_pos_det_qty_credit_note").ToString)
                    Catch ex As Exception
                    End Try

                    If jum_cn = 0.0 Then
                        cond_general = False
                    Else
                        jum_select = jum_select + 1

                        'cek exist item
                        For j As Integer = 0 To ((FormFGMissingCreditNoteStoreDet.GVItemList.RowCount - 1) - GetGroupRowCount(FormFGMissingCreditNoteStoreDet.GVItemList))
                            Dim id_product_cek As String = "-1"
                            Dim id_design_price_cek As String = "-1"
                            Dim design_price_cek As Decimal = 0.0
                            Try
                                id_product_cek = FormFGMissingCreditNoteStoreDet.GVItemList.GetRowCellValue(j, "id_product").ToString
                            Catch ex As Exception
                            End Try

                            Try
                                id_design_price_cek = FormFGMissingCreditNoteStoreDet.GVItemList.GetRowCellValue(j, "id_design_price").ToString
                            Catch ex As Exception
                            End Try

                            Try
                                design_price_cek = Decimal.Parse(FormFGMissingCreditNoteStoreDet.GVItemList.GetRowCellValue(j, "design_price").ToString)
                            Catch ex As Exception
                            End Try

                            If action_pop = "ins" Then
                                If id_product_cek = GVItemList.GetRowCellValue(i, "id_product").ToString And id_design_price_cek = GVItemList.GetRowCellValue(i, "id_design_price").ToString And design_price_cek = Decimal.Parse(GVItemList.GetRowCellValue(i, "design_price").ToString) Then
                                    alert_check = GVItemList.GetRowCellValue(i, "name").ToString + " / Size : " + GVItemList.GetRowCellValue(i, "size").ToString + ", already choosen !"
                                    cond_check = False
                                    Exit For
                                End If
                            ElseIf action_pop = "upd" Then
                                'update action
                            End If
                        Next


                        If Not cond_check Then
                            Exit For
                        Else
                            Dim R As DataRow = dt.NewRow
                            R("code") = GVItemList.GetRowCellValue(i, "code").ToString
                            R("name") = GVItemList.GetRowCellValue(i, "name").ToString
                            R("size") = GVItemList.GetRowCellValue(i, "size").ToString
                            R("color") = GVItemList.GetRowCellValue(i, "color").ToString
                            R("sales_pos_det_qty") = Decimal.Parse(GVItemList.GetRowCellValue(i, "sales_pos_det_qty_credit_note").ToString)
                            R("sales_pos_det_amount") = Decimal.Parse(GVItemList.GetRowCellValue(i, "sales_pos_det_qty_credit_note").ToString) * Decimal.Parse(GVItemList.GetRowCellValue(i, "design_price_retail").ToString)
                            R("design_price_retail") = Decimal.Parse(GVItemList.GetRowCellValue(i, "design_price_retail").ToString)
                            R("design_price_type") = GVItemList.GetRowCellValue(i, "design_price_type").ToString
                            R("design_price") = Decimal.Parse(GVItemList.GetRowCellValue(i, "design_price").ToString)
                            R("id_design") = GVItemList.GetRowCellValue(i, "id_design").ToString
                            R("id_product") = GVItemList.GetRowCellValue(i, "id_product").ToString
                            R("id_sample") = GVItemList.GetRowCellValue(i, "id_sample").ToString
                            R("id_design_price") = GVItemList.GetRowCellValue(i, "id_design_price").ToString
                            R("id_design_price_retail") = GVItemList.GetRowCellValue(i, "id_design_price_retail").ToString
                            R("id_sales_pos_det_ref") = GVItemList.GetRowCellValue(i, "id_sales_pos_det").ToString
                            R("id_sales_pos_det") = "0"
                            dt.Rows.Add(R)
                        End If
                    End If
                End If
            Next

            If cond_general Then
                If jum_select > 0 Then
                    If cond_check Then
                        For ls As Integer = 0 To (dt.Rows.Count - 1)
                            Dim newRow As DataRow = (TryCast(FormFGMissingCreditNoteStoreDet.GCItemList.DataSource, DataTable)).NewRow()
                            newRow("code") = dt.Rows(ls)("code").ToString
                            newRow("name") = dt.Rows(ls)("name").ToString
                            newRow("size") = dt.Rows(ls)("size").ToString
                            newRow("color") = dt.Rows(ls)("color").ToString
                            newRow("sales_pos_det_qty") = Decimal.Parse(dt.Rows(ls)("sales_pos_det_qty").ToString)
                            newRow("sales_pos_det_amount") = Decimal.Parse(dt.Rows(ls)("sales_pos_det_amount").ToString)
                            newRow("design_price_retail") = Decimal.Parse(dt.Rows(ls)("design_price_retail").ToString)
                            newRow("design_price_type") = dt.Rows(ls)("design_price_type").ToString
                            newRow("design_price") = Decimal.Parse(dt.Rows(ls)("design_price").ToString)
                            newRow("id_design") = dt.Rows(ls)("id_design").ToString
                            newRow("id_product") = dt.Rows(ls)("id_product").ToString
                            newRow("id_sample") = dt.Rows(ls)("id_sample").ToString
                            newRow("id_design_price") = dt.Rows(ls)("id_design_price").ToString
                            newRow("id_design_price_retail") = dt.Rows(ls)("id_design_price_retail").ToString
                            newRow("id_sales_pos_det_ref") = dt.Rows(ls)("id_sales_pos_det_ref").ToString
                            newRow("id_sales_pos_det") = "0"

                            TryCast(FormFGMissingCreditNoteStoreDet.GCItemList.DataSource, DataTable).Rows.Add(newRow)
                            FormFGMissingCreditNoteStoreDet.GCItemList.RefreshDataSource()
                            FormFGMissingCreditNoteStoreDet.GVItemList.RefreshData()
                            FormFGMissingCreditNoteStoreDet.getDiscount()
                            FormFGMissingCreditNoteStoreDet.getNetto()
                            FormFGMissingCreditNoteStoreDet.getVat()
                            FormFGMissingCreditNoteStoreDet.getTaxBase()
                        Next
                        FormFGMissingCreditNoteStoreDet.check_but()
                        Close()
                    Else
                        stopCustom(alert_check)
                    End If
                Else
                    stopCustom("No item selected !")
                End If
            Else
                stopCustom("Input not valid. Make sure Qty Credit Note is not zero.")
            End If
        ElseIf id_pop_up = "3" Then
            GVItemList.ActiveFilterString = "[sales_pos_det_qty_credit_note]>0 "
            If GVItemList.RowCount > 0 Then
                'check exist item
                Dim cond_exists As Boolean = False
                Dim err_exist As String = ""
                For i As Integer = 0 To ((GVItemList.RowCount - 1) - GetGroupRowCount(GVItemList))
                    Dim id_product_cek As String = GVItemList.GetRowCellValue(i, "id_product").ToString
                    Dim code_cek As String = GVItemList.GetRowCellValue(i, "code").ToString
                    Dim name_cek As String = GVItemList.GetRowCellValue(i, "name").ToString
                    Dim size_cek As String = GVItemList.GetRowCellValue(i, "size").ToString
                    FormSalesPOSDet.GVItemList.ActiveFilterString = "[id_product]='" + id_product_cek + "'"
                    If FormSalesPOSDet.GVItemList.RowCount > 0 Then
                        cond_exists = True
                        err_exist = code_cek + "/" + name_cek + "/ Size " + size_cek + " already exist. "
                        Exit For
                    End If
                Next
                FormSalesPOSDet.GVItemList.ActiveFilterString = ""

                If cond_exists Then
                    stopCustom(err_exist)
                    GVItemList.ActiveFilterString = ""
                Else
                    For ls As Integer = 0 To ((GVItemList.RowCount - 1) - GetGroupRowCount(GVItemList))
                        Dim newRow As DataRow = (TryCast(FormSalesPOSDet.GCItemList.DataSource, DataTable)).NewRow()
                        newRow("code") = GVItemList.GetRowCellValue(ls, "code").ToString
                        newRow("name") = GVItemList.GetRowCellValue(ls, "name").ToString
                        newRow("size") = GVItemList.GetRowCellValue(ls, "size").ToString
                        'newRow("color") = GVItemList.GetRowCellValue(ls, "color").ToString
                        newRow("sales_pos_det_qty") = GVItemList.GetRowCellValue(ls, "sales_pos_det_qty_credit_note")
                        newRow("sales_pos_det_amount") = GVItemList.GetRowCellValue(ls, "sales_pos_det_qty_credit_note") * GVItemList.GetRowCellValue(ls, "design_price_retail")
                        newRow("design_price_retail") = GVItemList.GetRowCellValue(ls, "design_price_retail")
                        newRow("design_price_type") = GVItemList.GetRowCellValue(ls, "design_price_type")
                        newRow("design_price") = GVItemList.GetRowCellValue(ls, "design_price")
                        newRow("id_design") = GVItemList.GetRowCellValue(ls, "id_design").ToString
                        newRow("id_product") = GVItemList.GetRowCellValue(ls, "id_product").ToString
                        newRow("id_design_price") = GVItemList.GetRowCellValue(ls, "id_design_price").ToString
                        newRow("id_design_price_retail") = GVItemList.GetRowCellValue(ls, "id_design_price_retail").ToString
                        newRow("id_sales_pos_det_ref") = GVItemList.GetRowCellValue(ls, "id_sales_pos_det").ToString
                        newRow("id_sales_pos_det") = "0"

                        TryCast(FormSalesPOSDet.GCItemList.DataSource, DataTable).Rows.Add(newRow)
                        FormSalesPOSDet.GCItemList.RefreshDataSource()
                        FormSalesPOSDet.GVItemList.RefreshData()
                        FormSalesPOSDet.calculate()
                    Next
                    Close()
                End If
            Else
                stopCustom("Input can't blank")
                GVItemList.ActiveFilterString = ""
            End If
        End If
        Cursor = Cursors.Default
    End Sub

    Private Sub SPQtyCreditNote_EditValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SPQtyCreditNote.EditValueChanged
        'aktifkan jika dipakai (ada pembatasan berdasarkan limit)
        Dim SpQty As DevExpress.XtraEditors.SpinEdit = CType(sender, DevExpress.XtraEditors.SpinEdit)
        Dim qty_rec As Decimal = SpQty.EditValue
        Dim qty_limit As Decimal = GVItemList.GetFocusedRowCellValue("sales_pos_det_qty_limit")
        If qty_rec > qty_limit Then
            stopCustom("Qty Credit Note cannot exceed " + qty_limit.ToString + "")
            GVItemList.SetFocusedRowCellValue("sales_pos_det_qty_credit_note", 0)
        End If
    End Sub

    Private Sub GVItemList_CustomColumnDisplayText(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs) Handles GVItemList.CustomColumnDisplayText
        If e.Column.FieldName = "no" Then
            e.DisplayText = (e.ListSourceRowIndex + 1).ToString()
        End If
    End Sub



    Private Sub GVItemList_FocusedRowChanged(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles GVItemList.FocusedRowChanged

    End Sub

    Private Sub GVItemList_ColumnFilterChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GVItemList.ColumnFilterChanged

    End Sub
End Class