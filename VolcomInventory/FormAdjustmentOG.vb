Public Class FormAdjustmentOG
    Private Sub FormAdjustmentOG_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        form_load()
    End Sub

    Private Sub FormAdjustmentOG_Activated(sender As Object, e As EventArgs) Handles MyBase.Activated
        FormMain.show_rb(Name)
        checkFormAccess(Name)
    End Sub

    Private Sub FormAdjustmentOG_Deactivate(sender As Object, e As EventArgs) Handles MyBase.Deactivate
        FormMain.hide_rb()
    End Sub

    Private Sub FormAdjustmentOG_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Sub form_load()
        Dim query As String = "
            SELECT a.id_adjustment, IF(a.id_type = 1, 'Adjustment In', IF(a.id_type = 2, 'Adjustment Out', 'Transfer')) AS `type`, IF(a.id_departement_from = 0, 'Purchasing Storage', df.departement) AS departement_from, IF(a.id_departement_to = 0, 'Purchasing Storage', dt.departement) AS departement_to, a.number, DATE_FORMAT(a.created_at, '%d %M %Y %H:%i:%s') AS created_at, e.employee_name AS created_by, r.report_status
            FROM tb_adjustment_og AS a
            LEFT JOIN tb_m_departement AS df ON a.id_departement_from = df.id_departement
            LEFT JOIN tb_m_departement AS dt ON a.id_departement_to = dt.id_departement
            LEFT JOIN tb_m_employee AS e ON a.created_by = e.id_employee
            LEFT JOIN tb_lookup_report_status AS r ON a.id_report_status = r.id_report_status
            ORDER BY a.id_adjustment DESC
        "

        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")

        GCList.DataSource = data

        GVList.BestFitColumns()
    End Sub

    Private Sub GVList_DoubleClick(sender As Object, e As EventArgs) Handles GVList.DoubleClick
        FormMain.but_edit()
    End Sub
End Class