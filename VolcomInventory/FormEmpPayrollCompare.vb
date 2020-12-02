Public Class FormEmpPayrollCompare
    Public id_payroll As String = ""
    Public id_payroll_before As String = ""

    Private data_payroll As DataTable = New DataTable

    Private Sub FormEmpPayrollCompare_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If id_payroll = "" Then
            id_payroll = FormEmpPayroll.GVPayrollPeriode.GetFocusedRowCellValue("id_payroll").ToString
        End If

        If id_payroll_before = "" Then
            id_payroll_before = execute_query("SELECT id_payroll FROM tb_emp_payroll WHERE MONTH(periode_end) = (SELECT MONTH(periode_end - INTERVAL 1 MONTH) FROM tb_emp_payroll WHERE id_payroll = '" & id_payroll & "') AND YEAR(periode_end) = (SELECT YEAR(periode_end - INTERVAL 1 MONTH) FROM tb_emp_payroll WHERE id_payroll = '" & id_payroll & "') AND id_payroll_type = (SELECT id_payroll_type FROM tb_emp_payroll WHERE id_payroll = '" & id_payroll & "')", 0, True, "", "", "", "")
        End If

        data_payroll = execute_query("
            SELECT 'no' AS is_check, pr.*,emp.`employee_name`,type.payroll_type as payroll_type_name,DATE_FORMAT(pr.periode_end,'%M %Y') AS payroll_name, IFNULL((SELECT report_status FROM tb_lookup_report_status WHERE id_report_status = pr.id_report_status), 'Not Submitted') AS report_status, type.is_thr, type.is_dw FROM tb_emp_payroll pr
            INNER JOIn tb_emp_payroll_type type ON type.id_payroll_type=pr.id_payroll_type
            INNER JOIN tb_m_user usr ON usr.id_user=pr.id_user_upd
            INNER JOIN tb_m_employee emp ON emp.`id_employee`=usr.id_employee
            WHERE pr.id_payroll = '" + id_payroll + "'
        ", -1, True, "", "", "", "")

        Dim data As DataTable = execute_query("CALL view_payroll(" + id_payroll + ")", -1, True, "", "", "", "")
        Dim data_before As DataTable = execute_query("CALL view_payroll(" + id_payroll_before + ")", -1, True, "", "", "", "")

        'combine
        For i = 0 To data.Rows.Count - 1
            For j = 0 To data_before.Rows.Count - 1
                If data.Rows(i)("id_employee").ToString = data_before.Rows(j)("id_employee").ToString Then
                    data.Rows(i)("grand_total_before") = data_before.Rows(j)("grand_total")

                    Exit For
                End If
            Next
        Next

        'not in data
        For i = 0 To data_before.Rows.Count - 1
            Dim already As Boolean = False

            For j = 0 To data.Rows.Count - 1
                If data_before.Rows(i)("id_employee").ToString = data.Rows(j)("id_employee").ToString Then
                    already = True

                    Exit For
                End If
            Next

            If Not already Then
                Dim row As DataRow = data_before.Rows(i)

                data.ImportRow(row)

                data.Rows(data.Rows.Count - 1)("grand_total_before") = data.Rows(data.Rows.Count - 1)("grand_total")
                data.Rows(data.Rows.Count - 1)("grand_total") = 0
            End If
        Next

        GCPayroll.DataSource = data

        'number
        Dim num As Integer = 0

        For i = 0 To GVPayroll.RowCount - 1
            If GVPayroll.IsValidRowHandle(i) Then
                num = num + 1

                GVPayroll.SetRowCellValue(i, "no", num)
            End If
        Next

        GVPayroll.BestFitColumns()

        'controls
        Dim id_report_status As String = execute_query("SELECT id_report_status FROM tb_emp_payroll WHERE id_payroll = '" + id_payroll + "'", 0, True, "", "", "", "")

        If id_report_status = "0" Then
            SBPrint.Enabled = False
        Else
            SBPrint.Enabled = True
        End If
    End Sub

    Private Sub FormEmpPayrollCompare_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub SBPrint_Click(sender As Object, e As EventArgs) Handles SBPrint.Click
        Dim data As DataTable = GCPayroll.DataSource

        'alphabeth
        Dim alphabet As String() = {"A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z"}

        data.DefaultView.Sort = "departement ASC, departement_sub ASC"
        data = data.DefaultView.ToTable

        Dim iAlphabet As Integer = 0
        Dim iInterger As Integer = 1

        Dim last_departement As String = ""
        Dim last_departement_sub As String = ""

        For i = 0 To data.Rows.Count - 1
            Dim curr_departement As String = System.Text.RegularExpressions.Regex.Replace(data.Rows(i)("departement").ToString, "\(([A-Z])\)", "").ToString()
            Dim curr_departement_sub As String = System.Text.RegularExpressions.Regex.Replace(data.Rows(i)("departement_sub").ToString, "\(([A-Z])\)", "").ToString()

            If i = 0 Then
                last_departement = curr_departement
                last_departement_sub = curr_departement_sub
            End If

            If Not last_departement = curr_departement Then
                iAlphabet += 1
                iInterger = 0
            End If

            If Not last_departement_sub = curr_departement_sub Then
                iInterger += 1
            End If

            data.Rows(i)("departement") = curr_departement + " (" + alphabet(iAlphabet) + ")"
            data.Rows(i)("departement_sub") = curr_departement_sub + " (" + alphabet(iAlphabet) + iInterger.ToString + ")"

            last_departement = curr_departement
            last_departement_sub = curr_departement_sub
        Next

        'report
        Dim id_report_status As String = execute_query("SELECT id_report_status FROM tb_emp_payroll WHERE id_payroll = " + id_payroll, 0, True, "", "", "", "")

        Dim already_office As Boolean = False
        Dim already_store As Boolean = False

        For j = 0 To data.Rows.Count - 1
            If data.Rows(j)("is_office_payroll").ToString = "1" Then
                already_office = True
            ElseIf data.Rows(j)("is_office_payroll").ToString = "2"
                already_store = True
            End If
        Next

        'office
        Dim data_payroll_office As DataTable = data.Clone

        For j = 0 To data.Rows.Count - 1
            If data.Rows(j)("is_office_payroll").ToString = "1" Then
                data_payroll_office.ImportRow(data.Rows(j))
            End If
        Next

        'store
        Dim data_payroll_store As DataTable = data.Clone

        For j = 0 To data.Rows.Count - 1
            If data.Rows(j)("is_office_payroll").ToString = "2" Then
                data_payroll_store.ImportRow(data.Rows(j))
            End If
        Next

        Dim report As ReportPayrollAllCompare = New ReportPayrollAllCompare

        report.id_payroll = id_payroll
        report.id_pre = If(id_report_status = "6", "-1", "1")
        report.type = data_payroll.Rows(0)("id_payroll_type").ToString
        report.dt_office = data_payroll_office
        report.dt_store = data_payroll_store

        report.XLPeriod.Text = Date.Parse(data_payroll.Rows(0)("periode_end").ToString).ToString("MMMM yyyy")
        report.XLType.Text = data_payroll.Rows(0)("payroll_type_name").ToString

        If Not already_office Then
            report.DetailReportOffice.Visible = False

            report.DetailReportStore.Level = 0
            report.DetailReportStore.PageBreak = DevExpress.XtraReports.UI.PageBreak.None
        End If

        If Not already_store Then
            report.DetailReportStore.Visible = False

            report.DetailReportOffice.Level = 0
            report.DetailReportOffice.PageBreak = DevExpress.XtraReports.UI.PageBreak.None
        End If

        Dim tool As DevExpress.XtraReports.UI.ReportPrintTool = New DevExpress.XtraReports.UI.ReportPrintTool(report)

        tool.ShowPreview()
    End Sub

    Private Sub GVPayroll_CustomDrawGroupRow(sender As Object, e As DevExpress.XtraGrid.Views.Base.RowObjectCustomDrawEventArgs) Handles GVPayroll.CustomDrawGroupRow
        Dim info As DevExpress.XtraGrid.Views.Grid.ViewInfo.GridGroupRowInfo = TryCast(e.Info, DevExpress.XtraGrid.Views.Grid.ViewInfo.GridGroupRowInfo)

        If info.Column.Caption = "Sub Departement" And Not info.EditValue.ToString.Contains("SOGO") Then
            info.GroupText = " "
        End If
    End Sub

    Private Sub GVPayroll_CustomDrawRowFooter(sender As Object, e As DevExpress.XtraGrid.Views.Base.RowObjectCustomDrawEventArgs) Handles GVPayroll.CustomDrawRowFooter
        e.Graphics.FillRectangle(New SolidBrush(Color.White), e.Bounds)

        Dim format As StringFormat = e.Appearance.GetStringFormat.Clone

        format.Alignment = StringAlignment.Near

        If GVPayroll.GetGroupRowDisplayText(e.RowHandle).Contains("Group") Then
            e.Graphics.DrawString("Grand Total: " + GVPayroll.GetGroupRowValue(e.RowHandle), e.Appearance.GetFont, e.Appearance.GetForeBrush(e.Cache), e.Bounds, format)
        Else
            If GVPayroll.GetGroupRowDisplayText(e.RowHandle).Contains("SOGO") Then
                e.Graphics.DrawString("Total " + GVPayroll.GetGroupRowDisplayText(e.RowHandle), e.Appearance.GetFont, e.Appearance.GetForeBrush(e.Cache), e.Bounds, format)
            Else
                If Not GVPayroll.GetGroupRowDisplayText(e.RowHandle).Contains("Sub") Then
                    e.Graphics.DrawString("Total " + GVPayroll.GetGroupRowDisplayText(e.RowHandle), e.Appearance.GetFont, e.Appearance.GetForeBrush(e.Cache), e.Bounds, format)
                End If
            End If
        End If

        e.Handled = True
    End Sub

    Private Sub GVPayroll_CustomDrawRowFooterCell(sender As Object, e As DevExpress.XtraGrid.Views.Grid.FooterCellCustomDrawEventArgs) Handles GVPayroll.CustomDrawRowFooterCell
        Dim view As DevExpress.XtraGrid.Views.Grid.GridView = sender

        If view.GetGroupRowDisplayText(e.RowHandle).Contains("Sub Departement") And Not view.GetGroupRowValue(e.RowHandle).ToString.Contains("SOGO") Then
            e.Appearance.ForeColor = Color.White
            e.Handled = True
        End If
    End Sub
End Class