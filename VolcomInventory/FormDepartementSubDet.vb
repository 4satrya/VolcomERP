Public Class FormDepartementSubDet
    Public id_subdept As String = "-1"
    Private Sub FormDepartementSubDet_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub BtnCancel_Click(sender As Object, e As EventArgs) Handles BtnCancel.Click
        Close()
    End Sub

    Private Sub FormDepartementSubDet_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        load_dept()
        load_user()

        If Not id_subdept = "-1" Then
            LEDepartement.ItemIndex = LEDepartement.Properties.GetDataSourceRowIndex("id_departement", FormDepartementSub.GVDepartment.GetFocusedRowCellValue("id_departement").ToString)
            LEUser.ItemIndex = LEUser.Properties.GetDataSourceRowIndex("id_user", FormDepartementSub.GVDepartment.GetFocusedRowCellValue("id_usr_head_sub_dept").ToString)
            TESubDept.Text = FormDepartementSub.GVDepartment.GetFocusedRowCellValue("departement_sub").ToString
        End If
    End Sub

    Sub load_dept()
        Dim query As String = "SELECT * FROM tb_m_departement a ORDER BY a.id_departement "
        viewLookupQuery(LEDepartement, query, 0, "departement", "id_departement")
    End Sub

    Sub load_user()
        Dim query As String = "SELECT a.`id_user`,a.`username`,emp.`employee_name` FROM tb_m_user a 
                                INNER JOIN tb_m_employee emp ON emp.`id_employee`=a.`id_employee`
                                ORDER BY a.id_user "
        viewLookupQuery(LEUser, query, 0, "employee_name", "id_user")
    End Sub

    Private Sub BtnSave_Click(sender As Object, e As EventArgs) Handles BtnSave.Click
        If TESubDept.Text = "" Then
            stopCustom("Please Input Sub Departement description first.")
        Else
            If id_subdept = "-1" Then 'new
                Dim query As String = "INSERT INTO tb_m_departement_sub(id_departement,departement_sub,id_usr_head_sub_dept)
                                        VALUES('" & LEDepartement.EditValue.ToString & "','" & TESubDept.Text & "','" & LEUser.EditValue.ToString & "')"
                execute_non_query(query, True, "", "", "", "")
                infoCustom("Sub Departement Registered")
                FormDepartementSub.view_departement()
                Close()
            Else 'edit
                Dim query As String = "UPDATE tb_m_departement_sub SET id_departement='" & LEDepartement.EditValue.ToString & "',departement_sub='" & TESubDept.Text & "',id_usr_head_sub_dept='" & LEUser.EditValue.ToString & "' WHERE id_departement_sub='" & id_subdept & "'"
                execute_non_query(query, True, "", "", "", "")
                infoCustom("Sub Departement Updated")
                FormDepartementSub.view_departement()
                Close()
            End If
        End If
    End Sub
End Class