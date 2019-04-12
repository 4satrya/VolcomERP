Public Class FormProductionPLToWHRec 
    Dim bnew_active As String = "1"
    Dim bedit_active As String = "1"
    Dim bdel_active As String = "1"
    Dim product_image_path As String = get_setup_field("pic_path_product") & "\"

    'Form Load
    Private Sub FormProductionPLToWHRec_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim dt_now As DateTime = getTimeDB()
        DEFrom.EditValue = dt_now
        DEUntil.EditValue = dt_now

        'list PL
        view_sample_purc()
    End Sub

    'Activated/DeadActivated
    Private Sub FormProductionPLToWHRec_Activated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Activated
        FormMain.show_rb(Name)
        checkFormAccess(Name)
        button_main(bnew_active, bedit_active, bdel_active)
    End Sub

    Private Sub FormProductionPLToWHRec_Deactivate(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Deactivate
        FormMain.hide_rb()
    End Sub
    'View Data
    'View Packing List
    Sub viewPL()
        Cursor = Cursors.WaitCursor

        'Prepare paramater
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


        Dim query_c As ClassProductionPLToWHRec = New ClassProductionPLToWHRec()
        Dim query As String = query_c.queryMain("AND (a0.pl_prod_order_rec_date>='" + date_from_selected + "' AND a0.pl_prod_order_rec_date<='" + date_until_selected + "') ", "2")
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCPL.DataSource = data
        GVPL.BestFitColumns()
        check_menu()
        Cursor = Cursors.Default
    End Sub

    Private Sub GVPL_CustomColumnDisplayText(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs) Handles GVPL.CustomColumnDisplayText
        If e.Column.FieldName = "no" Then
            e.DisplayText = (e.ListSourceRowIndex + 1).ToString()
        End If
    End Sub

    Private Sub GVPL_RowClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Grid.RowClickEventArgs) Handles GVPL.RowClick
        noManipulating()
    End Sub

    Private Sub GVPL_FocusedRowChanged(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles GVPL.FocusedRowChanged
        noManipulating()
    End Sub

    Sub noManipulating()
        Try
            If XTCPL.SelectedTabPageIndex = 0 Then
                Dim indeks As Integer = GVPL.FocusedRowHandle
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
            ElseIf XTCPL.SelectedTabPageIndex = 1 Then
                Dim indeks As Integer = GVProd.FocusedRowHandle
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
        Catch ex As Exception
        End Try
    End Sub

    Sub check_menu()
        If XTCPL.SelectedTabPageIndex = 0 Then
            'based on receive
            If GVPL.RowCount < 1 Then
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
        ElseIf XTCPL.SelectedTabPageIndex = 1 Then
            'based on PO
            If GVProd.RowCount < 1 Then
                'hide all
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
        End If
    End Sub

    Private Sub XTCPL_SelectedPageChanged(ByVal sender As System.Object, ByVal e As DevExpress.XtraTab.TabPageChangedEventArgs) Handles XTCPL.SelectedPageChanged
        check_menu()
    End Sub

    '=================Tab REC Waiting===========================
    Sub view_sample_purc()
        Dim query = "Select "
        query += "a.id_pl_prod_order,d.id_sample, a.pl_prod_order_number, d.design_display_name,d.design_name , d.design_code, IFNULL(ad.total_qty,0) AS `total_qty`, g.pl_category, "
        query += "(a.pl_prod_order_date) As pl_prod_order_date, a.id_report_status,c.report_status, "
        query += "d.id_design,b.id_delivery, e.delivery, f.season, e.id_season, "
        query += "a.id_comp_contact_from, a.id_comp_contact_to, (i.comp_name) As comp_name_to, (i.comp_number) As comp_number_to, (k.comp_name) As comp_name_from, (k.comp_number) As comp_number_from, "
        query += "alloc.id_pd_alloc, alloc.pd_alloc "
        query += "FROM tb_pl_prod_order a 
        LEFT JOIN (
	        SELECT pl.id_pl_prod_order, SUM(pld.pl_prod_order_det_qty) AS `total_qty`
	        FROM tb_pl_prod_order_det pld
	        INNER JOIN tb_pl_prod_order pl ON pl.id_pl_prod_order = pld.id_pl_prod_order
	        WHERE pl.id_report_status=6
	        GROUP BY pl.id_pl_prod_order
        ) ad ON ad.id_pl_prod_order = a.id_pl_prod_order "
        query += "INNER JOIN tb_m_comp_contact h On h.id_comp_contact = a.id_comp_contact_to "
        query += "INNER JOIN tb_m_comp i On h.id_comp = i.id_comp "
        query += "INNER JOIN tb_m_comp_contact j On j.id_comp_contact = a.id_comp_contact_from "
        query += "INNER JOIN tb_m_comp k On k.id_comp = j.id_comp "
        query += "INNER JOIN tb_prod_order a1 On a.id_prod_order = a1.id_prod_order "
        query += "INNER JOIN tb_prod_demand_design b On a1.id_prod_demand_design = b.id_prod_demand_design "
        query += "INNER JOIN tb_lookup_report_status c On a.id_report_status = c.id_report_status "
        query += "INNER JOIN tb_m_design d On b.id_design = d.id_design "
        query += "INNER JOIN tb_season_delivery e On b.id_delivery=e.id_delivery "
        query += "INNER JOIN tb_season f On f.id_season=e.id_season "
        query += "INNER JOIN tb_lookup_pl_category g On g.id_pl_category = a.id_pl_category "
        query += "LEFT JOIN tb_pl_prod_order_rec z On a.id_pl_prod_order = z.id_pl_prod_order And z.id_report_status!='5' "
        query += "LEFT JOIN tb_lookup_pd_alloc alloc ON alloc.id_pd_alloc = a.id_pd_alloc "
        query += "WHERE (a.id_report_status = '6') AND ISNULL(z.id_pl_prod_order_rec) AND i.id_departement ='" + id_departement_user + "' "
        query += "ORDER BY a.id_pl_prod_order ASC "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCProd.DataSource = data
        GVProd.BestFitColumns()
        check_menu()

        Dim id_pl_prod_order_param As String = "-1"
        Try
            id_pl_prod_order_param = GVProd.GetFocusedRowCellValue("id_pl_prod_order").ToString
        Catch ex As Exception
        End Try
        view_list_purchase(id_pl_prod_order_param)
    End Sub
    Sub view_list_purchase(ByVal id_pl_prod_order As String)
        Try
            Dim query = "CALL view_pl_prod('" + id_pl_prod_order + "', '0', '0')"
            Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
            GCListProduct.DataSource = data
        Catch ex As Exception
            errorConnection()
        End Try
    End Sub

    Private Sub GVProd_FocusedRowChanged(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles GVProd.FocusedRowChanged
        noManipulating()
        Dim id_pl_prod_orderx As String = "-1"
        Try
            id_pl_prod_orderx = GVProd.GetFocusedRowCellValue("id_pl_prod_order").ToString
        Catch ex As Exception

        End Try
        view_list_purchase(id_pl_prod_orderx)
    End Sub

    Private Sub GVListPurchase_CustomColumnDisplayText(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs) Handles GVListProduct.CustomColumnDisplayText
        If e.Column.FieldName = "no" Then
            e.DisplayText = (e.ListSourceRowIndex + 1).ToString()
        End If
    End Sub

    Private Sub GVProd_ColumnFilterChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GVProd.ColumnFilterChanged
        Dim id_pl_prod_orderx As String = "-1"
        Try
            id_pl_prod_orderx = GVProd.GetFocusedRowCellValue("id_pl_prod_order").ToString
        Catch ex As Exception

        End Try
        view_list_purchase(id_pl_prod_orderx)
    End Sub

    Private Sub GVPL_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GVPL.DoubleClick
        If GVPL.RowCount > 0 Then
            Cursor = Cursors.WaitCursor
            FormMain.but_edit()
            Cursor = Cursors.Default
        End If
    End Sub

    Private Sub GVPL_PopupMenuShowing(sender As Object, e As DevExpress.XtraGrid.Views.Grid.PopupMenuShowingEventArgs) Handles GVPL.PopupMenuShowing
        If GVPL.RowCount > 0 And GVPL.FocusedRowHandle >= 0 Then
            Dim id_stt As String = GVPL.GetFocusedRowCellValue("id_report_status").ToString
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
        FormProductionPLToWHRecDet.id_pre = "1"
        FormMain.but_edit()
        Cursor = Cursors.Default
    End Sub

    Private Sub SMPrint_Click(sender As Object, e As EventArgs) Handles SMPrint.Click
        Cursor = Cursors.WaitCursor
        FormProductionPLToWHRecDet.id_pre = "2"
        FormMain.but_edit()
        Cursor = Cursors.Default
    End Sub

    Private Sub BtnView_Click(sender As Object, e As EventArgs) Handles BtnView.Click
        viewPL()
    End Sub
End Class