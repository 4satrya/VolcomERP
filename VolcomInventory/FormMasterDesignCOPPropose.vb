Public Class FormMasterDesignCOPPropose
    Public id_propose As String = "-1"
    Public is_view As String = "-1"

    Private Sub FormMasterDesignCOPPropose_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub FormMasterDesignCOPPropose_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        viewReportStatus()
        viewCOPType()

        If id_propose = "-1" Then
            'new
            TENumber.Text = "[auto generate]"
            TEReqBy.Text = "[auto generate]"
            DEDateCreated.EditValue = Now()
            'load det
            load_det()
            BtnPrint.Visible = False
            BAttach.Visible = False
            BMark.Visible = False
            BtnSave.Visible = True
            PCAddDel.Visible = True
        Else
            'edit
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
                '
                load_det()
                '

            End If

            CENeedMarketing.Enabled = False
            MENote.Enabled = False

            If is_view = "1" Then
                BtnPrint.Visible = False
                BAttach.Visible = True
            Else
                BtnPrint.Visible = True
                BAttach.Visible = True
            End If

            BMark.Visible = True
            BtnSave.Visible = False
            PCAddDel.Visible = False
        End If
    End Sub

    Sub viewCOPType()
        Dim query As String = "SELECT id_cop_propose_type,cop_propose_type FROM tb_lookup_cop_propose_type a ORDER BY a.id_cop_propose_type "
        viewLookupQuery(LECOPType, query, 0, "cop_propose_type", "id_cop_propose_type")
    End Sub

    Sub load_det()
        Dim query As String = "SELECT pd.`id_design_cop_propose_det`,pd.`id_design`,dsg.`design_code`,dsg.`design_display_name`
,pd.`id_currency_before`,cur_before.`currency` AS currency_before,pd.`id_comp_contact_before`,c_before.`comp_number` AS comp_number_before,c_before.`comp_name` AS comp_name_before,pd.`kurs_before`,pd.`design_cop_before`,pd.`add_cost_before`,(pd.`design_cop_before`-pd.`add_cost_before`) AS design_cop_ex_before
,pd.`id_currency`,cur.`currency`,pd.`id_comp_contact`,c.`comp_number`,c.`comp_name`,pd.`kurs`,pd.`design_cop`,pd.`add_cost`,(pd.`design_cop`-pd.`add_cost`) AS design_cop_ex
FROM `tb_design_cop_propose_det` pd
INNER JOIN tb_m_design dsg ON dsg.`id_design`=pd.`id_design`
INNER JOIN tb_lookup_currency cur ON cur.`id_currency`=pd.`id_currency`
INNER JOIN tb_lookup_currency cur_before ON cur_before.`id_currency`=pd.`id_currency_before`
INNER JOIN tb_m_comp_contact cc ON cc.`id_comp_contact`=pd.`id_comp_contact`
INNER JOIN tb_m_comp c ON c.`id_comp`=cc.`id_comp`
INNER JOIN tb_m_comp_contact cc_before ON cc_before.`id_comp_contact`=pd.`id_comp_contact_before`
INNER JOIN tb_m_comp c_before ON c_before.`id_comp`=cc_before.`id_comp`
WHERE pd.id_design_cop_propose='" & id_propose & "'"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCItemList.DataSource = data
        BGVItemList.BestFitColumns()
        check_but()
    End Sub

    Sub check_but()
        If id_propose = "-1" Then
            PCAddDel.Visible = True
            BtnAdd.Visible = True
            If BGVItemList.RowCount > 0 Then
                BtnDel.Visible = True
            Else
                BtnDel.Visible = False
            End If
        Else
            PCAddDel.Visible = False
        End If
    End Sub

    Sub viewReportStatus()
        Dim query As String = "SELECT * FROM tb_lookup_report_status a ORDER BY a.id_report_status "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        viewLookupQuery(LEReportStatus, query, 0, "report_status", "id_report_status")
    End Sub

    Private Sub BtnSave_Click(sender As Object, e As EventArgs) Handles BtnSave.Click
        If id_propose = "-1" Then
            If BGVItemList.RowCount <= 0 Then
                warningCustom("Please select design to revise first")
            Else
                Dim query As String = "INSERT INTO `tb_design_cop_propose`(id_cop_propose_type,created_by,created_date,note,id_report_status)
