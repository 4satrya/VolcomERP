Public Class FormSalesReturnRec
    Dim bnew_active As String = "1"
    Dim bedit_active As String = "1"
    Dim bdel_active As String = "1"

    Private Sub FormSalesReturnRec_Activated(sender As Object, e As EventArgs) Handles MyBase.Activated
        FormMain.show_rb(Name)
        check_menu()
    End Sub

    Private Sub FormSalesReturnRec_Deactivate(sender As Object, e As EventArgs) Handles MyBase.Deactivate
        FormMain.hide_rb()
    End Sub

    Sub check_menu()
        bnew_active = "1"
        bdel_active = "0"

        Console.WriteLine(GVList.RowCount)

        If GVList.RowCount >= 1 Then
            bedit_active = "1"
        Else
            bedit_active = "0"
        End If

        checkFormAccess(Name)
        button_main(bnew_active, bedit_active, bdel_active)
    End Sub

    Private Sub FormSalesReturnRec_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        load_list()
    End Sub

    Sub load_list()
        Dim data As DataTable = execute_query("SELECT * FROM `tb_sales_return_rec`", -1, True, "", "", "", "")
        GCList.DataSource = data
        GVList.BestFitColumns()
    End Sub

    Private Sub GVList_DoubleClick(sender As Object, e As EventArgs) Handles GVList.DoubleClick
        FormSalesReturnRecDet.id = GVList.GetFocusedDataRow("id_sales_return_rec").ToString
        FormSalesReturnRecDet.ShowDialog()
    End Sub
End Class