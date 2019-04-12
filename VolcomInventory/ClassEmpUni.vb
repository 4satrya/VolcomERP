Public Class ClassEmpUni
    Public is_public_form As Boolean = False

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

        Dim query As String = "SELECT u.id_emp_uni_period, u.period_name, u.selection_date_start, u.selection_date_start, u.selection_date_end, u.created_date, u.distribution_date, u.tolerance, u.budget_point, u.id_status,stt.status
        FROM tb_emp_uni_period u
        INNER JOIN tb_lookup_status stt ON stt.id_status = u.id_status
        WHERE u.id_emp_uni_period>0 "
        query += condition + " "
        query += "GROUP BY u.id_emp_uni_period  "
        query += "ORDER BY u.id_emp_uni_period " + order_type
        Return query
    End Function

    Public Function queryMainOrder(ByVal condition As String, ByVal order_type As String, ByVal except_id As String) As String
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

        Dim query As String = "SELECT so.id_sales_order, so.sales_order_number, so.sales_order_date, so.sales_order_note, SUM(IFNULL(sod.sales_order_det_qty,0)) AS `total_order`, SUM(IFNULL(udd.point,0)) AS `amount`,
        so.id_emp_uni_budget, b.id_emp_uni_period, p.period_name, (b.budget/p.budget_point)*100 AS `budget`, so.tolerance, so.discount,
        b.id_employee, e.employee_code, e.employee_name, e.employee_position, e.id_employee_level, lvl.employee_level, e.id_departement, d.departement, e.id_sex,
        so.id_report_status, rs.report_status, so.sales_order_note, so.sales_order_date, eu.employee_name AS `prepared_by`, c.id_drawer_def, IFNULL(so.is_selected,2) AS is_selected, b.is_dept_head
        FROM tb_sales_order so
        LEFT JOIN tb_sales_order_det sod ON sod.id_sales_order = so.id_sales_order
        LEFT JOIN tb_m_product prod ON prod.id_product = sod.id_product
        LEFT JOIN tb_m_design dsg ON dsg.id_design = prod.id_design
        INNER JOIN tb_emp_uni_budget b on b.id_emp_uni_budget = so.id_emp_uni_budget
        INNER JOIN tb_m_employee e ON e.id_employee = b.id_employee
        LEFT JOIN tb_lookup_employee_level lvl ON lvl.id_employee_level = e.id_employee_level
        INNER JOIN tb_lookup_report_status rs ON rs.id_report_status = so.id_report_status
        INNER JOIN tb_m_departement d ON d.id_departement = e.id_departement
        INNER JOIN tb_emp_uni_period p ON p.id_emp_uni_period = b.id_emp_uni_period
        LEFT JOIN tb_emp_uni_design ud ON ud.id_emp_uni_period = p.id_emp_uni_period AND ud.id_report_status=6
        LEFT JOIN tb_emp_uni_design_det udd ON udd.id_emp_uni_design = ud.id_emp_uni_design AND udd.id_design = dsg.id_design
        INNER JOIN tb_m_user u ON u.id_user = so.id_user_created
        INNER JOIN tb_m_employee eu ON eu.id_employee = u.id_employee
        INNER JOIN tb_m_comp_contact cc ON cc.id_comp_contact = so.id_warehouse_contact_to
        INNER JOIN tb_m_comp c ON c.id_comp = cc.id_comp
        WHERE so.id_sales_order>0 "
        query += condition + " "
        query += "GROUP BY so.id_sales_order "
        query += "ORDER BY so.id_sales_order " + order_type
        Return query
    End Function


    Public Function queryMainList(ByVal condition As String, ByVal order_type As String) As String
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

        Dim query As String = "SELECT d.id_emp_uni_design, d.id_emp_uni_period, pr.period_name, d.id_wh_drawer, d.note, d.created_date, d.id_report_status, rs.report_status, d.is_dept_head
        FROM tb_emp_uni_design d
        INNER JOIN tb_emp_uni_period pr ON pr.id_emp_uni_period = d.id_emp_uni_period
        INNER JOIN tb_lookup_report_status rs ON rs.id_report_status = d.id_report_status
        WHERE d.id_emp_uni_design>0 "
        query += condition + " "
        query += "GROUP BY d.id_emp_uni_design  "
        query += "ORDER BY d.id_emp_uni_design " + order_type
        Return query
    End Function

    Sub nonaktifPeriod()
        Dim query As String = "UPDATE tb_emp_uni_period SET id_status=2 "
        execute_non_query(query, True, "", "", "", "")
    End Sub

    Sub openOrderDetail(ByVal id_period As String, ByVal id_budget As String, ByVal id_order As String, ByVal id_department As String)
        Dim id_emp_uni_budget As String = id_budget
        'Dim qorder As String = "SELECT * FROM tb_sales_order WHERE id_emp_uni_period=" + id_period + " AND id_emp_uni_budget=" + id_budget + " AND id_report_status!=5 "
        'Dim dorder As DataTable = execute_query(qorder, -1, True, "", "", "", "")
        If id_order <> "0" Then 'sudah ada order
            FormEmpUniOrderDet.id_sales_order = id_order
            FormEmpUniOrderDet.is_public_form = is_public_form
            FormEmpUniOrderDet.ShowDialog()
        Else 'blm ada
            'batasi waktu
            If is_public_form Then
                Dim valid As String = execute_query("SELECT is_selection_time(" + id_period + ", " + id_department + ")", 0, True, "", "", "", "")
                If valid = "2" Then
                    stopCustom("Maaf, saat ini belum waktunya memilih uniform")
                    Exit Sub
                End If
            End If

            'get destination
            Dim id_dept As String = id_department
            Dim id_store_contact_to As String = "-1"
            Try
                id_store_contact_to = execute_query("SELECT cc.id_comp_contact FROM tb_m_departement d 
                INNER JOIN tb_m_comp c ON c.id_comp = d.id_comp_promo
                INNER JOIN tb_m_comp_contact cc ON cc.id_comp = c.id_comp AND cc.is_default=1
                WHERE d.id_departement=" + id_dept + " ", 0, True, "", "", "", "")
            Catch ex As Exception
            End Try

            'get from
            Dim id_warehouse_contact_to = "-1"
            Try
                id_warehouse_contact_to = execute_query("SELECT cc.id_comp_contact 
                    FROM tb_emp_uni_design l 
                    INNER JOIN tb_m_comp c ON c.id_drawer_def = l.id_wh_drawer
                    INNER JOIN tb_m_comp_contact cc ON cc.id_comp = c.id_comp AND cc.is_default=1
                    WHERE l.id_emp_uni_period=" + id_period + " AND l.id_report_status=6
                    GROUP BY l.id_emp_uni_period", 0, True, "", "", "", "")
            Catch ex As Exception
            End Try

            'get id_emp_uni_budget
            Dim tolerance As String = decimalSQL("0")

            'get discount
            Dim discount As Decimal = 0

            'check
            If id_store_contact_to = "-1" Then
                stopCustom("Destination account is not found")
            ElseIf id_warehouse_contact_to = "-1" Then
                stopCustom("WH account is not found")
            Else
                Dim query As String = "INSERT INTO tb_sales_order(id_store_contact_to, id_warehouse_contact_to, sales_order_number, sales_order_date, sales_order_note, id_so_type, id_report_status, id_so_status, id_user_created, id_emp_uni_period, id_emp_uni_budget, tolerance, discount, is_selected) "
                query += "VALUES('" + id_store_contact_to + "', '" + id_warehouse_contact_to + "', '', NOW(), '', '0', '1', '7', '" + id_user + "','" + id_period + "'," + id_emp_uni_budget + ",'" + tolerance + "','" + decimalSQL(discount.ToString) + "', '2'); SELECT LAST_INSERT_ID(); "
                Dim id_new As String = execute_query(query, 0, True, "", "", "", "")

                'submit_who_prepared("39", id_new, id_user)
                FormEmpUniOrderDet.is_public_form = is_public_form
                FormEmpUniOrderDet.id_sales_order = id_new
                FormEmpUniOrderDet.ShowDialog()
            End If
        End If
    End Sub

    Sub openUniformPublic(ByVal id_period_selected As String)
        Dim query As String = "SELECT p.id_emp_uni_period, b.id_emp_uni_budget, IFNULL(so.id_sales_order,0) AS `id_order`
        FROM tb_emp_uni_period p 
        LEFT JOIN tb_emp_uni_budget b ON b.id_emp_uni_period = p.id_emp_uni_period AND b.id_employee=" + id_employee_user + "
        LEFT JOIN tb_m_employee e ON e.id_employee = b.id_employee
        LEFT JOIN tb_sales_order so ON so.id_emp_uni_budget = b.id_emp_uni_budget AND so.id_emp_uni_period = p.id_emp_uni_period
        WHERE p.id_status=1 AND p.id_emp_uni_period='" + id_period_selected + "'  "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        Dim id_periode As String = "-1"
        Try
            id_periode = data.Rows(0)("id_emp_uni_period").ToString
        Catch ex As Exception
        End Try
        If id_periode = "" Then
            id_periode = "-1"
        End If
        Dim valid As String = execute_query("SELECT is_selection_time(" + id_periode + ", " + id_departement_user + ")", 0, True, "", "", "", "")
        If data.Rows.Count > 0 And valid = "1" Then
            is_public_form = True
            openOrderDetail(id_periode, data.Rows(0)("id_emp_uni_budget").ToString, data.Rows(0)("id_order").ToString, id_departement_user)
        Else
            stopCustom("Periode uniform belum dimulai")
        End If
    End Sub
End Class
