Public Class FormPopUpPurchase
    Public id_pop_up As String = "-1"
    Public id_purc As String = "-1"
    '1 = Sample REceive
    '2 = PR
    '3 = Return Out Supplier Sample
    '4 = Return In Supplier Sample
    '5 = Packing List Sample

    Private Sub FormPopUpPurchase_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'view_sample_purc()
        'If id_purc <> "-1" Then
        '    GVSamplePurchase.FocusedRowHandle = find_row(GVSamplePurchase, "id_sample_purc", id_purc)
        'End If
        If id_pop_up = "1" Or id_pop_up = "2" Or id_pop_up = "3" Or id_pop_up = "5" Or id_pop_up = "4" Then
            view_sample_purc()
            If id_purc <> "-1" Then
                GVSamplePurchase.FocusedRowHandle = find_row(GVSamplePurchase, "id_sample_purc", id_purc)
            End If
        End If
        'ElseIf id_pop_up = "2" Then
        '    view_sample_purc()
        '    If id_purc <> "-1" Then
        '        GVSamplePurchase.FocusedRowHandle = find_row(GVSamplePurchase, "id_sample_purc", id_purc)
        '    End If
        'ElseIf id_pop_up = "3" Then
        '    view_sample_purc()
        '    If id_purc <> "-1" Then
        '        GVSamplePurchase.FocusedRowHandle = find_row(GVSamplePurchase, "id_sample_purc", id_purc)
        '    End If
        'ElseIf id_pop_up = "4" Then
        '    view_sample_purc()
        '    If id_purc <> "-1" Then
        '        GVSamplePurchase.FocusedRowHandle = find_row(GVSamplePurchase, "id_sample_purc", id_purc)
        '    End If
        'ElseIf id_pop_up = "5" Then
        '    view_sample_purc()
        '    If id_purc <> "-1" Then
        '        GVSamplePurchase.FocusedRowHandle = find_row(GVSamplePurchase, "id_sample_purc", id_purc)
        '    End If
        'End If
    End Sub
    Sub view_sample_purc()
        Dim query = "SELECT a.id_sample_purc, "
        query += "a.id_season_orign, "
        query += "b.season_orign, g.payment,"
        query += "f.comp_name AS comp_name_ship_to, "
        query += "a.id_comp_contact_ship_to, "
        query += "f.comp_number AS comp_code_ship_to, "
        query += "d.comp_name AS comp_name_to, "
        query += "d.comp_number AS comp_number_to, "
        query += "d.address_primary AS address_primary_to, "
        query += "a.sample_purc_number, a.id_comp_contact_to, "
        query += "DATE_FORMAT(a.sample_purc_date,'%d %M %Y') AS sample_purc_date, "
        query += "DATE_FORMAT(DATE_ADD(a.sample_purc_date,INTERVAL a.sample_purc_lead_time DAY),'%d %M %Y') AS sample_purc_lead_time, "
        query += "DATE_FORMAT(DATE_ADD(a.sample_purc_date,INTERVAL (a.sample_purc_top+a.sample_purc_lead_time) DAY),'%d %M %Y') AS sample_purc_top "
        query += "FROM tb_sample_purc a INNER JOIN tb_season_orign b ON a.id_season_orign = b.id_season_orign "
        query += "INNER JOIN tb_m_comp_contact c ON a.id_comp_contact_to = c.id_comp_contact "
        query += "INNER JOIN tb_m_comp d ON c.id_comp = d.id_comp "
        query += "INNER JOIN tb_m_comp_contact e ON a.id_comp_contact_ship_to = e.id_comp_contact "
        query += "INNER JOIN tb_m_comp f ON e.id_comp = f.id_comp "
        query += "INNER JOIN tb_lookup_payment g ON a.id_payment = g.id_payment "
        query += "WHERE a.id_report_status = '6'"

        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCSamplePurchase.DataSource = data
        If data.Rows.Count > 0 Then
            'show all
            BSave.Enabled = True
            view_list_purchase(GVSamplePurchase.GetFocusedRowCellValue("id_sample_purc").ToString)
        Else
            BSave.Enabled = False
        End If
    End Sub
    Sub view_list_purchase(ByVal id_sample_purc As String)
        Dim query As String
        If id_pop_up = "1" Then
            query = "CALL view_purc_sample_det_limit('" & id_sample_purc & "')"
        Else
            query = "CALL view_purc_sample_det('" & id_sample_purc & "')"
        End If
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCListPurchase.DataSource = data
        If data.Rows.Count > 0 Then
            BSave.Enabled = True
        Else
            BSave.Enabled = False
        End If
    End Sub

    Private Sub GVSamplePurchase_RowClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Grid.RowClickEventArgs) Handles GVSamplePurchase.RowClick
        view_list_purchase(GVSamplePurchase.GetFocusedRowCellValue("id_sample_purc").ToString)
    End Sub

    Private Sub GVSamplePurchase_FocusedRowChanged(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles GVSamplePurchase.FocusedRowChanged
        Dim focusedRowHandle As Integer = -1
        If e.FocusedRowHandle = DevExpress.XtraGrid.GridControl.NewItemRowHandle OrElse e.FocusedRowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
            Return
        End If
        Dim view As DevExpress.XtraGrid.Views.Grid.GridView = CType(sender, DevExpress.XtraGrid.Views.Grid.GridView)
        If e.FocusedRowHandle < 0 Then
            If e.PrevFocusedRowHandle = DevExpress.XtraGrid.GridControl.InvalidRowHandle Then
                focusedRowHandle = 0
            ElseIf Control.MouseButtons = MouseButtons.Left OrElse Control.MouseButtons = MouseButtons.Right Then
                focusedRowHandle = e.PrevFocusedRowHandle
            Else
                Dim prevRow As Integer = view.GetVisibleIndex(e.PrevFocusedRowHandle)
                Dim currRow As Integer = view.GetVisibleIndex(e.FocusedRowHandle)
                If prevRow > currRow Then
                    focusedRowHandle = e.PrevFocusedRowHandle - 1
                Else
                    focusedRowHandle = e.PrevFocusedRowHandle + 1
                End If
                If focusedRowHandle < 0 Then
                    focusedRowHandle = 0
                End If
                If focusedRowHandle >= view.DataRowCount Then
                    focusedRowHandle = view.DataRowCount - 1
                End If
            End If
            If focusedRowHandle < 0 Then
                view.FocusedRowHandle = 0
            Else
                view.FocusedRowHandle = focusedRowHandle
            End If
        End If
    End Sub

    Private Sub BSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BSave.Click
        If id_pop_up = "1" Then
            FormSampleReceiveDet.id_order = GVSamplePurchase.GetFocusedRowCellValue("id_sample_purc").ToString
            '
            Dim query As String = String.Format("SELECT sample_purc_vat,id_season_orign,sample_purc_number,id_comp_contact_to,id_comp_contact_ship_to,id_po_type,id_payment,DATE_FORMAT(sample_purc_date,'%Y-%m-%d') as sample_purc_datex,sample_purc_lead_time,sample_purc_top,id_currency,sample_purc_note FROM tb_sample_purc WHERE id_sample_purc = '{0}'", GVSamplePurchase.GetFocusedRowCellValue("id_sample_purc").ToString)
            Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
            Dim date_created As String = ""

            FormSampleReceiveDet.TEPONumber.Text = data.Rows(0)("sample_purc_number").ToString
            FormSampleReceiveDet.id_comp_from = data.Rows(0)("id_comp_contact_to").ToString
            FormSampleReceiveDet.TECompName.Text = get_company_x(get_id_company(data.Rows(0)("id_comp_contact_to").ToString), "1")

            FormSampleReceiveDet.id_comp_to = GVSamplePurchase.GetFocusedRowCellValue("id_comp_contact_ship_to").ToString
            FormSampleReceiveDet.TECompShipToName.Text = GVSamplePurchase.GetFocusedRowCellValue("comp_name_ship_to").ToString


            date_created = data.Rows(0)("sample_purc_datex").ToString
            FormSampleReceiveDet.TEOrderDate.Text = view_date_from(date_created, 0)
            FormSampleReceiveDet.TEEstRecDate.Text = view_date_from(date_created, Integer.Parse(data.Rows(0)("sample_purc_lead_time").ToString))

            FormSampleReceiveDet.GroupControl2.Enabled = True
            FormSampleReceiveDet.view_list_purchase()
            FormSampleReceiveDet.GroupControlScannedItem.Enabled = True
            FormSampleReceiveDet.viewDetailBC()
            FormSampleReceiveDet.allowDelete()
            Close()
        ElseIf id_pop_up = "2" Then
            FormSamplePRDet.id_purc = GVSamplePurchase.GetFocusedRowCellValue("id_sample_purc").ToString

            FormSamplePRDet.view_po()
            FormSamplePRDet.view_list_purchase()
            FormSamplePRDet.GConListPurchase.Enabled = True
            Close()
        ElseIf id_pop_up = "3" Then
            FormSampleRetOutSingle.id_sample_purc = GVSamplePurchase.GetFocusedRowCellDisplayText("id_sample_purc").ToString
            FormSampleRetOutSingle.TxtOrderNumber.Text = GVSamplePurchase.GetFocusedRowCellDisplayText("sample_purc_number").ToString
            FormSampleRetOutSingle.id_comp_contact_to = GVSamplePurchase.GetFocusedRowCellDisplayText("id_comp_contact_to").ToString
            FormSampleRetOutSingle.TxtNameCompTo.Text = GVSamplePurchase.GetFocusedRowCellDisplayText("comp_name_to").ToString
            FormSampleRetOutSingle.TxtCodeCompTo.Text = GVSamplePurchase.GetFocusedRowCellValue("comp_number_to").ToString
            FormSampleRetOutSingle.MEAdrressCompTo.Text = GVSamplePurchase.GetFocusedRowCellValue("address_primary_to").ToString
            FormSampleRetOutSingle.GroupControlRet.Enabled = True
            FormSampleRetOutSingle.viewDetailReturn()
            FormSampleRetOutSingle.deleteRows()
            FormSampleRetOutSingle.id_sample_purc_det_list.Clear()
            Close()
        ElseIf id_pop_up = "4" Then
            FormSampleRetInSingle.id_sample_purc = GVSamplePurchase.GetFocusedRowCellDisplayText("id_sample_purc").ToString
            FormSampleRetInSingle.TxtOrderNumber.Text = GVSamplePurchase.GetFocusedRowCellDisplayText("sample_purc_number").ToString
            FormSampleRetInSingle.id_comp_contact_from = GVSamplePurchase.GetFocusedRowCellDisplayText("id_comp_contact_to").ToString
            FormSampleRetInSingle.TxtNameCompFrom.Text = GVSamplePurchase.GetFocusedRowCellDisplayText("comp_name_to").ToString
            FormSampleRetInSingle.TxtCodeCompFrom.Text = GVSamplePurchase.GetFocusedRowCellValue("comp_number_to").ToString
            'FormSampleRetOutSingle.MEAdrressCompTo.Text = GVSamplePurchase.GetFocusedRowCellValue("address_primary_to").ToString
            FormSampleRetInSingle.GroupControlRet.Enabled = True
            FormSampleRetInSingle.viewDetailReturn()
            FormSampleRetInSingle.deleteRows()
            FormSampleRetInSingle.id_sample_purc_det_list.Clear()
            'MsgBox(FormSampleRetInSingle.id_sample_purc)
            Close()
        ElseIf id_pop_up = "5" Then
            FormSamplePLSingle.id_comp_contact_from = GVSamplePurchase.GetFocusedRowCellValue("id_comp_contact_ship_to").ToString
            FormSamplePLSingle.TxtCodeCompFrom.Text = GVSamplePurchase.GetFocusedRowCellValue("comp_name_ship_to").ToString
            FormSamplePLSingle.TxtNameCompFrom.Text = GVSamplePurchase.GetFocusedRowCellValue("comp_code_ship_to").ToString
            FormSamplePLSingle.id_sample_purc = GVSamplePurchase.GetFocusedRowCellDisplayText("id_sample_purc").ToString
            FormSamplePLSingle.TxtOrderNumber.Text = GVSamplePurchase.GetFocusedRowCellDisplayText("sample_purc_number").ToString
            FormSamplePLSingle.GConListPL.Enabled = True
            FormSamplePLSingle.GCReceiving.Enabled = True
            FormSamplePLSingle.viewListRec()
            FormSamplePLSingle.viewReceiving()
            Dispose()
        End If
    End Sub

    Private Sub FormPopUpPurchase_FormClosed(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub BCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BCancel.Click
        Close()
    End Sub

    Private Sub GVListPurchase_CustomColumnDisplayText(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs) Handles GVListPurchase.CustomColumnDisplayText
        If e.Column.FieldName = "no" Then
            e.DisplayText = (e.ListSourceRowIndex + 1).ToString()
        End If
    End Sub
End Class