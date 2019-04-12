Public Class FormReportMarkCancelList
    Dim bnew_active As String = "1"
    Dim bedit_active As String = "1"
    Dim bdel_active As String = "1"
    '
    Public is_purc_dep As String = "-1"
    Public is_admin As String = "1"
    '
    Private Sub FormReportMarkCancelList_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub FormReportMarkCancelList_Deactivate(sender As Object, e As EventArgs) Handles MyBase.Deactivate
        FormMain.hide_rb()
    End Sub

    Private Sub FormReportMarkCancelList_Activated(sender As Object, e As EventArgs) Handles MyBase.Activated
        FormMain.show_rb(Name)
        check_menu()
    End Sub

    Sub check_menu()
        If Not is_admin = "1" Then
            bnew_active = "1"
            bedit_active = "1"
            bdel_active = "0"
        Else
            If GVListCancel.RowCount > 0 Then
                bnew_active = "1"
                bedit_active = "1"
                bdel_active = "0"
            Else
                bnew_active = "1"
                bedit_active = "0"
                bdel_active = "0"
            End If
        End If

        checkFormAccess(Name)
        button_main(bnew_active, bedit_active, bdel_active)
    End Sub

    Private Sub FormReportMarkCancelList_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        load_dep()
        If Not is_admin = "1" Then
            PCDepartement.Visible = False
        End If
        load_cancel_form()
    End Sub

    Sub load_cancel_form()
        Dim query_cancel As String = ""
        Dim dep As String = ""

        If is_admin = "1" Then
            If SLEDepartement.EditValue.ToString = "0" Then
                dep = "%%"
            Else
                dep = SLEDepartement.EditValue.ToString
            End If
        Else
            dep = id_departement_user
        End If

        query_cancel = "SELECT rmc.*,emp.`employee_name`,rmt.report_mark_type_name,emp_comp.employee_name AS name_complete FROM `tb_report_mark_cancel` rmc
                        INNER JOIN tb_m_user usr ON usr.`id_user`=rmc.`created_by`
                        INNER JOIN tb_m_employee emp ON emp.`id_employee`=usr.`id_employee`
                        LEFT JOIN tb_m_user usr_comp ON usr_comp.`id_user`=rmc.`user_complete`
                        LEFT JOIN tb_m_employee emp_comp ON emp_comp.`id_employee`=usr_comp.`id_employee`
                        INNER JOIN tb_lookup_report_mark_type rmt ON rmt.report_mark_type=rmc.report_mark_type
                        WHERE emp.`id_departement` LIKE '" & dep & "'"

        If Not is_admin = "1" Then
            query_cancel += " AND rmc.created_by='" & id_user & "'"
        End If

        Dim data_cancel As DataTable = execute_query(query_cancel, -1, True, "", "", "", "")
        GCListCancel.DataSource = data_cancel
        GVListCancel.BestFitColumns()
        '
        check_menu()
    End Sub

    Sub load_dep()
        Dim query_dep As String = "SELECT 0 AS id_departement,'All Departement' as departement 
                                   UNION
                                   SELECT id_departement,departement FROM tb_m_departement"
        viewSearchLookupQuery(SLEDepartement, query_dep, "id_departement", "departement", "id_departement")
    End Sub

    Private Sub BViewReqList_Click(sender As Object, e As EventArgs) Handles BViewReqList.Click
        load_cancel_form()
    End Sub
End Class