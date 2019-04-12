Public Class FormSalesReportTrackingParam
    Dim id_comp_cat_store As String = "-1"
    Public id_comp As String = "0"
    Public id_store_contact_from As String = "0"
    Public is_load As Boolean = False

    Private Sub TxtCodeCompFrom_KeyDown(sender As Object, e As KeyEventArgs) Handles TxtCodeCompFrom.KeyDown
        If e.KeyCode = Keys.Enter Then
            Dim query As String = "Select dr.id_wh_drawer, rack.id_wh_rack, Loc.id_wh_locator, cc.id_comp_contact, cc.id_comp, c.npwp, c.comp_number, c.comp_name, c.comp_commission, c.address_primary, c.id_so_type "
            query += " From tb_m_comp_contact cc "
            query += " INNER JOIN tb_m_comp c On c.id_comp=cc.id_comp"
            query += " INNER JOIN tb_m_wh_drawer dr ON dr.id_wh_drawer=c.id_drawer_def"
            query += " INNER JOIN tb_m_wh_rack rack ON rack.id_wh_rack=dr.id_wh_rack"
            query += " INNER JOIN tb_m_wh_locator loc ON loc.id_wh_locator=rack.id_wh_locator"
            query += " where cc.is_default=1 And c.id_comp_cat='" + id_comp_cat_store + "' AND c.comp_number='" + addSlashes(TxtCodeCompFrom.Text) + "'"
            Dim data As DataTable = execute_query(query, "-1", True, "", "", "", "")

            If data.Rows.Count <= 0 Then
                stopCustom("Store not found.")
                TxtCodeCompFrom.Focus()
            ElseIf data.Rows.Count > 1 Then
                FormPopUpContact.id_pop_up = "85"
                FormPopUpContact.id_cat = id_comp_cat_store
                FormPopUpContact.GVCompany.ActiveFilterString = "[comp_number]='" + addSlashes(TxtCodeCompFrom.Text) + "'"
                FormPopUpContact.ShowDialog()
            Else
                id_comp = data.Rows(0)("id_comp").ToString
                id_store_contact_from = data.Rows(0)("id_comp_contact").ToString
                TxtNameCompFrom.Text = data.Rows(0)("comp_name").ToString
                TxtCodeCompFrom.Text = data.Rows(0)("comp_number").ToString
                '
            End If
        End If
    End Sub

    Private Sub BtnCancel_Click(sender As Object, e As EventArgs) Handles BtnCancel.Click
        Close()
    End Sub

    Private Sub FormSalesReportTrackingParam_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If is_load = False Then
            DEStart.EditValue = Now
            DEEnd.EditValue = Now
            '
            id_comp_cat_store = execute_query("SELECT id_comp_cat_store FROM tb_opt", 0, True, "", "", "", "")
            load_rep()
            load_island()
            load_group()
            load_price_cat()
            load_promo()
            load_division()
            load_season()

            load_price_type()
            '
            is_load = False
        End If
    End Sub

    Sub load_rep()
        Dim query As String = "SELECT 0 as id_employee,'All' as employee_name
                                UNION
                                SELECT emp.id_employee,emp.employee_name FROM tb_m_employee emp
                                INNER JOIN tb_m_departement dep ON dep.id_departement=emp.id_departement
                                WHERE dep.id_departement=(SELECT id_dept_sales_rep FROM tb_opt_sales LIMIT 1) AND id_employee_active='1'
                                ORDER BY employee_name ASC"
        viewLookupQuery(LERepArea, query, 0, "employee_name", "id_employee")
    End Sub

    Sub load_season()
        Dim query As String = "SELECT 0 AS id_code_detail,'All Division' AS display_name
                                UNION
                                SELECT cd.id_code_detail,cd.display_name FROM `tb_m_code_detail` cd WHERE cd.id_code='3'"
        viewLookupQuery(LESeason, query, 0, "display_name", "id_code_detail")
    End Sub

    Sub load_island()
        Dim query As String = "SELECT 'All' as island
                                UNION
                                (SELECT island FROM tb_m_city
                                WHERE NOT ISNULL(island)
                                GROUP BY island ORDER BY island ASC)"
        viewLookupQuery(LEIsland, query, 0, "island", "island")
    End Sub

    Sub load_group()
        Dim query As String = "SELECT '0' as id_comp_group,'All' as comp_group
                                UNION
                                (SELECT id_comp_group,comp_group FROM tb_m_comp_group
                                ORDER BY comp_group ASC)"
        viewLookupQuery(LEGroupAccount, query, 0, "comp_group", "id_comp_group")
    End Sub

    Sub load_price_cat()
        Dim query As String = "SELECT 0 AS id_design_cat,'ALL' AS design_cat
                                UNION
                                SELECT * FROM `tb_lookup_design_cat`"
        viewLookupQuery(LEPriceCat, query, 0, "design_cat", "id_design_cat")
    End Sub

    Sub load_promo()
        Dim query As String = "SELECT 0 AS id_promo,'Include Promo' AS promo
                                UNION
                                SELECT 2 AS id_promo,'Not Include Promo' AS promo"
        viewLookupQuery(LEPromo, query, 0, "promo", "id_promo")
    End Sub

    Sub load_division()
        Dim query As String = "SELECT 0 AS id_code_detail,'All Division' AS display_name
                                UNION
                                SELECT cd.id_code_detail,cd.display_name FROM `tb_m_code_detail` cd WHERE cd.id_code='32'"
        viewLookupQuery(LEDivision, query, 0, "display_name", "id_code_detail")
    End Sub

    Sub load_price_type()
        Dim query As String = "SELECT 1 AS id_price_type,'Normal' AS price_type
                                UNION
                                SELECT 2 AS id_price_type,'Update' AS price_type
                                UNION
                                SELECT 3 AS id_price_type,'As it is' AS price_type"
        viewLookupQuery(LEPRiceType, query, 0, "price_type", "id_price_type")
    End Sub

    Private Sub BtnSave_Click(sender As Object, e As EventArgs) Handles BtnSave.Click
        Dim date_start, date_end, id_rep, island, id_group, id_price_cat, id_promo, id_season, id_division, id_price_type As String

        date_start = Date.Parse(DEStart.EditValue.ToString).ToString("yyyy-MM-dd")
        date_end = Date.Parse(DEEnd.EditValue.ToString).ToString("yyyy-MM-dd")
        FormSalesReportTracking.var_periode = Date.Parse(DEStart.EditValue.ToString).ToString("dd MMMM yyyy") & " until " & Date.Parse(DEEnd.EditValue.ToString).ToString("dd MMMM yyyy")

        id_rep = LERepArea.EditValue.ToString
        FormSalesReportTracking.var_rep_area = LERepArea.Text.ToString

        island = LEIsland.EditValue.ToString
        FormSalesReportTracking.var_island = LEIsland.Text.ToString

        id_group = LEGroupAccount.EditValue.ToString
        FormSalesReportTracking.var_grup = LEGroupAccount.Text.ToString

        id_price_cat = LEPriceCat.EditValue.ToString
        FormSalesReportTracking.var_price_cat = LEPriceCat.Text.ToString

        id_promo = LEPromo.EditValue.ToString
        FormSalesReportTracking.var_promo = LEPromo.Text.ToString

        id_season = LESeason.EditValue.ToString
        FormSalesReportTracking.var_season = LESeason.Text.ToString

        id_division = LEDivision.EditValue.ToString
        FormSalesReportTracking.var_division = LEDivision.Text.ToString

        id_price_type = LEPRiceType.EditValue.ToString
        FormSalesReportTracking.var_prc_type = LEPRiceType.Text.ToString
        '
        If id_comp = "0" Then
            FormSalesReportTracking.var_store = "All Store"
        Else
            FormSalesReportTracking.var_store = TxtCodeCompFrom.Text & " - " & TxtNameCompFrom.Text
        End If
        '
        FormSalesReportTracking.load_data(id_comp, date_start, date_end, id_rep, island, id_group, id_price_cat, id_promo, id_division, id_season, id_price_type)

        Close()
    End Sub

    Private Sub FormSalesReportTrackingParam_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed

    End Sub

    Private Sub BtnBrowseContactFrom_Click(sender As Object, e As EventArgs) Handles BtnBrowseContactFrom.Click
        FormPopUpContact.id_pop_up = "85"
        FormPopUpContact.id_cat = id_comp_cat_store
        FormPopUpContact.ShowDialog()
    End Sub

    Private Sub BReset_Click(sender As Object, e As EventArgs) Handles BReset.Click
        id_comp = "0"
        TxtCodeCompFrom.Text = ""
        TxtNameCompFrom.Text = ""
    End Sub
End Class