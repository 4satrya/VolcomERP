Public Class FormDesignColumnMapping
    Public edited As Boolean = False

    Private Sub FormDesignColumnMapping_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        view_template()

        view_division()

        view_season()

        load_form()
    End Sub

    Sub view_template()
        viewSearchLookupQuery(SLUEStore, "SELECT id_design_column_type, column_type FROM tb_design_column_type", "id_design_column_type", "column_type", "id_design_column_type")
    End Sub

    Sub load_form()
        'col
        Dim cols As DataTable = execute_query("
            SELECT alias_name AS column_name FROM tb_design_column_additional
            UNION ALL
            SELECT 'Spesifikasi' AS column_name
            UNION ALL
            SELECT column_name FROM tb_design_column WHERE id_design_column_category = 1
        ", -1, True, "", "", "", "")

        GCCol.DataSource = cols

        GVCol.BestFitColumns()

        GVDesign.Columns.Clear()
        GCDesign.DataSource = Nothing

        'column
        GVColumn.Columns.Clear()

        Dim column As DataTable = execute_query("
            SELECT cl.id_design_column_list, cl.column_list, cm.column_mapping
            FROM tb_design_column_list AS cl
            LEFT JOIN (
	            SELECT cm.id_design_column_list, cm.column_mapping
	            FROM tb_design_column_mapping AS cm
	            LEFT JOIN tb_design_column_list AS cl ON cm.id_design_column_list = cl.id_design_column_list
	            WHERE cl.id_design_column_type = " + SLUEStore.EditValue.ToString + "
            ) AS cm ON cl.id_design_column_list = cm.id_design_column_list
            WHERE cl.id_design_column_type = " + SLUEStore.EditValue.ToString + "
            ORDER BY cl.sort ASC, cl.id_design_column_list ASC
        ", -1, True, "", "", "", "")

        Dim data As DataTable = New DataTable

        For i = 0 To column.Rows.Count - 1
            Dim id_design_column_list As String = column.Rows(i)("id_design_column_list").ToString
            Dim column_list As String = column.Rows(i)("column_list").ToString

            data.Columns.Add(column_list.Replace(" ", ""), GetType(String))

            Dim col As DevExpress.XtraGrid.Columns.GridColumn = New DevExpress.XtraGrid.Columns.GridColumn

            col.Caption = column_list
            col.FieldName = column_list.Replace(" ", "")
            col.Tag = id_design_column_list
            col.MinWidth = 200
            col.ColumnEdit = RepositoryItemMemoEdit
            col.Visible = True

            GVColumn.Columns.Add(col)
        Next

        Dim row As DataRow = data.NewRow

        For i = 0 To column.Rows.Count - 1
            Dim column_name As String = column.Rows(i)("column_list").ToString

            row(column_name.Replace(" ", "")) = column.Rows(i)("column_mapping").ToString
        Next

        data.Rows.Add(row)

        GCColumn.DataSource = data

        GVColumn.BestFitColumns()
    End Sub

    Private Sub FormDesignColumnMapping_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Function generate_column(id_store As String) As DataTable
        'select
        Dim q_select As String = ""

        Dim data_column As DataTable = execute_query("
            SELECT cl.column_list, cm.column_mapping
            FROM tb_design_column_list AS cl
            LEFT JOIN (
	            SELECT cm.id_design_column_list, cm.column_mapping
	            FROM tb_design_column_mapping AS cm
	            LEFT JOIN tb_design_column_list AS cl ON cm.id_design_column_list = cl.id_design_column_list
	            WHERE cl.id_design_column_type = " + id_store + "
            ) AS cm ON cl.id_design_column_list = cm.id_design_column_list
            WHERE cl.id_design_column_type = " + id_store + "
            ORDER BY cl.sort ASC, cl.id_design_column_list ASC
        ", -1, True, "", "", "", "")

        For i = 0 To data_column.Rows.Count - 1
            Dim q_concat As String = "CONCAT("

            'split value by line
            Dim value As String = data_column.Rows(i)("column_mapping").ToString

            value = value.Replace(vbCr, "")

            Dim s_line() As String = value.Split(vbLf)

            For j = 0 To s_line.Count - 1
                'list all string
                Dim l_list_all As List(Of String) = New List(Of String)

                'split by string
                Dim matched As System.Text.RegularExpressions.MatchCollection = System.Text.RegularExpressions.Regex.Matches(s_line(j), "(.)")

                'combine `column`
                Dim is_new_line As Boolean = True

                For k = 0 To matched.Count - 1
                    Dim vchar As String = matched(k).Value

                    If is_new_line Then
                        l_list_all.Add(vchar)
                    Else
                        l_list_all(l_list_all.Count - 1) += vchar
                    End If

                    If vchar = "`" Then
                        If is_new_line Then
                            is_new_line = False
                        Else
                            is_new_line = True
                        End If
                    End If
                Next

                'build concat
                For k = 0 To l_list_all.Count - 1
                    If l_list_all(k).Contains("`") Then
                        q_concat += "IFNULL(" + l_list_all(k) + ", ''), "
                    Else
                        q_concat += "'" + l_list_all(k) + "', "
                    End If
                Next

                If j < (s_line.Count - 1) Then
                    q_concat += "'\n', "
                End If
            Next

            q_concat = If(q_concat = "CONCAT(", "CONCAT(''", q_concat.Substring(0, q_concat.Length - 2)) + ") AS `" + data_column.Rows(i)("column_list").ToString + "`"

            q_select += q_concat + ", "
        Next

        Dim data As DataTable = New DataTable

        If Not q_select = "" Then
            'query
            Dim query As String = "CALL view_all_design_mapping(" + SLUEStore.EditValue.ToString + ", """ + q_select.Substring(0, q_select.Length - 2) + """, " + SLUESeason.EditValue.ToString + ", " + SLUEDivision.EditValue.ToString + ")"

            data = execute_query(query, -1, True, "", "", "", "")

            If data.Rows.Count > 0 Then
                'remove blank
                For i = 0 To data.Rows.Count - 1
                    For j = 0 To data.Columns.Count - 1
                        If Not data.Columns(j).ColumnName.ToString = "id_design" And Not data.Columns(j).ColumnName.ToString = "id_product" Then
                            Dim value() As String = data.Rows(i)(data.Columns(j)).ToString.Split(vbLf)

                            Dim new_value As List(Of String) = New List(Of String)

                            For k = 0 To value.Count - 1
                                If Not value(k).ToString = "" Then
                                    new_value.Add(value(k).ToString)
                                End If
                            Next

                            data.Rows(i)(data.Columns(j)) = ""

                            For k = 0 To new_value.Count - 1
                                data.Rows(i)(data.Columns(j)) += new_value(k).ToString

                                If k < (new_value.Count - 1) Then
                                    data.Rows(i)(data.Columns(j)) += vbLf
                                End If
                            Next
                        End If
                    Next
                Next

                data.Columns.Remove(data.Columns("id_design"))
                data.Columns.Remove(data.Columns("id_product"))
            End If
        End If

        Return data
    End Function

    Private Sub GVCol_DoubleClick(sender As Object, e As EventArgs) Handles GVCol.DoubleClick
        Dim value As String = GVColumn.GetFocusedRowCellValue(GVColumn.FocusedColumn) + "`" + GVCol.GetFocusedRowCellValue("column_name").ToString + "`"

        GVColumn.SetFocusedRowCellValue(GVColumn.FocusedColumn, value)

        edited = True
    End Sub

    Private Sub SLUEStore_EditValueChanged(sender As Object, e As EventArgs) Handles SLUEStore.EditValueChanged
        load_form()
    End Sub

    Private Sub SBAdd_Click(sender As Object, e As EventArgs) Handles SBAdd.Click
        If Not TEAdd.Text = "" Then
            'check duplicate
            Dim is_duplicate As Boolean = False

            For i = 0 To GVColumn.Columns.Count - 1
                If GVColumn.Columns(i).Caption = TEAdd.EditValue.ToString Then
                    is_duplicate = True
                End If
            Next

            If Not is_duplicate Then
                'column
                Dim col As DevExpress.XtraGrid.Columns.GridColumn = New DevExpress.XtraGrid.Columns.GridColumn

                col.Caption = TEAdd.EditValue.ToString
                col.FieldName = TEAdd.EditValue.ToString.Replace(" ", "")
                col.Tag = "0"
                col.MinWidth = 200
                col.ColumnEdit = RepositoryItemMemoEdit
                col.Visible = True

                GVColumn.Columns.Add(col)

                'datasource
                Dim data As DataTable = GCColumn.DataSource

                data.Columns.Add(TEAdd.EditValue.ToString.Replace(" ", ""), GetType(String))

                GCColumn.DataSource = data

                GVColumn.BestFitColumns()

                TEAdd.EditValue = ""

                edited = True
            Else
                stopCustom("Duplicate column '" + TEAdd.EditValue.ToString + "'")
            End If
        Else
            stopCustom("Please add column name.")
        End If
    End Sub

    Private Sub SBSave_Click(sender As Object, e As EventArgs) Handles SBSave.Click
        Cursor = Cursors.WaitCursor

        Dim in_design_column_list As String = ""

        For i = 0 To GVColumn.Columns.Count - 1
            Dim id_design_column_list As String = GVColumn.Columns(i).Tag.ToString

            If id_design_column_list = "0" Then
                'add column list
                id_design_column_list = execute_query("INSERT INTO tb_design_column_list (id_design_column_type, column_list, sort) VALUES (" + SLUEStore.EditValue.ToString + ", '" + addSlashes(GVColumn.Columns(i).Caption) + "', " + GVColumn.Columns(i).AbsoluteIndex.ToString + "); SELECT LAST_INSERT_ID();", 0, True, "", "", "", "")
            Else
                'update sort
                execute_non_query("UPDATE tb_design_column_list SET sort = " + GVColumn.Columns(i).AbsoluteIndex.ToString + " WHERE id_design_column_list = " + id_design_column_list, True, "", "", "", "")
            End If

            execute_non_query("DELETE FROM tb_design_column_mapping WHERE id_design_column_list = " + id_design_column_list, True, "", "", "", "")

            execute_non_query("INSERT INTO tb_design_column_mapping (id_design_column_list, column_mapping) VALUES (" + id_design_column_list + ", '" + addSlashes(GVColumn.GetRowCellValue(0, GVColumn.Columns(i)).ToString) + "')", True, "", "", "", "")

            in_design_column_list += id_design_column_list + ", "
        Next

        If Not in_design_column_list = "" Then
            execute_non_query("DELETE FROM tb_design_column_list WHERE id_design_column_list NOT IN (" + in_design_column_list.Substring(0, in_design_column_list.Length - 2) + ") AND id_design_column_type = " + SLUEStore.EditValue.ToString, True, "", "", "", "")
        End If

        GVDesign.Columns.Clear()
        GCDesign.DataSource = Nothing

        edited = False

        Cursor = Cursors.Default

        infoCustom("Saved.")
    End Sub

    Private Sub SBDelete_Click(sender As Object, e As EventArgs) Handles SBDelete.Click
        'datasource
        Dim data As DataTable = GCColumn.DataSource

        data.Columns.Remove(GVColumn.FocusedColumn.FieldName)

        GVColumn.Columns.Remove(GVColumn.FocusedColumn)

        GCColumn.DataSource = data

        edited = True
    End Sub

    Private Sub SLUEStore_EditValueChanging(sender As Object, e As DevExpress.XtraEditors.Controls.ChangingEventArgs) Handles SLUEStore.EditValueChanging
        If edited Then
            Dim confirm As DialogResult = DevExpress.XtraEditors.XtraMessageBox.Show("Are you sure want to move and discard changes ?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)

            If confirm = DialogResult.No Then
                e.Cancel = True
            Else
                edited = False
            End If
        End If
    End Sub

    Private Sub SBView_Click(sender As Object, e As EventArgs) Handles SBView.Click
        Cursor = Cursors.WaitCursor

        GVDesign.Columns.Clear()
        GCDesign.DataSource = Nothing

        Dim data As DataTable = generate_column(SLUEStore.EditValue.ToString)

        GCDesign.DataSource = data

        'add memo edit
        For i = 0 To GVDesign.Columns.Count - 1
            GVDesign.Columns(i).Width = 150
            GVDesign.Columns(i).ColumnEdit = RepositoryItemMemoEdit1
        Next

        Cursor = Cursors.Default
    End Sub

    Private Sub SBExportXLSX_Click(sender As Object, e As EventArgs) Handles SBExportXLSX.Click
        If GVDesign.RowCount > 0 Then
            Dim save As SaveFileDialog = New SaveFileDialog

            save.Filter = "Excel File | *.xlsx"
            save.ShowDialog()

            If Not save.FileName = "" Then
                GCDesign.ExportToXlsx(save.FileName)

                infoCustom("File saved.")
            End If
        Else
            stopCustom("No product in the list.")
        End If
    End Sub

    Sub view_season()
        Dim query As String = "
            (SELECT 0 AS id_season, 'ALL' AS season, 0 AS id_range, 'ALL' AS `range`)
            UNION ALL
            (SELECT a.id_season, a.season, b.id_range, b.range
            FROM tb_season a 
            INNER JOIN tb_range b ON a.id_range = b.id_range 
            ORDER BY b.range DESC)
        "
        viewSearchLookupQuery(SLUESeason, query, "id_season", "season", "id_season")
    End Sub

    Sub view_division()
        Dim query As String = "
            (SELECT 0 AS id_code_detail, 'ALL' AS code)
            UNION ALL
            (SELECT id_code_detail, `code`
            FROM tb_m_code_detail
            WHERE id_code = 32
            ORDER BY id_code_detail ASC)
        "

        viewSearchLookupQuery(SLUEDivision, query, "id_code_detail", "code", "id_code_detail")
    End Sub

    Private Sub FormDesignColumnMapping_Activated(sender As Object, e As EventArgs) Handles MyBase.Activated
        FormMain.show_rb(Name)
        checkFormAccess(Name)
        button_main("0", "0", "0")
    End Sub

    Private Sub FormDesignColumnMapping_Deactivate(sender As Object, e As EventArgs) Handles MyBase.Deactivate
        FormMain.hide_rb()
    End Sub

    Private Sub SBEditType_Click(sender As Object, e As EventArgs) Handles SBEditType.Click
        Dim cnt As Boolean = True

        If edited Then
            Dim confirm As DialogResult = DevExpress.XtraEditors.XtraMessageBox.Show("Are you sure want to move and discard changes ?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)

            If confirm = DialogResult.No Then
                cnt = False
            End If
        End If

        If cnt Then
            FormDesignColumnMappingTemplate.id_design_column_type = SLUEStore.EditValue.ToString
            FormDesignColumnMappingTemplate.ShowDialog()
        End If
    End Sub

    Private Sub SBAddType_Click(sender As Object, e As EventArgs) Handles SBAddType.Click
        Dim cnt As Boolean = True

        If edited Then
            Dim confirm As DialogResult = DevExpress.XtraEditors.XtraMessageBox.Show("Are you sure want to move and discard changes ?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)

            If confirm = DialogResult.No Then
                cnt = False
            End If
        End If

        If cnt Then
            FormDesignColumnMappingTemplate.id_design_column_type = "0"
            FormDesignColumnMappingTemplate.ShowDialog()
        End If
    End Sub

    Private Sub RepositoryItemMemoEdit_KeyUp(sender As Object, e As KeyEventArgs) Handles RepositoryItemMemoEdit.KeyUp
        edited = True
    End Sub

    Private Sub GVColumn_ColumnPositionChanged(sender As Object, e As EventArgs) Handles GVColumn.ColumnPositionChanged
        Dim column As DevExpress.XtraGrid.Columns.GridColumn = CType(sender, DevExpress.XtraGrid.Columns.GridColumn)

        GVColumn.Columns(column.FieldName).AbsoluteIndex = column.VisibleIndex

        edited = True
    End Sub
End Class