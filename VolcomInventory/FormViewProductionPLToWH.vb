Public Class FormViewProductionPLToWH 
    Public action As String
    Public id_pl_prod_order As String = "0"
    Public id_prod_order As String = "-1"
    Public id_comp_contact_to As String
    Public id_comp_contact_from As String
    Public id_prod_order_det_list, id_pl_prod_order_det_list, id_pl_prod_order_det_unique_list As New List(Of String)
    Dim date_start As Date
    Public id_report_status As String

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

    Public id_design As String = "-1"
    Public data_code As DataTable
    Dim myListOfDogs As New List(Of String)
    Public dt As New DataTable
    Public is_use_qc_report As String = "-1"


    Public Class FileRecord
        Public Id As String
        Public Code As String
    End Class

    Private Sub FormViewProductionPLToWH_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        viewReportStatus() 'get report status
        viewPLCat()
        viewPLCatSub()
        actionLoad()

        If is_use_qc_report = "2" Then
            LECLaim.Visible = False
            LabelControl11.Visible = False
        End If
    End Sub

    Private Sub FormViewProductionPLToWH_FormClosed(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Sub actionLoad()
        'Enable/Disable
        GroupControlRet.Enabled = True
        GroupControlListBarcode.Enabled = True


        'View data
        Try
            Dim query As String = "SELECT alloc.pd_alloc, a.id_pl_category, IFNULL(a.id_pl_category_sub,0) AS `id_pl_category_sub`, h.design_name, h.id_sample, DATE_FORMAT(a.pl_prod_order_date,'%Y-%m-%d') as pl_prod_order_datex, a.id_report_status, a.id_prod_order, a.id_pl_prod_order, a.pl_prod_order_date, "
            query += "a.pl_prod_order_note, a.pl_prod_order_number,  "
            query += "g.id_design,b.prod_order_number, (c.id_comp_contact) AS id_comp_contact_from, (d.comp_name) AS comp_name_contact_from, (d.comp_number) AS comp_code_contact_from, (d.address_primary) AS comp_address_contact_from, "
            query += "(e.id_comp_contact) AS id_comp_contact_to, (f.comp_name) AS comp_name_contact_to, (f.comp_number) AS comp_code_contact_to,(f.address_primary) AS comp_address_contact_to, b.is_use_qc_report "
            query += "FROM tb_pl_prod_order a "
            query += "INNER JOIN tb_prod_order b ON a.id_prod_order = b.id_prod_order "
            query += "INNER JOIN tb_m_comp_contact c ON a.id_comp_contact_from = c.id_comp_contact "
            query += "INNER JOIN tb_m_comp d ON d.id_comp = c.id_comp "
            query += "INNER JOIN tb_m_comp_contact e ON a.id_comp_contact_to = e.id_comp_contact "
            query += "INNER JOIN tb_m_comp f ON e.id_comp = f.id_comp "
            query += "INNER JOIN tb_prod_demand_design g ON g.id_prod_demand_design = b.id_prod_demand_design "
            query += "INNER JOIN tb_m_design h ON g.id_design = h.id_design "
            query += "LEFT JOIN tb_lookup_pd_alloc alloc on alloc.id_pd_alloc = a.id_pd_alloc "
            query += "WHERE a.id_pl_prod_order='" + id_pl_prod_order + "' "
            Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
            TxtAllocation.Text = data.Rows(0)("pd_alloc").ToString
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
            LECLaim.ItemIndex = LECLaim.Properties.GetDataSourceRowIndex("id_pl_category_sub", data.Rows(0)("id_pl_category_sub").ToString)
            id_report_status = data.Rows(0)("id_report_status").ToString
            id_prod_order = data.Rows(0)("id_prod_order").ToString
            id_design = data.Rows(0)("id_design").ToString
            is_use_qc_report = data.Rows(0)("is_use_qc_report").ToString
            pre_viewImages("2", PEView, id_design, False)
            TEDesign.Text = data.Rows(0)("design_name").ToString
            PEView.Enabled = True
        Catch ex As Exception
            stopCustom(ex.ToString)
        End Try
        view_barcode_list()
        viewDetail()
        check_but()
        allowDelete()
        allow_status()
    End Sub
    Sub allow_status()
        MENote.Properties.ReadOnly = True
        DERet.Properties.ReadOnly = True
        LEPLCategory.Enabled = False
        LECLaim.Enabled = False
        BtnAttachment.Enabled = True
        TxtRetOutNumber.Focus()
    End Sub
    'sub check_but
    Sub check_but()
      
    End Sub
    'View po
    Sub view_list_po(ByVal id_prod_order As String)
      
    End Sub

    Sub view_po()
      
    End Sub

    'View Data
    Sub viewReportStatus()
        Dim query As String = "SELECT * FROM tb_lookup_report_status a ORDER BY a.id_report_status "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        viewLookupQuery(LEReportStatus, query, 0, "report_status", "id_report_status")
    End Sub

    Sub view_barcode_list()
        Dim id_pl_prod_order_det_par As String = "-1"
        Try
            id_pl_prod_order_det_par = GVRetDetail.GetFocusedRowCellValue("id_pl_prod_order_det").ToString
        Catch ex As Exception
        End Try
        Dim query As String = "SELECT ('') AS no, CONCAT(c.product_full_code, a.pl_prod_order_det_counting) AS code, "
        query += "b.id_pl_prod_order_det, (a.pl_prod_order_det_counting) AS counting_code, a.id_pl_prod_order_det_unique, ('2') AS is_fix, b.id_prod_order_det "
        query += "FROM tb_pl_prod_order_det_counting a "
        query += "INNER JOIN tb_pl_prod_order_det b ON a.id_pl_prod_order_det = b.id_pl_prod_order_det "
        query += "INNER JOIN tb_m_product c ON a.id_product = c.id_product "
        query += "WHERE a.id_pl_prod_order_det = '" + id_pl_prod_order_det_par + "' "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCBarcode.DataSource = data
    End Sub

    Sub viewDetail()
        Dim query As String = "CALL view_PL_prod('" + id_pl_prod_order + "', '0', '0')"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCRetDetail.DataSource = data
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

    'View PL Claim
    Sub viewPLCatSub()
        Dim id_cat As String = "-1"
        Try
            id_cat = LEPLCategory.EditValue.ToString
        Catch ex As Exception
        End Try
        Dim query As String = "SELECT * FROM tb_lookup_pl_category_sub a WHERE a.id_pl_category='" + id_cat + "' ORDER BY a.id_pl_category_sub ASC  "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        viewLookupQuery(LECLaim, query, 0, "pl_category_sub", "id_pl_category_sub")
    End Sub

    Sub deleteDetailBc(ByVal id_prod_order_det As String)
       
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
        FormReportMark.is_view = "1"
        FormReportMark.report_mark_type = "33"
        FormReportMark.form_origin = Name
        FormReportMark.ShowDialog()
    End Sub

    'DeleteRows
    Sub deleteRowsBc()
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


    Private Sub GVBarcode_HiddenEditor(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GVBarcode.HiddenEditor
        '' MsgBox(GVBarcode.GetFocusedRowCellValue("code").ToString)
        Dim code_check As String = GVBarcode.GetFocusedRowCellValue("code").ToString
        Dim code_found As Boolean = False
        Dim code_duplicate As Boolean = False
        Dim id_prod_order_det As String = ""
        Dim counting_code As String = ""

        'check available code
        For i As Integer = 0 To (dt.Rows.Count - 1)
            Dim code As String = dt.Rows(i)("product_full_code").ToString
            id_prod_order_det = dt.Rows(i)("id_prod_order_det").ToString
            counting_code = dt.Rows(i)("product_counting_code").ToString
            If code = code_check Then
                code_found = True
                Exit For
            End If
        Next

        'check duplicate code
        ' MsgBox(GVBarcode.RowCount.ToString)
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
            GVBarcode.SetFocusedRowCellValue("id_pl_prod_order_det_unique", "0")
            GVBarcode.SetFocusedRowCellValue("is_fix", "2")
            GVBarcode.SetFocusedRowCellValue("id_prod_order_det", id_prod_order_det)
            'MsgBox(counting_code)
            GVBarcode.SetFocusedRowCellValue("counting_code", counting_code)
            countQty(id_prod_order_det)
            newRowsBc()
            'allowDelete()
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

    End Sub

    Sub noEdit()

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
    End Sub

    Private Sub GVRetDetail_CustomColumnDisplayText(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs) Handles GVRetDetail.CustomColumnDisplayText
        If e.Column.FieldName = "no" Then
            e.DisplayText = (e.ListSourceRowIndex + 1).ToString()
        End If
    End Sub

    'check limit qty
    Sub isAllowRequisition(ByVal sample_name As String, ByVal id_prod_order_det_cek As String, ByVal qty_plx As String)
        cond_check = True
        qty_pl = Decimal.Parse(qty_plx.ToString)
        sample_check = sample_name
        'MsgBox(id_prod_order_det_cek)
        Dim query_check As String = "CALL view_stock_prod_rec('" + id_prod_order + "', '" + id_prod_order_det_cek + "', '0', '0', '" + id_pl_prod_order + "', '0', '0') "
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
        FormPopUpProdDet.id_pl = id_pl_prod_order
        FormPopUpProdDet.BtnSave.Visible = False
        FormPopUpProdDet.is_info_form = True
        FormPopUpProdDet.ShowDialog()
    End Sub

    Private Sub PEView_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PEView.DoubleClick
        pre_viewImages("2", PEView, id_design, True)
    End Sub


    Private Sub BtnAttachment_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnAttachment.Click
        Cursor = Cursors.WaitCursor
        FormDocumentUpload.id_report = id_pl_prod_order
        FormDocumentUpload.is_view = "1"
        FormDocumentUpload.report_mark_type = "33"
        FormDocumentUpload.ShowDialog()
        Cursor = Cursors.Default
    End Sub

    Private Sub LEPLCategory_EditValueChanged(sender As Object, e As EventArgs) Handles LEPLCategory.EditValueChanged
        viewPLCatSub()
    End Sub

    Private Sub GVRetDetail_FocusedRowChanged(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles GVRetDetail.FocusedRowChanged
        Cursor = Cursors.WaitCursor
        view_barcode_list()
        Cursor = Cursors.Default
    End Sub

    Private Sub GVRetDetail_ColumnFilterChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GVRetDetail.ColumnFilterChanged
        Cursor = Cursors.WaitCursor
        view_barcode_list()
        Cursor = Cursors.Default
    End Sub
End Class