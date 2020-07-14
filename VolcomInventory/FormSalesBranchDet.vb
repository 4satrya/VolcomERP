Public Class FormSalesBranchDet
    Public id As String = "-1"
    Public action As String = "-1"
    Public rmt As String = "254"
    Public id_report_status As String = "1"

    Private Sub FormSalesBranchDet_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        viewReportStatus()
        viewCoaTag()
        viewStores()
        viewCOA()
        actionLoad()
    End Sub

    Sub viewStores()
        Dim query As String = "SELECT c.id_comp, CONCAT(c.comp_number,' - ', c.comp_name) AS `comp`
        FROM tb_m_comp c WHERE c.id_comp_cat=6
        ORDER BY c.comp_number ASC "
        viewSearchLookupQuery(SLEStoreNormal, query, "id_comp", "comp", "id_comp")
        viewSearchLookupQuery(SLEStoreSale, query, "id_comp", "comp", "id_comp")
    End Sub

    Sub viewCOA()
        Dim query As String = "SELECT id_acc,acc_name,CONCAT(acc_name,' - ',acc_description) AS `acc_description` FROM `tb_a_acc` WHERE id_status='1' AND id_is_det='2'"
        viewSearchLookupQuery(SLEAccPPNNormal, query, "id_acc", "acc_description", "id_acc")
        viewSearchLookupQuery(SLEAccRevNormal, query, "id_acc", "acc_description", "id_acc")
        viewSearchLookupQuery(SLEAccAPNormal, query, "id_acc", "acc_description", "id_acc")
        viewSearchLookupQuery(SLEAccPPNSale, query, "id_acc", "acc_description", "id_acc")
        viewSearchLookupQuery(SLEAccRevSale, query, "id_acc", "acc_description", "id_acc")
        viewSearchLookupQuery(SLEAccAPSale, query, "id_acc", "acc_description", "id_acc")
    End Sub

    Sub viewReportStatus()
        Dim query As String = "SELECT * FROM tb_lookup_report_status a ORDER BY a.id_report_status "
        viewLookupQuery(LEReportStatus, query, 0, "report_status", "id_report_status")
    End Sub

    Sub viewCoaTag()
        Dim query As String = "SELECT ct.id_coa_tag, ct.tag_code, ct.tag_description, CONCAT(ct.tag_code,' - ', ct.tag_description)  AS `coa_tag`
        FROM tb_coa_tag ct WHERE ct.id_coa_tag>1 ORDER BY ct.id_coa_tag ASC "
        viewSearchLookupQuery(SLEUnit, query, "id_coa_tag", "tag_description", "id_coa_tag")
    End Sub

    Sub actionLoad()
        If action = "ins" Then
            Dim now_dt As DateTime = getTimeDB()
            DESalesDate.EditValue = now_dt
            DECreatedDate.EditValue = now_dt

            'initial normal
            TxtRevGrossNormal.EditValue = 0.00
            TxtProsPPNNormal.EditValue = 0.00
            TxtPPNNormal.EditValue = 0.00
            TxtPPNNoteNormal.EditValue = 0.00
            TxtRevNormal.EditValue = 0.00
            TxtRevNoteNormal.EditValue = 0.00
            TxtAPNormal.EditValue = 0.00
            TxtAPNoteNormal.EditValue = 0.00
            'iniital sale
            TxtRevGrossSale.EditValue = 0.00
            TxtProsPPNSale.EditValue = 0.00
            TxtPPNSale.EditValue = 0.00
            TxtPPNNoteSale.EditValue = 0.00
            TxtRevSale.EditValue = 0.00
            TxtRevNoteSale.EditValue = 0.00
            TxtAPSale.EditValue = 0.00
            TxtAPNoteSale.EditValue = 0.00

            'load opt
            Dim query_opt As String = "SELECT vat_inv_default FROM tb_opt;"
            Dim data_opt As DataTable = execute_query(query_opt, -1, True, "", "", "", "")
            TxtProsPPNNormal.EditValue = data_opt.Rows(0)("vat_inv_default")
            TxtProsPPNSale.EditValue = data_opt.Rows(0)("vat_inv_default")
            calculate()

            'detail
            viewDetail()
        End If
    End Sub

    Sub calculate()

    End Sub

    Sub viewDetail()
        Cursor = Cursors.WaitCursor
        Dim query As String = "SELECT d.id_sales_branch_det, d.id_sales_branch, 
        d.id_acc, coa.acc_name AS `coa_account`, coa.acc_description AS `coa_description`,
        d.id_dc, dc.dc_code, d.id_comp, d.note, d.`value`, d.id_report, d.report_mark_type
        FROM tb_sales_branch_det d
        INNER JOIN tb_a_acc coa ON coa.id_acc = d.id_acc
        INNER JOIN tb_lookup_dc dc ON dc.id_dc = d.id_dc
        WHERE d.id_sales_branch=" + id + " "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCData.DataSource = data
        GVData.BestFitColumns()
        Cursor = Cursors.Default
    End Sub

    Sub allowStatus()
        BtnSave.Enabled = False
        BtnPrint.Enabled = True
        BMark.Enabled = False
        PanelControlNav.Visible = False
        SLEUnit.Enabled = False
        DESalesDate.Enabled = False
        GVData.OptionsBehavior.ReadOnly = True
        GroupControlNormalAccount.Enabled = False
        GroupControlSaleAccount.Enabled = False
        GroupControlNote.Enabled = False
    End Sub

    Private Sub BtnDelete_Click(sender As Object, e As EventArgs) Handles BtnDelete.Click
        If GVData.RowCount > 0 And GVData.FocusedRowHandle >= 0 Then
            Dim confirm As DialogResult = DevExpress.XtraEditors.XtraMessageBox.Show("Are you sure want to delete this detail ?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
            If confirm = Windows.Forms.DialogResult.Yes Then
                Cursor = Cursors.WaitCursor
                GVData.DeleteSelectedRows()
                GCData.RefreshDataSource()
                GVData.RefreshData()
                Cursor = Cursors.Default
            End If
        End If
    End Sub

    Private Sub BtnAdd_Click(sender As Object, e As EventArgs) Handles BtnAdd.Click
        If id = "-1" Then
            Cursor = Cursors.WaitCursor
            FormBankDepositAdd.id_pop_up = "1"
            FormBankDepositAdd.action = "ins"
            FormBankDepositAdd.ShowDialog()
            Cursor = Cursors.Default
        End If
    End Sub

    Private Sub SLEUnit_EditValueChanged(sender As Object, e As EventArgs) Handles SLEUnit.EditValueChanged
        Cursor = Cursors.WaitCursor
        Dim id_coa_tag_sel As String = "-1"
        Try
            id_coa_tag_sel = SLEUnit.EditValue.ToString
        Catch ex As Exception
        End Try
        Dim query As String = "SELECT c.id_comp,c.id_store_type FROM tb_m_comp c WHERE c.id_comp_cat=6 AND c.id_coa_tag='" + id_coa_tag_sel + "' "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        Dim data_filter_normal As DataRow() = data.Select("[id_store_type]='1' ")
        SLEStoreNormal.EditValue = data_filter_normal(0)("id_comp").ToString
        Dim data_filter_sale As DataRow() = data.Select("[id_store_type]='2' ")
        SLEStoreSale.EditValue = data_filter_sale(0)("id_comp").ToString
        Cursor = Cursors.Default
    End Sub
End Class