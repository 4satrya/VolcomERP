Public Class FormBankWithdrawalDet
    Public report_mark_type As String = "-1"
    Public id_pay_type As String = "-1"
    Public id_payment As String = "-1"
    '
    Public is_view As String = "-1"
    '
    Private Sub FormBankWithdrawalDet_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Sub form_load()
        TETotal.EditValue = 0.00
        DEDateCreated.EditValue = Now
        TEPayNumber.Text = "[Auto generate]"

        load_pay_from()
        load_vendor()
        load_trans_type()
        load_report_type()
        '
        If id_payment = "-1" Then
            load_det()
            BtnPrint.Visible = False
            BMark.Visible = False
            BtnSave.Visible = True
            'check account
            Dim query_check As String = "SELECT IFNULL(id_acc_dp,0) AS id_acc_dp,IFNULL(id_acc_ap,0) AS id_acc_ap FROM tb_m_comp c
INNER JOIN tb_m_comp_contact cc ON cc.id_comp = c.id_comp
WHERE cc.id_comp_contact='" & FormBankWithdrawal.SLEVendor.EditValue & "'"
            Dim data_check As DataTable = execute_query(query_check, -1, True, "", "", "", "")
            If data_check.Rows(0)("id_acc_dp").ToString = "0" And id_pay_type = "1" Then
                warningCustom("This vendor DP account is not set.")
                Close()
            ElseIf data_check.Rows(0)("id_acc_ap").ToString = "0" And id_pay_type = "2" Then
                warningCustom("This vendor AP account is not set.")
                Close()
            End If
            '
            If report_mark_type = "139" Then 'purchasing
                'load header
                SLEVendor.EditValue = FormBankWithdrawal.SLEVendor.EditValue
                SLEPayType.EditValue = id_pay_type
                '
                If id_pay_type = "2" Then 'Payment
                    GridColumnPayment.OptionsColumn.AllowEdit = False
                Else
                    GridColumnPayment.OptionsColumn.AllowEdit = True
                End If
                '
                SLEReportType.EditValue = report_mark_type
                'load detail
                For i As Integer = 0 To FormBankWithdrawal.GVPOList.RowCount - 1
                    'id_report,number,total,balance due
                    Dim newRow As DataRow = (TryCast(GCList.DataSource, DataTable)).NewRow()
                    newRow("id_report") = FormBankWithdrawal.GVPOList.GetRowCellValue(i, "id_purc_order").ToString
                    newRow("number") = FormBankWithdrawal.GVPOList.GetRowCellValue(i, "purc_order_number").ToString
                    newRow("total_dp") = FormBankWithdrawal.GVPOList.GetRowCellValue(i, "total_dp").ToString
                    newRow("value") = FormBankWithdrawal.GVPOList.GetRowCellValue(i, "total_due").ToString
                    newRow("balance_due") = FormBankWithdrawal.GVPOList.GetRowCellValue(i, "total_due").ToString
                    newRow("note") = ""
                    TryCast(GCList.DataSource, DataTable).Rows.Add(newRow)
                Next
                '
                calculate_amount()
            ElseIf report_mark_type = "157" Then 'expense
                'load header
                Dim id_comp As String = FormBankWithdrawal.SLEVendorExpense.EditValue
                Dim id_comp_contact As String = get_company_x(id_comp, 6)
                SLEVendor.EditValue = id_comp_contact
                SLEPayType.EditValue = id_pay_type
                SLEReportType.EditValue = report_mark_type

                If id_pay_type = "2" Then 'Payment
                    GridColumnPayment.OptionsColumn.AllowEdit = False
                Else
                    GridColumnPayment.OptionsColumn.AllowEdit = True
                End If

                'load detail
                For i As Integer = 0 To FormBankWithdrawal.GVExpense.RowCount - 1
                    'id_report,number,total,balance due
                    Dim newRow As DataRow = (TryCast(GCList.DataSource, DataTable)).NewRow()
                    newRow("id_report") = FormBankWithdrawal.GVExpense.GetRowCellValue(i, "id_item_expense").ToString
                    newRow("number") = FormBankWithdrawal.GVExpense.GetRowCellValue(i, "number").ToString
                    newRow("total_dp") = FormBankWithdrawal.GVExpense.GetRowCellValue(i, "total_dp")
                    newRow("value") = FormBankWithdrawal.GVExpense.GetRowCellValue(i, "balance")
                    newRow("balance_due") = FormBankWithdrawal.GVExpense.GetRowCellValue(i, "balance")
                    newRow("note") = ""
                    TryCast(GCList.DataSource, DataTable).Rows.Add(newRow)
                Next
                calculate_amount()
            End If
        Else
            BtnPrint.Visible = True
            BMark.Visible = True
            BtnSave.Visible = False
            SLEPayFrom.Enabled = False
            MENote.Enabled = False
            '
            Dim query As String = "SELECT * FROM tb_payment WHERE id_payment='" & id_payment & "'"
            Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
            If data.Rows.Count > 0 Then
                TEPayNumber.Text = data.Rows(0)("number").ToString
                report_mark_type = data.Rows(0)("report_mark_type").ToString
                SLEVendor.EditValue = data.Rows(0)("id_comp_contact").ToString
                SLEPayType.EditValue = data.Rows(0)("id_pay_type").ToString
                SLEReportType.EditValue = data.Rows(0)("report_mark_type").ToString
                '
                If data.Rows(0)("id_report_status").ToString = "6" Then
                    BtnViewJournal.Visible = True
                Else
                    BtnViewJournal.Visible = False
                End If
                '
                DEDateCreated.EditValue = data.Rows(0)("date_created")
                SLEPayFrom.EditValue = data.Rows(0)("id_acc_payfrom").ToString
                MENote.EditValue = data.Rows(0)("note").ToString
            End If
            '
            load_det()
            GridColumnPayment.OptionsColumn.AllowEdit = False
            GridColumnNote.OptionsColumn.AllowEdit = False
        End If
    End Sub

    Private Sub FormBankWithdrawalDet_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        form_load()
    End Sub

    Sub load_det()
        Dim query As String = ""
        If report_mark_type = "139" Then
            query = "SELECT pyd.*,po.purc_order_number as number FROM tb_payment_det pyd INNER JOIN tb_purc_order po ON po.id_purc_order=pyd.id_report WHERE pyd.id_payment='" & id_payment & "'"
        ElseIf report_mark_type = "157" Then
            query = "SELECT pyd.*,e.number AS `number` FROM tb_payment_det pyd INNER JOIN tb_item_expense e ON e.id_item_expense=pyd.id_report WHERE pyd.id_payment='" + id_payment + "'"
        End If
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCList.DataSource = data
        calculate_amount()
    End Sub

    Sub load_vendor()
        Dim query As String = "SELECT cc.id_comp_contact,CONCAT(c.comp_number,' - ',c.comp_name) as comp_name 
                                FROM tb_m_comp c
                                INNER JOIN tb_m_comp_contact cc ON cc.`id_comp`=c.`id_comp` AND cc.`is_default`='1'"
        viewSearchLookupQuery(SLEVendor, query, "id_comp_contact", "comp_name", "id_comp_contact")
    End Sub

    Sub load_pay_from()
        Dim query As String = "SELECT id_acc,acc_name,acc_description FROM `tb_a_acc` WHERE id_status='1' AND id_is_det='2'"
        viewSearchLookupQuery(SLEPayFrom, query, "id_acc", "acc_description", "id_acc")
    End Sub

    Sub load_trans_type()
        Dim query As String = "SELECT id_pay_type,pay_type FROM tb_lookup_pay_type"
        viewSearchLookupQuery(SLEPayType, query, "id_pay_type", "pay_type", "id_pay_type")
    End Sub

    Sub load_report_type()
        Dim query As String = "SELECT report_mark_type,report_mark_type_name FROM `tb_lookup_report_mark_type` WHERE is_payable='1'"
        viewSearchLookupQuery(SLEReportType, query, "report_mark_type", "report_mark_type_name", "report_mark_type")
    End Sub

    Private Sub BtnPrint_Click(sender As Object, e As EventArgs) Handles BtnPrint.Click
        Cursor = Cursors.WaitCursor
        ReportBankWithdrawal.id_withdrawal = id_payment
        ReportBankWithdrawal.dt = GCList.DataSource
        Dim Report As New ReportBankWithdrawal()
        ' '... 
        ' ' creating and saving the view's layout to a new memory stream 
        Dim str As System.IO.Stream
        str = New System.IO.MemoryStream()
        GVList.SaveLayoutToStream(str, DevExpress.Utils.OptionsLayoutBase.FullLayout)
        str.Seek(0, System.IO.SeekOrigin.Begin)
        Report.GVList.RestoreLayoutFromStream(str, DevExpress.Utils.OptionsLayoutBase.FullLayout)
        str.Seek(0, System.IO.SeekOrigin.Begin)

        'Grid Detail
        ReportStyleGridview(Report.GVList)

        'Parse val
        Dim query As String = "SELECT py.number,acc.acc_description as acc_payfrom,py.`id_report_status`,sts.report_status,emp.employee_name AS created_by, DATE_FORMAT(py.date_created,'%d %M %Y') as date_created, py.`id_payment`,FORMAT(py.`value`,2,'id_ID') as total_amount,CONCAT(c.`comp_number`,' - ',c.`comp_name`) AS comp_name,rm.`report_mark_type_name`,pt.`pay_type`,py.note
