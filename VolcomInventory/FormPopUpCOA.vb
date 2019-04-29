Imports DevExpress.XtraEditors
Imports DevExpress.XtraGrid.Views.Base
Imports DevExpress.XtraVerticalGrid

Public Class FormPopUpCOA
    Public id_coa As String = "-1"
    Public id_pop_up As String = "-1'"

    Private helperx As MyTreeListSearchHelper
    Private helpery As MyTreeListSearchHelper

    Private Sub FormPopUpCOA_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If id_pop_up = "8" Or id_pop_up = "9" Or id_pop_up = "10" Or id_pop_up = "11" Or id_pop_up = "12" Then
            XTPOpenTrans.PageVisible = False
            XTPAccount.PageVisible = False
        End If

        helperx = New MyTreeListSearchHelper(TreeList1)
        helpery = New MyTreeListSearchHelper(TreeList1)

        CreateNodes(TreeList1)

        'If id_pop_up = "1" Then
        '    load_open_trans()
        '    XTPOpenTrans.PageVisible = True
        'Else
        '    XTPOpenTrans.PageVisible = False
        'End If

        helperx.FieldName = "acc_name"
        helpery.FieldName = "acc_description"
        helperx.Text = ButtonEdit1.Text
        helpery.Text = ButtonEdit2.Text

        If Not id_coa = "-1" Then
            TreeList1.FocusedNode = TreeList1.FindNodeByKeyID(id_coa)
        Else
            TreeList1.FocusedNode = TreeList1.Nodes.FirstNode
        End If
        view_acc()
    End Sub

    Sub CreateNodes(ByVal tl As DevExpress.XtraTreeList.TreeList)
        tl.ClearNodes()
        tl.BeginUnboundLoad()
        ' Create a root node .
        Dim parentForRootNodes As DevExpress.XtraTreeList.Nodes.TreeListNode = Nothing
        'root
        Dim query As String = "SELECT a.id_acc,acc_name,a.id_acc_parent,a.acc_description,a.id_acc_cat,b.acc_cat,a.id_status,c.status,a.id_is_det,d.is_det,a.id_status FROM tb_a_acc a "
        query += "INNER JOIN tb_lookup_acc_cat b ON a.id_acc_cat=b.id_acc_cat INNER JOIN tb_lookup_status c ON a.id_status=c.id_status INNER JOIN tb_lookup_is_det d ON a.id_is_det=d.id_is_det"
        'query += " WHERE a.id_acc_parent=a.id_acc"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        Dim data_filter As DataRow() = data.Select("[id_acc_parent] is NULL AND [id_status]='1'")

        'MsgBox(data_filter.Length.ToString)

        For i As Integer = 0 To data_filter.Length - 1
            Dim rootNode As DevExpress.XtraTreeList.Nodes.TreeListNode = tl.AppendNode(New Object() {data_filter(i)("id_acc").ToString, data_filter(i)("id_acc_parent").ToString, data_filter(i)("acc_name").ToString, data_filter(i)("acc_description").ToString, data_filter(i)("id_is_det").ToString}, parentForRootNodes)
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
                Dim parentNode As DevExpress.XtraTreeList.Nodes.TreeListNode = tl.AppendNode(New Object() {data_filter(i)("id_acc").ToString, data_filter(i)("id_acc_parent").ToString, data_filter(i)("acc_name").ToString, data_filter(i)("acc_description").ToString, data_filter(i)("id_is_det").ToString}, parent_nodes)
                recursive_nodes(data_filter(i)("id_acc").ToString, parentNode, tl, data_table)
            Next
        End If
    End Sub

    Private Sub TreeList1_FocusedNodeChanged(ByVal sender As System.Object, ByVal e As DevExpress.XtraTreeList.FocusedNodeChangedEventArgs) Handles TreeList1.FocusedNodeChanged
        If id_pop_up = "1" Or id_pop_up = "3" Or id_pop_up = "4" Then 'Entry Journal
            If TreeList1.Nodes.Count > 0 Then
                If Not TreeList1.FocusedNode("id_is_det").ToString() = "2" Then
                    BSave.Enabled = False
                Else
                    BSave.Enabled = True
                End If
            End If
        End If
    End Sub

    Private Sub BCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BCancel.Click
        Close()
    End Sub

    Private Sub FormPopUpCOA_FormClosed(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub buttonEdit1_Properties_ButtonClick(ByVal sender As Object, ByVal e As DevExpress.XtraEditors.Controls.ButtonPressedEventArgs) Handles ButtonEdit1.Properties.ButtonClick
        PerformSearch(e.Button.Index = 1)
    End Sub
    Private Sub PerformSearch(ByVal forward As Boolean)
        Cursor = Cursors.WaitCursor
        helperx.PerformSearch(forward)
        TreeList1.FocusedNode = helperx.CurrentNode
        Cursor = Cursors.Default
    End Sub

    Private Sub buttonEdit2_Properties_ButtonClick(ByVal sender As Object, ByVal e As DevExpress.XtraEditors.Controls.ButtonPressedEventArgs) Handles ButtonEdit2.Properties.ButtonClick
        PerformSearchy(e.Button.Index = 1)
    End Sub
    Private Sub PerformSearchy(ByVal forward As Boolean)
        Cursor = Cursors.WaitCursor
        helpery.PerformSearch(forward)
        TreeList1.FocusedNode = helpery.CurrentNode
        Cursor = Cursors.Default
    End Sub

    Private Sub ButtonEdit1_EditValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonEdit1.EditValueChanged
        TreeList1.FocusedNode = TreeList1.Nodes.FirstNode
        If Not helperx Is Nothing Then
            helperx.Text = ButtonEdit1.Text
            PerformSearch(1)
        End If
    End Sub

    Private Sub ButtonEdit2_EditValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonEdit2.EditValueChanged
        TreeList1.FocusedNode = TreeList1.Nodes.FirstNode
        If Not helpery Is Nothing Then
            helpery.Text = ButtonEdit2.Text
            PerformSearchy(1)
        End If
    End Sub

    Private Sub BSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BSave.Click
        pick_acc()
    End Sub
    Sub pick_acc()
        If id_pop_up = "1" Then 'Entry Journal
            If id_coa <> "-1" Then
                'edit
                'check if exist
                Dim already = False
                If FormAccountingJournalDet.GVJournalDet.RowCount > 0 Then
                    For i As Integer = 0 To FormAccountingJournalDet.GVJournalDet.RowCount - 1
                        If FormAccountingJournalDet.GVJournalDet.GetRowCellValue(i, "id_acc").ToString = TreeList1.FocusedNode("id_acc").ToString() And Not TreeList1.FocusedNode("id_acc").ToString() = id_coa Then
                            already = True
                        End If
                    Next
                End If

                If already = True Then
                    stopCustom("This account already on list.")
                Else
                    FormAccountingJournalDet.GVJournalDet.SetRowCellValue(FormAccountingJournalDet.GVJournalDet.FocusedRowHandle, "id_acc", TreeList1.FocusedNode("id_acc").ToString())
                    FormAccountingJournalDet.GVJournalDet.SetRowCellValue(FormAccountingJournalDet.GVJournalDet.FocusedRowHandle, "acc_name", TreeList1.FocusedNode("acc_name").ToString())
                    FormAccountingJournalDet.GVJournalDet.SetRowCellValue(FormAccountingJournalDet.GVJournalDet.FocusedRowHandle, "note", TreeList1.FocusedNode("acc_description").ToString())
                    FormAccountingJournalDet.GVJournalDet.SetRowCellValue(FormAccountingJournalDet.GVJournalDet.FocusedRowHandle, "debit", 0)
                    FormAccountingJournalDet.GVJournalDet.SetRowCellValue(FormAccountingJournalDet.GVJournalDet.FocusedRowHandle, "credit", 0)
                    FormAccountingJournalDet.GVJournalDet.SetRowCellValue(FormAccountingJournalDet.GVJournalDet.FocusedRowHandle, "id_status_open", 1)

                    FormAccountingJournalDet.GVJournalDet.FocusedRowHandle = 0
                    FormAccountingJournalDet.but_check()
                    Close()
                End If
            Else
                'new
                'check if exist
                Dim already = False
                If FormAccountingJournalDet.GVJournalDet.RowCount > 0 Then
                    For i As Integer = 0 To FormAccountingJournalDet.GVJournalDet.RowCount - 1
                        If FormAccountingJournalDet.GVJournalDet.GetRowCellValue(i, "id_acc").ToString = TreeList1.FocusedNode("id_acc").ToString() Then
                            already = True
                        End If
                    Next
                End If

                If already = True Then
                    stopCustom("Account already in list")
                Else
                    Dim newRow As DataRow = (TryCast(FormAccountingJournalDet.GCJournalDet.DataSource, DataTable)).NewRow()
                    newRow("id_acc") = TreeList1.FocusedNode("id_acc").ToString()
                    newRow("acc_name") = TreeList1.FocusedNode("acc_name").ToString()
                    newRow("note") = TreeList1.FocusedNode("acc_description").ToString()
                    newRow("debit") = 0
                    newRow("credit") = 0
                    newRow("id_status_open") = 1

                    TryCast(FormAccountingJournalDet.GCJournalDet.DataSource, DataTable).Rows.Add(newRow)
                    FormAccountingJournalDet.GCJournalDet.RefreshDataSource()
                    ' FormAccountingJournalDet.check_but()
                    FormAccountingJournalDet.but_check()
                    FormAccountingJournalDet.GVJournalDet.FocusedRowHandle = 0
                    Close()
                End If
            End If
        ElseIf id_pop_up = "2" Then
            FormMappingCOA.GVAcc.SetRowCellValue(FormMappingCOA.GVAcc.FocusedRowHandle, "id_acc", TreeList1.FocusedNode("id_acc").ToString())
            FormMappingCOA.GVAcc.SetRowCellValue(FormMappingCOA.GVAcc.FocusedRowHandle, "acc_name", TreeList1.FocusedNode("acc_name").ToString())
            FormMappingCOA.GVAcc.SetRowCellValue(FormMappingCOA.GVAcc.FocusedRowHandle, "acc_description", TreeList1.FocusedNode("acc_description").ToString())
            FormMappingCOA.GVAcc.FocusedRowHandle = 0
            Close()
        ElseIf id_pop_up = "3" Then 'Adjustment Entry Journal
            If id_coa <> "-1" Then
                'edit
                'check if exist
                'Dim already = False
                'If FormAccountingJournalAdjDet.GVJournalDet.RowCount > 0 Then
                '    For i As Integer = 0 To FormAccountingJournalAdjDet.GVJournalDet.RowCount - 1
                '        If FormAccountingJournalAdjDet.GVJournalDet.GetRowCellValue(i, "id_acc").ToString = TreeList1.FocusedNode("id_acc").ToString() And Not TreeList1.FocusedNode("id_acc").ToString() = id_coa Then
                '            already = True
                '        End If
                '    Next
                'End If

                'If already = True Then
                '    stopCustom("This account already on list.")
                'Else
                FormAccountingJournalAdjDet.GVJournalDet.SetRowCellValue(FormAccountingJournalDet.GVJournalDet.FocusedRowHandle, "id_acc", TreeList1.FocusedNode("id_acc").ToString())
                FormAccountingJournalAdjDet.GVJournalDet.SetRowCellValue(FormAccountingJournalDet.GVJournalDet.FocusedRowHandle, "acc_name", TreeList1.FocusedNode("acc_name").ToString())
                FormAccountingJournalAdjDet.GVJournalDet.SetRowCellValue(FormAccountingJournalDet.GVJournalDet.FocusedRowHandle, "note", TreeList1.FocusedNode("acc_description").ToString())
                FormAccountingJournalAdjDet.GVJournalDet.SetRowCellValue(FormAccountingJournalDet.GVJournalDet.FocusedRowHandle, "debit", 0)
                FormAccountingJournalAdjDet.GVJournalDet.SetRowCellValue(FormAccountingJournalDet.GVJournalDet.FocusedRowHandle, "credit", 0)

                FormAccountingJournalAdjDet.GVJournalDet.FocusedRowHandle = 0
                FormAccountingJournalAdjDet.but_check()
                Close()
                'End If
            Else
                'new
                'check if exist
                'Dim already = False
                'If FormAccountingJournalAdjDet.GVJournalDet.RowCount > 0 Then
                '    For i As Integer = 0 To FormAccountingJournalAdjDet.GVJournalDet.RowCount - 1
                '        If FormAccountingJournalAdjDet.GVJournalDet.GetRowCellValue(i, "id_acc").ToString = TreeList1.FocusedNode("id_acc").ToString() Then
                '            already = True
                '        End If
                '    Next
                'End If

                'If already = True Then
                '    stopCustom("Account already in list")
                'Else
                Dim newRow As DataRow = (TryCast(FormAccountingJournalAdjDet.GCJournalDet.DataSource, DataTable)).NewRow()
                newRow("id_acc") = TreeList1.FocusedNode("id_acc").ToString()
                newRow("acc_name") = TreeList1.FocusedNode("acc_name").ToString()
                newRow("note") = TreeList1.FocusedNode("acc_description").ToString()
                newRow("debit") = 0
                newRow("credit") = 0

                TryCast(FormAccountingJournalAdjDet.GCJournalDet.DataSource, DataTable).Rows.Add(newRow)
                FormAccountingJournalAdjDet.GCJournalDet.RefreshDataSource()
                ' FormAccountingJournalDet.check_but()
                FormAccountingJournalAdjDet.but_check()
                FormAccountingJournalAdjDet.GVJournalDet.FocusedRowHandle = 0
                Close()
                'End If
            End If
        ElseIf id_pop_up = "4" Then 'Mapping popup
            FormPopUpAccountMap.id_coa = TreeList1.FocusedNode("id_acc").ToString()
            FormPopUpAccountMap.TECoaNumber.Text = TreeList1.FocusedNode("acc_name").ToString()
            FormPopUpAccountMap.TECoaName.Text = TreeList1.FocusedNode("acc_description").ToString()

            Close()
        ElseIf id_pop_up = "5" Then 'Mapping list det
            FormAccountingMappingListDet.id_acc = TreeList1.FocusedNode("id_acc").ToString()
            FormAccountingMappingListDet.is_search_cc = TreeList1.FocusedNode("id_is_det").ToString() '1=detail;2=parent
            FormAccountingMappingListDet.TECoaNumber.Text = TreeList1.FocusedNode("acc_name").ToString()
            FormAccountingMappingListDet.MEDesc.Text = TreeList1.FocusedNode("acc_description").ToString()

            Close()
        ElseIf id_pop_up = "6" Then 'Entry Journal
            'new
            'check if exist
            Dim already = False
            If FormAccountingJournalBill.GVJournalDet.RowCount > 0 Then
                For i As Integer = 0 To FormAccountingJournalDet.GVJournalDet.RowCount - 1
                    If FormAccountingJournalBill.GVJournalDet.GetRowCellValue(i, "id_acc").ToString = TreeList1.FocusedNode("id_acc").ToString() Then
                        already = True
                    End If
                Next
            End If

            If already = True Then
                stopCustom("Account already in list")
            Else
                Dim newRow As DataRow = (TryCast(FormAccountingJournalBill.GCJournalDet.DataSource, DataTable)).NewRow()
                newRow("id_acc") = TreeList1.FocusedNode("id_acc").ToString()
                newRow("acc_name") = TreeList1.FocusedNode("acc_name").ToString()
                newRow("note") = TreeList1.FocusedNode("acc_description").ToString()
                newRow("debit") = 0
                newRow("credit") = 0
                newRow("id_comp") = 0
                'newRow("report_mark_type") = 0
                'newRow("id_report") = 0
                newRow("report_number") = ""
                newRow("id_status_open") = 1

                TryCast(FormAccountingJournalBill.GCJournalDet.DataSource, DataTable).Rows.Add(newRow)
                FormAccountingJournalBill.GCJournalDet.RefreshDataSource()
                ' FormAccountingJournalDet.check_but()
                FormAccountingJournalBill.but_check()
                FormAccountingJournalBill.GVJournalDet.FocusedRowHandle = 0
                Close()
            End If
        ElseIf id_pop_up = "7" Then 'Mapping in company single
            If FormMasterCompanySingle.GVCoaMapping.RowCount > 0 Then
                'save first
                Dim query As String = ""
                If FormMasterCompanySingle.GVCoaMapping.GetFocusedRowCellValue("id_comp_coa").ToString = "" Then  'new
                    query = "INSERT INTO tb_m_comp_coa(id_comp,id_coa_map_det,id_acc) VALUES('" + FormMasterCompanySingle.id_company.ToString + "','" + FormMasterCompanySingle.GVCoaMapping.GetFocusedRowCellValue("id_coa_map_det").ToString + "','" + TreeList1.FocusedNode("id_acc").ToString() + "')"
                Else 'edit
                    query = "UPDATE tb_m_comp_coa SET id_acc='" + TreeList1.FocusedNode("id_acc").ToString() + "' WHERE id_comp_coa='" + FormMasterCompanySingle.GVCoaMapping.GetFocusedRowCellValue("id_comp_coa").ToString + "'"
                End If
                execute_non_query(query, True, "", "", "", "")
                'end save 

                FormMasterCompanySingle.GVCoaMapping.SetFocusedRowCellValue("id_acc", TreeList1.FocusedNode("id_acc").ToString())
                FormMasterCompanySingle.GVCoaMapping.SetFocusedRowCellValue("acc_name", TreeList1.FocusedNode("acc_name").ToString())
            Else
                infoCustom("Please select the type transaction to map first.")
            End If
            Close()
        ElseIf id_pop_up = "8" Then 'inv store
            Dim id As String = FormItemCatMappingDet.id
            Dim query As String = "UPDATE tb_item_coa_propose SET acc_coa_receive='" + GVAcc.GetFocusedRowCellValue("id_acc").ToString + "' WHERE id_item_coa_propose='" + id + "' "
            execute_non_query(query, True, "", "", "", "")
            FormItemCatMappingDet.loadMain()
            Close()
        ElseIf id_pop_up = "9" Then 'hutang
            Dim id As String = FormItemCatMappingDet.id
            Dim query As String = "UPDATE tb_item_coa_propose SET acc_coa_hutang='" + GVAcc.GetFocusedRowCellValue("id_acc").ToString + "' WHERE id_item_coa_propose='" + id + "' "
            execute_non_query(query, True, "", "", "", "")
            FormItemCatMappingDet.loadMain()
            Close()
        ElseIf id_pop_up = "10" Then 'inv WH
            Dim id As String = FormItemCatMappingDet.id
            Dim query As String = "UPDATE tb_item_coa_propose SET acc_coa_trf='" + GVAcc.GetFocusedRowCellValue("id_acc").ToString + "' WHERE id_item_coa_propose='" + id + "' "
            execute_non_query(query, True, "", "", "", "")
            FormItemCatMappingDet.loadMain()
            Close()
        ElseIf id_pop_up = "11" Then 'general setup
            'receive account
            FormAccounting.acc_coa_receive = GVAcc.GetFocusedRowCellValue("id_acc").ToString
            FormAccounting.TxtRecAccount.Text = GVAcc.GetFocusedRowCellValue("acc_name").ToString
            FormAccounting.TxtRecDesc.Text = GVAcc.GetFocusedRowCellValue("acc_description").ToString
            Close()
        ElseIf id_pop_up = "12" Then 'general setup
            'vat account
            FormAccounting.acc_coa_vat_in = GVAcc.GetFocusedRowCellValue("id_acc").ToString
            FormAccounting.TxtVATAccount.Text = GVAcc.GetFocusedRowCellValue("acc_name").ToString
            FormAccounting.TxtVATDesc.Text = GVAcc.GetFocusedRowCellValue("acc_description").ToString
            Close()
        End If
    End Sub
    Sub load_open_trans()
        Dim query As String = ""
        query = "SELECT c.date_created,a.id_acc_trans_det,a.id_acc_trans,c.acc_trans_number,a.id_acc,b.acc_name,b.id_acc_parent,b.acc_description,CAST(IFNULL(a.debit,0) AS DECIMAL(13,2)) AS debit,CAST(IFNULL(a.credit,0) AS DECIMAL(13,2)) AS credit,a.acc_trans_det_note as note,a.id_status_open FROM tb_a_acc_trans_det a "
        query += " INNER JOIN tb_a_acc b ON  a.id_acc=b.id_acc"
        query += " INNER JOIN tb_a_acc_trans c ON c.id_acc_trans=a.id_acc_trans"
        query += " WHERE a.id_status_open='1' AND c.id_report_status='6'"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")

        GCJournalDet.DataSource = data
    End Sub

    Private Sub BCancelOT_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BCancelOT.Click
        Close()
    End Sub

    Private Sub BPickOT_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BPickOT.Click
        If id_coa <> "-1" Then
            'edit
            Dim already = False
            If FormAccountingJournalDet.GVJournalDet.RowCount > 0 Then
                For i As Integer = 0 To FormAccountingJournalDet.GVJournalDet.RowCount - 1
                    If FormAccountingJournalDet.GVJournalDet.GetRowCellValue(i, "id_acc").ToString = GVJournalDet.GetFocusedRowCellValue("id_acc").ToString() And Not GVJournalDet.GetFocusedRowCellValue("id_acc").ToString() = id_coa Then
                        already = True
                    End If
                Next
            End If

            If already = True Then
                stopCustom("This account already on list.")
            Else
                FormAccountingJournalDet.GVJournalDet.SetRowCellValue(FormAccountingJournalDet.GVJournalDet.FocusedRowHandle, "id_acc", GVJournalDet.GetFocusedRowCellValue("id_acc").ToString())
                FormAccountingJournalDet.GVJournalDet.SetRowCellValue(FormAccountingJournalDet.GVJournalDet.FocusedRowHandle, "acc_name", GVJournalDet.GetFocusedRowCellValue("acc_name").ToString())
                FormAccountingJournalDet.GVJournalDet.SetRowCellValue(FormAccountingJournalDet.GVJournalDet.FocusedRowHandle, "note", GVJournalDet.GetFocusedRowCellValue("note").ToString())
                FormAccountingJournalDet.GVJournalDet.SetRowCellValue(FormAccountingJournalDet.GVJournalDet.FocusedRowHandle, "debit", GVJournalDet.GetFocusedRowCellValue("credit"))
                FormAccountingJournalDet.GVJournalDet.SetRowCellValue(FormAccountingJournalDet.GVJournalDet.FocusedRowHandle, "credit", GVJournalDet.GetFocusedRowCellValue("debit"))
                FormAccountingJournalDet.GVJournalDet.SetRowCellValue(FormAccountingJournalDet.GVJournalDet.FocusedRowHandle, "id_status_open", 1)

                FormAccountingJournalDet.GVJournalDet.FocusedRowHandle = 0
                FormAccountingJournalDet.but_check()
                Close()
            End If
        Else
            'new
            Dim already = False
            If FormAccountingJournalDet.GVJournalDet.RowCount > 0 Then
                For i As Integer = 0 To FormAccountingJournalDet.GVJournalDet.RowCount - 1
                    If FormAccountingJournalDet.GVJournalDet.GetRowCellValue(i, "id_acc").ToString = GVJournalDet.GetFocusedRowCellValue("id_acc").ToString() Then
                        already = True
                    End If
                Next
            End If

            If already = True Then
                stopCustom("Account already in list")
            Else
                Dim newRow As DataRow = (TryCast(FormAccountingJournalDet.GCJournalDet.DataSource, DataTable)).NewRow()
                'newRow("id_acc_src") = GVJournalDet.GetFocusedRowCellValue("id_acc").ToString()
                newRow("id_acc") = GVJournalDet.GetFocusedRowCellValue("id_acc").ToString()
                newRow("acc_name") = GVJournalDet.GetFocusedRowCellValue("acc_name").ToString()
                newRow("note") = GVJournalDet.GetFocusedRowCellValue("note").ToString()
                newRow("debit") = GVJournalDet.GetFocusedRowCellValue("credit")
                newRow("credit") = GVJournalDet.GetFocusedRowCellValue("debit")
                newRow("id_status_open") = 1

                TryCast(FormAccountingJournalDet.GCJournalDet.DataSource, DataTable).Rows.Add(newRow)
                FormAccountingJournalDet.GCJournalDet.RefreshDataSource()
                ' FormAccountingJournalDet.check_but()
                FormAccountingJournalDet.but_check()
                FormAccountingJournalDet.GVJournalDet.FocusedRowHandle = 0
                Close()
            End If
        End If
    End Sub
    Sub view_acc()
        Dim query As String = ""
        query += "SELECT a.id_acc,acc_name,a.acc_description,a.id_acc_cat,b.acc_cat,a.id_status,c.status,a.id_is_det,d.is_det,comp.id_comp,comp.comp_name,comp.comp_number FROM tb_a_acc a "
        query += "INNER JOIN tb_lookup_acc_cat b ON a.id_acc_cat=b.id_acc_cat INNER JOIN tb_lookup_status c ON a.id_status=c.id_status INNER JOIN tb_lookup_is_det d ON a.id_is_det=d.id_is_det "
        query += "LEFT JOIN tb_m_comp comp ON comp.id_comp=a.id_comp 
        WHERE a.id_status=1 "

        If id_pop_up = "8" Or id_pop_up = "9" Or id_pop_up = "10" Then
            query += "AND a.id_is_det=2 "
        End If

        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCAcc.DataSource = data
    End Sub

    Private Sub GVAcc_FocusedRowChanged(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles GVAcc.FocusedRowChanged
        If GVAcc.RowCount > 0 Then
            Dim id_acc As String = "-1"
            id_acc = GVAcc.GetFocusedRowCellValue("id_acc").ToString
            TreeList1.SetFocusedNode(TreeList1.FindNodeByFieldValue("id_acc", id_acc))
        End If
    End Sub

    Private Sub BCancelTable_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BCancelTable.Click
        Close()
    End Sub

    Private Sub BPickTable_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BPickTable.Click
        pick_acc()
    End Sub

    Private Sub GVAcc_ColumnFilterChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GVAcc.ColumnFilterChanged
        If GVAcc.RowCount > 0 Then
            Dim id_acc As String = "-1"
            id_acc = GVAcc.GetFocusedRowCellValue("id_acc").ToString
            TreeList1.SetFocusedNode(TreeList1.FindNodeByFieldValue("id_acc", id_acc))
        End If
    End Sub
End Class