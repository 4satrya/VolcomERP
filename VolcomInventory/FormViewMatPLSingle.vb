Public Class FormViewMatPLSingle
    Public id_pl_mrs As String
    Public id_comp_contact_from, id_comp_from As String
    Public id_comp_contact_to, id_comp_to As String
    Public code_list, code_list_drawer, id_sample_list As New List(Of String)
    Dim id_pl_mrs_det_list As New List(Of String)
    Dim test_old As String
    Public id_report_status As String
    Public id_mrs As String = "-1"
    Public id_prod_order_mrs_det_style As String
    Dim qty_process As Decimal
    Dim based_on_srs As Boolean = False
    Public cond_check As Boolean = True
    Public mat_check As String
    Public qty_pl As Decimal
    Public allow_sum As Decimal

    Private Sub FormViewMatPLSingle_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        checkFormAccessSingle(Name) 'check access
        viewPLType() 'get PL Type
        actionLoad()
    End Sub
    'View PL Type
    Sub viewPLType()
        Dim query As String = "SELECT id_pl_mat_type,pl_mat_type FROM tb_pl_mat_type a ORDER BY a.id_pl_mat_Type "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        viewLookupQuery(LEPLType, query, 0, "pl_mat_type", "id_pl_mat_type")
    End Sub

    Sub actionLoad()
        BtnInfoSrs.Enabled = True
        'Fetch from db main
        Dim query As String = "SELECT a.id_pl_mat_type,i.prod_order_mrs_number,a.id_prod_order_mrs, a.id_pl_mrs ,a.id_comp_contact_from , a.id_comp_contact_to,a.pl_mrs_date, a.pl_mrs_note, a.pl_mrs_number, (d.comp_name) AS comp_name_from, (d.comp_number) AS comp_code_from, (d.id_comp) AS id_comp_from, (f.comp_name) AS comp_name_to, (f.comp_number) AS comp_code_to, (f.id_comp) AS id_comp_to,(f.address_primary) AS comp_address_t, a.id_report_status, "
        query += "DATE_FORMAT(a.pl_mrs_date,'%Y-%m-%d') as pl_mrs_datex "
        query += "FROM tb_pl_mrs a "
        query += "INNER JOIN tb_m_comp_contact c ON a.id_comp_contact_from = c.id_comp_contact "
        query += "INNER JOIN tb_m_comp d ON c.id_comp = d.id_comp "
        query += "INNER JOIN tb_m_comp_contact e ON a.id_comp_contact_to = e.id_comp_contact "
        query += "INNER JOIN tb_m_comp f ON e.id_comp = f.id_comp "
        query += "INNER JOIN tb_prod_order_mrs i ON a.id_prod_order_mrs = i.id_prod_order_mrs "
        query += "LEFT JOIN tb_prod_order k ON i.id_prod_order = k.id_prod_order "
        query += "WHERE a.id_pl_mrs = '" + id_pl_mrs + "' "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")

        'tampung ke form
        TxtSRSNumber.Text = data.Rows(0)("prod_order_mrs_number").ToString
        TxtCodeCompFrom.Text = data.Rows(0)("comp_code_from").ToString
        TxtNameCompFrom.Text = data.Rows(0)("comp_name_from").ToString
        id_comp_from = data.Rows(0)("id_comp_from").ToString
        TxtCodeCompTo.Text = data.Rows(0)("comp_code_to").ToString
        TxtNameCompTo.Text = data.Rows(0)("comp_name_to").ToString
        id_comp_to = data.Rows(0)("id_comp_to").ToString
        'MEAdrressCompTo.Text = data.Rows(0)("comp_address_to").ToString
        LEPLType.ItemIndex = LEPLType.Properties.GetDataSourceRowIndex("id_pl_mat_type", data.Rows(0)("id_pl_mat_type").ToString)
        TxtPLNumber.Text = data.Rows(0)("pl_mrs_number").ToString
        DEPL.Text = view_date_from(data.Rows(0)("pl_mrs_datex").ToString(), 0)
        MENote.Text = data.Rows(0)("pl_mrs_note").ToString
        id_mrs = data.Rows(0)("id_prod_order_mrs").ToString

        'Group Control
        GroupControlDetailSingle.Enabled = True
        GroupControlDrawer.Enabled = True

        'Fetch db detail
        viewFillEmptyData()
        view_list_pcs()
        '
        get_po_desg()
    End Sub

    Sub get_po_desg()
        Dim query As String = "SELECT po.prod_order_number,desg.design_code,desg.design_display_name FROM tb_pl_mrs plm
                                INNER JOIN tb_prod_order_mrs mrs ON mrs.id_prod_order_mrs=plm.id_prod_order_mrs
                                LEFT JOIN tb_prod_order po ON po.id_prod_order=mrs.id_prod_order
                                LEFT JOIN tb_prod_demand_design pdd ON pdd.id_prod_demand_design=po.id_prod_demand_design
                                LEFT JOIN tb_m_design desg ON desg.id_design=pdd.id_design
                                WHERE plm.id_pl_mrs='" & id_pl_mrs & "'"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        If data.Rows.Count > 0 Then
            TEPONumber.Text = data.Rows(0)("prod_order_number").ToString
            TEDesignCode.Text = data.Rows(0)("design_code").ToString
            TEDesignName.Text = data.Rows(0)("design_display_name").ToString
        Else
            TEPONumber.Text = "-"
            TEDesignCode.Text = "-"
            TEDesignName.Text = "-"
        End If
    End Sub

    Sub viewFillEmptyData()
        Dim query As String = "CALL view_prod_order_mrs('" + id_mrs + "')"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCDetail.DataSource = data
        viewPLSample()
        For i As Integer = 0 To (data.Rows.Count - 1)
            id_sample_list.Add(data.Rows(i)("id_mat_det").ToString)
            getAmountReq(data.Rows(i)("id_prod_order_mrs_det").ToString, False)
        Next
        GVDetail.FocusedRowHandle = 0
    End Sub
    Sub viewFillEmptyDrawer()
        Dim query As String = "SELECT ('0') AS id_pl_mrs_det, ('0') AS id_mat_det,('') AS code, ('') AS name, ('0') AS id_wh_drawer, ('') AS wh_locator, ('') AS wh_rack,  ('') AS wh_drawer, ('0') AS pl_mrs_det_qty, ('') AS pl_mrs_det_note, ('0') AS qty_all_mat, ('0') AS id_prod_order_mrs_det, ('') AS uom, ('0') AS id_wh_locator, ('0') AS id_wh_rack "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCDrawer.DataSource = data
        deleteRows()
    End Sub
    'View PL Sample
    Sub viewPLSample()
        Dim query As String = "CALL view_pl_mrs('" + id_pl_mrs + "', '1')"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        For i As Integer = 0 To (data.Rows.Count - 1)
            code_list.Add(data.Rows(i)("id_mat_det").ToString)
            code_list_drawer.Add(data.Rows(i)("id_wh_drawer").ToString)
            id_pl_mrs_det_list.Add(data.Rows(i)("id_pl_mrs_det").ToString)
        Next
        GCDrawer.DataSource = data
    End Sub

    'Row Manipulation
    Sub focusColumnCode()
        GVDrawer.FocusedColumn = GVDrawer.VisibleColumns(0)
        GVDrawer.ShowEditor()
    End Sub
    Sub newRows()
        GVDrawer.AddNewRow()
    End Sub
    Sub deleteRows()
        GVDrawer.DeleteRow(GVDrawer.FocusedRowHandle)
    End Sub
    Private Sub FormSamplePLDelSingle_FormClosed(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub BMark_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BMark.Click
        FormReportMark.id_report = id_pl_mrs
        FormReportMark.is_view = "1"
        FormReportMark.report_mark_type = "30"
        FormReportMark.form_origin = Name
        FormReportMark.ShowDialog()
    End Sub

    'Color Cell
    Public Sub test_aw(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs)
        Dim View As DevExpress.XtraGrid.Views.Grid.GridView = sender

        e.Appearance.BackColor = Color.White
        e.Appearance.BackColor2 = Color.White

        id_prod_order_mrs_det_style = GVDetail.GetFocusedRowCellValue("id_prod_order_mrs_det").ToString
        Dim id_prod_order_mrs_det_check As String = View.GetRowCellDisplayText(e.RowHandle, View.Columns("id_prod_order_mrs_det"))
        If id_prod_order_mrs_det_check = id_prod_order_mrs_det_style Then
            e.Appearance.BackColor = Color.SpringGreen
            e.Appearance.BackColor2 = Color.White
        End If
    End Sub
    Private Sub RepositoryItemSpinEdit2_EditValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            Dim SpQty As DevExpress.XtraEditors.SpinEdit = CType(sender, DevExpress.XtraEditors.SpinEdit)
            Dim qty_rec As Decimal = Decimal.Parse(SpQty.Text.ToString)
            Dim qty_limit As Decimal = Decimal.Parse(GVDrawer.GetFocusedRowCellDisplayText("qty_all_mat").ToString)
            Dim current_name As String = GVDrawer.GetFocusedRowCellDisplayText("name").ToString
            Dim current_uom As String = GVDrawer.GetFocusedRowCellDisplayText("uom").ToString
            If qty_rec > qty_limit Then
                DevExpress.XtraEditors.XtraMessageBox.Show("Material : '" + current_name + "', cannot exceed " + qty_limit.ToString + " " + current_uom + " ! ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                GVDrawer.SetFocusedRowCellValue("pl_mrs_det_qty", "0")
            End If
        Catch ex As Exception

        End Try
    End Sub
    Sub getAmountReq(ByVal id_prod_order_mrs_det As String, ByVal is_sum_req As Boolean)
        Dim qty_sum As Decimal = 0
        For i As Integer = 0 To (GVDrawer.RowCount - 1)
            Try
                Dim qty As Decimal = Decimal.Parse(GVDrawer.GetRowCellValue(i, "pl_mrs_det_qty").ToString)
                Dim id_prod_order_mrs_det_data As String = GVDrawer.GetRowCellValue(i, "id_prod_order_mrs_det").ToString
                If id_prod_order_mrs_det_data = id_prod_order_mrs_det Then
                    qty_sum = qty + qty_sum
                End If
            Catch ex As Exception

            End Try
        Next
        GVDetail.FocusedRowHandle = find_row(GVDetail, "id_prod_order_mrs_det", id_prod_order_mrs_det)
        If Not is_sum_req Then
            'MsgBox(qty_sum.ToString("N2"))
            GVDetail.SetFocusedRowCellValue("qty_real_mat", qty_sum.ToString("N2"))
        Else
            'MsgBox(qty_sum.ToString("N2"))
            Dim qty_requisition As Decimal = Decimal.Parse(GVDetail.GetFocusedRowCellDisplayText("prod_order_mrs_det_qty").ToString)
            Dim tot As Decimal = qty_requisition + qty_sum
            GVDetail.SetFocusedRowCellValue("qty_real_mat", qty_sum.ToString("N2"))
            GVDetail.SetFocusedRowCellValue("prod_order_mrs_det_qty", tot.ToString("N2"))
        End If
    End Sub
    Private Sub BtnInfoSrs_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnInfoSrs.Click
        infoSrs()
    End Sub

    Sub isAllowRequisition(ByVal mat_det_name As String, ByVal id_prod_order_mrs_det_cek As String, ByVal qty_plx As String)
        cond_check = True
        qty_pl = Decimal.Parse(qty_plx.ToString)
        qty_pl = Decimal.Parse(qty_plx.ToString)
        mat_check = mat_det_name
        Dim query_check As String = "SELECT (a.prod_order_mrs_det_qty - IFNULL(SUM(b.pl_mrs_det_qty), 0) ) AS allow_sum "
        query_check += "FROM tb_prod_order_mrs_det a "
        query_check += "LEFT JOIN tb_pl_mrs_det b ON a.id_prod_order_mrs_det = b.id_prod_order_mrs_det "
        query_check += "AND b.id_pl_mrs !='" + id_pl_mrs + "' "
        query_check += "WHERE a.id_prod_order_mrs_det = '" + id_prod_order_mrs_det_cek + "'  "
        query_check += "GROUP BY a.id_prod_order_mrs "
        allow_sum = Decimal.Parse(execute_query(query_check, 0, True, "", "", "", ""))
        If qty_pl > allow_sum Then
            cond_check = False
        End If
    End Sub

    Sub infoSrs()
        Cursor = Cursors.WaitCursor
        FormInfoMRSPord.id_mrs = id_mrs
        FormInfoMRSPord.LabelSubTitle.Text = "MRS No : " + TxtSRSNumber.Text + ""
        FormInfoMRSPord.ShowDialog()
        Cursor = Cursors.Default
    End Sub

    Private Sub RepositoryItemSpinEdit1_EditValueChanged_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RepositoryItemSpinEdit1.EditValueChanged
        Try
            Dim SpQty As DevExpress.XtraEditors.SpinEdit = CType(sender, DevExpress.XtraEditors.SpinEdit)
            Dim qty_rec As Decimal = Decimal.Parse(SpQty.Text.ToString)
            Dim qty_requisition As Decimal = Decimal.Parse(GVDrawer.GetFocusedRowCellDisplayText("prod_order_mrs_det_qty").ToString)
            Dim qty_available As Decimal = Decimal.Parse(GVDrawer.GetFocusedRowCellDisplayText("qty_all_mat").ToString)
            Dim current_name As String = GVDrawer.GetFocusedRowCellDisplayText("name").ToString
            Dim uom As String = GVDrawer.GetFocusedRowCellDisplayText("uom").ToString
            If qty_rec > qty_requisition Or qty_rec > qty_available Then
                DevExpress.XtraEditors.XtraMessageBox.Show("Error : " + vbNewLine + "- Qty cannot exceed qty requisition " + vbNewLine + "- Qty cannot exceed qty available ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                GVDrawer.SetFocusedRowCellValue("pl_mrs_det_qty", "0")
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub GVDetail_FocusedRowChanged(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles GVDetail.FocusedRowChanged
        AddHandler GVDrawer.RowCellStyle, AddressOf test_aw
        GCDrawer.RefreshDataSource()
        GVDrawer.RefreshData()
    End Sub

    Private Sub GVDetail_RowClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Grid.RowClickEventArgs) Handles GVDetail.RowClick
        AddHandler GVDrawer.RowCellStyle, AddressOf test_aw
        GCDrawer.RefreshDataSource()
        GVDrawer.RefreshData()
    End Sub

    Private Sub BAttach_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BAttach.Click
        Cursor = Cursors.WaitCursor
        FormDocumentUpload.id_report = id_pl_mrs
        FormDocumentUpload.is_view = "1"
        FormDocumentUpload.report_mark_type = "30"
        FormDocumentUpload.ShowDialog()
        Cursor = Cursors.Default
    End Sub
    '
    Sub calculate_qty_rec()
        If GVDetail.RowCount > 0 Then
            For i As Integer = 0 To GVDrawer.RowCount - 1
                Dim qty_rec As Decimal = 0.0
                Dim unit_price As Decimal = 0.0

                unit_price = GVDrawer.GetRowCellValue(i, "pl_mrs_det_price")

                For j As Integer = 0 To GVRoll.RowCount - 1
                    If GVDrawer.GetRowCellValue(i, "id_mat_det_price").ToString = GVRoll.GetRowCellValue(j, "id_mat_det_price").ToString And GVDrawer.GetRowCellValue(i, "id_wh_drawer").ToString = GVRoll.GetRowCellValue(j, "id_wh_drawer").ToString Then
                        qty_rec += GVRoll.GetRowCellValue(j, "qty")
                    End If
                Next
                GVDrawer.SetRowCellValue(i, "total_price", qty_rec * unit_price)
                GVDrawer.SetRowCellValue(i, "pl_mrs_det_qty", qty_rec)
                getAmountReq(GVDrawer.GetRowCellValue(i, "id_prod_order_mrs_det").ToString, False)
            Next
        End If
    End Sub

    Sub view_list_pcs()
        Dim query = "CALL view_pl_mrs_pcs('" & id_pl_mrs & "')"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCRoll.DataSource = data
        calculate_qty_rec()
    End Sub

    Sub view_list_pcs_empty()
        Dim query = "CALL view_pl_mrs_pcs(-1)"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCRoll.DataSource = data
    End Sub

    Private Sub GVRoll_CellValueChanged(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles GVRoll.CellValueChanged
        calculate_qty_rec()
    End Sub

    Private Sub GVRoll_CustomColumnDisplayText(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs) Handles GVRoll.CustomColumnDisplayText
        If e.Column.FieldName = "no" Then
            e.DisplayText = (e.ListSourceRowIndex + 1).ToString()
        End If
    End Sub
End Class