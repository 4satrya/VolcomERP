Public Class FormWHImportDO
    Private Sub FormWHImportDO_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        viewDOList()
    End Sub

    Sub viewDOList()
        Dim query As String = "SELECT * FROM tb_wh_awb_do"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCImportDO.DataSource = data
        GVImportDO.BestFitColumns()
    End Sub

    Private Sub FormWHImportDO_Activated(sender As Object, e As EventArgs) Handles MyBase.Activated
        FormMain.show_rb(Name)
        checkFormAccess(Name)
    End Sub

    Private Sub FormWHImportDO_Deactivate(sender As Object, e As EventArgs) Handles MyBase.Deactivate
        FormMain.hide_rb()
    End Sub

    Private Sub BtnImport_Click(sender As Object, e As EventArgs) Handles BtnImport.Click
        Cursor = Cursors.WaitCursor
        FormImportExcel.id_pop_up = "14"
        FormImportExcel.ShowDialog()
        Cursor = Cursors.Default
    End Sub

    Private Sub GVImportDO_CustomColumnDisplayText(sender As Object, e As DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs) Handles GVImportDO.CustomColumnDisplayText
        If e.Column.FieldName = "no" Then
            e.DisplayText = (e.ListSourceRowIndex + 1).ToString()
        End If
    End Sub
End Class