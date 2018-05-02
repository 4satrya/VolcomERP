Public Class FormFGTransList
    Public page_active As String = ""

    Private Sub FormFGTransList_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'date now
        Dim data_dt As DataTable = execute_query("SELECT DATE(NOW()) AS `dt`", -1, True, "", "", "", "")
        DEFromRec.EditValue = data_dt.Rows(0)("dt")
        DEUntilRec.EditValue = data_dt.Rows(0)("dt")
        DEFromDO.EditValue = data_dt.Rows(0)("dt")
        DEUntilDO.EditValue = data_dt.Rows(0)("dt")
        DEFromReturn.EditValue = data_dt.Rows(0)("dt")
        DEUntilReturn.EditValue = data_dt.Rows(0)("dt")
        DEFromReturnQC.EditValue = data_dt.Rows(0)("dt")
        DEUntilReturnQC.EditValue = data_dt.Rows(0)("dt")
        DEFromTrf.EditValue = data_dt.Rows(0)("dt")
        DEUntilTrf.EditValue = data_dt.Rows(0)("dt")
        DEFromNonStock.EditValue = data_dt.Rows(0)("dt")
        DEUntilNonStock.EditValue = data_dt.Rows(0)("dt")

        ActiveControl = DEFromRec
        page_active = "rec"
    End Sub

    Sub viewRec()
        Cursor = Cursors.WaitCursor
        'Prepare paramater
        Dim date_from_selected As String = "0000-01-01"
        Dim date_until_selected As String = "9999-01-01"
        Try
            date_from_selected = DateTime.Parse(DEFromRec.EditValue.ToString).ToString("yyyy-MM-dd")
        Catch ex As Exception
        End Try

        Try
            date_until_selected = DateTime.Parse(DEUntilRec.EditValue.ToString).ToString("yyyy-MM-dd")
        Catch ex As Exception
        End Try

        'prepare query
        Dim query_c As ClassProductionPLToWHRec = New ClassProductionPLToWHRec()
        Dim data As DataTable = query_c.transactionList("AND (a0.pl_prod_order_rec_date>='" + date_from_selected + "' AND a0.pl_prod_order_rec_date<='" + date_until_selected + "') ", "1")
        GCPL.DataSource = data
        Cursor = Cursors.Default
    End Sub

    Sub viewDO()
        Cursor = Cursors.WaitCursor
        'Prepare paramater
        Dim date_from_selected As String = "0000-01-01"
        Dim date_until_selected As String = "9999-01-01"
        Try
            date_from_selected = DateTime.Parse(DEFromDO.EditValue.ToString).ToString("yyyy-MM-dd")
        Catch ex As Exception
        End Try

        Try
            date_until_selected = DateTime.Parse(DEUntilDO.EditValue.ToString).ToString("yyyy-MM-dd")
        Catch ex As Exception
        End Try

        'prepare query
        Dim query_c As ClassSalesDelOrder = New ClassSalesDelOrder()
        Dim data As DataTable = query_c.transactionList("AND (a.pl_sales_order_del_date>='" + date_from_selected + "' AND a.pl_sales_order_del_date<='" + date_until_selected + "') ", "1")
        GCSalesDelOrder.DataSource = data
        Cursor = Cursors.Default
    End Sub

    Private Sub BtnViewDO_Click(sender As Object, e As EventArgs) Handles BtnViewDO.Click
        viewDO()
    End Sub

    Sub viewReturn()
        Cursor = Cursors.WaitCursor
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

        'prepare query
        Dim query_c As ClassSalesReturn = New ClassSalesReturn()
        Dim data As DataTable = query_c.transactionList("AND (a.id_ret_type!=2) AND (a.sales_return_date>='" + date_from_selected + "' AND a.sales_return_date<='" + date_until_selected + "') ", "1")
        GCSalesReturn.DataSource = data
        Cursor = Cursors.Default
    End Sub

    Private Sub BtnViewReturn_Click(sender As Object, e As EventArgs) Handles BtnViewReturn.Click
        viewReturn()
    End Sub

    Sub viewNonStock()
        Cursor = Cursors.WaitCursor
        'Prepare paramater
        Dim date_from_selected As String = "0000-01-01"
        Dim date_until_selected As String = "9999-01-01"
        Try
            date_from_selected = DateTime.Parse(DEFromNonStock.EditValue.ToString).ToString("yyyy-MM-dd")
        Catch ex As Exception
        End Try

        Try
            date_until_selected = DateTime.Parse(DEUntilNonStock.EditValue.ToString).ToString("yyyy-MM-dd")
        Catch ex As Exception
        End Try

        'prepare query
        Dim query_c As ClassSalesReturn = New ClassSalesReturn()
        Dim data As DataTable = query_c.transactionListNSI("AND a.id_ret_type=2 AND (a.sales_return_date>='" + date_from_selected + "' AND a.sales_return_date<='" + date_until_selected + "') ", "1")
        GCNonStock.DataSource = data
        Cursor = Cursors.Default
    End Sub

    Private Sub BtnViewNonStock_Click(sender As Object, e As EventArgs) Handles BtnViewNonStock.Click
        viewNonStock()
    End Sub

    Private Sub BtnViewRec_Click(sender As Object, e As EventArgs) Handles BtnViewRec.Click
        viewRec()
    End Sub

    Sub viewTrf()
        Cursor = Cursors.WaitCursor
        'Prepare paramater
        Dim date_from_selected As String = "0000-01-01"
        Dim date_until_selected As String = "9999-01-01"
        Try
            date_from_selected = DateTime.Parse(DEFromTrf.EditValue.ToString).ToString("yyyy-MM-dd")
        Catch ex As Exception
        End Try

        Try
            date_until_selected = DateTime.Parse(DEUntilTrf.EditValue.ToString).ToString("yyyy-MM-dd")
        Catch ex As Exception
        End Try

        'prepare query
        Dim query_c As ClassFGTrf = New ClassFGTrf()
        Dim data As DataTable = query_c.transactionList("AND (trf.fg_trf_date>='" + date_from_selected + "' AND trf.fg_trf_date<='" + date_until_selected + "') ", "1")
        GCFGTrf.DataSource = data
        Cursor = Cursors.Default
    End Sub

    Private Sub BtnViewTrf_Click(sender As Object, e As EventArgs) Handles BtnViewTrf.Click
        viewTrf()
    End Sub

    Sub viewRQC()
        Cursor = Cursors.WaitCursor
        'Prepare paramater
        Dim date_from_selected As String = "0000-01-01"
        Dim date_until_selected As String = "9999-01-01"
        Try
            date_from_selected = DateTime.Parse(DEFromReturnQC.EditValue.ToString).ToString("yyyy-MM-dd")
        Catch ex As Exception
        End Try

        Try
            date_until_selected = DateTime.Parse(DEUntilReturnQC.EditValue.ToString).ToString("yyyy-MM-dd")
        Catch ex As Exception
        End Try

        'prepare query
        Dim query_c As ClassSalesReturnQC = New ClassSalesReturnQC()
        Dim data As DataTable = query_c.transactionList("AND (a.sales_return_qc_date>='" + date_from_selected + "' AND a.sales_return_qc_date<='" + date_until_selected + "') ", "1")
        GCSalesReturnQC.DataSource = data
        Cursor = Cursors.Default
    End Sub

    Private Sub BtnViewReturnQC_Click(sender As Object, e As EventArgs) Handles BtnViewReturnQC.Click
        viewRQC()
    End Sub

    Private Sub FormFGTransList_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub FormFGTransList_Activated(sender As Object, e As EventArgs) Handles MyBase.Activated
        FormMain.show_rb(Name)
        checkFormAccess(Name)
    End Sub

    Private Sub FormFGTransList_Deactivate(sender As Object, e As EventArgs) Handles MyBase.Deactivate
        FormMain.hide_rb()
    End Sub

    Private Sub XTCSvcLevel_SelectedPageChanged(sender As Object, e As DevExpress.XtraTab.TabPageChangedEventArgs) Handles XTCSvcLevel.SelectedPageChanged
        Dim tab_index As Integer = XTCSvcLevel.SelectedTabPageIndex
        If tab_index = 0 Then
            page_active = "rec"
            ActiveControl = DEFromRec
        ElseIf tab_index = 1 Then
            page_active = "del"
            ActiveControl = DEFromDO
        ElseIf tab_index = 2 Then
            page_active = "ret"
            ActiveControl = DEFromReturn
        ElseIf tab_index = 3 Then
            page_active = "nsr"
            ActiveControl = DEFromNonStock
        ElseIf tab_index = 4 Then
            page_active = "ret_trf"
            ActiveControl = DEFromReturnQC
        ElseIf tab_index = 5 Then
            page_active = "trf"
            ActiveControl = DEFromTrf
        End If
    End Sub

    Private Sub DEFromRec_KeyDown(sender As Object, e As KeyEventArgs) Handles DEFromRec.KeyDown
        If e.KeyCode = Keys.Enter Then
            DEUntilRec.Focus()
        End If
    End Sub

    Private Sub DEUntilRec_KeyDown(sender As Object, e As KeyEventArgs) Handles DEUntilRec.KeyDown
        If e.KeyCode = Keys.Enter Then
            BtnViewRec.Focus()
        End If
    End Sub

    Private Sub DEFromDO_KeyDown(sender As Object, e As KeyEventArgs) Handles DEFromDO.KeyDown
        If e.KeyCode = Keys.Enter Then
            DEUntilDO.Focus()
        End If
    End Sub

    Private Sub DEUntilDO_KeyDown(sender As Object, e As KeyEventArgs) Handles DEUntilDO.KeyDown
        If e.KeyCode = Keys.Enter Then
            BtnViewDO.Focus()
        End If
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

    Private Sub DEFromNonStock_KeyDown(sender As Object, e As KeyEventArgs) Handles DEFromNonStock.KeyDown
        If e.KeyCode = Keys.Enter Then
            DEUntilNonStock.Focus()
        End If
    End Sub

    Private Sub DEUntilNonStock_KeyDown(sender As Object, e As KeyEventArgs) Handles DEUntilNonStock.KeyDown
        If e.KeyCode = Keys.Enter Then
            BtnViewNonStock.Focus()
        End If
    End Sub

    Private Sub DEFromReturnQC_KeyDown(sender As Object, e As KeyEventArgs) Handles DEFromReturnQC.KeyDown
        If e.KeyCode = Keys.Enter Then
            DEUntilReturnQC.Focus()
        End If
    End Sub

    Private Sub DEUntilReturnQC_KeyDown(sender As Object, e As KeyEventArgs) Handles DEUntilReturnQC.KeyDown
        If e.KeyCode = Keys.Enter Then
            BtnViewReturnQC.Focus()
        End If
    End Sub

    Private Sub DEFromTrf_KeyDown(sender As Object, e As KeyEventArgs) Handles DEFromTrf.KeyDown
        If e.KeyCode = Keys.Enter Then
            DEUntilTrf.Focus()
        End If
    End Sub

    Private Sub DEUntilTrf_KeyDown(sender As Object, e As KeyEventArgs) Handles DEUntilTrf.KeyDown
        If e.KeyCode = Keys.Enter Then
            BtnViewTrf.Focus()
        End If
    End Sub
End Class