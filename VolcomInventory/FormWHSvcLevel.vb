Public Class FormWHSvcLevel
    Private Sub FormWHSvcLevel_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim data_dt As DataTable = execute_query("SELECT DATE(NOW()) AS `dt`", -1, True, "", "", "", "")
        DEFrom.EditValue = data_dt.Rows(0)("dt")
        DEUntil.EditValue = data_dt.Rows(0)("dt")
        DEFromCode.EditValue = data_dt.Rows(0)("dt")
        DEUntilCode.EditValue = data_dt.Rows(0)("dt")
        DEFromAcc.EditValue = data_dt.Rows(0)("dt")
        DEUntilAcc.EditValue = data_dt.Rows(0)("dt")
        DEFromReturn.EditValue = data_dt.Rows(0)("dt")
        DEUntilReturn.EditValue = data_dt.Rows(0)("dt")
    End Sub

    Sub viewSvcBySO()
        'Prepare paramater
        Dim date_from_selected As String = "0000-01-01"
        Dim date_until_selected As String = "9999-01-01"
        Try
            date_from_selected = DateTime.Parse(DEFrom.EditValue.ToString).ToString("yyyy-MM-dd")
        Catch ex As Exception
        End Try
        Try
            date_until_selected = DateTime.Parse(DEUntil.EditValue.ToString).ToString("yyyy-MM-dd")
        Catch ex As Exception
        End Try

        Dim query As String = "CALL view_svc_level_so('" + date_from_selected + "','" + date_until_selected + "') "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCBySO.DataSource = data
    End Sub

    Sub viewSvcByCode()
        'Prepare paramater
        Dim date_from_selected As String = "0000-01-01"
        Dim date_until_selected As String = "9999-01-01"
        Try
            date_from_selected = DateTime.Parse(DEFromCode.EditValue.ToString).ToString("yyyy-MM-dd")
        Catch ex As Exception
        End Try
        Try
            date_until_selected = DateTime.Parse(DEUntilCode.EditValue.ToString).ToString("yyyy-MM-dd")
        Catch ex As Exception
        End Try

        Dim query As String = "CALL view_svc_level_code('" + date_from_selected + "','" + date_until_selected + "') "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCByCode.DataSource = data
    End Sub

    Sub viewSvcByAcc()
        'Prepare paramater
        Dim date_from_selected As String = "0000-01-01"
        Dim date_until_selected As String = "9999-01-01"
        Try
            date_from_selected = DateTime.Parse(DEFromAcc.EditValue.ToString).ToString("yyyy-MM-dd")
        Catch ex As Exception
        End Try
        Try
            date_until_selected = DateTime.Parse(DEUntilAcc.EditValue.ToString).ToString("yyyy-MM-dd")
        Catch ex As Exception
        End Try

        Dim query As String = "CALL view_svc_level_acc('" + date_from_selected + "', '" + date_until_selected + "') "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCByAcco.DataSource = data
    End Sub

    Private Sub BtnView_Click(sender As Object, e As EventArgs) Handles BtnView.Click
        Cursor = Cursors.WaitCursor
        viewSvcBySO()
        Cursor = Cursors.Default
    End Sub

    Private Sub FormWHSvcLevel_Activated(sender As Object, e As EventArgs) Handles MyBase.Activated
        FormMain.show_rb(Name)
        checkFormAccess(Name)
        checkFocus()
    End Sub

    Private Sub FormWHSvcLevel_Deactivate(sender As Object, e As EventArgs) Handles MyBase.Deactivate
        FormMain.hide_rb()
    End Sub

    Private Sub BtnAcc_Click(sender As Object, e As EventArgs) Handles BtnAcc.Click
        Cursor = Cursors.WaitCursor
        viewSvcByAcc()
        Cursor = Cursors.Default
    End Sub

    Private Sub BtnViewCode_Click(sender As Object, e As EventArgs) Handles BtnViewCode.Click
        Cursor = Cursors.WaitCursor
        viewSvcByCode()
        Cursor = Cursors.Default
    End Sub

    Private Sub XTCSvcLelel_SelectedPageChanged(sender As Object, e As DevExpress.XtraTab.TabPageChangedEventArgs) Handles XTCSvcLelel.SelectedPageChanged
        checkFocus()
    End Sub

    Sub checkFocus()
        If XTCSvcLelel.SelectedTabPageIndex = 0 Then
            DEFrom.Focus()
        ElseIf XTCSvcLelel.SelectedTabPageIndex = 1 Then
            DEFromCode.Focus()
        ElseIf XTCSvcLelel.SelectedTabPageIndex = 2 Then
            DEFromAcc.Focus()
        ElseIf XTCSvcLelel.SelectedTabPageIndex = 3 Then
            DEFromReturn.Focus()
        End If
    End Sub

    Private Sub DEFrom_KeyDown(sender As Object, e As KeyEventArgs) Handles DEFrom.KeyDown
        If e.KeyCode = Keys.Enter Then
            DEUntil.Focus()
        End If
    End Sub

    Private Sub DEUntil_KeyDown(sender As Object, e As KeyEventArgs) Handles DEUntil.KeyDown
        If e.KeyCode = Keys.Enter Then
            Cursor = Cursors.WaitCursor
            viewSvcBySO()
            BtnView.Focus()
            Cursor = Cursors.Default
        End If
    End Sub

    Private Sub DEFromCode_KeyDown(sender As Object, e As KeyEventArgs) Handles DEFromCode.KeyDown
        If e.KeyCode = Keys.Enter Then
            DEUntilCode.Focus()
        End If
    End Sub

    Private Sub DEUntilCode_KeyDown(sender As Object, e As KeyEventArgs) Handles DEUntilCode.KeyDown
        If e.KeyCode = Keys.Enter Then
            Cursor = Cursors.WaitCursor
            viewSvcByCode()
            BtnViewCode.Focus()
            Cursor = Cursors.Default
        End If
    End Sub

    Private Sub DEFromAcc_KeyDown(sender As Object, e As KeyEventArgs) Handles DEFromAcc.KeyDown
        If e.KeyCode = Keys.Enter Then
            DEUntilAcc.Focus()
        End If
    End Sub

    Private Sub DEUntilAcc_KeyDown(sender As Object, e As KeyEventArgs) Handles DEUntilAcc.KeyDown
        If e.KeyCode = Keys.Enter Then
            Cursor = Cursors.WaitCursor
            viewSvcByAcc()
            BtnAcc.Focus()
            Cursor = Cursors.Default
        End If
    End Sub

    Private Sub BtnViewReturn_Click(sender As Object, e As EventArgs) Handles BtnViewReturn.Click
        Cursor = Cursors.WaitCursor
        viewSvcReturn()
        Cursor = Cursors.Default
    End Sub

    Sub viewSvcReturn()
        'Prepare paramater
        Dim date_from_selected As String = "0000-01-01"
        Dim date_until_selected As String = "9999-01-01"
        Try
            date_from_selected = DateTime.Parse(DEFromReturn.EditValue.ToString).ToString("yyyy-MM-dd")
        Catch ex As Exception
        End Try
        Try
            date_until_selected = DateTime.Parse(DEUntilReturn.EditValue.ToString).ToString("yyyy-MM-dd")
        Catch ex As Exception
        End Try

        Dim query As String = "CALL view_svc_level_return('" + date_from_selected + "','" + date_until_selected + "') "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCReturn.DataSource = data
    End Sub

    Private Sub DEFromReturn_KeyDown(sender As Object, e As KeyEventArgs) Handles DEFromReturn.KeyDown
        If e.KeyCode = Keys.Enter Then
            DEUntilReturn.Focus()
        End If
    End Sub

    Private Sub DEUntilReturn_KeyDown(sender As Object, e As KeyEventArgs) Handles DEUntilReturn.KeyDown
        If e.KeyCode = Keys.Enter Then
            BtnViewReturn.Focus()
        End If
    End Sub
End Class