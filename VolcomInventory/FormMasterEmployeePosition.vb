Public Class FormMasterEmployeePosition
    Public id_employee_position As String = "-1"
    Public id_employee As String = "-1"

    Sub viewDept()
        Dim query As String = "SELECT * FROM tb_m_departement a ORDER BY a.departement ASC "
        viewLookupQuery(LEDepartement, query, 0, "departement", "id_departement")
        viewLookupQuery(LEOriginDept, query, 0, "departement", "id_departement")
        viewSubDept()
        viewSubDeptOrign()
    End Sub

    Sub viewSubDept()
        Dim query As String = "SELECT * FROM tb_m_departement_sub a WHERE id_departement='" & LEDepartement.EditValue.ToString & "' ORDER BY a.departement_sub ASC "
        viewLookupQuery(LESubDept, query, 0, "departement_sub", "id_departement_sub")
    End Sub

    Sub viewSubDeptOrign()
        Dim query As String = "SELECT * FROM tb_m_departement_sub a WHERE id_departement='" & LEOriginDept.EditValue.ToString & "' ORDER BY a.departement_sub ASC "
        viewLookupQuery(LESubDeptOrign, query, 0, "departement_sub", "id_departement_sub")
    End Sub

    Sub viewLevel()
        Dim query As String = "SELECT * FROM tb_lookup_employee_level lvl ORDER BY lvl.id_employee_level ASC  "
        viewLookupQuery(LELevel, query, 0, "employee_level", "id_employee_level")
        viewLookupQuery(LEOriginLevel, query, 0, "employee_level", "id_employee_level")
    End Sub

    Private Sub FormMasterEmployeePosition_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        viewDept()
        viewLevel()

        'current position
        Dim query As String = "SELECT emp.id_departement,emp.id_departement_sub,emp.employee_position, emp.id_employee_level FROM tb_m_employee emp WHERE emp.id_employee='" + id_employee + "' "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")

        If data.Rows(0)("id_departement").ToString = "" Then
            LEOriginDept.EditValue = Nothing
            LESubDeptOrign.EditValue = Nothing
        Else
            LEOriginDept.ItemIndex = LEOriginDept.Properties.GetDataSourceRowIndex("id_departement", data.Rows(0)("id_departement").ToString)
            viewSubDeptOrign()
        End If

        If data.Rows(0)("id_employee_level").ToString = "" Then
            LEOriginLevel.EditValue = Nothing
        Else
            LEOriginLevel.ItemIndex = LEOriginLevel.Properties.GetDataSourceRowIndex("id_employee_level", data.Rows(0)("id_employee_level").ToString)
        End If
        TxtOriginPosition.Text = data.Rows(0)("employee_position").ToString
    End Sub

    Private Sub DEJoinDate_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles DEDate.Validating
        EP_DE_cant_blank(ErrorProvider1, DEDate)
    End Sub

    Private Sub BtnSave_Click(sender As Object, e As EventArgs) Handles BtnSave.Click
        ValidateChildren()
        If Not formIsValid(ErrorProvider1) Then
            errorInput()
        Else
            Dim id_departement_origin As String = "NULL"
            Dim id_departement_sub_origin As String = "NULL"
            Try
                id_departement_origin = checkNullInput(LEOriginDept.EditValue.ToString)
            Catch ex As Exception
            End Try

            Try
                id_departement_sub_origin = checkNullInput(LESubDeptOrign.EditValue.ToString)
            Catch ex As Exception
            End Try
            Dim id_employee_level_origin As String = "NULL"
            Try
                id_employee_level_origin = checkNullInput(LEOriginLevel.EditValue.ToString)
            Catch ex As Exception
            End Try
            Dim employee_position_origin As String = checkNullInput(TxtOriginPosition.Text)
            Dim id_departement As String = LEDepartement.EditValue.ToString
            Dim id_departement_sub As String = LESubDept.EditValue.ToString
            Dim id_employee_level As String = LELevel.EditValue.ToString
            Dim employee_position As String = addSlashes(TxtPosition.Text)
            Dim employee_position_date As String = DateTime.Parse(DEDate.EditValue.ToString).ToString("yyyy-MM-dd")

            'ins
            Dim query As String = "INSERT INTO tb_m_employee_position(id_employee, id_departement_origin, id_employee_level_origin, employee_position_origin, id_departement, id_employee_level, employee_position, employee_position_date) "
            query += "VALUES('" + id_employee + "', " + id_departement_origin + ",  " + id_employee_level_origin + ", " + employee_position_origin + ", '" + id_departement + "', '" + id_employee_level + "', '" + employee_position + "', '" + employee_position_date + "'); SELECT LAST_INSERT_ID(); "
            id_employee_position = execute_query(query, 0, True, "", "", "", "")

            'update position
            Dim query_upd As String = "UPDATE tb_m_employee SET id_departement='" + id_departement + "',id_departement_sub='" + id_departement_sub + "', id_employee_level='" + id_employee_level + "', employee_position='" + employee_position + "' WHERE id_employee='" + id_employee + "' "
            execute_non_query(query_upd, True, "", "", "", "")

            FormMasterEmployeeNewDet.viewEmployeePosition()
            Close()
        End If
    End Sub

    Private Sub FormMasterEmployeePosition_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub TxtPosition_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles TxtPosition.Validating
        EP_TE_cant_blank(ErrorProvider1, TxtPosition)
    End Sub

    Private Sub LEOriginDept_EditValueChanged(sender As Object, e As EventArgs) Handles LEOriginDept.EditValueChanged
        viewSubDeptOrign()
    End Sub

    Private Sub LEDepartement_EditValueChanged(sender As Object, e As EventArgs) Handles LEDepartement.EditValueChanged
        viewSubDept()
    End Sub
End Class