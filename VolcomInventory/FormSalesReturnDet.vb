Imports Microsoft.Office.Interop

Public Class FormSalesReturnDet
    Public action As String
    Public id_sales_return As String = "-1"
    Public id_sales_return_order As String = "-1"
    Public id_store_contact_from As String = "-1"
    Public id_wh_drawer_store As String = "-1"
    Public id_wh_rack_store As String = "-1"
    Public id_wh_locator_store As String = "-1"
    Public id_store As String = "-1"
    Public id_comp_contact_to As String = "-1"
    Public id_report_status As String
    Public id_sales_return_det_list As New List(Of String)
    Public id_sales_return_det_counting_list As New List(Of String)
    Public id_sales_return_det_drawer_list As New List(Of String)
    Public id_sales_return_det_drawer_detail_list As New List(Of String)
    Public id_comp_user As String = "-1"
    Public dt As New DataTable
    Public id_comp_to As String = "-1"
    Public id_drawer As String = "-1"
    Public id_pre As String = "-1"
    'Dim is_scan As Boolean = False
    Public bof_column As String = get_setup_field("bof_column")
    Public bof_xls_so As String = get_setup_field("bof_xls_ret")
    Public bof_xls_nsi As String = get_setup_field("bof_xls_nsi")

    'var check qty
    Public cond_check As Boolean = True
    Public sample_check As String
    Public qty_pl As Decimal
    Public allow_sum As Decimal

    'updated 19 December 2014
    Dim locator_sel As String = "-1"
    Dim rack_sel As String = "-1"
    Dim drawer_sel As String = "-1"
    Dim is_save_unreg_unique As String = "-1"
    Dim is_scan_prob As String = "-1"
    Public id_ret_type As String = ""
    Public is_view As String = "-1"
    Dim id_store_type As String = "-1"

    Public is_use_unique_code As String = "2"
    Dim id_commerce_type As String = "-1"
    Dim action_scan_btn As String = ""

    Private Sub FormSalesReturnDet_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        viewReportStatus()
        actionLoad()

        'sementara bahkan selamanya
        SCCStorage.Panel2.Hide()
        WindowState = FormWindowState.Maximized
    End Sub

    Sub actionLoad()
        Try
            'initiation datatable jika blm ada
            dt.Columns.Add("id_product")
            dt.Columns.Add("id_pl_prod_order_rec_det_unique")
            dt.Columns.Add("product_code")
            dt.Columns.Add("product_counting_code")
            dt.Columns.Add("product_full_code")
            dt.Columns.Add("bom_unit_price")
            dt.Columns.Add("id_design_price")
            dt.Columns.Add("design_price")
            dt.Columns.Add("is_old_design")
        Catch ex As Exception
        End Try

        If action = "ins" Then
            XTPStorage.PageEnabled = False
            TxtSalesReturnNumber.Text = ""
            BtnPrint.Enabled = False
            BMark.Enabled = False
            BtnAttachment.Enabled = False
            DEForm.Text = view_date(0)
            DDBPrint.Enabled = False

            'from waiting menu
            If id_sales_return_order <> "-1" Then
                viewSalesReturnOrder()
                BtnBrowseRO.Enabled = False
            End If
            check_but()

            'check is_save_unreg_unique (unique tdk teregister)
            is_save_unreg_unique = get_setup_field("is_save_unreg_unique")
        ElseIf action = "upd" Then
            GroupControlListItem.Enabled = True
            GroupControlScannedItem.Enabled = True
            GroupControlProb.Enabled = True
            GVItemList.OptionsBehavior.AutoExpandAllGroups = True
            BtnBrowseRO.Enabled = False
            BtnInfoSrs.Enabled = True
            BMark.Enabled = True
            BtnCreateNonStock.Visible = True
            DDBPrint.Enabled = True


            'query view based on edit id's
            Dim query As String = "SELECT a.id_wh_drawer,dw.wh_drawer_code,b.id_sales_return_order, a.id_store_contact_from, d.id_commerce_type,(d.id_drawer_def) AS `id_wh_drawer_store`,IFNULL(rck.id_wh_rack,-1) AS `id_wh_rack_store`, IFNULL(rck.id_wh_locator,-1) AS `id_wh_locator_store`, a.id_comp_contact_to, (d.comp_name) AS store_name_from, (d1.comp_name) AS comp_name_to, (d.comp_number) AS store_number_from, (d1.comp_number) AS comp_number_to, (d.address_primary) AS store_address_from, a.id_report_status, f.report_status, "
            query += "a.sales_return_note,a.sales_return_date, a.sales_return_number, sales_return_store_number,b.sales_return_order_number, "
            query += "DATE_FORMAT(a.sales_return_date,'%Y-%m-%d') AS sales_return_datex, (c.id_comp) AS id_store, (c1.id_comp) AS id_comp_to, dw.wh_drawer, rc.wh_rack, loc.wh_locator, a.id_ret_type, rt.ret_type, so.sales_order_ol_shop_number, a.is_use_unique_code "
            query += "FROM tb_sales_return a "
            query += "INNER JOIN tb_sales_return_order b ON a.id_sales_return_order = b.id_sales_return_order "
            query += "INNER JOIN tb_m_comp_contact c ON c.id_comp_contact = a.id_store_contact_from "
            query += "INNER JOIN tb_m_comp d ON c.id_comp = d.id_comp "
            query += "INNER JOIN tb_m_comp_contact c1 ON c1.id_comp_contact = a.id_comp_contact_to "
            query += "INNER JOIN tb_m_comp d1 ON c1.id_comp = d1.id_comp "
            query += "INNER JOIN tb_lookup_report_status f ON f.id_report_status = a.id_report_status "
            query += "LEFT JOIN tb_m_wh_drawer dw ON dw.id_wh_drawer=a.id_wh_drawer "
            query += "LEFT JOIN tb_m_wh_rack rc ON rc.id_wh_rack = dw.id_wh_rack "
            query += "LEFT JOIN tb_m_wh_locator loc ON loc.id_wh_locator = rc.id_wh_locator "
            query += "INNER JOIN tb_m_wh_drawer drw ON drw.id_wh_drawer = d.id_drawer_def "
            query += "INNER JOIN tb_m_wh_rack rck ON rck.id_wh_rack = drw.id_wh_rack "
            query += "LEFT JOIN tb_lookup_ret_type rt ON rt.id_ret_type = a.id_ret_type "
            query += "LEFT JOIN tb_sales_order so ON so.id_sales_order = b.id_sales_order "
            query += "WHERE a.id_sales_return = '" + id_sales_return + "' "
            Dim data As DataTable = execute_query(query, "-1", True, "", "", "", "")
            id_report_status = data.Rows(0)("id_report_status").ToString

            id_store_contact_from = data.Rows(0)("id_store_contact_from").ToString
            id_comp_contact_to = data.Rows(0)("id_comp_contact_to").ToString

            TxtStoreReturnNumber.Text = data.Rows(0)("sales_return_store_number").ToString
            TxtSalesReturnNumber.Text = data.Rows(0)("sales_return_number").ToString
            TxtSalesReturnOrderNumber.Text = data.Rows(0)("sales_return_order_number").ToString

            TxtNameCompFrom.Text = data.Rows(0)("store_name_from").ToString
            TxtCodeCompFrom.Text = data.Rows(0)("store_number_from").ToString
            TxtNameCompTo.Text = data.Rows(0)("comp_name_to").ToString
            TxtCodeCompTo.Text = data.Rows(0)("comp_number_to").ToString

            MEAdrressCompFrom.Text = data.Rows(0)("store_address_from").ToString

            DEForm.Text = view_date_from(data.Rows(0)("sales_return_datex").ToString, 0)
            TxtSalesReturnNumber.Text = data.Rows(0)("sales_return_number").ToString
            MENote.Text = data.Rows(0)("sales_return_note").ToString
            LEReportStatus.ItemIndex = LEReportStatus.Properties.GetDataSourceRowIndex("id_report_status", data.Rows(0)("id_report_status").ToString)
            id_sales_return_order = data.Rows(0)("id_sales_return_order").ToString
            id_store = data.Rows(0)("id_store").ToString
            id_comp_to = data.Rows(0)("id_comp_to").ToString
            id_wh_drawer_store = data.Rows(0)("id_wh_drawer_store").ToString
            id_wh_locator_store = data.Rows(0)("id_wh_locator_store").ToString
            id_wh_rack_store = data.Rows(0)("id_wh_rack_store").ToString
            id_commerce_type = data.Rows(0)("id_commerce_type").ToString

            drawer_sel = data.Rows(0)("wh_drawer").ToString
            rack_sel = data.Rows(0)("wh_rack").ToString
            locator_sel = data.Rows(0)("wh_locator").ToString

            id_drawer = data.Rows(0)("id_wh_drawer").ToString
            TEDrawer.Text = data.Rows(0)("wh_drawer_code").ToString
            id_ret_type = data.Rows(0)("id_ret_type").ToString
            TxtReturnType.Text = data.Rows(0)("ret_type").ToString
            TxtOLStoreOrder.Text = data.Rows(0)("sales_order_ol_shop_number").ToString
            is_use_unique_code = data.Rows(0)("is_use_unique_code").ToString

            'detail2
            viewDetail()
            view_barcode_list()
            view_barcode_list_prob()
            check_but()
            allow_status()

            If id_pre = "1" Then
                prePrinting()
                Close()
            ElseIf id_pre = "2" Then
                printing()
                Close()
            End If
        End If

        'ret type
        If id_ret_type = "2" Then
            XTCReturn.SelectedTabPageIndex = 1
            XTPReturn.PageEnabled = False
            XTPNonStock.PageEnabled = True
        Else
            XTCReturn.SelectedTabPageIndex = 0
            XTPNonStock.PageEnabled = False
            XTPReturn.PageEnabled = True
        End If
    End Sub
    Sub viewSalesReturnOrder()
        Dim query As String = "SELECT a.id_sales_return_order, a.id_store_contact_to, a.id_wh_contact_to, d.is_use_unique_code, d.id_commerce_type, d.id_store_type,(d.comp_name) AS store_name_to, (d.id_drawer_def) AS `id_wh_drawer_store`, IFNULL(rck.id_wh_rack,-1) AS `id_wh_rack_store`, IFNULL(rck.id_wh_locator,-1) AS `id_wh_locator_store`,a.id_report_status, f.report_status, "
        query += "a.sales_return_order_note, a.sales_return_order_note, a.sales_return_order_number, "
        query += "DATE_FORMAT(a.sales_return_order_date,'%d %M %Y') AS sales_return_order_date, "
        query += "DATE_FORMAT(a.sales_return_order_est_date,'%d %M %Y') AS sales_return_order_est_date "
        If id_ret_type = "4" Then
            query += ", wh.id_comp AS `id_wh`,wh.comp_number AS `wh_number`, wh.comp_name AS `wh_name`, wh.id_drawer_def AS `wh_drawer`, so.sales_order_ol_shop_number "
        End If
        query += "FROM tb_sales_return_order a "
        'query += "INNER JOIN tb_sales_return_order_det b ON a.id_sales_return_order = b.id_sales_return_order "
        query += "INNER JOIN tb_m_comp_contact c ON c.id_comp_contact = a.id_store_contact_to "
        query += "INNER JOIN tb_m_comp d ON c.id_comp = d.id_comp "
        query += "INNER JOIN tb_lookup_report_status f ON f.id_report_status = a.id_report_status "
        query += "INNER JOIN tb_m_wh_drawer drw ON drw.id_wh_drawer = d.id_drawer_def "
        query += "INNER JOIN tb_m_wh_rack rck ON rck.id_wh_rack = drw.id_wh_rack "
        If id_ret_type = "4" Then
            query += "INNER JOIN tb_m_comp_contact whc ON whc.id_comp_contact = a.id_wh_contact_to "
            query += "INNER JOIN tb_m_comp wh ON wh.id_comp = whc.id_comp "
            query += "INNER JOIN tb_sales_order so ON so.id_sales_order = a.id_sales_order "
        End If
        query += "WHERE a.id_sales_return_order ='" + id_sales_return_order + "' "
        query += "ORDER BY a.id_sales_return_order ASC "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")

        'SO
        TxtSalesReturnOrderNumber.Text = data.Rows(0)("sales_return_order_number").ToString

        'store data
        Dim query_comp_to As String = "SELECT id_comp FROM tb_m_comp_contact WHERE id_comp_contact = '" + data.Rows(0)("id_store_contact_to").ToString + "'"
        Dim id_comp_from As String = execute_query(query_comp_to, 0, True, "", "", "", "")
        id_store = id_comp_from
        id_store_contact_from = data.Rows(0)("id_store_contact_to").ToString
        id_store_type = data.Rows(0)("id_store_type").ToString
        id_commerce_type = data.Rows(0)("id_commerce_type").ToString
        is_use_unique_code = data.Rows(0)("is_use_unique_code").ToString
        TxtCodeCompFrom.Text = get_company_x(id_comp_from, 2)
        TxtNameCompFrom.Text = get_company_x(id_comp_from, 1)
        id_wh_drawer_store = data.Rows(0)("id_wh_drawer_store").ToString
        id_wh_rack_store = data.Rows(0)("id_wh_rack_store").ToString
        id_wh_locator_store = data.Rows(0)("id_wh_locator_store").ToString
        'MEAdrressCompTo.Text = get_company_x(id_comp_to, 3)

        If id_ret_type = "2" Then 'for non stock
            id_comp_contact_to = id_store_contact_from
            TxtNameCompTo.Text = TxtNameCompFrom.Text
            TxtCodeCompTo.Text = TxtCodeCompFrom.Text
            id_comp_user = id_store
            setDefDrawer()
        ElseIf id_ret_type = "4" Then 'for ol store
            BtnBrowseContactTo.Enabled = False
            BPickDrawer.Enabled = False
            TxtOLStoreOrder.Text = data.Rows(0)("sales_order_ol_shop_number").ToString
            id_comp_contact_to = data.Rows(0)("id_wh_contact_to").ToString
            TxtNameCompTo.Text = data.Rows(0)("wh_name").ToString
            TxtCodeCompTo.Text = data.Rows(0)("wh_number").ToString
            setDefDrawer()
        End If




        'general
        viewDetail()
        view_barcode_list()
        view_barcode_list_prob()
        GroupControlListItem.Enabled = True
        GroupControlScannedItem.Enabled = True
        GroupControlProb.Enabled = True
        BtnInfoSrs.Enabled = True
        GVItemList.OptionsBehavior.AutoExpandAllGroups = True
    End Sub

    Sub setDefDrawer()
        'get default drawer
        Dim id_comp_param As String = "0"
        Try
            id_comp_param = get_id_company(id_comp_contact_to)
        Catch ex As Exception
        End Try
        Dim query_def_drw As String = ""
        query_def_drw += "SELECT IFNULL(drw.id_wh_drawer,'-1') AS `id_wh_drawer`, IFNULL(drw.wh_drawer_code,'') AS `wh_drawer_code`, "
        query_def_drw += "IFNULL(drw.wh_drawer,'') AS `wh_drawer` "
        query_def_drw += "FROM tb_m_comp comp "
        query_def_drw += "LEFT JOIN tb_m_wh_drawer drw ON comp.id_drawer_def = drw.id_wh_drawer "
        query_def_drw += "WHERE comp.id_comp='" + id_comp_param + "' "
        Dim data_def_drw As DataTable = execute_query(query_def_drw, -1, True, "", "", "", "")
        id_drawer = data_def_drw(0)("id_wh_drawer").ToString
        TEDrawer.Text = data_def_drw(0)("wh_drawer_code").ToString
    End Sub

    Sub viewReportStatus()
        Dim query As String = "SELECT * FROM tb_lookup_report_status a ORDER BY a.id_report_status "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        viewLookupQuery(LEReportStatus, query, 0, "report_status", "id_report_status")
    End Sub

    Sub viewDetail()
        dt.Clear()
        If action = "ins" Then
            'action
            Dim query As String = "CALL view_sales_return_order_limit('" + id_sales_return_order + "', '0', '0')"
            Dim data As DataTable = execute_query(query, "-1", True, "", "", "", "")
            GCItemList.DataSource = data
        ElseIf action = "upd" Then
            Dim query As String = "CALL view_sales_return('" + id_sales_return + "')"
            Dim data As DataTable = execute_query(query, "-1", True, "", "", "", "")
            For i As Integer = 0 To (data.Rows.Count - 1)
                id_sales_return_det_list.Add(data.Rows(i)("id_sales_return_det").ToString)
                'codeAvailableIns(data.Rows(i)("id_product").ToString, id_store, data.Rows(i)("id_design_price").ToString)
            Next
            GCItemList.DataSource = data
        End If
    End Sub


    Sub view_barcode_list()
        If action = "ins" Then
            Dim query As String = "SELECT ('0') AS no, ('') AS code, ('') AS name, ('') AS size, ('0') AS id_sales_return_det, ('0') AS id_pl_prod_order_rec_det_unique, ('0') AS id_product,('1') AS is_fix, ('') AS counting_code, ('0') AS id_sales_return_det_counting, CAST('0' AS DECIMAL(13,2)) AS bom_unit_price, CAST('0' AS DECIMAL(13,2)) AS design_price, ('0') AS id_design_price, '0' AS ` is_unique_report` "
            Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
            GCBarcode.DataSource = data
            deleteRowsBc()
            allowDelete()
        ElseIf action = "upd" Then
            Dim query As String = ""
            query += "SELECT ('') AS no, CONCAT(c.product_full_code, a.sales_return_det_counting) AS code, (c.product_full_code) AS product_code, "
            query += "c.product_display_name AS `name`, cod.display_name AS `size`, (a.sales_return_det_counting) AS counting_code, "
            query += "a.id_sales_return_det_counting, ('2') AS is_fix, "
            query += "IFNULL(a.id_pl_prod_order_rec_det_unique,'0') AS `id_pl_prod_order_rec_det_unique`, b.id_product, "
            query += "d.bom_unit_price, b.id_design_price, b.design_price, a. is_unique_report "
            query += "FROM tb_sales_return_det_counting a "
            query += "INNER JOIN tb_sales_return_det b ON a.id_sales_return_det = b.id_sales_return_det "
            query += "JOIN tb_opt o "
            query += "INNER JOIN tb_m_product c ON c.id_product = b.id_product "
            query += "INNER JOIN tb_m_product_code cc ON cc.id_product = c.id_product "
            query += "INNER JOIN tb_m_code_detail cod ON cod.id_code_detail = cc.id_code_detail AND cod.id_code = o.id_code_product_size "
            query += "LEFT JOIN tb_pl_prod_order_rec_det_counting d ON d.id_pl_prod_order_rec_det_unique = a.id_pl_prod_order_rec_det_unique "
            query += "WHERE b.id_sales_return = '" + id_sales_return + "' "
            Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
            For i As Integer = 0 To (data.Rows.Count - 1)
                id_sales_return_det_counting_list.Add(data.Rows(i)("id_sales_return_det_counting").ToString)
            Next
            GCBarcode.DataSource = data
        End If
    End Sub

    Sub view_barcode_list_prob()
        Dim query As String = "SELECT '0' AS `no`,rp.id_sales_return_problem, rp.id_product, d.design_code, rp.scanned_code AS `code`,
            d.design_display_name AS `name`, cd.code_detail_name AS `size`, rp.remark
            FROM tb_sales_return_problem rp
            INNER JOIN tb_m_product p ON p.id_product = rp.id_product
            INNER JOIN tb_m_product_code pc ON pc.id_product = p.id_product
            INNER JOIN tb_m_code_detail cd ON cd.id_code_detail = pc.id_code_detail
            INNER JOIN tb_m_design d ON d.id_design = p.id_design
            WHERE rp.id_sales_return=" + id_sales_return + " "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCBarcodeProb.DataSource = data
    End Sub



    Sub codeAvailableIns(ByVal id_product_param As String, ByVal id_product_param_or As String, ByVal id_store_param As String, ByVal id_design_price_param As String)
        'unique
        Dim query As String = ""
        If is_use_unique_code = "1" Then
            query = "SELECT c.id_pl_prod_order_rec_det_unique, prc.design_price, prc.id_design_price, prc.design_price_type, 
            u.id_product, prod.product_full_code AS `product_code`, prod.product_display_name AS `name`,cd.code_detail_name AS `size`, RIGHT(u.unique_code,4) AS `product_counting_code`,
            u.unique_code AS `product_full_code`, dsg.design_cop AS `bom_unit_price`, SUM(u.qty) AS `qty`, 6 AS `id_report_status`, 2 AS `is_old_design`, '' AS `stt`, u.is_unique_report
            FROM tb_m_unique_code u
            INNER JOIN tb_m_product prod ON prod.id_product = u.id_product
            INNER JOIN tb_m_product_code prodc ON prodc.id_product = prod.id_product
            INNER JOIN tb_m_code_detail cd ON cd.id_code_detail = prodc.id_code_detail
            INNER JOIN tb_m_design dsg ON dsg.id_design = prod.id_design
            LEFT JOIN( 
              Select * FROM ( 
              Select price.id_design, price.design_price, price.design_price_date, price.id_design_price, 
              price.id_design_price_type, price_type.design_price_type,
              cat.id_design_cat, cat.design_cat
              From tb_m_design_price price 
              INNER Join tb_lookup_design_price_type price_type On price.id_design_price_type = price_type.id_design_price_type 
              INNER JOIN tb_lookup_design_cat cat ON cat.id_design_cat = price_type.id_design_cat
              WHERE price.is_active_wh =1 AND price.design_price_start_date <= NOW() 
              ORDER BY price.design_price_start_date DESC, price.id_design_price DESC ) a 
              GROUP BY a.id_design 
            ) prc ON prc.id_design = prod.id_design 
            INNER JOIN tb_pl_prod_order_rec_det_counting c ON c.id_product = u.id_product AND c.pl_prod_order_rec_det_counting = RIGHT(u.unique_code,4)
            WHERE u.id_comp=" + id_store + " AND (" + id_product_param_or + ")
            GROUP BY u.unique_code 
            HAVING qty>0 "
        Else
            query = "CALL view_stock_fg_unique_ret('" + id_product_param + "','" + id_store_param + "', '" + id_design_price_param + "','0')"
        End If

        Dim datax As DataTable = execute_query(query, -1, True, "", "", "", "")
        dt = datax
        'For k As Integer = 0 To (datax.Rows.Count - 1)
        'insertDt(datax.Rows(k)("id_product").ToString, datax.Rows(k)("id_pl_prod_order_rec_det_unique").ToString, datax.Rows(k)("product_code").ToString, datax.Rows(k)("product_counting_code").ToString, datax.Rows(k)("product_full_code").ToString, Decimal.Parse(datax.Rows(k)("bom_unit_price").ToString), datax.Rows(k)("id_design_price").ToString, Decimal.Parse(datax.Rows(k)("design_price").ToString))
        'Next

        'not unique 
        Dim query_c As ClassDesign = New ClassDesign()
        Dim query_not As String = query_c.queryOldDesignCode(id_product_param)
        Dim data_not As DataTable = execute_query(query_not, -1, True, "", "", "", "")

        'merge
        If data_not.Rows.Count > 0 Then
            If dt.Rows.Count = 0 Then
                dt = data_not
            Else
                dt.Merge(data_not, True, MissingSchemaAction.Ignore)
            End If
        End If

        If is_save_unreg_unique = "1" Then
            'merge with unique unregistered
            Dim data_unreg = query_c.dataUnregisteredCode(id_product_param)
            If data_unreg.Rows.Count > 0 Then
                If dt.Rows.Count = 0 Then
                    dt = data_unreg
                Else
                    dt.Merge(data_unreg, True, MissingSchemaAction.Ignore)
                End If
            End If
        End If
    End Sub

    Sub codeAvailableInsProb(ByVal id_product_param As String, ByVal id_store_param As String, ByVal id_design_price_param As String)

    End Sub

    Sub insertDt(ByVal id_product_param As String, ByVal id_pl_prod_order_rec_det_unique_param As String, ByVal product_code_param As String, ByVal product_counting_code_param As String, ByVal product_full_code_param As String, ByVal cost_param As Decimal, ByVal id_design_price_param As String, ByVal design_price_param As Decimal)
        Dim R As DataRow = dt.NewRow
        R("id_product") = id_product_param
        R("id_pl_prod_order_rec_det_unique") = id_pl_prod_order_rec_det_unique_param
        R("product_code") = product_code_param
        R("product_counting_code") = product_counting_code_param
        R("product_full_code") = product_full_code_param
        R("bom_unit_price") = cost_param
        R("id_design_price") = id_design_price_param
        R("design_price") = design_price_param
        R("is_old_design") = "2"
        dt.Rows.Add(R)
    End Sub

    Sub codeAvailableDel(ByVal id_product_param As String)
        Dim i As Integer = dt.Rows.Count - 1
        While (i >= 0)
            If dt.Rows(i)("id_product").ToString = id_product_param Then
                dt.Rows.RemoveAt(i)
            End If
            i = i - 1
        End While
    End Sub

    Private Sub BtnBrowseRO_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnBrowseRO.Click
        FormPopUpSalesReturnOrder.id_pop_up = "1"
        FormPopUpSalesReturnOrder.id_sales_return_order_det = "0"
        FormPopUpSalesReturnOrder.id_sales_return = "0"
        FormPopUpSalesReturnOrder.ShowDialog()
    End Sub

    'sub check_but
    Sub check_but()
        Dim id_productx As String = "0"
        Try
            id_productx = GVItemList.GetFocusedRowCellValue("id_product").ToString
        Catch ex As Exception

        End Try

        'MsgBox("main :" + id_productx)

        'Constraint Status
        If GVItemList.RowCount > 0 And id_productx <> "0" Then
            BtnEdit.Enabled = True
            BtnDel.Enabled = True
        Else
            BtnEdit.Enabled = False
            BtnDel.Enabled = False
        End If
    End Sub

    Sub allow_status()
        Dim rm As String = ""
        If id_ret_type = "1" Then
            rm = "46"
        ElseIf id_ret_type = "3" Then
            rm = "113"
        Else
            rm = "111"
        End If
        If check_edit_report_status(id_report_status, rm, id_sales_return) Then
            PanelControlNav.Enabled = True
            PanelNavBarcode.Enabled = False
            PanelNavBarcodeProb.Enabled = False
            MENote.Properties.ReadOnly = False
            BtnSave.Enabled = False
            TxtStoreReturnNumber.Properties.ReadOnly = False
            BtnInfoSrs.Enabled = True
            GridColumnQtyLimit.Visible = False
            BtnBrowseContactTo.Enabled = False
            BPickDrawer.Enabled = True
        Else
            PanelControlNav.Enabled = False
            PanelNavBarcode.Enabled = False
            PanelNavBarcodeProb.Enabled = False
            MENote.Properties.ReadOnly = True
            BtnSave.Enabled = False
            TxtStoreReturnNumber.Properties.ReadOnly = True
            BtnInfoSrs.Enabled = False
            GridColumnQtyLimit.Visible = False
            BtnBrowseContactTo.Enabled = False
            BPickDrawer.Enabled = False
        End If
        BtnVerify.Enabled = False
        GridColumnStt.Visible = False

        'non stock report
        If is_view = "1" Then
            BtnCreateNonStock.Visible = False
        End If

        'attachment
        If check_attach_report_status(id_report_status, rm, id_sales_return) Then
            BtnAttachment.Enabled = True
        Else
            BtnAttachment.Enabled = False
        End If

        'Pre Print
        If check_pre_print_report_status(id_report_status) Then
            BtnPrePrinting.Enabled = True
        Else
            BtnPrePrinting.Enabled = False
        End If

        'Print
        If check_print_report_status(id_report_status) Then
            BtnPrint.Enabled = True
        Else
            BtnPrint.Enabled = False
        End If

        'Btn Storage
        If check_storage_report_status(id_report_status) Then
            XTPStorage.PageEnabled = True
        Else
            XTPStorage.PageEnabled = False
        End If

        If id_report_status <> "5" And bof_column = "1" Then
            BtnXlsBOF.Visible = True
        Else
            BtnXlsBOF.Visible = False
        End If

        TxtSalesReturnNumber.Focus()
    End Sub

    'DeleteRows
    Sub deleteRowsBc()
        GVBarcode.DeleteRow(GVBarcode.FocusedRowHandle)
    End Sub

    'Focus Column Code
    Sub focusColumnCodeBc()
        GVBarcode.FocusedColumn = GVBarcode.VisibleColumns(0)
        GVBarcode.ShowEditor()
    End Sub
    'New Row
    Sub newRowsBc()
        GVBarcode.AddNewRow()
        GCBarcode.RefreshDataSource()
        GVBarcode.RefreshData()
        GVBarcode.FocusedRowHandle = GVBarcode.RowCount - 1
    End Sub

    Private Sub GVBarcode_CustomColumnDisplayText(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs)
        If e.Column.FieldName = "no" Then
            e.DisplayText = (e.ListSourceRowIndex + 1).ToString()
        End If
    End Sub

    Sub allowDelete()
        'If GVBarcode.RowCount > 0 Then
        '    BDelete.Enabled = True
        'Else
        '    BDelete.Enabled = False
        'End If
    End Sub

    Sub noEdit()
        Try
            Dim is_fix As String = GVBarcode.GetFocusedRowCellDisplayText("is_fix")
            If is_fix <> "2" Then
                GridColumnBarcode.OptionsColumn.AllowEdit = True
            Else
                GridColumnBarcode.OptionsColumn.AllowEdit = False
            End If
        Catch ex As Exception
            'errorCustom(ex.ToString)
        End Try
    End Sub

    Sub countQty(ByVal id_product_param As String)
        If id_commerce_type = "2" Then
            'onine store
            'focus
            makeSafeGV(GVItemList)
            If action_scan_btn = "start" Then
                GVItemList.ActiveFilterString = "[id_product]='" + id_product_param + "' AND [diff]>0 "
            ElseIf action_scan_btn = "delete" Then
                GVItemList.ActiveFilterString = "[id_product]='" + id_product_param + "' AND [sales_return_det_qty]>0 "
            End If
            GVItemList.FocusedRowHandle = 0
            makeSafeGV(GVItemList)

            Dim tot As Integer = 0
            If action_scan_btn = "start" Then
                tot = GVItemList.GetFocusedRowCellValue("sales_return_det_qty") + 1
            ElseIf action_scan_btn = "delete" Then
                tot = GVItemList.GetFocusedRowCellValue("sales_return_det_qty") - 1
            End If


            Dim price As Decimal = Decimal.Parse(GVItemList.GetFocusedRowCellValue("design_price").ToString)
            GVItemList.SetFocusedRowCellValue("sales_return_det_amount", tot * price)
            GVItemList.SetFocusedRowCellValue("sales_return_det_qty", tot)
        Else
            Dim tot As Decimal = 0.0
            For i As Integer = 0 To GVBarcode.RowCount - 1
                Dim id_product As String = GVBarcode.GetRowCellValue(i, "id_product").ToString
                If id_product = id_product_param Then
                    tot = tot + 1.0
                End If
            Next

            Dim indeks As Integer = -1
            For j As Integer = 0 To GVItemList.RowCount - 1
                Try
                    Dim id_productx As String = GVItemList.GetRowCellValue(j, "id_product").ToString
                    If id_productx = id_product_param Then
                        indeks = j
                        Exit For
                    End If
                Catch ex As Exception
                End Try
            Next



            GVItemList.FocusedRowHandle = indeks
            Dim price As Decimal = Decimal.Parse(GVItemList.GetFocusedRowCellValue("design_price").ToString)
            GVItemList.SetFocusedRowCellValue("sales_return_det_amount", tot * price)
            GVItemList.SetFocusedRowCellValue("sales_return_det_qty", tot)
        End If
    End Sub

    Private Sub BtnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnAdd.Click
        FormPopUpSalesReturnOrder.id_pop_up = "2"
        FormPopUpSalesReturnOrder.id_sales_return_order = id_sales_return_order
        FormPopUpSalesReturnOrder.id_sales_return_order_det = "0"
        If action = "ins" Then
            FormPopUpSalesReturnOrder.id_sales_return = "0"
        Else
            FormPopUpSalesReturnOrder.id_sales_return = id_sales_return
        End If
        FormPopUpSalesReturnOrder.ShowDialog()
    End Sub

    Private Sub BtnEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnEdit.Click
        Dim id_sales_return_order_det As String = "0"
        'Dim qty_from_wh As Decimal = 0.0
        Dim qty As Decimal = 0.0
        Dim id_sales_return_det = "-1"
        Try
            id_sales_return_order_det = GVItemList.GetRowCellValue(GVItemList.FocusedRowHandle, "id_sales_return_order_det")
            'qty_from_wh = Decimal.Parse(GVItemList.GetFocusedRowCellValue("qty_from_wh"))
            qty = Decimal.Parse(GVItemList.GetFocusedRowCellValue("sales_return_det_qty"))
            id_sales_return_det = GVItemList.GetFocusedRowCellValue("id_sales_return_det").ToString
        Catch ex As Exception
        End Try

        If action = "ins" Then
            If qty = 0.0 Then
                'MsgBox(id_sales_return_order_det)
                FormPopUpSalesReturnOrder.id_pop_up = "2"
                FormPopUpSalesReturnOrder.id_sales_return_order = id_sales_return_order
                FormPopUpSalesReturnOrder.id_sales_return_order_det = id_sales_return_order_det
                FormPopUpSalesReturnOrder.indeks_edit = GVItemList.FocusedRowHandle()
                FormPopUpSalesReturnOrder.ShowDialog()
            Else
                errorCustom("This data already locked and can't edit.")
            End If
        ElseIf action = "upd" Then
            If id_sales_return_det = "0" Then
                If qty = 0.0 Then
                    'MsgBox(id_sales_return_order_det)
                    FormPopUpSalesReturnOrder.id_pop_up = "2"
                    FormPopUpSalesReturnOrder.id_sales_return_order = id_sales_return_order
                    FormPopUpSalesReturnOrder.id_sales_return_order_det = id_sales_return_order_det
                    FormPopUpSalesReturnOrder.indeks_edit = GVItemList.FocusedRowHandle()
                    FormPopUpSalesReturnOrder.ShowDialog()
                Else
                    errorCustom("This data already locked and can't edit.")
                End If
            Else
                errorCustom("This data already locked and can't edit.")
            End If
        End If
    End Sub

    Private Sub BtnDel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnDel.Click
        Cursor = Cursors.WaitCursor
        Dim id_sales_return_order_det As String = "0"
        Dim qty As Decimal = 0.0
        Dim id_product As String = "0"
        Dim id_sales_return_det = "-1"
        Dim bom_unit_price As Decimal = 0.0
        Dim counting_code As String = ""
        Dim id_pl_prod_order_rec_det_unique As String = ""
        Dim code As String = ""
        Try
            id_sales_return_order_det = GVItemList.GetFocusedRowCellValue("id_sales_return_order_det").ToString
            qty = Decimal.Parse(GVItemList.GetFocusedRowCellValue("sales_return_det_qty"))
            id_product = GVItemList.GetFocusedRowCellValue("id_product").ToString
            id_sales_return_det = GVItemList.GetFocusedRowCellValue("id_sales_return_det").ToString
            bom_unit_price = Decimal.Parse(GVBarcode.GetFocusedRowCellValue("bom_unit_price").ToString)
            counting_code = GVBarcode.GetFocusedRowCellValue("counting_code").ToString
            id_pl_prod_order_rec_det_unique = GVBarcode.GetFocusedRowCellValue("id_pl_prod_order_rec_det_unique").ToString
            code = GVBarcode.GetFocusedRowCellValue("code").ToString
        Catch ex As Exception

        End Try

        Dim confirm As DialogResult = DevExpress.XtraEditors.XtraMessageBox.Show("Are you sure want to delete this item?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
        If confirm = Windows.Forms.DialogResult.Yes Then
            GVItemList.DeleteRow(GVItemList.FocusedRowHandle)
            GCItemList.RefreshDataSource()
            GVItemList.RefreshData()
            codeAvailableDel(id_product)
            deleteDetailBC(id_product)
            deleteDetailDrawer(id_product)
            check_but()
        End If
        Cursor = Cursors.Default
    End Sub

    Private Sub BtnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCancel.Click
        If action = "ins" Then
            Dim confirm As DialogResult = DevExpress.XtraEditors.XtraMessageBox.Show("Are you sure want to cancel ?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
            If confirm = Windows.Forms.DialogResult.Yes Then
                Close()
            End If
        Else
            Close()
        End If
    End Sub

    Private Sub FormSalesReturnDet_FormClosed(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub


    Private Sub BMark_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BMark.Click
        Cursor = Cursors.WaitCursor
        FormReportMark.id_report = id_sales_return
        If id_ret_type = "1" Then
            FormReportMark.report_mark_type = "46"
        ElseIf id_ret_type = "3" Then
            FormReportMark.report_mark_type = "113"
        ElseIf id_ret_type = "4" Then
            FormReportMark.report_mark_type = "120"
        Else
            FormReportMark.report_mark_type = "111"
        End If
        FormReportMark.form_origin = Name
        FormReportMark.is_view = "1"
        FormReportMark.is_view_finalize = "1"
        FormReportMark.ShowDialog()
        Cursor = Cursors.Default
    End Sub

    Private Sub GVItemList_FocusedRowChanged_1(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles GVItemList.FocusedRowChanged
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
        check_but()
        AddHandler GVDrawer.RowCellStyle, AddressOf my_color_cell
        ''AddHandler GVBarcode.RowCellStyle, AddressOf my_color_cell
        GCDrawer.RefreshDataSource()
        GVDrawer.RefreshData()
        ''GCBarcode.RefreshDataSource()
        ''GVBarcode.RefreshData()
    End Sub

    Private Sub BtnBrowseContactTo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnBrowseContactTo.Click
        FormPopUpContact.id_pop_up = "41"
        FormPopUpContact.id_departement = id_departement_user
        FormPopUpContact.ShowDialog()
    End Sub

    Private Sub TxtSalesReturnOrderNumber_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TxtSalesReturnOrderNumber.Validating
        EP_TE_cant_blank(EPForm, TxtSalesReturnOrderNumber)
        EPForm.SetIconPadding(TxtSalesReturnOrderNumber, 58)
    End Sub

    Private Sub TxtNameCompFrom_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TxtNameCompFrom.Validating
        EP_TE_cant_blank(EPForm, TxtNameCompFrom)
    End Sub

    Private Sub TxtNameCompTo_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TxtNameCompTo.Validating
        EP_TE_cant_blank(EPForm, TxtNameCompTo)
        EPForm.SetIconPadding(TxtNameCompTo, 30)
    End Sub

    Function verifyTrans() As Boolean
        GridColumnStt.Visible = True
        Dim cond_list As Boolean = True
        'Dim query_cek_stok As String = "CALL view_stock_fg('" + id_store + "', '" + id_wh_locator_store + "', '" + id_wh_rack_store + "', '" + id_wh_drawer_store + "', '0', 4, '9999-01-01') "
        Dim query_cek_stok As String = "CALL view_sales_return_order_limit('" + id_sales_return_order + "','0','0') "
        Dim dt_cek As DataTable = execute_query(query_cek_stok, -1, True, "", "", "", "")

        If id_commerce_type = "2" Then
            'online store
            For i As Integer = 0 To ((GVItemList.RowCount - 1) - GetGroupRowCount(GVItemList))
                Dim id_sales_return_order_det_cek As String = GVItemList.GetRowCellValue(i, "id_sales_return_order_det").ToString
                Dim name_cek As String = GVItemList.GetRowCellValue(i, "name").ToString
                Dim size_cek As String = GVItemList.GetRowCellValue(i, "size").ToString
                Dim qty_cek As Integer = GVItemList.GetRowCellValue(i, "sales_return_det_qty")
                Dim qty_soh As Integer = 0
                Dim dt_filter_cek As DataRow() = dt_cek.Select("[id_sales_return_order_det]='" + id_sales_return_order_det_cek + "' ")
                If dt_filter_cek.Length > 0 Then
                    ' qty_soh = dt_filter_cek(0)("qty_all_product")
                    qty_soh = dt_filter_cek(0)("sales_return_det_qty_limit")
                Else
                    qty_soh = 0
                End If

                If qty_cek > qty_soh Then
                    cond_list = False
                End If
                GVItemList.SetRowCellValue(i, "sales_return_det_qty_limit", qty_soh)
            Next
        Else
            For i As Integer = 0 To ((GVItemList.RowCount - 1) - GetGroupRowCount(GVItemList))
                Dim id_product_cek As String = GVItemList.GetRowCellValue(i, "id_product").ToString
                Dim name_cek As String = GVItemList.GetRowCellValue(i, "name").ToString
                Dim size_cek As String = GVItemList.GetRowCellValue(i, "size").ToString
                Dim qty_cek As Integer = GVItemList.GetRowCellValue(i, "sales_return_det_qty")
                Dim qty_soh As Integer = 0
                Dim dt_filter_cek As DataRow() = dt_cek.Select("[id_product]='" + id_product_cek + "' ")
                If dt_filter_cek.Length > 0 Then
                    ' qty_soh = dt_filter_cek(0)("qty_all_product")
                    qty_soh = dt_filter_cek(0)("sales_return_det_qty_limit")
                Else
                    qty_soh = 0
                End If

                If qty_cek > qty_soh Then
                    cond_list = False
                End If
                GVItemList.SetRowCellValue(i, "sales_return_det_qty_limit", qty_soh)
            Next
        End If
        Return cond_list
    End Function

    Private Sub BtnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSave.Click
        ValidateChildren()
        makeSafeGV(GVItemList)
        makeSafeGV(GVBarcode)
        makeSafeGV(GVBarcodeProb)

        'check limit
        Dim error_list As String = ""
        Dim cond_list As Boolean = True
        If action = "ins" Then
            cond_list = verifyTrans()
        End If


        If Not formIsValidInPanel(EPForm, PanelControlTopLeft) Or Not formIsValidInPanel(EPForm, PanelControlTopRight) Then
            errorInput()
        ElseIf GVItemList.RowCount = 0 Then
            errorCustom("Return item data can't blank")
        ElseIf TxtStoreReturnNumber.Text = "" Then
            stopCustom("Store return number can't blank")
        ElseIf Not cond_list Then
            stopCustom("Please see different in column status.")
        Else
            Dim confirm As DialogResult = DevExpress.XtraEditors.XtraMessageBox.Show("Are you sure to continue this process?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
            If confirm = Windows.Forms.DialogResult.Yes Then
                Cursor = Cursors.WaitCursor
                BtnSave.Enabled = False
                Dim sales_return_store_number As String = TxtStoreReturnNumber.Text
                Dim sales_return_note As String = MENote.Text

                If action = "ins" Then
                    'query main table
                    Dim sales_return_number As String = ""
                    If id_ret_type = "1" Or id_ret_type = "3" Or id_ret_type = "4" Then
                        sales_return_number = header_number_sales("5")
                    Else
                        sales_return_number = header_number_sales("32")
                    End If
                    Dim query_main As String = "INSERT tb_sales_return(id_store_contact_from, id_comp_contact_to, id_sales_return_order, sales_return_number, sales_return_store_number, sales_return_date, sales_return_note,id_wh_drawer ,id_report_status, last_update, last_update_by, id_ret_type, is_use_unique_code) "
                    query_main += "VALUES('" + id_store_contact_from + "', '" + id_comp_contact_to + "', '" + id_sales_return_order + "', '" + sales_return_number + "', '" + sales_return_store_number + "', NOW(), '" + sales_return_note + "','" + id_drawer + "', '1', NOW(), " + id_user + ",'" + id_ret_type + "', '" + is_use_unique_code + "');SELECT LAST_INSERT_ID(); "
                    id_sales_return = execute_query(query_main, 0, True, "", "", "", "")

                    If id_ret_type = "1" Then
                        increase_inc_sales("5")
                        'insert who prepared
                        insert_who_prepared("46", id_sales_return, id_user)
                    ElseIf id_ret_type = "3" Then
                        increase_inc_sales("5")
                        'insert who prepared
                        insert_who_prepared("113", id_sales_return, id_user)
                    ElseIf id_ret_type = "4" Then
                        increase_inc_sales("5")
                        'insert who prepared
                        insert_who_prepared("120", id_sales_return, id_user)
                    Else
                        increase_inc_sales("32")
                        'insert who prepared
                        insert_who_prepared("111", id_sales_return, id_user)
                    End If


                    'Detail return
                    Dim jum_ins_j As Integer = 0
                    Dim query_detail As String = ""
                    GVItemList.ActiveFilterString = "[sales_return_det_qty]>0 "
                    If GVItemList.RowCount > 0 Then
                        query_detail = "INSERT tb_sales_return_det(id_sales_return, id_sales_return_order_det, id_product, id_design_price, design_price, sales_return_det_qty, sales_return_det_note) VALUES "
                    End If
                    For j As Integer = 0 To ((GVItemList.RowCount - 1) - GetGroupRowCount(GVItemList))
                        Try
                            Dim id_sales_return_order_det As String = GVItemList.GetRowCellValue(j, "id_sales_return_order_det").ToString
                            Dim id_product As String = GVItemList.GetRowCellValue(j, "id_product").ToString
                            Dim id_design_price As String = GVItemList.GetRowCellValue(j, "id_design_price").ToString
                            Dim design_price As String = decimalSQL(GVItemList.GetRowCellValue(j, "design_price").ToString)
                            Dim sales_return_det_qty As String = decimalSQL(GVItemList.GetRowCellValue(j, "sales_return_det_qty").ToString)
                            Dim sales_return_det_note As String = GVItemList.GetRowCellValue(j, "sales_return_det_note").ToString

                            If jum_ins_j > 0 Then
                                query_detail += ", "
                            End If
                            query_detail += "('" + id_sales_return + "', '" + id_sales_return_order_det + "', '" + id_product + "', '" + id_design_price + "', '" + design_price + "', '" + sales_return_det_qty + "', '" + sales_return_det_note + "') "
                            jum_ins_j = jum_ins_j + 1
                        Catch ex As Exception
                        End Try
                    Next
                    If jum_ins_j > 0 Then
                        execute_non_query(query_detail, True, "", "", "", "")
                    End If
                    GVItemList.ActiveFilterString = ""

                    'get all detail id
                    Dim query_get_detail_id As String = "SELECT a.id_sales_return_det, a.id_product, a.id_design_price, a.design_price "
                    query_get_detail_id += "FROM tb_sales_return_det a "
                    query_get_detail_id += "WHERE a.id_sales_return = '" + id_sales_return + "' "
                    Dim data_get_detail_id As DataTable = execute_query(query_get_detail_id, -1, True, "", "", "", "")

                    'counting
                    Dim jum_ins_p As Integer = 0
                    Dim query_counting As String = ""
                    If GVBarcode.RowCount > 0 Then
                        query_counting = "INSERT INTO tb_sales_return_det_counting(id_sales_return_det, id_pl_prod_order_rec_det_unique, sales_return_det_counting, is_unique_report) VALUES "
                    End If
                    For p As Integer = 0 To (GVBarcode.RowCount - 1)
                        Dim id_product_counting As String = GVBarcode.GetRowCellValue(p, "id_product").ToString
                        Dim id_pl_prod_order_rec_det_unique As String = GVBarcode.GetRowCellValue(p, "id_pl_prod_order_rec_det_unique").ToString
                        If id_pl_prod_order_rec_det_unique = "0" Then
                            id_pl_prod_order_rec_det_unique = "NULL "
                        End If
                        Dim sales_return_det_counting As String = GVBarcode.GetRowCellValue(p, "counting_code").ToString
                        Dim is_unique_report As String = GVBarcode.GetRowCellValue(p, "is_unique_report").ToString
                        For p1 As Integer = 0 To (data_get_detail_id.Rows.Count - 1)
                            If id_product_counting = data_get_detail_id.Rows(p1)("id_product").ToString Then
                                If jum_ins_p > 0 Then
                                    query_counting += ", "
                                End If
                                query_counting += "('" + data_get_detail_id.Rows(p1)("id_sales_return_det").ToString + "', " + id_pl_prod_order_rec_det_unique + ", '" + sales_return_det_counting + "', '" + is_unique_report + "') "
                                jum_ins_p = jum_ins_p + 1
                                Exit For
                            End If
                        Next
                    Next
                    If jum_ins_p > 0 Then
                        execute_non_query(query_counting, True, "", "", "", "")
                    End If

                    'unik record
                    If is_use_unique_code = "1" Then
                        Dim un As New ClassSalesReturn()
                        un.insertUnique(id_sales_return)
                    End If

                    'code problem scan
                    Dim jum_ins_k As Integer = 0
                    Dim query_problem_stock As String = ""
                    If GVBarcodeProb.RowCount > 0 Then
                        query_problem_stock = "INSERT INTO tb_sales_return_problem(id_sales_return, id_product, scanned_code, remark) VALUES "
                    End If
                    For k As Integer = 0 To ((GVBarcodeProb.RowCount - 1) - GetGroupRowCount(GVBarcodeProb))
                        Dim id_product As String = GVBarcodeProb.GetRowCellValue(k, "id_product").ToString
                        Dim scanned_code As String = GVBarcodeProb.GetRowCellValue(k, "code").ToString
                        Dim remark As String = addSlashes(GVBarcodeProb.GetRowCellValue(k, "remark").ToString)
                        If jum_ins_k > 0 Then
                            query_problem_stock += ", "
                        End If
                        query_problem_stock += "('" + id_sales_return + "','" + id_product + "','" + scanned_code + "', '" + remark + "') "
                        jum_ins_k = jum_ins_k + 1
                    Next
                    If jum_ins_k > 0 Then
                        execute_non_query(query_problem_stock, True, "", "", "", "")
                    End If

                    'reserved stock
                    If id_ret_type <> "4" Then 'ol store reserved di ro
                        Dim stc_rev As ClassSalesReturn = New ClassSalesReturn()
                        stc_rev.reservedStock(id_sales_return)
                    End If


                    If id_ret_type = "1" Then
                        'submit who prepared
                        submit_who_prepared("46", id_sales_return, id_user)
                    ElseIf id_ret_type = "3" Then
                        'submit who prepared
                        submit_who_prepared("113", id_sales_return, id_user)
                    ElseIf id_ret_type = "4" Then
                        'submit who prepared
                        submit_who_prepared("120", id_sales_return, id_user)
                    Else
                        'submit who prepared
                        submit_who_prepared("111", id_sales_return, id_user)
                    End If


                    FormSalesReturn.viewSalesReturn()
                    FormSalesReturn.viewSalesReturnOrder()
                    FormSalesReturn.GVSalesReturn.FocusedRowHandle = find_row(FormSalesReturn.GVSalesReturn, "id_sales_return", id_sales_return)
                    action = "upd"
                    actionLoad()
                    exportToBOF(False)
                    infoCustom("Return #" + sales_return_number + " was created successfully ")
                ElseIf action = "upd" Then
                    'update main table
                    Dim sales_return_number As String = TxtSalesReturnNumber.Text
                    Dim query_main As String = "UPDATE tb_sales_return SET id_store_contact_from = '" + id_store_contact_from + "', id_comp_contact_to = '" + id_comp_contact_to + "', sales_return_store_number= '" + sales_return_store_number + "', sales_return_note = '" + sales_return_note + "',id_wh_drawer='" + id_drawer + "', last_update = NOW(), last_update_by=" + id_user + " WHERE id_sales_return = '" + id_sales_return + "'"
                    execute_non_query(query_main, True, "", "", "", "")

                    'update detail table
                    Dim jum_ins_j As Integer = 0
                    Dim query_detail As String = ""
                    If GVItemList.RowCount > 0 Then
                        query_detail = "INSERT tb_sales_return_det(id_sales_return, id_sales_return_order_det, id_product, id_design_price, design_price, sales_return_det_qty, sales_return_det_note) VALUES "
                    End If
                    For j As Integer = 0 To ((GVItemList.RowCount - 1) - GetGroupRowCount(GVItemList))
                        Try
                            Dim id_sales_return_det As String = GVItemList.GetRowCellValue(j, "id_sales_return_det").ToString
                            Dim id_sales_return_order_det As String = GVItemList.GetRowCellValue(j, "id_sales_return_order_det").ToString
                            Dim id_product As String = GVItemList.GetRowCellValue(j, "id_product").ToString
                            Dim id_design_price As String = GVItemList.GetRowCellValue(j, "id_design_price").ToString
                            Dim design_price As String = decimalSQL(GVItemList.GetRowCellValue(j, "design_price").ToString)
                            Dim sales_return_det_qty As String = decimalSQL(GVItemList.GetRowCellValue(j, "sales_return_det_qty").ToString)
                            Dim sales_return_det_note As String = GVItemList.GetRowCellValue(j, "sales_return_det_note").ToString

                            If id_sales_return_det = "0" Then
                                If jum_ins_j > 0 Then
                                    query_detail += ", "
                                End If
                                query_detail += "('" + id_sales_return + "', '" + id_sales_return_order_det + "', '" + id_product + "', '" + id_design_price + "', '" + design_price + "', '" + sales_return_det_qty + "', '" + sales_return_det_note + "') "
                                jum_ins_j = jum_ins_j + 1
                            Else
                                'Dim query_detail_upd As String = "UPDATE tb_sales_return_det SET id_product = '" + id_product + "', id_design_price = '" + id_design_price + "', design_price='" + design_price + "', sales_return_det_qty = '" + sales_return_det_qty + "', sales_return_det_note = '" + sales_return_det_note + "' WHERE id_sales_return_det = '" + id_sales_return_det + "'"
                                Dim query_detail_upd As String = "UPDATE tb_sales_return_det SET sales_return_det_note = '" + sales_return_det_note + "' WHERE id_sales_return_det = '" + id_sales_return_det + "'"
                                execute_non_query(query_detail_upd, True, "", "", "", "")
                                id_sales_return_det_list.Remove(id_sales_return_det)
                            End If
                        Catch ex As Exception
                        End Try
                    Next
                    If jum_ins_j > 0 Then
                        execute_non_query(query_detail, True, "", "", "", "")
                    End If

                    'For j_del As Integer = 0 To (id_sales_return_det_list.Count - 1)
                    '    Try
                    '        Dim query_detail_del As String = "DELETE FROM tb_sales_return_det WHERE id_sales_return_det = '" + id_sales_return_det_list(j_del) + "'"
                    '        execute_non_query(query_detail_del, True, "", "", "", "")
                    '    Catch ex As Exception

                    '    End Try
                    'Next

                    'get all detail id
                    'Dim query_get_detail_id As String = "SELECT a.id_sales_return_det, a.id_product, a.id_design_price, a.design_price "
                    'query_get_detail_id += "FROM tb_sales_return_det a "
                    'query_get_detail_id += "WHERE a.id_sales_return = '" + id_sales_return + "' "
                    'Dim data_get_detail_id As DataTable = execute_query(query_get_detail_id, -1, True, "", "", "", "")

                    'update counting
                    'Dim jum_ins_p As Integer = 0
                    'Dim query_counting As String = ""
                    'If GVBarcode.RowCount > 0 Then
                    '    query_counting = "INSERT INTO tb_sales_return_det_counting(id_sales_return_det, id_pl_prod_order_rec_det_unique, sales_return_det_counting) VALUES "
                    'End If
                    'For p As Integer = 0 To (GVBarcode.RowCount - 1)
                    '    Dim id_sales_return_det_counting As String = GVBarcode.GetRowCellValue(p, "id_sales_return_det_counting").ToString
                    '    Dim id_product_counting As String = GVBarcode.GetRowCellValue(p, "id_product")
                    '    Dim id_pl_prod_order_rec_det_unique As String = GVBarcode.GetRowCellValue(p, "id_pl_prod_order_rec_det_unique").ToString
                    '    If id_pl_prod_order_rec_det_unique = "0" Then
                    '        id_pl_prod_order_rec_det_unique = "NULL "
                    '    End If
                    '    Dim sales_return_det_counting As String = GVBarcode.GetRowCellValue(p, "counting_code").ToString
                    '    Dim id_design_price_counting As String = GVBarcode.GetRowCellValue(p, "id_design_price").ToString
                    '    Dim design_price_counting As Decimal = Decimal.Parse(GVBarcode.GetRowCellValue(p, "design_price").ToString)
                    '    For p1 As Integer = 0 To (data_get_detail_id.Rows.Count - 1)
                    '        If id_sales_return_det_counting = "0" Then
                    '            If id_product_counting = data_get_detail_id.Rows(p1)("id_product").ToString And id_design_price_counting = data_get_detail_id.Rows(p1)("id_design_price").ToString And design_price_counting = Decimal.Parse(data_get_detail_id.Rows(p1)("design_price").ToString) Then
                    '                If jum_ins_p > 0 Then
                    '                    query_counting += ", "
                    '                End If
                    '                query_counting += "('" + data_get_detail_id.Rows(p1)("id_sales_return_det").ToString + "', " + id_pl_prod_order_rec_det_unique + ", '" + sales_return_det_counting + "') "
                    '                jum_ins_p = jum_ins_p + 1
                    '                Exit For
                    '            End If
                    '        Else
                    '            Dim query_upd_counting As String = "UPDATE tb_sales_return_det_counting SET id_pl_prod_order_rec_det_unique = " + id_pl_prod_order_rec_det_unique + ", sales_return_det_counting = '" + sales_return_det_counting + "' WHERE id_sales_return_det_counting = '" + id_sales_return_det_counting + "'"
                    '            execute_non_query(query_upd_counting, True, "", "", "", "")
                    '            id_sales_return_det_counting_list.Remove(id_sales_return_det_counting)
                    '        End If
                    '    Next
                    'Next
                    'If jum_ins_p > 0 Then
                    '    execute_non_query(query_counting, True, "", "", "", "")
                    'End If

                    'For p_del As Integer = 0 To (id_sales_return_det_counting_list.Count - 1)
                    '    Try
                    '        Dim query_counting_del As String = "DELETE FROM tb_sales_return_det_counting WHERE id_sales_return_det_counting = '" + id_sales_return_det_counting_list(p_del) + "'"
                    '        execute_non_query(query_counting_del, True, "", "", "", "")
                    '    Catch ex As Exception

                    '    End Try
                    'Next

                    FormSalesReturn.viewSalesReturn()
                    FormSalesReturn.viewSalesReturnOrder()
                    FormSalesReturn.GVSalesReturn.FocusedRowHandle = find_row(FormSalesReturn.GVSalesReturn, "id_sales_return", id_sales_return)
                    action = "upd"
                    actionLoad()
                    exportToBOF(False)
                    infoCustom("Return #" + sales_return_number + " was edited successfully ")
                End If
                Cursor = Cursors.Default
            End If
        End If
    End Sub

    Sub disableControl()
        MENote.Enabled = False
        BtnSave.Enabled = False
        BtnVerify.Enabled = False
        BScan.Enabled = False
        BScanProb.Enabled = False
        BStop.Enabled = True
        BStopProb.Enabled = True
        BDelete.Enabled = False
        BDeleteProb.Enabled = False
        BtnCancel.Enabled = False
        ControlBox = False
        BtnAdd.Enabled = False
        BtnEdit.Enabled = False
        BtnDel.Enabled = False
        BtnInfoSrs.Enabled = False
        TxtStoreReturnNumber.Enabled = False
    End Sub

    Sub loadCodeDetail()
        Cursor = Cursors.WaitCursor
        Dim id_product_param As String = ""
        Dim id_product_param_or As String = ""
        For i As Integer = 0 To ((GVItemList.RowCount - 1) - GetGroupRowCount(GVItemList))
            id_product_param += GVItemList.GetRowCellValue(i, "id_product").ToString
            If i < ((GVItemList.RowCount - 1) - GetGroupRowCount(GVItemList)) Then
                id_product_param += ";"
            End If

            If i > 0 Then
                id_product_param_or += "OR "
            End If
            id_product_param_or += "u.id_product='" + GVItemList.GetRowCellValue(i, "id_product").ToString + "' "
        Next
        codeAvailableIns(id_product_param, id_product_param_or, id_store, "0")
        Cursor = Cursors.Default
    End Sub

    Sub loadCodeDetailProb()
        Cursor = Cursors.WaitCursor
        Dim id_product_param As String = ""
        For i As Integer = 0 To ((GVItemList.RowCount - 1) - GetGroupRowCount(GVItemList))
            id_product_param += GVItemList.GetRowCellValue(i, "id_product").ToString
            If i < ((GVItemList.RowCount - 1) - GetGroupRowCount(GVItemList)) Then
                id_product_param += ";"
            End If
        Next
        codeAvailableInsProb(id_product_param, id_store, "0")
        Cursor = Cursors.Default
    End Sub

    Private Sub BScan_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BScan.Click
        action_scan_btn = "start"
        If GVItemList.RowCount > 0 Then
            loadCodeDetail()
            verifyTrans()
            disableControl()
            newRowsBc()
        Else
            errorCustom("Item list can't blank")
        End If
    End Sub

    Private Sub BStop_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BStop.Click
        action_scan_btn = "stop"
        For i As Integer = 0 To (GVBarcode.RowCount - 1)
            Dim check_code As String = ""
            Try
                check_code = GVBarcode.GetRowCellValue(i, "code").ToString()
            Catch ex As Exception

            End Try
            If check_code = "" Or check_code = Nothing Or IsDBNull(check_code) Then
                GVBarcode.DeleteRow(i)
            End If
        Next
        enableControl()
    End Sub

    Sub enableControl()
        MENote.Enabled = True
        BtnSave.Enabled = True
        BtnVerify.Enabled = True
        BScan.Enabled = True
        BScanProb.Enabled = True
        BStop.Enabled = False
        BStopProb.Enabled = False
        BDelete.Enabled = True
        BDeleteProb.Enabled = True
        BtnCancel.Enabled = True
        allowDelete()
        ControlBox = True
        BtnAdd.Enabled = True
        BtnEdit.Enabled = True
        BtnDel.Enabled = True
        BtnInfoSrs.Enabled = True
        TxtStoreReturnNumber.Enabled = True
        LabelDelScan.Visible = False
        TxtDeleteScan.Visible = False
        LabelScanProb.Visible = False
        TxtScanProb.Visible = False
    End Sub

    Private Sub BDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BDelete.Click
        action_scan_btn = "delete"
        disableControl()
        LabelDelScan.Visible = True
        TxtDeleteScan.Visible = True
        TxtDeleteScan.Focus()
        'Dim id_sales_return_det_counting As String = "-1"
        'Try
        '    id_sales_return_det_counting = GVBarcode.GetFocusedRowCellValue("id_sales_return_det_counting").ToString
        'Catch ex As Exception
        'End Try

        'If action = "ins" Then
        '    Dim confirm As DialogResult = DevExpress.XtraEditors.XtraMessageBox.Show("Are you sure want to delete this data?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
        '    If confirm = Windows.Forms.DialogResult.Yes Then
        '        Dim id_product As String = GVBarcode.GetFocusedRowCellValue("id_product").ToString
        '        Dim bom_unit_price As Decimal = Decimal.Parse(GVBarcode.GetFocusedRowCellValue("bom_unit_price").ToString)
        '        Dim counting_code As String = GVBarcode.GetFocusedRowCellValue("counting_code").ToString
        '        Dim id_pl_prod_order_rec_det_unique As String = GVBarcode.GetFocusedRowCellValue("id_pl_prod_order_rec_det_unique").ToString
        '        Dim code As String = GVBarcode.GetFocusedRowCellValue("code").ToString

        '        deleteRowsBc()
        '        If id_product <> "" Or id_product <> Nothing Then
        '            GVBarcode.ApplyFindFilter("")
        '            countQty(id_product)
        '            countUnitCost(id_product, bom_unit_price)
        '        End If

        '        allowDelete()
        '    End If
        'ElseIf action = "upd" Then
        '    If id_sales_return_det_counting = "0" Then
        '        Dim confirm As DialogResult = DevExpress.XtraEditors.XtraMessageBox.Show("Are you sure want to delete this data?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
        '        If confirm = Windows.Forms.DialogResult.Yes Then
        '            Dim id_product As String = GVBarcode.GetFocusedRowCellValue("id_product").ToString
        '            Dim bom_unit_price As Decimal = Decimal.Parse(GVBarcode.GetFocusedRowCellValue("bom_unit_price").ToString)
        '            Dim counting_code As String = GVBarcode.GetFocusedRowCellValue("counting_code").ToString
        '            Dim id_pl_prod_order_rec_det_unique As String = GVBarcode.GetFocusedRowCellValue("id_pl_prod_order_rec_det_unique").ToString
        '            Dim code As String = GVBarcode.GetFocusedRowCellValue("code").ToString
        '            deleteRowsBc()
        '            If id_product <> "" Or id_product <> Nothing Then
        '                GVBarcode.ApplyFindFilter("")
        '                countQty(id_product)
        '                countUnitCost(id_product, bom_unit_price)
        '            End If
        '            allowDelete()
        '        End If
        '    Else
        '        errorCustom("This data already locked and can't delete.")
        '    End If
        'End If
    End Sub

    Private Sub GVBarcode_CustomColumnDisplayText_1(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs) Handles GVBarcode.CustomColumnDisplayText
        If e.Column.FieldName = "no" Then
            e.DisplayText = (e.ListSourceRowIndex + 1).ToString()
        End If
    End Sub

    Private Sub GVBarcode_FocusedColumnChanged(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.FocusedColumnChangedEventArgs) Handles GVBarcode.FocusedColumnChanged
        If Not GVBarcode.FocusedColumn.FieldName = "code" Then
            GVBarcode.FocusedColumn = GVBarcode.Columns("code")
        End If
    End Sub

    Private Sub GVBarcode_FocusedRowChanged(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles GVBarcode.FocusedRowChanged
        noEdit()
    End Sub

    Private Sub GVItemList_CustomColumnDisplayText(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs) Handles GVItemList.CustomColumnDisplayText
        If e.Column.FieldName = "no" Then
            e.DisplayText = (e.ListSourceRowIndex + 1).ToString()
        End If
    End Sub

    Private Sub GVBarcode_HiddenEditor(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GVBarcode.HiddenEditor
        Cursor = Cursors.WaitCursor
        Dim code_check As String = GVBarcode.GetFocusedRowCellValue("code").ToString
        Dim code_found As Boolean = False
        Dim code_duplicate As Boolean = False
        Dim counting_code As String = ""
        Dim id_pl_prod_order_rec_det_unique As String = ""
        Dim id_product As String = ""
        Dim product_name As String = ""
        Dim id_design_cat As String = ""
        Dim size As String = ""
        Dim bom_unit_price As Decimal = 0.0
        Dim index_atas As Integer = -100
        Dim is_old As String = "0"
        Dim jum_scan As Integer = 0
        Dim jum_limit As Integer = 0
        Dim is_unique_report As String = "2"

        'check in ro 
        Dim code_list_found As Boolean = False
        Dim code_list As String = ""
        If code_check.Length >= 12 Then
            code_list = code_check.Substring(0, 12)
        Else
            code_list = code_check
        End If
        GVItemList.ActiveFilterString = "[code]='" + code_list + "' "
        GVItemList.FocusedRowHandle = 0
        If GVItemList.RowCount > 0 Then
            code_list_found = True
        End If
        makeSafeGV(GVItemList)

        If code_list_found Then
            'check available code
            Dim dt_filter As DataRow() = dt.Select("[product_full_code]='" + code_check + "' ")
            If dt_filter.Length > 0 Then
                counting_code = dt_filter(0)("product_counting_code").ToString
                id_pl_prod_order_rec_det_unique = dt_filter(0)("id_pl_prod_order_rec_det_unique").ToString
                id_product = dt_filter(0)("id_product").ToString
                product_name = dt_filter(0)("name").ToString
                size = dt_filter(0)("size").ToString
                bom_unit_price = Decimal.Parse(dt_filter(0)("bom_unit_price").ToString)
                is_old = dt_filter(0)("is_old_design").ToString
                is_unique_report = dt_filter(0)("is_unique_report").ToString
                code_found = True
            End If

            'get jum del & limit
            If id_commerce_type = "2" Then 'online store
                GVItemList.ActiveFilterString = "[id_product]='" + id_product + "' AND [diff]>0 "
            Else
                GVItemList.ActiveFilterString = "[id_product]='" + id_product + "' "
            End If


            GVItemList.FocusedRowHandle = 0
            Try
                jum_limit = GVItemList.GetFocusedRowCellValue("sales_return_det_qty_limit")
            Catch ex As Exception
            End Try
            Try
                jum_scan = GVItemList.GetFocusedRowCellValue("sales_return_det_qty")
            Catch ex As Exception
            End Try
            makeSafeGV(GVItemList)


            If is_old = "1" Then 'old product
                If jum_limit <= 0 Then
                    GVBarcode.SetRowCellValue(GVBarcode.RowCount - 1, "code", "")
                    GVBarcode.FocusedRowHandle = GVBarcode.RowCount - 1
                    stopCustom("This item cannot scan, because limit qty is zero.")
                ElseIf jum_scan >= jum_limit Then
                    GVBarcode.SetRowCellValue(GVBarcode.RowCount - 1, "code", "")
                    GVBarcode.FocusedRowHandle = GVBarcode.RowCount - 1
                    stopCustom("Maximum qty : " + jum_limit.ToString)
                Else
                    GVBarcode.SetRowCellValue(GVBarcode.RowCount - 1, "id_pl_prod_order_rec_det_unique", id_pl_prod_order_rec_det_unique)
                    GVBarcode.SetRowCellValue(GVBarcode.RowCount - 1, "id_sales_return_det_counting", "0")
                    GVBarcode.SetRowCellValue(GVBarcode.RowCount - 1, "is_fix", "2")
                    GVBarcode.SetRowCellValue(GVBarcode.RowCount - 1, "counting_code", counting_code)
                    GVBarcode.SetRowCellValue(GVBarcode.RowCount - 1, "id_product", id_product)
                    GVBarcode.SetRowCellValue(GVBarcode.RowCount - 1, "name", product_name)
                    GVBarcode.SetRowCellValue(GVBarcode.RowCount - 1, "size", size)
                    GVBarcode.SetRowCellValue(GVBarcode.RowCount - 1, "bom_unit_price", bom_unit_price)
                    GVBarcode.SetRowCellValue(GVBarcode.RowCount - 1, "is_unique_report", is_unique_report)
                    countQty(id_product)
                    checkUnitCost(id_product, bom_unit_price)
                    newRowsBc()
                    GCItemList.RefreshDataSource()
                    GVItemList.RefreshData()
                End If
            ElseIf is_old = "2" Or is_old = "3" Then 'new product
                'check duplicate code
                GVBarcode.ActiveFilterString = "[code]='" + code_check + "' AND [is_fix]='2' "
                If GVBarcode.RowCount > 0 Then
                    code_duplicate = True
                End If
                GVBarcode.ActiveFilterString = ""

                If Not code_found Then
                    GVBarcode.SetRowCellValue(GVBarcode.RowCount - 1, "code", "")
                    GVBarcode.FocusedRowHandle = GVBarcode.RowCount - 1
                    stopCustom("Code not found !")
                ElseIf code_duplicate Then
                    GVBarcode.SetRowCellValue(GVBarcode.RowCount - 1, "code", "")
                    GVBarcode.FocusedRowHandle = GVBarcode.RowCount - 1
                    stopCustom("Data duplicate !")
                Else
                    If jum_limit <= 0 Then
                        GVBarcode.SetRowCellValue(GVBarcode.RowCount - 1, "code", "")
                        GVBarcode.FocusedRowHandle = GVBarcode.RowCount - 1
                        stopCustom("This item cannot scan, because limit qty is zero.")
                    ElseIf jum_scan >= jum_limit Then
                        GVBarcode.SetRowCellValue(GVBarcode.RowCount - 1, "code", "")
                        GVBarcode.FocusedRowHandle = GVBarcode.RowCount - 1
                        stopCustom("Maximum qty : " + jum_limit.ToString)
                    Else
                        GVBarcode.SetRowCellValue(GVBarcode.RowCount - 1, "id_pl_prod_order_rec_det_unique", id_pl_prod_order_rec_det_unique)
                        GVBarcode.SetRowCellValue(GVBarcode.RowCount - 1, "id_sales_return_det_counting", "0")
                        GVBarcode.SetRowCellValue(GVBarcode.RowCount - 1, "is_fix", "2")
                        GVBarcode.SetRowCellValue(GVBarcode.RowCount - 1, "counting_code", counting_code)
                        GVBarcode.SetRowCellValue(GVBarcode.RowCount - 1, "id_product", id_product)
                        GVBarcode.SetRowCellValue(GVBarcode.RowCount - 1, "name", product_name)
                        GVBarcode.SetRowCellValue(GVBarcode.RowCount - 1, "size", size)
                        GVBarcode.SetRowCellValue(GVBarcode.RowCount - 1, "bom_unit_price", bom_unit_price)
                        GVBarcode.SetRowCellValue(GVBarcode.RowCount - 1, "is_unique_report", is_unique_report)
                        countQty(id_product)
                        checkUnitCost(id_product, bom_unit_price)
                        newRowsBc()
                        GCItemList.RefreshDataSource()
                        GVItemList.RefreshData()
                    End If
                End If
            Else
                GVBarcode.SetRowCellValue(GVBarcode.RowCount - 1, "code", "")
                GVBarcode.FocusedRowHandle = GVBarcode.RowCount - 1
                stopCustom("Code not found !")
            End If
        Else
            GVBarcode.SetRowCellValue(GVBarcode.RowCount - 1, "code", "")
            GVBarcode.FocusedRowHandle = GVBarcode.RowCount - 1
            stopCustom("Product not found in return order list!")
        End If
        Cursor = Cursors.Default
    End Sub

    Sub deleteDetailBC(ByVal id_product_param As String)
        'delete detail
        Dim i As Integer = GVBarcode.RowCount - 1
        While (i >= 0)
            Dim id_product As String = ""
            Try
                id_product = GVBarcode.GetRowCellValue(i, "id_product").ToString()
            Catch ex As Exception

            End Try
            If id_product = id_product_param Then
                GVBarcode.DeleteRow(i)
            End If
            i = i - 1
        End While
    End Sub

    Sub deleteDetailDrawer(ByVal id_product_param As String)
        'delete(detail)
        Dim i As Integer = GVDrawer.RowCount - 1
        While (i >= 0)
            'MsgBox(id_product_param)
            Dim id_product As String = ""
            Try
                id_product = GVDrawer.GetRowCellValue(i, "id_product").ToString()
            Catch ex As Exception

            End Try
            If id_product = id_product_param Then
                GVDrawer.DeleteRow(i)
            End If
            i = i - 1
        End While
    End Sub

    Private Sub BtnInfoSrs_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnInfoSrs.Click
        infoQty()
    End Sub

    Sub infoQty()
        FormInfoSalesReturnOrder.id_pop_up = "1"
        FormInfoSalesReturnOrder.id_sales_return_order = id_sales_return_order
        FormInfoSalesReturnOrder.id_sales_return_order_det = "0"
        If action = "ins" Then
            FormInfoSalesReturnOrder.id_sales_return = "0"
        Else
            FormInfoSalesReturnOrder.id_sales_return = "0"
        End If
        FormInfoSalesReturnOrder.id_wh_drawer = id_wh_drawer_store
        FormInfoSalesReturnOrder.id_wh_rack = id_wh_rack_store
        FormInfoSalesReturnOrder.id_wh_locator = id_wh_locator_store
        FormInfoSalesReturnOrder.ShowDialog()
    End Sub


    Private Sub BtnTest_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnTest.Click
        ' jika complete
        Dim stc_compl As ClassSalesReturn = New ClassSalesReturn()
        stc_compl.completeReservedStock(id_sales_return)
        MsgBox("Done")
    End Sub

    Sub getReport()
        GridColumnNo.VisibleIndex = 0
        GVItemList.ActiveFilterString = "[sales_return_det_qty]>0"
        For i As Integer = 0 To GVItemList.RowCount - 1
            GVItemList.SetRowCellValue(i, "no", (i + 1).ToString)
        Next
        GCItemList.RefreshDataSource()
        GVItemList.RefreshData()
        ReportSalesReturn.dt = GCItemList.DataSource
        ReportSalesReturn.id_sales_return = id_sales_return
        Dim Report As New ReportSalesReturn()

        ' '... 
        ' ' creating and saving the view's layout to a new memory stream 
        Dim str As System.IO.Stream
        str = New System.IO.MemoryStream()
        GVItemList.SaveLayoutToStream(str, DevExpress.Utils.OptionsLayoutBase.FullLayout)
        str.Seek(0, System.IO.SeekOrigin.Begin)
        Report.GridView1.RestoreLayoutFromStream(str, DevExpress.Utils.OptionsLayoutBase.FullLayout)
        str.Seek(0, System.IO.SeekOrigin.Begin)

        'Grid Detail
        ReportStyleGridview(Report.GridView1)

        'Parse val
        Report.LRecNumber.Text = TxtSalesReturnNumber.Text
        Report.LRecDate.Text = DEForm.Text
        Report.LabelReturnOrder.Text = TxtSalesReturnOrderNumber.Text
        Report.LabelFrom.Text = TxtCodeCompFrom.Text + " - " + TxtNameCompFrom.Text
        Report.LabelAddressFrom.Text = MEAdrressCompFrom.Text
        Report.LabelTo.Text = TxtCodeCompTo.Text + " - " + TxtNameCompTo.Text
        Report.LLocator.Text = locator_sel
        Report.LRack.Text = rack_sel
        Report.LDrawer.Text = drawer_sel
        Report.LabelNote.Text = MENote.Text


        'Show the report's preview. 
        Dim Tool As DevExpress.XtraReports.UI.ReportPrintTool = New DevExpress.XtraReports.UI.ReportPrintTool(Report)
        Tool.ShowPreview()
        GVItemList.ActiveFilterString = ""
        GridColumnNo.Visible = False
    End Sub

    Sub checkUnitCost(ByVal id_product_param As String, ByVal bom_unit_price_param As Decimal)

    End Sub

    Sub countUnitCost(ByVal id_product_param As String, ByVal bom_unit_price_param As Decimal)
        Dim tot As Decimal = 0.0
        For i As Integer = 0 To GVBarcode.RowCount - 1
            Dim id_product As String = "-1"
            Dim cost As Decimal = 0.0
            Try
                id_product = GVBarcode.GetRowCellValue(i, "id_product").ToString
                cost = Decimal.Parse(GVBarcode.GetRowCellValue(i, "bom_unit_price").ToString)
            Catch ex As Exception
            End Try

            If id_product = id_product_param And cost = bom_unit_price_param Then
                tot = tot + 1.0
            End If
        Next

        'cari yg sesuai
        For j As Integer = 0 To (GVDrawer.RowCount - 1)
            Dim id_product_cek As String = "-1"
            Dim cost As Decimal = 0.0
            Try
                id_product_cek = GVDrawer.GetRowCellValue(j, "id_product").ToString
                cost = Decimal.Parse(GVDrawer.GetRowCellValue(j, "bom_unit_price").ToString)
                If id_product_cek = id_product_param And bom_unit_price_param = cost Then
                    'MsgBox(tot.ToString)
                    GVDrawer.SetRowCellValue(j, "sales_return_det_drawer_qty", tot)
                    Exit For
                End If
            Catch ex As Exception
            End Try
        Next
    End Sub

    Private Sub BtnSaveToStorage_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSaveToStorage.Click
        Cursor = Cursors.WaitCursor
        Dim sales_return_det_drawer_qty As Decimal = Decimal.Parse(GVDrawer.GetFocusedRowCellValue("sales_return_det_drawer_qty"))
        Dim sales_return_det_drawer_qty_stored As Decimal = Decimal.Parse(GVDrawer.GetFocusedRowCellValue("sales_return_det_drawer_qty_stored"))
        If sales_return_det_drawer_qty <> sales_return_det_drawer_qty_stored Then
            FormProductionStorageIn.id_transaction_det = GVDrawer.GetFocusedRowCellValue("id_sales_return_det_drawer").ToString
            FormProductionStorageIn.id_design = GVItemList.GetFocusedRowCellValue("id_design").ToString
            FormProductionStorageIn.id_sample = GVItemList.GetFocusedRowCellValue("id_sample").ToString
            FormProductionStorageIn.action = "ins"
            FormProductionStorageIn.colorku = GVItemList.GetFocusedRowCellValue("color").ToString
            FormProductionStorageIn.sizeku = GVItemList.GetFocusedRowCellValue("size").ToString
            FormProductionStorageIn.id_report = id_sales_return
            FormProductionStorageIn.report_mark_type = "46"
            FormProductionStorageIn.id_product = GVDrawer.GetFocusedRowCellValue("id_product").ToString
            FormProductionStorageIn.cost = Decimal.Parse(GVDrawer.GetFocusedRowCellValue("bom_unit_price").ToString)
            FormProductionStorageIn.id_pop_up = "2"
            FormProductionStorageIn.id_wh_origin = id_comp_to
            FormProductionStorageIn.ShowDialog()
        Else
            errorCustom("- All item for this product has been stored in warehouse" + System.Environment.NewLine + "- If yo want to edit location storage, please edit on 'Transfer Product' menu")
        End If
        Cursor = Cursors.Default
    End Sub

    Private Sub GVDrawer_FocusedRowChanged(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles GVDrawer.FocusedRowChanged
        Try
            Dim id_product As String = GVDrawer.GetFocusedRowCellValue("id_product").ToString
            Dim id_design_price As String = GVDrawer.GetFocusedRowCellValue("id_design_price").ToString

            Dim indeks As Integer
            For i As Integer = 0 To (GVItemList.RowCount - 1)
                Try
                    If id_product = GVDrawer.GetRowCellValue(i, "id_product").ToString And id_design_price = GVDrawer.GetRowCellValue(i, "id_design_price").ToString Then
                        indeks = i
                        Exit For
                    End If
                Catch ex As Exception
                End Try
            Next
            GVItemList.FocusedRowHandle = indeks

            'drawer detail
            check_but_drawer()
        Catch ex As Exception
        End Try
    End Sub

    'Color Cell
    Public Sub my_color_cell(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs)
        'MsgBox("HAH")
        Dim View As DevExpress.XtraGrid.Views.Grid.GridView = sender

        e.Appearance.BackColor = Color.White
        e.Appearance.BackColor2 = Color.White

        Try
            Dim id_product_style As String = GVItemList.GetFocusedRowCellValue("id_product").ToString
            Dim id_design_price_style As String = GVItemList.GetFocusedRowCellValue("id_design_price").ToString

            Dim id_product_check As String = View.GetRowCellValue(e.RowHandle, View.Columns("id_product"))
            Dim id_design_price_check As String = View.GetRowCellValue(e.RowHandle, View.Columns("id_design_price"))
            If id_product_check = id_product_style And id_design_price_check = id_design_price_style Then
                e.Appearance.BackColor = Color.Lavender
                e.Appearance.BackColor2 = Color.White
            End If
        Catch ex As Exception

        End Try
    End Sub

    Sub check_but_drawer()
        If GVDrawer.RowCount > 0 Then
            PanelNavStorage.Enabled = True
        Else
            PanelNavStorage.Enabled = False
        End If
    End Sub

    Private Sub BPickDrawer_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BPickDrawer.Click
        FormPopUpDrawer.id_pop_up = "1"
        Dim id_comp_param As String = "0"
        Try
            id_comp_param = get_id_company(id_comp_contact_to)
        Catch ex As Exception
        End Try
        FormPopUpDrawer.id_comp = id_comp_param
        FormPopUpDrawer.ShowDialog()
    End Sub

    Private Sub TEDrawer_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TEDrawer.Validating
        EP_TE_cant_blank(EPForm, TEDrawer)
        EPForm.SetIconPadding(TEDrawer, 30)
    End Sub

    Private Sub BtnAttachment_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnAttachment.Click
        Cursor = Cursors.WaitCursor
        FormDocumentUpload.id_report = id_sales_return
        If id_ret_type = "1" Then
            FormDocumentUpload.report_mark_type = "46"
        ElseIf id_ret_type = "3" Then
            FormDocumentUpload.report_mark_type = "113"
        ElseIf id_ret_type = "4" Then
            FormDocumentUpload.report_mark_type = "120"
        Else
            FormDocumentUpload.report_mark_type = "111"
        End If
        FormDocumentUpload.is_view = is_view
        FormDocumentUpload.ShowDialog()
        Cursor = Cursors.Default
    End Sub

    Private Sub BtnPrePrinting_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BtnPrePrinting.ItemClick
        prePrinting()
    End Sub

    Sub prePrinting()
        Cursor = Cursors.WaitCursor
        ReportSalesReturn.id_pre = "1"
        getReport()
        Cursor = Cursors.Default
    End Sub

    Private Sub BtnPrint_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BtnPrint.ItemClick
        printing()
    End Sub

    Sub printing()
        Cursor = Cursors.WaitCursor
        ReportSalesReturn.id_pre = "-1"
        getReport()
        Cursor = Cursors.Default
    End Sub

    Private Sub TxtDeleteScan_KeyDown(sender As Object, e As KeyEventArgs) Handles TxtDeleteScan.KeyDown
        If e.KeyCode = Keys.Enter And TxtDeleteScan.Text.Length > 0 Then
            Cursor = Cursors.WaitCursor
            GVBarcode.ActiveFilterString = "[code]='" + TxtDeleteScan.Text + "'"
            If GVBarcode.RowCount <= 0 Then
                stopCustom("Code not found.")
                GVBarcode.ActiveFilterString = ""
                TxtDeleteScan.Text = ""
                TxtDeleteScan.Focus()
            Else
                Dim id_sales_return_det_counting As String = "-1"
                Try
                    id_sales_return_det_counting = GVBarcode.GetFocusedRowCellValue("id_sales_return_det_counting").ToString
                Catch ex As Exception
                End Try

                If action = "ins" Then
                    Dim confirm As DialogResult = DevExpress.XtraEditors.XtraMessageBox.Show("Are you sure want to delete this data?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
                    If confirm = Windows.Forms.DialogResult.Yes Then
                        Dim id_product As String = GVBarcode.GetFocusedRowCellValue("id_product").ToString
                        Dim bom_unit_price As Decimal = Decimal.Parse(GVBarcode.GetFocusedRowCellValue("bom_unit_price").ToString)
                        Dim counting_code As String = GVBarcode.GetFocusedRowCellValue("counting_code").ToString
                        Dim id_pl_prod_order_rec_det_unique As String = GVBarcode.GetFocusedRowCellValue("id_pl_prod_order_rec_det_unique").ToString
                        Dim code As String = GVBarcode.GetFocusedRowCellValue("code").ToString

                        deleteRowsBc()
                        If id_product <> "" Or id_product <> Nothing Then
                            GVBarcode.ApplyFindFilter("")
                            GVBarcode.ActiveFilterString = ""
                            countQty(id_product)
                            countUnitCost(id_product, bom_unit_price)
                        End If
                        GCItemList.RefreshDataSource()
                        GVItemList.RefreshData()
                        allowDelete()
                    Else
                        GVBarcode.ActiveFilterString = ""
                    End If
                    TxtDeleteScan.Text = ""
                    TxtDeleteScan.Focus()
                ElseIf action = "upd" Then
                    If id_sales_return_det_counting = "0" Then
                        Dim confirm As DialogResult = DevExpress.XtraEditors.XtraMessageBox.Show("Are you sure want to delete this data?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
                        If confirm = Windows.Forms.DialogResult.Yes Then
                            Dim id_product As String = GVBarcode.GetFocusedRowCellValue("id_product").ToString
                            Dim bom_unit_price As Decimal = Decimal.Parse(GVBarcode.GetFocusedRowCellValue("bom_unit_price").ToString)
                            Dim counting_code As String = GVBarcode.GetFocusedRowCellValue("counting_code").ToString
                            Dim id_pl_prod_order_rec_det_unique As String = GVBarcode.GetFocusedRowCellValue("id_pl_prod_order_rec_det_unique").ToString
                            Dim code As String = GVBarcode.GetFocusedRowCellValue("code").ToString
                            deleteRowsBc()
                            If id_product <> "" Or id_product <> Nothing Then
                                GVBarcode.ApplyFindFilter("")
                                GVBarcode.ActiveFilterString = ""
                                countQty(id_product)
                                countUnitCost(id_product, bom_unit_price)
                            End If
                            GCItemList.RefreshDataSource()
                            GVItemList.RefreshData()
                            allowDelete()
                        Else
                            GVBarcode.ActiveFilterString = ""
                        End If
                    Else
                        errorCustom("This data already locked and can't delete.")
                    End If
                    TxtDeleteScan.Text = ""
                    TxtDeleteScan.Focus()
                End If
            End If
            Cursor = Cursors.Default
        End If
    End Sub

    Sub exportToBOF(ByVal show_msg As Boolean)
        If bof_column = "1" Then
            Cursor = Cursors.WaitCursor

            'hide column
            For c As Integer = 0 To GVItemList.Columns.Count - 1
                GVItemList.Columns(c).Visible = False
            Next
            GridColumnCode.VisibleIndex = 0
            GridColumnQty.VisibleIndex = 1
            GridColumnNumber.VisibleIndex = 2
            GridColumnFrom.VisibleIndex = 3
            GridColumnTo.VisibleIndex = 4
            GridColumnRemark.VisibleIndex = 5
            GVItemList.OptionsPrint.PrintFooter = False
            GVItemList.OptionsPrint.PrintHeader = False


            'export excel
            Dim path_root As String = ""
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
                ExportToExcel(GVItemList, exp, show_msg)
            Catch ex As Exception
                stopCustom("Please close your excel file first then try again later")
            End Try

            'show column
            GridColumnCode.VisibleIndex = 0
            GridColumnName.VisibleIndex = 1
            GridColumnSize.VisibleIndex = 2
            GridColumnQty.VisibleIndex = 3
            GridColumnPriceType.VisibleIndex = 4
            GridColumnPrice.VisibleIndex = 5
            GridColumnAmount.VisibleIndex = 6
            GridColumnRemark.VisibleIndex = 7
            GridColumnStt.Visible = False
            GridColumnNumber.Visible = False
            GridColumnFrom.Visible = False
            GridColumnTo.Visible = False
            GVItemList.OptionsPrint.PrintFooter = True
            GVItemList.OptionsPrint.PrintHeader = True
            Cursor = Cursors.Default
        End If
    End Sub

    Public Sub ExportToExcel(ByVal dtTemp As DevExpress.XtraGrid.Views.Grid.GridView, ByVal filepath As String, show_msg As Boolean)
        Dim strFileName As String = filepath
        If System.IO.File.Exists(strFileName) Then
            System.IO.File.Delete(strFileName)
        End If
        Dim _excel As New Excel.Application
        Dim wBook As Excel.Workbook
        Dim wSheet As Excel.Worksheet

        wBook = _excel.Workbooks.Add()
        wSheet = wBook.ActiveSheet()


        Dim colIndex As Integer = 0
        Dim rowIndex As Integer = -1

        ' export the Columns 
        'If CheckBox1.Checked Then
        '    For Each dc In dt.Columns
        '        colIndex = colIndex + 1
        '        wSheet.Cells(1, colIndex) = dc.ColumnName
        '    Next
        'End If

        'export the rows 
        For i As Integer = 0 To dtTemp.RowCount - 1
            rowIndex = rowIndex + 1
            colIndex = 0
            For j As Integer = 0 To dtTemp.VisibleColumns.Count - 1
                colIndex = colIndex + 1
                If j = 0 Then 'code
                    wSheet.Cells(rowIndex + 1, colIndex) = dtTemp.GetRowCellValue(i, "code").ToString
                ElseIf j = 1 Then 'qty
                    wSheet.Cells(rowIndex + 1, colIndex) = dtTemp.GetRowCellValue(i, "sales_return_det_qty")
                ElseIf j = 2 Then  'number
                    wSheet.Cells(rowIndex + 1, colIndex) = dtTemp.GetRowCellDisplayText(i, "number").ToString
                ElseIf j = 3 Then  'from
                    wSheet.Cells(rowIndex + 1, colIndex) = dtTemp.GetRowCellDisplayText(i, "from").ToString
                ElseIf j = 4 Then  'to
                    wSheet.Cells(rowIndex + 1, colIndex) = dtTemp.GetRowCellDisplayText(i, "to").ToString
                Else
                    wSheet.Cells(rowIndex + 1, colIndex) = dtTemp.GetRowCellValue(i, "sales_return_det_note").ToString
                End If
            Next
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

        If show_msg Then
            infoCustom("File exported successfully")
        End If
    End Sub

    Private Sub ReleaseObject(ByVal o As Object)
        Try
            While (System.Runtime.InteropServices.Marshal.ReleaseComObject(o) > 0)
            End While
        Catch
        Finally
            o = Nothing
        End Try
    End Sub

    Sub exportToBOFProb(ByVal show_msg As Boolean)
        If bof_column = "1" Then
            Cursor = Cursors.WaitCursor

            'export excel
            Dim path_root As String = ""
            Try
                ' Open the file using a stream reader.
                Using sr As New IO.StreamReader(Application.StartupPath & "\bof_path.txt")
                    ' Read the stream to a string and write the string to the console.
                    path_root = sr.ReadToEnd()
                End Using
            Catch ex As Exception
            End Try

            Dim fileName As String = bof_xls_nsi + ".xls"
            Dim exp As String = IO.Path.Combine(path_root, fileName)
            ' Try
            ExportToExcelProb(exp, show_msg)
            'Catch ex As Exception
            'stopCustom("Please close your excel file first then try again later")
            'End Try
            Cursor = Cursors.Default
        End If
    End Sub

    Public Sub ExportToExcelProb(ByVal filepath As String, show_msg As Boolean)
        Dim strFileName As String = filepath
        If System.IO.File.Exists(strFileName) Then
            System.IO.File.Delete(strFileName)
        End If
        Dim _excel As New Excel.Application
        Dim wBook As Excel.Workbook
        Dim wSheet As Excel.Worksheet

        wBook = _excel.Workbooks.Add()
        wSheet = wBook.ActiveSheet()


        Dim colIndex As Integer = 0
        Dim rowIndex As Integer = -1

        ' export the Columns 
        Dim query As String = "SELECT p.id_product,p.product_full_code AS `code` , d.design_display_name AS `name`, cd.code_detail_name AS `size`,
        COUNT(rp.id_product) AS `qty`, r.sales_return_number AS `number`, s.comp_number AS `from`,
        o.non_inv_account AS `to`
        FROM tb_sales_return_problem rp
        INNER JOIN tb_sales_return r ON r.id_sales_return = rp.id_sales_return
        INNER JOIN tb_m_comp_contact sc ON sc.id_comp_contact = r.id_store_contact_from
        INNER JOIN tb_m_comp s ON s.id_comp = sc.id_comp
        INNER JOIN tb_m_product p ON p.id_product = RP.id_product
        INNER JOIN tb_m_product_code pc ON pc.id_product = p.id_product
        INNER JOIN tb_m_code_detail cd ON cd.id_code_detail = pc.id_code_detail
        INNER JOIN tb_m_design d ON d.id_design = p.id_design
        JOIN tb_opt_sales o
        WHERE rp.id_sales_return='" + id_sales_return + "'
        GROUP BY rp.id_product "
        Dim dtTemp As DataTable = execute_query(query, -1, True, "", "", "", "")

        'export the rows 
        For i As Integer = 0 To dtTemp.Rows.Count - 1
            rowIndex = rowIndex + 1
            colIndex = 0

            For j As Integer = 0 To dtTemp.Columns.Count - 1
                colIndex = colIndex + 1
                If j = 0 Then 'code
                    wSheet.Cells(rowIndex + 1, colIndex) = dtTemp.Rows(i)("code").ToString
                ElseIf j = 1 Then 'qty
                    wSheet.Cells(rowIndex + 1, colIndex) = dtTemp.Rows(i)("qty")
                ElseIf j = 2 Then  'number
                    wSheet.Cells(rowIndex + 1, colIndex) = dtTemp.Rows(i)("number").ToString
                ElseIf j = 3 Then  'from
                    wSheet.Cells(rowIndex + 1, colIndex) = dtTemp.Rows(i)("from").ToString
                ElseIf j = 4 Then  'to
                    wSheet.Cells(rowIndex + 1, colIndex) = dtTemp.Rows(i)("to").ToString
                Else
                    wSheet.Cells(rowIndex + 1, colIndex) = ""
                End If
            Next
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

        If show_msg Then
            infoCustom("File exported successfully")
        End If
    End Sub



    Private Sub BtnXlsBOF_Click(sender As Object, e As EventArgs) Handles BtnXlsBOF.Click
        exportToBOF(False)
    End Sub

    Private Sub GVItemList_RowCellStyle(sender As Object, e As DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs) Handles GVItemList.RowCellStyle
        If e.RowHandle >= 0 Then
            If (e.Column.FieldName = "status") Then
                Dim val As Integer = 0
                Try
                    val = CType(sender.GetRowCellValue(e.RowHandle, sender.Columns("status")), Integer)
                Catch ex As Exception

                End Try
                If val > 0 Then
                    e.Appearance.BackColor = Color.Salmon
                    e.Appearance.BackColor2 = Color.Salmon
                ElseIf val < 0 Then
                    e.Appearance.BackColor = Color.Yellow
                    e.Appearance.BackColor2 = Color.Yellow
                Else
                    e.Appearance.BackColor = Color.Green
                    e.Appearance.BackColor2 = Color.Green
                End If
            End If
        End If
    End Sub

    Private Sub BtnVerify_Click(sender As Object, e As EventArgs) Handles BtnVerify.Click
        Cursor = Cursors.WaitCursor
        verifyTrans()
        Cursor = Cursors.Default
    End Sub

    Private Sub GVItemList_CustomDrawRowIndicator(sender As Object, e As DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs) Handles GVItemList.CustomDrawRowIndicator
        If e.RowHandle >= 0 Then
            e.Info.DisplayText = (e.RowHandle + 1).ToString
        End If
    End Sub

    Private Sub GVItemList_CustomUnboundColumnData(sender As Object, e As DevExpress.XtraGrid.Views.Base.CustomColumnDataEventArgs) Handles GVItemList.CustomUnboundColumnData
        Dim view As DevExpress.XtraGrid.Views.Grid.GridView = TryCast(sender, DevExpress.XtraGrid.Views.Grid.GridView)
        If e.Column.FieldName = "from" AndAlso e.IsGetData Then
            e.Value = TxtCodeCompFrom.Text.ToString
        ElseIf e.Column.FieldName = "to" AndAlso e.IsGetData Then
            e.Value = TxtCodeCompTo.Text.ToString
        ElseIf e.Column.FieldName = "number" AndAlso e.IsGetData Then
            e.Value = TxtSalesReturnNumber.Text.ToString
        ElseIf e.Column.FieldName = "status" AndAlso e.IsGetData Then
            e.Value = getDiff(view, e.ListSourceRowIndex)
        End If
    End Sub

    Private Function getDiff(view As DevExpress.XtraGrid.Views.Grid.GridView, listSourceRowIndex As Integer) As String
        Dim qty As Integer = Convert.ToInt32(view.GetListSourceRowCellValue(listSourceRowIndex, "sales_return_det_qty"))
        Dim limit As Integer = Convert.ToInt32(view.GetListSourceRowCellValue(listSourceRowIndex, "sales_return_det_qty_limit"))
        Dim diff As Integer = qty - limit
        Dim stt As String = ""
        If diff > 0 Then
            stt = "+" + diff.ToString
        Else
            stt = diff.ToString
        End If
        Return stt
    End Function

    Private Sub BScanProb_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub TxtScanProb_KeyDown(sender As Object, e As KeyEventArgs)

    End Sub

    Private Sub BStopProb_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub BDeleteProb_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub GVBarcodeProb_CustomColumnDisplayText(sender As Object, e As DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs)

    End Sub

    Private Sub GVBarcodeProb_HiddenEditor(sender As Object, e As EventArgs) Handles GVBarcodeProb.HiddenEditor

    End Sub

    Private Sub TxtScanProb_KeyDown_1(sender As Object, e As KeyEventArgs) Handles TxtScanProb.KeyDown
        If e.KeyCode = Keys.Enter Then
            Cursor = Cursors.WaitCursor
            Dim code As String = addSlashes(TxtScanProb.Text)

            If is_scan_prob = "1" Then 'scan
                Dim query As String = "CALL view_scan_code_active('AND list.code=''" + code + "''')"
                Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
                If data.Rows.Count > 0 Then
                    'check duplicate
                    'code
                    If data.Rows(0)("is_old_design").ToString = "2" Then
                        GVBarcodeProb.ActiveFilterString = "[code]='" + code + "' "
                        Dim jum_duplicate As Integer = GVBarcodeProb.RowCount
                        GVBarcodeProb.ActiveFilterString = ""
                        If jum_duplicate > 0 Then
                            stopCustom("Data duplicate")
                            TxtScanProb.Text = ""
                            TxtScanProb.Focus()
                            Exit Sub
                        End If
                    End If

                    Dim newRow As DataRow = (TryCast(GCBarcodeProb.DataSource, DataTable)).NewRow()
                    newRow("id_sales_return_problem") = "0"
                    newRow("id_product") = data.Rows(0)("id_product").ToString
                    newRow("design_code") = data.Rows(0)("design_code").ToString
                    newRow("code") = data.Rows(0)("code").ToString
                    newRow("name") = data.Rows(0)("name").ToString
                    newRow("size") = data.Rows(0)("size").ToString
                    TryCast(GCBarcodeProb.DataSource, DataTable).Rows.Add(newRow)
                    FormSalesReturnDetProblem.TxtCode.Text = data.Rows(0)("design_code").ToString
                    FormSalesReturnDetProblem.TxtBarcode.Text = data.Rows(0)("code").ToString
                    FormSalesReturnDetProblem.TxtSize.Text = data.Rows(0)("size").ToString
                    FormSalesReturnDetProblem.TxtDesign.Text = data.Rows(0)("name").ToString
                    FormSalesReturnDetProblem.id_product = data.Rows(0)("id_product").ToString
                    FormSalesReturnDetProblem.id_type = "1"
                    FormSalesReturnDetProblem.ShowDialog()
                    GCBarcodeProb.RefreshDataSource()
                    GVBarcodeProb.RefreshData()
                    GVBarcodeProb.ActiveFilterString = ""
                    TxtScanProb.Text = ""
                    TxtScanProb.Focus()
                Else
                    stopCustom("Data not found")
                    GVBarcodeProb.ActiveFilterString = ""
                    TxtScanProb.Text = ""
                    TxtScanProb.Focus()
                End If
            ElseIf is_scan_prob = "2" Then 'del scan
                Cursor = Cursors.WaitCursor
                GVBarcodeProb.ActiveFilterString = "[code]='" + TxtScanProb.Text + "'"
                If GVBarcodeProb.RowCount <= 0 Then
                    stopCustom("Code not found.")
                    GVBarcodeProb.ActiveFilterString = ""
                    TxtScanProb.Text = ""
                    TxtScanProb.Focus()
                Else
                    Dim confirm As DialogResult = DevExpress.XtraEditors.XtraMessageBox.Show("Are you sure want to delete this data?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
                    If confirm = Windows.Forms.DialogResult.Yes Then
                        GVBarcodeProb.DeleteRow(GVBarcodeProb.FocusedRowHandle)
                        GVBarcodeProb.ActiveFilterString = ""
                    Else
                        GVBarcodeProb.ActiveFilterString = ""
                    End If
                    TxtScanProb.Text = ""
                    TxtScanProb.Focus()
                End If
                Cursor = Cursors.Default
            End If
            Cursor = Cursors.Default
        End If
    End Sub

    Private Sub BScanProb_Click_1(sender As Object, e As EventArgs) Handles BScanProb.Click
        If GVItemList.RowCount > 0 Then
            TxtScanProb.Text = ""
            is_scan_prob = "1"
            disableControl()
            LabelScanProb.Visible = True
            TxtScanProb.Visible = True
            TxtScanProb.Focus()
        Else
            errorCustom("Item list can't blank")
        End If
    End Sub

    Private Sub BStopProb_Click_1(sender As Object, e As EventArgs) Handles BStopProb.Click
        TxtScanProb.Text = ""
        is_scan_prob = "-1"
        enableControl()
    End Sub

    Private Sub BDeleteProb_Click_1(sender As Object, e As EventArgs) Handles BDeleteProb.Click
        is_scan_prob = "2"
        disableControl()
        TxtScanProb.Text = ""
        LabelScanProb.Visible = True
        TxtScanProb.Visible = True
        TxtScanProb.Focus()
    End Sub

    Private Sub GVBarcodeProb_CustomColumnDisplayText_1(sender As Object, e As DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs) Handles GVBarcodeProb.CustomColumnDisplayText
        If e.Column.FieldName = "no" Then
            e.DisplayText = (e.ListSourceRowIndex + 1).ToString()
        End If
    End Sub

    Private Sub BtnAddManual_Click(sender As Object, e As EventArgs) Handles BtnAddManual.Click
        FormSalesReturnDetProblem.ShowDialog()
    End Sub

    Private Sub EditRemarkToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EditRemarkToolStripMenuItem.Click
        If GVBarcodeProb.RowCount > 0 And GVBarcodeProb.FocusedRowHandle >= 0 Then
            FormSalesReturnDetProblem.id_type = "2"
            FormSalesReturnDetProblem.TxtSearch.Text = ""
            FormSalesReturnDetProblem.TxtCode.Text = GVBarcodeProb.GetFocusedRowCellValue("design_code").ToString
            FormSalesReturnDetProblem.TxtBarcode.Text = GVBarcodeProb.GetFocusedRowCellValue("code").ToString
            FormSalesReturnDetProblem.TxtSize.Text = GVBarcodeProb.GetFocusedRowCellValue("size").ToString
            FormSalesReturnDetProblem.TxtDesign.Text = GVBarcodeProb.GetFocusedRowCellValue("name").ToString
            FormSalesReturnDetProblem.TxtRemark.Text = GVBarcodeProb.GetFocusedRowCellValue("remark").ToString
            FormSalesReturnDetProblem.id_product = GVBarcodeProb.GetFocusedRowCellValue("id_product").ToString
            FormSalesReturnDetProblem.ShowDialog()
        End If
    End Sub

    Private Sub DeleteToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DeleteToolStripMenuItem.Click
        If GVBarcodeProb.RowCount > 0 And GVBarcodeProb.FocusedRowHandle >= 0 Then
            Dim confirm As DialogResult = DevExpress.XtraEditors.XtraMessageBox.Show("Are you sure want to delete this data?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
            If confirm = Windows.Forms.DialogResult.Yes Then
                GVBarcodeProb.DeleteSelectedRows()
            End If
        End If
    End Sub

    Private Sub BBPrintNonStock_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BBPrintNonStock.ItemClick
        Cursor = Cursors.WaitCursor
        ReportSalesReturnNonStock.dt = GCBarcodeProb.DataSource
        Dim Report As New ReportSalesReturnNonStock()

        ' '... 
        ' ' creating and saving the view's layout to a new memory stream 
        Dim str As System.IO.Stream
        str = New System.IO.MemoryStream()
        GVBarcodeProb.SaveLayoutToStream(str, DevExpress.Utils.OptionsLayoutBase.FullLayout)
        str.Seek(0, System.IO.SeekOrigin.Begin)
        Report.GVBarcodeProb.RestoreLayoutFromStream(str, DevExpress.Utils.OptionsLayoutBase.FullLayout)
        str.Seek(0, System.IO.SeekOrigin.Begin)

        'Grid Detail
        ReportStyleGridview(Report.GVBarcodeProb)

        'Parse val
        Report.LRecNumber.Text = TxtSalesReturnNumber.Text
        Report.LRecDate.Text = DEForm.Text
        Report.LabelReturnStore.Text = TxtStoreReturnNumber.Text
        Report.LabelFrom.Text = TxtCodeCompFrom.Text + " - " + TxtNameCompFrom.Text
        Report.LabelAddressFrom.Text = MEAdrressCompFrom.Text
        Report.LabelPrint.Text = name_user + " (" + execute_query("SELECT DATE_FORMAT(NOW(),'%d/%m/%Y %T')", 0, True, "", "", "", "") + ")"
        'Report.LabelNote.Text = MENote.Text


        'Show the report's preview. 
        Dim Tool As DevExpress.XtraReports.UI.ReportPrintTool = New DevExpress.XtraReports.UI.ReportPrintTool(Report)
        Tool.ShowPreviewDialog()
        Cursor = Cursors.Default
    End Sub

    Private Sub BtnCreateNonStock_Click(sender As Object, e As EventArgs) Handles BtnCreateNonStock.Click
        action = "ins"
        id_ret_type = "2"
        id_sales_return = "-1"
        TxtReturnType.Text = "Non Stock"
        Dim store_ret_number As String = TxtStoreReturnNumber.Text
        actionLoad()
        TxtStoreReturnNumber.Text = store_ret_number
        TxtSalesReturnNumber.Text = ""
        TxtSalesReturnNumber.Text = ""
        BtnPrint.Enabled = False
        BMark.Enabled = False
        BtnAttachment.Enabled = False
        DEForm.Text = view_date(0)
        DDBPrint.Enabled = False
        BtnSave.Enabled = True
        BtnXlsBOF.Visible = False
        BtnCreateNonStock.Visible = False
        PanelNavBarcode.Enabled = True
        PanelNavBarcodeProb.Enabled = True
    End Sub
End Class