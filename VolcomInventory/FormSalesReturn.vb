Public Class FormSalesReturn 
    Dim bnew_active As String = "1"
    Dim bedit_active As String = "1"
    Dim bdel_active As String = "1"

    Private Sub FormSalesReturn_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'date now
        Dim data As DataTable = execute_query("SELECT DATE(NOW()) AS `tgl`", -1, True, "", "", "", "")
        DEFrom.EditValue = data.Rows(0)("tgl")
        DEUntil.EditValue = data.Rows(0)("tgl")

        viewSalesReturnOrder()
    End Sub

    '==============SALES RETURN ORDER=============================
    Private Sub FormSalesReturn_Activated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Activated
        FormMain.show_rb(Name)
        checkFormAccess(Name)
        button_main(bnew_active, bedit_active, bdel_active)
    End Sub

    Private Sub FormSalesReturn_Deactivate(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Deactivate
        FormMain.hide_rb()
    End Sub

    Sub viewSalesReturn()
        Dim date_from_selected As String = "0000-01-01"
        Dim date_until_selected As String = "9999-01-01"
        Try
            date_from_selected = DateTime.Parse(DEFrom.EditValue.ToString).ToString("yyyy-MM-dd")
        Catch ex As Exception
        End Try
        Try
            date_until_selected = DateTime.Parse(DEUntil.EditValue.ToString).ToString("yyyy-MM-dd")
        Catch ex As Exception
        End Try

        Dim query_c As ClassSalesReturn = New ClassSalesReturn()
        Dim query As String = query_c.queryMain("AND (a.sales_return_date>='" + date_from_selected + "' AND a.sales_return_date<='" + date_until_selected + "') ", "2")
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCSalesReturn.DataSource = data
        check_menu()
    End Sub

    Sub noManipulating()
        Try
            If XTCSalesReturn.SelectedTabPageIndex = 0 Then
                Dim indeks As Integer = GVSalesReturn.FocusedRowHandle
                If indeks < 0 Then
                    bnew_active = "1"
                    bedit_active = "0"
                    bdel_active = "0"
                Else
                    bnew_active = "1"
                    bedit_active = "1"
                    bdel_active = "1"
                End If
            ElseIf XTCSalesReturn.SelectedTabPageIndex = 1 Then
                Dim indeks As Integer = GVSalesReturnOrder.FocusedRowHandle
                If indeks < 0 Then
                    bnew_active = "0"
                    bedit_active = "0"
                    bdel_active = "0"
                Else
                    bnew_active = "1"
                    bedit_active = "0"
                    bdel_active = "0"
                End If
            End If
            checkFormAccess(Name)
            button_main(bnew_active, bedit_active, bdel_active)
        Catch ex As Exception

        End Try
    End Sub

    Sub check_menu()
        If XTCSalesReturn.SelectedTabPageIndex = 0 Then
            'based on receive
            If GVSalesReturn.RowCount < 1 Then
                'hide all except new
                bnew_active = "1"
                bedit_active = "0"
                bdel_active = "0"
                checkFormAccess(Name)
                button_main(bnew_active, bedit_active, bdel_active)
                noManipulating()
            Else
                'show all
                bnew_active = "1"
                bedit_active = "1"
                bdel_active = "1"
                checkFormAccess(Name)
                button_main(bnew_active, bedit_active, bdel_active)
                noManipulating()
            End If
        ElseIf XTCSalesReturn.SelectedTabPageIndex = 1 Then
            'based on SO
            If GVSalesReturn.RowCount < 1 Then
                'hide all
                bnew_active = "0"
                bedit_active = "0"
                bdel_active = "0"
                checkFormAccess(Name)
                button_main(bnew_active, bedit_active, bdel_active)
                noManipulating()
            Else
                'show all
                bnew_active = "1"
                bedit_active = "0"
                bdel_active = "0"
                checkFormAccess(Name)
                button_main(bnew_active, bedit_active, bdel_active)
                noManipulating()
            End If
        End If
    End Sub


    Private Sub GVSalesReturn_FocusedRowChanged(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles GVSalesReturn.FocusedRowChanged
        noManipulating()
    End Sub

    Private Sub XTCSalesReturn_SelectedPageChanged(ByVal sender As System.Object, ByVal e As DevExpress.XtraTab.TabPageChangedEventArgs) Handles XTCSalesReturn.SelectedPageChanged
        check_menu()
    End Sub

    '====================WAITING SALES RETURN ORDER==========================
    Sub viewSalesReturnOrder()
        Dim query_c As ClassReturn = New ClassReturn()
        Dim query As String = query_c.queryMain("AND a.id_report_status = '6' AND (a.id_prepare_status='1') ", "1")
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCSalesReturnOrder.DataSource = data
        check_menu()
    End Sub

    Sub viewListReturnOrder(ByVal id_sales_return_order As String, ByVal id_store As String, ByVal drawer As String, ByVal rack As String, ByVal locator As String)
        Dim query As String = ""
        query = "CALL view_sales_return_order_limit('" + id_sales_return_order + "', '0', '0')"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        Dim dt As DataTable = execute_query("CALL view_stock_fg('" + id_store + "', '" + locator + "', '" + rack + "', '" + drawer + "', '0', '4', '9999-01-01')", -1, True, "", "", "", "")
        Dim tb1 = data.AsEnumerable()
        Dim tb2 = dt.AsEnumerable()
        Dim query_new = From table1 In tb1
                        Group Join table_tmp In tb2 On table1("code") Equals table_tmp("code")
                            Into Group
                        From y1 In Group.DefaultIfEmpty()
                        Select New With
                            {
                            .code = table1.Field(Of String)("code"),
                            .name = table1.Field(Of String)("name"),
                            .size = table1.Field(Of String)("size"),
                            .sales_return_order_det_qty = CType(table1("sales_return_order_det_qty"), Decimal),
                            .sales_return_det_qty_view = CType(table1("sales_return_det_qty_view"), Decimal),
                            .soh = If(y1 Is Nothing, 0.0, y1("qty_all_product")),
                            .design_price = CType(table1("design_price"), Decimal),
                           .amount = CType(table1("amount"), Decimal)
                            }

        GCSalesReturnOrderDetail.DataSource = query_new.ToList
        GVSalesReturnOrderDetail.OptionsBehavior.AutoExpandAllGroups = True
    End Sub


    Private Sub GVSalesReturnOrder_FocusedRowChanged(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles GVSalesReturnOrder.FocusedRowChanged
        rowChanged()
    End Sub

    Sub rowChanged()
        Cursor = Cursors.WaitCursor
        GCSalesReturnOrderDetail.DataSource = Nothing
        BtnPrintDetail.Visible = False
        'noManipulating()
        'Dim id_sales_return_order As String = "-1"
        'Try
        '    id_sales_return_order = GVSalesReturnOrder.GetFocusedRowCellValue("id_sales_return_order").ToString
        'Catch ex As Exception
        'End Try
        'Dim id_store_contact_to As String = "-1"
        'Try
        '    id_store_contact_to = GVSalesReturnOrder.GetFocusedRowCellValue("id_store_contact_to").ToString
        'Catch ex As Exception
        'End Try

        'Dim id_wh_drawer As String = "-1"
        'Try
        '    id_wh_drawer = GVSalesReturnOrder.GetFocusedRowCellValue("id_wh_drawer_store").ToString
        'Catch ex As Exception
        'End Try

        'Dim id_wh_rack As String = "-1"
        'Try
        '    id_wh_rack = GVSalesReturnOrder.GetFocusedRowCellValue("id_wh_rack_store").ToString
        'Catch ex As Exception
        'End Try

        'Dim id_wh_locator As String = "-1"
        'Try
        '    id_wh_locator = GVSalesReturnOrder.GetFocusedRowCellValue("id_wh_locator_store").ToString
        'Catch ex As Exception
        'End Try
        'Try
        '    viewListReturnOrder(id_sales_return_order, get_company_contact_x(id_store_contact_to, "3"), id_wh_drawer, id_wh_rack, id_wh_locator)
        'Catch ex As Exception

        'End Try
        Cursor = Cursors.Default
    End Sub

    Private Sub GVSalesReturnOrderDetail_CustomColumnDisplayText(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs) Handles GVSalesReturnOrderDetail.CustomColumnDisplayText
        If e.Column.FieldName = "no" Then
            e.DisplayText = (e.ListSourceRowIndex + 1).ToString()
        End If
    End Sub

    Private Sub GVSalesReturnOrder_ColumnFilterChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GVSalesReturnOrder.ColumnFilterChanged
        rowChanged()
    End Sub

    Private Sub GVSalesReturnOrder_RowStyle(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Grid.RowStyleEventArgs) Handles GVSalesReturnOrder.RowStyle
        'If (e.RowHandle >= 0) Then
        '    'pick field
        '    If Date.Parse(sender.GetRowCellValue(e.RowHandle, sender.Columns("sales_return_order_date_current"))) >= Date.Parse(sender.GetRowCellValue(e.RowHandle, sender.Columns("sales_return_order_est_date"))) Then
        '        e.Appearance.BackColor = Color.Salmon
        '        e.Appearance.BackColor2 = Color.White
        '    End If
        'End If
    End Sub

    Private Sub GVSalesReturn_DoubleClick(sender As Object, e As EventArgs) Handles GVSalesReturn.DoubleClick
        If GVSalesReturn.RowCount > 0 And GVSalesReturn.FocusedRowHandle >= 0 Then
            Cursor = Cursors.WaitCursor
            FormMain.but_edit()
            Cursor = Cursors.Default
        End If
    End Sub

    Private Sub SMPrePrint_Click(sender As Object, e As EventArgs) Handles SMPrePrint.Click
        Cursor = Cursors.WaitCursor
        FormSalesReturnDet.id_pre = "1"
        FormMain.but_edit()
        Cursor = Cursors.Default
    End Sub

    Private Sub SMPrint_Click(sender As Object, e As EventArgs) Handles SMPrint.Click
        Cursor = Cursors.WaitCursor
        FormSalesReturnDet.id_pre = "2"
        FormMain.but_edit()
        Cursor = Cursors.Default
    End Sub

    Private Sub GVSalesReturn_PopupMenuShowing(sender As Object, e As DevExpress.XtraGrid.Views.Grid.PopupMenuShowingEventArgs) Handles GVSalesReturn.PopupMenuShowing
        If GVSalesReturn.RowCount > 0 And GVSalesReturn.FocusedRowHandle >= 0 Then
            Dim id_stt As String = GVSalesReturn.GetFocusedRowCellValue("id_report_status").ToString
            If id_stt <> "3" And id_stt <> "4" And id_stt <> "6" Then
                SMPrint.Visible = False
            Else
                SMPrint.Visible = True
            End If

            If id_stt <> "1" And id_stt <> "2" And id_stt <> "3" And id_stt <> "4" And id_stt <> "6" Then
                SMPrePrint.Visible = False
            Else
                SMPrePrint.Visible = True
            End If
            Dim view As DevExpress.XtraGrid.Views.Grid.GridView = CType(sender, DevExpress.XtraGrid.Views.Grid.GridView)
            Dim hitInfo As DevExpress.XtraGrid.Views.Grid.ViewInfo.GridHitInfo = view.CalcHitInfo(e.Point)
            If hitInfo.InRow And hitInfo.RowHandle >= 0 Then
                view.FocusedRowHandle = hitInfo.RowHandle
                ViewMenu.Show(view.GridControl, e.Point)
            End If
        End If
    End Sub

    Private Sub BAccept_Click(sender As Object, e As EventArgs) Handles BAccept.Click
        Dim id_sales_return_order As String = "-1"
        Try
            id_sales_return_order = GVSalesReturnOrder.GetFocusedRowCellValue("id_sales_return_order").ToString
        Catch ex As Exception
        End Try
        Dim id_store_contact_to As String = "-1"
        Try
            id_store_contact_to = GVSalesReturnOrder.GetFocusedRowCellValue("id_store_contact_to").ToString
        Catch ex As Exception
        End Try

        Dim id_wh_drawer As String = "-1"
        Try
            id_wh_drawer = GVSalesReturnOrder.GetFocusedRowCellValue("id_wh_drawer_store").ToString
        Catch ex As Exception
        End Try

        Dim id_wh_rack As String = "-1"
        Try
            id_wh_rack = GVSalesReturnOrder.GetFocusedRowCellValue("id_wh_rack_store").ToString
        Catch ex As Exception
        End Try

        Dim id_wh_locator As String = "-1"
        Try
            id_wh_locator = GVSalesReturnOrder.GetFocusedRowCellValue("id_wh_locator_store").ToString
        Catch ex As Exception
        End Try
        Try
            viewListReturnOrder(id_sales_return_order, get_company_contact_x(id_store_contact_to, "3"), id_wh_drawer, id_wh_rack, id_wh_locator)
        Catch ex As Exception

        End Try
        BtnPrintDetail.Visible = True
    End Sub

    Private Sub BtnPrintDetail_Click(sender As Object, e As EventArgs) Handles BtnPrintDetail.Click
        Dim nbr As String = ""
        Try
            nbr = GVSalesReturnOrder.GetFocusedRowCellValue("sales_return_order_number").ToString
        Catch ex As Exception

        End Try
        print(GCSalesReturnOrderDetail, nbr)
    End Sub

    Private Sub BtnView_Click(sender As Object, e As EventArgs) Handles BtnView.Click
        Cursor = Cursors.WaitCursor
        viewSalesReturn()
        Cursor = Cursors.Default
    End Sub
End Class