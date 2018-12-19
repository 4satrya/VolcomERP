Public Class FormTestImage
    Private Sub FormTestImage_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        loadList()
        loadWH()
        loadLocator()
        loadRack()
        loadDrawer()
    End Sub

    Sub loadList()
        Dim query As String = "SELECT * FROM `tb_m_design` LIMIT 50"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")

        GCList.DataSource = data
    End Sub

    Sub loadWH()
        Dim query As String = ""

        query = "SELECT `id_comp_cat_wh` FROM `tb_opt`"
        Dim id_comp_cat_wh As String = execute_query(query, 0, True, "", "", "", "")

        query = "SELECT `id_comp_cat_store` FROM `tb_opt`"
        Dim id_comp_cat_store As String = execute_query(query, 0, True, "", "", "", "")

        query = "SELECT ('0') AS id_comp, ('-') AS comp_number, ('All WH') AS comp_name UNION ALL SELECT a.id_comp, a.comp_number, a.comp_name FROM tb_m_comp a WHERE (a.id_comp_cat = '" + id_comp_cat_wh + "' OR  a.id_comp_cat = '" + id_comp_cat_store + "') ORDER BY comp_number ASC"
        viewSearchLookupQuery(SLWH, query, "id_comp", "comp_name", "id_comp")
    End Sub

    Sub loadLocator()
        Dim id_comp As String = SLWH.EditValue.ToString()
        Dim query As String = "SELECT ('0') AS id_comp, ('0') AS id_wh_locator, ('-') AS wh_locator_code, ('All Loactor') AS wh_locator, ('-') AS wh_locator_description UNION ALL SELECT a.id_comp, a.id_wh_locator, a.wh_locator_code, a.wh_locator, a.wh_locator_description FROM tb_m_wh_locator a WHERE a.id_comp = '" + id_comp + "'"

        viewSearchLookupQuery(SLLocator, query, "id_wh_locator", "wh_locator", "id_wh_locator")
    End Sub

    Sub loadRack()
        Dim id_locator As String = SLLocator.EditValue.ToString()
        Dim query As String = "SELECT ('0') AS id_locator, ('0') AS id_wh_rack, ('-') AS wh_rack_code, ('All Rack') AS wh_rack, ('-') AS wh_rack_description UNION ALL SELECT a.id_wh_locator, a.id_wh_rack, a.wh_rack_code, a.wh_rack, a.wh_rack_description FROM tb_m_wh_rack a WHERE a.id_wh_locator = '" + id_locator + "'"

        viewSearchLookupQuery(SLRack, query, "id_wh_rack", "wh_rack", "id_wh_rack")
    End Sub

    Sub loadDrawer()
        Dim id_rack As String = SLRack.EditValue.ToString()
        Dim query As String = "SELECT ('0') AS id_rack, ('0') AS id_wh_drawer, ('-') AS wh_drawer_code, ('All Drawer') AS wh_drawer, ('-') AS wh_drawer_description UNION ALL SELECT a.id_wh_rack, a.id_wh_drawer, a.wh_drawer_code, a.wh_drawer, a.wh_drawer_description FROM tb_m_wh_drawer a WHERE a.id_wh_rack = '" + id_rack + "'"

        viewSearchLookupQuery(SLDrawer, query, "id_wh_drawer", "wh_drawer", "id_wh_drawer")
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

    Private Sub SLWH_EditValueChanged(sender As Object, e As EventArgs) Handles SLWH.EditValueChanged
        loadLocator()
        loadRack()
        loadDrawer()
    End Sub
End Class