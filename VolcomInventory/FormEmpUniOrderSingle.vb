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
            Dim check_existing As Boolean = FormEmpUniOrderDet.checkExist(id_design)

            'cek stok
            Dim check_avail_stc As Boolean = True
            Dim condition As String = "AND dm.id_emp_uni_period=" + FormEmpUniOrderDet.id_emp_uni_period + " AND prod.id_product=" + id_product + " "
            Dim data_stc As DataTable = FormEmpUniOrderDet.checkStock(condition)
            If (data_stc.Rows.Count <= 0) Or data_stc.Rows(0)("qty_avl") <= 0 Then
                check_avail_stc = False
            End If

            'cek budget
            Dim total As Decimal = FormEmpUniOrderDet.TxtTotal.EditValue + GVDesign.GetFocusedRowCellValue("point")

            If check_existing Then
                stopCustom("Product sudah dipilih")
                Close()
            ElseIf Not check_avail_stc Then
                stopCustom("Stok sudah habis")
            ElseIf total > FormEmpUniOrderDet.Txtbudget.EditValue Then
                stopCustom("Budget tidak mencukupi")
                Close()
            Else
                Cursor = Cursors.WaitCursor
                Dim query As String = "INSERT INTO tb_sales_order_det(id_sales_order, id_product, id_design_price, design_price, sales_order_det_qty, sales_order_det_note) VALUES 
                ('" + FormEmpUniOrderDet.id_sales_order + "','" + id_product + "','" + id_design_price + "','" + design_price + "','1',''); SELECT LAST_INSERT_ID(); "
                Dim id_new As String = execute_query(query, 0, True, "", "", "", "")

                'cek lg
                data_stc = Nothing
                data_stc = FormEmpUniOrderDet.checkStock(condition)
                If (data_stc.Rows.Count <= 0) Or data_stc.Rows(0)("qty_avl") < 0 Then
                    Dim qdel As String = "DELETE FROM tb_sales_order_det WHERE id_sales_order_det=" + id_new + " "
                    execute_non_query(qdel, True, "", "", "", "")
                    stopCustom("Stok sudah habis")
                End If

                'refresh
                FormEmpUniOrderDet.actionLoad()
                Close()
                Cursor = Cursors.Default
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

    Private Sub BtnClose_Click(sender As Object, e As EventArgs) Handles BtnClose.Click
        closeForm()
    End Sub
End Class