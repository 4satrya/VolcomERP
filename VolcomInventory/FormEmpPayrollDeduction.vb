Public Class FormEmpPayrollDeduction
    Public id_payroll As String = "-1"
    Private Sub FormEmpPayrollDeduction_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        id_payroll = FormEmpPayroll.GVPayrollPeriode.GetFocusedRowCellValue("id_payroll").ToString
        load_deduction()
    End Sub

    Sub load_deduction()
        Dim query As String = "SELECT pyd.id_payroll_deduction,emp.`id_employee`,dep.`departement`,emp.`employee_code`,emp.`employee_name`,emp.`employee_position`,lvl.`employee_level`,pyd.`deduction`,sald.`description`,pyd.note FROM tb_emp_payroll_deduction pyd
                                INNER JOIN tb_m_employee emp ON emp.`id_employee`=pyd.`id_employee`
                                INNER jOIN tb_m_departement dep ON dep.id_departement=emp.id_departement
                                INNER JOIN `tb_lookup_employee_level` lvl ON lvl.`id_employee_level`=emp.`id_employee_level`
                                INNER JOIN `tb_lookup_salary_deduction` sald ON sald.`id_salary_deduction`=pyd.`id_salary_deduction`
                                WHERE pyd.`id_payroll`='" & id_payroll & "'"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCDeduction.DataSource = data
        GVDeduction.BestFitColumns()
    End Sub

    Private Sub BBJamsostek_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BBJamsostek.ItemClick
        Dim confirm As DialogResult
        confirm = DevExpress.XtraEditors.XtraMessageBox.Show("Are you sure want to generate all jamsostek deduction ?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
        If confirm = Windows.Forms.DialogResult.Yes Then
            Dim query As String = "CALL generate_jamsostek(" & id_payroll & ");"
            execute_non_query(query, True, "", "", "", "")
            '
            load_deduction()
        End If
    End Sub

    Private Sub BBKoperasi_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BBKoperasi.ItemClick
        Dim confirm As DialogResult
        confirm = DevExpress.XtraEditors.XtraMessageBox.Show("Are you sure want to generate all iuran koperasi ?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
        If confirm = Windows.Forms.DialogResult.Yes Then
            Dim query As String = "CALL generate_koperasi(" & id_payroll & ");"
            execute_non_query(query, True, "", "", "", "")
            '
            load_deduction()
        End If
    End Sub

    Private Sub BDel_Click(sender As Object, e As EventArgs) Handles BDel.Click
        Dim confirm As DialogResult
        confirm = DevExpress.XtraEditors.XtraMessageBox.Show("Are you sure want to delete ?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
        If confirm = Windows.Forms.DialogResult.Yes Then
            Dim query As String = "DELETE FROM tb_emp_payroll_deduction WHERE id_payroll_deduction='" & GVDeduction.GetFocusedRowCellValue("id_payroll_deduction") & "'"
            execute_non_query(query, True, "", "", "", "")
            '
            load_deduction()
        End If
    End Sub

    Private Sub BEdit_Click(sender As Object, e As EventArgs) Handles BEdit.Click
        FormEmpPayrollDeductionDet.id_payroll_deduction = GVDeduction.GetFocusedRowCellValue("id_payroll_deduction").ToString
        FormEmpPayrollDeductionDet.ShowDialog()
    End Sub

    Private Sub BAdd_Click(sender As Object, e As EventArgs) Handles BAdd.Click
        FormEmpPayrollDeductionDet.id_payroll_deduction = "-1"
        FormEmpPayrollDeductionDet.ShowDialog()
    End Sub

    Private Sub BarButtonItem3_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem3.ItemClick
        FormImportExcel.id_pop_up = "36"
        FormImportExcel.ShowDialog()
    End Sub
End Class