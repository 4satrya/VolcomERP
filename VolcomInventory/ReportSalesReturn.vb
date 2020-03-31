Public Class ReportSalesReturn
    Public Shared id_pre As String = "-1"
    Public Shared id_sales_return As String = "-1"
    Public Shared dt As DataTable
    Public report_mark_type As String = "-1"


    Private Sub ReportSalesReturn_BeforePrint(ByVal sender As System.Object, ByVal e As System.Drawing.Printing.PrintEventArgs) Handles MyBase.BeforePrint
        Dim row As DevExpress.XtraReports.UI.XRTableRow = XTRow

        Dim total_sales_return_det_qty As Integer = 0
        Dim total_sales_return_det_amount As Integer = 0

        For i = 0 To dt.Rows.Count - 1
            total_sales_return_det_qty = total_sales_return_det_qty + dt.Rows(i)("sales_return_det_qty")
            total_sales_return_det_amount = total_sales_return_det_amount + dt.Rows(i)("sales_return_det_amount")

            row = XTable.InsertRowBelow(row)

            row.HeightF = 17

            'no
            Dim no As DevExpress.XtraReports.UI.XRTableCell = row.Cells.Item(0)
            no.Text = (i + 1).ToString
            no.BorderWidth = 0
            no.Font = New Font(no.Font.FontFamily, no.Font.Size, FontStyle.Regular)

            'code
            Dim code As DevExpress.XtraReports.UI.XRTableCell = row.Cells.Item(1)
            code.Text = dt.Rows(i)("code").ToString
            code.BorderWidth = 0
            code.Font = New Font(code.Font.FontFamily, code.Font.Size, FontStyle.Regular)

            'name
            Dim name As DevExpress.XtraReports.UI.XRTableCell = row.Cells.Item(2)
            name.Text = dt.Rows(i)("name").ToString
            name.BorderWidth = 0
            name.Font = New Font(name.Font.FontFamily, name.Font.Size, FontStyle.Regular)

            'size
            Dim size As DevExpress.XtraReports.UI.XRTableCell = row.Cells.Item(3)
            size.Text = dt.Rows(i)("size").ToString
            size.BorderWidth = 0
            size.Font = New Font(size.Font.FontFamily, size.Font.Size, FontStyle.Regular)

            'sales_return_det_qty
            Dim sales_return_det_qty As DevExpress.XtraReports.UI.XRTableCell = row.Cells.Item(4)
            sales_return_det_qty.Text = Format(dt.Rows(i)("sales_return_det_qty"), "##")
            sales_return_det_qty.BorderWidth = 0
            sales_return_det_qty.Font = New Font(sales_return_det_qty.Font.FontFamily, sales_return_det_qty.Font.Size, FontStyle.Regular)

            'design_price_type
            Dim design_price_type As DevExpress.XtraReports.UI.XRTableCell = row.Cells.Item(5)
            design_price_type.Text = dt.Rows(i)("design_price_type").ToString
            design_price_type.BorderWidth = 0
            design_price_type.Font = New Font(design_price_type.Font.FontFamily, design_price_type.Font.Size, FontStyle.Regular)

            'design_price
            Dim design_price As DevExpress.XtraReports.UI.XRTableCell = row.Cells.Item(6)
            design_price.Text = Format(dt.Rows(i)("design_price"), "##,##0")
            design_price.BorderWidth = 0
            design_price.Font = New Font(design_price.Font.FontFamily, design_price.Font.Size, FontStyle.Regular)

            'sales_return_det_amount
            Dim sales_return_det_amount As DevExpress.XtraReports.UI.XRTableCell = row.Cells.Item(7)
            sales_return_det_amount.Text = Format(dt.Rows(i)("sales_return_det_amount"), "##,##0")
            sales_return_det_amount.BorderWidth = 0
            sales_return_det_amount.Font = New Font(sales_return_det_amount.Font.FontFamily, sales_return_det_amount.Font.Size, FontStyle.Regular)

            'sales_return_det_amount
            Dim sales_return_det_note As DevExpress.XtraReports.UI.XRTableCell = row.Cells.Item(8)
            sales_return_det_note.Text = dt.Rows(i)("sales_return_det_note").ToString
            sales_return_det_note.BorderWidth = 0
            sales_return_det_note.Font = New Font(sales_return_det_note.Font.FontFamily, sales_return_det_note.Font.Size, FontStyle.Regular)
        Next

        XrRowTotal.HeightF = 25

        XCReturnQty.Text = total_sales_return_det_qty
        XCReturnAmount.Text = Format(total_sales_return_det_amount, "##,##0")

        If id_pre = "-1" Then
            load_mark_horz(report_mark_type, id_sales_return, "2", "1", XrTable1)
        Else
            pre_load_mark_horz(report_mark_type, id_sales_return, "2", "2", XrTable1)
        End If

        XRCompany.Text = execute_query("SELECT comp_name FROM tb_m_comp WHERE id_comp = (SELECT id_own_company FROM tb_opt LIMIT 1)", 0, True, "", "", "", "")
        Dim qp As String = "
            SELECT e.employee_nick_name AS `printed_by`, DATE_FORMAT(NOW(),'%d-%m-%Y %H:%i') AS `printed_date`
            FROM tb_m_user u
            INNER JOIN tb_m_employee e ON e.id_employee = u.id_employee
            WHERE u.id_user=" + id_user + " 
        "
        Dim dp As DataTable = execute_query(qp, -1, True, "", "", "", "")
        LabelPrintedDate.Text = dp.Rows(0)("printed_date").ToString
        LabelPrintedBy.Text = dp.Rows(0)("printed_by").ToString
    End Sub

    Private Sub GridView1_CustomColumnDisplayText(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs)
        'If e.Column.FieldName = "no" Then
        '    e.DisplayText = (e.ListSourceRowIndex + 1).ToString()
        'End If
    End Sub
End Class