Public Class FormFabricConsumption
    Public id_design As String = "-1"
    Private Sub FormFabricConsumption_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub BCancel_Click(sender As Object, e As EventArgs) Handles BCancel.Click
        Close()
    End Sub

    Sub load_mat()
        Dim q As String = "CALL view_mat_det(0)"
        viewSearchLookupRepositoryQuery(RISLEMatDet, q, 0, "mat_det_name", "id_mat_det")
        viewSearchLookupRepositoryQuery(RISLEACC, q, 0, "mat_det_name", "id_mat_det")
    End Sub

    Sub load_cur()
        Dim q As String = "SELECT id_currency,currency FROM tb_lookup_currency"
        viewSearchLookupRepositoryQuery(RISLECurrencyFab, q, 0, "currency", "id_currency")
        viewSearchLookupRepositoryQuery(RISLECurAcc, q, 0, "currency", "id_currency")
        viewSearchLookupRepositoryQuery(RISLECurOvh, q, 0, "currency", "id_currency")
    End Sub

    Private Sub FormFabricConsumption_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim q As String = "SELECT d.design_code,d.design_display_name,s.season FROM tb_m_design d 
INNER JOIN tb_season_delivery sd ON sd.`id_delivery`=d.`id_delivery`
INNER JOIN tb_season s ON s.`id_season`=sd.`id_season`
WHERE d.id_design='" & id_design & "'"
        Dim dt As DataTable = execute_query(q, -1, True, "", "", "", "")
        '
        If dt.Rows.Count > 0 Then
            TEDesignCode.Text = dt.Rows(0)("design_code").ToString
            TEDesignName.Text = dt.Rows(0)("design_code").ToString
            TESeason.Text = dt.Rows(0)("season").ToString
        End If
        '
        load_cur()
        load_mat()
        load_work()

        load_fab()
        load_acc()
        load_ovh()

        allow_but()
    End Sub

    Sub load_work()
        Dim q As String = "SELECT ovhp.`id_ovh_price`,c.`id_comp`,c.`comp_name`,ovh.`overhead`,ovhp.`ovh_price_name`,ovhp.`ovh_price`,ovhp.id_currency,cur.currency
FROM tb_m_ovh_price ovhp
INNER JOIN tb_m_ovh ovh ON ovh.`id_ovh`=ovhp.`id_ovh`
INNER JOIN tb_m_comp_contact cc ON cc.`id_comp_contact`=ovhp.`id_comp_contact`
INNER JOIN tb_m_comp c ON c.`id_comp`=cc.`id_comp`
INNER JOIN tb_lookup_currency cur ON cur.id_currency=ovhp.id_currency
WHERE ovhp.`is_enable_component`=1
ORDER BY c.`comp_name`"
        viewSearchLookupRepositoryQuery(RISLETechWork, q, 0, "overhead", "id_ovh_price")
    End Sub

    Sub load_fab()
        Dim q As String = "SELECT dc.`id_design_component`,md.`id_mat_det`,dc.`description`,dc.`qty`,dc.id_currency,dc.price,uom.uom
FROM `tb_design_component` dc
INNER JOIN tb_m_mat_det md ON md.`id_mat_det`=dc.`id_mat_det`
INNER JOIN tb_m_mat m ON m.id_mat=md.id_mat
INNER JOIN tb_m_uom uom ON uom.id_uom=m.id_uom
WHERE dc.`id_design`='" & id_design & "' AND dc.`id_cat`='1'"
        Dim dt As DataTable = execute_query(q, -1, True, "", "", "", "")
        GCFabCons.DataSource = dt
        GVFabCons.BestFitColumns()
    End Sub

    Sub load_acc()
        Dim q As String = "SELECT dc.`id_design_component`,md.`id_mat_det`,dc.`description`,dc.`qty`,dc.id_currency,dc.price,uom.uom
FROM `tb_design_component` dc
INNER JOIN tb_m_mat_det md ON md.`id_mat_det`=dc.`id_mat_det`
INNER JOIN tb_m_mat m ON m.id_mat=md.id_mat
INNER JOIN tb_m_uom uom ON uom.id_uom=m.id_uom
WHERE dc.`id_design`='" & id_design & "' AND dc.`id_cat`='2'"
        Dim dt As DataTable = execute_query(q, -1, True, "", "", "", "")
        GCACC.DataSource = dt
        GVACC.BestFitColumns()
    End Sub

    Sub load_ovh()
        Dim q As String = "SELECT dc.`id_design_component`,dc.`id_ovh_price`,dc.`description`,dc.`qty`,dc.id_currency,dc.price
