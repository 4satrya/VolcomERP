Public Class ReportPayrollAll
    Public id_pre As String
    Public id_payroll As String = ""
    Public type As String = ""
    Public dt As DataTable

    Private Sub ReportEmpUni_BeforePrint(sender As Object, e As Printing.PrintEventArgs) Handles MyBase.BeforePrint
        GCPayroll.DataSource = dt

        If type = "1" Then
            GBWorkingDays.Visible = True
            GBSalary.Visible = True

            GBDW.Visible = False

            GCPosition.Caption = "Employee" + Environment.NewLine + "Position"
            GCStatus.Caption = "Employee" + Environment.NewLine + "Status"
            GCActualWorkingDays.Caption = "Actual" + Environment.NewLine + "WD"
            GCOvertimeHours.Caption = "Overtime" + Environment.NewLine + "(Hours)"
            GCTotalTHP.Caption = "Total" + Environment.NewLine + "THP"
            GCTotalAdjustment.Caption = "Total" + Environment.NewLine + "Bonus / Adj"
            GCTotalDeduction.Caption = "Total" + Environment.NewLine + "Deduction"
            GCTotalPaymentOvertime.Caption = "Total" + Environment.NewLine + "Overtime"
            GCGrandTotal.Caption = "Grand" + Environment.NewLine + "Total"
        End If

        If type = "4" Then
            GCActualWorkingDaysDW.Caption = "Actual" + Environment.NewLine + "Working Days"

            GBWorkingDays.Visible = False

            GCTotalTHP.Visible = False
            GCTotalAdjustment.Visible = False

            GBDW.Visible = True

            GCStatus.Width = 100
        End If

        'mark
        If id_pre = "-1" Then
            load_mark_horz("192", id_payroll, "2", "1", XrTable1)
        Else
            pre_load_mark_horz("192", id_payroll, "2", "2", XrTable1)
        End If
    End Sub

    Private Sub GVPayroll_CustomColumnDisplayText(sender As Object, e As DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs) Handles GVPayroll.CustomColumnDisplayText
        If e.IsForGroupRow Then
            'sogo
            If e.DisplayText.ToString.Contains("SOGO") Then
                If e.Column.Caption = "Departement" Then
                    e.DisplayText = "Departement: " + e.DisplayText
                ElseIf e.Column.Caption = "Sub Departement" Then
                    e.DisplayText = "Sub Departement: " + e.DisplayText
                End If
            Else
                If e.Column.Caption = "Departement" Then
                    e.DisplayText = "Departement: " + e.DisplayText
                ElseIf e.Column.Caption = "Sub Departement" Then
                    e.DisplayText = ""
                End If
            End If
        End If
    End Sub

    Dim sum_tot_thp As Double = 0
    Dim sum_tot_adj As Double = 0
    Dim sum_tot_ded As Double = 0
    Dim sum_tot_ot As Double = 0
    Dim sum_tot As Double = 0

    Private Sub GVPayroll_CustomSummaryCalculate(sender As Object, e As DevExpress.Data.CustomSummaryEventArgs) Handles GVPayroll.CustomSummaryCalculate

        Dim item As DevExpress.XtraGrid.GridSummaryItem = TryCast(e.Item, DevExpress.XtraGrid.GridSummaryItem)

        If item.FieldName.ToString = "tot_thp" Then
            Select Case e.SummaryProcess
                Case DevExpress.Data.CustomSummaryProcess.Start
                    sum_tot_thp = 0
                Case DevExpress.Data.CustomSummaryProcess.Calculate
                    sum_tot_thp += e.FieldValue
                Case DevExpress.Data.CustomSummaryProcess.Finalize
                    If GVPayroll.GetRowCellValue(e.RowHandle, "departement_sub").ToString.Contains("SOGO") Then
                        e.TotalValue = sum_tot_thp
                    Else
                        If e.GroupLevel = 0 Then
                            e.TotalValue = sum_tot_thp
                        End If
                    End If
            End Select
        End If

        If item.FieldName.ToString = "total_adjustment" Then
            Select Case e.SummaryProcess
                Case DevExpress.Data.CustomSummaryProcess.Start
                    sum_tot_adj = 0
                Case DevExpress.Data.CustomSummaryProcess.Calculate
                    sum_tot_adj += e.FieldValue
                Case DevExpress.Data.CustomSummaryProcess.Finalize
                    If GVPayroll.GetRowCellValue(e.RowHandle, "departement_sub").ToString.Contains("SOGO") Then
                        e.TotalValue = sum_tot_adj
                    Else
                        If e.GroupLevel = 0 Then
                            e.TotalValue = sum_tot_adj
                        End If
                    End If
            End Select
        End If

        If item.FieldName.ToString = "total_deduction" Then
            Select Case e.SummaryProcess
                Case DevExpress.Data.CustomSummaryProcess.Start
                    sum_tot_ded = 0
                Case DevExpress.Data.CustomSummaryProcess.Calculate
                    sum_tot_ded += e.FieldValue
                Case DevExpress.Data.CustomSummaryProcess.Finalize
                    If GVPayroll.GetRowCellValue(e.RowHandle, "departement_sub").ToString.Contains("SOGO") Then
                        e.TotalValue = sum_tot_ded
                    Else
                        If e.GroupLevel = 0 Then
                            e.TotalValue = sum_tot_ded
                        End If
                    End If
            End Select
        End If

        If item.FieldName.ToString = "total_ot_wages" Then
            Select Case e.SummaryProcess
                Case DevExpress.Data.CustomSummaryProcess.Start
                    sum_tot_ot = 0
                Case DevExpress.Data.CustomSummaryProcess.Calculate
                    sum_tot_ot += e.FieldValue
                Case DevExpress.Data.CustomSummaryProcess.Finalize
                    If GVPayroll.GetRowCellValue(e.RowHandle, "departement_sub").ToString.Contains("SOGO") Then
                        e.TotalValue = sum_tot_ot
                    Else
                        If e.GroupLevel = 0 Then
                            e.TotalValue = sum_tot_ot
                        End If
                    End If
            End Select
        End If

        If item.FieldName.ToString = "grand_total" Then
            Select Case e.SummaryProcess
                Case DevExpress.Data.CustomSummaryProcess.Start
                    sum_tot = 0
                Case DevExpress.Data.CustomSummaryProcess.Calculate
                    sum_tot += e.FieldValue
                Case DevExpress.Data.CustomSummaryProcess.Finalize
                    If GVPayroll.GetRowCellValue(e.RowHandle, "departement_sub").ToString.Contains("SOGO") Then
                        e.TotalValue = sum_tot
                    Else
                        If e.GroupLevel = 0 Then
                            e.TotalValue = sum_tot
                        End If
                    End If
            End Select
        End If
    End Sub
End Class