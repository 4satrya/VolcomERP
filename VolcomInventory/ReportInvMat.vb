Public Class ReportInvMat
    Public Shared id_inv_mat As String = "-1"
    Public Shared rmt As String = "-1"
    Public Shared id_report_status As String = "-1"
    Public Shared dt As DataTable
    Public id_pre As String = "-1"


    Private Sub ReportInvMat_BeforePrint(sender As Object, e As Printing.PrintEventArgs) Handles MyBase.BeforePrint
        Dim query_head As String = "SELECT inv.`id_inv_mat`,SUM(invd.`value`) AS total,CAST(inv.vat_percent AS DECIMAL(5,0)) AS p,SUM(invd.`value`)*(inv.vat_percent/100) AS ppn,SUM(invd.`value`)*((100+inv.vat_percent)/100) AS total_amount
,inv.note,self.comp_name AS own_comp_name,self.address_primary AS own_comp_address, self.postal_code AS own_comp_postal_code, self.npwp AS own_comp_npwp
,c.comp_name AS vendor_name,c.address_primary AS vendor_address,inv.number AS report_number,DATE_FORMAT(inv.created_date,'%d %M %Y') AS created_date,DATE_FORMAT(inv.due_date,'%d %M %Y') AS due_date,emp.employee_name AS printed_by, DATE_FORMAT(NOW(),'%d %M %Y') AS printed_date
FROM tb_inv_mat_det invd
INNER JOIN tb_inv_mat inv ON inv.`id_inv_mat`=invd.`id_inv_mat`
INNER JOIN tb_m_comp c ON c.id_comp=inv.id_comp
LEFT JOIN tb_m_user usr ON usr.id_user='" & id_user & "'
LEFT JOIN tb_m_employee emp ON emp.id_employee=usr.id_employee
INNER JOIN tb_m_comp self ON self.id_comp='1'
WHERE inv.`id_inv_mat`='" & id_inv_mat & "' "
        Dim data_head As DataTable = execute_query(query_head, -1, True, "", "", "", "")
        DataSource = data_head

        'set footer detail
        'RowTotalAmount.Text = Decimal.Parse(data_head.Rows(0)("total").ToString).ToString("N2")

        'set invocie value info
        LabelAmount.Text = Decimal.Parse(data_head.Rows(0)("total").ToString).ToString("N2")
        LabelPPN.Text = Decimal.Parse(data_head.Rows(0)("ppn").ToString).ToString("N2")
        LabelTotalAmount.Text = Decimal.Parse(data_head.Rows(0)("total_amount").ToString).ToString("N2")
        LabelSay.Text = "Say : " + ConvertCurrencyToIndonesian(data_head.Rows(0)("total_amount"))

        'detail
        Dim font_row_style As New Font("Segoe UI", 8, FontStyle.Regular)
        For i = 0 To dt.Rows.Count - 1
            'row
            Dim row As DevExpress.XtraReports.UI.XRTableRow = New DevExpress.XtraReports.UI.XRTableRow
            row.HeightF = 15

            If Not FormInvMatDet.is_deposit = "1" Then
                'header packing list
                Dim no_pl As DevExpress.XtraReports.UI.XRTableCell = New DevExpress.XtraReports.UI.XRTableCell
                no_pl.Text = dt.Rows(i)("report_number").ToString & " - " & " (PO Number : " & dt.Rows(i)("prod_order_number").ToString & " - " & dt.Rows(i)("info_design").ToString & ") "
                no_pl.Borders = DevExpress.XtraPrinting.BorderSide.Top
                no_pl.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
                no_pl.BackColor = Color.Transparent
                no_pl.Font = font_row_style
                no_pl.WidthF = 772

                row.Cells.Add(no_pl)
                XTable.Rows.Add(row)
            End If

            'detail
            Dim query As String = ""
            If FormInvMatDet.is_deposit = "1" Then
                query = "SELECT md.`mat_det_code`,md.`mat_det_name`,pld.`pl_mrs_det_qty` AS qty," & decimalSQL(dt.Rows(i)("price").ToString) & " AS price,(pld.`pl_mrs_det_qty`*" & decimalSQL(dt.Rows(i)("price").ToString) & ") AS amount
FROM tb_pl_mrs_det pld
INNER JOIN tb_m_mat_det_price prc ON prc.`id_mat_det_price`=pld.`id_mat_det_price`
INNER JOIN tb_m_mat_det md ON md.`id_mat_det`=prc.`id_mat_det`
WHERE pld.`id_pl_mrs`='" & dt.Rows(i)("id_report").ToString & "' AND CONCAT(md.mat_det_code,' - ',md.mat_det_name)='" & dt.Rows(i)("info_design").ToString & "'"
            Else
                If FormInvMatDet.SLEPayType.EditValue.ToString = "1" Then 'packing list
                    query = "SELECT md.`mat_det_code`,md.`mat_det_name`,pld.`pl_mrs_det_qty` AS qty,pld.`pl_mrs_det_price` AS price,(pld.`pl_mrs_det_qty`*pld.`pl_mrs_det_price`) AS amount
FROM tb_pl_mrs_det pld
INNER JOIN tb_m_mat_det_price prc ON prc.`id_mat_det_price`=pld.`id_mat_det_price`
INNER JOIN tb_m_mat_det md ON md.`id_mat_det`=prc.`id_mat_det`
WHERE pld.`id_pl_mrs`='" & dt.Rows(i)("id_report").ToString & "'"
                ElseIf FormInvMatDet.SLEPayType.EditValue.ToString = "1" Then 'retur
                    query = "SELECT md.`mat_det_code`,md.`mat_det_name`,retd.`mat_prod_ret_in_det_qty` AS qty,retd.`mat_prod_ret_in_det_price` AS price,(retd.`mat_prod_ret_in_det_qty`*retd.`mat_prod_ret_in_det_price`) AS amount
