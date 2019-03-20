Public Class FormMasterDesignCOP 
    Dim bnew_active As String = "1"
    Dim bedit_active As String = "1"
    Dim bdel_active As String = "1"

    Private Sub FormMasterDesignCOP_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        viewSeason()
    End Sub

    Sub viewSeason()
        Dim query As String = "SELECT '-1' AS id_season, 'All Season' AS season,'-1' AS `range` UNION
                                (SELECT a.id_season,a.season,b.range AS `range` FROM tb_season a 
                                INNER JOIN tb_range b ON a.id_range = b.id_range 
                                ORDER BY b.range ASC)"
        viewSearchLookupQuery(SLESeason, query, "id_season", "season", "id_season")
        viewSearchLookupQuery(SLESeasonByCode, query, "range", "season", "range")
    End Sub

    Sub view_design()
        Dim query_where As String = ""

        If Not SLESeason.EditValue.ToString = "-1" Then
            query_where += " AND season.id_season='" & SLESeason.EditValue.ToString & "'"
        End If

        Try
            Dim query As String = "CALL view_all_design_param(""" + query_where + """)"
            Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
            GCDesign.DataSource = data
            BGVDesign.BestFitColumns()
            BGVDesign.ExpandAllGroups()
            check_menu()
        Catch ex As Exception
            errorConnection()
        End Try
    End Sub

    Private Sub GVDesign_FocusedRowChanged(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs)
        Dim focusedRowHandle As Integer = -1
        If e.FocusedRowHandle = DevExpress.XtraGrid.GridControl.NewItemRowHandle OrElse e.FocusedRowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            Return
        End If
        Dim view As DevExpress.XtraGrid.Views.Grid.GridView = CType(sender, DevExpress.XtraGrid.Views.Grid.GridView)
        If e.FocusedRowHandle < 0 Then
            If e.PrevFocusedRowHandle = DevExpress.XtraGrid.GridControl.InvalidRowHandle Then
                focusedRowHandle = 0
            ElseIf Control.MouseButtons = MouseButtons.Left OrElse Control.MouseButtons = MouseButtons.Right Then
                focusedRowHandle = e.PrevFocusedRowHandle
            Else
                Dim prevRow As Integer = view.GetVisibleIndex(e.PrevFocusedRowHandle)
                Dim currRow As Integer = view.GetVisibleIndex(e.FocusedRowHandle)
                If prevRow > currRow Then
                    focusedRowHandle = e.PrevFocusedRowHandle - 1
                Else
                    focusedRowHandle = e.PrevFocusedRowHandle + 1
                End If
                If focusedRowHandle < 0 Then
                    focusedRowHandle = 0
                End If
                If focusedRowHandle >= view.DataRowCount Then
                    focusedRowHandle = view.DataRowCount - 1
                End If
            End If
            If focusedRowHandle < 0 Then
                view.FocusedRowHandle = 0
            Else
                view.FocusedRowHandle = focusedRowHandle
            End If
        End If
    End Sub

    Sub check_menu()
        If BGVDesign.RowCount < 1 Then
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
            checkFormAccess(Name)
            button_main(bnew_active, bedit_active, bdel_active)
        End If
    End Sub

    Private Sub FormMasterDesignCOP_Activated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Activated
        FormMain.show_rb(Name)
        checkFormAccess(Name)
        button_main(bnew_active, bedit_active, bdel_active)
    End Sub

    Private Sub FormMasterDesignCOP_Deactivate(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Deactivate
        FormMain.hide_rb()
    End Sub

    Private Sub BSearch_Click(sender As Object, e As EventArgs) Handles BSearch.Click
        view_design()
    End Sub

    Private Sub GVDesign_PopupMenuShowing(sender As Object, e As DevExpress.XtraGrid.Views.Grid.PopupMenuShowingEventArgs)
        Dim view As DevExpress.XtraGrid.Views.Grid.GridView = CType(sender, DevExpress.XtraGrid.Views.Grid.GridView)
        Dim hitInfo As DevExpress.XtraGrid.Views.Grid.ViewInfo.GridHitInfo = view.CalcHitInfo(e.Point)
        If hitInfo.InRow And hitInfo.RowHandle >= 0 Then
            view.FocusedRowHandle = hitInfo.RowHandle
            ViewMenu.Show(view.GridControl, e.Point)
        End If
    End Sub

    Private Sub SMEditEcopFinal_Click(sender As Object, e As EventArgs) Handles SMEditEcopFinal.Click
        'MASTER RET CODE
        FormProductionCOP.id_design = BGVDesign.GetFocusedRowCellValue("id_design").ToString
        FormProductionCOP.ShowDialog()
    End Sub

    Private Sub SMEditEcopPD_Click(sender As Object, e As EventArgs) Handles SMEditEcopPD.Click
        FormMasterDesignCOPPD.id_design = BGVDesign.GetFocusedRowCellValue("id_design").ToString
        FormMasterDesignCOPPD.TECode.Text = BGVDesign.GetFocusedRowCellValue("design_code").ToString
        FormMasterDesignCOPPD.TEDesc.Text = BGVDesign.GetFocusedRowCellValue("design_display_name").ToString
        '
        FormMasterDesignCOPPD.ShowDialog()
    End Sub

    Private Sub BGVDesign_PopupMenuShowing(sender As Object, e As DevExpress.XtraGrid.Views.Grid.PopupMenuShowingEventArgs) Handles BGVDesign.PopupMenuShowing
        Dim view As DevExpress.XtraGrid.Views.Grid.GridView = CType(sender, DevExpress.XtraGrid.Views.Grid.GridView)
        Dim hitInfo As DevExpress.XtraGrid.Views.Grid.ViewInfo.GridHitInfo = view.CalcHitInfo(e.Point)
        If hitInfo.InRow And hitInfo.RowHandle >= 0 Then
            view.FocusedRowHandle = hitInfo.RowHandle
            ViewMenu.Show(view.GridControl, e.Point)
        End If
    End Sub

    Private Sub CEFreeze_CheckedChanged(sender As Object, e As EventArgs) Handles CEFreeze.CheckedChanged
        If CEFreeze.Checked = True Then 'freeze band detail
            GridBandDetail.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left
        Else 'not freeze
            GridBandDetail.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.None
        End If
    End Sub

    Private Sub CEShowImg_CheckedChanged(sender As Object, e As EventArgs) Handles CEShowImg.CheckedChanged
        Cursor = Cursors.WaitCursor
        Dim val As String = CEShowImg.EditValue.ToString
        If val = "True" Then
            Picture.Visible = True
            Picture.VisibleIndex = 0
        Else
            Picture.Visible = False
        End If
        GCDesign.RefreshDataSource()
        BGVDesign.RefreshData()
        Cursor = Cursors.Default
    End Sub

    Private ImageDir As String = product_image_path
    Private Images As Hashtable = New Hashtable()
    Private Sub BGVDesign_CustomUnboundColumnData(sender As Object, e As DevExpress.XtraGrid.Views.Base.CustomColumnDataEventArgs) Handles BGVDesign.CustomUnboundColumnData
        If e.Column.FieldName = "img" AndAlso e.IsGetData And CEShowImg.EditValue.ToString = "True" Then
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

    Private Sub ViewDetailToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ViewDetailToolStripMenuItem.Click
        FormMasterDesignSingle.id_pop_up = "4"
        FormMasterDesignSingle.id_design = BGVDesign.GetFocusedRowCellValue("id_design").ToString
        FormMasterDesignSingle.ShowDialog()
    End Sub

    Private Sub BSearchByCode_Click(sender As Object, e As EventArgs) Handles BSearchByCode.Click
        view_design_by_code()
    End Sub

    Sub view_design_by_code()
        Dim query_where As String = ""

        If Not SLESeasonByCode.EditValue.ToString = "-1" Then
            query_where += " AND RIGHT(f1.design_code,2)='" & SLESeasonByCode.EditValue.ToString & "'"
        End If

        Try
            Dim query As String = "CALL view_all_design_param(""" + query_where + """)"
            Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
            GCDesign.DataSource = data
            BGVDesign.BestFitColumns()
            BGVDesign.ExpandAllGroups()
            check_menu()
        Catch ex As Exception
            errorConnection()
        End Try
    End Sub

    Private Sub BGVDesign_RowStyle(sender As Object, e As DevExpress.XtraGrid.Views.Grid.RowStyleEventArgs) Handles BGVDesign.RowStyle
        Try
            If BGVDesign.GetRowCellValue(e.RowHandle, "id_lookup_status_order").ToString = "2" Then
                e.Appearance.BackColor = Color.Salmon
                e.Appearance.ForeColor = Color.Red
                e.Appearance.FontStyleDelta = FontStyle.Bold
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub BRefresh_Click(sender As Object, e As EventArgs) Handles BRefresh.Click
        load_propose()
    End Sub

    Sub load_propose()
        Dim query As String = "SELECT dcp.*,emp.`employee_name`,st.`report_status`,last_mark.employee_name AS last_mark_by FROM `tb_design_cop_propose` dcp
                                INNER JOIN tb_m_user usr ON usr.`id_user`=dcp.`created_by`
                                INNER JOIN tb_m_employee emp ON emp.`id_employee`=usr.`id_employee`
                                LEFT JOIN
                                (
	                                SELECT mark.id_report_mark,mark.id_report,emp.employee_name,maxd.report_mark_datetime,mark.report_number
	                                FROM tb_report_mark mark
	                                INNER JOIN tb_m_employee emp ON emp.`id_employee`=mark.id_employee
	                                INNER JOIN 
	                                (
	                                    SELECT mark.id_report,mark.report_mark_type,MAX(report_mark_datetime) AS report_mark_datetime
	                                    FROM tb_report_mark mark
	                                    WHERE mark.id_mark='2' AND NOT ISNULL(report_mark_start_datetime) AND report_mark_type='150'
	                                    GROUP BY report_mark_type,id_report
	                                ) maxd ON maxd.id_report=mark.id_report AND maxd.report_mark_type=mark.report_mark_type AND maxd.report_mark_datetime=mark.report_mark_datetime
	                                WHERE mark.id_mark='2' AND NOT ISNULL(mark.report_mark_start_datetime) AND mark.report_mark_type='150'
                                )last_mark ON last_mark.id_report=dcp.`id_design_cop_propose`
                                INNER JOIN tb_lookup_report_status st ON st.`id_report_status`=dcp.`id_report_status`"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCCostPropose.DataSource = data
        GVCostPropose.BestFitColumns()
    End Sub

    Private Sub BProposeCost_Click(sender As Object, e As EventArgs) Handles BProposeCost.Click
        FormMasterDesignCOPPropose.ShowDialog()
    End Sub

    Private Sub GVCostPropose_DoubleClick(sender As Object, e As EventArgs) Handles GVCostPropose.DoubleClick
        FormMasterDesignCOPPropose.id_propose = GVCostPropose.GetFocusedRowCellValue("id_design_cop_propose").ToString
        FormMasterDesignCOPPropose.ShowDialog()
    End Sub
End Class