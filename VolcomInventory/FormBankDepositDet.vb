Public Class FormBankDepositDet
    Public id_deposit As String = "-1"
    Public is_view As String = "-1"
    '
    Private Sub FormBankDepositDet_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        form_load()
    End Sub

    Sub form_load()
        load_receive_from()
        load_pay_from()
        load_store()
        '
        Try
            TEPayNumber.Text = "[auto_generate]"
            DEDateCreated.EditValue = Now()
            TETotal.EditValue = 0.00
            TENeedToPay.EditValue = 0.00
            '
            If id_deposit = "-1" Then 'new
                load_det()
                BtnPrint.Visible = False
                BMark.Visible = False
                BtnSave.Visible = True
                'check account
                Dim query_check As String = "SELECT IFNULL(id_acc_ar,0) AS id_acc_ar FROM tb_m_comp c
INNER JOIN tb_m_comp_contact cc ON cc.id_comp = c.id_comp
WHERE cc.id_comp_contact='" & FormBankDeposit.SLEStoreInvoice.EditValue & "'"
                Dim data_check As DataTable = execute_query(query_check, -1, True, "", "", "", "")
                If data_check.Rows(0)("id_acc_ar").ToString = "0" Then
                    warningCustom("This vendor AP account is not set.")
                    Close()
                End If
                'load header
                SLEStore.EditValue = FormBankDeposit.SLEStoreInvoice.EditValue
                'load detail
                For i As Integer = 0 To FormBankDeposit.GVInvoiceList.RowCount - 1
                    'id_report,number,total,balance due
                    Dim newRow As DataRow = (TryCast(GCList.DataSource, DataTable)).NewRow()
                    newRow("id_report") = FormBankDeposit.GVInvoiceList.GetRowCellValue(i, "id_sales_pos").ToString
                    newRow("report_mark_type") = FormBankDeposit.GVInvoiceList.GetRowCellValue(i, "report_mark_type").ToString
                    newRow("report_mark_type_name") = FormBankDeposit.GVInvoiceList.GetRowCellValue(i, "report_mark_type_name").ToString
                    newRow("number") = FormBankDeposit.GVInvoiceList.GetRowCellValue(i, "sales_pos_number").ToString
                    newRow("total_rec") = FormBankDeposit.GVInvoiceList.GetRowCellValue(i, "total_rec").ToString
                    newRow("value") = FormBankDeposit.GVInvoiceList.GetRowCellValue(i, "total_due").ToString
                    newRow("balance_due") = FormBankDeposit.GVInvoiceList.GetRowCellValue(i, "total_due").ToString
                    newRow("note") = ""
                    TryCast(GCList.DataSource, DataTable).Rows.Add(newRow)
                Next
                calculate_amount()
            Else
                BtnPrint.Visible = True
                BMark.Visible = True
                BtnSave.Visible = False
                SLEPayFrom.Enabled = False
                SLEPayRecTo.Enabled = False
                MENote.Enabled = False
                '
                Dim query As String = "SELECT * FROM tb_rec_payment WHERE id_rec_payment='" & id_deposit & "'"
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
                    SLEPayRecTo.EditValue = data.Rows(0)("id_acc_pay_rec").ToString
                    '
                    SLEPayFrom.EditValue = data.Rows(0)("id_acc_pay_to").ToString
                    TENeedToPay.EditValue = data.Rows(0)("val_need_pay")
                    '
                    MENote.EditValue = data.Rows(0)("note").ToString
                End If
                '
                load_det()
                GridColumnReceive.OptionsColumn.AllowEdit = False
                GridColumnNote.OptionsColumn.AllowEdit = False
            End If
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub

    Private Sub GVList_CellValueChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles GVList.CellValueChanged
        If e.Column.FieldName.ToString = "value" Then
            'set value
            calculate_amount()
        End If
    End Sub

    Sub load_det()
        Dim query As String = "SELECT recd.id_rec_payment_det,recd.id_report,recd.report_mark_type,rmt.report_mark_type_name,recd.number,recd.total_rec,recd.`value`,recd.balance_due,recd.note 
