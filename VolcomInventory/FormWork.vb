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
        DEStartCancel.EditValue = Now
        DEEndCancel.EditValue = Now
        If id_user = get_setup_field("id_user_cancel_management") Or id_role_login = get_setup_field("id_role_super_admin") Then
            XTPCancelApproval.PageVisible = True
        Else
            XTPCancelApproval.PageVisible = False
        End If
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
        Dim query = "SELECT a.id_mark, a.info , a.info_design ,a.info_design_code ,a.info_report , a.report_mark_type , a.id_report , a.id_report_status , c.report_status , b.report_mark_type_name 
                    ,a.report_mark_start_datetime AS date_time_start 
                    ,ADDTIME(report_mark_start_datetime,report_mark_lead_time) AS lead_time 
                    ,ADDTIME(report_mark_start_datetime,report_mark_lead_time) AS raw_lead_time 
                    ,TIME_TO_SEC(TIMEDIFF(NOW(),((ADDTIME(report_mark_start_datetime,report_mark_lead_time))))) AS time_miss, report_date, report_number 
                    FROM tb_report_mark a 
                    INNER JOIN tb_lookup_report_mark_type b ON b.report_mark_type = a.report_mark_type 
                    INNER JOIN tb_lookup_report_status c ON c.id_report_status = a.id_report_status 
                    LEFT JOIN 
                    (
	                    SELECT report_mark_type,id_report,id_mark_asg,COUNT(id_report_mark) AS jml FROM tb_report_mark WHERE id_mark!=1 GROUP BY report_mark_type,id_report,id_mark_asg
                    ) mark ON  a.report_mark_type=mark.report_mark_type AND a.id_report=mark.id_report AND a.id_mark_asg=mark.id_mark_asg 
                    LEFT JOIN 
                    (
	                    SELECT rm.id_report,rm.id_report_status,rm.`id_mark_asg`,rm.report_mark_type,SUM(IF(rm.`is_use`=1,1,0)) AS jml_req,SUM(IF(rm.`id_mark`=2,1,0)) AS jml_approve FROM tb_report_mark rm 
	                    WHERE rm.is_requisite=1
	                    GROUP BY rm.id_report_status,rm.id_report,rm.report_mark_type
                    ) req ON a.id_report_status=req.id_report_status AND a.id_report=req.id_report AND a.report_mark_type=req.report_mark_type 
                    WHERE a.id_mark = 1 AND a.id_user ='" & id_user & "' AND NOW()>a.report_mark_start_datetime 
                    AND IFNULL(mark.jml,0) < 1 
                    -- ini yang ngurangi requisite dulu
                    AND IF(a.is_requisite=2,(IFNULL(req.jml_approve,0) = IFNULL(req.jml_req,0)),TRUE)
                    AND a.is_on_hold=2"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")

        GCMarkNeed.DataSource = data
        GVMarkNeed.BestFitColumns()
        Try
            FormMain.checkNumberNotif()
        Catch ex As Exception
        End Try
        Try
            'FormNotification.viewNotif()
        Catch ex As Exception
        End Try
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

        GCMarkHistory.DataSource = data
        GVMarkHistory.BestFitColumns()
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

    Private Sub GVMarkHistory_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GVMarkHistory.DoubleClick
        view_popup_gv_mark()
    End Sub

    Sub view_popup_gv_mark()
        If XTCMark.SelectedTabPageIndex = 0 Then
            If GVMarkNeed.RowCount > 0 Then
                Cursor = Cursors.WaitCursor
                Dim report_mark_type As String = "-1"
                Dim id_report As String = "-1"

                report_mark_type = GVMarkNeed.GetFocusedRowCellValue("report_mark_type").ToString
                id_report = GVMarkNeed.GetFocusedRowCellValue("id_report").ToString

                Dim showpopup As ClassShowPopUp = New ClassShowPopUp()
                showpopup.report_mark_type = report_mark_type
                showpopup.id_report = id_report
                showpopup.show()
                Cursor = Cursors.Default
            End If
        Else 'history
            If GVMarkHistory.RowCount > 0 Then
                Dim report_mark_type As String = "-1"
                Dim id_report As String = "-1"

                report_mark_type = GVMarkHistory.GetFocusedRowCellValue("report_mark_type").ToString
                id_report = GVMarkHistory.GetFocusedRowCellValue("id_report").ToString

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
        ElseIf XTCGeneral.SelectedTabPageIndex = 1 Then
            'approve cancel
            If XtraTabControl1.SelectedTabPageIndex = 0 Then
                If GVCancelApproval.RowCount < 1 Then
                    'hide
                    bview_active = "0"
                Else
                    bview_active = "1"
                End If
            End If
        End If
    End Sub

    Private Sub GVMarkHistory_FocusedRowChanged(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles GVMarkHistory.FocusedRowChanged
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
    '======================== cancel approval ======================================
    Private Sub BRefreshCancelApproval_Click(sender As Object, e As EventArgs) Handles BRefreshCancelApproval.Click
        view_cancel_list()
    End Sub

    Sub view_cancel_list()
        Dim query As String = "SELECT rmc.id_report_mark_cancel ,rmt.report_mark_type_name FROM tb_report_mark_cancel rmc 
                                INNER JOIN tb_lookup_report_mark_type rmt ON rmt.report_mark_type=rmc.report_mark_type
                                WHERE rmc.id_report_status='4'"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCCancelApproval.DataSource = data
    End Sub

    Private Sub GVCancelApproval_DoubleClick(sender As Object, e As EventArgs) Handles GVCancelApproval.DoubleClick
        If GVCancelApproval.RowCount > 0 Then
            FormReportMarkCancel.is_complete = "1"
            FormReportMarkCancel.id_report_mark_cancel = GVCancelApproval.GetFocusedRowCellValue("id_report_mark_cancel")
            FormReportMarkCancel.ShowDialog()
        End If
    End Sub

    Sub history_cancel()
        Dim date_start, date_until As String

        date_start = Date.Parse(DEStart.EditValue.ToString).ToString("yyyy-MM-dd")
        date_until = Date.Parse(DEUntil.EditValue.ToString).ToString("yyyy-MM-dd")

        Dim query As String = "SELECT rmc.*,emp.`employee_name`,rmt.report_mark_type_name,emp_comp.employee_name AS name_complete FROM `tb_report_mark_cancel` rmc
                                INNER JOIN tb_m_user usr ON usr.`id_user`=rmc.`created_by`
                                INNER JOIN tb_m_employee emp ON emp.`id_employee`=usr.`id_employee`
                                LEFT JOIN tb_m_user usr_comp ON usr_comp.`id_user`=rmc.`user_complete`
                                LEFT JOIN tb_m_employee emp_comp ON emp_comp.`id_employee`=usr_comp.`id_employee`
                                INNER JOIN tb_lookup_report_mark_type rmt ON rmt.report_mark_type=rmc.report_mark_type AND rmc.id_report_status='6' AND DATE(rmc.complete_datetime) >='" & date_start & "' AND DATE(rmc.complete_datetime) <='" & date_until & "'"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCCancelApprovalHistory.DataSource = data
        GVCancelApprovalHistory.BestFitColumns()
    End Sub

    Private Sub BViewHistoryCancel_Click(sender As Object, e As EventArgs) Handles BViewHistoryCancel.Click
        history_cancel()
    End Sub

    Private Sub GVCancelApprovalHistory_DoubleClick(sender As Object, e As EventArgs) Handles GVCancelApprovalHistory.DoubleClick
        If GVCancelApprovalHistory.RowCount > 0 Then
            FormReportMarkCancel.is_view = "1"
            FormReportMarkCancel.id_report_mark_cancel = GVCancelApprovalHistory.GetFocusedRowCellValue("id_report_mark_cancel")
            FormReportMarkCancel.ShowDialog()
        End If
    End Sub
    '======================== end of cancel approval ======================================
End Class