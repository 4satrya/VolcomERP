Public Class FormBankWithdrawalLogPaymentDate
    Public id_pn As String = "-1"
    Private Sub FormBankWithdrawalLogPaymentDate_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim q As String = "SELECT logpn.id_pn_log_date_payment,logpn.log_date,logpn.from_date,logpn.to_date,emp.employee_name
FROM tb_pn_log_date_payment logpn
INNER JOIN tb_m_user usr ON usr.id_user=logpn.log_by
INNER JOIN tb_m_employee emp ON emp.id_employee=usr.id_employee"
        Dim dt As DataTable = execute_query(q, -1, True, "", "", "", "")
        GCLog.DataSource = dt
        GVLog.BestFitColumns()
    End Sub

    Private Sub FormBankWithdrawalLogPaymentDate_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub
End Class