Public Class FormAdditionalCostDet
    Public id_pps As String = "-1"
    Public id_type As String = "1" '1 = est , 2 = realization
    Public realization_from As String = "-1"
    Public id_report_status As String = "1"
    Public is_view As String = "-1"

    Private Sub FormAdditionalCostDet_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        form_load()
    End Sub

    Sub view_vendor()
        Dim q As String = "SELECT id_comp,comp_name,comp_number FROM tb_m_comp WHERE is_active=1"
        viewSearchLookupQuery(SLEVendor, q, "id_comp", "comp_name", "id_comp")
    End Sub

    Sub form_load()
        view_vendor()
        TEVatPercent.EditValue = 0.00

        If Not id_pps = "-1" Then
            'edit
            BMark.Visible = True
            BtnPrint.Visible = True

            Dim q As String = "SELECT pps.id_type,pps.id_comp,pps.number,pps.created_by,emp.employee_name,pps.created_date,pps.update_by,pps.update_date,pps.note,pps.vat_percent,pps.id_report_status 
FROM tb_additional_cost_pps pps 
INNER JOIN tb_m_user usr ON usr.id_user=pps.created_by
INNER JOIN tb_m_employee emp ON emp.id_employee=usr.id_employee
WHERE id_additional_cost_pps='" & id_pps & "'"
            Dim dt As DataTable = execute_query(q, -1, True, "", "", "", "")
            If dt.Rows.Count > 0 Then
                id_type = dt.Rows(0)("id_type").ToString
                TENumber.Text = dt.Rows(0)("number").ToString
                TECreatedBy.Text = dt.Rows(0)("employee_name").ToString
                MENote.Text = dt.Rows(0)("note").ToString
                TEVatPercent.Text = dt.Rows(0)("vat_percent").ToString
                id_report_status = dt.Rows(0)("id_report_status").ToString
                '
                SLEVendor.EditValue = dt.Rows(0)("id_comp").ToString
            End If
            '
            load_design()
            '
            load_det_cost()
        Else
            'new
            BMark.Visible = False
            BtnPrint.Visible = False
            '
            If id_type = "2" Then
                load_design_est()
                load_det_cost_est()
            Else
                load_det_cost()
            End If
        End If

        calculate()
    End Sub

    Sub load_design()
        Dim q As String = "SELECT dsg.id_design,dsg.`design_code`,dsg.`design_display_name`,ppsd.ecop AS prod_order_cop_pd,ppsd.`qty_order` AS qty
,ppsd.qty_sample AS qty_sampling
FROM tb_additional_cost_pps_design ppsd 
INNER JOIN tb_m_design dsg ON dsg.id_design=ppsd.id_design
WHERE id_additional_cost_pps='" & id_pps & "'"
        Dim dt As DataTable = execute_query(q, -1, True, "", "", "", "")
        GCDesignList.DataSource = dt
        GVDesignList.BestFitColumns()
    End Sub

    Sub load_design_est()
        Dim q As String = "SELECT dsg.id_design,dsg.`design_code`,dsg.`design_display_name`,ppsd.ecop AS prod_order_cop_pd,ppsd.`qty_order` AS qty
,ppsd.qty_sample AS qty_sampling
FROM tb_additional_cost_pps_design ppsd 
INNER JOIN tb_m_design dsg ON dsg.id_design=ppsd.id_design
WHERE id_additional_cost_pps='" & realization_from & "'"
        Dim dt As DataTable = execute_query(q, -1, True, "", "", "", "")
        GCDesignList.DataSource = dt
        GVDesignList.BestFitColumns()
    End Sub

    Sub load_det_cost()
        Dim q As String = ""

        If id_type = "1" Then
            q = "SELECT description,qty_est AS qty,value_est AS `value`
FROM `tb_additional_cost_pps_det` 
WHERE id_additional_cost_pps='" & id_pps & "'"
        Else
            q = "SELECT description,qty AS qty,value AS `value`
FROM `tb_additional_cost_pps_det` 
WHERE id_additional_cost_pps='" & id_pps & "'"
        End If

        Dim dt As DataTable = execute_query(q, -1, True, "", "", "", "")
        GCCostList.DataSource = dt
        check_button()
    End Sub

    Sub load_det_cost_est()
        Dim q As String = ""

        q = "SELECT description,qty_est AS qty,value_est AS `value`
