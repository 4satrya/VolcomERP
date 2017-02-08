Public Class FormFGTrfNew 
    Dim bnew_active As String = "1"
    Dim bedit_active As String = "1"
    Dim bdel_active As String = "1"
    Public id_sales_order_gen As String = "-1"

    Private Sub FormFGTrfNew_Activated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Activated
        FormMain.show_rb(Name)
        check_menu()
    End Sub

    Private Sub FormFGTrfNew_Deactivate(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Deactivate
        FormMain.hide_rb()
    End Sub

    Private Sub FormFGTrfNew_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'date now
        Dim data As DataTable = execute_query("SELECT DATE(NOW()) AS `tgl`", -1, True, "", "", "", "")
        DEFrom.EditValue = data.Rows(0)("tgl")
        DEUntil.EditValue = data.Rows(0)("tgl")


        viewSalesOrder()

        'set notif load
        TimerMonitor.Interval = Integer.Parse(get_setup_field("load_notif"))
    End Sub

    Sub viewFGTrf()
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

        Dim query_c As ClassFGTrf = New ClassFGTrf()
        Dim query As String = query_c.queryMain("AND (trf.fg_trf_date>=''" + date_from_selected + "'' AND trf.fg_trf_date<=''" + date_until_selected + "'') ", "2")
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCFGTrf.DataSource = data
        check_menu()
    End Sub

    Sub viewSalesOrder()
        Dim query_c As ClassSalesOrder = New ClassSalesOrder()
        Dim query As String = query_c.queryMain("AND a.id_so_status=5 AND a.id_report_status='6' AND a.id_prepare_status='1' AND d.is_only_for_alloc=2 ", "1")
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCSalesOrder.DataSource = data
    End Sub

    Sub check_menu()
        If XTCTrf.SelectedTabPageIndex = 0 Then
            If GVFGTrf.RowCount < 1 Then
                'hide all except new
                bnew_active = "1"
                bedit_active = "0"
                bdel_active = "0"
                checkFormAccess(Name)
                button_main(bnew_active, bedit_active, bdel_active)
            Else
                'show all
                bnew_active = "1"
                bedit_active = "1"
                bdel_active = "1"
                noManipulating()
            End If
        ElseIf XTCTrf.SelectedTabPageIndex = 1 Then
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
        ElseIf XTCTrf.SelectedTabPageIndex = 2 Then
            bnew_active = "0"
            bedit_active = "0"
            bdel_active = "0"
            checkFormAccess(Name)
            button_main(bnew_active, bedit_active, bdel_active)
        End If
    End Sub

    Sub noManipulating()
        If XTCTrf.SelectedTabPageIndex = 0 Then
            Dim indeks As Integer = GVFGTrf.FocusedRowHandle
            If indeks < 0 Then
                bnew_active = "1"
                bedit_active = "0"
                bdel_active = "0"
            Else
                bnew_active = "1"
                bedit_active = "1"
                bdel_active = "1"
            End If
            checkFormAccess(Name)
            button_main(bnew_active, bedit_active, bdel_active)
        ElseIf XTCTrf.SelectedTabPageIndex = 1 Then
            Dim indeks As Integer = GVSalesOrder.FocusedRowHandle
            If indeks < 0 Then
                bnew_active = "0"
                bedit_active = "0"
                bdel_active = "0"
            Else
                bnew_active = "1"
                bedit_active = "0"
                bdel_active = "0"
            End If
            checkFormAccess(Name)
            button_main(bnew_active, bedit_active, bdel_active)
        End If
    End Sub

    Private Sub GVFGTrf_FocusedRowChanged(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles GVFGTrf.FocusedRowChanged
        noManipulating()
    End Sub

    Private Sub GVFGTrf_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GVFGTrf.DoubleClick
        If GVFGTrf.RowCount > 0 And GVFGTrf.FocusedRowHandle >= 0 Then
            FormMain.but_edit()
        End If
    End Sub

    Private Sub SMPrePrint_Click(sender As Object, e As EventArgs) Handles SMPrePrint.Click
        Cursor = Cursors.WaitCursor
        FormFGTrfNewDet.id_pre = "1"
        FormMain.but_edit()
        Cursor = Cursors.Default
    End Sub

    Private Sub SMPrint_Click(sender As Object, e As EventArgs) Handles SMPrint.Click
        Cursor = Cursors.WaitCursor
        If XTCTrf.SelectedTabPageIndex = 0 Then
            FormFGTrfNewDet.id_pre = "2"
            FormMain.but_edit()
        Else
            If GVSalesOrder.FocusedRowHandle >= 0 And GVSalesOrder.RowCount > 0 Then
                FormViewSalesOrder.id_sales_order = GVSalesOrder.GetFocusedRowCellValue("id_sales_order").ToString
                FormViewSalesOrder.is_print = "1"
                FormViewSalesOrder.ShowDialog()
            End If
        End If
        Cursor = Cursors.Default
    End Sub

    Private Sub GVFGTrf_PopupMenuShowing(sender As Object, e As DevExpress.XtraGrid.Views.Grid.PopupMenuShowingEventArgs) Handles GVFGTrf.PopupMenuShowing
        If GVFGTrf.RowCount > 0 And GVFGTrf.FocusedRowHandle >= 0 Then
            Dim id_stt As String = GVFGTrf.GetFocusedRowCellValue("id_report_status").ToString
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

    Private Sub CheckEditRefresh_CheckedChanged(sender As Object, e As EventArgs) Handles CheckEditRefresh.CheckedChanged
        Dim cek As String = CheckEditRefresh.EditValue.ToString
        If cek Then
            TimerMonitor.Enabled = True
        Else
            TimerMonitor.Enabled = False
        End If
    End Sub

    Private Sub BtnView_Click(sender As Object, e As EventArgs) Handles BtnView.Click
        Cursor = Cursors.WaitCursor
        viewFGTrf()
        Cursor = Cursors.Default
    End Sub

    Private Sub XTCTrf_SelectedPageChanged(sender As Object, e As DevExpress.XtraTab.TabPageChangedEventArgs) Handles XTCTrf.SelectedPageChanged
        check_menu()
        If XTCTrf.SelectedTabPageIndex = 0 Then
            SMPrePrint.Visible = True
        ElseIf XTCTrf.SelectedTabPageIndex = 1 Then
            SMPrePrint.Visible = False
            GVSalesOrder.ShowFindPanel()
            GVSalesOrder.ShowFindPanel()
        ElseIf XTCTrf.SelectedTabPageIndex = 2 Then
            TxtNoParam.Focus()
        End If
    End Sub

    Private Sub GVFGTrf_ColumnFilterChanged(sender As Object, e As EventArgs) Handles GVFGTrf.ColumnFilterChanged
        noManipulating()
    End Sub

    Private Sub GVSalesOrder_ColumnFilterChanged(sender As Object, e As EventArgs) Handles GVSalesOrder.ColumnFilterChanged
        noManipulating()
    End Sub

    Private Sub GVSalesOrder_FocusedRowChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles GVSalesOrder.FocusedRowChanged
        noManipulating()
    End Sub

    Private Sub TxtNoParam_ButtonClick(sender As Object, e As DevExpress.XtraEditors.Controls.ButtonPressedEventArgs) Handles TxtNoParam.ButtonClick
        Cursor = Cursors.WaitCursor
        FormSalesOrderRef.id_pop_up = "2"
        FormSalesOrderRef.ShowDialog()
        Cursor = Cursors.Default
    End Sub

    Sub viewRef()
        Cursor = Cursors.WaitCursor
        Dim val As String = addSlashes(TxtNoParam.Text.ToString)
        If val = "" Then
            errorCustom("Data not found !")
        Else
            If id_sales_order_gen = "-1" Then
                Dim query As String = "SELECT id_sales_order_gen FROM tb_sales_order_gen WHERE sales_order_gen_reff='" + val + "' AND id_so_status=5 LIMIT 1 "
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

    Private Sub BtnViewNewPrepare_Click(sender As Object, e As EventArgs) Handles BtnViewNewPrepare.Click
        viewRef()
    End Sub


    Private Sub TxtNoParam_KeyDown(sender As Object, e As KeyEventArgs) Handles TxtNoParam.KeyDown
        If e.KeyCode = Keys.Enter Then
            viewRef()
        End If
    End Sub
End Class