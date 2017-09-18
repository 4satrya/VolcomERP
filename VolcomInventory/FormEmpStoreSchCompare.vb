Public Class FormEmpStoreSchCompare
    Public view_store As Boolean = True

    Private Sub FormEmpStoreSchCompare_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        viewDept()
        DEStartSum.EditValue = Now
        DEUntilSum.EditValue = Now
    End Sub
    Sub viewDept()
        Dim query As String = ""
        If view_store Then
            query += "(SELECT id_departement,departement FROM tb_m_departement a WHERE is_store='1' ORDER BY a.departement ASC) "
        Else
            query += "SELECT 0 as id_departement, 'All departement' as departement UNION  "
            query += "(SELECT id_departement,departement FROM tb_m_departement a ORDER BY a.departement ASC) "
        End If
        viewLookupQuery(LEDeptSum, query, 0, "departement", "id_departement")
    End Sub

    Private Sub BViewSum_Click(sender As Object, e As EventArgs) Handles BViewSum.Click
        Cursor = Cursors.WaitCursor
        load_schedule_table()
        load_schedule_plan_table()
        Cursor = Cursors.Default
    End Sub
    Sub load_schedule_plan_table()
        Dim startP As Date = Date.Parse(DEStartSum.EditValue.ToString)
        Dim endP As Date = Date.Parse(DEUntilSum.EditValue.ToString)
        Dim curD As Date = startP
        Dim string_date As String = ""
        Dim dept As String = ""

        If LEDeptSum.EditValue.ToString = "0" Then
            dept = "%%"
        Else
            dept = LEDeptSum.EditValue.ToString
        End If

        Dim query As String = "SELECT * FROM tb_m_employee WHERE id_departement LIKE '" & dept & "' AND id_employee_active='1'"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")

        GVScheduleTable.Columns.Clear()

        If data.Rows.Count > 0 Then
            '
            GVScheduleTable.Columns.AddVisible("id_employee", "ID")
            GVScheduleTable.Columns("id_employee").OptionsColumn.AllowEdit = False
            GVScheduleTable.Columns("id_employee").Visible = False

            GVScheduleTable.Columns.AddVisible("employee_code", "NIP")
            GVScheduleTable.Columns("employee_code").OptionsColumn.AllowEdit = False

            GVScheduleTable.Columns.AddVisible("employee_name", "Name")
            GVScheduleTable.Columns("employee_name").OptionsColumn.AllowEdit = False

            While (curD <= endP)
                GVScheduleTable.Columns.AddVisible(curD.ToString("yyyy-MM-dd"), curD.ToString("dddd, dd MMM yyyy"))
                string_date += ",'" & curD.ToString("yyyy-MM-dd") & "'"
                curD = curD.AddDays(1)
            End While
            '
            Dim query_x As String = "SELECT '' as id_employee,'' as employee_code,'' as employee_name" & string_date
            Dim data_x As DataTable = execute_query(query_x, -1, True, "", "", "", "")
            GCScheduleTable.DataSource = data_x
            GVScheduleTable.DeleteRow(0)
            '
            For i As Integer = 0 To data.Rows.Count - 1
                Dim query_emp As String = "SELECT schd.date,schd.shift_code,sch.* FROM tb_emp_assign_sch_det schd
                                            INNER JOIN tb_emp_assign_sch sch ON sch.id_assign_sch=schd.id_emp_assign_sch
                                            INNER JOIN (
	                                            SELECT * FROM tb_report_mark WHERE report_mark_type='100' GROUP BY id_report HAVING MAX(report_mark_datetime)
                                            ) rm ON rm.id_report=sch.id_assign_sch 
                                            WHERE schd.id_employee= '" & data.Rows(i)("id_employee").ToString & "'
                                            AND schd.`date` >= '" & startP.ToString("yyyy-MM-dd") & "' 
                                            AND schd.`date` <= '" & endP.ToString("yyyy-MM-dd") & "'
                                            AND schd.type='2'
                                            AND sch.id_report_status='6' 
                                            GROUP BY schd.date
                                            HAVING MIN(rm.report_mark_datetime) "
                Dim data_emp As DataTable = execute_query(query_emp, -1, True, "", "", "", "")

                Dim newRow As DataRow = (TryCast(GCScheduleTable.DataSource, DataTable)).NewRow()
                newRow("id_employee") = data.Rows(i)("id_employee").ToString
                newRow("employee_code") = data.Rows(i)("employee_code").ToString
                newRow("employee_name") = data.Rows(i)("employee_name").ToString
                If data_emp.Rows.Count > 0 Then
                    For j As Integer = 0 To data_emp.Rows.Count - 1
                        newRow(Date.Parse(data_emp.Rows(j)("date").ToString).ToString("yyyy-MM-dd")) = data_emp.Rows(j)("shift_code").ToString.ToUpper
                    Next
                End If

                TryCast(GCScheduleTable.DataSource, DataTable).Rows.Add(newRow)
                GCScheduleTable.RefreshDataSource()
            Next
            GVScheduleTable.BestFitColumns()
        Else
            stopCustom("Please select employee first.")
        End If

    End Sub
    Sub load_schedule_table()
        Dim startP As Date = Date.Parse(DEStartSum.EditValue.ToString)
        Dim endP As Date = Date.Parse(DEUntilSum.EditValue.ToString)
        Dim curD As Date = startP
        Dim string_date As String = ""
        Dim dept As String = ""

        If LEDeptSum.EditValue.ToString = "0" Then
            dept = "%%"
        Else
            dept = LEDeptSum.EditValue.ToString
        End If

        Dim query As String = "SELECT * FROM tb_m_employee WHERE id_departement LIKE '" & dept & "' AND id_employee_active='1'"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")

        GVScheduleAfter.Columns.Clear()

        If data.Rows.Count > 0 Then
            '
            GVScheduleAfter.Columns.AddVisible("id_employee", "ID")
            GVScheduleAfter.Columns("id_employee").OptionsColumn.AllowEdit = False
            GVScheduleAfter.Columns("id_employee").Visible = False

            GVScheduleAfter.Columns.AddVisible("employee_code", "NIP")
            GVScheduleAfter.Columns("employee_code").OptionsColumn.AllowEdit = False

            GVScheduleAfter.Columns.AddVisible("employee_name", "Name")
            GVScheduleAfter.Columns("employee_name").OptionsColumn.AllowEdit = False

            While (curD <= endP)
                GVScheduleAfter.Columns.AddVisible(curD.ToString("yyyy-MM-dd"), curD.ToString("dddd, dd MMM yyyy"))
                string_date += ",'" & curD.ToString("yyyy-MM-dd") & "'"
                curD = curD.AddDays(1)
            End While
            '
            Dim query_x As String = "SELECT '' as id_employee,'' as employee_code,'' as employee_name" & string_date
            Dim data_x As DataTable = execute_query(query_x, -1, True, "", "", "", "")
            GCScheduleAfter.DataSource = data_x
            GVScheduleAfter.DeleteRow(0)
            '
            For i As Integer = 0 To data.Rows.Count - 1
                Dim query_emp As String = "SELECT emp.date,emp.shift_code FROM tb_emp_schedule emp WHERE emp.id_employee='" & data.Rows(i)("id_employee").ToString & "' AND emp.date >= '" & startP.ToString("yyyy-MM-dd") & "' AND emp.date <= '" & endP.ToString("yyyy-MM-dd") & "'"
                Dim data_emp As DataTable = execute_query(query_emp, -1, True, "", "", "", "")

                Dim newRow As DataRow = (TryCast(GCScheduleAfter.DataSource, DataTable)).NewRow()
                newRow("id_employee") = data.Rows(i)("id_employee").ToString
                newRow("employee_code") = data.Rows(i)("employee_code").ToString
                newRow("employee_name") = data.Rows(i)("employee_name").ToString
                If data_emp.Rows.Count > 0 Then
                    For j As Integer = 0 To data_emp.Rows.Count - 1
                        newRow(Date.Parse(data_emp.Rows(j)("date").ToString).ToString("yyyy-MM-dd")) = data_emp.Rows(j)("shift_code").ToString.ToUpper
                    Next
                End If

                TryCast(GCScheduleAfter.DataSource, DataTable).Rows.Add(newRow)
                GCScheduleAfter.RefreshDataSource()
            Next
            GVScheduleAfter.BestFitColumns()
        Else
            stopCustom("Please select employee first.")
        End If

    End Sub

    Private Sub CEMarkDifferent_CheckedChanged(sender As Object, e As EventArgs)

    End Sub

    Private Sub GVScheduleAfter_RowCellStyle(sender As Object, e As DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs) Handles GVScheduleAfter.RowCellStyle
        Try
            If Not GVScheduleTable.GetRowCellValue(e.RowHandle, e.Column.FieldName.ToString).ToString = e.CellValue.ToString Then
                e.Appearance.BackColor = Color.Salmon
                e.Appearance.BackColor2 = Color.SeaShell
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub SMViewHistoryPD_Click(sender As Object, e As EventArgs) Handles SMViewHistoryPD.Click
        If XtraTabControl1.SelectedTabPageIndex = 0 Then
            FormEmpStoreSchCompareHistory.LDate.Text = GVScheduleTable.FocusedColumn.Caption.ToString
            FormEmpStoreSchCompareHistory.LEmpName.Text = GVScheduleTable.GetFocusedRowCellValue("employee_name").ToString
            FormEmpStoreSchCompareHistory.id_emp = GVScheduleTable.GetFocusedRowCellValue("id_employee").ToString
            FormEmpStoreSchCompareHistory.date_string = GVScheduleTable.FocusedColumn.FieldName.ToString
            FormEmpStoreSchCompareHistory.ShowDialog()
        Else
            FormEmpStoreSchCompareHistory.LDate.Text = GVScheduleAfter.FocusedColumn.Caption.ToString
            FormEmpStoreSchCompareHistory.LEmpName.Text = GVScheduleAfter.GetFocusedRowCellValue("employee_name").ToString
            FormEmpStoreSchCompareHistory.id_emp = GVScheduleAfter.GetFocusedRowCellValue("id_employee").ToString
            FormEmpStoreSchCompareHistory.date_string = GVScheduleAfter.FocusedColumn.FieldName.ToString
            FormEmpStoreSchCompareHistory.ShowDialog()
        End If

    End Sub

    Private Sub BPrintSum_Click(sender As Object, e As EventArgs) Handles BPrintSum.Click
        If XtraTabControl1.SelectedTabPageIndex = 0 Then
            print(GCScheduleTable, "Planned Schedule")
        Else
            print(GCScheduleAfter, "Current Schedule")
        End If
    End Sub
End Class