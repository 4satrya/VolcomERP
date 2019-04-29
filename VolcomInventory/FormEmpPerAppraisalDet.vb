Public Class FormEmpPerAppraisalDet
    Public is_dephead As String = "-1"
    Public is_hrd As String = "-1"

    Public id_employee As Integer = 0

    Public grup_penilaian As Integer = 0

    Public id_question_period As Integer = 0
    Public id_question_status As Integer = 0

    Public id_question_gen_res As Integer = 0
    Public id_question_pri_res As Integer = 0

    Public employee_head_name As String = ""

    Public appraiser_check As Integer = 0
    Public appraiser_check_date As String = ""
    Public hrd_check As Integer = 0
    Public hrd_check_date As String = ""

    Public row_result As Integer = 0
    Public sum_height As Integer = 0

    Sub load_question()
        Dim query As String = ""

        If id_question_period Then
            query = "
                SELECT 0 no, qg.id_question_gen_app, qg.question, CONCAT('(', qg.question_detail, ')') question_detail, qg.id_question_gen_app_group, CONCAT(qg.id_question_gen_app_group, '. ', qgg.group_name, ' (Bobot ', qgg.group_weight, '%)') group_name, qgg.group_weight, IFNULL(qgr.id_question_gen_app_res, 0) id_question_gen_app_res, IFNULL(qgr.value, 0) value, IFNULL(qgr.information, '') information
                FROM tb_question_gen_app qg
                LEFT JOIN tb_question_gen_app_group qgg ON qg.id_question_gen_app_group = qgg.id_question_gen_app_group
                LEFT JOIN tb_question_gen_app_res qgr ON qg.id_question_gen_app = qgr.id_question_gen_app
                WHERE qgr.id_question_period = " + id_question_period.ToString + "
                ORDER BY qg.id_question_gen_app_group ASC
            "
        Else
            query = "
                SELECT 0 no, qg.id_question_gen_app, qg.question, CONCAT('(', qg.question_detail, ')') question_detail, qg.id_question_gen_app_group, CONCAT(qg.id_question_gen_app_group, '. ', qgg.group_name, ' (Bobot ', qgg.group_weight, '%)') group_name, qgg.group_weight, 0 id_question_gen_app_res, 0 value, '' information
                FROM tb_question_gen_app qg
                LEFT JOIN tb_question_gen_app_group qgg ON qg.id_question_gen_app_group = qgg.id_question_gen_app_group
                WHERE qg.grup_penilaian <= '" + grup_penilaian.ToString + "'
                ORDER BY qg.id_question_gen_app_group ASC
            "
        End If

        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")

        GCListQuestion.DataSource = data
        GVListQuestion.BestFitColumns()

        Dim query_value As String = "SELECT value FROM tb_lookup_question_value"

        viewLookupRepositoryQuery(LUEValue, query_value, 0, "value", "value")
    End Sub

    Sub load_conclusion()
        Dim query As String = ""

        'gen
        If id_question_period Then
            query = "
                SELECT 0 no, qc.id_question_gen_con, qc.question, IFNULL(qcr.id_question_gen_con_res, 0) id_question_gen_con_res, IFNULL(qcr.conclusion, '') conclusion
                FROM tb_question_gen_con qc
                LEFT JOIN tb_question_gen_con_res qcr ON qc.id_question_gen_con = qcr.id_question_gen_con
                WHERE qcr.id_question_period = " + id_question_period.ToString + "
            "
        Else
            query = "
                SELECT 0 no, qc.id_question_gen_con, qc.question, 0 id_question_gen_con_res, '' conclusion 
                FROM tb_question_gen_con qc
            "
        End If

        Dim data_gen As DataTable = execute_query(query, -1, True, "", "", "", "")

        GCConclusion.DataSource = data_gen
        GVConclusion.BestFitColumns()

        'pri
        If id_question_period Then
            query = "
                SELECT 0 no, qc.id_question_pri_con, qc.question, IFNULL(qcr.id_question_pri_con_res, 0) id_question_pri_con_res, IFNULL(qcr.conclusion, '') conclusion
                FROM tb_question_pri_con qc
                LEFT JOIN tb_question_pri_con_res qcr ON qc.id_question_pri_con = qcr.id_question_pri_con
                WHERE qcr.id_question_period = " + id_question_period.ToString + "
            "
        Else
            query = "
                SELECT 0 no, qc.id_question_pri_con, qc.question, 0 id_question_pri_con_res, '' conclusion 
                FROM tb_question_pri_con qc
            "
        End If

        Dim data_pri As DataTable = execute_query(query, -1, True, "", "", "", "")

        GCComment.DataSource = data_pri
        GVComment.BestFitColumns()
    End Sub

    Sub load_result()
        Dim query As String = ""

        'recommendation lookup
        query = "
                SELECT lqr.id_result, lqr.result, lqr.information
                FROM tb_lookup_question_result lqr
            "

        ''gen
        viewSearchLookupQuery(SLUERec, query, "id_result", "result", "id_result")

        ''pri
        viewSearchLookupQuery(SLUERecPri, query, "id_result", "result", "id_result")

        'result
        ''gen
        query = "
                SELECT qgr.id_question_gen_res, qgr.id_result, lqr.information, qgr.result_information, qgr.employee_note, qgr.hrd_note
                FROM tb_question_gen_res qgr
                LEFT JOIN tb_lookup_question_result lqr ON qgr.id_result = lqr.id_result
                WHERE qgr.id_question_period = " + id_question_period.ToString + "
            "
        Dim data_gen As DataTable = execute_query(query, -1, True, "", "", "", "")

        ''pri
        query = "
                SELECT qpr.id_question_pri_res, qpr.id_result, lqr.information, qpr.result_information, qpr.hrd_note
                FROM tb_question_pri_res qpr
                LEFT JOIN tb_lookup_question_result lqr ON qpr.id_result = lqr.id_result
                WHERE qpr.id_question_period = " + id_question_period.ToString + "
            "
        Dim data_pri As DataTable = execute_query(query, -1, True, "", "", "", "")

        If id_question_period Then
            ''gen
            id_question_gen_res = data_gen.Rows(0)("id_question_gen_res")

            MEEmployeeNote.EditValue = data_gen.Rows(0)("employee_note")
            MEHRDNote.EditValue = data_gen.Rows(0)("hrd_note")

            ''pri
            id_question_pri_res = data_pri.Rows(0)("id_question_pri_res")

            MEHRDNotePri.EditValue = data_pri.Rows(0)("hrd_note")
        End If

        If id_question_period Then
            ''gen
            SLUERec.EditValue = data_gen.Rows(0)("id_result")
            TERec.EditValue = data_gen.Rows(0)("result_information")

            If data_gen.Rows(0)("information") = "1" Then
                TERec.Visible = True
            Else
                TERec.Visible = False
            End If

            ''pri
            SLUERecPri.EditValue = data_pri.Rows(0)("id_result")
            TERecPri.EditValue = data_pri.Rows(0)("result_information")

            If data_pri.Rows(0)("information") = "1" Then
                TERecPri.Visible = True
            Else
                TERecPri.Visible = False
            End If
        End If
    End Sub

    Sub load_summary()
        Dim query As String = "
            SELECT qs.id_question_sum, IFNULL((
                SELECT qsr.id_question_sum_res
                FROM tb_question_sum_res qsr
                WHERE qsr.id_question_period = " + id_question_period.ToString + " AND qsr.id_question_sum = qs.id_question_sum
            ), 0) id_question_sum_res, 
            qs.id_question_sum_group, qsg.group_name, qs.question, 
            IFNULL((
                SELECT qsr.value
                FROM tb_question_sum_res qsr
                WHERE qsr.id_question_period = " + id_question_period.ToString + " AND qsr.id_question_sum = qs.id_question_sum
            ), 0) value,
            qs.formula, 0.00 result, qs.max_value
            FROM tb_question_sum qs
            LEFT JOIN tb_question_sum_group qsg ON qs.id_question_sum_group = qsg.id_question_sum_group
            WHERE qs.grup_penilaian IN (0, " + grup_penilaian.ToString + ")
            ORDER BY qs.id_question_sum_group ASC, qs.id_question_sum ASC
        "

        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")

        'late, minus work
        Dim query_detail As String = "
            SELECT SUM(tb.late) AS late, ABS(SUM(tb.minus_work)) AS minus_work
            FROM
            (
	            SELECT tb.*, IF(tb.id_leave_type IS NULL, tb.minutes_work - tb.work_hour, 0) AS minus_work
	            FROM 
	            (
	                SELECT tb.*, IF(NOT ISNULL(tb.att_in) AND NOT ISNULL(tb.att_out), (tb.minutes_work - tb.over_break - tb.late + IF(tb.over < 0, tb.over, 0)), 0) AS work_hour
	                FROM 
	                (   
		            SELECT ket.id_leave_type, ket.leave_type, sch.id_employee, sch.date, sch.in, sch.in_tolerance, IF(sch.id_schedule_type = '1', MIN(at_in.datetime), MIN(at_in_hol.datetime)) AS att_in, sch.out, IF(sch.id_schedule_type = '1', MAX(at_out.datetime), MAX(at_out_hol.datetime)) AS att_out, sch.break_out, MIN(at_brout.datetime) AS start_break, sch.break_in, MAX(at_brin.datetime) AS end_break, sch.minutes_work, sch.out_tolerance, IF(ket.id_leave_type IS NULL, IF(MIN(at_in.datetime) > sch.in_tolerance, TIMESTAMPDIFF(MINUTE, sch.in_tolerance, MIN(at_in.datetime)), 0), 0) AS late, TIMESTAMPDIFF(MINUTE, sch.out, MAX(at_out.datetime)) AS over, IF(TIMESTAMPDIFF(MINUTE, MIN(at_brout.datetime), MAX(at_brin.datetime)) > TIMESTAMPDIFF(MINUTE, sch.break_out, sch.break_in), TIMESTAMPDIFF(MINUTE, MIN(at_brout.datetime), MAX(at_brin.datetime)) - TIMESTAMPDIFF(MINUTE, sch.break_out, sch.break_in), 0) AS over_break, TIMESTAMPDIFF(MINUTE, MIN(at_in.datetime), MAX(at_out.datetime)) AS actual_work_hour 
		            FROM tb_emp_schedule sch 
		            LEFT JOIN tb_lookup_leave_type ket ON ket.id_leave_type = sch.id_leave_type 
		            INNER JOIN tb_m_employee emp ON emp.id_employee = sch.id_employee 
		            INNER JOIN tb_lookup_employee_level lvl ON lvl.id_employee_level = emp.id_employee_level 
		            INNER JOIN tb_lookup_schedule_type scht ON scht.id_schedule_type = sch.id_schedule_type 
		            LEFT JOIN tb_emp_attn at_in ON at_in.id_employee = sch.id_employee AND (at_in.datetime >= (sch.out - INTERVAL 1 DAY) AND at_in.datetime <= sch.out) AND at_in.type_log = 1 
		            LEFT JOIN tb_emp_attn at_out ON at_out.id_employee = sch.id_employee AND (at_out.datetime >= sch.in AND at_out.datetime <= (sch.in + INTERVAL 1 DAY)) AND at_out.type_log = 2 
		            LEFT JOIN tb_emp_attn at_brout ON at_brout.id_employee = sch.id_employee AND DATE(at_brout.datetime) = sch.date AND at_brout.type_log = 3 
		            LEFT JOIN tb_emp_attn at_brin ON at_brin.id_employee = sch.id_employee AND DATE(at_brin.datetime) = sch.date AND at_brin.type_log = 4 
		            LEFT JOIN tb_emp_attn at_in_hol ON at_in_hol.id_employee = sch.id_employee AND DATE(at_in_hol.datetime) = sch.date AND at_in_hol.type_log = 1 
		            LEFT JOIN tb_emp_attn at_out_hol ON at_out_hol.id_employee = sch.id_employee AND DATE(at_out_hol.datetime) = sch.date AND at_out_hol.type_log = 2
		            WHERE sch.id_employee = " + id_employee.ToString + "
		            AND sch.date >= '" + Date.Parse(TEStartPeriod.EditValue.ToString).ToString("yyyy-MM-dd") + "'
		            AND sch.date <= '" + Date.Parse(TEEndPeriod.EditValue.ToString).AddDays(-45).ToString("yyyy-MM-dd") + "'
		            GROUP BY sch.id_schedule
	                ) tb
	            ) tb
            ) tb
            GROUP BY tb.id_employee
        "

        Dim data_detail As DataTable = execute_query(query_detail, -1, True, "", "", "", "")

        'sick
        Dim query_sick As String = "
            SELECT MONTH(sch.date) month, COUNT(sch.id_leave_type) total
            FROM tb_emp_schedule sch
            WHERE sch.id_employee = " + id_employee.ToString + "
            AND sch.id_leave_type = 2
            AND sch.date >= '" + Date.Parse(TEStartPeriod.EditValue.ToString).ToString("yyyy-MM-dd") + "'
            AND sch.date <= '" + Date.Parse(TEEndPeriod.EditValue.ToString).AddDays(-45).ToString("yyyy-MM-dd") + "'
            GROUP BY MONTH(sch.date)
            ORDER BY sch.date
        "

        Dim data_sick As DataTable = execute_query(query_sick, -1, True, "", "", "", "")

        'combine
        If data_detail.Rows.Count > 0 Then
            For i = 0 To data.Rows.Count - 1
                If data.Rows(i)("formula") = "late" Then
                    data.Rows(i)("value") = data_detail.Rows(0)("late")
                End If

                If data.Rows(i)("formula") = "sick" Then
                    Dim sick As Integer = 10
                    Dim sick_total As Integer = 0

                    If data_sick.Rows.Count > 0 Then
                        For j = 0 To data_sick.Rows.Count - 1
                            If j = 0 Then
                                If data_sick.Rows(j)("total") >= 2 Then
                                    sick = sick - 1
                                End If
                            End If

                            If j = 1 Then
                                If data_sick.Rows(j)("total") >= 2 Then
                                    sick = sick - 2
                                End If
                            End If

                            If j = 3 Then
                                If data_sick.Rows(j)("total") >= 2 Then
                                    sick = sick - 3
                                End If
                            End If

                            sick_total = sick_total + data_sick.Rows(j)("total")
                        Next

                        If sick_total >= 6 Then
                            sick = sick - 4
                        End If
                    End If

                    data.Rows(i)("value") = sick
                End If

                If data.Rows(i)("formula") = "wh" Then
                    data.Rows(i)("value") = data_detail.Rows(0)("minus_work")
                End If
            Next
        End If

        GCSummary.DataSource = data
        GVSummary.BestFitColumns()

        GCSummary.Height = (GVSummary.RowCount * 25) + 118

        Dim query_lookup As String = "SELECT point FROM tb_lookup_question_point"

        viewLookupRepositoryQuery(RILUEValue, query_lookup, 0, "point", "point")
    End Sub

    Sub calculate_summary(ByVal i As Integer)
        GVSummary.ExpandAllGroups()

        Dim query_lookup As String = "SELECT point, score FROM tb_lookup_question_point"

        Dim score_list As DataTable = execute_query(query_lookup, -1, True, "", "", "", "")

        Dim result As Decimal = 0

        If GVSummary.GetRowCellValue(i, "formula") = "late" Then
            result = (GVSummary.GetRowCellValue(i, "max_value") - ((GVSummary.GetRowCellValue(i, "value") / (120 * 6)) * GVSummary.GetRowCellValue(i, "max_value")))

            If (result < 0) Then
                result = 0
            End If

            GVSummary.SetRowCellValue(i, "result", result)
        ElseIf GVSummary.GetRowCellValue(i, "formula") = "wh" Then
            result = (GVSummary.GetRowCellValue(i, "max_value") - ((GVSummary.GetRowCellValue(i, "value") / (480 * 6)) * GVSummary.GetRowCellValue(i, "max_value")))

            If (result < 0) Then
                result = 0
            End If

            GVSummary.SetRowCellValue(i, "result", result)
        ElseIf GVSummary.GetRowCellValue(i, "formula") = "sick" Then
            GVSummary.SetRowCellValue(i, "result", GVSummary.GetRowCellValue(i, "value"))
        ElseIf GVSummary.GetRowCellValue(i, "formula") = "pu" Then
            Dim pu As Decimal = GVGroupQuestion.GetRowCellValue(GVGroupQuestion.RowCount - 1, "total")

            result = (pu * GVSummary.GetRowCellValue(i, "max_value")) / 100

            GVSummary.SetRowCellValue(i, "result", result)

            For j = 0 To score_list.Rows.Count - 1
                If pu >= score_list.Rows(j)("score") Then
                    GVSummary.SetRowCellValue(i, "value", score_list.Rows(j)("point"))
                End If
            Next
        ElseIf GVSummary.GetRowCellValue(i, "formula") = "point" Then
            For j = 0 To score_list.Rows.Count - 1
                If GVSummary.GetRowCellValue(i, "value") = score_list.Rows(j)("point") Then
                    result = (score_list.Rows(j)("score") * GVSummary.GetRowCellValue(i, "max_value")) / 100
                End If
            Next

            GVSummary.SetRowCellValue(i, "result", result)
        End If

        GVSummary.RefreshData()

        If GVSummary.Columns("result").SummaryItem.SummaryValue <= 40 Then
            GVSummary.Columns("max_value").SummaryItem.DisplayFormat = "Kurang"
        ElseIf GVSummary.Columns("result").SummaryItem.SummaryValue <= 60 Then
            GVSummary.Columns("max_value").SummaryItem.DisplayFormat = "Perlu Perbaikan"
        ElseIf GVSummary.Columns("result").SummaryItem.SummaryValue <= 80 Then
            GVSummary.Columns("max_value").SummaryItem.DisplayFormat = "Baik"
        ElseIf GVSummary.Columns("result").SummaryItem.SummaryValue <= 80 Then
            GVSummary.Columns("max_value").SummaryItem.DisplayFormat = "Baik Sekali"
        ElseIf GVSummary.Columns("result").SummaryItem.SummaryValue <= 90 Then
            GVSummary.Columns("max_value").SummaryItem.DisplayFormat = "Memuaskan"
        End If
    End Sub

    Private Sub FormEmpPerAppraisalDet_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Cursor = Cursors.WaitCursor

        load_question()

        load_conclusion()

        load_result()

        calculate_total()

        load_summary()

        For i = 0 To GVSummary.RowCount - 1
            If GVSummary.IsValidRowHandle(i) Then
                calculate_summary(i)
            End If
        Next

        If grup_penilaian >= 2 Then
            XTPPAP.PageVisible = True
        Else
            XTPPAP.PageVisible = False
        End If

        If is_hrd = "1" Or id_question_status >= 2 Then
            GCValue.OptionsColumn.AllowEdit = False
            GCInformation.OptionsColumn.AllowEdit = False
            GCConclusionResult.OptionsColumn.AllowEdit = False
            SLUERec.Properties.ReadOnly = True
            TERec.Properties.ReadOnly = True
            MEEmployeeNote.Properties.ReadOnly = True
            MEHRDNote.Properties.ReadOnly = False
            GCPConclusionResult.OptionsColumn.AllowEdit = False
            SLUERecPri.Properties.ReadOnly = True
            TERecPri.Properties.ReadOnly = True
            MEHRDNotePri.Properties.ReadOnly = False
            RILUEValue.ReadOnly = True

            If hrd_check <> 0 Then
                BtnSave.Enabled = False
            End If
        End If

        If is_dephead = "1" Or id_question_status = 3 Then
            MEEmployeeNote.Properties.ReadOnly = True
            MEHRDNote.Properties.ReadOnly = True
            MEHRDNotePri.Properties.ReadOnly = True

            If appraiser_check <> 0 Then
                BtnSave.Enabled = False
            End If
        End If

        If id_question_period = 0 Then
            BtnPrint.Enabled = False

            If is_hrd = "1" Then
                BtnSave.Enabled = False
            End If
        End If

        generate_number(GVListQuestion, "no")
        generate_number(GVConclusion, "no")
        generate_number(GVComment, "no")

        Cursor = Cursors.Default
    End Sub

    Sub generate_number(ByVal GridView As DevExpress.XtraGrid.Views.Grid.GridView, ByVal fieldName As String)
        For i = 0 To GridView.RowCount - 1
            GridView.SetRowCellValue(i, fieldName, i + 1)
        Next
    End Sub

    Sub calculate_total()
        'all group
        Dim query_group As String = "
            SELECT id_question_gen_app_group, CONCAT(id_question_gen_app_group, '. ', group_name) group_name, group_weight FROM tb_question_gen_app_group ORDER BY id_question_gen_app_group ASC
        "

        Dim data_group As DataTable = execute_query(query_group, -1, True, "", "", "", "")

        'last id
        Dim query_group_id As String = "
            SELECT id_question_gen_app_group FROM tb_question_gen_app_group ORDER BY id_question_gen_app_group DESC LIMIT 1
        "

        Dim last_group_id As Integer = execute_query(query_group_id, 0, True, "", "", "", "")

        'declare array
        Dim tot() As Decimal
        Dim count() As Integer

        'array dimension using last id
        ReDim tot(last_group_id)
        ReDim count(last_group_id)

        'variable
        Dim id_group As Integer = 0
        Dim group_name As String = ""
        Dim group_weight As Integer = 0

        Dim total As Decimal = 0.00
        Dim total_score As Decimal = 0.00

        Dim formula As String = ""

        Dim total_detail As New DataTable
        Dim result As New DataTable

        'calculate total & count each group
        For i As Integer = 0 To GVListQuestion.RowCount - 1
            If GVListQuestion.IsValidRowHandle(i) Then
                id_group = GVListQuestion.GetRowCellValue(i, "id_question_gen_app_group")

                tot(id_group) += GVListQuestion.GetRowCellValue(i, "value")
                count(id_group) += 1
            End If
        Next

        'datatable column
        total_detail.Columns.Add("group_name", GetType(String))
        total_detail.Columns.Add("formula", GetType(String))
        total_detail.Columns.Add("total", GetType(String))

        'total calculation
        For i As Integer = 0 To data_group.Rows.Count - 1
            id_group = data_group.Rows(i)("id_question_gen_app_group")
            group_name = data_group.Rows(i)("group_name")
            group_weight = data_group.Rows(i)("group_weight")

            'total each group
            total = group_weight * (tot(id_group) / (count(id_group) * 10))

            'formula string
            formula = group_weight.ToString + " X (" + tot(id_group).ToString + "/" + (count(id_group) * 10).ToString + ")"

            'datatable each group
            total_detail.Rows.Add(group_name, formula, Format(total, "0.00"))

            'total all
            total_score += total
        Next

        'datatable total all
        total_detail.Rows.Add("", "Total Nilai", Format(total_score, "0.00"))

        'datatable result
        Dim query_result = "
            SELECT IF(" + decimalSQL(total_score) + " >= `from` AND " + decimalSQL(total_score) + " <= `to`, '(X)', '') `result`, `name`, CONCAT(REPLACE(`from`, '.', ','), ' - ', REPLACE(`to`, '.', ',')) `range` FROM `tb_lookup_question_range` ORDER BY `from` DESC
        "

        Dim data_result As DataTable = execute_query(query_result, -1, True, "", "", "", "")

        GCGroupQuestion.DataSource = total_detail
        GVGroupQuestion.BestFitColumns()

        GCResult.DataSource = data_result
        GVResult.BestFitColumns()

        'row result
        For i = 0 To GVResult.RowCount - 1
            If GVResult.GetRowCellValue(i, "result").ToString <> "" Then
                row_result = i
            End If
        Next

        'Summary
        For i = 0 To GVSummary.RowCount - 1
            If GVSummary.GetRowCellValue(i, "formula") = "pu" Then
                calculate_summary(i)
            End If
        Next
    End Sub

    Sub save_data()
        GVListQuestion.ExpandAllGroups()

        Dim query As String = ""

        If id_question_period = 0 Then
            Dim start_period As String = Date.Parse(TEStartPeriod.EditValue.ToString).ToString("yyyy-MM-dd")
            Dim end_period As String = Date.Parse(TEEndPeriod.EditValue.ToString).ToString("yyyy-MM-dd")

            query = "INSERT INTO tb_question_period (id_employee, from_period, until_period, appraiser_check, appraiser_check_date, id_question_status) VALUES (" + id_employee.ToString + ", '" + start_period + "', '" + end_period + "', " + id_employee_user + ", NOW(), 2); SELECT LAST_INSERT_ID();"

            id_question_period = execute_query(query, 0, True, "", "", "", "")
        End If

        If is_hrd = "1" Then
            query = "UPDATE tb_question_period SET hrd_check = " + id_employee_user + ", hrd_check_date = NOW(), id_question_status = 3 WHERE id_question_period = " + id_question_period.ToString + ""

            execute_non_query(query, True, "", "", "", "")
        End If

        'app
        For i As Integer = 0 To GVListQuestion.RowCount - 1
            If GVListQuestion.IsValidRowHandle(i) Then
                If GVListQuestion.GetRowCellValue(i, "id_question_gen_app_res").ToString = "0" Then
                    query = "INSERT INTO tb_question_gen_app_res (id_question_period, id_question_gen_app, value, information) VALUES (" + id_question_period.ToString + ", " + GVListQuestion.GetRowCellValue(i, "id_question_gen_app").ToString + ", " + GVListQuestion.GetRowCellValue(i, "value").ToString + ", '" + addSlashes(GVListQuestion.GetRowCellValue(i, "information").ToString) + "')"
                Else
                    query = "UPDATE tb_question_gen_app_res SET id_question_period = " + id_question_period.ToString + ", id_question_gen_app = " + GVListQuestion.GetRowCellValue(i, "id_question_gen_app").ToString + ", value = " + GVListQuestion.GetRowCellValue(i, "value").ToString + ", information = '" + addSlashes(GVListQuestion.GetRowCellValue(i, "information").ToString) + "' WHERE id_question_gen_app_res = " + GVListQuestion.GetRowCellValue(i, "id_question_gen_app_res").ToString + ""
                End If

                execute_non_query(query, True, "", "", "", "")
            End If
        Next

        'con
        ''gen
        For i As Integer = 0 To GVConclusion.RowCount - 1
            If GVConclusion.GetRowCellValue(i, "id_question_gen_con_res").ToString = "0" Then
                query = "INSERT INTO tb_question_gen_con_res (id_question_period, id_question_gen_con, conclusion) VALUES (" + id_question_period.ToString + ", " + GVConclusion.GetRowCellValue(i, "id_question_gen_con").ToString + ", '" + addSlashes(GVConclusion.GetRowCellValue(i, "conclusion").ToString) + "')"
            Else
                query = "UPDATE tb_question_gen_con_res SET id_question_period = " + id_question_period.ToString + ", id_question_gen_con = " + GVConclusion.GetRowCellValue(i, "id_question_gen_con").ToString + ", conclusion = '" + addSlashes(GVConclusion.GetRowCellValue(i, "conclusion").ToString) + "' WHERE id_question_gen_con_res = " + GVConclusion.GetRowCellValue(i, "id_question_gen_con_res").ToString + ""
            End If

            execute_non_query(query, True, "", "", "", "")
        Next

        ''pri
        For i As Integer = 0 To GVComment.RowCount - 1
            If GVComment.GetRowCellValue(i, "id_question_pri_con_res").ToString = "0" Then
                query = "INSERT INTO tb_question_pri_con_res (id_question_period, id_question_pri_con, conclusion) VALUES (" + id_question_period.ToString + ", " + GVComment.GetRowCellValue(i, "id_question_pri_con").ToString + ", '" + addSlashes(GVComment.GetRowCellValue(i, "conclusion").ToString) + "')"
            Else
                query = "UPDATE tb_question_pri_con_res SET id_question_period = " + id_question_period.ToString + ", id_question_pri_con = " + GVComment.GetRowCellValue(i, "id_question_pri_con").ToString + ", conclusion = '" + addSlashes(GVComment.GetRowCellValue(i, "conclusion").ToString) + "' WHERE id_question_pri_con_res = " + GVComment.GetRowCellValue(i, "id_question_pri_con_res").ToString + ""
            End If

            execute_non_query(query, True, "", "", "", "")
        Next

        'res
        ''gen
        If id_question_gen_res <> 0 Then
            query = "UPDATE tb_question_gen_res SET id_question_period = " + id_question_period.ToString + ", id_result = " + SLUERec.EditValue.ToString + ", employee_note = '" + addSlashes(MEEmployeeNote.EditValue.ToString) + "', hrd_note = '" + addSlashes(MEHRDNote.EditValue.ToString) + "', result_information = '" + addSlashes(TERec.EditValue.ToString) + "' WHERE id_question_gen_res = " + id_question_gen_res.ToString + ""
        Else
            query = "INSERT INTO tb_question_gen_res (id_question_period, id_result, employee_note, hrd_note, result_information) VALUES (" + id_question_period.ToString + ", " + SLUERec.EditValue.ToString + ", '" + addSlashes(MEEmployeeNote.EditValue.ToString) + "', '" + addSlashes(MEHRDNote.EditValue.ToString) + "', '" + addSlashes(TERec.EditValue.ToString) + "')"
        End If

        execute_non_query(query, True, "", "", "", "")

        ''pri
        If id_question_pri_res <> 0 Then
            query = "UPDATE tb_question_pri_res SET id_question_period = " + id_question_period.ToString + ", id_result = " + SLUERecPri.EditValue.ToString + ", hrd_note = '" + addSlashes(MEHRDNotePri.EditValue.ToString) + "', result_information = '" + addSlashes(TERecPri.EditValue.ToString) + "' WHERE id_question_pri_res = " + id_question_pri_res.ToString + ""
        Else
            query = "INSERT INTO tb_question_pri_res (id_question_period, id_result, hrd_note, result_information) VALUES (" + id_question_period.ToString + ", " + SLUERecPri.EditValue.ToString + ", '" + addSlashes(MEHRDNotePri.EditValue.ToString) + "', '" + addSlashes(TERecPri.EditValue.ToString) + "')"
        End If

        execute_non_query(query, True, "", "", "", "")

        'summary
        For i = 0 To GVSummary.RowCount - 1
            If GVSummary.GetRowCellValue(i, "formula") = "point" Then
                If GVSummary.GetRowCellValue(i, "id_question_sum_res") = "0" Then
                    query = "INSERT INTO tb_question_sum_res (id_question_period, id_question_sum, value) VALUES (" + id_question_period.ToString + ", " + GVSummary.GetRowCellValue(i, "id_question_sum").ToString + ", " + GVSummary.GetRowCellValue(i, "value").ToString + ")"
                Else
                    query = "UPDATE tb_question_sum_res SET id_question_period = " + id_question_period.ToString + ", id_question_sum = " + GVSummary.GetRowCellValue(i, "id_question_sum").ToString + ", value = " + GVSummary.GetRowCellValue(i, "value").ToString + " WHERE id_question_sum_res = " + GVSummary.GetRowCellValue(i, "id_question_sum_res").ToString + ""
                End If

                execute_non_query(query, True, "", "", "", "")
            End If
        Next
    End Sub

    Private Sub LUEValue_EditValueChanged(sender As Object, e As EventArgs) Handles LUEValue.EditValueChanged
        GVListQuestion.CloseEditor()
        GVListQuestion.UpdateCurrentRow()

        calculate_total()
    End Sub

    Private Sub FormEmpPerAppraisalDet_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        FormEmpPerAppraisal.load_employee()
        FormEmpPerAppraisal.load_history()

        If FormEmpPerAppraisal.XTCEmp.SelectedTabPage.Name = "XTPPenilaian" Then
            FormEmpPerAppraisal.GVList.FocusedRowHandle = find_row(FormEmpPerAppraisal.GVList, "id_employee", id_employee.ToString)
        ElseIf FormEmpPerAppraisal.XTCEmp.SelectedTabPage.Name = "XTPHistory" Then
            FormEmpPerAppraisal.GVHistory.FocusedRowHandle = find_row(FormEmpPerAppraisal.GVHistory, "id_question_period", id_question_period.ToString)
        End If

        Dispose()
    End Sub

    Private Sub BtnSave_Click(sender As Object, e As EventArgs) Handles BtnSave.Click
        MEHRDNote_Validating(MEHRDNote, New ComponentModel.CancelEventArgs())
        MEHRDNotePri_Validating(MEHRDNotePri, New ComponentModel.CancelEventArgs())
        TERec_Validating(TERec, New ComponentModel.CancelEventArgs())
        TERecPri_Validating(TERecPri, New ComponentModel.CancelEventArgs())
        SLUERec_Validating(SLUERec, New ComponentModel.CancelEventArgs())
        SLUERecPri_Validating(SLUERecPri, New ComponentModel.CancelEventArgs())

        validating_gen_con()
        validating_pri_con()

        If Not formIsValidInGroup(ErrorProvider1, GroupControl6) Or Not formIsValidInGroup(ErrorProvider1, GroupControl8) Or Not formIsValidInGroup(ErrorProvider1, GroupControl10) Or Not formIsValidInGroup(ErrorProvider1, GroupControl11) Or Not formIsValidInPanel(ErrorProvider1, PanelControl5) Or Not formIsValidInPanel(ErrorProvider1, PanelControl6) Then
            errorCustom("Mohon diisi dengan lengkap.")
        Else
            Dim confirm As DialogResult
            confirm = DevExpress.XtraEditors.XtraMessageBox.Show("Data akan disimpan dan tidak dapat diubah lagi, mohon untuk diperiksa kembali." + Environment.NewLine + "Apakah anda yakin akan disimpan?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)

            If confirm = Windows.Forms.DialogResult.Yes Then
                save_data()

                Close()
            End If
        End If
    End Sub

    Private Sub BtnClose_Click(sender As Object, e As EventArgs) Handles BtnClose.Click
        Close()
    End Sub

    Private Sub BtnPrint_Click(sender As Object, e As EventArgs) Handles BtnPrint.Click
        Cursor = Cursors.WaitCursor

        If XTCAppraisal.SelectedTabPage.Name = "XTPPAU" Then
            print_pau()
        ElseIf XTCAppraisal.SelectedTabPage.Name = "XTPPAP" Then
            print_pap()
        ElseIf XTCAppraisal.SelectedTabPage.Name = "XTPPA" Then
            print_sum()
        End If

        Cursor = Cursors.Default
    End Sub

    Sub print_pau()
        ReportEmpPerAppraisalPAU.dt_question = GCListQuestion.DataSource
        ReportEmpPerAppraisalPAU.dt_group_question = GCGroupQuestion.DataSource
        ReportEmpPerAppraisalPAU.dt_result = GCResult.DataSource
        ReportEmpPerAppraisalPAU.dt_conclusion = GCConclusion.DataSource

        Dim Report As New ReportEmpPerAppraisalPAU()

        If grup_penilaian >= 2 Then
            Report.XLLevelStaff.Text = "(Level Assistant Supervisor s/d Senior Manager)"
        Else
            Report.XLLevelStaff.Text = "(Level Staff s/d Team Leader)"
        End If

        Report.XLNama.Text = TEEmployeeName.EditValue.ToString
        Report.XLPosition.Text = TEEmployeePosition.EditValue.ToString
        Report.XLDept.Text = TEDepartement.EditValue.ToString
        Report.XLComp.Text = TECompany.EditValue.ToString
        Report.XLJoinDate.Text = TEEmployeeJoinDate.EditValue.ToString
        Report.XLStatus.Text = TEEmployeeStatus.EditValue.ToString
        Report.XLPeriod.Text = TEStartPeriod.EditValue.ToString + " s/d " + TEEndPeriod.EditValue.ToString
        Report.XLPurpose.Text = TEPurpose.EditValue.ToString

        Report.XLRecommend.Text = SLUERec.Text + " " + TERec.EditValue.ToString
        Report.XLEmpNote.Text = MEEmployeeNote.EditValue.ToString
        Report.XLHRDNote.Text = MEHRDNote.EditValue.ToString

        Report.XLStaff.Text = TEEmployeeName.EditValue.ToString

        If appraiser_check <> 0 Then
            Report.XLAppraiser.Text = get_emp(appraiser_check.ToString, "2")
            Report.XLAppraiserDate.Text = appraiser_check_date

            Report.XLAppraiserMng.Text = employee_head_name
        End If

        If hrd_check <> 0 Then
            'Report.XLHRD.Text = get_emp(hrd_check.ToString, "2")
            Report.XLHRDDate.Text = hrd_check_date
        End If

        Dim Tool As DevExpress.XtraReports.UI.ReportPrintTool = New DevExpress.XtraReports.UI.ReportPrintTool(Report)
        Tool.ShowPreview()
    End Sub

    Sub print_pap()
        ReportEmpPerAppraisalPAP.dt_conclusion = GCComment.DataSource

        Dim Report As New ReportEmpPerAppraisalPAP()

        Report.XLNama.Text = TEEmployeeName.EditValue.ToString
        Report.XLPosition.Text = TEEmployeePosition.EditValue.ToString
        Report.XLDept.Text = TEDepartement.EditValue.ToString
        Report.XLComp.Text = TECompany.EditValue.ToString
        Report.XLJoinDate.Text = TEEmployeeJoinDate.EditValue.ToString
        Report.XLStatus.Text = TEEmployeeStatus.EditValue.ToString
        Report.XLPeriod.Text = TEStartPeriod.EditValue.ToString + " s/d " + TEEndPeriod.EditValue.ToString
        Report.XLPurpose.Text = TEPurpose.EditValue.ToString

        Report.XLRecommend.Text = SLUERecPri.Text + " " + TERecPri.EditValue.ToString
        Report.XLHRDNote.Text = MEHRDNotePri.EditValue.ToString

        If appraiser_check <> 0 Then
            Report.XLAppraiser.Text = get_emp(appraiser_check.ToString, "2")
            Report.XLAppraiserDate.Text = appraiser_check_date

            Report.XLAppraiserMng.Text = employee_head_name
        End If

        If hrd_check <> 0 Then
            'Report.XLHRD.Text = get_emp(hrd_check.ToString, "2")
            Report.XLHRDDate.Text = hrd_check_date
        End If

        Dim Tool As DevExpress.XtraReports.UI.ReportPrintTool = New DevExpress.XtraReports.UI.ReportPrintTool(Report)
        Tool.ShowPreview()
    End Sub

    Sub print_sum()
        ReportEmpPerAppraisalSUM.dt = GCSummary.DataSource

        Dim Report As New ReportEmpPerAppraisalSUM()

        If grup_penilaian = 3 Then
            Report.XLTitle.Text = "SUMMARY PENILAIAN INDIVIDU KARYAWAN LEVEL JUNIOR COORDINATOR S/D SENIOR MANAGER"
        ElseIf grup_penilaian = 2 Then
            Report.XLTitle.Text = "SUMMARY PENILAIAN INDIVIDU KARYAWAN LEVEL ASSISTANT SUPERVISOR S/D SENIOR SUPERVISOR"
        ElseIf grup_penilaian = 1 Then
            Report.XLTitle.Text = "SUMMARY PENILAIAN INDIVIDU KARYAWAN LEVEL STAFF S/D TEAM LEADER"
        End If

        Report.XLNama.Text = TEEmployeeName.EditValue.ToString
        Report.XLPosition.Text = TEEmployeePosition.EditValue.ToString
        Report.XLDept.Text = TEDepartement.EditValue.ToString
        Report.XLComp.Text = TECompany.EditValue.ToString
        Report.XLJoinDate.Text = TEEmployeeJoinDate.EditValue.ToString
        Report.XLStatus.Text = TEEmployeeStatus.EditValue.ToString
        Report.XLPeriod.Text = TEStartPeriod.EditValue.ToString + " s/d " + TEEndPeriod.EditValue.ToString
        Report.XLPurpose.Text = TEPurpose.EditValue.ToString

        Report.XLGrandTotal.Text = FormatNumber(GVSummary.Columns("result").SummaryItem.SummaryValue, 2).ToString + "%"

        If GVSummary.Columns("result").SummaryItem.SummaryValue <= 40 Then
            Report.XLKategori.Text = "Kurang"
        ElseIf GVSummary.Columns("result").SummaryItem.SummaryValue <= 60 Then
            Report.XLKategori.Text = "Perlu Perbaikan"
        ElseIf GVSummary.Columns("result").SummaryItem.SummaryValue <= 80 Then
            Report.XLKategori.Text = "Baik"
        ElseIf GVSummary.Columns("result").SummaryItem.SummaryValue <= 80 Then
            Report.XLKategori.Text = "Baik Sekali"
        ElseIf GVSummary.Columns("result").SummaryItem.SummaryValue <= 90 Then
            Report.XLKategori.Text = "Memuaskan"
        End If

        Dim Tool As DevExpress.XtraReports.UI.ReportPrintTool = New DevExpress.XtraReports.UI.ReportPrintTool(Report)
        Tool.ShowPreview()
    End Sub

    Private Sub SLUERec_EditValueChanged(sender As Object, e As EventArgs) Handles SLUERec.EditValueChanged
        If SLUERec.Properties.View.GetFocusedRowCellValue("information") = "1" Then
            TERec.Visible = True
        Else
            TERec.Visible = False
            TERec.EditValue = ""
        End If
    End Sub

    Private Sub SLUERecPri_EditValueChanged(sender As Object, e As EventArgs) Handles SLUERecPri.EditValueChanged
        If SLUERecPri.Properties.View.GetFocusedRowCellValue("information") = "1" Then
            TERecPri.Visible = True
        Else
            TERecPri.Visible = False
            TERecPri.EditValue = ""
        End If
    End Sub

    Private Sub GVResult_RowCellStyle(sender As Object, e As DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs) Handles GVResult.RowCellStyle
        If e.RowHandle = row_result Then
            e.Appearance.FontStyleDelta = FontStyle.Bold
        End If
    End Sub

    Private Sub GVGroupQuestion_RowCellStyle(sender As Object, e As DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs) Handles GVGroupQuestion.RowCellStyle
        If e.RowHandle = GVGroupQuestion.RowCount - 1 Then
            e.Appearance.FontStyleDelta = FontStyle.Bold
        End If
    End Sub

    Private Sub RILUEValue_EditValueChanged(sender As Object, e As EventArgs) Handles RILUEValue.EditValueChanged
        GVSummary.CloseEditor()
        GVSummary.UpdateCurrentRow()

        calculate_summary(GVSummary.GetFocusedDataSourceRowIndex)
    End Sub

    Private Sub GVSummary_CustomRowCellEdit(sender As Object, e As DevExpress.XtraGrid.Views.Grid.CustomRowCellEditEventArgs) Handles GVSummary.CustomRowCellEdit
        If e.Column.Name = "GCSValue" Then
            If GVSummary.GetRowCellValue(e.RowHandle, "formula") = "point" Then
                e.RepositoryItem = RILUEValue
            Else
                e.RepositoryItem = RITEValue
            End If
        Else
            Return
        End If
    End Sub

    Private Sub SLUERec_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles SLUERec.Validating
        If SLUERec.EditValue = 1 Then
            ErrorProvider1.SetError(SLUERec, "Mohon diisi.")
        Else
            ErrorProvider1.SetError(SLUERec, String.Empty)
        End If
    End Sub

    Private Sub TERec_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles TERec.Validating
        If TERec.Visible Then
            If TERec.EditValue = "" Then
                ErrorProvider1.SetError(TERec, "Mohon diisi.")
            Else
                ErrorProvider1.SetError(TERec, String.Empty)
            End If
        Else
            ErrorProvider1.SetError(TERec, String.Empty)
        End If
    End Sub

    Private Sub SLUERecPri_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles SLUERecPri.Validating
        If XTPPAP.PageVisible Then
            If SLUERecPri.EditValue = 1 Then
                ErrorProvider1.SetError(SLUERecPri, "Mohon diisi.")
            Else
                ErrorProvider1.SetError(SLUERecPri, String.Empty)
            End If
        Else
            ErrorProvider1.SetError(SLUERecPri, String.Empty)
        End If
    End Sub

    Private Sub TERecPri_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles TERecPri.Validating
        If XTPPAP.PageVisible Then
            If TERecPri.Visible Then
                If TERecPri.EditValue = "" Then
                    ErrorProvider1.SetError(TERecPri, "Mohon diisi.")
                Else
                    ErrorProvider1.SetError(TERecPri, String.Empty)
                End If
            Else
                ErrorProvider1.SetError(TERecPri, String.Empty)
            End If
        Else
            ErrorProvider1.SetError(TERecPri, String.Empty)
        End If
    End Sub

    Private Sub MEHRDNote_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles MEHRDNote.Validating
        If is_hrd = "1" Then
            If MEHRDNote.EditValue = "" Then
                ErrorProvider1.SetError(MEHRDNote, "Mohon diisi.")
            Else
                ErrorProvider1.SetError(MEHRDNote, String.Empty)
            End If
        Else
            ErrorProvider1.SetError(MEHRDNote, String.Empty)
        End If
    End Sub

    Private Sub MEHRDNotePri_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles MEHRDNotePri.Validating
        If XTPPAP.PageVisible Then
            If is_hrd = "1" Then
                If MEHRDNotePri.EditValue = "" Then
                    ErrorProvider1.SetError(MEHRDNotePri, "Mohon diisi.")
                Else
                    ErrorProvider1.SetError(MEHRDNotePri, String.Empty)
                End If
            Else
                ErrorProvider1.SetError(MEHRDNotePri, String.Empty)
            End If
        Else
            ErrorProvider1.SetError(MEHRDNotePri, String.Empty)
        End If
    End Sub

    Sub validating_gen_con()
        Dim er As Boolean = False

        If is_dephead = "1" Then
            For i = 0 To GVConclusion.RowCount - 1
                If GVConclusion.GetRowCellValue(i, "conclusion").ToString() = "" Then
                    er = True
                End If
            Next
        End If

        If er Then
            ErrorProvider1.SetError(TEGenCon, "Mohon diisi.")
        Else
            ErrorProvider1.SetError(TEGenCon, String.Empty)
        End If
    End Sub

    Sub validating_pri_con()
        Dim er As Boolean = False

        If XTPPAP.PageVisible Then
            If is_dephead = "1" Then
                For i = 0 To GVComment.RowCount - 1
                    If GVComment.GetRowCellValue(i, "conclusion").ToString() = "" Then
                        er = True
                    End If
                Next
            End If
        End If

        If er Then
            ErrorProvider1.SetError(TEPriCon, "Mohon diisi.")
        Else
            ErrorProvider1.SetError(TEPriCon, String.Empty)
        End If
    End Sub
End Class