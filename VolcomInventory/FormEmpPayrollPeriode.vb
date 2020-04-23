Public Class FormEmpPayrollPeriode
    Public id_payroll As String = "-1"
    Private Sub BtnCancel_Click(sender As Object, e As EventArgs) Handles BtnCancel.Click
        Close()
    End Sub

    Private Sub FormEmpPayrollPeriode_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub FormEmpPayrollPeriode_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        load_type_payroll()

        If Not id_payroll = "-1" Then 'edit
            Dim query As String = "SELECT * FROM tb_emp_payroll WHERE id_payroll='" & id_payroll & "'"
            Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")

            DEStart.EditValue = data.Rows(0)("periode_start")
            DEEnd.EditValue = data.Rows(0)("periode_end")

            DEStartOt.EditValue = data.Rows(0)("ot_periode_start")
            DEEndOt.EditValue = data.Rows(0)("ot_periode_end")

            DEStartStore.EditValue = data.Rows(0)("store_periode_start")
            DEEndStore.EditValue = data.Rows(0)("store_periode_end")

            MEPayrollNote.Text = data.Rows(0)("note").ToString

            LEPayrollType.ItemIndex = LEPayrollType.Properties.GetDataSourceRowIndex("id_payroll_type", data.Rows(0)("id_payroll_type").ToString)
        End If
    End Sub

    Private Sub BtnSave_Click(sender As Object, e As EventArgs) Handles BtnSave.Click
        If formIsValid(ErrorProvider) Then
            Dim is_thr As String = execute_query("SELECT is_thr FROM tb_emp_payroll_type WHERE id_payroll_type = " + LEPayrollType.EditValue.ToString, 0, True, "", "", "", "")

            Dim date_start As String = "NULL"
            Dim date_end As String = "NULL"

            Try
                date_start = "'" + Date.Parse(DEStart.EditValue.ToString).ToString("yyyy-MM-dd") + "'"
            Catch ex As Exception
            End Try

            Try
                date_end = "'" + Date.Parse(DEEnd.EditValue.ToString).ToString("yyyy-MM-dd") + "'"
            Catch ex As Exception
            End Try

            Dim ot_date_start As String = "NULL"
            Dim ot_date_end As String = "NULL"

            Try
                ot_date_start = "'" + Date.Parse(DEStartOt.EditValue.ToString).ToString("yyyy-MM-dd") + "'"
            Catch ex As Exception
            End Try

            Try
                ot_date_end = "'" + Date.Parse(DEEndOt.EditValue.ToString).ToString("yyyy-MM-dd") + "'"
            Catch ex As Exception
            End Try

            Dim store_date_start As String = "NULL"
            Dim store_date_end As String = "NULL"

            Try
                store_date_start = "'" + Date.Parse(DEStartStore.EditValue.ToString).ToString("yyyy-MM-dd") + "'"
            Catch ex As Exception
            End Try

            Try
                store_date_end = "'" + Date.Parse(DEEndStore.EditValue.ToString).ToString("yyyy-MM-dd") + "'"
            Catch ex As Exception
            End Try

            Dim note As String = addSlashes(MEPayrollNote.Text)
            Dim id_payroll_type As String = LEPayrollType.EditValue.ToString

            If is_thr = "1" Then
                store_date_end = date_end
            End If

            If id_payroll = "-1" Then
                Dim query As String = "INSERT INTO tb_emp_payroll(periode_start,periode_end,ot_periode_start,ot_periode_end,store_periode_start,store_periode_end,note,last_upd,id_user_upd,id_payroll_type) VALUES(" & date_start & "," & date_end & "," & ot_date_start & "," & ot_date_end & "," & store_date_start & "," & store_date_end & ",'" & addSlashes(note) & "',NOW(),'" & id_user & "','" & id_payroll_type & "'); SELECT LAST_INSERT_ID();"
                id_payroll = execute_query(query, 0, True, "", "", "", "")
                '
                FormEmpPayroll.load_payroll()
                FormEmpPayroll.GVPayrollPeriode.FocusedRowHandle = find_row(FormEmpPayroll.GVPayrollPeriode, "id_payroll", id_payroll)
                Close()
            Else 'edit
                Dim query As String = "UPDATE tb_emp_payroll SET periode_start=" & date_start & ",periode_end=" & date_end & ",ot_periode_start=" & ot_date_start & ",ot_periode_end=" & ot_date_end & ",store_periode_start=" & store_date_start & ",store_periode_end=" & store_date_end & ",note='" & addSlashes(note) & "',last_upd=NOW(),id_user_upd='" & id_user & "',id_payroll_type='" & id_payroll_type & "' WHERE id_payroll='" & id_payroll & "'"
                execute_non_query(query, True, "", "", "", "")
                '
                FormEmpPayroll.load_payroll()
                FormEmpPayroll.GVPayrollPeriode.FocusedRowHandle = find_row(FormEmpPayroll.GVPayrollPeriode, "id_payroll", id_payroll)
                Close()
            End If
        Else
            errorCustom("Please check your input.")
        End If
    End Sub

    Sub load_type_payroll()
        Dim query As String = "SELECT id_payroll_type,payroll_type FROM tb_emp_payroll_type ORDER BY sort ASC"
        viewLookupQuery(LEPayrollType, query, 0, "payroll_type", "id_payroll_type")
    End Sub

    Private Sub DEStart_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles DEStart.Validating
        Dim is_thr As String = execute_query("SELECT is_thr FROM tb_emp_payroll_type WHERE id_payroll_type = " + LEPayrollType.EditValue.ToString, 0, True, "", "", "", "")

        If DEStart.Text.ToString = "" And is_thr = "2" Then
            ErrorProvider.SetError(DEStart, "Don't leave it blank.")
        Else
            ErrorProvider.SetError(DEStart, String.Empty)
        End If
    End Sub

    Private Sub DEEnd_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles DEEnd.Validating
        If DEEnd.Text.ToString = "" Then
            ErrorProvider.SetError(DEEnd, "Don't leave it blank.")
        Else
            ErrorProvider.SetError(DEEnd, String.Empty)
        End If
    End Sub

    Private Sub LEPayrollType_EditValueChanged(sender As Object, e As EventArgs) Handles LEPayrollType.EditValueChanged
        Dim is_thr As String = execute_query("SELECT is_thr FROM tb_emp_payroll_type WHERE id_payroll_type = " + LEPayrollType.EditValue.ToString, 0, True, "", "", "", "")

        If is_thr = "1" Then
            LCEnd.Text = "Date"

            PCStart.Visible = False
            PCEnd.Visible = True
            PCStartOt.Visible = False
            PCEndOt.Visible = False
            PCStartStore.Visible = False
            PCEndStore.Visible = False

            Size = New Size(445, 230)
        Else
            LCEnd.Text = "Period End"

            PCStart.Visible = True
            PCEnd.Visible = True
            PCStartOt.Visible = True
            PCEndOt.Visible = True
            PCStartStore.Visible = True
            PCEndStore.Visible = True

            Size = New Size(445, 383)
        End If
    End Sub
End Class