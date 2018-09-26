Imports DevExpress.XtraEditors.Repository
Public Class FormFGLineList
    Public id_pop_up As String = "-1"
    Public data_band_break_par As DataTable = Nothing
    Public data_band_break_plan_par As DataTable = Nothing
    Public data_band_alloc_par As DataTable = Nothing
    Public data_band_alloc_plan_par As DataTable = Nothing
    Dim id_role_super_admin As String = "-1"
    Public data_column As New DataTable

    'id_pop_up :
    '-1 = line list MD
    '1  = for pop up windows
    '2  = view Line List
    '3  = Line list non MD 

    Private Sub FormFGLineList_Activated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Activated
        If id_pop_up <> "1" Then
            FormMain.show_rb(Name)
            checkFormAccess(Name)
        End If
    End Sub

    Private Sub FormFGLineList_Deactivate(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Deactivate
        If id_pop_up <> "1" Then
            FormMain.hide_rb()
        End If
    End Sub


    Private Sub FormFGLineList_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Cursor = Cursors.WaitCursor
        checkFormAccessSingle(Name)
        viewSeason() 'season
        viewLineType() 'pd type

        'inital datatable
        Dim query_c As ClassDesign = New ClassDesign()
        data_band_break_par = query_c.getBreakTotalLineList("1")
        data_band_break_plan_par = query_c.getBreakTotalLineList("3")
        data_band_alloc_par = query_c.getBreakAllocLineList("1")
        data_band_alloc_plan_par = query_c.getBreakAllocLineList("2")

        'initial role super admin
        id_role_super_admin = get_setup_field("id_role_super_admin")

        'single window
        If id_pop_up = "1" Then
            SLESeason.EditValue = FormProductionPLToWHDet.id_season
            SLESeason.Enabled = False
            SLETypeLineList.EditValue = 2
            SLETypeLineList.Enabled = False
            viewLineList()
            BGVLineList.ActiveFilterString = "[id_design]='" + FormProductionPLToWHDet.id_design.ToString + "' "
            BGVLineList.Columns("Select_sct").Visible = False
            SMDeleteDesign.Visible = False
        ElseIf id_pop_up = "2" Then
            PanelControlNavLineListBottom.Visible = False
            SMDeleteDesign.Visible = False
        ElseIf id_pop_up = "3" Then
            BBProposePrice.Visibility = DevExpress.XtraBars.BarItemVisibility.Never
            BBDs.Visibility = DevExpress.XtraBars.BarItemVisibility.Never
            BtnDesign.Visible = True
            SMDeleteDesign.Visible = True
        Else
            SMDeleteDesign.Visible = False
        End If

        'custom column template inisialisasi
        'initialisation datatable edit
        Try
            data_column.Columns.Add("options_view_det_band")
            data_column.Columns.Add("options_view_det_caption")
            data_column.Columns.Add("options_view_det_column")
            data_column.Columns.Add("options_view_det_visible")
        Catch ex As Exception
        End Try

        Cursor = Cursors.Default
    End Sub

    'view season
    Sub viewSeason()
        Dim query As String = "SELECT * FROM tb_season a "
        query += "INNER JOIN tb_range b ON a.id_range = b.id_range "
        query += "WHERE b.id_range >0 "
        If id_pop_up = "3" Then 'non merch
            query += "AND b.is_md='2' AND b.id_departement='" + id_departement_user + "' "
        Else
            query += "AND b.is_md='1' "
        End If
        query += "ORDER BY b.range DESC"
        viewSearchLookupQuery(SLESeason, query, "id_season", "season", "id_season")
    End Sub

    Sub viewLineType()
        Dim query As String = "SELECT * FROM tb_lookup_pd_type ORDER BY id_pd_type ASC "
        viewSearchLookupQuery(SLETypeLineList, query, "id_pd_type", "pd_type", "id_pd_type")
    End Sub

    Private Sub BtnView_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnView.Click
        Cursor = Cursors.WaitCursor
        CheckImg.EditValue = False
        BtnView.Text = "Loading..."
        BtnView.Enabled = False
        viewLineList()
        noEdit()
        BtnView.Text = "View Line List"
        BtnView.Enabled = True
        PanelOpt.Visible = False
        PanelImg.Visible = True
        BGVLineList.RowHeight = 10
        Cursor = Cursors.Default
    End Sub

    Sub viewLineList()
        Dim id_season_par As String = "0"
        Try
            id_season_par = SLESeason.EditValue.ToString
        Catch ex As Exception
        End Try
        Dim id_type As String = "-1"
        Try
            id_type = SLETypeLineList.EditValue.ToString
        Catch ex As Exception
        End Try

        Dim show_breakdown As Boolean = CheckEditOpt.EditValue

        Dim query_c As ClassDesign = New ClassDesign()
        If id_type = 1 Or id_type = "2" Then 'workspace
            query_c.viewLineList(id_season_par, id_type, BGVLineList, GCLineList, data_band_break_par, data_band_alloc_par, show_breakdown)
            optionsViewBanded(BGVLineList, "FormFGLineList", "BGVLineList", "1")
        Else 'summary & final line list
            query_c.viewLineListFinal(id_season_par, id_type, BGVLineList, GCLineList, data_band_break_par, data_band_break_plan_par, data_band_alloc_par, data_band_alloc_plan_par, show_breakdown)
            'optionsViewBanded(BGVLineList, "FormFGLineList", "BGVLineList", "2")
        End If
    End Sub

    Sub nonMDCustomView()
        ''hide band
        'For i As Integer = 0 To BGVLineList.Bands.Count - 1
        '    If BGVLineList.Bands(i).Caption.Contains("QTY") Then
        '        If BGVLineList.Bands(i).Caption.ToString <> "TOTAL QTY DESIGN" Then
        '            Console.WriteLine(BGVLineList.Bands(i).Caption.ToString)
        '            BGVLineList.Bands(i).Visible = False
        '        End If
        '    End If
        'Next

        ''hide column
        'For j As Integer = 0 To BGVLineList.Columns.Count - 1
        '    If BGVLineList.Columns(j).FieldName.Contains("Prc") Then
        '        If BGVLineList.Columns(j).FieldName.ToString <> "COST_Prc" And BGVLineList.Columns(j).FieldName.ToString <> "TOTAL COST_Prc" Then
        '            BGVLineList.Columns(j).Visible = False
        '        End If
        '    End If
        'Next
    End Sub

    Sub nothingLineList()
        GCLineList.Visible = False
        GCLineList.DataSource = Nothing
        CheckEditSelAll.Checked = False
    End Sub

    Private Sub SLESeason_EditValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SLESeason.EditValueChanged
        Cursor = Cursors.WaitCursor
        nothingLineList()
        CheckEditOpt.EditValue = False
        PanelOpt.Visible = True
        PanelImg.Visible = False
        Cursor = Cursors.Default
    End Sub

    Private Sub SLETypeLineList_EditValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SLETypeLineList.EditValueChanged
        Cursor = Cursors.WaitCursor
        nothingLineList()
        CheckEditOpt.EditValue = False
        PanelOpt.Visible = True
        PanelImg.Visible = False


        'show/hide btn
        If id_pop_up <> "2" Then
            If SLETypeLineList.EditValue.ToString = "1" Then
                'BtnProposePrice.Visible = False
                'BtnActualCost.Visible = False
                BtnEstimateCost.Visible = True
                BtnCopyFrom.Visible = True
                BtnCreateNewPD.Visible = True
                BtnPlanStatus.Visible = True
                If id_pop_up <> "3" Then
                    BtnDesign.Visible = False
                Else
                    BtnDesign.Visible = True
                End If
            ElseIf SLETypeLineList.EditValue.ToString = "2" Then
                'BtnProposePrice.Visible = False
                ' BtnActualCost.Visible = False
                BtnEstimateCost.Visible = True
                BtnCopyFrom.Visible = True
                BtnCreateNewPD.Visible = True
                BtnPlanStatus.Visible = True
                If id_pop_up <> "3" Then
                    BtnDesign.Visible = False
                Else
                    BtnDesign.Visible = True
                End If
            Else
                BtnProposePrice.Visible = False
                BtnActualCost.Visible = False
                BtnEstimateCost.Visible = False
                BtnCopyFrom.Visible = False
                BtnCreateNewPD.Visible = False
                BtnPlanStatus.Visible = False
                BtnDesign.Visible = False
            End If
        End If
        Cursor = Cursors.Default
    End Sub


    Private Sub SMEditDesign_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SMEditDesign.Click
        Cursor = Cursors.WaitCursor
        editLineList()
        Cursor = Cursors.Default
    End Sub

    Private Sub editLineList()
        Dim query_c As ClassDesign = New ClassDesign()
        Dim line_act As String = "-1"
        Try
            line_act = query_c.getLineActFocus(SLETypeLineList.EditValue.ToString, BGVLineList)
        Catch ex As Exception
        End Try
        If BGVLineList.RowCount > 0 And line_act = "1" Then
            Dim id_dsg As String = "-1"
            Try
                id_dsg = BGVLineList.GetFocusedRowCellValue("id_design").ToString
            Catch ex As Exception
            End Try

            If id_dsg <> "-1" And id_dsg <> "" Then
                FormMasterDesignSingle.id_pop_up = id_pop_up
                FormMasterDesignSingle.form_name = Name
                FormMasterDesignSingle.id_design = id_dsg
                FormMasterDesignSingle.WindowState = FormWindowState.Maximized
                FormMasterDesignSingle.ShowDialog()
            Else
                stopCustom("Design not found.")
            End If
        End If
    End Sub

    Private Sub SMDeleteDesign_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SMDeleteDesign.Click
        Cursor = Cursors.WaitCursor
        If BGVLineList.RowCount > 0 Then
            Dim tot_pd As String = "0"
            Try
                tot_pd = BGVLineList.GetFocusedRowCellValue("TOTAL PD CREATED").ToString
            Catch ex As Exception
            End Try
            If tot_pd = "0" Then
                Dim confirm As DialogResult = DevExpress.XtraEditors.XtraMessageBox.Show("Are you sure want to delete this data?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
                If confirm = Windows.Forms.DialogResult.Yes Then
                    Cursor = Cursors.WaitCursor
                    Try
                        Dim id_design As String = Me.BGVLineList.GetFocusedRowCellValue("id_design").ToString
                        Dim query As String = String.Format("DELETE FROM tb_m_design WHERE id_design='{0}'", id_design)
                        execute_non_query(query, True, "", "", "", "")
                        viewLineList()
                    Catch ex As Exception
                        errorDelete()
                    End Try
                    Cursor = Cursors.Default
                End If
            Else
                errorDelete()
            End If
        End If
        Cursor = Cursors.Default
    End Sub


    Private Sub CheckEditSelAll_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckEditSelAll.CheckedChanged
        If BGVLineList.RowCount > 0 Then
            Dim cek As String = CheckEditSelAll.EditValue.ToString
            For i As Integer = 0 To ((BGVLineList.RowCount - 1) - GetGroupRowCount(BGVLineList))
                Dim id_lookup_status_order As String = BGVLineList.GetRowCellValue(i, "id_lookup_status_order").ToString
                If cek And id_lookup_status_order <> "2" Then
                    BGVLineList.SetRowCellValue(i, "Select_sct", "Yes")
                Else
                    BGVLineList.SetRowCellValue(i, "Select_sct", "No")
                End If
            Next
        End If
    End Sub

    Sub noEdit()
        If BGVLineList.FocusedRowHandle >= 0 Then
            If id_pop_up = "-1" Then
                Dim id_lookup_status_order As String = BGVLineList.GetFocusedRowCellValue("id_lookup_status_order").ToString
                If id_lookup_status_order = "2" Then
                    BGVLineList.Columns("Select_sct").OptionsColumn.AllowEdit = False
                Else
                    BGVLineList.Columns("Select_sct").OptionsColumn.AllowEdit = True
                End If
            Else
                If id_role_login <> id_role_super_admin Then
                    Dim query_c As ClassDesign = New ClassDesign()
                    Dim line_act As String = "-1"
                    Try
                        line_act = query_c.getLineActFocus(SLETypeLineList.EditValue.ToString, BGVLineList)
                    Catch ex As Exception
                    End Try
                    If line_act = "1" Then 'opened
                        BGVLineList.Columns("Select_sct").OptionsColumn.AllowEdit = True
                    Else
                        BGVLineList.Columns("Select_sct").OptionsColumn.AllowEdit = False
                    End If
                End If
            End If
        End If
    End Sub

    Private Sub BGVLineList_CustomColumnDisplayText(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs) Handles BGVLineList.CustomColumnDisplayText
        If e.Column.FieldName = "NO" Then
            e.DisplayText = (e.ListSourceRowIndex + 1).ToString()
        End If
    End Sub

    Private Sub BGVLineList_PopupMenuShowing(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Grid.PopupMenuShowingEventArgs) Handles BGVLineList.PopupMenuShowing
        If e.MenuType = DevExpress.XtraGrid.Views.Grid.GridMenuType.Column And id_role_login = id_role_super_admin Then
            Dim menu As DevExpress.XtraGrid.Menu.GridViewColumnMenu = e.Menu

            If Not menu.Column Is Nothing Then
                menu.Items.Add(CreateCheckItem("Options View", menu.Column))
            End If
        End If

        Dim query_c As ClassDesign = New ClassDesign()
        Dim line_act As String = "-1"
        Try
            line_act = query_c.getLineActFocus(SLETypeLineList.EditValue.ToString, BGVLineList)
        Catch ex As Exception
        End Try
        If BGVLineList.RowCount > 0 And id_pop_up <> "2" Then
            If line_act = "1" Then
                SMEditDesign.Visible = True
                SMViewDupe.Visible = False
            Else
                SMEditDesign.Visible = False
                SMViewDupe.Visible = False
            End If
            Dim view As DevExpress.XtraGrid.Views.Grid.GridView = CType(sender, DevExpress.XtraGrid.Views.Grid.GridView)
            Dim hitInfo As DevExpress.XtraGrid.Views.Grid.ViewInfo.GridHitInfo = view.CalcHitInfo(e.Point)
            If hitInfo.InRow And hitInfo.RowHandle >= 0 Then
                view.FocusedRowHandle = hitInfo.RowHandle
                ViewMenu.Show(view.GridControl, e.Point)
            End If
        End If
    End Sub

    Private Sub BGVLineList_FocusedRowChanged(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles BGVLineList.FocusedRowChanged
        Try
            noEdit()
        Catch ex As Exception
        End Try
    End Sub

    Private Sub SMViewDupe_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SMViewDupe.Click
        'design
        Cursor = Cursors.WaitCursor
        FormMasterDesignSingle.id_pop_up = id_pop_up
        FormMasterDesignSingle.WindowState = FormWindowState.Maximized
        FormMasterDesignSingle.form_name = "FormFGLineList"
        FormMasterDesignSingle.dupe = "1"
        Dim id_dsg_param As String = "-1"
        Try
            id_dsg_param = BGVLineList.GetFocusedRowCellValue("id_design").ToString
        Catch ex As Exception
        End Try
        FormMasterDesignSingle.id_design = id_dsg_param
        FormMasterDesignSingle.ShowDialog()
        Cursor = Cursors.Default
    End Sub


    Private Sub BBProposePrice_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles BBProposePrice.ItemClick
        Cursor = Cursors.WaitCursor
        Try
            FormFGProposePrice.MdiParent = FormMain
            FormFGProposePrice.Show()
            FormFGProposePrice.WindowState = FormWindowState.Maximized
            FormFGProposePrice.Focus()
        Catch ex As Exception
            errorProcess()
        End Try
        Cursor = Cursors.Default
    End Sub

    Private Sub BBPD_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles BBPD.ItemClick
        Cursor = Cursors.WaitCursor
        Try
            FormProdDemand.MdiParent = FormMain
            FormProdDemand.Show()
            FormProdDemand.WindowState = FormWindowState.Maximized
            FormProdDemand.Focus()
        Catch ex As Exception
            errorProcess()
            FormProdDemand.Dispose()
        End Try
        Cursor = Cursors.Default
    End Sub

    Dim tot_cost As Decimal
    Dim tot_prc As Decimal
    Dim tot_cost_grp As Decimal
    Dim tot_prc_grp As Decimal

    Dim tot_cost_act As Decimal
    Dim tot_prc_act As Decimal
    Dim tot_cost_grp_act As Decimal
    Dim tot_prc_grp_act As Decimal
    Private Sub BGVLineList_CustomSummaryCalculate(ByVal sender As System.Object, ByVal e As DevExpress.Data.CustomSummaryEventArgs) Handles BGVLineList.CustomSummaryCalculate
        Dim summaryID As Integer = Convert.ToInt32(CType(e.Item, DevExpress.XtraGrid.GridSummaryItem).Tag)
        Dim View As DevExpress.XtraGrid.Views.Grid.GridView = CType(sender, DevExpress.XtraGrid.Views.Grid.GridView)

        If SLETypeLineList.EditValue.ToString = "3" Then
            '-------------ACTUAL
            ' Initialization 
            If e.SummaryProcess = DevExpress.Data.CustomSummaryProcess.Start Then
                tot_cost = 0.0
                tot_prc = 0.0
                tot_cost_grp = 0.0
                tot_prc_grp = 0.0

                tot_cost_act = 0.0
                tot_prc_act = 0.0
                tot_cost_grp_act = 0.0
                tot_prc_grp_act = 0.0
            End If

            ' Calculation 
            If e.SummaryProcess = DevExpress.Data.CustomSummaryProcess.Calculate Then
                Dim cost As Decimal = CDec(myCoalesce(View.GetRowCellValue(e.RowHandle, "TOTAL COST_Prc_Plan").ToString, "0.00"))
                Dim prc As Decimal = CDec(myCoalesce(View.GetRowCellValue(e.RowHandle, "TOTAL AMO_Prc_Plan"), "0.00"))
                Dim cost_act As Decimal = CDec(myCoalesce(View.GetRowCellValue(e.RowHandle, "TOTAL COST_Prc").ToString, "0.00"))
                Dim prc_act As Decimal = CDec(myCoalesce(View.GetRowCellValue(e.RowHandle, "TOTAL AMO_Prc"), "0.00"))
                Select Case summaryID
                    Case 46
                        tot_cost += cost
                        tot_prc += prc
                    Case 47
                        tot_cost_grp += cost
                        tot_prc_grp += prc
                    Case 48
                        tot_cost_act += cost_act
                        tot_prc_act += prc_act
                    Case 49
                        tot_cost_grp_act += cost_act
                        tot_prc_grp_act += prc_act
                End Select
            End If

            ' Finalization 
            If e.SummaryProcess = DevExpress.Data.CustomSummaryProcess.Finalize Then
                Select Case summaryID
                    Case 46 'total summary
                        Dim sum_res As Decimal = 0.0
                        Try
                            sum_res = tot_prc / tot_cost
                        Catch ex As Exception
                        End Try
                        e.TotalValue = sum_res
                    Case 47 'group summary
                        Dim sum_res As Decimal = 0.0
                        Try
                            sum_res = tot_prc_grp / tot_cost_grp
                        Catch ex As Exception
                        End Try
                        e.TotalValue = sum_res
                    Case 48 'total summary
                        Dim sum_res As Decimal = 0.0
                        Try
                            sum_res = tot_prc_act / tot_cost_act
                        Catch ex As Exception
                        End Try
                        e.TotalValue = sum_res
                    Case 49 'group summary
                        Dim sum_res As Decimal = 0.0
                        Try
                            sum_res = tot_prc_grp_act / tot_cost_grp_act
                        Catch ex As Exception
                        End Try
                        e.TotalValue = sum_res
                End Select
            End If
        Else
            ' Initialization 
            If e.SummaryProcess = DevExpress.Data.CustomSummaryProcess.Start Then
                tot_cost = 0.0
                tot_prc = 0.0
                tot_cost_grp = 0.0
                tot_prc_grp = 0.0
            End If

            ' Calculation 
            If e.SummaryProcess = DevExpress.Data.CustomSummaryProcess.Calculate Then
                Dim cost As Decimal = CDec(myCoalesce(View.GetRowCellValue(e.RowHandle, "TOTAL COST NON ADDITIONAL_Prc").ToString, "0.00"))
                Dim prc As Decimal = CDec(myCoalesce(View.GetRowCellValue(e.RowHandle, "TOTAL AMO NON ADDITIONAL_Prc"), "0.00"))
                Select Case summaryID
                    Case 46
                        tot_cost += cost
                        tot_prc += prc
                    Case 47
                        tot_cost_grp += cost
                        tot_prc_grp += prc
                End Select
            End If

            ' Finalization 
            If e.SummaryProcess = DevExpress.Data.CustomSummaryProcess.Finalize Then
                Select Case summaryID
                    Case 46 'total summary
                        Dim sum_res As Decimal = 0.0
                        Try
                            sum_res = tot_prc / tot_cost
                        Catch ex As Exception
                        End Try
                        e.TotalValue = sum_res
                    Case 47 'group summary
                        Dim sum_res As Decimal = 0.0
                        Try
                            sum_res = tot_prc_grp / tot_cost_grp
                        Catch ex As Exception
                        End Try
                        e.TotalValue = sum_res
                End Select
            End If
        End If
    End Sub

    Private Sub BtnDesign_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnDesign.Click
        Cursor = Cursors.WaitCursor
        FormMasterDesignSingle.id_pop_up = id_pop_up
        FormMasterDesignSingle.id_season_par = SLESeason.EditValue.ToString
        FormMasterDesignSingle.form_name = Name
        FormMasterDesignSingle.WindowState = FormWindowState.Maximized
        FormMasterDesignSingle.ShowDialog()
        Cursor = Cursors.Default
    End Sub

    Private Sub BtnActualCost_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnActualCost.Click
        Cursor = Cursors.WaitCursor
        If BGVLineList.RowCount > 0 Then
            Dim jum_tot As Integer = getTotalSelected()
            Dim id_str As String = ""
            Dim jum_str As Integer = 0


            If jum_tot > 0 Then
                Dim rhandle_c As Integer = 0
                Dim dsg_c As String = ""
                Dim bool_c As Boolean = True
                For c As Integer = 0 To ((BGVLineList.RowCount - 1) - GetGroupRowCount(BGVLineList))
                    If BGVLineList.GetRowCellValue(c, "Select_sct").ToString = "Yes" Then
                        Dim cek_pp As String = BGVLineList.GetRowCellValue(c, "id_report_status_sct").ToString
                        rhandle_c = c
                        dsg_c = BGVLineList.GetRowCellValue(c, "DESCRIPTION").ToString
                        If cek_pp <> "6" Then
                            bool_c = False
                            Exit For
                        End If
                    End If
                Next

                If bool_c Then
                    Dim confirm As DialogResult = DevExpress.XtraEditors.XtraMessageBox.Show("Are you sure you want to update actual cost?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
                    If confirm = Windows.Forms.DialogResult.Yes Then
                        'For l As Integer = 0 To ((BGVLineList.RowCount - 1) - GetGroupRowCount(BGVLineList))
                        '    If BGVLineList.GetRowCellValue(l, "Select_sct") = "Yes" Then
                        '        If jum_str > 0 Then
                        '            id_str += ";"
                        '        End If
                        '        id_str += myCoalesce(BGVLineList.GetRowCellValue(l, "id_design").ToString, "0")
                        '        jum_str += 1
                        '    End If
                        'Next
                        'Dim query As String = "CALL generate_pd_upd_act_cost('" + id_str + "')"
                        'execute_non_query(query, True, "", "", "", "")
                        'viewLineList()
                        'infoCustom("Actual cost updated.")
                        'CheckEditSelAll.EditValue = False
                    End If
                Else
                    stopCustom("Design : '" + dsg_c.ToString + "' doesn't have 'Final Propose Price' !")
                    BGVLineList.FocusedRowHandle = rhandle_c
                End If
            Else
                stopCustom("Nothing item selected!")
            End If
        End If
        Cursor = Cursors.Default
    End Sub

    Private Function getTotalSelected() As Integer
        Dim jum_tot As Integer = 0
        Dim cond_same As Boolean = False
        Dim string_same As String = "-1"
        Dim id_design_same As String = "-1"
        Dim idx_same As Integer = 0
        For i As Integer = 0 To ((BGVLineList.RowCount - 1) - GetGroupRowCount(BGVLineList))
            If BGVLineList.GetRowCellValue(i, "Select_sct") = "Yes" Then
                jum_tot += 1
                If jum_tot > 0 Then
                    Exit For
                End If
            End If
        Next
        Return jum_tot
    End Function

    Private Sub BtnEstimateCost_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnEstimateCost.Click
        Cursor = Cursors.WaitCursor
        If BGVLineList.RowCount > 0 Then
            Dim jum_tot As Integer = getTotalSelected()
            Dim id_str As String = ""
            Dim jum_str As Integer = 0
            Dim ll_type As String = ""
            If SLETypeLineList.EditValue.ToString = "1" Then
                ll_type = "id_prod_demand_design_line"
            ElseIf SLETypeLineList.EditValue.ToString = "2" Then
                ll_type = "id_prod_demand_design_line_upd"
            Else
                ll_type = "id_prod_demand_design_line_final"
            End If

            If jum_tot > 0 Then
                Dim confirm As DialogResult = DevExpress.XtraEditors.XtraMessageBox.Show("Are you sure you want to Update Estimate Cost?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
                If confirm = Windows.Forms.DialogResult.Yes Then
                    For l As Integer = 0 To ((BGVLineList.RowCount - 1) - GetGroupRowCount(BGVLineList))
                        If BGVLineList.GetRowCellValue(l, "Select_sct") = "Yes" Then
                            If jum_str > 0 Then
                                id_str += "OR "
                            End If
                            id_str += "pd_dsg.id_prod_demand_design = " + myCoalesce(BGVLineList.GetRowCellValue(l, ll_type).ToString, "0") + " "
                            jum_str += 1
                        End If
                    Next
                    Console.WriteLine(id_str)
                    Dim query As String = "CALL generate_pd_upd_est_cost_new('" + id_str + "')"
                    execute_non_query(query, True, "", "", "", "")
                    viewLineList()
                    infoCustom("Estimate Cost Updated.")
                    CheckEditSelAll.EditValue = False
                End If
            Else
                stopCustom("Nothing item selected!")
            End If
        End If
        Cursor = Cursors.Default
    End Sub

    Private Sub BBMasterSeason_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles BBMasterSeason.ItemClick
        Cursor = Cursors.WaitCursor
        Try
            If id_pop_up <> "-1" Then
                FormSeason.is_md = "2"
            End If
            FormSeason.MdiParent = FormMain
            FormSeason.Show()
            FormSeason.WindowState = FormWindowState.Maximized
            FormSeason.Focus()
        Catch ex As Exception
            errorProcess()
        End Try
        Cursor = Cursors.Default
    End Sub

    Private Sub BGVLineList_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BGVLineList.DoubleClick
        Cursor = Cursors.WaitCursor
        If id_pop_up <> "2" Then
            editLineList()
        End If
        Cursor = Cursors.Default
    End Sub

    Private Sub BtnProposePrice_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnProposePrice.Click
        Cursor = Cursors.WaitCursor
        If BGVLineList.RowCount > 0 Then
            Dim jum_tot As Integer = getTotalSelected()
            Dim id_str As String = ""
            Dim jum_str As Integer = 0


            If jum_tot > 0 Then
                Dim confirm As DialogResult = DevExpress.XtraEditors.XtraMessageBox.Show("Are you sure you want to update propose price?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
                If confirm = Windows.Forms.DialogResult.Yes Then
                    For l As Integer = 0 To ((BGVLineList.RowCount - 1) - GetGroupRowCount(BGVLineList))
                        If BGVLineList.GetRowCellValue(l, "Select_sct") = "Yes" Then
                            If jum_str > 0 Then
                                id_str += ";"
                            End If
                            id_str += myCoalesce(BGVLineList.GetRowCellValue(l, "id_design").ToString, "0")
                            jum_str += 1
                        End If
                    Next
                    Dim query As String = "CALL generate_pd_upd_act_price('" + id_str + "', TRUE)"
                    execute_non_query(query, True, "", "", "", "")
                    viewLineList()
                    infoCustom("Propose price updated.")
                    CheckEditSelAll.EditValue = False
                End If
            Else
                stopCustom("Nothing item selected!")
            End If
        End If
        Cursor = Cursors.Default
    End Sub

    Private Sub BtnCopyFrom_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCopyFrom.Click
        Cursor = Cursors.WaitCursor
        If BGVLineList.RowCount > 0 Then
            Dim jum_tot As Integer = getTotalSelected()
            If jum_tot > 0 Then
                FormFGLineListType.ShowDialog()
            Else
                stopCustom("Nothing item selected!")
            End If
        End If
        Cursor = Cursors.Default
    End Sub

    Private Sub SMViewPD_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SMViewPD.Click
        Cursor = Cursors.WaitCursor
        Dim id_prod_demand_last_par As String = "0"
        Try
            id_prod_demand_last_par = BGVLineList.GetFocusedRowCellValue("id_prod_demand_last").ToString
        Catch ex As Exception
        End Try
        If id_prod_demand_last_par = "0" Or id_prod_demand_last_par = "" Then
            stopCustom("Document not found")
        Else

            Dim querty_c As ClassShowPopUp = New ClassShowPopUp()
            querty_c.id_report = id_prod_demand_last_par
            querty_c.report_mark_type = "9"
            querty_c.show()
            'Try
            '    FormProdDemand.MdiParent = FormMain
            '    FormProdDemand.Show()
            '    FormProdDemand.WindowState = FormWindowState.Maximized
            '    FormProdDemand.Focus()
            '    FormProdDemand.GVProdDemand.FocusedRowHandle = find_row(FormProdDemand.GVProdDemand, "id_prod_demand", id_prod_demand_last_par)
            '    FormProdDemand.GVProdDemand.ApplyFindFilter(BGVLineList.GetFocusedRowCellValue("LAST PD").ToString)
            'Catch ex As Exception
            '    errorProcess()
            '    FormProdDemand.Dispose()
            'End Try
        End If
        Cursor = Cursors.Default
    End Sub

    Private Sub SMViewHistoryPD_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SMViewHistoryPD.Click
        Cursor = Cursors.WaitCursor
        Dim id_dsg_par As String = "0"
        Try
            id_dsg_par = BGVLineList.GetFocusedRowCellValue("id_design").ToString
        Catch ex As Exception
        End Try
        If id_dsg_par = "0" Or id_dsg_par = "" Then
            stopCustom("Document not found")
        Else
            FormProdDemandHist.id_dsg_param = id_dsg_par
            FormProdDemandHist.ShowDialog()
        End If
        Cursor = Cursors.Default
    End Sub

    Private Sub BGVLineList_ValidateRow(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs) Handles BGVLineList.ValidateRow

    End Sub

    Private Sub BtnLock_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Cursor = Cursors.WaitCursor
        If BGVLineList.RowCount > 0 Then
            Dim jum_tot As Integer = getTotalSelected()
            Dim id_str As String = ""
            Dim jum_str As Integer = 0
            Dim ll_type As String = "id_design"
            Dim ll_cat As String = "-1"
            Dim ll_us As String = "-1"
            Dim ll_time As String = "-1"
            If SLETypeLineList.EditValue.ToString = "1" Then
                ll_cat = "id_prod_demand_design_line_lock"
                ll_us = "id_prod_demand_design_line_lock_user"
                ll_time = "id_prod_demand_design_line_lock_time"
            ElseIf SLETypeLineList.EditValue.ToString = "2" Then
                ll_cat = "id_prod_demand_design_line_upd_lock"
                ll_us = "id_prod_demand_design_line_upd_lock_user"
                ll_time = "id_prod_demand_design_line_upd_lock_time"
            Else
                ll_cat = "id_prod_demand_design_line_final_lock"
                ll_us = "id_prod_demand_design_line_final_lock_user"
                ll_time = "id_prod_demand_design_line_final_lock_time"
            End If

            If jum_tot > 0 Then
                Dim confirm As DialogResult = DevExpress.XtraEditors.XtraMessageBox.Show("Are you sure you want to Lock Design for this Line List?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
                If confirm = Windows.Forms.DialogResult.Yes Then
                    For l As Integer = 0 To ((BGVLineList.RowCount - 1) - GetGroupRowCount(BGVLineList))
                        If BGVLineList.GetRowCellValue(l, "Select_sct") = "Yes" Then
                            If jum_str > 0 Then
                                id_str += ";"
                            End If
                            id_str += myCoalesce(BGVLineList.GetRowCellValue(l, ll_type).ToString, "0")
                            jum_str += 1
                        End If
                    Next
                    Dim query As String = "CALL generate_pd_upd_lock('" + id_str + "', '" + ll_cat + "', '" + ll_us + "', '" + id_user + "', '" + ll_time + "','2')"
                    execute_non_query(query, True, "", "", "", "")
                    viewLineList()
                    infoCustom("Locked successfully.")
                    CheckEditSelAll.EditValue = False
                End If
            Else
                stopCustom("Nothing item selected!")
            End If
        End If
        Cursor = Cursors.Default
    End Sub

    Private Sub BGVLineList_CellValueChanged(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles BGVLineList.CellValueChanged
        'Cursor = Cursors.WaitCursor
        'Try
        '    noEdit()
        'Catch ex As Exception
        'End Try
        'Cursor = Cursors.Default
    End Sub

    Private Sub BtnUnlock_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Cursor = Cursors.WaitCursor
        If BGVLineList.RowCount > 0 Then
            Dim jum_tot As Integer = getTotalSelected()
            Dim id_str As String = ""
            Dim jum_str As Integer = 0
            Dim ll_type As String = "id_design"
            Dim ll_cat As String = "-1"
            Dim ll_us As String = "-1"
            Dim ll_time As String = "-1"
            If SLETypeLineList.EditValue.ToString = "1" Then
                ll_cat = "id_prod_demand_design_line_lock"
                ll_us = "id_prod_demand_design_line_lock_user"
                ll_time = "id_prod_demand_design_line_lock_time"
            ElseIf SLETypeLineList.EditValue.ToString = "2" Then
                ll_cat = "id_prod_demand_design_line_upd_lock"
                ll_us = "id_prod_demand_design_line_upd_lock_user"
                ll_time = "id_prod_demand_design_line_upd_lock_time"
            Else
                ll_cat = "id_prod_demand_design_line_final_lock"
                ll_us = "id_prod_demand_design_line_final_lock_user"
                ll_time = "id_prod_demand_design_line_final_lock_time"
            End If

            If jum_tot > 0 Then
                Dim confirm As DialogResult = DevExpress.XtraEditors.XtraMessageBox.Show("Are you sure you want to Unlock Design for this Line List?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
                If confirm = Windows.Forms.DialogResult.Yes Then
                    For l As Integer = 0 To ((BGVLineList.RowCount - 1) - GetGroupRowCount(BGVLineList))
                        If BGVLineList.GetRowCellValue(l, "Select_sct") = "Yes" Then
                            If jum_str > 0 Then
                                id_str += ";"
                            End If
                            id_str += myCoalesce(BGVLineList.GetRowCellValue(l, ll_type).ToString, "0")
                            jum_str += 1
                        End If
                    Next
                    Dim query As String = "CALL generate_pd_upd_lock('" + id_str + "', '" + ll_cat + "', '" + ll_us + "', '" + id_user + "', '" + ll_time + "','1')"
                    execute_non_query(query, True, "", "", "", "")
                    viewLineList()
                    infoCustom("Unlocked successfully.")
                    CheckEditSelAll.EditValue = False
                End If
            Else
                stopCustom("Nothing item selected!")
            End If
        End If
        Cursor = Cursors.Default
    End Sub

    Private Sub SMViewCostHist_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SMViewCostHist.Click
        Cursor = Cursors.WaitCursor
        Dim id_dsg_par As String = "0"
        Try
            id_dsg_par = BGVLineList.GetFocusedRowCellValue("id_design").ToString
        Catch ex As Exception
        End Try
        If id_dsg_par = "0" Or id_dsg_par = "" Then
            stopCustom("Document not found")
        Else
            FormProdDemandCostHist.id_design_par = id_dsg_par
            FormProdDemandCostHist.ShowDialog()
        End If
        Cursor = Cursors.Default
    End Sub

    Private Sub BGVLineList_ColumnChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BGVLineList.ColumnChanged
        'Cursor = Cursors.WaitCursor
        'Try
        '    noEdit()
        'Catch ex As Exception
        'End Try
        'Cursor = Cursors.Default
    End Sub

    Private Sub FormFGLineList_FormClosed(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub BBDs_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles BBDs.ItemClick
        Cursor = Cursors.WaitCursor
        Try
            FormFGDistScheme.MdiParent = FormMain
            FormFGDistScheme.Show()
            FormFGDistScheme.WindowState = FormWindowState.Maximized
            FormFGDistScheme.Focus()
        Catch ex As Exception
            errorProcess()
        End Try
        Cursor = Cursors.Default
    End Sub

    ' Creates a menu item.
    Function CreateCheckItem(ByVal caption As String, ByVal column As DevExpress.XtraGrid.Columns.GridColumn) As DevExpress.Utils.Menu.DXMenuItem
        Dim item As DevExpress.Utils.Menu.DXMenuItem = New DevExpress.Utils.Menu.DXMenuItem(caption, New EventHandler(AddressOf OnCanMovedItemClick))
        item.Tag = New MenuColumnInfo(column)
        Return item
    End Function

    ' Menu item click handler.
    Sub OnCanMovedItemClick(ByVal sender As Object, ByVal e As EventArgs)
        data_column.Clear()
        For i As Integer = 0 To BGVLineList.Columns.Count - 1
            If BGVLineList.Columns(i).FieldName.ToString <> "Select_sct" Then
                Console.WriteLine(BGVLineList.Columns(i).FieldName.ToString + "=" + BGVLineList.Columns(i).Caption.ToString + "-" + BGVLineList.Columns(i).Visible.ToString)
                Dim R As DataRow = data_column.NewRow
                R("options_view_det_band") = BGVLineList.Columns(i).OwnerBand.ToString
                R("options_view_det_caption") = BGVLineList.Columns(i).Caption.ToString
                R("options_view_det_column") = BGVLineList.Columns(i).FieldName.ToString
                R("options_view_det_visible") = BGVLineList.Columns(i).Visible.ToString
                data_column.Rows.Add(R)
            End If
        Next
        FormOptView.frm_opt_name = "FormFGLineList"
        FormOptView.gv_opt_name = "BGVLineList"
        If SLETypeLineList.EditValue.ToString = 1 Or SLETypeLineList.EditValue.ToString = "2" Then
            FormOptView.tag_opt_name = "1"
        Else
            FormOptView.tag_opt_name = "2"
        End If
        FormOptView.dt = data_column
        FormOptView.ShowDialog()
    End Sub

    ' The class that stores menu specific information.
    Class MenuColumnInfo
        Public Sub New(ByVal column As DevExpress.XtraGrid.Columns.GridColumn)
            Me.Column = column
        End Sub
        Public Column As DevExpress.XtraGrid.Columns.GridColumn
    End Class

    Private Sub BtnCreateNewPD_Click(sender As Object, e As EventArgs) Handles BtnCreateNewPD.Click
        Cursor = Cursors.WaitCursor
        If BGVLineList.RowCount > 0 Then
            Dim id_str As String = ""
            Dim dsg_cek As String = ""
            Dim jum_str As Integer = 0
            Dim jum_tot As Integer = getTotalSelected()
            If jum_tot > 0 Then
                Dim confirm As DialogResult = DevExpress.XtraEditors.XtraMessageBox.Show("Make sure cost item is up to date before you create new production demand. Are you sure you want to Create New Production Demand?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
                If confirm = Windows.Forms.DialogResult.Yes Then
                    Cursor = Cursors.WaitCursor
                    For l As Integer = 0 To ((BGVLineList.RowCount - 1) - GetGroupRowCount(BGVLineList))
                        If BGVLineList.GetRowCellValue(l, "Select_sct") = "Yes" Then
                            If jum_str > 0 Then
                                id_str += ";"
                                dsg_cek += "OR "
                            End If
                            id_str += BGVLineList.GetRowCellValue(l, "id_design").ToString
                            dsg_cek += "pdd.id_design = '" + BGVLineList.GetRowCellValue(l, "id_design").ToString + "' "
                            jum_str += 1
                        End If
                    Next

                    'cek design yg ada di PD
                    Dim qd As String = "SELECT pd.prod_demand_number, d.design_code AS `code`, d.design_display_name AS `name` 
                    FROM tb_prod_demand_design pdd
                    INNER JOIN tb_m_design d ON d.id_design = pdd.id_design
                    INNER JOIN tb_prod_demand pd ON pd.id_prod_demand = pdd.id_prod_demand
                    WHERE pd.is_pd=1 AND pd.id_report_status!=5 AND pdd.is_void=2
                    AND (" + dsg_cek + ")
                    ORDER BY pd.id_prod_demand ASC "
                    Dim dd As DataTable = execute_query(qd, -1, True, "", "", "", "")
                    If dd.Rows.Count > 0 Then
                        FormFGLineListPDExist.dt = dd
                        FormFGLineListPDExist.ShowDialog()
                        Exit Sub
                    End If

                    Try
                        FormProdDemand.MdiParent = FormMain
                        FormProdDemand.Show()
                        FormProdDemand.WindowState = FormWindowState.Maximized
                        FormProdDemand.Focus()

                        FormProdDemandSingle.action = "ins"
                        FormProdDemandSingle.ss_line_list = SLESeason.EditValue.ToString
                        FormProdDemandSingle.id_report_status = "-1"
                        FormProdDemandSingle.dsg_line_list = id_str
                        FormProdDemandSingle.type_line_list = SLETypeLineList.EditValue.ToString
                        FormProdDemandSingle.ShowDialog()

                        viewLineList()
                        CheckEditSelAll.EditValue = False
                    Catch ex As Exception
                        errorProcess()
                        FormProdDemand.Dispose()
                    End Try
                    Cursor = Cursors.Default
                End If
            Else
                stopCustom("Nothing item selected!")
            End If
        End If
        Cursor = Cursors.Default
    End Sub

    'prepare est price
    Private Sub BBPrepEstPrice_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BBPrepEstPrice.ItemClick
        Cursor = Cursors.WaitCursor
        FormFGLineListPrepPrice.id_type = SLETypeLineList.EditValue.ToString
        FormFGLineListPrepPrice.id_season = SLESeason.EditValue.ToString
        FormFGLineListPrepPrice.ShowDialog()
        Cursor = Cursors.Default
        'For Each column As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn In BGVLineList.Columns
        '    If column.FieldName.ToString <> "CODE" Then
        '        column.Visible = False
        '    End If
        'Next column
    End Sub

    Private Sub BtnImportEstPrice_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BtnImportEstPrice.ItemClick
        Cursor = Cursors.WaitCursor
        FormImportExcel.id_pop_up = "17"
        FormImportExcel.ShowDialog()
        Cursor = Cursors.Default
    End Sub

    Private Sub BtnPlanStatus_Click(sender As Object, e As EventArgs) Handles BtnPlanStatus.Click
        Cursor = Cursors.WaitCursor
        BGVLineList.ActiveFilterString = "[Select_sct]='Yes' "
        If BGVLineList.RowCount > 0 Then
            Dim jum_tot As Integer = getTotalSelected()
            If jum_tot > 0 Then
                FormFGLineListMoveSeason.id_pop_up = id_pop_up
                FormFGLineListMoveSeason.ShowDialog()
            Else
                stopCustom("Nothing item selected!")
            End If
        End If
        BGVLineList.ActiveFilterString = ""
        Cursor = Cursors.Default
    End Sub

    Private ImageDir As String = product_image_path
    Private Images As Hashtable = New Hashtable()
    Private Sub BGVLineList_CustomUnboundColumnData(sender As Object, e As DevExpress.XtraGrid.Views.Base.CustomColumnDataEventArgs) Handles BGVLineList.CustomUnboundColumnData
        If e.Column.FieldName = "img" AndAlso e.IsGetData And CheckImg.EditValue.ToString = "True" Then
            Images = Nothing
            Images = New Hashtable()
            Dim view As DevExpress.XtraGrid.Views.Grid.GridView = TryCast(sender, DevExpress.XtraGrid.Views.Grid.GridView)
            Dim id As String = CStr(view.GetListSourceRowCellValue(e.ListSourceRowIndex, "id_design"))

            Dim fileName As String = id & ".jpg".ToLower

            If (Not Images.ContainsKey(fileName)) Then
                Dim img As Image = Nothing
                Dim resizeImg As Image = Nothing

                Try

                    Dim filePath As String = DevExpress.Utils.FilesHelper.FindingFileName(ImageDir, fileName, False)
                    img = Image.FromFile(filePath)
                    resizeImg = img.GetThumbnailImage(100, 100, Nothing, Nothing)
                Catch

                End Try

                Images.Add(fileName, resizeImg)

            End If

            e.Value = Images(fileName)
        End If
    End Sub

    Private Sub CheckImg_CheckedChanged(sender As Object, e As EventArgs) Handles CheckImg.CheckedChanged
        Cursor = Cursors.WaitCursor
        Dim val As String = CheckImg.EditValue.ToString
        If val = "True" Then
            BGVLineList.RowHeight = 100
            BGVLineList.Columns("img").Visible = True
        Else
            BGVLineList.RowHeight = 10
            BGVLineList.Columns("img").Visible = False
        End If
        GCLineList.RefreshDataSource()
        BGVLineList.RefreshData()
        Cursor = Cursors.Default
    End Sub

    Private Sub BBSetAddPrc_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BBSetAddPrc.ItemClick
        Cursor = Cursors.WaitCursor
        FormFGLineListAddPrice.ShowDialog()
        Cursor = Cursors.Default
    End Sub
End Class