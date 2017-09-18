Public Class FormEmpUniOrderDet
    Public id_sales_order As String = "-1"
    Dim id_wh As String = "-1"
    Dim id_locator As String = "-1"
    Dim id_rack As String = "-1"
    Public id_drawer As String = "-1"
    Public id_emp_uni_budget As String = "-1"
    Dim prepared_by As String = ""

    Private Sub FormEmpUniOrderDet_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        viewReportStatus()
        actionLoad()
    End Sub

    Sub actionLoad()
        Dim query_c As New ClassEmpUni()
        Dim query As String = query_c.queryMainOrder("And so.id_sales_order=" + id_sales_order + " ", "1", id_sales_order)
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        id_emp_uni_budget = data.Rows(0)("id_emp_uni_budget").ToString
        TxtNIK.Text = data.Rows(0)("employee_code").ToString
        TxtName.Text = data.Rows(0)("employee_name").ToString
        TxtDept.Text = data.Rows(0)("departement").ToString
        TxtLevel.Text = data.Rows(0)("employee_level").ToString
        TxtOrderNumber.Text = data.Rows(0)("sales_order_number").ToString
        TxtPeriodName.Text = data.Rows(0)("period_name").ToString
        MENote.Text = data.Rows(0)("sales_order_note").ToString
        prepared_by = data.Rows(0)("prepared_by").ToString
        DECreated.EditValue = data.Rows(0)("sales_order_date")
        TxtBudget.EditValue = data.Rows(0)("budget")
        TxtTolerance.EditValue = data.Rows(0)("tolerance")
        TxtOrderMax.EditValue = data.Rows(0)("order_max")
        TxtDiscount.EditValue = data.Rows(0)("discount")
        TxtGross.EditValue = data.Rows(0)("amount")
        LEReportStatus.ItemIndex = LEReportStatus.Properties.GetDataSourceRowIndex("id_report_status", data.Rows(0)("id_report_status").ToString)
        getTotal()
        TxtDiff.EditValue = TxtOrderMax.EditValue - TxtTotal.EditValue
        TxtDesign.Focus()

        'get drawer
        id_wh = get_setup_field("wh_uni")
        Dim query_wh As String = "SELECT l.id_wh_locator, r.id_wh_rack, d.id_wh_drawer 
        FROM tb_m_wh_locator l 
        INNER JOIN tb_m_wh_rack r ON r.id_wh_locator = l.id_wh_locator
        INNER JOIN tb_m_wh_drawer d ON d.id_wh_rack = r.id_wh_rack
        WHERE l.id_comp=" + id_wh + " "
        Dim dt_wh As DataTable = execute_query(query_wh, -1, True, "", "", "", "")
        id_locator = dt_wh(0)("id_wh_locator").ToString
        id_rack = dt_wh(0)("id_wh_rack").ToString
        id_drawer = dt_wh(0)("id_wh_drawer").ToString

        If data.Rows(0)("id_report_status").ToString = 5 Or data.Rows(0)("id_report_status").ToString = 6 Then
            BtnAccept.Visible = False
            BtnCancelOrder.Visible = False
            PanelControl4.Visible = False
        End If
        viewDetail()
    End Sub

    Sub getTotal()
        Dim gross As Decimal = 0
        Try
            gross = TxtGross.EditValue
        Catch ex As Exception
        End Try
        Dim disc As Decimal = 0
        Try
            disc = TxtDiscount.EditValue
        Catch ex As Exception
        End Try
        Dim discount_val As Decimal = (disc / 100) * gross
        TxtDiscountValue.EditValue = discount_val
        TxtTotal.EditValue = gross - discount_val
    End Sub


    Sub viewReportStatus()
        Dim query As String = "Select * FROM tb_lookup_report_status a ORDER BY a.id_report_status "
        viewLookupQuery(LEReportStatus, query, 0, "report_status", "id_report_status")
    End Sub

    Sub viewDetail()
        Dim query As String = "CALL view_sales_order('" + id_sales_order + "') "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCItemList.DataSource = data
    End Sub
    Private Sub FormEmpUniOrderDet_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub BtnAccept_Click(sender As Object, e As EventArgs) Handles BtnAccept.Click
        Dim confirm As DialogResult = DevExpress.XtraEditors.XtraMessageBox.Show("Are you sure want to accept this order?", "Accept Order", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
        If confirm = Windows.Forms.DialogResult.Yes Then
            Dim query As String = "UPDATE tb_sales_order Set id_report_status=6, sales_order_note='" + addSlashes(MENote.Text.ToString) + "' WHERE id_sales_order=" + id_sales_order + " "
            execute_non_query(query, True, "", "", "", "")
            FormEmpUniPeriodDet.viewOrder()
            actionLoad()
        End If
    End Sub

    Private Sub BtnCancelOrder_Click(sender As Object, e As EventArgs) Handles BtnCancelOrder.Click
        Dim confirm As DialogResult = DevExpress.XtraEditors.XtraMessageBox.Show("Are you sure want To cancell this order?", "Cancell Order", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
        If confirm = Windows.Forms.DialogResult.Yes Then
            Dim so As New ClassSalesOrder()
            so.cancelReservedStock(id_sales_order)

            Dim query As String = "UPDATE tb_sales_order Set id_report_status=5,sales_order_note='" + addSlashes(MENote.Text.ToString) + "' WHERE id_sales_order=" + id_sales_order + " "
            execute_non_query(query, True, "", "", "", "")
            FormEmpUniPeriodDet.viewOrder()
            actionLoad()
        End If
    End Sub

    Private Sub LabelControl6_Click(sender As Object, e As EventArgs)

    End Sub

    Sub addRow()
        Cursor = Cursors.WaitCursor
        TxtDesign.Text = ""
        TxtDesign.Focus()
        Cursor = Cursors.Default
    End Sub

    Sub deleteRow()
        Dim confirm As DialogResult = DevExpress.XtraEditors.XtraMessageBox.Show("Are you sure want To delete this detail order?", "Delete Detail Order", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
        If confirm = Windows.Forms.DialogResult.Yes Then
            Dim query As String = "DELETE FROM tb_sales_order_det WHERE id_sales_order_det=" + GVItemList.GetFocusedRowCellValue("id_sales_order_det").ToString + " "
            execute_non_query(query, True, "", "", "", "")
            actionLoad()
        End If
    End Sub

    Sub focusRow()
        GVItemList.Focus()
    End Sub

    Private Sub FormEmpUniOrderDet_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.Insert Then
            addRow()
        ElseIf e.KeyCode = Keys.Delete Then
            deleteRow()
        ElseIf (e.KeyCode = Keys.R AndAlso e.Modifiers = Keys.Control) Then
            focusRow()
        End If
    End Sub

    Private Sub BtnAddOrder_Click(sender As Object, e As EventArgs) Handles BtnAddOrder.Click
        addRow()
    End Sub

    Private Sub BtnDelOrder_Click(sender As Object, e As EventArgs) Handles BtnDelOrder.Click
        deleteRow()
    End Sub

    Private Sub BtnFocusRow_Click(sender As Object, e As EventArgs) Handles BtnFocusRow.Click
        focusRow()
    End Sub

    Private Sub TxtDesign_KeyDown(sender As Object, e As KeyEventArgs) Handles TxtDesign.KeyDown
        If e.KeyCode = Keys.Enter Then
            Cursor = Cursors.WaitCursor
            Dim key As String = addSlashes(TxtDesign.Text)
            Dim condition As String = "AND so.id_emp_uni_period=" + FormEmpUniPeriodDet.id_emp_uni_period + " AND (prod.design_code LIKE '%" + key + "%' OR prod.product_full_code LIKE '%" + key + "%' OR prod.design_display_name LIKE '%" + key + "%') "
            Dim dt As DataTable = execute_query("CALL view_emp_uni_stock(""" + condition + """,1) ", -1, True, "", "", "", "")
            If dt.Rows.Count <= 0 Then
                stopCustom("Product not found")
                TxtDesign.Text = ""
                TxtDesign.Focus()
            Else
                FormEmpUniOrderSingle.dt = dt
                FormEmpUniOrderSingle.ShowDialog()
                TxtDesign.Text = ""
                TxtDesign.Focus()
            End If
            Cursor = Cursors.Default
        End If
    End Sub

    Private Sub GVItemList_CustomColumnDisplayText(sender As Object, e As DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs) Handles GVItemList.CustomColumnDisplayText
        If e.Column.FieldName = "no" Then
            e.DisplayText = (e.ListSourceRowIndex + 1).ToString()
        End If
    End Sub

    Private Sub SimpleButton3_Click(sender As Object, e As EventArgs) Handles SimpleButton3.Click
        Cursor = Cursors.WaitCursor
        ReportEmpUniOrder.dt = GCItemList.DataSource
        Dim Report As New ReportEmpUniOrder()

        ' '... 
        ' ' creating and saving the view's layout to a new memory stream 
        Dim str As System.IO.Stream
        str = New System.IO.MemoryStream()
        GVItemList.SaveLayoutToStream(str, DevExpress.Utils.OptionsLayoutBase.FullLayout)
        str.Seek(0, System.IO.SeekOrigin.Begin)
        Report.GVItemList.RestoreLayoutFromStream(str, DevExpress.Utils.OptionsLayoutBase.FullLayout)
        str.Seek(0, System.IO.SeekOrigin.Begin)

        'Grid Detail
        ReportStyleGridview(Report.GVItemList)

        'Parse val
        Report.LabelTitle.Text = "UNIFORM ORDER - " + TxtPeriodName.Text.ToUpper
        Report.LabelNumber.Text = TxtOrderNumber.Text.ToUpper
        Report.LabelNIK.Text = TxtNIK.Text.ToUpper
        Report.LabelName.Text = TxtName.Text.ToUpper
        Report.LabelDept.Text = TxtDept.Text.ToUpper
        Report.LabelLevel.Text = TxtLevel.Text.ToUpper
        Report.LabelBudget.Text = TxtBudget.Text.ToUpper
        Report.LabelTolerance.Text = TxtTolerance.Text.ToUpper
        Report.LabelGrossTotal.Text = TxtGross.Text.ToUpper
        Report.LabelDiscount.Text = TxtDiscountValue.Text.ToUpper
        Report.LabelTotal.Text = TxtTotal.Text.ToUpper
        Report.LabelPrepared.Text = "PREPARED BY " + prepared_by.ToUpper + " (" + DECreated.Text + ")"

        'Show the report's preview. 
        Dim Tool As DevExpress.XtraReports.UI.ReportPrintTool = New DevExpress.XtraReports.UI.ReportPrintTool(Report)
        Tool.ShowPreviewDialog()
        Cursor = Cursors.Default
    End Sub

    'Private Sub TxtCode_KeyDown(sender As Object, e As KeyEventArgs)
    '    If e.KeyCode = Keys.Enter Then
    '        Dim val As String = addSlashes(TxtCode.Text)
    '        If val.Length > 9 Then
    '            val = val.Substring(0, 9)
    '        End If

    '    End If
    'End Sub
End Class