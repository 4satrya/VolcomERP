Public Class FormSamplePurcClose
    Dim bnew_active As String = "1"
    Dim bedit_active As String = "1"
    Dim bdel_active As String = "1"
    '
    Private Sub FormSamplePurcClose_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub FormSamplePurcClose_Deactivate(sender As Object, e As EventArgs) Handles MyBase.Deactivate
        FormMain.hide_rb()
    End Sub

    Private Sub FormSamplePurcClose_Activated(sender As Object, e As EventArgs) Handles MyBase.Activated
        FormMain.show_rb(Name)
        check_menu()
    End Sub

    Sub check_menu()
        If GVListClose.RowCount < 1 Then
            'hide all except new
            bnew_active = "1"
            bedit_active = "0"
            bdel_active = "0"
            checkFormAccess(Name)
            button_main(bnew_active, bedit_active, bdel_active)
            'noManipulating()
        Else
            'show all
            bnew_active = "1"
            bedit_active = "1"
            bdel_active = "1"
            checkFormAccess(Name)
            button_main(bnew_active, bedit_active, bdel_active)
            'noManipulating()
        End If
    End Sub

    Sub load_close(ByVal opt As String)
        Dim query As String = ""

        If opt = "1" Then 'specific date
            query = "SELECT pc.*,emp.`employee_name`,sts.`report_status` FROM tb_sample_purc_close pc
INNER JOIN tb_m_user usr ON pc.`created_by`=usr.`id_user`
INNER JOIN tb_m_employee emp ON emp.`id_employee`=usr.`id_employee`
INNER JOIN tb_lookup_report_status sts ON sts.`id_report_status`=pc.`id_report_status`
WHERE DATE(pc.date_created) >= '" & Date.Parse(DEStart.EditValue.ToString).ToString("yyyy-MM-dd") & "' AND DATE(pc.date_created) <= '" & Date.Parse(DEUntil.EditValue.ToString).ToString("yyyy-MM-dd") & "'"
        ElseIf opt = "2" Then 'show all
            query = "SELECT pc.*,emp.`employee_name`,sts.`report_status` FROM tb_sample_purc_close pc
INNER JOIN tb_m_user usr ON pc.`created_by`=usr.`id_user`
INNER JOIN tb_m_employee emp ON emp.`id_employee`=usr.`id_employee`
INNER JOIN tb_lookup_report_status sts ON sts.`id_report_status`=pc.`id_report_status`"
        End If

        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCListClose.DataSource = data
        GVListClose.BestFitColumns()
        check_menu()
    End Sub

    Private Sub BShowList_Click(sender As Object, e As EventArgs) Handles BShowList.Click
        load_close("1")
    End Sub

    Private Sub BShowAll_Click(sender As Object, e As EventArgs) Handles BShowAll.Click
        load_close("2")
    End Sub

    Private Sub FormSamplePurcClose_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        DEStart.EditValue = Now
        DEUntil.EditValue = Now
    End Sub

    Private Sub DEStart_EditValueChanged(sender As Object, e As EventArgs) Handles DEStart.EditValueChanged
        DEUntil.Properties.MinValue = DEStart.EditValue
    End Sub
End Class