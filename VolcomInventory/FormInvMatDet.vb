Imports DevExpress.XtraReports.UI

Public Class FormInvMatDet
    Public id_inv As String = "-1"
    Public id_status As String = "1"

    Public is_deposit As String = "-1"
    Public is_view As String = "-1"
    '
    Sub load_form()
        load_vendor()
        load_type()

        DEDueDate.EditValue = Now
        DERefDate.EditValue = Now
        DEDateCreated.EditValue = Now

        If id_inv = "-1" Then 'new
            BtnPrint.Visible = False
            PanelControlPreview.Visible = False
            BtnViewJournal.Visible = False
            BMark.Visible = False
            DEDueDate.Properties.ReadOnly = False
            DERefDate.Properties.ReadOnly = False
            '
            load_det()
            'vendor 
            SLEVendor.EditValue = FormInvMat.SLEVendorPayment.EditValue

            If FormInvMat.XTCMatInv.SelectedTabPageIndex = 1 Then
                'invoice pl
                SLEPayType.EditValue = "1"
                'detail
                Try
                    For i = 0 To FormInvMat.GVPL.RowCount - 1
                        If is_deposit = "1" Then
                            Dim query As String = "SELECT md.`mat_det_code`,md.`mat_det_name`,pld.`pl_mrs_det_qty` AS qty,pld.`pl_mrs_det_price` AS price,(pld.`pl_mrs_det_qty`*pld.`pl_mrs_det_price`) AS amount
FROM tb_pl_mrs_det pld
INNER JOIN tb_m_mat_det_price prc ON prc.`id_mat_det_price`=pld.`id_mat_det_price`
INNER JOIN tb_m_mat_det md ON md.`id_mat_det`=prc.`id_mat_det`
WHERE pld.`id_pl_mrs`='" & FormInvMat.GVPL.GetRowCellValue(i, "id_pl_mrs").ToString & "'"
                            Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
                            For j As Integer = 0 To data.Rows.Count - 1
                                Dim newRow As DataRow = (TryCast(GCList.DataSource, DataTable)).NewRow()
                                newRow("id_prod_order") = "0"
                                newRow("prod_order_number") = "-"
                                newRow("id_report") = FormInvMat.GVPL.GetRowCellValue(i, "id_pl_mrs").ToString
                                newRow("report_mark_type") = "30"
                                newRow("report_number") = FormInvMat.GVPL.GetRowCellValue(i, "pl_mrs_number").ToString
                                newRow("info_design") = data.Rows(j)("mat_det_code").ToString & " - " & data.Rows(j)("mat_det_name").ToString
                                newRow("qty") = data.Rows(j)("qty")
                                newRow("price") = data.Rows(j)("price")
                                newRow("value") = data.Rows(j)("price") * data.Rows(j)("qty")
                                newRow("note") = ""
                                TryCast(GCList.DataSource, DataTable).Rows.Add(newRow)
                            Next
                        Else
                            Dim newRow As DataRow = (TryCast(GCList.DataSource, DataTable)).NewRow()
                            newRow("id_prod_order") = FormInvMat.GVPL.GetRowCellValue(i, "id_prod_order").ToString
                            newRow("prod_order_number") = FormInvMat.GVPL.GetRowCellValue(i, "prod_order_number").ToString
                            newRow("id_report") = FormInvMat.GVPL.GetRowCellValue(i, "id_pl_mrs").ToString
                            newRow("report_mark_type") = "30"
                            newRow("report_number") = FormInvMat.GVPL.GetRowCellValue(i, "pl_mrs_number").ToString
                            newRow("info_design") = FormInvMat.GVPL.GetRowCellValue(i, "design_display_name").ToString
                            newRow("value") = FormInvMat.GVPL.GetRowCellValue(i, "amount")
                            newRow("note") = ""
                            TryCast(GCList.DataSource, DataTable).Rows.Add(newRow)
                        End If
                    Next
                    calculate()
                Catch ex As Exception
                    MsgBox(ex.ToString)
                End Try
            ElseIf FormInvMat.XTCMatInv.SelectedTabPageIndex = 2 Then
                'invoice retur
                SLEPayType.EditValue = "2"
                'detail
                Try
                    For i = 0 To FormInvMat.GVRetur.RowCount - 1
                        If is_deposit = "1" Then

                        Else
                            Dim newRow As DataRow = (TryCast(GCList.DataSource, DataTable)).NewRow()
                            newRow("id_prod_order") = FormInvMat.GVRetur.GetRowCellValue(i, "id_prod_order").ToString
                            newRow("prod_order_number") = FormInvMat.GVRetur.GetRowCellValue(i, "prod_order_number").ToString
                            newRow("id_report") = FormInvMat.GVRetur.GetRowCellValue(i, "id_mat_prod_ret_in").ToString
                            newRow("report_mark_type") = "32"
                            newRow("report_number") = FormInvMat.GVRetur.GetRowCellValue(i, "mat_prod_ret_in_number").ToString
                            newRow("info_design") = FormInvMat.GVRetur.GetRowCellValue(i, "design_display_name").ToString
                            newRow("value") = FormInvMat.GVRetur.GetRowCellValue(i, "amount")
                            newRow("note") = ""
                            TryCast(GCList.DataSource, DataTable).Rows.Add(newRow)
                        End If
                    Next
                    calculate()
                Catch ex As Exception
                    MsgBox(ex.ToString)
                End Try
            End If
        Else 'edit
            BtnPrint.Visible = True
            PanelControlPreview.Visible = True
            BMark.Visible = True
            DEDueDate.Properties.ReadOnly = True
            DERefDate.Properties.ReadOnly = True
            TEVatPercent.Enabled = False
            'load header
            Dim q_head As String = "SELECT inv.`number`,inv.`id_comp`,inv.is_deposit,c.`comp_name`,inv.`vat_percent`,inv.`id_inv_mat_type`,typ.`inv_mat_type`,inv.created_date,inv.ref_date,inv.due_date,inv.note,inv.id_report_status
