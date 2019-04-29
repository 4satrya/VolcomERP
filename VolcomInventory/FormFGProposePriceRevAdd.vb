Public Class FormFGProposePriceRevAdd
    Dim id_rev_det As String = ""

    Private Sub BtnCancel_Click(sender As Object, e As EventArgs) Handles BtnCancel.Click
        Close()
    End Sub

    Private Sub FormFGProposePriceRevAdd_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        viewData()
    End Sub

    Sub viewData()
        Cursor = Cursors.WaitCursor
        Dim query As String = "SELECT ppd.id_fg_propose_price_detail, 
        ppd.id_design, d.design_code AS `code`, d.design_display_name AS `name`,
        ppd.id_prod_demand_design, ppd.msrp,ppd.price, ppd.additional_price 
        FROM tb_fg_propose_price_detail ppd
        INNER JOIN tb_m_design d ON d.id_design = ppd.id_design
        WHERE ppd.id_fg_propose_price='" + FormFGProposePriceRev.id_pp + "' AND ppd.is_active=1 "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCData.DataSource = data
        GVData.BestFitColumns()
        Cursor = Cursors.Default
    End Sub


    Private Sub FormFGProposePriceRevAdd_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub BtnAdd_Click(sender As Object, e As EventArgs) Handles BtnAdd.Click
        makeSafeGV(GVData)
        Dim id_fg_propose_price_detail As String = GVData.GetFocusedRowCellValue("id_fg_propose_price_detail").ToString

        'check exist
        Dim is_found_exist As Boolean = False
        Dim qcek As String = "SELECT * FROM tb_fg_propose_price_rev_det rd WHERE rd.id_fg_propose_price_rev='" + FormFGProposePriceRev.id + "' AND rd.id_fg_propose_price_detail='" + id_fg_propose_price_detail + "'"
        Dim dcek As DataTable = execute_query(qcek, -1, True, "", "", "", "")
        If dcek.Rows.Count > 0 Then
            is_found_exist = True
        End If

        If is_found_exist Then
            stopCustom("Already exist")
        Else
            Dim id_design As String = GVData.GetFocusedRowCellValue("id_design").ToString
            Dim id_prod_demand_design As String = GVData.GetFocusedRowCellValue("id_prod_demand_design").ToString
            Dim msrp As String = decimalSQL(GVData.GetFocusedRowCellValue("msrp").ToString)
            Dim price As String = decimalSQL(GVData.GetFocusedRowCellValue("price").ToString)
            Dim additional_price As String = decimalSQL(GVData.GetFocusedRowCellValue("additional_price").ToString)
            Dim id_pd_status_rev As String = "1"
            Dim query As String = "INSERT INTO tb_fg_propose_price_rev_det(
            `id_fg_propose_price_rev` ,
            `id_fg_propose_price_detail` ,
            `id_design`,
            `id_prod_demand_design`,
            `id_cop_status` ,
            `qty`,
            `additional_cost` ,
            `cop_date` ,
            `cop_rate_cat` ,
            `cop_kurs` ,
            `cop_value` ,
            `cop_mng_kurs` ,
            `cop_mng_value`,
            `msrp` ,
            `price`,
            `sale_price`,
            `additional_price`,
            `remark` ,
            `id_pd_status_rev` ,
            `id_design_price_type_master`,
            `id_design_price_type_print`
            )
            SELECT '" + FormFGProposePriceRev.id + "' ,
                `id_fg_propose_price_detail` ,
                `id_design`,
                `id_prod_demand_design`,
                `id_cop_status` ,
                `qty`,
                `additional_cost` ,
                `cop_date` ,
                `cop_rate_cat` ,
                `cop_kurs` ,
                `cop_value` ,
                `cop_mng_kurs` ,
                `cop_mng_value`,
                `msrp` ,
                `price`,
                `sale_price`,
                `additional_price`,
                `remark` ,
                1,
                `id_design_price_type_master`,
                `id_design_price_type_print`
            FROM tb_fg_propose_price_detail ppd
            WHERE ppd.id_fg_propose_price_detail='" + id_fg_propose_price_detail + "'; SELECT LAST_INSERT_ID(); "
            Dim id_det As String = execute_query(query, 0, True, "", "", "", "")
            If id_rev_det <> "" Then
                id_rev_det += "OR "
            End If
            id_rev_det += "[id_fg_propose_price_rev_det]='" + id_det + "' "
            FormFGProposePriceRev.viewDetail()
        End If
    End Sub

    Private Sub FormFGProposePriceRevAdd_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        If id_rev_det <> "" Then
            'refresh
            makeSafeGV(FormFGProposePriceRev.GVRevision)
            FormFGProposePriceRev.viewDetail()

            'filter for update COP
            FormFGProposePriceRev.GVRevision.ActiveFilterString = id_rev_det
            FormFGProposePriceRev.CESelAll.EditValue = False
            FormFGProposePriceRev.CESelAll.EditValue = True
            FormFGProposePriceRev.updateCOP()
            makeSafeGV(FormFGProposePriceRev.GVRevision)
            FormFGProposePriceRev.CESelAll.EditValue = False
        End If
    End Sub
End Class