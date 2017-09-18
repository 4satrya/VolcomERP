Public Class FormWorkQuick
    Private Sub FormWorkQuick_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        view_mark_need()
    End Sub

    Sub view_mark_need()
        Cursor = Cursors.WaitCursor
        Dim query = "SELECT a.id_report_mark,a.id_mark, a.info , a.info_design ,a.info_design_code ,a.info_report , a.report_mark_type , a.id_report , a.id_report_status , c.report_status , b.report_mark_type_name "
        query += ",a.report_mark_start_datetime AS date_time_start "
        query += ",ADDTIME(report_mark_start_datetime,report_mark_lead_time) AS lead_time "
        query += ",ADDTIME(report_mark_start_datetime,report_mark_lead_time) AS raw_lead_time "
        query += ",TIME_TO_SEC(TIMEDIFF(NOW(),((ADDTIME(report_mark_start_datetime,report_mark_lead_time))))) AS time_miss, report_date, report_number, "
        query += "('No') AS `is_select`, del.qty, del.from, del.to "
        query += "FROM tb_report_mark a "
        query += "INNER JOIN tb_lookup_report_mark_type b ON b.report_mark_type = a.report_mark_type "
        query += "INNER JOIN tb_lookup_report_status c ON c.id_report_status = a.id_report_status "
        query += "LEFT JOIN 
                    (
	                    SELECT report_mark_type,id_report,id_mark_asg,COUNT(id_report_mark) AS jml FROM tb_report_mark WHERE id_mark!=1 GROUP BY report_mark_type,id_report,id_mark_asg
                    ) mark ON  a.report_mark_type=mark.report_mark_type AND a.id_report=mark.id_report AND a.id_mark_asg=mark.id_mark_asg "
        query += "LEFT JOIN (
                    SELECT del.id_pl_sales_order_del, CONCAT(w.comp_number, ' - ', w.comp_name) AS `from`, CONCAT(s.comp_number, ' - ', s.comp_name) AS `to`
                    ,SUM(deld.pl_sales_order_del_det_qty) AS `qty`
                    FROM tb_pl_sales_order_del del
                    INNER JOIN tb_pl_sales_order_del_det deld ON deld.id_pl_sales_order_del = del.id_pl_sales_order_del
                    INNER JOIN tb_m_comp_contact wc ON wc.id_comp_contact = del.id_comp_contact_from
                    INNER JOIN tb_m_comp w ON w.id_comp = wc.id_comp
                    INNER JOIN tb_m_comp_contact sc ON sc.id_comp_contact = del.id_store_contact_to
                    INNER JOIN tb_m_comp s ON s.id_comp = sc.id_comp
                    GROUP BY del.id_pl_sales_order_del
                ) del ON del.id_pl_sales_order_del = a.id_report AND a.report_mark_type=43 "
        query += "WHERE a.id_mark = 1 AND a.id_user ='" & id_user & "' AND NOW()>a.report_mark_start_datetime "
        query += "AND IFNULL(mark.jml,0) < 1 "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")

        GCData.DataSource = data
        GVData.BestFitColumns()
        Try
            FormMain.checkNumberNotif()
        Catch ex As Exception
        End Try
        Try
            FormNotification.viewNotif()
        Catch ex As Exception
        End Try
        Cursor = Cursors.Default
    End Sub

    Private Sub FormWorkQuick_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs) Handles SimpleButton1.Click
        view_mark_need()
    End Sub

    Private Sub CheckEdit1_CheckedChanged(sender As Object, e As EventArgs) Handles CheckEdit1.CheckedChanged
        Dim cek As String = CheckEdit1.EditValue.ToString
        For i As Integer = 0 To ((GVData.RowCount - 1) - GetGroupRowCount(GVData))
            If cek Then
                GVData.SetRowCellValue(i, "is_select", "Yes")
            Else
                GVData.SetRowCellValue(i, "is_select", "No")
            End If
        Next
    End Sub

    Private Sub BAccept_Click(sender As Object, e As EventArgs) Handles BAccept.Click
        actionButton("2")
    End Sub

    Sub actionButton(ByVal id_mark_par)
        makeSafeGV(GVData)
        GVData.ActiveFilterString = "[is_select]='Yes'"
        If GVData.RowCount > 0 Then
            Dim confirm As DialogResult
            If id_mark_par = "2" Then
                confirm = DevExpress.XtraEditors.XtraMessageBox.Show("Are you sure you want to accept this report ?", "Approve Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
            Else
                confirm = DevExpress.XtraEditors.XtraMessageBox.Show("Are you sure want to refuse this report ?", "Not Approve Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
            End If
            If confirm = Windows.Forms.DialogResult.Yes Then
                updateStatus(id_mark_par)
                GVData.ActiveFilterString = ""
            Else
                GVData.ActiveFilterString = ""
            End If
        Else
            stopCustom("Please select list item first !")
        End If
    End Sub

    Sub updateStatus(ByVal id_mark_par As String)
        SplashScreenManager1.ShowWaitForm()
        For i As Integer = 0 To ((GVData.RowCount - 1) - GetGroupRowCount(GVData))
            'update all to 2
            Console.WriteLine(i.ToString)
            reset_is_use_mark(GVData.GetRowCellValue(i, "id_report_mark").ToString, "2")
            Dim query As String = "UPDATE tb_report_mark SET id_mark='" + id_mark_par + "',is_use='1',report_mark_note='" + addSlashes(MemoEdit1.Text) + "',report_mark_datetime=NOW() WHERE id_report_mark='" + GVData.GetRowCellValue(i, "id_report_mark").ToString + "' "
            execute_non_query(query, True, "", "", "", "")
            ' here auto approve
            Dim id_status_reportx As String = GVData.GetRowCellValue(i, "id_report_status").ToString
            Dim query_jml As String = "SELECT count(id_report_mark) FROM tb_report_mark WHERE report_mark_type='" + GVData.GetRowCellValue(i, "report_mark_type").ToString + "' AND id_report='" + GVData.GetRowCellValue(i, "id_report").ToString + "' AND id_report_status = '" + id_status_reportx + "' AND is_use='1'"
            Dim jml As Integer = execute_query(query_jml, 0, True, "", "", "", "")
            Dim assigned As Boolean = False
            If jml < 1 Then
                'no one assigned yet
                assigned = False
            Else
                assigned = True
                query_jml = String.Format("SELECT count(id_report_mark) FROM tb_report_mark WHERE report_mark_type='{0}' AND id_report='{1}' AND id_report_status <= '{2}' AND id_mark != '2' AND is_use='1'", GVData.GetRowCellValue(i, "report_mark_type").ToString, GVData.GetRowCellValue(i, "id_report").ToString, id_status_reportx)
                jml = execute_query(query_jml, 0, True, "", "", "", "")
            End If

            If (jml < 1 And assigned = True) Then
                change_status(GVData.GetRowCellValue(i, "report_mark_type").ToString, GVData.GetRowCellValue(i, "id_report").ToString, id_status_reportx)
            End If
        Next
        view_mark_need()
        FormWork.view_mark_need()
        SplashScreenManager1.CloseWaitForm()
    End Sub

    Private Sub BRefuse_Click(sender As Object, e As EventArgs) Handles BRefuse.Click
        actionButton("3")
    End Sub

    Sub change_status(ByVal report_mark_type As String, ByVal id_report As String, ByVal id_status_reportx As String)
        If report_mark_type = "37" Then
            'Rec PL FG TO WH
            Try
                Dim ch_stt As ClassProductionPLToWHRec = New ClassProductionPLToWHRec()
                ch_stt.changeStatus(id_report, id_status_reportx)
            Catch ex As Exception
                errorProcess()
            End Try
        ElseIf report_mark_type = "43" Then
            'SALES Del Order
            Dim stt As ClassSalesDelOrder = New ClassSalesDelOrder()
            stt.changeStatus(id_report, id_status_reportx)
        ElseIf report_mark_type = "46" Then
            'SALES RETURN
            Dim stt As ClassSalesReturn = New ClassSalesReturn()
            stt.changeStatus(id_report, id_status_reportx)
        ElseIf report_mark_type = "49" Then
            'SALES RETURN QC
            Dim st As ClassSalesReturnQC = New ClassSalesReturnQC()
            st.changeStatus(id_report, id_status_reportx)
        End If
    End Sub

    Private Sub GVData_DoubleClick(sender As Object, e As EventArgs) Handles GVData.DoubleClick
        If GVData.RowCount > 0 Then
            Cursor = Cursors.WaitCursor
            Dim report_mark_type As String = "-1"
            Dim id_report As String = "-1"

            report_mark_type = GVData.GetFocusedRowCellValue("report_mark_type").ToString
            id_report = GVData.GetFocusedRowCellValue("id_report").ToString

            Dim showpopup As ClassShowPopUp = New ClassShowPopUp()
            showpopup.report_mark_type = report_mark_type
            showpopup.id_report = id_report
            showpopup.show()
            Cursor = Cursors.Default
        End If
    End Sub
End Class