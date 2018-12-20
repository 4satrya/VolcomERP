Imports System.Linq
Imports DevExpress.XtraEditors
Imports DevExpress.XtraTreeList
Imports System.Collections.Generic
Imports DevExpress.XtraTreeList.Nodes
Imports DevExpress.XtraTreeList.Columns

Public Class FormAccounting
    Dim bnew_active As String = "1"
    Dim bedit_active As String = "1"
    Dim bdel_active As String = "1"

    Private Sub FormAccounting_Activated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Activated
        FormMain.show_rb(Name)
        checkFormAccess(Name)
        button_main(bnew_active, bedit_active, bdel_active)
    End Sub

    Private Sub FormAccounting_Deactivate(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Deactivate
        FormMain.hide_rb()
    End Sub

    Private Sub FormAccounting_FormClosed(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Sub check_but()
        If XTCGeneral.SelectedTabPageIndex = 0 Then
            If GVAcc.RowCount > 0 Then
                bnew_active = "1"
                bedit_active = "1"
                bdel_active = "1"
            Else
                bnew_active = "1"
                bedit_active = "0"
                bdel_active = "0"
            End If
        Else
            If TreeList1.Nodes.Count > 0 Then
                bnew_active = "0"
                bedit_active = "0"
                bdel_active = "0"
            Else
                bnew_active = "1"
                bedit_active = "0"
                bdel_active = "0"
            End If
        End If
        checkFormAccess(Name)
        button_main(bnew_active, bedit_active, bdel_active)
    End Sub

    Private Sub FormAccounting_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        For Each t As DevExpress.XtraTab.XtraTabPage In XTCGeneral.TabPages
            XTCGeneral.SelectedTabPage = t
        Next t
        XTCGeneral.SelectedTabPage = XTCGeneral.TabPages(0)
        view_acc()
        viewCategory()
        CreateNodes(TreeList1)
    End Sub

    Sub viewCompany()
        Cursor = Cursors.WaitCursor
        Dim id_comp_cat As String = LECompanyCategory.EditValue.ToString
        Dim query As String = "SELECT tb_m_comp.id_comp as id_comp,tb_m_comp.comp_number as comp_number,
        tb_m_comp.comp_name as comp_name,tb_m_comp.address_primary as address_primary,tb_m_comp.is_active as is_active,
        tb_m_comp_cat.comp_cat_name as company_category ,
        IFNULL(tb_m_comp.id_acc_ap,0) AS `id_acc_ap`, 
        IFNULL(tb_m_comp.id_acc_dp,0) AS `id_acc_dp`,
        IFNULL(tb_m_comp.id_acc_ar,0) AS `id_acc_ar`,
        IFNULL(tb_m_comp.id_acc_sales,0) AS `id_acc_sales`,
        IFNULL(tb_m_comp.id_acc_sales_return,0) AS `id_acc_sales_return`,
        CONCAT(ap.acc_name,' - ', ap.acc_description) AS `acc_ap`,
        CONCAT(dp.acc_name,' - ', dp.acc_description) AS `acc_dp`,
        CONCAT(ar.acc_name,' - ', ar.acc_description) AS `acc_ar`,
        CONCAT(sal.acc_name,' - ', sal.acc_description) AS `acc_sales`,
        CONCAT(sal_ret.acc_name,' - ', sal_ret.acc_description) AS `acc_sales_return`
        FROM tb_m_comp
        INNER JOIN tb_m_comp_cat ON tb_m_comp.id_comp_cat=tb_m_comp_cat.id_comp_cat
        LEFT JOIN tb_a_acc ap ON ap.id_acc = tb_m_comp.id_acc_ap
        LEFT JOIN tb_a_acc dp ON dp.id_acc = tb_m_comp.id_acc_dp
        LEFT JOIN tb_a_acc ar ON ar.id_acc = tb_m_comp.id_acc_ar
        LEFT JOIN tb_a_acc sal ON sal.id_acc = tb_m_comp.id_acc_sales
        LEFT JOIN tb_a_acc sal_ret ON sal_ret.id_acc = tb_m_comp.id_acc_sales_return
        WHERE tb_m_comp.id_comp>0 "
        If id_comp_cat <> "0" Then
            query += "AND tb_m_comp.id_comp_cat='" + id_comp_cat + "' "
        End If
        query += "ORDER BY comp_name ASC "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCCompany.DataSource = data
        GVCompany.BestFitColumns()
        Cursor = Cursors.Default
    End Sub

    Private Sub viewCategory()
        Dim query As String = "SELECT 0 AS `id_comp_cat`, 'All Category' AS `comp_cat_name` UNION ALL SELECT id_comp_cat,comp_cat_name FROM tb_m_comp_cat"
        viewLookupQuery(LECompanyCategory, query, 0, "comp_cat_name", "id_comp_cat")
    End Sub

    Sub view_acc()
        Dim query As String = ""
        query += "SELECT a.id_acc,acc_name,a.acc_description,a.id_acc_cat,b.acc_cat,a.id_status,c.status,a.id_is_det,d.is_det,comp.id_comp,comp.comp_name,comp.comp_number FROM tb_a_acc a "
        query += "INNER JOIN tb_lookup_acc_cat b ON a.id_acc_cat=b.id_acc_cat INNER JOIN tb_lookup_status c ON a.id_status=c.id_status INNER JOIN tb_lookup_is_det d ON a.id_is_det=d.id_is_det "
        query += "LEFT JOIN tb_m_comp comp ON comp.id_comp=a.id_comp "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCAcc.DataSource = data
    End Sub

    Sub CreateNodes(ByVal tl As DevExpress.XtraTreeList.TreeList)
        tl.ClearNodes()
        tl.BeginUnboundLoad()
        ' Create a root node .
        Dim parentForRootNodes As DevExpress.XtraTreeList.Nodes.TreeListNode = Nothing
        'root
        Dim query As String = "SELECT a.id_acc,acc_name,a.id_acc_parent,a.acc_description,CAST(IFNULL(entry.debit,0) AS DECIMAL(13,2)) AS debit,CAST(IFNULL(entry.credit,0) AS DECIMAL(13,2)) AS credit,a.id_acc_cat,b.acc_cat,a.id_status,c.status,a.id_is_det,d.is_det,a.id_status,'' as id_all_child,comp.id_comp,comp.comp_name,comp.comp_number FROM tb_a_acc a"
        query += " INNER JOIN tb_lookup_acc_cat b ON a.id_acc_cat=b.id_acc_cat "
        query += " INNER JOIN tb_lookup_status c ON a.id_status=c.id_status "
        query += " INNER JOIN tb_lookup_is_det d ON a.id_is_det=d.id_is_det"
        query += " LEFT JOIN tb_m_comp comp ON comp.id_comp=a.id_comp "
        query += " LEFT JOIN ("
        query += " SELECT id_acc,SUM(debit) AS debit,SUM(credit) AS credit FROM"
        query += " ("
        query += " SELECT id_acc,SUM(debit) AS debit,SUM(credit) AS credit FROM tb_a_acc_trans_det GROUP BY id_acc"
        query += " UNION"
        query += " SELECT id_acc,SUM(debit) AS debit,SUM(credit) AS credit FROM tb_a_acc_trans_adj_det GROUP BY id_acc"
        query += " ) a GROUP BY id_acc"
        query += " ) entry ON entry.id_acc=a.id_acc"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        Dim data_filter As DataRow() = data.Select("[id_acc_parent] is NULL AND [id_status]='1'")

        For i As Integer = 0 To data_filter.Length - 1
            Dim rootNode As DevExpress.XtraTreeList.Nodes.TreeListNode = tl.AppendNode(New Object() {data_filter(i)("id_acc").ToString, data_filter(i)("id_acc_parent").ToString, data_filter(i)("acc_name").ToString, data_filter(i)("acc_description").ToString, data_filter(i)("debit"), data_filter(i)("credit"), data_filter(i)("id_all_child"), data_filter(i)("comp_name"), data_filter(i)("comp_number"), data_filter(i)("id_comp")}, parentForRootNodes)
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
                Dim newNode As DevExpress.XtraTreeList.Nodes.TreeListNode = tl.AppendNode(New Object() {data_filter(i)("id_acc").ToString, data_filter(i)("id_acc_parent").ToString, data_filter(i)("acc_name").ToString, data_filter(i)("acc_description").ToString, data_filter(i)("debit"), data_filter(i)("credit"), data_filter(i)("id_all_child"), data_filter(i)("comp_name"), data_filter(i)("comp_number"), data_filter(i)("id_comp")}, parent_nodes)
                recursive_nodes(data_filter(i)("id_acc").ToString, newNode, tl, data_table)
                parent_nodes.SetValue("debit", parent_nodes.GetValue("debit") + newNode.GetValue("debit"))
                parent_nodes.SetValue("credit", parent_nodes.GetValue("credit") + newNode.GetValue("credit"))

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

    Private Sub XTCGeneral_SelectedPageChanged(ByVal sender As System.Object, ByVal e As DevExpress.XtraTab.TabPageChangedEventArgs) Handles XTCGeneral.SelectedPageChanged
        check_but()
    End Sub

    Private SavedFocused As TreeListNode
    Private NeedRestoreFocused As Boolean

    Private Sub treeList1_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles TreeList1.MouseUp
        Dim tree As TreeList = TryCast(sender, TreeList)
        If e.Button = MouseButtons.Right AndAlso ModifierKeys = Keys.None AndAlso tree.State = TreeListState.Regular Then
            Dim pt As Point = tree.PointToClient(MousePosition)
            Dim info As TreeListHitInfo = tree.CalcHitInfo(pt)
            If info.HitInfoType = HitInfoType.Cell Then
                SavedFocused = tree.FocusedNode
                Dim SavedTopIndex As Integer = tree.TopVisibleNodeIndex
                tree.FocusedNode = info.Node
                NeedRestoreFocused = True
                BalanceMenu.Show(Cursor.Position)
            End If
        End If
    End Sub
    Private Sub treeList2_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs)
        Dim tree As TreeList = TryCast(sender, TreeList)
        If e.Button = MouseButtons.Right AndAlso ModifierKeys = Keys.None AndAlso tree.State = TreeListState.Regular Then
            Dim pt As Point = tree.PointToClient(MousePosition)
            Dim info As TreeListHitInfo = tree.CalcHitInfo(pt)
            If info.HitInfoType = HitInfoType.Cell Then
                SavedFocused = tree.FocusedNode
                Dim SavedTopIndex As Integer = tree.TopVisibleNodeIndex
                tree.FocusedNode = info.Node
                NeedRestoreFocused = True
                BalanceMenu.Show(Cursor.Position)
            End If
        End If
    End Sub
    Private Sub SMViewTransaction_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SMViewTransaction.Click
        FormAccountingTrs.id_pop_up = "1"
        FormAccountingTrs.id_acc = TreeList1.FocusedNode.GetValue("id_acc").ToString
        FormAccountingTrs.id_acc_child = TreeList1.FocusedNode.GetValue("id_all_child").ToString
        FormAccountingTrs.ShowDialog()
    End Sub

    Private Sub GVAcc_DoubleClick(sender As Object, e As EventArgs) Handles GVAcc.DoubleClick
        If GVAcc.RowCount > 0 And GVAcc.FocusedRowHandle >= 0 Then
            FormMain.but_edit()
        End If
    End Sub

    Private Sub BtnViewCompany_Click(sender As Object, e As EventArgs) Handles BtnViewCompany.Click
        viewCompany()
    End Sub

    Private Sub GVCompany_DoubleClick(sender As Object, e As EventArgs) Handles GVCompany.DoubleClick
        If GVCompany.RowCount > 0 And GVCompany.FocusedRowHandle >= 0 Then
            Cursor = Cursors.WaitCursor
            FormAccountingARAP.ShowDialog()
            Cursor = Cursors.Default
        End If
    End Sub
End Class