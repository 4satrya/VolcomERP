Public Class FormMasterDesignCOPPropose
    Public id_propose As String = "-1"
    Public is_view As String = "-1"

    Public is_insert_cool_storage As String = get_opt_prod_field("is_insert_cool_storage_ecop")

    Private Sub FormMasterDesignCOPPropose_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Sub load_head()
        viewReportStatus()
        viewCOPType()

        If is_insert_cool_storage Then
            BGCStorageAfter.Visible = True
            BGCStorageBefore.Visible = True
        Else
            BGCStorageAfter.Visible = False
            BGCStorageBefore.Visible = False
        End If

        If id_propose = "-1" Then
            'new
            TENumber.Text = "[auto generate]"
            TEReqBy.Text = "[auto generate]"
            DEDateCreated.EditValue = Now()
            'load det
            load_det()
        Else
            'edit
            LECOPType.Enabled = False
            Dim query As String = "SELECT cp.*,emp.employee_name FROM `tb_design_cop_propose` cp
                                    INNER JOIN tb_m_user usr ON usr.`id_user`=cp.`created_by`
                                    INNER JOIN tb_m_employee emp ON emp.`id_employee`=usr.`id_employee`
                                    WHERE `id_design_cop_propose`='" & id_propose & "'"
            Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
            If data.Rows.Count > 0 Then
                TENumber.Text = data.Rows(0)("number").ToString
                TEReqBy.Text = data.Rows(0)("employee_name").ToString
                DEDateCreated.EditValue = data.Rows(0)("created_date")
                LECOPType.ItemIndex = LECOPType.Properties.GetDataSourceRowIndex("id_cop_propose_type", data.Rows(0)("id_cop_propose_type").ToString)
                '
                MENote.Text = data.Rows(0)("note").ToString
                LEReportStatus.ItemIndex = LEReportStatus.Properties.GetDataSourceRowIndex("id_report_status", data.Rows(0)("id_report_status").ToString)
                '
                If data.Rows(0)("is_promo").ToString = "1" Then
                    CENeedMarketing.Checked = True
                Else
                    CENeedMarketing.Checked = False
                End If

                If data.Rows(0)("is_additional").ToString = "1" Then
                    CEAdditionalCost.Checked = True
                Else
                    CEAdditionalCost.Checked = False
                End If
                '
                load_det()
            End If
        End If
    End Sub

    Private Sub FormMasterDesignCOPPropose_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        load_head()
    End Sub

    Sub viewCOPType()
        Dim query As String = "SELECT id_cop_propose_type,cop_propose_type FROM tb_lookup_cop_propose_type a ORDER BY a.id_cop_propose_type "
        viewLookupQuery(LECOPType, query, 0, "cop_propose_type", "id_cop_propose_type")
    End Sub

    Sub load_det()
        Dim query As String = "SELECT pd.target_cost,pd.`id_design_cop_propose_det`,pd.`id_design`,dsg.`design_code`,dsg.`design_display_name`
