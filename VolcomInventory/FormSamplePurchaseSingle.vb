Public Class FormSamplePurchaseSingle
    Public id_sample_purc_det As String = "-1"
    Public id_sample_price As String = "-1"
    Public id_sample_purc As String = "-1"
    Dim sample_image_path As String = get_setup_field("pic_path_sample") & "\"
    Public filter_string As String = ""
    Private Sub FormSamplePurchaseSingle_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        view_currency(LECurrency)
        LECurrency.EditValue = Nothing
        LECurrency.ItemIndex = LECurrency.Properties.GetDataSourceRowIndex("id_currency", FormSamplePurchaseDet.LECurrency.EditValue)

        TEKurs.EditValue = FormSamplePurchaseDet.TEKurs.EditValue
        view_sample()
    End Sub

    Sub view_sample()
        Try
            Dim query As String
            query = "CALL view_sample_single(" & FormSamplePurchaseDet.id_comp_to.ToString & ")"
            Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
            GCSample.DataSource = data

            If Not data.Rows.Count < 1 Then
                If id_sample_price <> "-1" Then
                    '
                    Dim id_sample As String
                    id_sample = get_id_sample_f_id_price(id_sample_price)
                    GVSample.FocusedRowHandle = find_row(GVSample, "id_sample", id_sample)
                    '
                End If
                'add filter division 
                If Not filter_string = "" Then
                    filter_string = " AND (" & filter_string & ")"
                End If
                '
                GVSample.ActiveFilterString = "[id_season_orign] = '" & FormSamplePurchaseDet.LESeason.EditValue.ToString & "' " & filter_string
                view_image()
                view_sample_price(GVSample.GetFocusedRowCellDisplayText("id_sample").ToString)
            End If
        Catch ex As Exception
            errorConnection()
        End Try
    End Sub
    Sub view_image()
        If System.IO.File.Exists(sample_image_path & GVSample.GetFocusedRowCellDisplayText("id_sample").ToString & ".jpg") Then
            PictureEdit1.LoadAsync(sample_image_path & GVSample.GetFocusedRowCellDisplayText("id_sample").ToString & ".jpg")
        Else
            PictureEdit1.LoadAsync(sample_image_path & "default" & ".jpg")
        End If
    End Sub
    Sub view_sample_price(ByVal id_samplex As String)
        Dim query As String = "SELECT tb_lookup_currency.currency,tb_m_sample_price.id_sample_price,tb_m_sample_price.sample_price_name,tb_m_sample_price.sample_price,tb_m_sample_price.sample_price_date FROM tb_m_sample_price,tb_lookup_currency WHERE tb_m_sample_price.id_currency=tb_lookup_currency.id_currency AND tb_m_sample_price.id_sample='" & id_samplex & "' ORDER BY tb_m_sample_price.id_sample_price DESC"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCSamplePrice.DataSource = data
        GVSamplePrice.BestFitColumns()

        If id_sample_price <> "-1" Then
            If Not data.Rows.Count < 1 Then
                GroupControlDetail.Enabled = True
                PanelControlButton.Enabled = True
                '
                GVSamplePrice.FocusedRowHandle = find_row(GVSamplePrice, "id_sample_price", id_sample_price)

                TEQty.EditValue = FormSamplePurchaseDet.GVListPurchase.GetFocusedRowCellValue("qty")
                TEDiscount.EditValue = FormSamplePurchaseDet.GVListPurchase.GetFocusedRowCellValue("discount")
                TENote.Text = FormSamplePurchaseDet.GVListPurchase.GetFocusedRowCellValue("note").ToString
                load_sample_price()
                '
            Else
                GroupControlDetail.Enabled = False
                PanelControlButton.Enabled = False
            End If
        Else
            If Not data.Rows.Count < 1 Then
                GroupControlDetail.Enabled = True
                PanelControlButton.Enabled = True
                load_sample_price()
            Else
                GroupControlDetail.Enabled = False
                PanelControlButton.Enabled = False
            End If
        End If
    End Sub
    Sub load_sample_price()
        TEVendCur.Text = GVSamplePrice.GetFocusedRowCellDisplayText("currency").ToString
        TEVendPrice.EditValue = GVSamplePrice.GetFocusedRowCellValue("sample_price")
        TEUOM.Text = GVSample.GetFocusedRowCellDisplayText("uom").ToString

        calculate()
    End Sub

    Sub calculate()
        Try
            Dim price_kurs, price_tot As Decimal

            If TEVendPrice.EditValue = 0 Or TEKurs.EditValue = 0 Then
                TEPrice.EditValue = 0
            Else
                'price_kurs = TEVendPrice.EditValue * TEKurs.EditValue
                price_kurs = TEVendPrice.EditValue
                TEPrice.EditValue = price_kurs
            End If
            If TEPrice.EditValue = 0 Or TEQty.EditValue = 0 Then
                TEPriceTot.EditValue = 0
            Else
                price_tot = (Decimal.Parse(TEPrice.EditValue) - Decimal.Parse(TEDiscount.EditValue)) * Decimal.Parse(TEQty.EditValue)
                TEPriceTot.EditValue = price_tot
            End If
        Catch ex As Exception
        End Try
    End Sub
    Private Sub view_currency(ByVal lookup As DevExpress.XtraEditors.LookUpEdit)
        Dim query As String = "SELECT id_currency,currency FROM tb_lookup_currency"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")

        lookup.Properties.DataSource = data

        lookup.Properties.DisplayMember = "currency"
        lookup.Properties.ValueMember = "id_currency"
        lookup.ItemIndex = 0
    End Sub

    Private Sub GVSample_FocusedRowChanged(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles GVSample.FocusedRowChanged
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

    Private Sub GVSamplePrice_FocusedRowChanged(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles GVSamplePrice.FocusedRowChanged
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

    Private Sub GVSamplePrice_RowClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Grid.RowClickEventArgs) Handles GVSamplePrice.RowClick
        load_sample_price()
    End Sub

    Private Sub GVSample_RowClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Grid.RowClickEventArgs) Handles GVSample.RowClick
        view_image()
        view_sample_price(GVSample.GetFocusedRowCellDisplayText("id_sample").ToString)
    End Sub

    Private Sub TEKurs_EditValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TEKurs.EditValueChanged
        calculate()
    End Sub

    Private Sub TEQty_EditValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TEQty.EditValueChanged
        calculate()
    End Sub

    Private Sub TEDiscount_EditValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TEDiscount.EditValueChanged
        calculate()
    End Sub

    Private Sub BSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BSave.Click
        Dim id_price, price, qty, discount, error_text, note As String
        error_text = "-1"
        '
        id_price = "0"
        price = "0"
        qty = "0"
        discount = "0"
        note = ""
        '
        Try
            id_price = GVSamplePrice.GetFocusedRowCellDisplayText("id_sample_price").ToString
            If id_price = "" Then
                error_text = "1"
            End If
            price = TEPrice.EditValue
            qty = TEQty.EditValue
            discount = TEDiscount.EditValue
            note = TENote.Text
        Catch ex As Exception
            error_text = "1"
        End Try

        If error_text <> "-1" Then
            'ada error
            errorInput()
        Else
            'check dupe
            Dim already = False
            If FormSamplePurchaseDet.GVListPurchase.RowCount > 0 Then
                For i As Integer = 0 To FormSamplePurchaseDet.GVListPurchase.RowCount - 1
                    If FormSamplePurchaseDet.GVListPurchase.GetRowCellValue(i, "id_sample_price").ToString = id_price And Not id_price = id_sample_price Then
                        already = True
                    End If
                Next
            End If

            If already = True Then
                stopCustom("This sample already on list.")
            Else
                If id_sample_price <> "-1" Then
                    'edit
                    FormSamplePurchaseDet.GVListPurchase.SetRowCellValue(FormSamplePurchaseDet.GVListPurchase.FocusedRowHandle, "id_sample_price", id_price)
                    FormSamplePurchaseDet.GVListPurchase.SetRowCellValue(FormSamplePurchaseDet.GVListPurchase.FocusedRowHandle, "name", GVSample.GetFocusedRowCellDisplayText("sample_name").ToString)
                    FormSamplePurchaseDet.GVListPurchase.SetRowCellValue(FormSamplePurchaseDet.GVListPurchase.FocusedRowHandle, "code", GVSample.GetFocusedRowCellDisplayText("sample_us_code").ToString)
                    FormSamplePurchaseDet.GVListPurchase.SetRowCellValue(FormSamplePurchaseDet.GVListPurchase.FocusedRowHandle, "color", GVSample.GetFocusedRowCellDisplayText("Color").ToString)
                    FormSamplePurchaseDet.GVListPurchase.SetRowCellValue(FormSamplePurchaseDet.GVListPurchase.FocusedRowHandle, "size", GVSample.GetFocusedRowCellDisplayText("Size").ToString)
                    FormSamplePurchaseDet.GVListPurchase.SetRowCellValue(FormSamplePurchaseDet.GVListPurchase.FocusedRowHandle, "price", TEPrice.EditValue)
                    FormSamplePurchaseDet.GVListPurchase.SetRowCellValue(FormSamplePurchaseDet.GVListPurchase.FocusedRowHandle, "qty", TEQty.EditValue)
                    FormSamplePurchaseDet.GVListPurchase.SetRowCellValue(FormSamplePurchaseDet.GVListPurchase.FocusedRowHandle, "discount", TEDiscount.EditValue)
                    FormSamplePurchaseDet.GVListPurchase.SetRowCellValue(FormSamplePurchaseDet.GVListPurchase.FocusedRowHandle, "tot_discount", TEDiscount.EditValue * TEQty.EditValue)
                    FormSamplePurchaseDet.GVListPurchase.SetRowCellValue(FormSamplePurchaseDet.GVListPurchase.FocusedRowHandle, "total", TEPriceTot.EditValue)
                    FormSamplePurchaseDet.GVListPurchase.SetRowCellValue(FormSamplePurchaseDet.GVListPurchase.FocusedRowHandle, "note", note)
                    FormSamplePurchaseDet.GCListPurchase.RefreshDataSource()
                    FormSamplePurchaseDet.calculate()
                    FormSamplePurchaseDet.show_but()
                    Close()
                Else
                    'insert
                    Dim newRow As DataRow = (TryCast(FormSamplePurchaseDet.GCListPurchase.DataSource, DataTable)).NewRow()
                    newRow("id_sample_price") = id_price
                    newRow("name") = GVSample.GetFocusedRowCellDisplayText("sample_name").ToString
                    newRow("code") = GVSample.GetFocusedRowCellDisplayText("sample_us_code").ToString
                    newRow("color") = GVSample.GetFocusedRowCellDisplayText("Color").ToString
                    newRow("size") = GVSample.GetFocusedRowCellDisplayText("Size").ToString
                    newRow("price") = TEPrice.EditValue
                    newRow("qty") = TEQty.EditValue
                    newRow("discount") = TEDiscount.EditValue
                    newRow("tot_discount") = TEQty.EditValue * TEDiscount.EditValue
                    newRow("total") = TEPriceTot.EditValue
                    newRow("note") = TENote.Text

                    TryCast(FormSamplePurchaseDet.GCListPurchase.DataSource, DataTable).Rows.Add(newRow)
                    FormSamplePurchaseDet.GCListPurchase.RefreshDataSource()
                    FormSamplePurchaseDet.calculate()
                    FormSamplePurchaseDet.show_but()
                    Close()
                End If
            End If
        End If
    End Sub

    Private Sub FormSamplePurchaseSingle_FormClosed(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub BView_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BView.Click
        Try
            If System.IO.File.Exists(sample_image_path & GVSample.GetFocusedRowCellDisplayText("id_sample").ToString & ".jpg") Then
                Process.Start(sample_image_path & GVSample.GetFocusedRowCellDisplayText("id_sample").ToString & ".jpg")
            Else
                Process.Start(sample_image_path & "default" & ".jpg")
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub Brefresh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Brefresh.Click
        If GVSample.RowCount > 0 Then
            view_sample_price(GVSample.GetFocusedRowCellValue("id_sample").ToString)
        End If
    End Sub

    Private Sub BPrice_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BPrice.Click
        If GVSample.RowCount > 0 Then
            FormMasterSampleDet.id_sample = GVSample.GetFocusedRowCellValue("id_sample").ToString
            FormMasterSampleDet.XTPGeneral.PageVisible = False
            FormMasterSampleDet.XTPNote.PageVisible = False
            FormMasterSampleDet.ShowDialog()
        End If
    End Sub
End Class