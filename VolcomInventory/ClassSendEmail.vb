Imports System.IO
Imports System.Net.Mail

Public Class ClassSendEmail
    Public id_report As String = "-1"
    Public report_mark_type As String = "-1"

    'comment mail
    Public season As String = ""
    Public date_string As String = ""
    Public comment_by As String = ""
    Public comment As String = ""
    Public design As String = ""

    Sub send_email_html(ByVal send_to As String, ByVal email_to As String, ByVal subject As String, ByVal number As String, ByVal body As String)
        If report_mark_type = "95" Then
            ' Create a new report. 

            'ReportEmpLeave.id_report = id_report
            'ReportEmpLeave.report_mark_type = report_mark_type

            'Dim Report As New ReportEmpLeave()

            ' Create a new memory stream and export the report into it as PDF.
            'Dim Mem As New MemoryStream()
            'Report.ExportToPdf(Mem)

            ' Create a new attachment and put the PDF report into it.
            'Mem.Seek(0, System.IO.SeekOrigin.Begin)
            '
            'Dim Att = New Attachment(Mem, "TestReport.pdf", "application/pdf")
            '
            Dim mail As MailMessage = New MailMessage("septian@volcom.mail", email_to)
            'mail.Attachments.Add(Att)
            Dim client As SmtpClient = New SmtpClient()
            client.Port = 25
            client.DeliveryMethod = SmtpDeliveryMethod.Network
            client.UseDefaultCredentials = False
            client.Host = "192.168.1.4"
            client.Credentials = New System.Net.NetworkCredential("septian@volcom.mail", "septian")
            mail.Subject = subject
            mail.IsBodyHtml = True
            mail.Body = email_body(send_to, subject, number, "Catur")
            client.Send(mail)
        ElseIf report_mark_type = "weekly_attn" Then
            ' Create a new report. 
            Dim quuery_dept As String = "SELECT dept.id_departement,dept.departement,emp.id_employee,emp.email_lokal,emp.employee_name FROM tb_m_departement dept
                                            INNER JOIN tb_m_user usr ON dept.id_user_head=usr.id_user
                                            INNER JOIN tb_m_employee emp ON emp.id_employee=usr.id_employee"
            Dim data_dept As DataTable = execute_query(quuery_dept, -1, True, "", "", "", "")
            For i As Integer = 0 To data_dept.Rows.Count - 1
                ReportEmpAttn.id_dept = data_dept.Rows(i)("id_departement").ToString
                Dim Report As New ReportEmpAttn()

                ' Create a new memory stream and export the report into it as PDF.
                Dim Mem As New MemoryStream()
                Report.ExportToPdf(Mem)

                ' Create a new attachment and put the PDF report into it.
                Mem.Seek(0, System.IO.SeekOrigin.Begin)
                '
                Dim Att = New Attachment(Mem, "Weekly Attendance Report - " & data_dept.Rows(i)("departement").ToString & ".pdf", "application/pdf")
                '
                'Dim mail As MailMessage = New MailMessage("system@volcom.mail", data_dept.Rows(i)("email_lokal").ToString)
                Dim mail As MailMessage = New MailMessage("system@volcom.mail", "septian@volcom.mail")
                mail.Attachments.Add(Att)
                Dim client As SmtpClient = New SmtpClient()
                client.Port = 25
                client.DeliveryMethod = SmtpDeliveryMethod.Network
                client.UseDefaultCredentials = False
                client.Host = "192.168.1.4"
                client.Credentials = New System.Net.NetworkCredential("system@volcom.mail", "system123")
                mail.Subject = "Weekly Attendance Report (" & data_dept.Rows(i)("departement").ToString & ")"
                mail.IsBodyHtml = True
                mail.Body = email_temp(data_dept.Rows(i)("employee_name").ToString)
                client.Send(mail)
            Next
        ElseIf report_mark_type = "monthly_leave_remaining" Then
            ' Create a new report. 
            Dim quuery_dept As String = "SELECT dept.id_departement,dept.departement,emp.id_employee,emp.email_lokal,emp.employee_name FROM tb_m_departement dept
                                            INNER JOIN tb_m_user usr ON dept.id_user_head=usr.id_user
                                            INNER JOIN tb_m_employee emp ON emp.id_employee=usr.id_employee"
            Dim data_dept As DataTable = execute_query(quuery_dept, -1, True, "", "", "", "")
            For i As Integer = 0 To data_dept.Rows.Count - 1
                ReportEmpLeaveStock.id_dept = data_dept.Rows(i)("id_departement").ToString
                Dim Report As New ReportEmpLeaveStock

                ' Create a new memory stream and export the report into it as PDF.
                Dim Mem As New MemoryStream()
                Report.ExportToPdf(Mem)

                ' Create a new attachment and put the PDF report into it.
                Mem.Seek(0, System.IO.SeekOrigin.Begin)
                '
                Dim Att = New Attachment(Mem, "Monthly Leave Remaining Report - " & data_dept.Rows(i)("departement").ToString & ".pdf", "application/pdf")
                '
                'Dim mail As MailMessage = New MailMessage("system@volcom.mail", data_dept.Rows(i)("email_lokal").ToString)
                Dim mail As MailMessage = New MailMessage("system@volcom.mail", "septian@volcom.mail")
                mail.Attachments.Add(Att)
                Dim client As SmtpClient = New SmtpClient()
                client.Port = 25
                client.DeliveryMethod = SmtpDeliveryMethod.Network
                client.UseDefaultCredentials = False
                client.Host = "192.168.1.4"
                client.Credentials = New System.Net.NetworkCredential("system@volcom.mail", "system123")
                mail.Subject = "Monthly Leave Remaining Report (" & data_dept.Rows(i)("departement").ToString & ")"
                mail.IsBodyHtml = True
                mail.Body = email_temp_monthly(data_dept.Rows(i)("employee_name").ToString)
                client.Send(mail)
            Next
        End If
    End Sub
    Sub send_email()
        If report_mark_type = "design_comment" Then
            ' Create a new report. 
            Dim query_send_mail As String = "SELECT emp.`email_lokal`,emp.`employee_name` FROM tb_mail_dsg_cmnt md
                                                INNER JOIN tb_m_user usr ON usr.`id_user`=md.id_user
                                                INNER JOIN tb_m_employee emp ON emp.`id_employee`=usr.`id_employee`"
            Dim data_send_mail As DataTable = execute_query(query_send_mail, -1, True, "", "", "", "")

            Dim from_mail As MailAddress = New MailAddress("system@volcom.mail", "Volcom ERP")
            Dim mail As MailMessage = New MailMessage()
            mail.From = from_mail

            For i As Integer = 0 To data_send_mail.Rows.Count - 1
                Dim to_mail As MailAddress = New MailAddress(data_send_mail.Rows(i)("email_lokal").ToString, data_send_mail.Rows(i)("employee_name").ToString)
                mail.To.Add(to_mail)
            Next

            Dim client As SmtpClient = New SmtpClient()
            client.Port = 25
            client.DeliveryMethod = SmtpDeliveryMethod.Network
            client.UseDefaultCredentials = False
            client.Host = "192.168.1.4"
            client.Credentials = New System.Net.NetworkCredential("system@volcom.mail", "system123")
            mail.Subject = "New comment on design " & design & " (Season : " & season & ")"
            mail.IsBodyHtml = True
            mail.Body = email_body_comment(season, design, comment_by, date_string, comment)
            client.Send(mail)
        End If
    End Sub
    Sub send_email_appr(ByVal report_mark_type As String, ByVal id_leave As String, ByVal is_appr As Boolean)
        '
        Dim query As String = ""
        query = "SELECT empl.*,lt.leave_type,empl.leave_purpose,
                empx.email_lokal AS dept_head_email,empx.id_employee AS id_dep_head,empx.employee_name AS dep_head,
                empa.email_lokal AS asst_dept_head_email,empa.id_employee AS id_asst_dep_head,empa.employee_name AS asst_dep_head,
                empld.min_date,empld.max_date,status.report_status,emp.employee_name,emp.employee_code,empld.hours_total,empl.report_mark_type 
                FROM tb_emp_leave empl
                INNER JOIN tb_lookup_leave_type lt ON lt.id_leave_type=empl.id_leave_type
                INNER JOIN tb_lookup_report_status STATUS ON status.id_report_status=empl.id_report_status
                INNER JOIN tb_m_employee emp ON emp.id_employee=empl.id_emp
                INNER JOIN tb_lookup_employee_level lvl ON lvl.id_employee_level=emp.id_employee_level  
                INNER JOIN tb_m_departement dep ON dep.id_departement=emp.id_departement
                LEFT JOIN tb_m_user usrx ON usrx.id_user=dep.id_user_head
                LEFT JOIN tb_m_employee empx ON empx.id_employee=usrx.id_employee
                LEFT JOIN tb_m_user usra ON usra.id_user=dep.id_user_asst_head
                LEFT JOIN tb_m_employee empa ON empa.id_employee=usra.id_employee
                INNER JOIN 
                (SELECT id_emp_leave,MIN(datetime_start) AS min_date,MAX(datetime_until) AS max_date,ROUND(SUM(minutes_total)/60) AS hours_total FROM tb_emp_leave_det GROUP BY id_emp_leave) empld ON empld.id_emp_leave=empl.id_emp_leave
                WHERE empl.id_emp_leave='" & id_leave & "'"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        Dim emp_leave_type As String = data.Rows(0)("leave_type").ToString
        Dim dep_head As String = data.Rows(0)("dep_head").ToString
        Dim dep_head_email As String = data.Rows(0)("dept_head_email").ToString
        Dim emp_name As String = data.Rows(0)("employee_name").ToString
        Dim leave_no As String = data.Rows(0)("emp_leave_number").ToString
        'to list : dep head 
        Dim to_mail As MailAddress = New MailAddress(dep_head_email, dep_head)
        Dim from_mail As MailAddress = New MailAddress(get_setup_field("system_email").ToString, get_setup_field("app_name").ToString)
        Dim mail As MailMessage = New MailMessage(from_mail, to_mail)
        'add cc asst dept head
        If Not data.Rows(0)("asst_dept_head_email").ToString = "" Then
            Dim cc_asst_dept As MailAddress = New MailAddress(data.Rows(0)("asst_dept_head_email").ToString, data.Rows(0)("asst_dep_head").ToString)
            mail.CC.Add(cc_asst_dept)
        End If
        'add cc list : yg ada di mark semua
        Dim querycc As String = "SELECT emp.email_lokal,emp.employee_name,rm.* FROM tb_report_mark rm 
                                    INNER JOIN tb_m_user usr ON usr.id_user=rm.id_user
                                    INNER JOIN tb_m_employee emp ON emp.id_employee=usr.id_employee
                                    WHERE report_mark_type='" & report_mark_type & "' AND id_report='" & id_leave & "' AND id_report_status='3'"
        Dim datacc As DataTable = execute_query(querycc, -1, True, "", "", "", "")
        If datacc.Rows.Count > 0 Then
            For i As Integer = 0 To datacc.Rows.Count - 1
                Dim cc As MailAddress = New MailAddress(datacc.Rows(i)("email_lokal").ToString, datacc.Rows(i)("employee_name").ToString)
                mail.CC.Add(cc)
            Next
        End If
        'Dim to_mail As MailAddress = New MailAddress("septian@volcom.mail", "Septian Primadewa")
        'Dim from_mail As MailAddress = New MailAddress("system@volcom.mail", "Volcom ERP")
        'Dim mail As MailMessage = New MailMessage(from_mail, to_mail)
        'Dim copy As MailAddress = New MailAddress("catur@volcom.mail", "Triya")
        'mail.CC.Add(copy)
        If is_appr = True Then
            '-- start attachment 
            'Create a New report. 
            ReportEmpLeave.id_report = id_leave
            ReportEmpLeave.report_mark_type = report_mark_type
            Dim Report As New ReportEmpLeave()
            ' Create a new memory stream and export the report into it as PDF.
            Dim Mem As New MemoryStream()
            Report.ExportToPdf(Mem)
            ' Create a new attachment and put the PDF report into it.
            Mem.Seek(0, System.IO.SeekOrigin.Begin)
            Dim Att = New Attachment(Mem, leave_no & " - Request " & emp_leave_type & " - " & emp_name & ".pdf", "application/pdf")
            mail.Attachments.Add(Att)
            '-- end attachment
        End If
        Dim client As SmtpClient = New SmtpClient()
        client.Port = 25
        client.DeliveryMethod = SmtpDeliveryMethod.Network
        client.UseDefaultCredentials = False
        client.Host = get_setup_field("system_email_server").ToString
        client.Credentials = New System.Net.NetworkCredential(get_setup_field("system_email").ToString, get_setup_field("system_email_pass").ToString)
        If is_appr Then
            mail.Subject = "Request " & emp_leave_type & " " & emp_name & " Approved"
        Else
            mail.Subject = "Request " & emp_leave_type & " " & emp_name & " Not Approved"
        End If

        mail.IsBodyHtml = True
        mail.Body = email_appr_body(id_leave, is_appr)
        client.Send(mail)
    End Sub
    Function email_appr_body(ByVal id_leave As String, ByVal is_appr As Boolean)
        Dim query As String = ""
        query = "SELECT empl.*,lt.leave_type,empl.leave_purpose,empx.email_lokal as dept_head_email,empx.id_employee as id_dep_head,empx.employee_name as dep_head,empld.min_date,empld.max_date,status.report_status,emp.employee_name,emp.employee_code,empld.hours_total,empl.report_mark_type 
                FROM tb_emp_leave empl
                INNER JOIN tb_lookup_leave_type lt ON lt.id_leave_type=empl.id_leave_type
                INNER JOIN tb_lookup_report_status STATUS ON status.id_report_status=empl.id_report_status
                INNER JOIN tb_m_employee emp ON emp.id_employee=empl.id_emp
                INNER JOIN tb_lookup_employee_level lvl ON lvl.id_employee_level=emp.id_employee_level  
                INNER JOIN tb_m_departement dep ON dep.id_departement=emp.id_departement
                LEFT JOIN tb_m_user usrx ON usrx.id_user=dep.id_user_head
                LEFT JOIN tb_m_employee empx ON empx.id_employee=usrx.id_employee
                INNER JOIN 
                (SELECT id_emp_leave,MIN(datetime_start) AS min_date,MAX(datetime_until) AS max_date,ROUND(SUM(minutes_total)/60) AS hours_total FROM tb_emp_leave_det GROUP BY id_emp_leave) empld ON empld.id_emp_leave=empl.id_emp_leave
                WHERE empl.id_emp_leave='" & id_leave & "'"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        Dim dept_head As String = data.Rows(0)("dep_head").ToString
        Dim dept_head_email As String = data.Rows(0)("dept_head_email").ToString
        'reject
        Dim report_mark_type As String = data.Rows(0)("report_mark_type").ToString
        Dim reject_by_user As String = ""
        Dim reject_reason As String = ""
        Dim appr_note As String = ""
        If is_appr = False Then
            Dim query_appr As String = "SELECT rm.*,emp.employee_name FROM tb_report_mark rm INNER JOIN tb_m_user usr ON usr.id_user=rm.id_user INNER JOIN tb_m_employee emp ON emp.id_employee=usr.id_employee WHERE rm.report_mark_type='" & report_mark_type & "' AND rm.id_report='" & id_leave & "' AND rm.id_mark='3'"
            Dim data_appr As DataTable = execute_query(query_appr, -1, True, "", "", "", "")
            reject_by_user = data_appr.Rows(0)("employee_name").ToString
            reject_reason = data_appr.Rows(0)("report_mark_note").ToString
        Else
            Dim query_appr As String = "SELECT rm.*,emp.employee_name FROM tb_report_mark rm INNER JOIN tb_m_user usr ON usr.id_user=rm.id_user INNER JOIN tb_m_employee emp ON emp.id_employee=usr.id_employee WHERE rm.report_mark_type='" & report_mark_type & "' AND rm.id_report='" & id_leave & "' AND rm.id_mark='2'"
            Dim data_appr As DataTable = execute_query(query_appr, -1, True, "", "", "", "")
            If data_appr.Rows.Count <= 0 Then
                appr_note = ""
            Else
                For i As Integer = 0 To data_appr.Rows.Count - 1
                    If Not data_appr.Rows(i)("report_mark_note").ToString = "" Then
                        If Not appr_note = "" Then
                            appr_note += "<br/>"
                        End If
                        appr_note += "(" & data_appr.Rows(i)("employee_name").ToString & ")" & data_appr.Rows(i)("report_mark_note").ToString
                    End If
                Next
            End If

        End If
        '
        Dim leave_no As String = data.Rows(0)("emp_leave_number").ToString
        Dim leave_datetime As String = Date.Parse(data.Rows(0)("min_date").ToString).ToString("dd MMMM yyyy HH:mm") & " until " & Date.Parse(data.Rows(0)("max_date").ToString).ToString("dd MMMM yyyy HH:mm")
        Dim employee_name As String = data.Rows(0)("employee_name").ToString
        Dim leave_purpose As String = data.Rows(0)("leave_purpose").ToString
        Dim leave_type As String = data.Rows(0)("leave_type").ToString
        '
        Dim body_temp As String = ""
        body_temp = "<table class='m_1811720018273078822MsoNormalTable' border='0' cellspacing='0' cellpadding='0' width='100%' style='width:100.0%;background:#eeeeee'>
                     <tbody><tr>
                      <td style='padding:30.0pt 30.0pt 30.0pt 30.0pt'>
                      <div align='center'>

                      <table class='m_1811720018273078822MsoNormalTable' border='0' cellspacing='0' cellpadding='0' width='600' style='width:6.25in;background:white'>
                       <tbody><tr>
                        <td style='padding:0in 0in 0in 0in'></td>
                       </tr>
                       <tr>
                        <td style='padding:0in 0in 0in 0in'>
                        <p class='MsoNormal' align='center' style='text-align:center'><a href='http://www.volcom.co.id/' title='Volcom' target='_blank' data-saferedirecturl='https://www.google.com/url?hl=en&amp;q=http://www.volcom.co.id/&amp;source=gmail&amp;ust=1480121870771000&amp;usg=AFQjCNEjXvEZWgDdR-Wlke7nn0fmc1ZUuA'><span style='text-decoration:none'><img border='0' width='180' id='m_1811720018273078822_x0000_i1025' src='https://ci3.googleusercontent.com/proxy/x-zXDZUS-2knkEkbTh3HzgyAAusw1Wz7dqV-lbnl39W_4F6T97fJ2_b9doP3nYi0B6KHstdb-tK8VAF_kOaLt2OH=s0-d-e1-ft#http://www.volcom.co.id/enews/img/volcom.jpg' alt='Volcom' class='CToWUd'></span></a><u></u><u></u></p>
                        </td>
                       </tr>
                       <tr>
                        <td style='padding:0in 0in 0in 0in'></td>
                       </tr>
                       <tr>
                        <td style='padding:0in 0in 0in 0in'>
                        <table class='m_1811720018273078822MsoNormalTable' border='0' cellspacing='0' cellpadding='0' width='600' style='width:6.25in;background:white'>
                         <tbody><tr>
                          <td style='padding:0in 0in 0in 0in'>
      
                          </td>
                         </tr>
                        </tbody></table>
                        <p class='MsoNormal' style='background-color:#eff0f1'><span style='display:block;background-color:#eff0f1;height: 5px;'><u></u>&nbsp;<u></u></span></p>
                        <p class='MsoNormal'><span style='display:none'><u></u>&nbsp;<u></u></span></p>
                        <table class='m_1811720018273078822MsoNormalTable' border='0' cellspacing='0' cellpadding='0' style='background:white'>
                         <tbody>
                         <tr>
                          <td style='padding:15.0pt 15.0pt 15.0pt 15.0pt' colspan='3'>
                          <div>
                          <p class='MsoNormal' style='line-height:14.25pt'><b><span style='font-family:&quot;Arial&quot;,&quot;sans-serif&quot;;color:#606060'>Dear " & dept_head & ",</span></b><span style='font-size:10.0pt;font-family:&quot;Arial&quot;,&quot;sans-serif&quot;;color:#606060;letter-spacing:.4pt'><u></u><u></u></span></p>
                          </div>
                          </td>
                         </tr>
                         <tr>
                          <td style='padding:15.0pt 15.0pt 8.0pt 15.0pt' colspan='3'>
                          <div>
                          <p class='MsoNormal' style='line-height:14.25pt'><span style='font-size:10.0pt;font-family:&quot;Arial&quot;,&quot;sans-serif&quot;;color:#606060;letter-spacing:.4pt'>" & leave_type & " request with detail below, </span></b><span style='font-size:10.0pt;font-family:&quot;Arial&quot;,&quot;sans-serif&quot;;color:#606060;letter-spacing:.4pt'><u></u><u></u></span>
                          </div>
                          </td>
                         </tr>
                         <tr>
                          <td style='padding:1.0pt 1.0pt 1.0pt 15.0pt'>
                          <div>
                          <p class='MsoNormal' style='line-height:14.25pt'>
                            <span style='font-size:10.0pt;font-family:&quot;Arial&quot;,&quot;sans-serif&quot;;color:#606060;letter-spacing:.4pt'>Number
                              
                            </span>
                          </p>

                          </div>
                          </td>
                          <td style='padding:1.0pt 1.0pt 1.0pt 10.0pt'>
                          <div>
                          <p class='MsoNormal' style='line-height:14.25pt'>
                            <span style='font-size:10.0pt;font-family:&quot;Arial&quot;,&quot;sans-serif&quot;;color:#606060;letter-spacing:.4pt'>:
                              
                            </span>
                          </p>

                          </div>
                          </td>
                          <td style='padding:1.0pt 1.0pt 1.0pt 10.0pt'>
                          <div>
                          <p class='MsoNormal' style='line-height:14.25pt'>
                            <span style='font-size:10.0pt;font-family:&quot;Arial&quot;,&quot;sans-serif&quot;;color:#606060;letter-spacing:.4pt'>" & leave_no & "
                              
                            </span>
                          </p>

                          </div>
                          </td>
                         </tr>
                         <tr>
                          <td style='padding:1.0pt 1.0pt 1.0pt 15.0pt'>
                            <span style='font-size:10.0pt;font-family:&quot;Arial&quot;,&quot;sans-serif&quot;;color:#606060;letter-spacing:.4pt'>Proposed By
                            </span>
                          </td>
                          <td style='padding:1.0pt 1.0pt 1.0pt 10.0pt'>
                          <div>
                          <p class='MsoNormal' style='line-height:14.25pt'>
                            <span style='font-size:10.0pt;font-family:&quot;Arial&quot;,&quot;sans-serif&quot;;color:#606060;letter-spacing:.4pt'>:
                              
                            </span>
                          </p>

                          </div>
                          </td>
                          <td style='padding:1.0pt 1.0pt 1.0pt 10.0pt'>
                          <div>
                          <p class='MsoNormal' style='line-height:14.25pt'>
                            <span style='font-size:10.0pt;font-family:&quot;Arial&quot;,&quot;sans-serif&quot;;color:#606060;letter-spacing:.4pt'>" & employee_name & "
                            </span>
                          </p>
                          </div>
                          </td>
                         </tr>
                         <tr>
                          <td style='padding:1.0pt 1.0pt 1.0pt 15.0pt'>
                            <span style='font-size:10.0pt;font-family:&quot;Arial&quot;,&quot;sans-serif&quot;;color:#606060;letter-spacing:.4pt'>Periode
                            </span>
                          </td>
                          <td style='padding:1.0pt 1.0pt 1.0pt 10.0pt'>
                          <div>
                          <p class='MsoNormal' style='line-height:14.25pt'>
                            <span style='font-size:10.0pt;font-family:&quot;Arial&quot;,&quot;sans-serif&quot;;color:#606060;letter-spacing:.4pt'>:
                              
                            </span>
                          </p>

                          </div>
                          </td>
                          <td style='padding:1.0pt 1.0pt 1.0pt 10.0pt'>
                          <div>
                          <p class='MsoNormal' style='line-height:14.25pt'>
                            <span style='font-size:10.0pt;font-family:&quot;Arial&quot;,&quot;sans-serif&quot;;color:#606060;letter-spacing:.4pt'>" & leave_datetime & "
                            </span>
                          </p>
                          </div>
                          </td>
                         </tr>
                         <tr>
                          <td style='padding:1.0pt 1.0pt 1.0pt 15.0pt'>
                            <span style='font-size:10.0pt;font-family:&quot;Arial&quot;,&quot;sans-serif&quot;;color:#606060;letter-spacing:.4pt'>Purpose
                            </span>
                          </td>
                          <td style='padding:1.0pt 1.0pt 1.0pt 10.0pt'>
                          <div>
                          <p class='MsoNormal' style='line-height:14.25pt'>
                            <span style='font-size:10.0pt;font-family:&quot;Arial&quot;,&quot;sans-serif&quot;;color:#606060;letter-spacing:.4pt'>:
                              
                            </span>
                          </p>

                          </div>
                          </td>
                          <td style='padding:1.0pt 1.0pt 1.0pt 10.0pt'>
                          <div>
                          <p class='MsoNormal' style='line-height:14.25pt'>
                            <span style='font-size:10.0pt;font-family:&quot;Arial&quot;,&quot;sans-serif&quot;;color:#606060;letter-spacing:.4pt'>" & leave_purpose & "
                            </span>
                          </p>
                          </div>
                          </td>
                         </tr>"
        If is_appr = True Then
            body_temp += "<tr>
                          <td style='padding:15.0pt 15.0pt 8.0pt 15.0pt' colspan='3'>
                          <div>
                          <p class='MsoNormal' style='line-height:14.25pt'><span style='font-size:10.0pt;font-family:&quot;Arial&quot;,&quot;sans-serif&quot;;color:#606060;letter-spacing:.4pt'>The request has been <b><u>approved</u></b>.</span></b><span style='font-size:10.0pt;font-family:&quot;Arial&quot;,&quot;sans-serif&quot;;color:#606060;letter-spacing:.4pt'><u></u><u></u></span>
                          </div>
                          </td>
                         </tr>"
            If Not appr_note = "" Then
                body_temp += "<tr>
                          <td style='padding:1.0pt 1.0pt 1.0pt 15.0pt'>
                        
                            <span style='font-size:10.0pt;font-family:&quot;Arial&quot;,&quot;sans-serif&quot;;color:#606060;letter-spacing:.4pt'>Note
                              
                            </span>

                          
                          </td>
                          <td style='padding:1.0pt 1.0pt 1.0pt 10.0pt'>
                          <div>
                          <p class='MsoNormal' style='line-height:14.25pt'>
                            <span style='font-size:10.0pt;font-family:&quot;Arial&quot;,&quot;sans-serif&quot;;color:#606060;letter-spacing:.4pt'>:
                              
                            </span>
                          </p>

                          </div>
                          </td>
                          <td style='padding:1.0pt 1.0pt 1.0pt 10.0pt'>
                          <div>
                          <p class='MsoNormal' style='line-height:14.25pt'>
                            <span style='font-size:10.0pt;font-family:&quot;Arial&quot;,&quot;sans-serif&quot;;color:#606060;letter-spacing:.4pt'>" & appr_note & "
                            </span>
                          </p>
                          </div>
                          </td>
                         </tr>"
            End If
        Else
            body_temp += "<tr>
                              <td style='padding:15.0pt 15.0pt 8.0pt 15.0pt' colspan='3'>
                              <div>
                              <p class='MsoNormal' style='line-height:14.25pt'><span style='font-size:10.0pt;font-family:&quot;Arial&quot;,&quot;sans-serif&quot;;color:#606060;letter-spacing:.4pt'>The request <b><u>not approved</u></b>.</span></b><span style='font-size:10.0pt;font-family:&quot;Arial&quot;,&quot;sans-serif&quot;;color:#606060;letter-spacing:.4pt'><u></u><u></u></span>
                              </div>
                              </td>
                         </tr>
                         <tr>
                             <td style='padding:1.0pt 1.0pt 1.0pt 15.0pt'>
                                <span style='font-size:10.0pt;font-family:&quot;Arial&quot;,&quot;sans-serif&quot;;color:#606060;letter-spacing:.4pt'>By
                                </span>
                              </td>
                              <td style='padding:1.0pt 1.0pt 1.0pt 10.0pt'>
                              <div>
                              <p class='MsoNormal' style='line-height:14.25pt'>
                                <span style='font-size:10.0pt;font-family:&quot;Arial&quot;,&quot;sans-serif&quot;;color:#606060;letter-spacing:.4pt'>:
                              
                                </span>
                              </p>

                              </div>
                              </td>
                              <td style='padding:1.0pt 1.0pt 1.0pt 10.0pt'>
                              <div>
                              <p class='MsoNormal' style='line-height:14.25pt'>
                                <span style='font-size:10.0pt;font-family:&quot;Arial&quot;,&quot;sans-serif&quot;;color:#606060;letter-spacing:.4pt'>" & reject_by_user & "
                                </span>
                              </p>
                              </div>
                             </td>
                         </tr>
                         <tr>
                          <td style='padding:1.0pt 1.0pt 1.0pt 15.0pt'>
                        
                            <span style='font-size:10.0pt;font-family:&quot;Arial&quot;,&quot;sans-serif&quot;;color:#606060;letter-spacing:.4pt'>Note
                              
                            </span>

                          
                          </td>
                          <td style='padding:1.0pt 1.0pt 1.0pt 10.0pt'>
                          <div>
                          <p class='MsoNormal' style='line-height:14.25pt'>
                            <span style='font-size:10.0pt;font-family:&quot;Arial&quot;,&quot;sans-serif&quot;;color:#606060;letter-spacing:.4pt'>:
                              
                            </span>
                          </p>

                          </div>
                          </td>
                          <td style='padding:1.0pt 1.0pt 1.0pt 10.0pt'>
                          <div>
                          <p class='MsoNormal' style='line-height:14.25pt'>
                            <span style='font-size:10.0pt;font-family:&quot;Arial&quot;,&quot;sans-serif&quot;;color:#606060;letter-spacing:.4pt'>" & reject_reason & "
                            </span>
                          </p>
                          </div>
                          </td>
                         </tr>"
        End If

        body_temp += "<tr>
                          <td style='padding:15.0pt 15.0pt 15.0pt 15.0pt' colspan='3'>
                          <div>
                          <p class='MsoNormal' style='line-height:14.25pt'><span style='font-size:10.0pt;font-family:&quot;Arial&quot;,&quot;sans-serif&quot;;color:#606060;letter-spacing:.4pt'>Thank you<br /><b>Volcom ERP</b><u></u><u></u></span></p>

                          </div>
                          </td>
                         </tr>
                        </tbody></table>
                        <p class='MsoNormal' style='background-color:#eff0f1'><span style='display:block;height: 10px;'><u></u>&nbsp;<u></u></span></p>
                        <p class='MsoNormal'><span style='display:none'><u></u>&nbsp;<u></u></span></p>
                        <div align='center'>
                        <table class='m_1811720018273078822MsoNormalTable' border='0' cellspacing='0' cellpadding='0' style='background:white'>
                         <tbody><tr>
                          <td style='padding:6.0pt 6.0pt 6.0pt 6.0pt;text-align:center;'>
                            <span style='text-align:center;font-size:7.0pt;font-family:&quot;Arial&quot;,&quot;sans-serif&quot;;color:#a0a0a0;letter-spacing:.4pt;'>This email send directly from system. Do not reply.</b><u></u><u></u></span>
                          <p class='MsoNormal' align='center' style='margin-bottom:12.0pt;text-align:center;padding-top:0px;'><img border='0' width='300' id='m_1811720018273078822_x0000_i1028' src='https://ci6.googleusercontent.com/proxy/xq6o45mp_D9Z7DHCK5WT7GKuQ2QDaLg1hyMxoHX5ofUIv_m7GwasoczpbAOn6l6Ze-UfLuIUAndSokPvO633nnO9=s0-d-e1-ft#http://www.volcom.co.id/enews/img/footer.jpg' class='CToWUd'><u></u><u></u></p>
                          </td>
                         </tr>
                        </tbody></table>
                        </div>
                        </td>
                       </tr>
                      </tbody></table>
                      </div>
                      </td>
                     </tr>
                    </tbody></table>"
        Return body_temp
    End Function
    Function email_body_comment(ByVal season As String, ByVal design_name As String, ByVal comment_by As String, ByVal date_string As String, ByVal comment As String)
        Dim body_temp As String = ""
        body_temp = "<table class='m_1811720018273078822MsoNormalTable' border='0' cellspacing='0' cellpadding='0' width='100%' style='width:100.0%;background:#eeeeee'>
                     <tbody><tr>
                      <td style='padding:30.0pt 30.0pt 30.0pt 30.0pt'>
                      <div align='center'>

                      <table class='m_1811720018273078822MsoNormalTable' border='0' cellspacing='0' cellpadding='0' width='600' style='width:6.25in;background:white'>
                       <tbody><tr>
                        <td style='padding:0in 0in 0in 0in'></td>
                       </tr>
                       <tr>
                        <td style='padding:0in 0in 0in 0in'>
                        <p class='MsoNormal' align='center' style='text-align:center'><a href='http://www.volcom.co.id/' title='Volcom' target='_blank' data-saferedirecturl='https://www.google.com/url?hl=en&amp;q=http://www.volcom.co.id/&amp;source=gmail&amp;ust=1480121870771000&amp;usg=AFQjCNEjXvEZWgDdR-Wlke7nn0fmc1ZUuA'><span style='text-decoration:none'><img border='0' width='180' id='m_1811720018273078822_x0000_i1025' src='https://ci3.googleusercontent.com/proxy/x-zXDZUS-2knkEkbTh3HzgyAAusw1Wz7dqV-lbnl39W_4F6T97fJ2_b9doP3nYi0B6KHstdb-tK8VAF_kOaLt2OH=s0-d-e1-ft#http://www.volcom.co.id/enews/img/volcom.jpg' alt='Volcom' class='CToWUd'></span></a><u></u><u></u></p>
                        </td>
                       </tr>
                       <tr>
                        <td style='padding:0in 0in 0in 0in'></td>
                       </tr>
                       <tr>
                        <td style='padding:0in 0in 0in 0in'>
                        <table class='m_1811720018273078822MsoNormalTable' border='0' cellspacing='0' cellpadding='0' width='600' style='width:6.25in;background:white'>
                         <tbody><tr>
                          <td style='padding:0in 0in 0in 0in'>
      
                          </td>
                         </tr>
                        </tbody></table>
                        <p class='MsoNormal' style='background-color:#eff0f1'><span style='display:block;background-color:#eff0f1;height: 5px;'><u></u>&nbsp;<u></u></span></p>
                        <p class='MsoNormal'><span style='display:none'><u></u>&nbsp;<u></u></span></p>
                        <table class='m_1811720018273078822MsoNormalTable' border='0' cellspacing='0' cellpadding='0' style='background:white'>
                         <tbody>
                         <tr>
                          <td style='padding:15.0pt 15.0pt 15.0pt 15.0pt' colspan='3'>
                          <div>
                          <p class='MsoNormal' style='line-height:14.25pt'><b><span style='font-family:&quot;Arial&quot;,&quot;sans-serif&quot;;color:#606060'>Dear All,</span></b><span style='font-size:10.0pt;font-family:&quot;Arial&quot;,&quot;sans-serif&quot;;color:#606060;letter-spacing:.4pt'><u></u><u></u></span></p>
                          </div>
                          </td>
                         </tr>
                         <tr>
                          <td style='padding:15.0pt 15.0pt 8.0pt 15.0pt' colspan='3'>
                          <div>
                          <p class='MsoNormal' style='line-height:14.25pt'><span style='font-size:10.0pt;font-family:&quot;Arial&quot;,&quot;sans-serif&quot;;color:#606060;letter-spacing:.4pt'>New comment with detail below, </span></b><span style='font-size:10.0pt;font-family:&quot;Arial&quot;,&quot;sans-serif&quot;;color:#606060;letter-spacing:.4pt'><u></u><u></u></span>
                          </div>
                          </td>
                         </tr>
                         <tr>
                          <td style='padding:1.0pt 1.0pt 1.0pt 15.0pt'>
                          <div>
                          <p class='MsoNormal' style='line-height:14.25pt'>
                            <span style='font-size:10.0pt;font-family:&quot;Arial&quot;,&quot;sans-serif&quot;;color:#606060;letter-spacing:.4pt'>Datetime
                              
                            </span>
                          </p>

                          </div>
                          </td>
                          <td style='padding:1.0pt 1.0pt 1.0pt 10.0pt'>
                          <div>
                          <p class='MsoNormal' style='line-height:14.25pt'>
                            <span style='font-size:10.0pt;font-family:&quot;Arial&quot;,&quot;sans-serif&quot;;color:#606060;letter-spacing:.4pt'>:
                              
                            </span>
                          </p>

                          </div>
                          </td>
                          <td style='padding:1.0pt 1.0pt 1.0pt 10.0pt'>
                          <div>
                          <p class='MsoNormal' style='line-height:14.25pt'>
                            <span style='font-size:10.0pt;font-family:&quot;Arial&quot;,&quot;sans-serif&quot;;color:#606060;letter-spacing:.4pt'>" & date_string & "
                              
                            </span>
                          </p>

                          </div>
                          </td>
                         </tr>
			 <tr>
                          <td style='padding:1.0pt 1.0pt 1.0pt 15.0pt'>
                          <div>
                          <p class='MsoNormal' style='line-height:14.25pt'>
                            <span style='font-size:10.0pt;font-family:&quot;Arial&quot;,&quot;sans-serif&quot;;color:#606060;letter-spacing:.4pt'>Season
                              
                            </span>
                          </p>

                          </div>
                          </td>
                          <td style='padding:1.0pt 1.0pt 1.0pt 10.0pt'>
                          <div>
                          <p class='MsoNormal' style='line-height:14.25pt'>
                            <span style='font-size:10.0pt;font-family:&quot;Arial&quot;,&quot;sans-serif&quot;;color:#606060;letter-spacing:.4pt'>:
                              
                            </span>
                          </p>

                          </div>
                          </td>
                          <td style='padding:1.0pt 1.0pt 1.0pt 10.0pt'>
                          <div>
                          <p class='MsoNormal' style='line-height:14.25pt'>
                            <span style='font-size:10.0pt;font-family:&quot;Arial&quot;,&quot;sans-serif&quot;;color:#606060;letter-spacing:.4pt'>" & season & "
                              
                            </span>
                          </p>

                          </div>
                          </td>
                         </tr>
                         <tr>
                          <td style='padding:1.0pt 1.0pt 1.0pt 15.0pt'>
                            <span style='font-size:10.0pt;font-family:&quot;Arial&quot;,&quot;sans-serif&quot;;color:#606060;letter-spacing:.4pt'>Design
                            </span>
                          </td>
                          <td style='padding:1.0pt 1.0pt 1.0pt 10.0pt'>
                          <div>
                          <p class='MsoNormal' style='line-height:14.25pt'>
                            <span style='font-size:10.0pt;font-family:&quot;Arial&quot;,&quot;sans-serif&quot;;color:#606060;letter-spacing:.4pt'>:
                              
                            </span>
                          </p>

                          </div>
                          </td>
                          <td style='padding:1.0pt 1.0pt 1.0pt 10.0pt'>
                          <div>
                          <p class='MsoNormal' style='line-height:14.25pt'>
                            <span style='font-size:10.0pt;font-family:&quot;Arial&quot;,&quot;sans-serif&quot;;color:#606060;letter-spacing:.4pt'>" & design_name & "
                            </span>
                          </p>
                          </div>
                          </td>
                         </tr>
                         <tr>
                          <td style='padding:1.0pt 1.0pt 1.0pt 15.0pt'>
                            <span style='font-size:10.0pt;font-family:&quot;Arial&quot;,&quot;sans-serif&quot;;color:#606060;letter-spacing:.4pt'>By
                            </span>
                          </td>
                          <td style='padding:1.0pt 1.0pt 1.0pt 10.0pt'>
                          <div>
                          <p class='MsoNormal' style='line-height:14.25pt'>
                            <span style='font-size:10.0pt;font-family:&quot;Arial&quot;,&quot;sans-serif&quot;;color:#606060;letter-spacing:.4pt'>:
                              
                            </span>
                          </p>

                          </div>
                          </td>
                          <td style='padding:1.0pt 1.0pt 1.0pt 10.0pt'>
                          <div>
                          <p class='MsoNormal' style='line-height:14.25pt'>
                            <span style='font-size:10.0pt;font-family:&quot;Arial&quot;,&quot;sans-serif&quot;;color:#606060;letter-spacing:.4pt'>" & comment_by & "
                            </span>
                          </p>
                          </div>
                          </td>
                         </tr>
                         <tr>
                          <td style='padding:1.0pt 1.0pt 1.0pt 15.0pt'>
                            <span style='font-size:10.0pt;font-family:&quot;Arial&quot;,&quot;sans-serif&quot;;color:#606060;letter-spacing:.4pt'>Comment
                            </span>
                          </td>
                          <td style='padding:1.0pt 1.0pt 1.0pt 10.0pt'>
                          <div>
                          <p class='MsoNormal' style='line-height:14.25pt'>
                            <span style='font-size:10.0pt;font-family:&quot;Arial&quot;,&quot;sans-serif&quot;;color:#606060;letter-spacing:.4pt'>:
                              
                            </span>
                          </p>

                          </div>
                          </td>
                          <td style='padding:1.0pt 1.0pt 1.0pt 10.0pt'>
                          <div>
                          <p class='MsoNormal' style='line-height:14.25pt;text-align:justify''>
                            <span style='font-size:10.0pt;font-family:&quot;Arial&quot;,&quot;sans-serif&quot;;color:#606060;letter-spacing:.4pt'>" & comment & "
			    
			    </span>
                          </p>

                          </div>
                          </td>
                         </tr>
                         <tr>
                          <td style='padding:15.0pt 15.0pt 15.0pt 15.0pt' colspan='3'>
                          <div>
                          <p class='MsoNormal' style='line-height:14.25pt'><span style='font-size:10.0pt;font-family:&quot;Arial&quot;,&quot;sans-serif&quot;;color:#606060;letter-spacing:.4pt'>Thank you<br /><b>Volcom ERP</b><u></u><u></u></span></p>

                          </div>
                          </td>
                         </tr>
                        </tbody></table>
                        <p class='MsoNormal' style='background-color:#eff0f1'><span style='display:block;height: 10px;'><u></u>&nbsp;<u></u></span></p>
                        <p class='MsoNormal'><span style='display:none'><u></u>&nbsp;<u></u></span></p>
                        <div align='center'>
                        <table class='m_1811720018273078822MsoNormalTable' border='0' cellspacing='0' cellpadding='0' style='background:white'>
                         <tbody><tr>
                          <td style='padding:6.0pt 6.0pt 6.0pt 6.0pt;text-align:center;'>
                            <span style='text-align:center;font-size:7.0pt;font-family:&quot;Arial&quot;,&quot;sans-serif&quot;;color:#a0a0a0;letter-spacing:.4pt;'>This email send directly from system. Do not reply.</b><u></u><u></u></span>
                          <p class='MsoNormal' align='center' style='margin-bottom:12.0pt;text-align:center;padding-top:0px;'><img border='0' width='300' id='m_1811720018273078822_x0000_i1028' src='https://ci6.googleusercontent.com/proxy/xq6o45mp_D9Z7DHCK5WT7GKuQ2QDaLg1hyMxoHX5ofUIv_m7GwasoczpbAOn6l6Ze-UfLuIUAndSokPvO633nnO9=s0-d-e1-ft#http://www.volcom.co.id/enews/img/footer.jpg' class='CToWUd'><u></u><u></u></p>
                          </td>
                         </tr>
                        </tbody></table>
                        </div>
                        </td>
                       </tr>
                      </tbody></table>
                      </div>
                      </td>
                     </tr>
                    </tbody></table>"
        Return body_temp
    End Function
    Function email_temp(ByVal employee_name As String)
        Dim body_temp As String = ""
        body_temp = "<table class='m_1811720018273078822MsoNormalTable' border='0' cellspacing='0' cellpadding='0' width='100%' style='width:100.0%;background:#eeeeee'>
                     <tbody><tr>
                      <td style='padding:30.0pt 30.0pt 30.0pt 30.0pt'>
                      <div align='center'>

                      <table class='m_1811720018273078822MsoNormalTable' border='0' cellspacing='0' cellpadding='0' width='600' style='width:6.25in;background:white'>
                       <tbody><tr>
                        <td style='padding:0in 0in 0in 0in'></td>
                       </tr>
                       <tr>
                        <td style='padding:0in 0in 0in 0in'>
                        <p class='MsoNormal' align='center' style='text-align:center'><a href='http://www.volcom.co.id/' title='Volcom' target='_blank' data-saferedirecturl='https://www.google.com/url?hl=en&amp;q=http://www.volcom.co.id/&amp;source=gmail&amp;ust=1480121870771000&amp;usg=AFQjCNEjXvEZWgDdR-Wlke7nn0fmc1ZUuA'><span style='text-decoration:none'><img border='0' width='180' id='m_1811720018273078822_x0000_i1025' src='https://ci3.googleusercontent.com/proxy/x-zXDZUS-2knkEkbTh3HzgyAAusw1Wz7dqV-lbnl39W_4F6T97fJ2_b9doP3nYi0B6KHstdb-tK8VAF_kOaLt2OH=s0-d-e1-ft#http://www.volcom.co.id/enews/img/volcom.jpg' alt='Volcom' class='CToWUd'></span></a><u></u><u></u></p>
                        </td>
                       </tr>
                       <tr>
                        <td style='padding:0in 0in 0in 0in'></td>
                       </tr>
                       <tr>
                        <td style='padding:0in 0in 0in 0in'>
                        <table class='m_1811720018273078822MsoNormalTable' border='0' cellspacing='0' cellpadding='0' width='600' style='width:6.25in;background:white'>
                         <tbody><tr>
                          <td style='padding:0in 0in 0in 0in'>
      
                          </td>
                         </tr>
                        </tbody></table>
                        <p class='MsoNormal' style='background-color:#eff0f1'><span style='display:block;background-color:#eff0f1;height: 5px;'><u></u>&nbsp;<u></u></span></p>
                        <p class='MsoNormal'><span style='display:none'><u></u>&nbsp;<u></u></span></p>
                        <table class='m_1811720018273078822MsoNormalTable' border='0' cellspacing='0' cellpadding='0' style='background:white'>
                         <tbody><tr>
                          <td style='padding:15.0pt 15.0pt 15.0pt 15.0pt'>
                          <div>
                          <p class='MsoNormal' style='line-height:14.25pt'><b><span style='font-family:&quot;Arial&quot;,&quot;sans-serif&quot;;color:#606060'>Dear " & employee_name & ",</span></b><span style='font-size:10.0pt;font-family:&quot;Arial&quot;,&quot;sans-serif&quot;;color:#606060;letter-spacing:.4pt'><u></u><u></u></span></p>
                          <p class='MsoNormal' style='line-height:14.25pt'><span style='font-size:10.0pt;font-family:&quot;Arial&quot;,&quot;sans-serif&quot;;color:#606060;letter-spacing:.4pt'>Here's your weekly attendance report for your department. Please see attachment.
                    <u></u><u></u></span></p>
                          <p class='MsoNormal' style='line-height:14.25pt'><span style='font-size:10.0pt;font-family:&quot;Arial&quot;,&quot;sans-serif&quot;;color:#606060;letter-spacing:.4pt'>Thank you<br /><b>Volcom ERP</b><u></u><u></u></span></p>

                          </div>
                          </div>
                          </td>
                         </tr>
                        </tbody></table>
                        <p class='MsoNormal' style='background-color:#eff0f1'><span style='display:block;height: 10px;'><u></u>&nbsp;<u></u></span></p>
                        <p class='MsoNormal'><span style='display:none'><u></u>&nbsp;<u></u></span></p>
                        <div align='center'>
                        <table class='m_1811720018273078822MsoNormalTable' border='0' cellspacing='0' cellpadding='0' style='background:white'>
                         <tbody><tr>
                          <td style='padding:6.0pt 6.0pt 6.0pt 6.0pt;text-align:center;'>
                            <span style='text-align:center;font-size:7.0pt;font-family:&quot;Arial&quot;,&quot;sans-serif&quot;;color:#a0a0a0;letter-spacing:.4pt;'>This email send directly from system. Do not reply.</b><u></u><u></u></span>
                          <p class='MsoNormal' align='center' style='margin-bottom:12.0pt;text-align:center;padding-top:0px;'><img border='0' width='300' id='m_1811720018273078822_x0000_i1028' src='https://ci6.googleusercontent.com/proxy/xq6o45mp_D9Z7DHCK5WT7GKuQ2QDaLg1hyMxoHX5ofUIv_m7GwasoczpbAOn6l6Ze-UfLuIUAndSokPvO633nnO9=s0-d-e1-ft#http://www.volcom.co.id/enews/img/footer.jpg' class='CToWUd'><u></u><u></u></p>
                          </td>
                         </tr>
                        </tbody></table>

                        </div>
                        </td>
                       </tr>
                      </tbody></table>
                      </div>
                      </td>
                     </tr>
                    </tbody></table>"
        Return body_temp
    End Function
    Function email_temp_monthly(ByVal employee_name As String)
        Dim body_temp As String = ""
        body_temp = "<table class='m_1811720018273078822MsoNormalTable' border='0' cellspacing='0' cellpadding='0' width='100%' style='width:100.0%;background:#eeeeee'>
                     <tbody><tr>
                      <td style='padding:30.0pt 30.0pt 30.0pt 30.0pt'>
                      <div align='center'>

                      <table class='m_1811720018273078822MsoNormalTable' border='0' cellspacing='0' cellpadding='0' width='600' style='width:6.25in;background:white'>
                       <tbody><tr>
                        <td style='padding:0in 0in 0in 0in'></td>
                       </tr>
                       <tr>
                        <td style='padding:0in 0in 0in 0in'>
                        <p class='MsoNormal' align='center' style='text-align:center'><a href='http://www.volcom.co.id/' title='Volcom' target='_blank' data-saferedirecturl='https://www.google.com/url?hl=en&amp;q=http://www.volcom.co.id/&amp;source=gmail&amp;ust=1480121870771000&amp;usg=AFQjCNEjXvEZWgDdR-Wlke7nn0fmc1ZUuA'><span style='text-decoration:none'><img border='0' width='180' id='m_1811720018273078822_x0000_i1025' src='https://ci3.googleusercontent.com/proxy/x-zXDZUS-2knkEkbTh3HzgyAAusw1Wz7dqV-lbnl39W_4F6T97fJ2_b9doP3nYi0B6KHstdb-tK8VAF_kOaLt2OH=s0-d-e1-ft#http://www.volcom.co.id/enews/img/volcom.jpg' alt='Volcom' class='CToWUd'></span></a><u></u><u></u></p>
                        </td>
                       </tr>
                       <tr>
                        <td style='padding:0in 0in 0in 0in'></td>
                       </tr>
                       <tr>
                        <td style='padding:0in 0in 0in 0in'>
                        <table class='m_1811720018273078822MsoNormalTable' border='0' cellspacing='0' cellpadding='0' width='600' style='width:6.25in;background:white'>
                         <tbody><tr>
                          <td style='padding:0in 0in 0in 0in'>
      
                          </td>
                         </tr>
                        </tbody></table>
                        <p class='MsoNormal' style='background-color:#eff0f1'><span style='display:block;background-color:#eff0f1;height: 5px;'><u></u>&nbsp;<u></u></span></p>
                        <p class='MsoNormal'><span style='display:none'><u></u>&nbsp;<u></u></span></p>
                        <table class='m_1811720018273078822MsoNormalTable' border='0' cellspacing='0' cellpadding='0' style='background:white'>
                         <tbody><tr>
                          <td style='padding:15.0pt 15.0pt 15.0pt 15.0pt'>
                          <div>
                          <p class='MsoNormal' style='line-height:14.25pt'><b><span style='font-family:&quot;Arial&quot;,&quot;sans-serif&quot;;color:#606060'>Dear " & employee_name & ",</span></b><span style='font-size:10.0pt;font-family:&quot;Arial&quot;,&quot;sans-serif&quot;;color:#606060;letter-spacing:.4pt'><u></u><u></u></span></p>
                          <p class='MsoNormal' style='line-height:14.25pt'><span style='font-size:10.0pt;font-family:&quot;Arial&quot;,&quot;sans-serif&quot;;color:#606060;letter-spacing:.4pt'>Here's your monthly leave remaining report for your department. Please see attachment.
                    <u></u><u></u></span></p>
                          <p class='MsoNormal' style='line-height:14.25pt'><span style='font-size:10.0pt;font-family:&quot;Arial&quot;,&quot;sans-serif&quot;;color:#606060;letter-spacing:.4pt'>Thank you<br /><b>Volcom ERP</b><u></u><u></u></span></p>

                          </div>
                          </div>
                          </td>
                         </tr>
                        </tbody></table>
                        <p class='MsoNormal' style='background-color:#eff0f1'><span style='display:block;height: 10px;'><u></u>&nbsp;<u></u></span></p>
                        <p class='MsoNormal'><span style='display:none'><u></u>&nbsp;<u></u></span></p>
                        <div align='center'>
                        <table class='m_1811720018273078822MsoNormalTable' border='0' cellspacing='0' cellpadding='0' style='background:white'>
                         <tbody><tr>
                          <td style='padding:6.0pt 6.0pt 6.0pt 6.0pt;text-align:center;'>
                            <span style='text-align:center;font-size:7.0pt;font-family:&quot;Arial&quot;,&quot;sans-serif&quot;;color:#a0a0a0;letter-spacing:.4pt;'>This email send directly from system. Do not reply.</b><u></u><u></u></span>
                          <p class='MsoNormal' align='center' style='margin-bottom:12.0pt;text-align:center;padding-top:0px;'><img border='0' width='300' id='m_1811720018273078822_x0000_i1028' src='https://ci6.googleusercontent.com/proxy/xq6o45mp_D9Z7DHCK5WT7GKuQ2QDaLg1hyMxoHX5ofUIv_m7GwasoczpbAOn6l6Ze-UfLuIUAndSokPvO633nnO9=s0-d-e1-ft#http://www.volcom.co.id/enews/img/footer.jpg' class='CToWUd'><u></u><u></u></p>
                          </td>
                         </tr>
                        </tbody></table>

                        </div>
                        </td>
                       </tr>
                      </tbody></table>
                      </div>
                      </td>
                     </tr>
                    </tbody></table>"
        Return body_temp
    End Function
    Function email_body(ByVal employee As String, ByVal mark_type As String, ByVal mark_number As String, ByVal mark_sender As String)
        If report_mark_type = "95" Then

        End If

        Dim body_template As String = ""
        body_template = "<html><head></head><body>
            <title>Auto notification Volcom ERP</title>
            <style type=""text/css"">
	            #yiv0832847839  #yiv0832847839  RESET STYLES  
	            #yiv0832847839 p{margin:10px 0;padding:0;}
	            #yiv0832847839 table{border-collapse:collapse;}
	            #yiv0832847839 h1, #yiv0832847839 h2, #yiv0832847839 h3, #yiv0832847839 h4, #yiv0832847839 h5, #yiv0832847839 h6{display:block;margin:0;padding:0;}
	            #yiv0832847839 img, #yiv0832847839 a img{border:0;height:auto;outline:none;text-decoration:none;}
	            #yiv0832847839 body, #yiv0832847839 #yiv0832847839bodyTable, #yiv0832847839 #yiv0832847839bodyCell{height:100%;margin:0;padding:0;width:100%;}

	            #yiv0832847839 #yiv0832847839 CLIENT-SPECIFIC STYLES  
	            #yiv0832847839 #yiv0832847839outlook a{padding:0;}#yiv0832847839  
	             _filtered #yiv0832847839 {}#yiv0832847839  
	            #yiv0832847839 img{}#yiv0832847839  
	            #yiv0832847839 table{}#yiv0832847839  
	            #yiv0832847839 .yiv0832847839ReadMsgBody{width:100%;}#yiv0832847839 .yiv0832847839ExternalClass{width:100%;}#yiv0832847839  
	            #yiv0832847839 p, #yiv0832847839 a, #yiv0832847839 li, #yiv0832847839 td, #yiv0832847839 blockquote{}#yiv0832847839  
	            #yiv0832847839 a .filtered99999 , #yiv0832847839 a .filtered99999 {color:inherit;cursor:default;text-decoration:none;}#yiv0832847839  
	            #yiv0832847839 p, #yiv0832847839 a, #yiv0832847839 li, #yiv0832847839 td, #yiv0832847839 body, #yiv0832847839 table, #yiv0832847839 blockquote{}#yiv0832847839  
	            #yiv0832847839 .yiv0832847839ExternalClass, #yiv0832847839 .yiv0832847839ExternalClass p, #yiv0832847839 .yiv0832847839ExternalClass td, #yiv0832847839 .yiv0832847839ExternalClass div, #yiv0832847839 .yiv0832847839ExternalClass span, #yiv0832847839 .yiv0832847839ExternalClass font{line-height:100%;}#yiv0832847839  
	            #yiv0832847839 a .filtered99999 {color:inherit;text-decoration:none;font-size:inherit !important;font-family:inherit !important;font-weight:inherit;line-height:inherit !important;}#yiv0832847839  


	            #yiv0832847839 #yiv0832847839footerContent a{color:#B7B7B7;}

	            #yiv0832847839  #yiv0832847839  MOBILE STYLES  
	            @media screen and (max-width:480px){
	            #yiv0832847839 body{width:100% !important;min-width:100% !important;}
	            #yiv0832847839 h1{font-size:24px !important;}
	            #yiv0832847839 #yiv0832847839templateHeader{padding-right:20px !important;padding-left:20px !important;}
	            #yiv0832847839 #yiv0832847839headerContainer{padding-right:0 !important;padding-left:0 !important;}
	            #yiv0832847839 #yiv0832847839headerTable{}
	            #yiv0832847839 #yiv0832847839headerTable td{padding-top:30px !important;}
	            #yiv0832847839 #yiv0832847839bodyContainer{padding-right:20px !important;padding-left:20px !important;}
	            #yiv0832847839 #yiv0832847839bodyContent{padding-right:0 !important;}
	            #yiv0832847839 #yiv0832847839footerContent p{border-bottom:1px solid #E5E5E5;font-size:14px !important;padding-bottom:40px !important;}
	            #yiv0832847839 .yiv0832847839utilityLink{border-bottom:1px solid #E5E5E5;display:block;font-size:13px !important;padding-top:20px;padding-bottom:20px;text-decoration:none;}
	            #yiv0832847839 .yiv0832847839mobileHide{display:none;visibility:hidden;}
	            }

	            @media {
	             _filtered #yiv0832847839 {font-family:'Open Sans';font-style:normal;font-weight:400;}

	             _filtered #yiv0832847839 {font-family:'Open Sans';font-style:normal;font-weight:700;}

	             _filtered #yiv0832847839 {font-family:'Open Sans';font-style:normal;font-weight:400;}

	             _filtered #yiv0832847839 {font-family:'Open Sans';font-style:normal;font-weight:700;}

	            #yiv0832847839 *, #yiv0832847839 td{font-family:'Open Sans', 'Helvetica Neue', Helvetica, Arial, sans-serif !important;}
	            #yiv0832847839 
            </style>
                <div id=""yui_3_16_0_ym19_1_1465365162626_3230"">
                    <center id=""yui_3_16_0_ym19_1_1465365162626_3229"">
                        <table align=""center"" border=""0"" cellpadding=""0"" cellspacing=""0"" height=""100%"" width=""100%"" id=""yiv0832847839bodyTable"">
                            <tbody id=""yui_3_16_0_ym19_1_1465365162626_3228""><tr id=""yui_3_16_0_ym19_1_1465365162626_3227"">
                                <td align=""center"" valign=""top"" id=""yiv0832847839bodyCell"">
						            <span style=""color:#FFFFFF;display:none;font-size:0px;height:0px;visibility:hidden;width:0px;"">You're almost ready to get started!</span>
                        
                                    <table border=""0"" cellpadding=""0"" cellspacing=""0"" width=""100%"" id=""yui_3_16_0_ym19_1_1465365162626_3226"">
							            <tbody id=""yui_3_16_0_ym19_1_1465365162626_3225"">
							            <tr>
								            <td align=""center"" bgcolor=""#FFFFFF"" valign=""top"" id=""yiv0832847839headerContainer"" style=""background-color:#FFFFFF;padding-right:30px;padding-left:30px;"">
									            <table align=""center"" border=""0"" cellpadding=""0"" cellspacing=""0"" width=""100%"">
										            <tbody><tr>
											            <td align=""center"" valign=""top"">
												
												            <table align=""center"" border=""0"" cellpadding=""0"" cellspacing=""0"" width=""100%"" style=""max-width:640px;"" class=""yiv0832847839emailContainer"">
													            <tbody><tr>
														            <td align=""center"" valign=""top"">
															            <table align=""center"" bgcolor=""#FFFFFF"" border=""0"" cellpadding=""0"" cellspacing=""0"" width=""100%"" id=""yiv0832847839headerTable"" style=""background-color:#FFFFFF;border-collapse:separate;"">
																            <tbody>
																            <tr>
																	            <td align=""left"" valign=""top"" id=""yiv0832847839bodyContent"" style=""padding-bottom:30px;padding-top:40px;"">
																		            <h1 style=""color:#737373;font-family:'Helvetica Neue', Helvetica, Arial, sans-serif;font-size:30px;font-style:normal;font-weight:600;line-height:42px;letter-spacing:normal;margin:0;padding:0;text-align:center;"">You have 1 new waiting approval, " & employee & ".</h1>
																	            </td>
																            </tr>
															            </tbody></table>
														            </td>
													            </tr>
												            </tbody></table>
												
											            </td>
										            </tr>
									            </tbody></table>
								            </td>
                                        </tr>
							            <tr id=""yui_3_16_0_ym19_1_1465365162626_3224"">
								            <td align=""center"" valign=""top"" id=""yiv0832847839templateBody"">
									            <table align=""center"" border=""0"" cellpadding=""0"" cellspacing=""0"" width=""100%"" id=""yui_3_16_0_ym19_1_1465365162626_3223"">
										            <tbody id=""yui_3_16_0_ym19_1_1465365162626_3222""><tr id=""yui_3_16_0_ym19_1_1465365162626_3221"">
											            <td align=""center"" valign=""top"" id=""yui_3_16_0_ym19_1_1465365162626_3220"">
												
												            <table align=""center"" border=""0"" cellpadding=""0"" cellspacing=""0"" width=""100%"" style=""max-width:700px;"" class=""yiv0832847839emailContainer"" id=""yui_3_16_0_ym19_1_1465365162626_3219"">
													            <tbody id=""yui_3_16_0_ym19_1_1465365162626_3218""><tr id=""yui_3_16_0_ym19_1_1465365162626_3217"">
														            <td align=""right"" valign=""top"" width=""30"" class=""yiv0832847839mobileHide"">
															            <img width=""30"" style=""display:block;"" data-id=""f8de403e-5516-4f60-d47f-d38ec2c53672"">
														            </td>
														            <td valign=""top"" width=""100%"" style=""padding-right:70px;padding-left:40px;"" id=""yiv0832847839bodyContainer"">
															            <table align=""left"" border=""0"" cellpadding=""0"" cellspacing=""0"" width=""100%"" id=""yui_3_16_0_ym19_1_1465365162626_3216"">
																            <tbody id=""yui_3_16_0_ym19_1_1465365162626_3215"">
																            <tr id=""yui_3_16_0_ym19_1_1465365162626_3214"">
																	            <td align=""center"" valign=""top"" style=""padding-bottom:20px;"" id=""yui_3_16_0_ym19_1_1465365162626_3213"">
																			            <table align=""center"" border=""0"" cellpadding=""10"" cellspacing=""0"" width="""" style=""color:#929292;font-family:'Helvetica Neue', Helvetica, Arial, sans-serif;font-size:14px;font-style:normal;font-weight:400;line-height:21px;letter-spacing:normal;"">
																				            <tbody>
																					            <tr>
																						            <td align=""left"" valign=""near"">
																							            About
																						            </td>
																						            <td align=""left"" valign=""near"">
																							            :
																						            </td>
																						            <td align=""left"" valign=""near"">
																							            " + mark_type + "
																						            </td>
																					            </tr>
																					            <tr>
																						            <td align=""left"" valign=""near"">
																							            Number
																						            </td>
																						            <td align=""left"" valign=""near"">
																							            :
																						            </td>
																						            <td align=""left"" valign=""near"">
																							             " + mark_number + "
																						            </td>
																					            </tr>
																					            <tr>
																						            <td align=""left"" valign=""near"">
																							            From
																						            </td>
																						            <td align=""left"" valign=""near"">
																							            :
																						            </td>
																						            <td align=""left"" valign=""near"">
																							            " + mark_sender + "
																						            </td>
																					            </tr>
																				            </tbody>
																			            </table>
																	            </td>
																            </tr>
																            <tr>
																	            <td align=""center"" style=""padding-bottom:5px;"" valign=""top"">
																		            <table align=""center"" border=""0"" cellpadding=""0"" cellspacing=""0"" width=""100%"">
																			            <tbody><tr>
																				            <td align=""center"" valign=""middle"">
																					
																					            <a rel=""nofollow"" target=""_blank"" href="""" style=""background-color:#2FBD47;border-collapse:separate;border-top:20px solid #2FBD47;border-right:20px solid #2FBD47;border-bottom:20px solid #2FBD47;border-left:20px solid #2FBD47;border-radius:3px;color:#FFFFFF;display:inline-block;font-family:'Helvetica Neue', Helvetica, Arial, sans-serif;font-size:16px;font-weight:600;letter-spacing:.3px;text-decoration:none;"">Accept</a>
																					            &nbsp
																					            <a rel=""nofollow"" target=""_blank"" href="""" style=""background-color:#E11A1A;border-collapse:separate;border-top:20px solid #E11A1A;border-right:20px solid #E11A1A;border-bottom:20px solid #E11A1A;border-left:20px solid #E11A1A;border-radius:3px;color:#FFFFFF;display:inline-block;font-family:'Helvetica Neue', Helvetica, Arial, sans-serif;font-size:16px;font-weight:600;letter-spacing:.3px;text-decoration:none;"">Decline</a>
																					
																				            </td>
																			            </tr>
																		            </tbody></table>
																	            </td>
																            </tr>
																            <tr id=""yui_3_16_0_ym19_1_1465365162626_3214"">
																	            <td align=""left"" valign=""top"" style=""padding-bottom:40px;"" id=""yui_3_16_0_ym19_1_1465365162626_3213"">
																		            <div style=""color:#929292;font-family:'Helvetica Neue', Helvetica, Arial, sans-serif;font-size:14px;font-style:normal;font-weight:400;line-height:42px;letter-spacing:normal;margin:0;padding:0;text-align:center;"">(Please click one of button above to continue. Click <a href=""#"">here</a> for confirmation status.)</div>
																	            </td>
																            </tr>
															            </tbody></table>
														            </td>
													            </tr>
												            </tbody></table>
												
											            </td>
										            </tr>
									            </tbody></table>
								            </td>
                                        </tr>
                                        <tr id=""yui_3_16_0_ym19_1_1465365162626_3238"">
								            <td align=""center"" valign=""top"" id=""yiv0832847839templateFooter"" style=""padding-right:30px;padding-left:30px;"">
									            <table align=""center"" border=""0"" cellpadding=""0"" cellspacing=""0"" width=""100%"" style=""max-width:640px;"" class=""yiv0832847839emailContainer"" id=""yui_3_16_0_ym19_1_1465365162626_3237"">
										            <tbody id=""yui_3_16_0_ym19_1_1465365162626_3236""><tr id=""yui_3_16_0_ym19_1_1465365162626_3235"">
                                			            <td valign=""top"" id=""yiv0832847839footerContent"" style=""border-top:2px solid #F2F2F2;color:#B7B7B7;font-family:'Helvetica Neue', Helvetica, Arial, sans-serif;font-size:12px;font-weight:400;line-height:24px;padding-top:5px;padding-bottom:20px;text-align:center;"">
												            <div style=""color:#B7B7B7;font-family:'Helvetica Neue', Helvetica, Arial, sans-serif;font-size:12px;font-weight:400;line-height:24px;padding:0;margin:0;text-align:center;"" id=""yui_3_16_0_ym19_1_1465365162626_3239"">Notification from Volcom Enterprise Resource Planning (ERP)</div>
												            <a rel=""nofollow"" target=""_blank"" href=""http://www.volcom.co.id"" style=""color:#B7B7B7;text-decoration:underline;"" class=""yiv0832847839utilityLink"">Volcom Indonesia</a>
											            </td>
										            </tr>
									            </tbody></table>
									
								            </td>
                                        </tr>
                                    </tbody></table>
                        
                                </td>
                            </tr>
                        </tbody></table>
                    </center>
                <img height=""1"" width=""1"" data-id=""99d3f6c3-f87e-470b-3bb3-0280693bcba3""></div>
            </div><br><br></div>  </div> </div>  </div></div></body></html>"
        Return body_template
    End Function
End Class
