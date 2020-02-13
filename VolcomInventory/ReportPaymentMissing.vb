Public Class ReportPaymentMissing
    Public Shared id As String = "-1"
    Public Shared rmt As String = "-1"
    Public Shared id_report_status As String = "-1"

    Private Sub ReportPaymentMissing_BeforePrint(sender As Object, e As Printing.PrintEventArgs) Handles MyBase.BeforePrint
        Dim query As String = "SELECT py.id_missing_payment, py.number AS `report_number`, 
        DATE_FORMAT(py.date_created,'%d-%m-%Y') AS `created_date`,
        DATE_FORMAT(py.date_received,'%d-%m-%Y') AS `rec_date`,
        CONCAT(a.acc_name, ' - ', a.acc_description) AS `missing_payment_to`,py.value AS `amount`,
        py.note AS `note`, d.report_status, co.npwp_name AS `own_comp_name`, co.npwp AS `own_comp_npwp`,
        DATE_FORMAT(NOW(),'%d-%m-%Y %H:%i:%s') AS `printed_date`, eusr.employee_name AS `printed_by`
        FROM tb_missing_payment py
        INNER JOIN tb_a_acc a ON a.id_acc = py.id_acc_pay_rec
        JOIN tb_opt o
        LEFT JOIN tb_m_comp co ON co.id_comp  = o.id_own_company
        INNER JOIN tb_lookup_report_status d ON d.id_report_status = py.id_report_status 
        JOIN tb_m_user usr ON usr.id_user=" + id_user + "
        INNER JOIN tb_m_employee eusr ON eusr.id_employee = usr.id_employee
        WHERE py.id_missing_payment=" + id + " "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        DataSource = data

        'initial
        XrLabel4.Text = data.Rows(0)("missing_payment_to").ToString
        LabelAmount.Text = Decimal.Parse(data.Rows(0)("amount").ToString).ToString("N2")
        LabelSay.Text = "Say : " + ConvertCurrencyToEnglish(data.Rows(0)("amount"), get_setup_field("id_currency_default"))
        LabelBillType.Text = execute_query("SELECT bill_type FROM tb_lookup_bill_type WHERE id_bill_type = 25", 0, True, "", "", "", "")

        'detail
        viewDetail()

        'report status
        Dim itime As String = "2"
        If id_report_status = "1" Then
            itime = "2"
        ElseIf id_report_status = "6" Then
            itime = "1"
        End If
        pre_load_mark_horz_plain_acc(rmt, id, "2", itime, XrTable1)
    End Sub

    Sub viewDetail()
        Dim row As DevExpress.XtraReports.UI.XRTableRow = New DevExpress.XtraReports.UI.XRTableRow
        Dim query As String = "(SELECT 0 AS `id_det`,'1' AS `is_header`, 0 AS `id_reff`,a.acc_name AS `coa`, '' AS `reff`, py.note, '' AS `vendor`,
        '000' AS `cc`, 'D' AS `type`, py.value AS `amount`
        FROM tb_missing_payment py
        INNER JOIN tb_a_acc a ON a.id_acc = py.id_acc_pay_rec
        WHERE py.id_missing_payment=" + id + " AND py.`value` > 0)
        UNION ALL
        (SELECT pyd.id_missing_payment_det AS `id_det`,'2' AS `is_header`, pyd.id_report AS `id_reff`, a.acc_name AS `coa`, pyd.number AS `reff`, pyd.note, pyd.vendor,
        comp.comp_number AS `cc`, dc.dc_code AS `type`, ABS(pyd.`value`) AS `amount` 
        FROM tb_missing_payment_det pyd
        INNER JOIN tb_lookup_dc dc ON dc.id_dc = pyd.id_dc
        INNER JOIN tb_a_acc a ON a.id_acc = pyd.id_acc
        LEFT JOIN tb_m_comp comp ON comp.id_comp = pyd.id_comp
        WHERE pyd.id_missing_payment=" + id + "
        ORDER BY pyd.id_missing_payment_det ASC)
        ORDER BY is_header ASC, id_det ASC "
        Dim data As DataTable = execute_query(query, "-1", True, "", "", "", "")

        Dim font_row_style As New Font("Tahoma", 8, FontStyle.Regular)
        For i = 0 To data.Rows.Count - 1
            'row
            If i = 0 Then
                row = XTable.InsertRowBelow(XTRow)
                row.HeightF = 15
            Else
                row = XTable.InsertRowBelow(row)
            End If

            'no
            Dim no As DevExpress.XtraReports.UI.XRTableCell = row.Cells.Item(0)
            no.Text = (i + 1).ToString + "."
            no.Borders = DevExpress.XtraPrinting.BorderSide.None
            no.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
            no.BackColor = Color.Transparent
            no.Font = font_row_style

            'coa
            Dim coa As DevExpress.XtraReports.UI.XRTableCell = row.Cells.Item(1)
            coa.Text = data.Rows(i)("coa").ToString
            coa.Borders = DevExpress.XtraPrinting.BorderSide.None
            coa.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
            coa.BackColor = Color.Transparent
            coa.Font = font_row_style

            'cc
            Dim cc As DevExpress.XtraReports.UI.XRTableCell = row.Cells.Item(2)
            cc.Text = data.Rows(i)("cc").ToString
            cc.Borders = DevExpress.XtraPrinting.BorderSide.None
            cc.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
            cc.BackColor = Color.Transparent
            cc.Font = font_row_style

            'reff
            Dim reff As DevExpress.XtraReports.UI.XRTableCell = row.Cells.Item(3)
            reff.Text = data.Rows(i)("reff").ToString
            reff.Borders = DevExpress.XtraPrinting.BorderSide.None
            reff.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
            reff.BackColor = Color.Transparent
            reff.Font = font_row_style

            'note
            Dim note As DevExpress.XtraReports.UI.XRTableCell = row.Cells.Item(4)
            note.Text = data.Rows(i)("note").ToString
            note.Borders = DevExpress.XtraPrinting.BorderSide.None
            note.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
            note.BackColor = Color.Transparent
            note.Font = font_row_style

            'vendor
            Dim vendor As DevExpress.XtraReports.UI.XRTableCell = row.Cells.Item(5)
            vendor.Text = data.Rows(i)("vendor").ToString
            vendor.Borders = DevExpress.XtraPrinting.BorderSide.None
            vendor.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
            vendor.BackColor = Color.Transparent
            vendor.Font = font_row_style

            'type_rec
            Dim type_rec As DevExpress.XtraReports.UI.XRTableCell = row.Cells.Item(6)
            type_rec.Text = data.Rows(i)("type").ToString
            type_rec.Borders = DevExpress.XtraPrinting.BorderSide.None
            type_rec.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
            type_rec.BackColor = Color.Transparent
            type_rec.Font = font_row_style

            'amount
            Dim amo As DevExpress.XtraReports.UI.XRTableCell = row.Cells.Item(7)
            amo.Text = Decimal.Parse(data.Rows(i)("amount").ToString).ToString("N2")
            amo.Borders = DevExpress.XtraPrinting.BorderSide.None
            amo.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
            amo.BackColor = Color.Transparent
            amo.Font = font_row_style
        Next
    End Sub
End Class