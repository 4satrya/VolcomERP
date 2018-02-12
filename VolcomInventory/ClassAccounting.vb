Public Class ClassAccounting
    Public Sub generateJournalSalesDraft(ByVal id_report_par As String, rmt As String)
        Dim query As String = "CALL generate_journal_sales_draft(" + id_report_par + "," + rmt + ")"
        execute_non_query(query, True, "", "", "", "")
    End Sub

    Public Function viewJournalSalesDraft(ByVal condition As String, ByVal order_type As String) As String
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
        Dim query As String = "SELECT d.id_acc_trans_draft, d.id_comp, d.id_bill_type, c.comp_name, CONCAT(c.comp_number,' - ', c.comp_name) AS `comp`, d.id_acc, acc.acc_name, acc.acc_description, d.id_comp, d.debit, d.credit, d.id_currency, d.kurs, d.debit_valas, d.credit_valas, 
        d.acc_trans_det_note, d.report_mark_type, d.id_report, d.report_number, d.qty, d.id_acc_src, d.id_status_open
        FROM tb_a_acc_trans_draft d
        INNER JOIN tb_a_acc acc ON acc.id_acc = d.id_acc
        LEFT JOIN tb_m_comp c ON c.id_comp = d.id_comp
        WHERE d.id_acc_trans_draft>0 "
        query += condition
        query += "ORDER BY d.id_acc_trans_draft " + order_type
        Return query
    End Function

    Public Function queryViewAcc(ByVal condition As String, ByVal order_type As String) As String
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
        Dim query As String = "SELECT a.id_acc, a.acc_name, a.acc_description, a.id_acc_parent, p.acc_name AS `parent`, a.id_acc_cat, cat.acc_cat, a.id_is_det, id.is_det, a.id_status, st.`status`, a.id_comp 
        FROM tb_a_acc a 
        INNER JOIN tb_lookup_status st ON st.id_status = a.id_status
        INNER JOIN tb_lookup_is_det id ON id.id_is_det = a.id_is_det
        INNER JOIN tb_a_acc p ON p.id_acc = a.id_acc
        INNER JOIN tb_lookup_acc_cat cat ON cat.id_acc_cat = a.id_acc_cat
        WHERE a.id_acc>0 "
        query += condition
        query += "ORDER BY a.acc_name " + order_type
        Return query
    End Function
End Class