,pd.`id_currency_before`,cur_before.`currency` AS currency_before,pd.`id_comp_contact_before`,c_before.`comp_number` AS comp_number_before,c_before.`comp_name` AS comp_name_before,pd.`kurs_before`,pd.`design_cop_before`,pd.`add_cost_before`,(pd.`design_cop_before`-pd.`add_cost_before`) AS design_cop_ex_before
,pd.`id_currency`,cur.`currency`,pd.`id_comp_contact`,c.`comp_number`,c.`comp_name`,pd.`kurs`,pd.`design_cop`,pd.`add_cost`,(pd.`design_cop`-pd.`add_cost`) AS design_cop_ex
FROM `tb_design_cop_propose_det` pd
INNER JOIN tb_m_design dsg ON dsg.`id_design`=pd.`id_design`
INNER JOIN tb_lookup_currency cur ON cur.`id_currency`=pd.`id_currency`
LEFT JOIN tb_lookup_currency cur_before ON cur_before.`id_currency`=pd.`id_currency_before`
LEFT JOIN tb_m_comp_contact cc ON cc.`id_comp_contact`=pd.`id_comp_contact`
LEFT JOIN tb_m_comp c ON c.`id_comp`=cc.`id_comp`
LEFT JOIN tb_m_comp_contact cc_before ON cc_before.`id_comp_contact`=pd.`id_comp_contact_before`
LEFT JOIN tb_m_comp c_before ON c_before.`id_comp`=cc_before.`id_comp`
LEFT JOIN tb_lookup_cool_storage cs_before ON cs_before.`id_cool_storage`=pd.`is_cold_storage_before`
LEFT JOIN tb_lookup_cool_storage cs_after ON cs_after.`id_cool_storage`=pd.`is_cold_storage`
WHERE pd.id_design_cop_propose='" & id_propose & "'"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCItemList.DataSource = data
        BGVItemList.BestFitColumns()
        check_but()
    End Sub

    Sub check_but()
        If Not id_propose = "-1" Then
            '
            BtnAdd.Visible = True
            If BGVItemList.RowCount > 0 Then
                BtnDel.Visible = True
            Else
                BtnDel.Visible = False
            End If
            '
            If is_view = "1" Then
                BtnPrint.Visible = False
                BAttach.Visible = True
            Else
                BtnPrint.Visible = True
                BAttach.Visible = True
            End If
            '
            CEAdditionalCost.Enabled = False
            CENeedMarketing.Enabled = False
            '
            BMark.Visible = True
        Else
            BtnPrint.Visible = False
            BAttach.Visible = False
            BMark.Visible = False
            BtnSave.Visible = True
            PCAddDel.Visible = False
            '
            CEAdditionalCost.Enabled = True
            CENeedMarketing.Enabled = True
        End If
        '
        Dim query As String = "SELECT * FROM tb_report_mark WHERE id_report='" & id_propose & "' AND report_mark_type='" & get_report_mark_type() & "'"
        Dim dt As DataTable = execute_query(query, -1, True, "", "", "", "")
        If dt.Rows.Count > 0 Then
            'submitted
            PCAddDel.Visible = False
            BtnSave.Visible = False
        Else
            'not yet submitted
            PCAddDel.Visible = True
            BtnSave.Visible = True
        End If
    End Sub

    Sub viewReportStatus()
        Dim query As String = "SELECT * FROM tb_lookup_report_status a ORDER BY a.id_report_status "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        viewLookupQuery(LEReportStatus, query, 0, "report_status", "id_report_status")
    End Sub

    Private Sub BtnSave_Click(sender As Object, e As EventArgs) Handles BtnSave.Click
        Dim is_additional As String = "-1"
        Dim is_promo As String = "-1"
        '
        If id_propose = "-1" Then 'new
            If CEAdditionalCost.Checked = True Then
                is_additional = "1"
            Else
                is_additional = "2"
            End If
            '
            If CENeedMarketing.Checked = True Then
                is_promo = "1"
            Else
                is_promo = "2"
            End If

            Dim query As String = "INSERT INTO `tb_design_cop_propose`(id_cop_propose_type,created_by,created_date,note,id_report_status,is_promo,is_additional)