FROM tb_inv_mat inv
INNER JOIN tb_m_comp c ON c.`id_comp`=inv.`id_comp`
INNER JOIN `tb_inv_mat_type` typ ON typ.`id_inv_mat_type`=inv.`id_inv_mat_type`
WHERE inv.id_inv_mat='" & id_inv & "'"
            Dim dt_head As DataTable = execute_query(q_head, -1, True, "", "", "", "")
            If dt_head.Rows.Count > 0 Then
                TENumber.Text = dt_head.Rows(0)("number").ToString
                SLEPayType.EditValue = dt_head.Rows(0)("id_inv_mat_type").ToString
                SLEVendor.EditValue = dt_head.Rows(0)("id_comp").ToString
                '
                DEDateCreated.EditValue = dt_head.Rows(0)("created_date")
                DEDueDate.EditValue = dt_head.Rows(0)("due_date")
                DERefDate.EditValue = dt_head.Rows(0)("ref_date")
                TEVatPercent.EditValue = dt_head.Rows(0)("vat_percent")
                MENote.Text = dt_head.Rows(0)("note").ToString
                '
                id_status = dt_head.Rows(0)("id_report_status").ToString
                is_deposit = dt_head.Rows(0)("is_deposit").ToString
            End If
            '
            load_det()
            calculate()
            '
            If id_status = "6" Then
                BtnViewJournal.Visible = True
            Else
                BtnViewJournal.Visible = False
            End If
        End If

        If is_deposit = "1" Then
            GridColumnFGPO.Visible = False
            GridColumnPayment.Visible = False
            '
            GridColumnQty.Visible = True
            GridColumnPrice.Visible = True
            GridColumnAmount.Visible = True
        Else
            GridColumnFGPO.Visible = True
            GridColumnPayment.Visible = True
            '
            GridColumnQty.Visible = False
            GridColumnPrice.Visible = False
            GridColumnAmount.Visible = False
        End If
    End Sub

    Private Sub FormInvMatDet_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        load_form()
    End Sub

    Sub load_type()
        Dim query As String = "SELECT id_inv_mat_type,inv_mat_type FROM `tb_inv_mat_type`"
        viewSearchLookupQuery(SLEPayType, query, "id_inv_mat_type", "inv_mat_type", "id_inv_mat_type")
    End Sub

    Sub load_vendor()
        Dim query As String = "SELECT c.`id_comp`,c.`comp_number`,c.`comp_name`,c.`id_acc_ar` FROM tb_pl_mrs pl
