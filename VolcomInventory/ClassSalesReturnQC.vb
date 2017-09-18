Public Class ClassSalesReturnQC
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

        Dim query As String = ""
        query += "SELECT a.id_comp_contact_to, a.id_report_status, a.id_sales_return_qc, a.id_sales_return, DATE_FORMAT(a.sales_return_qc_date, '%d %M %Y') AS sales_return_qc_date, "
        query += "a.sales_return_qc_note, a.sales_return_qc_number, "
        query += "CONCAT(c.comp_number,' - ',c.comp_name) AS store_name_from, (c.comp_number) AS store_number_from, "
        query += "CONCAT(e.comp_number,' - ',e.comp_name) AS comp_name_to, (e.comp_number) AS comp_number_to, get_custom_rmk(e.id_wh_type,49) AS `rmk`, "
        query += "f.sales_return_number, g.report_status, h.pl_category, det.`total`, "
        query += "a.last_update, getUserEmp(a.last_update_by, 1) AS last_user, ('No') AS is_select "
        query += "FROM tb_sales_return_qc a  "
        query += "INNER JOIN tb_m_comp_contact b ON a.id_store_contact_from = b.id_comp_contact "
        query += "INNER JOIN tb_m_comp c ON c.id_comp = b.id_comp "
        query += "INNER JOIN tb_m_comp_contact d ON a.id_comp_contact_to = d.id_comp_contact "
        query += "INNER JOIN tb_m_comp e ON e.id_comp = d.id_comp "
        query += "INNER JOIN tb_sales_return f ON f.id_sales_return = a.id_sales_return "
        query += "INNER JOIN tb_lookup_report_status g ON g.id_report_status = a.id_report_status "
        query += "INNER JOIN tb_lookup_pl_category h ON h.id_pl_category = a.id_pl_category "
        query += "LEFT JOIN (
        SELECT d.id_sales_return_qc, SUM(d.sales_return_qc_det_qty) AS `total` 
        FROM tb_sales_return_qc_det d
        GROUP BY d.id_sales_return_qc
        ) det ON det.id_sales_return_qc = a.id_sales_return_qc "
        query += "WHERE a.id_sales_return_qc>0 "
        query += condition + " "
        query += "ORDER BY a.id_sales_return_qc " + order_type
        Return query
    End Function

    Public Function transactionList(ByVal condition As String, ByVal order_type As String) As DataTable
        Dim query As String = "CALL view_sales_return_qc_main(""" + condition + """, " + order_type + ")"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        Return data
    End Function

    Public Sub changeStatus(ByVal id_report_par As String, ByVal id_status_reportx_par As String)
        If id_status_reportx_par = "6" Then
            ' jika complete
            Dim query_del_zero As String = ""
            Dim query_save_out As String = ""
            Dim query_save_st As String = ""
            Dim query_upd_drw As String = ""
            Dim jum_ins_c As Integer = 0

            'next update save in storage
            jum_ins_c = 0
            Dim query_ret As String = ""
            query_ret += "SELECT qc.sales_return_qc_number, (ret.id_wh_drawer) AS id_wh_drawer_origin,qc.id_wh_drawer, qc_det.design_price, qc_det.id_design_price, qc_det.id_product, "
            query_ret += "qc_det.id_sales_return_det, qc_det.id_sales_return_qc, qc_det.sales_return_qc_det_qty, dsg.design_cop "
            query_ret += "FROM tb_sales_return_qc_det qc_det "
            query_ret += "INNER JOIN tb_sales_return_qc qc ON qc.id_sales_return_qc = qc_det.id_sales_return_qc "
            query_ret += "INNER JOIN tb_m_product prod ON prod.id_product = qc_det.id_product "
            query_ret += "INNER JOIN tb_m_design dsg ON dsg.id_design = prod.id_design "
            query_ret += "INNER JOIN tb_sales_return ret ON ret.id_sales_return = qc.id_sales_return "
            query_ret += "WHERE qc.id_sales_return_qc = '" + id_report_par + "' "
            Dim data_ret As DataTable = execute_query(query_ret, -1, True, "", "", "", "")

            If data_ret.Rows.Count > 0 Then
                query_save_out = "INSERT INTO tb_storage_fg(id_wh_drawer,id_storage_category,id_product,bom_unit_price,report_mark_type,id_report,storage_product_qty,storage_product_datetime,storage_product_notes,id_stock_status) VALUES "
                query_save_st = "INSERT INTO tb_storage_fg(id_wh_drawer,id_storage_category,id_product,bom_unit_price,report_mark_type,id_report,storage_product_qty,storage_product_datetime,storage_product_notes,id_stock_status) VALUES "
            End If
            For i As Integer = 0 To (data_ret.Rows.Count - 1)
                If data_ret.Rows(i)("sales_return_qc_det_qty") > 0.0 Then
                    If jum_ins_c > 0 Then
                        query_save_out += ", "
                        query_save_st += ", "
                    End If
                    query_save_out += "('" & data_ret.Rows(i)("id_wh_drawer_origin").ToString & "','2','" & data_ret.Rows(i)("id_product").ToString & "','" & decimalSQL(data_ret.Rows(i)("design_cop").ToString) & "','49','" & id_report_par & "','" & decimalSQL(data_ret.Rows(i)("sales_return_qc_det_qty").ToString) & "',NOW(),'Out for Return QC Process : " & data_ret.Rows(i)("sales_return_qc_number").ToString & "','1') "
                    query_save_st += "('" & data_ret.Rows(i)("id_wh_drawer").ToString & "','1','" & data_ret.Rows(i)("id_product").ToString & "','" & decimalSQL(data_ret.Rows(i)("design_cop").ToString) & "','49','" & id_report_par & "','" & decimalSQL(data_ret.Rows(i)("sales_return_qc_det_qty").ToString) & "',NOW(),'Completed, Return QC : " & data_ret.Rows(i)("sales_return_qc_number").ToString & "','1') "
                    jum_ins_c = jum_ins_c + 1
                End If
            Next
            If jum_ins_c > 0 Then
                execute_non_query(query_save_out, True, "", "", "", "")
                execute_non_query(query_save_st, True, "", "", "", "")
            End If
        End If

        Dim query As String = String.Format("UPDATE tb_sales_return_qc SET id_report_status='{0}', last_update = NOW(), last_update_by=" + id_user + " WHERE id_sales_return_qc ='{1}'", id_status_reportx_par, id_report_par)
        execute_non_query(query, True, "", "", "", "")
    End Sub

End Class
