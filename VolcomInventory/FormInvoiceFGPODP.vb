Public Class FormInvoiceFGPODP
    Public id_invoice As String = "-1"
    Public is_view As String = "-1"
    Public type As String = "1"

    Public id_po As String = "-1"

    Public doc_type As String = "2"
    Public id_report_status As String = "1"

    Private Sub BtnCancel_Click(sender As Object, e As EventArgs) Handles BtnCancel.Click
        Close()
    End Sub

    Sub load_trans_type()
        Dim query As String = "SELECT id_type,pn_type FROM tb_pn_type"
        If doc_type = "1" Or doc_type = "3" Then
            query += " WHERE id_type='1' OR id_type='2'"
        End If
        viewSearchLookupQuery(SLEPayType, query, "id_type", "pn_type", "id_type")
    End Sub

    Private Sub view_currency()
        Dim query As String = "SELECT id_currency,currency FROM tb_lookup_currency"
        viewSearchLookupRepositoryQuery(RISLECurrency, query, 0, "currency", "id_currency")
    End Sub

    Private Sub view_coa()
        Dim query As String = "SELECT id_acc,acc_name,CONCAT(acc_name,' - ',acc_description) AS acc_description FROM tb_a_acc WHERE id_is_det='2'"
        viewSearchLookupRepositoryQuery(RISLECOA, query, 0, "acc_description", "id_acc")

        query = "SELECT id_acc,acc_name,CONCAT(acc_name,' - ',acc_description) AS acc_description FROM tb_a_acc WHERE id_is_det='2' AND acc_name LIKE '1115111%'"
        viewSearchLookupQuery(SLEVatAcc, query, "id_acc", "acc_description", "id_acc")
    End Sub

    Private Sub FormInvoiceFGPODP_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        view_currency()
        view_coa()
        load_blank_draft()
        'check
        DEDateCreated.EditValue = Now
        DERefDate.EditValue = Now
        DEDueDate.EditValue = Now
        DEDueDateInv.EditValue = Now
        '
        TETotal.EditValue = 0.00
        TEVat.EditValue = 0.00
        TEGrandTotal.EditValue = 0.00
        '
        TENumber.Text = "[auto generate]"
        load_vendor()
        load_trans_type()
        load_det()
        '
        If id_invoice = "-1" Then 'new
            BtnPrint.Visible = False
            BAttachment.Visible = False
            BtnViewJournal.Visible = False
            BMark.Visible = False
            DEDueDate.Properties.ReadOnly = False
            DEDueDateInv.Properties.ReadOnly = False
            DERefDate.Properties.ReadOnly = False
            '
            If doc_type = "1" Or doc_type = "3" Then
                SLEPayType.Properties.ReadOnly = False
                SLEVendor.Properties.ReadOnly = False
            Else
                GCReff.OptionsColumn.AllowFocus = False
                GCDescription.OptionsColumn.AllowFocus = False
                GCQty.OptionsColumn.AllowFocus = False
                GCCur.OptionsColumn.AllowFocus = False
                GCBeforeKurs.OptionsColumn.AllowFocus = False
                GCKurs.OptionsColumn.AllowFocus = False
                GCVat.OptionsColumn.AllowFocus = False

                If type = "1" Then 'DP
                    BtnPrint.Visible = False
                    BtnViewJournal.Visible = False
                    BMark.Visible = False
                    DEDueDate.Properties.ReadOnly = False
                    DERefDate.Properties.ReadOnly = False
                    'new
                    'vendor 
                    SLEVendor.EditValue = FormInvoiceFGPO.SLEVendorPayment.EditValue
                    'detail
                    Try
                        For i = 0 To FormInvoiceFGPO.GVDPFGPO.RowCount - 1
                            Dim newRow As DataRow = (TryCast(GCList.DataSource, DataTable)).NewRow()
                            newRow("id_prod_order") = FormInvoiceFGPO.GVDPFGPO.GetRowCellValue(i, "id_prod_order").ToString
                            newRow("id_acc") = FormInvoiceFGPO.GVDPFGPO.GetRowCellValue(i, "id_acc").ToString
                            newRow("id_report") = FormInvoiceFGPO.GVDPFGPO.GetRowCellValue(i, "id_prod_order").ToString
                            newRow("report_mark_type") = "22"
                            newRow("report_number") = FormInvoiceFGPO.GVDPFGPO.GetRowCellValue(i, "prod_order_number").ToString
                            newRow("info_design") = FormInvoiceFGPO.GVDPFGPO.GetRowCellValue(i, "design_display_name").ToString
                            newRow("qty") = FormInvoiceFGPO.GVDPFGPO.GetRowCellValue(i, "qty")
                            '
                            newRow("id_currency") = FormInvoiceFGPO.GVDPFGPO.GetRowCellValue(i, "id_currency")
                            newRow("kurs") = FormInvoiceFGPO.GVDPFGPO.GetRowCellValue(i, "prod_order_wo_kurs")
                            newRow("value_bef_kurs") = FormInvoiceFGPO.GVDPFGPO.GetRowCellValue(i, "dp_amount_bef_kurs")
                            '
                            newRow("vat") = FormInvoiceFGPO.GVDPFGPO.GetRowCellValue(i, "dp_amount_vat")
                            newRow("inv_number") = ""
                            newRow("note") = ""
                            TryCast(GCList.DataSource, DataTable).Rows.Add(newRow)
                        Next
                        calculate()
                    Catch ex As Exception
                        MsgBox(ex.ToString)
                    End Try
                ElseIf type = "2" Then 'payment
                    BtnPrint.Visible = False
                    BtnViewJournal.Visible = False
                    BMark.Visible = False
                    DEDueDate.Properties.ReadOnly = False
                    DERefDate.Properties.ReadOnly = False

                    'add detail vendor, PO, receiving
                    FormInvoiceFGPONew.ShowDialog()

                    'pop up DP
                    Dim query_pop As String = "SELECT 'no' AS is_check, pnd.id_pn_fgpo_det, pn.`id_pn_fgpo`,pn.`number`,pnd.`value`,pnd.`vat`,pnd.`inv_number`,pnd.`note` 
                ,dsg.`design_code`,dsg.`design_display_name`
                FROM `tb_pn_fgpo_det` pnd
                INNER JOIN tb_pn_fgpo pn ON pn.`id_pn_fgpo`=pnd.`id_pn_fgpo`
                INNER JOIN tb_prod_order po ON po.`id_prod_order`=pnd.`id_report` AND pnd.`report_mark_type`='22'
                INNER JOIN `tb_prod_demand_design` pdd ON pdd.`id_prod_demand_design`=po.`id_prod_demand_design`
                INNER JOIN tb_m_design dsg ON dsg.`id_design`=pdd.`id_design`
                WHERE pn.`id_report_status`= '6' AND pnd.`id_report`='" & id_po & "' AND pnd.report_mark_type='22' AND pn.`type`='1'"
                    Dim data_pop As DataTable = execute_query(query_pop, -1, True, "", "", "", "")
                    If data_pop.Rows.Count > 0 Then
                        FormInvoiceFGPODPPop.id_po = id_po
                        FormInvoiceFGPODPPop.ShowDialog()
                    End If
                    '
                    calculate()

                    If GVList.RowCount <= 0 Then
                        Close()
                    End If

                    calculate()
                End If
            End If
        Else
            SLEVatAcc.Properties.ReadOnly = True
            BAttachment.Visible = True
            BtnPrint.Visible = True
            BtnViewJournal.Visible = True
            BMark.Visible = True
            BtnSave.Visible = False
            PCAddDel.Visible = False
            DEDueDate.Properties.ReadOnly = True
            DERefDate.Properties.ReadOnly = True
            DEDueDateInv.Properties.ReadOnly = True
            '
            SLEPayType.Properties.ReadOnly = True
            SLEVendor.Properties.ReadOnly = True
            '

            Dim query As String = "SELECT pn.*,emp.`employee_name` FROM tb_pn_fgpo pn
