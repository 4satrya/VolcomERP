Public Class FormSalesOrder 
    Dim bnew_active As String = "1"
    Dim bedit_active As String = "1"
    Dim bdel_active As String = "1"
    Dim id_season_par As String = "-1"
    Dim super_user As String = get_setup_field("id_role_super_admin")

    Private Sub FormSalesOrder_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'date now
        Dim data As DataTable = execute_query("SELECT DATE(NOW()) AS `tgl`", -1, True, "", "", "", "")
        DEFrom.EditValue = data.Rows(0)("tgl")
        DEUntil.EditValue = data.Rows(0)("tgl")

        'viewSalesOrder()
        'viewSalesOrderGen()
    End Sub

    Sub viewSalesOrderGen()
        Dim query_c As ClassSalesOrder = New ClassSalesOrder()
        Dim query As String = ""

        'date
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
        Dim cond As String = "AND (gen.sales_order_gen_date>='" + date_from_selected + "' AND gen.sales_order_gen_date<='" + date_until_selected + "') "

        If id_role_login <> super_user Then
            query = query_c.queryMainGen("AND gen.id_user='" + id_user + "' " + cond, "2")
        Else
            query = query_c.queryMainGen(cond, "2")
        End If
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCGen.DataSource = data
        check_menu()
    End Sub


    Sub viewSalesOrder()
        Dim query_c As ClassSalesOrder = New ClassSalesOrder()
        Dim cond As String = "AND ISNULL(a.id_sales_order_gen) "
        If id_role_login <> super_user Then
            cond += "AND a.id_user_created='" + id_user + "' "
        End If

        'date
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
        cond += "AND (a.sales_order_date>='" + date_from_selected + "' AND a.sales_order_date<='" + date_until_selected + "') "

        Dim query As String = query_c.queryMain(cond, "2")
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCSalesOrder.DataSource = data
        check_menu()
        RepositoryItemProgressBar1.LookAndFeel.SkinName = "Blue"
    End Sub

    Private Sub FormSalesOrder_Activated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Activated
        FormMain.show_rb(Name)
        check_menu()
    End Sub

    Private Sub FormSalesOrder_Deactivate(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Deactivate
        FormMain.hide_rb()
    End Sub

    Sub noManipulating()
        Try
            Dim indeks As Integer = 0
            If XTCSOGeneral.SelectedTabPageIndex = 0 Then
                indeks = GVSalesOrder.FocusedRowHandle
            Else
                indeks = GVGen.FocusedRowHandle
            End If
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
        Catch ex As Exception

        End Try
    End Sub

    Sub check_menu()
        If XTCSOGeneral.SelectedTabPageIndex = 0 Then
            'based on receive
            If GVSalesOrder.RowCount < 1 Then
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
        ElseIf XTCSOGeneral.SelectedTabPageIndex = 1 Then
            If GVGen.RowCount < 1 Then
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
        End If
    End Sub

    Private Sub XTCSalesTarget_SelectedPageChanged(ByVal sender As System.Object, ByVal e As DevExpress.XtraTab.TabPageChangedEventArgs) Handles XTCSalesOrder.SelectedPageChanged
        check_menu()
    End Sub

    Private Sub GVSalesOrder_FocusedRowChanged(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles GVSalesOrder.FocusedRowChanged
        GCDetailSO.DataSource = Nothing
        'noManipulating()
        'viewDet()
    End Sub

    Sub viewDet()
        Dim id_sales_order As String = "-1"
        Try
            id_sales_order = GVSalesOrder.GetFocusedRowCellValue("id_sales_order").ToString
        Catch ex As Exception
        End Try
        Dim id_so_status As String = "-1"
        Try
            id_so_status = GVSalesOrder.GetFocusedRowCellValue("id_so_status").ToString
        Catch ex As Exception
        End Try
        view_list_so(id_sales_order, id_so_status)
    End Sub

    Private Sub GVItemList_CustomColumnDisplayText(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs) Handles GVDetailSO.CustomColumnDisplayText
        If e.Column.FieldName = "no" Then
            e.DisplayText = (e.ListSourceRowIndex + 1).ToString()
        End If
    End Sub

    Sub view_list_so(ByVal id_sales_order As String, ByVal id_type_par As String)
        Dim query As String = ""
        If id_type_par >= "1" And id_type_par <= "4" Then
            query = "CALL view_sales_order_limit('" + id_sales_order + "', '0', '0')"
        ElseIf id_type_par = "5" Then
            query = "CALL view_sales_order_limit_for_trf('" + id_sales_order + "', '0', '0')"
        Else
            query = "CALL view_sales_order_limit('" + id_sales_order + "', '0', '0')"
        End If
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCDetailSO.DataSource = data
    End Sub

    Private Sub LabelControl1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub SLESeason_EditValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Cursor = Cursors.WaitCursor
        Cursor = Cursors.Default
    End Sub

    Private Sub SLEDel_EditValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Cursor = Cursors.WaitCursor
        Cursor = Cursors.Default
    End Sub

    Private Sub BtnView_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        'Cursor = Cursors.WaitCursor
        'Dim tracker_no As String = "-1"
        'Try
        '    tracker_no = SLETracker.EditValue.ToString
        'Catch ex As Exception
        'End Try
        'If tracker_no = "-1" Then
        '    stopCustom("Please select tracker number !")
        'Else
        '    infoCustom("Sip bro")
        'End If
        'Cursor = Cursors.Default
    End Sub

    Private Sub GVSalesOrder_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GVSalesOrder.DoubleClick
        If GVSalesOrder.RowCount > 0 Then
            Cursor = Cursors.WaitCursor
            FormMain.but_edit()
            Cursor = Cursors.Default
        End If
    End Sub

    Private Sub XTCSOGeneral_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles XTCSOGeneral.Click

    End Sub

    Private Sub XTCSOGeneral_SelectedPageChanged(sender As Object, e As DevExpress.XtraTab.TabPageChangedEventArgs) Handles XTCSOGeneral.SelectedPageChanged
        check_menu()
    End Sub

    Private Sub GVGen_DoubleClick(sender As Object, e As EventArgs) Handles GVGen.DoubleClick
        If GVGen.FocusedRowHandle >= 0 And GVGen.RowCount > 0 Then
            FormMain.but_edit()
        End If
    End Sub

    Private Sub BtnView_Click_1(sender As Object, e As EventArgs) Handles BtnView.Click
        Cursor = Cursors.WaitCursor
        If XTCSOGeneral.SelectedTabPageIndex = 0 Then
            viewSalesOrder()
        Else
            viewSalesOrderGen()
        End If
        Cursor = Cursors.Default
    End Sub

    Private Sub BtnViewProgress_Click(sender As Object, e As EventArgs) Handles BtnViewProgress.Click
        Cursor = Cursors.WaitCursor
        noManipulating()
        viewDet()
        Cursor = Cursors.Default
    End Sub
End Class