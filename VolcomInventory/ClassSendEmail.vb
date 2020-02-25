Imports System.IO
Imports System.Net.Mail

Public Class ClassSendEmail
    Public id_report As String = "-1"
    Public report_mark_type As String = "-1"
    Public opt As String = "1"

    'comment mail
    Public season As String = ""
    Public date_string As String = ""
    Public comment_by As String = ""
    Public comment As String = ""
    Public design As String = ""
    Public design_code As String = ""
    Public type_email As String = "4"
    Public par1 As String = ""
    Public par2 As String = ""
    Public dt As DataTable
    Public subj As String = ""
    Public titl As String = ""
    Public head As String = ""


    Sub send_email()
        'get param
        Dim is_ssl = get_setup_field("system_email_is_ssl").ToString
        Dim client As SmtpClient = New SmtpClient()
        If is_ssl = "1" Then
            client.Port = get_setup_field("system_email_ssl_port").ToString
            client.DeliveryMethod = SmtpDeliveryMethod.Network
            client.UseDefaultCredentials = False
            client.Host = get_setup_field("system_email_ssl_server").ToString
            client.EnableSsl = True
            client.Credentials = New System.Net.NetworkCredential(get_setup_field("system_email_ssl").ToString, get_setup_field("system_email_ssl_pass").ToString)
        Else
            client.Port = get_setup_field("system_email_port").ToString
            client.DeliveryMethod = SmtpDeliveryMethod.Network
            client.UseDefaultCredentials = False
            client.Host = get_setup_field("system_email_server").ToString
            client.Credentials = New System.Net.NetworkCredential(get_setup_field("system_email").ToString, get_setup_field("system_email_pass").ToString)
        End If

        If report_mark_type = "test" Then
            Dim from_mail As MailAddress = New MailAddress("system@volcom.co.id", "Update Artikel - Volcom ERP")
            Dim mail As MailMessage = New MailMessage()
            mail.From = from_mail
            Dim to_mail As MailAddress = New MailAddress("septian@volcom.co.id", "Septian")
            mail.To.Add(to_mail)
            to_mail = New MailAddress("catur@volcom.co.id", "Catur")
            mail.To.Add(to_mail)

            mail.Subject = "Test Email"
            mail.IsBodyHtml = True
            mail.Body = "Test ya kaks <br/> <br/> tes lagi"
            client.Send(mail)
        ElseIf report_mark_type = "33" Then
            Dim from_mail As MailAddress = New MailAddress("system@volcom.co.id", "Handover Notification - Volcom ERP")
            Dim mail As MailMessage = New MailMessage()
            mail.From = from_mail

            'Send to => design_code : email; design : contact person;
            Dim query_send_to As String = "SELECT emp.`email_external`,emp.`employee_name` 
            FROM tb_mail_to md
            INNER JOIN tb_m_user usr ON usr.`id_user`=md.id_user
            INNER JOIN tb_m_employee emp ON emp.`id_employee`=usr.`id_employee`
            WHERE is_to='1' AND md.report_mark_type=33 "
            Dim data_send_to As DataTable = execute_query(query_send_to, -1, True, "", "", "", "")
            For i As Integer = 0 To data_send_to.Rows.Count - 1
                Dim to_mail As MailAddress = New MailAddress(data_send_to.Rows(i)("email_external").ToString, data_send_to.Rows(i)("employee_name").ToString)
                mail.To.Add(to_mail)
            Next

            'Send CC
            Dim query_send_cc As String = "SELECT emp.`email_external`,emp.`employee_name` 
            FROM tb_mail_to md
            INNER JOIN tb_m_user usr ON usr.`id_user`=md.id_user
            INNER JOIN tb_m_employee emp ON emp.`id_employee`=usr.`id_employee`
            WHERE is_to='2' AND md.report_mark_type=33 "
            Dim data_send_cc As DataTable = execute_query(query_send_cc, -1, True, "", "", "", "")
            For i As Integer = 0 To data_send_cc.Rows.Count - 1
                Dim to_mail_cc As MailAddress = New MailAddress(data_send_cc.Rows(i)("email_external").ToString, data_send_cc.Rows(i)("employee_name").ToString)
                mail.CC.Add(to_mail_cc)
            Next

            Dim body_temp As String = " <table class='m_1811720018273078822MsoNormalTable' border='0' cellspacing='0' cellpadding='0' width='100%' style='width:100.0%;background:#eeeeee'>
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
                

                <!-- start body -->
                <table width='100%' class='m_1811720018273078822MsoNormalTable' border='0' cellspacing='0' cellpadding='0' style='background:white'>
                 <tbody>
                 <tr>
                  <td style='padding:15.0pt 15.0pt 15.0pt 15.0pt' colspan='3'>
                  <div>
                  <p class='MsoNormal' style='line-height:14.25pt'><b><span style='font-family:&quot;Arial&quot;,&quot;sans-serif&quot;;color:#606060'>Dear All, </span></b><span style='font-size:10.0pt;font-family:&quot;Arial&quot;,&quot;sans-serif&quot;;color:#606060;letter-spacing:.4pt'><u></u><u></u></span></p>
                  </div>
                  </td>
                 </tr>

                 <tr>
                  <td style='padding:5.0pt 5.0pt 5.0pt 15.0pt;'>
                    <p class='MsoNormal' style='line-height:10.25pt'>
                      <span style='font-size:10.0pt; font-family:&quot;Arial&quot;,&quot;sans-serif&quot;;color:#606060'>
                       There are <b>" + par1 + " pcs</b> ready for handover to the warehouse. Details attached in PDF.
                      </span>
                    </p>

                    <p class='MsoNormal' style='line-height:10.25pt'>
                      <span style='font-size:10.0pt; font-family:&quot;Arial&quot;,&quot;sans-serif&quot;;color:#606060'>
                       For more information please see on ERP <b>(Sales & Inventory > Handover Report)</b>
                      </span>
                    </p>
                  </td>
                 </tr>


         
          <tr>
                  <td style='padding:15.0pt 15.0pt 15.0pt 15.0pt' colspan='3'>
                  <div>
                  <p class='MsoNormal' style='line-height:14.25pt'><span style='font-size:10.0pt;font-family:&quot;Arial&quot;,&quot;sans-serif&quot;;color:#606060;letter-spacing:.4pt'>Thank you<br /><b>Volcom ERP</b><u></u><u></u></span></p>

                  </div>
                  </td>
                 </tr>
                </tbody>
              </table>
              <!-- end body -->


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
            </tbody>
        </table> "


            '-- start attachment 
            'Create a New report. 
            ReportProductionHOAttachment.id = id_report
            Dim Report As New ReportProductionHOAttachment()

            ' Create a new memory stream and export the report into it as PDF.
            Dim Mem As New MemoryStream()
            Dim unik_file As String = execute_query("SELECT UNIX_TIMESTAMP(NOW())", 0, True, "", "", "", "")
            Report.ExportToPdf(Mem)
            ' Create a new attachment and put the PDF report into it.
            Mem.Seek(0, System.IO.SeekOrigin.Begin)
            Dim Att = New Attachment(Mem, report_mark_type & "_" & unik_file & ".pdf", "application/pdf")
            mail.Attachments.Add(Att)
            '-- end attachment

            mail.Subject = "Handover Notification - " + date_string
            mail.IsBodyHtml = True
            mail.Body = body_temp
            client.Send(mail)
        ElseIf report_mark_type = "185" Then
            'par1 = id_design
            Dim from_mail As MailAddress = New MailAddress("system@volcom.co.id", "Final COP approved - Volcom ERP")
            Dim mail As MailMessage = New MailMessage()
            mail.From = from_mail
            'Send to
            Dim query_send_to As String = "SELECT emp.`email_external`,emp.`employee_name` 
            FROM tb_mail_to md
            INNER JOIN tb_m_user usr ON usr.`id_user`=md.id_user
            INNER JOIN tb_m_employee emp ON emp.`id_employee`=usr.`id_employee`
            WHERE is_to='1' AND md.report_mark_type=185 "
            Dim data_send_to As DataTable = execute_query(query_send_to, -1, True, "", "", "", "")
            For i As Integer = 0 To data_send_to.Rows.Count - 1
                If Not data_send_to.Rows(i)("email_external").ToString = "" Then
                    Dim to_mail As MailAddress = New MailAddress(data_send_to.Rows(i)("email_external").ToString, data_send_to.Rows(i)("employee_name").ToString)
                    mail.To.Add(to_mail)
                End If
            Next
            'CC
            Dim query_send_cc As String = "SELECT emp.`email_external`,emp.`employee_name` 
            FROM tb_mail_to md
            INNER JOIN tb_m_user usr ON usr.`id_user`=md.id_user
            INNER JOIN tb_m_employee emp ON emp.`id_employee`=usr.`id_employee`
            WHERE is_to='2' AND md.report_mark_type=185 "
            Dim data_send_cc As DataTable = execute_query(query_send_cc, -1, True, "", "", "", "")
            For i As Integer = 0 To data_send_cc.Rows.Count - 1
                If Not data_send_cc.Rows(i)("email_external").ToString = "" Then
                    Dim cc_mail As MailAddress = New MailAddress(data_send_cc.Rows(i)("email_external").ToString, data_send_cc.Rows(i)("employee_name").ToString)
                    mail.CC.Add(cc_mail)
                End If
            Next

            Dim design_name, cop, design_code As String
            Dim query As String = "SELECT design_display_name,design_code,design_cop FROM tb_m_design WHERE id_design='" & par1 & "'"
            Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
            If data.Rows.Count > 0 Then
                design_name = data.Rows(0)("design_display_name").ToString
                design_code = data.Rows(0)("design_code").ToString
                cop = Decimal.Parse(data.Rows(0)("design_cop").ToString).ToString("N2")
            Else
                design_name = ""
                design_code = ""
                cop = ""
            End If

            mail.Subject = "Final COP Approved (" & design_code & " - " & design_name & ")"
            mail.IsBodyHtml = True
            mail.Body = email_body_final_cop(cop, design_name, design_code, "1")
            client.Send(mail)
        ElseIf report_mark_type = "186" Then
            'par1 = id_design
            Dim from_mail As MailAddress = New MailAddress("system@volcom.co.id", "Pre Final COP approved - Volcom ERP")
            Dim mail As MailMessage = New MailMessage()
            mail.From = from_mail
            'Send to
            Dim query_send_to As String = "SELECT emp.`email_external`,emp.`employee_name` 
            FROM tb_mail_to md
            INNER JOIN tb_m_user usr ON usr.`id_user`=md.id_user
            INNER JOIN tb_m_employee emp ON emp.`id_employee`=usr.`id_employee`
            WHERE is_to='1' AND md.report_mark_type=186 "
            Dim data_send_to As DataTable = execute_query(query_send_to, -1, True, "", "", "", "")
            For i As Integer = 0 To data_send_to.Rows.Count - 1
                If Not data_send_to.Rows(i)("email_external").ToString = "" Then
                    Dim to_mail As MailAddress = New MailAddress(data_send_to.Rows(i)("email_external").ToString, data_send_to.Rows(i)("employee_name").ToString)
                    mail.To.Add(to_mail)
                End If
            Next
            'CC
            Dim query_send_cc As String = "SELECT emp.`email_external`,emp.`employee_name` 
            FROM tb_mail_to md
            INNER JOIN tb_m_user usr ON usr.`id_user`=md.id_user
            INNER JOIN tb_m_employee emp ON emp.`id_employee`=usr.`id_employee`
            WHERE is_to='2' AND md.report_mark_type=186 "
            Dim data_send_cc As DataTable = execute_query(query_send_cc, -1, True, "", "", "", "")
            For i As Integer = 0 To data_send_cc.Rows.Count - 1
                If Not data_send_cc.Rows(i)("email_external").ToString = "" Then
                    Dim cc_mail As MailAddress = New MailAddress(data_send_cc.Rows(i)("email_external").ToString, data_send_cc.Rows(i)("employee_name").ToString)
                    mail.CC.Add(cc_mail)
                End If
            Next

            Dim design_name, cop, design_code As String
            Dim query As String = "SELECT design_display_name,design_code,prod_order_cop_mng FROM tb_m_design WHERE id_design='" & par1 & "'"
            Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
            If data.Rows.Count > 0 Then
                design_name = data.Rows(0)("design_display_name").ToString
                design_code = data.Rows(0)("design_code").ToString
                cop = Decimal.Parse(data.Rows(0)("prod_order_cop_mng").ToString).ToString("N2")
            Else
                design_name = ""
                design_code = ""
                cop = ""
            End If

            mail.Subject = "Pre Final COP Approved (" & design_code & " - " & design_name & ")"
            mail.IsBodyHtml = True
            mail.Body = email_body_final_cop(cop, design_name, design_code, "2")
            client.Send(mail)
        ElseIf report_mark_type = "design_comment" Then
            ' Create a new report. 
            Dim from_mail As MailAddress = New MailAddress("system@volcom.co.id", "Update Artikel - Volcom ERP")
            Dim mail As MailMessage = New MailMessage()
            mail.From = from_mail
            'Send to
            Dim query_send_mail As String = "SELECT emp.`email_external`,emp.`employee_name` FROM tb_mail_dsg_cmnt md
                                                INNER JOIN tb_m_user usr ON usr.`id_user`=md.id_user
                                                INNER JOIN tb_m_employee emp ON emp.`id_employee`=usr.`id_employee`
                                              WHERE class='" & type_email & "' AND is_to='1'"
            Dim data_send_mail As DataTable = execute_query(query_send_mail, -1, True, "", "", "", "")
            For i As Integer = 0 To data_send_mail.Rows.Count - 1
                Dim to_mail As MailAddress = New MailAddress(data_send_mail.Rows(i)("email_external").ToString, data_send_mail.Rows(i)("employee_name").ToString)
                mail.To.Add(to_mail)
            Next
            'Send CC
            Dim query_send_cc As String = "SELECT emp.`email_external`,emp.`employee_name` FROM tb_mail_dsg_cmnt md
                                                 INNER JOIN tb_m_user usr ON usr.`id_user`=md.id_user
                                                INNER JOIN tb_m_employee emp ON emp.`id_employee`=usr.`id_employee`
                                              WHERE class='" & type_email & "' AND is_to='2'"
            Dim data_send_cc As DataTable = execute_query(query_send_cc, -1, True, "", "", "", "")
            For i As Integer = 0 To data_send_cc.Rows.Count - 1
                Dim to_mail As MailAddress = New MailAddress(data_send_cc.Rows(i)("email_external").ToString, data_send_cc.Rows(i)("employee_name").ToString)
                mail.CC.Add(to_mail)
            Next
            '
            mail.Subject = "New comment on design " & design & " (Season : " & season & ")"
            mail.IsBodyHtml = True
            mail.Body = email_body_comment(season, design, design_code, comment_by, date_string, comment)
            client.Send(mail)
        ElseIf report_mark_type = "126" Then 'over production memo
            ' Create a new report. 
            Dim from_mail As MailAddress = New MailAddress("system@volcom.co.id", "Over Production Memo - Volcom ERP")
            Dim mail As MailMessage = New MailMessage()
            mail.From = from_mail

            'Send to
            Dim query_send_mail As String = "SELECT emp.`email_external`,emp.`employee_name` 
                                             FROM tb_prod_over_memo_mail md
                                             INNER JOIN tb_m_user usr ON usr.`id_user`=md.id_user
                                             INNER JOIN tb_m_employee emp ON emp.`id_employee`=usr.`id_employee`
                                             WHERE is_to='1'"
            Dim data_send_mail As DataTable = execute_query(query_send_mail, -1, True, "", "", "", "")
            For i As Integer = 0 To data_send_mail.Rows.Count - 1
                Dim to_mail As MailAddress = New MailAddress(data_send_mail.Rows(i)("email_external").ToString, data_send_mail.Rows(i)("employee_name").ToString)
                mail.To.Add(to_mail)
            Next

            'Send CC
            Dim query_send_cc As String = "SELECT emp.`email_external`,emp.`employee_name` 
                                           FROM tb_prod_over_memo_mail md
                                           INNER JOIN tb_m_user usr ON usr.`id_user`=md.id_user
                                           INNER JOIN tb_m_employee emp ON emp.`id_employee`=usr.`id_employee`
                                           WHERE is_to='2'"
            Dim data_send_cc As DataTable = execute_query(query_send_cc, -1, True, "", "", "", "")
            For i As Integer = 0 To data_send_cc.Rows.Count - 1
                Dim to_mail As MailAddress = New MailAddress(data_send_cc.Rows(i)("email_external").ToString, data_send_cc.Rows(i)("employee_name").ToString)
                mail.CC.Add(to_mail)
            Next

            'mail body
            '----main
            Dim mov As New ClassProdOverMemo()
            Dim qm As String = mov.queryMain("AND m.id_prod_over_memo=" + id_report + "", "1")
            Dim dm As DataTable = execute_query(qm, -1, True, "", "", "", "")
            '----detail
            Dim query As String = "SELECT md.id_prod_over_memo_det, md.id_prod_over_memo, md.id_prod_order, po.prod_order_number, d.design_code AS `code`, d.design_display_name AS `name`, md.remark, md.qty
            FROM tb_prod_over_memo_det md
            INNER JOIN tb_prod_order po ON po.id_prod_order = md.id_prod_order
            INNER JOIN tb_prod_demand_design pdd ON pdd.id_prod_demand_design = po.id_prod_demand_design
            INNER JOIN tb_m_design d ON d.id_design = pdd.id_design
            WHERE md.id_prod_over_memo=" + id_report + " "
            Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")

            Dim body_temp As String = " <table class='m_1811720018273078822MsoNormalTable' border='0' cellspacing='0' cellpadding='0' width='100%' style='width:100.0%;background:#eeeeee'>
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
            <table width='100%' class='m_1811720018273078822MsoNormalTable' border='0' cellspacing='0' cellpadding='0' style='background:white'>
             <tbody>
             <tr>
              <td style='padding:15.0pt 15.0pt 15.0pt 15.0pt' colspan='3'>
              <div>
              <p class='MsoNormal' style='line-height:14.25pt'><b><span style='font-family:&quot;Arial&quot;,&quot;sans-serif&quot;;color:#606060'>Dear All,</span></b><span style='font-size:10.0pt;font-family:&quot;Arial&quot;,&quot;sans-serif&quot;;color:#606060;letter-spacing:.4pt'><u></u><u></u></span></p>
              </div>
              </td>
             </tr>
             <tr>
              <td style='padding:1.0pt 1.0pt 1.0pt 15.0pt' colspan='3'>
              <div>
              <p class='MsoNormal' style='line-height:14.25pt'><span style='font-size:10.0pt;font-family:&quot;Arial&quot;,&quot;sans-serif&quot;;color:#606060;letter-spacing:.4pt'>Memo No : " + dm.Rows(0)("memo_number").ToString + " has been submitted with details below </span></b><span style='font-size:10.0pt;font-family:&quot;Arial&quot;,&quot;sans-serif&quot;;color:#606060;letter-spacing:.4pt'><u></u><u></u></span>
              </div>
              </td>
             </tr>
         
             <tr>
              <td style='padding:15.0pt 15.0pt 15.0pt 15.0pt' colspan='3'>
                <table width='100%' class='m_1811720018273078822MsoNormalTable' border='1' cellspacing='0' cellpadding='5' style='background:white'>
                    <tr>
                      <th>FGPO#</th>
                      <th>Code</th>
                      <th>Description</th>
                      <th>Qty</th>
                    </tr> "
            Dim total As Integer = 0
            For i As Integer = 0 To (data.Rows.Count - 1)
                body_temp += "<tr>
            <td>" + data.Rows(i)("prod_order_number").ToString + "</td>
            <td>" + data.Rows(i)("code").ToString + "</td>
            <td>" + data.Rows(i)("name").ToString + "</td>
            <td>" + data.Rows(i)("qty").ToString + "</td>
            </tr>"
                total += data.Rows(i)("qty")
            Next
            body_temp += "
            <tr>
                <th colspan='3' align='center'>TOTAL</th>
                <td>" + total.ToString + "</td>
            </tr>
            </table>
              </td>
             </tr> 
           <tr>
              <td style ='padding:15.0pt 15.0pt 8.0pt 15.0pt' colspan='3'>
              <div>
                  <p class='MsoNormal' style='line-height:14.25pt'><span style='font-size:10.0pt;font-family:&quot;Arial&quot;,&quot;sans-serif&quot;;color:#606060;letter-spacing:.4pt'>This memo is valid until " + DateTime.Parse(dm.Rows(0)("expired_date").ToString).ToString("dd MMMM yyyy hh:mm tt") + "</span></b><span style='font-size:10.0pt;font-family:&quot;Arial&quot;,&quot;sans-serif&quot;;color:#606060;letter-spacing:.4pt'><u></u><u></u></span>
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
        </tbody>
    </table> "

            mail.Subject = "Memo No. : " + dm.Rows(0)("memo_number").ToString
            mail.IsBodyHtml = True
            mail.Body = body_temp
            client.Send(mail)
        ElseIf report_mark_type = "82" Or report_mark_type = "70" Or report_mark_type = "70_non_reg" Then 'barcode label req
            Dim from_mail As MailAddress = New MailAddress("system@volcom.co.id", "Barcode Label Requisition - Volcom ERP")
            Dim mail As MailMessage = New MailMessage()
            mail.From = from_mail

            'Send to
            Dim query_send_mail As String = "SELECT emp.`email_external`,emp.`employee_name` 
                                             FROM tb_fg_price_mail md
                                             INNER JOIN tb_m_user usr ON usr.`id_user`=md.id_user
                                             INNER JOIN tb_m_employee emp ON emp.`id_employee`=usr.`id_employee`
                                             WHERE is_to='1' AND emp.`email_external`!='' "
            Dim data_send_mail As DataTable = execute_query(query_send_mail, -1, True, "", "", "", "")
            For i As Integer = 0 To data_send_mail.Rows.Count - 1
                Dim to_mail As MailAddress = New MailAddress(data_send_mail.Rows(i)("email_external").ToString, data_send_mail.Rows(i)("employee_name").ToString)
                mail.To.Add(to_mail)
            Next

            'Send CC
            Dim query_send_cc As String = "SELECT emp.`email_external`,emp.`employee_name` 
                                           FROM tb_fg_price_mail md
                                           INNER JOIN tb_m_user usr ON usr.`id_user`=md.id_user
                                           INNER JOIN tb_m_employee emp ON emp.`id_employee`=usr.`id_employee`
                                           WHERE is_to='2' AND emp.`email_external`!='' "
            Dim data_send_cc As DataTable = execute_query(query_send_cc, -1, True, "", "", "", "")
            For i As Integer = 0 To data_send_cc.Rows.Count - 1
                Dim to_mail As MailAddress = New MailAddress(data_send_cc.Rows(i)("email_external").ToString, data_send_cc.Rows(i)("employee_name").ToString)
                mail.CC.Add(to_mail)
            Next

            Dim query As String = ""
            If report_mark_type = "82" Then
                query = "CALL view_memo_price('And pd.is_print = 1 And p.id_fg_price = " + id_report + "')"
            ElseIf report_mark_type = "70" Then
                query = "SELECT prod.product_full_code AS `barcode`, d.design_code AS `code`, d.design_display_name AS `name`, po.prod_order_number, cd.code_detail_name AS `size`,
                CAST(pod.prod_order_qty AS DECIMAL(10,0)) AS `order_qty`, IFNULL(rec.qty,0) AS `rec_qty`, ppd.price AS `design_price`
                FROM tb_prod_order_det pod
                INNER JOIN tb_prod_order po ON po.id_prod_order = pod.id_prod_order AND po.id_report_status!=5
                INNER JOIN tb_prod_demand_product pdp ON pdp.id_prod_demand_product = pod.id_prod_demand_product
                INNER JOIN tb_m_product prod ON prod.id_product = pdp.id_product
                INNER JOIN tb_m_product_code prodc ON prodc.id_product = prod.id_product
                INNER JOIN tb_m_code_detail cd ON cd.id_code_detail = prodc.id_code_detail
                INNER JOIN tb_m_design d ON d.id_design = prod.id_design
                INNER JOIN tb_fg_propose_price_detail ppd ON ppd.id_design = prod.id_design
                INNER JOIN tb_fg_propose_price pp ON pp.id_fg_propose_price = ppd.id_fg_propose_price
                LEFT JOIN (
	                SELECT rd.id_prod_order_det, SUM(rd.prod_order_rec_det_qty) AS `qty` 
	                FROM tb_prod_order_rec_det rd
	                INNER JOIN tb_prod_order_rec r ON r.id_prod_order_rec = rd.id_prod_order_rec
	                WHERE r.id_report_status=6
	                GROUP BY rd.id_prod_order_det
                ) rec ON rec.id_prod_order_det = pod.id_prod_order_det
                WHERE pp.id_fg_propose_price>0 AND !ISNULL(ppd.id_design_price_type_print) AND pp.id_fg_propose_price=" + id_report + " AND ppd.is_active=1 ORDER BY prod.product_full_code ASC "
            ElseIf report_mark_type = "70_non_reg" Then
                query = "SELECT prod.product_full_code AS `barcode`, d.design_code AS `code`, d.design_display_name AS `name`, po.prod_order_number, cd.code_detail_name AS `size`,
                CAST(pod.prod_order_qty AS DECIMAL(10,0)) AS `order_qty`, IFNULL(rec.qty,0) AS `rec_qty`, IF(ppd.id_design_price_type_print=1, ppd.price, IF(ppd.id_design_price_type_print=4, ppd.sale_price,0)) AS `design_price`
                FROM tb_prod_order_det pod
                INNER JOIN tb_prod_order po ON po.id_prod_order = pod.id_prod_order AND po.id_report_status!=5
                INNER JOIN tb_prod_demand_product pdp ON pdp.id_prod_demand_product = pod.id_prod_demand_product
                INNER JOIN tb_m_product prod ON prod.id_product = pdp.id_product
                INNER JOIN tb_m_product_code prodc ON prodc.id_product = prod.id_product
                INNER JOIN tb_m_code_detail cd ON cd.id_code_detail = prodc.id_code_detail
                INNER JOIN tb_m_design d ON d.id_design = prod.id_design
                INNER JOIN tb_fg_propose_price_detail ppd ON ppd.id_design = prod.id_design
                INNER JOIN tb_fg_propose_price pp ON pp.id_fg_propose_price = ppd.id_fg_propose_price
                LEFT JOIN (
	                SELECT rd.id_prod_order_det, SUM(rd.prod_order_rec_det_qty) AS `qty` 
	                FROM tb_prod_order_rec_det rd
	                INNER JOIN tb_prod_order_rec r ON r.id_prod_order_rec = rd.id_prod_order_rec
	                WHERE r.id_report_status=6
	                GROUP BY rd.id_prod_order_det
                ) rec ON rec.id_prod_order_det = pod.id_prod_order_det
                WHERE pp.id_fg_propose_price>0 AND !ISNULL(ppd.id_design_price_type_print) AND pp.id_fg_propose_price=" + id_report + " AND ppd.is_active=1 ORDER BY prod.product_full_code ASC "
            End If
            Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
            Dim body_temp As String = "  <table class='m_1811720018273078822MsoNormalTable' border='0' cellspacing='0' cellpadding='0' width='100%' style='width:100.0%;background:#eeeeee'>
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
        <table width='100%' class='m_1811720018273078822MsoNormalTable' border='0' cellspacing='0' cellpadding='0' style='background:white'>
         <tbody>
         <tr>
          <td style='padding:15.0pt 15.0pt 15.0pt 15.0pt' colspan='3'>
          <div>
          <p class='MsoNormal' style='line-height:14.25pt'><b><span style='font-family:&quot;Arial&quot;,&quot;sans-serif&quot;;color:#606060'>BARCODE LABEL REQUISITION</span></b><span style='font-size:10.0pt;font-family:&quot;Arial&quot;,&quot;sans-serif&quot;;color:#606060;letter-spacing:.4pt'><u></u><u></u></span></p>
          </div>
          </td>
         </tr>
         <tr>
          <td width='3px' style='padding:1.0pt 1.0pt 1.0pt 15.0pt'>
          <div>
          <p class='MsoNormal' style='line-height:14.25pt'><span style='font-size:10.0pt;font-family:&quot;Arial&quot;,&quot;sans-serif&quot;;color:#606060;letter-spacing:.4pt'>Date &nbsp;&nbsp;&nbsp;: " + date_string + "</span></b><span style='font-size:10.0pt;font-family:&quot;Arial&quot;,&quot;sans-serif&quot;;color:#606060;letter-spacing:.4pt'><u></u><u></u></span>
          </div>
          </td>
         </tr>
         <tr>
          <td width='3px' style='padding:1.0pt 1.0pt 1.0pt 15.0pt'>
          <div>
          <p class='MsoNormal' style='line-height:14.25pt'><span style='font-size:10.0pt;font-family:&quot;Arial&quot;,&quot;sans-serif&quot;;color:#606060;letter-spacing:.4pt'>Note &nbsp;&nbsp;&nbsp;: " + comment + "</span></b><span style='font-size:10.0pt;font-family:&quot;Arial&quot;,&quot;sans-serif&quot;;color:#606060;letter-spacing:.4pt'><u></u><u></u></span>
          </div>
          </td>
         </tr>

         
         
         <tr>
          <td style='padding:15.0pt 15.0pt 15.0pt 15.0pt' colspan='3'>
            <table width='100%' class='m_1811720018273078822MsoNormalTable' border='1' cellspacing='0' cellpadding='5' style='background:white; font-size:12px;'>
            <tr bgcolor='#cecccc'>
              <th>Barcode</th>
              <th>Size</th>
              <th>Price</th>
              <th>Order</th>
              <th>Rec</th>
            </tr>"

            Dim total_order As Integer = 0
            Dim total_rec As Integer = 0
            Dim sub_total_order As Integer = 0
            Dim sub_total_rec As Integer = 0
            Dim last_code As String = ""
            For i As Integer = 0 To (data.Rows.Count - 1)
                If last_code <> data.Rows(i)("code").ToString Then
                    If i > 0 Then
                        body_temp += "<tr bgcolor='#f4f4f4'>
                            <td colspan='3'>SUBTOTAL</td>
                            <td>" + sub_total_order.ToString + "</td>
                            <td>" + sub_total_rec.ToString + "</td>
                        </tr>"
                        sub_total_order = 0
                        sub_total_rec = 0
                    End If
                    body_temp += "<tr bgcolor='#eff0f2'>
                        <td colspan='5' style='font-weight:bold;'>" + data.Rows(i)("code").ToString + " - " + data.Rows(i)("name").ToString + " - " + data.Rows(i)("prod_order_number").ToString + "</td>
                    </tr>"
                End If
                body_temp += "<tr>
                <td>" + data.Rows(i)("barcode").ToString + "</td>
                <td>" + data.Rows(i)("size").ToString + "</td>
                <td>" + Decimal.Parse(data.Rows(i)("design_price").ToString).ToString("N0") + "</td>
                <td>" + data.Rows(i)("order_qty").ToString + "</td>
                <td>" + data.Rows(i)("rec_qty").ToString + "</td>
                </tr>"
                last_code = data.Rows(i)("code").ToString
                total_order += data.Rows(i)("order_qty")
                total_rec += data.Rows(i)("rec_qty")
                sub_total_order += data.Rows(i)("order_qty")
                sub_total_rec += data.Rows(i)("rec_qty")
            Next
            body_temp += "<tr bgcolor='#f4f4f4'>
                            <td colspan='3'>SUBTOTAL</td>
                            <td>" + sub_total_order.ToString + "</td>
                            <td>" + sub_total_rec.ToString + "</td>
                        </tr>"
            body_temp += "
            <tr bgcolor='#cecccc'>
                <td colspan='3' style='font-weight:bold;'>TOTAL</td>
                <td style='font-weight:bold;'>" + total_order.ToString + "</td>
                <td style='font-weight:bold;'>" + total_rec.ToString + "</td>
            </tr>
            </table>
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
    </tbody>
