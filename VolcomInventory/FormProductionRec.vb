Public Class FormProductionRec 
    Dim bnew_active As String = "1"
    Dim bedit_active As String = "1"
    Dim bdel_active As String = "1"
    Dim bcontact_active As String = "1"
    Dim product_image_path As String = get_setup_field("pic_path_product") & "\"

    Private Sub FormProductionRec_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        view_prod_order_rec()
        view_prod_order()
    End Sub
    Sub showMyToolHint()
        ToolTipControllerNew.HideHint()
        ToolTipControllerNew.ShowHint("Double click to see receiving number.", GCListProd, DevExpress.Utils.ToolTipLocation.RightCenter)
    End Sub
    Sub view_prod_order_rec()
        Dim query = "SELECT a.id_report_status,h.report_status, g.id_season,g.season,a.id_prod_order_rec,a.prod_order_rec_number, "
        query += "(a.delivery_order_date) AS delivery_order_date,a.delivery_order_number, a.arrive_date,b.prod_order_number, "
        query += "(a.prod_order_rec_date) AS prod_order_rec_date, CONCAT(f.comp_number,' - ',f.comp_name) AS comp_from, CONCAT(d.comp_number,' - ',d.comp_name) AS comp_to, dsg.design_code AS `code`,(dsg.design_display_name) AS name, SUM(ad.prod_order_rec_det_qty) AS `qty`, po_type.po_type "
        query += "FROM tb_prod_order_rec a  "
        query += "INNER JOIN tb_prod_order_rec_det ad ON ad.id_prod_order_rec = a.id_prod_order_rec "
        query += "INNER JOIN tb_prod_order b ON a.id_prod_order=b.id_prod_order "
        query += "INNER JOIN tb_m_comp_contact c ON c.id_comp_contact = a.id_comp_contact_to "
        query += "INNER JOIN tb_m_comp d ON d.id_comp = c.id_comp "
        query += "INNER JOIN tb_m_comp_contact e ON e.id_comp_contact = a.id_comp_contact_from  "
        query += "INNER JOIN tb_m_comp f ON f.id_comp = e.id_comp "
        query += "INNER JOIN tb_season_delivery i ON b.id_delivery = i.id_delivery "
        query += "INNER JOIN tb_season g ON g.id_season = i.id_season "
        query += "INNER JOIN tb_lookup_report_status h ON h.id_report_status = a.id_report_status "
        query += "INNER JOIN tb_prod_demand_design pd_dsg ON pd_dsg.id_prod_demand_design = b.id_prod_demand_design "
        query += "INNER JOIN tb_m_design dsg ON dsg.id_design = pd_dsg.id_design "
        query += "INNER JOIN tb_lookup_po_type po_type ON po_type.id_po_type = b.id_po_type "
        query += "GROUP BY a.id_prod_order_rec "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCProdRec.DataSource = data
        If data.Rows.Count > 0 Then
            GVProdRec.FocusedRowHandle = 0
        End If
        check_menu()
    End Sub

    Private Sub FormProductionRec_FormClosed(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub FormProductionRec_Activated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Activated
        FormMain.show_rb(Name)
        checkFormAccess(Name)
        button_main(bnew_active, bedit_active, bdel_active)
    End Sub

    Private Sub FormProductionRec_Deactivate(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Deactivate
        FormMain.hide_rb()
    End Sub

    Sub check_menu()
        If XTCTabReceive.SelectedTabPageIndex = 0 Then
            'based on receive
            If GVProdRec.RowCount < 1 Then
                'hide all except new
                bnew_active = "1"
                bedit_active = "0"
                bdel_active = "0"
                checkFormAccess(Name)
                button_main(bnew_active, bedit_active, bdel_active)
                '
            Else
                'show all
                bnew_active = "1"
                bedit_active = "1"
                bdel_active = "1"
                checkFormAccess(Name)
                button_main(bnew_active, bedit_active, bdel_active)
                '
            End If
            ToolTipControllerNew.HideHint()
        ElseIf XTCTabReceive.SelectedTabPageIndex = 1 Then
            'based on PO
            If GVProd.RowCount < 1 Then
                'hide all
                bnew_active = "0"
                bedit_active = "0"
                bdel_active = "0"
                checkFormAccess(Name)
                button_main(bnew_active, bedit_active, bdel_active)
                '
            Else
                'show all
                bnew_active = "1"
                bedit_active = "0"
                bdel_active = "0"
                checkFormAccess(Name)
                button_main(bnew_active, bedit_active, bdel_active)
                '
            End If
            showMyToolHint()
        End If
    End Sub


    Sub view_prod_order()
        Dim query = "SELECT "
        query += "NOW() as date_now,b.id_design,a.id_prod_order,d.id_sample, a.prod_order_number, d.design_display_name,d.design_name , d.design_code, h.term_production, g.po_type, "
        query += "DATE_FORMAT(a.prod_order_date,'%d %M %Y') AS prod_order_date,a.id_report_status,c.report_status, "
        query += "b.id_delivery, e.delivery, f.season, e.id_season, "
        query += "DATE_FORMAT(a.prod_order_date,'%d %M %Y') AS prod_order_date, "
        query += "DATE_FORMAT(DATE_ADD(a.prod_order_date,INTERVAL a.prod_order_lead_time DAY),'%d %M %Y') AS prod_order_lead_time, "
        query += "(SELECT COUNT(tb_prod_order_rec.id_prod_order_rec) FROM tb_prod_order_rec "
        query += "  WHERE tb_prod_order_rec.id_prod_order = a.id_prod_order "
        query += "  AND tb_prod_order_rec.id_report_status != '5' "
        query += ") AS receive_created, "
        query += "DATE_FORMAT(DATE_ADD(a.prod_order_date,INTERVAL a.prod_order_lead_time DAY),'%d %M %Y') AS prod_order_lead_time "
        query += "FROM tb_prod_order a "
        query += "INNER JOIN tb_prod_demand_design b ON a.id_prod_demand_design = b.id_prod_demand_design "
        query += "INNER JOIN tb_lookup_report_status c ON a.id_report_status = c.id_report_status "
        query += "INNER JOIN tb_m_design d ON b.id_design = d.id_design "
        query += "INNER JOIN tb_season_delivery e ON b.id_delivery=e.id_delivery "
        query += "INNER JOIN tb_season f ON f.id_season=e.id_season "
        query += "INNER JOIN tb_lookup_po_type g ON g.id_po_type=a.id_po_type "
        query += "INNER JOIN tb_lookup_term_production h ON h.id_term_production=a.id_term_production "
        query += "WHERE a.id_report_status = '3' OR a.id_report_status = '4' ORDER BY a.id_prod_order ASC "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCProd.DataSource = data
        If data.Rows.Count > 0 Then
            GVProd.FocusedRowHandle = 0
            view_list_prod(GVProd.GetFocusedRowCellValue("id_prod_order"))
        End If
        check_menu()
    End Sub

    Sub view_list_prod(ByVal id_prod_order As String)
        Dim query = "CALL view_prod_order_det('" & id_prod_order & "', '0')"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCListProd.DataSource = data
    End Sub

    Private Sub XTCTabReceive_SelectedPageChanged(ByVal sender As System.Object, ByVal e As DevExpress.XtraTab.TabPageChangedEventArgs) Handles XTCTabReceive.SelectedPageChanged
        check_menu()
    End Sub

    Private Sub GVProd_FocusedRowChanged(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles GVProd.FocusedRowChanged
        Dim focusedRowHandle As Integer = -1
        If e.FocusedRowHandle = DevExpress.XtraGrid.GridControl.NewItemRowHandle OrElse e.FocusedRowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            Return
        End If
        Dim view As DevExpress.XtraGrid.Views.Grid.GridView = CType(sender, DevExpress.XtraGrid.Views.Grid.GridView)
        If e.FocusedRowHandle < 0 Then
            If e.PrevFocusedRowHandle = DevExpress.XtraGrid.GridControl.InvalidRowHandle Then
                focusedRowHandle = 0
            ElseIf Control.MouseButtons = MouseButtons.Left OrElse Control.MouseButtons = MouseButtons.Right Then
                focusedRowHandle = e.PrevFocusedRowHandle
            Else
                Dim prevRow As Integer = view.GetVisibleIndex(e.PrevFocusedRowHandle)
                Dim currRow As Integer = view.GetVisibleIndex(e.FocusedRowHandle)
                If prevRow > currRow Then
                    focusedRowHandle = e.PrevFocusedRowHandle - 1
                Else
                    focusedRowHandle = e.PrevFocusedRowHandle + 1
                End If
                If focusedRowHandle < 0 Then
                    focusedRowHandle = 0
                End If
                If focusedRowHandle >= view.DataRowCount Then
                    focusedRowHandle = view.DataRowCount - 1
                End If
            End If
            If focusedRowHandle < 0 Then
                view.FocusedRowHandle = 0
            Else
                view.FocusedRowHandle = focusedRowHandle
            End If
        End If
        view_list_prod(GVProd.GetFocusedRowCellValue("id_prod_order").ToString)
        showMyToolHint()
    End Sub

    Private Sub GVProd_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GVProd.DoubleClick
        If GVProd.RowCount > 0 Then
            GVProdRec.ApplyFindFilter(GVProd.GetFocusedRowCellValue("prod_order_number").ToString)
            XTCTabReceive.SelectedTabPageIndex = 0
            check_menu()
        End If
    End Sub

    Private Sub GVProd_RowCellStyle(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs) Handles GVProd.RowCellStyle
        Dim View As DevExpress.XtraGrid.Views.Grid.GridView = sender

        Dim date_now As Date
        Dim date_rec As Date

        If e.Column.FieldName = "prod_order_lead_time" Then
            date_now = Date.Parse(View.GetRowCellDisplayText(e.RowHandle, View.Columns("date_now")))
            date_rec = Date.Parse(View.GetRowCellDisplayText(e.RowHandle, View.Columns("prod_order_lead_time")))
            'And View.GetRowCellDisplayText(e.RowHandle, View.Columns("qty_receive")) <= 0
            If date_now > date_rec Then
                e.Appearance.BackColor = Color.Red
                e.Appearance.BackColor2 = Color.LightSalmon
            End If
        End If
    End Sub

    Private Sub GVProd_RowClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Grid.RowClickEventArgs) Handles GVProd.RowClick

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

    Private Sub GCListProd_MouseHover(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GCListProd.MouseHover
       
    End Sub

    Private Sub GVListProd_FocusedRowChanged(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles GVListProd.FocusedRowChanged
        showMyToolHint()
    End Sub

    Private Sub GVListProd_CustomColumnDisplayText(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs) Handles GVListProd.CustomColumnDisplayText
        If e.Column.FieldName = "no" Then
            e.DisplayText = (e.ListSourceRowIndex + 1).ToString()
        End If
    End Sub

    Private Sub GVListProd_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GVListProd.DoubleClick
        Cursor = Cursors.WaitCursor
        Try
            Dim id_prod_order_det As String = GVListProd.GetFocusedRowCellValue("id_prod_order_det").ToString
            Dim query As String = "SELECT b.prod_order_rec_number FROM tb_prod_order_rec_det a "
            query += "INNER JOIN tb_prod_order_rec b ON a.id_prod_order_rec = b.id_prod_order_rec "
            query += "WHERE a.id_prod_order_det = '" + id_prod_order_det + "' "
            Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
            Dim filter_str As String = ""
            For i As Integer = 0 To (data.Rows.Count - 1)
                If i > 0 Then
                    filter_str += "OR "
                End If
                filter_str += "[prod_order_rec_number] = '" + toDoubleQuote(data.Rows(i)("prod_order_rec_number").ToString) + "' "
            Next
            GVProdRec.ApplyFindFilter("")
            GVProdRec.ActiveFilterString = filter_str
            XTCTabReceive.SelectedTabPageIndex = 0
        Catch ex As Exception

        End Try
        Cursor = Cursors.Default
    End Sub

    Private Sub GVProdRec_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GVProdRec.DoubleClick
        Cursor = Cursors.WaitCursor
        If GVProdRec.RowCount > 0 And GVProdRec.FocusedRowHandle >= 0 Then
            FormMain.but_edit()
        End If
        Cursor = Cursors.Default
    End Sub

    Private Sub GVProdRec_FocusedRowChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles GVProdRec.FocusedRowChanged
        noManipulating()
    End Sub

    Sub noManipulating()
        Try
            Dim indeks As Integer = GVProdRec.FocusedRowHandle
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
End Class