FROM `tb_additional_cost_pps_det` 
WHERE id_additional_cost_pps='" & realization_from & "'"

        Dim dt As DataTable = execute_query(q, -1, True, "", "", "", "")
        GCCostList.DataSource = dt
        check_button()
    End Sub

    Sub check_button()
        If GVCostList.RowCount > 0 Then
            BDel.Visible = True
        Else
            BDel.Visible = False
        End If
        If id_type = "2" Then
            BPickArticle.Visible = False
        Else
            BPickArticle.Visible = True
        End If
    End Sub

    Private Sub BPickArticle_Click(sender As Object, e As EventArgs) Handles BPickArticle.Click
        Dim ok As Boolean = True

        If GVDesignList.RowCount > 0 Then
            Dim confirm As DialogResult = DevExpress.XtraEditors.XtraMessageBox.Show("Reset cost breakdown and reload design list ?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
            If confirm = Windows.Forms.DialogResult.Yes Then
                ok = True
            Else
                ok = False
            End If
        End If

        If ok Then
            Dim q As String = "SELECT dsg.id_design,pdd.id_prod_demand_design,dsg.`design_code`,dsg.`design_display_name`,dsg.prod_order_cop_pd,SUM(pdp.`prod_demand_product_qty`) AS qty
,0 AS qty_sampling
FROM tb_m_design dsg 
INNER JOIN tb_prod_demand_design pdd ON pdd.`id_prod_demand_design`=dsg.id_prod_demand_design_line
INNER JOIN `tb_prod_demand_product` pdp ON pdp.id_prod_demand_design=pdd.id_prod_demand_design
WHERE dsg.`id_design` IN 
(
	SELECT acn.`id_design`
	FROM `tb_additional_cost_need` acn
	INNER JOIN tb_m_design dsg ON dsg.`id_design`=acn.`id_design`
	LEFT JOIN `tb_additional_cost_pps_design` ppsd ON ppsd.`id_design`=dsg.`id_design`
	LEFT JOIN tb_additional_cost_pps pps ON pps.id_additional_cost_pps=ppsd.id_additional_cost_pps AND pps.`id_report_status`!=5
	WHERE ISNULL(pps.`id_additional_cost_pps`)
)
GROUP BY pdd.`id_prod_demand_design`"
            Dim dt As DataTable = execute_query(q, -1, True, "", "", "", "")
            GCDesignList.DataSource = dt
            GVDesignList.BestFitColumns()
            '
            For j = GVCostList.RowCount - 1 To 0 Step -1
                GVCostList.DeleteRow(j)
            Next
            '
            calculate()
        End If
    End Sub

    Private Sub BtnCancel_Click(sender As Object, e As EventArgs) Handles BtnCancel.Click
        Close()
    End Sub

    Private Sub FormAdditionalCostDet_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub BCalculateSampleCOP_Click(sender As Object, e As EventArgs) Handles BCalculateSampleCOP.Click
        For i = 0 To GVDesignList.RowCount - 1
            If GVDesignList.GetRowCellValue(i, "qty_sampling") > 0 Then
                Dim newRow As DataRow = (TryCast(GCCostList.DataSource, DataTable)).NewRow()
                newRow("description") = GVDesignList.GetRowCellValue(i, "design_display_name").ToString
                newRow("qty") = GVDesignList.GetRowCellValue(i, "qty_sampling")
                newRow("value") = GVDesignList.GetRowCellValue(i, "prod_order_cop_pd")
                TryCast(GCCostList.DataSource, DataTable).Rows.Add(newRow)
            End If
        Next
        calculate()
        check_button()
    End Sub

    Private Sub BDel_Click(sender As Object, e As EventArgs) Handles BDel.Click
        If GVCostList.RowCount > 0 Then
            GVCostList.DeleteSelectedRows()
            calculate()
            check_button()
        End If
    End Sub

    Private Sub BAdd_Click(sender As Object, e As EventArgs) Handles BAdd.Click
        Dim newRow As DataRow = (TryCast(GCCostList.DataSource, DataTable)).NewRow()
        newRow("description") = ""
        newRow("qty") = 1
        newRow("value") = 0
        TryCast(GCCostList.DataSource, DataTable).Rows.Add(newRow)
        check_button()
    End Sub

    Sub calculate()
        Dim total_qty_order As Decimal = 0
        Dim total_cost As Decimal = 0.00
        Dim vat As Decimal = 0.00
        Dim vat_percent As Decimal = 0.00

        Try
            GVCostList.RefreshData()
            total_cost = GVCostList.Columns("sub_total").SummaryItem.SummaryValue
            total_qty_order = GVDesignList.Columns("qty").SummaryItem.SummaryValue
            '
            TETotQty.EditValue = total_qty_order
            TECostPerUnit.EditValue = total_cost / total_qty_order
            TESubTotal.EditValue = total_cost
            TEVat.EditValue = (TEVatPercent.EditValue / 100) * total_cost
            TEGrandTotal.EditValue = total_cost + ((TEVatPercent.EditValue / 100) * total_cost)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub GVCostList_CellValueChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles GVCostList.CellValueChanged
        If e.Column.FieldName = "qty" Or e.Column.FieldName = "value" Then
            calculate()
        End If
    End Sub

    Private Sub TEVatPercent_EditValueChanged(sender As Object, e As EventArgs) Handles TEVatPercent.EditValueChanged
        calculate()
    End Sub

    Private Sub BtnSave_Click(sender As Object, e As EventArgs) Handles BtnSave.Click
        Dim is_ok As Boolean = True

        For i As Integer = 0 To GVCostList.RowCount - 1
            If GVCostList.GetRowCellValue(i, "qty") <= 0 Or GVCostList.GetRowCellValue(i, "value") <= 0 Then
                warningCustom("Please put qty and cost price correctly")
                is_ok = False
                Exit For
            End If
        Next
        '
        If GVDesignList.RowCount = 0 Or GVCostList.RowCount = 0 Then
            warningCustom("Please load design first and put the cost list.")
            is_ok = False
        End If
        '
        If is_ok Then
            If id_type = "1" Then 'propose
                If id_pps = "1" Then 'new
                    Dim q As String = "INSERT INTO `tb_additional_cost_pps`(id_type,id_comp,created_by,created_date,update_by,update_date,note,vat_percent,id_report_status)
VALUES('1','" & SLEVendor.EditValue.ToString & "','" & id_user & "',NOW(),'" & id_user & "',NOW(),'" & addSlashes(MENote.Text) & "','" & decimalSQL(Decimal.Parse(TEVatPercent.EditValue.ToString)) & "','1'); SELECT LAST_INSERT_ID(); "

                    id_pps = execute_query(q, 0, True, "", "", "", "")
                    '
                    q = "CALL gen_number('" & id_pps & "','274');"
                    execute_non_query(q, True, "", "", "", "")
                    'design
                    q = "INSERT INTO `tb_additional_cost_pps_design`(`id_additional_cost_pps`,`id_design`,`qty_order`,`qty_sample`,`ecop`) VALUES"
                    For i = 0 To GVDesignList.RowCount - 1
                        If Not i = 0 Then
                            q += ","
                        End If
                        q += "('" & id_pps & "','" & GVDesignList.GetRowCellValue(i, "id_design").ToString & "','" & decimalSQL(Decimal.Parse(GVDesignList.GetRowCellValue(i, "qty").ToString).ToString) & "','" & decimalSQL(Decimal.Parse(GVDesignList.GetRowCellValue(i, "qty_sampling").ToString).ToString) & "','" & decimalSQL(Decimal.Parse(GVDesignList.GetRowCellValue(i, "prod_order_cop_pd").ToString).ToString) & "')"
                    Next
                    execute_non_query(q, True, "", "", "", "")
                    'detail
                    q = "INSERT INTO `tb_additional_cost_pps_det`(`id_additional_cost_pps`,`description`,`qty_est`,`value_est`) VALUES"
                    For i = 0 To GVCostList.RowCount - 1
                        If Not i = 0 Then
                            q += ","
                        End If
                        q += "('" & id_pps & "','" & addSlashes(GVCostList.GetRowCellValue(i, "description").ToString) & "','" & decimalSQL(Decimal.Parse(GVCostList.GetRowCellValue(i, "qty").ToString).ToString) & "','" & decimalSQL(Decimal.Parse(GVCostList.GetRowCellValue(i, "value").ToString).ToString) & "')"
                    Next
                    execute_non_query(q, True, "", "", "", "")
                    warningCustom("Propose created")
                Else 'edit
                    Dim q As String = "UPDATE `tb_additional_cost_pps` SET id_comp='" & SLEVendor.EditValue.ToString & "',update_by='" & id_user & "',update_date=NOW(),note='" & addSlashes(MENote.Text) & "',vat_percent='" & decimalSQL(Decimal.Parse(TEVatPercent.EditValue.ToString)) & "' WHERE id_additional_cost_pps='" & id_pps & "'"
                    execute_non_query(q, True, "", "", "", "")
                    'design
                    q = "DELETE FROM tb_additional_cost_pps_design WHERE id_additional_cost_pps='" & id_pps & "'"
                    execute_non_query(q, True, "", "", "", "")
                    q = "INSERT INTO `tb_additional_cost_pps_design`(`id_additional_cost_pps`,`id_design`,`qty_order`,`qty_sample`,`ecop`) VALUES"
                    For i = 0 To GVDesignList.RowCount - 1
                        If Not i = 0 Then
                            q += ","
                        End If
                        q += "('" & id_pps & "','" & GVDesignList.GetRowCellValue(i, "id_design").ToString & "','" & decimalSQL(Decimal.Parse(GVDesignList.GetRowCellValue(i, "qty").ToString).ToString) & "','" & decimalSQL(Decimal.Parse(GVDesignList.GetRowCellValue(i, "qty_sampling").ToString).ToString) & "','" & decimalSQL(Decimal.Parse(GVDesignList.GetRowCellValue(i, "prod_order_cop_pd").ToString).ToString) & "')"
                    Next
                    execute_non_query(q, True, "", "", "", "")
                    'detail
                    q = "DELETE FROM tb_additional_cost_pps_det WHERE id_additional_cost_pps='" & id_pps & "'"
                    execute_non_query(q, True, "", "", "", "")
                    q = "INSERT INTO `tb_additional_cost_pps_det`(`id_additional_cost_pps`,`description`,`qty_est`,`value_est`) VALUES"
                    For i = 0 To GVCostList.RowCount - 1
                        If Not i = 0 Then
                            q += ","
                        End If
                        q += "('" & id_pps & "','" & addSlashes(GVCostList.GetRowCellValue(i, "description").ToString) & "','" & decimalSQL(Decimal.Parse(GVCostList.GetRowCellValue(i, "qty").ToString).ToString) & "','" & decimalSQL(Decimal.Parse(GVCostList.GetRowCellValue(i, "value").ToString).ToString) & "')"
                    Next
                    execute_non_query(q, True, "", "", "", "")
                    warningCustom("Propose updated")
                End If
                form_load()
            ElseIf id_type = "2" Then 'realization
                If id_pps = "1" Then 'new
                    Dim q As String = "INSERT INTO `tb_additional_cost_pps`(id_type,id_comp,created_by,created_date,update_by,update_date,note,vat_percent,id_report_status)
VALUES('2','" & SLEVendor.EditValue.ToString & "','" & id_user & "',NOW(),'" & id_user & "',NOW(),'" & addSlashes(MENote.Text) & "','" & decimalSQL(Decimal.Parse(TEVatPercent.EditValue.ToString)) & "','1'); SELECT LAST_INSERT_ID(); "

                    id_pps = execute_query(q, 0, True, "", "", "", "")
                    '
                    q = "CALL gen_number('" & id_pps & "','274');"
                    execute_non_query(q, True, "", "", "", "")
                    'design
                    q = "INSERT INTO `tb_additional_cost_pps_design`(`id_additional_cost_pps`,`id_design`,`qty_order`,`qty_sample`,`ecop`) VALUES"
                    For i = 0 To GVDesignList.RowCount - 1
                        If Not i = 0 Then
                            q += ","
                        End If
                        q += "('" & id_pps & "','" & GVDesignList.GetRowCellValue(i, "id_design").ToString & "','" & decimalSQL(Decimal.Parse(GVDesignList.GetRowCellValue(i, "qty").ToString).ToString) & "','" & decimalSQL(Decimal.Parse(GVDesignList.GetRowCellValue(i, "qty_sampling").ToString).ToString) & "','" & decimalSQL(Decimal.Parse(GVDesignList.GetRowCellValue(i, "prod_order_cop_pd").ToString).ToString) & "')"
                    Next
                    execute_non_query(q, True, "", "", "", "")
                    'detail
                    q = "INSERT INTO `tb_additional_cost_pps_det`(`id_additional_cost_pps`,`description`,`qty`,`value`) VALUES"
                    For i = 0 To GVCostList.RowCount - 1
                        If Not i = 0 Then
                            q += ","
                        End If
                        q += "('" & id_pps & "','" & addSlashes(GVCostList.GetRowCellValue(i, "description").ToString) & "','" & decimalSQL(Decimal.Parse(GVCostList.GetRowCellValue(i, "qty").ToString).ToString) & "','" & decimalSQL(Decimal.Parse(GVCostList.GetRowCellValue(i, "value").ToString).ToString) & "')"
                    Next
                    execute_non_query(q, True, "", "", "", "")
                    warningCustom("Propose created")
                Else 'edit
                    Dim q As String = "UPDATE `tb_additional_cost_pps` SET id_comp='" & SLEVendor.EditValue.ToString & "',update_by='" & id_user & "',update_date=NOW(),note='" & addSlashes(MENote.Text) & "',vat_percent='" & decimalSQL(Decimal.Parse(TEVatPercent.EditValue.ToString)) & "' WHERE id_additional_cost_pps='" & id_pps & "'"
                    execute_non_query(q, True, "", "", "", "")
                    'design
                    q = "DELETE FROM tb_additional_cost_pps_design WHERE id_additional_cost_pps='" & id_pps & "'"
                    execute_non_query(q, True, "", "", "", "")
                    q = "INSERT INTO `tb_additional_cost_pps_design`(`id_additional_cost_pps`,`id_design`,`qty_order`,`qty_sample`,`ecop`) VALUES"
                    For i = 0 To GVDesignList.RowCount - 1
                        If Not i = 0 Then
                            q += ","
                        End If
                        q += "('" & id_pps & "','" & GVDesignList.GetRowCellValue(i, "id_design").ToString & "','" & decimalSQL(Decimal.Parse(GVDesignList.GetRowCellValue(i, "qty").ToString).ToString) & "','" & decimalSQL(Decimal.Parse(GVDesignList.GetRowCellValue(i, "qty_sampling").ToString).ToString) & "','" & decimalSQL(Decimal.Parse(GVDesignList.GetRowCellValue(i, "prod_order_cop_pd").ToString).ToString) & "')"
                    Next
                    execute_non_query(q, True, "", "", "", "")
                    'detail
                    q = "DELETE FROM tb_additional_cost_pps_det WHERE id_additional_cost_pps='" & id_pps & "'"
                    execute_non_query(q, True, "", "", "", "")
                    q = "INSERT INTO `tb_additional_cost_pps_det`(`id_additional_cost_pps`,`description`,`qty`,`value`) VALUES"
                    For i = 0 To GVCostList.RowCount - 1
                        If Not i = 0 Then
                            q += ","
                        End If
                        q += "('" & id_pps & "','" & addSlashes(GVCostList.GetRowCellValue(i, "description").ToString) & "','" & decimalSQL(Decimal.Parse(GVCostList.GetRowCellValue(i, "qty").ToString).ToString) & "','" & decimalSQL(Decimal.Parse(GVCostList.GetRowCellValue(i, "value").ToString).ToString) & "')"
                    Next
                    execute_non_query(q, True, "", "", "", "")
                    warningCustom("Propose updated")
                End If
                form_load()
            End If
        End If
    End Sub

    Private Sub BMark_Click(sender As Object, e As EventArgs) Handles BMark.Click
        FormReportMark.report_mark_type = "274"
        FormReportMark.is_view = is_view
        FormReportMark.id_report = id_pps
        FormReportMark.ShowDialog()
    End Sub

    Private Sub BAttachment_Click(sender As Object, e As EventArgs) Handles BAttachment.Click
        Cursor = Cursors.WaitCursor
        FormDocumentUpload.is_view = is_view
        FormDocumentUpload.id_report = id_pps
        FormDocumentUpload.report_mark_type = "274"
        FormDocumentUpload.ShowDialog()
        Cursor = Cursors.Default
    End Sub

    Private Sub BtnPrint_Click(sender As Object, e As EventArgs) Handles BtnPrint.Click
        Dim report As ReportAdditionalCost = New ReportAdditionalCost
        '
        Dim q As String = "SELECT '" & SLEVendor.Text.ToString & "' AS comp_name,'','',''"
        '
        report.data_design = GCDesignList.DataSource
        report.data_cost = GCCostList.DataSource
        '
        Dim tool_detail As DevExpress.XtraReports.UI.ReportPrintTool = New DevExpress.XtraReports.UI.ReportPrintTool(report)

        tool_detail.ShowPreview()
    End Sub
End Class