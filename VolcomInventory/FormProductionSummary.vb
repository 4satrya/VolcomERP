Public Class FormProductionSummary
    Private Sub FormProductionSummary_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim data_dt As DataTable = execute_query("SELECT DATE(NOW()) AS `dt`", -1, True, "", "", "", "")
        DEFrom.EditValue = data_dt.Rows(0)("dt")
        DEUntil.EditValue = data_dt.Rows(0)("dt")
        DEFromPD.EditValue = data_dt.Rows(0)("dt")
        DEUntilPD.EditValue = data_dt.Rows(0)("dt")
        DEFromMat.EditValue = data_dt.Rows(0)("dt")
        DEUntilMat.EditValue = data_dt.Rows(0)("dt")
        DEFrom.Focus()

        viewVendor()
    End Sub

    Private Sub FormProductionSummary_Activated(sender As Object, e As EventArgs) Handles MyBase.Activated
        FormMain.show_rb(Name)
        checkFormAccess(Name)
    End Sub

    Private Sub FormProductionSummary_Deactivate(sender As Object, e As EventArgs) Handles MyBase.Deactivate
        FormMain.hide_rb()
    End Sub

    Sub viewApprovedPO()
        Cursor = Cursors.WaitCursor
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

        Dim query As String = "CALL view_po_approved('" + date_from_selected + "', '" + date_until_selected + "', '" + id_user + "')"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCDesign.DataSource = data
        Cursor = Cursors.Default
    End Sub

    Private Sub BtnView_Click(sender As Object, e As EventArgs) Handles BtnView.Click
        viewApprovedPO()
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

    Sub viewPOMat()
        Cursor = Cursors.WaitCursor
        Dim date_from_selected As String = "0000-01-01"
        Dim date_until_selected As String = "9999-01-01"
        Try
            date_from_selected = DateTime.Parse(DEFromMat.EditValue.ToString).ToString("yyyy-MM-dd")
        Catch ex As Exception
        End Try
        Try
            date_until_selected = DateTime.Parse(DEUntilMat.EditValue.ToString).ToString("yyyy-MM-dd")
        Catch ex As Exception
        End Try

        Dim query As String = "CALL view_mat_purc_det_all('" + date_from_selected + "', '" + date_until_selected + "', '" + id_user + "')"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCListPurchase.DataSource = data
        Cursor = Cursors.Default
    End Sub

    Private Sub XTCSum_SelectedPageChanged(sender As Object, e As DevExpress.XtraTab.TabPageChangedEventArgs) Handles XTCSum.SelectedPageChanged
        If XTCSum.SelectedTabPageIndex = 0 Then
            DEFrom.Focus()
        ElseIf XTCSum.SelectedTabPageIndex = 1 Then
            DEFromPD.Focus()
        ElseIf XTCSum.SelectedTabPageIndex = 2 Then
            DEFromMat.Focus()
        End If
    End Sub

    Private Sub BtnViewPD_Click(sender As Object, e As EventArgs) Handles BtnViewPD.Click
        viewPD()
    End Sub

    Sub viewPD()
        Cursor = Cursors.WaitCursor
        Dim date_from_selected As String = "0000-01-01"
        Dim date_until_selected As String = "9999-01-01"
        Try
            date_from_selected = DateTime.Parse(DEFromPD.EditValue.ToString).ToString("yyyy-MM-dd")
        Catch ex As Exception
        End Try
        Try
            date_until_selected = DateTime.Parse(DEUntilPD.EditValue.ToString).ToString("yyyy-MM-dd")
        Catch ex As Exception
        End Try

        Dim query As String = "CALL view_pd_list('" + date_from_selected + "', '" + date_until_selected + "', '" + id_user + "')"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCPD.DataSource = data
        Cursor = Cursors.Default
    End Sub

    Private Sub DEFromPD_KeyDown(sender As Object, e As KeyEventArgs) Handles DEFromPD.KeyDown
        If e.KeyCode = Keys.Enter Then
            DEUntilPD.Focus()
        End If
    End Sub

    Private Sub DEUntilPD_KeyDown(sender As Object, e As KeyEventArgs) Handles DEUntilPD.KeyDown
        If e.KeyCode = Keys.Enter Then
            BtnViewPD.Focus()
        End If
    End Sub

    Private Sub FormProductionSummary_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub GVPD_CellValueChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles GVPD.CellValueChanged
        Cursor = Cursors.WaitCursor
        Dim row_foc As Integer = e.RowHandle
        Dim col As String = e.Column.FieldName.ToString
        If col = "is_select" Then
            Dim val As String = e.Value.ToString()
            Dim id_report As String = GVPD.GetRowCellValue(row_foc, "id_prod_demand").ToString()
            Dim id_source As String = GVPD.GetRowCellValue(row_foc, "id_source").ToString()
            If val = "Yes" Then
                Dim query As String = "DELETE FROM tb_work_pd WHERE id_report=" + id_report + " AND id_source=" + id_source + " AND id_user=" + id_user + ";
                INSERT INTO tb_work_pd VALUES('" + id_user + "', '" + id_report + "', '" + id_source + "', NOW()); "
                execute_non_query(query, True, "", "", "", "")
            Else
                Dim query As String = "DELETE FROM tb_work_pd WHERE id_report=" + id_report + " AND id_source=" + id_source + " AND id_user=" + id_user + "; "
                execute_non_query(query, True, "", "", "", "")
            End If
        End If
        GCPD.RefreshDataSource()
        GVPD.RefreshData()
        Cursor = Cursors.Default
    End Sub

    Private Sub GVPD_RowStyle(sender As Object, e As DevExpress.XtraGrid.Views.Grid.RowStyleEventArgs) Handles GVPD.RowStyle
        If e.RowHandle >= 0 Then
            Dim val As String = ""
            Try
                val = sender.GetRowCellValue(e.RowHandle, sender.Columns("is_select"))
            Catch ex As Exception

            End Try
            If val = "Yes" Then
                e.Appearance.BackColor = Color.Yellow
                e.Appearance.BackColor2 = Color.Yellow
            Else
                e.Appearance.BackColor = Color.White
                e.Appearance.BackColor2 = Color.White
            End If
        End If
    End Sub

    Private Sub GVDesign_CellValueChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles GVDesign.CellValueChanged
        Cursor = Cursors.WaitCursor
        Dim row_foc As Integer = e.RowHandle
        Dim col As String = e.Column.FieldName.ToString
        If col = "is_select" Then
            Dim val As String = e.Value.ToString()
            Dim id_report As String = GVDesign.GetRowCellValue(row_foc, "id_prod_order").ToString()
            If val = "Yes" Then
                Dim query As String = "DELETE FROM tb_work_po WHERE id_report=" + id_report + " AND id_user=" + id_user + ";
                INSERT INTO tb_work_po VALUES('" + id_user + "', '" + id_report + "', NOW()); "
                execute_non_query(query, True, "", "", "", "")
            Else
                Dim query As String = "DELETE FROM tb_work_po WHERE id_report=" + id_report + " AND id_user=" + id_user + "; "
                execute_non_query(query, True, "", "", "", "")
            End If
        End If
        GCDesign.RefreshDataSource()
        GVDesign.RefreshData()
        Cursor = Cursors.Default
    End Sub

    Private Sub GVDesign_RowStyle(sender As Object, e As DevExpress.XtraGrid.Views.Grid.RowStyleEventArgs) Handles GVDesign.RowStyle
        Dim View As DevExpress.XtraGrid.Views.Grid.GridView = sender
        If (e.RowHandle >= 0) Then
            Dim category As String = View.GetRowCellValue(e.RowHandle, View.Columns("is_select"))
            If category = "Yes" Then
                e.Appearance.BackColor = Color.Yellow
                e.Appearance.BackColor2 = Color.Yellow
            Else
                e.Appearance.BackColor = Color.White
                e.Appearance.BackColor2 = Color.White
            End If
        End If
    End Sub

    Private Sub BtnViewMat_Click(sender As Object, e As EventArgs) Handles BtnViewMat.Click
        viewPOMat()
    End Sub

    Private Sub BSearch_Click(sender As Object, e As EventArgs) Handles BSearch.Click
        Cursor = Cursors.WaitCursor
        view_prod_order_rec()
        Cursor = Cursors.Default
    End Sub
    Sub view_prod_order_rec()
        Dim query_where As String = ""
        Dim date_from_selected As String = "0000-01-01"
        Dim date_until_selected As String = "9999-01-01"

        If Not SLEVendor.EditValue.ToString = "0" Then
            query_where += " AND f.id_comp='" & SLEVendor.EditValue.ToString & "'"
        End If

        Try
            date_from_selected = Date.Parse(DEFromRec.EditValue.ToString).ToString("yyyy-MM-dd")
        Catch ex As Exception
        End Try
        Try
            date_until_selected = Date.Parse(DEUntilRec.EditValue.ToString).ToString("yyyy-MM-dd")
        Catch ex As Exception
        End Try

        Dim query = "SELECT dsg.design_display_name,dsg.design_code,a.id_report_status,h.report_status, g.id_season,g.season,a.id_prod_order_rec,a.prod_order_rec_number, 
                    (a.delivery_order_date) AS delivery_order_date,a.delivery_order_number,b.prod_order_number, DATE_ADD(b.prod_order_date, INTERVAL b.prod_order_lead_time DAY) AS po_est_rec_date,
                    (a.prod_order_rec_date) AS prod_order_rec_date, CONCAT(f.comp_number,' - ',f.comp_name) AS comp_from, CONCAT(d.comp_number,' - ',d.comp_name) AS comp_to, (dsg.design_display_name) AS NAME, po_type.po_type 
                    ,DATEDIFF(a.prod_order_rec_date,DATE_ADD(b.prod_order_date, INTERVAL b.prod_order_lead_time DAY)) AS late_rec_qc,
                    DATEDIFF(a.delivery_order_date,DATE_ADD(b.prod_order_date, INTERVAL b.prod_order_lead_time DAY)) AS late_vendor,
                    DATE_ADD(b.prod_order_date, INTERVAL b.prod_order_lead_time DAY) AS est_po_rec
                    FROM tb_prod_order_rec a  
                    INNER JOIN tb_prod_order b ON a.id_prod_order=b.id_prod_order 
                    INNER JOIN tb_m_comp_contact c ON c.id_comp_contact = a.id_comp_contact_to 
                    INNER JOIN tb_m_comp d ON d.id_comp = c.id_comp 
                    INNER JOIN tb_m_comp_contact e ON e.id_comp_contact = a.id_comp_contact_from  
                    INNER JOIN tb_m_comp f ON f.id_comp = e.id_comp
                    INNER JOIN tb_season_delivery i ON b.id_delivery = i.id_delivery 
                    INNER JOIN tb_season g ON g.id_season = i.id_season 
                    INNER JOIN tb_lookup_report_status h ON h.id_report_status = a.id_report_status 
                    INNER JOIN tb_prod_demand_design pd_dsg ON pd_dsg.id_prod_demand_design = b.id_prod_demand_design 
                    INNER JOIN tb_m_design dsg ON dsg.id_design = pd_dsg.id_design 
                    INNER JOIN tb_lookup_po_type po_type ON po_type.id_po_type = b.id_po_type 
                    WHERE (a.prod_order_rec_date>='" + date_from_selected + "' AND a.prod_order_rec_date<='" + date_until_selected + "')
                    " + query_where
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCProdRec.DataSource = data
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

    Dim tot_cop_pd As Decimal = 0
    Dim tot_cop_po As Decimal = 0
    Dim tot_cop_final As Decimal = 0
    Dim tot_retail_est As Decimal = 0
    Dim tot_retail_act As Decimal = 0
    Private Sub GVDesign_CustomSummaryCalculate(sender As Object, e As DevExpress.Data.CustomSummaryEventArgs) Handles GVDesign.CustomSummaryCalculate
        Dim summaryID As Integer = Convert.ToInt32(CType(e.Item, DevExpress.XtraGrid.GridSummaryItem).Tag)
        Dim View As DevExpress.XtraGrid.Views.Grid.GridView = CType(sender, DevExpress.XtraGrid.Views.Grid.GridView)

        ' Initialization 
        If e.SummaryProcess = DevExpress.Data.CustomSummaryProcess.Start Then
            tot_cop_pd = 0.0
            tot_cop_po = 0.0
            tot_cop_final = 0.0

            tot_retail_est = 0.0
            tot_retail_act = 0.0
        End If

        ' Calculation 
        If e.SummaryProcess = DevExpress.Data.CustomSummaryProcess.Calculate Then
            Dim cop_pd As Decimal = CDec(View.GetRowCellValue(e.RowHandle, "cop_pd_amo"))
            Dim cop_po As Decimal = CDec(View.GetRowCellValue(e.RowHandle, "cop_po_amo"))
            Dim cop_final As Decimal = CDec(View.GetRowCellValue(e.RowHandle, "cop_final_amo"))
            Dim retail_est As Decimal = CDec(View.GetRowCellValue(e.RowHandle, "retail_price_amo"))
            Dim retail_act As Decimal = CDec(View.GetRowCellValue(e.RowHandle, "normal_price_amo"))

            tot_cop_pd += cop_pd
            tot_cop_po += cop_po
            tot_cop_final += cop_final
            tot_retail_est += retail_est
            tot_retail_act += retail_act
        End If

        ' Finalization 
        If e.SummaryProcess = DevExpress.Data.CustomSummaryProcess.Finalize Then
            Select Case summaryID
                Case 1 'total summary markup_pd
                    Dim sum_markup_pd As Decimal = 0.0
                    Try
                        sum_markup_pd = tot_retail_est / tot_cop_pd
                    Catch ex As Exception
                    End Try
                    e.TotalValue = sum_markup_pd
                Case 2 'total summary markup_po
                    Dim sum_markup_po As Decimal = 0.0
                    Try
                        sum_markup_po = tot_retail_est / tot_cop_po
                    Catch ex As Exception
                    End Try
                    e.TotalValue = sum_markup_po
                Case 3 'total summary markup_final
                    Dim sum_markup_final As Decimal = 0.0
                    Try
                        sum_markup_final = tot_retail_act / tot_cop_final
                    Catch ex As Exception
                    End Try
                    e.TotalValue = sum_markup_final
                Case 4 'total group markup_pd
                    Dim sum_markup_pd As Decimal = 0.0
                    Try
                        sum_markup_pd = tot_retail_est / tot_cop_pd
                    Catch ex As Exception
                    End Try
                    e.TotalValue = sum_markup_pd
                Case 5 'total group markup_po
                    Dim sum_markup_po As Decimal = 0.0
                    Try
                        sum_markup_po = tot_retail_est / tot_cop_po
                    Catch ex As Exception
                    End Try
                    e.TotalValue = sum_markup_po
                Case 6 'total group markup_final
                    Dim sum_markup_final As Decimal = 0.0
                    Try
                        sum_markup_final = tot_retail_act / tot_cop_final
                    Catch ex As Exception
                    End Try
                    e.TotalValue = sum_markup_final
            End Select
        End If
    End Sub
End Class