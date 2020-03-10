Public Class FormInvoiceFGPOAdd
    Private Sub BCancel_Click(sender As Object, e As EventArgs) Handles BCancel.Click
        Close()
    End Sub

    Private Sub FormInvoiceFGPOAdd_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub BPick_Click(sender As Object, e As EventArgs) Handles BPick.Click
        Try
            Dim newRow As DataRow = (TryCast(FormInvoiceFGPODP.GCList.DataSource, DataTable)).NewRow()
            '
            If SLEReportType.EditValue.ToString = "22" Then
                newRow("id_prod_order") = SLEReport.EditValue.ToString
            Else
                newRow("id_prod_order") = SLEReport.Properties.View.GetFocusedRowCellValue("id_prod_order").ToString
            End If
            newRow("id_report") = SLEReport.EditValue.ToString

            newRow("report_mark_type") = SLEReportType.EditValue.ToString
            newRow("report_number") = SLEReport.Text
            newRow("info_design") = TEInfoDesign.Text
            '
            newRow("qty") = TEQty.EditValue
            newRow("id_currency") = LECurrency.EditValue.ToString
            newRow("kurs") = TEKurs.EditValue
            newRow("value_bef_kurs") = TEBeforeKurs.EditValue
            '
            newRow("vat") = TEVat.EditValue
            newRow("inv_number") = ""
            newRow("note") = ""

            TryCast(FormInvoiceFGPODP.GCList.DataSource, DataTable).Rows.Add(newRow)
            FormInvoiceFGPODP.calculate()
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Close()
    End Sub

    Sub load_kurs()
        'check kurs first
        Dim query_kurs As String = "SELECT * FROM tb_kurs_trans WHERE DATE(DATE_ADD(created_date, INTERVAL 6 DAY)) >= DATE(NOW()) ORDER BY id_kurs_trans DESC LIMIT 1"
        Dim data_kurs As DataTable = execute_query(query_kurs, -1, True, "", "", "", "")

        If Not data_kurs.Rows.Count > 0 Then
            warningCustom("Get kurs error.")
            TEKurs.EditValue = 0.00
        Else
            If LECurrency.EditValue.ToString = "2" Then
                TEKurs.EditValue = data_kurs.Rows(0)("kurs_trans")
            Else
                TEKurs.EditValue = 1
            End If
        End If
    End Sub

    Sub load_report_type()
        Dim query As String = "SELECT report_mark_type,report_mark_type_name FROM `tb_lookup_report_mark_type` WHERE is_payable_bpl='1'"
        viewSearchLookupQuery(SLEReportType, query, "report_mark_type", "report_mark_type_name", "report_mark_type")
    End Sub

    Private Sub FormInvoiceFGPOAdd_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        TEVATPercent.EditValue = 0.00
        TEVat.EditValue = 0.00
        TEQty.EditValue = 1
        '
        If FormInvoiceFGPODP.GVList.RowCount >= 1 Then
            TEKurs.EditValue = FormInvoiceFGPODP.GVList.GetRowCellValue(0, "kurs")
        Else
            TEKurs.EditValue = 0.00
        End If

        TEBeforeKurs.EditValue = 0.00
        TEAfterKurs.EditValue = 0.00

        load_report_type()

        view_currency()
        view_po()

        If FormInvoiceFGPODP.GVList.RowCount >= 1 Then
            LECurrency.ItemIndex = LECurrency.Properties.GetDataSourceRowIndex("id_currency", FormInvoiceFGPODP.GVList.GetRowCellValue(0, "id_currency").ToString)
        End If
    End Sub

    Private Sub view_currency()
        Dim query As String = "SELECT id_currency,currency FROM tb_lookup_currency"
        viewLookupQuery(LECurrency, query, 0, "currency", "id_currency")
    End Sub

    Sub view_po()
        Dim query As String = ""

        If SLEReportType.EditValue.ToString = "22" Then 'fgpo
            query = "SELECT po.`id_prod_order` AS id_report,po.`prod_order_number` AS report_number,dsg.`design_display_name` AS description,dsg.`design_code` AS info
