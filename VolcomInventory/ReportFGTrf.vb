Public Class ReportFGTrf
    Public Shared id_pre As String = "-1"
    Public Shared id_fg_trf As String = "-1"
    Public Shared id_type As String = "-1"
    Public Shared dt As DataTable

 

    Private Sub ReportFGTrf_BeforePrint(ByVal sender As System.Object, ByVal e As System.Drawing.Printing.PrintEventArgs) Handles MyBase.BeforePrint
        GCItemList.DataSource = dt

        Dim report_mark As String = ""

        If id_type = "-1" Then
            'Mark
            report_mark = "57"
        ElseIf id_type = "1" Then
            'Mark
            report_mark = "58"
        End If

        Dim is_transfer_data As String = execute_query("SELECT s.is_transfer_data FROM tb_fg_trf AS f LEFT JOIN tb_sales_order AS s ON f.id_sales_order = s.id_sales_order WHERE f.id_fg_trf = " + id_fg_trf, 0, True, "", "", "", "")

        If is_transfer_data = "2" Then
            'custom mark
            Dim query As String = "
            SELECT report_status_display, employee_name, `role`, date_time
            FROM (
                (SELECT IF(b.id_report_status = 1, 1, 4) AS `order`, b.report_status_display, d.employee_name, d.employee_position AS `role`, DATE_FORMAT(a.report_mark_datetime, '%d-%m-%Y %H:%i') AS date_time
                FROM tb_report_mark a
                INNER JOIN tb_lookup_report_status b ON a.id_report_status = b.id_report_status
                LEFT JOIN tb_m_employee d ON d.id_employee = a.id_employee
                WHERE a.report_mark_type='" + report_mark + "' AND a.id_report='" + id_fg_trf + "' " + If(id_pre = "-1", "AND a.is_use = 1 AND a.id_mark = 2", "AND (a.level IS NULL OR a.level = 1)") + " AND a.id_report_status = 1
                ORDER BY a.id_report_status, a.id_mark_asg)
                UNION
                (SELECT 4 AS `order`, 'Approved By,' AS report_status_display, '' AS employee_name, 'WH Team Leader' AS role, '' AS date_time)
                UNION
                (SELECT 5 AS `order`, 'Completed By,' AS report_status_display, '' AS employee_name, 'Dept. Head' AS role, '' AS date_time)
                UNION 
                (SELECT 3 AS `order`, 'Checked By,' AS report_status_display, '' AS employee_name, 'Security' AS role, '' AS date_time)
            ) AS tb
            ORDER BY `order`
        "

            Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")

            'head
            Dim row_head As New DevExpress.XtraReports.UI.XRTableRow()

            row_head.HeightF = 25.0F

            For j As Integer = 0 To data.Rows.Count - 1
                Dim cell As New DevExpress.XtraReports.UI.XRTableCell()

                cell.Font = New Font(XrTable1.Font.FontFamily, XrTable1.Font.Size + 1, FontStyle.Bold)
                cell.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter

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

            XrTable1.Rows.Add(row_head)

            'blank
            For i As Integer = 0 To 1
                Dim row_blank As New DevExpress.XtraReports.UI.XRTableRow()

                row_blank.HeightF = 10.0F

                For j As Integer = 0 To data.Rows.Count - 1
                    Dim cell_blank As New DevExpress.XtraReports.UI.XRTableCell()

                    cell_blank.Text = " "

                    row_blank.Cells.Add(cell_blank)
                Next j

                XrTable1.Rows.Add(row_blank)
            Next

            'name
            Dim row_name As New DevExpress.XtraReports.UI.XRTableRow()

            row_name.HeightF = 25.0F

            For j As Integer = 0 To data.Rows.Count - 1
                Dim cell As New DevExpress.XtraReports.UI.XRTableCell()

                cell.Font = New Font(XrTable1.Font.FontFamily, XrTable1.Font.Size, FontStyle.Bold)
                cell.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
                cell.Text = data.Rows(j)("employee_name").ToString

                row_name.Cells.Add(cell)
            Next j

            XrTable1.Rows.Add(row_name)

            'role
            Dim row_role As New DevExpress.XtraReports.UI.XRTableRow()

            row_role.HeightF = 25.0F

            For j As Integer = 0 To data.Rows.Count - 1
                Dim cell As New DevExpress.XtraReports.UI.XRTableCell()

                cell.Font = New Font(XrTable1.Font.FontFamily, XrTable1.Font.Size, FontStyle.Bold)
                cell.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
                cell.Text = data.Rows(j)("role").ToString

                row_role.Cells.Add(cell)
            Next j

            XrTable1.Rows.Add(row_role)

            If id_pre = "-1" Then 'time included
                Dim row_time As New DevExpress.XtraReports.UI.XRTableRow()

                row_time.HeightF = 25.0F

                For j As Integer = 0 To data.Rows.Count - 1
                    Dim cell As New DevExpress.XtraReports.UI.XRTableCell()

                    cell.Font = New Font(XrTable1.Font.FontFamily, XrTable1.Font.Size - 1, FontStyle.Italic)
                    cell.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
                    cell.Text = data.Rows(j)("date_time").ToString

                    row_time.Cells.Add(cell)
                Next j

                XrTable1.Rows.Add(row_time)
            End If
        End If
    End Sub

    Private Sub GVItemList_CustomColumnDisplayText(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs) Handles GVItemList.CustomColumnDisplayText
        If e.Column.FieldName = "no" Then
            e.DisplayText = (e.ListSourceRowIndex + 1).ToString()
        End If
    End Sub
End Class