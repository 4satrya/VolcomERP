Public Class FormPurcAssetDet
    Public id As String = "-1"
    Public action As String = "-1"
    Public id_purc_rec As String = "-1"
    Dim id_purc_order As String = "-1"
    Public is_confirm As String = "-1"
    Public is_view As String = "-1"
    Dim id_report_status As String = "-1"
    Public find_accum As Boolean = False
    Public view_current As Boolean = False
    Public move_location As Boolean = False
    Public input_description As Boolean = False

    Private loaded As Boolean = False

    Private id_departement_current As String = "-1"

    Private Sub FormPurcAssetDet_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        viewCOA()
        viewComp()
        viewEmp()
        viewDepartement()
        actionLoad()
    End Sub

    Sub viewComp()
        Dim query As String = "SELECT id_comp, comp_number,comp_name FROM tb_m_comp"
        viewSearchLookupQuery(SLEComp, query, "id_comp", "comp_number", "id_comp")
        '
        Try
            TxtComp.Text = get_company_x(get_setup_field("id_own_company").ToString, "1")
            SLEComp.EditValue = get_setup_field("id_own_company").ToString
        Catch ex As Exception

        End Try
    End Sub

    Sub viewCOA()
        Dim query As String = "SELECT a.id_acc, a.acc_name, a.acc_description, a.id_acc_parent, 
        a.id_acc_parent, a.id_acc_cat, a.id_is_det, a.id_status, a.id_comp
        FROM tb_a_acc a WHERE a.id_status=1 AND a.id_is_det=2 "
        viewSearchLookupQuery(SLEAccountFixedAsset, query, "id_acc", "acc_description", "id_acc")
        viewSearchLookupQuery(SLEDep, query, "id_acc", "acc_description", "id_acc")
        viewSearchLookupQuery(SLEAccumDep, query, "id_acc", "acc_description", "id_acc")
    End Sub

    Sub viewEmp()
        Dim query As String = "
            (SELECT '' AS id_departement, '' AS departement, '' AS id_employee, '' AS employee_code, '' AS employee_name, '' AS id_employee_active, '' AS employee_active)
            UNION
            (SELECT e.id_departement, d.departement, e.id_employee, e.employee_code, e.employee_name, e.id_employee_active, a.employee_active
            FROM tb_m_employee AS e
            LEFT JOIN tb_m_departement AS d ON e.id_departement = d.id_departement
            LEFT JOIN tb_lookup_employee_active AS a ON e.id_employee_active = a.id_employee_active
            ORDER BY d.departement ASC, e.id_employee_level ASC, e.employee_code ASC)
        "
        viewSearchLookupQuery(SLUEEmployeeCurrent, query, "id_employee", "employee_name", "id_employee")
    End Sub

    Sub viewDepartement()
        Dim query As String = "
            SELECT id_departement, departement FROM tb_m_departement ORDER BY departement ASC
        "
        viewSearchLookupQuery(SLUEDepartmentCurrent, query, "id_departement", "departement", "id_departement")
    End Sub

    Sub actionLoad()
        loaded = False

        If action = "ins" Then
            MsgBox("3ins")
            SLEComp.EditValue = "-1"
            TxtComp.Text = ""
            SLEComp.EditValue = "1"
            TxtComp.Text = execute_query("SELECT comp_number FROM tb_m_comp WHERE id_comp='" + SLEComp.EditValue.ToString + "' ", 0, True, "", "", "", "")
        ElseIf action = "upd" Then
            Dim a As New ClassPurcAsset()
            Dim query As String = a.queryMain("AND a.id_purc_rec_asset=" + id + "", "1", find_accum)
            Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
            '
            If data.Rows(0)("ship_to").ToString = "0" Then
                SLEComp.EditValue = get_setup_field("id_own_company")
            Else
                SLEComp.EditValue = data.Rows(0)("ship_to").ToString
            End If
            '
            is_confirm = data.Rows(0)("is_confirm").ToString
            'generate number
            If is_confirm = "2" Then
                execute_non_query("CALL gen_number(" + id + ", 160)", True, "", "", "", "")
                TxtAssetNumber.Text = execute_query("SELECT asset_number FROM tb_purc_rec_asset WHERE id_purc_rec_asset=" + id + "", 0, True, "", "", "", "")
            Else
                TxtAssetNumber.Text = data.Rows(0)("asset_number").ToString
            End If
            TxtAssetName.Text = data.Rows(0)("asset_name").ToString
            TxtDept.Text = data.Rows(0)("departement").ToString
            SLEAccountFixedAsset.EditValue = data.Rows(0)("id_acc_fa").ToString
            DECreated.EditValue = data.Rows(0)("acq_date")
            TxtCost.EditValue = data.Rows(0)("acq_cost")
            '
            If data.Rows(0)("is_confirm") = "1" Then
                SLEComp.EditValue = data.Rows(0)("id_comp_tag").ToString
            End If
            '
            If data.Rows(0)("id_report_status") = "6" And data.Rows(0)("is_active_v") = "1" Then
                PanelControlVA.Visible = True
                TxtVA.EditValue = data.Rows(0)("acq_cost_va")
                TxtTotalCost.EditValue = TxtCost.EditValue + TxtVA.EditValue
            Else
                PanelControlVA.Visible = False
            End If
            id_purc_rec = data.Rows(0)("id_purc_rec").ToString
            LinkRec.Text = data.Rows(0)("purc_rec_number").ToString
            id_purc_order = data.Rows(0)("id_purc_order").ToString
            LinkOrder.Text = data.Rows(0)("purc_order_number").ToString
            id_report_status = data.Rows(0)("id_report_status").ToString

            'depreciation
            TxtUseful.EditValue = data.Rows(0)("useful_life")
            If data.Rows(0)("id_acc_dep").ToString <> "0" Then
                SLEDep.EditValue = data.Rows(0)("id_acc_dep").ToString
            End If
            If data.Rows(0)("id_acc_dep_accum").ToString <> "0" Then
                SLEAccumDep.EditValue = data.Rows(0)("id_acc_dep_accum").ToString
            End If
            TxtAccumDep.EditValue = data.Rows(0)("accum_dep")
            If data.Rows(0)("is_non_depresiasi") = "1" Then
                CheckEditIsNonDep.EditValue = True
                PanelDepDetail.Enabled = False
            Else
                CheckEditIsNonDep.EditValue = False
                PanelDepDetail.Enabled = True
            End If

            'jika asset aktif
            If find_accum Then
                TxtAccumDep.EditValue = data.Rows(0)("accum_value") + data.Rows(0)("accum_value_va")
            End If

            'current
            id_departement_current = data.Rows(0)("id_departement_current").ToString

            SLUEEmployeeCurrent.EditValue = data.Rows(0)("id_employee_current")
            SLUEDepartmentCurrent.EditValue = data.Rows(0)("id_departement_current")
            SLUELocationCurrent.EditValue = data.Rows(0)("location_current")
            DELocationDate.EditValue = data.Rows(0)("location_date")

            'description
            MEDescription.EditValue = data.Rows(0)("asset_note").ToString

            allow_status()
        End If

        loaded = True
    End Sub

    Sub allow_status()
        BtnCreate.Visible = False
        SBSaveDescription.Visible = False

        If is_confirm = "2" Then
            BtnConfirm.Visible = True
            BtnCancell.Visible = False
            BtnMark.Visible = False
            TxtAssetName.Enabled = True
            MEDescription.Enabled = True
            CheckEditIsNonDep.Enabled = True
            TxtUseful.Enabled = True
            SLEDep.Enabled = True
            SLEAccumDep.Enabled = True
            TxtAccumDep.Enabled = True
        Else
            BtnConfirm.Visible = False
            BtnCancell.Visible = True
            BtnMark.Visible = True
            TxtAssetName.Enabled = False
            MEDescription.Enabled = False
            CheckEditIsNonDep.Enabled = False
            TxtUseful.Enabled = False
            SLEDep.Enabled = False
            SLEAccumDep.Enabled = False
            TxtAccumDep.Enabled = False
        End If

        If id_report_status = "6" Then
            BtnCancell.Visible = False
            PanelApp.Visible = True
            BtnDepHist.Visible = True
            BtnDepHist.BringToFront()
        ElseIf id_report_status = "5" Then
            BtnCancell.Visible = False
            PanelApp.Visible = False
        End If

        'current
        SLUEEmployeeCurrent.ReadOnly = True
        SLUEDepartmentCurrent.ReadOnly = True
        SLUELocationCurrent.ReadOnly = True
        DELocationDate.ReadOnly = True

        SBSaveCurrent.Visible = False

        DELocationDate.Size = New Size(300, DELocationDate.Height)

        If view_current Then
            SBSaveCurrent.Visible = True

            If id_departement_current = "" Then
                SLUEEmployeeCurrent.ReadOnly = False
                SLUEDepartmentCurrent.ReadOnly = False
                SLUELocationCurrent.ReadOnly = False
                DELocationDate.ReadOnly = False

                SBSaveCurrent.Enabled = True
            Else
                SLUEEmployeeCurrent.ReadOnly = True
                SLUEDepartmentCurrent.ReadOnly = True
                SLUELocationCurrent.ReadOnly = True
                DELocationDate.ReadOnly = True

                SBSaveCurrent.Enabled = False
            End If

            DELocationDate.Size = New Size(222, DELocationDate.Height)
        End If

        If move_location Then
            view_current = True

            SBSaveCurrent.Visible = True

            SLUEEmployeeCurrent.ReadOnly = False
            SLUEDepartmentCurrent.ReadOnly = False
            SLUELocationCurrent.ReadOnly = False
            DELocationDate.ReadOnly = False

            SBSaveCurrent.Enabled = True

            DELocationDate.Size = New Size(222, DELocationDate.Height)
        End If

        If input_description Then
            SBSaveDescription.Visible = True

            If MEDescription.Text = "" Then
                SBSaveDescription.Enabled = True
                MEDescription.Enabled = True
            Else
                SBSaveDescription.Enabled = False
                MEDescription.Enabled = False
            End If
        End If
    End Sub

    Private Sub FormPurcAssetDet_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub HyperLinkEdit1_OpenLink(sender As Object, e As DevExpress.XtraEditors.Controls.OpenLinkEventArgs) Handles LinkRec.OpenLink
        Cursor = Cursors.WaitCursor
        Dim c As New ClassShowPopUp()
        c.report_mark_type = "148"
        c.id_report = id_purc_rec
        c.show()
        Cursor = Cursors.Default
    End Sub

    Private Sub LinkOrder_OpenLink(sender As Object, e As DevExpress.XtraEditors.Controls.OpenLinkEventArgs) Handles LinkOrder.OpenLink
        Cursor = Cursors.WaitCursor
        Dim c As New ClassShowPopUp()
        c.report_mark_type = "139"
        c.id_report = id_purc_order
        c.show()
        Cursor = Cursors.Default
    End Sub

    Private Sub CheckEditIsNonDep_CheckedChanged(sender As Object, e As EventArgs) Handles CheckEditIsNonDep.CheckedChanged
        If CheckEditIsNonDep.EditValue = True Then
            PanelDepDetail.Enabled = False
        Else
            PanelDepDetail.Enabled = True
        End If
        allow_status()
    End Sub

    Private Sub BtnConfirm_Click(sender As Object, e As EventArgs) Handles BtnConfirm.Click
        If TxtUseful.EditValue <= 0 Then
            warningCustom("Please input useful life")
        Else
            Dim confirm As DialogResult = DevExpress.XtraEditors.XtraMessageBox.Show("Are you sure you want to confirm this asset ?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
            If confirm = Windows.Forms.DialogResult.Yes Then
                Cursor = Cursors.WaitCursor
                Dim asset_name As String = addSlashes(TxtAssetName.Text)
                Dim asset_note As String = addSlashes(MEDescription.Text)
                Dim is_non_depresiasi As String = ""
                If CheckEditIsNonDep.EditValue = True Then
                    is_non_depresiasi = "1"
                Else
                    is_non_depresiasi = "2"
                End If
                Dim useful_life As String = decimalSQL(TxtUseful.EditValue.ToString)
                Dim id_tag As String = SLEComp.EditValue.ToString
                Dim id_acc_dep As String = SLEDep.EditValue.ToString
                Dim id_acc_dep_accum As String = SLEAccumDep.EditValue.ToString
                Dim accum_dep As String = decimalSQL(TxtAccumDep.EditValue.ToString)
                Dim query As String = "UPDATE tb_purc_rec_asset SET id_comp_tag='" + id_tag + "',id_parent='" + id + "',asset_name='" + asset_name + "',
                asset_note='" + asset_note + "', is_non_depresiasi='" + is_non_depresiasi + "',useful_life='" + useful_life + "',
                id_acc_dep='" + id_acc_dep + "', id_acc_dep_accum='" + id_acc_dep_accum + "', accum_dep='" + accum_dep + "',
                is_confirm=1 WHERE id_purc_rec_asset='" + id + "' "
                execute_non_query(query, True, "", "", "", "")
                submit_who_prepared("160", id, id_user)
                FormPurcAsset.viewPending()
                FormPurcAsset.GVPending.FocusedRowHandle = find_row(FormPurcAsset.GVPending, "id_purc_rec_asset", id)
                action = "upd"
                actionLoad()
                Cursor = Cursors.Default
            End If
        End If
    End Sub

    Private Sub BtnMark_Click(sender As Object, e As EventArgs) Handles BtnMark.Click
        Cursor = Cursors.WaitCursor
        FormReportMark.report_mark_type = "160"
        FormReportMark.id_report = id
        FormReportMark.is_view = "1"
        FormReportMark.form_origin = Name
        FormReportMark.ShowDialog()
        Cursor = Cursors.Default
    End Sub

    Private Sub BtnCancell_Click(sender As Object, e As EventArgs) Handles BtnCancell.Click
        Dim confirm As DialogResult = DevExpress.XtraEditors.XtraMessageBox.Show("Are you sure you want to cancell this process ?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
        If confirm = Windows.Forms.DialogResult.Yes Then
            Cursor = Cursors.WaitCursor
            Dim a As New ClassPurcAsset()
            a.cancellPropose(id, id_purc_rec)
            Cursor = Cursors.Default
        End If

    End Sub

    Private Sub BtnDepHist_Click(sender As Object, e As EventArgs) Handles BtnDepHist.Click
        Cursor = Cursors.WaitCursor
        FormPurcAssetDepHistory.cond = "AND a.id_parent='" + id + "' "
        FormPurcAssetDepHistory.ShowDialog()
        Cursor = Cursors.Default
    End Sub

    Private Sub HLCDetailVA_Click(sender As Object, e As EventArgs) Handles HLCDetailVA.Click
        Cursor = Cursors.WaitCursor
        FormPurcAssetValueAddedList.id_parent = id
        FormPurcAssetValueAddedList.LabelAssetName.Text = TxtAssetName.Text
        FormPurcAssetValueAddedList.LabelLinkAssetNumber.Text = TxtAssetNumber.Text
        FormPurcAssetValueAddedList.LabelLinkAssetNumber.Enabled = False
        FormPurcAssetValueAddedList.BtnAdd.Visible = False
        FormPurcAssetValueAddedList.ShowDialog()
        Cursor = Cursors.Default
    End Sub

    Private Sub SLEComp_EditValueChanged(sender As Object, e As EventArgs) Handles SLEComp.EditValueChanged
        Try
            TxtComp.Text = SLEComp.Properties.View.GetFocusedRowCellValue("comp_name").ToString
        Catch ex As Exception

        End Try
    End Sub

    Private Sub SBSaveCurrent_Click(sender As Object, e As EventArgs) Handles SBSaveCurrent.Click
        Dim err As String = ""

        If SLUEDepartmentCurrent.EditValue.ToString = "" Then
            err = "Please select department."
        End If

        If SLUELocationCurrent.EditValue.ToString = "" Then
            err = "Please input location."
        End If

        If DELocationDate.Text = "" Then
            err = "Please input date."
        End If

        If err = "" Then
            Dim confirm As DialogResult

            confirm = DevExpress.XtraEditors.XtraMessageBox.Show("Data will be locked. Are you sure want to save ?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)

            If confirm = Windows.Forms.DialogResult.Yes Then
                Dim query As String = ""

                If move_location Then
                    query = "INSERT INTO tb_purc_rec_asset_history (id_purc_rec_asset, id_employee, id_departement, location, location_date, created_date) SELECT id_purc_rec_asset, id_employee_current, id_departement_current, location_current, location_date, NOW() FROM tb_purc_rec_asset WHERE id_purc_rec_asset = " + id

                    execute_non_query(query, True, "", "", "", "")
                End If

                Dim employee As String = If(SLUEEmployeeCurrent.EditValue.ToString = "", "NULL", "'" + SLUEEmployeeCurrent.EditValue.ToString + "'")

                query = "UPDATE tb_purc_rec_asset SET id_employee_current = " + employee + ", id_departement_current = '" + SLUEDepartmentCurrent.EditValue.ToString + "', location_current = '" + addSlashes(SLUELocationCurrent.EditValue.ToString) + "', location_date = '" + Date.Parse(DELocationDate.EditValue.ToString).ToString("yyyy-MM-dd") + "' WHERE id_purc_rec_asset = " + id

                execute_non_query(query, True, "", "", "", "")

                FormPurcAsset.viewActive()

                FormPurcAsset.GVActive.FocusedRowHandle = find_row(FormPurcAsset.GVActive, "id_purc_rec_asset", id)

                Close()
            End If
        Else
            errorCustom(err)
        End If
    End Sub

    Private Sub SLUEEmployeeCurrent_EditValueChanged(sender As Object, e As EventArgs) Handles SLUEEmployeeCurrent.EditValueChanged
        If loaded Then
            SLUEDepartmentCurrent.EditValue = SLUEEmployeeCurrent.Properties.View.GetFocusedRowCellValue("id_departement")
        End If
    End Sub

    Private Sub SBSaveDescription_Click(sender As Object, e As EventArgs) Handles SBSaveDescription.Click
        Dim err As String = ""

        If MEDescription.Text = "" Then
            err = "Please input description."
        End If

        If err = "" Then
            Dim confirm As DialogResult

            confirm = DevExpress.XtraEditors.XtraMessageBox.Show("Data will be locked. Are you sure want to save ?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)

            If confirm = Windows.Forms.DialogResult.Yes Then
                Dim query As String = "UPDATE tb_purc_rec_asset SET asset_note = '" + addSlashes(MEDescription.EditValue.ToString) + "' WHERE id_purc_rec_asset = " + id

                execute_non_query(query, True, "", "", "", "")

                FormPurcAsset.viewActive()

                FormPurcAsset.GVActive.FocusedRowHandle = find_row(FormPurcAsset.GVActive, "id_purc_rec_asset", id)

                Close()
            End If
        Else
            errorCustom(err)
        End If
    End Sub
End Class