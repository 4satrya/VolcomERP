Public Class FormDesignColumnDet
    Public id_design_column As String = "-1"
    Public column_type_front As String = "-1"
    Public column_type_end As String = "-1"

    Private Sub FormDesignColumnDet_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If id_design_column = "-1" Then
            Dim type As String = execute_query("
                SELECT CONCAT(column_front.display_name, ' ', column_end.display_name) AS `code`
                FROM (
	                SELECT display_name
	                FROM tb_m_code_detail
	                WHERE id_code_detail = " + column_type_front + "
                ) AS column_front, (
	                SELECT display_name
	                FROM tb_m_code_detail
	                WHERE id_code_detail = " + column_type_end + "
                ) AS column_end
            ", 0, True, "", "", "", "")

            TEType.EditValue = type
        Else
            Dim data As DataTable = execute_query("
                SELECT CONCAT(c_front.display_name, ' ', c_end.display_name) AS `type`, d.column_name, d.is_lookup
                FROM tb_design_column AS d
                LEFT JOIN tb_m_code_detail AS c_front ON c_front.id_code_detail = d.column_type_front
                LEFT JOIN tb_m_code_detail AS c_end ON c_end.id_code_detail = d.column_type_end
                WHERE d.id_design_column = " + id_design_column + "
            ", -1, True, "", "", "", "")

            TEType.EditValue = data.Rows(0)("type").ToString
            TEColumnName.EditValue = data.Rows(0)("column_name").ToString
            CEIsLookUp.Checked = If(data.Rows(0)("is_lookup").ToString = "1", True, False)
        End If
    End Sub

    Private Sub FormDesignColumnDet_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        FormDesignColumn.form_load()

        'set focus
        For i = 0 To FormDesignColumn.GVDesignColumn.Columns.Count - 1
            If FormDesignColumn.GVDesignColumn.Columns(i).Tag.ToString.Split(";")(0) = id_design_column Then
                FormDesignColumn.GVDesignColumn.FocusedColumn = FormDesignColumn.GVDesignColumn.Columns(i)
            End If
        Next

        Dispose()
    End Sub

    Private Sub SBClose_Click(sender As Object, e As EventArgs) Handles SBClose.Click
        Close()
    End Sub

    Private Sub SBSave_Click(sender As Object, e As EventArgs) Handles SBSave.Click
        If Not TEColumnName.Text = "" Then
            If id_design_column = "-1" Then
                'insert
                id_design_column = execute_query("
                    INSERT INTO tb_design_column (column_name, column_type_front, column_type_end, is_lookup) VALUES ('" + addSlashes(TEColumnName.EditValue) + "', " + column_type_front + ", " + column_type_end + ", " + If(CEIsLookUp.Checked, "1", "2") + "); SELECT LAST_INSERT_ID();
                ", 0, True, "", "", "", "")

                infoCustom("Saved.")

                Close()
            Else
                'update
                execute_non_query("
                    UPDATE tb_design_column SET column_name = '" + addSlashes(TEColumnName.EditValue) + "', column_type_front = " + column_type_front + ", column_type_end = " + column_type_end + ", is_lookup = " + If(CEIsLookUp.Checked, "1", "2") + " WHERE id_design_column = " + id_design_column + "
                ", True, "", "", "", "")

                infoCustom("Saved.")

                Close()
            End If
        Else
            errorCustom("Column name can't be blank.")
        End If
    End Sub
End Class