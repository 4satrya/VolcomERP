Public Class FormFGCodeReplace
    Dim bnew_active As String = "1"
    Dim bedit_active As String = "1"
    Dim bdel_active As String = "1"
    Public form_type As String = "1"

    Private Sub FormCodeReplace_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        viewCodeReplaceStore()
        viewCodeReplaceWH()
        load_complete()
    End Sub

    Private Sub FormCodeReplace_Activated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Activated
        FormMain.show_rb(Name)
        checkFormAccess(Name)
        button_main(bnew_active, bedit_active, bdel_active)
    End Sub

    Private Sub FormCodeReplace_Deactivate(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Deactivate
        FormMain.hide_rb()
    End Sub

    Sub viewCodeReplaceStore()
        Dim query_c As ClassFGCodeReplace = New ClassFGCodeReplace()
        Dim query As String = ""
        If form_type = "2" Then
            query = query_c.queryMainStore("AND rep.id_report_status=6 ", "2")
            GridColumnStatus.Visible = False
        ElseIf form_type = "3" Then
            query = query_c.queryMainStore("AND rep.id_report_status=6 AND rep.is_printed=1 ", "2")
            GridColumnStatus.Visible = False
            CENotPrintedYet.Visible = False
        Else
            query = query_c.queryMainStore("-1", "2")
        End If
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCFGCodeReplaceStore.DataSource = data
        GVFGCodeReplaceStore.BestFitColumns()
        check_menu()
    End Sub

    Sub load_complete()
        Dim query As String = "SELECT 'no' AS is_check,rep.id_fg_code_replace_store, rep.fg_code_replace_store_number, rep.fg_code_replace_store_date,
DATE_FORMAT(rep.fg_code_replace_store_date, '%Y-%m-%d') AS fg_code_replace_store_datex, rep.id_report_status, rep_status.report_status, rep.fg_code_replace_store_note, rep.is_verified, rep.verified_date, rep.verified_by, e.employee_name AS `verified_by_name`, rep.is_printed, IF(rep.is_printed=1,'Printed','-') AS `print_status`, rep.printed_date, rep.printed_by, ep.employee_name AS `printed_by_name`
,maxd.employee_name AS complete_by,maxd.report_mark_datetime AS completed_date
FROM tb_fg_code_replace_store rep
INNER JOIN tb_lookup_report_status rep_status ON rep_status.id_report_status = rep.id_report_status
LEFT JOIN tb_m_user u ON u.id_user = rep.verified_by
LEFT JOIN tb_m_employee e ON e.id_employee = u.id_employee
LEFT JOIN tb_m_user up ON up.id_user = rep.printed_by
LEFT JOIN tb_m_employee ep ON ep.id_employee = up.id_employee
LEFT JOIN
(
	SELECT mark.id_report_mark,mark.id_report,emp.employee_name,maxd.report_mark_datetime,mark.report_number
	FROM tb_report_mark mark
	INNER JOIN tb_m_employee emp ON emp.`id_employee`=mark.id_employee
	INNER JOIN 
	(
	    SELECT mark.id_report,mark.report_mark_type,MAX(report_mark_datetime) AS report_mark_datetime
	    FROM tb_report_mark mark
	    WHERE mark.id_mark='2' AND NOT ISNULL(report_mark_start_datetime) AND report_mark_type='65'
	    GROUP BY report_mark_type,id_report
	) maxd ON maxd.id_report=mark.id_report AND maxd.report_mark_type=mark.report_mark_type AND maxd.report_mark_datetime=mark.report_mark_datetime
	WHERE mark.id_mark='2' AND NOT ISNULL(mark.report_mark_start_datetime) AND mark.report_mark_type='65' 
) maxd ON maxd.id_report = rep.id_fg_code_replace_store
WHERE rep.id_fg_code_replace_store>'0'
ORDER BY rep.id_fg_code_replace_store DESC"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCComplete.DataSource = data
        GVComplete.BestFitColumns()
    End Sub

    Sub viewCodeReplaceWH()
        Dim query_c As ClassFGCodeReplace = New ClassFGCodeReplace()
        Dim query As String = query_c.queryMainWH("-1", "2")
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCFGCodeReplaceWH.DataSource = data
        check_menu()
    End Sub

    Sub check_menu()
        If XTCFGCodeReplace.SelectedTabPageIndex = 0 Then
            'based on receive
            If XTCList.SelectedTabPageIndex = 0 Then
                If GVFGCodeReplaceStore.RowCount < 1 Then
                    'hide all except new
                    bnew_active = "1"
                    bedit_active = "0"
                    bdel_active = "0"
                    checkFormAccess(Name)
                    button_main(bnew_active, bedit_active, bdel_active)
                Else
                    'show all
                    bnew_active = "1"
                    bedit_active = "1"
                    bdel_active = "1"
                    noManipulating()
                End If
            Else
                bnew_active = "0"
                bedit_active = "0"
                bdel_active = "0"
                checkFormAccess(Name)
                button_main(bnew_active, bedit_active, bdel_active)
            End If
        ElseIf XTCFGCodeReplace.SelectedTabPageIndex = 1 Then
            'based on receive
            If GVFGCodeReplaceWH.RowCount < 1 Then
                'hide all except new
                bnew_active = "1"
                bedit_active = "0"
                bdel_active = "0"
                checkFormAccess(Name)
                button_main(bnew_active, bedit_active, bdel_active)
            Else
                'show all
                bnew_active = "1"
                bedit_active = "1"
                bdel_active = "1"
                noManipulating()
            End If
        End If
    End Sub

    Sub noManipulating()
        Try
            If XTCFGCodeReplace.SelectedTabPageIndex = 0 Then
                Dim indeks As Integer = GVFGCodeReplaceStore.FocusedRowHandle
                If indeks < 0 Then
                    bnew_active = "1"
                    bedit_active = "0"
                    bdel_active = "0"
                Else
                    bnew_active = "1"
                    bedit_active = "1"
                    bdel_active = "1"
                End If
            ElseIf XTCFGCodeReplace.SelectedTabPageIndex = 1 Then
                Dim indeks As Integer = GVFGCodeReplaceWH.FocusedRowHandle
                If indeks < 0 Then
                    bnew_active = "1"
                    bedit_active = "0"
                    bdel_active = "0"
                Else
                    bnew_active = "1"
                    bedit_active = "1"
                    bdel_active = "1"
                End If
            End If
            checkFormAccess(Name)
            button_main(bnew_active, bedit_active, bdel_active)
        Catch ex As Exception
        End Try
    End Sub

    Private Sub XTCFGCodeReplace_SelectedPageChanged(ByVal sender As System.Object, ByVal e As DevExpress.XtraTab.TabPageChangedEventArgs) Handles XTCFGCodeReplace.SelectedPageChanged
        check_menu()
    End Sub

    Private Sub GVFGCodeReplaceStore_DoubleClick(sender As Object, e As EventArgs) Handles GVFGCodeReplaceStore.DoubleClick
        If GVFGCodeReplaceStore.RowCount > 0 And GVFGCodeReplaceStore.FocusedRowHandle >= 0 Then
            FormMain.but_edit()
        End If
    End Sub

    Private Sub BViewUnique_Click(sender As Object, e As EventArgs) Handles BViewUnique.Click
        Dim where_string As String = ""

        If GVFGCodeReplaceStore.RowCount > 0 Then
            Cursor = Cursors.WaitCursor
            'search id det
            makeSafeGV(GVFGCodeReplaceStore)
            GVFGCodeReplaceStore.ActiveFilterString = "[is_check]='yes'"
            If GVFGCodeReplaceStore.RowCount > 0 Then
                For i As Integer = 0 To GVFGCodeReplaceStore.RowCount - 1
                    If i = 0 Then
                        where_string = GVFGCodeReplaceStore.GetRowCellValue(i, "id_fg_code_replace_store").ToString
                    Else
                        where_string += "," & GVFGCodeReplaceStore.GetRowCellValue(i, "id_fg_code_replace_store").ToString
                    End If
                Next
                makeSafeGV(GVFGCodeReplaceStore)
                CENotPrintedYet.EditValue = False
                '
                FormFGCodeReplaceView.id = where_string
                FormFGCodeReplaceView.load_view()
                FormFGCodeReplaceView.ShowDialog()
                Cursor = Cursors.Default
            Else
                stopCustom("Please choose document first.")
                makeSafeGV(GVFGCodeReplaceStore)
                CENotPrintedYet.EditValue = False
            End If
        End If
    End Sub

    Private Sub CEAll_CheckedChanged(sender As Object, e As EventArgs) Handles CEAll.CheckedChanged
        If GVFGCodeReplaceStore.RowCount > 0 Then
            Dim cek As String = CEAll.EditValue.ToString
            For i As Integer = 0 To ((GVFGCodeReplaceStore.RowCount - 1) - GetGroupRowCount(GVFGCodeReplaceStore))
                If cek Then
                    GVFGCodeReplaceStore.SetRowCellValue(i, "is_check", "yes")
                Else
                    GVFGCodeReplaceStore.SetRowCellValue(i, "is_check", "no")
                End If
            Next
        End If
    End Sub

    Private Sub CENotPrintedYet_CheckedChanged(sender As Object, e As EventArgs) Handles CENotPrintedYet.CheckedChanged
        makeSafeGV(GVFGCodeReplaceStore)
        If CENotPrintedYet.EditValue = True Then
            GVFGCodeReplaceStore.ActiveFilterString = "[print_status]='-' "
        Else
            GVFGCodeReplaceStore.ActiveFilterString = ""
        End If
    End Sub

    Private Sub GVComplete_DoubleClick(sender As Object, e As EventArgs) Handles GVComplete.DoubleClick
        FormFGCodeReplaceStoreDet.form_type = "1"
        FormFGCodeReplaceStoreDet.action = "upd"
        FormFGCodeReplaceStoreDet.id_fg_code_replace_store = GVComplete.GetFocusedRowCellValue("id_fg_code_replace_store").ToString
        FormFGCodeReplaceStoreDet.ShowDialog()
    End Sub

    Private Sub XTCList_SelectedPageChanged(sender As Object, e As DevExpress.XtraTab.TabPageChangedEventArgs) Handles XTCList.SelectedPageChanged
        check_menu()
    End Sub
End Class