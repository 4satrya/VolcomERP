Public Class FormViewMatRecPurc
    Public id_order As String = "-1"
    Public id_receive As String = "-1"
    Public id_comp_from As String = "-1"
    Public id_comp_to As String = "-1"
    Dim sample_purc_rec_det_qty_inp As Decimal

    Private Sub FormViewMatRecPurc_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        viewComp()
        view_report_status(LEReportStatus)

        Dim order_created As String
        Dim query = "SELECT a.id_report_status,a.mat_purc_rec_note,b.id_comp_contact_to as id_comp_from,b.id_mat_purc,a.id_comp_contact_to as id_comp_to,g.season,a.id_mat_purc_rec,a.mat_purc_rec_number,DATE_FORMAT(b.mat_purc_date,'%Y-%m-%d') as mat_purc_datex,b.mat_purc_lead_time,a.delivery_order_date,a.delivery_order_number,b.mat_purc_number,DATE_FORMAT(a.mat_purc_rec_date,'%Y-%m-%d') AS mat_purc_rec_date, f.comp_name AS comp_from,d.comp_name AS comp_to "
        query += ",drw.id_wh_drawer,rck.id_wh_rack,loc.id_wh_locator,comp.id_comp "
        query += "FROM tb_mat_purc_rec a INNER JOIN tb_mat_purc b ON a.id_mat_purc=b.id_mat_purc "
        query += "INNER JOIN tb_m_comp_contact c ON c.id_comp_contact=a.id_comp_contact_to "
        query += "INNER JOIN tb_m_comp d ON d.id_comp=c.id_comp "
        query += "INNER JOIN tb_m_comp_contact e ON e.id_comp_contact=b.id_comp_contact_to "
        query += "INNER JOIN tb_m_comp f ON f.id_comp=e.id_comp "
        query += "INNER JOIN tb_season_delivery h ON b.id_delivery=h.id_delivery "
        query += "INNER JOIN tb_season g ON g.id_season=h.id_season "
        query += "LEFT JOIN tb_m_wh_drawer drw ON drw.id_wh_drawer = a.id_wh_drawer "
        query += "LEFT JOIN tb_m_wh_rack rck ON rck.id_wh_rack = drw.id_wh_rack "
        query += "LEFT JOIN tb_m_wh_locator loc ON loc.id_wh_locator = rck.id_wh_locator "
        query += "LEFT JOIN tb_m_comp comp ON comp.id_comp = loc.id_comp WHERE a.id_mat_purc_rec='" & id_receive & "'"

        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")

        Try
            SLEStorage.EditValue = data.Rows(0)("id_comp").ToString
            SLELocator.EditValue = data.Rows(0)("id_wh_locator").ToString
            SLERack.EditValue = data.Rows(0)("id_wh_rack").ToString
            SLEDrawer.EditValue = data.Rows(0)("id_wh_drawer").ToString
        Catch ex As Exception
        End Try

        TEPONumber.Text = data.Rows(0)("mat_purc_number").ToString
        TEDONumber.Text = data.Rows(0)("delivery_order_number").ToString
        TERecNumber.Text = data.Rows(0)("mat_purc_rec_number").ToString

        id_order = data.Rows(0)("id_mat_purc").ToString
        id_comp_from = data.Rows(0)("id_comp_from").ToString
        TECompName.Text = data.Rows(0)("comp_from").ToString
        id_comp_to = data.Rows(0)("id_comp_to").ToString
        TECompShipToName.Text = data.Rows(0)("comp_to").ToString

        order_created = data.Rows(0)("mat_purc_datex").ToString
        TEOrderDate.Text = view_date_from(order_created, 0)
        TEEstRecDate.Text = view_date_from(order_created, Integer.Parse(data.Rows(0)("mat_purc_lead_time").ToString))

        TERecDate.Text = view_date_from(data.Rows(0)("mat_purc_rec_date").ToString, 0)

        Dim tgl_delivery() As String = data.Rows(0)("delivery_order_date").ToString.Split(" ")
        TEDODate.Text = tgl_delivery(0)

        LEReportStatus.EditValue = Nothing
        LEReportStatus.ItemIndex = LEReportStatus.Properties.GetDataSourceRowIndex("id_report_status", data.Rows(0)("id_report_status").ToString)

        MENote.Text = data.Rows(0)("mat_purc_rec_note").ToString

        GConListPurchase.Enabled = True

        TERecNumber.Enabled = False
        view_list_rec()
        view_list_pcs()

    End Sub
    Sub view_list_pcs()
        Dim query = "CALL view_purc_rec_mat_det_pcs('" & id_receive & "')"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCRoll.DataSource = data
        calculate_qty_rec()
    End Sub
    Sub calculate_qty_rec()
        If GVListPurchase.RowCount > 0 Then
            For i As Integer = 0 To GVListPurchase.RowCount - 1
                Dim qty_rec As Decimal = 0.0
                For j As Integer = 0 To GVRoll.RowCount - 1
                    If GVListPurchase.GetRowCellValue(i, "id_mat_det").ToString = GVRoll.GetRowCellValue(j, "id_mat_det").ToString Then
                        qty_rec += GVRoll.GetRowCellValue(j, "qty").ToString
                    End If
                Next
                GVListPurchase.SetRowCellValue(i, "rec_qty", qty_rec)
            Next
        End If
    End Sub
    'view company
    Sub viewComp()
        Dim query As String = "SELECT * FROM tb_m_comp a "
        query += "INNER JOIN tb_m_comp_cat b ON a.id_comp_cat = b.id_comp_cat "
        query += "INNER JOIN tb_m_wh_locator c ON a.id_comp = c.id_comp "
        query += "INNER JOIN tb_m_wh_rack d ON c.id_wh_locator = d.id_wh_locator "
        query += "INNER JOIN tb_m_wh_drawer e ON e.id_wh_rack = d.id_wh_rack "
        query += "GROUP BY a.id_comp ORDER BY comp_number ASC "
        viewSearchLookupQuery(SLEStorage, query, "id_comp", "comp_name", "id_comp")
    End Sub
    'Rekursif Comp-Locator
    Private Sub SLEStorage_EditValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SLEStorage.EditValueChanged
        viewLoactor()
    End Sub
    Private Sub SLELocator_EditValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SLELocator.EditValueChanged
        viewRack()
    End Sub
    Private Sub SLERack_EditValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SLERack.EditValueChanged
        viewDrawer()
    End Sub
    'View Locator
    Sub viewLoactor()
        Dim id_comp As String = ""
        Try
            id_comp = SLEStorage.EditValue.ToString
        Catch ex As Exception
            id_comp = "-1"
        End Try
        Dim query As String = ""
        query = "SELECT * FROM tb_m_wh_locator a WHERE id_comp = '" + id_comp + "'"
        viewSearchLookupQuery(SLELocator, query, "id_wh_locator", "wh_locator", "id_wh_locator")
    End Sub
    'View Rack
    Sub viewRack()
        Dim id_locator As String = ""
        Try
            id_locator = SLELocator.EditValue.ToString
        Catch ex As Exception
            id_locator = "-1"
        End Try
        Dim query As String = "SELECT * FROM tb_m_wh_rack a WHERE id_wh_locator = '" + id_locator + "'"
        viewSearchLookupQuery(SLERack, query, "id_wh_rack", "wh_rack", "id_wh_rack")
    End Sub
    'View Drawer
    Sub viewDrawer()
        Dim id_rack As String = ""
        Try
            id_rack = SLERack.EditValue.ToString
        Catch ex As Exception
            id_rack = "-1"
        End Try
        Dim query As String = "SELECT * FROM tb_m_wh_drawer a WHERE id_wh_rack = '" + id_rack + "'"
        viewSearchLookupQuery(SLEDrawer, query, "id_wh_drawer", "wh_drawer", "id_wh_drawer")
    End Sub

    Sub view_po()
        Dim query As String = String.Format("SELECT id_report_status,mat_purc_vat,id_season,mat_purc_number,id_comp_contact_to,id_comp_contact_ship_to,id_po_type,id_payment,DATE_FORMAT(mat_purc_date,'%Y-%m-%d') as mat_purc_datex,mat_purc_lead_time,mat_purc_top,id_currency,mat_purc_note FROM tb_mat_purc WHERE id_mat_purc = '{0}'", id_order)
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")

        TEPONumber.Text = data.Rows(0)("mat_purc_number").ToString

        id_comp_from = data.Rows(0)("id_comp_contact_to").ToString
        TECompName.Text = get_company_x(get_id_company(data.Rows(0)("id_comp_contact_to").ToString), "1")

        TEOrderDate.Text = view_date_from(data.Rows(0)("sample_purc_datex").ToString, 0)
        TEEstRecDate.Text = view_date_from(data.Rows(0)("sample_purc_datex").ToString, Integer.Parse(data.Rows(0)("sample_purc_lead_time").ToString))
    End Sub

    Sub view_list_rec()
        Dim query = "CALL view_purc_rec_mat_det('" & id_receive & "')"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCListPurchase.DataSource = data
    End Sub

    Sub view_list_purchase()
        Dim query = "CALL view_purc_mat_det_limit('" & id_order & "')"
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

    Private Sub BMark_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BMark.Click
        FormReportMark.id_report = id_receive
        FormReportMark.is_view = "1"
        FormReportMark.report_mark_type = "16"
        FormReportMark.ShowDialog()
    End Sub

    Private Sub GVListPurchase_CustomColumnDisplayText(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs) Handles GVListPurchase.CustomColumnDisplayText
        If e.Column.FieldName = "no" Then
            e.DisplayText = (e.ListSourceRowIndex + 1).ToString()
        End If
    End Sub

    Private Sub Battach_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Battach.Click
        Cursor = Cursors.WaitCursor
        FormDocumentUpload.id_report = id_receive
        FormDocumentUpload.is_view = "1"
        FormDocumentUpload.report_mark_type = "16"
        FormDocumentUpload.ShowDialog()
        Cursor = Cursors.Default
    End Sub
    Private Sub GVRoll_CustomColumnDisplayText(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs) Handles GVRoll.CustomColumnDisplayText
        If e.Column.FieldName = "no" Then
            e.DisplayText = (e.ListSourceRowIndex + 1).ToString()
        End If
    End Sub
End Class