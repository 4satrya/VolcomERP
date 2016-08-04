Public Class FormSampleWO
    Private Sub FormSampleWO_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        view_currency(LECurrency)
        view_payment_type(LEpayment)

        Dim default_kurs As Decimal = 1.0
        TEKurs.EditValue = default_kurs
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
End Class