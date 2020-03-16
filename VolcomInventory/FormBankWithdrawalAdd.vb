Public Class FormBankWithdrawalAdd
    Public action As String = "-1"

    Private Sub BtnClose_Click(sender As Object, e As EventArgs) Handles BtnClose.Click
        Close()
    End Sub

    Private Sub FormBankWithdrawalAdd_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub FormBankWithdrawalAdd_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        viewCOA()
        viewComp()
        viewDK()
        actionLoad()
    End Sub

    Sub actionLoad()
        'focus
        ActiveControl = SLECOA

        If action = "ins" Then
            'coa
            Dim id_acc As String = SLECOA.EditValue.ToString
            TxtCOA.Text = execute_query("SELECT acc_name FROM tb_a_acc WHERE id_acc='" + id_acc + "' ", 0, True, "", "", "", "")

            'comp
            SLEComp.EditValue = "-1"
            TxtComp.Text = ""
            SLEComp.EditValue = "1"
            TxtComp.Text = execute_query("SELECT comp_number FROM tb_m_comp WHERE id_comp='" + SLEComp.EditValue.ToString + "' ", 0, True, "", "", "", "")

            TxtReff.Text = ""
            TxtDescription.Text = ""
            TxtSupplier.Text = ""

            'd/k
            LEDK.ItemIndex = LEDK.Properties.GetDataSourceRowIndex("id_dc", "1")
            TxtAmount.EditValue = 0.00
        Else
            SLECOA.EditValue = FormBankWithdrawalDet.GVList.GetFocusedRowCellValue("id_acc").ToString
            TxtCOA.Text = FormBankWithdrawalDet.GVList.GetFocusedRowCellValue("acc_name").ToString
            TxtReff.Text = FormBankWithdrawalDet.GVList.GetFocusedRowCellValue("number").ToString
            TxtDescription.Text = FormBankWithdrawalDet.GVList.GetFocusedRowCellValue("note").ToString
            TxtSupplier.Text = FormBankWithdrawalDet.GVList.GetFocusedRowCellValue("vendor").ToString
            TxtComp.Text = FormBankWithdrawalDet.GVList.GetFocusedRowCellValue("comp_number").ToString
            SLEComp.EditValue = FormBankWithdrawalDet.GVList.GetFocusedRowCellValue("id_comp").ToString
            LEDK.ItemIndex = LEDK.Properties.GetDataSourceRowIndex("id_dc", FormBankWithdrawalDet.GVList.GetFocusedRowCellValue("id_dc").ToString)
            TxtAmount.EditValue = FormBankWithdrawalDet.GVList.GetFocusedRowCellValue("value_view")
        End If
    End Sub

    Sub viewCOA()
        Dim query As String = "SELECT a.id_acc, a.acc_name, a.acc_description, a.id_acc_parent, 
        a.id_acc_parent, a.id_acc_cat, a.id_is_det, a.id_status, a.id_comp
        FROM tb_a_acc a WHERE a.id_status=1 AND a.id_is_det=2 "
        viewSearchLookupQuery(SLECOA, query, "id_acc", "acc_description", "id_acc")
    End Sub

    Sub viewComp()
        Dim query As String = "SELECT c.id_comp, c.comp_number,c.comp_name FROM tb_m_comp c"
        viewSearchLookupQuery(SLEComp, query, "id_comp", "comp_name", "id_comp")
    End Sub

    Sub viewDK()
        Dim query As String = "SELECT * FROM tb_lookup_dc d WHERE d.id_dc=1 OR d.id_dc=2 "
        viewLookupQuery(LEDK, query, 0, "dc_code", "id_dc")
    End Sub

    Private Sub SLECOA_EditValueChanged(sender As Object, e As EventArgs) Handles SLECOA.EditValueChanged
        Try
            TxtCOA.Text = SLECOA.Properties.View.GetFocusedRowCellValue("acc_name").ToString
        Catch ex As Exception
        End Try
    End Sub

    Private Sub SLEComp_EditValueChanged(sender As Object, e As EventArgs) Handles SLEComp.EditValueChanged
        Try
            TxtComp.Text = SLEComp.Properties.View.GetFocusedRowCellValue("comp_number").ToString
        Catch ex As Exception
        End Try
    End Sub

    Private Sub BtnAdd_Click(sender As Object, e As EventArgs) Handles BtnAdd.Click
        If action = "ins" Then
            Dim newRow As DataRow = (TryCast(FormBankWithdrawalDet.GCList.DataSource, DataTable)).NewRow()
            newRow("id_report") = "0"
            newRow("report_mark_type") = "0"
            newRow("id_acc") = SLECOA.EditValue.ToString
            newRow("vendor") = TxtSupplier.Text
            If TxtComp.Text = "" Then
                newRow("id_comp") = "1"
                newRow("comp_number") = "000"
            Else
                newRow("id_comp") = SLEComp.EditValue.ToString
                newRow("comp_number") = TxtComp.Text
            End If

            newRow("acc_name") = TxtCOA.Text
            newRow("acc_description") = SLECOA.Text
            newRow("number") = addSlashes(TxtReff.Text)
            newRow("total_pay") = 0

            If LEDK.EditValue.ToString = "2" Then
                newRow("value") = TxtAmount.EditValue * -1
                newRow("balance_due") = TxtAmount.EditValue * -1
            Else
                newRow("value") = TxtAmount.EditValue
                newRow("balance_due") = TxtAmount.EditValue
            End If
            newRow("kurs") = 0
            newRow("id_currency") = "1"
            newRow("currency") = "Rp"
            newRow("val_bef_kurs") = 0
            newRow("note") = addSlashes(TxtDescription.Text)
            newRow("id_dc") = LEDK.EditValue.ToString
            newRow("dc_code") = LEDK.Text
            newRow("value_view") = TxtAmount.EditValue
            TryCast(FormBankWithdrawalDet.GCList.DataSource, DataTable).Rows.Add(newRow)
            FormBankWithdrawalDet.GCList.RefreshDataSource()
            FormBankWithdrawalDet.GVList.RefreshData()
            FormBankWithdrawalDet.calculate_amount()
            actionLoad()
        Else
            'update
            FormBankWithdrawalDet.GVList.SetFocusedRowCellValue("number", addSlashes(TxtReff.Text))
            If TxtComp.Text = "" Then
                FormBankWithdrawalDet.GVList.SetFocusedRowCellValue("id_comp", "0")
            Else
                FormBankWithdrawalDet.GVList.SetFocusedRowCellValue("id_comp", SLEComp.EditValue.ToString)
            End If
            FormBankWithdrawalDet.GVList.SetFocusedRowCellValue("vendor", TxtSupplier.Text)
            FormBankWithdrawalDet.GVList.SetFocusedRowCellValue("id_acc", SLECOA.EditValue.ToString)
            FormBankWithdrawalDet.GVList.SetFocusedRowCellValue("acc_name", TxtCOA.Text)
            FormBankWithdrawalDet.GVList.SetFocusedRowCellValue("acc_description", SLECOA.Text)
            FormBankWithdrawalDet.GVList.SetFocusedRowCellValue("comp_number", TxtComp.Text)
            FormBankWithdrawalDet.GVList.SetFocusedRowCellValue("total_rec", 0)
            If LEDK.EditValue.ToString = "2" Then
                FormBankWithdrawalDet.GVList.SetFocusedRowCellValue("value", TxtAmount.EditValue * -1)
                FormBankWithdrawalDet.GVList.SetFocusedRowCellValue("balance_due", TxtAmount.EditValue * -1)
            Else
                FormBankWithdrawalDet.GVList.SetFocusedRowCellValue("value", TxtAmount.EditValue)
                FormBankWithdrawalDet.GVList.SetFocusedRowCellValue("balance_due", TxtAmount.EditValue)
            End If
            FormBankWithdrawalDet.GVList.SetFocusedRowCellValue("note", addSlashes(TxtDescription.Text))
            FormBankWithdrawalDet.GVList.SetFocusedRowCellValue("id_dc", LEDK.EditValue.ToString)
            FormBankWithdrawalDet.GVList.SetFocusedRowCellValue("dc_code", LEDK.Text)
            FormBankWithdrawalDet.GVList.SetFocusedRowCellValue("value_view", TxtAmount.EditValue)
            FormBankWithdrawalDet.GCList.RefreshDataSource()
            FormBankWithdrawalDet.GVList.RefreshData()
            FormBankWithdrawalDet.calculate_amount()
            Close()
        End If
    End Sub
End Class