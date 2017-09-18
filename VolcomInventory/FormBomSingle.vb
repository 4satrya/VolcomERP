Public Class FormBOMSingle
    Public id_bom As String = "-1"
    Public id_bom_approve As String = "-1"
    Public id_product As String = "-1"
    Public id_design As String = "-1"

    Public id_pop_up As String = "-1"

    Public id_is_design As String = "-1"
    '
    Public is_update_cop As Boolean = False

    Private Sub FormBOMSingle_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        RICEisCOP.ValueChecked = Convert.ToSByte(1)
        RICEisCOP.ValueUnchecked = Convert.ToSByte(2)
        '
        RCIMainVendor.ValueChecked = Convert.ToSByte(1)
        RCIMainVendor.ValueUnchecked = Convert.ToSByte(2)
        '
        act_load()
    End Sub
    Sub act_load()
        view_term(LETerm)
        view_report_status(LEReportStatus)

        view_currency(LECurrency)

        TEUnitPrice.EditValue = 0
        TEKurs.EditValue = 1

        load_but_submit()

        If id_pop_up = "-1" Then
            LabelProductCode.Text = FormBOM.GVProduct.GetFocusedRowCellDisplayText("product_name").ToString & " (" & FormBOM.GVProduct.GetFocusedRowCellDisplayText("Size").ToString & ")"
            If id_bom <> "-1" Then
                'edit
                Dim query As String = String.Format("SELECT * FROM tb_bom WHERE id_bom = '{0}'", id_bom)
                Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")

                Dim bom_name As String = data.Rows(0)("bom_name").ToString
                Dim id_term_production As String = data.Rows(0)("id_term_production").ToString

                TEKurs.EditValue = data.Rows(0)("kurs")
                MEBOMNote.Text = data.Rows(0)("bom_note").ToString

                data.Dispose()

                TEName.Text = bom_name
                LETerm.EditValue = Nothing
                LETerm.ItemIndex = LETerm.Properties.GetDataSourceRowIndex("id_term_production", id_term_production)

                LECurrency.EditValue = Nothing
                LECurrency.ItemIndex = LECurrency.Properties.GetDataSourceRowIndex("id_currency", data.Rows(0)("id_currency").ToString)

                LEReportStatus.EditValue = Nothing
                LEReportStatus.ItemIndex = LEReportStatus.Properties.GetDataSourceRowIndex("id_report_status", data.Rows(0)("id_report_status").ToString)

                view_bom_det(id_bom)
                view_bom_ovh(id_bom)
                view_bom_wip(id_bom)
                calculate_unit_price()

                LabelPrintedName.Text = bom_name
                GroupComponent.Enabled = True
            Else
                BMark.Enabled = False
                GroupComponent.Enabled = False
            End If
        ElseIf id_pop_up = "1" Then 'form per design
            LabelProductCode.Text = ""
            LTitleProduct.Text = "Design : " + FormBOM.GVPerDesign.GetFocusedRowCellDisplayText("design_name").ToString
            If Not id_bom_approve = "-1" Then
                'edit
                Dim query As String = ""
                Dim data As DataTable
                If id_bom_approve = "" Then
                    query = String.Format("SELECT * FROM tb_bom INNER JOIN tb_m_product mp ON mp.id_product=tb_bom.id_product WHERE ISNULL(id_bom_approve) AND mp.id_design='{0}' LIMIT 1", id_design)
                Else
                    query = String.Format("SELECT * FROM tb_bom INNER JOIN tb_m_product mp ON mp.id_product=tb_bom.id_product WHERE id_bom_approve = '{0}' AND mp.id_design='{1}' LIMIT 1", id_bom_approve, id_design)
                End If

                data = execute_query(query, -1, True, "", "", "", "")

                'submit button
                If Not data.Rows(0)("user_mat_submit").ToString = "" Then
                    BSubmitMat.Enabled = False
                    '
                    BAddMat.Enabled = False
                    BEditMat.Enabled = False
                    BDelMat.Enabled = False
                Else
                    BSubmitMat.Enabled = True
                    '
                    BAddMat.Enabled = True
                    BEditMat.Enabled = True
                    BDelMat.Enabled = True
                End If

                If Not data.Rows(0)("user_ovh_submit").ToString = "" Then
                    BSubmitOVH.Enabled = False
                    '
                    BAddOVH.Enabled = False
                    BEditOVH.Enabled = False
                    BDelOVH.Enabled = False
                Else
                    BSubmitOVH.Enabled = True
                    '
                    BAddOVH.Enabled = True
                    BEditOVH.Enabled = True
                    BDelOVH.Enabled = True
                End If

                If Not data.Rows(0)("user_mat_submit").ToString = "" And Not data.Rows(0)("user_ovh_submit").ToString = "" Then
                    BMark.Enabled = True
                Else
                    BMark.Enabled = False
                End If
                'end submit button

                Dim bom_name As String = data.Rows(0)("bom_name").ToString
                Dim id_term_production As String = data.Rows(0)("id_term_production").ToString

                id_bom = data.Rows(0)("id_bom").ToString

                TEKurs.EditValue = data.Rows(0)("kurs")
                MEBOMNote.Text = data.Rows(0)("bom_note").ToString

                data.Dispose()
                TEName.Text = bom_name
                LETerm.EditValue = Nothing
                LETerm.ItemIndex = LETerm.Properties.GetDataSourceRowIndex("id_term_production", id_term_production)

                LECurrency.EditValue = Nothing
                LECurrency.ItemIndex = LECurrency.Properties.GetDataSourceRowIndex("id_currency", data.Rows(0)("id_currency").ToString)

                LEReportStatus.EditValue = Nothing
                LEReportStatus.ItemIndex = LEReportStatus.Properties.GetDataSourceRowIndex("id_report_status", data.Rows(0)("id_report_status").ToString)

                view_bom_det(id_bom)
                view_bom_ovh(id_bom)
                calculate_unit_price()

                LabelPrintedName.Text = bom_name
                GroupComponent.Enabled = True
                BDuplicate.Enabled = True
            Else
                BDuplicate.Enabled = False
                BMark.Enabled = False
                GroupComponent.Enabled = False
            End If
        End If
        allow_status()
    End Sub
    Sub load_but_submit()
        If id_bom_approve = "-1" Then
            BSubmitMat.Visible = False
            BSubmitOVH.Visible = False
        Else
            BSubmitMat.Visible = True
            BSubmitOVH.Visible = True
        End If
    End Sub
    Private Sub view_report_status(ByVal lookup As DevExpress.XtraEditors.LookUpEdit)
        Dim query As String = "SELECT id_report_status,report_status FROM tb_lookup_report_status"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")

        lookup.Properties.DataSource = data

        lookup.Properties.DisplayMember = "report_status"
        lookup.Properties.ValueMember = "id_report_status"
        lookup.ItemIndex = 0
    End Sub
    Sub view_bom_det(ByVal id_bom As String)
        Try
            Dim query As String
            query = "CALL view_bom_mat(" & id_bom & ")"

            Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
            GCBomDetMat.DataSource = data
            check_but_mat()
            calculate_unit_price()
            GVBomDetMat.BestFitColumns()
        Catch ex As Exception
            errorConnection()
        End Try
    End Sub
    Sub check_but_mat()
        If GVBomDetMat.RowCount > 0 Then
            BDelMat.Visible = True
            BEditMat.Visible = True
        Else
            BDelMat.Visible = False
            BEditMat.Visible = False
        End If
    End Sub
    Sub check_but_ovh()
        If GVBomDetOvh.RowCount > 0 Then
            BDelOVH.Visible = True
            BEditOVH.Visible = True
        Else
            BDelOVH.Visible = False
            BEditOVH.Visible = False
        End If
    End Sub
    Private Sub view_currency(ByVal lookup As DevExpress.XtraEditors.LookUpEdit)
        Dim query As String = "SELECT id_currency,currency FROM tb_lookup_currency"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")

        lookup.Properties.DataSource = data

        lookup.Properties.DisplayMember = "currency"
        lookup.Properties.ValueMember = "id_currency"
        lookup.ItemIndex = 0
    End Sub
    Private Sub BAddMat_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BAddMat.Click
        '
        If FormBOM.XTCBOMSelection.SelectedTabPageIndex = "2" Then
            FormBOMSingleMat.id_pop_up = "2"
        End If
        FormBOMSingleMat.id_mat_det = "-1"
        FormBOMSingleMat.ShowDialog()
    End Sub
    Private Sub view_term(ByVal lookup As DevExpress.XtraEditors.LookUpEdit)
        Dim query As String = "SELECT id_term_production,term_production FROM tb_lookup_term_production"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")

        lookup.Properties.DataSource = data

        lookup.Properties.DisplayMember = "term_production"
        lookup.Properties.ValueMember = "id_term_production"
        lookup.ItemIndex = 0
    End Sub

    Private Sub BSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BSave.Click
        Dim bom_note, bom_name, id_term_production, query, unit_price, id_bom_new, id_bom_approve_new, kurs As String

        ValidateChildren()
        bom_name = TEName.Text
        bom_note = MEBOMNote.Text
        id_term_production = LETerm.EditValue
        unit_price = decimalSQL(TEUnitPrice.EditValue.ToString)
        kurs = decimalSQL(TEKurs.EditValue.ToString)
        If id_pop_up = "-1" Then
            If id_bom <> "-1" Then
                'edit
                If Not formIsValid(EPBOM) Then
                    errorInput()
                Else
                    query = String.Format("UPDATE tb_bom SET bom_name='{0}',id_term_production='{1}',bom_date_created=DATE(NOW()),bom_unit_price='{2}',id_currency='{3}',kurs='{5}',id_user_last_update='{6}',bom_note='{7}',bom_date_updated=NOW() WHERE id_bom='{4}'", bom_name, id_term_production, unit_price, LECurrency.EditValue.ToString, id_bom, kurs, id_user, bom_note)
                    execute_non_query(query, True, "", "", "", "")
                    FormBOM.view_bom(id_product)
                    FormBOM.GVBOM.FocusedRowHandle = find_row(FormBOM.GVBOM, "id_bom", id_bom)
                    FormBOM.view_bom_det(FormBOM.GVBOM.GetFocusedRowCellDisplayText("id_bom").ToString)
                    FormBOM.view_bom_ovh(FormBOM.GVBOM.GetFocusedRowCellDisplayText("id_bom").ToString)
                    FormBOM.view_bom_wip(FormBOM.GVBOM.GetFocusedRowCellDisplayText("id_bom").ToString)
                    '
                    infoCustom("BOM updated.")
                    act_load()
                End If
            Else
                'insert
                If Not formIsValid(EPBOM) Then
                    errorInput()
                Else
                    query = String.Format("INSERT INTO tb_bom(bom_name,id_product,id_term_production,bom_date_created,bom_unit_price,id_currency,kurs,id_user_last_update,bom_date_updated,bom_note) VALUES('{0}','{1}','{2}',DATE(NOW()),'{3}','{4}','{5}','{6}',NOW(),'{7}');SELECT LAST_INSERT_ID() ", bom_name, id_product, id_term_production, unit_price, LECurrency.EditValue.ToString, kurs, id_user, bom_note)
                    id_bom_new = execute_query(query, 0, True, "", "", "", "")
                    insert_who_prepared("8", id_bom_new, id_user)
                    FormBOM.view_bom(id_product)
                    FormBOM.GVBOM.FocusedRowHandle = find_row(FormBOM.GVBOM, "id_bom", id_bom_new)
                    FormBOM.view_bom_det(FormBOM.GVBOM.GetFocusedRowCellDisplayText("id_bom").ToString)
                    FormBOM.view_bom_ovh(FormBOM.GVBOM.GetFocusedRowCellDisplayText("id_bom").ToString)
                    FormBOM.view_bom_wip(FormBOM.GVBOM.GetFocusedRowCellDisplayText("id_bom").ToString)
                    '
                    id_bom = id_bom_new
                    infoCustom("BOM saved.")
                    act_load()
                End If
            End If
        ElseIf id_pop_up = "1" Then
            If Not id_bom_approve = "-1" Then
                'edit
                If Not formIsValid(EPBOM) Then
                    errorInput()
                Else
                    query = String.Format("UPDATE tb_bom SET bom_name='{0}',id_term_production='{1}',bom_date_updated=NOW(),bom_unit_price='{2}',id_currency='{3}',kurs='{5}',id_user_last_update='{6}',bom_note='{7}' WHERE id_bom_approve='{4}'", bom_name, id_term_production, unit_price, LECurrency.EditValue.ToString, id_bom_approve, kurs, id_user, bom_note)
                    execute_non_query(query, True, "", "", "", "")
                    '
                    infoCustom("BOM updated.")
                    act_load()
                End If
            Else
                'insert
                If Not formIsValid(EPBOM) Then
                    errorInput()
                Else
                    query = "INSERT INTO tb_bom_approve(id_report_status) values(1);SELECT LAST_INSERT_ID();"
                    id_bom_approve_new = execute_query(query, 0, True, "", "", "", "")
                    Dim query_loop As String = "SELECT id_product FROM tb_m_product WHERE id_design='" & FormBOM.GVPerDesign.GetFocusedRowCellValue("id_design").ToString & "'"
                    Dim data_loop As DataTable = execute_query(query_loop, -1, True, "", "", "", "")
                    For i As Integer = 0 To data_loop.Rows.Count - 1
                        query = String.Format("INSERT INTO tb_bom(bom_name,id_product,id_term_production,bom_date_created,bom_unit_price,id_currency,kurs,id_bom_approve,bom_date_updated,id_user_last_update,bom_note) VALUES('{0}','{1}','{2}',DATE(NOW()),'{3}','{4}','{5}','{6}',NOW(),'{7}','{8}'); ", bom_name, data_loop.Rows(i)("id_product").ToString, id_term_production, unit_price, LECurrency.EditValue.ToString, kurs, id_bom_approve_new, id_user, bom_note)
                        execute_non_query(query, True, "", "", "", "")
                    Next
                    '
                    id_bom_approve = id_bom_approve_new
                    infoCustom("BOM saved.")
                    act_load()
                End If
            End If
            FormBOM.show_bom_per_design(FormBOM.GVPerDesign.GetFocusedRowCellDisplayText("id_design").ToString)
            FormBOM.GVBOMPerDesign.FocusedRowHandle = find_row(FormBOM.GVBOMPerDesign, "id_bom_approve", id_bom_approve)
        End If
    End Sub

    Private Sub FormBOMSingle_FormClosed(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub TEName_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TEName.Validating
        EP_TE_cant_blank(EPBOM, TEName)
    End Sub

    Private Sub BEditMat_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BEditMat.Click
        '
        FormBOMSingleMat.id_bom = id_bom
        If FormBOM.XTCBOMSelection.SelectedTabPageIndex = "2" Then
            FormBOMSingleMat.id_pop_up = "2"
        End If
        FormBOMSingleMat.id_bom_det = GVBomDetMat.GetFocusedRowCellDisplayText("id_bom_det").ToString
        FormBOMSingleMat.ShowDialog()
    End Sub

    Private Sub BDelMat_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BDelMat.Click
        Dim confirm As DialogResult
        Dim query As String
        confirm = DevExpress.XtraEditors.XtraMessageBox.Show("Are you sure want to delete this component?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)

        Dim id_bom_det As String = GVBomDetMat.GetFocusedRowCellDisplayText("id_bom_det").ToString
        Dim id_mat_det As String = get_id_mat_det(id_bom_det)
        If confirm = Windows.Forms.DialogResult.Yes Then
            Cursor = Cursors.WaitCursor
            Try
                If FormBOM.XTCBOMSelection.SelectedTabPageIndex = "2" Then
                    query = String.Format("DELETE bom_d FROM tb_bom_det bom_d " +
                        "inner join tb_bom bom ON bom.id_bom=bom_d.id_bom " +
                        "inner join tb_m_mat_det_price mdp ON mdp.id_mat_det_price=bom_d.id_mat_det_price " +
                        "WHERE mdp.id_mat_det='{0}' and bom.id_bom_approve='{1}'", id_mat_det, id_bom_approve)
                    execute_non_query(query, True, "", "", "", "")
                Else
                    query = String.Format("DELETE FROM tb_bom_det WHERE id_bom_det = '{0}'", id_bom_det)
                End If
                execute_non_query(query, True, "", "", "", "")
                view_bom_det(id_bom)
            Catch ex As Exception
                DevExpress.XtraEditors.XtraMessageBox.Show("This component data already used.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
            Cursor = Cursors.Default
        End If
    End Sub

    Sub view_bom_ovh(ByVal id_bomx As String)
        Try
            Dim query As String
            query = "CALL view_bom_ovh(" & id_bomx & ")"

            Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
            GCBomDetOvh.DataSource = data
            check_but_ovh()
            calculate_unit_price()
            GVBomDetOvh.BestFitColumns()
        Catch ex As Exception
            errorConnection()
        End Try
    End Sub

    Private Sub BAddOVH_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BAddOVH.Click
        '
        If FormBOM.XTCBOMSelection.SelectedTabPageIndex = "2" Then
            FormBOMSingleOvh.id_pop_up = "2"
        End If
        FormBOMSingleOvh.id_bom = id_bom
        FormBOMSingleOvh.ShowDialog()
    End Sub

    Private Sub BEditOVH_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BEditOVH.Click
        '
        If FormBOM.XTCBOMSelection.SelectedTabPageIndex = "2" Then
            FormBOMSingleOvh.id_pop_up = "2"
        End If
        FormBOMSingleOvh.id_bom = id_bom
        FormBOMSingleOvh.id_bom_det = GVBomDetOvh.GetFocusedRowCellDisplayText("id_bom_det").ToString
        FormBOMSingleOvh.ShowDialog()
    End Sub

    Private Sub BDelOVH_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BDelOVH.Click
        Dim confirm As DialogResult
        Dim query As String
        confirm = DevExpress.XtraEditors.XtraMessageBox.Show("Are you sure want to delete this component?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)

        Dim id_bom_det As String = GVBomDetOvh.GetFocusedRowCellDisplayText("id_bom_det").ToString
        Dim id_ovh As String = get_id_ovh(id_bom_det)

        If confirm = Windows.Forms.DialogResult.Yes Then
            Cursor = Cursors.WaitCursor
            Try
                If FormBOM.XTCBOMSelection.SelectedTabPageIndex = "2" Then
                    query = String.Format("DELETE bom_d FROM tb_bom_det bom_d " +
                        "inner join tb_bom bom ON bom.id_bom=bom_d.id_bom " +
                        "inner join tb_m_ovh_price mop ON mop.id_ovh_price=bom_d.id_ovh_price " +
                        "WHERE mop.id_ovh='{0}' and bom.id_bom_approve='{1}'", id_ovh, id_bom_approve)
                    '"inner join tb_m_mat_det_price mdp ON mdp.id_mat_det_price=bom_d.id_mat_det_price " +
                    '"WHERE mdp.id_mat_det='{0}' and bom.id_bom_approve='{1}'", id_mat_det, FormBOMSingle.id_bom_approve)
                    execute_non_query(query, True, "", "", "", "")
                Else
                    query = String.Format("DELETE FROM tb_bom_det WHERE id_bom_det = '{0}'", id_bom_det)
                End If
                execute_non_query(query, True, "", "", "", "")
                view_bom_ovh(id_bom)
            Catch ex As Exception
                DevExpress.XtraEditors.XtraMessageBox.Show("This component data already used.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
            Cursor = Cursors.Default
        End If
    End Sub
    Sub view_bom_wip(ByVal id_bomx As String)
        Try
            Dim query As String
            query = "CALL view_bom_product(" & id_bomx & ")"

            Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
            GCBomDetWip.DataSource = data
            calculate_unit_price()
            If data.Rows.Count < 1 Then
                BDelWip.Visible = False
                BEditWip.Visible = False
            Else
                BDelWip.Visible = True
                BEditWip.Visible = True
            End If
        Catch ex As Exception
            errorConnection()
        End Try
    End Sub
    Private Sub BAddWip_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BAddWip.Click
        '
        FormBOMSingleWip.id_bom = id_bom
        FormBOMSingleWip.ShowDialog()
    End Sub

    Private Sub BEditWip_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BEditWip.Click
        FormBOMSingleWip.id_bom = id_bom
        FormBOMSingleWip.id_bom_det = GVBomDetWip.GetFocusedRowCellDisplayText("id_bom_det").ToString
        FormBOMSingleWip.ShowDialog()
    End Sub

    Private Sub BDelWip_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BDelWip.Click
        Dim confirm As DialogResult
        Dim query As String
        confirm = DevExpress.XtraEditors.XtraMessageBox.Show("Are you sure want to delete this component?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)

        Dim id_bom_det As String = GVBomDetWip.GetFocusedRowCellDisplayText("id_bom_det").ToString
        If confirm = Windows.Forms.DialogResult.Yes Then
            Cursor = Cursors.WaitCursor
            Try
                query = String.Format("DELETE FROM tb_bom_det WHERE id_bom_det = '{0}'", id_bom_det)
                execute_non_query(query, True, "", "", "", "")
                view_bom_wip(id_bom)
            Catch ex As Exception
                DevExpress.XtraEditors.XtraMessageBox.Show("This component data already used.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
            Cursor = Cursors.Default
        End If
    End Sub

    Sub calculate_unit_price()
        Dim mat, ovh, wip, total As Decimal
        Try
            mat = GVBomDetMat.Columns("total_cost").SummaryItem.SummaryValue
            ovh = GVBomDetOvh.Columns("total").SummaryItem.SummaryValue
            wip = GVBomDetWip.Columns("total").SummaryItem.SummaryValue
        Catch ex As Exception
        End Try

        total = mat + ovh + wip

        TEUnitPrice.EditValue = total
    End Sub
    Sub allow_status()
        If check_edit_report_status(LEReportStatus.EditValue.ToString, "8", id_bom) Then
            'allow edit
            BSave.Enabled = True
            TEKurs.Enabled = True
            '
            'BAddMat.Enabled = True
            'BEditMat.Enabled = True
            'BDelMat.Enabled = True
            '
            'BAddOVH.Enabled = True
            'BEditOVH.Enabled = True
            'BDelOVH.Enabled = True
            '
            'BAddWip.Enabled = True
            'BEditWip.Enabled = True
            'BDelWip.Enabled = True
        Else
            'no edit
            BSave.Enabled = False
            TEKurs.Enabled = False
            '
            'BAddMat.Enabled = False
            'BEditMat.Enabled = False
            'BDelMat.Enabled = False
            '
            'BAddOVH.Enabled = False
            'BEditOVH.Enabled = False
            'BDelOVH.Enabled = False
            '
            'BAddWip.Enabled = False
            'BEditWip.Enabled = False
            'BDelWip.Enabled = False
        End If
        If check_print_report_status(LEReportStatus.EditValue.ToString) Then
            Bprint.Enabled = True
        Else
            Bprint.Enabled = False
        End If
    End Sub

    Private Sub BMark_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BMark.Click
        'FormReportMark.id_report = id_bom
        'FormReportMark.report_mark_type = "8"
        FormReportMark.form_origin = "FormBomSingle"
        FormReportMark.id_report = id_bom_approve
        FormReportMark.report_mark_type = "79"
        FormReportMark.ShowDialog()
    End Sub

    Private Sub Bprint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Bprint.Click
        '
        ReportBOM.id_bom = FormBOM.GVBOM.GetFocusedRowCellDisplayText("id_bom").ToString
        ReportBOM.product_name = FormBOM.GVProduct.GetFocusedRowCellDisplayText("product_name").ToString & " - " & FormBOM.GVProduct.GetFocusedRowCellDisplayText("Size").ToString
        ReportBOM.bom_name = FormBOM.GVBOM.GetFocusedRowCellDisplayText("bom_name").ToString
        ReportBOM.bom_date = FormBOM.GVBOM.GetFocusedRowCellDisplayText("bom_date_created").ToString
        ReportBOM.bom_term = FormBOM.GVBOM.GetFocusedRowCellDisplayText("term_production").ToString

        Dim Report As New ReportBOM()
        ' Show the report's preview. 
        Dim Tool As DevExpress.XtraReports.UI.ReportPrintTool = New DevExpress.XtraReports.UI.ReportPrintTool(Report)
        Tool.ShowPreview()
    End Sub

    Private Sub BCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BCancel.Click
        Close()
    End Sub

    Private Sub BSubmitMat_Click(sender As Object, e As EventArgs) Handles BSubmitMat.Click
        Dim confirm As DialogResult
        Dim query As String
        confirm = DevExpress.XtraEditors.XtraMessageBox.Show("Are you sure want to submit this list?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)

        If confirm = Windows.Forms.DialogResult.Yes Then
            Cursor = Cursors.WaitCursor
            Try
                If FormBOM.XTCBOMSelection.SelectedTabPageIndex = "2" Then
                    Dim bom_where As String = ""
                    If id_bom_approve = "" Then
                        bom_where = "ISNULL(bom.id_bom_approve)"
                    Else
                        bom_where = "bom.id_bom_approve='" + id_bom_approve + "'"
                    End If

                    query = String.Format("UPDATE tb_bom bom INNER JOIN tb_m_product prod ON prod.id_product=bom.id_product SET bom.user_mat_submit='{0}',bom.bom_unit_price='{3}' WHERE {1} AND prod.id_design='{2}'", id_user, bom_where, id_design, decimalSQL(TEUnitPrice.EditValue.ToString))
                    execute_non_query(query, True, "", "", "", "")
                Else
                    query = String.Format("UPDATE tb_bom SET bom.user_mat_submit='{0}' WHERE id_bom='{1}'", id_user, id_bom)
                    execute_non_query(query, True, "", "", "", "")
                End If
                act_load()
            Catch ex As Exception
                DevExpress.XtraEditors.XtraMessageBox.Show(ex.ToString, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
            Cursor = Cursors.Default
        End If
    End Sub

    Private Sub BSubmitOVH_Click(sender As Object, e As EventArgs) Handles BSubmitOVH.Click
        Dim confirm As DialogResult
        Dim query As String
        confirm = DevExpress.XtraEditors.XtraMessageBox.Show("Are you sure want to submit this list?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)

        If confirm = Windows.Forms.DialogResult.Yes Then
            Cursor = Cursors.WaitCursor
            Try
                If FormBOM.XTCBOMSelection.SelectedTabPageIndex = "2" Then
                    Dim bom_where As String = ""
                    If id_bom_approve = "" Then
                        bom_where = "ISNULL(bom.id_bom_approve)"
                    Else
                        bom_where = "bom.id_bom_approve='" + id_bom_approve + "'"
                    End If

                    query = String.Format("UPDATE tb_bom bom INNER JOIN tb_m_product prod ON prod.id_product=bom.id_product SET bom.user_ovh_submit='{0}',bom.bom_unit_price='{3}' WHERE {1} AND prod.id_design='{2}'", id_user, bom_where, id_design, decimalSQL(TEUnitPrice.EditValue.ToString))
                    execute_non_query(query, True, "", "", "", "")
                Else
                    query = String.Format("UPDATE tb_bom SET bom.user_ovh_submit='{0}' WHERE id_bom='{1}'", id_user, id_bom)
                    execute_non_query(query, True, "", "", "", "")
                End If
                act_load()
            Catch ex As Exception
                DevExpress.XtraEditors.XtraMessageBox.Show(ex.ToString, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
            Cursor = Cursors.Default
        End If
    End Sub
    Sub act_dupe()
        Dim query As String = ""
        Dim id_bom_approve_new As String = ""
        'new id_bom_approve
        query = "INSERT INTO tb_bom_approve(id_report_status) VALUES(1); SELECT LAST_INSERT_ID();"
        id_bom_approve_new = execute_query(query, 0, True, "", "", "", "")
        'INSERT BOM
        query = "INSERT INTO tb_bom(id_product,id_term_production,bom_name,id_currency,kurs,bom_unit_price,bom_date_created,bom_date_updated,id_user_last_update,id_bom_approve,id_report_status,is_default,bom_note) "
        query += " SELECT bom.id_product,bom.id_term_production,bom.bom_name,bom.id_currency,bom.kurs,bom.bom_unit_price,DATE(NOW()),NOW(),'" + id_user + "','" + id_bom_approve_new + "','1',2,bom.bom_note "
        query += " FROM tb_bom bom"
        query += " INNER JOIN tb_m_product prod ON prod.id_product=bom.id_product"
        query += " WHERE bom.id_bom_approve='" + id_bom_approve + "' AND prod.id_design='" + id_design + "'"
        execute_non_query(query, True, "", "", "", "")
        'Insert detail
        query = "INSERT INTO tb_bom_det(id_bom,id_component_category,id_mat_det_price,id_ovh_price,id_product_price,kurs,bom_price,component_qty,is_cost,is_ovh_main) "
        query += " SELECT bom_b.id_bom_new,bomd.id_component_category,bomd.id_mat_det_price,bomd.id_ovh_price,bomd.id_product_price,bomd.kurs,bomd.bom_price,bomd.component_qty,bomd.is_cost,bomd.is_ovh_main FROM tb_bom_det bomd"
        query += " INNER JOIN tb_bom bom On bom.id_bom=bomd.id_bom"
        query += " INNER JOIN tb_m_product prod ON prod.id_product=bom.id_product"
        query += " INNER JOIN"
        query += " ( SELECT id_bom AS id_bom_new FROM tb_bom WHERE id_bom_approve='" + id_bom_approve_new + "' ) bom_b"
        query += " WHERE bom.id_bom=(SELECT id_bom FROM tb_bom WHERE id_bom_approve='" + id_bom_approve + "' LIMIT 1)"
        execute_non_query(query, True, "", "", "", "")
        infoCustom("BOM duplicate success.")
        '
        id_bom_approve = id_bom_approve_new
    End Sub

    Private Sub BDuplicate_Click(sender As Object, e As EventArgs) Handles BDuplicate.Click
        Dim confirm As DialogResult
        confirm = DevExpress.XtraEditors.XtraMessageBox.Show("Are you sure want to duplicate this BOM?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)

        If confirm = Windows.Forms.DialogResult.Yes Then
            Cursor = Cursors.WaitCursor
            Try
                act_dupe()
                '
                act_load()
                FormBOM.show_bom_per_design(FormBOM.GVPerDesign.GetFocusedRowCellDisplayText("id_design").ToString)
                FormBOM.GVBOMPerDesign.FocusedRowHandle = find_row(FormBOM.GVBOMPerDesign, "id_bom_approve", id_bom_approve)
            Catch ex As Exception
                DevExpress.XtraEditors.XtraMessageBox.Show(ex.ToString, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
            Cursor = Cursors.Default
        End If
    End Sub
End Class