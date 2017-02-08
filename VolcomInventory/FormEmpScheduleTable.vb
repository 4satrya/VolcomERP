Public Class FormEmpScheduleTable
    Private Sub FormEmpScheduleTable_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        FormEmpScheduleTableSet.ShowDialog()
    End Sub

    Private Sub FormEmpScheduleTable_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub BSetSchedule_Click(sender As Object, e As EventArgs) Handles BSetSchedule.Click
        Cursor = Cursors.WaitCursor
        If GVSchedule.RowCount > 0 Then
            For i As Integer = 0 To GVSchedule.RowCount - 1
                For j As Integer = 0 To GVSchedule.Columns.Count - 1
                    If Not (GVSchedule.Columns(j).FieldName = "id_employee" Or GVSchedule.Columns(j).FieldName = "employee_code" Or GVSchedule.Columns(j).FieldName = "employee_name") Then
                        get_schedule(GVSchedule.GetRowCellValue(i, GVSchedule.Columns(j).FieldName.ToString).ToString, GVSchedule.Columns(j).FieldName.ToString, GVSchedule.GetRowCellValue(i, "id_employee").ToString)
                    End If
                Next
            Next
            infoCustom("Employee Scheduled.")
            Close()
        Else
            stopCustom("Please choose the employee first.")
            FormEmpScheduleTableSet.ShowDialog()
        End If
        Cursor = Cursors.Default
    End Sub
    Sub get_schedule(ByVal shift_code As String, ByVal date_var As String, ByVal id_employee_var As String)
        Dim id_shift = ""
        If Not shift_code = "" Then
            If shift_code.ToUpper = "OFF" Then
                Dim query_shift As String = "CALL add_shift(" & id_employee_var & ",1,'" & date_var & "','" & date_var & "',2)"
                execute_non_query(query_shift, True, "", "", "", "")
            Else
                Dim query As String = "SELECT id_shift FROM tb_emp_shift WHERE UPPER(shift_code)='" & shift_code.ToUpper & "' LIMIT 1"
                Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
                If data.Rows.Count > 0 Then
                    Dim query_shift As String = "CALL add_shift(" & id_employee_var & "," & data.Rows(0)("id_shift").ToString & ",'" & date_var & "','" & date_var & "',1)"
                    execute_non_query(query_shift, True, "", "", "", "")
                End If
            End If
        End If
    End Sub
End Class