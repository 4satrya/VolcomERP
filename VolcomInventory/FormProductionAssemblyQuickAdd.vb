Public Class FormProductionAssemblyQuickAdd
    Private Sub BtnAddComponent_Click(sender As Object, e As EventArgs) Handles BtnAddComponent.Click
        Cursor = Cursors.WaitCursor
        makeSafeGV(GVComponent)
        FormProductionAssemblyComp.id_pop_up = "1"
        FormProductionAssemblyComp.data_par = GCComponent.DataSource
        FormProductionAssemblyComp.ShowDialog()
        Cursor = Cursors.Default
    End Sub

    Private Sub FormProductionAssemblyQuickAdd_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        viewData()
    End Sub

    Sub viewData()
        Cursor = Cursors.WaitCursor
        Dim query As String = "CALL view_prod_ass_comp_all(" + FormProductionAssemblySingle.id_prod_ass + ")"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCComponent.DataSource = data
        Cursor = Cursors.Default
    End Sub

    Private Sub BtnCancelComp_Click(sender As Object, e As EventArgs) Handles BtnCancelComp.Click
        Dim confirm As DialogResult = DevExpress.XtraEditors.XtraMessageBox.Show("This action will be removed all components. Are you sure you want to continue this action? ", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
        If confirm = Windows.Forms.DialogResult.Yes Then
            Cursor = Cursors.WaitCursor
            Dim ass As New ClassProductionAssembly()
            ass.removeAllComponents(FormProductionAssemblySingle.id_prod_ass)

            'update qty main
            Dim query_upd_main As String = "UPDATE tb_prod_ass_det main
            SET main.prod_ass_det_qty = 0 WHERE main.id_prod_ass=" + FormProductionAssemblySingle.id_prod_ass + " "
            execute_non_query(query_upd_main, True, "", "", "", "")

            viewData()
            FormProductionAssembly.viewData()
            FormProductionAssembly.GVData.FocusedRowHandle = find_row(FormProductionAssembly.GVData, "id_prod_ass", FormProductionAssemblySingle.id_prod_ass)
            FormProductionAssemblySingle.viewDetail()
            FormProductionAssemblySingle.viewBom()
            Cursor = Cursors.Default
        End If
    End Sub

    Private Sub FormProductionAssemblyQuickAdd_Activated(sender As Object, e As EventArgs) Handles MyBase.Activated
        Try
            GridColumnNameComp.GroupIndex = 0
            GVComponent.ExpandAllGroups()
        Catch ex As Exception
        End Try
    End Sub
End Class