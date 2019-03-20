Public Class FormCashAdvanceDet
    Public id_ca As String = "-1"
    Public is_no_schedule As Boolean = False
    Public is_load As Boolean = False
    '
    Public is_view As String = "-1"

    Private Sub FormCashAdvanceDet_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub BCancel_Click(sender As Object, e As EventArgs) Handles BCancel.Click
        Close()
    End Sub

    Private Sub FormCashAdvanceDet_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        load_det()
    End Sub

    Sub load_det()
        TETotal.EditValue = 0.00
        load_type()
        load_pay_from()
        load_pay_to()
        load_dep()
        load_employee()
        load_report_status()

        DEDateCreated.EditValue = Now
        DEAdvanceEnd.EditValue = Now
        DEDueDate.EditValue = Now
        '
        TENumber.Text = "[auto generate]"
        '
        If id_ca = "-1" Then 'new
            BMark.Visible = False
            BPrint.Visible = False
        Else 'edit
            Dim query As String = "SELECT * FROM tb_cash_advance WHERE id_cash_advance='" & id_ca & "'"
            Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
            '
            TENumber.Text = data.Rows(0)("number").ToString
            DEDateCreated.EditValue = data.Rows(0)("date_created")
            DEAdvanceEnd.EditValue = data.Rows(0)("report_back_date")
            DEDueDate.EditValue = data.Rows(0)("report_back_due_date")
            '
            SLEType.EditValue = data.Rows(0)("id_cash_advance_type").ToString
            SLEPayFrom.EditValue = data.Rows(0)("id_acc_from").ToString
            SLEEmployee.EditValue = data.Rows(0)("id_employee").ToString
            SLEDepartement.EditValue = data.Rows(0)("id_departement").ToString
            SLEPayTo.EditValue = data.Rows(0)("id_acc_to").ToString
            TETotal.EditValue = data.Rows(0)("val_ca")
            '
            MENote.Text = data.Rows(0)("note").ToString
            LEReportStatus.EditValue = data.Rows(0)("id_report_status")
            '
            BSave.Visible = False
            '
            BMark.Visible = True
            BPrint.Visible = True
            '
            If LEReportStatus.EditValue.ToString = "6" Then
                BtnViewJournal.Visible = True
            End If

            '
            SLEType.Properties.ReadOnly = True
            DEAdvanceEnd.Properties.ReadOnly = True
            SLEPayFrom.Properties.ReadOnly = True
            SLEEmployee.Properties.ReadOnly = True
            SLEDepartement.Properties.ReadOnly = True
            SLEPayTo.Properties.ReadOnly = True
            TETotal.Enabled = False
            MENote.Properties.ReadOnly = True
        End If

        is_load = True

        If id_ca = "-1" Then
            calculate_report_day()
        End If
    End Sub


    Sub load_type()
        Dim query As String = "SELECT id_cash_advance_type,cash_advance_type,day_limit FROM tb_lookup_cash_advance_type"
        viewSearchLookupQuery(SLEType, query, "id_cash_advance_type", "cash_advance_type", "id_cash_advance_type")
    End Sub

    Sub load_pay_from()
        Dim query As String = "SELECT id_acc,acc_name,acc_description FROM `tb_a_acc` WHERE id_status='1' AND id_is_det='2'"
        viewSearchLookupQuery(SLEPayFrom, query, "id_acc", "acc_description", "id_acc")
    End Sub

    Sub load_pay_to()
        Dim query As String = "SELECT id_acc,acc_name,acc_description FROM `tb_a_acc` WHERE id_status='1' AND id_is_det='2'"
        viewSearchLookupQuery(SLEPayTo, query, "id_acc", "acc_description", "id_acc")
    End Sub

    Sub load_dep()
        Dim query As String = "SELECT id_departement,departement FROM tb_m_departement"
        viewSearchLookupQuery(SLEDepartement, query, "id_departement", "departement", "id_departement")
    End Sub

    Sub load_employee()
        Dim query As String = "SELECT id_employee,id_departement,employee_name FROM tb_m_employee"
        viewSearchLookupQuery(SLEEmployee, query, "id_employee", "employee_name", "id_employee")
    End Sub

    Sub load_report_status()
        Dim query As String = "SELECT id_report_status,report_status FROM tb_lookup_report_status"
        viewLookupQuery(LEReportStatus, query, 0, "report_status", "id_report_status")
    End Sub

    Private Sub SLEType_EditValueChanged(sender As Object, e As EventArgs) Handles SLEType.EditValueChanged
        calculate_report_day()
    End Sub

    Sub calculate_report_day()
        If is_load = True Then
            Try
                Dim date_start As String = Date.Parse(DEAdvanceEnd.EditValue.ToString).ToString("yyyy-MM-dd")
                Dim dayLimit As String = execute_query("SELECT day_limit FROM tb_lookup_cash_advance_type WHERE id_cash_advance_type = " + SLEType.EditValue.ToString, 0, True, "", "", "", "")
                Dim query As String = ""

                query = "SELECT ('" + date_start + "' + INTERVAL " + dayLimit + " DAY) AS date"
                'If SLEType.EditValue.ToString = "1" Then 'dinas H+3
                '    query = "CALL work_days(3,'" & date_start & "','" & SLEEmployee.EditValue.ToString & "')"
                'ElseIf SLEType.EditValue.ToString = "2" Then 'operation H+1
                '    query = "CALL work_days(1,'" & date_start & "','" & SLEEmployee.EditValue.ToString & "')"
                'End If

                Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
                If data.Rows.Count > 0 Then
                    DEDueDate.EditValue = Date.Parse(data.Rows(0)("date").ToString).ToString("dd MMMM yyyy")
                    is_no_schedule = False
                Else
                    warningCustom("Please register schedule for this employee first, contact HRD for further detail.")
                    is_no_schedule = True
                End If
                '
                Console.WriteLine(query)
            Catch ex As Exception
                Console.WriteLine(ex.ToString)
            End Try
        End If
    End Sub

    Private Sub DEAdvanceEnd_EditValueChanged(sender As Object, e As EventArgs) Handles DEAdvanceEnd.EditValueChanged
        calculate_report_day()
    End Sub

    Private Sub SLEEmployee_EditValueChanged(sender As Object, e As EventArgs) Handles SLEEmployee.EditValueChanged
        calculate_report_day()
        '
        Try
            If is_load = True Then
                SLEDepartement.EditValue = SLEEmployee.Properties.View.GetFocusedRowCellValue("id_departement")
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub BSave_Click(sender As Object, e As EventArgs) Handles BSave.Click
        calculate_report_day()

        If is_no_schedule = True Then
            'already warning
        ElseIf TETotal.EditValue <= 0 Then
            warningCustom("Please make sure amount is not zero")
        Else
            Dim query As String = "INSERT INTO `tb_cash_advance`(id_cash_advance_type,date_created,created_by,id_employee,report_back_date,report_back_due_date,id_departement,id_acc_from,id_acc_to,val_ca,note,id_report_status)
