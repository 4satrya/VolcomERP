Public Class FormPurcReqDet
    Public id_req As String = "-1"
    Public id_user_created As String = "-1"
    Public is_draft As String = "1"
    Public is_view As String = "-1"
    '
    Dim calculate_in_proc As Boolean = False
    Dim is_reload As String = "2"
    Dim id_departement As String = "-1"
    '
    Public is_submit As String = "-1"
    Public is_ic_ia As String = "-1"
    '
    Public rmt As String = "-1"
    Public id_report_status = "-1"
    '
    Sub load_approval_ic_ia()
        Dim query As String = "SELECT '1' AS id_approval,'No Action' AS approval
UNION
SELECT '2' AS id_approval,'Approve' AS approval
UNION
SELECT '3' AS id_approval,'Not Approve' AS approval"
        viewSearchLookupQuery(SLEICApproval, query, "id_approval", "approval", "id_approval")
        viewSearchLookupQuery(SLEIAApproval, query, "id_approval", "approval", "id_approval")
    End Sub

    Sub load_form()
        load_approval_ic_ia()
        load_report_status()
        is_reload = "1"
        DEYearBudget.EditValue = Now
        load_purc_type()
        is_reload = "2"
        '
        If id_req = "-1" Then 'new
            If FormPurcReq.SLEDepartement.EditValue.ToString = "0" Then
                TEDep.Text = get_departement_x(id_departement_user, "1")
                id_departement = id_departement_user
            Else
                TEDep.Text = get_departement_x(FormPurcReq.SLEDepartement.EditValue.ToString, "1")
                id_departement = FormPurcReq.SLEDepartement.EditValue.ToString
            End If

            load_item_pil()
            load_det()
            '
            TEReqBy.Text = name_user
            id_user_created = id_user
            DEDateCreated.EditValue = Now
            TEReqNUmber.Text = "[auto generate]"

            DERequirementDate.EditValue = Now
            '
            GVItemList.OptionsBehavior.Editable = True
            BtnAttachment.Visible = False
            '
        Else 'edit
            BtnAttachment.Visible = True
            BSetShipping.Visible = False
            DERequirementDate.Properties.ReadOnly = True
            DEYearBudget.Properties.ReadOnly = True
            SLEPurcType.Properties.ReadOnly = True
            '
            GVItemList.OptionsBehavior.Editable = False
            '
            Dim query As String = "SELECT req.id_user_created,req.report_mark_type,req.is_submit,req.ic_approval,req.ia_approval,req.ic_note,req.ia_note,req.id_expense_type,DATE(CONCAT(req.year_budget, '-01-01')) as year_budget,req.`purc_req_number`,req.requirement_date,req.`note`,req.id_departement,emp.`employee_name`,req.`date_created`,dep.departement,req.id_report_status,req.is_store_purchase
                                    FROM tb_purc_req req
                                    INNER JOIN tb_m_user usr ON usr.`id_user`=req.`id_user_created`
                                    INNER JOIN tb_m_employee emp ON emp.`id_employee`=usr.`id_employee`
                                    INNER JOIN tb_m_departement dep ON dep.id_departement=req.id_departement
                                    WHERE id_purc_req='" & id_req & "'"
            Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
            '
            If data.Rows.Count > 0 Then
                rmt = data.Rows(0)("report_mark_type").ToString
                id_user_created = data.Rows(0)("id_user_created").ToString
                TEReqBy.Text = data.Rows(0)("employee_name").ToString
                id_departement = data.Rows(0)("id_departement").ToString
                DEDateCreated.EditValue = data.Rows(0)("date_created")
                DERequirementDate.EditValue = data.Rows(0)("requirement_date")
                TEReqNUmber.Text = data.Rows(0)("purc_req_number").ToString
                TEDep.Text = data.Rows(0)("departement").ToString
                MENote.Text = data.Rows(0)("note").ToString
                DEYearBudget.EditValue = data.Rows(0)("year_budget")
                '
                SLEPurcType.EditValue = data.Rows(0)("id_expense_type").ToString
                LEReportStatus.ItemIndex = LEReportStatus.Properties.GetDataSourceRowIndex("id_report_status", data.Rows(0)("id_report_status").ToString)
                '
                id_report_status = data.Rows(0)("id_report_status").ToString
                '
                is_submit = data.Rows(0)("is_submit").ToString
                SLEICApproval.EditValue = data.Rows(0)("ic_approval").ToString
                TENoteIC.Text = data.Rows(0)("ic_note").ToString
                SLEIAApproval.EditValue = data.Rows(0)("ia_approval").ToString
                TENoteIA.Text = data.Rows(0)("ia_note").ToString
                '
                If data.Rows(0)("is_store_purchase").ToString = "1" Then
                    CEStoreRequest.Checked = True
                Else
                    CEStoreRequest.Checked = False
                End If
                '
                load_item_pil()
                load_det()
            End If
        End If

        load_but()
        '
        If SLEPurcType.EditValue.ToString = "1" Then 'opex
            CEStoreRequest.Visible = True
            LStoreRequest.Visible = True
            PCIAIC.Visible = False
        Else
            If rmt = "201" Then
                PCIAIC.Visible = True
            End If
        End If
    End Sub

    Private Sub FormPurcReqDet_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        load_vendor()
        load_form()
    End Sub
    '
    Sub load_vendor()
        Dim query As String = "SELECT 0 AS id_comp,'Custom' AS comp_number,'Custom' AS comp_name,'Custom' AS address_primary
