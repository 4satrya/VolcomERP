Public Class FormMatPurchase
    Dim bnew_active As String = "1"
    Dim bedit_active As String = "1"
    Dim bdel_active As String = "1"

    Private Sub FormMatPurchase_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        DEStart.EditValue = Now
        DEEnd.EditValue = Now
        '
        viewSeason()
        view_mat_purc()
        '
        viewVendorKO()
        'GVMatPurchase.ActiveFilterString = "[id_mat_purc] > 1 AND [id_mat_purc] < 6"
        viewProdDemand()
    End Sub

    Sub viewVendorKO()
        Dim query As String = ""
        query += "SELECT ('0') AS id_comp, ('-') AS comp_number, ('All Vendor') AS comp_name, ('ALL Vendor') AS comp_name_label UNION ALL "
        query += "SELECT comp.id_comp,comp.comp_number, comp.comp_name, CONCAT_WS(' - ', comp.comp_number,comp.comp_name) AS comp_name_label FROM tb_m_comp comp "
        query += "WHERE comp.id_comp_cat='1'"
        viewSearchLookupQuery(SLEVendorKO, query, "id_comp", "comp_name_label", "id_comp")
    End Sub

    Private Sub viewSeason()
        Dim query As String = "SELECT '0' as id_season,'All season' AS season UNION (SELECT id_season,season FROM tb_season ORDER BY id_season DESC)"
        viewSearchLookupQuery(LESeason, query, "id_season", "season", "id_season")
    End Sub
    Private Sub FormMatPurchase_Activated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Activated
        FormMain.show_rb(Name)
        checkFormAccess(Name)
    End Sub

    Private Sub FormMatPurchase_Deactivate(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Deactivate
        FormMain.hide_rb()
    End Sub
    Sub view_mat_purc()
        Dim query_where As String = ""
        If Not LESeason.EditValue.ToString = "0" Then
            query_where += " AND del.id_season='" & LESeason.EditValue.ToString & "'"
        End If

        Dim query = "SELECT '' AS `no`,a.mat_purc_vat as vat,'no' AS is_check,IFNULL(rev.mat_purc_number,'-') AS mat_purc_rev_number,a.id_report_status,h.report_status,a.id_mat_purc, 
DATE_ADD(a.`mat_purc_date`,INTERVAL a.`mat_purc_lead_time` DAY) AS est_del_date,a.id_comp_contact_to AS id_comp_contact,d.id_comp AS id_comp,
DATE_ADD(a.`mat_purc_date`,INTERVAL (a.`mat_purc_lead_time`+a.`mat_purc_top`) DAY) AS payment_due_date,
a.`mat_purc_lead_time` AS lead_time,a.`mat_purc_top` AS top,
b.id_season,a.id_delivery,i.delivery, rang.`range`,
b.season, g.payment,
d.comp_name AS comp_name_to,  d.`comp_number` AS comp_number_to,
f.comp_name AS comp_name_ship_to, 
a.mat_purc_number,
a.mat_purc_date, del.`id_season`, 
DATE_ADD(a.mat_purc_date,INTERVAL a.mat_purc_lead_time DAY) AS mat_purc_lead_time, 
DATE_ADD(a.mat_purc_date,INTERVAL (a.mat_purc_top+a.mat_purc_lead_time) DAY) AS mat_purc_top 
,cur.`currency` AS po_curr,a.`mat_purc_kurs` AS po_kurs
,SUM(mpd.`mat_purc_det_price` * mpd.`mat_purc_det_qty`)* ((100 + a.mat_purc_vat)/100) AS po_amount
,SUM(mpd.`mat_purc_det_qty`) AS qty_order
,SUM(IF(a.`id_currency`=1,1,a.`mat_purc_kurs`) * mpd.`mat_purc_det_price` * mpd.`mat_purc_det_qty`) * ((100 + a.mat_purc_vat)/100) AS po_amount_rp
,uom.`uom`
FROM tb_mat_purc a INNER JOIN tb_season_delivery i ON a.id_delivery = i.id_delivery 
INNER JOIN tb_season b ON i.id_season = b.id_season 
INNER JOIN tb_m_comp_contact c ON a.id_comp_contact_to = c.id_comp_contact 
INNER JOIN tb_m_comp d ON c.id_comp = d.id_comp 
INNER JOIN tb_m_comp_contact e ON a.id_comp_contact_ship_to = e.id_comp_contact 
INNER JOIN tb_m_comp f ON e.id_comp = f.id_comp 
INNER JOIN tb_lookup_payment g ON a.id_payment = g.id_payment 
LEFT JOIN tb_mat_purc rev ON rev.id_mat_purc = a.id_mat_purc_rev 
INNER JOIN tb_lookup_report_status h ON h.id_report_status = a.id_report_status
INNER JOIN `tb_season_delivery` del ON a.`id_delivery`=del.`id_delivery`
INNER JOIN tb_season ssn ON ssn.`id_season`=del.`id_season`
INNER JOIN `tb_range` rang ON rang.id_range=ssn.id_range
INNER JOIN tb_mat_purc_det mpd ON mpd.`id_mat_purc`=a.`id_mat_purc`
INNER JOIN tb_lookup_currency cur ON cur.id_currency=a.id_currency
INNER JOIN tb_m_mat_det_price prc ON prc.`id_mat_det_price`=mpd.`id_mat_det_price`
INNER JOIN tb_m_mat_det md ON md.`id_mat_det`=prc.`id_mat_det`
INNER JOIN tb_m_mat mat ON mat.`id_mat`=md.`id_mat`
INNER JOIN tb_m_uom uom ON uom.`id_uom`=mat.`id_uom`
WHERE 1=1 " & query_where & "
GROUP BY mpd.`id_mat_purc`"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCMatPurchase.DataSource = data
        check_menu()
    End Sub
    Sub check_menu()
        If GVMatPurchase.RowCount < 1 Then
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
    End Sub

    Private Sub GVSamplePurchase_FocusedRowChanged(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles GVMatPurchase.FocusedRowChanged
        no_focus_gv(sender, e)
    End Sub

    Sub no_focus_gv(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs)
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
    End Sub

    Private Sub GVSamplePurchase_CustomColumnDisplayText(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs) Handles GVMatPurchase.CustomColumnDisplayText
        If e.Column.FieldName = "id_delivery" Then
            Dim rowhandle As Integer = e.ListSourceRowIndex
            If GVMatPurchase.IsGroupRow(rowhandle) Then
                rowhandle = GVMatPurchase.GetDataRowHandleByGroupRowHandle(rowhandle)
                e.DisplayText = GVMatPurchase.GetRowCellDisplayText(rowhandle, "delivery")
            End If
        End If
        If e.Column.FieldName = "id_season" Then
            Dim rowhandle As Integer = e.ListSourceRowIndex
            If GVMatPurchase.IsGroupRow(rowhandle) Then
                rowhandle = GVMatPurchase.GetDataRowHandleByGroupRowHandle(rowhandle)
                e.DisplayText = GVMatPurchase.GetRowCellDisplayText(rowhandle, "season")
            End If
        End If
    End Sub
    '========= from PD =============
    Sub viewProdDemand()
        Dim query As String = "SELECT *,c.report_status FROM tb_prod_demand a "
        query += "INNER JOIN tb_season b ON a.id_season = b.id_season "
        query += "INNER JOIN tb_lookup_report_status c ON c.id_report_status = a.id_report_status "
        query += "ORDER BY a.id_prod_demand DESC "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCProdDemand.DataSource = data
        GVProdDemand.Columns("season").GroupIndex = 0
        If data.Rows.Count > 0 Then
            GVProdDemand.FocusedRowHandle = 0
            view_product()
            'show all
            bnew_active = "1"
            bedit_active = "1"
            bdel_active = "1"
        Else
            'hide all except new
            bnew_active = "1"
            bedit_active = "0"
            bdel_active = "0"
        End If
        checkFormAccess(Name)
        button_main(bnew_active, bedit_active, bdel_active)
    End Sub
    Private Sub GVProdDemand_FocusedRowChanged(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles GVProdDemand.FocusedRowChanged
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
    End Sub
    'Row Click Number
    Private Sub GVProdDemand_RowClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Grid.RowClickEventArgs) Handles GVProdDemand.RowClick
        view_product()
        'checkPrintStatus()
    End Sub

    Sub view_product()
        Try
            Dim id_prod_demand As String = GVProdDemand.GetFocusedRowCellDisplayText("id_prod_demand").ToString
            Dim query As String = "CALL view_prod_demand('" & id_prod_demand & "', 0)"
            Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
            GCProduct.DataSource = data
            GVProduct.ClearGrouping()
            GVProduct.Columns("category").GroupIndex = 0
            GVProduct.Columns("design_name").GroupIndex = 1
            GVProduct.ExpandAllGroups()
            '
            If check_print_report_status(GVProdDemand.GetFocusedRowCellDisplayText("id_report_status").ToString) Then
                BCreate.Enabled = True
            Else
                BCreate.Enabled = False
            End If
        Catch ex As Exception
            errorConnection()
        End Try
    End Sub

    Private Sub BCreate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BCreate.Click
        FormProdDemandMat.id_prod_demand = GVProdDemand.GetFocusedRowCellDisplayText("id_prod_demand").ToString
        FormProdDemandMat.is_in_mat = "1"
        FormProdDemandMat.ShowDialog()
    End Sub

    Private Sub GVMatPurchase_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GVMatPurchase.DoubleClick
        If GVMatPurchase.RowCount > 0 Then
            FormMatPurchaseDet.id_purc = GVMatPurchase.GetFocusedRowCellDisplayText("id_mat_purc")
            FormMatPurchaseDet.ShowDialog()
        End If
    End Sub

    Private Sub BSearch_Click(sender As Object, e As EventArgs) Handles BSearch.Click
        view_mat_purc()
    End Sub

    Private Sub BClearFilter_Click(sender As Object, e As EventArgs) Handles BClearFilter.Click
        GVMatPurchase.ActiveFilterString = ""
    End Sub

    Private Sub BFilter_Click(sender As Object, e As EventArgs) Handles BFilter.Click
        GVMatPurchase.ActiveFilterString = "[mat_purc_date] >= #" & Date.Parse(DEStart.EditValue.ToString).ToString("d") & "# AND [mat_purc_date] <= #" & Date.Parse(DEEnd.EditValue.ToString).ToString("d") & "#"
    End Sub

    Private Sub BPrint_Click(sender As Object, e As EventArgs) Handles BPrint.Click
        FormMatPurcSum.dt = GCMatPurchase.DataSource
        FormMatPurcSum.GVProd.ActiveFilterString = "[is_check]='yes'"
        FormMatPurcSum.ShowDialog()
    End Sub

    Private Sub BShowPrintPanel_Click(sender As Object, e As EventArgs) Handles BShowPrintPanel.Click
        PCFilterDate.Visible = True
    End Sub

    Private Sub CheckEditSelAll_CheckedChanged(sender As Object, e As EventArgs) Handles CheckEditSelAll.CheckedChanged
        If GVMatPurchase.RowCount > 0 Then
            For i As Integer = 0 To ((GVMatPurchase.RowCount - 1) - GetGroupRowCount(GVMatPurchase))
                If CheckEditSelAll.Checked = False Then
                    GVMatPurchase.SetRowCellValue(i, "is_check", "no")
                Else
                    GVMatPurchase.SetRowCellValue(i, "is_check", "yes")
                End If
            Next
        End If
    End Sub

    Private Sub BViewKO_Click(sender As Object, e As EventArgs) Handles BViewKO.Click
        Dim query_where As String = ""
        '
        If Not SLEVendorKO.EditValue.ToString = "0" Then
            query_where += " AND c.id_comp='" & SLEVendorKO.EditValue.ToString & "'"
        End If
        '
        Dim query As String = "SELECT ko.*,c.`comp_name` FROM tb_prod_order_ko ko
INNER JOIN tb_m_comp_contact cc ON cc.`id_comp_contact`=ko.`id_comp_contact`
INNER JOIN tb_m_comp c ON c.`id_comp`=cc.`id_comp`
WHERE ko.id_prod_order_ko 
IN (SELECT MAX(id_prod_order_ko) AS id FROM `tb_prod_order_ko`
GROUP BY id_prod_order_ko_reff) AND is_purc_mat=1 " & query_where & " ORDER BY ko.id_prod_order_ko DESC"

        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCKO.DataSource = data
        If GVKO.RowCount > 0 Then
            BEditKO.Visible = True
        Else
            BEditKO.Visible = False
        End If
        GVKO.BestFitColumns()
    End Sub

    Private Sub BEditKO_Click(sender As Object, e As EventArgs) Handles BEditKO.Click
        FormProductionKO.id_ko = GVKO.GetFocusedRowCellValue("id_prod_order_ko").ToString
        FormProductionKO.ShowDialog()
    End Sub
End Class