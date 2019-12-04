Public Class FormProductionFinalClear
    Dim bnew_active As String = "1"
    Dim bedit_active As String = "1"
    Dim bdel_active As String = "1"

    Private Sub FormProductionFinalClear_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        viewVendor()

        Dim data_dt As DataTable = execute_query("SELECT DATE(NOW()) AS `dt`", -1, True, "", "", "", "")
        DEFrom.EditValue = data_dt.Rows(0)("dt")
        DEUntil.EditValue = data_dt.Rows(0)("dt")
        DEFromSum.EditValue = data_dt.Rows(0)("dt")
        DEUntilSum.EditValue = data_dt.Rows(0)("dt")
        DEFrom.Focus()
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

    Private Sub DEFrom_KeyDown(sender As Object, e As KeyEventArgs) Handles DEFrom.KeyDown
        If e.KeyCode = Keys.Enter Then
            DEUntil.Focus()
        End If
    End Sub

    Private Sub DEUntil_KeyDown(sender As Object, e As KeyEventArgs) Handles DEUntil.KeyDown
        If e.KeyCode = Keys.Enter Then
            BtnView.Focus()
        End If
    End Sub

    Sub viewFinalClear()
        Cursor = Cursors.WaitCursor
        'Prepare paramater
        Dim date_from_selected As String = "0000-01-01"
        Dim date_until_selected As String = "9999-01-01"
        Try
            date_from_selected = DateTime.Parse(DEFrom.EditValue.ToString).ToString("yyyy-MM-dd")
        Catch ex As Exception
        End Try

        Try
            date_until_selected = DateTime.Parse(DEUntil.EditValue.ToString).ToString("yyyy-MM-dd")
        Catch ex As Exception
        End Try

        'prepare query
        Dim query_c As ClassProductionFinalClear = New ClassProductionFinalClear()
        Dim query As String = query_c.queryMain("AND (f.prod_fc_date>='" + date_from_selected + "' AND f.prod_fc_date<='" + date_until_selected + "') ", "2")
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCFinalClear.DataSource = data
        GVFinalClear.BestFitColumns()
        check_menu()
        Cursor = Cursors.Default
    End Sub

    Private Sub BtnView_Click(sender As Object, e As EventArgs) Handles BtnView.Click
        viewFinalClear()
    End Sub

    Private Sub FormProductionFinalClear_Activated(sender As Object, e As EventArgs) Handles MyBase.Activated
        FormMain.show_rb(Name)
        check_menu()
    End Sub

    Sub noManipulating()
        If XTCQCReport.SelectedTabPageIndex = 0 Then
            Try
                Dim indeks As Integer = GVFinalClear.FocusedRowHandle
                If indeks < 0 Then
                    bnew_active = "1"
                    bedit_active = "0"
                    bdel_active = "0"
                Else
                    bnew_active = "1"
                    bedit_active = "1"
                    bdel_active = "0"
                End If
                checkFormAccess(Name)
                button_main(bnew_active, bedit_active, bdel_active)
            Catch ex As Exception
            End Try
        ElseIf XTCQCReport.SelectedTabPageIndex = 1 Then
            Dim indeks As Integer = -1
            Try
                indeks = GVFinalClear.FocusedRowHandle
            Catch ex As Exception
            End Try
            If indeks < 0 Then
                bnew_active = "1"
                bedit_active = "0"
                bdel_active = "0"
            Else
                bnew_active = "1"
                bedit_active = "1"
                bdel_active = "0"
            End If
            checkFormAccess(Name)
            button_main(bnew_active, bedit_active, bdel_active)
        ElseIf XTCQCReport.SelectedTabPageIndex = 2 Then
            Dim indeks As Integer = -1
            Try
                indeks = GVSum.FocusedRowHandle
            Catch ex As Exception
            End Try
            If indeks < 0 Then
                bnew_active = "1"
                bedit_active = "0"
                bdel_active = "0"
            Else
                bnew_active = "1"
                bedit_active = "1"
                bdel_active = "0"
            End If
            checkFormAccess(Name)
            button_main(bnew_active, bedit_active, bdel_active)
        End If
    End Sub

    Sub check_menu()
        If XTCQCReport.SelectedTabPageIndex = 0 Then
            If GVFinalClear.RowCount < 1 Then
                'hide all except new
                bnew_active = "0"
                bedit_active = "0"
                bdel_active = "0"
                checkFormAccess(Name)
                button_main(bnew_active, bedit_active, bdel_active)
            Else
                'show all
                bnew_active = "1"
                bedit_active = "1"
                bdel_active = "0"
                noManipulating()
            End If
        ElseIf XTCQCReport.SelectedTabPageIndex = 1 Then
            If GVProd.RowCount < 1 Then
                bnew_active = "0"
                bedit_active = "0"
                bdel_active = "0"
                checkFormAccess(Name)
                button_main(bnew_active, bedit_active, bdel_active)
            Else
                noManipulating()
            End If
        ElseIf XTCQCReport.SelectedTabPageIndex = 2 Then
            If GVSum.RowCount < 1 Then
                bnew_active = "1"
                bedit_active = "0"
                bdel_active = "0"
                checkFormAccess(Name)
                button_main(bnew_active, bedit_active, bdel_active)
            Else
                noManipulating()
            End If
        End If
    End Sub

    Private Sub GVFinalClear_FocusedRowChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles GVFinalClear.FocusedRowChanged
        noManipulating()
    End Sub

    Private Sub GVFinalClear_DoubleClick(sender As Object, e As EventArgs) Handles GVFinalClear.DoubleClick
        If GVFinalClear.RowCount > 0 And GVFinalClear.FocusedRowHandle >= 0 Then
            FormMain.but_edit()
        End If
    End Sub

    Private Sub FormProductionFinalClear_Deactivate(sender As Object, e As EventArgs) Handles MyBase.Deactivate
        FormMain.hide_rb()
    End Sub

    Private Sub XTCQCReport_SelectedPageChanged(sender As Object, e As DevExpress.XtraTab.TabPageChangedEventArgs) Handles XTCQCReport.SelectedPageChanged
        check_menu()
    End Sub

    Private Sub BSearch_Click(sender As Object, e As EventArgs) Handles BSearch.Click
        viewOrderList()
    End Sub

    Sub viewOrderList()
        Cursor = Cursors.WaitCursor
        Dim cond As String = ""
        If SLEVendor.EditValue.ToString <> "0" Then
            cond = "AND comp.id_comp='" + SLEVendor.EditValue.ToString + "' "
        End If

        Dim query As String = "SELECT po.id_prod_order, po.prod_order_number, po.prod_order_date, CONCAT(comp.comp_number,' - ', comp.comp_name) AS `vendor`, 
        d.design_code, d.design_display_name, ss.season, po.id_report_status
        FROM tb_prod_order po
        INNER JOIN tb_prod_order_wo wo On wo.id_prod_order = po.id_prod_order AND wo.is_main_vendor='1' AND wo.id_report_status!=5
        INNER JOIN tb_m_ovh_price ovh_p ON ovh_p.id_ovh_price = wo.id_ovh_price
        INNER JOIN tb_m_comp_contact cc ON cc.id_comp_contact=ovh_p.id_comp_contact 
        INNER JOIN tb_m_comp comp ON comp.id_comp=cc.id_comp 
        INNER JOIN tb_prod_demand_design pdd ON pdd.id_prod_demand_design = po.id_prod_demand_design
        INNER JOIN tb_m_design d ON d.id_design = pdd.id_design
        INNER JOIN tb_season_delivery del ON del.id_delivery = po.id_delivery
        INNER JOIN tb_season ss ON ss.id_season = del.id_season
        WHERE po.id_report_status=6 AND po.is_closing_rec=2
        " + cond + "
        ORDER BY po.id_prod_order ASC "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCProd.DataSource = data
        GVProd.BestFitColumns()
        check_menu()
        Cursor = Cursors.Default
    End Sub

    Private Sub SLEVendor_EditValueChanged(sender As Object, e As EventArgs) Handles SLEVendor.EditValueChanged
        GCProd.DataSource = Nothing
    End Sub

    Sub viewSummaryPropose()
        Dim date_from_selected As String = "0000-01-01"
        Dim date_until_selected As String = "9999-01-01"

        Try
            date_from_selected = DateTime.Parse(DEFromSum.EditValue.ToString).ToString("yyyy-MM-dd")
        Catch ex As Exception
        End Try

        Try
            date_until_selected = DateTime.Parse(DEUntilSum.EditValue.ToString).ToString("yyyy-MM-dd")
        Catch ex As Exception
        End Try

        Dim where_date_from As String = ""
        Dim where_date_until As String = ""

        If Not date_from_selected = "" Then
            where_date_from = "AND created_date >= '" + date_from_selected + " 00:00:00'"
        End If

        If Not date_until_selected = "" Then
            where_date_until = "AND created_date <= '" + date_until_selected + " 23:59:59'"
        End If

        Dim query As String = "
            SELECT fc_sum.id_prod_fc_sum, fc_sum.number, created_by.employee_name AS created_by, DATE_FORMAT(fc_sum.created_date, '%d %b %Y %H:%i:%s') AS created_date, updated_by.employee_name AS updated_by, DATE_FORMAT(fc_sum.updated_date, '%d %b %Y %H:%i:%s') AS updated_date, IF(fc_sum.id_report_status = 0, 'Draft', sts.report_status) AS report_status
            FROM tb_prod_fc_sum AS fc_sum
            LEFT JOIN (
                SELECT usr.id_user, emp.employee_name
                FROM tb_m_user AS usr
                LEFT JOIN tb_m_employee AS emp ON usr.id_employee = emp.id_employee
            ) AS created_by ON fc_sum.created_by = created_by.id_user
            LEFT JOIN (
                SELECT usr.id_user, emp.employee_name
                FROM tb_m_user AS usr
                LEFT JOIN tb_m_employee AS emp ON usr.id_employee = emp.id_employee
            ) AS updated_by ON fc_sum.updated_by = updated_by.id_user
            LEFT JOIN tb_lookup_report_status AS sts ON fc_sum.id_report_status = sts.id_report_status
            WHERE 1 " + where_date_from + " " + where_date_until + "
            ORDER BY fc_sum.id_prod_fc_sum DESC
        "

        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")

        GCSum.DataSource = data

        GVSum.BestFitColumns()
    End Sub

    Private Sub BtnViewSum_Click(sender As Object, e As EventArgs) Handles BtnViewSum.Click
        viewSummaryPropose()
    End Sub

    Private Sub GVSum_FocusedRowChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles GVSum.FocusedRowChanged
        noManipulating()
    End Sub

    Private Sub GVSum_DoubleClick(sender As Object, e As EventArgs) Handles GVSum.DoubleClick
        Try
            FormProductionFinalClearSummary.id_prod_fc_sum = GVSum.GetFocusedRowCellValue("id_prod_fc_sum").ToString
            FormProductionFinalClearSummary.is_vew = "0"
            FormProductionFinalClearSummary.ShowDialog()
        Catch ex As Exception
        End Try
    End Sub
End Class