INNER JOIN tb_m_comp_contact cc ON cc.`id_comp_contact`=pl.`id_comp_contact_to` AND pl.`id_pl_mat_type`='2'
INNER JOIN tb_m_comp c ON c.`id_comp`=cc.`id_comp` 
GROUP BY c.`id_comp`"
        viewSearchLookupQuery(SLEVendor, query, "id_comp", "comp_name", "id_comp")
    End Sub

    Sub calculate()
        Dim tot As Decimal = 0.0
        Dim vat_p As Decimal = 0.0
        Dim tot_vat As Decimal = 0.0
        Dim grand_tot As Decimal = 0.0

        Try
            tot = GVList.Columns("value").SummaryItem.SummaryValue
            vat_p = TEVatPercent.EditValue
            tot_vat = tot * (vat_p / 100)
            '
            TETotal.EditValue = tot
            TEVat.EditValue = tot_vat
            grand_tot = tot + tot_vat
            TEGrandTotal.EditValue = grand_tot
        Catch ex As Exception

        End Try
    End Sub

    Sub load_det()
        Dim query As String = ""

        If is_deposit = "1" Then
            query = "SELECT 0 AS `id_prod_order`,'-' AS `prod_order_number`,invd.`info_design`,invd.`id_report`,invd.`report_mark_type`,invd.`report_number`,invd.`value`,invd.price,invd.qty,invd.note
FROM `tb_inv_mat_det` invd
WHERE invd.`id_inv_mat`='" & id_inv & "'"
        Else
            query = "SELECT po.`id_prod_order`,po.`prod_order_number`,invd.`info_design`,invd.`id_report`,invd.`report_mark_type`,invd.`report_number`,invd.`value`,invd.note
FROM `tb_inv_mat_det` invd
INNER JOIN tb_prod_order po ON po.`id_prod_order`=invd.`id_prod_order`
WHERE invd.`id_inv_mat`='" & id_inv & "'"
        End If

        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        '
        GCList.DataSource = data
    End Sub

    Private Sub FormInvMatDet_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub TEVatPercent_EditValueChanged(sender As Object, e As EventArgs) Handles TEVatPercent.EditValueChanged
        calculate()
    End Sub

    Private Sub BtnCancel_Click(sender As Object, e As EventArgs) Handles BtnCancel.Click
        Close()
    End Sub

    Private Sub BtnSave_Click(sender As Object, e As EventArgs) Handles BtnSave.Click
        If SLEPayType.EditValue.ToString = "1" Then 'PL
            If id_inv = "-1" Then
                'new
                'header
                Dim query As String = "INSERT INTO `tb_inv_mat`(`id_inv_mat_type`,`id_comp`,`created_by`,`created_date`,`note`,`id_report_status`,`due_date`,`ref_date`,`vat_percent`,is_deposit)
