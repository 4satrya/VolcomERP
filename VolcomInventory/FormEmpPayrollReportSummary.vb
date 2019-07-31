Public Class FormEmpPayrollReportSummary
    Public id_payroll As String = ""

    Private Sub FormEmpPayrollReportSummary_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        id_payroll = FormEmpPayroll.GVPayrollPeriode.GetFocusedRowCellValue("id_payroll").ToString

        load_sum()

        'number
        For i = 0 To GVSummary.RowCount - 1
            If GVSummary.IsValidRowHandle(i) Then
                GVSummary.SetRowCellValue(i, "no", i + 1)

                If GVSummary.GetRowCellValue(i, "id_departement").ToString = "17" Then
                    Exit For
                End If
            End If
        Next

        'controls
        Dim id_report_status As String = execute_query("SELECT id_report_status FROM tb_emp_payroll WHERE id_payroll = '" + id_payroll + "'", 0, True, "", "", "", "")

        If id_report_status = "0" Then
            SBPrint.Enabled = False
        Else
            SBPrint.Enabled = True
        End If
    End Sub

    Sub load_sum()
        Dim query As String = "CALL view_payroll_sum('" & id_payroll & "')"

        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")

        GCSummary.DataSource = data

        'separate sogo
        Dim index As Integer = 0

        Dim salary As Decimal = 0
        Dim event_overtime As Decimal = 0
        Dim d_cooperative_loan As Decimal = 0
        Dim d_bpjskes As Decimal = 0
        Dim d_jaminan_pensiun As Decimal = 0
        Dim d_bpjstk As Decimal = 0
        Dim d_cooperative_contributtion As Decimal = 0
        Dim d_missing As Decimal = 0
        Dim d_meditation_cash As Decimal = 0
        Dim d_other As Decimal = 0
        Dim total_cash As Decimal = 0

        For i = 0 To data.Rows.Count - 1
            If data.Rows(i)("departement").ToString().Contains("SOGO") Then
                If index = 0 Then
                    index = i
                End If

                data.Rows(i)("departement") = "     " + data.Rows(i)("departement_sub").ToString()

                salary += data.Rows(i)("salary")
                event_overtime += data.Rows(i)("event_overtime")
                d_cooperative_loan += data.Rows(i)("d_cooperative_loan")
                d_bpjskes += data.Rows(i)("d_bpjskes")
                d_jaminan_pensiun += data.Rows(i)("d_jaminan_pensiun")
                d_bpjstk += data.Rows(i)("d_bpjstk")
                d_cooperative_contributtion += data.Rows(i)("d_cooperative_contribution")
                d_missing += data.Rows(i)("d_missing")
                d_meditation_cash += data.Rows(i)("d_meditation_cash")
                d_other += data.Rows(i)("d_other")
                total_cash += data.Rows(i)("total_cash")
            End If
        Next

        If Not index = 0 Then
            Dim row As DataRow = data.NewRow()

            row("group_report") = "STORE"
            row("is_office_payroll") = 2
            row("no") = 0
            row("id_departement") = 17
            row("departement") = "VOLCOM SOGO"
            row("departement_sub") = "VOLCOM SOGO"
            row("salary") = salary
            row("event_overtime") = event_overtime
            row("d_cooperative_loan") = d_cooperative_loan
            row("d_bpjskes") = d_bpjskes
            row("d_jaminan_pensiun") = d_jaminan_pensiun
            row("d_bpjstk") = d_bpjstk
            row("d_cooperative_contribution") = d_cooperative_contributtion
            row("d_missing") = d_missing
            row("d_meditation_cash") = d_meditation_cash
            row("d_other") = d_other
            row("total_cash") = total_cash

            data.Rows.InsertAt(row, index)
        End If

        GVSummary.BestFitColumns()
    End Sub

    Private Sub FormEmpPayrollReportSummary_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub SBPrint_Click(sender As Object, e As EventArgs) Handles SBPrint.Click
        Dim data As DataTable = GCSummary.DataSource

        Dim id_report_status As String = execute_query("SELECT id_report_status FROM tb_emp_payroll WHERE id_payroll = " + FormEmpPayroll.GVPayrollPeriode.GetFocusedRowCellValue("id_payroll").ToString, 0, True, "", "", "", "")

        Dim already_office As Boolean = False
        Dim already_store As Boolean = False

        For j = 0 To data.Rows.Count - 1
            If data.Rows(j)("is_office_payroll").ToString = "1" Then
                already_office = True
            ElseIf data.Rows(j)("is_office_payroll").ToString = "2"
                already_store = True
            End If
        Next

        Dim no As Integer = 0

        'office
        Dim data_payroll_1 As DataTable = data.Clone

        no = 0

        For j = 0 To data.Rows.Count - 1
            If data.Rows(j)("is_office_payroll").ToString = "1" Then
                data_payroll_1.ImportRow(data.Rows(j))

                data_payroll_1.Rows(no)("no") = no + 1

                no += 1
            End If
        Next

        'store
        Dim data_payroll_2 As DataTable = data.Clone

        no = 0

        For j = 0 To data.Rows.Count - 1
            If data.Rows(j)("is_office_payroll").ToString = "2" Then
                data_payroll_2.ImportRow(data.Rows(j))
            End If
        Next

        For i = 0 To data_payroll_2.Rows.Count - 1
            data_payroll_2.Rows(no)("no") = no + 1

            no += 1

            If data_payroll_2.Rows(i)("id_departement").ToString = "17" Then
                Exit For
            End If
        Next

        Dim report As ReportEmpPayrollReportAllDepartement = New ReportEmpPayrollReportAllDepartement

        report.id_payroll = FormEmpPayroll.GVPayrollPeriode.GetFocusedRowCellValue("id_payroll").ToString
        report.data = total_all(data)
        report.data_office = data_payroll_1
        report.data_store = data_payroll_2
        report.id_pre = If(id_report_status = "6", "-1", "1")
        report.type = FormEmpPayroll.GVPayrollPeriode.GetFocusedRowCellValue("id_payroll_type").ToString

        report.XLPeriod.Text = Date.Parse(FormEmpPayroll.GVPayrollPeriode.GetFocusedRowCellValue("periode_end").ToString).ToString("MMMM yyyy")
        report.XLType.Text = FormEmpPayroll.GVPayrollPeriode.GetFocusedRowCellValue("payroll_type_name").ToString

        Dim tool As DevExpress.XtraReports.UI.ReportPrintTool = New DevExpress.XtraReports.UI.ReportPrintTool(report)

        tool.ShowPreview()
    End Sub

    Function total_all(data_ori As DataTable) As DataTable
        Dim data As DataTable = New DataTable

        data.Columns.Add("information", GetType(String))
        data.Columns.Add("volcom_indonesia", GetType(Decimal))
        data.Columns.Add("bemo_corner", GetType(Decimal))
        data.Columns.Add("kuta_square", GetType(Decimal))
        data.Columns.Add("seminyak", GetType(Decimal))

        data.Rows.Add("TRANSFER BCA EFEKTIF " + Date.Parse(FormEmpPayroll.GVPayrollPeriode.GetFocusedRowCellValue("eff_trans_date").ToString).ToString("dd MMMM yyyy").ToUpper, 0, 0, 0, 0)
        data.Rows.Add("CASH EFEKTIF " + Date.Parse(FormEmpPayroll.GVPayrollPeriode.GetFocusedRowCellValue("eff_trans_date").ToString).ToString("dd MMMM yyyy").ToUpper, 0, 0, 0, 0)
        data.Rows.Add("Cooperative ", 0, 0, 0, 0)

        Dim transfer As Decimal = 0.00
        Dim cash As Decimal = 0.00
        Dim cooperative As Decimal = 0.00

        For i = 0 To data_ori.Rows.Count - 1
            If Not data_ori.Rows(i)("no").ToString = "" Then
                transfer = data_ori.Rows(i)("salary") + data_ori.Rows(i)("event_overtime") - data_ori.Rows(i)("d_cooperative_loan") - data_ori.Rows(i)("d_bpjskes") - data_ori.Rows(i)("d_jaminan_pensiun") - data_ori.Rows(i)("d_bpjstk") - data_ori.Rows(i)("d_cooperative_contribution") - data_ori.Rows(i)("d_missing") - data_ori.Rows(i)("d_meditation_cash") - data_ori.Rows(i)("d_other") - data_ori.Rows(i)("total_cash")
                cash = data_ori.Rows(i)("total_cash")
                cooperative = data_ori.Rows(i)("d_cooperative_contribution") + data_ori.Rows(i)("d_cooperative_loan")

                If data_ori.Rows(i)("id_departement").ToString = "16" Then
                    'bemo corner
                    data.Rows(0)("bemo_corner") += transfer
                    data.Rows(1)("bemo_corner") += cash
                    data.Rows(2)("bemo_corner") += cooperative
                ElseIf data_ori.Rows(i)("id_departement").ToString = "15" Then
                    'kuta square
                    data.Rows(0)("kuta_square") += transfer
                    data.Rows(1)("kuta_square") += cash
                    data.Rows(2)("kuta_square") += cooperative
                ElseIf data_ori.Rows(i)("id_departement").ToString = "23" Then
                    'seminyak
                    data.Rows(0)("seminyak") += transfer
                    data.Rows(1)("seminyak") += cash
                    data.Rows(2)("seminyak") += cooperative
                Else
                    data.Rows(0)("volcom_indonesia") += transfer
                    data.Rows(1)("volcom_indonesia") += cash
                    data.Rows(2)("volcom_indonesia") += cooperative
                End If
            End If
        Next

        Return data
    End Function

    Dim tot_salary As Decimal = 0
    Dim tot_event_overtime As Decimal = 0
    Dim tot_d_cooperative_loan As Decimal = 0
    Dim tot_d_bpjskes As Decimal = 0
    Dim tot_d_jaminan_pensiun As Decimal = 0
    Dim tot_d_bpjstk As Decimal = 0
    Dim tot_d_cooperative_contributtion As Decimal = 0
    Dim tot_d_missing As Decimal = 0
    Dim tot_d_meditation_cash As Decimal = 0
    Dim tot_d_other As Decimal = 0
    Dim tot_total_cash As Decimal = 0
    Dim tot_balance As Decimal = 0

    Private Sub GVSummary_CustomSummaryCalculate(sender As Object, e As DevExpress.Data.CustomSummaryEventArgs) Handles GVSummary.CustomSummaryCalculate
        Dim item As DevExpress.XtraGrid.GridSummaryItem = TryCast(e.Item, DevExpress.XtraGrid.GridSummaryItem)

        If item.FieldName.ToString = "salary" Then
            Select Case e.SummaryProcess
                Case DevExpress.Data.CustomSummaryProcess.Start
                    tot_salary = 0
                Case DevExpress.Data.CustomSummaryProcess.Calculate
                    If Not GVSummary.GetRowCellValue(e.RowHandle, "no").ToString = "" Then
                        tot_salary += e.FieldValue
                    End If
                Case DevExpress.Data.CustomSummaryProcess.Finalize
                    e.TotalValue = Format(tot_salary, "##,##0")
            End Select
        End If

        If item.FieldName.ToString = "event_overtime" Then
            Select Case e.SummaryProcess
                Case DevExpress.Data.CustomSummaryProcess.Start
                    tot_event_overtime = 0
                Case DevExpress.Data.CustomSummaryProcess.Calculate
                    If Not GVSummary.GetRowCellValue(e.RowHandle, "no").ToString = "" Then
                        tot_event_overtime += e.FieldValue
                    End If
                Case DevExpress.Data.CustomSummaryProcess.Finalize
                    e.TotalValue = Format(tot_event_overtime, "##,##0")
            End Select
        End If

        If item.FieldName.ToString = "d_cooperative_loan" Then
            Select Case e.SummaryProcess
                Case DevExpress.Data.CustomSummaryProcess.Start
                    tot_d_cooperative_loan = 0
                Case DevExpress.Data.CustomSummaryProcess.Calculate
                    If Not GVSummary.GetRowCellValue(e.RowHandle, "no").ToString = "" Then
                        tot_d_cooperative_loan += e.FieldValue
                    End If
                Case DevExpress.Data.CustomSummaryProcess.Finalize
                    e.TotalValue = Format(tot_d_cooperative_loan, "##,##0")
            End Select
        End If

        If item.FieldName.ToString = "d_bpjskes" Then
            Select Case e.SummaryProcess
                Case DevExpress.Data.CustomSummaryProcess.Start
                    tot_d_bpjskes = 0
                Case DevExpress.Data.CustomSummaryProcess.Calculate
                    If Not GVSummary.GetRowCellValue(e.RowHandle, "no").ToString = "" Then
                        tot_d_bpjskes += e.FieldValue
                    End If
                Case DevExpress.Data.CustomSummaryProcess.Finalize
                    e.TotalValue = Format(tot_d_bpjskes, "##,##0")
            End Select
        End If

        If item.FieldName.ToString = "d_jaminan_pensiun" Then
            Select Case e.SummaryProcess
                Case DevExpress.Data.CustomSummaryProcess.Start
                    tot_d_jaminan_pensiun = 0
                Case DevExpress.Data.CustomSummaryProcess.Calculate
                    If Not GVSummary.GetRowCellValue(e.RowHandle, "no").ToString = "" Then
                        tot_d_jaminan_pensiun += e.FieldValue
                    End If
                Case DevExpress.Data.CustomSummaryProcess.Finalize
                    e.TotalValue = Format(tot_d_jaminan_pensiun, "##,##0")
            End Select
        End If

        If item.FieldName.ToString = "d_bpjstk" Then
            Select Case e.SummaryProcess
                Case DevExpress.Data.CustomSummaryProcess.Start
                    tot_d_bpjstk = 0
                Case DevExpress.Data.CustomSummaryProcess.Calculate
                    If Not GVSummary.GetRowCellValue(e.RowHandle, "no").ToString = "" Then
                        tot_d_bpjstk += e.FieldValue
                    End If
                Case DevExpress.Data.CustomSummaryProcess.Finalize
                    e.TotalValue = Format(tot_d_bpjstk, "##,##0")
            End Select
        End If

        If item.FieldName.ToString = "d_cooperative_contribution" Then
            Select Case e.SummaryProcess
                Case DevExpress.Data.CustomSummaryProcess.Start
                    tot_d_cooperative_contributtion = 0
                Case DevExpress.Data.CustomSummaryProcess.Calculate
                    If Not GVSummary.GetRowCellValue(e.RowHandle, "no").ToString = "" Then
                        tot_d_cooperative_contributtion += e.FieldValue
                    End If
                Case DevExpress.Data.CustomSummaryProcess.Finalize
                    e.TotalValue = Format(tot_d_cooperative_contributtion, "##,##0")
            End Select
        End If

        If item.FieldName.ToString = "d_missing" Then
            Select Case e.SummaryProcess
                Case DevExpress.Data.CustomSummaryProcess.Start
                    tot_d_missing = 0
                Case DevExpress.Data.CustomSummaryProcess.Calculate
                    If Not GVSummary.GetRowCellValue(e.RowHandle, "no").ToString = "" Then
                        tot_d_missing += e.FieldValue
                    End If
                Case DevExpress.Data.CustomSummaryProcess.Finalize
                    e.TotalValue = Format(tot_d_missing, "##,##0")
            End Select
        End If

        If item.FieldName.ToString = "d_meditation_cash" Then
            Select Case e.SummaryProcess
                Case DevExpress.Data.CustomSummaryProcess.Start
                    tot_d_meditation_cash = 0
                Case DevExpress.Data.CustomSummaryProcess.Calculate
                    If Not GVSummary.GetRowCellValue(e.RowHandle, "no").ToString = "" Then
                        tot_d_meditation_cash += e.FieldValue
                    End If
                Case DevExpress.Data.CustomSummaryProcess.Finalize
                    e.TotalValue = Format(tot_d_meditation_cash, "##,##0")
            End Select
        End If

        If item.FieldName.ToString = "d_other" Then
            Select Case e.SummaryProcess
                Case DevExpress.Data.CustomSummaryProcess.Start
                    tot_d_other = 0
                Case DevExpress.Data.CustomSummaryProcess.Calculate
                    If Not GVSummary.GetRowCellValue(e.RowHandle, "no").ToString = "" Then
                        tot_d_other += e.FieldValue
                    End If
                Case DevExpress.Data.CustomSummaryProcess.Finalize
                    e.TotalValue = Format(tot_d_other, "##,##0")
            End Select
        End If

        If item.FieldName.ToString = "total_cash" Then
            Select Case e.SummaryProcess
                Case DevExpress.Data.CustomSummaryProcess.Start
                    tot_total_cash = 0
                Case DevExpress.Data.CustomSummaryProcess.Calculate
                    If Not GVSummary.GetRowCellValue(e.RowHandle, "no").ToString = "" Then
                        tot_total_cash += e.FieldValue
                    End If
                Case DevExpress.Data.CustomSummaryProcess.Finalize
                    e.TotalValue = Format(tot_total_cash, "##,##0")
            End Select
        End If

        If item.FieldName.ToString = "balance" Then
            Select Case e.SummaryProcess
                Case DevExpress.Data.CustomSummaryProcess.Start
                    tot_balance = 0
                Case DevExpress.Data.CustomSummaryProcess.Calculate
                    If Not GVSummary.GetRowCellValue(e.RowHandle, "no").ToString = "" Then
                        tot_balance += e.FieldValue
                    End If
                Case DevExpress.Data.CustomSummaryProcess.Finalize
                    e.TotalValue = Format(tot_balance, "##,##0")
            End Select
        End If
    End Sub
End Class