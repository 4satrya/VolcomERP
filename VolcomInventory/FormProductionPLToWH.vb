Public Class FormProductionPLToWH 
    Dim bnew_active As String = "1"
    Dim bedit_active As String = "1"
    Dim bdel_active As String = "1"
    Dim product_image_path As String = get_setup_field("pic_path_product") & "\"

    'Form Load
    Private Sub FormProductionPLToWH_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        viewPL()
        view_sample_purc()
        'viewSampleReq()
    End Sub

    Sub showMyToolHint()
        ToolTipControllerNew.HideHint()
        ToolTipControllerNew.ShowHint("Double click to see PL number.", GCListProduct, DevExpress.Utils.ToolTipLocation.RightCenter)
    End Sub
    'Activated/DeadActivated
    Private Sub FormProductionPLToWH_Activated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Activated
        FormMain.show_rb(Name)
        checkFormAccess(Name)
        button_main(bnew_active, bedit_active, bdel_active)
    End Sub
    Private Sub FormProductionPLToWH_Deactivate(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Deactivate
        FormMain.hide_rb()
    End Sub
    'View Data
    'View Packing List
    Sub viewPL()
        Dim query As String = "SELECT ssd.id_season, ssd.season, k.pl_category, i.prod_order_number, dsg.design_code AS `code`, dsg.design_display_name AS `name`, a.id_pl_prod_order ,a.id_comp_contact_from , a.id_comp_contact_to, a.pl_prod_order_note, a.pl_prod_order_number, "
        query += "CONCAT(d.comp_number,' - ',d.comp_name) AS comp_name_from, CONCAT(f.comp_number,' - ',f.comp_name) AS comp_name_to, h.report_status, a.id_report_status, "
        query += "pl_prod_order_date, a.id_pd_alloc, pd_alloc.pd_alloc, det.total "
        query += "FROM tb_pl_prod_order a "
        query += "INNER JOIN tb_m_comp_contact c ON a.id_comp_contact_from = c.id_comp_contact "
        query += "INNER JOIN tb_m_comp d ON c.id_comp = d.id_comp "
        query += "INNER JOIN tb_m_comp_contact e ON a.id_comp_contact_to = e.id_comp_contact "
        query += "INNER JOIN tb_m_comp f ON e.id_comp = f.id_comp "
        query += "INNER JOIN tb_lookup_report_status h ON h.id_report_status = a.id_report_status "
        query += "INNER JOIN tb_prod_order i ON a.id_prod_order = i.id_prod_order 
        INNER JOIN tb_prod_demand_design pd_dsg ON pd_dsg.id_prod_demand_design = i.id_prod_demand_design
        INNER JOIN tb_m_design dsg ON dsg.id_design = pd_dsg.id_design "
        query += "INNER JOIN tb_lookup_pl_category k ON k.id_pl_category = a.id_pl_category "
        query += "LEFT JOIN tb_lookup_pd_alloc pd_alloc ON pd_alloc.id_pd_alloc = a.id_pd_alloc "
        query += "INNER JOIN tb_season_delivery del ON del.id_delivery = i.id_delivery "
        query += "INNER JOIN tb_season ss ON ss.id_season = del.id_season 
        INNER JOIN tb_season ssd ON ssd.id_season = dsg.id_season "
        query += "LEFT JOIN(
        SELECT pld.id_pl_prod_order, SUM(pld.pl_prod_order_det_qty) AS `total`
        FROM tb_pl_prod_order_det pld
        GROUP BY pld.id_pl_prod_order
        ) det ON det.id_pl_prod_order = a.id_pl_prod_order "
        query += "ORDER BY a.id_pl_prod_order DESC "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCPL.DataSource = data
        check_menu()
    End Sub
    Sub viewSampleReq()
        ''get id role super admin & role user
        'Dim id_super_admin As String = execute_query("SELECT id_role_super_admin FROM tb_opt", 0, True, "", "", "", "")
        'Dim query As String = ""
        'query += "SELECT a.id_prod_order, a.prod_order_date, a.prod_order_duration, "
        'query += "a.prod_order_note, a.prod_order_number, (c.comp_name) AS comp_from, (c.id_comp) AS id_comp_to, "
        'query += "f.report_status, a.id_report_status "
        'query += "FROM tb_prod_order a "
        'query += "INNER JOIN tb_m_comp_contact b ON a.id_comp_contact_from = b.id_comp_contact  "
        'query += "INNER JOIN tb_m_comp c ON b.id_comp = c.id_comp  "
        'query += "INNER JOIN tb_lookup_report_status f ON a.id_report_status = f.id_report_status "
        'query += "INNER JOIN tb_prod_order_det g ON g.id_prod_order = a.id_prod_order "
        'query += "WHERE a.id_report_status > '2' AND a.id_report_status !='5' "
        'query += "GROUP BY a.id_prod_order ORDER BY a.id_prod_order ASC "
        'Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        'GCReq.DataSource = data
        'If data.Rows.Count > 0 Then
        '    viewDetailReq()
        'End If
        'check_menu()
    End Sub
    Sub viewDetailReq()
        ''get id role super admin & role user
        'Dim id_super_admin As String = execute_query("SELECT id_role_super_admin FROM tb_opt", 0, True, "", "", "", "")
        'Dim id_comp_param As String = ""
        'If id_role_login <> id_super_admin Then
        '    id_comp_param = id_comp_user
        'Else
        '    id_comp_param = "0"
        'End If
        'Dim id_prod_order As String = GVReq.GetFocusedRowCellDisplayText("id_prod_order").ToString
        'Dim query As String = "CALL view_sample_req_det_limit('" + id_prod_order + "', '0')"
        'Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        'GCRetDetail.DataSource = data
        'viewPLSrs()
    End Sub
    Sub viewPLSrs()
        'Dim id_srs_det As String = GVRetDetail.GetFocusedRowCellValue("id_prod_order_det")
        'Dim query As String = "CALL view_pl_prod_order_srs('" + id_srs_det + "')"
        'Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        'GCCreatedPLDetail.DataSource = data
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
            ToolTipControllerNew.HideHint()
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
                checkFormAccess(Name)
                button_main(bnew_active, bedit_active, bdel_active)
            End If
            showMyToolHint()
        End If
    End Sub

    Private Sub XTCPL_SelectedPageChanged(ByVal sender As System.Object, ByVal e As DevExpress.XtraTab.TabPageChangedEventArgs) Handles XTCPL.SelectedPageChanged
        check_menu()
    End Sub


    '===========TAB INFO PL===================
    Sub view_sample_purc()
        Dim query = "SELECT "
        query += "a.id_prod_order,d.id_sample, a.prod_order_number, d.design_display_name,d.design_name , d.design_code, d.design_cop, IFNULL(d.id_cop_status,0) AS `id_cop_status`, h.term_production, g.po_type, "
        query += "DATE_FORMAT(a.prod_order_date,'%d %M %Y') AS prod_order_date,a.id_report_status,c.report_status, "
        query += "b.id_design,b.id_delivery, e.delivery, f.season, e.id_season, "
        query += "prod_order_date, "
        query += "(DATE_ADD(a.prod_order_date,INTERVAL a.prod_order_lead_time DAY)) AS prod_order_lead_time, "
        query += "(SELECT COUNT(tb_pl_prod_order.id_pl_prod_order) FROM tb_pl_prod_order "
        query += "  WHERE tb_pl_prod_order.id_prod_order = a.id_prod_order "
        query += "  AND tb_pl_prod_order.id_report_status != '5' "
        query += ") AS pl_created "
        query += "FROM tb_prod_order a "
        query += "INNER JOIN tb_prod_demand_design b ON a.id_prod_demand_design = b.id_prod_demand_design "
        query += "INNER JOIN tb_lookup_report_status c ON a.id_report_status = c.id_report_status "
        query += "INNER JOIN tb_m_design d ON b.id_design = d.id_design "
        query += "INNER JOIN tb_season_delivery e ON b.id_delivery=e.id_delivery "
        query += "INNER JOIN tb_season f ON f.id_season=e.id_season "
        query += "INNER JOIN tb_lookup_po_type g ON g.id_po_type=a.id_po_type "
        query += "INNER JOIN tb_lookup_term_production h ON h.id_term_production=a.id_term_production "
        query += "WHERE a.id_report_status = '6' "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        data.Columns.Add("images", GetType(Image))

        GCProd.DataSource = data
        'GVProd.ActiveFilterString = "[pl_created]=0 "
        If GVProd.RowCount > 0 Then
            'show all
            view_list_purchase("-1")
        End If
    End Sub
    Sub view_list_purchase(ByVal id_prod_order As String)
        Dim id_po As String = "-1"
        Try
            id_po = GVProd.GetFocusedRowCellValue("id_prod_order").ToString
        Catch ex As Exception
        End Try
        Dim query = "CALL view_stock_prod_rec('" + id_po + "', '0', '0', '0', '0','0', '0')"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCListProduct.DataSource = data
    End Sub

    Private Sub GVProd_FocusedRowChanged(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles GVProd.FocusedRowChanged
        Dim id_po As String = "-1"
        Try
            id_po = GVProd.GetFocusedRowCellValue("id_prod_order").ToString
        Catch ex As Exception
        End Try
        view_list_purchase(id_po)
        showMyToolHint()
    End Sub
    Private Sub GVProd_RowClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Grid.RowClickEventArgs) Handles GVProd.RowClick

    End Sub

    Private Sub GVListPurchase_CustomColumnDisplayText(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs) Handles GVListProduct.CustomColumnDisplayText
        If e.Column.FieldName = "no" Then
            e.DisplayText = (e.ListSourceRowIndex + 1).ToString()
        End If
    End Sub

    Private Sub GVProd_CustomColumnDisplayText(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs) Handles GVProd.CustomColumnDisplayText
        If e.Column.FieldName = "id_delivery" Then
            Dim rowhandle As Integer = e.ListSourceRowIndex
            If GVProd.IsGroupRow(rowhandle) Then
                rowhandle = GVProd.GetDataRowHandleByGroupRowHandle(rowhandle)
                e.DisplayText = GVProd.GetRowCellDisplayText(rowhandle, "delivery")
            End If
        End If
        If e.Column.FieldName = "id_season" Then
            Dim rowhandle As Integer = e.ListSourceRowIndex
            If GVProd.IsGroupRow(rowhandle) Then
                rowhandle = GVProd.GetDataRowHandleByGroupRowHandle(rowhandle)
                e.DisplayText = GVProd.GetRowCellDisplayText(rowhandle, "season")
            End If
        End If
    End Sub

    Private Sub GVProd_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GVProd.DoubleClick
        If GVProd.RowCount > 0 Then
            GVPL.ApplyFindFilter(GVProd.GetFocusedRowCellValue("prod_order_number").ToString)
            XTCPL.SelectedTabPageIndex = 0
            check_menu()
        End If
    End Sub

    Private Sub GVListProduct_FocusedRowChanged(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles GVListProduct.FocusedRowChanged
        showMyToolHint()
    End Sub

    Private Sub GVListProduct_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GVListProduct.DoubleClick
        Cursor = Cursors.WaitCursor
        Try
            Dim id_prod_order_det As String = GVListProduct.GetFocusedRowCellValue("id_prod_order_det").ToString
            Dim query As String = "SELECT b.pl_prod_order_number FROM tb_pl_prod_order_det a "
            query += "INNER JOIN tb_pl_prod_order b ON a.id_pl_prod_order = b.id_pl_prod_order "
            query += "WHERE a.id_prod_order_det = '" + id_prod_order_det + "' "
            Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
            Dim filter_str As String = ""
            For i As Integer = 0 To (data.Rows.Count - 1)
                If i > 0 Then
                    filter_str += "OR "
                End If
                filter_str += "[pl_prod_order_number] = '" + toDoubleQuote(data.Rows(i)("pl_prod_order_number").ToString) + "' "
            Next
            If filter_str <> "" Then
                GVPL.ApplyFindFilter("")
                GVPL.ActiveFilterString = filter_str
                XTCPL.SelectedTabPageIndex = 0
            Else
                stopCustom("This item not found in packing list data")
            End If
        Catch ex As Exception

        End Try
        Cursor = Cursors.Default
    End Sub

    Private Sub XTCPL_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles XTCPL.Click

    End Sub

    Private Sub GVPL_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GVPL.DoubleClick
        If GVPL.RowCount > 0 Then
            If GVPL.FocusedRowHandle >= 0 Then
                FormMain.but_edit()
            End If
        End If
    End Sub
End Class