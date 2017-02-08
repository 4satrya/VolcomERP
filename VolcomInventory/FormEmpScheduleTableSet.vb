Public Class FormEmpScheduleTableSet
    Public opt As String = "1"
    '1 = schedule table
    '2 = attnassigndet
    Private Sub FormEmpScheduleTableSet_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim dayOfWeek = CInt(Date.Today.DayOfWeek)
        Dim startOfWeek = Date.Today.AddDays(-1 * dayOfWeek)
        Dim endOfWeek = Date.Today.AddDays(7 - dayOfWeek).AddSeconds(-1)
        '
        DEStart.EditValue = startOfWeek
        DEUntil.EditValue = endOfWeek
        '
        load_emp()
    End Sub
    Sub load_emp()
        Dim query As String = "SELECT 'no' as is_select,lvl.employee_level,emp.id_employee,emp.employee_code,emp.employee_name,dep.departement,emp.employee_position,active.employee_active
                                FROM tb_m_employee emp
                                INNER JOIN tb_m_departement dep ON dep.id_departement=emp.id_departement
                                INNER JOIN tb_lookup_employee_level lvl ON lvl.id_employee_level=emp.id_employee_level
                                INNER JOIN tb_lookup_employee_active active On active.id_employee_active=emp.id_employee_active"

        If FormEmpSchedule.is_security = "1" And opt = "1" Then
            query += " WHERE emp.employee_position LIKE '%security%' AND emp.id_employee_active='1'"
        ElseIf opt = "2" Then
            query += " WHERE emp.id_departement='" & id_departement_user & "' AND emp.id_employee_active='1'"
        End If

        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCEmployee.DataSource = data
        GVEmployee.BestFitColumns()
    End Sub

    Private Sub CESelectAll_CheckedChanged(sender As Object, e As EventArgs) Handles CESelectAll.CheckedChanged
        Dim cek As String = CESelectAll.EditValue.ToString
        For i As Integer = 0 To (GVEmployee.RowCount - 1)
            If cek Then
                GVEmployee.SetRowCellValue(i, "is_select", "yes")
            Else
                GVEmployee.SetRowCellValue(i, "is_select", "no")
            End If
        Next
    End Sub
    Private Sub DEStart_EditValueChanged(sender As Object, e As EventArgs) Handles DEStart.EditValueChanged
        Try
            DEUntil.Properties.MinValue = DEStart.EditValue
        Catch ex As Exception
        End Try
    End Sub

    Private Sub BChoose_Click(sender As Object, e As EventArgs) Handles BChoose.Click
        Dim startP As Date = Date.Parse(DEStart.EditValue.ToString)
        Dim endP As Date = Date.Parse(DEUntil.EditValue.ToString)
        Dim curD As Date = startP
        Dim string_date As String = ""

        GVEmployee.ActiveFilterString = "[is_select]='yes' "
        If opt = "1" Then
            If GVEmployee.RowCount > 0 Then
                '
                FormEmpScheduleTable.GVSchedule.Columns.AddVisible("id_employee", "ID")
                FormEmpScheduleTable.GVSchedule.Columns("id_employee").OptionsColumn.AllowEdit = False
                FormEmpScheduleTable.GVSchedule.Columns("id_employee").Visible = False

                FormEmpScheduleTable.GVSchedule.Columns.AddVisible("employee_code", "NIP")
                FormEmpScheduleTable.GVSchedule.Columns("employee_code").OptionsColumn.AllowEdit = False

                FormEmpScheduleTable.GVSchedule.Columns.AddVisible("employee_name", "Name")
                FormEmpScheduleTable.GVSchedule.Columns("employee_name").OptionsColumn.AllowEdit = False

                While (curD <= endP)
                    FormEmpScheduleTable.GVSchedule.Columns.AddVisible(curD.ToString("yyyy-MM-dd"), curD.ToString("dd MMM yyyy"))
                    string_date += ",'" & curD.ToString("yyyy-MM-dd") & "'"
                    curD = curD.AddDays(1)
                End While
                '
                Dim query As String = "SELECT '' as id_employee,'' as employee_code,'' as employee_name" & string_date
                Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
                FormEmpScheduleTable.GCSchedule.DataSource = data
                FormEmpScheduleTable.GVSchedule.DeleteRow(0)
                '
                For i As Integer = 0 To GVEmployee.RowCount - 1
                    Dim query_emp As String = "SELECT emp.date,emp.shift_code FROM tb_emp_schedule emp WHERE emp.id_employee='" & GVEmployee.GetRowCellValue(i, "id_employee").ToString & "' AND emp.date >= '" & startP.ToString("yyyy-MM-dd") & "' AND emp.date <= '" & endP.ToString("yyyy-MM-dd") & "'"
                    Dim data_emp As DataTable = execute_query(query_emp, -1, True, "", "", "", "")

                    Dim newRow As DataRow = (TryCast(FormEmpScheduleTable.GCSchedule.DataSource, DataTable)).NewRow()
                    newRow("id_employee") = GVEmployee.GetRowCellValue(i, "id_employee").ToString
                    newRow("employee_code") = GVEmployee.GetRowCellValue(i, "employee_code").ToString
                    newRow("employee_name") = GVEmployee.GetRowCellValue(i, "employee_name").ToString
                    If data_emp.Rows.Count > 0 Then
                        For j As Integer = 0 To data_emp.Rows.Count - 1
                            newRow(Date.Parse(data_emp.Rows(j)("date").ToString).ToString("yyyy-MM-dd")) = data_emp.Rows(j)("shift_code").ToString.ToUpper
                        Next
                    End If

                    TryCast(FormEmpScheduleTable.GCSchedule.DataSource, DataTable).Rows.Add(newRow)
                    FormEmpScheduleTable.GCSchedule.RefreshDataSource()
                Next
                FormEmpScheduleTable.GVSchedule.BestFitColumns()
                '
                Close()
            Else
                stopCustom("Please select employee first.")
            End If
        ElseIf opt = "2" Then
            If GVEmployee.RowCount > 0 Then
                'before grid view
                curD = startP
                FormEmpAttnAssignDet.GVScheduleBefore.Columns.AddVisible("id_employee", "ID")
                FormEmpAttnAssignDet.GVScheduleBefore.Columns("id_employee").OptionsColumn.AllowEdit = False
                FormEmpAttnAssignDet.GVScheduleBefore.Columns("id_employee").Visible = False

                FormEmpAttnAssignDet.GVScheduleBefore.Columns.AddVisible("employee_code", "NIP")
                FormEmpAttnAssignDet.GVScheduleBefore.Columns("employee_code").OptionsColumn.AllowEdit = False

                FormEmpAttnAssignDet.GVScheduleBefore.Columns.AddVisible("employee_name", "Name")
                FormEmpAttnAssignDet.GVScheduleBefore.Columns("employee_name").OptionsColumn.AllowEdit = False

                FormEmpAttnAssignDet.GVScheduleBefore.Columns("employee_code").Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left
                FormEmpAttnAssignDet.GVScheduleBefore.Columns("employee_name").Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left

                While (curD <= endP)
                    FormEmpAttnAssignDet.GVScheduleBefore.Columns.AddVisible(curD.ToString("yyyy-MM-dd"), curD.ToString("dd MMM yyyy"))
                    FormEmpAttnAssignDet.GVScheduleBefore.Columns(curD.ToString("yyyy-MM-dd")).OptionsColumn.AllowEdit = False

                    string_date += ",'" & curD.ToString("yyyy-MM-dd") & "'"
                    curD = curD.AddDays(1)
                End While
                '
                Dim query As String = "SELECT '' as id_employee,'' as employee_code,'' as employee_name" & string_date
                Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
                FormEmpAttnAssignDet.GCScheduleBefore.DataSource = data
                FormEmpAttnAssignDet.GVScheduleBefore.DeleteRow(0)
                '
                For i As Integer = 0 To GVEmployee.RowCount - 1
                    Dim query_emp As String = "SELECT emp.date,emp.shift_code FROM tb_emp_schedule emp WHERE emp.id_employee='" & GVEmployee.GetRowCellValue(i, "id_employee").ToString & "' AND emp.date >= '" & startP.ToString("yyyy-MM-dd") & "' AND emp.date <= '" & endP.ToString("yyyy-MM-dd") & "'"
                    Dim data_emp As DataTable = execute_query(query_emp, -1, True, "", "", "", "")

                    Dim newRow As DataRow = (TryCast(FormEmpAttnAssignDet.GCScheduleBefore.DataSource, DataTable)).NewRow()
                    newRow("id_employee") = GVEmployee.GetRowCellValue(i, "id_employee").ToString
                    newRow("employee_code") = GVEmployee.GetRowCellValue(i, "employee_code").ToString
                    newRow("employee_name") = GVEmployee.GetRowCellValue(i, "employee_name").ToString
                    If data_emp.Rows.Count > 0 Then
                        For j As Integer = 0 To data_emp.Rows.Count - 1
                            newRow(Date.Parse(data_emp.Rows(j)("date").ToString).ToString("yyyy-MM-dd")) = data_emp.Rows(j)("shift_code").ToString.ToUpper
                        Next
                    End If

                    TryCast(FormEmpAttnAssignDet.GCScheduleBefore.DataSource, DataTable).Rows.Add(newRow)
                    FormEmpAttnAssignDet.GCScheduleBefore.RefreshDataSource()
                Next
                FormEmpAttnAssignDet.GVScheduleBefore.BestFitColumns()

                'repeat for after
                curD = startP
                string_date = ""

                FormEmpAttnAssignDet.GVScheduleAfter.Columns.AddVisible("id_employee", "ID")
                FormEmpAttnAssignDet.GVScheduleAfter.Columns("id_employee").OptionsColumn.AllowEdit = False
                FormEmpAttnAssignDet.GVScheduleAfter.Columns("id_employee").Visible = False

                FormEmpAttnAssignDet.GVScheduleAfter.Columns.AddVisible("employee_code", "NIP")
                FormEmpAttnAssignDet.GVScheduleAfter.Columns("employee_code").OptionsColumn.AllowEdit = False

                FormEmpAttnAssignDet.GVScheduleAfter.Columns.AddVisible("employee_name", "Name")
                FormEmpAttnAssignDet.GVScheduleAfter.Columns("employee_name").OptionsColumn.AllowEdit = False

                FormEmpAttnAssignDet.GVScheduleAfter.Columns("employee_code").Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left
                FormEmpAttnAssignDet.GVScheduleAfter.Columns("employee_name").Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left

                While (curD <= endP)
                    FormEmpAttnAssignDet.GVScheduleAfter.Columns.AddVisible(curD.ToString("yyyy-MM-dd"), curD.ToString("dd MMM yyyy"))
                    string_date += ",'" & curD.ToString("yyyy-MM-dd") & "'"
                    curD = curD.AddDays(1)
                End While
                '
                query = "SELECT '' as id_employee,'' as employee_code,'' as employee_name" & string_date
                data = execute_query(query, -1, True, "", "", "", "")
                FormEmpAttnAssignDet.GCScheduleAfter.DataSource = data
                FormEmpAttnAssignDet.GVScheduleAfter.DeleteRow(0)
                '
                For i As Integer = 0 To GVEmployee.RowCount - 1
                    Dim query_emp As String = "SELECT emp.date,emp.shift_code FROM tb_emp_schedule emp WHERE emp.id_employee='" & GVEmployee.GetRowCellValue(i, "id_employee").ToString & "' AND emp.date >= '" & startP.ToString("yyyy-MM-dd") & "' AND emp.date <= '" & endP.ToString("yyyy-MM-dd") & "'"
                    Dim data_emp As DataTable = execute_query(query_emp, -1, True, "", "", "", "")

                    Dim newRow As DataRow = (TryCast(FormEmpAttnAssignDet.GCScheduleAfter.DataSource, DataTable)).NewRow()
                    newRow("id_employee") = GVEmployee.GetRowCellValue(i, "id_employee").ToString
                    newRow("employee_code") = GVEmployee.GetRowCellValue(i, "employee_code").ToString
                    newRow("employee_name") = GVEmployee.GetRowCellValue(i, "employee_name").ToString
                    If data_emp.Rows.Count > 0 Then
                        For j As Integer = 0 To data_emp.Rows.Count - 1
                            newRow(Date.Parse(data_emp.Rows(j)("date").ToString).ToString("yyyy-MM-dd")) = data_emp.Rows(j)("shift_code").ToString.ToUpper
                        Next
                    End If

                    TryCast(FormEmpAttnAssignDet.GCScheduleAfter.DataSource, DataTable).Rows.Add(newRow)
                    FormEmpAttnAssignDet.GCScheduleAfter.RefreshDataSource()
                Next
                FormEmpAttnAssignDet.GVScheduleAfter.BestFitColumns()
                FormEmpAttnAssignDet.date_from = DEStart.EditValue
                FormEmpAttnAssignDet.date_until = DEUntil.EditValue
                '
                Close()
            Else
                stopCustom("Please select employee first.")
            End If
        End If
    End Sub

    Private Sub FormEmpScheduleTableSet_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub
End Class