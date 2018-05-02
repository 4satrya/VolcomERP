Public Class FormSalesReturnOrderDetEdit
    Dim id_product As String = "-1"

    Private Sub TextEdit5_Properties_KeyUp(sender As Object, e As KeyEventArgs) Handles TxtAdd.Properties.KeyUp

    End Sub

    Private Sub TxtCode_KeyDown(sender As Object, e As KeyEventArgs) Handles TxtCode.KeyDown
        If e.KeyCode = Keys.Enter Then
            Dim code As String = addSlashes(TxtCode.Text)
            Dim query As String = "SELECT p.id_product, p.product_full_code AS `code`, d.design_display_name AS `name`, cd.code_detail_name AS `size`,
            IF(ISNULL(rod.id_sales_return_order_det),'yes','no') AS `stt`
            FROM tb_m_product p 
            INNER JOIN tb_m_product_code pc ON pc.id_product = p.id_product
            INNER JOIN tb_m_code_detail cd ON cd.id_code_detail = pc.id_code_detail
            INNER JOIN tb_m_design d ON d.id_design = p.id_design
            LEFT JOIN tb_sales_return_order_det rod ON rod.id_product = p.id_product AND rod.id_sales_return_order=" + FormSalesReturnOrderDet.id_sales_return_order + "
            WHERE d.id_active=1 AND p.product_full_code='" + code + "' "
            Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
            If data.Rows.Count <= 0 Then
                stopCustom("Product not found")
                TxtDesign.Text = ""
                TxtCode.Text = ""
                id_product = "-1"
                TxtCode.Focus()
            Else
                If data.Rows(0)("stt").ToString = "yes" Then
                    TxtDesign.Text = data.Rows(0)("name").ToString
                    TxtSize.Text = data.Rows(0)("size").ToString
                    id_product = data.Rows(0)("id_product").ToString
                    TxtAdd.Focus()
                Else
                    stopCustom("Product already exist.")
                    TxtDesign.Text = ""
                    TxtCode.Text = ""
                    id_product = "-1"
                    TxtCode.Focus()
                End If
            End If
        Else
            TxtDesign.Text = ""
            id_product = "-1"
        End If
    End Sub

    Private Sub FormSalesReturnOrderDetEdit_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ActiveControl = TxtCode
        TxtAdd.EditValue = 0
    End Sub

    Private Sub TxtAdd_KeyDown(sender As Object, e As KeyEventArgs) Handles TxtAdd.KeyDown
        If e.KeyCode = Keys.Enter Then
            If id_product = "-1" Then
                stopCustom("Please input spesific product !")
            Else
                Dim qty As Integer = TxtAdd.EditValue
                Dim dt As DataTable = execute_query("CALL view_stock_fg('" + FormSalesReturnOrderDet.id_comp + "', '" + FormSalesReturnOrderDet.id_wh_locator + "', '" + FormSalesReturnOrderDet.id_wh_rack + "', '" + FormSalesReturnOrderDet.id_wh_drawer + "', '" + id_product + "', '4', '9999-01-01') ", -1, True, "", "", "", "")
                If dt.Rows.Count > 0 Then
                    Dim qty_limit As Integer = dt.Rows(0)("qty_all_product")
                    If qty > qty_limit Then
                        stopCustom("Can't exceed " + qty_limit.ToString)
                    Else
                        Dim query_ins = "INSERT INTO tb_sales_return_order_det(id_sales_return_order, id_product, id_return_cat, id_design_price, design_price, sales_return_order_det_qty, sales_return_order_det_note) VALUES 
                        ('" + FormSalesReturnOrderDet.id_sales_return_order + "','" + id_product + "','1', '" + dt.Rows(0)("id_design_price_retail").ToString + "','" + decimalSQL(dt.Rows(0)("design_price_retail").ToString) + "','" + decimalSQL(qty.ToString) + "','') "
                        execute_non_query(query_ins, True, "", "", "", "")
                        FormSalesReturnOrderDet.viewDetail()

                        'log
                        Dim ret As New ClassSalesReturn()
                        ret.orderLog(FormSalesReturnOrderDet.id_sales_return_order, "1", addSlashes(TxtCode.Text) + " " + addSlashes(TxtDesign.Text) + " : " + TxtAdd.Text.ToString)

                        'reset
                        TxtCode.Text = ""
                        TxtDesign.Text = ""
                        TxtSize.Text = ""
                        TxtAdd.EditValue = 0
                        id_product = "-1"
                        TxtCode.Focus()
                    End If
                Else
                    stopCustom("There is no available stock")
                End If
            End If
        End If
    End Sub

    Private Sub FormSalesReturnOrderDetEdit_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub
End Class