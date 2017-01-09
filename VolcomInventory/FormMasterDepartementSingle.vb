Public Class FormMasterDepartementSingle 
    Public id_departement As String
    Private Sub TEDepartement_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TEDepartement.Validating
        EP_TE_cant_blank(EPDepartement, TEDepartement)
        '
        Dim query_jml As String
        If id_departement = "-1" Then
            'new
            query_jml = String.Format("SELECT COUNT(id_departement) FROM tb_m_departement WHERE departement='{0}'", TEDepartement.Text)
        Else
            query_jml = String.Format("SELECT COUNT(id_departement) FROM tb_m_departement WHERE departement='{0}' AND id_departement!='{1}'", TEDepartement.Text, id_departement)
        End If

        Dim jml As Integer = execute_query(query_jml, 0, True, "", "", "", "")
        If Not jml < 1 Then
            EP_TE_already_used(EPDepartement, TEDepartement, "1")
        Else
            EPDepartement.SetError(TEDepartement, String.Empty)
        End If
    End Sub
    Private Sub TEDepartementCode_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TEDepartementCode.Validating
        EP_TE_cant_blank(EPDepartement, TEDepartementCode)
        '
        Dim query_jml As String
        If id_departement = "-1" Then
            'new
            query_jml = String.Format("SELECT COUNT(id_departement) FROM tb_m_departement WHERE departement_code='{0}'", TEDepartementCode.Text)
        Else
            query_jml = String.Format("SELECT COUNT(id_departement) FROM tb_m_departement WHERE departement_code='{0}' AND id_departement!='{1}'", TEDepartementCode.Text, id_departement)
        End If

        Dim jml As Integer = execute_query(query_jml, 0, True, "", "", "", "")
        If Not jml < 1 Then
            EP_TE_already_used(EPDepartement, TEDepartementCode, "1")
        Else
            EPDepartement.SetError(TEDepartementCode, String.Empty)
        End If
    End Sub
    Private Sub BSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BSave.Click
        Cursor = Cursors.WaitCursor

        Dim query As String
        Dim departement As String = TEDepartement.Text
        Dim departement_code As String = TEDepartementCode.Text
        Dim description As String = MEDescription.Text

        Try
            If id_departement <> "-1" Then
                'update
                If Not formIsValid(EPDepartement) Then
                    errorInput()
                Else
                    query = String.Format("UPDATE tb_m_departement SET departement='{0}',departement_code='{1}',description='{2}',id_user_head='{4}',id_user_asst_head='{5}' WHERE id_departement='{3}'", departement, departement_code, description, id_departement, SLEHeadDept.EditValue.ToString, SLEAsstHeadDept.EditValue.ToString)
                    execute_non_query(query, True, "", "", "", "")
                    FormMasterDepartement.view_department()
                    FormMasterDepartement.GVDepartment.FocusedRowHandle = find_row(FormMasterDepartement.GVDepartment, "id_departement", id_departement)
                    Close()
                End If
            Else
                'insert
                If Not formIsValid(EPDepartement) Then
                    errorInput()
                Else
                    query = String.Format("INSERT INTO tb_m_departement(departement,departement_code,description,id_user_head,id_user_asst_head) VALUES('{0}','{1}','{2}','{3}','{4}'); SELECT LAST_INSERT_ID()", departement, departement_code, description, SLEHeadDept.EditValue.ToString, SLEAsstHeadDept.EditValue.ToString)
                    id_departement = execute_query(query, 0, True, "", "", "", "")
                    FormMasterDepartement.view_department()
                    FormMasterDepartement.GVDepartment.FocusedRowHandle = find_row(FormMasterDepartement.GVDepartment, "id_departement", id_departement)
                    Close()
                End If
            End If
        Catch ex As Exception
            errorInput()
        End Try
        Cursor = Cursors.Default
    End Sub
    Private Sub FormMasterDepartementSingle_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        load_user_head()
        load_user_asst_head()

        If id_departement <> "-1" Then
            'update
            Dim query As String = String.Format("SELECT * FROM tb_m_departement WHERE id_departement = '{0}'", id_departement)
            Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")

            Dim departement As String = data.Rows(0)("departement").ToString
            Dim departement_code As String = data.Rows(0)("departement_code").ToString
            Dim description As String = data.Rows(0)("description").ToString

            Dim id_user_head As String = data.Rows(0)("id_user_head").ToString
            SLEHeadDept.EditValue = id_user_head
            '
            Dim id_user_asst_head As String = data.Rows(0)("id_user_asst_head").ToString
            SLEAsstHeadDept.EditValue = id_user_asst_head
            '
            data.Dispose()

            TEDepartement.Text = departement
            TEDepartementCode.Text = departement_code
            MEDescription.Text = description
        End If
    End Sub
    Sub load_user_head()
        Dim query As String = "SELECT usr.*,emp.*,dep.departement FROM tb_m_user usr INNER JOIN tb_m_employee emp ON usr.id_employee=emp.id_employee INNER JOIN tb_m_departement dep ON dep.id_departement=emp.id_departement"
        'AND emp.id_departement='" + id_departement + "'
        viewSearchLookupQuery(SLEHeadDept, query, "id_user", "employee_name", "id_user")
        SLEHeadDept.Properties.View.ActiveFilterString = "[id_departement]='" & id_departement & "'"
        SLEViewEmp.RefreshData()
    End Sub
    Sub load_user_asst_head()
        Dim query As String = "SELECT usr.*,emp.*,dep.departement FROM tb_m_user usr INNER JOIN tb_m_employee emp ON usr.id_employee=emp.id_employee INNER JOIN tb_m_departement dep ON dep.id_departement=emp.id_departement"
        'AND emp.id_departement='" + id_departement + "'
        viewSearchLookupQuery(SLEAsstHeadDept, query, "id_user", "employee_name", "id_user")
        SLEAsstHeadDept.Properties.View.ActiveFilterString = "[id_departement]='" & id_departement & "'"
        SLEViewEmp.RefreshData()
    End Sub
    Private Sub FormMasterDepartementSingle_FormClosed(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
        checkFormAccess("FormMasterDepartement")
    End Sub

End Class