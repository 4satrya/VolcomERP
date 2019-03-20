Public Class FormSamplePriceSingle
    Public id_sample_price As String = "-1"
    Public id_sample As String = "-1"

    Private Sub TEPrice_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TEPrice.Validating
        EP_TE_cant_blank(EPSamplePrice, TEPrice)
    End Sub

    Private Sub TEPriceName_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TEPriceName.Validating
        EP_TE_cant_blank(EPSamplePrice, TEPriceName)
    End Sub

    Private Sub FormSamplePriceSingle_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        load_company(LEVendor)
        view_currency(LECurrency)

        If Not id_sample_price = "-1" Then
            Dim query As String = String.Format("SELECT * FROM tb_m_sample_price WHERE id_sample_price = '{0}'", id_sample_price)
            Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")

            Dim id_company As String = get_id_company(data.Rows(0)("id_comp_contact").ToString)

            TEPriceName.Text = data.Rows(0)("sample_price_name").ToString
            TEPrice.Text = data.Rows(0)("sample_price").ToString

            LECurrency.EditValue = Nothing
            LECurrency.ItemIndex = LECurrency.Properties.GetDataSourceRowIndex("id_currency", data.Rows(0)("id_currency").ToString)

            load_company(LEVendor)
            LEVendor.EditValue = id_company
            load_contact(LEVendorContact, LEVendor.EditValue)
            LEVendorContact.EditValue = data.Rows(0)("id_comp_contact").ToString
        End If
    End Sub

    Sub load_company(ByVal lookup As DevExpress.XtraEditors.SearchLookUpEdit)
        Dim query As String = getQueryVendorSimple()
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")

        lookup.Properties.DataSource = Nothing
        lookup.Properties.DataSource = data

        lookup.Properties.DisplayMember = "comp_name"
        lookup.Properties.ValueMember = "id_comp"
        lookup.EditValue = data.Rows(0)("id_comp").ToString
        load_contact(LEVendorContact, LEVendor.EditValue.ToString)
    End Sub
    Sub load_contact(ByVal lookup As DevExpress.XtraEditors.SearchLookUpEdit, ByVal id_vendor As String)
        Dim query As String = "SELECT id_comp_contact,contact_person FROM tb_m_comp_contact WHERE id_comp='" & id_vendor & "' ORDER BY is_default ASC"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")

        lookup.Properties.DataSource = Nothing
        lookup.Properties.DataSource = data

        lookup.Properties.DisplayMember = "contact_person"
        lookup.Properties.ValueMember = "id_comp_contact"
        lookup.EditValue = data.Rows(0)("id_comp_contact").ToString
    End Sub

    Private Sub BSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BSave.Click
        Dim id_comp_contact, sample_price, sample_price_name, query, id_currency As String

        ValidateChildren()

        id_comp_contact = LEVendorContact.EditValue.ToString
        id_currency = LECurrency.EditValue.ToString
        sample_price = TEPrice.EditValue
        sample_price_name = TEPriceName.Text

        If Not id_sample_price = "-1" Then
            'update
            If id_comp_contact = "" Or Not formIsValid(EPSamplePrice) Then
                errorInput()
            Else
                query = String.Format("UPDATE tb_m_sample_price SET sample_price_name='{0}',sample_price='{1}',sample_price_date=DATE(NOW()),id_comp_contact='{2}',id_currency='{3}' WHERE id_sample_price='{4}'", sample_price_name, decimalSQL(sample_price.ToString), id_comp_contact, id_currency, id_sample_price)
                execute_non_query(query, True, "", "", "", "")
                FormMasterSampleDet.view_sample_price(id_sample)
                Close()
                Dispose()
            End If
        Else
            'insert
            If id_comp_contact = "" Or Not formIsValid(EPSamplePrice) Then
                errorInput()
            Else
                query = String.Format("INSERT INTO tb_m_sample_price(id_sample,sample_price_name,sample_price,sample_price_date,id_comp_contact,id_currency) VALUES('{0}','{1}','{2}',DATE(NOW()),'{3}',{4})", id_sample, sample_price_name, decimalSQL(sample_price.ToString), id_comp_contact, id_currency)
                execute_non_query(query, True, "", "", "", "")
                FormMasterSampleDet.view_sample_price(id_sample)
                Close()
                Dispose()
            End If
        End If
    End Sub
    Private Sub view_currency(ByVal lookup As DevExpress.XtraEditors.LookUpEdit)
        Dim query As String = "SELECT id_currency,currency FROM tb_lookup_currency WHERE is_active_sample='1'"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")

        lookup.Properties.DataSource = data

        lookup.Properties.DisplayMember = "currency"
        lookup.Properties.ValueMember = "id_currency"
        lookup.ItemIndex = 0
    End Sub
    Private Sub LEVendor_EditValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LEVendor.EditValueChanged
        load_contact(LEVendorContact, LEVendor.EditValue.ToString)
    End Sub
End Class