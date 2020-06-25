Public Class ReportRequestRetOLStore
    Public id As String = ""
    Public data As DataTable = New DataTable
    Public id_pre As String = ""
    Public report_mark_type As String = ""

    Private Sub ReportRequestRetOLStore_BeforePrint(sender As Object, e As Printing.PrintEventArgs) Handles MyBase.BeforePrint
        'detail
        Dim row As DevExpress.XtraReports.UI.XRTableRow = XTRow

        Dim total_design_price As Decimal = 0.00

        For i = 0 To data.Rows.Count - 1
            row = XTable.InsertRowBelow(row)

            row.HeightF = 17

            'no
            Dim no As DevExpress.XtraReports.UI.XRTableCell = row.Cells.Item(0)
            no.Text = (i + 1).ToString
            no.BorderWidth = 1
            no.Borders = DevExpress.XtraPrinting.BorderSide.Left
            no.Font = New Font(no.Font.FontFamily, no.Font.Size, FontStyle.Regular)

            'code
            Dim barcode As DevExpress.XtraReports.UI.XRTableCell = row.Cells.Item(1)
            barcode.Text = data.Rows(i)("code").ToString
            barcode.BorderWidth = 0
            barcode.Font = New Font(barcode.Font.FontFamily, barcode.Font.Size, FontStyle.Regular)

            'product_full_code
            Dim product_full_code As DevExpress.XtraReports.UI.XRTableCell = row.Cells.Item(2)
            product_full_code.Text = data.Rows(i)("product_full_code").ToString
            product_full_code.BorderWidth = 0
            product_full_code.Font = New Font(barcode.Font.FontFamily, barcode.Font.Size, FontStyle.Regular)

            'description
            Dim description As DevExpress.XtraReports.UI.XRTableCell = row.Cells.Item(3)
            description.Text = data.Rows(i)("name").ToString
            description.BorderWidth = 0
            description.Font = New Font(description.Font.FontFamily, description.Font.Size, FontStyle.Regular)

            'size
            Dim size As DevExpress.XtraReports.UI.XRTableCell = row.Cells.Item(4)
            size.Text = data.Rows(i)("size").ToString
            size.BorderWidth = 0
            size.Font = New Font(size.Font.FontFamily, size.Font.Size, FontStyle.Regular)

            'status
            Dim design_cat As DevExpress.XtraReports.UI.XRTableCell = row.Cells.Item(5)
            design_cat.Text = data.Rows(i)("design_cat").ToString
            design_cat.BorderWidth = 0
            design_cat.Font = New Font(design_cat.Font.FontFamily, design_cat.Font.Size, FontStyle.Regular)

            'unit price
            Dim design_price As DevExpress.XtraReports.UI.XRTableCell = row.Cells.Item(6)
            design_price.Text = Format(data.Rows(i)("design_price"), "##,##0")
            design_price.BorderWidth = 0
            design_price.Font = New Font(design_price.Font.FontFamily, design_price.Font.Size, FontStyle.Regular)

            'item id
            Dim item_id As DevExpress.XtraReports.UI.XRTableCell = row.Cells.Item(7)
            item_id.Text = data.Rows(i)("item_id").ToString
            item_id.BorderWidth = 0
            item_id.Font = New Font(item_id.Font.FontFamily, item_id.Font.Size, FontStyle.Regular)

            'ol store id
            Dim ol_store_id As DevExpress.XtraReports.UI.XRTableCell = row.Cells.Item(8)
            ol_store_id.Text = data.Rows(i)("ol_store_id").ToString
            ol_store_id.BorderWidth = 1
            ol_store_id.Borders = DevExpress.XtraPrinting.BorderSide.Right
            ol_store_id.Font = New Font(ol_store_id.Font.FontFamily, ol_store_id.Font.Size, FontStyle.Regular)

            total_design_price += data.Rows(i)("design_price")
        Next

        XTCTotal.Text = Format(total_design_price, "##,##0")

        XrRowTotal.HeightF = 25

        If id_pre = "-1" Then
            load_mark_horz(report_mark_type, id, "2", "1", XrTable)
        Else
            pre_load_mark_horz(report_mark_type, id, "2", "2", XrTable)
        End If
    End Sub
End Class