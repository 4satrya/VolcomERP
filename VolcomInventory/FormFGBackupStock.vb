Public Class FormFGBackupStock
    Private Sub FormFGBackupStock_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        viewSt()
    End Sub

    Sub viewSt()
        Cursor = Cursors.WaitCursor
        Dim st As New ClassStockTake()
        Dim query As String = st.queryMain("-1", "1")
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCPeriod.DataSource = data
        Cursor = Cursors.Default
    End Sub

    Private Sub FormFGBackupStock_Activated(sender As Object, e As EventArgs) Handles MyBase.Activated
        FormMain.show_rb(Name)
        checkFormAccess(Name)
    End Sub

    Private Sub FormFGBackupStock_Deactivate(sender As Object, e As EventArgs) Handles MyBase.Deactivate
        FormMain.hide_rb()
    End Sub
End Class