Public Class FormSampleWO
    Public id_sample_wo As String = "-1"
    Public id_sample_purc As String = "-1"

    Public id_comp_to As String = "-1"
    Public id_comp_ship_to As String = "-1"
    Private Sub FormSampleWO_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        view_currency(LECurrency)
        view_payment_type(LEpayment)

        Dim default_kurs As Decimal = 1.0
        TEKurs.EditValue = default_kurs
        '
        TEReffPO.Text = FormSamplePurchaseDet.TEPONumber.Text
        '
        load_wo()

        If id_sample_wo = "-1" Then
            'new
            TECompCode.Text = FormSamplePurchaseDet.TECompCode.Text
            TECompName.Text = FormSamplePurchaseDet.TECompName.Text
            TECompAttn.Text = FormSamplePurchaseDet.TECompAttn.Text
            MECompAddress.Text = FormSamplePurchaseDet.MECompAddress.Text
            id_comp_to = FormSamplePurchaseDet.id_comp_to
            '
            TECompShipTo.Text = FormSamplePurchaseDet.TECompShipTo.Text
            TECompShipToName.Text = FormSamplePurchaseDet.TECompShipToName.Text
            MECompShipToAddress.Text = FormSamplePurchaseDet.MECompShipToAddress.Text
            id_comp_ship_to = FormSamplePurchaseDet.id_comp_ship_to
            '
            TEDate.Text = view_date(0)
            TERecDate.Text = view_date(0)
            TEDueDate.Text = view_date(0)
            TEPONumber.Text = header_number("22")

            load_item()
        Else
            'edit
            Dim query As String = "SELECT * FROM tb_sample_wo WHERE id_sample_wo='" & id_sample_wo & "'"
            Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
            '
            TECompCode.Text = FormSamplePurchaseDet.TECompCode.Text
            TECompName.Text = FormSamplePurchaseDet.TECompName.Text
            TECompAttn.Text = FormSamplePurchaseDet.TECompAttn.Text
            id_comp_to = FormSamplePurchaseDet.id_comp_to
            '
            TECompShipTo.Text = FormSamplePurchaseDet.TECompShipTo.Text
            TECompShipToName.Text = FormSamplePurchaseDet.TECompShipToName.Text
            id_comp_ship_to = FormSamplePurchaseDet.id_comp_ship_to
        End If
        '
    End Sub
    Sub load_wo()
        Dim query As String = "CALL view_sample_wo_det(" & id_sample_wo & ")"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")

        GCListPurchase.DataSource = data

    End Sub
    Sub load_item()
        For i As Integer = 0 To FormSamplePurchaseDet.GVListPurchase.RowCount - 1
            Dim newRow As DataRow = (TryCast(GCListPurchase.DataSource, DataTable)).NewRow()
            newRow("id_sample_price") = FormSamplePurchaseDet.GVListPurchase.GetRowCellValue(0, "id_sample_price")
            newRow("name") = FormSamplePurchaseDet.GVListPurchase.GetRowCellValue(0, "name")
            newRow("code") = FormSamplePurchaseDet.GVListPurchase.GetRowCellValue(0, "code")
            newRow("color") = FormSamplePurchaseDet.GVListPurchase.GetRowCellValue(0, "color")
            newRow("size") = FormSamplePurchaseDet.GVListPurchase.GetRowCellValue(0, "size")
            newRow("price") = 0.00
            newRow("qty") = 1
            newRow("discount") = 0.00
            newRow("tot_discount") = 0.00
            newRow("note") = FormSamplePurchaseDet.GVListPurchase.GetRowCellValue(0, "note")

            TryCast(GCListPurchase.DataSource, DataTable).Rows.Add(newRow)
            GCListPurchase.RefreshDataSource()
        Next

        'FormSamplePurchaseDet.calculate()
        'FormSamplePurchaseDet.show_but()
    End Sub
    Private Sub view_currency(ByVal lookup As DevExpress.XtraEditors.LookUpEdit)
        Dim query As String = "SELECT id_currency,currency FROM tb_lookup_currency"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")

        lookup.Properties.DataSource = data

        lookup.Properties.DisplayMember = "currency"
        lookup.Properties.ValueMember = "id_currency"
        lookup.ItemIndex = 0
    End Sub
    Private Sub view_payment_type(ByVal lookup As DevExpress.XtraEditors.LookUpEdit)
        Dim query As String = "SELECT id_payment,payment FROM tb_lookup_payment"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")

        lookup.Properties.DataSource = data

        lookup.Properties.DisplayMember = "payment"
        lookup.Properties.ValueMember = "id_payment"
        lookup.ItemIndex = 0
    End Sub
    Private Sub view_po_status(ByVal lookup As DevExpress.XtraEditors.LookUpEdit)
        Dim query As String = "SELECT id_status_doc,status_doc FROM tb_lookup_status_doc"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")

        lookup.Properties.DataSource = data

        lookup.Properties.DisplayMember = "status_doc"
        lookup.Properties.ValueMember = "id_status_doc"
        lookup.ItemIndex = 0
    End Sub
    Private Sub GVListPurchase_CustomColumnDisplayText(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs) Handles GVListPurchase.CustomColumnDisplayText
        If e.Column.FieldName = "no" Then
            e.DisplayText = (e.ListSourceRowIndex + 1).ToString()
        End If
    End Sub
End Class