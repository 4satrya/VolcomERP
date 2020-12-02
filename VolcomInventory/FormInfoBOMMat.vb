Public Class FormInfoBOMMat 
    Public id_pd_design As String = "-1"

    Private Sub FormInfoBOMMat_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        RCIsCOP.ValueChecked = Convert.ToSByte(1)
        RCIsCOP.ValueUnchecked = Convert.ToSByte(2)

        viewVendor()
    End Sub

    Sub viewVendor()
        Dim query As String = ""
        query += "SELECT ('0') AS id_comp, ('-') AS comp_number, ('All Vendor') AS comp_name, ('ALL Vendor') AS comp_name_label 
        UNION "
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

    Sub view_bom_mat()
        Try
            Dim query As String
            query = "CALL view_mat_design('" & GVProd.GetFocusedRowCellValue("id_prod_demand_design").ToString & "')"

            Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
            GCBomDetMat.DataSource = data
            GVBomDetMat.BestFitColumns()
        Catch ex As Exception
            errorConnection()
        End Try
    End Sub

    Private Sub FormInfoBOMMat_FormClosed(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub BAddMat_Click(sender As Object, e As EventArgs) Handles BAddMat.Click
        'check if exist
        'Dim already = False
        'If FormProductionMRS.GVMat.RowCount > 0 Then
        '    For i As Integer = 0 To FormProductionMRS.GVMat.RowCount - 1
        '        If FormProductionMRS.GVMat.GetRowCellValue(i, "id_mat_det_price").ToString = GVBomDetMat.GetFocusedRowCellDisplayText("id_mat_det_price").ToString Then
        '            already = True
        '        End If
        '    Next
        'End If

        'If already = True Then
        '    stopCustom("Material already in list")
        'Else
        '    Dim newRow As DataRow = (TryCast(FormProductionMRS.GCMat.DataSource, DataTable)).NewRow()
        '    newRow("id_mat_det") = GVBomDetMat.GetFocusedRowCellDisplayText("id_mat_det").ToString
        '    newRow("id_mat_det_price") = GVBomDetMat.GetFocusedRowCellDisplayText("id_mat_det_price").ToString
        '    newRow("size") = GVBomDetMat.GetFocusedRowCellDisplayText("size").ToString
        '    newRow("mat_det_price") = GVBomDetMat.GetFocusedRowCellDisplayText("price")
        '    newRow("name") = GVBomDetMat.GetFocusedRowCellDisplayText("mat_det_name").ToString
        '    newRow("code") = GVBomDetMat.GetFocusedRowCellDisplayText("mat_det_code").ToString
        '    newRow("color") = GVBomDetMat.GetFocusedRowCellDisplayText("color").ToString
        '    newRow("qty_all_mat") = GVBomDetMat.GetFocusedRowCellDisplayText("qty_all_mat").ToString
        '    newRow("qty_left") = GVBomDetMat.GetFocusedRowCellDisplayText("qty_left").ToString
        '    newRow("qty") = GVBomDetMat.GetFocusedRowCellDisplayText("qty").ToString

        '    TryCast(FormProductionMRS.GCMat.DataSource, DataTable).Rows.Add(newRow)
        '    FormProductionMRS.GCMat.RefreshDataSource()
        '    FormProductionMRS.check_but()
        '    FormProductionMRS.GVMat.FocusedRowHandle = 0
        '    Close()
        'End If

        If GVBomDetMat.RowCount > 0 Then
            For i As Integer = FormProductionMRS.GVMat.RowCount - 1 To 0 Step -1
                FormProductionMRS.GVMat.DeleteRow(i)
            Next

            For i As Integer = 0 To GVBomDetMat.RowCount - 1
                Dim newRow As DataRow = (TryCast(FormProductionMRS.GCMat.DataSource, DataTable)).NewRow()
                newRow("id_mat_det") = GVBomDetMat.GetRowCellValue(i, "id_mat_det").ToString
                newRow("id_mat_det_price") = GVBomDetMat.GetRowCellValue(i, "id_mat_det_price").ToString
                newRow("size") = GVBomDetMat.GetRowCellValue(i, "size").ToString
                newRow("mat_det_price") = GVBomDetMat.GetRowCellValue(i, "price")
                newRow("name") = GVBomDetMat.GetRowCellValue(i, "mat_det_name").ToString
                newRow("code") = GVBomDetMat.GetRowCellValue(i, "mat_det_code").ToString
                newRow("color") = GVBomDetMat.GetRowCellValue(i, "color").ToString
                newRow("qty_all_mat") = GVBomDetMat.GetRowCellValue(i, "qty_all_mat").ToString
                newRow("qty_left") = GVBomDetMat.GetRowCellValue(i, "qty_left").ToString
                newRow("qty") = GVBomDetMat.GetRowCellValue(i, "qty").ToString

                TryCast(FormProductionMRS.GCMat.DataSource, DataTable).Rows.Add(newRow)
                FormProductionMRS.GCMat.RefreshDataSource()
            Next

            FormProductionMRS.check_but()
            FormProductionMRS.GVMat.FocusedRowHandle = 0
            '
            FormProductionMRS.id_prod_order = GVProd.GetFocusedRowCellValue("id_prod_order").ToString

            FormProductionMRS.TEDesign.EditValue = GVProd.GetFocusedRowCellValue("design_display_name").ToString
            FormProductionMRS.TEDesignCode.EditValue = GVProd.GetFocusedRowCellValue("design_code").ToString
            FormProductionMRS.TEPONumber.EditValue = GVProd.GetFocusedRowCellValue("prod_order_number").ToString
            '
            Close()
        End If
    End Sub

    Private Sub BSearch_Click(sender As Object, e As EventArgs) Handles BSearch.Click
        Dim query_where As String = ""

        If Not SLEVendor.EditValue.ToString = "0" Then
            query_where += " AND cc.id_comp='" & SLEVendor.EditValue.ToString & "'"
        End If

        Dim query As String = "
            SELECT a.id_prod_order, CONCAT(comp.comp_number, '-', comp.comp_name) AS vendor, a.prod_order_number, d.design_code, d.design_display_name, a.prod_order_date, b.id_prod_demand_design
            FROM tb_prod_order AS a
            INNER JOIN tb_prod_order_det AS pod ON pod.id_prod_order = a.id_prod_order
            INNER JOIN tb_prod_demand_design AS b ON a.id_prod_demand_design = b.id_prod_demand_design
            INNER JOIN tb_m_design AS d ON b.id_design = d.id_design
            LEFT JOIN tb_prod_order_wo AS wo ON wo.id_prod_order = a.id_prod_order AND wo.is_main_vendor = '1'
            LEFT JOIN tb_m_ovh_price AS ovh_p ON ovh_p.id_ovh_price = wo.id_ovh_price 
            LEFT JOIN tb_m_comp_contact AS cc ON cc.id_comp_contact = ovh_p.id_comp_contact
            LEFT JOIN tb_m_comp AS comp ON comp.id_comp = cc.id_comp
            WHERE a.id_report_status = 6 " + query_where + "
            GROUP BY a.id_prod_order
            ORDER BY a.id_prod_order DESC
        "

        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")

        GCProd.DataSource = data
        GVProd.BestFitColumns()
    End Sub

    Private Sub GVProd_FocusedRowChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles GVProd.FocusedRowChanged
        view_bom_mat()
    End Sub

    Private Sub GVProd_ColumnFilterChanged(sender As Object, e As EventArgs) Handles GVProd.ColumnFilterChanged
        view_bom_mat()
    End Sub
End Class