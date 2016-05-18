Public Class FormBOM
    Dim bnew_active As String = "1"
    Dim bedit_active As String = "1"
    Dim bdel_active As String = "1"
    Dim bdupe_active As String = "1"

    Private Sub FormBOM_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        show_design()
        view_product()
        '
        viewSeason()
    End Sub
    'view season
    Sub viewSeason()
        Dim query As String = "SELECT * FROM tb_season a "
        query += "INNER JOIN tb_range b ON a.id_range = b.id_range "
        query += "WHERE b.id_range >0 "
        query += "ORDER BY b.range DESC"
        viewSearchLookupQuery(SLESeason, query, "id_season", "season", "id_season")
    End Sub

    Sub view_product()
        Try
            Dim query As String
            query = "CALL view_product()"
            Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
            GCProduct.DataSource = data
            If data.Rows.Count Then
                view_bom(GVProduct.GetFocusedRowCellDisplayText("id_product").ToString)
            End If
        Catch ex As Exception
            errorConnection()
        End Try
    End Sub

    Private Sub GVProduct_FocusedRowChanged(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles GVProduct.FocusedRowChanged
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

    Private Sub GVProduct_RowCellClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Grid.RowCellClickEventArgs) Handles GVProduct.RowCellClick
        view_bom(GVProduct.GetFocusedRowCellDisplayText("id_product").ToString)
    End Sub

    Sub view_bom(ByVal id_product As String)
        Try
            Dim query As String
            query = "SELECT tb_lookup_report_status.id_report_status,tb_lookup_report_status.report_status,tb_bom.id_bom,tb_bom.bom_name,tb_bom.bom_unit_price,DATE_FORMAT(tb_bom.bom_date_created,'%d %M %Y') as bom_date_created,tb_lookup_term_production.term_production,IF(tb_bom.is_default='1','yes','no') as is_default,tb_lookup_currency.currency,tb_lookup_currency.id_currency FROM tb_bom,tb_lookup_report_status,tb_lookup_term_production,tb_lookup_currency WHERE tb_lookup_report_status.id_report_status=tb_bom.id_report_status AND tb_bom.id_term_production=tb_lookup_term_production.id_term_production AND tb_lookup_currency.id_currency=tb_bom.id_currency AND tb_bom.id_product = '" & id_product & "'"
            Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")

            GCBOM.DataSource = data
            show_but()
            If Not data.Rows.Count < 1 Then
                view_bom_det(GVBOM.GetFocusedRowCellDisplayText("id_bom").ToString)
                view_bom_ovh(GVBOM.GetFocusedRowCellDisplayText("id_bom").ToString)
                view_bom_wip(GVBOM.GetFocusedRowCellDisplayText("id_bom").ToString)
            End If
        Catch ex As Exception
            errorConnection()
        End Try
    End Sub
    Sub show_but()
        If XTCBOMSelection.SelectedTabPageIndex = 1 Then
            If Not GVBOM.RowCount < 1 Then
                'show all
                bnew_active = "1"
                bedit_active = "1"
                bdel_active = "1"
                '
                bdupe_active = "1"
                BDefault.Visible = True
                '
            Else
                'hide all except add
                bnew_active = "1"
                bedit_active = "0"
                bdel_active = "0"
                '
                bdupe_active = "0"
                BDefault.Visible = False
            End If
        ElseIf XTCBOMSelection.SelectedTabPageIndex = 1 Then
            If Not GVDesign.RowCount < 1 Then
                'show all
                bnew_active = "1"
                bedit_active = "1"
                bdel_active = "0"
                '
                bdupe_active = "0"
                '
            Else
                'hide all except add
                bnew_active = "0"
                bedit_active = "0"
                bdel_active = "0"
                '
                bdupe_active = "0"

            End If
        End If
        checkFormAccess(Name)
        button_main(bnew_active, bedit_active, bdel_active)
        button_main_ext("3", bdupe_active)
    End Sub
    Sub view_bom_det(ByVal id_bom As String)
        Try
            Dim query As String
            query = "CALL view_bom_mat(" & id_bom & ")"

            Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
            GCBomDetMat.DataSource = data
            GVBomDetMat.ActiveFilterString = "[is_cost]=1"
        Catch ex As Exception
            errorConnection()
        End Try
    End Sub
    Sub view_bom_ovh(ByVal id_bomx As String)
        Try
            Dim query As String
            query = "CALL view_bom_ovh(" & id_bomx & ")"

            Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
            GCBomDetOvh.DataSource = data

        Catch ex As Exception
            errorConnection()
        End Try
    End Sub
    Sub view_bom_wip(ByVal id_bomx As String)
        Try
            Dim query As String
            query = "CALL view_bom_product(" & id_bomx & ")"

            Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
            GCBomDetWip.DataSource = data
        Catch ex As Exception
            errorConnection()
        End Try
    End Sub
    Private Sub FormBOM_Activated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Activated
        FormMain.show_rb(Name)
        show_but()
    End Sub

    Private Sub FormBOM_Deactivate(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Deactivate
        FormMain.hide_rb()
    End Sub

    Private Sub GVBOM_RowClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Grid.RowClickEventArgs) Handles GVBOM.RowClick
        view_bom_det(GVBOM.GetFocusedRowCellDisplayText("id_bom").ToString)
        view_bom_ovh(GVBOM.GetFocusedRowCellDisplayText("id_bom").ToString)
        view_bom_wip(GVBOM.GetFocusedRowCellDisplayText("id_bom").ToString)
    End Sub

    Private Sub BDefault_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BDefault.Click
        Dim confirm As DialogResult
        Dim query As String

        confirm = DevExpress.XtraEditors.XtraMessageBox.Show("Are you sure want to make this BOM as default for this product ?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)

        If confirm = Windows.Forms.DialogResult.Yes Then
            Cursor = Cursors.WaitCursor
            Try
                Dim id_bom As String = GVBOM.GetFocusedRowCellValue("id_bom").ToString
                query = String.Format("UPDATE tb_bom SET is_default='2' WHERE id_product = '{0}';UPDATE tb_bom SET is_default='1' WHERE id_bom = '{1}'", GVProduct.GetFocusedRowCellValue("id_product").ToString, id_bom)
                execute_non_query(query, True, "", "", "", "")
                view_bom(GVProduct.GetFocusedRowCellValue("id_product").ToString)
                GVBOM.FocusedRowHandle = find_row(GVBOM, "id_bom", id_bom)
                infoCustom("BOM updated.")
            Catch ex As Exception
                stopCustom(ex.ToString)
            End Try
            Cursor = Cursors.Default
        End If
    End Sub
    '============= PER PD ===============
    Sub show_design()
        Try
            Dim query As String = "CALL view_bom_design()"
            Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
            GCDesign.DataSource = data
            If data.Rows.Count > 0 Then
                GVDesign.ExpandAllGroups()
                GVDesign.FocusedRowHandle = 0
                show_bom(GVDesign.GetFocusedRowCellValue("id_prod_demand_design").ToString)
                GVDesign.ActiveFilterString = "[prod_demand_number] <> '-'"
            End If
            show_but()
        Catch ex As Exception
            errorConnection()
        End Try
    End Sub
    Sub show_bom(ByVal id_prod_demand_design As String)
        Try
            If id_prod_demand_design = "" Then
                id_prod_demand_design = "-1"
            End If
            Dim query As String
            query = "CALL view_bom_design_list(" & id_prod_demand_design & ",1)"
            Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
            GCBOMDesign.DataSource = data
            GVBOMDesign.ActiveFilterString = "[is_cost]=1"
            GVBOMDesign.ExpandAllGroups()
        Catch ex As Exception
            errorConnection()
        End Try
    End Sub

    Private Sub GVDesign_FocusedRowChanged(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles GVDesign.FocusedRowChanged
        If GVDesign.RowCount > 0 Then
            If Not GVDesign.IsGroupRow(GVDesign.FocusedRowHandle) Then
                show_bom(GVDesign.GetFocusedRowCellValue("id_prod_demand_design").ToString)
            End If
        End If
    End Sub

    Private Sub XTCBOMSelection_SelectedPageChanged(ByVal sender As System.Object, ByVal e As DevExpress.XtraTab.TabPageChangedEventArgs) Handles XTCBOMSelection.SelectedPageChanged
        show_but()
    End Sub
    '========================================= per Design ===============================
    Sub view_design()
        Try
            Dim query As String = ""
            query = "CALL view_all_design_param(' AND f1.id_season=" + SLESeason.EditValue.ToString + " ')"
            Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
            GCPerDesign.DataSource = data
            GVPerDesign.ExpandAllGroups()

            If Not data.Rows.Count < 1 Then
                GVPerDesign.FocusedRowHandle = 0
                ' ganti ke show bom dari design itu
                show_bom_per_design(GVPerDesign.GetFocusedRowCellDisplayText("id_design").ToString)
            End If
        Catch ex As Exception
            errorConnection()
        End Try
    End Sub
    Sub show_bom_per_design(ByVal id_design As String)
        Dim query As String = ""
        query = "SELECT tb_lookup_report_status.id_report_status,tb_lookup_report_status.report_status,tb_bom.id_bom,tb_bom.bom_name,tb_bom.bom_unit_price,"
        query += " DATE_FORMAT(tb_bom.bom_date_created,'%d %M %Y') as bom_date_created, tb_bom.id_bom_approve,"
        query += " tb_lookup_term_production.term_production,"
        query += " If(tb_bom.is_default='1','yes','no') as is_default,tb_lookup_currency.currency,tb_lookup_currency.id_currency "
        query += " FROM tb_bom"
        query += " INNER JOIN tb_lookup_report_status On tb_lookup_report_status.id_report_status=tb_bom.id_report_status"
        query += " INNER JOIN tb_lookup_term_production ON tb_bom.id_term_production=tb_lookup_term_production.id_term_production "
        query += " INNER JOIN tb_lookup_currency On tb_lookup_currency.id_currency=tb_bom.id_currency"
        query += " INNER JOIN tb_m_product ON tb_m_product.id_product=tb_bom.id_product"
        query += " WHERE tb_m_product.id_design = '" + id_design + "' AND !ISNULL(tb_bom.id_bom_approve)"
        query += " group by tb_bom.id_bom_approve"
        'query = "CALL view_bom_per_desg('" & id_design & "')"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCBOMPerDesign.DataSource = data
        GVBOMPerDesign.BestFitColumns()
        view_list_bom_per_desg()
    End Sub


    Private Sub GVBOMPerDesign_FocusedRowChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles GVPerDesign.FocusedRowChanged
        If Not GVPerDesign.FocusedRowHandle < 0 Then
            show_bom_per_design(GVPerDesign.GetFocusedRowCellValue("id_design").ToString)
        End If
    End Sub

    Sub view_bom_per_desg(ByVal id_product As String)
        Try
            Dim query As String
            query = "SELECT tb_lookup_report_status.id_report_status,tb_lookup_report_status.report_status,tb_bom.id_bom,tb_bom.bom_name,tb_bom.bom_unit_price,DATE_FORMAT(tb_bom.bom_date_created,'%d %M %Y') as bom_date_created,tb_lookup_term_production.term_production,IF(tb_bom.is_default='1','yes','no') as is_default,tb_lookup_currency.currency,tb_lookup_currency.id_currency FROM tb_bom,tb_lookup_report_status,tb_lookup_term_production,tb_lookup_currency WHERE tb_lookup_report_status.id_report_status=tb_bom.id_report_status AND tb_bom.id_term_production=tb_lookup_term_production.id_term_production AND tb_lookup_currency.id_currency=tb_bom.id_currency AND tb_bom.id_product = '" & id_product & "'"
            Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")

            GCBOM.DataSource = data
            show_but()
            If Not data.Rows.Count < 1 Then
                view_bom_det(GVBOM.GetFocusedRowCellDisplayText("id_bom").ToString)
                view_bom_ovh(GVBOM.GetFocusedRowCellDisplayText("id_bom").ToString)
                view_bom_wip(GVBOM.GetFocusedRowCellDisplayText("id_bom").ToString)
            End If
        Catch ex As Exception
            errorConnection()
        End Try
    End Sub

    Private Sub BDefaultBOM_Click(sender As Object, e As EventArgs) Handles BDefaultBOM.Click
        Dim confirm As DialogResult
        Dim query As String

        confirm = DevExpress.XtraEditors.XtraMessageBox.Show("Are you sure want to make this BOM as default for this design ?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)

        If confirm = Windows.Forms.DialogResult.Yes Then
            Cursor = Cursors.WaitCursor
            Try
                Dim id_bom_approve As String = GVBOMPerDesign.GetFocusedRowCellValue("id_bom_approve").ToString
                Dim where_id_bom_app As String = ""
                If id_bom_approve = "" Then
                    where_id_bom_app = "ISNULL(tb_bom.id_bom_approve)"
                Else
                    where_id_bom_app = "tb_bom.id_bom_approve ='" + id_bom_approve + "'"
                End If
                query = String.Format("UPDATE tb_bom INNER JOIN tb_m_product prod ON prod.id_product=tb_bom.id_product SET tb_bom.is_default='2' WHERE prod.id_design = '{0}';UPDATE tb_bom INNER JOIN tb_m_product prod ON prod.id_product=tb_bom.id_product SET tb_bom.is_default='1' WHERE " + where_id_bom_app + " AND prod.id_design='{0}'", GVPerDesign.GetFocusedRowCellValue("id_design").ToString, id_bom_approve)
                execute_non_query(query, True, "", "", "", "")
                show_bom_per_design(GVPerDesign.GetFocusedRowCellValue("id_design").ToString)
                GVBOMPerDesign.FocusedRowHandle = find_row(GVBOMPerDesign, "id_bom_approve", id_bom_approve)
                infoCustom("BOM updated.")
            Catch ex As Exception
                stopCustom(ex.ToString)
            End Try
            Cursor = Cursors.Default
        End If
    End Sub

    Private Sub GVBOMPerDesign_FocusedRowChanged_1(sender As Object, e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles GVBOMPerDesign.FocusedRowChanged
        view_list_bom_per_desg()
    End Sub
    Sub view_list_bom_per_desg()
        If GVBOMPerDesign.RowCount > 0 Then
            Dim query As String = ""
            query = "CALL view_bom(" + GVBOMPerDesign.GetFocusedRowCellValue("id_bom").ToString + ")"
            Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
            GCCompPerDesign.DataSource = data
            GVCompPerDesign.ActiveFilterString = "[is_cost]=1"
            GVCompPerDesign.ExpandAllGroups()
        Else
            Dim query As String = ""
            query = "CALL view_bom(-1)"
            Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
            GCCompPerDesign.DataSource = data
            GVCompPerDesign.ActiveFilterString = "[is_cost]=1"
            GVCompPerDesign.ExpandAllGroups()
        End If
    End Sub

    Private Sub BImportExcel_Click(sender As Object, e As EventArgs) Handles BImportExcel.Click
        FormImportExcel.id_pop_up = "16"
        FormImportExcel.ShowDialog()
    End Sub

    Private Sub BtnView_Click(sender As Object, e As EventArgs) Handles BtnView.Click
        'perDesign
        view_design()
        GVPerDesign.BestFitColumns()
    End Sub

    Private Sub BPrint_Click(sender As Object, e As EventArgs) Handles BPrint.Click
        'print(GCPerDesign, "List Design " + SLESeason.Text)
        print_bom(GCPerDesign, "List Design " + SLESeason.Text)
    End Sub
    Sub print_bom(ByVal GridControlHere As DevExpress.XtraGrid.GridControl, ByVal title_here As String)
        'change BOM column

        '
        title_print = ""
        title_print = title_here
        Dim componentLink As New DevExpress.XtraPrinting.PrintableComponentLink(New DevExpress.XtraPrinting.PrintingSystem())
        componentLink.Component = GridControlHere
        componentLink.Landscape = True
        'AddHandler componentLink.CreateMarginalHeaderArea, AddressOf CreateMarginalHeaderArea
        'AddHandler componentLink.CreateReportHeaderArea, AddressOf CreateReportHeaderArea
        Dim phf As DevExpress.XtraPrinting.PageHeaderFooter = TryCast(componentLink.PageHeaderFooter, DevExpress.XtraPrinting.PageHeaderFooter)

        componentLink.CreateDocument()
        componentLink.ShowPreview()
    End Sub
    Private Sub GVPerDesign_ColumnFilterChanged(sender As Object, e As EventArgs) Handles GVPerDesign.ColumnFilterChanged
        If Not GVPerDesign.FocusedRowHandle < 0 Then
            show_bom_per_design(GVPerDesign.GetFocusedRowCellValue("id_design").ToString)
        End If
    End Sub
End Class