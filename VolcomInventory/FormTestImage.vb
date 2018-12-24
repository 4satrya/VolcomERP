Public Class FormTestImage
    Dim bnew_active As String = "1"
    Dim bedit_active As String = "1"
    Dim bdel_active As String = "1"

    Private Sub FormTestImage_Deactivate(sender As Object, e As EventArgs) Handles MyBase.Deactivate
        FormMain.hide_rb()
    End Sub

    Private Sub FormTestImage_Activated(sender As Object, e As EventArgs) Handles MyBase.Activated
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

    Private Sub FormTestImage_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        loadList()
        viewType()
    End Sub

    Sub loadList()
        Dim cond As String = "-1"

        If SLSeason.EditValue Then
            cond = "And f1.id_season=" + SLSeason.EditValue.ToString() + " "
        End If

        Dim query As String = "CALL view_all_design_param('" + cond + "')"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")

        GCList.DataSource = data
    End Sub

    Sub viewType()
        Dim query As String = "SELECT * FROM tb_lookup_line_list_type a ORDER BY a.id_line_list_type ASC"
        viewSearchLookupQuery(SLType, query, "id_line_list_type", "line_list_type", "id_line_list_type")
    End Sub

    Sub viewSeason()
        Dim type As String = ""

        If SLType.EditValue Then
            type = SLType.EditValue.ToString()
        End If

        Dim query As String = "Select a.id_season, a.season, b.id_range, b.`range` From tb_season a INNER Join tb_range b ON a.id_range = b.id_range WHERE b.is_md='" + type + "' ORDER BY `range` DESC"

        viewSearchLookupQuery(SLSeason, query, "id_season", "season", "id_season")
    End Sub

    Private Sub GVList_RowClick(sender As Object, e As DevExpress.XtraGrid.Views.Grid.RowClickEventArgs) Handles GVList.RowClick
        Dim id_design As String = GVList.GetFocusedRowCellValue("id_design").ToString()
        Dim design_code As String = GVList.GetFocusedRowCellValue("design_code").ToString()
        Dim design_name As String = GVList.GetFocusedRowCellValue("design_name").ToString()

        If id_design Then
            pre_viewImages("2", PictureEdit, id_design, False)
        End If

        TextCode.EditValue = design_code
        TextName.EditValue = design_name
    End Sub

    Private Sub SLType_EditValueChanged(sender As Object, e As EventArgs) Handles SLType.EditValueChanged
        viewSeason()
    End Sub

    Private Sub SLSeason_EditValueChanged(sender As Object, e As EventArgs) Handles SLSeason.EditValueChanged
        loadList()
    End Sub
End Class