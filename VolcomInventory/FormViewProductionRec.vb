Public Class FormViewProductionRec 
    Public id_order As String = "-1"
    Public id_receive As String = "-1"
    Public id_comp_from As String = "-1"
    Public id_comp_to As String = "-1"
    Public id_design As String = "-1"
    Dim sample_purc_rec_det_qty_inp As Decimal
    Dim myList(,) As String
    Dim is_start As Boolean = False


    Private Sub FormProductionRecDet_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If Not id_order = "-1" Then
            view_list_purchase()
            view_po()
            GConListPurchase.Enabled = True
        End If

        view_report_status(LEReportStatus)

        Dim order_created As String
        Dim query = "SELECT j.id_design,IF(a.delivery_order_date<>'0000-00-00', 'date_normal','date_null') as del_date_type, i.id_sample, (i.design_display_name) AS `design_name`, a.id_report_status,a.prod_order_rec_note,a.id_comp_contact_from as id_comp_from,b.id_prod_order,a.id_comp_contact_to as id_comp_to,g.season,a.id_prod_order_rec,a.prod_order_rec_number,DATE_FORMAT(b.prod_order_date,'%Y-%m-%d') as prod_order_datex,b.prod_order_lead_time,a.delivery_order_date,a.delivery_order_number, a.arrive_date,b.prod_order_number,DATE_FORMAT(a.prod_order_rec_date,'%Y-%m-%d') AS prod_order_rec_date, f.comp_name AS comp_from, f.comp_number AS comp_from_number,d.comp_name AS comp_to, d.comp_number AS comp_to_number, i.id_sample, po_type.po_type "
        query += "FROM tb_prod_order_rec a "
        query += "INNER JOIN tb_prod_order b ON a.id_prod_order=b.id_prod_order "
        query += "INNER JOIN tb_m_comp_contact c ON c.id_comp_contact=a.id_comp_contact_to "
        query += "INNER JOIN tb_m_comp d ON d.id_comp=c.id_comp "
        query += "INNER JOIN tb_m_comp_contact e ON e.id_comp_contact=a.id_comp_contact_from "
        query += "INNER JOIN tb_m_comp f ON f.id_comp=e.id_comp "
        query += "INNER JOIN tb_season_delivery h ON b.id_delivery=h.id_delivery "
        query += "INNER JOIN tb_season g ON g.id_season=h.id_season "
        query += "INNER JOIN tb_prod_demand_design j ON b.id_prod_demand_design = j.id_prod_demand_design "
        query += "INNER JOIN tb_m_design i ON j.id_design = i.id_design "
        query += "INNER JOIN tb_lookup_po_type po_type ON po_type.id_po_type = b.id_po_type "
        query += " WHERE a.id_prod_order_rec='" & id_receive & "' "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")

        TEPONumber.Text = data.Rows(0)("prod_order_number").ToString
        TxtPOType.Text = data.Rows(0)("po_type").ToString
        TEDONumber.Text = data.Rows(0)("delivery_order_number").ToString
        TERecNumber.Text = data.Rows(0)("prod_order_rec_number").ToString

        id_design = data.Rows(0)("id_design").ToString
        id_order = data.Rows(0)("id_prod_order").ToString
        id_comp_from = data.Rows(0)("id_comp_from").ToString
        TECompName.Text = data.Rows(0)("comp_from").ToString
        id_comp_to = data.Rows(0)("id_comp_to").ToString
        TECompShipToName.Text = data.Rows(0)("comp_to").ToString

        order_created = data.Rows(0)("prod_order_datex").ToString
        TEOrderDate.Text = view_date_from(order_created, 0)
        TEEstRecDate.Text = view_date_from(order_created, Integer.Parse(data.Rows(0)("prod_order_lead_time").ToString))

        TERecDate.Text = view_date_from(data.Rows(0)("prod_order_rec_date").ToString, 0)

        Dim tgl_delivery() As String = data.Rows(0)("delivery_order_date").ToString.Split(" ")
        'TEDODate.Text = tgl_delivery(0)


        If data.Rows(0)("del_date_type") = "date_normal" Then
            TEDODate.EditValue = data.Rows(0)("delivery_order_date")
        End If

        DEArrive.EditValue = data.Rows(0)("arrive_date")

        LEReportStatus.EditValue = Nothing
        LEReportStatus.ItemIndex = LEReportStatus.Properties.GetDataSourceRowIndex("id_report_status", data.Rows(0)("id_report_status").ToString)

        MENote.Text = data.Rows(0)("prod_order_rec_note").ToString
        pre_viewImages("2", PEView, id_design, False)
        TEDesign.Text = data.Rows(0)("design_name").ToString

        GConListPurchase.Enabled = True
        PEView.Enabled = True

        TERecNumber.Enabled = False
        view_list_rec()
        allow_status()
    End Sub

    Sub view_po()
        Dim query As String = String.Format("SELECT id_report_status,prod_order_vat,prod_order_number,id_comp_contact_to,id_comp_contact_ship_to,id_po_type,id_payment,DATE_FORMAT(prod_order_date,'%Y-%m-%d') as prod_order_datex,prod_order_lead_time,prod_order_top,id_currency,prod_order_note FROM tb_prod_order WHERE id_prod_order = '{0}'", id_order)
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")

        TEPONumber.Text = data.Rows(0)("prod_order_number").ToString

        id_comp_from = data.Rows(0)("id_comp_contact_to").ToString
        TECompName.Text = get_company_x(get_id_company(data.Rows(0)("id_comp_contact_to").ToString), "1")
        TECompShipToName.Text = get_company_x(get_id_company(data.Rows(0)("id_comp_contact_ship_to").ToString), "1")

        TEOrderDate.Text = view_date_from(data.Rows(0)("prod_order_datex").ToString, 0)
        TEEstRecDate.Text = view_date_from(data.Rows(0)("prod_order_datex").ToString, Integer.Parse(data.Rows(0)("prod_order_lead_time").ToString))
    End Sub

    Sub view_list_rec()
        Dim query = "CALL view_prod_order_rec_det('" + id_receive + "', '0')"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCListPurchase.DataSource = data
    End Sub

    Sub view_barcode_list()
        'Dim query As String = "SELECT ('0') AS no, ('') AS ean_code, ('0') AS id_prod_order_det, ('1') AS is_fix "
        'Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        'GCBarcode.DataSource = data
        'deleteRows()
    End Sub

    Sub view_list_purchase()
        Dim query = "CALL view_prod_order_det('" & id_order & "', '0')"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCListPurchase.DataSource = data
    End Sub

    Sub view_report_status(ByVal lookup As DevExpress.XtraEditors.LookUpEdit)
        Dim query As String = "SELECT id_report_status,report_status FROM tb_lookup_report_status"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")

        lookup.Properties.DataSource = data

        lookup.Properties.DisplayMember = "report_status"
        lookup.Properties.ValueMember = "id_report_status"
        lookup.ItemIndex = 0
    End Sub

    Private Sub TERecNumber_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TERecNumber.Validating
      
    End Sub

    Private Sub FormSampleReceiveDet_FormClosed(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub BMark_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BMark.Click
        Cursor = Cursors.WaitCursor
        FormReportMark.id_report = id_receive
        FormReportMark.report_mark_type = "28"
        FormReportMark.is_view = "1"
        FormReportMark.form_origin = Name
        FormReportMark.ShowDialog()
        Cursor = Cursors.Default
    End Sub

    Sub allow_status()
        TEDODate.Properties.ReadOnly = True
        DEArrive.Properties.ReadOnly = True
        TEDONumber.Properties.ReadOnly = True
        MENote.Properties.ReadOnly = True
        GVListPurchase.OptionsBehavior.Editable = False
    End Sub

    Private Sub GVListPurchase_ShownEditor(ByVal sender As System.Object, ByVal e As System.EventArgs)
        'Try
        '    sample_purc_rec_det_qty_inp = GVListPurchase.GetFocusedRowCellDisplayText("prod_order_rec_det_qty").ToString
        'Catch ex As Exception
        'End Try
    End Sub

    Private Sub GVListPurchase_CustomColumnDisplayText(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs)
        If e.Column.FieldName = "no" Then
            e.DisplayText = (e.ListSourceRowIndex + 1).ToString()
        End If
    End Sub
    'Cell Value Changed to resrict qty
    Private Sub RepositoryItemSpinEdit1_EditValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        'Try
        '    Dim sqty As DevExpress.XtraEditors.SpinEdit = CType(sender, DevExpress.XtraEditors.SpinEdit)
        '    Dim qty_limit As Decimal = CType(GVListPurchase.GetFocusedRowCellDisplayText("qty").ToString, Decimal)
        '    Dim qty_rec As Decimal = CType(sqty.EditValue.ToString, Decimal)
        '    If (qty_rec > qty_limit) Then
        '        DevExpress.XtraEditors.XtraMessageBox.Show("- Qty issue must be smaller than qty ordered or equal to qty ordered !" + System.Environment.NewLine + "- Not allowed character input !", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        '        Dim qty_bound As Decimal = qty_rec - 1
        '        If qty_bound < 0 Then
        '            qty_bound = 0
        '        End If
        '        GVListPurchase.SetFocusedRowCellValue("prod_order_rec_det_qty", qty_limit.ToString)
        '    End If
        'Catch ex As Exception
        'End Try
    End Sub

    Private Sub GroupGeneralHeader_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles GroupGeneralHeader.Paint

    End Sub

    Private Sub PEView_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PEView.DoubleClick
        pre_viewImages("2", PEView, id_design, True)
    End Sub

    Private Sub GVListPurchase_CustomColumnDisplayText_1(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs) Handles GVListPurchase.CustomColumnDisplayText
        If e.Column.FieldName = "no" Then
            e.DisplayText = (e.ListSourceRowIndex + 1).ToString()
        End If
    End Sub

    Private Sub BtnAttachment_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnAttachment.Click
        Cursor = Cursors.WaitCursor
        FormDocumentUpload.id_report = id_receive
        FormDocumentUpload.report_mark_type = "28"
        FormDocumentUpload.is_view = "1"
        FormDocumentUpload.ShowDialog()
        Cursor = Cursors.Default
    End Sub
End Class