VALUES('" & LECOPType.EditValue.ToString & "','" & id_user & "',NOW(),'" & MENote.Text & "','1'); SELECT LAST_INSERT_ID(); "
                id_propose = execute_query(query, 0, True, "", "", "", "")
                'detail
                query = ""
                For i As Integer = 0 To BGVItemList.RowCount - 1
                    Dim id_design As String = BGVItemList.GetRowCellValue(i, "id_design").ToString
                    Dim id_currency_before As String = BGVItemList.GetRowCellValue(i, "id_currency_before").ToString
                    Dim kurs_before As String = decimalSQL(BGVItemList.GetRowCellValue(i, "kurs_before").ToString)
                    Dim design_cop_before As String = decimalSQL(BGVItemList.GetRowCellValue(i, "design_cop_before").ToString)
                    Dim id_comp_contact_before As String = BGVItemList.GetRowCellValue(i, "id_comp_contact_before").ToString
                    Dim add_cost_before As String = decimalSQL(BGVItemList.GetRowCellValue(i, "add_cost_before").ToString)
                    '
                    Dim id_currency As String = BGVItemList.GetRowCellValue(i, "id_currency").ToString
                    Dim kurs As String = decimalSQL(BGVItemList.GetRowCellValue(i, "kurs").ToString)
                    Dim design_cop As String = decimalSQL(BGVItemList.GetRowCellValue(i, "design_cop").ToString)
                    Dim id_comp_contact As String = BGVItemList.GetRowCellValue(i, "id_comp_contact").ToString
                    Dim add_cost As String = decimalSQL(BGVItemList.GetRowCellValue(i, "add_cost").ToString)
                    '
                    If Not i = 0 Then
                        query += ","
                    End If
                    query += "('" & id_propose & "','" & id_design & "','" & id_currency_before & "','" & kurs_before & "','" & design_cop_before & "','" & id_comp_contact_before & "','" & add_cost_before & "','" & id_currency & "','" & kurs & "','" & design_cop & "','" & id_comp_contact & "','" & add_cost & "')"
                Next
                query = "INSERT INTO tb_design_cop_propose_det(id_design_cop_propose,id_design,id_currency_before,kurs_before,design_cop_before,id_comp_contact_before,add_cost_before,id_currency,kurs,design_cop,id_comp_contact,add_cost) VALUES" & query
                execute_non_query(query, True, "", "", "", "")
                query = "CALL gen_number('" & id_propose & "','150')"
                execute_non_query(query, True, "", "", "", "")
                '
                infoCustom("Proposal created")
                FormMasterDesignCOP.load_propose()
                Close()
            End If
        End If
    End Sub

    Private Sub BtnAdd_Click(sender As Object, e As EventArgs) Handles BtnAdd.Click
        FormMasterDesignCOPProposeDet.ShowDialog()
    End Sub

    Private Sub BtnCancel_Click(sender As Object, e As EventArgs) Handles BtnCancel.Click
        Close()
    End Sub

    Private Sub BMark_Click(sender As Object, e As EventArgs) Handles BMark.Click
        Dim is_addcost As Boolean = False
        '
        For i As Integer = 0 To BGVItemList.RowCount - 1
            If Not BGVItemList.GetRowCellValue(i, "add_cost_before") = 0 Or Not BGVItemList.GetRowCellValue(i, "add_cost") = 0 Then
                is_addcost = True
            End If
        Next
        '
        If is_addcost = True Then
            If CENeedMarketing.Checked = True Then
                FormReportMark.report_mark_type = "173"
            Else
                FormReportMark.report_mark_type = "150"
            End If
            FormReportMark.is_view = is_view
            FormReportMark.id_report = id_propose
            FormReportMark.ShowDialog()
        Else
            If CENeedMarketing.Checked = True Then
                FormReportMark.report_mark_type = "172"
            Else
                FormReportMark.report_mark_type = "155"
            End If
            FormReportMark.is_view = is_view
            FormReportMark.id_report = id_propose
            FormReportMark.ShowDialog()
        End If
    End Sub

    Private Sub BtnDel_Click(sender As Object, e As EventArgs) Handles BtnDel.Click
        Dim confirm As DialogResult = DevExpress.XtraEditors.XtraMessageBox.Show("Are you sure want to delete this item?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
        If confirm = Windows.Forms.DialogResult.Yes Then
            BGVItemList.DeleteSelectedRows()
            check_but()
        End If
    End Sub

    Private Sub BtnPrint_Click(sender As Object, e As EventArgs) Handles BtnPrint.Click
        ReportDesignCOPPropose.id_propose = id_propose
        Dim is_addcost As Boolean = False
        For i As Integer = 0 To BGVItemList.RowCount - 1
            If Not BGVItemList.GetRowCellValue(i, "add_cost_before") = 0 Or Not BGVItemList.GetRowCellValue(i, "add_cost") = 0 Then
                is_addcost = True
            End If
        Next
        If is_addcost = True Then
            If CENeedMarketing.Checked = True Then
                ReportDesignCOPPropose.rmt = "173"
                FormProdDemandPrintOpt.rmt = "173"
            Else
                ReportDesignCOPPropose.rmt = "150"
                FormProdDemandPrintOpt.rmt = "150"
            End If
        Else
            If CENeedMarketing.Checked = True Then
                ReportDesignCOPPropose.rmt = "172"
                FormProdDemandPrintOpt.rmt = "172"
            Else
                ReportDesignCOPPropose.rmt = "155"
                FormProdDemandPrintOpt.rmt = "155"
            End If
        End If
        '
        If LEReportStatus.EditValue.ToString = "1" Or get_setup_field("id_role_super_admin") = id_role_login Then
            FormProdDemandPrintOpt.id = id_propose
            FormProdDemandPrintOpt.ShowDialog()
        End If
        '
        ReportDesignCOPPropose.dt = GCItemList.DataSource

        Dim Report As New ReportDesignCOPPropose()
        ' Show the report's preview. 
        Dim Tool As DevExpress.XtraReports.UI.ReportPrintTool = New DevExpress.XtraReports.UI.ReportPrintTool(Report)
        Tool.ShowPreview()
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
        If is_addcost = True Then
            If CENeedMarketing.Checked = True Then
                FormDocumentUpload.report_mark_type = "173"
            Else
                FormDocumentUpload.report_mark_type = "150"
            End If
        Else
            If CENeedMarketing.Checked = True Then
                FormDocumentUpload.report_mark_type = "172"
            Else
                FormDocumentUpload.report_mark_type = "155"
            End If
        End If
        '
        FormDocumentUpload.is_no_delete = "1"

        FormDocumentUpload.ShowDialog()
        Cursor = Cursors.Default
    End Sub
End Class