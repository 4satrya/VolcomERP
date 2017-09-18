Public Class FormMatStock 
    'Def var -Tab Stock Card
    Dim id_mat_image As String = "0"
    Dim id_comp_def As String = "0"
    Dim comp_def As String = ""
    Dim id_design_def As String = "0"
    Dim label_mat_def As String = "0"
    Dim color_def As String = "-1"
    Dim size_set_def As String = "-1"
    Dim lot_def As String = "-1"
    Dim year_def As String = "-1"
    Dim id_mat_def As String = "-1"
    Dim mat_cat_def As String = "-1"
    Dim uom_def As String = "-1"

    'selected view  -Tab Stock Card
    Public id_mat_selected As String = "-1"
    Public label_mat_selected As String = "-1"
    Public id_wh_selected As String = "-1"
    Public comp_name_label_selected As String = ""
    Public date_from_selected As String = "-1"
    Public date_until_selected As String = "-1"

    'Datatalbe-Tab Stock Card
    Public dt As DataTable

    'Def var -Tab Stock Sum
    Dim id_comp_def_stock_sum As String = "0"
    Dim comp_def_stock_sum As String = ""
    Dim label_mat_stock_sum_def As String

    'Selected view - Tab Stock Sum
    Public id_wh_param_selected As String = "-1"
    Public id_locator_param_selected As String = "-1"
    Public id_rack_param_selected As String = "-1"
    Public id_drawer_param_selected As String = "-1"
    Public id_design_selected_stock_sum As String = "-1"
    Public label_design_selected_stock_sum As String = "-1"
    Public label_wh_selected_stock_sum As String = "-1"
    Public label_locator_selected_stock_sum As String = "-1"
    Public label_rack_selected_stock_sum As String = "-1"
    Public label_drawer_selected_stock_sum As String = "-1"
    Public date_from_selected_stock_sum As String = "-1"
    Public date_until_selected_stock_sum As String = "-1"

    'Datatalbe-Tab Stock Sum
    Public dt_sum As DataTable

    Private Sub FormFGStock_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        DEFrom.EditValue = Now
        DEUntil.EditValue = Now
        '
        DEFromBOM.EditValue = Now
        DEUntilBOM.EditValue = Now
        '
        viewProduct()
        viewWHStockCard()
        '
        viewWHStockSum()
        viewProductStockSum()
        '
        viewWOStockStore()
        viewProductStockStore()
        '

    End Sub

    '==============FUNCTION==========================='
    Function getQueryWH() As String
        Dim query As String = ""
        query += "SELECT ('0') AS id_comp, ('-') AS comp_number, ('All WH') AS comp_name, ('ALL WH') AS comp_name_label UNION ALL "
        query += "SELECT e.id_comp, e.comp_number, e.comp_name, CONCAT_WS(' - ', e.comp_number, e.comp_name) AS comp_name_label FROM tb_storage_mat a "
        query += "INNER JOIN tb_m_wh_drawer b ON a.id_wh_drawer = b.id_wh_drawer "
        query += "INNER JOIN tb_m_wh_rack c ON b.id_wh_rack = c.id_wh_rack "
        query += "INNER JOIN tb_m_wh_locator d ON c.id_wh_locator = d.id_wh_locator "
        query += "INNER JOIN tb_m_comp e ON e.id_comp = d.id_comp "
        query += "GROUP BY e.id_comp "
        Return query
    End Function

    Function getQueryLocator(ByVal id_comp) As String
        Dim query As String = ""
        query += "SELECT ('0') AS id_comp, ('0') AS id_wh_locator, ('-') AS wh_locator_code, ('All Loactor') AS wh_locator, ('-') AS wh_locator_description, ('All Locator') AS locator_label UNION ALL "
        query += "SELECT a.id_comp, a.id_wh_locator, a.wh_locator_code, a.wh_locator, a.wh_locator_description, CONCAT_WS(' - ', a.wh_locator_code, a.wh_locator) AS locator_label FROM tb_m_wh_locator a WHERE a.id_comp = '" + id_comp + "' "
        Return query
    End Function

    Function getRack(ByVal id_locator As String) As String
        Dim query As String = "SELECT ('0') AS id_locator, ('0') AS id_wh_rack, ('-') AS wh_rack_code, ('All Rack') AS wh_rack, ('-') AS wh_rack_description, ('All Rack') AS rack_label UNION ALL "
        query += "SELECT a.id_wh_locator, a.id_wh_rack, a.wh_rack_code, a.wh_rack, a.wh_rack_description, CONCAT_WS(' - ', a.wh_rack_code, a.wh_rack) AS rack_label FROM tb_m_wh_rack a WHERE a.id_wh_locator = '" + id_locator + "' "
        Return query
    End Function

    Function getDrawer(ByVal id_rack As String) As String
        Dim query As String = "SELECT ('0') AS id_rack, ('0') AS id_wh_drawer, ('-') AS wh_drawer_code, ('All Drawer') AS wh_drawer, ('-') AS wh_drawer_description, ('All Drawer') AS drawer_label UNION ALL "
        query += "SELECT a.id_wh_rack, a.id_wh_drawer, a.wh_drawer_code, a.wh_drawer, a.wh_drawer_description, CONCAT_WS(' - ', a.wh_drawer_code, a.wh_drawer) AS drawer_label FROM tb_m_wh_drawer a WHERE a.id_wh_rack = '" + id_rack + "'"
        Return query
    End Function

    Function getStockSum(ByVal id_wh_view As String, ByVal id_wh_locator_view As String, ByVal id_wh_rack_view As String, ByVal id_wh_drawer_view As String)
        Dim query As String = "CALL view_stock_fg('" + id_wh_view + "','" + id_wh_locator_view + "','" + id_wh_rack_view + "','" + id_wh_drawer_view + "', '0','3', '9999-01-01')"
        Return query
    End Function

    '=============== TAB STOCK CARD MAT==================================
    Sub viewProduct()
        Dim query As String = ""
        query += "CALL view_wh_mat(False) "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        For i As Integer = 0 To data.Rows.Count - 1
            If i = 0 Then
                label_mat_def = data.Rows(i)("label_mat").ToString
                id_mat_def = data.Rows(i)("id_mat_det").ToString
                mat_cat_def = data.Rows(i)("mat_category").ToString
                color_def = data.Rows(i)("color").ToString
                size_set_def = data.Rows(i)("size").ToString
                lot_def = data.Rows(i)("lot").ToString
                year_def = data.Rows(i)("year").ToString
                uom_def = data.Rows(i)("uom").ToString
                Exit For
            End If
        Next
        SLEProduct.Properties.DataSource = Nothing
        SLEProduct.Properties.DataSource = data
        SLEProduct.Properties.DisplayMember = "name"
        SLEProduct.Properties.ValueMember = "id_mat_det"
        '
        SLEMatBOM.Properties.DataSource = Nothing
        SLEMatBOM.Properties.DataSource = data
        SLEMatBOM.Properties.DisplayMember = "name"
        SLEMatBOM.Properties.ValueMember = "id_mat_det"
        '
        SLEResMat.Properties.DataSource = Nothing
        SLEResMat.Properties.DataSource = data
        SLEResMat.Properties.DisplayMember = "name"
        SLEResMat.Properties.ValueMember = "id_mat_det"
        '
        If data.Rows.Count.ToString >= 1 Then
            SLEProduct.EditValue = data.Rows(0)("id_mat_det").ToString
            BestFit(SLEProduct)
            '
            SLEMatBOM.EditValue = data.Rows(0)("id_mat_det").ToString
            BestFit(SLEMatBOM)
            '
            SLEResMat.EditValue = data.Rows(0)("id_mat_det").ToString
            BestFit(SLEResMat)
        Else
            SLEProduct.EditValue = Nothing
            '
            SLEMatBOM.EditValue = Nothing
            '
            SLEResMat.EditValue = Nothing
        End If
    End Sub
    Private Sub SLEProduct_EditValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SLEProduct.EditValueChanged
        If SLEProduct.EditValue = Nothing Then
            SLEProduct.EditValue = id_design_def
        Else
            id_design_def = SLEProduct.EditValue.ToString
        End If
    End Sub
    Sub viewWHStockCard()
        Dim query As String = getQueryWH()
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        For i As Integer = 0 To data.Rows.Count - 1
            If i = 0 Then
                comp_def = data.Rows(i)("comp_name_label").ToString
                Exit For
            End If
        Next
        SLEWH.Properties.DataSource = Nothing
        SLEWH.Properties.DataSource = data
        SLEWH.Properties.DisplayMember = "comp_name_label"
        SLEWH.Properties.ValueMember = "id_comp"
        If data.Rows.Count.ToString >= 1 Then
            SLEWH.EditValue = data.Rows(0)("id_comp").ToString
        Else
            SLEWH.EditValue = Nothing
        End If
    End Sub
    Private Sub SLEWH_EditValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SLEWH.EditValueChanged
        If SLEWH.EditValue = Nothing Then
            SLEWH.EditValue = "0"
        Else
            id_comp_def = SLEWH.EditValue.ToString
        End If
    End Sub
    Private Sub BtnTracking_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnTracking.Click
        Cursor = Cursors.WaitCursor
        BandedGridViewFGStockCard.Columns.Clear()
        BandedGridViewFGStockCard.Bands.Clear()
        'BandedGridViewFGStockCard.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        BandedGridViewFGStockCard.Appearance.BandPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        id_mat_selected = "-1"
        label_mat_selected = ""
        id_wh_selected = "0"
        comp_name_label_selected = ""
        date_from_selected = "0000-01-01"
        date_until_selected = "9999-01-01"
        Try
            id_wh_selected = SLEWH.EditValue.ToString
            id_mat_selected = SLEProduct.EditValue.ToString
            date_from_selected = DateTime.Parse(DEFrom.EditValue.ToString).ToString("yyyy-MM-dd")
            date_until_selected = DateTime.Parse(DEUntil.EditValue.ToString).ToString("yyyy-MM-dd")
        Catch ex As Exception
        End Try

        id_mat_image = "0"

        Dim band_ref As DevExpress.XtraGrid.Views.BandedGrid.GridBand = BandedGridViewFGStockCard.Bands.AddBand("Reff")
        Dim band_qty As DevExpress.XtraGrid.Views.BandedGrid.GridBand = BandedGridViewFGStockCard.Bands.AddBand("Quantity")
        Dim band_bal As DevExpress.XtraGrid.Views.BandedGrid.GridBand = BandedGridViewFGStockCard.Bands.AddBand("Balance")
        Dim band_amount As DevExpress.XtraGrid.Views.BandedGrid.GridBand = BandedGridViewFGStockCard.Bands.AddBand("Amount")
        Dim band_stat As DevExpress.XtraGrid.Views.BandedGrid.GridBand = BandedGridViewFGStockCard.Bands.AddBand("")

        BandedGridViewFGStockCard.OptionsView.GroupFooterShowMode = DevExpress.XtraGrid.Views.Grid.GroupFooterShowMode.VisibleAlways

        band_stat.AutoFillDown = True
        Dim query As String = "CALL view_stock_card_mat('" + id_mat_selected + "', '" + id_wh_selected + "', '" + date_from_selected + "', '" + date_until_selected + "') "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        For i As Integer = 0 To data.Columns.Count - 1
            If data.Columns(i).ColumnName.ToString = "id_comp" Or data.Columns(i).ColumnName.ToString = "id_report" Or data.Columns(i).ColumnName.ToString = "report_mark_type" Or data.Columns(i).ColumnName.ToString = "id_storage_category" Or data.Columns(i).ColumnName.ToString = "Time" Or data.Columns(i).ColumnName.ToString = "Transaction" Then
                band_ref.Columns.Add(BandedGridViewFGStockCard.Columns.AddVisible(data.Columns(i).ColumnName.ToString, data.Columns(i).ColumnName.ToString))
                If data.Columns(i).ColumnName.ToString = "Time" Then
                    BandedGridViewFGStockCard.Columns(data.Columns(i).ColumnName.ToString).DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
                    BandedGridViewFGStockCard.Columns(data.Columns(i).ColumnName.ToString).DisplayFormat.FormatString = "dd MMM yyyy hh:mm:ss"
                End If
            ElseIf data.Columns(i).ColumnName.ToString = "Status" Then
                band_stat.Columns.Add(BandedGridViewFGStockCard.Columns.AddVisible(data.Columns(i).ColumnName.ToString, "Status"))
                BandedGridViewFGStockCard.Columns(data.Columns(i).ColumnName.ToString).AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
                BandedGridViewFGStockCard.Columns(data.Columns(i).ColumnName.ToString).AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
            ElseIf data.Columns(i).ColumnName.ToString = "qty" Then
                band_qty.Columns.Add(BandedGridViewFGStockCard.Columns.AddVisible(data.Columns(i).ColumnName.ToString, "Quantity"))
                BandedGridViewFGStockCard.Columns(data.Columns(i).ColumnName.ToString).AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
                BandedGridViewFGStockCard.Columns(data.Columns(i).ColumnName.ToString).DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                BandedGridViewFGStockCard.Columns(data.Columns(i).ColumnName.ToString).DisplayFormat.FormatString = "{0:n2}"
            ElseIf data.Columns(i).ColumnName.ToString = "balance" Then
                band_bal.Columns.Add(BandedGridViewFGStockCard.Columns.AddVisible(data.Columns(i).ColumnName.ToString, "Balance"))
                BandedGridViewFGStockCard.Columns(data.Columns(i).ColumnName.ToString).AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
                BandedGridViewFGStockCard.Columns(data.Columns(i).ColumnName.ToString).DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                BandedGridViewFGStockCard.Columns(data.Columns(i).ColumnName.ToString).DisplayFormat.FormatString = "{0:n2}"
            Else
                band_amount.Columns.Add(BandedGridViewFGStockCard.Columns.AddVisible(data.Columns(i).ColumnName.ToString, data.Columns(i).ColumnName.ToString))
                BandedGridViewFGStockCard.Columns(data.Columns(i).ColumnName.ToString).AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
                BandedGridViewFGStockCard.Columns(data.Columns(i).ColumnName.ToString).DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                BandedGridViewFGStockCard.Columns(data.Columns(i).ColumnName.ToString).DisplayFormat.FormatString = "{0:n2}"
            End If
        Next

        GCFGStockCard.DataSource = data
        dt = data

        'hide column
        BandedGridViewFGStockCard.Columns("id_comp").Visible = False
        BandedGridViewFGStockCard.Columns("id_report").Visible = False
        BandedGridViewFGStockCard.Columns("report_mark_type").Visible = False
        BandedGridViewFGStockCard.Columns("id_storage_category").Visible = False

        'enable group
        GroupControlInfo.Enabled = True
        GroupControlTraccking.Enabled = True

        Dim view As DevExpress.XtraGrid.Views.Grid.GridView = SLEProduct.Properties.View
        Dim row_handle As Integer = view.FocusedRowHandle
        Dim view_wh As DevExpress.XtraGrid.Views.Grid.GridView = SLEWH.Properties.View

        Dim row_handle_wh As Integer = view_wh.FocusedRowHandle

        If row_handle < 0 Then
            id_mat_image = id_mat_def
            LabelLot.Text = lot_def
            LabelColor.Text = color_def
            LabelSizeSetting.Text = size_set_def
            LabelYear.Text = year_def
            LabelMatCategory.Text = mat_cat_def
            LUom.Text = uom_def
            'for information print
            label_mat_selected = label_mat_def
        Else
            id_mat_image = view.GetRowCellValue(row_handle, "id_mat_det")
            LabelLot.Text = view.GetRowCellValue(row_handle, "lot")
            LabelColor.Text = view.GetRowCellValue(row_handle, "color")
            LabelSizeSetting.Text = view.GetRowCellValue(row_handle, "size")
            LabelYear.Text = view.GetRowCellValue(row_handle, "year")
            LabelMatCategory.Text = view.GetRowCellValue(row_handle, "mat_category").ToString
            LUom.Text = view.GetRowCellValue(row_handle, "uom")

            'for information print
            label_mat_selected = view.GetRowCellValue(row_handle, "label_mat")
        End If

        If row_handle_wh < 0 Then
            'for print
            comp_name_label_selected = comp_def
        Else
            'for information print
            comp_name_label_selected = view_wh.GetRowCellValue(row_handle_wh, "comp_name_label")
        End If
        viewImages(PictureEdit1, get_setup_field("pic_path_mat") & "\", id_mat_image, False)
        Cursor = Cursors.Default
    End Sub
    Private Sub BtnViewImg_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnViewImg.Click
        viewImages(PictureEdit1, get_setup_field("pic_path_mat") & "\", id_mat_image, True)
    End Sub
    Private Sub BandedGridViewFGStockCard_PopupMenuShowing(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Grid.PopupMenuShowingEventArgs) Handles BandedGridViewFGStockCard.PopupMenuShowing
        If BandedGridViewFGStockCard.RowCount > 0 Then
            Dim view As DevExpress.XtraGrid.Views.Grid.GridView = CType(sender, DevExpress.XtraGrid.Views.Grid.GridView)
            Dim hitInfo As DevExpress.XtraGrid.Views.Grid.ViewInfo.GridHitInfo = view.CalcHitInfo(e.Point)
            If hitInfo.InRow Then
                view.FocusedRowHandle = hitInfo.RowHandle
                ViewMenu.Show(view.GridControl, e.Point)
            End If
        End If
    End Sub
    Private Sub SMViewDel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SMViewDel.Click
        Cursor = Cursors.WaitCursor
        If BandedGridViewFGStockCard.RowCount > 0 Then
            Dim id_trans As String = "-1"
            Dim report_mark_type As String = "-1"
            Try
                id_trans = BandedGridViewFGStockCard.GetFocusedRowCellValue("id_report").ToString
                report_mark_type = BandedGridViewFGStockCard.GetFocusedRowCellValue("report_mark_type").ToString
            Catch ex As Exception
            End Try
            Dim showpopup As ClassShowPopUp = New ClassShowPopUp()
            showpopup.report_mark_type = report_mark_type
            showpopup.id_report = id_trans
            showpopup.show()
        End If
        Cursor = Cursors.Default
    End Sub
    Private Sub FormFGStock_Activated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Activated
        FormMain.show_rb(Name)
        check_menu()
    End Sub
    Private Sub FormFGStock_Deactivate(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Deactivate
        FormMain.hide_rb()
    End Sub
    Sub check_menu()
        checkFormAccess(Name)
    End Sub

    '===================== TAB STOCK SUMMARY=========================================
    Sub viewWHStockSum()
        Dim query As String = getQueryWH()
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        For i As Integer = 0 To data.Rows.Count - 1
            If i = 0 Then
                comp_def_stock_sum = data.Rows(i)("comp_name_label").ToString
                Exit For
            End If
        Next
        SLEWHStockSum.Properties.DataSource = Nothing
        SLEWHStockSum.Properties.DataSource = data
        SLEWHStockSum.Properties.DisplayMember = "comp_name_label"
        SLEWHStockSum.Properties.ValueMember = "id_comp"
        If data.Rows.Count.ToString >= 1 Then
            SLEWHStockSum.EditValue = data.Rows(0)("id_comp").ToString
        Else
            SLEWHStockSum.EditValue = Nothing
        End If
    End Sub
    Private Sub SLEWHStockSum_EditValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SLEWHStockSum.EditValueChanged
        If SLEWHStockSum.EditValue = Nothing Then
            SLEWHStockSum.EditValue = "0"
        Else
            id_comp_def_stock_sum = SLEWHStockSum.EditValue.ToString
            viewLocatorStockSum()
        End If
    End Sub
    Sub viewLocatorStockSum()
        Dim id_comp As String = "-1"
        Try
            id_comp = SLEWHStockSum.EditValue.ToString()
        Catch ex As Exception
        End Try
        Dim query As String = getQueryLocator(id_comp)
        viewSearchLookupQuery(SLELocatorStockSum, query, "id_wh_locator", "locator_label", "id_wh_locator")
    End Sub
    Private Sub SLELocatorStockSum_EditValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SLELocatorStockSum.EditValueChanged
        viewRackStockSum()
    End Sub
    Sub viewRackStockSum()
        Dim id_locator As String = "-1"
        Try
            id_locator = SLELocatorStockSum.EditValue.ToString
        Catch ex As Exception
        End Try
        Dim query As String = getRack(id_locator)
        viewSearchLookupQuery(SLERackStockSum, query, "id_wh_rack", "rack_label", "id_wh_rack")
    End Sub
    Private Sub SLERackStockSum_EditValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SLERackStockSum.EditValueChanged
        viewDrawerStockSum()
    End Sub
    Sub viewDrawerStockSum()
        Dim id_rack As String = "-1"
        Try
            id_rack = SLERackStockSum.EditValue.ToString
        Catch ex As Exception
        End Try
        Dim query As String = getDrawer(id_rack)
        viewSearchLookupQuery(SLEDrawerStockSum, query, "id_wh_drawer", "drawer_label", "id_wh_drawer")
    End Sub
    Private Sub SLEDrawerStockSum_EditValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SLEDrawerStockSum.EditValueChanged
        If SLEDrawerStockSum.EditValue Is Nothing Then
            BtnViewStockSum.Enabled = False
        Else
            BtnViewStockSum.Enabled = True
        End If
    End Sub
    Private Sub BtnViewStockSum_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnViewStockSum.Click
        Cursor = Cursors.WaitCursor

        'Clear List code
        'special_code_list.Clear()

        'Prepare paramater
        Try
            id_design_selected_stock_sum = SLEDesignStockSum.EditValue.ToString
            id_wh_param_selected = SLEWHStockSum.EditValue.ToString
            id_locator_param_selected = SLELocatorStockSum.EditValue.ToString
            id_rack_param_selected = SLERackStockSum.EditValue.ToString
            id_drawer_param_selected = SLEDrawerStockSum.EditValue.ToString
            date_from_selected_stock_sum = DateTime.Parse(DEFrom.EditValue.ToString).ToString("yyyy-MM-dd")
            date_until_selected_stock_sum = DateTime.Parse(DEUntil.EditValue.ToString).ToString("yyyy-MM-dd")
        Catch ex As Exception
        End Try

        'set selected
        If id_design_selected_stock_sum = "0" Then
            label_design_selected_stock_sum = "All Material"
        Else
            label_design_selected_stock_sum = SLEDesignStockSum.Properties.View.GetFocusedRowCellValue("label_mat").ToString
        End If

        If id_wh_param_selected = "0" Then
            label_wh_selected_stock_sum = "All WH"
        Else
            label_wh_selected_stock_sum = SLEWHStockSum.Properties.View.GetFocusedRowCellValue("comp_name_label").ToString
        End If

        If id_locator_param_selected = "0" Then
            label_locator_selected_stock_sum = "All Locator"
        Else
            label_locator_selected_stock_sum = SLELocatorStockSum.Properties.View.GetFocusedRowCellValue("locator_label").ToString
        End If

        If id_rack_param_selected = "0" Then
            label_rack_selected_stock_sum = "All Rack"
        Else
            label_rack_selected_stock_sum = SLERackStockSum.Properties.View.GetFocusedRowCellValue("rack_label").ToString
        End If

        If id_drawer_param_selected = "0" Then
            label_drawer_selected_stock_sum = "All Drawer"
        Else
            label_drawer_selected_stock_sum = SLEDrawerStockSum.Properties.View.GetFocusedRowCellValue("drawer_label").ToString
        End If

        'Prepare Baded
        BGVFGStock.Columns.Clear()
        BGVFGStock.Bands.Clear()
        BGVFGStock.Appearance.BandPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center

        BGVFGStock.OptionsView.GroupFooterShowMode = DevExpress.XtraGrid.Views.Grid.GroupFooterShowMode.VisibleAlways

        Dim band_desc As DevExpress.XtraGrid.Views.BandedGrid.GridBand = BGVFGStock.Bands.AddBand("Description")
        Dim band_qty_free As DevExpress.XtraGrid.Views.BandedGrid.GridBand = BGVFGStock.Bands.AddBand("Qty Free")
        Dim band_qty_bom As DevExpress.XtraGrid.Views.BandedGrid.GridBand = BGVFGStock.Bands.AddBand("Qty BOM")
        Dim band_qty_res As DevExpress.XtraGrid.Views.BandedGrid.GridBand = BGVFGStock.Bands.AddBand("Qty Reserved Packing List")
        Dim band_qty_total As DevExpress.XtraGrid.Views.BandedGrid.GridBand = BGVFGStock.Bands.AddBand("Total Qty")

        band_qty_total.AppearanceHeader.Font = New Font(BGVFGStock.Appearance.Row.Font.FontFamily, BGVFGStock.Appearance.Row.Font.Size, FontStyle.Bold)

        Dim query As String = "CALL view_stock_mat_sum('" + id_wh_param_selected + "', '" + id_locator_param_selected + "', '" + id_rack_param_selected + "', '" + id_drawer_param_selected + "', '" + id_design_selected_stock_sum + "') "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        For i As Integer = 0 To data.Columns.Count - 1
            If data.Columns(i).ColumnName.ToString = "id_mat_det" Or data.Columns(i).ColumnName.ToString = "code" Or data.Columns(i).ColumnName.ToString = "name" Or data.Columns(i).ColumnName.ToString = "mat_cat" Or data.Columns(i).ColumnName.ToString = "year" Or data.Columns(i).ColumnName.ToString = "lot" Or data.Columns(i).ColumnName.ToString = "color" Or data.Columns(i).ColumnName.ToString = "size" Or data.Columns(i).ColumnName.ToString = "uom" Or data.Columns(i).ColumnName.ToString = "price" Then
                If data.Columns(i).ColumnName.ToString = "code" Then
                    band_desc.Columns.Add(BGVFGStock.Columns.AddVisible(data.Columns(i).ColumnName.ToString, "Code"))
                ElseIf data.Columns(i).ColumnName.ToString = "id_mat_det" Then
                    band_desc.Columns.Add(BGVFGStock.Columns.AddVisible(data.Columns(i).ColumnName.ToString, "ID"))
                ElseIf data.Columns(i).ColumnName.ToString = "name" Then
                    band_desc.Columns.Add(BGVFGStock.Columns.AddVisible(data.Columns(i).ColumnName.ToString, "Description"))
                ElseIf data.Columns(i).ColumnName.ToString = "mat_cat" Then
                    band_desc.Columns.Add(BGVFGStock.Columns.AddVisible(data.Columns(i).ColumnName.ToString, "Category"))
                ElseIf data.Columns(i).ColumnName.ToString = "year" Then
                    band_desc.Columns.Add(BGVFGStock.Columns.AddVisible(data.Columns(i).ColumnName.ToString, "Year"))
                ElseIf data.Columns(i).ColumnName.ToString = "lot" Then
                    band_desc.Columns.Add(BGVFGStock.Columns.AddVisible(data.Columns(i).ColumnName.ToString, "Lot"))
                ElseIf data.Columns(i).ColumnName.ToString = "color" Then
                    band_desc.Columns.Add(BGVFGStock.Columns.AddVisible(data.Columns(i).ColumnName.ToString, "Color"))
                ElseIf data.Columns(i).ColumnName.ToString = "size" Then
                    band_desc.Columns.Add(BGVFGStock.Columns.AddVisible(data.Columns(i).ColumnName.ToString, "Size"))
                ElseIf data.Columns(i).ColumnName.ToString = "uom" Then
                    band_desc.Columns.Add(BGVFGStock.Columns.AddVisible(data.Columns(i).ColumnName.ToString, "UOM"))
                ElseIf data.Columns(i).ColumnName.ToString = "price" Then
                    band_desc.Columns.Add(BGVFGStock.Columns.AddVisible(data.Columns(i).ColumnName.ToString, "Cost"))
                End If
            ElseIf data.Columns(i).ColumnName.ToString.Contains("qty_free") Then
                Dim st_caption As String = "Free Qty"
                band_qty_free.Columns.Add(BGVFGStock.Columns.AddVisible(data.Columns(i).ColumnName.ToString, st_caption))
                BGVFGStock.Columns(data.Columns(i).ColumnName.ToString).AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
                BGVFGStock.Columns(data.Columns(i).ColumnName.ToString).AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
                BGVFGStock.Columns(data.Columns(i).ColumnName.ToString).DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                BGVFGStock.Columns(data.Columns(i).ColumnName.ToString).DisplayFormat.FormatString = "{0:n2}"
            ElseIf data.Columns(i).ColumnName.ToString.Contains("amount_free") Then
                Dim st_caption As String = "Free Amount"
                band_qty_free.Columns.Add(BGVFGStock.Columns.AddVisible(data.Columns(i).ColumnName.ToString, st_caption))
                BGVFGStock.Columns(data.Columns(i).ColumnName.ToString).AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
                BGVFGStock.Columns(data.Columns(i).ColumnName.ToString).AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
                BGVFGStock.Columns(data.Columns(i).ColumnName.ToString).DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                BGVFGStock.Columns(data.Columns(i).ColumnName.ToString).DisplayFormat.FormatString = "{0:n2}"

                BGVFGStock.Columns(data.Columns(i).ColumnName.ToString).SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
                BGVFGStock.Columns(data.Columns(i).ColumnName.ToString).SummaryItem.DisplayFormat = "{0:n2}"

                Dim item As DevExpress.XtraGrid.GridGroupSummaryItem = New DevExpress.XtraGrid.GridGroupSummaryItem()
                item.FieldName = data.Columns(i).ColumnName.ToString
                item.SummaryType = DevExpress.Data.SummaryItemType.Sum
                item.DisplayFormat = "{0:n2}"
                item.ShowInGroupColumnFooter = BGVFGStock.Columns(data.Columns(i).ColumnName.ToString)
                BGVFGStock.GroupSummary.Add(item)
            ElseIf data.Columns(i).ColumnName.ToString.Contains("qty_res") Then
                Dim st_caption As String = "Reserved Qty"
                band_qty_res.Columns.Add(BGVFGStock.Columns.AddVisible(data.Columns(i).ColumnName.ToString, st_caption))
                BGVFGStock.Columns(data.Columns(i).ColumnName.ToString).AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
                BGVFGStock.Columns(data.Columns(i).ColumnName.ToString).AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
                BGVFGStock.Columns(data.Columns(i).ColumnName.ToString).DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                BGVFGStock.Columns(data.Columns(i).ColumnName.ToString).DisplayFormat.FormatString = "{0:n2}"
            ElseIf data.Columns(i).ColumnName.ToString.Contains("amount_res") Then
                Dim st_caption As String = "Reserved Amount"
                band_qty_res.Columns.Add(BGVFGStock.Columns.AddVisible(data.Columns(i).ColumnName.ToString, st_caption))
                BGVFGStock.Columns(data.Columns(i).ColumnName.ToString).AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
                BGVFGStock.Columns(data.Columns(i).ColumnName.ToString).AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
                BGVFGStock.Columns(data.Columns(i).ColumnName.ToString).DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                BGVFGStock.Columns(data.Columns(i).ColumnName.ToString).DisplayFormat.FormatString = "{0:n2}"

                BGVFGStock.Columns(data.Columns(i).ColumnName.ToString).SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
                BGVFGStock.Columns(data.Columns(i).ColumnName.ToString).SummaryItem.DisplayFormat = "{0:n2}"

                Dim item As DevExpress.XtraGrid.GridGroupSummaryItem = New DevExpress.XtraGrid.GridGroupSummaryItem()
                item.FieldName = data.Columns(i).ColumnName.ToString
                item.SummaryType = DevExpress.Data.SummaryItemType.Sum
                item.DisplayFormat = "{0:n2}"
                item.ShowInGroupColumnFooter = BGVFGStock.Columns(data.Columns(i).ColumnName.ToString)
                BGVFGStock.GroupSummary.Add(item)
            ElseIf data.Columns(i).ColumnName.ToString.Contains("qty_all") Then
                Dim st_caption As String = "Total Qty"
                band_qty_total.Columns.Add(BGVFGStock.Columns.AddVisible(data.Columns(i).ColumnName.ToString, st_caption))
                BGVFGStock.Columns(data.Columns(i).ColumnName.ToString).AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
                BGVFGStock.Columns(data.Columns(i).ColumnName.ToString).AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
                BGVFGStock.Columns(data.Columns(i).ColumnName.ToString).DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                BGVFGStock.Columns(data.Columns(i).ColumnName.ToString).DisplayFormat.FormatString = "{0:n2}"
            ElseIf data.Columns(i).ColumnName.ToString.Contains("amount_all") Then
                Dim st_caption As String = "Total Amount"
                band_qty_total.Columns.Add(BGVFGStock.Columns.AddVisible(data.Columns(i).ColumnName.ToString, st_caption))
                BGVFGStock.Columns(data.Columns(i).ColumnName.ToString).AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
                BGVFGStock.Columns(data.Columns(i).ColumnName.ToString).AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
                BGVFGStock.Columns(data.Columns(i).ColumnName.ToString).DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                BGVFGStock.Columns(data.Columns(i).ColumnName.ToString).DisplayFormat.FormatString = "{0:n2}"

                BGVFGStock.Columns(data.Columns(i).ColumnName.ToString).SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
                BGVFGStock.Columns(data.Columns(i).ColumnName.ToString).SummaryItem.DisplayFormat = "{0:n2}"

                Dim item As DevExpress.XtraGrid.GridGroupSummaryItem = New DevExpress.XtraGrid.GridGroupSummaryItem()
                item.FieldName = data.Columns(i).ColumnName.ToString
                item.SummaryType = DevExpress.Data.SummaryItemType.Sum
                item.DisplayFormat = "{0:n2}"
                item.ShowInGroupColumnFooter = BGVFGStock.Columns(data.Columns(i).ColumnName.ToString)
                BGVFGStock.GroupSummary.Add(item)
            ElseIf data.Columns(i).ColumnName.ToString.Contains("qty_left_bom") Or data.Columns(i).ColumnName.ToString.Contains("bom_res") Then
                Dim st_caption As String = ""
                If data.Columns(i).ColumnName.ToString.Contains("qty_left_bom") Then
                    st_caption = "Qty After BOM Reserved"
                ElseIf data.Columns(i).ColumnName.ToString.Contains("bom_res") Then
                    st_caption = "BOM Reserved"
                End If

                band_qty_bom.Columns.Add(BGVFGStock.Columns.AddVisible(data.Columns(i).ColumnName.ToString, st_caption))

                BGVFGStock.Columns(data.Columns(i).ColumnName.ToString).AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
                BGVFGStock.Columns(data.Columns(i).ColumnName.ToString).AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
                BGVFGStock.Columns(data.Columns(i).ColumnName.ToString).DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                BGVFGStock.Columns(data.Columns(i).ColumnName.ToString).DisplayFormat.FormatString = "{0:n2}"
            End If
        Next
        GCFGStock.DataSource = data
        dt_sum = data
        'hide bom
        band_qty_bom.Visible = False

        'hide column
        BGVFGStock.Columns("id_mat_det").Visible = False
        BGVFGStock.BestFitColumns()

        'Enable Group
        GroupControlStockSum.Enabled = True
        Cursor = Cursors.Default
    End Sub
    Sub viewProductStockSum()
        Dim query As String = ""
        query += "CALL view_wh_mat(TRUE) "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        For i As Integer = 0 To data.Rows.Count - 1
            If i = 0 Then
                label_mat_stock_sum_def = data.Rows(i)("label_mat").ToString
                Exit For
            End If
        Next
        SLEDesignStockSum.Properties.DataSource = Nothing
        SLEDesignStockSum.Properties.DataSource = data
        SLEDesignStockSum.Properties.DisplayMember = "label_mat"
        SLEDesignStockSum.Properties.ValueMember = "id_mat_det"
        If data.Rows.Count.ToString >= 1 Then
            SLEDesignStockSum.EditValue = data.Rows(0)("id_mat_det").ToString
            BestFit(SLEDesignStockSum)
        Else
            SLEDesignStockSum.EditValue = Nothing
        End If
    End Sub
    Private Sub BestFit(ByVal sle As DevExpress.XtraEditors.SearchLookUpEdit)
        sle.Properties.PopulateViewColumns()
        Dim columns = SearchLookUpEdit1View.Columns
        Dim totalWidth = 0
        For Each column As DevExpress.XtraGrid.Columns.GridColumn In columns
            Dim columnBestWidth = sle.Properties.View.CalcColumnBestWidth(column)
            totalWidth += columnBestWidth
        Next column
        sle.Properties.PopupFormWidth = totalWidth
    End Sub
    '======================== stock vendor ============================
    '------------------------------------
    'VARIABLE STOCK STORE
    '------------------------------------
    'Def var -Tab Stock Store
    Dim id_store_def_stock_store As String = "0"
    Dim store_def_stock_store As String = ""
    Dim label_design_stock_store_def As String

    'selected View - Tab Stock Store
    Public id_vendor_param_selected As String = "-1"
    Public id_mat_selected_stock_vendor As String = "-1"
    Public label_mat_selected_stock_vendor As String = "-1"
    Public label_vendor_selected_stock_vendor As String = "-1"
    Public date_from_selected_stock_vendor As String = "0000-01-01"
    Public date_until_selected_stock_vendor As String = "9999-01-01"

    'Datatalbe-Tab Stock Store
    Public dt_store As DataTable

    Sub viewWOStockStore()
        Dim query As String = getQueryVendor()
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        For i As Integer = 0 To data.Rows.Count - 1
            If i = 0 Then
                store_def_stock_store = data.Rows(i)("comp_name_label").ToString
                Exit For
            End If
        Next
        SLEVendor.Properties.DataSource = Nothing
        SLEVendor.Properties.DataSource = data
        SLEVendor.Properties.DisplayMember = "comp_name_label"
        SLEVendor.Properties.ValueMember = "id_comp"
        If data.Rows.Count.ToString >= 1 Then
            SLEVendor.EditValue = data.Rows(0)("id_comp").ToString
        Else
            SLEVendor.EditValue = Nothing
        End If
    End Sub
    Sub viewProductStockStore()
        Dim query As String = ""
        query += "CALL view_wh_mat(TRUE) "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        For i As Integer = 0 To data.Rows.Count - 1
            If i = 0 Then
                label_design_stock_store_def = data.Rows(i)("label_mat").ToString
                Exit For
            End If
        Next
        SLEMatStockVendor.Properties.DataSource = Nothing
        SLEMatStockVendor.Properties.DataSource = data
        SLEMatStockVendor.Properties.DisplayMember = "label_mat"
        SLEMatStockVendor.Properties.ValueMember = "id_mat_det"
        If data.Rows.Count.ToString >= 1 Then
            SLEMatStockVendor.EditValue = data.Rows(0)("id_mat_det").ToString
            BestFit(SLEMatStockVendor)
        Else
            SLEMatStockVendor.EditValue = Nothing
        End If
    End Sub

    Private Sub BtnViewStockVendor_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnViewStockVendor.Click
        Cursor = Cursors.WaitCursor

        'Prepare paramater
        date_from_selected_stock_vendor = "0000-01-01"
        date_until_selected_stock_vendor = "9999-01-01"
        Try
            id_mat_selected_stock_vendor = SLEMatStockVendor.EditValue.ToString
            id_vendor_param_selected = SLEVendor.EditValue.ToString
        Catch ex As Exception
        End Try

        Try
            date_from_selected_stock_vendor = DateTime.Parse(DEWOFrom.EditValue.ToString).ToString("yyyy-MM-dd")
        Catch ex As Exception
        End Try

        Try
            date_until_selected_stock_vendor = DateTime.Parse(DEWOUntil.EditValue.ToString).ToString("yyyy-MM-dd")
        Catch ex As Exception
        End Try
        
        'set selected
        If id_mat_selected_stock_vendor = "0" Then
            label_mat_selected_stock_vendor = "All Material"
        Else
            label_mat_selected_stock_vendor = SLEMatStockVendor.Properties.View.GetFocusedRowCellValue("label_mat").ToString
        End If

        If id_vendor_param_selected = "0" Then
            label_vendor_selected_stock_vendor = "All Vendor"
        Else
            label_vendor_selected_stock_vendor = SLEVendor.Properties.View.GetFocusedRowCellValue("comp_name_label").ToString
        End If

        'Prepare Baded
        'BGVStockWO.Columns.Clear()
        'BGVStockWO.Bands.Clear()
        'BGVStockWO.Appearance.BandPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center

        'Dim band_desc As DevExpress.XtraGrid.Views.BandedGrid.GridBand = BGVStockWO.Bands.AddBand("DESCRIPTION")
        'Dim band_reff As DevExpress.XtraGrid.Views.BandedGrid.GridBand = BGVStockWO.Bands.AddBand("REFERENCE")
        'Dim band_qty As DevExpress.XtraGrid.Views.BandedGrid.GridBand = BGVStockWO.Bands.AddBand("QTY")

        ' Make the group footers always visible.
        ' BGVStockWO.GroupFooterShowMode = DevExpress.XtraGrid.Views.Grid.GroupFooterShowMode.VisibleAlways

        Dim queryx As String = ""
        queryx = "CALL view_stock_mat_vendor_wo('" + id_mat_selected_stock_vendor + "', '" + id_vendor_param_selected + "','" + date_from_selected_stock_vendor + "', '" + date_until_selected_stock_vendor + "') "
        Dim data As DataTable = execute_query(queryx, -1, True, "", "", "", "")
        'For i As Integer = 0 To data.Columns.Count - 1
        '    If data.Columns(i).ColumnName.ToString = "Store" Or data.Columns(i).ColumnName.ToString = "id_sample" Or data.Columns(i).ColumnName.ToString = "Code" Or data.Columns(i).ColumnName.ToString = "id_design" Or data.Columns(i).ColumnName.ToString = "Design" Or data.Columns(i).ColumnName.ToString = "design_display_name" Or data.Columns(i).ColumnName.ToString = "uom" Or data.Columns(i).ColumnName.ToString = "Receiving WH Aging" Or data.Columns(i).ColumnName.ToString = "id_design_stock" Or data.Columns(i).ColumnName.ToString = "Age (Day)" Or data.Columns(i).ColumnName.ToString = "id_comp" Or data.Columns(i).ColumnName.ToString = "Product Division" Or data.Columns(i).ColumnName.ToString = "Product Source" Or data.Columns(i).ColumnName.ToString = "Product Branding" Or data.Columns(i).ColumnName.ToString = "Range" Or data.Columns(i).ColumnName.ToString = "Product Counting" Or data.Columns(i).ColumnName.ToString = "Color" Or data.Columns(i).ColumnName.ToString = "id_design_price" Or data.Columns(i).ColumnName.ToString = "Price Type" Or data.Columns(i).ColumnName.ToString = "Price Name" Or data.Columns(i).ColumnName.ToString = "Color" Or data.Columns(i).ColumnName.ToString = "Price" Then
        '        band_desc.Columns.Add(BGVStockWO.Columns.AddVisible(data.Columns(i).ColumnName.ToString, data.Columns(i).ColumnName.ToString))
        '    Else
        '        Dim st_caption As String = data.Columns(i).ColumnName.ToString.Length - 6
        '        band_qty.Columns.Add(BGVStockWO.Columns.AddVisible(data.Columns(i).ColumnName.ToString, data.Columns(i).ColumnName.ToString.Substring(0, st_caption)))
        '        BGVStockWO.Columns(data.Columns(i).ColumnName.ToString).AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        '        BGVStockWO.Columns(data.Columns(i).ColumnName.ToString).DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        '        BGVStockWO.Columns(data.Columns(i).ColumnName.ToString).DisplayFormat.FormatString = "{0:n2}"

        '        BGVStockWO.Columns(data.Columns(i).ColumnName.ToString).SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
        '        BGVStockWO.Columns(data.Columns(i).ColumnName.ToString).SummaryItem.DisplayFormat = "{0:n2}"

        '        Dim item As DevExpress.XtraGrid.GridGroupSummaryItem = New DevExpress.XtraGrid.GridGroupSummaryItem()
        '        item.FieldName = data.Columns(i).ColumnName.ToString
        '        item.SummaryType = DevExpress.Data.SummaryItemType.Sum
        '        item.DisplayFormat = "{0:n2}"
        '        item.ShowInGroupColumnFooter = BGVStockWO.Columns(data.Columns(i).ColumnName.ToString)
        '        BGVStockWO.GroupSummary.Add(item)
        '    End If
        'Next
        GCStockWO.DataSource = data
        dt_store = data

        ''hide column
        'BGVStockWO.Columns("id_sample").Visible = False
        'BGVStockWO.Columns("id_design").Visible = False
        'BGVStockWO.Columns("design_display_name").Visible = False
        'BGVStockWO.Columns("uom").Visible = False
        'BGVStockWO.Columns("id_design_stock").Visible = False
        'BGVStockWO.Columns("id_design_price").Visible = False
        'BGVStockWO.Columns("Product Counting").Visible = False
        'BGVStockWO.Columns("Range").Visible = False
        'BGVStockWO.Columns("id_comp").Visible = False

        'Enable Group
        BGVStockWO.BestFitColumns()
        GroupControlStockWo.Enabled = True
        Cursor = Cursors.Default
    End Sub

    Private Sub ViewPackingListToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ViewPackingListToolStripMenuItem.Click
        Cursor = Cursors.WaitCursor
        If BGVStockWO.RowCount > 0 Then
            Dim id_trans As String = "-1"
            Dim report_mark_type As String = "-1"
            Try
                id_trans = BGVStockWO.GetFocusedRowCellValue("id_pl_mrs").ToString
                report_mark_type = "30"
            Catch ex As Exception
            End Try

            Dim showpopup As ClassShowPopUp = New ClassShowPopUp()
            showpopup.report_mark_type = report_mark_type
            showpopup.id_report = id_trans
            showpopup.show()
        End If
        Cursor = Cursors.Default
    End Sub

    Private Sub ViewMaterialRequestToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ViewMaterialRequestToolStripMenuItem.Click
        Cursor = Cursors.WaitCursor
        If BGVStockWO.RowCount > 0 Then
            Dim id_trans As String = "-1"
            Dim report_mark_type As String = "-1"
            Try
                id_trans = BGVStockWO.GetFocusedRowCellValue("id_prod_order_mrs").ToString
                report_mark_type = "44"
            Catch ex As Exception
            End Try

            Dim showpopup As ClassShowPopUp = New ClassShowPopUp()
            showpopup.report_mark_type = report_mark_type
            showpopup.id_report = id_trans
            showpopup.show()
        End If
        Cursor = Cursors.Default
    End Sub

    Private Sub WorkOrderToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles WorkOrderToolStripMenuItem.Click
        Cursor = Cursors.WaitCursor
        If BGVStockWO.RowCount > 0 Then
            Dim id_trans As String = "-1"
            Dim report_mark_type As String = "-1"
            Try
                id_trans = BGVStockWO.GetFocusedRowCellValue("id_mat_wo").ToString
                report_mark_type = "15"
            Catch ex As Exception
            End Try

            Dim showpopup As ClassShowPopUp = New ClassShowPopUp()
            showpopup.report_mark_type = report_mark_type
            showpopup.id_report = id_trans
            showpopup.show()
        End If
        Cursor = Cursors.Default
    End Sub

    Private Sub BGVStockWO_PopupMenuShowing(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Grid.PopupMenuShowingEventArgs) Handles BGVStockWO.PopupMenuShowing
        If BGVStockWO.RowCount > 0 Then
            Dim view As DevExpress.XtraGrid.Views.Grid.GridView = CType(sender, DevExpress.XtraGrid.Views.Grid.GridView)
            Dim hitInfo As DevExpress.XtraGrid.Views.Grid.ViewInfo.GridHitInfo = view.CalcHitInfo(e.Point)
            If hitInfo.InRow Then
                view.FocusedRowHandle = hitInfo.RowHandle
                ViewMenuWO.Show(view.GridControl, e.Point)
            End If
        End If
    End Sub

    Private Sub BViewBOM_Click(sender As Object, e As EventArgs) Handles BViewBOM.Click
        Cursor = Cursors.WaitCursor
        BGVStockBOM.Columns.Clear()
        BGVStockBOM.Bands.Clear()
        BGVStockBOM.Appearance.BandPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        id_mat_selected = "-1"
        label_mat_selected = ""
        comp_name_label_selected = ""
        date_from_selected = "0000-01-01"
        date_until_selected = "9999-01-01"
        Try
            id_mat_selected = SLEMatBOM.EditValue.ToString
            date_from_selected = Date.Parse(DEFromBOM.EditValue.ToString).ToString("yyyy-MM-dd")
            date_until_selected = Date.Parse(DEUntilBOM.EditValue.ToString).ToString("yyyy-MM-dd")
        Catch ex As Exception
        End Try

        id_mat_image = "0"

        Dim band_ref As DevExpress.XtraGrid.Views.BandedGrid.GridBand = BGVStockBOM.Bands.AddBand("Reff")
        Dim band_qty As DevExpress.XtraGrid.Views.BandedGrid.GridBand = BGVStockBOM.Bands.AddBand("Quantity")
        Dim band_bal As DevExpress.XtraGrid.Views.BandedGrid.GridBand = BGVStockBOM.Bands.AddBand("Balance")
        Dim band_amount As DevExpress.XtraGrid.Views.BandedGrid.GridBand = BGVStockBOM.Bands.AddBand("Amount")
        Dim band_stat As DevExpress.XtraGrid.Views.BandedGrid.GridBand = BGVStockBOM.Bands.AddBand("")

        BGVStockBOM.OptionsView.GroupFooterShowMode = DevExpress.XtraGrid.Views.Grid.GroupFooterShowMode.VisibleAlways

        band_stat.AutoFillDown = True
        Dim query As String = "CALL view_mat_stock_card_bom('" + id_mat_selected + "','" + date_from_selected + "', '" + date_until_selected + "') "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        For i As Integer = 0 To data.Columns.Count - 1
            If data.Columns(i).ColumnName.ToString = "design_display_name" Or data.Columns(i).ColumnName.ToString = "design_code" Or data.Columns(i).ColumnName.ToString = "note" Or data.Columns(i).ColumnName.ToString = "id_mat_det" Or data.Columns(i).ColumnName.ToString = "id_report" Or data.Columns(i).ColumnName.ToString = "report_mark_type" Or data.Columns(i).ColumnName.ToString = "id_storage_category" Or data.Columns(i).ColumnName.ToString = "date" Or data.Columns(i).ColumnName.ToString = "Transaction" Then
                If data.Columns(i).ColumnName.ToString = "date" Then
                    band_ref.Columns.Add(BGVStockBOM.Columns.AddVisible(data.Columns(i).ColumnName.ToString, "Time"))
                    BGVStockBOM.Columns(data.Columns(i).ColumnName.ToString).DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
                    BGVStockBOM.Columns(data.Columns(i).ColumnName.ToString).DisplayFormat.FormatString = "dd MMM yyyy hh:mm:ss"
                ElseIf data.Columns(i).ColumnName.ToString = "design_display_name" Then
                    band_ref.Columns.Add(BGVStockBOM.Columns.AddVisible(data.Columns(i).ColumnName.ToString, "Design"))
                ElseIf data.Columns(i).ColumnName.ToString = "design_code" Then
                    band_ref.Columns.Add(BGVStockBOM.Columns.AddVisible(data.Columns(i).ColumnName.ToString, "Design Code"))
                ElseIf data.Columns(i).ColumnName.ToString = "note" Then
                    band_ref.Columns.Add(BGVStockBOM.Columns.AddVisible(data.Columns(i).ColumnName.ToString, "Note"))
                Else
                    band_ref.Columns.Add(BGVStockBOM.Columns.AddVisible(data.Columns(i).ColumnName.ToString, data.Columns(i).ColumnName.ToString))
                End If
            ElseIf data.Columns(i).ColumnName.ToString = "Status" Then
                band_stat.Columns.Add(BGVStockBOM.Columns.AddVisible(data.Columns(i).ColumnName.ToString, "Status"))
                BGVStockBOM.Columns(data.Columns(i).ColumnName.ToString).AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
                BGVStockBOM.Columns(data.Columns(i).ColumnName.ToString).AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
            ElseIf data.Columns(i).ColumnName.ToString = "qty" Then
                band_qty.Columns.Add(BGVStockBOM.Columns.AddVisible(data.Columns(i).ColumnName.ToString, "Quantity"))
                BGVStockBOM.Columns(data.Columns(i).ColumnName.ToString).AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
                BGVStockBOM.Columns(data.Columns(i).ColumnName.ToString).DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                BGVStockBOM.Columns(data.Columns(i).ColumnName.ToString).DisplayFormat.FormatString = "{0:n2}"
            ElseIf data.Columns(i).ColumnName.ToString = "balance" Then
                band_bal.Columns.Add(BGVStockBOM.Columns.AddVisible(data.Columns(i).ColumnName.ToString, "Balance"))
                BGVStockBOM.Columns(data.Columns(i).ColumnName.ToString).AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
                BGVStockBOM.Columns(data.Columns(i).ColumnName.ToString).DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                BGVStockBOM.Columns(data.Columns(i).ColumnName.ToString).DisplayFormat.FormatString = "{0:n2}"
            Else
                If data.Columns(i).ColumnName.ToString = "amount" Then
                    band_amount.Columns.Add(BGVStockBOM.Columns.AddVisible(data.Columns(i).ColumnName.ToString, "Amount"))
                Else
                    band_amount.Columns.Add(BGVStockBOM.Columns.AddVisible(data.Columns(i).ColumnName.ToString, data.Columns(i).ColumnName.ToString))
                End If
                BGVStockBOM.Columns(data.Columns(i).ColumnName.ToString).AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
                BGVStockBOM.Columns(data.Columns(i).ColumnName.ToString).DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                BGVStockBOM.Columns(data.Columns(i).ColumnName.ToString).DisplayFormat.FormatString = "{0:n2}"
            End If
        Next

        GCStockBOM.DataSource = data
        dt = data

        'hide column
        'BGVStockBOM.Columns("id_report").Visible = False
        BGVStockBOM.Columns("id_mat_det").Visible = False
        BGVStockBOM.Columns("id_storage_category").Visible = False

        'enable group
        GCBOMTracking.Enabled = True

        Dim view As DevExpress.XtraGrid.Views.Grid.GridView = SLEMatBOM.Properties.View
        Dim row_handle As Integer = view.FocusedRowHandle

        BGVStockBOM.BestFitColumns()

        Cursor = Cursors.Default
    End Sub

    Private Sub BViewMatRes_Click(sender As Object, e As EventArgs) Handles BViewMatRes.Click
        Cursor = Cursors.WaitCursor
        BGVStockRes.Columns.Clear()
        BGVStockRes.Bands.Clear()
        BGVStockRes.Appearance.BandPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        id_mat_selected = "-1"
        Try
            id_mat_selected = SLEResMat.EditValue.ToString
        Catch ex As Exception
        End Try

        id_mat_image = "0"

        Dim band_ref As DevExpress.XtraGrid.Views.BandedGrid.GridBand = BGVStockRes.Bands.AddBand("Reff")
        Dim band_qty As DevExpress.XtraGrid.Views.BandedGrid.GridBand = BGVStockRes.Bands.AddBand("Quantity")
        Dim band_amount As DevExpress.XtraGrid.Views.BandedGrid.GridBand = BGVStockRes.Bands.AddBand("Amount")
        Dim band_stat As DevExpress.XtraGrid.Views.BandedGrid.GridBand = BGVStockRes.Bands.AddBand("")

        BGVStockRes.OptionsView.GroupFooterShowMode = DevExpress.XtraGrid.Views.Grid.GroupFooterShowMode.VisibleAlways

        band_stat.AutoFillDown = True
        Dim query As String = "CALL view_mat_stock_res('" + id_mat_selected + "') "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        For i As Integer = 0 To data.Columns.Count - 1
            If data.Columns(i).ColumnName.ToString = "design_display_name" Or data.Columns(i).ColumnName.ToString = "design_code" Or data.Columns(i).ColumnName.ToString = "note" Or data.Columns(i).ColumnName.ToString = "id_mat_det" Or data.Columns(i).ColumnName.ToString = "id_report" Or data.Columns(i).ColumnName.ToString = "report_mark_type" Or data.Columns(i).ColumnName.ToString = "id_storage_category" Or data.Columns(i).ColumnName.ToString = "date" Then
                If data.Columns(i).ColumnName.ToString = "design_display_name" Then
                    band_ref.Columns.Add(BGVStockRes.Columns.AddVisible(data.Columns(i).ColumnName.ToString, "Design"))
                ElseIf data.Columns(i).ColumnName.ToString = "design_code" Then
                    band_ref.Columns.Add(BGVStockRes.Columns.AddVisible(data.Columns(i).ColumnName.ToString, "Design Code"))
                ElseIf data.Columns(i).ColumnName.ToString = "note" Then
                    band_ref.Columns.Add(BGVStockRes.Columns.AddVisible(data.Columns(i).ColumnName.ToString, "Note"))
                Else
                    band_ref.Columns.Add(BGVStockRes.Columns.AddVisible(data.Columns(i).ColumnName.ToString, data.Columns(i).ColumnName.ToString))
                End If
            ElseIf data.Columns(i).ColumnName.ToString = "Status" Then
                band_stat.Columns.Add(BGVStockRes.Columns.AddVisible(data.Columns(i).ColumnName.ToString, "Status"))
                BGVStockRes.Columns(data.Columns(i).ColumnName.ToString).AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
                BGVStockRes.Columns(data.Columns(i).ColumnName.ToString).AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
            ElseIf data.Columns(i).ColumnName.ToString = "qty" Then
                band_qty.Columns.Add(BGVStockRes.Columns.AddVisible(data.Columns(i).ColumnName.ToString, "Quantity"))
                BGVStockRes.Columns(data.Columns(i).ColumnName.ToString).AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
                BGVStockRes.Columns(data.Columns(i).ColumnName.ToString).DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                BGVStockRes.Columns(data.Columns(i).ColumnName.ToString).DisplayFormat.FormatString = "{0:n2}"
            Else
                If data.Columns(i).ColumnName.ToString = "amount" Then
                    band_amount.Columns.Add(BGVStockRes.Columns.AddVisible(data.Columns(i).ColumnName.ToString, "Amount"))
                Else
                    band_amount.Columns.Add(BGVStockRes.Columns.AddVisible(data.Columns(i).ColumnName.ToString, data.Columns(i).ColumnName.ToString))
                End If
                BGVStockRes.Columns(data.Columns(i).ColumnName.ToString).AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
                BGVStockRes.Columns(data.Columns(i).ColumnName.ToString).DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                BGVStockRes.Columns(data.Columns(i).ColumnName.ToString).DisplayFormat.FormatString = "{0:n2}"
            End If
        Next

        BGCStockRes.DataSource = data
        dt = data

        'hide column
        BGVStockRes.Columns("id_report").Visible = False
        BGVStockRes.Columns("report_mark_type").Visible = False
        BGVStockRes.Columns("id_mat_det").Visible = False
        BGVStockRes.Columns("id_storage_category").Visible = False

        'enable group
        BGCStockRes.Enabled = True
        GCRes.Enabled = True

        Dim view As DevExpress.XtraGrid.Views.Grid.GridView = SLEResMat.Properties.View
        Dim row_handle As Integer = view.FocusedRowHandle

        BGVStockRes.BestFitColumns()

        Cursor = Cursors.Default
    End Sub
End Class