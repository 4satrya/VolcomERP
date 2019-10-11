﻿Public Class FormProductionFinalClear
    Dim bnew_active As String = "1"
    Dim bedit_active As String = "1"
    Dim bdel_active As String = "1"

    Private Sub FormProductionFinalClear_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim data_dt As DataTable = execute_query("SELECT DATE(NOW()) AS `dt`", -1, True, "", "", "", "")
        DEFrom.EditValue = data_dt.Rows(0)("dt")
        DEUntil.EditValue = data_dt.Rows(0)("dt")
        DEFrom.Focus()
    End Sub

    Private Sub DEFrom_KeyDown(sender As Object, e As KeyEventArgs) Handles DEFrom.KeyDown
        If e.KeyCode = Keys.Enter Then
            DEUntil.Focus()
        End If
    End Sub

    Private Sub DEUntil_KeyDown(sender As Object, e As KeyEventArgs) Handles DEUntil.KeyDown
        If e.KeyCode = Keys.Enter Then
            BtnView.Focus()
        End If
    End Sub

    Sub viewFinalClear()
        Cursor = Cursors.WaitCursor
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

        'prepare query
        Dim query_c As ClassProductionFinalClear = New ClassProductionFinalClear()
        Dim query As String = query_c.queryMain("AND (f.prod_fc_date>='" + date_from_selected + "' AND f.prod_fc_date<='" + date_until_selected + "') ", "2")
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCFinalClear.DataSource = data
        GVFinalClear.BestFitColumns()
        check_menu()
        Cursor = Cursors.Default
    End Sub

    Private Sub BtnView_Click(sender As Object, e As EventArgs) Handles BtnView.Click
        viewFinalClear()
    End Sub

    Private Sub FormProductionFinalClear_Activated(sender As Object, e As EventArgs) Handles MyBase.Activated
        FormMain.show_rb(Name)
        check_menu()
    End Sub

    Sub noManipulating()
        If XTCQCReport.SelectedTabPageIndex = 0 Then
            Try
                Dim indeks As Integer = GVFinalClear.FocusedRowHandle
                If indeks < 0 Then
                    bnew_active = "1"
                    bedit_active = "0"
                    bdel_active = "0"
                Else
                    bnew_active = "1"
                    bedit_active = "1"
                    bdel_active = "0"
                End If
                checkFormAccess(Name)
                button_main(bnew_active, bedit_active, bdel_active)
            Catch ex As Exception
            End Try
        ElseIf XTCQCReport.SelectedTabPageIndex = 1 Then
            'noaction
        End If
    End Sub

    Sub check_menu()
        If XTCQCReport.SelectedTabPageIndex = 0 Then
            If GVFinalClear.RowCount < 1 Then
                'hide all except new
                bnew_active = "1"
                bedit_active = "0"
                bdel_active = "0"
                checkFormAccess(Name)
                button_main(bnew_active, bedit_active, bdel_active)
            Else
                'show all
                bnew_active = "1"
                bedit_active = "1"
                bdel_active = "0"
                noManipulating()
            End If
        ElseIf XTCQCReport.SelectedTabPageIndex = 1 Then
            bnew_active = "0"
            bedit_active = "0"
            bdel_active = "0"
            checkFormAccess(Name)
            button_main(bnew_active, bedit_active, bdel_active)
        End If
    End Sub

    Private Sub GVFinalClear_FocusedRowChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles GVFinalClear.FocusedRowChanged
        noManipulating()
    End Sub

    Private Sub GVFinalClear_DoubleClick(sender As Object, e As EventArgs) Handles GVFinalClear.DoubleClick
        If GVFinalClear.RowCount > 0 And GVFinalClear.FocusedRowHandle >= 0 Then
            FormMain.but_edit()
        End If
    End Sub

    Private Sub FormProductionFinalClear_Deactivate(sender As Object, e As EventArgs) Handles MyBase.Deactivate
        FormMain.hide_rb()
    End Sub

    Private Sub XTCQCReport_SelectedPageChanged(sender As Object, e As DevExpress.XtraTab.TabPageChangedEventArgs) Handles XTCQCReport.SelectedPageChanged
        check_menu()
    End Sub
End Class