</table> "
            mail.Subject = "BARCODE LABEL REQUISITION"
            mail.IsBodyHtml = True
            mail.Body = body_temp
            client.Send(mail)
        ElseIf report_mark_type = "43" Then
            If opt = "1" Then
                Dim from_mail As MailAddress = New MailAddress("system@volcom.co.id", "Master Product - Volcom ERP")
                Dim mail As MailMessage = New MailMessage()
                mail.From = from_mail

                'Send to => design_code : email; design : contact person;
                Dim to_mail As MailAddress = New MailAddress(design_code, design)
                mail.To.Add(to_mail)

                'Send CC
                Dim query_send_cc As String = "SELECT emp.`email_external`,emp.`employee_name` 
            FROM tb_mail_to md
            INNER JOIN tb_m_user usr ON usr.`id_user`=md.id_user
            INNER JOIN tb_m_employee emp ON emp.`id_employee`=usr.`id_employee`
            WHERE is_to='2' AND md.report_mark_type=43 "
                Dim data_send_cc As DataTable = execute_query(query_send_cc, -1, True, "", "", "", "")
                For i As Integer = 0 To data_send_cc.Rows.Count - 1
                    Dim to_mail_cc As MailAddress = New MailAddress(data_send_cc.Rows(i)("email_external").ToString, data_send_cc.Rows(i)("employee_name").ToString)
                    mail.CC.Add(to_mail_cc)
                Next
                Dim body_temp As String = "<table class='m_1811720018273078822MsoNormalTable' border='0' cellspacing='0' cellpadding='0' width='100%' style='width:100.0%;background:#eeeeee'>
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
            <table width='100%' class='m_1811720018273078822MsoNormalTable' border='0' cellspacing='0' cellpadding='0' style='background:white'>
             <tbody>
             <tr>
              <td style='padding:15.0pt 15.0pt 15.0pt 15.0pt' colspan='3'>
              <div>
              <p class='MsoNormal' style='line-height:14.25pt'><b><span style='font-family:&quot;Arial&quot;,&quot;sans-serif&quot;;color:#606060'>Dear " + design + ",</span></b><span style='font-size:10.0pt;font-family:&quot;Arial&quot;,&quot;sans-serif&quot;;color:#606060;letter-spacing:.4pt'><u></u><u></u></span></p>
              </div>
              </td>
             </tr>
             <tr>
              <td style='padding:1.0pt 1.0pt 1.0pt 15.0pt' colspan='3'>
              <div>
              <p class='MsoNormal' style='line-height:14.25pt'><span style='font-size:10.0pt;font-family:&quot;Arial&quot;,&quot;sans-serif&quot;;color:#606060;letter-spacing:.4pt'>Terlampir file master product periode pengiriman " + comment + "</span></b><span style='font-size:10.0pt;font-family:&quot;Arial&quot;,&quot;sans-serif&quot;;color:#606060;letter-spacing:.4pt'><u></u><u></u></span>
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
        </tbody>
    </table> "

                '-- start attachment 
                'Create a New report. 
                ReportMasterProductDelivery.id_del = par1
                ReportMasterProductDelivery.store = par2
                ReportMasterProductDelivery.period = comment
                Dim Report As New ReportMasterProductDelivery()

                ' Create a new memory stream and export the report into it as PDF.
                Dim Mem As New MemoryStream()
                Dim unik_file As String = execute_query("SELECT UNIX_TIMESTAMP(NOW())", 0, True, "", "", "", "")
                Report.ExportToXls(Mem)
                ' Create a new attachment and put the PDF report into it.
                Mem.Seek(0, System.IO.SeekOrigin.Begin)
                Dim Att = New Attachment(Mem, report_mark_type & "_" & id_report & "_" & unik_file & ".xls", "application/excel")
                mail.Attachments.Add(Att)
                '-- end attachment

                mail.Subject = "PT VOLCOM INDONESIA - MASTER PRODUCT"
                mail.IsBodyHtml = True
                mail.Body = body_temp
                client.Send(mail)
            ElseIf opt = "2" Then
                'konfirmasi pengiriman ke concept store
                Dim from_mail As MailAddress = New MailAddress("system@volcom.co.id", "Delivery Confirmation - Volcom ERP")
                Dim mail As MailMessage = New MailMessage()
                mail.From = from_mail

                'Send to => design_code : email; design : contact person;
                Dim query_send_to As String = "SELECT emp.`email_external`,emp.`employee_name` 
                FROM tb_mail_to_store md
                INNER JOIN tb_m_user usr ON usr.`id_user`=md.id_user
                INNER JOIN tb_m_employee emp ON emp.`id_employee`=usr.`id_employee`
                WHERE is_to='1' AND md.report_mark_type=43 AND md.opt=2 AND md.id_outlet=" + dt.Rows(0)("id_outlet").ToString + " "
                Dim data_send_to As DataTable = execute_query(query_send_to, -1, True, "", "", "", "")
                For i As Integer = 0 To data_send_to.Rows.Count - 1
                    Dim to_mail As MailAddress = New MailAddress(data_send_to.Rows(i)("email_external").ToString, data_send_to.Rows(i)("employee_name").ToString)
                    mail.To.Add(to_mail)
                Next

                'Send CC
                Dim query_send_cc As String = "SELECT emp.`email_external`,emp.`employee_name` 
                FROM tb_mail_to_store md
                INNER JOIN tb_m_user usr ON usr.`id_user`=md.id_user
                INNER JOIN tb_m_employee emp ON emp.`id_employee`=usr.`id_employee`
                WHERE is_to='2' AND md.report_mark_type=43 AND md.opt=2 AND md.id_outlet=" + dt.Rows(0)("id_outlet").ToString + " "
                Dim data_send_cc As DataTable = execute_query(query_send_cc, -1, True, "", "", "", "")
                For i As Integer = 0 To data_send_cc.Rows.Count - 1
                    Dim to_mail_cc As MailAddress = New MailAddress(data_send_cc.Rows(i)("email_external").ToString, data_send_cc.Rows(i)("employee_name").ToString)
                    mail.CC.Add(to_mail_cc)
                Next

                Dim body_temp As String = " <table class='m_1811720018273078822MsoNormalTable' border='0' cellspacing='0' cellpadding='0' width='100%' style='width:100.0%;background:#eeeeee'>
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
                

                <!-- start body -->
                <table width='100%' class='m_1811720018273078822MsoNormalTable' border='0' cellspacing='0' cellpadding='0' style='background:white'>
                 <tbody>
                 <tr>
                  <td style='padding:15.0pt 15.0pt 5.0pt 15.0pt' colspan='3'>
                  <div>
                  <p class='MsoNormal' style='line-height:14.25pt'><b><span style='font-family:&quot;Arial&quot;,&quot;sans-serif&quot;;color:#606060'>DELIVERY CONFIRMATION</span></b><span style='font-size:10.0pt;font-family:&quot;Arial&quot;,&quot;sans-serif&quot;;color:#606060;letter-spacing:.4pt'><u></u><u></u></span></p>
                  </div>
                  </td>
                 </tr>

                 <tr>
                 	<td colspan='3'>
	                  	<table width='100%' style='padding:5.0pt 5.0pt 0.0pt 14.0pt; font-size:10.0pt; font-family:&quot;Arial&quot;,&quot;sans-serif&quot;;color:#606060; border-spacing:0 7px;' border='0'>
		                  	<tr>
		                  		<td width='20%'>Store Account</td>
		                  		<td width='2%'>:</td>
		                  		<td width='77%'>" + dt.Rows(0)("store_account").ToString + "</td>
		                  	</tr>

		                  	<tr>
		                  		<td width='20%'>Delivery No.</td>
		                  		<td width='2%'>:</td>
		                  		<td width='77%'>" + dt.Rows(0)("del_number").ToString + "</td>
		                  	</tr>

		                  	<tr>
		                  		<td width='20%'>Delivered at</td>
		                  		<td width='2%'>:</td>
		                  		<td width='77%'>" + dt.Rows(0)("del_date").ToString + "</td>
		                  	</tr>

		                  	<tr>
		                  		<td width='20%'>Total Qty</td>
		                  		<td width='2%'>:</td>
		                  		<td width='77%'>" + Decimal.Parse(dt.Rows(0)("total_qty").ToString).ToString("N0") + "</td>
		                  	</tr>

		                  	<tr>
		                  		<td width='20%'>Amount</td>
		                  		<td width='2%'>:</td>
		                  		<td width='77%'>" + Decimal.Parse(dt.Rows(0)("amount").ToString).ToString("N0") + "</td>
		                  	</tr>
		                 
	                  	</table>
	                 </td>
                 </tr>


         
          <tr>
                  <td style='padding:15.0pt 15.0pt 15.0pt 15.0pt' colspan='3'>
                  <div>
                  <p class='MsoNormal' style='line-height:14.25pt'><span style='font-size:10.0pt;font-family:&quot;Arial&quot;,&quot;sans-serif&quot;;color:#606060;letter-spacing:.4pt'>Delivery details attached in PDF<u></u><u></u></span></p>
                  <p class='MsoNormal' style='line-height:14.25pt'><span style='font-size:10.0pt;font-family:&quot;Arial&quot;,&quot;sans-serif&quot;;color:#606060;letter-spacing:.4pt'>Thank you<br /><b>Volcom ERP</b><u></u><u></u></span></p>

                  </div>
                  </td>
                 </tr>
                </tbody>
              </table>
              <!-- end body -->


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
            </tbody>
        </table> "

                '-- start attachment 
                Dim id_commerce_type As String = execute_query("SELECT id_commerce_type FROM tb_m_comp WHERE id_comp = " + dt.Rows(0)("id_store").ToString, 0, True, "", "", "", "")

                If id_commerce_type = "2" Then
                    ReportSalesDelOrderOwnStore2.id_pre = "1"
                    ReportSalesDelOrderOwnStore2.id = id_report
                    ReportSalesDelOrderOwnStore2.rmt = dt.Rows(0)("rmt").ToString
                    ReportSalesDelOrderOwnStore2.id_report_status = "6"
                    ReportSalesDelOrderOwnStore2.id_store = dt.Rows(0)("id_store").ToString
                    ReportSalesDelOrderOwnStore2.is_combine = dt.Rows(0)("is_combine").ToString
                    ReportSalesDelOrderOwnStore2.is_use_unique_code = dt.Rows(0)("is_use_unique_code").ToString
                    ReportSalesDelOrderOwnStore2.is_no_print = "1"
                    Dim Report As New ReportSalesDelOrderOwnStore2()


                    'Grid Detail
                    'ReportStyleGridviewBlackLine(Report.GVItemList)

                    'Parse val
                    Report.LabelTo.Text = dt.Rows(0)("store_account").ToString
                    Report.LabelFrom.Text = dt.Rows(0)("wh_account").ToString
                    Report.LabelAddress.Text = dt.Rows(0)("store_address").ToString
                    Report.LRecDate.Text = dt.Rows(0)("del_created_date").ToString
                    Report.LRecNumber.Text = dt.Rows(0)("del_number").ToString
                    Report.LabelNote.Text = dt.Rows(0)("note").ToString
                    Report.LabelPrepare.Text = dt.Rows(0)("order_number").ToString
                    Report.LabelCat.Text = dt.Rows(0)("order_cat").ToString
                    'Report.LabelUni3.Text = "-"
                    Report.LabelUni6.Text = "-"
                    Report.PanelUni.Visible = False

                    ' Create a new memory stream and export the report into it as PDF.
                    Dim Mem As New MemoryStream()
                    Dim unik_file As String = execute_query("SELECT UNIX_TIMESTAMP(NOW())", 0, True, "", "", "", "")
                    Report.ExportToPdf(Mem)
                    ' Create a new attachment and put the PDF report into it.
                    Mem.Seek(0, System.IO.SeekOrigin.Begin)
                    Dim Att = New Attachment(Mem, report_mark_type & "_" & unik_file & ".pdf", "application/pdf")
                    mail.Attachments.Add(Att)
                    '-- end attachment

                    mail.Subject = "Delivery Confirmation - " + dt.Rows(0)("del_number").ToString
                    mail.IsBodyHtml = True
                    mail.Body = body_temp
                    client.Send(mail)
                Else
                    ReportSalesDelOrderOwnStore.id_pre = "1"
                    ReportSalesDelOrderOwnStore.id = id_report
                    ReportSalesDelOrderOwnStore.rmt = dt.Rows(0)("rmt").ToString
                    ReportSalesDelOrderOwnStore.id_report_status = "6"
                    ReportSalesDelOrderOwnStore.id_store = dt.Rows(0)("id_store").ToString
                    ReportSalesDelOrderOwnStore.is_combine = dt.Rows(0)("is_combine").ToString
                    ReportSalesDelOrderOwnStore.is_use_unique_code = dt.Rows(0)("is_use_unique_code").ToString
                    ReportSalesDelOrderOwnStore.is_no_print = "1"
                    Dim Report As New ReportSalesDelOrderOwnStore()


                    'Grid Detail
                    'ReportStyleGridviewBlackLine(Report.GVItemList)

                    'Parse val
                    Report.LabelTo.Text = dt.Rows(0)("store_account").ToString
                    Report.LabelFrom.Text = dt.Rows(0)("wh_account").ToString
                    Report.LabelAddress.Text = dt.Rows(0)("store_address").ToString
                    Report.LRecDate.Text = dt.Rows(0)("del_created_date").ToString
                    Report.LRecNumber.Text = dt.Rows(0)("del_number").ToString
                    Report.LabelNote.Text = dt.Rows(0)("note").ToString
                    Report.LabelPrepare.Text = dt.Rows(0)("order_number").ToString
                    Report.LabelCat.Text = dt.Rows(0)("order_cat").ToString
                    'Report.LabelUni3.Text = "-"
                    Report.LabelUni6.Text = "-"
                    Report.PanelUni.Visible = False

                    ' Create a new memory stream and export the report into it as PDF.
                    Dim Mem As New MemoryStream()
                    Dim unik_file As String = execute_query("SELECT UNIX_TIMESTAMP(NOW())", 0, True, "", "", "", "")
                    Report.ExportToPdf(Mem)
                    ' Create a new attachment and put the PDF report into it.
                    Mem.Seek(0, System.IO.SeekOrigin.Begin)
                    Dim Att = New Attachment(Mem, report_mark_type & "_" & unik_file & ".pdf", "application/pdf")
                    mail.Attachments.Add(Att)
                    '-- end attachment

                    mail.Subject = "Delivery Confirmation - " + dt.Rows(0)("del_number").ToString
                    mail.IsBodyHtml = True
                    mail.Body = body_temp
                    client.Send(mail)
                End If
            End If
        ElseIf report_mark_type = "39" Then
            Dim from_mail As MailAddress = New MailAddress("system@volcom.co.id", "Online Store Order - Volcom ERP")
            Dim mail As MailMessage = New MailMessage()
            mail.From = from_mail

            'Send to => design_code : email; design : contact person;
            Dim query_send_to As String = "SELECT emp.`email_external`,emp.`employee_name` 
            FROM tb_mail_to md
            INNER JOIN tb_m_user usr ON usr.`id_user`=md.id_user
            INNER JOIN tb_m_employee emp ON emp.`id_employee`=usr.`id_employee`
            WHERE is_to='1' AND md.report_mark_type=39 "
            Dim data_send_to As DataTable = execute_query(query_send_to, -1, True, "", "", "", "")
            For i As Integer = 0 To data_send_to.Rows.Count - 1
                Dim to_mail As MailAddress = New MailAddress(data_send_to.Rows(i)("email_external").ToString, data_send_to.Rows(i)("employee_name").ToString)
                mail.To.Add(to_mail)
            Next

            'Send CC
            Dim query_send_cc As String = "SELECT emp.`email_external`,emp.`employee_name` 
            FROM tb_mail_to md
            INNER JOIN tb_m_user usr ON usr.`id_user`=md.id_user
            INNER JOIN tb_m_employee emp ON emp.`id_employee`=usr.`id_employee`
            WHERE is_to='2' AND md.report_mark_type=39 "
            Dim data_send_cc As DataTable = execute_query(query_send_cc, -1, True, "", "", "", "")
            For i As Integer = 0 To data_send_cc.Rows.Count - 1
                Dim to_mail_cc As MailAddress = New MailAddress(data_send_cc.Rows(i)("email_external").ToString, data_send_cc.Rows(i)("employee_name").ToString)
                mail.CC.Add(to_mail_cc)
            Next

            Dim body_temp As String = "  <table class='m_1811720018273078822MsoNormalTable' border='0' cellspacing='0' cellpadding='0' width='100%' style='width:100.0%;background:#eeeeee'>
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
                <table width='100%' class='m_1811720018273078822MsoNormalTable' border='0' cellspacing='0' cellpadding='0' style='background:white'>
                 <tbody>
                 <tr>
                  <td style='padding:15.0pt 15.0pt 15.0pt 15.0pt' colspan='3'>
                  <div>
                  <p class='MsoNormal' style='line-height:14.25pt'><b><span style='font-family:&quot;Arial&quot;,&quot;sans-serif&quot;;color:#606060'>ONLINE STORE ORDER</span></b><span style='font-size:10.0pt;font-family:&quot;Arial&quot;,&quot;sans-serif&quot;;color:#606060;letter-spacing:.4pt'><u></u><u></u></span></p>
                  </div>
                  </td>
                 </tr>

                 <tr>
                  <td style='padding:5.0pt 5.0pt 5.0pt 15.0pt;'>
                    <p class='MsoNormal' style='line-height:10.25pt'>
                      <span style='font-size:10.0pt; font-family:&quot;Arial&quot;,&quot;sans-serif&quot;;color:#606060'>
                        Store
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        :
                        &nbsp;&nbsp;
                        " + design + "
                      </span>
                    </p>
                  </td>
                 </tr>

                 <tr>
                  <td style='padding:5.0pt 5.0pt 5.0pt 15.0pt;'>
                    <p class='MsoNormal' style='line-height:10.25pt'>
                      <span style='font-size:10.0pt; font-family:&quot;Arial&quot;,&quot;sans-serif&quot;;color:#606060'>
                        Order No.
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        :
                        &nbsp;&nbsp;
                         " + design_code + "
                      </span>
                    </p>
                  </td>
                 </tr>

                 <tr>
                  <td style='padding:5.0pt 5.0pt 5.0pt 15.0pt;'>
                    <p class='MsoNormal' style='line-height:10.25pt'>
                      <span style='font-size:10.0pt; font-family:&quot;Arial&quot;,&quot;sans-serif&quot;;color:#606060'>
                        Customer
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        :
                        &nbsp;&nbsp;
                          " + comment_by + "
                      </span>
                    </p>
                  </td>
                 </tr>

         
         
                 <tr>
                  <td style='padding:15.0pt 15.0pt 15.0pt 15.0pt' colspan='3'>
                    <table width='100%' class='m_1811720018273078822MsoNormalTable' border='1' cellspacing='0' cellpadding='5' style='background:white; font-size: 12px; font-family:&quot;Arial&quot;,&quot;sans-serif&quot;;color:#606060'>
                    <tr>
                      <th>ERP Order#</th>
                      <th>WH Account</th>
                      <th>Store Account</th>
                      <th>Qty</th>
                    </tr>"

            Dim query_so As String = "SELECT so.id_sales_order, so.sales_order_number, c.comp_number AS `store_number`, wh.comp_number AS `wh_number`, CAST(SUM(sod.sales_order_det_qty) AS DECIMAL(10,0)) AS `qty`
            FROM tb_sales_order so
            INNER JOIN tb_sales_order_det sod ON sod.id_sales_order = so.id_sales_order
            INNER JOIN tb_m_comp_contact socc ON socc.id_comp_contact = so.id_store_contact_to
            INNER JOIN tb_m_comp c ON c.id_comp = socc.id_comp
            INNER JOIN tb_m_comp_contact wh_c ON wh_c.id_comp_contact = so.id_warehouse_contact_to 
            INNER JOIN tb_m_comp wh ON wh_c.id_comp = wh.id_comp 
            WHERE so.sales_order_ol_shop_number='" + design_code + "'
            AND (" + id_report + ")
            GROUP BY so.id_sales_order "
            Dim data_so As DataTable = execute_query(query_so, "-1", True, "", "", "", "")
            Dim total_qty As Integer = 0
            For i As Integer = 0 To data_so.Rows.Count - 1
                body_temp += "<tr>
                                    <td>" + data_so.Rows(i)("sales_order_number").ToString + "</td>
                                    <td>" + data_so.Rows(i)("wh_number").ToString + "</td>
                                    <td>" + data_so.Rows(i)("store_number").ToString + "</td>
                                    <td align='center'>" + data_so.Rows(i)("qty").ToString + "</td>
                                </tr> "
                total_qty += data_so.Rows(i)("qty")

                '-- start attachment -sementara comment dl
                'Dim query_attach As String = "SELECT doc.id_doc, CONCAT(doc.id_doc,'_',doc.report_mark_type,'_',doc.id_report,'',doc.ext) AS filename, doc.*
                'FROM tb_doc doc
                'WHERE doc.report_mark_type='39' AND doc.id_report='" + data_so.Rows(i)("id_sales_order").ToString + "' "
                'Dim data_attach As DataTable = execute_query(query_attach, -1, True, "", "", "", "")
                'For d As Integer = 0 To data_attach.Rows.Count - 1
                '    Dim path As String = comment & report_mark_type & "\" & data_attach.Rows(d)("filename").ToString
                '    Dim Att = New Attachment(path)
                '    mail.Attachments.Add(Att)
                'Next
                '-- end attachment
            Next
            body_temp += "<tr>
                            <th colspan='3'>TOTAL ORDER</td>
                            <th>" + total_qty.ToString + "</th>
                        </tr> "

            body_temp += "</table>
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
            </tbody>
        </table> "

            mail.Subject = "" + design.ToUpper + " ORDER " + design_code + " - SO"
            mail.IsBodyHtml = True
            mail.Body = body_temp
            client.Send(mail)
        ElseIf report_mark_type = "43_confirm" Then
            Dim from_mail As MailAddress = New MailAddress("system@volcom.co.id", "Delivery Confirmation - Volcom ERP")
            Dim mail As MailMessage = New MailMessage()
            mail.From = from_mail

            'Send to => design_code : email; design : contact person;
            Dim query_send_to As String = "SELECT emp.`email_external`,emp.`employee_name` 
            FROM tb_mail_del_confirm md
            INNER JOIN tb_m_user usr ON usr.`id_user`=md.id_user
            INNER JOIN tb_m_employee emp ON emp.`id_employee`=usr.`id_employee`
            WHERE is_to='1' "
            Dim data_send_to As DataTable = execute_query(query_send_to, -1, True, "", "", "", "")
            For i As Integer = 0 To data_send_to.Rows.Count - 1
                Dim to_mail As MailAddress = New MailAddress(data_send_to.Rows(i)("email_external").ToString, data_send_to.Rows(i)("employee_name").ToString)
                mail.To.Add(to_mail)
            Next

            'Send CC
            Dim query_send_cc As String = "SELECT emp.`email_external`,emp.`employee_name` 
            FROM tb_mail_del_confirm md
            INNER JOIN tb_m_user usr ON usr.`id_user`=md.id_user
            INNER JOIN tb_m_employee emp ON emp.`id_employee`=usr.`id_employee`
            WHERE is_to='2' "
            Dim data_send_cc As DataTable = execute_query(query_send_cc, -1, True, "", "", "", "")
            For i As Integer = 0 To data_send_cc.Rows.Count - 1
                Dim to_mail_cc As MailAddress = New MailAddress(data_send_cc.Rows(i)("email_external").ToString, data_send_cc.Rows(i)("employee_name").ToString)
                mail.CC.Add(to_mail_cc)
            Next

            Dim body_temp As String = " <table class='m_1811720018273078822MsoNormalTable' border='0' cellspacing='0' cellpadding='0' width='100%' style='width:100.0%;background:#eeeeee'>
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
                

                <!-- start body -->
                <table width='100%' class='m_1811720018273078822MsoNormalTable' border='0' cellspacing='0' cellpadding='0' style='background:white'>
                 <tbody>
                 <tr>
                  <td style='padding:15.0pt 15.0pt 5.0pt 15.0pt' colspan='3'>
                  <div>
                  <p class='MsoNormal' style='line-height:14.25pt'><b><span style='font-family:&quot;Arial&quot;,&quot;sans-serif&quot;;color:#606060'>DELIVERY CONFIRMATION</span></b><span style='font-size:10.0pt;font-family:&quot;Arial&quot;,&quot;sans-serif&quot;;color:#606060;letter-spacing:.4pt'><u></u><u></u></span></p>
                  </div>
                  </td>
                 </tr>

                 <tr>
                 	<td colspan='3'>
	                  	<table width='100%' style='padding:5.0pt 5.0pt 0.0pt 14.0pt; font-size:10.0pt; font-family:&quot;Arial&quot;,&quot;sans-serif&quot;;color:#606060; border-spacing:0 7px;' border='0'>
		                  	<tr>
		                  		<td width='25%'>Store Account</td>
		                  		<td width='2%'>:</td>
		                  		<td width='73%'>" + dt.Rows(0)("store").ToString + "</td>
		                  	</tr>

		                  	<tr>
		                  		<td width='25%'>Delivery No.</td>
		                  		<td width='2%'>:</td>
		                  		<td width='73%'>" + dt.Rows(0)("del_number").ToString + "</td>
		                  	</tr>

		                  	<tr>
		                  		<td width='25%'>Delivered Date</td>
		                  		<td width='2%'>:</td>
		                  		<td width='73%'>" + dt.Rows(0)("del_date").ToString + "</td>
		                  	</tr>

		                  

		                  	<tr>
		                  		<td width='25%'>Order No.</td>
		                  		<td width='2%'>:</td>
		                  		<td width='73%'>" + dt.Rows(0)("ol_store_order_number").ToString + "</td>
		                  	</tr>

		                  	<tr>
		                  		<td width='25%'>ERP Order No.</td>
		                  		<td width='2%'>:</td>
		                  		<td width='73%'>" + dt.Rows(0)("order_number").ToString + "</td>
		                  	</tr>

		                  	<tr>
		                  		<td width='25%'>Order Date</td>
		                  		<td width='2%'>:</td>
		                  		<td width='73%'>" + dt.Rows(0)("order_date").ToString + "</td>
		                  	</tr>

		                  	<tr>
		                  		<td width='25%'>Customer</td>
		                  		<td width='2%'>:</td>
		                  		<td width='73%'>" + dt.Rows(0)("customer_name").ToString + "</td>
		                  	</tr>

		                  	<tr>
		                  		<td width='25%'></td>
		                  		<td width='2%'></td>
		                  		<td width='73%'></td>
		                  	</tr>

		                  	<tr>
		                  		<td width='25%'><b>Detail Items</b></td>
		                  		<td width='2%'><b></b></td>
		                  		<td width='73%'></td>
		                  	</tr>
	                  	</table>
	                 </td>
                 </tr>

               
         
                 <tr>
                  <td style='padding:1.0pt 15.0pt 15.0pt 15.0pt' colspan='3'>
                    <table width='100%' class='m_1811720018273078822MsoNormalTable' border='1' cellspacing='0' cellpadding='5' style='background:white; font-size: 12px; font-family:&quot;Arial&quot;,&quot;sans-serif&quot;;color:#606060'>
                    <tr>
                      <th>Barcode</th>
                      <th>Item Id</th>
                      <th>OL Store Id</th>
                      <th>Description</th>
                      <th>Size</th>
                      <th>Qty</th>
                    </tr> "

            Dim query_det As String = "SELECT dd.id_pl_sales_order_del_det, sod.id_sales_order_det, sod.item_id, sod.ol_store_id , 
            dd.id_product, prod.product_full_code AS `barcode`, prod.product_display_name AS `name`, cd.code_detail_name AS `size`, CAST(dd.pl_sales_order_del_det_qty AS DECIMAL(10,0)) AS `qty`
            FROM tb_pl_sales_order_del_det dd
            INNER JOIN tb_sales_order_det sod ON sod.id_sales_order_det = dd.id_sales_order_det
            INNER JOIN tb_m_product prod ON prod.id_product = dd.id_product
            INNER JOIN tb_m_product_code prodc ON prodc.id_product = prod.id_product
            INNER JOIN tb_m_code_detail cd ON cd.id_code_detail = prodc.id_code_detail
            WHERE dd.id_pl_sales_order_del='" + id_report + "' "
            Dim data_det As DataTable = execute_query(query_det, -1, True, "", "", "", "")
            Dim total_qty As Integer = 0
            For i As Integer = 0 To data_det.Rows.Count - 1
                body_temp += "<tr>
                                    <td>" + data_det.Rows(i)("barcode").ToString + "</td>
                                    <td>" + data_det.Rows(i)("item_id").ToString + "</td>
                                    <td>" + data_det.Rows(i)("ol_store_id").ToString + "</td>
                                    <td>" + data_det.Rows(i)("name").ToString + "</td>
                                    <td>" + data_det.Rows(i)("size").ToString + "</td>
                                    <td align='center'>" + data_det.Rows(i)("qty").ToString + "</td>
                                </tr> "
                total_qty += data_det.Rows(i)("qty")
            Next

            body_temp += "<tr>
                            <th colspan='5'>TOTAL</td>
                            <th>" + total_qty.ToString + "</th>
                        </tr> "


            body_temp += "</table>
                  </td>

                 </tr>

         
          <tr>
                  <td style='padding:15.0pt 15.0pt 15.0pt 15.0pt' colspan='3'>
                  <div>
                  <p class='MsoNormal' style='line-height:14.25pt'><span style='font-size:10.0pt;font-family:&quot;Arial&quot;,&quot;sans-serif&quot;;color:#606060;letter-spacing:.4pt'>Thank you<br /><b>Volcom ERP</b><u></u><u></u></span></p>

                  </div>
                  </td>
                 </tr>
                </tbody>
              </table>
              <!-- end body -->


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
            </tbody>
        </table> "

            mail.Subject = "" + dt.Rows(0)("store_group").ToString + " ORDER " + dt.Rows(0)("ol_store_order_number").ToString + " - DEL"
            mail.IsBodyHtml = True
            mail.Body = body_temp
            client.Send(mail)
        ElseIf report_mark_type = "43_ready" Then
            'READY TO SHIP
            Dim from_mail As MailAddress = New MailAddress("system@volcom.co.id", "Ready to Ship - Volcom ERP")
            Dim mail As MailMessage = New MailMessage()
            mail.From = from_mail

            'Send to => design_code : email; design : contact person;
            Dim query_send_to As String = "SELECT emp.`email_external`,emp.`employee_name` 
            FROM tb_mail_del_confirm md
            INNER JOIN tb_m_user usr ON usr.`id_user`=md.id_user
            INNER JOIN tb_m_employee emp ON emp.`id_employee`=usr.`id_employee`
            WHERE is_to='1' "
            Dim data_send_to As DataTable = execute_query(query_send_to, -1, True, "", "", "", "")
            For i As Integer = 0 To data_send_to.Rows.Count - 1
                Dim to_mail As MailAddress = New MailAddress(data_send_to.Rows(i)("email_external").ToString, data_send_to.Rows(i)("employee_name").ToString)
                mail.To.Add(to_mail)
            Next

            'Send CC
            Dim query_send_cc As String = "SELECT emp.`email_external`,emp.`employee_name` 
            FROM tb_mail_del_confirm md
            INNER JOIN tb_m_user usr ON usr.`id_user`=md.id_user
            INNER JOIN tb_m_employee emp ON emp.`id_employee`=usr.`id_employee`
            WHERE is_to='2' "
            Dim data_send_cc As DataTable = execute_query(query_send_cc, -1, True, "", "", "", "")
            For i As Integer = 0 To data_send_cc.Rows.Count - 1
                Dim to_mail_cc As MailAddress = New MailAddress(data_send_cc.Rows(i)("email_external").ToString, data_send_cc.Rows(i)("employee_name").ToString)
                mail.CC.Add(to_mail_cc)
            Next

            Dim body_temp As String = " <table class='m_1811720018273078822MsoNormalTable' border='0' cellspacing='0' cellpadding='0' width='100%' style='width:100.0%;background:#eeeeee'>
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
                

                <!-- start body -->
                <table width='100%' class='m_1811720018273078822MsoNormalTable' border='0' cellspacing='0' cellpadding='0' style='background:white'>
                 <tbody>
                 <tr>
                  <td style='padding:15.0pt 15.0pt 5.0pt 15.0pt' colspan='3'>
                  <div>
                  <p class='MsoNormal' style='line-height:14.25pt'><b><span style='font-family:&quot;Arial&quot;,&quot;sans-serif&quot;;color:#606060'>READY TO SHIP</span></b><span style='font-size:10.0pt;font-family:&quot;Arial&quot;,&quot;sans-serif&quot;;color:#606060;letter-spacing:.4pt'><u></u><u></u></span></p>
                  </div>
                  </td>
                 </tr>

                 <tr>
                 	<td colspan='3'>
	                  	<table width='100%' style='padding:5.0pt 5.0pt 0.0pt 14.0pt; font-size:10.0pt; font-family:&quot;Arial&quot;,&quot;sans-serif&quot;;color:#606060; border-spacing:0 7px;' border='0'>
		                  	<tr>
		                  		<td width='25%'>Store Account</td>
		                  		<td width='2%'>:</td>
		                  		<td width='73%'>" + dt.Rows(0)("store").ToString + "</td>
		                  	</tr>

		                  	<tr>
		                  		<td width='25%'>Delivery No.</td>
		                  		<td width='2%'>:</td>
		                  		<td width='73%'>" + dt.Rows(0)("del_number").ToString + "</td>
		                  	</tr>

		                  	<tr>
		                  		<td width='25%'>Approved Date</td>
		                  		<td width='2%'>:</td>
		                  		<td width='73%'>" + dt.Rows(0)("appr_date").ToString + "</td>
		                  	</tr>

		                  

		                  	<tr>
		                  		<td width='25%'>Order No.</td>
		                  		<td width='2%'>:</td>
		                  		<td width='73%'>" + dt.Rows(0)("ol_store_order_number").ToString + "</td>
		                  	</tr>

		                  	<tr>
		                  		<td width='25%'>ERP Order No.</td>
		                  		<td width='2%'>:</td>
		                  		<td width='73%'>" + dt.Rows(0)("order_number").ToString + "</td>
		                  	</tr>

		                  	<tr>
		                  		<td width='25%'>Order Date</td>
		                  		<td width='2%'>:</td>
		                  		<td width='73%'>" + dt.Rows(0)("order_date").ToString + "</td>
		                  	</tr>

		                  	<tr>
		                  		<td width='25%'>Customer</td>
		                  		<td width='2%'>:</td>
		                  		<td width='73%'>" + dt.Rows(0)("customer_name").ToString + "</td>
		                  	</tr>

		                  	<tr>
		                  		<td width='25%'></td>
		                  		<td width='2%'></td>
		                  		<td width='73%'></td>
		                  	</tr>

		                  	<tr>
		                  		<td width='25%'><b>Detail Items</b></td>
		                  		<td width='2%'><b></b></td>
		                  		<td width='73%'></td>
		                  	</tr>
	                  	</table>
	                 </td>
                 </tr>

               
         
                 <tr>
                  <td style='padding:1.0pt 15.0pt 15.0pt 15.0pt' colspan='3'>
                    <table width='100%' class='m_1811720018273078822MsoNormalTable' border='1' cellspacing='0' cellpadding='5' style='background:white; font-size: 12px; font-family:&quot;Arial&quot;,&quot;sans-serif&quot;;color:#606060'>
                    <tr>
                      <th>Barcode</th>
                      <th>Item Id</th>
                      <th>OL Store Id</th>
                      <th>Description</th>
                      <th>Size</th>
                      <th>Qty</th>
                    </tr> "

            Dim query_det As String = "SELECT dd.id_pl_sales_order_del_det, sod.id_sales_order_det, sod.item_id, sod.ol_store_id , 
            dd.id_product, prod.product_full_code AS `barcode`, prod.product_display_name AS `name`, cd.code_detail_name AS `size`, CAST(dd.pl_sales_order_del_det_qty AS DECIMAL(10,0)) AS `qty`
            FROM tb_pl_sales_order_del_det dd
            INNER JOIN tb_sales_order_det sod ON sod.id_sales_order_det = dd.id_sales_order_det
            INNER JOIN tb_m_product prod ON prod.id_product = dd.id_product
            INNER JOIN tb_m_product_code prodc ON prodc.id_product = prod.id_product
            INNER JOIN tb_m_code_detail cd ON cd.id_code_detail = prodc.id_code_detail
            WHERE dd.id_pl_sales_order_del='" + id_report + "' "
            Dim data_det As DataTable = execute_query(query_det, -1, True, "", "", "", "")
            Dim total_qty As Integer = 0
            For i As Integer = 0 To data_det.Rows.Count - 1
                body_temp += "<tr>
                                    <td>" + data_det.Rows(i)("barcode").ToString + "</td>
                                    <td>" + data_det.Rows(i)("item_id").ToString + "</td>
                                    <td>" + data_det.Rows(i)("ol_store_id").ToString + "</td>
                                    <td>" + data_det.Rows(i)("name").ToString + "</td>
                                    <td>" + data_det.Rows(i)("size").ToString + "</td>
                                    <td align='center'>" + data_det.Rows(i)("qty").ToString + "</td>
                                </tr> "
                total_qty += data_det.Rows(i)("qty")
            Next

            body_temp += "<tr>
                            <th colspan='5'>TOTAL</td>
                            <th>" + total_qty.ToString + "</th>
                        </tr> "


            body_temp += "</table>
                  </td>

                 </tr>

         
          <tr>
                  <td style='padding:15.0pt 15.0pt 15.0pt 15.0pt' colspan='3'>
                  <div>
                  <p class='MsoNormal' style='line-height:14.25pt'><span style='font-size:10.0pt;font-family:&quot;Arial&quot;,&quot;sans-serif&quot;;color:#606060;letter-spacing:.4pt'>Thank you<br /><b>Volcom ERP</b><u></u><u></u></span></p>

                  </div>
                  </td>
                 </tr>
                </tbody>
              </table>
              <!-- end body -->


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
            </tbody>
        </table> "

            mail.Subject = "" + dt.Rows(0)("store_group").ToString + " ORDER " + dt.Rows(0)("ol_store_order_number").ToString + " - READY TO SHIP"
            mail.IsBodyHtml = True
            mail.Body = body_temp
            client.Send(mail)
        ElseIf report_mark_type = "in_store_date_actual" Then
            Dim from_mail As MailAddress = New MailAddress("system@volcom.co.id", "Update Actual In Store Date - Volcom ERP")
            Dim mail As MailMessage = New MailMessage()
            mail.From = from_mail

            'Send to => design_code : email; design : contact person;
            Dim query_send_to As String = "SELECT emp.`email_external`,emp.`employee_name` 
            FROM tb_mail_in_store_date md
            INNER JOIN tb_m_user usr ON usr.`id_user`=md.id_user
            INNER JOIN tb_m_employee emp ON emp.`id_employee`=usr.`id_employee`
            WHERE is_to='1' "
            Dim data_send_to As DataTable = execute_query(query_send_to, -1, True, "", "", "", "")
            For i As Integer = 0 To data_send_to.Rows.Count - 1
                Dim to_mail As MailAddress = New MailAddress(data_send_to.Rows(i)("email_external").ToString, data_send_to.Rows(i)("employee_name").ToString)
                mail.To.Add(to_mail)
            Next

            'Send CC
            Dim query_send_cc As String = "SELECT emp.`email_external`,emp.`employee_name` 
            FROM tb_mail_in_store_date md
            INNER JOIN tb_m_user usr ON usr.`id_user`=md.id_user
            INNER JOIN tb_m_employee emp ON emp.`id_employee`=usr.`id_employee`
            WHERE is_to='2' "
            Dim data_send_cc As DataTable = execute_query(query_send_cc, -1, True, "", "", "", "")
            For i As Integer = 0 To data_send_cc.Rows.Count - 1
                Dim to_mail_cc As MailAddress = New MailAddress(data_send_cc.Rows(i)("email_external").ToString, data_send_cc.Rows(i)("employee_name").ToString)
                mail.CC.Add(to_mail_cc)
            Next

            Dim body_temp As String = " <table class='m_1811720018273078822MsoNormalTable' border='0' cellspacing='0' cellpadding='0' width='100%' style='width:100.0%;background:#eeeeee'>
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
                

                <!-- start body -->
                <table width='100%' class='m_1811720018273078822MsoNormalTable' border='0' cellspacing='0' cellpadding='0' style='background:white'>
                 <tbody>
                 <tr>
                  <td style='padding:15.0pt 15.0pt 15.0pt 15.0pt' colspan='3'>
                  <div>
                  <p class='MsoNormal' style='line-height:14.25pt'><b><span style='font-family:&quot;Arial&quot;,&quot;sans-serif&quot;;color:#606060'>UPDATE ACTUAL IN-STORE DATE</span></b><span style='font-size:10.0pt;font-family:&quot;Arial&quot;,&quot;sans-serif&quot;;color:#606060;letter-spacing:.4pt'><u></u><u></u></span></p>
                  </div>
                  </td>
                 </tr>

                 <tr>
                  <td style='padding:5.0pt 5.0pt 5.0pt 15.0pt;'>
                    <p class='MsoNormal' style='line-height:10.25pt'>
                      <span style='font-size:10.0pt; font-family:&quot;Arial&quot;,&quot;sans-serif&quot;;color:#606060'>
                       Design with detail below :
                      </span>
                    </p>
                  </td>
                 </tr>


            


         
         
                 <tr>
                  <td style='padding:15.0pt 15.0pt 15.0pt 15.0pt' colspan='3'>
                    <table width='100%' class='m_1811720018273078822MsoNormalTable' border='1' cellspacing='0' cellpadding='5' style='background:white; font-size: 12px; font-family:&quot;Arial&quot;,&quot;sans-serif&quot;;color:#606060'>
                    <tr>
                      <th>Code</th>
                      <th>Description</th>
                    </tr> "


            Dim qc As String = "SELECT d.design_code AS `code`, d.design_display_name AS `name` FROM tb_m_design d WHERE (" + design + ") "
            Dim dc As DataTable = execute_query(qc, -1, True, "", "", "", "")
            For i As Integer = 0 To dc.Rows.Count - 1
                body_temp += " <tr>
                    <td>" + dc.Rows(i)("code").ToString + "</td>
                    <td>" + dc.Rows(i)("name").ToString + "</td>
               </tr>"
            Next




            body_temp += "</table>
                  </td>

                 </tr>

                 <tr>
                  <td style='padding:5.0pt 5.0pt 5.0pt 15.0pt;'>
                    <p class='MsoNormal' style='line-height:10.25pt'>
                      <span style='font-size:10.0pt; font-family:&quot;Arial&quot;,&quot;sans-serif&quot;;color:#606060'>
                       scheduled to be in store on <b>" + date_string + "</b>
                      </span>
                    </p>
                  </td>
                 </tr>



         
          <tr>
                  <td style='padding:15.0pt 15.0pt 15.0pt 15.0pt' colspan='3'>
                  <div>
                  <p class='MsoNormal' style='line-height:14.25pt'><span style='font-size:10.0pt;font-family:&quot;Arial&quot;,&quot;sans-serif&quot;;color:#606060;letter-spacing:.4pt'>Thank you<br /><b>Volcom ERP</b><u></u><u></u></span></p>

                  </div>
                  </td>
                 </tr>
                </tbody>
              </table>
              <!-- end body -->


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
            </tbody>
        </table>"

            mail.Subject = "Update Actual In Store Date"
            mail.IsBodyHtml = True
            mail.Body = body_temp
            client.Send(mail)
        ElseIf report_mark_type = "225" Then
            'EMAIL INVOICE PENJUALAN
            Dim comp_name As String = execute_query("SELECT c.comp_name FROM tb_m_comp c WHERE c.id_comp=1", 0, True, "", "", "", "")
            Dim mail_address_from As String = execute_query("SELECT m.mail_address FROM tb_mail_manage_member m WHERE m.id_mail_manage=" + id_report + " AND m.id_mail_member_type=1 ORDER BY m.id_mail_manage_member ASC LIMIT 1", 0, True, "", "", "", "")

            Dim from_mail As MailAddress = New MailAddress(mail_address_from, head)
            Dim mail As MailMessage = New MailMessage()
            mail.From = from_mail


            'Send to => design_code : email; design : contact person;
            Dim query_send_to As String = "SELECT  m.id_mail_member_type,m.mail_address, IF(ISNULL(m.id_comp_contact), e.employee_name, cc.contact_person) AS `display_name`
            FROM tb_mail_manage_member m 
            LEFT JOIN tb_m_comp_contact cc ON cc.id_comp_contact = m.id_comp_contact
            LEFT JOIN tb_m_user u ON u.id_user = m.id_user
            LEFT JOIN tb_m_employee e ON e.id_employee = u.id_employee
            WHERE m.id_mail_manage=" + id_report + " AND m.id_mail_member_type>1 
            ORDER BY m.id_mail_member_type ASC,m.id_mail_manage_member ASC "
            Dim data_send_to As DataTable = execute_query(query_send_to, -1, True, "", "", "", "")
            For i As Integer = 0 To data_send_to.Rows.Count - 1
                Dim to_mail As MailAddress = New MailAddress(data_send_to.Rows(i)("mail_address").ToString, data_send_to.Rows(i)("display_name").ToString)
                If data_send_to.Rows(i)("id_mail_member_type").ToString = "2" Then
                    mail.To.Add(to_mail)
                ElseIf data_send_to.Rows(i)("id_mail_member_type").ToString = "3" Then
                    mail.CC.Add(to_mail)
                End If
            Next
            'include email management
            Dim management_mail As String = getMailManagement(report_mark_type)
            If management_mail <> "" Then
                mail.CC.Add(management_mail)
            End If

            '-- start attachment 
            'Create a New report. 
            Dim list As List(Of DevExpress.XtraPrinting.Page) = New List(Of DevExpress.XtraPrinting.Page)
            Dim rpt As New ReportSalesInvoiceNew()
            Dim query As String = "SELECT * FROM tb_mail_manage_det md WHERE md.id_mail_manage='" + id_report + "' "
            Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
            For i As Integer = 0 To data.Rows.Count - 1
                ReportSalesInvoiceNew.id_sales_pos = data.Rows(i)("id_report").ToString
                ReportSalesInvoiceNew.id_report_status = "6"
                ReportSalesInvoiceNew.rmt = data.Rows(i)("report_mark_type").ToString
                Dim Report As New ReportSalesInvoiceNew()
                Report.LabelTitle.Text = "INVOICE SLIP"
                Report.PrintingSystem.ContinuousPageNumbering = False
                Report.CreateDocument()

                For j = 0 To Report.Pages.Count - 1
                    list.Add(Report.Pages(j))
                Next
            Next
            rpt.Pages.AddRange(list)

            ' Create a new memory stream and export the report into it as PDF.
            Dim Mem As New MemoryStream()
            'Dim unik_file As String = execute_query("SELECT UNIX_TIMESTAMP(NOW())", 0, True, "", "", "", "")
            rpt.ExportToPdf(Mem)
            ' Create a new attachment and put the PDF report into it.
            Mem.Seek(0, System.IO.SeekOrigin.Begin)
            Dim Att = New Attachment(Mem, "sal_inv_" & report_mark_type & "_" & id_report & ".pdf", "application/pdf")
            mail.Attachments.Add(Att)
            '-- end attachment


            Dim body_temp As String = email_body_invoice_penjualan(dt, titl.ToUpper, par1, par2, comment, design_code)
            Dim subject_mail As String = execute_query("SELECT m.mail_subject FROM tb_mail_manage m WHERE m.id_mail_manage=" + id_report + "", 0, True, "", "", "", "")
            mail.Subject = subject_mail
            mail.IsBodyHtml = True
            mail.Body = body_temp
            client.Send(mail)
        ElseIf report_mark_type = "226" Or report_mark_type = "227" Then
            'EMAIL pemberitahuan/peringatan
            Dim mail_address_from As String = execute_query("SELECT m.mail_address FROM tb_mail_manage_member m WHERE m.id_mail_manage=" + id_report + " AND m.id_mail_member_type=1 ORDER BY m.id_mail_manage_member ASC LIMIT 1", 0, True, "", "", "", "")

            Dim from_mail As MailAddress = New MailAddress(mail_address_from, head)
            Dim mail As MailMessage = New MailMessage()
            mail.From = from_mail


            'Send to => design_code : email; design : contact person;
            Dim query_send_to As String = "SELECT  m.id_mail_member_type,m.mail_address, IF(ISNULL(m.id_comp_contact), e.employee_name, cc.contact_person) AS `display_name`
            FROM tb_mail_manage_member m 
            LEFT JOIN tb_m_comp_contact cc ON cc.id_comp_contact = m.id_comp_contact
            LEFT JOIN tb_m_user u ON u.id_user = m.id_user
            LEFT JOIN tb_m_employee e ON e.id_employee = u.id_employee
            WHERE m.id_mail_manage=" + id_report + " AND m.id_mail_member_type>1 
            ORDER BY m.id_mail_member_type ASC,m.id_mail_manage_member ASC "
            Dim data_send_to As DataTable = execute_query(query_send_to, -1, True, "", "", "", "")
            For i As Integer = 0 To data_send_to.Rows.Count - 1
                Dim to_mail As MailAddress = New MailAddress(data_send_to.Rows(i)("mail_address").ToString, data_send_to.Rows(i)("display_name").ToString)
                If data_send_to.Rows(i)("id_mail_member_type").ToString = "2" Then
                    mail.To.Add(to_mail)
                ElseIf data_send_to.Rows(i)("id_mail_member_type").ToString = "3" Then
                    mail.CC.Add(to_mail)
                End If
            Next
            'include email management
            Dim management_mail As String = getMailManagement(report_mark_type)
            If management_mail <> "" Then
                mail.CC.Add(management_mail)
            End If

            '-- start attachment 
            '-- sementara nonaktif
            'Create a New report. 
            'Dim id_sales_pos As String = ""
            'For i As Integer = 0 To (dt.Rows.Count - 1)
            '    If i > 0 Then
            '        id_sales_pos += ","
            '    End If
            '    id_sales_pos += dt.Rows(i)("id_report").ToString
            'Next
            'ReportSummaryInvoice.id = id_sales_pos
            'Dim rpt As New ReportSummaryInvoice()

            '' Create a new memory stream and export the report into it as PDF.
            'Dim Mem As New MemoryStream()
            ''Dim unik_file As String = execute_query("SELECT UNIX_TIMESTAMP(NOW())", 0, True, "", "", "", "")
            'rpt.ExportToXlsx(Mem)
            '' Create a new attachment and put the PDF report into it.
            'Mem.Seek(0, System.IO.SeekOrigin.Begin)
            'Dim Att = New Attachment(Mem, "list_inv" & report_mark_type & "_" & id_report & ".xlsx", "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet")
            'mail.Attachments.Add(Att)
            '-- end attachment

            Dim body_temp As String = email_body_invoice_jatuh_tempo(dt, titl.ToUpper, par1, par2, comment, design_code)
            mail.Subject = subj
            mail.IsBodyHtml = True
            mail.Body = body_temp
            client.Send(mail)
        ElseIf report_mark_type = "228" Then
            'send email
            Dim mail_address_from As String = execute_query("SELECT m.mail_address FROM tb_mail_manage_member m WHERE m.id_mail_manage=" + id_report + " AND m.id_mail_member_type=1 ORDER BY m.id_mail_manage_member ASC LIMIT 1", 0, True, "", "", "", "")
            Dim from_mail As MailAddress = New MailAddress(mail_address_from, design_code)
            Dim mail As MailMessage = New MailMessage()
            mail.From = from_mail
            Dim query_send_to As String = "SELECT  m.id_mail_member_type,m.mail_address, IF(ISNULL(m.id_comp_contact), e.employee_name, cc.contact_person) AS `display_name`
                    FROM tb_mail_manage_member m 
                    LEFT JOIN tb_m_comp_contact cc ON cc.id_comp_contact = m.id_comp_contact
                    LEFT JOIN tb_m_user u ON u.id_user = m.id_user
                    LEFT JOIN tb_m_employee e ON e.id_employee = u.id_employee
                    WHERE m.id_mail_manage=" + id_report + " AND m.id_mail_member_type>1 
                    ORDER BY m.id_mail_member_type ASC,m.id_mail_manage_member ASC "
            Dim data_send_to As DataTable = execute_query(query_send_to, -1, True, "", "", "", "")
            For i As Integer = 0 To data_send_to.Rows.Count - 1
                Dim to_mail As MailAddress = New MailAddress(data_send_to.Rows(i)("mail_address").ToString, data_send_to.Rows(i)("display_name").ToString)
                If data_send_to.Rows(i)("id_mail_member_type").ToString = "2" Then
                    mail.To.Add(to_mail)
                ElseIf data_send_to.Rows(i)("id_mail_member_type").ToString = "3" Then
                    mail.CC.Add(to_mail)
                End If
            Next
            'include email management
            Dim management_mail As String = getMailManagement(report_mark_type)
            If management_mail <> "" Then
                mail.CC.Add(management_mail)
            End If

            mail.Subject = design
            mail.IsBodyHtml = True
            mail.Body = emailOnHold(comment_by, comment, dt)
            client.Send(mail)
        ElseIf report_mark_type = "230" Then
            Dim mail_address_from As String = execute_query("SELECT m.mail_address FROM tb_mail_manage_member m WHERE m.id_mail_manage=" + id_report + " AND m.id_mail_member_type=1 ORDER BY m.id_mail_manage_member ASC LIMIT 1", 0, True, "", "", "", "")
            Dim from_mail As MailAddress = New MailAddress(mail_address_from, design_code)
            Dim mail As MailMessage = New MailMessage()
            mail.From = from_mail
            Dim query_send_to As String = "SELECT  m.id_mail_member_type,m.mail_address, IF(ISNULL(m.id_comp_contact), e.employee_name, cc.contact_person) AS `display_name`
                    FROM tb_mail_manage_member m 
                    LEFT JOIN tb_m_comp_contact cc ON cc.id_comp_contact = m.id_comp_contact
                    LEFT JOIN tb_m_user u ON u.id_user = m.id_user
                    LEFT JOIN tb_m_employee e ON e.id_employee = u.id_employee
                    WHERE m.id_mail_manage=" + id_report + " AND m.id_mail_member_type>1 
                    ORDER BY m.id_mail_member_type ASC,m.id_mail_manage_member ASC "
            Dim data_send_to As DataTable = execute_query(query_send_to, -1, True, "", "", "", "")
            For i As Integer = 0 To data_send_to.Rows.Count - 1
                Dim to_mail As MailAddress = New MailAddress(data_send_to.Rows(i)("mail_address").ToString, data_send_to.Rows(i)("display_name").ToString)
                If data_send_to.Rows(i)("id_mail_member_type").ToString = "2" Then
                    mail.To.Add(to_mail)
                ElseIf data_send_to.Rows(i)("id_mail_member_type").ToString = "3" Then
                    mail.CC.Add(to_mail)
                End If
            Next
            'include email management
            Dim management_mail As String = getMailManagement(report_mark_type)
            If management_mail <> "" Then
                mail.CC.Add(management_mail)
            End If

            mail.Subject = design
            mail.IsBodyHtml = True
            mail.Body = emailReleaseDel(comment_by, comment, dt)
            client.Send(mail)
        End If
    End Sub

    Sub send_mail_complete(ByVal report_mark_type As String, ByVal id_report As String, ByVal report_number As String)
        Dim query As String = "SELECT emp.`employee_name`,emp.`email_external`,rmt.`report_mark_type_name`
