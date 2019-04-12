Public Class FormFGProposePrice 
    Dim bnew_active As String = "1"
    Dim bedit_active As String = "1"
    Dim bdel_active As String = "1"
    Dim is_first_load_compare As Boolean = True

    Private Sub FormFGProposePrice_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim dt_now As DataTable = execute_query("SELECT DATE(NOW()) as tgl", -1, True, "", "", "", "")
        DEFromList.EditValue = dt_now.Rows(0)("tgl")
        DEUntilList.EditValue = dt_now.Rows(0)("tgl")
        DEFromRev.EditValue = dt_now.Rows(0)("tgl")
        DEUntilRev.EditValue = dt_now.Rows(0)("tgl")
    End Sub

    Sub viewPropose()
        Cursor = Cursors.WaitCursor

        'date
        Dim date_from_selected As String = "0000-01-01"
        Dim date_until_selected As String = "9999-01-01"
        Try
            date_from_selected = DateTime.Parse(DEFromList.EditValue.ToString).ToString("yyyy-MM-dd")
        Catch ex As Exception
        End Try
        Try
            date_until_selected = DateTime.Parse(DEUntilList.EditValue.ToString).ToString("yyyy-MM-dd")
        Catch ex As Exception
        End Try
        Dim cond As String = "AND (fg_propose_price_date>=''" + date_from_selected + "'' AND fg_propose_price_date<=''" + date_until_selected + "'') "

        Dim query_c As ClassFGProposePrice = New ClassFGProposePrice()
        Dim query As String = query_c.queryMain(cond, "2")
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCFGPropose.DataSource = data
        GVFGPropose.BestFitColumns()
        check_menu()
        Cursor = Cursors.Default
    End Sub

    Sub viewRevision()
        Cursor = Cursors.WaitCursor

        'date
        Dim date_from_selected As String = "0000-01-01"
        Dim date_until_selected As String = "9999-01-01"
        Try
            date_from_selected = DateTime.Parse(DEFromRev.EditValue.ToString).ToString("yyyy-MM-dd")
        Catch ex As Exception
        End Try
        Try
            date_until_selected = DateTime.Parse(DEUntilRev.EditValue.ToString).ToString("yyyy-MM-dd")
        Catch ex As Exception
        End Try
        Dim cond As String = "AND (DATE(ppr.created_date)>='" + date_from_selected + "' AND DATE(ppr.created_date)<='" + date_until_selected + "') "

        Dim pp As ClassFGProposePrice = New ClassFGProposePrice()
        Dim data As DataTable = pp.dataMainRev(cond, "2")
        GCRev.DataSource = data
        GVRev.BestFitColumns()
        check_menu()
        Cursor = Cursors.Default
    End Sub

    Private Sub FormFGProposePrice_Activated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Activated
        FormMain.show_rb(Name)
        check_menu()
    End Sub

    Private Sub FormFGProposePrice_Deactivate(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Deactivate
        FormMain.hide_rb()
    End Sub

    Sub check_menu()
        If XTCPropose.SelectedTabPageIndex = 0 Then
            If GVFGPropose.RowCount < 1 Then
                'hide all except new
                bnew_active = "1"
                bedit_active = "0"
                bdel_active = "0"
                checkFormAccess(Name)
                button_main(bnew_active, bedit_active, bdel_active)
            Else
                'show all
                bnew_active = "1"
                bedit_active = "1"
                bdel_active = "1"
                noManipulating()
            End If
        ElseIf XTCPropose.SelectedTabPageIndex = 1 Then
            If GVRev.RowCount < 1 Then
                'hide all except new
                bnew_active = "1"
                bedit_active = "0"
                bdel_active = "0"
                checkFormAccess(Name)
                button_main(bnew_active, bedit_active, bdel_active)
            Else
                'show all
                bnew_active = "1"
                bedit_active = "1"
                bdel_active = "1"
                noManipulating()
            End If
        ElseIf XTCPropose.SelectedTabPageIndex = 2 Then
            If GVCompare.RowCount < 1 Then
                'hide all except new
                bnew_active = "0"
                bedit_active = "0"
                bdel_active = "0"
                checkFormAccess(Name)
                button_main(bnew_active, bedit_active, bdel_active)
            Else
                'show all
                bnew_active = "0"
                bedit_active = "0"
                bdel_active = "0"
                noManipulating()
            End If
        End If
    End Sub

    Sub noManipulating()
        If XTCPropose.SelectedTabPageIndex = 0 Then
            Dim indeks As Integer = -1
            Try
                indeks = GVFGPropose.FocusedRowHandle
            Catch ex As Exception
            End Try
            If indeks < 0 Then
                bnew_active = "1"
                bedit_active = "0"
                bdel_active = "0"
            Else
                bnew_active = "1"
                bedit_active = "1"
                bdel_active = "1"
            End If
            checkFormAccess(Name)
            button_main(bnew_active, bedit_active, bdel_active)
        ElseIf XTCPropose.SelectedTabPageIndex = 1 Then
            Dim indeks As Integer = -1
            Try
                indeks = GVRev.FocusedRowHandle
            Catch ex As Exception
            End Try
            If indeks < 0 Then
                bnew_active = "1"
                bedit_active = "0"
                bdel_active = "0"
            Else
                bnew_active = "1"
                bedit_active = "1"
                bdel_active = "1"
            End If
            checkFormAccess(Name)
            button_main(bnew_active, bedit_active, bdel_active)
        ElseIf XTCPropose.SelectedTabPageIndex = 2 Then
            Dim indeks As Integer = -1
            Try
                indeks = GVCompare.FocusedRowHandle
            Catch ex As Exception
            End Try
            If indeks < 0 Then
                bnew_active = "0"
                bedit_active = "0"
                bdel_active = "0"
            Else
                bnew_active = "0"
                bedit_active = "0"
                bdel_active = "0"
            End If
            checkFormAccess(Name)
            button_main(bnew_active, bedit_active, bdel_active)
        End If
    End Sub

    Private Sub GVFGPropose_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GVFGPropose.DoubleClick
        If GVFGPropose.RowCount > 0 And GVFGPropose.FocusedRowHandle >= 0 Then
            Cursor = Cursors.WaitCursor
            FormMain.but_edit()
            Cursor = Cursors.Default
        End If
    End Sub

    Private Sub BtnListCOP_Click(sender As Object, e As EventArgs) Handles BtnListCOP.Click
        Cursor = Cursors.WaitCursor
        FormFGProposePriceCOPList.ShowDialog()
        Cursor = Cursors.Default
    End Sub

    Private Sub BtnViewList_Click(sender As Object, e As EventArgs) Handles BtnViewList.Click
        viewPropose()
    End Sub

    Sub viewSeason()
        Dim query As String = "(SELECT a.id_season, a.season, b.range AS `range` FROM tb_season a 
                                INNER JOIN tb_range b ON a.id_range = b.id_range 
                                ORDER BY b.range ASC)"
        viewSearchLookupQuery(SLESeason, query, "id_season", "season", "id_season")
    End Sub

    Sub view_division_fg()
        Dim id_code As String = get_setup_field("id_code_fg_division")
        Dim query As String = "SELECT id_code_detail,code_detail_name,display_name 
        FROM tb_m_code_detail a WHERE a.id_code='" + id_code + "' ORDER BY id_code_detail ASC "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        viewLookupQuery(LEDivision, query, 0, "display_name", "id_code_detail")
    End Sub

    Sub view_source_fg()
        Dim id_code As String = get_setup_field("id_code_fg_source")
        Dim query As String = "SELECT (id_code_detail) AS id_source, (code_detail_name) AS source, display_name FROM tb_m_code_detail a WHERE a.id_code='" + id_code + "' HAVING source<>'-' ORDER BY a.id_code_detail "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        viewLookupQuery(LESource, query, 0, "display_name", "id_source")
    End Sub

    Private Sub XTCPropose_SelectedPageChanged(sender As Object, e As DevExpress.XtraTab.TabPageChangedEventArgs) Handles XTCPropose.SelectedPageChanged
        check_menu()

        If XTCPropose.SelectedTabPageIndex = 0 Then
        ElseIf XTCPropose.SelectedTabPageIndex = 1 Then

        ElseIf XTCPropose.SelectedTabPageIndex = 2 Then
            If is_first_load_compare Then
                viewSeason()
                view_division_fg()
                view_source_fg()
                is_first_load_compare = False
            End If
        End If
    End Sub

    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs) Handles SimpleButton1.Click
        viewCompare()
    End Sub

    Sub viewCompare()
        Cursor = Cursors.WaitCursor
        Dim query As String = "SELECT pp.id_fg_propose_price, 70 AS `rmt`, pp.markup_target, pp.fg_propose_price_number, ppd.id_design, d.design_code AS `code`, d.design_display_name AS `name`, sc.size_chart,
        ppd.id_cop_status, cs.cop_status, ppd.additional_cost, IF(ppd.cop_rate_cat=1,'BOM', 'Payment') AS `rate_cat`, ppd.cop_kurs, ppd.cop_value, ppd.price, ppd.additional_price,
        IF(d.final_is_approve=1,IF(ppd.cop_rate_cat=1,'BOM', 'Payment'),'-') AS `final_rate_cat`,
        IF(d.final_is_approve=1,d.final_cop_kurs,0) AS `final_cop_kurs`,
        IF(d.final_is_approve=1,d.final_cop_value,0) AS `final_cop_value`,
        IF(d.final_is_approve=1,d.design_cop_addcost,0) AS `final_additional_cost`,
        pp.id_pp_type, pty.pp_type
        FROM tb_fg_propose_price pp
        INNER JOIN tb_fg_propose_price_detail ppd ON ppd.id_fg_propose_price = pp.id_fg_propose_price
        INNER JOIN tb_m_design d ON d.id_design = ppd.id_design
        LEFT JOIN (
          SELECT pdp.id_prod_demand_design, GROUP_CONCAT(DISTINCT cd.code_detail_name ORDER BY cd.id_code_detail ASC SEPARATOR ',') AS `size_chart`
          FROM tb_prod_demand_product pdp
          INNER JOIN tb_m_product prod ON prod.id_product = pdp.id_product
          INNER JOIN tb_m_product_code prod_code ON prod_code.id_product = prod.id_product
          INNER JOIN tb_m_code_detail cd ON cd.id_code_detail = prod_code.id_code_detail
          GROUP BY pdp.id_prod_demand_design
        ) sc ON sc.id_prod_demand_design = ppd.id_prod_demand_design
        INNER JOIN tb_lookup_cop_status cs ON cs.id_cop_status = ppd.id_cop_status
        INNER JOIN tb_lookup_pp_type pty ON pty.id_pp_type = pp.id_pp_type
        WHERE ppd.is_active=1 AND pp.id_report_status=6 AND pp.id_season=" + SLESeason.EditValue.ToString + " AND pp.id_source=" + LESource.EditValue.ToString + " AND pp.id_division=" + LEDivision.EditValue.ToString + " "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCCompare.DataSource = data
        GVCompare.BestFitColumns()
        Cursor = Cursors.Default
    End Sub

    Private Sub SLESeason_EditValueChanged(sender As Object, e As EventArgs) Handles SLESeason.EditValueChanged
        GCCompare.DataSource = Nothing
    End Sub

    Private Sub LESource_EditValueChanged(sender As Object, e As EventArgs) Handles LESource.EditValueChanged
        GCCompare.DataSource = Nothing
    End Sub

    Private Sub LEDivision_EditValueChanged(sender As Object, e As EventArgs) Handles LEDivision.EditValueChanged
        GCCompare.DataSource = Nothing
    End Sub

    Private Sub GVCompare_RowCellStyle(sender As Object, e As DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs) Handles GVCompare.RowCellStyle
        If e.RowHandle >= 0 Then
            If (e.Column.FieldName = "markup") Then
                Dim val As Decimal = 0
                Try
                    val = sender.GetRowCellValue(e.RowHandle, sender.Columns("markup"))
                Catch ex As Exception
                End Try

                Dim std As Decimal = 0
                Try
                    std = sender.GetRowCellValue(e.RowHandle, sender.Columns("markup_target"))
                Catch ex As Exception
                End Try


                If val >= std Then
                    e.Appearance.BackColor = Color.LightSeaGreen
                    e.Appearance.BackColor2 = Color.LightSeaGreen
                Else
                    e.Appearance.BackColor = Color.Crimson
                    e.Appearance.BackColor2 = Color.Crimson
                End If
            ElseIf (e.Column.FieldName = "final_markup") Then
                Dim val As Decimal = 0
                Try
                    val = sender.GetRowCellValue(e.RowHandle, sender.Columns("final_markup"))
                Catch ex As Exception
                End Try

                Dim std As Decimal = 0
                Try
                    std = sender.GetRowCellValue(e.RowHandle, sender.Columns("markup_target"))
                Catch ex As Exception
                End Try


                If val >= std Then
                    e.Appearance.BackColor = Color.LightSeaGreen
                    e.Appearance.BackColor2 = Color.LightSeaGreen
                Else
                    e.Appearance.BackColor = Color.Crimson
                    e.Appearance.BackColor2 = Color.Crimson
                End If
            End If
        End If
    End Sub

    Private Sub RepoPPNumber_Click(sender As Object, e As EventArgs) Handles RepoPPNumber.Click
        If GVCompare.RowCount > 0 And GVCompare.FocusedRowHandle >= 0 Then
            Dim m As New ClassShowPopUp()
            m.id_report = GVCompare.GetFocusedRowCellValue("id_fg_propose_price").ToString
            m.report_mark_type = GVCompare.GetFocusedRowCellValue("rmt").ToString
            m.show()
        End If
    End Sub

    Private Sub SimpleButton3_Click(sender As Object, e As EventArgs) Handles BtnViewRevision.Click
        viewRevision()
    End Sub

    Private Sub GVRev_DoubleClick(sender As Object, e As EventArgs) Handles GVRev.DoubleClick
        If GVRev.RowCount > 0 And GVRev.FocusedRowHandle >= 0 Then
            FormMain.but_edit()
        End If
    End Sub
End Class