VALUES ('" & SLEPayType.EditValue.ToString & "','" & SLEVendor.EditValue.ToString & "','" & id_user & "',NOW(),'" & addSlashes(MENote.Text) & "','1','" & Date.Parse(DEDueDate.EditValue.ToString).ToString("yyyy-MM-dd") & "','" & Date.Parse(DERefDate.EditValue.ToString).ToString("yyyy-MM-dd") & "','" & decimalSQL(TEVatPercent.EditValue.ToString) & "','" & If(is_deposit = "1", "1", "2") & "'); SELECT LAST_INSERT_ID(); "
                id_inv = execute_query(query, 0, True, "", "", "", "")
                'id_inv
                query = ""
                For i = 0 To GVList.RowCount - 1
                    If is_deposit = "1" Then
                        query += "INSERT INTO `tb_inv_mat_det`(`id_inv_mat`,id_prod_order,`id_report`,`report_mark_type`,report_number,info_design,`qty`,`price`,`value`,`note`)
VALUES('" & id_inv & "','" & GVList.GetRowCellValue(i, "id_prod_order").ToString & "','" & GVList.GetRowCellValue(i, "id_report").ToString & "','" & GVList.GetRowCellValue(i, "report_mark_type").ToString & "','" & GVList.GetRowCellValue(i, "report_number").ToString & "','" & GVList.GetRowCellValue(i, "info_design").ToString & "','" & decimalSQL(GVList.GetRowCellValue(i, "qty").ToString) & "','" & decimalSQL(GVList.GetRowCellValue(i, "price").ToString) & "','" & decimalSQL(GVList.GetRowCellValue(i, "value").ToString) & "','" & addSlashes(GVList.GetRowCellValue(i, "note").ToString) & "');"
                    Else
                        query += "INSERT INTO `tb_inv_mat_det`(`id_inv_mat`,id_prod_order,`id_report`,`report_mark_type`,report_number,info_design,`value`,`note`)
VALUES('" & id_inv & "','" & GVList.GetRowCellValue(i, "id_prod_order").ToString & "','" & GVList.GetRowCellValue(i, "id_report").ToString & "','" & GVList.GetRowCellValue(i, "report_mark_type").ToString & "','" & GVList.GetRowCellValue(i, "report_number").ToString & "','" & GVList.GetRowCellValue(i, "info_design").ToString & "','" & decimalSQL(GVList.GetRowCellValue(i, "value").ToString) & "','" & addSlashes(GVList.GetRowCellValue(i, "note").ToString) & "');"
                    End If
                Next
                execute_non_query(query, True, "", "", "", "")
                '
                query = "CALL gen_number('" & id_inv & "','231')"
                execute_non_query(query, True, "", "", "", "")
                submit_who_prepared("231", id_inv, id_user)
                '
                infoCustom("BPB Created")
                FormInvMat.load_view()
                FormInvMat.XTCMatInv.SelectedTabPageIndex = 0
                FormInvMat.load_view()
                FormInvMat.GVInvoice.FocusedRowHandle = find_row(FormInvMat.GVInvoice, "id_inv_mat", id_inv)
                Close()
            Else
                'edit
                Dim query As String = ""
            End If
        ElseIf SLEPayType.EditValue.ToString = "2" Then 'retur
            If id_inv = "-1" Then
                'new
                'header
                Dim query As String = "INSERT INTO `tb_inv_mat`(`id_inv_mat_type`,`id_comp`,`created_by`,`created_date`,`note`,`id_report_status`,`due_date`,`ref_date`,`vat_percent`,is_deposit)
VALUES ('" & SLEPayType.EditValue.ToString & "','" & SLEVendor.EditValue.ToString & "','" & id_user & "',NOW(),'" & addSlashes(MENote.Text) & "','1','" & Date.Parse(DEDueDate.EditValue.ToString).ToString("yyyy-MM-dd") & "','" & Date.Parse(DERefDate.EditValue.ToString).ToString("yyyy-MM-dd") & "','" & decimalSQL(TEVatPercent.EditValue.ToString) & "','2'); SELECT LAST_INSERT_ID(); "
                id_inv = execute_query(query, 0, True, "", "", "", "")
                'id_inv
                query = ""
                For i = 0 To GVList.RowCount - 1
                    query += "INSERT INTO `tb_inv_mat_det`(`id_inv_mat`,id_prod_order,`id_report`,`report_mark_type`,report_number,info_design,`value`,`note`)
