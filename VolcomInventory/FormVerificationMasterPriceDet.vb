Public Class FormVerificationMasterPriceDet
    Public id_verification_master As String = "-1"

    Private Sub FormVerificationMasterPriceDet_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        view_slue_online_store()
        view_slue_division()
        view_template()

        form_load()
    End Sub

    Sub form_load()
        If Not id_verification_master = "-1" Then
            Dim id_comp As String = execute_query("SELECT id_comp FROM tb_verification_master_p WHERE id_verification_master = '" + id_verification_master + "'", 0, True, "", "", "", "")
            Dim id_template As String = execute_query("SELECT id_template FROM tb_verification_master_p WHERE id_verification_master = '" + id_verification_master + "'", 0, True, "", "", "", "")
            Dim id_code_detail As String = execute_query("SELECT id_code_detail FROM tb_verification_master_p WHERE id_verification_master = '" + id_verification_master + "'", 0, True, "", "", "", "")
            Dim file_name As String = execute_query("SELECT file_name FROM tb_verification_master_p WHERE id_verification_master = '" + id_verification_master + "'", 0, True, "", "", "", "")

            SLUEOnlineStore.EditValue = id_comp
            SLUETemplate.EditValue = id_template
            SLUEDivision.EditValue = id_code_detail
            TEFileName.EditValue = file_name

            Dim query As String = ""

            If id_comp = "653" Then
                query = "
                    SELECT SellerSku, Price, SalePrice, SellerSku_erp, Price_erp, SalePrice_erp
                    FROM tb_verification_master_p_zalora
                    WHERE id_verification_master = '" + id_verification_master + "'
                "
            ElseIf id_comp = "1177" Then
                query = "
                    SELECT SellerSKU, HargaRp, HargaPenjualanRp, SellerSKU_erp, HargaRp_erp, HargaPenjualanRp_erp
                    FROM tb_verification_master_p_blibli
                    WHERE id_verification_master = '" + id_verification_master + "'
                "
            ElseIf id_comp = "1286" Then
                query = "
                    SELECT SKU, Harga, HargaDiskon, SKU_erp, Harga_erp, HargaDiskon_erp
                    FROM tb_verification_master_p_shopee
                    WHERE id_verification_master = '" + id_verification_master + "'
                "
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
            ElseIf id_comp = "1286" Then
                selected_column = "SKU"
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

    Private Sub FormVerificationMasterPriceDet_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        FormVerificationMasterPrice.form_load()

        Dispose()
    End Sub

    Sub view_slue_online_store()
        Dim query_in As String = ""

        If id_departement_user = "11" Then
            query_in = "653, 1177, 1286"
        Else
            query_in = "0"
        End If

        If id_role_login = "1" Then
            query_in = "653, 1177, 1286"
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
                SELECT COUNT(*) FROM tb_verification_master_p WHERE file_name = '" + addSlashes(file_dialog.SafeFileName) + "'
            ", 0, True, "", "", "", "")

            If is_already = "0" Then
                TEFileName.EditValue = file_dialog.SafeFileName

                If SLUEOnlineStore.EditValue.ToString = "653" Then
                    check_zalora(file_dialog.FileName)
                ElseIf SLUEOnlineStore.EditValue.ToString = "1177" Then
                    check_blibli(file_dialog.FileName)
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
                worksheet = workbook.Worksheets("Sheet")

                Dim data_excel As DataTable = New DataTable

                Dim row As Integer = 0
                Dim column As Integer = 0

                Dim continue_loop As Boolean = False

                Dim column_check As List(Of String) = New List(Of String)

                column_check.Add("SellerSku")
                column_check.Add("Price")
                column_check.Add("SalePrice")

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

                        If Not value = "" Then
                            If column_name = "Price" Or column_name = "SalePrice" Then
                                value = value.Replace(".00", "")
                            End If
                        End If

                        data_excel_row(column_name) = value

                        If column_name = "SellerSku" Then
                            If Not value = "" Then
                                id_product_in += "'" + value + "', "
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
                    SELECT pro.product_full_code AS SellerSku, FLOOR(de_pn.design_price) AS Price, IF(de_pc.id_design_price_type = 1, '', FLOOR(de_pc.design_price)) AS SalePrice " + column_is_valid + "
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
                    WHERE pro.product_full_code IN (" + id_product_in.Substring(0, id_product_in.Length - 2) + ")
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

                            If Not list_is_not_valid.Contains(column_check(j)) Then
                                list_is_not_valid.Add(column_check(j))
                            End If
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
                    query = "INSERT INTO tb_verification_master_p (id_comp, file_name, id_code_detail, created_date, created_by) VALUES (" + SLUEOnlineStore.EditValue.ToString + ", '" + addSlashes(TEFileName.EditValue.ToString) + "', " + SLUEDivision.EditValue.ToString + ", NOW(), " + id_employee_user + "); SELECT LAST_INSERT_ID();"

                    id_verification_master = execute_query(query, 0, True, "", "", "", "")

                    'detail
                    query = "INSERT INTO tb_verification_master_p_zalora (id_verification_master, SellerSku, Price, SalePrice, SellerSku_erp, Price_erp, SalePrice_erp) VALUES "

                    For i = 0 To data_excel.Rows.Count - 1
                        Dim SellerSku As String = data_excel.Rows(i)("SellerSku").ToString
                        Dim Price As String = data_excel.Rows(i)("Price").ToString
                        Dim SalePrice As String = data_excel.Rows(i)("SalePrice").ToString

                        Dim SellerSku_erp As String = ""
                        Dim Price_erp As String = ""
                        Dim SalePrice_erp As String = ""

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

                        query += "('" + id_verification_master + "', '" + SellerSku + "', '" + Price + "', '" + SalePrice + "', '" + SellerSku_erp + "', '" + Price_erp + "', '" + SalePrice_erp + "'), "
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

            GCVerification.DataSource = Nothing
            GVVerification.Columns.Clear()

            GCERP.DataSource = Nothing
            GVERP.Columns.Clear()

            Try
                workbook = app.Workbooks.Open(file_name)
                worksheet = workbook.Worksheets("Data")

                Dim data_excel As DataTable = New DataTable

                Dim row As Integer = 0
                Dim column As Integer = 0

                Dim continue_loop As Boolean = False

                Dim column_check As List(Of String) = New List(Of String)

                column_check.Add("SellerSKU")
                column_check.Add("HargaRp")
                column_check.Add("HargaPenjualanRp")

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

                        If column_name = "SellerSKU" Then
                            If Not value = "" Then
                                id_product_in += "'" + value + "', "
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

                Dim query As String = "
                    SELECT pro.product_full_code AS SellerSKU, FLOOR(de_pn.design_price) AS HargaRp, FLOOR(de_pc.design_price) AS HargaPenjualanRp " + column_is_valid + "
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
                    WHERE pro.product_full_code IN (" + id_product_in.Substring(0, id_product_in.Length - 2) + ")
                    ORDER BY pro.product_full_code ASC
                "

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

                            If Not list_is_not_valid.Contains(column_check(j)) Then
                                list_is_not_valid.Add(column_check(j))
                            End If
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
                    query = "INSERT INTO tb_verification_master_p (id_comp, id_template, file_name, id_code_detail, created_date, created_by) VALUES (" + SLUEOnlineStore.EditValue.ToString + ", " + SLUETemplate.EditValue.ToString + ", '" + addSlashes(TEFileName.EditValue.ToString) + "', " + SLUEDivision.EditValue.ToString + ", NOW(), " + id_employee_user + "); SELECT LAST_INSERT_ID();"

                    id_verification_master = execute_query(query, 0, True, "", "", "", "")

                    'detail
                    query = "INSERT INTO tb_verification_master_p_blibli (id_verification_master, SellerSKU, HargaRp, HargaPenjualanRp, SellerSKU_erp, HargaRp_erp, HargaPenjualanRp_erp) VALUES "

                    For i = 0 To data_excel.Rows.Count - 1
                        Dim SellerSKU As String = data_excel.Rows(i)("SellerSKU").ToString
                        Dim HargaRp As String = data_excel.Rows(i)("HargaRp").ToString
                        Dim HargaPenjualanRp As String = data_excel.Rows(i)("HargaPenjualanRp").ToString

                        Dim SellerSKU_erp As String = ""
                        Dim HargaRp_erp As String = ""
                        Dim HargaPenjualanRp_erp As String = ""

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

                        query += "('" + id_verification_master + "', '" + SellerSKU + "', '" + HargaRp + "', '" + HargaPenjualanRp + "', '" + SellerSKU_erp + "', '" + HargaRp_erp + "', '" + HargaPenjualanRp_erp + "'), "
                    Next

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

    Sub check_shopee(file_name As String)
        Dim app As New Microsoft.Office.Interop.Excel.Application
        Dim worksheet As Microsoft.Office.Interop.Excel.Worksheet
        Dim workbook As Microsoft.Office.Interop.Excel.Workbook

        app.DisplayAlerts = False

        If Not file_name = "" Then
            Cursor = Cursors.WaitCursor

            Try
                workbook = app.Workbooks.Open(file_name)
                worksheet = workbook.Worksheets("Sheet1")

                Dim data_excel As DataTable = New DataTable

                Dim row As Integer = 0
                Dim column As Integer = 0

                Dim continue_loop As Boolean = False

                Dim column_check As List(Of String) = New List(Of String)

                column_check.Add("SKU")
                column_check.Add("Harga")
                column_check.Add("HargaDiskon")

                'column
                row = 3
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

                        If column_name = "SKU" Then
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

                Dim q As String = "
                    SELECT pro.product_full_code AS SKU, FLOOR(de_pn.design_price) AS Harga, IF(de_pc.id_design_price_type = 1, 0, FLOOR(de_pc.design_price)) AS HargaDiskon
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

                Dim data_erp As DataTable = execute_query(q, -1, True, "", "", "", "")

                'validation
                For i = 0 To data_excel.Rows.Count - 1
                    For j = 0 To data_erp.Rows.Count - 1
                        If data_excel.Rows(i)("SKU").ToString = data_erp.Rows(j)("SKU").ToString Then
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
                        If data_erp.Rows(i)("SKU").ToString = data_excel.Rows(j)("SKU").ToString Then
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

                            If Not list_is_not_valid.Contains(column_check(j)) Then
                                list_is_not_valid.Add(column_check(j))
                            End If
                        End If
                    Next
                Next

                'sorting
                Dim data_view As DataView = New DataView(data_excel)
                data_view.Sort = "SKU ASC"
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
                    query = "INSERT INTO tb_verification_master_p (id_comp, id_template, file_name, id_code_detail, created_date, created_by) VALUES (" + SLUEOnlineStore.EditValue.ToString + ", " + SLUETemplate.EditValue.ToString + ", '" + addSlashes(TEFileName.EditValue.ToString) + "', " + SLUEDivision.EditValue.ToString + ", NOW(), " + id_employee_user + "); SELECT LAST_INSERT_ID();"

                    id_verification_master = execute_query(query, 0, True, "", "", "", "")

                    'detail
                    query = "INSERT INTO tb_verification_master_p_shopee (id_verification_master, SKU, Harga, HargaDiskon, SKU_erp, Harga_erp, HargaDiskon_erp) VALUES "

                    For i = 0 To data_excel.Rows.Count - 1
                        Dim SKU As String = data_excel.Rows(i)("SKU").ToString
                        Dim Harga As String = data_excel.Rows(i)("Harga").ToString
                        Dim HargaDiskon As String = data_excel.Rows(i)("HargaDiskon").ToString

                        Dim SKU_erp As String = ""
                        Dim Harga_erp As String = ""
                        Dim HargaDiskon_erp As String = ""

                        Try
                            SKU_erp = data_erp.Rows(i)("SKU").ToString
                        Catch ex As Exception
                        End Try

                        Try
                            Harga_erp = data_erp.Rows(i)("Harga").ToString
                        Catch ex As Exception
                        End Try

                        Try
                            HargaDiskon_erp = data_erp.Rows(i)("HargaDiskon").ToString
                        Catch ex As Exception
                        End Try

                        query += "('" + id_verification_master + "', '" + SKU + "', '" + Harga + "', '" + HargaDiskon + "', '" + SKU_erp + "', '" + Harga_erp + "', '" + HargaDiskon_erp + "'), "
                    Next

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

    Private Sub FormVerificationMasterPriceDet_Resize(sender As Object, e As EventArgs) Handles MyBase.Resize
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