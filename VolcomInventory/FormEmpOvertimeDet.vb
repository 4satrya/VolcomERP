Public Class FormEmpOvertimeDet
    Public is_hrd As String = "-1"
    Public is_check As String = "-1"
    Public id As String = "0"

    Private Sub FormEmpOvertimeDet_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        form_load()
    End Sub

    Sub form_load()
        ' default
        viewLookupQuery(LUEOvertimeType, "SELECT id_ot_type, CONCAT(IF(is_event = 1, 'Event ', ''), ot_type) AS ot_type FROM tb_lookup_ot_type", 0, "ot_type", "id_ot_type")
        viewSearchLookupRepositoryQuery(RISLUEType, "SELECT 1 AS id_type, 'Salary' AS type UNION SELECT 2 AS id_type, 'DP' AS type", 0, "type", "id_type")
        viewSearchLookupQuery(SLUEPayrollPeriod, "SELECT id_payroll, DATE_FORMAT(periode_start, '%d %M %Y') AS periode_start, DATE_FORMAT(periode_end, '%d %M %Y') AS periode_end, DATE_FORMAT(periode_end, '%M %Y') as periode FROM tb_emp_payroll WHERE id_payroll_type = 1", "id_payroll", "periode", "id_payroll")

        DEOvertimeDate.EditValue = Now
        TECreatedBy.EditValue = get_emp(id_employee_user, "2")
        TECreatedAt.EditValue = DateTime.Parse(Now).ToString("dd MMM yyyy h:mm:ss tt")

        Dim data As DataTable = New DataTable

        data.Columns.Add("id_employee", GetType(String))
        data.Columns.Add("only_dp", GetType(String))
        data.Columns.Add("id_departement", GetType(String))
        data.Columns.Add("departement", GetType(String))
        data.Columns.Add("employee_code", GetType(String))
        data.Columns.Add("employee_name", GetType(String))
        data.Columns.Add("employee_position", GetType(String))
        data.Columns.Add("id_employee_level", GetType(String))
        data.Columns.Add("employee_level", GetType(String))
        data.Columns.Add("conversion_type", GetType(String))
        data.Columns.Add("start_work", GetType(String))
        data.Columns.Add("end_work", GetType(String))
        data.Columns.Add("valid", GetType(String))

        GCEmployee.DataSource = data

        'load database
        If Not id = "0" Then
            Dim query_ot As String = "
                SELECT ot.id_ot, ot.id_ot_type, ot_type.ot_type, DATE_FORMAT(ot.ot_date, '%d %M %Y') AS ot_date, DATE_FORMAT(ot.ot_start_time, '%l:%i:%s %p') AS ot_start_time, DATE_FORMAT(ot.ot_end_time, '%l:%i:%s %p') AS ot_end_time, ot.ot_break, (TIMESTAMPDIFF(HOUR, ot.ot_start_time, ot.ot_end_time) - ot.ot_break) AS total_hours, ot.ot_note, ot.id_payroll, DATE_FORMAT(payroll.periode_end, '%M %Y') AS payroll_periode, ot.id_report_status, report_status.report_status, IFNULL(check_status.report_status, 'Not Checked') AS check_status, ot.hrd_check, ot.number, employee.employee_name AS created_by, DATE_FORMAT(ot.created_at, '%d %M %Y %l:%i:%s %p') AS created_at
                FROM tb_ot AS ot
                LEFT JOIN tb_lookup_ot_type AS ot_type ON ot.id_ot_type = ot_type.id_ot_type
                LEFT JOIN tb_emp_payroll AS payroll ON ot.id_payroll = payroll.id_payroll
                LEFT JOIN tb_lookup_report_status AS report_status ON ot.id_report_status = report_status.id_report_status
                LEFT JOIN tb_lookup_report_status AS check_status ON ot.id_check_status = check_status.id_report_status
                LEFT JOIN tb_m_employee AS employee ON ot.created_by = employee.id_employee
                WHERE ot.id_ot = " + id + "
            "

            Dim data_ot As DataTable = execute_query(query_ot, -1, True, "", "", "", "")

            TENumber.EditValue = data_ot.Rows(0)("number").ToString
            DEOvertimeDate.EditValue = data_ot.Rows(0)("ot_date").ToString
            TECreatedBy.EditValue = data_ot.Rows(0)("created_by").ToString
            TECreatedAt.EditValue = data_ot.Rows(0)("created_at").ToString
            LUEOvertimeType.ItemIndex = LUEOvertimeType.Properties.GetDataSourceRowIndex("id_ot_type", data_ot.Rows(0)("id_ot_type").ToString)
            TEOvertimeStart.EditValue = Date.Parse(data_ot.Rows(0)("ot_start_time").ToString)
            TEOvertimeEnd.EditValue = Date.Parse(data_ot.Rows(0)("ot_end_time").ToString)
            TEOvertimeBreak.EditValue = data_ot.Rows(0)("ot_break").ToString
            MEOvertimeNote.EditValue = data_ot.Rows(0)("ot_note").ToString
            SLUEPayrollPeriod.EditValue = data_ot.Rows(0)("id_payroll")
            TEReportStatus.EditValue = data_ot.Rows(0)("report_status").ToString
            TECheckStatus.EditValue = data_ot.Rows(0)("check_status").ToString

            ' load employee
            ' column
            Dim whereCheckColumn As String = "TIME_FORMAT(IF(sch.id_schedule_type = 1, ot.ot_start_time, att_in.datetime), '%h:%i:%s %p') AS start_work, TIME_FORMAT(att_out.datetime, '%h:%i:%s %p') AS end_work, ot.ot_break AS break_hours, (TIMESTAMPDIFF(HOUR, IF(sch.id_schedule_type = 1, ot.ot_start_time, att_in.datetime), att_out.datetime) - ot.ot_break) AS total_hours"

            If data_ot.Rows(0)("hrd_check").ToString = "1" Then
                whereCheckColumn = "TIME_FORMAT(ot_det.start_work, '%h:%i:%s %p') AS start_work, TIME_FORMAT(ot_det.end_work, '%h:%i:%s %p') AS end_work, ot_det.break_hours, (TIMESTAMPDIFF(HOUR, ot_det.start_work, ot_det.end_work) - ot_det.break_hours) AS total_hours"
            End If

            ' table join
            Dim whereCheckJoin As String = "
                LEFT JOIN (
                    SELECT id_employee, TIME(MIN(`datetime`)) AS `datetime` 
                    FROM tb_emp_attn
                    WHERE type_log = 1 AND DATE(`datetime`) = '" + Date.Parse(data_ot.Rows(0)("ot_date").ToString).ToString("yyyy-MM-dd") + "' 
                    GROUP BY id_employee
                ) att_in ON ot_det.id_employee = att_in.id_employee
                LEFT JOIN (
                    SELECT id_employee, TIME(MAX(`datetime`)) AS `datetime` 
                    FROM tb_emp_attn
                    WHERE type_log = 2 AND DATE(`datetime`) = '" + Date.Parse(data_ot.Rows(0)("ot_date").ToString).ToString("yyyy-MM-dd") + "'
                    GROUP BY id_employee
                ) att_out ON ot_det.id_employee = att_out.id_employee
                LEFT JOIN (
                    SELECT id_employee, id_schedule_type FROM tb_emp_schedule WHERE date = '" + Date.Parse(data_ot.Rows(0)("ot_date").ToString).ToString("yyyy-MM-dd") + "'
                ) sch ON ot_det.id_employee = sch.id_employee
            "

            If data_ot.Rows(0)("hrd_check").ToString = "1" Then
                whereCheckJoin = ""
            End If

            Dim query_ot_det As String = "
                SELECT ot_det.id_employee, IF(ot_det.id_employee_level < 13, 'yes', 'no') AS only_dp, ot_det.id_departement, departement.departement, employee.employee_code, employee.employee_name, ot_det.employee_position, ot_det.id_employee_level, employee_level.employee_level, ot_det.conversion_type, " + whereCheckColumn + ", IF(is_valid = 1, 'yes', 'no') AS valid
                FROM tb_ot_det AS ot_det
                LEFT JOIN tb_ot AS ot ON ot_det.id_ot = ot.id_ot
                LEFT JOIN tb_m_employee AS employee ON ot_det.id_employee = employee.id_employee
                LEFT JOIN tb_m_departement AS departement ON ot_det.id_departement = departement.id_departement
                LEFT JOIN tb_lookup_employee_level AS employee_level ON ot_det.id_employee_level = employee_level.id_employee_level
                " + whereCheckJoin + "
                WHERE ot_det.id_ot = " + id + "
            "

            Dim data_ot_det As DataTable = execute_query(query_ot_det, -1, True, "", "", "", "")

            GCEmployee.DataSource = data_ot_det

            GVEmployee.BestFitColumns()
        End If

        calculateTotalHours()

        ' permission
        If Not id = "0" Then
            LUEOvertimeType.ReadOnly = True
            DEOvertimeDate.ReadOnly = True
            TEOvertimeStart.ReadOnly = True
            TEOvertimeEnd.ReadOnly = True
            TEOvertimeBreak.ReadOnly = True
            MEOvertimeNote.ReadOnly = True
            SLUEPayrollPeriod.ReadOnly = True

            RISLUEType.ReadOnly = True

            SBEmpDelete.Enabled = False
            SBEmpAdd.Enabled = False
            SBMark.Enabled = True
            SBPrint.Enabled = True
            SBSave.Enabled = False
        End If

        If is_check = "-1" Then
            GCStartWork.Visible = False
            GCEndWork.Visible = False
            GCBreakHours.Visible = False
            GCTotalHours.Visible = False
            GCValid.Visible = False

            SBCheck.Visible = False

            SBSave.Visible = True

            PCCheckStatus.Visible = False
        Else
            Dim query_check As String = "SELECT id_check_status FROM tb_ot WHERE id_ot = " + id + ""

            Dim data_check As DataTable = execute_query(query_check, -1, True, "", "", "", "")

            If data_check.Rows(0)("id_check_status").ToString = "" Then
                RISLUEType.ReadOnly = False

                SLUEPayrollPeriod.ReadOnly = False

                SBMark.Enabled = False
                SBPrint.Enabled = False
                SBCheck.Enabled = True
            Else
                RISLUEType.ReadOnly = True

                SLUEPayrollPeriod.ReadOnly = True

                SBMark.Enabled = True
                SBPrint.Enabled = True
                SBCheck.Enabled = False

                GCStartWork.OptionsColumn.AllowEdit = False
                GCEndWork.OptionsColumn.AllowEdit = False
                GCBreakHours.OptionsColumn.AllowEdit = False
                GCValid.OptionsColumn.AllowEdit = False
            End If

            GCStartWork.Visible = True
            GCEndWork.Visible = True
            GCBreakHours.Visible = True
            GCTotalHours.Visible = True
            GCValid.Visible = True

            SBCheck.Visible = True

            SBSave.Visible = False

            PCCheckStatus.Visible = True
        End If
    End Sub

    Sub calculateTotalHours()
        TEOvertimeStart.EditValue = Date.Parse(Date.Parse(DEOvertimeDate.EditValue.ToString).ToString("yyyy-MM-dd") + " " + Date.Parse(TEOvertimeStart.EditValue.ToString).ToString("HH:mm:ss"))
        TEOvertimeEnd.EditValue = Date.Parse(Date.Parse(DEOvertimeDate.EditValue.ToString).ToString("yyyy-MM-dd") + " " + Date.Parse(TEOvertimeEnd.EditValue.ToString).ToString("HH:mm:ss"))

        Dim diff As TimeSpan = TEOvertimeEnd.EditValue - TEOvertimeStart.EditValue

        TETotalHours.EditValue = (Math.Floor(diff.TotalHours) - TEOvertimeBreak.EditValue).ToString
    End Sub

    Private Sub TEOvertimeStart_EditValueChanged(sender As Object, e As EventArgs) Handles TEOvertimeStart.EditValueChanged
        calculateTotalHours()
    End Sub

    Private Sub TEOvertimeEnd_EditValueChanged(sender As Object, e As EventArgs) Handles TEOvertimeEnd.EditValueChanged
        calculateTotalHours()
    End Sub

    Private Sub TEOvertimeBreak_EditValueChanged(sender As Object, e As EventArgs) Handles TEOvertimeBreak.EditValueChanged
        calculateTotalHours()
    End Sub

    Sub calculateActualTotalHours()
        GVEmployee.CloseEditor()
        GVEmployee.UpdateCurrentRow()

        For i = 0 To GVEmployee.RowCount - 1
            If GVEmployee.IsValidRowHandle(i) Then
                If Not GVEmployee.GetRowCellValue(i, "end_work").ToString = "" And Not GVEmployee.GetRowCellValue(i, "start_work").ToString = "" Then
                    Dim diff As TimeSpan = Date.Parse(GVEmployee.GetRowCellValue(i, "end_work").ToString) - Date.Parse(GVEmployee.GetRowCellValue(i, "start_work").ToString)

                    GVEmployee.SetRowCellValue(i, "total_hours", (Math.Floor(diff.TotalHours) - GVEmployee.GetRowCellValue(i, "break_hours")))
                Else
                    GVEmployee.SetRowCellValue(i, "total_hours", "0.0")
                End If
            End If
        Next

        GVEmployee.RefreshData()
    End Sub

    Private Sub RITEAttendance_EditValueChanged(sender As Object, e As EventArgs) Handles RITEAttendance.EditValueChanged
        calculateActualTotalHours()
    End Sub

    Private Sub RITEBreakHours_EditValueChanged(sender As Object, e As EventArgs) Handles RITEBreakHours.EditValueChanged
        calculateActualTotalHours()
    End Sub

    Private Sub FormEmpOvertimeDet_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub SBClose_Click(sender As Object, e As EventArgs) Handles SBClose.Click
        Close()
    End Sub

    Private Sub SBEmpAdd_Click(sender As Object, e As EventArgs) Handles SBEmpAdd.Click
        FormEmpOvertimePick.is_hrd = is_hrd

        FormEmpOvertimePick.ShowDialog()
    End Sub

    Private Sub SBEmpDelete_Click(sender As Object, e As EventArgs) Handles SBEmpDelete.Click
        GVEmployee.DeleteSelectedRows()
    End Sub

    Private Sub SBSave_Click(sender As Object, e As EventArgs) Handles SBSave.Click
        MEOvertimeNote_Validating(MEOvertimeNote, New System.ComponentModel.CancelEventArgs)

        If TEOvertimeStart.EditValue > TEOvertimeEnd.EditValue Then
            errorCustom("Start time must be earlier than end time.")
        ElseIf TETotalHours.EditValue < 0 Then
            errorCustom("Break time greater than work time.")
        ElseIf GVEmployee.RowCount <= 0 Then
            errorCustom("No employee selected.")
        ElseIf Not formIsValidInPanel(ErrorProvider, PanelControl4) Then
            errorCustom("Please check your input.")
        Else
            Dim confirm As DialogResult

            confirm = DevExpress.XtraEditors.XtraMessageBox.Show("All data will be locked. Are you sure want to submit ?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)

            If confirm = Windows.Forms.DialogResult.Yes Then
                Dim query As String = ""

                Dim ot_date As String = Date.Parse(DEOvertimeDate.EditValue.ToString).ToString("yyyy-MM-dd")
                Dim ot_start_time As String = Date.Parse(TEOvertimeStart.EditValue.ToString).ToString("HH:mm:ss")
                Dim ot_end_time As String = Date.Parse(TEOvertimeEnd.EditValue.ToString).ToString("HH:mm:ss")

                query = "INSERT INTO tb_ot (id_ot_type, ot_date, ot_start_time, ot_end_time, ot_break, ot_note, id_payroll, id_report_status, number, created_by, created_at) VALUES (" + LUEOvertimeType.EditValue.ToString + ", '" + ot_date + "', '" + ot_start_time + "', '" + ot_end_time + "', " + decimalSQL(TEOvertimeBreak.EditValue.ToString) + ", '" + addSlashes(MEOvertimeNote.Text.ToString) + "', " + SLUEPayrollPeriod.EditValue.ToString + ", 1, '0', " + id_employee_user + ", NOW()); SELECT LAST_INSERT_ID();"

                id = execute_query(query, 0, True, "", "", "", "")

                GVEmployee.ExpandAllGroups()

                For i = 0 To GVEmployee.RowCount - 1
                    If GVEmployee.IsValidRowHandle(i) Then
                        query = "INSERT INTO tb_ot_det (id_ot, id_employee, id_departement, employee_position, id_employee_level, conversion_type) VALUES (" + id + ", " + GVEmployee.GetRowCellValue(i, "id_employee").ToString + ", " + GVEmployee.GetRowCellValue(i, "id_departement").ToString + ", '" + addSlashes(GVEmployee.GetRowCellValue(i, "employee_position").ToString) + "', " + GVEmployee.GetRowCellValue(i, "id_employee_level").ToString + ", " + GVEmployee.GetRowCellValue(i, "conversion_type").ToString + ")"

                        execute_non_query(query, True, "", "", "", "")
                    End If
                Next

                submit_who_prepared("184", id, id_user)

                execute_non_query("CALL gen_number(" + id + ", '184')", True, "", "", "", "")

                ' load overtime
                FormEmpOvertime.DEStart.EditValue = Date.Parse(DEOvertimeDate.EditValue.ToString)
                FormEmpOvertime.DEUntil.EditValue = Date.Parse(DEOvertimeDate.EditValue.ToString)

                FormEmpOvertime.load_overtime("ot_date")

                Close()
            End If
        End If
    End Sub

    Private Sub MEOvertimeNote_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles MEOvertimeNote.Validating
        If MEOvertimeNote.Text.ToString = "" Then
            ErrorProvider.SetError(MEOvertimeNote, "Please fill out this field.")
        Else
            ErrorProvider.SetError(MEOvertimeNote, "")
        End If
    End Sub

    Private Sub SBMark_Click(sender As Object, e As EventArgs) Handles SBMark.Click
        Cursor = Cursors.WaitCursor

        FormReportMark.report_mark_type = If(is_check = "-1", "184", "187")
        FormReportMark.id_report = id

        FormReportMark.ShowDialog()

        Cursor = Cursors.Default
    End Sub

    Private Sub SBPrint_Click(sender As Object, e As EventArgs) Handles SBPrint.Click
        Dim query As String = "
            SELECt ot.id_report_status
            FROM tb_ot AS ot
            WHERE ot.id_ot = " + id + "
        "

        Dim report_status As String = execute_query(query, 0, True, "", "", "", "")

        Dim Report As New ReportEmpOvertime()

        Report.id = id
        Report.data = GCEmployee.DataSource
        Report.id_pre = If(report_status = "6", "-1", "1")

        Report.XLNumber.Text = TENumber.Text.ToString
        Report.XLOTtype.Text = LUEOvertimeType.Text.ToString
        Report.XLOTDate.Text = DEOvertimeDate.Text.ToString
        Report.XLOTTime.Text = TEOvertimeStart.Text.ToString + " - " + TEOvertimeEnd.Text.ToString + " (" + TETotalHours.Text.ToString + " Hours)"
        Report.XLPayrollPeriod.Text = SLUEPayrollPeriod.Text.ToString
        Report.XLCreatedAt.Text = TECreatedBy.Text.ToString
        Report.XLCreatedBy.Text = TECreatedAt.Text.ToString
        Report.XLOTNote.Text = MEOvertimeNote.Text.ToString

        Dim Tool As DevExpress.XtraReports.UI.ReportPrintTool = New DevExpress.XtraReports.UI.ReportPrintTool(Report)
        Tool.ShowPreviewDialog()
    End Sub

    Private clone As DataView = Nothing

    Private Sub GVEmployee_ShownEditor(sender As Object, e As EventArgs) Handles GVEmployee.ShownEditor
        Dim view As DevExpress.XtraGrid.Views.Grid.GridView = CType(sender, DevExpress.XtraGrid.Views.Grid.GridView)

        If view.FocusedColumn.FieldName = "conversion_type" AndAlso TypeOf view.ActiveEditor Is DevExpress.XtraEditors.SearchLookUpEdit Then
            Dim edit As DevExpress.XtraEditors.SearchLookUpEdit
            Dim table As DataTable
            Dim row As DataRow

            edit = CType(view.ActiveEditor, DevExpress.XtraEditors.SearchLookUpEdit)

            Try
                table = CType(edit.Properties.DataSource, DataTable)
            Catch ex As Exception
                table = CType(edit.Properties.DataSource, DataView).Table
            End Try

            clone = New DataView(table)

            row = view.GetDataRow(view.FocusedRowHandle)

            If view.GetFocusedRowCellValue("only_dp").ToString = "yes" Then
                clone.RowFilter = "[id_type] = 2"
            Else
                clone.RowFilter = ""
            End If

            edit.Properties.DataSource = clone
        End If
    End Sub

    Private Sub DEOvertimeDate_EditValueChanged(sender As Object, e As EventArgs) Handles DEOvertimeDate.EditValueChanged
        If Not DEOvertimeDate.EditValue Is Nothing Then
            Dim data As DataTable = execute_query("SELECT id_payroll, DATE_FORMAT(ot_periode_start, '%d %M %Y') AS ot_periode_start, DATE_FORMAT(ot_periode_end, '%d %M %Y') AS ot_periode_end FROM tb_emp_payroll WHERE id_payroll_type = 1", -1, True, "", "", "", "")

            For i = 0 To data.Rows.Count - 1
                If Date.Parse(DEOvertimeDate.Text.ToString + " 12:00 AM") >= Date.Parse(data.Rows(i)("ot_periode_start")) And Date.Parse(DEOvertimeDate.Text.ToString + " 12:00 AM") <= Date.Parse(data.Rows(i)("ot_periode_end")) Then
                    SLUEPayrollPeriod.EditValue = data.Rows(i)("id_payroll")

                    Exit For
                End If
            Next
        End If
    End Sub

    Private Sub SBCheck_Click(sender As Object, e As EventArgs) Handles SBCheck.Click
        Dim confirm As DialogResult

        ' Validation
        Dim errorTotal As String = ""

        For i = 0 To GVEmployee.RowCount - 1
            If GVEmployee.IsValidRowHandle(i) Then
                If GVEmployee.GetRowCellValue(i, "valid").ToString = "yes" Then
                    If GVEmployee.GetRowCellValue(i, "total_hours") <= 0 Then
                        errorTotal = "Make sure if that valid, total (hours) is greater than 0."
                    End If
                End If
            End If
        Next

        If errorTotal = "" Then
            confirm = DevExpress.XtraEditors.XtraMessageBox.Show("All data will be locked. Are you sure want to submit ?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)

            If confirm = Windows.Forms.DialogResult.Yes Then
                Dim query As String = "
                    UPDATE tb_ot SET id_payroll = '" + SLUEPayrollPeriod.EditValue.ToString + "', id_check_status = 1, hrd_check = 1 WHERE id_ot = " + id + "
                "

                execute_non_query(query, True, "", "", "", "")

                GVEmployee.ExpandAllGroups()

                For i = 0 To GVEmployee.RowCount - 1
                    If GVEmployee.IsValidRowHandle(i) Then
                        Dim conversion_type As String = GVEmployee.GetRowCellValue(i, "conversion_type").ToString
                        Dim start_work As String = "NULL"
                        Dim end_work As String = "NULL"
                        Dim break_hours As String = GVEmployee.GetRowCellValue(i, "break_hours").ToString

                        If Not GVEmployee.GetRowCellValue(i, "start_work").ToString = "" Then
                            start_work = "'" + Date.Parse(GVEmployee.GetRowCellValue(i, "start_work").ToString).ToString("HH:mm:ss") + "'"
                        End If

                        If Not GVEmployee.GetRowCellValue(i, "end_work").ToString = "" Then
                            end_work = "'" + Date.Parse(GVEmployee.GetRowCellValue(i, "end_work").ToString).ToString("HH:mm:ss") + "'"
                        End If

                        Dim is_valid As String = If(GVEmployee.GetRowCellValue(i, "valid").ToString = "yes", "1", "2")

                        query = "UPDATE tb_ot_det SET conversion_type = '" + conversion_type + "', start_work = " + start_work + ", end_work = " + end_work + ", break_hours = " + decimalSQL(break_hours) + ", is_valid = " + is_valid + " WHERE id_ot = " + id + " AND id_employee = " + GVEmployee.GetRowCellValue(i, "id_employee").ToString + ""

                        execute_non_query(query, True, "", "", "", "")
                    End If
                Next

                submit_who_prepared("187", id, id_user)

                ' load overtime
                FormEmpOvertime.DEStart.EditValue = Date.Parse(DEOvertimeDate.EditValue.ToString)
                FormEmpOvertime.DEUntil.EditValue = Date.Parse(DEOvertimeDate.EditValue.ToString)

                FormEmpOvertime.load_overtime("ot_date")

                Close()
            End If
        Else
            errorCustom(errorTotal)
        End If
    End Sub

    Sub updateChanges()
        Dim query As String = ""

        query = "
            SELECT ot_det.conversion_type, departement.is_store, ot.id_payroll, payroll.periode_end, ot_det.id_employee, ot.id_ot_type, ot.ot_date, ot_det.start_work AS ot_start, ot_det.end_work AS ot_end, ot_det.break_hours AS total_break, (TIMESTAMPDIFF(HOUR, ot_det.start_work, ot_det.end_work) - ot_det.break_hours) AS total_hour, 0 AS total_point, (IF((SELECT id_schedule_type FROM tb_emp_schedule WHERE id_employee = ot_det.id_employee AND DATE = ot.ot_date) = 1, 2, 1)) AS is_day_off, ot_type.ot_point_wages AS wages_per_point, ot.ot_note AS note, ot_det.id_ot_det
            FROM tb_ot_det AS ot_det
            LEFT JOIN tb_ot AS ot ON ot_det.id_ot = ot.id_ot
            LEFT JOIN tb_lookup_ot_type AS ot_type ON ot.id_ot_type = ot_type.id_ot_type
            LEFT JOIN tb_m_departement AS departement ON ot_det.id_departement = departement.id_departement
            LEFT JOIN tb_emp_payroll AS payroll ON ot.id_payroll = payroll.id_payroll
            WHERE ot.id_ot = " + id + " AND ot_det.is_valid = 1
        "

        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")

        For i = 0 To data.Rows.Count - 1
            Dim conversion_type As String = data.Rows(i)("conversion_type").ToString
            Dim is_store As String = data.Rows(i)("conversion_type").ToString
            Dim id_payroll As String = data.Rows(i)("id_payroll").ToString
            Dim id_employee As String = data.Rows(i)("id_employee").ToString
            Dim id_ot_type As String = data.Rows(i)("id_ot_type").ToString
            Dim ot_date As String = Date.Parse(data.Rows(i)("ot_date").ToString).ToString("yyyy-MM-dd")
            Dim ot_start As String = data.Rows(i)("ot_start").ToString
            Dim ot_end As String = data.Rows(i)("ot_end").ToString
            Dim total_break As String = data.Rows(i)("total_break").ToString
            Dim total_hour As String = data.Rows(i)("total_hour").ToString
            Dim is_day_off As String = data.Rows(i)("is_day_off").ToString
            Dim total_point As String = calc_point(Decimal.Parse(total_hour), is_day_off, is_store).ToString
            Dim wages_per_point As String = data.Rows(i)("wages_per_point").ToString
            Dim note As String = data.Rows(i)("note").ToString
            Dim id_ot_det As String = data.Rows(i)("id_ot_det").ToString
            Dim qty As String = Math.Round((Decimal.Parse(total_hour) * 60)).ToString
            Dim date_expired As String = Date.Parse(data.Rows(i)("periode_end").ToString).AddMonths(6).ToString("yyyy-MM-dd")

            If conversion_type = "1" Then
                ' overtime
                query = "INSERT INTO tb_emp_payroll_ot (id_payroll, id_employee, id_ot_type, ot_start, ot_end, total_break, total_hour, total_point, is_day_off, wages_per_point, note, id_ot_det) VALUES (" + id_payroll + ", " + id_employee + ", " + id_ot_type + ", '" + ot_date + " " + ot_start + "', '" + ot_date + " " + ot_end + "', " + decimalSQL(total_break) + ", " + decimalSQL(total_hour) + ", " + decimalSQL(total_point) + ", " + is_day_off + ", '" + decimalSQL(wages_per_point) + "', '" + note + "', " + id_ot_det + ")"

                execute_non_query(query, True, "", "", "", "")
            Else
                ' dp
                query = "INSERT INTO tb_emp_stock_leave (id_ot_det, id_emp, qty, plus_minus, date_leave, date_expired, is_process_exp, note, type) VALUES (" + id_ot_det + ", " + id_employee + ", " + qty + ", 1, NOW(), '" + date_expired + "', 1, '" + note + "', 2)"

                execute_non_query(query, True, "", "", "", "")
            End If
        Next
    End Sub

    Function calc_point(ByVal tot_hour As Decimal, ByVal is_day_off As String, ByVal is_store As String) As Decimal
        Dim tot_point As Decimal = 0.0

        Try
            If is_day_off = "1" Then
                'hari libur
                If is_store = "1" Then 'toko
                    tot_point = If(tot_hour > 8, ((tot_hour - 8) * 4), 0) + If(tot_hour > 7, ((tot_hour - If(tot_hour > 7, (tot_hour - 8), 0) - 7) * 3), 0) + (tot_hour - If(tot_hour > 7, (tot_hour - 7), 0)) * 2
                Else 'office
                    tot_point = If(tot_hour > 9, ((tot_hour - 9) * 4), 0) + If(tot_hour > 8, ((tot_hour - If(tot_hour > 9, (tot_hour - 9), 0) - 8) * 3), 0) + (tot_hour - If(tot_hour > 8, (tot_hour - 8), 0)) * 2
                End If
            Else
                'hari kerja
                tot_point = If(tot_hour > 1, ((tot_hour - 1) * 2), 0) + ((tot_hour - If(tot_hour > 1, (tot_hour - 1), 0)) * 1.5)
            End If
        Catch ex As Exception
        End Try

        Return tot_point
    End Function
End Class