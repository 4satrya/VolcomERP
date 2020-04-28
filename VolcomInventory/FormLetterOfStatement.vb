﻿Public Class FormLetterOfStatement
    Private Sub FormLetterOfStatement_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        form_load()
    End Sub

    Private Sub FormLetterOfStatement_Activated(sender As Object, e As EventArgs) Handles MyBase.Activated
        FormMain.show_rb(Name)
        checkFormAccess(Name)
        button_main("1", "0", "0")
    End Sub

    Private Sub FormLetterOfStatement_Deactivate(sender As Object, e As EventArgs) Handles MyBase.Deactivate
        FormMain.hide_rb()
    End Sub

    Private Sub FormLetterOfStatement_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Sub form_load()
        Dim query As String = "
            SELECT p.popup, e.employee_name, s.number, s.date, s.id_letter_of_statement
            FROM tb_letter_of_statement AS s
            LEFT JOIN tb_letter_of_statement_popup AS p ON s.id_popup = p.id_letter_of_statement_popup
            LEFT JOIN tb_m_employee AS e ON s.id_employee = e.id_employee
        "

        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")

        GCLetterOfStatement.DataSource = data

        GVLetterOfStatement.BestFitColumns()
    End Sub

    Sub form_print(ByVal id_letter_of_statement As String)
        Dim query As String = "
            SELECT s.id_letter_of_statement, s.id_popup, p.popup, s.number, s.date, s.id_employee, e.employee_name, e.employee_code, e.address_primary, e.employee_pob, e.employee_dob, e.employee_position, d.departement, s.created_date, e.employee_actual_join_date, e.employee_last_date
            FROM tb_letter_of_statement AS s
            LEFT JOIN tb_letter_of_statement_popup AS p ON s.id_popup = p.id_letter_of_statement_popup
            LEFT JOIN tb_m_employee AS e ON s.id_employee = e.id_employee
            LEFT JOIN tb_m_departement AS d ON e.id_departement = d.id_departement
            WHERE s.id_letter_of_statement = " + id_letter_of_statement + "
        "

        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")

        If data.Rows(0)("id_popup").ToString = "1" Then
            Dim Report As New ReportMasterEmployeeSuratKeteranganPenangguhanBank()

            Report.XLNumber.Text = Report.XLNumber.Text.Replace("[number]", data.Rows(0)("number").ToString)

            If data.Rows(0)("id_employee").ToString = "132" Then
                Report.L_hrd_employee_name1.Text = "Marissa Bridgitt Kasih"
                Report.L_hrd_employee_position1.Text = "Director"

                Report.L_hrd_employee_name2.Text = "Marissa Bridgitt Kasih"
                Report.L_hrd_employee_position2.Text = "Director"
            Else
                Report.L_hrd_employee_name1.Text = "Johannes Paulus Lazarus Handoko"
                Report.L_hrd_employee_position1.Text = "HR & Compliance Manager"

                Report.L_hrd_employee_name2.Text = "Johannes Paulus Lazarus Handoko"
                Report.L_hrd_employee_position2.Text = "HR & Compliance Manager"
            End If
            Report.L_employee_name.Text = data.Rows(0)("employee_name").ToString
            Report.L_employee_code.Text = data.Rows(0)("employee_code").ToString
            Report.L_address_primary.Text = data.Rows(0)("address_primary").ToString
            Report.L_date.Text = "Kuta, " + Date.Parse(data.Rows(0)("created_date").ToString).ToString("dd MMMM yyyy")

            Dim Tool As DevExpress.XtraReports.UI.ReportPrintTool = New DevExpress.XtraReports.UI.ReportPrintTool(Report)
            Tool.ShowPreviewDialog()
        ElseIf data.Rows(0)("id_popup").ToString = "2" Then
            Dim depthead As String = execute_query("
                SELECT e_dh.employee_name
                FROM tb_m_employee AS e
                LEFT JOIN tb_m_departement AS d ON e.id_departement = d.id_departement
                LEFT JOIN tb_m_user AS u_dh ON d.id_user_head = u_dh.id_user
                LEFT JOIN tb_m_employee AS e_dh ON u_dh.id_employee = e_dh.id_employee
                WHERE e.id_employee = " + data.Rows(0)("id_employee").ToString + "
            ", 0, True, "", "", "", "")

            Dim Report As New ReportMasterEmployeeSuratKeputusanDirumahkan()

            Report.XLNumber.Text = Report.XLNumber.Text.Replace("[number]", data.Rows(0)("number").ToString)

            Report.L_employee_name.Text = data.Rows(0)("employee_name").ToString
            Report.L_employee_code.Text = data.Rows(0)("employee_code").ToString
            Report.L_address_primary.Text = data.Rows(0)("address_primary").ToString
            Report.L_employee_pob_dob.Text = data.Rows(0)("employee_pob").ToString + ", " + Date.Parse(data.Rows(0)("employee_dob").ToString).ToString("dd MMMM yyyy")
            Report.L_date.Text = "Kuta, " + Date.Parse(data.Rows(0)("created_date").ToString).ToString("dd MMMM yyyy")
            Report.L_text.Text = Report.L_text.Text.Replace("[date]", Date.Parse(data.Rows(0)("date").ToString).ToString("dd MMMM yyyy"))
            Report.L_depthead.Text = depthead

            Dim Tool As DevExpress.XtraReports.UI.ReportPrintTool = New DevExpress.XtraReports.UI.ReportPrintTool(Report)
            Tool.ShowPreviewDialog()
        ElseIf data.Rows(0)("id_popup").ToString = "3" Then
            Dim Report As New ReportMasterEmployeeSuratTugas()

            Report.XLNumber.Text = Report.XLNumber.Text.Replace("[number]", data.Rows(0)("number").ToString)

            If FormMasterEmployee.GVEmployee.GetFocusedRowCellValue("id_employee").ToString = "132" Then
                Report.L_hrd_employee_name2.Text = "Marissa Bridgitt Kasih"
                Report.L_hrd_employee_position2.Text = "Director"
            Else
                Report.L_hrd_employee_name2.Text = "Johannes Paulus Lazarus Handoko"
                Report.L_hrd_employee_position2.Text = "HR & Compliance Manager"
            End If
            Report.L_employee_name.Text = data.Rows(0)("employee_name").ToString
            Report.L_employee_code.Text = data.Rows(0)("employee_code").ToString
            Report.L_employee_position.Text = data.Rows(0)("employee_position").ToString
            Report.L_departement.Text = data.Rows(0)("departement").ToString
            Report.L_date.Text = "Kuta, " + Date.Parse(data.Rows(0)("created_date").ToString).ToString("dd MMMM yyyy")

            Dim depthead As String = execute_query("
                SELECT e_dh.id_employee
                FROM tb_m_employee AS e
                LEFT JOIN tb_m_departement AS d ON e.id_departement = d.id_departement
                LEFT JOIN tb_m_user AS u_dh ON d.id_user_head = u_dh.id_user
                LEFT JOIN tb_m_employee AS e_dh ON u_dh.id_employee = e_dh.id_employee
                WHERE e.id_employee = " + data.Rows(0)("id_employee").ToString + "
            ", 0, True, "", "", "", "")

            If depthead = data.Rows(0)("id_employee").ToString Then
                Report.L_cc.Text = "
cc.
- Direktur
- HRD 
                "
            Else
                Report.L_cc.Text = "
cc.
- Direktur
- Departemen Head terkait
- HRD 
                "
            End If

            Dim Tool As DevExpress.XtraReports.UI.ReportPrintTool = New DevExpress.XtraReports.UI.ReportPrintTool(Report)
            Tool.ShowPreviewDialog()
        ElseIf data.Rows(0)("id_popup").ToString = "4" Then
            Dim Report As New ReportMasterEmployeeSuratKeteranganBansos()

            Report.XLNumber.Text = Report.XLNumber.Text.Replace("[number]", data.Rows(0)("number").ToString)

            Report.L_employee_name.Text = data.Rows(0)("employee_name").ToString
            Report.L_employee_code.Text = data.Rows(0)("employee_code").ToString
            Report.L_address_primary.Text = data.Rows(0)("address_primary").ToString
            Report.L_employee_pob_dob.Text = data.Rows(0)("employee_pob").ToString + ", " + Date.Parse(data.Rows(0)("employee_dob").ToString).ToString("dd MMMM yyyy")
            Report.L_date.Text = "Kuta, " + Date.Parse(data.Rows(0)("created_date").ToString).ToString("dd MMMM yyyy")
            Report.L_text.Text = Report.L_text.Text.Replace("[date]", Date.Parse(data.Rows(0)("date").ToString).ToString("dd MMMM yyyy"))

            Dim Tool As DevExpress.XtraReports.UI.ReportPrintTool = New DevExpress.XtraReports.UI.ReportPrintTool(Report)
            Tool.ShowPreviewDialog()
        ElseIf data.Rows(0)("id_popup").ToString = "5" Then
            Dim Report As New ReportMasterEmployeeSuratReferensi()

            Report.XLNumber.Text = Report.XLNumber.Text.Replace("[number]", data.Rows(0)("number").ToString)

            Report.L_employee_name.Text = data.Rows(0)("employee_name").ToString
            Report.L_address_primary.Text = data.Rows(0)("address_primary").ToString
            Report.L_date.Text = Date.Parse(data.Rows(0)("created_date").ToString).ToString("MMMM d, yyyy")
            Report.L_text.Text = Report.L_text.Text.Replace("[employee_actual_join_date]", Date.Parse(data.Rows(0)("employee_actual_join_date").ToString).ToString("MMMM d, yyyy"))
            Report.L_text.Text = Report.L_text.Text.Replace("[employee_last_date]", Date.Parse(data.Rows(0)("employee_last_date").ToString).ToString("MMMM d, yyyy"))
            Report.L_text.Text = Report.L_text.Text.Replace("[employee_position]", data.Rows(0)("employee_position").ToString)

            Dim Tool As DevExpress.XtraReports.UI.ReportPrintTool = New DevExpress.XtraReports.UI.ReportPrintTool(Report)
            Tool.ShowPreviewDialog()
        End If
    End Sub

    Private Sub PrintToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PrintToolStripMenuItem.Click
        form_print(GVLetterOfStatement.GetFocusedRowCellValue("id_letter_of_statement").ToString)
    End Sub
End Class