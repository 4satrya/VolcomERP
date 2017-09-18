Public Class FormEmpUniOrderNew
    Private Sub FormEmpUniOrderNew_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim query As String = "CALL view_emp_uni_budget(" + FormEmpUniPeriodDet.id_emp_uni_period + ") "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCDetail.DataSource = data
        GCDetail.Focus()
        GVDetail.Focus()
    End Sub

    Sub chooseEmp()
        If GVDetail.RowCount > 0 And GVDetail.FocusedRowHandle >= 0 Then
            Cursor = Cursors.WaitCursor
            'get destination
            Dim id_dept As String = GVDetail.GetFocusedRowCellValue("id_departement").ToString
            Dim id_store_contact_to As String = "-1"
            Try
                id_store_contact_to = execute_query("SELECT cc.id_comp_contact FROM tb_m_departement d 
                INNER JOIN tb_m_comp c ON c.id_comp = d.id_comp_promo
                INNER JOIN tb_m_comp_contact cc ON cc.id_comp = c.id_comp AND cc.is_default=1
                WHERE d.id_departement=" + id_dept + " ", 0, True, "", "", "", "")
            Catch ex As Exception
            End Try

            'get from
            Dim id_wh_uni As String = get_setup_field("wh_uni")
            Dim id_warehouse_contact_to = "-1"
            Try
                id_warehouse_contact_to = execute_query("SELECT cc.id_comp_contact FROM tb_m_comp c 
                INNER JOIN tb_m_comp_contact cc ON cc.id_comp = c.id_comp AND cc.is_default=1
                WHERE c.id_comp = " + id_wh_uni + " ", 0, True, "", "", "", "")
            Catch ex As Exception
            End Try

            'get id_emp_uni_budget
            Dim id_emp_uni_budget As String = GVDetail.GetFocusedRowCellValue("id_emp_uni_budget").ToString
            Dim tolerance As String = decimalSQL(GVDetail.GetFocusedRowCellValue("tolerance").ToString)

            'get discount
            Dim discount As Decimal = 0
            Dim data_dsc As DataTable = execute_query("SELECT discount_uni FROM tb_opt ", -1, True, "", "", "", "")
            If data_dsc.Rows.Count > 0 Then
                discount = data_dsc.Rows(0)("discount_uni")
            End If

            If id_store_contact_to = "-1" Then
                stopCustom("Promo account is not found")
            ElseIf id_warehouse_contact_to = "-1" Then
                stopCustom("WH account is not found")
            Else
                Dim query As String = "INSERT INTO tb_sales_order(id_store_contact_to, id_warehouse_contact_to, sales_order_number, sales_order_date, sales_order_note, id_so_type, id_report_status, id_so_status, id_user_created, id_emp_uni_period, id_emp_uni_budget, tolerance, discount) "
                query += "VALUES('" + id_store_contact_to + "', '" + id_warehouse_contact_to + "', '" + header_number_sales("2") + "', NOW(), '', '0', '1', '7', '" + id_user + "','" + FormEmpUniPeriodDet.id_emp_uni_period + "'," + id_emp_uni_budget + ",'" + tolerance + "','" + decimalSQL(discount.ToString) + "'); SELECT LAST_INSERT_ID(); "
                Dim id_new As String = execute_query(query, 0, True, "", "", "", "")
                increase_inc_sales("2")
                submit_who_prepared("39", id_new, id_user)
                FormEmpUniPeriodDet.viewOrder()
                FormEmpUniPeriodDet.GVSalesOrder.FocusedRowHandle = find_row(FormEmpUniPeriodDet.GVSalesOrder, "id_sales_order", id_new)

                FormEmpUniOrderDet.id_sales_order = id_new
                FormEmpUniOrderDet.ShowDialog()
                Close()
            End If
            Cursor = Cursors.Default
        End If
    End Sub

    Private Sub BtnChoose_Click(sender As Object, e As EventArgs) Handles BtnChoose.Click
        chooseEmp()
    End Sub

    Private Sub FormEmpUniOrderNew_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.Enter Then
            chooseEmp()
        End If
    End Sub

    Private Sub FormEmpUniOrderNew_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub
End Class