Public Class FormMasterPrice
    Dim bnew_active As String = "1"
    Dim bedit_active As String = "1"
    Dim bdel_active As String = "1"
    Dim super_user As String = get_setup_field("id_role_super_admin")

    Private Sub FormMasterPrice_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        viewSeason()

        'set default
        Dim dt_now As DataTable = execute_query("SELECT DATE(NOW()) as tgl", -1, True, "", "", "", "")
        DEFrom.EditValue = dt_now.Rows(0)("tgl")
        DEFromList.EditValue = dt_now.Rows(0)("tgl")
        DEUntilList.EditValue = dt_now.Rows(0)("tgl")
    End Sub

    Sub viewSeason()
        Dim query As String = ""
        query += "SELECT (0) AS `id_season`, (0) AS `range`, ('All Season') AS `season` UNION ALL "
        query += "(SELECT a.id_season, b.range, a.season FROM tb_season a "
        query += "INNER JOIN tb_range b ON a.id_range = b.id_range "
        query += "ORDER BY b.range DESC) "
        viewSearchLookupQuery(SLESeason, query, "id_season", "season", "id_season")
    End Sub

    Sub viewDel()
        Dim id_ss As String = "0"
        Try
            id_ss = SLESeason.EditValue.ToString
        Catch ex As Exception
        End Try
        Dim query As String = "SELECT ('0') AS id_delivery, ('All Delivery') AS delivery "
        query += "UNION ALL "
        query += "SELECT id_delivery, delivery FROM tb_season_delivery "
        query += "WHERE id_season = '" + id_ss + "' "
        query += "ORDER BY id_delivery ASC "
        viewSearchLookupQuery(SLEDel, query, "id_delivery", "delivery", "id_delivery")
    End Sub

    Sub browsePrice()
        Cursor = Cursors.WaitCursor
        Dim cond As String = "-1"
        Dim date_from_selected As String = ""
        Try
            date_from_selected = DateTime.Parse(DEFrom.EditValue.ToString).ToString("yyyy-MM-dd")
        Catch ex As Exception
        End Try
        Dim query As String = ""

        'condition
        If SLESeason.EditValue.ToString <> "0" Then
            cond = "AND d.id_season=''" + SLESeason.EditValue.ToString + "'' "
        End If
        If SLEDel.EditValue.ToString <> "0" Then
            cond += "AND d.id_delivery=''" + SLEDel.EditValue.ToString + "'' "
        End If

        If date_from_selected <> "" Then
            query = "CALL view_product_price('" + cond + "', '" + date_from_selected + "')"
        Else
            query = "CALL view_product_price('" + cond + "', DATE(NOW()))"
        End If
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCBrowsePrice.DataSource = data
        GVBrowsePrice.BestFitColumns()
        Cursor = Cursors.Default
    End Sub

    Sub viewPrice()
        Cursor = Cursors.WaitCursor
        Dim query_c As ClassDesign = New ClassDesign()
        Dim cond As String = ""
        If id_role_login <> super_user Then
            cond = "AND prc.id_user_created='" + id_user + "' "
        End If

        'date
        Dim date_from_selected As String = "0000-01-01"
        Dim date_until_selected As String = "9999-01-01"
        Try
            date_from_selected = DateTime.Parse(DEFromList.EditValue.ToString).ToString("yyyy-MM-dd")
        Catch ex As Exception
        End Try
        Try
            date_until_selected = DateTime.Parse(DEUntilList.EditValue.ToString).ToString("yyyy-MM-dd")
        Catch ex As Exception
        End Try
        cond += "AND (prc.fg_price_date>='" + date_from_selected + "' AND prc.fg_price_date<='" + date_until_selected + "') "

        Dim query As String = query_c.queryPriceExcelMain(cond, "2")
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCPrice.DataSource = data
        GVPrice.BestFitColumns()
        check_menu()
        Cursor = Cursors.Default
    End Sub

    Private Sub FormMasterPrice_Activated(sender As Object, e As EventArgs) Handles MyBase.Activated
        FormMain.show_rb(Name)
        check_menu()
    End Sub

    Private Sub FormMasterPrice_Deactivate(sender As Object, e As EventArgs) Handles MyBase.Deactivate
        FormMain.hide_rb()
    End Sub


    Sub check_menu()
        If XTCPrice.SelectedTabPageIndex = 0 Then
            SLESeason.Focus()
            If GVBrowsePrice.RowCount < 1 Then
                'hide all except new
                bnew_active = "0"
                bedit_active = "0"
                bdel_active = "0"
                checkFormAccess(Name)
                button_main(bnew_active, bedit_active, bdel_active)
            Else
                'show all
                bnew_active = "0"
                bedit_active = "0"
                bdel_active = "0"
                noManipulating()
            End If
        ElseIf XTCPrice.SelectedTabPageIndex = 1 Then
            If GVPrice.RowCount < 1 Then
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
        End If
    End Sub

    Sub noManipulating()
        If XTCPrice.SelectedTabPageIndex = 0 Then
            Try
                Dim indeks As Integer = GVBrowsePrice.FocusedRowHandle
                If indeks < 0 Then
                    bnew_active = "0"
                    bedit_active = "0"
                    bdel_active = "0"
                Else
                    bnew_active = "0"
                    bedit_active = "0"
                    bdel_active = "0"
                End If
                checkFormAccess(Name)
                button_main(bnew_active, bedit_active, bdel_active)
            Catch ex As Exception
            End Try
        ElseIf XTCPrice.SelectedTabPageIndex = 1 Then
            Try
                Dim indeks As Integer = GVPrice.FocusedRowHandle
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
        End If
    End Sub

    Private Sub GVPrice_FocusedRowChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles GVPrice.FocusedRowChanged
        noManipulating()
    End Sub

    Private Sub GVPrice_DoubleClick(sender As Object, e As EventArgs) Handles GVPrice.DoubleClick
        If GVPrice.FocusedRowHandle >= 0 And GVPrice.RowCount > 0 Then
            FormMain.but_edit()
        End If
    End Sub

    Private Sub XTCPrice_SelectedPageChanged(sender As Object, e As DevExpress.XtraTab.TabPageChangedEventArgs) Handles XTCPrice.SelectedPageChanged
        check_menu()
        If XTCPrice.SelectedTabPageIndex = 0 Then
        ElseIf XTCPrice.SelectedTabPageIndex = 1 Then
        End If
    End Sub

    Private Sub BtnView_Click(sender As Object, e As EventArgs) Handles BtnView.Click
        browsePrice()
    End Sub

    Private Sub GVBrowsePrice_CustomColumnDisplayText(sender As Object, e As DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs) Handles GVBrowsePrice.CustomColumnDisplayText
        If e.Column.FieldName = "no" Then
            e.DisplayText = (e.ListSourceRowIndex + 1).ToString()
        End If
    End Sub

    Private Sub SLESeason_EditValueChanged(sender As Object, e As EventArgs) Handles SLESeason.EditValueChanged
        viewDel()
    End Sub

    Private Sub BtnViewList_Click(sender As Object, e As EventArgs) Handles BtnViewList.Click
        viewPrice()
    End Sub
End Class