FROM tb_payment py
INNER JOIN tb_m_comp_contact cc ON cc.`id_comp_contact`=py.`id_comp_contact`
INNER JOIN tb_m_comp c ON c.`id_comp`=cc.`id_comp`
INNER JOIN `tb_lookup_report_mark_type` rm ON rm.`report_mark_type`=py.`report_mark_type`
INNER JOIN `tb_lookup_pay_type` pt ON pt.`id_pay_type`=py.`id_pay_type`
INNER JOIN tb_m_user usr ON usr.id_user=py.id_user_created
INNER JOIN tb_m_employee emp ON emp.id_employee=usr.id_employee
INNER JOIN tb_lookup_report_status sts ON sts.id_report_status=py.id_report_status
INNER JOIN tb_a_acc acc ON acc.id_acc=py.id_acc_payfrom
WHERE py.`id_payment`='" & id_payment & "'"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        Report.DataSource = data

        If Not data.Rows(0)("id_report_status").ToString = "6" Then
            Report.id_pre = "2"
        Else
            Report.id_pre = "1"
        End If

        'Show the report's preview. 
        Dim Tool As DevExpress.XtraReports.UI.ReportPrintTool = New DevExpress.XtraReports.UI.ReportPrintTool(Report)
        Tool.ShowPreview()
        Cursor = Cursors.Default
    End Sub

    Private Sub BtnCancel_Click(sender As Object, e As EventArgs) Handles BtnCancel.Click
        Close()
    End Sub

    Sub calculate_amount()
        GVList.RefreshData()
        Dim gross_total As Double = 0.0
        Try
            gross_total = Double.Parse(GVList.Columns("value").SummaryItem.SummaryValue.ToString)
        Catch ex As Exception
        End Try

        TETotal.EditValue = gross_total
        '
        GVList.BestFitColumns()
    End Sub

    Private Sub GVList_CellValueChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles GVList.CellValueChanged
        If e.Column.FieldName.ToString = "value" Then
            'set value
            calculate_amount()
        End If
    End Sub

    Private Sub BtnSave_Click(sender As Object, e As EventArgs) Handles BtnSave.Click
        If id_payment = "-1" Then
            If report_mark_type = "139" Then 'purchasing
                'cek dp 0
                Dim dp_is_zero As Boolean = False
                If id_pay_type = "1" Then 'dp
                    For i As Integer = 0 To GVList.RowCount - 1
                        If GVList.GetRowCellValue(i, "value") = 0 Then
                            dp_is_zero = True
                        End If
                    Next
                End If
                'cek paid no exceed balance
                Dim paid_more As Boolean = False
                For i As Integer = 0 To GVList.RowCount - 1
                    If GVList.GetRowCellValue(i, "value") > GVList.GetRowCellValue(i, "balance_due") Then
                        paid_more = True
                    End If
                Next
                '
                If GVList.RowCount = 0 Then
                    warningCustom("No item listed.")
                ElseIf dp_is_zero = True Then
                    warningCustom("You must fill dp value.")
                ElseIf paid_more = True Then
                    warningCustom("You pay more than balance.")
                Else
                    'header
                    Dim query As String = "INSERT INTO tb_payment(report_mark_type,id_acc_payfrom,id_comp_contact,id_pay_type,id_user_created,date_created,value,note,id_report_status) 
