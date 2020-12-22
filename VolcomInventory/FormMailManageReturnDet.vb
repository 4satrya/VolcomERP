Public Class FormMailManageReturnDet
    Public rmt As String = "-1"
    Public action As String = "-1"
    Public id As String = "-1"
    Dim id_mail_status As String = "-1"
    'Dim mail_head As String = ""
    Dim mail_subject As String = ""
    'Dim mail_title As String = ""
    'Dim mail_content_head As String = ""
    'Dim mail_content As String = ""
    'Dim mail_content_end As String = ""
    'Dim mail_content_to As String = ""
    Dim super_user As String = get_setup_field("id_role_super_admin")

    Private loaded As Boolean = False

    Private Sub FormMailManageReturnDet_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        actionLoad()

        loaded = True
    End Sub

    Private Sub FormMailManageReturnDet_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Function dtLoadDetail(ByVal id_sales_return_order_par As String)
        Dim dt As New DataTable
        If rmt = "45" Then
            Dim qdet As String = "
                SELECT 'no' AS is_check, a.id_sales_return_order, a.id_store_contact_to, CONCAT(d.comp_number, ' - ', d.comp_name) AS store_name_to, g.description AS group_store, d.comp_name AS group_company, a.sales_return_order_note, a.sales_return_order_note, a.sales_return_order_number, DATE_FORMAT(a.sales_return_order_date, '%d %M %Y') AS sales_return_order_date, DATE_FORMAT(a.sales_return_order_est_date,'%d %M %Y') AS sales_return_order_est_date, ot.order_type, SUM(b.design_price * b.sales_return_order_det_qty) AS amount, 45 AS report_mark_type, d.address_primary AS store_address_to, p.comp_name AS store_company
                FROM tb_sales_return_order a
                INNER JOIN tb_sales_return_order_det b ON a.id_sales_return_order = b.id_sales_return_order
                INNER JOIN tb_m_comp_contact c ON c.id_comp_contact = a.id_store_contact_to 
                INNER JOIN tb_m_comp d ON c.id_comp = d.id_comp 
                INNER JOIN tb_m_comp_group g ON g.id_comp_group = d.id_comp_group
                LEFT JOIN tb_lookup_order_type ot ON ot.id_order_type = a.id_order_type
                LEFT JOIN tb_m_comp AS p ON d.id_store_company = p.id_comp
                WHERE a.id_sales_return_order IN (" + id_sales_return_order_par + ")
                GROUP BY a.id_sales_return_order
                ORDER BY a.id_sales_return_order ASC"
            dt = execute_query(qdet, -1, True, "", "", "", "")
        End If
        Return dt
    End Function

    Function getSavedInvoice() As String
        Dim qinv As String = "SELECT d.id_report FROM tb_mail_manage_det d WHERE d.id_mail_manage=" + id + " "
        Dim dinv As DataTable = execute_query(qinv, -1, True, "", "", "", "")
        Dim id_sales_return_order As String = ""
        For i As Integer = 0 To dinv.Rows.Count - 1
            If i > 0 Then
                id_sales_return_order += ","
            End If
            id_sales_return_order += dinv.Rows(i)("id_report").ToString
        Next
        Return id_sales_return_order
    End Function

    Sub actionLoad()
        Cursor = Cursors.WaitCursor
        If action = "ins" Then
            TxtEmailNumber.Text = "[auto_generated]"
            TxtMailStatus.Text = "Pending"

            If rmt = "45" Then 'RETURN ORDER
                '-- mail type
                TxtMailType.Text = execute_query("SELECT report_mark_type_name FROM tb_lookup_report_mark_type WHERE report_mark_type='45'", 0, True, "", "", "", "")
                MEReason.EditValue = ""
                MEAdditionalInfo.EditValue = ""

                '--- load member
                Dim qf As String = "SELECT m.id_mail_manage_mapping_intern AS `index`,0 AS `id_mail_manage_member`,0 AS `id_mail_manage`,m.id_mail_member_type, mmt.mail_member_type,m.id_user,0 AS `id_comp_contact`, 
                e.employee_name AS `description`,e.email_external AS `mail_address`, e.employee_position AS `position` 
                FROM tb_mail_manage_mapping_intern m
                INNER JOIN tb_lookup_mail_member_type mmt ON mmt.id_mail_member_type = m.id_mail_member_type
                INNER JOIN tb_m_user u ON u.id_user = m.id_user
                INNER JOIN tb_m_employee e ON e.id_employee = u.id_employee
                WHERE e.email_external!='' AND m.report_mark_type='" + rmt + "' AND (ISNULL(m.id_comp_group) OR m.id_comp_group='" + FormMailManageReturn.SLEStoreGroup.EditValue.ToString + "')
                UNION
                SELECT m.id_mail_manage_mapping AS `index`,0 AS `id_mail_manage_member`,0 AS `id_mail_manage`,m.id_mail_member_type, mmt.mail_member_type, 0 AS `id_user`, m.id_comp_contact,
                cc.contact_person AS `description`, cc.email AS `mail_address`, '' AS `position`
                FROM tb_mail_manage_mapping m
                INNER JOIN tb_lookup_mail_member_type mmt ON mmt.id_mail_member_type = m.id_mail_member_type
                INNER JOIN tb_m_comp_contact cc ON cc.id_comp_contact = m.id_comp_contact
                WHERE m.id_comp_group='" + FormMailManageReturn.SLEStoreGroup.EditValue.ToString + "' AND cc.id_comp='" + FormMailManageReturn.SLEStoreCompany.EditValue.ToString + "' AND cc.email!='' AND m.report_mark_type='" + rmt + "'
                ORDER BY id_mail_member_type ASC, `index` ASC "
                Dim df As DataTable = execute_query(qf, -1, True, "", "", "", "")
                GCMember.DataSource = df
                GVMember.BestFitColumns()

                '--- load data
                Dim id_sales_return_order As String = ""
                For i As Integer = 0 To (FormMailManageReturn.GVReturnOrder.RowCount - 1)
                    If i > 0 Then
                        id_sales_return_order += ","
                    End If
                    id_sales_return_order += FormMailManageReturn.GVReturnOrder.GetRowCellValue(i, "id_sales_return_order").ToString
                Next
                Dim ddet As DataTable = dtLoadDetail(id_sales_return_order)
                GCDetail.DataSource = ddet
                GVDetail.BestFitColumns()

                Dim employee_name_from As String = ""
                Dim employee_position_from As String = ""

                '-- load 'from/to/cc & html preview
                GVMember.ActiveFilterString = ""
                For j As Integer = 0 To ((GVMember.RowCount - 1) - GetGroupRowCount(GVMember))
                    Dim id_mail_member_type As String = GVMember.GetRowCellValue(j, "id_mail_member_type").ToString
                    Dim mail_address As String = GVMember.GetRowCellValue(j, "mail_address").ToString

                    If id_mail_member_type = "1" Then
                        MEFrom.Text += mail_address + "; "

                        employee_name_from = GVMember.GetRowCellValue(j, "description").ToString
                        employee_position_from = GVMember.GetRowCellValue(j, "position").ToString
                    ElseIf id_mail_member_type = "2" Then
                        METo.Text += mail_address + "; "
                    Else
                        MECC.Text += mail_address + "; "
                    End If
                Next

                'load var
                Dim qopt As String = "SELECT mail_head_sales_return,mail_subject_sales_return, mail_title_sales_return , mail_content_head_sales_return, mail_content_sales_return ,mail_content_end_sales_return
                FROM tb_opt "
                Dim dopt As DataTable = execute_query(qopt, -1, True, "", "", "", "")
                'mail_head = dopt.Rows(0)("mail_head_sales_return").ToString
                mail_subject = dopt.Rows(0)("mail_subject_sales_return").ToString + " - " + ddet.Rows(0)("group_store").ToString
                'mail_title = dopt.Rows(0)("mail_title_sales_return").ToString
                'mail_content_head = dopt.Rows(0)("mail_content_head_sales_return").ToString
                'mail_content = dopt.Rows(0)("mail_content_sales_return").ToString
                'mail_content_end = dopt.Rows(0)("mail_content_end_sales_return").ToString
                MESubject.Text = addSlashes(mail_subject)

                'mail template
                Dim html As String = execute_query("SELECT template FROM tb_mail_manage_template WHERE `type` = 'ret'", 0, True, "", "", "", "")

                html = html.Replace("[return_reason]", MEReason.EditValue.ToString)
                html = html.Replace("[additional_info]", If(MEAdditionalInfo.EditValue.ToString = "", "", "<p style="" Font-family 'Times New Roman', Times, serif; Font-Size:  16px; margin: 5px 0 15px 0; "">" + MEAdditionalInfo.EditValue.ToString + "</p>"))
                html = html.Replace("[employee_name]", employee_name_from)
                html = html.Replace("[employee_position]", employee_position_from)

                WebBrowser1.DocumentText = html
            End If
        ElseIf action = "upd" Then
            '-- main view
            Dim mm As New ClassMailManageReturn()
            mm.id_mail_manage = id
            mm.rmt = rmt
            Dim query As String = mm.queryMain("AND m.id_mail_manage='" + id + "' ", "1")
            Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
            TxtEmailNumber.Text = data.Rows(0)("number").ToString
            TxtMailType.Text = data.Rows(0)("report_mark_type_name").ToString
            id_mail_status = data.Rows(0)("id_mail_status").ToString
            TxtMailStatus.Text = data.Rows(0)("mail_status").ToString
            MENote.Text = data.Rows(0)("mail_status_note").ToString
            DECreatedDate.EditValue = data.Rows(0)("created_date")
            TxtCreatedBy.Text = data.Rows(0)("created_by_name").ToString
            DEUpdatedDate.EditValue = data.Rows(0)("updated_date")
            TxtUpdatedBy.Text = data.Rows(0)("updated_by_name").ToString
            MESubject.Text = data.Rows(0)("mail_subject").ToString
            MEReason.EditValue = data.Rows(0)("reason").ToString
            MEAdditionalInfo.EditValue = data.Rows(0)("additional_info").ToString

            If rmt = "45" Then 'RETURN ORDER
                '-- load member
                Dim qf As String = "SELECT m.id_mail_manage_member AS `index`,m.`id_mail_manage_member`,m.`id_mail_manage`,m.id_mail_member_type, mmt.mail_member_type,m.id_user, 0 AS `id_comp_contact`, 
                e.employee_name AS `description`, m.mail_address AS `mail_address`, e.employee_position AS `position`
                FROM tb_mail_manage_member m
                INNER JOIN tb_lookup_mail_member_type mmt ON mmt.id_mail_member_type = m.id_mail_member_type
                INNER JOIN tb_m_user u ON u.id_user = m.id_user
                INNER JOIN tb_m_employee e ON e.id_employee = u.id_employee
                WHERE m.id_mail_manage=" + id + " AND ISNULL(m.id_comp_contact)
                UNION
                SELECT m.id_mail_manage_member AS `index`,m.`id_mail_manage_member`,m.`id_mail_manage`,m.id_mail_member_type, mmt.mail_member_type, 0 AS `id_user`, m.id_comp_contact,
                cc.contact_person AS `description`, cc.email AS `mail_address`, '' AS `position`
                FROM tb_mail_manage_member m
                INNER JOIN tb_lookup_mail_member_type mmt ON mmt.id_mail_member_type = m.id_mail_member_type
                INNER JOIN tb_m_comp_contact cc ON cc.id_comp_contact = m.id_comp_contact
                WHERE m.id_mail_manage=" + id + " AND ISNULL(m.id_user)
                ORDER BY id_mail_member_type ASC, `index` ASC "
                Dim df As DataTable = execute_query(qf, -1, True, "", "", "", "")
                GCMember.DataSource = df
                GVMember.BestFitColumns()

                '--- load data
                Dim id_sales_return_order As String = getSavedInvoice()
                Dim ddet As DataTable = dtLoadDetail(id_sales_return_order)
                GCDetail.DataSource = ddet
                GVDetail.BestFitColumns()

                '-- load 'from/to/cc & html preview
                Dim employee_name_from As String = ""
                Dim employee_position_from As String = ""

                GVMember.ActiveFilterString = ""
                MEFrom.Text = ""
                METo.Text = ""
                MECC.Text = ""
                For j As Integer = 0 To ((GVMember.RowCount - 1) - GetGroupRowCount(GVMember))
                    Dim id_mail_member_type As String = GVMember.GetRowCellValue(j, "id_mail_member_type").ToString
                    Dim mail_address As String = GVMember.GetRowCellValue(j, "mail_address").ToString

                    If id_mail_member_type = "1" Then
                        MEFrom.Text += mail_address + "; "

                        employee_name_from = GVMember.GetRowCellValue(j, "description").ToString
                        employee_position_from = GVMember.GetRowCellValue(j, "position").ToString
                    ElseIf id_mail_member_type = "2" Then
                        METo.Text += mail_address + "; "
                    Else
                        MECC.Text += mail_address + "; "
                    End If
                Next

                'load var
                Dim qopt As String = "SELECT mail_head_sales_return, mail_subject_sales_return, mail_title_sales_return , mail_content_head_sales_return, mail_content_sales_return, mail_content_end_sales_return
                FROM tb_opt"
                Dim dopt As DataTable = execute_query(qopt, -1, True, "", "", "", "")
                'mail_head = dopt.Rows(0)("mail_head_sales_return").ToString
                mail_subject = dopt.Rows(0)("mail_subject_sales_return").ToString + " - " + ddet.Rows(0)("group_store").ToString
                'mail_title = dopt.Rows(0)("mail_title_sales_return").ToString
                'mail_content_head = dopt.Rows(0)("mail_content_head_sales_return").ToString
                'mail_content = dopt.Rows(0)("mail_content_sales_return").ToString
                'mail_content_end = dopt.Rows(0)("mail_content_end_sales_return").ToString
                MESubject.Text = addSlashes(mail_subject)

                'mail template
                Dim html As String = execute_query("SELECT template FROM tb_mail_manage_template WHERE `type` = 'ret'", 0, True, "", "", "", "")

                html = html.Replace("[return_reason]", MEReason.EditValue.ToString)
                html = html.Replace("[additional_info]", If(MEAdditionalInfo.EditValue.ToString = "", "", "<p style="" Font-family 'Times New Roman', Times, serif; Font-Size:  16px; margin: 5px 0 15px 0; "">" + MEAdditionalInfo.EditValue.ToString + "</p>"))
                html = html.Replace("[employee_name]", employee_name_from)
                html = html.Replace("[employee_position]", employee_position_from)

                WebBrowser1.DocumentText = html
            End If

            '-- muncul dialog jika eror send
            If id_mail_status = "3" And Not checkAlreadySent() Then
                stopCustom("Last log show this email is 'FAILED' to send. Click 'RESEND' to try again.")
            End If

            '-- permision
            'general btn
            BtnLog.Visible = True

            'jika draft dan fail
            If id_mail_status = "1" Or id_mail_status = "3" Then
                BtnDraft.Visible = True
                BtnCancel.Visible = True
                MEReason.ReadOnly = False
                MEAdditionalInfo.ReadOnly = False
            Else
                BtnDraft.Visible = False
                BtnCancel.Visible = False
                MEReason.ReadOnly = True
                MEAdditionalInfo.ReadOnly = True
            End If

            'jika cancel
            If id_mail_status = "4" Then
                BtnSend.Visible = False
            End If

            'cek di log jika sudah pernah sent
            If checkAlreadySent() Then
                BtnDraft.Visible = False
                BtnCancel.Visible = False
                BtnSend.Text = "Resend"
            End If

            'jika sent tapi bukan super user
            If id_mail_status = "2" And id_role_login <> super_user Then
                BtnSend.Visible = False
            End If
        End If

        'include mail management
        Dim management_mail As String = getMailManagement(rmt)
        If management_mail <> "" Then
            MECC.Text += management_mail + ";"
        End If
        Cursor = Cursors.Default
    End Sub

    Function checkAlreadySent() As Boolean
        Dim qsl As String = "SELECT * FROM tb_mail_manage_log l WHERE l.id_mail_manage=" + id + " AND l.id_mail_status=2 "
        Dim dsl As DataTable = execute_query(qsl, -1, True, "", "", "", "")
        If dsl.Rows.Count > 0 Then
            Return True
        Else
            Return False
        End If
    End Function

    Private Sub GVDetail_CustomColumnDisplayText(sender As Object, e As DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs)
        If e.Column.FieldName = "no" Then
            e.DisplayText = (e.ListSourceRowIndex + 1).ToString()
        End If
    End Sub

    Private Sub BtnSend_Click(sender As Object, e As EventArgs) Handles BtnSend.Click
        Cursor = Cursors.WaitCursor
        If Not MEReason.Text = "" Then
            'ada konfirmasi
            Dim confirm As DialogResult = DevExpress.XtraEditors.XtraMessageBox.Show("Are you sure you want to send this email ? ", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
            If confirm = Windows.Forms.DialogResult.Yes Then
                save("2", "")
            End If
        Else
            stopCustom("Please add reason.")
        End If
        Cursor = Cursors.Default
    End Sub

    Private Sub BtnDraft_Click(sender As Object, e As EventArgs) Handles BtnDraft.Click
        Cursor = Cursors.WaitCursor
        save("1", "")
        Cursor = Cursors.Default
    End Sub

    Private Sub BtnCancel_Click(sender As Object, e As EventArgs) Handles BtnCancel.Click
        If checkAlreadySent() Then
            stopCustom("Can't cancel this transaction because email already sent")
        Else
            FormMailManageReturnCancel.rmt = rmt
            FormMailManageReturnCancel.id_mail_manage = id
            FormMailManageReturnCancel.ShowDialog()
            actionLoad()
            refreshMainView()
            If id_mail_status = "4" Then
                Close()
            End If
        End If
    End Sub

    Sub refreshMainView()
        FormMailManageReturn.XTCMailManage.SelectedTabPageIndex = 0
        FormMailManageReturn.viewMailManage()
        makeSafeGV(FormMailManageReturn.GVData)
        FormMailManageReturn.GVData.FocusedRowHandle = find_row(FormMailManageReturn.GVData, "id_mail_manage", id)
        If rmt = "45" Then
            FormMailManageReturn.SLEStoreGroup.EditValue = "0"
        End If
    End Sub

    Sub save(ByVal id_status_par As String, ByVal note_par As String)
        Cursor = Cursors.WaitCursor
        GVMember.ActiveFilterString = ""
        GVDetail.ActiveFilterString = ""
        Dim mail_subject As String = addSlashes(MESubject.Text)
        If action = "ins" Then
            'insert head
            Dim query As String = "INSERT INTO tb_mail_manage(number, created_date, created_by, updated_date, updated_by, report_mark_type, id_mail_status, mail_status_note, mail_subject, reason, additional_info) VALUES
            ('', NOW(), '" + id_user + "', NOW(), '" + id_user + "', '" + rmt + "', '1', '" + note_par + "', '" + mail_subject + "', '" + addSlashes(MEReason.EditValue.ToString) + "', '" + addSlashes(MEAdditionalInfo.EditValue.ToString) + "'); SELECT LAST_INSERT_ID(); "
            id = execute_query(query, 0, True, "", "", "", "")
            execute_non_query("UPDATE tb_mail_manage SET `number` = CONCAT((SELECT email_code_head FROM `tb_opt` LIMIT 1),LPAD(" + id + ",(SELECT email_code_digit FROM tb_opt LIMIT 1),'0')) WHERE id_mail_manage=" + id + ";", True, "", "", "", "")

            'insert member
            If GVMember.RowCount > 0 Then
                Dim query_member As String = "INSERT INTO tb_mail_manage_member(id_mail_manage, id_mail_member_type, id_user, id_comp_contact, mail_address) VALUES "
                For i As Integer = 0 To ((GVMember.RowCount - 1) - (GetGroupRowCount(GVMember)))
                    Dim id_mail_member_type As String = GVMember.GetRowCellValue(i, "id_mail_member_type").ToString
                    Dim id_userx As String = GVMember.GetRowCellValue(i, "id_user").ToString
                    If id_userx = "0" Then
                        id_userx = "NULL"
                    End If
                    Dim id_comp_contact As String = GVMember.GetRowCellValue(i, "id_comp_contact").ToString
                    If id_comp_contact = "0" Then
                        id_comp_contact = "NULL"
                    End If
                    Dim mail_address As String = addSlashes(GVMember.GetRowCellValue(i, "mail_address").ToString)

                    If i > 0 Then
                        query_member += ", "
                    End If
                    query_member += "('" + id + "', '" + id_mail_member_type + "', " + id_userx + ", " + id_comp_contact + ", '" + mail_address + "') "
                Next
                execute_non_query(query_member, True, "", "", "", "")
            End If

            'insert detil
            If GVDetail.RowCount > 0 Then
                Dim query_detail As String = "INSERT INTO tb_mail_manage_det(id_mail_manage, report_mark_type, id_report, report_number) VALUES "
                For j As Integer = 0 To ((GVDetail.RowCount - 1) - (GetGroupRowCount(GVDetail)))
                    Dim report_mark_type As String = GVDetail.GetRowCellValue(j, "report_mark_type").ToString
                    Dim id_report As String = GVDetail.GetRowCellValue(j, "id_sales_return_order").ToString
                    Dim report_number As String = GVDetail.GetRowCellValue(j, "sales_return_order_number").ToString

                    If j > 0 Then
                        query_detail += ","
                    End If
                    query_detail += "('" + id + "', '" + report_mark_type + "', '" + id_report + "', '" + report_number + "') "
                Next
                execute_non_query(query_detail, True, "", "", "", "")
            End If

            'other action
            If rmt = "45" Then
                updateSttInvoice("2")
            End If

            'send email
            If id_status_par = "2" Then 'send
                sendEmail()
            ElseIf id_status_par = "1" Then 'draft
                Dim querylog As String = "UPDATE tb_mail_manage SET updated_date=NOW(), updated_by='" + id_user + "', 
                id_mail_status=1, mail_status_note='Draft Email' WHERE id_mail_manage='" + id + "'; " + queryInsertLog("1", "Draft Email") + "; "
                execute_non_query(querylog, True, "", "", "", "")
            End If

            'actionLoad & refresh
            action = "upd"
            actionLoad()
            refreshMainView()

            'jika tidak gagal langsung close
            If id_mail_status <> "3" Then
                Close()
            End If
        Else
            'send email
            If id_status_par = "2" Then 'send
                sendEmail()
            ElseIf id_status_par = "1" Then 'draft
                Dim querylog As String = "UPDATE tb_mail_manage SET updated_date=NOW(), updated_by='" + id_user + "', 
                id_mail_status=1, mail_status_note='Draft Email' WHERE id_mail_manage='" + id + "'; " + queryInsertLog("1", "Draft Email") + "; "
                execute_non_query(querylog, True, "", "", "", "")
            End If

            'actionLoad & refresh
            action = "upd"
            actionLoad()
            refreshMainView()

            'jika tidak gagal langsung close
            If id_mail_status <> "3" Then
                Close()
            End If
        End If
        Cursor = Cursors.Default
    End Sub

    Function getTotalAmo(ByVal dtx As DataTable) As Double
        Dim tot_amo As Double = 0
        If rmt = "45" Then
            For i As Integer = 0 To dtx.Rows.Count - 1
                tot_amo += dtx.Rows(i)("amount")
            Next
        End If
        Return tot_amo
    End Function

    Sub sendEmail()
        'send mail
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

        Dim mail_address As DataTable = execute_query("SELECT m.mail_address, IFNULL(e.employee_name, c.contact_person) AS mail_name FROM tb_mail_manage_member m LEFT JOIN tb_m_user u ON m.id_user = u.id_user LEFT JOIN tb_m_employee e ON u.id_employee = e.id_employee LEFT JOIN tb_m_comp_contact c ON m.id_comp_contact = c.id_comp_contact WHERE m.id_mail_manage=" + id + " AND m.id_mail_member_type=1 ORDER BY m.id_mail_manage_member ASC LIMIT 1", -1, True, "", "", "", "")

        Dim from_mail As Net.Mail.MailAddress = New Net.Mail.MailAddress(mail_address.Rows(0)("mail_address").ToString, mail_address.Rows(0)("mail_name").ToString)
        Dim mail As Net.Mail.MailMessage = New Net.Mail.MailMessage()
        mail.From = from_mail

        'Send to => design_code : email; design : contact person;
        Dim query_send_to As String = "SELECT  m.id_mail_member_type,m.mail_address, IF(ISNULL(m.id_comp_contact), e.employee_name, cc.contact_person) AS `display_name`
            FROM tb_mail_manage_member m 
            LEFT JOIN tb_m_comp_contact cc ON cc.id_comp_contact = m.id_comp_contact
            LEFT JOIN tb_m_user u ON u.id_user = m.id_user
            LEFT JOIN tb_m_employee e ON e.id_employee = u.id_employee
            WHERE m.id_mail_manage=" + id + " AND m.id_mail_member_type>1 
            ORDER BY m.id_mail_member_type ASC,m.id_mail_manage_member ASC "
        Dim data_send_to As DataTable = execute_query(query_send_to, -1, True, "", "", "", "")
        For i As Integer = 0 To data_send_to.Rows.Count - 1
            Dim to_mail As Net.Mail.MailAddress = New Net.Mail.MailAddress(data_send_to.Rows(i)("mail_address").ToString, data_send_to.Rows(i)("display_name").ToString)
            If data_send_to.Rows(i)("id_mail_member_type").ToString = "2" Then
                mail.To.Add(to_mail)
            ElseIf data_send_to.Rows(i)("id_mail_member_type").ToString = "3" Then
                mail.CC.Add(to_mail)
            End If
        Next
        'include email management
        Dim management_mail As String = getMailManagement("45")
        If management_mail <> "" Then
            mail.CC.Add(management_mail)
        End If

        '-- start attachment 
        Dim list As List(Of DevExpress.XtraPrinting.Page) = New List(Of DevExpress.XtraPrinting.Page)
        Dim rpt As New ReportSalesReturnOrder()
        GVDetail.ActiveFilterString = ""
        For i As Integer = 0 To GVDetail.RowCount - 1
            Dim dt As DataTable = execute_query("CALL view_sales_return_order_less('" + GVDetail.GetRowCellValue(i, "id_sales_return_order").ToString + "')", -1, True, "", "", "", "")

            ReportSalesReturnOrder.id_sales_return_order = GVDetail.GetRowCellValue(i, "id_sales_return_order").ToString
            ReportSalesReturnOrder.dt = dt
            Dim Report As New ReportSalesReturnOrder()
            ReportStyleGridview(Report.GridView1)
            Report.LRecNumber.Text = GVDetail.GetRowCellValue(i, "sales_return_order_number").ToString
            Report.LRecDate.Text = GVDetail.GetRowCellValue(i, "sales_return_order_date").ToString
            Report.LabelTo.Text = GVDetail.GetRowCellValue(i, "store_name_to").ToString
            Report.LabelAddress.Text = GVDetail.GetRowCellValue(i, "store_address_to").ToString
            Report.LabelEstReturn.Text = GVDetail.GetRowCellValue(i, "sales_return_order_est_date").ToString
            Report.LabelNote.Text = GVDetail.GetRowCellValue(i, "sales_return_order_note").ToString
            Report.PrintingSystem.ContinuousPageNumbering = False
            Report.CreateDocument()

            For j = 0 To Report.Pages.Count - 1
                list.Add(Report.Pages(j))
            Next
        Next
        rpt.Pages.AddRange(list)

        ' Create a new memory stream and export the report into it as PDF.
        Dim Mem As New IO.MemoryStream()
        'Dim unik_file As String = execute_query("SELECT UNIX_TIMESTAMP(NOW())", 0, True, "", "", "", "")
        rpt.ExportToPdf(Mem)
        ' Create a new attachment and put the PDF report into it.
        Mem.Seek(0, System.IO.SeekOrigin.Begin)
        Dim Att = New Net.Mail.Attachment(Mem, "sal_ret_45_" & id & ".pdf", "application/pdf")
        mail.Attachments.Add(Att)
        '-- end attachment

        Dim id_sales_return_order As String = getSavedInvoice()
        Dim dtx As DataTable = dtLoadDetail(id_sales_return_order)

        Dim body_temp As String = WebBrowser1.DocumentText
        Dim subject_mail As String = execute_query("SELECT m.mail_subject FROM tb_mail_manage m WHERE m.id_mail_manage=" + id + "", 0, True, "", "", "", "")
        mail.Subject = subject_mail
        mail.IsBodyHtml = True
        mail.Body = body_temp

        Try
            client.Send(mail)

            Dim querylog As String = "UPDATE tb_mail_manage SET updated_date=NOW(), updated_by='" + id_user + "',id_mail_status=2, mail_status_note='Sent successfully' WHERE id_mail_manage='" + id + "'; " + queryInsertLog("2", "Sent successfully") + "; "
            execute_non_query(querylog, True, "", "", "", "")
        Catch ex As Exception
            Dim query As String = "UPDATE tb_mail_manage SET updated_date=NOW(), updated_by='" + id_user + "',id_mail_status=3, mail_status_note='" + addSlashes(ex.ToString) + "' WHERE id_mail_manage='" + id + "';" + queryInsertLog("3", ex.ToString) + "; "
            execute_non_query(query, True, "", "", "", "")
        End Try
    End Sub

    Function queryInsertLog(ByVal id_status_par As String, ByVal note_par As String) As String
        Dim query As String = "INSERT INTO tb_mail_manage_log(id_mail_manage, log_date, id_user, id_mail_status, note) VALUES 
        ('" + id + "', NOW(),'" + id_user + "', '" + id_status_par + "', '" + addSlashes(note_par) + "') "
        Return query
    End Function

    Sub updateSttInvoice(ByVal is_pending_mail_par As String)
        'update detil invoice
        Dim query As String = "UPDATE tb_sales_return_order main 
        INNER JOIN (
	        SELECT md.report_mark_type,md.id_report 
	        FROM tb_mail_manage_det md
	        WHERE md.id_mail_manage=" + id + "
        ) src ON src.id_report = main.id_sales_return_order
        SET main.is_pending_mail=" + is_pending_mail_par + " "
        execute_non_query(query, True, "", "", "", "")
    End Sub

    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs) Handles BtnAttach.Click
        Cursor = Cursors.WaitCursor
        If rmt = "45" Then
            Dim list As List(Of DevExpress.XtraPrinting.Page) = New List(Of DevExpress.XtraPrinting.Page)
            Dim rpt As New ReportSalesReturnOrder()
            GVDetail.ActiveFilterString = ""
            For i As Integer = 0 To GVDetail.RowCount - 1
                Dim dt As DataTable = execute_query("CALL view_sales_return_order_less('" + GVDetail.GetRowCellValue(i, "id_sales_return_order").ToString + "')", -1, True, "", "", "", "")

                ReportSalesReturnOrder.id_sales_return_order = GVDetail.GetRowCellValue(i, "id_sales_return_order").ToString
                ReportSalesReturnOrder.dt = dt
                Dim Report As New ReportSalesReturnOrder()
                ReportStyleGridview(Report.GridView1)
                Report.LRecNumber.Text = GVDetail.GetRowCellValue(i, "sales_return_order_number").ToString
                Report.LRecDate.Text = GVDetail.GetRowCellValue(i, "sales_return_order_date").ToString
                Report.LabelTo.Text = GVDetail.GetRowCellValue(i, "store_name_to").ToString
                Report.LabelAddress.Text = GVDetail.GetRowCellValue(i, "store_address_to").ToString
                Report.LabelEstReturn.Text = GVDetail.GetRowCellValue(i, "sales_return_order_est_date").ToString
                Report.LabelNote.Text = GVDetail.GetRowCellValue(i, "sales_return_order_note").ToString
                Report.PrintingSystem.ContinuousPageNumbering = False
                Report.CreateDocument()

                For j = 0 To Report.Pages.Count - 1
                    list.Add(Report.Pages(j))
                Next
            Next
            rpt.Pages.AddRange(list)
            Dim tool_detail As DevExpress.XtraReports.UI.ReportPrintTool = New DevExpress.XtraReports.UI.ReportPrintTool(rpt)
            tool_detail.ShowPreview()
        End If
        Cursor = Cursors.Default
    End Sub

    Private Sub BtnLog_Click(sender As Object, e As EventArgs) Handles BtnLog.Click
        Cursor = Cursors.WaitCursor
        FormMailManageLog.id = id
        FormMailManageLog.ShowDialog()
        Cursor = Cursors.Default
    End Sub

    Function email_body_sales_return(ByVal dtp As DataTable, ByVal titlep As String, ByVal content_head As String, ByVal content As String, ByVal content_end As String, ByVal tot_amountp As String)
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
                <p class='MsoNormal' align='center' style='text-align:center'><a href='http://www.volcom.co.id/' title='Volcom' target='_blank'><span style='text-decoration:none'><img border='0' width='180' id='m_1811720018273078822_x0000_i1025' src='https://d3k81ch9hvuctc.cloudfront.net/company/VFgA3P/images/de2b6f13-9275-426d-ae31-640f3dcfc744.jpeg' alt='Volcom' class='CToWUd' style='margin-top: 1em;'></span></a><u></u><u></u></p>
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
                      <th>No Sales Return</th>
                      <th>Estimate Return</th>
                      <th>Nominal</th>
                    </tr> "

        For i As Integer = 0 To dtp.Rows.Count - 1
            body_temp += "<tr>
                <td>" + (i + 1).ToString + "</td>
                <td>" + dtp.Rows(i)("store_name_to").ToString + "</td>
                <td>" + dtp.Rows(i)("sales_return_order_number").ToString + "</td>
                <td>" + dtp.Rows(i)("sales_return_order_est_date").ToString + "</td>
                <td align='center'>" + Decimal.Parse(dtp.Rows(i)("amount").ToString).ToString("N2") + "</td>
            </tr>"
        Next

        body_temp += "<tr>
            <th colspan='4'>TOTAL</th>
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

    Private Sub MEReason_EditValueChanged(sender As Object, e As EventArgs) Handles MEReason.EditValueChanged
        If loaded Then
            '-- load 'from/to/cc & html preview
            Dim employee_name_from As String = ""
            Dim employee_position_from As String = ""

            GVMember.ActiveFilterString = ""
            For j As Integer = 0 To ((GVMember.RowCount - 1) - GetGroupRowCount(GVMember))
                Dim id_mail_member_type As String = GVMember.GetRowCellValue(j, "id_mail_member_type").ToString

                If id_mail_member_type = "1" Then
                    employee_name_from = GVMember.GetRowCellValue(j, "description").ToString
                    employee_position_from = GVMember.GetRowCellValue(j, "position").ToString
                End If
            Next

            'mail template
            Dim html As String = execute_query("SELECT template FROM tb_mail_manage_template WHERE `type` = 'ret'", 0, True, "", "", "", "")

            html = html.Replace("[return_reason]", MEReason.EditValue.ToString)
            html = html.Replace("[additional_info]", If(MEAdditionalInfo.EditValue.ToString = "", "", "<p style="" Font-family 'Times New Roman', Times, serif; Font-Size:  16px; margin: 5px 0 15px 0; "">" + MEAdditionalInfo.EditValue.ToString + "</p>"))
            html = html.Replace("[employee_name]", employee_name_from)
            html = html.Replace("[employee_position]", employee_position_from)

            WebBrowser1.DocumentText = html
        End If
    End Sub

    Private Sub MEAdditionalInfo_EditValueChanged(sender As Object, e As EventArgs) Handles MEAdditionalInfo.EditValueChanged
        If loaded Then
            '-- load 'from/to/cc & html preview
            Dim employee_name_from As String = ""
            Dim employee_position_from As String = ""

            GVMember.ActiveFilterString = ""
            For j As Integer = 0 To ((GVMember.RowCount - 1) - GetGroupRowCount(GVMember))
                Dim id_mail_member_type As String = GVMember.GetRowCellValue(j, "id_mail_member_type").ToString

                If id_mail_member_type = "1" Then
                    employee_name_from = GVMember.GetRowCellValue(j, "description").ToString
                    employee_position_from = GVMember.GetRowCellValue(j, "position").ToString
                End If
            Next

            'mail template
            Dim html As String = execute_query("SELECT template FROM tb_mail_manage_template WHERE `type` = 'ret'", 0, True, "", "", "", "")

            html = html.Replace("[return_reason]", MEReason.EditValue.ToString)
            html = html.Replace("[additional_info]", If(MEAdditionalInfo.EditValue.ToString = "", "", "<p style="" Font-family 'Times New Roman', Times, serif; Font-Size:  16px; margin: 5px 0 15px 0; "">" + MEAdditionalInfo.EditValue.ToString + "</p>"))
            html = html.Replace("[employee_name]", employee_name_from)
            html = html.Replace("[employee_position]", employee_position_from)

            WebBrowser1.DocumentText = html
        End If
    End Sub
End Class