INNER JOIN tb_m_user usr ON usr.`id_user`=pn.`created_by`
INNER JOIN tb_m_employee emp ON emp.`id_employee`=usr.`id_employee`
WHERE pn.`id_pn_fgpo`='" & id_invoice & "'"
            Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
            If data.Rows.Count > 0 Then
                TENumber.Text = data.Rows(0)("number").ToString
                DEDateCreated.EditValue = data.Rows(0)("created_date")
                DEDueDate.EditValue = data.Rows(0)("due_date")
                DEDueDateInv.EditValue = data.Rows(0)("due_date_inv")
                DERefDate.EditValue = data.Rows(0)("ref_date")

                SLEVatAcc.EditValue = data.Rows(0)("id_acc_vat").ToString
                SLEVendor.EditValue = data.Rows(0)("id_comp").ToString
                SLEPayType.EditValue = data.Rows(0)("type").ToString
                '
                MENote.Text = data.Rows(0)("note").ToString
                '
                id_report_status = data.Rows(0)("id_report_status").ToString
            End If
        End If
    End Sub

    Sub load_det()
        Dim query As String = "
Select pnd.`id_prod_order`,pnd.id_acc,pnd.`id_report` As id_report,pnd.report_mark_type, pnd.`report_number`, pnd.`info_design`, pnd.`id_pn_fgpo_det`, pnd.`qty`,pnd.`vat`, pnd.`inv_number`,pnd.value_bef_kurs,pnd.kurs,pnd.id_currency,cur.currency, pnd.`note` 
FROM tb_pn_fgpo_det pnd
INNER JOIN tb_lookup_currency cur ON cur.id_currency=pnd.id_currency
WHERE pnd.`id_pn_fgpo`='" & id_invoice & "'"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCList.DataSource = data
        GVList.BestFitColumns()
        calculate()
    End Sub

    Sub load_blank_draft()
        Cursor = Cursors.WaitCursor
        Dim query As String = "SELECT 0 AS `no`,'' AS id_acc, '' AS acc_name, '' AS acc_description, '' AS `cc`, '' AS report_number, '' AS note, 0.00 AS `debit`, 0.00 AS `credit` "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCDraft.DataSource = data
        GVDraft.DeleteSelectedRows()
        GVDraft.BestFitColumns()
        Cursor = Cursors.Default
    End Sub

    Sub empty_draft()
        For i = GVDraft.RowCount - 1 To 0 Step -1
            GVDraft.DeleteRow(i)
        Next
    End Sub

    Sub load_draft()
        Cursor = Cursors.WaitCursor
        empty_draft()
        If GVList.RowCount > 0 Then
            makeSafeGV(GVList)
            Dim jum_row As Integer = 0

            'header
            jum_row += 1
            Dim qh As String = "SELECT acc.acc_name,acc.acc_description