FROM tb_report_mark rm
INNER JOIN tb_m_employee emp ON emp.`id_employee`=rm.`id_employee`
INNER JOIN tb_lookup_report_mark_type rmt ON rmt.`report_mark_type`=rm.`report_mark_type`
WHERE rm.id_report='" & id_report & "' AND rm.report_mark_type='" & report_mark_type & "' AND rm.id_report_status='1' LIMIT 1"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")

        If data.Rows.Count > 0 Then
            Dim is_ssl = get_setup_field("system_email_is_ssl").ToString
            Dim client As SmtpClient = New SmtpClient()
            If is_ssl = "1" Then
                client.Port = get_setup_field("system_email_ssl_port").ToString
                client.DeliveryMethod = SmtpDeliveryMethod.Network
                client.UseDefaultCredentials = False
                client.Host = get_setup_field("system_email_ssl_server").ToString
                client.EnableSsl = True
                client.Credentials = New System.Net.NetworkCredential(get_setup_field("system_email_ssl").ToString, get_setup_field("system_email_ssl_pass").ToString)
            Else
                client.Port = get_setup_field("system_email_port").ToString
                client.DeliveryMethod = SmtpDeliveryMethod.Network
                client.UseDefaultCredentials = False
                client.Host = get_setup_field("system_email_server").ToString
                client.Credentials = New System.Net.NetworkCredential(get_setup_field("system_email").ToString, get_setup_field("system_email_pass").ToString)
            End If

            Dim report_type As String = data.Rows(0)("report_mark_type_name").ToString
            Dim dear_to As String = data.Rows(0)("employee_name").ToString
            Dim dear_to_mail As String = data.Rows(0)("email_external").ToString

            'to list : dep head 
            Dim to_mail As MailAddress = New MailAddress(dear_to_mail, dear_to)
            Dim from_mail As MailAddress = New MailAddress(get_setup_field("system_email_ssl").ToString, get_setup_field("app_name").ToString)
            Dim mail As MailMessage = New MailMessage(from_mail, to_mail)

            mail.Subject = report_type & " (" & report_number & ") Completed"

            mail.IsBodyHtml = True
            mail.Body = email_complete_body(report_type, report_number, dear_to)
            client.Send(mail)
        End If
    End Sub

    Sub send_email_appr(ByVal report_mark_type As String, ByVal id_leave As String, ByVal is_appr As Boolean)
        Dim is_ssl = get_setup_field("system_email_is_ssl").ToString
        Dim client As SmtpClient = New SmtpClient()
        If is_ssl = "1" Then
            client.Port = get_setup_field("system_email_ssl_port").ToString
            client.DeliveryMethod = SmtpDeliveryMethod.Network
            client.UseDefaultCredentials = False
            client.Host = get_setup_field("system_email_ssl_server").ToString
            client.EnableSsl = True
            client.Credentials = New System.Net.NetworkCredential(get_setup_field("system_email_ssl").ToString, get_setup_field("system_email_ssl_pass").ToString)
        Else
            client.Port = get_setup_field("system_email_port").ToString
            client.DeliveryMethod = SmtpDeliveryMethod.Network
            client.UseDefaultCredentials = False
            client.Host = get_setup_field("system_email_server").ToString
            client.Credentials = New System.Net.NetworkCredential(get_setup_field("system_email").ToString, get_setup_field("system_email_pass").ToString)
        End If
        '
        Dim query As String = ""
        query = "SELECT empl.*,lt.leave_type,empl.leave_purpose,
                empx.email_external AS dept_head_email,empx.id_employee AS id_dep_head,empx.employee_name AS dep_head,
                empa.email_external AS asst_dept_head_email,empa.id_employee AS id_asst_dep_head,empa.employee_name AS asst_dep_head,
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
        Dim from_mail As MailAddress = New MailAddress(get_setup_field("system_email_ssl").ToString, get_setup_field("app_name").ToString)
        Dim mail As MailMessage = New MailMessage(from_mail, to_mail)
        'add cc asst dept head
        If Not data.Rows(0)("asst_dept_head_email").ToString = "" Then
            Dim cc_asst_dept As MailAddress = New MailAddress(data.Rows(0)("asst_dept_head_email").ToString, data.Rows(0)("asst_dep_head").ToString)
            mail.CC.Add(cc_asst_dept)
        End If
        'add cc list : yg ada di mark semua
        Dim querycc As String = "SELECT emp.email_external,emp.employee_name,rm.* FROM tb_report_mark rm 
                                    INNER JOIN tb_m_user usr ON usr.id_user=rm.id_user
                                    INNER JOIN tb_m_employee emp ON emp.id_employee=usr.id_employee
                                    WHERE report_mark_type='" & report_mark_type & "' AND id_report='" & id_leave & "' AND id_report_status='3'"
        Dim datacc As DataTable = execute_query(querycc, -1, True, "", "", "", "")
        If datacc.Rows.Count > 0 Then
            For i As Integer = 0 To datacc.Rows.Count - 1
                Dim cc As MailAddress = New MailAddress(datacc.Rows(i)("email_external").ToString, datacc.Rows(i)("employee_name").ToString)
                mail.CC.Add(cc)
            Next
        End If
        'Dim to_mail As MailAddress = New MailAddress("septian@volcom.mail", "Septian Primadewa")
        'Dim from_mail As MailAddress = New MailAddress("system@volcom.co.id", "Volcom ERP")
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
        query = "SELECT empl.*,lt.leave_type,empl.leave_purpose,empx.email_external as dept_head_email,empx.id_employee as id_dep_head,empx.employee_name as dep_head,empld.min_date,empld.max_date,status.report_status,emp.employee_name,emp.employee_code,empld.hours_total,empl.report_mark_type 
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

    Function email_complete_body(ByVal report_type As String, ByVal report_number As String, ByVal dear_to As String)
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
                          <p class='MsoNormal' style='line-height:14.25pt'><b><span style='font-family:&quot;Arial&quot;,&quot;sans-serif&quot;;color:#606060'>Dear " & dear_to & ",</span></b><span style='font-size:10.0pt;font-family:&quot;Arial&quot;,&quot;sans-serif&quot;;color:#606060;letter-spacing:.4pt'><u></u><u></u></span></p>
                          </div>
                          </td>
                         </tr>
                         <tr>
                          <td style='padding:15.0pt 15.0pt 8.0pt 15.0pt' colspan='3'>
                          <div>
                          <p class='MsoNormal' style='line-height:14.25pt'><span style='font-size:10.0pt;font-family:&quot;Arial&quot;,&quot;sans-serif&quot;;color:#606060;letter-spacing:.4pt'>Approval <b>" & report_type & "</b> with number <b>" & report_number & "</b>, has been completed. </span></b><span style='font-size:10.0pt;font-family:&quot;Arial&quot;,&quot;sans-serif&quot;;color:#606060;letter-spacing:.4pt'><u></u><u></u></span>
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

    Function email_body_comment(ByVal season As String, ByVal design_name As String, ByVal design_code As String, ByVal comment_by As String, ByVal date_string As String, ByVal comment As String)
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
                            <span style='font-size:10.0pt;font-family:&quot;Arial&quot;,&quot;sans-serif&quot;;color:#606060;letter-spacing:.4pt'>Design Code
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
                            <span style='font-size:10.0pt;font-family:&quot;Arial&quot;,&quot;sans-serif&quot;;color:#606060;letter-spacing:.4pt'>" & design_code & "
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
                          <td style='padding:1.0pt 10.0pt 1.0pt 10.0pt'>
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
                          <td style='padding:1.0pt 10.0pt 1.0pt 10.0pt'>
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

    Function email_body_final_cop(ByVal cop As String, ByVal design_name As String, ByVal design_code As String, ByVal opt As String)
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
      <p class='MsoNormal' style='line-height:14.25pt'><span style='font-size:10.0pt;font-family:&quot;Arial&quot;,&quot;sans-serif&quot;;color:#606060;letter-spacing:.4pt'>Article with detail below, </span></b><span style='font-size:10.0pt;font-family:&quot;Arial&quot;,&quot;sans-serif&quot;;color:#606060;letter-spacing:.4pt'><u></u><u></u></span>
      </div>
      </td>
     </tr>
     <tr>
      <td style='padding:1.0pt 1.0pt 1.0pt 15.0pt'>
        <span style='font-size:10.0pt;font-family:&quot;Arial&quot;,&quot;sans-serif&quot;;color:#606060;letter-spacing:.4pt'>Code
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
        <span style='font-size:10.0pt;font-family:&quot;Arial&quot;,&quot;sans-serif&quot;;color:#606060;letter-spacing:.4pt'>" & design_code & "
        </span>
      </p>
      </div>
      </td>
     </tr>
     <tr>
      <td style='padding:1.0pt 1.0pt 1.0pt 15.0pt'>
        <span style='font-size:10.0pt;font-family:&quot;Arial&quot;,&quot;sans-serif&quot;;color:#606060;letter-spacing:.4pt'>Description
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
        <span style='font-size:10.0pt;font-family:&quot;Arial&quot;,&quot;sans-serif&quot;;color:#606060;letter-spacing:.4pt'>"

        If opt = "1" Then
            body_temp += "Final COP"
        Else
            body_temp += "Pre Final COP"
        End If

        body_temp += "
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
      <td style='padding:1.0pt 10.0pt 1.0pt 10.0pt'>
      <div>
      <p class='MsoNormal' style='line-height:14.25pt'>
        <span style='font-size:10.0pt;font-family:&quot;Arial&quot;,&quot;sans-serif&quot;;color:#606060;letter-spacing:.4pt'>" & cop & "
        </span>
      </p>
      </div>
      </td>
     </tr>
     <tr>
      <td style='padding:15.0pt 15.0pt 8.0pt 15.0pt' colspan='3'>
      <div>
      <p class='MsoNormal' style='line-height:14.25pt'><span style='font-size:10.0pt;font-family:&quot;Arial&quot;,&quot;sans-serif&quot;;color:#606060;letter-spacing:.4pt'>Has been approved. </span></b><span style='font-size:10.0pt;font-family:&quot;Arial&quot;,&quot;sans-serif&quot;;color:#606060;letter-spacing:.4pt'><u></u><u></u></span>
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
    '
    Sub send_email_notif(ByVal rmt As String, ByVal id_report As String)
        Dim is_ssl = get_setup_field("system_email_is_ssl").ToString
        Dim client As SmtpClient = New SmtpClient()
        If is_ssl = "1" Then
            client.Port = get_setup_field("system_email_ssl_port").ToString
            client.DeliveryMethod = SmtpDeliveryMethod.Network
            client.UseDefaultCredentials = False
            client.Host = get_setup_field("system_email_ssl_server").ToString
            client.EnableSsl = True
            client.Credentials = New System.Net.NetworkCredential(get_setup_field("system_email_ssl").ToString, get_setup_field("system_email_ssl_pass").ToString)
        Else
            client.Port = get_setup_field("system_email_port").ToString
            client.DeliveryMethod = SmtpDeliveryMethod.Network
            client.UseDefaultCredentials = False
            client.Host = get_setup_field("system_email_server").ToString
            client.Credentials = New System.Net.NetworkCredential(get_setup_field("system_email").ToString, get_setup_field("system_email_pass").ToString)
        End If

        'caption
        Dim mail_subject As String = ""

        If rmt = "9" Or rmt = "80" Or rmt = "81" Or rmt = "206" Then
            mail_subject = "PD Created"
        End If

        Dim from_mail As MailAddress = New MailAddress("system@volcom.co.id", "Volcom ERP")
        Dim mail As MailMessage = New MailMessage()
        mail.From = from_mail

        'Send to
        Dim query_send_mail As String = "SELECT emp.`email_external`,emp.`employee_name` 
