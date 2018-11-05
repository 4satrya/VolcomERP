﻿Public Class FormPurcReqDet
    Public id_req As String = "-1"
    Public id_user_created As String = "-1"
    Public is_draft As String = "1"
    Public is_view As String = "-1"
    '
    Dim calculate_in_proc As Boolean = False
    '
    Private Sub FormPurcReqDet_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        load_report_status()
        load_request_type()
        '
        If id_req = "-1" Then 'new
            load_item_pil()
            load_det()
            '
            TEReqBy.Text = name_user
            id_user_created = id_user
            DEDateCreated.EditValue = Now
            TEReqNUmber.Text = "[auto generate]"
            TEDep.Text = get_departement_x(id_departement_user, "1")
        Else 'edit
            load_item_pil()
            SLERequestType.Enabled = False
            '
            Dim query As String = "SELECT req.`purc_req_number`,req.`note`,emp.`employee_name`,req.`date_created`,dep.departement,req.id_purc_req_type,req.id_report_status FROM tb_purc_req req
                                    INNER JOIN tb_m_user usr ON usr.`id_user`=req.`id_user_created`
                                    INNER JOIN tb_m_employee emp ON emp.`id_employee`=usr.`id_employee`
                                    INNER JOIN tb_m_departement dep ON dep.id_departement=emp.id_departement
                                    WHERE id_purc_req='" & id_req & "'"
            Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
            '
            If data.Rows.Count > 0 Then
                TEReqBy.Text = data.Rows(0)("employee_name").ToString
                DEDateCreated.EditValue = data.Rows(0)("date_created")
                TEReqNUmber.Text = data.Rows(0)("purc_req_number").ToString
                TEDep.Text = data.Rows(0)("departement").ToString
                MENote.Text = data.Rows(0)("note").ToString
                '
                SLERequestType.EditValue = data.Rows(0)("id_purc_req_type").ToString
                LEReportStatus.ItemIndex = LEReportStatus.Properties.GetDataSourceRowIndex("id_report_status", data.Rows(0)("id_report_status").ToString)
                '
                load_item_pil()
                load_det()
            End If
        End If

        load_but()
    End Sub
    '
    Sub load_request_type()
        Dim query As String = "SELECT id_purc_req_type,purc_req_type FROM tb_lookup_purc_req_type WHERE is_active='1'"
        viewSearchLookupQuery(SLERequestType, query, "id_purc_req_type", "purc_req_type", "id_purc_req_type")
    End Sub
    '
    Sub load_report_status()
        Dim query As String = "SELECT * FROM tb_lookup_report_status a ORDER BY a.id_report_status "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        viewLookupQuery(LEReportStatus, query, 0, "report_status", "id_report_status")
    End Sub
    '
    Sub load_but()
        If id_req = "-1" Then 'new
            PCAddDel.Visible = True
            BtnAdd.Visible = True
            If GVItemList.RowCount > 0 Then
                BtnDel.Visible = True
            Else
                BtnDel.Visible = False
            End If
        Else
            PCAddDel.Visible = False
            BtnDel.Visible = False
            BtnAdd.Visible = False
        End If
        If is_view = "1" Then
            GVItemList.OptionsBehavior.ReadOnly = True
            BtnCancel.Visible = False
            BtnSave.Visible = False
            BtnPrint.Visible = False
        End If
    End Sub

    Sub load_det()
        Dim query As String = "SELECT reqd.*,uom.uom,cat.`item_cat`
                                FROM tb_purc_req_det reqd 
                                INNER JOIN tb_item itm ON reqd.`id_item`=itm.`id_item`
                                INNER JOIN tb_item_cat cat ON cat.`id_item_cat`=itm.`id_item_cat`
                                INNER JOIN tb_m_uom uom ON uom.`id_uom`=itm.`id_uom`
                                WHERE reqd.id_purc_req='" & id_req & "'"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCItemList.DataSource = data
    End Sub

    Sub load_item_pil()
        Dim query As String = "SELECT ex.id_b_expense,it.id_item,it.item_desc,uom.uom,cat.item_cat,value_expense AS budget,IFNULL(used.val,0) AS budget_used,((SELECT budget)-(SELECT budget_used)) AS budget_remaining,it.`latest_price` FROM tb_item it
                                INNER JOIN tb_item_cat cat ON cat.id_item_cat=it.id_item_cat
                                INNER JOIN tb_item_coa itc ON itc.id_item_cat=cat.id_item_cat AND itc.id_departement='" & id_departement_user & "'
                                INNER JOIN tb_b_expense ex ON ex.`id_item_coa`=itc.`id_item_coa` AND ex.is_active='1' AND ex.year=YEAR(NOW())
                                INNER JOIN tb_m_uom uom ON uom.id_uom=it.id_uom
                                LEFT JOIN 
                                (
	                                SELECT reqd.id_b_expense,SUM(`qty`*`value`) AS val
	                                FROM `tb_purc_req_det` reqd
	                                INNER JOIN tb_purc_req req ON req.`id_purc_req`=reqd.`id_purc_req` AND req.`id_report_status`!=5 AND is_cancel!=1
	                                GROUP BY reqd.id_b_expense
                                )used ON used.id_b_expense=ex.`id_b_expense`
                                WHERE it.is_active='1' AND it.id_purc_req_type='" & SLERequestType.EditValue.ToString & "'"
        viewSearchLookupRepositoryQuery(RISLEItem, query, 0, "item_desc", "id_item")
    End Sub

    Sub load_item_pil_edit()
        Dim query As String = "SELECT it.id_item,it.item_desc,cat.item_cat FROM tb_item it
                                INNER JOIN tb_item_cat cat ON cat.id_item_cat=it.id_item_cat
                                INNER JOIN tb_item_coa itc ON itc.id_item_cat=cat.id_item_cat AND itc.id_departement='" & id_departement_user & "'"
        viewSearchLookupRepositoryQuery(RISLEItem, query, "id_item", "item_desc", "id_item")
    End Sub

    Private Sub FormPurcReqDet_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub BtnAdd_Click(sender As Object, e As EventArgs) Handles BtnAdd.Click
        GVItemList.AddNewRow()
        GVItemList.FocusedRowHandle = GVItemList.RowCount - 1
        check_but()
    End Sub

    Private Sub RISLEItem_EditValueChanged(sender As Object, e As EventArgs) Handles RISLEItem.EditValueChanged
        Dim sle As DevExpress.XtraEditors.SearchLookUpEdit = CType(sender, DevExpress.XtraEditors.SearchLookUpEdit)
        'budget
        If GVItemList.FocusedRowHandle = 0 Then
            GVItemList.SetFocusedRowCellValue("budget_remaining", sle.Properties.View.GetFocusedRowCellValue("budget_remaining").ToString())
        ElseIf GVItemList.FocusedRowHandle = 1 Then
            If GVItemList.GetRowCellValue(0, "id_b_expense").ToString = sle.Properties.View.GetFocusedRowCellValue("id_b_expense").ToString() Then
                GVItemList.SetFocusedRowCellValue("budget_remaining", GVItemList.GetRowCellValue(0, "budget_after"))
            Else
                GVItemList.SetFocusedRowCellValue("budget_remaining", sle.Properties.View.GetFocusedRowCellValue("budget_remaining").ToString())
            End If
        Else
            Dim is_found As Boolean = False
            For i As Integer = GVItemList.FocusedRowHandle - 1 To 0 Step -1
                If GVItemList.GetRowCellValue(i, "id_b_expense").ToString = sle.Properties.View.GetFocusedRowCellValue("id_b_expense").ToString() Then
                    GVItemList.SetFocusedRowCellValue("budget_remaining", GVItemList.GetRowCellValue(i, "budget_after"))
                    is_found = True
                    Exit For
                End If
            Next
            If is_found = False Then
                GVItemList.SetFocusedRowCellValue("budget_remaining", sle.Properties.View.GetFocusedRowCellValue("budget_remaining").ToString())
            End If
        End If
        '
        If SLERequestType.EditValue = "1" Then 'purchase the auto price
            GVItemList.SetFocusedRowCellValue("value", sle.Properties.View.GetFocusedRowCellValue("latest_price"))
        End If

        GVItemList.SetFocusedRowCellValue("uom", sle.Properties.View.GetFocusedRowCellValue("uom").ToString())
        GVItemList.SetFocusedRowCellValue("item_cat", sle.Properties.View.GetFocusedRowCellValue("item_cat").ToString())
        GVItemList.SetFocusedRowCellValue("id_b_expense", sle.Properties.View.GetFocusedRowCellValue("id_b_expense").ToString())
    End Sub

    Sub check_but()
        If GVItemList.RowCount > 0 Then
            BtnDel.Visible = True
        Else
            BtnDel.Visible = False
        End If
    End Sub

    Private Sub BtnCancel_Click(sender As Object, e As EventArgs) Handles BtnCancel.Click
        Close()
    End Sub

    Private Sub BtnSave_Click(sender As Object, e As EventArgs) Handles BtnSave.Click
        'validate
        Dim is_exceed_budget As Boolean = False

        If GVItemList.RowCount > 0 Then
            'check exceed budget
            For i As Integer = 0 To GVItemList.RowCount - 1
                If GVItemList.GetRowCellValue(i, "budget_after") < 0 Or GVItemList.GetRowCellValue(i, "budget_after").ToString = "" Then
                    is_exceed_budget = True
                End If
            Next
            '
            If is_exceed_budget = False Then
                If id_req = "-1" Then 'new
                    Dim query As String = "INSERT INTO tb_purc_req(id_departement,note,id_user_created,date_created,id_purc_req_type) VALUES('" & id_departement_user & "','" & MENote.Text & "','" & id_user & "',NOW(),'" & SLERequestType.EditValue.ToString & "'); SELECT LAST_INSERT_ID(); "
                    Dim id_req As String = execute_query(query, 0, True, "", "", "", "")
                    '
                    Dim query_det As String = ""
                    For i As Integer = 0 To GVItemList.RowCount - 1
                        'check budget again
                        Dim query_check As String = "SELECT (ex.value_expense-IFNULL(used_ex.val,0)) AS remaining FROM tb_b_expense ex
                                                     LEFT JOIN
                                                     (
	                                                    SELECT reqd.id_b_expense,SUM(`qty`*`value`) AS val
	                                                    FROM `tb_purc_req_det` reqd
	                                                    INNER JOIN tb_purc_req req ON req.`id_purc_req`=reqd.`id_purc_req` AND req.`id_report_status`!=5 AND is_cancel!=1
	                                                    WHERE reqd.`id_b_expense` = '" & GVItemList.GetRowCellValue(i, "id_b_expense").ToString & "'
	                                                    GROUP BY reqd.id_b_expense
                                                     )used_ex ON used_ex.id_b_expense=ex.`id_b_expense`
                                                     WHERE ex.`year`=YEAR(NOW()) AND ex.id_b_expense='" & GVItemList.GetRowCellValue(i, "id_b_expense").ToString & "' AND ex.is_active='1'"
                        Dim data_check As DataTable = execute_query(query_check, -1, True, "", "", "", "")
                        If Not data_check.Rows(0)("remaining") - (GVItemList.GetRowCellValue(i, "qty") * GVItemList.GetRowCellValue(i, "value")) < 0 Then
                            If Not query_det = "" Then
                                query_det += ","
                            End If
                            query_det += "('" & id_req & "','" & GVItemList.GetRowCellValue(i, "id_item").ToString & "','" & GVItemList.GetRowCellValue(i, "id_b_expense").ToString & "','" & decimalSQL(GVItemList.GetRowCellValue(i, "qty").ToString) & "','" & decimalSQL(GVItemList.GetRowCellValue(i, "value").ToString) & "','" & decimalSQL(GVItemList.GetRowCellValue(i, "budget_remaining").ToString) & "','" & addSlashes(GVItemList.GetRowCellValue(i, "note").ToString) & "')"
                        End If
                    Next
                    '
                    query_det = "INSERT INTO `tb_purc_req_det`(id_purc_req,id_item,id_b_expense,qty,value,budget_remaining,note)
                                                VALUES" & query_det
                    '
                    execute_non_query(query_det, True, "", "", "", "")

                    'insert to expense trans
                    Dim query_trans As String = "INSERT INTO `tb_b_expense_trans`(id_b_expense,date_trans,`value`,is_actual,id_report,report_mark_type) 
                                                 SELECT id_b_expense,NOW(),`value`,'2' AS is_actual,id_purc_req AS id_report,'137' AS report_mark_type
                                                 FROM tb_purc_req_det prd
                                                 WHERE prd.`id_purc_req`='" & id_req & "'"
                    execute_non_query(query_trans, True, "", "", "", "")

                    'generate number
                    query = "CALL gen_number('" & id_req & "','137')"
                    execute_non_query(query, True, "", "", "", "")
                    '
                    submit_who_prepared("137", id_req, id_user)
                    infoCustom("Purchase requested.")
                    FormPurcReq.load_req()
                    Close()
                Else 'edit
                    Dim query As String = "UPDATE tb_purc_req SET id_user_last_upd='" & id_user & "',date_last_upd=NOW(),note='" & addSlashes(MENote.Text) & "',id_purc_req_type='" & SLERequestType.EditValue.ToString & "' WHERE id_purc_req='" & id_req & "'"
                    execute_non_query(query, True, "", "", "", "")
                    infoCustom("Purchase request updated.")
                    FormPurcReq.load_req()
                    Close()
                End If
            Else
                stopCustom("Please make sure the item you requested not exceed the budget and filled properly.")
            End If
        Else
            stopCustom("Please insert the item first")
        End If
    End Sub

    Private Sub GVItemList_CustomUnboundColumnData(sender As Object, e As DevExpress.XtraGrid.Views.Base.CustomColumnDataEventArgs) Handles GVItemList.CustomUnboundColumnData
        If e.Column.FieldName = "sub_tot" Then
            Try
                TETotal.EditValue = 0.00
                TETotal.EditValue = Double.Parse(GVItemList.Columns("sub_tot").SummaryItem.SummaryValue.ToString)
            Catch ex As Exception
            End Try
        End If
        If e.Column.FieldName = "budget_after" Then
            Try
                If calculate_in_proc = False Then
                    update_remaining_budget()
                End If
            Catch ex As Exception
                calculate_in_proc = False
            End Try
        End If
    End Sub

    Sub update_remaining_budget()
        calculate_in_proc = True
        For i As Integer = 0 To GVItemList.RowCount - 1
            'check per item
            For j As Integer = i + 1 To GVItemList.RowCount - 1
                If GVItemList.GetRowCellValue(i, "id_b_expense").ToString = GVItemList.GetRowCellValue(j, "id_b_expense").ToString Then
                    GVItemList.SetRowCellValue(j, "budget_remaining", GVItemList.GetRowCellValue(i, "budget_after"))
                End If
            Next
        Next
        calculate_in_proc = False
    End Sub

    Private Sub BtnDel_Click(sender As Object, e As EventArgs) Handles BtnDel.Click
        GVItemList.DeleteSelectedRows()
        update_remaining_budget()
        check_but()
    End Sub

    Private Sub BMark_Click(sender As Object, e As EventArgs) Handles BMark.Click
        FormReportMark.id_report = id_req
        FormReportMark.report_mark_type = "137"
        If is_view = "1" Then
            FormReportMark.is_view = "1"
        End If
        FormReportMark.form_origin = Name
        FormReportMark.ShowDialog()
    End Sub

    Private Sub BtnPrint_Click(sender As Object, e As EventArgs) Handles BtnPrint.Click
        'Cursor = Cursors.WaitCursor
        'ReportPurcOrder.id_po = id_po
        'ReportPurcOrder.dt = GCSummary.DataSource
        'Dim Report As New ReportPurcOrder()
        '' '... 
        '' ' creating and saving the view's layout to a new memory stream 
        'Dim str As System.IO.Stream
        'str = New System.IO.MemoryStream()
        'GVSummary.SaveLayoutToStream(str, DevExpress.Utils.OptionsLayoutBase.FullLayout)
        'str.Seek(0, System.IO.SeekOrigin.Begin)
        'Report.GVSummary.RestoreLayoutFromStream(str, DevExpress.Utils.OptionsLayoutBase.FullLayout)
        'str.Seek(0, System.IO.SeekOrigin.Begin)

        ''Grid Detail
        'ReportStyleGridview(Report.GVSummary)

        ''Parse val
        'Report.LPoNumber.Text = TEPONumber.Text
        'Report.LTerm.Text = LEPaymentTerm.Text.ToUpper
        'Report.LCreateDate.Text = Date.Parse(DEDateCreated.EditValue.ToString).ToString("dd MMMM yyyy")
        'Report.LEstRecDate.Text = Date.Parse(DEEstReceiveDate.EditValue.ToString).ToString("dd MMMM yyyy").ToUpper
        'Report.LTermOrder.Text = LEOrderTerm.Text.ToUpper
        'Report.LShipVia.Text = LEShipVia.Text.ToUpper
        ''
        'Report.LabelAttn.Text = TEVendorAttn.Text
        'Report.LTo.Text = TEVendorName.Text
        'Report.LToAdress.Text = MEAdrressCompTo.Text & vbNewLine & TEVendorPhone.Text & vbNewLine & TEVendorEmail.Text

        'Report.LShipTo.Text = get_company_x(get_id_company(get_setup_field("id_own_company")), "1")
        'Report.LShipToAddress.Text = get_company_x(get_id_company(get_setup_field("id_own_company")), "3")

        'If Not LEReportStatus.EditValue = "6" Then
        '    Report.id_pre = "2"
        'Else
        '    Report.id_pre = "1"
        'End If

        ''Show the report's preview. 
        'Dim Tool As DevExpress.XtraReports.UI.ReportPrintTool = New DevExpress.XtraReports.UI.ReportPrintTool(Report)
        'Tool.ShowPreview()
        'Cursor = Cursors.Default
    End Sub

    Dim is_reload As String = "2"

    Private Sub SLERequestType_EditValueChanged(sender As Object, e As EventArgs) Handles SLERequestType.EditValueChanged
        'reset
        If Not SLERequestType.EditValue = SLERequestType.OldEditValue And is_reload = "2" And id_req = "-1" Then
            If GVItemList.RowCount > 0 Then
                Dim confirm As DialogResult
                confirm = DevExpress.XtraEditors.XtraMessageBox.Show("All list will be reset, continue ?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)

                If confirm = DialogResult.Yes Then
                    clear_all_request()
                    load_item_pil()
                    load_but()
                Else
                    SLERequestType.EditValue = SLERequestType.OldEditValue
                End If
            Else
                load_item_pil()
                load_but()
            End If
        End If
        '
        If SLERequestType.EditValue.ToString = "1" Then
            GCValue.OptionsColumn.ReadOnly = True
        Else
            GCValue.OptionsColumn.ReadOnly = False
        End If
        '
        is_reload = "2"
    End Sub

    Sub clear_all_request()
        For i As Integer = GVItemList.RowCount - 1 To 0 Step -1
            GVItemList.DeleteRow(i)
        Next
    End Sub
End Class