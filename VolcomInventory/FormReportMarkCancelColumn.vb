Public Class FormReportMarkCancelColumn
    Public id_report_cancel As String = "-1"

    Private Sub FormReportMarkCancelColumn_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub FormReportMarkCancelColumn_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        load_column()
    End Sub

    Sub load_column()
        Dim query As String = "SELECT * FROM `tb_report_mark_cancel_column`
WHERE id_report_mark_cancel='" & id_report_cancel & "'"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCAddColumn.DataSource = data
        GVAddColumn.BestFitColumns()
    End Sub

    Private Sub BDelColumn_Click(sender As Object, e As EventArgs) Handles BDelColumn.Click
        If GVAddColumn.RowCount > 0 Then
            Dim query As String = "DELETE FROM tb_report_mark_cancel_column WHERE id_column='" & GVAddColumn.GetFocusedRowCellValue("id_column") & "'"
            execute_non_query(query, True, "", "", "", "")
            infoCustom("Column deleted")
            load_column()
            FormReportMarkCancel.load_det()
        Else
            warningCustom("Please select which one to delete.")
        End If
    End Sub

    Private Sub BAddColumn_Click(sender As Object, e As EventArgs) Handles BAddColumn.Click
        If TEColumnName.Text = "" Then
            warningCustom("Please input proper column name")
        Else
            Dim query As String = "INSERT INTO tb_report_mark_cancel_column(id_report_mark_cancel,column_name) VALUES('" & id_report_cancel & "','" & addSlashes(TEColumnName.Text) & "')"
            execute_non_query(query, True, "", "", "", "")
            infoCustom("Column added")
            load_column()
            FormReportMarkCancel.load_det()
        End If
    End Sub
End Class