Public Class FormAccountingJournalAdj 
    Dim bnew_active As String = "1"
    Dim bedit_active As String = "1"
    Dim bdel_active As String = "1"

    Private Sub FormAccountingJournalAdj_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        view_jurnal()
    End Sub

    Private Sub FormAccountingJournalAdj_Activated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Activated
        FormMain.show_rb(Name)
        checkFormAccess(Name)
        button_main(bnew_active, bedit_active, bdel_active)
    End Sub

    Private Sub FormAccountingJournalAdj_Deactivate(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Deactivate
        FormMain.hide_rb()
    End Sub
    Sub check_but()
        If GVAccTrans.RowCount > 0 Then
            bnew_active = "1"
            bedit_active = "1"
            bdel_active = "0"
        Else
            bnew_active = "1"
            bedit_active = "0"
            bdel_active = "0"
        End If
        checkFormAccess(Name)
        button_main(bnew_active, bedit_active, bdel_active)
    End Sub

    Private Sub FormAccountingJournalAdj_FormClosed(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Sub view_jurnal()
        Dim query As String = ""
        query = "SELECT t.id_acc_trans,t.id_acc_trans_adj,t.acc_trans_adj_number,b.acc_trans_number,t.id_report_status,f.report_status,t.acc_trans_adj_note,i.employee_name,  DATE_FORMAT(t.date_created, '%d %M %Y') AS date_created 
                FROM tb_a_acc_trans_adj t 
                INNER JOIN tb_a_acc_trans b ON t.id_acc_trans=b.id_acc_trans 
                INNER JOIN tb_m_user h ON t.id_user = h.id_user 
                INNER JOIN tb_m_employee i ON h.id_employee = i.id_employee 
                INNER JOIN tb_lookup_report_status f ON t.id_report_status = f.id_report_status 
                ORDER BY t.id_acc_trans DESC "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCAccTrans.DataSource = data
    End Sub
End Class