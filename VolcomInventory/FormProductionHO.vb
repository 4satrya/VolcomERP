Public Class FormProductionHO
    Public is_public_form As String = "false"

    Private Sub FormProductionHO_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim time_now As DateTime = getTimeDB()
        DEFrom.EditValue = time_now
        DEUntil.EditValue = time_now
        DEFromDetail.EditValue = time_now
        DEUntilDetail.EditValue = time_now
        DEUntilSummary.EditValue = time_now

        If is_public_form Then
            BtnViewPending.Visible = False
            PanelControlSendEmail.Visible = False
            GridColumnis_select.Visible = False
        End If

        viewSeason()
    End Sub

    Sub viewSeason()
        Dim query As String = "SELECT 0 AS `id_season`, 0 AS `range`, 'All Season' AS `season`
        UNION
        SELECT ss.id_season, r.`range`, ss.season 
        FROM tb_season ss
        INNER JOIN tb_range r ON r.id_range = ss.id_range
        ORDER BY `range` ASC "
        viewSearchLookupQuery(SLESeason, query, "id_season", "season", "id_season")
    End Sub

    Sub viewHOStatus()
        Dim query As String = "SELECT ho.id_ho_status AS `id_ho_status_input`, ho.ho_status  
        FROM tb_lookup_ho_status ho "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        RepoHOStatus.DataSource = Nothing
        RepoHOStatus.DataSource = data
        RepoHOStatus.DisplayMember = "ho_status"
        RepoHOStatus.ValueMember = "id_ho_status_input"
        'If CheckEdit1.EditValue = True Then
        '    RepositoryItemSearchLookUpEdit1View.ActiveFilterString = "[acc_description] like '%" + LECat.Text.ToString + "%'"
        '    RepositoryItemSearchLookUpEdit1View.ApplyColumnsFilter()
        '    RepositoryItemSearchLookUpEdit1View.RefreshData()
        'End If
    End Sub


    Private Sub FormProductionHO_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub FormProductionHO_Activated(sender As Object, e As EventArgs) Handles MyBase.Activated
        FormMain.show_rb(Name)
        checkFormAccess(Name)
    End Sub

    Private Sub FormProductionHO_Deactivate(sender As Object, e As EventArgs) Handles MyBase.Deactivate
        FormMain.hide_rb()
    End Sub

    Private Sub BtnView_Click(sender As Object, e As EventArgs) Handles BtnView.Click
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
        viewRegList("AND (pl.pl_prod_order_date>=""" + date_from_selected + """ AND pl.pl_prod_order_date<=""" + date_until_selected + """) ")
        PanelControlSendEmail.Visible = False
        GridColumnis_select.Visible = False
        GridColumnid_ho_status_input.Visible = False
    End Sub

    Sub viewRegList(ByVal cond As String)
        Cursor = Cursors.WaitCursor
        Dim query As String = "CALL view_pl_prod_report('" + cond + "') "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCList.DataSource = data
        GVList.BestFitColumns()
        Cursor = Cursors.Default
    End Sub

    Private Sub BtnViewPending_Click(sender As Object, e As EventArgs) Handles BtnViewPending.Click
        viewHOStatus()
        viewRegList("AND ho_notif=2 ")
        PanelControlSendEmail.Visible = True
        GridColumnis_select.VisibleIndex = 0
        GridColumnid_ho_status_input.VisibleIndex = 1
    End Sub

    Private Sub GVList_CustomColumnDisplayText(sender As Object, e As DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs) Handles GVList.CustomColumnDisplayText
        If e.Column.FieldName = "no" Then
            e.DisplayText = (e.ListSourceRowIndex + 1).ToString()
        End If
    End Sub

    Private Sub GVList_DoubleClick(sender As Object, e As EventArgs) Handles GVList.DoubleClick
        If GVList.RowCount > 0 And GVList.FocusedRowHandle >= 0 Then
            Cursor = Cursors.WaitCursor
            Dim m As New ClassShowPopUp()
            m.report_mark_type = 33
            m.id_report = GVList.GetFocusedRowCellValue("id_pl_prod_order").ToString
            m.show()
            Cursor = Cursors.Default
        End If
    End Sub

    Private Sub CESelAll_CheckedChanged(sender As Object, e As EventArgs) Handles CESelAll.CheckedChanged
        Cursor = Cursors.WaitCursor
        Dim is_select As String = ""
        If CESelAll.EditValue = True Then
            is_select = "Yes"
        Else
            is_select = "No"
        End If
        For i As Integer = 0 To ((GVList.RowCount - 1) - GetGroupRowCount(GVList))
            GVList.SetRowCellValue(i, "is_select", is_select)
        Next
        Cursor = Cursors.Default
    End Sub

    Private Sub BtnSendEmail_Click(sender As Object, e As EventArgs) Handles BtnSendEmail.Click
        Cursor = Cursors.WaitCursor
        makeSafeGV(GVList)
        GVList.ActiveFilterString = "[is_select]='Yes'"
        If GVList.RowCount > 0 Then
            Dim confirm As DialogResult = DevExpress.XtraEditors.XtraMessageBox.Show("Are you sure to continue this process?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
            If confirm = Windows.Forms.DialogResult.Yes Then
                Dim id As String = ""
                Dim query_upd As String = ""
                For i As Integer = 0 To GVList.RowCount - 1
                    If i > 0 Then
                        id += "OR "
                    End If
                    id += "pl.id_pl_prod_order=" + GVList.GetRowCellValue(i, "id_pl_prod_order").ToString + " "
                    query_upd += "UPDATE tb_pl_prod_order pl SET pl.id_ho_status=" + GVList.GetRowCellValue(i, "id_ho_status_input").ToString + ", pl.ho_notif=1, pl.ho_notif_date=NOW(), pl.ho_notif_by=" + id_user + " WHERE pl.id_pl_prod_order=" + GVList.GetRowCellValue(i, "id_pl_prod_order").ToString + "; "
                Next
                execute_non_query(query_upd, True, "", "", "", "")

                Try
                    'send email
                    Dim em As New ClassSendEmail()
                    em.report_mark_type = "33"
                    Dim qty As String = Decimal.Parse(GVList.Columns("total_qty").SummaryItem.SummaryValue.ToString).ToString("N0")
                    em.par1 = qty
                    em.id_report = id
                    em.date_string = DateTime.Parse(getTimeDB).ToString("dd MMMM yyyy HH:mm")
                    em.send_email()
                Catch ex As Exception
                    stopCustom(ex.ToString)
                End Try

                'refresh view
                GCList.DataSource = Nothing
            End If
        Else
                stopCustom("No data selected")
        End If
        GVList.ActiveFilterString = ""
        Cursor = Cursors.Default
    End Sub

    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs) Handles BtnViewDetail.Click
        Cursor = Cursors.WaitCursor
        Dim date_from_selected As String = "0000-01-01"
        Dim date_until_selected As String = "9999-01-01"
        Try
            date_from_selected = DateTime.Parse(DEFromDetail.EditValue.ToString).ToString("yyyy-MM-dd")
        Catch ex As Exception
        End Try
        Try
            date_until_selected = DateTime.Parse(DEUntilDetail.EditValue.ToString).ToString("yyyy-MM-dd")
        Catch ex As Exception
        End Try
        viewDetail("AND (pl.pl_prod_order_date>=""" + date_from_selected + """ AND pl.pl_prod_order_date<=""" + date_until_selected + """) ")
        Cursor = Cursors.Default
    End Sub

    Sub viewDetail(ByVal cond As String)
        Cursor = Cursors.WaitCursor
        Dim query As String = "CALL view_pl_prod_report_det_ver2('" + cond + "') "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCDetail.DataSource = data
        GVDetail.BestFitColumns()
        Cursor = Cursors.Default
    End Sub

    Private Sub GVList_CellValueChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles GVList.CellValueChanged
        GVList.BestFitColumns()
    End Sub

    Private Sub BtnViewSummary_Click(sender As Object, e As EventArgs) Handles BtnViewSummary.Click
        viewSummary()
    End Sub

    Sub viewSummary()
        Cursor = Cursors.WaitCursor
        Dim date_until_selected As String = "9999-01-01"
        Try
            date_until_selected = DateTime.Parse(DEUntilDetail.EditValue.ToString).ToString("yyyy-MM-dd")
        Catch ex As Exception
        End Try
        Dim cond As String = "AND pl.pl_prod_order_date<=""" + date_until_selected + """ "
        Dim id_season As String = SLESeason.EditValue.ToString
        If id_season <> "0" Then
            cond += "AND d.id_season=" + id_season + " "
        End If
        Dim query As String = "CALL view_pl_prod_report_summary('" + cond + "')"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCSummary.DataSource = data
        GVSummary.BestFitColumns()
        Cursor = Cursors.Default
    End Sub
End Class