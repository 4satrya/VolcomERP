Public Class ClassSampleReturnPL
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

        Dim query As String = "SELECT ret.id_sample_pl_ret, ret.sample_pl_ret_number, ret.sample_pl_ret_date, DATE_FORMAT(ret.sample_pl_ret_date,'%Y-%m-%d') AS sample_pl_datex, ret.sample_pl_ret_note,"
        query += " ret.id_wh_drawer, drw.wh_drawer_code, drw.wh_drawer, rck.id_wh_rack, loc.id_wh_locator,"
        query += " ret.id_comp_contact_to, getCompByContact(ret.id_comp_contact_to, 1) As id_comp_to, getCompByContact(ret.id_comp_contact_to, 5) As comp_to, getCompByContact(ret.id_comp_contact_to, 2) As comp_to_code, getCompByContact(ret.id_comp_contact_to, 3) As comp_to_name,"
        query += " ret.id_report_status, stt.report_status, IFNULL(SUM(sample_pl_ret_det_qty),0) AS `total` "
        query += " FROM tb_sample_pl_ret ret 
        LEFT JOIN tb_sample_pl_ret_det retd ON retd.id_sample_pl_ret = ret.id_sample_pl_ret "
        query += " INNER JOIN tb_lookup_report_status stt On ret.id_report_status = stt.id_report_status"
        query += " INNER JOIN tb_m_wh_drawer drw On drw.id_wh_drawer = ret.id_wh_drawer"
        query += " INNER JOIN tb_m_wh_rack rck On rck.id_wh_rack = drw.id_wh_rack"
        query += " INNER JOIN tb_m_wh_locator loc On loc.id_wh_locator = rck.id_wh_locator"
        query += " WHERE ret.id_sample_pl_ret>0 "
        query += condition + " "
        query += " GROUP BY ret.id_sample_pl_ret "
        query += "ORDER BY ret.id_sample_pl_ret " + order_type
        Return query
    End Function

    Public Sub completeStock(ByVal id_report_param As String, ByVal report_mark_type_param As String)
        'complete
        Dim query_compl As String = "CALL view_sample_pl_ret('" + id_report_param + "') "
        Dim dt_compl As DataTable = execute_query(query_compl, -1, True, "", "", "", "")

        Dim stc_compl As ClassStock = New ClassStock()
        For s As Integer = 0 To dt_compl.Rows.Count - 1
            stc_compl.prepInsStockSample(dt_compl.Rows(s)("id_wh_drawer").ToString, "1", dt_compl.Rows(s)("id_sample").ToString, dt_compl.Rows(s)("id_sample_price").ToString, decimalSQL(dt_compl.Rows(s)("sample_price").ToString), report_mark_type_param, id_report_param, decimalSQL(dt_compl.Rows(s)("sample_pl_det_qty").ToString), "", "1")
        Next
        stc_compl.insStockSample()
    End Sub
End Class
