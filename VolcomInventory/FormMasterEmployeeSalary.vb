Public Class FormMasterEmployeeSalary
    Public id_employee As String = "-1"

    Private Sub FormMasterEmployeeSalary_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        TxtBasicSalary.EditValue = 0
        TxtAllowJob.EditValue = 0
        TxtAllowMeal.EditValue = 0
        TxtAllowTrans.EditValue = 0
        TxtAllowHouse.EditValue = 0
        TxtAllowCar.EditValue = 0
        TETotal.EditValue = 0
    End Sub

    Sub calculate()
        Try
            Dim total As Integer = TxtAllowCar.EditValue + TxtAllowHouse.EditValue + TxtAllowJob.EditValue + TxtAllowMeal.EditValue + TxtAllowTrans.EditValue + TxtBasicSalary.EditValue
            TETotal.EditValue = total
        Catch ex As Exception

        End Try
    End Sub

    Private Sub BtnSave_Click(sender As Object, e As EventArgs) Handles BtnSave.Click
        Dim basic_salary As String = decimalSQL(TxtBasicSalary.EditValue)
        Dim allow_job As String = decimalSQL(TxtAllowJob.EditValue)
        Dim allow_meal As String = decimalSQL(TxtAllowMeal.EditValue)
        Dim allow_trans As String = decimalSQL(TxtAllowTrans.EditValue)
        Dim allow_house As String = decimalSQL(TxtAllowHouse.EditValue)
        Dim allow_car As String = decimalSQL(TxtAllowCar.EditValue)
        Dim confirm As DialogResult = DevExpress.XtraEditors.XtraMessageBox.Show("Are you sure you want to set as default salary?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
        If confirm = Windows.Forms.DialogResult.Yes Then
            Dim query_upd As String = "UPDATE tb_m_employee SET "
            query_upd += "basic_salary='" + basic_salary + "', "
            query_upd += "allow_job='" + allow_job + "', "
            query_upd += "allow_meal='" + allow_meal + "', "
            query_upd += "allow_trans='" + allow_trans + "', "
            query_upd += "allow_house='" + allow_house + "', "
            query_upd += "allow_car='" + allow_car + "' "
            query_upd += "WHERE id_employee='" + id_employee + "' "
            execute_non_query(query_upd, True, "", "", "", "")

            Dim query_ins As String = "INSERT INTO tb_m_employee_salary(id_employee, basic_salary, allow_job, allow_meal, allow_trans, allow_house, allow_car, effective_date) VALUES "
            query_ins += "('" + id_employee + "','" + basic_salary + "', '" + allow_job + "', '" + allow_meal + "', '" + allow_trans + "', '" + allow_house + "', '" + allow_car + "', NOW()) "
            execute_non_query(query_ins, True, "", "", "", "")
            FormMasterEmployeeNewDet.viewSalary()
            Close()
        End If
    End Sub

    Private Sub FormMasterEmployeeSalary_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub TxtBasicSalary_EditValueChanged(sender As Object, e As EventArgs) Handles TxtBasicSalary.EditValueChanged
        calculate()
    End Sub

    Private Sub TxtAllowJob_EditValueChanged(sender As Object, e As EventArgs) Handles TxtAllowJob.EditValueChanged
        calculate()
    End Sub

    Private Sub TxtAllowMeal_EditValueChanged(sender As Object, e As EventArgs) Handles TxtAllowMeal.EditValueChanged
        calculate()
    End Sub

    Private Sub TxtAllowTrans_EditValueChanged(sender As Object, e As EventArgs) Handles TxtAllowTrans.EditValueChanged
        calculate()
    End Sub

    Private Sub TxtAllowHouse_EditValueChanged(sender As Object, e As EventArgs) Handles TxtAllowHouse.EditValueChanged
        calculate()
    End Sub

    Private Sub TxtAllowCar_EditValueChanged(sender As Object, e As EventArgs) Handles TxtAllowCar.EditValueChanged
        calculate()
    End Sub
End Class