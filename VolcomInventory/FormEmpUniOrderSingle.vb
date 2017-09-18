Public Class FormEmpUniOrderSingle
    Public dt As DataTable

    Private Sub FormEmpUniOrderSingle_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub FormEmpUniOrderSingle_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        GCDesign.DataSource = dt
        GVDesign.FocusedRowHandle = 0
    End Sub

    Sub closeForm()
        Close()
    End Sub

    Sub choose()
        If GVDesign.RowCount > 0 And GVDesign.FocusedRowHandle >= 0 Then
            Cursor = Cursors.WaitCursor
            Dim id_product As String = GVDesign.GetFocusedRowCellValue("id_product").ToString
            Dim id_design As String = GVDesign.GetFocusedRowCellValue("id_design").ToString
            Dim id_design_price As String = GVDesign.GetFocusedRowCellValue("id_design_price").ToString
            Dim design_price As String = decimalSQL(GVDesign.GetFocusedRowCellValue("design_price").ToString)


            'cek in so
            Dim check_existing As Boolean = False
            Dim query_sod As String = "SELECT * FROM tb_sales_order_det sod 
            INNER JOIN tb_sales_order so ON so.id_sales_order = sod.id_sales_order
            INNER JOIN tb_m_product p ON p.id_product = sod.id_product 
            WHERE so.id_emp_uni_budget =" + FormEmpUniOrderDet.id_emp_uni_budget + " AND p.id_design=" + id_design + " AND so.id_report_status!=5 "
            Dim data_sod As DataTable = execute_query(query_sod, -1, True, "", "", "", "")
            If data_sod.Rows.Count > 0 Then
                check_existing = True
            End If

            'cek stok
            Dim check_avail_stc As Boolean = True
            Dim condition As String = "AND so.id_emp_uni_period=" + FormEmpUniPeriodDet.id_emp_uni_period + " AND sod.id_product=" + id_product + " "
            Dim data_stc As DataTable = execute_query("CALL view_emp_uni_stock(""" + condition + """,1) ", -1, True, "", "", "", "")
            If (data_stc.Rows.Count <= 0) Or data_stc.Rows(0)("qty_avail") <= 0 Then
                check_avail_stc = False
            End If

            'cek budget
            Dim gross_check As Decimal = FormEmpUniOrderDet.TxtGross.EditValue + GVDesign.GetFocusedRowCellValue("design_price")
            Dim total As Decimal = gross_check - (gross_check * (FormEmpUniOrderDet.TxtDiscount.EditValue / 100))

            If check_existing Then
                stopCustom("Product already order")
            ElseIf Not check_avail_stc Then
                stopCustom("There is no available quantity")
            ElseIf total > FormEmpUniOrderDet.TxtOrderMax.EditValue
                stopCustom("Exceed maximum order : " + FormEmpUniOrderDet.TxtOrderMax.Text.ToString)
            Else
                Dim query As String = "INSERT INTO tb_sales_order_det(id_sales_order, id_product, id_design_price, design_price, sales_order_det_qty, sales_order_det_note) VALUES 
                ('" + FormEmpUniOrderDet.id_sales_order + "','" + id_product + "','" + id_design_price + "','" + design_price + "','1','') "
                execute_non_query(query, True, "", "", "", "")

                'refresh
                FormEmpUniOrderDet.actionLoad()
                Close()
            End If

            Cursor = Cursors.Default
        End If
    End Sub

    Private Sub FormEmpUniOrderSingle_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.Enter Then
            choose()
        End If
    End Sub

    Private Sub GVDesign_DoubleClick(sender As Object, e As EventArgs) Handles GVDesign.DoubleClick
        choose()
    End Sub
End Class