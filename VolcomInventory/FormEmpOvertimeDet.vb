﻿Public Class FormEmpOvertimeDet
    Public is_hrd As String = "-1"
    Public id As String = "0"

    Public id_ot_det As String = "0"

    Private is_point_ho As String = "0"

    Private ot_min_spv As Integer = get_opt_emp_field("ot_min_spv")

    Private Sub FormEmpOvertimeDet_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If is_hrd = "-1" Then
            Text = "Propose Overtime Detail"
        Else
            Text = "Overtime Management Detail"
        End If

        form_load()
    End Sub

    Sub form_load()
        ' default
        viewLookupQuery(LUEOvertimeType, "SELECT id_ot_type, CONCAT(IF(is_event = 1, 'Event ', ''), ot_type) AS ot_type FROM tb_lookup_ot_type", 0, "ot_type", "id_ot_type")
        viewSearchLookupRepositoryQuery(RISLUEType, "SELECT id_ot_conversion AS id_type, conversion_type AS type, to_salary, to_dp FROM tb_lookup_ot_conversion", 0, "type", "id_type")
        viewLookupQuery(LEDepartement, "SELECT * FROM tb_m_departement", 0, "departement", "id_departement")

        LEDepartement.ItemIndex = LEDepartement.Properties.GetDataSourceRowIndex("id_departement", id_departement_user)
        TECreatedBy.EditValue = get_emp(id_employee_user, "2")
        DECreatedAt.EditValue = Now

        generate_memo_format()

        load_default()

        'load database
        If Not id = "0" Then
            Dim query_ot As String = "
                SELECT ot.id_ot, ot.id_ot_type, ot_type.ot_type, ot.id_departement, departement.departement, ot.number, LEFT(ot.memo_number, 3) AS memo_number, RIGHT(ot.memo_number, LENGTH(ot.memo_number) - 3) AS memo_number_format, ot.id_report_status, report_status.report_status, employee.employee_name AS created_by, ot.created_at
                FROM tb_ot AS ot
                LEFT JOIN tb_lookup_ot_type AS ot_type ON ot.id_ot_type = ot_type.id_ot_type
                LEFT JOIN tb_m_departement AS departement ON ot.id_departement = departement.id_departement
                LEFT JOIN tb_lookup_report_status AS report_status ON ot.id_report_status = report_status.id_report_status
                LEFT JOIN tb_m_employee AS employee ON ot.created_by = employee.id_employee
                WHERE ot.id_ot = " + id + "
            "

            Dim data_ot As DataTable = execute_query(query_ot, -1, True, "", "", "", "")

            TENumber.EditValue = data_ot.Rows(0)("number").ToString
            LUEOvertimeType.ItemIndex = LUEOvertimeType.Properties.GetDataSourceRowIndex("id_ot_type", data_ot.Rows(0)("id_ot_type").ToString)
            LEDepartement.ItemIndex = LEDepartement.Properties.GetDataSourceRowIndex("id_departement", data_ot.Rows(0)("id_departement").ToString)
            TECreatedBy.EditValue = data_ot.Rows(0)("created_by").ToString
            DECreatedAt.EditValue = data_ot.Rows(0)("created_at").ToString
            TEReportStatus.EditValue = data_ot.Rows(0)("report_status").ToString
            TEMemoNumber.EditValue = data_ot.Rows(0)("memo_number").ToString
            TEMemoFormat.EditValue = data_ot.Rows(0)("memo_number_format").ToString

            ' load employee
            ' column
            Dim query_ot_det As String = "
                SELECT ot_det.id_employee, ot_det.id_departement, ot_det.id_departement_sub, departement.departement, DATE_FORMAT(ot_det.ot_date, '%d %M %Y') AS ot_date, employee.employee_code, employee.employee_name, ot_det.employee_position, ot_det.id_employee_status, employee_status.employee_status, ot_det.to_salary, ot_det.conversion_type, IF(((SELECT id_schedule_type FROM tb_emp_schedule WHERE id_employee = ot_det.id_employee AND date = ot_det.ot_date) = 1) AND ((SELECT id_emp_holiday FROM tb_emp_holiday WHERE emp_holiday_date = ot_det.ot_date AND id_religion IN (0, IF(departement.is_store = 1, 0, employee.id_religion))) IS NULL), 2, 1) AS is_day_off, ot_det.ot_consumption, DATE_FORMAT(ot_det.ot_start_time, '%d %M %Y %H:%i:%s') AS ot_start_time, DATE_FORMAT(ot_det.ot_end_time, '%d %M %Y %H:%i:%s') AS ot_end_time, ot_det.ot_break, ROUND((TIMESTAMPDIFF(MINUTE, ot_det.ot_start_time, ot_det.ot_end_time) / 60) - ot_det.ot_break, 1) AS ot_total_hours, ot_det.ot_note
                FROM tb_ot_det AS ot_det
                LEFT JOIN tb_ot AS ot ON ot_det.id_ot = ot.id_ot
                LEFT JOIN tb_m_employee AS employee ON ot_det.id_employee = employee.id_employee
                LEFT JOIN tb_m_departement AS departement ON ot_det.id_departement = departement.id_departement
                LEFT JOIN tb_lookup_employee_status AS employee_status ON ot_det.id_employee_status = employee_status.id_employee_status
                WHERE ot_det.id_ot = " + id + "
                ORDER BY ot_det.ot_date ASC, departement.departement ASC, employee.id_employee_level ASC, employee.employee_code ASC
            "

            Dim data_ot_det As DataTable = execute_query(query_ot_det, -1, True, "", "", "", "")

            GCEmployee.DataSource = data_ot_det

            GVEmployee.BestFitColumns()
        End If

        ' permission
        If Not id = "0" Then
            LUEOvertimeType.ReadOnly = True

            RISLUEType.ReadOnly = True

            SBEmpDelete.Enabled = False
            SBEmpAdd.Enabled = False
            SBMark.Enabled = True
            SBPrint.Enabled = True
            SBSave.Enabled = False

            LEDepartement.Properties.ReadOnly = True

            TEMemoNumber.ReadOnly = True
        Else
            If is_hrd = "-1" Then
                LEDepartement.Properties.ReadOnly = True
            End If
        End If
    End Sub

    Sub load_default()
        Dim data As DataTable = New DataTable

        data.Columns.Add("id_employee", GetType(String))
        data.Columns.Add("id_departement", GetType(String))
        data.Columns.Add("id_departement_sub", GetType(String))
        data.Columns.Add("departement", GetType(String))
        data.Columns.Add("ot_date", GetType(String))
        data.Columns.Add("employee_code", GetType(String))
        data.Columns.Add("employee_name", GetType(String))
        data.Columns.Add("employee_position", GetType(String))
        data.Columns.Add("id_employee_status", GetType(String))
        data.Columns.Add("employee_status", GetType(String))
        data.Columns.Add("to_salary", GetType(String))
        data.Columns.Add("conversion_type", GetType(String))
        data.Columns.Add("is_day_off", GetType(String))
        data.Columns.Add("ot_consumption", GetType(Decimal))
        data.Columns.Add("ot_start_time", GetType(DateTime))
        data.Columns.Add("ot_end_time", GetType(DateTime))
        data.Columns.Add("ot_break", GetType(Decimal))
        data.Columns.Add("ot_total_hours", GetType(Decimal))
        data.Columns.Add("ot_note", GetType(String))

        GCEmployee.DataSource = data
    End Sub

    Private Sub FormEmpOvertimeDet_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        If FormEmpOvertime.last_click = "ot_date" Then
            FormEmpOvertime.load_overtime("ot_date")
        ElseIf FormEmpOvertime.last_click = "created_at" Then
            FormEmpOvertime.load_overtime("created_at")
        ElseIf FormEmpOvertime.last_click = "new" Then
            FormEmpOvertime.DEStart.EditValue = Date.Parse(Now.Year.ToString + "-" + Now.Month.ToString + "-1")
            FormEmpOvertime.DEUntil.EditValue = Date.Parse(Now.Year.ToString + "-" + Now.Month.ToString + "-" + Date.DaysInMonth(Now.Year, Now.Month).ToString)

            FormEmpOvertime.load_overtime("created_at")
        End If

        If FormEmpOvertime.XTCPropose.SelectedTabPage.Name = "XTPByEmployee" Then
            If Not id_ot_det = "0" Then
                FormEmpOvertime.GVProposeEmployee.FocusedRowHandle = find_row(FormEmpOvertime.GVProposeEmployee, "id_ot_det", id_ot_det)
            End If
        Else
            If Not id = "0" Then
                FormEmpOvertime.GVOvertime.FocusedRowHandle = find_row(FormEmpOvertime.GVOvertime, "id_ot", id)
            End If
        End If

        Dispose()
    End Sub

    Private Sub SBClose_Click(sender As Object, e As EventArgs) Handles SBClose.Click
        Close()
    End Sub

    Private Sub SBEmpAdd_Click(sender As Object, e As EventArgs) Handles SBEmpAdd.Click
        FormEmpOvertimeDate.is_hrd = is_hrd

        FormEmpOvertimeDate.ShowDialog()
    End Sub

    Private Sub SBEmpDelete_Click(sender As Object, e As EventArgs) Handles SBEmpDelete.Click
        GVEmployee.DeleteSelectedRows()
    End Sub

    Private Sub SBSave_Click(sender As Object, e As EventArgs) Handles SBSave.Click
        TEMemoNumber_Validating(TEMemoNumber, New System.ComponentModel.CancelEventArgs)

        If GVEmployee.RowCount <= 0 Then
            errorCustom("No employee selected.")
        ElseIf Not formIsValidInPanel(ErrorProvider, PCMemoNumber) Then
            errorCustom("Please check your input.")
        Else
            Dim confirm As DialogResult

            confirm = DevExpress.XtraEditors.XtraMessageBox.Show("All data will be locked. Are you sure want to submit ?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)

            If confirm = Windows.Forms.DialogResult.Yes Then
                Dim query As String = ""

                Dim memo_number As String = If(PCMemoNumber.Visible = True, TEMemoNumber.EditValue.ToString + TEMemoFormat.EditValue.ToString, "0")

                query = "INSERT INTO tb_ot (id_ot_type, id_departement, memo_number, id_report_status, created_by, created_at) VALUES (" + LUEOvertimeType.EditValue.ToString + ", " + LEDepartement.EditValue.ToString + ", '" + addSlashes(memo_number) + "', 1, " + id_employee_user + ", NOW()); SELECT LAST_INSERT_ID();"

                id = execute_query(query, 0, True, "", "", "", "")

                GVEmployee.ExpandAllGroups()

                For i = 0 To GVEmployee.RowCount - 1
                    If GVEmployee.IsValidRowHandle(i) Then
                        Dim id_employee As String = GVEmployee.GetRowCellValue(i, "id_employee").ToString
                        Dim id_departement As String = GVEmployee.GetRowCellValue(i, "id_departement").ToString
                        Dim id_departement_sub As String = GVEmployee.GetRowCellValue(i, "id_departement_sub").ToString
                        Dim employee_position As String = GVEmployee.GetRowCellValue(i, "employee_position").ToString
                        Dim id_employee_status As String = GVEmployee.GetRowCellValue(i, "id_employee_status").ToString
                        Dim to_salary As String = GVEmployee.GetRowCellValue(i, "to_salary").ToString
                        Dim conversion_type As String = GVEmployee.GetRowCellValue(i, "conversion_type").ToString
                        Dim ot_consumption As String = GVEmployee.GetRowCellValue(i, "ot_consumption").ToString
                        Dim ot_date As String = Date.Parse(GVEmployee.GetRowCellValue(i, "ot_date").ToString).ToString("yyyy-MM-dd")
                        Dim ot_start_time As String = Date.Parse(GVEmployee.GetRowCellValue(i, "ot_start_time").ToString).ToString("yyyy-MM-dd HH:mm:ss")
                        Dim ot_end_time As String = Date.Parse(GVEmployee.GetRowCellValue(i, "ot_end_time").ToString).ToString("yyyy-MM-dd HH:mm:ss")
                        Dim ot_break As String = GVEmployee.GetRowCellValue(i, "ot_break").ToString
                        Dim ot_note As String = GVEmployee.GetRowCellValue(i, "ot_note").ToString

                        query = "INSERT INTO tb_ot_det (id_ot, id_employee, id_departement, id_departement_sub, employee_position, id_employee_status, to_salary, conversion_type, ot_consumption, ot_date, ot_start_time, ot_end_time, ot_break, ot_note) VALUES (" + id + ", " + id_employee + ", " + id_departement + ", " + id_departement_sub + ", '" + addSlashes(employee_position) + "', " + id_employee_status + ", " + to_salary + ", " + conversion_type + ", " + decimalSQL(ot_consumption) + ", '" + ot_date + "', '" + ot_start_time + "', '" + ot_end_time + "', " + decimalSQL(ot_break) + ", '" + addSlashes(ot_note) + "')"

                        execute_non_query(query, True, "", "", "", "")
                    End If
                Next

                execute_non_query("CALL gen_number(" + id + ", '184')", True, "", "", "", "")

                Dim is_user_head As Boolean = If(execute_query("SELECT id_user_head FROM tb_m_departement WHERE id_departement = " + LEDepartement.EditValue.ToString, 0, True, "", "", "", "") = id_user, True, False)

                'approval
                If LEDepartement.EditValue.ToString = "8" Or id_departement_user = "8" Then
                    'departement hrd
                    If is_user_head Then
                        'manager hrd submit
                        submit_who_prepared("214", id, id_user)
                        execute_non_query("UPDATE tb_ot SET report_mark_type = 214 WHERE id_ot = " + id, True, "", "", "", "")
                    Else
                        'admin hrd submit
                        submit_who_prepared("213", id, id_user)
                        execute_non_query("UPDATE tb_ot SET report_mark_type = 213 WHERE id_ot = " + id, True, "", "", "", "")
                    End If
                Else
                    'other departement
                    If is_user_head Then
                        'manager submit
                        submit_who_prepared("213", id, id_user)
                        execute_non_query("UPDATE tb_ot SET report_mark_type = 213 WHERE id_ot = " + id, True, "", "", "", "")
                    Else
                        'admin submit
                        submit_who_prepared("184", id, id_user)
                        execute_non_query("UPDATE tb_ot SET report_mark_type = 184 WHERE id_ot = " + id, True, "", "", "", "")
                    End If
                End If

                FormEmpOvertime.last_click = "new"

                Close()
            End If
        End If
    End Sub

    Private Sub SBMark_Click(sender As Object, e As EventArgs) Handles SBMark.Click
        Cursor = Cursors.WaitCursor

        FormReportMark.report_mark_type = execute_query("SELECT report_mark_type FROM tb_ot WHERE id_ot = " + id, 0, True, "", "", "", "")
        FormReportMark.id_report = id

        FormReportMark.ShowDialog()

        Cursor = Cursors.Default
    End Sub

    Private Sub SBPrint_Click(sender As Object, e As EventArgs) Handles SBPrint.Click
        Dim id_report_status As String = execute_query("SELECT id_report_status FROM tb_ot WHERE id_ot = " + id, 0, True, "", "", "", "")

        'overtime
        Dim ReportOvertime As New ReportEmpOvertime()

        ReportOvertime.id = id
        ReportOvertime.data = GCEmployee.DataSource
        ReportOvertime.id_pre = If(id_report_status = "6", "-1", "1")

        ReportOvertime.XLNumber.Text = TENumber.Text.ToString
        ReportOvertime.XLOTtype.Text = LUEOvertimeType.Text.ToString
        ReportOvertime.XLCreatedAt.Text = TECreatedBy.Text.ToString
        ReportOvertime.XLCreatedBy.Text = DECreatedAt.Text.ToString

        ReportOvertime.GVEmployee.BestFitColumns()

        ReportOvertime.CreateDocument()

        'memo
        'date
        Dim query_date As String = "
            SELECT IFNULL(GROUP_CONCAT(DISTINCT tb.ot_date SEPARATOR ', '), '') AS ot_date
            FROM (
                SELECT CONCAT_WS(' - ', DATE_FORMAT(MIN(ot_det.ot_date), '%d %M %Y'), CASE WHEN MAX(ot_det.ot_date) > MIN(ot_det.ot_date) THEN DATE_FORMAT(MAX(ot_det.ot_date), '%d %M %Y') END) AS ot_date
                FROM (
                    SELECT
                        CASE WHEN ((ot_date = @last_ci + INTERVAL 1 DAY) OR (ot_date = @last_ci)) THEN @n ELSE @n := @n + 1 END AS group_date,
                        @last_ci := ot_date AS ot_date
                    FROM
                        tb_ot_det, (SELECT @n := 0) i, (SELECT @last_ci := 0) j
                    WHERE tb_ot_det.id_ot = " + id + " AND ROUND((TIMESTAMPDIFF(MINUTE, tb_ot_det.ot_start_time, tb_ot_det.ot_end_time) / 60) - tb_ot_det.ot_break, 1) >= (SELECT ot_memo_employee FROM tb_opt_emp LIMIT 1)
                    ORDER BY ot_date
                ) ot_det
                GROUP BY group_date
            ) tb
        "

        Dim ot_date As String = execute_query(query_date, 0, True, "", "", "", "")

        'employee
        Dim data_employee As DataTable = execute_query("
            SELECT id_employee, employee_name, employee_position FROM tb_m_employee WHERE id_employee = (SELECT ot_memo_to FROM tb_opt_emp LIMIT 1)
            UNION ALL
            SELECT id_employee, employee_name, employee_position FROM tb_m_employee WHERE id_employee = (SELECT ot_memo_cc1 FROM tb_opt_emp LIMIT 1)
            UNION ALL
            SELECT id_employee, employee_name, employee_position FROM tb_m_employee WHERE id_employee = (SELECT ot_memo_cc2 FROM tb_opt_emp LIMIT 1)
            UNION ALL
            SELECT id_employee, employee_name, employee_position FROM tb_m_employee WHERE id_employee = (SELECT usr.id_employee FROM tb_m_departement AS dep LEFT JOIN tb_m_user AS usr ON dep.id_user_head = usr.id_user WHERE dep.id_departement = 8)
            UNION ALL
            SELECT id_employee, employee_name, employee_position FROM tb_m_employee WHERE id_employee = (SELECT usr.id_employee FROM tb_m_departement AS dep LEFT JOIN tb_m_user AS usr ON dep.id_user_head = usr.id_user WHERE dep.id_departement = " + LEDepartement.EditValue.ToString + ")
        ", -1, True, "", "", "", "")

        Dim ReportMemo As New ReportEmpOvertimeMemo()

        ReportMemo.id = id
        ReportMemo.id_pre = If(id_report_status = "6", "-1", "1")

        ReportMemo.XrLabel2.Text = TEMemoNumber.EditValue.ToString + TEMemoFormat.EditValue.ToString
        ReportMemo.XLTo.Text = data_employee.Rows(0)("employee_name").ToString
        ReportMemo.XLToPosition.Text = "- " + data_employee.Rows(0)("employee_position").ToString

        ReportMemo.XLCC1.Text = data_employee.Rows(1)("employee_name").ToString
        ReportMemo.XLCC1Position.Text = "- " + data_employee.Rows(1)("employee_position").ToString

        ReportMemo.XLCC2.Text = data_employee.Rows(2)("employee_name").ToString
        ReportMemo.XLCC2Position.Text = "- " + data_employee.Rows(2)("employee_position").ToString

        ReportMemo.XLCC3.Text = data_employee.Rows(3)("employee_name").ToString
        ReportMemo.XLCC3Position.Text = "- " + data_employee.Rows(3)("employee_position").ToString

        ReportMemo.XLFrom.Text = data_employee.Rows(4)("employee_name").ToString
        ReportMemo.XLFromPosition.Text = "- " + data_employee.Rows(4)("employee_position").ToString

        ReportMemo.XLHal.Text = "Budget Konsumsi Lembur " + LEDepartement.Text.ToString + " " + ot_date

        If data_employee.Rows(3)("id_employee").ToString = data_employee.Rows(4)("id_employee").ToString Then
            ReportMemo.XLCC3.Visible = False
            ReportMemo.XLCC3Dot.Visible = False
            ReportMemo.XLCC3Position.Visible = False

            ReportMemo.XPFrom.LocationF = New PointF(0, 99)
            ReportMemo.SubBand1.HeightF = 153
        End If

        ReportMemo.XLText.Text = ReportMemo.XLText.Text.Replace("[departement]", LEDepartement.Text.ToString)
        ReportMemo.XLText.Text = ReportMemo.XLText.Text.Replace("[ot_date]", ot_date)
        ReportMemo.XLText.Text = ReportMemo.XLText.Text.Replace("[total_consumption]", Format(GCConsumption.SummaryItem.SummaryValue, "##,##0"))

        ReportMemo.CreateDocument()

        'combine
        Dim list As List(Of DevExpress.XtraPrinting.Page) = New List(Of DevExpress.XtraPrinting.Page)

        For i = 0 To ReportOvertime.Pages.Count - 1
            list.Add(ReportOvertime.Pages(i))
        Next

        If PCMemoNumber.Visible = True Then
            For i = 0 To ReportMemo.Pages.Count - 1
                list.Add(ReportMemo.Pages(i))
            Next
        End If

        ReportOvertime.Pages.AddRange(list)

        Dim Tool As DevExpress.XtraReports.UI.ReportPrintTool = New DevExpress.XtraReports.UI.ReportPrintTool(ReportOvertime)
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

            If view.GetFocusedRowCellValue("to_salary").ToString = "1" Then
                clone.RowFilter = ""
            Else
                If view.GetFocusedRowCellValue("is_day_off").ToString = "1" Then
                    If view.GetFocusedRowCellValue("ot_total_hours") < ot_min_spv Then
                        clone.RowFilter = "[to_salary] = 2 AND [to_dp] = 2"
                    Else
                        clone.RowFilter = "[to_salary] = 2"
                    End If
                Else
                    clone.RowFilter = "[to_salary] = 2 AND [to_dp] = 2"
                End If
            End If

            edit.Properties.DataSource = clone
        End If

        Dim att_min As Date = Date.Parse(GVEmployee.GetFocusedRowCellValue("ot_date").ToString)
        Dim att_max As Date = Date.Parse(GVEmployee.GetFocusedRowCellValue("ot_date").ToString).AddDays(1)

        If GVEmployee.FocusedColumn.FieldName = "ot_start_time" Then
            Dim ADateEdit As DevExpress.XtraEditors.DateEdit = CType(GVEmployee.ActiveEditor, DevExpress.XtraEditors.DateEdit)

            ADateEdit.Properties.MinValue = New DateTime(att_min.Year, att_min.Month, att_min.Day, 0, 0, 0)
            ADateEdit.Properties.MaxValue = New DateTime(att_min.Year, att_min.Month, att_min.Day, 23, 59, 59)
        ElseIf GVEmployee.FocusedColumn.FieldName = "ot_end_time" Then
            Dim ADateEdit As DevExpress.XtraEditors.DateEdit = CType(GVEmployee.ActiveEditor, DevExpress.XtraEditors.DateEdit)

            ADateEdit.Properties.MinValue = New DateTime(att_min.Year, att_min.Month, att_min.Day, 0, 0, 0)
            ADateEdit.Properties.MaxValue = New DateTime(att_max.Year, att_max.Month, att_max.Day, 23, 59, 59)
        End If
    End Sub

    Private Sub LUEOvertimeType_EditValueChanging(sender As Object, e As DevExpress.XtraEditors.Controls.ChangingEventArgs) Handles LUEOvertimeType.EditValueChanging
        If Not GVEmployee.RowCount = 0 Then
            Dim confirm As DialogResult

            confirm = DevExpress.XtraEditors.XtraMessageBox.Show("Change overtime type will reset employee list, are you sure?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)

            If confirm = Windows.Forms.DialogResult.Yes Then
                load_default()
            Else
                e.Cancel = True
            End If
        End If
    End Sub

    Sub generate_memo_format()
        Dim format As String = execute_query("
            SELECT CONCAT('/INT/', (SELECT `code` FROM tb_ot_memo_number_dep WHERE id_departement = " + LEDepartement.EditValue.ToString + "), '-MM/', (SELECT `code` FROM tb_ot_memo_number_mon WHERE `month` = " + DateTime.Parse(DECreatedAt.EditValue.ToString).ToString("%M") + "), '/', " + DateTime.Parse(DECreatedAt.EditValue.ToString).ToString("%y") + ") AS `format`
        ", 0, True, "", "", "", "")

        TEMemoFormat.EditValue = format
    End Sub

    Sub check_include_memo()
        Dim include_memo As Boolean = False

        If id = "0" Then
            If LUEOvertimeType.EditValue.ToString = "1" Then
                Dim hours As Integer = get_opt_emp_field("ot_memo_employee")

                For i = 0 To GVEmployee.RowCount - 1
                    If GVEmployee.IsValidRowHandle(i) Then
                        If GVEmployee.GetRowCellValue(i, "ot_total_hours") >= hours Then
                            include_memo = True

                            Exit For
                        End If
                    End If
                Next
            End If
        Else
            include_memo = If(execute_query("SELECT memo_number FROM tb_ot WHERE id_ot = " + id, 0, True, "", "", "", "") = "0", False, True)
        End If

        If include_memo Then
            PCMemoNumber.Visible = True
        Else
            PCMemoNumber.Visible = False
        End If
    End Sub

    Private Sub LUEOvertimeType_EditValueChanged(sender As Object, e As EventArgs) Handles LUEOvertimeType.EditValueChanged
        check_include_memo()
    End Sub

    Private Sub GVEmployee_RowCountChanged(sender As Object, e As EventArgs) Handles GVEmployee.RowCountChanged
        check_include_memo()
    End Sub

    Private Sub TEMemoNumber_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles TEMemoNumber.Validating
        If PCMemoNumber.Visible = True Then
            If TEMemoNumber.EditValue.ToString = "" Then
                ErrorProvider.SetError(TEMemoNumber, "Can't be blank.")
            Else
                ErrorProvider.SetError(TEMemoNumber, "")
            End If
        Else
            ErrorProvider.SetError(TEMemoNumber, "")
        End If
    End Sub

    Private Sub LEDepartement_EditValueChanged(sender As Object, e As EventArgs) Handles LEDepartement.EditValueChanged
        generate_memo_format()
    End Sub
End Class