Public Class FormSalesDelOrderSlip
    Public direct_menu As Boolean = False
    Public action As String
    Public id_pl_sales_order_del_slip As String = "-1"
    Public id_store_contact_to As String = "-1"
    Public id_comp_contact_from As String = "-1"
    Public id_wh_drawer As String = "-1"
    Public id_report_status As String
    Public id_pl_sales_order_del_slip_det_list As New List(Of String)
    Public id_pre As String = "-1"
    Public bof_column As String = get_setup_field("bof_column")
    Public bof_xls_so As String = get_setup_field("bof_xls_do")

    Private Sub FormSalesDelOrderSlip_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        viewReportStatus()
        actionLoad()
    End Sub

    Sub actionLoad()
        If Action = "ins" Then
            'TxtSalesDelOrderNumber.Text = header_number_sales("3")
            BtnPrint.Enabled = False
            BMark.Enabled = False
            BtnAttachment.Enabled = False
            DDBPrint.Enabled = False
            DEForm.Text = view_date(0)

            'from pre del
            If direct_menu Then
                id_store_contact_to = FormSalesDelOrderDet.id_store_contact_to
                id_comp_contact_from = FormSalesDelOrderDet.id_comp_contact_from
                id_wh_drawer = FormSalesDelOrderDet.id_wh_drawer
                TxtNameCompFrom.Text = FormSalesDelOrderDet.TxtNameCompFrom.Text
                TxtCodeCompFrom.Text = FormSalesDelOrderDet.TxtCodeCompFrom.Text
                TxtNameCompTo.Text = FormSalesDelOrderDet.TxtNameCompTo.Text
                TxtCodeCompTo.Text = FormSalesDelOrderDet.TxtCodeCompTo.Text
                MEAdrressCompTo.Text = FormSalesDelOrderDet.MEAdrressCompTo.Text
                TxtCodeCompFrom.Properties.ReadOnly = True
                TxtCodeCompTo.Properties.ReadOnly = True
                viewSalesDelOrder()
                GCSalesDelOrder.Focus()
            Else
                TxtCodeCompFrom.Focus()
            End If
        ElseIf Action = "upd" Then
            GroupControlListItem.Enabled = True
            GVItemList.OptionsBehavior.AutoExpandAllGroups = True
            BMark.Enabled = True
            DDBPrint.Enabled = True

            'query view based on edit id's
            'Dim query_c As New ClassSalesDelOrder()
            'Dim query As String = query_c.queryMain("AND a.id_pl_sales_order_del=" + id_pl_sales_order_del + " ", "2")
            'Dim data As DataTable = execute_query(query, "-1", True, "", "", "", "")
            'id_report_status = data.Rows(0)("id_report_status").ToString
            'id_store_contact_to = data.Rows(0)("id_store_contact_to").ToString
            'id_comp_contact_from = data.Rows(0)("id_comp_contact_from").ToString
            'TxtSalesOrder.Text = data.Rows(0)("sales_order_number").ToString
            'TxtNameCompFrom.Text = data.Rows(0)("wh_name").ToString
            'TxtCodeCompFrom.Text = data.Rows(0)("wh_number").ToString
            'TxtNameCompTo.Text = data.Rows(0)("store_name_to").ToString
            'TxtCodeCompTo.Text = data.Rows(0)("store_number_to").ToString
            'MEAdrressCompTo.Text = data.Rows(0)("store_address_to").ToString
            'TxtDrawerCode.Text = data.Rows(0)("wh_drawer_code").ToString
            'TxtDrawer.Text = data.Rows(0)("wh_drawer").ToString
            'DEForm.Text = view_date_from(data.Rows(0)("pl_sales_order_del_datex").ToString, 0)
            'TxtSalesDelOrderNumber.Text = data.Rows(0)("pl_sales_order_del_number").ToString
            'MENote.Text = data.Rows(0)("pl_sales_order_del_note").ToString
            'LEReportStatus.ItemIndex = LEReportStatus.Properties.GetDataSourceRowIndex("id_report_status", data.Rows(0)("id_report_status").ToString)
            'LETypeSO.ItemIndex = LETypeSO.Properties.GetDataSourceRowIndex("id_so_type", data.Rows(0)("id_so_type").ToString)
            'LEStatusSO.ItemIndex = LEStatusSO.Properties.GetDataSourceRowIndex("id_so_status", data.Rows(0)("id_so_status").ToString)
            'id_sales_order = data.Rows(0)("id_sales_order").ToString
            'id_wh_drawer = data.Rows(0)("id_wh_drawer").ToString

            'detail2
            'viewDetail()
            allow_status()

            If id_pre = "1" Then
                prePrinting()
                Close()
            ElseIf id_pre = "2" Then
                Printing()
                Close()
            End If
        End If
    End Sub


    Sub viewSalesDelOrder()
        Dim query_c As ClassSalesDelOrder = New ClassSalesDelOrder()
        Dim query As String = query_c.queryMain("AND a.id_store_contact_to='" + id_store_contact_to + "' AND a.id_comp_contact_from='" + id_comp_contact_from + "' AND a.id_report_status=1 AND a.last_update_by=" + id_user + " ", "1")
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCSalesDelOrder.DataSource = data
    End Sub

    Sub viewReportStatus()
        Dim query As String = "SELECT * FROM tb_lookup_report_status a ORDER BY a.id_report_status "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        viewLookupQuery(LEReportStatus, query, 0, "report_status", "id_report_status")
    End Sub

    Sub viewDetail(ByVal pre_delivery As String)
        Dim query As String = "CALL view_pl_sales_order_del_slip('" + pre_delivery + "') "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCItemList.DataSource = data
    End Sub

    Sub allow_status()
        'If check_edit_report_status(id_report_status, "43", id_pl_sales_order_del) Then
        '    PanelNavBarcode.Enabled = True
        '    MENote.Properties.ReadOnly = False
        '    BtnSave.Enabled = True
        '    BtnVerify.Enabled = True
        '    GVItemList.OptionsCustomization.AllowQuickHideColumns = False
        '    GVItemList.OptionsCustomization.AllowGroup = False
        '    GridColumnQtyLimit.Visible = True
        'Else
        '    PanelNavBarcode.Enabled = False
        '    MENote.Properties.ReadOnly = True
        '    BtnSave.Enabled = False
        '    BtnVerify.Enabled = False
        '    GVItemList.OptionsCustomization.AllowQuickHideColumns = True
        '    GVItemList.Columns("sales_order_det_qty_limit").Visible = False
        '    GVItemList.OptionsCustomization.AllowGroup = True
        '    GridColumnQtyLimit.Visible = False
        'End If

        ''attachment
        'If check_attach_report_status(id_report_status, "43", id_pl_sales_order_del) Then
        '    BtnAttachment.Enabled = True
        'Else
        '    BtnAttachment.Enabled = False
        'End If

        ''pre print
        'If check_pre_print_report_status(id_report_status) Then
        '    BtnPrePrinting.Enabled = True
        'Else
        '    BtnPrePrinting.Enabled = False
        'End If

        ''print
        'If check_print_report_status(id_report_status) Then
        '    BtnPrint.Enabled = True
        'Else
        '    BtnPrint.Enabled = False
        'End If

        'If id_report_status <> "5" And bof_column = "1" Then
        '    BtnXlsBOF.Visible = True
        'Else
        '    BtnXlsBOF.Visible = False
        'End If
        'TxtSalesDelOrderNumber.Focus()
    End Sub

    Sub getReport()
        'GridColumnNo.VisibleIndex = 0
        'GridColumnStatus.Visible = False
        'GridColumnQtyLimit.Visible = False
        'GVItemList.ActiveFilterString = "[pl_sales_order_del_det_qty]>0"
        'For i As Integer = 0 To GVItemList.RowCount - 1
        '    GVItemList.SetRowCellValue(i, "no", (i + 1).ToString)
        'Next
        'GCItemList.RefreshDataSource()
        'GVItemList.RefreshData()
        'ReportSalesDelOrderDet.dt = GCItemList.DataSource
        'ReportSalesDelOrderDet.id_pl_sales_order_del = id_pl_sales_order_del
        'Dim Report As New ReportSalesDelOrderDet()

        '' '... 
        '' ' creating and saving the view's layout to a new memory stream 
        'Dim str As System.IO.Stream
        'str = New System.IO.MemoryStream()
        'GVItemList.SaveLayoutToStream(str, DevExpress.Utils.OptionsLayoutBase.FullLayout)
        'str.Seek(0, System.IO.SeekOrigin.Begin)
        'Report.GVItemList.RestoreLayoutFromStream(str, DevExpress.Utils.OptionsLayoutBase.FullLayout)
        'str.Seek(0, System.IO.SeekOrigin.Begin)

        ''Grid Detail
        'ReportStyleGridview(Report.GVItemList)

        ''Parse val
        'Report.LabelTo.Text = TxtCodeCompTo.Text + "-" + TxtNameCompTo.Text
        'Report.LabelFrom.Text = TxtCodeCompFrom.Text + "-" + TxtNameCompFrom.Text
        'Report.LabelAddress.Text = MEAdrressCompTo.Text
        'Report.LRecDate.Text = DEForm.Text
        'Report.LRecNumber.Text = TxtSalesDelOrderNumber.Text
        'Report.LabelNote.Text = MENote.Text
        'Report.LabelPrepare.Text = TxtSalesOrder.Text
        'Report.LabelCat.Text = LEStatusSO.Text


        ''Show the report's preview. 
        'Dim Tool As DevExpress.XtraReports.UI.ReportPrintTool = New DevExpress.XtraReports.UI.ReportPrintTool(Report)
        'Tool.ShowPreview()
        'GVItemList.ActiveFilterString = ""
        'GridColumnNo.Visible = False
        'GridColumnQtyLimit.Visible = True
    End Sub

    Private Sub BtnPrePrinting_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BtnPrePrinting.ItemClick
        prePrinting()
    End Sub

    Sub prePrinting()
        Cursor = Cursors.WaitCursor
        ReportSalesDelOrderDet.id_pre = "1"
        getReport()
        Cursor = Cursors.Default
    End Sub

    Private Sub BtnPrint_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BtnPrint.ItemClick
        printing()
    End Sub

    Sub printing()
        Cursor = Cursors.WaitCursor
        ReportSalesDelOrderDet.id_pre = "-1"
        getReport()
        Cursor = Cursors.Default
    End Sub

    Private Sub CheckSelAll_CheckedChanged(sender As Object, e As EventArgs) Handles CheckSelAll.CheckedChanged
        If GVSalesDelOrder.RowCount > 0 Then
            Dim cek As String = CheckSelAll.EditValue.ToString
            For i As Integer = 0 To ((GVSalesDelOrder.RowCount - 1) - GetGroupRowCount(GVSalesDelOrder))
                If cek Then
                    GVSalesDelOrder.SetRowCellValue(i, "is_select", "Yes")
                Else
                    GVSalesDelOrder.SetRowCellValue(i, "is_select", "No")
                End If
            Next
        End If
    End Sub

    Private Sub BtnLoad_Click(sender As Object, e As EventArgs) Handles BtnLoad.Click
        GCItemList.DataSource = Nothing
        GVSalesDelOrder.ActiveFilterString = "[is_select]='Yes' "
        If GVSalesDelOrder.RowCount > 0 Then
            Dim predel As String = ""
            For i As Integer = 0 To ((GVSalesDelOrder.RowCount - 1) - GetGroupRowCount(GVSalesDelOrder))
                If i > 0 Then
                    predel += "OR "
                End If
                predel += "k.id_pl_sales_order_del=" + GVSalesDelOrder.GetRowCellValue(i, "id_pl_sales_order_del").ToString + " "
            Next
            viewDetail(predel)
            XTCDel.SelectedTabPageIndex = 1
        End If
        GVSalesDelOrder.ActiveFilterString = ""
    End Sub

    Private Sub TxtCodeCompFrom_KeyDown(sender As Object, e As KeyEventArgs) Handles TxtCodeCompFrom.KeyDown
        If e.KeyCode = Keys.Enter Then
            Dim query_cond As String = "AND (comp.id_comp_cat=5 AND comp.id_departement=6 AND comp.is_active=1) "
            Dim data As DataTable = get_company_by_code(TxtCodeCompFrom.Text, query_cond)
            If data.Rows.Count = 0 Then
                stopCustom("Account not found!")
                id_comp_contact_from = = "-1"
                id_wh_drawer = "-1"
                TxtCodeCompFrom.Text = ""
                TxtNameCompFrom.Text = ""
                TxtCodeCompFrom.Focus()
            Else
                Cursor = Cursors.WaitCursor
                id_comp_contact_from = data.Rows(0)("id_comp_contact").ToString
                id_wh_drawer = data.Rows(0)("id_wh_drawer").ToString
                TxtCodeCompFrom.Text = data.Rows(0)("comp_number").ToString
                TxtNameCompFrom.Text = data.Rows(0)("comp_name").ToString
                TxtCodeCompTo.Focus()
                Cursor = Cursors.Default
            End If
        Else
            If Not direct_menu Then
                GCSalesDelOrder.DataSource = Nothing
                GCItemList.DataSource = Nothing
            End If
        End If
    End Sub

    Private Sub TxtCodeCompTo_KeyDown(sender As Object, e As KeyEventArgs) Handles TxtCodeCompTo.KeyDown
        If e.KeyCode = Keys.Enter Then
            Dim query_cond As String = "AND (comp.id_comp_cat=6 AND comp.is_active=1) "
            Dim data As DataTable = get_company_by_code(TxtCodeCompTo.Text, query_cond)
            If data.Rows.Count = 0 Then
                stopCustom("Account not found!")
                id_store_contact_to = "-1"
                TxtCodeCompTo.Text = ""
                TxtNameCompTo.Text = ""
                MEAdrressCompTo.Text = ""
                TxtCodeCompTo.Focus()
            Else
                Cursor = Cursors.WaitCursor
                id_store_contact_to = data.Rows(0)("id_comp_contact").ToString
                TxtCodeCompTo.Text = data.Rows(0)("comp_number").ToString
                TxtNameCompTo.Text = data.Rows(0)("comp_name").ToString
                MEAdrressCompTo.Text = data.Rows(0)("address_primary").ToString
                viewSalesDelOrder()
                GCSalesDelOrder.Focus()
                Cursor = Cursors.Default
            End If
        Else
            If Not direct_menu Then
                GCSalesDelOrder.DataSource = Nothing
                GCItemList.DataSource = Nothing
            End If
        End If
    End Sub

    Private Sub FormSalesDelOrderSlip_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub BtnCancel_Click(sender As Object, e As EventArgs) Handles BtnCancel.Click
        Close()
    End Sub

    Private Sub BtnSave_Click(sender As Object, e As EventArgs) Handles BtnSave.Click
        makeSafeGV(GVSalesDelOrder)
        makeSafeGV(GVItemList)
        'makeSafeGV(GVBarcode)

        If id_comp_contact_from = "-1" Or id_store_contact_to = "-1" Then
            stopCustom("Warehouse or store can't blank")
        ElseIf GVItemList.RowCount = 0 Then
            errorCustom("Detail data can't blank")
        Else
            Dim confirm As DialogResult = DevExpress.XtraEditors.XtraMessageBox.Show("Are you sure you want to continue this process?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
            If confirm = Windows.Forms.DialogResult.Yes Then
                Cursor = Cursors.WaitCursor
                Dim pl_sales_order_del_slip_note As String = MENote.Text.ToString
                If action = "ins" Then
                    'query main table
                    Dim pl_sales_order_del_slip_number As String = header_number_sales("31")
                    Dim query_main As String = "INSERT tb_pl_sales_order_del_slip(pl_sales_order_del_slip_number, id_comp_contact_from, id_store_contact_to, pl_sales_order_del_slip_date, pl_sales_order_del_slip_note, id_report_status, last_update, last_update_by, id_wh_drawer) "
                    query_main += "VALUES('" + pl_sales_order_del_slip_number + "', '" + id_comp_contact_from + "', '" + id_store_contact_to + "', NOW(), '" + pl_sales_order_del_slip_note + "', '1', NOW(), " + id_user + ", '" + id_wh_drawer + "'); SELECT LAST_INSERT_ID(); "
                    id_pl_sales_order_del_slip = execute_query(query_main, 0, True, "", "", "", "")
                    increase_inc_sales("31")

                    'insert who prepared
                    submit_who_prepared("103", id_pl_sales_order_del_slip, id_user)

                    'Detail return
                    Dim jum_ins_j As Integer = 0
                    Dim query_detail As String = ""
                    If GVSalesDelOrder.RowCount > 0 Then
                        query_detail = "INSERT tb_pl_sales_order_del_slip_det(id_pl_sales_order_del_slip, id_pl_sales_order_del) VALUES "
                    End If
                    For j As Integer = 0 To ((GVSalesDelOrder.RowCount - 1) - GetGroupRowCount(GVSalesDelOrder))
                        Try
                            Dim id_pl_sales_order_del As String = GVSalesDelOrder.GetRowCellValue(j, "id_pl_sales_order_del").ToString

                            If jum_ins_j > 0 Then
                                query_detail += ", "
                            End If
                            query_detail += "('" + id_pl_sales_order_del + "') "
                            jum_ins_j = jum_ins_j + 1
                        Catch ex As Exception
                        End Try
                    Next
                    If GVSalesDelOrder.RowCount > 0 Then
                        execute_non_query(query_detail, True, "", "", "", "")
                    End If

                    FormSalesDelOrder.viewSalesDelSlip()
                    FormSalesDelOrder.GVDel.FocusedRowHandle = find_row(FormSalesDelOrder.GVDel, "id_pl_sales_order_del_slip", id_pl_sales_order_del_slip)
                    action = "upd"
                    actionLoad()
                    exportToBOF(False)
                    infoCustom("Delivery Slip : " + pl_sales_order_del_slip_number + " was created successfully.")
                ElseIf action = "upd" Then
                    'update main table
                    Dim pl_sales_order_del_slip_number As String = TxtSalesDelOrderNumber.Text
                    Dim query_main As String = "UPDATE tb_pl_sales_order_del_slip SET pl_sales_order_del_slip_note = '" + pl_sales_order_del_slip_note + "', last_update=NOW(), last_update_by=" + id_user + " WHERE id_pl_sales_order_del_slip = '" + id_pl_sales_order_del_slip + "'"
                    execute_non_query(query_main, True, "", "", "", "")

                    FormSalesDelOrder.viewSalesDelSlip()
                    FormSalesDelOrder.GVDel.FocusedRowHandle = find_row(FormSalesDelOrder.GVDel, "id_pl_sales_order_del_slip", id_pl_sales_order_del_slip)
                    action = "upd"
                    actionLoad()
                    exportToBOF(False)
                    infoCustom("Delivery Slip : " + pl_sales_order_del_slip_number + " was edited successfully.")
                End If
                Cursor = Cursors.Default
            End If
        End If
    End Sub

    Sub exportToBOF(a As Boolean)

    End Sub
End Class