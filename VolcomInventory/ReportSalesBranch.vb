Public Class ReportSalesBranch
    Public Shared id As String = "-1"
    Public Shared rmt As String = "-1"
    Public Shared id_report_status As String = "-1"

    Private Sub ReportSalesBranch_BeforePrint(sender As Object, e As Printing.PrintEventArgs) Handles MyBase.BeforePrint
        'header
        If rmt = "254" Then
            LabelTitle.Text = "BUKTI PENJUALAN"
        ElseIf rmt = "256" Then
            LabelTitle.Text = "BUKTI CREDIT NOTE"
        End If

        Dim query As String = "SELECT py.id_sales_branch, py.number AS `report_number`, 
        DATE_FORMAT(py.created_date,'%d-%m-%Y') AS `created_date`,
        DATE_FORMAT(py.transaction_date,'%d-%m-%Y') AS `sales_date`,
        py.value AS `amount`,
        py.note AS `note`, d.report_status, t.tag_description AS `own_comp_name`, 
        DATE_FORMAT(NOW(),'%d-%m-%Y %H:%i:%s') AS `printed_date`, eusr.employee_name AS `printed_by`
        FROM tb_sales_branch py
        JOIN tb_opt o
        INNER JOIN tb_coa_tag t ON t.id_coa_tag = py.id_coa_tag
        INNER JOIN tb_lookup_report_status d ON d.id_report_status = py.id_report_status 
        JOIN tb_m_user usr ON usr.id_user=" + id_user + "
        INNER JOIN tb_m_employee eusr ON eusr.id_employee = usr.id_employee
        WHERE py.id_sales_branch=" + id + " "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        DataSource = data

        'initial
        LabelAmount.Text = Decimal.Parse(data.Rows(0)("amount").ToString).ToString("N2")
        LabelSay.Text = "Say : " + ConvertCurrencyToEnglish(data.Rows(0)("amount"), get_setup_field("id_currency_default"))

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
        Dim query As String = "-- payment detail
        SELECT coa.acc_name, c.comp_number, d.note, dc.dc_code, d.`value` AS `amount`
        FROM tb_sales_branch_det d
        INNER JOIN tb_a_acc coa ON coa.id_acc = d.id_acc
        LEFT JOIN tb_m_comp c ON c.id_comp = d.id_comp
        INNER JOIN tb_lookup_dc dc ON dc.id_dc = d.id_dc
        WHERE d.id_sales_branch=8 AND d.value>0
        UNION ALL
        -- rev normal
        SELECT coa.acc_name, c.comp_number, m.rev_normal_net_note AS `note`, 'K', m.rev_normal_net AS `amount`
        FROM tb_sales_branch m 
        INNER JOIN tb_a_acc coa ON coa.id_acc = m.rev_normal_net_acc
        LEFT JOIN tb_m_comp c ON c.id_comp = m.id_comp_normal
        WHERE m.id_sales_branch=8 AND m.rev_normal_net>0
        UNION ALL 
        -- ppn normal
        SELECT coa.acc_name, c.comp_number, m.rev_normal_ppn_note AS `note`, 'K', m.rev_normal_ppn AS `amount`
        FROM tb_sales_branch m 
        INNER JOIN tb_a_acc coa ON coa.id_acc = m.rev_normal_ppn_acc
        LEFT JOIN tb_m_comp c ON c.id_comp = m.id_comp_normal
        WHERE m.id_sales_branch=8 AND m.rev_normal_ppn>0
        UNION ALL 
        -- ap normal
        SELECT coa.acc_name, c.comp_number, m.comp_rev_normal_note AS `note`, 'K', m.comp_rev_normal AS `amount`
        FROM tb_sales_branch m 
        INNER JOIN tb_a_acc coa ON coa.id_acc = m.comp_rev_normal_acc
        LEFT JOIN tb_m_comp c ON c.id_comp = m.id_comp_normal
        WHERE m.id_sales_branch=8 AND m.comp_rev_normal>0
        UNION ALL 
        -- rev sale
        SELECT coa.acc_name, c.comp_number, m.rev_sale_net_note AS `note`, 'K', m.rev_sale_net AS `amount`
        FROM tb_sales_branch m 
        INNER JOIN tb_a_acc coa ON coa.id_acc = m.rev_sale_net_acc
        LEFT JOIN tb_m_comp c ON c.id_comp = m.id_comp_sale
        WHERE m.id_sales_branch=8 AND m.rev_normal_net>0
        UNION ALL
        -- ppn sale
        SELECT coa.acc_name, c.comp_number, m.rev_sale_ppn_note AS `note`, 'K', m.rev_sale_ppn AS `amount`
        FROM tb_sales_branch m 
        INNER JOIN tb_a_acc coa ON coa.id_acc = m.rev_sale_ppn_acc
        LEFT JOIN tb_m_comp c ON c.id_comp = m.id_comp_sale
        WHERE m.id_sales_branch=8 AND m.rev_sale_ppn>0
        UNION ALL 
        -- ap sale
        SELECT coa.acc_name, c.comp_number, m.comp_rev_sale_note AS `note`, 'K', m.comp_rev_sale AS `amount`
        FROM tb_sales_branch m 
        INNER JOIN tb_a_acc coa ON coa.id_acc = m.comp_rev_sale_acc
        LEFT JOIN tb_m_comp c ON c.id_comp = m.id_comp_sale
        WHERE m.id_sales_branch=8 AND m.comp_rev_sale>0 "
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
            coa.Text = data.Rows(i)("acc_name").ToString
            coa.Borders = DevExpress.XtraPrinting.BorderSide.None
            coa.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
            coa.BackColor = Color.Transparent
            coa.Font = font_row_style

            'cc
            Dim cc As DevExpress.XtraReports.UI.XRTableCell = row.Cells.Item(2)
            cc.Text = data.Rows(i)("comp_number").ToString
            cc.Borders = DevExpress.XtraPrinting.BorderSide.None
            cc.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
            cc.BackColor = Color.Transparent
            cc.Font = font_row_style

            'note
            Dim note As DevExpress.XtraReports.UI.XRTableCell = row.Cells.Item(3)
            note.Text = data.Rows(i)("note").ToString
            note.Borders = DevExpress.XtraPrinting.BorderSide.None
            note.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
            note.BackColor = Color.Transparent
            note.Font = font_row_style


            'type_rec
            Dim type_rec As DevExpress.XtraReports.UI.XRTableCell = row.Cells.Item(4)
            type_rec.Text = data.Rows(i)("dc_code").ToString
            type_rec.Borders = DevExpress.XtraPrinting.BorderSide.None
            type_rec.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
            type_rec.BackColor = Color.Transparent
            type_rec.Font = font_row_style

            'amount
            Dim amo As DevExpress.XtraReports.UI.XRTableCell = row.Cells.Item(5)
            amo.Text = Decimal.Parse(data.Rows(i)("amount").ToString).ToString("N2")
            amo.Borders = DevExpress.XtraPrinting.BorderSide.None
            amo.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
            amo.BackColor = Color.Transparent
            amo.Font = font_row_style
        Next
    End Sub
End Class