FROM tb_m_comp c 
INNER JOIN tb_a_acc acc ON acc.id_acc=id_acc_ap
WHERE c.id_comp='" + SLEVendor.EditValue.ToString + "' "
            Dim dh As DataTable = execute_query(qh, -1, True, "", "", "", "")
            If dh.Rows.Count > 0 Then
                'total
                If TETotal.EditValue > 0 Then
                    Dim newRowh As DataRow = (TryCast(GCDraft.DataSource, DataTable)).NewRow()
                    newRowh("no") = jum_row
                    newRowh("acc_name") = dh.Rows(0)("acc_name").ToString
                    newRowh("acc_description") = dh.Rows(0)("acc_name").ToString & " - " & dh.Rows(0)("acc_description").ToString
                    newRowh("cc") = "000"
                    newRowh("report_number") = ""
                    newRowh("note") = MENote.Text
                    newRowh("debit") = 0
                    newRowh("credit") = TETotal.EditValue + TEVat.EditValue
                    TryCast(GCDraft.DataSource, DataTable).Rows.Add(newRowh)
                    GCDraft.RefreshDataSource()
                    GVDraft.RefreshData()
                End If

                'detil
                For i As Integer = 0 To GVList.RowCount - 1
                    Dim found As Boolean = False
                    Dim row_found As Integer = 0
                    For j As Integer = 0 To GVDraft.RowCount - 1
                        row_found = j
                    Next

                    If found Then
                        GVDraft.SetRowCellValue(row_found, "debit", GVDraft.GetRowCellValue(row_found, "debit") + Math.Abs(GVList.GetRowCellValue(i, "valuex")))

                    Else
                        jum_row += 1
                        Dim newRow As DataRow = (TryCast(GCDraft.DataSource, DataTable)).NewRow()
                        newRow("no") = jum_row
                        newRow("id_acc") = GVList.GetRowCellValue(i, "id_acc").ToString
                        newRow("acc_description") = GVList.GetRowCellDisplayText(i, "id_acc").ToString
                        newRow("cc") = "000"
                        newRow("report_number") = GVList.GetRowCellValue(i, "report_number").ToString
                        newRow("note") = GVList.GetRowCellValue(i, "info_design").ToString
                        If GVList.GetRowCellValue(i, "valuex") < 0 Then
                            newRow("debit") = 0
                            newRow("credit") = Math.Abs(GVList.GetRowCellValue(i, "valuex"))
                        Else
                            newRow("debit") = Math.Abs(GVList.GetRowCellValue(i, "valuex"))
                            newRow("credit") = 0
                        End If
                        TryCast(GCDraft.DataSource, DataTable).Rows.Add(newRow)
                        GCDraft.RefreshDataSource()
                        GVDraft.RefreshData()
                    End If
                Next
                'vat
                If TEVat.EditValue > 0 Then
                    Dim newRowvat As DataRow = (TryCast(GCDraft.DataSource, DataTable)).NewRow()
                    newRowvat("no") = jum_row
                    newRowvat("acc_name") = get_acc(SLEVatAcc.EditValue, "1")
                    newRowvat("acc_description") = SLEVatAcc.Text
                    newRowvat("cc") = "000"
                    newRowvat("report_number") = ""
                    newRowvat("note") = MENote.Text
                    newRowvat("debit") = TEVat.EditValue
                    newRowvat("credit") = 0
                    TryCast(GCDraft.DataSource, DataTable).Rows.Add(newRowvat)
                End If
                '
                GCDraft.RefreshDataSource()
                GVDraft.RefreshData()

                GVDraft.BestFitColumns()
            Else
                MsgBox(SLEVendor.Text & " DP/AP account is not set")
                XTCBPL.SelectedTabPageIndex = 0
            End If
        End If
        Cursor = Cursors.Default
    End Sub

    Sub calculate()
        GVList.RefreshData()
        Dim tot As Decimal = 0.0
        Dim tot_vat As Decimal = 0.0
        Dim grand_tot As Decimal = 0.0

        Try
            tot = Decimal.Parse(GVList.Columns("valuex").SummaryItem.SummaryValue.ToString)

            TETotal.EditValue = tot
            tot_vat = Decimal.Parse(GVList.Columns("vat").SummaryItem.SummaryValue.ToString)
            TEVat.EditValue = tot_vat
            grand_tot = tot + tot_vat
            TEGrandTotal.EditValue = grand_tot

            GVList.BestFitColumns()
        Catch ex As Exception
            Console.WriteLine(ex.ToString)
        End Try
    End Sub

    Sub load_vendor()
        Dim query As String = "SELECT c.id_comp,CONCAT(c.comp_number,' - ',c.comp_name) as comp_name  
                                FROM tb_m_comp c
                                WHERE c.id_comp_cat='1' "
        viewSearchLookupQuery(SLEVendor, query, "id_comp", "comp_name", "id_comp")
    End Sub

    Private Sub BtnSave_Click(sender As Object, e As EventArgs) Handles BtnSave.Click
        'check
        Dim is_ok As Boolean = True
        'check currency and kurs
        Dim is_cur_ok As Boolean = True

        For i = 0 To GVList.RowCount - 1
            If GVList.GetRowCellValue(i, "inv_number").ToString = "" Or GVList.GetRowCellValue(i, "id_currency").ToString = "" Or GVList.GetRowCellValue(i, "id_acc").ToString = "" Then
                is_ok = False
                Exit For
            End If
            If Not GVList.GetRowCellValue(i, "id_currency").ToString = GVList.GetRowCellValue(0, "id_currency").ToString Or Not GVList.GetRowCellValue(i, "kurs").ToString = GVList.GetRowCellValue(0, "kurs").ToString Then
                is_cur_ok = False
                Exit For
            End If
        Next

        Dim is_not_mapping As Boolean = False

        Dim q_pay As String = "SELECT id_acc_dp,id_acc_ap FROM tb_m_comp WHERE id_comp='" & SLEVendor.EditValue.ToString & "'"
        Dim dt_pay As DataTable = execute_query(q_pay, -1, True, "", "", "", "")

        If SLEPayType.EditValue.ToString = "1" Then 'DP
            If dt_pay.Rows(0)("id_acc_dp").ToString = "" Then
                is_not_mapping = True
            End If
        Else 'Payment
            If dt_pay.Rows(0)("id_acc_ap").ToString = "" Then
                is_not_mapping = True
            End If
        End If

        Dim is_dup As Boolean = False

        If is_ok Then
            'check on grid
            Dim inv_number As String = ""
            For i = 0 To GVList.RowCount - 1
                'can duplicate
                If Not GVList.GetRowCellValue(i, "report_mark_type").ToString = "199" Then
                    If Not inv_number = "" Then
                        inv_number += ","
                    End If
                    inv_number += "'" & GVList.GetRowCellValue(i, "inv_number").ToString & "'"
                End If
            Next

            'check on db
            Dim check_q As String = "SELECT * FROM tb_pn_fgpo_det pnd
