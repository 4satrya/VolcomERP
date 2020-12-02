Public Class ReportScanReturnLocal
    Public data_det As DataTable

    Private Sub ReportScanReturnLocal_BeforePrint(sender As Object, e As Printing.PrintEventArgs) Handles MyBase.BeforePrint
        Dim row As DevExpress.XtraReports.UI.XRTableRow = New DevExpress.XtraReports.UI.XRTableRow

        For i = 0 To data_det.Rows.Count - 1
            'row
            If i = 0 Then
                row = XTDetail.InsertRowBelow(XTTop)
                row.HeightF = 16
            Else
                row = XTDetail.InsertRowBelow(row)
            End If

            row.Font = New Font("Tahoma", 7.5, FontStyle.Regular)

            'list store
            Dim list_store As DevExpress.XtraReports.UI.XRTableCell = row.Cells.Item(0)
            list_store.WordWrap = True
            list_store.Multiline = True
            list_store.Text = data_det.Rows(i)("store_list").ToString
            list_store.Borders = DevExpress.XtraPrinting.BorderSide.Top Or DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Bottom
            list_store.BackColor = Color.Transparent

            'return note
            Dim nota_retur As DevExpress.XtraReports.UI.XRTableCell = row.Cells.Item(1)

            nota_retur.Text = data_det.Rows(i)("number_return_note").ToString
            nota_retur.Borders = DevExpress.XtraPrinting.BorderSide.Top Or DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Bottom
            nota_retur.BackColor = Color.Transparent

            'tanggal scan barang
            Dim date_created As DevExpress.XtraReports.UI.XRTableCell = row.Cells.Item(2)

            date_created.Text = Date.Parse(data_det.Rows(i)("date_created").ToString).ToString("dd MMMM yyyy")
            date_created.Borders = DevExpress.XtraPrinting.BorderSide.Top Or DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Bottom
            date_created.BackColor = Color.Transparent

            'Qty Return Note
            Dim qty_return_note As DevExpress.XtraReports.UI.XRTableCell = row.Cells.Item(3)

            qty_return_note.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
            qty_return_note.Text = Decimal.Parse(data_det.Rows(i)("qty_return_note").ToString).ToString("N0")
            qty_return_note.Borders = DevExpress.XtraPrinting.BorderSide.Top Or DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Bottom
            qty_return_note.BackColor = Color.Transparent

            'Qty Scan
            Dim qty_scan As DevExpress.XtraReports.UI.XRTableCell = row.Cells.Item(4)

            qty_scan.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
            qty_scan.Text = Decimal.Parse(data_det.Rows(i)("qty_scan").ToString).ToString("N0")
            qty_scan.Borders = DevExpress.XtraPrinting.BorderSide.Top Or DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Bottom
            qty_scan.BackColor = Color.Transparent

            'Diff Qty 
            Dim qty_bap As DevExpress.XtraReports.UI.XRTableCell = row.Cells.Item(5)

            qty_bap.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
            qty_bap.Text = Decimal.Parse(data_det.Rows(i)("qty_bap").ToString).ToString("N0")
            qty_bap.Borders = DevExpress.XtraPrinting.BorderSide.Top Or DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Bottom
            qty_bap.BackColor = Color.Transparent

            'bap number
            Dim bap_number As DevExpress.XtraReports.UI.XRTableCell = row.Cells.Item(6)

            bap_number.Text = data_det.Rows(i)("bap_number").ToString
            bap_number.Borders = DevExpress.XtraPrinting.BorderSide.Top Or DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Bottom
            bap_number.BackColor = Color.Transparent

            'Remark 
            Dim notes As DevExpress.XtraReports.UI.XRTableCell = row.Cells.Item(7)

            notes.WordWrap = True
            notes.Multiline = True
            notes.Text = ""
            notes.Borders = DevExpress.XtraPrinting.BorderSide.Top Or DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Right Or DevExpress.XtraPrinting.BorderSide.Bottom
            notes.BackColor = Color.Transparent
        Next
        XRTotal.HeightF = 16
    End Sub
End Class