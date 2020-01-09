Public Class ClassAREvaluation
    Function dtCekEmailRelease(ByVal id_group As String) As DataTable
        Dim query_cek_email_release As String = "SELECT cg.id_comp_group_header, e.id_comp_group, IFNULL(ep.jum_not_active,0) AS `jum_not_active`
        FROM tb_ar_eval e
        INNER JOIN tb_m_comp_group cg ON cg.id_comp_group = e.id_comp_group
        LEFT JOIN (
          SELECT cg.id_comp_group_header,
          COUNT(e.id_sales_pos) AS `jum_not_active`
          FROM tb_ar_eval e
          INNER JOIN tb_m_comp_group cg ON cg.id_comp_group = e.id_comp_group
          WHERE e.eval_date IN (SELECT MAX(e.eval_date)  FROM tb_ar_eval e)
          AND cg.id_comp_group_header IN (" + id_group + ") AND e.is_active=1
          GROUP BY cg.id_comp_group_header
        ) ep ON ep.id_comp_group_header = cg.id_comp_group_header
        WHERE e.eval_date IN (SELECT MAX(e.eval_date)  FROM tb_ar_eval e)
        AND cg.id_comp_group_header IN (" + id_group + ")
        GROUP BY cg.id_comp_group_header
        HAVING jum_not_active=0 "
        Dim data_cek_email_release As DataTable = execute_query(query_cek_email_release, -1, True, "", "", "", "")
        Return data_cek_email_release
    End Function

    Sub holdDelivery(ByVal date_eval As String)
        Try
            'jalankan evaluasi
            Dim qins As String = "CALL getEvaluationAR('" + date_eval + "'); "
            execute_non_query(qins, True, "", "", "", "")

            'log
            Dim query_log As String = "INSERT INTO tb_ar_eval_log(eval_date, log_time, log) 
            VALUES('" + date_eval + "', NOW(), 'Evaluation Success'); "
            execute_non_query(query_log, True, "", "", "", "")
        Catch ex As Exception
            'log
            Dim query_log As String = "INSERT INTO tb_ar_eval_log(eval_date, log_time, log) 
            VALUES('" + date_eval + "', NOW(), 'Evaluation Failed : " + addSlashes(ex.ToString) + "'); "
            execute_non_query(query_log, True, "", "", "", "")
        End Try
    End Sub

    Sub sendEmailHoldDelivery(ByVal date_eval As String, ByVal date_eval_display As String)
        Dim mm As New ClassMailManage()
        Dim id_mail As String = "-1"
        Try
            Dim query_cek_eval As String = "SELECT COUNT(e.id_ar_eval) AS jum_eval FROM tb_ar_eval e WHERE e.eval_date='" + date_eval + "' "
            Dim data_cek_eval As DataTable = execute_query(query_cek_eval, -1, True, "", "", "", "")
            If data_cek_eval.Rows(0)("jum_eval") > 0 Then
                'create mail manage
                Dim mail_subject As String = get_setup_field("mail_subject_on_hold") + " - " + date_eval_display.ToString
                Dim mail_title As String = get_setup_field("mail_title_on_hold")
                Dim mail_content As String = get_setup_field("mail_content_on_hold")
                Dim query_mail_content_to As String = "SELECT CONCAT(e.employee_name, ' (',e.employee_position,')') AS `to_content_mail`
                    FROM tb_opt o
                    INNER JOIN tb_m_employee e ON e.id_employee = o.id_emp_wh_manager "
                Dim mail_content_to As String = execute_query(query_mail_content_to, 0, True, "", "", "", "")

                'send paramenter class
                mm.rmt = "228"
                mm.mail_subject = mail_subject
                mm.mail_title = mail_title
                mm.par1 = date_eval
                mm.createEmail("-1", id_user, "NULL", "NULL", "")
                id_mail = mm.id_mail_manage

                'email rep address
                Dim query_email_rep As String = "INSERT INTO tb_mail_manage_member(id_mail_manage, id_mail_member_type, id_user, id_comp_contact, mail_address)
                SELECT " + id_mail + " AS `id_mail_manage`, m.id_mail_member_type, m.id_user, NULL AS `id_comp_contact`, e.email_external AS `mail_address`
                FROM tb_mail_manage_mapping_intern m
                INNER JOIN tb_m_user u ON u.id_user = m.id_user
                INNER JOIN tb_m_employee e ON e.id_employee = u.id_employee
                WHERE m.report_mark_type=228 AND 
                m.id_comp_group IN (
	                SELECT e.id_comp_group 
	                FROM tb_ar_eval e WHERE e.eval_date='" + date_eval + "'
	                GROUP BY e.id_comp_group
                ) "
                execute_non_query(query_email_rep, True, "", "", "", "")

                'send email
                Dim sm As New ClassSendEmail()
                sm.id_report = id_mail
                sm.report_mark_type = "228"
                sm.design_code = mail_title
                sm.design = mail_subject
                sm.comment_by = mail_content_to
                sm.comment = mail_content
                sm.dt = mm.getDetailData()
                sm.send_email()

                Dim querylog As String = "INSERT INTO tb_ar_eval_log(eval_date, log_time, log, is_success) 
                    VALUES('" + date_eval + "', NOW(), 'Email Hold Delivery Sent successfully',1); " + mm.queryInsertLog(id_user, "2", "Sent successfully") + "; "
                execute_non_query(querylog, True, "", "", "", "")
            End If
        Catch ex As Exception
            'Log
            Dim query_log As String = "INSERT INTO tb_ar_eval_log(eval_date, log_time, log, is_success) 
            VALUES('" + date_eval + "', NOW(), 'Failed send email Hold Delivery : " + addSlashes(ex.ToString) + "',2); " + mm.queryInsertLog(id_user, "3", addSlashes(ex.ToString))
            execute_non_query(query_log, True, "", "", "", "")
        End Try

    End Sub

    Sub sendEmailPeringatan(ByVal date_eval As String, ByVal id_group As String, ByVal group_name As String)
        Dim mm As New ClassMailManage()
        Dim id_mail As String = "-1"
        Try
            Dim query_cek_eval As String = "SELECT COUNT(e.id_ar_eval) AS jum_eval FROM tb_ar_eval e WHERE e.eval_date='" + date_eval + "' AND e.id_comp_group='" + id_group + "' AND e.is_active=1 "
            Dim data_cek_eval As DataTable = execute_query(query_cek_eval, -1, True, "", "", "", "")
            If data_cek_eval.Rows(0)("jum_eval") > 0 Then
                'create mail var
                Dim qopt As String = "SELECT mail_head_peringatan,mail_subject_peringatan, mail_title_peringatan , mail_content_head_peringatan, mail_content_peringatan ,mail_content_end_peringatan
                FROM tb_opt "
                Dim dopt As DataTable = execute_query(qopt, -1, True, "", "", "", "")
                Dim mail_head As String = dopt.Rows(0)("mail_head_peringatan").ToString
                Dim mail_subject As String = dopt.Rows(0)("mail_subject_peringatan").ToString
                Dim mail_title As String = dopt.Rows(0)("mail_title_peringatan").ToString
                Dim mail_content_head As String = dopt.Rows(0)("mail_content_head_peringatan").ToString
                Dim mail_content As String = dopt.Rows(0)("mail_content_peringatan").ToString
                Dim mail_content_end As String = dopt.Rows(0)("mail_content_end_peringatan").ToString

                'send paramenter class
                mm.rmt = "227"
                mm.typ = "2"
                mm.par1 = date_eval
                mm.par2 = id_group
                mm.createEmail(id_group, id_user, "NULL", "NULL", "")
                id_mail = mm.id_mail_manage

                'data send email
                Dim qcont As String = "SELECT cgho.comp_name AS `group_company`, UPPER(cg.description) AS `group_store`,
                e.id_sales_pos AS `id_report`,e.report_number, CONCAT(c.comp_number,' - ', c.comp_name) AS `store`,
                CONCAT(DATE_FORMAT(sp.sales_pos_start_period,'%d-%m-%y'),' s/d ', DATE_FORMAT(sp.sales_pos_end_period,'%d-%m-%y')) AS `period`,
                DATE_FORMAT(sp.sales_pos_due_date,'%d-%m-%y') AS `sales_pos_due_date`,
                CAST(IF(typ.`is_receive_payment`=2,-1,1) * ((sp.`sales_pos_total`*((100-sp.sales_pos_discount)/100))-sp.`sales_pos_potongan`) AS DECIMAL(15,2))-IFNULL(pyd.`value`,0.00) AS `amount`
                FROM tb_ar_eval e 
                INNER JOIN tb_sales_pos sp ON sp.id_sales_pos = e.id_sales_pos
                INNER JOIN tb_m_comp_contact cc ON cc.`id_comp_contact`= IF(sp.id_memo_type=8 OR sp.id_memo_type=9, sp.id_comp_contact_bill,sp.`id_store_contact_from`)
                INNER JOIN tb_lookup_report_mark_type rmt ON rmt.report_mark_type=sp.report_mark_type
                INNER JOIN tb_m_comp c ON c.`id_comp`=cc.`id_comp`
                INNER JOIN tb_m_comp_group cg ON cg.id_comp_group = c.id_comp_group
                INNER JOIN tb_m_comp cgho ON cgho.id_comp = cg.id_comp
                INNER JOIN tb_lookup_memo_type typ ON typ.`id_memo_type`=sp.`id_memo_type`
                LEFT JOIN (
                   SELECT pyd.id_report, pyd.report_mark_type, 
                   COUNT(IF(py.id_report_status!=5 AND py.id_report_status!=6,py.id_rec_payment,NULL)) AS `total_pending`,
                   SUM(pyd.value) AS  `value`
                   FROM tb_rec_payment_det pyd
                   INNER JOIN tb_rec_payment py ON py.`id_rec_payment`=pyd.`id_rec_payment`
                   INNER JOIN tb_sales_pos sp ON sp.id_sales_pos = pyd.id_report AND sp.is_close_rec_payment=2
                   WHERE py.`id_report_status`=6
                   GROUP BY pyd.id_report, pyd.report_mark_type
                ) pyd ON pyd.id_report = sp.id_sales_pos AND pyd.report_mark_type = sp.report_mark_type
                LEFT JOIN tb_propose_delay_payment m ON m.id_propose_delay_payment = sp.id_propose_delay_payment
                WHERE e.id_comp_group=" + id_group + " AND e.eval_date='" + date_eval + "' AND e.is_active=1 "
                Dim dcont As DataTable = execute_query(qcont, -1, True, "", "", "", "")
                Dim tot_amo As Double = 0
                For i As Integer = 0 To dcont.Rows.Count - 1
                    tot_amo += dcont.Rows(i)("amount")
                Next

                'send email
                Dim sm As New ClassSendEmail()
                sm.id_report = id_mail
                sm.report_mark_type = "227"
                sm.head = mail_head
                sm.subj = mail_subject + " - " + dcont.Rows(0)("group_store").ToString
                sm.titl = mail_title
                sm.par1 = mail_content_head + " " + dcont.Rows(0)("group_company").ToString
                sm.par2 = mail_content
                sm.comment = mail_content_end
                sm.design_code = Double.Parse(tot_amo.ToString).ToString("N2")
                sm.dt = dcont
                sm.send_email()

                'log
                Dim querylog As String = "INSERT INTO tb_ar_eval_log(eval_date, log_time, log, is_success) 
                    VALUES('" + date_eval + "', NOW(), '" + group_name + " - Email Sent successfully',1); " + mm.queryInsertLog(id_user, "2", "" + group_name + " - Sent successfully") + "; "
                execute_non_query(querylog, True, "", "", "", "")

                'log follow up
                mm.insertLogFollowUp("")
            End If
        Catch ex As Exception
            'Log
            Dim query_log As String = "INSERT INTO tb_ar_eval_log(eval_date, log_time, log, is_success) 
            VALUES('" + date_eval + "', NOW(), '" + group_name + " - Failed send email : " + addSlashes(ex.ToString) + "',2); " + mm.queryInsertLog(id_user, "3", " + group_name + - " + addSlashes(ex.ToString))
            execute_non_query(query_log, True, "", "", "", "")
        End Try
    End Sub
End Class