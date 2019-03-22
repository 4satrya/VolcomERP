Public Class ClassInsertAttendance
    Shared Sub insertAttendance()
        Dim dataSchedule As DataTable = execute_query("
            SELECT * 
            FROM tb_emp_schedule 
            WHERE id_employee = 137 AND `date` BETWEEN '2018-08-01' AND '2018-08-31'
            ORDER BY `date` ASC
        ", -1, True, "", "", "", "")

        ' add column
        dataSchedule.Columns.Add("att_in", GetType(String)).SetOrdinal(4)

        Dim dataAttn As DataTable = execute_query("
            SELECT *
            FROM tb_emp_attn
            WHERE id_employee = 137 AND DATE(`datetime`) BETWEEN '2018-08-01' AND '2018-08-31'
            ORDER BY `datetime` ASC
        ", -1, True, "", "", "", "")

        For i = 0 To dataAttn.Rows.Count - 1
            Dim attDt As String = Date.Parse(dataAttn.Rows(i)("datetime").ToString).ToString("yyyy-MM-dd H:mm:ss")
            Dim attD As String = Date.Parse(dataAttn.Rows(i)("datetime").ToString).ToString("yyyy-MM-dd")

            For j = 0 To dataSchedule.Rows.Count - 1
                Dim schD As String = ""
                Dim schInDt As String = ""
                Dim schInD As String = ""

                Try
                    schD = Date.Parse(dataSchedule.Rows(j)("date").ToString).ToString("yyyy-MM-dd")
                    schInDt = Date.Parse(dataSchedule.Rows(j)("in").ToString).ToString("yyyy-MM-dd H:mm:ss")
                    schInD = Date.Parse(dataSchedule.Rows(j)("in").ToString).ToString("yyyy-MM-dd")
                Catch ex As Exception
                End Try

                If schInD = "" Then
                    ' by schedule date
                    If schD = attD Then
                        If dataSchedule.Rows(j)("att_in").ToString = "" Then
                            dataSchedule.Rows(j)("att_in") = attDt
                        End If
                    End If
                Else
                    ' by schedule in
                    If schInD = attD Then
                        If dataSchedule.Rows(j)("att_in").ToString = "" Then
                            dataSchedule.Rows(j)("att_in") = attDt
                        End If
                    End If
                End If
            Next
        Next


        Dim d As DataTable = dataSchedule


        Console.WriteLine("Stop.")


        Dim dataInserted As New Dictionary(Of String, DataTable)

        For i = 0 To dataSchedule.Rows.Count - 1
            Dim idSch As String = dataSchedule.Rows(i)("id_schedule").ToString

            Dim schD As String = ""
            Dim schInDt As String = ""
            Dim schInD As String = ""

            Try
                schD = Date.Parse(dataSchedule.Rows(i)("date").ToString).ToString("yyyy-MM-dd")
                schInDt = Date.Parse(dataSchedule.Rows(i)("in").ToString).ToString("yyyy-MM-dd H:mm:ss")
                schInD = Date.Parse(dataSchedule.Rows(i)("in").ToString).ToString("yyyy-MM-dd")
            Catch ex As Exception
            End Try

            ' temp datatable
            Dim dataSch As DataTable = New DataTable

            dataSch.Columns.Add("date", GetType(String))
            dataSch.Columns.Add("in", GetType(String))
            dataSch.Columns.Add("att_in", GetType(String))

            dataSch.Rows.Add(schD, schInDt, "")

            ' inser datatable
            dataInserted.Add(idSch, dataSch)

            For j = 0 To dataAttn.Rows.Count - 1
                ' att_in
                If dataAttn.Rows(j)("type_log").ToString = "1" Then
                    Dim attDt As String = Date.Parse(dataAttn.Rows(j)("datetime").ToString).ToString("yyyy-MM-dd H:mm:ss")
                    Dim attD As String = Date.Parse(dataAttn.Rows(j)("datetime").ToString).ToString("yyyy-MM-dd")

                    If schInD = "" Then
                        ' by schedule date
                        If schD = attD Then
                            If dataInserted(idSch).Rows(0)("att_in").ToString = "" Then
                                dataInserted(idSch).Rows(0)("att_in") = attDt
                            End If
                        End If
                    Else
                        ' by schedule in
                        If schInD = attD Then
                            If dataInserted(idSch).Rows(0)("att_in").ToString = "" Then
                                dataInserted(idSch).Rows(0)("att_in") = attDt
                            End If
                        End If
                    End If
                End If
            Next
        Next

        If dataInserted.Count Then

        End If
    End Sub
End Class