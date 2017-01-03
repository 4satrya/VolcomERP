Public Class FormMatPL
    Dim bnew_active As String = "1"
    Dim bedit_active As String = "1"
    Dim bdel_active As String = "1"

    Private Sub FormMatPL_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Cursor = Cursors.WaitCursor
        Try

            viewPL()
            viewStatusMRS()

            viewPLOther()
            view_mrs_other()
            viewPLWO()
            view_mrs_mat_wo()
            '
            check_but()
        Catch ex As Exception
            errorConnection()
        End Try
        Cursor = Cursors.Default
    End Sub
    Sub viewStatusMRS()
        Dim query As String = "SELECT '0' as id_statusmrs, 'All' as status_mrs 
                                UNION
                              SELECT '1' as id_statusmrs, 'Already Created' as status_mrs 
                                UNION
                              SELECT '2' as id_statusmrs, 'Not yet created' as status_mrs"
        viewSearchLookupQuery(SLESeason, query, "id_statusmrs", "status_mrs", "id_statusmrs")
    End Sub
    Private Sub FormMatPL_Activated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Activated
        FormMain.show_rb(Name)
        checkFormAccess(Name)
        button_main(bnew_active, bedit_active, bdel_active)
    End Sub

    Private Sub FormMatPL_Deactivate(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Deactivate
        FormMain.hide_rb()
    End Sub

    Sub viewPL()
        Dim query As String = "SELECT a.id_pl_mrs ,m.design_name,m.design_display_name,k.prod_order_number,a.id_comp_contact_from , a.id_comp_contact_to, a.pl_mrs_note, a.pl_mrs_number, "
        query += "(d.comp_name) AS comp_name_from, (f.comp_name) AS comp_name_to, h.report_status, a.id_report_status,j.prod_order_wo_number,i.prod_order_mrs_number, "
        query += "a.pl_mrs_date, a.id_report_status FROM tb_pl_mrs a "
        query += "INNER JOIN tb_m_comp_contact c ON a.id_comp_contact_from = c.id_comp_contact "
        query += "INNER JOIN tb_m_comp d ON c.id_comp = d.id_comp "
        query += "INNER JOIN tb_m_comp_contact e ON a.id_comp_contact_to = e.id_comp_contact "
        query += "INNER JOIN tb_m_comp f ON e.id_comp = f.id_comp "
        query += "INNER JOIN tb_lookup_report_status h ON h.id_report_status = a.id_report_status "
        query += "INNER JOIN tb_prod_order_mrs i ON a.id_prod_order_mrs = i.id_prod_order_mrs "
        query += "INNER JOIN tb_prod_order k ON i.id_prod_order = k.id_prod_order "
        query += "LEFT JOIN tb_prod_order_wo j ON i.id_prod_order_wo = j.id_prod_order_wo "
        query += "INNER JOIN tb_prod_demand_design l ON k.id_prod_demand_design = l.id_prod_demand_design "
        query += "INNER JOIN tb_m_design m ON m.id_design = l.id_design "
        query += "WHERE NOT ISNULL(i.id_prod_order) "
        query += "ORDER BY a.id_pl_mrs DESC "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCProdPL.DataSource = data
    End Sub
    Sub viewPLOther()
        Dim query As String = "SELECT a.id_pl_mrs ,a.id_comp_contact_from , a.id_comp_contact_to, a.pl_mrs_note, a.pl_mrs_number, "
        query += "(d.comp_name) AS comp_name_from, (f.comp_name) AS comp_name_to, h.report_status, a.id_report_status,i.prod_order_mrs_number, "
        query += "a.pl_mrs_date, a.id_report_status FROM tb_pl_mrs a "
        query += "INNER JOIN tb_m_comp_contact c ON a.id_comp_contact_from = c.id_comp_contact "
        query += "INNER JOIN tb_m_comp d ON c.id_comp = d.id_comp "
        query += "INNER JOIN tb_m_comp_contact e ON a.id_comp_contact_to = e.id_comp_contact "
        query += "INNER JOIN tb_m_comp f ON e.id_comp = f.id_comp "
        query += "INNER JOIN tb_lookup_report_status h ON h.id_report_status = a.id_report_status "
        query += "INNER JOIN tb_prod_order_mrs i ON a.id_prod_order_mrs = i.id_prod_order_mrs "
        query += "WHERE ISNULL(i.id_prod_order) AND i.mrs_type='1' "
        query += "ORDER BY a.id_pl_mrs DESC "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCPLOther.DataSource = data
    End Sub
    Sub viewPLWO()
        Dim query As String = "SELECT a.id_pl_mrs ,wo.mat_wo_number,a.id_comp_contact_from , a.id_comp_contact_to, a.pl_mrs_note, a.pl_mrs_number, "
        query += "(d.comp_name) AS comp_name_from, (f.comp_name) AS comp_name_to, h.report_status, a.id_report_status,i.prod_order_mrs_number, "
        query += "a.pl_mrs_date, a.id_report_status FROM tb_pl_mrs a "
        query += "INNER JOIN tb_m_comp_contact c ON a.id_comp_contact_from = c.id_comp_contact "
        query += "INNER JOIN tb_m_comp d ON c.id_comp = d.id_comp "
        query += "INNER JOIN tb_m_comp_contact e ON a.id_comp_contact_to = e.id_comp_contact "
        query += "INNER JOIN tb_m_comp f ON e.id_comp = f.id_comp "
        query += "INNER JOIN tb_lookup_report_status h ON h.id_report_status = a.id_report_status "
        query += "INNER JOIN tb_prod_order_mrs i ON a.id_prod_order_mrs = i.id_prod_order_mrs "
        query += "LEFT JOIN tb_mat_wo wo ON wo.id_mat_wo = i.id_mat_wo "
        query += "WHERE i.mrs_type='2' "
        query += "ORDER BY a.id_pl_mrs DESC "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCPLWO.DataSource = data
    End Sub
    Sub viewMRS()
        Dim status_mrs As String = SLESeason.EditValue.ToString
        Dim query_status As String = ""
        If status_mrs = "0" Then
            '
        ElseIf status_mrs = "1" Then
            query_status = "AND IFNULL(jum_pl.jum_pl,0)>0 "
        ElseIf status_mrs = "2" Then
            query_status = "AND IFNULL(jum_pl.jum_pl,0)<=0 "
        End If

        Dim query = "SELECT a.id_prod_order_mrs,m.design_name,m.design_display_name,k.prod_order_number,a.prod_order_mrs_number,a.id_report_status,h.report_status,a.id_prod_order_wo,b.prod_order_wo_number, 
                    d.comp_name AS comp_name_req_from,c.id_comp_contact AS id_comp_name_req_from, 
                    f.comp_name AS comp_name_req_to,e.id_comp_contact AS id_comp_name_req_to, 
                    a.prod_order_mrs_date 
                    ,IF(IFNULL(jum_pl.jum_pl,0)>0,'yes','no') AS pl_created,IFNULL(jum_pl.jum_pl,0) AS jum_pl
                    FROM tb_prod_order_mrs a 
                    LEFT JOIN tb_prod_order_wo b ON a.id_prod_order_wo = b.id_prod_order_wo 
                    INNER JOIN tb_m_comp_contact c ON a.id_comp_contact_req_from = c.id_comp_contact 
                    INNER JOIN tb_m_comp d ON c.id_comp = d.id_comp 
                    INNER JOIN tb_m_comp_contact e ON a.id_comp_contact_req_to = e.id_comp_contact 
                    INNER JOIN tb_m_comp f ON e.id_comp = f.id_comp 
                    INNER JOIN tb_lookup_report_status h ON h.id_report_status = a.id_report_status 
                    INNER JOIN tb_prod_order k ON a.id_prod_order = k.id_prod_order 
                    INNER JOIN tb_prod_demand_design l ON k.id_prod_demand_design = l.id_prod_demand_design 
                    INNER JOIN tb_m_design m ON m.id_design = l.id_design 
                    LEFT JOIN 
                    (
	                    SELECT COUNT(id_pl_mrs) AS jum_pl,id_prod_order_mrs FROM tb_pl_mrs WHERE id_report_status!=5 GROUP BY id_prod_order_mrs
                    ) AS jum_pl ON jum_pl.id_prod_order_mrs=a.id_prod_order_mrs
                    WHERE (a.id_report_status = '3' OR a.id_report_status='4')  " & query_status & " AND NOT ISNULL(a.id_prod_order)"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCMRS.DataSource = data
    End Sub
    Sub view_mrs_other()
        Dim query = "SELECT a.id_prod_order_mrs,a.prod_order_mrs_number,a.id_report_status,h.report_status,a.id_prod_order_wo,b.prod_order_wo_number, "
        query += "d.comp_name AS comp_name_req_from,c.id_comp_contact AS id_comp_name_req_from, "
        query += "f.comp_name AS comp_name_req_to,e.id_comp_contact AS id_comp_name_req_to, "
        query += "a.prod_order_mrs_date "
        query += "FROM tb_prod_order_mrs a "
        query += "LEFT JOIN tb_prod_order_wo b ON a.id_prod_order_wo = b.id_prod_order_wo "
        query += "INNER JOIN tb_m_comp_contact c ON a.id_comp_contact_req_from = c.id_comp_contact "
        query += "INNER JOIN tb_m_comp d ON c.id_comp = d.id_comp "
        query += "INNER JOIN tb_m_comp_contact e ON a.id_comp_contact_req_to = e.id_comp_contact "
        query += "INNER JOIN tb_m_comp f ON e.id_comp = f.id_comp "
        query += "INNER JOIN tb_lookup_report_status h ON h.id_report_status = a.id_report_status "
        query += "WHERE (a.id_report_status = '3' OR a.id_report_status='4') AND ISNULL(a.id_prod_order) AND a.mrs_type='1'"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCMRSOther.DataSource = data
    End Sub
    Sub view_mrs_mat_wo()
        Dim query = "SELECT a.id_prod_order_mrs,a.prod_order_mrs_number,a.id_report_status,h.report_status,a.id_prod_order_wo,b.mat_wo_number, "
        query += "d.comp_name AS comp_name_req_from,c.id_comp_contact AS id_comp_name_req_from, "
        query += "f.comp_name AS comp_name_req_to,e.id_comp_contact AS id_comp_name_req_to, "
        query += "a.prod_order_mrs_date "
        query += "FROM tb_prod_order_mrs a "
        query += "LEFT JOIN tb_mat_wo b ON a.id_mat_wo = b.id_mat_wo "
        query += "INNER JOIN tb_m_comp_contact c ON a.id_comp_contact_req_from = c.id_comp_contact "
        query += "INNER JOIN tb_m_comp d ON c.id_comp = d.id_comp "
        query += "INNER JOIN tb_m_comp_contact e ON a.id_comp_contact_req_to = e.id_comp_contact "
        query += "INNER JOIN tb_m_comp f ON e.id_comp = f.id_comp "
        query += "INNER JOIN tb_lookup_report_status h ON h.id_report_status = a.id_report_status "
        query += "WHERE (a.id_report_status = '3' OR a.id_report_status='4') AND a.mrs_type='2'"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCMRSwo.DataSource = data
    End Sub
    Sub check_but()
        If XTCPL.SelectedTabPageIndex = 0 Then
            If XTCTabProduction.SelectedTabPageIndex = 0 Then 'list all pl prod
                If GVProdPL.RowCount > 0 Then
                    bnew_active = "1"
                    bedit_active = "1"
                    bdel_active = "1"
                Else
                    bnew_active = "1"
                    bedit_active = "0"
                    bdel_active = "0"
                End If
            ElseIf XTCTabProduction.SelectedTabPageIndex = 1 Then 'list mrs pl prod
                If GVMRS.RowCount > 0 Then
                    bnew_active = "1"
                    bedit_active = "0"
                    bdel_active = "0"
                Else
                    bnew_active = "0"
                    bedit_active = "0"
                    bdel_active = "0"
                End If
            End If
        ElseIf XTCPL.SelectedTabPageIndex = 1 Then
            If XTCPLWO.SelectedTabPageIndex = 0 Then 'list pl wo
                If GVPLWO.RowCount > 0 Then
                    bnew_active = "1"
                    bedit_active = "1"
                    bdel_active = "1"
                Else
                    bnew_active = "1"
                    bedit_active = "0"
                    bdel_active = "0"
                End If
            ElseIf XTCPLWO.SelectedTabPageIndex = 1 Then 'list wo
                If GVMRSWO.RowCount > 0 Then
                    bnew_active = "1"
                    bedit_active = "0"
                    bdel_active = "0"
                Else
                    bnew_active = "0"
                    bedit_active = "0"
                    bdel_active = "0"
                End If
            End If
        ElseIf XTCPL.SelectedTabPageIndex = 2 Then
            If XTCPLOther.SelectedTabPageIndex = 0 Then 'list pl other
                If GVPLOther.RowCount > 0 Then
                    bnew_active = "1"
                    bedit_active = "1"
                    bdel_active = "1"
                Else
                    bnew_active = "1"
                    bedit_active = "0"
                    bdel_active = "0"
                End If
            ElseIf XTCPLOther.SelectedTabPageIndex = 1 Then 'list mrs other
                If GVMRSOther.RowCount > 0 Then
                    bnew_active = "1"
                    bedit_active = "0"
                    bdel_active = "0"
                Else
                    bnew_active = "0"
                    bedit_active = "0"
                    bdel_active = "0"
                End If
            End If
        End If
        checkFormAccess(Name)
        button_main(bnew_active, bedit_active, bdel_active)
    End Sub

    Private Sub XTCPL_SelectedPageChanged(ByVal sender As System.Object, ByVal e As DevExpress.XtraTab.TabPageChangedEventArgs) Handles XTCPL.SelectedPageChanged
        check_but()
    End Sub

    Private Sub XTCTabProduction_SelectedPageChanged(ByVal sender As System.Object, ByVal e As DevExpress.XtraTab.TabPageChangedEventArgs) Handles XTCTabProduction.SelectedPageChanged
        check_but()
    End Sub

    Private Sub XTCPLOther_SelectedPageChanged(ByVal sender As System.Object, ByVal e As DevExpress.XtraTab.TabPageChangedEventArgs) Handles XTCPLOther.SelectedPageChanged
        check_but()
    End Sub

    Private Sub XTCPLWO_SelectedPageChanged(ByVal sender As System.Object, ByVal e As DevExpress.XtraTab.TabPageChangedEventArgs) Handles XTCPLWO.SelectedPageChanged
        check_but()
    End Sub

    Private Sub BtnView_Click(sender As Object, e As EventArgs) Handles BtnView.Click
        viewMRS()
    End Sub
End Class