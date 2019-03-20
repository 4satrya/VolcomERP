Public Class FormSalesDelOrder 
    Dim bnew_active As String = "1"
    Dim bedit_active As String = "1"
    Dim bdel_active As String = "1"
    Public id_sales_order_gen As String = "-1"
    Dim is_all_order As Boolean = True

    Private Sub FormSalesDelOrder_Activated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Activated
        FormMain.show_rb(Name)
        check_menu()
    End Sub

    Private Sub FormSalesDelOrder_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'date now
        Dim data As DataTable = execute_query("SELECT DATE(NOW()) AS `tgl`", -1, True, "", "", "", "")
        DEFrom.EditValue = data.Rows(0)("tgl")
        DEUntil.EditValue = data.Rows(0)("tgl")

        'load prepare listt
        viewSalesOrder()

        'set notif load
        TimerMonitor.Interval = Integer.Parse(get_setup_field("load_notif"))
    End Sub

    Sub viewSalesOrder()
        Dim query_c As ClassSalesOrder = New ClassSalesOrder()
        Dim query As String = query_c.queryMain("AND a.id_so_status!=5 AND a.id_report_status='6' AND a.id_prepare_status='1' ", "1")
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCSalesOrder.DataSource = data
        GridColumnEmpCode.Visible = False
        GridColumnEmpName.Visible = False
    End Sub

    Sub viewUniformOrder()
        Dim query_c As ClassSalesOrder = New ClassSalesOrder()
        Dim query As String = query_c.queryMain("AND a.id_so_status=7 AND a.id_report_status='6' AND a.id_prepare_status='1' ", "1")
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCSalesOrder.DataSource = data
        GridColumnEmpCode.VisibleIndex = 1
        GridColumnEmpName.VisibleIndex = 2
    End Sub

    Sub viewSalesDelOrder()
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

        Dim query_c As ClassSalesDelOrder = New ClassSalesDelOrder()
        Dim query As String = query_c.queryMain("AND (a.pl_sales_order_del_date>='" + date_from_selected + "' AND a.pl_sales_order_del_date<='" + date_until_selected + "') ", "2")
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCSalesDelOrder.DataSource = data
        GVSalesDelOrder.BestFitColumns()
        check_menu()
    End Sub

    Private Sub FormSalesDelOrder_Deactivate(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Deactivate
        FormMain.hide_rb()
    End Sub

    Sub noManipulating()
        If XTCDO.SelectedTabPageIndex = 0 Then
            Dim indeks As Integer = 0
            Try
                indeks = GVSalesDelOrder.FocusedRowHandle
            Catch ex As Exception
            End Try
            If indeks < 0 Then
                bnew_active = "1"
                bedit_active = "0"
                bdel_active = "0"
            Else
                bnew_active = "1"
                bedit_active = "1"
                bdel_active = "1"
            End If
        ElseIf XTCDO.SelectedTabPageIndex = 1 Then
            Dim indeks As Integer = 0
            Try
                indeks = GVSalesOrder.FocusedRowHandle
            Catch ex As Exception
            End Try
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
    End Sub

    Sub check_menu()
        If XTCDO.SelectedTabPageIndex = 0 Then
            'based on receive
            If GVSalesDelOrder.RowCount < 1 Then
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
        ElseIf XTCDO.SelectedTabPageIndex = 1 Then
            'based on SO
            If GVSalesOrder.RowCount < 1 Then
                'hide all except new
                bnew_active = "0"
                bedit_active = "0"
                bdel_active = "0"
                checkFormAccess(Name)
                button_main(bnew_active, bedit_active, bdel_active)
            Else
                'show all
                bnew_active = "1"
                bedit_active = "0"
                bdel_active = "0"
                noManipulating()
            End If
        ElseIf XTCDO.SelectedTabPageIndex = 2 Then
            bnew_active = "0"
            bedit_active = "0"
            bdel_active = "0"
            checkFormAccess(Name)
            button_main(bnew_active, bedit_active, bdel_active)
        End If
    End Sub

    Private Sub GVSalesDelOrder_FocusedRowChanged(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles GVSalesDelOrder.FocusedRowChanged
        noManipulating()
    End Sub

    Private Sub XTCSalesDelOrder_SelectedPageChanged(ByVal sender As System.Object, ByVal e As DevExpress.XtraTab.TabPageChangedEventArgs) Handles XTCSalesDelOrder.SelectedPageChanged
        check_menu()
    End Sub

    Private Sub GVSalesOrder_FocusedRowChanged(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs)
        noManipulating()
    End Sub

    Private Sub GVItemList_FocusedRowChanged(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs)

    End Sub

    Private Sub GVItemList_CustomColumnDisplayText(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs)
        If e.Column.FieldName = "no" Then
            e.DisplayText = (e.ListSourceRowIndex + 1).ToString()
        End If
    End Sub

    Private Sub GVSalesDelOrder_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GVSalesDelOrder.DoubleClick
        If GVSalesDelOrder.RowCount > 0 Then
            FormMain.but_edit()
        End If
    End Sub

    Private Sub GVSalesDelOrder_PopupMenuShowing(sender As Object, e As DevExpress.XtraGrid.Views.Grid.PopupMenuShowingEventArgs) Handles GVSalesDelOrder.PopupMenuShowing
        If GVSalesDelOrder.RowCount > 0 And GVSalesDelOrder.FocusedRowHandle >= 0 Then
            Dim id_stt As String = GVSalesDelOrder.GetFocusedRowCellValue("id_report_status").ToString
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

    Private Sub SMPrePrint_Click(sender As Object, e As EventArgs) Handles SMPrePrint.Click
        Cursor = Cursors.WaitCursor
        FormSalesDelOrderDet.id_pre = "1"
        FormMain.but_edit()
        Cursor = Cursors.Default
    End Sub

    Private Sub SMPrint_Click(sender As Object, e As EventArgs) Handles SMPrint.Click
        Cursor = Cursors.WaitCursor
        If XTCDO.SelectedTabPageIndex = 0 Then
            FormSalesDelOrderDet.id_pre = "2"
            FormMain.but_edit()
        Else
            If GVSalesOrder.FocusedRowHandle >= 0 And GVSalesOrder.RowCount > 0 Then
                Dim id As String = GVSalesOrder.GetFocusedRowCellValue("id_sales_order").ToString
                FormViewSalesOrder.id_sales_order = id
                FormViewSalesOrder.is_print = "1"
                FormViewSalesOrder.ShowDialog()
                If is_all_order Then
                    viewSalesOrder()
                Else
                    viewUniformOrder()
                End If
                GVSalesOrder.FocusedRowHandle = find_row(GVSalesOrder, "id_sales_order", id)
            End If
        End If
        Cursor = Cursors.Default
    End Sub

    Private Sub BtnViewNewPrepare_Click(sender As Object, e As EventArgs) Handles BtnViewNewPrepare.Click
        viewrRef()
    End Sub

    Sub viewrRef()
        Cursor = Cursors.WaitCursor
        Dim val As String = addSlashes(TxtNoParam.Text.ToString)
        If val = "" Then
            errorCustom("Data not found !")
        Else
            If id_sales_order_gen = "-1" Then
                Dim query As String = "SELECT id_sales_order_gen FROM tb_sales_order_gen WHERE sales_order_gen_reff='" + val + "' AND id_so_status<>5 LIMIT 1 "
                id_sales_order_gen = "-1"
                Try
                    id_sales_order_gen = execute_query(query, 0, True, "", "", "", "")
                Catch ex As Exception
                End Try
            End If

            If id_sales_order_gen = "-1" Then
                errorCustom("Data not found !")
                GCNewPrepare.DataSource = Nothing
            Else
                Dim rf As New ClassSalesOrder()
                rf.viewReff(id_sales_order_gen, "-1", GCNewPrepare, GVNewPrepare)
                id_sales_order_gen = "-1"
            End If
        End If
        Cursor = Cursors.Default
    End Sub

    Private Sub TxtNoParam_KeyDown(sender As Object, e As KeyEventArgs) Handles TxtNoParam.KeyDown
        If e.KeyCode = Keys.Enter Then
            viewrRef()
        End If
    End Sub

    Private Sub XTCDO_SelectedPageChanged(sender As Object, e As DevExpress.XtraTab.TabPageChangedEventArgs) Handles XTCDO.SelectedPageChanged
        check_menu()
        If XTCDO.SelectedTabPageIndex = 0 Then
            SMPrePrint.Visible = True
        ElseIf XTCDO.SelectedTabPageIndex = 1 Then
            SMPrePrint.Visible = False
            GVSalesOrder.ShowFindPanel()
            GVSalesOrder.ShowFindPanel()
        ElseIf XTCDO.SelectedTabPageIndex = 2 Then
            TxtNoParam.Focus()
        End If
    End Sub

    Private Sub TxtNoParam_ButtonClick(sender As Object, e As DevExpress.XtraEditors.Controls.ButtonPressedEventArgs) Handles TxtNoParam.ButtonClick
        Cursor = Cursors.WaitCursor
        FormSalesOrderRef.id_pop_up = "1"
        FormSalesOrderRef.ShowDialog()
        Cursor = Cursors.Default
    End Sub

    Private Sub TimerMonitor_Tick(sender As Object, e As EventArgs) Handles TimerMonitor.Tick
        Cursor = Cursors.WaitCursor
        viewSalesOrder()
        Cursor = Cursors.Default
    End Sub

    Private Sub CheckEditRefresh_CheckedChanged(sender As Object, e As EventArgs) Handles CheckEditRefresh.CheckedChanged
        Dim cek As String = CheckEditRefresh.EditValue.ToString
        If cek Then
            TimerMonitor.Enabled = True
        Else
            TimerMonitor.Enabled = False
        End If
    End Sub

    Private Sub GVSalesDelOrder_ColumnFilterChanged(sender As Object, e As EventArgs) Handles GVSalesDelOrder.ColumnFilterChanged
        noManipulating()
    End Sub

    Private Sub GVSalesOrder_ColumnFilterChanged(sender As Object, e As EventArgs) Handles GVSalesOrder.ColumnFilterChanged
        noManipulating()
    End Sub

    Private Sub GVSalesOrder_FocusedRowChanged_1(sender As Object, e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles GVSalesOrder.FocusedRowChanged
        noManipulating()
    End Sub

    Private Sub BtnView_Click(sender As Object, e As EventArgs) Handles BtnView.Click
        Cursor = Cursors.WaitCursor
        viewSalesDelOrder()
        Cursor = Cursors.Default
    End Sub

    Private Sub BtnCombineDel_Click(sender As Object, e As EventArgs) Handles BtnCombineDel.Click
        Cursor = Cursors.WaitCursor
        FormSalesDelOrderSlip.action = "ins"
        FormSalesDelOrderSlip.ShowDialog()
        Cursor = Cursors.Default
    End Sub

    Private Sub ViewCombinedDeliveryToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ViewCombinedDeliveryToolStripMenuItem.Click
        Dim id_combine As String = ""
        Try
            id_combine = GVSalesDelOrder.GetFocusedRowCellValue("id_combine").ToString
        Catch ex As Exception
        End Try
        If id_combine = "0" Then
            id_combine = ""
        End If
        If id_combine <> "" Then
            Cursor = Cursors.WaitCursor
            FormSalesDelOrderSlip.action = "upd"
            FormSalesDelOrderSlip.id_pl_sales_order_del_slip = id_combine
            FormSalesDelOrderSlip.ShowDialog()
            Cursor = Cursors.Default
        Else
            stopCustom("Combined delivery not found")
        End If
    End Sub

    Private Sub BtnShowUniform_Click(sender As Object, e As EventArgs) Handles BtnShowUniform.Click
        Cursor = Cursors.WaitCursor
        viewUniformOrder()
        is_all_order = False
        Cursor = Cursors.Default
    End Sub

    Private Sub BtnShowAll_Click(sender As Object, e As EventArgs) Handles BtnShowAll.Click
        Cursor = Cursors.WaitCursor
        viewSalesOrder()
        is_all_order = True
        Cursor = Cursors.Default
    End Sub

    Private Sub FileAttachmentToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles FileAttachmentToolStripMenuItem.Click
        If GVSalesOrder.RowCount > 0 And GVSalesOrder.FocusedRowHandle >= 0 Then
            Cursor = Cursors.WaitCursor
            FormDocumentUpload.report_mark_type = "39"
            FormDocumentUpload.id_report = GVSalesOrder.GetFocusedRowCellValue("id_sales_order").ToString
            FormDocumentUpload.is_view = "1"
            FormDocumentUpload.ShowDialog()
            Cursor = Cursors.Default
        End If
    End Sub
End Class