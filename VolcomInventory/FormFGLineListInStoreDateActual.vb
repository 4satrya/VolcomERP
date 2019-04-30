Public Class FormFGLineListInStoreDateActual
    Private Sub FormFGLineListInStoreDateActual_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub FormFGLineListInStoreDateActual_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        DEInStoreDate.EditValue = getTimeDB()
    End Sub

    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs) Handles SimpleButton1.Click
        Close()
    End Sub

    Private Sub BtnSave_Click(sender As Object, e As EventArgs) Handles BtnSave.Click
        Dim confirm As DialogResult = DevExpress.XtraEditors.XtraMessageBox.Show("Are you sure you want to update in store date actual?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
        If confirm = Windows.Forms.DialogResult.Yes Then
            Cursor = Cursors.WaitCursor
            Dim in_store_date_actual As String = DateTime.Parse(DEInStoreDate.EditValue.ToString).ToString("yyyy-MM-dd")
            Dim id_design As String = ""
            For i As Integer = 0 To (FormFGLineList.BGVLineList.RowCount - 1)
                If i > 0 Then
                    id_design += "OR "
                End If
                id_design += "id_design='" + FormFGLineList.BGVLineList.GetRowCellValue(i, "id_design").ToString + "' "
            Next
            Dim query As String = "UPDATE tb_m_design SET in_store_date_actual='" + in_store_date_actual + "' WHERE (" + id_design + ") "
            execute_non_query(query, True, "", "", "", "")

            'send mail
            Dim m As New ClassSendEmail()
            m.report_mark_type = "in_store_date_actual"
            m.design = id_design
            m.date_string = DEInStoreDate.Text
            m.send_email()

            FormFGLineList.viewLineList()
            Close()
            Cursor = Cursors.Default
        End If
    End Sub
End Class