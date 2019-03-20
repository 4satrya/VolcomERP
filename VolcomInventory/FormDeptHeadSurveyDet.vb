Public Class FormDeptHeadSurveyDet
    Public id_period As Integer = 0

    Private Sub FormDeptHeadSurveyDet_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If id_period = 0 Then
            GCDetail.Visible = False
        Else
            TEName.ReadOnly = True
            DEStart.ReadOnly = True
            DEEnd.ReadOnly = True

            Dim data_period As DataTable = execute_query("SELECT * FROM `tb_question_depthead_period` WHERE `id_question_depthead_period` = " + id_period.ToString + "", -1, True, "", "", "", "")

            TEName.EditValue = data_period.Rows(0)("period_name")
            DEStart.EditValue = data_period.Rows(0)("from_period")
            DEEnd.EditValue = data_period.Rows(0)("until_period")

            If data_period.Rows(0)("status") = 0 Then
                CEActive.Checked = False
            Else
                CEActive.Checked = True
            End If

            Dim query_survey As String = "
                SELECT dr.id_departement, dept.departement, dr.id_depthead, depthead.employee_name AS depthead_name, dr.id_employee, CONCAT(dept.departement, ': ', depthead.employee_name) AS view, '' AS survey
                FROM tb_question_depthead_res AS dr 
                LEFT JOIN tb_m_departement AS dept ON dr.id_departement = dept.id_departement
                LEFT JOIN tb_m_employee AS depthead ON dr.id_depthead = depthead.id_employee
                WHERE dr.id_question_depthead_period = " + id_period.ToString + " GROUP BY dr.id_employee
            "

            Dim data_survey As DataTable = execute_query(query_survey, -1, True, "", "", "", "")

            GCSurvey.DataSource = data_survey

            GVSurvey.BestFitColumns()

            For i = 0 To GVSurvey.RowCount - 1
                GVSurvey.SetRowCellValue(i, "survey", "Form Survey " + (i + 1).ToString)
            Next
        End If
    End Sub

    Private Sub SBSave_Click(sender As Object, e As EventArgs) Handles SBSave.Click
        Dim query As String = ""
        Dim status As Integer = If(CEActive.Checked, 1, 0)

        If id_period = 0 Then
            query = "INSERT INTO `tb_question_depthead_period` (`created_date`, `period_name`, `from_period`, `until_period`, `status`) VALUES (NOW(), '" + TEName.EditValue.ToString + "', '" + Date.Parse(DEStart.EditValue.ToString).ToString("yyyy-MM-dd") + "', '" + Date.Parse(DEEnd.EditValue.ToString).ToString("yyyy-MM-dd") + "', " + status.ToString + "); SELECT LAST_INSERT_ID();"

            id_period = Convert.ToInt32(execute_query(query, 0, True, "", "", "", ""))
        Else
            query = "UPDATE `tb_question_depthead_period` SET `status` = " + status.ToString + " WHERE `id_question_depthead_period` = " + id_period.ToString + ""

            execute_non_query(query, True, "", "", "", "")
        End If

        If status = 1 Then
            Dim data_period As DataTable = execute_query("SELECT `id_question_depthead_period` FROM `tb_question_depthead_period`", -1, True, "", "", "", "")

            For i = 0 To data_period.Rows.Count - 1
                If Not data_period.Rows(i)("id_question_depthead_period").ToString = id_period.ToString Then
                    query = "UPDATE `tb_question_depthead_period` SET `status` = 0 WHERE `id_question_depthead_period` = " + data_period.Rows(i)("id_question_depthead_period").ToString + ""

                    execute_non_query(query, True, "", "", "", "")
                End If
            Next
        End If

        Close()
    End Sub

    Private Sub FormDeptHeadSurveyDet_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        FormDeptHeadSurvey.load_period()

        FormDeptHeadSurvey.GVListPeriod.FocusedRowHandle = find_row(FormDeptHeadSurvey.GVListPeriod, "id_question_depthead_period", id_period.ToString)

        Dispose()
    End Sub

    Private Sub SBCancel_Click(sender As Object, e As EventArgs) Handles SBCancel.Click
        Close()
    End Sub

    Private Sub GVSurvey_DoubleClick(sender As Object, e As EventArgs) Handles GVSurvey.DoubleClick
        If GVSurvey.GetFocusedRowCellValue("id_employee").ToString IsNot Nothing Then
            Cursor = Cursors.WaitCursor

            Dim query As String = "
                SELECT 0 no, dr.id_question_depthead, d.question, dr.value, dr.information
                FROM tb_question_depthead_res dr
                LEFT JOIN tb_question_depthead d ON dr.id_question_depthead = d.id_question_depthead
                WHERE dr.id_question_depthead_period = " + id_period.ToString + " AND dr.id_employee = " + GVSurvey.GetFocusedRowCellValue("id_employee").ToString + "
            "

            Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")

            ReportDeptHeadSurvey.dt = data

            Dim Report As New ReportDeptHeadSurvey()

            Report.XLDeptHead.Text = GVSurvey.GetFocusedRowCellValue("depthead_name")
            Report.XLDept.Text = GVSurvey.GetFocusedRowCellValue("departement")

            Dim Tool As DevExpress.XtraReports.UI.ReportPrintTool = New DevExpress.XtraReports.UI.ReportPrintTool(Report)
            Tool.ShowPreview()

            Cursor = Cursors.Default
        End If
    End Sub
End Class