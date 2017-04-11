Public Class FormEmpAttn
    Dim fp As New ClassFingerPrint
    Private Sub BGetData_Click(sender As Object, e As EventArgs) Handles BGetData.Click
        Cursor = Cursors.WaitCursor
        get_data()
        Cursor = Cursors.Default
    End Sub

    Sub get_data()
        Dim query As String = "SELECT * FROM tb_m_fingerprint"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")

        Dim string_err As String = ""

        For i As Integer = 0 To data.Rows.Count - 1
            fp.ip = data.Rows(i)("ip").ToString()
            fp.port = data.Rows(i)("port").ToString()

            fp.connect()

            If fp.bIsConnected Then
                fp.get_attlog(data.Rows(i)("id_fingerprint").ToString())
                fp.clear_attlog()
            Else
                If Not i = 0 Then
                    string_err += vbNewLine
                End If
                string_err += "- " & data.Rows(i)("name").ToString()
            End If

            fp.disconnect()
        Next

        If Not string_err = "" Then
            string_err = "Fingerprint not connected : " & string_err
            infoCustom(string_err)
        End If
    End Sub

    Private Sub BView_Click(sender As Object, e As EventArgs) Handles BView.Click
        get_log()
    End Sub

    Sub get_log()
        Dim date_start, date_until As String

        date_start = Date.Parse(DEStart.EditValue.ToString).ToString("yyyy-MM-dd")
        date_until = Date.Parse(DEUntil.EditValue.ToString).ToString("yyyy-MM-dd")

        Dim query As String = "SELECT emp.employee_code,emp.employee_name,att.datetime,type_log.type_log,fp.name AS fp_machine,IF(att.scan_method=1,'Fingerprint','Face') AS scan_method FROM tb_emp_attn att
                                INNER JOIN tb_m_employee emp ON emp.id_employee=att.id_employee
                                INNER JOIN tb_lookup_type_log type_log ON type_log.id_type_log=att.type_log
                                INNER JOIN tb_m_fingerprint fp ON fp.id_fingerprint=att.id_fingerprint
                                WHERE DATE(att.datetime) >='" & date_start & "' AND DATE(att.datetime) <='" & date_until & "'
                                ORDER BY att.datetime ASC"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCLogAttn.DataSource = data
        GVLogAttn.BestFitColumns()
    End Sub

    Private Sub FormEmpAttn_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        DEStart.EditValue = Now
        DEUntil.EditValue = Now
    End Sub

    Private Sub DEStart_EditValueChanged(sender As Object, e As EventArgs) Handles DEStart.EditValueChanged
        Try
            DEUntil.Properties.MinValue = DEStart.EditValue
        Catch ex As Exception
        End Try
    End Sub

    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs) Handles SimpleButton1.Click
        print(GCLogAttn, "List Attendance (Raw)")
    End Sub
End Class