Public Class FormFGCodeReplaceStoreAdd
    Public id_drawer_def As String = "-1"
    Public id_comp As String = "-1"
    Public id_product As String = "-1"
    Public id_design As String = "-1"
    Dim is_limited_print As String = "-1"

    Private Sub FormFGCodeReplaceStoreAdd_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ActiveControl = TxtStoreCode
        TxtQty.EditValue = 0
        TxtAvailable.EditValue = 0
        pre_viewImages("2", PEView, id_design, False)
        is_limited_print = get_setup_field("is_limited_print")
        If is_limited_print = "2" Then
            LabelControl4.Visible = False
            TxtAvailable.Visible = False
        End If
    End Sub

    Private Sub BtnClose_Click(sender As Object, e As EventArgs) Handles BtnClose.Click
        Close()
    End Sub

    Private Sub FormFGCodeReplaceStoreAdd_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Sub resetInputStore(ByVal include_code As Boolean)
        id_drawer_def = "-1"
        id_comp = "-1"
        If include_code Then
            TxtStoreCode.Text = ""
        End If
        TxtStoreName.Text = ""
        TxtQty.EditValue = 0
        TxtAvailable.EditValue = 0
    End Sub

    Sub resetInputDesign(ByVal include_code As Boolean)
        id_product = "-1"
        id_design = "-1"
        If include_code Then
            TxtDesignCode.Text = ""
        End If
        TxtDesignName.Text = ""
        TxtSize.Text = ""
        PEView.EditValue = Nothing
        'pre_viewImages("2", PEView, id_design, False)
    End Sub

    Private Sub TxtStoreCode_KeyDown(sender As Object, e As KeyEventArgs) Handles TxtStoreCode.KeyDown
        If e.KeyCode = Keys.Enter Then
            Dim code As String = addSlashes(TxtStoreCode.Text)
            Dim data As DataTable = get_company_by_code(code, "AND (comp.id_comp_cat = 6 OR comp.id_comp_cat =5) AND comp.is_only_for_alloc=2 ")
            If data.Rows.Count > 0 Then
                If data.Rows.Count > 1 Then
                    FormMasterCompanyDouble.dt = data
                    FormMasterCompanyDouble.id_pop_up = "2"
                    FormMasterCompanyDouble.ShowDialog()
                    If id_drawer_def <> "-1" Then
                        TxtDesignCode.Focus()
                    Else
                        TxtStoreCode.Text = ""
                        TxtStoreCode.Focus()
                    End If
                Else
                    TxtStoreCode.Text = data.Rows(0)("comp_number").ToString
                    TxtStoreName.Text = data.Rows(0)("comp_name").ToString
                    id_drawer_def = data.Rows(0)("id_drawer_def").ToString
                    id_comp = data.Rows(0)("id_comp").ToString
                    TxtDesignCode.Focus()
                End If
            Else
                stopCustom("Store not found")
                TxtStoreCode.Text = ""
                TxtStoreCode.Focus()
            End If
        Else
            resetInputStore(False)
        End If
    End Sub

    Private Sub TxtDesignCode_KeyDown(sender As Object, e As KeyEventArgs) Handles TxtDesignCode.KeyDown
        If e.KeyCode = Keys.Enter Then
            Dim keyword As String = addSlashes(TxtDesignCode.Text)
            Dim query As String = "SELECT p.id_product,p.id_design, d.design_code, p.product_full_code AS `product_code`,p.product_full_code AS `code`,
            d.design_display_name AS `name`, cd.code_detail_name AS `size`, d.is_old_design
            FROM tb_m_product p
            INNER JOIN tb_m_product_code pc ON pc.id_product = p.id_product
            INNER JOIN tb_m_code_detail cd ON cd.id_code_detail = pc.id_code_detail
            INNER JOIN tb_m_design d ON d.id_design = p.id_design AND d.id_active=1
            WHERE p.product_full_code LIKE '%" + keyword + "%' OR d.design_code LIKE '%" + keyword + "%'  "
            Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
            If data.Rows.Count > 0 Then
                FormSalesReturnSearch.id_pop_up = "1"
                FormSalesReturnSearch.dt = data
                FormSalesReturnSearch.ShowDialog()
                If id_product <> "-1" Then
                    pre_viewImages("2", PEView, id_design, False)
                    getStock()
                    TxtQty.Focus()
                Else
                    TxtDesignCode.Focus()
                End If
            Else
                stopCustom("Data not found")
                TxtDesignCode.Text = ""
                TxtDesignCode.Focus()
            End If
        Else
            resetInputDesign(False)
        End If
    End Sub

    Sub getStock()
        Cursor = Cursors.WaitCursor
        If is_limited_print = "1" Then
            Dim query As String = "SELECT SUM(IF(f.id_storage_category=2, CONCAT('-', f.storage_product_qty), f.storage_product_qty)) AS qty
            FROM tb_storage_fg f
            WHERE f.id_wh_drawer='" + id_drawer_def + "' AND f.id_product='" + id_product + "'
            GROUP BY f.id_product "
            Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
            If data.Rows.Count > 0 Then
                TxtAvailable.EditValue = data.Rows(0)("qty")
            Else
                TxtAvailable.EditValue = 0
            End If
        Else
            TxtAvailable.EditValue = 9999
        End If
        Cursor = Cursors.Default
    End Sub

    Private Sub TxtQty_EditValueChanged(sender As Object, e As EventArgs) Handles TxtQty.EditValueChanged

    End Sub


    Private Sub TxtQty_KeyDown(sender As Object, e As KeyEventArgs) Handles TxtQty.KeyDown
        If e.KeyCode = Keys.Enter Then
            If TxtQty.EditValue > TxtAvailable.EditValue Then
                stopCustom("Can't exceed " + TxtAvailable.EditValue.ToString)
                TxtQty.EditValue = 0
                TxtQty.Focus()
            Else
                BtnAdd.Focus()
            End If
        End If
    End Sub

    Private Sub BtnAdd_Click(sender As Object, e As EventArgs) Handles BtnAdd.Click
        makeSafeGV(FormFGCodeReplaceStoreDet.GVItemList)
        Dim cond_duplicate As Boolean = False
        FormFGCodeReplaceStoreDet.GVItemList.ActiveFilterString = "[id_comp]='" + id_comp + "' AND [id_product]='" + id_product + "' "
        If FormFGCodeReplaceStoreDet.GVItemList.RowCount > 0 Then
            cond_duplicate = True
        End If
        FormFGCodeReplaceStoreDet.GVItemList.ActiveFilterString = ""

        If id_drawer_def = " - 1" Or id_product = "-1" Or TxtQty.EditValue = 0 Then
            stopCustom("Input can't blank. ")
        ElseIf TxtQty.EditValue > TxtAvailable.EditValue Then
            stopCustom("Can't exceed " + TxtAvailable.EditValue.ToString)
        ElseIf cond_duplicate Then
            stopCustom("Data already exist !")
        Else
            Dim newRow As DataRow = (TryCast(FormFGCodeReplaceStoreDet.GCItemList.DataSource, DataTable)).NewRow()
            newRow("code") = TxtDesignCode.Text
            newRow("name") = TxtDesignName.Text
            newRow("size") = TxtSize.Text
            newRow("pl_sales_order_del_number") = ""
            newRow("id_comp") = id_comp
            newRow("comp_name") = TxtStoreName.Text
            newRow("comp_number") = TxtStoreCode.Text
            newRow("counting_start") = "0000"
            newRow("counting_end") = "0000"
            newRow("fg_code_replace_store_det_qty") = TxtQty.EditValue
            newRow("id_product") = id_product
            newRow("id_fg_code_replace_store_det") = "0"
            TryCast(FormFGCodeReplaceStoreDet.GCItemList.DataSource, DataTable).Rows.Add(newRow)
            FormFGCodeReplaceStoreDet.GCItemList.RefreshDataSource()
            FormFGCodeReplaceStoreDet.GVItemList.RefreshData()
            resetInputStore(True)
            resetInputDesign(True)
            ActiveControl = TxtStoreCode
        End If
    End Sub
End Class