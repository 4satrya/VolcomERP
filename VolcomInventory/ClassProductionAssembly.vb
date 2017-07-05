Public Class ClassProductionAssembly
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

        Dim query As String = "SELECT a.id_prod_ass, a.prod_ass_number, a.prod_ass_date, 
        a.id_design, d.design_code AS `code`, d.design_display_name AS `name`, SUM(b.prod_ass_det_qty) AS `total`, a.prod_ass_note, 
        a.id_report_status, rs.report_status
        FROM tb_prod_ass a
        INNER JOIN tb_prod_ass_det b ON a.id_prod_ass = b.id_prod_ass
        INNER JOIN tb_m_design d ON d.id_design = a.id_design
        INNER JOIN tb_lookup_report_status rs ON rs.id_report_status = a.id_report_status
        WHERE a.id_prod_ass>0 "
        query += condition + " "
        query += "GROUP BY a.id_prod_ass "
        query += "ORDER BY a.id_prod_ass " + order_type
        Return query
    End Function

    Public Sub removeAllComponents(ByVal id_prod_ass As String)
        Dim query As String = "DELETE tb_prod_ass_comp_det 
        FROM tb_prod_ass_comp_det 
        INNER JOIN tb_prod_ass_det ON tb_prod_ass_det.id_prod_ass_det = tb_prod_ass_comp_det.id_prod_ass_det
        WHERE tb_prod_ass_det.id_prod_ass=" + id_prod_ass + " "
        execute_non_query(query, True, "", "", "", "")
    End Sub

    Public Sub changeStatus(ByVal id_report_par As String, ByVal id_status_reportx_par As String)
        If id_status_reportx_par = "6" Then
            'cek po
            Dim query_final_ss As String = "CALL view_prod_ass_final(" + id_report_par + ")"
            Dim data_cek_po As DataTable = execute_query(query_final_ss, -1, True, "", "", "", "")
        End If

        'change report status
        Dim query As String = String.Format("UPDATE tb_prod_ass SET id_report_status='{0}' WHERE id_prod_ass ='{1}' ", id_status_reportx_par, id_report_par)
        execute_non_query(query, True, "", "", "", "")
    End Sub
End Class
