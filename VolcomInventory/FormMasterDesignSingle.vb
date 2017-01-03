Public Class FormMasterDesignSingle
    Dim opt_id_code_color As String = "1"
    Public data_insert_parameter As New DataTable
    Public data_insert_parameter_dsg As New DataTable
    Public data_insert_parameter_non_md As New DataTable
    Public id_design As String = "-1"
    Public dupe As String = "-1"
    Public form_name As String = "-1"
    Public id_season_par As String = "-1"
    Public id_prod_demand_design_active As String = "-1"
    Dim del_date_ As Date = Nothing
    Dim ret_date_ As Date = Nothing
    Public counting_det As DataTable = Nothing
    Public id_range_par As String = "-1"
    Public bool_qty_line As Boolean = False
    Public id_pop_up As String = "-1"
    Public ss_dept As String = "-1"
    Dim is_approved As String = "-1"

    'View UOM
    Private Sub viewUOM(ByVal lookup As DevExpress.XtraEditors.LookUpEdit)
        Dim query As String = "SELECT id_uom,uom FROM tb_m_uom ORDER BY id_uom ASC"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")

        lookup.Properties.DataSource = Nothing
        lookup.Properties.DataSource = data

        lookup.Properties.DisplayMember = "uom"
        lookup.Properties.ValueMember = "id_uom"
        lookup.ItemIndex = 0
    End Sub

    'tampung counting
    Sub getCounting()
        Dim query As String = ""
        query += "SELECT b.id_code_detail, b.display_name FROM tb_m_code a "
        query += "INNER JOIN tb_m_code_detail b ON a.id_code = b.id_code "
        query += "JOIN tb_opt c "
        If id_pop_up = "3" Then ' non md
            query += "WHERE a.id_code = c.id_code_fg_non_md_counting "
        Else
            query += "WHERE a.id_code = c.id_code_fg_counting "
        End If
        counting_det = execute_query(query, -1, True, "", "", "", "")
    End Sub
    Sub view_ret_code(ByVal lookup As DevExpress.XtraEditors.LookUpEdit)
        Dim query As String = "SELECT * FROM tb_lookup_ret_code "
        'If id_pop_up <> "3" Then 'except non merch
        '    query += "WHERE id_ret_code>0 "
        'End If
        query += "ORDER BY id_ret_code ASC "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        Dim val_ As Date = Nothing
        Try
            val_ = data.Rows(0)("ret_date")
        Catch ex As Exception
        End Try
        ret_date_ = val_
        'DERetDate.EditValue = val_
        lifetime()

        lookup.Properties.DataSource = Nothing
        lookup.Properties.DataSource = data

        lookup.Properties.DisplayMember = "ret_code"
        lookup.Properties.ValueMember = "id_ret_code"
        lookup.ItemIndex = 0
    End Sub
    'View Design Type
    Private Sub viewDesignType(ByVal lookup As DevExpress.XtraEditors.LookUpEdit)
        Dim query As String = "SELECT id_design_type,design_type FROM tb_lookup_design_type ORDER BY id_design_type ASC"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")

        lookup.Properties.DataSource = Nothing
        lookup.Properties.DataSource = data

        lookup.Properties.DisplayMember = "design_type"
        lookup.Properties.ValueMember = "id_design_type"
        lookup.ItemIndex = 0
    End Sub

    'view season orign
    Sub viewSeasonOrign(ByVal lookup As DevExpress.XtraEditors.SearchLookUpEdit)
        Dim query As String = "SELECT * FROM tb_season_orign a ORDER BY a.id_season_orign DESC "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")

        lookup.Properties.DataSource = Nothing
        lookup.Properties.DataSource = data

        lookup.Properties.DisplayMember = "season_orign"
        lookup.Properties.ValueMember = "id_season_orign"
        lookup.EditValue = data.Rows(0)("id_season_orign").ToString
    End Sub

    'View Season
    Sub viewSeason(ByVal lookup As DevExpress.XtraEditors.SearchLookUpEdit)
        Dim query As String = "SELECT id_season,season FROM tb_season "
        query += "INNER JOIN tb_range ON tb_season.id_range = tb_range.id_range "
        If id_pop_up = "3" Then
            query += "WHERE tb_range.id_departement='" + id_departement_user + "' "
        Else
            query += "WHERE tb_range.is_md='1' "
        End If
        query += "ORDER BY id_season DESC "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")

        lookup.Properties.DataSource = Nothing
        lookup.Properties.DataSource = data

        lookup.Properties.DisplayMember = "season"
        lookup.Properties.ValueMember = "id_season"
        lookup.EditValue = data.Rows(0)("id_season").ToString
    End Sub

    Sub viewDelivery(ByVal id_season_par As String)
        Dim query As String = "SELECT * FROM tb_season_delivery WHERE id_season='" + id_season_par + "' ORDER BY id_delivery ASC"
        Dim data1 As DataTable = execute_query(query, -1, True, "", "", "", "")
        SLEDel.Properties.DataSource = Nothing
        SLEDel.Properties.DataSource = data1
        SLEDel.Properties.DisplayMember = "delivery"
        SLEDel.Properties.ValueMember = "id_delivery"
        SLEDel.EditValue = data1.Rows(0)("id_delivery").ToString
        Try
            TxtDelDate.EditValue = data1.Rows(0)("delivery_date")
        Catch ex As Exception
            TxtDelDate.EditValue = Nothing
        End Try
        Try
            del_date_ = data1.Rows(0)("delivery_date")
        Catch ex As Exception
            del_date_ = Nothing
        End Try
        Try
            DEWHDate.EditValue = data1.Rows(0)("est_wh_date")
        Catch ex As Exception
            DEWHDate.EditValue = Nothing
        End Try
        lifetime()
    End Sub
    'View Sample Orign
    Private Sub viewSampleOrign(ByVal lookup As DevExpress.XtraEditors.SearchLookUpEdit)
        Dim query As String = "SELECT a.id_sample,a.sample_display_name,a.sample_code,a.sample_name,a.sample_us_code,b.id_uom, c.id_season,c.season,d.season_orign, IFNULL(a.sample_fabrication,'') AS sample_fabrication FROM tb_m_sample a "
        query += "INNER JOIN tb_m_uom b ON a.id_uom = b.id_uom "
        query += "INNER JOIN tb_season c ON c.id_season = a.id_season "
        query += "INNER JOIN tb_season_orign d ON d.id_season_orign = a.id_season_orign ORDER BY a.sample_name ASC "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")

        lookup.Properties.DataSource = Nothing
        lookup.Properties.DataSource = data

        If data.Rows.Count > 0 Then
            lookup.Properties.DisplayMember = "sample_name"
            lookup.Properties.ValueMember = "id_sample"
            lookup.EditValue = data.Rows(0)("id_sample").ToString

            'from sample
            'If System.IO.File.Exists(sample_image_path & data.Rows(0)("id_sample").ToString & ".jpg") Then
            '    PictureEdit1.LoadAsync(sample_image_path & data.Rows(0)("id_sample").ToString & ".jpg")
            'Else
            '    PictureEdit1.LoadAsync(sample_image_path & "default" & ".jpg")
            'End If
            'BViewImage.Visible = True
        End If
    End Sub

    Sub viewPlanOrder()
        Dim query As String = "SELECT * FROM tb_lookup_status_order ORDER BY id_lookup_status_order ASC"
        viewLookupQuery(LEPlanStatus, query, 0, "lookup_status_order", "id_lookup_status_order")
    End Sub

    'View Template
    Private Sub viewTemplate(ByVal lookup As DevExpress.XtraEditors.SearchLookUpEdit, ByVal id_type_par As String)
        '1 = md
        '2 = non md
        '3 = for design dept

        Dim query As String = "SELECT id_template_code,template_code FROM tb_template_code ORDER BY template_code ASC"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")

        lookup.Properties.DataSource = Nothing
        lookup.Properties.DataSource = data

        lookup.Properties.DisplayMember = "template_code"
        lookup.Properties.ValueMember = "id_template_code"
        Try
            If id_type_par = "1" Then
                lookup.EditValue = get_setup_field("id_code_template_design")
            ElseIf id_type_par = "2" Then
                lookup.EditValue = get_setup_field("id_code_template_design_non_md")
            ElseIf id_type_par = "3" Then
                lookup.EditValue = get_setup_field("id_code_template_design_dsg")
            End If
        Catch ex As Exception
            lookup.EditValue = data.Rows(0)("id_template_code").ToString
        End Try

    End Sub
    Sub load_isi_param(ByVal id_type As String)
        Cursor = Cursors.WaitCursor

        If id_type = "1" Then
            data_insert_parameter.Clear()
            If data_insert_parameter.Columns.Count < 2 Then
                data_insert_parameter.Columns.Add("code")
                data_insert_parameter.Columns.Add("value")
            End If
            GCCode.DataSource = data_insert_parameter
            DNCode.DataSource = data_insert_parameter
            Try
                add_combo_grid_val(GVCode, 0)
                view_value_code(GVCode, 1)
            Catch ex As Exception
            End Try
        ElseIf id_type = "2" Then
            data_insert_parameter_dsg.Clear()
            If data_insert_parameter_dsg.Columns.Count < 2 Then
                data_insert_parameter_dsg.Columns.Add("code")
                data_insert_parameter_dsg.Columns.Add("value")
            End If
            GCCodeDsg.DataSource = data_insert_parameter_dsg
            DNCodeDesign.DataSource = data_insert_parameter_dsg
            Try
                add_combo_grid_val(GVCodeDsg, 0)
                view_value_code(GVCodeDsg, 1)
            Catch ex As Exception
            End Try
        Else
            data_insert_parameter_non_md.Clear()
            If data_insert_parameter_non_md.Columns.Count < 2 Then
                data_insert_parameter_non_md.Columns.Add("code")
                data_insert_parameter_non_md.Columns.Add("value")
            End If
            GCCodeNonMD.DataSource = data_insert_parameter_non_md
            DNCodeNonMD.DataSource = data_insert_parameter_non_md
            Try
                add_combo_grid_val(GVCodeNonMD, 0)
                view_value_code(GVCodeNonMD, 1)
            Catch ex As Exception
            End Try
        End If
        Cursor = Cursors.Default
    End Sub
    Private Sub add_combo_grid_val(ByVal grid As DevExpress.XtraGrid.Views.Grid.GridView, ByVal col As Integer)
        Dim lookup As New DevExpress.XtraEditors.Repository.RepositoryItemSearchLookUpEdit

        lookup.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor

        Dim query As String = String.Format("SELECT id_code,code_name as Code,description as Description FROM tb_m_code")
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")

        lookup.DataSource = Nothing
        lookup.DataSource = data
        lookup.PopulateViewColumns()
        lookup.NullText = ""
        lookup.ReadOnly = True
        lookup.View.Columns("id_code").Visible = True
        lookup.DisplayMember = "Code"
        lookup.ValueMember = "id_code"

        grid.Columns(col).ColumnEdit = lookup
    End Sub
    Sub view_value_code(ByVal grid As DevExpress.XtraGrid.Views.Grid.GridView, ByVal col As Integer)
        Dim lookup As New DevExpress.XtraEditors.Repository.RepositoryItemSearchLookUpEdit

        lookup.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor

        Dim query As String = String.Format("SELECT id_code,id_code_detail,CODE as Code,code_detail_name as Name,display_name as 'Printed Name',CONCAT(CODE,' - ',code_detail_name) AS value FROM tb_m_code_detail")
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")

        lookup.DataSource = Nothing
        lookup.DataSource = data
        lookup.PopulateViewColumns()
        lookup.NullText = ""
        lookup.View.Columns("id_code_detail").Visible = False
        lookup.View.Columns("value").Visible = False
        lookup.View.Columns("id_code").Visible = False
        lookup.DisplayMember = "value"
        lookup.ValueMember = "id_code_detail"
        lookup.View.Columns("Code").SortOrder = DevExpress.Data.ColumnSortOrder.Ascending

        grid.Columns(col).ColumnEdit = lookup
    End Sub

    Private Function getLastCounting(ByVal digir_par As String) As String
        Dim id_season_sel As String = "-1"
        Try
            id_season_sel = LESeason.EditValue.ToString
            If id_season_sel = "" Then
                id_season_sel = "-1"
            End If
        Catch ex As Exception
        End Try
        Dim query As String = "CALL generate_product_counting('" + ss_dept + "','" + id_season_sel + "', " + digir_par + ")"
        Dim res As String = execute_query(query, 0, True, "", "", "", "")
        Return res
    End Function

    Private Sub FormMasterDesignSingle_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        TEName.Focus()
        actionLoad()
    End Sub

    Sub enableDisableCode()

    End Sub

    Sub viewDesign()
        Dim query As String = "SELECT * FROM tb_m_design a "
        query += "INNER JOIN tb_season b ON a.id_season = b.id_season "
        query += "INNER JOIN tb_range r ON r.id_range = b.id_range "
        If id_pop_up = "3" Then
            query += "WHERE r.id_departement='" + id_departement_user + "' "
        Else
            query += "WHERE r.is_md='1' "
        End If
        query += "ORDER BY a.id_season ASC "
        viewSearchLookupQuery(SLEDesign, query, "id_design", "design_display_name", "id_design")
    End Sub

    Sub viewStatus()
        'Dim query As String = "SELECT * FROM tb_lookup_design_price_type ORDER BY id_design_price_type ASC "
        'viewSearchLookupQuery(SLEStatus, query, "id_design_price_type", "design_price_type", "id_design_price_type")
    End Sub

    Sub viewActive()
        Dim query As String = "SELECT * FROM tb_lookup_status ORDER BY id_status "
        viewSearchLookupQuery(SLEActive, query, "id_status", "status", "id_status")
    End Sub

    Sub actionLoad()
        viewUOM(LEUOM)
        viewSeason(LESeason)
        viewSeasonOrign(SLESeasonOrigin)
        viewSampleOrign(LESampleOrign)
        view_ret_code(LERetCode)
        load_isi_param("1")
        load_isi_param("2")
        load_isi_param("3")


        'permission condition
        If id_pop_up = "-1" Or id_pop_up = "2" Or id_pop_up = "5" Then
            XTPDesign.PageVisible = True
            XTPMD.PageVisible = True
            XTPNonMD.PageVisible = False
            viewTemplate(LETemplate, "1")
            viewTemplate(LETemplateDsg, "3")
            ss_dept = get_setup_field("ss_default_dept")
        ElseIf id_pop_up = "3" Then 'non merch
            XTPDesign.PageVisible = False
            XTPMD.PageVisible = False
            XTPNonMD.PageVisible = True
            viewTemplate(LETemplateNonMD, "2")
            ss_dept = id_departement_user
            SLESeasonOrigin.EditValue = 0
        End If


        viewDesignType(LEDesignType)
        viewPlanOrder()
        viewDesign()
        viewStatus()
        viewActive()
        getCounting()

        'load img
        pre_viewImages("2", PictureEdit1, id_design, False)

        'for super admin
        If id_role_login = get_setup_field("id_role_super_admin").ToString Then
            TxtFabrication.Enabled = True
            LESampleOrign.Enabled = True
        End If

        If id_design <> "-1" Then
            'edit
            If dupe = "-1" Then
                view_product_price(id_design)
                view_product(id_design)
                XTPPrice.PageVisible = True
                XTPSize.PageVisible = True
            End If


            Try
                Dim query As String = "SELECT *, b.id_range "
                query += "FROM tb_m_design a "
                query += "INNER JOIN tb_season b on a.id_season = b.id_season "
                query += "INNER JOIN tb_season_delivery del ON a.id_delivery = del.id_delivery "
                query += "INNER JOIN tb_lookup_status d ON d.id_status = a.id_active  "
                query += "INNER JOIN tb_lookup_ret_code ret ON ret.id_ret_code = a.id_ret_code "
                query += "WHERE a.id_design = '" + id_design + "' "
                Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")

                id_range_par = data.Rows(0)("id_range").ToString
                TEName.Text = data.Rows(0)("design_name").ToString

                'display name
                If id_pop_up = "3" Then
                    TEDisplayNameNonMD.Text = data.Rows(0)("design_display_name").ToString
                Else
                    TEDisplayName.Text = data.Rows(0)("design_display_name").ToString
                End If

                'code
                If dupe = "-1" Then
                    If id_pop_up = "3" Then
                        TECodeNonMD.Text = data.Rows(0)("design_code").ToString
                    Else
                        TECode.Text = data.Rows(0)("design_code").ToString
                    End If
                End If
                TxtCodeImport.Text = data.Rows(0)("design_code_import").ToString

                LERetCode.EditValue = Nothing
                LERetCode.ItemIndex = LERetCode.Properties.GetDataSourceRowIndex("id_ret_code", data.Rows(0)("id_ret_code").ToString)

                LEUOM.EditValue = Nothing
                LEUOM.ItemIndex = LEUOM.Properties.GetDataSourceRowIndex("id_uom", data.Rows(0)("id_uom").ToString)

                LEDesignType.EditValue = Nothing
                LEDesignType.ItemIndex = LEDesignType.Properties.GetDataSourceRowIndex("id_design_type", data.Rows(0)("id_design_type").ToString)

                LESeason.EditValue = data.Rows(0)("id_season").ToString
                SLESeasonOrigin.EditValue = data.Rows(0)("id_season_orign").ToString
                LESampleOrign.EditValue = data.Rows(0)("id_sample").ToString

                SLEDel.EditValue = data.Rows(0)("id_delivery").ToString
                SLEDelAct.EditValue = data.Rows(0)("id_delivery_act").ToString
                DEEOS.EditValue = data.Rows(0)("design_eos")
                DERetDate.EditValue = data.Rows(0)("ret_date")
                TxtDelDate.EditValue = data.Rows(0)("delivery_date")
                DEWHDate.EditValue = data.Rows(0)("est_wh_date")
                TxtFabrication.Text = data.Rows(0)("design_fabrication").ToString
                LEPlanStatus.EditValue = data.Rows(0)("id_lookup_status_order")
                SLEDesign.EditValue = data.Rows(0)("id_design_ref")
                MEDetail.Text = data.Rows(0)("design_detail").ToString
                is_approved = data.Rows(0)("is_approved").ToString
                If is_approved = "1" Then
                    CheckEditApproved.EditValue = True
                Else
                    CheckEditApproved.EditValue = False
                End If

                If dupe = "-1" And id_pop_up = "5" Then ' only for dsg Line List
                    CheckEditApproved.Visible = True
                Else
                    CheckEditApproved.Visible = False
                End If


                If dupe = "-1" Then
                    SLEActive.EditValue = data.Rows(0)("id_active")
                Else
                    SLEActive.EditValue = "1"
                End If

                'from sample
                pre_viewImages("2", PictureEdit1, id_design, False)
                BViewImage.Visible = True

                '--DETAIL CODE---
                If id_pop_up <> "3" Then
                    'view code detail
                    If dupe = "-1" Then 'jika mode edit
                        query = String.Format("SELECT tb_m_code_detail.id_code as id_code,tb_m_design_code.id_code_detail as id_code_detail FROM tb_m_design_code,tb_m_code_detail, tb_template_code_det WHERE  tb_m_design_code.id_code_detail = tb_m_code_detail.id_code_detail AND tb_template_code_det.id_code = tb_m_code_detail.id_code AND tb_template_code_det.id_template_code='" + LETemplate.EditValue.ToString + "' AND tb_m_design_code.id_design = '{0}' ORDER BY tb_template_code_det.id_template_code_det ASC", id_design)
                        Dim data_value As DataTable = execute_query(query, -1, True, "", "", "", "")
                        If Not data_value.Rows.Count = 0 Then
                            data_insert_parameter.Clear()
                            For i As Integer = 0 To data_value.Rows.Count - 1
                                data_insert_parameter.Rows.Add(data_value.Rows(i)("id_code").ToString, data_value.Rows(i)("id_code_detail").ToString)
                            Next
                        End If
                    End If


                    'view DESIGN detail
                    query = String.Format("SELECT tb_m_code_detail.id_code as id_code,tb_m_design_code.id_code_detail as id_code_detail FROM tb_m_design_code,tb_m_code_detail, tb_template_code_det WHERE  tb_m_design_code.id_code_detail = tb_m_code_detail.id_code_detail AND tb_template_code_det.id_code = tb_m_code_detail.id_code AND tb_template_code_det.id_template_code='" + LETemplateDsg.EditValue.ToString + "' AND tb_m_design_code.id_design = '{0}' ORDER BY tb_template_code_det.id_template_code_det ASC", id_design)
                    Dim data_value_dsg As DataTable = execute_query(query, -1, True, "", "", "", "")
                    If Not data_value_dsg.Rows.Count = 0 Then
                        data_insert_parameter_dsg.Clear()
                        For i As Integer = 0 To data_value_dsg.Rows.Count - 1
                            data_insert_parameter_dsg.Rows.Add(data_value_dsg.Rows(i)("id_code").ToString, data_value_dsg.Rows(i)("id_code_detail").ToString)
                        Next
                    End If
                Else
                    'view NON MD detail
                    query = String.Format("SELECT tb_m_code_detail.id_code as id_code,tb_m_design_code.id_code_detail as id_code_detail FROM tb_m_design_code,tb_m_code_detail, tb_template_code_det WHERE  tb_m_design_code.id_code_detail = tb_m_code_detail.id_code_detail AND tb_template_code_det.id_code = tb_m_code_detail.id_code AND tb_template_code_det.id_template_code='" + LETemplateNonMD.EditValue.ToString + "' AND tb_m_design_code.id_design = '{0}' ORDER BY tb_template_code_det.id_template_code_det ASC", id_design)
                    Dim data_value_non_md As DataTable = execute_query(query, -1, True, "", "", "", "")
                    If Not data_value_non_md.Rows.Count = 0 Then
                        data_insert_parameter_non_md.Clear()
                        For i As Integer = 0 To data_value_non_md.Rows.Count - 1
                            data_insert_parameter_non_md.Rows.Add(data_value_non_md.Rows(i)("id_code").ToString, data_value_non_md.Rows(i)("id_code_detail").ToString)
                        Next
                    End If
                End If

                'special case from FormFGLineList
                If form_name = "FormFGLineList" Then
                    id_prod_demand_design_active = "-1"
                    If dupe = "-1" Then
                        XTPPrice.PageVisible = False

                        'disable season (mode edit)
                        LESeason.Enabled = True
                        BtnAddSeaason.Enabled = True

                        'cari id_prod_demand_design berdasarkan type yg aktuf & Load line list only UPDATE TYPE
                        If FormFGLineList.SLETypeLineList.EditValue.ToString = "1" Then
                            bool_qty_line = True
                            id_prod_demand_design_active = data.Rows(0)("id_prod_demand_design_line").ToString
                            XTPLineList.PageVisible = True
                            loadLineList(id_prod_demand_design_active)
                        ElseIf FormFGLineList.SLETypeLineList.EditValue.ToString = "2" Then
                            bool_qty_line = True
                            id_prod_demand_design_active = data.Rows(0)("id_prod_demand_design_line_upd").ToString
                            XTPLineList.PageVisible = True
                            loadLineList(id_prod_demand_design_active)
                        Else
                            bool_qty_line = False
                            id_prod_demand_design_active = data.Rows(0)("id_prod_demand_design_line_final").ToString
                            XTPLineList.PageVisible = False
                        End If
                    End If
                End If
                inputPermission()  'access limit
            Catch ex As Exception
                errorConnection()
            End Try
        Else
            'ins jika dilakuyukan di LINE LIST
            SLEDesign.EditValue = Nothing
            If formName = "FormFGLineList" Or formName = "FormFGDesignList" Then
                LESeason.EditValue = id_season_par
                LESampleOrign.EditValue = Nothing
            End If
            inputPermission() 'access limit
        End If
    End Sub

    Sub inputPermission()
        'type
        If id_pop_up = "-1" Then 'merchandise
            TEName.Enabled = False
            BeditCodeDsg.Enabled = False
            BRefreshCodeDsg.Enabled = False
            BGenerateDesc.Enabled = False
            LESampleOrign.Enabled = False
            TxtFabrication.Enabled = False
            SLEDesign.Enabled = False
            GCCodeDsg.Enabled = False
            XTPPrice.PageVisible = False
            LEUOM.Enabled = False
            TxtDelDate.Enabled = False
            DEWHDate.Enabled = False
            DERetDate.Enabled = False
            TELifetime.Enabled = False
            TEDisplayName.Enabled = False
            DEInStoreDet.Enabled = False
            MEDetail.Enabled = False
            TECode.Enabled = False
            TxtCodeImport.Enabled = False
            SLESeasonOrigin.Enabled = False
            BtnAddSeasonOrign.Enabled = False

            LESeason.Enabled = True
            BtnAddSeaason.Enabled = True
            XTPLineList.PageVisible = True
            XTPSize.PageVisible = True
            SLEDel.Enabled = True
            LERetCode.Enabled = True
            DEEOS.Enabled = True
            BeditCode.Enabled = True
            BRefreshCode.Enabled = True
            BGenerate.Enabled = True
            BtnGetLastCount.Enabled = True
            GCCode.Enabled = True
            BtnAddRetCode.Enabled = True
            PictureEdit1.Properties.ReadOnly = True
            XTPCode.SelectedTabPageIndex = 1

            'jika belum ada code size dan line list mati
            If TECode.Text = "" Then
                XTPSize.PageVisible = False
                XTPLineList.PageVisible = False
                BtnGetLastCount.Visible = True
            Else
                XTPSize.PageVisible = True
                XTPLineList.PageVisible = True
                BtnGetLastCount.Visible = False
            End If
        ElseIf id_pop_up = "2" Then 'sample dept
            XTPLineList.PageVisible = False
            XTPPrice.PageVisible = False
            XTPSize.PageVisible = False
            TEName.Enabled = False
            LEUOM.Enabled = False
            LESeason.Enabled = False
            SLEDel.Enabled = False
            TxtDelDate.Enabled = False
            LERetCode.Enabled = False
            DERetDate.Enabled = False
            TELifetime.Enabled = False
            DEEOS.Enabled = False
            BeditCode.Enabled = False
            BRefreshCode.Enabled = False
            TECode.Enabled = False
            BGenerate.Enabled = False
            TEDisplayName.Enabled = False
            LEPlanStatus.Enabled = False
            LESampleOrign.Enabled = True
            TxtFabrication.Enabled = True
            BtnGetLastCount.Enabled = False
            SLEDesign.Enabled = False
            GCCode.Enabled = False
            DEWHDate.Enabled = False
            DEInStoreDet.Enabled = False
            BtnAddRetCode.Enabled = False
            BtnAddSeaason.Enabled = False
            DNCode.Enabled = False
            PictureEdit1.Properties.ReadOnly = True
        ElseIf id_pop_up = "3" Then 'non merch
            TxtFabrication.Enabled = True
            LESampleOrign.Enabled = True
            LERetCode.Enabled = False
            DERetDate.Enabled = False
            DEEOS.Enabled = False
            LEPlanStatus.Enabled = False
        ElseIf id_pop_up = "4" Then 'preview design
            XTPLineList.PageVisible = False
            XTPPrice.PageVisible = False
            XTPSize.PageVisible = False
            TEName.Enabled = False
            LEUOM.Enabled = False
            LESeason.Enabled = False
            SLEDel.Enabled = False
            TxtDelDate.Enabled = False
            LERetCode.Enabled = False
            DERetDate.Enabled = False
            TELifetime.Enabled = False
            DEEOS.Enabled = False
            BeditCode.Enabled = False
            BRefreshCode.Enabled = False
            TECode.Enabled = False
            BGenerate.Enabled = False
            TEDisplayName.Enabled = False
            LEPlanStatus.Enabled = False
            LESampleOrign.Enabled = False
            TxtFabrication.Enabled = False
            BtnGetLastCount.Enabled = False
            SLEDesign.Enabled = False
            GCCode.Enabled = False
            DEWHDate.Enabled = False
            DEInStoreDet.Enabled = False
            BtnAddRetCode.Enabled = False
            BtnAddSeaason.Enabled = False
            DNCode.Enabled = False
            PictureEdit1.Properties.ReadOnly = True
            PanelControl2.Visible = False
            XTPSize.Visible = False
            XTPLineList.Visible = False
            XTPPrice.Visible = False
        ElseIf id_pop_up = "5" Then 'design dept
            TEName.Enabled = True
            BeditCodeDsg.Enabled = True
            BRefreshCodeDsg.Enabled = True
            BGenerateDesc.Enabled = True
            LESampleOrign.Enabled = True
            TxtFabrication.Enabled = True
            SLEDesign.Enabled = True
            GCCodeDsg.Enabled = True
            MEDetail.Enabled = True
            SLEDesign.Enabled = True
            TxtCodeImport.Enabled = True
            LESeason.Enabled = True
            SLESeasonOrigin.Enabled = True
            BtnAddSeasonOrign.Enabled = True


            PictureEdit1.Properties.ReadOnly = False
            XTPLineList.PageVisible = False
            XTPPrice.PageVisible = False
            XTPSize.PageVisible = False
            LEUOM.Enabled = False
            BtnAddSeaason.Enabled = False
            SLEDel.Enabled = False
            TxtDelDate.Enabled = False
            LERetCode.Enabled = False
            DERetDate.Enabled = False
            TELifetime.Enabled = False
            DEEOS.Enabled = False
            BeditCode.Enabled = False
            BRefreshCode.Enabled = False
            TECode.Enabled = False
            BGenerate.Enabled = False
            TEDisplayName.Enabled = False
            BtnGetLastCount.Enabled = False
            GCCode.Enabled = False
            DEWHDate.Enabled = False
            DEInStoreDet.Enabled = False
            BtnAddRetCode.Enabled = False
        Else 'unidentified -> from formmasterproduct
            XTPLineList.PageVisible = False
            XTPSize.PageVisible = False
            TEName.Enabled = False
            LEUOM.Enabled = False
            LESeason.Enabled = False
            SLEDel.Enabled = False
            TxtDelDate.Enabled = False
            DERetDate.Enabled = False
            TELifetime.Enabled = False
            BeditCode.Enabled = False
            BRefreshCode.Enabled = False
            TECode.Enabled = False
            BGenerate.Enabled = False
            TEDisplayName.Enabled = False
            LEPlanStatus.Enabled = False
            LESampleOrign.Enabled = False
            TxtFabrication.Enabled = False
            BtnGetLastCount.Enabled = False
            SLEDesign.Enabled = False
            GCCode.Enabled = False
            DEWHDate.Enabled = False
            DEInStoreDet.Enabled = False
            BtnAddRetCode.Enabled = False
            BtnAddSeaason.Enabled = False
            DNCode.Enabled = False
            PictureEdit1.Properties.ReadOnly = True
            XTPPrice.PageVisible = True
            LERetCode.Enabled = True
            DEEOS.Enabled = True
            SLEActive.Enabled = True
        End If

        'cek PO & FG Line List
        Dim is_permanent_master_dsg As String = get_setup_field("is_permanent_master_dsg")
        If is_permanent_master_dsg = "1" And dupe = "-1" Then
            Dim query_cek_po As String = ""
            query_cek_po += "SELECT COUNT(*) FROM tb_prod_order pr_ord "
            query_cek_po += "INNER JOIN tb_prod_demand_design pd_dsg ON pr_ord.id_prod_demand_design = pd_dsg.id_prod_demand_design "
            query_cek_po += "WHERE pd_dsg.id_design = '" + id_design + "' AND pr_ord.id_report_status !='5' "
            Dim jum_cek_po As String = execute_query(query_cek_po, 0, True, "", "", "", "")
            'jika uda ada PO yg diproses
            If jum_cek_po > 0 Then
                TEName.Enabled = False
                BeditCodeDsg.Enabled = False
                BRefreshCodeDsg.Enabled = False
                BGenerateDesc.Enabled = False
                LESampleOrign.Enabled = False
                TxtFabrication.Enabled = False
                SLEDesign.Enabled = False
                GCCodeDsg.Enabled = False
                BtnAddSeaason.Enabled = False
                LESeason.Enabled = False
                XTPPrice.PageVisible = False
                LEUOM.Enabled = False
                TxtDelDate.Enabled = False
                DERetDate.Enabled = False
                TELifetime.Enabled = False
                TEDisplayName.Enabled = False
                DEInStoreDet.Enabled = False
                MEDetail.Enabled = False
                TECode.Enabled = False
                TxtCodeImport.Enabled = False
                SLESeasonOrigin.Enabled = False
                BtnAddSeasonOrign.Enabled = False

                If id_pop_up = "-1" Then
                    XTPLineList.PageVisible = True
                End If
                XTPSize.PageVisible = False
                SLEDel.Enabled = False
                LERetCode.Enabled = False
                DEEOS.Enabled = False
                BeditCode.Enabled = False
                BRefreshCode.Enabled = False
                BGenerate.Enabled = False
                BtnGetLastCount.Enabled = False
                GCCode.Enabled = False
                DEWHDate.Enabled = False
                BtnAddRetCode.Enabled = False
            End If
        End If
    End Sub

    Sub loadLineList(ByVal id_prod_demand_design_param As String)
        Try
            FormProdDemandDesignSingle.Dispose()
        Catch ex As Exception
        End Try
        XTPLineList.Controls.Clear()
        FormProdDemandDesignSingle.TopLevel = False
        XTPLineList.Controls.Add(FormProdDemandDesignSingle)
        FormProdDemandDesignSingle.id_prod_demand_design = id_prod_demand_design_param
        FormProdDemandDesignSingle.action = "upd"
        FormProdDemandDesignSingle.form_name = Name
        FormProdDemandDesignSingle.Show()
        FormProdDemandDesignSingle.ControlBox = False
        FormProdDemandDesignSingle.FormBorderStyle = Windows.Forms.FormBorderStyle.None
        FormProdDemandDesignSingle.Focus()
        FormProdDemandDesignSingle.Dock = DockStyle.Fill
    End Sub

    Private Sub GVCode_CellValueChanged(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles GVCode.CellValueChanged
        If e.Column.Name.ToString <> "ColCodeParam" Then
            Exit Sub
        Else
            Dim cellValue As String = e.Value.ToString()

            Dim query As String = String.Format("SELECT id_code,id_code_detail,CODE as Code,code_detail_name as Name,display_name as 'Printed Name',CONCAT(CODE,' - ',code_detail_name) AS value FROM tb_m_code_detail WHERE id_code='" & cellValue.ToString & "'")
            Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
            GVCode.SetRowCellValue(e.RowHandle, GVCode.Columns("value"), data.Rows(0)("id_code").ToString)
        End If
    End Sub
    Private clone As DataView = Nothing
    Private Sub GVCode_ShownEditor(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GVCode.ShownEditor
        Dim view As DevExpress.XtraGrid.Views.Grid.GridView = CType(sender, DevExpress.XtraGrid.Views.Grid.GridView)
        If view.FocusedColumn.FieldName = "value" AndAlso TypeOf view.ActiveEditor Is DevExpress.XtraEditors.SearchLookUpEdit Then
            Dim edit As DevExpress.XtraEditors.SearchLookUpEdit
            Dim table As DataTable
            Dim row As DataRow

            edit = CType(view.ActiveEditor, DevExpress.XtraEditors.SearchLookUpEdit)
            Try
                table = CType(edit.Properties.DataSource, DataTable)
            Catch ex As Exception
                table = CType(edit.Properties.DataSource, DataView).Table
            End Try
            clone = New DataView(table)

            row = view.GetDataRow(view.FocusedRowHandle)
            clone.RowFilter = "[id_code] = " + row("code").ToString()
            edit.Properties.DataSource = clone
        End If
    End Sub

    Private Sub GVCode_HiddenEditor(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GVCode.HiddenEditor
        If clone IsNot Nothing Then
            clone.Dispose()
            clone = Nothing
        End If
    End Sub

    Sub load_template(ByVal id_template As String)
        Dim query As String = String.Format("SELECT * FROM tb_template_code_det WHERE id_template_code = '{0}'", id_template)
        Dim data_value As DataTable = execute_query(query, -1, True, "", "", "", "")

        data_insert_parameter.Clear()
        If Not data_value.Rows.Count = 0 Then
            For i As Integer = 0 To data_value.Rows.Count - 1
                data_insert_parameter.Rows.Add(data_value.Rows(i)("id_code").ToString)
            Next
        End If
    End Sub

    Sub load_template_dsg(ByVal id_template As String)
        Dim query As String = String.Format("SELECT * FROM tb_template_code_det WHERE id_template_code = '{0}'", id_template)
        Dim data_value As DataTable = execute_query(query, -1, True, "", "", "", "")

        data_insert_parameter_dsg.Clear()
        If Not data_value.Rows.Count = 0 Then
            For i As Integer = 0 To data_value.Rows.Count - 1
                data_insert_parameter_dsg.Rows.Add(data_value.Rows(i)("id_code").ToString)
            Next
        End If
    End Sub

    Sub load_template_non_md(ByVal id_template As String)
        Dim query As String = String.Format("SELECT * FROM tb_template_code_det WHERE id_template_code = '{0}'", id_template)
        Dim data_value As DataTable = execute_query(query, -1, True, "", "", "", "")

        data_insert_parameter_non_md.Clear()
        If Not data_value.Rows.Count = 0 Then
            For i As Integer = 0 To data_value.Rows.Count - 1
                data_insert_parameter_non_md.Rows.Add(data_value.Rows(i)("id_code").ToString)
            Next
        End If
    End Sub


    Private Sub LETemplate_EditValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LETemplate.EditValueChanged
        load_template(LETemplate.EditValue)
    End Sub

    Private Sub BGenerate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BGenerate.Click
        Dim id_code, code, query As String
        Dim code_full As String = ""

        For i As Integer = 0 To GVCode.RowCount - 1
            code = ""
            id_code = ""
            Try
                id_code = GVCode.GetRowCellValue(i, "value").ToString
            Catch ex As Exception
                id_code = ""
            End Try

            If Not id_code = "" Or id_code = "0" Then
                Try
                    query = String.Format("SELECT is_include_code FROM tb_m_code,tb_m_code_detail WHERE tb_m_code.id_code=tb_m_code_detail.id_code AND tb_m_code_detail.id_code_detail='" & id_code & "'")
                    code = execute_query(query, 0, True, "", "", "", "")
                Catch ex As Exception
                    code = "False"
                End Try

                If code = "True" Then
                    query = String.Format("SELECT code FROM tb_m_code_detail WHERE id_code_detail='" & id_code & "'")
                    code = execute_query(query, 0, True, "", "", "", "")
                Else
                    code = ""
                End If
            End If
            code_full += code
        Next
        TECode.Text = code_full
    End Sub

    Private Sub BSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BSave.Click
        ValidateChildren()
        Dim id_lookup_status_order, id_design_tersimpan, query, namex, display_name, code, id_uom, id_season, sample_orign, id_design_type, design_ret_code, id_delivery, id_delivery_act, design_eos, design_fabrication, id_design_ref, id_active, design_detail, code_import, id_season_orign, is_old_design As String
        namex = addSlashes(TEName.Text.TrimStart(" ").TrimEnd(" "))

        'code & display name
        If id_pop_up = "3" Then
            display_name = addSlashes(TEDisplayNameNonMD.Text)
            code = TECodeNonMD.Text
        Else
            display_name = addSlashes(TEDisplayName.Text)
            code = TECode.Text
        End If
        code_import = TxtCodeImport.Text
        If code_import = "" Then
            code_import = "NULL"
        Else
            code_import = "'" + code_import + "'"
        End If

        id_uom = LEUOM.EditValue
        id_season = LESeason.EditValue
        id_season_orign = SLESeasonOrigin.EditValue
        design_ret_code = LERetCode.EditValue.ToString
        If id_pop_up = "3" Then 'non merch
            id_design_type = "2"
            is_old_design = "1"
        Else
            id_design_type = "1"
            is_old_design = "2"
        End If
        id_delivery = myCoalesce(SLEDel.EditValue.ToString, "0")
        id_delivery_act = myCoalesce(SLEDel.EditValue.ToString, "0")
        id_active = SLEActive.EditValue.ToString
        design_eos = "-1"
        design_detail = addSlashes(MEDetail.Text.ToString)
        Try
            design_eos = DateTime.Parse(DEEOS.EditValue.ToString).ToString("yyyy-MM-dd")
        Catch ex As Exception
        End Try
        sample_orign = "0"
        Try
            sample_orign = LESampleOrign.EditValue
        Catch ex As Exception
        End Try
        design_fabrication = addSlashes(TxtFabrication.Text)
        id_lookup_status_order = "1"

        id_design_ref = Nothing
        Try
            id_design_ref = SLEDesign.EditValue.ToString
        Catch ex As Exception
        End Try

        'validate
        EP_TE_cant_blank(EPMasterDesign, TEName)
        If id_pop_up = "-1" Then
            EP_TE_cant_blank(EPMasterDesign, TECode)
        ElseIf id_pop_up = "3" Then
            EP_TE_cant_blank(EPMasterDesign, TECodeNonMD)
        End If
        If id_pop_up = "5" Then
            EP_TE_cant_blank(EPMasterDesign, TEDisplayName)
        ElseIf id_pop_up = "3" Then
            EP_TE_cant_blank(EPMasterDesign, TEDisplayNameNonMD)
        End If
        validateLifetime()
        EP_DE_cant_blank(EPMasterDesign, DERetDate)
        EP_DE_cant_blank(EPMasterDesign, TxtDelDate)

        'cek code- hanya utk codefikasi
        If id_pop_up = "-1" Then
            Dim query_cek_code As String = ""
            If id_design = "-1" Then 'New
                query_cek_code = "SELECT COUNT(*) FROM tb_m_design a WHERE a.design_code = '" + code + "' AND a.id_active=1 "
            Else 'Edit
                If dupe = "-1" Then
                    query_cek_code = "SELECT COUNT(*) FROM tb_m_design a WHERE a.design_code = '" + code + "' AND a.id_design !='" + id_design + "' AND a.id_active=1 "
                Else
                    query_cek_code = "SELECT COUNT(*) FROM tb_m_design a WHERE a.design_code = '" + code + "' AND a.id_active=1 "
                End If
            End If
            Dim jum_row As String = execute_query(query_cek_code, 0, True, "", "", "", "")
            If jum_row > 0 Then
                stopCustom("Duplicate code, please fill another code.")
                Exit Sub
            End If
        End If

        'keep view
        Dim find_string As String = ""
        Dim filter_string As String = ""
        If form_name = "FormFGDesignList" Then
            find_string = FormFGDesignList.GVDesign.FindFilterText.ToString
            filter_string = FormFGDesignList.GVDesign.ActiveFilterString
        End If

        Cursor = Cursors.WaitCursor
        'save
        If id_design <> "-1" Then
            If dupe <> "-1" Then
                'insert
                If Not formIsValidInPanel(EPMasterDesign, PanC1) Or Not formIsValidInPanel(EPMasterDesign, PanC2) Or Not formIsValidInPanel(EPMasterDesign, PanC4) Or Not formIsValidInPanel(EPMasterDesign, PanC5) Then
                    errorInput()
                Else
                    Dim confirm As DialogResult = DevExpress.XtraEditors.XtraMessageBox.Show("Are you sure want to save changes?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
                    If confirm = Windows.Forms.DialogResult.Yes Then
                        query = "INSERT INTO tb_m_design(design_name,design_display_name,design_code, design_code_import,id_uom,id_season, id_season_orign,id_ret_code,id_design_type, id_delivery, id_delivery_act, design_eos, design_fabrication, id_sample, id_design_ref, id_lookup_status_order, design_detail, is_old_design) "
                        query += "VALUES('" + namex + "','" + display_name + "','" + code + "', " + code_import + ",'" + id_uom + "','" + id_season + "', '" + id_season_orign + "','" + design_ret_code + "','" + id_design_type + "', '" + id_delivery + "', '" + id_delivery_act + "', "
                        If design_eos = "-1" Then
                            query += "NULL, "
                        Else
                            query += "'" + design_eos + "', "
                        End If
                        If design_fabrication = "" Then
                            query += "NULL, "
                        Else
                            query += "'" + design_fabrication + "', "
                        End If
                        If sample_orign = "0" Or sample_orign = "" Then
                            query += "NULL, "
                        Else
                            query += "'" + sample_orign + "', "
                        End If

                        If id_design_ref = Nothing Then
                            query += "NULL, "
                        Else
                            query += "'" + id_design_ref + "', "
                        End If
                        query += "'" + id_lookup_status_order + "', '" + design_detail + "' "
                        query += ", '" + is_old_design + "');SELECT LAST_INSERT_ID(); "
                        id_design_tersimpan = execute_query(query, 0, True, "", "", "", "")

                        'cek image
                        save_image_ori(PictureEdit1, product_image_path, id_design_tersimpan & ".jpg")
                        query = String.Format("DELETE FROM tb_m_design_code WHERE id_design='" & id_design_tersimpan & "'")
                        execute_non_query(query, True, "", "", "", "")

                        'codefication
                        For i As Integer = 0 To GVCode.RowCount - 1
                            Try
                                If Not GVCode.GetRowCellValue(i, "value").ToString = "" Or GVCode.GetRowCellValue(i, "value").ToString = 0 Then
                                    query = String.Format("INSERT INTO tb_m_design_code(id_design,id_code_detail) VALUES('{0}','{1}')", id_design_tersimpan, GVCode.GetRowCellValue(i, "value").ToString)
                                    execute_non_query(query, True, "", "", "", "")
                                End If
                            Catch ex As Exception
                            End Try
                        Next

                        'detail design
                        For i As Integer = 0 To GVCodeDsg.RowCount - 1
                            Try
                                If Not GVCodeDsg.GetRowCellValue(i, "value").ToString = "" Or GVCodeDsg.GetRowCellValue(i, "value").ToString = "0" Then
                                    query = String.Format("INSERT INTO tb_m_design_code(id_design,id_code_detail) VALUES('{0}','{1}')", id_design_tersimpan, GVCodeDsg.GetRowCellValue(i, "value").ToString)
                                    execute_non_query(query, True, "", "", "", "")
                                End If
                            Catch ex As Exception
                            End Try
                        Next

                        'non MD
                        For i As Integer = 0 To GVCodeNonMD.RowCount - 1
                            Try
                                If Not GVCodeNonMD.GetRowCellValue(i, "value").ToString = "" Or GVCodeNonMD.GetRowCellValue(i, "value").ToString = 0 Then
                                    query = String.Format("INSERT INTO tb_m_design_code(id_design,id_code_detail) VALUES('{0}','{1}')", id_design_tersimpan, GVCodeNonMD.GetRowCellValue(i, "value").ToString)
                                    execute_non_query(query, True, "", "", "", "")
                                End If
                            Catch ex As Exception
                            End Try
                        Next

                        'default price for Non MD
                        If id_pop_up = "3" Then
                            setDefaultPrice(id_design_tersimpan, 0)
                        End If

                        'new line list
                        NewLineList(id_design_tersimpan, id_season, id_delivery)

                        If form_name = "-1" Then
                            FormMasterProduct.view_design()
                            FormMasterProduct.GVDesign.FocusedRowHandle = find_row(FormMasterProduct.GVDesign, "id_design", id_design_tersimpan)
                        ElseIf form_name = "FormFGLineList" Then
                            FormFGLineList.SLESeason.EditValue = LESeason.EditValue
                            FormFGLineList.viewLineList()
                            FormFGLineList.BGVLineList.FocusedRowHandle = find_row(FormFGLineList.BGVLineList, "id_design", id_design_tersimpan)
                        ElseIf form_name = "FormFGDesignList" Then
                            FormFGDesignList.SLESeason.EditValue = LESeason.EditValue
                            FormFGDesignList.viewData()
                            FormFGDesignList.GVDesign.FocusedRowHandle = find_row(FormFGDesignList.GVDesign, "id_design", id_design_tersimpan)
                            FormFGDesignList.GVDesign.ApplyFindFilter(find_string)
                            FormFGDesignList.GVDesign.ActiveFilterString = filter_string
                        End If

                        dupe = "-1"
                        id_design = id_design_tersimpan
                        Dim stt As New ClassDesign
                        stt.updatedTime(id_design)
                        infoCustom(display_name + ", has been sucessfully created.")
                        actionLoad()
                    End If
                End If
            Else
                'edit
                If Not formIsValidInPanel(EPMasterDesign, PanC1) Or Not formIsValidInPanel(EPMasterDesign, PanC2) Or Not formIsValidInPanel(EPMasterDesign, PanC4) Or Not formIsValidInPanel(EPMasterDesign, PanelDesc) Or Not formIsValidInPanel(EPMasterDesign, PanC5) Then
                    errorInput()
                Else
                    Dim confirm As DialogResult = DevExpress.XtraEditors.XtraMessageBox.Show("Are you sure want to save changes?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
                    If confirm = Windows.Forms.DialogResult.Yes Then
                        Cursor = Cursors.WaitCursor
                        query = "UPDATE tb_m_design SET design_name='{0}',design_display_name='{1}',design_code='{2}', design_code_import=" + code_import + ",id_uom='{3}',id_season='{4}', id_season_orign='" + id_season_orign + "',id_design_type='{6}',id_ret_code='{7}', id_delivery='" + id_delivery + "', id_delivery_act='" + id_delivery_act + "', "
                        If design_eos = "-1" Then
                            query += "design_eos=NULL, "
                        Else
                            query += "design_eos='" + design_eos + "', "
                        End If
                        If design_fabrication = "" Then
                            query += "design_fabrication=NULL, "
                        Else
                            query += "design_fabrication='" + design_fabrication + "', "
                        End If
                        If sample_orign = "0" Or sample_orign = "" Then
                            query += "id_sample=NULL, "
                        Else
                            query += "id_sample='" + sample_orign + "', "
                        End If

                        If id_design_ref = Nothing Then
                            query += "id_design_ref=NULL, "
                        Else
                            query += "id_design_ref='" + id_design_ref + "', "
                        End If
                        query += "id_active='" + id_active + "', "
                        query += "id_lookup_status_order='" + id_lookup_status_order + "', design_detail='" + design_detail + "' "
                        query += "WHERE id_design='{5}' "
                        query = String.Format(query, namex, display_name, code, id_uom, id_season, id_design, id_design_type, design_ret_code)
                        execute_non_query(query, True, "", "", "", "")

                        save_image_ori(PictureEdit1, product_image_path, id_design & ".jpg")
                        query = String.Format("DELETE FROM tb_m_design_code WHERE id_design='" & id_design & "'; ")


                        'codefication
                        For i As Integer = 0 To GVCode.RowCount - 1
                            Try
                                If Not GVCode.GetRowCellValue(i, "value").ToString = "" Or GVCode.GetRowCellValue(i, "value").ToString = "0" Then
                                    query += String.Format("INSERT INTO tb_m_design_code(id_design,id_code_detail) VALUES('{0}','{1}'); ", id_design, GVCode.GetRowCellValue(i, "value").ToString)
                                    'execute_non_query(query, True, "", "", "", "")
                                End If
                            Catch ex As Exception
                            End Try
                        Next

                        'detail design
                        For i As Integer = 0 To GVCodeDsg.RowCount - 1
                            Try
                                If Not GVCodeDsg.GetRowCellValue(i, "value").ToString = "" Or GVCodeDsg.GetRowCellValue(i, "value").ToString = "0" Then
                                    query += String.Format("INSERT INTO tb_m_design_code(id_design,id_code_detail) VALUES('{0}','{1}'); ", id_design, GVCodeDsg.GetRowCellValue(i, "value").ToString)
                                    'execute_non_query(query, True, "", "", "", "")
                                End If
                            Catch ex As Exception
                            End Try
                        Next

                        'non MD
                        For i As Integer = 0 To GVCodeNonMD.RowCount - 1
                            Try
                                If Not GVCodeNonMD.GetRowCellValue(i, "value").ToString = "" Or GVCodeNonMD.GetRowCellValue(i, "value").ToString = 0 Then
                                    query += String.Format("INSERT INTO tb_m_design_code(id_design,id_code_detail) VALUES('{0}','{1}');", id_design, GVCodeNonMD.GetRowCellValue(i, "value").ToString)
                                    ' execute_non_query(query, True, "", "", "", "")
                                End If
                            Catch ex As Exception
                            End Try
                        Next
                        execute_non_query(query, True, "", "", "", "")

                        'pdate product code
                        updProductCode(id_design)

                        If form_name = "FormMasterProduct" Then
                            FormMasterProduct.view_design()
                            FormMasterProduct.GVDesign.FocusedRowHandle = find_row(FormMasterProduct.GVDesign, "id_design", id_design)
                        ElseIf form_name = "FormFGLineList" Then
                            FormFGLineList.viewLineList()
                            FormFGLineList.BGVLineList.FocusedRowHandle = find_row(FormFGLineList.BGVLineList, "id_design", id_design)
                        ElseIf form_name = "FormFGDesignList" Then
                            FormFGDesignList.SLESeason.EditValue = LESeason.EditValue
                            FormFGDesignList.viewData()
                            FormFGDesignList.GVDesign.FocusedRowHandle = find_row(FormFGDesignList.GVDesign, "id_design", id_design)
                            FormFGDesignList.GVDesign.ApplyFindFilter(find_string)
                            FormFGDesignList.GVDesign.ActiveFilterString = filter_string
                        End If

                        'ipdate time
                        Dim stt As New ClassDesign
                        stt.updatedTime(id_design)

                        Cursor = Cursors.Default
                        infoCustom("Edit has been sucessfully.")
                        actionLoad()
                    End If
                End If
            End If
        Else
            'insert
            If Not formIsValidInPanel(EPMasterDesign, PanC1) Or Not formIsValidInPanel(EPMasterDesign, PanC2) Or Not formIsValidInPanel(EPMasterDesign, PanC4) Or Not formIsValidInPanel(EPMasterDesign, PanelDesc) Or Not formIsValidInPanel(EPMasterDesign, PanC5) Then
                errorInput()
            Else
                Dim confirm As DialogResult = DevExpress.XtraEditors.XtraMessageBox.Show("Are you sure want to save changes?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
                If confirm = Windows.Forms.DialogResult.Yes Then
                    Dim approved As String = "2"
                    If id_pop_up = "3" Then 'non MD
                        approved = "1"
                    End If

                    query = "INSERT INTO tb_m_design(design_name,design_display_name,design_code, design_code_import,id_uom,id_season, id_season_orign,id_ret_code,id_design_type, id_delivery, id_delivery_act, design_eos, design_fabrication, id_sample, id_design_ref, id_lookup_status_order, design_detail, is_approved, is_old_design) "
                    query += "VALUES('" + namex + "','" + display_name + "','" + code + "'," + code_import + ",'" + id_uom + "','" + id_season + "', '" + id_season_orign + "','" + design_ret_code + "','" + id_design_type + "', '" + id_delivery + "', '" + id_delivery_act + "', "
                    If design_eos = "-1" Then
                        query += "NULL, "
                    Else
                        query += "'" + design_eos + "', "
                    End If
                    If design_fabrication = "" Then
                        query += "NULL, "
                    Else
                        query += "'" + design_fabrication + "', "
                    End If
                    If sample_orign = "0" Or sample_orign = "" Then
                        query += "NULL, "
                    Else
                        query += "'" + sample_orign + "', "
                    End If

                    If id_design_ref = Nothing Then
                        query += "NULL, "
                    Else
                        query += "'" + id_design_ref + "', "
                    End If
                    query += "'" + id_lookup_status_order + "', '" + design_detail + "', '" + approved + "' , '" + is_old_design + "' "
                    query += ");SELECT LAST_INSERT_ID(); "
                    id_design_tersimpan = execute_query(query, 0, True, "", "", "", "")

                    'cek image
                    'MsgBox(get_setup_field("pic_path_design") + "\" + " " + id_design_tersimpan)
                    save_image_ori(PictureEdit1, product_image_path, id_design_tersimpan & ".jpg")
                    query = String.Format("DELETE FROM tb_m_design_code WHERE id_design='" & id_design_tersimpan & "'")
                    execute_non_query(query, True, "", "", "", "")

                    'design detail
                    For i As Integer = 0 To GVCodeDsg.RowCount - 1
                        Try
                            If Not GVCodeDsg.GetRowCellValue(i, "value").ToString = "" Or GVCodeDsg.GetRowCellValue(i, "value").ToString = 0 Then
                                query = String.Format("INSERT INTO tb_m_design_code(id_design,id_code_detail) VALUES('{0}','{1}')", id_design_tersimpan, GVCodeDsg.GetRowCellValue(i, "value").ToString)
                                execute_non_query(query, True, "", "", "", "")
                            End If
                        Catch ex As Exception
                        End Try
                    Next

                    'codefikasi
                    For i As Integer = 0 To GVCode.RowCount - 1
                        Try
                            If Not GVCode.GetRowCellValue(i, "value").ToString = "" Or GVCode.GetRowCellValue(i, "value").ToString = 0 Then
                                query = String.Format("INSERT INTO tb_m_design_code(id_design,id_code_detail) VALUES('{0}','{1}')", id_design_tersimpan, GVCode.GetRowCellValue(i, "value").ToString)
                                execute_non_query(query, True, "", "", "", "")
                            End If
                        Catch ex As Exception
                        End Try
                    Next

                    'non MD
                    For i As Integer = 0 To GVCodeNonMD.RowCount - 1
                        Try
                            If Not GVCodeNonMD.GetRowCellValue(i, "value").ToString = "" Or GVCodeNonMD.GetRowCellValue(i, "value").ToString = 0 Then
                                query = String.Format("INSERT INTO tb_m_design_code(id_design,id_code_detail) VALUES('{0}','{1}')", id_design_tersimpan, GVCodeNonMD.GetRowCellValue(i, "value").ToString)
                                execute_non_query(query, True, "", "", "", "")
                            End If
                        Catch ex As Exception
                        End Try
                    Next

                    'default price for Non MD
                    If id_pop_up = "3" Then
                        setDefaultPrice(id_design_tersimpan, 0)
                    End If

                    'new line list
                    NewLineList(id_design_tersimpan, id_season, id_delivery)

                    If form_name = "-1" Then
                        FormMasterProduct.view_design()
                        FormMasterProduct.GVDesign.FocusedRowHandle = find_row(FormMasterProduct.GVDesign, "id_design", id_design_tersimpan)
                    ElseIf form_name = "FormFGLineList" Then
                        FormFGLineList.SLESeason.EditValue = LESeason.EditValue
                        FormFGLineList.viewLineList()
                        FormFGLineList.BGVLineList.FocusedRowHandle = find_row(FormFGLineList.BGVLineList, "id_design", id_design_tersimpan)
                    ElseIf form_name = "FormFGDesignList" Then
                        FormFGDesignList.SLESeason.EditValue = LESeason.EditValue
                        FormFGDesignList.viewData()
                        FormFGDesignList.GVDesign.FocusedRowHandle = find_row(FormFGDesignList.GVDesign, "id_design", id_design_tersimpan)
                        FormFGDesignList.GVDesign.ApplyFindFilter(find_string)
                        FormFGDesignList.GVDesign.ActiveFilterString = filter_string
                    End If
                    id_design = id_design_tersimpan

                    'ipdate time
                    Dim stt As New ClassDesign
                    stt.updatedTime(id_design)

                    infoCustom(display_name + " has been sucessfully created.")
                    actionLoad()
                End If
            End If
        End If
        Cursor = Cursors.Default
    End Sub

    Sub setDefaultPrice(ByVal id_design_set As String, price As Decimal)
        Dim query As String = "INSERT INTO tb_m_design_price(id_design, id_design_price_type, design_price_name, id_currency, design_price, design_price_date, design_price_start_date, is_print, id_user) 
                               VALUES('" + id_design_set + "', '1', 'Normal', '1', '" + decimalSQL(price) + "', NOW(), NOW(), '1', '" + id_user + "') "
        execute_non_query(query, True, "", "", "", "")
    End Sub

    Sub updProductCode(ByVal id_dsg_param As String)
        Dim query As String = "UPDATE tb_m_product a INNER JOIN tb_m_design b ON a.id_design = b.id_design SET a.product_full_code = CONCAT(b.design_code,a.product_code), a.product_display_name = b.design_display_name, a.product_name = b.design_display_name WHERE a.id_design = '" + id_dsg_param + "' "
        execute_non_query(query, True, "", "", "", "")
    End Sub

    Sub NewLineList(ByVal id_design_param As String, ByVal id_season_param As String, ByVal id_delivery_param As String)
        Dim query As String = "CALL ins_line_list('" + id_design_param + "','" + id_season_param + "','" + id_delivery_param + "')"
        execute_non_query(query, True, "", "", "", "")
    End Sub

    Private Sub validateLifetime()
        If Not isNumber(TELifetime.Text) Or TELifetime.Text.Length < 1 Then
            EPMasterDesign.SetError(TELifetime, "Not a valid input.")
            'EPMasterDesign.SetIconPadding(TELifetime, 50)
        Else
            EPMasterDesign.SetError(TELifetime, String.Empty)
        End If
    End Sub

    Private Sub TEName_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TEName.Validating
        EP_TE_cant_blank(EPMasterDesign, TEName)
    End Sub

    Private Sub TEDisplayName_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TEDisplayName.Validating
        If id_pop_up = "5" Then
            EP_TE_cant_blank(EPMasterDesign, TEDisplayName)
        End If
    End Sub

    Private Sub TELifetime_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TELifetime.Validating
        validateLifetime()
    End Sub

    Private Sub TECode_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TECode.Validating
        If id_pop_up = "-1" Then 'only for codefication
            EP_TE_cant_blank(EPMasterDesign, TECode)
            EPMasterDesign.SetIconPadding(TECode, 400)
        End If
    End Sub

    Private Sub FormMasterDesignSingle_FormClosed(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub BViewImage_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BViewImage.Click
        pre_viewImages("2", PictureEdit1, id_design, True)
    End Sub

    Private Sub PictureEdit1_Modified(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureEdit1.Modified
        BViewImage.Visible = False
    End Sub

    Private Sub LESampleOrign_EditValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LESampleOrign.EditValueChanged
        'from sample
        Dim fabric As String = ""
        Try
            fabric = LESampleOrign.Properties.View.GetFocusedRowCellValue("sample_fabrication").ToString
        Catch ex As Exception
        End Try
        TxtFabrication.Text = fabric.ToString

        Dim id_sample_par As String = "-1"
        Try
            id_sample_par = LESampleOrign.EditValue.ToString
        Catch ex As Exception
        End Try
        'pre_viewImages("1", PictureEdit1, id_sample_par, False)
        'BViewImage.Visible = False
    End Sub

    '============= begin code price ================
    Sub view_product_price(ByVal id_designx As String)
        Dim query As String = ""
        query += "SELECT *, ifnull(pp.fg_propose_price_number, '-') AS pp_number FROM tb_m_design_price price "
        query += "INNER JOIN tb_lookup_design_price_type price_type ON price.id_design_price_type = price_type.id_design_price_type "
        query += "INNER JOIN tb_lookup_currency curr ON curr.id_currency = price.id_currency "
        query += "INNER JOIN tb_m_user user ON user.id_user = price.id_user "
        query += "INNER JOIN tb_m_employee emp ON emp.id_employee = user.id_employee "
        query += "LEFT JOIN tb_fg_propose_price pp ON pp.id_fg_propose_price = price.id_fg_propose_price "
        query += "WHERE price.id_design = '" + id_designx + "' AND price.is_design_cost!='1' "
        query += "ORDER BY price.id_design_price ASC"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCProductPrice.DataSource = data

        If data.Rows.Count < 1 Then
            Bdelete.Visible = False
        Else
            Bdelete.Visible = True
        End If
    End Sub

    Private Sub BAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BAdd.Click
        Cursor = Cursors.WaitCursor
        FormMasterDesignPriceSingle.id_design = id_design
        FormMasterDesignPriceSingle.ShowDialog()
        Cursor = Cursors.Default
    End Sub

    Private Sub Bdelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Bdelete.Click
        ''delete
        Dim confirm As DialogResult
        Dim query As String
        confirm = DevExpress.XtraEditors.XtraMessageBox.Show("Are you sure want to delete this data?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)

        Dim id_design_price As String = GVProductPrice.GetFocusedRowCellDisplayText("id_design_price").ToString
        If confirm = Windows.Forms.DialogResult.Yes Then
            Cursor = Cursors.WaitCursor
            Try
                query = String.Format("DELETE FROM tb_m_design_price WHERE id_design_price = '{0}'", id_design_price)
                execute_non_query(query, True, "", "", "", "")
                view_product_price(id_design)
            Catch ex As Exception
                DevExpress.XtraEditors.XtraMessageBox.Show("This data already used. Can't delete.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
            Cursor = Cursors.Default
        End If
    End Sub
    Private Sub BRefreshCode_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BRefreshCode.Click
        load_isi_param("1")
        load_template(LETemplate.EditValue)
    End Sub

    Private Sub BeditCode_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BeditCode.Click
        FormCodeTemplateEdit.id_pop_up = "2"
        FormCodeTemplateEdit.id_template_code = LETemplate.EditValue.ToString
        FormCodeTemplateEdit.ShowDialog()
    End Sub

    Private Sub BtnSetAsPrintedPrice_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSetAsPrintedPrice.Click
        Cursor = Cursors.Default

        Dim id_design_price As String = GVProductPrice.GetFocusedRowCellDisplayText("id_design_price").ToString
        Dim confirm As DialogResult = DevExpress.XtraEditors.XtraMessageBox.Show("Are you sure want to set data as printed price?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
        If confirm = Windows.Forms.DialogResult.Yes Then
            Dim id_design_pricex As String = "-1"
            Dim id_designx As String = "-1"
            Try
                id_design_pricex = GVProductPrice.GetFocusedRowCellValue("id_design_price").ToString
            Catch ex As Exception
            End Try

            Try
                id_designx = GVProductPrice.GetFocusedRowCellValue("id_design").ToString
            Catch ex As Exception
            End Try



            'update status
            Dim query_status As String = "UPDATE tb_m_design_price SET is_print = '0' WHERE id_design='" + id_designx + "' "
            execute_non_query(query_status, True, "", "", "", "")

            'active status
            Dim query_active As String = "UPDATE tb_m_design_price SET is_print = '1' WHERE id_design_price = '" + id_design_pricex + "' "
            execute_non_query(query_active, True, "", "", "", "")

            view_product_price(id_designx)
        End If

        Cursor = Cursors.Default
    End Sub


    Private Sub SMViewDel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SMViewDel.Click
        Cursor = Cursors.WaitCursor
        If GVProductPrice.RowCount > 0 Then
            Dim id_pp As String = myCoalesce(GVProductPrice.GetFocusedRowCellValue("id_fg_propose_price").ToString, "-1")
            If id_pp <> "-1" Then
                Dim showpopup As ClassShowPopUp = New ClassShowPopUp()
                showpopup.report_mark_type = "70"
                showpopup.id_report = id_pp
                showpopup.show()
            Else
                stopCustom("Propose price not found!")
            End If
        End If
        Cursor = Cursors.Default
    End Sub

    Private Sub GVProductPrice_PopupMenuShowing(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Grid.PopupMenuShowingEventArgs) Handles GVProductPrice.PopupMenuShowing
        If GVProductPrice.RowCount > 0 Then
            Dim view As DevExpress.XtraGrid.Views.Grid.GridView = CType(sender, DevExpress.XtraGrid.Views.Grid.GridView)
            Dim hitInfo As DevExpress.XtraGrid.Views.Grid.ViewInfo.GridHitInfo = view.CalcHitInfo(e.Point)
            If hitInfo.InRow Then
                view.FocusedRowHandle = hitInfo.RowHandle
                ViewMenu.Show(view.GridControl, e.Point)
            End If
        End If
    End Sub

    Private Sub DERetDate_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles DERetDate.Validating
        EP_DE_cant_blank(EPMasterDesign, DERetDate)
    End Sub

    Private Sub LESeason_EditValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LESeason.EditValueChanged
        Dim id_s As String = "-1"
        Try
            id_s = LESeason.EditValue.ToString
        Catch ex As Exception
        End Try
        viewDelivery(id_s)
    End Sub

    Private Sub GCProductPrice_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GCProductPrice.Click

    End Sub

    Private Sub SimpleButton3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Cursor = Cursors.WaitCursor
        FormMasterProductDet.form_name = Name
        FormMasterProductDet.id_product = "-1"
        FormMasterProductDet.id_design = id_design
        FormMasterProductDet.ShowDialog()
        Cursor = Cursors.Default
    End Sub

    Private Sub SimpleButton2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnDelSize.Click
        Cursor = Cursors.WaitCursor
        Dim id_product As String = GVProduct.GetFocusedRowCellDisplayText("id_product").ToString
        Dim query_cek As String = "SELECT COUNT(*) FROM tb_prod_demand_product pd_prod  "
        query_cek += "INNER JOIN tb_prod_demand_design pd_dsg ON pd_dsg.id_prod_demand_design = pd_prod.id_prod_demand_design AND pd_prod.id_product='" + id_product + "' "
        query_cek += "INNER JOIN tb_prod_demand pd ON pd.id_prod_demand = pd_dsg.id_prod_demand "
        query_cek += "WHERE pd.is_pd='1' "
        Dim jum_cek As String = execute_query(query_cek, 0, True, "", "", "", "")
        If jum_cek <= 0 Then
            Dim confirm As DialogResult = DevExpress.XtraEditors.XtraMessageBox.Show("Are you sure want to delete this data?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
            Dim query As String = ""
            If confirm = Windows.Forms.DialogResult.Yes Then
                Try
                    query = String.Format("DELETE FROM tb_m_product WHERE id_product='{0}'", id_product)
                    execute_non_query(query, True, "", "", "", "")
                    view_product(id_design)
                    If form_name = "-1" Then
                        FormMasterProduct.view_design()
                        FormMasterProduct.GVDesign.FocusedRowHandle = find_row(FormMasterProduct.GVDesign, "id_design", id_design)
                    ElseIf form_name = "FormFGLineList" Then
                        FormFGLineList.viewLineList()
                        FormFGLineList.BGVLineList.FocusedRowHandle = find_row(FormFGLineList.BGVLineList, "id_design", id_design)
                        loadLineList(id_prod_demand_design_active)
                    End If
                Catch ex As Exception
                    errorDelete()
                End Try
            End If
        Else
            stopCustom("Data currently used in Production Demand.")
        End If
        Cursor = Cursors.Default
    End Sub

    Sub view_product(ByVal id_design As String)
        Try
            Dim query As String = "CALL view_product_master('" & id_design & "')"
            Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
            GCProduct.DataSource = data
            check_but_size()
        Catch ex As Exception
            errorConnection()
        End Try
    End Sub

    Sub check_menu()
        'product
        If GVProduct.RowCount < 1 Then
            'hide all except new
            BtnDelSize.Enabled = False
        Else
            'show all
            BtnDelSize.Enabled = True
        End If
    End Sub

    Sub check_but_size()
        Dim id_size As String = "-1"
        Try
            id_size = GVProduct.GetFocusedRowCellValue("id_product").ToString
        Catch ex As Exception
        End Try


        If id_size <> "-1" And GVProduct.RowCount > 0 Then
            BtnDelSize.Enabled = True
        Else
            BtnDelSize.Enabled = False
        End If
    End Sub

    Private Sub GVProduct_ColumnFilterChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GVProduct.ColumnFilterChanged
        Cursor = Cursors.WaitCursor
        check_but_size()
        Cursor = Cursors.Default
    End Sub


    Private Sub GVProduct_FocusedRowChanged(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles GVProduct.FocusedRowChanged
        Cursor = Cursors.WaitCursor
        check_but_size()
        Cursor = Cursors.Default
    End Sub

    Private Sub BtnEditSize_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        editSize()
    End Sub

    Sub editSize()

    End Sub

    Private Sub SimpleButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        MsgBox(del_date_.ToString)
        MsgBox(ret_date_.ToString)
        MsgBox(DateDiff(DateInterval.Month, del_date_, ret_date_).ToString)
    End Sub

    Private Sub TECodeImport_EditValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TECodeImport.EditValueChanged

    End Sub

    Private Sub LabelControl10_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LabelControl10.Click

    End Sub

    Private Sub PictureEdit1_EditValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureEdit1.EditValueChanged
        'If PictureEdit1.EditValue Is Nothing Then
        '    BViewImage.Visible = False
        'Else
        '    BViewImage.Visible = True
        'End If
    End Sub

    Private Sub SLEDel_EditValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SLEDel.EditValueChanged
        Dim del_date As String = ""
        del_date_ = Nothing
        Try
            del_date = SLEDel.Properties.View.GetFocusedRowCellDisplayText("delivery_date").ToString
            del_date_ = SLEDel.Properties.View.GetFocusedRowCellDisplayText("delivery_date").ToString
        Catch ex As Exception
        End Try
        TxtDelDate.EditValue = del_date
        lifetime()
        Try
            DEWHDate.EditValue = SLEDel.Properties.View.GetFocusedRowCellValue("est_wh_date")
        Catch ex As Exception
            DEWHDate.EditValue = Nothing
        End Try
    End Sub

    Private Sub LERetCode_EditValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LERetCode.EditValueChanged
        Dim value As Object = Nothing
        Try
            Dim editor As DevExpress.XtraEditors.LookUpEdit = CType(sender, DevExpress.XtraEditors.LookUpEdit)
            Dim row As DataRowView = CType(editor.Properties.GetDataSourceRowByKeyValue(editor.EditValue), DataRowView)
            value = row("ret_date")
            ret_date_ = value
        Catch ex As Exception
            ret_date_ = Nothing
        End Try
        DERetDate.EditValue = value
        lifetime()
    End Sub

    Sub lifetime()
        Dim lf As Decimal = 0.0
        Try
            lf = DateDiff(DateInterval.Month, del_date_, ret_date_).ToString
        Catch ex As Exception
        End Try

        If del_date_ = Nothing Or ret_date_ = Nothing Then
            lf = -1
        End If

        If lf < 0 Then
            lf = 0
        End If
        TELifetime.EditValue = lf
    End Sub

    Private Sub DERetDate_EditValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DERetDate.EditValueChanged
        Try
            ret_date_ = DERetDate.EditValue
        Catch ex As Exception
            ret_date_ = Nothing
        End Try
        lifetime()
    End Sub


    Private Sub GVProduct_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GVProduct.DoubleClick
        editSize()
    End Sub

    Private Sub TxtDelDate_EditValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtDelDate.EditValueChanged
        Dim del_date As String = ""
        del_date_ = Nothing
        Try
            del_date_ = TxtDelDate.EditValue
        Catch ex As Exception
        End Try
        lifetime()
    End Sub

    Private Sub BtnAddSeaason_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnAddSeaason.Click
        Cursor = Cursors.WaitCursor
        Try
            FormSeason.Close()
            FormSeason.Dispose()
        Catch ex As Exception
        End Try
        FormSeason.quick_edit = "1"
        FormSeason.id_pop_up = "1"
        If id_pop_up = "3" Then
            FormSeason.is_md = "2"
        Else
            FormSeason.is_md = "1"
        End If
        FormSeason.ShowDialog()
        Cursor = Cursors.Default
    End Sub

    Private Sub BtnAddRetCode_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnAddRetCode.Click
        Cursor = Cursors.WaitCursor
        FormMasterRetCode.is_single = True
        FormMasterRetCode.ShowDialog()
        Cursor = Cursors.Default
    End Sub

    Private Sub TxtDelDate_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TxtDelDate.Validating
        EP_DE_cant_blank(EPMasterDesign, TxtDelDate)
    End Sub

    Private Sub SimpleButton2_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnGetLastCount.Click
        Cursor = Cursors.WaitCursor
        Dim id_fg_code_count As String = ""
        Dim digit_par As String = "1"
        If id_pop_up = "3" Then 'non md
            id_fg_code_count = get_setup_field("id_code_fg_non_md_counting")
            digit_par = "4"
        Else
            id_fg_code_count = get_setup_field("id_code_fg_counting")
            digit_par = "3"
        End If

        For i As Integer = 0 To GVCode.RowCount - 1
            If GVCode.GetRowCellValue(i, "code").ToString = id_fg_code_count Then
                Dim counting_x As String = getLastCounting(digit_par)
                Dim data_filter As DataRow() = counting_det.Select("[display_name]='" + counting_x + "'")
                GVCode.SetRowCellValue(i, "value", data_filter(0)("id_code_detail"))
                Exit For
            End If
        Next
        Cursor = Cursors.Default
    End Sub

    Private Sub BtnTemplateSize_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnTemplateSize.Click
        Cursor = Cursors.WaitCursor
        FormMasterProductMulti.id_popup = "1"
        FormMasterProductMulti.ShowDialog()
        Cursor = Cursors.Default
    End Sub

    Private Sub LETemplateDsg_EditValueChanged(sender As Object, e As EventArgs) Handles LETemplateDsg.EditValueChanged
        load_template_dsg(LETemplateDsg.EditValue)
    End Sub

    Private Sub GVCodeDsg_CellValueChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles GVCodeDsg.CellValueChanged
        If e.Column.Name.ToString <> "ColCodeParam" Then
            Exit Sub
        Else
            Dim cellValue As String = e.Value.ToString()

            Dim query As String = String.Format("SELECT id_code,id_code_detail,CODE as Code,code_detail_name as Name,display_name as 'Printed Name',CONCAT(CODE,' - ',code_detail_name) AS value FROM tb_m_code_detail WHERE id_code='" & cellValue.ToString & "'")
            Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
            GVCodeDsg.SetRowCellValue(e.RowHandle, GVCodeDsg.Columns("value"), data.Rows(0)("id_code").ToString)
        End If
    End Sub

    Private Sub GVCodeDsg_HiddenEditor(sender As Object, e As EventArgs) Handles GVCodeDsg.HiddenEditor
        If clone_dsg IsNot Nothing Then
            clone_dsg.Dispose()
            clone_dsg = Nothing
        End If
    End Sub

    Private clone_dsg As DataView = Nothing
    Private Sub GVCodeDsg_ShownEditor(sender As Object, e As EventArgs) Handles GVCodeDsg.ShownEditor
        Dim view As DevExpress.XtraGrid.Views.Grid.GridView = CType(sender, DevExpress.XtraGrid.Views.Grid.GridView)
        If view.FocusedColumn.FieldName = "value" AndAlso TypeOf view.ActiveEditor Is DevExpress.XtraEditors.SearchLookUpEdit Then
            Dim edit As DevExpress.XtraEditors.SearchLookUpEdit
            Dim table As DataTable
            Dim row As DataRow

            edit = CType(view.ActiveEditor, DevExpress.XtraEditors.SearchLookUpEdit)
            Try
                table = CType(edit.Properties.DataSource, DataTable)
            Catch ex As Exception
                table = CType(edit.Properties.DataSource, DataView).Table
            End Try
            clone_dsg = New DataView(table)

            row = view.GetDataRow(view.FocusedRowHandle)
            clone_dsg.RowFilter = "[id_code] = " + row("code").ToString()
            edit.Properties.DataSource = clone_dsg
        End If
    End Sub

    Private Sub SimpleButton2_Click_2(sender As Object, e As EventArgs) Handles BRefreshCodeDsg.Click
        load_isi_param("2")
        load_template_dsg(LETemplateDsg.EditValue)
    End Sub

    Private Sub SimpleButton3_Click_1(sender As Object, e As EventArgs) Handles BeditCodeDsg.Click
        FormCodeTemplateEdit.id_pop_up = "6"
        FormCodeTemplateEdit.id_template_code = LETemplateDsg.EditValue.ToString
        FormCodeTemplateEdit.ShowDialog()
    End Sub

    Private Sub BGenerateDesc_Click(sender As Object, e As EventArgs) Handles BGenerateDesc.Click
        'display name
        Dim id_code, code, query As String
        Dim string_name As String = ""
        Dim class_name As String = ""
        Dim promo_name As String = ""

        For i As Integer = 0 To GVCodeDsg.RowCount - 1
            code = ""
            id_code = ""
            Try
                id_code = GVCodeDsg.GetRowCellValue(i, "value").ToString
            Catch ex As Exception
                id_code = ""
            End Try

            If Not id_code = "" Or id_code = "0" Then
                query = String.Format("SELECT tb_m_code.is_include_name FROM tb_m_code,tb_m_code_detail WHERE tb_m_code.id_code=tb_m_code_detail.id_code AND tb_m_code_detail.id_code_detail='" & id_code & "'")
                code = execute_query(query, 0, True, "", "", "", "")
                If code.ToString = "True" Then
                    query = String.Format("SELECT m_c.id_code, m_c_d.display_name,m_c.code_name FROM tb_m_code_detail m_c_d INNER JOIN tb_m_code m_c ON m_c.id_code=m_c_d.id_code WHERE m_c_d.id_code_detail='" & id_code & "'")
                    Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
                    code = data.Rows(0)("display_name").ToString
                    If data.Rows(0)("id_code").ToString = get_setup_field("id_code_fg_class") Then
                        class_name = code
                    ElseIf data.Rows(0)("id_code").ToString = get_setup_field("id_code_fg_prod_non_md") Then
                        promo_name = code
                    Else
                        string_name += " " & code
                    End If
                End If
            End If
        Next

        Dim full_desc As String = ""
        If id_pop_up = "3" Then 'non merch
            full_desc = promo_name & " " & class_name & " " & TEName.Text.ToUpper & string_name.ToUpper
        Else
            full_desc = class_name & " " & TEName.Text.ToUpper.TrimStart(" ").TrimEnd(" ") & string_name.ToUpper
        End If

        If full_desc.Length > 25 Then
            TEDisplayName.Text = full_desc.Substring(0, 25)
        Else
            TEDisplayName.Text = full_desc
        End If
    End Sub

    Private Sub BtnAddSeasonOrign_Click(sender As Object, e As EventArgs) Handles BtnAddSeasonOrign.Click
        Cursor = Cursors.WaitCursor
        Try
            FormSeason.Close()
            FormSeason.Dispose()
        Catch ex As Exception
        End Try
        FormSeason.quick_edit = "1"
        FormSeason.id_pop_up = "2"
        FormSeason.ShowDialog()
        Cursor = Cursors.Default
    End Sub

    Private Sub LETemplateNonMD_EditValueChanged(sender As Object, e As EventArgs) Handles LETemplateNonMD.EditValueChanged
        load_template_non_md(LETemplateNonMD.EditValue)
    End Sub

    Private Sub BRefreshCodeNonMD_Click(sender As Object, e As EventArgs) Handles BRefreshCodeNonMD.Click
        load_isi_param("3")
        load_template_non_md(LETemplateNonMD.EditValue)
    End Sub

    Private Sub BeditCodeNonMD_Click(sender As Object, e As EventArgs) Handles BeditCodeNonMD.Click
        FormCodeTemplateEdit.id_pop_up = "7"
        FormCodeTemplateEdit.id_template_code = LETemplateNonMD.EditValue.ToString
        FormCodeTemplateEdit.ShowDialog()
    End Sub

    Private Sub GVCodeNonMD_CellValueChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles GVCodeNonMD.CellValueChanged
        If e.Column.Name.ToString <> "ColCodeParam" Then
            Exit Sub
        Else
            Dim cellValue As String = e.Value.ToString()

            Dim query As String = String.Format("SELECT id_code,id_code_detail,CODE as Code,code_detail_name as Name,display_name as 'Printed Name',CONCAT(CODE,' - ',code_detail_name) AS value FROM tb_m_code_detail WHERE id_code='" & cellValue.ToString & "'")
            Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
            GVCodeNonMD.SetRowCellValue(e.RowHandle, GVCodeNonMD.Columns("value"), data.Rows(0)("id_code").ToString)
        End If
    End Sub

    Private Sub GVCodeNonMD_HiddenEditor(sender As Object, e As EventArgs) Handles GVCodeNonMD.HiddenEditor
        If clone_non_md IsNot Nothing Then
            clone_non_md.Dispose()
            clone_non_md = Nothing
        End If
    End Sub

    Private clone_non_md As DataView = Nothing
    Private Sub GVCodeNonMD_ShownEditor(sender As Object, e As EventArgs) Handles GVCodeNonMD.ShownEditor
        Dim view As DevExpress.XtraGrid.Views.Grid.GridView = CType(sender, DevExpress.XtraGrid.Views.Grid.GridView)
        If view.FocusedColumn.FieldName = "value" AndAlso TypeOf view.ActiveEditor Is DevExpress.XtraEditors.SearchLookUpEdit Then
            Dim edit As DevExpress.XtraEditors.SearchLookUpEdit
            Dim table As DataTable
            Dim row As DataRow

            edit = CType(view.ActiveEditor, DevExpress.XtraEditors.SearchLookUpEdit)
            Try
                table = CType(edit.Properties.DataSource, DataTable)
            Catch ex As Exception
                table = CType(edit.Properties.DataSource, DataView).Table
            End Try
            clone_non_md = New DataView(table)

            row = view.GetDataRow(view.FocusedRowHandle)
            clone_non_md.RowFilter = "[id_code] = " + row("code").ToString()
            edit.Properties.DataSource = clone_non_md
        End If
    End Sub

    Private Sub BtnGetLastCountNonMD_Click(sender As Object, e As EventArgs) Handles BtnGetLastCountNonMD.Click
        Cursor = Cursors.WaitCursor
        Dim id_fg_code_count As String = ""
        Dim digit_par As String = "1"
        id_fg_code_count = get_setup_field("id_code_fg_non_md_counting")
        digit_par = "4"

        For i As Integer = 0 To GVCodeNonMD.RowCount - 1
            If GVCodeNonMD.GetRowCellValue(i, "code").ToString = id_fg_code_count Then
                Dim counting_x As String = getLastCounting(digit_par)
                Dim data_filter As DataRow() = counting_det.Select("[display_name]='" + counting_x + "'")
                GVCodeNonMD.SetRowCellValue(i, "value", data_filter(0)("id_code_detail"))
                Exit For
            End If
        Next
        Cursor = Cursors.Default
    End Sub

    Private Sub BGenerateNonMD_Click(sender As Object, e As EventArgs) Handles BGenerateNonMD.Click
        Dim id_code, code, code_name, query As String
        Dim code_full As String = ""
        'display name
        Dim string_name As String = ""
        Dim class_name As String = ""
        Dim promo_name As String = ""


        For i As Integer = 0 To GVCodeNonMD.RowCount - 1
            code = ""
            code_name = ""
            id_code = ""
            Try
                id_code = GVCodeNonMD.GetRowCellValue(i, "value").ToString
            Catch ex As Exception
                id_code = ""
            End Try

            If Not id_code = "" Or id_code = "0" Then
                Try
                    query = String.Format("Select is_include_code FROM tb_m_code,tb_m_code_detail WHERE tb_m_code.id_code=tb_m_code_detail.id_code And tb_m_code_detail.id_code_detail='" & id_code & "'")
                    code = execute_query(query, 0, True, "", "", "", "")
                Catch ex As Exception
                    code = "False"
                End Try

                If code = "True" Then
                    query = String.Format("SELECT id_code,code,display_name FROM tb_m_code_detail WHERE id_code_detail='" & id_code & "'")
                    Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
                    code = data.Rows(0)("code").ToString
                Else
                    code = ""
                End If

                query = String.Format("SELECT tb_m_code.is_include_name FROM tb_m_code,tb_m_code_detail WHERE tb_m_code.id_code=tb_m_code_detail.id_code AND tb_m_code_detail.id_code_detail='" & id_code & "'")
                code_name = execute_query(query, 0, True, "", "", "", "")
                If code_name.ToString = "True" Then
                    query = String.Format("SELECT m_c.id_code, m_c_d.display_name,m_c.code_name FROM tb_m_code_detail m_c_d INNER JOIN tb_m_code m_c ON m_c.id_code=m_c_d.id_code WHERE m_c_d.id_code_detail='" & id_code & "'")
                    Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
                    code_name = data.Rows(0)("display_name").ToString
                    If data.Rows(0)("id_code").ToString = get_setup_field("id_code_fg_class") Then
                        class_name = code_name
                    ElseIf data.Rows(0)("id_code").ToString = get_setup_field("id_code_fg_prod_non_md") Then
                        promo_name = code_name
                    Else
                        string_name += " " & code_name
                    End If
                End If
            End If
            code_full += code
        Next

        'code
        TECodeNonMD.Text = code_full

        'desc
        Dim full_desc As String = ""
        full_desc = promo_name & " " & class_name & " " & TEName.Text.ToUpper.TrimStart(" ").TrimEnd(" ") & string_name.ToUpper

        If full_desc.Length > 25 Then
            TEDisplayNameNonMD.Text = full_desc.Substring(0, 25)
        Else
            TEDisplayNameNonMD.Text = full_desc
        End If
    End Sub

    Private Sub TECodeNonMD_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles TECodeNonMD.Validating
        If id_pop_up = "3" Then 'only for codefication
            EP_TE_cant_blank(EPMasterDesign, TECodeNonMD)
            EPMasterDesign.SetIconPadding(TECodeNonMD, 400)
        End If
    End Sub

    Private Sub TEDisplayNameNonMD_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles TEDisplayNameNonMD.Validating
        If id_pop_up = "3" Then 'only for codefication
            EP_TE_cant_blank(EPMasterDesign, TEDisplayNameNonMD)
        End If
    End Sub
End Class