FROM `tb_mail_to` mt
INNER JOIN tb_m_user usr ON usr.`id_user`=mt.id_user
INNER JOIN tb_m_employee emp ON emp.`id_employee`=usr.`id_employee`
WHERE is_to='1' AND emp.`email_external`!='' AND report_mark_type='" & rmt & "'"
        Dim data_send_mail As DataTable = execute_query(query_send_mail, -1, True, "", "", "", "")
        For i As Integer = 0 To data_send_mail.Rows.Count - 1
            Dim to_mail As MailAddress = New MailAddress(data_send_mail.Rows(i)("email_external").ToString, data_send_mail.Rows(i)("employee_name").ToString)
            mail.To.Add(to_mail)
        Next
        'cc list
        Dim querycc As String = "SELECT emp.`email_external`,emp.`employee_name` 
FROM `tb_mail_to` mt
INNER JOIN tb_m_user usr ON usr.`id_user`=mt.id_user
INNER JOIN tb_m_employee emp ON emp.`id_employee`=usr.`id_employee`
WHERE is_to='2' AND emp.`email_external`!='' AND report_mark_type='" & rmt & "'"
        Dim datacc As DataTable = execute_query(querycc, -1, True, "", "", "", "")
        If datacc.Rows.Count > 0 Then
            For i As Integer = 0 To datacc.Rows.Count - 1
                Dim cc As MailAddress = New MailAddress(datacc.Rows(i)("email_external").ToString, datacc.Rows(i)("employee_name").ToString)
                mail.CC.Add(cc)
            Next
        End If

        mail.Subject = mail_subject

        mail.IsBodyHtml = True
        mail.Body = email_body_notif(rmt, id_report)
        client.Send(mail)
    End Sub
    Function email_body_notif(ByVal rmt As String, ByVal id_report As String)
        Dim body_temp As String = ""
        Dim content As String = ""
        Dim number As String = ""
        Dim report_type As String = ""

        Dim q_type As String = "SELECT * FROM tb_lookup_report_mark_type WHERE report_mark_type='" & rmt & "'"
        Dim d_type As DataTable = execute_query(q_type, -1, True, "", "", "", "")

        If d_type.Rows.Count > 0 Then
            report_type = d_type.Rows(0)("report_mark_type_name").ToString
        End If

        If rmt = "9" Or rmt = "80" Or rmt = "81" Or rmt = "206" Then
            Dim query As String = "SELECT pd.prod_demand_number,pdd.`id_prod_demand_design`,dsg.`design_code`,dsg.`design_display_name`,ROUND(SUM(pdp.`prod_demand_product_qty`)) AS qty FROM `tb_prod_demand_product` pdp
