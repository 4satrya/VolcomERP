Public Class FormBankWithdrawalBookTransfer
    Private Sub FormBankWithdrawalBookTransfer_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub view_currency()
        Dim query As String = "SELECT id_currency,currency FROM tb_lookup_currency"
        viewLookupQuery(LECurrency, query, 0, "currency", "id_currency")
    End Sub

    Private Sub FormBankWithdrawalBookTransfer_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        load_pay_from()
        view_currency()
        '
        TEAmount.EditValue = 0
        TEKurs.EditValue = 1
    End Sub

    Sub load_pay_from()
        Dim query As String = "SELECT id_acc,acc_name,acc_description FROM `tb_a_acc` WHERE id_status='1' AND id_is_det='2'"
        viewSearchLookupQuery(SLEPayFrom, query, "id_acc", "acc_description", "id_acc")
        viewSearchLookupQuery(SLETrfTo, query, "id_acc", "acc_description", "id_acc")
    End Sub

    Private Sub BConfirm_Click(sender As Object, e As EventArgs) Handles BConfirm.Click
        'header
        FormBankWithdrawalDet.SLEPayFrom.EditValue = SLEPayFrom.EditValue
        FormBankWithdrawalDet.SLEVendor.EditValue = "1"
        FormBankWithdrawalDet.SLEPayType.EditValue = "2"
        '
        FormBankWithdrawalDet.SLEReportType.EditValue = "159"
        FormBankWithdrawalDet.report_mark_type = "159"

        Try
            Dim newRow As DataRow = (TryCast(FormBankWithdrawalDet.GCList.DataSource, DataTable)).NewRow()
            newRow("id_report") = "0"
            newRow("report_mark_type") = "0"
            newRow("id_acc") = SLETrfTo.EditValue.ToString
            newRow("vendor") = ""
            newRow("id_comp") = "1"
            newRow("comp_number") = "000"

            newRow("acc_name") = SLETrfTo.Properties.View.GetFocusedRowCellValue("acc_name").ToString
            newRow("acc_description") = SLETrfTo.Text
            newRow("number") = ""
            newRow("total_pay") = 0

            newRow("value") = TEAmountRp.EditValue
            newRow("balance_due") = TEAmountRp.EditValue

            newRow("kurs") = TEKurs.EditValue
            newRow("id_currency") = LECurrency.EditValue
            newRow("currency") = LECurrency.Text
            newRow("val_bef_kurs") = TEAmount.EditValue
            newRow("note") = "Book Transfer"
            newRow("id_dc") = "1"
            newRow("dc_code") = "D"
            newRow("value_view") = TEAmountRp.EditValue
            TryCast(FormBankWithdrawalDet.GCList.DataSource, DataTable).Rows.Add(newRow)
            FormBankWithdrawalDet.GCList.RefreshDataSource()
            FormBankWithdrawalDet.GVList.RefreshData()
            FormBankWithdrawalDet.calculate_amount()
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

        Close()
    End Sub

    Private Sub TEAmount_EditValueChanged(sender As Object, e As EventArgs) Handles TEAmount.EditValueChanged
        calculate()
    End Sub

    Private Sub TEKurs_EditValueChanged(sender As Object, e As EventArgs) Handles TEKurs.EditValueChanged
        calculate()
    End Sub

    Sub calculate()
        TEAmountRp.EditValue = TEKurs.EditValue * TEAmount.EditValue
    End Sub
End Class