Public Class FormEmpAttnSumDetailLate
    Public id_employee As String = "-1"
    Public date_from As Date = Date.Now
    Public date_to As Date = Date.Now
    Public month As Date = Nothing

    Private Sub FormEmpAttnSumDetailLate_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Cursor = Cursors.WaitCursor

        Dim data_employee As DataTable = execute_query("SELECT employee_code, employee_name FROM tb_m_employee WHERE id_employee = " + id_employee, -1, True, "", "", "", "")

        TEEmployeeCode.EditValue = data_employee.Rows(0)("employee_code").ToString
        TEEmployeeName.EditValue = data_employee.Rows(0)("employee_name").ToString

        Dim where_month As String = ""

        If Not month = Nothing Then
            where_month = "AND YEAR(sch.date) = " + month.ToString("yyyy") + " AND MONTH(sch.date) = " + month.ToString("MM")
        End If

        Dim tb_attn As String = "
            (SELECT * FROM tb_emp_attn WHERE id_employee LIKE '" & id_employee & "' AND `datetime` >= DATE_ADD('" & date_from.ToString("yyyy-MM-dd") & "', INTERVAL 1 DAY) AND `datetime` <= DATE_ADD('" & date_to.ToString("yyyy-MM-dd") & "', INTERVAL -1 DAY))
            UNION ALL
            (SELECT 0 AS id_emp_attn, 0 AS id_fingerprint, e.employee_code, d.id_employee, d.time_in AS `datetime`, 1 AS type_log, 0 AS scan_method
            FROM `tb_emp_attn_input_det` AS d
            LEFT JOIN `tb_emp_attn_input` AS a ON d.id_emp_attn_input = a.id_emp_attn_input
            LEFT JOIN `tb_m_employee` AS e ON d.id_employee = e.id_employee
            WHERE d.id_departement = 17 AND d.id_employee LIKE '" & id_employee & "' AND d.date >= DATE_ADD('" & date_from.ToString("yyyy-MM-dd") & "', INTERVAL 1 DAY) AND d.date <= DATE_ADD('" & date_to.ToString("yyyy-MM-dd") & "', INTERVAL -1 DAY))
            UNION ALL
            (SELECT 0 AS id_emp_attn, 0 AS id_fingerprint, e.employee_code, d.id_employee, d.time_out AS `datetime`, 2 AS type_log, 0 AS scan_method
            FROM `tb_emp_attn_input_det` AS d
            LEFT JOIN `tb_emp_attn_input` AS a ON d.id_emp_attn_input = a.id_emp_attn_input
            LEFT JOIN `tb_m_employee` AS e ON d.id_employee = e.id_employee
            WHERE d.id_departement = 17 AND d.id_employee LIKE '" & id_employee & "' AND d.date >= DATE_ADD('" & date_from.ToString("yyyy-MM-dd") & "', INTERVAL 1 DAY) AND d.date <= DATE_ADD('" & date_to.ToString("yyyy-MM-dd") & "', INTERVAL -1 DAY))
        "

        Dim query_list As String = "
            SELECT *
            FROM (
                SELECT 
                    DATE_FORMAT(sch.date, '%M %Y') AS late_month,
                    DATE_FORMAT(sch.date, '%d %M %Y') AS late_date,
                    DATE_FORMAT(IF(sch.id_schedule_type = 1, MIN(at_in.datetime), MIN(at_in_hol.datetime)), '%H:%i:%s') AS att_in, 
                    DATE_FORMAT(IF(sch.id_schedule_type = 1, MAX(at_out.datetime), MAX(at_out_hol.datetime)), '%H:%i:%s') AS att_out, 
                    IF(lv.is_full_day = 1, 0, IF(IF(MIN(at_in.datetime) > sch.in_tolerance, TIMESTAMPDIFF(MINUTE, sch.in_tolerance, MIN(at_in.datetime)), 0) - IF(lv.is_full_day = 1 OR ISNULL(lv.datetime_until), 0, IF(lv.datetime_until = sch.out, 0, IF(lv.id_leave_type = 5 OR lv.id_leave_type = 6, lv.minutes_total, lv.minutes_total + 60))) < 0, 0, IF(MIN(at_in.datetime) > sch.in_tolerance, TIMESTAMPDIFF(MINUTE, sch.in_tolerance, MIN(at_in.datetime)), 0) - IF(lv.is_full_day = 1 OR ISNULL(lv.datetime_until), 0, IF(lv.datetime_until = sch.out, 0, IF(lv.id_leave_type = 5 OR lv.id_leave_type = 6, lv.minutes_total, lv.minutes_total + 60))))) AS late
                FROM tb_emp_schedule sch 
                LEFT JOIN
                (
                    SELECT eld.id_schedule, eld.is_full_day, eld.datetime_until, eld.minutes_total, el.id_leave_type
                    FROM tb_emp_leave_det eld
                    INNER JOIN tb_emp_leave el ON el.id_emp_leave = eld.id_emp_leave
                    WHERE el.id_report_status = '6' AND el.id_emp = " + id_employee + " AND eld.datetime_start BETWEEN '" + date_from.ToString("yyyy-MM-dd") + "' AND '" + date_to.ToString("yyyy-MM-dd") + "'
                    GROUP BY eld.id_schedule
                ) lv ON lv.id_schedule = sch.id_schedule
                LEFT JOIN (" + tb_attn + ") at_in ON at_in.id_employee = sch.id_employee AND (at_in.datetime >= (sch.out - INTERVAL 1 DAY) AND at_in.datetime <= sch.out) AND at_in.type_log = 1 
                LEFT JOIN (" + tb_attn + ") at_out ON at_out.id_employee = sch.id_employee AND (at_out.datetime >= sch.in AND at_out.datetime <= (sch.in + INTERVAL 1 DAY)) AND at_out.type_log = 2 
                LEFT JOIN (" + tb_attn + ") at_in_hol ON at_in_hol.id_employee = sch.id_employee AND DATE(at_in_hol.datetime) = sch.Date AND at_in_hol.type_log = 1 
                LEFT JOIN (" + tb_attn + ") at_out_hol ON at_out_hol.id_employee = sch.id_employee AND DATE(at_out_hol.datetime) = sch.Date AND at_out_hol.type_log = 2   
                WHERE sch.date BETWEEN '" + date_from.ToString("yyyy-MM-dd") + "' AND '" + date_to.ToString("yyyy-MM-dd") + "' AND sch.id_employee = " + id_employee + " " + where_month + "
                GROUP BY sch.id_schedule
            ) tb
            WHERE late > 0
        "

        Dim data_list As DataTable = execute_query(query_list, -1, True, "", "", "", "")

        GCList.DataSource = data_list

        GVList.BestFitColumns()

        Cursor = Cursors.Default
    End Sub

    Private Sub FormEmpAttnSumDetailLate_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub BPrintSum_Click(sender As Object, e As EventArgs) Handles BPrintSum.Click
        ReportAttnSum.dt = GCList.DataSource
        ReportAttnSum.id_report_type = "-1"
        Dim Report As New ReportAttnSum()

        ' '... 
        ' ' creating and saving the view's layout to a new memory stream 
        Dim str As System.IO.Stream
        str = New System.IO.MemoryStream()
        GVList.SaveLayoutToStream(str, DevExpress.Utils.OptionsLayoutBase.FullLayout)
        str.Seek(0, System.IO.SeekOrigin.Begin)
        Report.GVSchedule.RestoreLayoutFromStream(str, DevExpress.Utils.OptionsLayoutBase.FullLayout)
        str.Seek(0, System.IO.SeekOrigin.Begin)

        'Grid Detail
        ReportStyleGridview(Report.GVSchedule)

        'Parse val
        Report.LTitle.Text = "DETAIL LATE REPORT"
        Report.LType.Text = "Name"
        Report.LDept.Text = TEEmployeeName.EditValue.ToString
        Report.LDateRange.Text = Date.Parse(date_from).ToString("dd MMM yyyy") + " - " + Date.Parse(date_to).ToString("dd MMM yyyy")

        'Show the report's preview. 
        Dim Tool As DevExpress.XtraReports.UI.ReportPrintTool = New DevExpress.XtraReports.UI.ReportPrintTool(Report)
        Tool.ShowPreview()
    End Sub

    Private Sub GVList_CustomColumnSort(sender As Object, e As DevExpress.XtraGrid.Views.Base.CustomColumnSortEventArgs) Handles GVList.CustomColumnSort
        If e.Column.FieldName = "late_month" Then
            Dim val1 As DateTime = Convert.ToDateTime(e.Value1)
            Dim val2 As DateTime = Convert.ToDateTime(e.Value2)

            e.Result = Comparer.Default.Compare(val1, val2)

            e.Handled = True
        End If
    End Sub
End Class