FROM tb_rec_payment_det recd 
INNER JOIN tb_lookup_report_mark_type rmt ON rmt.`report_mark_type`=recd.report_mark_type
WHERE recd.id_rec_payment='" & id_deposit & "'"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCList.DataSource = data
        GVList.BestFitColumns()
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
    '
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
        Else
            LPayFrom.Visible = True
            LNeedToPay.Visible = True
            '
            SLEPayFrom.Visible = True
            TENeedToPay.Visible = True
            '
            TETotal.EditValue = 0.00
            TENeedToPay.EditValue = -gross_total
        End If
        '
        GVList.BestFitColumns()
    End Sub

    Sub load_store()
        Dim query As String = "SELECT cc.id_comp_contact,CONCAT(c.comp_number,' - ',c.comp_name) as comp_name 
                                FROM tb_m_comp c
                                INNER JOIN tb_m_comp_contact cc ON cc.`id_comp`=c.`id_comp` AND cc.`is_default`='1'"
        viewSearchLookupQuery(SLEStore, query, "id_comp_contact", "comp_name", "id_comp_contact")
    End Sub

    Private Sub FormBankDepositDet_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub BtnCancel_Click(sender As Object, e As EventArgs) Handles BtnCancel.Click
        Close()
    End Sub

    Private Sub BtnSave_Click(sender As Object, e As EventArgs) Handles BtnSave.Click
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
        If TETotal.EditValue = 0 And TENeedToPay.EditValue = 0 Then
            warningCustom("Please make sure amount is not 0")
        ElseIf value_exceed = True Then
            warningCustom("Please make sure amount credit note is not exceed 0, received amount not below 0, and not exceed balance due")
        Else
            If id_deposit = "-1" Then 'new
                'if there is need to pay
                Dim need_to_pay_amount As String = "0.00"
                Dim need_to_pay_account As String = "NULL"
                If TENeedToPay.EditValue > 0 Then
                    need_to_pay_amount = decimalSQL(TENeedToPay.EditValue.ToString)
                    need_to_pay_account = SLEPayFrom.EditValue.ToString
                End If
                query = "INSERT INTO tb_rec_payment(`id_acc_pay_rec`,`id_comp_contact`,`id_user_created`,`date_created`,`value`,`note`,`val_need_pay`,`id_acc_pay_to`,`id_report_status`)
VALUES ('" & SLEPayRecTo.EditValue.ToString & "','" & SLEStore.EditValue.ToString & "','" & id_user & "',NOW(),'" & decimalSQL(TETotal.EditValue.ToString) & "','" & addSlashes(MENote.Text) & "','" & need_to_pay_amount & "'," & need_to_pay_account & ",'1'); SELECT LAST_INSERT_ID();"
                id_deposit = execute_query(query, 0, True, "", "", "", "")
                'detail
                query = "INSERT INTO tb_rec_payment_det(`id_rec_payment`,`id_report`,`report_mark_type`,`number`,`total_rec`,`value`,`balance_due`,`note`) VALUES"
                For i As Integer = 0 To GVList.RowCount - 1
                    If Not i = 0 Then
                        query += ","
                    End If
                    query += "('" & id_deposit & "','" & GVList.GetRowCellValue(i, "id_report").ToString & "','" & GVList.GetRowCellValue(i, "report_mark_type").ToString & "','" & GVList.GetRowCellValue(i, "number").ToString & "','" & decimalSQL(GVList.GetRowCellValue(i, "total_rec").ToString) & "','" & decimalSQL(GVList.GetRowCellValue(i, "value").ToString) & "','" & decimalSQL(GVList.GetRowCellValue(i, "balance_due").ToString) & "','" & GVList.GetRowCellValue(i, "note").ToString & "')"
                Next
                execute_non_query(query, True, "", "", "", "")
                'generate number
                query = "CALL gen_number('" & id_deposit & "','162')"
                execute_non_query(query, True, "", "", "", "")
                'add journal + mark
                submit_who_prepared("162", id_deposit, id_user)
                'done
                infoCustom("Receive Payment created")
                FormBankDeposit.load_invoice()
                FormBankDeposit.SLEStoreDeposit.EditValue = SLEStore.EditValue
                FormBankDeposit.load_deposit()
                FormBankDeposit.GVList.FocusedRowHandle = find_row(FormBankDeposit.GVList, "id_rec_payment", id_deposit)
                FormBankDeposit.XTCPO.SelectedTabPageIndex = 0
                Close()
            End If
        End If
    End Sub
End Class