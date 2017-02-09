Public Class FormSalesDelOrderSlip
    Public direct_menu As Boolean = False
    Public action As String
    Public id_pl_sales_order_del_slip As String = "-1"
    Public id_store_contact_to As String = "-1"
    Public id_comp_contact_from As String = "-1"
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
                TxtNameCompFrom.Text = FormSalesDelOrderDet.TxtNameCompFrom.Text
                TxtCodeCompFrom.Text = FormSalesDelOrderDet.TxtCodeCompFrom.Text
                TxtNameCompTo.Text = FormSalesDelOrderDet.TxtNameCompTo.Text
                TxtCodeCompTo.Text = FormSalesDelOrderDet.TxtCodeCompTo.Text
                MEAdrressCompTo.Text = FormSalesDelOrderDet.MEAdrressCompTo.Text
                TxtCodeCompFrom.Properties.ReadOnly = True
                TxtCodeCompTo.Properties.ReadOnly = True
                viewSalesDelOrder()
                GCSalesDelOrder.Focus()
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
End Class