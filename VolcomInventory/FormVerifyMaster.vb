Public Class FormVerifyMaster
    Public id_store As String = "-1"
    Public id_store_contact As String = "-1"
    Dim id_del As String = ""

    Private Sub FormVerifyMaster_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'date now
        Dim data_dt As DataTable = execute_query("SELECT DATE(NOW()) AS `dt`", -1, True, "", "", "", "")
        DEFrom.EditValue = data_dt.Rows(0)("dt")
        DEUntil.EditValue = data_dt.Rows(0)("dt")
        DEFromHist.EditValue = data_dt.Rows(0)("dt")
        DEUntilHist.EditValue = data_dt.Rows(0)("dt")
    End Sub

    Private Sub FormVerifyMaster_Activated(sender As Object, e As EventArgs) Handles MyBase.Activated
        FormMain.show_rb(Name)
        checkFormAccess(Name)
    End Sub

    Private Sub FormVerifyMaster_Deactivate(sender As Object, e As EventArgs) Handles MyBase.Deactivate
        FormMain.hide_rb()
    End Sub

    Private Sub BtnBrowse_Click(sender As Object, e As EventArgs) Handles BtnBrowse.Click
        Cursor = Cursors.WaitCursor
        FormPopUpContact.id_pop_up = "92"
        FormPopUpContact.id_cat = "6"
        FormPopUpContact.ShowDialog()
        Cursor = Cursors.Default
    End Sub

    Sub viewDel()
        GVSalesDelOrder.OptionsBehavior.Editable = True
        CESelAll.Enabled = True
        BtnReset.Visible = False
        BtnView.Enabled = False
        GCSalesDelOrder.DataSource = Nothing
        BtnLoadData.Visible = False
        GCData.DataSource = Nothing
        BtnConfirm.Visible = False

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

        Dim query_c As ClassSalesDelOrder = New ClassSalesDelOrder()
        Dim query As String = query_c.queryMain("AND a.is_verify_master=2 AND a.is_use_unique_code='1' AND d.id_comp='" + id_store + "' AND (a.pl_sales_order_del_date>='" + date_from_selected + "' AND a.pl_sales_order_del_date<='" + date_until_selected + "') ", "2")
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCSalesDelOrder.DataSource = data
        If GVSalesDelOrder.RowCount > 0 Then
            GVSalesDelOrder.BestFitColumns()
            BtnLoadData.Visible = True
        Else
            BtnLoadData.Visible = False
        End If
    End Sub

    Private Sub BtnLoadData_Click(sender As Object, e As EventArgs) Handles BtnLoadData.Click
        viewData()
    End Sub

    Sub viewData()
        Cursor = Cursors.WaitCursor
        GCData.DataSource = Nothing
        BtnConfirm.Visible = False

        makeSafeGV(GVSalesDelOrder)
        GVSalesDelOrder.ActiveFilterString = "[is_select]='Yes'"
        id_del = ""
        If GVSalesDelOrder.RowCount <= 0 Then
            stopCustom("No item selected")
            GVSalesDelOrder.OptionsBehavior.Editable = True
            CESelAll.Enabled = True
        Else
            GVSalesDelOrder.OptionsBehavior.Editable = False
            CESelAll.Enabled = False

            For i As Integer = 0 To GVSalesDelOrder.RowCount - 1
                If i > 0 Then
                    id_del += "OR "
                End If
                id_del += "d.id_pl_sales_order_del = '" + GVSalesDelOrder.GetRowCellValue(i, "id_pl_sales_order_del").ToString + "' "
            Next

            'call proc
            Dim delc As New ClassSalesDelOrder()
            Dim data As DataTable = delc.getMasterDelivery(id_del)
            GCData.DataSource = data
            If GVData.RowCount > 0 Then
                GVData.BestFitColumns()
                BtnConfirm.Visible = True
                BtnLoadData.Visible = False
                BtnReset.Visible = True
            Else
                BtnConfirm.Visible = False
                BtnLoadData.Visible = True
                BtnReset.Visible = False
            End If
        End If
        makeSafeGV(GVSalesDelOrder)
        Cursor = Cursors.Default
    End Sub

    Private Sub ViewDetailToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ViewDetailToolStripMenuItem.Click
        Cursor = Cursors.WaitCursor
        If GVSalesDelOrder.RowCount > 0 And GVSalesDelOrder.FocusedRowHandle >= 0 Then
            Dim id_del As String = GVSalesDelOrder.GetFocusedRowCellValue("id_pl_sales_order_del").ToString
            Dim menu As New ClassShowPopUp()
            menu.id_report = id_del
            menu.report_mark_type = "43"
            menu.show()
        End If
        Cursor = Cursors.Default
    End Sub

    Private Sub BtnReset_Click(sender As Object, e As EventArgs) Handles BtnReset.Click
        Cursor = Cursors.WaitCursor
        viewDel()
        GCData.DataSource = Nothing
        BtnConfirm.Visible = False
        Cursor = Cursors.Default
    End Sub

    Private Sub CESelAll_CheckedChanged(sender As Object, e As EventArgs) Handles CESelAll.CheckedChanged
        If GVSalesDelOrder.RowCount > 0 Then
            Dim cek As String = CESelAll.EditValue.ToString
            For i As Integer = ((GVSalesDelOrder.RowCount - 1) - GetGroupRowCount(GVSalesDelOrder)) To 0 Step -1
                If cek Then
                    GVSalesDelOrder.SetRowCellValue(i, "is_select", "Yes")
                Else
                    GVSalesDelOrder.SetRowCellValue(i, "is_select", "No")
                End If
            Next
        End If
    End Sub

    Private Sub DEFrom_EditValueChanged(sender As Object, e As EventArgs) Handles DEFrom.EditValueChanged
        If id_store <> "-1" Then
            BtnView.Enabled = True
        Else
            BtnView.Enabled = False
        End If
        GCSalesDelOrder.DataSource = Nothing
        GCData.DataSource = Nothing
        BtnLoadData.Visible = False
        BtnReset.Visible = False
        BtnConfirm.Visible = False
    End Sub

    Private Sub DEUntil_EditValueChanged(sender As Object, e As EventArgs) Handles DEUntil.EditValueChanged
        If id_store <> "-1" Then
            BtnView.Enabled = True
        Else
            BtnView.Enabled = False
        End If
        GCSalesDelOrder.DataSource = Nothing
        GCData.DataSource = Nothing
        BtnLoadData.Visible = False
        BtnReset.Visible = False
        BtnConfirm.Visible = False
    End Sub

    Private Sub GVData_CustomColumnDisplayText(sender As Object, e As DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs) Handles GVData.CustomColumnDisplayText
        If e.Column.FieldName = "no" Then
            e.DisplayText = (e.ListSourceRowIndex + 1).ToString()
        End If
    End Sub

    Private Sub BtnView_Click(sender As Object, e As EventArgs) Handles BtnView.Click
        Cursor = Cursors.WaitCursor
        viewDel()
        Cursor = Cursors.Default
    End Sub

    Private Sub BtnConfirm_Click(sender As Object, e As EventArgs) Handles BtnConfirm.Click
        Dim confirm As DialogResult = DevExpress.XtraEditors.XtraMessageBox.Show("Are you sure you want to verify these master and send directly to " + TxtCompName.Text + " ?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
        If confirm = Windows.Forms.DialogResult.Yes Then
            Cursor = Cursors.WaitCursor
            Dim em As New ClassSendEmail()
            em.report_mark_type = "43"
            em.id_report = id_store
            em.design_code = TxtEmail.Text
            em.design = TXTCP.Text
            em.comment = DEFrom.Text + " - " + DEUntil.Text
            em.par1 = id_del
            em.par2 = TxtCompName.Text
            em.send_email()

            'update status
            Dim query_upd As String = "UPDATE tb_pl_sales_order_del d SET d.is_verify_master=1, d.verified_by=" + id_user + ", d.verified_date=NOW() 
             WHERE (" + id_del + ") "
            execute_non_query(query_upd, True, "", "", "", "")

            'refresh 
            viewDel()
            Cursor = Cursors.Default
        End If
    End Sub

    Sub viewHistory()
        Cursor = Cursors.WaitCursor
        Dim date_from_selected As String = "0000-01-01"
        Dim date_until_selected As String = "9999-01-01"
        Try
            date_from_selected = DateTime.Parse(DEFromHist.EditValue.ToString).ToString("yyyy-MM-dd")
        Catch ex As Exception
        End Try
        Try
            date_until_selected = DateTime.Parse(DEUntilHist.EditValue.ToString).ToString("yyyy-MM-dd")
        Catch ex As Exception
        End Try

        Dim query As String = "SELECT a.id_pl_sales_order_del, a.pl_sales_order_del_date, a.pl_sales_order_del_number, a.id_sales_order, a.id_store_contact_to, (d.id_comp) AS `id_store`,(d.comp_name) AS store_name_to, (d.comp_number) AS store_number_to, CONCAT(d.comp_number, ' - ', d.comp_name) AS `store`,
        a.verified_date, e.employee_name AS `verified_by`
        FROM tb_pl_sales_order_del a 
        INNER JOIN tb_m_comp_contact c ON c.id_comp_contact = a.id_store_contact_to  
        INNER JOIN tb_m_comp d ON c.id_comp = d.id_comp 
        INNER JOIN tb_m_user u ON u.id_user = a.verified_by
        INNER JOIN tb_m_employee e ON e.id_employee = u.id_employee
        WHERE a.id_pl_sales_order_del>0 AND a.is_verify_master=1 AND (DATE(a.verified_date)>='" + date_from_selected + "' AND DATE(a.verified_date)<='" + date_until_selected + "') "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCHistory.DataSource = data
        GVHistory.BestFitColumns()
        Cursor = Cursors.Default
    End Sub

    Private Sub ToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem1.Click
        Cursor = Cursors.WaitCursor
        If GVHistory.RowCount > 0 And GVHistory.FocusedRowHandle >= 0 Then
            Dim id_del As String = GVHistory.GetFocusedRowCellValue("id_pl_sales_order_del").ToString
            Dim menu As New ClassShowPopUp()
            menu.id_report = id_del
            menu.report_mark_type = "43"
            menu.show()
        End If
        Cursor = Cursors.Default
    End Sub

    Private Sub BtnViewHist_Click(sender As Object, e As EventArgs) Handles BtnViewHist.Click
        viewHistory()
    End Sub
End Class