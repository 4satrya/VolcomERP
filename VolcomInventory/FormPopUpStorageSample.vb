Public Class FormPopUpStorageSample 
    Public id_pop_up As String
    Public id_wh As String = "-1"
    Public allow_all_wh As Boolean = True
    Public allow_all_locator As Boolean = True
    Public allow_all_rack As Boolean = True
    Public allow_all_drawer As Boolean = True
    Dim id_sample As String
    Public action As String
    Dim id_sample_requisition_detx As String = ""
    Public id_wh_rack_edit, id_wh_locator_edit, id_wh_drawer_edit, pl_sample_del_det_qty, pl_sample_del_det_note, id_sample_edit As String
    Public id_pl_sample_del_det As String

    'Form
    Private Sub FormPopUpStorageSample_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If id_pop_up = "1" Then
            viewWHStock()
            viewSampleStorage()
            GVSample.ActiveFilterString = "[qty_all_sample] > 0 "
            GridColumnIsSelect.Visible = True
        ElseIf id_pop_up = "2" Then
            viewWHStock()
            If action = "ins" Then
                viewSampleStorage()
            ElseIf action = "upd" Then
                SLELocator.EditValue = id_wh_locator_edit
                SLERack.EditValue = id_wh_rack_edit
                SLEDrawer.EditValue = id_wh_drawer_edit
                viewSampleStorage()
                SPQtyPL.Text = pl_sample_del_det_qty.ToString
                MERemark.Text = pl_sample_del_det_note.ToString
            End If
        End If
    End Sub
    Private Sub FormPopUpStorageSample_FormClosed(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub
    'View Data
    Sub viewWHStock()
        Dim query As String = ""
        'get id category on opt
        query = "SELECT id_comp_cat_wh FROM tb_opt "
        Dim id_comp_cat_wh As String = execute_query(query, 0, True, "", "", "", "")

        'view data comp/warehouse
        query = ""
        If allow_all_wh Then
            query += "SELECT ('0') AS id_comp, ('-') AS comp_number, ('All WH') AS comp_name UNION ALL "
        End If
        query += "SELECT a.id_comp, a.comp_number, a.comp_name FROM tb_m_comp a WHERE a.id_comp_cat = '" + id_comp_cat_wh + "' "
        If id_wh <> "-1" Then
            query += "AND a.id_comp = '" + id_wh + "' "
        End If
        query += "ORDER BY comp_number ASC "
        viewSearchLookupQuery(SLEWH, query, "id_comp", "comp_name", "id_comp")
    End Sub
    Sub viewWHLocatorSLE()
        Dim id_comp As String = SLEWH.EditValue.ToString
        Dim query As String = ""
        If allow_all_locator Then
            query += "SELECT ('0') AS id_comp, ('0') AS id_wh_locator, ('-') AS wh_locator_code, ('All Loactor') AS wh_locator, ('-') AS wh_locator_description UNION ALL "
        End If
        query += "SELECT a.id_comp, a.id_wh_locator, a.wh_locator_code, a.wh_locator, a.wh_locator_description FROM tb_m_wh_locator a WHERE a.id_comp = '" + id_comp + "' "
        viewSearchLookupQuery(SLELocator, query, "id_wh_locator", "wh_locator", "id_wh_locator")
    End Sub
    Sub viewWHRack()
        Dim id_locator As String = SLELocator.EditValue.ToString
        Dim query As String = ""
        If allow_all_rack Then
            query += "SELECT ('0') AS id_locator, ('0') AS id_wh_rack, ('-') AS wh_rack_code, ('All Rack') AS wh_rack, ('-') AS wh_rack_description UNION ALL "
        End If
        query += "SELECT a.id_wh_locator, a.id_wh_rack, a.wh_rack_code, a.wh_rack, a.wh_rack_description FROM tb_m_wh_rack a WHERE a.id_wh_locator = '" + id_locator + "' "
        viewSearchLookupQuery(SLERack, query, "id_wh_rack", "wh_rack", "id_wh_rack")
    End Sub
    Sub viewWHDrawer()
        Dim id_rack As String = SLERack.EditValue.ToString
        Dim query As String = ""
        If allow_all_drawer Then
            query = "SELECT ('0') AS id_rack, ('0') AS id_wh_drawer, ('-') AS wh_drawer_code, ('All Drawer') AS wh_drawer, ('-') AS wh_drawer_description UNION ALL "
        End If
        query += "SELECT a.id_wh_rack, a.id_wh_drawer, a.wh_drawer_code, a.wh_drawer, a.wh_drawer_description FROM tb_m_wh_drawer a WHERE a.id_wh_rack = '" + id_rack + "'"
        viewSearchLookupQuery(SLEDrawer, query, "id_wh_drawer", "wh_drawer", "id_wh_drawer")
    End Sub
    Sub viewSampleStorage()
        Cursor = Cursors.WaitCursor
        Dim id_wh_drawer_view As String = ""
        Dim id_wh_rack_view As String = ""
        Dim id_wh_locator_view As String = ""
        Dim id_wh_view As String = ""
        Try
            id_wh_drawer_view = SLEDrawer.EditValue.ToString
            id_wh_rack_view = SLERack.EditValue.ToString
            id_wh_locator_view = SLELocator.EditValue.ToString
            id_wh_view = SLEWH.EditValue.ToString
        Catch ex As Exception
            id_wh_drawer_view = "-1"
            id_wh_rack_view = "-1"
            id_wh_locator_view = "-1"
            id_wh_view = "-1"
        End Try
       
        Try
            If id_pop_up = "1" Then
                Dim query As String = "CALL view_stock_sample('" + id_wh_view + "','" + id_wh_locator_view + "','" + id_wh_rack_view + "','" + id_wh_drawer_view + "', '9999-12-01','3')"

                Dim data As DataTable
                If action = "upd" Then
                    Dim dtd_temp As DataTable = execute_query(query, -1, True, "", "", "", "")
                    dtd_temp.DefaultView.RowFilter = "id_sample <> '" + id_sample_edit + "' AND division = '" + FormSampleReqSingle.LESampleDivision.Text + "'"
                    data = dtd_temp.DefaultView.ToTable
                Else
                    Dim dtd_temp As DataTable = execute_query(query, -1, True, "", "", "", "")
                    dtd_temp.DefaultView.RowFilter = "division = '" + FormSampleReqSingle.LESampleDivision.Text + "'"

                    data = dtd_temp.DefaultView.ToTable
                End If
                GCSample.DataSource = data
                If data.Rows.Count > 0 Then
                    BtnChoose.Enabled = True
                    BtnImg.Enabled = True
                    GridColumnWHX.Visible = False
                    GridColumnWHLOcatorx.Visible = False
                    GridColumnWhDrawerx.Visible = False
                    GridColumnWHRackx.Visible = False
                    GridColumn1.Visible = False
                Else
                    BtnChoose.Enabled = False
                    BtnImg.Enabled = False
                End If
                setRequired()
            ElseIf id_pop_up = "2" Then
                'UPDATED 14 NOVEMBER 2014
                Dim query As String = "CALL view_stock_sample('" + id_wh_view + "','" + id_wh_locator_view + "','" + id_wh_rack_view + "','" + id_wh_drawer_view + "', '9999-12-01','2')"
                Dim dtd_temp As DataTable = execute_query(query, -1, True, "", "", "", "")
                If action = "ins" Then
                    Dim st_filter As String = ""
                    For ct As Integer = 0 To FormSamplePLDelSingle.id_sample_list.Count - 1
                        st_filter += "id_sample='" + FormSamplePLDelSingle.id_sample_list(ct) + "' "
                        If ct < FormSamplePLDelSingle.id_sample_list.Count - 1 Then
                            st_filter += "OR "
                        End If
                    Next
                    dtd_temp.DefaultView.RowFilter = st_filter
                    Dim data As DataTable = dtd_temp.DefaultView.ToTable
                    GCSample.DataSource = data
                ElseIf action = "upd" Then
                    dtd_temp.DefaultView.RowFilter = "id_sample = '" + id_sample_edit + "' "
                    Dim data As DataTable = dtd_temp.DefaultView.ToTable
                    GCSample.DataSource = data
                End If
                If action = "ins" Then
                    GVSample.Columns("name").GroupIndex = 0
                End If

                'Filter
                GVSample.ActiveFilterString = "[qty_all_sample]>0"


                'enabled/disabled button
                If GVSample.RowCount > 0 Then
                    BtnChoose.Enabled = True
                    BtnImg.Enabled = True
                Else
                    BtnChoose.Enabled = False
                    BtnImg.Enabled = False
                End If


                setRequired()
                checkRequisition()
            End If
        Catch ex As Exception
            errorConnection()
            Close()
        End Try
        Cursor = Cursors.Default
    End Sub
    Sub viewImg()
        BtnImg.Visible = True
        pre_viewImages("1", PictureEdit1, id_sample, False)
        If id_sample <> "" Then
            BtnChoose.Enabled = True
        Else
            BtnChoose.Enabled = False
        End If
    End Sub
    'SLE
    Private Sub SLEWH_EditValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SLEWH.EditValueChanged
        Try
            viewWHLocatorSLE()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub SLELocator_EditValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SLELocator.EditValueChanged
        Try
            viewWHRack()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub SLERack_EditValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SLERack.EditValueChanged
        Try
            viewWHDrawer()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub SLEDrawer_EditValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SLEDrawer.EditValueChanged
        Try
            If SLEDrawer.EditValue Is Nothing Then
                BtnViewStock.Enabled = False
            Else
                BtnViewStock.Enabled = True
            End If
        Catch ex As Exception

        End Try
    End Sub
    'Button
    Private Sub BtnViewStock_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnViewStock.Click
        Try
            viewSampleStorage()
        Catch ex As Exception

        End Try
    End Sub
    Private Sub BtnChoose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnChoose.Click
        If id_pop_up = "1" Then
            'check available
            Dim available = True
            Dim qty_all_sample As Decimal = Decimal.Parse(GVSample.GetFocusedRowCellValue("qty_all_sample").ToString)
            If qty_all_sample = 0.0 Then
                'aktifkan jika dipakai
                'available = False 
            Else
                available = True
            End If

            'check duplicate
            Dim already As Boolean = False
            For i As Integer = 0 To FormSampleReqSingle.GVRetDetail.RowCount - 1
                Dim id_sample_cek As String = ""
                Dim id_wh_drawer_cek As String = ""
                Try
                    id_sample_cek = FormSampleReqSingle.GVRetDetail.GetRowCellValue(i, "id_sample").ToString
                    id_wh_drawer_cek = FormSampleReqSingle.GVRetDetail.GetRowCellValue(i, "id_wh_drawer").ToString
                Catch ex As Exception
                End Try
                If id_sample_cek = GVSample.GetFocusedRowCellDisplayText("id_sample").ToString Then
                    already = True
                    Exit For
                End If
            Next

            If available Then
                If action = "ins" Then
                    If Not already Then
                        FormSampleReqSingle.newRows()
                        FormSampleReqSingle.GVRetDetail.SetFocusedRowCellValue("id_sample_requisition_det", "0")
                        FormSampleReqSingle.GVRetDetail.SetFocusedRowCellValue("id_sample", GVSample.GetFocusedRowCellDisplayText("id_sample").ToString)
                        FormSampleReqSingle.GVRetDetail.SetFocusedRowCellValue("name", GVSample.GetFocusedRowCellDisplayText("name").ToString)
                        FormSampleReqSingle.GVRetDetail.SetFocusedRowCellValue("size", GVSample.GetFocusedRowCellValue("size").ToString)
                        FormSampleReqSingle.GVRetDetail.SetFocusedRowCellValue("uom", GVSample.GetFocusedRowCellValue("uom").ToString)
                        FormSampleReqSingle.GVRetDetail.SetFocusedRowCellValue("qty_all_sample", GVSample.GetFocusedRowCellValue("qty_all_sample").ToString)
                        FormSampleReqSingle.GVRetDetail.SetFocusedRowCellValue("code", GVSample.GetFocusedRowCellValue("code").ToString)
                        FormSampleReqSingle.GVRetDetail.SetFocusedRowCellValue("sample_requisition_det_qty", "0")
                        FormSampleReqSingle.GVRetDetail.SetFocusedRowCellValue("id_comp", GVSample.GetFocusedRowCellValue("id_comp").ToString)
                        FormSampleReqSingle.GVRetDetail.SetFocusedRowCellValue("id_wh_locator", GVSample.GetFocusedRowCellValue("id_wh_locator").ToString)
                        FormSampleReqSingle.GVRetDetail.SetFocusedRowCellValue("id_wh_rack", GVSample.GetFocusedRowCellValue("id_wh_rack").ToString)
                        FormSampleReqSingle.GVRetDetail.SetFocusedRowCellValue("id_wh_drawer", GVSample.GetFocusedRowCellValue("id_wh_drawer").ToString)
                        FormSampleReqSingle.GVRetDetail.SetFocusedRowCellValue("comp_name", GVSample.GetFocusedRowCellValue("comp_name").ToString)
                        FormSampleReqSingle.GVRetDetail.SetFocusedRowCellValue("wh_locator", GVSample.GetFocusedRowCellValue("wh_locator").ToString)
                        FormSampleReqSingle.GVRetDetail.SetFocusedRowCellValue("wh_rack", GVSample.GetFocusedRowCellValue("wh_rack").ToString)
                        FormSampleReqSingle.GVRetDetail.SetFocusedRowCellValue("wh_drawer", GVSample.GetFocusedRowCellValue("wh_drawer").ToString)
                        FormSampleReqSingle.GVRetDetail.CloseEditor()
                        FormSampleReqSingle.GCRetDetail.RefreshDataSource()
                        FormSampleReqSingle.GVRetDetail.RefreshData()
                        FormSampleReqSingle.GVRetDetail.OptionsBehavior.AutoExpandAllGroups = True
                        'FormSampleReqSingle.GVRetDetail.Columns("name").GroupIndex = 0
                        'GVSample.OptionsBehavior.AutoExpandAllGroups = True
                        FormSampleReqSingle.id_sample_list.Add(GVSample.GetFocusedRowCellDisplayText("id_sample").ToString)
                        'FormSampleReqSingle.id_wh_drawer_list.Add(GVSample.GetFocusedRowCellDisplayText("id_wh_drawer").ToString)
                        FormSampleReqSingle.isManipulation()
                        Close()
                    Else
                        stopCustom("This sample already on list.")
                    End If
                ElseIf action = "upd" Then
                    If Not already Then
                        Dim id_sample_list_det_old As String = FormSampleReqSingle.GVRetDetail.GetFocusedRowCellDisplayText("id_sample").ToString
                        'Dim id_wh_drawer_list_det_old As String = FormSampleReqSingle.GVRetDetail.GetFocusedRowCellDisplayText("id_wh_drawer").ToString
                        FormSampleReqSingle.id_sample_list.Remove(id_sample_list_det_old)
                        'FormSampleReqSingle.id_wh_drawer_list.Remove(id_wh_drawer_list_det_old)
                        FormSampleReqSingle.GVRetDetail.SetFocusedRowCellValue("id_sample_requisition_det", "0")
                        FormSampleReqSingle.GVRetDetail.SetFocusedRowCellValue("id_sample", GVSample.GetFocusedRowCellDisplayText("id_sample").ToString)
                        FormSampleReqSingle.GVRetDetail.SetFocusedRowCellValue("name", GVSample.GetFocusedRowCellDisplayText("name").ToString)
                        FormSampleReqSingle.GVRetDetail.SetFocusedRowCellValue("size", GVSample.GetFocusedRowCellValue("size").ToString)
                        FormSampleReqSingle.GVRetDetail.SetFocusedRowCellValue("uom", GVSample.GetFocusedRowCellValue("uom").ToString)
                        FormSampleReqSingle.GVRetDetail.SetFocusedRowCellValue("qty_all_sample", GVSample.GetFocusedRowCellValue("qty_all_sample").ToString)
                        FormSampleReqSingle.GVRetDetail.SetFocusedRowCellValue("code", GVSample.GetFocusedRowCellValue("code").ToString)
                        ' FormSampleReqSingle.GVRetDetail.SetFocusedRowCellValue("sample_requisition_det_qty", "0")
                        FormSampleReqSingle.GVRetDetail.SetFocusedRowCellValue("id_comp", GVSample.GetFocusedRowCellValue("id_comp").ToString)
                        FormSampleReqSingle.GVRetDetail.SetFocusedRowCellValue("id_wh_locator", GVSample.GetFocusedRowCellValue("id_wh_locator").ToString)
                        FormSampleReqSingle.GVRetDetail.SetFocusedRowCellValue("id_wh_rack", GVSample.GetFocusedRowCellValue("id_wh_rack").ToString)
                        FormSampleReqSingle.GVRetDetail.SetFocusedRowCellValue("id_wh_drawer", GVSample.GetFocusedRowCellValue("id_wh_drawer").ToString)
                        FormSampleReqSingle.GVRetDetail.SetFocusedRowCellValue("comp_name", GVSample.GetFocusedRowCellValue("comp_name").ToString)
                        FormSampleReqSingle.GVRetDetail.SetFocusedRowCellValue("wh_locator", GVSample.GetFocusedRowCellValue("wh_locator").ToString)
                        FormSampleReqSingle.GVRetDetail.SetFocusedRowCellValue("wh_rack", GVSample.GetFocusedRowCellValue("wh_rack").ToString)
                        FormSampleReqSingle.GVRetDetail.SetFocusedRowCellValue("wh_drawer", GVSample.GetFocusedRowCellValue("wh_drawer").ToString)
                        FormSampleReqSingle.GVRetDetail.CloseEditor()
                        FormSampleReqSingle.GCRetDetail.RefreshDataSource()
                        FormSampleReqSingle.GVRetDetail.RefreshData()
                        FormSampleReqSingle.id_sample_list.Add(GVSample.GetFocusedRowCellDisplayText("id_sample").ToString)
                        ' FormSampleReqSingle.id_wh_drawer_list.Add(GVSample.GetFocusedRowCellDisplayText("id_wh_drawer").ToString)
                        FormSampleReqSingle.isManipulation()
                        Close()
                    Else
                        stopCustom("This sample already on list.")
                    End If
                End If
            Else
                stopCustom("Sorry, this sample not available for this time.")
            End If
        ElseIf id_pop_up = "2" Then
            Dim qty_input_grid As Decimal = Decimal.Parse(SPQtyPL.EditValue.ToString)
            Dim qty_limit As Decimal = Decimal.Parse(TxtQtyLimit.EditValue.ToString)
            If qty_input_grid.ToString <> 0.0 And qty_input_grid <= qty_limit Then '-------NEW----------
                If action = "ins" Then
                    'check exixt
                    Dim exist_list As Boolean = False
                    For i As Integer = 0 To FormSamplePLDelSingle.GVDetail.RowCount - 1
                        Dim id_sample_cek As String = ""
                        Try
                            id_sample_cek = FormSamplePLDelSingle.GVDetail.GetRowCellValue(i, "id_sample").ToString
                        Catch ex As Exception
                        End Try
                        If id_sample_cek = GVSample.GetFocusedRowCellDisplayText("id_sample").ToString Then
                            exist_list = True
                            Exit For
                        End If
                    Next

                    'check duplicate
                    Dim already As Boolean = False
                    For i As Integer = 0 To FormSamplePLDelSingle.GVDrawer.RowCount - 1
                        Dim id_sample_cek As String = ""
                        Dim id_wh_drawer_cek As String = ""
                        Try
                            id_sample_cek = FormSamplePLDelSingle.GVDrawer.GetRowCellValue(i, "id_sample").ToString
                            id_wh_drawer_cek = FormSamplePLDelSingle.GVDrawer.GetRowCellValue(i, "id_wh_drawer").ToString
                        Catch ex As Exception
                        End Try
                        If id_sample_cek = GVSample.GetFocusedRowCellDisplayText("id_sample").ToString And id_wh_drawer_cek = GVSample.GetFocusedRowCellDisplayText("id_wh_drawer").ToString Then
                            'MsgBox("sama")
                            already = True
                            Exit For
                        End If
                    Next

                    'SAVE DB
                    If exist_list Then
                        If Not already Then
                            'Edit di Induk insert save langsung ke db
                            If id_pl_sample_del_det <> "0" Then
                                'MsgBox(id_pl_sample_del_det)
                                FormSamplePLDelSingle.GVDetail.FocusedRowHandle = find_row(FormSamplePLDelSingle.GVDetail, "id_sample_requisition_det", id_sample_requisition_detx)
                                Dim qty_curr As Decimal = Decimal.Parse(FormSamplePLDelSingle.GVDetail.GetFocusedRowCellDisplayText("qty_real_sample").ToString)
                                Dim qty_pl As Decimal = Decimal.Parse(SPQtyPL.Text.ToString)
                                qty_pl = qty_pl + qty_curr
                                FormSamplePLDelSingle.isAllowRequisition(GVSample.GetFocusedRowCellDisplayText("name").ToString, id_sample_requisition_detx, qty_pl.ToString)
                                If FormSamplePLDelSingle.cond_check Then
                                    Dim query_ins_pl_det As String = "INSERT tb_pl_sample_del_det(id_pl_sample_del,pl_sample_del_det_note, id_sample_requisition_det, pl_sample_del_det_qty, id_wh_drawer) "
                                    query_ins_pl_det += "VALUES('" + FormSamplePLDelSingle.id_pl_sample_del + "','" + MERemark.Text + "', '" + id_sample_requisition_detx + "', '" + SPQtyPL.Text + "', '" + GVSample.GetFocusedRowCellValue("id_wh_drawer").ToString + "') "
                                    execute_non_query(query_ins_pl_det, True, "", "", "", "")
                                    Dim id_pl_sample_del_det_new As String = execute_query("SELECT LAST_INSERT_ID()", 0, True, "", "", "", "")
                                    FormSamplePLDelSingle.GVDrawer.SetFocusedRowCellValue("id_pl_sample_del_det", id_pl_sample_del_det_new)

                                    Dim query_upd_storage As String = "INSERT tb_storage_sample(id_wh_drawer, id_storage_category, id_sample, qty_sample, datetime_storage_sample, storage_sample_notes) "
                                    query_upd_storage += "VALUES('" + GVSample.GetFocusedRowCellValue("id_wh_drawer").ToString + "', '2', '" + GVSample.GetFocusedRowCellDisplayText("id_sample").ToString + "', '" + SPQtyPL.Text + "', NOW(), 'Data Edited , PL : " + FormSamplePLDelSingle.TxtPLNumber.Text + "')"
                                    execute_non_query(query_upd_storage, True, "", "", "", "")

                                    FormSamplePLDelSingle.newRows()
                                    FormSamplePLDelSingle.GVDrawer.SetFocusedRowCellValue("id_pl_sample_del_det", id_pl_sample_del_det_new)
                                    FormSamplePLDelSingle.GVDrawer.SetFocusedRowCellValue("id_sample", GVSample.GetFocusedRowCellDisplayText("id_sample").ToString)
                                    FormSamplePLDelSingle.GVDrawer.SetFocusedRowCellValue("name", GVSample.GetFocusedRowCellDisplayText("name").ToString)
                                    FormSamplePLDelSingle.GVDrawer.SetFocusedRowCellValue("code", GVSample.GetFocusedRowCellValue("code").ToString)
                                    FormSamplePLDelSingle.GVDrawer.SetFocusedRowCellValue("pl_sample_del_det_qty", qty_input_grid.ToString("N2"))
                                    FormSamplePLDelSingle.GVDrawer.SetFocusedRowCellValue("pl_sample_del_det_note", MERemark.Text)
                                    FormSamplePLDelSingle.GVDrawer.SetFocusedRowCellValue("wh_locator", GVSample.GetFocusedRowCellValue("wh_locator").ToString)
                                    FormSamplePLDelSingle.GVDrawer.SetFocusedRowCellValue("wh_rack", GVSample.GetFocusedRowCellValue("wh_rack").ToString)
                                    FormSamplePLDelSingle.GVDrawer.SetFocusedRowCellValue("wh_drawer", GVSample.GetFocusedRowCellValue("wh_drawer").ToString)
                                    FormSamplePLDelSingle.GVDrawer.SetFocusedRowCellValue("id_wh_drawer", GVSample.GetFocusedRowCellValue("id_wh_drawer").ToString)
                                    FormSamplePLDelSingle.GVDrawer.SetFocusedRowCellValue("id_wh_locator", GVSample.GetFocusedRowCellValue("id_wh_locator").ToString)
                                    FormSamplePLDelSingle.GVDrawer.SetFocusedRowCellValue("id_wh_rack", GVSample.GetFocusedRowCellValue("id_wh_rack").ToString)
                                    FormSamplePLDelSingle.GVDrawer.SetFocusedRowCellValue("qty_all_sample", GVSample.GetFocusedRowCellValue("qty_all_sample").ToString)
                                    FormSamplePLDelSingle.GVDrawer.SetFocusedRowCellValue("id_sample_requisition_det", id_sample_requisition_detx)
                                    FormSamplePLDelSingle.GVDrawer.SetFocusedRowCellValue("uom", GVSample.GetFocusedRowCellValue("uom").ToString)
                                    FormSamplePLDelSingle.GVDrawer.SetFocusedRowCellValue("id_sample_price", GVSample.GetFocusedRowCellValue("id_sample_price").ToString)
                                    FormSamplePLDelSingle.GVDrawer.SetFocusedRowCellValue("sample_price", GVSample.GetFocusedRowCellValue("sample_price").ToString)


                                    'Save in Gridview
                                    FormSamplePLDelSingle.GVDrawer.CloseEditor()
                                    'FormSamplePLDelSingle.code_list.Add(GVSample.GetFocusedRowCellDisplayText("id_sample").ToString)
                                    'FormSamplePLDelSingle.code_list_drawer.Add(GVSample.GetFocusedRowCellValue("id_wh_drawer").ToString)
                                    AddHandler FormSamplePLDelSingle.GVDrawer.RowCellStyle, AddressOf FormSamplePLDelSingle.test_aw
                                    FormSamplePLDelSingle.GCDrawer.RefreshDataSource()
                                    FormSamplePLDelSingle.GVDrawer.RefreshData()
                                    FormSamplePLDelSingle.getAmountReq(id_sample_requisition_detx, False)
                                    Close()
                                Else
                                    errorCustom("Sample : '" + FormSamplePLDelSingle.sample_check + "' cannot exceed " + FormSamplePLDelSingle.allow_sum.ToString("N2") + ", please check in Info SRS ! ")
                                    FormSamplePLDelSingle.infoSrs()
                                End If
                            Else
                                FormSamplePLDelSingle.newRows()
                                FormSamplePLDelSingle.GVDrawer.SetFocusedRowCellValue("id_pl_sample_del_det", "0")
                                FormSamplePLDelSingle.GVDrawer.SetFocusedRowCellValue("id_sample", GVSample.GetFocusedRowCellDisplayText("id_sample").ToString)
                                FormSamplePLDelSingle.GVDrawer.SetFocusedRowCellValue("name", GVSample.GetFocusedRowCellDisplayText("name").ToString)
                                FormSamplePLDelSingle.GVDrawer.SetFocusedRowCellValue("code", GVSample.GetFocusedRowCellValue("code").ToString)
                                FormSamplePLDelSingle.GVDrawer.SetFocusedRowCellValue("pl_sample_del_det_qty", qty_input_grid.ToString("N2"))
                                FormSamplePLDelSingle.GVDrawer.SetFocusedRowCellValue("pl_sample_del_det_note", MERemark.Text)
                                FormSamplePLDelSingle.GVDrawer.SetFocusedRowCellValue("wh_locator", GVSample.GetFocusedRowCellValue("wh_locator").ToString)
                                FormSamplePLDelSingle.GVDrawer.SetFocusedRowCellValue("wh_rack", GVSample.GetFocusedRowCellValue("wh_rack").ToString)
                                FormSamplePLDelSingle.GVDrawer.SetFocusedRowCellValue("wh_drawer", GVSample.GetFocusedRowCellValue("wh_drawer").ToString)
                                FormSamplePLDelSingle.GVDrawer.SetFocusedRowCellValue("id_wh_drawer", GVSample.GetFocusedRowCellValue("id_wh_drawer").ToString)
                                FormSamplePLDelSingle.GVDrawer.SetFocusedRowCellValue("id_wh_locator", GVSample.GetFocusedRowCellValue("id_wh_locator").ToString)
                                FormSamplePLDelSingle.GVDrawer.SetFocusedRowCellValue("id_wh_rack", GVSample.GetFocusedRowCellValue("id_wh_rack").ToString)
                                FormSamplePLDelSingle.GVDrawer.SetFocusedRowCellValue("qty_all_sample", GVSample.GetFocusedRowCellValue("qty_all_sample").ToString)
                                FormSamplePLDelSingle.GVDrawer.SetFocusedRowCellValue("id_sample_requisition_det", id_sample_requisition_detx)
                                FormSamplePLDelSingle.GVDrawer.SetFocusedRowCellValue("uom", GVSample.GetFocusedRowCellValue("uom").ToString)
                                FormSamplePLDelSingle.GVDrawer.SetFocusedRowCellValue("id_sample_price", GVSample.GetFocusedRowCellValue("id_sample_price").ToString)
                                FormSamplePLDelSingle.GVDrawer.SetFocusedRowCellValue("sample_price", GVSample.GetFocusedRowCellValue("sample_price").ToString)

                                'Save in Gridview
                                FormSamplePLDelSingle.GVDrawer.CloseEditor()
                                'FormSamplePLDelSingle.code_list.Add(GVSample.GetFocusedRowCellDisplayText("id_sample").ToString)
                                'FormSamplePLDelSingle.code_list_drawer.Add(GVSample.GetFocusedRowCellValue("id_wh_drawer").ToString)
                                AddHandler FormSamplePLDelSingle.GVDrawer.RowCellStyle, AddressOf FormSamplePLDelSingle.test_aw
                                FormSamplePLDelSingle.GCDrawer.RefreshDataSource()
                                FormSamplePLDelSingle.GVDrawer.RefreshData()
                                FormSamplePLDelSingle.getAmountReq(id_sample_requisition_detx, False)
                                Close()
                            End If
                        Else
                            stopCustom("This sample already on list.")
                        End If
                    Else
                        stopCustom("Sorry, this sample not found in this requisition list !")
                    End If
                ElseIf action = "upd" Then ' -------EDIT------------
                    'Edit di Induk update save langsung ke db
                    If id_pl_sample_del_det <> "0" Then
                        FormSamplePLDelSingle.GVDetail.FocusedRowHandle = find_row(FormSamplePLDelSingle.GVDetail, "id_sample_requisition_det", id_sample_requisition_detx)
                        Dim qty_curr As Decimal = Decimal.Parse(FormSamplePLDelSingle.GVDetail.GetFocusedRowCellDisplayText("qty_real_sample").ToString) - Decimal.Parse(pl_sample_del_det_qty.ToString)
                        Dim qty_pl As Decimal = Decimal.Parse(SPQtyPL.Text)
                        qty_pl = qty_pl + qty_curr
                        FormSamplePLDelSingle.isAllowRequisition(GVSample.GetFocusedRowCellDisplayText("name").ToString, id_sample_requisition_detx, qty_pl.ToString)
                        If FormSamplePLDelSingle.cond_check Then
                            'Dim query_upd_pl_det As String = "UPDATE tb_pl_sample_del_det SET id_pl_sample_del = '" + FormSamplePLDelSingle.id_pl_sample_del + "',pl_sample_del_det_note = '" + MERemark.Text + "', id_sample_requisition_det = '" + id_sample_requisition_detx + "', pl_sample_del_det_qty = '" + SPQtyPL.Text + "', id_wh_drawer = '" + GVSample.GetFocusedRowCellValue("id_wh_drawer").ToString + "' WHERE id_pl_sample_del_det = '" + id_pl_sample_del_det + "' "
                            'execute_non_query(query_upd_pl_det, True, "", "", "", "")
                            'FormSamplePLDelSingle.GVDrawer.SetFocusedRowCellValue("id_pl_sample_del_det", id_pl_sample_del_det)

                            'Dim query_upd_storage1 As String = "INSERT tb_storage_sample(id_wh_drawer, id_storage_category, id_sample, qty_sample, datetime_storage_sample, storage_sample_notes) "
                            'query_upd_storage1 += "VALUES('" + GVSample.GetFocusedRowCellValue("id_wh_drawer").ToString + "', '1', '" + GVSample.GetFocusedRowCellDisplayText("id_sample").ToString + "', '" + pl_sample_del_det_qty + "', NOW(), 'Data Edited , PL : " + FormSamplePLDelSingle.TxtPLNumber.Text + "')"
                            'execute_non_query(query_upd_storage1, True, "", "", "", "")
                            'Dim query_upd_storage2 As String = "INSERT tb_storage_sample(id_wh_drawer, id_storage_category, id_sample, qty_sample, datetime_storage_sample, storage_sample_notes) "
                            'query_upd_storage2 += "VALUES('" + GVSample.GetFocusedRowCellValue("id_wh_drawer").ToString + "', '2', '" + GVSample.GetFocusedRowCellDisplayText("id_sample").ToString + "', '" + SPQtyPL.Text + "', NOW(), 'Data Edited , PL : " + FormSamplePLDelSingle.TxtPLNumber.Text + "')"
                            'execute_non_query(query_upd_storage2, True, "", "", "", "")

                            'Dim id_sample_list_old As String = FormSamplePLDelSingle.GVDrawer.GetFocusedRowCellDisplayText("id_sample").ToString
                            'FormSamplePLDelSingle.code_list.Remove(id_sample_list_old)
                            'Dim id_drawer_list_old As String = FormSamplePLDelSingle.GVDrawer.GetFocusedRowCellDisplayText("id_wh_drawer").ToString
                            'FormSamplePLDelSingle.code_list_drawer.Remove(id_drawer_list_old)
                            FormSamplePLDelSingle.GVDrawer.SetFocusedRowCellValue("id_pl_sample_del_det", id_pl_sample_del_det)
                            FormSamplePLDelSingle.GVDrawer.SetFocusedRowCellValue("id_sample", GVSample.GetFocusedRowCellDisplayText("id_sample").ToString)
                            FormSamplePLDelSingle.GVDrawer.SetFocusedRowCellValue("name", GVSample.GetFocusedRowCellDisplayText("name").ToString)
                            FormSamplePLDelSingle.GVDrawer.SetFocusedRowCellValue("code", GVSample.GetFocusedRowCellValue("code").ToString)
                            FormSamplePLDelSingle.GVDrawer.SetFocusedRowCellValue("pl_sample_del_det_qty", qty_input_grid.ToString("N2"))
                            FormSamplePLDelSingle.GVDrawer.SetFocusedRowCellValue("pl_sample_del_det_note", MERemark.Text)
                            FormSamplePLDelSingle.GVDrawer.SetFocusedRowCellValue("wh_locator", GVSample.GetFocusedRowCellValue("wh_locator").ToString)
                            FormSamplePLDelSingle.GVDrawer.SetFocusedRowCellValue("wh_rack", GVSample.GetFocusedRowCellValue("wh_rack").ToString)
                            FormSamplePLDelSingle.GVDrawer.SetFocusedRowCellValue("wh_drawer", GVSample.GetFocusedRowCellValue("wh_drawer").ToString)
                            FormSamplePLDelSingle.GVDrawer.SetFocusedRowCellValue("id_wh_drawer", GVSample.GetFocusedRowCellValue("id_wh_drawer").ToString)
                            FormSamplePLDelSingle.GVDrawer.SetFocusedRowCellValue("id_wh_locator", GVSample.GetFocusedRowCellValue("id_wh_locator").ToString)
                            FormSamplePLDelSingle.GVDrawer.SetFocusedRowCellValue("id_wh_rack", GVSample.GetFocusedRowCellValue("id_wh_rack").ToString)
                            FormSamplePLDelSingle.GVDrawer.SetFocusedRowCellValue("qty_all_sample", GVSample.GetFocusedRowCellValue("qty_all_sample").ToString)
                            FormSamplePLDelSingle.GVDrawer.SetFocusedRowCellValue("id_sample_requisition_det", id_sample_requisition_detx)
                            FormSamplePLDelSingle.GVDrawer.SetFocusedRowCellValue("uom", GVSample.GetFocusedRowCellValue("uom").ToString)
                            FormSamplePLDelSingle.GVDrawer.SetFocusedRowCellValue("id_sample_price", GVSample.GetFocusedRowCellValue("id_sample_price").ToString)
                            FormSamplePLDelSingle.GVDrawer.SetFocusedRowCellValue("sample_price", GVSample.GetFocusedRowCellValue("sample_price").ToString)

                            'Save in Gridview
                            FormSamplePLDelSingle.GVDrawer.CloseEditor()
                            'FormSamplePLDelSingle.code_list.Add(GVSample.GetFocusedRowCellDisplayText("id_sample").ToString)
                            'FormSamplePLDelSingle.code_list_drawer.Add(GVSample.GetFocusedRowCellValue("id_wh_drawer").ToString)
                            AddHandler FormSamplePLDelSingle.GVDrawer.RowCellStyle, AddressOf FormSamplePLDelSingle.test_aw
                            FormSamplePLDelSingle.GCDrawer.RefreshDataSource()
                            FormSamplePLDelSingle.GVDrawer.RefreshData()
                            FormSamplePLDelSingle.getAmountReq(id_sample_requisition_detx, False)
                            Close()
                        Else
                            errorCustom("Sample : '" + FormSamplePLDelSingle.sample_check + "' cannot exceed " + FormSamplePLDelSingle.allow_sum.ToString("N2") + ", please check in Info SRS ! ")
                            FormSamplePLDelSingle.infoSrs()
                        End If
                    Else
                        'Dim id_sample_list_old As String = FormSamplePLDelSingle.GVDrawer.GetFocusedRowCellDisplayText("id_sample").ToString
                        'FormSamplePLDelSingle.code_list.Remove(id_sample_list_old)
                        'Dim id_drawer_list_old As String = FormSamplePLDelSingle.GVDrawer.GetFocusedRowCellDisplayText("id_wh_drawer").ToString
                        'FormSamplePLDelSingle.code_list_drawer.Remove(id_drawer_list_old)
                        FormSamplePLDelSingle.GVDrawer.SetFocusedRowCellValue("id_pl_sample_del_det", "0")
                        FormSamplePLDelSingle.GVDrawer.SetFocusedRowCellValue("id_sample", GVSample.GetFocusedRowCellDisplayText("id_sample").ToString)
                        FormSamplePLDelSingle.GVDrawer.SetFocusedRowCellValue("name", GVSample.GetFocusedRowCellDisplayText("name").ToString)
                        FormSamplePLDelSingle.GVDrawer.SetFocusedRowCellValue("code", GVSample.GetFocusedRowCellValue("code").ToString)
                        FormSamplePLDelSingle.GVDrawer.SetFocusedRowCellValue("pl_sample_del_det_qty", qty_input_grid.ToString("N2"))
                        FormSamplePLDelSingle.GVDrawer.SetFocusedRowCellValue("pl_sample_del_det_note", MERemark.Text)
                        FormSamplePLDelSingle.GVDrawer.SetFocusedRowCellValue("wh_locator", GVSample.GetFocusedRowCellValue("wh_locator").ToString)
                        FormSamplePLDelSingle.GVDrawer.SetFocusedRowCellValue("wh_rack", GVSample.GetFocusedRowCellValue("wh_rack").ToString)
                        FormSamplePLDelSingle.GVDrawer.SetFocusedRowCellValue("wh_drawer", GVSample.GetFocusedRowCellValue("wh_drawer").ToString)
                        FormSamplePLDelSingle.GVDrawer.SetFocusedRowCellValue("id_wh_drawer", GVSample.GetFocusedRowCellValue("id_wh_drawer").ToString)
                        FormSamplePLDelSingle.GVDrawer.SetFocusedRowCellValue("id_wh_locator", GVSample.GetFocusedRowCellValue("id_wh_locator").ToString)
                        FormSamplePLDelSingle.GVDrawer.SetFocusedRowCellValue("id_wh_rack", GVSample.GetFocusedRowCellValue("id_wh_rack").ToString)
                        FormSamplePLDelSingle.GVDrawer.SetFocusedRowCellValue("qty_all_sample", GVSample.GetFocusedRowCellValue("qty_all_sample").ToString)
                        FormSamplePLDelSingle.GVDrawer.SetFocusedRowCellValue("id_sample_requisition_det", id_sample_requisition_detx)
                        FormSamplePLDelSingle.GVDrawer.SetFocusedRowCellValue("uom", GVSample.GetFocusedRowCellValue("uom").ToString)
                        FormSamplePLDelSingle.GVDrawer.SetFocusedRowCellValue("id_sample_price", GVSample.GetFocusedRowCellValue("id_sample_price").ToString)
                        FormSamplePLDelSingle.GVDrawer.SetFocusedRowCellValue("sample_price", GVSample.GetFocusedRowCellValue("sample_price").ToString)

                        'Save in Gridview
                        FormSamplePLDelSingle.GVDrawer.CloseEditor()
                        'FormSamplePLDelSingle.code_list.Add(GVSample.GetFocusedRowCellDisplayText("id_sample").ToString)
                        'FormSamplePLDelSingle.code_list_drawer.Add(GVSample.GetFocusedRowCellValue("id_wh_drawer").ToString)
                        AddHandler FormSamplePLDelSingle.GVDrawer.RowCellStyle, AddressOf FormSamplePLDelSingle.test_aw
                        FormSamplePLDelSingle.GCDrawer.RefreshDataSource()
                        FormSamplePLDelSingle.GVDrawer.RefreshData()
                        FormSamplePLDelSingle.getAmountReq(id_sample_requisition_detx, False)
                        Close()
                    End If
                End If
            Else
                stopCustom("Input not valid. Make sure : " + System.Environment.NewLine + "- Qty PL not allowed zero value." + System.Environment.NewLine + "- Qty PL must be smaller than qty limit. ")
            End If
        End If
    End Sub
    Private Sub BtnImg_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnImg.Click
        Try
            pre_viewImages("1", PictureEdit1, id_sample, True)
        Catch ex As Exception
        End Try
    End Sub
    Private Sub BtnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCancel.Click
        Close()
    End Sub
    'GridView
    Private Sub GVSample_RowClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Grid.RowClickEventArgs) Handles GVSample.RowClick
        Try
            setRequired()
            If id_pop_up = "2" Then
                checkRequisition()
            End If
        Catch ex As Exception

        End Try
    End Sub
    'Set required
    Sub setRequired()
        id_sample = "-1"
        Try
            id_sample = GVSample.GetFocusedRowCellDisplayText("id_sample").ToString
        Catch ex As Exception
        End Try
        viewImg()

        'Set Qty Limit in textbox
        TxtQtyLimit.Text = GVSample.GetFocusedRowCellDisplayText("qty_all_sample").ToString
        SPQtyPL.Text = "0"
        MERemark.Text = ""
    End Sub

    Sub checkRequisition()
        ''check in sample req list
        Dim id_sample_check As String = GVSample.GetFocusedRowCellDisplayText("id_sample").ToString
        Dim found_sample As Boolean = False
        For i As Integer = 0 To (FormSamplePLDelSingle.GVDetail.RowCount - 1)
            Try
                Dim id_sample_ls As String = FormSamplePLDelSingle.GVDetail.GetRowCellValue(i, "id_sample").ToString
                Dim id_sample_requisition_det As String = FormSamplePLDelSingle.GVDetail.GetRowCellValue(i, "id_sample_requisition_det").ToString
                If id_sample_ls = id_sample_check Then
                    id_sample_requisition_detx = id_sample_requisition_det
                    found_sample = True
                    Exit For
                End If
            Catch ex As Exception

            End Try
        Next

        'If found_sample Then
        '    LabelAttention.Visible = False
        '    GroupControlInput.Enabled = True
        '    BtnChoose.Enabled = True
        '    'Return id_sample_requisition_detx
        'Else
        '    LabelAttention.Visible = True
        '    GroupControlInput.Enabled = False
        '    BtnChoose.Enabled = False
        '    'Return "0"
        'End If
    End Sub
    'Spin QTY
    Private Sub SPQtyPL_EditValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SPQtyPL.EditValueChanged
        'Try
        '    Dim SpQty As DevExpress.XtraEditors.SpinEdit = CType(sender, DevExpress.XtraEditors.SpinEdit)
        '    Dim qty_rec As Decimal = Decimal.Parse(SpQty.Text.ToString)
        '    Dim qty_limit As Decimal = Decimal.Parse(GVSample.GetFocusedRowCellDisplayText("qty_all_sample").ToString)
        '    Dim current_name As String = GVSample.GetFocusedRowCellDisplayText("name").ToString
        '    Dim current_uom As String = GVSample.GetFocusedRowCellDisplayText("uom").ToString
        '    If qty_rec > qty_limit Then
        '        DevExpress.XtraEditors.XtraMessageBox.Show("Product sample : '" + current_name + "', cannot exceed " + qty_limit.ToString + " " + current_uom + " ! ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        '        SpQty.Text = (qty_rec - 1).ToString
        '    End If
        'Catch ex As Exception

        'End Try
    End Sub

    Private Sub GVSample_FocusedRowChanged(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles GVSample.FocusedRowChanged
        Try
            setRequired()
            If id_pop_up = "2" Then
                checkRequisition()
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub GVSample_ColumnFilterChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GVSample.ColumnFilterChanged
        setRequired()
        If GVSample.RowCount > 0 Then
            BtnChoose.Enabled = True
            BtnImg.Enabled = True
        Else
            BtnChoose.Enabled = False
            BtnImg.Enabled = False
        End If
    End Sub

    Private Sub BtnLineList_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnLineList.Click
        Cursor = Cursors.WaitCursor
        FormInfoLineList.id_pop_up = "1"
        FormInfoLineList.ShowDialog()
        Cursor = Cursors.Default
    End Sub
End Class