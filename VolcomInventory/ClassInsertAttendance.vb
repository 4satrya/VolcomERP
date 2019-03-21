Public Class ClassInsertAttendance
    Shared Sub insertAttendance()
        Dim dataSchedule As DataTable = execute_query("
            SELECT * 
            FROM tb_emp_schedule 
            WHERE id_employee = 137 AND date BETWEEN '2018-09-01' AND '2018-09-08'
        ", -1, True, "", "", "", "")

        Dim dataAttn As DataTable = execute_query("
            SELECT *
            FROM tb_emp_attn
            WHERE id_employee = 137 AND DATE(datetime) BETWEEN '2018-09-01' AND '2018-09-08'
            ORDER BY datetime ASC
        ", -1, True, "", "", "", "")

        For i = 0 To dataAttn.Rows.Count - 1
            ' attn_in
            If dataAttn.Rows(i)("type_log").ToString = "1" Then
                Dim toDatetime As String = Date.Parse(dataAttn.Rows(i)("datetime").ToString).ToString("yyyy-MM-dd H:mm:ss")
                Dim toDate As String = Date.Parse(dataAttn.Rows(i)("datetime").ToString).ToString("yyyy-MM-dd")

                For j = 0 To dataSchedule.Rows.Count - 1
                    If Not dataSchedule.Rows(j)("in").ToString = "" Then
                        If dataSchedule.Rows(j)("in").ToString.Substring(0, 10) = toDate Then
                            Console.WriteLine("id: " + dataSchedule.Rows(j)("id_schedule").ToString + ", att_in: " + toDatetime)
                        End If
                    End If
                Next
            End If
        Next
    End Sub
End Class