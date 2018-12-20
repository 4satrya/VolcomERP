Public Class FormBOMSingleOvh
    Public id_bom As String = "-1"
    Public id_bom_det As String = "-1"

    Public id_pop_up As String = "-1"
    Public id_ovh As String = "-1"

    Private Sub FormBOMSingleOvh_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        TEQty.EditValue = 0.0
        TEKurs.EditValue = 0.0
        CEOVHMain.Checked = False
        view_currency(LECurrency)
        '
        If id_pop_up = "-1" Then
            LECurrency.EditValue = Nothing
            LECurrency.ItemIndex = LECurrency.Properties.GetDataSourceRowIndex("id_currency", FormBOMSingle.LECurrency.EditValue.ToString)
            LabelBomName.Text = FormBOMSingle.LabelPrintedName.Text
        ElseIf id_pop_up = "1" Then 'Per PD Design
            LECurrency.EditValue = Nothing
            LECurrency.ItemIndex = LECurrency.Properties.GetDataSourceRowIndex("id_currency", FormBOMDesignSingle.LECurrency.EditValue.ToString)
            LabelBomName.Text = FormBOMDesignSingle.LabelPrintedName.Text
        ElseIf id_pop_up = "2" Then 'per design
            LECurrency.EditValue = Nothing
            LECurrency.ItemIndex = LECurrency.Properties.GetDataSourceRowIndex("id_currency", FormBOMSingle.LECurrency.EditValue.ToString)
            LabelBomName.Text = FormBOMSingle.LabelPrintedName.Text
        End If

        view_ovh()
        If id_pop_up = "-1" Then
            If Not id_bom_det = "-1" Then
                '
                Dim id_ovh As String
                id_ovh = get_id_ovh(id_bom_det)
                GVOVH.FocusedRowHandle = find_row(GVOVH, "id_ovh", id_ovh)
                '
                Dim query As String = String.Format("SELECT * FROM tb_bom_det WHERE id_bom_det = '{0}'", id_bom_det)
                Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")

                GVOVHPrice.FocusedRowHandle = find_row(GVOVHPrice, "id_ovh_price", data.Rows(0)("id_ovh_price").ToString)
                '
                TEKurs.EditValue = data.Rows(0)("kurs")
                TEPrice.EditValue = data.Rows(0)("bom_price")
                TEQty.EditValue = data.Rows(0)("component_qty")
                '
                calculate()

                If FormBOMSingle.GVBomDetOvh.GetFocusedRowCellValue("is_ovh_main").ToString = "1" Then
                    CEOVHMain.Checked = True
                Else
                    CEOVHMain.Checked = False
                End If
            Else
                TEKurs.EditValue = FormBOMSingle.TEKurs.EditValue
            End If
        ElseIf id_pop_up = "1" Then
            If Not id_ovh = "-1" Then
                GVOVH.FocusedRowHandle = find_row(GVOVH, "id_ovh", FormBOMDesignSingle.GVBomDetOvh.GetFocusedRowCellValue("id_component").ToString)
                load_ovh_price()
                '
                Dim query As String = String.Format("SELECT * FROM tb_bom_det WHERE id_bom_det = '{0}'", id_bom_det)
                Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")

                GVOVHPrice.FocusedRowHandle = find_row(GVOVHPrice, "id_ovh_price", data.Rows(0)("id_ovh_price").ToString)
                '
                TEPrice.EditValue = FormBOMDesignSingle.GVBomDetOvh.GetFocusedRowCellValue("price")
                TEQty.EditValue = FormBOMDesignSingle.GVBomDetOvh.GetFocusedRowCellValue("qty")
                TEKurs.EditValue = FormBOMDesignSingle.GVBomDetOvh.GetFocusedRowCellValue("kurs")

                If FormBOMDesignSingle.GVBomDetOvh.GetFocusedRowCellValue("is_ovh_main").ToString = "1" Then
                    CEOVHMain.Checked = True
                Else
                    CEOVHMain.Checked = False
                End If
            Else
                TEKurs.EditValue = FormBOMDesignSingle.TEKurs.EditValue
            End If
        ElseIf id_pop_up = "2" Then 'per Design
            Console.WriteLine(id_bom_det)
            If Not id_bom_det = "-1" Then
                '
                id_ovh = get_id_ovh(id_bom_det)
                GVOVH.FocusedRowHandle = find_row(GVOVH, "id_ovh", id_ovh)
                '
                Dim query As String = String.Format("SELECT * FROM tb_bom_det WHERE id_bom_det = '{0}'", id_bom_det)
                Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")

                GVOVHPrice.FocusedRowHandle = find_row(GVOVHPrice, "id_ovh_price", data.Rows(0)("id_ovh_price").ToString)
                '
                TEKurs.EditValue = data.Rows(0)("kurs")
                TEPrice.EditValue = data.Rows(0)("bom_price")
                TEQty.EditValue = data.Rows(0)("component_qty")
                '
                calculate()

                If FormBOMSingle.GVBomDetOvh.GetFocusedRowCellValue("is_ovh_main").ToString = "1" Then
                    CEOVHMain.Checked = True
                Else
                    CEOVHMain.Checked = False
                End If
            Else
                TEKurs.EditValue = FormBOMSingle.TEKurs.EditValue
            End If
        End If
    End Sub
    Sub view_ovh()
        Try
            Dim query As String
            query = "SELECT ovh.id_ovh,ovh.overhead_code,ovh.overhead,uom.uom,cat.ovh_cat "
            query += " FROM tb_m_ovh ovh"
            query += " INNER JOIN tb_m_uom uom On ovh.id_uom=uom.id_uom"
            query += " INNER JOIN tb_m_ovh_cat cat ON ovh.id_ovh_cat=cat.id_ovh_cat"

            Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
            GCOVH.DataSource = data
            '
            If Not data.Rows.Count < 1 Then
                view_ovh_price(GVOVH.GetFocusedRowCellDisplayText("id_ovh").ToString)
            End If
        Catch ex As Exception
            errorConnection()
        End Try
    End Sub
    Sub view_ovh_price(ByVal id_ovhx As String)
        Dim query As String = "SELECT tb_lookup_currency.currency,tb_m_ovh_price.id_ovh_price,tb_m_ovh_price.ovh_price_name,tb_m_ovh_price.ovh_price,tb_m_ovh_price.ovh_price_date,tb_m_comp.comp_name,tb_m_ovh_price.id_currency FROM tb_m_ovh_price,tb_m_comp,tb_m_comp_contact,tb_lookup_currency WHERE tb_m_ovh_price.id_currency=tb_lookup_currency.id_currency AND tb_m_ovh_price.id_comp_contact=tb_m_comp_contact.id_comp_contact AND tb_m_comp_contact.id_comp=tb_m_comp.id_comp AND tb_m_ovh_price.id_ovh='" & id_ovhx & "' ORDER BY tb_m_ovh_price.id_ovh_price DESC"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCOVHPrice.DataSource = data

        If Not data.Rows.Count < 1 Then
            BSave.Enabled = True
        Else
            BSave.Enabled = False
        End If
    End Sub
    Sub load_ovh_price()
        TEVendCur.Text = GVOVHPrice.GetFocusedRowCellDisplayText("currency").ToString
        TEVendPrice.EditValue = GVOVHPrice.GetFocusedRowCellValue("ovh_price")
        TEPrice.EditValue = TEVendPrice.EditValue
        TEUOM.Text = GVOVH.GetFocusedRowCellDisplayText("uom").ToString

        calculate()
    End Sub
    Private Sub view_currency(ByVal lookup As DevExpress.XtraEditors.LookUpEdit)
        Dim query As String = "SELECT id_currency,currency FROM tb_lookup_currency"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")

        lookup.Properties.DataSource = data

        lookup.Properties.DisplayMember = "currency"
        lookup.Properties.ValueMember = "id_currency"
        lookup.ItemIndex = 0
    End Sub

    Private Sub FormBOMSingleOvh_FormClosed(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub GVOVH_FocusedRowChanged(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles GVOVH.FocusedRowChanged
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
        If GVOVH.RowCount > 0 Then
            view_ovh_price(GVOVH.GetFocusedRowCellValue("id_ovh"))
        End If
    End Sub

    Private Sub GVOVHPrice_RowClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Grid.RowClickEventArgs) Handles GVOVHPrice.RowClick
        load_ovh_price()
    End Sub

    Private Sub GVOVH_RowClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Grid.RowClickEventArgs) Handles GVOVH.RowClick
        view_ovh_price(GVOVH.GetFocusedRowCellDisplayText("id_ovh").ToString)
    End Sub

    Private Sub TEKurs_EditValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TEKurs.EditValueChanged
        calculate()
    End Sub

    Private Sub TEQty_EditValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TEQty.EditValueChanged
        calculate()
    End Sub
    Sub calculate()
        Try
            'Dim price_kurs, price_tot As Decimal
            Dim price_tot As Decimal
            'If TEVendPrice.EditValue = 0 Or TEKurs.EditValue = 0 Then
            '    TEPrice.EditValue = 0
            'Else
            '    price_kurs = TEVendPrice.EditValue * TEKurs.EditValue
            '    TEPrice.EditValue = price_kurs
            'End If

            If TEPrice.EditValue = 0 Or TEQty.EditValue = 0 Then
                TEPriceTot.EditValue = 0
            Else
                price_tot = TEPrice.EditValue * TEQty.EditValue
                TEPriceTot.EditValue = price_tot
            End If
        Catch ex As Exception
        End Try
    End Sub
    Private Sub BSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BSave.Click
        Dim id_component_category, id_component_price, error_text, query As String

        Dim kurs, bom_price, component_qty As Decimal

        id_component_category = "2"
        error_text = "-1"
        '
        id_component_price = "0"
        kurs = 0
        bom_price = 0
        component_qty = 0
        '
        Try
            id_component_price = GVOVHPrice.GetFocusedRowCellDisplayText("id_ovh_price").ToString
            kurs = TEKurs.EditValue
            bom_price = TEPrice.EditValue
            component_qty = TEQty.EditValue
        Catch ex As Exception
            error_text = "1"
        End Try

        If error_text <> "-1" Then
            'ada error
            errorInput()
        ElseIf Not GVOVHPrice.RowCount > 0 Then
            stopCustom("Please choose overhead with proper price.")
        ElseIf Not TEQty.EditValue > 0 Then
            stopCustom("Please insert qty of overhead.")
        Else
            Dim is_ovh_main As Integer
            If CEOVHMain.Checked = True Then
                is_ovh_main = "1"
            Else
                is_ovh_main = "2"
            End If
            If id_pop_up = "-1" Then
                If id_bom_det <> "-1" Then
                    'edit
                    Dim query_jml As String = String.Format("SELECT COUNT(id_bom_det) FROM tb_bom_det WHERE id_ovh_price='{0}' AND id_bom='{1}' AND id_bom_det !='{2}'", id_component_price, id_bom, id_bom_det)
                    Dim jml As Integer = execute_query(query_jml, 0, True, "", "", "", "")
                    If Not jml < 1 Then
                        errorDuplicate(" Overhead.")
                    Else
                        If is_ovh_main = "1" Then
                            query = String.Format("UPDATE tb_bom_det SET is_ovh_main='{0}' WHERE id_bom='{1}'", is_ovh_main, id_bom)
                            execute_non_query(query, True, "", "", "", "")
                        End If
                        query = String.Format("UPDATE tb_bom_det SET id_ovh_price='{0}',kurs='{1}',bom_price='{2}',component_qty='{3}',is_ovh_main='{5}' WHERE id_bom_det='{4}'", id_component_price, decimalSQL(kurs.ToString), decimalSQL(bom_price.ToString), decimalSQL(component_qty.ToString), id_bom_det, is_ovh_main)
                        execute_non_query(query, True, "", "", "", "")
                        FormBOMSingle.view_bom_ovh(id_bom)
                        Close()
                    End If
                Else
                    'insert
                    Dim query_jml As String = String.Format("SELECT COUNT(id_bom_det) FROM tb_bom_det WHERE id_ovh_price='{0}' AND id_bom='{1}'", id_component_price, id_bom)
                    Dim jml As Integer = execute_query(query_jml, 0, True, "", "", "", "")
                    If Not jml < 1 Then
                        errorDuplicate(" Overhead.")
                    Else
                        If is_ovh_main = "1" Then
                            query = String.Format("UPDATE tb_bom_det SET is_ovh_main='2' WHERE id_bom='{1}'", is_ovh_main, id_bom)
                            execute_non_query(query, True, "", "", "", "")
                        End If
                        query = String.Format("INSERT INTO tb_bom_det(id_bom,id_ovh_price,kurs,bom_price,component_qty,id_component_category,is_ovh_main) VALUES('{0}','{1}','{2}','{3}','{4}','{5}','{6}')", id_bom, id_component_price, decimalSQL(kurs.ToString), decimalSQL(bom_price.ToString), decimalSQL(component_qty.ToString), id_component_category, is_ovh_main)
                        execute_non_query(query, True, "", "", "", "")
                        FormBOMSingle.view_bom_ovh(id_bom)
                        Close()
                    End If
                End If
            ElseIf id_pop_up = "1" Then
                If id_ovh <> "-1" Then
                    'edit
                    Dim dupe As String = "1"
                    For i As Integer = 0 To FormBOMDesignSingle.GVBomDetOvh.RowCount - 1
                        If Not FormBOMDesignSingle.GVBomDetOvh.GetRowCellValue(i, "id_component").ToString = id_ovh Then
                            If FormBOMDesignSingle.GVBomDetOvh.GetRowCellValue(i, "id_component").ToString = GVOVH.GetFocusedRowCellValue("id_ovh").ToString Then
                                dupe = "2"
                                Exit For
                            End If
                        End If
                    Next
                    If dupe = "2" Then
                        stopCustom("Overhead already on list.")
                    Else
                        'edit
                        If is_ovh_main = "1" Then
                            For i As Integer = 0 To FormBOMDesignSingle.GVBomDetOvh.RowCount - 1
                                FormBOMDesignSingle.GVBomDetOvh.SetRowCellValue(0, "is_ovh_main", 2)
                            Next
                        End If
                        FormBOMDesignSingle.GVBomDetOvh.SetFocusedRowCellValue("id_component", GVOVH.GetFocusedRowCellValue("id_ovh").ToString)
                        FormBOMDesignSingle.GVBomDetOvh.SetFocusedRowCellValue("id_component_price", GVOVHPrice.GetFocusedRowCellValue("id_ovh_price").ToString)
                        FormBOMDesignSingle.GVBomDetOvh.SetFocusedRowCellValue("code", GVOVH.GetFocusedRowCellValue("overhead_code").ToString)
                        FormBOMDesignSingle.GVBomDetOvh.SetFocusedRowCellValue("name", GVOVH.GetFocusedRowCellValue("overhead").ToString)
                        FormBOMDesignSingle.GVBomDetOvh.SetFocusedRowCellValue("size", "-")
                        FormBOMDesignSingle.GVBomDetOvh.SetFocusedRowCellValue("color", "-")
                        FormBOMDesignSingle.GVBomDetOvh.SetFocusedRowCellValue("qty", TEQty.EditValue)
                        FormBOMDesignSingle.GVBomDetOvh.SetFocusedRowCellValue("kurs", TEKurs.EditValue)
                        FormBOMDesignSingle.GVBomDetOvh.SetFocusedRowCellValue("currency", GVOVHPrice.GetFocusedRowCellValue("currency").ToString)
                        FormBOMDesignSingle.GVBomDetOvh.SetFocusedRowCellValue("uom", GVOVH.GetFocusedRowCellValue("uom").ToString)
                        FormBOMDesignSingle.GVBomDetOvh.SetFocusedRowCellValue("ovh_cat", GVOVH.GetFocusedRowCellValue("ovh_cat").ToString)

                        If GVOVHPrice.GetFocusedRowCellValue("id_currency").ToString = "1" Then
                            FormBOMDesignSingle.GVBomDetOvh.SetFocusedRowCellValue("price", bom_price)
                            FormBOMDesignSingle.GVBomDetOvh.SetFocusedRowCellValue("unit_price", bom_price)
                            FormBOMDesignSingle.GVBomDetOvh.SetFocusedRowCellValue("total", bom_price * component_qty)
                        Else
                            FormBOMDesignSingle.GVBomDetOvh.SetFocusedRowCellValue("price", bom_price)
                            FormBOMDesignSingle.GVBomDetOvh.SetFocusedRowCellValue("unit_price", bom_price * kurs)
                            FormBOMDesignSingle.GVBomDetOvh.SetFocusedRowCellValue("total", bom_price * component_qty * kurs)
                        End If
                        FormBOMDesignSingle.GVBomDetOvh.SetFocusedRowCellValue("is_ovh_main", is_ovh_main)
                        FormBOMDesignSingle.GCBomDetOvh.RefreshDataSource()
                        FormBOMDesignSingle.GVBomDetOvh.RefreshData()
                        FormBOMDesignSingle.show_but_ovh()
                        FormBOMDesignSingle.calculate_unit_price()
                        FormBOMDesignSingle.GVBomDetOvh.BestFitColumns()
                        Close()
                    End If
                Else
                    'insert
                    Dim dupe As String = "1"
                    For i As Integer = 0 To FormBOMDesignSingle.GVBomDetOvh.RowCount - 1
                        If FormBOMDesignSingle.GVBomDetOvh.GetRowCellValue(i, "id_component").ToString = GVOVH.GetFocusedRowCellValue("id_ovh").ToString Then
                            dupe = "2"
                            Exit For
                        End If
                    Next
                    If dupe = "2" Then
                        stopCustom("Overhead already on list.")
                    Else
                        'insert
                        If is_ovh_main = "1" Then
                            For i As Integer = 0 To FormBOMDesignSingle.GVBomDetOvh.RowCount - 1
                                FormBOMDesignSingle.GVBomDetOvh.SetRowCellValue(0, "is_ovh_main", 2)
                            Next
                        End If
                        FormBOMDesignSingle.GVBomDetOvh.AddNewRow()
                        FormBOMDesignSingle.GVBomDetOvh.SetFocusedRowCellValue("id_component", GVOVH.GetFocusedRowCellValue("id_ovh").ToString)
                        FormBOMDesignSingle.GVBomDetOvh.SetFocusedRowCellValue("id_component_price", GVOVHPrice.GetFocusedRowCellValue("id_ovh_price").ToString)
                        FormBOMDesignSingle.GVBomDetOvh.SetFocusedRowCellValue("code", GVOVH.GetFocusedRowCellValue("overhead_code").ToString)
                        FormBOMDesignSingle.GVBomDetOvh.SetFocusedRowCellValue("name", GVOVH.GetFocusedRowCellValue("overhead").ToString)
                        FormBOMDesignSingle.GVBomDetOvh.SetFocusedRowCellValue("size", "-")
                        FormBOMDesignSingle.GVBomDetOvh.SetFocusedRowCellValue("color", "-")
                        FormBOMDesignSingle.GVBomDetOvh.SetFocusedRowCellValue("qty", TEQty.EditValue)
                        FormBOMDesignSingle.GVBomDetOvh.SetFocusedRowCellValue("kurs", TEKurs.EditValue)
                        FormBOMDesignSingle.GVBomDetOvh.SetFocusedRowCellValue("currency", GVOVHPrice.GetFocusedRowCellValue("currency").ToString)
                        FormBOMDesignSingle.GVBomDetOvh.SetFocusedRowCellValue("uom", GVOVH.GetFocusedRowCellValue("uom").ToString)
                        FormBOMDesignSingle.GVBomDetOvh.SetFocusedRowCellValue("ovh_cat", GVOVH.GetFocusedRowCellValue("ovh_cat").ToString)
                        If GVOVHPrice.GetFocusedRowCellValue("id_currency").ToString = "1" Then
                            FormBOMDesignSingle.GVBomDetOvh.SetFocusedRowCellValue("price", bom_price)
                            FormBOMDesignSingle.GVBomDetOvh.SetFocusedRowCellValue("unit_price", bom_price)
                            FormBOMDesignSingle.GVBomDetOvh.SetFocusedRowCellValue("total", bom_price * component_qty)
                        Else
                            FormBOMDesignSingle.GVBomDetOvh.SetFocusedRowCellValue("price", bom_price)
                            FormBOMDesignSingle.GVBomDetOvh.SetFocusedRowCellValue("unit_price", bom_price * kurs)
                            FormBOMDesignSingle.GVBomDetOvh.SetFocusedRowCellValue("total", bom_price * component_qty * kurs)
                        End If
                        FormBOMDesignSingle.GVBomDetOvh.SetFocusedRowCellValue("is_ovh_main", is_ovh_main)
                        FormBOMDesignSingle.GVBomDetOvh.CloseEditor()
                        FormBOMDesignSingle.GCBomDetOvh.RefreshDataSource()
                        FormBOMDesignSingle.GVBomDetOvh.RefreshData()
                        FormBOMDesignSingle.show_but_ovh()
                        FormBOMDesignSingle.calculate_unit_price()
                        FormBOMDesignSingle.GVBomDetOvh.BestFitColumns()
                        Close()
                    End If
                End If
            ElseIf id_pop_up = "2" Then 'per design
                If id_ovh <> "-1" Then
                    'edit
                    Dim query_jml As String = String.Format("SELECT COUNT(id_bom_det) FROM tb_bom_det WHERE id_ovh_price='{0}' AND id_bom='{1}' AND id_bom_det !='{2}'", id_component_price, id_bom, id_bom_det)
                    Dim jml As Integer = execute_query(query_jml, 0, True, "", "", "", "")

                    If Not jml < 1 Then
                        errorDuplicate(" Overhead.")
                    Else
                        If is_ovh_main = "1" Then
                            query = String.Format("UPDATE tb_bom_det bom_d INNER JOIN tb_bom bom ON bom.id_bom=bom_d.id_bom SET bom_d.is_ovh_main='2' WHERE bom.id_bom_approve='{0}'", FormBOMSingle.id_bom_approve)
                            execute_non_query(query, True, "", "", "", "")
                        End If
                        query = String.Format("UPDATE tb_bom_det bom_d " +
                        "inner join tb_bom bom ON bom.id_bom=bom_d.id_bom " +
                        "inner join tb_m_ovh_price mop ON mop.id_ovh_price=bom_d.id_ovh_price " +
                        "SET bom_d.id_ovh_price='{0}',bom_d.kurs='{1}',bom_d.bom_price='{2}',bom_d.component_qty='{3}',bom_d.is_ovh_main='{4}' " +
                        "WHERE mop.id_ovh='{5}' and bom.id_bom_approve='{6}'", id_component_price, decimalSQL(kurs.ToString), decimalSQL(bom_price.ToString), decimalSQL(component_qty.ToString), is_ovh_main, id_ovh, FormBOMSingle.id_bom_approve)
                        execute_non_query(query, True, "", "", "", "")
                        'update who
                        query = String.Format("UPDATE tb_bom SET id_user_last_update='{0}',bom_date_updated=NOW() WHERE id_bom_approve='{1}'", id_user, FormBOMSingle.id_bom_approve)
                        execute_non_query(query, True, "", "", "", "")
                        'update ecop
                        query = String.Format("CALL update_bom_tot_app('{0}')", FormBOMSingle.id_bom_approve)
                        execute_non_query(query, True, "", "", "", "")
                        '
                        FormBOMSingle.act_load()
                        Close()
                    End If
                Else
                    'insert
                    Dim query_jml As String = String.Format("SELECT COUNT(id_bom_det) FROM tb_bom_det WHERE id_ovh_price='{0}' AND id_bom='{1}'", id_component_price, id_bom)
                    Dim jml As Integer = execute_query(query_jml, 0, True, "", "", "", "")
                    If Not jml < 1 Then
                        errorDuplicate(" Overhead.")
                    Else
                        If is_ovh_main = "1" Then
                            query = String.Format("UPDATE tb_bom_det bom_d INNER JOIN tb_bom bom ON bom.id_bom=bom_d.id_bom SET bom_d.is_ovh_main='2' WHERE bom.id_bom_approve='{0}'", FormBOMSingle.id_bom_approve)
                            execute_non_query(query, True, "", "", "", "")
                        End If
                        'insert
                        query = "INSERT INTO tb_bom_det(id_bom,id_component_category, id_ovh_price,kurs, bom_price, component_qty, is_cost,is_ovh_main)"
                        query += " Select id_bom,'" + id_component_category + "' As id_component_category,"
                        query += "'" + id_component_price + "' As id_ovh_price,"
                        query += "'" + decimalSQL(kurs.ToString) + "' AS kurs,"
                        query += "'" + decimalSQL(bom_price.ToString) + "' As bom_price,"
                        query += "'" + decimalSQL(component_qty.ToString) + "' As component_qty,"
                        query += "'1' As is_cost,"
                        query += "'" + is_ovh_main.ToString + "' As is_ovh_main"
                        query += " FROM tb_bom WHERE id_bom_approve='" + FormBOMSingle.id_bom_approve + "'"
                        execute_non_query(query, True, "", "", "", "")
                        'update who
                        query = String.Format("UPDATE tb_bom SET id_user_last_update='{0}',bom_date_updated=NOW() WHERE id_bom_approve='{1}'", id_user, FormBOMSingle.id_bom_approve)
                        execute_non_query(query, True, "", "", "", "")
                        'update ecop
                        query = String.Format("CALL update_bom_tot_app('{0}')", FormBOMSingle.id_bom_approve)
                        execute_non_query(query, True, "", "", "", "")
                        '
                        FormBOMSingle.act_load()
                        Close()
                    End If
                End If
            End If
        End If
    End Sub

    Private Sub GVOVHPrice_FocusedRowChanged(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles GVOVHPrice.FocusedRowChanged
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
        load_ovh_price()
    End Sub

    Private Sub TEPrice_EditValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TEPrice.EditValueChanged
        calculate()
    End Sub

    Private Sub GVOVH_ColumnFilterChanged(sender As Object, e As EventArgs) Handles GVOVH.ColumnFilterChanged
        If GVOVH.RowCount > 0 Then
            view_ovh_price(GVOVH.GetFocusedRowCellValue("id_ovh"))
        End If
    End Sub
End Class