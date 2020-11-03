Public Class FormSalesReturnOrderMailDet
    Public id_mail_3pl As String = "-1"
    Public id_store As String = "-1"

    Private last_id_mail_3pl As String = "-1"

    Private loaded As Boolean = False

    Private data_from As DataTable = New DataTable
    Private data_to As DataTable = New DataTable
    Private data_cc As DataTable = New DataTable
    Private data_subject As DataTable = New DataTable

    Private Sub FormSalesReturnOrderMailDet_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        view_3pl()
        view_3pl_status()
        view_store()

        If id_mail_3pl = "-1" Then
            'head
            SLUE3PL.EditValue = CType(SLUE3PL.Properties.DataSource, DataTable)(0)("id_cargo").ToString
            SLUE3PLStatus.EditValue = "1"
            SLUEStore.EditValue = id_store
            DECreatedDate.EditValue = Now
            TxtCreatedBy.EditValue = get_emp(id_employee_user, "2")
            TxtSentStatus.EditValue = "-"

            'detail
            Dim data_detail As DataTable = New DataTable

            data_detail.Columns.Add("id_sales_return_order", GetType(Integer))
            data_detail.Columns.Add("no", GetType(Integer))
            data_detail.Columns.Add("sales_return_order_number", GetType(String))
            data_detail.Columns.Add("store_name_to", GetType(String))
            data_detail.Columns.Add("pickup_date", GetType(Date))

            For i = 0 To FormSalesOrderSvcLevel.GVSalesReturnOrder.RowCount - 1
                Dim id_sales_return_order As Integer = FormSalesOrderSvcLevel.GVSalesReturnOrder.GetRowCellValue(i, "id_sales_return_order")
                Dim no As Integer = i + 1
                Dim sales_return_order_number As String = FormSalesOrderSvcLevel.GVSalesReturnOrder.GetRowCellValue(i, "sales_return_order_number")
                Dim store_name_to As String = FormSalesOrderSvcLevel.GVSalesReturnOrder.GetRowCellValue(i, "store_name_to")
                Dim pickup_date As Date = FormSalesOrderSvcLevel.GVSalesReturnOrder.GetRowCellValue(i, "pickup_date")

                data_detail.Rows.Add(id_sales_return_order, no, sales_return_order_number, store_name_to, pickup_date)
            Next

            GCDetail.DataSource = data_detail

            GVDetail.BestFitColumns()

            'from
            data_from = execute_query("
                SELECT emp.employee_name AS name, emp.email_external AS email
                FROM tb_sales_return_order_mail_mapping AS map
                LEFT JOIN tb_m_employee AS emp ON map.id_employee = emp.id_employee
                WHERE map.use_in = '3pl' AND map.type = 'from'
            ", -1, True, "", "", "", "")

            'to
            data_to = execute_query("
                SELECT c.comp_name AS name, cc.email
                FROM tb_m_comp_contact AS cc
                LEFT JOIN tb_m_comp AS c ON cc.id_comp = c.id_comp
                WHERE cc.id_comp = " + SLUE3PL.EditValue.ToString + " AND cc.is_default = 1
            ", -1, True, "", "", "", "")

            'cc
            data_cc = execute_query("
                SELECT emp.employee_name AS name, emp.email_external AS email
                FROM tb_sales_return_order_mail_mapping AS map
                LEFT JOIN tb_m_employee AS emp ON map.id_employee = emp.id_employee
                WHERE map.use_in = '3pl' AND map.type = 'cc'
            ", -1, True, "", "", "", "")

            'subject
            data_subject = New DataTable

            data_subject.Columns.Add("subject", GetType(String))

            data_subject.Rows.Add(get_setup_field("sales_return_order_3pl_subject"))

            'controls
            SBAccept.Visible = False
            SBDecline.Visible = False
            BtnSend.Visible = True
            SLUE3PL.ReadOnly = False
            SBOther3PL.Visible = False
        Else
            'head
            Dim query As String = "
                SELECT m.id_3pl, m.id_status, m.id_store, CONCAT(d.comp_number, ' - ', d.comp_name) AS store_name, m.subject, m.from, m.to, m.cc, m.body, m.sent_status, m.select_other_3pl, m.created_date, e.employee_name AS created_by
                FROM tb_sales_return_order_mail_3pl AS m
                LEFT JOIN tb_m_employee AS e ON m.created_by = e.id_employee
                LEFT JOIN tb_m_comp AS d ON d.id_comp = m.id_store
                WHERE m.id_mail_3pl = " + id_mail_3pl + "
            "

            Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")

            SLUE3PL.EditValue = data.Rows(0)("id_3pl").ToString
            SLUE3PLStatus.EditValue = data.Rows(0)("id_status").ToString
            SLUEStore.EditValue = data.Rows(0)("id_store").ToString
            DECreatedDate.EditValue = data.Rows(0)("created_date")
            TxtCreatedBy.EditValue = data.Rows(0)("created_by").ToString
            TxtSentStatus.EditValue = data.Rows(0)("sent_status").ToString

            'detail
            Dim query_detail As String = "
                SELECT s.id_sales_return_order, 0 AS no, s.sales_return_order_number, CONCAT(e.comp_number, ' - ', e.comp_name) AS store_name_to, s.pickup_date
                FROM tb_sales_return_order_mail_3pl_det AS d
                LEFT JOIN tb_sales_return_order AS s ON d.id_sales_order_return = s.id_sales_return_order
                LEFT JOIN tb_m_comp_contact AS c ON c.id_comp_contact = s.id_store_contact_to
                LEFT JOIN tb_m_comp AS e ON c.id_comp = e.id_comp 
                WHERE d.id_mail_3pl = " + id_mail_3pl + "
            "

            Dim data_detail As DataTable = execute_query(query_detail, -1, True, "", "", "", "")

            'numbering
            For i = 0 To data_detail.Rows.Count - 1
                data_detail.Rows(i)("no") = i + 1
            Next

            GCDetail.DataSource = data_detail

            GVDetail.BestFitColumns()

            'from
            data_from.Columns.Add("name", GetType(String))
            data_from.Columns.Add("email", GetType(String))

            Dim arr_data_from() As String = data.Rows(0)("from").ToString.Split(";")

            For i = 0 To arr_data_from.Count - 1
                data_from.Rows.Add("", arr_data_from(i))
            Next

            'to
            data_to.Columns.Add("name", GetType(String))
            data_to.Columns.Add("email", GetType(String))

            Dim arr_data_to() As String = data.Rows(0)("to").ToString.Split(";")

            For i = 0 To arr_data_to.Count - 1
                data_to.Rows.Add("", arr_data_to(i))
            Next

            'cc
            data_cc.Columns.Add("name", GetType(String))
            data_cc.Columns.Add("email", GetType(String))

            Dim arr_data_cc() As String = data.Rows(0)("cc").ToString.Split(";")

            For i = 0 To arr_data_cc.Count - 1
                data_cc.Rows.Add("", arr_data_cc(i))
            Next

            'subject
            data_subject = New DataTable

            data_subject.Columns.Add("subject", GetType(String))

            data_subject.Rows.Add(data.Rows(0)("subject").ToString)

            'body
            WebBrowser.DocumentText = data.Rows(0)("body").ToString

            'controls
            SBAccept.Visible = True
            SBDecline.Visible = True
            BtnSend.Visible = False
            SLUE3PL.ReadOnly = True
            SBOther3PL.Visible = False

            If SLUE3PLStatus.EditValue.ToString = "3" Or SLUE3PLStatus.EditValue.ToString = "4" Then
                SBAccept.Visible = False
                SBDecline.Visible = False
            End If

            If SLUE3PLStatus.EditValue.ToString = "4" Then
                SBOther3PL.Visible = True
            End If

            If data.Rows(0)("select_other_3pl") Then
                SBOther3PL.Visible = False
            End If
        End If

        display_recipient()

        If id_mail_3pl = "-1" Then
            display_html()
        End If

        loaded = True
    End Sub

    Sub view_3pl()
        Dim query As String = "
            SELECT r.id_cargo, c.comp_name AS `cargo_name`, r.cargo_rate, r.cargo_lead_time, r.cargo_min_weight
            FROM tb_wh_cargo_rate r 
            INNER JOIN tb_m_comp c ON c.id_comp = r.id_cargo
            WHERE 1 " + If(id_mail_3pl = "-1", " AND r.id_store=" + id_store + "", "") + " AND r.id_rate_type=2
            ORDER BY r.cargo_rate ASC
        "

        viewSearchLookupQuery(SLUE3PL, query, "id_cargo", "cargo_name", "id_cargo")
    End Sub

    Sub view_3pl_status()
        Dim query As String = "
            SELECT id_status, `status`
            FROM tb_lookup_ror_mail_3pl_status_lookup
        "

        viewSearchLookupQuery(SLUE3PLStatus, query, "id_status", "status", "id_status")
    End Sub

    Sub view_store()
        Dim query As String = "
            SELECT id_comp AS id_store, CONCAT(comp_number, ' - ', comp_name) AS store_name
            FROM tb_m_comp
        "

        viewSearchLookupQuery(SLUEStore, query, "id_store", "store_name", "id_store")
    End Sub

    Sub display_html()
        Dim html As String = "
            <table cellpadding='0' cellspacing='0' width='100%' style='background-color: #EEEEEE; padding: 30pt;'>
                <tr>
                    <td align='center'>
                        <table cellpadding='0' cellspacing='0' width='700' style='background-color: #FFFFFF;'>
                            <tr>
                                <td style='text-align: center; padding: 30pt 0pt;'>
                                    <a href='http://www.volcom.co.id' title='Volcom' target='_blank'>
                                        <img src='https://d3k81ch9hvuctc.cloudfront.net/company/VFgA3P/images/de2b6f13-9275-426d-ae31-640f3dcfc744.jpeg' alt='Volcom' height='142' width='200'>
                                    </a>
                                </td>
                            </tr>
                            <tr>
                                <td style='background-color: #EEEEEE; padding: 5pt 0pt;'></td>
                            </tr>
                            <tr>
                                <td style='padding: 30pt;'>
                                    <p style='font-size: 12pt; font-family: Arial, sans-serif; font-weight: bold; margin: 0pt 0pt 10pt 0pt;'>Dear " + SLUE3PL.Text + ",</p>
                                    <p style='font-size: 10pt; font-family: Arial, sans-serif; margin: 0pt 0pt 5pt 0pt;'>Please confirm to pick up this item :</p>
                                    <table border='1' cellpadding='0' cellspacing='0' width='100%' style='margin: 15pt 0;'>
                                        <tr>
                                            <th style='padding: 5pt 10pt;'><p style='font-size: 10pt; font-family: Arial, sans-serif; margin: 0pt 0pt 0pt 0pt;'>No</p></th>
                                            <th style='padding: 5pt 10pt;'><p style='font-size: 10pt; font-family: Arial, sans-serif; margin: 0pt 0pt 0pt 0pt;'>No Sales Return</p></th>
                                            <th style='padding: 5pt 10pt;'><p style='font-size: 10pt; font-family: Arial, sans-serif; margin: 0pt 0pt 0pt 0pt;'>Store</p></th>
                                            <th style='padding: 5pt 10pt;'><p style='font-size: 10pt; font-family: Arial, sans-serif; margin: 0pt 0pt 0pt 0pt;'>Pick Up Date</p></th>
                                        </tr>
        "

        For i = 0 To GVDetail.RowCount - 1
            html += "
                <tr>
                    <td style='padding: 5pt 10pt;'><p style='font-size: 10pt; font-family: Arial, sans-serif; margin: 0pt 0pt 0pt 0pt;'>" + (i + 1).ToString + "</p></td>
                    <td style='padding: 5pt 10pt;'><p style='font-size: 10pt; font-family: Arial, sans-serif; margin: 0pt 0pt 0pt 0pt;'>" + GVDetail.GetRowCellValue(i, "sales_return_order_number").ToString + "</p></td>
                    <td style='padding: 5pt 10pt;'><p style='font-size: 10pt; font-family: Arial, sans-serif; margin: 0pt 0pt 0pt 0pt;'>" + GVDetail.GetRowCellValue(i, "store_name_to").ToString + "</p></td>
                    <td style='padding: 5pt 10pt;'><p style='font-size: 10pt; font-family: Arial, sans-serif; margin: 0pt 0pt 0pt 0pt;'>" + Date.Parse(GVDetail.GetRowCellValue(i, "pickup_date").ToString).ToString("dd MMMM yyyy") + "</p></td>
                </tr>
            "
        Next

        html += "
                                    </table>
                                    <p style='font-size: 10pt; font-family: Arial, sans-serif; margin: 25pt 0pt 10pt 0pt;'>Thank you</p>
                                    <p style='font-size: 12pt; font-family: Arial, sans-serif; font-weight: bold; margin: 0pt;'>Volcom ERP</p>
                                </td>
                            </tr>
                            <tr>
                                <td style='background-color: #EEEEEE; padding: 5pt 0pt;'></td>
                            </tr>
                            <tr>
                                <td style='text-align: center; padding: 30pt 0pt;'>
                                    <p><a href='http://www.volcom.co.id' style='font-size: 9pt; font-family: Arial, sans-serif; color: #A0A0A0;' title='Volcom' target='_blank'>Volcom Indonesia</a></p>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
        "

        WebBrowser.DocumentText = html
    End Sub

    Private Sub BtnSend_Click(sender As Object, e As EventArgs) Handles BtnSend.Click
        If Not METo.Text.ToString = "" Then
            Dim confirm As DialogResult = DevExpress.XtraEditors.XtraMessageBox.Show("Are you sure want to send this email ? ", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)

            If confirm = DialogResult.Yes Then
                Dim sent_status As String = "OK"

                'send mail
                sent_status = send_mail()

                'save
                Dim query As String = "
                    INSERT INTO tb_sales_return_order_mail_3pl (id_3pl, id_store, id_status, `subject`, `from`, `to`, cc, body, sent_status, error_status, created_date, created_by) VALUES (" + SLUE3PL.EditValue.ToString + ", " + SLUEStore.EditValue.ToString + ", 2, '" + addSlashes(MESubject.EditValue.ToString) + "', '" + MEFrom.EditValue.ToString + "', '" + METo.EditValue.ToString + "', '" + MECC.EditValue.ToString + "', '" + addSlashes(WebBrowser.DocumentText) + "', '" + If(sent_status = "OK", "OK", "ERROR") + "', '" + If(sent_status = "OK", "", sent_status) + "', NOW(), " + id_employee_user + "); SELECT LAST_INSERT_ID();
                "

                id_mail_3pl = execute_query(query, 0, True, "", "", "", "")

                Dim query_detail As String = "INSERT INTO tb_sales_return_order_mail_3pl_det (id_mail_3pl, id_sales_order_return) VALUES "

                For i = 0 To GVDetail.RowCount - 1
                    query_detail += "(" + id_mail_3pl + ", " + GVDetail.GetRowCellValue(i, "id_sales_return_order").ToString + "), "
                Next

                query_detail = query_detail.Substring(0, query_detail.Length - 2)

                execute_non_query(query_detail, True, "", "", "", "")

                'update other 3pl
                execute_non_query("UPDATE tb_sales_return_order_mail_3pl SET select_other_3pl = 1 WHERE id_mail_3pl = " + last_id_mail_3pl + "", True, "", "", "", "")

                Close()
            End If
        Else
            stopCustom("Please input 3PL email address.")
        End If
    End Sub

    Private Sub FormSalesReturnOrderMailDet_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Try
            FormSalesReturnOrderMail.form_load()
            FormSalesOrderSvcLevel.viewReturnOrder()
        Catch ex As Exception
        End Try

        Dispose()
    End Sub

    Private Sub SLUE3PL_EditValueChanged(sender As Object, e As EventArgs) Handles SLUE3PL.EditValueChanged
        If loaded Then
            'to
            data_to = execute_query("
                SELECT c.comp_name AS name, cc.email
                FROM tb_m_comp_contact AS cc
                LEFT JOIN tb_m_comp AS c ON cc.id_comp = c.id_comp
                WHERE cc.id_comp = " + SLUE3PL.EditValue.ToString + " AND cc.is_default = 1
            ", -1, True, "", "", "", "")

            'list to
            Dim list_to As String = ""

            For i = 0 To data_to.Rows.Count - 1
                list_to += data_to(i)("email").ToString + "; "
            Next

            list_to = list_to.Substring(0, list_to.Length - 2)

            METo.EditValue = list_to

            display_html()
        End If
    End Sub

    Sub change_status(id_status As String)
        Dim status As String = execute_query("SELECT `status` FROM tb_lookup_ror_mail_3pl_status_lookup WHERE id_status = " + id_status, 0, True, "", "", "", "")

        Dim confirm As DialogResult = DevExpress.XtraEditors.XtraMessageBox.Show("Are you sure you want to " + status.ToLower + " this ? ", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)

        If confirm = DialogResult.Yes Then
            Dim query As String = "UPDATE tb_sales_return_order_mail_3pl SET id_status = " + id_status + " WHERE id_mail_3pl = " + id_mail_3pl

            execute_non_query(query, True, "", "", "", "")

            infoCustom("Status updated.")

            If id_status = "4" Then
                Dim confirm_next As DialogResult = DevExpress.XtraEditors.XtraMessageBox.Show("Do you want to choose another 3PL ?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)

                If confirm_next = DialogResult.Yes Then
                    change_3pl()
                Else
                    Close()
                End If
            Else
                Close()
            End If
        End If
    End Sub

    Private Sub SBAccept_Click(sender As Object, e As EventArgs) Handles SBAccept.Click
        change_status("3")
    End Sub

    Private Sub SBDecline_Click(sender As Object, e As EventArgs) Handles SBDecline.Click
        change_status("4")
    End Sub

    Private Sub FormSalesReturnOrderMailDet_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown
        '3pl email
        If METo.Text.ToString = "" Then
            stopCustom("Please input 3PL email address.")
        End If
    End Sub

    Sub change_3pl()
        last_id_mail_3pl = id_mail_3pl

        id_mail_3pl = "-1"

        'choose another 3pl
        Dim query_3pl As String = "
            SELECT r.id_cargo, c.comp_name AS `cargo_name`, r.cargo_rate, r.cargo_lead_time, r.cargo_min_weight
            FROM tb_wh_cargo_rate r 
            INNER JOIN tb_m_comp c ON c.id_comp = r.id_cargo
            WHERE 1 AND r.id_store=" + id_store + " AND r.id_rate_type=2 AND r.id_cargo <> " + SLUE3PL.EditValue.ToString + "
            ORDER BY r.cargo_rate ASC
        "

        Dim data_3pl As String = execute_query(query_3pl, 0, True, "", "", "", "")

        view_3pl()

        SLUE3PL.EditValue = data_3pl
        SLUE3PLStatus.EditValue = "1"
        DECreatedDate.EditValue = Now
        TxtCreatedBy.EditValue = get_emp(id_employee_user, "2")
        TxtSentStatus.EditValue = "-"

        display_html()

        'from
        data_from = execute_query("
            SELECT emp.employee_name AS name, emp.email_external AS email
            FROM tb_sales_return_order_mail_mapping AS map
            LEFT JOIN tb_m_employee AS emp ON map.id_employee = emp.id_employee
            WHERE map.use_in = '3pl' AND map.type = 'from'
        ", -1, True, "", "", "", "")

        'to
        data_to = execute_query("
            SELECT c.comp_name AS name, cc.email
            FROM tb_m_comp_contact AS cc
            LEFT JOIN tb_m_comp AS c ON cc.id_comp = c.id_comp
            WHERE cc.id_comp = " + SLUE3PL.EditValue.ToString + " AND cc.is_default = 1
        ", -1, True, "", "", "", "")

        'cc
        data_cc = execute_query("
            SELECT emp.employee_name AS name, emp.email_external AS email
            FROM tb_sales_return_order_mail_mapping AS map
            LEFT JOIN tb_m_employee AS emp ON map.id_employee = emp.id_employee
            WHERE map.use_in = '3pl' AND map.type = 'cc'
        ", -1, True, "", "", "", "")

        'subject
        data_subject = New DataTable

        data_subject.Columns.Add("subject", GetType(String))

        data_subject.Rows.Add(get_setup_field("sales_return_order_3pl_subject"))

        display_recipient()

        'controls
        SBAccept.Visible = False
        SBDecline.Visible = False
        BtnSend.Visible = True
        SLUE3PL.ReadOnly = False
        SBOther3PL.Visible = False
    End Sub

    Private Sub SBOther3PL_Click(sender As Object, e As EventArgs) Handles SBOther3PL.Click
        Dim confirm_next As DialogResult = DevExpress.XtraEditors.XtraMessageBox.Show("Do you want to choose another 3PL ?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)

        If confirm_next = DialogResult.Yes Then
            change_3pl()
        End If
    End Sub

    Sub display_recipient()
        'list from
        Dim list_from As String = ""

        For i = 0 To data_from.Rows.Count - 1
            If Not data_from(i)("email").ToString = "" Then
                list_from += data_from(i)("email").ToString + "; "
            End If
        Next

        If Not list_from = "" Then
            list_from = list_from.Substring(0, list_from.Length - 2)

            MEFrom.EditValue = list_from
        End If

        'list to
        Dim list_to As String = ""

        For i = 0 To data_to.Rows.Count - 1
            If Not data_to(i)("email").ToString = "" Then
                list_to += data_to(i)("email").ToString + "; "
            End If
        Next

        If Not list_to = "" Then
            list_to = list_to.Substring(0, list_to.Length - 2)

            METo.EditValue = list_to
        End If

        'list cc
        Dim list_cc As String = ""

        For i = 0 To data_cc.Rows.Count - 1
            If Not data_cc(i)("email").ToString = "" Then
                list_cc += data_cc(i)("email").ToString + "; "
            End If
        Next

        If Not list_cc = "" Then
            list_cc = list_cc.Substring(0, list_cc.Length - 2)

            MECC.EditValue = list_cc
        End If

        'list subject
        MESubject.EditValue = data_subject.Rows(0)("subject").ToString
    End Sub

    Function send_mail() As String
        Dim is_ssl = get_setup_field("system_email_is_ssl").ToString

        Dim client As Net.Mail.SmtpClient = New Net.Mail.SmtpClient()

        If is_ssl = "1" Then
            client.Port = get_setup_field("system_email_ssl_port").ToString
            client.DeliveryMethod = Net.Mail.SmtpDeliveryMethod.Network
            client.UseDefaultCredentials = False
            client.Host = get_setup_field("system_email_ssl_server").ToString
            client.EnableSsl = True
            client.Credentials = New System.Net.NetworkCredential(get_setup_field("system_email_ssl").ToString, get_setup_field("system_email_ssl_pass").ToString)
        Else
            client.Port = get_setup_field("system_email_port").ToString
            client.DeliveryMethod = Net.Mail.SmtpDeliveryMethod.Network
            client.UseDefaultCredentials = False
            client.Host = get_setup_field("system_email_server").ToString
            client.Credentials = New System.Net.NetworkCredential(get_setup_field("system_email").ToString, get_setup_field("system_email_pass").ToString)
        End If

        'mail
        Dim mail As Net.Mail.MailMessage = New Net.Mail.MailMessage()

        'from
        Dim from_mail As Net.Mail.MailAddress = New Net.Mail.MailAddress(data_from.Rows(0)("email").ToString, data_from.Rows(0)("name").ToString)

        mail.From = from_mail

        'to
        For j = 0 To data_to.Rows.Count - 1
            If Not data_to.Rows(j)("email").ToString = "" Then
                Dim to_mail As Net.Mail.MailAddress = New Net.Mail.MailAddress(data_to.Rows(j)("email").ToString, data_to.Rows(j)("name").ToString)

                mail.To.Add(to_mail)
            End If
        Next

        'cc
        For j = 0 To data_cc.Rows.Count - 1
            If Not data_cc.Rows(j)("email").ToString = "" Then
                Dim cc_mail As Net.Mail.MailAddress = New Net.Mail.MailAddress(data_cc.Rows(j)("email").ToString, data_cc.Rows(j)("name").ToString)

                mail.CC.Add(cc_mail)
            End If
        Next

        'subject & body
        mail.Subject = data_subject.Rows(0)("subject").ToString

        mail.IsBodyHtml = True

        mail.Body = WebBrowser.DocumentText

        Dim out As String = "OK"

        Try
            client.Send(mail)

            mail.Dispose()
        Catch ex As Exception
            out = ex.ToString
        End Try

        Return out
    End Function
End Class