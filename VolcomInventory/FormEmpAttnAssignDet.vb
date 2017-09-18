Public Class FormEmpAttnAssignDet
    Public id_emp_assign_sch As String = "-1"
    Public date_from As Date = Now
    Public date_until As Date = Now
    '
    Public is_view As String = "-1"
    Private Sub FormEmpAttnAssignDet_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If id_emp_assign_sch = "-1" Then 'new
            Dim query As String = "SELECT emp.employee_name,emp.employee_code,dep.departement FROM tb_m_employee emp
                                    INNER JOIN tb_m_departement dep ON dep.id_departement=emp.id_departement
                                    WHERE id_employee='" & id_employee_user & "'"
            Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
            '
            TEEmpCode.Text = data.Rows(0)("employee_code").ToString
            TEEmpName.Text = data.Rows(0)("employee_name").ToString
            TEDepartement.Text = data.Rows(0)("departement").ToString

            DEDate.EditValue = Now
            TENumber.Text = header_number_emp("4")

            '
            FormEmpScheduleTableSet.opt = "2"
            FormEmpScheduleTableSet.ShowDialog()
        Else 'edit
            BMark.Visible = True
            BPropose.Visible = False
            '
            Dim query As String = "SELECT * FROM tb_emp_assign_sch sch
                                LEFT JOIN tb_m_user usr ON usr.id_user=sch.id_user_propose
                                INNER JOIN tb_m_employee emp ON emp.id_employee=usr.id_employee
                                INNER JOIN tb_m_departement dep ON dep.id_departement=sch.id_departement
                                WHERE sch.id_assign_sch='" & id_emp_assign_sch & "'"
            Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")

            DEDate.EditValue = data.Rows(0)("assign_sch_date")
            TENumber.Text = data.Rows(0)("assign_sch_number").ToString
            TEDepartement.Text = data.Rows(0)("departement").ToString
            TEEmpCode.Text = data.Rows(0)("employee_code").ToString
            TEEmpName.Text = data.Rows(0)("employee_name").ToString
            '
            Dim string_date As String = ""
            Dim startP As Date = Date.Parse(data.Rows(0)("date_from").ToString)
            Dim endP As Date = Date.Parse(data.Rows(0)("date_until").ToString)
            Dim curD As Date = startP
            'before grid view
            curD = startP
            GVScheduleBefore.Columns.AddVisible("id_employee", "ID")
            GVScheduleBefore.Columns("id_employee").OptionsColumn.AllowEdit = False
            GVScheduleBefore.Columns("id_employee").Visible = False

            GVScheduleBefore.Columns.AddVisible("employee_code", "NIP")
            GVScheduleBefore.Columns("employee_code").OptionsColumn.AllowEdit = False

            GVScheduleBefore.Columns.AddVisible("employee_name", "Name")
            GVScheduleBefore.Columns("employee_name").OptionsColumn.AllowEdit = False

            GVScheduleBefore.Columns("employee_code").Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left
            GVScheduleBefore.Columns("employee_name").Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left

            While (curD <= endP)
                GVScheduleBefore.Columns.AddVisible(curD.ToString("yyyy-MM-dd"), curD.ToString("dd MMM yyyy"))
                GVScheduleBefore.Columns(curD.ToString("yyyy-MM-dd")).OptionsColumn.AllowEdit = False

                If curD.DayOfWeek = DayOfWeek.Saturday Or curD.DayOfWeek = DayOfWeek.Sunday Then
                    GVScheduleBefore.Columns(curD.ToString("yyyy-MM-dd")).AppearanceCell.BackColor = Color.Pink
                ElseIf check_public_holiday(curD) = "1" Then
                    GVScheduleBefore.Columns(curD.ToString("yyyy-MM-dd")).AppearanceCell.BackColor = Color.Red
                End If

                string_date += ",'" & curD.ToString("yyyy-MM-dd") & "'"
                curD = curD.AddDays(1)
            End While
            '
            Dim query_x As String = "SELECT '' as id_employee,'' as employee_code,'' as employee_name" & string_date
            Dim data_x As DataTable = execute_query(query_x, -1, True, "", "", "", "")
            GCScheduleBefore.DataSource = data_x
            GVScheduleBefore.DeleteRow(0)
            '
            Dim query_y As String = "SELECT sch.id_employee,emp.employee_name,emp.employee_code FROM tb_emp_assign_sch_det sch INNER JOIN tb_m_employee emp ON emp.id_employee=sch.id_employee WHERE id_emp_assign_sch='" & id_emp_assign_sch & "' AND type='1' GROUP BY id_employee"
            Dim data_y As DataTable = execute_query(query_y, -1, True, "", "", "", "")
            '
            For i As Integer = 0 To data_y.Rows.Count - 1
                Dim query_emp As String = "SELECT emp.date,emp.shift_code FROM tb_emp_assign_sch_det emp WHERE emp.id_emp_assign_sch='" & id_emp_assign_sch & "' AND emp.type='1' AND emp.id_employee='" & data_y.Rows(i)("id_employee").ToString & "' AND emp.date >= '" & startP.ToString("yyyy-MM-dd") & "' AND emp.date <= '" & endP.ToString("yyyy-MM-dd") & "'"
                Dim data_emp As DataTable = execute_query(query_emp, -1, True, "", "", "", "")

                Dim newRow As DataRow = (TryCast(GCScheduleBefore.DataSource, DataTable)).NewRow()
                newRow("id_employee") = data_y.Rows(i)("id_employee").ToString
                newRow("employee_code") = data_y.Rows(i)("employee_code").ToString
                newRow("employee_name") = data_y.Rows(i)("employee_name").ToString
                If data_emp.Rows.Count > 0 Then
                    For j As Integer = 0 To data_emp.Rows.Count - 1
                        newRow(Date.Parse(data_emp.Rows(j)("date").ToString).ToString("yyyy-MM-dd")) = data_emp.Rows(j)("shift_code").ToString.ToUpper
                    Next
                End If

                TryCast(GCScheduleBefore.DataSource, DataTable).Rows.Add(newRow)
                GCScheduleBefore.RefreshDataSource()
            Next
            GVScheduleBefore.BestFitColumns()
            GVScheduleBefore.OptionsSelection.EnableAppearanceFocusedRow = False
            GVScheduleBefore.OptionsSelection.EnableAppearanceFocusedCell = False
            'repeat for after
            curD = startP
            string_date = ""

            GVScheduleAfter.Columns.AddVisible("id_employee", "ID")
            GVScheduleAfter.Columns("id_employee").OptionsColumn.AllowEdit = False
            GVScheduleAfter.Columns("id_employee").Visible = False

            GVScheduleAfter.Columns.AddVisible("employee_code", "NIP")
            GVScheduleAfter.Columns("employee_code").OptionsColumn.AllowEdit = False

            GVScheduleAfter.Columns.AddVisible("employee_name", "Name")
            GVScheduleAfter.Columns("employee_name").OptionsColumn.AllowEdit = False

            GVScheduleAfter.Columns("employee_code").Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left
            GVScheduleAfter.Columns("employee_name").Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left

            While (curD <= endP)
                GVScheduleAfter.Columns.AddVisible(curD.ToString("yyyy-MM-dd"), curD.ToString("dd MMM yyyy"))
                GVScheduleAfter.Columns(curD.ToString("yyyy-MM-dd")).OptionsColumn.AllowEdit = False

                string_date += ",'" & curD.ToString("yyyy-MM-dd") & "'"

                If curD.DayOfWeek = DayOfWeek.Saturday Or curD.DayOfWeek = DayOfWeek.Sunday Then
                    GVScheduleAfter.Columns(curD.ToString("yyyy-MM-dd")).AppearanceCell.BackColor = Color.Pink
                ElseIf check_public_holiday(curD) = "1" Then
                    GVScheduleAfter.Columns(curD.ToString("yyyy-MM-dd")).AppearanceCell.BackColor = Color.Red
                End If

                curD = curD.AddDays(1)
            End While
            '
            Dim query_xx As String = "SELECT '' as id_employee,'' as employee_code,'' as employee_name" & string_date
            Dim data_xx As DataTable = execute_query(query_xx, -1, True, "", "", "", "")
            GCScheduleAfter.DataSource = data_xx
            GVScheduleAfter.DeleteRow(0)
            '
            Dim query_yy As String = "SELECT sch.id_employee,emp.employee_name,emp.employee_code FROM tb_emp_assign_sch_det sch INNER JOIN tb_m_employee emp ON emp.id_employee=sch.id_employee WHERE id_emp_assign_sch='" & id_emp_assign_sch & "' AND type='2' GROUP BY id_employee"
            Dim data_yy As DataTable = execute_query(query_yy, -1, True, "", "", "", "")
            '
            For i As Integer = 0 To data_yy.Rows.Count - 1
                Dim query_emp As String = "SELECT emp.date,emp.shift_code FROM tb_emp_assign_sch_det emp WHERE emp.id_emp_assign_sch='" & id_emp_assign_sch & "' AND emp.type='2' AND emp.id_employee='" & data_yy.Rows(i)("id_employee").ToString & "' AND emp.date >= '" & startP.ToString("yyyy-MM-dd") & "' AND emp.date <= '" & endP.ToString("yyyy-MM-dd") & "'"
                Dim data_emp As DataTable = execute_query(query_emp, -1, True, "", "", "", "")

                Dim newRow As DataRow = (TryCast(GCScheduleAfter.DataSource, DataTable)).NewRow()
                newRow("id_employee") = data_yy.Rows(i)("id_employee").ToString
                newRow("employee_code") = data_yy.Rows(i)("employee_code").ToString
                newRow("employee_name") = data_yy.Rows(i)("employee_name").ToString
                If data_emp.Rows.Count > 0 Then
                    For j As Integer = 0 To data_emp.Rows.Count - 1
                        newRow(Date.Parse(data_emp.Rows(j)("date").ToString).ToString("yyyy-MM-dd")) = data_emp.Rows(j)("shift_code").ToString.ToUpper
                    Next
                End If

                TryCast(GCScheduleAfter.DataSource, DataTable).Rows.Add(newRow)
                GCScheduleAfter.RefreshDataSource()
            Next

            GVScheduleAfter.BestFitColumns()
            GVScheduleAfter.OptionsSelection.EnableAppearanceFocusedRow = False
            GVScheduleAfter.OptionsSelection.EnableAppearanceFocusedCell = False
        End If
    End Sub

    Function check_public_holiday(date_par As Date)
        Dim is_public_holiday = "2"

        Dim query As String = "SELECT * FROM tb_emp_holiday WHERE id_religion=0 AND emp_holiday_date='" & date_par.ToString("yyyy-MM-dd") & "'"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")

        If data.Rows.Count > 0 Then
            is_public_holiday = "1"
        End If

        Return is_public_holiday
    End Function

    Private Sub FormEmpAttnAssignDet_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub BCancel_Click(sender As Object, e As EventArgs) Handles BCancel.Click
        Close()
    End Sub

    Private Sub BViewShift_Click(sender As Object, e As EventArgs) Handles BViewShift.Click
        FormEmpAttnAssignShift.ShowDialog()
    End Sub

    Private Sub BPropose_Click(sender As Object, e As EventArgs) Handles BPropose.Click
        Cursor = Cursors.WaitCursor
        If id_emp_assign_sch = "-1" Then 'new
            Dim query As String = ""
            Dim date_fromp As String = Date.Parse(date_from.ToString).ToString("yyyy-MM-dd")
            Dim date_untilp As String = Date.Parse(date_until.ToString).ToString("yyyy-MM-dd")
            'add header
            query = "INSERT INTO tb_emp_assign_sch(assign_sch_number,assign_sch_date,id_departement,date_from,date_until,id_user_propose,id_report_status,note) 
                    VALUES('" & header_number_emp("4") & "',NOW(),'" & id_departement_user & "','" & date_fromp & "','" & date_untilp & "','" & id_user & "',1,'" & MENote.Text & "'); SELECT LAST_INSERT_ID(); "
            id_emp_assign_sch = execute_query(query, 0, True, "", "", "", "")
            increase_inc_emp("4")
            'detail
            query = ""
            'detail before
            For i As Integer = 0 To GVScheduleBefore.RowCount - 1
                For j As Integer = 0 To GVScheduleBefore.Columns.Count - 1
                    If Not (GVScheduleBefore.Columns(j).FieldName = "id_employee" Or GVScheduleBefore.Columns(j).FieldName = "employee_code" Or GVScheduleBefore.Columns(j).FieldName = "employee_name") Then
                        Dim shift_code As String = GVScheduleBefore.GetRowCellValue(i, GVScheduleBefore.Columns(j).FieldName.ToString).ToString
                        If Not shift_code = "" Then
                            If shift_code = "OFF" Then
                                query += "INSERT INTO tb_emp_assign_sch_det(id_emp_assign_sch,`type`,id_employee,`date`,id_schedule_type,note,shift_code)
                                    VALUES('" & id_emp_assign_sch & "','1','" & GVScheduleBefore.GetRowCellValue(i, "id_employee").ToString & "','" & GVScheduleBefore.Columns(j).FieldName.ToString & "','2','Day Off','OFF');"
                            Else
                                query += "INSERT INTO tb_emp_assign_sch_det(id_emp_assign_sch,`type`,id_employee,`date`,`in`,`out`,in_tolerance,break_out,break_in,minutes_work,id_schedule_type,note,shift_code)
                                    SELECT '" & id_emp_assign_sch & "' AS id_emp_assign_sch,'1' AS `type`,'" & GVScheduleBefore.GetRowCellValue(i, "id_employee").ToString & "' AS id_employee,'" & GVScheduleBefore.Columns(j).FieldName.ToString & "' AS `date`
                                    ,s.start_work AS `in`,s.end_work AS `out`,s.late_start_tolerance AS `in_tolerance`
                                    ,s.start_break AS break_out,s.end_break AS break_in
                                    ,s.minutes_work,IF('" & shift_code & "'='OFF',2,1) AS id_schedule_type,s.shift_name AS note,s.shift_code
                                    FROM tb_emp_shift s WHERE s.shift_code='" & shift_code & "' LIMIT 1;"
                            End If
                        End If
                    End If
                Next
            Next
            'detail after
            For i As Integer = 0 To GVScheduleAfter.RowCount - 1
                For j As Integer = 0 To GVScheduleAfter.Columns.Count - 1
                    If Not (GVScheduleAfter.Columns(j).FieldName = "id_employee" Or GVScheduleAfter.Columns(j).FieldName = "employee_code" Or GVScheduleAfter.Columns(j).FieldName = "employee_name") Then
                        Dim shift_code As String = GVScheduleAfter.GetRowCellValue(i, GVScheduleAfter.Columns(j).FieldName.ToString).ToString
                        If shift_code = "" Or shift_code = "OFF" Then
                            query += "INSERT INTO tb_emp_assign_sch_det(id_emp_assign_sch,`type`,id_employee,`date`,id_schedule_type,note,shift_code)
                                    VALUES('" & id_emp_assign_sch & "','2','" & GVScheduleAfter.GetRowCellValue(i, "id_employee").ToString & "','" & GVScheduleAfter.Columns(j).FieldName.ToString & "','2','Day Off','OFF');"
                        Else
                            query += "INSERT INTO tb_emp_assign_sch_det(id_emp_assign_sch,`type`,id_employee,`date`,`in`,`out`,in_tolerance,break_out,break_in,minutes_work,id_schedule_type,note,shift_code)
                                    SELECT '" & id_emp_assign_sch & "' AS id_emp_assign_sch,'2' AS `type`,'" & GVScheduleAfter.GetRowCellValue(i, "id_employee").ToString & "' AS id_employee,'" & GVScheduleAfter.Columns(j).FieldName.ToString & "' AS `date`
                                    ,s.start_work AS `in`,s.end_work AS `out`,s.late_start_tolerance AS `in_tolerance`
                                    ,s.start_break AS break_out,s.end_break AS break_in
                                    ,s.minutes_work,IF('" & shift_code & "'='OFF',2,1) AS id_schedule_type,s.shift_name AS note,s.shift_code
                                    FROM tb_emp_shift s WHERE s.shift_code='" & shift_code & "' LIMIT 1;"
                        End If
                    End If
                Next
            Next
            execute_non_query(query, True, "", "", "", "")
            submit_who_prepared("100", id_emp_assign_sch, id_user)
            infoCustom("Change schedule proposed. Waiting approval.")
            FormEmpAttnAssign.load_attn()
            Close()
        End If
    End Sub

    Private Sub BMark_Click(sender As Object, e As EventArgs) Handles BMark.Click
        FormReportMark.id_report = id_emp_assign_sch
        FormReportMark.report_mark_type = "100"
        FormReportMark.is_view = is_view
        FormReportMark.ShowDialog()
    End Sub
End Class