Public Class FormBOMDesignSingle 
    Public id_is_design As String = "-1"
    Public id_prod_demand_design As String = "-1"
    Public id_design As String = FormBOM.GVDesign.GetFocusedRowCellValue("id_design").ToString
    Public id_pop_up As String = "-1"
    '
    Public id_bom_approve As String = "-1"
    '
    Public user_mat_approve As String = "-1"
    Public user_ovh_approve As String = "-1"
    '

    Private Sub FormBOMSingle_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        RICECOP.ValueChecked = Convert.ToSByte(1)
        RICECOP.ValueUnchecked = Convert.ToSByte(2)
        '
        RCOVHMain.ValueChecked = Convert.ToSByte(1)
        RCOVHMain.ValueUnchecked = Convert.ToSByte(2)
        '
        act_load()
    End Sub
    Sub act_load()
        view_term(LETerm)

        view_currency(LECurrency)

        TEUnitPriceTot.EditValue = 0.0
        TEUnitPrice.EditValue = 0.0
        TEKurs.EditValue = 1.0

        LabelProductCode.Text = FormBOM.GVDesign.GetFocusedRowCellDisplayText("design_name").ToString

        If id_pop_up = "1" Then 'edit
            Dim query As String = "SELECT "
            query += " m_p.id_design, bom.bom_note, bom.id_bom,bom.bom_date_created, bom.id_product, bom.is_default, bom.bom_name, bom.id_currency, bom.kurs, bom.id_term_production, bom.id_bom_approve, bom.user_mat_submit,user_ovh_submit"
            query += " FROM tb_bom bom"
            query += " INNER JOIN tb_m_product m_p ON m_p.id_product=bom.id_product"
            query += " WHERE m_p.id_design='" & id_design & "' AND bom.is_default='1' "
            query += " LIMIT 1"
            Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
            If data.Rows.Count > 0 Then
                TEName.Text = data.Rows(0)("bom_name").ToString
                MEBOMNote.Text = data.Rows(0)("bom_note").ToString
                Dim date_temp As Date = data.Rows(0)("bom_date_created").ToString
                DEBOM.EditValue = date_temp
                LECurrency.EditValue = Nothing
                LECurrency.ItemIndex = LECurrency.Properties.GetDataSourceRowIndex("id_currency", data.Rows(0)("id_currency").ToString)
                LETerm.EditValue = Nothing
                LETerm.ItemIndex = LETerm.Properties.GetDataSourceRowIndex("id_term_production", data.Rows(0)("id_term_production").ToString)
                TEKurs.EditValue = data.Rows(0)("kurs")

                If data.Rows(0)("user_mat_submit").ToString = "" Then
                    user_mat_approve = "-1"
                    BSubmitMat.Enabled = True
                    '
                    BAddMat.Enabled = True
                    BEditMat.Enabled = True
                    BDelMat.Enabled = True
                Else
                    user_mat_approve = data.Rows(0)("user_mat_submit").ToString
                    BSubmitMat.Enabled = False
                    '
                    BAddMat.Enabled = False
                    BEditMat.Enabled = False
                    BDelMat.Enabled = False
                End If

                If data.Rows(0)("user_ovh_submit").ToString = "" Then
                    user_ovh_approve = "-1"
                    BSubmitOVH.Enabled = True
                    '
                    BAddOVH.Enabled = True
                    BEditOVH.Enabled = True
                    BDelOVH.Enabled = True
                Else
                    user_ovh_approve = data.Rows(0)("user_ovh_submit").ToString
                    BSubmitOVH.Enabled = False
                    '
                    BAddOVH.Enabled = False
                    BEditOVH.Enabled = False
                    BDelOVH.Enabled = False
                End If

                If Not data.Rows(0)("user_ovh_submit").ToString = "" And Not data.Rows(0)("user_mat_submit").ToString = "" Then
                    BMark.Enabled = True
                Else
                    BMark.Enabled = False
                End If

                id_bom_approve = data.Rows(0)("id_bom_approve").ToString
            End If
            BDuplicate.Visible = True
            BDupDesign.Visible = True
        Else
            DEBOM.EditValue = Now()
            BDuplicate.Visible = False
            BDupDesign.Visible = False
        End If

        view_bom_det()
        show_but_mat()
        view_bom_ovh()
        show_but_ovh()
        '
        allow_status_po()
    End Sub
    Sub allow_status_po()
        Dim query As String = "SELECT id_prod_order FROM tb_prod_order po
                                INNER JOIN `tb_prod_demand_design` pdd ON pdd.`id_prod_demand_design`=po.`id_prod_demand_design`
                                WHERE (po.`id_report_status`!= 1 AND po.`id_report_status`!= 5)
                                AND pdd.id_design='" & id_design & "'"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        If data.Rows.Count > 0 Then
            'sudah ada approved
            LPOApproved.Text = "PO processed : " & data.Rows.Count.ToString
            'hide all button
            BDuplicate.Visible = False
            BSave.Visible = False
            '
            BAddOVH.Visible = False
            BEditOVH.Visible = False
            BDelOVH.Visible = False
            '
            BAddMat.Visible = False
            BEditMat.Visible = False
            BDelMat.Visible = False
        Else
            'hide all button
            BDuplicate.Visible = True
            BSave.Visible = True
            '
            BAddOVH.Visible = True
            BEditOVH.Visible = True
            BDelOVH.Visible = True
            '
            BAddMat.Visible = True
            BEditMat.Visible = True
            BDelMat.Visible = True
        End If
    End Sub
    Private Sub view_report_status(ByVal lookup As DevExpress.XtraEditors.LookUpEdit)
        Dim query As String = "SELECT id_report_status,report_status FROM tb_lookup_report_status"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")

        lookup.Properties.DataSource = data

        lookup.Properties.DisplayMember = "report_status"
        lookup.Properties.ValueMember = "id_report_status"
        lookup.ItemIndex = 0
    End Sub
    Sub view_bom_det()
        Try
            Dim query As String
            query = "CALL view_bom_design_list(" & id_prod_demand_design & ",2)"

            Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
            GCBomDetMat.DataSource = data
            GVBomDetMat.BestFitColumns()
            calculate_unit_price()

        Catch ex As Exception
            errorConnection()
        End Try
    End Sub
    Sub show_but_mat()
        If GVBomDetMat.RowCount < 1 Then
            BDelMat.Visible = False
            BEditMat.Visible = False
        Else
            BDelMat.Visible = True
            BEditMat.Visible = True
        End If
        calculate_unit_price()
    End Sub
    Private Sub view_currency(ByVal lookup As DevExpress.XtraEditors.LookUpEdit)
        Dim query As String = "SELECT id_currency,currency FROM tb_lookup_currency"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")

        lookup.Properties.DataSource = data

        lookup.Properties.DisplayMember = "currency"
        lookup.Properties.ValueMember = "id_currency"
        lookup.ItemIndex = 0
    End Sub
    Private Sub BAddMat_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BAddMat.Click
        '
        FormBOMSingleMat.id_pop_up = "1"
        FormBOMSingleMat.ShowDialog()
    End Sub
    Private Sub view_term(ByVal lookup As DevExpress.XtraEditors.LookUpEdit)
        Dim query As String = "SELECT id_term_production,term_production FROM tb_lookup_term_production"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")

        lookup.Properties.DataSource = data

        lookup.Properties.DisplayMember = "term_production"
        lookup.Properties.ValueMember = "id_term_production"
        lookup.ItemIndex = 0
    End Sub

    Private Sub BSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BSave.Click
        If TEName.Text = "" Then
            stopCustom("Please insert bom name.")
        Else
            Dim bom_note, bom_name, id_term_production, query, unit_price, kurs, id_currency As String

            ValidateChildren()
            bom_name = TEName.Text
            bom_note = MEBOMNote.Text
            id_term_production = LETerm.EditValue
            unit_price = decimalSQL(TEUnitPrice.EditValue.ToString)
            kurs = decimalSQL(TEKurs.EditValue.ToString)
            id_currency = LECurrency.EditValue.ToString

            If id_pop_up = "-1" Then 'new
                'update default bom
                query = "UPDATE "
                query += " tb_bom bom "
                query += " INNER JOIN tb_m_product m_p ON m_p.id_product=bom.id_product"
                query += " SET bom.is_default = 2"
                query += " WHERE m_p.id_design='" & id_design & "'"
                execute_non_query(query, True, "", "", "", "")
                'create bom report
                query = "INSERT INTO tb_bom_approve(id_report_status) VALUES('1'); SELECT LAST_INSERT_ID();"
                id_bom_approve = execute_query(query, 0, True, "", "", "", "")
                'insert bom default
                query = "INSERT INTO tb_bom(id_product,id_term_production,bom_name,id_currency,kurs,bom_unit_price,bom_note,bom_date_created,is_default,id_bom_approve,id_user_last_update,bom_date_updated)"
                query += " SELECT "
                query += " id_product"
                query += " ,'" & id_term_production & "' AS id_term_production"
                query += " ,'" & bom_name & "' AS bom_name"
                query += " ,'" & id_currency & "' AS id_currency"
                query += " ,'" & kurs & "' AS kurs"
                query += " ,'" & unit_price & "' AS bom_unit_price"
                query += " ,'" & bom_note & "' AS bom_note"
                query += " ,NOW() AS bom_date_created"
                query += " ,'1' AS is_default"
                query += " ,'" & id_bom_approve & "'"
                query += " ,'" & id_user & "' AS id_user_last_update"
                query += " ,NOW() AS bom_date_updated"
                query += " FROM tb_prod_demand_product"
                query += " WHERE id_prod_demand_design='" & FormBOM.GVDesign.GetFocusedRowCellValue("id_prod_demand_design").ToString & "'"
                execute_non_query(query, True, "", "", "", "")
                'detail mat
                For i As Integer = 0 To GVBomDetMat.RowCount - 1
                    'MsgBox(decimalSQL((GVBomDetMat.GetRowCellValue(i, "qty") / TEQtyPD.EditValue).ToString))
                    query = "INSERT INTO tb_bom_det(id_bom,id_component_category,id_mat_det_price,bom_price,kurs,component_qty,is_cost,is_addcost)"
                    query += " SELECT "
                    query += " id_bom"
                    query += " ,'1' AS id_component_category"
                    query += " ,'" & GVBomDetMat.GetRowCellValue(i, "id_component_price").ToString & "' AS id_mat_det_price"
                    query += " ,'" & decimalSQL(GVBomDetMat.GetRowCellValue(i, "price").ToString) & "' AS bom_price"
                    query += " ,'" & decimalSQL(GVBomDetMat.GetRowCellValue(i, "kurs").ToString) & "' AS kurs"
                    query += " ,'" & decimalSQL((GVBomDetMat.GetRowCellValue(i, "qty") / TEQtyPD.EditValue).ToString) & "' AS component_qty"
                    query += " ,'" & GVBomDetMat.GetRowCellValue(i, "is_cost").ToString & "' AS is_cost"
                    query += " ,'" & GVBomDetMat.GetRowCellValue(i, "is_addcost").ToString & "' AS is_addcost"
                    query += " FROM tb_bom bom"
                    query += " INNER JOIN tb_m_product m_p ON m_p.id_product = bom.id_product"
                    query += " WHERE m_p.id_design='" & id_design & "' AND bom.is_default='1'"
                    execute_non_query(query, True, "", "", "", "")
                Next
                'detail ovh
                For i As Integer = 0 To GVBomDetOvh.RowCount - 1
                    'MsgBox(decimalSQL((GVBomDetOvh.GetRowCellValue(i, "qty") / TEQtyPD.EditValue).ToString))
                    query = "INSERT INTO tb_bom_det(id_bom,id_component_category,id_ovh_price,bom_price,kurs,component_qty,is_ovh_main)"
                    query += " SELECT "
                    query += " id_bom"
                    query += " ,'2' AS id_component_category"
                    query += " ,'" & GVBomDetOvh.GetRowCellValue(i, "id_component_price").ToString & "' AS id_ovh_price"
                    query += " ,'" & decimalSQL(GVBomDetOvh.GetRowCellValue(i, "price").ToString) & "' AS bom_price"
                    query += " ,'" & decimalSQL(GVBomDetOvh.GetRowCellValue(i, "kurs").ToString) & "' AS kurs"
                    query += " ,'" & decimalSQL((GVBomDetOvh.GetRowCellValue(i, "qty") / TEQtyPD.EditValue).ToString) & "' AS component_qty"
                    query += " ,'" & GVBomDetOvh.GetRowCellValue(i, "is_ovh_main").ToString & "' AS is_ovh_main"
                    query += " FROM tb_bom bom"
                    query += " INNER JOIN tb_m_product m_p ON m_p.id_product = bom.id_product"
                    query += " WHERE m_p.id_design='" & id_design & "' AND bom.is_default='1'"
                    execute_non_query(query, True, "", "", "", "")
                Next
                infoCustom("BOM created")
                id_pop_up = "1"
                id_prod_demand_design = FormBOM.GVDesign.GetFocusedRowCellValue("id_prod_demand_design").ToString
                act_load()
            Else 'edit
                'update default bom
                query = "UPDATE "
                query += " tb_bom bom "
                query += " INNER JOIN tb_m_product m_p ON m_p.id_product = bom.id_product"
                query += " SET bom.id_term_production = 2"
                query += " ,id_term_production = '" & id_term_production & "'"
                query += " ,bom_name='" & bom_name & "'"
                query += " ,id_currency='" & id_currency & "'"
                query += " ,kurs='" & kurs & "'"
                query += " ,bom_unit_price='" & unit_price & "'"
                query += " ,bom_note='" & bom_note & "'"
                query += " ,bom_date_updated=NOW()"
                query += " ,id_user_last_update='" & id_user & "'"
                query += " WHERE m_p.id_design='" & id_design & "' AND bom.is_default='1'"
                execute_non_query(query, True, "", "", "", "")
                'delete detail
                query = "DELETE tb_bom_det FROM "
                query += " tb_bom_det "
                query += " INNER JOIN tb_bom ON tb_bom.id_bom=tb_bom_det.id_bom"
                query += " INNER JOIN tb_m_product ON tb_m_product.id_product=tb_bom.id_product"
                query += " WHERE tb_m_product.id_design='" & id_design & "' AND tb_bom.is_default='1'"
                execute_non_query(query, True, "", "", "", "")
                'detail mat
                For i As Integer = 0 To GVBomDetMat.RowCount - 1
                    query = "INSERT INTO tb_bom_det(id_bom,id_component_category,id_mat_det_price,bom_price,kurs,component_qty,is_cost,is_addcost)"
                    query += " SELECT "
                    query += " id_bom"
                    query += " ,'1' AS id_component_category"
                    query += " ,'" & GVBomDetMat.GetRowCellValue(i, "id_component_price").ToString & "' AS id_mat_det_price"
                    query += " ,'" & decimalSQL(GVBomDetMat.GetRowCellValue(i, "price").ToString) & "' AS bom_price"
                    query += " ,'" & decimalSQL(GVBomDetMat.GetRowCellValue(i, "kurs").ToString) & "' AS kurs"
                    query += " ,'" & decimalSQL((GVBomDetMat.GetRowCellValue(i, "qty") / TEQtyPD.EditValue).ToString) & "' AS component_qty"
                    query += " ,'" & GVBomDetMat.GetRowCellValue(i, "is_cost").ToString & "' AS is_cost"
                    query += " ,'" & GVBomDetMat.GetRowCellValue(i, "is_addcost").ToString & "' AS is_addcost"
                    query += " FROM tb_bom bom"
                    query += " INNER JOIN tb_m_product m_p ON m_p.id_product = bom.id_product"
                    query += " WHERE m_p.id_design='" & id_design & "' AND bom.is_default='1'"
                    execute_non_query(query, True, "", "", "", "")
                Next
                'detail ovh
                For i As Integer = 0 To GVBomDetOvh.RowCount - 1
                    query = "INSERT INTO tb_bom_det(id_bom,id_component_category,id_ovh_price,bom_price,kurs,component_qty,is_ovh_main)"
                    query += " SELECT "
                    query += " id_bom"
                    query += " ,'2' AS id_component_category"
                    query += " ,'" & GVBomDetOvh.GetRowCellValue(i, "id_component_price").ToString & "' AS id_ovh_price"
                    query += " ,'" & decimalSQL(GVBomDetOvh.GetRowCellValue(i, "price").ToString) & "' AS bom_price"
                    query += " ,'" & decimalSQL(GVBomDetOvh.GetRowCellValue(i, "kurs").ToString) & "' AS kurs"
                    query += " ,'" & decimalSQL((GVBomDetOvh.GetRowCellValue(i, "qty") / TEQtyPD.EditValue).ToString) & "' AS component_qty"
                    query += " ,'" & GVBomDetOvh.GetRowCellValue(i, "is_ovh_main").ToString & "' AS is_ovh_main"
                    query += " FROM tb_bom bom"
                    query += " INNER JOIN tb_m_product m_p ON m_p.id_product = bom.id_product"
                    query += " WHERE m_p.id_design='" & id_design & "' AND bom.is_default='1'"
                    execute_non_query(query, True, "", "", "", "")
                Next
                infoCustom("BOM updated")
                act_load()
            End If
            'sync the F.G.PO with same PD
            sync_po(id_prod_demand_design)
        End If
    End Sub

    Sub sync_po(ByVal id_pd As String)
        'po first
        Dim query As String = "SELECT id_prod_order FROM tb_prod_order WHERE id_report_status!='5' AND id_prod_demand_design='" & id_pd & "'"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")

        For i As Integer = 0 To data.Rows.Count - 1
            Dim id_po As String = data.Rows(i)("id_prod_order").ToString
            'update
            Dim query_upd As String = "UPDATE tb_prod_order_wo wo
                                        INNER JOIN 
                                        (
	                                        SELECT bom.id_bom,bomd.id_ovh_price,ovh.overhead,ovhp.id_comp_contact,bomd.kurs,ovhp.id_currency,bomd.is_ovh_main,SUM(bomd.bom_price*pod.prod_order_qty) AS amount FROM tb_prod_order_det pod
	                                        INNER JOIN tb_prod_demand_product pdp ON pdp.`id_prod_demand_product`=pod.`id_prod_demand_product`
	                                        INNER JOIN tb_bom bom ON bom.`id_product`=pdp.`id_product` AND bom.is_default='1'
	                                        INNER JOIN tb_bom_det bomd ON bomd.`id_bom`=bom.`id_bom` 
	                                        INNER JOIN tb_m_ovh_price ovhp ON ovhp.id_ovh_price=bomd.`id_ovh_price`
	                                        INNER JOIN tb_m_ovh ovh ON ovh.id_ovh=ovhp.`id_ovh`
	                                        WHERE pod.`id_prod_order`='" & id_po & "' AND bomd.`id_component_category`='2'
	                                        GROUP BY bomd.id_ovh_price
                                        )bom ON bom.id_ovh_price=wo.`id_ovh_price`
                                        SET wo.id_comp_contact_ship_to=bom.id_comp_contact,wo.id_currency=bom.id_currency,wo.prod_order_wo_kurs=bom.`kurs`,wo.is_main_vendor=bom.is_ovh_main,wo.prod_order_wo_amount=bom.amount
                                        WHERE wo.`id_prod_order`='" & id_po & "' AND NOT ISNULL(bom.`id_bom`);"
            execute_non_query(query_upd, True, "", "", "", "")
            query_upd = "Update tb_prod_order_wo_det wod
                                        INNER JOIN tb_prod_order_wo wo ON wod.id_prod_order_wo=wo.`id_prod_order_wo`
                                        INNER JOIN
                                        (
	                                        SELECT bom.id_bom,bomd.id_ovh_price,ovh.overhead,ovhp.id_comp_contact,bomd.kurs,ovhp.id_currency,bomd.is_ovh_main,bomd.bom_price AS price FROM tb_prod_order_det pod
	                                        INNER JOIN tb_prod_demand_product pdp ON pdp.`id_prod_demand_product`=pod.`id_prod_demand_product`
	                                        INNER JOIN tb_bom bom ON bom.`id_product`=pdp.`id_product` AND bom.is_default='1'
	                                        INNER JOIN tb_bom_det bomd ON bomd.`id_bom`=bom.`id_bom` 
	                                        INNER JOIN tb_m_ovh_price ovhp ON ovhp.id_ovh_price=bomd.`id_ovh_price`
	                                        INNER JOIN tb_m_ovh ovh ON ovh.id_ovh=ovhp.`id_ovh`
	                                        WHERE pod.`id_prod_order`='" & id_po & "' AND bomd.`id_component_category`='2'
	                                        GROUP BY bomd.id_ovh_price
                                        )bom ON bom.id_ovh_price=wo.`id_ovh_price`
                                        SET wod.prod_order_wo_det_price=bom.price
                                        WHERE wo.`id_prod_order`='" & id_po & "' AND NOT ISNULL(bom.`id_bom`);"
            execute_non_query(query_upd, True, "", "", "", "")
            'insert
            Dim query_ins As String = "SELECT po.id_report_status,bom.id_bom,bomd.id_ovh_price,ovh.overhead,ovhp.id_comp_contact,bomd.kurs,ovhp.id_currency,bomd.is_ovh_main,pod.prod_order_qty,bomd.bom_price,SUM(bomd.bom_price*pod.prod_order_qty) AS amount,
                                        wo.`id_prod_order_wo`,wo.`prod_order_wo_kurs`,wo.`id_currency`,wo.`is_main_vendor`,wo.`prod_order_wo_amount` FROM tb_prod_order_det pod
                                        INNER JOIN tb_prod_order po ON po.id_prod_order=pod.id_prod_order
                                        INNER JOIN tb_prod_demand_product pdp ON pdp.`id_prod_demand_product`=pod.`id_prod_demand_product`
                                        INNER JOIN tb_bom bom ON bom.`id_product`=pdp.`id_product` AND bom.is_default='1'
                                        INNER JOIN tb_bom_det bomd ON bomd.`id_bom`=bom.`id_bom` 
                                        INNER JOIN tb_m_ovh_price ovhp ON ovhp.id_ovh_price=bomd.`id_ovh_price`
                                        INNER JOIN tb_m_ovh ovh ON ovh.id_ovh=ovhp.`id_ovh`
                                        LEFT JOIN tb_prod_order_wo wo ON bomd.id_ovh_price=wo.`id_ovh_price` AND wo.`id_prod_order`=pod.id_prod_order
                                        WHERE pod.`id_prod_order`='" & id_po & "' AND bomd.`id_component_category`='2' AND ISNULL(wo.`id_prod_order_wo`)
                                        GROUP BY bomd.id_ovh_price"
            Dim data_ins As DataTable = execute_query(query_ins, -1, True, "", "", "", "")
            For j As Integer = 0 To data_ins.Rows.Count - 1
                Dim wo_number As String = header_number_prod(2)
                Dim query_ins_wo As String = "INSERT INTO tb_prod_order_wo(id_prod_order,prod_order_wo_number,id_ovh_price,id_comp_contact_ship_to,id_payment,prod_order_wo_del_date,prod_order_wo_date,prod_order_wo_amount,id_currency,prod_order_wo_kurs,is_main_vendor,id_report_status)
                                                VALUES('" & id_po & "','" & wo_number & "','" & data_ins.Rows(j)("id_ovh_price").ToString & "','" & data_ins.Rows(j)("id_comp_contact").ToString & "','1',NOW(),NOW(),'" & decimalSQL(data_ins.Rows(j)("amount").ToString) & "','" & data_ins.Rows(j)("id_currency").ToString & "','" & decimalSQL(data_ins.Rows(j)("kurs").ToString) & "','" & data_ins.Rows(j)("is_ovh_main").ToString & "','" & data_ins.Rows(j)("id_report_status").ToString & "'); SELECT LAST_INSERT_ID()"
                Dim id_wo_new As String = execute_query(query_ins_wo, 0, True, "", "", "", "")
                increase_inc_prod("2")
                Dim query_ins_wo_det As String = "INSERT INTO tb_prod_order_wo_det(id_prod_order_wo,id_prod_order_det,prod_order_wo_det_price,prod_order_wo_det_qty)
                                                    SELECT '" & id_wo_new & "' AS id_prod_order_wo,id_prod_order_det,'" & decimalSQL(data_ins.Rows(j)("bom_price").ToString) & "' AS price,pod.prod_order_qty 
                                                    FROM tb_prod_order_det pod
                                                    WHERE pod.id_prod_order='" & id_po & "'"
                execute_non_query(query_ins_wo_det, True, "", "", "", "")
            Next
            'delete
            Dim query_del As String = "DELETE wo FROM tb_prod_order_wo wo
                                        LEFT JOIN 
                                        (
	                                        SELECT bom.id_bom,bomd.id_ovh_price,ovh.overhead,ovhp.id_comp_contact,bomd.kurs,ovhp.id_currency,bomd.is_ovh_main,SUM(bomd.bom_price*pod.prod_order_qty) AS amount FROM tb_prod_order_det pod
	                                        INNER JOIN tb_prod_demand_product pdp ON pdp.`id_prod_demand_product`=pod.`id_prod_demand_product`
	                                        INNER JOIN tb_bom bom ON bom.`id_product`=pdp.`id_product` AND bom.is_default='1'
	                                        INNER JOIN tb_bom_det bomd ON bomd.`id_bom`=bom.`id_bom` 
	                                        INNER JOIN tb_m_ovh_price ovhp ON ovhp.id_ovh_price=bomd.`id_ovh_price`
	                                        INNER JOIN tb_m_ovh ovh ON ovh.id_ovh=ovhp.`id_ovh`
	                                        WHERE pod.`id_prod_order`='" & id_po & "' AND bomd.`id_component_category`='2'
	                                        GROUP BY bomd.id_ovh_price
                                        )bom ON bom.id_ovh_price=wo.`id_ovh_price`
                                        WHERE wo.`id_prod_order`='" & id_po & "' AND ISNULL(bom.`id_bom`)"
            execute_non_query(query_del, True, "", "", "", "")
        Next
    End Sub

    Private Sub FormBOMSingle_FormClosed(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles MyBase.FormClosed
        '
        If Not id_bom_approve = "-1" Then
            Dim query_upd As String = "UPDATE tb_bom SET `bom_last_updated`=NOW() WHERE tb_bom.`id_bom_approve`='" & id_bom_approve & "' "
            execute_non_query(query_upd, True, "", "", "", "")
        End If
        Dispose()
    End Sub

    Private Sub TEName_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TEName.Validating
        EP_TE_cant_blank(EPBOM, TEName)
    End Sub

    Private Sub BEditMat_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BEditMat.Click
        '
        FormBOMSingleMat.id_pop_up = "1"
        FormBOMSingleMat.id_mat_det = GVBomDetMat.GetFocusedRowCellDisplayText("id_component").ToString
        FormBOMSingleMat.ShowDialog()
    End Sub

    Private Sub BDelMat_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BDelMat.Click
        Dim confirm As DialogResult
        confirm = DevExpress.XtraEditors.XtraMessageBox.Show("Are you sure want to delete this material on the list?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)

        If confirm = Windows.Forms.DialogResult.Yes Then
            Cursor = Cursors.WaitCursor
            GVBomDetMat.DeleteSelectedRows()
            show_but_mat()
            Cursor = Cursors.Default
        End If
    End Sub

    Sub view_bom_ovh()
        Try
            Dim query As String
            query = "CALL view_bom_design_list(" & id_prod_demand_design & ",3)"

            Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
            GCBomDetOvh.DataSource = data
            GVBomDetOvh.BestFitColumns()
            calculate_unit_price()
        Catch ex As Exception
            errorConnection()
        End Try
    End Sub
    Sub show_but_ovh()
        If GVBomDetOvh.RowCount < 1 Then
            BDelOVH.Visible = False
            BEditOVH.Visible = False
        Else
            BDelOVH.Visible = True
            BEditOVH.Visible = True
        End If
        calculate_unit_price()
    End Sub

    Private Sub BAddOVH_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BAddOVH.Click
        '
        FormBOMSingleOvh.id_pop_up = "1"
        FormBOMSingleOvh.ShowDialog()
    End Sub

    Private Sub BEditOVH_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BEditOVH.Click
        'check the payment first
        Dim query As String = "SELECT * FROM tb_pr_prod_order pr
                                INNER JOIN tb_prod_order_wo wo ON wo.id_prod_order_wo=pr.id_prod_order_wo
                                INNER JOIN tb_prod_order po ON po.id_prod_order=wo.id_prod_order
                                WHERE pr.id_report_status!='5' AND po.id_report_status!='5' AND po.id_prod_demand_design='" & id_prod_demand_design & "' AND wo.id_ovh_price='" & GVBomDetOvh.GetFocusedRowCellValue("id_component_price").ToString & "'"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")

        If data.Rows.Count > 0 Then
            stopCustom("Payment already created for this item. Please cancel it first.")
        Else
            FormBOMSingleOvh.id_pop_up = "1"
            FormBOMSingleOvh.TEQty.EditValue = GVBomDetOvh.GetFocusedRowCellValue("qty")
            FormBOMSingleOvh.id_bom_det = GVBomDetOvh.GetFocusedRowCellValue("id_bom_det").ToString
            FormBOMSingleOvh.id_ovh = GVBomDetOvh.GetFocusedRowCellValue("id_component").ToString
            FormBOMSingleOvh.ShowDialog()
        End If
    End Sub

    Private Sub BDelOVH_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BDelOVH.Click
        Dim query As String = "SELECT * FROM tb_pr_prod_order pr
                                INNER JOIN tb_prod_order_wo wo ON wo.id_prod_order_wo=pr.id_prod_order_wo
                                INNER JOIN tb_prod_order po ON po.id_prod_order=wo.id_prod_order
                                WHERE pr.id_report_status!='5' AND po.id_report_status!='5' AND po.id_prod_demand_design='" & id_prod_demand_design & "' AND wo.id_ovh_price='" & GVBomDetOvh.GetFocusedRowCellValue("id_component_price").ToString & "'"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")

        If data.Rows.Count > 0 Then
            stopCustom("Payment already created for this item. Please cancel it first.")
        Else
            Dim confirm As DialogResult
            confirm = DevExpress.XtraEditors.XtraMessageBox.Show("Are you sure want to delete this component?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)

            If confirm = Windows.Forms.DialogResult.Yes Then
                Cursor = Cursors.WaitCursor
                GVBomDetOvh.DeleteSelectedRows()
                Cursor = Cursors.Default
            End If
        End If
    End Sub

    Sub calculate_unit_price()
        Dim mat, ovh, total As Decimal
        total = 0.0
        Try
            mat = GVBomDetMat.Columns("total_cost").SummaryItem.SummaryValue
            ovh = GVBomDetOvh.Columns("total").SummaryItem.SummaryValue
        Catch ex As Exception
        End Try

        total = mat + ovh

        TEUnitPriceTot.EditValue = total
        TEUnitPrice.EditValue = total / TEQtyPD.EditValue

    End Sub

    Private Sub BMark_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

        FormReportMark.report_mark_type = "8"
        FormReportMark.ShowDialog()
    End Sub

    Private Sub Bprint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Bprint.Click
        ReportBOM.qty_order = TEQtyPD.Text
        ReportBOM.id_pd = id_prod_demand_design
        ReportBOM.product_name = FormBOM.GVDesign.GetFocusedRowCellDisplayText("design_name").ToString
        ReportBOM.bom_name = TEName.Text
        Dim date_temp As Date
        date_temp = DEBOM.EditValue
        ReportBOM.bom_date = date_temp.ToString("dd MMM yyyy")
        ReportBOM.bom_term = LETerm.Text

        Dim Report As New ReportBOM()
        ' Show the report's preview. 
        Dim Tool As DevExpress.XtraReports.UI.ReportPrintTool = New DevExpress.XtraReports.UI.ReportPrintTool(Report)
        Tool.ShowPreview()
    End Sub

    Private Sub TEName_EditValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TEName.EditValueChanged
        LabelPrintedName.Text = TEName.Text
    End Sub

    Private Sub BCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BCancel.Click
        Close()
    End Sub

    Private Sub BSubmitOVH_Click(sender As Object, e As EventArgs) Handles BSubmitOVH.Click
        '
        Dim confirm As DialogResult
        Dim query As String
        confirm = DevExpress.XtraEditors.XtraMessageBox.Show("Are you sure want to submit this list?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)

        If confirm = Windows.Forms.DialogResult.Yes Then
            Cursor = Cursors.WaitCursor
            Try
                Dim bom_where As String = ""
                If id_bom_approve = "" Then
                    bom_where = "ISNULL(bom.id_bom_approve)"
                Else
                    bom_where = "bom.id_bom_approve='" + id_bom_approve + "'"
                End If

                query = String.Format("UPDATE tb_bom bom INNER JOIN tb_m_product prod ON prod.id_product=bom.id_product SET bom.user_ovh_submit='{0}',bom.bom_unit_price='{3}' WHERE {1} AND prod.id_design='{2}'", id_user, bom_where, id_design, decimalSQL(TEUnitPrice.EditValue.ToString))
                execute_non_query(query, True, "", "", "", "")

                act_load()
            Catch ex As Exception
                DevExpress.XtraEditors.XtraMessageBox.Show(ex.ToString, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
            Cursor = Cursors.Default
        End If
    End Sub

    Private Sub BSubmitMat_Click(sender As Object, e As EventArgs) Handles BSubmitMat.Click
        Dim confirm As DialogResult
        Dim query As String
        confirm = DevExpress.XtraEditors.XtraMessageBox.Show("Are you sure want to submit this list?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)

        If confirm = Windows.Forms.DialogResult.Yes Then
            Cursor = Cursors.WaitCursor
            Try
                Dim bom_where As String = ""
                If id_bom_approve = "" Then
                    bom_where = "ISNULL(bom.id_bom_approve)"
                Else
                    bom_where = "bom.id_bom_approve='" + id_bom_approve + "'"
                End If

                query = String.Format("UPDATE tb_bom bom INNER JOIN tb_m_product prod ON prod.id_product=bom.id_product SET bom.user_mat_submit='{0}',bom.bom_unit_price='{3}' WHERE {1} AND prod.id_design='{2}'", id_user, bom_where, id_design, decimalSQL(TEUnitPrice.EditValue.ToString))
                execute_non_query(query, True, "", "", "", "")
                act_load()
            Catch ex As Exception
                DevExpress.XtraEditors.XtraMessageBox.Show(ex.ToString, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
            Cursor = Cursors.Default
        End If
    End Sub

    Private Sub BMark_Click_1(sender As Object, e As EventArgs) Handles BMark.Click
        'FormReportMark.report_mark_type = "8"
        FormReportMark.form_origin = "FormBomDesignSingle"
        FormReportMark.id_report = id_bom_approve
        FormReportMark.report_mark_type = "79"
        FormReportMark.ShowDialog()
    End Sub

    Private Sub BDuplicate_Click(sender As Object, e As EventArgs) Handles BDuplicate.Click
        Dim confirm As DialogResult
        confirm = DevExpress.XtraEditors.XtraMessageBox.Show("Are you sure want to duplicate this BOM?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)

        If confirm = Windows.Forms.DialogResult.Yes Then
            Cursor = Cursors.WaitCursor
            Try
                act_dupe()
                '
                act_load()
            Catch ex As Exception
                DevExpress.XtraEditors.XtraMessageBox.Show(ex.ToString, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
            Cursor = Cursors.Default
        End If
    End Sub
    Sub act_dupe()
        Dim query As String = ""
        Dim id_bom_approve_new As String = ""
        'new id_bom_approve
        query = "INSERT INTO tb_bom_approve(id_report_status) VALUES(1); SELECT LAST_INSERT_ID();"
        id_bom_approve_new = execute_query(query, 0, True, "", "", "", "")
        'update default=2 (replace default)
        'update default bom
        query = "UPDATE "
        query += " tb_bom bom "
        query += " INNER JOIN tb_m_product m_p ON m_p.id_product = bom.id_product"
        query += " SET bom.is_default = 2"
        query += " WHERE m_p.id_design='" & id_design & "'"
        execute_non_query(query, True, "", "", "", "")
        'INSERT BOM
        query = "INSERT INTO tb_bom(id_product,id_term_production,bom_name,id_currency,kurs,bom_unit_price,bom_date_created,bom_date_updated,id_user_last_update,id_bom_approve,id_report_status,is_default,bom_note) "
        query += " SELECT bom.id_product,bom.id_term_production,bom.bom_name,bom.id_currency,bom.kurs,bom.bom_unit_price,DATE(NOW()),NOW(),'" + id_user + "','" + id_bom_approve_new + "','1',1,bom.bom_note "
        query += " FROM tb_bom bom"
        query += " INNER JOIN tb_m_product prod ON prod.id_product=bom.id_product"
        query += " WHERE bom.id_bom_approve='" + id_bom_approve + "' AND prod.id_design='" + id_design + "'"
        execute_non_query(query, True, "", "", "", "")
        'Insert detail
        query = "INSERT INTO tb_bom_det(id_bom,id_component_category,id_mat_det_price,id_ovh_price,id_product_price,kurs,bom_price,component_qty,is_cost,is_addcost,is_ovh_main) "
        query += " SELECT bom_b.id_bom_new,bomd.id_component_category,bomd.id_mat_det_price,bomd.id_ovh_price,bomd.id_product_price,bomd.kurs,bomd.bom_price,bomd.component_qty,bomd.is_cost,bomd.is_addcost,bomd.is_ovh_main FROM tb_bom_det bomd"
        query += " INNER JOIN tb_bom bom On bom.id_bom=bomd.id_bom"
        query += " INNER JOIN tb_m_product prod ON prod.id_product=bom.id_product"
        query += " INNER JOIN"
        query += " ( SELECT id_bom AS id_bom_new FROM tb_bom WHERE id_bom_approve='" + id_bom_approve_new + "' ) bom_b"
        query += " WHERE bom.id_bom=(SELECT id_bom FROM tb_bom WHERE id_bom_approve='" + id_bom_approve + "' LIMIT 1)"
        execute_non_query(query, True, "", "", "", "")
        infoCustom("BOM duplicate success.")
        '
        id_bom_approve = id_bom_approve_new
    End Sub

    Private Sub BDupDesign_Click(sender As Object, e As EventArgs) Handles BDupDesign.Click
        FormBOMDuplicateDesign.ShowDialog()
    End Sub
End Class