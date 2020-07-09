Public Class ReportBankWithdrawalSum
    Public Shared id_sum As String = "-1"

    Private Sub ReportBankWithdrawalSum_BeforePrint(sender As Object, e As Printing.PrintEventArgs) Handles MyBase.BeforePrint
        Dim query_head As String = "SELECT pns.`id_pn_summary`,kb.nama_bank,bnk.bank_no,bnk.bank_attn,pns.number,DATE_FORMAT(pns.`date_payment`,'%d %M %Y') as date_payment,DATE_FORMAT(pns.`created_date`,'%d %M %Y') AS created_date,emp.`employee_name`, cur.`id_currency`,cur.`currency`,SUM(pnd.`val_bef_kurs`) AS val_bef_kurs, pns.note
FROM tb_pn_summary pns
INNER JOIN tb_pn_summary_det pnsd ON pnsd.id_pn_summary=pns.id_pn_summary
INNER JOIN tb_pn_det pnd ON pnd.`id_pn`=pnsd.`id_pn` AND pnd.`id_currency`=pns.`id_currency`
INNER JOIN tb_lookup_currency cur ON cur.`id_currency`=pns.`id_currency`
INNER JOIN tb_m_user usr ON usr.`id_user`=pns.`created_by`
INNER JOIN tb_m_employee emp ON emp.`id_employee`=usr.`id_employee`
INNER JOIN tb_list_account_bank bnk ON bnk.id_list_account_bank=pns.id_list_account_bank
INNER JOIN tb_kode_bank kb ON kb.id=bnk.id_kode_bank
WHERE pns.`id_pn_summary`='" & id_sum & "' GROUP BY pns.`id_pn_summary` "
        Dim data_head As DataTable = execute_query(query_head, -1, True, "", "", "", "")
        DataSource = data_head

        'set invocie value info
        LTotal.Text = data_head.Rows(0)("currency").ToString & " " & Decimal.Parse(data_head.Rows(0)("val_bef_kurs").ToString).ToString("N0")
        LTotSay.Text = "Say : " + ConvertCurrencyToIndonesian(data_head.Rows(0)("val_bef_kurs"))

        'detail
        Dim font_row_style As New Font("Segoe UI", 8, FontStyle.Regular)
        '
        Dim q As String = "SELECT 'no' AS is_check,py.number,sts.report_status,emp.employee_name AS created_by, py.date_created, py.`id_pn`,SUM(pyd.`val_bef_kurs`) AS `value` ,c.`comp_name`,rm.`report_mark_type_name`,pt.`pay_type`,py.note,py.date_payment,tot.val_total
