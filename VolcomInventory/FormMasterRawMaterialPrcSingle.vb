Public Class FormMasterRawMaterialPrcSingle
    Public action As String
    Public id_mat_det_price As String
    Public is_can_edit_cost As Boolean = True
    Public is_can_edit_bulk As Boolean = True
    Public is_can_edit_price As Boolean = True
    'Form Load
    Private Sub FormRawMaterialPrcSingle_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim def_dec As Decimal = 0.0
        TxtPrice.EditValue = def_dec
        TEQtyinBulk.EditValue = 1.0
        '
        TEUnit.Text = "pcs"
        '
        viewVendor()
        viewVendorContact()
        viewCurrency()
        actionLoad()
        '
        If is_can_edit_bulk Then
            TEQtyinBulk.Enabled = True
            TEUnit.Enabled = True
        Else
            TEQtyinBulk.Enabled = False
            TEUnit.Enabled = False
        End If

        If is_can_edit_cost Then
            TEQtyinBulk.Enabled = True
            TEUnit.Enabled = True
        Else
            TEQtyinBulk.Enabled = False
            TEUnit.Enabled = False
        End If

        If Not is_can_edit_price Then
            LECurrency.Enabled = False
            TxtPrice.Enabled = False
            TxtPriceName.Enabled = False
            SLEVendor.Enabled = False
            SLEVendorContact.Enabled = False
        End If
    End Sub
    'ActionLoad
    Private Sub actionLoad()
        If action = "upd" Then
            Dim query As String = "SELECT * FROM tb_m_mat_det_price a "
            query += "INNER JOIN tb_m_comp_contact b ON a.id_comp_contact = b.id_comp_contact "
            query += "INNER JOIN tb_m_comp c ON b.id_comp = c.id_comp "
            query += "WHERE a.id_mat_det_price = '" + FormMasterRawMaterialDetSingle.GVPrice.GetFocusedRowCellDisplayText("id_mat_det_price") + "' "
            Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
            SLEVendor.EditValue = data.Rows(0)("id_comp").ToString
            SLEVendorContact.EditValue = data.Rows(0)("id_comp_contact").ToString
            LECurrency.ItemIndex = LECurrency.Properties.GetDataSourceRowIndex("id_currency", data.Rows(0)("id_currency").ToString)
            TxtPriceName.Text = data.Rows(0)("mat_det_price_name").ToString
            TxtPrice.Text = data.Rows(0)("mat_det_price").ToString
            TEQtyinBulk.EditValue = data.Rows(0)("min_qty_in_bulk")
            TEUnit.Text = data.Rows(0)("bulk_unit").ToString
            TEMOQ.EditValue = data.Rows(0)("moq")
        End If
    End Sub
    'Form Closed
    Private Sub FormRawMaterialPrcSingle_FormClosed(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub
    'Btn Cancel
    Private Sub BtnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCancel.Click
        Close()
    End Sub
    'View Vendor
    Sub viewVendor()
        Dim query As String = "SELECT *, CONCAT_WS('-', a.comp_number, a.comp_name) AS vendor_select FROM tb_m_comp a "
        query += "INNER JOIN tb_m_comp_cat b ON a.id_comp_cat = b.id_comp_cat "
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
    'Value Change comp
    Private Sub SLEVendor_EditValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SLEVendor.EditValueChanged
        viewVendorContact()
    End Sub
    'Validating Price Name
    Private Sub TxtPriceName_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TxtPriceName.Validating
        EP_TE_cant_blank(EPPrice, TxtPriceName)
    End Sub
    'Btn Save 
    Private Sub BtnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSave.Click
        ValidateChildren()
        If Not formIsValid(EPPrice) Then
            errorInput()
        Else
            Dim query As String
            Dim id_mat_det As String = FormMasterRawMaterialDetSingle.id_mat_det
            Dim id_comp_contact As String = SLEVendorContact.EditValue
            Dim mat_det_price_name As String = addSlashes(TxtPriceName.Text)
            Dim mat_det_price As String = TxtPrice.EditValue
            Dim id_currency As String = LECurrency.EditValue
            Dim qty_bulk As String = decimalSQL(TEQtyinBulk.EditValue.ToString)
            Dim moq As String = decimalSQL(TEMOQ.EditValue.ToString)
            Dim bulk_unit As String = addSlashes(TEUnit.Text)
            If action = "ins" Then
                Try
                    query = "INSERT INTO tb_m_mat_det_price(id_mat_det, id_comp_contact, mat_det_price_name, mat_det_price, mat_det_price_date, id_currency, min_qty_in_bulk, bulk_unit, moq) "
                    query += "VALUES('{0}', '{1}', '{2}', '{3}', DATE(NOW()), '{4}','{5}','{6}','{7}')"
                    query = String.Format(query, id_mat_det, id_comp_contact, mat_det_price_name, decimalSQL(mat_det_price.ToString), id_currency, qty_bulk, bulk_unit, moq)
                    execute_non_query(query, True, "", "", "", "")
                    logData("tb_m_mat", 1)
                    FormMasterRawMaterialDetSingle.viewPrice()
                    Close()
                Catch ex As Exception
                    errorConnection()
                    Close()
                End Try
            ElseIf action = "upd" Then
                Try
                    query = "UPDATE tb_m_mat_det_price SET id_mat_det ='{0}', id_comp_contact='{1}', "
                    query += "mat_det_price_name = '{2}', mat_det_price = '{3}', id_currency = '{4}',min_qty_in_bulk='{6}',bulk_unit='{7}',moq='{8}' WHERE id_mat_det_price = '{5}' "
                    query = String.Format(query, id_mat_det, id_comp_contact, mat_det_price_name, decimalSQL(mat_det_price.ToString), id_currency, id_mat_det_price, qty_bulk, bulk_unit, moq)
                    execute_non_query(query, True, "", "", "", "")
                    logData("tb_m_mat", 2)
                    FormMasterRawMaterialDetSingle.viewPrice()
                    Close()
                Catch ex As Exception
                    errorConnection()
                    Close()
                End Try
            End If
        End If
    End Sub
End Class