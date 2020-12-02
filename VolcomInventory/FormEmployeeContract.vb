Public Class FormEmployeeContract
    Private Sub FormEmployeeContract_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        form_load()
    End Sub

    Private Sub FormEmployeeContract_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub FormEmployeeContract_Activated(sender As Object, e As EventArgs) Handles MyBase.Activated
        FormMain.show_rb(Name)
        checkFormAccess(Name)
    End Sub

    Private Sub FormEmployeeContract_Deactivate(sender As Object, e As EventArgs) Handles MyBase.Deactivate
        FormMain.hide_rb()
    End Sub

    Sub form_load()
        Dim query As String = "
            SELECT c.id_emp_contract, c.id_contract_type, c.employee_name, IF(c.id_departement = 17, CONCAT(d.departement, '-', s.departement_sub), d.departement) AS departement, c.number, c.start_period, c.end_period, c.created_at, e.employee_name AS created_by, l.contract_type
            FROM tb_emp_contract AS c
            LEFT JOIN tb_lookup_contract_type AS l ON c.id_contract_type = l.id_contract_type
            LEFT JOIN tb_m_employee AS e ON c.created_by = e.id_employee
            LEFT JOIN tb_m_departement AS d ON c.id_departement = d.id_departement
            LEFT JOIN tb_m_departement_sub AS s ON c.id_departement_sub = s.id_departement_sub
            ORDER BY c.id_emp_contract DESC
        "

        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")

        GCEmployeeContract.DataSource = data

        GVEmployeeContract.BestFitColumns()
    End Sub

    Sub print(id_emp_contract As String)
        Dim report As ReportEmployeeContract = New ReportEmployeeContract

        Dim director As DataTable = execute_query("
            SELECT tb_m_employee.employee_name AS director_name, tb_m_employee.employee_position AS director_position
            FROM tb_m_employee 
            WHERE tb_m_employee.id_employee = (SELECT id_emp_director FROM tb_opt LIMIT 1)
        ", -1, True, "", "", "", "")

        Dim vice_director As DataTable = execute_query("
            SELECT tb_m_employee.employee_name AS director_name, tb_m_employee.employee_position AS director_position
            FROM tb_m_employee 
            WHERE tb_m_employee.id_employee = (SELECT id_emp_vice_director FROM tb_opt LIMIT 1)
        ", -1, True, "", "", "", "")

        Dim hrd_manager As DataTable = execute_query("
            SELECT tb_m_employee.employee_name AS hrd_manager_name, tb_m_employee.employee_position AS hrd_manager_position
            FROM tb_m_departement 
            LEFT JOIN tb_m_user ON tb_m_departement.id_user_head = tb_m_user.id_user 
            LEFT JOIN tb_m_employee ON tb_m_user.id_employee = tb_m_employee.id_employee
            WHERE tb_m_departement.id_departement = 8
        ", -1, True, "", "", "", "")

        Dim data As DataTable = execute_query("
            SELECT c.number, c.employee_name, c.employee_position, c.employee_code, c.employee_ktp, c.address_primary, IF(c.id_departement = 17, s.departement_sub, d.departement) AS departement, IF(d.is_store = 1, '7 (tujuh) jam', '8 (delapan) jam') AS working_hours, c.basic_salary, c.allow_job, c.allow_meal, c.allow_trans, c.allow_house, c.allow_car, (c.basic_salary + c.allow_job + c.allow_meal + c.allow_trans + c.allow_house + c.allow_car) AS total_salary, IFNULL((FLOOR((TIMESTAMPDIFF(DAY, c.start_period, c.end_period)) / 30)), 0) AS length_contract, DATE_FORMAT(c.start_period, '%d %M %Y') AS start_period, DATE_FORMAT(c.end_period, '%d %M %Y') AS end_period, DATE_FORMAT(c.created_at, '%d %M %Y') AS created_at, IF((SELECT list_departement_include_missing FROM tb_emp_contract_template WHERE id_contract_type = c.id_contract_type) LIKE CONCAT('%[', c.id_departement, ']%'), 1, 2) AS include_missing
            FROM tb_emp_contract AS c
            LEFT JOIN tb_m_departement AS d ON c.id_departement = d.id_departement
            LEFT JOIN tb_m_departement_sub AS s ON c.id_departement_sub = s.id_departement_sub
            WHERE c.id_emp_contract = " + id_emp_contract + "
        ", -1, True, "", "", "", "")

        Dim data_template As DataTable = execute_query("SELECT template, template_include_missing, template_salary_list, template_salary_type FROM tb_emp_contract_template WHERE id_contract_type = (SELECT id_contract_type FROM tb_emp_contract WHERE id_emp_contract = " + id_emp_contract + ")", -1, True, "", "", "", "")

        Dim template As String = data_template.Rows(0)("template").ToString
        Dim template_include_missing As String = data_template.Rows(0)("template_include_missing").ToString
        Dim template_salary_list As String = data_template.Rows(0)("template_salary_list").ToString
        Dim template_salary_type As String = data_template.Rows(0)("template_salary_type").ToString

        'length contract
        Dim length_contract As String = ""

        If data.Rows(0)("length_contract") > 0 Then
            If data.Rows(0)("length_contract") < 12 Then
                length_contract = data.Rows(0)("length_contract").ToString + " (" + execute_query("SELECT `string` FROM tb_lookup_number_to_string WHERE `number` = " + data.Rows(0)("length_contract").ToString, 0, True, "", "", "", "") + ") bulan"
            Else
                Dim yr As String = Math.Round(data.Rows(0)("length_contract") / 12, 0).ToString
                Dim mr As String = (data.Rows(0)("length_contract") Mod 12).ToString

                length_contract = yr + " (" + execute_query("SELECT `string` FROM tb_lookup_number_to_string WHERE `number` = " + yr, 0, True, "", "", "", "") + ") tahun"

                If mr > 0 Then
                    length_contract += " " + mr + " (" + execute_query("SELECT `string` FROM tb_lookup_number_to_string WHERE `number` = " + mr, 0, True, "", "", "", "") + ") bulan"
                End If
            End If
        End If

        'salary detail
        Dim salary_detail As String = ""

        If data.Rows(0)("basic_salary") > 0 Then
            salary_detail += "Gaji pokok Rp. " + Format(data.Rows(0)("basic_salary"), "##,##0") + ",-, "
        End If

        If data.Rows(0)("allow_job") > 0 Then
            salary_detail += "Tunjangan jabatan Rp. " + Format(data.Rows(0)("allow_job"), "##,##0") + ",-, "
        End If

        If data.Rows(0)("allow_meal") > 0 Then
            salary_detail += "Uang makan Rp. " + Format(data.Rows(0)("allow_meal"), "##,##0") + ",-, "
        End If

        If data.Rows(0)("allow_trans") > 0 Then
            salary_detail += "Uang transport Rp. " + Format(data.Rows(0)("allow_trans"), "##,##0") + ",-, "
        End If

        If data.Rows(0)("allow_house") > 0 Then
            salary_detail += "Uang perumahan Rp. " + Format(data.Rows(0)("allow_house"), "##,##0") + ",-, "
        End If

        If data.Rows(0)("allow_car") > 0 Then
            salary_detail += "Uang kehadiran Rp. " + Format(data.Rows(0)("allow_car"), "##,##0") + ",-"
        End If

        'salary list
        Dim salary_list As String = ""

        If data.Rows(0)("basic_salary") > 0 Then
            salary_list += template_salary_list.Replace("[colspan]", "colspan=""2""").Replace("[list_name]", "Gaji Pokok").Replace("[list_total]", Format(data.Rows(0)("basic_salary"), "##,##0")).Replace("[list_type]", "")
        End If

        If data.Rows(0)("allow_job") > 0 Then
            salary_list += template_salary_list.Replace("[colspan]", "").Replace("[list_name]", "Tunj. Jabatan").Replace("[list_total]", Format(data.Rows(0)("allow_job"), "##,##0")).Replace("[list_type]", template_salary_type.Replace("[salary_type]", "Tunj. Tetap"))
        End If

        If data.Rows(0)("allow_meal") > 0 Then
            Dim text_allow_meal As String = ""

            If data.Rows(0)("allow_job") > 0 Then
                text_allow_meal = template_salary_list.Replace("[colspan]", "").Replace("[list_name]", "Uang Makan").Replace("[list_total]", Format(data.Rows(0)("allow_meal"), "##,##0")).Replace("[list_type]", "<td></td>")
            Else
                text_allow_meal = template_salary_list.Replace("[colspan]", "").Replace("[list_name]", "Uang Makan").Replace("[list_total]", Format(data.Rows(0)("allow_meal"), "##,##0")).Replace("[list_type]", template_salary_type.Replace("[salary_type]", "Tunj. Tetap"))
            End If

            salary_list += text_allow_meal
        End If

        If data.Rows(0)("allow_trans") > 0 Then
            Dim text_allow_trans As String = ""

            If data.Rows(0)("allow_job") > 0 Or data.Rows(0)("allow_meal") > 0 Then
                text_allow_trans = template_salary_list.Replace("[colspan]", "").Replace("[list_name]", "Uang Transport").Replace("[list_total]", Format(data.Rows(0)("allow_trans"), "##,##0")).Replace("[list_type]", "<td></td>")
            Else
                text_allow_trans = template_salary_list.Replace("[colspan]", "").Replace("[list_name]", "Uang Transport").Replace("[list_total]", Format(data.Rows(0)("allow_trans"), "##,##0")).Replace("[list_type]", template_salary_type.Replace("[salary_type]", "Tunj. Tetap"))
            End If

            salary_list += text_allow_trans
        End If

        If data.Rows(0)("allow_house") > 0 Then
            salary_list += template_salary_list.Replace("[colspan]", "").Replace("[list_name]", "Uang Perumahan").Replace("[list_total]", Format(data.Rows(0)("allow_house"), "##,##0")).Replace("[list_type]", template_salary_type.Replace("[salary_type]", "Tunj. Tidak Tetap"))
        End If

        If data.Rows(0)("allow_car") > 0 Then
            Dim text_allow_car As String = ""

            If data.Rows(0)("allow_house") > 0 Then
                text_allow_car = template_salary_list.Replace("[colspan]", "").Replace("[list_name]", "Uang Kehadiran").Replace("[list_total]", Format(data.Rows(0)("allow_car"), "##,##0")).Replace("[list_type]", "<td></td>")
            Else
                text_allow_car = template_salary_list.Replace("[colspan]", "").Replace("[list_name]", "Uang Kehadiran").Replace("[list_total]", Format(data.Rows(0)("allow_car"), "##,##0")).Replace("[list_type]", template_salary_type.Replace("[salary_type]", "Tunj. Tidak Tetap"))
            End If

            salary_list += text_allow_car
        End If

        'include missing
        Dim include_missing As String = ""

        If data.Rows(0)("include_missing").ToString = "1" Then
            include_missing = template_include_missing
        End If

        template = template.Replace("[number]", data.Rows(0)("number").ToString)
        template = template.Replace("[hrd_manager_name]", hrd_manager.Rows(0)("hrd_manager_name").ToString)
        template = template.Replace("[hrd_manager_position]", hrd_manager.Rows(0)("hrd_manager_position").ToString)
        template = template.Replace("[director_name]", director.Rows(0)("director_name").ToString)
        template = template.Replace("[vice_director_name]", vice_director.Rows(0)("director_name").ToString)
        template = template.Replace("[director_position]", director.Rows(0)("director_position").ToString)
        template = template.Replace("[employee_name]", data.Rows(0)("employee_name").ToString)
        template = template.Replace("[address_primary]", data.Rows(0)("address_primary").ToString)
        template = template.Replace("[employee_position]", data.Rows(0)("employee_position").ToString)
        template = template.Replace("[employee_code]", data.Rows(0)("employee_code").ToString)
        template = template.Replace("[employee_ktp]", data.Rows(0)("employee_ktp").ToString)
        template = template.Replace("[departement]", data.Rows(0)("departement").ToString)
        template = template.Replace("[working_hours]", data.Rows(0)("working_hours").ToString)
        template = template.Replace("[total_salary]", Format(data.Rows(0)("total_salary"), "##,##0"))
        template = template.Replace("[salary_detail]", salary_detail)
        template = template.Replace("[salary_list]", salary_list)
        template = template.Replace("[length_contract]", length_contract)
        template = template.Replace("[start_period]", data.Rows(0)("start_period").ToString)
        template = template.Replace("[end_period]", data.Rows(0)("end_period").ToString)
        template = template.Replace("[include_missing]", include_missing)
        template = template.Replace("[created_at]", data.Rows(0)("created_at").ToString)

        report.XrRichText.Html = template

        Dim Tool As DevExpress.XtraReports.UI.ReportPrintTool = New DevExpress.XtraReports.UI.ReportPrintTool(report)

        Tool.ShowPreviewDialog()
    End Sub

    Private Sub PrintToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PrintToolStripMenuItem.Click
        print(GVEmployeeContract.GetFocusedRowCellValue("id_emp_contract").ToString)
    End Sub
End Class