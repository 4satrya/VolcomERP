Public Class FormVerificationMasterOLDet
    Public id_verification_master As String = "-1"

    Private Sub FormVerificationMasterOLDet_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        view_slue_online_store()
        view_slue_division()
        view_template()

        form_load()
    End Sub

    Sub form_load()
        If Not id_verification_master = "-1" Then
            Dim id_comp As String = execute_query("SELECT id_comp FROM tb_verification_master WHERE id_verification_master = '" + id_verification_master + "'", 0, True, "", "", "", "")
            Dim id_template As String = execute_query("SELECT id_template FROM tb_verification_master WHERE id_verification_master = '" + id_verification_master + "'", 0, True, "", "", "", "")
            Dim id_code_detail As String = execute_query("SELECT id_code_detail FROM tb_verification_master WHERE id_verification_master = '" + id_verification_master + "'", 0, True, "", "", "", "")
            Dim file_name As String = execute_query("SELECT file_name FROM tb_verification_master WHERE id_verification_master = '" + id_verification_master + "'", 0, True, "", "", "", "")

            SLUEOnlineStore.EditValue = id_comp
            SLUETemplate.EditValue = id_template
            SLUEDivision.EditValue = id_code_detail
            TEFileName.EditValue = file_name

            Dim query As String = ""

            If id_comp = "653" Then
                query = "
                    SELECT SkuSupplierConfig, Name, Brand, Color, ParentSku, SellerSku, Price, SalePrice, Variation, SkuSupplierConfig_erp, Name_erp, Brand_erp, Color_erp, ParentSku_erp, SellerSku_erp, Price_erp, SalePrice_erp, Variation_erp
                    FROM tb_verification_master_zalora
                    WHERE id_verification_master = '" + id_verification_master + "'
                "
            ElseIf id_comp = "1177" Then
                If id_template = "1" Then
                    query = "
                        SELECT NamaProduk, SellerSKU, Ukuran, Warna, Parent, KodeTokoGudang, HargaRp, HargaPenjualanRp, NamaProduk_erp, SellerSKU_erp, Ukuran_erp, Warna_erp, Parent_erp, KodeTokoGudang_erp, HargaRp_erp, HargaPenjualanRp_erp
                        FROM tb_verification_master_blibli
                        WHERE id_verification_master = '" + id_verification_master + "'
                    "
                ElseIf id_template = "2" Then
                    query = "
                        SELECT NamaProduk, SellerSKU, HargaRp, HargaPenjualanRp, TokoGudang, NamaProduk_erp, SellerSKU_erp, HargaRp_erp, HargaPenjualanRp_erp, TokoGudang_erp
                        FROM tb_verification_master_blibli_update
                        WHERE id_verification_master = '" + id_verification_master + "'
                    "
                End If
            ElseIf id_comp = "1212" Then
                query = "
                    SELECT Option1Value, VariantSKU, VariantPrice, VariantCompareAtPrice, VariantBarcode, Option1Value_erp, VariantSKU_erp, VariantPrice_erp, VariantCompareAtPrice_erp, VariantBarcode_erp
                    FROM tb_verification_master_volcom
                    WHERE id_verification_master = '" + id_verification_master + "'
                "
            ElseIf id_comp = "1286" Then
                If id_template = "1" Then
                    query = "
                        SELECT NamaProduk, SKUInduk, KodeIntegrasiVariasi, VarianuntukVariasi1, Harga, KodeVariasi, NamaProduk_erp, SKUInduk_erp, KodeIntegrasiVariasi_erp, VarianuntukVariasi1_erp, Harga_erp, KodeVariasi_erp
                        FROM tb_verification_master_shopee
                        WHERE id_verification_master = '" + id_verification_master + "'
                    "
                ElseIf id_template = "2" Then
                    query = "
                        SELECT ProductNameOptional, NamaVariasiOpsional, SKURefNoOptional, HargaAwalOpsional, Hargadiskon, ProductNameOptional_erp, NamaVariasiOpsional_erp, SKURefNoOptional_erp, HargaAwalOpsional_erp, Hargadiskon_erp
                        FROM tb_verification_master_shopee_update
                        WHERE id_verification_master = '" + id_verification_master + "'
                    "
                End If
            End If

            Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")

            Dim data_excel As DataTable = New DataTable
            Dim data_erp As DataTable = New DataTable

            'add column
            For i = 0 To data.Columns.Count - 1
                Dim column_name As String = data.Columns(i).ColumnName

                If Not column_name.Contains("_erp") Then
                    data_excel.Columns.Add(column_name, GetType(String))
                    data_erp.Columns.Add(column_name, GetType(String))
                End If
            Next

            'add column is valid
            For i = 0 To data.Columns.Count - 1
                Dim column_name As String = data.Columns(i).ColumnName

                If Not column_name.Contains("_erp") Then
                    data_excel.Columns.Add("IsValid" + column_name, GetType(String))
                    data_erp.Columns.Add("IsValid" + column_name, GetType(String))
                End If
            Next

            'add data
            For i = 0 To data.Rows.Count - 1
                Dim data_excel_row As DataRow = data_excel.NewRow
                Dim data_erp_row As DataRow = data_erp.NewRow

                Dim is_insert As Boolean = False

                For j = 0 To data.Columns.Count - 1
                    Dim column_name As String = data.Columns(j).ColumnName

                    If Not column_name.Contains("_erp") And Not column_name.Contains("IsValid") Then
                        data_excel_row(column_name) = data.Rows(i)(column_name).ToString
                        data_erp_row(column_name) = data.Rows(i)(column_name + "_erp").ToString

                        data_excel_row("IsValid" + column_name) = "0"
                        data_erp_row("IsValid" + column_name) = "0"

                        If Not data.Rows(i)(column_name + "_erp").ToString = "" Then
                            is_insert = True
                        End If
                    End If
                Next

                data_excel.Rows.Add(data_excel_row)

                If is_insert Then
                    data_erp.Rows.Add(data_erp_row)
                End If
            Next

            'selected column
            Dim selected_column As String = ""

            If id_comp = "653" Then
                selected_column = "SellerSKU"
            ElseIf id_comp = "1177" Then
                selected_column = "SellerSKU"
            ElseIf id_comp = "1212" Then
                selected_column = "VariantSKU"
            ElseIf id_comp = "1286" Then
                If id_template = "1" Then
                    selected_column = "KodeVariasi"
                ElseIf id_template = "2" Then
                    selected_column = "SKURefNoOptional"
                End If
            End If

            'validation
            For i = 0 To data_excel.Rows.Count - 1
                For j = 0 To data_erp.Rows.Count - 1
                    If data_excel.Rows(i)(selected_column).ToString = data_erp.Rows(j)(selected_column).ToString Then
                        For k = 0 To data.Columns.Count - 1
                            Dim column_name As String = data.Columns(k).ColumnName

                            If Not column_name.Contains("_erp") And Not column_name.Contains("IsValid") Then
                                If data_excel.Rows(i)(column_name).ToString = data_erp.Rows(j)(column_name).ToString Then
                                    data_excel.Rows(i)("IsValid" + column_name) = "1"
                                End If
                            End If
                        Next
                    End If
                Next
            Next

            'combine data is valid
            For i = 0 To data_erp.Rows.Count - 1
                For j = 0 To data_excel.Rows.Count - 1
                    If data_erp.Rows(i)(selected_column).ToString = data_excel.Rows(j)(selected_column).ToString Then
                        For k = 0 To data.Columns.Count - 1
                            Dim column_name As String = data.Columns(k).ColumnName

                            If Not column_name.Contains("_erp") And Not column_name.Contains("IsValid") Then
                                data_erp.Rows(i)("IsValid" + column_name) = data_excel.Rows(j)("IsValid" + column_name)
                            End If
                        Next

                        Exit For
                    End If
                Next
            Next

            GCVerification.DataSource = data_excel
            GCERP.DataSource = data_erp

            'hide column
            For i = 0 To GVVerification.Columns.Count - 1
                Dim gv_column As DevExpress.XtraGrid.Columns.GridColumn = GVVerification.Columns(i)

                If gv_column.Name.Contains("IsValid") Then
                    gv_column.Visible = False
                End If
            Next

            For i = 0 To GVERP.Columns.Count - 1
                Dim gv_column As DevExpress.XtraGrid.Columns.GridColumn = GVERP.Columns(i)

                If gv_column.Name.Contains("IsValid") Then
                    gv_column.Visible = False
                End If
            Next

            GVVerification.BestFitColumns()
            GVERP.BestFitColumns()

            'controls
            SLUEOnlineStore.ReadOnly = True
            SLUETemplate.ReadOnly = True
            SLUEDivision.ReadOnly = True
            TEFileName.ReadOnly = True
            SBImportExcel.Enabled = False
        Else
            SLUEOnlineStore.EditValue = "0"
            SLUEDivision.EditValue = "0"
            TEFileName.EditValue = ""
        End If

        TEFileName.ReadOnly = True
    End Sub

    Private Sub FormVerificationMasterOLDet_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        FormVerificationMasterOL.form_load()

        Dispose()
    End Sub

    Sub view_slue_online_store()
        Dim query_in As String = ""

        If id_departement_user = "11" Then
            query_in = "653, 1177, 1286"
        ElseIf id_departement_user = "9" Then
            query_in = "1212"
        Else
            query_in = "0"
        End If

        If id_role_login = "1" Then
            query_in = "653, 1177, 1286, 1212"
        End If

        Dim query As String = "
            SELECT 0 AS id_comp, '' AS comp_name
            UNION ALL
            SELECT id_comp, REPLACE(REPLACE(comp_name, 'NORMAL', ''), '()', '') AS comp_name FROM tb_m_comp WHERE id_comp IN (" + query_in + ")
        "

        viewSearchLookupQuery(SLUEOnlineStore, query, "id_comp", "comp_name", "id_comp")
    End Sub

    Sub view_slue_division()
        Dim query As String = "
            SELECT 0 AS id_code_detail, '' AS display_name
            UNION ALL
            SELECT id_code_detail, display_name
            FROM tb_m_code_detail AS cd
            WHERE id_code = 32
        "

        viewSearchLookupQuery(SLUEDivision, query, "id_code_detail", "display_name", "id_code_detail")
    End Sub

    Private Sub SBImportExcel_Click(sender As Object, e As EventArgs) Handles SBImportExcel.Click
        If Not SLUEOnlineStore.EditValue.ToString = "0" And Not SLUEDivision.EditValue.ToString = "0" Then
            Dim file_dialog As OpenFileDialog = New OpenFileDialog

            file_dialog.Title = "Browse file..."
            file_dialog.Multiselect = False
            file_dialog.Filter = "All Files | *.*"
            file_dialog.ShowDialog()

            Dim is_already As String = execute_query("
                SELECT COUNT(*) FROM tb_verification_master WHERE file_name = '" + addSlashes(file_dialog.SafeFileName) + "'
            ", 0, True, "", "", "", "")

            If is_already = "0" Then
                TEFileName.EditValue = file_dialog.SafeFileName

                If SLUEOnlineStore.EditValue.ToString = "653" Then
                    check_zalora(file_dialog.FileName)
                ElseIf SLUEOnlineStore.EditValue.ToString = "1177" Then
                    check_blibli(file_dialog.FileName)
                ElseIf SLUEOnlineStore.EditValue.ToString = "1212" Then
                    check_volcom(file_dialog.FileName)
                ElseIf SLUEOnlineStore.EditValue.ToString = "1286" Then
                    check_shopee(file_dialog.FileName)
                End If
            Else
                errorCustom("File name already imported.")
            End If
        Else
            errorCustom("Please select online store and division.")
        End If
    End Sub

    Sub check_zalora(file_name As String)
        Dim app As New Microsoft.Office.Interop.Excel.Application
        Dim worksheet As Microsoft.Office.Interop.Excel.Worksheet
        Dim workbook As Microsoft.Office.Interop.Excel.Workbook

        app.DisplayAlerts = False

        If Not file_name = "" Then
            Cursor = Cursors.WaitCursor

            GCVerification.DataSource = Nothing
            GVVerification.Columns.Clear()

            GCERP.DataSource = Nothing
            GVERP.Columns.Clear()

            Try
                workbook = app.Workbooks.Open(file_name)
                worksheet = workbook.Worksheets("Upload Template")

                Dim data_excel As DataTable = New DataTable

                Dim row As Integer = 0
                Dim column As Integer = 0

                Dim continue_loop As Boolean = False

                Dim column_check As List(Of String) = New List(Of String)

                column_check.Add("SkuSupplierConfig")
                column_check.Add("Name")
                column_check.Add("Brand")
                column_check.Add("Color")
                column_check.Add("ParentSku")
                column_check.Add("SellerSku")
                column_check.Add("Price")
                column_check.Add("SalePrice")
                column_check.Add("Variation")

                'column
                row = 3
                column = 1

                continue_loop = True

                While continue_loop
                    Dim column_name As String = worksheet.Cells(row, column).Value

                    If Not column_name = "" Then
                        column_name = column_name.Substring(0, column_name.IndexOf(" "))

                        data_excel.Columns.Add(column_name, GetType(String))
                    Else
                        continue_loop = False
                    End If

                    column += 1
                End While

                'row
                Dim id_product_in As String = ""

                row = 4
                column = 1

                continue_loop = True

                While continue_loop
                    Dim empty_all As Boolean = False

                    Dim data_excel_row As DataRow = data_excel.NewRow

                    For i = 0 To data_excel.Columns.Count - 1
                        Dim column_name As String = data_excel.Columns(i).ColumnName
                        Dim value As String = worksheet.Cells(row, i + 1).Value

                        data_excel_row(column_name) = value

                        If column_name = "SellerSku" Then
                            id_product_in += value + ", "
                        End If

                        If Not value = "" Then
                            empty_all = True
                        End If
                    Next

                    If empty_all Then
                        data_excel.Rows.Add(data_excel_row)
                    Else
                        continue_loop = False
                    End If

                    row += 1
                End While

                workbook.Close()

                app.Quit()

                'remove column
                column = 0

                continue_loop = True

                While continue_loop
                    Dim column_name As String = ""

                    Try
                        column_name = data_excel.Columns(column).ColumnName
                    Catch ex As Exception
                        continue_loop = False
                    End Try

                    If Not column_name = "" Then
                        If column_check.IndexOf(column_name) < 0 Then
                            data_excel.Columns.Remove(column_name)
                        Else
                            column += 1
                        End If
                    End If
                End While

                'add column
                For i = 0 To column_check.Count - 1
                    data_excel.Columns.Add("IsValid" + column_check(i), GetType(String))
                Next

                'add column value
                For i = 0 To data_excel.Rows.Count - 1
                    For j = 0 To column_check.Count - 1
                        data_excel.Rows(i)("IsValid" + column_check(j)) = "0"
                    Next
                Next

                'data erp
                Dim column_is_valid As String = ""

                For i = 0 To column_check.Count - 1
                    column_is_valid += ", 0 AS IsValid" + column_check(i) + ""
                Next

                Dim data_erp As DataTable = execute_query("
                    SELECT de.design_code AS SkuSupplierConfig, de.design_display_name AS Name, 'Volcom' AS Brand, color.code_detail_name AS Color, pro_parent.product_full_code AS ParentSku, pro.product_full_code AS SellerSku, FLOOR(de_pn.design_price) AS Price, IF(de_pc.id_design_price_type = 1, '', FLOOR(de_pc.design_price)) AS SalePrice, cd_det.display_name AS Variation " + column_is_valid + "
                    FROM tb_m_product AS pro
                    LEFT JOIN tb_m_design AS de ON pro.id_design = de.id_design
                    LEFT JOIN (
                        SELECT id_design, design_price, id_design_price_type
                        FROM tb_m_design_price
                        WHERE id_design_price IN (
                            SELECT MAX(id_design_price) AS id_design_price
                            FROM tb_m_design_price
                            WHERE design_price_start_date <= NOW() AND is_active_wh = 1 AND is_design_cost = 0
                            GROUP BY id_design
                        )
                    ) AS de_pc ON de.id_design = de_pc.id_design
                    LEFT JOIN (
                        SELECT id_design, design_price
                        FROM tb_m_design_price
                        WHERE id_design_price IN (
                            SELECT MAX(id_design_price) AS id_design_price
                            FROM tb_m_design_price
                            WHERE design_price_start_date <= NOW() AND is_active_wh = 1 AND is_design_cost = 0 AND id_design_price_type = 1
                            GROUP BY id_design
                        )
                    ) AS de_pn ON de.id_design = de_pn.id_design
                    LEFT JOIN (
                        SELECT id_design, MIN(product_full_code) AS product_full_code
                        FROM tb_m_product
                        GROUP BY id_design
                    ) AS pro_parent ON de.id_design = pro_parent.id_design
                    LEFT JOIN (
                        SELECT dc.id_design, cd.code_detail_name
                        FROM tb_m_design_code AS dc
                        INNER JOIN tb_m_code_detail AS cd ON dc.id_code_detail = cd.id_code_detail AND cd.id_code = 14
                    ) AS color ON de.id_design = color.id_design
                    LEFT JOIN tb_m_product_code AS pro_cd ON pro.id_product = pro_cd.id_product
                    LEFT JOIN tb_m_code_detail AS cd_det ON pro_cd.id_code_detail = cd_det.id_code_detail
                    WHERE pro.product_full_code IN (" + id_product_in.Substring(0, id_product_in.Length - 4) + ")
                    ORDER BY pro.product_full_code ASC
                ", -1, True, "", "", "", "")

                'validation
                For i = 0 To data_excel.Rows.Count - 1
                    For j = 0 To data_erp.Rows.Count - 1
                        If data_excel.Rows(i)("SellerSku").ToString = data_erp.Rows(j)("SellerSku").ToString Then
                            For k = 0 To column_check.Count - 1
                                If data_excel.Rows(i)(column_check(k)).ToString = data_erp.Rows(j)(column_check(k)).ToString Then
                                    data_excel.Rows(i)("IsValid" + column_check(k)) = "1"
                                End If
                            Next
                        End If
                    Next
                Next

                'combine data is valid
                For i = 0 To data_erp.Rows.Count - 1
                    For j = 0 To data_excel.Rows.Count - 1
                        If data_erp.Rows(i)("SellerSku").ToString = data_excel.Rows(j)("SellerSku").ToString Then
                            For k = 0 To column_check.Count - 1
                                data_erp.Rows(i)("IsValid" + column_check(k)) = data_excel.Rows(j)("IsValid" + column_check(k))
                            Next

                            Exit For
                        End If
                    Next
                Next

                'check is valid all
                Dim list_is_not_valid As List(Of String) = New List(Of String)

                Dim is_valid_all As Boolean = True

                For i = 0 To data_excel.Rows.Count - 1
                    For j = 0 To column_check.Count - 1
                        If data_excel.Rows(i)("IsValid" + column_check(j)).ToString = "0" Then
                            is_valid_all = False

                            list_is_not_valid.Add(column_check(j))
                        End If
                    Next
                Next

                'sorting
                Dim data_view As DataView = New DataView(data_excel)
                data_view.Sort = "SellerSku ASC"
                data_excel = data_view.ToTable

                'set datasource
                GCVerification.DataSource = data_excel
                GCERP.DataSource = data_erp

                'bestfit
                GVVerification.BestFitColumns()
                GVERP.BestFitColumns()

                'hide column
                For i = 0 To GVVerification.Columns.Count - 1
                    Dim gv_column As DevExpress.XtraGrid.Columns.GridColumn = GVVerification.Columns(i)

                    If gv_column.Name.Contains("IsValid") Then
                        gv_column.Visible = False
                    End If
                Next

                For i = 0 To GVERP.Columns.Count - 1
                    Dim gv_column As DevExpress.XtraGrid.Columns.GridColumn = GVERP.Columns(i)

                    If gv_column.Name.Contains("IsValid") Then
                        gv_column.Visible = False
                    End If
                Next

                'store data if valid
                If is_valid_all Then
                    'save to database
                    Dim query As String = ""

                    'header
                    query = "INSERT INTO tb_verification_master (id_comp, file_name, id_code_detail, created_date, created_by) VALUES (" + SLUEOnlineStore.EditValue.ToString + ", '" + addSlashes(TEFileName.EditValue.ToString) + "', " + SLUEDivision.EditValue.ToString + ", NOW(), " + id_employee_user + "); SELECT LAST_INSERT_ID();"

                    id_verification_master = execute_query(query, 0, True, "", "", "", "")

                    'detail
                    query = "INSERT INTO tb_verification_master_zalora (id_verification_master, SkuSupplierConfig, Name, Brand, Color, ParentSku, SellerSku, Price, SalePrice, Variation, SkuSupplierConfig_erp, Name_erp, Brand_erp, Color_erp, ParentSku_erp, SellerSku_erp, Price_erp, SalePrice_erp, Variation_erp) VALUES "

                    For i = 0 To data_excel.Rows.Count - 1
                        Dim SkuSupplierConfig As String = data_excel.Rows(i)("SkuSupplierConfig").ToString
                        Dim Name As String = data_excel.Rows(i)("Name").ToString
                        Dim Brand As String = data_excel.Rows(i)("Brand").ToString
                        Dim Color As String = data_excel.Rows(i)("Color").ToString
                        Dim ParentSku As String = data_excel.Rows(i)("ParentSku").ToString
                        Dim SellerSku As String = data_excel.Rows(i)("SellerSku").ToString
                        Dim Price As String = data_excel.Rows(i)("Price").ToString
                        Dim SalePrice As String = data_excel.Rows(i)("SalePrice").ToString
                        Dim Variation As String = data_excel.Rows(i)("Variation").ToString

                        Dim SkuSupplierConfig_erp As String = ""
                        Dim Name_erp As String = ""
                        Dim Brand_erp As String = ""
                        Dim Color_erp As String = ""
                        Dim ParentSku_erp As String = ""
                        Dim SellerSku_erp As String = ""
                        Dim Price_erp As String = ""
                        Dim SalePrice_erp As String = ""
                        Dim Variation_erp As String = ""

                        Try
                            SkuSupplierConfig_erp = data_erp.Rows(i)("SkuSupplierConfig").ToString
                        Catch ex As Exception
                        End Try

                        Try
                            Name_erp = data_erp.Rows(i)("Name").ToString
                        Catch ex As Exception
                        End Try

                        Try
                            Brand_erp = data_erp.Rows(i)("Brand").ToString
                        Catch ex As Exception
                        End Try

                        Try
                            Color_erp = data_erp.Rows(i)("Color").ToString
                        Catch ex As Exception
                        End Try

                        Try
                            ParentSku_erp = data_erp.Rows(i)("ParentSku").ToString
                        Catch ex As Exception
                        End Try

                        Try
                            SellerSku_erp = data_erp.Rows(i)("SellerSku").ToString
                        Catch ex As Exception
                        End Try

                        Try
                            Price_erp = data_erp.Rows(i)("Price").ToString
                        Catch ex As Exception
                        End Try

                        Try
                            SalePrice_erp = data_erp.Rows(i)("SalePrice").ToString
                        Catch ex As Exception
                        End Try

                        Try
                            Variation_erp = data_erp.Rows(i)("Variation").ToString
                        Catch ex As Exception
                        End Try

                        query += "('" + id_verification_master + "', '" + SkuSupplierConfig + "', '" + Name + "', '" + Brand + "', '" + Color + "', '" + ParentSku + "', '" + SellerSku + "', '" + Price + "', '" + SalePrice + "', '" + Variation + "', '" + SkuSupplierConfig_erp + "', '" + Name_erp + "', '" + Brand_erp + "', '" + Color_erp + "', '" + ParentSku_erp + "', '" + SellerSku_erp + "', '" + Price_erp + "', '" + SalePrice_erp + "', '" + Variation_erp + "'), "
                    Next

                    query = query.Substring(0, query.Length - 2)

                    execute_non_query(query, True, "", "", "", "")
                End If

                'warning message
                If is_valid_all Then
                    infoCustom("Excel data is correct.")

                    'controls
                    SLUEOnlineStore.ReadOnly = True
                    SLUEDivision.ReadOnly = True
                    TEFileName.ReadOnly = True
                    SBImportExcel.Enabled = False
                    DropDownButtonExport.Enabled = False
                Else
                    PopupMenuExport.ClearLinks()

                    For i = 0 To list_is_not_valid.Count - 1
                        Dim b As DevExpress.XtraBars.BarButtonItem = New DevExpress.XtraBars.BarButtonItem

                        b.Caption = list_is_not_valid(i) + " Not Matched"
                        b.Tag = list_is_not_valid(i)

                        AddHandler b.ItemClick, AddressOf exportClick

                        PopupMenuExport.AddItem(b)
                    Next

                    DropDownButtonExport.Enabled = True

                    errorCustom("There are some excel data wrong.")
                End If
            Catch ex As Exception
                errorCustom(ex.ToString)
            End Try

            Cursor = Cursors.Default
        End If
    End Sub

    Sub check_blibli(file_name As String)
        Dim app As New Microsoft.Office.Interop.Excel.Application
        Dim worksheet As Microsoft.Office.Interop.Excel.Worksheet
        Dim workbook As Microsoft.Office.Interop.Excel.Workbook

        app.DisplayAlerts = False

        If Not file_name = "" Then
            Cursor = Cursors.WaitCursor

            Try
                workbook = app.Workbooks.Open(file_name)
                worksheet = workbook.Worksheets("Data")

                Dim data_excel As DataTable = New DataTable

                Dim row As Integer = 0
                Dim column As Integer = 0

                Dim continue_loop As Boolean = False

                Dim column_check As List(Of String) = New List(Of String)

                If SLUETemplate.EditValue.ToString = "1" Then
                    column_check.Add("NamaProduk")
                    column_check.Add("SellerSKU")
                    column_check.Add("Ukuran")
                    column_check.Add("Warna")
                    column_check.Add("Parent")
                    column_check.Add("KodeTokoGudang")
                    column_check.Add("HargaRp")
                    column_check.Add("HargaPenjualanRp")
                ElseIf SLUETemplate.EditValue.ToString = "2" Then
                    column_check.Add("NamaProduk")
                    column_check.Add("SellerSKU")
                    column_check.Add("HargaRp")
                    column_check.Add("HargaPenjualanRp")
                    column_check.Add("TokoGudang")
                End If

                'column
                If SLUETemplate.EditValue.ToString = "1" Then
                    row = 2
                    column = 1
                ElseIf SLUETemplate.EditValue.ToString = "2" Then
                    row = 1
                    column = 1
                End If

                continue_loop = True

                While continue_loop
                    Dim column_name As String = worksheet.Cells(row, column).Value

                    If Not column_name = "" Then
                        column_name = System.Text.RegularExpressions.Regex.Replace(column_name, "[^\w\\]", "")

                        data_excel.Columns.Add(column_name, GetType(String))
                    Else
                        continue_loop = False
                    End If

                    column += 1
                End While

                'row
                Dim id_product_in As String = ""

                If SLUETemplate.EditValue.ToString = "1" Then
                    row = 3
                    column = 1
                ElseIf SLUETemplate.EditValue.ToString = "2" Then
                    row = 2
                    column = 1
                End If

                continue_loop = True

                While continue_loop
                    Dim empty_all As Boolean = False

                    Dim data_excel_row As DataRow = data_excel.NewRow

                    For i = 0 To data_excel.Columns.Count - 1
                        Dim column_name As String = data_excel.Columns(i).ColumnName
                        Dim value As String = worksheet.Cells(row, i + 1).Value

                        data_excel_row(column_name) = value

                        If column_name = "SellerSKU" Then
                            id_product_in += value + ", "
                        End If

                        If Not value = "" Then
                            empty_all = True
                        End If
                    Next

                    If empty_all Then
                        data_excel.Rows.Add(data_excel_row)
                    Else
                        continue_loop = False
                    End If

                    row += 1
                End While

                workbook.Close()

                app.Quit()

                'remove column
                column = 0

                continue_loop = True

                While continue_loop
                    Dim column_name As String = ""

                    Try
                        column_name = data_excel.Columns(column).ColumnName
                    Catch ex As Exception
                        continue_loop = False
                    End Try

                    If Not column_name = "" Then
                        If column_check.IndexOf(column_name) < 0 Then
                            data_excel.Columns.Remove(column_name)
                        Else
                            column += 1
                        End If
                    End If
                End While

                'add column
                For i = 0 To column_check.Count - 1
                    data_excel.Columns.Add("IsValid" + column_check(i), GetType(String))
                Next

                'add column value
                For i = 0 To data_excel.Rows.Count - 1
                    For j = 0 To column_check.Count - 1
                        data_excel.Rows(i)("IsValid" + column_check(j)) = "0"
                    Next
                Next

                'data erp
                Dim column_is_valid As String = ""

                For i = 0 To column_check.Count - 1
                    column_is_valid += ", 0 AS IsValid" + column_check(i) + ""
                Next

                Dim query As String = ""

                If SLUETemplate.EditValue.ToString = "1" Then
                    query = "
                        SELECT CONCAT('VOLCOM ', TRIM(LEFT(de.design_display_name, LENGTH(de.design_display_name) - 3))) AS NamaProduk, pro.product_full_code AS SellerSKU, cd_det.display_name AS Ukuran, color.code_detail_name AS Warna, CONCAT('VOLCOM ', TRIM(LEFT(de.design_display_name, LENGTH(de.design_display_name) - 3))) AS Parent, (SELECT code_toko_gudang_blibli FROM tb_opt LIMIT 1) AS KodeTokoGudang, FLOOR(de_pn.design_price) AS HargaRp, FLOOR(de_pc.design_price) AS HargaPenjualanRp " + column_is_valid + "
                        FROM tb_m_product AS pro
                        LEFT JOIN tb_m_design AS de ON pro.id_design = de.id_design
                        LEFT JOIN (
                            SELECT id_design, design_price, id_design_price_type
                            FROM tb_m_design_price
                            WHERE id_design_price IN (
                                SELECT MAX(id_design_price) AS id_design_price
                                FROM tb_m_design_price
                                WHERE design_price_start_date <= NOW() AND is_active_wh = 1 AND is_design_cost = 0
                                GROUP BY id_design
                            )
                        ) AS de_pc ON de.id_design = de_pc.id_design
                        LEFT JOIN (
                            SELECT id_design, design_price
                            FROM tb_m_design_price
                            WHERE id_design_price IN (
                                SELECT MAX(id_design_price) AS id_design_price
                                FROM tb_m_design_price
                                WHERE design_price_start_date <= NOW() AND is_active_wh = 1 AND is_design_cost = 0 AND id_design_price_type = 1
                                GROUP BY id_design
                            )
                        ) AS de_pn ON de.id_design = de_pn.id_design
                        LEFT JOIN (
                            SELECT id_design, MIN(product_full_code) AS product_full_code
                            FROM tb_m_product
                            GROUP BY id_design
                        ) AS pro_parent ON de.id_design = pro_parent.id_design
                        LEFT JOIN (
                            SELECT dc.id_design, cd.code_detail_name
                            FROM tb_m_design_code AS dc
                            INNER JOIN tb_m_code_detail AS cd ON dc.id_code_detail = cd.id_code_detail AND cd.id_code = 14
                        ) AS color ON de.id_design = color.id_design
                        LEFT JOIN tb_m_product_code AS pro_cd ON pro.id_product = pro_cd.id_product
                        LEFT JOIN tb_m_code_detail AS cd_det ON pro_cd.id_code_detail = cd_det.id_code_detail
                        WHERE pro.product_full_code IN (" + id_product_in.Substring(0, id_product_in.Length - 4) + ")
                        ORDER BY pro.product_full_code ASC
                    "
                ElseIf SLUETemplate.EditValue.ToString = "2" Then
                    query = "
                        SELECT CONCAT('VOLCOM ', TRIM(LEFT(de.design_display_name, LENGTH(de.design_display_name) - 3))) AS NamaProduk, pro.product_full_code AS SellerSKU, FLOOR(de_pn.design_price) AS HargaRp, FLOOR(de_pc.design_price) AS HargaPenjualanRp, (SELECT code_toko_gudang_blibli FROM tb_opt LIMIT 1) AS TokoGudang " + column_is_valid + "
                        FROM tb_m_product AS pro
                        LEFT JOIN tb_m_design AS de ON pro.id_design = de.id_design
                        LEFT JOIN (
                            SELECT id_design, design_price, id_design_price_type
                            FROM tb_m_design_price
                            WHERE id_design_price IN (
                                SELECT MAX(id_design_price) AS id_design_price
                                FROM tb_m_design_price
                                WHERE design_price_start_date <= NOW() AND is_active_wh = 1 AND is_design_cost = 0
                                GROUP BY id_design
                            )
                        ) AS de_pc ON de.id_design = de_pc.id_design
                        LEFT JOIN (
                            SELECT id_design, design_price
                            FROM tb_m_design_price
                            WHERE id_design_price IN (
                                SELECT MAX(id_design_price) AS id_design_price
                                FROM tb_m_design_price
                                WHERE design_price_start_date <= NOW() AND is_active_wh = 1 AND is_design_cost = 0 AND id_design_price_type = 1
                                GROUP BY id_design
                            )
                        ) AS de_pn ON de.id_design = de_pn.id_design
                        LEFT JOIN (
                            SELECT id_design, MIN(product_full_code) AS product_full_code
                            FROM tb_m_product
                            GROUP BY id_design
                        ) AS pro_parent ON de.id_design = pro_parent.id_design
                        LEFT JOIN (
                            SELECT dc.id_design, cd.code_detail_name
                            FROM tb_m_design_code AS dc
                            INNER JOIN tb_m_code_detail AS cd ON dc.id_code_detail = cd.id_code_detail AND cd.id_code = 14
                        ) AS color ON de.id_design = color.id_design
                        LEFT JOIN tb_m_product_code AS pro_cd ON pro.id_product = pro_cd.id_product
                        LEFT JOIN tb_m_code_detail AS cd_det ON pro_cd.id_code_detail = cd_det.id_code_detail
                        WHERE pro.product_full_code IN (" + id_product_in.Substring(0, id_product_in.Length - 4) + ")
                        ORDER BY pro.product_full_code ASC
                    "
                End If

                Dim data_erp As DataTable = execute_query(query, -1, True, "", "", "", "")

                'validation
                For i = 0 To data_excel.Rows.Count - 1
                    For j = 0 To data_erp.Rows.Count - 1
                        If data_excel.Rows(i)("SellerSKU").ToString = data_erp.Rows(j)("SellerSKU").ToString Then
                            For k = 0 To column_check.Count - 1
                                If column_check(k) = "NamaProduk" Then
                                    If data_excel.Rows(i)(column_check(k)).ToString.Contains(data_erp.Rows(j)(column_check(k)).ToString) Then
                                        data_excel.Rows(i)("IsValid" + column_check(k)) = "1"

                                        data_excel.Rows(i)(column_check(k)) = data_erp.Rows(j)(column_check(k)).ToString
                                    End If
                                Else
                                    If data_excel.Rows(i)(column_check(k)).ToString = data_erp.Rows(j)(column_check(k)).ToString Then
                                        data_excel.Rows(i)("IsValid" + column_check(k)) = "1"
                                    End If
                                End If
                            Next
                        End If
                    Next
                Next

                'combine data is valid
                For i = 0 To data_erp.Rows.Count - 1
                    For j = 0 To data_excel.Rows.Count - 1
                        If data_erp.Rows(i)("SellerSKU").ToString = data_excel.Rows(j)("SellerSKU").ToString Then
                            For k = 0 To column_check.Count - 1
                                data_erp.Rows(i)("IsValid" + column_check(k)) = data_excel.Rows(j)("IsValid" + column_check(k))
                            Next

                            Exit For
                        End If
                    Next
                Next

                'check is valid all
                Dim list_is_not_valid As List(Of String) = New List(Of String)

                Dim is_valid_all As Boolean = True

                For i = 0 To data_excel.Rows.Count - 1
                    For j = 0 To column_check.Count - 1
                        If data_excel.Rows(i)("IsValid" + column_check(j)).ToString = "0" Then
                            is_valid_all = False

                            list_is_not_valid.Add(column_check(j))
                        End If
                    Next
                Next

                'sorting
                Dim data_view As DataView = New DataView(data_excel)
                data_view.Sort = "SellerSKU ASC"
                data_excel = data_view.ToTable

                'set datasource
                GCVerification.DataSource = data_excel
                GCERP.DataSource = data_erp

                'bestfit
                GVVerification.BestFitColumns()
                GVERP.BestFitColumns()

                'hide column
                For i = 0 To GVVerification.Columns.Count - 1
                    Dim gv_column As DevExpress.XtraGrid.Columns.GridColumn = GVVerification.Columns(i)

                    If gv_column.Name.Contains("IsValid") Then
                        gv_column.Visible = False
                    End If
                Next

                For i = 0 To GVERP.Columns.Count - 1
                    Dim gv_column As DevExpress.XtraGrid.Columns.GridColumn = GVERP.Columns(i)

                    If gv_column.Name.Contains("IsValid") Then
                        gv_column.Visible = False
                    End If
                Next

                'store data if valid
                If is_valid_all Then
                    'save to database
                    'header
                    query = "INSERT INTO tb_verification_master (id_comp, id_template, file_name, id_code_detail, created_date, created_by) VALUES (" + SLUEOnlineStore.EditValue.ToString + ", " + SLUETemplate.EditValue.ToString + ", '" + addSlashes(TEFileName.EditValue.ToString) + "', " + SLUEDivision.EditValue.ToString + ", NOW(), " + id_employee_user + "); SELECT LAST_INSERT_ID();"

                    id_verification_master = execute_query(query, 0, True, "", "", "", "")

                    'detail
                    If SLUETemplate.EditValue.ToString = "1" Then
                        query = "INSERT INTO tb_verification_master_blibli (id_verification_master, NamaProduk, SellerSKU, Ukuran, Warna, Parent, KodeTokoGudang, HargaRp, HargaPenjualanRp, NamaProduk_erp, SellerSKU_erp, Ukuran_erp, Warna_erp, Parent_erp, KodeTokoGudang_erp, HargaRp_erp, HargaPenjualanRp_erp) VALUES "

                        For i = 0 To data_excel.Rows.Count - 1
                            Dim NamaProduk As String = data_excel.Rows(i)("NamaProduk").ToString
                            Dim SellerSKU As String = data_excel.Rows(i)("SellerSKU").ToString
                            Dim Ukuran As String = data_excel.Rows(i)("Ukuran").ToString
                            Dim Warna As String = data_excel.Rows(i)("Warna").ToString
                            Dim Parent As String = data_excel.Rows(i)("Parent").ToString
                            Dim KodeTokoGudang As String = data_excel.Rows(i)("KodeTokoGudang").ToString
                            Dim HargaRp As String = data_excel.Rows(i)("HargaRp").ToString
                            Dim HargaPenjualanRp As String = data_excel.Rows(i)("HargaPenjualanRp").ToString

                            Dim NamaProduk_erp As String = ""
                            Dim SellerSKU_erp As String = ""
                            Dim Ukuran_erp As String = ""
                            Dim Warna_erp As String = ""
                            Dim Parent_erp As String = ""
                            Dim KodeTokoGudang_erp As String = ""
                            Dim HargaRp_erp As String = ""
                            Dim HargaPenjualanRp_erp As String = ""

                            Try
                                NamaProduk_erp = data_erp.Rows(i)("NamaProduk").ToString
                            Catch ex As Exception
                            End Try

                            Try
                                SellerSKU_erp = data_erp.Rows(i)("SellerSKU").ToString
                            Catch ex As Exception
                            End Try

                            Try
                                Ukuran_erp = data_erp.Rows(i)("Ukuran").ToString
                            Catch ex As Exception
                            End Try

                            Try
                                Warna_erp = data_erp.Rows(i)("Warna").ToString
                            Catch ex As Exception
                            End Try

                            Try
                                Parent_erp = data_erp.Rows(i)("Parent").ToString
                            Catch ex As Exception
                            End Try

                            Try
                                KodeTokoGudang_erp = data_erp.Rows(i)("KodeTokoGudang").ToString
                            Catch ex As Exception
                            End Try

                            Try
                                HargaRp_erp = data_erp.Rows(i)("HargaRp").ToString
                            Catch ex As Exception
                            End Try

                            Try
                                HargaPenjualanRp_erp = data_erp.Rows(i)("HargaPenjualanRp").ToString
                            Catch ex As Exception
                            End Try

                            query += "('" + id_verification_master + "', '" + NamaProduk + "', '" + SellerSKU + "', '" + Ukuran + "', '" + Warna + "', '" + Parent + "', '" + KodeTokoGudang + "', '" + HargaRp + "', '" + HargaPenjualanRp + "', '" + NamaProduk_erp + "', '" + SellerSKU_erp + "', '" + Ukuran_erp + "', '" + Warna_erp + "', '" + Parent_erp + "', '" + KodeTokoGudang_erp + "', '" + HargaRp_erp + "', '" + HargaPenjualanRp_erp + "'), "
                        Next
                    ElseIf SLUETemplate.EditValue.ToString = "2" Then
                        query = "INSERT INTO tb_verification_master_blibli_update (id_verification_master, NamaProduk, SellerSKU, HargaRp, HargaPenjualanRp, TokoGudang, NamaProduk_erp, SellerSKU_erp, HargaRp_erp, HargaPenjualanRp_erp, TokoGudang_erp) VALUES "

                        For i = 0 To data_excel.Rows.Count - 1
                            Dim NamaProduk As String = data_excel.Rows(i)("NamaProduk").ToString
                            Dim SellerSKU As String = data_excel.Rows(i)("SellerSKU").ToString
                            Dim HargaRp As String = data_excel.Rows(i)("HargaRp").ToString
                            Dim HargaPenjualanRp As String = data_excel.Rows(i)("HargaPenjualanRp").ToString
                            Dim TokoGudang As String = data_excel.Rows(i)("TokoGudang").ToString

                            Dim NamaProduk_erp As String = ""
                            Dim SellerSKU_erp As String = ""
                            Dim HargaRp_erp As String = ""
                            Dim HargaPenjualanRp_erp As String = ""
                            Dim TokoGudang_erp As String = ""

                            Try
                                NamaProduk_erp = data_erp.Rows(i)("NamaProduk").ToString
                            Catch ex As Exception
                            End Try

                            Try
                                SellerSKU_erp = data_erp.Rows(i)("SellerSKU").ToString
                            Catch ex As Exception
                            End Try

                            Try
                                HargaRp_erp = data_erp.Rows(i)("HargaRp").ToString
                            Catch ex As Exception
                            End Try

                            Try
                                HargaPenjualanRp_erp = data_erp.Rows(i)("HargaPenjualanRp").ToString
                            Catch ex As Exception
                            End Try

                            Try
                                TokoGudang_erp = data_erp.Rows(i)("TokoGudang").ToString
                            Catch ex As Exception
                            End Try

                            query += "('" + id_verification_master + "', '" + NamaProduk + "', '" + SellerSKU + "', '" + HargaRp + "', '" + HargaPenjualanRp + "', '" + TokoGudang + "', '" + NamaProduk_erp + "', '" + SellerSKU_erp + "', '" + HargaRp_erp + "', '" + HargaPenjualanRp_erp + "', '" + TokoGudang_erp + "'), "
                        Next
                    End If


                    query = query.Substring(0, query.Length - 2)

                    execute_non_query(query, True, "", "", "", "")
                End If

                'warning message
                If is_valid_all Then
                    infoCustom("Excel data is correct.")

                    'controls
                    SLUEOnlineStore.ReadOnly = True
                    SLUETemplate.ReadOnly = True
                    SLUEDivision.ReadOnly = True
                    TEFileName.ReadOnly = True
                    SBImportExcel.Enabled = False
                    DropDownButtonExport.Enabled = False
                Else
                    PopupMenuExport.ClearLinks()

                    For i = 0 To list_is_not_valid.Count - 1
                        Dim b As DevExpress.XtraBars.BarButtonItem = New DevExpress.XtraBars.BarButtonItem

                        b.Caption = list_is_not_valid(i) + " Not Matched"
                        b.Tag = list_is_not_valid(i)

                        AddHandler b.ItemClick, AddressOf exportClick

                        PopupMenuExport.AddItem(b)
                    Next

                    DropDownButtonExport.Enabled = True

                    errorCustom("There are some excel data wrong.")
                End If
            Catch ex As Exception
                errorCustom(ex.ToString)
            End Try

            Cursor = Cursors.Default
        End If
    End Sub

    Sub check_volcom(file_name As String)
        Dim app As New Microsoft.Office.Interop.Excel.Application
        Dim worksheet As Microsoft.Office.Interop.Excel.Worksheet
        Dim workbook As Microsoft.Office.Interop.Excel.Workbook

        app.DisplayAlerts = False

        If Not file_name = "" Then
            Cursor = Cursors.WaitCursor

            Try
                workbook = app.Workbooks.Open(file_name)
                worksheet = workbook.Worksheets("Sheet2")

                Dim data_excel As DataTable = New DataTable

                Dim row As Integer = 0
                Dim column As Integer = 0

                Dim continue_loop As Boolean = False

                Dim column_check As List(Of String) = New List(Of String)

                column_check.Add("Option1Value")
                column_check.Add("VariantSKU")
                column_check.Add("VariantPrice")
                column_check.Add("VariantCompareAtPrice")
                column_check.Add("VariantBarcode")

                'column
                row = 1
                column = 1

                continue_loop = True

                While continue_loop
                    Dim column_name As String = worksheet.Cells(row, column).Value

                    If Not column_name = "" Then
                        column_name = System.Text.RegularExpressions.Regex.Replace(column_name, "[^\w\\]", "")

                        data_excel.Columns.Add(column_name, GetType(String))
                    Else
                        continue_loop = False
                    End If

                    column += 1
                End While

                'row
                Dim id_product_in As String = ""

                row = 2
                column = 1

                continue_loop = True

                While continue_loop
                    Dim empty_all As Boolean = False

                    Dim data_excel_row As DataRow = data_excel.NewRow

                    For i = 0 To data_excel.Columns.Count - 1
                        Dim column_name As String = data_excel.Columns(i).ColumnName
                        Dim value As String = worksheet.Cells(row, i + 1).Value

                        data_excel_row(column_name) = value

                        If column_name = "VariantSKU" Then
                            If Not value = "" Then
                                id_product_in += value + ", "
                            End If
                        End If

                        If Not value = "" Then
                            empty_all = True
                        End If
                    Next

                    If empty_all Then
                        data_excel.Rows.Add(data_excel_row)
                    Else
                        continue_loop = False
                    End If

                    row += 1
                End While

                workbook.Close()

                app.Quit()

                'remove column
                column = 0

                continue_loop = True

                While continue_loop
                    Dim column_name As String = ""

                    Try
                        column_name = data_excel.Columns(column).ColumnName
                    Catch ex As Exception
                        continue_loop = False
                    End Try

                    If Not column_name = "" Then
                        If column_check.IndexOf(column_name) < 0 Then
                            data_excel.Columns.Remove(column_name)
                        Else
                            column += 1
                        End If
                    End If
                End While

                'add column
                For i = 0 To column_check.Count - 1
                    data_excel.Columns.Add("IsValid" + column_check(i), GetType(String))
                Next

                'add column value
                For i = 0 To data_excel.Rows.Count - 1
                    For j = 0 To column_check.Count - 1
                        data_excel.Rows(i)("IsValid" + column_check(j)) = "0"
                    Next
                Next

                'data erp
                Dim column_is_valid As String = ""

                For i = 0 To column_check.Count - 1
                    column_is_valid += ", 0 AS IsValid" + column_check(i) + ""
                Next

                Dim data_erp As DataTable = execute_query("
                    SELECT cd_det.display_name AS Option1Value, pro.product_full_code AS VariantSKU, de.design_display_name AS VariantBarcode, FLOOR(de_pn.design_price) AS VariantCompareAtPrice, FLOOR(de_pc.design_price) AS VariantPrice " + column_is_valid + "
                    FROM tb_m_product AS pro
                    LEFT JOIN tb_m_design AS de ON pro.id_design = de.id_design
                    LEFT JOIN (
                        SELECT id_design, design_price, id_design_price_type
                        FROM tb_m_design_price
                        WHERE id_design_price IN (
                            SELECT MAX(id_design_price) AS id_design_price
                            FROM tb_m_design_price
                            WHERE design_price_start_date <= NOW() AND is_active_wh = 1 AND is_design_cost = 0
                            GROUP BY id_design
                        )
                    ) AS de_pc ON de.id_design = de_pc.id_design
                    LEFT JOIN (
                        SELECT id_design, design_price
                        FROM tb_m_design_price
                        WHERE id_design_price IN (
                            SELECT MAX(id_design_price) AS id_design_price
                            FROM tb_m_design_price
                            WHERE design_price_start_date <= NOW() AND is_active_wh = 1 AND is_design_cost = 0 AND id_design_price_type = 1
                            GROUP BY id_design
                        )
                    ) AS de_pn ON de.id_design = de_pn.id_design
                    LEFT JOIN tb_m_product_code AS pro_cd ON pro.id_product = pro_cd.id_product
                    LEFT JOIN tb_m_code_detail AS cd_det ON pro_cd.id_code_detail = cd_det.id_code_detail
                    WHERE pro.product_full_code IN (" + id_product_in.Substring(0, id_product_in.Length - 4) + ")
                    ORDER BY pro.product_full_code ASC
                ", -1, True, "", "", "", "")

                'validation
                For i = 0 To data_excel.Rows.Count - 1
                    For j = 0 To data_erp.Rows.Count - 1
                        If data_excel.Rows(i)("VariantSKU").ToString = data_erp.Rows(j)("VariantSKU").ToString Then
                            For k = 0 To column_check.Count - 1
                                If data_excel.Rows(i)(column_check(k)).ToString = data_erp.Rows(j)(column_check(k)).ToString Then
                                    data_excel.Rows(i)("IsValid" + column_check(k)) = "1"
                                End If
                            Next
                        End If
                    Next
                Next

                'combine data is valid
                For i = 0 To data_erp.Rows.Count - 1
                    For j = 0 To data_excel.Rows.Count - 1
                        If data_erp.Rows(i)("VariantSKU").ToString = data_excel.Rows(j)("VariantSKU").ToString Then
                            For k = 0 To column_check.Count - 1
                                data_erp.Rows(i)("IsValid" + column_check(k)) = data_excel.Rows(j)("IsValid" + column_check(k))
                            Next

                            Exit For
                        End If
                    Next
                Next

                'check is valid all
                Dim list_is_not_valid As List(Of String) = New List(Of String)

                Dim is_valid_all As Boolean = True

                For i = 0 To data_excel.Rows.Count - 1
                    For j = 0 To column_check.Count - 1
                        If data_excel.Rows(i)("IsValid" + column_check(j)).ToString = "0" Then
                            is_valid_all = False

                            list_is_not_valid.Add(column_check(j))
                        End If
                    Next
                Next

                'sorting
                Dim data_view As DataView = New DataView(data_excel)
                data_view.Sort = "VariantSKU ASC"
                data_excel = data_view.ToTable

                'set datasource
                GCVerification.DataSource = data_excel
                GCERP.DataSource = data_erp

                'bestfit
                GVVerification.BestFitColumns()
                GVERP.BestFitColumns()

                'hide column
                For i = 0 To GVVerification.Columns.Count - 1
                    Dim gv_column As DevExpress.XtraGrid.Columns.GridColumn = GVVerification.Columns(i)

                    If gv_column.Name.Contains("IsValid") Then
                        gv_column.Visible = False
                    End If
                Next

                For i = 0 To GVERP.Columns.Count - 1
                    Dim gv_column As DevExpress.XtraGrid.Columns.GridColumn = GVERP.Columns(i)

                    If gv_column.Name.Contains("IsValid") Then
                        gv_column.Visible = False
                    End If
                Next

                'store data if valid
                If is_valid_all Then
                    'save to database
                    Dim query As String = ""

                    'header
                    query = "INSERT INTO tb_verification_master (id_comp, file_name, id_code_detail, created_date, created_by) VALUES (" + SLUEOnlineStore.EditValue.ToString + ", '" + addSlashes(TEFileName.EditValue.ToString) + "', " + SLUEDivision.EditValue.ToString + ", NOW(), " + id_employee_user + "); SELECT LAST_INSERT_ID();"

                    id_verification_master = execute_query(query, 0, True, "", "", "", "")

                    'detail
                    query = "INSERT INTO tb_verification_master_blibli (id_verification_master, NamaProduk, SellerSKU, Ukuran, Warna, Parent, KodeTokoGudang, HargaRp, HargaPenjualanRp, NamaProduk_erp, SellerSKU_erp, Ukuran_erp, Warna_erp, Parent_erp, KodeTokoGudang_erp, HargaRp_erp, HargaPenjualanRp_erp) VALUES "

                    For i = 0 To data_excel.Rows.Count - 1
                        Dim Option1Value As String = data_excel.Rows(i)("Option1Value").ToString
                        Dim VariantSKU As String = data_excel.Rows(i)("VariantSKU").ToString
                        Dim VariantPrice As String = data_excel.Rows(i)("VariantPrice").ToString
                        Dim VariantCompareAtPrice As String = data_excel.Rows(i)("VariantCompareAtPrice").ToString
                        Dim VariantBarcode As String = data_excel.Rows(i)("VariantBarcode").ToString

                        Dim Option1Value_erp As String = ""
                        Dim VariantSKU_erp As String = ""
                        Dim VariantPrice_erp As String = ""
                        Dim VariantCompareAtPrice_erp As String = ""
                        Dim VariantBarcode_erp As String = ""

                        Try
                            Option1Value_erp = data_erp.Rows(i)("Option1Value").ToString
                        Catch ex As Exception
                        End Try

                        Try
                            VariantSKU_erp = data_erp.Rows(i)("VariantSKU").ToString
                        Catch ex As Exception
                        End Try

                        Try
                            VariantPrice_erp = data_erp.Rows(i)("VariantPrice").ToString
                        Catch ex As Exception
                        End Try

                        Try
                            VariantCompareAtPrice_erp = data_erp.Rows(i)("VariantCompareAtPrice").ToString
                        Catch ex As Exception
                        End Try

                        Try
                            VariantBarcode_erp = data_erp.Rows(i)("VariantBarcode").ToString
                        Catch ex As Exception
                        End Try

                        query += "('" + id_verification_master + "', '" + Option1Value + "', '" + VariantSKU + "', '" + VariantPrice + "', '" + VariantCompareAtPrice + "', '" + VariantBarcode + "', '" + Option1Value_erp + "', '" + VariantSKU_erp + "', '" + VariantPrice_erp + "', '" + VariantCompareAtPrice_erp + "', '" + VariantBarcode_erp + "'), "
                    Next

                    query = query.Substring(0, query.Length - 2)

                    execute_non_query(query, True, "", "", "", "")
                End If

                'warning message
                If is_valid_all Then
                    infoCustom("Excel data is correct.")

                    'controls
                    SLUEOnlineStore.ReadOnly = True
                    SLUEDivision.ReadOnly = True
                    TEFileName.ReadOnly = True
                    SBImportExcel.Enabled = False
                    DropDownButtonExport.Enabled = False
                Else
                    PopupMenuExport.ClearLinks()

                    For i = 0 To list_is_not_valid.Count - 1
                        Dim b As DevExpress.XtraBars.BarButtonItem = New DevExpress.XtraBars.BarButtonItem

                        b.Caption = list_is_not_valid(i) + " Not Matched"
                        b.Tag = list_is_not_valid(i)

                        AddHandler b.ItemClick, AddressOf exportClick

                        PopupMenuExport.AddItem(b)
                    Next

                    DropDownButtonExport.Enabled = True

                    errorCustom("There are some excel data wrong.")
                End If
            Catch ex As Exception
                errorCustom(ex.ToString)
            End Try

            Cursor = Cursors.Default
        End If
    End Sub

    Sub check_shopee(file_name As String)
        Dim app As New Microsoft.Office.Interop.Excel.Application
        Dim worksheet As Microsoft.Office.Interop.Excel.Worksheet
        Dim workbook As Microsoft.Office.Interop.Excel.Workbook

        app.DisplayAlerts = False

        If Not file_name = "" Then
            Cursor = Cursors.WaitCursor

            Try
                workbook = app.Workbooks.Open(file_name)

                If SLUETemplate.EditValue.ToString = "1" Then
                    worksheet = workbook.Worksheets("Template")
                ElseIf SLUETemplate.EditValue.ToString = "2" Then
                    worksheet = workbook.Worksheets("Sheet")
                End If

                Dim data_excel As DataTable = New DataTable

                Dim row As Integer = 0
                Dim column As Integer = 0

                Dim continue_loop As Boolean = False

                Dim column_check As List(Of String) = New List(Of String)

                If SLUETemplate.EditValue.ToString = "1" Then
                    column_check.Add("NamaProduk")
                    column_check.Add("SKUInduk")
                    column_check.Add("KodeIntegrasiVariasi")
                    column_check.Add("VarianuntukVariasi1")
                    column_check.Add("Harga")
                    column_check.Add("KodeVariasi")
                ElseIf SLUETemplate.EditValue.ToString = "2" Then
                    column_check.Add("ProductNameOptional")
                    column_check.Add("NamaVariasiOpsional")
                    column_check.Add("SKURefNoOptional")
                    column_check.Add("HargaAwalOpsional")
                    column_check.Add("Hargadiskon")
                End If

                'column
                If SLUETemplate.EditValue.ToString = "1" Then
                    row = 2
                    column = 1
                ElseIf SLUETemplate.EditValue.ToString = "2" Then
                    row = 1
                    column = 1
                End If

                continue_loop = True

                While continue_loop
                    Dim column_name As String = worksheet.Cells(row, column).Value

                    If Not column_name = "" Then
                        column_name = System.Text.RegularExpressions.Regex.Replace(column_name, "[^\w\\]", "")

                        data_excel.Columns.Add(column_name, GetType(String))
                    Else
                        continue_loop = False
                    End If

                    column += 1
                End While

                'row
                Dim id_product_in As String = ""

                If SLUETemplate.EditValue.ToString = "1" Then
                    row = 6
                    column = 1
                ElseIf SLUETemplate.EditValue.ToString = "2" Then
                    row = 2
                    column = 1
                End If

                continue_loop = True

                While continue_loop
                    Dim empty_all As Boolean = False

                    Dim data_excel_row As DataRow = data_excel.NewRow

                    For i = 0 To data_excel.Columns.Count - 1
                        Dim column_name As String = data_excel.Columns(i).ColumnName
                        Dim value As String = worksheet.Cells(row, i + 1).Value

                        data_excel_row(column_name) = value

                        If SLUETemplate.EditValue.ToString = "1" Then
                            If column_name = "KodeVariasi" Then
                                If Not value = "" Then
                                    id_product_in += value + ", "
                                End If
                            End If
                        ElseIf SLUETemplate.EditValue.ToString = "2" Then
                            If column_name = "SKURefNoOptional" Then
                                If Not value = "" Then
                                    id_product_in += value + ", "
                                End If
                            End If
                        End If

                        If Not value = "" Then
                            empty_all = True
                        End If
                    Next

                    If empty_all Then
                        data_excel.Rows.Add(data_excel_row)
                    Else
                        continue_loop = False
                    End If

                    row += 1
                End While

                workbook.Close()

                app.Quit()

                'remove column
                column = 0

                continue_loop = True

                While continue_loop
                    Dim column_name As String = ""

                    Try
                        column_name = data_excel.Columns(column).ColumnName
                    Catch ex As Exception
                        continue_loop = False
                    End Try

                    If Not column_name = "" Then
                        If column_check.IndexOf(column_name) < 0 Then
                            data_excel.Columns.Remove(column_name)
                        Else
                            column += 1
                        End If
                    End If
                End While

                'add column
                For i = 0 To column_check.Count - 1
                    data_excel.Columns.Add("IsValid" + column_check(i), GetType(String))
                Next

                'add column value
                For i = 0 To data_excel.Rows.Count - 1
                    For j = 0 To column_check.Count - 1
                        data_excel.Rows(i)("IsValid" + column_check(j)) = "0"
                    Next
                Next

                'data erp
                Dim column_is_valid As String = ""

                For i = 0 To column_check.Count - 1
                    column_is_valid += ", 0 AS IsValid" + column_check(i) + ""
                Next

                Dim q As String = ""

                If SLUETemplate.EditValue.ToString = "1" Then
                    q = "
                        SELECT CONCAT('VOLCOM - ', de.design_display_name) AS NamaProduk, LEFT(pro.product_full_code, 9) AS SKUInduk, LEFT(pro.product_full_code, 9) AS KodeIntegrasiVariasi, cd_det.display_name AS VarianuntukVariasi1, FLOOR(de_pc.design_price) AS Harga, pro.product_full_code AS KodeVariasi
                        " + column_is_valid + "
                        FROM tb_m_product AS pro
                        LEFT JOIN tb_m_design AS de ON pro.id_design = de.id_design
                        LEFT JOIN (
                            SELECT id_design, design_price, id_design_price_type
                            FROM tb_m_design_price
                            WHERE id_design_price IN (
                                SELECT MAX(id_design_price) AS id_design_price
                                FROM tb_m_design_price
                                WHERE design_price_start_date <= NOW() AND is_active_wh = 1 AND is_design_cost = 0
                                GROUP BY id_design
                            )
                        ) AS de_pc ON de.id_design = de_pc.id_design
                        LEFT JOIN (
                            SELECT id_design, design_price
                            FROM tb_m_design_price
                            WHERE id_design_price IN (
                                SELECT MAX(id_design_price) AS id_design_price
                                FROM tb_m_design_price
                                WHERE design_price_start_date <= NOW() AND is_active_wh = 1 AND is_design_cost = 0 AND id_design_price_type = 1
                                GROUP BY id_design
                            )
                        ) AS de_pn ON de.id_design = de_pn.id_design
                        LEFT JOIN tb_m_product_code AS pro_cd ON pro.id_product = pro_cd.id_product
                        LEFT JOIN tb_m_code_detail AS cd_det ON pro_cd.id_code_detail = cd_det.id_code_detail
                        WHERE pro.product_full_code IN (" + id_product_in.Substring(0, id_product_in.Length - 2) + ")
                        ORDER BY pro.product_full_code ASC
                    "
                ElseIf SLUETemplate.EditValue.ToString = "2" Then
                    q = "
                        SELECT CONCAT('VOLCOM - ', de.design_display_name) AS ProductNameOptional, cd_det.display_name AS NamaVariasiOpsional, pro.product_full_code AS SKURefNoOptional, FLOOR(de_pn.design_price) AS HargaAwalOpsional, FLOOR(de_pc.design_price) AS Hargadiskon
                        " + column_is_valid + "
                        FROM tb_m_product AS pro
                        LEFT JOIN tb_m_design AS de ON pro.id_design = de.id_design
                        LEFT JOIN (
                            SELECT id_design, design_price, id_design_price_type
                            FROM tb_m_design_price
                            WHERE id_design_price IN (
                                SELECT MAX(id_design_price) AS id_design_price
                                FROM tb_m_design_price
                                WHERE design_price_start_date <= NOW() AND is_active_wh = 1 AND is_design_cost = 0
                                GROUP BY id_design
                            )
                        ) AS de_pc ON de.id_design = de_pc.id_design
                        LEFT JOIN (
                            SELECT id_design, design_price
                            FROM tb_m_design_price
                            WHERE id_design_price IN (
                                SELECT MAX(id_design_price) AS id_design_price
                                FROM tb_m_design_price
                                WHERE design_price_start_date <= NOW() AND is_active_wh = 1 AND is_design_cost = 0 AND id_design_price_type = 1
                                GROUP BY id_design
                            )
                        ) AS de_pn ON de.id_design = de_pn.id_design
                        LEFT JOIN tb_m_product_code AS pro_cd ON pro.id_product = pro_cd.id_product
                        LEFT JOIN tb_m_code_detail AS cd_det ON pro_cd.id_code_detail = cd_det.id_code_detail
                        WHERE pro.product_full_code IN (" + id_product_in.Substring(0, id_product_in.Length - 2) + ")
                        ORDER BY pro.product_full_code ASC
                    "
                End If

                Dim data_erp As DataTable = execute_query(q, -1, True, "", "", "", "")

                'validation
                For i = 0 To data_excel.Rows.Count - 1
                    For j = 0 To data_erp.Rows.Count - 1
                        If SLUETemplate.EditValue.ToString = "1" Then
                            If data_excel.Rows(i)("KodeVariasi").ToString = data_erp.Rows(j)("KodeVariasi").ToString Then
                                For k = 0 To column_check.Count - 1
                                    If data_excel.Rows(i)(column_check(k)).ToString = data_erp.Rows(j)(column_check(k)).ToString Then
                                        data_excel.Rows(i)("IsValid" + column_check(k)) = "1"
                                    End If
                                Next
                            End If
                        ElseIf SLUETemplate.EditValue.ToString = "2" Then
                            If data_excel.Rows(i)("SKURefNoOptional").ToString = data_erp.Rows(j)("SKURefNoOptional").ToString Then
                                For k = 0 To column_check.Count - 1
                                    If data_excel.Rows(i)(column_check(k)).ToString = data_erp.Rows(j)(column_check(k)).ToString Then
                                        data_excel.Rows(i)("IsValid" + column_check(k)) = "1"
                                    End If
                                Next
                            End If
                        End If
                    Next
                Next

                'combine data is valid
                For i = 0 To data_erp.Rows.Count - 1
                    For j = 0 To data_excel.Rows.Count - 1
                        If SLUETemplate.EditValue.ToString = "1" Then
                            If data_erp.Rows(i)("KodeVariasi").ToString = data_excel.Rows(j)("KodeVariasi").ToString Then
                                For k = 0 To column_check.Count - 1
                                    data_erp.Rows(i)("IsValid" + column_check(k)) = data_excel.Rows(j)("IsValid" + column_check(k))
                                Next

                                Exit For
                            End If
                        ElseIf SLUETemplate.EditValue.ToString = "2" Then
                            If data_erp.Rows(i)("SKURefNoOptional").ToString = data_excel.Rows(j)("SKURefNoOptional").ToString Then
                                For k = 0 To column_check.Count - 1
                                    data_erp.Rows(i)("IsValid" + column_check(k)) = data_excel.Rows(j)("IsValid" + column_check(k))
                                Next

                                Exit For
                            End If
                        End If
                    Next
                Next

                'check is valid all
                Dim list_is_not_valid As List(Of String) = New List(Of String)

                Dim is_valid_all As Boolean = True

                For i = 0 To data_excel.Rows.Count - 1
                    For j = 0 To column_check.Count - 1
                        If data_excel.Rows(i)("IsValid" + column_check(j)).ToString = "0" Then
                            is_valid_all = False

                            list_is_not_valid.Add(column_check(j))
                        End If
                    Next
                Next

                'sorting
                Dim data_view As DataView = New DataView(data_excel)
                If SLUETemplate.EditValue.ToString = "1" Then
                    data_view.Sort = "KodeVariasi ASC"
                ElseIf SLUETemplate.EditValue.ToString = "2" Then
                    data_view.Sort = "SKURefNoOptional ASC"
                End If
                data_excel = data_view.ToTable

                'set datasource
                GCVerification.DataSource = data_excel
                GCERP.DataSource = data_erp

                'bestfit
                GVVerification.BestFitColumns()
                GVERP.BestFitColumns()

                'hide column
                For i = 0 To GVVerification.Columns.Count - 1
                    Dim gv_column As DevExpress.XtraGrid.Columns.GridColumn = GVVerification.Columns(i)

                    If gv_column.Name.Contains("IsValid") Then
                        gv_column.Visible = False
                    End If
                Next

                For i = 0 To GVERP.Columns.Count - 1
                    Dim gv_column As DevExpress.XtraGrid.Columns.GridColumn = GVERP.Columns(i)

                    If gv_column.Name.Contains("IsValid") Then
                        gv_column.Visible = False
                    End If
                Next

                'store data if valid
                If is_valid_all Then
                    'save to database
                    Dim query As String = ""

                    'header
                    query = "INSERT INTO tb_verification_master (id_comp, id_template, file_name, id_code_detail, created_date, created_by) VALUES (" + SLUEOnlineStore.EditValue.ToString + ", " + SLUETemplate.EditValue.ToString + ", '" + addSlashes(TEFileName.EditValue.ToString) + "', " + SLUEDivision.EditValue.ToString + ", NOW(), " + id_employee_user + "); SELECT LAST_INSERT_ID();"

                    id_verification_master = execute_query(query, 0, True, "", "", "", "")

                    'detail
                    If SLUETemplate.EditValue.ToString = "1" Then
                        query = "INSERT INTO tb_verification_master_shopee (id_verification_master, NamaProduk, SKUInduk, KodeIntegrasiVariasi, VarianuntukVariasi1, Harga, KodeVariasi, NamaProduk_erp, SKUInduk_erp, KodeIntegrasiVariasi_erp, VarianuntukVariasi1_erp, Harga_erp, KodeVariasi_erp) VALUES "

                        For i = 0 To data_excel.Rows.Count - 1
                            Dim NamaProduk As String = data_excel.Rows(i)("NamaProduk").ToString
                            Dim SKUInduk As String = data_excel.Rows(i)("SKUInduk").ToString
                            Dim KodeIntegrasiVariasi As String = data_excel.Rows(i)("KodeIntegrasiVariasi").ToString
                            Dim VarianuntukVariasi1 As String = data_excel.Rows(i)("VarianuntukVariasi1").ToString
                            Dim Harga As String = data_excel.Rows(i)("Harga").ToString
                            Dim KodeVariasi As String = data_excel.Rows(i)("KodeVariasi").ToString

                            Dim NamaProduk_erp As String = ""
                            Dim SKUInduk_erp As String = ""
                            Dim KodeIntegrasiVariasi_erp As String = ""
                            Dim VarianuntukVariasi1_erp As String = ""
                            Dim Harga_erp As String = ""
                            Dim KodeVariasi_erp As String = ""

                            Try
                                NamaProduk_erp = data_erp.Rows(i)("NamaProduk").ToString
                            Catch ex As Exception
                            End Try

                            Try
                                SKUInduk_erp = data_erp.Rows(i)("SKUInduk").ToString
                            Catch ex As Exception
                            End Try

                            Try
                                KodeIntegrasiVariasi_erp = data_erp.Rows(i)("KodeIntegrasiVariasi").ToString
                            Catch ex As Exception
                            End Try

                            Try
                                VarianuntukVariasi1_erp = data_erp.Rows(i)("VarianuntukVariasi1").ToString
                            Catch ex As Exception
                            End Try

                            Try
                                Harga_erp = data_erp.Rows(i)("Harga").ToString
                            Catch ex As Exception
                            End Try

                            Try
                                KodeVariasi_erp = data_erp.Rows(i)("KodeVariasi").ToString
                            Catch ex As Exception
                            End Try

                            query += "('" + id_verification_master + "', '" + NamaProduk + "', '" + SKUInduk + "', '" + KodeIntegrasiVariasi + "', '" + VarianuntukVariasi1 + "', '" + Harga + "', '" + KodeVariasi + "', '" + NamaProduk_erp + "', '" + SKUInduk_erp + "', '" + KodeIntegrasiVariasi_erp + "', '" + VarianuntukVariasi1_erp + "', '" + Harga_erp + "', '" + KodeVariasi_erp + "'), "
                        Next
                    ElseIf SLUETemplate.EditValue.ToString = "2" Then
                        query = "INSERT INTO tb_verification_master_shopee_update (id_verification_master, ProductNameOptional, NamaVariasiOpsional, SKURefNoOptional, HargaAwalOpsional, Hargadiskon, ProductNameOptional_erp, NamaVariasiOpsional_erp, SKURefNoOptional_erp, HargaAwalOpsional_erp, Hargadiskon_erp) VALUES "

                        For i = 0 To data_excel.Rows.Count - 1
                            Dim ProductNameOptional As String = data_excel.Rows(i)("ProductNameOptional").ToString
                            Dim NamaVariasiOpsional As String = data_excel.Rows(i)("NamaVariasiOpsional").ToString
                            Dim SKURefNoOptional As String = data_excel.Rows(i)("SKURefNoOptional").ToString
                            Dim HargaAwalOpsional As String = data_excel.Rows(i)("HargaAwalOpsional").ToString
                            Dim Hargadiskon As String = data_excel.Rows(i)("Hargadiskon").ToString

                            Dim ProductNameOptional_erp As String = ""
                            Dim NamaVariasiOpsional_erp As String = ""
                            Dim SKURefNoOptional_erp As String = ""
                            Dim HargaAwalOpsional_erp As String = ""
                            Dim Hargadiskon_erp As String = ""

                            Try
                                ProductNameOptional_erp = data_erp.Rows(i)("ProductNameOptional").ToString
                            Catch ex As Exception
                            End Try

                            Try
                                NamaVariasiOpsional_erp = data_erp.Rows(i)("NamaVariasiOpsional").ToString
                            Catch ex As Exception
                            End Try

                            Try
                                SKURefNoOptional_erp = data_erp.Rows(i)("SKURefNoOptional").ToString
                            Catch ex As Exception
                            End Try

                            Try
                                HargaAwalOpsional_erp = data_erp.Rows(i)("HargaAwalOpsional").ToString
                            Catch ex As Exception
                            End Try

                            Try
                                Hargadiskon_erp = data_erp.Rows(i)("Hargadiskon").ToString
                            Catch ex As Exception
                            End Try

                            query += "('" + id_verification_master + "', '" + ProductNameOptional + "', '" + NamaVariasiOpsional + "', '" + SKURefNoOptional + "', '" + HargaAwalOpsional + "', '" + Hargadiskon + "', '" + ProductNameOptional_erp + "', '" + NamaVariasiOpsional_erp + "', '" + SKURefNoOptional_erp + "', '" + HargaAwalOpsional_erp + "', '" + Hargadiskon_erp + "'), "
                        Next
                    End If

                    query = query.Substring(0, query.Length - 2)

                    execute_non_query(query, True, "", "", "", "")
                End If

                'warning message
                If is_valid_all Then
                    infoCustom("Excel data is correct.")

                    'controls
                    SLUEOnlineStore.ReadOnly = True
                    SLUETemplate.ReadOnly = True
                    SLUEDivision.ReadOnly = True
                    TEFileName.ReadOnly = True
                    SBImportExcel.Enabled = False
                    DropDownButtonExport.Enabled = False
                Else
                    PopupMenuExport.ClearLinks()

                    For i = 0 To list_is_not_valid.Count - 1
                        Dim b As DevExpress.XtraBars.BarButtonItem = New DevExpress.XtraBars.BarButtonItem

                        b.Caption = list_is_not_valid(i) + " Not Matched"
                        b.Tag = list_is_not_valid(i)

                        AddHandler b.ItemClick, AddressOf exportClick

                        PopupMenuExport.AddItem(b)
                    Next

                    DropDownButtonExport.Enabled = True

                    errorCustom("There are some excel data wrong.")
                End If
            Catch ex As Exception
                errorCustom(ex.ToString)
            End Try

            Cursor = Cursors.Default
        End If
    End Sub

    Private Sub GVVerification_CustomDrawCell(sender As Object, e As DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs) Handles GVVerification.CustomDrawCell
        Dim gv As DevExpress.XtraGrid.Views.Grid.GridView = sender

        If Not e.Column.Name.Contains("IsValid") Then
            Dim gv_column_valid As String = "IsValid" + e.Column.Name.Replace("col", "")

            Dim is_valid As String = gv.GetRowCellValue(e.RowHandle, gv_column_valid)

            If is_valid = "0" Then
                e.Appearance.BackColor = Color.Red
            End If
        End If
    End Sub

    Private Sub FormVerificationMasterOLDet_Resize(sender As Object, e As EventArgs) Handles MyBase.Resize
        SplitContainerControl.SplitterPosition = SplitContainerControl.Size.Width / 2
    End Sub

    Private Sub GVERP_CustomDrawCell(sender As Object, e As DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs) Handles GVERP.CustomDrawCell
        Dim gv As DevExpress.XtraGrid.Views.Grid.GridView = sender

        If Not e.Column.Name.Contains("IsValid") Then
            Dim gv_column_valid As String = "IsValid" + e.Column.Name.Replace("col", "")

            Dim is_valid As String = gv.GetRowCellValue(e.RowHandle, gv_column_valid)

            If is_valid = "0" Then
                e.Appearance.BackColor = Color.Green
            End If
        End If
    End Sub

    Sub view_template()
        Dim query As String = "
            SELECT 1 AS id_template, 'New Product' AS template_name
            UNION ALL
            SELECT 2 AS id_template, 'Update Product' AS template_name
        "

        viewSearchLookupQuery(SLUETemplate, query, "id_template", "template_name", "id_template")
    End Sub

    Private Sub SLUEOnlineStore_EditValueChanged(sender As Object, e As EventArgs) Handles SLUEOnlineStore.EditValueChanged
        If SLUEOnlineStore.EditValue.ToString = "1177" Or SLUEOnlineStore.EditValue.ToString = "1286" Then
            SLUETemplate.Visible = True
        Else
            SLUETemplate.Visible = False
        End If
    End Sub

    Private Sub exportClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs)
        GVVerification.ActiveFilterString = "[IsValid" + e.Item.Tag.ToString + "] = 0"

        Dim save As SaveFileDialog = New SaveFileDialog

        save.Filter = "Excel File | *.xls"
        save.ShowDialog()

        If Not save.FileName = "" Then
            Dim op As DevExpress.XtraPrinting.XlsExportOptionsEx = New DevExpress.XtraPrinting.XlsExportOptionsEx

            op.ExportType = DevExpress.Export.ExportType.WYSIWYG

            GVVerification.ExportToXls(save.FileName, op)

            infoCustom("File saved.")
        End If

        GVVerification.ActiveFilterString = ""
    End Sub
End Class