UNION ALL
SELECT id_comp,comp_number,comp_name,address_primary FROM `tb_m_comp` WHERE is_active='1'"
        viewSearchLookupRepositoryQuery(RISLEShipTo, query, 0, "comp_number", "id_comp")
    End Sub
    '
    Sub load_purc_type()
        Dim query As String = "SELECT id_expense_type,expense_type FROM `tb_lookup_expense_type`"
        viewSearchLookupQuery(SLEPurcType, query, "id_expense_type", "expense_type", "id_expense_type")
    End Sub
    '
    Sub load_report_status()
        Dim query As String = "SELECT * FROM tb_lookup_report_status a ORDER BY a.id_report_status "
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
            BtnPrint.Visible = False
            BMark.Visible = False
        Else
            PCAddDel.Visible = False
            BtnDel.Visible = False
            BtnAdd.Visible = False
            '
            BtnPrint.Visible = True
            BMark.Visible = True
        End If

        If is_view = "1" Then
            GVItemList.OptionsBehavior.ReadOnly = True
            BtnCancel.Visible = False
            BtnSave.Visible = False
            BtnPrint.Visible = False
        End If
    End Sub

    Sub load_det()
        Dim query As String = "SELECT reqd.*,uom.uom,cat.`item_cat`,itm.item_desc,itm.`id_item_type`,IF(main.is_fixed_asset=1,'yes','no') AS is_fixed_asset
                                FROM tb_purc_req_det reqd 
                                INNER JOIN tb_item itm ON reqd.`id_item`=itm.`id_item`
                                INNER JOIN tb_item_cat cat ON cat.`id_item_cat`=itm.`id_item_cat`
                                INNER JOIN tb_item_cat_main main ON main.id_item_cat_main=cat.id_item_cat_main
                                INNER JOIN tb_m_uom uom ON uom.`id_uom`=itm.`id_uom`
                                WHERE reqd.id_purc_req='" & id_req & "'"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCItemList.DataSource = data
    End Sub

    Sub load_item_pil()
        Dim query As String = ""

        query = "SELECT it.id_item,IF(main.is_fixed_asset=1,'yes','no') AS is_fixed_asset,used.id_b_expense,used_opex.id_b_expense_opex,cat.`id_expense_type`,it.`id_item_cat`,it.item_desc,uom.uom,cat.item_cat,IFNULL(IF(cat.`id_expense_type`='2',used.value_expense,used_opex.value_expense),0) AS budget,IFNULL(IF(cat.`id_expense_type`='2',used.val,used_opex.val),0) AS budget_used,((SELECT budget)-(SELECT budget_used)) AS budget_remaining,it.`latest_price` 
                    FROM tb_item it
                    INNER JOIN tb_m_uom uom ON uom.id_uom=it.id_uom
                    INNER JOIN tb_item_cat cat ON cat.id_item_cat=it.id_item_cat
                    INNER JOIN tb_item_cat_main main ON main.id_item_cat_main=cat.id_item_cat_main
                    INNER JOIN tb_item_coa coa ON coa.id_item_cat = cat.id_item_cat AND coa.id_departement = '" & id_departement & "'
                    LEFT JOIN
                    (
	                    SELECT ex.`value_expense`,used.val AS val,ex.`id_b_expense`,ex.`id_item_cat_main` 
	                    FROM tb_b_expense ex 
	                    LEFT JOIN 
	                    (
		                    SELECT trx.id_b_expense,SUM(`value`) AS val
		                    FROM `tb_b_expense_trans` trx
		                    GROUP BY trx.id_b_expense
	                    ) used ON used.id_b_expense=ex.`id_b_expense` 
                        WHERE ex.is_active='1' AND ex.year='" & Date.Parse(DEYearBudget.EditValue.ToString).ToString("yyyy") & "' AND ex.`id_departement`='" & id_departement & "'
                    )used ON used.id_item_cat_main=cat.`id_item_cat_main`
                    LEFT JOIN
                    (
	                    SELECT ex.`value_expense`,used.val AS val,ex.`id_b_expense_opex`,ex.`id_item_cat_main` 
	                    FROM tb_b_expense_opex ex 
	                    LEFT JOIN 
	                    (
		                    SELECT trx.id_b_expense_opex,SUM(`value`) AS val
		                    FROM `tb_b_expense_opex_trans` trx
		                    GROUP BY trx.id_b_expense_opex
	                    ) used ON used.id_b_expense_opex=ex.`id_b_expense_opex` 
                        WHERE ex.is_active='1' AND ex.year='" & Date.Parse(DEYearBudget.EditValue.ToString).ToString("yyyy") & "'
                    )used_opex ON used_opex.id_item_cat_main=cat.`id_item_cat_main`
                    WHERE it.is_active='1' AND cat.id_expense_type='" & SLEPurcType.EditValue.ToString & "' AND IFNULL(IF(cat.`id_expense_type`='2',used.value_expense,used_opex.value_expense),0) > 0"
        If GVItemList.RowCount > 1 Then
            query += " AND main.is_fixed_asset='" & If(GVItemList.GetRowCellValue(0, "is_fixed_asset").ToString = "yes", "1", "2") & "'"
        End If
        viewSearchLookupRepositoryQuery(RISLEItem, query, 0, "item_desc", "id_item")
        RISLEItem.View.BestFitColumns()
    End Sub

    Sub load_item_pil_edit()
        Dim query As String = "SELECT it.id_item,it.item_desc,cat.item_cat FROM tb_item it
                                INNER JOIN tb_item_cat cat ON cat.id_item_cat=it.id_item_cat
                                INNER JOIN tb_item_coa itc ON itc.id_item_cat=cat.id_item_cat AND itc.id_departement='" & id_departement & "'"
        viewSearchLookupRepositoryQuery(RISLEItem, query, "id_item", "item_desc", "id_item")
    End Sub

    Private Sub FormPurcReqDet_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub BtnAdd_Click(sender As Object, e As EventArgs) Handles BtnAdd.Click
        'check all value first
        Dim is_ok As Boolean = True
        If GVItemList.RowCount = 0 Then
            is_ok = True
        ElseIf GVItemList.GetFocusedRowCellValue("id_item").ToString = "" Or GVItemList.GetFocusedRowCellValue("qty").ToString = "" Or GVItemList.GetFocusedRowCellValue("ship_to").ToString = "" Then
            stopCustom("Please fill item/qty/destination first")
            is_ok = False
        End If

        If is_ok Then
            GVItemList.AddNewRow()
            GVItemList.FocusedRowHandle = GVItemList.RowCount - 1
            GVItemList.SetFocusedRowCellValue("ship_destination", get_setup_field("id_own_company"))
            load_item_pil()
            check_but()
        End If
        '
    End Sub

    Private Sub RISLEItem_EditValueChanged(sender As Object, e As EventArgs) Handles RISLEItem.EditValueChanged
        Try
            Dim sle As DevExpress.XtraEditors.SearchLookUpEdit = CType(sender, DevExpress.XtraEditors.SearchLookUpEdit)
            'budget
            GVItemList.SetFocusedRowCellValue("budget_remaining", sle.Properties.View.GetFocusedRowCellValue("budget_remaining").ToString())
            GVItemList.SetFocusedRowCellValue("is_fixed_asset", sle.Properties.View.GetFocusedRowCellValue("is_fixed_asset").ToString())
            'If GVItemList.FocusedRowHandle = 0 Then
            '    GVItemList.SetFocusedRowCellValue("budget_remaining", sle.Properties.View.GetFocusedRowCellValue("budget_remaining").ToString())
            'ElseIf GVItemList.FocusedRowHandle = 1 Then
            '    If GVItemList.GetRowCellValue(0, "id_b_expense").ToString = sle.Properties.View.GetFocusedRowCellValue("id_b_expense").ToString() Then
            '        GVItemList.SetFocusedRowCellValue("budget_remaining", GVItemList.GetRowCellValue(0, "budget_after"))
            '    Else
            '        GVItemList.SetFocusedRowCellValue("budget_remaining", sle.Properties.View.GetFocusedRowCellValue("budget_remaining").ToString())
            '    End If
            'Else
            '    Dim is_found As Boolean = False
            '    For i As Integer = GVItemList.FocusedRowHandle - 1 To 0 Step -1
            '        If GVItemList.GetRowCellValue(i, "id_b_expense").ToString = sle.Properties.View.GetFocusedRowCellValue("id_b_expense").ToString() Then
            '            GVItemList.SetFocusedRowCellValue("budget_remaining", GVItemList.GetRowCellValue(i, "budget_after"))
            '            is_found = True
            '            Exit For
            '        End If
            '    Next
            '    If is_found = False Then
            '        GVItemList.SetFocusedRowCellValue("budget_remaining", sle.Properties.View.GetFocusedRowCellValue("budget_remaining").ToString())
            '    End If
            'End If
            ''
            'If SLEItemType.EditValue = "1" Then 'purchase the auto price
            '    GVItemList.SetFocusedRowCellValue("value", sle.Properties.View.GetFocusedRowCellValue("latest_price"))
            'End If

            GVItemList.SetFocusedRowCellValue("item_detail", sle.Properties.View.GetFocusedRowCellValue("item_desc").ToString())
            GVItemList.SetFocusedRowCellValue("uom", sle.Properties.View.GetFocusedRowCellValue("uom").ToString())
            GVItemList.SetFocusedRowCellValue("item_cat", sle.Properties.View.GetFocusedRowCellValue("item_cat").ToString())
            GVItemList.SetFocusedRowCellValue("budget", sle.Properties.View.GetFocusedRowCellValue("budget").ToString())
            GVItemList.SetFocusedRowCellValue("id_expense_type", sle.Properties.View.GetFocusedRowCellValue("id_expense_type").ToString())
            GVItemList.SetFocusedRowCellValue("id_b_expense_opex", sle.Properties.View.GetFocusedRowCellValue("id_b_expense_opex").ToString())
            GVItemList.SetFocusedRowCellValue("id_b_expense", sle.Properties.View.GetFocusedRowCellValue("id_b_expense").ToString())
            GVItemList.SetFocusedRowCellValue("ship_destination", get_company_x(get_setup_field("id_own_company"), "1").ToString)
            GVItemList.SetFocusedRowCellValue("ship_address", get_company_x(get_setup_field("id_own_company"), "3").ToString)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub

    Sub check_but()
        If GVItemList.RowCount > 0 Then
            BtnDel.Visible = True
            DEYearBudget.Enabled = False
            SLEPurcType.Enabled = False
        Else
            BtnDel.Visible = False
            DEYearBudget.Enabled = True
            SLEPurcType.Enabled = True
        End If
    End Sub

    Private Sub BtnCancel_Click(sender As Object, e As EventArgs) Handles BtnCancel.Click
        Close()
    End Sub

    Private Sub BtnSave_Click(sender As Object, e As EventArgs) Handles BtnSave.Click
        'validate
        Dim is_exceed_budget As Boolean = False
        Dim is_no_shipping As Boolean = False
        Dim qty_is_0 As Boolean = False
        '
        Dim rmt_ins As String = ""
        '
        If GVItemList.RowCount > 0 Then
            'check 
            For i As Integer = 0 To GVItemList.RowCount - 1
                'exceed budget
                If GVItemList.GetRowCellValue(i, "budget").ToString = "" OrElse GVItemList.GetRowCellValue(i, "budget") <= 0 Then
                    is_exceed_budget = True
                End If
                'no shipping destination
                If GVItemList.GetRowCellValue(i, "ship_to").ToString = "" Or GVItemList.GetRowCellValue(i, "ship_destination").ToString = "" Then
                    is_no_shipping = True
                End If
                'no qty
                If GVItemList.GetRowCellValue(i, "qty").ToString = "" OrElse GVItemList.GetRowCellValue(i, "qty") <= 0 Then
                    qty_is_0 = True
                    Exit For
                End If
            Next
            '
            If is_exceed_budget = True Then
                stopCustom("Please make sure you have budget.")
            ElseIf is_no_shipping = True Then
                stopCustom("Please make sure choosing and fill the shipping destination.")
            ElseIf qty_is_0 = True Then
                stopCustom("Please make sure Qty is not 0.")
            ElseIf GVItemList.RowCount = 0 Then
                stopCustom("Please choose item first")
            Else
                Dim is_store_purchase As String = ""

                If CEStoreRequest.Checked = True Then
                    is_store_purchase = "1"
                Else
                    is_store_purchase = "2"
                End If

                If GVItemList.GetRowCellValue(0, "is_fixed_asset").ToString = "yes" Then 'fixed asset
                    rmt_ins = "201"
                Else
                    rmt_ins = "137"
                End If

                If id_req = "-1" Then 'new
                    Dim query As String = "INSERT INTO tb_purc_req(id_departement,report_mark_type,is_fixed_asset,is_store_purchase,id_expense_type,year_budget,note,id_user_created,date_created,requirement_date) VALUES('" & id_departement & "','" & rmt_ins & "','" & If(GVItemList.GetRowCellValue(0, "is_fixed_asset").ToString = "yes", "1", "2") & "','" & is_store_purchase & "','" & SLEPurcType.EditValue.ToString & "','" & Date.Parse(DEYearBudget.EditValue.ToString).ToString("yyyy") & "','" & addSlashes(MENote.Text) & "','" & id_user & "',NOW(),'" & Date.Parse(DERequirementDate.EditValue.ToString).ToString("yyyy-MM-dd") & "'); SELECT LAST_INSERT_ID(); "
                    id_req = execute_query(query, 0, True, "", "", "", "")
                    '
                    Dim query_det As String = ""
                    For i As Integer = 0 To GVItemList.RowCount - 1
                        If Not query_det = "" Then
                            query_det += ","
                        End If
                        query_det += "('" & id_req & "','" & GVItemList.GetRowCellValue(i, "id_item").ToString & "','" & GVItemList.GetRowCellValue(i, "id_b_expense_opex").ToString & "','" & GVItemList.GetRowCellValue(i, "id_b_expense").ToString & "','" & decimalSQL(GVItemList.GetRowCellValue(i, "qty").ToString) & "','0.00','" & decimalSQL(GVItemList.GetRowCellValue(i, "budget").ToString) & "','" & decimalSQL(GVItemList.GetRowCellValue(i, "budget_remaining").ToString) & "','" & addSlashes(GVItemList.GetRowCellValue(i, "note").ToString) & "','" & addSlashes(GVItemList.GetRowCellValue(i, "ship_to").ToString) & "','" & addSlashes(GVItemList.GetRowCellValue(i, "ship_destination").ToString) & "','" & addSlashes(GVItemList.GetRowCellValue(i, "ship_address").ToString) & "','" & addSlashes(GVItemList.GetRowCellValue(i, "item_detail").ToString) & "')"
                    Next
                    '
                    query_det = "INSERT INTO `tb_purc_req_det`(id_purc_req,id_item,id_b_expense_opex,id_b_expense,qty,value,budget,budget_remaining,note,ship_to,ship_destination,ship_address,item_detail)
                                                VALUES" & query_det
                    '
                    execute_non_query(query_det, True, "", "", "", "")
                    'generate number
                    query = "CALL gen_number('" & id_req & "','" & rmt_ins & "')"
                    execute_non_query(query, True, "", "", "", "")

                    infoCustom("Purchase requested.")
                    load_form()
                    FormPurcReq.load_req()
                Else 'edit
                    Dim query As String = "UPDATE tb_purc_req SET id_user_last_upd='" & id_user & "',is_store_purchase='" & is_store_purchase & "',year_budget='" & Date.Parse(DEYearBudget.EditValue.ToString).ToString("yyyy") & "',date_last_upd=NOW(),requirement_date='" & Date.Parse(DERequirementDate.EditValue.ToString).ToString("yyyy-MM-dd") & "',note='" & addSlashes(MENote.Text) & "' WHERE id_purc_req='" & id_req & "'"
                    execute_non_query(query, True, "", "", "", "")
                    infoCustom("Purchase request updated.")
                    load_form()
                    FormPurcReq.load_req()
                End If
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
    End Sub

    Private Sub BtnDel_Click(sender As Object, e As EventArgs) Handles BtnDel.Click
        If GVItemList.RowCount > 0 Then
            GVItemList.DeleteRow(GVItemList.RowCount - 1)
            load_item_pil()
            check_but()
        End If
    End Sub

    Private Sub BMark_Click(sender As Object, e As EventArgs) Handles BMark.Click
        If is_submit = "1" Then
            FormReportMark.id_report = id_req
            FormReportMark.report_mark_type = rmt
            If is_view = "1" Then
                FormReportMark.is_view = "1"
            End If
            FormReportMark.form_origin = Name
            FormReportMark.ShowDialog()
        Else
            'submit
            If rmt = "201" Then 'fixed asset
                If is_ic_ia = "1" Then
                    FormPurcReqICApproval.step_approve = FormPurcReqList.step_approve
                    FormPurcReqICApproval.id_report = id_req
                    FormPurcReqICApproval.ShowDialog()
                    load_form()
                Else
                    warningCustom("Only IA and IC can submit Fixed Asset request")
                End If
            Else 'non fixed asset
                Dim query_upd As String = "UPDATE tb_purc_req SET is_submit='1' WHERE id_purc_req='" & id_req & "'"
                execute_non_query(query_upd, True, "", "", "", "")
                submit_who_prepared(rmt, id_req, id_user_created)
                load_form()
            End If
        End If
    End Sub

    Private Sub BtnPrint_Click(sender As Object, e As EventArgs) Handles BtnPrint.Click
        Cursor = Cursors.WaitCursor

        ReportPurcReq.id_req = id_req
        ReportPurcReq.dt = GCItemList.DataSource
        ReportPurcReq.rmt = rmt
        Dim Report As New ReportPurcReq()
        ' '... 

        'Grid Detail
        ReportStyleGridview(Report.GVItemList)
        Report.GVItemList.BestFitColumns()

        'Parse val
        Dim query As String = "SELECT req.`purc_req_number`,et.`expense_type`,DATE_FORMAT(req.requirement_date,'%d %M %Y') AS requirement_date,req.`note`,emp.`employee_name` AS req_by,DATE_FORMAT(req.`date_created`,'%d %M %Y') AS date_created,dep.departement,req.id_report_status,SUM(reqd.qty*reqd.value) AS amount FROM tb_purc_req req
