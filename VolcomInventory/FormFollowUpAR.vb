Public Class FormFollowUpAR
    Private Sub FormFollowUpAR_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Sub viewList()
        Cursor = Cursors.WaitCursor
        Dim query As String = "SELECT f.id_follow_up_ar, f.due_date, f.follow_up, 
        f.follow_up_result, f.follow_up_date, f.follow_up_input
        FROM tb_follow_up_ar f "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCData.DataSource = data
        GVData.BestFitColumns()
        Cursor = Cursors.Default
    End Sub
End Class