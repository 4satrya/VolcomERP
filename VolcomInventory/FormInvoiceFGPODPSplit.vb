Public Class FormInvoiceFGPODPSplit
    Private Sub FormInvoiceFGPODPSplit_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub FormInvoiceFGPODPSplit_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        TEAmount.EditValue = FormInvoiceFGPODP.GVList.GetFocusedRowCellValue("value")
        TEVAT.EditValue = FormInvoiceFGPODP.GVList.GetFocusedRowCellValue("vat")
    End Sub

    Private Sub BSplit_Click(sender As Object, e As EventArgs) Handles BSplit.Click
        'check
        If TEAmount.EditValue + TEVAT.EditValue < 0 Then
            warningCustom("Please put the amount/VAT value first")
        ElseIf TEAmount.EditValue = FormInvoiceFGPODP.GVList.GetFocusedRowCellValue("value") Then
            warningCustom("Values are same")
        ElseIf TEAmount.EditValue > FormInvoiceFGPODP.GVList.GetFocusedRowCellValue("value") Or TEVAT.EditValue > FormInvoiceFGPODP.GVList.GetFocusedRowCellValue("vat") Then
            warningCustom("Values are more than original")
        Else
            'update focused row
            FormInvoiceFGPODP.GVList.SetFocusedRowCellValue("value", FormInvoiceFGPODP.GVList.GetFocusedRowCellValue("value") - TEAmount.EditValue)
            FormInvoiceFGPODP.GVList.SetFocusedRowCellValue("vat", FormInvoiceFGPODP.GVList.GetFocusedRowCellValue("vat") - TEVAT.EditValue)
            'add splitted value
            Dim newRow As DataRow = (TryCast(FormInvoiceFGPODP.GCList.DataSource, DataTable)).NewRow()
            newRow("id_report") = FormInvoiceFGPODP.GVList.GetFocusedRowCellValue("id_report")
            newRow("report_mark_type") = FormInvoiceFGPODP.GVList.GetFocusedRowCellValue("report_mark_type")
            newRow("number") = FormInvoiceFGPODP.GVList.GetFocusedRowCellValue("number")
            newRow("description") = FormInvoiceFGPODP.GVList.GetFocusedRowCellValue("description")
            newRow("code") = FormInvoiceFGPODP.GVList.GetFocusedRowCellValue("code")
            newRow("value") = TEAmount.EditValue
            newRow("vat") = TEVAT.EditValue
            newRow("inv_number") = ""
            newRow("note") = ""
            TryCast(FormInvoiceFGPODP.GCList.DataSource, DataTable).Rows.Add(newRow)
            Close()
        End If
    End Sub
End Class