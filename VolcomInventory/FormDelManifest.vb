Public Class FormDelManifest
    Private Sub FormDelManifest_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        view_3pl()
        form_load()
    End Sub

    Private Sub FormDelManifest_Activated(sender As Object, e As EventArgs) Handles MyBase.Activated
        FormMain.show_rb(Name)
        checkFormAccess(Name)
        button_main("1", "1", "0")
    End Sub

    Private Sub FormDelManifest_Deactivate(sender As Object, e As EventArgs) Handles MyBase.Deactivate
        FormMain.hide_rb()
    End Sub

    Private Sub FormDelManifest_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Sub form_load()
        Dim query_where As String = ""

        If Not SLUE3PL.EditValue.ToString = "0" Then
            query_where = "AND m.id_comp = " + SLUE3PL.EditValue.ToString
        End If

        Dim query As String = "
            SELECT m.id_del_manifest, c.comp_name, m.number, DATE_FORMAT(m.created_date, '%d %M %Y %H:%i:%s') AS created_date, DATE_FORMAT(m.updated_date, '%d %M %Y %H:%i:%s') AS updated_date, ea.employee_name AS created_by, eb.employee_name AS updated_by, IFNULL(l.report_status, 'Draft') AS report_status
            FROM tb_del_manifest AS m
            LEFT JOIN tb_m_comp AS c ON m.id_comp = c.id_comp
            LEFT JOIN tb_m_user AS ua ON m.created_by = ua.id_user
            LEFT JOIN tb_m_employee AS ea ON ua.id_employee = ea.id_employee
            LEFT JOIN tb_m_user AS ub ON m.created_by = ub.id_user
            LEFT JOIN tb_m_employee AS eb ON ub.id_employee = eb.id_employee
            LEFT JOIN tb_lookup_report_status AS l ON m.id_report_status = l.id_report_status
            WHERE 1 " + query_where + "
            ORDER BY m.id_del_manifest DESC
        "

        GCList.DataSource = execute_query(query, -1, True, "", "", "", "")

        GVList.BestFitColumns()
    End Sub

    Sub view_3pl()
        Dim query As String = "(SELECT 0 AS id_comp, 'All 3PL' AS comp_name) UNION ALL (SELECT id_comp, comp_name AS comp_name FROM tb_m_comp WHERE id_comp_cat = 7)"

        viewSearchLookupQuery(SLUE3PL, query, "id_comp", "comp_name", "id_comp")
    End Sub

    Private Sub SBView_Click(sender As Object, e As EventArgs) Handles SBView.Click
        form_load()
    End Sub

    Private Sub GVList_DoubleClick(sender As Object, e As EventArgs) Handles GVList.DoubleClick
        FormDelManifestDet.id_del_manifest = GVList.GetFocusedRowCellValue("id_del_manifest").ToString
        FormDelManifestDet.ShowDialog()
    End Sub
End Class