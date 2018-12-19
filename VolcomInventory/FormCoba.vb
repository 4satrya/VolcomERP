Public Class FormCoba
    Private Sub FormCoba_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        load_list()
        load_comp()
    End Sub
    Sub load_list()
        Dim id_comp As String = ""
        Dim date_from As String = Format(DateEditFrom.EditValue, "yyyy-MM-dd")
        Dim date_to As String = Format(DateEditTo.EditValue, "yyyy-MM-dd")

        If SearchLookUpEditVendor.EditValue Then
            id_comp = SearchLookUpEditVendor.EditValue.ToString
        End If

        Dim query As String = "CALL view_amount_rec_fgpo('" & id_comp & "','" & date_from & "','" & date_to & "')"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")

        GCList.DataSource = data
        GVList.BestFitColumns()
    End Sub

    Sub load_comp()
        Dim query As String = "SELECT * FROM tb_m_comp"
        viewSearchLookupQuery(SearchLookUpEditVendor, query, "id_comp", "comp_name", "id_comp")
    End Sub

    Private Sub BId_Click(sender As Object, e As EventArgs) Handles BId.Click
        'warningCustom("Id : " & GVList.GetFocusedRowCellValue("id_prod_order_rec").ToString)
        warningCustom("Id : " & GVList.GetRowCellValue(0, "id_prod_order_rec").ToString)
        For i As Integer = 0 To GVList.RowCount - 1
            Console.WriteLine(GVList.GetRowCellValue(i, "id_prod_order_rec").ToString)
        Next
    End Sub

    Private Sub BSearch_Click(sender As Object, e As EventArgs) Handles BSearch.Click
        load_list()
    End Sub
End Class