FROM tb_prod_order po 
INNER JOIN tb_prod_demand_design pdd ON pdd.`id_prod_demand_design`=po.`id_prod_demand_design`
INNER JOIN tb_m_design dsg ON dsg.`id_design`=pdd.`id_design`
WHERE po.`id_report_status`='6'
GROUP BY po.`id_prod_order`"
        ElseIf SLEReportType.EditValue.ToString = "13" Then 'material
            query = "SELECT po.`id_mat_purc` AS id_report,po.`mat_purc_number` AS report_number,GROUP_CONCAT(TRIM(md.mat_det_name) SEPARATOR '\n') AS description,c.comp_name AS info
,po.id_currency,po.mat_purc_kurs as kurs,po.mat_purc_vat as vat,SUM(pod.mat_purc_det_price*pod.mat_purc_det_qty) as po_val
FROM tb_mat_purc_det pod 
INNER JOIN tb_m_mat_det_price mdp ON mdp.id_mat_det_price=pod.id_mat_det_price
INNER JOIN tb_m_mat_det md ON md.id_mat_det=mdp.id_mat_det
INNER JOIN tb_mat_purc po ON pod.id_mat_purc=po.id_mat_purc 
INNER JOIN tb_m_comp_contact cc ON cc.id_comp_contact=po.id_comp_contact_to
INNER JOIN tb_m_comp c ON c.id_comp=cc.id_comp
WHERE po.`id_report_status`='6'
GROUP BY pod.id_mat_purc"
        ElseIf SLEReportType.EditValue.ToString = "23" Then 'FG WO
            query = "SELECT wo.`id_prod_order_wo` AS id_report,wo.`id_prod_order_wo` AS id_prod_order,wo.`prod_order_wo_number` AS report_number,CONCAT(ovh.`overhead`,' - ',dsg.`design_display_name`) AS description,dsg.`design_code` AS info