INNER JOIN tb_prod_demand_design pdd ON pdd.`id_prod_demand_design`=pdp.`id_prod_demand_design` AND pdd.`is_void`='2'
INNER JOIN tb_prod_demand pd ON pd.id_prod_demand = pdd.id_prod_demand
INNER JOIN tb_m_design dsg ON dsg.`id_design`=pdd.`id_design`
WHERE pdd.id_prod_demand='" & id_report & "'
GROUP BY pdp.`id_prod_demand_design`"
            Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
            If data.Rows.Count > 0 Then
                'content
                content += "<tr>
									<td style='padding:15.0pt 15.0pt 8.0pt 15.0pt' colspan='3'>
										<div>
											<table class='content' style='padding:1.0pt 1.0pt 1.0pt 10.0pt;border-collapse: collapse'>
												<tr>
													<td>
														Code
													</td>
													<td>
														Design
													</td>
													<td style='text-align: center;'>
														Total Qty
													</td>
												</tr>"
                For i As Integer = 0 To data.Rows.Count - 1
                    content += "<tr>
										<td>
											" & data.Rows(i)("design_code").ToString & "
										</td>
										<td>
											" & data.Rows(i)("design_display_name").ToString & "
										</td>
										<td style='text-align: center;'>
											" & data.Rows(i)("qty").ToString & "
										</td>
									</tr>"
                Next
                content += "</table>
										</div>
									</td>
								</tr>"
                'number
                number = data.Rows(0)("prod_demand_number").ToString
            End If
        End If

        body_temp = "