VALUES('" & LECOPType.EditValue.ToString & "','" & id_user & "',NOW(),'" & addSlashes(MENote.Text) & "','1','" & is_promo & "','" & is_additional & "'); SELECT LAST_INSERT_ID(); "
            id_propose = execute_query(query, 0, True, "", "", "", "")

            'query = ""
            'For i As Integer = 0 To BGVItemList.RowCount - 1
            '    Dim id_design As String = BGVItemList.GetRowCellValue(i, "id_design").ToString
            '    Dim target_cost As String = decimalSQL(BGVItemList.GetRowCellValue(i, "target_cost").ToString)

            '    Dim id_currency_before As String = "NULL"
            '    Dim kurs_before As String = "NULL"
            '    Dim design_cop_before As String = "NULL"
            '    Dim id_comp_contact_before As String = "NULL"
            '    Dim add_cost_before As String = "NULL"

            '    If LECOPType.EditValue.ToString = "1" Then
            '        id_currency_before = "'" & BGVItemList.GetRowCellValue(i, "id_currency_before").ToString & "'"
            '        kurs_before = "'" & decimalSQL(BGVItemList.GetRowCellValue(i, "kurs_before").ToString) & "'"
            '        design_cop_before = "'" & decimalSQL(BGVItemList.GetRowCellValue(i, "design_cop_before").ToString) & "'"
            '        id_comp_contact_before = "'" & BGVItemList.GetRowCellValue(i, "id_comp_contact_before").ToString & "'"
            '        add_cost_before = "'" & decimalSQL(BGVItemList.GetRowCellValue(i, "add_cost_before").ToString) & "'"
            '    End If

            '    '
            '    Dim id_currency As String = BGVItemList.GetRowCellValue(i, "id_currency").ToString
            '    Dim kurs As String = decimalSQL(BGVItemList.GetRowCellValue(i, "kurs").ToString)
            '    Dim design_cop As String = decimalSQL(BGVItemList.GetRowCellValue(i, "design_cop").ToString)
            '    Dim id_comp_contact As String = BGVItemList.GetRowCellValue(i, "id_comp_contact").ToString
            '    Dim add_cost As String = decimalSQL(BGVItemList.GetRowCellValue(i, "add_cost").ToString)
            '    '
            '    If Not i = 0 Then
            '        query += ","
            '    End If
            '    query += "('" & id_propose & "','" & target_cost & "','" & id_design & "'," & id_currency_before & "," & kurs_before & "," & design_cop_before & "," & id_comp_contact_before & "," & add_cost_before & ",'" & id_currency & "','" & kurs & "','" & design_cop & "','" & id_comp_contact & "','" & add_cost & "')"
            'Next
            ''
            'query = "INSERT INTO tb_design_cop_propose_det(id_design_cop_propose,target_cost,id_design,id_currency_before,kurs_before,design_cop_before,id_comp_contact_before,add_cost_before,id_currency,kurs,design_cop,id_comp_contact,add_cost) VALUES" & query
            'execute_non_query(query, True, "", "", "", "")

            query = "CALL gen_number('" & id_propose & "','150')"
            execute_non_query(query, True, "", "", "", "")

            infoCustom("Proposal created")
            FormMasterDesignCOP.load_propose()
            load_head()
            'Close()
        Else 'edit
            If BGVItemList.RowCount <= 0 Then
                warningCustom("Please select design to revise first")
            Else
                Dim query As String = "UPDATE `tb_design_cop_propose` SET note='" & addSlashes(MENote.Text) & "' WHERE id_design_cop_propose='" & id_propose & "'"
                execute_non_query(query, True, "", "", "", "")
                '
                infoCustom("Proposal updated")
                FormMasterDesignCOP.load_propose()
                'Close()
            End If
        End If
    End Sub

    Private Sub BtnAdd_Click(sender As Object, e As EventArgs) Handles BtnAdd.Click
        FormMasterDesignCOPProposeDet.ShowDialog()
    End Sub

    Private Sub BtnCancel_Click(sender As Object, e As EventArgs) Handles BtnCancel.Click
        Close()
    End Sub

    Function get_report_mark_type()
        Dim rmt As String = ""
        If CEAdditionalCost.Checked = True Then
            If CENeedMarketing.Checked = True Then
                rmt = "173"
            Else
                rmt = "150"
            End If
        Else
            If CENeedMarketing.Checked = True Then
                rmt = "172"
            Else
                rmt = "155"
            End If
        End If
        Return rmt
    End Function

    Private Sub BMark_Click(sender As Object, e As EventArgs) Handles BMark.Click
        FormReportMark.report_mark_type = get_report_mark_type()
        FormReportMark.is_view = is_view
        FormReportMark.id_report = id_propose
        FormReportMark.ShowDialog()
    End Sub

    Private Sub BtnDel_Click(sender As Object, e As EventArgs) Handles BtnDel.Click
        Dim confirm As DialogResult = DevExpress.XtraEditors.XtraMessageBox.Show("Are you sure want to delete this item?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
        If confirm = Windows.Forms.DialogResult.Yes Then
            'BGVItemList.DeleteSelectedRows()
            Dim query As String = "DELETE FROM tb_design_cop_propose_det WHERE id_design_cop_propose_det='" & BGVItemList.GetFocusedRowCellValue("id_design_cop_propose_det").ToString & "'"
            execute_non_query(query, True, "", "", "", "")
            load_det()
            check_but()
        End If
    End Sub

    Private Sub BtnPrint_Click(sender As Object, e As EventArgs) Handles BtnPrint.Click
        If Not check_allow_print(LEReportStatus.EditValue.ToString, get_report_mark_type(), id_propose) Then
            warningCustom("Can't print, please complete all approval on system first")
        Else
            ReportDesignCOPPropose.id_propose = id_propose
            ReportDesignCOPPropose.rmt = get_report_mark_type()
            '
            If get_setup_field("id_role_super_admin") = id_role_login Then
                FormProdDemandPrintOpt.rmt = get_report_mark_type()
                FormProdDemandPrintOpt.id = id_propose
                FormProdDemandPrintOpt.ShowDialog()
            End If
            '
            ReportDesignCOPPropose.dt = GCItemList.DataSource

            Dim Report As New ReportDesignCOPPropose()
            ' Show the report's preview. 
            Dim Tool As DevExpress.XtraReports.UI.ReportPrintTool = New DevExpress.XtraReports.UI.ReportPrintTool(Report)
            Tool.ShowPreview()
        End If
    End Sub

    Private Sub BAttach_Click(sender As Object, e As EventArgs) Handles BAttach.Click
        Cursor = Cursors.WaitCursor
        FormDocumentUpload.id_report = id_propose
        Dim is_addcost As Boolean = False
        '
        For i As Integer = 0 To BGVItemList.RowCount - 1
            If Not BGVItemList.GetRowCellValue(i, "add_cost_before") = 0 Or Not BGVItemList.GetRowCellValue(i, "add_cost") = 0 Then
                is_addcost = True
            End If
        Next
        '
        FormDocumentUpload.report_mark_type = get_report_mark_type()
        '
        FormDocumentUpload.is_no_delete = "1"

        FormDocumentUpload.ShowDialog()
        Cursor = Cursors.Default
    End Sub

    Private Sub LECOPType_EditValueChanged(sender As Object, e As EventArgs) Handles LECOPType.EditValueChanged
        If BGVItemList.RowCount > 0 Then
            Dim confirm As DialogResult = DevExpress.XtraEditors.XtraMessageBox.Show("Are you want to change type? All record will be reset", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
            If confirm = Windows.Forms.DialogResult.Yes Then
                For i As Integer = BGVItemList.RowCount To 0 Step -1
                    BGVItemList.DeleteRow(i)
                Next
            End If
        End If
        '
        If LECOPType.EditValue.ToString = "1" Then
            GBAfter.Caption = "After"
            GBBefore.Visible = True
        Else
            GBAfter.Caption = "Propose"
            GBBefore.Visible = False
        End If
    End Sub

    Private Sub BGVItemList_DoubleClick(sender As Object, e As EventArgs) Handles BGVItemList.DoubleClick
        If BGVItemList.RowCount > 0 Then
            FormMasterDesignCOPProposeDet.id_det = BGVItemList.GetFocusedRowCellValue("id_design_cop_propose_det")
            FormMasterDesignCOPProposeDet.is_view = "1"
            FormMasterDesignCOPProposeDet.ShowDialog()
        End If
    End Sub
End Class