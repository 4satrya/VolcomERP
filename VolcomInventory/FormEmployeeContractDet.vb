Public Class FormEmployeeContractDet
    Public basic_salary As String = "0"
    Public allow_job As String = "0"
    Public allow_meal As String = "0"
    Public allow_trans As String = "0"
    Public allow_house As String = "0"
    Public allow_car As String = "0"

    Private data_contract_type As DataTable = execute_query("SELECT * FROM tb_lookup_contract_type", -1, True, "", "", "", "")

    Private Sub FormEmployeeContractDet_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        viewSearchLookupQuery(SLUEContractType, "
            SELECT id_contract_type, contract_type, is_use_start_date, is_use_end_date, is_dw
            FROM tb_lookup_contract_type
        ", "id_contract_type", "contract_type", "id_contract_type")

        viewSearchLookupQuery(SLUEDepartement, "
            SELECT *
            FROM (
                (SELECT id_departement, departement, is_store
                FROM tb_m_departement
                WHERE id_departement <> 17 AND id_departement NOT IN (24, 25, 26, 27, 28, 29))
                UNION ALL
                (SELECT CONCAT(d.id_departement, '-', s.id_departement_sub) AS id_departement, CONCAT(d.departement, '- ', s.departement_sub) AS departement, d.is_store
                FROM tb_m_departement_sub AS s
                LEFT JOIN tb_m_departement AS d ON s.id_departement = d.id_departement
                WHERE s.id_departement = 17 AND s.id_departement_sub <> 16)
            ) AS tb
            ORDER BY departement ASC
        ", "id_departement", "departement", "id_departement")

        Dim month As String = execute_query("SELECT `code` FROM `tb_ot_memo_number_mon` WHERE `month` = MONTH(NOW())", 0, True, "", "", "", "")

        DEDate.EditValue = Now
        TEName.EditValue = get_emp(id_employee_user, "2")
        TENumberBack.EditValue = "/INT/HRD-KK/" + month + "/" + Date.Now.ToString("yy")
    End Sub

    Private Sub FormEmployeeContractDet_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Sub calculate_total_salary()
        TETotalSalary.EditValue = TEBasicSalary.EditValue + TEAllowJob.EditValue + TEAllowMeal.EditValue + TEAllowTrans.EditValue + TEAllowHouse.EditValue + TEAllowCar.EditValue
    End Sub

    Private Sub TEBasicSalary_EditValueChanged(sender As Object, e As EventArgs) Handles TEBasicSalary.EditValueChanged
        calculate_total_salary()
    End Sub

    Private Sub TEAllowJob_EditValueChanged(sender As Object, e As EventArgs) Handles TEAllowJob.EditValueChanged
        calculate_total_salary()
    End Sub

    Private Sub TEAllowMeal_EditValueChanged(sender As Object, e As EventArgs) Handles TEAllowMeal.EditValueChanged
        calculate_total_salary()
    End Sub

    Private Sub TEAllowTrans_EditValueChanged(sender As Object, e As EventArgs) Handles TEAllowTrans.EditValueChanged
        calculate_total_salary()
    End Sub

    Private Sub TEAllowHouse_EditValueChanged(sender As Object, e As EventArgs) Handles TEAllowHouse.EditValueChanged
        calculate_total_salary()
    End Sub

    Private Sub TEAllowCar_EditValueChanged(sender As Object, e As EventArgs) Handles TEAllowCar.EditValueChanged
        calculate_total_salary()
    End Sub

    Private Sub TEBasicSalary_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles TEBasicSalary.Validating
        If TEBasicSalary.EditValue.ToString = basic_salary Then
            ErrorProvider.SetError(TEBasicSalary, "")
        Else
            ErrorProvider.SetError(TEBasicSalary, "Salary changed.")
        End If
    End Sub

    Private Sub TEAllowJob_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles TEAllowJob.Validating
        If TEAllowJob.EditValue.ToString = allow_job Then
            ErrorProvider.SetError(TEAllowJob, "")
        Else
            ErrorProvider.SetError(TEAllowJob, "Salary changed.")
        End If
    End Sub

    Private Sub TEAllowMeal_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles TEAllowMeal.Validating
        If TEAllowMeal.EditValue.ToString = allow_meal Then
            ErrorProvider.SetError(TEAllowMeal, "")
        Else
            ErrorProvider.SetError(TEAllowMeal, "Salary changed.")
        End If
    End Sub

    Private Sub TEAllowTrans_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles TEAllowTrans.Validating
        If TEAllowTrans.EditValue.ToString = allow_trans Then
            ErrorProvider.SetError(TEAllowTrans, "")
        Else
            ErrorProvider.SetError(TEAllowTrans, "Salary changed.")
        End If
    End Sub

    Private Sub TEAllowHouse_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles TEAllowHouse.Validating
        If TEAllowHouse.EditValue.ToString = allow_house Then
            ErrorProvider.SetError(TEAllowHouse, "")
        Else
            ErrorProvider.SetError(TEAllowHouse, "Salary changed.")
        End If
    End Sub

    Private Sub TEAllowCar_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles TEAllowCar.Validating
        If TEAllowCar.EditValue.ToString = allow_car Then
            ErrorProvider.SetError(TEAllowCar, "")
        Else
            ErrorProvider.SetError(TEAllowCar, "Salary changed.")
        End If
    End Sub

    Private Sub SBBrowse_Click(sender As Object, e As EventArgs) Handles SBBrowse.Click
        FormEmployeeContractEmp.ShowDialog()
    End Sub

    Private Sub SBSavePrint_Click(sender As Object, e As EventArgs) Handles SBSavePrint.Click
        Dim id_contract_type As String = SLUEContractType.EditValue.ToString

        Dim departement As String() = SLUEDepartement.EditValue.ToString.Split("-")

        Dim id_departement As String = "NULL"
        Dim id_departement_sub As String = "NULL"

        Try
            id_departement = departement(0)
        Catch ex As Exception
        End Try

        Try
            id_departement_sub = departement(1)
        Catch ex As Exception
        End Try

        Dim employee_name As String = "'" + addSlashes(TEEmployee.EditValue.ToString) + "'"
        Dim employee_position As String = "'" + addSlashes(TEPosition.EditValue.ToString) + "'"
        Dim employee_code As String = "'" + addSlashes(TEEmployeeCode.EditValue.ToString) + "'"
        Dim employee_ktp As String = "'" + addSlashes(TEKTP.EditValue.ToString) + "'"
        Dim address_primary As String = "'" + addSlashes(TEAddress.EditValue.ToString) + "'"
        Dim number As String = "'" + TENumberFront.Text + TENumberBack.EditValue.ToString + "'"

        Dim start_period As String = "NULL"
        Dim end_period As String = "NULL"

        Try
            start_period = "'" + Date.Parse(DEStartDate.EditValue.ToString).ToString("yyyy-MM-dd") + "'"
        Catch ex As Exception
        End Try

        Try
            end_period = "'" + Date.Parse(DEEndDate.EditValue.ToString).ToString("yyyy-MM-dd") + "'"
        Catch ex As Exception
        End Try

        Dim is_use_start_date As Boolean = True
        Dim is_use_end_date As Boolean = True
        Dim is_dw As Boolean = True

        For i = 0 To data_contract_type.Rows.Count - 1
            If data_contract_type.Rows(i)("id_contract_type").ToString = SLUEContractType.EditValue.ToString Then
                is_use_start_date = data_contract_type.Rows(i)("id_contract_type")
                is_use_end_date = data_contract_type.Rows(i)("is_use_end_date")
                is_dw = data_contract_type.Rows(i)("is_dw")
            End If
        Next

        If Not is_use_start_date Then
            start_period = "NULL"
        End If

        If Not is_use_end_date Then
            end_period = "NULL"
        End If

        Dim basic_salary As String = decimalSQL(TEBasicSalary.EditValue.ToString)
        Dim allow_job As String = decimalSQL(TEAllowJob.EditValue.ToString)
        Dim allow_meal As String = decimalSQL(TEAllowMeal.EditValue.ToString)
        Dim allow_trans As String = decimalSQL(TEAllowTrans.EditValue.ToString)
        Dim allow_house As String = decimalSQL(TEAllowHouse.EditValue.ToString)
        Dim allow_car As String = decimalSQL(TEAllowCar.EditValue.ToString)

        If is_dw Then
            allow_job = "0.00"
            allow_meal = "0.00"
            allow_trans = "0.00"
            allow_house = "0.00"
            allow_car = "0.00"
        End If

        Dim created_at As String = "NOW()"
        Dim created_by As String = id_employee_user

        Dim query As String = "INSERT INTO tb_emp_contract (id_contract_type, id_departement, id_departement_sub, employee_name, employee_position, employee_code, employee_ktp, address_primary, number, start_period, end_period, basic_salary, allow_job, allow_meal, allow_trans, allow_house, allow_car, created_at, created_by) VALUES (" + id_contract_type + ", " + id_departement + ", " + id_departement_sub + ", " + employee_name + ", " + employee_position + ", " + employee_code + ", " + employee_ktp + ", " + address_primary + ", " + number + ", " + start_period + ", " + end_period + ", " + basic_salary + ", " + allow_job + ", " + allow_meal + ", " + allow_trans + ", " + allow_house + ", " + allow_car + ", " + created_at + ", " + created_by + "); SELECT LAST_INSERT_ID();"

        Dim id_emp_contract As String = execute_query(query, 0, True, "", "", "", "")

        FormEmployeeContract.print(id_emp_contract)

        FormEmployeeContract.form_load()

        Close()
    End Sub

    Private Sub SLUEContractType_EditValueChanged(sender As Object, e As EventArgs) Handles SLUEContractType.EditValueChanged
        Dim is_use_start_date As Boolean = True
        Dim is_use_end_date As Boolean = True
        Dim is_dw As Boolean = True

        For i = 0 To data_contract_type.Rows.Count - 1
            If data_contract_type.Rows(i)("id_contract_type").ToString = SLUEContractType.EditValue.ToString Then
                is_use_start_date = data_contract_type.Rows(i)("id_contract_type")
                is_use_end_date = data_contract_type.Rows(i)("is_use_end_date")
                is_dw = data_contract_type.Rows(i)("is_dw")
            End If
        Next

        If is_dw Then
            PCContract.Height = 215
            Height = 425

            LabelControl9.Text = "Gaji Harian"

            TEAllowJob.Visible = False
            TEAllowMeal.Visible = False
            TEAllowTrans.Visible = False
            TEAllowHouse.Visible = False
            TEAllowCar.Visible = False
            TETotalSalary.Visible = False
            LabelControl10.Visible = False
            LabelControl11.Visible = False
            LabelControl12.Visible = False
            LabelControl13.Visible = False
            LabelControl14.Visible = False
            LabelControl15.Visible = False
        Else
            PCContract.Height = 380
            Height = 585

            LabelControl9.Text = "Gaji Pokok"

            TEAllowJob.Visible = True
            TEAllowMeal.Visible = True
            TEAllowTrans.Visible = True
            TEAllowHouse.Visible = True
            TEAllowCar.Visible = True
            TETotalSalary.Visible = True
            LabelControl10.Visible = True
            LabelControl11.Visible = True
            LabelControl12.Visible = True
            LabelControl13.Visible = True
            LabelControl14.Visible = True
            LabelControl15.Visible = True
        End If

        If is_use_start_date And is_use_end_date Then
            LabelControl8.Visible = True
            DEStartDate.Visible = True
            DEEndDate.Visible = True
        Else
            If Not is_use_start_date Then
                LabelControl8.Visible = False
                DEStartDate.Visible = False
            End If

            If Not is_use_end_date Then
                LabelControl8.Visible = False
                DEEndDate.Visible = False
            End If
        End If
    End Sub
End Class