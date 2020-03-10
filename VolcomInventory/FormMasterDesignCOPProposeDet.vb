Public Class FormMasterDesignCOPProposeDet
    Public id_comp As String = "-1"
    Public id_comp_contact As String = "-1"
    Public id_det As String = "-1"
    Public is_view As String = "2"

    Private Sub FormMasterDesignCOPProposeDet_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'check kurs first
        Dim query_kurs As String = "SELECT * FROM tb_kurs_trans WHERE DATE(DATE_ADD(created_date, INTERVAL 6 DAY)) >= DATE(NOW()) ORDER BY id_kurs_trans DESC LIMIT 1"
        Dim data_kurs As DataTable = execute_query(query_kurs, -1, True, "", "", "", "")

        If Not data_kurs.Rows.Count > 0 Then
            warningCustom("Get kurs error.")
            TETodayKurs.EditValue = 0.00
        Else
            TETodayKurs.EditValue = data_kurs.Rows(0)("kurs_trans") + data_kurs.Rows(0)("fixed_floating")
        End If
        '
        viewSeason()
        view_currency_grid()
        '
        load_det_input()
        '
        If is_view = "1" Then
            TEVendor.Text = FormMasterDesignCOPPropose.BGVItemList.GetFocusedRowCellValue("comp_number").ToString
            TEVendorName.Text = FormMasterDesignCOPPropose.BGVItemList.GetFocusedRowCellValue("comp_name").ToString
            '
            TEVendor.Properties.ReadOnly = True
            BtnBrowseContactFrom.Visible = False
            '
            calculate()
            '
            LTodayKurs.Visible = False
            TETodayKurs.Visible = False
            '
            PCSeason.Visible = False
            GCItemList.Visible = False
            PCComponent.Dock = DockStyle.Fill
            '
            BAdd.Visible = False
            BDelete.Visible = False
            GVCOPComponent.OptionsBehavior.ReadOnly = True
            BtnSave.Visible = False
        End If
    End Sub

    Sub add_row()
        Dim newRow As DataRow = (TryCast(GCCOPComponent.DataSource, DataTable)).NewRow()
        newRow("description") = ""
        newRow("id_currency") = 1
        newRow("kurs") = TETodayKurs.EditValue
        newRow("before_kurs") = 0.00
        newRow("additional") = 0.00

        TryCast(GCCOPComponent.DataSource, DataTable).Rows.Add(newRow)
        GCCOPComponent.RefreshDataSource()
        show_but()
    End Sub

    Sub show_but()
        If GVCOPComponent.RowCount > 0 Then
            BDelete.Visible = True
        Else
            BDelete.Visible = False
        End If
    End Sub

    Sub calculate()
        GVCOPComponent.RefreshData()
        GCCOPComponent.Refresh()
        '
        TEEcop.EditValue = GVCOPComponent.Columns("sub_tot").SummaryItem.SummaryValue
        TEAdditionalCost.EditValue = GVCOPComponent.Columns("additional").SummaryItem.SummaryValue
    End Sub

    Sub load_det_input()
        Try
            Dim query As String = "SELECT description,id_currency," & decimalSQL(TETodayKurs.EditValue.ToString) & " AS kurs,before_kurs,additional FROM tb_design_cop_propose_comp WHERE id_design_cop_propose_det='" & id_det & "'"
            Dim dt As DataTable = execute_query(query, -1, True, "", "", "", "")
            GCCOPComponent.DataSource = dt
            GVCOPComponent.BestFitColumns()
            show_but()
        Catch ex As Exception
            Console.WriteLine(ex.ToString)
        End Try

    End Sub

    Private Sub view_currency_grid()
        Try
            Dim query As String = "SELECT id_currency,currency FROM tb_lookup_currency WHERE is_active_cop='1'"
            viewSearchLookupRepositoryQuery(RISLEComp, query, 0, "currency", "id_currency")
        Catch ex As Exception
        End Try
    End Sub
    Sub load_det(ByVal opt As String)
        Dim query_where As String = ""
        '
        If opt = "code" Then
            If Not SLESeasonByCode.EditValue.ToString = "-1" Then
                query_where += " AND RIGHT(f1.design_code,2)='" & SLESeasonByCode.EditValue.ToString & "'"
            End If

            Try
                Dim query As String = "CALL view_all_design_param(""" + query_where + """)"
                Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
                GCItemList.DataSource = data
                BGVItemList.BestFitColumns()
            Catch ex As Exception
                errorConnection()
            End Try
        ElseIf opt = "season" Then
            If Not SLESeason.EditValue.ToString = "-1" Then
                query_where += " AND season.id_season='" & SLESeason.EditValue.ToString & "'"
            End If

            Try
                Dim query As String = "CALL view_all_design_param(""" + query_where + """)"
                Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
                GCItemList.DataSource = data
                BGVItemList.BestFitColumns()
            Catch ex As Exception
                errorConnection()
            End Try
        End If
    End Sub

    Sub viewSeason()
        Dim query As String = "SELECT '-1' AS id_season, 'All Season' AS season,'-1' AS `range` UNION
                                (SELECT a.id_season,a.season,b.range AS `range` FROM tb_season a 
                                INNER JOIN tb_range b ON a.id_range = b.id_range 
                                ORDER BY b.range ASC)"
        viewSearchLookupQuery(SLESeason, query, "id_season", "season", "id_season")
        viewSearchLookupQuery(SLESeasonByCode, query, "range", "season", "range")
    End Sub

    Private Sub view_currency(ByVal lookup As DevExpress.XtraEditors.LookUpEdit)
        Dim query As String = "SELECT id_currency,currency FROM tb_lookup_currency"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")

        lookup.Properties.DataSource = data

        lookup.Properties.DisplayMember = "currency"
        lookup.Properties.ValueMember = "id_currency"
        lookup.ItemIndex = 0
    End Sub

    Private Sub BSearchByCode_Click(sender As Object, e As EventArgs) Handles BSearchByCode.Click
        load_det("code")
    End Sub

    Private Sub BGVItemList_RowCellStyle(sender As Object, e As DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs) Handles BGVItemList.RowCellStyle
        Try
            If BGVItemList.GetRowCellValue(e.RowHandle, "id_lookup_status_order").ToString = "2" Then
                e.Appearance.BackColor = Color.Salmon
                e.Appearance.ForeColor = Color.Red
                e.Appearance.FontStyleDelta = FontStyle.Bold
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub BtnCancel_Click(sender As Object, e As EventArgs) Handles BtnCancel.Click
        Close()
    End Sub

    Private Sub FormMasterDesignCOPProposeDet_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub BSearch_Click(sender As Object, e As EventArgs) Handles BSearch.Click
        load_det("season")
    End Sub

    Private Sub TEVendor_KeyDown(sender As Object, e As KeyEventArgs) Handles TEVendor.KeyDown
        If e.KeyCode = Keys.Enter Then
            Dim query As String = "select cc.id_comp_contact,cc.id_comp,c.npwp,c.comp_number,c.comp_name,c.comp_commission,c.address_primary,c.id_so_type "
            query += " From tb_m_comp_contact cc "
            query += " inner join tb_m_comp c On c.id_comp=cc.id_comp"
            query += " where cc.is_default=1 and (c.id_comp_cat='1' OR c.id_comp_cat='8') AND c.comp_number='" + TEVendor.Text + "'"
            Dim data As DataTable = execute_query(query, "-1", True, "", "", "", "")

            If data.Rows.Count <= 0 Then
                stopCustom("Store not found.")
                TEVendor.Focus()
            ElseIf data.Rows.Count > 1 Then
                FormPopUpContact.id_pop_up = "88"
                FormPopUpContact.id_cat = 1
                FormPopUpContact.GVCompany.ActiveFilterString = "[comp_number]='" + TEVendor.Text + "'"
                FormPopUpContact.ShowDialog()
            Else
                id_comp = data.Rows(0)("id_comp").ToString
                id_comp_contact = data.Rows(0)("id_comp_contact").ToString
                TEVendorName.Text = data.Rows(0)("comp_name").ToString
                TEVendor.Text = data.Rows(0)("comp_number").ToString
                '
                'LECurrency.Focus()
            End If
        End If
    End Sub

    Private Sub TEKurs_KeyDown(sender As Object, e As KeyEventArgs)
        If e.KeyCode = Keys.Enter Then
            TEEcop.Focus()
        End If
    End Sub

    Private Sub BtnSave_Click(sender As Object, e As EventArgs) Handles BtnSave.Click
        calculate()

        If Not BGVItemList.RowCount > 0 Then
            warningCustom("Please choose the design first")
            'ElseIf id_comp_contact = "-1" Then
            '    warningCustom("Please fill the vendor")
        ElseIf TEEcop.EditValue = 0 Then
            warningCustom("Please put the cost")
        ElseIf TETodayKurs.EditValue = 0 Then
            warningCustom("Today transaction kurs still not submitted, please contact accounting.")
        Else
            Dim check As Boolean = False
            For i As Integer = 0 To FormMasterDesignCOPPropose.BGVItemList.RowCount - 1
                If FormMasterDesignCOPPropose.BGVItemList.GetRowCellValue(i, "id_design").ToString = BGVItemList.GetFocusedRowCellValue("id_design").ToString Then
                    check = True
                    Exit For
                End If
            Next

            If check = False Then
                Dim query_pd As String = "SELECT pdd.`id_prod_demand`,pd.`id_report_status`,pdd.`id_design` FROM tb_prod_demand_design pdd
INNER JOIN tb_prod_demand pd ON pd.`id_prod_demand`=pdd.`id_prod_demand`
WHERE pd.`id_report_status` != '5' AND pdd.`id_design`='" & BGVItemList.GetFocusedRowCellValue("id_design").ToString & "' AND pd.is_pd='1'"
                Dim data_pd As DataTable = execute_query(query_pd, -1, True, "", "", "", "")

                If FormMasterDesignCOPPropose.LECOPType.EditValue.ToString = "1" And data_pd.Rows.Count <= 0 Then
                    warningCustom("This design dont have PD created, please change the cost normally.")
                Else
                    Dim check_rec_qc As String = "SELECT prod_det.id_prod_order_det,SUM(prod_rec_d.prod_order_rec_det_qty) AS receive_created_qty
                FROM tb_prod_order_rec_det prod_rec_d
                INNER JOIN tb_prod_order_det prod_det ON prod_det.id_prod_order_det=prod_rec_d.id_prod_order_det
                INNER JOIN tb_prod_order_rec prod_rec ON prod_rec_d.id_prod_order_rec=prod_rec.id_prod_order_rec
                INNER JOIN tb_prod_demand_product pd_prod ON prod_det.id_prod_demand_product=pd_prod.id_prod_demand_product
                INNER JOIN tb_prod_demand_design pd_desg ON pd_desg.id_prod_demand_design=pd_prod.id_prod_demand_design
                WHERE pd_desg.id_design='" & BGVItemList.GetFocusedRowCellValue("id_design").ToString & "' AND prod_rec.id_report_status=6 GROUP BY prod_rec_d.id_prod_order_det"
                    Dim data_rec_qc As DataTable = execute_query(check_rec_qc, -1, True, "", "", "", "")

                    If data_rec_qc.Rows.Count > 0 Then
                        warningCustom("This design already received at QC. Please cancel receive QC first before adjusting COP PD.")
                    Else
                        'insert det
                        Dim id_propose As String = FormMasterDesignCOPPropose.id_propose
                        Dim target_cost As String = decimalSQL(BGVItemList.GetFocusedRowCellValue("target_cost").ToString)
                        Dim id_design As String = BGVItemList.GetFocusedRowCellValue("id_design").ToString
                        '
                        Dim id_cur_before As String = ""
                        Dim kurs_before As String = ""
                        Dim cop_before As String = ""
                        Dim id_contact_before As String = ""
                        Dim add_cost_before As String = ""
                        '
                        Dim id_cur_after As String = ""
                        Dim kurs_after As String = ""
                        Dim cop_after As String = ""
                        Dim id_contact_after As String = ""
                        Dim add_cost_after As String = ""

                        'before
                        If FormMasterDesignCOPPropose.LECOPType.EditValue.ToString = "1" Then
                            id_contact_before = "'" & BGVItemList.GetFocusedRowCellValue("prod_order_cop_pd_vendor").ToString & "'"
                            id_cur_before = "'" & BGVItemList.GetFocusedRowCellValue("prod_order_cop_pd_curr").ToString & "'"
                            kurs_before = "'" & decimalSQL(BGVItemList.GetFocusedRowCellValue("prod_order_cop_kurs_pd").ToString) & "'"
                            cop_before = "'" & decimalSQL(BGVItemList.GetFocusedRowCellValue("prod_order_cop_pd").ToString) & "'"
                            add_cost_before = "'" & decimalSQL(BGVItemList.GetFocusedRowCellValue("prod_order_cop_pd_addcost").ToString) & "'"
                        Else
                            id_contact_before = "NULL"
                            id_cur_before = "NULL"
                            kurs_before = "NULL"
                            cop_before = "NULL"
                            add_cost_before = "NULL"
                        End If

                        'after
                        Dim id_currency As String = "1"
                        For i = 0 To GVCOPComponent.RowCount - 1
                            If Not GVCOPComponent.GetRowCellValue(i, "id_currency").ToString = "1" Then
                                id_currency = GVCOPComponent.GetRowCellValue(i, "id_currency").ToString
                            End If
                        Next

                        id_cur_after = id_currency
                        kurs_after = decimalSQL(TETodayKurs.EditValue.ToString)
                        cop_after = decimalSQL(TEEcop.EditValue.ToString)

                        If Not id_comp_contact = "-1" Then
                            id_contact_after = "'" & id_comp_contact & "'"
                        Else
                            id_contact_after = "'0'"
                        End If
                        add_cost_after = decimalSQL(TEAdditionalCost.EditValue.ToString)

                        Dim query As String = ""
                        query = "INSERT INTO tb_design_cop_propose_det(id_design_cop_propose,target_cost,id_design,id_currency_before,kurs_before,design_cop_before,id_comp_contact_before,add_cost_before,id_currency,kurs,design_cop,id_comp_contact,add_cost) VALUES"
                        query += "('" & id_propose & "','" & target_cost & "','" & id_design & "'," & id_cur_before & "," & kurs_before & "," & cop_before & "," & id_contact_before & "," & add_cost_before & ",'" & id_cur_after & "','" & kurs_after & "','" & cop_after & "', " & id_contact_after & " ,'" & add_cost_after & "'); SELECT LAST_INSERT_ID(); "
                        id_det = execute_query(query, 0, True, "", "", "", "")

                        'insert component
                        query = "INSERT INTO tb_design_cop_propose_comp(`id_design_cop_propose_det`,`description`,`id_currency`,`kurs`,`before_kurs`,`additional`) VALUES"
                        For i = 0 To GVCOPComponent.RowCount - 1
                            If Not i = 0 Then
                                query += ","
                            End If
                            query += "('" & id_det & "','" & addSlashes(GVCOPComponent.GetRowCellValue(i, "description").ToString) & "','" & GVCOPComponent.GetRowCellValue(i, "id_currency").ToString & "','" & decimalSQL(TETodayKurs.EditValue.ToString) & "','" & decimalSQL(GVCOPComponent.GetRowCellValue(i, "before_kurs").ToString) & "','" & decimalSQL(GVCOPComponent.GetRowCellValue(i, "additional").ToString) & "')"
                        Next
                        execute_non_query(query, True, "", "", "", "")

                        FormMasterDesignCOPPropose.load_det()
                        FormMasterDesignCOPPropose.BGVItemList.BestFitColumns()
                        FormMasterDesignCOPPropose.check_but()
                        Close()
                    End If
                End If
            Else
                warningCustom("This design already listed")
            End If
        End If
    End Sub

    Private Sub BtnBrowseContactFrom_Click(sender As Object, e As EventArgs) Handles BtnBrowseContactFrom.Click
        FormPopUpContact.id_pop_up = "88"
        FormPopUpContact.id_cat = "1,8"
        FormPopUpContact.ShowDialog()
    End Sub

    Private Sub BDelete_Click(sender As Object, e As EventArgs) Handles BDelete.Click
        GVCOPComponent.DeleteSelectedRows()
        show_but()
    End Sub

    Private Sub BAdd_Click(sender As Object, e As EventArgs) Handles BAdd.Click
        add_row()
        show_but()
    End Sub

    Private Sub GVCOPComponent_CellValueChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles GVCOPComponent.CellValueChanged
        calculate()
    End Sub
End Class