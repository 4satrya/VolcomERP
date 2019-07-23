Public Class ReportEmpPayrollReportAllDepartement
    Public type As String = ""
    Public id_payroll As String = ""
    Public id_pre As String
    Public data As DataTable
    Public data_office As DataTable
    Public data_store As DataTable

    Private Sub ReportEmpPayrollReportAllDepartement_BeforePrint(sender As Object, e As Printing.PrintEventArgs) Handles MyBase.BeforePrint
        'office
        GVSummaryOffice.Columns("event_overtime").Caption = "Overtime" + Environment.NewLine + "Event"
        GVSummaryOffice.Columns("d_cooperative_loan").Caption = "Cooperative" + Environment.NewLine + "Loan"
        GVSummaryOffice.Columns("d_bpjskes").Caption = "BPJS" + Environment.NewLine + "Kesehatan"
        GVSummaryOffice.Columns("d_jaminan_pensiun").Caption = "JP" + Environment.NewLine + "Contribution"
        GVSummaryOffice.Columns("d_cooperative_contribution").Caption = "Cooperative" + Environment.NewLine + "Contribution"
        GVSummaryOffice.Columns("d_missing").Caption = "Saving" + Environment.NewLine + "Missing"
        GVSummaryOffice.Columns("d_meditation_cash").Caption = "Meditation" + Environment.NewLine + "/ Cash Receipt"

        GCSummaryOffice.DataSource = data_office

        'store
        GVSummaryStore.Columns("event_overtime").Caption = "Overtime" + Environment.NewLine + "Event"
        GVSummaryStore.Columns("d_cooperative_loan").Caption = "Cooperative" + Environment.NewLine + "Loan"
        GVSummaryStore.Columns("d_bpjskes").Caption = "BPJS" + Environment.NewLine + "Kesehatan"
        GVSummaryStore.Columns("d_jaminan_pensiun").Caption = "JP" + Environment.NewLine + "Contribution"
        GVSummaryStore.Columns("d_cooperative_contribution").Caption = "Cooperative" + Environment.NewLine + "Contribution"
        GVSummaryStore.Columns("d_missing").Caption = "Saving" + Environment.NewLine + "Missing"
        GVSummaryStore.Columns("d_meditation_cash").Caption = "Meditation" + Environment.NewLine + "/ Cash Receipt"

        GCSummaryStore.DataSource = data_store

        'all
        GCSummaryAll.DataSource = data

        GVSummaryAll.Columns("volcom_indonesia").Caption = "VOLCOM INDONESIA" + Environment.NewLine + "(VCIN)"
        GVSummaryAll.Columns("bemo_corner").Caption = "BEMO CORNER" + Environment.NewLine + "(VCOM)"
        GVSummaryAll.Columns("kuta_square").Caption = "KUTA SQUARE" + Environment.NewLine + "(VOCM)"
        GVSummaryAll.Columns("seminyak").Caption = "SEMINYAK" + Environment.NewLine + "(PTVI)"

        'mark
        If id_pre = "-1" Then
            load_mark_horz("192", id_payroll, "2", "1", XrTable1)
        Else
            pre_load_mark_horz("192", id_payroll, "2", "2", XrTable1)
        End If
    End Sub

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

    Private Sub GVSummaryStore_CustomSummaryCalculate(sender As Object, e As DevExpress.Data.CustomSummaryEventArgs) Handles GVSummaryStore.CustomSummaryCalculate
        Dim item As DevExpress.XtraGrid.GridSummaryItem = TryCast(e.Item, DevExpress.XtraGrid.GridSummaryItem)

        If item.FieldName.ToString = "salary" Then
            Select Case e.SummaryProcess
                Case DevExpress.Data.CustomSummaryProcess.Start
                    tot_salary = 0
                Case DevExpress.Data.CustomSummaryProcess.Calculate
                    If Not GVSummaryStore.GetRowCellValue(e.RowHandle, "no").ToString = "" Then
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
                    If Not GVSummaryStore.GetRowCellValue(e.RowHandle, "no").ToString = "" Then
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
                    If Not GVSummaryStore.GetRowCellValue(e.RowHandle, "no").ToString = "" Then
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
                    If Not GVSummaryStore.GetRowCellValue(e.RowHandle, "no").ToString = "" Then
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
                    If Not GVSummaryStore.GetRowCellValue(e.RowHandle, "no").ToString = "" Then
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
                    If Not GVSummaryStore.GetRowCellValue(e.RowHandle, "no").ToString = "" Then
                        tot_d_bpjstk += e.FieldValue
                    End If
                Case DevExpress.Data.CustomSummaryProcess.Finalize
                    e.TotalValue = Format(tot_d_bpjstk, "##,##0")
            End Select
        End If

        If item.FieldName.ToString = "d_cooperative_contributtion" Then
            Select Case e.SummaryProcess
                Case DevExpress.Data.CustomSummaryProcess.Start
                    tot_d_cooperative_contributtion = 0
                Case DevExpress.Data.CustomSummaryProcess.Calculate
                    If Not GVSummaryStore.GetRowCellValue(e.RowHandle, "no").ToString = "" Then
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
                    If Not GVSummaryStore.GetRowCellValue(e.RowHandle, "no").ToString = "" Then
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
                    If Not GVSummaryStore.GetRowCellValue(e.RowHandle, "no").ToString = "" Then
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
                    If Not GVSummaryStore.GetRowCellValue(e.RowHandle, "no").ToString = "" Then
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
                    If Not GVSummaryStore.GetRowCellValue(e.RowHandle, "no").ToString = "" Then
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
                    If Not GVSummaryStore.GetRowCellValue(e.RowHandle, "no").ToString = "" Then
                        tot_balance += e.FieldValue
                    End If
                Case DevExpress.Data.CustomSummaryProcess.Finalize
                    e.TotalValue = Format(tot_balance, "##,##0")
            End Select
        End If
    End Sub
End Class