INNER JOIN tb_pn_fgpo pn ON pn.`id_pn_fgpo`=pnd.`id_pn_fgpo`
WHERE pn.`id_report_status`!=5 AND inv_number IN (" & inv_number & ") AND pn.id_pn_fgpo!='" & id_invoice & "'"
            Dim dt_q As DataTable = execute_query(check_q, -1, True, "", "", "", "")
            If dt_q.Rows.Count > 0 Then
                is_dup = True
            End If
            'end of check duplicate
        End If

        If Not is_ok Then
            warningCustom("Please fill all value")
        ElseIf is_dup Then
            warningCustom("Invoice number duplicate")
        ElseIf is_not_mapping Then
            warningCustom("This vendor AP account is not set.")
        ElseIf Not is_cur_ok Then
            warningCustom("Make sure currency and kurs is same")
        Else
            If id_invoice = "-1" Then
                'header
                Dim query As String = "INSERT INTO `tb_pn_fgpo`(`type`,`id_acc_vat`,`doc_type`,`created_by`,`created_date`,`note`,`id_report_status`,`id_comp`,`due_date`,`due_date_inv`,`ref_date`)
VALUES ('" & SLEPayType.EditValue.ToString & "','" & SLEVatAcc.EditValue.ToString & "','" & doc_type & "','" & id_user & "',NOW(),'" & addSlashes(MENote.Text) & "','1','" & SLEVendor.EditValue.ToString & "','" & Date.Parse(DEDueDate.EditValue.ToString).ToString("yyyy-MM-dd") & "','" & Date.Parse(DEDueDateInv.EditValue.ToString).ToString("yyyy-MM-dd") & "','" & Date.Parse(DERefDate.EditValue.ToString).ToString("yyyy-MM-dd") & "'); SELECT LAST_INSERT_ID(); "
                id_invoice = execute_query(query, 0, True, "", "", "", "")
                'detail
                query = ""
                For i = 0 To GVList.RowCount - 1 '
                    query += "INSERT INTO `tb_pn_fgpo_det`(`id_pn_fgpo`,id_prod_order,`id_acc`,`id_report`,`report_mark_type`,report_number,info_design,qty,id_currency,value_bef_kurs,kurs,`value`,`vat`,`inv_number`,`note`)
