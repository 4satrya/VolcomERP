Public Class FormReportEstWHInQty
    Dim bnew_active As String = "1"
    Dim bedit_active As String = "1"
    Dim bdel_active As String = "1"
    '
    Public is_qc As String = "-1"
    '
    Private Sub FormReportEstWHInQty_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub FormReportEstWHInQty_Deactivate(sender As Object, e As EventArgs) Handles MyBase.Deactivate
        FormMain.hide_rb()
    End Sub

    Private Sub FormReportEstWHInQty_Activated(sender As Object, e As EventArgs) Handles MyBase.Activated
        FormMain.show_rb(Name)
        check_menu()
    End Sub

    Sub check_menu()
        bnew_active = "0"
        bedit_active = "0"
        bdel_active = "0"
        checkFormAccess(Name)
        button_main(bnew_active, bedit_active, bdel_active)
    End Sub

    Private Sub FormReportEstWHInQty_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        load_type()
        DEStart.EditValue = Now
        DEEnd.EditValue = Now
        '
        If is_qc = "1" Then
            GridColumnEstInWH.OptionsColumn.ShowInCustomizationForm = False
            GridColumnEstInWH.Visible = False
            GridColumnStatus.OptionsColumn.ShowInCustomizationForm = True
            GridColumnStatus.Visible = True
            GridColumnEstInStoreDate.OptionsColumn.ShowInCustomizationForm = True
            GridColumnEstInStoreDate.Visible = True
        Else
            GridColumnEstInStoreDate.OptionsColumn.ShowInCustomizationForm = True
            GridColumnEstInStoreDate.Visible = True
            GridColumnEstInWH.OptionsColumn.ShowInCustomizationForm = True
            GridColumnEstInWH.Visible = True
            GridColumnStatus.OptionsColumn.ShowInCustomizationForm = False
            GridColumnStatus.Visible = False
        End If
    End Sub

    Sub load_type()
        Dim query As String = ""
        If is_qc = "1" Then
            query = "SELECT '2' AS opt,'Estimate Receive QC Date' AS type
UNION
SELECT '3' AS opt,'Estimate in Store Date' AS type"
        Else
            query = "SELECT '2' AS opt,'Estimate Receive QC Date' AS type
UNION
SELECT '1' AS opt,'Estimate in WH Date' AS type
UNION
SELECT '3' AS opt,'Estimate in Store Date' AS type"
        End If

        viewSearchLookupQuery(SLEType, query, "opt", "type", "opt")
    End Sub

    Sub load_data()
        Dim date_start As String = Date.Parse(DEStart.EditValue.ToString).ToString("yyyy-MM-dd")
        Dim date_end As String = Date.Parse(DEEnd.EditValue.ToString).ToString("yyyy-MM-dd")

        Dim query As String = "CALL report_est_in_wh_qty('" & is_qc & "','" & SLEType.EditValue.ToString & "','" & date_start & "','" & date_end & "')"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCWorkOrder.DataSource = data
        GVWorkOrder.BestFitColumns()
        '
    End Sub

    Private Sub DEStart_EditValueChanged(sender As Object, e As EventArgs) Handles DEStart.EditValueChanged
        Try
            DEEnd.Properties.MinValue = DEStart.EditValue
        Catch ex As Exception
        End Try
    End Sub

    Private Sub BViewSum_Click(sender As Object, e As EventArgs) Handles BViewSum.Click
        load_data()
    End Sub

    Private Sub GVWorkOrder_DoubleClick(sender As Object, e As EventArgs) Handles GVWorkOrder.DoubleClick
        Cursor = Cursors.WaitCursor
        If GVWorkOrder.RowCount > 0 And Not GVWorkOrder.IsGroupRow(GVWorkOrder.FocusedRowHandle) Then
            Dim report_mark_type As String = "-1"
            Dim id_report As String = "-1"
            '
            report_mark_type = GVWorkOrder.GetFocusedRowCellValue("report_mark_type").ToString
            id_report = GVWorkOrder.GetFocusedRowCellValue("id_report").ToString
            '
            Dim showpopup As ClassShowPopUp = New ClassShowPopUp()
            showpopup.opt = "no cost"
            showpopup.report_mark_type = report_mark_type
            showpopup.id_report = id_report
            showpopup.show()
        End If
        Cursor = Cursors.Default
    End Sub
End Class