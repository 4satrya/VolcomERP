Public Class ReportSalesDelOrderOwnStore2
    Public Shared id As String
    Public Shared id_pre As String = "-1"
    Public Shared dt As DataTable
    Public Shared rmt As String = "43"
    Public Shared is_combine = "2"
    Public Shared id_report_status As String = "-1"
    Public Shared id_store As String = "-1"
    Public Shared is_use_unique_code As String = "-1"
    Public Shared is_no_print As String = "-1"

    Private Sub ReportSalesDelOrderOwnStore2_BeforePrint(sender As Object, e As Printing.PrintEventArgs) Handles MyBase.BeforePrint
        'custom mark
        Dim query As String = "
            SELECT report_status_display, employee_name, `role`, date_time
            FROM (
                (SELECT IF(b.id_report_status = 1, 1, 4) AS `order`, b.report_status_display, d.employee_name, d.employee_position AS `role`, DATE_FORMAT(a.report_mark_datetime, '%d-%m-%Y %H:%i') AS date_time
                FROM tb_report_mark a
                INNER JOIN tb_lookup_report_status b ON a.id_report_status = b.id_report_status
                LEFT JOIN tb_m_employee d ON d.id_employee = a.id_employee
                WHERE a.report_mark_type='" & rmt & "' AND a.id_report='" & id & "' " + If(id_pre = "-1", "AND a.is_use = 1 AND a.id_mark = 2", "AND (a.level IS NULL OR a.level = 1)") + "
                ORDER BY a.id_report_status, a.id_mark_asg)
                UNION
                (SELECT 5 AS `order`, 'Completed By,' AS report_status_display, employee_name, employee_position AS role, (SELECT DATE_FORMAT(final_comment_date, '%d-%m-%Y %H:%i') FROM tb_report_mark_final_comment WHERE report_mark_type = " & rmt & " AND id_report = " + id + " LIMIT 1) AS date_time
                FROM tb_m_employee
                WHERE id_employee = (SELECT id_emp_wh_manager FROM tb_opt LIMIT 1))
                UNION 
                (SELECT 3 AS `order`, 'Checked By,' AS report_status_display, '' AS employee_name, 'Security' AS role, '' AS date_time)
                UNION
                (SELECT 2 AS `order`, 'Dispatched By,' AS report_status_display, '' AS employee_name, 'Outbound Staff' AS role, '' AS date_time)
                UNION
                (SELECT 6 AS `order`, 'Received By,' AS report_status_display, '' AS employee_name, '' AS role, '' AS date_time)
            ) AS tb
            ORDER BY `order`
        "

        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")

        'head
        Dim row_head As New DevExpress.XtraReports.UI.XRTableRow()

        row_head.HeightF = 25.0F

        For j As Integer = 0 To data.Rows.Count - 1
            Dim cell As New DevExpress.XtraReports.UI.XRTableCell()

            cell.Font = New Font(XrTable.Font.FontFamily, XrTable.Font.Size + 1, FontStyle.Bold)
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

        XrTable.Rows.Add(row_head)

        'blank
        For i As Integer = 0 To 1
            Dim row_blank As New DevExpress.XtraReports.UI.XRTableRow()

            row_blank.HeightF = 10.0F

            For j As Integer = 0 To data.Rows.Count - 1
                Dim cell_blank As New DevExpress.XtraReports.UI.XRTableCell()

                cell_blank.Text = " "

                row_blank.Cells.Add(cell_blank)
            Next j

            XrTable.Rows.Add(row_blank)
        Next

        'name
        Dim row_name As New DevExpress.XtraReports.UI.XRTableRow()

        row_name.HeightF = 25.0F

        For j As Integer = 0 To data.Rows.Count - 1
            Dim cell As New DevExpress.XtraReports.UI.XRTableCell()

            cell.Font = New Font(XrTable.Font.FontFamily, XrTable.Font.Size, FontStyle.Bold)
            cell.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
            cell.Text = data.Rows(j)("employee_name").ToString

            row_name.Cells.Add(cell)
        Next j

        XrTable.Rows.Add(row_name)

        'role
        Dim row_role As New DevExpress.XtraReports.UI.XRTableRow()

        row_role.HeightF = 25.0F

        For j As Integer = 0 To data.Rows.Count - 1
            Dim cell As New DevExpress.XtraReports.UI.XRTableCell()

            cell.Font = New Font(XrTable.Font.FontFamily, XrTable.Font.Size, FontStyle.Bold)
            cell.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
            cell.Text = data.Rows(j)("role").ToString

            row_role.Cells.Add(cell)
        Next j

        XrTable.Rows.Add(row_role)

        If id_pre = "-1" Then 'time included
            Dim row_time As New DevExpress.XtraReports.UI.XRTableRow()

            row_time.HeightF = 25.0F

            For j As Integer = 0 To data.Rows.Count - 1
                Dim cell As New DevExpress.XtraReports.UI.XRTableCell()

                cell.Font = New Font(XrTable.Font.FontFamily, XrTable.Font.Size - 1, FontStyle.Italic)
                cell.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
                cell.Text = data.Rows(j)("date_time").ToString

                row_time.Cells.Add(cell)
            Next j

            XrTable.Rows.Add(row_time)
        End If

        'printed by & printed date
        If is_no_print = "-1" Then
            LabelPrintedDateTitle.Visible = True
            LabelPrintedDate.Visible = True
            LabelPrintedByTitle.Visible = True
            LabelPrintedBy.Visible = True

            Dim qp As String = "SELECT e.employee_nick_name AS `printed_by`, DATE_FORMAT(NOW(),'%d-%m-%Y %H:%i') AS `printed_date`
            FROM tb_m_user u
            INNER JOIN tb_m_employee e ON e.id_employee = u.id_employee
            WHERE u.id_user=" + id_user + " "
            Dim dp As DataTable = execute_query(qp, -1, True, "", "", "", "")
            LabelPrintedDate.Text = dp.Rows(0)("printed_date").ToString
            LabelPrintedBy.Text = dp.Rows(0)("printed_by").ToString
        Else
            LabelPrintedDateTitle.Visible = False
            LabelPrintedDate.Visible = False
            LabelPrintedByTitle.Visible = False
            LabelPrintedBy.Visible = False
        End If


        'detail
        viewDetail()

        'completed
        If id_report_status = "6" Then
            LabelCompleted.Visible = True
            Dim qcom As String = "SELECT e.employee_name AS `completed_by`, DATE_FORMAT(r.final_comment_date,'%d-%m-%Y %H:%i') AS `completed_date` 
            FROM tb_report_mark_final_comment r 
            INNER JOIN tb_m_user u ON u.id_user = r.id_user
            INNER JOIN tb_m_employee e ON e.id_employee = u.id_employee
            WHERE r.report_mark_type=" + rmt + " AND r.id_report=" + id + " "
            Dim dcom As DataTable = execute_query(qcom, -1, True, "", "", "", "")
            DataSource = dcom
        End If

        LRecNumber.Text = "NO. " + LRecNumber.Text
        LabelTo.Text = LabelTo.Text.ToUpper
        LabelAddress.Text = LabelAddress.Text.ToUpper
        LabelFrom.Text = LabelFrom.Text.ToUpper
        LRecDate.Text = LRecDate.Text.ToUpper
        LabelPrepare.Text = LabelPrepare.Text.ToUpper
        LabelCat.Text = LabelCat.Text.ToUpper
        LabelUni6.Text = LabelUni6.Text.ToUpper

        If Not id_report_status = "6" Or Not id_pre = "-1" Then
            LabelCompleted.Visible = False
        End If

        XRCompany.Text = execute_query("SELECT comp_name FROM tb_m_comp WHERE id_comp = (SELECT id_own_company FROM tb_opt LIMIT 1)", 0, True, "", "", "", "")
    End Sub

    Sub viewDetail()
        Dim del As New ClassSalesDelOrder()
        Dim cond As String = ""
        If is_combine = "2" Then
            cond = "AND dd.id_pl_sales_order_del=" + id + " "
        Else
            cond = "AND d.is_combine=1 AND d.id_combine=" + id + " "
        End If
        Dim query As String = ""
        'If is_use_unique_code = "1" Then
        'query = del.queryDelConceptStore(cond, id_store)
        'Else
        query = del.queryDelRegular(cond, id_store)
        'End If
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        'GCItemList.DataSource = data

        Dim row As DevExpress.XtraReports.UI.XRTableRow = XTRow

        Dim total_qty As Decimal = 0.00
        Dim total_amount As Decimal = 0.00

        For i = 0 To data.Rows.Count - 1
            row = XTable.InsertRowBelow(row)

            row.HeightF = 17

            'no
            Dim no As DevExpress.XtraReports.UI.XRTableCell = row.Cells.Item(0)
            no.Text = (i + 1).ToString
            no.BorderWidth = 0
            no.Font = New Font(no.Font.FontFamily, no.Font.Size, FontStyle.Regular)

            'barcode
            Dim barcode As DevExpress.XtraReports.UI.XRTableCell = row.Cells.Item(1)
            barcode.Text = data.Rows(i)("code").ToString
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

            'qty
            Dim qty As DevExpress.XtraReports.UI.XRTableCell = row.Cells.Item(4)
            qty.Text = Decimal.Round(data.Rows(i)("qty"))
            qty.BorderWidth = 0
            qty.Font = New Font(qty.Font.FontFamily, qty.Font.Size, FontStyle.Regular)

            'type
            Dim type As DevExpress.XtraReports.UI.XRTableCell = row.Cells.Item(5)
            type.Text = data.Rows(i)("design_price_type").ToString.Substring(0, 1)
            type.BorderWidth = 0
            type.Font = New Font(type.Font.FontFamily, type.Font.Size, FontStyle.Regular)

            'price
            Dim price As DevExpress.XtraReports.UI.XRTableCell = row.Cells.Item(6)
            price.Text = Format(data.Rows(i)("design_price"), "##,##0")
            price.BorderWidth = 0
            price.Font = New Font(price.Font.FontFamily, price.Font.Size, FontStyle.Regular)

            'ammount
            Dim ammount As DevExpress.XtraReports.UI.XRTableCell = row.Cells.Item(7)
            ammount.Text = Format(data.Rows(i)("qty") * data.Rows(i)("design_price"), "##,##0")
            ammount.BorderWidth = 0
            ammount.Font = New Font(price.Font.FontFamily, price.Font.Size, FontStyle.Regular)

            total_qty = total_qty + data.Rows(i)("qty")
            total_amount = total_amount + (data.Rows(i)("qty") * data.Rows(i)("design_price"))
        Next

        RowTotalQty.Text = Decimal.Round(total_qty, 0)
        RowTotalAmount.Text = Format(total_amount, "##,##0")
    End Sub

    Private Sub GVItemList_CustomColumnDisplayText(sender As Object, e As DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs)
        If e.Column.FieldName = "no" Then
            e.DisplayText = (e.ListSourceRowIndex + 1).ToString()
        End If
    End Sub
End Class