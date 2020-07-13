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

            'detail
            viewDetail()
        End If
    End Sub

    Sub viewDetail()
        Cursor = Cursors.WaitCursor
        Dim query As String = "SELECT d.id_sales_branch_det, d.id_sales_branch, 
        d.id_acc, coa.acc_name AS `coa_account`, coa.acc_description AS `coa_description`,
        d.id_dc, d.id_comp, d.note, d.`value` 
        FROM tb_sales_branch_det d
        INNER JOIN tb_a_acc coa ON coa.id_acc = d.id_acc
        WHERE d.id_sales_branch=" + id + " "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCData.DataSource = data
        GVData.BestFitColumns()
        Cursor = Cursors.Default
    End Sub

    Sub allowStatus()

    End Sub
End Class