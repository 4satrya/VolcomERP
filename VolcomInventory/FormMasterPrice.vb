Public Class FormMasterPrice
    Dim bnew_active As String = "1"
    Dim bedit_active As String = "1"
    Dim bdel_active As String = "1"
    Dim super_user As String = get_setup_field("id_role_super_admin")
    Public is_price_list As Boolean = False

    Private Sub FormMasterPrice_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        viewSeason()
        viewClass()

        'set default
        Dim dt_now As DataTable = execute_query("SELECT DATE(NOW()) as tgl", -1, True, "", "", "", "")
        DEFrom.EditValue = dt_now.Rows(0)("tgl")
        DEFromList.EditValue = dt_now.Rows(0)("tgl")
        DEUntilList.EditValue = dt_now.Rows(0)("tgl")

        If is_price_list Then
            XTPImport.PageVisible = False
        End If
    End Sub

    Sub viewSeason()
        Dim query As String = ""
        query += "SELECT (0) AS `id_season`, (0) AS `range`, ('All Season') AS `season` UNION ALL "
        query += "(SELECT a.id_season, b.range, a.season FROM tb_season a "
        query += "INNER JOIN tb_range b ON a.id_range = b.id_range "
        query += "ORDER BY b.range DESC) "
        viewSearchLookupQuery(SLESeason, query, "id_season", "season", "id_season")
        viewSearchLookupQuery(SLESeasonHistDet, query, "id_season", "season", "id_season")
        viewSearchLookupQuery(SLESeasonHistSum, query, "id_season", "season", "id_season")
    End Sub

    Sub viewClass()
        Dim id_code_class As String = get_setup_field("id_code_fg_class")
        Dim query As String = "SELECT 0 AS `id_class`, 'All Class' AS `class`, 'All' AS `class_display_name`
        UNION
        SELECT cd.id_code_detail AS `id_class`, cd.code_detail_name AS `class`, cd.display_name AS `class_display_name` 
        FROM tb_m_code_detail cd
        WHERE cd.id_code=" + id_code_class + " "
        viewSearchLookupQuery(SLEClass, query, "id_class", "class_display_name", "id_class")
        viewSearchLookupQuery(SLEClassHistDet, query, "id_class", "class_display_name", "id_class")
        viewSearchLookupQuery(SLEClassHistSum, query, "id_class", "class_display_name", "id_class")
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
        viewSearchLookupQuery(SLEDelHistDet, query, "id_delivery", "delivery", "id_delivery")
        viewSearchLookupQuery(SLEDelHistSum, query, "id_delivery", "delivery", "id_delivery")
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
        If SLEClass.EditValue.ToString <> "0" Then
            cond += "AND prod.`Product Class_display`=''" + SLEClass.Text.ToString + "'' "
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

    Private Sub BtnViewHistDet_Click(sender As Object, e As EventArgs) Handles BtnViewHistDet.Click
        viewHistDetail()
    End Sub

    Sub viewHistDetail()
        'season
        Dim cond_season As String = ""
        Dim id_season As String = SLESeasonHistDet.EditValue.ToString
        If id_season <> "0" Then
            cond_season = "AND d.id_season='" + id_season + "' "
        End If

        'del
        Dim cond_del As String = ""
        Dim id_delivery As String = SLEDelHistDet.EditValue.ToString
        If id_delivery <> "0" Then
            cond_del = "AND d.id_delivery='" + id_delivery + "' "
        End If

        'class
        Dim cond_class As String = ""
        Dim id_class As String = SLEClassHistDet.EditValue.ToString
        If id_class <> "0" Then
            cond_class = "AND cls.id_class='" + id_class + "' "
        End If

        'qquery
        Dim query As String = "SELECT d.id_design, d.design_code AS `code`, d.design_display_name AS `name`, sc.size_chart, cls.class,ss.season, sd.delivery,
        prc.design_price,pt.design_price_type, dstt.design_cat, LEFT(dstt.design_cat,1) AS `design_cat_view`, prc.design_price_start_date
        FROM tb_m_design_price prc
        INNER JOIN tb_m_design d ON d.id_design = prc.id_design
        LEFT JOIN (
	        SELECT dc.id_design, cd.id_code_detail AS `id_class`, cd.display_name AS `class` 
	        FROM tb_m_design_code dc
	        INNER JOIN tb_m_code_detail cd ON cd.id_code_detail = dc.id_code_detail AND cd.id_code IN (SELECT o.id_code_fg_class FROM tb_opt o)
	        GROUP BY dc.id_design
        ) cls ON cls.id_design = d.id_design
        INNER JOIN tb_lookup_design_price_type pt ON pt.id_design_price_type = prc.id_design_price_type
        INNER JOIN tb_lookup_design_cat dstt ON dstt.id_design_cat = pt.id_design_cat
        LEFT JOIN (
	        SELECT d.id_design, GROUP_CONCAT(DISTINCT cd.code_detail_name ORDER BY cd.id_code_detail ASC) AS `size_chart`
	        FROM tb_m_product p
	        INNER JOIN tb_m_product_code pc ON pc.id_product = p.id_product
	        INNER JOIN tb_m_code_detail cd ON cd.id_code_detail = pc.id_code_detail
	        INNER JOIN tb_m_design d ON d.id_design = p.id_design
	        GROUP BY d.id_design
        ) sc ON sc.id_design = d.id_design
        INNER JOIN tb_season ss ON ss.id_season = d.id_season
        INNER JOIN tb_season_delivery sd ON sd.id_delivery = d.id_delivery
        WHERE d.id_lookup_status_order!=2 
        " + cond_season + "
        " + cond_del + "
        " + cond_class + "
        ORDER BY cls.class ASC, d.id_design ASC,prc.design_price_start_date ASC "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCHistDet.DataSource = data
    End Sub

    Private Sub BtnExportToXLSHistDetail_Click(sender As Object, e As EventArgs) Handles BtnExportToXLSHistDetail.Click
        If GVHistDet.RowCount > 0 Then
            Cursor = Cursors.WaitCursor
            Dim path As String = Application.StartupPath & "\download\"
            'create directory if not exist
            If Not IO.Directory.Exists(path) Then
                System.IO.Directory.CreateDirectory(path)
            End If
            path = path + "pl_hist_detail.xlsx"
            exportToXLS(path, "detail", GCHistDet)
            Cursor = Cursors.Default
        End If
    End Sub

    Sub exportToXLS(ByVal path_par As String, ByVal sheet_name_par As String, ByVal gc_par As DevExpress.XtraGrid.GridControl)
        Cursor = Cursors.WaitCursor
        Dim path As String = path_par

        ' Customize export options 
        CType(gc_par.MainView, DevExpress.XtraGrid.Views.Grid.GridView).OptionsPrint.PrintHeader = True
        Dim advOptions As DevExpress.XtraPrinting.XlsxExportOptionsEx = New DevExpress.XtraPrinting.XlsxExportOptionsEx()
        advOptions.AllowSortingAndFiltering = DevExpress.Utils.DefaultBoolean.False
        advOptions.ShowGridLines = DevExpress.Utils.DefaultBoolean.False
        advOptions.AllowGrouping = DevExpress.Utils.DefaultBoolean.True
        advOptions.ShowTotalSummaries = DevExpress.Utils.DefaultBoolean.True
        advOptions.SheetName = sheet_name_par
        advOptions.ExportType = DevExpress.Export.ExportType.DataAware

        Try
            gc_par.ExportToXlsx(path, advOptions)
            Process.Start(path)
            ' Open the created XLSX file with the default application. 
        Catch ex As Exception
            stopCustom(ex.ToString)
        End Try
        Cursor = Cursors.Default
    End Sub

    Private Sub BtnExportToXLS_Click(sender As Object, e As EventArgs) Handles BtnExportToXLS.Click
        If GVBrowsePrice.RowCount > 0 Then
            Cursor = Cursors.WaitCursor
            Dim path As String = Application.StartupPath & "\download\"
            'create directory if not exist
            If Not IO.Directory.Exists(path) Then
                System.IO.Directory.CreateDirectory(path)
            End If
            path = path + "pl_active.xlsx"
            exportToXLS(path, "active price", GCBrowsePrice)
            Cursor = Cursors.Default
        End If
    End Sub

    Private Sub FormMasterPrice_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.F7 And XTCBrowse.SelectedTabPageIndex = 2 Then
            FormMenuAuth.type = "4"
            FormMenuAuth.ShowDialog()
        End If
    End Sub

    Private Sub BtnExportToXLSHistSum_Click(sender As Object, e As EventArgs) Handles BtnExportToXLSHistSum.Click
        If GVHistSummary.RowCount > 0 Then
            Cursor = Cursors.WaitCursor
            Dim path As String = Application.StartupPath & "\download\"
            'create directory if not exist
            If Not IO.Directory.Exists(path) Then
                System.IO.Directory.CreateDirectory(path)
            End If
            path = path + "pl_hist_summary.xlsx"
            exportToXLS(path, "summary", GCHistSummary)
            Cursor = Cursors.Default
        End If
    End Sub

    Private Sub BtnViewHistSum_Click(sender As Object, e As EventArgs) Handles BtnViewHistSum.Click
        viewHistSummary()
    End Sub

    Sub viewHistSummary()
        'season
        Dim cond_season As String = ""
        Dim id_season As String = SLESeasonHistSum.EditValue.ToString
        If id_season <> "0" Then
            cond_season = "AND d.id_season='" + id_season + "' "
        End If

        'del
        Dim cond_del As String = ""
        Dim id_delivery As String = SLEDelHistSum.EditValue.ToString
        If id_delivery <> "0" Then
            cond_del = "AND d.id_delivery='" + id_delivery + "' "
        End If

        'class
        Dim cond_class As String = ""
        Dim id_class As String = SLEClassHistSum.EditValue.ToString
        If id_class <> "0" Then
            cond_class = "AND cls.id_class='" + id_class + "' "
        End If

        Dim query As String = "SELECT d.id_design,d.design_code AS `code`, d.design_display_name AS `name`, sc.size_chart, cls.id_class,cls.class, src.id_source, src.`source`, LEFT(last_prc.design_cat,1) AS `design_cat_view`,ss.season, sd.delivery,
        IF(d.final_is_approve=1, d.design_cop,0) AS `cost`, IFNULL(np.design_price,0) AS `normal_price`, IFNULL(mp.design_price,0) AS `mkd_price`, 
        IFNULL(ep.design_price,0) AS `eos_price`, IFNULL(sp.design_price,0) AS `sale_price`, last_prc.design_price_date AS `last_updated`
        FROM tb_m_design d
        LEFT JOIN (
	        SELECT d.id_design, GROUP_CONCAT(DISTINCT cd.code_detail_name ORDER BY cd.id_code_detail ASC) AS `size_chart`
	        FROM tb_m_product p
	        INNER JOIN tb_m_product_code pc ON pc.id_product = p.id_product
	        INNER JOIN tb_m_code_detail cd ON cd.id_code_detail = pc.id_code_detail
	        INNER JOIN tb_m_design d ON d.id_design = p.id_design
	        GROUP BY d.id_design
        ) sc ON sc.id_design = d.id_design
        LEFT JOIN (
	        SELECT dc.id_design, cd.id_code_detail AS `id_class`, cd.display_name AS `class` 
	        FROM tb_m_design_code dc
	        INNER JOIN tb_m_code_detail cd ON cd.id_code_detail = dc.id_code_detail AND cd.id_code IN (SELECT o.id_code_fg_class FROM tb_opt o)
	        GROUP BY dc.id_design
        ) cls ON cls.id_design = d.id_design
        LEFT JOIN (
	        SELECT dc.id_design, cd.id_code_detail AS `id_source`,cd.display_name AS `source` 
	        FROM tb_m_design_code dc
	        INNER JOIN tb_m_code_detail cd ON cd.id_code_detail = dc.id_code_detail AND cd.id_code IN (SELECT o.id_code_fg_source FROM tb_opt o)
	        GROUP BY dc.id_design
        ) src ON src.id_design = d.id_design
        INNER JOIN tb_season ss ON ss.id_season = d.id_season
        INNER JOIN tb_season_delivery sd ON sd.id_delivery = d.id_delivery
        LEFT JOIN (
	        SELECT * FROM (
		        SELECT prc.id_design, prc.design_price 
		        FROM tb_m_design_price prc
		        WHERE prc.design_price>0 AND prc.id_design_price_type=1 AND prc.design_price_start_date<=NOW()
		        ORDER BY prc.design_price_start_date DESC, prc.id_design_price DESC
	        ) p
	        GROUP BY p.id_design
        ) np ON np.id_design = d.id_design
        LEFT JOIN (
	        SELECT * FROM (
		        SELECT prc.id_design, prc.design_price 
		        FROM tb_m_design_price prc
		        WHERE prc.design_price>0 AND prc.id_design_price_type=2 AND prc.design_price_start_date<=NOW()
		        ORDER BY prc.design_price_start_date DESC, prc.id_design_price DESC
	        ) p
	        GROUP BY p.id_design
        ) mp ON mp.id_design = d.id_design
        LEFT JOIN (
	        SELECT * FROM (
		        SELECT prc.id_design, prc.design_price 
		        FROM tb_m_design_price prc
		        WHERE prc.design_price>0 AND prc.id_design_price_type=3 AND prc.design_price_start_date<=NOW()
		        ORDER BY prc.design_price_start_date DESC, prc.id_design_price DESC
	        ) p
	        GROUP BY p.id_design
        ) ep ON ep.id_design = d.id_design
        LEFT JOIN (
	        SELECT * FROM (
		        SELECT prc.id_design, prc.design_price 
		        FROM tb_m_design_price prc
		        WHERE prc.design_price>0 AND prc.id_design_price_type=4 AND prc.design_price_start_date<=NOW()
		        ORDER BY prc.design_price_start_date DESC, prc.id_design_price DESC
	        ) p
	        GROUP BY p.id_design
        ) sp ON sp.id_design = d.id_design
        LEFT JOIN( 
          Select * FROM ( 
	          Select price.id_design, price.design_price, price.design_price_date, price.id_design_price, 
	          price.id_design_price_type, price_type.design_price_type,
	          cat.id_design_cat, cat.design_cat
	          From tb_m_design_price price 
	          INNER Join tb_lookup_design_price_type price_type On price.id_design_price_type = price_type.id_design_price_type 
	          INNER JOIN tb_lookup_design_cat cat ON cat.id_design_cat = price_type.id_design_cat
	          WHERE price.is_active_wh =1 AND price.design_price_start_date <= NOW() 
	          ORDER BY price.design_price_start_date DESC, price.id_design_price DESC 
          ) a 
          GROUP BY a.id_design 
        ) last_prc ON last_prc.id_design = d.id_design 
         WHERE d.id_lookup_status_order!=2 
        " + cond_season + "
        " + cond_del + "
        " + cond_class + "
        ORDER BY cls.class ASC, d.id_design ASC "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCHistSummary.DataSource = data
    End Sub
End Class