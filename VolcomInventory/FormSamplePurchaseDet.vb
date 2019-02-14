Public Class FormSamplePurchaseDet
    Public id_sample_purc As String = "-1"
    Public id_comp_to As String = "-1"
    Public id_comp_ship_to As String = "-1"
    Public id_comp_contact_courier As String = "-1"
    Public id_sample_plan As String = "-1"
    Public date_created As String = ""
    Public id_report_status_g As String = "1"

    Sub load_budget()
        Dim where_active As String = ""
        If id_sample_purc = "-1" Then
            where_active = " AND spb.year >= YEAR(CURRENT_DATE()) AND spb.is_active = 1"
        End If

        Dim query As String = "SELECT spb.`id_sample_purc_budget`,spb.`description`,spb.`year`,spb.`value_rp`,spb.`value_usd`,GROUP_CONCAT(spbd.id_code_division) AS id_code_division,spb.`value_rp` - IFNULL(used_budget.budget_rp,0.00) AS remaining_rp,spb.`value_usd` - IFNULL(used_budget.budget_usd,0.00) AS remaining_usd FROM `tb_sample_purc_budget_div` spbd
INNER JOIN tb_sample_purc_budget spb ON spb.id_sample_purc_budget=spbd.`id_sample_purc_budget`
INNER JOIN tb_m_code_detail cd ON cd.`id_code_detail`=spbd.`id_code_division`
LEFT JOIN (
	SELECT sp.id_sample_purc_budget,SUM(IF(sp.id_currency=1,spd.sample_purc_det_qty,0)*spd.sample_purc_det_price) AS budget_rp, SUM(IF(sp.id_currency=2,spd.sample_purc_det_qty,0)*spd.sample_purc_det_price) AS budget_usd FROM tb_sample_purc_det spd
	INNER JOIN tb_sample_purc sp ON sp.id_sample_purc=spd.id_sample_purc
	WHERE sp.id_report_status!=5
	GROUP BY sp.id_sample_purc_budget
)used_budget ON used_budget.id_sample_purc_budget=spb.id_sample_purc_budget
WHERE 1=1 " & where_active & "
GROUP BY spb.`id_sample_purc_budget`"
        viewSearchLookupQuery(SLEBudget, query, "id_sample_purc_budget", "description", "id_sample_purc_budget")
        'remaining
        SLEBudget.EditValue = Nothing
        SLEBudget.Properties.NullText = "-- Choose budget --"
        load_remaining_budget()
    End Sub

    Sub load_remaining_budget()
        If id_sample_purc = "-1" Then
            Try
                If SLEBudget.EditValue = 0 Then
                    TERemainingBudget.EditValue = 0.00
                Else
                    If LECurrency.EditValue.ToString = "1" Then 'rp
                        TERemainingBudget.EditValue = SLEBudget.Properties.View.GetFocusedRowCellValue("remaining_rp")
                    ElseIf LECurrency.EditValue.ToString = "2" Then 'usd
                        TERemainingBudget.EditValue = SLEBudget.Properties.View.GetFocusedRowCellValue("remaining_usd")
                    End If
                End If
            Catch ex As Exception
                TERemainingBudget.EditValue = 0.00
            End Try
        End If
    End Sub

    Private Sub FormSamplePurchaseDet_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        TEGrossTot.EditValue = 0.00
        TEVatTot.EditValue = 0.00
        TETot.EditValue = 0.00
        '
        TERemainingBudget.EditValue = 0.00
        TERemainingBudgetAfter.EditValue = 0.00
        TEPOPlusCommision.EditValue = 0.00
        '
        TEComm.EditValue = 0.00
        TEKurs.EditValue = 1.0

        view_po_type(LEPOType)
        viewSeasonOrign(LESeason)
        view_payment_type(LEpayment)
        view_currency(LECurrency)
        load_budget()

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
            Dim query As String = String.Format("SELECT id_comp_contact_courier,id_sample_purc_budget,IF(id_sample_purc_budget=0,0.00,budget_before) AS budget_before,IF(id_sample_purc_budget=0,0.00,budget_after) AS budget_after,courier_comm,id_report_status,sample_purc_kurs,sample_purc_vat,id_season_orign,sample_purc_number,id_comp_contact_to,id_comp_contact_ship_to,id_po_type,id_payment,DATE_FORMAT(sample_purc_date,'%Y-%m-%d') as sample_purc_datex,sample_purc_lead_time,sample_purc_top,id_currency,sample_purc_note FROM tb_sample_purc WHERE id_sample_purc = '{0}'", id_sample_purc)
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
            'budget
            SLEBudget.EditValue = data.Rows(0)("id_sample_purc_budget").ToString
            TERemainingBudget.EditValue = data.Rows(0)("budget_before").ToString
            TERemainingBudgetAfter.EditValue = data.Rows(0)("budget_after").ToString
            '
            calculate()
            '
            BtnAttachment.Visible = True
            PanelControl2.Visible = False
            BSave.Visible = False
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
        load_remaining_budget()
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
        If id_sample_purc = "-1" Then 'new
            query += " WHERE is_active_sample='1'"
        End If
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
        If GVListPurchase.RowCount > 0 Then
            Dim confirm As DialogResult
            confirm = DevExpress.XtraEditors.XtraMessageBox.Show("All list will be reset, continue ?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)

            If confirm = DialogResult.Yes Then
                clear_all_request()
                FormPopUpContact.id_pop_up = "1"
                FormPopUpContact.id_cat = get_setup_field("id_comp_cat_vendor")
                FormPopUpContact.ShowDialog()
            End If
        Else
            FormPopUpContact.id_pop_up = "1"
            FormPopUpContact.id_cat = get_setup_field("id_comp_cat_vendor")
            FormPopUpContact.ShowDialog()
        End If
    End Sub

    Private Sub BSearchCompShipTo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BSearchCompShipTo.Click
        FormPopUpContact.id_pop_up = "2"
        FormPopUpContact.ShowDialog()
    End Sub

    Private Sub BSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BSave.Click
        If TEKurs.EditValue <= 1 Then
            warningCustom("Today transaction kurs still not submitted, please contact FC.")
        Else
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
                'If Not formIsValidInGroup(EPSamplePurc, GroupGeneralHeader) Or id_comp_ship_to = "-1" Or id_comp_to = "-1" Then
                '    errorInput()
                'Else
                '    query = String.Format("UPDATE tb_sample_purc Set id_season_orign='{0}',sample_purc_number='{1}',id_comp_contact_to='{2}',id_comp_contact_ship_to='{3}',id_po_type='{4}',id_payment='{5}',sample_purc_lead_time='{6}',sample_purc_top='{7}',id_currency='{8}',sample_purc_note='{9}',sample_purc_vat='{10}',sample_purc_kurs='{12}',id_comp_contact_courier={13},courier_comm='{14}' WHERE id_sample_purc='{11}'", id_season_orign, po_number, id_comp_to, id_comp_ship_to, po_typex, payment_type, lead_time, top, id_currency, notex, vat, id_sample_purc, decimalSQL(TEKurs.EditValue.ToString), id_comp_contact_courier, decimalSQL(TEComm.EditValue.ToString))
                '    execute_non_query(query, True, "", "", "", "")
                '    'detail
                '    'delete first
                '    Dim sp_check As Boolean = False
                '    Dim query_del As String = "SELECT id_sample_purc_det FROM tb_sample_purc_det WHERE id_sample_purc='" & id_sample_purc & "'"
                '    Dim data_del As DataTable = execute_query(query_del, -1, True, "", "", "", "")

                '    If data_del.Rows.Count > 0 Then
                '        For i As Integer = 0 To data_del.Rows.Count - 1
                '            sp_check = False
                '            ' false mean not found, believe me
                '            For j As Integer = 0 To GVListPurchase.RowCount - 1
                '                If Not GVListPurchase.GetRowCellValue(j, "id_sample_purc_det").ToString = "" Then
                '                    '
                '                    If GVListPurchase.GetRowCellValue(j, "id_sample_purc_det").ToString = data_del.Rows(i)("id_sample_purc_det").ToString() Then
                '                        sp_check = True
                '                    End If
                '                End If
                '            Next
                '            'end loop check on gv
                '            If sp_check = False Then
                '                'Because not found, it's only mean already deleted
                '                query = String.Format("DELETE FROM tb_sample_purc_det WHERE id_sample_purc_det='{0}'", data_del.Rows(i)("id_sample_purc_det").ToString())
                '                execute_non_query(query, True, "", "", "", "")
                '            End If
                '        Next
                '    End If
                '    '
                '    For i As Integer = 0 To GVListPurchase.RowCount - 1
                '        If Not GVListPurchase.GetRowCellValue(i, "id_sample_price").ToString = "" Then
                '            If GVListPurchase.GetRowCellValue(i, "id_sample_purc_det").ToString = "" Then
                '                'insert new
                '                query = String.Format("INSERT INTO tb_sample_purc_det(id_sample_purc,id_sample_price,sample_purc_det_kurs,sample_purc_det_price,sample_purc_det_qty,sample_purc_det_discount,sample_purc_det_note) VALUES('{0}','{1}','{2}','{3}','{4}','{5}','{6}')", id_sample_purc, GVListPurchase.GetRowCellValue(i, "id_sample_price").ToString(), decimalSQL(TEKurs.EditValue.ToString), decimalSQL(GVListPurchase.GetRowCellValue(i, "price").ToString()), decimalSQL(GVListPurchase.GetRowCellValue(i, "qty").ToString()), decimalSQL(GVListPurchase.GetRowCellValue(i, "discount").ToString()), GVListPurchase.GetRowCellValue(i, "note").ToString())
                '                execute_non_query(query, True, "", "", "", "")
                '            Else
                '                'update
                '                query = String.Format("UPDATE tb_sample_purc_det SET id_sample_price='{0}',sample_purc_det_price='{1}',sample_purc_det_qty='{2}',sample_purc_det_discount='{3}',sample_purc_det_note='{4}',sample_purc_det_kurs='{6}' WHERE id_sample_purc_det='{5}'", GVListPurchase.GetRowCellValue(i, "id_sample_price").ToString, decimalSQL(GVListPurchase.GetRowCellValue(i, "price").ToString), decimalSQL(GVListPurchase.GetRowCellValue(i, "qty").ToString), decimalSQL(GVListPurchase.GetRowCellValue(i, "discount").ToString), GVListPurchase.GetRowCellValue(i, "note").ToString, GVListPurchase.GetRowCellValue(i, "id_sample_purc_det").ToString, decimalSQL(TEKurs.EditValue.ToString))
                '                execute_non_query(query, True, "", "", "", "")
                '            End If
                '        End If
                '    Next
                'End If

                'FormSamplePurchase.XTCTabReceive.SelectedTabPageIndex = 0
                'FormSamplePurchase.view_sample_purc()
                'FormSamplePurchase.GVSamplePurchase.FocusedRowHandle = find_row(FormSamplePurchase.GVSamplePurchase, "id_sample_purc", id_sample_purc)
                'Close()
            Else
                'new
                If Not formIsValidInGroup(EPSamplePurc, GroupGeneralHeader) Or id_comp_ship_to = "-1" Or id_comp_to = "-1" Then
                    errorInput()
                Else
                    query = String.Format("INSERT INTO tb_sample_purc(id_season_orign,sample_purc_number,id_comp_contact_to,id_comp_contact_ship_to,id_po_type,id_payment,sample_purc_date,sample_purc_lead_time,sample_purc_top,id_currency,sample_purc_note,sample_purc_vat,sample_purc_kurs,id_comp_contact_courier,courier_comm,id_sample_purc_budget,budget_before,budget_after) VALUES('{0}','{1}','{2}','{3}','{4}','{5}',DATE(NOW()),'{6}','{7}','{8}','{9}','{10}','{11}',{12},'{13}','{14}',{15},'{16}');SELECT LAST_INSERT_ID()", id_season_orign, po_number, id_comp_to, id_comp_ship_to, po_typex, payment_type, lead_time, top, id_currency, notex, vat, decimalSQL(TEKurs.EditValue.ToString), id_comp_contact_courier, decimalSQL(TEComm.EditValue.ToString), SLEBudget.EditValue.ToString, decimalSQL(TERemainingBudget.EditValue.ToString), decimalSQL(TERemainingBudgetAfter.EditValue.ToString))
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
        If SLEBudget.EditValue Is Nothing Then
            warningCustom("Please select budget first")
        ElseIf id_comp_to = "-1" Then
            warningCustom("Please select vendor first")
        Else
            Dim filter_string As String = ""
            Dim id_div() As String = SLEBudget.Properties.View.GetFocusedRowCellValue("id_code_division").Split(",")
            For i = 0 To id_div.Length - 1
                If Not i = 0 Then
                    filter_string += " OR "
                End If
                filter_string += "[div_code] = '" & id_div(i).ToString & "'"
            Next
            FormSamplePurchaseSingle.filter_string = filter_string
            FormSamplePurchaseSingle.id_sample_purc = id_sample_purc
            FormSamplePurchaseSingle.ShowDialog()
        End If
    End Sub

    Sub calculate()
        Dim total, sub_tot, gross_tot, vat, discount As Decimal

        Try
            sub_tot = GVListPurchase.Columns("total").SummaryItem.SummaryValue
            vat = (TEVat.EditValue / 100) * GVListPurchase.Columns("total").SummaryItem.SummaryValue
            discount = GVListPurchase.Columns("tot_discount").SummaryItem.SummaryValue
        Catch ex As Exception
        End Try

        TEVatTot.EditValue = vat

        gross_tot = sub_tot - discount

        TEGrossTot.EditValue = gross_tot

        total = sub_tot + vat
        TETot.EditValue = total
        '
        load_remaining_budget_after()
        '
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
        Dim filter_string As String = ""
        Dim id_div() As String = SLEBudget.Properties.View.GetFocusedRowCellValue("id_code_division").Split(",")
        For i = 0 To id_div.Length - 1
            If Not i = 0 Then
                filter_string += " OR "
            End If
            filter_string += "[div_code] = '" & id_div(i).ToString & "'"
        Next
        FormSamplePurchaseSingle.filter_string = filter_string
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
            load_remaining_budget()
            load_remaining_budget_after()
            If id_sample_purc = "-1" Then
                If LECurrency.EditValue.ToString = "2" Then
                    Dim query_kurs As String = "SELECT * FROM tb_kurs_trans WHERE DATE(created_date) = DATE(NOW()) ORDER BY id_kurs_trans DESC"
                    Dim data_kurs As DataTable = execute_query(query_kurs, -1, True, "", "", "", "")

                    If Not data_kurs.Rows.Count > 0 Then
                        warningCustom("Today transaction kurs still not submitted, please contact FC.")
                        TEKurs.EditValue = 0.0
                    Else
                        TEKurs.EditValue = data_kurs.Rows(0)("kurs_trans")
                    End If
                Else
                    TEKurs.EditValue = 1.0
                End If
            End If
            '
            calculate()
        Catch ex As Exception
        End Try
    End Sub

    Sub load_remaining_budget_after()
        Dim remaining_after As Decimal = 0.00
        Dim remaining_before As Decimal = 0.00
        Dim used As Decimal = 0.00
        Dim commision_percent, total_plus_comision As Decimal
        '
        commision_percent = TEComm.EditValue
        total_plus_comision = TEGrossTot.EditValue + (TEGrossTot.EditValue * (commision_percent / 100))
        TEPOPlusCommision.EditValue = total_plus_comision
        '
        If id_sample_purc = "-1" Then
            Try
                remaining_before = TERemainingBudget.EditValue
                used = TEPOPlusCommision.EditValue
                remaining_after = remaining_before - used
                TERemainingBudgetAfter.EditValue = remaining_after
            Catch ex As Exception
            End Try
        End If
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

    Private Sub SLEBudget_EditValueChanged(sender As Object, e As EventArgs) Handles SLEBudget.EditValueChanged
        If GVListPurchase.RowCount > 0 And id_sample_purc = "-1" Then
            Dim confirm As DialogResult
            confirm = DevExpress.XtraEditors.XtraMessageBox.Show("All list will be reset, continue ?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)

            If confirm = DialogResult.Yes Then
                clear_all_request()
                load_remaining_budget()
            Else
                SLEBudget.EditValue = SLEBudget.OldEditValue
            End If
        Else
            load_remaining_budget()
        End If
    End Sub

    Sub clear_all_request()
        For i As Integer = GVListPurchase.RowCount - 1 To 0 Step -1
            GVListPurchase.DeleteRow(i)
        Next
    End Sub
    Private Sub TEComm_EditValueChanged(sender As Object, e As EventArgs) Handles TEComm.EditValueChanged
        load_remaining_budget()
    End Sub
End Class