Public Class FormLetterOfStatementDet
    Public id_letter_of_statement As String = "0"

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

        DEDate.EditValue = Now
    End Sub

    Private Sub SBSavePrint_Click(sender As Object, e As EventArgs) Handles SBSavePrint.Click
        Dim query As String = "INSERT INTO tb_letter_of_statement (id_popup, number, date, id_employee, created_date, created_by) VALUES (" + SLUEType.EditValue.ToString + ", '" + TENumberFront.EditValue.ToString + TENumberBack.EditValue.ToString + "', '" + Date.Parse(DEDate.EditValue.ToString).ToString("yyyy-MM-dd") + "', " + SLUEEmployee.EditValue.ToString + ", NOW(), " + id_user + "); SELECT LAST_INSERT_ID();"

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
            End If
        Catch ex As Exception
        End Try
    End Sub
End Class