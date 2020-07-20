Public Class FormDesignColumnDet
    Public id_design_column As String = "-1"

    Private Sub FormDesignColumnDet_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If Not id_design_column = "-1" Then
            Dim data As DataTable = execute_query("
                SELECT d.column_name, d.is_lookup
                FROM tb_design_column AS d
                WHERE d.id_design_column = " + id_design_column + "
            ", -1, True, "", "", "", "")

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
                    INSERT INTO tb_design_column (column_name, is_lookup) VALUES ('" + addSlashes(TEColumnName.EditValue) + "', " + If(CEIsLookUp.Checked, "1", "2") + "); SELECT LAST_INSERT_ID();
                ", 0, True, "", "", "", "")

                infoCustom("Saved.")

                Close()
            Else
                'update
                execute_non_query("
                    UPDATE tb_design_column SET column_name = '" + addSlashes(TEColumnName.EditValue) + "', is_lookup = " + If(CEIsLookUp.Checked, "1", "2") + " WHERE id_design_column = " + id_design_column + "
                ", True, "", "", "", "")

                infoCustom("Saved.")

                Close()
            End If
        Else
            errorCustom("Column name can't be blank.")
        End If
    End Sub
End Class