Public Class FormSalesReturnOrderMail
    Private Sub FormSalesReturnOrderMail_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        form_load()
    End Sub

    Private Sub FormSalesReturnOrderMail_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub GVDetail_DoubleClick(sender As Object, e As EventArgs) Handles GVDetail.DoubleClick
        FormSalesReturnOrderMailDet.id_mail_3pl = GVDetail.GetFocusedRowCellValue("id_mail_3pl").ToString
        FormSalesReturnOrderMailDet.ShowDialog()
    End Sub

    Sub form_load()
        Dim query As String = "
            SELECT m.id_mail_3pl, s.store_name, c.comp_name AS 3pl, l.status, m.created_date, e.employee_name AS created_by
            FROM tb_sales_return_order_mail_3pl AS m
            LEFT JOIN tb_m_employee AS e ON m.created_by = e.id_employee
            LEFT JOIN tb_m_comp AS c ON c.id_comp = m.id_3pl 
            LEFT JOIN tb_lookup_ror_mail_3pl_status_lookup AS l ON l.id_status = m.id_status
            LEFT JOIN (
                SELECT p.id_mail_3pl, GROUP_CONCAT(CONCAT(c.comp_number, ' - ', c.comp_name) SEPARATOR ', ') AS store_name
                FROM tb_sales_return_order_mail_3pl_store AS p
                LEFT JOIN tb_m_comp AS c ON p.id_comp = c.id_comp
                GROUP BY id_mail_3pl
            ) AS s ON s.id_mail_3pl = m.id_mail_3pl
            ORDER BY m.created_date DESC
        "

        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")

        GCDetail.DataSource = data

        GVDetail.BestFitColumns()
    End Sub

    Private Sub FormSalesReturnOrderMail_Activated(sender As Object, e As EventArgs) Handles MyBase.Activated
        FormMain.show_rb(Name)
        checkFormAccess(Name)
    End Sub

    Private Sub FormSalesReturnOrderMail_Deactivate(sender As Object, e As EventArgs) Handles MyBase.Deactivate
        FormMain.hide_rb()
    End Sub
End Class