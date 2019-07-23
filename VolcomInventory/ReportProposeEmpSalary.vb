Public Class ReportProposeEmpSalary
    Public id_employee_sal_pps As String = "-1"
    Public type As String = "1"
    Public data As DataTable = New DataTable
    Public is_pre As String = "-1"

    Private Sub ReportProposeEmpSalary_BeforePrint(sender As Object, e As Printing.PrintEventArgs) Handles MyBase.BeforePrint
        GCEmployee.DataSource = data

        GCEmployeeStatus.Caption = GCEmployeeStatus.Caption.Replace(" ", Environment.NewLine)
        GCBasicSalary.Caption = GCBasicSalary.Caption.Replace(" ", Environment.NewLine)
        GCJobAllowance.Caption = GCJobAllowance.Caption.Replace(" ", Environment.NewLine)
        GCMealAllowance.Caption = GCMealAllowance.Caption.Replace(" ", Environment.NewLine)
        GCTransportAllowance.Caption = GCTransportAllowance.Caption.Replace(" ", Environment.NewLine)
        GCHouseAllowance.Caption = GCHouseAllowance.Caption.Replace(" ", Environment.NewLine)
        GCAttendanceAllowance.Caption = GCAttendanceAllowance.Caption.Replace(" ", Environment.NewLine)
        GCTotalSalary.Caption = GCTotalSalary.Caption.Replace(" ", Environment.NewLine)
        GCTotalSalary.Caption = GCTotalSalary.Caption.Replace(" ", Environment.NewLine)
        GCFixedSalary.Caption = GCFixedSalary.Caption.Replace(" ", Environment.NewLine)
        GCNonFixedSalary.Caption = GCNonFixedSalary.Caption.Replace(" ", Environment.NewLine)

        If type = "2" Then
            GCBasicSalary.Caption = "Daily" + Environment.NewLine + "Salary"

            GCJobAllowance.VisibleIndex = -1
            GCMealAllowance.VisibleIndex = -1
            GCTransportAllowance.VisibleIndex = -1
            GCHouseAllowance.VisibleIndex = -1
            GCAttendanceAllowance.VisibleIndex = -1
            GCTotalSalary.VisibleIndex = -1

            GBComposition.Visible = False
        End If

        GVEmployee.BestFitColumns()

        If is_pre = "-1" Then
            load_mark_horz("197", id_employee_sal_pps, "2", "1", XrTable1)
        Else
            load_mark_horz("197", id_employee_sal_pps, "2", "2", XrTable1)
        End If
    End Sub
End Class