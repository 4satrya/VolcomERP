Public Class ReportDesignCOPPropose
    Public Shared id_propose As String = "-1"
    Public Shared dt As DataTable
    Public Shared rmt As String = "-1"

    Private Sub ReportDesignCOPPropose_BeforePrint(sender As Object, e As Printing.PrintEventArgs) Handles MyBase.BeforePrint
        GCItemList.DataSource = dt
        BGVItemList.BestFitColumns()
        '
        Dim query As String = "SELECT copp.`number`,copp.`note`,copp.`id_report_status`,copp.`created_date`,emp.`employee_name`,typ.`cop_propose_type` FROM `tb_design_cop_propose` copp
INNER JOIN tb_m_user usr ON usr.`id_user`=copp.`created_by`
INNER JOIN tb_m_employee emp ON emp.`id_employee`=usr.`id_employee`
INNER JOIN `tb_lookup_cop_propose_type` typ ON typ.`id_cop_propose_type`=copp.`id_cop_propose_type`
WHERE id_design_cop_propose='" & id_propose & "'"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        If data.Rows.Count > 0 Then
            LNote.Text = data.Rows(0)("note").ToString
            LNumber.Text = data.Rows(0)("number").ToString
            LRequestedBy.Text = data.Rows(0)("employee_name").ToString
            LDateCreated.Text = Date.Parse(data.Rows(0)("created_date").ToString).ToString("dd MMMM yyyy")
            LType.Text = data.Rows(0)("cop_propose_type").ToString
            pre_load_mark_horz(rmt, id_propose, "2", "2", XrTable1)
        End If
    End Sub
End Class