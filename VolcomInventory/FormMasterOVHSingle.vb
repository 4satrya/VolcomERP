Public Class FormMasterOVHSingle
    Public id_ovh As String
    '-------------GENERAL------------------------
    Private Sub FormMasterOVHSingle_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        viewUOM()
        viewOVHCat()
        If id_ovh <> "-1" Then
            'edit
            Dim query As String = String.Format("SELECT * FROM tb_m_ovh WHERE id_ovh = '{0}'", id_ovh)
            Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
            LabelDetailMaterial.Text = "Overhead : " + data.Rows(0)("overhead")
            'Parse String
            Dim overhead_code As String = data.Rows(0)("overhead_code").ToString
            Dim overhead As String = data.Rows(0)("overhead").ToString
            TEOVH.Text = overhead
            TEOVHCode.Text = overhead_code

            LEUOM.ItemIndex = LEUOM.Properties.GetDataSourceRowIndex("id_uom", data.Rows(0)("id_uom").ToString)

            LEOVHCat.ItemIndex = LEOVHCat.Properties.GetDataSourceRowIndex("id_ovh_cat", data.Rows(0)("id_ovh_cat").ToString)

            'Page Price
            XTPPrice.PageVisible = True
            viewPrice()
        Else
            LabelDetailMaterial.Text = "Add New Overhead"
        End If
    End Sub
    'View LookUp UOM
    Sub viewUOM()
        Dim query As String = "SELECT * FROM tb_m_uom a ORDER BY uom ASC"
        viewLookupQuery(LEUOM, query, 0, "uom", "id_uom")
    End Sub
    Sub viewOVHCat()
        Dim query As String = "SELECT * FROM tb_m_ovh_cat a ORDER BY ovh_cat ASC"
        viewLookupQuery(LEOVHCat, query, 0, "ovh_cat", "id_ovh_cat")
    End Sub
    Private Sub BtnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCancel.Click
        Close()
    End Sub
    Private Sub TEOVHCode_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs)
        validatingCodeOVH()
    End Sub
    Sub validatingCodeOVH()
        Dim query_jml As String
        If id_ovh = "-1" Then
            'new
            query_jml = String.Format("SELECT COUNT(id_ovh) FROM tb_m_ovh WHERE overhead_code='{0}'", TEOVHCode.Text)
        Else
            query_jml = String.Format("SELECT COUNT(id_ovh) FROM tb_m_ovh WHERE overhead_code='{0}' AND id_ovh!='{1}'", TEOVHCode.Text, id_ovh)
        End If

        Dim jml As Integer = execute_query(query_jml, 0, True, "", "", "", "")
        If Not jml < 1 Then
            EP_TE_already_used(ErrorProviderOVH, TEOVHCode, "1")
        Else
            EP_TE_cant_blank(ErrorProviderOVH, TEOVHCode)
        End If
    End Sub
    Private Sub TEOVH_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs)
        EP_TE_cant_blank(ErrorProviderOVH, TEOVH)
    End Sub

    Private Sub BtnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSave.Click
        Dim query As String
        Dim overhead As String = TEOVH.Text
        Dim overhead_code As String = TEOVHCode.Text
        Dim id_uom As String = LEUOM.EditValue
        validatingCodeOVH()
        EP_TE_cant_blank(ErrorProviderOVH, TEOVH)

        If id_ovh = "-1" Then
            'new
            If Not formIsValidInPanel(ErrorProviderOVH, PCGeneral) Then
                errorInput()
            Else
                query = String.Format("INSERT INTO tb_m_ovh(overhead_code,overhead, id_uom,id_ovh_cat) VALUES('{0}','{1}', '{2}','{3}')", overhead_code, overhead, id_uom, LEOVHCat.EditValue.ToString)
                execute_non_query(query, True, "", "", "", "")
                logData("tb_m_ovh", 1)
                FormMasterOVH.view_ovh()
                Close()
            End If
        Else
            'new
            If Not formIsValidInPanel(ErrorProviderOVH, PCGeneral) Then
                errorInput()
            Else
                query = String.Format("UPDATE tb_m_ovh SET overhead_code='{0}',overhead='{1}', id_uom='" + id_uom + "', id_ovh_cat='" + LEOVHCat.EditValue.ToString + "' WHERE id_ovh='{2}'", overhead_code, overhead, id_ovh)
                execute_non_query(query, True, "", "", "", "")
                logData("tb_m_ovh", 2)
                FormMasterOVH.view_ovh()
                Close()
            End If
        End If
    End Sub
    Private Sub FormMasterOVHSingle_FormClosed(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub
    '---------PRICE------------------
    Sub viewPrice()
        Try
            Dim query As String = "SELECT a.id_ovh_price,a.id_ovh,c.comp_name,d.currency,d.id_currency,c.id_comp,b.id_comp_contact,a.ovh_price,IF(a.is_enable_component=1,'yes','no') AS is_enable_component,a.ovh_price_name,a.ovh_price_date FROM tb_m_ovh_price a "
            query += "INNER JOIN tb_m_comp_contact b ON a.id_comp_contact = b.id_comp_contact "
            query += "INNER JOIN tb_m_comp c ON c.id_comp = b.id_comp "
            query += "INNER JOIN tb_lookup_currency d ON a.id_currency = d.id_currency "
            query += "WHERE a.id_ovh = '" + id_ovh + "' "
            Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
            GCPrice.DataSource = data
            If data.Rows.Count < 1 Then
                BtnDelete.Visible = False
                BtnEdit.Visible = False
            Else
                BtnDelete.Visible = True
                BtnEdit.Visible = True
            End If
        Catch ex As Exception
            errorConnection()
            Close()
        End Try
    End Sub
    'Add Price
    Private Sub BtnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnAdd.Click
        FormMasterOVHPrcSingle.action = "ins"
        FormMasterOVHPrcSingle.ShowDialog()
    End Sub
    'Delete Price
    Private Sub BtnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnDelete.Click
        Dim confirm As DialogResult = DevExpress.XtraEditors.XtraMessageBox.Show("Are you sure want to delete this price?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
        If confirm = Windows.Forms.DialogResult.Yes Then
            Cursor = Cursors.WaitCursor
            Try
                Dim id_ovh_price As String = GVPrice.GetFocusedRowCellDisplayText("id_ovh_price").ToString
                Dim query As String = String.Format("DELETE FROM tb_m_ovh_price WHERE id_ovh_price = '{0}'", id_ovh_price)
                execute_non_query(query, True, "", "", "", "")
                logData("tb_m_ovh_price", 3)
                viewPrice()
            Catch ex As Exception
                errorDelete()
            End Try
            Cursor = Cursors.Default
        End If
    End Sub
    'Edit Price
    Private Sub BtnEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnEdit.Click
        FormMasterOVHPrcSingle.action = "upd"
        FormMasterOVHPrcSingle.id_ovh_price = GVPrice.GetFocusedRowCellDisplayText("id_ovh_price").ToString
        FormMasterOVHPrcSingle.ShowDialog()
    End Sub

    Private Sub BEnable_Click(sender As Object, e As EventArgs) Handles BEnable.Click
        If GVPrice.RowCount > 0 Then
            If GVPrice.GetFocusedRowCellValue("is_enable_component").ToString = "yes" Then
                Dim q As String = "UPDATE tb_m_ovh_price SET is_enable_component=2 WHERE id_ovh_price='" & GVPrice.GetFocusedRowCellValue("id_ovh_price").ToString & "'"
                execute_non_query(q, True, "", "", "", "")
            ElseIf GVPrice.GetFocusedRowCellValue("is_enable_component").ToString = "no" Then
                Dim q As String = "UPDATE tb_m_ovh_price SET is_enable_component=1 WHERE id_ovh_price='" & GVPrice.GetFocusedRowCellValue("id_ovh_price").ToString & "'"
                execute_non_query(q, True, "", "", "", "")
            End If
            viewPrice()
        End If
    End Sub
End Class