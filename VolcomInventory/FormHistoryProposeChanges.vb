Public Class FormHistoryProposeChanges
    Public id_design As String = "-1"
    Public id_pop_up As String = "-1"
    Public form_name As String = ""

    Private Sub FormHistoryProposeChanges_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim report_mark_type As String = ""

        If id_pop_up = "-1" Then
            report_mark_type = "177"
        ElseIf id_pop_up = "3" Then
            report_mark_type = "178"
        ElseIf id_pop_up = "5" Then
            report_mark_type = "176"
        End If

        Dim query As String = "SELECT dr.*, e.employee_name AS created_byx, DATE_FORMAT(dr.created_at, '%d %M %Y %h:%i %p') AS created_atx, rs.report_status FROM tb_m_design_rev AS dr LEFT JOIN tb_m_employee AS e ON dr.created_by = e.id_employee LEFT JOIN tb_lookup_report_status AS rs ON dr.id_report_status = rs.id_report_status WHERE dr.id_report_status <> '1' AND dr.id_design = '" + id_design + "' AND dr.report_mark_type = '" + report_mark_type + "' ORDER BY dr.created_at DESC"

        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")

        GCList.DataSource = data
    End Sub

    Private Sub GVList_DoubleClick(sender As Object, e As EventArgs) Handles GVList.DoubleClick
        FormMasterDesignSingle.id_pop_up = id_pop_up
        FormMasterDesignSingle.form_name = form_name
        FormMasterDesignSingle.id_design = id_design
        FormMasterDesignSingle.WindowState = FormWindowState.Maximized
        FormMasterDesignSingle.is_propose_changes = True
        FormMasterDesignSingle.id_propose_changes = GVList.GetFocusedRowCellValue("id_design_rev").ToString

        FormMasterDesignSingle.ShowDialog()
    End Sub
End Class