VALUES('139','" & SLEPayFrom.EditValue.ToString & "','" & SLEVendor.EditValue.ToString & "','" & SLEPayType.EditValue.ToString & "','" & id_user & "',NOW(),'" & decimalSQL(TETotal.EditValue.ToString) & "','" & addSlashes(MENote.Text) & "','1'); SELECT LAST_INSERT_ID(); "
                    id_payment = execute_query(query, 0, True, "", "", "", "")
                    'detail
                    query = "INSERT INTO tb_payment_det(id_payment,id_report,number,total_dp,value,balance_due,note) VALUES"
                    For i As Integer = 0 To GVList.RowCount - 1
                        If Not i = 0 Then
                            query += ","
                        End If
                        query += "('" & id_payment & "','" & GVList.GetRowCellValue(i, "id_report").ToString & "','" & GVList.GetRowCellValue(i, "number").ToString & "','" & decimalSQL(GVList.GetRowCellValue(i, "total_dp").ToString) & "','" & decimalSQL(GVList.GetRowCellValue(i, "value").ToString) & "','" & decimalSQL(GVList.GetRowCellValue(i, "balance_due").ToString) & "','" & addSlashes(GVList.GetRowCellValue(i, "note").ToString) & "')"
                    Next
                    execute_non_query(query, True, "", "", "", "")
                    'generate number
                    query = "CALL gen_number('" & id_payment & "','159')"
                    execute_non_query(query, True, "", "", "", "")
                    'add journal + mark
                    submit_who_prepared("159", id_payment, id_user)

                    'done
                    infoCustom("Payment created")
                    FormBankWithdrawal.load_po()
                    FormBankWithdrawal.load_payment()
                    FormBankWithdrawal.GVList.FocusedRowHandle = find_row(FormBankWithdrawal.GVList, "id_payment", id_payment)
                    FormBankWithdrawal.XTCPO.SelectedTabPageIndex = 0
                    Close()
                End If
            ElseIf report_mark_type = "157" Then
                'cek dp 0
                Dim dp_is_zero As Boolean = False
                If id_pay_type = "1" Then 'dp
                    For i As Integer = 0 To GVList.RowCount - 1
                        If GVList.GetRowCellValue(i, "value") = 0 Then
                            dp_is_zero = True
                        End If
                    Next
                End If
                'cek paid no exceed balance
                Dim paid_more As Boolean = False
                For i As Integer = 0 To GVList.RowCount - 1
                    If GVList.GetRowCellValue(i, "value") > GVList.GetRowCellValue(i, "balance_due") Then
                        paid_more = True
                    End If
                Next
                '
                If GVList.RowCount = 0 Then
                    warningCustom("No item listed.")
                ElseIf dp_is_zero = True Then
                    warningCustom("You must fill dp value.")
                ElseIf paid_more = True Then
                    warningCustom("You pay more than balance.")
                Else
                    'header
                    Dim query As String = "INSERT INTO tb_payment(report_mark_type,id_acc_payfrom,id_comp_contact,id_pay_type,id_user_created,date_created,value,note,id_report_status) 
