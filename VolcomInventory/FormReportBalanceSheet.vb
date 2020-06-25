Public Class FormReportBalanceSheet
    Dim bnew_active As String = "0"
    Dim bedit_active As String = "0"
    Dim bdel_active As String = "0"

    Private Sub FormReportBalanceSheet_Activated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Activated
        FormMain.show_rb(Name)
        check_menu()
    End Sub

    Private Sub FormReportBalanceSheet_Deactivate(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Deactivate
        FormMain.hide_rb()
    End Sub

    Sub check_menu()
        bnew_active = "0"
        bedit_active = "0"
        bdel_active = "0"
        checkFormAccess(Name)
        button_main(bnew_active, bedit_active, bdel_active)
    End Sub

    Sub load_tag_coa()
        Dim q As String = "SELECT id_coa_tag,tag_description FROM `tb_coa_tag`"
        viewSearchLookupQuery(SLETaxTagCOA, q, "id_coa_tag", "tag_description", "id_coa_tag")
    End Sub

    Private Sub FormReportBalanceSheet_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        DEUntil.EditValue = New DateTime(Now.Year, Now.Month, Date.DaysInMonth(Now.Year, Now.Month))
        load_unit()
        load_tag_coa()

        Try
            CreateNodes(TLLedger, "", Date.Parse(DEUntil.EditValue.ToString), SLEUnit.EditValue.ToString)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub

    Sub load_unit()
        Dim query As String = "SELECT '0' AS id_comp,'-' AS comp_number, 'All Unit' AS comp_name
UNION ALL
SELECT ad.`id_comp`,c.`comp_number`,c.`comp_name` FROM `tb_a_acc_trans_det` ad
INNER JOIN tb_m_comp c ON c.`id_comp`=ad.`id_comp`
GROUP BY ad.id_comp"
        viewSearchLookupQuery(SLEUnit, query, "id_comp", "comp_number", "id_comp")
    End Sub

    Sub CreateNodes(ByVal tl As DevExpress.XtraTreeList.TreeList, ByVal opt As String, ByVal date_var As Date, ByVal unit As String)
        Dim unit_var As String = ""
        If Not unit = "0" Then
            unit_var = " AND atd.id_comp='" & unit & "'"
        End If
        tl.ClearNodes()
        tl.BeginUnboundLoad()
        ' Create a root node .
        Dim parentForRootNodes As DevExpress.XtraTreeList.Nodes.TreeListNode = Nothing
        'root
        Dim query As String = "SELECT a.id_acc,acc_name,a.id_acc_parent,a.acc_description,CAST(IFNULL(entry.debit,0) AS DECIMAL(13,2)) AS debit,CAST(IFNULL(entry.credit,0) AS DECIMAL(13,2)) AS credit,IFNULL(entry.this_month,0.00) AS this_month,IFNULL(entry.prev_month,0.00) AS prev_month,a.id_acc_cat,b.acc_cat,a.id_status,c.status,a.id_is_det,d.is_det,a.id_status,'' as id_all_child,comp.id_comp,comp.comp_name,comp.comp_number FROM tb_a_acc a"
        query += " INNER JOIN tb_lookup_acc_cat b ON a.id_acc_cat=b.id_acc_cat"
        query += " INNER JOIN tb_lookup_status c ON a.id_status=c.id_status "
        query += " INNER JOIN tb_lookup_is_det d ON a.id_is_det=d.id_is_det"
        query += " LEFT JOIN tb_m_comp comp ON comp.id_comp=a.id_comp "
        query += " LEFT JOIN ("
        query += " SELECT atd.id_acc,SUM(atd.debit) AS debit,SUM(atd.credit) AS credit
,SUM(IF(IFNULL(at.date_reference,at.date_created) < DATE_FORMAT('" & Date.Parse(date_var.ToString).ToString("yyyy-MM-dd") & "' ,'%Y-%m-01') AND IFNULL(at.date_reference,at.date_created) >= DATE_FORMAT(DATE_SUB('" & Date.Parse(date_var.ToString).ToString("yyyy-MM-dd") & "',INTERVAL 1 MONTH) ,'%Y-%m-01'),IF(acc.id_dc='2',atd.credit-atd.debit,atd.debit-atd.credit),0)) AS prev_month
,SUM(IF(DATE_FORMAT(IFNULL(at.date_reference,at.date_created),'%m-%Y')=DATE_FORMAT('" & Date.Parse(date_var.ToString).ToString("yyyy-MM-dd") & "','%m-%Y'),IF(acc.id_dc='2',atd.credit-atd.debit,atd.debit-atd.credit),0)) AS this_month
FROM tb_a_acc_trans_det atd 
INNER JOIN tb_a_acc acc ON acc.id_acc=atd.id_acc
INNER JOIN tb_a_acc_trans at ON at.id_acc_trans=atd.id_acc_trans AND DATE(at.date_created)<=DATE('" & Date.Parse(date_var.ToString).ToString("yyyy-MM-dd") & "') " & unit_var & " GROUP BY atd.id_acc"
        query += " ) entry ON entry.id_acc=a.id_acc"
        query += " " & opt

        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        Dim data_filter As DataRow() = data.Select("[id_acc_parent] is NULL AND [id_status]='1'")

        For i As Integer = 0 To data_filter.Length - 1
            Dim rootNode As DevExpress.XtraTreeList.Nodes.TreeListNode = tl.AppendNode(New Object() {data_filter(i)("id_acc").ToString, data_filter(i)("id_acc_parent").ToString, data_filter(i)("acc_name").ToString, data_filter(i)("acc_description").ToString, data_filter(i)("debit"), data_filter(i)("credit"), data_filter(i)("id_all_child"), data_filter(i)("prev_month"), data_filter(i)("this_month")}, parentForRootNodes)
            recursive_nodes(data_filter(i)("id_acc").ToString, rootNode, tl, data)
        Next

        ' Create a child node for the node1            
        'tl.AppendNode(New Object() {"Suyama, Michael", "Obere Str. 55", "030-0074263"}, rootNode)
        ' Creating more nodes
        ' ...

        tl.EndUnboundLoad()
        tl.ExpandAll()
    End Sub

    Sub recursive_nodes(ByVal id_acc As String, ByVal parent_nodes As DevExpress.XtraTreeList.Nodes.TreeListNode, ByVal tl As DevExpress.XtraTreeList.TreeList, ByVal data_table As DataTable)
        Dim data_filter As DataRow() = data_table.Select("[id_acc_parent]='" & id_acc & "' AND [id_status]='1'")

        If data_filter.Length > 0 Then
            For i As Integer = 0 To data_filter.Length - 1
                Dim newNode As DevExpress.XtraTreeList.Nodes.TreeListNode = tl.AppendNode(New Object() {data_filter(i)("id_acc").ToString, data_filter(i)("id_acc_parent").ToString, data_filter(i)("acc_name").ToString, data_filter(i)("acc_description").ToString, data_filter(i)("debit"), data_filter(i)("credit"), data_filter(i)("id_all_child"), data_filter(i)("prev_month"), data_filter(i)("this_month")}, parent_nodes)
                recursive_nodes(data_filter(i)("id_acc").ToString, newNode, tl, data_table)
                parent_nodes.SetValue("debit", parent_nodes.GetValue("debit") + newNode.GetValue("debit"))
                parent_nodes.SetValue("credit", parent_nodes.GetValue("credit") + newNode.GetValue("credit"))
                parent_nodes.SetValue("this_month", parent_nodes.GetValue("this_month") + newNode.GetValue("this_month"))
                parent_nodes.SetValue("prev_month", parent_nodes.GetValue("prev_month") + newNode.GetValue("prev_month"))

                If data_filter(i)("id_is_det").ToString = "2" Then
                    If parent_nodes.GetValue("id_all_child") = "" Then
                        parent_nodes.SetValue("id_all_child", data_filter(i)("id_acc").ToString)
                    Else
                        parent_nodes.SetValue("id_all_child", parent_nodes.GetValue("id_all_child").ToString & "," & data_filter(i)("id_acc").ToString)
                    End If
                    newNode.SetValue("id_all_child", data_filter(i)("id_acc").ToString)
                Else
                    If Not newNode.GetValue("id_all_child").ToString = "" Then
                        If parent_nodes.GetValue("id_all_child") = "" Then
                            parent_nodes.SetValue("id_all_child", newNode.GetValue("id_all_child").ToString)
                        Else
                            parent_nodes.SetValue("id_all_child", parent_nodes.GetValue("id_all_child").ToString & "," & newNode.GetValue("id_all_child").ToString)
                        End If
                    End If
                End If
            Next
        End If
    End Sub

    Private Sub BView_Click(sender As Object, e As EventArgs) Handles BView.Click
        If XTCBalanceSheet.SelectedTabPageIndex = 0 Then
            CreateNodes(TLLedger, "", Date.Parse(DEUntil.EditValue.ToString), SLEUnit.EditValue.ToString)
        ElseIf XTCBalanceSheet.SelectedTabPageIndex = 1 Then
            If XTCBS.SelectedTabPageIndex = 0 Then
                CreateNodes(TLBalanceSheet, " WHERE b.is_balance_sheet='1'", Date.Parse(DEUntil.EditValue.ToString), SLEUnit.EditValue.ToString)
            ElseIf XTCBS.SelectedTabPageIndex = 1 Then
                load_report(GCAktiva, "1")
                GVAktiva.BestFitColumns()
                GVAktiva.ExpandAllGroups()
                load_report(GCPasiva, "2")
                GVPasiva.BestFitColumns()
                GVPasiva.ExpandAllGroups()
            End If
        ElseIf XTCBalanceSheet.SelectedTabPageIndex = 2 Then
            If XTCProfitAndLoss.SelectedTabPageIndex = 0 Then
                CreateNodes(TLProfitAndLoss, " WHERE b.is_profit_loss='1'", Date.Parse(DEUntil.EditValue.ToString), SLEUnit.EditValue.ToString)
            ElseIf XTCProfitAndLoss.SelectedTabPageIndex = 1 Then
                load_report_pl(GCProfitAndLoss)
                GVProfitAndLoss.BestFitColumns()
                GVProfitAndLoss.ExpandAllGroups()
            End If
        End If
    End Sub

    Sub load_report(ByVal gc As DevExpress.XtraGrid.GridControl, ByVal opt As String)
        Dim date_str As String = Date.Parse(DEUntil.EditValue.ToString).ToString("yyyy-MM-dd")
        Dim unit_str As String = SLEUnit.EditValue.ToString
        Dim query As String = "CALL acc_show_report('" & date_str & "','" & opt & "','" & unit_str & "')"
        gc.DataSource = execute_query(query, -1, True, "", "", "", "")
    End Sub

    Sub load_report_pl(ByVal gc As DevExpress.XtraGrid.GridControl)
        Dim date_str As String = Date.Parse(DEUntil.EditValue.ToString).ToString("yyyy-MM-dd")
        Dim unit_str As String = SLEUnit.EditValue.ToString
        Dim query As String = "CALL acc_report_profit_loss('" & date_str & "','" & unit_str & "')"
        gc.DataSource = execute_query(query, -1, True, "", "", "", "")
    End Sub

    Private Sub DEUntil_EditValueChanged(sender As Object, e As EventArgs) Handles DEUntil.EditValueChanged
        Try
            DEUntil.EditValue = New DateTime(DEUntil.EditValue.Year, DEUntil.EditValue.Month, Date.DaysInMonth(DEUntil.EditValue.Year, DEUntil.EditValue.Month))
        Catch ex As Exception
        End Try
    End Sub

    Private Sub XTCBS_SelectedPageChanged(sender As Object, e As DevExpress.XtraTab.TabPageChangedEventArgs) Handles XTCBS.SelectedPageChanged
        If XTCBS.SelectedTabPageIndex = 1 Then
            SplitterBS.SplitterPosition = SplitterBS.Width / 2
        End If
    End Sub

    Private Sub BPrint_Click(sender As Object, e As EventArgs) Handles BPrint.Click
        If XTCBalanceSheet.SelectedTabPageIndex = 0 Then
            print_treelist(TLLedger, "Ledger")
        ElseIf XTCBalanceSheet.SelectedTabPageIndex = 1 Then
            If XTCBS.SelectedTabPageIndex = 0 Then
                print_treelist(TLBalanceSheet, "Balance Sheet")
            ElseIf XTCBS.SelectedTabPageIndex = 1 Then
                print_bs()
            End If
        ElseIf XTCBalanceSheet.SelectedTabPageIndex = 2 Then
            If XTCProfitAndLoss.SelectedTabPageIndex = 0 Then
                print_treelist(TLProfitAndLoss, "Profit And Loss")
            ElseIf XTCProfitAndLoss.SelectedTabPageIndex = 1 Then
                print(GCProfitAndLoss, "Profit And Loss")
            End If
        End If
    End Sub

    Sub print_bs()
        Cursor = Cursors.WaitCursor
        Dim Report As New ReportBalanceSheet()

        Dim Tool As DevExpress.XtraReports.UI.ReportPrintTool = New DevExpress.XtraReports.UI.ReportPrintTool(Report)
        Tool.ShowPreviewDialog()

        Cursor = Cursors.Default
    End Sub

    Private Sub XTCBalanceSheet_SelectedPageChanged(sender As Object, e As DevExpress.XtraTab.TabPageChangedEventArgs) Handles XTCBalanceSheet.SelectedPageChanged
        If XTCBalanceSheet.SelectedTabPageIndex = 0 Or XTCBalanceSheet.SelectedTabPageIndex = 2 Then
            PCFilterUpper.Visible = True
        Else
            PCFilterUpper.Visible = False
        End If
    End Sub

    Private Sub BViewPajak_Click(sender As Object, e As EventArgs) Handles BViewPajak.Click

    End Sub
End Class