Public Class FormMasterOVHPrcSingle 
    Public action As String
    Public id_ovh_price As String
    'Form Load
    Private Sub FormMasterOVHPrcSingle_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        viewVendor()
        viewVendorContact()
        viewCurrency()
        actionLoad()
    End Sub
    'ActionLoad
    Private Sub actionLoad()
        If action = "upd" Then
            Dim query As String = "SELECT * FROM tb_m_ovh_price a "
            query += "INNER JOIN tb_m_comp_contact b ON a.id_comp_contact = b.id_comp_contact "
            query += "INNER JOIN tb_m_comp c ON b.id_comp = c.id_comp "
            query += "INNER JOIN tb_lookup_currency d ON a.id_currency = d.id_currency "
            query += "WHERE a.id_ovh_price = '" + FormMasterOVHSingle.GVPrice.GetFocusedRowCellDisplayText("id_ovh_price") + "' "
            Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
            SLEVendor.EditValue = data.Rows(0)("id_comp").ToString
            SLEVendorContact.EditValue = data.Rows(0)("id_comp_contact").ToString
            LECurrency.ItemIndex = LECurrency.Properties.GetDataSourceRowIndex("id_currency", data.Rows(0)("id_currency").ToString)
            TxtPriceName.Text = data.Rows(0)("ovh_price_name").ToString
            TxtPrice.Text = data.Rows(0)("ovh_price").ToString
        End If
    End Sub
    'View Vendor
    Sub viewVendor()
        Dim query As String = "SELECT *, CONCAT_WS('-', a.comp_number, a.comp_name) AS vendor_select FROM tb_m_comp a "
        query += "INNER JOIN tb_m_comp_cat b ON a.id_comp_cat = b.id_comp_cat AND b.id_comp_cat='1' "
        query += "ORDER BY comp_number ASC"
        viewSearchLookupQuery(SLEVendor, query, "id_comp", "vendor_select", "id_comp")
    End Sub
    'View Vendor Contact
    Sub viewVendorContact()
        Dim id_comp As String = SLEVendor.EditValue
        Dim query As String = "SELECT * FROM tb_m_comp_contact a WHERE a.id_comp = '" + id_comp + "' ORDER BY a.is_default ASC"
        viewSearchLookupQuery(SLEVendorContact, query, "id_comp_contact", "contact_person", "id_comp_contact")
    End Sub
    'View Currency
    Sub viewCurrency()
        Dim query As String = "SELECT * FROM tb_lookup_currency ORDER BY id_currency "
        viewLookupQuery(LECurrency, query, 0, "currency", "id_currency")
    End Sub
    'Form Closed
    Private Sub FormMasterOVHPrcSingle_FormClosed(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub
    'Cancel Button
    Private Sub BtnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCancel.Click
        Close()
    End Sub
    'Save Buttton
    Private Sub BtnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSave.Click
        ValidateChildren()
        ValidateChildren()
        If Not formIsValid(EPPrice) Then
            errorInput()
        Else
            Dim query As String
            Dim id_ovh As String = FormMasterOVHSingle.id_ovh
            Dim id_comp_contact As String = SLEVendorContact.EditValue
            Dim ovh_price_name As String = addSlashes(TxtPriceName.Text)
            Dim ovh_price As String = decimalSQL(TxtPrice.EditValue.ToString)
            Dim id_currency As String = LECurrency.EditValue
            If action = "ins" Then
                Try
                    query = "INSERT INTO tb_m_ovh_price(id_ovh, id_comp_contact, ovh_price_name, ovh_price, id_currency, ovh_price_date) "
                    query += "VALUES('{0}', '{1}', '{2}', '{3}','{4}', DATE(NOW()))"
                    query = String.Format(query, id_ovh, id_comp_contact, ovh_price_name, ovh_price, id_currency)
                    execute_non_query(query, True, "", "", "", "")
                    logData("tb_m_ovh_price", 1)
                    FormMasterOVHSingle.viewPrice()
                    Close()
                Catch ex As Exception
                    errorConnection()
                    Close()
                End Try
            ElseIf action = "upd" Then
                Try
                    query = "UPDATE tb_m_ovh_price SET id_ovh ='{0}', id_comp_contact='{1}', "
                    query += "ovh_price_name = '{2}', ovh_price = '{3}', id_currency = '{4}' WHERE id_ovh_price = '{5}' "
                    query = String.Format(query, id_ovh, id_comp_contact, ovh_price_name, ovh_price, id_currency, id_ovh_price)
                    execute_non_query(query, True, "", "", "", "")
                    logData("tb_m_ovh_price", 2)
                    FormMasterOVHSingle.viewPrice()
                    Close()
                Catch ex As Exception
                    errorConnection()
                    Close()
                End Try
            End If
        End If
    End Sub
    'Validating Price Name
    Private Sub TxtPriceName_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TxtPriceName.Validating
        EP_TE_cant_blank(EPPrice, TxtPriceName)
    End Sub
    'Validating Price
    Private Sub TxtPrice_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TxtPrice.Validating
        'EP_TE_must_decimal(EPPrice, TxtPrice)
    End Sub
    'Value Changed
    Private Sub SLEVendor_EditValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SLEVendor.EditValueChanged
        viewVendorContact()
    End Sub
End Class