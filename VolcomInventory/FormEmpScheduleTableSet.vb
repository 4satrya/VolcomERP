﻿Public Class FormEmpScheduleTableSet
    Private Sub FormEmpScheduleTableSet_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        load_emp()
    End Sub
    Sub load_emp()
        Dim query As String = "SELECT 'no' as is_select,lvl.employee_level,emp.id_employee,emp.employee_code,emp.employee_name,dep.departement,emp.employee_position,active.employee_active"
        query += " FROM tb_m_employee emp"
        query += " INNER JOIN tb_m_departement dep ON dep.id_departement=emp.id_departement"
        query += " INNER JOIN tb_lookup_employee_level lvl ON lvl.id_employee_level=emp.id_employee_level"
        query += " INNER JOIN tb_lookup_employee_active active On active.id_employee_active=emp.id_employee_active"
        If FormEmpSchedule.is_security = "1" Then
            query += " WHERE emp.employee_position LIKE '%security%'"
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
    End Sub

    Private Sub FormEmpScheduleTableSet_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub
End Class