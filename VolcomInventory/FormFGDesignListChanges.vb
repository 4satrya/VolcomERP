Public Class FormFGDesignListChanges
    Public id As String = "-1"
    Public is_view As String = "-1"
    Dim id_report_status As String = "-1"
    Dim is_confirm As String = "-1"
    Dim rmt As String = "200"
    Public is_md As String = "-1"


    Private Sub FormFGDesignListChanges_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        viewReportStatus()
        actionLoad()
    End Sub

    Private Sub FormFGDesignListChanges_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Sub viewReportStatus()
        Dim query As String = "SELECT * FROM tb_lookup_report_status a ORDER BY a.id_report_status "
        'Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        viewLookupQuery(LEReportStatus, query, 0, "report_status", "id_report_status")
    End Sub

    Sub actionLoad()
        Cursor = Cursors.WaitCursor
        'main
        Dim query_c As ClassDesign = New ClassDesign()
        Dim query As String = query_c.queryProposeChanges("AND dc.id_changes=" + id + " ", "2")
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        TxtNumber.Text = data.Rows(0)("number").ToString
        MENote.Text = data.Rows(0)("note").ToString
        DECreated.EditValue = data.Rows(0)("created_date")
        is_confirm = data.Rows(0)("is_confirm").ToString
        is_md = data.Rows(0)("is_md").ToString
        LEReportStatus.ItemIndex = LEReportStatus.Properties.GetDataSourceRowIndex("id_report_status", data.Rows(0)("id_report_status").ToString)
        id_report_status = data.Rows(0)("id_report_status").ToString

        'detail
        viewDetail()
        allow_status()
        Cursor = Cursors.Default
    End Sub

    Sub viewDetail()
        Cursor = Cursors.WaitCursor

        Dim query As String = ""
        If is_md = "1" Then
            XTCType.SelectedTabPageIndex = 0

            gridBandCodeImport.Visible = True
            gridBandName.Visible = True
            gridBandSor.Visible = True
            gridBandFabrication.Visible = True
            gridBandDesignDetail.Visible = True
            gridBandSource.Visible = True
            gridBandDivision.Visible = True
            gridBandSubCat.Visible = True
            gridBandClass.Visible = True
            gridBandColor.Visible = True

            gridBandCodeImport.VisibleIndex = 0
            gridBandName.VisibleIndex = 1
            gridBandSor.VisibleIndex = 2
            gridBandFabrication.VisibleIndex = 3
            gridBandDesignDetail.VisibleIndex = 4
            gridBandSource.VisibleIndex = 5
            gridBandDivision.VisibleIndex = 6
            gridBandSubCat.VisibleIndex = 7
            gridBandClass.VisibleIndex = 8
            gridBandColor.VisibleIndex = 9

            query = "SELECT 0 AS RowHeight, dr.design_code AS `code_view`, dr.design_display_name AS `name_view`,
            pd.id_prod_demand, pd.prod_demand_number, po.id_prod_order, po.prod_order_number,
            dr.id_design, d.id_design AS `id_design_new`,
            dr.design_code AS `code`, d.design_code AS `code_new`,
            IF(det.c_design_code_import=1,dr.design_code_import,'-') AS `code_import`, IF(det.c_design_code_import=1,d.design_code_import,'-') AS `code_import_new`,
            IF(det.c_design_display_name=1,dr.design_display_name,'-') AS `name`, IF(det.c_design_display_name=1,d.design_display_name,'-') AS `name_new`,
            IF(det.c_id_season_orign=1,sordr.season_orign_display,'-') AS `season_orign`, IF(det.c_id_season_orign=1,sor.season_orign_display,'-') AS `season_orign_new`,
            IF(det.c_design_fabrication=1, dr.design_fabrication,'-') AS `design_fabrication`, IF(det.c_design_fabrication=1, d.design_fabrication,'-') AS `design_fabrication_new`,
            IF(det.c_design_detail=1,dr.design_detail, '-') AS `design_detail`, IF(det.c_design_detail=1,d.design_detail, '-') AS `design_detail_new`,
            IF(det.c_source=1,src.`source`, '-') AS `source`, IF(det.c_source=1,src_new.`source_new`, '-') AS `source_new`,
            IF(det.c_division=1,dvs.division,'-') AS `division`, IF(det.c_division=1,dvs_new.division_new,'-') AS `division_new`,
            IF(det.c_subcategory=1, subcat.sub_category,'-') AS `sub_category`, IF(det.c_subcategory=1, subcat_new.sub_category_new,'-') AS `sub_category_new`,
            IF(det.c_class=1, cls.class, '-') AS `class`, IF(det.c_class=1, cls_new.class_new, '-') AS `class_new`,
            IF(det.c_color=1, col.color,'-') AS `color`, IF(det.c_color=1, col_new.color_new,'-') AS `color_new`,
            det.c_design_name, det.c_design_code_import, det.c_design_display_name, det.c_id_season_orign, 
            det.c_design_fabrication, det.c_design_detail,
            det.c_source, det.c_division, det.c_subcategory, det.c_class, det.c_color "
            Dim dsg As New ClassDesign()
            query += dsg.queryPCDBodyDetail(id)
            Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
            GCData.DataSource = data

            'cek column
            GVData.ActiveFilterString = "c_design_display_name=1 "
            If GVData.RowCount <= 0 Then
                gridBandName.Visible = False
            End If
            GVData.ActiveFilterString = "c_design_code_import=1 "
            If GVData.RowCount <= 0 Then
                gridBandCodeImport.Visible = False
            End If
            GVData.ActiveFilterString = "c_id_season_orign=1 "
            If GVData.RowCount <= 0 Then
                gridBandSor.Visible = False
            End If
            GVData.ActiveFilterString = "c_design_fabrication=1 "
            If GVData.RowCount <= 0 Then
                gridBandFabrication.Visible = False
            End If
            GVData.ActiveFilterString = "c_design_detail=1 "
            If GVData.RowCount <= 0 Then
                gridBandDesignDetail.Visible = False
            End If
            GVData.ActiveFilterString = "c_source=1 "
            If GVData.RowCount <= 0 Then
                gridBandSource.Visible = False
            End If
            GVData.ActiveFilterString = "c_division=1 "
            If GVData.RowCount <= 0 Then
                gridBandDivision.Visible = False
            End If
            GVData.ActiveFilterString = "c_subcategory=1 "
            If GVData.RowCount <= 0 Then
                gridBandSubCat.Visible = False
            End If
            GVData.ActiveFilterString = "c_class=1 "
            If GVData.RowCount <= 0 Then
                gridBandClass.Visible = False
            End If
            GVData.ActiveFilterString = "c_color=1 "
            If GVData.RowCount <= 0 Then
                gridBandColor.Visible = False
            End If
            makeSafeGV(GVData)
            GVData.BestFitColumns()
        Else 'non 
            XTCType.SelectedTabPageIndex = 1
            'query = ""
            'Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
            'GCData.DataSource = data
            'GVData.BestFitColumns()
        End If
        Cursor = Cursors.Default
    End Sub

    Sub allow_status()
        BtnAttachment.Visible = True
        BtnCancell.Visible = True
        If is_confirm = "2" And is_view = "-1" Then
            BtnConfirm.Visible = True
            BtnMark.Visible = False
            PanelControlNav.Visible = True
            BtnPrint.Visible = False
            BtnSaveChanges.Visible = True
            MENote.Properties.ReadOnly = False
            GVData.OptionsBehavior.ReadOnly = False
        Else
            BtnConfirm.Visible = False
            BtnMark.Visible = True
            PanelControlNav.Visible = False
            BtnPrint.Visible = True
            BtnSaveChanges.Visible = False
            MENote.Properties.ReadOnly = True
            GVData.OptionsBehavior.ReadOnly = True
        End If

        'reset propose
        If is_view = "-1" And is_confirm = "1" Then
            BtnResetPropose.Visible = True
        Else
            BtnResetPropose.Visible = False
        End If

        If id_report_status = "6" Then
            BtnCancell.Visible = False
            BtnResetPropose.Visible = False
        ElseIf id_report_status = "5" Then
            BtnCancell.Visible = False
            BtnResetPropose.Visible = False
            BtnConfirm.Visible = False
            BtnPrint.Visible = False
            PanelControlNav.Visible = False
            BtnSaveChanges.Visible = False
            MENote.Properties.ReadOnly = True
            GVData.OptionsBehavior.ReadOnly = True
        End If
    End Sub

    Private Sub BtnAdd_Click(sender As Object, e As EventArgs) Handles BtnAdd.Click
        Cursor = Cursors.WaitCursor
        FormFGDesignListChangesDesign.ShowDialog()
        Cursor = Cursors.Default
    End Sub

    Sub saveChangesDetail()
        Cursor = Cursors.WaitCursor
        Cursor = Cursors.Default
    End Sub

    Private Sub BtnDel_Click(sender As Object, e As EventArgs) Handles BtnDel.Click
        If GVData.RowCount > 0 And GVData.FocusedRowHandle >= 0 Then
            Dim confirm As DialogResult = DevExpress.XtraEditors.XtraMessageBox.Show("Are you sure you want to delete this item(s) ?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
            If confirm = Windows.Forms.DialogResult.Yes Then
                Cursor = Cursors.WaitCursor
                Dim id_design As String = GVData.GetFocusedRowCellValue("id_design_new").ToString
                Dim query As String = "DELETE FROM tb_m_design WHERE id_design=" + id_design + " "
                execute_non_query(query, True, "", "", "", "")
                viewDetail()
                Cursor = Cursors.Default
            End If
        End If
    End Sub

    Private Sub BtnCancell_Click(sender As Object, e As EventArgs) Handles BtnCancell.Click
        Dim confirm As DialogResult = DevExpress.XtraEditors.XtraMessageBox.Show("Are you sure you want to cancelled this propose ?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
        If confirm = Windows.Forms.DialogResult.Yes Then
            Cursor = Cursors.WaitCursor
            Dim query As String = "UPDATE tb_m_design_changes SET id_report_status=5 WHERE id_changes='" + id + "'; 
            UPDATE tb_m_design d
            INNER JOIN (
	            SELECT pcd_det.id_design 
	            FROM tb_m_design_changes_det pcd_det
	            WHERE pcd_det.id_changes=" + id + "
            ) src ON src.id_design = d.id_design
            SET d.id_lookup_status_order=2; "
            execute_non_query(query, True, "", "", "", "")

            'nonaktif mark
            Dim queryrm = String.Format("UPDATE tb_report_mark SET report_mark_lead_time=NULL,report_mark_start_datetime=NULL WHERE report_mark_type='{0}' AND id_report='{1}' AND id_report_status>'1'", rmt, id, "5")
            execute_non_query(queryrm, True, "", "", "", "")

            FormFGDesignList.viewPropose()
            FormFGDesignList.GVPropose.FocusedRowHandle = find_row(FormFGDesignList.GVPropose, "id_changes", id)
            actionLoad()
            Cursor = Cursors.Default
        End If
    End Sub

    Private Sub BtnAttachment_Click(sender As Object, e As EventArgs) Handles BtnAttachment.Click
        Cursor = Cursors.WaitCursor
        FormDocumentUpload.report_mark_type = rmt
        FormDocumentUpload.id_report = id
        If is_view = "1" Or id_report_status = "6" Or id_report_status = "5" Or is_confirm = "1" Then
            FormDocumentUpload.is_view = "1"
        End If
        FormDocumentUpload.ShowDialog()
        Cursor = Cursors.Default
    End Sub

    Private Sub BtnPrint_Click(sender As Object, e As EventArgs) Handles BtnPrint.Click
        Cursor = Cursors.WaitCursor
        RepoLinkPD.LinkColor = Color.Black
        If Not check_allow_print(id_report_status, rmt, id) Then
            warningCustom("Can't print, please complete all approval on system first")
        Else
            Dim gv As DevExpress.XtraGrid.Views.Grid.GridView = Nothing
            gv = GVData
            ReportFGDesignListChanges.dt = GCData.DataSource
            ReportFGDesignListChanges.id = id
            If id_report_status <> "6" Then
                ReportFGDesignListChanges.is_pre = "1"
            Else
                ReportFGDesignListChanges.is_pre = "-1"
            End If
            ReportFGDesignListChanges.id_report_status = LEReportStatus.EditValue.ToString

            ReportFGDesignListChanges.rmt = rmt
            Dim Report As New ReportFGDesignListChanges()

            '... 
            ' creating And saving the view's layout to a new memory stream 
            Dim str As System.IO.Stream
            str = New System.IO.MemoryStream()
            gv.SaveLayoutToStream(str, DevExpress.Utils.OptionsLayoutBase.FullLayout)
            str.Seek(0, System.IO.SeekOrigin.Begin)
            Report.GVData.RestoreLayoutFromStream(str, DevExpress.Utils.OptionsLayoutBase.FullLayout)
            str.Seek(0, System.IO.SeekOrigin.Begin)

            'style
            Report.GVData.AppearancePrint.BandPanel.BorderColor = Color.Black
            Report.GVData.AppearancePrint.BandPanel.BackColor = Color.Transparent
            Report.GVData.AppearancePrint.BandPanel.ForeColor = Color.Black
            Report.GVData.AppearancePrint.BandPanel.Font = New Font("Tahoma", 7, FontStyle.Bold)

            Report.GVData.OptionsPrint.UsePrintStyles = True
            Report.GVData.AppearancePrint.FilterPanel.BackColor = Color.Transparent
            Report.GVData.AppearancePrint.FilterPanel.ForeColor = Color.Black
            Report.GVData.AppearancePrint.FilterPanel.Font = New Font("Tahoma", 7, FontStyle.Regular)

            Report.GVData.AppearancePrint.GroupFooter.BackColor = Color.WhiteSmoke
            Report.GVData.AppearancePrint.GroupFooter.ForeColor = Color.Black
            Report.GVData.AppearancePrint.GroupFooter.Font = New Font("Tahoma", 7, FontStyle.Bold)

            Report.GVData.AppearancePrint.GroupRow.BackColor = Color.Transparent
            Report.GVData.AppearancePrint.GroupRow.ForeColor = Color.Black
            Report.GVData.AppearancePrint.GroupRow.Font = New Font("Tahoma", 7, FontStyle.Bold)

            Report.GVData.AppearancePrint.HeaderPanel.BorderColor = Color.Black
            Report.GVData.AppearancePrint.HeaderPanel.BackColor = Color.Transparent
            Report.GVData.AppearancePrint.HeaderPanel.ForeColor = Color.Black
            Report.GVData.AppearancePrint.HeaderPanel.Font = New Font("Tahoma", 7, FontStyle.Bold)

            Report.GVData.AppearancePrint.FooterPanel.BackColor = Color.Gainsboro
            Report.GVData.AppearancePrint.FooterPanel.ForeColor = Color.Black
            Report.GVData.AppearancePrint.FooterPanel.Font = New Font("Tahoma", 7.3, FontStyle.Bold)

            Report.GVData.AppearancePrint.Row.ForeColor = Color.Black
            Report.GVData.AppearancePrint.Row.Font = New Font("Tahoma", 7.3, FontStyle.Regular)

            Report.GVData.AppearancePrint.Lines.BackColor = Color.Black

            Report.GVData.OptionsPrint.ExpandAllDetails = True
            Report.GVData.OptionsPrint.UsePrintStyles = True
            Report.GVData.OptionsPrint.PrintDetails = True
            Report.GVData.OptionsPrint.PrintFooter = True

            Report.LabelNumber.Text = TxtNumber.Text
            Report.LabelDate.Text = DECreated.Text.ToUpper
            Report.LabelStatus.Text = LEReportStatus.Text.ToUpper
            Report.LNote.Text = MENote.Text

            ' Show the report's preview. 
            Dim Tool As DevExpress.XtraReports.UI.ReportPrintTool = New DevExpress.XtraReports.UI.ReportPrintTool(Report)
            Tool.ShowPreviewDialog()
        End If
        Cursor = Cursors.Default
    End Sub

    Private Sub BtnMark_Click(sender As Object, e As EventArgs) Handles BtnMark.Click
        Cursor = Cursors.WaitCursor
        FormReportMark.report_mark_type = rmt
        FormReportMark.id_report = id
        FormReportMark.is_view = is_view
        FormReportMark.form_origin = Name
        FormReportMark.ShowDialog()
        Cursor = Cursors.Default
    End Sub

    Sub saveHead()
        'head
        Dim note As String = addSlashes(MENote.Text)
        Dim query_head As String = "UPDATE tb_m_design_changes SET note='" + note + "', created_date=NOW()
        WHERE id_changes='" + id + "' "
        execute_non_query(query_head, True, "", "", "", "")
    End Sub

    Private Sub BtnSaveChanges_Click(sender As Object, e As EventArgs) Handles BtnSaveChanges.Click
        Dim confirm As DialogResult = DevExpress.XtraEditors.XtraMessageBox.Show("Are you sure you want to save changes this propose ?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
        If confirm = Windows.Forms.DialogResult.Yes Then
            'head
            saveHead()

            'detail
            saveChangesDetail()

            actionLoad()
            FormFGDesignList.viewPropose()
            FormFGDesignList.GVPropose.FocusedRowHandle = find_row(FormFGDesignList.GVPropose, "id_changes", id)
        End If
    End Sub

    Private Sub BtnConfirm_Click(sender As Object, e As EventArgs) Handles BtnConfirm.Click
        makeSafeGV(GVData)
        If GVData.RowCount <= 0 Then
            stopCustom("No propose were made. If you want to cancel this propose, please click 'Cancel Propose'")
        Else
            Dim confirm As DialogResult = DevExpress.XtraEditors.XtraMessageBox.Show("Are you sure you want to confirm this Propose Design Changes ?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
            If confirm = Windows.Forms.DialogResult.Yes Then
                Cursor = Cursors.WaitCursor
                'update 
                saveHead()
                saveChangesDetail()

                'update confirm
                Dim query As String = "UPDATE tb_m_design_changes SET is_confirm=1 WHERE id_changes='" + id + "'"
                execute_non_query(query, True, "", "", "", "")

                'submit approval 
                submit_who_prepared(rmt, id, id_user)
                BtnConfirm.Visible = False
                actionLoad()
                infoCustom("Propose Design Changes submitted. Waiting for approval.")
                Cursor = Cursors.Default
            End If
        End If
    End Sub

    Private Sub BtnResetPropose_Click(sender As Object, e As EventArgs) Handles BtnResetPropose.Click
        Dim query As String = "SELECT * FROM tb_report_mark rm WHERE rm.report_mark_type=" + rmt + " AND rm.id_report_status=2 
        AND rm.is_requisite=2 AND rm.id_mark=2 AND rm.id_report=" + id + " "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        If data.Rows.Count = 0 Then
            Dim confirm As DialogResult = DevExpress.XtraEditors.XtraMessageBox.Show("This action will be reset approval and you can update this propose. Are you sure you want to reset this propose ?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
            If confirm = Windows.Forms.DialogResult.Yes Then
                Dim query_upd As String = "-- delete report mark
                DELETE FROM tb_report_mark WHERE report_mark_type=" + rmt + " AND id_report=" + id + "; 
                -- reset confirm
                UPDATE tb_m_design_changes SET is_confirm=2 WHERE id_changes=" + id + "; "
                execute_non_query(query_upd, True, "", "", "", "")

                'refresh
                FormFGDesignList.viewPropose()
                FormFGDesignList.GVPropose.FocusedRowHandle = find_row(FormFGDesignList.GVPropose, "id_changes", id)
                actionLoad()
            End If
        Else
            stopCustom("This propose already process")
        End If
    End Sub

    Private Sub BtnEdit_Click(sender As Object, e As EventArgs) Handles BtnEdit.Click
        If GVData.RowCount > 0 And GVData.FocusedRowHandle >= 0 Then
            Cursor = Cursors.WaitCursor
            FormMasterDesignSingle.id_pop_up = "5"
            FormMasterDesignSingle.WindowState = FormWindowState.Maximized
            FormMasterDesignSingle.form_name = Name
            Dim id_dsg_param As String = "-1"
            Try
                id_dsg_param = GVData.GetFocusedRowCellValue("id_design_new").ToString
            Catch ex As Exception
            End Try

            FormMasterDesignSingle.id_changes = id
            FormMasterDesignSingle.is_pcd = "1"
            FormMasterDesignSingle.id_design = id_dsg_param
            FormMasterDesignSingle.ShowDialog()
            Cursor = Cursors.Default
        End If
    End Sub

    Private Sub RepoLinkPD_Click(sender As Object, e As EventArgs) Handles RepoLinkPD.Click
        Cursor = Cursors.WaitCursor
        Dim id_pd As String = GVData.GetFocusedRowCellValue("id_prod_demand").ToString
        FormViewProdDemand.id_prod_demand = id_pd
        FormViewProdDemand.is_for_design = True
        FormViewProdDemand.ShowDialog()
        Cursor = Cursors.Default
    End Sub

    Private Sub GVData_CustomColumnDisplayText(sender As Object, e As DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs) Handles GVData.CustomColumnDisplayText
        If e.Column.FieldName = "no" Then
            e.DisplayText = (e.ListSourceRowIndex + 1).ToString()
        End If
    End Sub

    Private Sub GVData_CalcRowHeight(sender As Object, e As DevExpress.XtraGrid.Views.Grid.RowHeightEventArgs) Handles GVData.CalcRowHeight
        Dim dt As DataTable = GCData.DataSource

        dt.Rows(e.RowHandle)("RowHeight") = e.RowHeight

        GCData.DataSource = dt
    End Sub
End Class