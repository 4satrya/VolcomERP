Imports Microsoft.Office.Interop
Public Class FormProductionPLToWHDet
    Public action As String
    Public id_pl_prod_order As String = "0"
    Public id_prod_order As String = "-1"
    Public id_comp_contact_to As String = "-1"
    Public id_comp_contact_from As String = "-1"
    Public id_prod_order_det_list, id_pl_prod_order_det_list, id_pl_prod_order_det_unique_list As New List(Of String)
    Dim date_start As Date
    Public id_report_status As String
    Public id_season As String = "-1"
    Public bof_column As String = get_setup_field("bof_column")
    Public bof_xls As String = get_setup_field("bof_xls_pl")

    'var check qty
    Public cond_check As Boolean = True
    Public sample_check As String
    Public qty_pl As Decimal
    Public allow_sum As Decimal
    Public allow_alloc As Decimal

    'var check duplicate unique
    Public cond_check_unique As Boolean = True
    Public sample_check_unique As String
    Public qty_pl_unique As Decimal
    Public allow_sum_unique As Decimal

    Public id_design As String = "-1"
    Public data_code As DataTable
    Dim myListOfDogs As New List(Of String)
    Public dt As New DataTable

    Public Class FileRecord
        Public Id As String
        Public Code As String
    End Class

    Private Sub FormProductionPLToWHDet_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        viewReportStatus() 'get report status
        viewPLCat()
        viewPDAlloc()
        actionLoad()
    End Sub

    Sub viewPDAlloc()
        Dim query As String = "SELECT * FROM tb_lookup_pd_alloc a ORDER BY a.priority ASC "
        viewLookupQuery(LEPDAlloc, query, 0, "pd_alloc", "id_pd_alloc")
    End Sub

    Private Sub FormProductionPLToWHDet_FormClosed(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Sub actionLoad()
        Try
            'initiation datatable jika blm ada
            dt.Columns.Add("id_product")
            dt.Columns.Add("id_prod_order_det")
            dt.Columns.Add("product_code")
            dt.Columns.Add("product_counting_code")
            dt.Columns.Add("product_full_code")
            dt.Columns.Add("is_old_design")
        Catch ex As Exception

        End Try

        If action = "ins" Then
            TxtRetOutNumber.Text = ""
            BtnPrint.Enabled = False
            BMark.Enabled = False
            BtnAttachment.Enabled = False
            DERet.Text = view_date(0)


            'own source
            Dim id_qc As String = execute_query("SELECT id_qc_dept FROM tb_opt", 0, True, "", "", "", "")
            Dim query_get_comp_name As String = "SELECT b.comp_name, b.comp_number FROM tb_m_comp_contact a "
            query_get_comp_name += "INNER JOIN tb_m_comp b ON a.id_comp = b.id_comp "
            query_get_comp_name += "WHERE a.id_comp_contact = '" + id_qc + "' AND b.id_departement = '" + id_departement_user + "'"
            Try
                Dim data_comp_from As DataTable = execute_query(query_get_comp_name, -1, True, "", "", "", "")
                TxtNameCompFrom.Text = data_comp_from(0)("comp_name").ToString
                TxtCodeCompFrom.Text = data_comp_from(0)("comp_number").ToString
                id_comp_contact_from = id_qc
            Catch ex As Exception
                TxtNameCompFrom.Text = ""
                TxtCodeCompFrom.Text = ""
                id_comp_contact_from = "-1"
            End Try

            'from info PL
            If id_prod_order <> "-1" Then
                view_po()
                GroupControlRet.Enabled = True
                GroupControlListBarcode.Enabled = True
                id_prod_order_det_list.Clear()
                viewDetail()
                view_barcode_list()
                check_but()
                BtnInfoSrs.Enabled = True
                BtnViewLineList.Enabled = True
            End If
        ElseIf action = "upd" Then
            'View data
            BMark.Enabled = True
            Try
                Dim query As String = "SELECT a.id_pl_category, (h.design_display_name) AS `design_name`, h.id_sample, h.id_season, DATE_FORMAT(a.pl_prod_order_date,'%Y-%m-%d') as pl_prod_order_datex, a.id_report_status, a.id_prod_order, a.id_pl_prod_order, a.pl_prod_order_date, "
                query += "a.pl_prod_order_note, a.pl_prod_order_number,  "
                query += "b.prod_order_number, (c.id_comp_contact) AS id_comp_contact_from, (d.comp_name) AS comp_name_contact_from, (d.comp_number) AS comp_code_contact_from, (d.address_primary) AS comp_address_contact_from, "
                query += "g.id_design,(e.id_comp_contact) AS id_comp_contact_to, (f.comp_name) AS comp_name_contact_to, (f.comp_number) AS comp_code_contact_to,(f.address_primary) AS comp_address_contact_to, a.id_pd_alloc, ho.id_ho_type, ho.ho_type "
                query += "FROM tb_pl_prod_order a "
                query += "INNER JOIN tb_prod_order b ON a.id_prod_order = b.id_prod_order "
                query += "INNER JOIN tb_m_comp_contact c ON a.id_comp_contact_from = c.id_comp_contact "
                query += "INNER JOIN tb_m_comp d ON d.id_comp = c.id_comp "
                query += "INNER JOIN tb_m_comp_contact e ON a.id_comp_contact_to = e.id_comp_contact "
                query += "INNER JOIN tb_m_comp f ON e.id_comp = f.id_comp "
                query += "INNER JOIN tb_prod_demand_design g ON g.id_prod_demand_design = b.id_prod_demand_design "
                query += "INNER JOIN tb_m_design h ON g.id_design = h.id_design "
                query += "INNER JOIN tb_lookup_ho_type ho ON ho.id_ho_type = a.id_ho_type "
                query += "WHERE a.id_pl_prod_order='" + id_pl_prod_order + "' "
                Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
                LEPDAlloc.ItemIndex = LEPDAlloc.Properties.GetDataSourceRowIndex("id_pd_alloc", data.Rows(0)("id_pd_alloc").ToString)
                TxtOrderNumber.Text = data.Rows(0)("prod_order_number").ToString
                id_comp_contact_from = data.Rows(0)("id_comp_contact_from").ToString
                TxtCodeCompFrom.Text = data.Rows(0)("comp_code_contact_from").ToString
                TxtNameCompFrom.Text = data.Rows(0)("comp_name_contact_from").ToString
                id_comp_contact_to = data.Rows(0)("id_comp_contact_to").ToString
                TxtCodeCompTo.Text = data.Rows(0)("comp_code_contact_to").ToString
                TxtNameCompTo.Text = data.Rows(0)("comp_name_contact_to").ToString
                MEAdrressCompTo.Text = data.Rows(0)("comp_address_contact_to").ToString
                'Dim start_date_arr() As String = data.Rows(0)("pl_prod_order_date").ToString.Split(" ")
                DERet.Text = view_date_from(data.Rows(0)("pl_prod_order_datex").ToString, 0)
                TxtRetOutNumber.Text = data.Rows(0)("pl_prod_order_number").ToString
                MENote.Text = data.Rows(0)("pl_prod_order_note").ToString
                LEReportStatus.ItemIndex = LEReportStatus.Properties.GetDataSourceRowIndex("id_report_status", data.Rows(0)("id_report_status").ToString)
                LEPLCategory.ItemIndex = LEPLCategory.Properties.GetDataSourceRowIndex("id_pl_category", data.Rows(0)("id_pl_category").ToString)
                id_report_status = data.Rows(0)("id_report_status").ToString
                id_prod_order = data.Rows(0)("id_prod_order").ToString
                id_design = data.Rows(0)("id_design").ToString
                pre_viewImages("2", PEView, id_design, False)
                TEDesign.Text = data.Rows(0)("design_name").ToString
                id_season = data.Rows(0)("id_season").ToString
                PEView.Enabled = True
                mainVendor()
            Catch ex As Exception
                errorConnection()
            End Try

            'Enable/Disable
            LEPDAlloc.Enabled = False
            BtnBrowsePO.Enabled = False
            GroupControlRet.Enabled = True
            GroupControlListBarcode.Enabled = True
            BtnInfoSrs.Enabled = True
            BtnViewLineList.Enabled = True

            view_barcode_list()
            viewDetail()
            check_but()
            allowDelete()
            allow_status()
        End If
    End Sub

    Sub mainVendor()
        'main vendor
        Dim data_vend As DataTable = getMainVendor(id_prod_order)
        Try
            TxtVendorCode.Text = data_vend.Rows(0)("comp_number").ToString
            TxtVendor.Text = data_vend.Rows(0)("comp_name").ToString
        Catch ex As Exception
            TxtVendorCode.Text = ""
            TxtVendor.Text = ""
        End Try
    End Sub

    Sub allow_status()
        If check_edit_report_status(id_report_status, "33", id_pl_prod_order) Then
            BtnBrowseContactFrom.Enabled = True
            BtnBrowseContactTo.Enabled = True
            BtnAdd.Enabled = True
            BtnEdit.Enabled = True
            BtnDel.Enabled = True
            MENote.Properties.ReadOnly = False
            BtnSave.Enabled = True
            BScan.Enabled = True
            BDelete.Enabled = True
            BtnInfoSrs.Enabled = True
            LEPLCategory.Enabled = True
            GVRetDetail.OptionsBehavior.ReadOnly = False
        Else
            BtnBrowseContactFrom.Enabled = False
            BtnBrowseContactTo.Enabled = False
            BtnAdd.Enabled = False
            BtnEdit.Enabled = False
            BtnDel.Enabled = False
            MENote.Properties.ReadOnly = True
            DERet.Properties.ReadOnly = True
            BtnSave.Enabled = False
            BScan.Enabled = False
            BDelete.Enabled = False
            BtnInfoSrs.Enabled = False
            LEPLCategory.Enabled = False
            GVRetDetail.OptionsBehavior.ReadOnly = True
        End If
        PanelNavBarcode.Enabled = False

        'attachment
        If check_attach_report_status(id_report_status, "33", id_pl_prod_order) Then
            BtnAttachment.Enabled = True
        Else
            BtnAttachment.Enabled = False
        End If

        'print
        If check_print_report_status(id_report_status) Then
            BtnPrint.Enabled = True
        Else
            BtnPrint.Enabled = False
        End If

        'bof column
        If bof_column = "1" And LEReportStatus.EditValue.ToString <> "5" Then
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
            BtnEdit.Enabled = True
            BtnDel.Enabled = True
        Else
            BtnEdit.Enabled = False
            BtnDel.Enabled = False
        End If
    End Sub
    'View po
    Sub view_list_po(ByVal id_prod_order As String)
        Dim query = "CALL view_prod_order_det('" & id_prod_order & "', '0')"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        For i As Integer = 0 To (data.Rows.Count - 1)
            id_prod_order_det_list.Add(data.Rows(i)("id_prod_order_det").ToString)
        Next
        GCRetDetail.DataSource = data
    End Sub

    Sub view_po()
        Dim query As String = "SELECT d.id_sample, (d.design_display_name) AS `design_name`, a.id_report_status, a.prod_order_number, a.id_po_type, DATE_FORMAT(a.prod_order_date,'%Y-%m-%d') as prod_order_datex, "
        query += "d.id_design,a.prod_order_lead_time, a.prod_order_note, f.id_season "
        query += "FROM tb_prod_order a "
        query += "INNER JOIN tb_prod_demand_design b ON a.id_prod_demand_design = b.id_prod_demand_design "
        query += "INNER JOIN tb_lookup_report_status c ON a.id_report_status = c.id_report_status "
        query += "INNER JOIN tb_m_design d ON b.id_design = d.id_design "
        query += "INNER JOIN tb_season_delivery e ON b.id_delivery=e.id_delivery "
        query += "INNER JOIN tb_season f ON f.id_season=e.id_season "
        query += "INNER JOIN tb_lookup_po_type g ON g.id_po_type=a.id_po_type "
        query += "INNER JOIN tb_lookup_term_production h ON h.id_term_production=a.id_term_production "
        query += "WHERE id_prod_order = '{0}' "
        query = String.Format(query, id_prod_order)
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")

        TxtOrderNumber.Text = data.Rows(0)("prod_order_number").ToString
        TEDesign.Text = data.Rows(0)("design_name").ToString
        id_season = data.Rows(0)("id_season").ToString
        id_design = data.Rows(0)("id_design").ToString
        pre_viewImages("2", PEView, data.Rows(0)("id_design").ToString, False)
        PEView.Enabled = True
        mainVendor()
    End Sub

    'View Data
    Sub viewReportStatus()
        Dim query As String = "SELECT * FROM tb_lookup_report_status a ORDER BY a.id_report_status "
        'Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        viewLookupQuery(LEReportStatus, query, 0, "report_status", "id_report_status")
    End Sub

    Sub view_barcode_list()
        If action = "ins" Then
            Dim query As String = "SELECT ('0') AS no, ('') AS code, ('0') AS id_prod_order_det, ('1') AS is_fix, ('') AS counting_code, ('0') AS id_pl_prod_order_det_unique "
            Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
            GCBarcode.DataSource = data
            deleteRowsBc()
        ElseIf action = "upd" Then
            Dim query As String = "SELECT ('') AS no, CONCAT(c.product_full_code, a.pl_prod_order_det_counting) AS code, "
            query += "b.id_pl_prod_order_det, (a.pl_prod_order_det_counting) AS counting_code, a.id_pl_prod_order_det_unique, ('2') AS is_fix, b.id_prod_order_det "
            query += "FROM tb_pl_prod_order_det_counting a "
            query += "INNER JOIN tb_pl_prod_order_det b ON a.id_pl_prod_order_det = b.id_pl_prod_order_det "
            query += "INNER JOIN tb_m_product c ON a.id_product = c.id_product "
            query += "WHERE b.id_pl_prod_order = '" + id_pl_prod_order + "' "
            Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
            For i As Integer = 0 To (data.Rows.Count - 1)
                id_pl_prod_order_det_unique_list.Add(data.Rows(i)("id_pl_prod_order_det_unique").ToString)
                'code dipindah ke detail    
            Next
            GCBarcode.DataSource = data
        End If
    End Sub

    Sub viewDetail()
        If action = "ins" Then
            'UPDATED 22 DECEMBER 2014
            Dim query As String = "CALL view_stock_prod_rec('" + id_prod_order + "', '0', '0', '0', '" + id_pl_prod_order + "','0', '" + LEPDAlloc.EditValue.ToString + "')"
            Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
            For i As Integer = 0 To (data.Rows.Count - 1)
                id_prod_order_det_list.Add(data.Rows(i)("id_prod_order_det").ToString)
            Next
            GCRetDetail.DataSource = data

            FormProcessing.id_process = "3"
            FormProcessing.idx_main = id_prod_order
            FormProcessing.ShowDialog()
        ElseIf action = "upd" Then
            Dim query As String = "CALL view_PL_prod('" + id_pl_prod_order + "', '0', '" + LEPDAlloc.EditValue.ToString + "')"
            Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
            For i As Integer = 0 To (data.Rows.Count - 1)
                id_prod_order_det_list.Add(data.Rows(i)("id_prod_order_det").ToString)
                id_pl_prod_order_det_list.Add(data.Rows(i)("id_pl_prod_order_det").ToString)
                Dim id_prod_order_det As String = data.Rows(i)("id_prod_order_det").ToString
                Dim queryx As String = "SELECT a.id_product, pod.id_prod_order_det, a.range_awal, a.range_akhir, a.digit_code, a.product_full_code, a.is_old_design,a.last_print_unique 
                                        FROM tb_prod_order_det pod
                                        INNER JOIN tb_prod_demand_product pdd ON pdd.id_prod_demand_product=pod.id_prod_demand_product
                                        INNER JOIN tb_m_product p ON pdd.id_product=p.id_product
                                        INNER JOIN 
                                        (
                                        SELECT a.id_product, a.id_prod_order_det, MIN(a.range_awal) AS range_awal, MAX(a.range_akhir) AS range_akhir, a.digit_code, b.product_full_code, dsg.is_old_design,b.last_print_unique 
                                        FROM tb_m_product_range a 
                                        INNER JOIN tb_m_product b ON a.id_product = b.id_product 
                                        INNER JOIN tb_m_design dsg ON dsg.id_design = b.id_design 
                                        GROUP BY a.id_product 
                                        )a ON a.id_product=p.id_product
                                        WHERE pod.id_prod_order_det = '" + id_prod_order_det + "' GROUP BY a.id_product "
                Dim datax As DataTable = execute_query(queryx, -1, True, "", "", "", "")
                For k As Integer = 0 To (datax.Rows.Count - 1)
                    'data.Rows(0)("id_product").ToString
                    Dim id_product As String = datax.Rows(k)("id_product").ToString
                    Dim range_awal As Integer = Integer.Parse(datax.Rows(k)("range_awal").ToString)
                    'Dim range_akhir As Integer = Integer.Parse(datax.Rows(k)("range_akhir").ToString)
                    Dim range_akhir As Integer = Integer.Parse(datax.Rows(k)("last_print_unique").ToString)
                    Dim digit_code As Integer = Integer.Parse(datax.Rows(k)("digit_code").ToString)
                    Dim product_code As String = datax.Rows(k)("product_full_code").ToString
                    Dim is_old_design As String = datax.Rows(k)("is_old_design").ToString
                    For j As Integer = range_awal To range_akhir
                        Dim R As DataRow = dt.NewRow
                        R("id_product") = id_product
                        R("id_prod_order_det") = id_prod_order_det
                        R("product_code") = product_code
                        R("product_counting_code") = combine_header_number("", j, digit_code)
                        R("product_full_code") = combine_header_number(product_code, j, digit_code)
                        R("is_old_design") = is_old_design
                        dt.Rows.Add(R)
                    Next
                Next
            Next
            GCRetDetail.DataSource = data
        End If
        check_but()
    End Sub

    Sub tampungArr(ByVal id_prod_order_det As String)

    End Sub

    'View PL Category
    Sub viewPLCat()
        Dim query As String = "SELECT * FROM tb_lookup_pl_category a ORDER BY a.id_pl_category  "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        viewLookupQuery(LEPLCategory, query, 0, "pl_category", "id_pl_category")
    End Sub

    'Button
    Private Sub BtnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSave.Click
        Cursor = Cursors.WaitCursor
        makeSafeGV(GVRetDetail)
        makeSafeGV(GVBarcode)
        ValidateChildren()

        'Cek isi qty
        Dim cond_qty As Boolean = True
        Dim qty As Decimal
        For i As Integer = 0 To ((GVRetDetail.RowCount - 1) - GetGroupRowCount(GVRetDetail))
            qty = GVRetDetail.GetRowCellValue(i, "pl_prod_order_det_qty")
            If qty = 0.0 Then
                cond_qty = False
            End If
        Next

        'cek qty limit di DB
        Dim dt_cek As DataTable = execute_query("CALL view_stock_prod_rec('" + id_prod_order + "', '0', '0', '0', '" + id_pl_prod_order + "', '0', '" + LEPDAlloc.EditValue.ToString + "') ", -1, True, "", "", "", "")
        For i As Integer = 0 To ((GVRetDetail.RowCount - 1) - GetGroupRowCount(GVRetDetail))
            Dim id_prod_order_det_cekya As String = GVRetDetail.GetRowCellValue(i, "id_prod_order_det").ToString
            Dim qty_plya As String = GVRetDetail.GetRowCellValue(i, "pl_prod_order_det_qty").ToString
            Dim sample_checkya As String = GVRetDetail.GetRowCellValue(i, "name").ToString + " / Size " + GVRetDetail.GetRowCellValue(i, "size").ToString
            Dim data_filter_cek As DataRow() = dt_cek.Select("[id_prod_order_det]='" + id_prod_order_det_cekya + "' ")
            Dim qty_pl As Integer = 0
            If data_filter_cek.Length <= 0 Then
                qty_pl = 0
            Else
                qty_pl = data_filter_cek(0)("qty")
            End If
            If qty_plya > qty_pl Then
                cond_check = False
            End If
            If Not cond_check Then
                Exit For
            End If
        Next

        'cek uniqueCode
        Dim found_check_unique As Boolean = False
        'sample_check_unique = ""
        Dim query_check_exist As String = "SELECT d.pl_prod_order_number, CONCAT(b.product_full_code, a.pl_prod_order_det_counting) AS `barcode` FROM tb_pl_prod_order_det_counting a "
        query_check_exist += "INNER JOIN tb_m_product b ON a.id_product = b.id_product "
        query_check_exist += "INNER JOIN tb_m_design dsg ON dsg.id_design = b.id_design "
        query_check_exist += "INNER JOIN tb_pl_prod_order_det c ON a.id_pl_prod_order_det = c.id_pl_prod_order_det "
        query_check_exist += "INNER JOIN tb_pl_prod_order d ON c.id_pl_prod_order = d.id_pl_prod_order 
        INNER JOIN tb_prod_order_det pod ON pod.id_prod_order_det = c.id_prod_order_det
        INNER JOIN tb_prod_demand_product pdp ON pdp.id_prod_demand_product = pod.id_prod_demand_product "
        query_check_exist += "WHERE d.id_pl_prod_order!='" + id_pl_prod_order + "' AND d.id_report_status != '5' AND b.id_design='" + id_design + "' AND dsg.is_old_design=2 "
        Dim data_check_exist As DataTable = execute_query(query_check_exist, True, -1, "", "", "", "")
        For j As Integer = 0 To (GVBarcode.RowCount - 1)
            Dim barcode_check As String = GVBarcode.GetRowCellValue(j, "code")
            Dim data_filter As DataRow() = data_check_exist.Select("[barcode]='" + barcode_check + "'")
            If data_filter.Length > 0 Then
                found_check_unique = True
                sample_check_unique = "Code : " + barcode_check + ", already exist in PL Number : " + data_filter(0)("pl_prod_order_number").ToString + ""
                Exit For
            End If
        Next

        If Not formIsValidInPanel(EPRet, PanelControlTopMain) Then
            errorInput()
            'ElseIf Not cond_qty Or GVRetDetail.RowCount = 0 Then
            '    errorCustom("Qty can't blank or zero value !")
        ElseIf Not cond_check Then
            errorCustom("- Product : '" + sample_check + "' more than qty total, please check in Info Qty !" + System.Environment.NewLine + "- Use 'receiving QC module' for new item product. ")
            infoQty()
        ElseIf found_check_unique Then
            errorCustom(sample_check_unique)
        Else
            Dim query As String
            Dim pl_prod_order_number As String = ""
            Dim pl_prod_order_note As String = addSlashes(MENote.Text)
            Dim id_report_status As String = LEReportStatus.EditValue
            Dim id_prod_order_det, pl_prod_order_det_qty, pl_prod_order_det_note As String
            Dim id_pl_prod_order_det As String
            Dim id_pl_category As String = LEPLCategory.EditValue.ToString
            Dim id_pd_alloc As String = LEPDAlloc.EditValue.ToString
            If action = "ins" Then
                Dim confirm As DialogResult = DevExpress.XtraEditors.XtraMessageBox.Show("Are you sure to save changes this data?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
                If confirm = Windows.Forms.DialogResult.Yes Then
                    Cursor = Cursors.WaitCursor
                    Try
                        'Main tbale
                        pl_prod_order_number = header_number_prod("7")
                        query = "INSERT INTO tb_pl_prod_order(id_prod_order, pl_prod_order_number, id_comp_contact_to, id_comp_contact_from, pl_prod_order_date, pl_prod_order_note, id_report_status, id_pl_category, id_pd_alloc) "
                        query += "VALUES('" + id_prod_order + "', '" + pl_prod_order_number + "', '" + id_comp_contact_to + "', '" + id_comp_contact_from + "', NOW(), '" + pl_prod_order_note + "', '" + id_report_status + "', '" + id_pl_category + "', NULL); SELECT LAST_INSERT_ID(); "
                        id_pl_prod_order = execute_query(query, 0, True, "", "", "", "")

                        increase_inc_prod("7")

                        'insert who prepared
                        insert_who_prepared("33", id_pl_prod_order, id_user)

                        'Detail return
                        Dim jum_ins_j As Integer = 0
                        Dim query_detail As String = ""
                        If GVRetDetail.RowCount > 0 Then
                            query_detail = "INSERT tb_pl_prod_order_det(id_pl_prod_order, id_prod_order_det, pl_prod_order_det_qty, pl_prod_order_det_note) VALUES "
                        End If
                        For j As Integer = 0 To ((GVRetDetail.RowCount - 1) - GetGroupRowCount(GVRetDetail))
                            Try
                                id_prod_order_det = GVRetDetail.GetRowCellValue(j, "id_prod_order_det").ToString
                                pl_prod_order_det_qty = decimalSQL(GVRetDetail.GetRowCellValue(j, "pl_prod_order_det_qty").ToString)
                                pl_prod_order_det_note = GVRetDetail.GetRowCellValue(j, "pl_prod_order_det_note").ToString

                                If jum_ins_j > 0 Then
                                    query_detail += ", "
                                End If
                                query_detail += "('" + id_pl_prod_order + "', '" + id_prod_order_det + "', '" + pl_prod_order_det_qty + "', '" + pl_prod_order_det_note + "') "
                                jum_ins_j = jum_ins_j + 1
                            Catch ex As Exception
                            End Try
                        Next
                        If jum_ins_j > 0 Then
                            execute_non_query(query_detail, True, "", "", "", "")
                        End If


                        'get all detail
                        Dim query_get_detail As String = "SELECT a.id_pl_prod_order_det, a.id_prod_order_det, c.id_product FROM tb_pl_prod_order_det a "
                        query_get_detail += "INNER JOIN tb_prod_order_det b ON a.id_prod_order_det = b.id_prod_order_det "
                        query_get_detail += "INNER JOIN tb_prod_demand_product c ON b.id_prod_demand_product = c.id_prod_demand_product "
                        query_get_detail += "WHERE a.id_pl_prod_order = '" + id_pl_prod_order + "' "
                        Dim data_get_detail As DataTable = execute_query(query_get_detail, True, -1, "", "", "", "")

                        'counting
                        Dim jum_ins As Integer = 0
                        Dim query_counting As String = ""
                        If GVBarcode.RowCount > 0 Then
                            query_counting = "INSERT INTO tb_pl_prod_order_det_counting(id_pl_prod_order_det, pl_prod_order_det_counting, id_product) VALUES "
                        End If
                        For k As Integer = 0 To (GVBarcode.RowCount - 1)
                            Dim id_prod_order_det_counting As String = GVBarcode.GetRowCellValue(k, "id_prod_order_det").ToString
                            Dim pl_prod_order_det_counting As String = GVBarcode.GetRowCellValue(k, "counting_code").ToString
                            For kx As Integer = 0 To (data_get_detail.Rows.Count - 1)
                                If id_prod_order_det_counting = data_get_detail.Rows(kx)("id_prod_order_det").ToString Then
                                    If jum_ins > 0 Then
                                        query_counting += ", "
                                    End If
                                    query_counting += "('" + data_get_detail.Rows(kx)("id_pl_prod_order_det").ToString + "', '" + pl_prod_order_det_counting + "', '" + data_get_detail.Rows(kx)("id_product").ToString + "') "
                                    jum_ins = jum_ins + 1
                                    Exit For
                                End If
                            Next
                        Next
                        If jum_ins > 0 Then
                            execute_non_query(query_counting, True, "", "", "", "")
                        End If

                        FormProductionPLToWH.viewPL()
                        FormProductionPLToWH.view_sample_purc()
                        FormProductionPLToWH.GVPL.FocusedRowHandle = find_row(FormProductionPLToWH.GVPL, "id_pl_prod_order", id_pl_prod_order)
                        FormProductionPLToWH.XTCPL.SelectedTabPageIndex = 0
                        action = "upd"
                        actionLoad()

                        'gen xls
                        exportToBOF(False)

                        infoCustom("PL was created successfully!")
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
                        pl_prod_order_number = addSlashes(TxtRetOutNumber.Text)

                        'edit main table
                        query = "UPDATE tb_pl_prod_order SET id_prod_order = '" + id_prod_order + "', pl_prod_order_number = '" + pl_prod_order_number + "', id_comp_contact_to = '" + id_comp_contact_to + "', id_comp_contact_from = '" + id_comp_contact_from + "', id_report_status = '" + id_report_status + "', pl_prod_order_note = '" + pl_prod_order_note + "', id_pl_category = '" + id_pl_category + "', id_pd_alloc = NULL WHERE id_pl_prod_order = '" + id_pl_prod_order + "' "
                        execute_non_query(query, True, "", "", "", "")

                        'edit detail table
                        Dim jum_ins_j As Integer = 0
                        Dim query_detail As String = ""
                        If GVRetDetail.RowCount > 0 Then
                            query_detail = "INSERT tb_pl_prod_order_det(id_pl_prod_order, id_prod_order_det, pl_prod_order_det_qty, pl_prod_order_det_note) VALUES "
                        End If
                        For j As Integer = 0 To (GVRetDetail.RowCount - 1)
                            Try
                                id_pl_prod_order_det = GVRetDetail.GetRowCellValue(j, "id_pl_prod_order_det").ToString
                                id_prod_order_det = GVRetDetail.GetRowCellValue(j, "id_prod_order_det").ToString
                                pl_prod_order_det_qty = decimalSQL(GVRetDetail.GetRowCellValue(j, "pl_prod_order_det_qty").ToString)
                                pl_prod_order_det_note = GVRetDetail.GetRowCellValue(j, "pl_prod_order_det_note").ToString

                                If id_pl_prod_order_det = "0" Then
                                    If jum_ins_j > 0 Then
                                        query_detail += ", "
                                    End If
                                    query_detail += "('" + id_pl_prod_order + "', '" + id_prod_order_det + "', '" + pl_prod_order_det_qty + "', '" + pl_prod_order_det_note + "') "
                                    jum_ins_j = jum_ins_j + 1
                                Else
                                    Dim query_upd As String = "UPDATE tb_pl_prod_order_det SET id_prod_order_det = '" + id_prod_order_det + "', pl_prod_order_det_qty = '" + pl_prod_order_det_qty + "', pl_prod_order_det_note = '" + pl_prod_order_det_note + "' WHERE id_pl_prod_order_det = '" + id_pl_prod_order_det + "'"
                                    execute_non_query(query_upd, True, "", "", "", "")
                                    id_pl_prod_order_det_list.Remove(id_pl_prod_order_det)
                                End If
                            Catch ex As Exception
                                ex.ToString()
                            End Try
                        Next
                        If jum_ins_j > 0 Then
                            execute_non_query(query_detail, True, "", "", "", "")
                        End If

                        'delete sisa
                        For k As Integer = 0 To (id_pl_prod_order_det_list.Count - 1)
                            Try
                                query = "DELETE FROM tb_pl_prod_order_det WHERE id_pl_prod_order_det = '" + id_pl_prod_order_det_list(k) + "' "
                                execute_non_query(query, True, "", "", "", "")
                            Catch ex As Exception
                                ex.ToString()
                            End Try
                        Next

                        'get all detail
                        Dim query_get_detail As String = "SELECT a.id_pl_prod_order_det, a.id_prod_order_det, c.id_product FROM tb_pl_prod_order_det a "
                        query_get_detail += "INNER JOIN tb_prod_order_det b ON a.id_prod_order_det = b.id_prod_order_det "
                        query_get_detail += "INNER JOIN tb_prod_demand_product c ON b.id_prod_demand_product = c.id_prod_demand_product "
                        query_get_detail += "WHERE a.id_pl_prod_order = '" + id_pl_prod_order + "' "
                        Dim data_get_detail As DataTable = execute_query(query_get_detail, True, -1, "", "", "", "")

                        'counting
                        Dim query_counting As String = ""
                        If GVBarcode.RowCount > 0 Then
                            query_counting = "INSERT INTO tb_pl_prod_order_det_counting(id_pl_prod_order_det, pl_prod_order_det_counting, id_product) VALUES "
                        End If
                        Dim jum_ins As Integer = 0
                        For k As Integer = 0 To (GVBarcode.RowCount - 1)
                            Dim id_prod_order_det_counting As String = GVBarcode.GetRowCellValue(k, "id_prod_order_det").ToString
                            Dim pl_prod_order_det_counting As String = GVBarcode.GetRowCellValue(k, "counting_code").ToString
                            Dim id_pl_prod_order_det_unique As String = GVBarcode.GetRowCellValue(k, "id_pl_prod_order_det_unique").ToString
                            If id_pl_prod_order_det_unique = "0" Then
                                For kx As Integer = 0 To (data_get_detail.Rows.Count - 1)
                                    If id_prod_order_det_counting = data_get_detail.Rows(kx)("id_prod_order_det").ToString Then
                                        If jum_ins > 0 Then
                                            query_counting += ", "
                                        End If
                                        query_counting += "('" + data_get_detail.Rows(kx)("id_pl_prod_order_det").ToString + "', '" + pl_prod_order_det_counting + "', '" + data_get_detail.Rows(kx)("id_product").ToString + "') "
                                        jum_ins = jum_ins + 1
                                        Exit For
                                    End If
                                Next
                            Else
                                id_pl_prod_order_det_unique_list.Remove(id_pl_prod_order_det_unique)
                            End If
                        Next
                        If jum_ins > 0 Then
                            execute_non_query(query_counting, True, "", "", "", "")
                        End If

                        'delete sisa unique
                        For k As Integer = 0 To (id_pl_prod_order_det_unique_list.Count - 1)
                            Try
                                query = "DELETE FROM tb_pl_prod_order_det_counting WHERE id_pl_prod_order_det_unique = '" + id_pl_prod_order_det_unique_list(k) + "' "
                                execute_non_query(query, True, "", "", "", "")
                            Catch ex As Exception
                                ex.ToString()
                            End Try
                        Next

                        'View
                        FormProductionPLToWH.viewPL()
                        FormProductionPLToWH.view_sample_purc()
                        FormProductionPLToWH.GVPL.FocusedRowHandle = find_row(FormProductionPLToWH.GVPL, "id_pl_prod_order", id_pl_prod_order)
                        action = "upd"
                        actionLoad()

                        'gen xls
                        exportToBOF(False)

                        infoCustom("PL was edited successfully!")
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
        If id_comp_contact_from <> "-1" And id_comp_contact_to <> "-1" Then
            FormPopUpProd.id_pop_up = "4"
            FormPopUpProd.ShowDialog()
        Else
            stopCustom("Please input `From` and `To` first!")
        End If
    End Sub
    Private Sub BtnBrowseContactFrom_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnBrowseContactFrom.Click
        FormPopUpContact.id_pop_up = "35"
        FormPopUpContact.id_departement = id_departement_user
        FormPopUpContact.ShowDialog()
    End Sub
    Private Sub BtnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnAdd.Click
        FormPopUpProdDet.id_pop_up = "3"
        FormPopUpProdDet.action = "ins"
        FormPopUpProdDet.id_prod_order = id_prod_order
        FormPopUpProdDet.id_pl = id_pl_prod_order
        FormPopUpProdDet.ShowDialog()
    End Sub
    Private Sub BtnDel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnDel.Click
        If (MessageBox.Show("Are you sure to delete this row?", "Delete Confirmation", MessageBoxButtons.YesNo) <> DialogResult.Yes) Then Return
        Dim id_prod_order_det As String = GVRetDetail.GetFocusedRowCellDisplayText("id_prod_order_det").ToString
        id_prod_order_det_list.Remove(id_prod_order_det) 'delete list
        deleteRows() 'delete list
        deleteDetailBc(id_prod_order_det) 'delete barcode

        'delete datatable
        FormProcessing.id_process = "2"
        FormProcessing.idx = id_prod_order_det
        FormProcessing.ShowDialog()
        check_but()
    End Sub

    Sub deleteDetailBc(ByVal id_prod_order_det As String)
        'delete detail
        Dim i As Integer = GVBarcode.RowCount - 1
        While (i >= 0)
            Dim id_prod_order_detx As String = ""
            Try
                id_prod_order_detx = GVBarcode.GetRowCellValue(i, "id_prod_order_det").ToString()
            Catch ex As Exception

            End Try
            If id_prod_order_det = id_prod_order_detx Then
                GVBarcode.DeleteRow(i)
            End If
            i = i - 1
        End While
    End Sub
    Private Sub BtnEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnEdit.Click
        FormPopUpProdDet.id_pop_up = "3"
        FormPopUpProdDet.action = "upd"
        FormPopUpProdDet.id_prod_order = id_prod_order
        FormPopUpProdDet.id_prod_order_det_edit = GVRetDetail.GetFocusedRowCellValue("id_prod_order_det").ToString
        FormPopUpProdDet.id_pl = id_pl_prod_order
        FormPopUpProdDet.ShowDialog()
    End Sub
    Private Sub BtnPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnPrint.Click
        Cursor = Cursors.WaitCursor
        GVRetDetail.BestFitColumns()
        ReportProductionPLToWH.dt = GCRetDetail.DataSource
        ReportProductionPLToWH.id_pl_prod_order = id_pl_prod_order
        Dim Report As New ReportProductionPLToWH()

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
        Report.LabelTo.Text = TxtCodeCompTo.Text + "- " + TxtNameCompTo.Text
        Report.LabelDate.Text = DERet.Text
        Report.LabelNo.Text = TxtRetOutNumber.Text
        Report.LabelSource.Text = LEPLCategory.Text
        Report.LabelDesign.Text = TEDesign.Text
        Report.LabelNote.Text = MENote.Text
        Report.LabelVendor.Text = TxtVendorCode.Text + " - " + TxtVendor.Text

        'Show the report's preview. 
        Dim Tool As DevExpress.XtraReports.UI.ReportPrintTool = New DevExpress.XtraReports.UI.ReportPrintTool(Report)
        Tool.ShowPreview()
        Cursor = Cursors.Default
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
    Private Sub TxtNameCompTo_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TxtNameCompTo.Validating
        EP_TE_cant_blank(EPRet, TxtNameCompTo)
        EPRet.SetIconPadding(TxtNameCompTo, 30)
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
        FormReportMark.id_report = id_pl_prod_order
        FormReportMark.report_mark_type = "33"
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
        getLimitQty()
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
        BtnAdd.Enabled = False
        BtnEdit.Enabled = False
        BtnDel.Enabled = False
        BtnInfoSrs.Enabled = False
        LEPLCategory.Enabled = False
        If action = "ins" Then
            LEPDAlloc.Enabled = False
        ElseIf action = "upd" Then
            BtnAttachment.Enabled = False
        End If
        newRowsBc()
        'allowDelete()
    End Sub

    Sub getLimitQty()
        Cursor = Cursors.WaitCursor
        Dim query As String = "CALL view_stock_prod_rec('" + id_prod_order + "', '0', '0', '0', '" + id_pl_prod_order + "','0', '" + LEPDAlloc.EditValue.ToString + "')"
        Dim dt_cek As DataTable = execute_query(query, -1, True, "", "", "", "")
        For i As Integer = 0 To ((GVRetDetail.RowCount - 1) - GetGroupRowCount(GVRetDetail))
            Dim id_prod_order_det_cekya As String = GVRetDetail.GetRowCellValue(i, "id_prod_order_det").ToString
            Dim qty_cek As Integer = GVRetDetail.GetRowCellValue(i, "pl_prod_order_det_qty")

            Dim data_filter_cek As DataRow() = dt_cek.Select("[id_prod_order_det]='" + id_prod_order_det_cekya + "' ")
            If data_filter_cek.Length <= 0 Then
                GVRetDetail.SetRowCellValue(i, "limit_qty", 0)
            Else
                Dim limit_qty As Integer = data_filter_cek(0)("qty")
                GVRetDetail.SetRowCellValue(i, "limit_qty", limit_qty)
            End If
        Next
        Cursor = Cursors.Default
    End Sub

    Private Sub BStop_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BStop.Click
        LabelDelScan.Visible = False
        TxtDeleteScan.Visible = False
        TxtDeleteScan.Text = ""
        MENote.Enabled = True
        If action = "ins" Then
            BtnBrowsePO.Enabled = True
        End If
        BtnBrowseContactFrom.Enabled = True
        BtnBrowseContactTo.Enabled = True
        BtnSave.Enabled = True
        BScan.Enabled = True
        BStop.Enabled = False
        BtnCancel.Enabled = True
        allowDelete()
        GVRetDetail.OptionsBehavior.Editable = True
        ControlBox = True
        BtnAdd.Enabled = True
        BtnEdit.Enabled = True
        BtnDel.Enabled = True
        BtnInfoSrs.Enabled = True
        LEPLCategory.Enabled = True
        If action = "ins" Then
            LEPDAlloc.Enabled = True
        ElseIf action = "upd" Then
            BtnAttachment.Enabled = True
        End If
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
    End Sub

    Private Sub BDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BDelete.Click
        BDelete.Enabled = False
        BScan.Enabled = False
        BStop.Enabled = True
        LabelDelScan.Visible = True
        TxtDeleteScan.Visible = True
        TxtDeleteScan.Text = ""
        TxtDeleteScan.Focus()
        'Dim confirm As DialogResult = DevExpress.XtraEditors.XtraMessageBox.Show("Are you sure want to delete this data?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
        'If confirm = Windows.Forms.DialogResult.Yes Then
        '    Dim id_prod_order_det As String = GVBarcode.GetFocusedRowCellValue("id_prod_order_det").ToString
        '    deleteRowsBc()
        '    If id_prod_order_det <> "" Or id_prod_order_det <> Nothing Then
        '        GVBarcode.ApplyFindFilter("")
        '        'GVBarcode.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Default
        '        countQty(id_prod_order_det)
        '    End If
        '    allowDelete()
        'End If
    End Sub

    Private Sub GVBarcode_HiddenEditor(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GVBarcode.HiddenEditor
        Dim code_check As String = GVBarcode.GetFocusedRowCellValue("code").ToString
        Dim code_found As Boolean = False
        Dim code_duplicate As Boolean = False
        Dim id_prod_order_det As String = ""
        Dim counting_code As String = ""
        Dim index_atas As Integer = 0
        Dim is_old As String = "0"
        Dim jum_scan As Integer = 0
        Dim jum_limit As Integer = 0

        'check available code
        Dim dt_filter As DataRow() = dt.Select("[product_full_code]='" + code_check + "' ")
        If dt_filter.Length > 0 Then
            counting_code = dt_filter(0)("product_counting_code").ToString
            id_prod_order_det = dt_filter(0)("id_prod_order_det").ToString
            is_old = dt_filter(0)("is_old_design").ToString
            code_found = True
        End If

        If is_old = "1" Then
            GVRetDetail.FocusedRowHandle = find_row(GVRetDetail, "id_prod_order_det", id_prod_order_det)
            If GVRetDetail.GetFocusedRowCellValue("pl_prod_order_det_qty") >= GVRetDetail.GetFocusedRowCellValue("limit_qty") Then
                GVBarcode.SetRowCellValue(GVBarcode.RowCount - 1, "code", "")
                GVBarcode.FocusedRowHandle = GVBarcode.RowCount - 1
                stopCustom("Can't scan. Maximum qty for size " + GVRetDetail.GetFocusedRowCellValue("size").ToString + " :  " + GVRetDetail.GetFocusedRowCellValue("limit_qty").ToString)
            Else
                GVBarcode.SetFocusedRowCellValue("id_pl_prod_order_det_unique", "0")
                GVBarcode.SetFocusedRowCellValue("is_fix", "2")
                GVBarcode.SetFocusedRowCellValue("id_prod_order_det", id_prod_order_det)
                GVBarcode.SetFocusedRowCellValue("counting_code", counting_code)
                countQty(id_prod_order_det)
                newRowsBc()
            End If
        ElseIf is_old = "2" Then
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
                GVRetDetail.FocusedRowHandle = find_row(GVRetDetail, "id_prod_order_det", id_prod_order_det)
                If GVRetDetail.GetFocusedRowCellValue("pl_prod_order_det_qty") >= GVRetDetail.GetFocusedRowCellValue("limit_qty") Then
                    GVBarcode.SetRowCellValue(GVBarcode.RowCount - 1, "code", "")
                    GVBarcode.FocusedRowHandle = GVBarcode.RowCount - 1
                    stopCustom("Can't scan. Maximum qty for size " + GVRetDetail.GetFocusedRowCellValue("size").ToString + " :  " + GVRetDetail.GetFocusedRowCellValue("limit_qty").ToString)
                Else
                    GVBarcode.SetFocusedRowCellValue("id_pl_prod_order_det_unique", "0")
                    GVBarcode.SetFocusedRowCellValue("is_fix", "2")
                    GVBarcode.SetFocusedRowCellValue("id_prod_order_det", id_prod_order_det)
                    GVBarcode.SetFocusedRowCellValue("counting_code", counting_code)
                    countQty(id_prod_order_det)
                    newRowsBc()
                End If
            End If
        Else
            GVBarcode.SetFocusedRowCellValue("code", "")
            stopCustom("Data not found !")
        End If
    End Sub

    Private Sub GVBarcode_CellValueChanged(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles GVBarcode.CellValueChanged
        'MsgBox(GVBarcode.GetFocusedRowCellValue("code").ToString)
        'GVBarcode.AddNewRow()
        'MsgBox("k")
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
            'MsgBox(id_prod_order_rec_det)
            If is_fix <> "2" Then
                GridColumnBarcode.OptionsColumn.AllowEdit = True
            Else
                GridColumnBarcode.OptionsColumn.AllowEdit = False
            End If
            'MsgBox(id_prod_order_rec_det)
        Catch ex As Exception
            'errorCustom(ex.ToString)
        End Try
    End Sub

    Private Sub GVBarcode_FocusedRowChanged(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles GVBarcode.FocusedRowChanged
        noEdit()
    End Sub

    Sub countQty(ByVal id_prod_order_detx As String)
        Dim tot As Decimal = 0.0
        For i As Integer = 0 To GVBarcode.RowCount - 1
            Dim id_prod_order_det As String = GVBarcode.GetRowCellValue(i, "id_prod_order_det").ToString
            If id_prod_order_det = id_prod_order_detx Then
                tot = tot + 1.0
            End If
        Next
        GVRetDetail.FocusedRowHandle = find_row(GVRetDetail, "id_prod_order_det", id_prod_order_detx)
        GVRetDetail.SetFocusedRowCellValue("pl_prod_order_det_qty", tot)
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
    Sub isAllowRequisition(ByVal sample_name As String, ByVal id_prod_order_det_cek As String, ByVal qty_plx As String)
        cond_check = True
        qty_pl = Decimal.Parse(qty_plx.ToString)
        sample_check = sample_name
        'MsgBox(id_prod_order_det_cek)
        Dim query_check As String = "CALL view_stock_prod_rec('" + id_prod_order + "', '" + id_prod_order_det_cek + "', '0', '0', '" + id_pl_prod_order + "', '0', '" + LEPDAlloc.EditValue.ToString + "') "
        Dim data As DataTable = execute_query(query_check, -1, True, "", "", "", "")
        allow_sum = Decimal.Parse(data.Rows(0)("qty"))
        If qty_pl > allow_sum Then
            cond_check = False
        End If
    End Sub

    Sub infoQty()
        FormPopUpProdDet.id_pop_up = "3"
        FormPopUpProdDet.action = "ins"
        FormPopUpProdDet.id_prod_order = id_prod_order
        FormPopUpProdDet.LabelControlAlloc.Visible = True
        FormPopUpProdDet.LabelControlAlloc.Text = "Allocation : " + LEPDAlloc.Text.ToString
        FormPopUpProdDet.id_pd_alloc_par = LEPDAlloc.EditValue.ToString
        FormPopUpProdDet.id_pl = id_pl_prod_order
        FormPopUpProdDet.BtnSave.Visible = False
        FormPopUpProdDet.is_info_form = True
        FormPopUpProdDet.ShowDialog()
    End Sub

    Private Sub PEView_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PEView.DoubleClick
        pre_viewImages("2", PEView, id_design, True)
    End Sub

    Private Sub SimpleButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SimpleButton1.Click
        For i As Integer = 0 To dt.Rows.Count - 1
            MsgBox(dt.Rows(i)("product_counting_code").ToString)
        Next
    End Sub

    Private Sub BtnAttachment_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnAttachment.Click
        Cursor = Cursors.WaitCursor
        FormDocumentUpload.id_report = id_pl_prod_order
        FormDocumentUpload.report_mark_type = "33"
        FormDocumentUpload.ShowDialog()
        Cursor = Cursors.Default
    End Sub

    Private Sub LEPDAlloc_EditValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LEPDAlloc.EditValueChanged
        Cursor = Cursors.WaitCursor
        TxtOrderNumber.Text = ""
        id_design = "-1"
        TEDesign.Text = ""
        GCRetDetail.DataSource = Nothing
        GCBarcode.DataSource = Nothing
        BtnInfoSrs.Enabled = False
        BtnViewLineList.Enabled = False
        GroupControlRet.Enabled = False
        GroupControlListBarcode.Enabled = False
        Cursor = Cursors.Default
    End Sub

    Private Sub BtnViewLineList_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnViewLineList.Click
        Cursor = Cursors.WaitCursor
        FormFGLineList.id_pop_up = "1"
        FormFGLineList.PanelControlNavLineListBottom.Visible = False
        FormFGLineList.Width = 800
        FormFGLineList.Height = 450
        FormFGLineList.ShowDialog()
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
            GridColumnQty.VisibleIndex = 1
            GridColumnNumber.VisibleIndex = 2
            GridColumnFrom.VisibleIndex = 3
            GridColumnTo.VisibleIndex = 4
            GridColumnRemark.VisibleIndex = 5
            GVRetDetail.OptionsPrint.PrintFooter = False
            GVRetDetail.OptionsPrint.PrintHeader = False


            'export excel
            Dim path_root As String = ""
            Try
                ' Open the file using a stream reader.
                Using sr As New IO.StreamReader(Application.StartupPath & "\pro_path.txt")
                    ' Read the stream to a string and write the string to the console.
                    path_root = sr.ReadToEnd()
                End Using
            Catch ex As Exception
            End Try

            Dim fileName As String = bof_xls + ".xls"
            Dim exp As String = IO.Path.Combine(path_root, fileName)
            Try
                ExportToExcel(GVRetDetail, exp, show_msg)
            Catch ex As Exception
                stopCustom("Please close your excel file first then try again later")
            End Try

            'show column
            GridColumnNox.VisibleIndex = 0
            GridColumnCode.VisibleIndex = 1
            GridColumnEanCode.VisibleIndex = 2
            GridColumnName.VisibleIndex = 3
            GridColumnSize.VisibleIndex = 4
            GridColumnQty.VisibleIndex = 5
            GridColumnRemark.VisibleIndex = 6
            GridColumnNumber.Visible = False
            GridColumnFrom.Visible = False
            GridColumnTo.Visible = False
            GVRetDetail.OptionsPrint.PrintFooter = True
            GVRetDetail.OptionsPrint.PrintHeader = True
            Cursor = Cursors.Default
        End If
    End Sub

    Private Sub GVRetDetail_CustomUnboundColumnData(sender As Object, e As DevExpress.XtraGrid.Views.Base.CustomColumnDataEventArgs) Handles GVRetDetail.CustomUnboundColumnData
        Dim view As DevExpress.XtraGrid.Views.Grid.GridView = TryCast(sender, DevExpress.XtraGrid.Views.Grid.GridView)
        If e.Column.FieldName = "from" AndAlso e.IsGetData Then
            e.Value = TxtCodeCompFrom.Text.ToString
        ElseIf e.Column.FieldName = "to" AndAlso e.IsGetData Then
            e.Value = TxtCodeCompTo.Text.ToString
        ElseIf e.Column.FieldName = "number" AndAlso e.IsGetData Then
            e.Value = TxtRetOutNumber.Text.ToString
        End If
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
                Dim id_pl_prod_order_del_det_counting As String = "-1"
                Try
                    id_pl_prod_order_del_det_counting = GVBarcode.GetFocusedRowCellValue("id_pl_prod_order_del_det_counting").ToString
                Catch ex As Exception
                End Try

                If action = "ins" Then
                    Dim confirm As DialogResult = DevExpress.XtraEditors.XtraMessageBox.Show("Are you sure want to delete this data?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
                    If confirm = Windows.Forms.DialogResult.Yes Then
                        Dim id_prod_order_det As String = GVBarcode.GetFocusedRowCellValue("id_prod_order_det").ToString
                        deleteRowsBc()
                        If id_prod_order_det <> "" Or id_prod_order_det <> Nothing Then
                            GVBarcode.ActiveFilterString = ""
                            countQty(id_prod_order_det)
                        End If
                        GCRetDetail.RefreshDataSource()
                        GVRetDetail.RefreshData()
                        allowDelete()
                    Else
                        GVBarcode.ActiveFilterString = ""
                    End If
                    TxtDeleteScan.Text = ""
                    TxtDeleteScan.Focus()
                ElseIf action = "upd" Then
                    If id_pl_prod_order_del_det_counting = "0" Then
                        Dim confirm As DialogResult = DevExpress.XtraEditors.XtraMessageBox.Show("Are you sure want to delete this data?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
                        If confirm = Windows.Forms.DialogResult.Yes Then
                            Dim id_prod_order_det As String = GVBarcode.GetFocusedRowCellValue("id_prod_order_det").ToString
                            deleteRowsBc()
                            If id_prod_order_det <> "" Or id_prod_order_det <> Nothing Then
                                GVBarcode.ActiveFilterString = ""
                                countQty(id_prod_order_det)
                            End If
                            GCRetDetail.RefreshDataSource()
                            GVRetDetail.RefreshData()
                            allowDelete()
                        Else
                            GVBarcode.ActiveFilterString = ""
                        End If
                    Else
                        errorCustom("This data already locked and can't delete.")
                        GVBarcode.ActiveFilterString = ""
                    End If
                    TxtDeleteScan.Text = ""
                    TxtDeleteScan.Focus()
                End If
            End If
            Cursor = Cursors.Default
        End If
    End Sub

    Private Sub ExportToExcel(ByVal dtTemp As DevExpress.XtraGrid.Views.Grid.GridView, ByVal filepath As String, show_msg As Boolean)
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
                ElseIf j = 1 Then
                    wSheet.Cells(rowIndex + 1, colIndex) = dtTemp.GetRowCellValue(i, "pl_prod_order_det_qty")
                ElseIf j = 2 Then
                    wSheet.Cells(rowIndex + 1, colIndex) = dtTemp.GetRowCellDisplayText(i, "number").ToString
                ElseIf j = 3 Then
                    wSheet.Cells(rowIndex + 1, colIndex) = dtTemp.GetRowCellDisplayText(i, "from").ToString
                ElseIf j = 4 Then
                    wSheet.Cells(rowIndex + 1, colIndex) = dtTemp.GetRowCellDisplayText(i, "to").ToString
                Else
                    wSheet.Cells(rowIndex + 1, colIndex) = dtTemp.GetRowCellValue(i, "pl_prod_order_det_note").ToString
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
End Class