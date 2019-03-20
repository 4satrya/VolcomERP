Public Class FormItemCatMappingDet
    Public id As String = "-1"
    Public is_view As String = "-1"
    Dim id_report_status As String = "-1"
    Dim is_confirm As String = "-1"
    Public show_mark As Boolean = False

    Private Sub FormItemCatMappingDet_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        viewReportStatus()
        viewDept()
        viewCat()
        actionLoad()
    End Sub

    Private Sub FormItemCatMappingDet_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Try
            FormItemCoaProposeAdd.Close()
        Catch ex As Exception
        End Try
        Dispose()
    End Sub


    'View Data
    Sub viewReportStatus()
        Dim query As String = "SELECT * FROM tb_lookup_report_status a ORDER BY a.id_report_status "
        'Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        viewLookupQuery(LEReportStatus, query, 0, "report_status", "id_report_status")
    End Sub

    Sub viewDept()
        Cursor = Cursors.WaitCursor
        Dim query As String = "SELECT 0 as id_departement, 'All departement' as departement UNION  "
        query += "(SELECT id_departement,departement FROM tb_m_departement a ORDER BY a.departement ASC) "
        viewLookupQuery(LEDept, query, 0, "departement", "id_departement")
        Cursor = Cursors.Default
    End Sub

    Sub viewCat()
        Cursor = Cursors.WaitCursor
        Dim query As String = "SELECT 0 AS `id_item_cat`, 'All Category' AS `item_cat`
        UNION ALL
        SELECT c.id_item_cat, c.item_cat FROM tb_item_cat c ORDER BY id_item_cat ASC"
        viewSearchLookupQuery(SLECat, query, "id_item_cat", "item_cat", "id_item_cat")
        Cursor = Cursors.Default
    End Sub

    Sub viewCOA()
        Dim query As String = "SELECT a.id_acc, a.acc_name, a.acc_description, a.id_acc_parent, 
        a.id_acc_parent, a.id_acc_cat, a.id_is_det, a.id_status, a.id_comp
        FROM tb_a_acc a WHERE a.id_status=1 AND a.id_is_det=2 "
        viewSearchLookupQuery(SLEExp, query, "id_acc", "acc_description", "id_acc")
        viewSearchLookupQuery(SLEInv, query, "id_acc", "acc_description", "id_acc")
    End Sub

    Sub loadMain()
        Dim query_c As New ClassItemCat()
        Dim query As String = query_c.queryMappingPropose("AND cp.id_item_coa_propose=" + id + "", "2")
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")

        id_report_status = data.Rows(0)("id_report_status").ToString
        is_confirm = data.Rows(0)("is_confirm").ToString
        TxtNumber.Text = data.Rows(0)("number").ToString
        DECreated.EditValue = data.Rows(0)("created_date")
        MENote.Text = data.Rows(0)("note").ToString
        LEReportStatus.ItemIndex = LEReportStatus.Properties.GetDataSourceRowIndex("id_report_status", data.Rows(0)("id_report_status").ToString)

        'load general account-propose
        TxtProposeCodeInvStore.Text = data.Rows(0)("code_inv_store").ToString
        TxtProposeDescInvStore.Text = data.Rows(0)("name_inv_store").ToString
        TxtProposeCodeHutang.Text = data.Rows(0)("code_hutang").ToString
        TxtProposeDescHutang.Text = data.Rows(0)("name_hutang").ToString
        TxtProposeCodeInvWH.Text = data.Rows(0)("code_inv_wh").ToString
        TxtProposeDescInvWH.Text = data.Rows(0)("name_inv_wh").ToString

        'load general account-current
        Dim qcg As String = "SELECT h.acc_name AS `code_hutang`, h.acc_description AS `name_hutang`,
        r.acc_name AS `code_inv_store`, r.acc_description AS `name_inv_store`,
        t.acc_name AS `code_inv_wh`, t.acc_description AS `name_inv_wh`
        FROM tb_opt_purchasing o
        LEFT JOIN tb_a_acc h ON h.id_acc = o.acc_coa_hutang
        LEFT JOIN tb_a_acc r ON r.id_acc = o.acc_coa_receive
        LEFT JOIN tb_a_acc t ON t.id_acc = o.acc_coa_trf "
        Dim dcg As DataTable = execute_query(qcg, -1, True, "", "", "", "")
        TxtCurrentCodeInvStore.Text = dcg.Rows(0)("code_inv_store").ToString
        TxtCurrentDescInvStore.Text = dcg.Rows(0)("name_inv_store").ToString
        TxtCurrentCodeHutang.Text = dcg.Rows(0)("code_hutang").ToString
        TxtCurrentDescHutang.Text = dcg.Rows(0)("name_hutang").ToString
        TxtCurrentCodeInvWH.Text = dcg.Rows(0)("code_inv_wh").ToString
        TxtCurrentDescInvWH.Text = dcg.Rows(0)("name_inv_wh").ToString
    End Sub

    Sub actionLoad()
        CheckEditCat.EditValue = False
        SLEInv.Enabled = False

        loadMain()
        viewDetail()
        allow_status()
        If show_mark Then
            openMark()
        End If
    End Sub

    Sub viewDetail()
        'dept
        Dim dept As String = ""
        If LEDept.EditValue.ToString <> "0" Then
            dept = "AND m.id_departement='" + LEDept.EditValue.ToString + "' "
        Else
            dept = ""
        End If

        'cat
        Dim cat As String = ""
        If SLECat.EditValue.ToString <> "0" Then
            cat = "AND m.id_item_cat='" + SLECat.EditValue.ToString + "' "
        Else
            cat = ""
        End If

        Dim query As String = "SELECT m.id_item_coa_propose_det, m.id_item_coa_propose, m.id_item_cat, c.item_cat, 
        m.id_departement, d.departement, 
        m.id_coa_in, ci.acc_name AS `inv_acc`, ci.acc_description AS `inv_desc`,
        m.id_coa_out, co.acc_name AS `exp_acc`,co.acc_description AS `exp_desc`, 
        m.is_request, IF(m.is_request=1,'Yes', 'No') AS `is_request_v`, 
        m.is_expense, IF(m.is_expense=1,'Yes', 'No') AS `is_expense_v`
        FROM tb_item_coa_propose_det m
        INNER JOIN tb_item_cat c ON c.id_item_cat = m.id_item_cat
        INNER JOIN  tb_m_departement d ON d.id_departement = m.id_departement
        INNER JOIN tb_a_acc co ON co.id_acc = m.id_coa_out
        LEFT JOIN tb_a_acc ci ON ci.id_acc = m.id_coa_in
        WHERE m.id_item_coa_propose=" + id + " " + dept + cat
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCMaping.DataSource = data
    End Sub

    Sub allow_status()
        BtnAttachment.Visible = True
        BtnCancell.Visible = True
        If is_confirm = "2" Then
            BtnConfirm.Visible = True
            BtnMark.Visible = False
            BtnAddMulti.Visible = True
            BtnDeleteMulti.Visible = True
            BtnEdit.Visible = True
            MENote.Enabled = True
            GCMaping.ContextMenuStrip = ContextMenuStrip1
            BtnSetInvStore.Enabled = True
            BtnClearInvStore.Enabled = True
            BtnSetInvHutang.Enabled = True
            BtnClearHutang.Enabled = True
            BtnSetInvWH.Enabled = True
            BtnClearInvWH.Enabled = True
        Else
            BtnConfirm.Visible = False
            BtnMark.Visible = True
            BtnAddMulti.Visible = False
            BtnDeleteMulti.Visible = False
            BtnEdit.Visible = False
            MENote.Enabled = False
            GCMaping.ContextMenuStrip = Nothing
            BtnSetInvStore.Enabled = False
            BtnClearInvStore.Enabled = False
            BtnSetInvHutang.Enabled = False
            BtnClearHutang.Enabled = False
            BtnSetInvWH.Enabled = False
            BtnClearInvWH.Enabled = False
        End If

        If check_print_report_status(id_report_status) Then
            BtnPrint.Visible = True
        Else
            BtnPrint.Visible = False
        End If

        If id_report_status = "6" Then
            BtnCancell.Visible = False
        ElseIf id_report_status = "5" Then
            BtnCancell.Visible = False
            BtnConfirm.Visible = False
            BtnAddMulti.Visible = False
            BtnDeleteMulti.Visible = False
            BtnEdit.Visible = False
            MENote.Enabled = False
            GCMaping.ContextMenuStrip = Nothing
            BtnSetInvStore.Enabled = False
            BtnClearInvStore.Enabled = False
            BtnSetInvHutang.Enabled = False
            BtnClearHutang.Enabled = False
            BtnSetInvWH.Enabled = False
            BtnClearInvWH.Enabled = False
        End If
    End Sub

    Private Sub BtnMark_Click(sender As Object, e As EventArgs) Handles BtnMark.Click
        openMark()
    End Sub

    Sub openMark()
        Cursor = Cursors.WaitCursor
        FormReportMark.report_mark_type = "135"
        FormReportMark.id_report = id
        FormReportMark.is_view = is_view
        FormReportMark.form_origin = Name
        FormReportMark.ShowDialog()
        Cursor = Cursors.Default
    End Sub

    Private Sub BtnConfirm_Click(sender As Object, e As EventArgs) Handles BtnConfirm.Click
        Dim confirm As DialogResult = DevExpress.XtraEditors.XtraMessageBox.Show("Are you sure you want to confirm this propose ?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
        If confirm = Windows.Forms.DialogResult.Yes Then
            Cursor = Cursors.WaitCursor
            'update confirm
            Dim query As String = "UPDATE tb_item_coa_propose SET is_confirm=1 WHERE id_item_coa_propose='" + id + "'"
            execute_non_query(query, True, "", "", "", "")

            'submit approval
            submit_who_prepared(135, id, id_user)
            actionLoad()
            Cursor = Cursors.Default
        End If
    End Sub

    Private Sub BtnPrint_Click(sender As Object, e As EventArgs) Handles BtnPrint.Click
        print_raw(GCMaping, "")
    End Sub

    Private Sub BtnAttachment_Click(sender As Object, e As EventArgs) Handles BtnAttachment.Click
        Cursor = Cursors.WaitCursor
        FormDocumentUpload.report_mark_type = "135"
        FormDocumentUpload.id_report = id
        If is_view = "1" Or id_report_status = "6" Or id_report_status = "5" Then
            FormDocumentUpload.is_view = "1"
        End If
        FormDocumentUpload.ShowDialog()
        Cursor = Cursors.Default
    End Sub

    Private Sub BtnCancell_Click(sender As Object, e As EventArgs) Handles BtnCancell.Click
        Dim confirm As DialogResult = DevExpress.XtraEditors.XtraMessageBox.Show("Are you sure you want to cancelled this propose ?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
        If confirm = Windows.Forms.DialogResult.Yes Then
            Cursor = Cursors.WaitCursor
            Dim query As String = "UPDATE tb_item_coa_propose SET id_report_status=5 WHERE id_item_coa_propose='" + id + "'"
            execute_non_query(query, True, "", "", "", "")

            'nonaktif mark
            Dim queryrm = String.Format("UPDATE tb_report_mark SET report_mark_lead_time=NULL,report_mark_start_datetime=NULL WHERE report_mark_type='{0}' AND id_report='{1}' AND id_report_status>'1'", 135, id, "5")
            execute_non_query(queryrm, True, "", "", "", "")

            FormItemCatMapping.viewPropose()
            FormItemCatMapping.GVPropose.FocusedRowHandle = find_row(FormItemCatMapping.GVPropose, "id_item_coa_propose", id)
            actionLoad()
            Cursor = Cursors.Default
        End If
    End Sub

    Private Sub BtnDelete_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub BtnAdd_Click(sender As Object, e As EventArgs)
        'Cursor = Cursors.WaitCursor
        'FormItemCatProposeAdd.ShowDialog()
        'Cursor = Cursors.Default
    End Sub

    Private Sub MENote_EditValueChanged(sender As Object, e As EventArgs) Handles MENote.EditValueChanged
        If is_confirm = 2 And id_report_status = "1" Then
            Dim query_upd As String = "UPDATE tb_item_coa_propose SET note='" + addSlashes(MENote.Text) + "' WHERE id_item_coa_propose='" + id + "' "
            execute_non_query(query_upd, True, "", "", "", "")
            FormItemCatMapping.viewPropose()
            FormItemCatMapping.GVPropose.FocusedRowHandle = find_row(FormItemCatMapping.GVPropose, "id_item_coa_propose", id)
        End If
    End Sub

    Private Sub XTPNewMapping_Paint(sender As Object, e As PaintEventArgs)

    End Sub

    Private Sub LEDeptSum_EditValueChanged(sender As Object, e As EventArgs) Handles LEDeptSum.EditValueChanged

    End Sub

    Private Sub CheckEditCat_CheckedChanged(sender As Object, e As EventArgs) Handles CheckEditCat.CheckedChanged
        If CheckEditCat.EditValue = True Then
            SLEInv.Enabled = True
        Else
            SLEInv.Enabled = False
        End If
    End Sub

    Private Sub BtnAdd_Click_1(sender As Object, e As EventArgs) Handles BtnAdd.Click
        add()
    End Sub

    Sub add()
        Dim id_item_cat As String = LECat.EditValue.ToString
        Dim id_departement As String = LEDeptSum.EditValue.ToString
        Dim id_coa_out As String = SLEExp.EditValue.ToString
        Dim id_coa_in As String = ""
        If CheckEditCat.EditValue = True Then
            id_coa_in = SLEInv.EditValue.ToString
        Else
            id_coa_in = "NULL"
        End If
        Dim is_request As String = ""
        If CheckEditReq.EditValue = True Then
            is_request = "1"
        Else
            is_request = "2"
        End If
        Dim is_expense As String = ""
        If CheckEditExpense.EditValue = True Then
            is_expense = "1"
        Else
            is_expense = "2"
        End If
    End Sub

    Private Sub SimpleButton2_Click(sender As Object, e As EventArgs) Handles BtnAddMulti.Click
        Cursor = Cursors.WaitCursor
        FormItemCoaProposeAdd.Show()
        PanelControlBottom.Visible = False
        Cursor = Cursors.Default
    End Sub

    Private Sub BtnDeleteMulti_Click(sender As Object, e As EventArgs) Handles BtnDeleteMulti.Click
        del()
    End Sub

    Sub del()
        If GVMapping.RowCount > 0 And GVMapping.FocusedRowHandle >= 0 Then
            Dim confirm As DialogResult = DevExpress.XtraEditors.XtraMessageBox.Show("Are you sure you want to delete this mapping ?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
            If confirm = Windows.Forms.DialogResult.Yes Then
                Dim query As String = "DELETE FROM tb_item_coa_propose_det WHERE id_item_coa_propose_det='" + GVMapping.GetFocusedRowCellValue("id_item_coa_propose_det").ToString + "'"
                execute_non_query(query, True, "", "", "", "")
                viewDetail()
            End If
        End If
    End Sub

    Private Sub DeleteToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DeleteToolStripMenuItem.Click
        del()
    End Sub

    Private Sub LEDept_EditValueChanged(sender As Object, e As EventArgs) Handles LEDept.EditValueChanged
        viewDetail()
    End Sub

    Private Sub LECategory_EditValueChanged(sender As Object, e As EventArgs)
        viewDetail()
    End Sub

    Private Sub BtnSetInvWH_Click(sender As Object, e As EventArgs) Handles BtnSetInvWH.Click
        Cursor = Cursors.WaitCursor
        FormPopUpCOA.id_pop_up = "10"
        FormPopUpCOA.ShowDialog()
        Cursor = Cursors.Default
    End Sub

    Private Sub BtnClearInvStore_Click(sender As Object, e As EventArgs) Handles BtnClearInvStore.Click
        Cursor = Cursors.WaitCursor
        Dim query As String = "UPDATE tb_item_coa_propose SET acc_coa_receive=NULL WHERE id_item_coa_propose=" + id + " "
        execute_non_query(query, True, "", "", "", "")
        loadMain()
        Cursor = Cursors.Default
    End Sub

    Private Sub BtnSetInvHutang_Click(sender As Object, e As EventArgs) Handles BtnSetInvHutang.Click
        Cursor = Cursors.WaitCursor
        FormPopUpCOA.id_pop_up = "9"
        FormPopUpCOA.ShowDialog()
        Cursor = Cursors.Default
    End Sub

    Private Sub BtnClearHutang_Click(sender As Object, e As EventArgs) Handles BtnClearHutang.Click
        Cursor = Cursors.WaitCursor
        Dim query As String = "UPDATE tb_item_coa_propose SET acc_coa_hutang=NULL WHERE id_item_coa_propose=" + id + " "
        execute_non_query(query, True, "", "", "", "")
        loadMain()
        Cursor = Cursors.Default
    End Sub

    Private Sub BtnClearInvWH_Click(sender As Object, e As EventArgs) Handles BtnClearInvWH.Click
        Cursor = Cursors.WaitCursor
        Dim query As String = "UPDATE tb_item_coa_propose SET acc_coa_trf=NULL WHERE id_item_coa_propose=" + id + " "
        execute_non_query(query, True, "", "", "", "")
        loadMain()
        Cursor = Cursors.Default
    End Sub

    Private Sub BtnSetInvStore_Click(sender As Object, e As EventArgs) Handles BtnSetInvStore.Click
        Cursor = Cursors.WaitCursor
        FormPopUpCOA.id_pop_up = "8"
        FormPopUpCOA.ShowDialog()
        Cursor = Cursors.Default
    End Sub

    Private Sub BtnEdit_Click(sender As Object, e As EventArgs) Handles BtnEdit.Click
        edit()
    End Sub

    Sub edit()
        If GVMapping.RowCount > 0 And GVMapping.FocusedRowHandle >= 0 Then
            Cursor = Cursors.WaitCursor
            FormItemCatMappingEdit.id_detail = GVMapping.GetFocusedRowCellValue("id_item_coa_propose_det").ToString
            FormItemCatMappingEdit.ShowDialog()
            Cursor = Cursors.Default
        End If
    End Sub

    Private Sub EditToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EditToolStripMenuItem.Click
        edit()
    End Sub

    Private Sub SLECat_EditValueChanged(sender As Object, e As EventArgs) Handles SLECat.EditValueChanged
        viewDetail()
    End Sub
End Class