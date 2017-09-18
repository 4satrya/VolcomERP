Public Class FormMasterProductDet
    Public data_insert_parameter As New DataTable
    Public id_product As String = "-1"
    Public id_design As String = "-1"
    Public dupe As String = "-1"
    Public form_name As String = "-1"
    'Public is_active_ean As String = "-1"
    Dim id_role_admin_super As String = "-1"
    'Dim product_image_path As String = get_setup_field("pic_path_product") & "\"

    Private Sub view_inv_method(ByVal lookup As DevExpress.XtraEditors.LookUpEdit)
        Dim query As String = "SELECT id_method,method FROM tb_lookup_inventory_method ORDER BY id_method ASC"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")

        lookup.Properties.DataSource = Nothing
        lookup.Properties.DataSource = data

        lookup.Properties.DisplayMember = "method"
        lookup.Properties.ValueMember = "id_method"
        lookup.ItemIndex = 0
    End Sub
    'View Template
    Private Sub viewTemplate(ByVal lookup As DevExpress.XtraEditors.SearchLookUpEdit)
        Dim query As String = "SELECT id_template_code,template_code FROM tb_template_code ORDER BY template_code ASC"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")

        lookup.Properties.DataSource = Nothing
        lookup.Properties.DataSource = data

        lookup.Properties.DisplayMember = "template_code"
        lookup.Properties.ValueMember = "id_template_code"
        Try
            lookup.EditValue = get_setup_field("id_code_template_product")
        Catch ex As Exception
            lookup.EditValue = data.Rows(0)("id_template_code").ToString
        End Try
    End Sub
    Sub load_isi_param()
        Cursor = Cursors.WaitCursor

        data_insert_parameter.Clear()

        If data_insert_parameter.Columns.Count < 2 Then
            data_insert_parameter.Columns.Add("code")
            data_insert_parameter.Columns.Add("value")
        End If

        GCCode.DataSource = data_insert_parameter
        DNCode.DataSource = data_insert_parameter


        Try
            add_combo_grid_val(GVCode, 0)
            view_value_code(GVCode, 1)
        Catch ex As Exception
        End Try

        Cursor = Cursors.Default
    End Sub
    Private Sub add_combo_grid_val(ByVal grid As DevExpress.XtraGrid.Views.Grid.GridView, ByVal col As Integer)
        Dim lookup As New DevExpress.XtraEditors.Repository.RepositoryItemSearchLookUpEdit

        lookup.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor

        Dim query As String = String.Format("SELECT id_code,code_name as Code,description as Description FROM tb_m_code")
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")

        lookup.DataSource = Nothing
        lookup.DataSource = data
        lookup.PopulateViewColumns()
        lookup.NullText = ""
        lookup.View.Columns("id_code").Visible = False
        lookup.DisplayMember = "Code"
        lookup.ValueMember = "id_code"

        grid.Columns(col).ColumnEdit = lookup
    End Sub
    Sub view_value_code(ByVal grid As DevExpress.XtraGrid.Views.Grid.GridView, ByVal col As Integer)
        Dim lookup As New DevExpress.XtraEditors.Repository.RepositoryItemSearchLookUpEdit

        lookup.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor

        Dim query As String = String.Format("SELECT id_code,id_code_detail,CODE as Code,code_detail_name as Name,display_name as 'Printed Name',CONCAT(CODE,' - ',code_detail_name) AS value FROM tb_m_code_detail")
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")

        lookup.DataSource = Nothing
        lookup.DataSource = data
        lookup.PopulateViewColumns()
        lookup.NullText = ""
        lookup.View.Columns("id_code_detail").Visible = False
        lookup.View.Columns("value").Visible = False
        lookup.View.Columns("id_code").Visible = False
        lookup.DisplayMember = "value"
        lookup.ValueMember = "id_code_detail"

        grid.Columns(col).ColumnEdit = lookup
    End Sub

    Private Sub FormMasterProductDet_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        view_inv_method(LEInvMethod)
        load_isi_param()
        viewTemplate(LETemplate)

        TEMinStock.EditValue = 0.0
        TEMaxStock.EditValue = 0.0
        TEMinOrder.EditValue = 0.0
        TEMaxOrder.EditValue = 0.0

        id_role_admin_super = get_setup_field("id_role_super_admin")
        actionLoad()
    End Sub

    Sub actionLoad()
        If form_name = "FormMasterDesignSingle" Then
            If FormMasterDesignSingle.form_name = "-1" Then
                TEDesignCode.Text = FormMasterProduct.GVDesign.GetFocusedRowCellDisplayText("design_code").ToString
                TEName.Text = FormMasterProduct.GVDesign.GetFocusedRowCellDisplayText("design_name").ToString
            ElseIf FormMasterDesignSingle.form_name = "FormFGLineList" Then
                TEEanCode.Enabled = False
                TEDesignCode.Text = FormMasterDesignSingle.TECode.Text
                TEName.Text = FormMasterDesignSingle.TEDisplayName.Text
            End If
        ElseIf form_name = "FormFGProdList" Then
            TEDesignCode.Text = FormFGProdList.GVProdList.GetFocusedRowCellValue("design_code").ToString
            TEName.Text = FormFGProdList.GVProdList.GetFocusedRowCellValue("design_display_name").ToString
            LEInvMethod.Enabled = False
            TEMinStock.Enabled = False
            TEMaxStock.Enabled = False
            TEMinOrder.Enabled = False
            TEMaxOrder.Enabled = False
            BGenerate.Visible = False
            BeditCode.Visible = False
            BRefreshCode.Visible = False
            GVCode.OptionsBehavior.Editable = False
            If id_role_admin_super = id_role_login Then
                CheckEdit1.Visible = True
            End If
        End If

        If id_product <> "-1" Then
            LabelPrintedName.Text = FormMasterProduct.GVProduct.GetFocusedRowCellDisplayText("product_name").ToString
            view_product_price(id_product)
            view_movement(id_product)
            'edit
            'If System.IO.File.Exists(product_image_path & id_product & ".jpg") Then
            'PictureEdit1.LoadAsync(product_image_path & id_product & ".jpg")
            ' Else
            '    PictureEdit1.LoadAsync(product_image_path & "default" & ".jpg")
            ' End If

            Try
                Dim query As String = String.Format("SELECT * FROM tb_m_product WHERE id_product = '{0}'", id_product)
                Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")

                TEName.Text = data.Rows(0)("product_name").ToString
                TEDisplayName.Text = data.Rows(0)("product_display_name").ToString
                TECode.Text = data.Rows(0)("product_code").ToString
                TEFullCode.Text = data.Rows(0)("product_full_code").ToString
                TEMaxOrder.Text = data.Rows(0)("order_max").ToString
                TEMinOrder.Text = data.Rows(0)("order_min").ToString
                TEMaxStock.Text = data.Rows(0)("inv_max_stock").ToString
                TEMinStock.Text = data.Rows(0)("inv_min_stock").ToString
                LEInvMethod.EditValue = data.Rows(0)("id_method").ToString
                TEEanCode.Text = data.Rows(0)("product_ean_code").ToString

                query = String.Format("SELECT tb_m_code_detail.id_code as id_code,tb_m_product_code.id_code_detail as id_code_detail FROM tb_m_product_code,tb_m_code_detail WHERE tb_m_product_code.id_code_detail = tb_m_code_detail.id_code_detail AND tb_m_product_code.id_product = '{0}'", id_product)
                Dim data_value As DataTable = execute_query(query, -1, True, "", "", "", "")
                data_insert_parameter.Clear()
                If Not data_value.Rows.Count = 0 Then
                    For i As Integer = 0 To data_value.Rows.Count - 1
                        data_insert_parameter.Rows.Add(data_value.Rows(i)("id_code").ToString, data_value.Rows(i)("id_code_detail").ToString)
                    Next
                End If

                If dupe = "-1" Then
                    XTPPrice.PageVisible = False
                    XTPMovement.PageVisible = False
                End If
            Catch ex As Exception
                errorConnection()
            End Try
        Else
            'XTPPrice.PageVisible = False
            XTPMovement.PageVisible = False
        End If
    End Sub

    Private Sub GVCode_CellValueChanged(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles GVCode.CellValueChanged
        If e.Column.Name.ToString <> "ColCodeParam" Then
            Exit Sub
        Else
            Dim cellValue As String = e.Value.ToString()

            Dim query As String = String.Format("SELECT id_code,id_code_detail,CODE as Code,code_detail_name as Name,display_name as 'Printed Name',CONCAT(CODE,' - ',code_detail_name) AS value FROM tb_m_code_detail WHERE id_code='" & cellValue.ToString & "'")
            Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
            GVCode.SetRowCellValue(e.RowHandle, GVCode.Columns("value"), data.Rows(0)("id_code").ToString)
        End If
    End Sub
    Private clone As DataView = Nothing
    Private Sub GVCode_ShownEditor(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GVCode.ShownEditor
        Dim view As DevExpress.XtraGrid.Views.Grid.GridView = CType(sender, DevExpress.XtraGrid.Views.Grid.GridView)
        Try
            If view.FocusedColumn.FieldName = "value" AndAlso TypeOf view.ActiveEditor Is DevExpress.XtraEditors.SearchLookUpEdit Then
                Dim edit As DevExpress.XtraEditors.SearchLookUpEdit
                Dim table As DataTable
                Dim row As DataRow

                edit = CType(view.ActiveEditor, DevExpress.XtraEditors.SearchLookUpEdit)
                Try
                    table = CType(edit.Properties.DataSource, DataTable)
                Catch ex As Exception
                    table = CType(edit.Properties.DataSource, DataView).Table
                End Try
                clone = New DataView(table)

                row = view.GetDataRow(view.FocusedRowHandle)
                clone.RowFilter = "[id_code] = " + row("code").ToString()
                edit.Properties.DataSource = clone
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub GVCode_HiddenEditor(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GVCode.HiddenEditor
        If clone IsNot Nothing Then
            clone.Dispose()
            clone = Nothing
        End If
    End Sub

    Sub load_template(ByVal id_template As String)
        Dim query As String = String.Format("SELECT * FROM tb_template_code_det WHERE id_template_code = '{0}'", id_template)
        Dim data_value As DataTable = execute_query(query, -1, True, "", "", "", "")

        data_insert_parameter.Clear()
        If Not data_value.Rows.Count = 0 Then
            For i As Integer = 0 To data_value.Rows.Count - 1
                data_insert_parameter.Rows.Add(data_value.Rows(i)("id_code").ToString)
            Next
        End If
    End Sub

    Private Sub LETemplate_EditValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LETemplate.EditValueChanged
        load_template(LETemplate.EditValue)
    End Sub

    Private Sub BGenerate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BGenerate.Click
        Dim id_code, code, query As String
        Dim code_full As String = ""

        For i As Integer = 0 To GVCode.RowCount - 1
            code = ""
            id_code = ""
            Try
                id_code = GVCode.GetRowCellValue(i, "value").ToString
            Catch ex As Exception
                id_code = ""
            End Try

            If Not id_code = "" Or id_code = "0" Then
                Try
                    query = String.Format("SELECT is_include_code FROM tb_m_code,tb_m_code_detail WHERE tb_m_code.id_code=tb_m_code_detail.id_code AND tb_m_code_detail.id_code_detail='" & id_code & "'")
                    code = execute_query(query, 0, True, "", "", "", "")
                Catch ex As Exception
                    code = "False"
                End Try

                If code = "True" Then
                    query = String.Format("SELECT code FROM tb_m_code_detail WHERE id_code_detail='" & id_code & "'")
                    code = execute_query(query, 0, True, "", "", "", "")
                Else
                    code = ""
                End If
            End If
            code_full += code
        Next
        TECode.Text = code_full
        'display name
        Dim string_name As String = ""

        For i As Integer = 0 To GVCode.RowCount - 1
            code = ""
            id_code = ""
            Try
                id_code = GVCode.GetRowCellValue(i, "value").ToString
            Catch ex As Exception
                id_code = ""
            End Try

            If Not id_code = "" Or id_code = "0" Then
                query = String.Format("SELECT tb_m_code.is_include_name FROM tb_m_code,tb_m_code_detail WHERE tb_m_code.id_code=tb_m_code_detail.id_code AND tb_m_code_detail.id_code_detail='" & id_code & "'")
                code = execute_query(query, 0, True, "", "", "", "")
                If code.ToString = "True" Then
                    query = String.Format("SELECT display_name FROM tb_m_code_detail WHERE id_code_detail='" & id_code & "'")
                    code = execute_query(query, 0, True, "", "", "", "")
                    string_name += " " & code
                End If
            End If
        Next

        TEDisplayName.Text = TEName.Text.ToUpper & string_name.ToUpper
        LabelPrintedName.Text = TEName.Text.ToUpper & string_name.ToUpper
    End Sub
    Private Sub FormMasterProductDet_FormClosed(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub
    Sub view_full_code()
        Dim code_design As String = TEDesignCode.Text
        Dim code_product As String = TECode.Text
        TEFullCode.Text = code_design & code_product
    End Sub
    Private Sub TECode_EditValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TECode.EditValueChanged
        view_full_code()
    End Sub

    Private Sub BSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BSave.Click
        Dim id_product_tersimpan, query, namex, display_name, full_code, code, inv_method, min_stock, max_stock, min_order, max_order, product_ean_code As String
        namex = addSlashes(TEName.Text)
        display_name = addSlashes(TEDisplayName.Text)
        code = TECode.Text
        full_code = TEFullCode.Text
        inv_method = LEInvMethod.EditValue
        min_order = TEMinOrder.Text
        max_order = TEMaxOrder.Text
        min_stock = TEMinStock.Text
        max_stock = TEMaxStock.Text
        product_ean_code = TEEanCode.Text.ToString

        'validate
        EP_TE_cant_blank(EPMasterProduct, TEName)
        EP_TE_cant_blank(EPMasterProduct, TEDisplayName)
        EP_TE_cant_blank(EPMasterProduct, TECode)
        EP_TE_cant_blank(EPMasterProduct, TEFullCode)
        'EP_TE_cant_blank(EPMasterProduct, TEEanCode)

        Dim query_check As String = "SELECT COUNT(*) as jum_check FROM tb_m_product WHERE product_full_code = '" + TEFullCode.Text + "' "
        If id_product <> "-1" Then
            query_check += "AND id_product!='" + id_product + "' "
        End If
        Dim jum_check As String = execute_query(query_check, 0, True, "", "", "", "")
        If jum_check > 0 Then
            stopCustom("Code invalid/duplicate, please check your input!")
        Else
            If id_product <> "-1" Then
                If dupe <> "-1" Then
                    'dupe
                    'insert
                    'If PictureEdit1.EditValue Is Nothing Or Not formIsValidInPanel(EPMasterProduct, PanC1) Or Not formIsValidInPanel(EPMasterProduct, PanC2) Then
                    If Not formIsValidInPanel(EPMasterProduct, PanC1) Or Not formIsValidInPanel(EPMasterProduct, PanC2) Then
                        errorInput()
                    Else
                        Dim confirm As DialogResult = DevExpress.XtraEditors.XtraMessageBox.Show("Are you sure want to save changes this data?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
                        If confirm = Windows.Forms.DialogResult.Yes Then
                            Cursor = Cursors.WaitCursor
                            query = String.Format("INSERT INTO tb_m_product(product_name,product_display_name,product_code,product_full_code,inv_min_stock,inv_max_stock,id_method,order_min,order_max,id_design, product_ean_code) VALUES('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}', '{10}');SELECT LAST_INSERT_ID() ", namex, display_name, code, full_code, min_stock, max_stock, inv_method, min_order, max_order, id_design, product_ean_code)
                            id_product_tersimpan = execute_query(query, 0, True, "", "", "", "")
                            'insert default price
                            query = String.Format("INSERT INTO tb_m_product_price(id_product,product_price_name,id_currency,product_price,product_price_date) VALUES('{0}','Default Price','1','0',DATE(NOW()))", id_product_tersimpan)
                            execute_non_query(query, True, "", "", "", "")

                            'insert generate ean
                            Dim query_gen As String = "CALL generate_vendor_code('" + FormMasterDesignSingle.id_range_par + "', '" + id_product_tersimpan + "'); "
                            execute_non_query(query_gen, True, "", "", "", "")

                            'cek image
                            'save_image(PictureEdit1, product_image_path, id_product_tersimpan & ".jpg")
                            query = String.Format("DELETE FROM tb_m_product_code WHERE id_product='" & id_product_tersimpan & "'")
                            execute_non_query(query, True, "", "", "", "")
                            For i As Integer = 0 To GVCode.RowCount - 1
                                Try
                                    If Not GVCode.GetRowCellValue(i, "value").ToString = "" Or GVCode.GetRowCellValue(i, "value").ToString = 0 Then
                                        query = String.Format("INSERT INTO tb_m_product_code(id_product,id_code_detail) VALUES('{0}','{1}')", id_product_tersimpan, GVCode.GetRowCellValue(i, "value").ToString)
                                        execute_non_query(query, True, "", "", "", "")
                                    End If
                                Catch ex As Exception
                                End Try
                            Next


                            If form_name = "-1" Then
                                FormMasterProduct.view_product(id_design)
                                FormMasterProduct.GVProduct.FocusedRowHandle = find_row(FormMasterProduct.GVProduct, "id_product", id_product)
                            Else
                                'input to PD DET TABLE
                                If form_name = "FormMasterDesignSingle" Then
                                    Dim query_c As ClassDesign = New ClassDesign()
                                    query_c.insertToLineListDet(id_design, id_product_tersimpan)
                                    FormMasterDesignSingle.loadLineList(FormMasterDesignSingle.id_prod_demand_design_active)
                                End If

                                FormMasterDesignSingle.view_product(id_design)
                                FormMasterDesignSingle.GVProduct.FocusedRowHandle = find_row(FormMasterDesignSingle.GVProduct, "id_product", id_product)
                                If FormMasterDesignSingle.form_name = "-1" Then
                                    FormMasterProduct.view_design()
                                    FormMasterProduct.GVDesign.FocusedRowHandle = find_row(FormMasterProduct.GVDesign, "id_design", id_design)
                                ElseIf FormMasterDesignSingle.form_name = "FormFGLineList" Then
                                    FormFGLineList.viewLineList()
                                    FormFGLineList.BGVLineList.FocusedRowHandle = find_row(FormFGLineList.BGVLineList, "id_design", id_design)
                                End If
                            End If
                            Close()
                            Dispose()
                            Cursor = Cursors.Default
                        End If
                    End If
                Else
                    'edit
                    'If PictureEdit1.EditValue Is Nothing Or Not formIsValidInPanel(EPMasterProduct, PanC1) Or Not formIsValidInPanel(EPMasterProduct, PanC2) Then
                    If Not formIsValidInPanel(EPMasterProduct, PanC1) Or Not formIsValidInPanel(EPMasterProduct, PanC2) Then
                        errorInput()
                    Else
                        Dim confirm As DialogResult = DevExpress.XtraEditors.XtraMessageBox.Show("Are you sure want to save changes this data?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
                        If confirm = Windows.Forms.DialogResult.Yes Then
                            Cursor = Cursors.WaitCursor
                            query = String.Format("UPDATE tb_m_product SET product_name='{0}',product_display_name='{1}',product_code='{2}',product_full_code='{3}',inv_min_stock='{4}',inv_max_stock='{5}',id_method='{6}',order_min='{7}',order_max='{8}', product_ean_code='" + product_ean_code + "' WHERE id_product='{9}'", namex, display_name, code, full_code, min_stock, max_stock, inv_method, min_order, max_order, id_product)
                            execute_non_query(query, True, "", "", "", "")

                            'save_image(PictureEdit1, product_image_path, id_design & ".jpg")
                            query = String.Format("DELETE FROM tb_m_product_code WHERE id_product='" & id_product & "'")
                            execute_non_query(query, True, "", "", "", "")
                            For i As Integer = 0 To GVCode.RowCount - 1
                                Try
                                    If Not GVCode.GetRowCellValue(i, "value").ToString = "" Or GVCode.GetRowCellValue(i, "value").ToString = "0" Then
                                        query = String.Format("INSERT INTO tb_m_product_code(id_product,id_code_detail) VALUES('{0}','{1}')", id_product, GVCode.GetRowCellValue(i, "value").ToString)
                                        execute_non_query(query, True, "", "", "", "")
                                    End If
                                Catch ex As Exception
                                End Try
                            Next
                            If form_name = "-1" Then
                                FormMasterProduct.view_product(id_design)
                                FormMasterProduct.GVProduct.FocusedRowHandle = find_row(FormMasterProduct.GVProduct, "id_product", id_product)
                            ElseIf form_name = "FormFGProdList" Then
                                If CheckEdit1.EditValue = "True" And id_role_login = id_role_admin_super Then
                                    Dim query_gen_new As String = "CALL generate_vendor_code('" + FormFGProdList.GVProdList.GetFocusedRowCellValue("id_range").ToString + "', '" + id_product + "'); "
                                    execute_non_query(query_gen_new, True, "", "", "", "")
                                End If
                                Dim act_fil As String = FormFGProdList.GVProdList.ActiveFilterString.ToString
                                FormFGProdList.viewProd()
                                FormFGProdList.GVProdList.ActiveFilterString = act_fil
                                If act_fil = "" Then
                                    FormFGProdList.GVProdList.FocusedRowHandle = find_row(FormFGProdList.GVProdList, "id_product", id_product)
                                End If
                            Else
                                FormMasterDesignSingle.view_product(id_design)
                                FormMasterDesignSingle.GVProduct.FocusedRowHandle = find_row(FormMasterDesignSingle.GVProduct, "id_product", id_product)
                                If FormMasterDesignSingle.form_name = "-1" Then
                                    FormMasterProduct.view_design()
                                    FormMasterProduct.GVDesign.FocusedRowHandle = find_row(FormMasterProduct.GVDesign, "id_design", id_design)
                                ElseIf FormMasterDesignSingle.form_name = "FormFGLineList" Then
                                    FormFGLineList.viewLineList()
                                    FormFGLineList.BGVLineList.FocusedRowHandle = find_row(FormFGLineList.BGVLineList, "id_design", id_design)
                                    FormMasterDesignSingle.loadLineList(FormMasterDesignSingle.id_prod_demand_design_active)
                                End If
                            End If
                            Close()
                            Dispose()
                            Cursor = Cursors.Default
                        End If
                    End If
                End If
            Else
                'insert
                'If PictureEdit1.EditValue Is Nothing Or Not formIsValidInPanel(EPMasterProduct, PanC1) Or Not formIsValidInPanel(EPMasterProduct, PanC2) Then
                If Not formIsValidInPanel(EPMasterProduct, PanC1) Or Not formIsValidInPanel(EPMasterProduct, PanC2) Then
                    errorInput()
                Else
                    Dim confirm As DialogResult = DevExpress.XtraEditors.XtraMessageBox.Show("Are you sure want to save changes this data?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
                    If confirm = Windows.Forms.DialogResult.Yes Then
                        query = String.Format("INSERT INTO tb_m_product(product_name,product_display_name,product_code,product_full_code,inv_min_stock,inv_max_stock,id_method,order_min,order_max,id_design, product_ean_code) VALUES('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}', '{10}'); SELECT LAST_INSERT_ID() ", namex, display_name, code, full_code, min_stock, max_stock, inv_method, min_order, max_order, id_design, product_ean_code)
                        id_product_tersimpan = execute_query(query, 0, True, "", "", "", "")
                        'insert default price
                        query = String.Format("INSERT INTO tb_m_product_price(id_product,product_price_name,id_currency,product_price,product_price_date) VALUES('{0}','Default Price','1','0',DATE(NOW()))", id_product_tersimpan)
                        execute_non_query(query, True, "", "", "", "")

                        'insert generate ean
                        Dim query_gen As String = "CALL generate_vendor_code('" + FormMasterDesignSingle.id_range_par + "', '" + id_product_tersimpan + "'); "
                        execute_non_query(query_gen, True, "", "", "", "")

                        'cek image
                        'save_image(PictureEdit1, product_image_path, id_product_tersimpan & ".jpg")
                        query = String.Format("DELETE FROM tb_m_product_code WHERE id_code_detail='" & id_product_tersimpan & "'")
                        execute_non_query(query, True, "", "", "", "")
                        For i As Integer = 0 To GVCode.RowCount - 1
                            Try
                                If Not GVCode.GetRowCellValue(i, "value").ToString = "" Or GVCode.GetRowCellValue(i, "value").ToString = 0 Then
                                    query = String.Format("INSERT INTO tb_m_product_code(id_product,id_code_detail) VALUES('{0}','{1}')", id_product_tersimpan, GVCode.GetRowCellValue(i, "value").ToString)
                                    execute_non_query(query, True, "", "", "", "")
                                End If
                            Catch ex As Exception
                            End Try
                        Next
                        If form_name = "-1" Then
                            FormMasterProduct.view_product(id_design)
                            FormMasterProduct.GVProduct.FocusedRowHandle = find_row(FormMasterProduct.GVProduct, "id_product", id_product)
                        Else
                            'input to PD DET TABLE
                            If form_name = "FormMasterDesignSingle" Then
                                Dim query_c As ClassDesign = New ClassDesign()
                                query_c.insertToLineListDet(id_design, id_product_tersimpan)
                                FormMasterDesignSingle.loadLineList(FormMasterDesignSingle.id_prod_demand_design_active)
                            End If

                            FormMasterDesignSingle.view_product(id_design)
                            FormMasterDesignSingle.GVProduct.FocusedRowHandle = find_row(FormMasterDesignSingle.GVProduct, "id_product", id_product)
                            If FormMasterDesignSingle.form_name = "-1" Then
                                FormMasterProduct.view_design()
                                FormMasterProduct.GVDesign.FocusedRowHandle = find_row(FormMasterProduct.GVDesign, "id_design", id_design)
                            ElseIf FormMasterDesignSingle.form_name = "FormFGLineList" Then
                                FormFGLineList.viewLineList()
                                FormFGLineList.BGVLineList.FocusedRowHandle = find_row(FormFGLineList.BGVLineList, "id_design", id_design)
                            End If
                        End If
                        Close()
                        Dispose()
                    End If
                End If
            End If
        End If

        
    End Sub

    
    Private Sub TEName_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TEName.Validating
        EP_TE_cant_blank(EPMasterProduct, TEName)
    End Sub

    Private Sub TEDisplayName_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TEDisplayName.Validating
        EP_TE_cant_blank(EPMasterProduct, TEDisplayName)
    End Sub

    Private Sub TEMinStock_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TEMinStock.Validating
        'If TEMinStock.Text.Length < 1 Then
        '    EPMasterProduct.SetError(TEMinStock, "Not a valid input.")
        'Else
        '    EPMasterProduct.SetError(TEMinStock, String.Empty)
        'End If
    End Sub

    Private Sub TEMaxStock_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TEMaxStock.Validating
        'If TEMaxStock.Text.Length < 1 Then
        '    EPMasterProduct.SetError(TEMaxStock, "Not a valid input.")
        'Else
        '    EPMasterProduct.SetError(TEMaxStock, String.Empty)
        'End If
    End Sub

    Private Sub TEMinOrder_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TEMinOrder.Validating
        'If TEMinOrder.Text.Length < 1 Then
        '    EPMasterProduct.SetError(TEMinOrder, "Not a valid input.")
        'Else
        '    EPMasterProduct.SetError(TEMinOrder, String.Empty)
        'End If
    End Sub

    Private Sub TEMaxOrder_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TEMaxOrder.Validating
        'If TEMaxOrder.Text.Length < 1 Then
        '    EPMasterProduct.SetError(TEMaxOrder, "Not a valid input.")
        'Else
        '    EPMasterProduct.SetError(TEMaxOrder, String.Empty)
        'End If
    End Sub

    Private Sub TEFullCode_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TEFullCode.Validating
        EP_TE_cant_blank(EPMasterProduct, TEFullCode)
    End Sub

    Private Sub TECode_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TECode.Validating
        EP_TE_cant_blank(EPMasterProduct, TECode)
    End Sub
    'Private Sub BGenerateDN_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BGenerateDN.Click
    '    Dim string_name As String = ""
    '    Dim id_code, code, query As String

    '    For i As Integer = 0 To GVCode.RowCount - 1
    '        code = ""
    '        id_code = ""
    '        Try
    '            id_code = GVCode.GetRowCellValue(i, "value").ToString
    '        Catch ex As Exception
    '            id_code = ""
    '        End Try

    '        If Not id_code = "" Or id_code = "0" Then
    '            query = String.Format("SELECT tb_m_code.is_include_name FROM tb_m_code,tb_m_code_detail WHERE tb_m_code.id_code=tb_m_code_detail.id_code AND tb_m_code_detail.id_code_detail='" & id_code & "'")
    '            code = execute_query(query, 0, True, "", "", "", "")
    '            If code.ToString = "True" Then
    '                query = String.Format("SELECT display_name FROM tb_m_code_detail WHERE id_code_detail='" & id_code & "'")
    '                code = execute_query(query, 0, True, "", "", "", "")
    '                string_name += " " & code
    '            End If
    '        End If
    '    Next

    '    TEDisplayName.Text = TEName.Text.ToUpper & string_name.ToUpper
    '    LabelPrintedName.Text = TEName.Text.ToUpper & string_name.ToUpper
    'End Sub
    '============= begin code price ================
    Sub view_product_price(ByVal id_productx As String)
        Dim query As String = "SELECT tb_m_product_price.is_print,tb_m_product_price.id_product_price,tb_m_product_price.product_price_name,tb_m_product_price.product_price,tb_m_product_price.product_price_date,tb_lookup_currency.currency FROM tb_m_product_price,tb_lookup_currency WHERE tb_m_product_price.id_currency=tb_lookup_currency.id_currency AND tb_m_product_price.id_product='" & id_productx & "' ORDER BY tb_m_product_price.id_product_price DESC"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCProductPrice.DataSource = data

        If data.Rows.Count < 1 Then
            Bdelete.Visible = False
            Bedit.Visible = False
        Else
            Bdelete.Visible = True
            Bedit.Visible = True
        End If
    End Sub

    Private Sub BAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BAdd.Click
        FormProductPriceSingle.id_product = id_product
        FormProductPriceSingle.ShowDialog()
    End Sub

    Private Sub Bedit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Bedit.Click
        FormProductPriceSingle.id_product = id_product
        FormProductPriceSingle.id_product_price = GVProductPrice.GetFocusedRowCellDisplayText("id_product_price").ToString
        FormProductPriceSingle.ShowDialog()
    End Sub

    Private Sub Bdelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Bdelete.Click
        'delete
        Dim confirm As DialogResult
        Dim query As String
        confirm = DevExpress.XtraEditors.XtraMessageBox.Show("Are you sure want to delete this data?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)

        Dim id_product_price As String = GVProductPrice.GetFocusedRowCellDisplayText("id_product_price").ToString
        If confirm = Windows.Forms.DialogResult.Yes Then
            Cursor = Cursors.WaitCursor
            Try
                query = String.Format("DELETE FROM tb_m_product_price WHERE id_product_price = '{0}'", id_product_price)
                execute_non_query(query, True, "", "", "", "")
                view_product_price(id_product)
            Catch ex As Exception
                DevExpress.XtraEditors.XtraMessageBox.Show("This data already used. Can't delete.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
            Cursor = Cursors.Default
        End If
    End Sub
    '===========================begin movement===============================
    Sub view_movement(ByVal id_productx As String)
        Dim query As String = "SELECT a.id_product_movement,d.movement_category,c.comp_name,a.product_movement_qty,a.product_movement_tot_price,CONCAT(DATE(a.product_movement_datetime),' ',TIME(a.product_movement_datetime)) AS datetimex "
        query += "FROM tb_m_product_movement a, tb_m_comp_contact b, tb_m_comp c, tb_lookup_movement_category d "
        query += "WHERE a.id_comp_contact = b.id_comp_contact And b.id_comp = c.id_comp "
        query += "AND d.id_movement_category = a.id_movement_category "
        query += "AND a.id_product = '" & id_productx & "'"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCProductMovement.DataSource = data
    End Sub

    Private Sub TEEanCode_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TEEanCode.Validating
        'EP_TE_cant_blank(EPMasterProduct, TEEanCode)
    End Sub

    Private Sub BRefreshCode_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BRefreshCode.Click
        load_isi_param()
        load_template(LETemplate.EditValue)
    End Sub

    Private Sub BeditCode_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BeditCode.Click
        FormCodeTemplateEdit.id_pop_up = "3"
        FormCodeTemplateEdit.id_template_code = LETemplate.EditValue.ToString
        FormCodeTemplateEdit.ShowDialog()
    End Sub

    
End Class