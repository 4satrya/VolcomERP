﻿Public Class FormFGTransList
    Public page_active As String = ""

    Private Sub FormFGTransList_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'date now
        Dim data_dt As DataTable = execute_query("SELECT DATE(NOW()) AS `dt`", -1, True, "", "", "", "")
        DEFromRec.EditValue = data_dt.Rows(0)("dt")
        DEUntilRec.EditValue = data_dt.Rows(0)("dt")
        DEFromDO.EditValue = data_dt.Rows(0)("dt")
        DEUntilDO.EditValue = data_dt.Rows(0)("dt")
        DEFromReturn.EditValue = data_dt.Rows(0)("dt")
        DEUntilReturn.EditValue = data_dt.Rows(0)("dt")
        DEFromReturnQC.EditValue = data_dt.Rows(0)("dt")
        DEUntilReturnQC.EditValue = data_dt.Rows(0)("dt")
        DEFromTrf.EditValue = data_dt.Rows(0)("dt")
        DEUntilTrf.EditValue = data_dt.Rows(0)("dt")
        DEFromNonStock.EditValue = data_dt.Rows(0)("dt")
        DEUntilNonStock.EditValue = data_dt.Rows(0)("dt")
        DEFromSal.EditValue = data_dt.Rows(0)("dt")
        DEUntilSal.EditValue = data_dt.Rows(0)("dt")

        'lookup
        viewPeriodType()

        ActiveControl = DEFromRec
        page_active = "rec"
    End Sub

    Sub viewPeriodType()
        Cursor = Cursors.WaitCursor
        Dim query As String = "SELECT '1' AS `id_period_type`,'Sales Date' AS `period_type`
        UNION
        SELECT '2' AS `id_period_type`,'Entry Date' AS `period_type` "
        viewSearchLookupQuery(SLEPeriodType, query, "id_period_type", "period_type", "id_period_type")
        Cursor = Cursors.Default
    End Sub

    Sub viewRec()
        Cursor = Cursors.WaitCursor
        'Prepare paramater
        Dim date_from_selected As String = "0000-01-01"
        Dim date_until_selected As String = "9999-01-01"
        Try
            date_from_selected = DateTime.Parse(DEFromRec.EditValue.ToString).ToString("yyyy-MM-dd")
        Catch ex As Exception
        End Try

        Try
            date_until_selected = DateTime.Parse(DEUntilRec.EditValue.ToString).ToString("yyyy-MM-dd")
        Catch ex As Exception
        End Try

        'prepare query
        Dim query_c As ClassProductionPLToWHRec = New ClassProductionPLToWHRec()
        Dim data As DataTable = query_c.transactionList("AND (a0.pl_prod_order_rec_date>='" + date_from_selected + "' AND a0.pl_prod_order_rec_date<='" + date_until_selected + "') ", "1")
        GCPL.DataSource = data
        Cursor = Cursors.Default
    End Sub

    Sub viewDO()
        Cursor = Cursors.WaitCursor
        'Prepare paramater
        Dim date_from_selected As String = "0000-01-01"
        Dim date_until_selected As String = "9999-01-01"
        Try
            date_from_selected = DateTime.Parse(DEFromDO.EditValue.ToString).ToString("yyyy-MM-dd")
        Catch ex As Exception
        End Try

        Try
            date_until_selected = DateTime.Parse(DEUntilDO.EditValue.ToString).ToString("yyyy-MM-dd")
        Catch ex As Exception
        End Try

        'prepare query
        Dim query_c As ClassSalesDelOrder = New ClassSalesDelOrder()
        Dim data As DataTable = query_c.transactionList("AND (a.pl_sales_order_del_date>='" + date_from_selected + "' AND a.pl_sales_order_del_date<='" + date_until_selected + "') ", "1")
        GCSalesDelOrder.DataSource = data
        Cursor = Cursors.Default
    End Sub

    Private Sub BtnViewDO_Click(sender As Object, e As EventArgs) Handles BtnViewDO.Click
        viewDO()
    End Sub

    Sub viewReturn()
        Cursor = Cursors.WaitCursor
        'Prepare paramater
        Dim date_from_selected As String = "0000-01-01"
        Dim date_until_selected As String = "9999-01-01"
        Try
            date_from_selected = DateTime.Parse(DEFromReturn.EditValue.ToString).ToString("yyyy-MM-dd")
        Catch ex As Exception
        End Try

        Try
            date_until_selected = DateTime.Parse(DEUntilReturn.EditValue.ToString).ToString("yyyy-MM-dd")
        Catch ex As Exception
        End Try

        'prepare query
        Dim query_c As ClassSalesReturn = New ClassSalesReturn()
        Dim data As DataTable = query_c.transactionList("AND (a.id_ret_type!=2) AND (a.sales_return_date>='" + date_from_selected + "' AND a.sales_return_date<='" + date_until_selected + "') ", "1")
        GCSalesReturn.DataSource = data
        Cursor = Cursors.Default
    End Sub

    Private Sub BtnViewReturn_Click(sender As Object, e As EventArgs) Handles BtnViewReturn.Click
        viewReturn()
    End Sub

    Sub viewNonStock()
        Cursor = Cursors.WaitCursor
        'Prepare paramater
        Dim date_from_selected As String = "0000-01-01"
        Dim date_until_selected As String = "9999-01-01"
        Try
            date_from_selected = DateTime.Parse(DEFromNonStock.EditValue.ToString).ToString("yyyy-MM-dd")
        Catch ex As Exception
        End Try

        Try
            date_until_selected = DateTime.Parse(DEUntilNonStock.EditValue.ToString).ToString("yyyy-MM-dd")
        Catch ex As Exception
        End Try

        'prepare query
        Dim query_c As ClassSalesReturn = New ClassSalesReturn()
        Dim data As DataTable = query_c.transactionListNSI("AND a.id_ret_type=2 AND (a.sales_return_date>='" + date_from_selected + "' AND a.sales_return_date<='" + date_until_selected + "') ", "1")
        GCNonStock.DataSource = data
        Cursor = Cursors.Default
    End Sub

    Private Sub BtnViewNonStock_Click(sender As Object, e As EventArgs) Handles BtnViewNonStock.Click
        viewNonStock()
    End Sub

    Private Sub BtnViewRec_Click(sender As Object, e As EventArgs) Handles BtnViewRec.Click
        viewRec()
    End Sub

    Sub viewTrf()
        Cursor = Cursors.WaitCursor
        'Prepare paramater
        Dim date_from_selected As String = "0000-01-01"
        Dim date_until_selected As String = "9999-01-01"
        Try
            date_from_selected = DateTime.Parse(DEFromTrf.EditValue.ToString).ToString("yyyy-MM-dd")
        Catch ex As Exception
        End Try

        Try
            date_until_selected = DateTime.Parse(DEUntilTrf.EditValue.ToString).ToString("yyyy-MM-dd")
        Catch ex As Exception
        End Try

        'prepare query
        Dim query_c As ClassFGTrf = New ClassFGTrf()
        Dim data As DataTable = query_c.transactionList("AND (trf.fg_trf_date>='" + date_from_selected + "' AND trf.fg_trf_date<='" + date_until_selected + "') ", "1")
        GCFGTrf.DataSource = data
        Cursor = Cursors.Default
    End Sub

    Private Sub BtnViewTrf_Click(sender As Object, e As EventArgs) Handles BtnViewTrf.Click
        viewTrf()
    End Sub

    Sub viewRQC()
        Cursor = Cursors.WaitCursor
        'Prepare paramater
        Dim date_from_selected As String = "0000-01-01"
        Dim date_until_selected As String = "9999-01-01"
        Try
            date_from_selected = DateTime.Parse(DEFromReturnQC.EditValue.ToString).ToString("yyyy-MM-dd")
        Catch ex As Exception
        End Try

        Try
            date_until_selected = DateTime.Parse(DEUntilReturnQC.EditValue.ToString).ToString("yyyy-MM-dd")
        Catch ex As Exception
        End Try

        'prepare query
        Dim query_c As ClassSalesReturnQC = New ClassSalesReturnQC()
        Dim data As DataTable = query_c.transactionList("AND (a.sales_return_qc_date>='" + date_from_selected + "' AND a.sales_return_qc_date<='" + date_until_selected + "') ", "1")
        GCSalesReturnQC.DataSource = data
        Cursor = Cursors.Default
    End Sub

    Private Sub BtnViewReturnQC_Click(sender As Object, e As EventArgs) Handles BtnViewReturnQC.Click
        viewRQC()
    End Sub

    Private Sub FormFGTransList_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub FormFGTransList_Activated(sender As Object, e As EventArgs) Handles MyBase.Activated
        FormMain.show_rb(Name)
        checkFormAccess(Name)
    End Sub

    Private Sub FormFGTransList_Deactivate(sender As Object, e As EventArgs) Handles MyBase.Deactivate
        FormMain.hide_rb()
    End Sub

    Private Sub XTCSvcLevel_SelectedPageChanged(sender As Object, e As DevExpress.XtraTab.TabPageChangedEventArgs) Handles XTCSvcLevel.SelectedPageChanged
        Dim tab_index As Integer = XTCSvcLevel.SelectedTabPageIndex
        If tab_index = 0 Then
            page_active = "rec"
            ActiveControl = DEFromRec
        ElseIf tab_index = 1 Then
            page_active = "del"
            ActiveControl = DEFromDO
        ElseIf tab_index = 2 Then
            page_active = "ret"
            ActiveControl = DEFromReturn
        ElseIf tab_index = 3 Then
            page_active = "nsr"
            ActiveControl = DEFromNonStock
        ElseIf tab_index = 4 Then
            page_active = "ret_trf"
            ActiveControl = DEFromReturnQC
        ElseIf tab_index = 5 Then
            page_active = "trf"
            ActiveControl = DEFromTrf
        ElseIf tab_index = 6 Then
            page_active = "sal"
            ActiveControl = DEFromSal
        End If
    End Sub

    Private Sub DEFromRec_KeyDown(sender As Object, e As KeyEventArgs) Handles DEFromRec.KeyDown
        If e.KeyCode = Keys.Enter Then
            DEUntilRec.Focus()
        End If
    End Sub

    Private Sub DEUntilRec_KeyDown(sender As Object, e As KeyEventArgs) Handles DEUntilRec.KeyDown
        If e.KeyCode = Keys.Enter Then
            BtnViewRec.Focus()
        End If
    End Sub

    Private Sub DEFromDO_KeyDown(sender As Object, e As KeyEventArgs) Handles DEFromDO.KeyDown
        If e.KeyCode = Keys.Enter Then
            DEUntilDO.Focus()
        End If
    End Sub

    Private Sub DEUntilDO_KeyDown(sender As Object, e As KeyEventArgs) Handles DEUntilDO.KeyDown
        If e.KeyCode = Keys.Enter Then
            BtnViewDO.Focus()
        End If
    End Sub

    Private Sub DEFromReturn_KeyDown(sender As Object, e As KeyEventArgs) Handles DEFromReturn.KeyDown
        If e.KeyCode = Keys.Enter Then
            DEUntilReturn.Focus()
        End If
    End Sub

    Private Sub DEUntilReturn_KeyDown(sender As Object, e As KeyEventArgs) Handles DEUntilReturn.KeyDown
        If e.KeyCode = Keys.Enter Then
            BtnViewReturn.Focus()
        End If
    End Sub

    Private Sub DEFromNonStock_KeyDown(sender As Object, e As KeyEventArgs) Handles DEFromNonStock.KeyDown
        If e.KeyCode = Keys.Enter Then
            DEUntilNonStock.Focus()
        End If
    End Sub

    Private Sub DEUntilNonStock_KeyDown(sender As Object, e As KeyEventArgs) Handles DEUntilNonStock.KeyDown
        If e.KeyCode = Keys.Enter Then
            BtnViewNonStock.Focus()
        End If
    End Sub

    Private Sub DEFromReturnQC_KeyDown(sender As Object, e As KeyEventArgs) Handles DEFromReturnQC.KeyDown
        If e.KeyCode = Keys.Enter Then
            DEUntilReturnQC.Focus()
        End If
    End Sub

    Private Sub DEUntilReturnQC_KeyDown(sender As Object, e As KeyEventArgs) Handles DEUntilReturnQC.KeyDown
        If e.KeyCode = Keys.Enter Then
            BtnViewReturnQC.Focus()
        End If
    End Sub

    Private Sub DEFromTrf_KeyDown(sender As Object, e As KeyEventArgs) Handles DEFromTrf.KeyDown
        If e.KeyCode = Keys.Enter Then
            DEUntilTrf.Focus()
        End If
    End Sub

    Private Sub DEUntilTrf_KeyDown(sender As Object, e As KeyEventArgs) Handles DEUntilTrf.KeyDown
        If e.KeyCode = Keys.Enter Then
            BtnViewTrf.Focus()
        End If
    End Sub

    Private Sub BtnExportToXLS_Click(sender As Object, e As EventArgs) Handles BtnExportToXLS.Click
        If GVSalesDelOrder.RowCount > 0 Then
            Cursor = Cursors.WaitCursor
            Dim dt_from As String = DEFromDO.Text.Replace(" ", "")
            Dim dt_until As String = DEUntilDO.Text.Replace(" ", "")
            Dim path As String = Application.StartupPath & "\download\"
            'create directory if not exist
            If Not IO.Directory.Exists(path) Then
                System.IO.Directory.CreateDirectory(path)
            End If
            'path = path + "del_" + dt_from + "_" + dt_until + ".xlsx"
            path = path + "tl_del.xlsx"
            exportToXLS(path, "del", GCSalesDelOrder)
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
        advOptions.AllowGrouping = DevExpress.Utils.DefaultBoolean.False
        advOptions.ShowTotalSummaries = DevExpress.Utils.DefaultBoolean.False
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

    Private Sub BtnExportToXLSRec_Click(sender As Object, e As EventArgs) Handles BtnExportToXLSRec.Click
        If GVPL.RowCount > 0 Then
            Cursor = Cursors.WaitCursor
            Dim dt_from As String = DEFromRec.Text.Replace(" ", "")
            Dim dt_until As String = DEUntilRec.Text.Replace(" ", "")
            Dim path As String = Application.StartupPath & "\download\"
            'create directory if not exist
            If Not IO.Directory.Exists(path) Then
                System.IO.Directory.CreateDirectory(path)
            End If
            path = path + "tl_rec.xlsx"
            exportToXLS(path, "rec", GCPL)
            Cursor = Cursors.Default
        End If
    End Sub

    Private Sub BtnExportToXLSRet_Click(sender As Object, e As EventArgs) Handles BtnExportToXLSRet.Click
        If GVSalesReturn.RowCount > 0 Then
            Cursor = Cursors.WaitCursor
            Dim dt_from As String = DEFromReturn.Text.Replace(" ", "")
            Dim dt_until As String = DEUntilReturn.Text.Replace(" ", "")
            Dim path As String = Application.StartupPath & "\download\"
            'create directory if not exist
            If Not IO.Directory.Exists(path) Then
                System.IO.Directory.CreateDirectory(path)
            End If
            path = path + "tl_ret.xlsx"
            exportToXLS(path, "ret", GCSalesReturn)
            Cursor = Cursors.Default
        End If
    End Sub

    Private Sub BtnExportToXLSNonStock_Click(sender As Object, e As EventArgs) Handles BtnExportToXLSNonStock.Click
        If GVNonStock.RowCount > 0 Then
            Cursor = Cursors.WaitCursor
            Dim path As String = Application.StartupPath & "\download\"
            'create directory if not exist
            If Not IO.Directory.Exists(path) Then
                System.IO.Directory.CreateDirectory(path)
            End If
            path = path + "tl_ns.xlsx"
            exportToXLS(path, "ns", GCNonStock)
            Cursor = Cursors.Default
        End If
    End Sub

    Private Sub BtnExportToXLSRetTrf_Click(sender As Object, e As EventArgs) Handles BtnExportToXLSRetTrf.Click
        If GVSalesReturnQC.RowCount > 0 Then
            Cursor = Cursors.WaitCursor
            Dim path As String = Application.StartupPath & "\download\"
            'create directory if not exist
            If Not IO.Directory.Exists(path) Then
                System.IO.Directory.CreateDirectory(path)
            End If
            path = path + "tl_ret_trf.xlsx"
            exportToXLS(path, "ret_trf", GCSalesReturnQC)
            Cursor = Cursors.Default
        End If
    End Sub

    Private Sub BtnExportToXLSTrf_Click(sender As Object, e As EventArgs) Handles BtnExportToXLSTrf.Click
        If GVFGTrf.RowCount > 0 Then
            Cursor = Cursors.WaitCursor
            Dim path As String = Application.StartupPath & "\download\"
            'create directory if not exist
            If Not IO.Directory.Exists(path) Then
                System.IO.Directory.CreateDirectory(path)
            End If
            path = path + "tl_trf.xlsx"
            exportToXLS(path, "trf", GCFGTrf)
            Cursor = Cursors.Default
        End If
    End Sub

    Private Sub BtnViewSal_Click(sender As Object, e As EventArgs) Handles BtnViewSal.Click
        viewSal()
    End Sub

    Sub viewSal()
        Cursor = Cursors.WaitCursor
        'class
        Dim id_code_class As String = get_setup_field("id_code_fg_class")
        'period type
        Dim col_date As String = ""
        If SLEPeriodType.EditValue.ToString = "1" Then
            col_date = "sp.sales_pos_end_period"
        Else
            col_date = "sp.sales_pos_date"
        End If
        'filter promo
        Dim cond_promo As String = ""
        Dim cond_promo_trans As String = ""
        If CEPromo.EditValue = True Then
            cond_promo = ""
            cond_promo_trans = ""
        Else
            cond_promo = "AND sp.sales_pos_total>0 "
            cond_promo_trans = "AND sp.report_mark_type!=116 "
        End If
        'date paramater
        Dim date_from_selected As String = "0000-01-01"
        Dim date_until_selected As String = "9999-01-01"
        Try
            date_from_selected = DateTime.Parse(DEFromSal.EditValue.ToString).ToString("yyyy-MM-dd")
        Catch ex As Exception
        End Try

        Try
            date_until_selected = DateTime.Parse(DEUntilSal.EditValue.ToString).ToString("yyyy-MM-dd")
        Catch ex As Exception
        End Try

        Dim query As String = "SELECT spd.id_sales_pos_det, spd.id_sales_pos, sp.sales_pos_number, rmt.report_mark_type_name, 
        c.comp_number, c.comp_name, cg.comp_group, cg.description AS `comp_group_name`,
        sp.sales_pos_date, sp.sales_pos_due_date,
        sp.sales_pos_start_period, sp.sales_pos_end_period,
        prod.id_product, prod.id_design, prod.`code`, prod.`code_main`,
        prod.`name`, prod.`size`, prod.`class`, spd.sales_pos_det_qty, spd.design_price_retail, (spd.sales_pos_det_qty * spd.design_price_retail) AS `amount`,
        stt.report_status
        FROM tb_sales_pos_det spd
        INNER JOIN tb_sales_pos sp ON sp.id_sales_pos = spd.id_sales_pos
        INNER JOIN tb_m_comp_contact cc ON cc.`id_comp_contact`= IF(sp.id_memo_type=8 OR sp.id_memo_type=9, sp.id_comp_contact_bill,sp.`id_store_contact_from`)
        INNER JOIN tb_lookup_report_mark_type rmt ON rmt.report_mark_type=sp.report_mark_type
        INNER JOIN tb_m_comp c ON c.`id_comp`=cc.`id_comp`
        INNER JOIN tb_m_comp_group cg ON cg.id_comp_group = c.id_comp_group
        LEFT JOIN (
	        SELECT prod.id_product, prod.id_design, prod.product_full_code AS `code`, dsg.design_code AS `code_main`,
	        prod.product_display_name AS `name`, sz.code_detail_name AS `size`, cls.display_name AS `class`
	        FROM tb_m_product prod
	        INNER JOIN tb_m_design dsg ON dsg.id_design = prod.id_design
	        INNER JOIN tb_m_product_code prod_code ON prod_code.id_product = prod.id_product
	        INNER JOIN tb_m_code_detail sz ON sz.id_code_detail = prod_code.id_code_detail
	        INNER JOIN tb_m_design_code dsg_code ON dsg_code.id_design = dsg.id_design
	        INNER JOIN tb_m_code_detail cls ON cls.id_code_detail = dsg_code.id_code_detail AND cls.id_code=" + id_code_class + "
	        WHERE dsg.id_lookup_status_order!=2
        ) prod ON prod.id_product = spd.id_product
        INNER JOIN tb_lookup_report_status stt ON stt.id_report_status = sp.id_report_status
        WHERE 1=1 AND (" + col_date + ">='" + date_from_selected + "' AND " + col_date + "<='" + date_until_selected + "') " + cond_promo + cond_promo_trans
        query += "ORDER BY spd.id_sales_pos ASC "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCSales.DataSource = data
        Cursor = Cursors.Default
    End Sub

    Private Sub BtnExportToXLSSal_Click(sender As Object, e As EventArgs) Handles BtnExportToXLSSal.Click
        If GVSales.RowCount > 0 Then
            Cursor = Cursors.WaitCursor
            Dim path As String = Application.StartupPath & "\download\"
            'create directory if not exist
            If Not IO.Directory.Exists(path) Then
                System.IO.Directory.CreateDirectory(path)
            End If
            path = path + "tl_sal.xlsx"
            exportToXLS(path, "sal", GCSales)
            Cursor = Cursors.Default
        End If
    End Sub
End Class