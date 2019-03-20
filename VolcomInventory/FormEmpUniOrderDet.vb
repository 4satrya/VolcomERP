Imports DevExpress.XtraReports.UI

Public Class FormEmpUniOrderDet
    Public id_sales_order As String = "-1"
    Public id_emp_uni_budget As String = "-1"
    Public id_emp_uni_period As String = "-1"
    Dim prepared_by As String = ""
    Dim id_wh_drawer As String = ""
    Public is_public_form As Boolean = False
    Dim id_departement As String = "-1"
    Public is_view As String = "-1"
    Dim id_sex As String = "-1"
    Dim is_filter_uni_sex As String = "-1"
    Dim is_dept_head As String = "-1"

    Private Sub FormEmpUniOrderDet_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        viewReportStatus()
        actionLoad()
    End Sub

    Sub actionLoad()
        Dim query_c As New ClassEmpUni()
        Dim query As String = query_c.queryMainOrder("And so.id_sales_order=" + id_sales_order + " ", "1", id_sales_order)
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        id_emp_uni_budget = data.Rows(0)("id_emp_uni_budget").ToString
        id_emp_uni_period = data.Rows(0)("id_emp_uni_period").ToString
        id_wh_drawer = data.Rows(0)("id_drawer_def").ToString
        id_departement = data.Rows(0)("id_departement").ToString
        id_sex = data.Rows(0)("id_sex").ToString
        is_dept_head = data.Rows(0)("is_dept_head").ToString
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
        TxtDiscount.EditValue = data.Rows(0)("discount")
        TxtTotal.EditValue = data.Rows(0)("amount")
        LEReportStatus.ItemIndex = LEReportStatus.Properties.GetDataSourceRowIndex("id_report_status", data.Rows(0)("id_report_status").ToString)
        TxtDiff.EditValue = TxtBudget.EditValue - TxtTotal.EditValue
        TxtDesign.Focus()

        'filter uniform by sex option
        is_filter_uni_sex = get_setup_field("is_filter_uni_sex")

        If data.Rows(0)("id_report_status").ToString = "5" Or data.Rows(0)("id_report_status").ToString = "6" Or data.Rows(0)("is_selected").ToString = "1" Then
            BtnAccept.Visible = False
            BtnCancelOrder.Visible = False
            PanelControl4.Visible = False
        End If
        viewDetail()

        If is_view = "1" Then
            BtnMark.Visible = True
        End If
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
        Dim query As String = "CALL view_sales_order_uni('" + id_sales_order + "') "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCItemList.DataSource = data
    End Sub
    Private Sub FormEmpUniOrderDet_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub BtnAccept_Click(sender As Object, e As EventArgs)

    End Sub

    Sub acceptOrder()
        Dim confirm As DialogResult = DevExpress.XtraEditors.XtraMessageBox.Show("Are you sure want to accept this order?", "Accept Order", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
        If confirm = Windows.Forms.DialogResult.Yes Then
            Cursor = Cursors.WaitCursor
            'submit
            submit_who_prepared("39", id_sales_order, id_user)

            'update completed
            Dim query As String = "UPDATE tb_sales_order set id_report_status=6, is_selected=1, sales_order_note='" + addSlashes(MENote.Text.ToString) + "' WHERE id_sales_order=" + id_sales_order + " "
            execute_non_query(query, True, "", "", "", "")
            If Not is_public_form Then
                FormEmpUniPeriodDet.viewOrder()
            End If
            actionLoad()

            'print direct
            'printOrder(False)
            Cursor = Cursors.Default
        End If
    End Sub

    Private Sub ReportOnStartPrint(ByVal sender As Object, ByVal e As DevExpress.XtraPrinting.PrintDocumentEventArgs)
        e.PrintDocument.PrinterSettings.Copies = Integer.Parse(get_setup_field("copy_of_uni"))
    End Sub

    Private Sub BtnCancelOrder_Click(sender As Object, e As EventArgs) Handles BtnCancelOrder.Click
        Dim confirm As DialogResult = DevExpress.XtraEditors.XtraMessageBox.Show("Are you sure want To cancell this order?", "Cancell Order", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
        If confirm = Windows.Forms.DialogResult.Yes Then
            Dim so As New ClassSalesOrder()
            so.cancelReservedStock(id_sales_order)

            Dim query As String = "UPDATE tb_sales_order Set id_report_status=5,sales_order_note='" + addSlashes(MENote.Text.ToString) + "' WHERE id_sales_order=" + id_sales_order + " "
            execute_non_query(query, True, "", "", "", "")
            If Not is_public_form Then
                FormEmpUniPeriodDet.viewOrder()
            End If
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
        Cursor = Cursors.WaitCursor
        makeSafeGV(GVItemList)
        FormEmpUniOrderDelete.ShowDialog()
        If GVItemList.ActiveFilterString <> "" Then
            If GVItemList.RowCount <= 0 Then
                stopCustom("Data tidak ditemukan")
            Else
                deleteData()
            End If
            makeSafeGV(GVItemList)
        End If
        Cursor = Cursors.Default
    End Sub

    Sub deleteData()
        If GVItemList.RowCount > 0 And GVItemList.FocusedRowHandle >= 0 Then
            Dim confirm As DialogResult = DevExpress.XtraEditors.XtraMessageBox.Show("Are you sure want To delete this detail order?", "Delete Detail Order", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
            If confirm = Windows.Forms.DialogResult.Yes Then
                Dim query As String = "DELETE FROM tb_sales_order_det WHERE id_sales_order_det=" + GVItemList.GetFocusedRowCellValue("id_sales_order_det").ToString + " "
                execute_non_query(query, True, "", "", "", "")
                actionLoad()
            End If
        End If
    End Sub

    Sub focusRow()
        GVItemList.Focus()
    End Sub


    Private Sub FormEmpUniOrderDet_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.F2 Then
            'TAMBAH
            addRow()
        ElseIf e.KeyCode = Keys.F3 Then
            'DELETE
            deleteRow()
        ElseIf e.KeyCode = Keys.F4 Then
            'view STOCK
            viewStock()
        ElseIf e.KeyCode = Keys.F5 Then
            'ACCEPT ORDER
            acceptOrder()
        ElseIf e.KeyCode = Keys.F6 Then
            'PRINT
            printOrder(True)
        ElseIf (e.KeyCode = Keys.R AndAlso e.Modifiers = Keys.Control) Then
            focusRow()
        End If
    End Sub

    Private Sub BtnAddOrder_Click(sender As Object, e As EventArgs)
        addRow()
    End Sub

    Private Sub BtnDelOrder_Click(sender As Object, e As EventArgs) Handles BtnDelOrder.Click
        deleteRow()
    End Sub

    Private Sub BtnFocusRow_Click(sender As Object, e As EventArgs) Handles BtnFocusRow.Click
        focusRow()
    End Sub

    Public Sub selectUniform(ByVal key As String)
        Dim cond_sex As String = ""
        If is_filter_uni_sex = "1" And id_sex = "1" Then
            cond_sex = "AND dd.division='M' "
        End If

        Dim cond_dept_head As String = ""
        If is_dept_head = "2" Then
            cond_dept_head = "AND dd.is_dept_head=2 "
        End If

        Dim dt As DataTable = checkStock("AND dm.id_emp_uni_period=" + id_emp_uni_period + " AND dd.no='" + key.ToString + "' " + cond_sex + cond_dept_head)
        If dt.Rows.Count <= 0 Then
            stopCustom("Product tidak ditemukan")
            TxtDesign.Text = ""
            TxtDesign.Focus()
        Else
            'jika sudah ada di list
            If checkExist(dt.Rows(0)("id_design").ToString) Then
                stopCustom("Product sudah dipilih")
                TxtDesign.Text = ""
                TxtDesign.Focus()
            Else
                FormEmpUniOrderSingle.dt = dt
                FormEmpUniOrderSingle.ShowDialog()
                TxtDesign.Text = ""
                TxtDesign.Focus()
            End If
        End If
    End Sub
    Private Sub TxtDesign_KeyDown(sender As Object, e As KeyEventArgs) Handles TxtDesign.KeyDown
        If e.KeyCode = Keys.Enter Then
            Cursor = Cursors.WaitCursor
            If is_public_form Then
                Dim valid As String = execute_query("SELECT is_selection_time(" + id_emp_uni_period + ", " + id_departement + ")", 0, True, "", "", "", "")
                If valid = "2" Then
                    stopCustom("Maaf, saat ini belum waktunya memilih uniform")
                    TxtDesign.Text = ""
                    TxtDesign.Focus()
                    Exit Sub
                End If
            End If
            Dim key As String = addSlashes(TxtDesign.Text)
            selectUniform(key)
            Cursor = Cursors.Default
        End If
    End Sub

    Public Function checkStock(ByVal cond As String) As DataTable
        Dim query As String = "SELECT dd.`no`, dd.id_design, prod.id_product, dsg.design_code AS `code`, prod.product_full_code AS `barcode`, dsg.design_display_name AS `name`, cd.code_detail_name AS `size`, IFNULL(dsg.design_cop,0) AS `design_cop`,
            IFNULL(s.qty_avl,0) AS qty_avl,
            IFNULL(s.qty_rsv,0) AS qty_rsv,
            IFNULL(s.qty_tot,0) AS qty_tot,
            prc.id_design_price, prc.design_price, IFNULL(dd.point,0) AS `point`
            FROM tb_emp_uni_design_det dd
            INNER JOIN tb_emp_uni_design dm ON dm.id_emp_uni_design = dd.id_emp_uni_design
            INNER JOIN tb_m_design dsg ON dsg.id_design = dd.id_design
            INNER JOIN tb_m_product prod ON prod.id_design = dsg.id_design
            INNER JOIN tb_m_product_code prodc ON prodc.id_product = prod.id_product
            INNER JOIN tb_m_code_detail cd ON cd.id_code_detail = prodc.id_code_detail
            LEFT JOIN (
	            SELECT j.id_product,
	            SUM(IF(j.id_storage_category=2, CONCAT('-', j.storage_product_qty), j.storage_product_qty)) AS qty_avl, 	
	            SUM(IF(j.id_stock_status=1, (IF(j.id_storage_category='2', CONCAT('-', j.storage_product_qty), j.storage_product_qty)),0)) AS qty_tot,			
	            SUM(IF(j.id_stock_status=2, (IF(j.id_storage_category='1', CONCAT('-', j.storage_product_qty), j.storage_product_qty)),0)) AS qty_rsv
	            FROM tb_storage_fg j
	            WHERE j.id_wh_drawer=" + id_wh_drawer + "
	            GROUP BY j.id_product
            ) s ON s.id_product = prod.id_product
            LEFT JOIN( 
                 Select * FROM ( 
                 Select price.id_design, price.design_price, price.design_price_date, price.id_design_price, 
	              price.id_design_price_type, price_type.design_price_type,
	              cat.id_design_cat, cat.design_cat
                 From tb_m_design_price price 
                 INNER Join tb_lookup_design_price_type price_type On price.id_design_price_type = price_type.id_design_price_type 
                 INNER JOIN tb_lookup_design_cat cat ON cat.id_design_cat = price_type.id_design_cat
                 WHERE price.is_active_wh =1 AND price.design_price_start_date <= NOW() 
                 ORDER BY price.design_price_start_date DESC, price.id_design_price DESC ) a 
                 GROUP BY a.id_design 
            ) prc ON prc.id_design = dsg.id_design 
            WHERE dm.id_report_status=6 
            " + cond + "
            ORDER BY dd.`no` ASC, cd.id_code_detail ASC "
        Dim dt As DataTable = execute_query(query, -1, True, "", "", "", "")
        Return dt
    End Function

    Public Function checkExist(ByVal id_design_par As String) As Boolean
        Dim check_existing As Boolean = False
        Dim query_sod As String = "SELECT * FROM tb_sales_order_det sod 
            INNER JOIN tb_sales_order so ON so.id_sales_order = sod.id_sales_order
            INNER JOIN tb_m_product p ON p.id_product = sod.id_product 
            WHERE so.id_emp_uni_budget =" + id_emp_uni_budget + " AND so.id_emp_uni_period=" + id_emp_uni_period + " AND p.id_design=" + id_design_par + " AND so.id_report_status!=5 "
        Dim data_sod As DataTable = execute_query(query_sod, -1, True, "", "", "", "")
        If data_sod.Rows.Count > 0 Then
            check_existing = True
        End If
        Return check_existing
    End Function

    Private Sub GVItemList_CustomColumnDisplayText(sender As Object, e As DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs) Handles GVItemList.CustomColumnDisplayText
        If e.Column.FieldName = "nomer" Then
            e.DisplayText = (e.ListSourceRowIndex + 1).ToString()
        End If
    End Sub

    Private Sub SimpleButton3_Click(sender As Object, e As EventArgs) Handles SimpleButton3.Click
        printOrder(True)
    End Sub

    Sub printOrder(ByVal is_preview As Boolean)
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
        'Report.LabelTitle.Text = "UNIFORM ORDER"
        Report.LabelPeriod.Text = TxtPeriodName.Text.ToUpper
        Report.LabelNumber.Text = TxtOrderNumber.Text.ToUpper
        Report.LabelNIK.Text = TxtNIK.Text.ToUpper
        Report.LabelName.Text = TxtName.Text.ToUpper
        Report.LabelDept.Text = TxtDept.Text.ToUpper
        Report.LabelLevel.Text = TxtLevel.Text.ToUpper
        Report.LabelBudget.Text = TxtBudget.Text.ToUpper + "%"
        Report.LabelTotal.Text = TxtTotal.Text.ToUpper + "%"
        Report.LabelDiff.Text = TxtDiff.Text + "%"
        Report.LabelHRD.Text = prepared_by.ToUpper
        Report.LabelTTDName.Text = TxtName.Text.ToUpper
        Report.LabelDate.Text = DECreated.Text.ToString

        If is_preview Then
            'Show the report's preview. 
            Dim Tool As DevExpress.XtraReports.UI.ReportPrintTool = New DevExpress.XtraReports.UI.ReportPrintTool(Report)
            Tool.ShowPreviewDialog()
        Else
            Dim instance As New Printing.PrinterSettings
            Dim DefaultPrinter As String = instance.PrinterName

            ' THIS IS TO PRINT THE REPORT
            Report.PrinterName = DefaultPrinter
            Report.CreateDocument()
            Report.PrintingSystem.ShowMarginsWarning = False
            AddHandler Report.PrintingSystem.StartPrint, AddressOf ReportOnStartPrint
            Report.Print()
        End If
        Cursor = Cursors.Default
    End Sub

    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs)
        Cursor = Cursors.WaitCursor
        FormEmpUniSuggest.id_emp_uni_period = id_emp_uni_period
        FormEmpUniSuggest.ShowDialog()
        Cursor = Cursors.Default
    End Sub

    Private Sub BtnStock_Click(sender As Object, e As EventArgs) Handles BtnStock.Click
        viewStock()
    End Sub

    Sub viewStock()
        Cursor = Cursors.WaitCursor
        FormEmpUniSuggest.id_emp_uni_period = id_emp_uni_period
        FormEmpUniSuggest.id_sex = id_sex
        FormEmpUniSuggest.is_dept_head = is_dept_head
        FormEmpUniSuggest.ShowDialog()
        Cursor = Cursors.Default
    End Sub

    Private Sub AddToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AddToolStripMenuItem.Click
        addRow()
    End Sub

    Private Sub DeleteToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DeleteToolStripMenuItem.Click
        deleteData()
    End Sub

    Private Sub StockToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles StockToolStripMenuItem.Click
        viewStock()
    End Sub

    Private Sub BtnMark_Click(sender As Object, e As EventArgs) Handles BtnMark.Click
        Cursor = Cursors.WaitCursor
        FormReportMark.report_mark_type = "130"
        FormReportMark.is_view = "1"
        FormReportMark.id_report = id_sales_order
        FormReportMark.ShowDialog()
        Cursor = Cursors.Default
    End Sub

    Private Sub SimpleButton1_Click_1(sender As Object, e As EventArgs) Handles SimpleButton1.Click
        addRow()
    End Sub

    Private Sub BtnAccept2_Click(sender As Object, e As EventArgs) Handles BtnAccept.Click
        acceptOrder()
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