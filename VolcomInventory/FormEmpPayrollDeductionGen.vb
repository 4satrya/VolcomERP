Public Class FormEmpPayrollDeductionGen
    Public id_payroll As String = "-1"
    Public deduct_type As String = "-1"
    '1 = Jamsostek
    '2 = Koperasi
    '3 = Other
    Private Sub FormEmpPayrollDeductionGen_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim query As String = ""
        Dim data As DataTable = Nothing
        If deduct_type = "1" Then 'Jamsostek
            query = "CALL generate_jamsostek()"
            data = execute_query(query, -1, True, "", "", "", "")
            GCGenDeduction.DataSource = data
        ElseIf deduct_type = "2" Then 'Koperasi

        ElseIf deduct_type = "3" Then 'Other

        End If
    End Sub
    '
    Private Sub FormEmpPayrollDeductionGen_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub
End Class