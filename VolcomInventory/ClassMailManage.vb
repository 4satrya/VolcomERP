Public Class ClassMailManage
    Public id_mail_manage As String = "-1"
    Public mail_subject As String = ""
    Public mail_title As String = ""
    Public rmt As String = "-1"
    Public typ As String = "1"
    Public par1 As String = ""
    Public par2 As String = ""

    Public Function queryMain(ByVal condition As String, ByVal order_type As String) As String
        If order_type = "1" Then
            order_type = "ASC "
        ElseIf order_type = "2" Then
            order_type = "DESC "
        End If

        If condition <> "-1" Then
            condition = condition
        Else
            condition = ""
        End If

        Dim query As String = "SELECT m.id_mail_manage, m.`number`, 
        m.created_date, m.created_by, ec.employee_name AS `created_by_name`, 
        m.updated_date, m.updated_by, eu.employee_name AS `updated_by_name`,
        m.report_mark_type, rmt.report_mark_type_name, 
        m.id_mail_status, ms.mail_status, m.mail_status_note, m.mail_subject, mto.`to`
        FROM tb_mail_manage m
        LEFT JOIN tb_m_user uc ON uc.id_user = m.created_by
        LEFT JOIN tb_m_employee ec ON ec.id_employee = uc.id_employee
        LEFT JOIN tb_m_user uu ON uu.id_user = m.updated_by
        LEFT JOIN tb_m_employee eu ON eu.id_employee = uu.id_employee
        INNER JOIN tb_lookup_report_mark_type rmt ON rmt.report_mark_type = m.report_mark_type
        INNER JOIN tb_lookup_mail_status ms ON ms.id_mail_status = m.id_mail_status
        LEFT JOIN (
	        SELECT m.id_mail_manage, GROUP_CONCAT(DISTINCT m.mail_address ORDER BY m.id_mail_manage_member ASC SEPARATOR ', ') AS `to` 
	        FROM tb_mail_manage_member m WHERE m.id_mail_member_type=2 
	        GROUP BY m.id_mail_manage
        ) mto ON mto.id_mail_manage = m.id_mail_manage
        WHERE m.id_mail_manage>0 "
        query += condition + " "
        query += "ORDER BY m.id_mail_manage " + order_type
        Return query
    End Function

    Sub createEmail(ByVal id_comp_group_par As String, ByVal id_user_created As String, ByVal id_report_ref As String, ByVal report_mark_type_ref As String, ByVal report_number_ref As String)
        If id_user_created = "0" Then
            id_user_created = "NULL"
        End If

        'group toko
        Dim cond_internal_group As String = ""
        If id_comp_group_par <> "-1" Then
            cond_internal_group = "OR m.id_comp_group='" + id_comp_group_par + "' "
        End If

        Dim query_mail_manage As String = "INSERT INTO tb_mail_manage(number, created_date, created_by, updated_date, updated_by, report_mark_type, id_mail_status, mail_status_note, mail_subject, mail_parameter) 
        VALUES('', NOW(), " + id_user_created + ", NOW(), " + id_user_created + ", " + rmt + ", 1, 'Draft', '" + mail_subject + "', '" + par1 + "'); SELECT LAST_INSERT_ID(); "
        id_mail_manage = execute_query(query_mail_manage, 0, True, "", "", "", "")
        'update number mail
        execute_non_query("CALL gen_number(" + id_mail_manage + ", " + rmt + ");", True, "", "", "", "")
        'insert member & detil
        Dim query_mail_detail As String = "/*member*/
        INSERT INTO tb_mail_manage_member(id_mail_manage, id_mail_member_type, id_user, id_comp_contact, mail_address) "
        If rmt = "227" Then
            'to dari comp group
            query_mail_detail += "SELECT " + id_mail_manage + " AS `id_mail_manage`, m.id_mail_member_type, NULL AS `id_user`, m.id_comp_contact, cc.email AS `mail_address`
            FROM tb_mail_manage_mapping m
            INNER JOIN tb_m_comp_contact cc ON cc.id_comp_contact = m.id_comp_contact
            WHERE m.report_mark_type=" + rmt + " AND m.id_comp_group=" + par2 + "
            UNION "
        End If
        query_mail_detail += "SELECT " + id_mail_manage + " AS `id_mail_manage`, m.id_mail_member_type, m.id_user, NULL AS `id_comp_contact`, e.email_external AS `mail_address`
        FROM tb_mail_manage_mapping_intern m
        INNER JOIN tb_m_user u ON u.id_user = m.id_user
        INNER JOIN tb_m_employee e ON e.id_employee = u.id_employee
        WHERE m.report_mark_type=" + rmt + " AND (ISNULL(m.id_comp_group) " + cond_internal_group + "); "
        query_mail_detail += "/*detil*/
        INSERT INTO tb_mail_manage_det(id_mail_manage, report_mark_type, id_report, report_number, id_report_ref, report_mark_type_ref, report_number_ref) "
        If rmt = "227" Then 'email peringatan
            If typ = "1" Then
                'regular
                query_mail_detail += "SELECT " + id_mail_manage + " AS `id_mail_manage`, sp.report_mark_type, sp.id_sales_pos, sp.sales_pos_number, " + id_report_ref + ", " + report_mark_type_ref + ", '" + report_number_ref + "'
                FROM tb_sales_pos sp
                INNER JOIN tb_m_comp_contact cc ON cc.`id_comp_contact`= IF(sp.id_memo_type=8 OR sp.id_memo_type=9, sp.id_comp_contact_bill,sp.`id_store_contact_from`)
                INNER JOIN tb_lookup_report_mark_type rmt ON rmt.report_mark_type=sp.report_mark_type
                INNER JOIN tb_m_comp c ON c.`id_comp`=cc.`id_comp`
                INNER JOIN tb_m_comp_group cg ON cg.id_comp_group = c.id_comp_group
                INNER JOIN tb_lookup_memo_type typ ON typ.`id_memo_type`=sp.`id_memo_type`
                LEFT JOIN tb_propose_delay_payment m ON m.id_propose_delay_payment = sp.id_propose_delay_payment
                WHERE sp.`id_report_status`='6' AND sp.is_close_rec_payment=2 AND sp.sales_pos_total>0
                AND (DATEDIFF(NOW(),IF(ISNULL(sp.propose_delay_payment_due_date),sp.sales_pos_due_date,sp.propose_delay_payment_due_date))>0)
                AND cg.id_comp_group=" + par2 + "
                GROUP BY sp.id_sales_pos	
                ORDER BY c.id_comp_group ASC, sp.id_sales_pos ASC; "
            ElseIf typ = "2" Then
                'base on eval
                query_mail_detail += "SELECT " + id_mail_manage + " AS `id_mail_manage`, e.report_mark_type, e.id_sales_pos, e.report_number, " + id_report_ref + ", " + report_mark_type_ref + ", '" + report_number_ref + "'
                FROM tb_ar_eval e WHERE e.id_comp_group=" + par2 + " AND e.eval_date='" + par1 + "'; "
            End If
        ElseIf rmt = "228" Then 'email hold delivery
            query_mail_detail += "SELECT " + id_mail_manage + " AS `id_mail_manage`, e.report_mark_type, e.id_sales_pos, e.report_number, " + id_report_ref + ", " + report_mark_type_ref + ", '" + report_number_ref + "'
            FROM tb_ar_eval e WHERE e.eval_date='" + par1 + "'; "
        ElseIf rmt = "230" Then 'email release delivery
            query_mail_detail += "SELECT " + id_mail_manage + ", " + rmt + ", g.id_comp_group_header AS `id_report`, NULL AS `report_number`, " + id_report_ref + ", " + report_mark_type_ref + ", '" + report_number_ref + "'
            FROM tb_m_comp_group g 
            WHERE g.id_comp_group_header IN(" + par1 + ") "
        End If
        execute_non_query(query_mail_detail, True, "", "", "", "")
    End Sub

    Function getDetailData() As DataTable
        Dim dt As New DataTable

        'get id_report
        Dim query_get_id As String = "SELECT GROUP_CONCAT(md.id_report) AS `id_report`
        FROM tb_mail_manage_det md
        WHERE md.id_mail_manage=" + id_mail_manage + " "
        Dim id_trans As String = execute_query(query_get_id, 0, True, "", "", "", "")

        If rmt = "228" Then
            Dim query As String = "SELECT  g.id_comp_group,g.description AS `group_store`
            FROM tb_sales_pos sp 
            INNER JOIN tb_m_comp_contact cc ON cc.`id_comp_contact`= IF(sp.id_memo_type=8 OR sp.id_memo_type=9, sp.id_comp_contact_bill,sp.`id_store_contact_from`)
            INNER JOIN tb_m_comp c ON c.`id_comp`=cc.`id_comp`
            INNER JOIN tb_m_comp_group g ON g.id_comp_group = c.id_comp_group
            INNER JOIN tb_lookup_memo_type typ ON typ.`id_memo_type`=sp.`id_memo_type`
            WHERE sp.id_sales_pos IN (" + id_trans + ") 
            GROUP BY g.id_comp_group_header
            ORDER BY g.id_comp_group ASC "
            dt = execute_query(query, -1, True, "", "", "", "")
        ElseIf rmt = "230" Then
            Dim query As String = "SELECT  g.id_comp_group,g.description AS `group_store`
            FROM tb_m_comp_group g
            WHERE g.id_comp_group_header IN (" + id_trans + "); "
            dt = execute_query(query, -1, True, "", "", "", "")
        End If
        Return dt
    End Function

    Function queryInsertLog(ByVal id_user_par As String, ByVal id_status_par As String, ByVal note_par As String) As String
        If id_user_par = "0" Then
            id_user_par = "NULL"
        End If

        Dim query As String = ""
        If id_mail_manage <> "-1" Then
            query = "UPDATE tb_mail_manage SET updated_date=NOW(), updated_by=" + id_user_par + ", 
            id_mail_status=" + id_status_par + ", mail_status_note='" + addSlashes(note_par) + "' WHERE id_mail_manage='" + id_mail_manage + "'; 
            INSERT INTO tb_mail_manage_log(id_mail_manage, log_date, id_user, id_mail_status, note) VALUES 
            ('" + id_mail_manage + "', NOW()," + id_user_par + ", '" + id_status_par + "', '" + addSlashes(note_par) + "'); "
        End If
        Return query
    End Function

    Sub insertLogFollowUp(ByVal follow_up_remark As String)
        If rmt = "225" Or rmt = "226" Or rmt = "227" Then
            Dim query As String = "INSERT INTO tb_follow_up_ar(id_comp_group, due_date, follow_up, follow_up_result, follow_up_date, follow_up_input) 
            SELECT c.id_comp_group, sp.sales_pos_due_date, CONCAT(rmt.report_mark_type_name, '" + follow_up_remark + "'), '', DATE(mm.updated_date), NOW()
            FROM tb_mail_manage_det mmd
            INNER JOIN tb_mail_manage mm ON mm.id_mail_manage = mmd.id_mail_manage
            INNER JOIN tb_sales_pos sp ON sp.id_sales_pos = mmd.id_report AND sp.report_mark_type = mmd.report_mark_type
            INNER JOIN tb_m_comp_contact cc ON cc.`id_comp_contact`= IF(sp.id_memo_type=8 OR sp.id_memo_type=9, sp.id_comp_contact_bill,sp.`id_store_contact_from`)
            INNER JOIN tb_m_comp c ON c.`id_comp`=cc.`id_comp`
            INNER JOIN tb_lookup_report_mark_type rmt ON rmt.report_mark_type = mm.report_mark_type
            WHERE mmd.id_mail_manage=" + id_mail_manage + "
            GROUP BY sp.sales_pos_due_date "
            execute_non_query(query, True, "", "", "", "")
        End If
    End Sub
End Class