,wo.id_currency,wo.prod_order_wo_kurs AS kurs,wo.prod_order_wo_vat AS vat,SUM(wod.prod_order_wo_det_price*wod.prod_order_wo_det_qty) AS wo_val,SUM(wod.prod_order_wo_det_qty) AS qty
FROM tb_prod_order_wo_det wod 
INNER JOIN tb_prod_order_wo wo ON wo.`id_prod_order_wo`=wod.`id_prod_order_wo_det`
INNER JOIN tb_m_ovh_price ovhp ON ovhp.`id_ovh_price`=wo.`id_ovh_price`
INNER JOIN tb_m_ovh ovh ON ovh.`id_ovh`=ovhp.`id_ovh`
INNER JOIN tb_prod_order po ON po.`id_prod_order`=wo.id_prod_Order
INNER JOIN tb_prod_demand_design pdd ON pdd.`id_prod_demand_design`=po.`id_prod_demand_design`
INNER JOIN tb_m_design dsg ON dsg.`id_design`=pdd.`id_design`
WHERE po.`id_report_status`='6'
GROUP BY wo.`id_prod_order_wo`"
        End If

        viewSearchLookupQuery(SLEReport, query, "id_report", "report_number", "id_report")
        Try
            SLEReport.EditValue = Nothing
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub

    Private Sub SLEFGPO_EditValueChanged(sender As Object, e As EventArgs) Handles SLEReport.EditValueChanged
        Try
            If SLEReportType.EditValue.ToString = "13" Then
                Dim aft_kurs As Decimal = 0.00

                LECurrency.ItemIndex = LECurrency.Properties.GetDataSourceRowIndex("id_currency", SLEReport.Properties.View.GetFocusedRowCellValue("id_currency").ToString)
                TEBeforeKurs.EditValue = SLEReport.Properties.View.GetFocusedRowCellValue("po_val")
                TEKurs.EditValue = SLEReport.Properties.View.GetFocusedRowCellValue("kurs")
                TEVATPercent.EditValue = SLEReport.Properties.View.GetFocusedRowCellValue("vat")
                aft_kurs = TEBeforeKurs.EditValue * TEKurs.EditValue
                TEAfterKurs.EditValue = aft_kurs
            ElseIf SLEReportType.EditValue.ToString = "23" Then
                Dim aft_kurs As Decimal = 0.00

                LECurrency.ItemIndex = LECurrency.Properties.GetDataSourceRowIndex("id_currency", SLEReport.Properties.View.GetFocusedRowCellValue("id_currency").ToString)
                TEBeforeKurs.EditValue = SLEReport.Properties.View.GetFocusedRowCellValue("wo_val")
                TEKurs.EditValue = SLEReport.Properties.View.GetFocusedRowCellValue("kurs")
                TEQty.EditValue = SLEReport.Properties.View.GetFocusedRowCellValue("qty")
                TEVATPercent.EditValue = SLEReport.Properties.View.GetFocusedRowCellValue("vat")
                aft_kurs = TEBeforeKurs.EditValue * TEKurs.EditValue
                TEAfterKurs.EditValue = aft_kurs
            End If
        Catch ex As Exception
        End Try
        '
        If Not TEVATPercent.EditValue = 0 Then
            calculate_fgpo(True)
        Else
            calculate_fgpo(False)
        End If
    End Sub

    Sub calculate_fgpo(ByVal is_vatp As Boolean)
        Dim bef_kurs As Decimal = 0.00
        Dim aft_kurs As Decimal = 0.00
        Dim kurs As Decimal = 0.00
        '
        Dim vat_perc As Decimal = 0.00
        Dim vat As Decimal = 0.00
        '
        Try
            TEInfoDesign.Text = SLEReport.Properties.View.GetFocusedRowCellValue("description").ToString

            bef_kurs = TEBeforeKurs.EditValue
            kurs = TEKurs.EditValue
            aft_kurs = bef_kurs * kurs
            TEAfterKurs.EditValue = aft_kurs
            '
            If is_vatp Then
                vat_perc = TEVATPercent.EditValue
                vat = aft_kurs * (vat_perc / 100)
                TEVat.EditValue = vat
                TEAfterVAT.EditValue = aft_kurs + vat
            Else
                vat = TEVat.EditValue
                TEAfterVAT.EditValue = aft_kurs + vat
            End If
        Catch ex As Exception
            Console.WriteLine(ex.ToString)
        End Try
    End Sub

    Private Sub TEVATPercent_EditValueChanged(sender As Object, e As EventArgs) Handles TEVATPercent.EditValueChanged
        calculate_fgpo(True)
    End Sub

    Private Sub TEVat_EditValueChanged(sender As Object, e As EventArgs) Handles TEVat.EditValueChanged
        calculate_fgpo(False)
    End Sub

    Private Sub TEBeforeKurs_EditValueChanged(sender As Object, e As EventArgs) Handles TEBeforeKurs.EditValueChanged
        If Not TEVATPercent.EditValue = 0 Then
            calculate_fgpo(True)
        Else
            calculate_fgpo(False)
        End If
    End Sub

    'Private Sub LECurrency_EditValueChanged(sender As Object, e As EventArgs) Handles LECurrency.EditValueChanged
    '    load_kurs()
    'End Sub

    Private Sub TEKurs_EditValueChanged(sender As Object, e As EventArgs) Handles TEKurs.EditValueChanged
        If Not TEVATPercent.EditValue = 0 Then
            calculate_fgpo(True)
        Else
            calculate_fgpo(False)
        End If
    End Sub

    Private Sub SLEReportType_EditValueChanged(sender As Object, e As EventArgs) Handles SLEReportType.EditValueChanged
        view_po()
    End Sub
End Class