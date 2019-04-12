Public Class FormViewProductionRetIn 
    Public action As String
    Public id_prod_order_ret_in As String = "0"
    Public id_prod_order As String
    Public id_comp_contact_to As String
    Public id_comp_contact_from As String
    Public id_prod_order_det_list, id_prod_order_ret_in_det_list As New List(Of String)
    Dim date_start As Date
    Public id_report_status As String
    Public cond_check As Boolean = True
    Public sample_check As String
    Public qty_pl As Decimal
    Public allow_sum As Decimal
    Public id_design As String = "-1"

    Private Sub FormProductionRetOutSingle_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        viewReportStatus() 'get report status
        actionLoad()
    End Sub

    Private Sub FormProductionRetOutSingle_FormClosed(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Sub actionLoad()
        'Enable/Disable
        GroupControlRet.Enabled = True


        'View data
        Try
            Dim query As String = "SELECT h.design_name, h.id_sample, DATE_FORMAT(a.prod_order_ret_in_date,'%Y-%m-%d') as prod_order_ret_in_datex, a.id_report_status, a.id_prod_order, a.id_prod_order_ret_in, a.prod_order_ret_in_date, "
            query += "a.prod_order_ret_in_note, a.prod_order_ret_in_number,  "
            query += "g.id_design,b.prod_order_number, (c.id_comp_contact) AS id_comp_contact_from, (d.comp_name) AS comp_name_contact_from, (d.comp_number) AS comp_code_contact_from, (d.address_primary) AS comp_address_contact_from, "
            query += "(e.id_comp_contact) AS id_comp_contact_to, (f.comp_name) AS comp_name_contact_to, (f.comp_number) AS comp_code_contact_to,(f.address_primary) AS comp_address_contact_to, ss.season "
            query += "FROM tb_prod_order_ret_in a "
            query += "INNER JOIN tb_prod_order b ON a.id_prod_order = b.id_prod_order "
            query += "INNER JOIN tb_season_delivery del ON del.id_delivery = b.id_delivery "
            query += "INNER JOIN tb_season ss ON ss.id_season = del.id_season "
            query += "INNER JOIN tb_m_comp_contact c ON a.id_comp_contact_from = c.id_comp_contact "
            query += "INNER JOIN tb_m_comp d ON d.id_comp = c.id_comp "
            query += "INNER JOIN tb_m_comp_contact e ON a.id_comp_contact_to = e.id_comp_contact "
            query += "INNER JOIN tb_m_comp f ON e.id_comp = f.id_comp "
            query += "INNER JOIN tb_prod_demand_design g ON g.id_prod_demand_design = b.id_prod_demand_design "
            query += "INNER JOIN tb_m_design h ON g.id_design = h.id_design "
            query += "WHERE a.id_prod_order_ret_in='" + id_prod_order_ret_in + "' "
            Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
            TxtOrderNumber.Text = data.Rows(0)("prod_order_number").ToString
            id_comp_contact_from = data.Rows(0)("id_comp_contact_from").ToString
            TxtCodeCompFrom.Text = data.Rows(0)("comp_code_contact_from").ToString
            TxtNameCompFrom.Text = data.Rows(0)("comp_name_contact_from").ToString
            id_comp_contact_to = data.Rows(0)("id_comp_contact_to").ToString
            TxtCodeCompTo.Text = data.Rows(0)("comp_code_contact_to").ToString
            TxtNameCompTo.Text = data.Rows(0)("comp_name_contact_to").ToString
            MEAdrressCompTo.Text = data.Rows(0)("comp_address_contact_to").ToString
            'Dim start_date_arr() As String = data.Rows(0)("prod_order_ret_in_date").ToString.Split(" ")
            DERet.Text = view_date_from(data.Rows(0)("prod_order_ret_in_datex").ToString, 0)
            TxtRetOutNumber.Text = data.Rows(0)("prod_order_ret_in_number").ToString
            MENote.Text = data.Rows(0)("prod_order_ret_in_note").ToString
            LEReportStatus.ItemIndex = LEReportStatus.Properties.GetDataSourceRowIndex("id_report_status", data.Rows(0)("id_report_status").ToString)
            id_report_status = data.Rows(0)("id_report_status").ToString
            id_prod_order = data.Rows(0)("id_prod_order").ToString
            id_design = data.Rows(0)("id_design").ToString
            pre_viewImages("2", PEView, id_design, False)
            TEDesign.Text = data.Rows(0)("design_name").ToString
            TxtSeason.Text = data.Rows(0)("season").ToString
            PEView.Enabled = True
        Catch ex As Exception
            errorConnection()
        End Try
        view_barcode_list()
        viewDetailReturn()
        check_but()
        allow_status()
    End Sub
    Sub allow_status()
        GVRetDetail.OptionsBehavior.Editable = False
        MENote.Properties.ReadOnly = True
        DERet.Properties.ReadOnly = True
    End Sub
    'sub check_but
    Sub check_but()

    End Sub
    'View Data
    Sub viewReportStatus()
        Dim query As String = "SELECT * FROM tb_lookup_report_status a ORDER BY a.id_report_status "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        viewLookupQuery(LEReportStatus, query, 0, "report_status", "id_report_status")
    End Sub

    Sub view_barcode_list()
        'Dim query As String = "SELECT ('0') AS no, ('') AS ean_code, ('0') AS id_prod_order_det, ('1') AS is_fix "
        'Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        'GCBarcode.DataSource = data
        'deleteRowsBc()
    End Sub

    Sub viewDetailReturn()
        Dim query As String = "CALL view_return_in_prod('" + id_prod_order_ret_in + "', '0')"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        For i As Integer = 0 To (data.Rows.Count - 1)
            id_prod_order_det_list.Add(data.Rows(i)("id_prod_order_det").ToString)
            id_prod_order_ret_in_det_list.Add(data.Rows(i)("id_prod_order_ret_in_det").ToString)
        Next
        GCRetDetail.DataSource = data
        check_but()
    End Sub
    'Button
    Private Sub BMark_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BMark.Click
        FormReportMark.id_report = id_prod_order_ret_in
        FormReportMark.report_mark_type = "32"
        FormReportMark.form_origin = Name
        FormReportMark.is_view = "1"
        FormReportMark.ShowDialog()
    End Sub

    Private Sub GVRetDetail_CustomColumnDisplayText(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs) Handles GVRetDetail.CustomColumnDisplayText
        If e.Column.FieldName = "no" Then
            e.DisplayText = (e.ListSourceRowIndex + 1).ToString()
        End If
    End Sub

    Private Sub PEView_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PEView.DoubleClick
        pre_viewImages("2", PEView, id_design, True)
    End Sub

    Private Sub BtnAttachment_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnAttachment.Click
        Cursor = Cursors.WaitCursor
        FormDocumentUpload.id_report = id_prod_order_ret_in
        FormDocumentUpload.report_mark_type = "32"
        FormDocumentUpload.is_view = "1"
        FormDocumentUpload.ShowDialog()
        Cursor = Cursors.Default
    End Sub
End Class