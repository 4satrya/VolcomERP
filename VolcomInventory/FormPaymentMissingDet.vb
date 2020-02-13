Imports DevExpress.XtraReports.UI

Public Class FormPaymentMissingDet
    Public id_missing_payment As String = "-1"
    Public is_view As String = "-1"
    Dim id_report_status As String = "-1"
    Public type_rec As String = "1" '1 = invoice

    Private Sub FormPaymentMissingDet_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        form_load()
    End Sub

    Private Sub FormPaymentMissingDet_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Sub form_load()
        viewReportStatus()
        load_receive_from()
        load_pay_from()
        '
        TEPayNumber.Text = "[auto_generate]"
        Dim dt_now As DateTime = getTimeDB()
        DEDateCreated.EditValue = dt_now
        DERecDate.EditValue = dt_now
        TETotal.EditValue = 0.00
        TENeedToPay.EditValue = 0.00
        '
        If id_missing_payment = "-1" Then 'new
            load_det()
            BtnPrint.Visible = False
            BMark.Visible = False
            BtnSave.Visible = True

            'load header
            SLEStore.EditValue = FormPaymentMissing.SLEStoreInvoice.EditValue

            'load detail
            For i As Integer = 0 To FormPaymentMissing.GVInvoiceList.RowCount - 1
                'id_report,number,total,balance due
                Dim newRow As DataRow = (TryCast(GCList.DataSource, DataTable)).NewRow()
                newRow("id_report") = FormPaymentMissing.GVInvoiceList.GetRowCellValue(i, "id_sales_pos").ToString
                newRow("report_mark_type") = FormPaymentMissing.GVInvoiceList.GetRowCellValue(i, "report_mark_type").ToString
                newRow("report_mark_type_name") = FormPaymentMissing.GVInvoiceList.GetRowCellValue(i, "report_mark_type_name").ToString
                newRow("number") = FormPaymentMissing.GVInvoiceList.GetRowCellValue(i, "sales_pos_number").ToString
                newRow("id_comp") = FormPaymentMissing.GVInvoiceList.GetRowCellValue(i, "id_comp_default").ToString
                newRow("id_acc") = FormPaymentMissing.GVInvoiceList.GetRowCellValue(i, "id_acc").ToString
                newRow("acc_name") = FormPaymentMissing.GVInvoiceList.GetRowCellValue(i, "acc_name").ToString
                newRow("acc_description") = FormPaymentMissing.GVInvoiceList.GetRowCellValue(i, "acc_description").ToString
                newRow("comp_number") = FormPaymentMissing.GVInvoiceList.GetRowCellValue(i, "comp_number_default").ToString
                newRow("vendor") = FormPaymentMissing.GVInvoiceList.GetRowCellValue(i, "comp_number").ToString
                newRow("total_rec") = FormPaymentMissing.GVInvoiceList.GetRowCellValue(i, "total_rec")
                newRow("value") = FormPaymentMissing.GVInvoiceList.GetRowCellValue(i, "total_due")
                newRow("balance_due") = FormPaymentMissing.GVInvoiceList.GetRowCellValue(i, "total_due")
                newRow("note") = FormPaymentMissing.GVInvoiceList.GetRowCellValue(i, "note").ToString
                newRow("id_dc") = FormPaymentMissing.GVInvoiceList.GetRowCellValue(i, "id_dc").ToString
                newRow("dc_code") = FormPaymentMissing.GVInvoiceList.GetRowCellValue(i, "dc_code").ToString
                newRow("value_view") = Math.Abs(FormPaymentMissing.GVInvoiceList.GetRowCellValue(i, "total_due"))
                TryCast(GCList.DataSource, DataTable).Rows.Add(newRow)
            Next

            'auto select receive payment to base on company
            If GVList.RowCount > 0 Then
                SLEPayRecTo.EditValue = execute_query("SELECT IFNULL((SELECT id_acc_tabungan_missing FROM tb_m_comp WHERE id_comp = (SELECT cc.`id_comp` FROM tb_sales_pos sp INNER JOIN tb_m_comp_contact cc ON cc.`id_comp_contact`= IF(sp.id_memo_type=8 OR sp.id_memo_type=9, sp.id_comp_contact_bill,sp.`id_store_contact_from`) WHERE sp.id_sales_pos = " + GVList.GetRowCellValue(0, "id_report").ToString + ")), 6) AS id_comp", 0, True, "", "", "", "")
            End If

            calculate_amount()
        Else
            PanelControlNav.Visible = False
            BtnPrint.Visible = True
            BMark.Visible = True
            BtnSave.Visible = False
            SLEPayFrom.Enabled = False
            SLEPayRecTo.Enabled = False
            MENote.Enabled = False
            PanelControlPreview.Visible = True
            '
            Dim query As String = "SELECT * FROM tb_missing_payment WHERE id_missing_payment='" & id_missing_payment & "'"
            Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
            If data.Rows.Count > 0 Then
                TEPayNumber.Text = data.Rows(0)("number").ToString
                SLEStore.EditValue = data.Rows(0)("id_comp_contact").ToString
                '
                If data.Rows(0)("id_report_status").ToString = "6" Then
                    BtnViewJournal.Visible = True
                Else
                    BtnViewJournal.Visible = False
                End If
                '
                DEDateCreated.EditValue = data.Rows(0)("date_created")
                DERecDate.EditValue = data.Rows(0)("date_received")
                SLEPayRecTo.EditValue = data.Rows(0)("id_acc_pay_rec").ToString
                '
                SLEPayFrom.EditValue = data.Rows(0)("id_acc_pay_to").ToString
                TENeedToPay.EditValue = data.Rows(0)("val_need_pay")
                '
                MENote.EditValue = data.Rows(0)("note").ToString
                id_report_status = data.Rows(0)("id_report_status").ToString
                LEReportStatus.ItemIndex = LEReportStatus.Properties.GetDataSourceRowIndex("id_report_status", data.Rows(0)("id_report_status").ToString)
                type_rec = data.Rows(0)("type_rec").ToString
            End If
            '
            load_det()
            PanelControlNav.Visible = False
            DERecDate.Properties.ReadOnly = True
            GridColumnAlreadyReceived.Visible = False
            GridColumnBBaldue.Visible = False
            GridColumnReceive.OptionsColumn.AllowEdit = False
            GridColumnNote.OptionsColumn.AllowEdit = False
            If id_report_status = "6" Then
                XTPDraft.PageVisible = False
            End If
            calculate_amount()
        End If
    End Sub

    Sub viewReportStatus()
        Dim query As String = "SELECT * FROM tb_lookup_report_status a ORDER BY a.id_report_status "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        viewLookupQuery(LEReportStatus, query, 0, "report_status", "id_report_status")
    End Sub

    Sub load_receive_from()
        Dim query As String = "SELECT id_acc,acc_name,acc_description FROM `tb_a_acc` WHERE id_status='1' AND id_is_det='2'"
        viewSearchLookupQuery(SLEPayRecTo, query, "id_acc", "acc_description", "id_acc")
    End Sub
    '
    Sub load_pay_from()
        Dim query As String = "SELECT id_acc,acc_name,acc_description FROM `tb_a_acc` WHERE id_status='1' AND id_is_det='2'"
        viewSearchLookupQuery(SLEPayFrom, query, "id_acc", "acc_description", "id_acc")
    End Sub

    Sub load_det()
        Dim query As String = "SELECT recd.id_missing_payment_det,recd.id_report,recd.report_mark_type,
        rmt.report_mark_type_name,recd.number,recd.total_rec,recd.`value`,recd.balance_due,recd.note,
        if(recd.id_dc=1, recd.`value`*-1, recd.`value`) AS `value_view`,
        recd.id_comp, c.comp_number, c.comp_name, recd.id_acc, coa.acc_name, coa.acc_description, coa.acc_description, 
        recd.id_dc,dc.dc_code, recd.vendor
        FROM tb_missing_payment_det recd 
        LEFT JOIN tb_lookup_report_mark_type rmt ON rmt.`report_mark_type`=recd.report_mark_type
        LEFT JOIN tb_m_comp c ON c.id_comp = recd.id_comp
        INNER JOIN tb_a_acc coa ON coa.id_acc = recd.id_acc
        INNER JOIN tb_lookup_dc dc ON dc.id_dc = recd.id_dc
        WHERE recd.id_missing_payment='" & id_missing_payment & "' ORDER BY recd.id_missing_payment_det ASC "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCList.DataSource = data
        GVList.BestFitColumns()
    End Sub

    Sub calculate_amount()
        GVList.RefreshData()
        Dim gross_total As Double = 0.0
        Try
            gross_total = Double.Parse(GVList.Columns("value").SummaryItem.SummaryValue.ToString)
        Catch ex As Exception
        End Try
        '
        If gross_total >= 0 Then
            LPayFrom.Visible = False
            LNeedToPay.Visible = False
            '
            SLEPayFrom.Visible = False
            TENeedToPay.Visible = False
            '
            TENeedToPay.EditValue = 0.00
            TETotal.EditValue = gross_total
        End If
        '
        GVList.BestFitColumns()
    End Sub

    Private Sub BtnSave_Click(sender As Object, e As EventArgs) Handles BtnSave.Click
        makeSafeGV(GVList)
        GCList.RefreshDataSource()
        GVList.RefreshData()
        calculate_amount()

        Dim query As String = ""
        'check first
        'more than value
        Dim value_exceed As Boolean = False
        For i As Integer = 0 To GVList.RowCount - 1
            If GVList.GetRowCellValue(i, "balance_due") < 0 Then 'need minus not exceed 0
                If GVList.GetRowCellValue(i, "value") > 0 Or GVList.GetRowCellValue(i, "value") < GVList.GetRowCellValue(i, "balance_due") Then
                    value_exceed = True
                End If
            Else 'normal
                If GVList.GetRowCellValue(i, "value") < 0 Or GVList.GetRowCellValue(i, "value") > GVList.GetRowCellValue(i, "balance_due") Then
                    value_exceed = True
                End If
            End If
        Next
        '

        'cek balance journal
        Dim cond_bal As Boolean = True
        XTCBBM.SelectedTabPageIndex = 1
        makeSafeGV(GVDraft)
        If GVDraft.Columns("debit").SummaryItem.SummaryValue = GVDraft.Columns("credit").SummaryItem.SummaryValue Then
            cond_bal = True
            XTCBBM.SelectedTabPageIndex = 0
        Else
            cond_bal = False
        End If

        If TETotal.EditValue = 0 And TENeedToPay.EditValue = 0 Then
            warningCustom("Please make sure amount is not 0")
        ElseIf value_exceed = True Then
            warningCustom("Please make sure amount credit note is not exceed 0, received amount not below 0, and not exceed balance due")
        ElseIf Not cond_bal Then
            warningCustom("Journal not balance please check your input")
        Else
            Dim confirm As DialogResult = DevExpress.XtraEditors.XtraMessageBox.Show("Are you sure want to save this data ?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
            If confirm = Windows.Forms.DialogResult.Yes Then
                Dim date_received As String = DateTime.Parse(DERecDate.EditValue.ToString).ToString("yyyy-MM-dd")
                If id_missing_payment = "-1" Then 'new
                    Dim id_comp_contact As String = "NULL"
                    'if there is need to pay
                    Dim need_to_pay_amount As String = "0.00"
                    Dim need_to_pay_account As String = "NULL"
                    If TENeedToPay.EditValue > 0 Then
                        need_to_pay_amount = decimalSQL(TENeedToPay.EditValue.ToString)
                        need_to_pay_account = SLEPayFrom.EditValue.ToString
                    End If

                    query = "INSERT INTO tb_missing_payment(`id_acc_pay_rec`,`id_comp_contact`,`id_user_created`,`date_created`, `date_received`,`value`,`note`,`val_need_pay`,`id_acc_pay_to`,`id_report_status`, type_rec)
                    VALUES ('" & SLEPayRecTo.EditValue.ToString & "'," + id_comp_contact + ",'" & id_user & "',NOW(),'" + date_received + "','" & decimalSQL(TETotal.EditValue.ToString) & "','" & addSlashes(MENote.Text) & "','" & need_to_pay_amount & "'," & need_to_pay_account & ",'1', '" + type_rec + "'); SELECT LAST_INSERT_ID();"
                    id_missing_payment = execute_query(query, 0, True, "", "", "", "")

                    'detail
                    query = "INSERT INTO tb_missing_payment_det(`id_missing_payment`,`id_report`,`report_mark_type`,`number`,`total_rec`,`value`,`balance_due`,`note`, id_comp, id_acc, id_dc, vendor) VALUES"
                    For i As Integer = 0 To GVList.RowCount - 1
                        Dim id_report As String = GVList.GetRowCellValue(i, "id_report").ToString
                        If id_report = "0" Then
                            id_report = "NULL"
                        End If
                        Dim report_mark_type As String = GVList.GetRowCellValue(i, "report_mark_type").ToString
                        If report_mark_type = "0" Then
                            report_mark_type = "NULL"
                        End If
                        Dim id_comp As String = GVList.GetRowCellValue(i, "id_comp").ToString
                        If id_comp = "0" Then
                            id_comp = "NULL"
                        End If
                        Dim id_acc As String = GVList.GetRowCellValue(i, "id_acc").ToString
                        Dim id_dc As String = GVList.GetRowCellValue(i, "id_dc").ToString
                        Dim vendor As String = GVList.GetRowCellValue(i, "vendor").ToString

                        If Not i = 0 Then
                            query += ","
                        End If
                        query += "('" & id_missing_payment & "'," + id_report + "," + report_mark_type + ",'" & GVList.GetRowCellValue(i, "number").ToString & "','" & decimalSQL(GVList.GetRowCellValue(i, "total_rec").ToString) & "','" & decimalSQL(GVList.GetRowCellValue(i, "value").ToString) & "','" & decimalSQL(GVList.GetRowCellValue(i, "balance_due").ToString) & "','" & addSlashes(GVList.GetRowCellValue(i, "note").ToString) & "', " + id_comp + ", " + id_acc + ", " + id_dc + ", '" + vendor + "') "
                    Next
                    execute_non_query(query, True, "", "", "", "")

                    'generate number
                    query = "CALL gen_number('" & id_missing_payment & "','237')"
                    execute_non_query(query, True, "", "", "", "")
                    'add mark
                    submit_who_prepared("237", id_missing_payment, id_user)
                    'done
                    infoCustom("Receive Payment created. Waiting for approval")
                    'FormPaymentMissing.load_invoice()
                    'FormPaymentMissing.SLEStoreDeposit.EditValue = SLEStore.EditValue
                    FormPaymentMissing.GCInvoiceList.DataSource = Nothing
                    FormPaymentMissing.load_deposit()
                    FormPaymentMissing.GridViewMissing.FocusedRowHandle = find_row(FormPaymentMissing.GridViewMissing, "id_missing_payment", id_missing_payment)
                    FormPaymentMissing.XTCPO.SelectedTabPageIndex = 0
                    form_load()
                End If
            End If
        End If
    End Sub

    Private Sub BtnCancel_Click(sender As Object, e As EventArgs) Handles BtnCancel.Click
        Close()
    End Sub

    Private Sub XTCBBM_SelectedPageChanged(sender As Object, e As DevExpress.XtraTab.TabPageChangedEventArgs) Handles XTCBBM.SelectedPageChanged
        If XTCBBM.SelectedTabPageIndex = 1 Then
            viewBlankJournal()
            viewDraftJournal()
        End If
    End Sub

    Sub viewBlankJournal()
        Cursor = Cursors.WaitCursor
        Dim query As String = "SELECT 0 AS `no`, '' AS acc_name, '' AS acc_description, '' AS `cc`, '' AS report_number, '' AS note, 0.00 AS `debit`, 0.00 AS `credit` "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCDraft.DataSource = data
        GVDraft.DeleteSelectedRows()
        GVDraft.BestFitColumns()
        Cursor = Cursors.Default
    End Sub

    Sub viewDraftJournal()
        Cursor = Cursors.WaitCursor
        If GVList.RowCount > 0 Then
            makeSafeGV(GVList)
            Dim jum_row As Integer = 0

            'header
            jum_row += 1
            Dim qh As String = "SELECT * FROM tb_a_acc WHERE id_acc='" + SLEPayRecTo.EditValue.ToString + "' "
            Dim dh As DataTable = execute_query(qh, -1, True, "", "", "", "")
            Dim newRowh As DataRow = (TryCast(GCDraft.DataSource, DataTable)).NewRow()
            newRowh("no") = jum_row
            newRowh("acc_name") = dh.Rows(0)("acc_name").ToString
            newRowh("acc_description") = dh.Rows(0)("acc_description").ToString
            newRowh("cc") = "000"
            newRowh("report_number") = ""
            newRowh("note") = MENote.Text
            newRowh("debit") = TETotal.EditValue
            newRowh("credit") = 0
            TryCast(GCDraft.DataSource, DataTable).Rows.Add(newRowh)
            GCDraft.RefreshDataSource()
            GVDraft.RefreshData()

            'detil
            For i As Integer = 0 To GVList.RowCount - 1
                jum_row += 1
                Dim newRow As DataRow = (TryCast(GCDraft.DataSource, DataTable)).NewRow()
                newRow("no") = jum_row
                newRow("acc_name") = GVList.GetRowCellValue(i, "acc_name").ToString
                newRow("acc_description") = GVList.GetRowCellValue(i, "acc_description").ToString
                newRow("cc") = GVList.GetRowCellValue(i, "comp_number").ToString
                newRow("report_number") = GVList.GetRowCellValue(i, "number").ToString
                newRow("note") = GVList.GetRowCellValue(i, "note").ToString
                If GVList.GetRowCellValue(i, "id_dc").ToString = "1" Then
                    newRow("debit") = Math.Abs(GVList.GetRowCellValue(i, "value"))
                    newRow("credit") = 0
                Else
                    newRow("debit") = 0
                    newRow("credit") = GVList.GetRowCellValue(i, "value")
                End If
                TryCast(GCDraft.DataSource, DataTable).Rows.Add(newRow)
                GCDraft.RefreshDataSource()
                GVDraft.RefreshData()
            Next
            GVDraft.BestFitColumns()
        End If
        Cursor = Cursors.Default
    End Sub

    Private Sub BtnAdd_Click(sender As Object, e As EventArgs) Handles BtnAdd.Click
        If id_missing_payment = "-1" Then
            Cursor = Cursors.WaitCursor
            FormPaymentMissingAdd.action = "ins"
            FormPaymentMissingAdd.ShowDialog()
            Cursor = Cursors.Default
        End If
    End Sub

    Private Sub BtnDelete_Click(sender As Object, e As EventArgs) Handles BtnDelete.Click
        If GVList.RowCount > 0 And GVList.FocusedRowHandle >= 0 Then
            Dim confirm As DialogResult = DevExpress.XtraEditors.XtraMessageBox.Show("Are you sure want to delete this detail ?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
            If confirm = Windows.Forms.DialogResult.Yes Then
                Cursor = Cursors.WaitCursor
                GVList.DeleteSelectedRows()
                GCList.RefreshDataSource()
                GVList.RefreshData()
                calculate_amount()
                Cursor = Cursors.Default
            End If
        End If
    End Sub

    Private Sub BMark_Click(sender As Object, e As EventArgs) Handles BMark.Click
        FormReportMark.report_mark_type = "237"
        FormReportMark.is_view = is_view
        FormReportMark.id_report = id_missing_payment
        FormReportMark.ShowDialog()
    End Sub

    Private Sub BtnViewJournal_Click(sender As Object, e As EventArgs) Handles BtnViewJournal.Click
        Cursor = Cursors.WaitCursor
        Dim id_acc_trans As String = ""
        Try
            id_acc_trans = execute_query("SELECT ad.id_acc_trans FROM tb_a_acc_trans_det ad
            WHERE ad.report_mark_type=237 AND ad.id_report=" + id_missing_payment + "
            GROUP BY ad.id_acc_trans ", 0, True, "", "", "", "")
        Catch ex As Exception
            id_acc_trans = ""
        End Try

        If id_acc_trans <> "" Then
            Dim s As New ClassShowPopUp()
            FormViewJournal.is_enable_view_doc = False
            FormViewJournal.BMark.Visible = False
            FormViewJournal.show_trans_number = True
            s.id_report = id_acc_trans
            s.report_mark_type = "36"
            s.show()
        Else
            warningCustom("Auto journal not found.")
        End If
        Cursor = Cursors.Default
    End Sub

    Private Sub BtnPrint_Click(sender As Object, e As EventArgs) Handles BtnPrint.Click
        Cursor = Cursors.WaitCursor
        ReportPaymentMissing.id = id_missing_payment
        ReportPaymentMissing.id_report_status = id_report_status
        ReportPaymentMissing.rmt = "237"
        Dim Report As New ReportPaymentMissing()

        If CEPrintPreview.EditValue = True Then
            Dim Tool As DevExpress.XtraReports.UI.ReportPrintTool = New DevExpress.XtraReports.UI.ReportPrintTool(Report)
            Tool.ShowPreviewDialog()
        Else
            Dim instance As New Printing.PrinterSettings
            Dim DefaultPrinter As String = instance.PrinterName

            ' THIS IS TO PRINT THE REPORT
            Report.PrinterName = DefaultPrinter
            Report.CreateDocument()
            Report.PrintingSystem.ShowMarginsWarning = False
            Report.Print()
        End If


        '        ReportBankDeposit.id_deposit = id_deposit
        '        ReportBankDeposit.dt = GCList.DataSource
        '        Dim Report As New ReportBankDeposit()
        '        ' '... 
        '        ' ' creating and saving the view's layout to a new memory stream 
        '        Dim str As System.IO.Stream
        '        str = New System.IO.MemoryStream()
        '        GVList.SaveLayoutToStream(str, DevExpress.Utils.OptionsLayoutBase.FullLayout)
        '        str.Seek(0, System.IO.SeekOrigin.Begin)
        '        Report.GVList.RestoreLayoutFromStream(str, DevExpress.Utils.OptionsLayoutBase.FullLayout)
        '        str.Seek(0, System.IO.SeekOrigin.Begin)

        '        'Grid Detail
        '        ReportStyleGridview(Report.GVList)

        '        'Parse val
        '        Dim query As String = "SELECT rec_py.id_report_status,acc.`acc_description` AS acc_pay_rec,IFNULL(acc_pay.`acc_description`,'') AS acc_pay_to,rec_py.number,sts.report_status,emp.employee_name AS created_by, rec_py.date_created, FORMAT(rec_py.val_need_pay,2,'id_ID') AS total_need_pay, rec_py.`id_rec_payment`,FORMAT(rec_py.`value`,2,'ID_id') AS total_amount,CONCAT(c.`comp_number`,' - ',c.`comp_name`) AS comp_name,rec_py.note
        'FROM tb_rec_payment rec_py
        'INNER JOIN tb_m_comp_contact cc ON cc.`id_comp_contact`=rec_py.`id_comp_contact`
        'INNER JOIN tb_m_comp c ON c.`id_comp`=cc.`id_comp`
        'INNER JOIN tb_m_user usr ON usr.id_user=rec_py.id_user_created
        'INNER JOIN tb_m_employee emp ON emp.id_employee=usr.id_employee
        'INNER JOIN tb_lookup_report_status sts ON sts.id_report_status=rec_py.id_report_status
        'INNER JOIN tb_a_acc acc ON acc.`id_acc`=rec_py.`id_acc_pay_rec`
        'LEFT JOIN tb_a_acc acc_pay ON acc_pay.`id_acc`=rec_py.`id_acc_pay_to`
        'WHERE rec_py.`id_rec_payment`='" & id_deposit & "'"
        '        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        '        '
        '        If Not data.Rows(0)("acc_pay_to").ToString = "" Then
        '            Report.LRecTo.Text = "[acc_pay_to]"
        '            Report.LTotalAmount.Text = "[total_need_pay]"
        '            '
        '            Report.LRecToText.Text = "Pay From"
        '            Report.LTotalAmountText.Text = "Amount"
        '        End If
        '        '
        '        Report.DataSource = data

        '        If Not data.Rows(0)("id_report_status").ToString = "6" Then
        '            Report.id_pre = "2"
        '        Else
        '            Report.id_pre = "1"
        '        End If

        '        'Show the report's preview. 
        '        Dim Tool As DevExpress.XtraReports.UI.ReportPrintTool = New DevExpress.XtraReports.UI.ReportPrintTool(Report)
        '        Tool.ShowPreview()
        Cursor = Cursors.Default
    End Sub

    Private Sub GVList_CellValueChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles GVList.CellValueChanged
        If e.Column.FieldName.ToString = "value" Then
            'set value
            calculate_amount()
        ElseIf e.Column.FieldName.ToString = "value_view" Then
            Dim rh As Integer = e.RowHandle
            Dim val As Decimal = 0
            Dim id_dc As String = GVList.GetRowCellValue(rh, "id_dc").ToString
            If id_dc = "1" Then 'debit
                val = e.Value * -1
            Else
                val = e.Value
            End If
            GVList.SetRowCellValue(rh, "value", val)
        End If
    End Sub

    Private Sub GVList_CustomColumnDisplayText(sender As Object, e As DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs) Handles GVList.CustomColumnDisplayText
        If e.Column.FieldName = "no" Then
            e.DisplayText = (e.ListSourceRowIndex + 1).ToString()
        End If
    End Sub

    Private Sub GVList_DoubleClick(sender As Object, e As EventArgs) Handles GVList.DoubleClick
        If id_missing_payment = "-1" And GVList.FocusedRowHandle >= 0 Then
            If GVList.GetFocusedRowCellValue("id_report") = "0" Then
                Cursor = Cursors.WaitCursor
                FormPaymentMissingAdd.action = "upd"
                FormPaymentMissingAdd.ShowDialog()
                Cursor = Cursors.Default
            End If
        End If
    End Sub
End Class