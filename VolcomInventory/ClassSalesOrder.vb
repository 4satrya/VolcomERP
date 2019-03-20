Imports Microsoft.Office.Interop

Public Class ClassSalesOrder
    Public Function queryMain(ByVal condition As String, ByVal order_type As String) As String
        If order_type = "1" Then
            order_type = "ASC "
        ElseIf order_type = "2" Then
            order_type = "DESC "
        End If

        If condition <> "-1" Then
            condition = condition
        Else
            condition = ""
        End If

        Dim query As String = "SELECT a.id_sales_order, a.id_store_contact_to, d.id_commerce_type,d.id_comp AS `id_store`, d.is_use_unique_code, d.id_store_type, d.comp_number AS `store_number`, d.comp_name AS `store`, d.address_primary as `store_address`, CONCAT(d.comp_number,' - ',d.comp_name) AS store_name_to,a.id_report_status, f.report_status, a.id_warehouse_contact_to, CONCAT(wh.comp_number,' - ',wh.comp_name) AS warehouse_name_to, (wh.comp_number) AS warehouse_number_to,  (wh.comp_name) AS `warehouse`, wh.id_drawer_def AS `id_wh_drawer`, drw.wh_drawer_code, drw.wh_drawer, "
        query += "a.sales_order_note, a.sales_order_date, a.sales_order_note, a.sales_order_number, a.sales_order_ol_shop_number, "
        query += "(a.sales_order_date) AS sales_order_date, "
        query += "ps.id_prepare_status, ps.prepare_status, ('No') AS `is_select`, cat.id_so_status, cat.so_status, del_cat.id_so_cat, del_cat.so_cat, IFNULL(so_item.tot_so,0.00) AS `total_order`,IF(a.id_so_status!='5', IFNULL(ots.outstanding,0), IFNULL(otstrf.outstanding,0)) AS `outstanding`, "
        query += "IF(a.id_so_status!='5',CAST((IFNULL(dord_item.tot_do, 0.00)/IFNULL(so_item.tot_so,0.00)*100) AS DECIMAL(5,2)), CAST((IFNULL(trf_item.tot_trf, 0.00)/IFNULL(so_item.tot_so,0.00)*100) AS DECIMAL(5,2))) AS so_completness,  "
        query += "IFNULL(an.fg_so_reff_number,'-') AS `fg_so_reff_number`,a.id_so_type,prep.id_user, prep.prepared_date, "
        query += "IFNULL(crt.created, 0) AS created_process, "
        query += "gen.id_sales_order_gen, IFNULL(gen.sales_order_gen_reff, '-') AS `sales_order_gen_reff`, a.final_comment, a.final_date, fe.employee_name AS `final_by_name`, eu.period_name, ut.uni_type, ube.employee_code, ube.employee_name, lp.printed_date, IFNULL(lp.printed_by,'-') AS `printed_by` "
        query += "FROM tb_sales_order a "
        query += "INNER JOIN tb_m_comp_contact c ON c.id_comp_contact = a.id_store_contact_to "
        query += "INNER JOIN tb_m_comp d ON c.id_comp = d.id_comp "
        query += "INNER JOIN tb_m_comp_contact wh_c ON wh_c.id_comp_contact = a.id_warehouse_contact_to "
        query += "INNER JOIN tb_m_comp wh ON wh_c.id_comp = wh.id_comp "
        query += "INNER JOIN tb_lookup_report_status f ON f.id_report_status = a.id_report_status "
        query += "INNER JOIN tb_lookup_prepare_status ps ON ps.id_prepare_status = a.id_prepare_status "
        query += "INNER JOIN tb_lookup_so_status cat ON cat.id_so_status = a.id_so_status "
        query += "LEFT JOIN ( "
        query += "SELECT so_det.id_sales_order, SUM(so_det.sales_order_det_qty) AS tot_so  "
        query += "FROM tb_sales_order_det so_det "
        query += "GROUP BY so_det.id_sales_order "
        query += ") so_item ON so_item.id_sales_order = a.id_sales_order "
        query += "LEFT JOIN ( "
        query += "SELECT dord.id_sales_order, SUM(dord_det.pl_sales_order_del_det_qty) AS tot_do "
        query += "FROM tb_pl_sales_order_del_det dord_det "
        query += "INNER JOIN tb_pl_sales_order_del dord ON dord.id_pl_sales_order_del = dord_det.id_pl_sales_order_del "
        query += "WHERE dord.id_report_status='6' "
        query += "GROUP BY dord.id_sales_order "
        query += ") dord_item ON dord_item.id_sales_order = a.id_sales_order "
        query += "LEFT JOIN ( "
        query += "SELECT trf.id_sales_order, SUM(trf_det.fg_trf_det_qty) AS tot_trf "
        query += "FROM tb_fg_trf_det trf_det "
        query += "INNER JOIN tb_fg_trf trf ON trf.id_fg_trf = trf_det.id_fg_trf "
        query += "WHERE trf.id_report_status='6' "
        query += "GROUP BY trf.id_sales_order "
        query += ") trf_item ON trf_item.id_sales_order = a.id_sales_order "
        query += "Left Join( "
        query += "Select a.id_report, a.id_user, a.report_mark_datetime AS `prepared_date` "
        query += "From tb_report_mark a "
        query += "Where a.report_mark_type ='39' and a.id_report_status='1' "
        query += "group by a.id_report "
        query += ") prep On prep.id_report = a.id_sales_order "
        query += "LEFT JOIN tb_fg_so_reff an On an.id_fg_so_reff = a.id_fg_so_reff "
        query += "LEFT JOIN tb_lookup_pd_alloc alloc On alloc.id_pd_alloc = d.id_pd_alloc "
        query += "LEFT JOIN tb_lookup_so_cat del_cat On del_cat.id_so_cat = alloc.id_so_cat "
        query += "Left Join( "
        query += "Select id_sales_order, COUNT(*) As created FROM tb_pl_sales_order_del GROUP BY id_sales_order "
        query += "UNION ALL "
        query += "Select id_sales_order, COUNT(*) As created FROM tb_fg_trf GROUP BY id_sales_order "
        query += ") crt On crt.id_sales_order = a.id_sales_order "
        query += "LEFT JOIN tb_sales_order_gen gen ON gen.id_sales_order_gen = a.id_sales_order_gen "
        query += "LEFT JOIN tb_m_wh_drawer drw ON drw.id_wh_drawer = wh.id_drawer_def "
        query += "LEFT JOIN (
        SELECT del.id_sales_order,COUNT(*) AS `outstanding` FROM tb_pl_sales_order_del del
        WHERE del.id_report_status!=5 AND del.id_report_status!=6
        GROUP BY del.id_sales_order
        ) ots ON ots.id_sales_order = a.id_sales_order "
        query += "LEFT JOIN (
        SELECT trf.id_sales_order,COUNT(*) AS `outstanding` FROM tb_fg_trf trf
        WHERE trf.id_report_status!=5 AND trf.id_report_status!=6
        GROUP BY trf.id_sales_order
        ) otstrf ON otstrf.id_sales_order = a.id_sales_order "
        query += "LEFT JOIN tb_m_user fu ON fu.id_user = a.final_by "
        query += "LEFT JOIN tb_m_employee fe ON fe.id_employee = fu.id_employee "
        query += "LEFT JOIN tb_emp_uni_period eu ON eu.id_emp_uni_period=a.id_emp_uni_period 
        LEFT JOIN tb_lookup_uni_type ut ON ut.id_uni_type = a.id_uni_type 
        LEFT JOIN tb_emp_uni_budget ub ON ub.id_emp_uni_budget = a.id_emp_uni_budget
        LEFT JOIN tb_m_employee ube ON ube.id_employee = ub.id_employee 
        LEFT JOIN (
            SELECT a.id_sales_order, a.log_date AS `printed_date`, e.employee_name AS `printed_by` 
            FROM (
	            SELECT * FROM tb_sales_order_log_print lp
	            ORDER BY lp.log_date ASC
            ) a 
            INNER JOIN tb_m_user u ON u.id_user = a.id_user
            INNER JOIN tb_m_employee e ON e.id_employee = u.id_employee
            GROUP BY a.id_sales_order
        ) lp ON lp.id_sales_order = a.id_sales_order "
        query += "WHERE a.id_sales_order>0 "
        query += condition + " "
        query += "ORDER BY a.id_sales_order " + order_type
        Return query
    End Function

    Public Function queryMainGen(ByVal condition As String, ByVal order_type As String) As String
        If order_type = "1" Then
            order_type = "ASC "
        ElseIf order_type = "2" Then
            order_type = "DESC "
        End If

        If condition <> "-1" Then
            condition = condition
        Else
            condition = ""
        End If

        Dim query As String = "Select gen.id_sales_order_gen, gen.id_so_status, cat.so_status, gen.sales_order_gen_reff, "
        query += "gen.sales_order_gen_date, DATE_FORMAT(gen.sales_order_gen_date,'%Y-%m-%d') AS sales_order_gen_datex, "
        query += "gen.id_report_status, rep.report_status, gen.is_submit, gen.sales_order_gen_note "
        query += "FROM tb_sales_order_gen gen "
        query += "INNER JOIN tb_lookup_so_status cat ON cat.id_so_status = gen.id_so_status "
        query += "INNER JOIN tb_lookup_report_status rep ON rep.id_report_status = gen.id_report_status "
        query += "WHERE gen.id_sales_order_gen>0 "
        query += condition + " "
        query += "ORDER BY gen.id_sales_order_gen " + order_type
        Return query
    End Function

    Public Sub viewReff(ByVal id As String, ByVal cond_par As String, ByVal GCNewPrepare As DevExpress.XtraGrid.GridControl, ByVal GVNewPrepare As DevExpress.XtraGrid.Views.BandedGrid.AdvBandedGridView)
        'prepare
        Dim query_c As ClassDesign = New ClassDesign()
        Dim data_band_break_plan As DataTable = query_c.getBreakTotalLineList("4")

        GCNewPrepare.DataSource = Nothing
        GCNewPrepare.RepositoryItems.Clear()
        GCNewPrepare.RefreshDataSource()
        GVNewPrepare.ApplyFindFilter("")
        GVNewPrepare.ColumnPanelRowHeight = 40
        GVNewPrepare.Columns.Clear()
        GVNewPrepare.GroupSummary.Clear()
        GVNewPrepare.Bands.Clear()
        GVNewPrepare.Appearance.BandPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        GVNewPrepare.OptionsBehavior.AutoExpandAllGroups = True

        ' Make the group footers always visible.
        GVNewPrepare.OptionsView.GroupFooterShowMode = DevExpress.XtraGrid.Views.Grid.GroupFooterShowMode.VisibleAlways

        'create band
        Dim band_desc As DevExpress.XtraGrid.Views.BandedGrid.GridBand = GVNewPrepare.Bands.AddBand("DESCRIPTION")
        band_desc.AppearanceHeader.Font = New Font(GVNewPrepare.Appearance.Row.Font.FontFamily, GVNewPrepare.Appearance.Row.Font.Size, FontStyle.Bold)
        Dim band_break As DevExpress.XtraGrid.Views.BandedGrid.GridBand = GVNewPrepare.Bands.AddBand("BREAKDOWN SIZE")
        band_break.AppearanceHeader.Font = New Font(GVNewPrepare.Appearance.Row.Font.FontFamily, GVNewPrepare.Appearance.Row.Font.Size, FontStyle.Bold)
        Dim band_total As DevExpress.XtraGrid.Views.BandedGrid.GridBand = GVNewPrepare.Bands.AddBand("")
        band_total.AppearanceHeader.Font = New Font(GVNewPrepare.Appearance.Row.Font.FontFamily, GVNewPrepare.Appearance.Row.Font.Size, FontStyle.Bold)

        'declare band for merge coluumn
        Dim band_arr() As DevExpress.XtraGrid.Views.BandedGrid.GridBand = Nothing
        Dim band_alloc_break() As DevExpress.XtraGrid.Views.BandedGrid.GridBand = Nothing

        'declare arr to store break sizw column initial
        Dim break_alloc_initial As New List(Of String)

        'query
        Dim query As String = "CALL view_sales_order_reff('" + id + "','" + cond_par + "') "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")


        'rep
        Dim riTE As DevExpress.XtraEditors.Repository.RepositoryItemTextEdit = New DevExpress.XtraEditors.Repository.RepositoryItemTextEdit
        riTE.NullText = "-"
        GCNewPrepare.RepositoryItems.Add(riTE)


        'properties column
        GVNewPrepare.BeginUpdate()

        'setup band size total
        band_break.Columns.Add(GVNewPrepare.Columns.AddVisible("brk_1", ""))
        band_break.Columns.Add(GVNewPrepare.Columns.AddVisible("brk_2", ""))
        band_break.Columns.Add(GVNewPrepare.Columns.AddVisible("brk_3", ""))
        band_break.Columns.Add(GVNewPrepare.Columns.AddVisible("brk_4", ""))
        GVNewPrepare.SetColumnPosition(GVNewPrepare.Columns("brk_1"), 0, 0)
        GVNewPrepare.SetColumnPosition(GVNewPrepare.Columns("brk_2"), 1, 0)
        GVNewPrepare.SetColumnPosition(GVNewPrepare.Columns("brk_3"), 2, 0)
        GVNewPrepare.SetColumnPosition(GVNewPrepare.Columns("brk_4"), 3, 0)

        'var bantu utk band dinamis
        Dim i_break As Integer = 0


        For i As Integer = 0 To data.Columns.Count - 1
            If data.Columns(i).ColumnName.ToString = "QTY" Then
                band_total.Columns.Add(GVNewPrepare.Columns.AddVisible(data.Columns(i).ColumnName.ToString, data.Columns(i).ColumnName.ToString))
                'properties
                GVNewPrepare.Columns(data.Columns(i).ColumnName.ToString).AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
                GVNewPrepare.Columns(data.Columns(i).ColumnName.ToString).AppearanceHeader.Font = New Font(GVNewPrepare.Appearance.Row.Font.FontFamily, GVNewPrepare.Appearance.Row.Font.Size, FontStyle.Bold)

                GVNewPrepare.Columns(data.Columns(i).ColumnName.ToString).AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
                GVNewPrepare.Columns(data.Columns(i).ColumnName.ToString).DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                GVNewPrepare.Columns(data.Columns(i).ColumnName.ToString).DisplayFormat.FormatString = "{0:n0}"

                GVNewPrepare.Columns(data.Columns(i).ColumnName.ToString).SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
                GVNewPrepare.Columns(data.Columns(i).ColumnName.ToString).SummaryItem.DisplayFormat = "{0:n0}"

                Dim item As DevExpress.XtraGrid.GridGroupSummaryItem = New DevExpress.XtraGrid.GridGroupSummaryItem()
                item.FieldName = data.Columns(i).ColumnName.ToString
                item.SummaryType = DevExpress.Data.SummaryItemType.Sum
                item.DisplayFormat = "{0:n0}"
                item.ShowInGroupColumnFooter = GVNewPrepare.Columns(data.Columns(i).ColumnName.ToString)
                GVNewPrepare.GroupSummary.Add(item)
                GVNewPrepare.Columns(data.Columns(i).ColumnName.ToString).AutoFillDown = True
            ElseIf Not data.Columns(i).ColumnName.ToString.Contains("_qty") Then
                band_desc.Columns.Add(GVNewPrepare.Columns.AddVisible(data.Columns(i).ColumnName.ToString, data.Columns(i).ColumnName.ToString))
                GVNewPrepare.Columns(data.Columns(i).ColumnName.ToString).AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
                GVNewPrepare.Columns(data.Columns(i).ColumnName.ToString).AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
                GVNewPrepare.Columns(data.Columns(i).ColumnName.ToString).AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
                GVNewPrepare.Columns(data.Columns(i).ColumnName.ToString).AppearanceHeader.Font = New Font(GVNewPrepare.Appearance.Row.Font.FontFamily, GVNewPrepare.Appearance.Row.Font.Size, FontStyle.Bold)
                GVNewPrepare.Columns(data.Columns(i).ColumnName.ToString).AutoFillDown = True
            Else
                i_break += 1
                Dim st_caption As String = data.Columns(i).ColumnName.ToString.Length - 4
                band_break.Columns.Add(GVNewPrepare.Columns.AddVisible(data.Columns(i).ColumnName.ToString, data.Columns(i).ColumnName.ToString.Substring(0, st_caption)))

                'size position
                Dim data_filter As DataRow() = data_band_break_plan.Select("[display_name]='" + data.Columns(i).ColumnName.ToString + "'")
                GVNewPrepare.SetColumnPosition(GVNewPrepare.Columns(data.Columns(i).ColumnName.ToString), data_filter(0)("code_row_index").ToString, data_filter(0)("code_col_index").ToString)

                'properties
                GVNewPrepare.Columns(data.Columns(i).ColumnName.ToString).AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
                GVNewPrepare.Columns(data.Columns(i).ColumnName.ToString).AppearanceHeader.Font = New Font(GVNewPrepare.Appearance.Row.Font.FontFamily, GVNewPrepare.Appearance.Row.Font.Size, FontStyle.Bold)

                GVNewPrepare.Columns(data.Columns(i).ColumnName.ToString).AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
                GVNewPrepare.Columns(data.Columns(i).ColumnName.ToString).DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                GVNewPrepare.Columns(data.Columns(i).ColumnName.ToString).DisplayFormat.FormatString = "{0:n0}"

                GVNewPrepare.Columns(data.Columns(i).ColumnName.ToString).SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
                GVNewPrepare.Columns(data.Columns(i).ColumnName.ToString).SummaryItem.DisplayFormat = "{0:n0}"

                Dim item As DevExpress.XtraGrid.GridGroupSummaryItem = New DevExpress.XtraGrid.GridGroupSummaryItem()
                item.FieldName = data.Columns(i).ColumnName.ToString
                item.SummaryType = DevExpress.Data.SummaryItemType.Sum
                item.DisplayFormat = "{0:n0}"
                item.ShowInGroupColumnFooter = GVNewPrepare.Columns(data.Columns(i).ColumnName.ToString)
                GVNewPrepare.GroupSummary.Add(item)

                'repo
                GVNewPrepare.Columns(data.Columns(i).ColumnName.ToString).ColumnEdit = riTE
            End If
        Next

        'dispose column
        GVNewPrepare.Columns("brk_1").Dispose()
        GVNewPrepare.Columns("brk_2").Dispose()
        GVNewPrepare.Columns("brk_3").Dispose()
        GVNewPrepare.Columns("brk_4").Dispose()

        'set datasource
        GVNewPrepare.EndUpdate()
        GCNewPrepare.DataSource = data

        'hide column
        GVNewPrepare.Columns("id_design").Visible = False
        GVNewPrepare.Columns("DESIGN").Visible = False
        GVNewPrepare.Columns("NO").Visible = False

        'order BAND
        GVNewPrepare.Bands.MoveTo(1, band_desc)
        GVNewPrepare.Bands.MoveTo(2, band_break)
        GVNewPrepare.Bands.MoveTo(3, band_total)

        'group
        GVNewPrepare.Columns("DESIGN").GroupIndex = 0
        GVNewPrepare.Columns("DESIGN").FieldNameSortGroup = "id_design"
        GVNewPrepare.GroupFormat = "{1}{2}"

        ' 'hide PBC & Show GRID
        GCNewPrepare.RefreshDataSource()
        GVNewPrepare.RefreshData()

        'clear band array
        band_arr = Nothing
        band_alloc_break = Nothing
        break_alloc_initial.Clear()

        'best Fit
        GVNewPrepare.BestFitColumns()
    End Sub

    '-----------
    'STOCK OUT
    '--------------
    Public Sub reservedStock(ByVal id_report_param As String)
        Dim query As String = "INSERT INTO tb_storage_fg(id_wh_drawer, id_storage_category, id_product, bom_unit_price, report_mark_type, id_report, storage_product_qty, storage_product_datetime, storage_product_notes, id_stock_status) "
        query += "SELECT getCompByContact(so.id_warehouse_contact_to, 4), '2', so_det.id_product, IFNULL(dsg.design_cop,0), '39', '" + id_report_param + "', so_det.sales_order_det_qty, NOW(), '', '2' "
        query += "FROM tb_sales_order so "
        query += "INNER JOIN tb_sales_order_det so_det ON so_det.id_sales_order = so.id_sales_order "
        query += "INNER JOIN tb_m_product prod ON prod.id_product = so_det.id_product "
        query += "INNER JOIN tb_m_design dsg ON dsg.id_design = prod.id_design "
        query += "WHERE so.id_sales_order='" + id_report_param + "' "
        execute_non_query(query, True, "", "", "", "")
    End Sub

    Public Sub cancelReservedStock(ByVal id_report_param As String)
        Dim query As String = "INSERT INTO tb_storage_fg(id_wh_drawer, id_storage_category, id_product, bom_unit_price, report_mark_type, id_report, storage_product_qty, storage_product_datetime, storage_product_notes, id_stock_status) "
        query += "SELECT getCompByContact(so.id_warehouse_contact_to, 4), '1', so_det.id_product, IFNULL(dsg.design_cop,0), '39', '" + id_report_param + "', so_det.sales_order_det_qty, NOW(), '', '2' "
        query += "FROM tb_sales_order so "
        query += "INNER JOIN tb_sales_order_det so_det ON so_det.id_sales_order = so.id_sales_order "
        query += "INNER JOIN tb_m_product prod ON prod.id_product = so_det.id_product "
        query += "INNER JOIN tb_m_design dsg ON dsg.id_design = prod.id_design "
        query += "WHERE so.id_sales_order='" + id_report_param + "' "
        execute_non_query(query, True, "", "", "", "")
    End Sub

    Public Sub cancelReservedStockGen(ByVal id_report_param As String)
        Dim query As String = "INSERT INTO tb_storage_fg(id_wh_drawer, id_storage_category, id_product, bom_unit_price, report_mark_type, id_report, storage_product_qty, storage_product_datetime, storage_product_notes, id_stock_status) "
        query += "SELECT getCompByContact(so.id_warehouse_contact_to, 4), '1', so_det.id_product, IFNULL(dsg.design_cop,0), '39', so.id_sales_order, so_det.sales_order_det_qty, NOW(), '', '2' "
        query += "FROM tb_sales_order so "
        query += "INNER JOIN tb_sales_order_det so_det ON so_det.id_sales_order = so.id_sales_order "
        query += "INNER JOIN tb_m_product prod ON prod.id_product = so_det.id_product "
        query += "INNER JOIN tb_m_design dsg ON dsg.id_design = prod.id_design "
        query += "WHERE so.id_sales_order_gen='" + id_report_param + "' "
        execute_non_query(query, True, "", "", "", "")
    End Sub

    Public Function generateXLSForBOF(ByVal id_so As String) As String
        Dim path_root As String = ""
        Dim bof_xls_so As String = get_setup_field("bof_xls_so_gen")

        Try
            ' Open the file using a stream reader.
            Using sr As New IO.StreamReader(Application.StartupPath & "\bof_path.txt")
                ' Read the stream to a string and write the string to the console.
                path_root = sr.ReadToEnd()
            End Using
        Catch ex As Exception
        End Try

        Dim fileName As String = bof_xls_so + ".xls"
        Dim exp As String = IO.Path.Combine(path_root, fileName)
        Try
            Dim strFileName As String = exp
            If System.IO.File.Exists(strFileName) Then
                System.IO.File.Delete(strFileName)
            End If
            Dim _excel As New Excel.Application
            Dim wBook As Excel.Workbook
            Dim wSheet As Excel.Worksheet

            wBook = _excel.Workbooks.Add()
            wSheet = wBook.ActiveSheet()


            Dim rowIndex As Integer = -1
            Dim query As String = "SELECT prod.product_full_code AS `code`, CAST(sod.sales_order_det_qty  AS DECIMAL(10,0)) AS `qty`,
            so.sales_order_number AS `number`, wh.comp_number AS `from`, s.comp_number AS `to`, sod.sales_order_det_note AS `note`,
            so.sales_order_ol_shop_number AS `order_number`, DATE_FORMAT(so.sales_order_ol_shop_date,'%d/%m/%Y') AS `created_date`, sod.item_id, sod.ol_store_id
            FROM tb_sales_order so
            INNER JOIN tb_sales_order_det sod ON sod.id_sales_order = so.id_sales_order
            INNER JOIN tb_m_product prod ON prod.id_product = sod.id_product
            INNER JOIN tb_m_comp_contact whc ON whc.id_comp_contact = so.id_warehouse_contact_to
            INNER JOIN tb_m_comp wh ON wh.id_comp = whc.id_comp
            INNER JOIN tb_m_comp_contact sc ON sc.id_comp_contact = so.id_store_contact_to
            INNER JOIN tb_m_comp s ON s.id_comp = sc.id_comp
            WHERE so.id_sales_order>0 AND (" + id_so + ") "
            Dim dtTemp As DataTable = execute_query(query, -1, True, "", "", "", "")
            For i As Integer = 0 To dtTemp.Rows.Count - 1
                rowIndex = rowIndex + 1
                wSheet.Cells(rowIndex + 1, 1) = dtTemp.Rows(i)("code").ToString
                wSheet.Cells(rowIndex + 1, 2) = dtTemp.Rows(i)("qty")
                wSheet.Cells(rowIndex + 1, 3) = dtTemp.Rows(i)("number").ToString
                wSheet.Cells(rowIndex + 1, 4) = dtTemp.Rows(i)("from").ToString
                wSheet.Cells(rowIndex + 1, 5) = dtTemp.Rows(i)("to").ToString
                wSheet.Cells(rowIndex + 1, 6) = dtTemp.Rows(i)("note").ToString
                wSheet.Cells(rowIndex + 1, 7) = dtTemp.Rows(i)("order_number").ToString
                wSheet.Cells(rowIndex + 1, 8) = dtTemp.Rows(i)("created_date").ToString
                wSheet.Cells(rowIndex + 1, 9) = dtTemp.Rows(i)("item_id").ToString
                wSheet.Cells(rowIndex + 1, 10) = dtTemp.Rows(i)("ol_store_id").ToString
            Next

            wSheet.Columns.AutoFit()
            wBook.SaveAs(strFileName, Excel.XlFileFormat.xlExcel5)

            'release the objects
            ReleaseObject(wSheet)
            wBook.Close(False)
            ReleaseObject(wBook)
            _excel.Quit()
            ReleaseObject(_excel)
            ' some time Office application does not quit after automation: so i am calling GC.Collect method.
            GC.Collect()

            Return "True"
        Catch ex As Exception
            Return ex.ToString
        End Try
    End Function

    Private Sub ReleaseObject(ByVal o As Object)
        Try
            While (System.Runtime.InteropServices.Marshal.ReleaseComObject(o) > 0)
            End While
        Catch
        Finally
            o = Nothing
        End Try
    End Sub

End Class
