Public Class FormReturnNote
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

    Private Sub FormReturnNote_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        DEStart.EditValue = Now
        DEUntil.EditValue = Now
    End Sub

    Private Sub BView_Click(sender As Object, e As EventArgs) Handles BView.Click
        load_view()
    End Sub

    Sub load_view()
        Dim date_start As String = Date.Parse(DEStart.EditValue.ToString).ToString("yyyy-MM-dd")
        Dim date_until As String = Date.Parse(DEUntil.EditValue.ToString).ToString("yyyy-MM-dd")

        Dim q As String = "SELECT rn.id_return_note,emp.employee_name,IF(rn.id_type=1,'WH Inbound','3PL') AS `type`,st_list.store AS store_list,rn.id_emp_driver,rn.id_inbound_awb,rn.label_number,rn.date_created,rn.number_return_note,rn.qty,rn.date_return_note
FROM `tb_return_note` rn
LEFT JOIN
(
    SELECT st.`id_return_note`,GROUP_CONCAT(DISTINCT CONCAT(c.comp_number,' - ',c.comp_name) ORDER BY c.`comp_number` ASC SEPARATOR '\n') AS store
    FROM `tb_return_note_store` st
    INNER JOIN tb_m_comp c ON c.id_comp=st.id_comp
    GROUP BY st.`id_return_note`
)st_list ON st_list.id_return_note=rn.id_return_note
INNER JOIN tb_m_user usr ON usr.id_user=rn.created_by
INNER JOIN tb_m_employee emp ON emp.id_employee=usr.id_employee
WHERE DATE(rn.`date_created`)>='" & date_start & "' AND DATE(rn.`date_created`)<='" & date_until & "'"
        Dim dt As DataTable = execute_query(q, -1, True, "", "", "", "")
        GCAwb.DataSource = dt
        GVAwb.BestFitColumns()
    End Sub

    Private Sub GVAwb_DoubleClick(sender As Object, e As EventArgs) Handles GVAwb.DoubleClick
        If GVAwb.RowCount > 0 Then
            FormReturnNoteDet.id_return_note = GVAwb.GetFocusedRowCellValue("id_return_note").ToString
            FormReturnNoteDet.ShowDialog()
        End If
    End Sub
End Class