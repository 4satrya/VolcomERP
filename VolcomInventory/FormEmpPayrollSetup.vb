Public Class FormEmpPayrollSetup
    Public id_payroll As String = "-1"
    Private Sub FormEmpPayrollSetup_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub BCancel_Click(sender As Object, e As EventArgs) Handles BCancel.Click
        Close()
    End Sub

    Private Sub FormEmpPayrollSetup_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        id_payroll = FormEmpPayroll.GVPayrollPeriode.GetFocusedRowCellValue("id_payroll").ToString
        TEUMP.EditValue = 0
        TEBPJSMax.EditValue = 0
        TEJPMax.EditValue = 0
        TEPembilang.EditValue = 0
        TEPenyebut.EditValue = 0
        TEKoperasiIuran.EditValue = 0

        If Not id_payroll = "-1" Then
            Dim query As String = "SELECT * FROM tb_emp_payroll WHERE id_payroll='" & id_payroll & "'"
            Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")

            If data.Rows.Count > 0 Then
                TEUMP.EditValue = data.Rows(0)("ump")
                TEBPJSMax.EditValue = data.Rows(0)("bpjs_max")
                TEJPMax.EditValue = data.Rows(0)("jp_max")
                TEPembilang.EditValue = data.Rows(0)("ot_reg_pembilang")
                TEPenyebut.EditValue = data.Rows(0)("ot_reg_penyebut")
                TEKoperasiIuran.EditValue = data.Rows(0)("koperasi_iuran")
                DEEffDate.EditValue = data.Rows(0)("eff_trans_date")
                MemoEdit1.Text = data.Rows(0)("note").ToString
            End If
        End If
    End Sub

    Private Sub BPick_Click(sender As Object, e As EventArgs) Handles BPick.Click
        If Not id_payroll = "-1" Then
            Dim query As String = "UPDATE tb_emp_payroll SET ump='" & TEUMP.EditValue.ToString & "',bpjs_max='" & TEBPJSMax.EditValue.ToString & "',jp_max='" & TEJPMax.EditValue.ToString & "',ot_reg_pembilang='" & TEPembilang.EditValue.ToString & "',ot_reg_penyebut='" & TEPenyebut.EditValue.ToString & "',koperasi_iuran='" & TEKoperasiIuran.EditValue.ToString & "',note='" & addSlashes(MemoEdit1.Text) & "',eff_trans_date='" & Date.Parse(DEEffDate.EditValue.ToString).ToString("yyyy-MM-dd") & "' WHERE id_payroll='" & id_payroll & "'"
            execute_query(query, -1, True, "", "", "", "")
            FormEmpPayroll.load_payroll_detail()
            Close()
        End If
    End Sub
End Class