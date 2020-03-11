Public Class FormEmpPerAppraisalPick
    Private Sub SBClose_Click(sender As Object, e As EventArgs) Handles SBClose.Click
        Close()
    End Sub

    Private Sub SBAdd_Click(sender As Object, e As EventArgs) Handles SBAdd.Click
        If GVList.GetFocusedRowCellValue("id_employee") IsNot Nothing Then
            FormEmpPerAppraisalDet.is_pick = True

            FormEmpPerAppraisalDet.is_dephead = FormEmpPerAppraisal.is_dephead
            FormEmpPerAppraisalDet.is_hrd = FormEmpPerAppraisal.is_hrd

            FormEmpPerAppraisalDet.is_only_absensi = FormEmpPerAppraisal.is_only_absensi

            FormEmpPerAppraisalDet.id_employee = GVList.GetFocusedRowCellValue("id_employee")

            FormEmpPerAppraisalDet.grup_penilaian = GVList.GetFocusedRowCellValue("grup_penilaian")

            FormEmpPerAppraisalDet.id_question_period = 0
            FormEmpPerAppraisalDet.id_question_status = 1

            FormEmpPerAppraisalDet.employee_head_name = GVList.GetFocusedRowCellValue("employee_head_name").ToString

            FormEmpPerAppraisalDet.appraiser_check = 0
            FormEmpPerAppraisalDet.appraiser_check_date = ""
            FormEmpPerAppraisalDet.hrd_check = 0
            FormEmpPerAppraisalDet.hrd_check_date = ""

            FormEmpPerAppraisalDet.TEEmployeeName.EditValue = GVList.GetFocusedRowCellValue("employee_name").ToString
            FormEmpPerAppraisalDet.TEEmployeePosition.EditValue = GVList.GetFocusedRowCellValue("employee_position").ToString
            FormEmpPerAppraisalDet.TEDepartement.EditValue = GVList.GetFocusedRowCellValue("departement").ToString
            FormEmpPerAppraisalDet.TECompany.EditValue = "PT. Volcom Indonesia"
            FormEmpPerAppraisalDet.TEEmployeeJoinDate.EditValue = GVList.GetFocusedRowCellValue("employee_join_date").ToString
            FormEmpPerAppraisalDet.TEEmployeeStatus.EditValue = GVList.GetFocusedRowCellValue("employee_status").ToString
            FormEmpPerAppraisalDet.TEStartPeriod.EditValue = Date.Parse(DEPeriodDateFrom.EditValue.ToString).ToString("dd MMMM yyyy")
            FormEmpPerAppraisalDet.TEEndPeriod.EditValue = Date.Parse(DEPeriodDateTo.EditValue.ToString).ToString("dd MMMM yyyy")
            FormEmpPerAppraisalDet.TEPurpose.EditValue = TextEditPropose.Text
            FormEmpPerAppraisalDet.LCAttNote.Text = "*periode absensi " + Date.Parse(DEPeriodDateFrom.EditValue.ToString).ToString("dd MMMM yyyy") + " s/d " + Date.Parse(DEPeriodDateTo.EditValue.ToString).ToString("dd MMMM yyyy")

            FormEmpPerAppraisalDet.ShowDialog()
        End If
    End Sub

    Private Sub FormEmpPerAppraisalPick_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim whereDept = ""

        DEPeriodDateFrom.EditValue = Now
        DEPeriodDateTo.EditValue = Now

        TextEditPropose.EditValue = "Reguler"

        If FormEmpPerAppraisal.is_dephead = "1" Then
            whereDept = "AND (d.id_employee_head = " + id_employee_user + " OR e.id_departement = " + id_departement_user + ")"
        End If

        Dim query As String = "
            SELECT id_employee, id_departement, departement, employee_code, employee_name, employee_position, id_employee_status, employee_status, id_employee_active, employee_active, grup_penilaian, employee_head_name, employee_join_date
            FROM (
                SELECT e.id_employee, e.id_departement, d.departement, e.employee_code, e.employee_name, e.employee_position, e.id_employee_status, st.employee_status, e.id_employee_active, la.employee_active, IF(lv.grup_penilaian = 0, 1, lv.grup_penilaian) grup_penilaian, d.employee_head_name, DATE_FORMAT(e.employee_join_date, '%d %M %Y') AS employee_join_date
                FROM tb_m_employee AS e
                LEFT JOIN (
                    SELECT d.id_departement, d.departement, e.id_employee id_employee_head, e.employee_name employee_head_name, e.email_lokal employee_head_email
                    FROM tb_m_departement d
                    LEFT JOIN tb_m_user u ON d.id_user_head = u.id_user
                    LEFT JOIN tb_m_employee e ON u.id_employee = e.id_employee
                ) d ON d.id_departement = e.id_departement 
                LEFT JOIN tb_lookup_employee_status AS st ON e.id_employee_status = st.id_employee_status
                LEFT JOIN tb_lookup_employee_active AS la ON e.id_employee_active = la.id_employee_active
                LEFT JOIN tb_lookup_employee_level AS lv ON e.id_employee_level = lv.id_employee_level
                WHERE 1 " + whereDept + " AND e.id_employee_active = 1
                ORDER BY d.departement ASC, e.id_employee_level ASC, e.employee_code ASC
            ) AS tb
            GROUP BY id_employee
        "

        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")

        GCList.DataSource = data

        GVList.BestFitColumns()
    End Sub

    Private Sub FormEmpPerAppraisalPick_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub
End Class