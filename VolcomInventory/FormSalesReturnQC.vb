Public Class FormSalesReturnQC 
    Dim bnew_active As String = "1"
    Dim bedit_active As String = "1"
    Dim bdel_active As String = "1"

    Private Sub FormSalesReturnQC_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'date now
        Dim data As DataTable = execute_query("SELECT DATE(NOW()) AS `tgl`", -1, True, "", "", "", "")
        DEFrom.EditValue = data.Rows(0)("tgl")
        DEUntil.EditValue = data.Rows(0)("tgl")

        'return list
        viewSalesReturn()
    End Sub

    Private Sub FormSalesReturnQC_Activated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Activated
        FormMain.show_rb(Name)
        check_menu()
    End Sub

    Private Sub FormSalesReturnQC_Deactivate(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Deactivate
        FormMain.hide_rb()
    End Sub

    Sub viewSalesReturnQC()
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

        Dim query_c As ClassSalesReturnQC = New ClassSalesReturnQC()
        Dim query As String = query_c.queryMain("AND (a.sales_return_qc_date>='" + date_from_selected + "' AND a.sales_return_qc_date<='" + date_until_selected + "') ", "2")
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCSalesReturnQC.DataSource = data
        check_menu()
    End Sub

    Private Sub GVSalesReturnQC_DoubleClick(sender As Object, e As EventArgs) Handles GVSalesReturnQC.DoubleClick
        If GVSalesReturnQC.RowCount > 0 And GVSalesReturnQC.FocusedRowHandle >= 0 Then
            FormMain.but_edit()
        End If
    End Sub

    Private Sub SMPrePrint_Click(sender As Object, e As EventArgs) Handles SMPrePrint.Click
        Cursor = Cursors.WaitCursor
        FormSalesReturnQCDet.id_pre = "1"
        FormMain.but_edit()
        Cursor = Cursors.Default
    End Sub

    Private Sub SMPrint_Click(sender As Object, e As EventArgs) Handles SMPrint.Click
        Cursor = Cursors.WaitCursor
        FormSalesReturnQCDet.id_pre = "2"
        FormMain.but_edit()
        Cursor = Cursors.Default
    End Sub

    Private Sub GVSalesReturnQC_PopupMenuShowing(sender As Object, e As DevExpress.XtraGrid.Views.Grid.PopupMenuShowingEventArgs) Handles GVSalesReturnQC.PopupMenuShowing
        If GVSalesReturnQC.RowCount > 0 And GVSalesReturnQC.FocusedRowHandle >= 0 Then
            Dim id_stt As String = GVSalesReturnQC.GetFocusedRowCellValue("id_report_status").ToString
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

    Sub viewSalesReturn()
        Dim query As String = ""
        query += "SELECT a.id_sales_return, a.id_store_contact_from, a.id_comp_contact_to,(d.comp_name) AS store_name_from, (d1.comp_name) AS comp_name_to,a.id_report_status, f.report_status, "
        query += "a.sales_return_note, a.sales_return_number, "
        query += "DATE_FORMAT(a.sales_return_date,'%d %M %Y') AS sales_return_date "
        query += "FROM tb_sales_return a "
        query += "INNER JOIN tb_m_comp_contact c ON c.id_comp_contact = a.id_store_contact_from "
        query += "INNER JOIN tb_m_comp d ON c.id_comp = d.id_comp "
        query += "INNER JOIN tb_m_comp_contact c1 ON c1.id_comp_contact = a.id_comp_contact_to "
        query += "INNER JOIN tb_m_comp d1 ON c1.id_comp = d1.id_comp "
        query += "INNER JOIN tb_lookup_report_status f ON f.id_report_status = a.id_report_status "
        query += "INNER JOIN "
        query += "( "
        query += "SELECT a.id_sales_return,  a.id_sales_return_det, "
        query += "(a.sales_return_det_qty - COALESCE(ret.jum_ret, 0)) AS jum "
        query += "FROM tb_sales_return_det a "
        query += "INNER JOIN tb_sales_return b ON b.id_sales_return = a.id_sales_return "
        query += "LEFT JOIN ( "
        query += "SELECT b1.id_sales_return_det, SUM(b1.sales_return_qc_det_qty) AS jum_ret FROM tb_sales_return_qc_det b1 "
        query += "INNER JOIN tb_sales_return_qc b2 ON b1.id_sales_return_qc = b2.id_sales_return_qc "
        query += "WHERE b2.id_report_status != '5' "
        query += "GROUP BY b1.id_sales_return_det "
        query += ")ret ON ret.id_sales_return_det = a.id_sales_return_det  "
        query += "WHERE b.id_report_status = '6' AND (a.sales_return_det_qty - COALESCE(ret.jum_ret, 0)) >'0' "
        query += "GROUP BY a.id_sales_return "
        query += ") g ON g.id_sales_return = a.id_sales_return "
        query += "WHERE a.id_report_status = '6' AND a.id_ret_type=1 "
        query += "ORDER BY a.id_sales_return ASC "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCSalesReturn.DataSource = data
        check_menu()
    End Sub

    Sub viewListSalesReturnDet(ByVal id_sales_return As String)
        Dim query As String = "CALL view_sales_return_limit('" + id_sales_return + "','0', '0')"
        Dim data As DataTable = execute_query(query, "-1", True, "", "", "", "")
        GCItemList.DataSource = data
        GVItemList.OptionsBehavior.AutoExpandAllGroups = True
    End Sub

    Private Sub GVItemList_CustomColumnDisplayText(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs) Handles GVItemList.CustomColumnDisplayText
        If e.Column.FieldName = "no" Then
            e.DisplayText = (e.ListSourceRowIndex + 1).ToString()
        End If
    End Sub

    Sub rowChanged()
        Cursor = Cursors.WaitCursor
        GCItemList.DataSource = Nothing
        BtnPrintDetail.Visible = False
        Cursor = Cursors.Default
    End Sub

    Private Sub GVSalesReturnOrder_FocusedRowChanged(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles GVSalesReturn.FocusedRowChanged
        rowChanged()
    End Sub

    Private Sub GVSalesReturn_ColumnFilterChanged(sender As Object, e As EventArgs) Handles GVSalesReturn.ColumnFilterChanged
        rowChanged()
    End Sub

    Sub check_menu()
        If XTCReturnQC.SelectedTabPageIndex = 0 Then
            'based on receive
            If GVSalesReturnQC.RowCount < 1 Then
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
        ElseIf XTCReturnQC.SelectedTabPageIndex = 1 Then
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

    Sub noManipulating()
        Try
            If XTCReturnQC.SelectedTabPageIndex = 0 Then
                Dim indeks As Integer = GVSalesReturnQC.FocusedRowHandle
                If indeks < 0 Then
                    bnew_active = "1"
                    bedit_active = "0"
                    bdel_active = "0"
                Else
                    bnew_active = "1"
                    bedit_active = "1"
                    bdel_active = "1"
                End If
            ElseIf XTCReturnQC.SelectedTabPageIndex = 1 Then
                Dim indeks As Integer = GVSalesReturn.FocusedRowHandle
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

    Private Sub XTCReturnQC_SelectedPageChanged(sender As Object, e As DevExpress.XtraTab.TabPageChangedEventArgs) Handles XTCReturnQC.SelectedPageChanged
        check_menu()
    End Sub

    Private Sub BtnView_Click(sender As Object, e As EventArgs) Handles BtnView.Click
        Cursor = Cursors.WaitCursor
        viewSalesReturnQC()
        Cursor = Cursors.Default
    End Sub

    Private Sub BAccept_Click(sender As Object, e As EventArgs) Handles BAccept.Click
        Dim id_ret As String = "-1"
        Try
            id_ret = GVSalesReturn.GetFocusedRowCellValue("id_sales_return").ToString
        Catch ex As Exception
        End Try
        viewListSalesReturnDet(id_ret)
        BtnPrintDetail.Visible = True
    End Sub

    Private Sub BtnPrintDetail_Click(sender As Object, e As EventArgs) Handles BtnPrintDetail.Click
        Dim nbr As String = ""
        Try
            nbr = GVSalesReturn.GetFocusedRowCellValue("sales_return_number").ToString
        Catch ex As Exception

        End Try
        print(GCItemList, nbr)
    End Sub
End Class