VALUES('" & id_invoice & "','" & GVList.GetRowCellValue(i, "id_prod_order").ToString & "','" & GVList.GetRowCellValue(i, "id_acc").ToString & "','" & GVList.GetRowCellValue(i, "id_report").ToString & "','" & GVList.GetRowCellValue(i, "report_mark_type").ToString & "','" & GVList.GetRowCellValue(i, "report_number").ToString & "','" & GVList.GetRowCellValue(i, "info_design").ToString & "','" & decimalSQL(GVList.GetRowCellValue(i, "qty").ToString) & "','" & GVList.GetRowCellValue(i, "id_currency").ToString & "','" & decimalSQL(GVList.GetRowCellValue(i, "value_bef_kurs").ToString) & "','" & decimalSQL(GVList.GetRowCellValue(i, "kurs").ToString) & "','" & decimalSQL(GVList.GetRowCellValue(i, "valuex").ToString) & "','" & decimalSQL(GVList.GetRowCellValue(i, "vat").ToString) & "','" & addSlashes(GVList.GetRowCellValue(i, "inv_number").ToString) & "','" & addSlashes(GVList.GetRowCellValue(i, "note").ToString) & "');"
                Next
                execute_non_query(query, True, "", "", "", "")
                '
                query = "CALL gen_number('" & id_invoice & "','189')"
                execute_non_query(query, True, "", "", "", "")
                submit_who_prepared("189", id_invoice, id_user)
                '
                infoCustom("BPL Created")
                '
                FormInvoiceFGPO.XTCInvoiceFGPO.SelectedTabPageIndex = 0
                FormInvoiceFGPO.load_list("0")
                Close()
            Else
                'edit
                Dim query As String = ""
            End If
        End If
    End Sub

    Private Sub BtnViewJournal_Click(sender As Object, e As EventArgs) Handles BtnViewJournal.Click
        Cursor = Cursors.WaitCursor
        Dim id_acc_trans As String = ""
        Try
            id_acc_trans = execute_query("SELECT ad.id_acc_trans FROM tb_a_acc_trans_det ad
            WHERE ad.report_mark_type=189 AND ad.id_report=" + id_invoice + "
            GROUP BY ad.id_acc_trans ", 0, True, "", "", "", "")
        Catch ex As Exception
            id_acc_trans = ""
        End Try

        If id_acc_trans <> "" Then
            Dim s As New ClassShowPopUp()
            FormViewJournal.is_enable_view_doc = False
            FormViewJournal.BMark.Visible = False
            s.id_report = id_acc_trans
            s.report_mark_type = "36"
            s.show()
        Else
            warningCustom("Auto journal not found.")
        End If
        Cursor = Cursors.Default
    End Sub

    Private Sub FormInvoiceFGPODP_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub BMark_Click(sender As Object, e As EventArgs) Handles BMark.Click
        FormReportMark.report_mark_type = "189"
        FormReportMark.is_view = is_view
        FormReportMark.id_report = id_invoice
        FormReportMark.ShowDialog()
    End Sub

    Private Sub SMEditCost_Click(sender As Object, e As EventArgs) Handles SMEditCost.Click
        If GVList.RowCount > 0 Then
            FormInvoiceFGPODPSplit.ShowDialog()
        End If
    End Sub

    Private Sub BDP_Click(sender As Object, e As EventArgs) 

    End Sub

    Private Sub BDelete_Click(sender As Object, e As EventArgs) 
        If GVList.RowCount > 0 Then
            GVList.DeleteSelectedRows()
            calculate()
        End If
    End Sub

    Private Sub BtnPrint_Click(sender As Object, e As EventArgs) Handles BtnPrint.Click
        Cursor = Cursors.WaitCursor
        ReportFGPODP.id_pn_fgpo = id_invoice
        Dim q_print As String = "Select pnd.`id_prod_order`,po.prod_order_number,pnd.id_acc,pnd.`id_report` As id_report,pnd.report_mark_type, pnd.`report_number`, pnd.`info_design`, pnd.`id_pn_fgpo_det`, pnd.`qty`,pnd.`vat`, pnd.`inv_number`,pnd.value_bef_kurs,pnd.kurs,pnd.id_currency,cur.currency, pnd.`note` 
FROM tb_pn_fgpo_det pnd
INNER JOIN tb_lookup_currency cur ON cur.id_currency=pnd.id_currency
LEFT JOIN tb_prod_order po ON po.id_prod_order=pnd.id_prod_order 
WHERE pnd.`id_pn_fgpo`='" & id_invoice & "' AND pnd.report_mark_type!='199'"
        Dim dt As DataTable = execute_query(q_print, -1, True, "", "", "", "")
        'ReportFGPODP.dt = GCList.DataSource
        ReportFGPODP.dt = dt
        Dim Report As New ReportFGPODP()
        ' '... 
        ' ' creating and saving the view's layout to a new memory stream 
        For i = 0 To GVList.RowCount - 1
            GVList.SetRowCellValue(i, "currency", GVList.GetRowCellDisplayText(0, "id_currency").ToString)
        Next

        GCCur.VisibleIndex = -1
        GCCurHide.VisibleIndex = 5
        GridColumnAccPick.VisibleIndex = -1
        GridColumnNote.VisibleIndex = -1
        GCPORef.VisibleIndex = 1

        Dim str As System.IO.Stream
        str = New System.IO.MemoryStream()
        GVList.SaveLayoutToStream(str, DevExpress.Utils.OptionsLayoutBase.FullLayout)
        str.Seek(0, System.IO.SeekOrigin.Begin)
        Report.GVList.RestoreLayoutFromStream(str, DevExpress.Utils.OptionsLayoutBase.FullLayout)
        str.Seek(0, System.IO.SeekOrigin.Begin)

        'Grid Detail
        ReportStyleGridview(Report.GVList)
        Report.GVList.OptionsPrint.PrintFooter = False

        GridColumnAccPick.VisibleIndex = 0
        GCCur.VisibleIndex = 5
        GCCurHide.VisibleIndex = -1
        GridColumnNote.VisibleIndex = 10
        GCPORef.VisibleIndex = -1

        'search total
        Dim tot As String = Decimal.Parse("0").ToString("N2")
        Dim tot_vat As String = Decimal.Parse("0").ToString("N2")
        Dim q_tot As String = "SELECT IFNULL(SUM(pnd.value),0) AS tot,IFNULL(SUM(pnd.vat),0) AS tot_vat FROM tb_pn_fgpo_det pnd 
INNER JOIN tb_lookup_currency cur ON cur.id_currency=pnd.id_currency 
WHERE pnd.`id_pn_fgpo`='" & id_invoice & "' AND pnd.report_mark_type!='199'"
        Dim dt_tot As DataTable = execute_query(q_tot, -1, True, "", "", "", "")
        If dt_tot.Rows.Count > 0 Then
            tot = Decimal.Parse(dt_tot.Rows(0)("tot").ToString).ToString("N2")
            tot_vat = Decimal.Parse(dt_tot.Rows(0)("tot_vat").ToString).ToString("N2")
        End If

        'search dp
        Dim dp As String = Decimal.Parse("0").ToString("N2")
        Dim q_dp As String = "SELECT IFNULL(SUM(pnd.value+pnd.vat),0) AS tot_dp FROM tb_pn_fgpo_det pnd 
INNER JOIN tb_lookup_currency cur ON cur.id_currency=pnd.id_currency 
WHERE pnd.`id_pn_fgpo`='" & id_invoice & "' AND pnd.report_mark_type='199'"
        Dim dt_dp As DataTable = execute_query(q_dp, -1, True, "", "", "", "")
        If dt_dp.Rows.Count > 0 Then
            dp = Decimal.Parse(dt_dp.Rows(0)("tot_dp").ToString).ToString("N2")
        End If
        'Parse val
        Dim query As String = "SELECT '" & TENumber.Text & "' AS number,'" & addSlashes(MENote.Text) & "' AS note,'" & ConvertCurrencyToIndonesian(TEGrandTotal.EditValue) & "' AS tot_say,'" & SLEPayType.Text & "' AS type,'" & SLEVendor.Text & "' AS comp_name,'" & DERefDate.Text & "' AS ref_date,'" & DEDueDate.Text & "' AS due_date,'" & DEDueDateInv.Text & "' AS due_date_inv,'" & tot & "' AS total_amount,'" & tot_vat & "' AS total_vat,'" & dp & "' AS tot_dp,'" & TEGrandTotal.Text & "' AS total_after_vat,'" & DEDateCreated.Text & "' AS date_created,DATE_FORMAT(NOW(),'%d %M %Y') AS printed_date"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        Report.DataSource = data

        If Not id_report_status = "6" Then
            Report.id_pre = "2"
        Else
            Report.id_pre = "1"
        End If

        'Show the report's preview. 
        Dim Tool As DevExpress.XtraReports.UI.ReportPrintTool = New DevExpress.XtraReports.UI.ReportPrintTool(Report)
        Tool.ShowPreview()
        Cursor = Cursors.Default
    End Sub

    Private Sub BtnAdd_Click(sender As Object, e As EventArgs) Handles BtnAdd.Click
        FormInvoiceFGPOAdd.ShowDialog()
    End Sub

    Private Sub BtnDelete_Click(sender As Object, e As EventArgs) Handles BtnDelete.Click
        If GVList.RowCount > 0 Then
            GVList.DeleteSelectedRows()
            calculate()
        End If
    End Sub

    Private Sub BAddNewRow_Click(sender As Object, e As EventArgs) Handles BAddNewRow.Click
        Dim newRow As DataRow = (TryCast(GCList.DataSource, DataTable)).NewRow()
        '
        newRow("qty") = 1

        If GVList.RowCount >= 1 Then
            newRow("id_currency") = GVList.GetRowCellValue(0, "id_currency")
            newRow("kurs") = GVList.GetRowCellValue(0, "kurs")
        Else
            newRow("id_currency") = 1
            newRow("kurs") = 1
        End If

        newRow("value_bef_kurs") = 0
        '
        newRow("vat") = 0
        newRow("inv_number") = ""
        newRow("note") = ""

        TryCast(GCList.DataSource, DataTable).Rows.Add(newRow)
    End Sub

    Private Sub GVList_CellValueChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles GVList.CellValueChanged
        If e.Column.FieldName = "value_bef_kurs" Or e.Column.FieldName = "kurs" Or e.Column.FieldName = "vat" Then
            calculate()
        End If
    End Sub

    Private Sub XTCBPL_SelectedPageChanged(sender As Object, e As DevExpress.XtraTab.TabPageChangedEventArgs) Handles XTCBPL.SelectedPageChanged
        If XTCBPL.SelectedTabPageIndex = 1 Then
            load_draft()
        End If
    End Sub

    Private Sub BPickDP_Click(sender As Object, e As EventArgs) Handles BPickDP.Click
        FormInvoiceFGPODPPop.ShowDialog()
    End Sub

    Private Sub BAttachment_Click(sender As Object, e As EventArgs) Handles BAttachment.Click
        Cursor = Cursors.WaitCursor
        FormDocumentUpload.is_view = is_view
        If Not id_report_status = "1" Or is_view = "1" Then
            FormDocumentUpload.is_no_delete = "1"
        End If
        FormDocumentUpload.id_report = id_invoice
        FormDocumentUpload.report_mark_type = "189"
        FormDocumentUpload.ShowDialog()
        Cursor = Cursors.Default
    End Sub
End Class