Public Class FormViewSampleReceive
    Public id_order As String = "-1"
    Public id_receive As String = "-1"
    Public id_comp_from As String = "-1"
    Public id_comp_to As String = "-1"

    Private Sub FormViewSampleReceive_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        view_report_status(LEReportStatus)

        Dim order_created As String
        Dim query = "SELECT a.id_report_status,a.sample_purc_rec_note,b.id_comp_contact_to as id_comp_from,b.id_sample_purc,a.id_comp_contact_to as id_comp_to,g.season_orign,a.id_sample_purc_rec,a.sample_purc_rec_number,DATE_FORMAT(b.sample_purc_date,'%Y-%m-%d') as sample_purc_datex,b.sample_purc_lead_time,DATE_FORMAT(a.delivery_order_date,'%Y-%m-%d') AS delivery_order_date,a.delivery_order_number,b.sample_purc_number,DATE_FORMAT(a.sample_purc_rec_date,'%Y-%m-%d') AS sample_purc_rec_date, f.comp_name AS comp_from,d.comp_name AS comp_to "
        query += "FROM tb_sample_purc_rec a INNER JOIN tb_sample_purc b ON a.id_sample_purc=b.id_sample_purc "
        query += "INNER JOIN tb_m_comp_contact c ON c.id_comp_contact=a.id_comp_contact_to "
        query += "INNER JOIN tb_m_comp d ON d.id_comp=c.id_comp "
        query += "INNER JOIN tb_m_comp_contact e ON e.id_comp_contact=b.id_comp_contact_to "
        query += "INNER JOIN tb_m_comp f ON f.id_comp=e.id_comp "
        query += "INNER JOIN tb_season_orign g ON g.id_season_orign=b.id_season_orign WHERE a.id_sample_purc_rec='" & id_receive & "'"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")

        TEPONumber.Text = data.Rows(0)("sample_purc_number").ToString
        TEDONumber.Text = data.Rows(0)("delivery_order_number").ToString
        TERecNumber.Text = data.Rows(0)("sample_purc_rec_number").ToString

        id_comp_from = data.Rows(0)("id_comp_from").ToString
        TECompName.Text = data.Rows(0)("comp_from").ToString
        id_comp_to = data.Rows(0)("id_comp_to").ToString
        TECompShipToName.Text = data.Rows(0)("comp_to").ToString

        order_created = data.Rows(0)("sample_purc_datex").ToString
        TEOrderDate.Text = view_date_from(order_created, 0)
        TEEstRecDate.Text = view_date_from(order_created, Integer.Parse(data.Rows(0)("sample_purc_lead_time").ToString))

        TERecDate.Text = view_date_from(data.Rows(0)("sample_purc_rec_date").ToString, 0)
        TEDODate.Text = view_date_from(data.Rows(0)("delivery_order_date").ToString, 0)

        LEReportStatus.EditValue = Nothing
        LEReportStatus.ItemIndex = LEReportStatus.Properties.GetDataSourceRowIndex("id_report_status", data.Rows(0)("id_report_status").ToString)

        MENote.Text = data.Rows(0)("sample_purc_rec_note").ToString

        GConListPurchase.Enabled = True
        view_list_rec()
    End Sub

    Sub view_po()
        Dim query As String = String.Format("SELECT id_report_status,sample_purc_vat,id_season_orign,sample_purc_number,id_comp_contact_to,id_comp_contact_ship_to,id_po_type,id_payment,DATE_FORMAT(sample_purc_date,'%Y-%m-%d') as sample_purc_datex,sample_purc_lead_time,sample_purc_top,id_currency,sample_purc_note FROM tb_sample_purc WHERE id_sample_purc = '{0}'", id_order)
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")

        TEPONumber.Text = data.Rows(0)("sample_purc_number").ToString

        id_comp_from = data.Rows(0)("id_comp_contact_to").ToString
        TECompName.Text = get_company_x(get_id_company(data.Rows(0)("id_comp_contact_to").ToString), "1")

        TEOrderDate.Text = view_date_from(data.Rows(0)("sample_purc_datex").ToString, 0)
        TEEstRecDate.Text = view_date_from(data.Rows(0)("sample_purc_datex").ToString, Integer.Parse(data.Rows(0)("sample_purc_lead_time").ToString))
    End Sub

    Sub view_list_rec()
        Dim query = "CALL view_purc_rec_sample_det('" & id_receive & "')"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCListPurchase.DataSource = data
        GVListPurchase.BestFitColumns()
    End Sub

    Sub view_list_purchase()
        Dim query = "CALL view_purc_sample_det('" & id_order & "')"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCListPurchase.DataSource = data
        GVListPurchase.BestFitColumns()
    End Sub

    Sub view_report_status(ByVal lookup As DevExpress.XtraEditors.LookUpEdit)
        Dim query As String = "SELECT id_report_status,report_status FROM tb_lookup_report_status"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")

        lookup.Properties.DataSource = data

        lookup.Properties.DisplayMember = "report_status"
        lookup.Properties.ValueMember = "id_report_status"
        lookup.ItemIndex = 0
    End Sub
    Private Sub GVListPurchase_CustomColumnDisplayText(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs)
        If e.Column.FieldName = "no" Then
            e.DisplayText = (e.ListSourceRowIndex + 1).ToString()
        End If
    End Sub
    Private Sub BMark_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BMark.Click
        FormReportMark.id_report = id_receive
        FormReportMark.report_mark_type = "2"
        FormReportMark.is_view = "1"
        FormReportMark.ShowDialog()
    End Sub
End Class