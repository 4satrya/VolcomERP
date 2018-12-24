Public Class FormCoba
    Dim bnew_active As String = "1"
    Dim bedit_active As String = "1"
    Dim bdel_active As String = "1"

    Private Sub FormBankWithdrawal_Deactivate(sender As Object, e As EventArgs) Handles MyBase.Deactivate
        FormMain.hide_rb()
    End Sub

    Private Sub FormBankWithdrawal_Activated(sender As Object, e As EventArgs) Handles MyBase.Activated
        FormMain.show_rb(Name)
        check_menu()
    End Sub

    Sub check_menu()
        bnew_active = "0"
        bedit_active = "0"
        bdel_active = "0"
        checkFormAccess(Name)
        button_main(bnew_active, bedit_active, bdel_active)
    End Sub

    Private Sub FormCoba_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        load_list()
        load_comp()

        Dim query As String = "SELECT * FROM `tb_m_comp`"
        viewSearchLookupQuery(SLUECompanyName, query, "id_comp", "comp_name", "id_comp")
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

    Private Sub SBAdd_Click(sender As Object, e As EventArgs) Handles SBAdd.Click
        Dim newRow As DataRow = (TryCast(GCList.DataSource, DataTable)).NewRow()

        'newRow("id_prod_order_rec") =
        newRow("prod_order_rec_number") = TEOrderRec.EditValue.ToString
        newRow("val_rec") = NUDValue.Value
        'newRow("id_comp") =
        'newRow("comp_name") = SLUECompanyName.EditValue.ToString
        'newRow("id_prod_order") =
        newRow("prod_order_number") = TEProdOrderNumber.EditValue.ToString
        newRow("delivery_order_date") = DEDeliveryOrderDate.EditValue.ToString
        newRow("arrive_date") = DEArriveDate.EditValue.ToString
        'newRow("testunbound") = NUDValue.Value + 1

        TryCast(GCList.DataSource, DataTable).Rows.Add(newRow)

        GCList.RefreshDataSource()
    End Sub

    Private Sub SBDelete_Click(sender As Object, e As EventArgs) Handles SBDelete.Click
        Dim confirm As DialogResult
        confirm = DevExpress.XtraEditors.XtraMessageBox.Show("Are you sure want to delete this ?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)

        If confirm = DialogResult.Yes Then
            GVList.DeleteSelectedRows()
        End If
    End Sub

    Private Sub SBFormBanded_Click(sender As Object, e As EventArgs) Handles SBFormBanded.Click
        CobaFormBanded.ShowDialog()
    End Sub

    Private Sub SBFormCobaScan_Click(sender As Object, e As EventArgs) Handles SBFormCobaScan.Click
        FormTestBarcodeScan.ShowDialog()
    End Sub
End Class