FROM tb_pn py
INNER JOIN tb_m_comp_contact cc ON cc.`id_comp_contact`=py.`id_comp_contact`
INNER JOIN tb_m_comp c ON c.`id_comp`=cc.`id_comp`
INNER JOIN `tb_lookup_report_mark_type` rm ON rm.`report_mark_type`=py.`report_mark_type`
INNER JOIN `tb_lookup_pay_type` pt ON pt.`id_pay_type`=py.`id_pay_type`
INNER JOIN tb_m_user usr ON usr.id_user=py.id_user_created
INNER JOIN tb_m_employee emp ON emp.id_employee=usr.id_employee
INNER JOIN tb_lookup_report_status sts ON sts.id_report_status=py.id_report_status
INNER JOIN tb_pn_det pyd ON pyd.id_pn=py.id_pn AND pyd.`id_currency`='" & data_head.Rows(0)("id_currency").ToString & "' AND pyd.`is_include_total`=1
LEFT JOIN 
( SELECT id_pn,SUM(val_bef_kurs) as val_total FROM tb_pn_det WHERE `id_currency`='" & data_head.Rows(0)("id_currency").ToString & "' AND `is_include_total`=1 GROUP BY id_pn)
tot ON tot.id_pn=py.id_pn
INNER JOIN tb_pn_summary_det pnsd ON pnsd.`id_pn`=pyd.`id_pn` AND pnsd.`id_pn_summary`='" & id_sum & "'"

        If data_head.Rows(0)("id_currency").ToString = "1" Then
            q += " GROUP BY py.id_pn "
        Else
            q += " GROUP BY pyd.id_pn_det "
        End If
        '
        Dim dt_det As DataTable = execute_query(q, -1, True, "", "", "", "")

        For j = 0 To dt_det.Rows.Count - 1
            Dim row_det As DevExpress.XtraReports.UI.XRTableRow = New DevExpress.XtraReports.UI.XRTableRow
            row_det.HeightF = 15
            'no
            Dim no As DevExpress.XtraReports.UI.XRTableCell = New DevExpress.XtraReports.UI.XRTableCell
            no.Text = (j + 1).ToString
            no.Borders = DevExpress.XtraPrinting.BorderSide.None
            no.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
            no.BackColor = Color.Transparent
            no.Font = font_row_style
            no.WidthF = 40

            row_det.Cells.Add(no)

            'penerima
            Dim descrip As DevExpress.XtraReports.UI.XRTableCell = New DevExpress.XtraReports.UI.XRTableCell
            descrip.Text = dt_det.Rows(j)("comp_name").ToString
            descrip.Borders = DevExpress.XtraPrinting.BorderSide.None
            descrip.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
            descrip.BackColor = Color.Transparent
            descrip.Font = font_row_style
            descrip.WidthF = 200

            row_det.Cells.Add(descrip)

            'bbk no
            Dim bbk_no As DevExpress.XtraReports.UI.XRTableCell = New DevExpress.XtraReports.UI.XRTableCell
            bbk_no.Text = dt_det.Rows(j)("number").ToString
            bbk_no.Borders = DevExpress.XtraPrinting.BorderSide.None
            bbk_no.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
            bbk_no.BackColor = Color.Transparent
            bbk_no.Font = font_row_style
            bbk_no.WidthF = 100

            row_det.Cells.Add(bbk_no)

            'value
            Dim price As DevExpress.XtraReports.UI.XRTableCell = New DevExpress.XtraReports.UI.XRTableCell
            price.Text = data_head.Rows(0)("currency").ToString & " " & Decimal.Parse(dt_det.Rows(j)("value").ToString).ToString("N0")
            price.Borders = DevExpress.XtraPrinting.BorderSide.None
            price.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
            price.BackColor = Color.Transparent
            price.Font = font_row_style
            price.WidthF = 140

            row_det.Cells.Add(price)

            'total
            Dim amo As DevExpress.XtraReports.UI.XRTableCell = New DevExpress.XtraReports.UI.XRTableCell
            amo.Text = data_head.Rows(0)("currency").ToString & " " & Decimal.Parse(dt_det.Rows(j)("val_total").ToString).ToString("N0")
            amo.Borders = DevExpress.XtraPrinting.BorderSide.None
            amo.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
            amo.BackColor = Color.Transparent
            amo.Font = font_row_style
            amo.WidthF = 140

            row_det.Cells.Add(amo)

            'notes
            Dim notes As DevExpress.XtraReports.UI.XRTableCell = New DevExpress.XtraReports.UI.XRTableCell
            notes.Text = dt_det.Rows(j)("note").ToString
            notes.Borders = DevExpress.XtraPrinting.BorderSide.None
            notes.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
            notes.Padding = "5"
            notes.BackColor = Color.Transparent
            notes.Font = font_row_style
            notes.WidthF = 120

            row_det.Cells.Add(notes)

            XTable.Rows.Add(row_det)
        Next

        pre_load_list_horz("251", 2, 1, XrTable1)

        'If id_pre = "1" Then
        '    pre_load_mark_horz(rmt, id_inv_mat, LabelStoreName.Text, "2", XrTable1)
        'Else
        '    load_mark_horz(rmt, id_inv_mat, LabelStoreName.Text, "2", XrTable1)
        'End If
    End Sub
End Class