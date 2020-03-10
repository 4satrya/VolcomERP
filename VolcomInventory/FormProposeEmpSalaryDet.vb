Public Class FormProposeEmpSalaryDet
    Public id_employee_sal_pps As String = "-1"
    Public is_duplicate As String = "-1"
    Public id_employee_pps As String = "-1"

    Public Sub load_contract()
        Dim id_employee As List(Of String) = New List(Of String)

        id_employee.Add("-1")

        For i = 0 To GVEmployee.RowCount - 1
            If GVEmployee.IsValidRowHandle(i) Then
                id_employee.Add(GVEmployee.GetRowCellValue(i, "id_employee").ToString)
            End If
        Next

        Dim query As String = "
            SELECT * FROM (SELECT 0 AS id_employee_status_det, 0 AS id_employee, '-' AS contract) AS tba
            UNION ALL
            SELECT * FROM (SELECT id_employee_status_det, id_employee, IF(a.id_employee_status = 2, CONCAT(b.employee_status, ' (', DATE_FORMAT(a.start_period, '%d %b %Y'), ')'), CONCAT(b.employee_status, ' (', DATE_FORMAT(a.start_period, '%d %b %Y'), ' - ', DATE_FORMAT(a.end_period, '%d %b %Y'), ')')) AS contract
            FROM tb_m_employee_status_det AS a 
            INNER JOIN tb_lookup_employee_status AS b ON b.id_employee_status = a.id_employee_status 
            WHERE a.id_employee IN (" + String.Join(", ", id_employee.ToArray) + ")
            ORDER BY a.id_employee ASC, a.id_employee_status_det DESC) AS tbb
        "

        viewSearchLookupRepositoryQuery(RepositoryItemSearchLookUpEdit, query, 0, "contract", "id_employee_status_det")
    End Sub

    Private Sub FormProposeEmpSalaryDet_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        view_type()
        view_category()

        form_load()

        permission_load()

        load_contract()

        'from propose employee
        If Not id_employee_pps = "-1" Then
            SBInsertEmployee.Visible = False
            SBRemoveEmployee.Visible = False

            Dim query As String = "
                SELECT pps.*, dep.departement, dep.total_workdays, lvl.employee_level, sts.employee_status, IF(pps.id_employee_active = 1, TIMESTAMPDIFF(MONTH, pps.employee_actual_join_date, DATE(NOW())), TIMESTAMPDIFF(MONTH, pps.employee_actual_join_date, pps.employee_last_date)) AS tmp_length_work, IF((SELECT tmp_length_work) < 12, CONCAT((SELECT tmp_length_work), ' month'), CONCAT(FLOOR((SELECT tmp_length_work) / 12), ' year')) AS length_work
                FROM tb_employee_pps AS pps
                LEFT JOIN tb_m_departement AS dep ON pps.id_departement = dep.id_departement
                LEFT JOIN tb_lookup_employee_level AS lvl ON pps.id_employee_level = lvl.id_employee_level
                LEFT JOIN tb_lookup_employee_status AS sts ON pps.id_employee_status = sts.id_employee_status
                WHERE pps.id_employee_pps = " + id_employee_pps + "
            "

            Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")

            DEEffectiveDate.EditValue = data.Rows(0)("start_period")
            LUEType.EditValue = If(data.Rows(0)("id_employee_status").ToString = "3", "2", "1")

            CType(GCEmployee.DataSource, DataTable).Rows.Add(
                data.Rows(0)("id_employee").ToString,
                data.Rows(0)("employee_code").ToString,
                data.Rows(0)("employee_name").ToString,
                data.Rows(0)("id_departement").ToString,
                data.Rows(0)("departement").ToString,
                data.Rows(0)("total_workdays").ToString,
                data.Rows(0)("employee_position").ToString,
                data.Rows(0)("tmp_length_work").ToString,
                data.Rows(0)("length_work").ToString,
                data.Rows(0)("id_employee_level").ToString,
                data.Rows(0)("employee_level").ToString,
                data.Rows(0)("id_employee_status").ToString,
                data.Rows(0)("employee_status").ToString,
                0,
                0,
                0,
                0,
                0,
                0,
                0,
                0,
                0,
                0,
                0,
                0,
                0,
                0,
                0
            )

            'det.id_employee, 
            'emp.employee_code, 
            'emp.employee_name, 
            'det.id_departement, 
            'dp.departement, 
            'dp.total_workdays, 
            'det.employee_position, 
            'IF(emp.id_employee_active = 1, TIMESTAMPDIFF(MONTH, emp.employee_actual_join_date, DATE(NOW())), TIMESTAMPDIFF(MONTH, emp.employee_actual_join_date, emp.employee_last_date)) AS tmp_length_work, 
            'IF((SELECT tmp_length_work) < 12, CONCAT((SELECT tmp_length_work), ' month'), CONCAT(FLOOR((SELECT tmp_length_work) / 12), ' year')) AS length_work, 
            'det.id_employee_level, 
            'lv.employee_level, 
            'det.id_employee_status, 
            'sts.employee_status, 
            'IFNULL(det.id_employee_salary, 0) AS id_employee_salary, 
            'ROUND(IFNULL(sal.basic_salary, 0), 0) AS basic_salary_current, 
            'ROUND(IFNULL(sal.allow_job, 0), 0) AS allow_job_current, 
            'ROUND(IFNULL(sal.allow_meal, 0), 0) AS allow_meal_current, 
            'ROUND(IFNULL(sal.allow_trans, 0), 0) AS allow_trans_current, 
            'ROUND(IFNULL(sal.allow_house, 0), 0) AS allow_house_current, 
            'ROUND(IFNULL(sal.allow_car, 0), 0) AS allow_car_current, 
            '((SELECT basic_salary_current) + (SELECT allow_job_current) + (SELECT allow_meal_current) + (SELECT allow_trans_current) + (SELECT allow_house_current) + (SELECT allow_car_current)) AS total_salary_current, 
            'ROUND(IFNULL(det.basic_salary, 0), 0) AS basic_salary, 
            'ROUND(det.allow_job, 0) AS allow_job, 
            'ROUND(det.allow_meal, 0) AS allow_meal, 
            'ROUND(det.allow_trans, 0) AS allow_trans, 
            'ROUND(det.allow_house, 0) AS allow_house, 
            'ROUND(det.allow_car, 0) AS allow_car, 
            'CONCAT(ROUND(((det.basic_salary + det.allow_job + det.allow_meal + det.allow_trans + det.allow_house + det.allow_car) - (IFNULL(sal.basic_salary, 0) + IFNULL(sal.allow_job, 0) + IFNULL(sal.allow_meal, 0) + IFNULL(sal.allow_trans, 0) + IFNULL(sal.allow_house, 0) + IFNULL(sal.allow_car, 0))) / (IFNULL(sal.basic_salary, 0) + IFNULL(sal.allow_job, 0) + IFNULL(sal.allow_meal, 0) + IFNULL(sal.allow_trans, 0) + IFNULL(sal.allow_house, 0) + IFNULL(sal.allow_car, 0)) * 100, 2), '%') AS increase, CONCAT(ROUND(((ROUND(det.basic_salary, 0) + ROUND(det.allow_job, 0) + ROUND(det.allow_meal, 0) + ROUND(det.allow_trans, 0)) / (ROUND(det.basic_salary, 0) + ROUND(det.allow_job, 0) + ROUND(det.allow_meal, 0) + ROUND(det.allow_trans, 0) + ROUND(det.allow_house, 0) + ROUND(det.allow_car, 0)) * 100), 2), '%') AS fixed_salary, 
            'CONCAT(ROUND(((ROUND(det.allow_house, 0) + ROUND(det.allow_car, 0)) / (ROUND(det.basic_salary, 0) + ROUND(det.allow_job, 0) + ROUND(det.allow_meal, 0) + ROUND(det.allow_trans, 0) + ROUND(det.allow_house, 0) + ROUND(det.allow_car, 0)) * 100), 2), '%') AS non_fixed_salary, 
            'det.id_employee_status_det, 
            'det.reason
        End If
    End Sub

    Private Sub FormProposeEmpSalaryDet_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        FormProposeEmpSalary.load_pps()

        If Not id_employee_sal_pps = "-1" Then
            FormProposeEmpSalary.GVList.FocusedRowHandle = find_row(FormProposeEmpSalary.GVList, "id_employee_sal_pps", id_employee_sal_pps)
        End If

        Dispose()
    End Sub

    Sub view_type()
        Dim query As String = "
            SELECT id_sal_pps_type, sal_pps_type FROM tb_lookup_employee_sal_pps_type
        "

        viewLookupQuery(LUEType, query, 0, "sal_pps_type", "id_sal_pps_type")
    End Sub

    Sub view_category()
        Dim query As String = "
            SELECT id_sal_pps_category, sal_pps_category FROM tb_lookup_employee_sal_pps_category
        "

        viewLookupQuery(LUECategory, query, 0, "sal_pps_category", "id_sal_pps_category")
    End Sub

    Sub form_load()
        'load
        Dim query As String = "
            SELECT sal.id_employee_sal_pps, sal.id_sal_pps_category, sal.id_sal_pps_type, DATE_FORMAT(sal.effective_date, '%d %M %Y') AS effective_date, sal.id_report_status, sal.number, sal.note, emp.employee_name AS created_by, DATE_FORMAT(sal.created_at, '%d %M %Y %H:%i:%s') AS created_at
            FROM tb_employee_sal_pps AS sal
            LEFT JOIN tb_m_employee AS emp ON sal.created_by = emp.id_employee
            WHERE sal.id_employee_sal_pps = " + id_employee_sal_pps + "
            
            UNION ALL
            
            #default value
            SELECT -1 AS id_employee_sal_pps, 1 AS id_sal_pps_category, 1 AS id_sal_pps_type, DATE_FORMAT(NOW(), '%d %M %Y') AS effective_date, -1 AS id_report_status, '[autogenerate]' AS number, '' AS note, (SELECT employee_name FROM tb_m_employee WHERE id_employee = " + id_employee_user + ") AS created_by, DATE_FORMAT(NOW(), '%d %M %Y %H:%i:%s') AS created_at
        "

        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")

        TENumber.EditValue = data.Rows(0)("number").ToString
        MENote.EditValue = data.Rows(0)("note").ToString
        DEEffectiveDate.EditValue = data.Rows(0)("effective_date")
        TECreatedBy.EditValue = data.Rows(0)("created_by").ToString
        DECreatedAt.EditValue = data.Rows(0)("created_at")
        LUECategory.ItemIndex = LUECategory.Properties.GetDataSourceRowIndex("id_sal_pps_category", data.Rows(0)("id_sal_pps_category").ToString)
        LUEType.ItemIndex = LUEType.Properties.GetDataSourceRowIndex("id_sal_pps_type", data.Rows(0)("id_sal_pps_type").ToString)

        'load detail
        Dim query_detail As String = "
            SELECT det.id_employee, emp.employee_code, emp.employee_name, det.id_departement, dp.departement, dp.total_workdays, det.employee_position, IF(emp.id_employee_active = 1, TIMESTAMPDIFF(MONTH, emp.employee_actual_join_date, DATE(NOW())), TIMESTAMPDIFF(MONTH, emp.employee_actual_join_date, emp.employee_last_date)) AS tmp_length_work, IF((SELECT tmp_length_work) < 12, CONCAT((SELECT tmp_length_work), ' month'), CONCAT(FLOOR((SELECT tmp_length_work) / 12), ' year')) AS length_work, det.id_employee_level, lv.employee_level, det.id_employee_status, sts.employee_status, IFNULL(det.id_employee_salary, 0) AS id_employee_salary, ROUND(IFNULL(sal.basic_salary, 0), 0) AS basic_salary_current, ROUND(IFNULL(sal.allow_job, 0), 0) AS allow_job_current, ROUND(IFNULL(sal.allow_meal, 0), 0) AS allow_meal_current, ROUND(IFNULL(sal.allow_trans, 0), 0) AS allow_trans_current, ROUND(IFNULL(sal.allow_house, 0), 0) AS allow_house_current, ROUND(IFNULL(sal.allow_car, 0), 0) AS allow_car_current, ((SELECT basic_salary_current) + (SELECT allow_job_current) + (SELECT allow_meal_current) + (SELECT allow_trans_current) + (SELECT allow_house_current) + (SELECT allow_car_current)) AS total_salary_current, ROUND(IFNULL(det.basic_salary, 0), 0) AS basic_salary, ROUND(det.allow_job, 0) AS allow_job, ROUND(det.allow_meal, 0) AS allow_meal, ROUND(det.allow_trans, 0) AS allow_trans, ROUND(det.allow_house, 0) AS allow_house, ROUND(det.allow_car, 0) AS allow_car, CONCAT(ROUND(((det.basic_salary + det.allow_job + det.allow_meal + det.allow_trans + det.allow_house + det.allow_car) - (IFNULL(sal.basic_salary, 0) + IFNULL(sal.allow_job, 0) + IFNULL(sal.allow_meal, 0) + IFNULL(sal.allow_trans, 0) + IFNULL(sal.allow_house, 0) + IFNULL(sal.allow_car, 0))) / (IFNULL(sal.basic_salary, 0) + IFNULL(sal.allow_job, 0) + IFNULL(sal.allow_meal, 0) + IFNULL(sal.allow_trans, 0) + IFNULL(sal.allow_house, 0) + IFNULL(sal.allow_car, 0)) * 100, 2), '%') AS increase, CONCAT(ROUND(((ROUND(det.basic_salary, 0) + ROUND(det.allow_job, 0) + ROUND(det.allow_meal, 0) + ROUND(det.allow_trans, 0)) / (ROUND(det.basic_salary, 0) + ROUND(det.allow_job, 0) + ROUND(det.allow_meal, 0) + ROUND(det.allow_trans, 0) + ROUND(det.allow_house, 0) + ROUND(det.allow_car, 0)) * 100), 2), '%') AS fixed_salary, CONCAT(ROUND(((ROUND(det.allow_house, 0) + ROUND(det.allow_car, 0)) / (ROUND(det.basic_salary, 0) + ROUND(det.allow_job, 0) + ROUND(det.allow_meal, 0) + ROUND(det.allow_trans, 0) + ROUND(det.allow_house, 0) + ROUND(det.allow_car, 0)) * 100), 2), '%') AS non_fixed_salary, det.id_employee_status_det, det.reason
            FROM tb_employee_sal_pps_det AS det
            LEFT JOIN tb_m_employee AS emp ON det.id_employee = emp.id_employee
            LEFT JOIN tb_m_departement AS dp ON det.id_departement = dp.id_departement
            LEFT JOIN tb_lookup_employee_level AS lv ON det.id_employee_level = lv.id_employee_level
            LEFT JOIN tb_lookup_employee_status AS sts ON det.id_employee_status = sts.id_employee_status
            LEFT JOIN tb_m_employee_salary AS sal ON det.id_employee_salary = sal.id_employee_salary
            WHERE det.id_employee_sal_pps = " + id_employee_sal_pps + "
            ORDER BY det.id_employee_level ASC, emp.employee_code ASC
        "

        Dim data_detail As DataTable = execute_query(query_detail, -1, True, "", "", "", "")

        GCEmployee.DataSource = data_detail

        GVEmployee.BestFitColumns()

        'duplicate
        If is_duplicate = "1" Then
            TENumber.EditValue = "[autogenerate]"

            id_employee_sal_pps = "-1"
        End If

        update_current()

        If LUEType.EditValue.ToString = "2" Then
            GCIncreaseRp.UnboundExpression = "[basic_salary] - [basic_salary_current]"
        End If
    End Sub

    Sub permission_load()
        Dim id_report_status As String = If(id_employee_sal_pps = "-1", "0", execute_query("SELECT id_report_status FROM tb_employee_sal_pps WHERE id_employee_sal_pps = " + id_employee_sal_pps + "", 0, True, "", "", "", ""))

        If id_report_status = "0" Then
            SBMark.Enabled = False
            SBAttachment.Enabled = False
        Else
            SBSubmit.Enabled = False
            SBSave.Enabled = False

            SBInsertEmployee.Enabled = False
            SBRemoveEmployee.Enabled = False

            DEEffectiveDate.ReadOnly = True
            MENote.ReadOnly = True
            RITESalary.ReadOnly = True
            LUEType.ReadOnly = True
            LUECategory.ReadOnly = True

            RemoveEmployeeToolStripMenuItem.Visible = False

            RepositoryItemSearchLookUpEdit.ReadOnly = True

            RITEReason.ReadOnly = True
        End If
    End Sub

    Sub save(ByVal type As String)
        Cursor = Cursors.WaitCursor

        Dim query As String = ""

        'insert tb_employee_sal_pps
        Dim id_sal_pps_category As String = LUECategory.EditValue.ToString
        Dim id_sal_pps_type As String = LUEType.EditValue.ToString
        Dim effective_date As String = DateTime.Parse(DEEffectiveDate.EditValue.ToString).ToString("yyyy-MM-dd")
        Dim id_report_status As String = If(type = "submit", "1", "0")
        Dim note As String = addSlashes(MENote.Text)

        If id_employee_sal_pps = "-1" Then
            query = "
                INSERT INTO tb_employee_sal_pps (id_sal_pps_category, id_sal_pps_type, effective_date, id_report_status, note, created_by, created_at) 
                VALUES (" + id_sal_pps_category + ", " + id_sal_pps_type + ", '" + effective_date + "', " + id_report_status + ", '" + note + "', " + id_employee_user + ", NOW());
                SELECT LAST_INSERT_ID();
            "

            id_employee_sal_pps = execute_query(query, 0, True, "", "", "", "")
        Else
            query = "UPDATE tb_employee_sal_pps SET id_sal_pps_category = " + id_sal_pps_category + ", id_sal_pps_type = " + id_sal_pps_type + ", effective_date = '" + effective_date + "', id_report_status = " + id_report_status + ", note = '" + note + "' WHERE id_employee_sal_pps = " + id_employee_sal_pps + ""

            execute_non_query(query, True, "", "", "", "")
        End If

        'insert tb_employee_sal_pps_det
        If Not id_employee_sal_pps = "-1" Then
            execute_non_query("DELETE FROM tb_employee_sal_pps_det WHERE id_employee_sal_pps = " + id_employee_sal_pps + "", True, "", "", "", "")
        End If

        Dim values As String = ""

        For i = 0 To GVEmployee.RowCount - 1
            If GVEmployee.IsValidRowHandle(i) Then
                Dim id_employee As String = GVEmployee.GetRowCellValue(i, "id_employee").ToString
                Dim id_departement As String = GVEmployee.GetRowCellValue(i, "id_departement").ToString
                Dim employee_position As String = addSlashes(GVEmployee.GetRowCellValue(i, "employee_position").ToString)
                Dim id_employee_level As String = GVEmployee.GetRowCellValue(i, "id_employee_level").ToString
                Dim id_employee_status As String = GVEmployee.GetRowCellValue(i, "id_employee_status").ToString
                Dim basic_salary As String = GVEmployee.GetRowCellValue(i, "basic_salary").ToString
                Dim allow_job As String = GVEmployee.GetRowCellValue(i, "allow_job").ToString
                Dim allow_meal As String = GVEmployee.GetRowCellValue(i, "allow_meal").ToString
                Dim allow_trans As String = GVEmployee.GetRowCellValue(i, "allow_trans").ToString
                Dim allow_house As String = GVEmployee.GetRowCellValue(i, "allow_house").ToString
                Dim allow_car As String = GVEmployee.GetRowCellValue(i, "allow_car").ToString
                Dim id_employee_status_det As String = GVEmployee.GetRowCellValue(i, "id_employee_status_det").ToString
                Dim id_employee_salary As String = GVEmployee.GetRowCellValue(i, "id_employee_salary").ToString
                Dim reason As String = addSlashes(GVEmployee.GetRowCellValue(i, "reason").ToString)

                values += "(" + id_employee_sal_pps + ", " + id_employee + ", " + id_departement + ", '" + employee_position + "', " + id_employee_level + ", " + id_employee_status + ", " + basic_salary + ", " + allow_job + ", " + allow_meal + ", " + allow_trans + ", " + allow_house + ", " + allow_car + ", " + id_employee_status_det + ", " + id_employee_salary + ", '" + reason + "'), "
            End If
        Next

        If Not values = "" Then
            values = values.Substring(0, values.Length - 2)

            query = "INSERT INTO tb_employee_sal_pps_det (id_employee_sal_pps, id_employee, id_departement, employee_position, id_employee_level, id_employee_status, basic_salary, allow_job, allow_meal, allow_trans, allow_house, allow_car, id_employee_status_det, id_employee_salary, reason) VALUES " + values + ""

            execute_non_query(query, True, "", "", "", "")
        End If

        execute_non_query("CALL gen_number(" + id_employee_sal_pps + ", 197)", True, "", "", "", "")

        If type = "submit" Then
            If LUECategory.EditValue.ToString = "1" Then
                submit_who_prepared("197", id_employee_sal_pps, id_user)
            ElseIf LUECategory.EditValue.ToString = "2" Then
                submit_who_prepared("229", id_employee_sal_pps, id_user)
            End If
        End If

        Cursor = Cursors.Default
    End Sub

    Sub update_changes()
        Dim query As String = "
            SELECT pps_det.id_employee
            FROM tb_employee_sal_pps_det AS pps_det
            LEFT JOIN tb_employee_sal_pps AS pps ON pps_det.id_employee_sal_pps = pps.id_employee_sal_pps
            WHERE pps.id_employee_sal_pps = " + id_employee_sal_pps + "
        "

        Dim pps_salary As DataTable = execute_query(query, -1, True, "", "", "", "")

        For i = 0 To pps_salary.Rows.Count - 1
            Dim id_employee As String = pps_salary.Rows(i)("id_employee").ToString

            execute_non_query("
                UPDATE tb_m_employee SET 
                    basic_salary = (SELECT basic_salary FROM tb_employee_sal_pps_det WHERE id_employee_sal_pps = " + id_employee_sal_pps + " AND id_employee = " + id_employee + "),
                    allow_job = (SELECT allow_job FROM tb_employee_sal_pps_det WHERE id_employee_sal_pps = " + id_employee_sal_pps + " AND id_employee = " + id_employee + "),
                    allow_meal = (SELECT allow_meal FROM tb_employee_sal_pps_det WHERE id_employee_sal_pps = " + id_employee_sal_pps + " AND id_employee = " + id_employee + "),
                    allow_trans = (SELECT allow_trans FROM tb_employee_sal_pps_det WHERE id_employee_sal_pps = " + id_employee_sal_pps + " AND id_employee = " + id_employee + "),
                    allow_house = (SELECT allow_house FROM tb_employee_sal_pps_det WHERE id_employee_sal_pps = " + id_employee_sal_pps + " AND id_employee = " + id_employee + "),
                    allow_car = (SELECT allow_car FROM tb_employee_sal_pps_det WHERE id_employee_sal_pps = " + id_employee_sal_pps + " AND id_employee = " + id_employee + ")
                WHERE id_employee = " + id_employee + "
            ", True, "", "", "", "")

            execute_non_query("
                INSERT INTO tb_m_employee_salary (id_employee, basic_salary, allow_job, allow_meal, allow_trans, allow_house, allow_car, effective_date)
                SELECT id_employee, basic_salary, allow_job, allow_meal, allow_trans, allow_house, allow_car, effective_date 
                FROM tb_employee_sal_pps_det AS pps_det
                LEFT JOIN tb_employee_sal_pps AS pps ON pps_det.id_employee_sal_pps = pps.id_employee_sal_pps 
                WHERE pps.id_employee_sal_pps = " + id_employee_sal_pps + " AND id_employee = " + id_employee + "
            ", True, "", "", "", "")
        Next
    End Sub

    Sub remove_employee()
        Dim confirm As DialogResult

        confirm = DevExpress.XtraEditors.XtraMessageBox.Show("Are you sure want to remove selected employee?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)

        If confirm = Windows.Forms.DialogResult.Yes Then
            GVEmployee.DeleteSelectedRows()
        End If
    End Sub

    Private Sub SBInsertEmployee_Click(sender As Object, e As EventArgs) Handles SBInsertEmployee.Click
        'check included employee
        Dim not_included As String = ""

        For i = 0 To GVEmployee.RowCount - 1
            If GVEmployee.IsValidRowHandle(i) Then
                not_included += GVEmployee.GetRowCellValue(i, "id_employee").ToString + ", "
            End If
        Next

        If Not not_included = "" Then
            not_included = not_included.Substring(0, not_included.Length - 2)
        End If

        'form pick employee
        FormProposeEmpSalaryPick.id_sal_pps_type = LUEType.EditValue.ToString
        FormProposeEmpSalaryPick.not_included = not_included

        FormProposeEmpSalaryPick.ShowDialog()
    End Sub

    Private Sub SBRemoveEmployee_Click(sender As Object, e As EventArgs) Handles SBRemoveEmployee.Click
        remove_employee()
    End Sub

    Private Sub SBSubmit_Click(sender As Object, e As EventArgs) Handles SBSubmit.Click
        GVEmployee.ApplyFindFilter("")

        If GVEmployee.RowCount = 0 Then
            errorCustom("No employee inserted.")
        Else
            Dim confirm As DialogResult

            confirm = DevExpress.XtraEditors.XtraMessageBox.Show("Are you sure want to submit propose employee salary?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)

            If confirm = Windows.Forms.DialogResult.Yes Then
                save("submit")

                Close()
            End If
        End If
    End Sub

    Private Sub SBSave_Click(sender As Object, e As EventArgs) Handles SBSave.Click
        GVEmployee.ApplyFindFilter("")

        save("save")

        Close()
    End Sub

    Private Sub SBClose_Click(sender As Object, e As EventArgs) Handles SBClose.Click
        Close()
    End Sub

    Private Sub SBPrint_Click(sender As Object, e As EventArgs) Handles SBPrint.Click
        Dim id_report_status As String = execute_query("SELECT id_report_status FROM tb_employee_sal_pps WHERE id_employee_sal_pps = " + id_employee_sal_pps + "", 0, True, "", "", "", "")

        Dim report As ReportProposeEmpSalary = New ReportProposeEmpSalary

        report.id_employee_sal_pps = id_employee_sal_pps
        report.data = GCEmployee.DataSource
        report.is_pre = If(id_report_status = "6", "-1", "1")
        report.type = LUEType.EditValue.ToString
        report.category = LUECategory.EditValue.ToString

        report.XLNumber.Text = TENumber.Text
        report.XLEffectiveDate.Text = DEEffectiveDate.Text
        report.XLType.Text = LUEType.Text
        report.XLNote.Text = MENote.Text

        Dim Tool As DevExpress.XtraReports.UI.ReportPrintTool = New DevExpress.XtraReports.UI.ReportPrintTool(report)

        Tool.ShowPreviewDialog()
    End Sub

    Private Sub SBMark_Click(sender As Object, e As EventArgs) Handles SBMark.Click
        Cursor = Cursors.WaitCursor

        FormReportMark.report_mark_type = If(LUECategory.EditValue.ToString = "1", "197", "229")
        FormReportMark.id_report = id_employee_sal_pps

        FormReportMark.ShowDialog()

        Cursor = Cursors.Default
    End Sub

    Private Sub RemoveEmployeeToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RemoveEmployeeToolStripMenuItem.Click
        remove_employee()
    End Sub

    Private Sub RITESalary_EditValueChanged(sender As Object, e As EventArgs) Handles RITESalary.EditValueChanged
        GCEmployee.Refresh()
    End Sub

    Private Sub LUEType_EditValueChanged(sender As Object, e As EventArgs) Handles LUEType.EditValueChanged
        'reset datasource
        Dim query As String = "
            SELECT det.id_employee, emp.employee_code, emp.employee_name, det.id_departement, dp.departement, dp.total_workdays, det.employee_position, '' AS tmp_length_work, '' AS length_work, det.id_employee_level, lv.employee_level, det.id_employee_status, sts.employee_status, IFNULL(det.id_employee_salary, 0) AS id_employee_salary, ROUND(IFNULL(sal.basic_salary, 0), 0) AS basic_salary_current, ROUND(IFNULL(sal.allow_job, 0), 0) AS allow_job_current, ROUND(IFNULL(sal.allow_meal, 0), 0) AS allow_meal_current, ROUND(IFNULL(sal.allow_trans, 0), 0) AS allow_trans_current, ROUND(IFNULL(sal.allow_house, 0), 0) AS allow_house_current, ROUND(IFNULL(sal.allow_car, 0), 0) AS allow_car_current, ((SELECT basic_salary_current) + (SELECT allow_job_current) + (SELECT allow_meal_current) + (SELECT allow_trans_current) + (SELECT allow_house_current) + (SELECT allow_car_current)) AS total_salary_current, ROUND(IFNULL(det.basic_salary, 0), 0) AS basic_salary, ROUND(det.allow_job, 0) AS allow_job, ROUND(det.allow_meal, 0) AS allow_meal, ROUND(det.allow_trans, 0) AS allow_trans, ROUND(det.allow_house, 0) AS allow_house, ROUND(det.allow_car, 0) AS allow_car, '-100.00%' AS increase, CONCAT(ROUND(((ROUND(det.basic_salary, 0) + ROUND(det.allow_job, 0) + ROUND(det.allow_meal, 0) + ROUND(det.allow_trans, 0)) / (ROUND(det.basic_salary, 0) + ROUND(det.allow_job, 0) + ROUND(det.allow_meal, 0) + ROUND(det.allow_trans, 0) + ROUND(det.allow_house, 0) + ROUND(det.allow_car, 0)) * 100), 2), '%') AS fixed_salary, CONCAT(ROUND(((ROUND(det.allow_house, 0) + ROUND(det.allow_car, 0)) / (ROUND(det.basic_salary, 0) + ROUND(det.allow_job, 0) + ROUND(det.allow_meal, 0) + ROUND(det.allow_trans, 0) + ROUND(det.allow_house, 0) + ROUND(det.allow_car, 0)) * 100), 2), '%') AS non_fixed_salary, det.id_employee_status_det, '' AS reason
            FROM tb_employee_sal_pps_det AS det
            LEFT JOIN tb_m_employee AS emp ON det.id_employee = emp.id_employee
            LEFT JOIN tb_m_departement AS dp ON det.id_departement = dp.id_departement
            LEFT JOIN tb_lookup_employee_level AS lv ON det.id_employee_level = lv.id_employee_level
            LEFT JOIN tb_lookup_employee_status AS sts ON det.id_employee_status = sts.id_employee_status
            LEFT JOIN tb_m_employee_salary AS sal ON det.id_employee_salary = sal.id_employee_salary
            WHERE det.id_employee_sal_pps = -1
            ORDER BY det.id_employee_level ASC, emp.employee_code ASC
        "

        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")

        GCEmployee.DataSource = data

        'hide/show column
        If LUEType.EditValue.ToString = "1" Then
            GCBasicSalary.Caption = "Basic Salary"

            GCJobAllowance.VisibleIndex = 1
            GCMealAllowance.VisibleIndex = 2
            GCTransportAllowance.VisibleIndex = 3
            GCHouseAllowance.VisibleIndex = 4
            GCAttendanceAllowance.VisibleIndex = 5
            GCTotalSalary.VisibleIndex = 6

            GCBasicSalaryCurrent.Caption = "Basic Salary"

            GCJobAllowanceCurrent.VisibleIndex = 1
            GCMealAllowanceCurrent.VisibleIndex = 2
            GCTransportAllowanceCurrent.VisibleIndex = 3
            GCHouseAllowanceCurrent.VisibleIndex = 4
            GCAttendanceAllowanceCurrent.VisibleIndex = 5
            GCTotalSalaryCurrent.VisibleIndex = 6

            GBComposition.Visible = True
        ElseIf LUEType.EditValue.ToString = "2" Then
            GCBasicSalary.Caption = "Daily Salary"

            GCJobAllowance.VisibleIndex = -1
            GCMealAllowance.VisibleIndex = -1
            GCTransportAllowance.VisibleIndex = -1
            GCHouseAllowance.VisibleIndex = -1
            GCAttendanceAllowance.VisibleIndex = -1
            GCTotalSalary.VisibleIndex = -1

            GCBasicSalaryCurrent.Caption = "Daily Salary"

            GCJobAllowanceCurrent.VisibleIndex = -1
            GCMealAllowanceCurrent.VisibleIndex = -1
            GCTransportAllowanceCurrent.VisibleIndex = -1
            GCHouseAllowanceCurrent.VisibleIndex = -1
            GCAttendanceAllowanceCurrent.VisibleIndex = -1
            GCTotalSalaryCurrent.VisibleIndex = -1

            GBComposition.Visible = False
        End If

        GVEmployee.BestFitColumns()

        If LUEType.EditValue.ToString = "2" Then
            GCIncreaseRp.UnboundExpression = "[basic_salary] - [basic_salary_current]"
        Else
            GCIncreaseRp.UnboundExpression = "[total_salary] - [total_salary_current]"
        End If
    End Sub

    Private Sub RepositoryItemCheckEdit_Click(sender As Object, e As EventArgs) Handles RepositoryItemCheckEdit.Click
        FormProposeEmpSalaryAtt.id_employee_status_det = GVEmployee.GetFocusedRowCellValue("id_employee_status_det").ToString

        FormProposeEmpSalaryAtt.ShowDialog()
    End Sub

    Private Sub GVEmployee_CellValueChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles GVEmployee.CellValueChanged
        If e.Column.FieldName.ToString = "basic_salary" Or e.Column.FieldName.ToString = "allow_job" Or e.Column.FieldName.ToString = "allow_meal" Or e.Column.FieldName.ToString = "allow_trans" Or e.Column.FieldName.ToString = "allow_house" Or e.Column.FieldName.ToString = "allow_car" Then
            'calculate composition & increase
            Dim i As Integer = e.RowHandle

            'composition
            calculate_composition(i)

            'increase
            calculate_increase(i)
        End If

        If e.Column.FieldName.ToString = "id_employee_status_det" Then
            GVEmployee.BestFitColumns()
        End If
    End Sub

    Sub calculate_composition(ByVal i As Integer)
        Try
            Dim fixed_salary As Decimal = (GVEmployee.GetRowCellValue(i, "basic_salary") + GVEmployee.GetRowCellValue(i, "allow_job") + GVEmployee.GetRowCellValue(i, "allow_meal") + GVEmployee.GetRowCellValue(i, "allow_trans")) / (GVEmployee.GetRowCellValue(i, "basic_salary") + GVEmployee.GetRowCellValue(i, "allow_job") + GVEmployee.GetRowCellValue(i, "allow_meal") + GVEmployee.GetRowCellValue(i, "allow_trans") + GVEmployee.GetRowCellValue(i, "allow_house") + GVEmployee.GetRowCellValue(i, "allow_car")) * 100
            Dim non_fixed_salary As Decimal = (GVEmployee.GetRowCellValue(i, "allow_house") + GVEmployee.GetRowCellValue(i, "allow_car")) / (GVEmployee.GetRowCellValue(i, "basic_salary") + GVEmployee.GetRowCellValue(i, "allow_job") + GVEmployee.GetRowCellValue(i, "allow_meal") + GVEmployee.GetRowCellValue(i, "allow_trans") + GVEmployee.GetRowCellValue(i, "allow_house") + GVEmployee.GetRowCellValue(i, "allow_car")) * 100

            GVEmployee.SetRowCellValue(i, "fixed_salary", Math.Round(fixed_salary, 2).ToString + "%")
            GVEmployee.SetRowCellValue(i, "non_fixed_salary", Math.Round(non_fixed_salary, 2).ToString + "%")
        Catch ex As Exception
            GVEmployee.SetRowCellValue(i, "fixed_salary", "50.00%")
            GVEmployee.SetRowCellValue(i, "non_fixed_salary", "50.00%")
        End Try
    End Sub

    Sub calculate_increase(ByVal i As Integer)
        Try
            Dim increase As Decimal = 0.00

            If LUEType.EditValue.ToString = "1" Then
                increase = ((GVEmployee.GetRowCellValue(i, "basic_salary") + GVEmployee.GetRowCellValue(i, "allow_job") + GVEmployee.GetRowCellValue(i, "allow_meal") + GVEmployee.GetRowCellValue(i, "allow_trans") + GVEmployee.GetRowCellValue(i, "allow_house") + GVEmployee.GetRowCellValue(i, "allow_car")) - GVEmployee.GetRowCellValue(i, "total_salary_current")) / GVEmployee.GetRowCellValue(i, "total_salary_current") * 100
            Else
                increase = ((GVEmployee.GetRowCellValue(i, "basic_salary") + GVEmployee.GetRowCellValue(i, "allow_job") + GVEmployee.GetRowCellValue(i, "allow_meal") + GVEmployee.GetRowCellValue(i, "allow_trans") + GVEmployee.GetRowCellValue(i, "allow_house") + GVEmployee.GetRowCellValue(i, "allow_car")) - GVEmployee.GetRowCellValue(i, "basic_salary_current")) / GVEmployee.GetRowCellValue(i, "basic_salary_current") * 100
            End If

            GVEmployee.SetRowCellValue(i, "increase", Math.Round(increase, 2).ToString + "%")
        Catch ex As Exception
            Dim total As Decimal = GVEmployee.GetRowCellValue(i, "basic_salary") + GVEmployee.GetRowCellValue(i, "allow_job") + GVEmployee.GetRowCellValue(i, "allow_meal") + GVEmployee.GetRowCellValue(i, "allow_trans") + GVEmployee.GetRowCellValue(i, "allow_house") + GVEmployee.GetRowCellValue(i, "allow_car")

            If total = 0 Then
                GVEmployee.SetRowCellValue(i, "increase", "0.00%")
            Else
                GVEmployee.SetRowCellValue(i, "increase", "100.00%")
            End If
        End Try
    End Sub

    Private clone As DataView = Nothing

    Private Sub GVEmployee_ShownEditor(sender As Object, e As EventArgs) Handles GVEmployee.ShownEditor
        Dim view As DevExpress.XtraGrid.Views.Grid.GridView = CType(sender, DevExpress.XtraGrid.Views.Grid.GridView)

        If view.FocusedColumn.FieldName = "id_employee_status_det" AndAlso TypeOf view.ActiveEditor Is DevExpress.XtraEditors.SearchLookUpEdit Then
            Dim edit As DevExpress.XtraEditors.SearchLookUpEdit
            Dim table As DataTable
            Dim row As DataRow

            edit = CType(view.ActiveEditor, DevExpress.XtraEditors.SearchLookUpEdit)

            Try
                table = CType(edit.Properties.DataSource, DataTable)
            Catch ex As Exception
                table = CType(edit.Properties.DataSource, DataView).Table
            End Try

            clone = New DataView(table)

            row = view.GetDataRow(view.FocusedRowHandle)

            clone.RowFilter = "[id_employee] = " + view.GetFocusedRowCellValue("id_employee").ToString + "OR [id_employee] = 0"

            edit.Properties.DataSource = clone
        End If
    End Sub

    Private Sub LUECategory_EditValueChanged(sender As Object, e As EventArgs) Handles LUECategory.EditValueChanged
        If LUECategory.EditValue.ToString = "1" Then
            GBSalary.Caption = "Salary"

            GBSalaryCurrent.Visible = False
            GBIncrease.Visible = False

            GBContract.Visible = True

            GBNote.Visible = False
        ElseIf LUECategory.EditValue.ToString = "2" Then
            GBSalary.Caption = "Salary Propose"

            GBSalaryCurrent.Visible = True
            GBIncrease.Visible = True

            GBContract.Visible = False

            GBNote.Visible = True
        End If

        GVEmployee.BestFitColumns()
    End Sub

    Private Sub SBAttachment_Click(sender As Object, e As EventArgs) Handles SBAttachment.Click
        Cursor = Cursors.WaitCursor
        FormDocumentUpload.is_no_delete = "1"
        FormDocumentUpload.id_report = id_employee_sal_pps
        FormDocumentUpload.report_mark_type = If(LUECategory.EditValue.ToString = "1", "197", "229")
        FormDocumentUpload.ShowDialog()
        Cursor = Cursors.Default
    End Sub

    Sub update_current()
        For i = 0 To GVEmployee.RowCount - 1
            If GVEmployee.IsValidRowHandle(i) Then
                Dim salary_min_basic As Integer = GVEmployee.GetRowCellValue(i, "allow_job_current") + GVEmployee.GetRowCellValue(i, "allow_meal_current") + GVEmployee.GetRowCellValue(i, "allow_trans_current") + GVEmployee.GetRowCellValue(i, "allow_house_current") + GVEmployee.GetRowCellValue(i, "allow_car_current")

                If LUEType.EditValue.ToString = "1" Then
                    If salary_min_basic = 0 Then
                        GVEmployee.SetRowCellValue(i, "total_salary_current", GVEmployee.GetRowCellValue(i, "basic_salary_current") * GVEmployee.GetRowCellValue(i, "total_workdays"))

                        calculate_increase(i)
                    End If
                Else
                    If salary_min_basic > 0 Then
                        GVEmployee.SetRowCellValue(i, "basic_salary_current", GVEmployee.GetRowCellValue(i, "total_salary_current") / GVEmployee.GetRowCellValue(i, "total_workdays"))

                        calculate_increase(i)
                    End If
                End If
            End If
        Next
    End Sub

    Private Sub GVEmployee_CustomSummaryCalculate(sender As Object, e As DevExpress.Data.CustomSummaryEventArgs) Handles GVEmployee.CustomSummaryCalculate
        Dim item As DevExpress.XtraGrid.GridSummaryItem = TryCast(e.Item, DevExpress.XtraGrid.GridSummaryItem)

        If item.FieldName.ToString = "increase" Then
            Select Case e.SummaryProcess
                Case DevExpress.Data.CustomSummaryProcess.Finalize
                    Dim percentage As Decimal = 0.00

                    Try
                        If e.IsGroupSummary Then
                            If LUEType.EditValue.ToString = "2" Then
                                percentage = e.GetGroupSummary(e.GroupRowHandle, GVEmployee.GroupSummary.Item(14)) / e.GetGroupSummary(e.GroupRowHandle, GVEmployee.GroupSummary.Item(7)) * 100
                            Else
                                percentage = e.GetGroupSummary(e.GroupRowHandle, GVEmployee.GroupSummary.Item(14)) / e.GetGroupSummary(e.GroupRowHandle, GVEmployee.GroupSummary.Item(13)) * 100
                            End If

                            Dim percentage_str As String = Decimal.Round(percentage, 2).ToString.Replace(",", ".")

                            e.TotalValue = percentage_str + If(Not percentage_str.Contains("."), ".00", "") + "%"
                        ElseIf e.IsTotalSummary Then
                            If LUEType.EditValue.ToString = "2" Then
                                percentage = (GVEmployee.Columns("basic_salary").SummaryItem.SummaryValue - GVEmployee.Columns("basic_salary_current").SummaryItem.SummaryValue) / GVEmployee.Columns("basic_salary_current").SummaryItem.SummaryValue * 100
                            Else
                                percentage = (GVEmployee.Columns("total_salary").SummaryItem.SummaryValue - GVEmployee.Columns("total_salary_current").SummaryItem.SummaryValue) / GVEmployee.Columns("total_salary_current").SummaryItem.SummaryValue * 100
                            End If

                            Dim percentage_str As String = Decimal.Round(percentage, 2).ToString.Replace(",", ".")

                            e.TotalValue = percentage_str + If(Not percentage_str.Contains("."), ".00", "") + "%"
                        End If
                    Catch ex As Exception
                    End Try
            End Select
        End If
    End Sub
End Class