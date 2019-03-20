Public Class FormPopUpContact
    Public id_pop_up As String = "-1"
    Public id_comp_contact As String = "-1"
    Public id_cat As String = "-1"
    Public id_departement As String = "-1"
    Public id_so_type As String = "-1"
    Public comp_number As String = "-1"
    Public is_admin As String = "-1" 'can add or edit contact
    Public is_must_active As String = "-1"
    'id use of pop up
    'awb = awbill
    '1 = comp_to sample purchase det
    '2 = ship_to sample purchase det
    '3 = comp_to sample receive det
    '4 = comp_form sample packing list
    '5 = comp_to sample packing list
    '6 = PR 
    '7 = Return Out Supplier
    '8 = Return In Supplier
    '9 = PL Delivery Sample Contact From
    '10 = PL Delivery Sample Contact To
    '11 = Sample Requisition Contact From
    '12 = Sample Requisition Contact To
    '13 = Sample Plan To
    '14 = Material Purchasing To
    '15 = Material Purchasinh Ship To
    '16 = Sample Return From
    '17 = Sample Returm To
    '18 = Generate Material Purchasing Ship To (From PD)
    '19 = From PL Sample Del
    'test conflict

    Private Sub FormPopUpContact_FormClosing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        Dispose()
    End Sub

    Private Sub FormPopUpContact_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        view_company()
        If id_comp_contact <> "-1" Then
            Dim id_comp As String
            id_comp = get_id_company(id_comp_contact)
            GVCompany.FocusedRowHandle = find_row(GVCompany, "id_comp", id_comp)
            GVCompanyContactList.FocusedRowHandle = find_row(GVCompanyContactList, "id_comp_contact", id_comp_contact)
        End If

        'auto filter
        If id_pop_up = "25" Or id_pop_up = "30" Or id_pop_up = "33" Then ' rec QC
            Dim id_order As String = "-1"
            Dim type As String = "1"

            If id_pop_up = "25" Then
                id_order = FormProductionRecDet.id_order
            ElseIf id_pop_up = "30" Then
                id_order = FormProductionRetOutSingle.id_prod_order
                type = FormProductionRetOutSingle.LERetType.EditValue.ToString
            Else
                id_order = FormProductionRetInSingle.id_prod_order
                type = FormProductionRetInSingle.LERetType.EditValue.ToString
            End If
            Dim query_filter As String = ""
            query_filter += "SELECT comp.comp_number from tb_prod_order_wo wo "
            query_filter += "inner join tb_m_ovh_price op ON wo.id_ovh_price = op.id_ovh_price "
            query_filter += "inner join tb_m_comp_contact ctc ON ctc.id_comp_contact = op.id_comp_contact "
            query_filter += "inner join tb_m_comp comp ON ctc.id_comp = comp.id_comp "
            query_filter += "where wo.id_prod_order = '" + id_order + "' "
            Dim data_filter As DataTable = execute_query(query_filter, -1, True, "", "", "", "")

            Dim filter_str As String = ""
            Dim filter_i As Integer = 0
            If data_filter.Rows.Count > 0 Then
                For k As Integer = 0 To data_filter.Rows.Count - 1
                    If filter_i > 0 Then
                        filter_str += "OR "
                    End If
                    filter_str += "[comp_number]='" + data_filter.Rows(k)("comp_number").ToString + "' "
                    filter_i += 1
                Next
            End If
            '

            If id_pop_up = "30" And type = "2" Then
                GVCompany.ActiveFilterString = ""
            ElseIf id_pop_up = "33" And type = "2" Then
                GVCompany.ActiveFilterString = ""
            Else
                GVCompany.ActiveFilterString = filter_str
            End If

        End If
    End Sub

    Private Sub FormPopUpContact_Shown(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Shown
        GVCompany.ShowFindPanel()
        GVCompany.ShowFindPanel()
    End Sub

    Sub view_contact(ByVal id_company As String)
        If id_company = "" Or id_company < "0" Then
            id_company = "-1"
        End If

        Dim data As DataTable = execute_query(String.Format("SELECT id_comp_contact, getCompByContact(id_comp_contact, 4) AS `id_wh_drawer`, getCompByContact(id_comp_contact, 6) AS `id_wh_rack`, getCompByContact(id_comp_contact, 7) AS `id_wh_locator`, contact_person,contact_number, email,is_default FROM tb_m_comp_contact WHERE id_comp='{0}' ORDER BY is_default AND contact_person", id_company), -1, True, "", "", "", "")
        GCCompanyContactList.DataSource = data
        If Not data.Rows.Count > 0 Or id_company = "-1" Then
            BtnSave.Enabled = False
        Else
            BtnSave.Enabled = True
        End If
    End Sub

    Sub view_company()
        Dim query As String = "SELECT tb_m_comp.comp_commission,tb_m_comp.id_comp as id_comp,tb_m_comp.comp_number as comp_number,tb_m_comp.comp_name as comp_name,tb_m_comp.address_primary as address_primary,tb_m_comp.is_active as is_active, tb_m_comp.id_comp_cat, tb_m_comp_cat.comp_cat_name as company_category,tb_m_comp_group.comp_group, tb_m_comp.id_wh_type, tb_m_comp.id_store_type, tb_m_comp.id_wh_type, IFNULL(tb_m_comp.id_commerce_type,1) AS `id_commerce_type`,tb_m_comp.id_drawer_def,
        IF(tb_m_comp.id_comp_cat=5, tb_m_comp.id_wh_type,IF(tb_m_comp.id_comp_cat=6,tb_m_comp.id_store_type,0)) AS `id_account_type`, tb_m_comp.is_use_unique_code "
        query += " FROM tb_m_comp INNER JOIN tb_m_comp_cat ON tb_m_comp.id_comp_cat=tb_m_comp_cat.id_comp_cat "
        query += " INNER JOIN tb_m_comp_group ON tb_m_comp_group.id_comp_group=tb_m_comp.id_comp_group "
        If id_cat <> "-1" Then
            query += "AND tb_m_comp.id_comp_cat = '" + id_cat + "' "
        End If
        If id_pop_up = "38" Then
            query += "AND (tb_m_comp.id_comp_cat = '5' OR tb_m_comp.id_comp_cat = '6') AND tb_m_comp.is_active=1 "
        End If

        If id_pop_up = "40" Then 'ret order ofline
            If FormSalesReturnOrderDet.is_ro_only_offline = "1" Then
                query += "AND tb_m_comp.id_commerce_type=1 "
            End If
        End If

        If id_pop_up = "41" Then
            Dim id_ret_type = FormSalesReturnDet.id_ret_type
            If id_ret_type = "3" Then 'return direct/khusus
                query += "AND tb_m_comp.id_comp<>" + get_setup_field("wh_temp") + " "
            ElseIf id_ret_type = "1" Then 'return reguler
                query += "AND tb_m_comp.id_comp=" + get_setup_field("wh_temp") + " "
            End If
        End If

        If id_pop_up = "47" Then
            query += "AND (tb_m_comp.id_comp_cat = '5' OR tb_m_comp.id_comp_cat = '6') "
        End If

        If id_pop_up = "81" Then
            query += "AND tb_m_comp.id_commerce_type = 2 "
        End If

        If id_pop_up = "89" Then
            query += "AND tb_m_comp.id_comp_cat=6 "
        End If

        If id_pop_up = "91" Then
            query += "AND tb_m_comp.is_active=1 "
        End If

        If id_pop_up = "92" Then
            query += "AND tb_m_comp.is_active=1 AND tb_m_comp.is_use_unique_code=1 "
        End If

        If id_departement <> "-1" Then
            query += "AND tb_m_comp.id_departement = '" + id_departement + "' "
        End If
        If id_so_type <> "-1" Then
            If id_so_type = "0" Then
                query += "AND (tb_m_comp.id_so_type = '" + id_so_type + "' OR ISNULL(tb_m_comp.id_so_type)) "
            Else
                query += "AND tb_m_comp.id_so_type = '" + id_so_type + "' "
            End If
        End If

        'filter by comp_number
        If comp_number <> "-1" Then
            query += "AND tb_m_comp.comp_number='" + addSlashes(comp_number) + "' "
        End If
        '
        If is_must_active = "1" Then
            query += " AND tb_m_comp.is_active=1 "
        End If
        '
        query += "ORDER BY comp_name "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCCompany.DataSource = data
        GVCompany.OptionsBehavior.AutoExpandAllGroups = True
        If data.Rows.Count > 0 Then
            GVCompany.FocusedRowHandle = 0
            view_contact(GVCompany.GetFocusedRowCellDisplayText("id_comp").ToString)
        Else
            BtnSave.Enabled = False
        End If
    End Sub

    Private Sub GVCompany_FocusedRowChanged(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles GVCompany.FocusedRowChanged
        view_contact(GVCompany.GetFocusedRowCellDisplayText("id_comp").ToString)
    End Sub

    'Save
    Private Sub BtnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSave.Click
        Cursor = Cursors.WaitCursor
        If id_pop_up = "awb" Then
            FormWHAWBillDet.id_comp = GVCompany.GetFocusedRowCellDisplayText("id_comp").ToString
            FormWHAWBillDet.TECompCode.Text = GVCompany.GetFocusedRowCellDisplayText("comp_number").ToString
            FormWHAWBillDet.TECompName.Text = GVCompany.GetFocusedRowCellDisplayText("comp_name").ToString
            FormWHAWBillDet.rate_table()
            FormWHAWBillDet.clear_do()
            Close()
        ElseIf id_pop_up = "1" Then
            FormSamplePurchaseDet.id_comp_to = GVCompanyContactList.GetFocusedRowCellDisplayText("id_comp_contact").ToString
            FormSamplePurchaseDet.TECompCode.Text = GVCompany.GetFocusedRowCellDisplayText("comp_number").ToString
            FormSamplePurchaseDet.TECompName.Text = GVCompany.GetFocusedRowCellDisplayText("comp_name").ToString
            FormSamplePurchaseDet.TECompAttn.Text = GVCompanyContactList.GetFocusedRowCellDisplayText("contact_person").ToString
            FormSamplePurchaseDet.MECompAddress.Text = GVCompany.GetFocusedRowCellDisplayText("address_primary").ToString
            Close()
        ElseIf id_pop_up = "1c" Then
            FormSamplePurchaseDet.id_comp_contact_courier = GVCompanyContactList.GetFocusedRowCellDisplayText("id_comp_contact").ToString
            FormSamplePurchaseDet.TECourierCode.Text = GVCompany.GetFocusedRowCellDisplayText("comp_number").ToString
            FormSamplePurchaseDet.TECourier.Text = GVCompany.GetFocusedRowCellDisplayText("comp_name").ToString
            Close()
        ElseIf id_pop_up = "2" Then
            FormSamplePurchaseDet.id_comp_ship_to = GVCompanyContactList.GetFocusedRowCellDisplayText("id_comp_contact").ToString
            FormSamplePurchaseDet.TECompShipTo.Text = GVCompany.GetFocusedRowCellDisplayText("comp_number").ToString
            FormSamplePurchaseDet.TECompShipToName.Text = GVCompany.GetFocusedRowCellDisplayText("comp_name").ToString
            FormSamplePurchaseDet.MECompShipToAddress.Text = GVCompany.GetFocusedRowCellDisplayText("address_primary").ToString
            Close()
        ElseIf id_pop_up = "3" Then
            FormSampleReceiveDet.id_comp_to = GVCompanyContactList.GetFocusedRowCellDisplayText("id_comp_contact").ToString
            FormSampleReceiveDet.TECompShipToName.Text = GVCompany.GetFocusedRowCellDisplayText("comp_name").ToString
            Close()
        ElseIf id_pop_up = "4" Then
            FormSamplePLSingle.id_comp_contact_from = GVCompanyContactList.GetFocusedRowCellDisplayText("id_comp_contact").ToString
            FormSamplePLSingle.TxtCodeCompFrom.Text = GVCompany.GetFocusedRowCellDisplayText("comp_number").ToString
            FormSamplePLSingle.TxtNameCompFrom.Text = GVCompany.GetFocusedRowCellDisplayText("comp_name").ToString
            Close()
        ElseIf id_pop_up = "5" Then
            FormSamplePLSingle.id_comp_contact_to = GVCompanyContactList.GetFocusedRowCellDisplayText("id_comp_contact").ToString
            FormSamplePLSingle.TxtCodeCompTo.Text = GVCompany.GetFocusedRowCellDisplayText("comp_number").ToString
            FormSamplePLSingle.TxtNameCompTo.Text = GVCompany.GetFocusedRowCellDisplayText("comp_name").ToString
            FormSamplePLSingle.MEAdrressCompTo.Text = GVCompany.GetFocusedRowCellDisplayText("address_primary").ToString
            Close()
        ElseIf id_pop_up = "6" Then
            FormSamplePRDet.id_comp_contact_pay_to = GVCompanyContactList.GetFocusedRowCellDisplayText("id_comp_contact").ToString
            FormSamplePRDet.TECompTo.Text = GVCompany.GetFocusedRowCellDisplayText("comp_name").ToString
            FormSamplePRDet.MECompAddress.Text = GVCompany.GetFocusedRowCellDisplayText("address_primary").ToString
            Close()
        ElseIf id_pop_up = "7" Then
            FormSampleRetOutSingle.id_comp_contact_from = GVCompanyContactList.GetFocusedRowCellDisplayText("id_comp_contact").ToString
            FormSampleRetOutSingle.TxtCodeCompFrom.Text = GVCompany.GetFocusedRowCellDisplayText("comp_number").ToString
            FormSampleRetOutSingle.TxtNameCompFrom.Text = GVCompany.GetFocusedRowCellDisplayText("comp_name").ToString
            Close()
        ElseIf id_pop_up = "8" Then
            FormSampleRetInSingle.id_comp_contact_to = GVCompanyContactList.GetFocusedRowCellDisplayText("id_comp_contact").ToString
            FormSampleRetInSingle.TxtCodeCompTo.Text = GVCompany.GetFocusedRowCellDisplayText("comp_number").ToString
            FormSampleRetInSingle.TxtNameCompTo.Text = GVCompany.GetFocusedRowCellDisplayText("comp_name").ToString
            FormSampleRetInSingle.MEAdrressCompTo.Text = GVCompany.GetFocusedRowCellValue("address_primary").ToString
            Close()
        ElseIf id_pop_up = "9" Then
            FormSamplePLDelSingle.id_comp_from = GVCompany.GetFocusedRowCellDisplayText("id_comp").ToString
            FormSamplePLDelSingle.id_comp_contact_from = GVCompanyContactList.GetFocusedRowCellDisplayText("id_comp_contact").ToString
            FormSamplePLDelSingle.TxtCodeCompFrom.Text = GVCompany.GetFocusedRowCellDisplayText("comp_number").ToString
            FormSamplePLDelSingle.TxtNameCompFrom.Text = GVCompany.GetFocusedRowCellDisplayText("comp_name").ToString
            Close()
        ElseIf id_pop_up = "10" Then
            FormSamplePLDelSingle.id_comp_contact_to = GVCompanyContactList.GetFocusedRowCellDisplayText("id_comp_contact").ToString
            FormSamplePLDelSingle.TxtCodeCompTo.Text = GVCompany.GetFocusedRowCellDisplayText("comp_number").ToString
            FormSamplePLDelSingle.TxtNameCompTo.Text = GVCompany.GetFocusedRowCellDisplayText("comp_name").ToString
            Close()
        ElseIf id_pop_up = "11" Then
            FormSampleReqSingle.id_comp_contact_from = GVCompanyContactList.GetFocusedRowCellDisplayText("id_comp_contact").ToString
            FormSampleReqSingle.TxtCodeCompFrom.Text = GVCompany.GetFocusedRowCellDisplayText("comp_number").ToString
            FormSampleReqSingle.TxtNameCompFrom.Text = GVCompany.GetFocusedRowCellDisplayText("comp_name").ToString
            FormSampleReqSingle.id_comp_from = GVCompany.GetFocusedRowCellDisplayText("id_comp").ToString
            Close()
        ElseIf id_pop_up = "12" Then
            FormSampleReqSingle.id_comp_contact_to = GVCompanyContactList.GetFocusedRowCellDisplayText("id_comp_contact").ToString
            FormSampleReqSingle.TxtCodeCompTo.Text = GVCompany.GetFocusedRowCellDisplayText("comp_number").ToString
            FormSampleReqSingle.TxtNameCompTo.Text = GVCompany.GetFocusedRowCellDisplayText("comp_name").ToString
            FormSampleReqSingle.GroupControlReq.Enabled = True
            FormSampleReqSingle.id_comp_to = GVCompany.GetFocusedRowCellDisplayText("id_comp").ToString
            FormSampleReqSingle.MEAdrressCompTo.Text = GVCompany.GetFocusedRowCellDisplayText("address_primary").ToString
            FormSampleReqSingle.viewBlank()
            FormSampleReqSingle.deleteRows()
            Close()
        ElseIf id_pop_up = "13" Then
            FormSamplePlanDet.id_comp_contact_to = GVCompanyContactList.GetFocusedRowCellDisplayText("id_comp_contact").ToString
            FormSamplePlanDet.TECompCode.Text = GVCompany.GetFocusedRowCellDisplayText("comp_number").ToString
            FormSamplePlanDet.TECompName.Text = GVCompany.GetFocusedRowCellDisplayText("comp_name").ToString
            FormSamplePlanDet.MECompAddress.Text = GVCompany.GetFocusedRowCellValue("address_primary").ToString
            FormSamplePlanDet.TECompAttn.Text = GVCompanyContactList.GetFocusedRowCellDisplayText("contact_person").ToString
            Close()
        ElseIf id_pop_up = "14" Then
            FormMatPurchaseDet.id_comp_to = GVCompanyContactList.GetFocusedRowCellDisplayText("id_comp_contact").ToString
            FormMatPurchaseDet.TECompCode.Text = GVCompany.GetFocusedRowCellDisplayText("comp_number").ToString
            FormMatPurchaseDet.TECompName.Text = GVCompany.GetFocusedRowCellDisplayText("comp_name").ToString
            FormMatPurchaseDet.MECompAddress.Text = GVCompany.GetFocusedRowCellValue("address_primary").ToString
            FormMatPurchaseDet.TECompAttn.Text = GVCompanyContactList.GetFocusedRowCellDisplayText("contact_person").ToString
            Close()
        ElseIf id_pop_up = "15" Then
            FormMatPurchaseDet.id_comp_ship_to = GVCompanyContactList.GetFocusedRowCellDisplayText("id_comp_contact").ToString
            FormMatPurchaseDet.TECompShipTo.Text = GVCompany.GetFocusedRowCellDisplayText("comp_number").ToString
            FormMatPurchaseDet.TECompShipToName.Text = GVCompany.GetFocusedRowCellDisplayText("comp_name").ToString
            FormMatPurchaseDet.MECompShipToAddress.Text = GVCompany.GetFocusedRowCellDisplayText("address_primary").ToString
            Close()
        ElseIf id_pop_up = "16" Then
            FormSampleReturnSingle.id_comp_contact_from = GVCompanyContactList.GetFocusedRowCellDisplayText("id_comp_contact").ToString
            FormSampleReturnSingle.TxtCodeCompFrom.Text = GVCompany.GetFocusedRowCellDisplayText("comp_number").ToString
            FormSampleReturnSingle.TxtNameCompFrom.Text = GVCompany.GetFocusedRowCellDisplayText("comp_name").ToString
            Close()
        ElseIf id_pop_up = "17" Then
            FormSampleReturnSingle.id_comp_to = GVCompany.GetFocusedRowCellDisplayText("id_comp").ToString
            FormSampleReturnSingle.id_comp_contact_to = GVCompanyContactList.GetFocusedRowCellDisplayText("id_comp_contact").ToString
            'FormSampleReturnSingle.TxtCodeCompTo.Text = GVCompany.GetFocusedRowCellDisplayText("comp_number").ToString
            'FormSampleReturnSingle.TxtNameCompTo.Text = GVCompany.GetFocusedRowCellDisplayText("comp_name").ToString
            FormSampleReturnSingle.viewDetailReturn()
            FormSampleReturnSingle.GroupControlRet.Enabled = True
            Close()
        ElseIf id_pop_up = "18" Then
            FormProdDemandMat.id_comp_ship_to = GVCompanyContactList.GetFocusedRowCellDisplayText("id_comp_contact").ToString
            FormProdDemandMat.TECompShipTo.Text = GVCompany.GetFocusedRowCellDisplayText("comp_number").ToString
            FormProdDemandMat.TECompShipToName.Text = GVCompany.GetFocusedRowCellDisplayText("comp_name").ToString
            FormProdDemandMat.MECompShipToAddress.Text = GVCompany.GetFocusedRowCellDisplayText("address_primary").ToString
            Close()
        ElseIf id_pop_up = "19" Then
            FormMatWODet.id_comp_to = GVCompanyContactList.GetFocusedRowCellDisplayText("id_comp_contact").ToString
            FormMatWODet.TECompCode.Text = GVCompany.GetFocusedRowCellDisplayText("comp_number").ToString
            FormMatWODet.TECompName.Text = GVCompany.GetFocusedRowCellDisplayText("comp_name").ToString
            FormMatWODet.MECompAddress.Text = GVCompany.GetFocusedRowCellValue("address_primary").ToString
            FormMatWODet.TECompAttn.Text = GVCompanyContactList.GetFocusedRowCellDisplayText("contact_person").ToString
            Close()
        ElseIf id_pop_up = "20" Then
            FormMatWODet.id_comp_ship_to = GVCompanyContactList.GetFocusedRowCellDisplayText("id_comp_contact").ToString
            FormMatWODet.TECompShipTo.Text = GVCompany.GetFocusedRowCellDisplayText("comp_number").ToString
            FormMatWODet.TECompShipToName.Text = GVCompany.GetFocusedRowCellDisplayText("comp_name").ToString
            FormMatWODet.MECompShipToAddress.Text = GVCompany.GetFocusedRowCellDisplayText("address_primary").ToString
            Close()
        ElseIf id_pop_up = "21" Then
            FormMatRetOutDet.id_comp_contact_from = GVCompanyContactList.GetFocusedRowCellDisplayText("id_comp_contact").ToString
            FormMatRetOutDet.TxtCodeCompFrom.Text = GVCompany.GetFocusedRowCellDisplayText("comp_number").ToString
            FormMatRetOutDet.TxtNameCompFrom.Text = GVCompany.GetFocusedRowCellDisplayText("comp_name").ToString
            Close()
        ElseIf id_pop_up = "22" Then
            'mrs req to
            FormProductionMRS.id_comp_req_to = GVCompanyContactList.GetFocusedRowCellDisplayText("id_comp_contact").ToString
            FormProductionMRS.TECompToCode.Text = GVCompany.GetFocusedRowCellDisplayText("comp_number").ToString
            FormProductionMRS.TECompToName.Text = GVCompany.GetFocusedRowCellDisplayText("comp_name").ToString
            Close()
        ElseIf id_pop_up = "22f" Then
            'mrs req from
            FormProductionMRS.id_comp_req_from = GVCompanyContactList.GetFocusedRowCellDisplayText("id_comp_contact").ToString
            FormProductionMRS.TECompCode.Text = GVCompany.GetFocusedRowCellDisplayText("comp_number").ToString
            FormProductionMRS.TECompName.Text = GVCompany.GetFocusedRowCellDisplayText("comp_name").ToString
            Close()
        ElseIf id_pop_up = "23" Then
            FormMatRetInDet.id_comp_contact_to = GVCompanyContactList.GetFocusedRowCellDisplayText("id_comp_contact").ToString
            FormMatRetInDet.TxtCodeCompTo.Text = GVCompany.GetFocusedRowCellDisplayText("comp_number").ToString
            FormMatRetInDet.TxtNameCompTo.Text = GVCompany.GetFocusedRowCellDisplayText("comp_name").ToString
            FormMatRetInDet.MEAdrressCompTo.Text = GVCompany.GetFocusedRowCellValue("address_primary").ToString
            Close()
        ElseIf id_pop_up = "24" Then
            FormProductionWO.id_comp_ship_to = GVCompanyContactList.GetFocusedRowCellDisplayText("id_comp_contact").ToString
            FormProductionWO.TECompShipTo.Text = GVCompany.GetFocusedRowCellDisplayText("comp_number").ToString
            FormProductionWO.TECompShipToName.Text = GVCompany.GetFocusedRowCellDisplayText("comp_name").ToString
            FormProductionWO.MECompShipToAddress.Text = GVCompany.GetFocusedRowCellDisplayText("address_primary").ToString
            Close()
        ElseIf id_pop_up = "25" Then
            FormProductionRecDet.id_comp_from = GVCompanyContactList.GetFocusedRowCellDisplayText("id_comp_contact").ToString
            FormProductionRecDet.TxtCodeCompFrom.Text = GVCompany.GetFocusedRowCellDisplayText("comp_number").ToString
            FormProductionRecDet.TECompName.Text = GVCompany.GetFocusedRowCellDisplayText("comp_name").ToString
            Close()
        ElseIf id_pop_up = "26" Then
            'pl mrs
            FormMatPLSingle.id_comp_contact_from = GVCompanyContactList.GetFocusedRowCellDisplayText("id_comp_contact").ToString
            FormMatPLSingle.TxtCodeCompFrom.Text = GVCompany.GetFocusedRowCellDisplayText("comp_number").ToString
            FormMatPLSingle.TxtNameCompFrom.Text = GVCompany.GetFocusedRowCellDisplayText("comp_name").ToString
            Close()
        ElseIf id_pop_up = "27" Then
            FormProductionRecDet.id_comp_to = GVCompanyContactList.GetFocusedRowCellDisplayText("id_comp_contact").ToString
            FormProductionRecDet.TxtCodeCompTo.Text = GVCompany.GetFocusedRowCellDisplayText("comp_number").ToString
            FormProductionRecDet.TECompShipToName.Text = GVCompany.GetFocusedRowCellDisplayText("comp_name").ToString
            Close()
        ElseIf id_pop_up = "28" Then
            'pl mrs
            FormMatPLSingle.id_comp_contact_from = GVCompanyContactList.GetFocusedRowCellDisplayText("id_comp_contact").ToString
            FormMatPLSingle.TxtCodeCompFrom.Text = GVCompany.GetFocusedRowCellDisplayText("comp_number").ToString
            FormMatPLSingle.TxtNameCompFrom.Text = GVCompany.GetFocusedRowCellDisplayText("comp_name").ToString
            Close()
        ElseIf id_pop_up = "29" Then
            'return out fg from
            FormProductionRetOutSingle.id_comp_contact_from = GVCompanyContactList.GetFocusedRowCellDisplayText("id_comp_contact").ToString
            FormProductionRetOutSingle.TxtNameCompFrom.Text = get_company_x(get_id_company(GVCompanyContactList.GetFocusedRowCellDisplayText("id_comp_contact").ToString), "1")
            FormProductionRetOutSingle.TxtCodeCompFrom.Text = get_company_x(get_id_company(GVCompanyContactList.GetFocusedRowCellDisplayText("id_comp_contact").ToString), "2")
            Close()
        ElseIf id_pop_up = "30" Then
            'return out fg to
            FormProductionRetOutSingle.id_comp_contact_to = GVCompanyContactList.GetFocusedRowCellDisplayText("id_comp_contact").ToString
            FormProductionRetOutSingle.TxtNameCompTo.Text = get_company_x(get_id_company(GVCompanyContactList.GetFocusedRowCellDisplayText("id_comp_contact").ToString), "1")
            FormProductionRetOutSingle.TxtCodeCompTo.Text = get_company_x(get_id_company(GVCompanyContactList.GetFocusedRowCellDisplayText("id_comp_contact").ToString), "2")
            FormProductionRetOutSingle.MEAdrressCompTo.Text = get_company_x(get_id_company(GVCompanyContactList.GetFocusedRowCellDisplayText("id_comp_contact").ToString), "3")
            Close()
        ElseIf id_pop_up = "31" Then
            FormMatMRSDet.id_comp_req_from = GVCompanyContactList.GetFocusedRowCellDisplayText("id_comp_contact").ToString
            FormMatMRSDet.TECompCode.Text = GVCompany.GetFocusedRowCellDisplayText("comp_number").ToString
            FormMatMRSDet.TECompName.Text = GVCompany.GetFocusedRowCellDisplayText("comp_name").ToString
            Close()
        ElseIf id_pop_up = "32" Then
            FormMatMRSDet.id_comp_req_to = GVCompanyContactList.GetFocusedRowCellDisplayText("id_comp_contact").ToString
            FormMatMRSDet.TECompToCode.Text = GVCompany.GetFocusedRowCellDisplayText("comp_number").ToString
            FormMatMRSDet.TECompToName.Text = GVCompany.GetFocusedRowCellDisplayText("comp_name").ToString
            Close()
        ElseIf id_pop_up = "33" Then
            'return in fg from
            FormProductionRetInSingle.id_comp_contact_from = GVCompanyContactList.GetFocusedRowCellDisplayText("id_comp_contact").ToString
            FormProductionRetInSingle.TxtNameCompFrom.Text = get_company_x(get_id_company(GVCompanyContactList.GetFocusedRowCellDisplayText("id_comp_contact").ToString), "1")
            FormProductionRetInSingle.TxtCodeCompFrom.Text = get_company_x(get_id_company(GVCompanyContactList.GetFocusedRowCellDisplayText("id_comp_contact").ToString), "2")
            Close()
        ElseIf id_pop_up = "34" Then
            'return in fg to
            FormProductionRetInSingle.id_comp_contact_to = GVCompanyContactList.GetFocusedRowCellDisplayText("id_comp_contact").ToString
            FormProductionRetInSingle.TxtNameCompTo.Text = get_company_x(get_id_company(GVCompanyContactList.GetFocusedRowCellDisplayText("id_comp_contact").ToString), "1")
            FormProductionRetInSingle.TxtCodeCompTo.Text = get_company_x(get_id_company(GVCompanyContactList.GetFocusedRowCellDisplayText("id_comp_contact").ToString), "2")
            FormProductionRetInSingle.MEAdrressCompTo.Text = get_company_x(get_id_company(GVCompanyContactList.GetFocusedRowCellDisplayText("id_comp_contact").ToString), "3")
            Close()
        ElseIf id_pop_up = "35" Then
            'PL FG From
            FormProductionPLToWHDet.id_comp_contact_from = GVCompanyContactList.GetFocusedRowCellDisplayText("id_comp_contact").ToString
            FormProductionPLToWHDet.TxtNameCompFrom.Text = get_company_x(get_id_company(GVCompanyContactList.GetFocusedRowCellDisplayText("id_comp_contact").ToString), "1")
            FormProductionPLToWHDet.TxtCodeCompFrom.Text = get_company_x(get_id_company(GVCompanyContactList.GetFocusedRowCellDisplayText("id_comp_contact").ToString), "2")
            Close()
        ElseIf id_pop_up = "36" Then
            'PL FG To
            FormProductionPLToWHDet.id_comp_contact_to = GVCompanyContactList.GetFocusedRowCellDisplayText("id_comp_contact").ToString
            FormProductionPLToWHDet.TxtNameCompTo.Text = get_company_x(get_id_company(GVCompanyContactList.GetFocusedRowCellDisplayText("id_comp_contact").ToString), "1")
            FormProductionPLToWHDet.TxtCodeCompTo.Text = get_company_x(get_id_company(GVCompanyContactList.GetFocusedRowCellDisplayText("id_comp_contact").ToString), "2")
            FormProductionPLToWHDet.MEAdrressCompTo.Text = get_company_x(get_id_company(GVCompanyContactList.GetFocusedRowCellDisplayText("id_comp_contact").ToString), "3")
            Close()
        ElseIf id_pop_up = "37" Then
            'Sales Target
            FormSalesTargetDet.id_comp_contact_to = GVCompanyContactList.GetFocusedRowCellDisplayText("id_comp_contact").ToString
            FormSalesTargetDet.TxtNameCompTo.Text = get_company_x(get_id_company(GVCompanyContactList.GetFocusedRowCellDisplayText("id_comp_contact").ToString), "1")
            FormSalesTargetDet.TxtCodeCompTo.Text = get_company_x(get_id_company(GVCompanyContactList.GetFocusedRowCellDisplayText("id_comp_contact").ToString), "2")
            FormSalesTargetDet.MEAdrressCompTo.Text = get_company_x(get_id_company(GVCompanyContactList.GetFocusedRowCellDisplayText("id_comp_contact").ToString), "3")
            Close()
        ElseIf id_pop_up = "38" Then
            'Sales Order
            If FormSalesOrderDet.id_store_contact_to <> GVCompanyContactList.GetFocusedRowCellDisplayText("id_comp_contact").ToString And FormSalesOrderDet.GVItemList.RowCount > 0 Then
                Dim confirm As DialogResult = DevExpress.XtraEditors.XtraMessageBox.Show("These changes will reset your item list. Are you sure you want to keep these changes?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
                If confirm = Windows.Forms.DialogResult.Yes Then
                    Cursor = Cursors.WaitCursor
                    FormSalesOrderDet.viewDetail("-1")
                    FormSalesOrderDet.id_store = GVCompany.GetFocusedRowCellValue("id_comp").ToString
                    FormSalesOrderDet.id_store_cat = GVCompany.GetFocusedRowCellValue("id_comp_cat").ToString
                    FormSalesOrderDet.id_store_type = GVCompany.GetFocusedRowCellValue("id_store_type").ToString
                    FormSalesOrderDet.id_wh_type = GVCompany.GetFocusedRowCellValue("id_wh_type").ToString

                    'tentukan akun type
                    If GVCompany.GetFocusedRowCellValue("id_comp_cat").ToString = "5" Then
                        'wh
                        FormSalesOrderDet.id_account_type = GVCompany.GetFocusedRowCellValue("id_wh_type").ToString
                    Else
                        'store
                        FormSalesOrderDet.id_account_type = GVCompany.GetFocusedRowCellValue("id_store_type").ToString
                        If FormSalesOrderDet.id_account_type = "3" Then
                            FormSalesOrderDet.id_account_type = "2"
                        End If
                    End If

                    FormSalesOrderDet.id_commerce_type = GVCompany.GetFocusedRowCellValue("id_commerce_type").ToString
                    FormSalesOrderDet.checkCommerceType()
                    FormSalesOrderDet.id_store_contact_to = GVCompanyContactList.GetFocusedRowCellDisplayText("id_comp_contact").ToString
                    FormSalesOrderDet.TxtNameCompTo.Text = get_company_x(get_id_company(GVCompanyContactList.GetFocusedRowCellDisplayText("id_comp_contact").ToString), "1")
                    FormSalesOrderDet.TxtCodeCompTo.Text = get_company_x(get_id_company(GVCompanyContactList.GetFocusedRowCellDisplayText("id_comp_contact").ToString), "2")
                    FormSalesOrderDet.MEAdrressCompTo.Text = get_company_x(get_id_company(GVCompanyContactList.GetFocusedRowCellDisplayText("id_comp_contact").ToString), "3")
                    Close()
                    Cursor = Cursors.Default
                End If
            Else
                Cursor = Cursors.WaitCursor
                FormSalesOrderDet.id_store = GVCompany.GetFocusedRowCellValue("id_comp").ToString
                FormSalesOrderDet.id_store_cat = GVCompany.GetFocusedRowCellValue("id_comp_cat").ToString
                FormSalesOrderDet.id_store_type = GVCompany.GetFocusedRowCellValue("id_store_type").ToString
                FormSalesOrderDet.id_wh_type = GVCompany.GetFocusedRowCellValue("id_wh_type").ToString

                'tentukan akun type
                If GVCompany.GetFocusedRowCellValue("id_comp_cat").ToString = "5" Then
                    'wh
                    FormSalesOrderDet.id_account_type = GVCompany.GetFocusedRowCellValue("id_wh_type").ToString
                Else
                    'store
                    FormSalesOrderDet.id_account_type = GVCompany.GetFocusedRowCellValue("id_store_type").ToString
                    If FormSalesOrderDet.id_account_type = "3" Then
                        FormSalesOrderDet.id_account_type = "2"
                    End If
                End If

                FormSalesOrderDet.id_commerce_type = GVCompany.GetFocusedRowCellValue("id_commerce_type").ToString
                FormSalesOrderDet.checkCommerceType()
                FormSalesOrderDet.id_store_contact_to = GVCompanyContactList.GetFocusedRowCellDisplayText("id_comp_contact").ToString
                FormSalesOrderDet.TxtNameCompTo.Text = get_company_x(get_id_company(GVCompanyContactList.GetFocusedRowCellDisplayText("id_comp_contact").ToString), "1")
                FormSalesOrderDet.TxtCodeCompTo.Text = get_company_x(get_id_company(GVCompanyContactList.GetFocusedRowCellDisplayText("id_comp_contact").ToString), "2")
                FormSalesOrderDet.MEAdrressCompTo.Text = get_company_x(get_id_company(GVCompanyContactList.GetFocusedRowCellDisplayText("id_comp_contact").ToString), "3")
                Close()
            End If
        ElseIf id_pop_up = "39" Then
            'Sales Delivery Order From
            FormSalesDelOrderDet.id_comp_contact_from = GVCompanyContactList.GetFocusedRowCellDisplayText("id_comp_contact").ToString
            FormSalesDelOrderDet.TxtNameCompFrom.Text = get_company_x(get_id_company(GVCompanyContactList.GetFocusedRowCellDisplayText("id_comp_contact").ToString), "1")
            FormSalesDelOrderDet.TxtCodeCompFrom.Text = get_company_x(get_id_company(GVCompanyContactList.GetFocusedRowCellDisplayText("id_comp_contact").ToString), "2")
            FormSalesDelOrderDet.id_comp_user = GVCompany.GetFocusedRowCellDisplayText("id_comp").ToString
            'FormSalesDelOrderDet.BtnBrowseContactFrom.Enabled = False
            Close()
        ElseIf id_pop_up = "40" Then
            'Sales Return Order
            FormSalesReturnOrderDet.id_comp = GVCompany.GetFocusedRowCellDisplayText("id_comp").ToString
            FormSalesReturnOrderDet.id_store_contact_to = GVCompanyContactList.GetFocusedRowCellDisplayText("id_comp_contact").ToString
            FormSalesReturnOrderDet.id_wh_drawer = GVCompanyContactList.GetFocusedRowCellDisplayText("id_wh_drawer").ToString
            FormSalesReturnOrderDet.id_wh_rack = GVCompanyContactList.GetFocusedRowCellDisplayText("id_wh_rack").ToString
            FormSalesReturnOrderDet.id_wh_locator = GVCompanyContactList.GetFocusedRowCellDisplayText("id_wh_locator").ToString
            FormSalesReturnOrderDet.TxtNameCompTo.Text = get_company_x(get_id_company(GVCompanyContactList.GetFocusedRowCellDisplayText("id_comp_contact").ToString), "1")
            FormSalesReturnOrderDet.TxtCodeCompTo.Text = get_company_x(get_id_company(GVCompanyContactList.GetFocusedRowCellDisplayText("id_comp_contact").ToString), "2")
            FormSalesReturnOrderDet.MEAdrressCompTo.Text = get_company_x(get_id_company(GVCompanyContactList.GetFocusedRowCellDisplayText("id_comp_contact").ToString), "3")
            FormSalesReturnOrderDet.viewDetail()
            FormSalesReturnOrderDet.check_but()
            Close()
        ElseIf id_pop_up = "41" Then
            'Sales Return
            FormSalesReturnDet.id_comp_contact_to = GVCompanyContactList.GetFocusedRowCellDisplayText("id_comp_contact").ToString
            FormSalesReturnDet.TxtNameCompTo.Text = get_company_x(get_id_company(GVCompanyContactList.GetFocusedRowCellDisplayText("id_comp_contact").ToString), "1")
            FormSalesReturnDet.TxtCodeCompTo.Text = get_company_x(get_id_company(GVCompanyContactList.GetFocusedRowCellDisplayText("id_comp_contact").ToString), "2")
            FormSalesReturnDet.id_comp_user = GVCompany.GetFocusedRowCellDisplayText("id_comp").ToString
            FormSalesReturnDet.setDefDrawer()
            'FormSalesReturnDet.id_drawer = ""
            'FormSalesReturnDet.TEDrawer.Text = ""
            Close()
        ElseIf id_pop_up = "42" Then
            ''SALES VIRTUAL POS (UPDATED 8 Oktober 2014)
            'FormSalesPOSDet.SPDiscount.EditValue = Decimal.Parse(GVCompany.GetFocusedRowCellValue("comp_commission").ToString)
            'FormSalesPOSDet.id_comp = GVCompany.GetFocusedRowCellDisplayText("id_comp").ToString
            'FormSalesPOSDet.id_store_contact_from = GVCompanyContactList.GetFocusedRowCellDisplayText("id_comp_contact").ToString
            'FormSalesPOSDet.TxtNameCompFrom.Text = get_company_x(get_id_company(GVCompanyContactList.GetFocusedRowCellDisplayText("id_comp_contact").ToString), "1")
            'FormSalesPOSDet.TxtCodeCompFrom.Text = get_company_x(get_id_company(GVCompanyContactList.GetFocusedRowCellDisplayText("id_comp_contact").ToString), "2")
            'FormSalesPOSDet.MEAdrressCompFrom.Text = get_company_x(get_id_company(GVCompanyContactList.GetFocusedRowCellDisplayText("id_comp_contact").ToString), "3")
            'FormSalesPOSDet.viewDetail()
            'FormSalesPOSDet.viewStockStore()
            'FormSalesPOSDet.check_but()
            'FormSalesPOSDet.GroupControlList.Enabled = True
            'FormSalesPOSDet.getDiscount()
            'FormSalesPOSDet.getNetto()
            'FormSalesPOSDet.getVat()
            'FormSalesPOSDet.getTaxBase()
            'Close()
            'per 25 Feb
            'cek account 
            'cek account 
            'If FormSalesPOSDet.check_acc(GVCompany.GetFocusedRowCellDisplayText("id_comp").ToString) Then
            FormSalesPOSDet.SPDiscount.EditValue = Decimal.Parse(GVCompany.GetFocusedRowCellValue("comp_commission").ToString)
            FormSalesPOSDet.id_comp = GVCompany.GetFocusedRowCellDisplayText("id_comp").ToString
            FormSalesPOSDet.id_store_contact_from = GVCompanyContactList.GetFocusedRowCellDisplayText("id_comp_contact").ToString
            FormSalesPOSDet.is_use_unique_code = GVCompany.GetFocusedRowCellValue("is_use_unique_code").ToString
            FormSalesPOSDet.TxtNameCompFrom.Text = get_company_x(GVCompany.GetFocusedRowCellDisplayText("id_comp").ToString, "1")
            FormSalesPOSDet.TxtCodeCompFrom.Text = get_company_x(GVCompany.GetFocusedRowCellDisplayText("id_comp").ToString, "2")
            FormSalesPOSDet.MEAdrressCompFrom.Text = get_company_x(GVCompany.GetFocusedRowCellDisplayText("id_comp").ToString, "3")
            FormSalesPOSDet.TENPWP.Text = get_company_x(GVCompany.GetFocusedRowCellDisplayText("id_comp").ToString, "5")
            FormSalesPOSDet.LETypeSO.ItemIndex = FormSalesPOSDet.LETypeSO.Properties.GetDataSourceRowIndex("id_so_type", get_company_x(GVCompany.GetFocusedRowCellDisplayText("id_comp").ToString, "8"))
            FormSalesPOSDet.viewDetail()
            FormSalesPOSDet.viewDetailCode()
            FormSalesPOSDet.viewStockStore()
            FormSalesPOSDet.check_but()
            FormSalesPOSDet.GroupControlList.Enabled = True
            FormSalesPOSDet.getDiscount()
            FormSalesPOSDet.getNetto()
            FormSalesPOSDet.getVat()
            FormSalesPOSDet.getTaxBase()
            FormSalesPOSDet.check_do()
            Close()
            'Else
            '    stopCustom("Store not registered for auto posting journal.")
            'End If
        ElseIf id_pop_up = "43" Then
            'Sales Return QC
            If GVCompany.GetFocusedRowCellDisplayText("id_comp").ToString = get_setup_field("wh_to_claim") Then
                If FormSalesReturnQCDet.id_comp_to <> get_setup_field("wh_from_claim") Then
                    stopCustom("This account only receive from RT2")
                    Exit Sub
                End If
            End If
            FormSalesReturnQCDet.id_comp_contact_to = GVCompanyContactList.GetFocusedRowCellDisplayText("id_comp_contact").ToString
            FormSalesReturnQCDet.TxtNameCompTo.Text = get_company_x(get_id_company(GVCompanyContactList.GetFocusedRowCellDisplayText("id_comp_contact").ToString), "1")
            FormSalesReturnQCDet.TxtCodeCompTo.Text = get_company_x(get_id_company(GVCompanyContactList.GetFocusedRowCellDisplayText("id_comp_contact").ToString), "2")
            FormSalesReturnQCDet.id_comp_user = GVCompany.GetFocusedRowCellDisplayText("id_comp").ToString
            FormSalesReturnQCDet.id_wh_type = GVCompany.GetFocusedRowCellValue("id_wh_type").ToString
            FormSalesReturnQCDet.setDefDrawer()
            FormSalesReturnQCDet.setReportMarkType()
            FormSalesReturnQCDet.viewDetail()
            FormSalesReturnQCDet.view_barcode_list()
            FormSalesReturnQCDet.id_reject_type = "-1"
            FormSalesReturnQCDet.reject_type = ""
            'FormSalesReturnDet.GroupControlDrawerDetail.Enabled = True
            Close()
        ElseIf id_pop_up = "44" Then
            'STORE STOCK OPNAME
            Cursor = Cursors.WaitCursor
            FormFGStockOpnameStoreDet.id_store_contact_from = GVCompanyContactList.GetFocusedRowCellDisplayText("id_comp_contact").ToString
            FormFGStockOpnameStoreDet.TxtNameStoreFrom.Text = get_company_x(get_id_company(GVCompanyContactList.GetFocusedRowCellDisplayText("id_comp_contact").ToString), "1")
            FormFGStockOpnameStoreDet.TxtCodeStoreFrom.Text = get_company_x(get_id_company(GVCompanyContactList.GetFocusedRowCellDisplayText("id_comp_contact").ToString), "2")
            FormFGStockOpnameStoreDet.id_store_from = GVCompany.GetFocusedRowCellDisplayText("id_comp").ToString
            FormFGStockOpnameStoreDet.GroupControlItem.Enabled = True
            FormFGStockOpnameStoreDet.viewDetail()
            FormFGStockOpnameStoreDet.view_barcode_list()
            FormFGStockOpnameStoreDet.codeAvailableIns("0", GVCompany.GetFocusedRowCellDisplayText("id_comp").ToString, "0")
            Close()
            Cursor = Cursors.Default
        ElseIf id_pop_up = "45" Then
            'Mat Stock Opname Det
            FormMatStockOpnameDet.id_comp_contact = GVCompanyContactList.GetFocusedRowCellDisplayText("id_comp_contact").ToString
            FormMatStockOpnameDet.TESourceName.Text = get_company_x(get_id_company(GVCompanyContactList.GetFocusedRowCellDisplayText("id_comp_contact").ToString), "1")
            FormMatStockOpnameDet.TESourceCode.Text = get_company_x(get_id_company(GVCompanyContactList.GetFocusedRowCellDisplayText("id_comp_contact").ToString), "2")
            FormMatStockOpnameDet.MESourceAddress.Text = get_company_x(get_id_company(GVCompanyContactList.GetFocusedRowCellDisplayText("id_comp_contact").ToString), "3")
            Close()
        ElseIf id_pop_up = "46" Then
            'FG MISSING
            Cursor = Cursors.WaitCursor
            FormFGMissingDet.SPDiscount.EditValue = Decimal.Parse(GVCompany.GetFocusedRowCellValue("comp_commission").ToString)
            FormFGMissingDet.id_store_from = GVCompany.GetFocusedRowCellDisplayText("id_comp").ToString
            FormFGMissingDet.id_wh_drawer = GVCompanyContactList.GetFocusedRowCellDisplayText("id_wh_drawer").ToString
            FormFGMissingDet.id_wh_rack = GVCompanyContactList.GetFocusedRowCellDisplayText("id_wh_rack").ToString
            FormFGMissingDet.id_wh_locator = GVCompanyContactList.GetFocusedRowCellDisplayText("id_wh_locator").ToString
            FormFGMissingDet.id_store_contact_from = GVCompanyContactList.GetFocusedRowCellDisplayText("id_comp_contact").ToString
            FormFGMissingDet.TxtNameCompFrom.Text = get_company_x(get_id_company(GVCompanyContactList.GetFocusedRowCellDisplayText("id_comp_contact").ToString), "1")
            FormFGMissingDet.TxtCodeCompFrom.Text = get_company_x(get_id_company(GVCompanyContactList.GetFocusedRowCellDisplayText("id_comp_contact").ToString), "2")
            FormFGMissingDet.MEAdrressCompFrom.Text = get_company_x(get_id_company(GVCompanyContactList.GetFocusedRowCellDisplayText("id_comp_contact").ToString), "3")
            FormFGMissingDet.GroupControlList.Enabled = True
            FormFGMissingDet.viewDetail()
            FormFGMissingDet.getDiscount()
            FormFGMissingDet.getNetto()
            FormFGMissingDet.getVat()
            FormFGMissingDet.getTaxBase()
            Close()
            Cursor = Cursors.Default
        ElseIf id_pop_up = "47" Then
            'WH STOCK OPNAME
            Cursor = Cursors.WaitCursor
            FormFGStockOpnameWHDet.id_comp_contact_from = GVCompanyContactList.GetFocusedRowCellDisplayText("id_comp_contact").ToString
            FormFGStockOpnameWHDet.TxtNameCompFrom.Text = get_company_x(get_id_company(GVCompanyContactList.GetFocusedRowCellDisplayText("id_comp_contact").ToString), "1")
            FormFGStockOpnameWHDet.TxtCodeCompFrom.Text = get_company_x(get_id_company(GVCompanyContactList.GetFocusedRowCellDisplayText("id_comp_contact").ToString), "2")
            FormFGStockOpnameWHDet.id_comp_from = GVCompany.GetFocusedRowCellDisplayText("id_comp").ToString
            FormFGStockOpnameWHDet.GroupControlItem.Enabled = True
            FormFGStockOpnameWHDet.viewDetail()
            FormFGStockOpnameWHDet.view_barcode_list()
            FormFGStockOpnameWHDet.dt.Clear()
            FormFGStockOpnameWHDet.setDefaultDrawer()
            Close()
            Cursor = Cursors.Default
        ElseIf id_pop_up = "48" Then
            'FG TRansfer From
            Cursor = Cursors.WaitCursor
            FormFGTrfDet.id_comp_contact_from = GVCompanyContactList.GetFocusedRowCellDisplayText("id_comp_contact").ToString
            FormFGTrfDet.TxtNameCompFrom.Text = get_company_x(get_id_company(GVCompanyContactList.GetFocusedRowCellDisplayText("id_comp_contact").ToString), "1")
            FormFGTrfDet.TxtCodeCompFrom.Text = get_company_x(get_id_company(GVCompanyContactList.GetFocusedRowCellDisplayText("id_comp_contact").ToString), "2")
            FormFGTrfDet.id_comp_from = GVCompany.GetFocusedRowCellDisplayText("id_comp").ToString
            FormFGTrfDet.GroupControlDrawerDetail.Enabled = True
            FormFGTrfDet.GroupControlListItem.Enabled = True
            FormFGTrfDet.GroupControlScannedItem.Enabled = True
            FormFGTrfDet.viewDetailDrawer()
            FormFGTrfDet.viewDetail()
            FormFGTrfDet.view_barcode_list()
            Close()
            Cursor = Cursors.Default
        ElseIf id_pop_up = "49" Then
            'FG TRansfer To
            Cursor = Cursors.WaitCursor
            FormFGTrfDet.id_comp_contact_to = GVCompanyContactList.GetFocusedRowCellDisplayText("id_comp_contact").ToString
            FormFGTrfDet.TxtNameCompTo.Text = get_company_x(get_id_company(GVCompanyContactList.GetFocusedRowCellDisplayText("id_comp_contact").ToString), "1")
            FormFGTrfDet.TxtCodeCompTo.Text = get_company_x(get_id_company(GVCompanyContactList.GetFocusedRowCellDisplayText("id_comp_contact").ToString), "2")
            FormFGTrfDet.id_comp_to = GVCompany.GetFocusedRowCellDisplayText("id_comp").ToString
            Close()
            Cursor = Cursors.Default
        ElseIf id_pop_up = "50" Then
            'PL SAMPLE DELIVERY TO WH From
            Cursor = Cursors.WaitCursor
            FormSampleDelDet.id_comp_contact_from = GVCompanyContactList.GetFocusedRowCellDisplayText("id_comp_contact").ToString
            FormSampleDelDet.TxtNameCompFrom.Text = get_company_x(get_id_company(GVCompanyContactList.GetFocusedRowCellDisplayText("id_comp_contact").ToString), "1")
            FormSampleDelDet.TxtCodeCompFrom.Text = get_company_x(get_id_company(GVCompanyContactList.GetFocusedRowCellDisplayText("id_comp_contact").ToString), "2")
            FormSampleDelDet.id_comp_from = GVCompany.GetFocusedRowCellDisplayText("id_comp").ToString
            FormSampleDelDet.GroupControlDrawerDetail.Enabled = True
            FormSampleDelDet.GroupControlListItem.Enabled = True
            FormSampleDelDet.GroupControlScannedItem.Enabled = True
            FormSampleDelDet.viewDetailDrawer()
            FormSampleDelDet.viewDetail()
            FormSampleDelDet.viewDetailBC()
            Close()
            Cursor = Cursors.Default
        ElseIf id_pop_up = "51" Then
            'PL SAMPLE DELIVERY TO WH To
            Cursor = Cursors.WaitCursor
            FormSampleDelDet.id_comp_contact_to = GVCompanyContactList.GetFocusedRowCellDisplayText("id_comp_contact").ToString
            FormSampleDelDet.TxtNameCompTo.Text = get_company_x(get_id_company(GVCompanyContactList.GetFocusedRowCellDisplayText("id_comp_contact").ToString), "1")
            FormSampleDelDet.TxtCodeCompTo.Text = get_company_x(get_id_company(GVCompanyContactList.GetFocusedRowCellDisplayText("id_comp_contact").ToString), "2")
            FormSampleDelDet.id_comp_to = GVCompany.GetFocusedRowCellDisplayText("id_comp").ToString
            Close()
            Cursor = Cursors.Default
        ElseIf id_pop_up = "52" Then
            'REC PL SAMPLE DELIVERY WH
            Cursor = Cursors.WaitCursor
            FormSampleDelRecDet.id_comp_contact_to = GVCompanyContactList.GetFocusedRowCellDisplayText("id_comp_contact").ToString
            FormSampleDelRecDet.TxtNameCompTo.Text = get_company_x(get_id_company(GVCompanyContactList.GetFocusedRowCellDisplayText("id_comp_contact").ToString), "1")
            FormSampleDelRecDet.TxtCodeCompTo.Text = get_company_x(get_id_company(GVCompanyContactList.GetFocusedRowCellDisplayText("id_comp_contact").ToString), "2")
            FormSampleDelRecDet.id_comp_to = GVCompany.GetFocusedRowCellDisplayText("id_comp").ToString
            Close()
            Cursor = Cursors.Default
        ElseIf id_pop_up = "53" Then
            'SALES ORDER SAMPLE
            FormSampleOrderDet.id_store_contact_to = GVCompanyContactList.GetFocusedRowCellDisplayText("id_comp_contact").ToString
            FormSampleOrderDet.TxtNameCompTo.Text = get_company_x(get_id_company(GVCompanyContactList.GetFocusedRowCellDisplayText("id_comp_contact").ToString), "1")
            FormSampleOrderDet.TxtCodeCompTo.Text = get_company_x(get_id_company(GVCompanyContactList.GetFocusedRowCellDisplayText("id_comp_contact").ToString), "2")
            FormSampleOrderDet.MEAdrressCompTo.Text = get_company_x(get_id_company(GVCompanyContactList.GetFocusedRowCellDisplayText("id_comp_contact").ToString), "3")
            FormSampleOrderDet.viewDetail()
            FormSampleOrderDet.GroupControlList.Enabled = True
            Close()
        ElseIf id_pop_up = "54" Then
            'DELIVERY ORDER SAMPLE
            Cursor = Cursors.WaitCursor
            FormSampleDelOrderDet.id_comp_contact_from = GVCompanyContactList.GetFocusedRowCellDisplayText("id_comp_contact").ToString
            FormSampleDelOrderDet.TxtNameCompFrom.Text = get_company_x(get_id_company(GVCompanyContactList.GetFocusedRowCellDisplayText("id_comp_contact").ToString), "1")
            FormSampleDelOrderDet.TxtCodeCompFrom.Text = get_company_x(get_id_company(GVCompanyContactList.GetFocusedRowCellDisplayText("id_comp_contact").ToString), "2")
            FormSampleDelOrderDet.id_comp_from = GVCompany.GetFocusedRowCellDisplayText("id_comp").ToString
            FormSampleDelOrderDet.GroupControlDrawerDetail.Enabled = True
            FormSampleDelOrderDet.GroupControlScannedItem.Enabled = True
            FormSampleDelOrderDet.viewDetailDrawer()
            FormSampleDelOrderDet.viewDetailBC()
            FormSampleDelOrderDet.check_but()
            For i As Integer = 0 To (FormSampleDelOrderDet.GVItemList.RowCount - 1)
                Dim id_sample As String = FormSampleDelOrderDet.GVItemList.GetRowCellValue(i, "id_sample").ToString
                FormSampleDelOrderDet.countQtyFromWh(id_sample)
            Next
            FormSampleDelOrderDet.GCItemList.RefreshDataSource()
            FormSampleDelOrderDet.GVItemList.RefreshData()
            FormSampleDelOrderDet.allowScanPage()
            Close()
            Cursor = Cursors.Default
        ElseIf id_pop_up = "55" Then
            'SAMPLE STOCK OPNAME
            Cursor = Cursors.WaitCursor
            FormSampleStockOpnameDet.id_comp_contact_from = GVCompanyContactList.GetFocusedRowCellDisplayText("id_comp_contact").ToString
            FormSampleStockOpnameDet.TxtNameCompFrom.Text = get_company_x(get_id_company(GVCompanyContactList.GetFocusedRowCellDisplayText("id_comp_contact").ToString), "1")
            FormSampleStockOpnameDet.TxtCodeCompFrom.Text = get_company_x(get_id_company(GVCompanyContactList.GetFocusedRowCellDisplayText("id_comp_contact").ToString), "2")
            FormSampleStockOpnameDet.id_comp_from = GVCompany.GetFocusedRowCellDisplayText("id_comp").ToString
            FormSampleStockOpnameDet.GroupControlItem.Enabled = True
            FormSampleStockOpnameDet.viewDetail()
            FormSampleStockOpnameDet.view_barcode_list()
            FormSampleStockOpnameDet.dt.Clear()
            Close()
            Cursor = Cursors.Default
        ElseIf id_pop_up = "56" Then
            Cursor = Cursors.WaitCursor
            FormSOHDet.id_comp_contact = GVCompanyContactList.GetFocusedRowCellValue("id_comp_contact").ToString
            FormSOHDet.TECompGroup.Text = GVCompany.GetFocusedRowCellValue("comp_group").ToString
            FormSOHDet.TECompName.Text = GVCompany.GetFocusedRowCellValue("comp_name").ToString
            FormSOHDet.TECompCode.Text = get_company_x(GVCompany.GetFocusedRowCellValue("id_comp").ToString, "2")
            Close()
            Cursor = Cursors.Default
        ElseIf id_pop_up = "57" Then
            'FG Write Off
            Cursor = Cursors.WaitCursor
            FormFGWoffDet.id_comp_contact_from = GVCompanyContactList.GetFocusedRowCellDisplayText("id_comp_contact").ToString
            FormFGWoffDet.TxtNameCompFrom.Text = get_company_x(get_id_company(GVCompanyContactList.GetFocusedRowCellDisplayText("id_comp_contact").ToString), "1")
            FormFGWoffDet.TxtCodeCompFrom.Text = get_company_x(get_id_company(GVCompanyContactList.GetFocusedRowCellDisplayText("id_comp_contact").ToString), "2")
            FormFGWoffDet.id_comp_from = GVCompany.GetFocusedRowCellDisplayText("id_comp").ToString
            FormFGWoffDet.GroupControlDrawerDetail.Enabled = True
            FormFGWoffDet.GroupControlListItem.Enabled = True
            FormFGWoffDet.GroupControlScannedItem.Enabled = True
            FormFGWoffDet.viewDetailDrawer()
            FormFGWoffDet.viewDetail()
            FormFGWoffDet.view_barcode_list()
            Close()
            Cursor = Cursors.Default
        ElseIf id_pop_up = "59" Then
            'Prepare Order for new product
            Cursor = Cursors.WaitCursor
            FormFGDSSONew.id_comp_contact_par = GVCompanyContactList.GetFocusedRowCellValue("id_comp_contact").ToString
            FormFGDSSONew.TxtNameCompTo.Text = GVCompany.GetFocusedRowCellValue("comp_name").ToString
            FormFGDSSONew.TxtCodeCompTo.Text = get_company_x(GVCompany.GetFocusedRowCellValue("id_comp").ToString, "2")
            Close()
            Cursor = Cursors.Default
        ElseIf id_pop_up = "60" Then
            'Prepare Order for new product
            Cursor = Cursors.WaitCursor
            FormFGSalesOrderReffDet.id_comp_contact_par = GVCompanyContactList.GetFocusedRowCellValue("id_comp_contact").ToString
            FormFGSalesOrderReffDet.TxtNameCompTo.Text = GVCompany.GetFocusedRowCellValue("comp_name").ToString
            FormFGSalesOrderReffDet.TxtCodeCompTo.Text = get_company_x(GVCompany.GetFocusedRowCellValue("id_comp").ToString, "2")
            Close()
            Cursor = Cursors.Default
        ElseIf id_pop_up = "61" Then
            FormSalesPromoDet.id_comp = GVCompany.GetFocusedRowCellDisplayText("id_comp").ToString
            FormSalesPromoDet.id_store_contact_from = GVCompanyContactList.GetFocusedRowCellDisplayText("id_comp_contact").ToString
            FormSalesPromoDet.id_wh_drawer = GVCompanyContactList.GetFocusedRowCellDisplayText("id_wh_drawer").ToString
            FormSalesPromoDet.id_wh_rack = GVCompanyContactList.GetFocusedRowCellDisplayText("id_wh_rack").ToString
            FormSalesPromoDet.id_wh_locator = GVCompanyContactList.GetFocusedRowCellDisplayText("id_wh_locator").ToString
            FormSalesPromoDet.TxtNameCompFrom.Text = get_company_x(get_id_company(GVCompanyContactList.GetFocusedRowCellDisplayText("id_comp_contact").ToString), "1")
            FormSalesPromoDet.TxtCodeCompFrom.Text = get_company_x(get_id_company(GVCompanyContactList.GetFocusedRowCellDisplayText("id_comp_contact").ToString), "2")
            FormSalesPromoDet.MEAdrressCompFrom.Text = get_company_x(get_id_company(GVCompanyContactList.GetFocusedRowCellDisplayText("id_comp_contact").ToString), "3")
            FormSalesPromoDet.viewDetail()
            FormSalesPromoDet.viewStockStore()
            FormSalesPromoDet.check_but()
            FormSalesPromoDet.GroupControlList.Enabled = True
            FormSalesPromoDet.getNetto()
            FormSalesPromoDet.getVat()
            FormSalesPromoDet.getTaxBase()
            Close()
        ElseIf id_pop_up = "62" Then
            'Prepare Order - WH
            If FormSalesOrderDet.id_comp_contact_par <> GVCompanyContactList.GetFocusedRowCellValue("id_comp_contact").ToString And FormSalesOrderDet.GVItemList.RowCount > 0 Then
                Dim confirm As DialogResult = DevExpress.XtraEditors.XtraMessageBox.Show("These changes will reset your item list. Are you sure you want to keep these changes?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
                If confirm = Windows.Forms.DialogResult.Yes Then
                    Cursor = Cursors.WaitCursor
                    FormSalesOrderDet.viewDetail("-1")
                    FormSalesOrderDet.id_comp_par = GVCompany.GetFocusedRowCellValue("id_comp").ToString
                    FormSalesOrderDet.id_comp_contact_par = GVCompanyContactList.GetFocusedRowCellValue("id_comp_contact").ToString
                    FormSalesOrderDet.TxtWHNameTo.Text = GVCompany.GetFocusedRowCellValue("comp_name").ToString
                    FormSalesOrderDet.TxtWHCodeTo.Text = get_company_x(GVCompany.GetFocusedRowCellValue("id_comp").ToString, "2")
                    Close()
                    Cursor = Cursors.Default
                End If
            Else
                Cursor = Cursors.WaitCursor
                FormSalesOrderDet.id_comp_par = GVCompany.GetFocusedRowCellValue("id_comp").ToString
                FormSalesOrderDet.id_comp_contact_par = GVCompanyContactList.GetFocusedRowCellValue("id_comp_contact").ToString
                FormSalesOrderDet.TxtWHNameTo.Text = GVCompany.GetFocusedRowCellValue("comp_name").ToString
                FormSalesOrderDet.TxtWHCodeTo.Text = get_company_x(GVCompany.GetFocusedRowCellValue("id_comp").ToString, "2")
                Close()
                Cursor = Cursors.Default
            End If
        ElseIf id_pop_up = "63" Then
            '63
        ElseIf id_pop_up = "64" Then
            'from
            FormSamplePLToWHDet.id_comp_from = GVCompany.GetFocusedRowCellDisplayText("id_comp").ToString
            FormSamplePLToWHDet.id_comp_contact_from = GVCompanyContactList.GetFocusedRowCellDisplayText("id_comp_contact").ToString
            FormSamplePLToWHDet.TxtNameCompFrom.Text = GVCompany.GetFocusedRowCellDisplayText("comp_name").ToString
            FormSamplePLToWHDet.TxtCodeCompFrom.Text = GVCompany.GetFocusedRowCellDisplayText("comp_number").ToString
            FormSamplePLToWHDet.setDefaultDrawer()
            FormSamplePLToWHDet.viewDetail()
            FormSamplePLToWHDet.codeAvailableIns()
            Close()
        ElseIf id_pop_up = "65" Then
            'to
            FormSamplePLToWHDet.id_comp_to = GVCompany.GetFocusedRowCellDisplayText("id_comp").ToString
            FormSamplePLToWHDet.id_comp_contact_to = GVCompanyContactList.GetFocusedRowCellDisplayText("id_comp_contact").ToString
            FormSamplePLToWHDet.TxtNameCompTo.Text = GVCompany.GetFocusedRowCellDisplayText("comp_name").ToString
            FormSamplePLToWHDet.TxtCodeCompTo.Text = GVCompany.GetFocusedRowCellDisplayText("comp_number").ToString
            Close()
        ElseIf id_pop_up = "66" Then
            FormFGWHAllocDet.id_comp_from = GVCompany.GetFocusedRowCellDisplayText("id_comp").ToString
            FormFGWHAllocDet.id_wh_drawer_from = GVCompanyContactList.GetFocusedRowCellValue("id_wh_drawer").ToString
            FormFGWHAllocDet.TxtNameCompFrom.Text = GVCompany.GetFocusedRowCellDisplayText("comp_name").ToString
            FormFGWHAllocDet.TxtCodeCompFrom.Text = GVCompany.GetFocusedRowCellDisplayText("comp_number").ToString
            FormFGWHAllocDet.viewDetail()
            BtnSave.Focus()
            Close()
        ElseIf id_pop_up = "67" Then
            FormSampleReturnPLDet.id_comp_to = GVCompany.GetFocusedRowCellDisplayText("id_comp").ToString
            FormSampleReturnPLDet.id_comp_contact_to = GVCompanyContactList.GetFocusedRowCellDisplayText("id_comp_contact").ToString
            FormSampleReturnPLDet.TxtCodeCompTo.Text = GVCompany.GetFocusedRowCellDisplayText("comp_number").ToString
            FormSampleReturnPLDet.TxtNameCompTo.Text = GVCompany.GetFocusedRowCellDisplayText("comp_name").ToString
            FormSampleReturnPLDet.setDefaultDrawer()
            FormSampleReturnPLDet.viewDetail()
            FormSampleReturnPLDet.codeAvailableIns()
            Close()
        ElseIf id_pop_up = "68" Then
            'Design COP PD
            FormMasterDesignCOPPD.TEVendorName.Text = get_company_x(GVCompany.GetFocusedRowCellDisplayText("id_comp").ToString, "1")
            FormMasterDesignCOPPD.TEVendor.Text = get_company_x(GVCompany.GetFocusedRowCellDisplayText("id_comp").ToString, "2")
            FormMasterDesignCOPPD.id_comp_contact = GVCompanyContactList.GetFocusedRowCellDisplayText("id_comp_contact").ToString
            FormMasterDesignCOPPD.id_comp = GVCompany.GetFocusedRowCellDisplayText("id_comp").ToString
            Close()
        ElseIf id_pop_up = "69" Then
            'REPAIR FROM
            FormFGRepairDet.id_comp_from = GVCompany.GetFocusedRowCellValue("id_comp").ToString
            FormFGRepairDet.TxtNameCompFrom.Text = get_company_x(get_id_company(GVCompanyContactList.GetFocusedRowCellDisplayText("id_comp_contact").ToString), "1")
            FormFGRepairDet.TxtCodeCompFrom.Text = get_company_x(get_id_company(GVCompanyContactList.GetFocusedRowCellDisplayText("id_comp_contact").ToString), "2")
            FormFGRepairDet.setDefaultDrawerFrom()
            FormFGRepairDet.viewDetail()
            FormFGRepairDet.codeAvailableIns()
            FormFGRepairDet.TxtCodeCompTo.Focus()
            Close()
        ElseIf id_pop_up = "70" Then
            'REPAIR TO
            FormFGRepairDet.id_comp_to = GVCompany.GetFocusedRowCellValue("id_comp").ToString
            FormFGRepairDet.TxtNameCompTo.Text = get_company_x(get_id_company(GVCompanyContactList.GetFocusedRowCellDisplayText("id_comp_contact").ToString), "1")
            FormFGRepairDet.TxtCodeCompTo.Text = get_company_x(get_id_company(GVCompanyContactList.GetFocusedRowCellDisplayText("id_comp_contact").ToString), "2")
            FormFGRepairDet.setDefaultDrawerTo()
            Close()
        ElseIf id_pop_up = "71" Then
            'RETURN REPAIR FROM
            FormFGRepairReturnDet.id_comp_from = GVCompany.GetFocusedRowCellValue("id_comp").ToString
            FormFGRepairReturnDet.TxtNameCompFrom.Text = get_company_x(get_id_company(GVCompanyContactList.GetFocusedRowCellDisplayText("id_comp_contact").ToString), "1")
            FormFGRepairReturnDet.TxtCodeCompFrom.Text = get_company_x(get_id_company(GVCompanyContactList.GetFocusedRowCellDisplayText("id_comp_contact").ToString), "2")
            FormFGRepairReturnDet.setDefaultDrawerFrom()
            FormFGRepairReturnDet.viewDetail()
            FormFGRepairReturnDet.codeAvailableIns()
            FormFGRepairReturnDet.TxtCodeCompTo.Focus()
            Close()
        ElseIf id_pop_up = "72" Then
            'RETURN REPAIR TO
            FormFGRepairReturnDet.id_comp_to = GVCompany.GetFocusedRowCellValue("id_comp").ToString
            FormFGRepairReturnDet.TxtNameCompTo.Text = get_company_x(get_id_company(GVCompanyContactList.GetFocusedRowCellDisplayText("id_comp_contact").ToString), "1")
            FormFGRepairReturnDet.TxtCodeCompTo.Text = get_company_x(get_id_company(GVCompanyContactList.GetFocusedRowCellDisplayText("id_comp_contact").ToString), "2")
            FormFGRepairReturnDet.setDefaultDrawerTo()
            Close()
        ElseIf id_pop_up = "73" Then
            'CVLONE COMPAY
            Dim host As String = FormOutlet.GVOutlet.GetFocusedRowCellValue("host").ToString
            Dim username As String = FormOutlet.GVOutlet.GetFocusedRowCellValue("username").ToString
            Dim pass As String = FormOutlet.GVOutlet.GetFocusedRowCellValue("pass").ToString
            Dim db As String = FormOutlet.GVOutlet.GetFocusedRowCellValue("db").ToString

            Try
                'comp
                Dim id_comp As String = GVCompany.GetFocusedRowCellValue("id_comp").ToString
                Dim dtcomp As DataTable = execute_query("SELECT * FROM tb_m_comp WHERE id_comp=" + id_comp + "", -1, True, "", "", "", "")
                Dim qinscomp As String = "INSERT INTO tb_m_comp(id_comp, id_comp_cat, comp_number, id_city, comp_name, comp_display_name, address_primary, address_other, fax, postal_code, email, website, id_tax, npwp, is_active, id_departement, comp_commission, id_store_type, id_area, id_employee_rep, id_comp_group, id_pd_alloc, id_wh_type, id_wh, id_acc_sale_ar, id_acc_sale_fg, id_so_type, id_drawer_def, awb_destination, awb_zone, awb_cargo_code, awb_rank, is_own_store) "
                qinscomp += "SELECT '" + dtcomp.Rows(0)("id_comp").ToString + "', '" + dtcomp.Rows(0)("id_comp_cat").ToString + "', '" + dtcomp.Rows(0)("comp_number").ToString + "', '" + dtcomp.Rows(0)("id_city").ToString + "', '" + dtcomp.Rows(0)("comp_name").ToString + "', '" + dtcomp.Rows(0)("comp_display_name").ToString + "', '" + dtcomp.Rows(0)("address_primary").ToString + "', '" + dtcomp.Rows(0)("address_other").ToString + "', '" + dtcomp.Rows(0)("fax").ToString + "', '" + dtcomp.Rows(0)("postal_code").ToString + "', '" + dtcomp.Rows(0)("email").ToString + "', '" + dtcomp.Rows(0)("website").ToString + "', '" + dtcomp.Rows(0)("id_tax").ToString + "', '" + dtcomp.Rows(0)("npwp").ToString + "', '" + dtcomp.Rows(0)("is_active").ToString + "', " + checkNullInput(dtcomp.Rows(0)("id_departement").ToString) + ", '" + decimalSQL(dtcomp.Rows(0)("comp_commission").ToString) + "', '" + dtcomp.Rows(0)("id_store_type").ToString + "', '" + dtcomp.Rows(0)("id_area").ToString + "', '" + dtcomp.Rows(0)("id_employee_rep").ToString + "', '" + dtcomp.Rows(0)("id_comp_group").ToString + "', '" + dtcomp.Rows(0)("id_pd_alloc").ToString + "', " + checkNullInput(dtcomp.Rows(0)("id_wh_type").ToString) + ", " + checkNullInput(dtcomp.Rows(0)("id_wh").ToString) + ", " + checkNullInput(dtcomp.Rows(0)("id_acc_sale_ar").ToString) + ", " + checkNullInput(dtcomp.Rows(0)("id_acc_sale_fg").ToString) + ", '" + dtcomp.Rows(0)("id_so_type").ToString + "', '" + dtcomp.Rows(0)("id_drawer_def").ToString + "', " + checkNullInput(dtcomp.Rows(0)("awb_destination").ToString) + ", " + checkNullInput(dtcomp.Rows(0)("awb_zone").ToString) + ", " + checkNullInput(dtcomp.Rows(0)("awb_cargo_code").ToString) + ", " + checkNullInput(dtcomp.Rows(0)("awb_rank").ToString) + ", '" + dtcomp.Rows(0)("is_own_store").ToString + "'; SELECT LAST_INSERT_ID() "
                execute_non_query(qinscomp, False, host, username, pass, db)

                'contact
                Dim dtconn As DataTable = execute_query("SELECT a.id_comp_contact, a.id_comp,a.contact_person, a.contact_number, a.is_default FROM tb_m_comp_contact a WHERE a.id_comp=" + dtcomp.Rows(0)("id_comp").ToString + " AND a.is_default=1", -1, True, "", "", "", "")
                Dim qcon As String = "INSERT INTO tb_m_comp_contact(id_comp_contact, id_comp, contact_person, contact_number, is_default) 
                SELECT '" + dtconn.Rows(0)("id_comp_contact").ToString + "', '" + dtconn.Rows(0)("id_comp").ToString + "', '" + dtconn.Rows(0)("contact_person").ToString + "', '" + dtconn.Rows(0)("contact_number").ToString + "','1' "
                execute_non_query(qcon, False, host, username, pass, db)
                infoCustom("Clone data success")
                Close()
            Catch ex As Exception
                stopCustom(ex.ToString)
                Close()
            End Try
        ElseIf id_pop_up = "74" Then
            'RETURN Mat In Prod
            FormMatRetInProd.id_comp_contact_from = GVCompanyContactList.GetFocusedRowCellValue("id_comp_contact").ToString
            FormMatRetInProd.TxtNameCompFrom.Text = get_company_x(get_id_company(GVCompanyContactList.GetFocusedRowCellDisplayText("id_comp_contact").ToString), "1")
            FormMatRetInProd.TxtCodeCompFrom.Text = get_company_x(get_id_company(GVCompanyContactList.GetFocusedRowCellDisplayText("id_comp_contact").ToString), "2")
            FormMatRetInProd.MEAdrressCompFrom.Text = get_company_x(get_id_company(GVCompanyContactList.GetFocusedRowCellDisplayText("id_comp_contact").ToString), "3")
            Close()
        ElseIf id_pop_up = "75" Then
            'from final clearance
            FormProductionFinalClearDet.id_comp_from = GVCompany.GetFocusedRowCellValue("id_comp").ToString
            FormProductionFinalClearDet.TxtNameCompFrom.Text = GVCompany.GetFocusedRowCellValue("comp_name").ToString
            FormProductionFinalClearDet.TxtCodeCompFrom.Text = GVCompany.GetFocusedRowCellValue("comp_number").ToString
            FormProductionFinalClearDet.TxtCodeCompTo.Focus()
            Close()
        ElseIf id_pop_up = "76" Then
            'to final clearance
            FormProductionFinalClearDet.id_comp_to = GVCompany.GetFocusedRowCellValue("id_comp").ToString
            FormProductionFinalClearDet.TxtNameCompTo.Text = GVCompany.GetFocusedRowCellValue("comp_name").ToString
            FormProductionFinalClearDet.TxtCodeCompTo.Text = GVCompany.GetFocusedRowCellValue("comp_number").ToString
            FormProductionFinalClearDet.TxtOrder.Focus()
            Close()
        ElseIf id_pop_up = "77" Then
            'del empty
            Dim confirm As DialogResult = DevExpress.XtraEditors.XtraMessageBox.Show("Are you sure you want to choose this store : " + GVCompany.GetFocusedRowCellValue("comp_number").ToString + " - " + GVCompany.GetFocusedRowCellValue("comp_name").ToString + "?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
            If confirm = Windows.Forms.DialogResult.Yes Then
                Dim id_comp_contact As String = GVCompanyContactList.GetFocusedRowCellValue("id_comp_contact").ToString
                Dim query As String = "INSERT INTO tb_wh_del_empty(wh_del_empty_number, id_store_contact_from, wh_del_empty_date,id_report_status, last_update, last_update_by) "
                query += "VALUES('" + header_number_sales("31") + "', '" + id_comp_contact + "', NOW(),1, NOW(), " + id_user + ");SELECT LAST_INSERT_ID(); "
                Dim id As String = execute_query(query, 0, True, "", "", "", "")
                increase_inc_sales("31")
                FormWHDelEmpty.viewDel()
                FormWHDelEmpty.GVDel.FocusedRowHandle = find_row(FormWHDelEmpty.GVDel, "id_wh_del_empty", id)
                Close()
                FormWHDelEmptyDet.id_wh_del_empty = id
                FormWHDelEmptyDet.ShowDialog()
            End If
        ElseIf id_pop_up = "78" Then
            'WH DEL COMBINE
            FormSalesDelOrderSlip.id_comp_contact_from = GVCompanyContactList.GetFocusedRowCellValue("id_comp_contact").ToString
            FormSalesDelOrderSlip.TxtCodeCompFrom.Text = GVCompany.GetFocusedRowCellValue("comp_number").ToString
            FormSalesDelOrderSlip.TxtNameCompFrom.Text = GVCompany.GetFocusedRowCellValue("comp_name").ToString
            FormSalesDelOrderSlip.id_wh_drawer = GVCompany.GetFocusedRowCellValue("id_drawer_def").ToString
            FormSalesDelOrderSlip.viewSalesDelOrder()
            FormSalesDelOrderSlip.GCItemList.DataSource = Nothing
            Close()
        ElseIf id_pop_up = "79" Then
            'STORE DEL COMBINE
            FormSalesDelOrderSlip.id_store_contact_to = GVCompanyContactList.GetFocusedRowCellValue("id_comp_contact").ToString
            FormSalesDelOrderSlip.TxtCodeCompTo.Text = GVCompany.GetFocusedRowCellValue("comp_number").ToString
            FormSalesDelOrderSlip.TxtNameCompTo.Text = GVCompany.GetFocusedRowCellValue("comp_name").ToString
            FormSalesDelOrderSlip.MEAdrressCompTo.Text = GVCompany.GetFocusedRowCellValue("address_primary").ToString
            FormSalesDelOrderSlip.viewSalesDelOrder()
            FormSalesDelOrderSlip.GCItemList.DataSource = Nothing
            Close()
        ElseIf id_pop_up = "80" Then
            'missing staff bil
            FormSalesPOSDet.SPDiscount.EditValue = Decimal.Parse(GVCompany.GetFocusedRowCellValue("comp_commission").ToString)
            FormSalesPOSDet.id_comp_contact_bill = GVCompanyContactList.GetFocusedRowCellDisplayText("id_comp_contact").ToString
            FormSalesPOSDet.TxtNameBillTo.Text = get_company_x(GVCompany.GetFocusedRowCellDisplayText("id_comp").ToString, "1")
            FormSalesPOSDet.TxtCodeBillTo.Text = get_company_x(GVCompany.GetFocusedRowCellDisplayText("id_comp").ToString, "2")
            FormSalesPOSDet.getDiscount()
            FormSalesPOSDet.getNetto()
            FormSalesPOSDet.getVat()
            FormSalesPOSDet.getTaxBase()
            FormSalesPOSDet.check_do()
            Close()
        ElseIf id_pop_up = "81" Then
            'store ol store - return order
            FormSalesReturnOrderOLDet.id_store = GVCompany.GetFocusedRowCellValue("id_comp").ToString
            FormSalesReturnOrderOLDet.id_store_contact_to = GVCompanyContactList.GetFocusedRowCellValue("id_comp_contact").ToString
            FormSalesReturnOrderOLDet.TxtStoreCode.Text = GVCompany.GetFocusedRowCellValue("comp_number").ToString
            FormSalesReturnOrderOLDet.TxtStoreName.Text = GVCompany.GetFocusedRowCellValue("comp_name").ToString
            FormSalesReturnOrderOLDet.id_wh_drawer = GVCompany.GetFocusedRowCellValue("id_drawer_def").ToString
            FormSalesReturnOrderOLDet.viewDetail()
            Close()
        ElseIf id_pop_up = "82" Then
            'wh ol store - return order
            FormSalesReturnOrderOLDet.id_wh_contact_to = GVCompanyContactList.GetFocusedRowCellValue("id_comp_contact").ToString
            FormSalesReturnOrderOLDet.TxtWHCode.Text = GVCompany.GetFocusedRowCellValue("comp_number").ToString
            FormSalesReturnOrderOLDet.TxtWHName.Text = GVCompany.GetFocusedRowCellValue("comp_name").ToString
            Close()
        ElseIf id_pop_up = "83" Then
            'PR Courier
            FormProdPRWODet.id_comp_contact_pay_to = GVCompanyContactList.GetFocusedRowCellValue("id_comp_contact").ToString
            FormProdPRWODet.TECompTo.Text = get_company_x(get_id_company(GVCompanyContactList.GetFocusedRowCellDisplayText("id_comp_contact").ToString), "1")
            FormProdPRWODet.MECompAddress.Text = get_company_x(get_id_company(GVCompanyContactList.GetFocusedRowCellDisplayText("id_comp_contact").ToString), "3")
            If FormProdPRWODet.is_no_reff = "1" Then
                FormProdPRWODet.view_list_no_reff()
                FormProdPRWODet.GConListPurchase.Enabled = True
            Else
                FormProdPRWODet.view_list_po()
            End If
            Close()
        ElseIf id_pop_up = "84" Then
            'Debit Note
            FormProdDebitNoteDet.id_comp_contact_debit_to = GVCompanyContactList.GetFocusedRowCellValue("id_comp_contact").ToString
            FormProdDebitNoteDet.TxtCodeCompDebitTo.Text = GVCompany.GetFocusedRowCellValue("comp_number").ToString
            FormProdDebitNoteDet.TxtNameCompDebitTo.Text = GVCompany.GetFocusedRowCellValue("comp_name").ToString
            FormProdDebitNoteDet.MEAdrressCompDebitTo.Text = get_company_x(get_id_company(GVCompanyContactList.GetFocusedRowCellDisplayText("id_comp_contact").ToString), "3")
            Close()
        ElseIf id_pop_up = "85" Then
            'sales report tracking
            FormSalesReportTrackingParam.id_comp = GVCompany.GetFocusedRowCellDisplayText("id_comp").ToString
            FormSalesReportTrackingParam.id_store_contact_from = GVCompanyContactList.GetFocusedRowCellDisplayText("id_comp_contact").ToString
            FormSalesReportTrackingParam.TxtNameCompFrom.Text = get_company_x(GVCompany.GetFocusedRowCellDisplayText("id_comp").ToString, "1")
            FormSalesReportTrackingParam.TxtCodeCompFrom.Text = get_company_x(GVCompany.GetFocusedRowCellDisplayText("id_comp").ToString, "2")
            Close()
        ElseIf id_pop_up = "86" Then
            'Purchase Order Purchasing
            FormPurcOrderDet.id_vendor_contact = GVCompanyContactList.GetFocusedRowCellDisplayText("id_comp_contact").ToString
            FormPurcOrderDet.TEVendorCode.Text = GVCompany.GetFocusedRowCellValue("comp_number").ToString
            FormPurcOrderDet.TEVendorName.Text = GVCompany.GetFocusedRowCellValue("comp_name").ToString
            FormPurcOrderDet.MEAdrressCompTo.Text = get_company_x(get_id_company(GVCompanyContactList.GetFocusedRowCellDisplayText("id_comp_contact").ToString), "3")
            '
            FormPurcOrderDet.TEVendorAttn.Text = GVCompanyContactList.GetFocusedRowCellValue("contact_person").ToString
            FormPurcOrderDet.TEVendorEmail.Text = get_company_x(GVCompany.GetFocusedRowCellDisplayText("id_comp").ToString, "9")
            FormPurcOrderDet.TEVendorPhone.Text = get_company_contact_x(GVCompanyContactList.GetFocusedRowCellValue("id_comp_contact").ToString, "2")
            FormPurcOrderDet.TEVendorFax.Text = get_company_x(GVCompany.GetFocusedRowCellDisplayText("id_comp").ToString, "10")
            Close()
        ElseIf id_pop_up = "87" Then
            'receive return repair di WH
            FormFGRepairReturnRecDet.id_wh_type = GVCompany.GetFocusedRowCellValue("id_wh_type").ToString
            FormFGRepairReturnRecDet.id_wh_drawer_dest = GVCompany.GetFocusedRowCellValue("id_drawer_def").ToString
            FormFGRepairReturnRecDet.TxtCodeWH.Text = GVCompany.GetFocusedRowCellValue("comp_number").ToString
            FormFGRepairReturnRecDet.TxtNameWH.Text = GVCompany.GetFocusedRowCellValue("comp_name").ToString
            Close()
        ElseIf id_pop_up = "88" Then
            'design propose
            FormMasterDesignCOPProposeDet.TEVendorName.Text = get_company_x(GVCompany.GetFocusedRowCellDisplayText("id_comp").ToString, "1")
            FormMasterDesignCOPProposeDet.TEVendor.Text = get_company_x(GVCompany.GetFocusedRowCellDisplayText("id_comp").ToString, "2")
            FormMasterDesignCOPProposeDet.id_comp_contact = GVCompanyContactList.GetFocusedRowCellDisplayText("id_comp_contact").ToString
            FormMasterDesignCOPProposeDet.id_comp = GVCompany.GetFocusedRowCellDisplayText("id_comp").ToString
            Close()
        ElseIf id_pop_up = "89" Then
            'invoice no stock
            FormSalesPOSNoStockDet.id_comp = GVCompany.GetFocusedRowCellDisplayText("id_comp").ToString
            FormSalesPOSNoStockDet.TxtCompNumber.Text = GVCompany.GetFocusedRowCellValue("comp_number").ToString
            FormSalesPOSNoStockDet.TxtCompName.Text = GVCompany.GetFocusedRowCellValue("comp_name").ToString
            Close()
        ElseIf id_pop_up = "90" Then
            'expense

            'cek coa vendor
            Dim err_coa As String = ""
            Dim cond_coa_vendor As Boolean = True
            Dim qcoa_vendor As String = "SELECT c.id_comp, ap.id_acc 
            FROM tb_m_comp c
            LEFT JOIN tb_a_acc ap ON ap.id_acc = c.id_acc_ap
            WHERE c.id_comp=" + GVCompany.GetFocusedRowCellDisplayText("id_comp").ToString + "
            AND !ISNULL(ap.id_acc) "
            Dim dcoa_vendor As DataTable = execute_query(qcoa_vendor, -1, True, "", "", "", "")
            If dcoa_vendor.Rows.Count <= 0 Then
                err_coa += "- COA : Account Payable Vendor " + System.Environment.NewLine
                cond_coa_vendor = False
            End If

            If Not cond_coa_vendor Then
                warningCustom("Please contact Accounting Department to setup these COA : " + System.Environment.NewLine + err_coa)
                Close()
                Exit Sub
            End If

            FormItemExpenseDet.id_comp = GVCompany.GetFocusedRowCellDisplayText("id_comp").ToString
            FormItemExpenseDet.TxtCompNumber.Text = GVCompany.GetFocusedRowCellDisplayText("comp_number").ToString
            FormItemExpenseDet.TxtCompName.Text = GVCompany.GetFocusedRowCellDisplayText("comp_name").ToString
            Close()
        ElseIf id_pop_up = "91" Then
            'opt activate store report 16 digit
            FormOpt.id_store = GVCompany.GetFocusedRowCellDisplayText("id_comp").ToString
            FormOpt.TxtCompNumber.Text = GVCompany.GetFocusedRowCellDisplayText("comp_number").ToString
            FormOpt.TxtCompName.Text = GVCompany.GetFocusedRowCellDisplayText("comp_name").ToString
            If GVCompany.GetFocusedRowCellValue("is_use_unique_code").ToString = "1" Then
                FormOpt.TxtUseUniqueCode.Text = "Yes"
                FormOpt.BtnSet.Enabled = False
            Else
                FormOpt.TxtUseUniqueCode.Text = "No"
                FormOpt.BtnSet.Enabled = True
            End If
            FormOpt.GCCodeList.DataSource = Nothing
            Close()
        ElseIf id_pop_up = "92" Then
            'verify master
            If GVCompanyContactList.GetFocusedRowCellValue("contact_person").ToString = "" Or GVCompanyContactList.GetFocusedRowCellValue("email").ToString = "" Then
                stopCustom("Please complete all data contact person first")
                FormVerifyMaster.BtnView.Enabled = False
            Else
                FormVerifyMaster.id_store = GVCompany.GetFocusedRowCellDisplayText("id_comp").ToString
                FormVerifyMaster.id_store_contact = GVCompanyContactList.GetFocusedRowCellDisplayText("id_comp_contact").ToString
                FormVerifyMaster.TxtCompName.Text = GVCompany.GetFocusedRowCellDisplayText("comp_number").ToString + " - " + GVCompany.GetFocusedRowCellDisplayText("comp_name").ToString
                FormVerifyMaster.TxtEmail.Text = GVCompanyContactList.GetFocusedRowCellValue("email").ToString
                FormVerifyMaster.TXTCP.Text = GVCompanyContactList.GetFocusedRowCellValue("contact_person").ToString
                FormVerifyMaster.BtnView.Enabled = True
                FormVerifyMaster.BtnReset.Visible = False
                FormVerifyMaster.GCSalesDelOrder.DataSource = Nothing
                FormVerifyMaster.BtnLoadData.Visible = False
                FormVerifyMaster.GCData.DataSource = Nothing
                FormVerifyMaster.BtnConfirm.Visible = False
                Close()
            End If
        End If
        Cursor = Cursors.Default
    End Sub
    'Cancel
    Private Sub BtnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCancel.Click
        Close()
    End Sub

    Private Sub FormPopUpContact_FormClosed(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub GVCompany_ColumnFilterChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GVCompany.ColumnFilterChanged
        view_contact(GVCompany.GetFocusedRowCellDisplayText("id_comp").ToString)
    End Sub

    Private Sub BAddComp_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BAddComp.Click
        FormMasterCompanySingle.id_company = "-1"
        FormMasterCompanySingle.id_pop_up = "1"
        FormMasterCompanySingle.ShowDialog()
    End Sub

    Private Sub BEditComp_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BEditComp.Click
        FormMasterCompanySingle.id_company = GVCompany.GetFocusedRowCellValue("id_comp").ToString
        FormMasterCompanySingle.id_pop_up = "1"
        FormMasterCompanySingle.ShowDialog()
    End Sub

    Private Sub BDelComp_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BDelComp.Click
        Dim confirm As DialogResult
        Dim query As String

        confirm = DevExpress.XtraEditors.XtraMessageBox.Show("Are you sure want to delete this company ?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
        Dim id_company As String = GVCompany.GetFocusedRowCellValue("id_comp").ToString

        If confirm = Windows.Forms.DialogResult.Yes Then
            Cursor = Cursors.WaitCursor
            Try
                query = String.Format("DELETE FROM tb_m_comp WHERE id_comp = '{0}'", id_company)
                execute_non_query(query, True, "", "", "", "")
                view_company()
            Catch ex As Exception
                errorDelete()
            End Try
            Cursor = Cursors.Default
        End If
    End Sub

    Private Sub BContact_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BContact.Click
        FormMasterCompanyContact.id_company = GVCompany.GetFocusedRowCellValue("id_comp").ToString
        FormMasterCompanyContact.id_pop_up = "1"
        FormMasterCompanyContact.ShowDialog()
    End Sub
End Class