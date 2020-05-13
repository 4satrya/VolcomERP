Public Class ReportRetOLStoreDet
    Public id As String = ""
    Public data As DataTable = New DataTable
    Public id_pre As String = ""
    Public report_mark_type As String = ""

    Private Sub ReportRetOLStoreDet_BeforePrint(sender As Object, e As Printing.PrintEventArgs) Handles MyBase.BeforePrint
        'detail
        Dim row As DevExpress.XtraReports.UI.XRTableRow = XTRow

        For i = 0 To data.Rows.Count - 1
            row = XTable.InsertRowBelow(row)

            row.HeightF = 17

            'no
            Dim no As DevExpress.XtraReports.UI.XRTableCell = row.Cells.Item(0)
            no.Text = (i + 1).ToString
            no.BorderWidth = 0
            no.Font = New Font(no.Font.FontFamily, no.Font.Size, FontStyle.Regular)

            'code
            Dim barcode As DevExpress.XtraReports.UI.XRTableCell = row.Cells.Item(1)
            barcode.Text = data.Rows(i)("product_full_code").ToString
            barcode.BorderWidth = 0
            barcode.Font = New Font(barcode.Font.FontFamily, barcode.Font.Size, FontStyle.Regular)

            'description
            Dim description As DevExpress.XtraReports.UI.XRTableCell = row.Cells.Item(2)
            description.Text = data.Rows(i)("name").ToString
            description.BorderWidth = 0
            description.Font = New Font(description.Font.FontFamily, description.Font.Size, FontStyle.Regular)

            'size
            Dim size As DevExpress.XtraReports.UI.XRTableCell = row.Cells.Item(3)
            size.Text = data.Rows(i)("size").ToString
            size.BorderWidth = 0
            size.Font = New Font(size.Font.FontFamily, size.Font.Size, FontStyle.Regular)

            'item id
            Dim item_id As DevExpress.XtraReports.UI.XRTableCell = row.Cells.Item(4)
            item_id.Text = data.Rows(i)("item_id").ToString
            item_id.BorderWidth = 0
            item_id.Font = New Font(item_id.Font.FontFamily, item_id.Font.Size, FontStyle.Regular)

            'ol store id
            Dim ol_store_id As DevExpress.XtraReports.UI.XRTableCell = row.Cells.Item(5)
            ol_store_id.Text = data.Rows(i)("ol_store_id").ToString
            ol_store_id.BorderWidth = 0
            ol_store_id.Font = New Font(ol_store_id.Font.FontFamily, ol_store_id.Font.Size, FontStyle.Regular)
        Next

        If id_pre = "-1" Then
            load_mark_horz(report_mark_type, id, "2", "1", XrTable)
        Else
            pre_load_mark_horz(report_mark_type, id, "2", "2", XrTable)
        End If

        XRCompany.Text = execute_query("SELECT comp_name FROM tb_m_comp WHERE id_comp = (SELECT id_own_company FROM tb_opt LIMIT 1)", 0, True, "", "", "", "")
    End Sub
End Class