Public Class ReportProposeEmpSalaryCompare
    Public id_employee_sal_pps As String = "-1"
    Public category As String = "1"
    Public data As DataTable = New DataTable
    Public is_pre As String = "-1"

    Private Sub ReportProposeEmpSalaryCompare_BeforePrint(sender As Object, e As Printing.PrintEventArgs) Handles MyBase.BeforePrint
        Dim data_new As DataTable = New DataTable
        data_new.Columns.Add("employee_code", GetType(String))
        data_new.Columns.Add("employee_name", GetType(String))
        data_new.Columns.Add("departement", GetType(String))
        data_new.Columns.Add("salary_type", GetType(String))
        data_new.Columns.Add("basic_salary", GetType(Decimal))
        data_new.Columns.Add("allow_job", GetType(Decimal))
        data_new.Columns.Add("allow_meal", GetType(Decimal))
        data_new.Columns.Add("allow_trans", GetType(Decimal))
        data_new.Columns.Add("allow_house", GetType(Decimal))
        data_new.Columns.Add("allow_car", GetType(Decimal))

        Dim salary_type As List(Of String) = New List(Of String)
        salary_type.Add("_current")
        salary_type.Add("")

        For i = 0 To data.Rows.Count - 1
            For j = 0 To salary_type.Count - 1
                data_new.Rows.Add(
                    data.Rows(i)("employee_code").ToString,
                    data.Rows(i)("employee_name").ToString,
                    data.Rows(i)("departement").ToString,
                    If(salary_type(j) = "", "Propose", "Current"),
                    data.Rows(i)("basic_salary" + salary_type(j)),
                    data.Rows(i)("allow_job" + salary_type(j)),
                    data.Rows(i)("allow_meal" + salary_type(j)),
                    data.Rows(i)("allow_trans" + salary_type(j)),
                    data.Rows(i)("allow_house" + salary_type(j)),
                    data.Rows(i)("allow_car" + salary_type(j))
                )
            Next
        Next

        GCEmployee.DataSource = data_new

        GCBasicSalary.Caption = GCBasicSalary.Caption.Replace(" ", Environment.NewLine)
        GCJobAllowance.Caption = GCJobAllowance.Caption.Replace(" ", Environment.NewLine)
        GCMealAllowance.Caption = GCMealAllowance.Caption.Replace(" ", Environment.NewLine)
        GCTransportAllowance.Caption = GCTransportAllowance.Caption.Replace(" ", Environment.NewLine)
        GCHouseAllowance.Caption = GCHouseAllowance.Caption.Replace(" ", Environment.NewLine)
        GCAttendanceAllowance.Caption = GCAttendanceAllowance.Caption.Replace(" ", Environment.NewLine)
        GCTotalSalary.Caption = GCTotalSalary.Caption.Replace(" ", Environment.NewLine)

        Dim id_report_status As String = execute_query("SELECT id_report_status FROM tb_employee_sal_pps WHERE id_employee_sal_pps = " + id_employee_sal_pps, 0, True, "", "", "", "")

        If id_report_status = "0" Then
            XrTable1.Visible = False
        Else
            If is_pre = "-1" Then
                load_mark_horz(If(category = "1", "197", "229"), id_employee_sal_pps, "2", "1", XrTable1)
            Else
                pre_load_mark_horz(If(category = "1", "197", "229"), id_employee_sal_pps, "2", "2", XrTable1)
            End If
        End If
    End Sub
End Class