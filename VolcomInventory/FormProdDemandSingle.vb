Public Class FormProdDemandSingle
    Public id_season As String
    Public id_prod_demand As String = "-1"
    Public id_prod_demand_ref As String = "-1"
    Public action As String
    Public id_report_status As String = "-1"
    Public id_division As String = "-1"
    Public id_pd_type As String = "-1"
    Public id_pd As String = "-1"
    Public id_design_list As New List(Of String)
    Dim vmenu As New System.Windows.Forms.ContextMenuStrip
    Dim short_name_ss As String = "-1"
    Public type_line_list As String = "-1"
    Public dsg_line_list As String = "-1"
    Public ss_line_list As String = "-1"
    Public id_pd_kind As String = "-1"

    Dim id_role_super_admin As String = "-1"
    Public data_column As New DataTable

    '----------------GENERAL------------------------
    'Form Close
    Private Sub FormProdDemandSingle_FormClosed(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub
    'Cancel
    Private Sub BtnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCancel.Click
        Close()
    End Sub
    'Validating PD Number 
    Private Sub TEOVHCode_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TxtProdDemandNumber.Validating
        validatingPDNumber()
    End Sub
    'Procedure validating PD Number
    Sub validatingPDNumber()
        'Dim query As String = "SELECT COUNT(*) FROM tb_prod_demand WHERE prod_demand_number = '" + TxtProdDemandNumber.Text + "' "
        'If action = "upd" Then
        '    query += "AND id_prod_demand != '" + id_prod_demand + "' "
        'End If
        'Dim jml As Integer = execute_query(query, 0, True, "", "", "", "")
        'If jml > 0 Then
        '    EP_TE_already_used(EPProdDemand, TxtProdDemandNumber, "1")
        'Else
        '    EP_TE_cant_blank(EPProdDemand, TxtProdDemandNumber)
        'End If
    End Sub
    'Form Load
    Private Sub FormProdDemandSingle_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'initial role super admin
        id_role_super_admin = get_setup_field("id_role_super_admin")

        viewCategory()
        viewSeason()
        viewKind()
        viewPDType()
        _view_division_fg(LESampleDivision)
        viewReportStatus()

        'menu design info
        Dim vmenu_prop As ClassOwnMenu = New ClassOwnMenu()
        vmenu_prop.createDesignInfoForPD(vmenu, GVDesign)

        'from line list
        If dsg_line_list <> "-1" Then
            SLESeason.EditValue = ss_line_list
        End If

        'non md default type
        If SLEKind.EditValue.ToString <> "1" Then
            LECat.ItemIndex = LECat.Properties.GetDataSourceRowIndex("id_pd", "1")
            GVDesign.OptionsView.ColumnAutoWidth = True
        End If

        actionLoad()

        'divisi non md - tidak punya divisi biarkan stelah action load
        If SLEKind.EditValue.ToString <> "1" Then
            LESampleDivision.EditValue = Nothing
            LESampleDivision.Enabled = False
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
    End Sub

    'type
    Sub viewKind()
        Dim query As String = "SELECT * FROM tb_lookup_pd_kind "
        If id_role_login <> id_role_super_admin Then
            query += "WHERE id_departement='" + id_departement_user + "' "
        End If
        query += "ORDER BY id_pd_kind ASC "
        viewSearchLookupQuery(SLEKind, query, "id_pd_kind", "pd_kind", "id_pd_kind")
    End Sub

    'phase
    Sub viewCategory()
        Dim query As String = "SELECT * FROM tb_lookup_pd WHERE id_pd!='2' ORDER BY id_pd ASC"
        viewLookupQuery(LECat, query, 0, "pd", "id_pd")
    End Sub

    'view PD Type
    Sub viewPDType()
        Dim query As String = "SELECT * FROM tb_lookup_pd_type ORDER BY id_pd_type ASC "
        viewLookupQuery(LEPDType, query, 0, "pd_type", "id_pd_type")
    End Sub

    'report status
    Sub viewReportStatus()
        Dim query As String = "SELECT * FROM tb_lookup_report_status a ORDER BY a.id_report_status "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        viewLookupQuery(LEReportStatus, query, 0, "report_status", "id_report_status")
    End Sub

    'view season
    Sub viewSeason()
        Dim query As String = "SELECT * FROM tb_season a "
        query += "INNER JOIN tb_range b ON a.id_range = b.id_range "
        query += "WHERE b.id_departement='" + id_departement_user + "' "
        query += "ORDER BY b.range DESC "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        SLESeason.Properties.DataSource = Nothing
        SLESeason.Properties.DataSource = data
        SLESeason.Properties.DisplayMember = "season"
        SLESeason.Properties.ValueMember = "id_season"
        If data.Rows.Count.ToString >= 1 Then
            SLESeason.EditValue = data.Rows(0)("id_season").ToString
            short_name_ss = data.Rows(0)("season_printed_name").ToString
        Else
            SLESeason.EditValue = Nothing
        End If
    End Sub
    'action load
    Sub actionLoad()
        If action = "ins" Then
            'LabelPD.Text = "New Production Demand"
            BtnPrint.Enabled = False
            BMark.Visible = False
            BtnAttachment.Enabled = False
            GroupControlList.Enabled = False

            Dim query_now As String = "SELECT NOW();"
            Dim data As DataTable = execute_query(query_now, -1, True, "", "", "", "")
            DEForm.EditValue = data.Rows(0)("now()")
        ElseIf action = "upd" Then
            'Edit genneral
            GroupControlList.Enabled = True
            checkUpload()
            BtnSave.Text = "Save Changes"
            BtnCancel.Text = "Close"
            SLESeason.EditValue = id_season

            LECat.ItemIndex = LECat.Properties.GetDataSourceRowIndex("id_pd", id_pd)
            SLEKind.EditValue = id_pd_kind
            LEPDType.ItemIndex = LEPDType.Properties.GetDataSourceRowIndex("id_pd_type", id_pd_type)
            LESampleDivision.ItemIndex = LESampleDivision.Properties.GetDataSourceRowIndex("id_code_detail", id_division)
            LEReportStatus.ItemIndex = LEReportStatus.Properties.GetDataSourceRowIndex("id_report_status", id_report_status)

            ButtonEdit1.Enabled = False
            BtnDelRef.Enabled = False

            'Design tab
            viewDesignDemand()
            allow_status()
        End If
    End Sub

    Sub allow_status()
        Dim rmt As String = "-1"
        If SLEKind.EditValue.ToString = "1" Then
            rmt = "9"
        ElseIf SLEKind.EditValue.ToString = "2" Then
            rmt = "80"
        Else
            rmt = "81"
        End If
        'Based on report status
        If check_edit_report_status(id_report_status, rmt, id_prod_demand) Then
            'MsgBox("Masih Boleh")
            BtnSave.Enabled = True
            PanelControlNav.Visible = True
            SLEKind.Enabled = False
            LESampleDivision.Enabled = False
            LEPDType.Enabled = True
            SLESeason.Enabled = False
            MENote.Enabled = True
            LECat.Enabled = True
        Else
            'MsgBox("Nggak Boleh")
            BtnSave.Enabled = False
            PanelControlNav.Visible = False
            SLEKind.Enabled = False
            LESampleDivision.Enabled = False
            LEPDType.Enabled = False
            SLESeason.Enabled = False
            MENote.Enabled = False
            LECat.Enabled = False
        End If

        If check_attach_report_status(id_report_status, rmt, id_prod_demand) Then
            BtnAttachment.Enabled = True
        Else
            BtnAttachment.Enabled = False
        End If

        If check_print_report_status(id_report_status) Then
            BtnPrint.Enabled = True
        Else
            BtnPrint.Enabled = False
        End If

        If id_report_status = "6" Then
            PanelControlCompleted.Visible = True
            XTPRevision.PageVisible = True
        End If
    End Sub

    'Save
    Private Sub BtnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSave.Click
        validatingPDNumber()
        If Not formIsValidInPanel(EPProdDemand, GroupGeneralHeader) Then
            errorInput()
        Else
            Dim query As String
            Dim prod_demand_number As String = addSlashes(TxtProdDemandNumber.Text)
            Dim id_seasonx As String = SLESeason.EditValue
            Dim prod_demand_note As String = MENote.Text.ToString
            Dim id_pd_type As String = "2" 'LEPDType.EditValue.ToString
            Dim id_divisionx As String = "0"
            Try
                id_divisionx = LESampleDivision.EditValue.ToString
            Catch ex As Exception
            End Try
            Dim is_pd As String = LECat.EditValue.ToString
            Dim id_pd_kindx As String = SLEKind.EditValue.ToString

            If action = "ins" Then
                Dim confirm As DialogResult = DevExpress.XtraEditors.XtraMessageBox.Show("Are you sure to save this data ?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
                If confirm = Windows.Forms.DialogResult.Yes Then
                    Cursor = Cursors.WaitCursor
                    Try

                        'get PD Number
                        'prod_demand_number = execute_query("SELECT gen_pd_number('" + id_seasonx + "', '" + id_divisionx + "', '" + id_pd_kind + "')", 0, True, "", "", "", "")

                        'query new
                        If id_prod_demand_ref = "-1" Then
                            query = "INSERT INTO tb_prod_demand(prod_demand_number, id_season, prod_demand_note, id_pd_type, id_pd_kind, prod_demand_date, id_division, is_pd) "
                            query += "VALUES(gen_pd_number('" + id_seasonx + "', '" + id_divisionx + "', '" + id_pd_kindx + "'), '" + id_seasonx + "', '" + prod_demand_note + "', '" + id_pd_type + "', '" + id_pd_kindx + "', NOW(), " + id_divisionx + ", '" + is_pd + "'); SELECT LAST_INSERT_ID(); "
                        Else
                            query = "INSERT INTO tb_prod_demand(prod_demand_number, id_season, prod_demand_note, id_prod_demand_ref, id_pd_type, id_pd_kind, prod_demand_date, id_division, is_pd) "
                            query += "VALUES(gen_pd_number('" + id_seasonx + "', '" + id_divisionx + "', '" + id_pd_kindx + "'), '" + id_seasonx + "', '" + prod_demand_note + "', '" + id_prod_demand_ref + "', '" + id_pd_type + "', '" + id_pd_kindx + "', NOW(), '" + id_divisionx + "', '" + is_pd + "'); SELECT LAST_INSERT_ID(); "
                        End If
                        id_prod_demand = execute_query(query, 0, True, "", "", "", "")


                        insert_who_prepared("9", id_prod_demand, id_user)
                        '
                        logData("tb_prod_demand", 1)

                        'duplicate - Updated 3 Feb 2015
                        If id_prod_demand_ref <> "-1" And id_prod_demand_ref <> "" Then
                            'Dim query_ref As String = "CALL generate_pd_duplicate('" + id_prod_demand + "', '" + id_prod_demand_ref + "') "
                            'execute_non_query(query_ref, True, "", "", "", "")
                        End If

                        'detail
                        If dsg_line_list <> "-1" Then
                            Dim query_det_new As String = "CALL generate_pd_line_list('" + id_prod_demand + "', '" + type_line_list + "', '" + dsg_line_list + "')"
                            execute_non_query(query_det_new, True, "", "", "", "")
                        End If


                        FormProdDemand.viewProdDemand()
                        FormProdDemand.GVProdDemand.FocusedRowHandle = find_row(FormProdDemand.GVProdDemand, "id_prod_demand", id_prod_demand)
                        action = "upd"
                        id_season = id_seasonx
                        id_report_status = LEReportStatus.EditValue.ToString
                        id_division = id_divisionx
                        id_pd = is_pd
                        id_pd_kind = id_pd_kindx
                        actionLoad()
                        prod_demand_number = FormProdDemand.GVProdDemand.GetFocusedRowCellValue("prod_demand_number").ToString
                        TxtProdDemandNumber.Text = prod_demand_number
                        infoCustom("PD : " + prod_demand_number + ", created successfully. Please upload document!")
                        openAttach()
                        checkUpload()
                    Catch ex As Exception
                        errorConnection()
                        Close()
                    End Try
                    Cursor = Cursors.Default
                End If
            ElseIf action = "upd" Then
                Dim confirm As DialogResult = DevExpress.XtraEditors.XtraMessageBox.Show("Are you sure to save this data ?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
                If confirm = Windows.Forms.DialogResult.Yes Then
                    Cursor = Cursors.WaitCursor
                    Try
                        If id_prod_demand_ref = "-1" Or id_prod_demand_ref = "" Then
                            query = "UPDATE tb_prod_demand SET prod_demand_note='" + prod_demand_note + "', id_season='" + id_seasonx + "', id_prod_demand_ref = NULL, id_pd_type='" + id_pd_type + "', id_division='" + id_divisionx + "', is_pd='" + is_pd + "' "
                            query += "WHERE id_prod_demand = '" + id_prod_demand + "'"
                        Else
                            query = "UPDATE tb_prod_demand SET prod_demand_note='" + prod_demand_note + "', id_season='" + id_seasonx + "', id_prod_demand_ref = '" + id_prod_demand_ref + "', id_pd_type='" + id_pd_type + "', id_division='" + id_divisionx + "', is_pd='" + is_pd + "'  "
                            query += "WHERE id_prod_demand = '" + id_prod_demand + "'"
                        End If
                        execute_non_query(query, True, "", "", "", "")
                        logData("tb_prod_demand", 2)
                        infoCustom("PD : " + prod_demand_number + ", edited successfully.")
                        FormProdDemand.viewProdDemand()
                        FormProdDemand.GVProdDemand.FocusedRowHandle = find_row(FormProdDemand.GVProdDemand, "id_prod_demand", id_prod_demand)
                        action = "upd"
                        id_season = id_seasonx
                        id_report_status = LEReportStatus.EditValue.ToString
                        id_pd = is_pd
                        actionLoad()
                    Catch ex As Exception
                        errorConnection()
                        Close()
                    End Try
                    Cursor = Cursors.Default
                End If
            End If
        End If
    End Sub
    '-----------------DESIGN---------------------------------
    Sub viewDesignDemand()
        'initial u/ mengatasi tag yang belum terpanggil
        Dim prod_demand_report As ClassProdDemand = New ClassProdDemand()
        prod_demand_report.printReportLess("-1", GVDesign, GCDesign)

        'build report
        prod_demand_report.printReportLess(id_prod_demand + " AND is_void=2 ", GVDesign, GCDesign)
        If GVDesign.RowCount < 1 Then
            BtnEdit.Enabled = False
            BtnDelete.Enabled = False
            BBom.Enabled = False
        Else
            BtnEdit.Enabled = True
            BtnDelete.Enabled = True
            BBom.Enabled = True
        End If

        'tampung
        If GVDesign.RowCount > 0 Then
            id_design_list.Clear()
            For i As Integer = 0 To ((GVDesign.RowCount - 1) - GetGroupRowCount(GVDesign))
                id_design_list.Add(GVDesign.GetRowCellValue(i, "id_design_desc_report_column").ToString)
            Next
        End If

        'custom view
        optionsViewBanded(GVDesign, "FormProdDemandSingle", "GVDesign", "1")

        GCDesign.RefreshDataSource()
        GVDesign.RefreshData()

        'bestfit
        GVDesign.BestFitColumns()
        check_but()
    End Sub

    Sub viewRevision()
        Cursor = Cursors.WaitCursor
        Dim r As New ClassProdDemand
        Dim query As String = r.queryMainRev("AND r.id_prod_demand=" + id_prod_demand + "", "1")
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCData.DataSource = data
        GVData.BestFitColumns()
        Cursor = Cursors.Default
    End Sub

    'Add Design
    Private Sub BtnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnAdd.Click
        FormProdDemandDesignSingle.action = "ins"
        FormProdDemandDesignSingle.ShowDialog()
    End Sub
    'Edit Design
    Private Sub BtnEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnEdit.Click
        FormProdDemandDesignSingle.action = "upd"
        FormProdDemandDesignSingle.id_prod_demand_design = GVDesign.GetFocusedRowCellValue("id_prod_demand_design").ToString
        FormProdDemandDesignSingle.ShowDialog()
    End Sub

    Private Sub BBom_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BBom.Click
        '
        FormViewBOMFull.id_prod_demand_design = GVDesign.GetFocusedRowCellValue("id_prod_demand_design").ToString
        FormViewBOMFull.ShowDialog()
    End Sub
    'Delete Design
    Private Sub BtnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnDelete.Click
        Dim confirm As DialogResult = DevExpress.XtraEditors.XtraMessageBox.Show("Are you sure want to delete this design?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
        Dim query As String
        If confirm = Windows.Forms.DialogResult.Yes Then
            Cursor = Cursors.WaitCursor
            Try
                Dim id_dsg As String = GVDesign.GetFocusedRowCellValue("id_design_desc_report_column").ToString
                Dim id_prod_demand_design As String = GVDesign.GetFocusedRowCellValue("id_prod_demand_design").ToString
                query = String.Format("DELETE FROM tb_prod_demand_design WHERE id_prod_demand_design = '{0}'", id_prod_demand_design)
                execute_non_query(query, True, "", "", "", "")
                check_but()
                logData("tb_prod_demand_design", 3)
                viewDesignDemand()
                FormProdDemand.viewProdDemand()
                id_design_list.Remove(id_dsg)
                GCDesign.RefreshDataSource()
                GVDesign.RefreshData()
            Catch ex As Exception
                errorDelete()
            End Try
            Cursor = Cursors.Default
        End If
    End Sub
    'Row Click
    'Private Sub GVDesign_RowClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Grid.RowClickEventArgs) Handles GVDesign.RowClick
    '    If Not first_load Then
    '        Try
    '            Dim parse_data As String = GVDesign.GetFocusedRowCellDisplayText("id_prod_demand_design")
    '            If Not parse_data = "" Then
    '                If BtnEdit.Enabled = True Then
    '                    BtnEdit.Enabled = True
    '                End If
    '                If BtnDelete.Enabled = True Then
    '                    BtnDelete.Enabled = True
    '                End If
    '            Else
    '                BtnEdit.Enabled = False
    '                BtnDelete.Enabled = False
    '            End If
    '        Catch ex As Exception
    '            BtnEdit.Enabled = False
    '            BtnDelete.Enabled = False
    '        End Try
    '    End If
    'End Sub
    'Focus Row Changed
    'Private Sub GVDesign_FocusedRowChanged(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles GVDesign.FocusedRowChanged
    '    Dim focusedRowHandle As Integer = -1
    '    If e.FocusedRowHandle = DevExpress.XtraGrid.GridControl.NewItemRowHandle OrElse e.FocusedRowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
    '        Return
    '    End If
    '    Dim view As DevExpress.XtraGrid.Views.Grid.GridView = CType(sender, DevExpress.XtraGrid.Views.Grid.GridView)
    '    If e.FocusedRowHandle < 0 Then
    '        If e.PrevFocusedRowHandle = DevExpress.XtraGrid.GridControl.InvalidRowHandle Then
    '            focusedRowHandle = 0
    '        ElseIf Control.MouseButtons = MouseButtons.Left OrElse Control.MouseButtons = MouseButtons.Right Then
    '            focusedRowHandle = e.PrevFocusedRowHandle
    '        Else
    '            Dim prevRow As Integer = view.GetVisibleIndex(e.PrevFocusedRowHandle)
    '            Dim currRow As Integer = view.GetVisibleIndex(e.FocusedRowHandle)
    '            If prevRow > currRow Then
    '                focusedRowHandle = e.PrevFocusedRowHandle - 1
    '            Else
    '                focusedRowHandle = e.PrevFocusedRowHandle + 1
    '            End If
    '            If focusedRowHandle < 0 Then
    '                focusedRowHandle = 0
    '            End If
    '            If focusedRowHandle >= view.DataRowCount Then
    '                focusedRowHandle = view.DataRowCount - 1
    '            End If
    '        End If
    '        If focusedRowHandle < 0 Then
    '            view.FocusedRowHandle = 0
    '        Else
    '            view.FocusedRowHandle = focusedRowHandle
    '        End If
    '    End If
    'End Sub

    Private Sub ButtonEdit1_ButtonClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraEditors.Controls.ButtonPressedEventArgs) Handles ButtonEdit1.ButtonClick
        Cursor = Cursors.WaitCursor
        FormProdDemandRefSingle.id_pop_up = "1"
        FormProdDemandRefSingle.ShowDialog()
        Cursor = Cursors.Default
    End Sub

    Private Sub BtnDelRef_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnDelRef.Click
        ButtonEdit1.EditValue = ""
        id_prod_demand_ref = "-1"
    End Sub

    'sub check_but
    Sub check_but()
        Dim id_prod_demand_designx As String = "-1"
        Try
            id_prod_demand_designx = GVDesign.GetFocusedRowCellValue("id_prod_demand_design").ToString
        Catch ex As Exception
        End Try

        If GVDesign.RowCount > 0 And id_prod_demand_designx <> "-1" And id_prod_demand_designx <> "" Then
            BtnEdit.Enabled = True
            BtnDelete.Enabled = True
            BBom.Enabled = True
        Else
            BtnEdit.Enabled = False
            BtnDelete.Enabled = False
            BBom.Enabled = False
        End If
    End Sub

    Private Sub GVDesign_FocusedRowChanged_1(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles GVDesign.FocusedRowChanged
        check_but()
    End Sub

    Private Sub GVDesign_ColumnFilterChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GVDesign.ColumnFilterChanged
        check_but()
        If GVDesign.ActiveFilterString = "" Then
            CheckEditShowNonActive.EditValue = False
        End If

    End Sub


    Private Sub BMark_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BMark.Click
        Cursor = Cursors.WaitCursor
        FormReportMark.id_report = id_prod_demand
        If SLEKind.EditValue.ToString = "1" Then 'MD
            FormReportMark.report_mark_type = "9"
        ElseIf SLEKind.EditValue.ToString = "2" Then 'MKT
            FormReportMark.report_mark_type = "80"
        Else 'HRD
            FormReportMark.report_mark_type = "81"
        End If

        FormReportMark.form_origin = Name
        FormReportMark.ShowDialog()
        Cursor = Cursors.Default
    End Sub

    Private Sub BtnAttachment_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnAttachment.Click
        openAttach()
        checkUpload()
    End Sub

    Sub openAttach()
        Cursor = Cursors.WaitCursor
        FormDocumentUpload.id_report = id_prod_demand

        Dim rmt As String = ""
        If SLEKind.EditValue.ToString = "1" Then 'MD
            rmt = "9"
        ElseIf SLEKind.EditValue.ToString = "2" Then 'MKT
            rmt = "80"
        Else 'HRD
            rmt = "81"
        End If
        FormDocumentUpload.report_mark_type = rmt

        'cek ud submit ato blm
        Dim query As String = "SELECT * FROM tb_report_mark d
        WHERE d.report_mark_type=" + rmt + " AND d.id_report=" + id_prod_demand + " "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        If data.Rows.Count > 0 Then
            FormDocumentUpload.is_view = "1"
        End If

        FormDocumentUpload.ShowDialog()
        Cursor = Cursors.Default
    End Sub

    Sub checkUpload()
        'cek
        Dim rmt As String = ""
        If SLEKind.EditValue.ToString = "1" Then 'MD
            rmt = "9"
        ElseIf SLEKind.EditValue.ToString = "2" Then 'MKT
            rmt = "80"
        Else 'HRD
            rmt = "81"
        End If
        Dim query As String = "SELECT * FROM tb_doc d
        WHERE d.report_mark_type=" + rmt + " AND d.id_report=" + id_prod_demand + " "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        If data.Rows.Count > 0 Then
            BMark.Visible = True
        Else
            BMark.Visible = False
        End If
        allow_status()
    End Sub

    Private Sub GVDesign_CustomColumnDisplayText(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs) Handles GVDesign.CustomColumnDisplayText
        If e.Column.FieldName = "No_desc_report_column" Then
            e.DisplayText = (e.ListSourceRowIndex + 1).ToString()
        End If
    End Sub



    Private Sub BtnPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnPrint.Click
        Cursor = Cursors.WaitCursor
        '... 
        ' creating and saving the view's layout to a new memory stream 
        Dim str As System.IO.Stream
        str = New System.IO.MemoryStream()
        GVDesign.SaveLayoutToStream(str, DevExpress.Utils.OptionsLayoutBase.FullLayout)
        str.Seek(0, System.IO.SeekOrigin.Begin)
        ReportProdDemand.dt = GCDesign.DataSource
        ReportProdDemand.id_prod_demand = id_prod_demand
        ReportProdDemand.prod_demand_number = TxtProdDemandNumber.Text
        ReportProdDemand.season = SLESeason.Text
        ReportProdDemand.reff = ButtonEdit1.Text
        ReportProdDemand.phase = LECat.Text
        ReportProdDemand.coba = "TOTAL COST_add_report_column"

        Dim Report As New ReportProdDemand()
        Report.frm_origin = Name
        Report.BandedGridView1.OptionsBehavior.AutoExpandAllGroups = True
        Report.BandedGridView1.RestoreLayoutFromStream(str, DevExpress.Utils.OptionsLayoutBase.FullLayout)
        str.Seek(0, System.IO.SeekOrigin.Begin)
        ReportStyleBanded(Report.BandedGridView1)
        Report.BandedGridView1.AppearancePrint.HeaderPanel.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap

        ' Show the report's preview. 
        Dim Tool As DevExpress.XtraReports.UI.ReportPrintTool = New DevExpress.XtraReports.UI.ReportPrintTool(Report)
        Tool.ShowPreview()
        Cursor = Cursors.Default
    End Sub

    Dim tot_cost As Decimal
    Dim tot_prc As Decimal
    Dim tot_cost_grp As Decimal
    Dim tot_prc_grp As Decimal
    Private Sub GVDesign_CustomSummaryCalculate(ByVal sender As System.Object, ByVal e As DevExpress.Data.CustomSummaryEventArgs) Handles GVDesign.CustomSummaryCalculate
        Dim summaryID As Integer = Convert.ToInt32(CType(e.Item, DevExpress.XtraGrid.GridSummaryItem).Tag)
        Dim View As DevExpress.XtraGrid.Views.Grid.GridView = CType(sender, DevExpress.XtraGrid.Views.Grid.GridView)

        ' Initialization 
        If e.SummaryProcess = DevExpress.Data.CustomSummaryProcess.Start Then
            tot_cost = 0.0
            tot_prc = 0.0
            tot_cost_grp = 0.0
            tot_prc_grp = 0.0
        End If

        ' Calculation 
        If e.SummaryProcess = DevExpress.Data.CustomSummaryProcess.Calculate Then
            Dim cost As Decimal = CDec(myCoalesce(View.GetRowCellValue(e.RowHandle, "TOTAL COST NON ADDITIONAL_add_report_column").ToString, "0.00"))
            Dim prc As Decimal = CDec(myCoalesce(View.GetRowCellValue(e.RowHandle, "TOTAL AMOUNT NON ADDITIONAL_add_report_column"), "0.00"))
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
    End Sub

    Private Sub BtnRefresh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        viewDesignDemand()
    End Sub

    Private Sub BtnAddFromLineList_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnAddFromLineList.Click
        Cursor = Cursors.WaitCursor
        FormProdDemandLineList.id_season_par = SLESeason.EditValue
        FormProdDemandLineList.ShowDialog()
        Cursor = Cursors.Default
    End Sub

    Private Sub SLESeason_EditValueChanged(sender As Object, e As EventArgs) Handles SLESeason.EditValueChanged
        Try
            Dim view As DevExpress.XtraGrid.Views.Grid.GridView = SLESeason.Properties.View
            Dim rowhandle As Integer = view.FocusedRowHandle
            short_name_ss = view.GetRowCellValue(rowhandle, "season_printed_name").ToString
        Catch ex As Exception

        End Try
    End Sub

    Private Sub LECat_EditValueChanged(sender As Object, e As EventArgs) Handles LECat.EditValueChanged

    End Sub

    Private Sub GVDesign_PopupMenuShowing(sender As Object, e As DevExpress.XtraGrid.Views.Grid.PopupMenuShowingEventArgs) Handles GVDesign.PopupMenuShowing
        If e.MenuType = DevExpress.XtraGrid.Views.Grid.GridMenuType.Column And id_role_login = id_role_super_admin Then
            Dim menu As DevExpress.XtraGrid.Menu.GridViewColumnMenu = e.Menu

            If Not menu.Column Is Nothing Then
                menu.Items.Add(CreateCheckItem("Options View", menu.Column))
            End If
        End If

        Dim view As DevExpress.XtraGrid.Views.Grid.GridView = CType(sender, DevExpress.XtraGrid.Views.Grid.GridView)
        Dim hitInfo As DevExpress.XtraGrid.Views.Grid.ViewInfo.GridHitInfo = view.CalcHitInfo(e.Point)
        If hitInfo.InRow And hitInfo.RowHandle >= 0 Then
            view.FocusedRowHandle = hitInfo.RowHandle
            vmenu.Show(view.GridControl, e.Point)
        End If
    End Sub

    ' Creates a menu item.
    Function CreateCheckItem(ByVal caption As String, ByVal column As DevExpress.XtraGrid.Columns.GridColumn) As DevExpress.Utils.Menu.DXMenuItem
        Dim item As DevExpress.Utils.Menu.DXMenuItem = New DevExpress.Utils.Menu.DXMenuItem(caption, New EventHandler(AddressOf OnCanMovedItemClick))
        item.Tag = New MenuColumnInfo(column)
        Return item
    End Function

    ' The class that stores menu specific information.
    Class MenuColumnInfo
        Public Sub New(ByVal column As DevExpress.XtraGrid.Columns.GridColumn)
            Me.Column = column
        End Sub
        Public Column As DevExpress.XtraGrid.Columns.GridColumn
    End Class

    ' Menu item click handler.
    Sub OnCanMovedItemClick(ByVal sender As Object, ByVal e As EventArgs)
        data_column.Clear()
        For i As Integer = 0 To GVDesign.Columns.Count - 1
            Dim R As DataRow = data_column.NewRow
            R("options_view_det_band") = GVDesign.Columns(i).OwnerBand.ToString
            R("options_view_det_caption") = GVDesign.Columns(i).Caption.ToString
            R("options_view_det_column") = GVDesign.Columns(i).FieldName.ToString
            R("options_view_det_visible") = GVDesign.Columns(i).Visible.ToString
            data_column.Rows.Add(R)
        Next
        FormOptView.frm_opt_name = "FormProdDemandSingle"
        FormOptView.gv_opt_name = "GVDesign"
        FormOptView.tag_opt_name = "1"
        FormOptView.dt = data_column
        FormOptView.ShowDialog()
    End Sub

    Private Sub SLEKind_EditValueChanged(sender As Object, e As EventArgs) Handles SLEKind.EditValueChanged
        If SLEKind.EditValue.ToString <> "1" Then
            LESampleDivision.EditValue = Nothing
            LESampleDivision.Enabled = False
        Else
            LESampleDivision.EditValue = 3823
            LESampleDivision.Enabled = True
        End If
    End Sub

    Private Sub CheckEditShowActive_CheckedChanged(sender As Object, e As EventArgs) Handles CheckEditShowNonActive.CheckedChanged
        Cursor = Cursors.WaitCursor
        If CheckEditShowNonActive.EditValue = True Then
            Dim prod_demand_report As ClassProdDemand = New ClassProdDemand()
            prod_demand_report.printReportLess(id_prod_demand, GVDesign, GCDesign)
        Else
            Dim prod_demand_report As ClassProdDemand = New ClassProdDemand()
            prod_demand_report.printReportLess(id_prod_demand + " AND is_void=2 ", GVDesign, GCDesign)
        End If
        Cursor = Cursors.Default
    End Sub

    Private Sub XTCPD_SelectedPageChanged(sender As Object, e As DevExpress.XtraTab.TabPageChangedEventArgs) Handles XTCPD.SelectedPageChanged
        If XTCPD.SelectedTabPageIndex = 1 Then
            viewRevision()
        End If
    End Sub

    Private Sub GVData_DoubleClick(sender As Object, e As EventArgs) Handles GVData.DoubleClick
        If GVData.RowCount > 0 And GVData.FocusedRowHandle >= 0 Then
            Cursor = Cursors.WaitCursor
            Dim rmt As String = ""
            If SLEKind.EditValue.ToString = "1" Then 'MD
                rmt = "143"
            ElseIf SLEKind.EditValue.ToString = "2" Then 'MKT
                rmt = "144"
            Else 'HRD
                rmt = "145"
            End If
            Dim m As New ClassShowPopUp()
            m.id_report = GVData.GetFocusedRowCellValue("id_prod_demand_rev").ToString
            m.report_mark_type = rmt
            m.show()
            Cursor = Cursors.Default
        End If
    End Sub

    Private Sub ViewBreakdownSizeToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ViewBreakdownSizeToolStripMenuItem.Click
        Cursor = Cursors.WaitCursor
        If GVDesign.RowCount > 0 And GVDesign.FocusedRowHandle >= 0 Then
            Dim id_prod_demand_design As String = GVDesign.GetFocusedRowCellValue("id_prod_demand_design").ToString
            FormProdDemandBreakSize.LabelTitle.Text = GVDesign.GetFocusedRowCellValue("DESCRIPTION_desc_report_column").ToString
            FormProdDemandBreakSize.LabelSubTitle.Text = GVDesign.GetFocusedRowCellValue("CODE_desc_report_column").ToString
            FormProdDemandBreakSize.id_pdd = id_prod_demand_design
            FormProdDemandBreakSize.ShowDialog()
        End If
        Cursor = Cursors.Default
    End Sub
End Class