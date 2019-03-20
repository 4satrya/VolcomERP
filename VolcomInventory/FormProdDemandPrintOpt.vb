Public Class FormProdDemandPrintOpt
    Public id As String = "-1"
    Public rmt As String = "-1"

    Private Sub FormProdDemandPrintOpt_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ''checked
        'Dim qc As String = "SELECT rm.id_report_mark, e.employee_name
        'FROM tb_report_mark rm 
        'INNER JOIN tb_m_employee e ON e.id_employee = rm.id_employee
        'WHERE rm.report_mark_type=" + rmt + " AND rm.id_report=" + id + " AND rm.id_report_status=2 "
        'viewSearchLookupQuery(SLEChecked, qc, "id_report_mark", "employee_name", "id_report_mark")

        ''aproved
        'Dim qa As String = "SELECT rm.id_report_mark, e.employee_name
        'FROM tb_report_mark rm 
        'INNER JOIN tb_m_employee e ON e.id_employee = rm.id_employee
        'WHERE rm.report_mark_type=" + rmt + " AND rm.id_report=" + id + " AND rm.id_report_status=3 "
        'viewSearchLookupQuery(SLEApproved, qa, "id_report_mark", "employee_name", "id_report_mark")
        view_mark()
    End Sub

    Sub view_mark()
        Dim query As String = "SELECT IF(a.is_requisite='2','no','yes') AS is_requisite,a.id_report,a.report_mark_type,emp.employee_name,a.id_mark,a.id_mark_asg,a.id_report_status,a.report_mark_note,a.id_report_mark,b.report_status,a.id_user,IF(a.id_report_status=1,'Submitted',IF(e.`id_mark`=2,b.report_status,e.`mark`)) AS mark,CONCAT_WS(' ',DATE_FORMAT(a.report_mark_datetime,'%d %M %Y'),TIME(a.report_mark_datetime)) AS date_time,a.report_mark_note,a.is_use 
                            ,CONCAT_WS(' ',DATE_FORMAT(a.report_mark_start_datetime,'%d %M %Y'),TIME(a.report_mark_start_datetime)) AS date_time_start 
                            ,CONCAT_WS(' ',DATE_FORMAT((ADDTIME(report_mark_start_datetime,report_mark_lead_time)),'%d %M %Y'),TIME((ADDTIME(report_mark_start_datetime,report_mark_lead_time)))) AS lead_time 
                            ,CONCAT_WS(' ',DATE(ADDTIME(report_mark_start_datetime,report_mark_lead_time)),TIME((ADDTIME(report_mark_start_datetime,report_mark_lead_time)))) AS raw_lead_time 
                            ,CONCAT(a.id_report_status,LPAD(a.id_mark_asg,6,0))  as id_sort
                            FROM tb_report_mark a 
                            INNER JOIN tb_lookup_report_status b ON a.id_report_status=b.id_report_status 
                            LEFT JOIN tb_m_user c ON a.id_user=c.id_user 
                            LEFT JOIN tb_m_employee d ON d.id_employee=c.id_employee 
                            LEFT JOIN tb_m_employee emp ON emp.id_employee=a.id_employee 
                            INNER JOIN tb_lookup_mark e ON e.id_mark=a.id_mark 
                            WHERE a.report_mark_type='" & rmt & "' AND a.id_report='" & id & "' 
                            ORDER BY a.id_report_status,a.level"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCMark.DataSource = data
        GVMark.ExpandAllGroups()
        GVMark.BestFitColumns()
    End Sub


    Private Sub FormProdDemandPrintOpt_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs) Handles SimpleButton1.Click
        'Dim id_checked As String = SLEChecked.EditValue.ToString
        'Dim id_app As String = SLEApproved.EditValue.ToString
        'Dim query_upd_all As String = "UPDATE tb_report_mark rm SET rm.is_use=2 WHERE rm.report_mark_type=" + rmt + " AND rm.id_report=" + id + " AND (rm.id_report_status=2 OR rm.id_report_status=3);
        'UPDATE tb_report_mark rm SET rm.is_use=1 WHERE rm.id_report_mark = " + id_checked + "; 
        'UPDATE tb_report_mark rm SET rm.is_use=1 WHERE rm.id_report_mark = " + id_app + "; "
        'execute_non_query(query_upd_all, True, "", "", "", "")
        Close()
    End Sub

    Private Sub SignHardcopyToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SignHardcopyToolStripMenuItem.Click
        If GVMark.RowCount > 0 And GVMark.FocusedRowHandle >= 0 Then
            Dim id_mark_asg As String = GVMark.GetFocusedRowCellValue("id_mark_asg").ToString
            Dim id_report_mark As String = GVMark.GetFocusedRowCellValue("id_report_mark").ToString
            Dim query_upd_all As String = "UPDATE tb_report_mark rm SET rm.is_use=2 WHERE rm.report_mark_type=" + rmt + " AND rm.id_report=" + id + " AND rm.id_mark_asg=" + id_mark_asg + ";
            UPDATE tb_report_mark rm SET rm.is_use=1 WHERE rm.id_report_mark = " + id_report_mark + "; "
            execute_non_query(query_upd_all, True, "", "", "", "")
            view_mark()
            GVMark.FocusedRowHandle = find_row(GVMark, "id_report_mark", id_report_mark)
        End If
    End Sub
End Class