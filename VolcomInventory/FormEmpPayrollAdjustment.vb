Public Class FormEmpPayrollAdjustment
    Public id_payroll As String = "-1"
    Private Sub FormEmpPayrollAdjustment_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        id_payroll = FormEmpPayroll.GVPayrollPeriode.GetFocusedRowCellValue("id_payroll").ToString
        load_adjustment()
    End Sub
    Sub load_adjustment()
        Dim query As String = "SELECT pya.*,emp.`employee_name`,emp.`employee_code`,emp.`employee_position`,dep.`departement`,adj.`description`,lvl.`employee_level` FROM tb_emp_payroll_adj pya
                                INNER JOIN tb_m_employee emp ON pya.id_employee=emp.`id_employee`
                                INNER JOIN tb_m_departement dep ON dep.`id_departement`=emp.`id_departement`
                                INNER JOIN `tb_lookup_employee_level` lvl ON lvl.`id_employee_level`=emp.`id_employee_level`
                                INNER JOIN `tb_lookup_salary_adjustment` adj ON adj.`id_salary_adjustment`=pya.`id_salary_adj`
                                WHERE pya.`id_payroll`='" & id_payroll & "'"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")

        GCDeduction.DataSource = data
        GVDeduction.BestFitColumns()
    End Sub

    Private Sub FormEmpPayrollAdjustment_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub BAdd_Click(sender As Object, e As EventArgs) Handles BAdd.Click
        FormEmpPayrollAdjustmentDet.ShowDialog()
    End Sub

    Private Sub BEdit_Click(sender As Object, e As EventArgs) Handles BEdit.Click
        If GVDeduction.RowCount > 0 Then
            FormEmpPayrollAdjustmentDet.id_payroll_adj = GVDeduction.GetFocusedRowCellValue("id_payroll_adj").ToString
            FormEmpPayrollAdjustmentDet.ShowDialog()
        End If
    End Sub

    Private Sub BDel_Click(sender As Object, e As EventArgs) Handles BDel.Click
        If GVDeduction.RowCount > 0 Then
            Dim confirm As DialogResult
            confirm = DevExpress.XtraEditors.XtraMessageBox.Show("Are you sure want to delete ?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
            If confirm = Windows.Forms.DialogResult.Yes Then
                Dim query As String = "DELETE FROM tb_emp_payroll_adj WHERE id_payroll_adj='" & GVDeduction.GetFocusedRowCellValue("id_payroll_adj") & "'"
                execute_non_query(query, True, "", "", "", "")
                '
                load_adjustment()
            End If
        End If
    End Sub
End Class