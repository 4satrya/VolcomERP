Public Class FormFGProposePriceSingle
    Private Sub FormFGProposePriceSingle_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        viewData()
    End Sub

    Sub viewData()
        Cursor = Cursors.WaitCursor
        Dim pp As New ClassFGProposePrice()
        Dim data As DataTable = pp.dataCOPList(FormFGProposePriceDetail.SLESeason.EditValue.ToString, FormFGProposePriceDetail.id_source, FormFGProposePriceDetail.id_division, True)
        GCData.DataSource = data
        GVData.BestFitColumns()
        Cursor = Cursors.Default
    End Sub

    Private Sub BtnCancel_Click(sender As Object, e As EventArgs) Handles BtnCancel.Click
        close
    End Sub

    Private Sub FormFGProposePriceSingle_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub CESelAll_CheckedChanged(sender As Object, e As EventArgs) Handles CESelAll.CheckedChanged
        Dim res As String = ""
        If CESelAll.EditValue = True Then
            res = "Yes"
        Else
            res = "No"
        End If

        For i As Integer = 0 To (GVData.RowCount - 1) - GetGroupRowCount(GVData)
            GVData.SetRowCellValue(i, "is_select", res)
        Next
    End Sub

    Private Sub BtnAdd_Click(sender As Object, e As EventArgs) Handles BtnAdd.Click
        makeSafeGV(GVData)
        GVData.ActiveFilterString = "[is_select]='Yes'"
        If GVData.RowCount > 0 Then
            Cursor = Cursors.WaitCursor
            For i As Integer = 0 To GVData.RowCount - 1
                Dim id_design As String = GVData.GetRowCellValue(i, "id_design").ToString
                Dim id_prod_demand_design As String = GVData.GetRowCellValue(i, "id_prod_demand_design").ToString
                Dim id_cop_status As String = GVData.GetRowCellValue(i, "id_cop_status").ToString
                Dim qty As String = decimalSQL(GVData.GetRowCellValue(i, "qty").ToString)
                Dim msrp As String = "0"
                Dim additional_cost As String = decimalSQL(GVData.GetRowCellValue(i, "additional_cost").ToString)
                Dim cop_rate_cat As String = GVData.GetRowCellValue(i, "cop_rate_cat").ToString
                Dim cop_kurs As String = decimalSQL(GVData.GetRowCellValue(i, "cop_kurs").ToString)
                Dim cop_value As String = decimalSQL(GVData.GetRowCellValue(i, "cop_value").ToString)
                Dim cop_mng_kurs As String = decimalSQL(GVData.GetRowCellValue(i, "cop_mng_kurs").ToString)
                Dim cop_mng_value As String = decimalSQL(GVData.GetRowCellValue(i, "cop_mng_value").ToString)
                Dim price As String = "0"
                Dim sale_price As String = "0"
                Dim additional_price As String = "0"
                Dim id_design_price_type_master As String = "1"
                Dim id_design_price_type_print As String = "1"
                Dim remark As String = ""


                Dim query As String = "INSERT INTO tb_fg_propose_price_detail (
	                `id_fg_propose_price`,
	                `id_design`,
	                `id_prod_demand_design`,
	                `id_cop_status`,
                    `qty`,
	                `msrp`,
	                `additional_cost`,
	                `cop_date`,
	                `cop_rate_cat`,
	                `cop_kurs`,
	                `cop_value`,
	                `cop_mng_kurs` ,
	                `cop_mng_value`,
	                `price`,
                    `sale_price`,
	                `additional_price`,
                    `id_design_price_type_master`,
                    `id_design_price_type_print`,
	                `remark` 
                ) VALUES(
	                '" + FormFGProposePriceDetail.id + "',
	                '" + id_design + "',
	                '" + id_prod_demand_design + "',
	                '" + id_cop_status + "',
                    '" + qty + "',
	                '" + msrp + "',
	                '" + additional_cost + "',
	                NOW(),
	                '" + cop_rate_cat + "',
	                '" + cop_kurs + "',
	                '" + cop_value + "',
	                '" + cop_mng_kurs + "' ,
	                '" + cop_mng_value + "',
	                '" + price + "',
                    '" + sale_price + "',
	                '" + additional_price + "',
                    '" + id_design_price_type_master + "',
                    '" + id_design_price_type_print + "',
	                '" + remark + "' 
                )"
                execute_non_query(query, True, "", "", "", "")
            Next
            FormFGProposePriceDetail.viewDetail(False)
            viewData()
            Cursor = Cursors.Default
        Else
            stopCustom("No data selected")
        End If
        GVData.ActiveFilterString = ""
    End Sub
End Class