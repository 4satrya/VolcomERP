Public Class FormWork
    Dim bview_active As String = "1"
    Dim i As Integer = 0
    Private Sub FormWork_Activated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Activated
        FormMain.show_rb(Name)
        check_menu()
    End Sub

    Private Sub FormWork_Deactivate(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Deactivate
        FormMain.hide_rb()
    End Sub

    Private Sub FormWork_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        checkFormAccess(Name)
        DEStart.EditValue = Now
        DEUntil.EditValue = Now
        '
        DEStart.EditValue = Now.AddMonths(-3)
        '
    End Sub
    '=============== begin mark tab =======================
    Private Sub BViewApproval_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BViewApproval.Click
        Cursor = Cursors.WaitCursor
        view_mark_need()
        Cursor = Cursors.Default
    End Sub

    Private Sub BViewHistory_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BViewHistory.Click
        Cursor = Cursors.WaitCursor
        view_mark_history()
        Cursor = Cursors.Default
    End Sub
    Sub view_mark_need()
        Dim query = "SELECT a.id_mark, a.info , a.info_design ,a.info_design_code ,a.info_report , a.report_mark_type , a.id_report , a.id_report_status , c.report_status , b.report_mark_type_name "
        query += ",a.report_mark_start_datetime AS date_time_start "
        query += ",ADDTIME(report_mark_start_datetime,report_mark_lead_time) AS lead_time "
        query += ",ADDTIME(report_mark_start_datetime,report_mark_lead_time) AS raw_lead_time "
        query += ",TIME_TO_SEC(TIMEDIFF(NOW(),((ADDTIME(report_mark_start_datetime,report_mark_lead_time))))) AS time_miss, report_date, report_number "
        query += "FROM tb_report_mark a "
        query += "INNER JOIN tb_lookup_report_mark_type b ON b.report_mark_type = a.report_mark_type "
        query += "INNER JOIN tb_lookup_report_status c ON c.id_report_status = a.id_report_status "
        query += "LEFT JOIN 
                    (
	                    SELECT report_mark_type,id_report,id_mark_asg,COUNT(id_report_mark) AS jml FROM tb_report_mark WHERE id_mark!=1 GROUP BY report_mark_type,id_report,id_mark_asg
                    ) mark ON  a.report_mark_type=mark.report_mark_type AND a.id_report=mark.id_report AND a.id_mark_asg=mark.id_mark_asg "
        query += "WHERE a.id_mark = 1 AND a.id_user ='" & id_user & "' AND NOW()>a.report_mark_start_datetime "
        query += "AND IFNULL(mark.jml,0) < 1 "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")

        GCMarkNeed.DataSource = data
        GVMarkNeed.BestFitColumns()
        Try
            FormMain.checkNumberNotif()
        Catch ex As Exception
        End Try
        Try
            FormNotification.viewNotif()
        Catch ex As Exception
        End Try
    End Sub

    Sub view_mark_approved(ByVal date_start As String, ByVal date_until As String)

        Dim query = "SELECT a.id_mark , a.info, a.info_design ,a.info_design_code ,a.info_report , a.report_mark_type , a.id_report , a.id_report_status , c.report_status , b.report_mark_type_name, a.report_mark_datetime "
        query += ",a.report_mark_start_datetime AS date_time_start,mark.mark "
        query += ",ADDTIME(report_mark_start_datetime,report_mark_lead_time) AS lead_time "
        query += ",ADDTIME(report_mark_start_datetime,report_mark_lead_time) AS raw_lead_time "
        query += ",YEAR(a.report_mark_datetime) as y_datetime,MONTHNAME(STR_TO_DATE(MONTH(a.report_mark_datetime), '%m')) as m_datetime "
        query += ",TIME_TO_SEC(TIMEDIFF(NOW(),((ADDTIME(report_mark_start_datetime,report_mark_lead_time))))) AS time_miss, report_date, report_number "
        query += "FROM tb_report_mark a "
        query += "INNER JOIN tb_lookup_report_mark_type b ON b.report_mark_type = a.report_mark_type "
        query += "INNER JOIN tb_lookup_mark mark ON mark.id_mark=a.id_mark "
        query += "INNER JOIN tb_lookup_report_status c ON c.id_report_status = a.id_report_status "
        query += "WHERE DATE(a.report_mark_datetime) >='" & date_start & "' AND DATE(a.report_mark_datetime) <='" & date_until & "' AND a.id_mark != 1 AND a.id_user ='" & id_user & "' AND NOT ISNULL(a.report_mark_datetime) ORDER BY a.report_mark_datetime DESC "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")

        GCMarkApproved.DataSource = data
        GVMarkApproved.BestFitColumns()
    End Sub

    Sub view_mark_declined(ByVal date_start As String, ByVal date_until As String)
        Dim query = "SELECT a.id_mark , a.info, a.info_design ,a.info_design_code ,a.info_report , a.report_mark_type , a.id_report , a.id_report_status , c.report_status , b.report_mark_type_name, a.report_mark_datetime "
        query += ",a.report_mark_start_datetime AS date_time_start,mark.mark "
        query += ",ADDTIME(report_mark_start_datetime,report_mark_lead_time) AS lead_time "
        query += ",ADDTIME(report_mark_start_datetime,report_mark_lead_time) AS raw_lead_time "
        query += ",YEAR(a.report_mark_datetime) as y_datetime,MONTHNAME(STR_TO_DATE(MONTH(a.report_mark_datetime), '%m')) as m_datetime "
        query += ",TIME_TO_SEC(TIMEDIFF(NOW(),((ADDTIME(report_mark_start_datetime,report_mark_lead_time))))) AS time_miss, report_date, report_number "
        query += "FROM tb_report_mark a "
        query += "INNER JOIN tb_lookup_report_mark_type b ON b.report_mark_type = a.report_mark_type "
        query += "INNER JOIN tb_lookup_mark mark ON mark.id_mark=a.id_mark "
        query += "INNER JOIN tb_lookup_report_status c ON c.id_report_status = a.id_report_status "
        query += "WHERE DATE(a.report_mark_datetime) >='" & date_start & "' AND DATE(a.report_mark_datetime) <='" & date_until & "' AND a.id_mark != 1 AND a.id_user ='" & id_user & "' AND NOT ISNULL(a.report_mark_datetime) ORDER BY a.report_mark_datetime DESC "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")

        GCMarkDeclined.DataSource = data
        GVMarkDeclined.BestFitColumns()
    End Sub

    Sub view_mark_history()
        Dim date_start, date_until As String

        date_start = Date.Parse(DEStart.EditValue.ToString).ToString("yyyy-MM-dd")
        date_until = Date.Parse(DEUntil.EditValue.ToString).ToString("yyyy-MM-dd")

        Dim query = "SELECT a.id_mark , a.info, a.info_design ,a.info_design_code ,a.info_report , a.report_mark_type , a.id_report , a.id_report_status , c.report_status , b.report_mark_type_name, a.report_mark_datetime "
        query += ",a.report_mark_start_datetime AS date_time_start,mark.mark "
        query += ",ADDTIME(report_mark_start_datetime,report_mark_lead_time) AS lead_time "
        query += ",ADDTIME(report_mark_start_datetime,report_mark_lead_time) AS raw_lead_time "
        query += ",YEAR(a.report_mark_datetime) as y_datetime,MONTHNAME(STR_TO_DATE(MONTH(a.report_mark_datetime), '%m')) as m_datetime "
        query += ",TIME_TO_SEC(TIMEDIFF(NOW(),((ADDTIME(report_mark_start_datetime,report_mark_lead_time))))) AS time_miss, report_date, report_number "
        query += "FROM tb_report_mark a "
        query += "INNER JOIN tb_lookup_report_mark_type b ON b.report_mark_type = a.report_mark_type "
        query += "INNER JOIN tb_lookup_mark mark ON mark.id_mark=a.id_mark "
        query += "INNER JOIN tb_lookup_report_status c ON c.id_report_status = a.id_report_status "
        query += "WHERE DATE(a.report_mark_datetime) >='" & date_start & "' AND DATE(a.report_mark_datetime) <='" & date_until & "' AND a.id_mark != 1 AND a.id_user ='" & id_user & "' AND NOT ISNULL(a.report_mark_datetime) ORDER BY a.report_mark_datetime DESC "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")

        GCMarkApproved.DataSource = data
        GVMarkApproved.BestFitColumns()
    End Sub
    Private Sub GVMarkNeed_RowCellStyle(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs) Handles GVMarkNeed.RowCellStyle
        Dim lead_time As String = sender.GetRowCellDisplayText(e.RowHandle, sender.Columns("time_miss"))
        'condition
        If Not lead_time = "" Then
            If Integer.Parse(lead_time) > 0 Then
                e.Appearance.BackColor = Color.Salmon
                e.Appearance.BackColor2 = Color.Salmon
            End If
        End If
    End Sub



    Private Sub GVMarkNeed_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GVMarkNeed.DoubleClick
        view_popup_gv_mark()
    End Sub

    Private Sub GVMarkHistory_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GVMarkApproved.DoubleClick
        view_popup_gv_mark()
    End Sub
    Sub view_popup_gv_mark()
        If XTCMark.SelectedTabPageIndex = 0 Then
            If GVMarkNeed.RowCount > 0 Then
                Dim report_mark_type As String = "-1"
                Dim id_report As String = "-1"

                report_mark_type = GVMarkNeed.GetFocusedRowCellValue("report_mark_type").ToString
                id_report = GVMarkNeed.GetFocusedRowCellValue("id_report").ToString

                Dim showpopup As ClassShowPopUp = New ClassShowPopUp()
                showpopup.report_mark_type = report_mark_type
                showpopup.id_report = id_report
                showpopup.show()
            End If
        Else 'history
            If GVMarkApproved.RowCount > 0 Then
                Dim report_mark_type As String = "-1"
                Dim id_report As String = "-1"

                report_mark_type = GVMarkApproved.GetFocusedRowCellValue("report_mark_type").ToString
                id_report = GVMarkApproved.GetFocusedRowCellValue("id_report").ToString

                Dim showpopup As ClassShowPopUp = New ClassShowPopUp()
                showpopup.report_mark_type = report_mark_type
                showpopup.id_report = id_report
                showpopup.show()
            End If
        End If
    End Sub

    Sub check_menu()
        If XTCGeneral.SelectedTabPageIndex = 0 Then
            'sample
            If XTCMark.SelectedTabPageIndex = 0 Then
                If GVMarkNeed.RowCount < 1 Then
                    'hide
                    bview_active = "0"
                Else
                    bview_active = "1"
                End If
            End If
        End If
    End Sub

    Private Sub GVMarkHistory_FocusedRowChanged(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles GVMarkApproved.FocusedRowChanged
        no_focus_gv(sender, e)
    End Sub
    Sub no_focus_gv(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs)
        Dim focusedRowHandle As Integer = -1
        If e.FocusedRowHandle = DevExpress.XtraGrid.GridControl.NewItemRowHandle OrElse e.FocusedRowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            Return
        End If
        Dim view As DevExpress.XtraGrid.Views.Grid.GridView = CType(sender, DevExpress.XtraGrid.Views.Grid.GridView)
        If e.FocusedRowHandle < 0 Then
            If e.PrevFocusedRowHandle = DevExpress.XtraGrid.GridControl.InvalidRowHandle Then
                focusedRowHandle = 0
            ElseIf Control.MouseButtons = MouseButtons.Left OrElse Control.MouseButtons = MouseButtons.Right Then
                focusedRowHandle = e.PrevFocusedRowHandle
            Else
                Dim prevRow As Integer = view.GetVisibleIndex(e.PrevFocusedRowHandle)
                Dim currRow As Integer = view.GetVisibleIndex(e.FocusedRowHandle)
                If prevRow > currRow Then
                    focusedRowHandle = e.PrevFocusedRowHandle - 1
                Else
                    focusedRowHandle = e.PrevFocusedRowHandle + 1
                End If
                If focusedRowHandle < 0 Then
                    focusedRowHandle = 0
                End If
                If focusedRowHandle >= view.DataRowCount Then
                    focusedRowHandle = view.DataRowCount - 1
                End If
            End If
            If focusedRowHandle < 0 Then
                view.FocusedRowHandle = 0
            Else
                view.FocusedRowHandle = focusedRowHandle
            End If
        End If
    End Sub
    '=============== end mark tab =========================
    Private Sub DEStart_EditValueChanged(sender As Object, e As EventArgs) Handles DEStart.EditValueChanged
        Try
            DEUntil.Properties.MinValue = DEStart.EditValue
        Catch ex As Exception
        End Try
    End Sub

    Private Sub FormWork_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.F2 Then
            Cursor = Cursors.WaitCursor
            Dim query_cek As String = "SELECT COUNT(*) AS `jum` FROM tb_work_quick_user w WHERE w.id_user='" + id_user + "' "
            Dim data_cek As DataTable = execute_query(query_cek, -1, True, "", "", "", "")
            If data_cek.Rows(0)("jum") > 0 Then
                FormWorkQuick.ShowDialog()
            End If
            Cursor = Cursors.Default
        End If
    End Sub
End Class