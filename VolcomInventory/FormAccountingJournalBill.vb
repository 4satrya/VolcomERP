Public Class FormAccountingJournalBill 
    Public id_trans As String = "-1"
    Public id_report_status_g As String = "1"

    Public id_ref As String = "-1"
    Public id_cc As String = "-1"
    Public report_mark_typex As String = "-1"
    Public report_numberx As String = "-1"
    Dim id_report_status As String = "-1"

    Private Sub FormAccountingJournalBill_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        viewReportStatus()
        load_billing_type(LEBilling)
        ''
        view_status()
        BMark.Visible = False
        Bprint.Visible = False
        TEUserEntry.Text = get_user_identify(id_user, 1)

        view_vendor()

        TENumber.Text = ""
        'TEDate.EditValue = Now()
        actionLoad()

    End Sub

    Sub viewReportStatus()
        Dim query As String = "SELECT * FROM tb_lookup_report_status a ORDER BY a.id_report_status "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        viewLookupQuery(LEReportStatus, query, 0, "report_status", "id_report_status")
    End Sub

    Sub view_vendor()
        Dim query As String = "SELECT 0 AS id_comp, '' AS comp_number, '' AS comp_name, '' AS description UNION SELECT id_comp, comp_number, comp_name, CONCAT(comp_number, ' - ', comp_name) AS description FROM tb_m_comp"
        viewSearchLookupRepositoryQuery(RISLEVendor, query, 0, "description", "id_comp")
    End Sub

    Sub noEdit()
        Dim id_acc_src As String = ""
        Try
            id_acc_src = GVJournalDet.GetFocusedRowCellValue("id_acc_src").ToString
        Catch ex As Exception
        End Try
        If id_acc_src = "" Then
            GVJournalDet.Columns("debit").OptionsColumn.AllowEdit = True
            GVJournalDet.Columns("credit").OptionsColumn.AllowEdit = True
            GVJournalDet.Columns("report_number").OptionsColumn.AllowEdit = True
        Else
            GVJournalDet.Columns("debit").OptionsColumn.AllowEdit = False
            GVJournalDet.Columns("credit").OptionsColumn.AllowEdit = False
            GVJournalDet.Columns("report_number").OptionsColumn.AllowEdit = False
        End If
    End Sub

    Sub actionLoad()
        If id_trans = "-1" Then 'new
            Dim dt_now As DateTime = getTimeDB()
            DERefDate.EditValue = dt_now

            load_number()
            view_det()
            but_check()
        Else 'edit
            '
            BMark.Visible = True
            Bprint.Visible = True
            Dim query As String = "SELECT a.acc_trans_number,date_created, date_reference,a.id_user,a.acc_trans_note,id_report_status,a.report_number,a.id_bill_type FROM tb_a_acc_trans a WHERE a.id_acc_trans='" & id_trans & "'"
            Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")

            id_report_status_g = data.Rows(0)("id_report_status").ToString
            TEUserEntry.Text = get_user_identify(data.Rows(0)("id_user").ToString, 1)

            LEBilling.ItemIndex = LEBilling.Properties.GetDataSourceRowIndex("id_bill_type", data.Rows(0)("id_bill_type").ToString)
            TENumber.Text = data.Rows(0)("acc_trans_number").ToString

            TEDate.EditValue = data.Rows(0)("date_created")
            DERefDate.EditValue = data.Rows(0)("date_reference")

            MENote.Text = data.Rows(0)("acc_trans_note").ToString
            TEReffNumber.Text = data.Rows(0)("report_number").ToString
            id_report_status = data.Rows(0)("id_report_status").ToString
            LEReportStatus.ItemIndex = LEReportStatus.Properties.GetDataSourceRowIndex("id_report_status", data.Rows(0)("id_report_status").ToString)
            Blink.Enabled = False
            TEReffNumber.Properties.ReadOnly = True
            TENumber.Properties.ReadOnly = True
            '
            DERefDate.Enabled = False
            LEBilling.Enabled = False
            PCButton.Enabled = False
            view_det()
            allow_status()
            but_check()
        End If
        LabelControl4.Visible = False
        TEReffNumber.Visible = False
        Blink.Visible = False
    End Sub

    Sub view_det()
        Dim query As String = "SELECT a.id_acc_trans_det,a.id_acc,b.acc_name,b.acc_description,CAST(a.debit AS DECIMAL(13,2)) as debit,CAST(a.credit AS DECIMAL(13,2)) as credit,a.acc_trans_det_note as note,a.id_status_open,a.id_acc_src,IFNULL(a.id_comp, 0) AS id_comp,a.report_mark_type,a.id_report,a.report_number,a.report_number_ref FROM tb_a_acc_trans_det a INNER JOIN tb_a_acc b ON a.id_acc=b.id_acc LEFT JOIN tb_a_acc_trans_det d ON a.id_acc_src=d.id_acc_trans_det WHERE a.id_acc_trans='" & id_trans & "'"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCJournalDet.DataSource = data
        GVJournalDet.BestFitColumns()
    End Sub

    Private Sub LEBilling_EditValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LEBilling.EditValueChanged
        If Not LEBilling.EditValue.ToString = "" Then
            load_number()
        End If
    End Sub

    Sub view_status()
        Dim query As String = "SELECT id_status_open,status_open FROM tb_lookup_status_open"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        RSLEStatusOpen.DataSource = data
        RSLEStatusOpen.DisplayMember = "status_open"
        RSLEStatusOpen.ValueMember = "id_status_open"
        RSLEStatusOpen.PopulateViewColumns()
        RSLEStatusOpen.NullText = ""
        RSLEStatusOpen.View.Columns("id_status_open").Visible = False
        RSLEStatusOpen.View.Columns("status_open").Caption = "Status"

        If data.Rows.Count > 0 Then
            RSLEStatusOpen.View.FocusedRowHandle = 0
        End If
    End Sub

    Private Sub GVJournalDet_CustomColumnDisplayText(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs) Handles GVJournalDet.CustomColumnDisplayText
        If e.Column.FieldName = "no" Then
            e.DisplayText = (e.ListSourceRowIndex + 1).ToString()
        End If
    End Sub

    Sub but_check()
        If GVJournalDet.RowCount > 0 Then
            BDelMat.Visible = True
        Else
            BDelMat.Visible = False
        End If
    End Sub

    Private Sub BCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BCancel.Click
        Close()
    End Sub

    Private Sub FormAccountingJournalDet_FormClosed(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub BSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BSave.Click
        'validates
        ValidateChildren()
        If Not formIsValidInPanel(EPJournal, PCGeneralheader) Then
            stopCustom("Please check your input.")
        ElseIf GVJournalDet.Columns("debit").SummaryItem.SummaryValue = 0 And GVJournalDet.Columns("credit").SummaryItem.SummaryValue = 0 Then
            stopCustom("Please input debit/credit value.")
        ElseIf Not GVJournalDet.Columns("debit").SummaryText = GVJournalDet.Columns("credit").SummaryText Then
            stopCustom("Debit and credit must balance.")
        Else
            Dim confirm As DialogResult = DevExpress.XtraEditors.XtraMessageBox.Show("Are you sure want to save this journal entry ?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
            If confirm = Windows.Forms.DialogResult.Yes Then
                Dim date_reference As String = DateTime.Parse(DERefDate.EditValue.ToString).ToString("yyyy-MM-dd")
                If id_trans = "-1" Then
                    'new
                    Dim query As String = String.Format("INSERT INTO tb_a_acc_trans(acc_trans_number,date_created, date_reference,id_user,acc_trans_note,id_bill_type) VALUES('{0}',NOW(),'" + date_reference + "','{1}','{2}','{3}'); SELECT LAST_INSERT_ID()", header_number_acc("1"), id_user, MENote.Text, LEBilling.EditValue.ToString)
                    id_trans = execute_query(query, 0, True, "", "", "", "")

                    increase_inc_acc("1")
                    'If LEBilling.EditValue.ToString = "1" Then
                    '    increase_inc_acc("3")
                    'ElseIf LEBilling.EditValue.ToString = "3" Then
                    '    increase_inc_acc("4")
                    'ElseIf LEBilling.EditValue.ToString = "4" Then
                    '    increase_inc_acc("5")
                    'End If

                    'insert who prepared
                    insert_who_prepared("36", id_trans, id_user)

                    'entry detail
                    Dim id_reportd As String = ""
                    Dim report_mark_typed As String = ""
                    Dim id_acc_srcd As String = ""
                    Dim id_compd As String = ""
                    Dim vend As String = ""
                    Dim report_number_ref As String = ""
                    Try
                        For i As Integer = 0 To GVJournalDet.RowCount - 1
                            If Not GVJournalDet.GetRowCellValue(i, "id_acc").ToString = "" Then
                                If GVJournalDet.GetRowCellValue(i, "id_report").ToString = "" Then
                                    id_reportd = "NULL"
                                Else
                                    id_reportd = "'" + GVJournalDet.GetRowCellValue(i, "id_report").ToString + "'"
                                End If
                                If GVJournalDet.GetRowCellValue(i, "report_mark_type").ToString = "" Then
                                    report_mark_typed = "NULL"
                                Else
                                    report_mark_typed = "'" + GVJournalDet.GetRowCellValue(i, "report_mark_type").ToString + "'"
                                End If
                                If GVJournalDet.GetRowCellValue(i, "id_comp").ToString = "0" Then
                                    id_compd = "NULL"
                                Else
                                    id_compd = "'" + GVJournalDet.GetRowCellValue(i, "id_comp").ToString + "'"
                                End If
                                If GVJournalDet.GetRowCellValue(i, "id_acc_src").ToString = "" Then
                                    id_acc_srcd = "NULL"
                                Else
                                    id_acc_srcd = "'" + GVJournalDet.GetRowCellValue(i, "id_acc_src").ToString + "'"
                                End If
                                If GVJournalDet.GetRowCellValue(i, "report_number_ref").ToString = "" Then
                                    report_number_ref = "NULL"
                                Else
                                    report_number_ref = "'" + GVJournalDet.GetRowCellValue(i, "report_number_ref").ToString + "'"
                                End If
                                If GVJournalDet.GetRowCellValue(i, "id_comp").ToString = "0" Then
                                    vend = "NULL"
                                Else
                                    vend = "'" + execute_query("SELECT comp_number FROM tb_m_comp WHERE id_comp = " + id_compd, 0, True, "", "", "", "") + "'"
                                End If

                                query = String.Format("INSERT INTO tb_a_acc_trans_det(id_acc_trans,id_acc,debit,credit,acc_trans_det_note,id_status_open,report_mark_type,id_report,report_number,id_comp, id_acc_src, report_number_ref,vendor) VALUES('{0}','{1}','{2}','{3}','{4}','{5}',{6},{7},'{8}',{9},{10},{11},{12})", id_trans, GVJournalDet.GetRowCellValue(i, "id_acc").ToString, decimalSQL(GVJournalDet.GetRowCellValue(i, "debit").ToString), decimalSQL(GVJournalDet.GetRowCellValue(i, "credit").ToString), GVJournalDet.GetRowCellValue(i, "note").ToString, GVJournalDet.GetRowCellValue(i, "id_status_open").ToString, report_mark_typed, id_reportd, GVJournalDet.GetRowCellValue(i, "report_number").ToString, id_compd, id_acc_srcd, report_number_ref, vend)
                                execute_non_query(query, True, "", "", "", "")
                            End If
                        Next
                    Catch ex As Exception
                        MsgBox(ex.ToString)
                    End Try

                    'SUBMIT who prepared
                    submit_who_prepared("36", id_trans, id_user)

                    actionLoad()
                    FormAccountingJournal.view_entry()
                    FormAccountingJournal.GVAccTrans.FocusedRowHandle = find_row(FormAccountingJournal.GVAccTrans, "id_acc_trans", id_trans)
                    infoCustom("Journal saved.")
                Else
                    'edit
                    Dim query As String = String.Format("UPDATE tb_a_acc_trans SET acc_trans_note='{0}' WHERE id_acc_trans='{1}'", MENote.Text, id_trans)
                    execute_non_query(query, True, "", "", "", "")

                    'delete first
                    Dim sp_check As Boolean = False
                    Dim query_del As String = "SELECT id_acc_trans_det FROM tb_a_acc_trans_det WHERE id_acc_trans='" & id_trans & "'"
                    Dim data_del As DataTable = execute_query(query_del, -1, True, "", "", "", "")
                    If data_del.Rows.Count > 0 Then
                        For i As Integer = 0 To data_del.Rows.Count - 1
                            sp_check = False
                            ' false mean not found, believe me
                            For j As Integer = 0 To GVJournalDet.RowCount - 1
                                If Not GVJournalDet.GetRowCellValue(j, "id_acc_trans_det").ToString = "" Then
                                    '
                                    If GVJournalDet.GetRowCellValue(j, "id_acc_trans_det").ToString = data_del.Rows(i)("id_acc_trans_det").ToString() Then
                                        sp_check = True
                                    End If
                                End If
                            Next
                            'end loop check on gv
                            If sp_check = False Then
                                'Because not found, it's only mean already deleted
                                query = String.Format("DELETE FROM tb_a_acc_trans_det WHERE id_acc_trans_det='{0}'", data_del.Rows(i)("id_acc_trans_det").ToString())
                                execute_non_query(query, True, "", "", "", "")
                            End If
                        Next
                    End If

                    For i As Integer = 0 To GVJournalDet.RowCount - 1
                        If Not GVJournalDet.GetRowCellValue(i, "id_acc").ToString = "" Then
                            If GVJournalDet.GetRowCellValue(i, "id_acc_trans_det").ToString = "" Then
                                'insert new
                                query = String.Format("INSERT INTO tb_a_acc_trans_det(id_acc_trans,id_acc,debit,credit,acc_trans_det_note,id_status_open) VALUES('{0}','{1}','{2}','{3}','{4}','{5}')", id_trans, GVJournalDet.GetRowCellValue(i, "id_acc").ToString, decimalSQL(GVJournalDet.GetRowCellValue(i, "debit").ToString), decimalSQL(GVJournalDet.GetRowCellValue(i, "credit").ToString), GVJournalDet.GetRowCellValue(i, "note").ToString, GVJournalDet.GetRowCellValue(i, "id_status_open").ToString)
                                execute_non_query(query, True, "", "", "", "")
                            Else
                                'update
                                query = String.Format("UPDATE tb_a_acc_trans_det SET id_acc='{0}',debit='{1}',credit='{2}',acc_trans_det_note='{3}',id_status_open='{5}' WHERE id_acc_trans_det='{4}'", GVJournalDet.GetRowCellValue(i, "id_acc").ToString, decimalSQL(GVJournalDet.GetRowCellValue(i, "debit").ToString), decimalSQL(GVJournalDet.GetRowCellValue(i, "credit").ToString), GVJournalDet.GetRowCellValue(i, "note").ToString, GVJournalDet.GetRowCellValue(i, "id_acc_trans_det").ToString, GVJournalDet.GetRowCellValue(i, "id_status_open").ToString)
                                execute_non_query(query, True, "", "", "", "")
                            End If
                        End If
                    Next

                    'FormAccountingJournal.view_entry(LEBilling.EditValue.ToString)
                    'FormAccountingJournal.GVAccTrans.FocusedRowHandle = find_row(FormAccountingJournal.GVAccTrans, "id_acc_trans", id_trans)
                    infoCustom("Journal updated.")
                    Close()
                End If
            End If
        End If

    End Sub

    Sub load_number()
        ' TENumber.Text = = header_number_acc("1")
        'If LEBilling.EditValue.ToString = "1" Then
        '    TENumber.Text = header_number_acc("3")
        'ElseIf LEBilling.EditValue.ToString = "3" Then
        '    TENumber.Text = header_number_acc("4")
        'ElseIf LEBilling.EditValue.ToString = "4" Then
        '    TENumber.Text = header_number_acc("5")
        'End If
    End Sub

    Private Sub BDelMat_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BDelMat.Click
        Dim confirm As DialogResult
        confirm = DevExpress.XtraEditors.XtraMessageBox.Show("Are you sure want to delete this entry ?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
        If confirm = Windows.Forms.DialogResult.Yes Then
            GVJournalDet.DeleteSelectedRows()
            CType(GCJournalDet.DataSource, DataTable).AcceptChanges()
        End If
        GVJournalDet.RefreshData()
        but_check()
    End Sub

    Private Sub TENumber_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs)
        Dim query_jml As String
        query_jml = String.Format("SELECT COUNT(id_acc_trans) FROM tb_a_acc_trans WHERE acc_trans_number='{0}' AND id_acc_trans!='{1}'", TENumber.Text, id_trans)
        Dim jml As Integer = execute_query(query_jml, 0, True, "", "", "", "")
        If Not jml < 1 Then
            EP_TE_already_used(EPJournal, TENumber, "1")
        Else
            EP_TE_cant_blank(EPJournal, TENumber)
        End If
    End Sub

    Private Sub GVJournalDet_PopupMenuShowing(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Grid.PopupMenuShowingEventArgs) Handles GVJournalDet.PopupMenuShowing
        If GVJournalDet.RowCount > 0 Then
            Dim view As DevExpress.XtraGrid.Views.Grid.GridView = CType(sender, DevExpress.XtraGrid.Views.Grid.GridView)
            Dim hitInfo As DevExpress.XtraGrid.Views.Grid.ViewInfo.GridHitInfo = view.CalcHitInfo(e.Point)
            If hitInfo.InRow Then
                view.FocusedRowHandle = hitInfo.RowHandle
                BalanceMenu.Show(view.GridControl, e.Point)
            End If
        End If
    End Sub

    Private Sub BMark_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BMark.Click
        FormReportMark.id_report = id_trans
        FormReportMark.report_mark_type = "36"
        FormReportMark.form_origin = Name
        FormReportMark.ShowDialog()
    End Sub

    Sub allow_status()
        GVJournalDet.OptionsBehavior.Editable = False
        MENote.Properties.ReadOnly = True
        BAddMat.Enabled = False
        BDelMat.Enabled = False
        BSave.Enabled = False

        'If check_print_report_status(id_report_status_g) Then
        '    Bprint.Enabled = True
        'Else
        '    Bprint.Enabled = False
        'End If
    End Sub

    Private Sub Bprint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Bprint.Click
        ReportAccountingJournal.id_trans = id_trans
        If Not check_print_report_status(id_report_status_g) Then
            ReportAccountingJournal.is_pre = "1"
        End If
        Dim Report As New ReportAccountingJournal()
        Dim Tool As DevExpress.XtraReports.UI.ReportPrintTool = New DevExpress.XtraReports.UI.ReportPrintTool(Report)
        Tool.ShowPreview()
    End Sub

    Private Sub SMBalance_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SMBalance.Click
        If GVJournalDet.RowCount > 0 Then
            If Not GVJournalDet.Columns("debit").SummaryItem.SummaryValue = GVJournalDet.Columns("credit").SummaryItem.SummaryValue Then
                Dim debit, credit As Decimal
                debit = GVJournalDet.Columns("debit").SummaryItem.SummaryValue
                credit = GVJournalDet.Columns("credit").SummaryItem.SummaryValue
                If debit > credit Then
                    If GVJournalDet.GetFocusedRowCellValue("debit") > 0 Then
                        GVJournalDet.SetRowCellValue(GVJournalDet.FocusedRowHandle, "debit", (GVJournalDet.GetFocusedRowCellValue("debit") - (debit - credit)))
                    Else
                        GVJournalDet.SetRowCellValue(GVJournalDet.FocusedRowHandle, "credit", (GVJournalDet.GetFocusedRowCellValue("credit") + (debit - credit)))
                    End If
                Else
                    If GVJournalDet.GetFocusedRowCellValue("credit") > 0 Then
                        GVJournalDet.SetRowCellValue(GVJournalDet.FocusedRowHandle, "credit", (GVJournalDet.GetFocusedRowCellValue("credit") - (credit - debit)))
                    Else
                        GVJournalDet.SetRowCellValue(GVJournalDet.FocusedRowHandle, "debit", (GVJournalDet.GetFocusedRowCellValue("debit") + (credit - debit)))
                    End If
                End If
            End If
        End If
        GVJournalDet.RefreshData()
    End Sub

    Private Sub Blink_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Blink.Click
        Dim query_cek As String = "SELECT acc_t.id_acc_trans FROM tb_a_acc_trans acc_t WHERE acc_t.report_number='" + TEReffNumber.Text + "'"
        Dim data_cek As DataTable = execute_query(query_cek, -1, True, "", "", "", "")
        If data_cek.Rows.Count = 0 Then
            If LEBilling.EditValue.ToString = "1" Then 'BPJ invoice
                Dim query As String = ""
                Dim id_ref As String = ""
                Dim id_acc As String = ""
                Dim acc_name As String = ""
                Dim acc_desc As String = ""
                Dim debit, credit As Decimal
                Dim report_mark_type As String = ""
                Dim report_number As String = ""
                Dim comp_name As String = ""

                query = "SELECT s_p.id_sales_pos,comp_c.id_comp,comp.comp_name,s_p.sales_pos_number, s_p.sales_pos_total,s_p.sales_pos_discount,s_p.sales_pos_vat,(s_p.sales_pos_total*((100-s_p.sales_pos_discount)/100) ) AS netto, ((100/(100+s_p.sales_pos_vat))*(s_p.sales_pos_total*((100-s_p.sales_pos_discount)/100))) AS kena_ppn,((s_p.sales_pos_vat/(100+s_p.sales_pos_vat))*(s_p.sales_pos_total*((100-s_p.sales_pos_discount)/100))) AS ppn"
                query += " FROM tb_sales_pos s_p INNER JOIN tb_m_comp_contact comp_c ON comp_c.id_comp_contact=s_p.id_store_contact_from "
                query += " INNER JOIN tb_m_comp comp ON comp.id_comp=comp_c.id_comp "
                query += " WHERE sales_pos_number = '" + TEReffNumber.Text + "' AND id_memo_type='1'"
                Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
                If data.Rows.Count > 0 Then
                    report_mark_type = "48"
                    report_mark_typex = "48"

                    report_numberx = TEReffNumber.Text
                    id_cc = data.Rows(0)("id_comp").ToString
                    report_number = data.Rows(0)("sales_pos_number").ToString
                    id_ref = data.Rows(0)("id_sales_pos").ToString
                    comp_name = data.Rows(0)("comp_name").ToString

                    query = "SELECT coa_map_d.id_coa_map_det,comp_coa.id_acc,acc.acc_name,acc.acc_description "
                    query += " FROM tb_m_comp_coa comp_coa "
                    query += " INNER JOIN tb_coa_map_det coa_map_d ON coa_map_d.id_coa_map_det=comp_coa.id_coa_map_det"
                    query += " INNER JOIN tb_coa_map coa_map ON coa_map_d.id_coa_map=coa_map.id_coa_map"
                    query += " INNER JOIN tb_a_acc acc ON acc.id_acc=comp_coa.id_acc"
                    query += " WHERE comp_coa.id_comp='" + id_cc + "' AND coa_map.id_coa_map='1'"
                    Dim data_acc As DataTable = execute_query(query, -1, True, "", "", "", "")

                    If data_acc.Rows.Count > 0 Then 'id_coa_map = 1
                        'id_acc piutang dagang
                        Dim data_filter As DataRow() = data_acc.Select("[id_coa_map_det]='1'")
                        id_acc = data_filter(0)("id_acc").ToString
                        acc_name = data_filter(0)("acc_name").ToString
                        acc_desc = data_filter(0)("acc_description").ToString

                        debit = 0
                        credit = data.Rows(0)("netto")

                        add_journal(id_acc, acc_name, acc_desc, debit, credit, id_cc, report_mark_type, id_ref, report_number)
                        'end id_acc piutang dagang

                        'id_acc PPN
                        data_filter = data_acc.Select("[id_coa_map_det]='2'")
                        id_acc = data_filter(0)("id_acc").ToString
                        acc_name = data_filter(0)("acc_name").ToString
                        acc_desc = data_filter(0)("acc_description").ToString

                        debit = data.Rows(0)("ppn")
                        credit = 0
                        add_journal(id_acc, acc_name, acc_desc, debit, credit, id_cc, report_mark_type, id_ref, report_number)
                        'end id_acc PPN

                        'id_acc penjualan
                        data_filter = data_acc.Select("[id_coa_map_det]='3'")
                        id_acc = data_filter(0)("id_acc").ToString
                        acc_name = data_filter(0)("acc_name").ToString
                        acc_desc = data_filter(0)("acc_description").ToString

                        debit = data.Rows(0)("kena_ppn")
                        credit = 0
                        add_journal(id_acc, acc_name, acc_desc, debit, credit, id_cc, report_mark_type, id_ref, report_number)
                    Else
                        stopCustom("Store account not registered")
                    End If
                Else
                    infoCustom("Refference not found.")
                End If
            ElseIf LEBilling.EditValue.ToString = "2" Then 'BCN invoice
                Dim query As String = ""
                Dim id_ref As String = ""
                Dim id_acc As String = ""
                Dim acc_name As String = ""
                Dim acc_desc As String = ""
                Dim debit, credit As Decimal
                Dim report_mark_type As String = ""
                Dim report_number As String = ""
                Dim comp_name As String = ""

                query = "SELECT s_p.id_sales_pos,s_p_ref.id_memo_type as id_memo_type_ref,comp_c.id_comp,comp.comp_name,s_p.sales_pos_number, s_p.sales_pos_total,s_p.sales_pos_discount,s_p.sales_pos_vat,(s_p.sales_pos_total*((100-s_p.sales_pos_discount)/100)*(-1) ) AS netto, ((100/(100+s_p.sales_pos_vat))*(s_p.sales_pos_total*((100-s_p.sales_pos_discount)/100))*(-1)) AS kena_ppn,((s_p.sales_pos_vat/(100+s_p.sales_pos_vat))*(s_p.sales_pos_total*((100-s_p.sales_pos_discount)/100))*(-1)) AS ppn"
                query += " ,(((100+s_p.sales_pos_vat)/100)*(s_p.sales_pos_total*((100-s_p.sales_pos_discount)/100))*(-1)) AS kena_ppn_prm,((s_p.sales_pos_vat/100)*(s_p.sales_pos_total*((100-s_p.sales_pos_discount)/100))*(-1)) AS ppn_prm"
                query += " FROM tb_sales_pos s_p INNER JOIN tb_m_comp_contact comp_c ON comp_c.id_comp_contact=s_p.id_store_contact_from "
                query += " INNER JOIN tb_m_comp comp ON comp.id_comp=comp_c.id_comp "
                query += " LEFT JOIN tb_sales_pos s_p_ref ON s_p_ref.id_sales_pos=s_p.id_sales_pos_ref "
                query += " LEFT JOIN tb_lookup_memo_type memo_type ON memo_type.id_memo_type=s_p_ref.id_memo_type "
                query += " WHERE s_p.sales_pos_number = '" + TEReffNumber.Text + "' AND s_p.id_memo_type='2'"
                Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
                If data.Rows.Count > 0 Then
                    report_mark_type = "66"
                    report_mark_typex = "66"

                    If data.Rows(0)("id_memo_type_ref").ToString = "1" Then 'credit note sales pos
                        report_numberx = TEReffNumber.Text
                        id_cc = data.Rows(0)("id_comp").ToString
                        report_number = data.Rows(0)("sales_pos_number").ToString
                        id_ref = data.Rows(0)("id_sales_pos").ToString
                        comp_name = data.Rows(0)("comp_name").ToString

                        query = "SELECT coa_map_d.id_coa_map_det,comp_coa.id_acc,acc.acc_name,acc.acc_description "
                        query += " FROM tb_m_comp_coa comp_coa "
                        query += " INNER JOIN tb_coa_map_det coa_map_d ON coa_map_d.id_coa_map_det=comp_coa.id_coa_map_det"
                        query += " INNER JOIN tb_coa_map coa_map ON coa_map_d.id_coa_map=coa_map.id_coa_map"
                        query += " INNER JOIN tb_a_acc acc ON acc.id_acc=comp_coa.id_acc"
                        query += " WHERE comp_coa.id_comp='" + id_cc + "' AND coa_map.id_coa_map='1'"
                        Dim data_acc As DataTable = execute_query(query, -1, True, "", "", "", "")

                        If data_acc.Rows.Count > 0 Then 'id_coa_map = 1
                            'id_acc piutang dagang
                            Dim data_filter As DataRow() = data_acc.Select("[id_coa_map_det]='1'")
                            id_acc = data_filter(0)("id_acc").ToString
                            acc_name = data_filter(0)("acc_name").ToString
                            acc_desc = data_filter(0)("acc_description").ToString

                            'balik
                            debit = data.Rows(0)("netto")
                            credit = 0

                            add_journal(id_acc, acc_name, acc_desc, debit, credit, id_cc, report_mark_type, id_ref, report_number)
                            'end id_acc piutang dagang

                            'id_acc PPN
                            data_filter = data_acc.Select("[id_coa_map_det]='2'")
                            id_acc = data_filter(0)("id_acc").ToString
                            acc_name = data_filter(0)("acc_name").ToString
                            acc_desc = data_filter(0)("acc_description").ToString

                            debit = 0
                            credit = data.Rows(0)("ppn")
                            add_journal(id_acc, acc_name, acc_desc, debit, credit, id_cc, report_mark_type, id_ref, report_number)
                            'end id_acc PPN

                            'id_acc penjualan
                            data_filter = data_acc.Select("[id_coa_map_det]='3'")
                            id_acc = data_filter(0)("id_acc").ToString
                            acc_name = data_filter(0)("acc_name").ToString
                            acc_desc = data_filter(0)("acc_description").ToString

                            debit = 0
                            credit = data.Rows(0)("kena_ppn")
                            add_journal(id_acc, acc_name, acc_desc, debit, credit, id_cc, report_mark_type, id_ref, report_number)
                        Else
                            stopCustom("Store account not registered")
                        End If
                    ElseIf data.Rows(0)("id_memo_type_ref").ToString = "5" Then 'promo credit note 
                        report_numberx = TEReffNumber.Text
                        id_cc = data.Rows(0)("id_comp").ToString
                        report_number = data.Rows(0)("sales_pos_number").ToString
                        id_ref = data.Rows(0)("id_sales_pos").ToString
                        comp_name = data.Rows(0)("comp_name").ToString

                        query = "SELECT coa_map_d.id_coa_map_det,comp_coa.id_acc,acc.acc_name,acc.acc_description "
                        query += " FROM tb_m_comp_coa comp_coa "
                        query += " INNER JOIN tb_coa_map_det coa_map_d ON coa_map_d.id_coa_map_det=comp_coa.id_coa_map_det"
                        query += " INNER JOIN tb_coa_map coa_map ON coa_map_d.id_coa_map=coa_map.id_coa_map"
                        query += " INNER JOIN tb_a_acc acc ON acc.id_acc=comp_coa.id_acc"
                        query += " WHERE comp_coa.id_comp='" + id_cc + "' AND coa_map.id_coa_map='2'"
                        Dim data_acc As DataTable = execute_query(query, -1, True, "", "", "", "")

                        If data_acc.Rows.Count > 0 Then 'id_coa_map = 1
                            'id_acc piutang dagang
                            Dim data_filter As DataRow() = data_acc.Select("[id_coa_map_det]='4'")
                            id_acc = data_filter(0)("id_acc").ToString
                            acc_name = data_filter(0)("acc_name").ToString
                            acc_desc = data_filter(0)("acc_description").ToString

                            debit = data.Rows(0)("netto")
                            credit = 0
                            add_journal(id_acc, acc_name, acc_desc, debit, credit, id_cc, report_mark_type, id_ref, report_number)
                            'end id_acc piutang dagang

                            'id_acc PPN
                            data_filter = data_acc.Select("[id_coa_map_det]='5'")
                            id_acc = data_filter(0)("id_acc").ToString
                            acc_name = data_filter(0)("acc_name").ToString
                            acc_desc = data_filter(0)("acc_description").ToString

                            debit = 0
                            credit = data.Rows(0)("ppn_prm")
                            add_journal(id_acc, acc_name, acc_desc, debit, credit, id_cc, report_mark_type, id_ref, report_number)
                            'end id_acc PPN

                            'id_acc penjualan
                            data_filter = data_acc.Select("[id_coa_map_det]='6'")
                            id_acc = data_filter(0)("id_acc").ToString
                            acc_name = data_filter(0)("acc_name").ToString
                            acc_desc = data_filter(0)("acc_description").ToString

                            debit = 0
                            credit = data.Rows(0)("kena_ppn_prm")
                            add_journal(id_acc, acc_name, acc_desc, debit, credit, id_cc, report_mark_type, id_ref, report_number)
                        Else
                            stopCustom("Store account not registered")
                        End If
                    End If
                Else
                    infoCustom("Refference not found.")
                End If
            ElseIf LEBilling.EditValue.ToString = "4" Then 'Promo
                Dim query As String = ""
                Dim id_ref As String = ""
                Dim id_acc As String = ""
                Dim acc_name As String = ""
                Dim acc_desc As String = ""
                Dim debit, credit As Decimal
                Dim report_mark_type As String = ""
                Dim report_number As String = ""
                Dim comp_name As String = ""

                query = "SELECT s_p.id_sales_pos,comp_c.id_comp,comp.comp_name,s_p.sales_pos_number, s_p.sales_pos_total,s_p.sales_pos_discount,s_p.sales_pos_vat,(s_p.sales_pos_total*((100-s_p.sales_pos_discount)/100) ) AS netto, (((100+s_p.sales_pos_vat)/100)*(s_p.sales_pos_total*((100-s_p.sales_pos_discount)/100))) AS kena_ppn,((s_p.sales_pos_vat/100)*(s_p.sales_pos_total*((100-s_p.sales_pos_discount)/100))) AS ppn"
                query += " FROM tb_sales_pos s_p INNER JOIN tb_m_comp_contact comp_c ON comp_c.id_comp_contact=s_p.id_store_contact_from "
                query += " INNER JOIN tb_m_comp comp ON comp.id_comp=comp_c.id_comp "
                query += " WHERE sales_pos_number = '" + TEReffNumber.Text + "' AND id_memo_type='5'"
                Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
                If data.Rows.Count > 0 Then
                    report_mark_type = "76"
                    report_mark_typex = "76"

                    report_numberx = TEReffNumber.Text
                    id_cc = data.Rows(0)("id_comp").ToString
                    report_number = data.Rows(0)("sales_pos_number").ToString
                    id_ref = data.Rows(0)("id_sales_pos").ToString
                    comp_name = data.Rows(0)("comp_name").ToString

                    query = "SELECT coa_map_d.id_coa_map_det,comp_coa.id_acc,acc.acc_name,acc.acc_description "
                    query += " FROM tb_m_comp_coa comp_coa "
                    query += " INNER JOIN tb_coa_map_det coa_map_d ON coa_map_d.id_coa_map_det=comp_coa.id_coa_map_det"
                    query += " INNER JOIN tb_coa_map coa_map ON coa_map_d.id_coa_map=coa_map.id_coa_map"
                    query += " INNER JOIN tb_a_acc acc ON acc.id_acc=comp_coa.id_acc"
                    query += " WHERE comp_coa.id_comp='" + id_cc + "' AND coa_map.id_coa_map='2'"
                    Dim data_acc As DataTable = execute_query(query, -1, True, "", "", "", "")

                    If data_acc.Rows.Count > 0 Then 'id_coa_map = 1
                        'id_acc piutang dagang
                        Dim data_filter As DataRow() = data_acc.Select("[id_coa_map_det]='4'")
                        id_acc = data_filter(0)("id_acc").ToString
                        acc_name = data_filter(0)("acc_name").ToString
                        acc_desc = data_filter(0)("acc_description").ToString

                        debit = 0
                        credit = data.Rows(0)("netto")

                        add_journal(id_acc, acc_name, acc_desc, debit, credit, id_cc, report_mark_type, id_ref, report_number)
                        'end id_acc piutang dagang

                        'id_acc PPN
                        data_filter = data_acc.Select("[id_coa_map_det]='5'")
                        id_acc = data_filter(0)("id_acc").ToString
                        acc_name = data_filter(0)("acc_name").ToString
                        acc_desc = data_filter(0)("acc_description").ToString

                        debit = data.Rows(0)("ppn")
                        credit = 0
                        add_journal(id_acc, acc_name, acc_desc, debit, credit, id_cc, report_mark_type, id_ref, report_number)
                        'end id_acc PPN

                        'id_acc penjualan
                        data_filter = data_acc.Select("[id_coa_map_det]='6'")
                        id_acc = data_filter(0)("id_acc").ToString
                        acc_name = data_filter(0)("acc_name").ToString
                        acc_desc = data_filter(0)("acc_description").ToString

                        debit = data.Rows(0)("kena_ppn")
                        credit = 0
                        add_journal(id_acc, acc_name, acc_desc, debit, credit, id_cc, report_mark_type, id_ref, report_number)
                    Else
                        stopCustom("Store account not registered")
                    End If
                Else
                    infoCustom("Refference not found.")
                End If
            End If
        Else
            stopCustom("This reference already on journal.")
        End If
        but_check()
    End Sub

    Sub add_journal(ByVal id_acc As String, ByVal acc_name As String, ByVal note As String, ByVal debit As Decimal, ByVal credit As Decimal, ByVal id_comp As String, ByVal report_mark_type As String, ByVal id_report As String, ByVal report_number As String)
        Dim newRow As DataRow = (TryCast(GCJournalDet.DataSource, DataTable)).NewRow()
        newRow("id_acc") = id_acc
        newRow("acc_name") = acc_name
        newRow("note") = note
        newRow("debit") = debit
        newRow("credit") = credit
        newRow("id_comp") = id_comp
        newRow("report_mark_type") = report_mark_type
        newRow("id_report") = id_report
        newRow("report_number") = report_number
        newRow("id_status_open") = 1

        TryCast(GCJournalDet.DataSource, DataTable).Rows.Add(newRow)
        GCJournalDet.RefreshDataSource()
    End Sub

    Private Sub BAddMat_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BAddMat.Click
        FormPopUpCOA.id_pop_up = "6"
        FormPopUpCOA.ShowDialog()
    End Sub

    Private Sub BtnRef_Click(sender As Object, e As EventArgs) Handles BtnRef.Click
        Cursor = Cursors.WaitCursor
        FormAccountingJournalBrowse.data_par = GCJournalDet.DataSource
        FormAccountingJournalBrowse.ShowDialog()
        Cursor = Cursors.Default
    End Sub

    Private Sub GVJournalDet_ColumnFilterChanged(sender As Object, e As EventArgs) Handles GVJournalDet.ColumnFilterChanged
        noEdit()
    End Sub

    Private Sub GVJournalDet_FocusedRowChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles GVJournalDet.FocusedRowChanged
        noEdit()
    End Sub
End Class