FROM `tb_design_component` dc
INNER JOIN tb_m_ovh_price ovhp ON ovhp.`id_ovh_price`=dc.`id_ovh_price`
WHERE dc.`id_design`='" & id_design & "' AND dc.`id_cat`='3'"
        Dim dt As DataTable = execute_query(q, -1, True, "", "", "", "")
        GCOVH.DataSource = dt
        GVOVH.BestFitColumns()
    End Sub

    Private Sub BSave_Click(sender As Object, e As EventArgs) Handles BSave.Click
        Dim q As String = ""
        Dim qins As String = ""
        'check first
        Dim blank_val As Boolean = False

        For i = 0 To GVFabCons.RowCount - 1
            If GVFabCons.GetRowCellValue(i, "description").ToString = "" Or GVFabCons.GetRowCellValue(i, "id_mat_det").ToString = "" Or GVFabCons.GetRowCellValue(i, "price") <= 0 Or GVFabCons.GetRowCellValue(i, "qty") <= 0 Then
                blank_val = True
            End If
        Next

        If blank_val Then
            warningCustom("Please fill all value")
        Else
            q = "DELETE FROM tb_design_component WHERE id_design='" & id_design & "';INSERT INTO `tb_design_component`(id_cat,id_design,description,id_mat_det,id_ovh_price,id_currency,price,qty,date_created) VALUES"
            For i = 0 To GVFabCons.RowCount - 1
                If Not qins = "" Then
                    qins += ","
                End If
                qins += "('1','" & id_design & "','" & addSlashes(GVFabCons.GetRowCellValue(i, "description").ToString) & "','" & GVFabCons.GetRowCellValue(i, "id_mat_det").ToString & "',NULL,'" & GVFabCons.GetRowCellValue(i, "id_currency").ToString & "','" & decimalSQL(Decimal.Parse(GVFabCons.GetRowCellValue(i, "price").ToString)) & "','" & decimalSQL(Decimal.Parse(GVFabCons.GetRowCellValue(i, "qty").ToString)) & "',NOW())"
            Next
            For i = 0 To GVACC.RowCount - 1
                If Not qins = "" Then
                    qins += ","
                End If
                qins += "('2','" & id_design & "','" & addSlashes(GVACC.GetRowCellValue(i, "description").ToString) & "','" & GVACC.GetRowCellValue(i, "id_mat_det").ToString & "',NULL,'" & GVACC.GetRowCellValue(i, "id_currency").ToString & "','" & decimalSQL(Decimal.Parse(GVACC.GetRowCellValue(i, "price").ToString)) & "','" & decimalSQL(Decimal.Parse(GVACC.GetRowCellValue(i, "qty").ToString)) & "',NOW())"
            Next
            For i = 0 To GVOVH.RowCount - 1
                If Not qins = "" Then
                    qins += ","
                End If
                qins += "('3','" & id_design & "','" & addSlashes(GVOVH.GetRowCellValue(i, "description").ToString) & "',NULL," & GVOVH.GetRowCellValue(i, "id_ovh_price").ToString & ",'" & GVOVH.GetRowCellValue(i, "id_currency").ToString & "','" & decimalSQL(Decimal.Parse(GVOVH.GetRowCellValue(i, "price").ToString)) & "','" & decimalSQL(Decimal.Parse(GVOVH.GetRowCellValue(i, "qty").ToString)) & "',NOW())"
            Next
            execute_non_query(q & qins, True, "", "", "", "")
        End If
    End Sub

    Sub allow_but()
        If XTCComponent.SelectedTabPageIndex = 0 Then
            If GVFabCons.RowCount > 0 Then
                BDel.Visible = True
            Else
                BDel.Visible = False
            End If
        ElseIf XTCComponent.SelectedTabPageIndex = 1 Then
            If GVACC.RowCount > 0 Then
                BDel.Visible = True
            Else
                BDel.Visible = False
            End If
        ElseIf XTCComponent.SelectedTabPageIndex = 2 Then
            If GVOVH.RowCount > 0 Then
                BDel.Visible = True
            Else
                BDel.Visible = False
            End If
        End If
    End Sub

    Private Sub BDel_Click(sender As Object, e As EventArgs) Handles BDel.Click
        If XTCComponent.SelectedTabPageIndex = 0 Then
            If GVFabCons.RowCount > 0 Then
                GVFabCons.DeleteSelectedRows()
                allow_but()
            End If
        ElseIf XTCComponent.SelectedTabPageIndex = 1 Then
            If GVACC.RowCount > 0 Then
                GVACC.DeleteSelectedRows()
                allow_but()
            End If
        ElseIf XTCComponent.SelectedTabPageIndex = 2 Then
            If GVOVH.RowCount > 0 Then
                GVOVH.DeleteSelectedRows()
                allow_but()
            End If
        End If
    End Sub

    Private Sub BDefaultTemplate_Click(sender As Object, e As EventArgs) Handles BDefaultTemplate.Click
        'template
        Cursor = Cursors.WaitCursor
        Dim q As String = ""
        Dim dt As DataTable
        '1.Fabric
        delete_all_row(GVFabCons)
        q = "Select id_component,description,qty FROM tb_design_component_template WHERE id_cat='1'"
        dt = execute_query(q, -1, True, "", "", "", "")
        For i As Integer = 0 To dt.Rows.Count - 1
            new_row(GVFabCons, dt.Rows(i)("id_component").ToString, dt.Rows(i)("description").ToString, dt.Rows(i)("qty"))
        Next
        '2.Acc
        delete_all_row(GVACC)
        q = "Select id_component,description,qty FROM tb_design_component_template WHERE id_cat='2'"
        dt = execute_query(q, -1, True, "", "", "", "")
        For i As Integer = 0 To dt.Rows.Count - 1
            new_row(GVACC, dt.Rows(i)("id_component").ToString, dt.Rows(i)("description").ToString, dt.Rows(i)("qty"))
        Next

        GVFabCons.BestFitColumns()
        GVACC.BestFitColumns()
        allow_but()
        Cursor = Cursors.Default
    End Sub

    Sub delete_all_row(ByVal gv As DevExpress.XtraGrid.Views.Grid.GridView)
        For i = gv.RowCount - 1 To 0 Step -1
            gv.DeleteRow(i)
        Next
    End Sub

    Sub new_row(ByVal gv As DevExpress.XtraGrid.Views.Grid.GridView, ByVal id As String, ByVal desc As String, ByVal qty As Decimal)
        gv.AddNewRow()
        gv.FocusedRowHandle = gv.RowCount - 1
        gv.SetRowCellValue(gv.RowCount - 1, "id_component", id)
        gv.SetRowCellValue(gv.RowCount - 1, "description", desc)
        gv.SetRowCellValue(gv.RowCount - 1, "price", 0.0000)
        gv.SetRowCellValue(gv.RowCount - 1, "qty", qty)
    End Sub

    Private Sub BAdd_Click(sender As Object, e As EventArgs) Handles BAdd.Click
        If XTCComponent.SelectedTabPageIndex = 0 Then
            GVFabCons.AddNewRow()
            GVFabCons.FocusedRowHandle = GVFabCons.RowCount - 1
            GVFabCons.SetRowCellValue(GVFabCons.RowCount - 1, "price", 0.0000)
            GVFabCons.SetRowCellValue(GVFabCons.RowCount - 1, "qty", 1.0)
        ElseIf XTCComponent.SelectedTabPageIndex = 1 Then
            GVACC.AddNewRow()
            GVACC.FocusedRowHandle = GVACC.RowCount - 1
            GVACC.SetRowCellValue(GVACC.RowCount - 1, "price", 0.0000)
            GVACC.SetRowCellValue(GVACC.RowCount - 1, "qty", 1.0)
        ElseIf XTCComponent.SelectedTabPageIndex = 2 Then
            GVOVH.AddNewRow()
            GVOVH.FocusedRowHandle = GVOVH.RowCount - 1
            GVOVH.SetRowCellValue(GVOVH.RowCount - 1, "price", 0.0000)
            GVOVH.SetRowCellValue(GVOVH.RowCount - 1, "qty", 1.0)
        End If
        allow_but()
    End Sub

    Private Sub XTCComponent_SelectedPageChanged(sender As Object, e As DevExpress.XtraTab.TabPageChangedEventArgs) Handles XTCComponent.SelectedPageChanged
        allow_but()
    End Sub

    Private Sub RISLEMatDet_EditValueChanged(sender As Object, e As EventArgs) Handles RISLEMatDet.EditValueChanged
        Dim sle As DevExpress.XtraEditors.SearchLookUpEdit = CType(sender, DevExpress.XtraEditors.SearchLookUpEdit)
        GVFabCons.SetFocusedRowCellValue("price", sle.Properties.View.GetFocusedRowCellValue("mat_det_price").ToString())
        GVFabCons.SetFocusedRowCellValue("id_currency", sle.Properties.View.GetFocusedRowCellValue("id_currency").ToString())
        GVFabCons.SetFocusedRowCellValue("uom", sle.Properties.View.GetFocusedRowCellValue("uom").ToString())
    End Sub

    Private Sub RISLEACC_EditValueChanged(sender As Object, e As EventArgs) Handles RISLEACC.EditValueChanged
        Dim sle As DevExpress.XtraEditors.SearchLookUpEdit = CType(sender, DevExpress.XtraEditors.SearchLookUpEdit)
        GVACC.SetFocusedRowCellValue("price", sle.Properties.View.GetFocusedRowCellValue("mat_det_price").ToString())
        GVACC.SetFocusedRowCellValue("id_currency", sle.Properties.View.GetFocusedRowCellValue("id_currency").ToString())
        GVACC.SetFocusedRowCellValue("uom", sle.Properties.View.GetFocusedRowCellValue("uom").ToString())
    End Sub

    Private Sub RISLETechWork_EditValueChanged(sender As Object, e As EventArgs) Handles RISLETechWork.EditValueChanged
        Dim sle As DevExpress.XtraEditors.SearchLookUpEdit = CType(sender, DevExpress.XtraEditors.SearchLookUpEdit)
        GVOVH.SetFocusedRowCellValue("price", sle.Properties.View.GetFocusedRowCellValue("ovh_price").ToString())
        GVOVH.SetFocusedRowCellValue("id_currency", sle.Properties.View.GetFocusedRowCellValue("id_currency").ToString())
    End Sub
End Class