Public Class ReportPayrollAll
    Public id_pre As String
    Public id_payroll As String = ""
    Public type As String = ""
    Public dt_office As DataTable = New DataTable
    Public dt_store As DataTable = New DataTable

    Private Sub ReportEmpUni_BeforePrint(sender As Object, e As Printing.PrintEventArgs) Handles MyBase.BeforePrint
        GCPayrollOffice.DataSource = dt_office
        GCPayrollStore.DataSource = dt_store

        If type = "1" Then
            'office
            GBWorkingDays.Visible = True
            GBSalary.Visible = True

            GBDW.Visible = False

            GBTHR.Visible = False

            GCTotalPaymentOvertime.Visible = True
            GCTotalDeduction.Visible = True

            GCPosition.Caption = "Employee" + Environment.NewLine + "Position"
            GCStatus.Caption = "Employee" + Environment.NewLine + "Status"
            GCActualWorkingDays.Caption = "Actual" + Environment.NewLine + "WD"
            GCOvertimeHours.Caption = "Overtime" + Environment.NewLine + "(Hours)"
            GCTotalTHP.Caption = "Total" + Environment.NewLine + "THP"
            GCTotalAdjustment.Caption = "Total" + Environment.NewLine + "Bonus / Adj"
            GCTotalDeduction.Caption = "Total" + Environment.NewLine + "Deduction"
            GCTotalPaymentOvertime.Caption = "Total" + Environment.NewLine + "Overtime"
            GCGrandTotal.Caption = "Grand" + Environment.NewLine + "Total"

            'store
            GBWorkingDaysStore.Visible = True
            GBSalaryStore.Visible = True

            GBDWStore.Visible = False

            GBTHRStore.Visible = False

            GCTotalPaymentOvertimeStore.Visible = True
            GCTotalDeductionStore.Visible = True

            GCPositionStore.Caption = "Employee" + Environment.NewLine + "Position"
            GCStatusStore.Caption = "Employee" + Environment.NewLine + "Status"
            GCActualWorkingDaysStore.Caption = "Actual" + Environment.NewLine + "WD"
            GCOvertimeHoursStore.Caption = "Overtime" + Environment.NewLine + "(Hours)"
            GCTotalTHPStore.Caption = "Total" + Environment.NewLine + "THP"
            GCTotalAdjustmentStore.Caption = "Total" + Environment.NewLine + "Bonus / Adj"
            GCTotalDeductionStore.Caption = "Total" + Environment.NewLine + "Deduction"
            GCTotalPaymentOvertimeStore.Caption = "Total" + Environment.NewLine + "Overtime"
            GCGrandTotalStore.Caption = "Grand" + Environment.NewLine + "Total"
        End If

        If type = "4" Then
            'office
            GCActualWorkingDaysDW.Caption = "Actual" + Environment.NewLine + "Working Days"
            GCTotalAdjustment.Caption = "Total" + Environment.NewLine + "Bonus / Adj"
            GCTotalDeduction.Caption = "Total" + Environment.NewLine + "Deduction"
            GCTotalPaymentOvertime.Caption = "Total" + Environment.NewLine + "Overtime"
            GCGrandTotal.Caption = "Grand" + Environment.NewLine + "Total"

            GBWorkingDays.Visible = False

            GCTotalTHP.Visible = False

            GBDW.Visible = True

            GBTHR.Visible = False

            GCTotalPaymentOvertime.Visible = True
            GCTotalDeduction.Visible = True

            GCStatus.Width = 100

            'store
            GCActualWorkingDaysDWStore.Caption = "Actual" + Environment.NewLine + "Working Days"
            GCTotalAdjustmentStore.Caption = "Total" + Environment.NewLine + "Bonus / Adj"
            GCTotalDeductionStore.Caption = "Total" + Environment.NewLine + "Deduction"
            GCTotalPaymentOvertimeStore.Caption = "Total" + Environment.NewLine + "Overtime"
            GCGrandTotalStore.Caption = "Grand" + Environment.NewLine + "Total"

            GBWorkingDaysStore.Visible = False

            GCTotalTHPStore.Visible = False

            GBDWStore.Visible = True

            GBTHRStore.Visible = False

            GCTotalPaymentOvertimeStore.Visible = True
            GCTotalDeductionStore.Visible = True

            GCStatusStore.Width = 100
        End If

        Dim is_thr As String = execute_query("SELECT is_thr FROM tb_emp_payroll_type WHERE id_payroll_type = " + type, 0, True, "", "", "", "")

        If is_thr = "1" Then
            'office
            GCTotalAdjustment.Caption = "Total" + Environment.NewLine + "Adjustment"
            GCGrandTotal.Caption = "Grand" + Environment.NewLine + "Total"
            GCActualJoinDateTHR.Caption = "Actual" + Environment.NewLine + "Join Date"
            GCLengthOfWorkTHR.Caption = "Length of Work" + Environment.NewLine + "(Year)"
            GCTotalSalaryTHR.Caption = "Total" + Environment.NewLine + "THR"

            GBWorkingDays.Visible = False

            GCTotalTHP.Visible = False

            GBDW.Visible = False

            GBTHR.Visible = True

            GCTotalPaymentOvertime.Visible = False
            GCTotalDeduction.Visible = False

            GCStatus.Width = 100

            'store
            GCTotalAdjustmentStore.Caption = "Total" + Environment.NewLine + "Adjustment"
            GCGrandTotalStore.Caption = "Grand" + Environment.NewLine + "Total"
            GCActualJoinDateTHRStore.Caption = "Actual" + Environment.NewLine + "Join Date"
            GCLengthOfWorkTHRStore.Caption = "Length of Work" + Environment.NewLine + "(Year)"
            GCTotalSalaryTHRStore.Caption = "Total" + Environment.NewLine + "THR"

            GBWorkingDaysStore.Visible = False

            GCTotalTHPStore.Visible = False

            GBDWStore.Visible = False

            GBTHRStore.Visible = True

            GCTotalPaymentOvertimeStore.Visible = False
            GCTotalDeductionStore.Visible = False

            GCStatusStore.Width = 100
        End If

        GCName.SummaryItem.DisplayFormat = "Grand Total: " + XLLocationOffice.Text.ToUpper
        GCNameStore.SummaryItem.DisplayFormat = "Grand Total: " + XLLocationStore.Text.ToUpper

        'mark
        If id_pre = "-1" Then
            load_mark_horz("192", id_payroll, "2", "1", XrTable1)
        Else
            pre_load_mark_horz("192", id_payroll, "2", "2", XrTable1)
        End If
    End Sub

    'office
    Private Sub GVPayrollOffice_CustomColumnDisplayText(sender As Object, e As DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs) Handles GVPayrollOffice.CustomColumnDisplayText
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

    'store
    Private Sub GVPayrollStore_CustomColumnDisplayText(sender As Object, e As DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs) Handles GVPayrollStore.CustomColumnDisplayText
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

    Dim sum_tot_thp_office As Double = 0
    Dim sum_tot_adj_office As Double = 0
    Dim sum_tot_ded_office As Double = 0
    Dim sum_tot_ot_office As Double = 0
    Dim sum_tot_dw_office As Double = 0
    Dim sum_tot_office As Double = 0
    Dim sum_tot_thr_office As Double = 0

    Dim sum_tot_thp_store As Double = 0
    Dim sum_tot_adj_store As Double = 0
    Dim sum_tot_ded_store As Double = 0
    Dim sum_tot_ot_store As Double = 0
    Dim sum_tot_dw_store As Double = 0
    Dim sum_tot_store As Double = 0
    Dim sum_tot_thr_store As Double = 0

    Private Sub GVPayrollOffice_CustomSummaryCalculate(sender As Object, e As DevExpress.Data.CustomSummaryEventArgs) Handles GVPayrollOffice.CustomSummaryCalculate
        Dim item As DevExpress.XtraGrid.GridSummaryItem = TryCast(e.Item, DevExpress.XtraGrid.GridSummaryItem)

        summary_custom(item, e, GVPayrollOffice)
    End Sub

    Private Sub GVPayrollStore_CustomSummaryCalculate(sender As Object, e As DevExpress.Data.CustomSummaryEventArgs) Handles GVPayrollStore.CustomSummaryCalculate
        Dim item As DevExpress.XtraGrid.GridSummaryItem = TryCast(e.Item, DevExpress.XtraGrid.GridSummaryItem)

        summary_custom(item, e, GVPayrollStore)
    End Sub

    Sub summary_custom(item As DevExpress.XtraGrid.GridSummaryItem, e As DevExpress.Data.CustomSummaryEventArgs, gridView As DevExpress.XtraGrid.Views.BandedGrid.BandedGridView)
        If item.FieldName.ToString = "tot_thp" Then
            Select Case e.SummaryProcess
                Case DevExpress.Data.CustomSummaryProcess.Start
                    If gridView.Name = "GVPayrollOffice" Then
                        sum_tot_thp_office = 0
                    Else
                        sum_tot_thp_store = 0
                    End If
                Case DevExpress.Data.CustomSummaryProcess.Calculate
                    If gridView.Name = "GVPayrollOffice" Then
                        sum_tot_thp_office += e.FieldValue
                    Else
                        sum_tot_thp_store += e.FieldValue
                    End If
                Case DevExpress.Data.CustomSummaryProcess.Finalize
                    If gridView.GetRowCellValue(e.RowHandle, "departement_sub").ToString.Contains("SOGO") Then
                        If gridView.Name = "GVPayrollOffice" Then
                            e.TotalValue = sum_tot_thp_office
                        Else
                            e.TotalValue = sum_tot_thp_store
                        End If
                    Else
                        If e.GroupLevel = 0 Then
                            If gridView.Name = "GVPayrollOffice" Then
                                e.TotalValue = sum_tot_thp_office
                            Else
                                e.TotalValue = sum_tot_thp_store
                            End If
                        End If
                    End If
            End Select
        End If

        If item.FieldName.ToString = "total_adjustment" Then
            Select Case e.SummaryProcess
                Case DevExpress.Data.CustomSummaryProcess.Start
                    If gridView.Name = "GVPayrollOffice" Then
                        sum_tot_adj_office = 0
                    Else
                        sum_tot_adj_store = 0
                    End If
                Case DevExpress.Data.CustomSummaryProcess.Calculate
                    If gridView.Name = "GVPayrollOffice" Then
                        sum_tot_adj_office += e.FieldValue
                    Else
                        sum_tot_adj_store += e.FieldValue
                    End If
                Case DevExpress.Data.CustomSummaryProcess.Finalize
                    If gridView.GetRowCellValue(e.RowHandle, "departement_sub").ToString.Contains("SOGO") Then
                        If gridView.Name = "GVPayrollOffice" Then
                            e.TotalValue = sum_tot_adj_office
                        Else
                            e.TotalValue = sum_tot_adj_store
                        End If
                    Else
                        If e.GroupLevel = 0 Then
                            If gridView.Name = "GVPayrollOffice" Then
                                e.TotalValue = sum_tot_adj_office
                            Else
                                e.TotalValue = sum_tot_adj_store
                            End If
                        End If
                    End If
            End Select
        End If

        If item.FieldName.ToString = "total_deduction" Then
            Select Case e.SummaryProcess
                Case DevExpress.Data.CustomSummaryProcess.Start
                    If gridView.Name = "GVPayrollOffice" Then
                        sum_tot_ded_office = 0
                    Else
                        sum_tot_ded_store = 0
                    End If
                Case DevExpress.Data.CustomSummaryProcess.Calculate
                    If gridView.Name = "GVPayrollOffice" Then
                        sum_tot_ded_office += e.FieldValue
                    Else
                        sum_tot_ded_store += e.FieldValue
                    End If
                Case DevExpress.Data.CustomSummaryProcess.Finalize
                    If gridView.GetRowCellValue(e.RowHandle, "departement_sub").ToString.Contains("SOGO") Then
                        If gridView.Name = "GVPayrollOffice" Then
                            e.TotalValue = sum_tot_ded_office
                        Else
                            e.TotalValue = sum_tot_ded_store
                        End If
                    Else
                        If e.GroupLevel = 0 Then
                            If gridView.Name = "GVPayrollOffice" Then
                                e.TotalValue = sum_tot_ded_office
                            Else
                                e.TotalValue = sum_tot_ded_store
                            End If
                        End If
                    End If
            End Select
        End If

        If item.FieldName.ToString = "total_ot_wages" Then
            Select Case e.SummaryProcess
                Case DevExpress.Data.CustomSummaryProcess.Start
                    If gridView.Name = "GVPayrollOffice" Then
                        sum_tot_ot_office = 0
                    Else
                        sum_tot_ot_store = 0
                    End If
                Case DevExpress.Data.CustomSummaryProcess.Calculate
                    If gridView.Name = "GVPayrollOffice" Then
                        sum_tot_ot_office += e.FieldValue
                    Else
                        sum_tot_ot_store += e.FieldValue
                    End If
                Case DevExpress.Data.CustomSummaryProcess.Finalize
                    If gridView.GetRowCellValue(e.RowHandle, "departement_sub").ToString.Contains("SOGO") Then
                        If gridView.Name = "GVPayrollOffice" Then
                            e.TotalValue = sum_tot_ot_office
                        Else
                            e.TotalValue = sum_tot_ot_store
                        End If
                    Else
                        If e.GroupLevel = 0 Then
                            If gridView.Name = "GVPayrollOffice" Then
                                e.TotalValue = sum_tot_ot_office
                            Else
                                e.TotalValue = sum_tot_ot_store
                            End If
                        End If
                    End If
            End Select
        End If

        If item.FieldName.ToString = "total_salary_dw" Then
            Select Case e.SummaryProcess
                Case DevExpress.Data.CustomSummaryProcess.Start
                    If gridView.Name = "GVPayrollOffice" Then
                        sum_tot_dw_office = 0
                    Else
                        sum_tot_dw_store = 0
                    End If
                Case DevExpress.Data.CustomSummaryProcess.Calculate
                    If gridView.Name = "GVPayrollOffice" Then
                        sum_tot_dw_office += e.FieldValue
                    Else
                        sum_tot_dw_store += e.FieldValue
                    End If
                Case DevExpress.Data.CustomSummaryProcess.Finalize
                    If gridView.GetRowCellValue(e.RowHandle, "departement_sub").ToString.Contains("SOGO") Then
                        If gridView.Name = "GVPayrollOffice" Then
                            e.TotalValue = sum_tot_dw_office
                        Else
                            e.TotalValue = sum_tot_dw_store
                        End If
                    Else
                        If e.GroupLevel = 0 Then
                            If gridView.Name = "GVPayrollOffice" Then
                                e.TotalValue = sum_tot_dw_office
                            Else
                                e.TotalValue = sum_tot_dw_store
                            End If
                        End If
                    End If
            End Select
        End If

        If item.FieldName.ToString = "grand_total" Then
            Select Case e.SummaryProcess
                Case DevExpress.Data.CustomSummaryProcess.Start
                    If gridView.Name = "GVPayrollOffice" Then
                        sum_tot_office = 0
                    Else
                        sum_tot_store = 0
                    End If
                Case DevExpress.Data.CustomSummaryProcess.Calculate
                    If gridView.Name = "GVPayrollOffice" Then
                        sum_tot_office += e.FieldValue
                    Else
                        sum_tot_store += e.FieldValue
                    End If
                Case DevExpress.Data.CustomSummaryProcess.Finalize
                    If gridView.GetRowCellValue(e.RowHandle, "departement_sub").ToString.Contains("SOGO") Then
                        If gridView.Name = "GVPayrollOffice" Then
                            e.TotalValue = sum_tot_office
                        Else
                            e.TotalValue = sum_tot_store
                        End If
                    Else
                        If e.GroupLevel = 0 Then
                            If gridView.Name = "GVPayrollOffice" Then
                                e.TotalValue = sum_tot_office
                            Else
                                e.TotalValue = sum_tot_store
                            End If
                        End If
                    End If
            End Select
        End If

        If item.FieldName.ToString = "total_salary_thr" Then
            Select Case e.SummaryProcess
                Case DevExpress.Data.CustomSummaryProcess.Start
                    If gridView.Name = "GVPayrollOffice" Then
                        sum_tot_thr_office = 0
                    Else
                        sum_tot_thr_store = 0
                    End If
                Case DevExpress.Data.CustomSummaryProcess.Calculate
                    If gridView.Name = "GVPayrollOffice" Then
                        sum_tot_thr_office += e.FieldValue
                    Else
                        sum_tot_thr_store += e.FieldValue
                    End If
                Case DevExpress.Data.CustomSummaryProcess.Finalize
                    If gridView.GetRowCellValue(e.RowHandle, "departement_sub").ToString.Contains("SOGO") Then
                        If gridView.Name = "GVPayrollOffice" Then
                            e.TotalValue = sum_tot_thr_office
                        Else
                            e.TotalValue = sum_tot_thr_store
                        End If
                    Else
                        If e.GroupLevel = 0 Then
                            If gridView.Name = "GVPayrollOffice" Then
                                e.TotalValue = sum_tot_thr_office
                            Else
                                e.TotalValue = sum_tot_thr_store
                            End If
                        End If
                    End If
            End Select
        End If

        If item.FieldName.ToString = "employee_name" Then
            Select Case e.SummaryProcess
                Case DevExpress.Data.CustomSummaryProcess.Finalize
                    Dim curr_departement As String = System.Text.RegularExpressions.Regex.Replace(gridView.GetRowCellValue(e.RowHandle, "departement").ToString, "\(([A-Z])\)", "").ToString()
                    Dim alphabet As String = gridView.GetRowCellValue(e.RowHandle, "departement").ToString.Replace(curr_departement, "")

                    Dim curr_departement_sub As String = System.Text.RegularExpressions.Regex.Replace(gridView.GetRowCellValue(e.RowHandle, "departement_sub").ToString, "\(([A-Z][0-9])\)", "").ToString()
                    Dim alphabet_sub As String = gridView.GetRowCellValue(e.RowHandle, "departement_sub").ToString.Replace(curr_departement_sub, "")

                    If gridView.GetRowCellValue(e.RowHandle, "departement_sub").ToString.Contains("SOGO") Then
                        If e.GroupLevel = 1 Then
                            e.TotalValue = "Total: " + alphabet_sub.Replace("(", "").Replace(")", "")
                        Else
                            e.TotalValue = "Total: " + alphabet.Replace("(", "").Replace(")", "")
                        End If
                    Else
                        If e.GroupLevel = 0 Then
                            e.TotalValue = "Total: " + alphabet.Replace("(", "").Replace(")", "")
                        End If
                    End If
            End Select
        End If
    End Sub

    Private Sub GVPayrollOffice_RowCellStyle(sender As Object, e As DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs) Handles GVPayrollOffice.RowCellStyle
        If GVPayrollOffice.GetRowCellValue(e.RowHandle, "is_resign").ToString = "1" Then
            e.Appearance.BackColor = Color.Yellow
        End If
    End Sub

    Private Sub GVPayrollStore_RowCellStyle(sender As Object, e As DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs) Handles GVPayrollStore.RowCellStyle
        If GVPayrollStore.GetRowCellValue(e.RowHandle, "is_resign").ToString = "1" Then
            e.Appearance.BackColor = Color.Yellow
        End If
    End Sub
End Class