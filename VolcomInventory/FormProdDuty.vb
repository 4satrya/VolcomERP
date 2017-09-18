Public Class FormProdDuty
    Dim id_season As String = "0"
    Dim id_vendor As String = "-1"
    Dim id_design As String = "0"

    Private Sub FormProdDuty_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        viewDesign()
        '
        viewSeason()
        '
        viewVendor()
    End Sub
    Sub viewDesign()
        Dim query As String = ""
        query += "CALL view_design_order(TRUE)"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        SLEDesignStockStore.Properties.DataSource = Nothing
        SLEDesignStockStore.Properties.DataSource = data
        SLEDesignStockStore.Properties.DisplayMember = "display_name"
        SLEDesignStockStore.Properties.ValueMember = "id_design"
        If data.Rows.Count.ToString >= 1 Then
            SLEDesignStockStore.EditValue = data.Rows(0)("id_design").ToString
        Else
            SLEDesignStockStore.EditValue = Nothing
        End If
    End Sub
    Sub viewSeason()
        Dim query As String = "SELECT '-1' AS id_season, 'All Season' as season UNION "
        query += "(SELECT id_season,season FROM tb_season a "
        query += "INNER JOIN tb_range b ON a.id_range = b.id_range "
        query += "ORDER BY b.range ASC)"
        viewSearchLookupQuery(SLESeason, query, "id_season", "season", "id_season")
    End Sub
    Sub viewVendor()
        Dim query As String = ""
        query += "SELECT ('0') AS id_comp, ('-') AS comp_number, ('All Vendor') AS comp_name, ('ALL Vendor') AS comp_name_label UNION ALL "
        query += "SELECT comp.id_comp,comp.comp_number, comp.comp_name, CONCAT_WS(' - ', comp.comp_number,comp.comp_name) AS comp_name_label FROM tb_m_comp comp "
        query += "WHERE comp.id_comp_cat='1'"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        SLEVendor.Properties.DataSource = Nothing
        SLEVendor.Properties.DataSource = data
        SLEVendor.Properties.DisplayMember = "comp_name_label"
        SLEVendor.Properties.ValueMember = "id_comp"
        If data.Rows.Count.ToString >= 1 Then
            SLEVendor.EditValue = data.Rows(0)("id_comp").ToString
        Else
            SLEVendor.EditValue = Nothing
        End If
    End Sub
    Private Sub BSearch_Click(sender As Object, e As EventArgs) Handles BSearch.Click
        view_production_order()
    End Sub
    Sub view_production_order()
        Dim desg, season, comp As String

        If Not SLEDesignStockStore.EditValue.ToString = "0" Then
            desg = "'" & SLEDesignStockStore.EditValue.ToString & "'"
        Else
            desg = "'%%'"
        End If

        If Not SLESeason.EditValue.ToString = "-1" Then
            season = "'" & SLESeason.EditValue.ToString & "'"
        Else
            season = "'%%'"
        End If

        If Not SLEVendor.EditValue.ToString = "0" Then
            comp = "'" & SLEVendor.EditValue.ToString & "'"
        Else
            comp = "'%%'"
        End If

        Dim query As String = "CALL view_prod_duty(" & desg & "," & season & "," & comp & ")"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCProd.DataSource = data

        If data.Rows.Count > 0 Then
            GVProd.FocusedRowHandle = 0
            GVProd.BestFitColumns()
            GVProd.ExpandAllGroups()
        End If
    End Sub

    Private Sub SMEdit_Click(sender As Object, e As EventArgs) Handles SMEdit.Click
        If GVProd.RowCount > 0 Then
            FormProdDutyVar.id_prod_order = GVProd.GetFocusedRowCellValue("id_prod_order").ToString
            FormProdDutyVar.ShowDialog()
        End If
    End Sub

    Private Sub BImportExcel_Click(sender As Object, e As EventArgs) Handles BImportExcel.Click
        Cursor = Cursors.WaitCursor
        FormImportExcel.id_pop_up = "30"
        FormImportExcel.ShowDialog()
        Cursor = Cursors.Default
    End Sub

    Private Sub BPrint_Click(sender As Object, e As EventArgs) Handles BPrint.Click
        print_raw(GCProd, "Royalty")
    End Sub
End Class