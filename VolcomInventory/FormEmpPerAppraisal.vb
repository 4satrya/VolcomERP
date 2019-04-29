Imports System.IO
Imports System.Net.Mail

Public Class FormEmpPerAppraisal
    Public is_dephead As String = "-1"
    Public is_hrd As String = "-1"

    Sub load_employee()
        Dim where_dephead As String = ""

        If is_dephead = "1" Then
            where_dephead = "AND (dept.id_employee_head = " + id_employee_user + " OR emp.id_departement = " + id_departement_user + ")"
        End If

        Dim query As String = "
            SELECT tb.*
            FROM (
	            SELECT emp.id_departement, dept.departement, dept.id_employee_head, dept.employee_head_name, dept.employee_head_email,
		            emp.id_employee_status, stt.employee_status,
		            emp.id_employee, emp.employee_code, emp.employee_name,
		            emp.employee_position, emp.id_employee_level, lvl.employee_level, IF(lvl.grup_penilaian = 0, 1, lvl.grup_penilaian) grup_penilaian,
		            IFNULL(qp.id_question_period, 0) id_question_period, IFNULL(qp.id_question_status, 1) id_question_status, IFNULL(qps.status, 'Belum Dinilai') status,
		            IFNULL(qp.appraiser_check, 0) appraiser_check,
		            IFNULL(DATE_FORMAT(qp.appraiser_check_date, '%d %M %Y'), '') appraiser_check_date,
		            IFNULL(qp.hrd_check, 0) hrd_check,
		            IFNULL(DATE_FORMAT(qp.hrd_check_date, '%d %M %Y'), '') hrd_check_date,
		            DATE_FORMAT(emp.employee_join_date, '%d %M %Y') employee_join_date,
		            DATE_FORMAT(jdate.start_period, '%d %M %Y') start_period,
		            DATE_FORMAT(jdate.end_period, '%d %M %Y') end_period,
		            DATE_FORMAT((jdate.end_period - INTERVAL 45 DAY), '%d %M %Y') start_evaluation_date,
		            DATE_FORMAT((jdate.end_period - INTERVAL 45 DAY) + INTERVAL 3 DAY, '%d %M %Y') end_evaluation_date,
		            IF(TIMESTAMPDIFF(DAY, ((jdate.end_period - INTERVAL 45 DAY)), DATE(CURDATE())) = 0, 1, 0) now,
		            TIMESTAMPDIFF(DAY, ((jdate.end_period - INTERVAL 45 DAY) + INTERVAL 3 DAY), DATE(CURDATE())) late
	            FROM tb_m_employee emp
	            LEFT JOIN (
		            SELECT d.id_departement, d.departement, e.id_employee id_employee_head, e.employee_name employee_head_name, e.email_lokal employee_head_email
		            FROM tb_m_departement d
		            LEFT JOIN tb_m_user u ON d.id_user_head = u.id_user
		            LEFT JOIN tb_m_employee e ON u.id_employee = e.id_employee
	            ) dept ON dept.id_departement = emp.id_departement 
	            LEFT JOIN tb_lookup_employee_status stt ON stt.id_employee_status = emp.id_employee_status 
	            LEFT JOIN tb_lookup_employee_level lvl ON lvl.id_employee_level = emp.id_employee_level
	            LEFT JOIN (
		            SELECT e.id_employee, 
			            IF(CURDATE() >= j.first_evaluation_start AND CURDATE() <= j.first_evaluation_end, j.first_evaluation_start, j.second_evaluation_start) start_period,
			            IF(CURDATE() >= j.first_evaluation_start AND CURDATE() <= j.first_evaluation_end, j.first_evaluation_end, j.second_evaluation_end) end_period,
			            j.first_evaluation_start,
			            j.first_evaluation_end,
			            j.second_evaluation_start,
			            j.second_evaluation_end
		            FROM tb_m_employee e
		            LEFT JOIN (
			            SELECT id_employee,
				            DATE_ADD(employee_join_date, INTERVAL (TIMESTAMPDIFF(YEAR, employee_join_date, DATE(CURDATE()))) YEAR) first_evaluation_start,
				            DATE_ADD(DATE_ADD(employee_join_date, INTERVAL (TIMESTAMPDIFF(YEAR, employee_join_date, DATE(CURDATE()))) YEAR), INTERVAL 6 MONTH) - INTERVAL 1 DAY first_evaluation_end,
				            DATE_ADD(DATE_ADD(employee_join_date, INTERVAL (TIMESTAMPDIFF(YEAR, employee_join_date, DATE(CURDATE()))) YEAR), INTERVAL 6 MONTH) second_evaluation_start,
				            DATE_ADD(DATE_ADD(employee_join_date, INTERVAL (TIMESTAMPDIFF(YEAR, employee_join_date, DATE(CURDATE()))) YEAR), INTERVAL 12 MONTH) - INTERVAL 1 DAY second_evaluation_end
			            FROM tb_m_employee
		            ) j ON e.id_employee = j.id_employee
	            ) jdate ON emp.id_employee = jdate.id_employee
	            LEFT JOIN tb_question_period qp ON emp.id_employee = qp.id_employee AND jdate.start_period = qp.from_period AND jdate.end_period = qp.until_period
	            LEFT JOIN tb_lookup_question_status qps ON qp.id_question_status = qps.id_question_status
	            WHERE emp.id_employee_active = 1 AND (CURDATE() >= (jdate.end_period - INTERVAL 45 DAY) AND CURDATE() <= jdate.end_period) AND dept.id_employee_head <> emp.id_employee " + where_dephead + "
            ) tb
            WHERE tb.id_question_status <> 3
            ORDER BY tb.id_employee ASC
        "

        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")

        GCList.DataSource = data

        GVList.BestFitColumns()
    End Sub

    Sub load_history()
        Dim where_dephead As String = ""

        If is_dephead = "1" Then
            where_dephead = "AND (dept.id_employee_head = " + id_employee_user + " OR emp.id_departement = " + id_departement_user + ")"
        End If

        Dim query As String = "
            SELECT emp.id_departement, dept.departement, IFNULL(dept.id_employee_head, 0) id_employee_head, IFNULL(dept.employee_head_name, '') employee_head_name, IFNULL(dept.employee_head_email, '') employee_head_email,
                IFNULL(emp.id_employee_status, 0) id_employee_status, IFNULL(stt.employee_status, '') employee_status,
	            emp.id_employee, emp.employee_code, emp.employee_name,
	            emp.employee_position, emp.id_employee_level, lvl.employee_level, IF(lvl.grup_penilaian = 0, 1, lvl.grup_penilaian) grup_penilaian,
	            qp.id_question_period, qp.id_question_status, qps.status,
	            qp.appraiser_check, DATE_FORMAT(qp.appraiser_check_date, '%d %M %Y') appraiser_check_date,
	            qp.hrd_check, DATE_FORMAT(qp.hrd_check_date, '%d %M %Y') hrd_check_date,
	            DATE_FORMAT(emp.employee_join_date, '%d %M %Y') employee_join_date,
	            DATE_FORMAT(qp.from_period, '%d %M %Y') start_period,
	            DATE_FORMAT(qp.until_period, '%d %M %Y') end_period,
	            DATE_FORMAT((qp.until_period - INTERVAL 45 DAY), '%d %M %Y') start_evaluation_date,
	            DATE_FORMAT((qp.until_period - INTERVAL 45 DAY) + INTERVAL 5 DAY, '%d %M %Y') end_evaluation_date
            FROM tb_question_period qp
            LEFT JOIN tb_lookup_question_status qps ON qp.id_question_status = qps.id_question_status
            LEFT JOIN tb_m_employee emp ON qp.id_employee = emp.id_employee
            LEFT JOIN (
	            SELECT d.id_departement, d.departement, e.id_employee id_employee_head, e.employee_name employee_head_name, e.email_lokal employee_head_email
	            FROM tb_m_departement d
	            LEFT JOIN tb_m_user u ON d.id_user_head = u.id_user
	            LEFT JOIN tb_m_employee e ON u.id_employee = e.id_employee
            ) dept ON dept.id_departement = emp.id_departement 
            LEFT JOIN tb_lookup_employee_status stt ON stt.id_employee_status = emp.id_employee_status 
            LEFT JOIN tb_lookup_employee_level lvl ON lvl.id_employee_level = emp.id_employee_level
            WHERE qp.id_question_status = 3 AND dept.id_employee_head <> emp.id_employee " + where_dephead + "
            ORDER BY emp.id_employee ASC
        "

        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")

        GCHistory.DataSource = data

        GVHistory.BestFitColumns()
    End Sub

    Private Sub FormEmpPerAppraisal_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        load_employee()
        load_history()
    End Sub

    Private Sub FormEmpPerAppraisal_Activated(sender As Object, e As EventArgs) Handles MyBase.Activated
        FormMain.show_rb(Name)
        checkFormAccess(Name)
        button_main("0", "0", "0")
    End Sub

    Private Sub FormEmpPerAppraisal_Deactivate(sender As Object, e As EventArgs) Handles MyBase.Deactivate
        FormMain.hide_rb()
    End Sub

    Sub load_detail(GridView As DevExpress.XtraGrid.Views.BandedGrid.BandedGridView)
        If GridView.GetFocusedRowCellValue("id_employee") IsNot Nothing Then
            FormEmpPerAppraisalDet.is_dephead = is_dephead
            FormEmpPerAppraisalDet.is_hrd = is_hrd

            FormEmpPerAppraisalDet.id_employee = GridView.GetFocusedRowCellValue("id_employee")

            FormEmpPerAppraisalDet.grup_penilaian = GridView.GetFocusedRowCellValue("grup_penilaian")

            FormEmpPerAppraisalDet.id_question_period = GridView.GetFocusedRowCellValue("id_question_period")
            FormEmpPerAppraisalDet.id_question_status = GridView.GetFocusedRowCellValue("id_question_status")

            FormEmpPerAppraisalDet.employee_head_name = GridView.GetFocusedRowCellValue("employee_head_name").ToString

            FormEmpPerAppraisalDet.appraiser_check = GridView.GetFocusedRowCellValue("appraiser_check")
            FormEmpPerAppraisalDet.appraiser_check_date = GridView.GetFocusedRowCellValue("appraiser_check_date").ToString
            FormEmpPerAppraisalDet.hrd_check = GridView.GetFocusedRowCellValue("hrd_check")
            FormEmpPerAppraisalDet.hrd_check_date = GridView.GetFocusedRowCellValue("hrd_check_date").ToString

            FormEmpPerAppraisalDet.TEEmployeeName.EditValue = GridView.GetFocusedRowCellValue("employee_name").ToString
            FormEmpPerAppraisalDet.TEEmployeePosition.EditValue = GridView.GetFocusedRowCellValue("employee_position").ToString
            FormEmpPerAppraisalDet.TEDepartement.EditValue = GridView.GetFocusedRowCellValue("departement").ToString
            FormEmpPerAppraisalDet.TECompany.EditValue = "PT. Volcom Indonesia"
            FormEmpPerAppraisalDet.TEEmployeeJoinDate.EditValue = GridView.GetFocusedRowCellValue("employee_join_date").ToString
            FormEmpPerAppraisalDet.TEEmployeeStatus.EditValue = GridView.GetFocusedRowCellValue("employee_status").ToString
            FormEmpPerAppraisalDet.TEStartPeriod.EditValue = GridView.GetFocusedRowCellValue("start_period").ToString
            FormEmpPerAppraisalDet.TEEndPeriod.EditValue = GridView.GetFocusedRowCellValue("end_period").ToString
            FormEmpPerAppraisalDet.TEPurpose.EditValue = If(GridView.GetFocusedRowCellValue("id_employee_status") = 1, "Review kontrak kerja", "Reguler")
            FormEmpPerAppraisalDet.LCAttNote.Text = "*periode absensi " + GridView.GetFocusedRowCellValue("start_period").ToString + " s/d " + GridView.GetFocusedRowCellValue("start_evaluation_date").ToString

            FormEmpPerAppraisalDet.ShowDialog()
        End If
    End Sub

    Private Sub GVList_DoubleClick(sender As Object, e As EventArgs) Handles GVList.DoubleClick
        load_detail(GVList)
    End Sub

    Private Sub GVHistory_DoubleClick(sender As Object, e As EventArgs) Handles GVHistory.DoubleClick
        load_detail(GVHistory)
    End Sub
End Class