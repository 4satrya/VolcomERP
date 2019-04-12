Public Class FormPurcAssetDet
    Public id As String = "-1"
    Public action As String = "-1"
    Public id_purc_rec As String = "-1"
    Dim id_purc_order As String = "-1"
    Public is_confirm As String = "-1"
    Public is_view As String = "-1"
    Dim id_report_status As String = "-1"
    Public find_accum As Boolean = False

    Private Sub FormPurcAssetDet_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        viewCOA()
        actionLoad()
    End Sub

    Sub viewCOA()
        Dim query As String = "SELECT a.id_acc, a.acc_name, a.acc_description, a.id_acc_parent, 
        a.id_acc_parent, a.id_acc_cat, a.id_is_det, a.id_status, a.id_comp
        FROM tb_a_acc a WHERE a.id_status=1 AND a.id_is_det=2 "
        viewSearchLookupQuery(SLEAccountFixedAsset, query, "id_acc", "acc_description", "id_acc")
        viewSearchLookupQuery(SLEDep, query, "id_acc", "acc_description", "id_acc")
        viewSearchLookupQuery(SLEAccumDep, query, "id_acc", "acc_description", "id_acc")
    End Sub

    Sub actionLoad()
        If action = "ins" Then
        ElseIf action = "upd" Then


            Dim a As New ClassPurcAsset()
            Dim query As String = a.queryMain("AND a.id_purc_rec_asset=" + id + "", "1", find_accum)
            Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
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
            allow_status()
        End If
    End Sub

    Sub allow_status()
        BtnCreate.Visible = False

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
                Dim id_acc_dep As String = SLEDep.EditValue.ToString
                Dim id_acc_dep_accum As String = SLEAccumDep.EditValue.ToString
                Dim accum_dep As String = decimalSQL(TxtAccumDep.EditValue.ToString)
                Dim query As String = "UPDATE tb_purc_rec_asset SET id_parent='" + id + "',asset_name='" + asset_name + "',
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
End Class