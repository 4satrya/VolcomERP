﻿Public Class FormInbound3PL
    Dim bnew_active As String = "1"
    Dim bedit_active As String = "1"
    Dim bdel_active As String = "1"

    Private Sub FormProductionRec_Activated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Activated
        FormMain.show_rb(Name)
        checkFormAccess(Name)
        button_main(bnew_active, bedit_active, bdel_active)
    End Sub

    Private Sub FormProductionRec_Deactivate(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Deactivate
        FormMain.hide_rb()
    End Sub

    Sub check_menu()
        If GVAwb.RowCount < 1 Then
            'hide all except new
            bnew_active = "1"
            bedit_active = "0"
            bdel_active = "0"
            checkFormAccess(Name)
            button_main(bnew_active, bedit_active, bdel_active)
            '
        Else
            'show all
            bnew_active = "1"
            bedit_active = "1"
            bdel_active = "0"
            checkFormAccess(Name)
            button_main(bnew_active, bedit_active, bdel_active)
            '
        End If
    End Sub

    Private Sub FormInbound3PL_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        DEStart.EditValue = Now
        DEUntil.EditValue = Now
    End Sub

    Private Sub BView_Click(sender As Object, e As EventArgs) Handles BView.Click
        load_view()
    End Sub

    Sub load_view()
        Dim q As String = "SELECT awb.`id_inbound_awb`,awb.`id_comp`,c.`comp_name`,emp.`employee_name`,del.`del_type`,awb.`awb_number`,awb.`created_date`
FROM tb_inbound_awb awb
INNER JOIN tb_m_comp c ON c.`id_comp`=awb.`id_comp`
INNER JOIN tb_lookup_del_type del ON del.`id_del_type`=awb.`id_del_type`
INNER JOIN tb_m_user usr ON usr.id_user=awb.`created_by`
INNER JOIN tb_m_employee emp ON emp.`id_employee`=usr.`id_employee`"
        Dim dt As DataTable = execute_query(q, -1, True, "", "", "", "")
        GCAwb.DataSource = dt
        GVAwb.BestFitColumns()
    End Sub

    Private Sub FormInbound3PL_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub
End Class