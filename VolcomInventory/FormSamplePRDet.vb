Public Class FormSamplePRDet
    Public id_rec As String = "-1"
    Public id_purc As String = "-1"
    Public id_pr As String = "-1"
    Public id_comp_contact_pay_to As String = "-1"

    Private Sub FormSamplePRDet_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'checkFormAccess(Name)
        DEPIBKDate.EditValue = Now
        If id_purc = "-1" Then
            view_currency(LECurrency)
        Else
            view_po()
            view_list_purchase()
            GConListPurchase.Enabled = True
        End If

        If Not id_rec = "-1" Then
            view_rec()
            view_po()
            view_list_rec()
            GConListPurchase.Enabled = True
        End If

        view_report_status(LEReportStatus)

        If id_pr = "-1" Then
            'new
            TEPRDate.Text = view_date(0)
            TEPRNumber.Text = header_number("4")
            BPrint.Visible = False
            BMark.Visible = False
            BPrePrint.Visible = False
        Else
            'edit
            Dim query As String = "SELECT z.pibk_no,z.pibk_date,z.inv_no,z.pr_sample_purc_dp,z.pr_sample_purc_vat,z.id_pr_sample_purc,z.id_comp_contact_to,z.id_report_status,z.pr_sample_purc_number,z.pr_sample_purc_note,DATE_FORMAT(z.pr_sample_purc_date,'%Y-%m-%d') as pr_sample_purc_date,g.season_orign,a.id_sample_purc_rec,a.sample_purc_rec_number,a.delivery_order_number,b.sample_purc_number,DATE_FORMAT(a.sample_purc_rec_date,'%d %M %Y') AS sample_purc_rec_date,d.comp_name AS comp_to,b.id_sample_purc "
            query += "FROM tb_pr_sample_purc z "
            query += "LEFT JOIN tb_sample_purc_rec a ON z.id_sample_purc_rec = a.id_sample_purc_rec "
            query += "INNER JOIN tb_sample_purc b ON z.id_sample_purc=b.id_sample_purc "
            query += "INNER JOIN tb_m_comp_contact c ON c.id_comp_contact=z.id_comp_contact_to "
            query += "INNER JOIN tb_m_comp d ON d.id_comp=c.id_comp "
            query += "INNER JOIN tb_season_orign g ON g.id_season_orign=b.id_season_orign "
            query += "WHERE z.id_pr_sample_purc ='" & id_pr & "' "

            Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")

            TEPRNumber.Text = data.Rows(0)("pr_sample_purc_number").ToString
            TEPRDate.Text = view_date_from(data.Rows(0)("pr_sample_purc_date").ToString, 0)
            MENote.Text = data.Rows(0)("pr_sample_purc_note").ToString
            '
            LEReportStatus.EditValue = Nothing
            LEReportStatus.ItemIndex = LEReportStatus.Properties.GetDataSourceRowIndex("id_report_status", data.Rows(0)("id_report_status").ToString)

            TEDONumber.Text = data.Rows(0)("delivery_order_number").ToString
            TERecNumber.Text = data.Rows(0)("sample_purc_rec_number").ToString

            id_purc = data.Rows(0)("id_sample_purc").ToString
            view_po()

            id_comp_contact_pay_to = data.Rows(0)("id_comp_contact_to").ToString
            TECompTo.Text = get_company_x(get_id_company(data.Rows(0)("id_comp_contact_to").ToString), "1")
            MECompAddress.Text = get_company_x(get_id_company(data.Rows(0)("id_comp_contact_to").ToString), "3")

            GConListPurchase.Enabled = True
            view_list_pr()
            '
            TEPIBKNo.Text = data.Rows(0)("pibk_no").ToString
            DEPIBKDate.EditValue = data.Rows(0)("pibk_date")
            TEInvNo.Text = data.Rows(0)("inv_no").ToString
            '
            TEVat.Text = data.Rows(0)("pr_sample_purc_vat").ToString

            TEDPTot.Text = data.Rows(0)("pr_sample_purc_dp").ToString

            calculate()

            If Not Decimal.Parse(data.Rows(0)("pr_sample_purc_dp").ToString) <= 0 And Not Decimal.Parse(TEGrossTot.EditValue) <= 0 Then
                TEDP.Text = ((Decimal.Parse(data.Rows(0)("pr_sample_purc_dp").ToString) / Decimal.Parse(TEGrossTot.EditValue)) * 100).ToString("0")
            End If

            BShowOrder.Enabled = False
            BPickPO.Enabled = False
        End If
        allow_status()
    End Sub

    Private Sub BShowOrder_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BShowOrder.Click
        FormPopUpReceive.id_pop_up = "2"
        FormPopUpReceive.id_purc = id_purc
        FormPopUpReceive.ShowDialog()
    End Sub

    Private Sub BPickContact_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BPickContact.Click
        FormPopUpContact.id_pop_up = "6"
        FormPopUpContact.ShowDialog()
    End Sub
    Sub view_list_purchase()
        Dim query = "CALL view_pr_sample_from_po('" & id_purc & "')"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCListPurchase.DataSource = data

        If data.Rows.Count > 0 Then
            calculate()
        End If
    End Sub

    Sub view_list_pr()
        Dim query = "CALL view_pr_sample_from_pr('" & id_pr & "')"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCListPurchase.DataSource = data

        If data.Rows.Count > 0 Then
            calculate()
        End If
    End Sub

    Sub view_list_rec()
        Dim query = "CALL view_pr_sample_from_rec('" & id_rec & "')"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCListPurchase.DataSource = data

        If data.Rows.Count > 0 Then
            calculate()
        End If
    End Sub

    Sub view_po()
        Dim query As String = String.Format("SELECT id_report_status,sample_purc_vat,id_season_orign,sample_purc_number,id_comp_contact_to,id_comp_contact_ship_to,id_po_type,id_payment,DATE_FORMAT(sample_purc_date,'%Y-%m-%d') as sample_purc_datex,sample_purc_lead_time,sample_purc_top,id_currency,sample_purc_note FROM tb_sample_purc WHERE id_sample_purc = '{0}'", id_purc)
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")

        TEPONumber.Text = data.Rows(0)("sample_purc_number").ToString

        view_currency(LECurrency)
        LECurrency.EditValue = Nothing
        LECurrency.ItemIndex = LECurrency.Properties.GetDataSourceRowIndex("id_currency", data.Rows(0)("id_currency").ToString)
        LECurrency.Enabled = False

        id_comp_contact_pay_to = data.Rows(0)("id_comp_contact_to").ToString
        TECompTo.Text = get_company_x(get_id_company(data.Rows(0)("id_comp_contact_to").ToString), "1")
        MECompAddress.Text = get_company_x(get_id_company(data.Rows(0)("id_comp_contact_to").ToString), "3")

        TEDueDate.Text = view_date_from(data.Rows(0)("sample_purc_datex").ToString, (Integer.Parse(data.Rows(0)("sample_purc_lead_time").ToString) + Integer.Parse(data.Rows(0)("sample_purc_top").ToString)))
        TEVat.Text = data.Rows(0)("sample_purc_vat").ToString
    End Sub

    Sub view_rec()
        Dim query As String = "SELECT d.id_sample_purc,a.id_sample_purc_rec, a.sample_purc_rec_number, a.delivery_order_number,  a.delivery_order_date, a.sample_purc_rec_date, "
        query += "(SELECT COUNT(tb_pr_sample_purc.id_pr_sample_purc) FROM tb_pr_sample_purc WHERE tb_pr_sample_purc.id_sample_purc_rec = a.id_sample_purc_rec) AS pr_created, "
        query += "a.sample_purc_rec_note, c.comp_name, c.comp_number,e.season_orign, a.id_comp_contact_to  "
        query += "FROM tb_sample_purc_rec a "
        query += "INNER JOIN tb_m_comp_contact b ON a.id_comp_contact_to = b.id_comp_contact "
        query += "INNER JOIN tb_m_comp c ON b.id_comp = c.id_comp "
        query += "INNER join tb_sample_purc d on a.id_sample_purc = d.id_sample_purc "
        query += "INNER JOIN tb_season_orign e ON e.id_season_orign = d.id_season_orign "
        query += "WHERE a.id_sample_purc_rec = '" & id_rec & "'"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")

        TERecNumber.Text = data.Rows(0)("sample_purc_rec_number").ToString
        id_purc = data.Rows(0)("id_sample_purc").ToString
        TEPONumber.Text = data.Rows(0)("sample_purc_rec_number").ToString
        TEDONumber.Text = data.Rows(0)("delivery_order_number").ToString
        TECompTo.Text = data.Rows(0)("comp_name").ToString
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

    Sub calculate()
        Dim tot_credit, tot_debit, total, gross_tot, vat, dp As Decimal

        Try
            tot_credit = GVListPurchase.Columns("total").SummaryItem.SummaryValue
            tot_debit = GVListPurchase.Columns("debit").SummaryItem.SummaryValue
            gross_tot = tot_credit - tot_debit
            dp = TEDPTot.EditValue

            If dp <= 0 Or dp.ToString = "" Then
                vat = (TEVat.EditValue / 100) * gross_tot
            Else
                vat = (TEVat.EditValue / 100) * dp
            End If
        Catch ex As Exception
        End Try

        TEVatTot.EditValue = vat
        TEDPTot.EditValue = dp

        TEGrossTot.EditValue = gross_tot

        If dp.ToString = "" Or dp = 0 Then
            total = gross_tot + vat
        Else
            total = dp + vat
        End If

        TETot.EditValue = total

        Try
            METotSay.Text = ConvertCurrencyToEnglish(Double.Parse(total.ToString), LECurrency.EditValue.ToString)
        Catch ex As Exception
        End Try

    End Sub

    Private Sub GVListPurchase_CustomColumnDisplayText(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs) Handles GVListPurchase.CustomColumnDisplayText
        If e.Column.FieldName = "no" Then
            e.DisplayText = (e.ListSourceRowIndex + 1).ToString()
        End If
        If e.Column.FieldName = "total" Then
            If Not e.DisplayText = "" Then
                e.DisplayText = Decimal.Parse(e.DisplayText).ToString("N2")
            End If
        End If
        If e.Column.FieldName = "debit" Then
            If Not e.DisplayText = "" Then
                e.DisplayText = Decimal.Parse(e.DisplayText).ToString("N2")
            End If
        End If
    End Sub

    Private Sub FormSamplePRDet_FormClosed(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub TEPRNumber_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TEPRNumber.Validating
        Dim query_jml As String
        query_jml = String.Format("SELECT COUNT(id_pr_sample_purc) FROM tb_pr_sample_purc WHERE pr_sample_purc_number='{0}' AND id_pr_sample_purc!='{1}'", TEPRNumber.Text, id_pr)
        Dim jml As Integer = execute_query(query_jml, 0, True, "", "", "", "")
        If Not jml < 1 Then
            EP_TE_already_used(EPSamplePR, TEPRNumber, "1")
        Else
            EP_TE_cant_blank(EPSamplePR, TEPRNumber)
        End If
    End Sub

    Private Sub TEVat_EditValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TEVat.EditValueChanged
        calculate()
    End Sub

    Private Sub BPickPO_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BPickPO.Click
        FormPopUpPurchase.id_purc = id_purc
        FormPopUpPurchase.id_pop_up = "2"
        FormPopUpPurchase.ShowDialog()
    End Sub

    Private Sub BAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BAdd.Click
        If id_pr = "-1" Then
            FormPopUpPRComponent.id_purc = id_purc
            FormPopUpPRComponent.id_rec = id_rec
            FormPopUpPRComponent.ShowDialog()
        Else
            FormPopUpPRComponent.id_pr = id_pr
            FormPopUpPRComponent.id_purc = id_purc
            FormPopUpPRComponent.id_rec = id_rec
            FormPopUpPRComponent.ShowDialog()
        End If
    End Sub

    Sub show_but()
        If GVListPurchase.RowCount < 1 Then
            BEdit.Visible = False
            Bdel.Visible = False
        Else
            BEdit.Visible = True
            Bdel.Visible = True
        End If
    End Sub

    Private Sub Bdel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Bdel.Click
        If id_pr = "-1" Then
            GVListPurchase.DeleteSelectedRows()
        Else
            Dim confirm As DialogResult
            Dim query As String
            confirm = DevExpress.XtraEditors.XtraMessageBox.Show("Are you sure want to delete this item on list?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)

            Dim id_pr_sample_purc_det As String = GVListPurchase.GetFocusedRowCellDisplayText("id_pr_sample_purc_det").ToString
            If confirm = Windows.Forms.DialogResult.Yes Then
                Cursor = Cursors.WaitCursor
                Try
                    query = String.Format("DELETE FROM tb_pr_sample_purc_det WHERE id_pr_sample_purc_det = '{0}'", id_pr_sample_purc_det)
                    execute_non_query(query, True, "", "", "", "")
                    view_list_pr()
                Catch ex As Exception
                    DevExpress.XtraEditors.XtraMessageBox.Show("This list item can't be deleted.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End Try
                Cursor = Cursors.Default
            End If
        End If

        show_but()
    End Sub

    Private Sub TEDP_EditValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TEDP.EditValueChanged
        calculate_dp()
    End Sub

    Sub calculate_dp()
        Dim dp, gross_tot As Decimal

        Try
            gross_tot = Decimal.Parse(TEGrossTot.EditValue)
            dp = (Decimal.Parse(TEDP.EditValue) / 100) * gross_tot
        Catch ex As Exception
        End Try

        TEDPTot.Text = dp.ToString("0.00")
        calculate()
    End Sub

    Private Sub BSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BSave.Click
        Dim query As String = ""
        Dim err_txt As String = ""
        Dim pr_number, pr_date, pr_note, pr_stats, id_dc, inv_no, pibk_no, pibk_date As String
        Dim id_pr_new As String
        Dim pr_vat, pr_dp, pr_tot As Decimal
        pr_number = ""
        pr_date = ""
        pr_note = ""
        pr_stats = ""
        '
        inv_no = ""
        pibk_no = ""
        pibk_date = ""
        '
        pr_vat = 0.0
        pr_dp = 0.0
        pr_tot = 0.0

        'validasi
        Try
            pr_number = TEPRNumber.Text
            pr_date = TEPRDate.Text
            pr_note = MENote.Text
            pr_stats = LEReportStatus.EditValue
            pr_vat = TEVat.EditValue
            pr_dp = TEDPTot.EditValue
            pr_tot = TETot.EditValue
            '
            inv_no = TEInvNo.Text
            pibk_no = TEPIBKNo.Text
            pibk_date = Date.Parse(DEPIBKDate.EditValue.ToString).ToString("yyyy-MM-dd")
        Catch ex As Exception
            err_txt = "1"
        End Try

        For i As Integer = 0 To GVListPurchase.RowCount - 1
            Try
                If GVListPurchase.GetRowCellValue(i, "id_det").ToString = "" Then
                    err_txt = "1"
                End If
            Catch ex As Exception
            End Try
        Next

        'end of validasi
        If id_pr = "-1" Then
            'new
            If err_txt = "1" Or Not formIsValidInGroup(EPSamplePR, GroupGeneralHeader) Then
                errorInput()
            Else
                Try
                    'insert pr
                    query = String.Format("INSERT INTO tb_pr_sample_purc(id_sample_purc,id_sample_purc_rec,pr_sample_purc_number,pr_sample_purc_date,pr_sample_purc_note,id_report_status,pr_sample_purc_vat,pr_sample_purc_dp,pr_sample_purc_total,id_comp_contact_to,pibk_no,pibk_date,inv_no) VALUES('{0}','{1}','{2}',DATE(NOW()),'{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}','{11}');SELECT LAST_INSERT_ID();", id_purc, id_rec, pr_number, pr_note, pr_stats, decimalSQL(pr_vat.ToString), decimalSQL(pr_dp.ToString), decimalSQL(pr_tot.ToString), id_comp_contact_pay_to, pibk_no, pibk_date, inv_no)

                    id_pr_new = execute_query(query, 0, True, "", "", "", "")
                    'insert who prepared
                    insert_who_prepared("4", id_pr_new, id_user)
                    'end insert who prepared
                    '
                    increase_inc("4")
                    'pr detail
                    For i As Integer = 0 To GVListPurchase.RowCount - 1
                        Try
                            If Not GVListPurchase.GetRowCellValue(i, "id_det").ToString = "" Then
                                If GVListPurchase.GetRowCellValue(i, "total").ToString = "" Or GVListPurchase.GetRowCellValue(i, "total").ToString = "0" Then
                                    id_dc = 1
                                Else
                                    id_dc = 2
                                End If

                                If GVListPurchase.GetRowCellValue(i, "type").ToString = "1" Then
                                    'dp
                                    query = String.Format("INSERT INTO tb_pr_sample_purc_det(id_pr_sample_purc,id_pr_det_type,id_pr_sample_purc_dp,pr_sample_purc_det_note,pr_sample_purc_det_price,pr_sample_purc_det_qty,id_dc) VALUES('{0}','{1}','{2}','{3}','{4}','{5}','{6}')", id_pr_new, GVListPurchase.GetRowCellValue(i, "type").ToString, GVListPurchase.GetRowCellValue(i, "id_det").ToString, GVListPurchase.GetRowCellValue(i, "note").ToString, decimalSQL(GVListPurchase.GetRowCellValue(i, "price").ToString), decimalSQL(GVListPurchase.GetRowCellValue(i, "qty").ToString), id_dc)
                                    execute_non_query(query, True, "", "", "", "")
                                ElseIf GVListPurchase.GetRowCellValue(i, "type").ToString = "2" Then
                                    'purchase
                                    query = String.Format("INSERT INTO tb_pr_sample_purc_det(id_pr_sample_purc,id_pr_det_type,id_sample_purc_det,pr_sample_purc_det_note,pr_sample_purc_det_price,pr_sample_purc_det_qty,id_dc) VALUES('{0}','{1}','{2}','{3}','{4}','{5}','{6}')", id_pr_new, GVListPurchase.GetRowCellValue(i, "type").ToString, GVListPurchase.GetRowCellValue(i, "id_det").ToString, GVListPurchase.GetRowCellValue(i, "note").ToString, decimalSQL(GVListPurchase.GetRowCellValue(i, "price").ToString), decimalSQL(GVListPurchase.GetRowCellValue(i, "qty").ToString), id_dc)
                                    execute_non_query(query, True, "", "", "", "")
                                ElseIf GVListPurchase.GetRowCellValue(i, "type").ToString = "3" Then
                                    'ovh
                                    query = String.Format("INSERT INTO tb_pr_sample_purc_det(id_pr_sample_purc,id_pr_det_type,id_ovh,pr_sample_purc_det_note,pr_sample_purc_det_price,pr_sample_purc_det_qty,id_dc) VALUES('{0}','{1}','{2}','{3}','{4}','{5}','{6}')", id_pr_new, GVListPurchase.GetRowCellValue(i, "type").ToString, GVListPurchase.GetRowCellValue(i, "id_det").ToString, GVListPurchase.GetRowCellValue(i, "note").ToString, decimalSQL(GVListPurchase.GetRowCellValue(i, "price").ToString), decimalSQL(GVListPurchase.GetRowCellValue(i, "qty").ToString), id_dc)
                                    execute_non_query(query, True, "", "", "", "")
                                End If
                            End If
                        Catch ex As Exception
                            errorConnection()
                        End Try
                    Next

                    FormSamplePR.view_sample_pr()
                    FormSamplePR.GVSamplePR.FocusedRowHandle = find_row(FormSamplePR.GVSamplePR, "id_pr_sample_purc", id_pr_new)
                    Close()
                Catch ex As Exception
                    errorConnection()
                End Try
            End If
        Else
            'edit
            If err_txt = "1" Or Not formIsValidInGroup(EPSamplePR, GroupGeneralHeader) Then
                errorInput()
            Else
                Try
                    'update pr
                    query = String.Format("UPDATE tb_pr_sample_purc SET pr_sample_purc_number='{0}',pr_sample_purc_note='{1}',id_report_status='{2}',pr_sample_purc_vat='{4}',pr_sample_purc_dp='{5}',pr_sample_purc_total='{6}',id_comp_contact_to='{7}',pibk_no='{8}',pibk_date='{9}',inv_no='{10}' WHERE id_pr_sample_purc='{3}'", pr_number, pr_note, pr_stats, id_pr, decimalSQL(pr_vat.ToString), decimalSQL(pr_dp.ToString), decimalSQL(pr_tot.ToString), id_comp_contact_pay_to, pibk_no, pibk_date, inv_no)
                    execute_non_query(query, True, "", "", "", "")
                    'pr detail
                    For i As Integer = 0 To GVListPurchase.RowCount - 1
                        Try
                            If Not GVListPurchase.GetRowCellValue(i, "id_det").ToString = "" Then
                                query = String.Format("UPDATE tb_pr_sample_purc_det SET pr_sample_purc_det_note='{0}' WHERE id_pr_sample_purc_det='{1}'", GVListPurchase.GetRowCellValue(i, "note").ToString, GVListPurchase.GetRowCellValue(i, "id_pr_sample_purc_det").ToString)
                                execute_non_query(query, True, "", "", "", "")
                            End If
                        Catch ex As Exception
                        End Try
                    Next

                    FormSamplePR.view_sample_pr()
                    FormSamplePR.GVSamplePR.FocusedRowHandle = find_row(FormSamplePR.GVSamplePR, "id_pr_sample_purc", id_pr)
                    Close()
                Catch ex As Exception
                    errorConnection()
                End Try
            End If
        End If
    End Sub

    Private Sub TEDPTot_EditValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TEDPTot.EditValueChanged
        calculate()
    End Sub

    Private Sub BEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BEdit.Click
        If id_pr = "-1" Then
            FormPopUpPRComponent.id_det = GVListPurchase.GetFocusedRowCellDisplayText("id_det").ToString
            FormPopUpPRComponent.type = GVListPurchase.GetFocusedRowCellDisplayText("type").ToString
            FormPopUpPRComponent.id_purc = id_purc
            FormPopUpPRComponent.id_rec = id_rec

            FormPopUpPRComponent.ShowDialog()
        Else
            FormPopUpPRComponent.id_pr = id_pr
            FormPopUpPRComponent.id_pr_det = GVListPurchase.GetFocusedRowCellDisplayText("id_pr_sample_purc_det").ToString
            FormPopUpPRComponent.id_det = GVListPurchase.GetFocusedRowCellDisplayText("id_det").ToString
            FormPopUpPRComponent.type = GVListPurchase.GetFocusedRowCellDisplayText("type").ToString
            FormPopUpPRComponent.id_purc = id_purc
            FormPopUpPRComponent.id_rec = id_rec

            FormPopUpPRComponent.ShowDialog()
        End If
    End Sub

    Private Sub BPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BPrint.Click
        ReportSamplePR.id_pr = id_pr

        Dim Report As New ReportSamplePR()
        ' Show the report's preview. 
        Dim Tool As DevExpress.XtraReports.UI.ReportPrintTool = New DevExpress.XtraReports.UI.ReportPrintTool(Report)
        Tool.ShowPreview()
    End Sub

    Private Sub BCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BCancel.Click
        Close()
    End Sub

    Private Sub BMark_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BMark.Click
        FormReportMark.id_report = id_pr
        FormReportMark.report_mark_type = "4"
        FormReportMark.ShowDialog()
    End Sub
    Sub allow_status()
        If LEReportStatus.EditValue = "3" Or LEReportStatus.EditValue = "4" Or LEReportStatus.EditValue = "6" Or LEReportStatus.EditValue = "7" Then
            BPrint.Enabled = True
            BSave.Enabled = False
            '
            BEdit.Enabled = False
            BAdd.Enabled = False
            Bdel.Enabled = False
        Else
            BPrint.Enabled = False
            BSave.Enabled = True
            '
            BEdit.Enabled = True
            BAdd.Enabled = True
            Bdel.Enabled = True
        End If
    End Sub

    Private Sub BPrePrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BPrePrint.Click
        ReportSamplePR.id_pr = id_pr
        ReportSamplePR.id_pre = "1"

        Dim Report As New ReportSamplePR()
        ' Show the report's preview. 
        Dim Tool As DevExpress.XtraReports.UI.ReportPrintTool = New DevExpress.XtraReports.UI.ReportPrintTool(Report)
        Tool.ShowPreview()
    End Sub
End Class