Public Class FormBillingDet 
    Public id_bill As String = "-1"
    Public id_reff As String = "-1"
    Public id_cc As String = "-1"

    Private Sub FormBillingDet_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        load_billing_type(LEBilling)
        load_currency(LECurrency)
        load_bill_item()

        If id_bill = "-1" Then 'insert
            load_number()
            te_now_date(TEDate)
        Else 'edit

        End If
    End Sub

    Sub load_number()
        If LEBilling.EditValue.ToString = "1" Then
            TENumber.Text = header_number_acc("3")
        ElseIf LEBilling.EditValue.ToString = "2" Then
            TENumber.Text = header_number_acc("4")
        End If
    End Sub

    Private Sub BCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BCancel.Click
        Close()
    End Sub

    Private Sub BPickReff_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BPickReff.Click
        If LEBilling.EditValue.ToString = "1" Then 'BPJ
            FormSalesCreditNotePopInv.id_pop_up = "3"
            FormSalesCreditNotePopInv.ShowDialog()
        ElseIf LEBilling.EditValue.ToString = "2" Then 'BPL
            'pembelian material

        End If
    End Sub

    Sub clean_form()

    End Sub

    Private Sub FormBillingDet_FormClosed(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub
    Sub load_bill_item()
        Dim query As String = "1"
        If LEBilling.EditValue.ToString = "1" Then 'BPJ
            query = "CALL view_bill(48," + id_bill + ")"
        ElseIf LEBilling.EditValue.ToString = "2" Then 'BPL
            query = "CALL view_bill(48," + id_bill + ")"
        End If
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCBilling.DataSource = data
    End Sub

    Private Sub GVBilling_CustomColumnDisplayText(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs) Handles GVBilling.CustomColumnDisplayText
        If e.Column.FieldName = "no" Then
            e.DisplayText = (e.ListSourceRowIndex + 1).ToString()
        End If
    End Sub
    Sub calculate()
        If LEBilling.EditValue.ToString = "1" Then 'BPJ
            Dim total As Decimal = 0
            Dim vat As Decimal = 0
            Dim vat_amount As Decimal = 0
            Dim total_after_vat As Decimal = 0

            total = GVBilling.Columns("amount").SummaryItem.SummaryValue()
            TETotal.EditValue = total
            vat = TEVat.EditValue

            Dim commision As Decimal = 0
            Dim total_after_com As Decimal = 0

            commision = TEDisc.EditValue
            total = ((100 - commision) / 100) * total

            TETotalAfterCom.EditValue = total

            vat_amount = total * vat / 100
            total_after_vat = total + vat_amount

            TEVatTot.EditValue = vat_amount

            TETotalAfterVat.EditValue = total_after_vat

            METotSay.Text = ConvertCurrencyToEnglish(total_after_vat, LECurrency.EditValue.ToString)
        End If
    End Sub

    Private Sub BSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BSave.Click
        Dim query As String = ""
        query = "INSERT INTO tb_sales_pos()"
    End Sub

    Private Sub LEBilling_EditValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LEBilling.EditValueChanged
        If Not LEBilling.EditValue.ToString = "" Then
            clean_form()
            load_number()
        End If
    End Sub
End Class