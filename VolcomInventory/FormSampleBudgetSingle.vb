Public Class FormSampleBudgetSingle
    Public is_edit As String = "2"
    Private Sub FormSampleBudgetSingle_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        DEYearBudget.EditValue = Now
        TEBudgetKurs.EditValue = 1.0
        TEBudgetUSD.EditValue = 0.00
        TEBudgetRp.EditValue = 0.00
        '
        load_division()
        '
        If is_edit = "1" Then
            TEDescription.Text = FormSampleBudgetDet.GVAfter.GetFocusedRowCellValue("description_after").ToString
            DEYearBudget.EditValue = Date.Parse("1-1-" & FormSampleBudgetDet.GVAfter.GetFocusedRowCellValue("year_after").ToString)
            TEBudgetKurs.EditValue = FormSampleBudgetDet.GVAfter.GetFocusedRowCellValue("kurs_after")
            TEBudgetUSD.EditValue = FormSampleBudgetDet.GVAfter.GetFocusedRowCellValue("value_usd_after")
            TEBudgetRp.EditValue = FormSampleBudgetDet.GVAfter.GetFocusedRowCellValue("value_rp_after")
            '
            Dim divs() As String = FormSampleBudgetDet.GVAfter.GetFocusedRowCellValue("id_division_after").ToString.Split(",")
            For Each div As String In divs
                GVDivision.ActiveFilterString = "[id_code_detail] = '" & div.ToString & "'"
                If GVDivision.RowCount > 0 Then
                    GVDivision.SetRowCellValue(0, "is_check", "yes")
                End If
                GVDivision.ActiveFilterString = ""
            Next div
            BtnSave.Text = "Update"
        Else
            BtnSave.Text = "Insert"
        End If
    End Sub

    Sub load_division()
        Dim query As String = "SELECT 'no' AS is_check,cd.* FROM tb_m_code_detail cd
WHERE cd.`id_code`='16' OR cd.id_code='40'"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCDivision.DataSource = data
        GVDivision.BestFitColumns()
    End Sub

    Private Sub FormSampleBudgetSingle_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub BtnCancel_Click(sender As Object, e As EventArgs) Handles BtnCancel.Click
        Close()
    End Sub

    Private Sub BtnSave_Click(sender As Object, e As EventArgs) Handles BtnSave.Click
        GVDivision.ActiveFilterString = "[is_check] = 'yes'"
        If GVDivision.RowCount <= 0 Then
            warningCustom("Please select division to budget")
        ElseIf TEDescription.Text = "" Then
            warningCustom("Please input description first")
        ElseIf TEBudgetKurs.EditValue <= 0 Then
            warningCustom("Please input Kurs")
        ElseIf TEBudgetUSD.EditValue < 0 Then
            warningCustom("Please input USD budget")
        ElseIf TEBudgetRp.EditValue < 0 Then
            warningCustom("Please input Rp budget")
        Else
            Dim is_on_grid As Boolean = False
            Dim is_on_propose As Boolean = False
            Dim is_on_db As Boolean = False
            '
            Dim notif_string As String = "Note : "
            'check on grid
            For i As Integer = 0 To FormSampleBudgetDet.GVAfter.RowCount - 1
                For j As Integer = 0 To GVDivision.RowCount - 1
                    'MsgBox("Is edit : " & is_edit & " | is_rev : " & FormSampleBudgetDet.is_rev & " | j=" & i & " | focuse row handle : " & FormSampleBudgetDet.GVAfter.FocusedRowHandle)
                    If (is_edit = "1" And FormSampleBudgetDet.GVAfter.FocusedRowHandle = i) Then
                    Else
                        If ("," & FormSampleBudgetDet.GVAfter.GetRowCellValue(i, "id_division_after").ToString & ",").Contains(GVDivision.GetRowCellValue(j, "id_code_detail").ToString) Then
                            notif_string += vbNewLine & GVDivision.GetRowCellValue(j, "code_detail_name").ToString & "  " & Date.Parse(DEYearBudget.EditValue).ToString("yyyy") & " already on list."
                            is_on_grid = True
                        End If
                    End If
                Next
            Next

            'check on propose
            For j As Integer = 0 To GVDivision.RowCount - 1
                Dim query_cek_pps As String = "SELECT pp.*,ppdiv.`id_code_division`,ppd.`year_after` FROM `tb_sample_budget_pps_div` ppdiv
