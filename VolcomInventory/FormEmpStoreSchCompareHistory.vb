Public Class FormEmpStoreSchCompareHistory
    Public id_emp As String = ""
    Public date_string As String = ""
    Private Sub FormEmpStoreSchCompareHistory_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub
    Sub load_detail()
        Dim query As String = "SELECT schd.date,emp.employee_name AS name_propose,schdfrom.shift_code AS shift_code_from,schd.shift_code,sch.* FROM tb_emp_assign_sch_det schd
                                INNER JOIN tb_emp_assign_sch sch ON sch.id_assign_sch=schd.id_emp_assign_sch
                                LEFT JOIN tb_emp_assign_sch_det schdfrom ON schdfrom.date=schd.date AND schd.id_employee=schdfrom.id_employee AND schdfrom.type='1'
                                INNER JOIN tb_m_user usr ON usr.id_user=sch.id_user_propose
                                INNER JOIN tb_m_employee emp ON emp.id_employee=usr.id_employee
                                WHERE schd.type='2'
                                AND schd.id_employee='" & id_emp & "'
                                AND schd.date='" & date_string & "'"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCAttnAssign.DataSource = data
    End Sub

    Private Sub FormEmpStoreSchCompareHistory_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        load_detail()
    End Sub

    Private Sub SMViewHistoryPD_Click(sender As Object, e As EventArgs) Handles SMViewHistoryPD.Click
        If GVAttnAssign.RowCount > 0 Then
            FormEmpAttnAssignDet.id_emp_assign_sch = GVAttnAssign.GetFocusedRowCellValue("id_assign_sch").ToString
            FormEmpAttnAssignDet.is_view = "1"
            FormEmpAttnAssignDet.ShowDialog()
        End If
    End Sub

    Private Sub BPrint_Click(sender As Object, e As EventArgs) Handles BPrint.Click
        print(GCAttnAssign, "History Schedule")
    End Sub
End Class