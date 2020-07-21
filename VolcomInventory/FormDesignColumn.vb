Public Class FormDesignColumn
    Private column_type_front As String = ""
    Private column_type_end As String = ""

    Private Sub FormDesignColumn_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        view_type()

        form_load()
    End Sub

    Sub view_type()
        Dim data_division As DataTable = execute_query("
            SELECT id_code_detail, `code`
            FROM tb_m_code_detail
            WHERE id_code = 32 AND id_code_detail NOT IN (15553, 15624)
            ORDER BY id_code_detail ASC
        ", -1, True, "", "", "", "")

        Dim data_subcategory As DataTable = execute_query("
            SELECT id_code_detail, `code`
            FROM tb_m_code_detail
            WHERE id_code = 31
            ORDER BY id_code_detail ASC
        ", -1, True, "", "", "", "")

        'combine
        Dim data As DataTable = New DataTable

        data.Columns.Add("code", GetType(String))
        data.Columns.Add("id_code_detail_front", GetType(Integer))
        data.Columns.Add("id_code_detail_end", GetType(Integer))

        'add all
        data.Rows.Add(
            "ALL",
            Nothing,
            Nothing
        )

        For i = 0 To data_division.Rows.Count - 1
            For j = 0 To data_subcategory.Rows.Count - 1
                data.Rows.Add(
                    data_division.Rows(i)("code").ToString + " " + data_subcategory.Rows(j)("code").ToString,
                    data_division.Rows(i)("id_code_detail").ToString,
                    data_subcategory.Rows(j)("id_code_detail").ToString()
                )
            Next
        Next

        'load to lookup
        SLUEType.Properties.DataSource = Nothing
        SLUEType.Properties.DataSource = data
        SLUEType.Properties.DisplayMember = "code"
        SLUEType.Properties.ValueMember = "code"
        SLUEType.EditValue = data.Rows(0)("code").ToString
    End Sub

    Private Sub FormDesignColumn_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Sub form_load()
        'clear column
        GVDesignColumn.Columns.Clear()

        Try
            column_type_front = SLUEType.Properties.View.GetFocusedRowCellValue("id_code_detail_front").ToString
            column_type_end = SLUEType.Properties.View.GetFocusedRowCellValue("id_code_detail_end").ToString
        Catch ex As Exception
        End Try

        'get column
        Dim data_column As DataTable = execute_query("
            SELECT tb_design_column.id_design_column, tb_design_column.column_name
            FROM tb_design_column
        ", -1, True, "", "", "", "")

        'get row
        Dim data_row As DataTable = execute_query("
            SELECT tb_design_column_value.id_design_column, tb_design_column.column_name, tb_design_column_value.id_design_column_value, tb_design_column_value.value
            FROM tb_design_column_value
            LEFT JOIN tb_design_column ON tb_design_column_value.id_design_column = tb_design_column.id_design_column
            WHERE tb_design_column_value.column_type_front " + If(column_type_front = "", "IS NULL", "= " + column_type_front) + " AND tb_design_column_value.column_type_end " + If(column_type_end = "", "IS NULL", "= " + column_type_end) + "
        ", -1, True, "", "", "", "")

        If data_row.Rows.Count = 0 Then
            data_row = execute_query("
                SELECT (SELECT MIN(id_design_column) FROM tb_design_column) AS id_design_column, '' AS column_name, '' AS id_design_column_value, '' AS `value`
            ", -1, True, "", "", "", "")
        End If

        'list datatable
        Dim list As List(Of DataTable) = New List(Of DataTable)

        'set list datatable & column to gv
        For i = 0 To data_column.Rows.Count - 1
            'add list datatable
            Dim data_list As DataTable = New DataTable

            list.Add(data_list)

            list(list.Count - 1).Columns.Add(data_column.Rows(i)("column_name").ToString, GetType(String))

            'set column
            Dim gv_column As DevExpress.XtraGrid.Columns.GridColumn = New DevExpress.XtraGrid.Columns.GridColumn

            gv_column.Caption = data_column.Rows(i)("column_name").ToString
            gv_column.FieldName = data_column.Rows(i)("column_name").ToString
            gv_column.Tag = data_column.Rows(i)("id_design_column").ToString
            gv_column.Visible = True

            For j = 0 To data_row.Rows.Count - 1
                If data_column.Rows(i)("id_design_column").ToString = data_row.Rows(j)("id_design_column").ToString Then
                    'add tag value
                    gv_column.Tag = gv_column.Tag + ";" + data_row.Rows(j)("id_design_column_value").ToString

                    'list row
                    list(list.Count - 1).Rows.Add(data_row.Rows(j)("value").ToString)
                End If
            Next

            GVDesignColumn.Columns.Add(gv_column)
        Next

        'combine datatable
        Dim data As DataTable = New DataTable

        'get max row & set column
        Dim max_row As Integer = 0

        For i = 0 To list.Count - 1
            max_row = If(list(i).Rows.Count > max_row, list(i).Rows.Count, max_row)

            data.Columns.Add(list(i).Columns(0).ColumnName, GetType(String))
        Next

        'set row
        For i = 0 To max_row - 1
            Dim row As DataRow = data.NewRow

            For j = 0 To list.Count - 1
                Dim column_name As String = list(j).Columns(0).ColumnName
                Dim value As String = ""

                Try
                    value = list(j).Rows(i)(column_name).ToString()
                Catch ex As Exception
                End Try

                row(column_name) = value
            Next

            data.Rows.Add(row)
        Next

        'set datasource
        GCDesignColumn.DataSource = data

        'set focus
        If GVDesignColumn.Columns.Count > 0 Then
            GVDesignColumn.FocusedColumn = GVDesignColumn.Columns(0)
        End If
    End Sub

    Private Sub SLUEType_EditValueChanged(sender As Object, e As EventArgs) Handles SLUEType.EditValueChanged
        form_load()
    End Sub

    Private Sub BarButtonItemAddValue_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItemAddValue.ItemClick
        Try
            column_type_front = SLUEType.Properties.View.GetFocusedRowCellValue("id_code_detail_front").ToString
            column_type_end = SLUEType.Properties.View.GetFocusedRowCellValue("id_code_detail_end").ToString
        Catch ex As Exception
        End Try

        Try
            FormDesignColumnValue.id_design_column = GVDesignColumn.FocusedColumn.Tag.ToString.Split(";")(0)
            FormDesignColumnValue.column_type_front = column_type_front
            FormDesignColumnValue.column_type_end = column_type_end
            FormDesignColumnValue.ShowDialog()
        Catch ex As Exception
        End Try
    End Sub

    Private Sub BarButtonItemEditValue_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItemEditValue.ItemClick
        Try
            column_type_front = SLUEType.Properties.View.GetFocusedRowCellValue("id_code_detail_front").ToString
            column_type_end = SLUEType.Properties.View.GetFocusedRowCellValue("id_code_detail_end").ToString
        Catch ex As Exception
        End Try

        Try
            If Not GVDesignColumn.GetFocusedRowCellValue(GVDesignColumn.FocusedColumn.FieldName).ToString = "" Then
                FormDesignColumnValue.id_design_column_value = GVDesignColumn.FocusedColumn.Tag.ToString.Split(";")(GVDesignColumn.FocusedRowHandle + 1)
                FormDesignColumnValue.id_design_column = GVDesignColumn.FocusedColumn.Tag.ToString.Split(";")(0)
                FormDesignColumnValue.column_type_front = column_type_front
                FormDesignColumnValue.column_type_end = column_type_end
                FormDesignColumnValue.ShowDialog()
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub BarButtonItemAddColumn_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItemAddColumn.ItemClick
        Try
            FormDesignColumnDet.ShowDialog()
        Catch ex As Exception
        End Try
    End Sub

    Private Sub BarButtonItemEditColumn_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItemEditColumn.ItemClick
        Try
            FormDesignColumnDet.id_design_column = GVDesignColumn.FocusedColumn.Tag.ToString.Split(";")(0)
            FormDesignColumnDet.ShowDialog()
        Catch ex As Exception
        End Try
    End Sub

    Private Sub FormDesignColumn_Activated(sender As Object, e As EventArgs) Handles MyBase.Activated
        FormMain.show_rb(Name)
        checkFormAccess(Name)
        button_main("0", "0", "0")
    End Sub

    Private Sub FormDesignColumn_Deactivate(sender As Object, e As EventArgs) Handles MyBase.Deactivate
        FormMain.hide_rb()
    End Sub
End Class