Public Class FormEmpUniPeriodDet
    Public action As String = "-1"
    Public id_emp_uni_period As String = "-1"

    Private Sub FormEmpUniPeriodDet_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        actionLoad()
    End Sub

    Sub actionLoad()
        If action = "ins" Then
            XTCUni.Enabled = False
            BtnSave.Text = "Create New"
            TxtTolerance.EditValue = 0
        Else
            Dim query_c As New ClassEmpUni()
            Dim query As String = query_c.queryMain("AND u.id_emp_uni_period=" + id_emp_uni_period + "", "1")
            Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
            TxtPeriodName.Text = data.Rows(0)("period_name").ToString
            DEStart.EditValue = data.Rows(0)("selection_date_start")
            DEEnd.EditValue = data.Rows(0)("selection_date_end")
            DEDist.EditValue = data.Rows(0)("distribution_date")
            TxtTolerance.EditValue = data.Rows(0)("tolerance")
            XTCUni.Enabled = True
            BtnSave.Text = "Save Changes"
            viewDetail()
            viewDesignList()
            viewOrder()
        End If
    End Sub

    Sub viewDetail()
        Dim query As String = "CALL view_emp_uni_budget(" + id_emp_uni_period + ") "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCDetail.DataSource = data
    End Sub

    Sub viewDesignList()
        Cursor = Cursors.WaitCursor
        Dim query As String = "CALL view_emp_uni_design(" + id_emp_uni_period + ") "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCDesignList.DataSource = data
        Cursor = Cursors.Default
    End Sub

    Sub viewOrder()
        Cursor = Cursors.WaitCursor
        Dim query_c As New ClassEmpUni()
        Dim query As String = query_c.queryMainOrder("AND p.id_emp_uni_period=" + id_emp_uni_period + " ", "2", "-1")
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCSalesOrder.DataSource = data
        Cursor = Cursors.Default
    End Sub

    Private Sub BtnClose_Click(sender As Object, e As EventArgs) Handles BtnClose.Click
        Close()
    End Sub

    Private Sub BtnSave_Click(sender As Object, e As EventArgs) Handles BtnSave.Click
        If DEStart.Text <> "" And DEEnd.Text <> "" And DEDist.Text <> "" Then
            Dim period_name As String = addSlashes(TxtPeriodName.Text)
            Dim selection_date_start As String = DateTime.Parse(DEStart.EditValue.ToString).ToString("yyyy-MM-dd")
            Dim selection_date_end As String = DateTime.Parse(DEEnd.EditValue.ToString).ToString("yyyy-MM-dd")
            Dim distribution_date As String = DateTime.Parse(DEDist.EditValue.ToString).ToString("yyyy-MM-dd")
            Dim tolerance As String = decimalSQL(TxtTolerance.EditValue.ToString)
            If action = "ins" Then
                Dim query As String = "INSERT INTO tb_emp_uni_period(period_name, selection_date_start, selection_date_end, created_date, distribution_date, tolerance) VALUES "
                query += "('" + period_name + "', '" + selection_date_start + "', '" + selection_date_end + "', NOW(), '" + distribution_date + "','" + tolerance + "'); SELECT LAST_INSERT_ID(); "
                id_emp_uni_period = execute_query(query, 0, True, "", "", "", "")
                action = "upd"
                actionLoad()
                infoCustom("Uniform period was created successfully, please input detail budget.")
            Else
                Dim query As String = "UPDATE tb_emp_uni_period SET period_name='" + period_name + "', selection_date_start='" + selection_date_start + "', selection_date_end='" + selection_date_end + "', distribution_date='" + distribution_date + "', tolerance='" + tolerance + "' WHERE id_emp_uni_period='" + id_emp_uni_period + "' "
                execute_non_query(query, True, "", "", "", "")
                action = "upd"
                actionLoad()
                infoCustom("Uniform period was edited successfully.")
            End If
            FormEmpUniPeriod.viewUniformPeriod()
            FormEmpUniPeriod.GVUni.FocusedRowHandle = find_row(FormEmpUniPeriod.GVUni, "id_emp_uni_period", id_emp_uni_period)
        Else
            stopCustom("Period can't blank")
        End If

    End Sub

    Private Sub FormEmpUniPeriodDet_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub BtnAdd_Click(sender As Object, e As EventArgs) Handles BtnAdd.Click
        Cursor = Cursors.WaitCursor
        FormEmpUniPeriodSingle.action = "ins"
        FormEmpUniPeriodSingle.ShowDialog()
        Cursor = Cursors.Default
    End Sub

    Private Sub BtnEdit_Click(sender As Object, e As EventArgs) Handles BtnEdit.Click
        Dim id As String = "-1"
        Try
            id = GVDetail.GetFocusedRowCellValue("id_emp_uni_budget").ToString
        Catch ex As Exception
        End Try
        If id <> "-1" Then
            FormEmpUniPeriodSingle.action = "upd"
            FormEmpUniPeriodSingle.ShowDialog()
        End If
    End Sub

    Private Sub BtnPrintBudget_Click(sender As Object, e As EventArgs) Handles BtnPrintBudget.Click
        Cursor = Cursors.WaitCursor
        print(GCDetail, "UNIFORM BUDGET : " + TxtPeriodName.Text.ToUpper)
        Cursor = Cursors.Default
    End Sub

    Private Sub BtnDelete_Click(sender As Object, e As EventArgs) Handles BtnDelete.Click
        Dim id As String = "-1"
        Try
            id = GVDetail.GetFocusedRowCellValue("id_emp_uni_budget").ToString
        Catch ex As Exception
        End Try
        If id <> "-1" Then
            Dim confirm As DialogResult = DevExpress.XtraEditors.XtraMessageBox.Show("Are you sure want to delete this budget for this employee?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
            If confirm = Windows.Forms.DialogResult.Yes Then
                Try
                    Dim query As String = "DELETE FROM tb_emp_uni_budget WHERE id_emp_uni_budget=" + id + " "
                    execute_non_query(query, True, "", "", "", "")
                    viewDetail()
                Catch ex As Exception
                    errorDelete()
                End Try
            End If
        End If
    End Sub

    Private Sub XTCUni_SelectedPageChanged(sender As Object, e As DevExpress.XtraTab.TabPageChangedEventArgs) Handles XTCUni.SelectedPageChanged
        If XTCUni.SelectedTabPageIndex = 0 Then
            BtnSave.Visible = True
        Else
            BtnSave.Visible = False
        End If
    End Sub

    Private Sub SimpleButton6_Click(sender As Object, e As EventArgs) Handles SimpleButton6.Click
        viewDesignList()
    End Sub

    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs) Handles SimpleButton1.Click
        Cursor = Cursors.WaitCursor
        print(GCDesignList, TxtPeriodName.Text + " - " + "DESIGN LIST")
        Cursor = Cursors.Default
    End Sub

    Private Sub BtnPrintOrder_Click(sender As Object, e As EventArgs) Handles BtnPrintOrder.Click
        Cursor = Cursors.WaitCursor
        print(GCSalesOrder, "UNIFORM ORDER - " + TxtPeriodName.Text.ToString)
        Cursor = Cursors.Default
    End Sub

    Private Sub BtnCreateNewOrder_Click(sender As Object, e As EventArgs) Handles BtnCreateNewOrder.Click
        Cursor = Cursors.WaitCursor
        FormEmpUniOrderNew.ShowDialog()
        Cursor = Cursors.Default
    End Sub

    Private Sub GVSalesOrder_DoubleClick(sender As Object, e As EventArgs) Handles GVSalesOrder.DoubleClick
        If GVSalesOrder.RowCount > 0 And GVSalesOrder.FocusedRowHandle >= 0 Then
            Cursor = Cursors.WaitCursor
            FormEmpUniOrderDet.id_sales_order = GVSalesOrder.GetFocusedRowCellValue("id_sales_order").ToString
            FormEmpUniOrderDet.ShowDialog()
            Cursor = Cursors.Default
        End If
    End Sub

    Private Sub BtnImportExcel_Click(sender As Object, e As EventArgs) Handles BtnImportExcel.Click
        Cursor = Cursors.WaitCursor
        FormImportExcel.id_pop_up = "31"
        FormImportExcel.ShowDialog()
        Cursor = Cursors.Default
    End Sub
End Class