VALUES('" & id_inv & "','" & GVList.GetRowCellValue(i, "id_prod_order").ToString & "','" & GVList.GetRowCellValue(i, "id_report").ToString & "','" & GVList.GetRowCellValue(i, "report_mark_type").ToString & "','" & GVList.GetRowCellValue(i, "report_number").ToString & "','" & GVList.GetRowCellValue(i, "info_design").ToString & "','" & decimalSQL(GVList.GetRowCellValue(i, "value").ToString) & "','" & addSlashes(GVList.GetRowCellValue(i, "note").ToString) & "');"
                Next
                execute_non_query(query, True, "", "", "", "")
                '
                query = "CALL gen_number('" & id_inv & "','231')"
                execute_non_query(query, True, "", "", "", "")
                submit_who_prepared("231", id_inv, id_user)
                '
                infoCustom("BRP Created")
                FormInvMat.load_view()
                FormInvMat.XTCMatInv.SelectedTabPageIndex = 0
                FormInvMat.load_view()
                FormInvMat.GVInvoice.FocusedRowHandle = find_row(FormInvMat.GVInvoice, "id_inv_mat", id_inv)
                Close()
            Else
                'edit
                Dim query As String = ""
            End If
        End If
    End Sub

    Private Sub BtnPrint_Click(sender As Object, e As EventArgs) Handles BtnPrint.Click
        Cursor = Cursors.WaitCursor
        ReportInvMat.id_inv_mat = id_inv
        ReportInvMat.rmt = "231"
        ReportInvMat.dt = GCList.DataSource
        Dim Report As New ReportInvMat()

        If id_status = "6" Then
            Report.id_pre = "2"
        Else
            Report.id_pre = "1"
        End If

        If CEPrintPreview.EditValue = True Then
            Dim Tool As ReportPrintTool = New ReportPrintTool(Report)
            Tool.ShowPreviewDialog()
        Else
            Dim instance As New Printing.PrinterSettings
            Dim DefaultPrinter As String = instance.PrinterName

            ' THIS IS TO PRINT THE REPORT
            Report.PrinterName = DefaultPrinter
            Report.CreateDocument()
            Report.PrintingSystem.ShowMarginsWarning = False
            Report.Print()
        End If

        Cursor = Cursors.Default
    End Sub

    Private Sub BtnViewJournal_Click(sender As Object, e As EventArgs) Handles BtnViewJournal.Click
        Cursor = Cursors.WaitCursor
        Dim id_acc_trans As String = ""
        Try
            id_acc_trans = execute_query("SELECT ad.id_acc_trans FROM tb_a_acc_trans_det ad
            WHERE ad.report_mark_type=231 AND ad.id_report=" + id_inv + "
            GROUP BY ad.id_acc_trans ", 0, True, "", "", "", "")
        Catch ex As Exception
            id_acc_trans = ""
        End Try

        If id_acc_trans <> "" Then
            Dim s As New ClassShowPopUp()
            FormViewJournal.is_enable_view_doc = False
            FormViewJournal.BMark.Visible = False
            s.id_report = id_acc_trans
            s.report_mark_type = "36"
            s.show()
        Else
            warningCustom("Auto journal not found.")
        End If
        Cursor = Cursors.Default
    End Sub

    Private Sub BMark_Click(sender As Object, e As EventArgs) Handles BMark.Click
        FormReportMark.report_mark_type = "231"
        FormReportMark.is_view = is_view
        FormReportMark.id_report = id_inv
        FormReportMark.ShowDialog()
    End Sub

    Private Sub GVList_CellValueChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles GVList.CellValueChanged
        If e.Column.FieldName = "price" Then
            GVList.SetRowCellValue(e.RowHandle, "value", GVList.GetRowCellValue(e.RowHandle, "price") * GVList.GetRowCellValue(e.RowHandle, "qty"))
        End If
        GVList.RefreshData()
        calculate()
    End Sub
End Class