Public Class FormSalesPOSNoStockAdd
    Public id_design_price As String = "-1"
    Dim id_product As String = "-1"
    Dim id_design As String = "-1"

    Private Sub FormSalesPOSNoStockAdd_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        TxtPrice.EditValue = 0.00
        TxtAdd.EditValue = 0.00
        TxtCode.Focus()
        ActiveControl = TxtCode
    End Sub

    Sub add()
        Cursor = Cursors.WaitCursor
        If id_product = "-1" Or id_design_price = "-1" Or TxtAdd.EditValue <= 0 Then
            warningCustom("Please complete all data")
        Else
            Dim newRow As DataRow = (TryCast(FormSalesPOSNoStockDet.GCData.DataSource, DataTable)).NewRow()
            newRow("id_product") = id_product
            newRow("code") = TxtCode.Text
            newRow("name") = TxtDesign.Text
            newRow("size") = TxtSize.Text
            newRow("id_design_price") = id_design_price
            newRow("design_price") = TxtPrice.EditValue
            newRow("qty") = TxtAdd.EditValue
            newRow("note") = MENote.Text
            TryCast(FormSalesPOSNoStockDet.GCData.DataSource, DataTable).Rows.Add(newRow)
            FormSalesPOSNoStockDet.GCData.RefreshDataSource()
            FormSalesPOSNoStockDet.GVData.RefreshData()

            'input lagi
            resetInput()
            TxtCode.Focus()
            ActiveControl = TxtCode
        End If
        Cursor = Cursors.Default
    End Sub

    Private Sub BtnAdd_Click(sender As Object, e As EventArgs) Handles BtnAdd.Click
        add()
    End Sub

    Private Sub BtnClose_Click(sender As Object, e As EventArgs) Handles BtnClose.Click
        Close()
    End Sub

    Private Sub FormSalesPOSNoStockAdd_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub TxtCode_KeyDown(sender As Object, e As KeyEventArgs) Handles TxtCode.KeyDown
        If e.KeyCode = Keys.Enter Then
            If TxtCode.Text = "" Then
                warningCustom("Please input code product")
                TxtCode.Text = ""
                TxtCode.Focus()
            Else
                Dim code As String = addSlashes(TxtCode.Text)
                Dim query As String = "SELECT  prod.id_product, prod.id_design, prod.product_full_code AS `code`, dsg.design_display_name AS `name`, cd.code_detail_name AS `size`, 
                IFNULL(prc.id_design_price,0) AS `id_design_price`, IFNULL(prc.design_price,0.00) AS `design_price`
                FROM tb_m_product prod
                INNER JOIN tb_m_product_code pc ON pc.id_product = prod.id_product
                INNER JOIN tb_m_code_detail cd ON cd.id_code_detail = pc.id_code_detail
                INNER JOIN tb_m_design dsg ON dsg.id_design = prod.id_design
                LEFT JOIN( 
                  Select * FROM ( 
                  Select price.id_design, price.design_price, price.design_price_date, price.id_design_price, 
                  price.id_design_price_type, price_type.design_price_type,
                  cat.id_design_cat, cat.design_cat
                  From tb_m_design_price price 
                  INNER Join tb_lookup_design_price_type price_type On price.id_design_price_type = price_type.id_design_price_type 
                  INNER JOIN tb_lookup_design_cat cat ON cat.id_design_cat = price_type.id_design_cat
                  WHERE price.is_active_wh =1 AND price.design_price_start_date <= NOW() 
                  ORDER BY price.design_price_start_date DESC, price.id_design_price DESC ) a 
                  GROUP BY a.id_design 
                ) prc ON prc.id_design = prod.id_design 
                WHERE dsg.id_active=1 AND prod.product_full_code='" + code + "' "
                Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
                If data.Rows.Count <= 0 Then
                    warningCustom("Product not found")
                    resetInput()
                    TxtCode.Focus()
                Else
                    'tidak aad price
                    If data.Rows(0)("id_design_price").ToString = "0" Then
                        warningCustom("Price not found")
                        resetInput()
                        TxtCode.Focus()
                        Exit Sub
                    End If

                    'cek existing
                    makeSafeGV(FormSalesPOSNoStockDet.GVData)
                    FormSalesPOSNoStockDet.GVData.ActiveFilterString = "[id_product]='" + data.Rows(0)("id_product").ToString + "'"
                    If FormSalesPOSNoStockDet.GVData.RowCount > 0 Then
                        warningCustom("Product already exist.")
                        makeSafeGV(FormSalesPOSNoStockDet.GVData)
                        resetInput()
                        TxtCode.Focus()
                        Exit Sub
                    End If
                    makeSafeGV(FormSalesPOSNoStockDet.GVData)

                    TxtDesign.Text = data.Rows(0)("name").ToString
                    TxtSize.Text = data.Rows(0)("size").ToString
                    id_product = data.Rows(0)("id_product").ToString
                    id_design = data.Rows(0)("id_design").ToString
                    id_design_price = data.Rows(0)("id_design_price").ToString
                    TxtPrice.EditValue = data.Rows(0)("design_price")
                    TxtAdd.Focus()
                End If
            End If
        End If
    End Sub

    Sub resetInput()
        TxtCode.Text = ""
        TxtDesign.Text = ""
        TxtSize.Text = ""
        MENote.Text = ""
        TxtPrice.EditValue = 0.00
        TxtAdd.EditValue = 0.00
        id_product = "-1"
        id_design = "-1"
        id_design_price = "-1"
    End Sub

    Private Sub TxtAdd_KeyDown(sender As Object, e As KeyEventArgs) Handles TxtAdd.KeyDown
        If e.KeyCode = Keys.Enter Then
            If TxtAdd.EditValue <= 0 Then
                warningCustom("Please input quantity")
                TxtAdd.EditValue = 0.00
                TxtAdd.Focus()
            Else
                MENote.Focus()
            End If
        End If
    End Sub

    Private Sub MENote_KeyDown(sender As Object, e As KeyEventArgs) Handles MENote.KeyDown
        If e.KeyCode = Keys.Enter Then
            add()
        End If
    End Sub

    Private Sub BtnBrowse_Click(sender As Object, e As EventArgs) Handles BtnBrowse.Click
        Cursor = Cursors.WaitCursor
        FormSalesPosPrice.id_pop_up = "1"
        FormSalesPosPrice.id_design = id_design
        FormSalesPosPrice.ShowDialog()
        Cursor = Cursors.Default
    End Sub
End Class