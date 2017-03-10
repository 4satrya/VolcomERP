Imports Microsoft.Office.Interop

Public Class FormProductionPLToWHRecDet
    Public action As String
    Public id_pl_prod_order_rec As String = "0"
    Public id_pl_prod_order As String = "-1"
    Public id_order As String = "-1"
    Public id_comp_contact_to As String
    Public id_comp_contact_from As String
    Public id_pl_prod_order_det_list, id_pl_prod_order_rec_det_list, id_pl_prod_order_rec_det_unique_list As New List(Of String)
    Dim date_start As Date
    Public id_report_status As String
    Public id_pd_alloc As String = "-1"
    Public id_pre As String = "-1"
    Public bof_column As String = get_setup_field("bof_column")
    Public bof_xls_so As String = get_setup_field("bof_xls_rec")

    'var check qty
    Public cond_check As Boolean = True
    Public sample_check As String
    Public qty_pl As Decimal
    Public allow_sum As Decimal

    'var check duplicate unique
    Public cond_check_unique As Boolean = True
    Public sample_check_unique As String
    Public qty_pl_unique As Decimal
    Public allow_sum_unique As Decimal

    Public id_sample As String = "-1"
    Public data_code As DataTable
    Public dt As New DataTable

    Public id_comp_to As String = "-1"
    Public id_design As String = "-1"

    Private Sub FormProductionPLToWHRecDet_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        checkFormAccessSingle(Name)
        viewReportStatus() 'get report status
        viewPLCat()
        actionLoad()
    End Sub

    Private Sub FormProductionPLToWHRecDet_FormClosed(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Sub actionLoad()
        'initiation datatable
        Try
            'Jika blm ada
            dt.Columns.Add("id_product")
            dt.Columns.Add("id_pl_prod_order_det")
            dt.Columns.Add("product_code")
            dt.Columns.Add("product_counting_code")
            dt.Columns.Add("product_full_code")
            dt.Columns.Add("is_old_design")
        Catch ex As Exception
        End Try

        If action = "ins" Then
            TxtRetOutNumber.Text = ""
            DDBPrint.Enabled = False
            BtnPrint.Enabled = False
            BMark.Enabled = False
            BtnAttachment.Enabled = False
            DERet.Text = view_date(0)
            viewComp()

            'from info PL
            If id_pl_prod_order <> "-1" Then
                view_po()
            End If
        ElseIf action = "upd" Then
            'Enable/Disable
            BtnBrowsePO.Enabled = False
            GroupControlRet.Enabled = True
            GroupControlListBarcode.Enabled = True
            BtnInfoSrs.Enabled = True
            BMark.Enabled = True
            BtnAttachment.Enabled = True
            DDBPrint.Enabled = True


            'View data
            Try
                Dim query As String = "SELECT b.id_prod_order, b1.prod_order_number, ss.season,(loc.id_comp) AS `id_comp_storage`,g.id_design,(f.id_comp) AS id_comp_to, i.pl_category, b.id_pl_category, h.design_name, h.id_sample, DATE_FORMAT(a.pl_prod_order_rec_date,'%Y-%m-%d') AS pl_prod_order_rec_datex, "
                query += "a.id_report_status, a.id_pl_prod_order, a.id_pl_prod_order_rec, a.pl_prod_order_rec_date, a.pl_prod_order_rec_note, a.pl_prod_order_rec_number, "
                query += "b1.prod_order_number, b.pl_prod_order_number,(c.id_comp_contact) AS id_comp_contact_from, (d.comp_name) AS comp_name_contact_from, "
                query += "(d.comp_number) AS comp_code_contact_from, (d.address_primary) AS comp_address_contact_from, (e.id_comp_contact) AS id_comp_contact_to, (f.comp_name) AS "
                query += "comp_name_contact_to, (f.comp_number) AS comp_code_contact_to,(f.address_primary) AS comp_address_contact_to, h.design_cop, "
                query += "a.id_wh_drawer, CONCAT(drw.wh_drawer_code, '-', drw.wh_drawer) AS wh_drawer, "
                query += "rck.id_wh_rack, CONCAT(rck.wh_rack_code, '-', rck.wh_rack) AS wh_rack, "
                query += "loc.id_wh_locator, CONCAT(loc.wh_locator_code, '-', loc.wh_locator) AS wh_locator, "
                query += "alloc.id_pd_alloc, alloc.pd_alloc "
                query += "FROM tb_pl_prod_order_rec a "
                query += "INNER JOIN tb_pl_prod_order b ON a.id_pl_prod_order = b.id_pl_prod_order "
                query += "INNER JOIN tb_prod_order b1 ON b.id_prod_order = b1.id_prod_order "
                query += "INNER JOIN tb_m_comp_contact c ON a.id_comp_contact_from = c.id_comp_contact "
                query += "INNER JOIN tb_m_comp d ON d.id_comp = c.id_comp "
                query += "INNER JOIN tb_m_comp_contact e ON a.id_comp_contact_to = e.id_comp_contact "
                query += "INNER JOIN tb_m_comp f ON e.id_comp = f.id_comp "
                query += "INNER JOIN tb_prod_demand_design g ON g.id_prod_demand_design = b1.id_prod_demand_design "
                query += "INNER JOIN tb_m_design h ON g.id_design = h.id_design "
                query += "INNER JOIN tb_lookup_pl_category i ON b.id_pl_category = i.id_pl_category "
                query += "INNER JOIN tb_m_wh_drawer drw ON drw.id_wh_drawer = a.id_wh_drawer "
                query += "INNER JOIN tb_m_wh_rack rck ON rck.id_wh_rack = drw.id_wh_rack "
                query += "INNER JOIN tb_m_wh_locator loc ON loc.id_wh_locator = rck.id_wh_locator "
                query += "LEFT JOIN tb_lookup_pd_alloc alloc ON alloc.id_pd_alloc = b.id_pd_alloc "
                query += "INNER JOIN tb_season_delivery del ON del.id_delivery = b1.id_delivery "
                query += "INNER JOIN tb_season ss ON ss.id_season = del.id_season "
                query += "WHERE a.id_pl_prod_order_rec='" + id_pl_prod_order_rec + "' "
                Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")

                'allocation
                id_pd_alloc = data.Rows(0)("id_pd_alloc").ToString
                TxtAllocation.Text = data.Rows(0)("pd_alloc").ToString
                viewComp()

                TxtUnitCost.EditValue = Decimal.Parse(data.Rows(0)("design_cop").ToString)
                TxtOrderNumber.Text = data.Rows(0)("pl_prod_order_number").ToString
                id_comp_contact_from = data.Rows(0)("id_comp_contact_from").ToString
                TxtCodeCompFrom.Text = data.Rows(0)("comp_code_contact_from").ToString
                TxtNameCompFrom.Text = data.Rows(0)("comp_name_contact_from").ToString
                id_comp_contact_to = data.Rows(0)("id_comp_contact_to").ToString
                MEAdrressCompTo.Text = data.Rows(0)("comp_address_contact_to").ToString
                DERet.Text = view_date_from(data.Rows(0)("pl_prod_order_rec_datex").ToString, 0)
                TxtRetOutNumber.Text = data.Rows(0)("pl_prod_order_rec_number").ToString
                MENote.Text = data.Rows(0)("pl_prod_order_rec_note").ToString
                LEReportStatus.ItemIndex = LEReportStatus.Properties.GetDataSourceRowIndex("id_report_status", data.Rows(0)("id_report_status").ToString)
                TxtPLCategory.Text = data.Rows(0)("pl_category").ToString
                id_report_status = data.Rows(0)("id_report_status").ToString
                id_pl_prod_order = data.Rows(0)("id_pl_prod_order").ToString
                id_sample = data.Rows(0)("id_sample").ToString
                id_comp_to = data.Rows(0)("id_comp_to").ToString
                id_design = data.Rows(0)("id_design").ToString
                pre_viewImages("2", PEView, id_design, False)
                TEDesign.Text = data.Rows(0)("design_name").ToString
                PEView.Enabled = True

                'updated 28 Desember 2015
                SLEStorage.EditValue = data.Rows(0)("id_comp_storage").ToString
                SLELocator.EditValue = data.Rows(0)("id_wh_locator").ToString
                SLERack.EditValue = data.Rows(0)("id_wh_rack").ToString
                SLEDrawer.EditValue = data.Rows(0)("id_wh_drawer").ToString
                TxtSeason.Text = data.Rows(0)("season").ToString
                TxtPONumber.Text = data.Rows(0)("prod_order_number").ToString
                id_order = data.Rows(0)("id_prod_order").ToString
                mainVendor()
            Catch ex As Exception
                errorConnection()
            End Try

            view_barcode_list()
            viewDetail()
            check_but()
            allowDelete()
            allow_status()

            If id_pre = "1" Then
                prePrinting()
                Close()
            ElseIf id_pre = "2" Then
                printing()
                Close()
            End If

        End If
    End Sub

    'View Storage
    Sub viewComp()
        Dim query As String = "SELECT ('0') AS `id_comp`, '[Select Account]' AS `comp_name`, '-' AS `comp_cat_name`, '-' AS `address_primary` "
        query += "UNION ALL "
        query += "(SELECT a.id_comp, CONCAT(a.comp_number, '-', a.comp_name) AS comp_name, b.comp_cat_name, a.address_primary "
        query += "FROM tb_m_comp a "
        query += "INNER JOIN tb_m_comp_cat b ON a.id_comp_cat = b.id_comp_cat "
        query += "INNER JOIN tb_m_wh_locator c ON a.id_comp = c.id_comp "
        query += "INNER JOIN tb_m_wh_rack d ON c.id_wh_locator = d.id_wh_locator "
        query += "INNER JOIN tb_m_wh_drawer e ON e.id_wh_rack = d.id_wh_rack "
        query += "JOIN tb_opt opt "
        query += "WHERE a.id_departement = '" + id_departement_user + "' "
        query += "AND a.id_comp_cat = opt.id_comp_cat_wh "
        query += "GROUP BY a.id_comp "
        query += "ORDER BY a.id_wh_type ASC)"
        viewSearchLookupQuery(SLEStorage, query, "id_comp", "comp_name", "id_comp")
    End Sub

    Sub allow_status()
        If check_edit_report_status(id_report_status, "37", id_pl_prod_order_rec) Then
            BtnBrowseContactFrom.Enabled = True
            BtnBrowseContactTo.Enabled = True
            MENote.Properties.ReadOnly = False
            BtnSave.Enabled = False
            BScan.Enabled = True
            BDelete.Enabled = True
            SLEStorage.Enabled = True
            SLELocator.Enabled = True
            SLERack.Enabled = True
            SLEDrawer.Enabled = True
            GVRetDetail.OptionsBehavior.ReadOnly = False
        Else
            BtnBrowseContactFrom.Enabled = False
            BtnBrowseContactTo.Enabled = False
            MENote.Properties.ReadOnly = True
            DERet.Properties.ReadOnly = True
            BtnSave.Enabled = False
            BScan.Enabled = False
            BDelete.Enabled = False
            SLEStorage.Enabled = False
            SLELocator.Enabled = False
            SLERack.Enabled = False
            SLEDrawer.Enabled = False
            GVRetDetail.OptionsBehavior.ReadOnly = True
        End If
        PanelNavBarcode.Enabled = False

        'attachment
        If check_attach_report_status(id_report_status, "37", id_pl_prod_order_rec) Then
            BtnAttachment.Enabled = True
        Else
            BtnAttachment.Enabled = False
        End If


        'preprint
        If check_pre_print_report_status(id_report_status) Then
            BtnPrePrinting.Enabled = True
        Else
            BtnPrePrinting.Enabled = False
        End If

        'print
        If check_print_report_status(id_report_status) Then
            BtnPrint.Enabled = True
        Else
            BtnPrint.Enabled = False
        End If

        'bof column
        If bof_column = "1" And id_report_status <> "5" Then
            BtnXlsBOF.Visible = True
        Else
            BtnXlsBOF.Visible = False
        End If

        TxtRetOutNumber.Focus()
    End Sub
    'sub check_but
    Sub check_but()
        'Constraint Status
        If GVRetDetail.RowCount > 0 Then
            'BtnEdit.Visible = True
            'BtnDel.Visible = True
        Else
            'BtnEdit.Visible = False
            'BtnDel.Visible = False
        End If
    End Sub

    Sub mainVendor()
        'main vendor
        Dim data_vend As DataTable = getMainVendor(id_order)
        Try
            TxtVendorCode.Text = data_vend.Rows(0)("comp_number").ToString
            TxtVendor.Text = data_vend.Rows(0)("comp_name").ToString
        Catch ex As Exception
            TxtVendorCode.Text = ""
            TxtVendor.Text = ""
        End Try

    End Sub

    'View po
    Sub view_list_po(ByVal id_pl_prod_order As String)
        Dim query = "CALL view_prod_order_det('" & id_pl_prod_order & "', '0')"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        For i As Integer = 0 To (data.Rows.Count - 1)
            id_pl_prod_order_det_list.Add(data.Rows(i)("id_pl_prod_order_det").ToString)
        Next
        GCRetDetail.DataSource = data
    End Sub

    Sub view_po()
        Dim query = "SELECT  "
        query += "a1.id_prod_order, a1.prod_order_number, a.id_pl_prod_order,d.id_sample, a.pl_prod_order_number, d.design_display_name,d.design_name , d.design_code, g.pl_category, "
        query += "DATE_FORMAT(a.pl_prod_order_date,'%d %M %Y') AS pl_prod_order_date,a.id_report_status,c.report_status, "
        query += "b.id_design,b.id_delivery, e.delivery, f.season, e.id_season, "
        query += "a.id_comp_contact_from, a.id_comp_contact_to, (i.id_comp) AS id_comp_to, (i.comp_name) AS comp_name_to, (i.comp_number) AS comp_number_to, (k.comp_name) AS comp_name_from, (k.comp_number) AS comp_number_from, d.design_cop, "
        query += "alloc.id_pd_alloc, alloc.pd_alloc "
        query += "FROM tb_pl_prod_order a "
        query += "INNER JOIN tb_m_comp_contact h ON h.id_comp_contact = a.id_comp_contact_to "
        query += "INNER JOIN tb_m_comp i ON h.id_comp = i.id_comp "
        query += "INNER JOIN tb_m_comp_contact j ON j.id_comp_contact = a.id_comp_contact_from "
        query += "INNER JOIN tb_m_comp k ON k.id_comp = j.id_comp "
        query += "INNER JOIN tb_prod_order a1 ON a.id_prod_order = a1.id_prod_order "
        query += "INNER JOIN tb_prod_demand_design b ON a1.id_prod_demand_design = b.id_prod_demand_design "
        query += "INNER JOIN tb_lookup_report_status c ON a.id_report_status = c.id_report_status "
        query += "INNER JOIN tb_m_design d ON b.id_design = d.id_design "
        query += "INNER JOIN tb_season_delivery e ON b.id_delivery=e.id_delivery "
        query += "INNER JOIN tb_season f ON f.id_season=e.id_season "
        query += "INNER JOIN tb_lookup_pl_category g ON g.id_pl_category = a.id_pl_category "
        query += "LEFT JOIN tb_pl_prod_order_rec z ON a.id_pl_prod_order = z.id_pl_prod_order AND z.id_report_status!='5' "
        query += "LEFT JOIN tb_lookup_pd_alloc alloc ON alloc.id_pd_alloc = a.id_pd_alloc "
        query += "WHERE a.id_pl_prod_order = '" + id_pl_prod_order + "' "
        query += "ORDER BY a.id_pl_prod_order ASC "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")

        TxtUnitCost.EditValue = data.Rows(0)("design_cop")
        TxtOrderNumber.Text = data.Rows(0)("pl_prod_order_number").ToString
        TxtPLCategory.Text = data.Rows(0)("pl_category").ToString
        id_comp_contact_from = data.Rows(0)("id_comp_contact_from").ToString
        TxtCodeCompFrom.Text = data.Rows(0)("comp_number_from").ToString
        TxtNameCompFrom.Text = data.Rows(0)("comp_name_from").ToString
        id_comp_contact_to = data.Rows(0)("id_comp_contact_to").ToString
        id_comp_to = data.Rows(0)("id_comp_to").ToString
        id_sample = data.Rows(0)("id_sample").ToString
        id_design = data.Rows(0)("id_design").ToString
        TEDesign.Text = data.Rows(0)("design_display_name").ToString
        TxtAllocation.Text = data.Rows(0)("pd_alloc").ToString
        TxtSeason.Text = data.Rows(0)("season").ToString
        TxtPONumber.Text = data.Rows(0)("prod_order_number").ToString
        id_order = data.Rows(0)("id_prod_order").ToString
        mainVendor()
        pre_viewImages("2", PEView, data.Rows(0)("id_design").ToString, False)

        'default locator
        '  Dim id_loc As String = getDefaultLocator

        PEView.Enabled = True
        GroupControlRet.Enabled = True
        GroupControlListBarcode.Enabled = True
        viewDetail()
        view_barcode_list()
        id_pl_prod_order_det_list.Clear()
        check_but()
        BtnInfoSrs.Enabled = True
        BtnBrowsePO.Enabled = False
    End Sub

    'View Data
    Sub viewReportStatus()
        Dim query As String = "SELECT * FROM tb_lookup_report_status a ORDER BY a.id_report_status "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        viewLookupQuery(LEReportStatus, query, 0, "report_status", "id_report_status")
    End Sub

    Sub view_barcode_list()
        If action = "ins" Then
            Dim query As String = "SELECT ('0') AS no, ('') AS code, ('0') AS id_pl_prod_order_det, ('1') AS is_fix, ('') AS counting_code, ('0') AS id_pl_prod_order_rec_det_unique "
            Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
            GCBarcode.DataSource = data
            deleteRowsBc()
        ElseIf action = "upd" Then
            Dim query As String = "SELECT ('') AS no, CONCAT(c.product_full_code, a.pl_prod_order_rec_det_counting) AS code, "
            query += "b.id_pl_prod_order_rec_det, (a.pl_prod_order_rec_det_counting) AS counting_code, a.id_pl_prod_order_rec_det_unique, ('2') AS is_fix, b.id_pl_prod_order_det "
            query += "FROM tb_pl_prod_order_rec_det_counting a "
            query += "INNER JOIN tb_pl_prod_order_rec_det b ON a.id_pl_prod_order_rec_det = b.id_pl_prod_order_rec_det "
            query += "INNER JOIN tb_m_product c ON a.id_product = c.id_product "
            query += "WHERE b.id_pl_prod_order_rec = '" + id_pl_prod_order_rec + "' AND a.id_counting_type='1' "
            Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
            For i As Integer = 0 To (data.Rows.Count - 1)
                id_pl_prod_order_rec_det_unique_list.Add(data.Rows(i)("id_pl_prod_order_rec_det_unique").ToString)
            Next
            GCBarcode.DataSource = data
        End If
    End Sub

    Sub viewDetail()
        If action = "ins" Then
            Dim query As String = "CALL view_pl_prod('" + id_pl_prod_order + "', '0', '" + id_pd_alloc + "') "
            Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
            For i As Integer = 0 To (data.Rows.Count - 1)
                Dim id_pl_prod_order_det As String = data.Rows(i)("id_pl_prod_order_det").ToString
                Dim queryx As String = "SELECT ('') AS no, a.id_product, c.product_full_code,CONCAT(c.product_full_code, a.pl_prod_order_det_counting) AS code, "
                queryx += "b.id_pl_prod_order_det, (a.pl_prod_order_det_counting) AS counting_code, a.id_pl_prod_order_det_unique, ('2') AS is_fix, b.id_pl_prod_order_det, dsg.is_old_design "
                queryx += "FROM tb_pl_prod_order_det_counting a "
                queryx += "INNER JOIN tb_pl_prod_order_det b ON a.id_pl_prod_order_det = b.id_pl_prod_order_det "
                queryx += "INNER JOIN tb_m_product c ON a.id_product = c.id_product "
                queryx += "INNER JOIN tb_m_design dsg ON dsg.id_design = c.id_design "
                queryx += "WHERE a.id_pl_prod_order_det = '" + id_pl_prod_order_det + "' "
                Dim datax As DataTable = execute_query(queryx, -1, True, "", "", "", "")
                If dt.Rows.Count = 0 Then
                    dt = datax
                Else
                    dt.Merge(datax)
                End If
            Next
            GCRetDetail.DataSource = data
        ElseIf action = "upd" Then
            dt.Clear()
            Dim query As String = "CALL view_pl_prod_rec('" + id_pl_prod_order_rec + "', '0')"
            Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
            For i As Integer = 0 To (data.Rows.Count - 1)
                id_pl_prod_order_det_list.Add(data.Rows(i)("id_pl_prod_order_det").ToString)
                id_pl_prod_order_rec_det_list.Add(data.Rows(i)("id_pl_prod_order_rec_det").ToString)
                Dim id_pl_prod_order_det As String = data.Rows(i)("id_pl_prod_order_det").ToString
                Dim queryx As String = "SELECT ('') AS no, a.id_product, c.product_full_code,CONCAT(c.product_full_code, a.pl_prod_order_det_counting) AS code, "
                queryx += "b.id_pl_prod_order_det, (a.pl_prod_order_det_counting) AS counting_code, a.id_pl_prod_order_det_unique, ('2') AS is_fix, b.id_pl_prod_order_det, dsg.is_old_design "
                queryx += "FROM tb_pl_prod_order_det_counting a "
                queryx += "INNER JOIN tb_pl_prod_order_det b ON a.id_pl_prod_order_det = b.id_pl_prod_order_det "
                queryx += "INNER JOIN tb_m_product c ON a.id_product = c.id_product "
                queryx += "INNER JOIN tb_m_design dsg ON dsg.id_design = c.id_design "
                queryx += "WHERE a.id_pl_prod_order_det = '" + id_pl_prod_order_det + "' "
                Dim datax As DataTable = execute_query(queryx, -1, True, "", "", "", "")
                If dt.Rows.Count = 0 Then
                    dt = datax
                Else
                    dt.Merge(datax)
                End If
            Next
            GCRetDetail.DataSource = data
        End If
        check_but()
    End Sub

    'View PL Category
    Sub viewPLCat()
        'Dim query As String = "SELECT * FROM tb_lookup_pl_category a ORDER BY a.id_pl_category  "
        'Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        'viewLookupQuery(LEPLCategory, query, 0, "pl_category", "id_pl_category")
    End Sub

    'Button
    Private Sub BtnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSave.Click
        Cursor = Cursors.WaitCursor
        makeSafeGV(GVRetDetail)
        makeSafeGV(GVBarcode)
        ValidateChildren()

        'Cek isi qty
        Dim cond_qty As Boolean = True
        Dim qty1, qty2 As Decimal
        For i As Integer = 0 To ((GVRetDetail.RowCount - 1) - GetGroupRowCount(GVRetDetail))
            qty1 = GVRetDetail.GetRowCellValue(i, "pl_prod_order_rec_det_qty")
            qty2 = GVRetDetail.GetRowCellValue(i, "pl_prod_order_det_qty")
            If qty1 <> qty2 Then
                cond_qty = False
            End If
        Next

        If Not formIsValidInPanel(EPRet, PanelControlTopMain) Or Not formIsValidInPanel(EPRet, PanelControlTopRight) Or Not formIsValidInPanel(EPRet, PanelControlTopRight2) Then
            errorInput()
        ElseIf GVRetDetail.RowCount = 0 Then
            errorCustom("Qty can't blank or zero value !")
        ElseIf Not cond_qty Then
            errorCustom("Qty receive must have equal to qty pl !")
        ElseIf Not cond_check Then
            errorCustom("- Product : '" + sample_check + "' cannot exceed " + allow_sum.ToString("F2") + ", please check in Info Qty !" + System.Environment.NewLine + "- Use 'receiving QC module' for new item product. ")
            infoQty()
        ElseIf SLEStorage.EditValue.ToString = "0" Then
            stopCustom("Please choose storage account.")
        Else
            Dim query As String
            Dim pl_prod_order_rec_number As String = ""
            Dim pl_prod_order_rec_note As String = addSlashes(MENote.Text)
            Dim id_report_status As String = LEReportStatus.EditValue
            Dim id_pl_prod_order_det, pl_prod_order_rec_det_qty, pl_prod_order_rec_det_note As String
            Dim id_pl_prod_order_rec_det As String
            Dim bom_unit_price As String = decimalSQL(TxtUnitCost.EditValue.ToString)
            Dim id_wh_drawer As String = SLEDrawer.EditValue.ToString
            id_comp_contact_to = get_company_x(SLEStorage.EditValue.ToString, "6")

            If action = "ins" Then
                Dim confirm As DialogResult = DevExpress.XtraEditors.XtraMessageBox.Show("Are you sure to save changes this data?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
                If confirm = Windows.Forms.DialogResult.Yes Then
                    Cursor = Cursors.WaitCursor
                    Try
                        'Main tbale
                        pl_prod_order_rec_number = header_number_prod("8")
                        query = "INSERT INTO tb_pl_prod_order_rec(id_pl_prod_order, pl_prod_order_rec_number, id_comp_contact_to, id_comp_contact_from, pl_prod_order_rec_date, pl_prod_order_rec_note, id_report_status, id_wh_drawer, last_update, last_update_by) "
                        query += "VALUES('" + id_pl_prod_order + "', '" + pl_prod_order_rec_number + "', '" + id_comp_contact_to + "', '" + id_comp_contact_from + "', NOW(), '" + pl_prod_order_rec_note + "', '" + id_report_status + "', '" + id_wh_drawer + "', NOW(), " + id_user + "); SELECT LAST_INSERT_ID(); "
                        id_pl_prod_order_rec = execute_query(query, 0, True, "", "", "", "")

                        increase_inc_prod("8")

                        'insert who prepared
                        insert_who_prepared("37", id_pl_prod_order_rec, id_user)

                        'Detail return
                        Dim jum_ins_j As Integer = 0
                        Dim query_detail As String = ""
                        If GVRetDetail.RowCount > 0 Then
                            query_detail = "INSERT tb_pl_prod_order_rec_det(id_pl_prod_order_rec, id_pl_prod_order_det, pl_prod_order_rec_det_qty, pl_prod_order_rec_det_note) VALUES "
                        End If
                        For j As Integer = 0 To ((GVRetDetail.RowCount - 1) - GetGroupRowCount(GVRetDetail))
                            Try
                                id_pl_prod_order_det = GVRetDetail.GetRowCellValue(j, "id_pl_prod_order_det").ToString
                                pl_prod_order_rec_det_qty = decimalSQL(GVRetDetail.GetRowCellValue(j, "pl_prod_order_rec_det_qty").ToString)
                                pl_prod_order_rec_det_note = GVRetDetail.GetRowCellValue(j, "pl_prod_order_rec_det_note").ToString

                                If jum_ins_j > 0 Then
                                    query_detail += ", "
                                End If
                                query_detail += "('" + id_pl_prod_order_rec + "', '" + id_pl_prod_order_det + "', '" + pl_prod_order_rec_det_qty + "', '" + pl_prod_order_rec_det_note + "') "
                                jum_ins_j = jum_ins_j + 1
                            Catch ex As Exception
                            End Try
                        Next
                        If jum_ins_j > 0 Then
                            execute_non_query(query_detail, True, "", "", "", "")
                        End If

                        'get all detail
                        Dim query_get_detail As String = "SELECT a.id_pl_prod_order_rec_det, a.id_pl_prod_order_det, c.id_product FROM tb_pl_prod_order_rec_det a "
                        query_get_detail += "INNER JOIN tb_pl_prod_order_det b ON a.id_pl_prod_order_det = b.id_pl_prod_order_det "
                        query_get_detail += "INNER JOIN tb_prod_order_det b1 ON b.id_prod_order_det = b1.id_prod_order_det "
                        query_get_detail += "INNER JOIN tb_prod_demand_product c ON b1.id_prod_demand_product = c.id_prod_demand_product "
                        query_get_detail += "WHERE a.id_pl_prod_order_rec = '" + id_pl_prod_order_rec + "' "
                        Dim data_get_detail As DataTable = execute_query(query_get_detail, True, -1, "", "", "", "")

                        'counting
                        Dim jum_ins As Integer = 0
                        Dim query_counting As String = ""
                        If GVBarcode.RowCount > 0 Then
                            query_counting = "INSERT INTO tb_pl_prod_order_rec_det_counting(id_pl_prod_order_rec_det, pl_prod_order_rec_det_counting, id_product, bom_unit_price) VALUES "
                        End If
                        For k As Integer = 0 To (GVBarcode.RowCount - 1)
                            Dim id_pl_prod_order_det_counting As String = GVBarcode.GetRowCellValue(k, "id_pl_prod_order_det").ToString
                            Dim pl_prod_order_rec_det_counting As String = GVBarcode.GetRowCellValue(k, "counting_code").ToString
                            For kx As Integer = 0 To (data_get_detail.Rows.Count - 1)
                                If id_pl_prod_order_det_counting = data_get_detail.Rows(kx)("id_pl_prod_order_det").ToString Then
                                    If jum_ins > 0 Then
                                        query_counting += ", "
                                    End If
                                    query_counting += "('" + data_get_detail.Rows(kx)("id_pl_prod_order_rec_det").ToString + "', '" + pl_prod_order_rec_det_counting + "', '" + data_get_detail.Rows(kx)("id_product").ToString + "', '" + bom_unit_price + "') "
                                    jum_ins = jum_ins + 1
                                    Exit For
                                End If
                            Next
                        Next
                        execute_non_query(query_counting, True, "", "", "", "")

                        'submit who prepared
                        submit_who_prepared("37", id_pl_prod_order_rec, id_user)

                        exportToBOF(False)
                        FormProductionPLToWHRec.viewPL()
                        FormProductionPLToWHRec.GVPL.FocusedRowHandle = find_row(FormProductionPLToWHRec.GVPL, "id_pl_prod_order_rec", id_pl_prod_order_rec)
                        FormProductionPLToWHRec.view_sample_purc()
                        action = "upd"
                        actionLoad()
                        infoCustom("Document #" + pl_prod_order_rec_number + " was created successfully")
                    Catch ex As Exception
                        errorConnection()
                    End Try
                    Cursor = Cursors.Default
                End If
            ElseIf action = "upd" Then
                Dim confirm As DialogResult = DevExpress.XtraEditors.XtraMessageBox.Show("Are you sure to save changes this data?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
                If confirm = Windows.Forms.DialogResult.Yes Then
                    Cursor = Cursors.WaitCursor
                    Try
                        'edit main table
                        pl_prod_order_rec_number = addSlashes(TxtRetOutNumber.Text)
                        query = "UPDATE tb_pl_prod_order_rec SET id_pl_prod_order = '" + id_pl_prod_order + "', pl_prod_order_rec_number = '" + pl_prod_order_rec_number + "', id_comp_contact_to = '" + id_comp_contact_to + "', id_comp_contact_from = '" + id_comp_contact_from + "', id_report_status = '" + id_report_status + "', pl_prod_order_rec_note = '" + pl_prod_order_rec_note + "', id_wh_drawer='" + id_wh_drawer + "',last_update = NOW(), last_update_by = " + id_user + " WHERE id_pl_prod_order_rec = '" + id_pl_prod_order_rec + "' "
                        execute_non_query(query, True, "", "", "", "")

                        'edit detail table
                        Dim jum_ins_j As Integer = 0
                        Dim query_detail As String = ""
                        If GVRetDetail.RowCount > 0 Then
                            query_detail = "INSERT tb_pl_prod_order_rec_det(id_pl_prod_order_rec, id_pl_prod_order_det, pl_prod_order_rec_det_qty, pl_prod_order_rec_det_note) VALUES "
                        End If
                        For j As Integer = 0 To ((GVRetDetail.RowCount - 1) - GetGroupRowCount(GVRetDetail))
                            Try
                                id_pl_prod_order_rec_det = GVRetDetail.GetRowCellValue(j, "id_pl_prod_order_rec_det").ToString
                                id_pl_prod_order_det = GVRetDetail.GetRowCellValue(j, "id_pl_prod_order_det").ToString
                                pl_prod_order_rec_det_qty = decimalSQL(GVRetDetail.GetRowCellValue(j, "pl_prod_order_rec_det_qty").ToString)
                                pl_prod_order_rec_det_note = GVRetDetail.GetRowCellValue(j, "pl_prod_order_rec_det_note").ToString
                                If id_pl_prod_order_rec_det = "0" Then
                                    If jum_ins_j > 0 Then
                                        query_detail += ", "
                                    End If
                                    query_detail += "('" + id_pl_prod_order_rec + "', '" + id_pl_prod_order_det + "', '" + pl_prod_order_rec_det_qty + "', '" + pl_prod_order_rec_det_note + "') "
                                    jum_ins_j = jum_ins_j + 1
                                Else
                                    query = "UPDATE tb_pl_prod_order_rec_det SET id_pl_prod_order_det = '" + id_pl_prod_order_det + "', pl_prod_order_rec_det_qty = '" + pl_prod_order_rec_det_qty + "', pl_prod_order_rec_det_note = '" + pl_prod_order_rec_det_note + "' WHERE id_pl_prod_order_rec_det = '" + id_pl_prod_order_rec_det + "'"
                                    execute_non_query(query, True, "", "", "", "")
                                    id_pl_prod_order_rec_det_list.Remove(id_pl_prod_order_rec_det)
                                End If
                            Catch ex As Exception
                                ex.ToString()
                            End Try
                        Next
                        If jum_ins_j > 0 Then
                            execute_non_query(query_detail, True, "", "", "", "")
                        End If

                        'delete sisa
                        For k As Integer = 0 To (id_pl_prod_order_rec_det_list.Count - 1)
                            Try
                                query = "DELETE FROM tb_pl_prod_order_rec_det WHERE id_pl_prod_order_rec_det = '" + id_pl_prod_order_rec_det_list(k) + "' "
                                execute_non_query(query, True, "", "", "", "")
                            Catch ex As Exception
                                ex.ToString()
                            End Try
                        Next

                        'get all detail
                        Dim query_get_detail As String = "SELECT a.id_pl_prod_order_rec_det, a.id_pl_prod_order_det, c.id_product FROM tb_pl_prod_order_rec_det a "
                        query_get_detail += "INNER JOIN tb_pl_prod_order_det b ON a.id_pl_prod_order_det = b.id_pl_prod_order_det "
                        query_get_detail += "INNER JOIN tb_prod_order_det b1 ON b.id_prod_order_det = b1.id_prod_order_det "
                        query_get_detail += "INNER JOIN tb_prod_demand_product c ON b1.id_prod_demand_product = c.id_prod_demand_product "
                        query_get_detail += "WHERE a.id_pl_prod_order_rec = '" + id_pl_prod_order_rec + "' "
                        Dim data_get_detail As DataTable = execute_query(query_get_detail, True, -1, "", "", "", "")

                        'counting
                        Dim query_counting As String = ""
                        If GVBarcode.RowCount > 0 Then
                            query_counting = "INSERT INTO tb_pl_prod_order_rec_det_counting(id_pl_prod_order_rec_det, pl_prod_order_rec_det_counting, id_product, bom_unit_price) VALUES "
                        End If
                        Dim jum_ins As Integer = 0
                        For k As Integer = 0 To (GVBarcode.RowCount - 1)
                            Dim id_pl_prod_order_det_counting As String = GVBarcode.GetRowCellValue(k, "id_pl_prod_order_det").ToString
                            Dim pl_prod_order_rec_det_counting As String = GVBarcode.GetRowCellValue(k, "counting_code").ToString
                            Dim id_pl_prod_order_rec_det_unique As String = GVBarcode.GetRowCellValue(k, "id_pl_prod_order_rec_det_unique").ToString
                            If id_pl_prod_order_rec_det_unique = "0" Then
                                For kx As Integer = 0 To (data_get_detail.Rows.Count - 1)
                                    If id_pl_prod_order_det_counting = data_get_detail.Rows(kx)("id_pl_prod_order_det").ToString Then
                                        If jum_ins > 0 Then
                                            query_counting += ", "
                                        End If
                                        query_counting += "('" + data_get_detail.Rows(kx)("id_pl_prod_order_rec_det").ToString + "', '" + pl_prod_order_rec_det_counting + "', '" + data_get_detail.Rows(kx)("id_product").ToString + "', '" + bom_unit_price + "') "
                                        jum_ins = jum_ins + 1
                                        Exit For
                                    End If
                                Next
                            Else
                                id_pl_prod_order_rec_det_unique_list.Remove(id_pl_prod_order_rec_det_unique)
                            End If
                        Next
                        If jum_ins > 0 Then
                            execute_non_query(query_counting, True, "", "", "", "")
                        End If

                        'delete sisa unique
                        For k As Integer = 0 To (id_pl_prod_order_rec_det_unique_list.Count - 1)
                            Try
                                query = "DELETE FROM tb_pl_prod_order_rec_det_counting WHERE id_pl_prod_order_rec_det_unique = '" + id_pl_prod_order_rec_det_unique_list(k) + "' "
                                execute_non_query(query, True, "", "", "", "")
                            Catch ex As Exception
                                ex.ToString()
                            End Try
                        Next

                        'View
                        exportToBOF(False)
                        FormProductionPLToWHRec.viewPL()
                        FormProductionPLToWHRec.GVPL.FocusedRowHandle = find_row(FormProductionPLToWHRec.GVPL, "id_pl_prod_order_rec", id_pl_prod_order_rec)
                        FormProductionPLToWHRec.view_sample_purc()
                        action = "upd"
                        actionLoad()
                        infoCustom("Document #" + pl_prod_order_rec_number + " was edited successfully")
                    Catch ex As Exception
                        errorConnection()
                    End Try
                    Cursor = Cursors.Default
                End If
            End If
        End If
        Cursor = Cursors.Default
    End Sub
    Private Sub BtnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCancel.Click
        Close()
    End Sub
    Private Sub BtnBrowsePO_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnBrowsePO.Click
        FormPopUpPLProd.id_pop_up = "1"
        FormPopUpPLProd.ShowDialog()
    End Sub
    Private Sub BtnBrowseContactFrom_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnBrowseContactFrom.Click
        FormPopUpContact.id_pop_up = "35"
        FormPopUpContact.id_departement = id_departement_user
        FormPopUpContact.ShowDialog()
    End Sub
    Private Sub BtnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        FormPopUpPLProdDet.id_pop_up = "1"
        FormPopUpPLProdDet.action = "ins"
        FormPopUpPLProdDet.id_pl_prod_order = id_pl_prod_order
        FormPopUpPLProdDet.id_pl = id_pl_prod_order_rec
        FormPopUpPLProdDet.ShowDialog()
    End Sub
    Private Sub BtnDel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If (MessageBox.Show("Are you sure to delete this row?", "Delete Confirmation", MessageBoxButtons.YesNo) <> DialogResult.Yes) Then Return
        Dim id_pl_prod_order_det As String = GVRetDetail.GetFocusedRowCellDisplayText("id_pl_prod_order_det").ToString
        id_pl_prod_order_det_list.Remove(id_pl_prod_order_det) 'delete list
        deleteRows() 'delete list
        deleteDetailBc(id_pl_prod_order_det) 'delete barcode

        'delete datatable
        FormProcessing.id_process = "2"
        FormProcessing.idx = id_pl_prod_order_det
        FormProcessing.ShowDialog()
    End Sub

    Sub deleteDetailBc(ByVal id_pl_prod_order_det As String)
        'delete detail
        Dim i As Integer = GVBarcode.RowCount - 1
        While (i >= 0)
            Dim id_pl_prod_order_detx As String = ""
            Try
                id_pl_prod_order_detx = GVBarcode.GetRowCellValue(i, "id_pl_prod_order_det").ToString()
            Catch ex As Exception

            End Try
            If id_pl_prod_order_det = id_pl_prod_order_detx Then
                GVBarcode.DeleteRow(i)
            End If
            i = i - 1
        End While
    End Sub
    Private Sub BtnEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        FormPopUpPLProdDet.id_pop_up = "1"
        FormPopUpPLProdDet.action = "upd"
        FormPopUpPLProdDet.id_pl_prod_order = id_pl_prod_order
        FormPopUpPLProdDet.id_pl_prod_order_det_edit = GVRetDetail.GetFocusedRowCellValue("id_pl_prod_order_det").ToString
        FormPopUpPLProdDet.id_pl = id_pl_prod_order_rec
        FormPopUpPLProdDet.ShowDialog()
    End Sub

    'Validating
    Private Sub TxtOrderNumber_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TxtOrderNumber.Validating
        EP_TE_cant_blank(EPRet, TxtOrderNumber)
        EPRet.SetIconPadding(TxtOrderNumber, 56)
    End Sub

    Private Sub TxtNameCompFrom_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TxtNameCompFrom.Validating
        EP_TE_cant_blank(EPRet, TxtNameCompFrom)
        EPRet.SetIconPadding(TxtNameCompFrom, 30)
    End Sub

    Private Sub SLELocator_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles SLELocator.Validating
        EP_SLE_cant_blank(EPRet, SLELocator)
    End Sub

    Private Sub SLERack_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles SLERack.Validating
        EP_SLE_cant_blank(EPRet, SLERack)
    End Sub

    Private Sub SLEDrawer_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles SLEDrawer.Validating
        EP_SLE_cant_blank(EPRet, SLEDrawer)
    End Sub

    'Row Manipulation
    Sub focusColumnCode()
        GVRetDetail.FocusedColumn = GVRetDetail.VisibleColumns(0)
        GVRetDetail.ShowEditor()
    End Sub
    Sub newRows()
        GVRetDetail.AddNewRow()
    End Sub
    Sub deleteRows()
        GVRetDetail.DeleteRow(GVRetDetail.FocusedRowHandle)
    End Sub

    Private Sub BMark_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BMark.Click
        FormReportMark.id_report = id_pl_prod_order_rec
        FormReportMark.report_mark_type = "37"
        FormReportMark.is_view = "1"
        FormReportMark.is_view_finalize = "1"
        FormReportMark.form_origin = Name
        FormReportMark.ShowDialog()
    End Sub

    Private Sub BtnBrowseContactTo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnBrowseContactTo.Click
        FormPopUpContact.id_pop_up = "36"
        FormPopUpContact.ShowDialog()
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

    Private Sub BScan_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BScan.Click
        MENote.Enabled = False
        BtnBrowsePO.Enabled = False
        BtnBrowseContactFrom.Enabled = False
        BtnBrowseContactTo.Enabled = False
        BtnSave.Enabled = False
        BScan.Enabled = False
        BStop.Enabled = True
        BDelete.Enabled = False
        BtnCancel.Enabled = False
        GVRetDetail.OptionsBehavior.Editable = False
        ControlBox = False
        BtnInfoSrs.Enabled = False
        SLEStorage.Enabled = False
        SLELocator.Enabled = False
        SLERack.Enabled = False
        SLEDrawer.Enabled = False
        If action = "upd" Then
            DDBPrint.Enabled = False
            BMark.Enabled = False
            BtnAttachment.Enabled = False
        End If
        newRowsBc()
        GCBarcode.Focus()
        'allowDelete()
    End Sub

    Private Sub BStop_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BStop.Click
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

        MENote.Enabled = True
        BtnBrowseContactFrom.Enabled = True
        BtnBrowseContactTo.Enabled = True
        BtnSave.Enabled = True
        BScan.Enabled = True
        BStop.Enabled = False
        BtnCancel.Enabled = True
        allowDelete()
        GVRetDetail.OptionsBehavior.Editable = True
        ControlBox = True
        BtnInfoSrs.Enabled = True
        SLEStorage.Enabled = True
        SLELocator.Enabled = True
        SLERack.Enabled = True
        SLEDrawer.Enabled = True
        If action = "upd" Then
            DDBPrint.Enabled = True
            BMark.Enabled = True
            BtnAttachment.Enabled = True
        End If
        GCRetDetail.RefreshDataSource()
        GVRetDetail.RefreshData()
    End Sub

    Private Sub BDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BDelete.Click
        Dim confirm As DialogResult = DevExpress.XtraEditors.XtraMessageBox.Show("Are you sure want to delete this data?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
        If confirm = Windows.Forms.DialogResult.Yes Then
            Dim id_pl_prod_order_det As String = GVBarcode.GetFocusedRowCellValue("id_pl_prod_order_det").ToString
            deleteRowsBc()
            If id_pl_prod_order_det <> "" Or id_pl_prod_order_det <> Nothing Then
                GVBarcode.ApplyFindFilter("")
                'GVBarcode.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Default
                countQty(id_pl_prod_order_det)
            End If
            allowDelete()
            GCRetDetail.RefreshDataSource()
            GVRetDetail.RefreshData()
        End If
    End Sub

    Private Sub GVBarcode_HiddenEditor(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GVBarcode.HiddenEditor
        Dim code_check As String = GVBarcode.GetFocusedRowCellValue("code").ToString
        Dim code_found As Boolean = False
        Dim code_duplicate As Boolean = False
        Dim id_pl_prod_order_det As String = ""
        Dim counting_code As String = ""
        Dim is_old As String = ""

        'check available code
        Dim dt_filter As DataRow() = dt.Select("[code]='" + code_check + "' ")
        If dt_filter.Length > 0 Then
            id_pl_prod_order_det = dt_filter(0)("id_pl_prod_order_det").ToString
            counting_code = dt_filter(0)("counting_code").ToString
            is_old = dt_filter(0)("is_old_design").ToString
            code_found = True
        End If


        If is_old = "1" Then 'old system product
            GVBarcode.SetFocusedRowCellValue("id_pl_prod_order_rec_det_unique", "0")
            GVBarcode.SetFocusedRowCellValue("is_fix", "2")
            GVBarcode.SetFocusedRowCellValue("id_pl_prod_order_det", id_pl_prod_order_det)
            GVBarcode.SetFocusedRowCellValue("counting_code", counting_code)
            countQty(id_pl_prod_order_det)
            newRowsBc()
        ElseIf is_old = "2" Then 'new system product
            'check duplicate code
            If GVBarcode.RowCount <= 0 Then
                code_duplicate = False
            Else
                For i As Integer = 0 To (GVBarcode.RowCount - 1)
                    Dim code As String = ""
                    If Not IsDBNull(GVBarcode.GetRowCellValue(i, "code")) Then
                        code = GVBarcode.GetRowCellValue(i, "code".ToString)
                    End If

                    Dim is_fix As String = "1"
                    If Not IsDBNull(GVBarcode.GetRowCellValue(i, "is_fix")) Then
                        is_fix = GVBarcode.GetRowCellValue(i, "is_fix").ToString
                    End If

                    If code = code_check And is_fix = "2" Then
                        code_duplicate = True
                        Exit For
                    End If
                Next
            End If


            If Not code_found Then
                GVBarcode.SetFocusedRowCellValue("code", "")
                stopCustom("Data not found !")
            ElseIf code_duplicate Then
                GVBarcode.SetFocusedRowCellValue("code", "")
                stopCustom("Data duplicate !")
            Else
                GVBarcode.SetFocusedRowCellValue("id_pl_prod_order_rec_det_unique", "0")
                GVBarcode.SetFocusedRowCellValue("is_fix", "2")
                GVBarcode.SetFocusedRowCellValue("id_pl_prod_order_det", id_pl_prod_order_det)
                GVBarcode.SetFocusedRowCellValue("counting_code", counting_code)
                countQty(id_pl_prod_order_det)
                newRowsBc()
            End If
        Else
            GVBarcode.SetFocusedRowCellValue("code", "")
            stopCustom("Data not found !")
        End If
    End Sub

    Private Sub GVBarcode_FocusedColumnChanged(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.FocusedColumnChangedEventArgs) Handles GVBarcode.FocusedColumnChanged
        If Not GVBarcode.FocusedColumn.FieldName = "code" Then
            GVBarcode.FocusedColumn = GVBarcode.Columns("code")
        End If
    End Sub

    Private Sub GVBarcode_CustomColumnDisplayText(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs) Handles GVBarcode.CustomColumnDisplayText
        If e.Column.FieldName = "no" Then
            e.DisplayText = (e.ListSourceRowIndex + 1).ToString()
        End If
    End Sub

    Sub allowDelete()
        If GVBarcode.RowCount <= 0 Then
            BDelete.Enabled = False
        Else
            BDelete.Enabled = True
        End If
    End Sub

    Sub noEdit()
        Try
            Dim is_fix As String = GVBarcode.GetFocusedRowCellDisplayText("is_fix")
            'MsgBox(id_pl_prod_order_rec_det)
            If is_fix <> "2" Then
                GridColumnBarcode.OptionsColumn.AllowEdit = True
            Else
                GridColumnBarcode.OptionsColumn.AllowEdit = False
            End If
            'MsgBox(id_pl_prod_order_rec_det)
        Catch ex As Exception
            'errorCustom(ex.ToString)
        End Try
    End Sub

    Private Sub GVBarcode_FocusedRowChanged(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles GVBarcode.FocusedRowChanged
        noEdit()
    End Sub

    Sub countQty(ByVal id_pl_prod_order_detx As String)
        Dim tot As Decimal = 0.0
        For i As Integer = 0 To GVBarcode.RowCount - 1
            Dim id_pl_prod_order_det As String = GVBarcode.GetRowCellValue(i, "id_pl_prod_order_det").ToString
            If id_pl_prod_order_det = id_pl_prod_order_detx Then
                tot = tot + 1.0
            End If
        Next
        GVRetDetail.FocusedRowHandle = find_row(GVRetDetail, "id_pl_prod_order_det", id_pl_prod_order_detx)
        GVRetDetail.SetFocusedRowCellValue("pl_prod_order_rec_det_qty", tot)
        GCRetDetail.RefreshDataSource()
        GVRetDetail.RefreshData()
    End Sub

    Private Sub GVRetDetail_CustomColumnDisplayText(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs) Handles GVRetDetail.CustomColumnDisplayText
        If e.Column.FieldName = "no" Then
            e.DisplayText = (e.ListSourceRowIndex + 1).ToString()
        End If
    End Sub

    Private Sub BtnInfoSrs_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnInfoSrs.Click
        infoQty()
    End Sub
    'check limit qty
    Sub isAllowRequisition(ByVal sample_name As String, ByVal id_pl_prod_order_det_cek As String, ByVal qty_plx As String)
        cond_check = True
        qty_pl = Decimal.Parse(qty_plx.ToString)
        sample_check = sample_name
        'MsgBox(id_pl_prod_order_det_cek)
        Dim query_check As String = "CALL view_stock_prod_pl_rec('" + id_pl_prod_order + "', '" + id_pl_prod_order_det_cek + "', '0', '0', '" + id_pl_prod_order_rec + "', '0') "
        Dim data As DataTable = execute_query(query_check, -1, True, "", "", "", "")
        allow_sum = Decimal.Parse(data.Rows(0)("qty"))
        If qty_pl > allow_sum Then
            cond_check = False
        End If
    End Sub

    Sub infoQty()
        If action = "ins" Then
            FormPopUpPLProdDet.id_pop_up = "1"
            FormPopUpPLProdDet.action = "ins"
            FormPopUpPLProdDet.id_pl_prod_order = id_pl_prod_order
            FormPopUpPLProdDet.id_pl = id_pl_prod_order_rec
            FormPopUpPLProdDet.BtnSave.Visible = False
            FormPopUpPLProdDet.is_info_form = True
            FormPopUpPLProdDet.XTPCompare.PageVisible = False
            FormPopUpPLProdDet.ShowDialog()
        ElseIf action = "upd" Then
            FormPopUpPLProdDet.id_pop_up = "1"
            FormPopUpPLProdDet.action = "ins"
            FormPopUpPLProdDet.id_pl_prod_order = id_pl_prod_order
            FormPopUpPLProdDet.id_pl = id_pl_prod_order_rec
            FormPopUpPLProdDet.BtnSave.Visible = False
            FormPopUpPLProdDet.is_info_form = True
            FormPopUpPLProdDet.XTPDetail.PageVisible = False
            FormPopUpPLProdDet.ShowDialog()
        End If
    End Sub

    Private Sub PEView_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PEView.DoubleClick
        pre_viewImages("2", PEView, id_design, True)
    End Sub

    Private Sub SimpleButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SimpleButton1.Click
        For i As Integer = 0 To dt.Rows.Count - 1
            MsgBox(dt.Rows(i)("product_counting_code").ToString)
        Next
    End Sub

    Private Sub GVRetDetail_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GVRetDetail.DoubleClick
        Cursor = Cursors.WaitCursor
        If action = "ins" Then
            FormPopUpPLProdDet.id_pop_up = "1"
            FormPopUpPLProdDet.action = "ins"
            FormPopUpPLProdDet.id_pl_prod_order = id_pl_prod_order
            FormPopUpPLProdDet.id_pl = id_pl_prod_order_rec
            FormPopUpPLProdDet.BtnSave.Visible = False
            FormPopUpPLProdDet.is_info_form = True
            FormPopUpPLProdDet.XTPCompare.PageVisible = False
            FormPopUpPLProdDet.id_pl_prod_order_det = GVRetDetail.GetFocusedRowCellValue("id_pl_prod_order_det").ToString
            FormPopUpPLProdDet.ShowDialog()
        ElseIf action = "upd" Then
            FormPopUpPLProdDet.id_pop_up = "1"
            FormPopUpPLProdDet.action = "ins"
            FormPopUpPLProdDet.id_pl_prod_order = id_pl_prod_order
            FormPopUpPLProdDet.id_pl = id_pl_prod_order_rec
            FormPopUpPLProdDet.BtnSave.Visible = False
            FormPopUpPLProdDet.is_info_form = True
            FormPopUpPLProdDet.XTPDetail.PageVisible = False
            FormPopUpPLProdDet.id_pl_prod_order_det = GVRetDetail.GetFocusedRowCellValue("id_pl_prod_order_det").ToString
            FormPopUpPLProdDet.ShowDialog()
        End If
        Cursor = Cursors.Default
    End Sub

    Private Sub BtnStorage_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnStorage.Click
        Cursor = Cursors.WaitCursor
        Dim pl_prod_order_rec_det_qty_stored As Decimal = Decimal.Parse(GVRetDetail.GetFocusedRowCellValue("pl_prod_order_rec_det_qty_stored"))
        Dim pl_prod_order_rec_det_qty As Decimal = Decimal.Parse(GVRetDetail.GetFocusedRowCellValue("pl_prod_order_rec_det_qty"))
        'MsgBox(pl_prod_order_rec_det_qty_stored)
        'MsgBox(pl_prod_order_rec_det_qty)
        If pl_prod_order_rec_det_qty_stored <> pl_prod_order_rec_det_qty Then
            FormProductionStorageIn.cost = Decimal.Parse(TxtUnitCost.EditValue.ToString)
            FormProductionStorageIn.id_pl_prod_order_rec_det = GVRetDetail.GetFocusedRowCellValue("id_pl_prod_order_rec_det").ToString
            FormProductionStorageIn.id_design = GVRetDetail.GetFocusedRowCellValue("id_design").ToString
            FormProductionStorageIn.id_product = GVRetDetail.GetFocusedRowCellValue("id_product").ToString
            FormProductionStorageIn.id_sample = GVRetDetail.GetFocusedRowCellValue("id_sample").ToString
            FormProductionStorageIn.action = "ins"
            FormProductionStorageIn.colorku = GVRetDetail.GetFocusedRowCellValue("color").ToString
            FormProductionStorageIn.sizeku = GVRetDetail.GetFocusedRowCellValue("size").ToString
            FormProductionStorageIn.id_report = id_pl_prod_order_rec
            FormProductionStorageIn.report_mark_type = "37"
            FormProductionStorageIn.id_wh = id_comp_to
            FormProductionStorageIn.ShowDialog()
        Else
            errorCustom("- All item for this product has been stored in warehouse" + System.Environment.NewLine + "- If yo want to edit location storage, please edit on 'Warehouse & Locator' menu")
        End If
        Cursor = Cursors.Default
    End Sub

    Private Sub SLEStorage_EditValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SLEStorage.EditValueChanged
        Dim id_comp As String = "-1"
        Try
            id_comp = SLEStorage.EditValue.ToString
        Catch ex As Exception
            id_comp = "-1"
        End Try
        Dim query As String = ""
        query = "SELECT * FROM tb_m_wh_locator a WHERE id_comp = '" + id_comp + "'"
        viewSearchLookupQuery(SLELocator, query, "id_wh_locator", "wh_locator", "id_wh_locator")
    End Sub

    Private Sub SLELocator_EditValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SLELocator.EditValueChanged
        Dim id_locator As String = "-1"
        Try
            id_locator = SLELocator.EditValue.ToString
        Catch ex As Exception
            id_locator = "-1"
        End Try
        Dim query As String = "SELECT * FROM tb_m_wh_rack a WHERE id_wh_locator = '" + id_locator + "'"
        viewSearchLookupQuery(SLERack, query, "id_wh_rack", "wh_rack", "id_wh_rack")
    End Sub

    Private Sub SLERack_EditValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SLERack.EditValueChanged
        Dim id_rack As String = "-1"
        Try
            id_rack = SLERack.EditValue.ToString
        Catch ex As Exception
            id_rack = "-1"
        End Try
        Dim query As String = "SELECT * FROM tb_m_wh_drawer a WHERE id_wh_rack = '" + id_rack + "'"
        viewSearchLookupQuery(SLEDrawer, query, "id_wh_drawer", "wh_drawer", "id_wh_drawer")
    End Sub

    Private Sub LabelControl12_Click(sender As Object, e As EventArgs) Handles LabelControl12.Click

    End Sub

    Private Sub TxtSeason_EditValueChanged(sender As Object, e As EventArgs) Handles TxtSeason.EditValueChanged

    End Sub

    Private Sub LabelControl13_Click(sender As Object, e As EventArgs) Handles LabelControl13.Click

    End Sub

    Public Sub BtnPrint_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BtnPrint.ItemClick
        printing()
    End Sub

    Sub printing()
        Cursor = Cursors.WaitCursor
        ReportProductionPLToWHRec.dt = GCRetDetail.DataSource
        ReportProductionPLToWHRec.id_pl_prod_order_rec = id_pl_prod_order_rec
        ReportProductionPLToWHRec.id_pre = "-1"
        getReport()
        Cursor = Cursors.Default
    End Sub

    Public Sub getReport()
        GVRetDetail.BestFitColumns()
        Dim Report As New ReportProductionPLToWHRec()
        ' '... 
        ' ' creating and saving the view's layout to a new memory stream 
        Dim str As System.IO.Stream
        str = New System.IO.MemoryStream()
        GVRetDetail.SaveLayoutToStream(str, DevExpress.Utils.OptionsLayoutBase.FullLayout)
        str.Seek(0, System.IO.SeekOrigin.Begin)
        Report.GVRetDetail.RestoreLayoutFromStream(str, DevExpress.Utils.OptionsLayoutBase.FullLayout)
        str.Seek(0, System.IO.SeekOrigin.Begin)

        'Grid Detail
        ReportStyleGridview(Report.GVRetDetail)

        'Parse val
        Report.LabelRR.Text = TxtOrderNumber.Text
        Report.LabelFrom.Text = TxtCodeCompFrom.Text + "-" + TxtNameCompFrom.Text
        Report.LabelTo.Text = SLEStorage.Text
        Report.LabelDate.Text = DERet.Text
        Report.LabelNo.Text = TxtRetOutNumber.Text
        Report.LabelSource.Text = TxtPLCategory.Text
        Report.LabelDesign.Text = TEDesign.Text
        Report.LabelPO.Text = TxtPONumber.Text
        Report.LabelVendor.Text = TxtVendorCode.Text + "-" + TxtVendor.Text
        Report.LabelSeason.Text = TxtSeason.Text


        'Show the report's preview. 
        Dim Tool As DevExpress.XtraReports.UI.ReportPrintTool = New DevExpress.XtraReports.UI.ReportPrintTool(Report)
        Tool.ShowPreview()
    End Sub

    Public Sub BtnPrePrinting_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BtnPrePrinting.ItemClick
        prePrinting()
    End Sub

    Sub prePrinting()
        Cursor = Cursors.WaitCursor
        ReportProductionPLToWHRec.dt = GCRetDetail.DataSource
        ReportProductionPLToWHRec.id_pl_prod_order_rec = id_pl_prod_order_rec
        ReportProductionPLToWHRec.id_pre = "1"
        getReport()
        Cursor = Cursors.Default
    End Sub

    Private Sub BtnXlsBOF_Click(sender As Object, e As EventArgs) Handles BtnXlsBOF.Click
        exportToBOF(True)
    End Sub

    Sub exportToBOF(ByVal show_msg As Boolean)
        If bof_column = "1" Then
            Cursor = Cursors.WaitCursor

            'hide column
            For c As Integer = 0 To GVRetDetail.Columns.Count - 1
                GVRetDetail.Columns(c).Visible = False
            Next
            GridColumnCode.VisibleIndex = 0
            GridColumnQtyRec.VisibleIndex = 1
            GVRetDetail.OptionsPrint.PrintFooter = False
            GVRetDetail.OptionsPrint.PrintHeader = False


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
                ExportToExcel(GVRetDetail, exp, show_msg)
            Catch ex As Exception
                stopCustom("Please close your excel file first then try again later")
            End Try

            'show column
            GridColumnNo.VisibleIndex = 0
            GridColumnCode.VisibleIndex = 1
            GridColumnName.VisibleIndex = 2
            GridColumnSize.VisibleIndex = 3
            GridColumnQtyRec.VisibleIndex = 4
            GridColumnRemark.VisibleIndex = 5
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
                If j = 0 Then
                    wSheet.Cells(rowIndex + 1, colIndex) = dtTemp.GetRowCellValue(i, "code").ToString
                Else
                    wSheet.Cells(rowIndex + 1, colIndex) = dtTemp.GetRowCellValue(i, "pl_prod_order_rec_det_qty")
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



    Private Sub BtnAttachment_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnAttachment.Click
        Cursor = Cursors.WaitCursor
        FormDocumentUpload.id_report = id_pl_prod_order_rec
        FormDocumentUpload.report_mark_type = "37"
        FormDocumentUpload.ShowDialog()
        Cursor = Cursors.Default
    End Sub

    Private Sub SLEStorage_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles SLEStorage.Validating
        EP_SLE_cant_blank(EPRet, SLEStorage)
    End Sub
End Class