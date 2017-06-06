Public Class FormFGTransList
    Private Sub FormFGTransList_Activated(sender As Object, e As EventArgs) Handles MyBase.Activated
        FormMain.show_rb(Name)
        checkFormAccess(Name)
    End Sub

    Private Sub FormFGTransList_Deactivate(sender As Object, e As EventArgs) Handles MyBase.Deactivate
        FormMain.hide_rb()
    End Sub

    Private Sub BtnViewRec_Click(sender As Object, e As EventArgs) Handles BtnViewRec.Click
        viewRecProduct()
    End Sub

    Sub viewRecProduct()
        Cursor = Cursors.WaitCursor
        'Prepare paramater
        Dim date_from_selected As String = "0000-01-01"
        Dim date_until_selected As String = "9999-01-01"
        Try
            date_from_selected = DateTime.Parse(DEFromRec.EditValue.ToString).ToString("yyyy-MM-dd")
        Catch ex As Exception
        End Try
        Try
            date_until_selected = DateTime.Parse(DEUntilRec.EditValue.ToString).ToString("yyyy-MM-dd")
        Catch ex As Exception
        End Try

        'prepare query
        Dim query As String = ""
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCPL.DataSource = data
        Cursor = Cursors.Default
    End Sub
End Class