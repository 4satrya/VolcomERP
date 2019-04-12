Public Class ClassItemCat
    Public Function queryMaster(ByVal condition As String, ByVal order_type As String) As String
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

        Dim query As String = "SELECT c.id_item_cat, c.id_expense_type, e.expense_type, c.item_cat, c.item_cat_en 
        FROM tb_item_cat c
        INNER JOIN tb_lookup_expense_type e ON e.id_expense_type = c.id_expense_type
        WHERE c.id_item_cat>0 "
        query += condition + " "
        query += "ORDER BY c.id_item_cat " + order_type
        Return query
    End Function

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

        Dim query As String = "SELECT ip.id_item_cat_propose, ip.number, ip.created_date, ip.note, ip.id_report_status, stt.report_status, ip.is_confirm
        FROM tb_item_cat_propose ip
        INNER JOIN tb_lookup_report_status stt ON stt.id_report_status = ip.id_report_status
        WHERE ip.id_item_cat_propose>0 "
        query += condition + " "
        query += "ORDER BY ip.id_item_cat_propose " + order_type
        Return query
    End Function

    Public Function queryMapping(ByVal condition As String, ByVal order_type As String) As String
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

        Dim query As String = "SELECT m.id_item_coa, m.id_item_cat, c.item_cat, 
        m.id_departement, d.departement, 
        m.id_coa_in, ci.acc_name AS `inv_acc`, ci.acc_description AS `inv_desc`,
        m.id_coa_out, co.acc_name AS `exp_acc`,co.acc_description AS `exp_desc`, 
        m.is_request, IF(m.is_request=1,'Yes', 'No') AS `is_request_v`, 
        m.is_expense, IF(m.is_expense=1,'Yes', 'No') AS `is_expense_v`
        FROM tb_item_coa m
        INNER JOIN tb_item_cat c ON c.id_item_cat = m.id_item_cat
        INNER JOIN  tb_m_departement d ON d.id_departement = m.id_departement
        INNER JOIN tb_a_acc co ON co.id_acc = m.id_coa_out
        LEFT JOIN tb_a_acc ci ON ci.id_acc = m.id_coa_in
        WHERE m.id_item_coa>0 "
        query += condition + " "
        query += "ORDER BY m.id_item_coa " + order_type
        Return query
    End Function

    Public Function queryMappingPropose(ByVal condition As String, ByVal order_type As String) As String
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

        Dim query As String = "SELECT cp.id_item_coa_propose, cp.number, cp.created_date, cp.note, cp.id_report_status, stt.report_status, cp.is_confirm,
        cp.acc_coa_hutang, h.acc_name AS `code_hutang`, h.acc_description AS `name_hutang`,
        cp.acc_coa_receive, r.acc_name AS `code_inv_store`, r.acc_description AS `name_inv_store`,
        cp.acc_coa_trf, t.acc_name AS `code_inv_wh`, t.acc_description AS `name_inv_wh`
        FROM tb_item_coa_propose cp
        INNER JOIN tb_lookup_report_status stt ON stt.id_report_status = cp.id_report_status
        LEFT JOIN tb_a_acc h ON h.id_acc = cp.acc_coa_hutang
        LEFT JOIN tb_a_acc r ON r.id_acc = cp.acc_coa_receive
        LEFT JOIN tb_a_acc t ON t.id_acc = cp.acc_coa_trf 
        WHERE cp.id_item_coa_propose>0 "
        query += condition + " "
        query += "ORDER BY cp.id_item_coa_propose " + order_type
        Return query
    End Function

End Class
