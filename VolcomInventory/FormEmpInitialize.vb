Public Class FormEmpInitialize
    Private Sub FormEmpInitialize_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        viewEmployee()
    End Sub

    Sub viewEmployee()
        Dim query As String = "CALL view_employee('AND !ISNULL(emp.employee_code)', 2)"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCEmployee.DataSource = data
    End Sub

    Private Sub FormEmpInitialize_Activated(sender As Object, e As EventArgs) Handles MyBase.Activated
        FormMain.show_rb(Name)
        checkFormAccess(Name)
    End Sub

    Private Sub FormEmpInitialize_Deactivate(sender As Object, e As EventArgs) Handles MyBase.Deactivate
        FormMain.hide_rb()
    End Sub




    Private Sub GVEmployee_DoubleClick(sender As Object, e As EventArgs) Handles GVEmployee.DoubleClick
        If GVEmployee.RowCount > 0 And GVEmployee.FocusedRowHandle >= 0 Then
            Cursor = Cursors.WaitCursor
            FormMain.but_edit()
            Cursor = Cursors.Default
        End If
    End Sub

    Private Sub CheckEdit1_CheckedChanged(sender As Object, e As EventArgs) Handles CheckEdit1.CheckedChanged
        If GVEmployee.RowCount > 0 Then
            Dim cek As String = CheckEdit1.EditValue.ToString
            For i As Integer = 0 To ((GVEmployee.RowCount - 1) - GetGroupRowCount(GVEmployee))
                If cek Then
                    GVEmployee.SetRowCellValue(i, "is_select", "Yes")
                Else
                    GVEmployee.SetRowCellValue(i, "is_select", "No")
                End If
            Next
        End If
    End Sub

    Sub addUser()
        'Cursor = Cursors.WaitCursor
        'GVEmployee.ActiveFilterString = "[is_select]='Yes'"
        'If GVEmployee.RowCount > 0 Then
        '    Dim fp As New ClassFingerPrint()
        '    Dim data_fp As DataTable = fp.get_fp_register()
        '    fp.ip = data_fp.Rows(0)("ip").ToString
        '    fp.port = data_fp.Rows(0)("port").ToString
        '    fp.connect()
        '    fp.disable_fp()
        '    For i As Integer = 0 To ((GVEmployee.RowCount - 1) - GetGroupRowCount(GVEmployee))
        '        Dim is_select As String = GVEmployee.GetRowCellValue(i, "is_select").ToString
        '        Dim code As String = GVEmployee.GetRowCellValue(i, "employee_code").ToString
        '        Dim name As String = GVEmployee.GetRowCellValue(i, "employee_name").ToString
        '        fp.setUserInfo(code, name, "", 0, True)
        '    Next
        '    fp.refresh_fp()
        '    fp.enable_fp()
        '    fp.disconnect()
        '    infoCustom("OK")
        'Else
        '    stopCustom("No item selected.")
        'End If
        'GVEmployee.ActiveFilterString = ""
        'Cursor = Cursors.Default
    End Sub

    Private Sub RepositoryItemCheckEdit1_EditValueChanged(sender As Object, e As EventArgs) Handles RepositoryItemCheckEdit1.EditValueChanged
        GVEmployee.PostEditor()
    End Sub
End Class