<style type='text/css'>
	.content td{
		padding:1.0pt 5.0pt 1.0pt 5.0pt;border: 1PX solid;
        font-size:10.0pt;
        font-family:&quot;Arial&quot;,&quot;sans-serif&quot;;
        color:#606060;
        letter-spacing:.4pt;
	}
</style>
<table class='m_1811720018273078822MsoNormalTable' border='0' cellspacing='0' cellpadding='0' width='100%' style='width:100.0%;background:#eeeeee'>
<tbody>
	<tr>
		<td style='padding:30.0pt 30.0pt 30.0pt 30.0pt'>
			<div align='center'>

				<table class='m_1811720018273078822MsoNormalTable' border='0' cellspacing='0' cellpadding='0' width='600' style='width:6.25in;background:white'>
				<tbody>
					<tr>
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
							<tbody>
								<tr>
									<td style='padding:0in 0in 0in 0in'>

									</td>
								</tr>
							</tbody>
							</table>
							<p class='MsoNormal' style='background-color:#eff0f1'><span style='display:block;background-color:#eff0f1;height: 5px;'><u></u>&nbsp;<u></u></span></p>
							<p class='MsoNormal'><span style='display:none'><u></u>&nbsp;<u></u></span></p>
							<table class='m_1811720018273078822MsoNormalTable' border='0' cellspacing='0' cellpadding='0' style='background:white'>
							<tbody>
								<tr>
									<td style='padding:15.0pt 15.0pt 15.0pt 15.0pt' colspan='3'>
										<div>
											<p class='MsoNormal' style='line-height:14.25pt'><b><span style='font-family:&quot;Arial&quot;,&quot;sans-serif&quot;;color:#606060'>Dear Team,</span></b><span style='font-size:10.0pt;font-family:&quot;Arial&quot;,&quot;sans-serif&quot;;color:#606060;letter-spacing:.4pt'><u></u><u></u></span></p>
										</div>
									</td>
								</tr>
								<tr>
									<td style='padding:15.0pt 15.0pt 8.0pt 15.0pt' colspan='3'>
										<div>
											<p class='MsoNormal' style='line-height:14.25pt'><span style='font-size:10.0pt;font-family:&quot;Arial&quot;,&quot;sans-serif&quot;;color:#606060;letter-spacing:.4pt'>
                                            " & report_type & " (" & number & ") with detail below : 
                                            </span></b><span style='font-size:10.0pt;font-family:&quot;Arial&quot;,&quot;sans-serif&quot;;color:#606060;letter-spacing:.4pt'><u></u><u></u></span>
										</div>
									</td>
								</tr>"

        'insert content
        body_temp += content

        body_temp += "<tr>
									<td style='padding:15.0pt 15.0pt 8.0pt 15.0pt' colspan='3'>
										<div>
											<p class='MsoNormal' style='line-height:14.25pt'><span style='font-size:10.0pt;font-family:&quot;Arial&quot;,&quot;sans-serif&quot;;color:#606060;letter-spacing:.4pt'>Has been approved. Please check on your system. </span></b><span style='font-size:10.0pt;font-family:&quot;Arial&quot;,&quot;sans-serif&quot;;color:#606060;letter-spacing:.4pt'><u></u><u></u></span>
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
							</tbody>
							</table>
							<p class='MsoNormal' style='background-color:#eff0f1'><span style='display:block;height: 10px;'><u></u>&nbsp;<u></u></span></p>
							<p class='MsoNormal'><span style='display:none'><u></u>&nbsp;<u></u></span></p>
							<div align='center'>
								<table class='m_1811720018273078822MsoNormalTable' border='0' cellspacing='0' cellpadding='0' style='background:white'>
								<tbody>
									<tr>
										<td style='padding:6.0pt 6.0pt 6.0pt 6.0pt;text-align:center;'>
											<span style='text-align:center;font-size:7.0pt;font-family:&quot;Arial&quot;,&quot;sans-serif&quot;;color:#a0a0a0;letter-spacing:.4pt;'>This email send directly from system. Do not reply.</b><u></u><u></u></span>
											<p class='MsoNormal' align='center' style='margin-bottom:12.0pt;text-align:center;padding-top:0px;'><img border='0' width='300' id='m_1811720018273078822_x0000_i1028' src='https://ci6.googleusercontent.com/proxy/xq6o45mp_D9Z7DHCK5WT7GKuQ2QDaLg1hyMxoHX5ofUIv_m7GwasoczpbAOn6l6Ze-UfLuIUAndSokPvO633nnO9=s0-d-e1-ft#http://www.volcom.co.id/enews/img/footer.jpg' class='CToWUd'><u></u><u></u></p>
										</td>
									</tr>
								</tbody>
								</table>
							</div>
						</td>
					</tr>
				</tbody>
				</table>
			</div>
		</td>
	</tr>
