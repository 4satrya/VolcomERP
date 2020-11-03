Public Class FormBarcodeProduct 

    Private Sub FormBarcodeProduct_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        viewSeason()
        viewProd()
    End Sub

    Sub check_menu()
        checkFormAccess(Name)
        'If GVProdList.RowCount < 1 Then
        '    'hide all except new
        '    bnew_active = "1"
        '    bedit_active = "0"
        '    bdel_active = "0"
        '    checkFormAccess(Name)
        '    button_main(bnew_active, bedit_active, bdel_active)
        'Else
        '    'show all
        '    bnew_active = "1"
        '    bedit_active = "1"
        '    bdel_active = "1"
        '    noManipulating()
        'End If
    End Sub

    Sub viewSeason()
        Dim query As String = "SELECT * FROM tb_season a "
        query += "INNER JOIN tb_range b ON a.id_range = b.id_range "
        query += "ORDER BY b.range DESC"
        viewSearchLookupQuery(SLESeason, query, "id_season", "season", "id_season")
    End Sub

    Private Sub BtnView_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnView.Click
        Cursor = Cursors.WaitCursor
        viewProd()
        Cursor = Cursors.Default
    End Sub

    'per season
    'Sub viewProd()
    '    Dim id_season_par As String = "-1"
    '    Try
    '        id_season_par = SLESeason.EditValue.ToString
    '    Catch ex As Exception
    '    End Try
    '    Dim query As String = "CALL view_product_per_season('" + id_season_par + "')"
    '    Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
    '    GCProdList.DataSource = data
    '    GVProdList.ExpandAllGroups()
    'End Sub

    Sub viewProd()
        Dim query As String = "CALL view_product_opt(1,' WHERE e.id_season=" & SLESeason.EditValue.ToString & " AND IFNULL(qtyq.qty_order,0)>0 ')"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCProdList.DataSource = data
        GVProdList.ExpandAllGroups()
    End Sub

    Private Sub FormBarcodeProduct_FormClosed(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles MyBase.FormClosed

        Dispose()
    End Sub

    Private Sub FormBarcodeProduct_Activated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Activated
        FormMain.show_rb(Name)
        check_menu()
    End Sub

    Private Sub FormBarcodeProduct_Deactivate(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Deactivate
        FormMain.hide_rb()
    End Sub
End Class