INNER JOIN `tb_sample_budget_pps_det` ppd ON ppd.`id_sample_budget_pps_det`=ppdiv.`id_sample_budget_pps_det`
INNER JOIN `tb_sample_budget_pps` pp ON pp.`id_sample_budget_pps`=ppd.`id_sample_budget_pps`
WHERE ppdiv.`is_after` = '1' AND pp.`id_report_status`!=5 AND pp.`id_report_status`!=6
AND id_code_division='" & GVDivision.GetRowCellValue(j, "id_code_detail").ToString & "' AND year_after='" & Date.Parse(DEYearBudget.EditValue).ToString("yyyy") & "'"
                Dim data_cek_pps As DataTable = execute_query(query_cek_pps, -1, True, "", "", "", "")
                If data_cek_pps.Rows.Count > 0 Then
                    notif_string += vbNewLine & GVDivision.GetRowCellValue(j, "code_detail_name").ToString & "  " & Date.Parse(DEYearBudget.EditValue).ToString("yyyy") & " already proposed."
                    is_on_propose = True
                End If
            Next

            If Not FormSampleBudgetDet.is_rev = "1" Then 'not revision
                'check on budget already there or not
                For j As Integer = 0 To GVDivision.RowCount - 1
                    Dim query_cek_db As String = "SELECT * FROM `tb_sample_purc_budget_div` bd
INNER JOIN `tb_sample_purc_budget` pb ON pb.id_sample_purc_budget=bd.id_sample_purc_budget
WHERE pb.id_sample_purc_budget != 0 AND bd.id_code_division='" & GVDivision.GetRowCellValue(j, "id_code_detail").ToString & "' AND pb.year='" & Date.Parse(DEYearBudget.EditValue).ToString("yyyy") & "'"
                    Dim data_cek_db As DataTable = execute_query(query_cek_db, -1, True, "", "", "", "")
                    If data_cek_db.Rows.Count > 0 Then
                        notif_string += vbNewLine & GVDivision.GetRowCellValue(j, "code_detail_name").ToString & "  " & Date.Parse(DEYearBudget.EditValue).ToString("yyyy") & " already registered, use revision to change."
                        is_on_db = True
                    End If
                Next
            End If
            '
            If is_on_db = False And is_on_propose = False And is_on_grid = False Then
                '
                Dim id_code_detail As String = ""
                Dim code_detail As String = ""
                For i As Integer = 0 To GVDivision.RowCount - 1
                    If Not i = 0 Then
                        id_code_detail += ","
                        code_detail += ","
                    End If
                    id_code_detail += GVDivision.GetRowCellValue(i, "id_code_detail").ToString
                    code_detail += GVDivision.GetRowCellValue(i, "code_detail_name").ToString
                Next

                If is_edit = "1" Then
                    FormSampleBudgetDet.GVAfter.SetFocusedRowCellValue("description_after", TEDescription.Text)
                    FormSampleBudgetDet.GVAfter.SetFocusedRowCellValue("year_after", Date.Parse(DEYearBudget.EditValue).ToString("yyyy"))
                    FormSampleBudgetDet.GVAfter.SetFocusedRowCellValue("value_usd_after", TEBudgetUSD.EditValue)
                    FormSampleBudgetDet.GVAfter.SetFocusedRowCellValue("value_rp_after", TEBudgetRp.EditValue)
                    FormSampleBudgetDet.GVAfter.SetFocusedRowCellValue("kurs_after", TEBudgetKurs.EditValue)
                    FormSampleBudgetDet.GVAfter.SetFocusedRowCellValue("id_division_after", id_code_detail)
                    FormSampleBudgetDet.GVAfter.SetFocusedRowCellValue("division_after", code_detail)
                    FormSampleBudgetDet.GCAfter.RefreshDataSource()
                    FormSampleBudgetDet.GVAfter.RefreshData()
                    Close()
                Else
                    Dim newRow As DataRow = (TryCast(FormSampleBudgetDet.GCAfter.DataSource, DataTable)).NewRow()
                    newRow("description_after") = TEDescription.Text
                    newRow("year_after") = Date.Parse(DEYearBudget.EditValue.ToString).ToString("yyyy")
                    newRow("value_usd_after") = TEBudgetUSD.EditValue
                    newRow("value_rp_after") = TEBudgetRp.EditValue
                    newRow("kurs_after") = TEBudgetKurs.EditValue
                    newRow("id_division_after") = id_code_detail
                    newRow("division_after") = code_detail
                    TryCast(FormSampleBudgetDet.GCAfter.DataSource, DataTable).Rows.Add(newRow)
                    FormSampleBudgetDet.GCAfter.RefreshDataSource()
                    FormSampleBudgetDet.GVAfter.RefreshData()
                    FormSampleBudgetDet.GVAfter.FocusedRowHandle = FormSampleBudgetDet.GVAfter.RowCount - 1
                End If
            Else
                infoCustom(notif_string)
            End If
        End If
        GVDivision.ActiveFilterString = ""
    End Sub
End Class