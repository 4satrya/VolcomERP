Public Class FormSamplePurchaseDet
    Public id_sample_purc As String = "-1"
    Public id_comp_to As String = "-1"
    Public id_comp_ship_to As String = "-1"
    Public id_comp_contact_courier As String = "-1"
    Public id_sample_plan As String = "-1"
    Public date_created As String = ""
    Public id_report_status_g As String = "1"

    Private Sub FormSamplePurchaseDet_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        view_currency(LECurrency)
        view_po_type(LEPOType)
        viewSeasonOrign(LESeason)
        view_payment_type(LEpayment)

        TEComm.EditValue = 0

        Dim default_kurs As Decimal = 1.0
        TEKurs.EditValue = default_kurs

        If id_sample_purc = "-1" Then
            'new
            TEDate.Text = view_date(0)
            TERecDate.Text = view_date(0)
            TEDueDate.Text = view_date(0)
            TEPONumber.Text = header_number("1")

            view_list_purchase()

            BPrePrint.Visible = False
            BPrint.Visible = False
            BMark.Visible = False
            BtnAttachment.Visible = False
            '
        Else
            Dim query As String = String.Format("SELECT id_comp_contact_courier,courier_comm,id_report_status,sample_purc_kurs,sample_purc_vat,id_season_orign,sample_purc_number,id_comp_contact_to,id_comp_contact_ship_to,id_po_type,id_payment,DATE_FORMAT(sample_purc_date,'%Y-%m-%d') as sample_purc_datex,sample_purc_lead_time,sample_purc_top,id_currency,sample_purc_note FROM tb_sample_purc WHERE id_sample_purc = '{0}'", id_sample_purc)
            Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
            '
            TEPONumber.Text = data.Rows(0)("sample_purc_number").ToString
            TEKurs.EditValue = data.Rows(0)("sample_purc_kurs").ToString
            '
            LECurrency.EditValue = Nothing
            LECurrency.ItemIndex = LECurrency.Properties.GetDataSourceRowIndex("id_currency", data.Rows(0)("id_currency").ToString)
            LEpayment.ItemIndex = LEpayment.Properties.GetDataSourceRowIndex("id_payment", data.Rows(0)("id_payment").ToString)
            '
            LESeason.EditValue = data.Rows(0)("id_season_orign").ToString
            LEPOType.EditValue = data.Rows(0)("id_po_type").ToString()
            id_report_status_g = data.Rows(0)("id_report_status").ToString
            '
            id_comp_to = data.Rows(0)("id_comp_contact_to").ToString
            TECompName.Text = get_company_x(get_id_company(id_comp_to), "1")
            TECompCode.Text = get_company_x(get_id_company(id_comp_to), "2")
            MECompAddress.Text = get_company_x(get_id_company(id_comp_to), "3")
            TECompAttn.Text = get_company_contact_x(id_comp_to, "1")
            '
            id_comp_ship_to = data.Rows(0)("id_comp_contact_ship_to").ToString
            TECompShipToName.Text = get_company_x(get_id_company(id_comp_ship_to), "1")
            TECompShipTo.Text = get_company_x(get_id_company(id_comp_ship_to), "2")
            MECompShipToAddress.Text = get_company_x(get_id_company(id_comp_ship_to), "3")
            '
            Try
                id_comp_contact_courier = data.Rows(0)("id_comp_contact_courier").ToString
                TECourier.Text = get_company_x(get_id_company(id_comp_contact_courier), "1")
                TECourierCode.Text = get_company_x(get_id_company(id_comp_contact_courier), "2")
            Catch ex As Exception
            End Try

            TEComm.EditValue = data.Rows(0)("courier_comm")
            '
            MENote.Text = data.Rows(0)("sample_purc_note").ToString
            date_created = data.Rows(0)("sample_purc_datex").ToString
            TEDate.Text = view_date_from(date_created, 0)
            TELeadTime.Text = data.Rows(0)("sample_purc_lead_time").ToString
            TERecDate.Text = view_date_from(date_created, Integer.Parse(data.Rows(0)("sample_purc_lead_time").ToString))
            TETOP.Text = data.Rows(0)("sample_purc_top").ToString
            TEDueDate.Text = view_date_from(date_created, (Integer.Parse(data.Rows(0)("sample_purc_lead_time").ToString) + Integer.Parse(data.Rows(0)("sample_purc_top").ToString)))
            '
            GConListPurchase.Enabled = True
            TEVat.Properties.ReadOnly = False
            view_list_purchase()
            TEVat.Text = data.Rows(0)("sample_purc_vat").ToString
            calculate()
            '
            BtnAttachment.Visible = True
        End If
        allow_status()
        ' begin here sample plan
        If id_sample_plan <> "-1" Then
            BAdd.Enabled = False
            BEdit.Enabled = False
            Bdel.Enabled = False
            GConListPurchase.Enabled = True
            '
            Dim query As String = String.Format("SELECT id_comp_contact_to,id_season_orign FROM tb_sample_plan WHERE id_sample_plan = '{0}'", id_sample_plan)
            Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")

            LESeason.EditValue = data.Rows(0)("id_season_orign").ToString

            id_comp_to = data.Rows(0)("id_comp_contact_to").ToString
            TECompName.Text = get_company_x(get_id_company(id_comp_to), "1")
            TECompCode.Text = get_company_x(get_id_company(id_comp_to), "2")
            MECompAddress.Text = get_company_x(get_id_company(id_comp_to), "3")
            TECompAttn.Text = get_company_contact_x(id_comp_to, "1")
            '
            view_list_purchase()
            'template
            Dim query_loop As String = "SELECT tmp_tb.id_sample,tmp_tb.sample_code,tmp_tb.sample_name,tmp_tb.qty,tmp_tb.id_sample_price,tmp_tb.sample_price,CAST((tmp_tb.sample_price*tmp_tb.qty) AS DECIMAL(13,2)) total FROM "
            query_loop += "(SELECT a.id_sample, b.sample_code,b.sample_name,a.sample_plan_det_qty AS qty, "
            query_loop += "COALESCE((SELECT za.id_sample_price FROM tb_m_sample_price za WHERE za.id_sample=a.id_sample ORDER BY za.id_sample_price DESC LIMIT 1),NULL) AS id_sample_price, "
            query_loop += "COALESCE((SELECT za.sample_price FROM tb_m_sample_price za WHERE za.id_sample=a.id_sample ORDER BY za.id_sample_price DESC LIMIT 1),0) AS sample_price "
            query_loop += "FROM tb_sample_plan_det a INNER JOIN tb_m_sample b ON a.id_sample=b.id_sample "
            query_loop += "WHERE id_sample_plan='" & id_sample_plan & "') AS tmp_tb"
            Dim data_loop As DataTable = execute_query(query_loop, -1, True, "", "", "", "")
            For i As Integer = 0 To (data_loop.Rows.Count - 1)
                If Not data_loop.Rows(i)("id_sample_price").ToString() = "0" Then
                    Dim newRow As DataRow = (TryCast(GCListPurchase.DataSource, DataTable)).NewRow()
                    newRow("id_sample_price") = data_loop.Rows(i)("id_sample_price").ToString()
                    newRow("code") = data_loop.Rows(i)("sample_code").ToString()
                    newRow("name") = data_loop.Rows(i)("sample_name").ToString()
                    newRow("price") = data_loop.Rows(i)("sample_price").ToString()
                    newRow("discount") = "0"
                    newRow("qty") = data_loop.Rows(i)("qty").ToString()
                    newRow("total") = data_loop.Rows(i)("total").ToString()
                    '
                    TryCast(GCListPurchase.DataSource, DataTable).Rows.Add(newRow)
                    GCListPurchase.RefreshDataSource()
                End If
            Next

            TEVat.Properties.ReadOnly = False
            TEVat.Text = "0"
            calculate()
        End If
    End Sub

    Sub view_list_purchase()
        Dim query = "CALL view_purc_sample_det('" & id_sample_purc & "')"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCListPurchase.DataSource = data
        show_but()
        calculate()
    End Sub
    Sub show_but()
        If GVListPurchase.RowCount > 0 Then
            Bdel.Visible = True
            BEdit.Visible = True
        Else
            Bdel.Visible = False
            BEdit.Visible = False
        End If
    End Sub

    Private Sub view_currency(ByVal lookup As DevExpress.XtraEditors.LookUpEdit)
        Dim query As String = "SELECT id_currency,currency FROM tb_lookup_currency"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")

        lookup.Properties.DataSource = data

        lookup.Properties.DisplayMember = "currency"
        lookup.Properties.ValueMember = "id_currency"
        lookup.ItemIndex = 0
    End Sub
    Private Sub view_payment_type(ByVal lookup As DevExpress.XtraEditors.LookUpEdit)
        Dim query As String = "SELECT id_payment,payment FROM tb_lookup_payment"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")

        lookup.Properties.DataSource = data

        lookup.Properties.DisplayMember = "payment"
        lookup.Properties.ValueMember = "id_payment"
        lookup.ItemIndex = 0
    End Sub
    Private Sub view_po_type(ByVal lookup As DevExpress.XtraEditors.SearchLookUpEdit)
        Dim query As String = "SELECT id_po_type,po_type FROM tb_lookup_po_type ORDER BY id_po_type DESC"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")

        lookup.Properties.DataSource = Nothing
        lookup.Properties.DataSource = data

        lookup.Properties.DisplayMember = "po_type"
        lookup.Properties.ValueMember = "id_po_type"
        lookup.EditValue = data.Rows(0)("id_po_type").ToString
    End Sub
    'View Season
    Private Sub viewSeasonOrign(ByVal lookup As DevExpress.XtraEditors.SearchLookUpEdit)
        Dim query As String = "SELECT id_season_orign,season_orign FROM tb_season_orign ORDER BY id_season_orign DESC"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")

        lookup.Properties.DataSource = Nothing
        lookup.Properties.DataSource = data

        lookup.Properties.DisplayMember = "season_orign"
        lookup.Properties.ValueMember = "id_season_orign"
        lookup.EditValue = data.Rows(0)("id_season_orign").ToString
    End Sub

    Private Sub BSearchCompTo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BSearchCompTo.Click
        FormPopUpContact.id_pop_up = "1"
        FormPopUpContact.id_cat = get_setup_field("id_comp_cat_vendor")
        FormPopUpContact.ShowDialog()
    End Sub

    Private Sub BSearchCompShipTo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BSearchCompShipTo.Click
        FormPopUpContact.id_pop_up = "2"
        FormPopUpContact.ShowDialog()
    End Sub

    Private Sub BSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BSave.Click
        Dim err_txt, query, vat, po_typex, po_number, lead_time, top, payment_type, id_season_orign, id_currency, notex As String
        err_txt = "-1"

        po_typex = LEPOType.EditValue
        payment_type = LEpayment.EditValue
        id_season_orign = LESeason.EditValue
        id_currency = LECurrency.EditValue
        po_number = TEPONumber.Text
        lead_time = TELeadTime.Text
        top = TETOP.Text
        notex = MENote.Text
        vat = TEVat.EditValue

        If TECourierCode.Text = "" Then
            id_comp_contact_courier = "NULL"
        End If

        ValidateChildren()

        If id_sample_purc <> "-1" Then
            'edit
            If Not formIsValidInGroup(EPSamplePurc, GroupGeneralHeader) Or id_comp_ship_to = "-1" Or id_comp_to = "-1" Then
                errorInput()
            Else
                query = String.Format("UPDATE tb_sample_purc Set id_season_orign='{0}',sample_purc_number='{1}',id_comp_contact_to='{2}',id_comp_contact_ship_to='{3}',id_po_type='{4}',id_payment='{5}',sample_purc_lead_time='{6}',sample_purc_top='{7}',id_currency='{8}',sample_purc_note='{9}',sample_purc_vat='{10}',sample_purc_kurs='{12}',id_comp_contact_courier={13},courier_comm='{14}' WHERE id_sample_purc='{11}'", id_season_orign, po_number, id_comp_to, id_comp_ship_to, po_typex, payment_type, lead_time, top, id_currency, notex, vat, id_sample_purc, decimalSQL(TEKurs.EditValue.ToString), id_comp_contact_courier, decimalSQL(TEComm.EditValue.ToString))
                execute_non_query(query, True, "", "", "", "")
                'detail
                'delete first
                Dim sp_check As Boolean = False
                Dim query_del As String = "SELECT id_sample_purc_det FROM tb_sample_purc_det WHERE id_sample_purc='" & id_sample_purc & "'"
                Dim data_del As DataTable = execute_query(query_del, -1, True, "", "", "", "")

                If data_del.Rows.Count > 0 Then
                    For i As Integer = 0 To data_del.Rows.Count - 1
                        sp_check = False
                        ' false mean not found, believe me
                        For j As Integer = 0 To GVListPurchase.RowCount - 1
                            If Not GVListPurchase.GetRowCellValue(j, "id_sample_purc_det").ToString = "" Then
                                '
                                If GVListPurchase.GetRowCellValue(j, "id_sample_purc_det").ToString = data_del.Rows(i)("id_sample_purc_det").ToString() Then
                                    sp_check = True
                                End If
                            End If
                        Next
                        'end loop check on gv
                        If sp_check = False Then
                            'Because not found, it's only mean already deleted
                            query = String.Format("DELETE FROM tb_sample_purc_det WHERE id_sample_purc_det='{0}'", data_del.Rows(i)("id_sample_purc_det").ToString())
                            execute_non_query(query, True, "", "", "", "")
                        End If
                    Next
                End If
                '
                For i As Integer = 0 To GVListPurchase.RowCount - 1
                    If Not GVListPurchase.GetRowCellValue(i, "id_sample_price").ToString = "" Then
                        If GVListPurchase.GetRowCellValue(i, "id_sample_purc_det").ToString = "" Then
                            'insert new
                            query = String.Format("INSERT INTO tb_sample_purc_det(id_sample_purc,id_sample_price,sample_purc_det_kurs,sample_purc_det_price,sample_purc_det_qty,sample_purc_det_discount,sample_purc_det_note) VALUES('{0}','{1}','{2}','{3}','{4}','{5}','{6}')", id_sample_purc, GVListPurchase.GetRowCellValue(i, "id_sample_price").ToString(), decimalSQL(TEKurs.EditValue.ToString), decimalSQL(GVListPurchase.GetRowCellValue(i, "price").ToString()), decimalSQL(GVListPurchase.GetRowCellValue(i, "qty").ToString()), decimalSQL(GVListPurchase.GetRowCellValue(i, "discount").ToString()), GVListPurchase.GetRowCellValue(i, "note").ToString())
                            execute_non_query(query, True, "", "", "", "")
                        Else
                            'update
                            query = String.Format("UPDATE tb_sample_purc_det SET id_sample_price='{0}',sample_purc_det_price='{1}',sample_purc_det_qty='{2}',sample_purc_det_discount='{3}',sample_purc_det_note='{4}',sample_purc_det_kurs='{6}' WHERE id_sample_purc_det='{5}'", GVListPurchase.GetRowCellValue(i, "id_sample_price").ToString, decimalSQL(GVListPurchase.GetRowCellValue(i, "price").ToString), decimalSQL(GVListPurchase.GetRowCellValue(i, "qty").ToString), decimalSQL(GVListPurchase.GetRowCellValue(i, "discount").ToString), GVListPurchase.GetRowCellValue(i, "note").ToString, GVListPurchase.GetRowCellValue(i, "id_sample_purc_det").ToString, decimalSQL(TEKurs.EditValue.ToString))
                            execute_non_query(query, True, "", "", "", "")
                        End If
                    End If
                Next
            End If

            FormSamplePurchase.XTCTabReceive.SelectedTabPageIndex = 0
            FormSamplePurchase.view_sample_purc()
            FormSamplePurchase.GVSamplePurchase.FocusedRowHandle = find_row(FormSamplePurchase.GVSamplePurchase, "id_sample_purc", id_sample_purc)
            Close()
        Else
            'new
            If Not formIsValidInGroup(EPSamplePurc, GroupGeneralHeader) Or id_comp_ship_to = "-1" Or id_comp_to = "-1" Then
                errorInput()
            Else
                query = String.Format("INSERT INTO tb_sample_purc(id_season_orign,sample_purc_number,id_comp_contact_to,id_comp_contact_ship_to,id_po_type,id_payment,sample_purc_date,sample_purc_lead_time,sample_purc_top,id_currency,sample_purc_note,sample_purc_vat,sample_purc_kurs,id_comp_contact_courier,courier_comm) VALUES('{0}','{1}','{2}','{3}','{4}','{5}',DATE(NOW()),'{6}','{7}','{8}','{9}','{10}','{11}',{12},'{13}');SELECT LAST_INSERT_ID()", id_season_orign, po_number, id_comp_to, id_comp_ship_to, po_typex, payment_type, lead_time, top, id_currency, notex, vat, decimalSQL(TEKurs.EditValue.ToString), id_comp_contact_courier, decimalSQL(TEComm.EditValue.ToString))
                Dim last_id As String = execute_query(query, 0, True, "", "", "", "")

                If GVListPurchase.RowCount > 0 Then
                    For i As Integer = 0 To GVListPurchase.RowCount - 1
                        If Not GVListPurchase.GetRowCellValue(i, "id_sample_price").ToString = "" Then
                            'dp
                            query = String.Format("INSERT INTO tb_sample_purc_det(id_sample_purc,id_sample_price,sample_purc_det_kurs,sample_purc_det_price,sample_purc_det_qty,sample_purc_det_discount,sample_purc_det_note) VALUES('{0}','{1}','{2}','{3}','{4}','{5}','{6}')", last_id, GVListPurchase.GetRowCellValue(i, "id_sample_price").ToString(), decimalSQL(TEKurs.EditValue.ToString), decimalSQL(GVListPurchase.GetRowCellValue(i, "price").ToString), decimalSQL(GVListPurchase.GetRowCellValue(i, "qty").ToString()), decimalSQL(GVListPurchase.GetRowCellValue(i, "discount").ToString()), GVListPurchase.GetRowCellValue(i, "note").ToString())
                            execute_non_query(query, True, "", "", "", "")
                        End If
                    Next
                End If

                'insert who prepared
                insert_who_prepared("1", last_id, id_user)
                'end insert who prepared
                increase_inc("1")
                FormSamplePurchase.XTCTabReceive.SelectedTabPageIndex = 0
                FormSamplePurchase.view_sample_purc()
                FormSamplePurchase.GVSamplePurchase.FocusedRowHandle = find_row(FormSamplePurchase.GVSamplePurchase, "id_sample_purc", last_id)
                Close()
            End If
        End If
    End Sub

    Private Sub TEPONumber_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TEPONumber.Validating
        Dim query_jml As String
        query_jml = String.Format("SELECT COUNT(id_sample_purc) FROM tb_sample_purc WHERE sample_purc_number='{0}' AND id_sample_purc!='{1}'", TEPONumber.Text, id_sample_purc)
        Dim jml As Integer = execute_query(query_jml, 0, True, "", "", "", "")
        If Not jml < 1 Then
            EP_TE_already_used(EPSamplePurc, TEPONumber, "1")
        Else
            EP_TE_cant_blank(EPSamplePurc, TEPONumber)
        End If
    End Sub

    Private Sub TELeadTime_EditValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TELeadTime.EditValueChanged
        If id_sample_purc <> "-1" Then
            Try
                TERecDate.Text = view_date_from(date_created, Integer.Parse(TELeadTime.Text))
            Catch ex As Exception
                TERecDate.Text = view_date_from(date_created, 0)
            End Try
        Else
            Try
                TERecDate.Text = view_date(Integer.Parse(TELeadTime.Text))
            Catch ex As Exception
                TERecDate.Text = view_date(0)
            End Try
        End If
    End Sub

    Private Sub TETOP_EditValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TETOP.EditValueChanged
        If id_sample_purc <> "-1" Then
            Try
                TEDueDate.Text = view_date_from(date_created, (Integer.Parse(TELeadTime.Text) + Integer.Parse(TETOP.Text)))
            Catch ex As Exception
                TEDueDate.Text = view_date_from(date_created, 0)
            End Try
        Else
            Try
                TEDueDate.Text = view_date(Integer.Parse(TELeadTime.Text) + Integer.Parse(TETOP.Text))
            Catch ex As Exception
                TEDueDate.Text = view_date(0)
            End Try
        End If
    End Sub

    Private Sub LEpayment_EditValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LEpayment.EditValueChanged
        If LEpayment.EditValue = 1 Then
            TETOP.Enabled = True
        Else
            TETOP.Text = 0
            If id_sample_purc <> "-1" Then
                TEDueDate.Text = view_date_from(date_created, (Integer.Parse(TELeadTime.Text) + Integer.Parse(TETOP.Text)))
            Else
                TEDueDate.Text = view_date(Integer.Parse(TELeadTime.Text) + Integer.Parse(TETOP.Text))
            End If
            TETOP.Enabled = False
        End If
    End Sub

    Private Sub FormSamplePurchaseDet_FormClosed(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub BAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BAdd.Click
        FormSamplePurchaseSingle.id_sample_purc = id_sample_purc
        FormSamplePurchaseSingle.ShowDialog()
    End Sub

    Sub calculate()
        Dim total, sub_tot, gross_tot, vat, discount As Decimal

        Try
            sub_tot = GVListPurchase.Columns("total").SummaryItem.SummaryValue
            vat = (TEVat.EditValue / 100) * GVListPurchase.Columns("total").SummaryItem.SummaryValue
            discount = GVListPurchase.Columns("tot_discount").SummaryItem.SummaryValue
        Catch ex As Exception
        End Try

        TEDiscount.Text = discount.ToString("0.00")
        TEVatTot.Text = vat.ToString("0.00")

        gross_tot = sub_tot + discount
        TEGrossTot.Text = gross_tot.ToString("0.00")

        total = sub_tot + vat
        TETot.Text = total.ToString("0.00")
        METotSay.Text = ConvertCurrencyToEnglish(Double.Parse(total.ToString), LECurrency.EditValue.ToString)
    End Sub

    Private Sub TEVat_EditValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TEVat.EditValueChanged
        calculate()
    End Sub

    Private Sub GVListPurchase_CustomColumnDisplayText(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs) Handles GVListPurchase.CustomColumnDisplayText
        If e.Column.FieldName = "no" Then
            e.DisplayText = (e.ListSourceRowIndex + 1).ToString()
        End If
    End Sub

    Private Sub BEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BEdit.Click
        FormSamplePurchaseSingle.id_sample_purc = id_sample_purc
        FormSamplePurchaseSingle.id_sample_price = GVListPurchase.GetFocusedRowCellValue("id_sample_price").ToString
        FormSamplePurchaseSingle.id_sample_purc_det = GVListPurchase.GetFocusedRowCellValue("id_sample_purc_det").ToString
        FormSamplePurchaseSingle.ShowDialog()
    End Sub

    Private Sub BPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BPrint.Click
        ReportSamplePurchase.id_sample_purc = id_sample_purc

        Dim Report As New ReportSamplePurchase()
        ' Show the report's preview. 
        Dim Tool As DevExpress.XtraReports.UI.ReportPrintTool = New DevExpress.XtraReports.UI.ReportPrintTool(Report)
        Tool.ShowPreview()
    End Sub

    Private Sub Bdel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Bdel.Click
        Dim confirm As DialogResult
        confirm = DevExpress.XtraEditors.XtraMessageBox.Show("Are you sure want to delete this sample on list?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)

        If confirm = Windows.Forms.DialogResult.Yes Then
            Cursor = Cursors.WaitCursor
            Try
                GVListPurchase.DeleteSelectedRows()
                show_but()
            Catch ex As Exception
                DevExpress.XtraEditors.XtraMessageBox.Show("This list sample data already used.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
            Cursor = Cursors.Default
        End If
    End Sub

    Private Sub BMark_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BMark.Click
        FormReportMark.id_report = id_sample_purc
        FormReportMark.report_mark_type = "1"
        FormReportMark.ShowDialog()
    End Sub

    Private Sub BCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BCancel.Click
        Close()
    End Sub

    Sub allow_status()
        If check_edit_report_status(id_report_status_g, "13", id_sample_purc) Then
            BAdd.Enabled = True
            BEdit.Enabled = True
            Bdel.Enabled = True
            BSave.Enabled = True
            '
            BSearchCompTo.Enabled = True
            BSearchCompShipTo.Enabled = True
        Else
            BAdd.Enabled = False
            BEdit.Enabled = False
            Bdel.Enabled = False
            BSave.Enabled = False
            '
            BSearchCompTo.Enabled = False
            BSearchCompShipTo.Enabled = False
        End If

        If check_print_report_status(id_report_status_g) Then
            BPrint.Enabled = True
        Else
            BPrint.Enabled = False
        End If
    End Sub

    Private Sub BImportExcel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        FormImportExcel.id_pop_up = "1"
        FormImportExcel.ShowDialog()
    End Sub

    Private Sub LECurrency_EditValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LECurrency.EditValueChanged
        Try
            calculate()
        Catch ex As Exception
        End Try
    End Sub


    Private Sub BPrePrint_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BPrePrint.Click
        ReportSamplePurchase.id_sample_purc = id_sample_purc
        ReportSamplePurchase.id_pre = "1"

        Dim Report As New ReportSamplePurchase()
        ' Show the report's preview. 
        Dim Tool As DevExpress.XtraReports.UI.ReportPrintTool = New DevExpress.XtraReports.UI.ReportPrintTool(Report)
        Tool.ShowPreview()
    End Sub

    Private Sub BPickCourier_Click(sender As Object, e As EventArgs) Handles BPickCourier.Click
        FormPopUpContact.id_pop_up = "1c"
        FormPopUpContact.id_cat = get_setup_field("id_comp_cat_vendor")
        FormPopUpContact.ShowDialog()
    End Sub

    Private Sub BtnAttachment_Click(sender As Object, e As EventArgs) Handles BtnAttachment.Click
        Cursor = Cursors.WaitCursor
        FormDocumentUpload.id_report = id_sample_purc
        FormDocumentUpload.report_mark_type = "1"
        FormDocumentUpload.ShowDialog()
        Cursor = Cursors.Default
    End Sub
End Class