FROM tb_mat_prod_ret_in_det retd
INNER JOIN tb_pl_mrs_det pld ON pld.`id_pl_mrs_det`=retd.`id_pl_mrs_det`
INNER JOIN tb_m_mat_det_price prc ON prc.`id_mat_det_price`=pld.`id_mat_det_price`
INNER JOIN tb_m_mat_det md ON md.`id_mat_det`=prc.`id_mat_det`
WHERE retd.`id_mat_prod_ret_in`='" & dt.Rows(i)("id_report").ToString & "'"
                End If
            End If

            '
            Dim dt_det As DataTable = execute_query(query, -1, True, "", "", "", "")
            For j = 0 To dt_det.Rows.Count - 1
                Dim row_det As DevExpress.XtraReports.UI.XRTableRow = New DevExpress.XtraReports.UI.XRTableRow
                row_det.HeightF = 15
                'no
                Dim no As DevExpress.XtraReports.UI.XRTableCell = New DevExpress.XtraReports.UI.XRTableCell
                no.Text = (j + 1).ToString + "."
                no.Borders = DevExpress.XtraPrinting.BorderSide.None
                no.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
                no.BackColor = Color.Transparent
                no.Font = font_row_style
                no.WidthF = 50

                row_det.Cells.Add(no)

                'barcode
                Dim code As DevExpress.XtraReports.UI.XRTableCell = New DevExpress.XtraReports.UI.XRTableCell
                code.Text = dt_det.Rows(j)("mat_det_code").ToString
                code.Borders = DevExpress.XtraPrinting.BorderSide.None
                code.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
                code.BackColor = Color.Transparent
                code.Font = font_row_style
                code.WidthF = 140

                row_det.Cells.Add(code)

                'descrition
                Dim descrip As DevExpress.XtraReports.UI.XRTableCell = New DevExpress.XtraReports.UI.XRTableCell
                descrip.Text = dt_det.Rows(j)("mat_det_name").ToString
                descrip.Borders = DevExpress.XtraPrinting.BorderSide.None
                descrip.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
                descrip.BackColor = Color.Transparent
                descrip.Font = font_row_style
                descrip.WidthF = 280

                row_det.Cells.Add(descrip)

                'qty
                Dim qty As DevExpress.XtraReports.UI.XRTableCell = New DevExpress.XtraReports.UI.XRTableCell
                qty.Text = Decimal.Parse(dt_det.Rows(j)("qty").ToString).ToString("N4")
                qty.Borders = DevExpress.XtraPrinting.BorderSide.None
                qty.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
                qty.BackColor = Color.Transparent
                qty.Font = font_row_style
                qty.WidthF = 85

                row_det.Cells.Add(qty)

                'price
                Dim price As DevExpress.XtraReports.UI.XRTableCell = New DevExpress.XtraReports.UI.XRTableCell
                price.Text = Decimal.Parse(dt_det.Rows(j)("price").ToString).ToString("N2")
                price.Borders = DevExpress.XtraPrinting.BorderSide.None
                price.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
                price.BackColor = Color.Transparent
                price.Font = font_row_style
                price.WidthF = 100

                row_det.Cells.Add(price)

                'amount
                Dim amo As DevExpress.XtraReports.UI.XRTableCell = New DevExpress.XtraReports.UI.XRTableCell
                amo.Text = Decimal.Parse(dt_det.Rows(j)("amount").ToString).ToString("N2")
                amo.Borders = DevExpress.XtraPrinting.BorderSide.None
                amo.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
                amo.BackColor = Color.Transparent
                amo.Font = font_row_style
                amo.WidthF = 117

                row_det.Cells.Add(amo)

                XTable.Rows.Add(row_det)
            Next
        Next
        'row total
        Dim row_total As DevExpress.XtraReports.UI.XRTableRow = New DevExpress.XtraReports.UI.XRTableRow
        row_total.HeightF = 15

        Dim blank_amo As DevExpress.XtraReports.UI.XRTableCell = New DevExpress.XtraReports.UI.XRTableCell
        blank_amo.Text = ""
        blank_amo.WidthF = 665
        blank_amo.Borders = DevExpress.XtraPrinting.BorderSide.Top Or DevExpress.XtraPrinting.BorderSide.Bottom
        blank_amo.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
        blank_amo.BackColor = Color.Transparent
        blank_amo.Font = font_row_style

        row_total.Cells.Add(blank_amo)
        '
        Dim amo_tot As DevExpress.XtraReports.UI.XRTableCell = New DevExpress.XtraReports.UI.XRTableCell
        amo_tot.Text = Decimal.Parse(data_head.Rows(0)("total").ToString).ToString("N2")
        amo_tot.WidthF = 117
        amo_tot.Borders = DevExpress.XtraPrinting.BorderSide.Top Or DevExpress.XtraPrinting.BorderSide.Bottom
        amo_tot.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
        amo_tot.BackColor = Color.Transparent
        amo_tot.Font = font_row_style

        row_total.Cells.Add(amo_tot)
        XTable.Rows.Add(row_total)

        If id_pre = "1" Then
            pre_load_mark_horz(rmt, id_inv_mat, LabelStoreName.Text, "2", XrTable1)
        Else
            load_mark_horz(rmt, id_inv_mat, LabelStoreName.Text, "2", XrTable1)
        End If
    End Sub
End Class