VALUES('157','" & SLEPayFrom.EditValue.ToString & "','" & SLEVendor.EditValue.ToString & "','" & SLEPayType.EditValue.ToString & "','" & id_user & "',NOW(),'" & decimalSQL(TETotal.EditValue.ToString) & "','" & addSlashes(MENote.Text) & "','1'); SELECT LAST_INSERT_ID(); "
                    id_payment = execute_query(query, 0, True, "", "", "", "")
                    'detail
                    query = "INSERT INTO tb_payment_det(id_payment,id_report,number,total_dp,value,balance_due,note) VALUES"
                    For i As Integer = 0 To GVList.RowCount - 1
                        If Not i = 0 Then
                            query += ","
                        End If
                        query += "('" & id_payment & "','" & GVList.GetRowCellValue(i, "id_report").ToString & "','" & GVList.GetRowCellValue(i, "number").ToString & "','" & decimalSQL(GVList.GetRowCellValue(i, "total_dp").ToString) & "','" & decimalSQL(GVList.GetRowCellValue(i, "value").ToString) & "','" & decimalSQL(GVList.GetRowCellValue(i, "balance_due").ToString) & "','" & addSlashes(GVList.GetRowCellValue(i, "note").ToString) & "')"
                    Next
                    execute_non_query(query, True, "", "", "", "")
                    'generate number
                    query = "CALL gen_number('" & id_payment & "','159')"
                    execute_non_query(query, True, "", "", "", "")
                    'add journal + mark
                    submit_who_prepared("159", id_payment, id_user)

                    'done
                    infoCustom("Payment created")
                    FormBankWithdrawal.load_expense()
                    FormBankWithdrawal.load_payment()
                    FormBankWithdrawal.GVList.FocusedRowHandle = find_row(FormBankWithdrawal.GVList, "id_payment", id_payment)
                    FormBankWithdrawal.XTCPO.SelectedTabPageIndex = 0
                    Close()
                End If
            End If
        End If
    End Sub

    Private Sub BtnViewJournal_Click(sender As Object, e As EventArgs) Handles BtnViewJournal.Click
        Cursor = Cursors.WaitCursor
        Dim id_acc_trans As String = ""
        Try
            id_acc_trans = execute_query("SELECT ad.id_acc_trans FROM tb_a_acc_trans_det ad
            WHERE ad.report_mark_type=159 AND ad.id_report=" + id_payment + "
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

    Private Sub BMark_Click(sender As Object, e As EventArgs) Handles BMark.Click
        FormReportMark.report_mark_type = "159"
        FormReportMark.is_view = is_view
        FormReportMark.id_report = id_payment
        FormReportMark.ShowDialog()
    End Sub
End Class