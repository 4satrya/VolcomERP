Imports System.Data.OleDb
Imports MySql.Data.MySqlClient

Public Class FormImportExcel
    Private dataset_field As DataSet
    Public id_pop_up As String = "-1"
    '
    Public copy_file_path As String = ""
    ' List of id popup
    ' 1 = Sample Purchase
    ' 2 = Sample Planning
    Private Sub TBFileAddress_EditValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TBFileAddress.EditValueChanged
        If Not TBFileAddress.Text = "" Then
            fill_combo_worksheet()
        End If
    End Sub

    Private Sub CBWorksheetName_EditValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CBWorksheetName.EditValueChanged
        If Not CBWorksheetName.EditValue = "" Then
            Cursor = Cursors.WaitCursor
            fill_field_grid()
            Cursor = Cursors.Default
        End If
    End Sub
    Sub fill_combo_worksheet()
        Dim oledbconn As New OleDbConnection
        Dim strConn As String = ""
        Dim ExcelTables As DataTable
        Try
            copy_file_path = My.Application.Info.DirectoryPath.ToString & "\temp_import_xls." & IO.Path.GetExtension(TBFileAddress.Text)
            IO.File.Copy(TBFileAddress.Text, copy_file_path, True)

            Dim extension As String = IO.Path.GetExtension(copy_file_path)
            If extension.ToLower = ".xlsx" Then
                strConn = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source='" & copy_file_path.ToLower & "';Extended Properties=""Excel 12.0 XML; IMEX=1;HDR=YES;TypeGuessRows=0;ImportMixedTypes=Text;"""
            ElseIf extension.ToLower = ".xls" Then
                strConn = String.Format("Provider=Microsoft.ACE.OLEDB.12.0;Data Source={0};Extended Properties=""Excel 12.0 XML; IMEX=1;HDR=YES;TypeGuessRows=0;ImportMixedTypes=Text;""", copy_file_path.ToLower)
                'strConn = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source='" & TBFileAddress.Text.ToLower & "';Extended Properties=""Excel 12.0 XML; IMEX=1;HDR=YES;TypeGuessRows=0;ImportMixedTypes=Text;"""
            Else
                stopCustom("Make sure your file in .xls or .xlsx format.")
                Exit Sub
            End If

            oledbconn.ConnectionString = strConn
            oledbconn.Open()
            ExcelTables = oledbconn.GetOleDbSchemaTable(System.Data.OleDb.OleDbSchemaGuid.Tables, New Object() {Nothing, Nothing, Nothing, "TABLE"})
            oledbconn.Close()
            oledbconn.Dispose()
            Dim dr As DataRow
            Dim i As Integer = 0
            CBWorksheetName.Properties.Items.Clear()
            CBWorksheetName.EditValue = ""
            For Each dr In ExcelTables.Rows
                If dr.Item(3).ToString = "TABLE" Then
                    If InStr(dr.Item(2), "$") > 0 Then
                        i += 1
                        CBWorksheetName.Properties.Items.Add(dr.Item(2).ToString)
                        If i = 1 Then
                            CBWorksheetName.SelectedItem = dr.Item(2).ToString
                        End If
                    End If
                End If
            Next
            ExcelTables.Dispose()
        Catch ex As Exception
            stopCustom("- Please make sure your file not open and available to read." & vbNewLine & ex.ToString)
        End Try
    End Sub
    Sub fill_field_grid()
        Dim oledbconn As New OleDbConnection
        Dim strConn As String
        Dim data_temp As New DataTable

        GCData.DataSource = Nothing

        strConn = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source='" & copy_file_path.ToLower & "';Extended Properties=""Excel 12.0 XML; IMEX=1;HDR=YES;TypeGuessRows=0;ImportMixedTypes=Text;"""
        oledbconn.ConnectionString = strConn
        Dim MyCommand As OleDbDataAdapter

        If id_pop_up = "6" Or id_pop_up = "7" Then
            MyCommand = New OleDbDataAdapter("select code, SUM(qty) AS qty from [" & CBWorksheetName.SelectedItem.ToString & "] GROUP BY code", oledbconn)
        ElseIf id_pop_up = "8" Then
            MyCommand = New OleDbDataAdapter("select kode_barang, ket_barang, no_faktur, nama_toko, npwp, alamat, total, ppn, dpp, referensi from [" & CBWorksheetName.SelectedItem.ToString & "] where not ([no_faktur]='')", oledbconn)
        ElseIf id_pop_up = "11" Then
            MyCommand = New OleDbDataAdapter("select code, SUM(qty) AS qty from [" & CBWorksheetName.SelectedItem.ToString & "] where not ([code]='') GROUP BY code", oledbconn)
        ElseIf id_pop_up = "13" Or id_pop_up = "19" Then
            MyCommand = New OleDbDataAdapter("select * from [" & CBWorksheetName.SelectedItem.ToString & "] where not ([code]='')", oledbconn)
        ElseIf id_pop_up = "14" Then
            MyCommand = New OleDbDataAdapter("select * from [" & CBWorksheetName.SelectedItem.ToString & "] where not ([reg_no]='')", oledbconn)
        ElseIf id_pop_up = "15" Then
            MyCommand = New OleDbDataAdapter("select code, SUM(qty) AS qty from [" & CBWorksheetName.SelectedItem.ToString & "] where not ([code]='') GROUP BY code", oledbconn)
        ElseIf id_pop_up = "20" Then
            MyCommand = New OleDbDataAdapter("select code, wh, SUM(qty) AS qty from [" & CBWorksheetName.SelectedItem.ToString & "] where not ([code]='') GROUP BY code,wh", oledbconn)
        ElseIf id_pop_up = "21" Then
            MyCommand = New OleDbDataAdapter("select code, wh, store, SUM(qty) AS qty from [" & CBWorksheetName.SelectedItem.ToString & "] where not ([code]='') GROUP BY code,wh,store", oledbconn)
        ElseIf id_pop_up = "23" Or id_pop_up = "24" Then
            MyCommand = New OleDbDataAdapter("select VENDOR, KODE, NAMA, SIZETYP, `xxs/1`, `xs/2`, `s/3`, `m/4`, `ml/5`, `l/6`, `xl/7`, `xxl/8`, `all/9`, `~/0` from [" & CBWorksheetName.SelectedItem.ToString & "]", oledbconn)
        ElseIf id_pop_up = "25" Or id_pop_up = "29" Then
            MyCommand = New OleDbDataAdapter("select KODE, NAMA, SIZETYP, `xxs/1`, `xs/2`, `s/3`, `m/4`, `ml/5`, `l/6`, `xl/7`, `xxl/8`, `all/9`, `~/0` from [" & CBWorksheetName.SelectedItem.ToString & "] where not ([KODE]='')", oledbconn)
        ElseIf id_pop_up = "26" Then
            MyCommand = New OleDbDataAdapter("select no_faktur, nama_toko, npwp, alamat, id_keterangan_tambahan, kode_barang, ket_barang, jumlah_barang, harga_satuan, harga_total, diskon, ppn, dpp, jumlah_ppn, jumlah_dpp, referensi from [" & CBWorksheetName.SelectedItem.ToString & "] where not ([no_faktur]='')", oledbconn)
        Else
            MyCommand = New OleDbDataAdapter("select * from [" & CBWorksheetName.SelectedItem.ToString & "]", oledbconn)
        End If

        Try
            MyCommand.Fill(data_temp)
            MyCommand.Dispose()
        Catch ex As Exception
            stopCustom("Input must be in accordance with the format specified !")
            Exit Sub
        End Try

        If id_pop_up = "1" Then
            'sample purchase
            Dim id_sample, id_sample_price, name As String
            Dim total As Double

            id_sample = "0"
            id_sample_price = "0"
            name = ""

            total = 0

            dataset_field = New DataSet()
            dataset_field.Tables.Add("data_field")
            dataset_field.Tables("data_field").Columns.Add("id_sample_purc_det")
            dataset_field.Tables("data_field").Columns.Add("code")
            dataset_field.Tables("data_field").Columns.Add("name")
            dataset_field.Tables("data_field").Columns.Add("price")
            dataset_field.Tables("data_field").Columns.Add("qty")
            dataset_field.Tables("data_field").Columns.Add("discount")
            dataset_field.Tables("data_field").Columns.Add("total")
            dataset_field.Tables("data_field").Columns.Add("id_sample_price")
            '
            Try
                For i As Integer = 0 To data_temp.Rows.Count - 1
                    total = (Double.Parse(data_temp.Rows(i).Item("price").ToString) * Double.Parse(data_temp.Rows(i).Item("qty").ToString)) - Double.Parse(data_temp.Rows(i).Item("discount").ToString)
                    Try
                        id_sample = get_id_sample_fcode(data_temp.Rows(i).Item("code").ToString)
                        id_sample_price = get_sample_x(id_sample, "1")
                        name = get_sample_x(id_sample, "2")
                    Catch ex As Exception
                        id_sample_price = "0"
                        name = "Sample not found"
                    End Try
                    '
                    dataset_field.Tables("data_field").Rows.Add("0", data_temp.Rows(i).Item("code").ToString, name, data_temp.Rows(i).Item("price").ToString, data_temp.Rows(i).Item("qty").ToString, data_temp.Rows(i).Item("discount").ToString, total.ToString, id_sample_price)
                    '
                    GCData.DataSource = dataset_field.Tables("data_field")
                    GVData.Columns("id_sample_purc_det").Visible = False
                    GVData.Columns("id_sample_price").Visible = False
                Next
            Catch ex As Exception
                stopCustom("Incorrect format on table.")
            End Try
        ElseIf id_pop_up = "2" Then
            'sample planning
            Dim id_sample, name, sizex As String

            id_sample = "0"
            name = ""

            dataset_field = New DataSet()
            dataset_field.Tables.Add("data_field")
            dataset_field.Tables("data_field").Columns.Add("id_sample")
            dataset_field.Tables("data_field").Columns.Add("code")
            dataset_field.Tables("data_field").Columns.Add("name")
            dataset_field.Tables("data_field").Columns.Add("size")
            dataset_field.Tables("data_field").Columns.Add("qty")
            dataset_field.Tables("data_field").Columns.Add("note")
            '
            Try
                For i As Integer = 0 To data_temp.Rows.Count - 1
                    Try
                        id_sample = get_id_sample_fcode(data_temp.Rows(i).Item("code").ToString)
                        name = get_sample_x(id_sample, "2")
                        sizex = get_sample_x(id_sample, "3")
                    Catch ex As Exception
                        id_sample = "0"
                        name = "Sample not found"
                        sizex = "-"
                    End Try
                    '
                    dataset_field.Tables("data_field").Rows.Add(id_sample, data_temp.Rows(i).Item("code").ToString, name, sizex, data_temp.Rows(i).Item("qty").ToString, data_temp.Rows(i).Item("note").ToString)
                    '
                    GCData.DataSource = dataset_field.Tables("data_field")
                    GVData.Columns("id_sample").Visible = False
                Next
            Catch ex As Exception
                stopCustom("Incorrect format on table.")
            End Try
        ElseIf id_pop_up = "3" Then
            ''SOH Volcom
            'Dim id_sample, name As String

            'id_sample = "0"
            'name = ""

            'dataset_field = New DataSet()
            'dataset_field.Tables.Add("data_field")
            'dataset_field.Tables("data_field").Columns.Add("prod_code")
            'dataset_field.Tables("data_field").Columns.Add("style_code")
            'dataset_field.Tables("data_field").Columns.Add("prod_class")
            'dataset_field.Tables("data_field").Columns.Add("prod_desc")
            'dataset_field.Tables("data_field").Columns.Add("prod_aging")
            'dataset_field.Tables("data_field").Columns.Add("prod_source")
            'dataset_field.Tables("data_field").Columns.Add("prod_size")
            'dataset_field.Tables("data_field").Columns.Add("qty")
            'dataset_field.Tables("data_field").Columns.Add("prod_price")
            'dataset_field.Tables("data_field").Columns.Add("prod_sale")
            'dataset_field.Tables("data_field").Columns.Add("prod_cost")
            'dataset_field.Tables("data_field").Columns.Add("prod_margin")
            'dataset_field.Tables("data_field").Columns.Add("prod_date")
            'dataset_field.Tables("data_field").Columns.Add("prod_range")
            'dataset_field.Tables("data_field").Columns.Add("prod_reff")
            'dataset_field.Tables("data_field").Columns.Add("prod_status")

            ''
            Try
                GCData.DataSource = Nothing
                GCData.DataSource = data_temp
                GCData.RefreshDataSource()
                GVData.PopulateColumns()
            Catch ex As Exception
                stopCustom("Incorrect format on table.")
            End Try
        ElseIf id_pop_up = "4" Then
            ''SOH Store
            Try
                GCData.DataSource = Nothing
                GCData.DataSource = data_temp
                GCData.RefreshDataSource()
                GVData.PopulateColumns()
            Catch ex As Exception
                stopCustom("Incorrect format on table.")
            End Try
        ElseIf id_pop_up = "5" Then
            ''SOH Store
            Try
                GCData.DataSource = Nothing
                GCData.DataSource = data_temp
                GCData.RefreshDataSource()
                GVData.PopulateColumns()
            Catch ex As Exception
                stopCustom("Incorrect format on table.")
            End Try
        ElseIf id_pop_up = "6" Then
            'SALES INVOICE
            Try
                Dim dt As DataTable = FormSalesPOSDet.dt_stock_store
                Dim tb1 = data_temp.AsEnumerable()
                Dim tb2 = dt.AsEnumerable()

                Dim query = From table1 In tb1
                            Group Join table_tmp In tb2 On table1("code") Equals table_tmp("code")
                            Into Group
                            From y1 In Group.DefaultIfEmpty()
                            Select New With
                            {
                                .Code = table1.Field(Of String)("code"),
                                .Description = If(y1 Is Nothing, "", y1("name")),
                                .Size = If(y1 Is Nothing, "", y1("size")),
                                .UOM = If(y1 Is Nothing, "", y1("uom")),
                                .Amount = If(y1 Is Nothing, "", table1("qty") * y1("design_price_retail")),
                                .Qty = CType(table1("qty"), Decimal),
                                .Qty_Volcom = If(y1 Is Nothing, 0.0, y1("qty_all_product")),
                                .Price = If(y1 Is Nothing, 0.0, y1("design_price_retail")),
                                .id_design_price_retail = If(y1 Is Nothing, 0, y1("id_design_price_retail")),
                                .design_price_type = If(y1 Is Nothing, "", y1("design_price_type")),
                                .design_price = If(y1 Is Nothing, 0.0, y1("design_price")),
                                .sales_pos_det_note = If(y1 Is Nothing, "", ""),
                                .id_design = If(y1 Is Nothing, 0, y1("id_design")),
                                .id_product = If(y1 Is Nothing, 0, y1("id_product")),
                                .id_sample = If(y1 Is Nothing, 0, y1("id_sample")),
                                .id_design_price = If(y1 Is Nothing, 0, y1("id_design_price")),
                                .Type = If(y1 Is Nothing, "", y1("design_price_type")),
                                .id_sales_pos_det = If(y1 Is Nothing, "", "0"),
                                .Color = If(y1 Is Nothing, "", y1("color")),
                                .Diff = If((CType(table1("qty"), Decimal) - If(y1 Is Nothing, 0.0, y1("qty_all_product"))) <= 0, 0.0, (CType(table1("qty"), Decimal) - If(y1 Is Nothing, 0.0, y1("qty_all_product"))))
                            }

                GCData.DataSource = Nothing
                GCData.DataSource = query.ToList()
                GCData.RefreshDataSource()
                GVData.PopulateColumns()

                'Customize column
                GVData.Columns("Code").VisibleIndex = 0
                GVData.Columns("Description").VisibleIndex = 1
                GVData.Columns("Size").VisibleIndex = 2
                GVData.Columns("Qty").VisibleIndex = 3
                GVData.Columns("Qty").Caption = "Qty Store"
                GVData.Columns("Qty").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                GVData.Columns("Qty").DisplayFormat.FormatString = "{0:n2}"
                GVData.Columns("Qty_Volcom").VisibleIndex = 4
                GVData.Columns("Qty_Volcom").Caption = "Qty Limit"
                GVData.Columns("Qty_Volcom").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                GVData.Columns("Qty_Volcom").DisplayFormat.FormatString = "{0:n2}"
                GVData.Columns("Price").VisibleIndex = 5
                GVData.Columns("Price").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                GVData.Columns("Price").DisplayFormat.FormatString = "{0:n2}"
                GVData.Columns("Diff").VisibleIndex = 6
                GVData.Columns("Diff").Caption = "Over Qty"
                GVData.Columns("Diff").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                GVData.Columns("Diff").DisplayFormat.FormatString = "{0:n2}"
                GVData.Columns("UOM").Visible = False
                GVData.Columns("id_design_price_retail").Visible = False
                GVData.Columns("design_price_type").Visible = False
                GVData.Columns("design_price").Visible = False
                GVData.Columns("sales_pos_det_note").Visible = False
                GVData.Columns("id_design").Visible = False
                GVData.Columns("id_product").Visible = False
                GVData.Columns("id_sample").Visible = False
                GVData.Columns("id_design_price").Visible = False
                GVData.Columns("Type").Visible = False
                GVData.Columns("id_sales_pos_det").Visible = False
                GVData.Columns("Color").Visible = False
                GVData.Columns("Amount").Visible = False
            Catch ex As Exception
                stopCustom("Incorrect format on table.")
            End Try
        ElseIf id_pop_up = "7" Then
            'SALES INVOICE
            Try
                Dim dt As DataTable = FormFGMissingDet.dt_stock_store
                Dim tb1 = data_temp.AsEnumerable()
                Dim tb2 = dt.AsEnumerable()

                Dim query = From table1 In tb1
                            Group Join table_tmp In tb2 On table1("code") Equals table_tmp("code")
                            Into Group
                            From y1 In Group.DefaultIfEmpty()
                            Select New With
                            {
                                .Code = table1.Field(Of String)("code"),
                                .Description = If(y1 Is Nothing, "", y1("name")),
                                .Size = If(y1 Is Nothing, "", y1("size")),
                                .UOM = If(y1 Is Nothing, "", y1("uom")),
                                .Amount = If(y1 Is Nothing, "", table1("qty") * y1("design_price")),
                                .Qty = CType(table1("qty"), Decimal),
                                .Qty_Volcom = If(y1 Is Nothing, 0.0, y1("qty_all_product")),
                                .Price = If(y1 Is Nothing, 0.0, y1("design_price_retail")),
                                .id_design_price_retail = If(y1 Is Nothing, 0, y1("id_design_price_retail")),
                                .design_price_type = If(y1 Is Nothing, "", y1("design_price_type")),
                                .design_price = If(y1 Is Nothing, 0.0, y1("design_price")),
                                .sales_pos_det_note = If(y1 Is Nothing, "", ""),
                                .id_design = If(y1 Is Nothing, 0, y1("id_design")),
                                .id_product = If(y1 Is Nothing, 0, y1("id_product")),
                                .id_sample = If(y1 Is Nothing, 0, y1("id_sample")),
                                .id_design_price = If(y1 Is Nothing, 0, y1("id_design_price")),
                                .Type = If(y1 Is Nothing, "", y1("design_price_type")),
                                .id_sales_pos_det = If(y1 Is Nothing, "", "0"),
                                .Color = If(y1 Is Nothing, "", y1("color")),
                                .Diff = If((CType(table1("qty"), Decimal) - If(y1 Is Nothing, 0.0, y1("qty_all_product"))) <= 0, 0.0, (CType(table1("qty"), Decimal) - If(y1 Is Nothing, 0.0, y1("qty_all_product"))))
                            }

                GCData.DataSource = Nothing
                GCData.DataSource = query.ToList()
                GCData.RefreshDataSource()
                GVData.PopulateColumns()

                'Customize column
                GVData.Columns("Code").VisibleIndex = 0
                GVData.Columns("Description").VisibleIndex = 1
                GVData.Columns("Size").VisibleIndex = 2
                GVData.Columns("Qty").VisibleIndex = 3
                GVData.Columns("Qty").Caption = "Qty Store"
                GVData.Columns("Qty").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                GVData.Columns("Qty").DisplayFormat.FormatString = "{0:n2}"
                GVData.Columns("Qty_Volcom").VisibleIndex = 4
                GVData.Columns("Qty_Volcom").Caption = "Qty Limit"
                GVData.Columns("Qty_Volcom").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                GVData.Columns("Qty_Volcom").DisplayFormat.FormatString = "{0:n2}"
                GVData.Columns("design_price").VisibleIndex = 5
                GVData.Columns("design_price").Caption = "Price"
                GVData.Columns("design_price").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                GVData.Columns("design_price").DisplayFormat.FormatString = "{0:n2}"
                GVData.Columns("Diff").VisibleIndex = 6
                GVData.Columns("Diff").Caption = "Over Qty"
                GVData.Columns("Diff").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                GVData.Columns("Diff").DisplayFormat.FormatString = "{0:n2}"
                GVData.Columns("UOM").Visible = False
                GVData.Columns("id_design_price_retail").Visible = False
                GVData.Columns("design_price_type").Visible = False
                GVData.Columns("Price").Visible = False
                GVData.Columns("sales_pos_det_note").Visible = False
                GVData.Columns("id_design").Visible = False
                GVData.Columns("id_product").Visible = False
                GVData.Columns("id_sample").Visible = False
                GVData.Columns("id_design_price").Visible = False
                GVData.Columns("Type").Visible = False
                GVData.Columns("id_sales_pos_det").Visible = False
                GVData.Columns("Color").Visible = False
                GVData.Columns("Amount").Visible = False
            Catch ex As Exception
                stopCustom("Incorrect format on table.")
            End Try
        ElseIf id_pop_up = "8" Then
            'FAKTUR KELUARAN
            Try
                GCData.DataSource = Nothing
                GCData.DataSource = data_temp
                GCData.RefreshDataSource()
                GVData.PopulateColumns()
            Catch ex As Exception
                stopCustom("Incorrect format on table.")
            End Try
        ElseIf id_pop_up = "9" Then
            ''DISTRIBUTION SCHEME
            Try
                GCData.DataSource = Nothing
                GCData.DataSource = data_temp
                GCData.RefreshDataSource()
                GVData.PopulateColumns()
            Catch ex As Exception
                stopCustom("Incorrect format on table.")
            End Try
        ElseIf id_pop_up = "10" Then
            ''SO NEW
            Try
                GCData.DataSource = Nothing
                GCData.DataSource = data_temp
                GCData.RefreshDataSource()
                GVData.PopulateColumns()
            Catch ex As Exception
                stopCustom("Incorrect format on table.")
            End Try
        ElseIf id_pop_up = "11" Then
            'RETURN ORDER
            Try
                Dim dt As DataTable = execute_query("CALL view_stock_fg('" + FormSalesReturnOrderDet.id_comp + "', '" + FormSalesReturnOrderDet.id_wh_locator + "', '" + FormSalesReturnOrderDet.id_wh_rack + "', '" + FormSalesReturnOrderDet.id_wh_drawer + "', '0', '4', '9999-01-01') ", -1, True, "", "", "", "")
                Dim tb1 = data_temp.AsEnumerable()
                Dim tb2 = dt.AsEnumerable()
                Dim query = From table1 In tb1
                            Group Join table_tmp In tb2 On table1("code").ToString Equals table_tmp("code").ToString
                            Into Group
                            From y1 In Group.DefaultIfEmpty()
                            Select New With
                            {
                                .Code = table1.Field(Of String)("code"),
                                .Style = If(y1 Is Nothing, "", y1("name")),
                                .Size = If(y1 Is Nothing, "", y1("size")),
                                .Amount = If(y1 Is Nothing, 0, If(table1("qty").ToString = "", If(y1 Is Nothing, 0, y1("qty_all_product")), CType(table1("qty"), Decimal)) * y1("design_price_retail")),
                                .SOH = If(y1 Is Nothing, 0, y1("qty_all_product")),
                                .Qty = If(table1("qty").ToString = "", If(y1 Is Nothing, 0, y1("qty_all_product")), CType(table1("qty"), Decimal)),
                                .Price = If(y1 Is Nothing, 0.0, y1("design_price_retail")),
                                .id_design_price_retail = If(y1 Is Nothing, 0, y1("id_design_price_retail")),
                                .id_design = If(y1 Is Nothing, 0, y1("id_design")),
                                .id_product = If(y1 Is Nothing, 0, y1("id_product")),
                                .Color = If(y1 Is Nothing, "", y1("color")),
                                .Status = If(y1 Is Nothing, "Not found", "OK")
                            }
                '.Note = table1.Field(Of String)("note"),
                GCData.DataSource = Nothing
                GCData.DataSource = query.ToList()
                GCData.RefreshDataSource()
                GVData.PopulateColumns()

                'Customize column
                GVData.Columns("id_design_price_retail").Visible = False
                GVData.Columns("id_design").Visible = False
                GVData.Columns("id_product").Visible = False
                GVData.Columns("Color").Visible = False
                GVData.Columns("Amount").Visible = False
                GVData.Columns("Price").Visible = False
                GVData.Columns("SOH").Visible = False
                GVData.Columns("Code").VisibleIndex = 0
                GVData.Columns("Style").VisibleIndex = 1
                GVData.Columns("Size").VisibleIndex = 2
                GVData.Columns("Qty").VisibleIndex = 3
                ' GVData.Columns("Note").VisibleIndex = 4
                GVData.Columns("Status").VisibleIndex = 5
                GVData.Columns("Qty").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                GVData.Columns("Qty").DisplayFormat.FormatString = "{0:n0}"
                GVData.Columns("SOH").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                GVData.Columns("SOH").DisplayFormat.FormatString = "{0:n0}"

                'check duplicate
                Dim dt_check As DataTable = FormSalesReturnOrderDet.GCItemList.DataSource
                For i As Integer = 0 To GVData.RowCount - 1
                    Dim dt_filter As DataRow() = dt_check.Select("[id_product]='" + GVData.GetRowCellValue(i, "id_product").ToString + "' ")
                    If dt_filter.Length > 0 Then
                        GVData.SetRowCellValue(i, "Status", "Already in order list")
                    End If
                Next
            Catch ex As Exception
                stopCustom("Incorrect format on table.")
            End Try
        ElseIf id_pop_up = "12" Then
            Try
                Dim query_size As String = "SELECT id_code_detail,display_name FROM tb_m_code_detail WHERE id_code='13'"
                Dim data_size As DataTable = execute_query(query_size, -1, True, "", "", "", "")

                Dim query_color As String = "SELECT id_code_detail,display_name,id_code FROM tb_m_code_detail WHERE id_code='1'"
                Dim data_color As DataTable = execute_query(query_color, -1, True, "", "", "", "")

                Dim query_vendor As String = "SELECT c.id_comp as id_comp,cc.id_comp_contact,comp_number,c.comp_name FROM tb_m_comp c LEFT JOIN tb_m_comp_contact cc ON cc.id_comp=c.id_comp AND cc.is_default = '1' WHERE c.id_comp_cat='1'"
                Dim data_vendor As DataTable = execute_query(query_vendor, -1, True, "", "", "", "")

                Dim query_mat_det As String = "SELECT id_mat_det,mat_det_code FROM tb_m_mat_det"
                Dim data_mat_det As DataTable = execute_query(query_mat_det, -1, True, "", "", "", "")

                Dim query_year As String = "SELECT id_code_detail,display_name,code FROM tb_m_code_detail where id_code='12'"
                Dim data_year As DataTable = execute_query(query_year, -1, True, "", "", "", "")

                Dim query_counting As String = "SELECT id_code_detail,display_name,code FROM tb_m_code_detail where id_code='10'"
                Dim data_counting As DataTable = execute_query(query_counting, -1, True, "", "", "", "")

                Dim query_lot As String = "SELECT id_code_detail,display_name,code FROM tb_m_code_detail where id_code='11'"
                Dim data_lot As DataTable = execute_query(query_lot, -1, True, "", "", "", "")

                Dim query_mat As String = "SELECT id_mat,mat_code,id_mat_cat,mat_name FROM tb_m_mat WHERE is_old!='1'"
                Dim data_mat As DataTable = execute_query(query_mat, -1, True, "", "", "", "")

                Dim query_range As String = "SELECT id_range,`range` FROM tb_range"
                Dim data_range As DataTable = execute_query(query_range, -1, True, "", "", "", "")

                Dim query_curr As String = "SELECT id_currency,currency FROM tb_lookup_currency"
                Dim data_curr As DataTable = execute_query(query_curr, -1, True, "", "", "", "")

                Dim tb1 = data_temp.AsEnumerable() 'datatable xls
                Dim tb2 = data_size.AsEnumerable()
                Dim tb3 = data_color.AsEnumerable()
                Dim tb4 = data_vendor.AsEnumerable()
                Dim tb5 = data_mat_det.AsEnumerable()
                Dim tb6 = data_year.AsEnumerable()
                Dim tb7 = data_counting.AsEnumerable()
                Dim tb8 = data_lot.AsEnumerable()
                Dim tb9 = data_mat.AsEnumerable()
                Dim tb10 = data_range.AsEnumerable()
                Dim tb11 = data_curr.AsEnumerable()

                Dim query = From xls In tb1 'left join xls dgn size menjadi sizejoin
                            Group Join size In tb2
                            On xls("size") Equals size("display_name") Into sizejoin = Group
                            From resultsize In sizejoin.DefaultIfEmpty()
                            Group Join color In tb3 'left join xls dgn color menjadi colorjoin 'On xls("color").ToString.ToLower Equals color("display_name").ToString.ToLower And New {ID = trans.id, Flow = (Byte)1} Into colorjoin = Group
                            On xls("color").ToString.ToLower Equals color("display_name").ToString.ToLower Into colorjoin = Group
                            From resultcolor In colorjoin.DefaultIfEmpty()
                            Group Join vendor In tb4 'left join xls dgn vendor menjadi vendorjoin
                            On xls("vendor").ToString.ToLower Equals vendor("comp_number").ToString.ToLower Into vendorjoin = Group
                            From resultvendor In vendorjoin.DefaultIfEmpty()
                            Group Join mat_det In tb5 'left join xls dgn matdet menjadi matdetjoin
                            On xls("code").ToString.ToLower Equals mat_det("mat_det_code").ToString.ToLower Into matdetjoin = Group
                            From resultMatDet In matdetjoin.DefaultIfEmpty()
                            Group Join year In tb6 'left join xls dgn year menjadi yearjoin
                            On xls("code").ToString.ToLower.Substring(2, 2) Equals year("code").ToString.ToLower Into yearjoin = Group
                            From resultyear In yearjoin.DefaultIfEmpty()
                            Group Join count In tb7 'left join xls dgn count menjadi countjoin
                            On xls("code").ToString.ToLower.Substring(7, 2) Equals count("code").ToString.ToLower Into countjoin = Group
                            From resultcount In countjoin.DefaultIfEmpty()
                            Group Join lot In tb8 'left join xls dgn lot menjadi lotjoin
                            On xls("code").ToString.ToLower.Substring(11, 1) Equals lot("code").ToString.ToLower Into lotjoin = Group
                            From resultlot In lotjoin.DefaultIfEmpty()
                            Group Join mat In tb9 'left join xls dgn mat menjadi matjoin
                            On xls("code").ToString.ToLower.Substring(0, 2) Equals mat("mat_code").ToString.ToLower And xls("cat").ToString Equals mat("id_mat_cat").ToString Into matjoin = Group
                            From resultmat In matjoin.DefaultIfEmpty()
                            Group Join range In tb10 'left join xls dgn range menjadi rangejoin
                            On xls("range").ToString Equals range("range").ToString Into rangejoin = Group
                            From resultrange In rangejoin.DefaultIfEmpty()
                            Group Join curr In tb11 'left join xls dgn range menjadi currjoin
                            On xls("currency").ToString.ToLower Equals curr("currency").ToString.ToLower Into currjoin = Group
                            From resultcurr In currjoin.DefaultIfEmpty()
                            Select New With
                        {
                            .Code = xls("code").ToString,
                            .id_mat_det = If(resultMatDet Is Nothing, "", resultMatDet("id_mat_det")),
                            .id_mat = If(resultmat Is Nothing, "", resultmat("id_mat")),
                            .Type = If(resultmat Is Nothing, "", resultmat("mat_name")),
                            .Description = xls("desc").ToString,
                            .Size = xls("size").ToString,
                            .id_code_detail_size = If(resultsize Is Nothing, "", resultsize("id_code_detail")),
                            .Color = xls("color").ToString,
                            .id_code_detail_color = If(resultcolor Is Nothing, "", resultcolor("id_code_detail")),
                            .id_range = If(resultrange Is Nothing, "", resultrange("id_range")),
                            .Range = xls("range").ToString,
                            .Vendor = xls("vendor").ToString,
                            .id_comp_contact = If(resultvendor Is Nothing, "", resultvendor("id_comp_contact")),
                            .id_code_detail_year = If(resultyear Is Nothing, "", resultyear("id_code_detail")),
                            .id_code_detail_count = If(resultcount Is Nothing, "", resultcount("id_code_detail")),
                            .id_code_detail_lot = If(resultlot Is Nothing, "", resultlot("id_code_detail")),
                            .Currency = xls("currency").ToString,
                            .id_currency = If(resultcurr Is Nothing, "", resultcurr("id_currency")),
                            .Price = If(xls("price").ToString = "", 0, xls("price")),
                            .err_format = If(resultMatDet Is Nothing, "", "This code already on database; ") + If(resultmat Is Nothing, "Material Type not found; ", "") + If(resultrange Is Nothing, "Range not found; ", "") + If(resultsize Is Nothing, "Size not found; ", "") + If(resultcolor Is Nothing, "Color not found; ", "") + If(resultyear Is Nothing, "Year code not found; ", "") + If(resultcount Is Nothing, "Count code not found; ", "") + If(resultlot Is Nothing, "Lot code not found; ", "") + If(resultvendor Is Nothing, "Vendor code not found; ", "") + If(resultcurr Is Nothing, "Currency not found; ", "")
                        }

                GCData.DataSource = Nothing
                GCData.DataSource = query.ToList()
                GCData.RefreshDataSource()
                GVData.PopulateColumns()

                'check duplicate
                Dim j As Integer = 0
                For j = 0 To GVData.RowCount - 1
                    Dim filteredList = query.ToList.Where(Function(x) x.Code = GVData.GetRowCellValue(j, "Code")).ToList()
                    If filteredList.Count > 1 Then
                        GVData.SetRowCellValue(j, "err_format", "Duplicate in import list; " + GVData.GetRowCellValue(j, "err_format").ToString)
                    End If
                Next

                'Customize column
                GVData.Columns("Type").VisibleIndex = 0
                GVData.Columns("Code").VisibleIndex = 1
                GVData.Columns("Description").VisibleIndex = 2
                GVData.Columns("Size").VisibleIndex = 3
                GVData.Columns("Color").VisibleIndex = 4
                GVData.Columns("Vendor").VisibleIndex = 5
                GVData.Columns("Range").VisibleIndex = 6
                '
                GVData.Columns("err_format").Caption = "Error Format"
                '
                GVData.Columns("id_code_detail_size").Visible = False
                GVData.Columns("id_code_detail_color").Visible = False
                GVData.Columns("id_code_detail_year").Visible = False
                GVData.Columns("id_code_detail_count").Visible = False
                GVData.Columns("id_code_detail_lot").Visible = False
                GVData.Columns("id_comp_contact").Visible = False
                GVData.Columns("id_mat").Visible = False
                GVData.Columns("id_mat_det").Visible = False
                GVData.Columns("id_range").Visible = False
                GVData.Columns("id_currency").Visible = False

                GVData.BestFitColumns()

            Catch ex As Exception
                stopCustom("Incorrect format on table.")
            End Try
        ElseIf id_pop_up = "13" Then
            ''MASTER PRICE
            Try
                Dim dt As DataTable = execute_query("call view_all_design_param('AND f1.id_active=1 ')", -1, True, "", "", "", "")
                Dim tb1 = data_temp.AsEnumerable()
                Dim tb2 = dt.AsEnumerable()
                Dim query = From table1 In tb1
                            Group Join table_tmp In tb2 On table1("code").ToString Equals table_tmp("design_code").ToString
                            Into Group
                            From y1 In Group.DefaultIfEmpty()
                            Select New With
                            {
                                .Code = table1.Field(Of String)("code").ToString,
                                .Style = If(y1 Is Nothing, "", y1("design_display_name")),
                                .Class = If(y1 Is Nothing, "", y1("product_class_display")),
                                .PriceName = table1.Field(Of String)("price_name").ToString,
                                .Price = table1("price"),
                                .id_design = If(y1 Is Nothing, 0, y1("id_design")),
                                .id_currency = "1",
                                .is_print = If(table1("is_print").ToString > "0", "1", "0"),
                                .PrintOnTag = If(table1("is_print").ToString > "0", "Yes", "No"),
                                .Status = If(y1 Is Nothing, "Not found", "OK")
                            }
                GCData.DataSource = Nothing
                GCData.DataSource = query.ToList()
                GCData.RefreshDataSource()
                GVData.PopulateColumns()

                'Customize column
                GVData.Columns("id_design").Visible = False
                GVData.Columns("id_currency").Visible = False
                GVData.Columns("is_print").Visible = False
                GVData.Columns("Code").VisibleIndex = 0
                GVData.Columns("Style").VisibleIndex = 1
                GVData.Columns("Class").VisibleIndex = 2
                GVData.Columns("PriceName").VisibleIndex = 3
                GVData.Columns("Price").VisibleIndex = 4
                GVData.Columns("PrintOnTag").VisibleIndex = 5
                GVData.Columns("Status").VisibleIndex = 6
                GVData.Columns("Price").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                GVData.Columns("Price").DisplayFormat.FormatString = "{0:n2}"

                'check duplicate in - sementara gk dipake karena tiap import delete all dan tdk ada editing di item list
                'Dim dt_check As DataTable = FormMasterPriceSingle.GCItemList.DataSource
                'For i As Integer = 0 To GVData.RowCount - 1
                '    Dim dt_filter As DataRow() = dt_check.Select("[id_design]='" + GVData.GetRowCellValue(i, "id_design").ToString + "' ")
                '    If dt_filter.Length > 0 Then
                '        GVData.SetRowCellValue(i, "Status", "Already in item list")
                '    End If
                'Next

                'check duplicate
                Dim j As Integer = 0
                For j = 0 To GVData.RowCount - 1
                    If GVData.GetRowCellValue(j, "Status") = "OK" Then
                        Dim filteredList = query.ToList.Where(Function(x) x.Code = GVData.GetRowCellValue(j, "Code")).ToList()
                        If filteredList.Count > 1 Then
                            GVData.SetRowCellValue(j, "Status", "Duplicate in import list")
                        End If
                    End If
                Next
            Catch ex As Exception
                stopCustom("Incorrect format on table.")
            End Try
        ElseIf id_pop_up = "14" Then
            Try
                Dim query_do As String = "SELECT * FROM tb_wh_awb_do"
                Dim data_do As DataTable = execute_query(query_do, -1, True, "", "", "", "")

                Dim tb1 = data_temp.AsEnumerable() 'datatable xls
                Dim tb2 = data_do.AsEnumerable()
                Dim query = From xls In tb1
                            Group Join dox In tb2
                                On xls("reg_no") Equals dox("do_no") Into dojoin = Group
                            From doresult In dojoin.DefaultIfEmpty()
                            Select New With {
                                    .DO = xls("reg_no").ToString,
                                    .Date = xls("reg_dt").ToString,
                                    .StoreNumber = xls("reg_cuscd").ToString,
                                    .StoreName = xls("reg_name").ToString,
                                    .Reff = xls("reg_reff").ToString,
                                    .Qty = xls("reg_qty").ToString,
                                    .Status = If(doresult Is Nothing, "OK", "This code already on database")
                                }
                GCData.DataSource = Nothing
                GCData.DataSource = query.ToList()
                GCData.RefreshDataSource()
                GVData.PopulateColumns()
            Catch ex As Exception
                stopCustom("Incorrect format on table.")
            End Try
        ElseIf id_pop_up = "15" Then
            'RETURN ORDER
            Try
                Dim dt As DataTable = execute_query("CALL view_sales_order_prod_list('0', '" + FormSalesOrderDet.id_comp_par + "', '" + FormSalesOrderDet.id_store + "')", -1, True, "", "", "", "")
                Dim tb1 = data_temp.AsEnumerable()
                Dim tb2 = dt.AsEnumerable()
                Dim query = From table1 In tb1
                            Group Join table_tmp In tb2 On table1("code").ToString Equals table_tmp("product_full_code").ToString
                            Into Group
                            From y1 In Group.DefaultIfEmpty()
                            Select New With
                            {
                                .Code = table1.Field(Of String)("code"),
                                .Style = If(y1 Is Nothing, "", y1("design_display_name")),
                                .Size = If(y1 Is Nothing, "", y1("Size")),
                                .Price = If(y1 Is Nothing, 0.0, y1("design_price")),
                                .Available = If(y1 Is Nothing, 0, y1("total_allow")),
                                .Qty = If(table1("qty").ToString = "", 0, CType(table1("qty"), Decimal)),
                                .id_design_price = If(y1 Is Nothing, 0, y1("id_design_price")),
                                .id_product = If(y1 Is Nothing, 0, y1("id_product")),
                                .id_design = If(y1 Is Nothing, 0, y1("id_design")),
                                .design_price_type = If(y1 Is Nothing, 0, y1("design_price_type")),
                                .Status = If(y1 Is Nothing, "Not found", If(If(table1("qty").ToString = "", 0, CType(table1("qty"), Decimal)) > If(y1 Is Nothing, 0, y1("total_allow")), "Input qty exceed available qty", "OK"))
                            }
                GCData.DataSource = Nothing
                GCData.DataSource = query.ToList()
                GCData.RefreshDataSource()
                GVData.PopulateColumns()

                'Customize column
                GVData.Columns("id_design_price").Visible = False
                GVData.Columns("design_price_type").Visible = False
                GVData.Columns("id_product").Visible = False
                GVData.Columns("id_design").Visible = False
                GVData.Columns("Code").VisibleIndex = 0
                GVData.Columns("Style").VisibleIndex = 1
                GVData.Columns("Size").VisibleIndex = 2
                GVData.Columns("Price").VisibleIndex = 3
                GVData.Columns("Available").VisibleIndex = 4
                GVData.Columns("Qty").VisibleIndex = 5
                GVData.Columns("Status").VisibleIndex = 6
                GVData.Columns("Available").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                GVData.Columns("Available").DisplayFormat.FormatString = "{0:n0}"
                GVData.Columns("Qty").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                GVData.Columns("Qty").DisplayFormat.FormatString = "{0:n0}"

                'check duplicate
                Dim dt_check As DataTable = FormSalesOrderDet.GCItemList.DataSource
                For i As Integer = 0 To GVData.RowCount - 1
                    Dim dt_filter As DataRow() = dt_check.Select("[id_product]='" + GVData.GetRowCellValue(i, "id_product").ToString + "' ")
                    If dt_filter.Length > 0 Then
                        GVData.SetRowCellValue(i, "Status", "Already in order list")
                    End If
                Next
            Catch ex As Exception
                stopCustom("Incorrect format on table.")
            End Try
        ElseIf id_pop_up = "16" Then
            'import bom ecop
            Try
                Dim id_ovh_estimate As String = get_setup_field("id_ovh_estimate")

                Dim query_master As String = "CALL view_all_design_param('AND f1.id_active=1 ')"
                Dim data_master As DataTable = execute_query(query_master, -1, True, "", "", "", "")

                Dim query_vendor_ovh As String = "SELECT ovhp.id_ovh_price,c.id_comp AS id_comp,cc.id_comp_contact,comp_number,c.comp_name,cur.currency FROM tb_m_ovh_price ovhp INNER JOIN tb_m_comp_contact cc ON cc.id_comp_contact = ovhp.id_comp_contact INNER JOIN  tb_m_comp c ON cc.id_comp=c.id_comp INNER JOIN tb_lookup_currency cur ON cur.id_currency=ovhp.id_currency WHERE ovhp.id_ovh='" + id_ovh_estimate + "'"
                Dim data_vendor_ovh As DataTable = execute_query(query_vendor_ovh, -1, True, "", "", "", "")

                Dim query_curr As String = "SELECT id_currency,currency FROM tb_lookup_currency"
                Dim data_curr As DataTable = execute_query(query_curr, -1, True, "", "", "", "")

                Dim tb1 = data_temp.AsEnumerable() 'datatable xls
                Dim tb2 = data_master.AsEnumerable()
                Dim tb3 = data_vendor_ovh.AsEnumerable()
                Dim tb4 = data_curr.AsEnumerable()

                Dim query = From xls In tb1 'left join xls dgn size menjadi sizejoin
                            Group Join master In tb2
                            On xls("code") Equals master("design_code") Into masterjoin = Group
                            From resultmaster In masterjoin.DefaultIfEmpty()
                            Group Join vendor In tb3 'left join xls dgn vendor menjadi vendorjoin
                            On xls("vendor").ToString.ToLower Equals vendor("comp_number").ToString.ToLower And xls("currency").ToString.ToLower Equals vendor("currency").ToString.ToLower Into vendorjoin = Group
                            From resultvendor In vendorjoin.DefaultIfEmpty()
                            Group Join curr In tb4 'left join xls dgn range menjadi currjoin
                            On xls("currency").ToString.ToLower Equals curr("currency").ToString.ToLower Into currjoin = Group
                            From resultcurr In currjoin.DefaultIfEmpty()
                            Select New With
                            {
                                .Code = xls("code").ToString,
                                .id_design = If(resultmaster Is Nothing, "", resultmaster("id_design")),
                                .Description = If(resultmaster Is Nothing, "", resultmaster("design_name")),
                                .Size = If(resultmaster Is Nothing, "", resultmaster("size_chart")),
                                .Color = If(resultmaster Is Nothing, "", resultmaster("color")),
                                .id_ovh_price = If(resultvendor Is Nothing, "", resultvendor("id_ovh_price")),
                                .VendorCode = xls("vendor").ToString,
                                .Vendor = If(resultvendor Is Nothing, "", resultvendor("comp_name")),
                                .Currency = xls("currency").ToString,
                                .id_currency = If(resultcurr Is Nothing, "", resultcurr("id_currency")),
                                .Kurs = If(xls("kurs").ToString = "", 0, xls("kurs")),
                                .ECOP = If(xls("ecop").ToString = "", 0, xls("ecop")),
                                .err_format = If(resultmaster Is Nothing Or resultvendor Is Nothing Or resultcurr Is Nothing, If(resultmaster Is Nothing, "This design code is not registered; ", "") + If(resultvendor Is Nothing, "Please check if vendor registered in master overhead estimate; ", "") + If(resultcurr Is Nothing, "Currency not registered; ", ""), "OK")
                            }

                GCData.DataSource = Nothing
                GCData.DataSource = query.ToList()
                GCData.RefreshDataSource()
                GVData.PopulateColumns()


                'Customize column
                GVData.Columns("Code").VisibleIndex = 0
                GVData.Columns("Description").VisibleIndex = 1
                GVData.Columns("Size").VisibleIndex = 2
                GVData.Columns("Color").VisibleIndex = 3
                GVData.Columns("VendorCode").VisibleIndex = 4
                GVData.Columns("Vendor").VisibleIndex = 5
                GVData.Columns("Currency").VisibleIndex = 6
                GVData.Columns("ECOP").VisibleIndex = 7
                GVData.Columns("Kurs").VisibleIndex = 8
                GVData.Columns("err_format").VisibleIndex = 9
                '
                GVData.Columns("err_format").Caption = "Error Format"
                '
                GVData.Columns("id_design").Visible = False
                GVData.Columns("id_ovh_price").Visible = False
                GVData.Columns("id_currency").Visible = False
                '
                GVData.Columns("Kurs").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                GVData.Columns("Kurs").DisplayFormat.FormatString = "{0:n2}"
                GVData.Columns("ECOP").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                GVData.Columns("ECOP").DisplayFormat.FormatString = "{0:n2}"
                '
                GVData.BestFitColumns()

            Catch ex As Exception
                stopCustom("Incorrect format on table.")
            End Try
        ElseIf id_pop_up = "17" Then
            'import est price
            Try
                Dim query_master As String = "SELECT dsg.design_display_name AS `name`, det.color, pd_dsg.id_prod_demand_design AS `id`, dsg.design_code as `code`, pd_dsg.prod_demand_design_propose_price AS `est_price`, "
                query_master += "pd_dsg.rate_current, pd_dsg.msrp "
                query_master += "FROM tb_m_design dsg "
                query_master += "INNER JOIN tb_prod_demand_design pd_dsg ON pd_dsg.id_prod_demand_design = "
                If FormFGLineList.SLETypeLineList.EditValue.ToString = "1" Then
                    query_master += "id_prod_demand_design_line "
                ElseIf FormFGLineList.SLETypeLineList.EditValue.ToString = "2" Then
                    query_master += "id_prod_demand_design_line_upd "
                ElseIf FormFGLineList.SLETypeLineList.EditValue.ToString = "3" Then
                    query_master += "id_prod_demand_design_line_final "
                End If
                query_master += "Left Join( "
                query_master += "Select b.code_detail_name As color, a.id_design FROM tb_m_design_code a "
                query_master += "INNER Join tb_m_code_detail b ON a.id_code_detail = b.id_code_detail And b.id_code = '14' "
                query_master += "GROUP BY a.id_design "
                query_master += ") det ON det.id_design = dsg.id_design "
                query_master += "WHERE dsg.id_season = '" + FormFGLineList.SLESeason.EditValue.ToString + "' AND dsg.id_active=1 "
                query_master += "ORDER BY dsg.id_design ASC "
                Dim data_master As DataTable = execute_query(query_master, -1, True, "", "", "", "")
                Dim tb1 = data_temp.AsEnumerable() 'datatable xls
                Dim tb2 = data_master.AsEnumerable()
                Dim query = From xls In tb1
                            Group Join dox In tb2
                            On xls("id").ToString Equals dox("id").ToString Into dojoin = Group
                            From doresult In dojoin.DefaultIfEmpty()
                            Select New With {
                                        .id = If(doresult Is Nothing, "", doresult("id")),
                                        .code = If(doresult Is Nothing, "", doresult("code")),
                                        .name = If(doresult Is Nothing, "", doresult("name")),
                                        .color = If(doresult Is Nothing, "", doresult("color")),
                                        .rate_current = If(doresult Is Nothing, 0, Decimal.Parse(xls("rate_current").ToString)),
                                        .msrp = If(doresult Is Nothing, 0, Decimal.Parse(xls("msrp").ToString)),
                                        .msrp_rp = If(doresult Is Nothing, 0, Decimal.Parse(xls("msrp").ToString) * Decimal.Parse(xls("rate_current").ToString)),
                                        .est_price = If(doresult Is Nothing, 0, Decimal.Parse(xls("est_price").ToString)),
                                        .Status = If(doresult Is Nothing, "Not found", "OK")
                                    }
                GCData.DataSource = Nothing
                GCData.DataSource = query.ToList()
                GCData.RefreshDataSource()
                GVData.PopulateColumns()

                GVData.Columns("id").VisibleIndex = 0
                GVData.Columns("code").VisibleIndex = 1
                GVData.Columns("name").VisibleIndex = 2
                GVData.Columns("color").VisibleIndex = 3
                GVData.Columns("rate_current").VisibleIndex = 4
                GVData.Columns("msrp").VisibleIndex = 5
                GVData.Columns("msrp_rp").VisibleIndex = 6
                GVData.Columns("est_price").VisibleIndex = 7
                GVData.Columns("Status").VisibleIndex = 8
                GVData.BestFitColumns()

                GVData.Columns("rate_current").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                GVData.Columns("rate_current").DisplayFormat.FormatString = "{0:n2}"
                GVData.Columns("msrp").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                GVData.Columns("msrp").DisplayFormat.FormatString = "{0:n2}"
                GVData.Columns("msrp_rp").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                GVData.Columns("msrp_rp").DisplayFormat.FormatString = "{0:n2}"
                GVData.Columns("est_price").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                GVData.Columns("est_price").DisplayFormat.FormatString = "{0:n2}"
            Catch ex As Exception
                stopCustom("Incorrect format on table.")
            End Try
        ElseIf id_pop_up = "18" Then
            'SALES PROMO
            Try
                Dim dt As DataTable = FormSalesPromoDet.dt_stock_store
                Dim tb1 = data_temp.AsEnumerable()
                Dim tb2 = dt.AsEnumerable()

                Dim query = From table1 In tb1
                            Group Join table_tmp In tb2 On table1("code") Equals table_tmp("code")
                            Into Group
                            From y1 In Group.DefaultIfEmpty()
                            Select New With
                            {
                                .Code = table1.Field(Of String)("code"),
                                .Description = If(y1 Is Nothing, "", y1("name")),
                                .Size = If(y1 Is Nothing, "", y1("size")),
                                .UOM = If(y1 Is Nothing, "", y1("uom")),
                                .Amount = If(y1 Is Nothing, "", table1("qty") * y1("design_price_retail")),
                                .Qty = CType(table1("qty"), Decimal),
                                .Qty_Volcom = If(y1 Is Nothing, 0.0, y1("qty_all_product")),
                                .Price = If(y1 Is Nothing, 0.0, y1("design_price_retail")),
                                .id_design_price_retail = If(y1 Is Nothing, 0, y1("id_design_price_retail")),
                                .design_price_type = If(y1 Is Nothing, "", y1("design_price_type")),
                                .design_price = If(y1 Is Nothing, 0.0, y1("design_price")),
                                .sales_pos_det_note = If(y1 Is Nothing, "", ""),
                                .id_design = If(y1 Is Nothing, 0, y1("id_design")),
                                .id_product = If(y1 Is Nothing, 0, y1("id_product")),
                                .id_sample = If(y1 Is Nothing, 0, y1("id_sample")),
                                .id_design_price = If(y1 Is Nothing, 0, y1("id_design_price")),
                                .Type = If(y1 Is Nothing, "", y1("design_price_type")),
                                .id_sales_pos_det = If(y1 Is Nothing, "", "0"),
                                .Color = If(y1 Is Nothing, "", y1("color")),
                                .Diff = If((CType(table1("qty"), Decimal) - If(y1 Is Nothing, 0.0, y1("qty_all_product"))) <= 0, 0.0, (CType(table1("qty"), Decimal) - If(y1 Is Nothing, 0.0, y1("qty_all_product"))))
                            }

                GCData.DataSource = Nothing
                GCData.DataSource = query.ToList()
                GCData.RefreshDataSource()
                GVData.PopulateColumns()

                'Customize column
                GVData.Columns("Code").VisibleIndex = 0
                GVData.Columns("Description").VisibleIndex = 1
                GVData.Columns("Size").VisibleIndex = 2
                GVData.Columns("Qty").VisibleIndex = 3
                GVData.Columns("Qty").Caption = "Qty Store"
                GVData.Columns("Qty").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                GVData.Columns("Qty").DisplayFormat.FormatString = "{0:n2}"
                GVData.Columns("Qty_Volcom").VisibleIndex = 4
                GVData.Columns("Qty_Volcom").Caption = "Qty Limit"
                GVData.Columns("Qty_Volcom").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                GVData.Columns("Qty_Volcom").DisplayFormat.FormatString = "{0:n2}"
                GVData.Columns("Price").VisibleIndex = 5
                GVData.Columns("Price").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                GVData.Columns("Price").DisplayFormat.FormatString = "{0:n2}"
                GVData.Columns("Diff").VisibleIndex = 6
                GVData.Columns("Diff").Caption = "Over Qty"
                GVData.Columns("Diff").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                GVData.Columns("Diff").DisplayFormat.FormatString = "{0:n2}"
                GVData.Columns("UOM").Visible = False
                GVData.Columns("id_design_price_retail").Visible = False
                GVData.Columns("design_price_type").Visible = False
                GVData.Columns("design_price").Visible = False
                GVData.Columns("sales_pos_det_note").Visible = False
                GVData.Columns("id_design").Visible = False
                GVData.Columns("id_product").Visible = False
                GVData.Columns("id_sample").Visible = False
                GVData.Columns("id_design_price").Visible = False
                GVData.Columns("Type").Visible = False
                GVData.Columns("id_sales_pos_det").Visible = False
                GVData.Columns("Color").Visible = False
                GVData.Columns("Amount").Visible = False
            Catch ex As Exception
                stopCustom("Incorrect format on table.")
            End Try
        ElseIf id_pop_up = "19" Then
            ''MASTER SAMPLE PRICE
            Try
                Dim dt As DataTable = execute_query("call view_sample_master()", -1, True, "", "", "", "")
                Dim tb1 = data_temp.AsEnumerable()
                Dim tb2 = dt.AsEnumerable()
                Dim query = From table1 In tb1
                            Group Join table_tmp In tb2 On table1("code").ToString Equals table_tmp("sample_code").ToString
                            Into Group
                            From y1 In Group.DefaultIfEmpty()
                            Select New With
                            {
                                .Code = table1.Field(Of String)("code").ToString,
                                .Style = If(y1 Is Nothing, "", y1("sample_display_name")),
                                .Class = If(y1 Is Nothing, "", y1("class")),
                                .PriceName = table1.Field(Of String)("price_name").ToString,
                                .Price = table1("price"),
                                .id_sample = If(y1 Is Nothing, 0, y1("id_sample")),
                                .id_currency = "1",
                                .is_print = If(table1("is_print").ToString > "0", "1", "0"),
                                .PrintOnTag = If(table1("is_print").ToString > "0", "Yes", "No"),
                                .Status = If(y1 Is Nothing, "Not found", "OK")
                            }
                GCData.DataSource = Nothing
                GCData.DataSource = query.ToList()
                GCData.RefreshDataSource()
                GVData.PopulateColumns()

                'Customize column
                GVData.Columns("id_sample").Visible = False
                GVData.Columns("id_currency").Visible = False
                GVData.Columns("is_print").Visible = False
                GVData.Columns("Code").VisibleIndex = 0
                GVData.Columns("Style").VisibleIndex = 1
                GVData.Columns("Class").VisibleIndex = 2
                GVData.Columns("PriceName").VisibleIndex = 3
                GVData.Columns("Price").VisibleIndex = 4
                GVData.Columns("PrintOnTag").VisibleIndex = 5
                GVData.Columns("Status").VisibleIndex = 6
                GVData.Columns("Price").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                GVData.Columns("Price").DisplayFormat.FormatString = "{0:n2}"

                'check duplicate
                Dim j As Integer = 0
                For j = 0 To GVData.RowCount - 1
                    If GVData.GetRowCellValue(j, "Status") = "OK" Then
                        Dim filteredList = query.ToList.Where(Function(x) x.Code = GVData.GetRowCellValue(j, "Code")).ToList()
                        If filteredList.Count > 1 Then
                            GVData.SetRowCellValue(j, "Status", "Duplicate in import list")
                        End If
                    End If
                Next
            Catch ex As Exception
                stopCustom("Incorrect format on table.")
            End Try
        ElseIf id_pop_up = "20" Then
            Try
                Dim query_product As String = "CALL view_product_per_season(0)"
                Dim data_product As DataTable = execute_query(query_product, -1, True, "", "", "", "")

                Dim query_comp As String = "SELECT id_comp, comp_number, comp_name,id_drawer_def FROM tb_m_comp WHERE id_comp_cat='" + get_setup_field("id_comp_cat_wh") + "' "
                Dim data_comp As DataTable = execute_query(query_comp, -1, True, "", "", "", "")

                ' Dim query_exist As String = "CALL view_fg_wh_alloc('" + FormFGWHAllocDet.id_fg_wh_alloc + "') "
                ' Dim data_exist As DataTable = execute_query(query_exist, -1, True, "", "", "", "")

                Dim tb1 = data_temp.AsEnumerable() 'xls
                Dim tb2 = data_product.AsEnumerable()
                Dim tb3 = data_comp.AsEnumerable()
                ' Dim tb4 = data_exist.AsEnumerable()
                'Group Join exist In tb4
                '            On xls("code") Equals exist("code").ToString().ToUpper() And xls("wh") Equals exist("comp_number").ToString().ToUpper() Into existjoin = Group
                '            From resultexist In existjoin.DefaultIfEmpty()

                Dim query = From xls In tb1 'left join xls dgn prod menjadi prodjoin
                            Group Join prod In tb2
                            On xls("code") Equals prod("product_full_code") Into prodjoin = Group
                            From resultprod In prodjoin.DefaultIfEmpty()
                            Group Join comp In tb3 'left join xls dgn comp menjadi compjoin
                            On xls("wh").ToString.ToUpper Equals comp("comp_number").ToString.ToUpper Into compjoin = Group
                            From resultcomp In compjoin.DefaultIfEmpty()
                            Select New With
                            {
                                .Code = xls("code").ToString,
                                .id_product = If(resultprod Is Nothing, "", resultprod("id_product").ToString),
                                .Style = If(resultprod Is Nothing, "", resultprod("design_display_name").ToString),
                                .Size = If(resultprod Is Nothing, "", resultprod("Size").ToString),
                                .To = If(resultcomp Is Nothing, "", resultcomp("comp_number").ToString + " - " + resultcomp("comp_name").ToString),
                                .id_comp_to = If(resultcomp Is Nothing, "", resultcomp("id_comp").ToString),
                                .id_wh_drawer_to = If(resultcomp Is Nothing, "", resultcomp("id_drawer_def").ToString),
                                .Qty = xls("qty"),
                                .Status = If(resultprod Is Nothing Or resultcomp Is Nothing, If(resultprod Is Nothing, "This product code is not registered; ", "") + If(resultcomp Is Nothing, "Account is not registered; ", If(resultcomp("id_drawer_def").ToString = "", "Drawer not found; ", "")), "OK")
                            }

                '+ If(Not resultexist Is Nothing, "This item is already exist; ", "")
                GCData.DataSource = Nothing
                GCData.DataSource = query.ToList()
                GCData.RefreshDataSource()
                GVData.PopulateColumns()

                GVData.Columns("id_product").Visible = False
                GVData.Columns("id_comp_to").Visible = False
                GVData.Columns("id_wh_drawer_to").Visible = False
                GVData.Columns("Code").VisibleIndex = 0
                GVData.Columns("Style").VisibleIndex = 1
                GVData.Columns("Size").VisibleIndex = 2
                GVData.Columns("To").VisibleIndex = 3
                GVData.Columns("Qty").VisibleIndex = 4
                GVData.Columns("Status").VisibleIndex = 5
            Catch ex As Exception
                stopCustom("Incorrect format on table.")
            End Try
        ElseIf id_pop_up = "21" Then
            Try
                Dim query_stock As String = "CALL view_product_per_season(0)"
                Dim data_stock As DataTable = execute_query(query_stock, -1, True, "", "", "", "")

                'Dim query_store As String = "SELECT a.id_comp AS `id_store`, b.id_comp_contact AS `id_store_contact`, a.comp_number AS `store_number`, a.comp_name AS `store_name` FROM tb_m_comp a "
                'query_store += "INNER JOIN tb_m_comp_contact b ON a.id_comp = b.id_comp AND b.is_default=1 "
                'Dim data_store As DataTable = execute_query(query_store, -1, True, "", "", "", "")

                Dim query_comp As String = "SELECT a.id_comp , b.id_comp_contact , a.comp_number , a.comp_name FROM tb_m_comp a "
                query_comp += "INNER JOIN tb_m_comp_contact b ON a.id_comp = b.id_comp AND b.is_default=1 "
                Dim data_comp As DataTable = execute_query(query_comp, -1, True, "", "", "", "")

                Dim tb1 = data_temp.AsEnumerable() 'xls
                Dim tb2 = data_stock.AsEnumerable()
                Dim tb3 = data_comp.AsEnumerable()

                Dim query = From xls In tb1 'left join xls dgn prod menjadi prodjoin
                            Group Join prod In tb2
                            On xls("code") Equals prod("product_full_code") Into prodjoin = Group
                            From resultprod In prodjoin.DefaultIfEmpty()
                            Group Join store In tb3 'left join xls dgn store menjadi compjoin
                            On xls("store").ToString.ToUpper Equals store("comp_number").ToString.ToUpper Into storejoin = Group
                            From resultstore In storejoin.DefaultIfEmpty()
                            Group Join wh In tb3 'left join dgn comp-wh
                            On xls("wh").ToString.ToUpper Equals wh("comp_number").ToString.ToUpper Into whjoin = Group
                            From resultwh In whjoin.DefaultIfEmpty()
                            Select New With
                            {
                                .Code = xls("code").ToString,
                                .id_product = If(resultprod Is Nothing, "", resultprod("id_product").ToString),
                                .Style = If(resultprod Is Nothing, "", resultprod("design_display_name").ToString),
                                .Size = If(resultprod Is Nothing, "", resultprod("Size").ToString),
                                .From = If(resultwh Is Nothing, "", resultwh("comp_number").ToString + " - " + resultwh("comp_name").ToString),
                                .id_comp_from = If(resultwh Is Nothing, "", resultwh("id_comp").ToString),
                                .id_comp_contact_from = If(resultwh Is Nothing, "", resultwh("id_comp_contact").ToString),
                                .To = If(resultstore Is Nothing, "", resultstore("comp_number").ToString + " - " + resultstore("comp_name").ToString),
                                .id_comp_to = If(resultstore Is Nothing, "", resultstore("id_comp").ToString),
                                .id_comp_contact_to = If(resultstore Is Nothing, "", resultstore("id_comp_contact").ToString),
                                .Qty = xls("qty"),
                                .Status = If(resultprod Is Nothing Or resultstore Is Nothing Or resultwh Is Nothing, If(resultprod Is Nothing, "This product code is not registered; ", "") + If(resultstore Is Nothing, "Store account is not registered; ", "") + If(resultwh Is Nothing, "Warehouse account is not registered; ", ""), "OK")
                            }
                GCData.DataSource = Nothing
                GCData.DataSource = query.ToList()
                GCData.RefreshDataSource()
                GVData.PopulateColumns()

                GVData.Columns("id_product").Visible = False
                GVData.Columns("id_comp_to").Visible = False
                GVData.Columns("id_comp_from").Visible = False
                GVData.Columns("id_comp_contact_from").Visible = False
                GVData.Columns("id_comp_contact_to").Visible = False
                GVData.Columns("Code").VisibleIndex = 0
                GVData.Columns("Style").VisibleIndex = 1
                GVData.Columns("Size").VisibleIndex = 2
                GVData.Columns("From").VisibleIndex = 3
                GVData.Columns("To").VisibleIndex = 4
                GVData.Columns("Qty").VisibleIndex = 5
                GVData.Columns("Status").VisibleIndex = 6
            Catch ex As Exception
                stopCustom("Incorrect format on table.")
            End Try
        ElseIf id_pop_up = "22" Then
            ''Return sample from internal sale
            Try
                Dim dt As DataTable = execute_query("CALL view_sample_master()", -1, True, "", "", "", "")
                Dim tb1 = data_temp.AsEnumerable()
                Dim tb2 = dt.AsEnumerable()
                Dim query = From table1 In tb1
                            Group Join table_tmp In tb2 On table1("code").ToString Equals table_tmp("sample_code").ToString
                            Into Group
                            From y1 In Group.DefaultIfEmpty()
                            Select New With
                            {
                                .Code = table1.Field(Of String)("code").ToString,
                                .Description = If(y1 Is Nothing, "", y1("sample_display_name")),
                                .Size = If(y1 Is Nothing, "", y1("size")),
                                .Color = If(y1 Is Nothing, "", y1("Color")),
                                .Class = If(y1 Is Nothing, "", y1("class")),
                                .Qty = table1("qty"),
                                .id_sample = If(y1 Is Nothing, "", y1("id_sample")),
                                .code_us = If(y1 Is Nothing, "", y1("sample_us_code")),
                                .id_season = If(y1 Is Nothing, "", y1("id_season")),
                                .id_season_orign = If(y1 Is Nothing, "", y1("id_season_orign")),
                                .season = If(y1 Is Nothing, "", y1("season")),
                                .season_orign = If(y1 Is Nothing, "", y1("season_orign")),
                                .id_cost = If(y1 Is Nothing, "", y1("id_sample_price")),
                                .cost = If(y1 Is Nothing, 0, y1("sample_price")),
                                .id_price = If(y1 Is Nothing, "", y1("id_sample_ret_price")),
                                .price = If(y1 Is Nothing, 0, y1("sample_ret_price")),
                                .Status = If(y1 Is Nothing, "Code not found", "OK")
                            }
                GCData.DataSource = Nothing
                GCData.DataSource = query.ToList()
                GCData.RefreshDataSource()
                GVData.PopulateColumns()

                'Customize column
                GVData.Columns("id_sample").Visible = False
                GVData.Columns("code_us").Visible = False
                GVData.Columns("id_season").Visible = False
                GVData.Columns("id_season_orign").Visible = False
                GVData.Columns("season").Visible = False
                GVData.Columns("season_orign").Visible = False
                GVData.Columns("id_cost").Visible = False
                GVData.Columns("cost").Visible = False
                GVData.Columns("id_price").Visible = False
                GVData.Columns("price").Visible = False
                '
                GVData.Columns("Code").VisibleIndex = 0
                GVData.Columns("Description").VisibleIndex = 1
                GVData.Columns("Class").VisibleIndex = 2
                GVData.Columns("Size").VisibleIndex = 3
                GVData.Columns("Color").VisibleIndex = 4
                GVData.Columns("Qty").VisibleIndex = 5
                GVData.Columns("Status").VisibleIndex = 6

                'check duplicate
                Dim j As Integer = 0
                For j = 0 To GVData.RowCount - 1
                    If GVData.GetRowCellValue(j, "Status") = "OK" Then
                        Dim filteredList = query.ToList.Where(Function(x) x.Code = GVData.GetRowCellValue(j, "Code")).ToList()
                        If filteredList.Count > 1 Then
                            GVData.SetRowCellValue(j, "Status", "Duplicate in import list")
                        End If
                    End If
                Next
            Catch ex As Exception
                stopCustom("Incorrect format on table.")
            End Try
        ElseIf id_pop_up = "23" Then
            'SO Generate New
            Dim id_sales_order_gen As String = FormSalesOrderGen.id_sales_order_gen
            Dim connection_string As String = String.Format("Data Source={0};User Id={1};Password={2};Database={3};Convert Zero Datetime=True", app_host, app_username, app_password, app_database)
            Dim connection As New MySqlConnection(connection_string)
            connection.Open()

            Dim command As MySqlCommand = connection.CreateCommand()
            Dim qry As String = "DROP TABLE IF EXISTS tb_so_temp; CREATE TEMPORARY TABLE IF NOT EXISTS tb_so_temp AS ( SELECT * FROM ("
            Dim qry_det As String = ""
            For d As Integer = 0 To data_temp.Rows.Count - 1
                For c As Integer = 4 To 13
                    If data_temp.Rows(d)(c).ToString <> "" And data_temp.Rows(d)(c).ToString <> "-" And data_temp.Rows(d)(c).ToString <> "0" Then
                        If qry_det <> "" Then
                            qry_det += "UNION ALL "
                        End If
                        Dim size As String = 0
                        If c < 13 Then
                            size = c - 3
                        End If
                        qry_det += "SELECT '" + id_sales_order_gen + "' AS `id`, '" + data_temp.Rows(d)("VENDOR").ToString + "' AS `store`, '" + data_temp.Rows(d)("KODE").ToString + data_temp.Rows(d)("SIZETYP").ToString + size + "1" + "' AS `code`,  '" + data_temp.Rows(d)(c).ToString + "' AS `qty` "
                    End If
                Next
            Next
            qry += qry_det + ") a ); ALTER TABLE tb_so_temp CONVERT TO CHARACTER SET utf8 COLLATE utf8_general_ci; "
            command.CommandText = qry
            Command.ExecuteNonQuery()
            command.Dispose()

            Dim data As New DataTable
            Dim adapter As New MySqlDataAdapter("CALL view_sales_order_temp(" + id_sales_order_gen + ")", connection)
            adapter.SelectCommand.CommandTimeout = 300
            adapter.Fill(data)
            adapter.Dispose()
            data.Dispose()
            GCData.DataSource = data

            connection.Close()
            connection.Dispose()

            GVData.Columns("id").Visible = False
            GVData.Columns("id_product").Visible = False
            GVData.Columns("id_comp_contact_from").Visible = False
            GVData.Columns("id_comp_contact_to").Visible = False
            GVData.Columns("Class").Visible = False
            GVData.Columns("Code").VisibleIndex = 0
            GVData.Columns("Style").VisibleIndex = 1
            GVData.Columns("Size").VisibleIndex = 2
            GVData.Columns("From").VisibleIndex = 3
            GVData.Columns("To").VisibleIndex = 4
            GVData.Columns("Qty").VisibleIndex = 5
            GVData.Columns("Status").VisibleIndex = 6
        ElseIf id_pop_up = "24" Then
            'INVENTORY ALLOCATION
            Dim id_fg_wh_alloc As String = FormFGWHAllocDet.id_fg_wh_alloc
            Dim connection_string As String = String.Format("Data Source={0};User Id={1};Password={2};Database={3};Convert Zero Datetime=True", app_host, app_username, app_password, app_database)
            Dim connection As New MySqlConnection(connection_string)
            connection.Open()

            Dim command As MySqlCommand = connection.CreateCommand()
            Dim qry As String = "DROP TABLE IF EXISTS tb_fg_wh_alloc_temp; CREATE TEMPORARY TABLE IF NOT EXISTS tb_fg_wh_alloc_temp AS ( SELECT * FROM ("
            For d As Integer = 0 To data_temp.Rows.Count - 1
                If d > 0 Then
                    qry += "UNION ALL "
                End If
                qry += "SELECT '" + id_fg_wh_alloc + "' AS `id`, '" + data_temp.Rows(d)("VENDOR").ToString + "' AS `store`, '" + data_temp.Rows(d)("KODE").ToString + "' AS `code`, '" + data_temp.Rows(d)("SIZETYP").ToString + "' AS `sizetype`,  '" + data_temp.Rows(d)("xxs/1").ToString + "' AS `1`, '" + data_temp.Rows(d)("xs/2").ToString + "' AS `2`, '" + data_temp.Rows(d)("s/3").ToString + "' AS `3`, '" + data_temp.Rows(d)("m/4").ToString + "' AS `4`, '" + data_temp.Rows(d)("ml/5").ToString + "' AS `5`, '" + data_temp.Rows(d)("l/6").ToString + "' AS `6`, '" + data_temp.Rows(d)("xl/7").ToString + "' AS `7`, '" + data_temp.Rows(d)("xxl/8").ToString + "' AS `8`, '" + data_temp.Rows(d)("all/9").ToString + "' AS `9`, '" + data_temp.Rows(d)("~/0").ToString + "' AS `0` "
            Next
            qry += ") a ); ALTER TABLE tb_fg_wh_alloc_temp CONVERT TO CHARACTER SET utf8 COLLATE utf8_general_ci; "
            command.CommandText = qry
            command.ExecuteNonQuery()
            command.Dispose()
            'Console.WriteLine(qry)

            Dim data As New DataTable
            Dim adapter As New MySqlDataAdapter("CALL view_fg_wh_alloc_temp(" + id_fg_wh_alloc + ")", connection)
            adapter.SelectCommand.CommandTimeout = 300
            adapter.Fill(data)
            adapter.Dispose()
            data.Dispose()
            GCData.DataSource = data

            connection.Close()
            connection.Dispose()

            GVData.Columns("id").Visible = False
            GVData.Columns("id_product").Visible = False
            GVData.Columns("id_comp_contact_to").Visible = False
            GVData.Columns("id_wh_drawer_to").Visible = False
            GVData.Columns("Class").Visible = False
            GVData.Columns("Code").VisibleIndex = 0
            GVData.Columns("Style").VisibleIndex = 1
            GVData.Columns("Size").VisibleIndex = 2
            GVData.Columns("To").VisibleIndex = 3
            GVData.Columns("Qty").VisibleIndex = 4
            GVData.Columns("Status").VisibleIndex = 5
        ElseIf id_pop_up = "25" Then
            'sales order 9
            Dim connection_string As String = String.Format("Data Source={0};User Id={1};Password={2};Database={3};Convert Zero Datetime=True", app_host, app_username, app_password, app_database)
            Dim connection As New MySqlConnection(connection_string)
            connection.Open()

            Dim command As MySqlCommand = connection.CreateCommand()
            Dim qry As String = "DROP TABLE IF EXISTS tb_so_single_temp; CREATE TEMPORARY TABLE IF NOT EXISTS tb_so_single_temp AS ( SELECT * FROM ("
            Dim qry_det As String = ""
            For d As Integer = 0 To data_temp.Rows.Count - 1
                For c As Integer = 3 To 12
                    If data_temp.Rows(d)(c).ToString <> "" And data_temp.Rows(d)(c).ToString <> "-" And data_temp.Rows(d)(c).ToString <> "0" Then
                        If qry_det <> "" Then
                            qry_det += "UNION ALL "
                        End If
                        Dim size As String = 0
                        If c < 12 Then
                            size = c - 2
                        End If
                        qry_det += "SELECT '" + FormSalesOrderDet.id_comp_par + "' AS `id_wh`,'" + id_user + "' AS `id_user`, '" + data_temp.Rows(d)("KODE").ToString + data_temp.Rows(d)("SIZETYP").ToString + size + "1" + "' AS `code`, '" + data_temp.Rows(d)(c).ToString + "' AS `qty` "
                    End If
                Next
            Next
            qry += qry_det + ") a ); ALTER TABLE tb_so_single_temp CONVERT TO CHARACTER SET utf8 COLLATE utf8_general_ci; "

            'For d As Integer = 0 To data_temp.Rows.Count - 1
            '    If d > 0 Then
            '        qry += "UNION ALL "
            '    End If
            '    qry += "SELECT '" + FormSalesOrderDet.id_comp_par + "' AS `id_wh`,'" + id_user + "' AS `id_user`, '" + data_temp.Rows(d)("KODE").ToString + "' AS `code`, '" + data_temp.Rows(d)("SIZETYP").ToString + "' AS `sizetype`,  '" + data_temp.Rows(d)("xxs/1").ToString + "' AS `1`, '" + data_temp.Rows(d)("xs/2").ToString + "' AS `2`, '" + data_temp.Rows(d)("s/3").ToString + "' AS `3`, '" + data_temp.Rows(d)("m/4").ToString + "' AS `4`, '" + data_temp.Rows(d)("ml/5").ToString + "' AS `5`, '" + data_temp.Rows(d)("l/6").ToString + "' AS `6`, '" + data_temp.Rows(d)("xl/7").ToString + "' AS `7`, '" + data_temp.Rows(d)("xxl/8").ToString + "' AS `8`, '" + data_temp.Rows(d)("all/9").ToString + "' AS `9`, '" + data_temp.Rows(d)("~/0").ToString + "' AS `0` "
            'Next
            'qry += ") a ); ALTER TABLE tb_so_single_temp CONVERT TO CHARACTER SET utf8 COLLATE utf8_general_ci; "
            command.CommandText = qry
            command.ExecuteNonQuery()
            command.Dispose()
            'Console.WriteLine(qry)

            Dim data As New DataTable
            Dim adapter As New MySqlDataAdapter("CALL view_sales_order_single_temp(" + FormSalesOrderDet.id_comp_par + ", '" + id_user + "')", connection)
            adapter.SelectCommand.CommandTimeout = 300
            adapter.Fill(data)
            adapter.Dispose()
            data.Dispose()
            Dim data_par As DataTable = FormSalesOrderDet.GCItemList.DataSource
            If data_par.Rows.Count = 0 Then
                GCData.DataSource = data
            Else
                Dim t1 = data.AsEnumerable()
                Dim t2 = data_par.AsEnumerable()
                Dim except As DataTable = (From _t1 In t1
                                           Group Join _t2 In t2
                                           On _t1("id_product") Equals _t2("id_product") Into Group
                                           From _t3 In Group.DefaultIfEmpty()
                                           Where _t3 Is Nothing
                                           Select _t1).CopyToDataTable
                GCData.DataSource = except
            End If
            connection.Close()
            connection.Dispose()

            'Customize column
            GVData.Columns("id_design_price").Visible = False
            GVData.Columns("design_price_type").Visible = False
            GVData.Columns("id_product").Visible = False
            GVData.Columns("id_design").Visible = False
            GVData.Columns("id_wh").Visible = False
            GVData.Columns("id_user").Visible = False
            GVData.Columns("Class").Visible = False
            GVData.Columns("Code").VisibleIndex = 0
            GVData.Columns("Style").VisibleIndex = 1
            GVData.Columns("Size").VisibleIndex = 2
            GVData.Columns("Price").VisibleIndex = 3
            GVData.Columns("Available").VisibleIndex = 4
            GVData.Columns("Qty").VisibleIndex = 5
            GVData.Columns("Status").VisibleIndex = 6
            GVData.Columns("Available").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            GVData.Columns("Available").DisplayFormat.FormatString = "{0:n0}"
            GVData.Columns("Qty").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            GVData.Columns("Qty").DisplayFormat.FormatString = "{0:n0}"
        ElseIf id_pop_up = "26" Then
            'FAKTUR KELUARAN
            Try
                GCData.DataSource = Nothing
                GCData.DataSource = data_temp
                GCData.RefreshDataSource()
                GVData.PopulateColumns()
            Catch ex As Exception
                stopCustom("Incorrect format on table.")
            End Try
        ElseIf id_pop_up = "27" Then
            'holiday list
            Dim queryx As String = "SELECT id_religion,religion FROM tb_lookup_religion"
            Dim dt As DataTable = execute_query(queryx, -1, True, "", "", "", "")
            Dim tb1 = data_temp.AsEnumerable()
            Dim tb2 = dt.AsEnumerable()

            Dim query = From table1 In tb1
                        Group Join table_tmp In tb2 On table1("religion") Equals table_tmp("religion")
                            Into Group
                        From y1 In Group.DefaultIfEmpty()
                        Select New With
                            {
                                .Date = table1("date"),
                                .IdReligion = If(y1 Is Nothing, "0", y1("id_religion")),
                                .Religion = table1("religion"),
                                .Description = table1("nama_libur")
                            }

            GCData.DataSource = Nothing
            GCData.DataSource = query.ToList()
            GCData.RefreshDataSource()
            GVData.PopulateColumns()

            'Customize column
            GVData.Columns("IdReligion").Visible = False
            GVData.Columns("Date").DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
            GVData.Columns("Date").DisplayFormat.FormatString = "{0:dd MMM yyyy}"
        ElseIf id_pop_up = "28" Then
            'vendor code 
            Dim queryx As String = "SELECT id_product,product_full_code,product_name FROM tb_m_product"
            Dim dt As DataTable = execute_query(queryx, -1, True, "", "", "", "")
            Dim tb1 = data_temp.AsEnumerable()
            Dim tb2 = dt.AsEnumerable()

            Dim query = From table1 In tb1
                        Group Join table_tmp In tb2 On table1("pr_code").ToString Equals table_tmp("product_full_code").ToString
                            Into Group
                        From y1 In Group.DefaultIfEmpty()
                        Select New With
                            {
                                .IdProduct = If(y1 Is Nothing, "0", y1("id_product")),
                                .Code = If(y1 Is Nothing, "0", y1("product_full_code")),
                                .Description = If(y1 Is Nothing, "0", y1("product_name")),
                                .Color = table1("pr_colnm"),
                                .UPC = table1("pr_upc")
                            }

            GCData.DataSource = Nothing
            GCData.DataSource = query.ToList()
            GCData.RefreshDataSource()
            GVData.PopulateColumns()

            'Customize column
            GVData.Columns("IdProduct").Visible = False
        ElseIf id_pop_up = "29" Then
            'return order 9
            Dim connection_string As String = String.Format("Data Source={0};User Id={1};Password={2};Database={3};Convert Zero Datetime=True", app_host, app_username, app_password, app_database)
            Dim connection As New MySqlConnection(connection_string)
            connection.Open()

            Dim command As MySqlCommand = connection.CreateCommand()
            Dim qry As String = "DROP TABLE IF EXISTS tb_ro_single_temp; CREATE TEMPORARY TABLE IF NOT EXISTS tb_ro_single_temp AS ( SELECT * FROM ("
            Dim qry_det As String = ""
            For d As Integer = 0 To data_temp.Rows.Count - 1
                For c As Integer = 3 To 12
                    If data_temp.Rows(d)(c).ToString <> "" And data_temp.Rows(d)(c).ToString <> "-" And data_temp.Rows(d)(c).ToString <> "0" Then
                        If qry_det <> "" Then
                            qry_det += "UNION ALL "
                        End If
                        Dim size As String = 0
                        If c < 12 Then
                            size = c - 2
                        End If
                        qry_det += "SELECT '" + FormSalesReturnOrderDet.id_comp + "' AS `id_wh`,'" + id_user + "' AS `id_user`, '" + data_temp.Rows(d)("KODE").ToString + data_temp.Rows(d)("SIZETYP").ToString + size + "1" + "' AS `code`, '" + data_temp.Rows(d)(c).ToString + "' AS `qty` "
                    End If
                Next
            Next
            qry += qry_det + ") a ); ALTER TABLE tb_ro_single_temp CONVERT TO CHARACTER SET utf8 COLLATE utf8_general_ci; "
            command.CommandText = qry
            command.ExecuteNonQuery()
            command.Dispose()
            'Console.WriteLine(qry)

            Dim data As New DataTable
            Dim adapter As New MySqlDataAdapter("CALL view_return_order_single_temp(" + FormSalesReturnOrderDet.id_comp + ", '" + id_user + "')", connection)
            adapter.SelectCommand.CommandTimeout = 300
            adapter.Fill(data)
            adapter.Dispose()
            data.Dispose()
            Dim data_par As DataTable = FormSalesReturnOrderDet.GCItemList.DataSource
            If data_par.Rows.Count = 0 Then
                GCData.DataSource = data
            Else
                Dim t1 = data.AsEnumerable()
                Dim t2 = data_par.AsEnumerable()
                Dim except As DataTable = (From _t1 In t1
                                           Group Join _t2 In t2
                                           On _t1("id_product") Equals _t2("id_product") Into Group
                                           From _t3 In Group.DefaultIfEmpty()
                                           Where _t3 Is Nothing
                                           Select _t1).CopyToDataTable
                GCData.DataSource = except
            End If
            connection.Close()
            connection.Dispose()

            'Customize column
            GVData.Columns("id_design_price_retail").Visible = False
            GVData.Columns("id_design").Visible = False
            GVData.Columns("id_product").Visible = False
            GVData.Columns("Amount").Visible = False
            GVData.Columns("Price").Visible = False
            GVData.Columns("SOH").Visible = False
            GVData.Columns("Code").VisibleIndex = 0
            GVData.Columns("Style").VisibleIndex = 1
            GVData.Columns("Size").VisibleIndex = 2
            GVData.Columns("Qty").VisibleIndex = 3
            GVData.Columns("Status").VisibleIndex = 4
            GVData.Columns("Qty").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            GVData.Columns("Qty").DisplayFormat.FormatString = "{0:n0}"
            GVData.Columns("SOH").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            GVData.Columns("SOH").DisplayFormat.FormatString = "{0:n0}"
        ElseIf id_pop_up = "30" Then 'import duty
            Try
                Dim queryx As String = "SELECT po.`prod_order_number`,po.`id_prod_order`,dsg.`design_code_import`,dsg.`design_display_name`,dsg.`design_code`,comp.`comp_name`,comp.`comp_number`
                                    FROM tb_prod_order po
                                    INNER JOIN
                                    (
	                                    SELECT wo.*,ovhp.`id_comp_contact` FROM tb_prod_order_wo wo 
	                                    INNER JOIN tb_m_ovh_price ovhp ON ovhp.`id_ovh_price`=wo.`id_ovh_price`
	                                    WHERE wo.`is_main_vendor`='1'
                                    ) wo ON wo.id_prod_order=po.`id_prod_order`
                                    INNER JOIN `tb_m_comp_contact` cc ON cc.`id_comp_contact`=wo.`id_comp_contact`
                                    INNER JOIN tb_m_comp comp ON comp.`id_comp`=cc.`id_comp`
                                    INNER JOIN tb_prod_demand_design pdd ON pdd.`id_prod_demand_design`=po.`id_prod_demand_design`
                                    INNER JOIN tb_m_design dsg ON dsg.`id_design`=pdd.`id_design`
                                    WHERE po.`id_report_status`!='5' AND po.`id_po_type`='2'"
                Dim dt As DataTable = execute_query(queryx, -1, True, "", "", "", "")

                Dim query_curr As String = "SELECT id_currency,currency FROM tb_lookup_currency"
                Dim data_curr As DataTable = execute_query(query_curr, -1, True, "", "", "", "")

                Dim tb1 = data_temp.AsEnumerable()
                Dim tb2 = dt.AsEnumerable()
                Dim tb3 = data_curr.AsEnumerable()

                Dim query = From table1 In tb1
                            Group Join table_tmp In tb2
                            On table1("kode").ToString.ToLower Equals table_tmp("design_code").ToString.ToLower Into prod = Group
                            From result_prod In prod.DefaultIfEmpty()
                            Group Join curr In tb3
                            On table1("currency").ToString.ToLower Equals curr("id_currency").ToString.ToLower Into currjoin = Group
                            From resultcurr In currjoin.DefaultIfEmpty()
                            Select New With
                            {
                                .IdPO = If(result_prod Is Nothing, "0", result_prod("id_prod_order")),
                                .CodeImport = If(result_prod Is Nothing, "0", result_prod("design_code_import")),
                                .Code = If(result_prod Is Nothing, "0", result_prod("design_code")),
                                .Description = If(result_prod Is Nothing, "0", result_prod("design_display_name")),
                                .POOldSistem = table1("po_sistem_lama"),
                                .hs_code = table1("hs_kode"),
                                .AjuNumber = table1("aju_number"),
                                .PibNumber = table1("pib_number"),
                                .PibDate = table1("pib_date"),
                                .Duty = table1("duty"),
                                .Royalty = table1("royalty"),
                                .StoreDiscount = table1("store_discount"),
                                .SalesThru = table1("sales_through"),
                                .SalesVat = table1("ppn"),
                                .SalesPPH = table1("pph"),
                                .isPR = table1("payment_request"),
                                .isPay = table1("payment"),
                                .id_isPR = If(table1("payment_request").ToString.ToUpper = "YES", "1", "2"),
                                .id_isPay = If(table1("payment").ToString.ToUpper = "YES", "1", "2"),
                                .Source = table1("negara_asal"),
                                .DestPort = table1("pelabuhan_tujuan"),
                                .ppjk = table1("ppjk"),
                                .ppjk_inv = table1("ppjk_inv"),
                                .volume = table1("volume"),
                                .uom = table1("uom"),
                                .ls_no = table1("ls_no"),
                                .ls_date = table1("ls_date"),
                                .coo = table1("coo"),
                                .currency = If(resultcurr Is Nothing, "2", resultcurr("currency")),
                                .id_currency = table1("currency"),
                                .kurs = table1("kurs"),
                                .cif = table1("cif"),
                                .freight_usd = table1("freight_usd"),
                                .penalty_percent = table1("penalty_percent"),
                                .sales_actual_qty = table1("sales_actual_qty")
                            }

                GCData.DataSource = Nothing
                GCData.DataSource = query.ToList()
                GCData.RefreshDataSource()
                GVData.PopulateColumns()

                'Customize column
                GVData.Columns("IdPO").Visible = False
                GVData.Columns("hs_code").Caption = "HS Code"
                GVData.Columns("CodeImport").Caption = "Code Import"
                GVData.Columns("POOldSistem").Caption = "PO Reff #"
                GVData.Columns("AjuNumber").Caption = "Aju Number"
                GVData.Columns("PibNumber").Caption = "PIB Number"
                GVData.Columns("PibDate").Caption = "PIB Date"
                GVData.Columns("PibDate").DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
                GVData.Columns("PibDate").DisplayFormat.FormatString = "dd MMM yyyy"
                GVData.Columns("Duty").Caption = "Duty %"
                GVData.Columns("Royalty").Caption = "Royalty %"
                GVData.Columns("SalesVat").Caption = "PPN %"
                GVData.Columns("SalesPPH").Caption = "PPH %"
                GVData.Columns("StoreDiscount").Caption = "Store Discount %"
                GVData.Columns("SalesThru").Caption = "Sales Through %"
                GVData.Columns("isPR").Caption = "Payment Requested"
                GVData.Columns("isPay").Caption = "Payment"
                GVData.Columns("id_isPR").Visible = False
                GVData.Columns("id_isPay").Visible = False
                GVData.Columns("Source").Caption = "Source Country"
                GVData.Columns("DestPort").Caption = "Destination Port"
                GVData.Columns("ppjk").Caption = "PPJK"
                GVData.Columns("ppjk_inv").Caption = "PPJK Invoice Number"
                GVData.Columns("volume").Caption = "Volume"
                GVData.Columns("uom").Caption = "UOM"
                GVData.Columns("ls_no").Caption = "L/S Number"
                GVData.Columns("ls_date").Caption = "L/S Date"
                GVData.Columns("ls_date").DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
                GVData.Columns("ls_date").DisplayFormat.FormatString = "dd MMM yyyy"
                GVData.Columns("coo").Caption = "COO"
                GVData.Columns("currency").Caption = "Currency"
                GVData.Columns("id_currency").Visible = False
                GVData.Columns("kurs").Caption = "Kurs"
                GVData.Columns("cif").Caption = "CIF"
                GVData.Columns("freight_usd").Caption = "Freight (USD)"
                GVData.Columns("penalty_percent").Caption = "Penalty %"
                GVData.Columns("sales_actual_qty").Caption = "Sales Actual Qty"
                GVData.Columns("Duty").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                GVData.Columns("Duty").DisplayFormat.FormatString = "{0:n4}"
                GVData.Columns("Royalty").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                GVData.Columns("Royalty").DisplayFormat.FormatString = "{0:n4}"
                GVData.Columns("StoreDiscount").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                GVData.Columns("StoreDiscount").DisplayFormat.FormatString = "{0:n4}"
                GVData.Columns("SalesThru").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                GVData.Columns("SalesThru").DisplayFormat.FormatString = "{0:n4}"
                GVData.Columns("SalesVat").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                GVData.Columns("SalesVat").DisplayFormat.FormatString = "{0:n4}"
                GVData.Columns("SalesPPH").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                GVData.Columns("SalesPPH").DisplayFormat.FormatString = "{0:n4}"
                GVData.Columns("volume").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                GVData.Columns("volume").DisplayFormat.FormatString = "{0:n4}"
                GVData.Columns("kurs").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                GVData.Columns("kurs").DisplayFormat.FormatString = "{0:n4}"
                GVData.Columns("cif").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                GVData.Columns("cif").DisplayFormat.FormatString = "{0:n4}"
                GVData.Columns("freight_usd").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                GVData.Columns("freight_usd").DisplayFormat.FormatString = "{0:n4}"
                GVData.Columns("penalty_percent").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                GVData.Columns("penalty_percent").DisplayFormat.FormatString = "{0:n4}"
                GVData.Columns("sales_actual_qty").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                GVData.Columns("sales_actual_qty").DisplayFormat.FormatString = "{0:n0}"

                GVData.OptionsView.ColumnAutoWidth = False
                GVData.BestFitColumns()

            Catch ex As Exception
                stopCustom(ex.ToString)
            End Try
        ElseIf id_pop_up = "31" Then
            Dim id_emp_uni_period As String = FormEmpUniPeriodDet.id_emp_uni_period

            'master emp
            Dim queryx As String = "SELECT e.id_employee, IFNULL(so.id_sales_order,0) AS `id_sales_order`, e.employee_code, e.employee_name, e.employee_position, dept.departement 
            FROM tb_m_employee e 
            LEFT JOIN tb_emp_uni_budget b ON b.id_employee = e.id_employee AND b.id_emp_uni_period=" + id_emp_uni_period + "
            LEFT JOIN(
	            SELECT so.id_sales_order,so.id_emp_uni_budget  
	            FROM tb_sales_order so
	            WHERE !ISNULL(so.id_emp_uni_budget) AND so.id_emp_uni_period = " + id_emp_uni_period + "
	            GROUP BY so.id_emp_uni_budget
            ) so ON so.id_emp_uni_budget = b.id_emp_uni_budget
            INNER JOIN tb_m_departement dept ON dept.id_departement = e.id_departement
            WHERE e.id_employee_active=1 "
            Dim dt As DataTable = execute_query(queryx, -1, True, "", "", "", "")
            Dim tb1 = data_temp.AsEnumerable()
            Dim tb2 = dt.AsEnumerable()

            Dim query = From table1 In tb1
                        Group Join table_tmp In tb2 On table1("nik").ToString Equals table_tmp("employee_code").ToString
                            Into Group
                        From y1 In Group.DefaultIfEmpty()
                        Select New With
                            {
                                .IdEmp = If(y1 Is Nothing, "0", y1("id_employee").ToString),
                                .IdSO = If(y1 Is Nothing, "0", y1("id_sales_order").ToString),
                                .NIK = table1("nik"),
                                .Name = If(y1 Is Nothing, "-", y1("employee_name").ToString),
                                .Dept = If(y1 Is Nothing, "-", y1("departement").ToString),
                                .Position = If(y1 Is Nothing, "-", y1("employee_position").ToString),
                                .Budget = table1("budget"),
                                .Status = If(y1 Is Nothing, "Not Found", If(y1("id_sales_order").ToString = 0, "OK", "Order already processed"))
                            }
            GCData.DataSource = Nothing
            GCData.DataSource = query.ToList()
            GCData.RefreshDataSource()
            GVData.PopulateColumns()

            'Customize column
            GVData.Columns("IdEmp").Visible = False
            GVData.Columns("IdSO").Visible = False
            GVData.Columns("Budget").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            GVData.Columns("Budget").DisplayFormat.FormatString = "{0:n2}"
        End If
        data_temp.Dispose()
        oledbconn.Close()
        oledbconn.Dispose()
    End Sub
    Private Sub BBrowse_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BBrowse.Click
        Me.Cursor = Cursors.WaitCursor
        Dim fdlg As OpenFileDialog = New OpenFileDialog()
        fdlg.Title = "Select excel file To import"
        fdlg.InitialDirectory = "C: \"
        fdlg.Filter = "Excel File|*.xls; *.xlsx"
        fdlg.FilterIndex = 0
        fdlg.RestoreDirectory = True
        Cursor = Cursors.Default
        If fdlg.ShowDialog() = DialogResult.OK Then
            TBFileAddress.Text = ""
            TBFileAddress.Text = fdlg.FileName
        End If
        fdlg.Dispose()
    End Sub

    Private Sub GVData_RowCellStyle(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs) Handles GVData.RowCellStyle
        If id_pop_up = "1" Then
            Dim id_sample_price As String = sender.GetRowCellDisplayText(e.RowHandle, sender.Columns("id_sample_price"))
            'condition
            If Not id_sample_price = "" Then
                If id_sample_price = "0" Then
                    e.Appearance.BackColor = Color.Salmon
                    e.Appearance.BackColor2 = Color.Salmon
                End If
            End If
        ElseIf id_pop_up = "2" Then
            Dim id_sample As String = sender.GetRowCellDisplayText(e.RowHandle, sender.Columns("id_sample"))
            'condition
            If Not id_sample = "" Then
                If id_sample = "0" Then
                    e.Appearance.BackColor = Color.Salmon
                    e.Appearance.BackColor2 = Color.Salmon
                End If
            End If
        ElseIf id_pop_up = "6" Or id_pop_up = "7" Then
            Dim diff As Decimal = sender.GetRowCellValue(e.RowHandle, sender.Columns("Diff"))
            If diff > 0.0 Then
                e.Appearance.BackColor = Color.Salmon
                e.Appearance.BackColor2 = Color.WhiteSmoke
            End If
        ElseIf id_pop_up = "11" Or id_pop_up = "13" Or id_pop_up = "14" Or id_pop_up = "15" Or id_pop_up = "17" Or id_pop_up = "19" Or id_pop_up = "20" Or id_pop_up = "21" Or id_pop_up = "25" Or id_pop_up = "31" Then
            Dim stt As String = sender.GetRowCellValue(e.RowHandle, sender.Columns("Status")).ToString
            If stt <> "OK" Then
                e.Appearance.BackColor = Color.Salmon
                e.Appearance.BackColor2 = Color.Salmon
            End If
        ElseIf id_pop_up = "12" Then
            'condition
            If GVData.RowCount > 0 Then
                If Not sender.GetRowCellDisplayText(e.RowHandle, sender.Columns("err_format")) = "" Then
                    e.Appearance.BackColor = Color.Salmon
                    e.Appearance.BackColor2 = Color.Salmon
                End If
            End If
        End If
    End Sub

    Private Sub BCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BCancel.Click
        Close()
    End Sub

    Private Sub FormImportExcel_FormClosed(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub BImport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BImport.Click
        Cursor = Cursors.WaitCursor
        Try

        Catch ex As Exception
            stopCustom("Import failed. Please make sure : " & vbNewLine & "- Row data not empty" & vbNewLine & "- Value in correct format")
        End Try
        If Not GVData.RowCount > 0 Then
            infoCustom("No data imported.")
            Close()
        Else
            If id_pop_up = "1" Then
                For i As Integer = 0 To (GVData.RowCount - 1)
                    If Not GVData.GetRowCellValue(i, "id_sample_price").ToString() = "0" Then
                        Dim newRow As DataRow = (TryCast(FormSamplePurchaseDet.GCListPurchase.DataSource, DataTable)).NewRow()
                        newRow("id_sample_price") = GVData.GetRowCellValue(i, "id_sample_price").ToString()
                        newRow("code") = GVData.GetRowCellValue(i, "code").ToString()
                        newRow("name") = GVData.GetRowCellValue(i, "name").ToString()
                        newRow("price") = GVData.GetRowCellValue(i, "price").ToString()
                        newRow("discount") = GVData.GetRowCellValue(i, "discount").ToString()
                        newRow("qty") = GVData.GetRowCellValue(i, "qty").ToString()
                        newRow("total") = GVData.GetRowCellValue(i, "total").ToString()

                        TryCast(FormSamplePurchaseDet.GCListPurchase.DataSource, DataTable).Rows.Add(newRow)
                        FormSamplePurchaseDet.GCListPurchase.RefreshDataSource()
                    End If
                Next
                Close()
            ElseIf id_pop_up = "2" Then
                Dim check_match As Boolean = False
                Dim match_index As Integer = 0
                For i As Integer = 0 To (GVData.RowCount - 1)
                    If Not GVData.GetRowCellValue(i, "id_sample").ToString() = "0" Then
                        'check first
                        check_match = False
                        match_index = 0
                        For j As Integer = 0 To FormSamplePlanDet.GVListPurchase.RowCount - 1
                            If Not FormSamplePlanDet.GVListPurchase.GetRowCellValue(j, "id_sample").ToString = "" Then
                                If FormSamplePlanDet.GVListPurchase.GetRowCellValue(j, "id_sample").ToString = GVData.GetRowCellValue(i, "id_sample").ToString() Then
                                    'some match
                                    check_match = True
                                    match_index = j
                                    Exit For
                                End If
                            End If
                        Next
                        '
                        If check_match = False Then
                            Dim newRow As DataRow = (TryCast(FormSamplePlanDet.GCListPurchase.DataSource, DataTable)).NewRow()
                            newRow("id_sample") = GVData.GetRowCellValue(i, "id_sample").ToString()
                            newRow("code") = GVData.GetRowCellValue(i, "code").ToString()
                            newRow("name") = GVData.GetRowCellValue(i, "name").ToString()
                            newRow("size") = GVData.GetRowCellValue(i, "size").ToString()
                            newRow("qty") = GVData.GetRowCellValue(i, "qty").ToString()
                            newRow("sample_plan_det_note") = GVData.GetRowCellValue(i, "note").ToString()

                            TryCast(FormSamplePlanDet.GCListPurchase.DataSource, DataTable).Rows.Add(newRow)
                            FormSamplePlanDet.GCListPurchase.RefreshDataSource()
                        Else
                            FormSamplePlanDet.GVListPurchase.SetRowCellValue(match_index, "qty", (Decimal.Parse(FormSamplePlanDet.GVListPurchase.GetRowCellValue(match_index, "qty").ToString) + Decimal.Parse(GVData.GetRowCellValue(i, "qty").ToString())))
                        End If
                        '
                    End If
                Next
                FormSamplePlanDet.check_gv_but()
                Close()
            ElseIf id_pop_up = "3" Then 'import SOH on hand
                If GVData.RowCount > 0 Then
                    PBC.Properties.Minimum = 0
                    PBC.Properties.Maximum = GVData.RowCount - 1
                    PBC.Properties.Step = 1
                    PBC.Properties.PercentView = True

                    Dim bulk_query As String = ""
                    Dim id_soh As String = FormSOHDet.id_soh

                    Dim del_query As String = "DELETE FROM tb_soh_on_hand WHERE id_soh='" + id_soh + "'"
                    execute_non_query(del_query, True, "", "", "", "")

                    bulk_query = "INSERT INTO tb_soh_on_hand(id_soh,prod_code,style_code,prod_source,prod_size,qty) VALUES"
                    For i As Integer = 0 To (GVData.RowCount - 1)
                        Dim _prod_code As String = GVData.GetRowCellValue(i, "code1")
                        Dim _style_code As String = GVData.GetRowCellValue(i, "code")
                        Dim _source As String = GVData.GetRowCellValue(i, "source")
                        Dim _size As String = GVData.GetRowCellValue(i, "size")
                        Dim _qty As String = GVData.GetRowCellValue(i, "qtyt")

                        bulk_query += "('" + id_soh + "','" + _prod_code + "','" + _style_code + "','" + _source + "','" + _size + "','" + decimalSQL(_qty.ToString) + "')"
                        If Not i = GVData.RowCount - 1 Then
                            bulk_query += ","
                        End If
                        PBC.PerformStep()
                        PBC.Update()
                    Next

                    execute_non_query(bulk_query, True, "", "", "", "")
                    FormSOHDet.load_self()
                    Close()
                Else
                    stopCustom("No data available.")
                End If
            ElseIf id_pop_up = "4" Then 'import SOH Store
                If GVData.RowCount > 0 Then
                    PBC.Properties.Minimum = 0
                    PBC.Properties.Maximum = GVData.RowCount - 1
                    PBC.Properties.Step = 1
                    PBC.Properties.PercentView = True

                    Dim bulk_query As String = ""
                    Dim id_soh As String = FormSOHDet.id_soh

                    Dim del_query As String = "DELETE FROM tb_soh_store WHERE id_soh='" + id_soh + "'"
                    execute_non_query(del_query, True, "", "", "", "")

                    bulk_query = "INSERT INTO tb_soh_store(id_soh,prod_code,style_code,prod_desc,soh_store_qty) VALUES"
                    For i As Integer = 0 To (GVData.RowCount - 1)
                        Dim _style_code As String = GVData.GetRowCellValue(i, "style_code")
                        Dim _prod_code As String = GVData.GetRowCellValue(i, "barcode")
                        Dim _desc As String = GVData.GetRowCellValue(i, "desc")
                        Dim _qty As String = GVData.GetRowCellValue(i, "stock")

                        bulk_query += "('" + id_soh + "','" + _prod_code + "','" + _style_code + "','" + addSlashes(_desc) + "','" + decimalSQL(_qty.ToString) + "')"
                        If Not i = GVData.RowCount - 1 Then
                            bulk_query += ","
                        End If
                        PBC.PerformStep()
                        PBC.Update()
                    Next

                    execute_non_query(bulk_query, True, "", "", "", "")
                    FormSOHDet.load_store()
                    Close()
                Else
                    stopCustom("No data available.")
                End If
            ElseIf id_pop_up = "5" Then 'SOH Price
                If GVData.RowCount > 0 Then
                    PBC.Properties.Minimum = 0
                    PBC.Properties.Maximum = GVData.RowCount - 1
                    PBC.Properties.Step = 1
                    PBC.Properties.PercentView = True

                    Dim bulk_query As String = ""
                    Dim id_soh_periode As String = FormSOHPriceDet.id_soh_periode

                    Dim del_query As String = "DELETE FROM tb_soh_price WHERE id_soh_periode='" + id_soh_periode + "'"
                    execute_non_query(del_query, True, "", "", "", "")

                    bulk_query = "INSERT INTO tb_soh_price(id_soh_periode,style_code,prod_class,prod_desc,prod_price,prod_cost) VALUES"
                    For i As Integer = 0 To (GVData.RowCount - 1)
                        Dim _style_code As String = GVData.GetRowCellValue(i, "code").ToString
                        Dim _prod_class As String = GVData.GetRowCellValue(i, "class").ToString
                        Dim _desc As String = GVData.GetRowCellValue(i, "desc").ToString
                        Dim _price As String = GVData.GetRowCellValue(i, "price").ToString
                        Dim _cost As String = GVData.GetRowCellValue(i, "cost").ToString
                        'MsgBox(decimalSQL(_cost.ToString))
                        bulk_query += "('" + id_soh_periode + "','" + _style_code + "','" + _prod_class + "','" + addSlashes(_desc) + "','" + decimalSQL(_price.ToString) + "','" + decimalSQL(_cost.ToString) + "')"
                        If Not i = GVData.RowCount - 1 Then
                            bulk_query += ","
                        End If
                        PBC.PerformStep()
                        PBC.Update()
                    Next

                    execute_non_query(bulk_query, True, "", "", "", "")
                    FormSOHPriceDet.view_list_price()
                    Close()
                Else
                    stopCustom("No data available.")
                End If
            ElseIf id_pop_up = "6" Then
                'SALES INVOICE
                Dim confirm As DialogResult = DevExpress.XtraEditors.XtraMessageBox.Show("Please, make sure :" + System.Environment.NewLine + "- Quantity which has 'Over Qty', will be automatically adjusted / equated with quantity limits." + System.Environment.NewLine + "- If the quantity limit is equal to zero, then it will not belong in invoice list." + System.Environment.NewLine + "- If this report is an important, please click 'No' button, and then click 'Print' button to export to multiple formats provided.", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
                If confirm = Windows.Forms.DialogResult.Yes Then
                    makeSafeGV(GVData)
                    GVData.ActiveFilterString = "[id_product] > '0'"
                    Cursor = Cursors.WaitCursor
                    If GVData.RowCount > 0 Then
                        Dim check_match As Boolean = False
                        Dim match_index As Integer = 0
                        For i As Integer = 0 To (GVData.RowCount - 1)
                            'check first
                            check_match = False
                            match_index = 0
                            For j As Integer = 0 To FormSalesPOSDet.GVItemList.RowCount - 1
                                If FormSalesPOSDet.GVItemList.GetRowCellValue(j, "id_product").ToString = GVData.GetRowCellValue(i, "id_product").ToString() Then
                                    'some match
                                    check_match = True
                                    match_index = j
                                    PBC.EditValue = 0
                                    Exit For
                                End If
                            Next
                            '
                            If check_match = False Then
                                Dim newRow As DataRow = (TryCast(FormSalesPOSDet.GCItemList.DataSource, DataTable)).NewRow()
                                newRow("code") = GVData.GetRowCellValue(i, "Code").ToString()
                                newRow("name") = GVData.GetRowCellValue(i, "Description").ToString()
                                newRow("size") = GVData.GetRowCellValue(i, "Size").ToString()
                                newRow("uom") = GVData.GetRowCellValue(i, "UOM").ToString()

                                Dim qty_choose As Decimal = 0.0
                                'If GVData.GetRowCellValue(i, "Qty") > GVData.GetRowCellValue(i, "Qty_Volcom") Then
                                'qty_choose = GVData.GetRowCellValue(i, "Qty_Volcom")
                                'Else
                                'qty_choose = GVData.GetRowCellValue(i, "Qty")
                                'End If
                                'mau lebih atau tidak dibiarkan
                                qty_choose = GVData.GetRowCellValue(i, "Qty")
                                '
                                newRow("sales_pos_det_qty") = qty_choose
                                newRow("sales_pos_det_amount") = qty_choose * GVData.GetRowCellValue(i, "Price")
                                newRow("design_price_retail") = GVData.GetRowCellValue(i, "Price")
                                newRow("design_price_type") = GVData.GetRowCellValue(i, "design_price_type").ToString()
                                newRow("design_price") = GVData.GetRowCellValue(i, "design_price")
                                newRow("id_design") = GVData.GetRowCellValue(i, "id_design").ToString()
                                newRow("id_product") = GVData.GetRowCellValue(i, "id_product").ToString()
                                'newRow("id_sample") = GVData.GetRowCellValue(i, "id_sample").ToString()
                                newRow("id_design_price") = GVData.GetRowCellValue(i, "id_design_price").ToString()
                                newRow("id_sales_pos_det") = "0"
                                newRow("color") = GVData.GetRowCellValue(i, "Color").ToString()
                                newRow("id_design_price_retail") = GVData.GetRowCellValue(i, "id_design_price_retail").ToString()

                                TryCast(FormSalesPOSDet.GCItemList.DataSource, DataTable).Rows.Add(newRow)
                                FormSalesPOSDet.GCItemList.RefreshDataSource()
                                FormSalesPOSDet.GVItemList.RefreshData()
                                FormSalesPOSDet.check_but()
                                FormSalesPOSDet.getDiscount()
                                FormSalesPOSDet.getNetto()
                                FormSalesPOSDet.getVat()
                                FormSalesPOSDet.getTaxBase()
                                FormSalesPOSDet.DEStart.Properties.ReadOnly = True
                                FormSalesPOSDet.DEEnd.Properties.ReadOnly = True
                            Else
                                stopCustom("This product : '" + GVData.GetRowCellValue(i, "Code").ToString() + "/" + GVData.GetRowCellValue(i, "Description").ToString() + "/Size:" + GVData.GetRowCellValue(i, "Size").ToString() + "',already exist in Item List !")
                                makeSafeGV(GVData)
                                Exit For
                            End If
                            PBC.PerformStep()
                            PBC.Update()
                        Next
                        If check_match = False Then
                            Close()
                        End If
                    Else
                        stopCustom("Not meet condition to import data, please check your file input !")
                        makeSafeGV(GVData)
                    End If
                    Cursor = Cursors.Default
                End If
            ElseIf id_pop_up = "7" Then
                'MISSING STORE
                Dim confirm As DialogResult = DevExpress.XtraEditors.XtraMessageBox.Show("Please, make sure :" + System.Environment.NewLine + "- Quantity which has 'Over Qty', will be automatically adjusted / equated with quantity limits." + System.Environment.NewLine + "- If the quantity limit is equal to zero, then it will not belong in invoice list." + System.Environment.NewLine + "- If this report is an important, please click 'No' button, and then click 'Print' button to export to multiple formats provided.", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
                If confirm = Windows.Forms.DialogResult.Yes Then
                    makeSafeGV(GVData)
                    GVData.ActiveFilterString = "[id_product] > '0'"
                    Cursor = Cursors.WaitCursor
                    If GVData.RowCount > 0 Then
                        Dim check_match As Boolean = False
                        Dim match_index As Integer = 0
                        For i As Integer = 0 To (GVData.RowCount - 1)
                            'check first
                            check_match = False
                            match_index = 0
                            For j As Integer = 0 To FormFGMissingDet.GVItemList.RowCount - 1
                                If FormFGMissingDet.GVItemList.GetRowCellValue(j, "id_product").ToString = GVData.GetRowCellValue(i, "id_product").ToString() Then
                                    'some match
                                    check_match = True
                                    match_index = j
                                    PBC.EditValue = 0
                                    Exit For
                                End If
                            Next
                            '
                            If check_match = False Then
                                Dim newRow As DataRow = (TryCast(FormFGMissingDet.GCItemList.DataSource, DataTable)).NewRow()
                                newRow("code") = GVData.GetRowCellValue(i, "Code").ToString()
                                newRow("name") = GVData.GetRowCellValue(i, "Description").ToString()
                                newRow("size") = GVData.GetRowCellValue(i, "Size").ToString()
                                newRow("uom") = GVData.GetRowCellValue(i, "UOM").ToString()

                                Dim qty_choose As Decimal = 0.0
                                If GVData.GetRowCellValue(i, "Qty") > GVData.GetRowCellValue(i, "Qty_Volcom") Then
                                    qty_choose = GVData.GetRowCellValue(i, "Qty_Volcom")
                                Else
                                    qty_choose = GVData.GetRowCellValue(i, "Qty")
                                End If
                                newRow("sales_pos_det_qty") = qty_choose
                                newRow("sales_pos_det_amount") = qty_choose * GVData.GetRowCellValue(i, "design_price")
                                newRow("design_price_retail") = GVData.GetRowCellValue(i, "Price")
                                newRow("design_price_type") = GVData.GetRowCellValue(i, "design_price_type").ToString()
                                newRow("design_price") = GVData.GetRowCellValue(i, "design_price")
                                newRow("id_design") = GVData.GetRowCellValue(i, "id_design").ToString()
                                newRow("id_product") = GVData.GetRowCellValue(i, "id_product").ToString()
                                newRow("id_sample") = GVData.GetRowCellValue(i, "id_sample").ToString()
                                newRow("id_design_price") = GVData.GetRowCellValue(i, "id_design_price").ToString()
                                newRow("id_sales_pos_det") = "0"
                                newRow("color") = GVData.GetRowCellValue(i, "Color").ToString()
                                newRow("id_design_price_retail") = GVData.GetRowCellValue(i, "id_design_price_retail").ToString()


                                TryCast(FormFGMissingDet.GCItemList.DataSource, DataTable).Rows.Add(newRow)
                                FormFGMissingDet.GCItemList.RefreshDataSource()
                                FormFGMissingDet.GVItemList.RefreshData()
                                FormFGMissingDet.check_but()
                                FormFGMissingDet.getDiscount()
                                FormFGMissingDet.getNetto()
                                FormFGMissingDet.getVat()
                                FormFGMissingDet.getTaxBase()
                                FormFGMissingDet.DEStart.Properties.ReadOnly = True
                                FormFGMissingDet.DEEnd.Properties.ReadOnly = True
                            Else
                                stopCustom("This product : '" + GVData.GetRowCellValue(i, "Code").ToString() + "/" + GVData.GetRowCellValue(i, "Description").ToString() + "/Size:" + GVData.GetRowCellValue(i, "Size").ToString() + "',already exist in Item List !")
                                makeSafeGV(GVData)
                                Exit For
                            End If
                            PBC.PerformStep()
                            PBC.Update()
                        Next
                        If check_match = False Then
                            Close()
                        End If
                    Else
                        stopCustom("No fullfill condition to import data, please check your file input !")
                        makeSafeGV(GVData)
                    End If
                    Cursor = Cursors.Default
                End If
            ElseIf id_pop_up = "8" Then 'import faktur keluaran
                If GVData.RowCount > 0 Then
                    PBC.Properties.Minimum = 0
                    PBC.Properties.Maximum = GVData.RowCount - 1
                    PBC.Properties.Step = 1
                    PBC.Properties.PercentView = True

                    Dim bulk_query As String = ""
                    Dim id_acc_fak_scan As String = FormAccountingFakturScanSingle.id_acc_fak_scan

                    Dim del_query As String = "DELETE FROM tb_a_acc_fak_scan_fk_det WHERE id_acc_fak_scan='" + id_acc_fak_scan + "'"
                    execute_non_query(del_query, True, "", "", "", "")

                    bulk_query = "INSERT INTO tb_a_acc_fak_scan_fk_det(id_acc_fak_scan, kd_jenis_transaksi, fg_pengganti, nomor_faktur, masa_pajak, tahun_pajak, tanggal_faktur, npwp, nama, alamat_lengkap, jumlah_dpp, jumlah_ppn, jumlah_ppnbm, id_keterangan_tambahan, fg_uang_muka, uang_muka_dpp, uang_muka_ppn, uang_muka_ppnbm, referensi, of, kode_objek, nama3, harga_satuan, jumlah_barang, harga_total, diskon, dpp, ppn, tarif_ppnbm, ppnbm) VALUES "
                    For i As Integer = 0 To (GVData.RowCount - 1)
                        'number
                        Dim total As Decimal = Math.Round(Decimal.Parse(GVData.GetRowCellValue(i, "total").ToString))
                        Dim ppn As String = Math.Round(Decimal.Parse(GVData.GetRowCellValue(i, "ppn").ToString))
                        Dim dpp As String = Math.Round(Decimal.Parse(GVData.GetRowCellValue(i, "dpp").ToString))


                        'no faktur
                        Dim no_faktur_ori As String = GVData.GetRowCellValue(i, "no_faktur").ToString
                        Dim col_foc_str As String() = Split(no_faktur_ori, ".")
                        Dim kd_jenis_transaksi As String = col_foc_str(0).Substring(0, 2).ToString
                        Dim fg_pengganti As String = col_foc_str(0).Substring(2, 1)
                        Dim no_faktur As String = col_foc_str(1).Replace("-", "").Replace(".", "") + col_foc_str(2).ToString

                        'query
                        bulk_query += "('" + id_acc_fak_scan + "','" + kd_jenis_transaksi + "','" + fg_pengganti + "','" + addSlashes(no_faktur) + "','" + FormAccountingFakturScanSingle.TxtPeriod.Text + "','" + FormAccountingFakturScanSingle.TxtYear.Text + "', '" + FormAccountingFakturScanSingle.TxtFakturDate.Text + "', '" + addSlashes(GVData.GetRowCellValue(i, "npwp").Replace(".", "").Replace("-", "")) + "', '" + addSlashes(GVData.GetRowCellValue(i, "nama_toko").ToString) + "', '" + addSlashes(GVData.GetRowCellValue(i, "alamat").ToString) + "', '" + decimalSQL(dpp.ToString) + "', '" + decimalSQL(ppn.ToString) + "', '0', '','0','0', '0', '0', '" + addSlashes(GVData.GetRowCellValue(i, "referensi").ToString) + "', 'OF', '" + addSlashes(GVData.GetRowCellValue(i, "kode_barang").ToString) + "', '" + addSlashes(GVData.GetRowCellValue(i, "ket_barang").ToString) + "', '" + decimalSQL(dpp.ToString) + "', '1', '" + decimalSQL(dpp.ToString) + "', '0', '" + decimalSQL(dpp.ToString) + "', '" + decimalSQL(ppn.ToString) + "', '0', '0') "
                        If Not i = GVData.RowCount - 1 Then
                            bulk_query += ","
                        End If
                        PBC.PerformStep()
                        PBC.Update()
                    Next

                    execute_non_query(bulk_query, True, "", "", "", "")
                    FormAccountingFakturScanSingle.viewDetail()
                    Close()
                Else
                    stopCustom("No data available.")
                End If
            ElseIf id_pop_up = "9" Or id_pop_up = "10" Then 'import distribution scheme
                Dim data_edit As New DataTable
                'initialisation datatable edit
                Try
                    data_edit.Columns.Add("id_fg_ds_store")
                    data_edit.Columns.Add("store_name")
                Catch ex As Exception
                End Try

                'identify column
                Dim jum_store As Integer = 0
                For i As Integer = 0 To (GVData.Columns.Count - 1)
                    If GVData.Columns(i).FieldName.Contains("-") Then
                        Dim col_foc_str As String() = Split(GVData.Columns(i).FieldName.ToString, " - ")
                        Dim code As String = col_foc_str(0)
                        Dim name As String = col_foc_str(1)
                        Dim query_str As String = "SELECT str.id_fg_ds_store FROM tb_fg_ds_store str "
                        query_str += "INNER JOIN tb_m_comp comp ON comp.id_comp = str.id_comp "
                        query_str += "WHERE comp.comp_number='" + code + "' AND comp.comp_name='" + name + "' "
                        If id_pop_up = "9" Then
                            query_str += "AND str.id_season='" + FormFGDistScheme.SLESeason.EditValue.ToString + "' LIMIT 1 "
                        ElseIf id_pop_up = "10" Then
                            query_str += "AND str.id_season='" + FormFGSalesOrderReffDet.SLESeason.EditValue.ToString + "' LIMIT 1 "
                        End If

                        Dim data As DataTable = execute_query(query_str, -1, True, "", "", "", "")
                        If data.Rows.Count > 0 Then
                            Dim R As DataRow = data_edit.NewRow
                            R("id_fg_ds_store") = data.Rows(0)("id_fg_ds_store").ToString
                            R("store_name") = GVData.Columns(i).FieldName.ToString
                            data_edit.Rows.Add(R)
                            jum_store += 1
                        End If
                    End If
                Next

                If jum_store = 0 Then
                    stopCustom("Can't identify store. Please make sure your input.")
                Else
                    For i As Integer = 0 To ((GVData.RowCount - 1) - GetGroupRowCount(GVData))
                        Dim code_product As String = "0"
                        Try
                            code_product = GVData.GetRowCellValue(i, "CODE").ToString
                        Catch ex As Exception
                        End Try
                        Dim id_product As String = execute_query("SELECT id_product FROM tb_m_product WHERE product_full_code='" + code_product + "' ", 0, True, "", "", "", "")

                        If id_pop_up = "9" Then
                            Dim type_ds As String = FormFGDistScheme.SLEType.EditValue.ToString
                            For j As Integer = 0 To (data_edit.Rows.Count - 1)
                                Dim qty As String = decimalSQL(GVData.GetRowCellValue(i, data_edit.Rows(j)("store_name").ToString).ToString)
                                Dim query_ds As String = "CALL generate_fg_ds('" + type_ds + "', '" + data_edit.Rows(j)("id_fg_ds_store").ToString + "', '" + id_product + "', '" + qty + "') "
                                execute_non_query(query_ds, True, "", "", "", "")
                            Next
                        ElseIf id_pop_up = "10" Then
                            For j As Integer = 0 To (data_edit.Rows.Count - 1)
                                Dim qty As String = decimalSQL(GVData.GetRowCellValue(i, data_edit.Rows(j)("store_name").ToString).ToString)
                                Dim query_ds As String = "UPDATE tb_fg_so_reff_det SET fg_so_reff_det_qty='" + qty + "' WHERE id_fg_so_reff='" + FormFGSalesOrderReffDet.id_fg_so_reff + "' AND id_product='" + id_product + "' AND id_fg_ds_store='" + data_edit.Rows(j)("id_fg_ds_store").ToString + "' "
                                execute_non_query(query_ds, True, "", "", "", "")
                            Next
                        End If


                        PBC.PerformStep()
                        PBC.Update()
                    Next
                End If
                data_edit.Dispose()

                If id_pop_up = "9" Then
                    FormFGDistScheme.loadDS(FormFGDistScheme.SLESeason.EditValue.ToString, FormFGDistScheme.SLEType.EditValue.ToString, FormFGDistScheme.GCDS, FormFGDistScheme.GVDS)
                ElseIf id_pop_up = "10" Then
                    FormFGSalesOrderReffDet.viewDetail()
                End If
                Close()
            ElseIf id_pop_up = "11" Then
                Dim confirm As DialogResult = DevExpress.XtraEditors.XtraMessageBox.Show("Please make sure :" + System.Environment.NewLine + "- Only 'OK' status will include in order list." + System.Environment.NewLine + "- If this report is an important, please click 'No' button, and then click 'Print' button to export to multiple formats provided." + System.Environment.NewLine + "Are you sure you want to continue this process?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
                If confirm = Windows.Forms.DialogResult.Yes Then
                    makeSafeGV(GVData)
                    GVData.ActiveFilterString = "[Status] = 'OK'"
                    If GVData.RowCount > 0 Then
                        For i As Integer = 0 To GVData.RowCount - 1
                            Dim newRow As DataRow = (TryCast(FormSalesReturnOrderDet.GCItemList.DataSource, DataTable)).NewRow()
                            newRow("id_sales_return_order_det") = "0"
                            newRow("name") = GVData.GetRowCellValue(i, "Style").ToString
                            newRow("code") = GVData.GetRowCellValue(i, "Code").ToString
                            newRow("size") = GVData.GetRowCellValue(i, "Size").ToString
                            newRow("sales_return_order_det_qty") = GVData.GetRowCellValue(i, "Qty")
                            newRow("design_price_type") = ""
                            newRow("id_design_price") = GVData.GetRowCellValue(i, "id_design_price_retail").ToString
                            newRow("design_price") = GVData.GetRowCellValue(i, "Price")
                            newRow("id_return_cat") = "1"
                            newRow("return_cat") = "Return"
                            newRow("amount") = GVData.GetRowCellValue(i, "Amount")
                            newRow("sales_return_order_det_note") = ""
                            newRow("id_design") = GVData.GetRowCellValue(i, "id_design").ToString
                            newRow("id_product") = GVData.GetRowCellValue(i, "id_product").ToString
                            newRow("id_sample") = "0"
                            TryCast(FormSalesReturnOrderDet.GCItemList.DataSource, DataTable).Rows.Add(newRow)
                            FormSalesReturnOrderDet.GCItemList.RefreshDataSource()
                            FormSalesReturnOrderDet.GVItemList.RefreshData()
                            PBC.PerformStep()
                            PBC.Update()
                        Next
                        FormSalesReturnOrderDet.GVItemList.OptionsBehavior.AutoExpandAllGroups = True
                        FormSalesReturnOrderDet.check_but()
                        Close()
                    Else
                        stopCustom("There is no data for import process, please make sure your input !")
                        makeSafeGV(GVData)
                    End If
                End If
            ElseIf id_pop_up = "12" Then
                'check
                makeSafeGV(GVData)
                GVData.ActiveFilterString = "[err_format] = ''"
                If GVData.RowCount > 0 Then
                    PBC.Properties.Minimum = 0
                    PBC.Properties.Maximum = GVData.RowCount - 1
                    PBC.Properties.Step = 1
                    PBC.Properties.PercentView = True
                    For i As Integer = 0 To (GVData.RowCount - 1)
                        'insert mat_det
                        Dim id_mat_det As String = ""
                        Dim query As String = ""
                        query = "INSERT INTO tb_m_mat_det(id_mat,mat_det_display_name,mat_det_name,mat_det_code,mat_det_date,id_range) "
                        query += "VALUES('" + GVData.GetRowCellValue(i, "id_mat").ToString + "','" + GVData.GetRowCellValue(i, "Description").ToString + "','" + GVData.GetRowCellValue(i, "Description").ToString + "','" + GVData.GetRowCellValue(i, "Code").ToString + "',NOW(),'" + GVData.GetRowCellValue(i, "id_range").ToString + "')"
                        query += "; SELECT LAST_INSERT_ID();"

                        id_mat_det = execute_query(query, 0, True, "", "", "", "")
                        'insert code
                        query = "INSERT INTO tb_m_mat_det_code(id_mat_det,id_code_detail) VALUES"
                        query += "('" + id_mat_det + "','" + GVData.GetRowCellValue(i, "id_code_detail_year").ToString + "')," 'year
                        query += "('" + id_mat_det + "','" + GVData.GetRowCellValue(i, "id_code_detail_color").ToString + "')," 'color
                        query += "('" + id_mat_det + "','" + GVData.GetRowCellValue(i, "id_code_detail_count").ToString + "')," 'counting
                        query += "('" + id_mat_det + "','" + GVData.GetRowCellValue(i, "id_code_detail_size").ToString + "')," 'size
                        query += "('" + id_mat_det + "','" + GVData.GetRowCellValue(i, "id_code_detail_lot").ToString + "');" 'lot
                        execute_non_query(query, True, "", "", "", "")

                        'insert harga
                        query = "INSERT INTO tb_m_mat_det_price(id_mat_det,id_comp_contact,mat_det_price_name,id_currency,mat_det_price,mat_det_price_date,is_default_cost)"
                        query += "VALUES('" + id_mat_det + "','" + GVData.GetRowCellValue(i, "id_comp_contact").ToString + "','Normal Price','" + GVData.GetRowCellValue(i, "id_currency").ToString + "','" + decimalSQL(GVData.GetRowCellValue(i, "Price").ToString) + "',NOW(),1)"
                        execute_non_query(query, True, "", "", "", "")

                        PBC.PerformStep()
                        PBC.Update()
                    Next

                    Close()
                Else
                    stopCustom("No data available.")
                End If
            ElseIf id_pop_up = "13" Then
                Dim confirm As DialogResult = DevExpress.XtraEditors.XtraMessageBox.Show("Please make sure :" + System.Environment.NewLine + "- Only 'OK' status will continue to next step." + System.Environment.NewLine + "- If this report is an important, please click 'No' button, and then click 'Print' button to export to multiple formats provided." + System.Environment.NewLine + "Are you sure you want to continue this process?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
                If confirm = Windows.Forms.DialogResult.Yes Then
                    makeSafeGV(GVData)
                    GVData.ActiveFilterString = "[Status] = 'OK'"
                    If GVData.RowCount > 0 Then
                        Cursor = Cursors.WaitCursor
                        'del
                        Dim id_fg_price As String = FormMasterPriceSingle.id_fg_price
                        Dim query_del As String = "DELETE FROM tb_fg_price_det WHERE id_fg_price='" + id_fg_price + "' "
                        execute_non_query(query_del, True, "", "", "", "")

                        'ins
                        Dim l_i As Integer = 0
                        Dim query_ins As String = "INSERT INTO tb_fg_price_det(id_fg_price, id_design, design_price_name, id_currency, design_price, is_print) VALUES "
                        For l As Integer = 0 To ((GVData.RowCount - 1) - GetGroupRowCount(GVData))
                            Dim id_design As String = GVData.GetRowCellValue(l, "id_design").ToString
                            Dim design_price_name As String = GVData.GetRowCellValue(l, "PriceName").ToString
                            Dim id_currency As String = GVData.GetRowCellValue(l, "id_currency").ToString
                            Dim design_price As String = decimalSQL(GVData.GetRowCellValue(l, "Price").ToString)
                            Dim is_print As String = GVData.GetRowCellValue(l, "is_print").ToString

                            If l_i > 0 Then
                                query_ins += ", "
                            End If
                            query_ins += "('" + id_fg_price + "', '" + id_design + "', '" + design_price_name + "', '" + id_currency + "', '" + design_price + "', '" + is_print + "') "
                            l_i += 1
                            PBC.PerformStep()
                            PBC.Update()
                        Next
                        If l_i > 0 Then
                            execute_non_query(query_ins, True, "", "", "", "")
                        End If
                        FormMasterPriceSingle.viewDetail()
                        Close()
                        Cursor = Cursors.Default
                    Else
                        stopCustom("There is no data for import process, please make sure your input !")
                        makeSafeGV(GVData)
                    End If
                End If
            ElseIf id_pop_up = "14" Then 'import delivery order
                Dim confirm As DialogResult = DevExpress.XtraEditors.XtraMessageBox.Show("Please make sure :" + System.Environment.NewLine + "- Only 'OK' status will continue to next step." + System.Environment.NewLine + "- If this report is an important, please click 'No' button, and then click 'Print' button to export to multiple formats provided." + System.Environment.NewLine + "Are you sure you want to continue this process?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
                If confirm = Windows.Forms.DialogResult.Yes Then
                    makeSafeGV(GVData)
                    GVData.ActiveFilterString = "[Status] = 'OK'"
                    If GVData.RowCount > 0 Then
                        Cursor = Cursors.WaitCursor
                        'ins
                        Dim l_i As Integer = 0
                        Dim query_ins As String = "INSERT INTO tb_wh_awb_do(do_no, scan_date, store_number, store_name, qty, reff) VALUES "
                        For l As Integer = 0 To ((GVData.RowCount - 1) - GetGroupRowCount(GVData))
                            Dim do_no As String = addSlashes(GVData.GetRowCellValue(l, "DO").ToString)
                            Dim scan_date As String = addSlashes(GVData.GetRowCellValue(l, "Date").ToString)
                            Dim store_number As String = addSlashes(GVData.GetRowCellValue(l, "StoreNumber").ToString)
                            Dim store_name As String = addSlashes(GVData.GetRowCellValue(l, "StoreName").ToString)
                            Dim reff As String = addSlashes(GVData.GetRowCellValue(l, "Reff").ToString)
                            Dim qty As String = decimalSQL(GVData.GetRowCellValue(l, "Qty").ToString)

                            If l_i > 0 Then
                                query_ins += ", "
                            End If
                            query_ins += "('" + do_no + "', '" + scan_date + "', '" + store_number + "', '" + store_name + "', '" + qty + "', '" + reff + "') "
                            l_i += 1
                            PBC.PerformStep()
                            PBC.Update()
                        Next
                        If l_i > 0 Then
                            execute_non_query(query_ins, True, "", "", "", "")
                        End If
                        FormWHImportDO.viewDOList()
                        Close()
                        Cursor = Cursors.Default
                    Else
                        stopCustom("There is no data for import process, please make sure your input !")
                        makeSafeGV(GVData)
                    End If
                End If
            ElseIf id_pop_up = "15" Or id_pop_up = "25" Then 'SALES ORDER
                Dim confirm As DialogResult = DevExpress.XtraEditors.XtraMessageBox.Show("Please make sure :" + System.Environment.NewLine + "- Only 'OK' status will include in order list." + System.Environment.NewLine + "- If this report is an important, please click 'No' button, and then click 'Print' button to export to multiple formats provided." + System.Environment.NewLine + "Are you sure you want to continue this process?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
                If confirm = Windows.Forms.DialogResult.Yes Then
                    makeSafeGV(GVData)
                    GVData.ActiveFilterString = "[Status] = 'OK'"
                    If GVData.RowCount > 0 Then
                        FormSalesOrderDet.delNotFoundMyRow()
                        For i As Integer = 0 To GVData.RowCount - 1
                            Dim newRow As DataRow = (TryCast(FormSalesOrderDet.GCItemList.DataSource, DataTable)).NewRow()
                            newRow("id_sales_order_det") = "0"
                            newRow("name") = GVData.GetRowCellValue(i, "Style").ToString
                            newRow("code") = GVData.GetRowCellValue(i, "Code").ToString
                            newRow("size") = GVData.GetRowCellValue(i, "Size").ToString
                            newRow("sales_order_det_qty") = GVData.GetRowCellValue(i, "Qty")
                            newRow("id_design_price") = GVData.GetRowCellValue(i, "id_design_price").ToString
                            newRow("design_price") = GVData.GetRowCellValue(i, "Price")
                            newRow("design_price_type") = GVData.GetRowCellValue(i, "design_price_type").ToString
                            newRow("amount") = GVData.GetRowCellValue(i, "Price") * GVData.GetRowCellValue(i, "Qty")
                            newRow("sales_order_det_note") = ""
                            newRow("id_design") = GVData.GetRowCellValue(i, "id_design").ToString
                            newRow("id_product") = GVData.GetRowCellValue(i, "id_product").ToString
                            newRow("is_found") = "1"
                            TryCast(FormSalesOrderDet.GCItemList.DataSource, DataTable).Rows.Add(newRow)
                            FormSalesOrderDet.GCItemList.RefreshDataSource()
                            FormSalesOrderDet.GVItemList.RefreshData()
                            PBC.PerformStep()
                            PBC.Update()
                        Next
                        FormSalesReturnOrderDet.check_but()
                        Close()
                    Else
                        stopCustom("There is no data for import process, please make sure your input !")
                        makeSafeGV(GVData)
                    End If
                End If
            ElseIf id_pop_up = "16" Then 'ECOP
                Dim confirm As DialogResult = DevExpress.XtraEditors.XtraMessageBox.Show("Please keep in mind :" + System.Environment.NewLine + "- Only 'OK' status data will be imported." + System.Environment.NewLine + "- If this report is an important, please click 'No' button, and then click 'Print' button to export to multiple formats provided." + System.Environment.NewLine + "Are you sure you want to continue this process?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
                If confirm = Windows.Forms.DialogResult.Yes Then
                    makeSafeGV(GVData)
                    GVData.ActiveFilterString = "[err_format] = 'OK'"
                    If GVData.RowCount > 0 Then
                        For i As Integer = 0 To GVData.RowCount - 1
                            Dim query As String = ""
                            Dim id_bom As String = ""
                            Dim id_bom_approve As String = ""
                            'update default bom
                            query = "UPDATE "
                            query += " tb_bom bom "
                            query += " INNER JOIN tb_m_product m_p ON m_p.id_product=bom.id_product"
                            query += " SET bom.is_default = 2"
                            query += " WHERE m_p.id_design='" & GVData.GetRowCellValue(i, "id_design").ToString & "'"
                            execute_non_query(query, True, "", "", "", "")

                            'create bom report
                            query = "INSERT INTO tb_bom_approve(id_report_status) VALUES('1'); SELECT LAST_INSERT_ID();"
                            id_bom_approve = execute_query(query, 0, True, "", "", "", "")

                            'insert bom
                            'query = "INSERT INTO tb_bom(id_product,id_term_production,bom_name,id_currency,kurs,bom_unit_price,bom_date_created,id_user_last_update,is_default,id_report_status)"
                            'query += " VALUES('" + GVData.GetRowCellValue(i, "id_product").ToString + "','1','ECOP','" + GVData.GetRowCellValue(i, "id_currency").ToString + "','" + decimalSQL(GVData.GetRowCellValue(i, "Kurs").ToString) + "','" + decimalSQL(GVData.GetRowCellValue(i, "ECOP").ToString) + "',NOW(),'" + id_user + "','1','1')"
                            'query += "; SELECT LAST_INSERT_ID();"

                            'id_bom = execute_query(query, 0, True, "", "", "", "")

                            'insert bom det
                            'query = "INSERT INTO tb_bom_det(id_bom,id_component_category,id_ovh_price,kurs,bom_price,component_qty,is_cost,is_ovh_main)"
                            'query += " VALUES('" + id_bom + "','2','" + GVData.GetRowCellValue(i, "id_ovh_price").ToString + "','0','" + decimalSQL(GVData.GetRowCellValue(i, "ECOP").ToString) + "','1','1','1')"
                            'execute_non_query(query, True, "", "", "", "")

                            'insert bom default
                            query = "INSERT INTO tb_bom(id_product,id_term_production,bom_name,id_currency,kurs,bom_unit_price,bom_date_created,is_default,id_bom_approve,id_user_last_update,bom_date_updated)"
                            query += " SELECT "
                            query += " id_product"
                            query += " ,'1' AS id_term_production"
                            query += " ,'Estimate COP' AS bom_name"
                            query += " ,'" & GVData.GetRowCellValue(i, "id_currency").ToString & "' AS id_currency"
                            query += " ,'" & decimalSQL(GVData.GetRowCellValue(i, "Kurs").ToString) & "' AS kurs"
                            query += " ,'" & decimalSQL(GVData.GetRowCellValue(i, "ECOP").ToString) & "' AS bom_unit_price"
                            query += " ,NOW() AS bom_date_created"
                            query += " ,'1' AS is_default"
                            query += " ,'" & id_bom_approve & "'"
                            query += " ,'" & id_user & "' AS id_user_last_update"
                            query += " ,NOW() AS bom_last_updated"
                            query += " FROM tb_m_product"
                            query += " WHERE id_design='" & GVData.GetRowCellValue(i, "id_design").ToString & "'"
                            execute_non_query(query, True, "", "", "", "")

                            'insert det
                            query = "INSERT INTO tb_bom_det(id_bom,id_component_category,id_ovh_price,bom_price,component_qty,is_ovh_main)"
                            query += " SELECT "
                            query += " id_bom"
                            query += " ,'2' AS id_component_category"
                            query += " ,'" & GVData.GetRowCellValue(i, "id_ovh_price").ToString & "' AS id_ovh_price"
                            query += " ,'" & decimalSQL(GVData.GetRowCellValue(i, "ECOP").ToString) & "' AS bom_price"
                            query += " ,'1' AS component_qty"
                            query += " ,'1' AS is_ovh_main"
                            query += " FROM tb_bom bom"
                            query += " INNER JOIN tb_m_product m_p ON m_p.id_product = bom.id_product"
                            query += " WHERE m_p.id_design='" & GVData.GetRowCellValue(i, "id_design").ToString & "' AND bom.is_default='1'"
                            execute_non_query(query, True, "", "", "", "")

                            PBC.PerformStep()
                            PBC.Update()
                        Next
                        FormSalesReturnOrderDet.check_but()
                        Close()
                    Else
                        stopCustom("There is no data for import process, please make sure your input !")
                        makeSafeGV(GVData)
                    End If
                End If
            ElseIf id_pop_up = "17" Then
                Dim confirm As DialogResult = DevExpress.XtraEditors.XtraMessageBox.Show("Please make sure :" + System.Environment.NewLine + "- Only 'OK' status will continue to next step." + System.Environment.NewLine + "- If this report is an important, please click 'No' button, and then click 'Print' button to export to multiple formats provided." + System.Environment.NewLine + "Are you sure you want to continue this process?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
                If confirm = Windows.Forms.DialogResult.Yes Then
                    makeSafeGV(GVData)
                    GVData.ActiveFilterString = "[Status] = 'OK'"
                    If GVData.RowCount > 0 Then
                        Cursor = Cursors.WaitCursor
                        'ins
                        For l As Integer = 0 To ((GVData.RowCount - 1) - GetGroupRowCount(GVData))
                            Dim id As String = addSlashes(GVData.GetRowCellValue(l, "id").ToString)
                            Dim price As String = decimalSQL(GVData.GetRowCellValue(l, "est_price").ToString)
                            Dim rate As String = decimalSQL(GVData.GetRowCellValue(l, "rate_current").ToString)
                            Dim msrp_rp As String = decimalSQL(GVData.GetRowCellValue(l, "msrp_rp").ToString)
                            Dim msrp As String = decimalSQL(GVData.GetRowCellValue(l, "msrp").ToString)

                            'query
                            Dim query_upd As String = "UPDATE tb_prod_demand_design SET prod_demand_design_propose_price ='" + price + "', rate_current='" + rate + "', msrp='" + msrp + "', msrp_rp='" + msrp_rp + "' WHERE id_prod_demand_design='" + id + "' "
                            execute_non_query(query_upd, True, "", "", "", "")
                            PBC.PerformStep()
                            PBC.Update()
                        Next

                        FormFGLineList.viewLineList()
                        Close()
                        Cursor = Cursors.Default
                    Else
                        stopCustom("There is no data for import process, please make sure your input !")
                        makeSafeGV(GVData)
                    End If
                End If
            ElseIf id_pop_up = "18" Then
                'SALES Promo
                Dim confirm As DialogResult = DevExpress.XtraEditors.XtraMessageBox.Show("Please, make sure :" + System.Environment.NewLine + "- Quantity which has 'Over Qty', will be automatically adjusted / equated with quantity limits." + System.Environment.NewLine + "- If the quantity limit is equal to zero, then it will not belong in invoice list." + System.Environment.NewLine + "- If this report is an important, please click 'No' button, and then click 'Print' button to export to multiple formats provided.", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
                If confirm = Windows.Forms.DialogResult.Yes Then
                    makeSafeGV(GVData)
                    GVData.ActiveFilterString = "[id_product] > '0'"
                    Cursor = Cursors.WaitCursor
                    If GVData.RowCount > 0 Then
                        Dim check_match As Boolean = False
                        Dim match_index As Integer = 0
                        For i As Integer = 0 To (GVData.RowCount - 1)
                            'check first
                            check_match = False
                            match_index = 0
                            For j As Integer = 0 To FormSalesPOSDet.GVItemList.RowCount - 1
                                If FormSalesPOSDet.GVItemList.GetRowCellValue(j, "id_product").ToString = GVData.GetRowCellValue(i, "id_product").ToString() Then
                                    'some match
                                    check_match = True
                                    match_index = j
                                    PBC.EditValue = 0
                                    Exit For
                                End If
                            Next
                            '
                            If check_match = False Then
                                Dim newRow As DataRow = (TryCast(FormSalesPromoDet.GCItemList.DataSource, DataTable)).NewRow()
                                newRow("code") = GVData.GetRowCellValue(i, "Code").ToString()
                                newRow("name") = GVData.GetRowCellValue(i, "Description").ToString()
                                newRow("size") = GVData.GetRowCellValue(i, "Size").ToString()
                                newRow("uom") = GVData.GetRowCellValue(i, "UOM").ToString()

                                Dim qty_choose As Decimal = 0.0
                                'If GVData.GetRowCellValue(i, "Qty") > GVData.GetRowCellValue(i, "Qty_Volcom") Then
                                'qty_choose = GVData.GetRowCellValue(i, "Qty_Volcom")
                                'Else
                                'qty_choose = GVData.GetRowCellValue(i, "Qty")
                                'End If
                                'mau lebih atau tidak dibiarkan
                                qty_choose = GVData.GetRowCellValue(i, "Qty")
                                '
                                newRow("sales_pos_det_qty") = qty_choose
                                newRow("sales_pos_det_amount") = qty_choose * GVData.GetRowCellValue(i, "Price")
                                newRow("design_price_retail") = GVData.GetRowCellValue(i, "Price")
                                newRow("design_price_type") = GVData.GetRowCellValue(i, "design_price_type").ToString()
                                newRow("design_price") = GVData.GetRowCellValue(i, "design_price")
                                newRow("id_design") = GVData.GetRowCellValue(i, "id_design").ToString()
                                newRow("id_product") = GVData.GetRowCellValue(i, "id_product").ToString()
                                newRow("id_sample") = GVData.GetRowCellValue(i, "id_sample").ToString()
                                newRow("id_design_price") = GVData.GetRowCellValue(i, "id_design_price").ToString()
                                newRow("id_sales_pos_det") = "0"
                                newRow("color") = GVData.GetRowCellValue(i, "Color").ToString()
                                newRow("id_design_price_retail") = GVData.GetRowCellValue(i, "id_design_price_retail").ToString()

                                TryCast(FormSalesPromoDet.GCItemList.DataSource, DataTable).Rows.Add(newRow)
                                FormSalesPromoDet.GCItemList.RefreshDataSource()
                                FormSalesPromoDet.GVItemList.RefreshData()
                                FormSalesPromoDet.check_but()
                                FormSalesPromoDet.getNetto()
                                FormSalesPromoDet.getVat()
                                FormSalesPromoDet.getTaxBase()
                                FormSalesPromoDet.DEStart.Properties.ReadOnly = True
                                FormSalesPromoDet.DEEnd.Properties.ReadOnly = True
                            Else
                                stopCustom("This product : '" + GVData.GetRowCellValue(i, "Code").ToString() + "/" + GVData.GetRowCellValue(i, "Description").ToString() + "/Size:" + GVData.GetRowCellValue(i, "Size").ToString() + "',already exist in Item List !")
                                makeSafeGV(GVData)
                                Exit For
                            End If
                            PBC.PerformStep()
                            PBC.Update()
                        Next
                        If check_match = False Then
                            Close()
                        End If
                    Else
                        stopCustom("Not meet condition to import data, please check your file input !")
                        makeSafeGV(GVData)
                    End If
                    Cursor = Cursors.Default
                End If
            ElseIf id_pop_up = "19" Then
                ' MASTER SAMPLE PRICE
                Dim confirm As DialogResult = DevExpress.XtraEditors.XtraMessageBox.Show("Please make sure :" + System.Environment.NewLine + "- Only 'OK' status will continue to next step." + System.Environment.NewLine + "- If this report is an important, please click 'No' button, and then click 'Print' button to export to multiple formats provided." + System.Environment.NewLine + "Are you sure you want to continue this process?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
                If confirm = Windows.Forms.DialogResult.Yes Then
                    makeSafeGV(GVData)
                    GVData.ActiveFilterString = "[Status] = 'OK'"
                    If GVData.RowCount > 0 Then
                        Cursor = Cursors.WaitCursor
                        'del
                        Dim id_sample_price As String = FormMasterPriceSampleSingle.id_sample_price
                        Dim query_del As String = "DELETE FROM tb_sample_price_det WHERE id_sample_price='" + id_sample_price + "' "
                        execute_non_query(query_del, True, "", "", "", "")

                        'ins
                        Dim l_i As Integer = 0
                        Dim query_ins As String = "INSERT INTO tb_sample_price_det(id_sample_price, id_sample, sample_price_name, id_currency, sample_price, is_print) VALUES "
                        For l As Integer = 0 To ((GVData.RowCount - 1) - GetGroupRowCount(GVData))
                            Dim id_sample As String = GVData.GetRowCellValue(l, "id_sample").ToString
                            Dim design_price_name As String = addSlashes(GVData.GetRowCellValue(l, "PriceName").ToString)
                            Dim id_currency As String = GVData.GetRowCellValue(l, "id_currency").ToString
                            Dim sample_price As String = decimalSQL(GVData.GetRowCellValue(l, "Price").ToString)
                            Dim is_print As String = GVData.GetRowCellValue(l, "is_print").ToString

                            If l_i > 0 Then
                                query_ins += ", "
                            End If
                            query_ins += "('" + id_sample_price + "', '" + id_sample + "', '" + design_price_name + "', '" + id_currency + "', '" + sample_price + "', '" + is_print + "') "
                            l_i += 1
                            PBC.PerformStep()
                            PBC.Update()
                        Next
                        If l_i > 0 Then
                            execute_non_query(query_ins, True, "", "", "", "")
                        End If
                        FormMasterPriceSampleSingle.viewDetail()
                        Close()
                        Cursor = Cursors.Default
                    Else
                        stopCustom("There is no data for import process, please make sure your input !")
                        makeSafeGV(GVData)
                    End If
                End If
            ElseIf id_pop_up = "20" Or id_pop_up = "24" Then
                'inventory allocation
                Dim confirm As DialogResult = DevExpress.XtraEditors.XtraMessageBox.Show("Please make sure :" + System.Environment.NewLine + "- Only 'OK' status will continue to next step." + System.Environment.NewLine + "- If this report is an important, please click 'No' button, and then click 'Print' button to export to multiple formats provided." + System.Environment.NewLine + "Are you sure you want to continue this process?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
                If confirm = Windows.Forms.DialogResult.Yes Then
                    makeSafeGV(GVData)
                    GVData.ActiveFilterString = "[Status] = 'OK'"
                    If GVData.RowCount > 0 Then
                        Cursor = Cursors.WaitCursor
                        'del
                        Dim query_del As String = "DELETE FROM tb_fg_wh_alloc_det WHERE id_fg_wh_alloc='" + FormFGWHAllocDet.id_fg_wh_alloc + "' "
                        execute_non_query(query_del, True, "", "", "", "")

                        'ins
                        Dim l_i As Integer = 0
                        Dim query_ins As String = "INSERT INTO tb_fg_wh_alloc_det(id_fg_wh_alloc, id_product, id_wh_drawer_to, fg_wh_alloc_det_qty) VALUES "
                        For l As Integer = 0 To ((GVData.RowCount - 1) - GetGroupRowCount(GVData))
                            Dim id_fg_wh_alloc As String = FormFGWHAllocDet.id_fg_wh_alloc
                            Dim id_product As String = GVData.GetRowCellValue(l, "id_product").ToString
                            Dim id_wh_drawer_to As String = GVData.GetRowCellValue(l, "id_wh_drawer_to").ToString
                            Dim fg_wh_alloc_det_qty As String = decimalSQL(GVData.GetRowCellValue(l, "Qty").ToString)

                            If l_i > 0 Then
                                query_ins += ", "
                            End If
                            query_ins += "('" + id_fg_wh_alloc + "', '" + id_product + "', '" + id_wh_drawer_to + "', '" + fg_wh_alloc_det_qty + "') "
                            l_i += 1
                            PBC.PerformStep()
                            PBC.Update()
                        Next
                        If l_i > 0 Then
                            execute_non_query(query_ins, True, "", "", "", "")
                        End If
                        FormFGWHAllocDet.viewDetail()
                        Close()
                        Cursor = Cursors.Default
                    Else
                        stopCustom("There is no data for import process, please make sure your input !")
                        makeSafeGV(GVData)
                    End If
                End If
            ElseIf id_pop_up = "21" Then
                'generate SO
                Dim confirm As DialogResult = DevExpress.XtraEditors.XtraMessageBox.Show("Please make sure :" + System.Environment.NewLine + "- Only 'OK' status will continue to next step." + System.Environment.NewLine + "- If this report is an important, please click 'No' button, and then click 'Print' button to export to multiple formats provided." + System.Environment.NewLine + "Are you sure you want to continue this process?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
                If confirm = Windows.Forms.DialogResult.Yes Then
                    makeSafeGV(GVData)
                    GVData.ActiveFilterString = "[Status] = 'OK'"
                    If GVData.RowCount > 0 Then
                        Cursor = Cursors.WaitCursor
                        'del
                        Dim query_del As String = "DELETE FROM tb_sales_order_gen_det WHERE id_sales_order_gen='" + FormSalesOrderGen.id_sales_order_gen + "' "
                        execute_non_query(query_del, True, "", "", "", "")

                        'ins
                        Dim l_i As Integer = 0
                        Dim query_ins As String = "INSERT INTO tb_sales_order_gen_det(id_sales_order_gen, id_product, id_comp_contact_from, id_comp_contact_to, sales_order_gen_det_qty) VALUES "
                        For l As Integer = 0 To ((GVData.RowCount - 1) - GetGroupRowCount(GVData))
                            Dim id_sales_order_gen As String = FormSalesOrderGen.id_sales_order_gen
                            Dim id_product As String = GVData.GetRowCellValue(l, "id_product").ToString
                            Dim id_comp_contact_from As String = GVData.GetRowCellValue(l, "id_comp_contact_from").ToString
                            Dim id_comp_contact_to As String = GVData.GetRowCellValue(l, "id_comp_contact_to").ToString
                            Dim sales_order_gen_det_qty As String = decimalSQL(GVData.GetRowCellValue(l, "Qty").ToString)

                            If l_i > 0 Then
                                query_ins += ", "
                            End If
                            query_ins += "('" + id_sales_order_gen + "', '" + id_product + "', '" + id_comp_contact_from + "', '" + id_comp_contact_to + "', '" + sales_order_gen_det_qty + "') "
                            l_i += 1
                            PBC.PerformStep()
                            PBC.Update()
                        Next
                        If l_i > 0 Then
                            execute_non_query(query_ins, True, "", "", "", "")
                        End If
                        FormSalesOrderGen.viewDetail()
                        Close()
                        Cursor = Cursors.Default
                    Else
                        stopCustom("There is no data for import process, please make sure your input !")
                        makeSafeGV(GVData)
                    End If
                End If
            ElseIf id_pop_up = "22" Then
                'sample Return Internal sale
                Dim confirm As DialogResult = DevExpress.XtraEditors.XtraMessageBox.Show("Please note :" + System.Environment.NewLine + "- Only 'OK' status will continue to next step." + System.Environment.NewLine + "- If this report important, please click 'No' button, and then click 'Print' button to export to multiple formats provided." + System.Environment.NewLine + "Are you sure you want to continue this process?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
                If confirm = Windows.Forms.DialogResult.Yes Then
                    makeSafeGV(GVData)
                    GVData.ActiveFilterString = "[Status] = 'OK'"
                    If GVData.RowCount > 0 Then
                        Cursor = Cursors.WaitCursor
                        'ins
                        For l As Integer = 0 To ((GVData.RowCount - 1) - GetGroupRowCount(GVData))
                            Dim newRow As DataRow = (TryCast(FormSampleReturnPLDet.GCItemList.DataSource, DataTable)).NewRow()
                            newRow("id_sample_pl_det") = "0"
                            newRow("id_sample") = GVData.GetRowCellValue(l, "id_sample").ToString
                            newRow("id_sample_price") = GVData.GetRowCellValue(l, "id_cost").ToString
                            newRow("sample_price") = GVData.GetRowCellValue(l, "cost")
                            newRow("id_sample_ret_price") = GVData.GetRowCellValue(l, "id_price").ToString
                            newRow("sample_ret_price") = GVData.GetRowCellValue(l, "price")
                            newRow("code") = GVData.GetRowCellValue(l, "Code").ToString
                            newRow("code_us") = GVData.GetRowCellValue(l, "code_us").ToString
                            newRow("name") = GVData.GetRowCellValue(l, "Description").ToString
                            newRow("size") = GVData.GetRowCellValue(l, "Size").ToString
                            newRow("color") = GVData.GetRowCellValue(l, "Color").ToString
                            newRow("class") = GVData.GetRowCellValue(l, "Class").ToString
                            newRow("id_season") = GVData.GetRowCellValue(l, "id_season").ToString
                            newRow("season") = GVData.GetRowCellValue(l, "season").ToString
                            newRow("id_season_orign") = GVData.GetRowCellValue(l, "id_season_orign").ToString
                            newRow("season_orign") = GVData.GetRowCellValue(l, "season_orign").ToString
                            newRow("sample_pl_det_qty") = GVData.GetRowCellValue(l, "Qty").ToString
                            TryCast(FormSampleReturnPLDet.GCItemList.DataSource, DataTable).Rows.Add(newRow)
                            FormSampleReturnPLDet.GCItemList.RefreshDataSource()
                            FormSampleReturnPLDet.GVItemList.RefreshData()
                            '
                            PBC.PerformStep()
                            PBC.Update()
                        Next
                        FormSampleReturnPLDet.BtnSave.Focus()
                        Close()
                        Cursor = Cursors.Default
                    Else
                        stopCustom("There is no data for import process, please make sure your input !")
                        makeSafeGV(GVData)
                    End If
                End If
            ElseIf id_pop_up = "23" Then
                'generate SO new
                Dim confirm As DialogResult = DevExpress.XtraEditors.XtraMessageBox.Show("Please make sure :" + System.Environment.NewLine + "- Only 'OK' status will continue to next step." + System.Environment.NewLine + "- If this report is an important, please click 'No' button, and then click 'Print' button to export to multiple formats provided." + System.Environment.NewLine + "Are you sure you want to continue this process?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
                If confirm = Windows.Forms.DialogResult.Yes Then
                    makeSafeGV(GVData)
                    GVData.ActiveFilterString = "[Status] = 'OK'"
                    If GVData.RowCount > 0 Then
                        Cursor = Cursors.WaitCursor
                        'del
                        Dim query_del As String = "DELETE FROM tb_sales_order_gen_det WHERE id_sales_order_gen='" + FormSalesOrderGen.id_sales_order_gen + "' "
                        execute_non_query(query_del, True, "", "", "", "")

                        'ins
                        Dim l_i As Integer = 0
                        Dim query_ins As String = "INSERT INTO tb_sales_order_gen_det(id_sales_order_gen, id_product, id_comp_contact_from, id_comp_contact_to, sales_order_gen_det_qty) VALUES "
                        For l As Integer = 0 To ((GVData.RowCount - 1) - GetGroupRowCount(GVData))
                            Dim id_sales_order_gen As String = FormSalesOrderGen.id_sales_order_gen
                            Dim id_product As String = GVData.GetRowCellValue(l, "id_product").ToString
                            Dim id_comp_contact_from As String = GVData.GetRowCellValue(l, "id_comp_contact_from").ToString
                            Dim id_comp_contact_to As String = GVData.GetRowCellValue(l, "id_comp_contact_to").ToString
                            Dim sales_order_gen_det_qty As String = decimalSQL(GVData.GetRowCellValue(l, "Qty").ToString)

                            If l_i > 0 Then
                                query_ins += ", "
                            End If
                            query_ins += "('" + id_sales_order_gen + "', '" + id_product + "', '" + id_comp_contact_from + "', '" + id_comp_contact_to + "', '" + sales_order_gen_det_qty + "') "
                            l_i += 1
                            PBC.PerformStep()
                            PBC.Update()
                        Next
                        If l_i > 0 Then
                            execute_non_query(query_ins, True, "", "", "", "")
                        End If
                        FormSalesOrderGen.viewDetail()
                        Close()
                        Cursor = Cursors.Default
                    Else
                        stopCustom("There is no data for import process, please make sure your input !")
                        makeSafeGV(GVData)
                    End If
                End If
            ElseIf id_pop_up = "26" Then
                If GVData.RowCount > 0 Then
                    PBC.Properties.Minimum = 0
                    PBC.Properties.Maximum = GVData.RowCount - 1
                    PBC.Properties.Step = 1
                    PBC.Properties.PercentView = True

                    Dim bulk_query As String = ""
                    Dim id_acc_fak_scan As String = FormAccountingFakturScanSingle.id_acc_fak_scan

                    Dim del_query As String = "DELETE FROM tb_a_acc_fak_scan_fk_det WHERE id_acc_fak_scan='" + id_acc_fak_scan + "'"
                    execute_non_query(del_query, True, "", "", "", "")

                    bulk_query = "INSERT INTO tb_a_acc_fak_scan_fk_det(id_acc_fak_scan, kd_jenis_transaksi, fg_pengganti, nomor_faktur, masa_pajak, tahun_pajak, tanggal_faktur, npwp, nama, alamat_lengkap, jumlah_dpp, jumlah_ppn, jumlah_ppnbm, id_keterangan_tambahan, fg_uang_muka, uang_muka_dpp, uang_muka_ppn, uang_muka_ppnbm, referensi, of, kode_objek, nama3, harga_satuan, jumlah_barang, harga_total, diskon, dpp, ppn, tarif_ppnbm, ppnbm) VALUES "
                    For i As Integer = 0 To (GVData.RowCount - 1)
                        'number
                        Dim harga_total As Decimal = GVData.GetRowCellValue(i, "harga_total").ToString
                        Dim diskon As Decimal = GVData.GetRowCellValue(i, "diskon").ToString
                        Dim ppn As String = GVData.GetRowCellValue(i, "ppn").ToString
                        Dim dpp As String = GVData.GetRowCellValue(i, "dpp").ToString
                        Dim jumlah_ppn As String = GVData.GetRowCellValue(i, "jumlah_ppn").ToString
                        Dim jumlah_dpp As String = GVData.GetRowCellValue(i, "jumlah_dpp").ToString

                        'no faktur
                        Dim no_faktur_ori As String = GVData.GetRowCellValue(i, "no_faktur").ToString
                        Dim col_foc_str As String() = Split(no_faktur_ori, ".")
                        Dim kd_jenis_transaksi As String = col_foc_str(0).Substring(0, 2).ToString
                        Dim fg_pengganti As String = col_foc_str(0).Substring(2, 1)
                        Dim no_faktur As String = col_foc_str(1).Replace("-", "").Replace(".", "") + col_foc_str(2).ToString

                        'query
                        bulk_query += "('" + id_acc_fak_scan + "','" + kd_jenis_transaksi + "','" + fg_pengganti + "','" + addSlashes(no_faktur) + "','" + FormAccountingFakturScanSingle.TxtPeriod.Text + "','" + FormAccountingFakturScanSingle.TxtYear.Text + "', '" + FormAccountingFakturScanSingle.TxtFakturDate.Text + "', '" + addSlashes(GVData.GetRowCellValue(i, "npwp").Replace(".", "").Replace("-", "")) + "', '" + addSlashes(GVData.GetRowCellValue(i, "nama_toko").ToString) + "', '" + addSlashes(GVData.GetRowCellValue(i, "alamat").ToString) + "', '" + decimalSQL(jumlah_dpp.ToString) + "', '" + decimalSQL(jumlah_ppn.ToString) + "', '0', '" + addSlashes(GVData.GetRowCellValue(i, "id_keterangan_tambahan").ToString) + "','0','0', '0', '0', '" + addSlashes(GVData.GetRowCellValue(i, "referensi").ToString) + "', 'OF', '" + addSlashes(GVData.GetRowCellValue(i, "kode_barang").ToString) + "', '" + addSlashes(GVData.GetRowCellValue(i, "ket_barang").ToString) + "', '" + decimalSQL(GVData.GetRowCellValue(i, "harga_satuan").ToString) + "', '" + decimalSQL(GVData.GetRowCellValue(i, "jumlah_barang").ToString) + "', '" + decimalSQL(GVData.GetRowCellValue(i, "harga_total").ToString) + "', '" + decimalSQL(GVData.GetRowCellValue(i, "diskon").ToString) + "', '" + decimalSQL(dpp.ToString) + "', '" + decimalSQL(ppn.ToString) + "', '0', '0') "
                        If Not i = GVData.RowCount - 1 Then
                            bulk_query += ","
                        End If
                        PBC.PerformStep()
                        PBC.Update()
                    Next

                    execute_non_query(bulk_query, True, "", "", "", "")
                    FormAccountingFakturScanSingle.viewDetail()
                    Close()
                Else
                    stopCustom("No data available.")
                End If
            ElseIf id_pop_up = "27" Then 'import holiday
                If GVData.RowCount > 0 Then
                    PBC.Properties.Minimum = 0
                    PBC.Properties.Maximum = GVData.RowCount - 1
                    PBC.Properties.Step = 1
                    PBC.Properties.PercentView = True
                    '
                    For i As Integer = 0 To GVData.RowCount - 1
                        Dim date_var As Date = GVData.GetRowCellValue(i, "Date")
                        '
                        Dim query_del As String = "DELETE FROM tb_emp_holiday WHERE emp_holiday_date='" & Date.Parse(date_var.ToString).ToString("yyyy-MM-dd") & "' AND id_religion='" & GVData.GetRowCellValue(i, "IdReligion").ToString & "'"
                        execute_non_query(query_del, True, "", "", "", "")
                        '
                        Dim query_exec As String = "INSERT INTO tb_emp_holiday(id_religion,emp_holiday_date,emp_holiday_desc) VALUES('" & GVData.GetRowCellValue(i, "IdReligion").ToString & "','" & Date.Parse(date_var.ToString).ToString("yyyy-MM-dd") & "','" & GVData.GetRowCellValue(i, "Description").ToString & "')"
                        execute_non_query(query_exec, True, "", "", "", "")
                        '
                        PBC.PerformStep()
                        PBC.Update()
                    Next
                    Close()
                Else
                    stopCustom("No data available.")
                End If
            ElseIf id_pop_up = "28" Then 'import UPC
                GVData.ActiveFilterString = "[IdProduct] <> '0' AND [UPC] <> ''"
                If GVData.RowCount > 0 Then
                    PBC.Properties.Minimum = 0
                    PBC.Properties.Maximum = GVData.RowCount - 1
                    PBC.Properties.Step = 1
                    PBC.Properties.PercentView = True
                    '
                    For i As Integer = 0 To GVData.RowCount - 1
                        If Not GVData.GetRowCellValue(i, "IdProduct").ToString = "0" And Not GVData.GetRowCellValue(i, "UPC").ToString = "" Then
                            Dim query_exec As String = "UPDATE tb_m_product SET product_ean_code='" & GVData.GetRowCellValue(i, "UPC").ToString & "' WHERE id_product='" & GVData.GetRowCellValue(i, "IdProduct").ToString & "'"
                            execute_non_query(query_exec, True, "", "", "", "")
                        End If
                        '
                        PBC.PerformStep()
                        PBC.Update()
                    Next
                    Close()
                Else
                    stopCustom("No data available.")
                End If
            ElseIf id_pop_up = "29" Then
                Dim confirm As DialogResult = DevExpress.XtraEditors.XtraMessageBox.Show("Please make sure :" + System.Environment.NewLine + "- Only 'OK' status will include in order list." + System.Environment.NewLine + "- If this report is an important, please click 'No' button, and then click 'Print' button to export to multiple formats provided." + System.Environment.NewLine + "Are you sure you want to continue this process?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
                If confirm = Windows.Forms.DialogResult.Yes Then
                    makeSafeGV(GVData)
                    GVData.ActiveFilterString = "[Status] = 'OK'"
                    If GVData.RowCount > 0 Then
                        FormSalesReturnOrderDet.delNotFoundMyRow()
                        For i As Integer = 0 To GVData.RowCount - 1
                            Dim newRow As DataRow = (TryCast(FormSalesReturnOrderDet.GCItemList.DataSource, DataTable)).NewRow()
                            newRow("id_sales_return_order_det") = "0"
                            newRow("name") = GVData.GetRowCellValue(i, "Style").ToString
                            newRow("code") = GVData.GetRowCellValue(i, "Code").ToString
                            newRow("size") = GVData.GetRowCellValue(i, "Size").ToString
                            newRow("sales_return_order_det_qty") = GVData.GetRowCellValue(i, "Qty")
                            newRow("qty_avail") = GVData.GetRowCellValue(i, "SOH")
                            newRow("design_price_type") = ""
                            newRow("id_design_price") = GVData.GetRowCellValue(i, "id_design_price_retail").ToString
                            newRow("design_price") = GVData.GetRowCellValue(i, "Price")
                            newRow("id_return_cat") = "1"
                            newRow("return_cat") = "Return"
                            newRow("amount") = GVData.GetRowCellValue(i, "Amount")
                            newRow("sales_return_order_det_note") = ""
                            newRow("id_design") = GVData.GetRowCellValue(i, "id_design").ToString
                            newRow("id_product") = GVData.GetRowCellValue(i, "id_product").ToString
                            newRow("id_sample") = "0"
                            TryCast(FormSalesReturnOrderDet.GCItemList.DataSource, DataTable).Rows.Add(newRow)
                            FormSalesReturnOrderDet.GCItemList.RefreshDataSource()
                            FormSalesReturnOrderDet.GVItemList.RefreshData()
                            PBC.PerformStep()
                            PBC.Update()
                        Next
                        FormSalesReturnOrderDet.GVItemList.OptionsBehavior.AutoExpandAllGroups = True
                        FormSalesReturnOrderDet.check_but()
                        Close()
                    Else
                        stopCustom("There is no data for import process, please make sure your input !")
                        makeSafeGV(GVData)
                    End If
                End If
            ElseIf id_pop_up = "30" Then
                Dim confirm As DialogResult = DevExpress.XtraEditors.XtraMessageBox.Show("Are you sure want to import this " & GVData.RowCount.ToString & " data ? ", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
                If confirm = Windows.Forms.DialogResult.Yes Then
                    PBC.Properties.Minimum = 0
                    PBC.Properties.Maximum = GVData.RowCount - 1
                    PBC.Properties.Step = 1
                    PBC.Properties.PercentView = True
                    '
                    For i As Integer = 0 To GVData.RowCount - 1
                        If Not GVData.GetRowCellValue(i, "IdPO").ToString = "0" Then
                            Dim date_ls_string As String = ""
                            If Not GVData.GetRowCellValue(i, "ls_date").ToString() = "" Then
                                date_ls_string = DateTime.Parse(GVData.GetRowCellValue(i, "ls_date").ToString()).ToString("yyyy-MM-dd")
                            End If

                            Dim query_exec As String = "UPDATE tb_prod_order SET 
                                                        po_lama_no='" & GVData.GetRowCellValue(i, "POOldSistem").ToString & "',
                                                        hs_code='" & GVData.GetRowCellValue(i, "hs_code").ToString & "',
                                                        aju_no='" & GVData.GetRowCellValue(i, "AjuNumber").ToString & "',
                                                        pib_no='" & GVData.GetRowCellValue(i, "PibNumber").ToString & "', 
                                                        pib_date='" & DateTime.Parse(GVData.GetRowCellValue(i, "PibDate").ToString()).ToString("yyyy-MM-dd") & "', 
                                                        duty_percent='" & decimalSQL(GVData.GetRowCellValue(i, "Duty").ToString) & "', 
                                                        duty_royalty='" & decimalSQL(GVData.GetRowCellValue(i, "Royalty").ToString) & "', 
                                                        duty_sales_vat='" & decimalSQL(GVData.GetRowCellValue(i, "SalesVat").ToString) & "', 
                                                        duty_pph='" & decimalSQL(GVData.GetRowCellValue(i, "SalesPPH").ToString) & "', 
                                                        duty_store_disc='" & decimalSQL(GVData.GetRowCellValue(i, "StoreDiscount").ToString) & "', 
                                                        duty_sales_thru='" & decimalSQL(GVData.GetRowCellValue(i, "SalesThru").ToString) & "',
                                                        duty_is_pr_proposed='" & GVData.GetRowCellValue(i, "id_isPR").ToString & "',
                                                        duty_is_pay='" & GVData.GetRowCellValue(i, "id_isPay").ToString & "',
                                                        country_source='" & GVData.GetRowCellValue(i, "Source").ToString & "',
                                                        dest_port='" & GVData.GetRowCellValue(i, "DestPort").ToString & "',
                                                        ppjk='" & GVData.GetRowCellValue(i, "ppjk").ToString & "',
                                                        ppjk_inv_no='" & GVData.GetRowCellValue(i, "ppjk_inv").ToString & "',
                                                        pib_volume='" & decimalSQL(GVData.GetRowCellValue(i, "volume").ToString) & "',
                                                        pib_uom='" & GVData.GetRowCellValue(i, "uom").ToString & "',
                                                        cif='" & decimalSQL(GVData.GetRowCellValue(i, "cif").ToString) & "',
                                                        ls_no='" & GVData.GetRowCellValue(i, "ls_no").ToString & "',
                                                        ls_date='" & date_ls_string & "',
                                                        coo_no='" & GVData.GetRowCellValue(i, "coo").ToString & "',
                                                        pib_kurs='" & decimalSQL(GVData.GetRowCellValue(i, "kurs").ToString) & "',
                                                        pib_id_currency='" & GVData.GetRowCellValue(i, "id_currency").ToString & "',
                                                        freight_usd='" & decimalSQL(GVData.GetRowCellValue(i, "freight_usd").ToString) & "',
                                                        penalty_percent='" & decimalSQL(GVData.GetRowCellValue(i, "penalty_percent").ToString) & "',
                                                        act_sales_qty='" & decimalSQL(GVData.GetRowCellValue(i, "sales_actual_qty").ToString) & "'
                                                        WHERE id_prod_order='" & GVData.GetRowCellValue(i, "IdPO").ToString & "'"
                            execute_non_query(query_exec, True, "", "", "", "")
                        End If
                        '
                        PBC.PerformStep()
                        PBC.Update()
                    Next
                    infoCustom("Import Success")
                    FormProdDuty.view_production_order()
                    Close()
                End If
            ElseIf id_pop_up = "31" Then
                'uniform budget
                Dim confirm As DialogResult = DevExpress.XtraEditors.XtraMessageBox.Show("Please make sure :" + System.Environment.NewLine + "- Only 'OK' status will continue to next step." + System.Environment.NewLine + "- If this report is an important, please click 'No' button, and then click 'Print' button to export to multiple formats provided." + System.Environment.NewLine + "Are you sure you want to continue this process?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
                If confirm = Windows.Forms.DialogResult.Yes Then
                    makeSafeGV(GVData)
                    GVData.ActiveFilterString = "[Status] = 'OK'"
                    If GVData.RowCount > 0 Then
                        Cursor = Cursors.WaitCursor
                        'del
                        Dim id_emp_uni_period As String = FormEmpUniPeriodDet.id_emp_uni_period
                        Dim query_del As String = "DELETE FROM tb_emp_uni_budget WHERE id_emp_uni_budget IN (
	                    SELECT * FROM (
		                    SELECT b.id_emp_uni_budget FROM tb_emp_uni_budget b
		                    LEFT JOIN tb_sales_order so ON so.id_emp_uni_budget = b.id_emp_uni_budget
		                    WHERE b.id_emp_uni_period=" + id_emp_uni_period + " AND ISNULL(so.id_emp_uni_budget)
	                    ) AS p
) "
                        execute_non_query(query_del, True, "", "", "", "")

                        'ins
                        Dim l_i As Integer = 0
                        Dim query_ins As String = "INSERT INTO tb_emp_uni_budget(id_emp_uni_period, id_employee, budget) VALUES "
                        For l As Integer = 0 To ((GVData.RowCount - 1) - GetGroupRowCount(GVData))
                            Dim id_employee As String = GVData.GetRowCellValue(l, "IdEmp").ToString
                            Dim budget As String = decimalSQL(GVData.GetRowCellValue(l, "Budget").ToString)

                            If l_i > 0 Then
                                query_ins += ", "
                            End If
                            query_ins += "('" + id_emp_uni_period + "', '" + id_employee + "', '" + budget + "') "
                            l_i += 1
                            PBC.PerformStep()
                            PBC.Update()
                        Next
                        If l_i > 0 Then
                            execute_non_query(query_ins, True, "", "", "", "")
                        End If
                        FormEmpUniPeriodDet.viewDetail()
                        Close()
                        Cursor = Cursors.Default
                    Else
                        stopCustom("There is no data for import process, please make sure your input !")
                        makeSafeGV(GVData)
                    End If
                End If
            End If
        End If
        Cursor = Cursors.Default
    End Sub



    Private Sub BtnPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnPrint.Click
        Cursor = Cursors.WaitCursor
        print(GCData, "List Import Excel")
        Cursor = Cursors.Default
    End Sub

    Private Sub GVData_ValidatingEditor(sender As Object, e As DevExpress.XtraEditors.Controls.BaseContainerValidateEditorEventArgs) Handles GVData.ValidatingEditor
        Dim view As DevExpress.XtraGrid.Views.Grid.GridView = TryCast(sender, DevExpress.XtraGrid.Views.Grid.GridView)
        Dim currentDataView As DataView = TryCast(TryCast(sender, DevExpress.XtraGrid.Views.Grid.GridView).DataSource, DataView)
        If view.FocusedColumn.FieldName = "Code" Then
            'check duplicate code
            Dim currentCode As String = e.Value.ToString()
            For i As Integer = 0 To currentDataView.Count - 1
                If i <> view.GetDataSourceRowIndex(view.FocusedRowHandle) Then
                    If currentDataView(i)("Code").ToString() = currentCode Then
                        MsgBox("Duplicate Code detected.")
                        e.ErrorText = "Duplicate Code detected."
                        e.Valid = False
                        Exit For
                    End If
                End If
            Next
        End If
    End Sub

    Private Sub FormImportExcel_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        WindowState = FormWindowState.Maximized
        If id_pop_up = "6" Or id_pop_up = "18" Then
            TBFileAddress.Text = My.Application.Info.DirectoryPath.ToString & "\import\sales_pos.xlsx"
            fill_combo_worksheet()
        End If
    End Sub
End Class