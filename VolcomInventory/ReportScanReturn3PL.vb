Public Class ReportScanReturn3PL
    Public data_det As DataTable
    Public data_awb As DataTable

    Private Sub ReportScanReturn3PL_BeforePrint(sender As Object, e As Printing.PrintEventArgs) Handles MyBase.BeforePrint
        '============ awb
        Dim row_awb As DevExpress.XtraReports.UI.XRTableRow = New DevExpress.XtraReports.UI.XRTableRow
        Dim id_awb_cur As String = "-1"

        Dim tot_berat As Decimal = 0.00
        Dim tot_berat_dimensi As Decimal = 0.00
        Dim tot_final_berat As Decimal = 0.00

        Dim final_tot_berat As Decimal = 0.00
        Dim final_tot_berat_dimensi As Decimal = 0.00
        Dim final_tot_final_berat As Decimal = 0.00

        Dim total_awb As Integer = 0

        For i = 0 To data_awb.Rows.Count - 1
            'row

            If i = 0 Then
                row_awb = XTAWB.InsertRowBelow(XTTopAwb)
                row_awb.HeightF = 16
            Else
                row_awb = XTAWB.InsertRowBelow(row_awb)
            End If
            '
            row_awb.Font = New Font("Tahoma", 7.5, FontStyle.Regular)
            '
            If Not id_awb_cur = data_awb.Rows(i)("id_inbound_awb").ToString Then
                'awb number
                Dim awb As DevExpress.XtraReports.UI.XRTableCell = row_awb.Cells.Item(0)
                awb.Text = data_awb.Rows(i)("awb_number").ToString
                awb.Borders = DevExpress.XtraPrinting.BorderSide.Top Or DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Bottom
                awb.BackColor = Color.Transparent
                '
                For j = i + 1 To data_awb.Rows.Count - 1
                    If data_awb.Rows(i)("id_inbound_awb").ToString = data_awb.Rows(j)("id_inbound_awb").ToString Then
                        awb.RowSpan += 1
                    End If
                Next
            End If

            'berat
            Dim berat As DevExpress.XtraReports.UI.XRTableCell = row_awb.Cells.Item(1)

            berat.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
            berat.Text = Decimal.Parse(data_awb.Rows(i)("berat").ToString).ToString("N2")
            berat.Borders = DevExpress.XtraPrinting.BorderSide.Top Or DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Bottom
            berat.BackColor = Color.Transparent

            'panjang
            Dim panjang As DevExpress.XtraReports.UI.XRTableCell = row_awb.Cells.Item(2)

            panjang.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
            panjang.Text = Decimal.Parse(data_awb.Rows(i)("panjang").ToString).ToString("N2")
            panjang.Borders = DevExpress.XtraPrinting.BorderSide.Top Or DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Bottom
            panjang.BackColor = Color.Transparent

            'lebar
            Dim lebar As DevExpress.XtraReports.UI.XRTableCell = row_awb.Cells.Item(3)

            lebar.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
            lebar.Text = Decimal.Parse(data_awb.Rows(i)("lebar").ToString).ToString("N2")
            lebar.Borders = DevExpress.XtraPrinting.BorderSide.Top Or DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Bottom
            lebar.BackColor = Color.Transparent

            'tinggi
            Dim tinggi As DevExpress.XtraReports.UI.XRTableCell = row_awb.Cells.Item(4)

            tinggi.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
            tinggi.Text = Decimal.Parse(data_awb.Rows(i)("tinggi").ToString).ToString("N2")
            tinggi.Borders = DevExpress.XtraPrinting.BorderSide.Top Or DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Bottom
            tinggi.BackColor = Color.Transparent

            'berat_dimensi
            Dim berat_dimensi As DevExpress.XtraReports.UI.XRTableCell = row_awb.Cells.Item(5)

            berat_dimensi.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
            berat_dimensi.Text = Decimal.Parse(data_awb.Rows(i)("berat_dimensi").ToString).ToString("N2")
            berat_dimensi.Borders = DevExpress.XtraPrinting.BorderSide.Top Or DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Bottom
            berat_dimensi.BackColor = Color.Transparent

            'final_berat
            Dim final_berat As DevExpress.XtraReports.UI.XRTableCell = row_awb.Cells.Item(6)

            final_berat.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
            final_berat.Text = Decimal.Parse(data_awb.Rows(i)("final_berat").ToString).ToString("N2")
            final_berat.Borders = DevExpress.XtraPrinting.BorderSide.Top Or DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Right Or DevExpress.XtraPrinting.BorderSide.Bottom
            final_berat.BackColor = Color.Transparent
            '
            id_awb_cur = data_awb.Rows(i)("id_inbound_awb").ToString

            Dim is_insert_total As Boolean = False

            tot_berat += Decimal.Parse(data_awb.Rows(i)("berat").ToString)
            tot_berat_dimensi += Decimal.Parse(data_awb.Rows(i)("berat_dimensi").ToString)
            tot_final_berat += Decimal.Parse(data_awb.Rows(i)("final_berat").ToString)

            If i = data_awb.Rows.Count - 1 Then
                is_insert_total = True
            ElseIf Not id_awb_cur = data_awb.Rows(i)("id_inbound_awb").ToString Then
                is_insert_total = True
            Else
                'lanjut blm total

            End If
            '
            If is_insert_total Then
                total_awb += 1
                row_awb = XTAWB.InsertRowBelow(row_awb)
                row_awb.BackColor = Color.LightGray

                Dim awb_tot As DevExpress.XtraReports.UI.XRTableCell = row_awb.Cells.Item(0)
                awb_tot.BackColor = Color.LightGray
                awb_tot.Text = "Sub Total"

                'berat
                Dim berat_tot As DevExpress.XtraReports.UI.XRTableCell = row_awb.Cells.Item(1)
                berat_tot.BackColor = Color.LightGray

                berat_tot.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
                berat_tot.Text = Decimal.Parse(tot_berat.ToString).ToString("N2")
                berat_tot.Borders = DevExpress.XtraPrinting.BorderSide.Top Or DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Bottom

                Dim panjang_tot As DevExpress.XtraReports.UI.XRTableCell = row_awb.Cells.Item(2)
                panjang_tot.BackColor = Color.LightGray
                Dim lebar_tot As DevExpress.XtraReports.UI.XRTableCell = row_awb.Cells.Item(3)
                lebar_tot.BackColor = Color.LightGray
                Dim tinggi_tot As DevExpress.XtraReports.UI.XRTableCell = row_awb.Cells.Item(4)
                tinggi_tot.BackColor = Color.LightGray

                'berat_dimensi
                Dim berat_dimensi_tot As DevExpress.XtraReports.UI.XRTableCell = row_awb.Cells.Item(5)
                berat_dimensi_tot.BackColor = Color.LightGray

                berat_dimensi_tot.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
                berat_dimensi_tot.Text = Decimal.Parse(tot_berat_dimensi.ToString).ToString("N2")
                berat_dimensi_tot.Borders = DevExpress.XtraPrinting.BorderSide.Top Or DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Bottom

                'final_berat
                Dim final_berat_tot As DevExpress.XtraReports.UI.XRTableCell = row_awb.Cells.Item(6)
                final_berat_tot.BackColor = Color.LightGray

                final_berat_tot.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
                final_berat_tot.Text = Decimal.Parse(tot_final_berat.ToString).ToString("N2")
                final_berat_tot.Borders = DevExpress.XtraPrinting.BorderSide.Top Or DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Right Or DevExpress.XtraPrinting.BorderSide.Bottom
                '
                final_tot_berat += tot_berat
                final_tot_berat_dimensi += tot_berat_dimensi
                final_tot_final_berat += tot_final_berat
                '
                tot_berat = 0.00
                tot_berat_dimensi = 0.00
                tot_final_berat = 0.00
            End If
        Next

        LFinalTotBerat.Text = final_tot_berat.ToString
        LFinalTotVolume.Text = final_tot_berat_dimensi.ToString
        LFinalTotalBerat.Text = final_tot_final_berat.ToString
        LTotalAwB.Text = total_awb.ToString

        '============ detail
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

            'awb_number
            Dim awb_number As DevExpress.XtraReports.UI.XRTableCell = row.Cells.Item(0)
            awb_number.WordWrap = True
            awb_number.Multiline = True
            awb_number.Text = data_det.Rows(i)("awb_number").ToString
            awb_number.Borders = DevExpress.XtraPrinting.BorderSide.Top Or DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Bottom
            awb_number.BackColor = Color.Transparent

            'list store
            Dim list_store As DevExpress.XtraReports.UI.XRTableCell = row.Cells.Item(1)
            list_store.WordWrap = True
            list_store.Multiline = True
            list_store.Text = data_det.Rows(i)("store_list").ToString
            list_store.Borders = DevExpress.XtraPrinting.BorderSide.Top Or DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Bottom
            list_store.BackColor = Color.Transparent

            'return note
            Dim nota_retur As DevExpress.XtraReports.UI.XRTableCell = row.Cells.Item(2)

            nota_retur.Text = data_det.Rows(i)("number_return_note").ToString
            nota_retur.Borders = DevExpress.XtraPrinting.BorderSide.Top Or DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Bottom
            nota_retur.BackColor = Color.Transparent

            'tanggal scan barang
            Dim date_created As DevExpress.XtraReports.UI.XRTableCell = row.Cells.Item(3)

            date_created.Text = Date.Parse(data_det.Rows(i)("date_created").ToString).ToString("dd MMMM yyyy")
            date_created.Borders = DevExpress.XtraPrinting.BorderSide.Top Or DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Bottom
            date_created.BackColor = Color.Transparent

            'Qty Return Note
            Dim qty_return_note As DevExpress.XtraReports.UI.XRTableCell = row.Cells.Item(4)

            qty_return_note.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
            qty_return_note.Text = Decimal.Parse(data_det.Rows(i)("qty_return_note").ToString).ToString("N0")
            qty_return_note.Borders = DevExpress.XtraPrinting.BorderSide.Top Or DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Bottom
            qty_return_note.BackColor = Color.Transparent

            'Qty Scan
            Dim qty_scan As DevExpress.XtraReports.UI.XRTableCell = row.Cells.Item(5)

            qty_scan.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
            qty_scan.Text = Decimal.Parse(data_det.Rows(i)("qty_scan").ToString).ToString("N0")
            qty_scan.Borders = DevExpress.XtraPrinting.BorderSide.Top Or DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Bottom
            qty_scan.BackColor = Color.Transparent

            'Diff Qty 
            Dim qty_bap As DevExpress.XtraReports.UI.XRTableCell = row.Cells.Item(6)

            qty_bap.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
            qty_bap.Text = Decimal.Parse(data_det.Rows(i)("qty_bap").ToString).ToString("N0")
            qty_bap.Borders = DevExpress.XtraPrinting.BorderSide.Top Or DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Bottom
            qty_bap.BackColor = Color.Transparent

            'bap number
            Dim bap_number As DevExpress.XtraReports.UI.XRTableCell = row.Cells.Item(7)

            bap_number.Text = data_det.Rows(i)("bap_number").ToString
            bap_number.Borders = DevExpress.XtraPrinting.BorderSide.Top Or DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Bottom
            bap_number.BackColor = Color.Transparent

            'Remark 
            Dim notes As DevExpress.XtraReports.UI.XRTableCell = row.Cells.Item(8)

            notes.WordWrap = True
            notes.Multiline = True
            notes.Text = ""
            notes.Borders = DevExpress.XtraPrinting.BorderSide.Top Or DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Right Or DevExpress.XtraPrinting.BorderSide.Bottom
            notes.BackColor = Color.Transparent
        Next
        XRTotal.HeightF = 16
        XRTotWeight.HeightF = 16
        XRTotAWB.HeightF = 16
    End Sub
End Class