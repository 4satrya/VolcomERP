Public Class ReportCashAdvanceSummary
    Private Sub ReportCashAdvanceSummary_BeforePrint(sender As Object, e As Printing.PrintEventArgs) Handles MyBase.BeforePrint
        Dim query As String = "
            SELECT r.report_status_display, e.employee_name, e.employee_position AS role
            FROM tb_opt_accounting AS opt
            LEFT JOIN tb_lookup_report_status AS r ON r.id_report_status = 1
            LEFT JOIN tb_m_employee AS e ON e.id_employee = " + id_employee_user + "
            UNION ALL
            SELECT r.report_status_display, e.employee_name, e.employee_position AS role
            FROM tb_opt_accounting AS opt
            LEFT JOIN tb_lookup_report_status AS r ON r.id_report_status = 3
            LEFT JOIN tb_m_employee AS e ON opt.cash_advance_report_approve1 = e.id_employee
            UNION ALL
            SELECT r.report_status_display, e.employee_name, e.employee_position AS role
            FROM tb_opt_accounting AS opt
            LEFT JOIN tb_lookup_report_status AS r ON r.id_report_status = 3
            LEFT JOIN tb_m_employee AS e ON opt.cash_advance_report_approve2 = e.id_employee
        "

        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")

        Dim cellsInRow As Integer = data.Rows.Count
        Dim rowHeight As Single = 25.0F

        'header
        Dim row_head As DevExpress.XtraReports.UI.XRTableRow = New DevExpress.XtraReports.UI.XRTableRow

        row_head.HeightF = rowHeight

        For j As Integer = 0 To cellsInRow - 1
            Dim cell As DevExpress.XtraReports.UI.XRTableCell = New DevExpress.XtraReports.UI.XRTableCell

            cell.Font = New Font(XrTable.Font.FontFamily, XrTable.Font.Size, FontStyle.Bold)
            cell.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft

            'merge or not
            If j > 0 Then
                If data.Rows(j)("report_status_display").ToString = data.Rows(j - 1)("report_status_display").ToString Then
                    cell.Text = ""
                Else
                    cell.Text = data.Rows(j)("report_status_display").ToString
                End If
            Else
                cell.Text = data.Rows(j)("report_status_display").ToString
            End If

            row_head.Cells.Add(cell)
        Next j

        XrTable.Rows.Add(row_head)

        'insert row blank 3 times
        For i As Integer = 0 To 1
            Dim row_blank As DevExpress.XtraReports.UI.XRTableRow = New DevExpress.XtraReports.UI.XRTableRow

            row_blank.HeightF = 15.0F

            For j As Integer = 0 To cellsInRow - 1
                Dim cell_blank As DevExpress.XtraReports.UI.XRTableCell = New DevExpress.XtraReports.UI.XRTableCell

                cell_blank.Text = " "

                row_blank.Cells.Add(cell_blank)
            Next j

            XrTable.Rows.Add(row_blank)
        Next

        'who name
        Dim row_name As DevExpress.XtraReports.UI.XRTableRow = New DevExpress.XtraReports.UI.XRTableRow

        row_name.HeightF = rowHeight

        For j As Integer = 0 To cellsInRow - 1
            Dim cell As DevExpress.XtraReports.UI.XRTableCell = New DevExpress.XtraReports.UI.XRTableCell

            cell.Font = New Font(XrTable.Font.FontFamily, XrTable.Font.Size, FontStyle.Bold)
            cell.Text = data.Rows(j)("employee_name").ToString

            row_name.Cells.Add(cell)
        Next j

        XrTable.Rows.Add(row_name)

        'role
        Dim row_role As DevExpress.XtraReports.UI.XRTableRow = New DevExpress.XtraReports.UI.XRTableRow

        row_role.HeightF = rowHeight

        For j As Integer = 0 To cellsInRow - 1
            Dim cell As DevExpress.XtraReports.UI.XRTableCell = New DevExpress.XtraReports.UI.XRTableCell()

            cell.Font = New Font(XrTable.Font.FontFamily, XrTable.Font.Size, FontStyle.Bold)
            cell.Text = data.Rows(j)("role").ToString

            row_role.Cells.Add(cell)
        Next j

        XrTable.Rows.Add(row_role)
    End Sub
End Class