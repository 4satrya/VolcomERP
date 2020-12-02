Public Class FormSalesReturnOrderMailPick
    Private Sub FormSalesReturnOrderMailPick_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim where_in As String = ""

        For i = 0 To FormSalesReturnOrderMailDet.GVDetail.RowCount - 1
            If FormSalesReturnOrderMailDet.GVDetail.IsValidRowHandle(i) Then
                where_in = FormSalesReturnOrderMailDet.GVDetail.GetRowCellValue(i, "id_sales_return_order").ToString + ", "
            End If
        Next

        If Not where_in = "" Then
            where_in = "AND a.id_sales_return_order NOT IN (" + where_in.Substring(0, where_in.Length - 2) + ")"
        End If

        Dim query As String = "
            SELECT 'no' AS is_check, a.id_sales_return_order, a.sales_return_order_number, CONCAT(d.comp_number, ' - ', d.comp_name) AS store_name_to, IFNULL(i.return_qty, 0) AS return_qty, a.sales_return_order_note
            FROM tb_sales_return_order AS a
            INNER JOIN tb_m_comp_contact c ON c.id_comp_contact = a.id_store_contact_to
            INNER JOIN tb_m_comp d ON c.id_comp = d.id_comp
            LEFT JOIN (
                SELECT rt.id_sales_return_order, SUM(rt_det.sales_return_det_qty) AS return_qty 
                FROM tb_sales_return AS rt
                INNER JOIN tb_sales_return_det AS rt_det ON rt.id_sales_return = rt_det.id_sales_return 
                WHERE rt.id_report_status = 6
                GROUP BY rt.id_sales_return_order 
            ) AS i ON i.id_sales_return_order = a.id_sales_return_order
            LEFT JOIN (
                SELECT id_report
                FROM tb_mail_manage_det AS d
                LEFT JOIN tb_mail_manage AS h ON d.id_mail_manage = h.id_mail_manage
                WHERE h.report_mark_type = 45 AND h.id_mail_status = 2
            ) AS mail ON a.id_sales_return_order = mail.id_report
            WHERE a.id_sales_return_order > 0 AND c.id_comp IN (" + FormSalesReturnOrderMailDet.CCBEStore.EditValue.ToString + ") AND a.id_report_status = 6 AND mail.id_report IS NOT NULL " + where_in + " AND a.id_sales_return_order NOT IN (SELECT d.id_sales_order_return FROM tb_sales_return_order_mail_3pl_det AS d LEFT JOIN tb_sales_return_order_mail_3pl AS a ON d.id_mail_3pl = a.id_mail_3pl WHERE a.id_status <> 5)
            ORDER BY a.id_sales_return_order ASC
        "

        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")

        GCROR.DataSource = data

        GVROR.BestFitColumns()
    End Sub

    Private Sub FormSalesReturnOrderMailPick_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub SBAdd_Click(sender As Object, e As EventArgs) Handles SBAdd.Click
        GVROR.ActiveFilterString = "[is_check] = 'yes'"

        If GVROR.RowCount > 0 Then
            Dim data As DataTable = FormSalesReturnOrderMailDet.GCDetail.DataSource

            For i = 0 To GVROR.RowCount - 1
                If GVROR.IsValidRowHandle(i) Then
                    Dim row As DataRow = data.NewRow

                    row("id_sales_return_order") = GVROR.GetRowCellValue(i, "id_sales_return_order").ToString
                    row("no") = 0
                    row("sales_return_order_number") = GVROR.GetRowCellValue(i, "sales_return_order_number").ToString
                    row("store_name_to") = GVROR.GetRowCellValue(i, "store_name_to").ToString
                    row("return_qty") = GVROR.GetRowCellValue(i, "return_qty").ToString
                    row("sales_return_order_note") = GVROR.GetRowCellValue(i, "sales_return_order_note").ToString

                    data.Rows.Add(row)
                End If
            Next

            FormSalesReturnOrderMailDet.GCDetail.DataSource = data

            FormSalesReturnOrderMailDet.GVDetail.BestFitColumns()

            Close()
        Else
            stopCustom("Please select ROR.")
        End If

        GVROR.ActiveFilterString = ""
    End Sub
End Class