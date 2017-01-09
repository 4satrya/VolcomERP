Public Class FormWork
    Dim bview_active As String = "1"
    Dim i As Integer = 0
    Private Sub FormWork_Activated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Activated
        FormMain.show_rb(Name)
        check_menu()
    End Sub

    Private Sub FormWork_Deactivate(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Deactivate
        FormMain.hide_rb()
    End Sub

    Private Sub FormWork_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        checkFormAccess(Name)
        DEStart.EditValue = Now
        DEUntil.EditValue = Now
    End Sub
    '=============== begin mark tab =======================
    Private Sub BViewApproval_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BViewApproval.Click
        Cursor = Cursors.WaitCursor
        view_mark_need()
        Cursor = Cursors.Default
    End Sub

    Private Sub BViewHistory_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BViewHistory.Click
        Cursor = Cursors.WaitCursor
        view_mark_history()
        Cursor = Cursors.Default
    End Sub
    Sub view_mark_need()
        Dim query = "SELECT a.id_mark, a.info , a.info_design ,a.info_design_code ,a.info_report , a.report_mark_type , a.id_report , a.id_report_status , c.report_status , b.report_mark_type_name "
        query += ",a.report_mark_start_datetime AS date_time_start "
        query += ",ADDTIME(report_mark_start_datetime,report_mark_lead_time) AS lead_time "
        query += ",ADDTIME(report_mark_start_datetime,report_mark_lead_time) AS raw_lead_time "
        query += ",TIME_TO_SEC(TIMEDIFF(NOW(),((ADDTIME(report_mark_start_datetime,report_mark_lead_time))))) AS time_miss, report_date, report_number "
        query += "FROM tb_report_mark a "
        query += "INNER JOIN tb_lookup_report_mark_type b ON b.report_mark_type = a.report_mark_type "
        query += "INNER JOIN tb_lookup_report_status c ON c.id_report_status = a.id_report_status "
        query += "LEFT JOIN 
                    (
	                    SELECT report_mark_type,id_report,id_mark_asg,COUNT(id_report_mark) AS jml FROM tb_report_mark WHERE id_mark!=1 GROUP BY report_mark_type,id_report,id_mark_asg
                    ) mark ON  a.report_mark_type=mark.report_mark_type AND a.id_report=mark.id_report AND a.id_mark_asg=mark.id_mark_asg "
        query += "WHERE a.id_mark = 1 AND a.id_user ='" & id_user & "' AND NOW()>a.report_mark_start_datetime "
        query += "AND IFNULL(mark.jml,0) < 1 "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")

        GCMarkNeed.DataSource = data
        GVMarkNeed.BestFitColumns()
    End Sub
    Sub view_mark_history()
        Dim date_start, date_until As String

        date_start = Date.Parse(DEStart.EditValue.ToString).ToString("yyyy-MM-dd")
        date_until = Date.Parse(DEUntil.EditValue.ToString).ToString("yyyy-MM-dd")

        Dim query = "SELECT a.id_mark , a.info, a.info_design ,a.info_design_code ,a.info_report , a.report_mark_type , a.id_report , a.id_report_status , c.report_status , b.report_mark_type_name, a.report_mark_datetime "
        query += ",a.report_mark_start_datetime AS date_time_start "
        query += ",ADDTIME(report_mark_start_datetime,report_mark_lead_time) AS lead_time "
        query += ",ADDTIME(report_mark_start_datetime,report_mark_lead_time) AS raw_lead_time "
        query += ",YEAR(a.report_mark_datetime) as y_datetime,MONTHNAME(STR_TO_DATE(MONTH(a.report_mark_datetime), '%m')) as m_datetime "
        query += ",TIME_TO_SEC(TIMEDIFF(NOW(),((ADDTIME(report_mark_start_datetime,report_mark_lead_time))))) AS time_miss, report_date, report_number "
        query += "FROM tb_report_mark a "
        query += "INNER JOIN tb_lookup_report_mark_type b ON b.report_mark_type = a.report_mark_type "
        query += "INNER JOIN tb_lookup_report_status c ON c.id_report_status = a.id_report_status "
        query += "WHERE DATE(a.report_mark_datetime) >='" & date_start & "' AND DATE(a.report_mark_datetime) <='" & date_until & "' AND a.id_mark != 1 AND a.id_user ='" & id_user & "' AND NOT ISNULL(a.report_mark_datetime) ORDER BY a.report_mark_datetime DESC "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")

        GCMarkHistory.DataSource = data
        GVMarkHistory.BestFitColumns()
    End Sub
    Private Sub GVMarkNeed_RowCellStyle(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs) Handles GVMarkNeed.RowCellStyle
        Dim lead_time As String = sender.GetRowCellDisplayText(e.RowHandle, sender.Columns("time_miss"))
        'condition
        If Not lead_time = "" Then
            If Integer.Parse(lead_time) > 0 Then
                e.Appearance.BackColor = Color.Salmon
                e.Appearance.BackColor2 = Color.Salmon
            End If
        End If
    End Sub



    Private Sub GVMarkNeed_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GVMarkNeed.DoubleClick
        view_popup_gv_mark()
    End Sub

    Private Sub GVMarkHistory_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GVMarkHistory.DoubleClick
        view_popup_gv_mark()
    End Sub
    Sub view_popup_gv_mark()
        If XTCMark.SelectedTabPageIndex = 0 Then
            If GVMarkNeed.RowCount > 0 Then
                Dim report_mark_type As String = "-1"
                Dim id_report As String = "-1"

                report_mark_type = GVMarkNeed.GetFocusedRowCellValue("report_mark_type").ToString
                id_report = GVMarkNeed.GetFocusedRowCellValue("id_report").ToString

                Dim showpopup As ClassShowPopUp = New ClassShowPopUp()
                showpopup.report_mark_type = report_mark_type
                showpopup.id_report = id_report
                showpopup.show()
            End If
        Else 'history
            If GVMarkHistory.RowCount > 0 Then
                Dim report_mark_type As String = "-1"
                Dim id_report As String = "-1"

                report_mark_type = GVMarkHistory.GetFocusedRowCellValue("report_mark_type").ToString
                id_report = GVMarkHistory.GetFocusedRowCellValue("id_report").ToString

                Dim showpopup As ClassShowPopUp = New ClassShowPopUp()
                showpopup.report_mark_type = report_mark_type
                showpopup.id_report = id_report
                showpopup.show()
            End If
        End If
    End Sub

    Sub check_menu()
        If XTCGeneral.SelectedTabPageIndex = 0 Then
            'sample
            If XTCMark.SelectedTabPageIndex = 0 Then
                If GVMarkNeed.RowCount < 1 Then
                    'hide
                    bview_active = "0"
                Else
                    bview_active = "1"
                End If
            End If
        ElseIf XTCGeneral.SelectedTabPageIndex = 1 Then
            'sample
            If XTCSample.SelectedTabPageIndex = 0 Then
                'purchase
                If GVSamplePurchase.RowCount < 1 Then
                    'hide
                    bview_active = "0"
                Else
                    bview_active = "1"
                End If
                checkFormAccess(Name)
                button_main_ext("4", bview_active)
            ElseIf XTCSample.SelectedTabPageIndex = 1 Then
                'receive
                If GVSampleReceive.RowCount < 1 Then
                    'hide
                    bview_active = "0"
                Else
                    bview_active = "1"
                End If
                checkFormAccess(Name)
                button_main_ext("4", bview_active)
            ElseIf XTCSample.SelectedTabPageIndex = 2 Then
                'packing list
                If GVSamplePL.RowCount < 1 Then
                    'hide
                    bview_active = "0"
                Else
                    bview_active = "1"
                End If
                checkFormAccess(Name)
                button_main_ext("4", bview_active)
            ElseIf XTCSample.SelectedTabPageIndex = 3 Then
                'payment
                If GVSamplePR.RowCount < 1 Then
                    'hide
                    bview_active = "0"
                Else
                    bview_active = "1"
                End If
                checkFormAccess(Name)
                button_main_ext("4", bview_active)
            ElseIf XTCSample.SelectedTabPageIndex = 4 Then
                'sample req
                If GVListSampleReq.RowCount < 1 Then
                    'hide
                    bview_active = "0"
                Else
                    bview_active = "1"
                End If
                checkFormAccess(Name)
                button_main_ext("4", bview_active)
            ElseIf XTCSample.SelectedTabPageIndex = 5 Then
                'PL DEL
                'MsgBox("PL Delivery")
                If GVListSampleDrawerPLDel.RowCount < 1 Then
                    'hide
                    bview_active = "0"
                Else
                    bview_active = "1"
                End If
                checkFormAccess(Name)
                button_main_ext("4", bview_active)
            ElseIf XTCSample.SelectedTabPageIndex = 6 Then
                'Sampmle Return
                If GVListSampleReturn.RowCount < 1 Then
                    'hide
                    bview_active = "0"
                Else
                    bview_active = "1"
                End If
                checkFormAccess(Name)
                button_main_ext("4", bview_active)
            ElseIf XTCSample.SelectedTabPageIndex = 7 Then
                'Adj In Sample
                If GVAdjSampleIn.RowCount < 1 Then
                    'hide
                    bview_active = "0"
                Else
                    bview_active = "1"
                End If
                checkFormAccess(Name)
                button_main_ext("4", bview_active)
            ElseIf XTCSample.SelectedTabPageIndex = 8 Then
                'Adj Out Sample
                If GVListAdjOutSample.RowCount < 1 Then
                    'hide
                    bview_active = "0"
                Else
                    bview_active = "1"
                End If
                checkFormAccess(Name)
                button_main_ext("4", bview_active)
            ElseIf XTCSample.SelectedTabPageIndex = 9 Then
                'PL SAMPLE DELIVERY TO WH
                If GVSampleDel.RowCount < 1 Then
                    'hide
                    bview_active = "0"
                Else
                    bview_active = "1"
                End If
                checkFormAccess(Name)
                button_main_ext("4", bview_active)
            ElseIf XTCSample.SelectedTabPageIndex = 10 Then
                'REC PL SAMPLE DELIVERY TO WH
                If GVSampleDelRec.RowCount < 1 Then
                    'hide
                    bview_active = "0"
                Else
                    bview_active = "1"
                End If
                checkFormAccess(Name)
                button_main_ext("4", bview_active)
            ElseIf XTCSample.SelectedTabPageIndex = 11 Then
                'SALES SAMPLE ORDER
                If GVSampleOrder.RowCount < 1 Then
                    'hide
                    bview_active = "0"
                Else
                    bview_active = "1"
                End If
                checkFormAccess(Name)
                button_main_ext("4", bview_active)
            ElseIf XTCSample.SelectedTabPageIndex = 12 Then
                'DELIVERY ORDER SAMPLE
                If GVSampleDelOrder.RowCount < 1 Then
                    'hide
                    bview_active = "0"
                Else
                    bview_active = "1"
                End If
                checkFormAccess(Name)
                button_main_ext("4", bview_active)
            End If
        ElseIf XTCGeneral.SelectedTabPageIndex = 2 Then ' Material
            If XTCMaterial.SelectedTabPageIndex = 2 Then
                'payment PR PO Mat 
                If GVMatPRPO.RowCount < 1 Then
                    'hide
                    bview_active = "0"
                Else
                    bview_active = "1"
                End If
                checkFormAccess(Name)
                button_main_ext("4", bview_active)
            ElseIf XTCMaterial.SelectedTabPageIndex = 3 Then
                'payment PR WO Mat 
                If GVMatPRWO.RowCount < 1 Then
                    'hide
                    bview_active = "0"
                Else
                    bview_active = "1"
                End If
                checkFormAccess(Name)
                button_main_ext("4", bview_active)
            ElseIf XTCMaterial.SelectedTabPageIndex = 4 Then
                'Adj In Mat 
                If GVMatAdjIn.RowCount < 1 Then
                    'hide
                    bview_active = "0"
                Else
                    bview_active = "1"
                End If
                checkFormAccess(Name)
                button_main_ext("4", bview_active)
            ElseIf XTCMaterial.SelectedTabPageIndex = 5 Then
                'Adj Out Mat 
                If GVMatAdjOut.RowCount < 1 Then
                    'hide
                    bview_active = "0"
                Else
                    bview_active = "1"
                End If
                checkFormAccess(Name)
                button_main_ext("4", bview_active)
            End If
        ElseIf XTCGeneral.SelectedTabPageIndex = 3 Then 'Production
            If XTCProduction.SelectedTabPageIndex = 0 Then
                'prod demand
                If GVProdDemand.RowCount < 1 Then
                    'hide
                    bview_active = "0"
                Else
                    bview_active = "1"
                End If
                checkFormAccess(Name)
                button_main_ext("4", bview_active)
            ElseIf XTCProduction.SelectedTabPageIndex = 3 Then
                'rec QC
                If GVProdRec.RowCount < 1 Then
                    'hide
                    bview_active = "0"
                Else
                    bview_active = "1"
                End If
                checkFormAccess(Name)
                button_main_ext("4", bview_active)
            ElseIf XTCProduction.SelectedTabPageIndex = 4 Then
                'rec QC
                If GVProdRetOut.RowCount < 1 Then
                    'hide
                    bview_active = "0"
                Else
                    bview_active = "1"
                End If
                checkFormAccess(Name)
                button_main_ext("4", bview_active)
            ElseIf XTCProduction.SelectedTabPageIndex = 5 Then
                'rec QC
                If GVProdRetIn.RowCount < 1 Then
                    'hide
                    bview_active = "0"
                Else
                    bview_active = "1"
                End If
                checkFormAccess(Name)
                button_main_ext("4", bview_active)
            ElseIf XTCProduction.SelectedTabPageIndex = 6 Then
                'PL FG To WH
                If GVProdPLToWH.RowCount < 1 Then
                    'hide
                    bview_active = "0"
                Else
                    bview_active = "1"
                End If
                checkFormAccess(Name)
                button_main_ext("4", bview_active)
            ElseIf XTCProduction.SelectedTabPageIndex = 7 Then
                'REc PL FG To WH
                If GVProdPLToWHRec.RowCount < 1 Then
                    'hide
                    bview_active = "0"
                Else
                    bview_active = "1"
                End If
                checkFormAccess(Name)
                button_main_ext("4", bview_active)
            End If
        ElseIf XTCGeneral.SelectedTabPageIndex = 4 Then
            If XTCSales.SelectedTabPageIndex = 0 Then
            ElseIf XTCSales.SelectedTabPageIndex = 1 Then
                'PROPOSE PRICE
                If GVFGPropose.RowCount < 1 Then
                    'hide
                    bview_active = "0"
                Else
                    bview_active = "1"
                End If
                checkFormAccess(Name)
                button_main_ext("4", bview_active)
            ElseIf XTCSales.SelectedTabPageIndex = 2 Then
                'SALES ORDER
                If GVSalesOrder.RowCount < 1 Then
                    'hide
                    bview_active = "0"
                Else
                    bview_active = "1"
                End If
                checkFormAccess(Name)
                button_main_ext("4", bview_active)
            ElseIf XTCSales.SelectedTabPageIndex = 3 Then
                'SALES ORDER DEL
                If GVSalesDelOrder.RowCount < 1 Then
                    'hide
                    bview_active = "0"
                Else
                    bview_active = "1"
                End If
                checkFormAccess(Name)
                button_main_ext("4", bview_active)
            ElseIf XTCSales.SelectedTabPageIndex = 4 Then
                'SALES RETURN ORDER
                If GVSalesReturnOrder.RowCount < 1 Then
                    'hide
                    bview_active = "0"
                Else
                    bview_active = "1"
                End If
                checkFormAccess(Name)
                button_main_ext("4", bview_active)
            ElseIf XTCSales.SelectedTabPageIndex = 5 Then
                'SALES RETURN
                If GVSalesReturn.RowCount < 1 Then
                    'hide
                    bview_active = "0"
                Else
                    bview_active = "1"
                End If
                checkFormAccess(Name)
                button_main_ext("4", bview_active)
            ElseIf XTCSales.SelectedTabPageIndex = 6 Then
                'SALES POS
                If GVSalesPOS.RowCount < 1 Then
                    'hide
                    bview_active = "0"
                Else
                    bview_active = "1"
                End If
                checkFormAccess(Name)
                button_main_ext("4", bview_active)
            ElseIf XTCSales.SelectedTabPageIndex = 7 Then
                'SALES CREDIT NOTE
                If GVSalesCreditNote.RowCount < 1 Then
                    'hide
                    bview_active = "0"
                Else
                    bview_active = "1"
                End If
                checkFormAccess(Name)
                button_main_ext("4", bview_active)
            ElseIf XTCSales.SelectedTabPageIndex = 8 Then
                'SALES RETURN QC
                If GVSalesReturnQC.RowCount < 1 Then
                    'hide
                    bview_active = "0"
                Else
                    bview_active = "1"
                End If
                checkFormAccess(Name)
                button_main_ext("4", bview_active)
            ElseIf XTCSales.SelectedTabPageIndex = 9 Then
                'SALES INVOICE
                If GVSalesInvoice.RowCount < 1 Then
                    'hide
                    bview_active = "0"
                Else
                    bview_active = "1"
                End If
                checkFormAccess(Name)
                button_main_ext("4", bview_active)
            ElseIf XTCSales.SelectedTabPageIndex = 10 Then
                'FG SO STORE
                If GVSOStore.RowCount < 1 Then
                    'hide
                    bview_active = "0"
                Else
                    bview_active = "1"
                End If
                checkFormAccess(Name)
                button_main_ext("4", bview_active)
            ElseIf XTCSales.SelectedTabPageIndex = 11 Then
                'FG MISSING
                If GVFGMissing.RowCount < 1 Then
                    'hide
                    bview_active = "0"
                Else
                    bview_active = "1"
                End If
                checkFormAccess(Name)
                button_main_ext("4", bview_active)
            ElseIf XTCSales.SelectedTabPageIndex = 12 Then
                'FG MISSING
                If GVFGMissingCNStore.RowCount < 1 Then
                    'hide
                    bview_active = "0"
                Else
                    bview_active = "1"
                End If
                checkFormAccess(Name)
                button_main_ext("4", bview_active)
            ElseIf XTCSales.SelectedTabPageIndex = 13 Then
                'FG SO WH
                If GVFGSOWH.RowCount < 1 Then
                    'hide
                    bview_active = "0"
                Else
                    bview_active = "1"
                End If
                checkFormAccess(Name)
                button_main_ext("4", bview_active)
            ElseIf XTCSales.SelectedTabPageIndex = 14 Then
                'FG ADJ IN
                If GVFGAdjIn.RowCount < 1 Then
                    'hide
                    bview_active = "0"
                Else
                    bview_active = "1"
                End If
                checkFormAccess(Name)
                button_main_ext("4", bview_active)
            ElseIf XTCSales.SelectedTabPageIndex = 15 Then
                'FG ADJ Out
                If GVFGAdjOut.RowCount < 1 Then
                    'hide
                    bview_active = "0"
                Else
                    bview_active = "1"
                End If
                checkFormAccess(Name)
                button_main_ext("4", bview_active)
            ElseIf XTCSales.SelectedTabPageIndex = 16 Then
                'FG TRf
                If GVFGTrf.RowCount < 1 Then
                    'hide
                    bview_active = "0"
                Else
                    bview_active = "1"
                End If
                checkFormAccess(Name)
                button_main_ext("4", bview_active)
            ElseIf XTCSales.SelectedTabPageIndex = 17 Then
                'FG TRf REC
                If GVFGTrfRec.RowCount < 1 Then
                    'hide
                    bview_active = "0"
                Else
                    bview_active = "1"
                End If
                checkFormAccess(Name)
                button_main_ext("4", bview_active)
            ElseIf XTCSales.SelectedTabPageIndex = 18 Then
                'FG CODE REPLACE
                If GVFGCodeReplaceStore.RowCount < 1 Then
                    'hide
                    bview_active = "0"
                Else
                    bview_active = "1"
                End If
                checkFormAccess(Name)
                button_main_ext("4", bview_active)
            ElseIf XTCSales.SelectedTabPageIndex = 19 Then
                'FG CODE REPLACE WH
                If GVFGCodeReplaceWH.RowCount < 1 Then
                    'hide
                    bview_active = "0"
                Else
                    bview_active = "1"
                End If
                checkFormAccess(Name)
                button_main_ext("4", bview_active)
            ElseIf XTCSales.SelectedTabPageIndex = 20 Then
                'FG WRITE OFF
                If GVFGWoff.RowCount < 1 Then
                    'hide
                    bview_active = "0"
                Else
                    bview_active = "1"
                End If
                checkFormAccess(Name)
                button_main_ext("4", bview_active)
            End If
        End If
    End Sub

    Private Sub GVMarkHistory_FocusedRowChanged(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles GVMarkHistory.FocusedRowChanged
        no_focus_gv(sender, e)
    End Sub
    Sub no_focus_gv(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs)
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
    '=============== end mark tab =========================
    '=============== begin purchase sample ================
    Sub view_sample_purc()
        Dim query = "SELECT a.id_sample_purc,a.id_report_status,h.report_status, "
        query += "a.id_season_orign, "
        query += "b.season_orign, g.payment,"
        query += "d.comp_name AS comp_name_to, "
        query += "f.comp_name AS comp_name_ship_to, "
        query += "a.sample_purc_number,"
        query += "DATE_FORMAT(NOW(),'%d %M %Y') as date_now,"
        query += "(SELECT COUNT(tb_sample_purc_rec.id_sample_purc_rec) FROM tb_sample_purc_rec WHERE tb_sample_purc_rec.id_sample_purc=a.id_sample_purc) AS rec_created,"
        query += "(SELECT COUNT(tb_pr_sample_purc.id_pr_sample_purc) FROM tb_pr_sample_purc WHERE tb_pr_sample_purc.id_sample_purc=a.id_sample_purc) AS pr_created,"
        query += "DATE_FORMAT(a.sample_purc_date,'%d %M %Y') AS sample_purc_date, "
        query += "DATE_FORMAT(DATE_ADD(a.sample_purc_date,INTERVAL a.sample_purc_lead_time DAY),'%d %M %Y') AS sample_purc_lead_time, "
        query += "DATE_FORMAT(DATE_ADD(a.sample_purc_date,INTERVAL (a.sample_purc_top+a.sample_purc_lead_time) DAY),'%d %M %Y') AS sample_purc_top "
        query += "FROM tb_sample_purc a INNER JOIN tb_season_orign b ON a.id_season_orign = b.id_season_orign "
        query += "INNER JOIN tb_m_comp_contact c ON a.id_comp_contact_to = c.id_comp_contact "
        query += "INNER JOIN tb_m_comp d ON c.id_comp = d.id_comp "
        query += "INNER JOIN tb_m_comp_contact e ON a.id_comp_contact_ship_to = e.id_comp_contact "
        query += "INNER JOIN tb_m_comp f ON e.id_comp = f.id_comp "
        query += "INNER JOIN tb_lookup_report_status h ON h.id_report_status = a.id_report_status "
        query += "INNER JOIN tb_lookup_payment g ON a.id_payment = g.id_payment ORDER BY a.id_sample_purc DESC"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCSamplePurchase.DataSource = data
        check_menu()
        If data.Rows.Count > 0 Then
            'show all
            BViewReceivingSample.Visible = True
            BViewPRSample.Visible = True
            '
            BGotoSamplePayment.Visible = True
            BGotoSampleReceive.Visible = True
            BGotoSamplePurchase.Visible = True
            '
            GVSamplePurchase.FocusedRowHandle = 0
            view_list_purchase(GVSamplePurchase.GetFocusedRowCellValue("id_sample_purc").ToString)
        Else
            BViewReceivingSample.Visible = False
            BViewPRSample.Visible = False
            '
            BGotoSamplePurchase.Visible = False
            BGotoSampleReceive.Visible = False
            BGotoSamplePayment.Visible = False
        End If
    End Sub
    Sub view_list_purchase(ByVal id_sample_purc As String)
        Dim query = "CALL view_purc_sample_det('" & id_sample_purc & "')"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCListSamplePurchase.DataSource = data
    End Sub
    Private Sub BRefSamplePurc_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BRefSamplePurc.Click
        GVSamplePurchase.ApplyFindFilter("")
        view_sample_purc()
    End Sub
    Private Sub GVSamplePurchase_RowCellStyle(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs) Handles GVSamplePurchase.RowCellStyle
        Dim View As DevExpress.XtraGrid.Views.Grid.GridView = sender

        Dim date_now As Date
        Dim date_rec As Date
        Dim date_pr As Date

        If e.Column.FieldName = "pr_created" Then
            date_now = Date.Parse(View.GetRowCellDisplayText(e.RowHandle, View.Columns("date_now")))
            date_pr = Date.Parse(View.GetRowCellDisplayText(e.RowHandle, View.Columns("sample_purc_top")))
            If date_now > date_pr And View.GetRowCellDisplayText(e.RowHandle, View.Columns("pr_created")) <= 0 Then
                e.Appearance.BackColor = Color.Red
                e.Appearance.BackColor2 = Color.LightSalmon
            End If
        End If

        If e.Column.FieldName = "rec_created" Then
            date_now = Date.Parse(View.GetRowCellDisplayText(e.RowHandle, View.Columns("date_now")))
            date_rec = Date.Parse(View.GetRowCellDisplayText(e.RowHandle, View.Columns("sample_purc_lead_time")))
            If date_now > date_rec And View.GetRowCellDisplayText(e.RowHandle, View.Columns("rec_created")) <= 0 Then
                e.Appearance.BackColor = Color.Red
                e.Appearance.BackColor2 = Color.LightSalmon
            End If
        End If
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
    Private Sub GVListSamplePurchase_CustomColumnDisplayText(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs) Handles GVListSamplePurchase.CustomColumnDisplayText
        If e.Column.FieldName = "no" Then
            e.DisplayText = (e.ListSourceRowIndex + 1).ToString()
        End If
    End Sub
    Private Sub GVSamplePurchase_RowClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Grid.RowClickEventArgs) Handles GVSamplePurchase.RowClick
        Try
            view_list_purchase(GVSamplePurchase.GetFocusedRowCellValue("id_sample_purc").ToString)
        Catch ex As Exception
        End Try
    End Sub
    Private Sub BViewReceivingSample_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BViewReceivingSample.Click
        If GVSamplePurchase.RowCount > 0 Then
            GVSampleReceive.ApplyFindFilter("")
            view_sample_rec()
            GVSampleReceive.ApplyFindFilter(GVSamplePurchase.GetFocusedRowCellValue("sample_purc_number").ToString)
            XTCSample.SelectedTabPageIndex = 1
            If GVSampleReceive.RowCount > 0 Then
                Try
                    view_list_rec(GVSampleReceive.GetFocusedRowCellValue("id_sample_purc_rec").ToString)
                Catch ex As Exception
                End Try
            Else
                view_list_rec("-1")
            End If
        End If
    End Sub
    Private Sub BViewPRSample_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BViewPRSample.Click
        If GVSamplePurchase.RowCount > 0 Then
            GVSamplePR.ApplyFindFilter("")
            view_sample_pr()
            GVSamplePR.ApplyFindFilter(GVSamplePurchase.GetFocusedRowCellValue("sample_purc_number").ToString)
            XTCSample.SelectedTabPageIndex = 3
            'If GVSamplePR.RowCount > 0 Then
            '    Try
            '        view_list_pr(GVSamplePR.GetFocusedRowCellValue("id_pr_sample_purc").ToString)
            '    Catch ex As Exception
            '    End Try
            'Else
            '    view_list_pr("-1")
            'End If
        End If
    End Sub
    Private Sub GVSamplePR_CustomDrawEmptyForeground(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.CustomDrawEventArgs) Handles GVSamplePR.CustomDrawEmptyForeground
        Dim view As DevExpress.XtraGrid.Views.Grid.GridView = sender

        If Not view.RowCount = 0 Then
            Return
        End If

        Dim drawFormat As StringFormat = New StringFormat

        drawFormat.Alignment = drawFormat.LineAlignment = StringAlignment.Center
        e.Graphics.DrawString("No items exist", e.Appearance.Font, SystemBrushes.ControlDark, New RectangleF(e.Bounds.X, e.Bounds.Y, e.Bounds.Width, e.Bounds.Height), drawFormat)
    End Sub

    Private Sub GVSamplePR_ColumnFilterChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GVSamplePR.ColumnFilterChanged
        If GVSamplePR.RowCount > 0 Then
            Try
                view_list_pr(GVSamplePR.GetFocusedRowCellValue("id_pr_sample_purc").ToString)
            Catch ex As Exception
            End Try
        Else
            view_list_pr("-1")
        End If
    End Sub

    Private Sub BGotoSamplePurchase_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BGotoSamplePurchase.Click
        Cursor = Cursors.WaitCursor
        Try
            FormSamplePurchase.MdiParent = FormMain
            FormSamplePurchase.Show()
            FormSamplePurchase.WindowState = FormWindowState.Maximized
            FormSamplePurchase.Focus()
        Catch ex As Exception
            errorProcess()
        End Try
        Cursor = Cursors.Default

        FormSamplePurchase.GVSamplePurchase.FocusedRowHandle = find_row(FormSamplePurchase.GVSamplePurchase, "id_sample_purc", GVSamplePurchase.GetFocusedRowCellValue("id_sample_purc").ToString())
    End Sub

    Private Sub BGotoSampleReceive_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BGotoSampleReceive.Click
        If GVSamplePurchase.GetFocusedRowCellValue("id_report_status").ToString() = "3" Or GVSamplePurchase.GetFocusedRowCellValue("id_report_status").ToString() = "4" Then
            Cursor = Cursors.WaitCursor
            Try
                FormSampleReceive.MdiParent = FormMain
                FormSampleReceive.Show()
                FormSampleReceive.WindowState = FormWindowState.Maximized
                FormSampleReceive.Focus()
                '
                FormSampleReceive.XTCTabReceive.SelectedTabPageIndex = 1
                FormSampleReceive.GVSamplePurchaseNeed.FocusedRowHandle = find_row(FormSampleReceive.GVSamplePurchaseNeed, "id_sample_purc", GVSamplePurchase.GetFocusedRowCellValue("id_sample_purc").ToString())
                '
            Catch ex As Exception
                errorProcess()
            End Try
            Cursor = Cursors.Default
        Else
            stopCustom("This purchase order must be on approved or on process status.")
        End If
    End Sub

    Private Sub BGotoSamplePayment_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BGotoSamplePayment.Click
        If GVSamplePurchase.GetFocusedRowCellValue("id_report_status").ToString() = "3" Or GVSamplePurchase.GetFocusedRowCellValue("id_report_status").ToString() = "4" Then
            Cursor = Cursors.WaitCursor
            Try
                FormSamplePR.MdiParent = FormMain
                FormSamplePR.Show()
                FormSamplePR.WindowState = FormWindowState.Maximized
                FormSamplePR.Focus()
                '
                FormSamplePR.XTCTabPR.SelectedTabPageIndex = 1
                FormSamplePR.GVSamplePurchaseNeed.FocusedRowHandle = find_row(FormSamplePR.GVSamplePurchaseNeed, "id_sample_purc", GVSamplePurchase.GetFocusedRowCellValue("id_sample_purc").ToString())
                '
            Catch ex As Exception
                errorProcess()
            End Try
            Cursor = Cursors.Default
        Else
            stopCustom("This purchase order must be on approved or on process status.")
        End If
    End Sub
    '================== end purchase sample =======================

    '================== begin receive sample ======================
    Sub view_sample_rec()
        Dim query = "SELECT NOW() as date_now,a.id_report_status,h.report_status,g.season_orign,a.id_sample_purc_rec,a.sample_purc_rec_number,DATE_FORMAT(a.delivery_order_date,'%d %M %Y') AS delivery_order_date,a.delivery_order_number,b.sample_purc_number,DATE_FORMAT(a.sample_purc_rec_date,'%d %M %Y') AS sample_purc_rec_date, f.comp_name AS comp_from,d.comp_name AS comp_to "
        query += ",(SELECT COUNT(tb_pr_sample_purc.id_pr_sample_purc) FROM tb_pr_sample_purc WHERE tb_pr_sample_purc.id_sample_purc_rec=a.id_sample_purc_rec) AS pr_created,g.id_season_orign,g.season_orign, "
        query += "DATE_FORMAT(DATE_ADD(b.sample_purc_date,INTERVAL (b.sample_purc_top+b.sample_purc_lead_time) DAY),'%d %M %Y') AS sample_purc_top "
        query += "FROM tb_sample_purc_rec a INNER JOIN tb_sample_purc b ON a.id_sample_purc=b.id_sample_purc "
        query += "INNER JOIN tb_m_comp_contact c ON c.id_comp_contact=a.id_comp_contact_to "
        query += "INNER JOIN tb_m_comp d ON d.id_comp=c.id_comp "
        query += "INNER JOIN tb_m_comp_contact e ON e.id_comp_contact=b.id_comp_contact_to "
        query += "INNER JOIN tb_m_comp f ON f.id_comp=e.id_comp "
        query += "INNER JOIN tb_season_orign g ON g.id_season_orign=b.id_season_orign "
        query += "INNER JOIN tb_lookup_report_status h ON a.id_report_status=h.id_report_status "

        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCSampleReceive.DataSource = data
        check_menu()
        If data.Rows.Count > 0 Then
            GVSampleReceive.FocusedRowHandle = 0
            view_list_rec(GVSampleReceive.GetFocusedRowCellValue("id_sample_purc_rec").ToString)
            '
            BGotoSampleReceiveRec.Visible = True
            BGotoSamplePaymentRec.Visible = True

            '
        Else
            '
            BGotoSamplePaymentRec.Visible = False
            BGotoSampleReceiveRec.Visible = False
            '
        End If
    End Sub
    Sub view_list_rec(ByVal id_sample_purc_rec As String)
        Dim query = "CALL view_purc_rec_sample_det('" & id_sample_purc_rec & "')"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCListSampleReceive.DataSource = data
    End Sub

    Private Sub GVSampleReceive_RowClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Grid.RowClickEventArgs) Handles GVSampleReceive.RowClick
        Try
            view_list_rec(GVSampleReceive.GetFocusedRowCellValue("id_sample_purc_rec").ToString)
        Catch ex As Exception
        End Try
    End Sub

    Private Sub GVSampleReceive_FocusedRowChanged(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles GVSampleReceive.FocusedRowChanged
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
    Private Sub GVListSampleReceive_CustomColumnDisplayText(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs) Handles GVListSampleReceive.CustomColumnDisplayText
        If e.Column.FieldName = "no" Then
            e.DisplayText = (e.ListSourceRowIndex + 1).ToString()
        End If
    End Sub
    Private Sub BRefSampleReceive_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BRefSampleReceive.Click
        GVSampleReceive.ApplyFindFilter("")
        view_sample_rec()
    End Sub
    Private Sub BGotoSampleReceiveRec_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BGotoSampleReceiveRec.Click
        Cursor = Cursors.WaitCursor
        Try
            FormSampleReceive.MdiParent = FormMain
            FormSampleReceive.Show()
            FormSampleReceive.WindowState = FormWindowState.Maximized
            FormSampleReceive.Focus()
        Catch ex As Exception
            errorProcess()
        End Try
        Cursor = Cursors.Default

        FormSampleReceive.GVSampleReceive.FocusedRowHandle = find_row(FormSampleReceive.GVSampleReceive, "id_sample_purc_rec", GVSampleReceive.GetFocusedRowCellValue("id_sample_purc_rec").ToString())
    End Sub

    Private Sub BGotoSamplePaymentRec_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BGotoSamplePaymentRec.Click
        If GVSampleReceive.GetFocusedRowCellValue("id_report_status").ToString() = "3" Or GVSampleReceive.GetFocusedRowCellValue("id_report_status").ToString() = "4" Then
            Cursor = Cursors.WaitCursor
            Try
                FormSamplePR.MdiParent = FormMain
                FormSamplePR.Show()
                FormSamplePR.WindowState = FormWindowState.Maximized
                FormSamplePR.Focus()
                '
                FormSamplePR.XTCTabPR.SelectedTabPageIndex = 2
                FormSamplePR.GVSamplePurchaseNeed.FocusedRowHandle = find_row(FormSamplePR.GVMatReceive, "id_sample_purc_rec", GVSampleReceive.GetFocusedRowCellValue("id_sample_purc_rec").ToString())
                '
            Catch ex As Exception
                errorProcess()
            End Try
            Cursor = Cursors.Default
        Else
            stopCustom("This receive report must be on approved or on process status.")
        End If
    End Sub

    Private Sub GVSampleReceive_RowCellStyle(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs) Handles GVSampleReceive.RowCellStyle
        Dim View As DevExpress.XtraGrid.Views.Grid.GridView = sender

        Dim date_now As Date
        Dim date_pr As Date

        If e.Column.FieldName = "pr_created" Then
            date_now = Date.Parse(View.GetRowCellDisplayText(e.RowHandle, View.Columns("date_now")))
            date_pr = Date.Parse(View.GetRowCellDisplayText(e.RowHandle, View.Columns("sample_purc_top")))
            If date_now > date_pr And View.GetRowCellDisplayText(e.RowHandle, View.Columns("pr_created")) <= 0 Then
                e.Appearance.BackColor = Color.Red
                e.Appearance.BackColor2 = Color.LightSalmon
            End If
        End If
    End Sub
    '========================= end receive sample ====================

    '========================= begin payment sample ==================
    Sub view_sample_pr()
        Dim query As String = "SELECT NOW() as date_now,h.report_status,z.id_report_status,z.pr_sample_purc_note,z.id_pr_sample_purc,z.pr_sample_purc_number,DATE_FORMAT(z.pr_sample_purc_date,'%d %M %Y') as pr_sample_purc_date,g.season,a.id_sample_purc_rec,a.sample_purc_rec_number,DATE_FORMAT(a.delivery_order_date,'%d %M %Y') AS delivery_order_date,a.delivery_order_number,b.sample_purc_number,DATE_FORMAT(a.sample_purc_rec_date,'%d %M %Y') AS sample_purc_rec_date, d.comp_name AS comp_to, "
        query += "DATE_FORMAT(DATE_ADD(b.sample_purc_date,INTERVAL (b.sample_purc_top+b.sample_purc_lead_time) DAY),'%d %M %Y') AS sample_purc_top,g.id_season_orign,g.season_orign "
        query += "FROM tb_pr_sample_purc z "
        query += "LEFT JOIN tb_sample_purc_rec a ON z.id_sample_purc_rec = a.id_sample_purc_rec "
        query += "INNER JOIN tb_sample_purc b ON z.id_sample_purc=b.id_sample_purc "
        query += "INNER JOIN tb_m_comp_contact c ON c.id_comp_contact=z.id_comp_contact_to "
        query += "INNER JOIN tb_m_comp d ON d.id_comp=c.id_comp "
        query += "INNER JOIN tb_season_orign g ON g.id_season_orign=b.id_season_orign "
        query += "INNER JOIN tb_lookup_report_status h ON h.id_report_status=z.id_report_status "

        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCSamplePR.DataSource = data
        check_menu()
        If data.Rows.Count > 0 Then
            GVSamplePR.FocusedRowHandle = 0
            view_list_pr_mat_po(GVSamplePR.GetFocusedRowCellValue("id_pr_sample_purc").ToString)
            '
            BSampPRPayment.Visible = True
            '
        Else
            BSampPRPayment.Visible = False
        End If
    End Sub
    Sub view_list_pr_mat_po(ByVal id_prx As String)
        Dim query = "CALL view_pr_sample_from_pr('" & id_prx & "')"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCListSamplePR.DataSource = data
    End Sub
    Private Sub GVSamplePR_RowClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Grid.RowClickEventArgs) Handles GVSamplePR.RowClick
        Try
            view_list_pr(GVSamplePR.GetFocusedRowCellValue("id_pr_sample_purc").ToString)
        Catch ex As Exception
        End Try
    End Sub
    Private Sub GVSamplePR_FocusedRowChanged(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles GVSamplePR.FocusedRowChanged
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

    'Private Sub GVListMatPRPO_CustomColumnDisplayText(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs) Handles GVListMatPRPO.CustomColumnDisplayText
    '    If e.Column.FieldName = "no" Then
    '        e.DisplayText = (e.ListSourceRowIndex + 1).ToString()
    '    End If
    'End Sub

    Private Sub BRefSamplePR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BRefSamplePR.Click
        GVSamplePR.ApplyFindFilter("")
        view_sample_pr()
    End Sub
    Private Sub BSampPRPayment_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BSampPRPayment.Click
        Cursor = Cursors.WaitCursor
        Try
            FormSamplePR.MdiParent = FormMain
            FormSamplePR.Show()
            FormSamplePR.WindowState = FormWindowState.Maximized
            FormSamplePR.Focus()
        Catch ex As Exception
            errorProcess()
        End Try
        Cursor = Cursors.Default

        FormSamplePR.GVSamplePR.FocusedRowHandle = find_row(FormSamplePR.GVSamplePR, "id_pr_sample_purc", GVSamplePR.GetFocusedRowCellValue("id_pr_sample_purc").ToString())
    End Sub

    Private Sub GVSamplePR_RowCellStyle(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs) Handles GVSamplePR.RowCellStyle
        Dim View As DevExpress.XtraGrid.Views.Grid.GridView = sender

        Dim date_now As Date
        Dim date_pr As Date

        If e.Column.FieldName = "report_status" Then
            date_now = Date.Parse(View.GetRowCellDisplayText(e.RowHandle, View.Columns("date_now")))
            date_pr = Date.Parse(View.GetRowCellDisplayText(e.RowHandle, View.Columns("sample_purc_top")))
            If date_now > date_pr And View.GetRowCellDisplayText(e.RowHandle, View.Columns("id_report_status")) < 3 Then
                e.Appearance.BackColor = Color.Red
                e.Appearance.BackColor2 = Color.LightSalmon
            End If
        End If
    End Sub
    '========================= end payment sample ====================
    '========================= sample PL =============================
    Private Sub BRefSampPL_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BRefSampPL.Click
        GVSamplePL.ApplyFindFilter("")
        viewPL()
    End Sub
    Sub viewPL()
        Dim query As String = "SELECT a.id_report_status,g.report_status,a.id_pl_sample_purc, a.id_comp_contact_from , a.id_comp_contact_to,a.pl_sample_purc_date, a.pl_sample_purc_note, a.pl_sample_purc_number, b.pl_category, "
        query += "(d.comp_name) AS comp_name_from, (f.comp_name) AS comp_name_to ,y2.season "
        query += "FROM tb_pl_sample_purc a "
        'query += "INNER JOIN tb_pl_sample_purc_rec a2 ON a2.id_pl_sample_purc = a.id_pl_sample_purc "
        query += "INNER JOIN tb_lookup_pl_category b ON a.id_pl_category = b.id_pl_category "
        query += "INNER JOIN tb_m_comp_contact c ON a.id_comp_contact_from = c.id_comp_contact "
        query += "INNER JOIN tb_m_comp d ON c.id_comp = d.id_comp "
        query += "INNER JOIN tb_m_comp_contact e ON a.id_comp_contact_to = e.id_comp_contact "
        query += "INNER JOIN tb_lookup_report_status g ON g.id_report_status = a.id_report_status "
        query += "INNER JOIN tb_m_comp f ON e.id_comp = f.id_comp "
        query += "INNER JOIN tb_sample_purc y1 ON a.id_sample_purc = y1.id_sample_purc "
        query += "INNER JOIN tb_season y2 ON y1.id_season = y2.id_season "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCSamplePL.DataSource = data
        check_menu()
        If data.Rows.Count > 0 Then 'ada data
            GVSamplePL.FocusedRowHandle = 0
            view_sample_pl(GVSamplePL.GetFocusedRowCellValue("id_pl_sample_purc").ToString)
            BGotoSampPLPL.Visible = True
        Else
            BGotoSampPLPL.Visible = False
        End If
    End Sub
    'View PL Sample
    Sub view_sample_pl(ByVal id_sample_purcx As String)
        Try
            Dim query As String = "CALL view_pl_sample('" + id_sample_purcx + "')"
            Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
            GCListSamplePL.DataSource = data
        Catch ex As Exception
            errorConnection()
        End Try
    End Sub

    Private Sub GVListSamplePL_CustomColumnDisplayText(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs) Handles GVListSamplePL.CustomColumnDisplayText
        If e.Column.FieldName = "no" Then
            e.DisplayText = (e.ListSourceRowIndex + 1).ToString()
        End If
    End Sub
    '========================= end of sample PL =====================

    Private Sub BGotoSampPLPL_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BGotoSampPLPL.Click
        Cursor = Cursors.WaitCursor
        Try
            FormSamplePL.MdiParent = FormMain
            FormSamplePL.Show()
            FormSamplePL.WindowState = FormWindowState.Maximized
            FormSamplePL.Focus()
        Catch ex As Exception
            errorProcess()
        End Try
        Cursor = Cursors.Default

        FormSamplePL.GVPL.FocusedRowHandle = find_row(FormSamplePL.GVPL, "id_pl_sample_purc", GVSamplePL.GetFocusedRowCellValue("id_pl_sample_purc").ToString())
    End Sub

    '===================SAMPLE PL DEL============================
    Private Sub GVPL_CustomColumnDisplayText(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs) Handles GVSamplePLDel.CustomColumnDisplayText
        If e.Column.FieldName = "no" Then
            e.DisplayText = (e.ListSourceRowIndex + 1).ToString()
        End If
    End Sub
    Sub viewPLDel()
        Dim query As String = "SELECT i.sample_requisition_number, a.id_pl_sample_del ,a.id_comp_contact_from , a.id_comp_contact_to,a.pl_sample_del_date, a.pl_sample_del_note, a.pl_sample_del_number, "
        query += "(d.comp_name) AS comp_name_from, (f.comp_name) AS comp_name_to, h.report_status "
        query += "FROM tb_pl_sample_del a "
        query += "INNER JOIN tb_m_comp_contact c ON a.id_comp_contact_from = c.id_comp_contact "
        query += "INNER JOIN tb_m_comp d ON c.id_comp = d.id_comp "
        query += "INNER JOIN tb_m_comp_contact e ON a.id_comp_contact_to = e.id_comp_contact "
        query += "INNER JOIN tb_m_comp f ON e.id_comp = f.id_comp "
        query += "INNER JOIN tb_lookup_report_status h ON h.id_report_status = a.id_report_status "
        query += "INNER JOIN tb_sample_requisition i ON a.id_sample_requisition = i.id_sample_requisition "
        query += "ORDER BY a.id_pl_sample_del ASC "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCSamplePLDel.DataSource = data
        If data.Rows.Count > 0 Then 'ada data
            GVSamplePLDel.FocusedRowHandle = 0
            Dim id_sample_pl_del_param As String = "-1"
            Try
                id_sample_pl_del_param = GVSamplePLDel.GetFocusedRowCellValue("id_pl_sample_del").ToString
            Catch ex As Exception
            End Try
            view_sample_pl_del(id_sample_pl_del_param)
            check_menu()
            BGotoSampPLDel.Visible = True
        Else
            BGotoSampPLDel.Visible = False
        End If
    End Sub
    Sub view_sample_pl_del(ByVal id_sample_purcx As String)
        Try
            Dim query As String = "CALL view_pl_sample_del('" + id_sample_purcx + "', '1')"
            Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
            GCListSampleDrawerPLDel.DataSource = data
        Catch ex As Exception
            errorConnection()
        End Try
    End Sub

    Private Sub BGotoSampPLDel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BGotoSampPLDel.Click
        Cursor = Cursors.WaitCursor
        Try
            FormSamplePLDel.MdiParent = FormMain
            FormSamplePLDel.Show()
            FormSamplePLDel.WindowState = FormWindowState.Maximized
            FormSamplePLDel.Focus()
        Catch ex As Exception
            errorProcess()
        End Try
        Cursor = Cursors.Default

        FormSamplePLDel.GVPL.FocusedRowHandle = find_row(FormSamplePLDel.GVPL, "id_pl_sample_del", GVSamplePLDel.GetFocusedRowCellValue("id_pl_sample_del").ToString())
    End Sub

    Private Sub BRefSampPLDel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BRefSampPLDel.Click
        GVSamplePLDel.ApplyFindFilter("")
        viewPLDel()
    End Sub

    Private Sub GVSamplePLDel_RowClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Grid.RowClickEventArgs) Handles GVSamplePLDel.RowClick

    End Sub

    Private Sub GVSamplePLDel_FocusedRowChanged(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles GVSamplePLDel.FocusedRowChanged
        Dim id_pl_sample_del_param As String = "-1"
        Try
            id_pl_sample_del_param = GVSamplePLDel.GetFocusedRowCellValue("id_pl_sample_del").ToString
        Catch ex As Exception
        End Try
        view_sample_pl_del(id_pl_sample_del_param)
    End Sub

    Private Sub GVListSampleDrawerPLDel_CustomColumnDisplayText(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs) Handles GVListSampleDrawerPLDel.CustomColumnDisplayText
        If e.Column.FieldName = "no" Then
            e.DisplayText = (e.ListSourceRowIndex + 1).ToString()
        End If
    End Sub
    '==================SAmple Requisition=======================
    Sub viewSampleReq()
        Dim query As String = ""
        query += "SELECT i.employee_name, j.departement, a.id_sample_requisition, a.sample_requisition_date, a.sample_requisition_duration, "
        query += "a.sample_requisition_note, a.sample_requisition_number, (c.comp_name) AS comp_from,  "
        query += "f.report_status, a.id_report_status "
        query += "FROM tb_sample_requisition a "
        query += "INNER JOIN tb_m_comp_contact b ON a.id_comp_contact_from = b.id_comp_contact  "
        query += "INNER JOIN tb_m_comp c ON b.id_comp = c.id_comp  "
        query += "INNER JOIN tb_lookup_report_status f ON a.id_report_status = f.id_report_status "
        query += "INNER JOIN tb_m_user h ON a.id_user = h.id_user "
        query += "INNER JOIN tb_m_employee i ON h.id_employee = i.id_employee "
        query += "INNER JOIN tb_m_departement j ON j.id_departement = i.id_departement "
        query += "ORDER BY a.id_sample_requisition ASC "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCSampleReq.DataSource = data
        If data.Rows.Count > 0 Then 'ada data
            GVSampleReq.FocusedRowHandle = 0
            Dim id_sample_req_param As String = "-1"
            Try
                id_sample_req_param = GVSampleReq.GetFocusedRowCellValue("id_sample_requisition").ToString
            Catch ex As Exception
            End Try
            view_sample_req(id_sample_req_param)
            check_menu()
            BGotoSampleReq.Visible = True
            GVListSampleReq.OptionsBehavior.AutoExpandAllGroups = True
        Else
            BGotoSampleReq.Visible = False
        End If
    End Sub

    Sub view_sample_req(ByVal id_sample_purcx As String)
        Try
            Dim query As String = "CALL view_sample_req_det('" + id_sample_purcx + "')"
            Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
            GCListSampleReq.DataSource = data
        Catch ex As Exception
            errorConnection()
        End Try
    End Sub

    Private Sub BGotoSampleReq_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BGotoSampleReq.Click
        Cursor = Cursors.WaitCursor
        Try
            FormSampleReq.MdiParent = FormMain
            FormSampleReq.Show()
            FormSampleReq.WindowState = FormWindowState.Maximized
            FormSampleReq.Focus()
        Catch ex As Exception
            errorProcess()
        End Try
        Cursor = Cursors.Default

        FormSampleReq.GVReq.FocusedRowHandle = find_row(FormSampleReq.GVReq, "id_sample_requisition", GVSampleReq.GetFocusedRowCellValue("id_sample_requisition").ToString())
    End Sub

    Private Sub BRefSampleReq_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BRefSampleReq.Click
        GVSampleReq.ApplyFindFilter("")
        viewSampleReq()
    End Sub

    Private Sub GVSampleReq_FocusedRowChanged(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles GVSampleReq.FocusedRowChanged
        Cursor = Cursors.WaitCursor
        Dim id_sample_req_param As String = "-1"
        Try
            id_sample_req_param = GVSampleReq.GetFocusedRowCellValue("id_sample_requisition").ToString
        Catch ex As Exception
        End Try
        view_sample_req(id_sample_req_param)
        Cursor = Cursors.Default
    End Sub

    '===================SAMPLE RETURN============================
    'View Data
    Sub viewSampleReturn()
        Dim query As String = ""
        query += "SELECT a.id_sample_return, a.sample_return_date, a.sample_return_note,  "
        query += "a.sample_return_number, a.id_comp_contact_from, a.id_comp_contact_to,(c.comp_name) AS comp_from,  (e.comp_name) AS comp_to, f.report_status, a.id_report_status "
        query += "FROM tb_sample_return a "
        query += "INNER JOIN tb_m_comp_contact b ON a.id_comp_contact_from = b.id_comp_contact  "
        query += "INNER JOIN tb_m_comp c ON b.id_comp = c.id_comp "
        query += "INNER JOIN tb_m_comp_contact d ON a.id_comp_contact_to = d.id_comp_contact "
        query += "INNER JOIN tb_m_comp e ON d.id_comp = e.id_comp "
        query += "INNER JOIN tb_lookup_report_status f ON a.id_report_status = f.id_report_status "
        query += "ORDER BY a.id_sample_return ASC "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCRetSample.DataSource = data
        If data.Rows.Count > 0 Then 'ada data
            GVRetSample.FocusedRowHandle = 0
            Dim id_sample_return_param As String = "-1"
            Try
                id_sample_return_param = GVRetSample.GetFocusedRowCellValue("id_sample_return").ToString
            Catch ex As Exception
            End Try
            view_sample_return(id_sample_return_param)
            check_menu()
            BGotoSampeReturn.Visible = True
            GVListSampleReturn.OptionsBehavior.AutoExpandAllGroups = True
        Else
            BGotoSampeReturn.Visible = False
        End If
    End Sub

    Private Sub GVRetSample_FocusedRowChanged(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles GVRetSample.FocusedRowChanged
        Dim id_sample_return_param As String = "-1"
        Try
            id_sample_return_param = GVRetSample.GetFocusedRowCellValue("id_sample_return").ToString
        Catch ex As Exception
        End Try
        view_sample_return(id_sample_return_param)
    End Sub

    Sub view_sample_return(ByVal id_sample_purcx As String)
        Try
            Dim query As String = "CALL view_sample_return('" + id_sample_purcx + "')"
            Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
            GCListSampleReturn.DataSource = data
        Catch ex As Exception
            errorConnection()
        End Try
    End Sub

    Private Sub BGotoSampeReturn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BGotoSampeReturn.Click
        Cursor = Cursors.WaitCursor
        Try
            FormSampleReturn.MdiParent = FormMain
            FormSampleReturn.Show()
            FormSampleReturn.WindowState = FormWindowState.Maximized
            FormSampleReturn.Focus()
        Catch ex As Exception
            errorProcess()
        End Try
        Cursor = Cursors.Default

        FormSampleReturn.GVRetSample.FocusedRowHandle = find_row(FormSampleReturn.GVRetSample, "id_sample_return", GVSamplePLDel.GetFocusedRowCellValue("id_sample_return").ToString())
    End Sub

    Private Sub BRefSampleReturn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BRefSampleReturn.Click
        GVRetSample.ApplyFindFilter("")
        viewSampleReturn()
    End Sub

    Private Sub GVRetSample_RowClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Grid.RowClickEventArgs)

    End Sub

    '=======================Adjustment IN sample===============================
    Sub viewAdjInSample()
        Dim query As String = ""
        query += "SELECT *, DATE_FORMAT(a.adj_in_sample_date, '%d %M %Y') AS adj_in_sample_datex, a.adj_in_sample_date "
        query += "FROM tb_adj_in_sample a "
        query += "INNER JOIN tb_lookup_report_status b ON a.id_report_status = b.id_report_status "
        query += "INNER JOIN tb_lookup_currency c ON a.id_currency = c.id_currency  "
        query += "ORDER BY a.id_adj_in_sample ASC "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCAdjSampleIn.DataSource = data
        If data.Rows.Count > 0 Then 'ada data
            GVAdjSampleIn.FocusedRowHandle = 0
            Dim id_adj_in_sample_param As String = "-1"
            Try
                id_adj_in_sample_param = GVAdjSampleIn.GetFocusedRowCellValue("id_adj_in_sample").ToString
            Catch ex As Exception
            End Try
            view_sample_adj_in(id_adj_in_sample_param)
            check_menu()
            BGotoSampeAdjIn.Visible = True
            GVListAdjInSample.OptionsBehavior.AutoExpandAllGroups = True
        Else
            BGotoSampeAdjIn.Visible = False
        End If
    End Sub

    Sub view_sample_adj_in(ByVal id_sample_purcx As String)
        Try
            Dim query As String = "CALL view_sample_adj_in('" + id_sample_purcx + "')"
            Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
            GCListAdjInSample.DataSource = data
            GVListAdjInSample.Columns("id_sample").GroupIndex = 0
        Catch ex As Exception
            errorConnection()
        End Try
    End Sub

    Private Sub GVListAdjInSample_CustomColumnDisplayText(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs) Handles GVListAdjInSample.CustomColumnDisplayText
        If e.Column.FieldName = "id_sample" Then
            Dim rowhandle As Integer = e.ListSourceRowIndex
            If GVListAdjInSample.IsGroupRow(rowhandle) Then
                rowhandle = GVListAdjInSample.GetDataRowHandleByGroupRowHandle(rowhandle)
                e.DisplayText = GVListAdjInSample.GetRowCellDisplayText(rowhandle, "name")
            End If
        End If
    End Sub

    Private Sub GVAdjSampleIn_FocusedRowChanged(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles GVAdjSampleIn.FocusedRowChanged
        Dim id_adj_in_sample_param As String = "-1"
        Try
            id_adj_in_sample_param = GVAdjSampleIn.GetFocusedRowCellValue("id_adj_in_sample").ToString
        Catch ex As Exception
        End Try
        view_sample_adj_in(id_adj_in_sample_param)
    End Sub


    Private Sub BGotoSampeAdjIn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BGotoSampeAdjIn.Click
        Cursor = Cursors.WaitCursor
        Try
            FormSampleAdjustment.MdiParent = FormMain
            FormSampleAdjustment.Show()
            FormSampleAdjustment.WindowState = FormWindowState.Maximized
            FormSampleAdjustment.Focus()
            FormSampleAdjustment.XTCAdj.SelectedTabPageIndex = 0
        Catch ex As Exception
            errorProcess()
        End Try
        Cursor = Cursors.Default

        FormSampleAdjustment.GVAdjSampleIn.FocusedRowHandle = find_row(FormSampleAdjustment.GVAdjSampleIn, "id_adj_in_sample", GVAdjSampleIn.GetFocusedRowCellValue("id_adj_in_sample").ToString())
    End Sub

    Private Sub BRefSampleAdjIn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BRefSampleAdjIn.Click
        GVAdjSampleIn.ApplyFindFilter("")
        viewAdjInSample()
    End Sub

    '=====================Adjustment Out Sample ================================
    Sub viewAdjOutSample()
        Dim query As String = ""
        query += "SELECT *, DATE_FORMAT(a.adj_out_sample_date, '%d %M %Y') AS adj_out_sample_datex, a.adj_out_sample_date "
        query += "FROM tb_adj_out_sample a "
        query += "INNER JOIN tb_lookup_report_status b ON a.id_report_status = b.id_report_status "
        query += "INNER JOIN tb_lookup_currency c ON a.id_currency = c.id_currency  "
        query += "ORDER BY a.id_adj_out_sample ASC "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCAdjOutSample.DataSource = data
        If data.Rows.Count > 0 Then 'ada data
            GVAdjOutSample.FocusedRowHandle = 0
            Dim id_adj_out_sample_param As String = "-1"
            Try
                id_adj_out_sample_param = GVAdjOutSample.GetFocusedRowCellValue("id_adj_out_sample").ToString
            Catch ex As Exception
            End Try
            view_sample_adj_out(id_adj_out_sample_param)
            check_menu()
            BGotoSampeAdjOut.Visible = True
            GVListAdjOutSample.OptionsBehavior.AutoExpandAllGroups = True
        Else
            BGotoSampeAdjOut.Visible = False
        End If
    End Sub

    Sub view_sample_adj_out(ByVal id_sample_purcx As String)
        Try
            Dim query As String = "CALL view_sample_adj_out('" + id_sample_purcx + "')"
            Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
            GCListAdjOutSample.DataSource = data
            'GVListAdjInSampl.Columns("id_sample").GroupIndex = 0
        Catch ex As Exception
            errorConnection()
        End Try
    End Sub

    Private Sub GVAdjOutSample_FocusedRowChanged(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles GVAdjOutSample.FocusedRowChanged
        Dim id_adj_out_sample_param As String = "-1"
        Try
            id_adj_out_sample_param = GVAdjOutSample.GetFocusedRowCellValue("id_adj_out_sample").ToString
        Catch ex As Exception
        End Try
        view_sample_adj_out(id_adj_out_sample_param)
    End Sub

    Private Sub BGotoSampeAdjOut_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BGotoSampeAdjOut.Click
        Cursor = Cursors.WaitCursor
        Try
            FormSampleAdjustment.MdiParent = FormMain
            FormSampleAdjustment.Show()
            FormSampleAdjustment.WindowState = FormWindowState.Maximized
            FormSampleAdjustment.Focus()
            FormSampleAdjustment.XTCAdj.SelectedTabPageIndex = 1
        Catch ex As Exception
            errorProcess()
        End Try
        Cursor = Cursors.Default

        FormSampleAdjustment.GVAdjOutSample.FocusedRowHandle = find_row(FormSampleAdjustment.GVAdjOutSample, "id_adj_out_sample", GVAdjSampleIn.GetFocusedRowCellValue("id_adj_out_sample").ToString())
    End Sub

    Private Sub BRefSampleAdjOut_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BRefSampleAdjOut.Click
        GVListAdjOutSample.ApplyFindFilter("")
        viewAdjOutSample()
    End Sub

    Private Sub GVListAdjOutSample_CustomColumnDisplayText(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs) Handles GVListAdjOutSample.CustomColumnDisplayText
        If e.Column.FieldName = "no" Then
            e.DisplayText = (e.ListSourceRowIndex + 1).ToString()
        End If
    End Sub

    '========================PRODUCTION DEMAND=============================
    Sub viewProdDemand()
        Dim query_c As ClassProdDemand = New ClassProdDemand()
        Dim query As String = query_c.queryMain("-1", "1")
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCProdDemand.DataSource = data
        GVProdDemand.Columns("season").GroupIndex = 0
        If data.Rows.Count > 0 Then 'ada data
            GVProdDemand.FocusedRowHandle = 0

            Dim id_prod_demand_param As String = "-1"
            Try
                id_prod_demand_param = GVProdDemand.GetFocusedRowCellValue("id_prod_demand").ToString
            Catch ex As Exception
            End Try
            view_detail_pd(id_prod_demand_param)
            check_menu()
            BGotoProdDemand.Visible = True
            BGVProduct.OptionsBehavior.AutoExpandAllGroups = True
        Else
            BGotoProdDemand.Visible = False
        End If
    End Sub

    Private Sub GVProdDemand_FocusedRowChanged(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles GVProdDemand.FocusedRowChanged
        Cursor = Cursors.WaitCursor
        Dim id_prod_demand_param As String = "-1"
        Try
            id_prod_demand_param = GVProdDemand.GetFocusedRowCellValue("id_prod_demand").ToString
        Catch ex As Exception
        End Try
        view_detail_pd(id_prod_demand_param)
        Cursor = Cursors.Default
    End Sub

    Private Sub GVProdDemand_ColumnFilterChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GVProdDemand.ColumnFilterChanged
        Cursor = Cursors.WaitCursor
        Dim id_prod_demand_param As String = "-1"
        Try
            id_prod_demand_param = GVProdDemand.GetFocusedRowCellValue("id_prod_demand").ToString
        Catch ex As Exception
        End Try
        view_detail_pd(id_prod_demand_param)
        Cursor = Cursors.Default
    End Sub

    Private Sub BGVProduct_CustomColumnDisplayText(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs) Handles BGVProduct.CustomColumnDisplayText
        If e.Column.FieldName = "No_desc_report_column" Then
            e.DisplayText = (e.ListSourceRowIndex + 1).ToString()
        End If
    End Sub

    Dim tot_cost As Decimal
    Dim tot_prc As Decimal
    Dim tot_cost_grp As Decimal
    Dim tot_prc_grp As Decimal
    Private Sub BGVProduct_CustomSummaryCalculate(ByVal sender As System.Object, ByVal e As DevExpress.Data.CustomSummaryEventArgs) Handles BGVProduct.CustomSummaryCalculate
        Dim summaryID As Integer = Convert.ToInt32(CType(e.Item, DevExpress.XtraGrid.GridSummaryItem).Tag)
        Dim View As DevExpress.XtraGrid.Views.Grid.GridView = CType(sender, DevExpress.XtraGrid.Views.Grid.GridView)

        ' Initialization 
        If e.SummaryProcess = DevExpress.Data.CustomSummaryProcess.Start Then
            tot_cost = 0.0
            tot_prc = 0.0
            tot_cost_grp = 0.0
            tot_prc_grp = 0.0
        End If

        ' Calculation 
        If e.SummaryProcess = DevExpress.Data.CustomSummaryProcess.Calculate Then
            Dim cost As Decimal = CDec(myCoalesce(View.GetRowCellValue(e.RowHandle, "TOTAL COST_add_report_column").ToString, "0.00"))
            Dim prc As Decimal = CDec(myCoalesce(View.GetRowCellValue(e.RowHandle, "TOTAL AMOUNT_add_report_column"), "0.00"))
            Select Case summaryID
                Case 46
                    tot_cost += cost
                    tot_prc += prc
                Case 47
                    tot_cost_grp += cost
                    tot_prc_grp += prc
            End Select
        End If

        ' Finalization 
        If e.SummaryProcess = DevExpress.Data.CustomSummaryProcess.Finalize Then
            Select Case summaryID
                Case 46 'total summary
                    Dim sum_res As Decimal = 0.0
                    Try
                        sum_res = tot_prc / tot_cost
                    Catch ex As Exception
                    End Try
                    e.TotalValue = sum_res
                Case 47 'group summary
                    Dim sum_res As Decimal = 0.0
                    Try
                        sum_res = tot_prc_grp / tot_cost_grp
                    Catch ex As Exception
                    End Try
                    e.TotalValue = sum_res
            End Select
        End If
    End Sub

    Sub view_detail_pd(ByVal id_sample_purcx As String)
        'build report
        Dim prod_demand_report As ClassProdDemand = New ClassProdDemand()
        prod_demand_report.printReport(id_sample_purcx, BGVProduct, GCProduct)
    End Sub

    Private Sub BRefProdDemand_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BRefProdDemand.Click
        GVProdDemand.ApplyFindFilter("")
        viewProdDemand()
    End Sub

    Private Sub BGotoProdDemand_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BGotoProdDemand.Click
        Cursor = Cursors.WaitCursor
        Try
            FormProdDemand.MdiParent = FormMain
            FormProdDemand.Show()
            FormProdDemand.WindowState = FormWindowState.Maximized
            FormProdDemand.Focus()
        Catch ex As Exception
            errorProcess()
        End Try
        Cursor = Cursors.Default

        FormProdDemand.GVProdDemand.FocusedRowHandle = find_row(FormProdDemand.GVProdDemand, "id_prod_demand", GVProdDemand.GetFocusedRowCellValue("id_prod_demand").ToString())
    End Sub

    '==================PR PO MATERIAL==============================
    Sub view_mat_pr()
        Dim query As String = "SELECT NOW() as date_now, b.id_delivery, g.id_season,g0.delivery, z.id_report_status,h.report_status,z.pr_mat_purc_note,z.id_pr_mat_purc,z.pr_mat_purc_number,DATE_FORMAT(z.pr_mat_purc_date,'%d %M %Y') as pr_mat_purc_date,g.season,a.id_mat_purc_rec,a.mat_purc_rec_number,DATE_FORMAT(a.delivery_order_date,'%d %M %Y') AS delivery_order_date,a.delivery_order_number,b.mat_purc_number,DATE_FORMAT(a.mat_purc_rec_date,'%d %M %Y') AS mat_purc_rec_date, d.comp_name AS comp_to, "
        query += "DATE_FORMAT(DATE_ADD(b.mat_purc_date,INTERVAL (b.mat_purc_top+b.mat_purc_lead_time) DAY),'%d %M %Y') AS mat_purc_top "
        query += "FROM tb_pr_mat_purc z "
        query += "LEFT JOIN tb_mat_purc_rec a ON z.id_mat_purc_rec = a.id_mat_purc_rec "
        query += "INNER JOIN tb_mat_purc b ON z.id_mat_purc=b.id_mat_purc "
        query += "INNER JOIN tb_m_comp_contact c ON c.id_comp_contact=z.id_comp_contact_to "
        query += "INNER JOIN tb_m_comp d ON d.id_comp=c.id_comp "
        query += "INNER JOIN tb_season_delivery g0 ON g0.id_delivery = b.id_delivery "
        query += "INNER JOIN tb_season g ON g0.id_season = g.id_season "
        query += "INNER JOIN tb_lookup_report_status h ON h.id_report_status=z.id_report_status "
        query += "ORDER BY g.date_season_start ASC "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCMatPRPO.DataSource = data
        check_menu()
        If data.Rows.Count > 0 Then
            GVMatPRPO.FocusedRowHandle = 0
            view_list_pr(GVMatPRPO.GetFocusedRowCellValue("id_pr_mat_purc").ToString)
            '
            BMatPRPOPayment.Visible = True
            '
        Else
            BMatPRPOPayment.Visible = False
        End If
    End Sub
    Sub view_list_pr(ByVal id_prx As String)
        Dim query = "CALL view_pr_mat_from_pr('" & id_prx & "')"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCListMatPRPO.DataSource = data
    End Sub
    Private Sub GVMatPRPO_RowClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Grid.RowClickEventArgs) Handles GVMatPRPO.RowClick
        Try
            view_list_pr(GVMatPRPO.GetFocusedRowCellValue("id_pr_mat_purc").ToString)
        Catch ex As Exception
        End Try
    End Sub
    Private Sub GVMatPRPO_FocusedRowChanged(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles GVMatPRPO.FocusedRowChanged
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

    Private Sub GVListMatPRPO_CustomColumnDisplayText(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs) Handles GVListMatPRPO.CustomColumnDisplayText
        If e.Column.FieldName = "no" Then
            e.DisplayText = (e.ListSourceRowIndex + 1).ToString()
        End If
    End Sub

    Private Sub BRefMatPRPO_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BRefMatPRPO.Click
        GVMatPRPO.ApplyFindFilter("")
        view_mat_pr()
    End Sub
    Private Sub BMatPRPOPayment_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BMatPRPOPayment.Click
        Cursor = Cursors.WaitCursor
        Try
            FormMatPR.MdiParent = FormMain
            FormMatPR.Show()
            FormMatPR.WindowState = FormWindowState.Maximized
            FormMatPR.Focus()
        Catch ex As Exception
            errorProcess()
        End Try
        Cursor = Cursors.Default

        FormMatPR.GVMatPR.FocusedRowHandle = find_row(FormMatPR.GVMatPR, "id_pr_mat_purc", GVMatPRPO.GetFocusedRowCellValue("id_pr_mat_purc").ToString())
    End Sub

    Private Sub GVMatPRPO_RowCellStyle(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs) Handles GVMatPRPO.RowCellStyle
        Dim View As DevExpress.XtraGrid.Views.Grid.GridView = sender

        Dim date_now As Date
        Dim date_pr As Date

        If e.Column.FieldName = "report_status" Then
            date_now = Date.Parse(View.GetRowCellDisplayText(e.RowHandle, View.Columns("date_now")))
            date_pr = Date.Parse(View.GetRowCellDisplayText(e.RowHandle, View.Columns("mat_purc_top")))
            If date_now > date_pr And View.GetRowCellDisplayText(e.RowHandle, View.Columns("id_report_status")) < 3 Then
                e.Appearance.BackColor = Color.Red
                e.Appearance.BackColor2 = Color.LightSalmon
            End If
        End If
    End Sub

    '==================PR WO MATERIAL==============================
    Sub view_mat_pr_wo()
        Dim query As String = "SELECT  l.overhead, NOW() as date_now, b.id_delivery, g.id_season,g0.delivery, z.id_report_status,h.report_status,z.pr_mat_wo_note,z.id_pr_mat_wo,z.pr_mat_wo_number,DATE_FORMAT(z.pr_mat_wo_date,'%d %M %Y') as pr_mat_wo_date,g.season,a.id_mat_wo_rec,a.mat_wo_rec_number,DATE_FORMAT(a.delivery_order_date,'%d %M %Y') AS delivery_order_date,a.delivery_order_number,b.mat_wo_number,DATE_FORMAT(a.mat_wo_rec_date,'%d %M %Y') AS mat_wo_rec_date, d.comp_name AS comp_to, "
        query += "DATE_FORMAT(DATE_ADD(b.mat_wo_date,INTERVAL (b.mat_wo_top+b.mat_wo_lead_time) DAY),'%d %M %Y') AS mat_wo_top "
        query += "FROM tb_pr_mat_wo z "
        query += "LEFT JOIN tb_mat_wo_rec a ON z.id_mat_wo_rec = a.id_mat_wo_rec "
        query += "INNER JOIN tb_mat_wo b ON z.id_mat_wo=b.id_mat_wo "
        query += "INNER JOIN tb_m_comp_contact c ON c.id_comp_contact=z.id_comp_contact_to "
        query += "INNER JOIN tb_m_comp d ON d.id_comp=c.id_comp "
        query += "INNER JOIN tb_season_delivery g0 ON g0.id_delivery = b.id_delivery "
        query += "INNER JOIN tb_season g ON g0.id_season = g.id_season "
        query += "INNER JOIN tb_lookup_report_status h ON h.id_report_status=z.id_report_status "
        query += "INNER JOIN tb_m_ovh l ON b.id_ovh = l.id_ovh "
        query += "ORDER BY g.date_season_start ASC "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCMatPRWO.DataSource = data
        check_menu()
        If data.Rows.Count > 0 Then
            GVMatPRWO.FocusedRowHandle = 0
            view_list_pr_wo(GVMatPRWO.GetFocusedRowCellValue("id_pr_mat_wo").ToString)
            '
            BMatPRWOPayment.Visible = True
            '
        Else
            BMatPRWOPayment.Visible = False
        End If
    End Sub
    Sub view_list_pr_wo(ByVal id_prx As String)
        Dim query = "CALL view_pr_mat_wo_from_pr('" & id_prx & "')"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCListMatPRWO.DataSource = data
    End Sub
    Private Sub GVMatPRWO_RowClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Grid.RowClickEventArgs) Handles GVMatPRWO.RowClick
        Try
            view_list_pr_wo(GVMatPRWO.GetFocusedRowCellValue("id_pr_mat_wo").ToString)
        Catch ex As Exception
        End Try
    End Sub
    Private Sub GVMatPRWO_FocusedRowChanged(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles GVMatPRWO.FocusedRowChanged
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

    Private Sub GVListMatPRWO_CustomColumnDisplayText(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs) Handles GVListMatPRWO.CustomColumnDisplayText
        If e.Column.FieldName = "no" Then
            e.DisplayText = (e.ListSourceRowIndex + 1).ToString()
        End If
    End Sub

    Private Sub BRefMatPRWO_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BRefMatPRWO.Click
        GVMatPRWO.ApplyFindFilter("")
        view_mat_pr_wo()
    End Sub
    Private Sub BMatPRWOPayment_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BMatPRWOPayment.Click
        Cursor = Cursors.WaitCursor
        Try
            FormMatPRWO.MdiParent = FormMain
            FormMatPRWO.Show()
            FormMatPRWO.WindowState = FormWindowState.Maximized
            FormMatPRWO.Focus()
        Catch ex As Exception
            errorProcess()
        End Try
        Cursor = Cursors.Default

        FormMatPRWO.GVMatPRWO.FocusedRowHandle = find_row(FormMatPRWO.GVMatPRWO, "id_pr_mat_wo", GVMatPRWO.GetFocusedRowCellValue("id_pr_mat_wo").ToString())
    End Sub

    Private Sub GVMatPRWO_RowCellStyle(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs) Handles GVMatPRWO.RowCellStyle
        Dim View As DevExpress.XtraGrid.Views.Grid.GridView = sender

        Dim date_now As Date
        Dim date_pr As Date

        If e.Column.FieldName = "report_status" Then
            date_now = Date.Parse(View.GetRowCellDisplayText(e.RowHandle, View.Columns("date_now")))
            date_pr = Date.Parse(View.GetRowCellDisplayText(e.RowHandle, View.Columns("mat_wo_top")))
            If date_now > date_pr And View.GetRowCellDisplayText(e.RowHandle, View.Columns("id_report_status")) < 3 Then
                e.Appearance.BackColor = Color.Red
                e.Appearance.BackColor2 = Color.LightSalmon
            End If
        End If
    End Sub

    '====================Adjustment In Material========================
    Sub viewMatAdjIn()
        Dim query As String = ""
        query += "SELECT *, DATE_FORMAT(a.adj_in_mat_date, '%d %M %Y') AS adj_in_mat_datex "
        query += "FROM tb_adj_in_mat a "
        query += "INNER JOIN tb_lookup_report_status b ON a.id_report_status = b.id_report_status "
        query += "INNER JOIN tb_lookup_currency c ON a.id_currency = c.id_currency  "
        query += "ORDER BY a.id_adj_in_mat ASC "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCMatAdjIn.DataSource = data
        If data.Rows.Count > 0 Then 'ada data
            GVMatAdjIn.FocusedRowHandle = 0
            view_mat_adj_in(GVMatAdjIn.GetFocusedRowCellValue("id_adj_in_mat").ToString)
            check_menu()
            BGotoMatAdjIn.Visible = True
            GVMatListAdjIn.OptionsBehavior.AutoExpandAllGroups = True
        Else
            BGotoMatAdjIn.Visible = False
        End If
    End Sub

    Sub view_mat_adj_in(ByVal id_sample_purcx As String)
        Try
            Dim query As String = "CALL view_mat_adj_in('" + id_sample_purcx + "')"
            Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
            GCMatListAdjIn.DataSource = data
        Catch ex As Exception
            errorConnection()
        End Try
    End Sub

    Private Sub GVMatListAdjIn_CustomColumnDisplayText(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs) Handles GVMatListAdjIn.CustomColumnDisplayText
        If e.Column.FieldName = "id_mat_det" Then
            Dim rowhandle As Integer = e.ListSourceRowIndex
            If GVMatAdjIn.IsGroupRow(rowhandle) Then
                rowhandle = GVMatAdjIn.GetDataRowHandleByGroupRowHandle(rowhandle)
                e.DisplayText = GVListAdjInSample.GetRowCellDisplayText(rowhandle, "name")
            End If
        End If
        If e.Column.FieldName = "no" Then
            e.DisplayText = (e.ListSourceRowIndex + 1).ToString()
        End If
    End Sub

    Private Sub GVMatAdjIn_FocusedRowChanged(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles GVMatAdjIn.FocusedRowChanged
        view_mat_adj_in(GVMatAdjIn.GetFocusedRowCellValue("id_adj_in_mat").ToString)
    End Sub

    Private Sub BGotoMatAdjIn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BGotoMatAdjIn.Click
        Cursor = Cursors.WaitCursor
        Try
            FormMatAdj.MdiParent = FormMain
            FormMatAdj.Show()
            FormMatAdj.WindowState = FormWindowState.Maximized
            FormMatAdj.Focus()
            FormMatAdj.XTCAdj.SelectedTabPageIndex = 0
        Catch ex As Exception
            errorProcess()
        End Try
        Cursor = Cursors.Default
        FormMatAdj.GVAdjIn.FocusedRowHandle = find_row(FormMatAdj.GVAdjIn, "id_adj_in_mat", GVMatAdjIn.GetFocusedRowCellValue("id_adj_in_mat").ToString())
    End Sub

    Private Sub BRefMatAdjIn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BRefMatAdjIn.Click
        GVMatAdjIn.ApplyFindFilter("")
        viewMatAdjIn()
    End Sub

    '====================Adjustment Out Material========================
    Sub viewMatAdjOut()
        Dim query As String = ""
        query += "SELECT *, DATE_FORMAT(a.adj_out_mat_date, '%d %M %Y') AS adj_out_mat_datex "
        query += "FROM tb_adj_out_mat a "
        query += "INNER JOIN tb_lookup_report_status b ON a.id_report_status = b.id_report_status "
        query += "INNER JOIN tb_lookup_currency c ON a.id_currency = c.id_currency  "
        query += "ORDER BY a.id_adj_out_mat ASC "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCMatAdjOut.DataSource = data
        If data.Rows.Count > 0 Then 'ada data
            GVMatAdjOut.FocusedRowHandle = 0
            view_mat_adj_out(GVMatAdjOut.GetFocusedRowCellValue("id_adj_out_mat").ToString)
            check_menu()
            BGotoMatAdjOut.Visible = True
            GVMatListAdjOut.OptionsBehavior.AutoExpandAllGroups = True
        Else
            BGotoMatAdjOut.Visible = False
        End If
    End Sub

    Sub view_mat_adj_out(ByVal id_sample_purcx As String)
        Try
            Dim query As String = "CALL view_mat_adj_out('" + id_sample_purcx + "')"
            Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
            GCMatListAdjOut.DataSource = data
        Catch ex As Exception
            errorConnection()
        End Try
    End Sub

    Private Sub GVMatListAdjOut_CustomColumnDisplayText(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs) Handles GVMatListAdjOut.CustomColumnDisplayText
        If e.Column.FieldName = "no" Then
            e.DisplayText = (e.ListSourceRowIndex + 1).ToString()
        End If
    End Sub

    Private Sub GVMatAdjOut_FocusedRowChanged(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles GVMatAdjOut.FocusedRowChanged
        view_mat_adj_out(GVMatAdjOut.GetFocusedRowCellValue("id_adj_out_mat").ToString)
    End Sub

    Private Sub BGotoMatAdjOut_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BGotoMatAdjOut.Click
        Cursor = Cursors.WaitCursor
        Try
            FormMatAdj.MdiParent = FormMain
            FormMatAdj.Show()
            FormMatAdj.WindowState = FormWindowState.Maximized
            FormMatAdj.Focus()
            FormMatAdj.XTCAdj.SelectedTabPageIndex = 1
        Catch ex As Exception
            errorProcess()
        End Try
        Cursor = Cursors.Default
        FormMatAdj.GVAdjOut.FocusedRowHandle = find_row(FormMatAdj.GVAdjOut, "id_adj_out_mat", GVMatAdjOut.GetFocusedRowCellValue("id_adj_out_mat").ToString())
    End Sub

    Private Sub BRefMatAdjOut_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BRefMatAdjOut.Click
        GVMatAdjOut.ApplyFindFilter("")
        viewMatAdjOut()
    End Sub

    '================== begin receive production  ======================
    Sub view_production_rec()
        Dim query = "SELECT a.id_report_status,h.report_status,g.season,a.id_prod_order_rec,a.prod_order_rec_number, "
        query += "(a.delivery_order_date) AS delivery_order_date,a.delivery_order_number,b.prod_order_number, "
        query += "(a.prod_order_rec_date) AS prod_order_rec_date, f.comp_name AS comp_from,d.comp_name AS comp_to "
        query += "FROM tb_prod_order_rec a  "
        query += "INNER JOIN tb_prod_order b ON a.id_prod_order=b.id_prod_order "
        query += "INNER JOIN tb_m_comp_contact c ON c.id_comp_contact = a.id_comp_contact_to "
        query += "INNER JOIN tb_m_comp d ON d.id_comp = c.id_comp "
        query += "INNER JOIN tb_m_comp_contact e ON e.id_comp_contact = a.id_comp_contact_to  "
        query += "INNER JOIN tb_m_comp f ON f.id_comp = e.id_comp "
        query += "INNER JOIN tb_season_delivery i ON b.id_delivery = i.id_delivery "
        query += "INNER JOIN tb_season g ON g.id_season = i.id_season "
        query += "INNER JOIN tb_lookup_report_status h ON h.id_report_status = a.id_report_status "
        query += "ORDER BY g.date_season_start DESC, a.id_prod_order_rec ASC "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")

        GCProdRec.DataSource = data
        check_menu()
        If data.Rows.Count > 0 Then
            GVProdRec.FocusedRowHandle = 0
            Dim id_rec As String = "-1"
            Try
                id_rec = GVProdRec.GetFocusedRowCellValue("id_prod_order_rec").ToString
            Catch ex As Exception
            End Try
            view_list_prod_rec(id_rec)
            BGotoProdRecQc.Visible = True
        Else
            BGotoProdRecQc.Visible = False
        End If
    End Sub
    Sub view_list_prod_rec(ByVal id_sample_purc_rec As String)
        Dim query = "CALL view_prod_order_rec_det('" + id_sample_purc_rec + "', '0')"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCListProdRec.DataSource = data
    End Sub

    Private Sub GVListProdRec_CustomColumnDisplayText(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs) Handles GVListProdRec.CustomColumnDisplayText, GVListProdRec.CustomColumnDisplayText
        If e.Column.FieldName = "no" Then
            e.DisplayText = (e.ListSourceRowIndex + 1).ToString()
        End If
    End Sub
    Private Sub BRefProdRecQC_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BRefProdRecQC.Click
        GVProdRec.ApplyFindFilter("")
        view_production_rec()
    End Sub
    Private Sub BGotoProdRecQc_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BGotoProdRecQc.Click
        Cursor = Cursors.WaitCursor
        Try
            FormProductionRec.MdiParent = FormMain
            FormProductionRec.Show()
            FormProductionRec.WindowState = FormWindowState.Maximized
            FormProductionRec.Focus()
        Catch ex As Exception
            errorProcess()
        End Try
        Cursor = Cursors.Default

        FormProductionRec.GVProdRec.FocusedRowHandle = find_row(FormProductionRec.GVProdRec, "id_prod_order_rec", GVProdRec.GetFocusedRowCellValue("id_prod_order_rec").ToString())
    End Sub

    Private Sub GVProdRec_FocusedRowChanged(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles GVProdRec.FocusedRowChanged
        Cursor = Cursors.WaitCursor
        Dim id_rec As String = "-1"
        Try
            id_rec = GVProdRec.GetFocusedRowCellValue("id_prod_order_rec").ToString
        Catch ex As Exception
        End Try
        view_list_prod_rec(id_rec)
        Cursor = Cursors.Default
    End Sub

    Private Sub GVProdRec_ColumnFilterChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GVProdRec.ColumnFilterChanged
        Cursor = Cursors.WaitCursor
        Dim id_rec As String = "-1"
        Try
            id_rec = GVProdRec.GetFocusedRowCellValue("id_prod_order_rec").ToString
        Catch ex As Exception
        End Try
        view_list_prod_rec(id_rec)
        Cursor = Cursors.Default
    End Sub


    '================== begin return out production  ======================
    Sub view_production_ret_out()
        Dim query As String = "SELECT h.id_report_status, h.report_status, a.id_prod_order_ret_out, a.prod_order_ret_out_note,  "
        query += "a.prod_order_ret_out_number , b.prod_order_number, c.season, (e.comp_name) AS comp_from, (g.comp_name) AS comp_to, "
        query += "DATE_FORMAT(a.prod_order_ret_out_date,'%d %M %Y') AS prod_order_ret_out_date, "
        query += "DATE_FORMAT(a.prod_order_ret_out_due_date,'%d %M %Y') AS prod_order_ret_out_due_date "
        query += "FROM tb_prod_order_ret_out a "
        query += "INNER JOIN tb_prod_order b ON a.id_prod_order = b.id_prod_order "
        query += "INNER JOIN tb_prod_demand_design b1 ON b.id_prod_demand_design = b1.id_prod_demand_design "
        query += "INNER JOIN tb_prod_demand b2 ON b2.id_prod_demand = b1.id_prod_demand "
        query += "INNER JOIN tb_season c ON b2.id_season = c.id_season "
        query += "INNER JOIN tb_m_comp_contact d ON d.id_comp_contact = a.id_comp_contact_from "
        query += "INNER JOIN tb_m_comp e ON d.id_comp = e.id_comp "
        query += "INNER JOIN tb_m_comp_contact f ON f.id_comp_contact = a.id_comp_contact_to "
        query += "INNER JOIN tb_m_comp g ON f.id_comp = g.id_comp "
        query += "INNER JOIN tb_lookup_report_status h ON a.id_report_status = h.id_report_status "
        query += "ORDER BY a.id_prod_order_ret_out ASC "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")

        GCProdRetOut.DataSource = data
        check_menu()
        If data.Rows.Count > 0 Then
            GVProdRetOut.FocusedRowHandle = 0
            Dim id_ret_out As String = "-1"
            Try
                id_ret_out = GVProdRetOut.GetFocusedRowCellValue("id_prod_order_ret_out").ToString
            Catch ex As Exception
            End Try
            view_list_prod_ret_out(id_ret_out)
            BGotoProdRetOut.Visible = True
        Else
            BGotoProdRetOut.Visible = False
        End If
    End Sub

    Sub view_list_prod_ret_out(ByVal id_sample_purc_rec As String)
        Dim query = "CALL view_return_out_prod('" + id_sample_purc_rec + "', '0')"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCListProdRetOutDetail.DataSource = data
        GVListProdRetOutDetail.ActiveFilterString = "[prod_order_ret_out_det_qty] > 0.00"
    End Sub
    Private Sub GVListProdRetOutDetail_CustomColumnDisplayText(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs) Handles GVListProdRetOutDetail.CustomColumnDisplayText, GVListProdRetOutDetail.CustomColumnDisplayText
        If e.Column.FieldName = "no" Then
            e.DisplayText = (e.ListSourceRowIndex + 1).ToString()
        End If
    End Sub
    Private Sub BRefProdRetOut_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BRefProdRetOut.Click
        GVProdRetOut.ApplyFindFilter("")
        view_production_ret_out()
    End Sub

    Private Sub GVProdRetOut_FocusedRowChanged(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles GVProdRetOut.FocusedRowChanged
        Cursor = Cursors.WaitCursor
        Dim id_ret_out As String = "-1"
        Try
            id_ret_out = GVProdRetOut.GetFocusedRowCellValue("id_prod_order_ret_out").ToString
        Catch ex As Exception
        End Try
        view_list_prod_ret_out(id_ret_out)
        Cursor = Cursors.Default
    End Sub

    Private Sub GVProdRetOut_ColumnFilterChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GVProdRetOut.ColumnFilterChanged
        Cursor = Cursors.WaitCursor
        Dim id_ret_out As String = "-1"
        Try
            id_ret_out = GVProdRetOut.GetFocusedRowCellValue("id_prod_order_ret_out").ToString
        Catch ex As Exception
        End Try
        view_list_prod_ret_out(id_ret_out)
        Cursor = Cursors.Default
    End Sub

    Private Sub BGotoProdRetOut_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BGotoProdRetOut.Click
        Cursor = Cursors.WaitCursor
        Try
            FormProductionRet.MdiParent = FormMain
            FormProductionRet.Show()
            FormProductionRet.WindowState = FormWindowState.Maximized
            FormProductionRet.Focus()
            FormProductionRet.XTCReturn.SelectedTabPageIndex = 0
        Catch ex As Exception
            errorProcess()
        End Try
        Cursor = Cursors.Default

        FormProductionRet.GVRetOut.FocusedRowHandle = find_row(FormProductionRet.GVRetOut, "id_prod_order_ret_out", GVProdRetOut.GetFocusedRowCellValue("id_prod_order_ret_out").ToString())
    End Sub

    '================== begin return in production  ======================
    Sub view_production_ret_in()
        Dim query As String = "SELECT h.id_report_status, h.report_status, a.id_prod_order_ret_in, a.prod_order_ret_in_note,  "
        query += "a.prod_order_ret_in_number , b.prod_order_number, c.season, (e.comp_name) AS comp_from, (g.comp_name) AS comp_to, "
        query += "DATE_FORMAT(a.prod_order_ret_in_date,'%d %M %Y') AS prod_order_ret_in_date "
        query += "FROM tb_prod_order_ret_in a "
        query += "INNER JOIN tb_prod_order b ON a.id_prod_order = b.id_prod_order "
        query += "INNER JOIN tb_prod_demand_design b1 ON b.id_prod_demand_design = b1.id_prod_demand_design "
        query += "INNER JOIN tb_prod_demand b2 ON b2.id_prod_demand = b1.id_prod_demand "
        query += "INNER JOIN tb_season c ON b2.id_season = c.id_season "
        query += "INNER JOIN tb_m_comp_contact d ON d.id_comp_contact = a.id_comp_contact_from "
        query += "INNER JOIN tb_m_comp e ON d.id_comp = e.id_comp "
        query += "INNER JOIN tb_m_comp_contact f ON f.id_comp_contact = a.id_comp_contact_to "
        query += "INNER JOIN tb_m_comp g ON f.id_comp = g.id_comp "
        query += "INNER JOIN tb_lookup_report_status h ON a.id_report_status = h.id_report_status "
        query += "ORDER BY a.id_prod_order_ret_in ASC "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")

        GCProdRetIn.DataSource = data
        check_menu()
        If data.Rows.Count > 0 Then
            GVProdRetIn.FocusedRowHandle = 0
            view_list_prod_ret_in(GVProdRetIn.GetFocusedRowCellValue("id_prod_order_ret_in").ToString)
            BGotoProdRetIn.Visible = True
        Else
            BGotoProdRetIn.Visible = False
        End If
    End Sub

    Sub view_list_prod_ret_in(ByVal id_sample_purc_rec As String)
        Dim query = "CALL view_return_in_prod('" + id_sample_purc_rec + "', '0')"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCListProdRetInDetail.DataSource = data
    End Sub
    Private Sub GVListProdRetInDetail_CustomColumnDisplayText(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs) Handles GVListProdRetInDetail.CustomColumnDisplayText, GVListProdRetInDetail.CustomColumnDisplayText
        If e.Column.FieldName = "no" Then
            e.DisplayText = (e.ListSourceRowIndex + 1).ToString()
        End If
    End Sub
    Private Sub BRefProdRetIn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BRefProdRetIn.Click
        GVProdRetIn.ApplyFindFilter("")
        view_production_ret_in()
    End Sub

    Private Sub GVProdRetIn_FocusedRowChanged(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles GVProdRetIn.FocusedRowChanged
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
        view_list_prod_ret_in(GVProdRetIn.GetFocusedRowCellValue("id_prod_order_ret_in").ToString)
    End Sub

    Private Sub BGotoProdRetIn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BGotoProdRetIn.Click
        Cursor = Cursors.WaitCursor
        Try
            FormProductionRet.MdiParent = FormMain
            FormProductionRet.Show()
            FormProductionRet.WindowState = FormWindowState.Maximized
            FormProductionRet.Focus()
            FormProductionRet.XTCReturn.SelectedTabPageIndex = 1
        Catch ex As Exception
            errorProcess()
        End Try
        Cursor = Cursors.Default

        FormProductionRet.GVRetIn.FocusedRowHandle = find_row(FormProductionRet.GVRetIn, "id_prod_order_ret_in", GVProdRetIn.GetFocusedRowCellValue("id_prod_order_ret_in").ToString())
    End Sub

    '=============begin PL FG TO WH============================
    Sub view_production_pl_fg_to_wh()
        Dim query As String = "SELECT ss.id_season, ss.season, alloc.pd_alloc, k.pl_category, i.prod_order_number, a.id_pl_prod_order ,a.id_comp_contact_from , a.id_comp_contact_to, a.pl_prod_order_note, a.pl_prod_order_number, "
        query += "(d.comp_name) AS comp_name_from, (f.comp_name) AS comp_name_to, h.report_status, a.id_report_status, "
        query += "pl_prod_order_date "
        query += "FROM tb_pl_prod_order a "
        query += "INNER JOIN tb_m_comp_contact c ON a.id_comp_contact_from = c.id_comp_contact "
        query += "INNER JOIN tb_m_comp d ON c.id_comp = d.id_comp "
        query += "INNER JOIN tb_m_comp_contact e ON a.id_comp_contact_to = e.id_comp_contact "
        query += "INNER JOIN tb_m_comp f ON e.id_comp = f.id_comp "
        query += "INNER JOIN tb_lookup_report_status h ON h.id_report_status = a.id_report_status "
        query += "INNER JOIN tb_prod_order i ON a.id_prod_order = i.id_prod_order "
        query += "INNER JOIN tb_pl_prod_order_det j ON a.id_pl_prod_order = j.id_pl_prod_order "
        query += "INNER JOIN tb_lookup_pl_category k ON k.id_pl_category = a.id_pl_category "
        query += "INNER JOIN tb_lookup_pd_alloc alloc ON alloc.id_pd_alloc = a.id_pd_alloc "
        query += "INNER JOIN tb_season_delivery del ON del.id_delivery = i.id_delivery "
        query += "INNER JOIN tb_season ss ON ss.id_season = del.id_season "
        query += "GROUP BY a.id_pl_prod_order "
        query += "ORDER BY a.id_pl_prod_order ASC "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")

        GCProdPLToWH.DataSource = data
        check_menu()
        If data.Rows.Count > 0 Then
            GVProdPLToWH.FocusedRowHandle = 0
            Dim id_pl_prod_order_param As String = "-1"
            Try
                id_pl_prod_order_param = GVProdPLToWH.GetFocusedRowCellValue("id_pl_prod_order").ToString
            Catch ex As Exception
            End Try
            view_list_prod_pl_fg_to_wh(id_pl_prod_order_param)
            BGotoProdPLToWH.Visible = True
        Else
            BGotoProdPLToWH.Visible = False
        End If
    End Sub

    Sub view_list_prod_pl_fg_to_wh(ByVal id_sample_purc_rec As String)
        Dim query = "CALL view_PL_prod('" + id_sample_purc_rec + "', '0', '0')"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCListProdPLToWHDetail.DataSource = data
    End Sub

    Private Sub GVListProdPLToWHDetail_CustomColumnDisplayText(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs) Handles GVListProdPLToWHDetail.CustomColumnDisplayText, GVListProdPLToWHDetail.CustomColumnDisplayText
        If e.Column.FieldName = "no" Then
            e.DisplayText = (e.ListSourceRowIndex + 1).ToString()
        End If
    End Sub

    Private Sub BRefProdPLToWH_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BRefProdPLToWH.Click
        GVProdPLToWH.ApplyFindFilter("")
        view_production_pl_fg_to_wh()
    End Sub


    Private Sub GVProdPLToWH_FocusedRowChanged(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles GVProdPLToWH.FocusedRowChanged
        Cursor = Cursors.WaitCursor
        Dim id_pl_prod_order_param As String = "-1"
        Try
            id_pl_prod_order_param = GVProdPLToWH.GetFocusedRowCellValue("id_pl_prod_order").ToString
        Catch ex As Exception
        End Try
        view_list_prod_pl_fg_to_wh(id_pl_prod_order_param)
        Cursor = Cursors.Default
    End Sub

    Private Sub BGotoProdPLToWH_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BGotoProdPLToWH.Click
        Cursor = Cursors.WaitCursor
        Try
            FormProductionPLToWH.MdiParent = FormMain
            FormProductionPLToWH.Show()
            FormProductionPLToWH.WindowState = FormWindowState.Maximized
            FormProductionPLToWH.Focus()
            FormProductionPLToWH.XTCPL.SelectedTabPageIndex = 0
        Catch ex As Exception
            errorProcess()
        End Try
        Cursor = Cursors.Default
        FormProductionPLToWH.GVPL.FocusedRowHandle = find_row(FormProductionPLToWH.GVPL, "id_pl_prod_order", GVProdPLToWH.GetFocusedRowCellValue("id_pl_prod_order").ToString())
    End Sub

    Private Sub GVProdPLToWH_ColumnFilterChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GVProdPLToWH.ColumnFilterChanged
        Cursor = Cursors.WaitCursor
        Dim id_pl_prod_order_param As String = "-1"
        Try
            id_pl_prod_order_param = GVProdPLToWH.GetFocusedRowCellValue("id_pl_prod_order").ToString
        Catch ex As Exception
        End Try
        view_list_prod_pl_fg_to_wh(id_pl_prod_order_param)
        Cursor = Cursors.Default
    End Sub

    '=============begin Rec PL FG TO WH===========================
    Sub view_production_pl_fg_to_wh_rec()
        Dim query As String = "SELECT k.pl_category, i.pl_prod_order_number, a.id_pl_prod_order_rec ,a.id_comp_contact_from , a.id_comp_contact_to, a.pl_prod_order_rec_note, a.pl_prod_order_rec_number, "
        query += "(d.comp_name) AS comp_name_from, (f.comp_name) AS comp_name_to, h.report_status, a.id_report_status, "
        query += "DATE_FORMAT(a.pl_prod_order_rec_date,'%d %M %Y') AS pl_prod_order_rec_date "
        query += "FROM tb_pl_prod_order_rec a "
        query += "INNER JOIN tb_m_comp_contact c ON a.id_comp_contact_from = c.id_comp_contact "
        query += "INNER JOIN tb_m_comp d ON c.id_comp = d.id_comp "
        query += "INNER JOIN tb_m_comp_contact e ON a.id_comp_contact_to = e.id_comp_contact "
        query += "INNER JOIN tb_m_comp f ON e.id_comp = f.id_comp "
        query += "INNER JOIN tb_lookup_report_status h ON h.id_report_status = a.id_report_status "
        query += "INNER JOIN tb_pl_prod_order i ON a.id_pl_prod_order = i.id_pl_prod_order "
        query += "INNER JOIN tb_pl_prod_order_det j ON a.id_pl_prod_order = j.id_pl_prod_order "
        query += "INNER JOIN tb_lookup_pl_category k ON k.id_pl_category = i.id_pl_category "
        query += "GROUP BY a.id_pl_prod_order_rec "
        query += "ORDER BY a.id_pl_prod_order_rec ASC "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")

        GCProdPLToWHRec.DataSource = data
        check_menu()
        If data.Rows.Count > 0 Then
            GVProdPLToWHRec.FocusedRowHandle = 0
            Dim id_pl_prod_order_rec_param As String = "-1"
            Try
                id_pl_prod_order_rec_param = GVProdPLToWHRec.GetFocusedRowCellValue("id_pl_prod_order_rec").ToString
            Catch ex As Exception
            End Try
            view_list_prod_pl_fg_to_wh_rec(id_pl_prod_order_rec_param)
            BGotoProdPLToWHRec.Visible = True
        Else
            BGotoProdPLToWHRec.Visible = False
        End If
    End Sub

    Sub view_list_prod_pl_fg_to_wh_rec(ByVal id_sample_purc_rec As String)
        Dim query = "CALL view_pl_prod_rec('" + id_sample_purc_rec + "', '0')"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCListProdPLToWHRecDetail.DataSource = data
    End Sub

    Private Sub GVListProdPLToWHRecDetail_CustomColumnDisplayText(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs) Handles GVListProdPLToWHRecDetail.CustomColumnDisplayText, GVListProdPLToWHRecDetail.CustomColumnDisplayText
        If e.Column.FieldName = "no" Then
            e.DisplayText = (e.ListSourceRowIndex + 1).ToString()
        End If
    End Sub

    Private Sub BRefProdPLToWHRec_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BRefProdPLToWHRec.Click
        GVProdPLToWHRec.ApplyFindFilter("")
        view_production_pl_fg_to_wh_rec()
    End Sub

    Private Sub GVProdPLToWHRec_FocusedRowChanged(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles GVProdPLToWHRec.FocusedRowChanged
        Cursor = Cursors.WaitCursor
        Dim id_pl_prod_order_rec_param As String = "-1"
        Try
            id_pl_prod_order_rec_param = GVProdPLToWHRec.GetFocusedRowCellValue("id_pl_prod_order_rec").ToString
        Catch ex As Exception
        End Try
        view_list_prod_pl_fg_to_wh_rec(id_pl_prod_order_rec_param)
        Cursor = Cursors.Default
    End Sub

    Private Sub GVProdPLToWHRec_ColumnFilterChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GVProdPLToWHRec.ColumnFilterChanged
        Cursor = Cursors.WaitCursor
        Dim id_pl_prod_order_rec_param As String = "-1"
        Try
            id_pl_prod_order_rec_param = GVProdPLToWHRec.GetFocusedRowCellValue("id_pl_prod_order_rec").ToString
        Catch ex As Exception
        End Try
        view_list_prod_pl_fg_to_wh_rec(id_pl_prod_order_rec_param)
        Cursor = Cursors.Default
    End Sub

    Private Sub BGotoProdPLToWHRec_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BGotoProdPLToWHRec.Click
        Cursor = Cursors.WaitCursor
        Try
            FormProductionPLToWHRec.MdiParent = FormMain
            FormProductionPLToWHRec.Show()
            FormProductionPLToWHRec.WindowState = FormWindowState.Maximized
            FormProductionPLToWHRec.Focus()
            FormProductionPLToWHRec.XTCPL.SelectedTabPageIndex = 0
        Catch ex As Exception
            errorProcess()
        End Try
        Cursor = Cursors.Default
        FormProductionPLToWHRec.GVPL.FocusedRowHandle = find_row(FormProductionPLToWHRec.GVPL, "id_pl_prod_order_rec", GVProdPLToWHRec.GetFocusedRowCellValue("id_pl_prod_order_rec").ToString())
    End Sub

    '==============SALES ORDER=========================
    Sub view_sales_order()
        Dim query As String = "SELECT a.id_sales_order, a.id_store_contact_to, (d.comp_name) AS store_name_to,a.id_report_status, f.report_status, "
        query += "a.sales_order_note,a.sales_order_date, a.sales_order_note, a.sales_order_number, "
        query += "(a.sales_order_date) AS sales_order_date "
        query += "FROM tb_sales_order a "
        'query += "INNER JOIN tb_sales_order_det b ON a.id_sales_order = b.id_sales_order "
        query += "INNER JOIN tb_m_comp_contact c ON c.id_comp_contact = a.id_store_contact_to "
        query += "INNER JOIN tb_m_comp d ON c.id_comp = d.id_comp "
        query += "INNER JOIN tb_lookup_report_status f ON f.id_report_status = a.id_report_status "
        query += "ORDER BY a.id_sales_order ASC "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")

        GCSalesOrder.DataSource = data
        check_menu()
        If data.Rows.Count > 0 Then
            GVSalesOrder.FocusedRowHandle = 0
            Dim id_sales_order_param As String = "-1"
            Try
                id_sales_order_param = GVSalesOrder.GetFocusedRowCellValue("id_sales_order").ToString
            Catch ex As Exception
            End Try
            view_list_sales_order(id_sales_order_param)
            BGotoSalesOrder.Visible = True
        Else
            BGotoSalesOrder.Visible = False
        End If
    End Sub

    Sub view_list_sales_order(ByVal id_sales_order As String)
        Dim query As String = "CALL view_sales_order('" + id_sales_order + "')"
        Dim data As DataTable = execute_query(query, "-1", True, "", "", "", "")
        GCListSalesOrder.DataSource = data
    End Sub

    Private Sub BRefSalesOrder_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BRefSalesOrder.Click
        GVSalesOrder.ApplyFindFilter("")
        view_sales_order()
    End Sub

    Private Sub GVSalesOrder_FocusedRowChanged(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles GVSalesOrder.FocusedRowChanged
        Cursor = Cursors.WaitCursor
        Dim id_sales_order_param As String = "-1"
        Try
            id_sales_order_param = GVSalesOrder.GetFocusedRowCellValue("id_sales_order").ToString
        Catch ex As Exception
        End Try
        view_list_sales_order(id_sales_order_param)
        Cursor = Cursors.Default
    End Sub

    Private Sub BGotoSalesOrder_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BGotoSalesOrder.Click
        Cursor = Cursors.WaitCursor
        Try
            FormSalesOrder.MdiParent = FormMain
            FormSalesOrder.Show()
            FormSalesOrder.WindowState = FormWindowState.Maximized
            FormSalesOrder.Focus()
            FormSalesOrder.XTCSalesOrder.SelectedTabPageIndex = 0
        Catch ex As Exception
            errorProcess()
        End Try
        Cursor = Cursors.Default
        FormSalesOrder.GVSalesOrder.FocusedRowHandle = find_row(FormSalesOrder.GVSalesOrder, "id_sales_order", GVSalesOrder.GetFocusedRowCellValue("id_sales_order").ToString())
    End Sub

    Private Sub GVSalesOrder_ColumnFilterChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GVSalesOrder.ColumnFilterChanged
        Cursor = Cursors.WaitCursor
        Dim id_sales_order_param As String = "-1"
        Try
            id_sales_order_param = GVSalesOrder.GetFocusedRowCellValue("id_sales_order").ToString
        Catch ex As Exception
        End Try
        view_list_sales_order(id_sales_order_param)
        Cursor = Cursors.Default
    End Sub

    Private Sub GVListSalesOrder_CustomColumnDisplayText(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs) Handles GVListSalesOrder.CustomColumnDisplayText
        If e.Column.FieldName = "no" Then
            e.DisplayText = (e.ListSourceRowIndex + 1).ToString()
        End If
    End Sub

    '====================DELIVERY ORDER==============================
    Sub view_sales_order_del()
        Dim query As String = "SELECT a.id_pl_sales_order_del, a.id_store_contact_to, (d.comp_name) AS store_name_to, id_comp_contact_from,a.id_report_status, f.report_status, "
        query += "a.pl_sales_order_del_note, a.pl_sales_order_del_date, a.pl_sales_order_del_number, b.sales_order_number, "
        query += "DATE_FORMAT(a.pl_sales_order_del_date,'%d %M %Y') AS pl_sales_order_del_date, (wh.id_comp) AS `id_wh`, (wh.comp_name) AS `wh_name`, cat.id_so_status, cat.so_status "
        query += "FROM tb_pl_sales_order_del a "
        query += "INNER JOIN tb_sales_order b ON a.id_sales_order = b.id_sales_order "
        query += "INNER JOIN tb_m_comp_contact c ON c.id_comp_contact = a.id_store_contact_to "
        query += "INNER JOIN tb_m_comp d ON c.id_comp = d.id_comp "
        query += "INNER JOIN tb_lookup_report_status f ON f.id_report_status = a.id_report_status "
        query += "INNER JOIN tb_m_comp_contact wh_cont ON wh_cont.id_comp_contact = a.id_comp_contact_from "
        query += "INNER JOIN tb_m_comp wh ON wh.id_comp = wh_cont.id_comp "
        query += "INNER JOIN tb_lookup_so_status cat ON cat.id_so_status = b.id_so_status "
        query += "ORDER BY a.id_pl_sales_order_del ASC "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")

        GCSalesDelOrder.DataSource = data
        check_menu()
        If data.Rows.Count > 0 Then
            GVSalesDelOrder.FocusedRowHandle = 0
            Dim id_pl As String = "-1"
            Try
                id_pl = GVSalesDelOrder.GetFocusedRowCellValue("id_pl_sales_order_del").ToString
            Catch ex As Exception
            End Try
            view_list_sales_order_del(id_pl)
            BGotoSalesOrder.Visible = True
        Else
            BGotoSalesOrder.Visible = False
        End If
    End Sub

    Sub view_list_sales_order_del(ByVal id_del As String)
        Dim query As String = "CALL view_pl_sales_order_del('" + id_del + "')"
        Dim data As DataTable = execute_query(query, "-1", True, "", "", "", "")
        GCListSalesOrderDel.DataSource = data
    End Sub

    Private Sub BRefSalesOrderDel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BRefSalesOrderDel.Click
        GVSalesDelOrder.ApplyFindFilter("")
        view_sales_order_del()
    End Sub

    Private Sub GVSalesDelOrder_FocusedRowChanged(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles GVSalesDelOrder.FocusedRowChanged
        Cursor = Cursors.WaitCursor
        Dim id_pl As String = "-1"
        Try
            id_pl = GVSalesDelOrder.GetFocusedRowCellValue("id_pl_sales_order_del").ToString
        Catch ex As Exception
        End Try
        view_list_sales_order_del(id_pl)
        GVListSalesOrderDel.OptionsBehavior.AutoExpandAllGroups = True
        Cursor = Cursors.Default
    End Sub

    Private Sub GVSalesDelOrder_ColumnFilterChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Cursor = Cursors.WaitCursor
        Dim id_pl As String = "-1"
        Try
            id_pl = GVSalesDelOrder.GetFocusedRowCellValue("id_pl_sales_order_del").ToString
        Catch ex As Exception
        End Try
        view_list_sales_order_del(id_pl)
        Cursor = Cursors.Default
    End Sub

    Private Sub BGotoSalesOrderDel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BGotoSalesOrderDel.Click
        Cursor = Cursors.WaitCursor
        Try
            FormSalesDelOrder.MdiParent = FormMain
            FormSalesDelOrder.Show()
            FormSalesDelOrder.WindowState = FormWindowState.Maximized
            FormSalesDelOrder.Focus()
            FormSalesDelOrder.XTCSalesDelOrder.SelectedTabPageIndex = 0
        Catch ex As Exception
            errorProcess()
        End Try
        Cursor = Cursors.Default
        FormSalesDelOrder.GVSalesDelOrder.FocusedRowHandle = find_row(FormSalesDelOrder.GVSalesDelOrder, "id_pl_sales_order_del", GVSalesDelOrder.GetFocusedRowCellValue("id_pl_sales_order_del").ToString())
    End Sub

    Private Sub GVListSalesOrderDel_CustomColumnDisplayText(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs) Handles GVListSalesOrderDel.CustomColumnDisplayText
        If e.Column.FieldName = "no" Then
            e.DisplayText = (e.ListSourceRowIndex + 1).ToString()
        End If
    End Sub

    '=======================SALES RETURN ORDER===================

    Private Sub BGotoSalesReturnOrder_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BGotoSalesReturnOrder.Click
        Cursor = Cursors.WaitCursor
        Try
            FormSalesReturnOrder.MdiParent = FormMain
            FormSalesReturnOrder.Show()
            FormSalesReturnOrder.WindowState = FormWindowState.Maximized
            FormSalesReturnOrder.Focus()
        Catch ex As Exception
            errorProcess()
        End Try
        Cursor = Cursors.Default
        FormSalesReturnOrder.GVSalesReturnOrder.FocusedRowHandle = find_row(FormSalesReturnOrder.GVSalesReturnOrder, "id_sales_return_order", GVSalesReturnOrder.GetFocusedRowCellValue("id_sales_return_order").ToString())
    End Sub

    Private Sub BRefSalesReturnOrder_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BRefSalesReturnOrder.Click
        GVSalesReturnOrder.ApplyFindFilter("")
        view_sales_return_order()
    End Sub

    Sub view_sales_return_order()
        Dim query As String = "SELECT a.id_sales_return_order, a.id_store_contact_to, (d.comp_name) AS store_name_to,a.id_report_status, f.report_status, "
        query += "a.sales_return_order_note, a.sales_return_order_date, a.sales_return_order_note, a.sales_return_order_number, "
        query += "DATE_FORMAT(a.sales_return_order_date,'%d %M %Y') AS sales_return_order_date, "
        query += "DATE_FORMAT(a.sales_return_order_est_date,'%d %M %Y') AS sales_return_order_est_date "
        query += "FROM tb_sales_return_order a "
        'query += "INNER JOIN tb_sales_return_order_det b ON a.id_sales_return_order = b.id_sales_return_order "
        query += "INNER JOIN tb_m_comp_contact c ON c.id_comp_contact = a.id_store_contact_to "
        query += "INNER JOIN tb_m_comp d ON c.id_comp = d.id_comp "
        query += "INNER JOIN tb_lookup_report_status f ON f.id_report_status = a.id_report_status "
        query += "ORDER BY a.id_sales_return_order ASC "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCSalesReturnOrder.DataSource = data
        check_menu()
        If data.Rows.Count > 0 Then
            GVSalesReturnOrder.FocusedRowHandle = 0
            view_list_sales_return_order(GVSalesReturnOrder.GetFocusedRowCellValue("id_sales_return_order").ToString)
            BGotoSalesReturnOrder.Visible = True
        Else
            BGotoSalesReturnOrder.Visible = False
        End If
    End Sub

    Sub view_list_sales_return_order(ByVal id_sales_order As String)
        Dim query As String = "CALL view_sales_return_order('" + id_sales_order + "')"
        Dim data As DataTable = execute_query(query, "-1", True, "", "", "", "")
        GCListSalesReturnOrder.DataSource = data
        GVListSalesReturnOrder.OptionsBehavior.AutoExpandAllGroups = True
    End Sub

    Private Sub GVSalesReturnOrder_FocusedRowChanged(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles GVSalesReturnOrder.FocusedRowChanged
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
        view_list_sales_return_order(GVSalesReturnOrder.GetFocusedRowCellValue("id_sales_return_order").ToString)
    End Sub

    Private Sub GVListSalesReturnOrder_CustomColumnDisplayText(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs) Handles GVListSalesReturnOrder.CustomColumnDisplayText
        If e.Column.FieldName = "no" Then
            e.DisplayText = (e.ListSourceRowIndex + 1).ToString()
        End If
    End Sub

    '========================SALES RETURN======================================
    Private Sub BGotoSalesReturn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BGotoSalesReturn.Click
        Cursor = Cursors.WaitCursor
        Try
            FormSalesReturn.MdiParent = FormMain
            FormSalesReturn.Show()
            FormSalesReturn.WindowState = FormWindowState.Maximized
            FormSalesReturn.Focus()
        Catch ex As Exception
            errorProcess()
        End Try
        Cursor = Cursors.Default
        FormSalesReturn.GVSalesReturn.FocusedRowHandle = find_row(FormSalesReturn.GVSalesReturn, "id_sales_return", GVSalesReturn.GetFocusedRowCellValue("id_sales_return").ToString())
    End Sub

    Private Sub BRefSalesReturn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BRefSalesReturn.Click
        GVSalesReturn.ApplyFindFilter("")
        view_sales_return()
    End Sub

    Sub view_sales_return()
        Dim query As String = ""
        query += "SELECT a.id_comp_contact_to, a.id_report_status, a.id_sales_return, a.id_sales_return_order, DATE_FORMAT(a.sales_return_date, '%d %M %Y') AS sales_return_date, "
        query += "a.sales_return_note, a.sales_return_number, a.sales_return_store_number,  "
        query += "(c.comp_name) AS store_name_from, (c.comp_name) AS store_name_to, "
        query += "(e.comp_name) AS comp_name_to, (e.comp_number) AS comp_number_to, "
        query += "f.sales_return_order_number, g.report_status "
        query += "FROM tb_sales_return a  "
        query += "INNER JOIN tb_m_comp_contact b ON a.id_store_contact_from = b.id_comp_contact "
        query += "INNER JOIN tb_m_comp c ON c.id_comp = b.id_comp "
        query += "INNER JOIN tb_m_comp_contact d ON a.id_comp_contact_to = d.id_comp_contact "
        query += "INNER JOIN tb_m_comp e ON e.id_comp = d.id_comp "
        query += "INNER JOIN tb_sales_return_order f ON f.id_sales_return_order = a.id_sales_return_order "
        query += "INNER JOIN tb_lookup_report_status g ON g.id_report_status = a.id_report_status "
        query += "ORDER BY a.id_sales_return ASC "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCSalesReturn.DataSource = data
        check_menu()
        If data.Rows.Count > 0 Then
            GVSalesReturn.FocusedRowHandle = 0
            view_list_sales_return(GVSalesReturn.GetFocusedRowCellValue("id_sales_return").ToString)
            BGotoSalesReturn.Visible = True
        Else
            BGotoSalesReturn.Visible = False
        End If
    End Sub

    Sub view_list_sales_return(ByVal id_sales_order As String)
        Dim query As String = "CALL view_sales_return('" + id_sales_order + "')"
        Dim data As DataTable = execute_query(query, "-1", True, "", "", "", "")
        GCListSalesReturn.DataSource = data
        GVListSalesReturn.OptionsBehavior.AutoExpandAllGroups = True
    End Sub


    Private Sub GVSalesReturn_FocusedRowChanged(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles GVSalesReturn.FocusedRowChanged
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
        view_list_sales_return(GVSalesReturn.GetFocusedRowCellValue("id_sales_return").ToString)
    End Sub

    Private Sub GVListSalesReturn_CustomColumnDisplayText(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs) Handles GVListSalesReturn.CustomColumnDisplayText
        If e.Column.FieldName = "no" Then
            e.DisplayText = (e.ListSourceRowIndex + 1).ToString()
        End If
    End Sub

    '======================SALES POS=======================================
    Private Sub GVListSalesPOS_CustomColumnDisplayText(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs) Handles GVListSalesPOS.CustomColumnDisplayText
        If e.Column.FieldName = "no" Then
            e.DisplayText = (e.ListSourceRowIndex + 1).ToString()
        End If
    End Sub


    Private Sub BGotoSalesPOS_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BGotoSalesPOS.Click
        Cursor = Cursors.WaitCursor
        Try
            FormSalesPOS.MdiParent = FormMain
            FormSalesPOS.Show()
            FormSalesPOS.WindowState = FormWindowState.Maximized
            FormSalesPOS.Focus()
        Catch ex As Exception
            errorProcess()
        End Try
        Cursor = Cursors.Default
        FormSalesPOS.GVSalesPOS.FocusedRowHandle = find_row(FormSalesPOS.GVSalesPOS, "id_sales_pos", GVSalesPOS.GetFocusedRowCellValue("id_sales_pos").ToString())
    End Sub


    Private Sub BRefSalesPOS_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BRefSalesPOS.Click
        GVSalesPOS.ApplyFindFilter("")
        view_sales_pos()
    End Sub

    Sub view_sales_pos()
        Dim query As String = ""
        query += "SELECT a.id_report_status, a.id_sales_pos, DATE_FORMAT(a.sales_pos_date, '%d %M %Y') AS sales_pos_date, a.sales_pos_note, "
        query += "a.sales_pos_number, (c.comp_name) AS store_name_from, d.report_status "
        query += "FROM tb_sales_pos a "
        query += "INNER JOIN tb_m_comp_contact b ON a.id_store_contact_from = b.id_comp_contact "
        query += "INNER JOIN tb_m_comp c ON c.id_comp = b.id_comp "
        query += "INNER JOIN tb_lookup_report_status d ON d.id_report_status = a.id_report_status "
        query += "AND a.id_memo_type='1' "
        query += "ORDER BY a.id_sales_pos ASC "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCSalesPOS.DataSource = data
        check_menu()
        If data.Rows.Count > 0 Then
            GVSalesPOS.FocusedRowHandle = 0
            view_list_sales_pos(GVSalesPOS.GetFocusedRowCellValue("id_sales_pos").ToString)
            BGotoSalesPOS.Visible = True
        Else
            BGotoSalesPOS.Visible = False
        End If
    End Sub

    Sub view_list_sales_pos(ByVal id_sales_pos As String)
        Dim query As String = "CALL view_sales_pos('" + id_sales_pos + "')"
        Dim data As DataTable = execute_query(query, "-1", True, "", "", "", "")
        GCListSalesPOS.DataSource = data
        GVListSalesPOS.OptionsBehavior.AutoExpandAllGroups = True
    End Sub

    Private Sub GVSalesPOS_FocusedRowChanged(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles GVSalesPOS.FocusedRowChanged
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
        view_list_sales_pos(GVSalesPOS.GetFocusedRowCellValue("id_sales_pos").ToString)
    End Sub

    '----------------RETURN QUALITY CONTROL
    Private Sub BGotoSalesReturnQC_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BGotoSalesReturnQC.Click
        Cursor = Cursors.WaitCursor
        Try
            FormSalesReturnQC.MdiParent = FormMain
            FormSalesReturnQC.Show()
            FormSalesReturnQC.WindowState = FormWindowState.Maximized
            FormSalesReturnQC.Focus()
        Catch ex As Exception
            errorProcess()
        End Try
        Cursor = Cursors.Default
        FormSalesReturnQC.GVSalesReturnQC.FocusedRowHandle = find_row(FormSalesReturnQC.GVSalesReturnQC, "id_sales_return_qc", GVSalesReturnQC.GetFocusedRowCellValue("id_sales_return_qc").ToString())
    End Sub

    Private Sub GVSalesReturnQC_ColumnFilterChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GVSalesReturnQC.ColumnFilterChanged
        Cursor = Cursors.WaitCursor
        Dim id_sales_return_qc_par As String = "-1"
        Try
            id_sales_return_qc_par = GVSalesReturnQC.GetFocusedRowCellValue("id_sales_return_qc").ToString
        Catch ex As Exception
        End Try
        Cursor = Cursors.Default
    End Sub

    Private Sub BRefSalesReturnQC_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BRefSalesReturnQC.Click
        GVSalesReturnQC.ApplyFindFilter("")
        view_sales_return_qc()
    End Sub

    Sub view_sales_return_qc()
        Dim query As String = ""
        query += "SELECT a.id_comp_contact_to, a.id_report_status, a.id_sales_return_qc, a.id_sales_return, DATE_FORMAT(a.sales_return_qc_date, '%d %M %Y') AS sales_return_qc_date, "
        query += "a.sales_return_qc_note, a.sales_return_qc_number, "
        query += "(c.comp_name) AS store_name_from, (c.comp_number) AS store_number_from, "
        query += "(e.comp_name) AS comp_name_to, (e.comp_number) AS comp_number_to, "
        query += "f.sales_return_number, g.report_status, h.pl_category "
        query += "FROM tb_sales_return_qc a  "
        query += "INNER JOIN tb_m_comp_contact b ON a.id_store_contact_from = b.id_comp_contact "
        query += "INNER JOIN tb_m_comp c ON c.id_comp = b.id_comp "
        query += "INNER JOIN tb_m_comp_contact d ON a.id_comp_contact_to = d.id_comp_contact "
        query += "INNER JOIN tb_m_comp e ON e.id_comp = d.id_comp "
        query += "INNER JOIN tb_sales_return f ON f.id_sales_return = a.id_sales_return "
        query += "INNER JOIN tb_lookup_report_status g ON g.id_report_status = a.id_report_status "
        query += "INNER JOIN tb_lookup_pl_category h ON h.id_pl_category = a.id_pl_category "
        query += "ORDER BY a.id_sales_return_qc ASC "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCSalesReturnQC.DataSource = data
        check_menu()
        If data.Rows.Count > 0 Then
            GVSalesReturnQC.FocusedRowHandle = 0
            Dim id_sales_return_qc_par As String = "-1"
            Try
                id_sales_return_qc_par = GVSalesReturnQC.GetFocusedRowCellValue("id_sales_return_qc").ToString
            Catch ex As Exception
            End Try
            view_list_sales_return_qc(id_sales_return_qc_par)
            BGotoSalesReturnQC.Visible = True
        Else
            BGotoSalesReturnQC.Visible = False
        End If
    End Sub

    Sub view_list_sales_return_qc(ByVal id_sales_order As String)
        Dim query As String = "CALL view_sales_return_qc('" + id_sales_order + "')"
        Dim data As DataTable = execute_query(query, "-1", True, "", "", "", "")
        GCListSalesReturnQC.DataSource = data
        GVListSalesReturnQC.OptionsBehavior.AutoExpandAllGroups = True
    End Sub


    Private Sub GVSalesReturnQC_FocusedRowChanged(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles GVSalesReturnQC.FocusedRowChanged
        Cursor = Cursors.WaitCursor
        Dim id_sales_return_qc_par As String = "-1"
        Try
            id_sales_return_qc_par = GVSalesReturnQC.GetFocusedRowCellValue("id_sales_return_qc").ToString
        Catch ex As Exception
        End Try
        Cursor = Cursors.Default
    End Sub


    Private Sub GVListSalesReturnQC_CustomColumnDisplayText(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs) Handles GVListSalesReturnQC.CustomColumnDisplayText
        If e.Column.FieldName = "no" Then
            e.DisplayText = (e.ListSourceRowIndex + 1).ToString()
        End If
    End Sub

    '====================SALES INVOICE================================
    Private Sub BGotoSalesInvoice_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BGotoSalesInvoice.Click
        Cursor = Cursors.WaitCursor
        Try
            FormSalesInvoice.MdiParent = FormMain
            FormSalesInvoice.Show()
            FormSalesInvoice.WindowState = FormWindowState.Maximized
            FormSalesInvoice.Focus()
        Catch ex As Exception
            errorProcess()
        End Try
        Cursor = Cursors.Default
        FormSalesInvoice.GVSalesInvoice.FocusedRowHandle = find_row(FormSalesInvoice.GVSalesInvoice, "id_sales_invoice", GVSalesInvoice.GetFocusedRowCellValue("id_sales_invoice").ToString())
    End Sub

    Private Sub BRefSalesInvoice_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BRefSalesInvoice.Click
        GVSalesInvoice.ApplyFindFilter("")
        view_sales_invoice()
    End Sub

    Sub view_sales_invoice()
        Dim query As String = ""
        query += "SELECT a.id_report_status,a.id_sales_invoice, a.sales_invoice_discount, "
        query += "a.sales_invoice_discount, a.sales_invoice_end_period, a.sales_invoice_note, a.sales_invoice_number, a.sales_invoice_start_period, "
        query += "a.sales_invoice_total, a.sales_invoice_vat, b.so_type, c.report_status, "
        query += "CONCAT_WS(' - ', DATE_FORMAT(a.sales_invoice_start_period, '%d %M %Y') ,DATE_FORMAT(a.sales_invoice_start_period, '%d %M %Y')) AS sales_invoice_period, "
        query += "(e.comp_name) AS store_name_to, (e.id_comp) AS id_store, (e.address_primary) AS store_address_to, (e.comp_number) AS store_number_to, a.id_store_contact_to, "
        query += "DATE_FORMAT(a.sales_invoice_date, '%d %M %Y') AS sales_invoice_date, "
        query += "DATE_FORMAT(a.sales_invoice_due_date, '%d %M %Y') AS sales_invoice_due_date "
        query += "FROM tb_sales_invoice a "
        query += "INNER JOIN tb_lookup_so_type b ON b.id_so_type = a.id_so_type "
        query += "INNER JOIN tb_lookup_report_status c ON c.id_report_status = a.id_report_status "
        query += "INNER JOIN tb_m_comp_contact d ON d.id_comp_contact = a.id_store_contact_to "
        query += "INNER JOIN tb_m_comp e ON e.id_comp = d.id_comp "
        query += "ORDER BY a.id_sales_invoice ASC "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCSalesInvoice.DataSource = data
        check_menu()
        If data.Rows.Count > 0 Then
            GVSalesInvoice.FocusedRowHandle = 0
            view_list_sales_invoice(GVSalesInvoice.GetFocusedRowCellValue("id_sales_invoice").ToString)
            BGotoSalesInvoice.Visible = True
        Else
            BGotoSalesInvoice.Visible = False
        End If
    End Sub

    Sub view_list_sales_invoice(ByVal id_sales_invoice)
        Dim query As String = ""
        query = "CALL view_sales_invoice('" + id_sales_invoice + "', '2') "
        Dim data As DataTable = execute_query(query, "-1", True, "", "", "", "")
        GCListSalesInvoice.DataSource = data
        GVListSalesInvoice.OptionsBehavior.AutoExpandAllGroups = True
    End Sub


    Private Sub GVListSalesInvoice_CustomColumnDisplayText(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs) Handles GVListSalesInvoice.CustomColumnDisplayText
        If e.Column.FieldName = "no" Then
            e.DisplayText = (e.ListSourceRowIndex + 1).ToString()
        End If
    End Sub


    Private Sub GVSalesInvoice_FocusedRowChanged(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles GVSalesInvoice.FocusedRowChanged
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
        view_list_sales_invoice(GVSalesInvoice.GetFocusedRowCellValue("id_sales_invoice").ToString)
    End Sub

    '=========================STOCK OPNAME WH===========================

    Private Sub BtnGoToFGSOStore_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnGoToFGSOStore.Click
        Cursor = Cursors.WaitCursor
        Try
            FormFGStockOpnameStore.MdiParent = FormMain
            FormFGStockOpnameStore.Show()
            FormFGStockOpnameStore.WindowState = FormWindowState.Maximized
            FormFGStockOpnameStore.Focus()
        Catch ex As Exception
            errorProcess()
        End Try
        Cursor = Cursors.Default
        FormFGStockOpnameStore.GVSOStore.FocusedRowHandle = find_row(FormFGStockOpnameStore.GVSOStore, "id_fg_so_store", GVSOStore.GetFocusedRowCellValue("id_fg_so_store").ToString())
    End Sub

    Private Sub BRefFGSOStore_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BRefFGSOStore.Click
        GVSOStore.ApplyFindFilter("")
        view_fg_so_store()
    End Sub

    Sub view_fg_so_store()
        Dim query As String = ""
        query += "SELECT lockx.lock, so.id_lock, so.id_fg_so_store, so.fg_so_store_number, so.id_report_status,stat.report_status, "
        query += "DATE_FORMAT(so.fg_so_store_date_created, '%d %M %Y / %H:%i') AS fg_so_store_date_created, "
        query += "DATE_FORMAT(so.fg_so_store_last_update, '%d %M %Y / %H:%i') AS fg_so_store_last_update, "
        query += "(comp_contact.id_comp_contact) AS id_store_contact_from, (comp.id_comp) AS id_store_from, "
        query += "(comp.comp_number) AS store_number_from, (comp.comp_name) AS store_name_from "
        query += "FROM tb_fg_so_store so "
        'query += "INNER JOIN tb_fg_so_store_det so_det ON so.id_fg_so_store = so_det.id_fg_so_store "
        query += "INNER JOIN tb_m_comp_contact comp_contact ON comp_contact.id_comp_contact = so.id_store_contact_from "
        query += "INNER JOIN tb_m_comp comp ON comp.id_comp = comp_contact.id_comp "
        query += "INNER JOIN tb_lookup_report_status stat ON stat.id_report_status = so.id_report_status "
        query += "INNER JOIN tb_lookup_lock lockx ON lockx.id_lock = so.id_lock "
        query += "WHERE so.id_lock = '2' "
        query += "ORDER BY so.id_fg_so_store ASC "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCSOStore.DataSource = data
        check_menu()
        If data.Rows.Count > 0 Then
            GVSOStore.FocusedRowHandle = 0
            view_list_fg_so_store(GVSOStore.GetFocusedRowCellValue("id_fg_so_store").ToString)
            BtnGoToFGSOStore.Visible = True
        Else
            BtnGoToFGSOStore.Visible = False
        End If
    End Sub

    Sub view_list_fg_so_store(ByVal id_fg_so_store_param As String)
        Dim query As String = "CALL view_fg_so_store_sum('" + id_fg_so_store_param + "')"
        Dim data As DataTable = execute_query(query, "-1", True, "", "", "", "")
        GCListSOStore.DataSource = data
    End Sub

    Private Sub GVListSOStore_CustomColumnDisplayText(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs) Handles GVListSOStore.CustomColumnDisplayText
        If e.Column.FieldName = "no" Then
            e.DisplayText = (e.ListSourceRowIndex + 1).ToString()
        End If
    End Sub


    Private Sub GVSOStore_FocusedRowChanged(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles GVSOStore.FocusedRowChanged
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
        view_list_fg_so_store(GVSOStore.GetFocusedRowCellValue("id_fg_so_store").ToString)
    End Sub

    '================= MISSING FG===================================
    Private Sub BtnGoToFGMissing_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnGoToFGMissing.Click
        Cursor = Cursors.WaitCursor
        Try
            FormFGMissing.MdiParent = FormMain
            FormFGMissing.Show()
            FormFGMissing.WindowState = FormWindowState.Maximized
            FormFGMissing.Focus()
            FormFGMissing.XTCFGMissing.SelectedTabPageIndex = 0
        Catch ex As Exception
            errorProcess()
        End Try
        FormFGMissing.GVFGMissing.FocusedRowHandle = find_row(FormFGMissing.GVFGMissing, "id_sales_pos", GVFGMissing.GetFocusedRowCellValue("id_sales_pos").ToString())
        Cursor = Cursors.Default
    End Sub

    Private Sub BRefFGMissing_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BRefFGMissing.Click
        Cursor = Cursors.WaitCursor
        GVFGMissing.ApplyFindFilter("")
        view_fg_missing()
        Cursor = Cursors.Default
    End Sub

    Sub view_fg_missing()
        Dim query_c As ClassSalesInv = New ClassSalesInv()
        Dim query As String = query_c.queryMain("AND a.id_memo_type =''3'' ", "1")
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCFGMissing.DataSource = data
        check_menu()
        If data.Rows.Count > 0 Then
            GVFGMissing.FocusedRowHandle = 0
            Dim id_fg_missing_param As String = "-1"
            Try
                id_fg_missing_param = GVFGMissing.GetFocusedRowCellValue("id_sales_pos").ToString
            Catch ex As Exception
            End Try
            view_list_fg_missing(id_fg_missing_param)
            BtnGoToFGMissing.Visible = True
        Else
            BtnGoToFGMissing.Visible = False
        End If
    End Sub

    Sub view_list_fg_missing(ByVal id_fg_missing_param As String)
        Dim query_c As ClassSalesInv = New ClassSalesInv()
        Dim query As String = query_c.queryDetail(id_fg_missing_param)
        Dim data As DataTable = execute_query(query, "-1", True, "", "", "", "")
        GCListFGMissing.DataSource = data
    End Sub

    Private Sub GVFGMissing_FocusedRowChanged(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles GVFGMissing.FocusedRowChanged
        Cursor = Cursors.WaitCursor
        Dim id_fg_missing_param As String = "-1"
        Try
            id_fg_missing_param = GVFGMissing.GetFocusedRowCellValue("id_sales_pos").ToString
        Catch ex As Exception
        End Try
        view_list_fg_missing(id_fg_missing_param)
        Cursor = Cursors.Default
    End Sub

    Private Sub GVFGMissing_ColumnFilterChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GVFGMissing.ColumnFilterChanged
        Cursor = Cursors.WaitCursor
        Dim id_fg_missing_param As String = "-1"
        Try
            id_fg_missing_param = GVFGMissing.GetFocusedRowCellValue("id_sales_pos").ToString
        Catch ex As Exception
        End Try
        view_list_fg_missing(id_fg_missing_param)
        Cursor = Cursors.Default
    End Sub

    Private Sub GVListFGMissing_CustomColumnDisplayText(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs) Handles GVListFGMissing.CustomColumnDisplayText
        If e.Column.FieldName = "no" Then
            e.DisplayText = (e.ListSourceRowIndex + 1).ToString()
        End If
    End Sub


    '=========================STOCK OPNAME WH===========================
    Private Sub BtnGoToFGSOWH_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnGoToFGSOWH.Click
        Cursor = Cursors.WaitCursor
        Try
            FormFGStockOpnameWH.MdiParent = FormMain
            FormFGStockOpnameWH.Show()
            FormFGStockOpnameWH.WindowState = FormWindowState.Maximized
            FormFGStockOpnameWH.Focus()
        Catch ex As Exception
            errorProcess()
        End Try
        Cursor = Cursors.Default
        FormFGStockOpnameWH.GVSOWH.FocusedRowHandle = find_row(FormFGStockOpnameWH.GVSOWH, "id_fg_so_wh", GVFGSOWH.GetFocusedRowCellValue("id_fg_so_wh").ToString())
    End Sub

    Private Sub BRefFGSOWH_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BRefFGSOWH.Click
        GVFGSOWH.ApplyFindFilter("")
        view_fg_so_wh()
    End Sub

    Sub view_fg_so_wh()
        Dim query As String = ""
        query += "SELECT lockx.lock, so.id_lock, so.id_fg_so_wh, so.fg_so_wh_number, so.id_report_status,stat.report_status, "
        query += "DATE_FORMAT(so.fg_so_wh_date_created, '%d %M %Y / %H:%i') AS fg_so_wh_date_created, "
        query += "DATE_FORMAT(so.fg_so_wh_last_update, '%d %M %Y / %H:%i') AS fg_so_wh_last_update, "
        query += "(comp_contact.id_comp_contact) AS id_comp_contact_from, (comp.id_comp) AS id_comp_from, "
        query += "(comp.comp_number) AS comp_number_from, (comp.comp_name) AS comp_name_from "
        query += "FROM tb_fg_so_wh so "
        'query += "INNER JOIN tb_fg_so_wh_det so_det ON so.id_fg_so_wh = so_det.id_fg_so_wh "
        query += "INNER JOIN tb_m_comp_contact comp_contact ON comp_contact.id_comp_contact = so.id_comp_contact_from "
        query += "INNER JOIN tb_m_comp comp ON comp.id_comp = comp_contact.id_comp "
        query += "INNER JOIN tb_lookup_report_status stat ON stat.id_report_status = so.id_report_status "
        query += "INNER JOIN tb_lookup_lock lockx ON lockx.id_lock = so.id_lock "
        query += "WHERE so.id_lock = '2' "
        query += "ORDER BY so.id_fg_so_wh ASC "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCFGSOWH.DataSource = data
        check_menu()
        If data.Rows.Count > 0 Then
            GVFGSOWH.FocusedRowHandle = 0
            view_list_fg_so_wh(GVFGSOWH.GetFocusedRowCellValue("id_fg_so_wh").ToString)
            BtnGoToFGSOWH.Visible = True
        Else
            BtnGoToFGSOWH.Visible = False
        End If
    End Sub

    Sub view_list_fg_so_wh(ByVal id_fg_so_wh_param As String)
        Dim query As String = "CALL view_fg_so_wh_sum('" + id_fg_so_wh_param + "')"
        Dim data As DataTable = execute_query(query, "-1", True, "", "", "", "")
        GCListFGSOWH.DataSource = data
    End Sub

    Private Sub GVListFGSOWH_CustomColumnDisplayText(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs) Handles GVListFGSOWH.CustomColumnDisplayText
        If e.Column.FieldName = "no" Then
            e.DisplayText = (e.ListSourceRowIndex + 1).ToString()
        End If
    End Sub

    Private Sub GVFGSOWH_FocusedRowChanged(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles GVFGSOWH.FocusedRowChanged
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
        view_list_fg_so_wh(GVFGSOWH.GetFocusedRowCellValue("id_fg_so_wh").ToString)
    End Sub

    '======================FG ADJ IN======================================
    Private Sub BtnGoToFGAdjIn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnGoToFGAdjIn.Click
        Cursor = Cursors.WaitCursor
        Try
            FormFGAdj.MdiParent = FormMain
            FormFGAdj.Show()
            FormFGAdj.WindowState = FormWindowState.Maximized
            FormFGStockOpnameWH.Focus()
        Catch ex As Exception
            errorProcess()
        End Try
        Cursor = Cursors.Default
        FormFGAdj.XTCAdj.SelectedTabPageIndex = 0
        FormFGAdj.GVAdjIn.FocusedRowHandle = find_row(FormFGAdj.GVAdjIn, "id_adj_in_fg", GVFGAdjIn.GetFocusedRowCellValue("id_adj_in_fg").ToString())
    End Sub

    Private Sub BRefFGAdjIn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BRefFGAdjIn.Click
        GVFGAdjIn.ApplyFindFilter("")
        view_fg_adj_in()
    End Sub

    Sub view_fg_adj_in()
        Dim query As String = ""
        query += "SELECT *, DATE_FORMAT(a.adj_in_fg_date, '%d %M %Y') AS adj_in_fg_datex "
        query += "FROM tb_adj_in_fg a "
        query += "INNER JOIN tb_lookup_report_status b ON a.id_report_status = b.id_report_status "
        query += "INNER JOIN tb_lookup_currency c ON a.id_currency = c.id_currency  "
        query += "ORDER BY a.id_adj_in_fg ASC "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCFGAdjIn.DataSource = data
        check_menu()
        If data.Rows.Count > 0 Then
            GVFGAdjIn.FocusedRowHandle = 0
            view_list_fg_adj_in(GVFGAdjIn.GetFocusedRowCellValue("id_adj_in_fg").ToString)
            BtnGoToFGAdjIn.Visible = True
        Else
            BtnGoToFGAdjIn.Visible = False
        End If
    End Sub

    Sub view_list_fg_adj_in(ByVal id_ad_in_fg_param As String)
        Dim query As String = "CALL view_fg_adj_in('" + id_ad_in_fg_param + "')"
        Dim data As DataTable = execute_query(query, "-1", True, "", "", "", "")
        GCListFGAdjIn.DataSource = data
    End Sub

    Private Sub GVListFGAdjIn_CustomColumnDisplayText(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs) Handles GVListFGAdjIn.CustomColumnDisplayText
        If e.Column.FieldName = "no" Then
            e.DisplayText = (e.ListSourceRowIndex + 1).ToString()
        End If
    End Sub

    Private Sub GVFGAdjIn_FocusedRowChanged(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles GVFGAdjIn.FocusedRowChanged
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
        view_list_fg_adj_in(GVFGAdjIn.GetFocusedRowCellValue("id_adj_in_fg").ToString)
    End Sub

    '========================FG ADJ OUT=====================================
    Private Sub BtnGoToFGAdjOut_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnGoToFGAdjOut.Click
        Cursor = Cursors.WaitCursor
        Try
            FormFGAdj.MdiParent = FormMain
            FormFGAdj.Show()
            FormFGAdj.WindowState = FormWindowState.Maximized
            FormFGStockOpnameWH.Focus()
        Catch ex As Exception
            errorProcess()
        End Try
        Cursor = Cursors.Default
        FormFGAdj.XTCAdj.SelectedTabPageIndex = 1
        FormFGAdj.GVAdjOut.FocusedRowHandle = find_row(FormFGAdj.GVAdjOut, "id_adj_out_fg", GVFGAdjOut.GetFocusedRowCellValue("id_adj_out_fg").ToString())
    End Sub

    Private Sub BRefFGAdjOut_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BRefFGAdjOut.Click
        GVFGAdjOut.ApplyFindFilter("")
        view_fg_adj_out()
    End Sub

    Sub view_fg_adj_out()
        Dim query As String = ""
        query += "SELECT *, DATE_FORMAT(a.adj_out_fg_date, '%d %M %Y') AS adj_out_fg_datex "
        query += "FROM tb_adj_out_fg a "
        query += "INNER JOIN tb_lookup_report_status b ON a.id_report_status = b.id_report_status "
        query += "INNER JOIN tb_lookup_currency c ON a.id_currency = c.id_currency  "
        query += "ORDER BY a.id_adj_out_fg ASC "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCFGAdjOut.DataSource = data
        check_menu()
        If data.Rows.Count > 0 Then
            GVFGAdjOut.FocusedRowHandle = 0
            view_list_fg_adj_out(GVFGAdjOut.GetFocusedRowCellValue("id_adj_out_fg").ToString)
            BtnGoToFGAdjOut.Visible = True
        Else
            BtnGoToFGAdjOut.Visible = False
        End If
    End Sub

    Sub view_list_fg_adj_out(ByVal id_ad_in_fg_param As String)
        Dim query As String = "CALL view_fg_adj_out('" + id_ad_in_fg_param + "')"
        Dim data As DataTable = execute_query(query, "-1", True, "", "", "", "")
        GCListFGAdjOut.DataSource = data
    End Sub

    Private Sub GVListFGAdjOut_CustomColumnDisplayText(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs) Handles GVListFGAdjOut.CustomColumnDisplayText
        If e.Column.FieldName = "no" Then
            e.DisplayText = (e.ListSourceRowIndex + 1).ToString()
        End If
    End Sub

    Private Sub GVFGAdjOut_FocusedRowChanged(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles GVFGAdjOut.FocusedRowChanged
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
        view_list_fg_adj_out(GVFGAdjOut.GetFocusedRowCellValue("id_adj_out_fg").ToString)
    End Sub

    '========================= FG TRF=====================================
    Private Sub BtnGoToFGTrf_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnGoToFGTrf.Click
        Cursor = Cursors.WaitCursor
        Try
            FormFGTrf.MdiParent = FormMain
            FormFGTrf.Show()
            FormFGTrf.WindowState = FormWindowState.Maximized
            FormFGTrf.Focus()
        Catch ex As Exception
            errorProcess()
        End Try
        Cursor = Cursors.Default
        FormFGTrf.GVFGTrf.FocusedRowHandle = find_row(FormFGTrf.GVFGTrf, "id_fg_trf", GVFGTrf.GetFocusedRowCellValue("id_fg_trf").ToString())
    End Sub

    Private Sub GVFGTrf_ColumnFilterChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GVFGTrf.ColumnFilterChanged
        Cursor = Cursors.WaitCursor
        Dim id_fg_trf_par As String = "-1"
        Try
            id_fg_trf_par = GVFGTrf.GetFocusedRowCellValue("id_fg_trf").ToString
        Catch ex As Exception
        End Try
        view_list_fg_trf(id_fg_trf_par)
        Cursor = Cursors.Default
    End Sub

    Private Sub BRefFGTrf_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BRefFGTrf.Click
        GVFGTrf.ApplyFindFilter("")
        view_fg_trf()
    End Sub

    Sub view_fg_trf()
        Dim query As String = ""
        query += "SELECT "
        query += "trf.id_fg_trf, trf.fg_trf_number, DATE_FORMAT(trf.fg_trf_date, '%d %M %Y') AS fg_trf_date, trf.fg_trf_note, trf.id_report_status, rep_status.report_status, "
        query += "(comp_from.id_comp) AS id_comp_from, (comp_from.comp_number) AS comp_number_from, (comp_from.comp_name) AS comp_name_from, "
        query += "(comp_to.id_comp) AS id_comp_to, (comp_to.comp_number) AS comp_number_to, (comp_to.comp_name) AS comp_name_to, "
        query += "trf.id_comp_contact_from, trf.id_comp_contact_to "
        query += "FROM tb_fg_trf trf "
        query += "INNER JOIN tb_m_comp_contact comp_con_from ON trf.id_comp_contact_from = comp_con_from.id_comp_contact "
        query += "INNER JOIN tb_m_comp comp_from ON comp_con_from.id_comp = comp_from.id_comp "
        query += "INNER JOIN tb_m_comp_contact comp_con_to ON trf.id_comp_contact_to = comp_con_to.id_comp_contact "
        query += "INNER JOIN tb_m_comp comp_to ON comp_con_to.id_comp = comp_to.id_comp "
        query += "INNER JOIN tb_lookup_report_status rep_status ON trf.id_report_status = rep_status.id_report_status "
        query += "ORDER BY trf.id_fg_trf ASC "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCFGTrf.DataSource = data
        check_menu()
        If data.Rows.Count > 0 Then
            GVFGTrf.FocusedRowHandle = 0
            Dim id_fg_trf_par As String = "-1"
            Try
                id_fg_trf_par = GVFGTrf.GetFocusedRowCellValue("id_fg_trf").ToString
            Catch ex As Exception
            End Try
            view_list_fg_trf(id_fg_trf_par)
            BtnGoToFGTrf.Visible = True
        Else
            BtnGoToFGTrf.Visible = False
        End If
    End Sub

    Sub view_list_fg_trf(ByVal id_fg_trf_param As String)
        Dim query As String = "CALL view_fg_trf('" + id_fg_trf_param + "')"
        Dim data As DataTable = execute_query(query, "-1", True, "", "", "", "")
        GCListFGTrf.DataSource = data
        GVListFGTrf.OptionsBehavior.AutoExpandAllGroups = True
    End Sub

    Private Sub GVListFGTrf_CustomColumnDisplayText(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs) Handles GVListFGTrf.CustomColumnDisplayText
        If e.Column.FieldName = "no" Then
            e.DisplayText = (e.ListSourceRowIndex + 1).ToString()
        End If
    End Sub

    Private Sub GVFGTrf_FocusedRowChanged(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles GVFGTrf.FocusedRowChanged
        Cursor = Cursors.WaitCursor
        Dim id_fg_trf_par As String = "-1"
        Try
            id_fg_trf_par = GVFGTrf.GetFocusedRowCellValue("id_fg_trf").ToString
        Catch ex As Exception
        End Try
        view_list_fg_trf(id_fg_trf_par)
        Cursor = Cursors.Default
    End Sub

    '==========================FG TRF REC=====================================

    Private Sub BtnGoToFGTrfRec_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnGoToFGTrfRec.Click
        Cursor = Cursors.WaitCursor
        Try
            FormFGTrfReceive.MdiParent = FormMain
            FormFGTrfReceive.Show()
            FormFGTrfReceive.WindowState = FormWindowState.Maximized
            FormFGTrfReceive.Focus()
        Catch ex As Exception
            errorProcess()
        End Try
        Cursor = Cursors.Default
        FormFGTrfReceive.GVFGTrf.FocusedRowHandle = find_row(FormFGTrfReceive.GVFGTrf, "id_fg_trf", GVFGTrf.GetFocusedRowCellValue("id_fg_trf").ToString())
    End Sub

    Private Sub BRefFGTrfRec_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BRefFGTrfRec.Click
        GVFGTrfRec.ApplyFindFilter("")
        view_fg_trf_rec()
    End Sub

    Private Sub GVFGTrfRec_ColumnFilterChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GVFGTrfRec.ColumnFilterChanged
        Cursor = Cursors.WaitCursor
        Dim id_fg_trf_rec_par As String = "-1"
        Try
            id_fg_trf_rec_par = GVFGTrfRec.GetFocusedRowCellValue("id_fg_trf").ToString
        Catch ex As Exception
        End Try
        view_list_fg_trf_rec(id_fg_trf_rec_par)
        Cursor = Cursors.Default
    End Sub

    Sub view_fg_trf_rec()
        Dim query As String = ""
        query += "SELECT "
        query += "trf.id_fg_trf, trf.fg_trf_number, DATE_FORMAT(trf.fg_trf_date, '%d %M %Y') AS fg_trf_date, trf.fg_trf_note, trf.id_report_status, trf.id_report_status_rec,IF(ISNULL(trf.id_report_status_rec), '-', rep_status.report_status) AS report_status, "
        query += "IF(ISNULL(trf.fg_trf_date_rec), '-', DATE_FORMAT(trf.fg_trf_date_rec, '%d %M %Y')) AS  fg_trf_date_rec, "
        query += "(comp_from.id_comp) AS id_comp_from, (comp_from.comp_number) AS comp_number_from, (comp_from.comp_name) AS comp_name_from, "
        query += "(comp_to.id_comp) AS id_comp_to, (comp_to.comp_number) AS comp_number_to, (comp_to.comp_name) AS comp_name_to, "
        query += "trf.id_comp_contact_from, trf.id_comp_contact_to "
        query += "FROM tb_fg_trf trf "
        query += "INNER JOIN tb_m_comp_contact comp_con_from ON trf.id_comp_contact_from = comp_con_from.id_comp_contact "
        query += "INNER JOIN tb_m_comp comp_from ON comp_con_from.id_comp = comp_from.id_comp "
        query += "INNER JOIN tb_m_comp_contact comp_con_to ON trf.id_comp_contact_to = comp_con_to.id_comp_contact "
        query += "INNER JOIN tb_m_comp comp_to ON comp_con_to.id_comp = comp_to.id_comp "
        query += "LEFT JOIN tb_lookup_report_status rep_status ON trf.id_report_status_rec = rep_status.id_report_status "
        query += "WHERE trf.id_report_status = '6' "
        query += "ORDER BY trf.id_fg_trf ASC "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCFGTrfRec.DataSource = data
        check_menu()
        If data.Rows.Count > 0 Then
            GVFGTrfRec.FocusedRowHandle = 0
            Dim id_fg_trf_rec_par As String = "-1"
            Try
                id_fg_trf_rec_par = GVFGTrfRec.GetFocusedRowCellValue("id_fg_trf").ToString
            Catch ex As Exception
            End Try
            view_list_fg_trf_rec(id_fg_trf_rec_par)
            BtnGoToFGTrfRec.Visible = True
        Else
            BtnGoToFGTrfRec.Visible = False
        End If
    End Sub

    Sub view_list_fg_trf_rec(ByVal id_fg_trf_param As String)
        Dim query As String = "CALL view_fg_trf('" + id_fg_trf_param + "')"
        Dim data As DataTable = execute_query(query, "-1", True, "", "", "", "")
        GCListFGTrfRec.DataSource = data
        GVListFGTrfRec.OptionsBehavior.AutoExpandAllGroups = True
    End Sub

    Private Sub GVListFGTrfRec_CustomColumnDisplayText(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs) Handles GVListFGTrfRec.CustomColumnDisplayText
        If e.Column.FieldName = "no" Then
            e.DisplayText = (e.ListSourceRowIndex + 1).ToString()
        End If
    End Sub


    Private Sub GVFGTrfRec_FocusedRowChanged(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles GVFGTrfRec.FocusedRowChanged
        Cursor = Cursors.WaitCursor
        Dim id_fg_trf_rec_par As String = "-1"
        Try
            id_fg_trf_rec_par = GVFGTrfRec.GetFocusedRowCellValue("id_fg_trf").ToString
        Catch ex As Exception
        End Try
        view_list_fg_trf_rec(id_fg_trf_rec_par)
        Cursor = Cursors.Default
    End Sub

    '===================== PL SAMPLE DELIVERY===========================
    Private Sub BGotoSampeDel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BGotoSampeDel.Click
        Cursor = Cursors.WaitCursor
        Try
            FormSampleDel.MdiParent = FormMain
            FormSampleDel.Show()
            FormSampleDel.WindowState = FormWindowState.Maximized
            FormSampleDel.Focus()
        Catch ex As Exception
            errorProcess()
        End Try
        Cursor = Cursors.Default
        FormSampleDel.GVSampleDel.FocusedRowHandle = find_row(FormSampleDel.GVSampleDel, "id_sample_del", GVSampleDel.GetFocusedRowCellValue("id_sample_del").ToString())
    End Sub

    Private Sub BRefSampleDel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BRefSampleDel.Click
        GVSampleDel.ApplyFindFilter("")
        view_sample_del()
    End Sub

    Sub view_sample_del()
        Dim query As String = ""
        query += "SELECT del.id_sample_del, del.sample_del_date, del.sample_del_number, "
        query += "del.id_report_status, del.id_comp_contact_to, del.id_comp_contact_from, "
        query += "(comp_from.comp_number) AS comp_number_from, (comp_from.comp_name) AS comp_name_from, "
        query += "(comp_to.comp_number) AS comp_number_to, (comp_to.comp_name) AS comp_name_to, "
        query += "stt.report_status, pl_cat.id_pl_category, pl_cat.pl_category "
        query += "FROM tb_sample_del del "
        query += "INNER JOIN tb_m_comp_contact cont_from ON cont_from.id_comp_contact = del.id_comp_contact_from "
        query += "INNER JOIN tb_m_comp comp_from ON comp_from.id_comp = cont_from.id_comp "
        query += "INNER JOIN tb_m_comp_contact cont_to ON cont_to.id_comp_contact = del.id_comp_contact_to "
        query += "INNER JOIN tb_m_comp comp_to ON comp_to.id_comp = cont_to.id_comp "
        query += "INNER JOIN tb_lookup_report_status stt ON stt.id_report_status = del.id_report_status "
        query += "INNER JOIN tb_lookup_pl_category pl_cat ON pl_cat.id_pl_category = del.id_pl_category "
        query += "ORDER BY del.id_sample_del ASC "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCSampleDel.DataSource = data
        check_menu()
        If data.Rows.Count > 0 Then
            GVSampleDel.FocusedRowHandle = 0
            view_list_sample_del(GVSampleDel.GetFocusedRowCellValue("id_sample_del").ToString)
            BGotoSampeDel.Visible = True
        Else
            BGotoSampeDel.Visible = False
        End If
    End Sub

    Sub view_list_sample_del(ByVal id_sample_del_param As String)
        Dim query As String = "CALL view_sample_del('" + id_sample_del_param + "')"
        Dim data As DataTable = execute_query(query, "-1", True, "", "", "", "")
        GCListSampleDel.DataSource = data
        GVListSampleDel.OptionsBehavior.AutoExpandAllGroups = True
    End Sub

    Private Sub GVListSampleDel_CustomColumnDisplayText(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs) Handles GVListSampleDel.CustomColumnDisplayText
        If e.Column.FieldName = "no" Then
            e.DisplayText = (e.ListSourceRowIndex + 1).ToString()
        End If
    End Sub


    Private Sub GVSampleDel_FocusedRowChanged(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles GVSampleDel.FocusedRowChanged
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
        view_list_sample_del(GVSampleDel.GetFocusedRowCellValue("id_sample_del").ToString)
    End Sub

    'RECEIVING PL SAMPLE DELIVERY
    Private Sub BGotoSampeDelRec_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BGotoSampeDelRec.Click
        Cursor = Cursors.WaitCursor
        Try
            FormSampleDelRec.MdiParent = FormMain
            FormSampleDelRec.Show()
            FormSampleDelRec.WindowState = FormWindowState.Maximized
            FormSampleDelRec.Focus()
        Catch ex As Exception
            errorProcess()
        End Try
        Cursor = Cursors.Default
        FormSampleDelRec.GVSampleDelRec.FocusedRowHandle = find_row(FormSampleDelRec.GVSampleDelRec, "id_sample_del_rec", GVSampleDelRec.GetFocusedRowCellValue("id_sample_del_rec").ToString())
    End Sub


    Private Sub BRefSampleDelRec_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BRefSampleDelRec.Click
        GVSampleDelRec.ApplyFindFilter("")
        view_sample_del_rec()
    End Sub

    Sub view_sample_del_rec()
        Dim query_c As ClassSampleDelRec = New ClassSampleDelRec()
        Dim query As String = query_c.queryMain("-1", "1")
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCSampleDelRec.DataSource = data
        check_menu()
        If data.Rows.Count > 0 Then
            GVSampleDelRec.FocusedRowHandle = 0
            view_list_sample_del_rec(GVSampleDelRec.GetFocusedRowCellValue("id_sample_del_rec").ToString)
            BGotoSampeDelRec.Visible = True
        Else
            BGotoSampeDelRec.Visible = False
        End If
    End Sub

    Sub view_list_sample_del_rec(ByVal id_sample_del_rec_param As String)
        Dim query_c As ClassSampleDelRec = New ClassSampleDelRec
        Dim query As String = query_c.queryDetail(id_sample_del_rec_param)
        Dim data As DataTable = execute_query(query, "-1", True, "", "", "", "")
        GCListSampleDelRec.DataSource = data
        GVListSampleDelRec.OptionsBehavior.AutoExpandAllGroups = True
    End Sub


    Private Sub GVListSampleDelRec_CustomColumnDisplayText(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs) Handles GVListSampleDelRec.CustomColumnDisplayText
        If e.Column.FieldName = "no" Then
            e.DisplayText = (e.ListSourceRowIndex + 1).ToString()
        End If
    End Sub

    Private Sub GVSampleDelRec_FocusedRowChanged(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles GVSampleDelRec.FocusedRowChanged
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
        view_list_sample_del_rec(GVSampleDelRec.GetFocusedRowCellValue("id_sample_del_rec").ToString)
    End Sub

    '===============================SALES ORDER SAMPLE
    Private Sub BGotoSampleOrder_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BGotoSampleOrder.Click
        Cursor = Cursors.WaitCursor
        Try
            FormSampleOrder.MdiParent = FormMain
            FormSampleOrder.Show()
            FormSampleOrder.WindowState = FormWindowState.Maximized
            FormSampleOrder.Focus()
        Catch ex As Exception
            errorProcess()
        End Try
        Cursor = Cursors.Default
        FormSampleOrder.GVSampleOrder.FocusedRowHandle = find_row(FormSampleOrder.GVSampleOrder, "id_sample_order", GVSampleOrder.GetFocusedRowCellValue("id_sample_order").ToString())
    End Sub

    Private Sub BRefSampleOrder_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BRefSampleOrder.Click
        GVSampleOrder.ApplyFindFilter("")
        view_sample_order()
    End Sub

    Sub view_sample_order()
        Dim query_c As ClassSampleOrder = New ClassSampleOrder()
        Dim query As String = query_c.queryMain("-1", "1")
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCSampleOrder.DataSource = data
        check_menu()
        If data.Rows.Count > 0 Then
            GVSampleOrder.FocusedRowHandle = 0
            view_list_sample_order(GVSampleOrder.GetFocusedRowCellValue("id_sample_order").ToString)
            BGotoSampleOrder.Visible = True
        Else
            BGotoSampleOrder.Visible = False
        End If
    End Sub

    Sub view_list_sample_order(ByVal id_sample_order_param As String)
        Dim query_c As ClassSampleOrder = New ClassSampleOrder
        Dim query As String = query_c.queryDetail(id_sample_order_param)
        Dim data As DataTable = execute_query(query, "-1", True, "", "", "", "")
        GCListSampleOrder.DataSource = data
        GVListSampleOrder.OptionsBehavior.AutoExpandAllGroups = True
    End Sub

    Private Sub GVListSampleOrder_CustomColumnDisplayText(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs) Handles GVListSampleOrder.CustomColumnDisplayText
        If e.Column.FieldName = "no" Then
            e.DisplayText = (e.ListSourceRowIndex + 1).ToString()
        End If
    End Sub


    Private Sub GVSampleOrder_FocusedRowChanged(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles GVSampleOrder.FocusedRowChanged
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
        view_list_sample_order(GVSampleOrder.GetFocusedRowCellValue("id_sample_order").ToString)
    End Sub

    '===================DELIVERY ORDER SAMPLE
    Private Sub BGotoSampleDelOrder_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BGotoSampleDelOrder.Click
        Cursor = Cursors.WaitCursor
        Try
            FormSampleDelOrder.MdiParent = FormMain
            FormSampleDelOrder.Show()
            FormSampleDelOrder.WindowState = FormWindowState.Maximized
            FormSampleDelOrder.Focus()
        Catch ex As Exception
            errorProcess()
        End Try
        Cursor = Cursors.Default
        FormSampleDelOrder.GVSampleDelOrder.FocusedRowHandle = find_row(FormSampleDelOrder.GVSampleDelOrder, "id_pl_sample_order_del", GVSampleDelOrder.GetFocusedRowCellValue("id_pl_sample_order_del").ToString())
    End Sub

    Private Sub BRefSampleDelOrder_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BRefSampleDelOrder.Click
        GVSampleDelOrder.ApplyFindFilter("")
        view_sample_del_order()
    End Sub

    Sub view_sample_del_order()
        Dim query_c As ClassSampleDelOrder = New ClassSampleDelOrder()
        Dim query As String = query_c.queryMain("-1", "1")
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCSampleDelOrder.DataSource = data
        check_menu()
        If data.Rows.Count > 0 Then
            GVSampleDelOrder.FocusedRowHandle = 0
            view_list_sample_del_order(GVSampleDelOrder.GetFocusedRowCellValue("id_pl_sample_order_del").ToString)
            BGotoSampleDelOrder.Visible = True
        Else
            BGotoSampleDelOrder.Visible = False
        End If
    End Sub

    Sub view_list_sample_del_order(ByVal id_report_param As String)
        Dim query_c As ClassSampleDelOrder = New ClassSampleDelOrder
        Dim query As String = query_c.queryDetail(id_report_param)
        Dim data As DataTable = execute_query(query, "-1", True, "", "", "", "")
        GCListSampleDelOrder.DataSource = data
        GVListSampleDelOrder.OptionsBehavior.AutoExpandAllGroups = True
    End Sub


    Private Sub GVListSampleDelOrder_CustomColumnDisplayText(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs) Handles GVListSampleDelOrder.CustomColumnDisplayText
        If e.Column.FieldName = "no" Then
            e.DisplayText = (e.ListSourceRowIndex + 1).ToString()
        End If
    End Sub

    Private Sub GVSampleDelOrder_FocusedRowChanged(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles GVSampleDelOrder.FocusedRowChanged
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
        view_list_sample_del_order(GVSampleDelOrder.GetFocusedRowCellValue("id_pl_sample_order_del").ToString)
    End Sub

    '====================CODE REPLACEMENT STORE==========================
    Private Sub BtnGoToFGCodeReplaceStore_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnGoToFGCodeReplaceStore.Click
        Cursor = Cursors.WaitCursor
        Try
            FormFGCodeReplace.MdiParent = FormMain
            FormFGCodeReplace.Show()
            FormFGCodeReplace.WindowState = FormWindowState.Maximized
            FormFGCodeReplace.Focus()
            FormFGCodeReplace.XTCFGCodeReplace.SelectedTabPageIndex = 0
        Catch ex As Exception
            errorProcess()
        End Try
        Cursor = Cursors.Default
        FormFGCodeReplace.GVFGCodeReplaceStore.FocusedRowHandle = find_row(FormFGCodeReplace.GVFGCodeReplaceStore, "id_fg_code_replace_store", GVFGCodeReplaceStore.GetFocusedRowCellValue("id_fg_code_replace_store").ToString())
    End Sub


    Private Sub BRefFGCodeReplaceStore_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BRefFGCodeReplaceStore.Click
        GVSampleDelOrder.ApplyFindFilter("")
        view_fg_code_replace_store()
    End Sub

    Sub view_fg_code_replace_store()
        Dim query_c As ClassFGCodeReplace = New ClassFGCodeReplace()
        Dim query As String = query_c.queryMainStore("-1", "1")
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCFGCodeReplaceStore.DataSource = data
        check_menu()
        If data.Rows.Count > 0 Then
            GVFGCodeReplaceStore.FocusedRowHandle = 0
            view_list_fg_code_replace_store(GVFGCodeReplaceStore.GetFocusedRowCellValue("id_fg_code_replace_store").ToString)
            BtnGoToFGCodeReplaceStore.Visible = True
        Else
            BtnGoToFGCodeReplaceStore.Visible = False
        End If
    End Sub

    Sub view_list_fg_code_replace_store(ByVal id_report_param As String)
        Dim query_c As ClassFGCodeReplace = New ClassFGCodeReplace()
        Dim query As String = query_c.queryDetailStore(id_report_param)
        Dim data As DataTable = execute_query(query, "-1", True, "", "", "", "")
        GCListFGCodeReplaceStore.DataSource = data
        GVListFGCodeReplaceStore.OptionsBehavior.AutoExpandAllGroups = True
    End Sub

    Private Sub GVListFGCodeReplaceStore_CustomColumnDisplayText(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs) Handles GVListFGCodeReplaceStore.CustomColumnDisplayText
        If e.Column.FieldName = "no" Then
            e.DisplayText = (e.ListSourceRowIndex + 1).ToString()
        End If
    End Sub


    Private Sub GVFGCodeReplaceStore_FocusedRowChanged(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles GVFGCodeReplaceStore.FocusedRowChanged
        Dim id_fg_code_replace_store As String = "-1"
        Try
            id_fg_code_replace_store = GVFGCodeReplaceStore.GetFocusedRowCellValue("id_fg_code_replace_store").ToString
        Catch ex As Exception
        End Try
        view_list_fg_code_replace_store(id_fg_code_replace_store)
    End Sub

    '========================SALES CREDIT NOTE

    Private Sub GVListSalesCreditNote_CustomColumnDisplayText(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs) Handles GVListSalesCreditNote.CustomColumnDisplayText
        If e.Column.FieldName = "no" Then
            e.DisplayText = (e.ListSourceRowIndex + 1).ToString()
        End If
    End Sub

    Sub viewSalesCreditNote()
        Dim query_c As ClassSalesInv = New ClassSalesInv()
        Dim query As String = query_c.queryMain("AND a.id_memo_type=''2'' ", "1")
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCSalesCreditNote.DataSource = data
        If data.Rows.Count > 0 Then 'ada data
            GVSalesCreditNote.FocusedRowHandle = 0
            Dim id_sales_pos_param As String = "-1"
            Try
                id_sales_pos_param = GVSalesCreditNote.GetFocusedRowCellValue("id_sales_pos").ToString
            Catch ex As Exception
            End Try
            view_sales_credit_note(id_sales_pos_param)
            check_menu()
            BGotoSalesCreditNote.Visible = True
        Else
            BGotoSalesCreditNote.Visible = False
        End If
    End Sub

    Sub view_sales_credit_note(ByVal id_sales_pos_param As String)
        Try
            Dim query_c As ClassSalesInv = New ClassSalesInv()
            Dim query As String = query_c.queryDetail(id_sales_pos_param)
            Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
            GCListSalesCreditNote.DataSource = data
        Catch ex As Exception
            errorConnection()
        End Try
    End Sub

    Private Sub BGotoSalesCreditNote_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BGotoSalesCreditNote.Click
        Cursor = Cursors.WaitCursor
        Try
            FormSalesCreditNote.MdiParent = FormMain
            FormSalesCreditNote.Show()
            FormSalesCreditNote.WindowState = FormWindowState.Maximized
            FormSalesCreditNote.Focus()
        Catch ex As Exception
            errorProcess()
        End Try
        Cursor = Cursors.Default
        FormSalesCreditNote.GVSalesPOS.FocusedRowHandle = find_row(FormSalesCreditNote.GVSalesPOS, "id_sales_pos", GVSalesCreditNote.GetFocusedRowCellValue("id_sales_pos").ToString())
    End Sub

    Private Sub BRefSalesCreditNote_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BRefSalesCreditNote.Click
        GVSalesCreditNote.ApplyFindFilter("")
        viewSalesCreditNote()
    End Sub


    Private Sub GVSalesCreditNote_FocusedRowChanged(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles GVSalesCreditNote.FocusedRowChanged
        Cursor = Cursors.WaitCursor
        Dim id_sales_pos_param As String = "-1"
        Try
            id_sales_pos_param = GVSalesCreditNote.GetFocusedRowCellValue("id_sales_pos").ToString
        Catch ex As Exception
        End Try
        Cursor = Cursors.Default
        view_sales_credit_note(id_sales_pos_param)
    End Sub

    '======================MISSING CREDIT NOTE
    Private Sub GVListFGMissingCNStore_CustomColumnDisplayText(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs) Handles GVListFGMissingCNStore.CustomColumnDisplayText
        If e.Column.FieldName = "no" Then
            e.DisplayText = (e.ListSourceRowIndex + 1).ToString()
        End If
    End Sub

    Sub viewFGMissingCNStore()
        Dim query_c As ClassSalesInv = New ClassSalesInv()
        Dim query As String = query_c.queryMain("AND a.id_memo_type=''4'' ", "1")
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCFGMissingCNStore.DataSource = data
        If data.Rows.Count > 0 Then 'ada data
            GVFGMissingCNStore.FocusedRowHandle = 0
            Dim id_sales_pos_param As String = "-1"
            Try
                id_sales_pos_param = GVFGMissingCNStore.GetFocusedRowCellValue("id_sales_pos").ToString
            Catch ex As Exception
            End Try
            view_fg_missing_cn_store(id_sales_pos_param)
            check_menu()
            BGoToFGMissingCNStore.Visible = True
        Else
            BGoToFGMissingCNStore.Visible = False
        End If
    End Sub

    Sub view_fg_missing_cn_store(ByVal id_sales_pos_param As String)
        Try
            Dim query_c As ClassSalesInv = New ClassSalesInv()
            Dim query As String = query_c.queryDetail(id_sales_pos_param)
            Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
            GCListFGMissingCNStore.DataSource = data
        Catch ex As Exception
            errorConnection()
        End Try
    End Sub

    Private Sub BGoToFGMissingCNStore_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BGoToFGMissingCNStore.Click
        Cursor = Cursors.WaitCursor
        Try
            FormFGMissingCreditNote.MdiParent = FormMain
            FormFGMissingCreditNote.Show()
            FormFGMissingCreditNote.WindowState = FormWindowState.Maximized
            FormFGMissingCreditNote.Focus()
        Catch ex As Exception
            errorProcess()
        End Try
        FormFGMissingCreditNote.XTCFGMissingCN.SelectedTabPageIndex = 0
        FormFGMissingCreditNote.GVFGMissingCNStore.FocusedRowHandle = find_row(FormFGMissingCreditNote.GVFGMissingCNStore, "id_sales_pos", GVFGMissingCNStore.GetFocusedRowCellValue("id_sales_pos").ToString())
        Cursor = Cursors.Default
    End Sub

    Private Sub BRefFGMissingCN_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BRefFGMissingCN.Click
        GVFGMissingCNStore.ApplyFindFilter("")
        viewFGMissingCNStore()
    End Sub

    Private Sub GVFGMissingCNStore_FocusedRowChanged(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles GVFGMissingCNStore.FocusedRowChanged
        Cursor = Cursors.WaitCursor
        Dim id_sales_pos_param As String = "-1"
        Try
            id_sales_pos_param = GVFGMissingCNStore.GetFocusedRowCellValue("id_sales_pos").ToString
        Catch ex As Exception
        End Try
        Cursor = Cursors.Default
        view_fg_missing_cn_store(id_sales_pos_param)
    End Sub

    '================CODE REPLACEMENT WH
    Private Sub BtnGoToFGCodeReplaceWH_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnGoToFGCodeReplaceWH.Click
        Cursor = Cursors.WaitCursor
        Try
            FormFGCodeReplace.MdiParent = FormMain
            FormFGCodeReplace.Show()
            FormFGCodeReplace.WindowState = FormWindowState.Maximized
            FormFGCodeReplace.Focus()
            FormFGCodeReplace.XTCFGCodeReplace.SelectedTabPageIndex = 1
        Catch ex As Exception
            errorProcess()
        End Try
        Cursor = Cursors.Default
        FormFGCodeReplace.GVFGCodeReplaceWH.FocusedRowHandle = find_row(FormFGCodeReplace.GVFGCodeReplaceWH, "id_fg_code_replace_wh", GVFGCodeReplaceWH.GetFocusedRowCellValue("id_fg_code_replace_wh").ToString())
    End Sub


    Private Sub BRefFGCodeReplaceWH_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BRefFGCodeReplaceWH.Click
        GVFGCodeReplaceWH.ApplyFindFilter("")
        view_fg_code_replace_wh()
    End Sub

    Sub view_fg_code_replace_wh()
        Dim query_c As ClassFGCodeReplace = New ClassFGCodeReplace()
        Dim query As String = query_c.queryMainWH("-1", "1")
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCFGCodeReplaceWH.DataSource = data
        check_menu()
        If data.Rows.Count > 0 Then
            GVFGCodeReplaceStore.FocusedRowHandle = 0
            Dim id_replace_param As String = "-1"
            Try
                id_replace_param = GVFGCodeReplaceWH.GetFocusedRowCellValue("id_fg_code_replace_wh").ToString
            Catch ex As Exception
            End Try
            view_list_fg_code_replace_wh(id_replace_param)
            BtnGoToFGCodeReplaceWH.Visible = True
        Else
            BtnGoToFGCodeReplaceWH.Visible = False
        End If
    End Sub

    Sub view_list_fg_code_replace_wh(ByVal id_report_param As String)
        Dim query_c As ClassFGCodeReplace = New ClassFGCodeReplace()
        Dim query As String = query_c.queryDetailWH(id_report_param)
        Dim data As DataTable = execute_query(query, "-1", True, "", "", "", "")
        GCListFGCodeReplaceWH.DataSource = data
        GVListFGCodeReplaceWH.OptionsBehavior.AutoExpandAllGroups = True
        GVListFGCodeReplaceWH.ExpandAllGroups()
    End Sub

    Private Sub GVListFGCodeReplaceWH_CustomColumnDisplayText(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs) Handles GVListFGCodeReplaceWH.CustomColumnDisplayText
        If e.Column.FieldName = "no" Then
            e.DisplayText = (e.ListSourceRowIndex + 1).ToString()
        End If
    End Sub


    Private Sub GVFGCodeReplaceWH_FocusedRowChanged(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles GVFGCodeReplaceWH.FocusedRowChanged
        Cursor = Cursors.WaitCursor
        Dim id_fg_code_replace_wh As String = "-1"
        Try
            id_fg_code_replace_wh = GVFGCodeReplaceWH.GetFocusedRowCellValue("id_fg_code_replace_wh").ToString
        Catch ex As Exception
        End Try
        view_list_fg_code_replace_wh(id_fg_code_replace_wh)
        Cursor = Cursors.Default
    End Sub

    Private Sub GVFGCodeReplaceWH_ColumnFilterChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GVFGCodeReplaceWH.ColumnFilterChanged
        Cursor = Cursors.WaitCursor
        Dim id_fg_code_replace_wh As String = "-1"
        Try
            id_fg_code_replace_wh = GVFGCodeReplaceWH.GetFocusedRowCellValue("id_fg_code_replace_wh").ToString
        Catch ex As Exception
        End Try
        view_list_fg_code_replace_wh(id_fg_code_replace_wh)
        Cursor = Cursors.Default
    End Sub

    '================FG WRITE OFF
    Private Sub BtnGoToFGWoff_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnGoToFGWoff.Click
        Cursor = Cursors.WaitCursor
        Try
            FormFGWoff.MdiParent = FormMain
            FormFGWoff.Show()
            FormFGWoff.WindowState = FormWindowState.Maximized
            FormFGWoff.Focus()
        Catch ex As Exception
            errorProcess()
        End Try
        Cursor = Cursors.Default
        FormFGWoff.GVFGWoff.FocusedRowHandle = find_row(FormFGWoff.GVFGWoff, "id_fg_woff", GVFGWoff.GetFocusedRowCellValue("id_fg_woff").ToString())
    End Sub

    Private Sub BRefFGWoff_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BRefFGWoff.Click
        GVFGCodeReplaceWH.ApplyFindFilter("")
        view_fg_woff()
    End Sub

    Sub view_fg_woff()
        Dim query_c As ClassFGWoff = New ClassFGWoff()
        Dim query As String = query_c.queryMain("-1", "1")
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCFGWoff.DataSource = data
        check_menu()
        If data.Rows.Count > 0 Then
            GVFGWoff.FocusedRowHandle = 0
            Dim id_ As String = "-1"
            Try
                id_ = GVFGWoff.GetFocusedRowCellValue("id_fg_woff").ToString
            Catch ex As Exception
            End Try
            view_list_fg_woff(id_)
            BtnGoToFGWoff.Visible = True
        Else
            BtnGoToFGWoff.Visible = False
        End If
    End Sub

    Sub view_list_fg_woff(ByVal id_report_param As String)
        Dim query_c As ClassFGWoff = New ClassFGWoff()
        Dim query As String = query_c.queryDetail(id_report_param)
        Dim data As DataTable = execute_query(query, "-1", True, "", "", "", "")
        GCListFGWoff.DataSource = data
        GVListFGWoff.OptionsBehavior.AutoExpandAllGroups = True
        GVListFGWoff.ExpandAllGroups()
    End Sub

    Private Sub GVListFGWoff_CustomColumnDisplayText(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs) Handles GVListFGWoff.CustomColumnDisplayText
        If e.Column.FieldName = "no" Then
            e.DisplayText = (e.ListSourceRowIndex + 1).ToString()
        End If
    End Sub

    Private Sub GVFGWoff_FocusedRowChanged(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles GVFGWoff.FocusedRowChanged
        Cursor = Cursors.WaitCursor
        Dim id_fg_woff As String = "-1"
        Try
            id_fg_woff = GVFGWoff.GetFocusedRowCellValue("id_fg_woff").ToString
        Catch ex As Exception
        End Try
        view_list_fg_woff(id_fg_woff)
        Cursor = Cursors.Default
    End Sub

    Private Sub GVFGWoff_ColumnFilterChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GVFGWoff.ColumnFilterChanged
        Cursor = Cursors.WaitCursor
        Dim id_fg_woff As String = "-1"
        Try
            id_fg_woff = GVFGWoff.GetFocusedRowCellValue("id_fg_woff").ToString
        Catch ex As Exception
        End Try
        view_list_fg_woff(id_fg_woff)
        Cursor = Cursors.Default
    End Sub


    '==================PROPOSE PRICVE
    Private Sub BGoToFGProposePrice_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BGoToFGProposePrice.Click
        Cursor = Cursors.WaitCursor
        Try
            FormFGProposePrice.MdiParent = FormMain
            FormFGProposePrice.Show()
            FormFGProposePrice.WindowState = FormWindowState.Maximized
            FormFGProposePrice.Focus()
        Catch ex As Exception
            errorProcess()
        End Try
        FormFGProposePrice.GVFGPropose.FocusedRowHandle = find_row(FormFGProposePrice.GVFGPropose, "id_fg_propose_price", GVFGPropose.GetFocusedRowCellValue("id_fg_propose_price").ToString())
        Cursor = Cursors.Default
    End Sub


    Sub view_fg_propose_price()
        Dim query_c As ClassFGProposePrice = New ClassFGProposePrice()
        Dim query As String = query_c.queryMain("-1", "1")
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCFGPropose.DataSource = data
        check_menu()
        If data.Rows.Count > 0 Then
            GVFGPropose.FocusedRowHandle = 0
            view_list_fg_propose_price()
            BGoToFGProposePrice.Visible = True
        Else
            BGoToFGProposePrice.Visible = False
        End If
    End Sub

    Private Sub BRefFGProposePrice_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BRefFGProposePrice.Click
        GVFGPropose.ApplyFindFilter("")
        view_fg_propose_price()
    End Sub

    Sub view_list_fg_propose_price()
        Dim id_ As String = "-1"
        Try
            id_ = GVFGPropose.GetFocusedRowCellValue("id_fg_propose_price").ToString
        Catch ex As Exception
        End Try
        Dim src As String = "-1"
        Try
            src = GVFGPropose.GetFocusedRowCellValue("id_source").ToString
        Catch ex As Exception
        End Try

        Dim query_c As ClassFGProposePrice = New ClassFGProposePrice()
        Dim qurty As String = query_c.queryDetail(id_)
        If src = get_setup_field("id_code_fg_source_import") Then 'import
            XTCFGProposePrice.SelectedTabPageIndex = 1
            XTPLocal.PageVisible = False
            XTPImport.PageVisible = True
            Dim data As DataTable = execute_query(qurty, -1, True, "", "", "", "")
            GCItemListImport.DataSource = data
        Else 'local and the others
            XTCFGProposePrice.SelectedTabPageIndex = 0
            XTPLocal.PageVisible = True
            XTPImport.PageVisible = False
            Dim data As DataTable = execute_query(qurty, -1, True, "", "", "", "")
            GCItemListLocal.DataSource = data
        End If
    End Sub


    Private Sub GVItemListImport_CustomColumnDisplayText(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs) Handles GVItemListImport.CustomColumnDisplayText
        If e.Column.FieldName = "no" Then
            e.DisplayText = (e.ListSourceRowIndex + 1).ToString()
        End If
    End Sub


    Private Sub GVFGPropose_FocusedRowChanged(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles GVFGPropose.FocusedRowChanged
        Cursor = Cursors.WaitCursor
        view_list_fg_propose_price()
        Cursor = Cursors.Default
    End Sub

    Private Sub GVFGPropose_ColumnFilterChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GVFGPropose.ColumnFilterChanged
        Cursor = Cursors.WaitCursor
        view_list_fg_propose_price()
        Cursor = Cursors.Default
    End Sub

    Private Sub GVItemListLocal_CustomColumnDisplayText(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs) Handles GVItemListLocal.CustomColumnDisplayText
        If e.Column.FieldName = "no" Then
            e.DisplayText = (e.ListSourceRowIndex + 1).ToString()
        End If
    End Sub

    'CUSTOM SUMMARY LOCAL
    Dim custom_sum_final_price_loc As Decimal
    Dim custom_sum_cop_act_rate_loc As Decimal
    Dim custom_sum_markup_act_rate_prc_loc As Decimal
    Dim custom_sum_markup_act_rate_cop_loc As Decimal
    Private Sub GVItemListLocal_CustomSummaryCalculate(ByVal sender As System.Object, ByVal e As DevExpress.Data.CustomSummaryEventArgs) Handles GVItemListLocal.CustomSummaryCalculate
        ' Get the summary ID. 
        Dim summaryID As Integer = Convert.ToInt32(CType(e.Item, DevExpress.XtraGrid.GridSummaryItem).Tag)
        Dim View As DevExpress.XtraGrid.Views.Grid.GridView = CType(sender, DevExpress.XtraGrid.Views.Grid.GridView)

        ' Initialization 
        If e.SummaryProcess = DevExpress.Data.CustomSummaryProcess.Start Then
            custom_sum_final_price_loc = 0
            custom_sum_cop_act_rate_loc = 0
            custom_sum_markup_act_rate_prc_loc = 0
            custom_sum_markup_act_rate_cop_loc = 0
        End If

        ' Calculation 
        If e.SummaryProcess = DevExpress.Data.CustomSummaryProcess.Calculate Then
            Dim qty As Decimal = CDec(myCoalesce(View.GetRowCellValue(e.RowHandle, "fg_propose_price_det_qty").ToString, "0.00"))
            Dim prc As Decimal = CDec(myCoalesce(View.GetRowCellValue(e.RowHandle, "price_final"), "0.00"))
            Dim cop_act_rate As Decimal = CDec(myCoalesce(View.GetRowCellValue(e.RowHandle, "cop_final_rate_bom"), "0.0"))
            Dim cop_rate_app As Decimal = CDec(myCoalesce(View.GetRowCellValue(e.RowHandle, "cop_final_rate_management"), "0.0"))
            Select Case summaryID
                Case 1
                    custom_sum_final_price_loc += prc * qty
                Case 2
                    custom_sum_cop_act_rate_loc += cop_act_rate * qty
                Case 3
                    custom_sum_markup_act_rate_prc_loc += prc * qty
                    custom_sum_markup_act_rate_cop_loc += cop_act_rate * qty
            End Select
        End If

        ' Finalization 
        If e.SummaryProcess = DevExpress.Data.CustomSummaryProcess.Finalize Then
            Select Case summaryID
                Case 1
                    e.TotalValue = custom_sum_final_price_loc
                Case 2
                    e.TotalValue = custom_sum_cop_act_rate_loc
                Case 3
                    Dim res_mk_act = 0.0
                    Try
                        res_mk_act = custom_sum_markup_act_rate_prc_loc / custom_sum_markup_act_rate_cop_loc
                    Catch ex As Exception
                    End Try
                    e.TotalValue = res_mk_act
            End Select
        End If

    End Sub

    'CUSTOM SUMMARY IMPORT
    Dim custom_sum_final_price As Decimal
    Dim custom_sum_cop_pd As Decimal
    Dim custom_sum_cop_act_rate As Decimal
    Dim custom_sum_cop_rate_app As Decimal
    Dim custom_sum_markup_act_rate_prc As Decimal
    Dim custom_sum_markup_act_rate_cop As Decimal
    Dim custom_sum_markup_rate_app_prc As Decimal
    Dim custom_sum_markup_rate_app_cop As Decimal
    Private Sub GVItemListImport_CustomSummaryCalculate(ByVal sender As System.Object, ByVal e As DevExpress.Data.CustomSummaryEventArgs) Handles GVItemListImport.CustomSummaryCalculate
        ' Get the summary ID. 
        Dim summaryID As Integer = Convert.ToInt32(CType(e.Item, DevExpress.XtraGrid.GridSummaryItem).Tag)
        Dim View As DevExpress.XtraGrid.Views.Grid.GridView = CType(sender, DevExpress.XtraGrid.Views.Grid.GridView)

        ' Initialization 
        If e.SummaryProcess = DevExpress.Data.CustomSummaryProcess.Start Then
            custom_sum_final_price = 0
            custom_sum_cop_pd = 0
            custom_sum_cop_act_rate = 0
            custom_sum_cop_rate_app = 0
            custom_sum_markup_act_rate_prc = 0
            custom_sum_markup_act_rate_cop = 0
            custom_sum_markup_rate_app_prc = 0
            custom_sum_markup_rate_app_cop = 0
        End If

        ' Calculation 
        If e.SummaryProcess = DevExpress.Data.CustomSummaryProcess.Calculate Then
            Dim qty As Decimal = CDec(myCoalesce(View.GetRowCellValue(e.RowHandle, "fg_propose_price_det_qty").ToString, "0.00"))
            Dim prc As Decimal = CDec(myCoalesce(View.GetRowCellValue(e.RowHandle, "price_final"), "0.00"))
            Dim cop_pd As Decimal = CDec(myCoalesce(View.GetRowCellValue(e.RowHandle, "cop_pd"), "0.00"))
            Dim cop_act_rate As Decimal = CDec(myCoalesce(View.GetRowCellValue(e.RowHandle, "cop_final_rate_bom"), "0.0"))
            Dim cop_rate_app As Decimal = CDec(myCoalesce(View.GetRowCellValue(e.RowHandle, "cop_final_rate_management"), "0.0"))
            Select Case summaryID
                Case 1
                    custom_sum_final_price += prc * qty
                Case 2
                    custom_sum_cop_pd += cop_pd * qty
                Case 3
                    custom_sum_cop_act_rate += cop_act_rate * qty
                Case 4
                    custom_sum_cop_rate_app += cop_rate_app * qty
                Case 5
                    custom_sum_markup_act_rate_prc += prc * qty
                    custom_sum_markup_act_rate_cop += cop_act_rate * qty
                Case 6
                    custom_sum_markup_rate_app_prc = prc * qty
                    custom_sum_markup_rate_app_cop = cop_rate_app * qty
            End Select
        End If

        ' Finalization 
        If e.SummaryProcess = DevExpress.Data.CustomSummaryProcess.Finalize Then
            Select Case summaryID
                Case 1
                    e.TotalValue = custom_sum_final_price
                Case 2
                    e.TotalValue = custom_sum_cop_pd
                Case 3
                    e.TotalValue = custom_sum_cop_act_rate
                Case 4
                    e.TotalValue = custom_sum_cop_rate_app
                Case 5
                    Dim res_mk_act = 0.0
                    Try
                        res_mk_act = custom_sum_markup_act_rate_prc / custom_sum_markup_act_rate_cop
                    Catch ex As Exception
                    End Try
                    e.TotalValue = res_mk_act
                Case 6
                    Dim res_mk_app = 0.0
                    Try
                        res_mk_app = custom_sum_markup_rate_app_prc / custom_sum_markup_rate_app_cop
                    Catch ex As Exception
                    End Try
                    e.TotalValue = res_mk_app
            End Select
        End If

    End Sub

    Private Sub DEStart_EditValueChanged(sender As Object, e As EventArgs) Handles DEStart.EditValueChanged
        Try
            DEUntil.Properties.MinValue = DEStart.EditValue
        Catch ex As Exception
        End Try
    End Sub

    'Private Sub GVMarkNeed_CustomColumnDisplayText(sender As Object, e As DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs) Handles GVMarkNeed.CustomColumnDisplayText
    '    Try
    '        If e.Column.FieldName = "info" Then
    '            If GVMarkNeed.GetRowCellValue(GVMarkNeed.GetRowHandle(e.ListSourceRowIndex), "report_mark_type").ToString = "22" Then
    '                'PO production
    '                Dim id_po As String = GVMarkNeed.GetRowCellValue(GVMarkNeed.GetRowHandle(e.ListSourceRowIndex), "id_report").ToString
    '                Dim query As String = "SELECT pot.po_type FROM tb_prod_order po
    '                                    INNER JOIN tb_lookup_po_type pot ON pot.id_po_type=po.id_po_type WHERE po.id_prod_order='" & id_po & "'"
    '                e.DisplayText = execute_query(query, 0, True, "", "", "", "")
    '            ElseIf GVMarkNeed.GetRowCellValue(GVMarkNeed.GetRowHandle(e.ListSourceRowIndex), "report_mark_type").ToString = "23" Then
    '                'WO production
    '                Dim id_wo As String = GVMarkNeed.GetRowCellValue(GVMarkNeed.GetRowHandle(e.ListSourceRowIndex), "id_report").ToString
    '                Dim query As String = "SELECT pot.po_type FROM tb_prod_order_wo wo
    '                                    INNER JOIN tb_prod_order po ON po.id_prod_order=wo.id_prod_order
    '                                    INNER JOIN tb_lookup_po_type pot ON pot.id_po_type=po.id_po_type WHERE po.id_prod_order='" & id_wo & "'"
    '                e.DisplayText = execute_query(query, 0, True, "", "", "", "")
    '            End If
    '            e.DisplayText = ""
    '        End If
    '    Catch ex As Exception
    '    End Try
    'End Sub
End Class