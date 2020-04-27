Public Class FormMasterEmployeeNomorSurat
    Public Shared id_popup As String = "0"

    Private Sub FormMasterEmployeeNomorSurat_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub BPrint_Click(sender As Object, e As EventArgs) Handles BPrint.Click
        Dim month As String = execute_query("SELECT `code` FROM `tb_ot_memo_number_mon` WHERE `month` = MONTH(NOW())", 0, True, "", "", "", "")

        If id_popup = "1" Then
            Dim Report As New ReportMasterEmployeeSuratKeteranganPenangguhanBank()

            Report.XLNumber.Text = Report.XLNumber.Text.Replace("[number]", TENumber.Text + "/EXT/HRD-SK/" + month + "/" + Date.Now.ToString("yy"))

            If FormMasterEmployee.GVEmployee.GetFocusedRowCellValue("id_employee").ToString = "132" Then
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
            Report.L_employee_name.Text = FormMasterEmployee.GVEmployee.GetFocusedRowCellDisplayText("employee_name")
            Report.L_employee_code.Text = FormMasterEmployee.GVEmployee.GetFocusedRowCellDisplayText("employee_code")
            Report.L_address_primary.Text = FormMasterEmployee.GVEmployee.GetFocusedRowCellDisplayText("address_primary")
            Report.L_date.Text = "Kuta, " + Date.Now.ToString("dd MMMM yyyy")

            Dim Tool As DevExpress.XtraReports.UI.ReportPrintTool = New DevExpress.XtraReports.UI.ReportPrintTool(Report)
            Tool.ShowPreviewDialog()
        ElseIf id_popup = "2" Then
            Dim depthead As String = execute_query("
                SELECT e_dh.employee_name
                FROM tb_m_employee AS e
                LEFT JOIN tb_m_departement AS d ON e.id_departement = d.id_departement
                LEFT JOIN tb_m_user AS u_dh ON d.id_user_head = u_dh.id_user
                LEFT JOIN tb_m_employee AS e_dh ON u_dh.id_employee = e_dh.id_employee
                WHERE e.id_employee = " + FormMasterEmployee.GVEmployee.GetFocusedRowCellValue("id_employee").ToString + "
            ", 0, True, "", "", "", "")

            Dim Report As New ReportMasterEmployeeSuratKeputusanDirumahkan()

            Report.XLNumber.Text = Report.XLNumber.Text.Replace("[number]", TENumber.Text + "/INT/HRD-SK/" + month + "/" + Date.Now.ToString("yy"))

            Report.L_employee_name.Text = FormMasterEmployee.GVEmployee.GetFocusedRowCellDisplayText("employee_name")
            Report.L_employee_code.Text = FormMasterEmployee.GVEmployee.GetFocusedRowCellDisplayText("employee_code")
            Report.L_address_primary.Text = FormMasterEmployee.GVEmployee.GetFocusedRowCellDisplayText("address_primary")
            Report.L_employee_pob_dob.Text = FormMasterEmployee.GVEmployee.GetFocusedRowCellDisplayText("employee_pob") + ", " + FormMasterEmployee.GVEmployee.GetFocusedRowCellDisplayText("employee_dob")
            Report.L_date.Text = "Kuta, " + Date.Now.ToString("dd MMMM yyyy")
            Report.L_text.Text = Report.L_text.Text.Replace("[date]", DEDate.Text)
            Report.L_depthead.Text = depthead

            Dim Tool As DevExpress.XtraReports.UI.ReportPrintTool = New DevExpress.XtraReports.UI.ReportPrintTool(Report)
            Tool.ShowPreviewDialog()
        ElseIf id_popup = "3" Then
            Dim Report As New ReportMasterEmployeeSuratTugas()

            Report.XLNumber.Text = Report.XLNumber.Text.Replace("[number]", TENumber.Text + "/INT/HRD-ST/" + month + "/" + Date.Now.ToString("yy"))

            If FormMasterEmployee.GVEmployee.GetFocusedRowCellValue("id_employee").ToString = "132" Then
                Report.L_hrd_employee_name2.Text = "Marissa Bridgitt Kasih"
                Report.L_hrd_employee_position2.Text = "Director"
            Else
                Report.L_hrd_employee_name2.Text = "Johannes Paulus Lazarus Handoko"
                Report.L_hrd_employee_position2.Text = "HR & Compliance Manager"
            End If
            Report.L_employee_name.Text = FormMasterEmployee.GVEmployee.GetFocusedRowCellDisplayText("employee_name")
            Report.L_employee_code.Text = FormMasterEmployee.GVEmployee.GetFocusedRowCellDisplayText("employee_code")
            Report.L_employee_position.Text = FormMasterEmployee.GVEmployee.GetFocusedRowCellDisplayText("employee_position")
            Report.L_departement.Text = FormMasterEmployee.GVEmployee.GetFocusedRowCellDisplayText("departement")
            Report.L_date.Text = "Kuta, " + Date.Now.ToString("dd MMMM yyyy")

            Dim depthead As String = execute_query("
                SELECT e_dh.id_employee
                FROM tb_m_employee AS e
                LEFT JOIN tb_m_departement AS d ON e.id_departement = d.id_departement
                LEFT JOIN tb_m_user AS u_dh ON d.id_user_head = u_dh.id_user
                LEFT JOIN tb_m_employee AS e_dh ON u_dh.id_employee = e_dh.id_employee
                WHERE e.id_employee = " + FormMasterEmployee.GVEmployee.GetFocusedRowCellValue("id_employee").ToString + "
            ", 0, True, "", "", "", "")

            If depthead = FormMasterEmployee.GVEmployee.GetFocusedRowCellValue("id_employee").ToString Then
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
        ElseIf id_popup = "4" Then
            Dim Report As New ReportMasterEmployeeSuratKeteranganBansos()

            Report.XLNumber.Text = Report.XLNumber.Text.Replace("[number]", TENumber.Text + "/EXT/HRD-SK/" + month + "/" + Date.Now.ToString("yy"))

            Report.L_employee_name.Text = FormMasterEmployee.GVEmployee.GetFocusedRowCellDisplayText("employee_name")
            Report.L_employee_code.Text = FormMasterEmployee.GVEmployee.GetFocusedRowCellDisplayText("employee_code")
            Report.L_address_primary.Text = FormMasterEmployee.GVEmployee.GetFocusedRowCellDisplayText("address_primary")
            Report.L_employee_pob_dob.Text = FormMasterEmployee.GVEmployee.GetFocusedRowCellDisplayText("employee_pob") + ", " + FormMasterEmployee.GVEmployee.GetFocusedRowCellDisplayText("employee_dob")
            Report.L_date.Text = "Kuta, " + Date.Now.ToString("dd MMMM yyyy")
            Report.L_text.Text = Report.L_text.Text.Replace("[date]", DEDate.Text)

            Dim Tool As DevExpress.XtraReports.UI.ReportPrintTool = New DevExpress.XtraReports.UI.ReportPrintTool(Report)
            Tool.ShowPreviewDialog()
        End If
    End Sub

    Private Sub FormMasterEmployeeNomorSurat_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub
End Class