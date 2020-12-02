Public Class ReportAccountingLedger
    Public data As DataTable = New DataTable

    Private Sub ReportAccountingLedger_BeforePrint(sender As Object, e As Printing.PrintEventArgs) Handles MyBase.BeforePrint
        Dim data_group As DataTable = New DataTable

        'new data with group, detail & total
        data_group.Columns.Add("number")
        data_group.Columns.Add("report_number")
        data_group.Columns.Add("comp_number")
        data_group.Columns.Add("vendor_name")
        data_group.Columns.Add("date_created")
        data_group.Columns.Add("report_number_ref")
        data_group.Columns.Add("acc_trans_note")
        data_group.Columns.Add("qty")
        data_group.Columns.Add("debit")
        data_group.Columns.Add("credit")
        data_group.Columns.Add("balance")
        data_group.Columns.Add("type")

        Dim last_parent As String = ""
        Dim last_parent_1 As String = ""

        Dim d_last_parent As Decimal = 0.00
        Dim c_last_parent As Decimal = 0.00

        Dim d_last_parent_1 As Decimal = 0.00
        Dim c_last_parent_1 As Decimal = 0.00
        Dim b_last_parent_1 As Decimal = 0.00

        For i = 0 To data.Rows.Count - 1
            If Not i = 0 Then
                If Not last_parent = data.Rows(i)("acc_name").ToString Then
                    data_group.Rows.Add(
                        "SUB TOTAL: " + data.Rows(i - 1)("acc_name").ToString,
                        "",
                        "",
                        "",
                        "",
                        "",
                        "",
                        "",
                        d_last_parent,
                        c_last_parent,
                        data.Rows(i - 1)("balance"),
                        "total"
                    )

                    d_last_parent = 0.00
                    c_last_parent = 0.00

                    b_last_parent_1 = b_last_parent_1 + data.Rows(i - 1)("balance")
                End If

                'total
                If Not last_parent_1 = data.Rows(i)("acc_name_1").ToString Then
                    data_group.Rows.Add(
                        "SUB TOTAL: " + data.Rows(i - 1)("acc_name_1").ToString,
                        "",
                        "",
                        "",
                        "",
                        "",
                        "",
                        "",
                        d_last_parent_1,
                        c_last_parent_1,
                        b_last_parent_1,
                        "total"
                    )

                    d_last_parent_1 = 0.00
                    c_last_parent_1 = 0.00
                    b_last_parent_1 = 0.00
                End If
            End If

            'group
            If Not last_parent_1 = data.Rows(i)("acc_name_1").ToString Then
                data_group.Rows.Add(
                    data.Rows(i)("acc_name_1").ToString,
                    "",
                    "",
                    "",
                    "",
                    "",
                    "",
                    "",
                    0.00,
                    0.00,
                    0.00,
                    "group"
                )
            End If

            If Not last_parent = data.Rows(i)("acc_name").ToString Then
                data_group.Rows.Add(
                    data.Rows(i)("acc_name").ToString,
                    "",
                    "",
                    "",
                    "",
                    "",
                    "",
                    "",
                    0.00,
                    0.00,
                    0.00,
                    "group"
                )
            End If

            If i = 0 Then
                last_parent = data.Rows(i)("acc_name").ToString
                last_parent_1 = data.Rows(i)("acc_name_1").ToString
            End If

            'detail
            data_group.Rows.Add(
                data.Rows(i)("number").ToString,
                data.Rows(i)("report_number").ToString,
                data.Rows(i)("comp_number"),
                data.Rows(i)("vendor_name"),
                data.Rows(i)("date_created"),
                data.Rows(i)("report_number_ref"),
                data.Rows(i)("acc_trans_note"),
                data.Rows(i)("qty"),
                data.Rows(i)("debit"),
                data.Rows(i)("credit"),
                data.Rows(i)("balance"),
                ""
            )

            d_last_parent = d_last_parent + data.Rows(i)("debit")
            c_last_parent = c_last_parent + data.Rows(i)("credit")

            d_last_parent_1 = d_last_parent_1 + data.Rows(i)("debit")
            c_last_parent_1 = c_last_parent_1 + data.Rows(i)("credit")

            If i = data.Rows.Count - 1 Then
                'total
                data_group.Rows.Add(
                    "SUB TOTAL: " + data.Rows(i)("acc_name").ToString,
                    "",
                    "",
                    "",
                    "",
                    "",
                    "",
                    "",
                    d_last_parent,
                    c_last_parent,
                    data.Rows(i)("balance"),
                    "total"
                )

                b_last_parent_1 = b_last_parent_1 + data.Rows(i)("balance")

                data_group.Rows.Add(
                    "SUB TOTAL: " + data.Rows(i)("acc_name_1").ToString,
                    "",
                    "",
                    "",
                    "",
                    "",
                    "",
                    "",
                    d_last_parent_1,
                    c_last_parent_1,
                    b_last_parent_1,
                    "total"
                )
            End If

            last_parent = data.Rows(i)("acc_name").ToString
            last_parent_1 = data.Rows(i)("acc_name_1").ToString
        Next

        'add table row
        XrTable.BeginInit()

        Dim row As DevExpress.XtraReports.UI.XRTableRow = XrTableRow

        For i = 0 To data_group.Rows.Count - 1
            row = XrTable.InsertRowBelow(row)

            row.Font = New Font(XrTableRow.Font.FontFamily, 7.75, If(data_group.Rows(i)("type").ToString = "group", FontStyle.Bold, FontStyle.Regular))
            row.HeightF = 20
            row.Tag = data_group.Rows(i)("type").ToString

            Dim number As DevExpress.XtraReports.UI.XRTableCell = row.Cells.Item(0)
            number.Text = data_group.Rows(i)("number").ToString + If(data_group.Rows(i)("type").ToString = "detail", ".", "")
            number.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0)
            number.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
            number.Borders = DevExpress.XtraPrinting.BorderSide.Right Or DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Bottom

            Dim report_number As DevExpress.XtraReports.UI.XRTableCell = row.Cells.Item(1)
            report_number.Text = data_group.Rows(i)("report_number").ToString
            report_number.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0)
            report_number.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
            report_number.Borders = DevExpress.XtraPrinting.BorderSide.Right Or DevExpress.XtraPrinting.BorderSide.Bottom

            Dim comp_number As DevExpress.XtraReports.UI.XRTableCell = row.Cells.Item(2)
            comp_number.Text = data_group.Rows(i)("comp_number").ToString
            comp_number.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0)
            comp_number.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
            comp_number.Borders = DevExpress.XtraPrinting.BorderSide.Right Or DevExpress.XtraPrinting.BorderSide.Bottom

            Dim vendor_name As DevExpress.XtraReports.UI.XRTableCell = row.Cells.Item(3)
            vendor_name.Text = data_group.Rows(i)("vendor_name").ToString
            vendor_name.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0)
            vendor_name.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
            vendor_name.Borders = DevExpress.XtraPrinting.BorderSide.Right Or DevExpress.XtraPrinting.BorderSide.Bottom

            Dim date_created As DevExpress.XtraReports.UI.XRTableCell = row.Cells.Item(4)
            date_created.Text = If(data_group.Rows(i)("date_created").ToString = "", "", Date.Parse(data_group.Rows(i)("date_created").ToString).ToString("dd MMM yyyy"))
            date_created.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0)
            date_created.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
            date_created.Borders = DevExpress.XtraPrinting.BorderSide.Right Or DevExpress.XtraPrinting.BorderSide.Bottom

            Dim report_number_ref As DevExpress.XtraReports.UI.XRTableCell = row.Cells.Item(5)
            report_number_ref.Text = data_group.Rows(i)("report_number_ref").ToString
            report_number_ref.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0)
            report_number_ref.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
            report_number_ref.Borders = DevExpress.XtraPrinting.BorderSide.Right Or DevExpress.XtraPrinting.BorderSide.Bottom

            Dim acc_trans_note As DevExpress.XtraReports.UI.XRTableCell = row.Cells.Item(6)
            acc_trans_note.Text = data_group.Rows(i)("acc_trans_note").ToString
            acc_trans_note.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0)
            acc_trans_note.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
            acc_trans_note.Borders = DevExpress.XtraPrinting.BorderSide.Right Or DevExpress.XtraPrinting.BorderSide.Bottom
            acc_trans_note.WordWrap = False
            Dim qty As DevExpress.XtraReports.UI.XRTableCell = row.Cells.Item(7)
            qty.Text = If(data_group.Rows(i)("qty").ToString = "", "", Format(Decimal.Parse(data_group.Rows(i)("qty").ToString), "##,##0.00"))
            qty.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0)
            qty.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
            qty.Borders = DevExpress.XtraPrinting.BorderSide.Right Or DevExpress.XtraPrinting.BorderSide.Bottom

            Dim debit As DevExpress.XtraReports.UI.XRTableCell = row.Cells.Item(8)
            debit.Text = If(data_group.Rows(i)("debit").ToString = "", "", Format(Decimal.Parse(data_group.Rows(i)("debit").ToString), "##,##0.00"))
            debit.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0)
            debit.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
            debit.Borders = DevExpress.XtraPrinting.BorderSide.Right Or DevExpress.XtraPrinting.BorderSide.Bottom

            Dim credit As DevExpress.XtraReports.UI.XRTableCell = row.Cells.Item(9)
            credit.Text = If(data_group.Rows(i)("credit").ToString = "", "", Format(Decimal.Parse(data_group.Rows(i)("credit").ToString), "##,##0.00"))
            credit.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0)
            credit.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
            credit.Borders = DevExpress.XtraPrinting.BorderSide.Right Or DevExpress.XtraPrinting.BorderSide.Bottom

            Dim balance As DevExpress.XtraReports.UI.XRTableCell = row.Cells.Item(10)
            balance.Text = If(data_group.Rows(i)("balance").ToString = "", "", Format(Decimal.Parse(data_group.Rows(i)("balance").ToString), "##,##0.00"))
            balance.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0)
            balance.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
            balance.Borders = DevExpress.XtraPrinting.BorderSide.Right Or DevExpress.XtraPrinting.BorderSide.Bottom
        Next

        'rowspan
        For i = 0 To XrTable.Rows.Count - 1
            If XrTable.Rows.Item(i).Tag = "group" Then
                XrTable.Rows.Item(i).Cells.RemoveAt(10)
                XrTable.Rows.Item(i).Cells.RemoveAt(9)
                XrTable.Rows.Item(i).Cells.RemoveAt(8)
                XrTable.Rows.Item(i).Cells.RemoveAt(7)
                XrTable.Rows.Item(i).Cells.RemoveAt(6)
                XrTable.Rows.Item(i).Cells.RemoveAt(5)
                XrTable.Rows.Item(i).Cells.RemoveAt(4)
                XrTable.Rows.Item(i).Cells.RemoveAt(3)
                XrTable.Rows.Item(i).Cells.RemoveAt(2)
                XrTable.Rows.Item(i).Cells.RemoveAt(1)
            ElseIf XrTable.Rows.Item(i).Tag = "total" Then
                XrTable.Rows.Item(i).Cells.RemoveAt(7)
                XrTable.Rows.Item(i).Cells.RemoveAt(6)
                XrTable.Rows.Item(i).Cells.RemoveAt(5)
                XrTable.Rows.Item(i).Cells.RemoveAt(4)
                XrTable.Rows.Item(i).Cells.RemoveAt(3)
                XrTable.Rows.Item(i).Cells.RemoveAt(2)
                XrTable.Rows.Item(i).Cells.RemoveAt(1)

                XrTable.Rows.Item(i).Cells.Item(0).WidthF = XrTableCellNo.WidthF + XrTableCellReportNumber.WidthF + XrTableCellCompany.WidthF + +XrTableCellVendor.WidthF + XrTableCellJournalDate.WidthF + XrTableCellReff.WidthF + XrTableCellDescription.WidthF + XrTableCellQty.WidthF
                XrTable.Rows.Item(i).Cells.Item(1).WidthF = XrTableCellDebit.WidthF
                XrTable.Rows.Item(i).Cells.Item(2).WidthF = XrTableCellCredit.WidthF
                XrTable.Rows.Item(i).Cells.Item(3).WidthF = XrTableCellBalance.WidthF
            End If
        Next

        XrTable.EndInit()
    End Sub
End Class