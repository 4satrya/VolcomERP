Public Class FormMatPurchaseDet
    Public id_purc As String = "-1"
    Public id_comp_to As String = "-1"
    Public id_comp_ship_to As String = "-1"
    Public date_created As String = ""
    Public id_report_status_g As String = "1"
    Public id_rev As String = "-1"

    Private Sub FormSamplePurchaseDet_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        action_load()
    End Sub
    Sub action_load()
        view_currency(LECurrency)
        view_po_type(LEPOType)
        viewSeason(LESeason)
        'view delivery
        view_payment_type(LEpayment)

        'check kurs first
        Dim query_kurs As String = "SELECT * FROM tb_kurs_trans WHERE DATE(created_date) = DATE(NOW()) ORDER BY id_kurs_trans DESC"
        Dim data_kurs As DataTable = execute_query(query_kurs, -1, True, "", "", "", "")

        If Not data_kurs.Rows.Count > 0 Then
            warningCustom("Today transaction kurs still not submitted, please contact accounting.")
            Close()
        Else
            TEKurs.EditValue = data_kurs.Rows(0)("kurs_trans")
        End If


        If id_purc = "-1" Then
            'new
            TEDate.Text = view_date(0)
            TERecDate.Text = view_date(0)
            TEDueDate.Text = view_date(0)
            TEPONumber.Text = header_number_mat("1")
            view_list_purchase(id_purc)
            BPrint.Visible = False
            BMark.Visible = False
            BtnAttachment.Visible = False
            BPrePrint.Visible = False
            '
        Else
            BPrePrint.Visible = True
            Dim query As String = String.Format("SELECT IFNULL(a.id_mat_purc_rev,'-1') AS id_mat_purc_rev,IFNULL(b.mat_purc_number,'-') AS mat_purc_rev_number,a.mat_purc_kurs,a.id_report_status,a.mat_purc_vat,a.id_delivery,a.mat_purc_number,a.id_comp_contact_to,a.id_comp_contact_ship_to,a.id_po_type,a.id_payment,DATE_FORMAT(a.mat_purc_date,'%Y-%m-%d') AS mat_purc_datex,a.mat_purc_lead_time,a.mat_purc_top,a.id_currency,a.mat_purc_note " _
            & "FROM tb_mat_purc a " _
            & "LEFT JOIN tb_mat_purc b ON a.id_mat_purc_rev=b.id_mat_purc " _
            & "WHERE a.id_mat_purc = '{0}'", id_purc)
            Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")

            TEPORevNumber.Text = data.Rows(0)("mat_purc_rev_number").ToString
            id_rev = data.Rows(0)("id_mat_purc_rev").ToString

            TEPONumber.Text = data.Rows(0)("mat_purc_number").ToString
            TEKurs.Text = data.Rows(0)("mat_purc_kurs").ToString

            LECurrency.ItemIndex = LECurrency.Properties.GetDataSourceRowIndex("id_currency", data.Rows(0)("id_currency").ToString)

            LEpayment.ItemIndex = LEpayment.Properties.GetDataSourceRowIndex("id_payment", data.Rows(0)("id_payment").ToString)

            id_report_status_g = data.Rows(0)("id_report_status").ToString

            LESeason.EditValue = get_id_season(data.Rows(0)("id_delivery").ToString)
            LEDelivery.EditValue = data.Rows(0)("id_delivery").ToString

            LEPOType.EditValue = data.Rows(0)("id_po_type").ToString()

            id_comp_to = data.Rows(0)("id_comp_contact_to").ToString
            TECompName.Text = get_company_x(get_id_company(id_comp_to), "1")
            TECompCode.Text = get_company_x(get_id_company(id_comp_to), "2")
            MECompAddress.Text = get_company_x(get_id_company(id_comp_to), "3")
            TECompAttn.Text = get_company_contact_x(id_comp_to, "1")

            id_comp_ship_to = data.Rows(0)("id_comp_contact_ship_to").ToString
            TECompShipToName.Text = get_company_x(get_id_company(id_comp_ship_to), "1")
            TECompShipTo.Text = get_company_x(get_id_company(id_comp_ship_to), "2")
            MECompShipToAddress.Text = get_company_x(get_id_company(id_comp_ship_to), "3")

            MENote.Text = data.Rows(0)("mat_purc_note").ToString

            date_created = data.Rows(0)("mat_purc_datex").ToString
            TEDate.Text = view_date_from(date_created, 0)
            TELeadTime.Text = data.Rows(0)("mat_purc_lead_time").ToString
            TERecDate.Text = view_date_from(date_created, Integer.Parse(data.Rows(0)("mat_purc_lead_time").ToString))
            TETOP.Text = data.Rows(0)("mat_purc_top").ToString
            TEDueDate.Text = view_date_from(date_created, (Integer.Parse(data.Rows(0)("mat_purc_lead_time").ToString) + Integer.Parse(data.Rows(0)("mat_purc_top").ToString)))
            '
            GConListPurchase.Enabled = True
            TEVat.Properties.ReadOnly = False
            view_list_purchase(id_purc)
            TEVat.Text = data.Rows(0)("mat_purc_vat").ToString
            calculate()
        End If

        allow_status()
    End Sub
    Sub action_load_sub(ByVal id_old_po As String)
        Dim query As String = String.Format("SELECT mat_purc_kurs,id_report_status,mat_purc_vat,id_delivery,mat_purc_number,id_comp_contact_to,id_comp_contact_ship_to,id_po_type,id_payment,DATE_FORMAT(mat_purc_date,'%Y-%m-%d') as mat_purc_datex,mat_purc_lead_time,mat_purc_top,id_currency,mat_purc_note FROM tb_mat_purc WHERE id_mat_purc = '{0}'", id_old_po)
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")

        TEKurs.Text = data.Rows(0)("mat_purc_kurs").ToString

        LECurrency.ItemIndex = LECurrency.Properties.GetDataSourceRowIndex("id_currency", data.Rows(0)("id_currency").ToString)

        LEpayment.ItemIndex = LEpayment.Properties.GetDataSourceRowIndex("id_payment", data.Rows(0)("id_payment").ToString)

        LESeason.EditValue = get_id_season(data.Rows(0)("id_delivery").ToString)
        LEDelivery.EditValue = data.Rows(0)("id_delivery").ToString

        LEPOType.EditValue = data.Rows(0)("id_po_type").ToString()

        id_comp_to = data.Rows(0)("id_comp_contact_to").ToString
        TECompName.Text = get_company_x(get_id_company(id_comp_to), "1")
        TECompCode.Text = get_company_x(get_id_company(id_comp_to), "2")
        MECompAddress.Text = get_company_x(get_id_company(id_comp_to), "3")
        TECompAttn.Text = get_company_contact_x(id_comp_to, "1")

        id_comp_ship_to = data.Rows(0)("id_comp_contact_ship_to").ToString
        TECompShipToName.Text = get_company_x(get_id_company(id_comp_ship_to), "1")
        TECompShipTo.Text = get_company_x(get_id_company(id_comp_ship_to), "2")
        MECompShipToAddress.Text = get_company_x(get_id_company(id_comp_ship_to), "3")

        MENote.Text = data.Rows(0)("mat_purc_note").ToString

        date_created = data.Rows(0)("mat_purc_datex").ToString
        TEDate.Text = view_date_from(date_created, 0)
        TELeadTime.Text = data.Rows(0)("mat_purc_lead_time").ToString
        TERecDate.Text = view_date_from(date_created, Integer.Parse(data.Rows(0)("mat_purc_lead_time").ToString))
        TETOP.Text = data.Rows(0)("mat_purc_top").ToString
        TEDueDate.Text = view_date_from(date_created, (Integer.Parse(data.Rows(0)("mat_purc_lead_time").ToString) + Integer.Parse(data.Rows(0)("mat_purc_top").ToString)))
        '
        GConListPurchase.Enabled = True
        TEVat.Properties.ReadOnly = False
        view_list_purchase(id_old_po)
        TEVat.Text = data.Rows(0)("mat_purc_vat").ToString
        calculate()
    End Sub

    Sub view_delivery(ByVal id_season As String, ByVal lookup As DevExpress.XtraEditors.SearchLookUpEdit)
        Dim query As String = "SELECT id_delivery,delivery FROM tb_season_delivery WHERE id_season='" & id_season & "' ORDER BY id_delivery DESC"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")

        lookup.Properties.DataSource = Nothing
        lookup.Properties.DataSource = data

        lookup.Properties.DisplayMember = "delivery"
        lookup.Properties.ValueMember = "id_delivery"
        If data.Rows.Count > 0 Then
            lookup.EditValue = data.Rows(0)("id_delivery").ToString
        End If
    End Sub

    Sub view_list_purchase(ByVal id_purcx As String)
        Dim query = "CALL view_mat_purc_det('" & id_purcx & "')"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCListPurchase.DataSource = data
        GVListPurchase.BestFitColumns()
        show_but()
        calculate()
    End Sub

    Private Sub view_currency(ByVal lookup As DevExpress.XtraEditors.LookUpEdit)
        Dim query As String = "SELECT id_currency,currency FROM tb_lookup_currency"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")

        lookup.Properties.DataSource = data

        lookup.Properties.DisplayMember = "currency"
        lookup.Properties.ValueMember = "id_currency"
        lookup.ItemIndex = 0
    End Sub
    Private Sub view_report_status(ByVal lookup As DevExpress.XtraEditors.LookUpEdit)
        Dim query As String = "SELECT id_report_status,report_status FROM tb_lookup_report_status"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")

        lookup.Properties.DataSource = data

        lookup.Properties.DisplayMember = "report_status"
        lookup.Properties.ValueMember = "id_report_status"
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
    Private Sub viewSeason(ByVal lookup As DevExpress.XtraEditors.SearchLookUpEdit)
        Dim query As String = "SELECT id_season,season FROM tb_season ORDER BY id_season DESC"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")

        lookup.Properties.DataSource = Nothing
        lookup.Properties.DataSource = data

        lookup.Properties.DisplayMember = "season"
        lookup.Properties.ValueMember = "id_season"

        If data.Rows.Count > 0 Then
            lookup.EditValue = data.Rows(0)("id_season").ToString
            view_delivery(data.Rows(0)("id_season").ToString, LEDelivery)
        End If
    End Sub

    Private Sub BSearchCompTo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BSearchCompTo.Click
        FormPopUpContact.id_pop_up = "14"
        FormPopUpContact.ShowDialog()
    End Sub

    Private Sub BSearchCompShipTo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BSearchCompShipTo.Click
        FormPopUpContact.id_pop_up = "15"
        FormPopUpContact.ShowDialog()
    End Sub

    Private Sub BSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BSave.Click
        Dim kurs, err_txt, query, po_typex, po_number, lead_time, top, payment_type, id_delivery, id_currency, notex, vat, id_purc_new As String
        err_txt = "-1"

        po_typex = LEPOType.EditValue
        payment_type = LEpayment.EditValue
        id_delivery = LEDelivery.EditValue
        id_currency = LECurrency.EditValue
        po_number = TEPONumber.Text
        lead_time = TELeadTime.Text
        top = TETOP.Text
        notex = MENote.Text
        kurs = TEKurs.EditValue
        vat = TEVat.EditValue

        ValidateChildren()
        If id_comp_to = "-1" Or id_comp_ship_to = "-1" Then
            stopCustom("Please fill all field.")
        Else
            If id_purc <> "-1" Then
                'edit
                Try
                    If id_rev = "-1" Then 'normal
                        query = String.Format("UPDATE tb_mat_purc SET id_delivery='{0}',mat_purc_number='{1}',id_comp_contact_to='{2}',id_comp_contact_ship_to='{3}',id_po_type='{4}',id_payment='{5}',mat_purc_lead_time='{6}',mat_purc_top='{7}',id_currency='{8}',mat_purc_note='{9}',mat_purc_vat='{10}',mat_purc_kurs='{12}',id_mat_purc_rev=NULL WHERE id_mat_purc='{11}'", id_delivery, po_number, id_comp_to, id_comp_ship_to, po_typex, payment_type, lead_time, top, id_currency, notex, vat, id_purc, kurs)
                    Else
                        query = String.Format("UPDATE tb_mat_purc SET id_delivery='{0}',mat_purc_number='{1}',id_comp_contact_to='{2}',id_comp_contact_ship_to='{3}',id_po_type='{4}',id_payment='{5}',mat_purc_lead_time='{6}',mat_purc_top='{7}',id_currency='{8}',mat_purc_note='{9}',mat_purc_vat='{10}',mat_purc_kurs='{12}',id_mat_purc_rev='{13}' WHERE id_mat_purc='{11}'", id_delivery, po_number, id_comp_to, id_comp_ship_to, po_typex, payment_type, lead_time, top, id_currency, notex, vat, id_purc, kurs, id_rev)
                    End If

                    execute_non_query(query, True, "", "", "", "")
                    'delete first
                    Dim sp_check As Boolean = False
                    Dim query_del As String = "SELECT id_mat_purc_det FROM tb_mat_purc_det WHERE id_mat_purc='" & id_purc & "'"
                    Dim data_del As DataTable = execute_query(query_del, -1, True, "", "", "", "")
                    If data_del.Rows.Count > 0 Then
                        For i As Integer = 0 To data_del.Rows.Count - 1
                            sp_check = False
                            ' false mean not found, believe me
                            For j As Integer = 0 To GVListPurchase.RowCount - 1
                                If Not GVListPurchase.GetRowCellValue(j, "id_mat_purc_det").ToString = "" Then
                                    '
                                    If GVListPurchase.GetRowCellValue(j, "id_mat_purc_det").ToString = data_del.Rows(i)("id_mat_purc_det").ToString() Then
                                        sp_check = True
                                    End If
                                End If
                            Next
                            'end loop check on gv
                            If sp_check = False Then
                                'Because not found, it's only mean already deleted
                                query = String.Format("DELETE FROM tb_mat_purc_det WHERE id_mat_purc_det='{0}'", data_del.Rows(i)("id_mat_purc_det").ToString())
                                execute_non_query(query, True, "", "", "", "")
                            End If
                        Next
                    End If

                    For i As Integer = 0 To GVListPurchase.RowCount - 1
                        If Not GVListPurchase.GetRowCellValue(i, "id_mat_det_price").ToString = "" Then
                            If GVListPurchase.GetRowCellValue(i, "id_mat_purc_det").ToString = "" Then
                                'insert new
                                query = String.Format("INSERT INTO tb_mat_purc_det(id_mat_purc,id_mat_det_price,mat_purc_det_price,mat_purc_det_discount,mat_purc_det_qty,mat_purc_det_note) VALUES('{0}','{1}','{2}','{3}','{4}','{5}')", id_purc, GVListPurchase.GetRowCellValue(i, "id_mat_det_price").ToString, decimalSQL(GVListPurchase.GetRowCellValue(i, "price").ToString), decimalSQL(GVListPurchase.GetRowCellValue(i, "discount").ToString), decimalSQL(GVListPurchase.GetRowCellValue(i, "qty").ToString), GVListPurchase.GetRowCellValue(i, "note").ToString)
                                execute_non_query(query, True, "", "", "", "")
                            Else
                                'update
                                query = String.Format("UPDATE tb_mat_purc_det SET id_mat_det_price='{0}',mat_purc_det_price='{1}',mat_purc_det_discount='{2}',mat_purc_det_qty='{3}',mat_purc_det_note='{4}' WHERE id_mat_purc_det='{5}'", GVListPurchase.GetRowCellValue(i, "id_mat_det_price").ToString, decimalSQL(GVListPurchase.GetRowCellValue(i, "price").ToString), decimalSQL(GVListPurchase.GetRowCellValue(i, "discount").ToString), decimalSQL(GVListPurchase.GetRowCellValue(i, "qty").ToString), GVListPurchase.GetRowCellValue(i, "note").ToString, GVListPurchase.GetRowCellValue(i, "id_mat_purc_det").ToString)
                                execute_non_query(query, True, "", "", "", "")
                            End If
                        End If
                    Next
                    FormMatPurchase.view_mat_purc()
                    FormMatPurchase.GVMatPurchase.ExpandAllGroups()
                    FormMatPurchase.GVMatPurchase.FocusedRowHandle = find_row(FormMatPurchase.GVMatPurchase, "id_mat_purc", id_purc)
                    Close()
                Catch ex As Exception
                    errorConnection()
                End Try
            Else
                'new
                Try
                    'insert 
                    If id_rev = "-1" Then 'normal
                        query = String.Format("INSERT INTO tb_mat_purc(id_delivery,mat_purc_number,id_comp_contact_to,id_comp_contact_ship_to,id_po_type,id_payment,mat_purc_date,mat_purc_lead_time,mat_purc_top,id_currency,mat_purc_note,mat_purc_vat,mat_purc_kurs) VALUES('{0}','{1}','{2}','{3}','{4}','{5}',DATE(NOW()),'{6}','{7}','{8}','{9}','{10}','{11}'); SELECT LAST_INSERT_ID()", id_delivery, po_number, id_comp_to, id_comp_ship_to, po_typex, payment_type, lead_time, top, id_currency, notex, vat, kurs)
                    Else 'revision
                        query = String.Format("INSERT INTO tb_mat_purc(id_delivery,mat_purc_number,id_comp_contact_to,id_comp_contact_ship_to,id_po_type,id_payment,mat_purc_date,mat_purc_lead_time,mat_purc_top,id_currency,mat_purc_note,mat_purc_vat,mat_purc_kurs,id_mat_purc_rev) VALUES('{0}','{1}','{2}','{3}','{4}','{5}',DATE(NOW()),'{6}','{7}','{8}','{9}','{10}','{11}','{12}'); SELECT LAST_INSERT_ID()", id_delivery, po_number, id_comp_to, id_comp_ship_to, po_typex, payment_type, lead_time, top, id_currency, notex, vat, kurs, id_rev)
                    End If

                    'execute_non_query(query, True, "", "", "", "")
                    ''
                    'query = ""
                    id_purc_new = execute_query(query, 0, True, "", "", "", "")
                    '
                    insert_who_prepared("13", id_purc_new, id_user)

                    increase_inc_mat("1")
                    For i As Integer = 0 To GVListPurchase.RowCount - 1
                        If Not GVListPurchase.GetRowCellValue(i, "id_mat_det_price").ToString = "" Then
                            'dp
                            query = String.Format("INSERT INTO tb_mat_purc_det(id_mat_purc,id_mat_det_price,mat_purc_det_price,mat_purc_det_discount,mat_purc_det_qty,mat_purc_det_note) VALUES('{0}','{1}','{2}','{3}','{4}','{5}')", id_purc_new, GVListPurchase.GetRowCellValue(i, "id_mat_det_price").ToString, decimalSQL(GVListPurchase.GetRowCellValue(i, "price").ToString), decimalSQL(GVListPurchase.GetRowCellValue(i, "discount").ToString), decimalSQL(GVListPurchase.GetRowCellValue(i, "qty").ToString), GVListPurchase.GetRowCellValue(i, "note").ToString)
                            execute_non_query(query, True, "", "", "", "")
                        End If
                    Next
                    FormMatPurchase.view_mat_purc()
                    FormMatPurchase.GVMatPurchase.ExpandAllGroups()
                    FormMatPurchase.GVMatPurchase.FocusedRowHandle = find_row(FormMatPurchase.GVMatPurchase, "id_mat_purc", id_purc_new)
                    Close()
                Catch ex As Exception
                    errorConnection()
                End Try
            End If
        End If
    End Sub

    Private Sub TEPONumber_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TEPONumber.Validating
        Dim query_jml As String
        query_jml = String.Format("SELECT COUNT(id_mat_purc) FROM tb_mat_purc WHERE mat_purc_number='{0}' AND id_mat_purc!='{1}'", TEPONumber.Text, id_purc)
        Dim jml As Integer = execute_query(query_jml, 0, True, "", "", "", "")
        If Not jml < 1 Then
            EP_TE_already_used(EPMatPurc, TEPONumber, "1")
        Else
            EP_TE_cant_blank(EPMatPurc, TEPONumber)
        End If
    End Sub

    Private Sub TELeadTime_EditValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TELeadTime.EditValueChanged
        If id_purc <> "-1" Then
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
        If id_purc <> "-1" Then
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
            If id_purc <> "-1" Then
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
        FormMatPurchaseSingle.ShowDialog()
    End Sub

    Sub calculate()
        Dim total, sub_tot, gross_tot, vat, discount As Decimal

        Try
            sub_tot = GVListPurchase.Columns("total").SummaryItem.SummaryValue
            vat = (TEVat.EditValue / 100) * GVListPurchase.Columns("total").SummaryItem.SummaryValue
            discount = GVListPurchase.Columns("discount").SummaryItem.SummaryValue
        Catch ex As Exception
        End Try

        TEDiscount.EditValue = discount
        TEVatTot.EditValue = vat

        gross_tot = sub_tot + discount
        TEGrossTot.EditValue = gross_tot

        total = sub_tot + vat
        TETot.EditValue = total
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
        FormMatPurchaseSingle.id_mat_price = GVListPurchase.GetFocusedRowCellValue("id_mat_det_price").ToString
        FormMatPurchaseSingle.id_mat_purc_det = GVListPurchase.GetFocusedRowCellValue("id_mat_purc_det").ToString
        FormMatPurchaseSingle.TEQty.EditValue = GVListPurchase.GetFocusedRowCellValue("qty")
        FormMatPurchaseSingle.TENote.EditValue = GVListPurchase.GetFocusedRowCellValue("note")
        FormMatPurchaseSingle.ShowDialog()
    End Sub

    Private Sub BPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BPrint.Click
        'ReportMatPurchase.id_mat_purc = id_purc

        'Dim Report As New ReportMatPurchase()
        '' Show the report's preview. 
        'Dim Tool As DevExpress.XtraReports.UI.ReportPrintTool = New DevExpress.XtraReports.UI.ReportPrintTool(Report)
        'Tool.ShowPreview()

        Cursor = Cursors.WaitCursor
        ReportMatPurchase.dt = GCListPurchase.DataSource
        ReportMatPurchase.id_mat_purc = id_purc
        'ReportMatPurchase.is_pre = "1"
        Dim Report As New ReportMatPurchase()
        '
        GridColumnColor.Visible = False
        GridColumnDiscount.Visible = False
        GVListPurchase.BestFitColumns()
        '
        ' '... 
        ' ' creating and saving the view's layout to a new memory stream 
        Dim str As System.IO.Stream
        str = New System.IO.MemoryStream()
        GVListPurchase.SaveLayoutToStream(str, DevExpress.Utils.OptionsLayoutBase.FullLayout)
        str.Seek(0, System.IO.SeekOrigin.Begin)
        Report.GVListPurchase.RestoreLayoutFromStream(str, DevExpress.Utils.OptionsLayoutBase.FullLayout)
        str.Seek(0, System.IO.SeekOrigin.Begin)

        'Grid Detail
        ReportStyleGridview(Report.GVListPurchase)
        '
        Report.GVListPurchase.AppearancePrint.Row.Font = New Font("Tahoma", 8, FontStyle.Regular)

        '
        'Parse val
        Report.LPORev.Text = TEPORevNumber.Text
        Report.LPONumber.Text = TEPONumber.Text

        Report.LPODate.Text = TEDate.Text
        Report.LLeadTime.Text = TELeadTime.Text
        Report.LRecDate.Text = TERecDate.Text
        Report.LTOP.Text = TETOP.Text
        Report.LDueDate.Text = TEDueDate.Text

        Report.LToName.Text = TECompName.Text
        Report.LToAddress.Text = MECompAddress.Text
        Report.LToAttn.Text = TECompAttn.Text

        Report.LShipToName.Text = TECompShipToName.Text
        Report.LShipToAddress.Text = MECompShipToAddress.Text

        Report.LTax.Text = get_company_x(get_id_company(id_comp_ship_to), "4")
        Report.LNPWMP.Text = get_company_x(get_id_company(id_comp_ship_to), "5")

        Report.LRange.Text = get_range_x(get_id_range(get_id_season(LEDelivery.EditValue.ToString)), "1")
        Report.LSeason.Text = LESeason.Text
        Report.LDelivery.Text = LEDelivery.Text

        Report.LPayment.Text = LEpayment.Text
        Report.LPOType.Text = LEPOType.Text
        '    id_cur = data.Rows(0)("id_currency").ToString
        Report.LCur.Text = LECurrency.Text
        Report.LKurs.Text = TEKurs.Text
        Report.LVat.Text = TEVat.Text
        Report.LDiscount.Text = TEDiscount.Text
        Report.LVatTot.Text = TEVatTot.Text

        '    gross_tot = sub_tot + discount
        Report.LGrossTot.Text = TEGrossTot.Text

        '    total = sub_tot + vat
        Report.LTot.Text = TETot.Text
        Report.LSay.Text = METotSay.Text.ToString
        Report.LNote.Text = MENote.Text

        'Show the report's preview. 
        Dim Tool As DevExpress.XtraReports.UI.ReportPrintTool = New DevExpress.XtraReports.UI.ReportPrintTool(Report)
        Tool.ShowPreview()
        '
        GridColumnColor.Visible = True
        GridColumnDiscount.Visible = True
        '
        Cursor = Cursors.Default
    End Sub

    Private Sub Bdel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Bdel.Click
        Dim confirm As DialogResult
        confirm = DevExpress.XtraEditors.XtraMessageBox.Show("Are you sure want to delete this material on list?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)

        If confirm = Windows.Forms.DialogResult.Yes Then
            Cursor = Cursors.WaitCursor
            Try
                GVListPurchase.DeleteSelectedRows()
                calculate()
                show_but()
            Catch ex As Exception
                DevExpress.XtraEditors.XtraMessageBox.Show("This material on list already used.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
            Cursor = Cursors.Default
        End If
    End Sub

    Private Sub BMark_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BMark.Click
        FormReportMark.id_report = id_purc
        FormReportMark.report_mark_type = "13"
        FormReportMark.ShowDialog()
    End Sub

    Private Sub BCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BCancel.Click
        Close()
    End Sub
    Sub allow_status()
        If check_edit_report_status(id_report_status_g, "13", id_purc) Then
            BAdd.Enabled = True
            BEdit.Enabled = True
            Bdel.Enabled = True
            BSave.Enabled = True
            LEPOType.Enabled = True
            '
            BSearchCompTo.Enabled = True
            BSearchCompShipTo.Enabled = True
            BPickPORev.Enabled = True
        Else
            BAdd.Enabled = False
            BEdit.Enabled = False
            Bdel.Enabled = False
            BSave.Enabled = False
            LEPOType.Enabled = False
            '
            BSearchCompTo.Enabled = False
            BSearchCompShipTo.Enabled = False
            BPickPORev.Enabled = False
        End If

        If check_print_report_status(id_report_status_g) Then
            BPrint.Enabled = True
        Else
            BPrint.Enabled = False
        End If
    End Sub
    Sub show_but()
        If GVListPurchase.RowCount > 0 Then
            BEdit.Visible = True
            Bdel.Visible = True
        Else
            BEdit.Visible = False
            Bdel.Visible = False
        End If
    End Sub

    Private Sub LESeason_EditValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LESeason.EditValueChanged
        view_delivery(LESeason.EditValue, LEDelivery)
    End Sub

    Private Sub BPickPORev_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BPickPORev.Click
        FormPopUpPurchaseMat.id_pop_up = "5"
        FormPopUpPurchaseMat.id_purc = id_rev
        FormPopUpPurchaseMat.ShowDialog()
    End Sub

    Private Sub BtnAttachment_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnAttachment.Click
        Cursor = Cursors.WaitCursor
        FormDocumentUpload.id_report = id_purc
        FormDocumentUpload.report_mark_type = "13"
        FormDocumentUpload.ShowDialog()
        Cursor = Cursors.Default
    End Sub

    Private Sub BPrePrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BPrePrint.Click
        Cursor = Cursors.WaitCursor
        ReportMatPurchase.dt = GCListPurchase.DataSource
        ReportMatPurchase.id_mat_purc = id_purc
        ReportMatPurchase.is_pre = "1"
        Dim Report As New ReportMatPurchase()

        ' '... 
        GridColumnDiscount.Visible = False
        GVListPurchase.BestFitColumns()
        ' ' creating and saving the view's layout to a new memory stream 
        Dim str As System.IO.Stream
        str = New System.IO.MemoryStream()
        GVListPurchase.SaveLayoutToStream(str, DevExpress.Utils.OptionsLayoutBase.FullLayout)
        str.Seek(0, System.IO.SeekOrigin.Begin)
        Report.GVListPurchase.RestoreLayoutFromStream(str, DevExpress.Utils.OptionsLayoutBase.FullLayout)
        str.Seek(0, System.IO.SeekOrigin.Begin)

        'Grid Detail
        ReportStyleGridview(Report.GVListPurchase)
        '
        Report.GVListPurchase.AppearancePrint.Row.Font = New Font("Tahoma", 8, FontStyle.Regular)
        'Parse val
        Report.LPORev.Text = TEPORevNumber.Text
        Report.LPONumber.Text = TEPONumber.Text

        Report.LPODate.Text = TEDate.Text
        Report.LLeadTime.Text = TELeadTime.Text
        Report.LRecDate.Text = TERecDate.Text
        Report.LTOP.Text = TETOP.Text
        Report.LDueDate.Text = TEDueDate.Text

        Report.LToName.Text = TECompName.Text
        Report.LToAddress.Text = MECompAddress.Text
        Report.LToAttn.Text = TECompAttn.Text

        Report.LShipToName.Text = TECompShipToName.Text
        Report.LShipToAddress.Text = MECompShipToAddress.Text

        Report.LTax.Text = get_company_x(get_id_company(id_comp_ship_to), "4")
        Report.LNPWMP.Text = get_company_x(get_id_company(id_comp_ship_to), "5")

        Report.LRange.Text = get_range_x(get_id_range(get_id_season(LEDelivery.EditValue.ToString)), "1")
        Report.LSeason.Text = LESeason.Text
        Report.LDelivery.Text = LEDelivery.Text

        Report.LPayment.Text = LEpayment.Text
        Report.LPOType.Text = LEPOType.Text

        'id_cur = data.Rows(0)("id_currency").ToString
        Report.LCur.Text = LECurrency.Text
        Report.LKurs.Text = TEKurs.Text
        Report.LVat.Text = TEVat.Text
        Report.LDiscount.Text = TEDiscount.Text
        Report.LVatTot.Text = TEVatTot.Text

        'gross_tot = sub_tot + discount
        Report.LGrossTot.Text = TEGrossTot.Text

        'total = sub_tot + vat
        Report.LTot.Text = TETot.Text
        Report.LSay.Text = METotSay.Text.ToString
        Report.LNote.Text = MENote.Text

        'Show the report's preview. 
        Dim Tool As DevExpress.XtraReports.UI.ReportPrintTool = New DevExpress.XtraReports.UI.ReportPrintTool(Report)
        Tool.ShowPreview()

        GridColumnColor.Visible = True
        GridColumnDiscount.Visible = True

        Cursor = Cursors.Default
    End Sub

    Private Sub LECurrency_EditValueChanged(sender As Object, e As EventArgs) Handles LECurrency.EditValueChanged
        calculate()
    End Sub
End Class