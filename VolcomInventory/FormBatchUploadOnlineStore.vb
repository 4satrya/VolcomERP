Public Class FormBatchUploadOnlineStore
    Private loaded As Boolean = False

    Private Sub FormBatchUploadOnlineStore_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        view_template()

        view_online_store()
        view_season()
        view_division()

        loaded = True
    End Sub

    Private Sub FormBatchUploadOnlineStore_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub FormBatchUploadOnlineStore_Activated(sender As Object, e As EventArgs) Handles MyBase.Activated
        FormMain.show_rb(Name)
        checkFormAccess(Name)
    End Sub

    Private Sub FormBatchUploadOnlineStore_Deactivate(sender As Object, e As EventArgs) Handles MyBase.Deactivate
        FormMain.hide_rb()
    End Sub

    Sub view_online_store()
        viewSearchLookupQuery(SLUEOnlineStore, "SELECT * FROM tb_design_column_type", "id_design_column_type", "column_type", "id_design_column_type")
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

    Sub view_column()
        If SLUEOnlineStore.EditValue.ToString = "3" Then
            column_vios()
        ElseIf SLUEOnlineStore.EditValue.ToString = "4" Then
            column_zalora()
        ElseIf SLUEOnlineStore.EditValue.ToString = "5" Then
            column_blibli()
        ElseIf SLUEOnlineStore.EditValue.ToString = "8" Then
            column_shopee()
        End If
    End Sub

    Sub column_vios()
        'select
        Dim list_custom As List(Of String) = New List(Of String)

        Dim q_select As String = ""

        Dim data_column As DataTable = execute_query("
            SELECT cl.column_list_1, IF(cf.id_design_column_list_custom_fixed IS NULL, cl.column_mapping, CONCAT('custom_', cf.id_design_column_list_fixed)) AS column_mapping
            FROM tb_design_column_list_fixed AS cl
            LEFT JOIN tb_design_column_list_custom_fixed AS cf ON cl.id_design_column_list_fixed = cf.id_design_column_list_fixed
            WHERE cl.id_design_column_type = " + SLUEOnlineStore.EditValue.ToString + "
            GROUP BY cl.id_design_column_list_fixed
            ORDER BY cl.sort ASC, cl.id_design_column_list_fixed ASC
        ", -1, True, "", "", "", "")

        For i = 0 To data_column.Rows.Count - 1
            Dim value As String = data_column.Rows(i)("column_mapping").ToString

            If value.Contains("custom_") Then
                q_select += value + " AS `" + data_column.Rows(i)("column_list_1").ToString + "`, "

                list_custom.Add(value.Replace("custom_", ""))
            Else
                Dim q_concat As String = "CONCAT("

                'split value by line
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

                q_concat = If(q_concat = "CONCAT(", "CONCAT(''", q_concat.Substring(0, q_concat.Length - 2)) + ") AS `" + data_column.Rows(i)("column_list_1").ToString + "`"

                q_select += q_concat + ", "
            End If
        Next

        Dim data As DataTable = New DataTable

        'add header
        For i = 0 To data_column.Rows.Count - 1
            data.Columns.Add(data_column.Rows(i)("column_list_1").ToString, GetType(String))
        Next

        For x = 1 To 1
            Dim row As DataRow = data.NewRow

            For i = 0 To data_column.Rows.Count - 1
                row(data_column.Rows(i)("column_list_1").ToString) = data_column.Rows(i)("column_list_" + x.ToString).ToString
            Next

            data.Rows.Add(row)
        Next

        'custom column
        For i = 0 To list_custom.Count - 1
            Dim data_custom As DataTable = execute_query("SELECT * FROM tb_design_column_list_custom_fixed WHERE id_design_column_list_fixed = " + list_custom(i), -1, True, "", "", "", "")

            Dim q_custom As String = ""

            For j = 0 To data_custom.Rows.Count - 1
                Dim clm As String = data_custom.Rows(j)("column_check").ToString
                Dim val As String = data_custom.Rows(j)("column_value").ToString
                Dim res As String = data_custom.Rows(j)("column_result").ToString

                If j = 0 Then
                    q_custom = "IF(" + clm + " = '" + val + "', '" + res + "', [false])"
                Else
                    q_custom = q_custom.Replace("[false]", "IF(" + clm + " = '" + val + "', '" + res + "', [false])")
                End If
            Next

            q_custom = q_custom.Replace("[false]", "''")

            q_select = q_select.Replace("custom_" + list_custom(i), q_custom)
        Next

        If Not q_select = "" Then
            'query
            Dim query As String = "CALL view_all_design_mapping(" + SLUEOnlineStore.EditValue.ToString + ", """ + q_select.Substring(0, q_select.Length - 2) + """, " + SLUESeason.EditValue.ToString + ", " + SLUEDivision.EditValue.ToString + ", """ + TEProductCode.EditValue.ToString + """)"

            Dim data_tmp As DataTable = execute_query(query, -1, True, "", "", "", "")

            'remove same
            Dim x As Integer = 0

            For i = 0 To data_tmp.Rows.Count - 1
                data_tmp.Rows(i)("Handle") = data_tmp.Rows(i)("Handle").ToString.ToLower.Replace(" ", "-")
                data_tmp.Rows(i)("Title") = data_tmp.Rows(i)("Title").ToString

                If i > 0 Then
                    If data_tmp.Rows(i)("id_design").ToString <> data_tmp.Rows(i - 1)("id_design").ToString Then
                        x = i
                    End If
                End If

                If x <> i Then
                    For j = 0 To data_tmp.Columns.Count - 1
                        If data_tmp.Columns(j).ColumnName <> "id_design" And data_tmp.Columns(j).ColumnName <> "id_product" And data_tmp.Columns(j).ColumnName <> "Handle" Then
                            If data_tmp.Rows(i)("id_design").ToString = data_tmp.Rows(x)("id_design").ToString And data_tmp.Rows(i)(data_tmp.Columns(j)).ToString = data_tmp.Rows(x)(data_tmp.Columns(j)).ToString Then
                                data_tmp.Rows(i)(data_tmp.Columns(j)) = DBNull.Value
                            End If
                        End If
                    Next
                End If
            Next

            data.Merge(data_tmp)

            If data.Rows.Count > 0 Then
                Dim i As Integer = 0

                'replace enter with new line
                For i = 0 To data.Rows.Count - 1
                    For j = 0 To data.Columns.Count - 1
                        If data.Rows(i)(data.Columns(j)).ToString.Contains("[enter]") Then
                            data.Rows(i)(data.Columns(j)) = data.Rows(i)(data.Columns(j)).ToString.Replace("[enter]", Environment.NewLine)
                        End If
                    Next
                Next

                'build image
                Dim select_id_design As String = ""

                Dim stop_while As Boolean = True

                i = 0

                While stop_while
                    i = i + 1

                    Dim images As String() = data.Rows(i)("Image Src").ToString.Split(",")

                    select_id_design = data.Rows(i)("id_design").ToString

                    Dim get_image As Boolean = False

                    For j = 0 To images.Length - 1
                        Dim image As String = trimSpace(images(j).ToString)

                        If Not image = "" Then
                            If select_id_design = data.Rows(i)("id_design").ToString Then
                                data.Rows(i)("Image Src") = image
                                data.Rows(i)("Image Position") = image.Split("_")(2).Replace(".jpg", "")

                                i = i + 1
                            Else
                                Dim row As DataRow = data.NewRow

                                row("Image Src") = image
                                row("Image Position") = image.Split("_")(2).Replace(".jpg", "")
                                row("Handle") = data.Rows(i - 1)("Handle").ToString

                                data.Rows.InsertAt(row, i)
                            End If

                            get_image = True
                        Else
                            If j = 0 Then
                                data.Rows(i)("Image Src") = ""
                            End If
                        End If
                    Next

                    If get_image Then
                        i = i - 1
                    End If

                    If i = data.Rows.Count - 1 Then
                        stop_while = False
                    End If
                End While

                data.Columns.Remove(data.Columns("id_design"))
                data.Columns.Remove(data.Columns("id_product"))
            End If
        End If

        GCBatchUpload.DataSource = data

        'add memo edit
        For i = 0 To GVBatchUpload.Columns.Count - 1
            GVBatchUpload.Columns(i).Width = 250
            GVBatchUpload.Columns(i).ColumnEdit = RepositoryItemMemoEdit
        Next
    End Sub

    Sub column_zalora()
        'select
        Dim list_custom As List(Of String) = New List(Of String)

        Dim q_select As String = ""

        Dim data_column As DataTable = execute_query("
            SELECT cl.column_list_1, cl.column_list_2, cl.column_list_3, IF(cf.id_design_column_list_custom_fixed IS NULL, cl.column_mapping, CONCAT('custom_', cf.id_design_column_list_fixed)) AS column_mapping
            FROM tb_design_column_list_fixed AS cl
            LEFT JOIN tb_design_column_list_custom_fixed AS cf ON cl.id_design_column_list_fixed = cf.id_design_column_list_fixed
            WHERE cl.id_design_column_type = " + SLUEOnlineStore.EditValue.ToString + "
            GROUP BY cl.id_design_column_list_fixed
            ORDER BY cl.sort ASC, cl.id_design_column_list_fixed ASC
        ", -1, True, "", "", "", "")

        For i = 0 To data_column.Rows.Count - 1
            Dim value As String = data_column.Rows(i)("column_mapping").ToString

            If value.Contains("custom_") Then
                q_select += value + " AS `" + data_column.Rows(i)("column_list_3").ToString + "`, "

                list_custom.Add(value.Replace("custom_", ""))
            Else
                Dim q_concat As String = "CONCAT("

                'split value by line
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

                q_concat = If(q_concat = "CONCAT(", "CONCAT(''", q_concat.Substring(0, q_concat.Length - 2)) + ") AS `" + data_column.Rows(i)("column_list_3").ToString + "`"

                q_select += q_concat + ", "
            End If
        Next

        Dim data As DataTable = New DataTable

        'add header
        For i = 0 To data_column.Rows.Count - 1
            data.Columns.Add(data_column.Rows(i)("column_list_3").ToString, GetType(String))
        Next

        For x = 1 To 3
            Dim row As DataRow = data.NewRow

            For i = 0 To data_column.Rows.Count - 1
                row(data_column.Rows(i)("column_list_3").ToString) = data_column.Rows(i)("column_list_" + x.ToString).ToString
            Next

            data.Rows.Add(row)
        Next

        'custom column
        For i = 0 To list_custom.Count - 1
            Dim data_custom As DataTable = execute_query("SELECT * FROM tb_design_column_list_custom_fixed WHERE id_design_column_list_fixed = " + list_custom(i), -1, True, "", "", "", "")

            Dim q_custom As String = ""

            For j = 0 To data_custom.Rows.Count - 1
                Dim clm As String = data_custom.Rows(j)("column_check").ToString
                Dim val As String = data_custom.Rows(j)("column_value").ToString
                Dim res As String = data_custom.Rows(j)("column_result").ToString

                If j = 0 Then
                    q_custom = "IF(" + clm + " = '" + val + "', '" + res + "', [false])"
                Else
                    q_custom = q_custom.Replace("[false]", "IF(" + clm + " = '" + val + "', '" + res + "', [false])")
                End If
            Next

            q_custom = q_custom.Replace("[false]", "''")

            q_select = q_select.Replace("custom_" + list_custom(i), q_custom)
        Next

        If Not q_select = "" Then
            'query
            Dim query As String = "CALL view_all_design_mapping(" + SLUEOnlineStore.EditValue.ToString + ", """ + q_select.Substring(0, q_select.Length - 2) + """, " + SLUESeason.EditValue.ToString + ", " + SLUEDivision.EditValue.ToString + ", """ + TEProductCode.EditValue.ToString + """)"

            Dim data_tmp As DataTable = execute_query(query, -1, True, "", "", "", "")

            data.Merge(data_tmp)

            If data.Rows.Count > 2 Then
                'replace enter with new line
                For i = 2 To data.Rows.Count - 1
                    For j = 0 To data.Columns.Count - 1
                        If data.Rows(i)(data.Columns(j)).ToString.Contains("[enter]") Then
                            data.Rows(i)(data.Columns(j)) = data.Rows(i)(data.Columns(j)).ToString.Replace("[enter]", Environment.NewLine)
                        End If
                    Next
                Next

                data.Columns.Remove(data.Columns("id_design"))
                data.Columns.Remove(data.Columns("id_product"))
            End If
        End If

        GCBatchUpload.DataSource = data

        'add memo edit
        For i = 0 To GVBatchUpload.Columns.Count - 1
            GVBatchUpload.Columns(i).Width = 250
            GVBatchUpload.Columns(i).ColumnEdit = RepositoryItemMemoEdit
        Next
    End Sub

    Sub column_blibli()
        'select
        Dim list_custom As List(Of String) = New List(Of String)

        Dim q_select As String = ""

        Dim data_column As DataTable = execute_query("
            SELECT cl.column_list_1, cl.column_list_2, IF(cf.id_design_column_list_custom_fixed IS NULL, cl.column_mapping, CONCAT('custom_', cf.id_design_column_list_fixed)) AS column_mapping
            FROM tb_design_column_list_fixed AS cl
            LEFT JOIN tb_design_column_list_custom_fixed AS cf ON cl.id_design_column_list_fixed = cf.id_design_column_list_fixed
            WHERE cl.id_design_column_type = " + SLUEOnlineStore.EditValue.ToString + "
            GROUP BY cl.id_design_column_list_fixed
            ORDER BY cl.sort ASC, cl.id_design_column_list_fixed ASC
        ", -1, True, "", "", "", "")

        For i = 0 To data_column.Rows.Count - 1
            Dim value As String = data_column.Rows(i)("column_mapping").ToString

            If value.Contains("custom_") Then
                q_select += value + " AS `" + data_column.Rows(i)("column_list_2").ToString + "`, "

                list_custom.Add(value.Replace("custom_", ""))
            Else
                Dim q_concat As String = "CONCAT("

                'split value by line
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

                q_concat = If(q_concat = "CONCAT(", "CONCAT(''", q_concat.Substring(0, q_concat.Length - 2)) + ") AS `" + data_column.Rows(i)("column_list_2").ToString + "`"

                q_select += q_concat + ", "
            End If
        Next

        Dim data As DataTable = New DataTable

        'add header
        For i = 0 To data_column.Rows.Count - 1
            data.Columns.Add(data_column.Rows(i)("column_list_2").ToString, GetType(String))
        Next

        For x = 1 To 2
            Dim row As DataRow = data.NewRow

            For i = 0 To data_column.Rows.Count - 1
                row(data_column.Rows(i)("column_list_2").ToString) = data_column.Rows(i)("column_list_" + x.ToString).ToString
            Next

            data.Rows.Add(row)
        Next

        'custom column
        For i = 0 To list_custom.Count - 1
            Dim data_custom As DataTable = execute_query("SELECT * FROM tb_design_column_list_custom_fixed WHERE id_design_column_list_fixed = " + list_custom(i), -1, True, "", "", "", "")

            Dim q_custom As String = ""

            For j = 0 To data_custom.Rows.Count - 1
                Dim clm As String = data_custom.Rows(j)("column_check").ToString
                Dim val As String = data_custom.Rows(j)("column_value").ToString
                Dim res As String = data_custom.Rows(j)("column_result").ToString

                If j = 0 Then
                    q_custom = "IF(" + clm + " = '" + val + "', '" + res + "', [false])"
                Else
                    q_custom = q_custom.Replace("[false]", "IF(" + clm + " = '" + val + "', '" + res + "', [false])")
                End If
            Next

            q_custom = q_custom.Replace("[false]", "''")

            q_select = q_select.Replace("custom_" + list_custom(i), q_custom)
        Next

        If Not q_select = "" Then
            'query
            Dim query As String = "CALL view_all_design_mapping(" + SLUEOnlineStore.EditValue.ToString + ", """ + q_select.Substring(0, q_select.Length - 2) + """, " + SLUESeason.EditValue.ToString + ", " + SLUEDivision.EditValue.ToString + ", """ + TEProductCode.EditValue.ToString + """)"

            Dim data_tmp As DataTable = execute_query(query, -1, True, "", "", "", "")

            data.Merge(data_tmp)

            If data.Rows.Count > 1 Then
                'replace enter with new line
                For i = 1 To data.Rows.Count - 1
                    For j = 0 To data.Columns.Count - 1
                        If data.Rows(i)(data.Columns(j)).ToString.Contains("[enter]") Then
                            data.Rows(i)(data.Columns(j)) = data.Rows(i)(data.Columns(j)).ToString.Replace("[enter]", Environment.NewLine)
                        End If
                    Next
                Next

                data.Columns.Remove(data.Columns("id_design"))
                data.Columns.Remove(data.Columns("id_product"))
            End If
        End If

        GCBatchUpload.DataSource = data

        'add memo edit
        For i = 0 To GVBatchUpload.Columns.Count - 1
            GVBatchUpload.Columns(i).Width = 250
            GVBatchUpload.Columns(i).ColumnEdit = RepositoryItemMemoEdit
        Next
    End Sub

    Sub column_shopee()
        'select
        Dim list_custom As List(Of String) = New List(Of String)

        Dim q_select As String = ""

        Dim data_column As DataTable = execute_query("
            SELECT cl.column_list_1, cl.column_list_2, cl.column_list_3, cl.column_list_4, cl.column_list_5, IF(cf.id_design_column_list_custom_fixed IS NULL, cl.column_mapping, CONCAT('custom_', cf.id_design_column_list_fixed)) AS column_mapping
            FROM tb_design_column_list_fixed AS cl
            LEFT JOIN tb_design_column_list_custom_fixed AS cf ON cl.id_design_column_list_fixed = cf.id_design_column_list_fixed
            WHERE cl.id_design_column_type = " + SLUEOnlineStore.EditValue.ToString + "
            GROUP BY cl.id_design_column_list_fixed
            ORDER BY cl.sort ASC, cl.id_design_column_list_fixed ASC
        ", -1, True, "", "", "", "")

        For i = 0 To data_column.Rows.Count - 1
            Dim value As String = data_column.Rows(i)("column_mapping").ToString

            If value.Contains("custom_") Then
                q_select += value + " AS `" + data_column.Rows(i)("column_list_2").ToString + "`, "

                list_custom.Add(value.Replace("custom_", ""))
            Else
                Dim q_concat As String = "CONCAT("

                'split value by line
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

                q_concat = If(q_concat = "CONCAT(", "CONCAT(''", q_concat.Substring(0, q_concat.Length - 2)) + ") AS `" + data_column.Rows(i)("column_list_2").ToString + "`"

                q_select += q_concat + ", "
            End If
        Next

        Dim data As DataTable = New DataTable

        'add header
        For i = 0 To data_column.Rows.Count - 1
            data.Columns.Add(data_column.Rows(i)("column_list_2").ToString, GetType(String))
        Next

        For x = 1 To 5
            Dim row As DataRow = data.NewRow

            For i = 0 To data_column.Rows.Count - 1
                row(data_column.Rows(i)("column_list_2").ToString) = data_column.Rows(i)("column_list_" + x.ToString).ToString
            Next

            data.Rows.Add(row)
        Next

        'custom column
        For i = 0 To list_custom.Count - 1
            Dim data_custom As DataTable = execute_query("SELECT * FROM tb_design_column_list_custom_fixed WHERE id_design_column_list_fixed = " + list_custom(i), -1, True, "", "", "", "")

            Dim q_custom As String = ""

            For j = 0 To data_custom.Rows.Count - 1
                Dim clm As String = data_custom.Rows(j)("column_check").ToString
                Dim val As String = data_custom.Rows(j)("column_value").ToString
                Dim res As String = data_custom.Rows(j)("column_result").ToString

                If j = 0 Then
                    q_custom = "IF(" + clm + " = '" + val + "', '" + res + "', [false])"
                Else
                    q_custom = q_custom.Replace("[false]", "IF(" + clm + " = '" + val + "', '" + res + "', [false])")
                End If
            Next

            q_custom = q_custom.Replace("[false]", "''")

            q_select = q_select.Replace("custom_" + list_custom(i), q_custom)
        Next

        If Not q_select = "" Then
            'query
            Dim query As String = "CALL view_all_design_mapping(" + SLUEOnlineStore.EditValue.ToString + ", """ + q_select.Substring(0, q_select.Length - 2) + """, " + SLUESeason.EditValue.ToString + ", " + SLUEDivision.EditValue.ToString + ", """ + TEProductCode.EditValue.ToString + """)"

            Dim data_tmp As DataTable = execute_query(query, -1, True, "", "", "", "")

            data.Merge(data_tmp)

            If data.Rows.Count > 4 Then
                'replace enter with new line
                For i = 4 To data.Rows.Count - 1
                    For j = 0 To data.Columns.Count - 1
                        If data.Rows(i)(data.Columns(j)).ToString.Contains("[enter]") Then
                            data.Rows(i)(data.Columns(j)) = data.Rows(i)(data.Columns(j)).ToString.Replace("[enter]", Environment.NewLine)
                        End If
                    Next
                Next

                data.Columns.Remove(data.Columns("id_design"))
                data.Columns.Remove(data.Columns("id_product"))
            End If
        End If

        GCBatchUpload.DataSource = data

        'add memo edit
        For i = 0 To GVBatchUpload.Columns.Count - 1
            GVBatchUpload.Columns(i).Width = 250
            GVBatchUpload.Columns(i).ColumnEdit = RepositoryItemMemoEdit
        Next
    End Sub

    Private Sub SBView_Click(sender As Object, e As EventArgs) Handles SBView.Click
        clear_data()

        view_column()
    End Sub

    Private Sub SBExportExcel_Click(sender As Object, e As EventArgs) Handles SBExportExcel.Click
        Dim save As SaveFileDialog = New SaveFileDialog

        save.Filter = "Excel File | *.xlsx"

        save.ShowDialog()

        If Not save.FileName = "" Then
            GVBatchUpload.ExportToXlsx(save.FileName)

            infoCustom("File saved.")
        End If
    End Sub

    Private Sub SLUEOnlineStore_EditValueChanged(sender As Object, e As EventArgs) Handles SLUEOnlineStore.EditValueChanged
        clear_data()

        If SLUEOnlineStore.EditValue.ToString = "5" Or SLUEOnlineStore.EditValue.ToString = "8" Then
            SLUETemplate.Visible = True
        Else
            SLUETemplate.Visible = False
        End If
    End Sub

    Sub clear_data()
        GCBatchUpload.DataSource = Nothing

        GVBatchUpload.Columns.Clear()
    End Sub

    Private Sub SLUESeason_EditValueChanged(sender As Object, e As EventArgs) Handles SLUESeason.EditValueChanged
        If loaded Then
            TEProductCode.EditValue = ""
        End If
    End Sub

    Private Sub SLUEDivision_EditValueChanged(sender As Object, e As EventArgs) Handles SLUEDivision.EditValueChanged
        If loaded Then
            TEProductCode.EditValue = ""
        End If
    End Sub

    Private Sub GVBatchUpload_RowCellStyle(sender As Object, e As DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs) Handles GVBatchUpload.RowCellStyle
        If SLUEOnlineStore.EditValue.ToString = "8" Then
            If e.RowHandle <> 0 And e.RowHandle <= 4 Then
                e.Appearance.BackColor = Color.Silver
            End If

            If e.RowHandle = 1 Or e.RowHandle = 2 Then
                e.Appearance.Font = New Font("Tahoma", 8.25, FontStyle.Bold)
            End If

            If e.RowHandle = 1 Then
                e.Appearance.BackColor = Color.Orange
                e.Appearance.ForeColor = Color.White
            End If
        End If

        If SLUEOnlineStore.EditValue.ToString = "5" Then
            If e.RowHandle = 0 Or e.RowHandle = 1 Then
                e.Appearance.BackColor = Color.Silver
                e.Appearance.Font = New Font("Tahoma", 8.25, FontStyle.Bold)
            End If
        End If

        If SLUEOnlineStore.EditValue.ToString = "4" Then
            If e.RowHandle = 0 Or e.RowHandle = 1 Or e.RowHandle = 2 Then
                e.Appearance.BackColor = Color.Silver
            End If

            If e.RowHandle = 2 Then
                e.Appearance.Font = New Font("Tahoma", 8.25, FontStyle.Bold)
            End If
        End If

        If SLUEOnlineStore.EditValue.ToString = "3" Then
            If e.RowHandle = 0 Then
                e.Appearance.BackColor = Color.Silver
                e.Appearance.Font = New Font("Tahoma", 8.25, FontStyle.Bold)
            End If
        End If
    End Sub

    Private Sub SBSearch_Click(sender As Object, e As EventArgs) Handles SBSearch.Click
        FormBatchUploadOnlineStoreSearch.ShowDialog()
    End Sub

    Sub view_template()
        Dim query As String = "
            SELECT 1 AS id_template, 'New Product' AS template_name
            UNION ALL
            SELECT 2 AS id_template, 'Update Product' AS template_name
        "

        viewSearchLookupQuery(SLUETemplate, query, "id_template", "template_name", "id_template")
    End Sub
End Class