</tbody>
</table>"
        Return body_temp
    End Function

    Function email_body_invoice_penjualan(ByVal dtp As DataTable, ByVal titlep As String, ByVal content_head As String, ByVal content As String, ByVal content_end As String, ByVal tot_amountp As String)
        Dim body_temp As String = "<table class='m_1811720018273078822MsoNormalTable' border='0' cellspacing='0' cellpadding='0' width='100%' style='width:100.0%;background:#eeeeee'>
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
                

                <!-- start body -->
                <table width='100%' class='m_1811720018273078822MsoNormalTable' border='0' cellspacing='0' cellpadding='0' style='background:white'>
                 <tbody>
                 <tr>
                  <td style='padding:15.0pt 15.0pt 0pt 15.0pt' colspan='3'>
                  <div>
                    <b><span class='MsoNormal' style='line-height:14.25pt;font-family:&quot;Arial&quot;,&quot;sans-serif&quot;;color:#606060'>" + titlep + "</span></b>
                  </div>
                  </td>
                 </tr>

                 <tr>
                 	<td style='padding:15.0pt 15.0pt 5.0pt 15.0pt' colspan='3'>
                 		<p style='font-size:10.0pt; font-family:&quot;Arial&quot;,&quot;sans-serif&quot;;color:#606060; border-spacing:0 7px;'>" + content_head + "</p>
                 		<p style='margin-bottom:5pt; line-height:20.25pt; font-size:10.0pt; font-family:&quot;Arial&quot;,&quot;sans-serif&quot;;color:#606060; border-spacing:0 7px;'>" + content + "</p>
	                  	
	                 </td>
                 </tr>

               
         
                 <tr>
                  <td style='padding:1.0pt 15.0pt 15.0pt 15.0pt' colspan='3'>
                    <table width='100%' class='m_1811720018273078822MsoNormalTable' border='1' cellspacing='0' cellpadding='5' style='background:white; font-size: 12px; font-family:&quot;Arial&quot;,&quot;sans-serif&quot;;color:#606060'>
                    <tr>
                      <th>No</th>
                      <th>Store</th>
                      <th>No Invoice</th>
                      <th>Periode Penjualan</th>
                      <th>Jatuh Tempo</th>
                      <th>Nominal</th>
                    </tr> "

        For i As Integer = 0 To dtp.Rows.Count - 1
            body_temp += "<tr>
                <td>" + (i + 1).ToString + "</td>
                <td>" + dtp.Rows(i)("store").ToString + "</td>
                <td>" + dtp.Rows(i)("report_number").ToString + "</td>
                <td>" + dtp.Rows(i)("period").ToString + "</td>
                <td>" + dtp.Rows(i)("sales_pos_due_date").ToString + "</td>
                <td align='center'>" + Decimal.Parse(dtp.Rows(i)("amount").ToString).ToString("N2") + "</td>
            </tr>"
        Next

        body_temp += "<tr>
            <th colspan='5'>TOTAL</th>
            <th>" + tot_amountp + "</th>
        </tr> "

        body_temp += "</table>
                  </td>

                 </tr>

                 <tr>
                 	<td style='padding:5.0pt 15.0pt 5.0pt 15.0pt' colspan='3'>
                 		<p style='line-height:20.25pt;font-size:10.0pt; font-family:&quot;Arial&quot;,&quot;sans-serif&quot;;color:#606060; border-spacing:0 7px;'>" + content_end + "</p>
	                 </td>
                 </tr>

         
          <tr>
                  <td style='padding:15.0pt 15.0pt 15.0pt 15.0pt' colspan='3'>
                  <div>
                  <p class='MsoNormal' style='line-height:14.25pt'><span style='font-size:10.0pt;font-family:&quot;Arial&quot;,&quot;sans-serif&quot;;color:#606060;letter-spacing:.4pt'><b>Volcom ERP</b><u></u><u></u></span></p>

                  </div>
                  </td>
                 </tr>
                </tbody>
              </table>
              <!-- end body -->


                <p class='MsoNormal' style='background-color:#eff0f1'><span style='display:block;height: 10px;'><u></u>&nbsp;<u></u></span></p>
                <p class='MsoNormal'><span style='display:none'><u></u>&nbsp;<u></u></span></p>
                <div align='center'>
                <table class='m_1811720018273078822MsoNormalTable' border='0' cellspacing='0' cellpadding='0' style='background:white'>
                 <tbody><tr>
                  <td style='padding:6.0pt 6.0pt 6.0pt 6.0pt;text-align:center;'>
                    <span style='text-align:center;font-size:7.0pt;font-family:&quot;Arial&quot;,&quot;sans-serif&quot;;color:#a0a0a0;letter-spacing:.4pt;'></b><u></u><u></u></span>
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
            </tbody>
        </table>"
        Return body_temp
    End Function

    Function email_body_invoice_jatuh_tempo(ByVal dtp As DataTable, ByVal titlep As String, ByVal content_head As String, ByVal content As String, ByVal content_end As String, ByVal tot_amountp As String)
        Dim body_temp As String = "<table class='m_1811720018273078822MsoNormalTable' border='0' cellspacing='0' cellpadding='0' width='100%' style='width:100.0%;background:#eeeeee'>
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
                

                <!-- start body -->
                <table width='100%' class='m_1811720018273078822MsoNormalTable' border='0' cellspacing='0' cellpadding='0' style='background:white'>
                 <tbody>
                 <tr>
                  <td style='padding:15.0pt 15.0pt 0pt 15.0pt' colspan='3'>
                  <div>
                    <b><span class='MsoNormal' style='line-height:14.25pt;font-family:&quot;Arial&quot;,&quot;sans-serif&quot;;color:#606060'>" + titlep + "</span></b>
                  </div>
                  </td>
                 </tr>

                 <tr>
                 	<td style='padding:15.0pt 15.0pt 5.0pt 15.0pt' colspan='3'>
                 		<p style='font-size:10.0pt; font-family:&quot;Arial&quot;,&quot;sans-serif&quot;;color:#606060; border-spacing:0 7px;'>" + content_head + "</p>
                 		<p style='margin-bottom:5pt; line-height:20.25pt; font-size:10.0pt; font-family:&quot;Arial&quot;,&quot;sans-serif&quot;;color:#606060; border-spacing:0 7px;'>" + content + "</p>
	                  	
	                 </td>
                 </tr>

               
         
                 <tr>
                  <td style='padding:1.0pt 15.0pt 15.0pt 15.0pt' colspan='3'>
                    <table width='100%' class='m_1811720018273078822MsoNormalTable' border='1' cellspacing='0' cellpadding='5' style='background:white; font-size: 12px; font-family:&quot;Arial&quot;,&quot;sans-serif&quot;;color:#606060'>
                    <tr>
                      <th>No</th>
                      <th>Store</th>
                      <th>No Invoice</th>
                      <th>Periode Penjualan</th>
                      <th>Jatuh Tempo</th>
                      <th>Nominal</th>
                    </tr> "

        For i As Integer = 0 To dtp.Rows.Count - 1
            body_temp += "<tr>
                <td>" + (i + 1).ToString + "</td>
                <td>" + dtp.Rows(i)("store").ToString + "</td>
                <td>" + dtp.Rows(i)("report_number").ToString + "</td>
                <td>" + dtp.Rows(i)("period").ToString + "</td>
                <td>" + dtp.Rows(i)("sales_pos_due_date").ToString + "</td>
                <td align='center'>" + Decimal.Parse(dtp.Rows(i)("amount").ToString).ToString("N2") + "</td>
            </tr>"
        Next

        body_temp += "<tr>
            <th colspan='5'>TOTAL</th>
            <th>" + tot_amountp + "</th>
        </tr> "

        body_temp += "</table>
                  </td>

                 </tr>

                 <tr>
                 	<td style='padding:5.0pt 15.0pt 5.0pt 15.0pt' colspan='3'>
                 		<p style='line-height:20.25pt;font-size:10.0pt; font-family:&quot;Arial&quot;,&quot;sans-serif&quot;;color:#606060; border-spacing:0 7px;'>" + content_end + "</p>
	                 </td>
                 </tr>

         
          <tr>
                  <td style='padding:15.0pt 15.0pt 15.0pt 15.0pt' colspan='3'>
                  <div>
                  <p class='MsoNormal' style='line-height:14.25pt'><span style='font-size:10.0pt;font-family:&quot;Arial&quot;,&quot;sans-serif&quot;;color:#606060;letter-spacing:.4pt'><b>Volcom ERP</b><u></u><u></u></span></p>

                  </div>
                  </td>
                 </tr>
                </tbody>
              </table>
              <!-- end body -->


                <p class='MsoNormal' style='background-color:#eff0f1'><span style='display:block;height: 10px;'><u></u>&nbsp;<u></u></span></p>
                <p class='MsoNormal'><span style='display:none'><u></u>&nbsp;<u></u></span></p>
                <div align='center'>
                <table class='m_1811720018273078822MsoNormalTable' border='0' cellspacing='0' cellpadding='0' style='background:white'>
                 <tbody><tr>
                  <td style='padding:6.0pt 6.0pt 6.0pt 6.0pt;text-align:center;'>
                    <span style='text-align:center;font-size:7.0pt;font-family:&quot;Arial&quot;,&quot;sans-serif&quot;;color:#a0a0a0;letter-spacing:.4pt;'></b><u></u><u></u></span>
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
            </tbody>
        </table>"
        Return body_temp
    End Function

    Function emailOnHold(ByVal to_par As String, ByVal content_par As String, ByVal dt_par As DataTable)
        Dim body_temp As String = "<table class='m_1811720018273078822MsoNormalTable' border='0' cellspacing='0' cellpadding='0' width='100%' style='width:100.0%;background:#eeeeee'>
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
                

                <!-- start body -->
                <table width='100%' class='m_1811720018273078822MsoNormalTable' border='0' cellspacing='0' cellpadding='0' style='background:white'>
                 <tbody>
                <tr>
                  <td style='padding:15.0pt 15.0pt 0.0pt 15.0pt' colspan='3'>
                  <div>
                    <b><span class='MsoNormal' style='line-height:14.25pt;font-family:&quot;Arial&quot;,&quot;sans-serif&quot;;color:#606060'>Hold Delivery - Nama Toko Sesuai List</span></b>
                  </div>
                  </td>
                 </tr>

                 <tr>
                  <td style='padding:15.0pt 15.0pt 15.0pt 15.0pt' colspan='3'>
                  <div style='margin-bottom: 5pt;'>
                    <span class='MsoNormal' style='line-height:15.25pt; font-size: 10pt;font-family:&quot;Arial&quot;,&quot;sans-serif&quot;;color:#606060'>Kepada : " + to_par + " </span>
                  </div>

                  <div>
                    <span class='MsoNormal' style='line-height:15.25pt; font-size: 10pt;font-family:&quot;Arial&quot;,&quot;sans-serif&quot;;color:#606060'>" + content_par + "</span>
                  </div>
                  </td>
                 </tr>
               
         
                 <tr>
                  <td style='padding:0.0pt 0.0pt 0.0pt 5.0pt' colspan='3'>
                  	<ol > "

        For i As Integer = 0 To dt_par.Rows.Count - 1
            'data
            body_temp += "<li class='MsoNormal' style='line-height:15.25pt; font-size: 10pt;font-family:&quot;Arial&quot;,&quot;sans-serif&quot;;color:#606060'>" + dt_par.Rows(i)("group_store").ToString + "</li>"
        Next
        body_temp += "</ol>
                    </td>
                 </tr> 

         
          <tr>
                  <td style='padding:15.0pt 15.0pt 15.0pt 15.0pt' colspan='3'>
                  <div>
                  <p class='MsoNormal' style='line-height:14.25pt'><span style='font-size:10.0pt;font-family:&quot;Arial&quot;,&quot;sans-serif&quot;;color:#606060;letter-spacing:.4pt'>Thank you<br /><b>Volcom ERP</b><u></u><u></u></span></p>

                  </div>
                  </td>
                 </tr>
                </tbody>
              </table>
              <!-- end body -->


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
            </tbody>
        </table> "
        Return body_temp
    End Function

    Function emailReleaseDel(ByVal to_par As String, ByVal content_par As String, ByVal dt_par As DataTable)
        Dim body_temp As String = "<table class='m_1811720018273078822MsoNormalTable' border='0' cellspacing='0' cellpadding='0' width='100%' style='width:100.0%;background:#eeeeee'>
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
                

                <!-- start body -->
                <table width='100%' class='m_1811720018273078822MsoNormalTable' border='0' cellspacing='0' cellpadding='0' style='background:white'>
                 <tbody>
                <tr>
                  <td style='padding:15.0pt 15.0pt 0.0pt 15.0pt' colspan='3'>
                  <div>
                    <b><span class='MsoNormal' style='line-height:14.25pt;font-family:&quot;Arial&quot;,&quot;sans-serif&quot;;color:#606060'>Release Delivery - Nama Toko Sesuai List</span></b>
                  </div>
                  </td>
                 </tr>

                 <tr>
                  <td style='padding:15.0pt 15.0pt 15.0pt 15.0pt' colspan='3'>
                  <div style='margin-bottom: 5pt;'>
                    <span class='MsoNormal' style='line-height:15.25pt; font-size: 10pt;font-family:&quot;Arial&quot;,&quot;sans-serif&quot;;color:#606060'>Kepada : " + to_par + " </span>
                  </div>

                  <div>
                    <span class='MsoNormal' style='line-height:15.25pt; font-size: 10pt;font-family:&quot;Arial&quot;,&quot;sans-serif&quot;;color:#606060'>" + content_par + "</span>
                  </div>
                  </td>
                 </tr>
               
         
                 <tr>
                  <td style='padding:0.0pt 0.0pt 0.0pt 5.0pt' colspan='3'>
                  	<ol > "

        For i As Integer = 0 To dt_par.Rows.Count - 1
            'data
            body_temp += "<li class='MsoNormal' style='line-height:15.25pt; font-size: 10pt;font-family:&quot;Arial&quot;,&quot;sans-serif&quot;;color:#606060'>" + dt_par.Rows(i)("group_store").ToString + "</li>"
        Next
        body_temp += "</ol>
                    </td>
                 </tr> 

         
          <tr>
                  <td style='padding:15.0pt 15.0pt 15.0pt 15.0pt' colspan='3'>
                  <div>
                  <p class='MsoNormal' style='line-height:14.25pt'><span style='font-size:10.0pt;font-family:&quot;Arial&quot;,&quot;sans-serif&quot;;color:#606060;letter-spacing:.4pt'>Thank you<br /><b>Volcom ERP</b><u></u><u></u></span></p>

                  </div>
                  </td>
                 </tr>
                </tbody>
              </table>
              <!-- end body -->


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
            </tbody>
        </table> "
        Return body_temp
    End Function
End Class
