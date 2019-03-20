Public Class FormViewProductionRetOut 
    Public action As String
    Public id_prod_order_ret_out As String = "0"
    Public id_prod_order As String
    Public id_comp_contact_to As String
    Public id_comp_contact_from As String
    Public id_prod_order_det_list, id_prod_order_ret_out_det_list As New List(Of String)
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

        'View data
        Try
            Dim query As String = "SELECT DATE_FORMAT(a.prod_order_ret_out_date,'%Y-%m-%d') as prod_order_ret_out_datex, a.id_report_status, a.id_prod_order, a.id_prod_order_ret_out, a.prod_order_ret_out_date, "
            query += "dsg.id_design, dsg.design_display_name, a.prod_order_ret_out_due_date, a.prod_order_ret_out_note, a.prod_order_ret_out_number,  "
            query += "b.prod_order_number, (c.id_comp_contact) AS id_comp_contact_from, (d.comp_name) AS comp_name_contact_from, (d.comp_number) AS comp_code_contact_from, (d.address_primary) AS comp_address_contact_from, "
            query += "(e.id_comp_contact) AS id_comp_contact_to, (f.comp_name) AS comp_name_contact_to, (f.comp_number) AS comp_code_contact_to,(f.address_primary) AS comp_address_contact_to, dsg.id_sample, ss.season "
            query += "FROM tb_prod_order_ret_out a "
            query += "INNER JOIN tb_prod_order b ON a.id_prod_order = b.id_prod_order "
            query += "INNER JOIN tb_season_delivery del ON del.id_delivery = b.id_delivery "
            query += "INNER JOIN tb_season ss ON ss.id_season = del.id_season "
            query += "INNER JOIN tb_m_comp_contact c ON a.id_comp_contact_from = c.id_comp_contact "
            query += "INNER JOIN tb_m_comp d ON d.id_comp = c.id_comp "
            query += "INNER JOIN tb_m_comp_contact e ON a.id_comp_contact_to = e.id_comp_contact "
            query += "INNER JOIN tb_m_comp f ON e.id_comp = f.id_comp "
            query += "INNER JOIN tb_prod_demand_design pd_design ON pd_design.id_prod_demand_design = b.id_prod_demand_design "
            query += "INNER JOIN tb_m_design dsg ON dsg.id_design = pd_design.id_design "
            query += "WHERE a.id_prod_order_ret_out='" + id_prod_order_ret_out + "' "
            Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
            TxtOrderNumber.Text = data.Rows(0)("prod_order_number").ToString
            id_comp_contact_from = data.Rows(0)("id_comp_contact_from").ToString
            TxtCodeCompFrom.Text = data.Rows(0)("comp_code_contact_from").ToString
            TxtNameCompFrom.Text = data.Rows(0)("comp_name_contact_from").ToString
            id_comp_contact_to = data.Rows(0)("id_comp_contact_to").ToString
            TxtCodeCompTo.Text = data.Rows(0)("comp_code_contact_to").ToString
            TxtNameCompTo.Text = data.Rows(0)("comp_name_contact_to").ToString
            MEAdrressCompTo.Text = data.Rows(0)("comp_address_contact_to").ToString
            'Dim start_date_arr() As String = data.Rows(0)("prod_order_ret_out_date").ToString.Split(" ")
            DERet.Text = view_date_from(data.Rows(0)("prod_order_ret_out_datex").ToString, 0)
            'Dim start_due_date_arr() As String = data.Rows(0)("prod_order_ret_out_due_date").ToString.Split(" ")
            DERetDueDate.EditValue = data.Rows(0)("prod_order_ret_out_due_date")
            TxtRetOutNumber.Text = data.Rows(0)("prod_order_ret_out_number").ToString
            MENote.Text = data.Rows(0)("prod_order_ret_out_note").ToString
            LEReportStatus.ItemIndex = LEReportStatus.Properties.GetDataSourceRowIndex("id_report_status", data.Rows(0)("id_report_status").ToString)
            id_report_status = data.Rows(0)("id_report_status").ToString
            id_prod_order = data.Rows(0)("id_prod_order").ToString
            id_design = data.Rows(0)("id_design").ToString
            TxtDesign.Text = data.Rows(0)("design_display_name").ToString
            TxtSeason.Text = data.Rows(0)("season").ToString

            pre_viewImages("2", PEView, id_design, False)
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
        DERetDueDate.Enabled = False
        GVRetDetail.OptionsCustomization.AllowGroup = True
        BtnAttachment.Enabled = True


        TxtRetOutNumber.Focus()
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
       
    End Sub

    Sub viewDetailReturn()
        Dim query As String = "CALL view_return_out_prod('" + id_prod_order_ret_out + "', '0')"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCRetDetail.DataSource = data
    End Sub
  

    Private Sub BMark_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BMark.Click
        FormReportMark.id_report = id_prod_order_ret_out
        FormReportMark.report_mark_type = "31"
        FormReportMark.form_origin = Name
        FormReportMark.is_view = "1"
        FormReportMark.ShowDialog()
    End Sub


    Private Sub DERetDueDate_EditValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DERetDueDate.EditValueChanged
        ' Try
        date_start = execute_query("select now()", 0, True, "", "", "", "")
        DERetDueDate.Properties.MinValue = date_start
        'Catch ex As Exception

        'End Try
    End Sub


    'DeleteRows
    Sub deleteRowsBc()

    End Sub

    'Focus Column Code
    Sub focusColumnCodeBc()
  
    End Sub
    'New Row
    Sub newRowsBc()
        
    End Sub

    

    Sub allowDelete()
     
    End Sub

    Sub noEdit()

    End Sub

    Private Sub GVBarcode_FocusedRowChanged(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs)
        noEdit()
    End Sub

    Sub countQty(ByVal id_prod_order_detx As String)
      
    End Sub

    Private Sub GVRetDetail_CustomColumnDisplayText(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs) Handles GVRetDetail.CustomColumnDisplayText
        If e.Column.FieldName = "no" Then
            e.DisplayText = (e.ListSourceRowIndex + 1).ToString()
        End If
    End Sub

    Sub isAllowRequisition(ByVal sample_name As String, ByVal id_prod_order_det_cek As String, ByVal qty_plx As String)
        cond_check = True
        qty_pl = Decimal.Parse(qty_plx.ToString)
        sample_check = sample_name
        Dim query_check As String = "CALL view_stock_prod_rec('" + id_prod_order + "', '" + id_prod_order_det_cek + "', '" + id_prod_order_ret_out + "', '0','0', '0', '0') "
        Dim data As DataTable = execute_query(query_check, -1, True, "", "", "", "")
        allow_sum = Decimal.Parse(data.Rows(0)("qty"))
        If qty_pl > allow_sum Then
            cond_check = False
        End If
    End Sub

    Sub infoQty()
        FormPopUpProdDet.id_pop_up = "1"
        FormPopUpProdDet.action = "ins"
        FormPopUpProdDet.id_prod_order = id_prod_order
        FormPopUpProdDet.id_ret_out = id_prod_order_ret_out
        FormPopUpProdDet.BtnSave.Visible = False
        FormPopUpProdDet.is_info_form = True
        FormPopUpProdDet.ShowDialog()
    End Sub

    Private Sub PEView_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PEView.DoubleClick
        Cursor = Cursors.WaitCursor
        pre_viewImages("2", PEView, id_design, True)
        Cursor = Cursors.Default
    End Sub

    Private Sub BtnAttachment_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnAttachment.Click
        Cursor = Cursors.WaitCursor
        FormDocumentUpload.id_report = id_prod_order_ret_out
        FormDocumentUpload.report_mark_type = "31"
        FormDocumentUpload.is_view = "1"
        FormDocumentUpload.ShowDialog()
        Cursor = Cursors.Default
    End Sub
End Class