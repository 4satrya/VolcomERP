Public Class FormDeptHeadSurvey
    Public is_hrd As String = "-1"

    Public id_period As Integer = 0

    Sub load_question()
        viewLookupRepositoryQuery(RIUEValue, "SELECT value FROM tb_lookup_question_depthead_value", 0, "value", "value")

        Dim already As Integer = Convert.ToInt32(execute_query("SELECT IF((SELECT id_question_depthead_res FROM tb_question_depthead_res WHERE id_question_depthead_period = " + id_period.ToString + " LIMIT 1) IS NULL, 0, 1) already", 0, True, "", "", "", ""))

        Dim query As String = ""

        If already = 0 Then
            query = "SELECT 0 no, id_question_depthead, question, 1 value, '' information FROM tb_question_depthead"
        Else
            query = "
                SELECT 0 no, dr.id_question_depthead, d.question, dr.value, dr.information
                FROM tb_question_depthead_res dr
                LEFT JOIN tb_question_depthead d ON dr.id_question_depthead = d.id_question_depthead
                WHERE dr.id_question_depthead_period = " + id_period.ToString + " AND dr.id_employee = " + id_employee_user + "
            "
        End If

        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")

        GCList.DataSource = data

        GVList.BestFitColumns()

        generate_number(GVList, "no")

        If already = 1 Then
            BtnPrint.Enabled = True

            BtnSave.Enabled = False

            RIUEValue.ReadOnly = True
            RIMEInformation.ReadOnly = True
        End If
    End Sub

    Sub load_period()
        Dim data_period As DataTable = execute_query("SELECT id_question_depthead_period, period_name, DATE_FORMAT(from_period, '%d %M %Y') AS from_period, DATE_FORMAT(until_period, '%d %M %Y') AS until_period, IF(status = 0, 'Tidak Aktif', 'Aktif') AS status FROM tb_question_depthead_period ORDER BY id_question_depthead_period DESC", -1, True, "", "", "", "")

        GCListPeriod.DataSource = data_period

        GVListPeriod.BestFitColumns()
    End Sub

    Private Sub FormDeptHeadSurvey_Activated(sender As Object, e As EventArgs) Handles MyBase.Activated
        FormMain.show_rb(Name)
        checkFormAccess(Name)

        Dim btn_new = "0"
        Dim btn_edit = "0"
        Dim btn_delete = "0"

        If is_hrd = "1" Then
            btn_new = "1"
            btn_edit = "1"

            If GVListPeriod.RowCount < 1 Then
                btn_edit = "0"
            End If
        End If

        button_main(btn_new, btn_edit, btn_delete)
    End Sub

    Private Sub FormDeptHeadSurvey_Deactivate(sender As Object, e As EventArgs) Handles MyBase.Deactivate
        FormMain.hide_rb()
    End Sub

    Private Sub FormDeptHeadSurvey_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If is_hrd = "1" Then
            XTPForm.PageVisible = False
            XTPPeriod.PageVisible = True

            load_period()
        Else
            XTPForm.PageVisible = True
            XTPPeriod.PageVisible = False

            Dim query_depthead As String = "SELECT id_user_head FROM tb_m_departement WHERE id_departement = '" + id_departement_user + "'"

            Dim id_user_depthead As String = execute_query(query_depthead, 0, True, "", "", "", "")

            TEDeptHead.EditValue = get_emp(id_user_depthead, "3")
            TEDept.EditValue = get_departement_x(id_departement_user, "1")

            id_period = Convert.ToInt32(execute_query("SELECT IFNULL((SELECT id_question_depthead_period FROM tb_question_depthead_period WHERE `status` = 1 AND CURDATE() >= from_period AND CURDATE() <= until_period LIMIT 1), 0) AS id_question_depthead_period", 0, True, "", "", "", ""))

            If Not id_period = 0 Then
                load_question()
            End If
        End If
    End Sub

    Private Sub BtnSave_Click(sender As Object, e As EventArgs) Handles BtnSave.Click
        Dim confirm As DialogResult
        confirm = DevExpress.XtraEditors.XtraMessageBox.Show("Data akan disimpan dan tidak dapat diubah lagi, mohon untuk diperiksa kembali." + Environment.NewLine + "Apakah anda yakin akan disimpan?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)

        If confirm = Windows.Forms.DialogResult.Yes Then
            GVList.ExpandAllGroups()

            Dim query_depthead As String = "SELECT id_employee FROM tb_m_user WHERE id_user = (SELECT id_user_head FROM tb_m_departement WHERE id_departement = " + id_departement_user + ")"

            Dim id_depthead As String = execute_query(query_depthead, 0, True, "", "", "", "")

            Dim query As String = ""

            For i As Integer = 0 To GVList.RowCount - 1
                query = "INSERT INTO tb_question_depthead_res (id_question_depthead, id_question_depthead_period, id_employee, id_departement, id_depthead, value, information) VALUES (" + GVList.GetRowCellValue(i, "id_question_depthead").ToString + ", " + id_period.ToString + ", " + id_employee_user + ", " + id_departement_user + ", " + id_depthead + ", " + GVList.GetRowCellValue(i, "value").ToString + ", '" + addSlashes(GVList.GetRowCellValue(i, "information").ToString) + "')"

                execute_non_query(query, True, "", "", "", "")
            Next

            load_question()

            infoCustom("Data sudah tersimpan.")
        End If
    End Sub

    Sub generate_number(ByVal GridView As DevExpress.XtraGrid.Views.Grid.GridView, ByVal fieldName As String)
        For i = 0 To GridView.RowCount - 1
            GridView.SetRowCellValue(i, fieldName, i + 1)
        Next
    End Sub

    Private Sub BtnPrint_Click(sender As Object, e As EventArgs) Handles BtnPrint.Click
        Cursor = Cursors.WaitCursor

        ReportDeptHeadSurvey.dt = GCList.DataSource

        Dim Report As New ReportDeptHeadSurvey()

        Report.XLDeptHead.Text = TEDeptHead.EditValue.ToString
        Report.XLDept.Text = TEDept.EditValue.ToString

        Dim Tool As DevExpress.XtraReports.UI.ReportPrintTool = New DevExpress.XtraReports.UI.ReportPrintTool(Report)
        Tool.ShowPreview()

        Cursor = Cursors.Default
    End Sub

    Private Sub GVListPeriod_DoubleClick(sender As Object, e As EventArgs) Handles GVListPeriod.DoubleClick
        FormDeptHeadSurveyDet.id_period = GVListPeriod.GetFocusedRowCellValue("id_question_depthead_period")

        FormDeptHeadSurveyDet.ShowDialog()
    End Sub
End Class