﻿Public Class FormSalesBranchDet
    Public id As String = "-1"
    Public action As String = "-1"
    Public rmt As String = "254"
    Public id_report_status As String = "1"
    Public is_view As String = "-1"

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
        Dim query As String = "SELECT id_acc,acc_name,acc_description AS `acc_description` FROM `tb_a_acc` WHERE id_status='1' AND id_is_det='2'"
        viewSearchLookupQuery(SLEAccPPNNormal, query, "id_acc", "acc_name", "id_acc")
        viewSearchLookupQuery(SLEAccRevNormal, query, "id_acc", "acc_name", "id_acc")
        viewSearchLookupQuery(SLEAccAPNormal, query, "id_acc", "acc_name", "id_acc")
        viewSearchLookupQuery(SLEAccPPNSale, query, "id_acc", "acc_name", "id_acc")
        viewSearchLookupQuery(SLEAccRevSale, query, "id_acc", "acc_name", "id_acc")
        viewSearchLookupQuery(SLEAccAPSale, query, "id_acc", "acc_name", "id_acc")
        SLEAccPPNNormal.EditValue = Nothing
        SLEAccRevNormal.EditValue = Nothing
        SLEAccAPNormal.EditValue = Nothing
        SLEAccPPNSale.EditValue = Nothing
        SLEAccRevSale.EditValue = Nothing
        SLEAccAPSale.EditValue = Nothing
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
            TxtRevNormal.EditValue = 0.00
            TxtAPNormal.EditValue = 0.00
            'iniital sale
            TxtRevGrossSale.EditValue = 0.00
            TxtProsPPNSale.EditValue = 0.00
            TxtPPNSale.EditValue = 0.00
            TxtRevSale.EditValue = 0.00
            TxtAPSale.EditValue = 0.00

            'load opt
            Dim query_opt As String = "SELECT vat_inv_default FROM tb_opt;"
            Dim data_opt As DataTable = execute_query(query_opt, -1, True, "", "", "", "")
            TxtProsPPNNormal.EditValue = data_opt.Rows(0)("vat_inv_default")
            TxtProsPPNSale.EditValue = data_opt.Rows(0)("vat_inv_default")
            calculate()

            'load default coa
            Dim query_opt_acc As String = "SELECT IFNULL(a.id_acc_hutang_ppn_cabang,0) AS `id_acc_ppn`, ppn.acc_description AS `acc_ppn_description`, 
            IFNULL(a.id_acc_hutang_dagang_cabang,0) AS `id_acc_hutang_dagang`, hd.acc_description AS `acc_hutang_dagang`,
            IFNULL(a.id_acc_pendapatan_cabang_normal,0) AS `id_acc_pendapatan_normal`,pend_normal.acc_description AS `acc_pendapatan_normal`,
            IFNULL(a.id_acc_pendapatan_cabang_sale,0) AS `id_acc_pendapatan_sale`, pend_sale.acc_description AS `acc_pendapatan_sale`
            FROM tb_opt_accounting a 
            LEFT JOIN tb_a_acc ppn ON ppn.id_acc = a.id_acc_hutang_ppn_cabang 
            LEFT JOIN tb_a_acc hd ON hd.id_acc = a.id_acc_hutang_dagang_cabang 
            LEFT JOIN tb_a_acc pend_normal ON pend_normal.id_acc = a.id_acc_pendapatan_cabang_normal
            LEFT JOIN tb_a_acc pend_sale ON pend_sale.id_acc = a.id_acc_pendapatan_cabang_sale
            "
            Dim data_opt_acc As DataTable = execute_query(query_opt_acc, -1, True, "", "", "", "")
            If data_opt_acc.Rows(0)("id_acc_ppn").ToString <> "0" Then
                SLEAccPPNNormal.EditValue = data_opt_acc.Rows(0)("id_acc_ppn").ToString
                TxtPPNNoteNormal.Text = data_opt_acc.Rows(0)("acc_ppn_description").ToString
                SLEAccPPNSale.EditValue = data_opt_acc.Rows(0)("id_acc_ppn").ToString
                TxtPPNNoteSale.Text = data_opt_acc.Rows(0)("acc_ppn_description").ToString
            End If
            If data_opt_acc.Rows(0)("id_acc_hutang_dagang").ToString <> "0" Then
                SLEAccAPNormal.EditValue = data_opt_acc.Rows(0)("id_acc_hutang_dagang").ToString
                TxtAPNoteNormal.Text = data_opt_acc.Rows(0)("acc_hutang_dagang").ToString
                SLEAccAPSale.EditValue = data_opt_acc.Rows(0)("id_acc_hutang_dagang").ToString
                TxtAPNoteSale.Text = data_opt_acc.Rows(0)("acc_hutang_dagang").ToString
            End If
            If data_opt_acc.Rows(0)("id_acc_pendapatan_normal").ToString <> "0" Then
                SLEAccRevNormal.EditValue = data_opt_acc.Rows(0)("id_acc_pendapatan_normal").ToString
                TxtRevNoteNormal.Text = data_opt_acc.Rows(0)("acc_pendapatan_normal").ToString
            End If
            If data_opt_acc.Rows(0)("id_acc_pendapatan_sale").ToString <> "0" Then
                SLEAccRevSale.EditValue = data_opt_acc.Rows(0)("id_acc_pendapatan_sale").ToString
                TxtRevNoteSale.Text = data_opt_acc.Rows(0)("acc_pendapatan_sale").ToString
            End If

            ' store acc
            getStoreAccount()

            'detail
            viewDetail()
        Else
            Dim sb As New ClassSalesBranch()
            Dim query As String = sb.queryMain("AND b.id_sales_branch=" + id + "", "1")
            Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
            SLEUnit.EditValue = data.Rows(0)("id_coa_tag").ToString
            DESalesDate.EditValue = data.Rows(0)("transaction_date")
            id_report_status = data.Rows(0)("id_report_status")
            LEReportStatus.ItemIndex = LEReportStatus.Properties.GetDataSourceRowIndex("id_report_status", data.Rows(0)("id_report_status").ToString)
            MENote.Text = data.Rows(0)("note").ToString
            TxtTotal.EditValue = data.Rows(0)("value")
            'normal
            SLEStoreNormal.EditValue = data.Rows(0)("id_store_normal").ToString
            TxtRevGrossNormal.EditValue = data.Rows(0)("rev_normal")
            TxtProsPPNNormal.EditValue = data.Rows(0)("rev_normal_ppn_pros")
            TxtPPNNormal.EditValue = data.Rows(0)("rev_normal_ppn")
            SLEAccPPNNormal.EditValue = data.Rows(0)("id_coa_ppn_normal").ToString
            TxtRevNormal.EditValue = data.Rows(0)("rev_normal_net")
            SLEAccRevNormal.EditValue = data.Rows(0)("id_coa_pend_normal").ToString
            TxtAPNormal.EditValue = data.Rows(0)("comp_rev_normal")
            SLEAccAPNormal.EditValue = data.Rows(0)("id_coa_hd_normal")
            'sale
            SLEStoreSale.EditValue = data.Rows(0)("id_store_sale").ToString
            TxtRevGrossSale.EditValue = data.Rows(0)("rev_sale")
            TxtProsPPNSale.EditValue = data.Rows(0)("rev_sale_ppn_pros")
            TxtPPNSale.EditValue = data.Rows(0)("rev_sale_ppn")
            SLEAccPPNSale.EditValue = data.Rows(0)("id_coa_ppn_sale").ToString
            TxtRevSale.EditValue = data.Rows(0)("rev_sale_net")
            SLEAccRevSale.EditValue = data.Rows(0)("id_coa_pend_sale").ToString
            TxtAPSale.EditValue = data.Rows(0)("comp_rev_sale")
            SLEAccAPSale.EditValue = data.Rows(0)("id_coa_hd_sale")

            'detail
            viewDetail()
            allowStatus()
        End If
    End Sub

    Sub calculate()
        'normal ppn
        TxtPPNNormal.EditValue = (100 / (100 + TxtProsPPNNormal.EditValue)) * TxtRevGrossNormal.EditValue
        TxtRevNormal.EditValue = TxtRevGrossNormal.EditValue - TxtPPNNormal.EditValue
        TxtPPNSale.EditValue = (100 / (100 + TxtProsPPNSale.EditValue)) * TxtRevGrossSale.EditValue
        TxtRevSale.EditValue = TxtRevGrossSale.EditValue - TxtPPNSale.EditValue
        TxtTotal.EditValue = TxtRevGrossNormal.EditValue + TxtAPNormal.EditValue + TxtRevGrossSale.EditValue + TxtAPSale.EditValue
    End Sub

    Sub viewDetail()
        Cursor = Cursors.WaitCursor
        Dim query As String = "SELECT d.id_sales_branch_det, d.id_sales_branch, 
        d.id_acc, coa.acc_name AS `coa_account`, coa.acc_description AS `coa_description`,
        d.id_dc, dc.dc_code, d.id_comp, c.comp_number, d.note, d.`value`, d.id_report, d.number, d.report_mark_type, d.vendor
        FROM tb_sales_branch_det d
        INNER JOIN tb_a_acc coa ON coa.id_acc = d.id_acc
        INNER JOIN tb_lookup_dc dc ON dc.id_dc = d.id_dc
        LEFT JOIN tb_m_comp c ON c.id_comp = d.id_comp
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
        getStoreAccount()
        viewDetail()
    End Sub

    Sub getStoreAccount()
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

    Private Sub TxtRevGrossNormal_EditValueChanged(sender As Object, e As EventArgs) Handles TxtRevGrossNormal.EditValueChanged
        calculate()
    End Sub

    Private Sub TxtProsPPNNormal_EditValueChanged(sender As Object, e As EventArgs) Handles TxtProsPPNNormal.EditValueChanged
        calculate()
    End Sub

    Private Sub TxtRevGrossSale_EditValueChanged(sender As Object, e As EventArgs) Handles TxtRevGrossSale.EditValueChanged
        calculate()
    End Sub

    Private Sub TxtProsPPNSale_EditValueChanged(sender As Object, e As EventArgs) Handles TxtProsPPNSale.EditValueChanged
        calculate()
    End Sub

    Private Sub TxtAPNormal_EditValueChanged(sender As Object, e As EventArgs) Handles TxtAPNormal.EditValueChanged
        calculate()
    End Sub

    Private Sub TxtAPSale_EditValueChanged(sender As Object, e As EventArgs) Handles TxtAPSale.EditValueChanged
        calculate()
    End Sub

    Function getCOADescription(ByVal SLE As DevExpress.XtraEditors.SearchLookUpEdit) As String
        Dim note As String = ""
        Try
            note = SLE.Properties.View.GetFocusedRowCellValue("acc_description").ToString
        Catch ex As Exception
        End Try
        Return note
    End Function

    Private Sub SLEAccPPNNormal_EditValueChanged(sender As Object, e As EventArgs) Handles SLEAccPPNNormal.EditValueChanged
        TxtPPNNoteNormal.Text = getCOADescription(SLEAccPPNNormal)
    End Sub

    Private Sub SLEAccRevNormal_EditValueChanged(sender As Object, e As EventArgs) Handles SLEAccRevNormal.EditValueChanged
        TxtRevNoteNormal.Text = getCOADescription(SLEAccRevNormal)
    End Sub

    Private Sub SLEAccAPNormal_EditValueChanged(sender As Object, e As EventArgs) Handles SLEAccAPNormal.EditValueChanged
        TxtAPNoteNormal.Text = getCOADescription(SLEAccAPNormal)
    End Sub

    Private Sub SLEAccPPNSale_EditValueChanged(sender As Object, e As EventArgs) Handles SLEAccPPNSale.EditValueChanged
        TxtPPNNoteSale.Text = getCOADescription(SLEAccPPNSale)
    End Sub

    Private Sub SLEAccRevSale_EditValueChanged(sender As Object, e As EventArgs) Handles SLEAccRevSale.EditValueChanged
        TxtRevNoteSale.Text = getCOADescription(SLEAccRevSale)
    End Sub

    Private Sub SLEAccAPSale_EditValueChanged(sender As Object, e As EventArgs) Handles SLEAccAPSale.EditValueChanged
        TxtAPNoteSale.Text = getCOADescription(SLEAccAPSale)
    End Sub

    Private Sub FormSalesBranchDet_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub XTCData_SelectedPageChanged(sender As Object, e As DevExpress.XtraTab.TabPageChangedEventArgs) Handles XTCData.SelectedPageChanged
        If XTCData.SelectedTabPageIndex = 1 Then
            viewBlankJournal()
            viewDraftJournal()
        End If
    End Sub

    Sub viewBlankJournal()
        Cursor = Cursors.WaitCursor
        Dim query As String = "SELECT 0 AS `no`, '' AS acc_name, '' AS acc_description, '' AS `cc`, '' AS report_number, '' AS note, 0.00 AS `debit`, 0.00 AS `credit` "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCDraft.DataSource = data
        GVDraft.DeleteSelectedRows()
        GVDraft.BestFitColumns()
        Cursor = Cursors.Default
    End Sub

    Sub viewDraftJournal()
        Cursor = Cursors.WaitCursor
        Dim jum_row As Integer = 0
        If GVData.RowCount > 0 Then
            makeSafeGV(GVData)
            'detil
            For i As Integer = 0 To GVData.RowCount - 1
                jum_row += 1
                Dim newRow As DataRow = (TryCast(GCDraft.DataSource, DataTable)).NewRow()
                newRow("no") = jum_row
                newRow("acc_name") = GVData.GetRowCellValue(i, "coa_account").ToString
                newRow("acc_description") = GVData.GetRowCellValue(i, "coa_description").ToString
                newRow("cc") = GVData.GetRowCellValue(i, "comp_number").ToString
                newRow("report_number") = GVData.GetRowCellValue(i, "number").ToString
                newRow("note") = GVData.GetRowCellValue(i, "note").ToString
                If GVData.GetRowCellValue(i, "id_dc").ToString = "1" Then
                    newRow("debit") = Math.Abs(GVData.GetRowCellValue(i, "value"))
                    newRow("credit") = 0
                Else
                    newRow("debit") = 0
                    newRow("credit") = GVData.GetRowCellValue(i, "value")
                End If
                TryCast(GCDraft.DataSource, DataTable).Rows.Add(newRow)
                GCDraft.RefreshDataSource()
                GVDraft.RefreshData()
            Next
        End If

        'header normal
        If TxtRevNormal.EditValue > 0 Then
            'revenue
            jum_row += 1
            Dim newRow As DataRow = (TryCast(GCDraft.DataSource, DataTable)).NewRow()
            newRow("no") = jum_row
            newRow("acc_name") = SLEAccRevNormal.Text
            newRow("acc_description") = getCOADescription(SLEAccRevNormal)
            newRow("cc") = SLEStoreNormal.Text
            newRow("report_number") = ""
            newRow("note") = TxtRevNoteNormal.Text
            newRow("debit") = 0
            newRow("credit") = TxtRevNormal.EditValue
            TryCast(GCDraft.DataSource, DataTable).Rows.Add(newRow)
            GCDraft.RefreshDataSource()
            GVDraft.RefreshData()

            'ppn
            jum_row += 1
            Dim newRowPPN As DataRow = (TryCast(GCDraft.DataSource, DataTable)).NewRow()
            newRowPPN("no") = jum_row
            newRowPPN("acc_name") = SLEAccPPNNormal.Text
            newRowPPN("acc_description") = getCOADescription(SLEAccPPNNormal)
            newRowPPN("cc") = SLEStoreNormal.Text
            newRowPPN("report_number") = ""
            newRowPPN("note") = TxtPPNNoteNormal.Text
            newRowPPN("debit") = 0
            newRowPPN("credit") = TxtPPNNormal.EditValue
            TryCast(GCDraft.DataSource, DataTable).Rows.Add(newRowPPN)
            GCDraft.RefreshDataSource()
            GVDraft.RefreshData()

            'hutang dagang
            jum_row += 1
            Dim newRowHD As DataRow = (TryCast(GCDraft.DataSource, DataTable)).NewRow()
            newRowHD("no") = jum_row
            newRowHD("acc_name") = SLEAccAPNormal.Text
            newRowHD("acc_description") = getCOADescription(SLEAccAPNormal)
            newRowHD("cc") = SLEStoreNormal.Text
            newRowHD("report_number") = ""
            newRowHD("note") = TxtAPNoteNormal.Text
            newRowHD("debit") = 0
            newRowHD("credit") = TxtAPNoteNormal.EditValue
            TryCast(GCDraft.DataSource, DataTable).Rows.Add(newRowHD)
            GCDraft.RefreshDataSource()
            GVDraft.RefreshData()
        End If

        'header sale
        If TxtRevSale.EditValue > 0 Then
            'revenue
            jum_row += 1
            Dim newRow As DataRow = (TryCast(GCDraft.DataSource, DataTable)).NewRow()
            newRow("no") = jum_row
            newRow("acc_name") = SLEAccRevSale.Text
            newRow("acc_description") = getCOADescription(SLEAccRevSale)
            newRow("cc") = SLEStoreSale.Text
            newRow("report_number") = ""
            newRow("note") = TxtRevNoteSale.Text
            newRow("debit") = 0
            newRow("credit") = TxtRevSale.EditValue
            TryCast(GCDraft.DataSource, DataTable).Rows.Add(newRow)
            GCDraft.RefreshDataSource()
            GVDraft.RefreshData()

            'ppn
            jum_row += 1
            Dim newRowPPN As DataRow = (TryCast(GCDraft.DataSource, DataTable)).NewRow()
            newRowPPN("no") = jum_row
            newRowPPN("acc_name") = SLEAccPPNSale.Text
            newRowPPN("acc_description") = getCOADescription(SLEAccPPNSale)
            newRowPPN("cc") = SLEStoreSale.Text
            newRowPPN("report_number") = ""
            newRowPPN("note") = TxtPPNNoteSale.Text
            newRowPPN("debit") = 0
            newRowPPN("credit") = TxtPPNSale.EditValue
            TryCast(GCDraft.DataSource, DataTable).Rows.Add(newRowPPN)
            GCDraft.RefreshDataSource()
            GVDraft.RefreshData()

            'hutang dagang
            jum_row += 1
            Dim newRowHD As DataRow = (TryCast(GCDraft.DataSource, DataTable)).NewRow()
            newRowHD("no") = jum_row
            newRowHD("acc_name") = SLEAccAPSale.Text
            newRowHD("acc_description") = getCOADescription(SLEAccAPSale)
            newRowHD("cc") = SLEStoreSale.Text
            newRowHD("report_number") = ""
            newRowHD("note") = TxtAPNoteSale.Text
            newRowHD("debit") = 0
            newRowHD("credit") = TxtAPNoteSale.EditValue
            TryCast(GCDraft.DataSource, DataTable).Rows.Add(newRowHD)
            GCDraft.RefreshDataSource()
            GVDraft.RefreshData()
        End If
        GVDraft.BestFitColumns()
        Cursor = Cursors.Default
    End Sub

    Private Sub GVData_DoubleClick(sender As Object, e As EventArgs) Handles GVData.DoubleClick
        If id = "-1" And GVData.FocusedRowHandle >= 0 Then
            If GVData.GetFocusedRowCellValue("id_report") = "0" Then
                Cursor = Cursors.WaitCursor
                FormBankDepositAdd.id_pop_up = "1"
                FormBankDepositAdd.action = "upd"
                FormBankDepositAdd.ShowDialog()
                Cursor = Cursors.Default
            End If
        End If
    End Sub

    Private Sub GVData_CustomColumnDisplayText(sender As Object, e As DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs) Handles GVData.CustomColumnDisplayText
        If e.Column.FieldName = "no" Then
            e.DisplayText = (e.ListSourceRowIndex + 1).ToString()
        End If
    End Sub

    Private Sub GVDraft_CustomColumnDisplayText(sender As Object, e As DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs) Handles GVDraft.CustomColumnDisplayText
        If e.Column.FieldName = "no" Then
            e.DisplayText = (e.ListSourceRowIndex + 1).ToString()
        End If
    End Sub

    Private Sub BtnSave_Click(sender As Object, e As EventArgs) Handles BtnSave.Click
        makeSafeGV(GVData)
        GCData.RefreshDataSource()
        GVData.RefreshData()
        calculate()

        'cek balance journal
        Dim cond_bal As Boolean = True
        XTCData.SelectedTabPageIndex = 1
        makeSafeGV(GVDraft)
        If GVDraft.Columns("debit").SummaryItem.SummaryValue = GVDraft.Columns("credit").SummaryItem.SummaryValue Then
            cond_bal = True
            XTCData.SelectedTabPageIndex = 0
        Else
            cond_bal = False
        End If

        If Not cond_bal Then
            warningCustom("Journal not balance please check your input")

        Else
            Dim confirm As DialogResult = DevExpress.XtraEditors.XtraMessageBox.Show("Are you sure want to save this data ?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
            If confirm = Windows.Forms.DialogResult.Yes Then
                Dim id_coa_tag As String = SLEUnit.EditValue.ToString
                Dim transaction_date As String = DateTime.Parse(DESalesDate.EditValue.ToString).ToString("yyyy-MM-dd")
                Dim note As String = addSlashes(MENote.Text)
                Dim value As String = decimalSQL(TxtTotal.EditValue.ToString)
                Dim rev_normal As String = decimalSQL(TxtRevGrossNormal.EditValue.ToString)
                Dim rev_normal_ppn_pros As String = decimalSQL(TxtProsPPNNormal.EditValue.ToString)
                Dim rev_normal_ppn As String = decimalSQL(TxtPPNNormal.EditValue.ToString)
                Dim rev_normal_ppn_acc As String = SLEAccPPNNormal.EditValue.ToString
                Dim rev_normal_net As String = decimalSQL(TxtRevNormal.EditValue.ToString)
                Dim rev_normal_net_acc As String = SLEAccRevNormal.EditValue.ToString
                Dim comp_rev_normal As String = decimalSQL(TxtAPNormal.EditValue.ToString)
                Dim comp_rev_normal_acc As String = SLEAccAPNormal.EditValue.ToString
                Dim rev_sale As String = decimalSQL(TxtRevGrossSale.EditValue.ToString)
                Dim rev_sale_ppn_pros As String = decimalSQL(TxtProsPPNSale.EditValue.ToString)
                Dim rev_sale_ppn As String = decimalSQL(TxtPPNSale.EditValue.ToString)
                Dim rev_sale_ppn_acc As String = SLEAccPPNSale.EditValue.ToString
                Dim rev_sale_nett As String = decimalSQL(TxtRevSale.EditValue.ToString)
                Dim rev_sale_net_acc As String = SLEAccRevSale.EditValue.ToString
                Dim comp_rev_sale As String = decimalSQL(TxtAPSale.EditValue.ToString)
                Dim comp_rev_sale_acc As String = SLEAccAPSale.EditValue.ToString
                Dim query As String = "INSERT INTO tb_sales_branch(`id_coa_tag`,
                `created_date`,
                `transaction_date`,
                `id_report_status`,
                `note`
                `value` ,
                `pros_normal`,
                `pros_normal_comp`,
                `rev_normal`,
                `rev_normal_ppn_pros`,
                `rev_normal_ppn`,
                `rev_normal_ppn_acc`,
                `rev_normal_net`,
                `rev_normal_net_acc`,
                `comp_rev_normal`,
                `comp_rev_normal_acc`,
                `pros_sale`,
                `pros_sale_comp`,
                `rev_sale`,
                `rev_sale_ppn_pros`,
                `rev_sale_ppn`,
                `rev_sale_ppn_acc`,
                `rev_sale_nett`,
                `rev_sale_net_acc`,
                `comp_rev_sale`,
                `comp_rev_sale_acc`)
                VALUES
                ('" + id_coa_tag + "',
                NOW()
                '" + transaction_date + "',
                '" + id_report_status + "',
                '" + note + "',
                '" + value + "' ,
                '0',
                '0',
                '" + rev_normal + "',
                '" + rev_normal_ppn_pros + "',
                '" + rev_normal_ppn + "',
                '" + rev_normal_ppn_acc + "',
                '" + rev_normal_net + "',
                '" + rev_normal_net_acc + "',
                '" + comp_rev_normal + "',
                '" + comp_rev_normal_acc + "',
                '0',
                '0',
                '" + rev_sale + "',
                '" + rev_sale_ppn_pros + "',
                '" + rev_sale_ppn + "',
                '" + rev_sale_ppn_acc + "',
                '" + rev_sale_nett + "',
                '" + rev_sale_net_acc + "',
                '" + comp_rev_sale + "',
                '" + comp_rev_sale_acc + "' ); SELECT LAST_INSERT_ID(); "
                id = execute_query(query, 0, True, "", "", "", "")

                'detail
                Dim query_det As String = "INSERT INTO tb_sales_branch_det(id_sales_branch, id_acc, id_dc, id_comp, note, value, id_report, number, report_mark_type,vendor) "
                For i As Integer = 0 To GVData.RowCount - 1
                    Dim id_acc As String = GVData.GetRowCellValue(i, "id_acc").ToString
                    Dim id_dc As String = GVData.GetRowCellValue(i, "id_dc").ToString
                    Dim id_comp As String = GVData.GetRowCellValue(i, "id_comp").ToString
                    If id_comp = "0" Then
                        id_comp = "NULL"
                    End If
                    Dim note_detail As String = addSlashes(GVData.GetRowCellValue(i, "note_detail").ToString)
                    Dim value_detail As String = decimalSQL(GVData.GetRowCellValue(i, "value").ToString)
                    Dim id_report As String = GVData.GetRowCellValue(i, "id_report").ToString
                    If id_report = "0" Then
                        id_report = "NULL"
                    End If
                    Dim number As String = addSlashes(GVData.GetRowCellValue(i, "number").ToString)
                    Dim report_mark_type As String = GVData.GetRowCellValue(i, "report_mark_type").ToString
                    If report_mark_type = "0" Then
                        report_mark_type = "NULL"
                    End If
                    Dim vendor As String = addSlashes(GVData.GetRowCellValue(i, "vendor").ToString)

                    If i > 0 Then
                        query_det += ","
                    End If
                    query_det += "('" + id + "', '" + id_acc + "', '" + id_dc + "', " + id_comp + ", '" + note_detail + "', '" + value_detail + "', " + id_report + ", '" + number + "', " + report_mark_type + ", '" + vendor + "') "
                Next
                If GVData.RowCount > 0 Then
                    execute_non_query(query_det, True, "", "", "", "")
                End If

                'generate number
                execute_non_query("CALL gen_number('" & id & "','" + rmt + "')", True, "", "", "", "")

                'add mark
                submit_who_prepared(rmt, id, id_user)

                'done
                infoCustom("Sales created. Waiting for approval")

                'refresh
                FormSalesBranch.GVData.FocusedRowHandle = find_row(FormSalesBranch.GVData, "id_sales_branch", id)
                FormSalesBranch.viewData()
                action = "upd"
                actionLoad()
            End If
        End If
    End Sub

    Private Sub BtnCancel_Click(sender As Object, e As EventArgs) Handles BtnCancel.Click
        Close()
    End Sub

    Private Sub BtnViewJournal_Click(sender As Object, e As EventArgs) Handles BtnViewJournal.Click
        Cursor = Cursors.WaitCursor
        Dim id_acc_trans As String = ""
        Try
            id_acc_trans = execute_query("SELECT ad.id_acc_trans FROM tb_a_acc_trans_det ad
            WHERE ad.report_mark_type=" + rmt + " AND ad.id_report=" + id + "
            GROUP BY ad.id_acc_trans ", 0, True, "", "", "", "")
        Catch ex As Exception
            id_acc_trans = ""
        End Try

        If id_acc_trans <> "" Then
            Dim s As New ClassShowPopUp()
            FormViewJournal.is_enable_view_doc = False
            FormViewJournal.BMark.Visible = False
            FormViewJournal.show_trans_number = True
            s.id_report = id_acc_trans
            s.report_mark_type = "36"
            s.show()
        Else
            warningCustom("Auto journal not found.")
        End If
        Cursor = Cursors.Default
    End Sub

    Private Sub BtnPrint_Click(sender As Object, e As EventArgs) Handles BtnPrint.Click
        'Cursor = Cursors.WaitCursor
        'ReportBankDepositNew.id = id_deposit
        'ReportBankDepositNew.id_report_status = id_report_status
        'ReportBankDepositNew.rmt = "162"
        'Dim Report As New ReportBankDepositNew()

        'If CEPrintPreview.EditValue = True Then
        '    Dim Tool As DevExpress.XtraReports.UI.ReportPrintTool = New DevExpress.XtraReports.UI.ReportPrintTool(Report)
        '    Tool.ShowPreviewDialog()
        'Else
        '    Dim instance As New Printing.PrinterSettings
        '    Dim DefaultPrinter As String = instance.PrinterName

        '    ' THIS IS TO PRINT THE REPORT
        '    Report.PrinterName = DefaultPrinter
        '    Report.CreateDocument()
        '    Report.PrintingSystem.ShowMarginsWarning = False
        '    Report.Print()
        'End If
        'Cursor = Cursors.Default
    End Sub

    Private Sub BMark_Click(sender As Object, e As EventArgs) Handles BMark.Click
        FormReportMark.report_mark_type = rmt
        FormReportMark.is_view = is_view
        FormReportMark.id_report = id
        FormReportMark.ShowDialog()
    End Sub
End Class