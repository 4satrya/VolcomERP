Public Class FormLetterOfStatementDet
    Public id_letter_of_statement As String = "0"

    Public basic_salary As String = "0"
    Public allow_job As String = "0"
    Public allow_meal As String = "0"
    Public allow_trans As String = "0"
    Public allow_house As String = "0"
    Public allow_car As String = "0"

    Private Sub FormLetterOfStatementDet_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        form_load()
    End Sub

    Private Sub FormLetterOfStatementDet_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Sub form_load()
        viewSearchLookupQuery(SLUEType, "
            SELECT id_letter_of_statement_popup, popup, include_date FROM tb_letter_of_statement_popup
        ", "id_letter_of_statement_popup", "popup", "id_letter_of_statement_popup")

        SLUEType.EditValue = "1"

        SLUEType_EditValueChanged(SLUEType, New EventArgs)

        viewSearchLookupQuery(SLUEEmployee, "
            SELECT d.departement, e.employee_code, e.employee_name, e.employee_position, a.employee_active, e.id_employee
            FROM tb_m_employee AS e
            LEFT JOIN tb_m_departement AS d ON e.id_departement = d.id_departement
            LEFT JOIN tb_lookup_employee_active AS a ON e.id_employee_active = a.id_employee_active
            ORDER BY d.departement, e.id_employee_active, e.id_employee_level, e.employee_code
        ", "id_employee", "employee_name", "id_employee")

        SLUEEmployee.EditValue = "1"

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

        SLUEDepartement.EditValue = "1"

        DEDate.EditValue = Now
    End Sub

    Private Sub SBSavePrint_Click(sender As Object, e As EventArgs) Handles SBSavePrint.Click
        Dim query_contract As String = "NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL"

        If SLUEType.EditValue.ToString = "6" Then
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

            query_contract = "'" + addSlashes(TEEmployee.EditValue.ToString) + "', '" + addSlashes(TEPosition.EditValue.ToString) + "', " + id_departement + ", " + id_departement_sub + ", '" + addSlashes(TEAddress.EditValue.ToString) + "', '" + Date.Parse(DEStartDate.EditValue.ToString).ToString("yyyy-MM-dd") + "', '" + Date.Parse(DEEndDate.EditValue.ToString).ToString("yyyy-MM-dd") + "', " + TEBasicSalary.EditValue.ToString + ", " + TEAllowJob.EditValue.ToString + ", " + TEAllowMeal.EditValue.ToString + ", " + TEAllowTrans.EditValue.ToString + ", " + TEAllowHouse.EditValue.ToString + ", " + TEAllowCar.EditValue.ToString + ""
        End If

        Dim query As String = "INSERT INTO tb_letter_of_statement (id_popup, number, date, id_employee, created_date, created_by, employee_name, employee_position, id_departement, id_departement_sub, address_primary, start_period, end_period, basic_salary, allow_job, allow_meal, allow_trans, allow_house, allow_car) VALUES (" + SLUEType.EditValue.ToString + ", '" + TENumberFront.EditValue.ToString + TENumberBack.EditValue.ToString + "', '" + Date.Parse(DEDate.EditValue.ToString).ToString("yyyy-MM-dd") + "', " + SLUEEmployee.EditValue.ToString + ", NOW(), " + id_user + ", " + query_contract + "); SELECT LAST_INSERT_ID();"

        id_letter_of_statement = execute_query(query, 0, True, "", "", "", "")

        FormLetterOfStatement.form_print(id_letter_of_statement)

        Close()
    End Sub

    Private Sub SLUEType_EditValueChanged(sender As Object, e As EventArgs) Handles SLUEType.EditValueChanged
        Try
            If execute_query("SELECT include_date FROM tb_letter_of_statement_popup WHERE id_letter_of_statement_popup = " + SLUEType.EditValue.ToString, 0, True, "", "", "", "") Then
                LabelDate.Visible = True
                DEDate.Visible = True
            Else
                LabelDate.Visible = False
                DEDate.Visible = False
            End If

            If execute_query("SELECT is_contract FROM tb_letter_of_statement_popup WHERE id_letter_of_statement_popup = " + SLUEType.EditValue.ToString, 0, True, "", "", "", "") Then
                PCContract.Visible = True
                PCEmployee.Visible = False
                Size = New Size(615, 507)
            Else
                PCContract.Visible = False
                PCEmployee.Visible = True
                Size = New Size(615, 222)
            End If

            Dim month As String = execute_query("SELECT `code` FROM `tb_ot_memo_number_mon` WHERE `month` = MONTH(NOW())", 0, True, "", "", "", "")

            If SLUEType.EditValue.ToString = "1" Then
                TENumberBack.EditValue = "/EXT/HRD-SK/" + month + "/" + Date.Now.ToString("yy")
            ElseIf SLUEType.EditValue.ToString = "2" Then
                TENumberBack.EditValue = "/INT/HRD-SK/" + month + "/" + Date.Now.ToString("yy")
            ElseIf SLUEType.EditValue.ToString = "3" Then
                TENumberBack.EditValue = "/INT/HRD-ST/" + month + "/" + Date.Now.ToString("yy")
            ElseIf SLUEType.EditValue.ToString = "4" Then
                TENumberBack.EditValue = "/EXT/HRD-SK/" + month + "/" + Date.Now.ToString("yy")
            ElseIf SLUEType.EditValue.ToString = "5" Then
                TENumberBack.EditValue = "/EXT/HRD-SR/" + month + "/" + Date.Now.ToString("yy")
            ElseIf SLUEType.EditValue.ToString = "6" Then
                TENumberBack.EditValue = "/INT/HRD-KK/" + month + "/" + Date.Now.ToString("yy")
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub SBBrowse_Click(sender As Object, e As EventArgs) Handles SBBrowse.Click
        FormLetterOfStatementEmployee.ShowDialog()
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
End Class