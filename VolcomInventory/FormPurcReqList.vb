Public Class FormPurcReqList
    Dim bnew_active As String = "1"
    Dim bedit_active As String = "1"
    Dim bdel_active As String = "1"

    Public step_approve As String = "1"

    Private Sub FormPurcReqList_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        load_dep()
    End Sub

    Sub load_dep()
        Dim query As String = ""
        query = "SELECT '0' AS id_departement,'ALL' AS departement 
                               UNION
                               SELECT id_departement,departement FROM tb_m_departement"

        viewSearchLookupQuery(SLEDepartement, query, "id_departement", "departement", "id_departement")
    End Sub

    Private Sub FormPurcReqList_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub BView_Click(sender As Object, e As EventArgs) Handles BView.Click
        load_req()
    End Sub

    Sub print_report()

    End Sub

    Sub check_menu()
        bnew_active = "0"
        bedit_active = "0"
        bdel_active = "0"
        checkFormAccess(Name)
        button_main(bnew_active, bedit_active, bdel_active)
    End Sub

    Sub load_req()
        Dim where_dep As String = ""
        '
        If Not SLEDepartement.EditValue.ToString() = 0 Then
            where_dep = " AND dep.id_departement='" & SLEDepartement.EditValue.ToString() & "'"
        End If
        '
        Dim query As String = ""

        If step_approve = "1" Then 'IC
            If XTCPurcReq.SelectedTabPageIndex = 0 Then 'need submit
                query = "SELECT pr.`id_purc_req`,pr.id_user_created,pr.requirement_date,sts.report_status,et.expense_type,pr.id_report_status,dep.`departement`,et.pr_report_mark_type,pr.`purc_req_number`,pr.`note`,empc.`employee_name` AS created_by,pr.`date_created`,empu.`employee_name` AS last_upd_by,pr.`date_last_upd` FROM `tb_purc_req` pr
                                INNER JOIN tb_lookup_expense_type et ON et.id_expense_type=pr.id_expense_type
                                INNER JOIN tb_m_departement dep ON dep.id_departement=pr.id_departement
                                INNER JOIN tb_m_user usrc ON usrc.`id_user`=pr.`id_user_created`
                                INNER JOIN tb_m_employee empc ON empc.`id_employee`=usrc.`id_employee`
                                INNER JOIN tb_lookup_report_status sts ON sts.id_report_status=pr.id_report_status
                                LEFT JOIN tb_m_user usru ON usru.`id_user`=pr.`id_user_last_upd`
                                LEFT JOIN tb_m_employee empu ON empu.`id_employee`=usru.`id_employee` WHERE pr.ic_approval=1 AND pr.id_expense_type='2' AND pr.is_fixed_asset='1' AND pr.id_report_status!=5 " & where_dep & " ORDER BY pr.`id_purc_req` DESC"
            Else 'history
                query = "SELECT pr.`id_purc_req`,pr.id_user_created,pr.requirement_date,sts.report_status,et.expense_type,pr.id_report_status,dep.`departement`,et.pr_report_mark_type,pr.`purc_req_number`,pr.`note`,empc.`employee_name` AS created_by,pr.`date_created`,empu.`employee_name` AS last_upd_by,pr.`date_last_upd` FROM `tb_purc_req` pr
                                INNER JOIN tb_lookup_expense_type et ON et.id_expense_type=pr.id_expense_type
                                INNER JOIN tb_m_departement dep ON dep.id_departement=pr.id_departement
                                INNER JOIN tb_m_user usrc ON usrc.`id_user`=pr.`id_user_created`
                                INNER JOIN tb_m_employee empc ON empc.`id_employee`=usrc.`id_employee`
                                INNER JOIN tb_lookup_report_status sts ON sts.id_report_status=pr.id_report_status
                                LEFT JOIN tb_m_user usru ON usru.`id_user`=pr.`id_user_last_upd`
                                LEFT JOIN tb_m_employee empu ON empu.`id_employee`=usru.`id_employee` WHERE pr.ic_approval!=1 AND pr.id_expense_type='2' AND pr.is_fixed_asset='1' AND pr.id_report_status!=5 " & where_dep & " ORDER BY pr.`id_purc_req` DESC"
            End If
        ElseIf step_approve = "2" Then 'IA
            If XTCPurcReq.SelectedTabPageIndex = 0 Then 'need submit
                query = "SELECT pr.`id_purc_req`,pr.id_user_created,pr.requirement_date,sts.report_status,et.expense_type,pr.id_report_status,dep.`departement`,et.pr_report_mark_type,pr.`purc_req_number`,pr.`note`,empc.`employee_name` AS created_by,pr.`date_created`,empu.`employee_name` AS last_upd_by,pr.`date_last_upd` FROM `tb_purc_req` pr
                                INNER JOIN tb_lookup_expense_type et ON et.id_expense_type=pr.id_expense_type
                                INNER JOIN tb_m_departement dep ON dep.id_departement=pr.id_departement
                                INNER JOIN tb_m_user usrc ON usrc.`id_user`=pr.`id_user_created`
                                INNER JOIN tb_m_employee empc ON empc.`id_employee`=usrc.`id_employee`
                                INNER JOIN tb_lookup_report_status sts ON sts.id_report_status=pr.id_report_status
                                LEFT JOIN tb_m_user usru ON usru.`id_user`=pr.`id_user_last_upd`
                                LEFT JOIN tb_m_employee empu ON empu.`id_employee`=usru.`id_employee` WHERE pr.ic_approval!=1 AND pr.ia_approval=1 AND pr.id_expense_type='2' AND pr.is_fixed_asset='1' " & where_dep & " ORDER BY pr.`id_purc_req` DESC"
            Else 'history
                query = "SELECT pr.`id_purc_req`,pr.id_user_created,pr.requirement_date,sts.report_status,et.expense_type,pr.id_report_status,dep.`departement`,et.pr_report_mark_type,pr.`purc_req_number`,pr.`note`,empc.`employee_name` AS created_by,pr.`date_created`,empu.`employee_name` AS last_upd_by,pr.`date_last_upd` FROM `tb_purc_req` pr
                                INNER JOIN tb_lookup_expense_type et ON et.id_expense_type=pr.id_expense_type
                                INNER JOIN tb_m_departement dep ON dep.id_departement=pr.id_departement
                                INNER JOIN tb_m_user usrc ON usrc.`id_user`=pr.`id_user_created`
                                INNER JOIN tb_m_employee empc ON empc.`id_employee`=usrc.`id_employee`
                                INNER JOIN tb_lookup_report_status sts ON sts.id_report_status=pr.id_report_status
                                LEFT JOIN tb_m_user usru ON usru.`id_user`=pr.`id_user_last_upd`
                                LEFT JOIN tb_m_employee empu ON empu.`id_employee`=usru.`id_employee` WHERE pr.ia_approval!=1 AND pr.id_expense_type='2' AND pr.is_fixed_asset='1' " & where_dep & " ORDER BY pr.`id_purc_req` DESC"
            End If
        End If

        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        If XTCPurcReq.SelectedTabPageIndex = 0 Then 'need submit
            GCPurcReqNeedSubmit.DataSource = data
            GVPurcReqNeedSubmit.BestFitColumns()
        Else
            GCPurcReqHistorySubmit.DataSource = data
            GVPurcReqHistorySubmit.BestFitColumns()
        End If

        check_menu()
    End Sub

    Private Sub GVPurcReqNeedSubmit_DoubleClick(sender As Object, e As EventArgs) Handles GVPurcReqNeedSubmit.DoubleClick
        If GVPurcReqNeedSubmit.RowCount > 0 Then
            FormPurcReqICApproval.step_approve = step_approve
            FormPurcReqICApproval.id_user_created = GVPurcReqNeedSubmit.GetFocusedRowCellValue("id_user_created").ToString
            FormPurcReqICApproval.id_report = GVPurcReqNeedSubmit.GetFocusedRowCellValue("id_purc_req").ToString
            FormPurcReqICApproval.ShowDialog()
        Else
            warningCustom("No purchase request on list.")
        End If
    End Sub

    Private Sub GVPurcReqHistorySubmit_DoubleClick(sender As Object, e As EventArgs) Handles GVPurcReqHistorySubmit.DoubleClick
        If GVPurcReqHistorySubmit.RowCount > 0 Then
            Cursor = Cursors.WaitCursor
            Dim report_mark_type As String = "-1"

            report_mark_type = "201"

            Dim showpopup As ClassShowPopUp = New ClassShowPopUp()
            showpopup.report_mark_type = report_mark_type
            showpopup.id_report = GVPurcReqHistorySubmit.GetFocusedRowCellValue("id_purc_req").ToString
            showpopup.show()
            Cursor = Cursors.Default
        Else
            warningCustom("No purchase request on list.")
        End If
    End Sub
End Class