VALUES('" & SLEType.EditValue.ToString & "',NOW(),'" & id_user & "','" & SLEEmployee.EditValue.ToString & "','" & Date.Parse(DEAdvanceEnd.EditValue.ToString).ToString("yyyy-MM-dd") & "','" & Date.Parse(DEDueDate.EditValue.ToString).ToString("yyyy-MM-dd") & "','" & SLEDepartement.EditValue.ToString & "','" & SLEPayFrom.EditValue.ToString & "','" & SLEPayTo.EditValue.ToString & "','" & decimalSQL(TETotal.EditValue.ToString) & "','" & addSlashes(MENote.Text) & "',1); SELECT LAST_INSERT_ID();"
            id_ca = execute_query(query, 0, True, "", "", "", "")
            'generate number
            query = "CALL gen_number('" & id_ca & "','167')"
            execute_non_query(query, True, "", "", "", "")
            'add mark
            submit_who_prepared("167", id_ca, id_user)
            'done
            infoCustom("Cash Advance created")

            FormCashAdvance.SLEType.EditValue = SLEType.EditValue
            FormCashAdvance.SLEDepartement.EditValue = SLEDepartement.EditValue
            FormCashAdvance.load_employee()
            FormCashAdvance.SLEEmployee.EditValue = SLEEmployee.EditValue
            FormCashAdvance.load_cash_advance()

            FormCashAdvance.GVListOpen.FocusedRowHandle = find_row(FormCashAdvance.GVListOpen, "id_cash_advance", id_ca)
            FormCashAdvance.XTCPO.SelectedTabPageIndex = 0

            Close()
        End If
    End Sub

    Private Sub BMark_Click(sender As Object, e As EventArgs) Handles BMark.Click
        FormReportMark.report_mark_type = "167"
        FormReportMark.is_view = is_view
        FormReportMark.id_report = id_ca
        FormReportMark.ShowDialog()
    End Sub

    Private Sub BPrint_Click(sender As Object, e As EventArgs) Handles BPrint.Click
        Cursor = Cursors.WaitCursor
        ReportCashAdvance.id_ca = id_ca
        Dim Report As New ReportCashAdvance()
        'Parse val
        Report.LNumber.Text = TENumber.Text
        Report.LDateCreated.Text = Date.Parse(DEDateCreated.EditValue.ToString).ToString("dd MMMM yyyy")
        Report.LReqBy.Text = SLEEmployee.Text
        Report.LDepartement.Text = SLEDepartement.Text
        Report.LReportBackDate.Text = Date.Parse(DEAdvanceEnd.EditValue.ToString).ToString("dd MMMM yyyy")
        Report.LReportBackDueDate.Text = Date.Parse(DEDueDate.EditValue.ToString).ToString("dd MMMM yyyy")
        Report.LTotalAmount.Text = "Rp. " & TETotal.Text
        Report.LNote.Text = MENote.Text

        If LEReportStatus.EditValue.ToString = "6" Then
            Report.id_pre = "-1"
        Else
            Report.id_pre = "1"
        End If

        'Show the report's preview. 
        Dim Tool As DevExpress.XtraReports.UI.ReportPrintTool = New DevExpress.XtraReports.UI.ReportPrintTool(Report)
        Tool.ShowPreview()
        Cursor = Cursors.Default
    End Sub

    Private Sub BtnViewJournal_Click(sender As Object, e As EventArgs) Handles BtnViewJournal.Click
        Cursor = Cursors.WaitCursor
        Dim id_acc_trans As String = ""
        Try
            id_acc_trans = execute_query("SELECT ad.id_acc_trans FROM tb_a_acc_trans_det ad
            WHERE ad.report_mark_type=167 AND ad.id_report=" + id_ca + "
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
End Class