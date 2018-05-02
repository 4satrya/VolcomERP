Public Class FormFGCodeReplaceView
    Public id As String = "-1"
    Private Sub FormFGCodeReplaceView_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        load_view()
    End Sub
    Sub load_view()
        Dim query As String = "CALL generate_repalce_barcode_view('" & id & "')"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCBarcode.DataSource = data
        GVBarcode.BestFitColumns()
    End Sub

    Private Sub FormFGCodeReplaceView_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub BViewUnique_Click(sender As Object, e As EventArgs) Handles BViewUnique.Click
        print_no_footer(GCBarcode, "Unique List")
    End Sub
End Class