INNER JOIN tb_m_user usr ON usr.`id_user`=req.`id_user_created`
INNER JOIN tb_m_employee emp ON emp.`id_employee`=usr.`id_employee`
INNER JOIN tb_m_departement dep ON dep.id_departement=req.id_departement
INNER JOIN tb_purc_req_det reqd ON reqd.`id_purc_req`=req.`id_purc_req`
INNER JOIN tb_lookup_expense_type et ON et.`id_expense_type`=req.`id_expense_type`
WHERE req.id_purc_req='" & id_req & "'
GROUP BY req.`id_purc_req`"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        '
        Report.DataSource = data

        If Not data.Rows(0)("id_report_status").ToString = "6" Then
            Report.id_pre = "2"
        Else
            Report.id_pre = "1"
        End If

        'Show the report's preview. 
        Dim Tool As DevExpress.XtraReports.UI.ReportPrintTool = New DevExpress.XtraReports.UI.ReportPrintTool(Report)
        Tool.ShowPreview()
        Cursor = Cursors.Default
    End Sub

    Sub clear_all_request()
        For i As Integer = GVItemList.RowCount - 1 To 0 Step -1
            GVItemList.DeleteRow(i)
        Next
    End Sub

    Private Sub DEYearBudget_EditValueChanged(sender As Object, e As EventArgs) Handles DEYearBudget.EditValueChanged
        'reset
        If Not DEYearBudget.OldEditValue = Nothing Then
            If Not DEYearBudget.EditValue = DEYearBudget.OldEditValue And is_reload = "2" And id_req = "-1" Then
                If GVItemList.RowCount > 0 Then
                    Dim confirm As DialogResult
                    confirm = DevExpress.XtraEditors.XtraMessageBox.Show("All list will be reset, continue ?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)

                    If confirm = DialogResult.Yes Then
                        clear_all_request()
                        load_item_pil()
                        load_but()
                    Else
                        DEYearBudget.EditValue = DEYearBudget.OldEditValue
                    End If
                Else
                    load_item_pil()
                    load_but()
                End If
            End If
            '
            is_reload = "2"
        End If
    End Sub

    Private Sub BSetShipping_Click(sender As Object, e As EventArgs) Handles BSetShipping.Click
        Dim id_own_company As String = get_setup_field("id_own_company")

        For i As Integer = 0 To GVItemList.RowCount - 1
            If GVItemList.GetRowCellValue(i, "ship_destination").ToString = "" Or GVItemList.GetRowCellValue(i, "ship_address").ToString = "" Then
                GVItemList.SetRowCellValue(i, "ship_to", id_own_company)
                GVItemList.SetRowCellValue(i, "ship_destination", get_company_x(id_own_company, "1").ToString)
                GVItemList.SetRowCellValue(i, "ship_address", get_company_x(id_own_company, "3").ToString)
            End If
        Next
    End Sub

    Private Sub SLEPurcType_EditValueChanged(sender As Object, e As EventArgs) Handles SLEPurcType.EditValueChanged
        'reset
        If Not SLEPurcType.OldEditValue = Nothing Then
            If Not SLEPurcType.EditValue = SLEPurcType.OldEditValue And is_reload = "2" And id_req = "-1" Then
                If GVItemList.RowCount > 0 Then
                    Dim confirm As DialogResult
                    confirm = DevExpress.XtraEditors.XtraMessageBox.Show("All list will be reset, continue ?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)

                    If confirm = DialogResult.Yes Then
                        clear_all_request()
                        load_item_pil()
                        load_but()
                    Else
                        SLEPurcType.EditValue = SLEPurcType.OldEditValue
                    End If
                Else
                    load_item_pil()
                    load_but()
                End If
            End If
            '
            If SLEPurcType.EditValue.ToString = "1" Then 'opex
                CEStoreRequest.Checked = False
                CEStoreRequest.Visible = True
                LStoreRequest.Visible = True
            Else
                CEStoreRequest.Checked = False
                CEStoreRequest.Visible = False
                LStoreRequest.Visible = False
            End If
            is_reload = "2"
        End If
    End Sub

    Private Sub BtnAttachment_Click(sender As Object, e As EventArgs) Handles BtnAttachment.Click
        Cursor = Cursors.WaitCursor

        FormDocumentUpload.report_mark_type = rmt
        FormDocumentUpload.id_report = id_req

        MsgBox(id_report_status)
        If is_view = "1" Or Not id_report_status = "1" Then
            FormDocumentUpload.is_view = "1"
        End If
        FormDocumentUpload.ShowDialog()
        Cursor = Cursors.Default
    End Sub

    Private Sub RISLEShipTo_EditValueChanged(sender As Object, e As EventArgs) Handles RISLEShipTo.EditValueChanged
        Try
            Dim sle As DevExpress.XtraEditors.SearchLookUpEdit = CType(sender, DevExpress.XtraEditors.SearchLookUpEdit)
            '
            GVItemList.SetFocusedRowCellValue("ship_destination", sle.Properties.View.GetFocusedRowCellValue("comp_name").ToString())
            GVItemList.SetFocusedRowCellValue("ship_address", sle.Properties.View.GetFocusedRowCellValue("address_primary").ToString())
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub

    Private Sub GVItemList_ShownEditor(sender As Object, e As EventArgs) Handles GVItemList.ShownEditor
        If GVItemList.RowCount > 1 And GVItemList.FocusedRowHandle = 0 Then
            GVItemList.ActiveEditor.Properties.ReadOnly = True
        Else
            GVItemList.ActiveEditor.Properties.ReadOnly = False
        End If
    End Sub
End Class