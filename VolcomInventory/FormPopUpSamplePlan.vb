Public Class FormPopUpSamplePlan
    Public id_sample_plan As String = "-1"

    Private Sub BCancel_Click(sender As Object, e As EventArgs) Handles BCancel.Click
        Close()
    End Sub

    Private Sub FormPopUpSamplePlan_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub BSave_Click(sender As Object, e As EventArgs) Handles BSave.Click
        If GVSamplePrePO.RowCount > 0 Then
            FormSamplePurchaseDet.TEProfPO.Text = GVSamplePrePO.GetFocusedRowCellValue("sample_plan_number").ToString
            FormSamplePurchaseDet.id_sample_plan = GVSamplePrePO.GetFocusedRowCellValue("id_sample_plan").ToString
            Close()
        Else
            stopCustom("Please select Sample Proforma PO first.")
        End If

    End Sub

    Private Sub FormPopUpSamplePlan_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        view_sample_plan()
        If id_sample_plan <> "-1" Then
            GVSamplePrePO.FocusedRowHandle = find_row(GVSamplePrePO, "id_sample_plan", id_sample_plan)
        End If
    End Sub
    Sub view_sample_plan()
        Dim query As String = "SELECT a.id_sample_plan,a.sample_plan_number,a.sample_plan_note,a.id_comp_contact_to,d.comp_name AS comp_name_to,a.id_season_orign,b.season_orign,a.sample_plan_date,DATE_FORMAT(a.sample_plan_date,'%d %M %Y') AS date_view,a.id_report_status,e.report_status "
        query += "FROM tb_sample_plan a INNER JOIN tb_season_orign b ON a.id_season_orign=b.id_season_orign "
        query += "INNER JOIN tb_m_comp_contact c ON c.id_comp_contact=a.id_comp_contact_to "
        query += "INNER JOIN tb_m_comp d ON c.id_comp = d.id_comp "
        query += "INNER JOIN tb_lookup_report_status e ON e.id_report_status = a.id_report_status "

        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCSamplePrePO.DataSource = data
    End Sub
End Class