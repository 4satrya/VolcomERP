Public Class FormProductionDet
    Public id_prod_order As String = "-1"
    Public id_prod_demand As String = "-1"
    Public id_prod_demand_design As String = "-1"
    Public id_delivery As String = "-1"
    Public id_report_status_g As String = "-1"
    Public is_pd_base As String = "-1"
    Public date_created As Date
    Public is_wo_view As String = "-1"


    Private Sub FormProductionDet_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        RCIMainVendor.ValueChecked = Convert.ToSByte(1)
        RCIMainVendor.ValueUnchecked = Convert.ToSByte(2)
        '
        view_term_production(LECategory)
        view_po_type(LEPOType)
        '
        TETolerance.EditValue = 0
        '
        date_created = Now
        DEDate.EditValue = date_created
        DERecDate.EditValue = date_created

        If id_prod_order = "-1" Then
            'new
            TEPONumber.Text = header_number_prod("1")

            XTPWorkOrder.PageVisible = False
            XTPMRS.PageVisible = False
            DDBPrint.Visible = False
            BtnAttachment.Visible = False
            BMark.Visible = False
            If is_pd_base = "1" Then
                id_prod_demand = get_prod_demand_design_x(id_prod_demand_design, "1")
                id_delivery = get_prod_demand_design_x(id_prod_demand_design, "2")
                TEPDNo.Text = get_prod_demand_x(id_prod_demand, "1")
                TEDesign.Text = get_design_x(get_prod_demand_design_x(id_prod_demand_design, "3"), "1")
                TEDesignCode.Text = get_design_x(get_prod_demand_design_x(id_prod_demand_design, "3"), "2")
                TESeason.Text = get_season_x(get_id_season(id_delivery), "1")
                TERange.Text = get_range_x(get_id_range(get_id_season(id_delivery)), "1")
                TEDelivery.Text = get_delivery_x(id_delivery, "1")
                TEUSCOde.Text = get_design_x(get_prod_demand_design_x(id_prod_demand_design, "3"), "3")
                view_prod_demand_product()
                view_bom()
                BPickDesign.Enabled = True
                BPickPD.Enabled = True
            End If
        Else
            'edit
            Dim query As String = String.Format("SELECT *,DATE_FORMAT(prod_order_date,'%Y-%m-%d') as prod_order_datex FROM tb_prod_order WHERE id_prod_order = '{0}'", id_prod_order)
            Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")

            id_report_status_g = data.Rows(0)("id_report_status").ToString

            TEPONumber.Text = data.Rows(0)("prod_order_number").ToString

            LEPOType.EditValue = data.Rows(0)("id_po_type").ToString()
            LECategory.EditValue = data.Rows(0)("id_term_production").ToString()
            '
            TETolerance.EditValue = data.Rows(0)("tolerance")
            '
            date_created = data.Rows(0)("prod_order_date")
            TELeadTime.Text = data.Rows(0)("prod_order_lead_time").ToString
            '
            DEDate.EditValue = date_created
            DERecDate.EditValue = date_created.AddDays(data.Rows(0)("prod_order_lead_time"))
            '
            id_prod_demand_design = data.Rows(0)("id_prod_demand_design").ToString()
            id_prod_demand = get_prod_demand_design_x(id_prod_demand_design, "1")
            id_delivery = get_prod_demand_design_x(id_prod_demand_design, "2")
            '
            TEPDNo.Text = get_prod_demand_x(id_prod_demand, "1")
            TEDesign.Text = get_design_x(get_prod_demand_design_x(id_prod_demand_design, "3"), "1")
            TEDesignCode.Text = get_design_x(get_prod_demand_design_x(id_prod_demand_design, "3"), "2")
            TESeason.Text = get_season_x(get_id_season(id_delivery), "1")
            TERange.Text = get_range_x(get_id_range(get_id_season(id_delivery)), "1")
            TEDelivery.Text = get_delivery_x(id_delivery, "1")
            TEUSCOde.Text = get_design_x(get_prod_demand_design_x(id_prod_demand_design, "3"), "3")
            '
            BPickPD.Enabled = False
            BPickDesign.Enabled = False
            BCOP.Visible = True
            view_list_purchase()
            view_bom()
            allow_status()
            XTPWorkOrder.PageVisible = True
            XTPMRS.PageVisible = True
            'wo
            view_wo()
            view_mrs()
        End If
    End Sub

    Sub view_bom()
        Try
            If id_prod_demand_design = "" Then
                id_prod_demand_design = "-1"
            End If
            Dim query As String
            query = "CALL view_bom_design_list(" & id_prod_demand_design & ",1)"
            Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
            GCBOM.DataSource = data
            GVBOM.ActiveFilterString = "[is_cost] = 1"
            GVBOM.ExpandAllGroups()
            If GVBOM.RowCount > 0 Then
                METotSay.Text = ConvertCurrencyToEnglish(GVBOM.Columns("total").SummaryItem.SummaryValue.ToString, get_setup_field("id_currency_default"))
            End If
        Catch ex As Exception
            errorConnection()
        End Try
    End Sub

    Private Sub GVBOM_CustomColumnDisplayText(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs) Handles GVBOM.CustomColumnDisplayText
        If e.Column.FieldName = "id_component_category" Then
            Dim rowhandle As Integer = e.ListSourceRowIndex
            If GVBOM.IsGroupRow(rowhandle) Then
                rowhandle = GVBOM.GetDataRowHandleByGroupRowHandle(rowhandle)
                e.DisplayText = GVBOM.GetRowCellDisplayText(rowhandle, "category")
            End If
        End If
    End Sub

    Sub view_list_purchase()
        Dim query = "CALL view_prod_order_det('" & id_prod_order & "','1')"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCListProduct.DataSource = data
        If data.Rows.Count < 1 Then
            BSave.Enabled = False
            METotSay.Text = ""
        Else
            BSave.Enabled = True
            'METotSay.Text = ConvertCurrencyToEnglish(GVListProduct.Columns("total_cost").SummaryItem.SummaryValue.ToString, get_setup_field("id_currency_default"))
        End If
        GVListProduct.BestFitColumns()
    End Sub
    Private Sub BPickPD_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BPickPD.Click
        FormPopUpPD.id_pop_up = "1"
        FormPopUpPD.ShowDialog()
    End Sub
    Private Sub BPickDesign_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BPickDesign.Click
        FormPopUpPDDesign.id_pop_up = "1"
        FormPopUpPDDesign.id_prod_demand = id_prod_demand
        FormPopUpPDDesign.ShowDialog()
    End Sub
    Sub view_term_production(ByVal lookup As DevExpress.XtraEditors.SearchLookUpEdit)
        Dim query As String = "SELECT id_term_production,term_production FROM tb_lookup_term_production ORDER BY id_term_production ASC"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")

        lookup.Properties.DataSource = Nothing
        lookup.Properties.DataSource = data

        lookup.Properties.DisplayMember = "term_production"
        lookup.Properties.ValueMember = "id_term_production"
        lookup.EditValue = data.Rows(0)("id_term_production").ToString
    End Sub
    Sub view_po_type(ByVal lookup As DevExpress.XtraEditors.SearchLookUpEdit)
        Dim query As String = "SELECT id_po_type,po_type FROM tb_lookup_po_type ORDER BY id_po_type ASC"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")

        lookup.Properties.DataSource = Nothing
        lookup.Properties.DataSource = data

        lookup.Properties.DisplayMember = "po_type"
        lookup.Properties.ValueMember = "id_po_type"
        lookup.EditValue = data.Rows(0)("id_po_type").ToString
    End Sub
    Sub view_prod_demand_product()
        Dim query As String = "CALL view_prod_demand_product('" + id_prod_demand_design + "',1)"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCListProduct.DataSource = data
        If data.Rows.Count < 1 Then
            BSave.Enabled = False
            'METotSay.Text = ""
        Else
            BSave.Enabled = True
            'METotSay.Text = ConvertCurrencyToEnglish(GVListProduct.Columns("total_cost").SummaryText.ToString, "1")
        End If
    End Sub
    Private Sub BCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BCancel.Click
        Close()
    End Sub

    Private Sub FormProductionDet_FormClosed(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub GVListProduct_CustomColumnDisplayText(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs) Handles GVListProduct.CustomColumnDisplayText
        If e.Column.FieldName = "no" Then
            e.DisplayText = (e.ListSourceRowIndex + 1).ToString()
        End If
    End Sub

    Private Sub BSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BSave.Click
        Dim query As String = ""

        If id_prod_order = "-1" Then
            'new
            If Not formIsValidInGroup(EPProdOrder, GroupGeneralHeader) Or id_prod_demand_design = "-1" Then
                errorInput()
            Else
                Dim po_number As String = header_number_prod(1)
                query = String.Format("INSERT INTO tb_prod_order(id_prod_demand_design,prod_order_number,id_po_type,id_term_production,prod_order_date,prod_order_note,id_delivery,prod_order_lead_time,tolerance) VALUES('{0}','{1}','{2}','{3}',NOW(),'{4}','{5}','{6}','{7}');SELECT LAST_INSERT_ID() ", id_prod_demand_design, po_number, LEPOType.EditValue.ToString, LECategory.EditValue.ToString, MENote.Text, id_delivery, TELeadTime.Text, TETolerance.EditValue.ToString)
                Dim last_id As String = execute_query(query, 0, True, "", "", "", "")

                If GVListProduct.RowCount > 0 Then
                    For i As Integer = 0 To GVListProduct.RowCount - 1
                        If Not GVListProduct.GetRowCellValue(i, "id_prod_demand_product").ToString = "" Then
                            'dp
                            query = String.Format("INSERT INTO tb_prod_order_det(id_prod_order,id_prod_demand_product,prod_order_qty,prod_order_det_note) VALUES('{0}','{1}','{2}','{3}')", last_id, GVListProduct.GetRowCellValue(i, "id_prod_demand_product").ToString(), GVListProduct.GetRowCellValue(i, "prod_order_qty").ToString(), GVListProduct.GetRowCellValue(i, "note").ToString())
                            execute_non_query(query, True, "", "", "", "")
                        End If
                    Next
                End If

                'insert who prepared
                insert_who_prepared("22", last_id, id_user)
                'end insert who prepared
                increase_inc_prod("1")
                FormProduction.XTCTabProduction.SelectedTabPageIndex = 0
                FormProduction.view_production_order()
                FormProduction.GVProd.FocusedRowHandle = find_row(FormProduction.GVProd, "id_prod_order", last_id)
                Close()
            End If
        Else
            'edit
            If Not formIsValidInGroup(EPProdOrder, GroupGeneralHeader) Or id_prod_demand_design = "-1" Then
                errorInput()
            Else
                query = String.Format("UPDATE tb_prod_order SET id_prod_demand_design='{0}',prod_order_number='{1}',id_po_type='{2}',id_term_production='{3}',prod_order_note='{4}',id_delivery='{6}',prod_order_lead_time='{7}',tolerance='{8}' WHERE id_prod_order='{5}'", id_prod_demand_design, TEPONumber.Text, LEPOType.EditValue, LECategory.EditValue, MENote.Text, id_prod_order, id_delivery, TELeadTime.Text, TETolerance.EditValue.ToString)
                execute_non_query(query, True, "", "", "", "")

                'update mark
                query = String.Format("UPDATE tb_report_mark SET info='{0}' WHERE id_report='{1}' AND report_mark_type='22'", LEPOType.Text, id_prod_order)
                execute_non_query(query, True, "", "", "", "")
                '
                FormProduction.XTCTabProduction.SelectedTabPageIndex = 0
                FormProduction.view_production_order()
                FormProduction.GVProd.FocusedRowHandle = find_row(FormProduction.GVProd, "id_prod_order", id_prod_order)

                For i As Integer = 0 To GVListProduct.RowCount - 1
                    query = String.Format("UPDATE tb_prod_order_det SET prod_order_det_note='{1}' WHERE id_prod_order_det='{0]'", GVListProduct.GetRowCellValue(i, "id_prod_order_det").ToString(), GVListProduct.GetRowCellValue(i, "note").ToString())
                    execute_non_query(query, True, "", "", "", "")
                Next

                Close()
            End If
        End If
        'universal save bom
        'save_id_bom()
    End Sub

    Sub save_id_bom()
        Dim query As String = ""
        If GVListProduct.RowCount > 0 Then
            For i As Integer = 0 To GVListProduct.RowCount - 1
                If Not GVListProduct.GetRowCellValue(i, "id_bom").ToString = "" Then
                    query = String.Format("UPDATE tb_prod_demand_product SET id_bom='{1}',last_update_bom=NOW() WHERE id_prod_demand_product='{0}'", GVListProduct.GetRowCellValue(i, "id_prod_demand_product").ToString, GVListProduct.GetRowCellValue(i, "id_bom").ToString)
                    execute_non_query(query, True, "", "", "", "")
                End If
            Next
        End If
    End Sub

    'Private Sub TEPONumber_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TEPONumber.Validating
    'Dim query_jml As String
    '    query_jml = String.Format("SELECT COUNT(id_prod_order) FROM tb_prod_order WHERE prod_order_number='{0}' AND id_prod_order!='{1}'", TEPONumber.Text, id_prod_order)
    'Dim jml As Integer = execute_query(query_jml, 0, True, "", "", "", "")
    'If Not jml < 1 Then
    '        EP_TE_already_used(EPProdOrder, TEPONumber, "1")
    'Else
    '        EP_TE_cant_blank(EPProdOrder, TEPONumber)
    'End If
    'End Sub

    Private Sub BMark_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BMark.Click
        FormReportMark.id_report = id_prod_order
        FormReportMark.report_mark_type = "22"
        FormReportMark.ShowDialog()
    End Sub

    Private Sub BAddWO_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BAddWO.Click
        FormProductionWO.id_wo = "-1"
        FormProductionWO.id_po = id_prod_order
        FormProductionWO.ShowDialog()
    End Sub
    Sub allow_status()
        If check_edit_report_status(id_report_status_g, "22", id_prod_order) Then
            BSave.Enabled = True
            GridColumnBOM.OptionsColumn.AllowEdit = True
            '
            BPickDesign.Enabled = True
            BPickPD.Enabled = True
        Else
            BSave.Enabled = False
            GridColumnBOM.OptionsColumn.AllowEdit = False
            '
            BPickDesign.Enabled = False
            BPickPD.Enabled = False
        End If

        'If check_print_report_status(id_report_status_g) Then
        '    'BPrint.Enabled = True
        '    'DDBPrint.Enabled = True
        'Else
        '    'BPrint.Enabled = False
        '    'DDBPrint.Enabled = False
        'End If
    End Sub
    '======================= begin WO ===============================
    Sub view_wo()
        Dim query = "SELECT a.id_report_status,h.report_status,a.id_prod_order_wo,a.id_ovh_price "
        query += ",(SELECT IFNULL(MAX(prod_order_wo_prog_percent),0) FROM tb_prod_order_wo_prog WHERE id_prod_order_wo = a.id_prod_order_wo) as progress,"
        query += "g.payment,a.is_main_vendor, "
        query += "d.comp_name AS comp_name_to, "
        query += "f.comp_name AS comp_name_ship_to, "
        query += "a.prod_order_wo_number,a.id_ovh_price,j.overhead, "
        query += "a.prod_order_wo_date, "
        query += "DATE_ADD(a.prod_order_wo_date,INTERVAL a.prod_order_wo_lead_time DAY) AS prod_order_wo_lead_time, "
        query += "DATE_ADD(a.prod_order_wo_date,INTERVAL (a.prod_order_wo_top+a.prod_order_wo_lead_time) DAY) AS prod_order_wo_top "
        query += "FROM tb_prod_order_wo a INNER JOIN tb_m_ovh_price b ON a.id_ovh_price=b.id_ovh_price "
        query += "INNER JOIN tb_m_comp_contact c ON b.id_comp_contact = c.id_comp_contact "
        query += "INNER JOIN tb_m_comp d ON c.id_comp = d.id_comp "
        query += "INNER JOIN tb_m_comp_contact e ON a.id_comp_contact_ship_to = e.id_comp_contact "
        query += "INNER JOIN tb_m_comp f ON e.id_comp = f.id_comp "
        query += "INNER JOIN tb_lookup_payment g ON a.id_payment = g.id_payment "
        query += "INNER JOIN tb_lookup_report_status h ON h.id_report_status = a.id_report_status "
        query += "INNER JOIN tb_m_ovh j ON b.id_ovh = j.id_ovh "
        query += "WHERE a.id_prod_order='" & id_prod_order & "'"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCProdWO.DataSource = data

        show_but_wo()
    End Sub

    Private Sub BEditWO_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BEditWO.Click
        edit_wo()
    End Sub
    Sub edit_wo()
        FormProductionWO.id_wo = GVProdWO.GetFocusedRowCellValue("id_prod_order_wo").ToString
        FormProductionWO.id_po = id_prod_order
        FormProductionWO.ShowDialog()
    End Sub
    Private Sub Bdel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Bdel.Click
        Dim confirm As DialogResult
        Dim query As String
        If Not check_edit_report_status(GVProdWO.GetFocusedRowCellDisplayText("id_report_status").ToString, "23", GVProdWO.GetFocusedRowCellDisplayText("id_prod_order_wo").ToString) Or GVProdWO.GetFocusedRowCellDisplayText("id_report_status").ToString = "5" Then
            stopCustom("This data already locked.")
        Else
            confirm = DevExpress.XtraEditors.XtraMessageBox.Show("Are you sure want to delete this work order?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
            Dim id_wo As String = GVProdWO.GetFocusedRowCellDisplayText("id_prod_order_wo").ToString
            If confirm = Windows.Forms.DialogResult.Yes Then
                Cursor = Cursors.WaitCursor
                Try
                    query = String.Format("DELETE FROM tb_prod_order_wo WHERE id_prod_order_wo = '{0}'", id_wo)
                    execute_non_query(query, True, "", "", "", "")
                    delete_all_mark_related("23", id_wo)
                    view_wo()
                    show_but_wo()
                Catch ex As Exception
                    DevExpress.XtraEditors.XtraMessageBox.Show("This work order already used.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End Try
                Cursor = Cursors.Default
            End If
        End If
    End Sub

    Sub show_but_wo()
        If GVProdWO.RowCount > 0 Then
            BEditWO.Visible = True
            Bdel.Visible = True
            BProgress.Visible = True
        Else
            BEditWO.Visible = False
            Bdel.Visible = False
            BProgress.Visible = False
        End If
    End Sub

    Private Sub BPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BPrint.Click
        ReportProduction.id_prod_order = id_prod_order

        Dim Report As New ReportProduction()
        Dim Tool As DevExpress.XtraReports.UI.ReportPrintTool = New DevExpress.XtraReports.UI.ReportPrintTool(Report)
        Tool.ShowPreview()
    End Sub

    Private Sub BProgress_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BProgress.Click
        FormProductionWOProgress.id_wo = GVProdWO.GetFocusedRowCellValue("id_prod_order_wo").ToString
        FormProductionWOProgress.id_po = id_prod_order
        FormProductionWOProgress.ShowDialog()
    End Sub

    Private Sub BAddMRS_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BAddMRS.Click
        FormProductionMRS.id_prod_order = id_prod_order
        FormProductionMRS.TEPONumber.Text = TEPONumber.Text
        FormProductionMRS.TEDesign.Text = TEDesign.Text
        FormProductionMRS.TEDesignCode.Text = TEDesignCode.Text
        FormProductionMRS.ShowDialog()
    End Sub

    Private Sub TELeadTime_EditValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TELeadTime.EditValueChanged
        Try
            DERecDate.EditValue = date_created.AddDays(TELeadTime.EditValue)
        Catch ex As Exception
            '
        End Try
    End Sub
    '================ view MRS ====================
    Sub view_mrs()
        Dim query = "SELECT a.id_prod_order_mrs,a.prod_order_mrs_number,a.id_report_status,h.report_status,a.id_prod_order_wo,b.prod_order_wo_number, "
        query += "d.comp_name AS comp_name_req_from,c.id_comp_contact AS id_comp_name_req_from, "
        query += "f.comp_name AS comp_name_req_to,e.id_comp_contact AS id_comp_name_req_to, "
        query += "a.prod_order_mrs_date "
        query += "FROM tb_prod_order_mrs a "
        query += "LEFT JOIN tb_prod_order_wo b ON a.id_prod_order_wo = b.id_prod_order_wo "
        query += "INNER JOIN tb_m_comp_contact c ON a.id_comp_contact_req_from = c.id_comp_contact "
        query += "INNER JOIN tb_m_comp d ON c.id_comp = d.id_comp "
        query += "INNER JOIN tb_m_comp_contact e ON a.id_comp_contact_req_to = e.id_comp_contact "
        query += "INNER JOIN tb_m_comp f ON e.id_comp = f.id_comp "
        query += "INNER JOIN tb_lookup_report_status h ON h.id_report_status = a.id_report_status "
        query += "WHERE a.id_prod_order='" & id_prod_order & "'"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCMRS.DataSource = data

        show_but_mrs()
    End Sub
    Sub show_but_mrs()
        If GVMRS.RowCount > 0 Then
            BEditMRS.Visible = True
            BDeleteMRS.Visible = True
        Else
            BEditMRS.Visible = False
            BDeleteMRS.Visible = False
        End If
    End Sub

    Private Sub BEditMRS_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BEditMRS.Click
        FormProductionMRS.id_prod_order = id_prod_order
        FormProductionMRS.id_mrs = GVMRS.GetFocusedRowCellValue("id_prod_order_mrs").ToString
        FormProductionMRS.id_comp_req_from = GVMRS.GetFocusedRowCellValue("id_comp_name_req_from").ToString
        FormProductionMRS.id_comp_req_to = GVMRS.GetFocusedRowCellValue("id_comp_name_req_to").ToString
        FormProductionMRS.TEMRSNumber.Text = GVMRS.GetFocusedRowCellValue("prod_order_mrs_number").ToString
        FormProductionMRS.TEWONumber.Text = GVMRS.GetFocusedRowCellValue("prod_order_wo_number").ToString
        FormProductionMRS.TEPONumber.Text = TEPONumber.Text
        FormProductionMRS.TEDesign.Text = TEDesign.Text
        FormProductionMRS.TEDesignCode.Text = TEDesignCode.Text
        FormProductionMRS.ShowDialog()
    End Sub

    Private Sub BDeleteMRS_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BDeleteMRS.Click
        Dim confirm As DialogResult
        Dim query As String
        If Not check_edit_report_status(GVMRS.GetFocusedRowCellDisplayText("id_report_status").ToString, "29", GVMRS.GetFocusedRowCellDisplayText("id_prod_order_mrs").ToString) Or GVMRS.GetFocusedRowCellDisplayText("id_report_status").ToString = "5" Then
            stopCustom("This data already locked.")
        Else
            confirm = DevExpress.XtraEditors.XtraMessageBox.Show("Are you sure want to delete this request ?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
            Dim id_mrs As String = GVMRS.GetFocusedRowCellDisplayText("id_prod_order_mrs").ToString
            If confirm = Windows.Forms.DialogResult.Yes Then
                Cursor = Cursors.WaitCursor
                Try
                    query = String.Format("DELETE FROM tb_prod_order_mrs WHERE id_prod_order_mrs = '{0}'", id_mrs)
                    execute_non_query(query, True, "", "", "", "")
                    delete_all_mark_related("29", id_mrs)
                    view_mrs()
                    show_but_mrs()
                Catch ex As Exception
                    DevExpress.XtraEditors.XtraMessageBox.Show("This request already used.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End Try
                Cursor = Cursors.Default
            End If
        End If
    End Sub

    Private Sub BCOP_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BCOP.Click
        FormProductionCOP.id_design = get_prod_demand_design_x(id_prod_demand_design, "3")
        FormProductionCOP.ShowDialog()
    End Sub

    Private Sub BPrintBOM_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        print(GCBOM, "Bill Of Material - " & TEDesign.Text & " - " & TEDesignCode.Text)
    End Sub

    Private Sub BAccount_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BAccount.Click
        FormMappingCOA.report_mark_type = "23"
        FormMappingCOA.ShowDialog()
    End Sub

    Private Sub BEBOM_ButtonClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraEditors.Controls.ButtonPressedEventArgs) Handles BEBOM.ButtonClick
        FormPopUpBOM.id_product = GVListProduct.GetFocusedRowCellValue("id_product").ToString
        FormPopUpBOM.ShowDialog()
    End Sub

    Private Sub BarLargeButtonItem1_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarLargeButtonItem1.ItemClick
        ReportProduction.id_prod_order = id_prod_order
        If check_print_report_status(id_report_status_g) Then
            ReportProduction.is_pre = "-1"
        Else
            ReportProduction.is_pre = "1"
        End If

        Dim Report As New ReportProduction()
        Dim Tool As DevExpress.XtraReports.UI.ReportPrintTool = New DevExpress.XtraReports.UI.ReportPrintTool(Report)
        Tool.ShowPreview()
    End Sub

    Private Sub BarButtonItem2_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem2.ItemClick
        'print(GCBOM, "Bill Of Material - " & TEDesign.Text & " - " & TEDesignCode.Text)
        '... 
        ' creating and saving the view's layout to a new memory stream 
        Dim str As System.IO.Stream
        str = New System.IO.MemoryStream()
        GVBOM.SaveLayoutToStream(str, DevExpress.Utils.OptionsLayoutBase.FullLayout)
        str.Seek(0, System.IO.SeekOrigin.Begin)
        ReportProdBOM.id_prod_order = id_prod_order
        ReportProdBOM.dt = GCBOM.DataSource

        If check_print_report_status(id_report_status_g) Then
            ReportProdBOM.is_pre = "-1"
        Else
            ReportProdBOM.is_pre = "1"
        End If

        Dim Report As New ReportProdBOM()
        Report.GVBOM.RestoreLayoutFromStream(str, DevExpress.Utils.OptionsLayoutBase.FullLayout)
        str.Seek(0, System.IO.SeekOrigin.Begin)
        
        ' Report.LabelDesign.Text = FormFGStock.label_design_selected_stock_sum
        Report.LCode.Text = TEDesignCode.Text
        Report.LDesign.Text = TEDesign.Text
        Report.LPONo.Text = TEPONumber.Text
        Report.LDate.Text = DEDate.EditValue.ToString("dd MMM yyyy")
        Report.LBOMType.Text = LECategory.Text
        ' cost here
        Report.LTotCost.Text = Decimal.Parse(GVBOM.Columns("total").SummaryItem.SummaryValue).ToString("N2")
        Report.LSay.Text = ConvertCurrencyToEnglish(GVBOM.Columns("total").SummaryItem.SummaryValue.ToString, get_setup_field("id_currency_default"))
        Report.Lqty.Text = Decimal.Parse(GVListProduct.Columns("prod_order_qty").SummaryItem.SummaryValue).ToString("N2")
        Report.LUnitCost.Text = Decimal.Parse((GVBOM.Columns("total").SummaryItem.SummaryValue / GVListProduct.Columns("prod_order_qty").SummaryItem.SummaryValue)).ToString("N2")
        '
        ReportStyleGridview(Report.GVBOM)
        '
        Dim query As String = "SELECT "
        query += " m_p.id_design, bom.id_bom, bom.id_product, bom.is_default, bom.bom_name, bom.id_currency, bom.kurs, bom.id_term_production"
        query += " FROM tb_bom bom"
        query += " INNER JOIN tb_m_product m_p ON m_p.id_product=bom.id_product"
        query += " WHERE m_p.id_design='" & get_prod_demand_design_x(id_prod_demand_design, "3") & "' AND bom.is_default='1' "
        query += " LIMIT 1"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        If data.Rows.Count > 0 Then
            Report.LCur.Text = get_currency(data.Rows(0)("id_currency").ToString)
            Report.LKurs.Text = Decimal.Parse(data.Rows(0)("kurs")).ToString("N2")
            Report.LCPA.Text = Decimal.Parse((GVBOM.Columns("total").SummaryItem.SummaryValue / GVListProduct.Columns("prod_order_qty").SummaryItem.SummaryValue) * data.Rows(0)("kurs")).ToString("N2")
        End If
        ' Show the report's preview. 
        Dim Tool As DevExpress.XtraReports.UI.ReportPrintTool = New DevExpress.XtraReports.UI.ReportPrintTool(Report)
        Tool.ShowPreview()
    End Sub

    Private Sub BtnAttachment_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnAttachment.Click
        Cursor = Cursors.WaitCursor
        FormDocumentUpload.id_report = id_prod_order
        FormDocumentUpload.report_mark_type = "22"
        FormDocumentUpload.ShowDialog()
        Cursor = Cursors.Default
    End Sub
    Private Sub FormProductionDet_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown
        'work order list
        If Not is_wo_view = "-1" Then
            GVProdWO.FocusedRowHandle = find_row(GVProdWO, "id_prod_order_wo", is_wo_view)
            edit_wo()
        End If
    End Sub

    Private Sub DERecDate_EditValueChanged(sender As Object, e As EventArgs) Handles DERecDate.EditValueChanged
        Try
            TELeadTime.EditValue = DateDiff(DateInterval.Day, date_created, DERecDate.EditValue)
        Catch ex As Exception
            '
        End Try
    End Sub

End Class