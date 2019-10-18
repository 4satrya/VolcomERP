﻿Public Class FormBankDepositAdd
    Public action As String = "-1"

    Private Sub BtnClose_Click(sender As Object, e As EventArgs) Handles BtnClose.Click
        Close()
    End Sub

    Private Sub FormBankDepositAdd_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub FormBankDepositAdd_Load(sender As Object, e As EventArgs) Handles MyBase.Load
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

            TxtReff.Text = ""
            TxtDescription.Text = ""

            'comp
            SLEComp.EditValue = Nothing
            TxtCustomer.Text = ""


            'd/k
            LEDK.ItemIndex = LEDK.Properties.GetDataSourceRowIndex("id_dc", "1")
            TxtAmount.EditValue = 0.00
        Else
            SLECOA.EditValue = FormBankDepositDet.GVList.GetFocusedRowCellValue("id_acc").ToString
            TxtCOA.Text = FormBankDepositDet.GVList.GetFocusedRowCellValue("acc_name").ToString
            TxtReff.Text = FormBankDepositDet.GVList.GetFocusedRowCellValue("number").ToString
            TxtDescription.Text = FormBankDepositDet.GVList.GetFocusedRowCellValue("note").ToString
            TxtCustomer.Text = FormBankDepositDet.GVList.GetFocusedRowCellValue("comp_number").ToString
            SLEComp.EditValue = FormBankDepositDet.GVList.GetFocusedRowCellValue("id_comp").ToString
            LEDK.ItemIndex = LEDK.Properties.GetDataSourceRowIndex("id_dc", FormBankDepositDet.GVList.GetFocusedRowCellValue("id_dc").ToString)
            TxtAmount.EditValue = FormBankDepositDet.GVList.GetFocusedRowCellValue("value_view")
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
            TxtCustomer.Text = SLEComp.Properties.View.GetFocusedRowCellValue("comp_number").ToString
        Catch ex As Exception
        End Try
    End Sub

    Private Sub BtnAdd_Click(sender As Object, e As EventArgs) Handles BtnAdd.Click
        If action = "ins" Then
            Dim newRow As DataRow = (TryCast(FormBankDepositDet.GCList.DataSource, DataTable)).NewRow()
            newRow("id_report") = "0"
            newRow("report_mark_type") = "0"
            newRow("report_mark_type_name") = "-"
            newRow("number") = addSlashes(TxtReff.Text)
            If TxtCustomer.Text = "" Then
                newRow("id_comp") = "0"
            Else
                newRow("id_comp") = SLEComp.EditValue.ToString
            End If
            newRow("id_acc") = SLECOA.EditValue.ToString
            newRow("acc_name") = TxtCOA.Text
            newRow("acc_description") = SLECOA.Text
            newRow("comp_number") = TxtCustomer.Text
            newRow("total_rec") = 0
            If LEDK.EditValue.ToString = "1" Then
                newRow("value") = TxtAmount.EditValue * -1
                newRow("balance_due") = TxtAmount.EditValue * -1
            Else
                newRow("value") = TxtAmount.EditValue
                newRow("balance_due") = TxtAmount.EditValue
            End If
            newRow("note") = addSlashes(TxtDescription.Text)
            newRow("id_dc") = LEDK.EditValue.ToString
            newRow("dc_code") = LEDK.Text
            newRow("value_view") = TxtAmount.EditValue
            TryCast(FormBankDepositDet.GCList.DataSource, DataTable).Rows.Add(newRow)
            FormBankDepositDet.GCList.RefreshDataSource()
            FormBankDepositDet.GVList.RefreshData()
            FormBankDepositDet.calculate_amount()
            actionLoad()
        Else
            'update
            FormBankDepositDet.GVList.SetFocusedRowCellValue("number", addSlashes(TxtReff.Text))
            If TxtCustomer.Text = "" Then
                FormBankDepositDet.GVList.SetFocusedRowCellValue("id_comp", "0")
            Else
                FormBankDepositDet.GVList.SetFocusedRowCellValue("id_comp", SLEComp.EditValue.ToString)
            End If
            FormBankDepositDet.GVList.SetFocusedRowCellValue("id_acc", SLECOA.EditValue.ToString)
            FormBankDepositDet.GVList.SetFocusedRowCellValue("acc_name", TxtCOA.Text)
            FormBankDepositDet.GVList.SetFocusedRowCellValue("acc_description", SLECOA.Text)
            FormBankDepositDet.GVList.SetFocusedRowCellValue("comp_number", TxtCustomer.Text)
            FormBankDepositDet.GVList.SetFocusedRowCellValue("total_rec", 0)
            If LEDK.EditValue.ToString = "1" Then
                FormBankDepositDet.GVList.SetFocusedRowCellValue("value", TxtAmount.EditValue * -1)
                FormBankDepositDet.GVList.SetFocusedRowCellValue("balance_due", TxtAmount.EditValue * -1)
            Else
                FormBankDepositDet.GVList.SetFocusedRowCellValue("value", TxtAmount.EditValue)
                FormBankDepositDet.GVList.SetFocusedRowCellValue("balance_due", TxtAmount.EditValue)
            End If
            FormBankDepositDet.GVList.SetFocusedRowCellValue("note", addSlashes(TxtDescription.Text))
            FormBankDepositDet.GVList.SetFocusedRowCellValue("id_dc", LEDK.EditValue.ToString)
            FormBankDepositDet.GVList.SetFocusedRowCellValue("dc_code", LEDK.Text)
            FormBankDepositDet.GVList.SetFocusedRowCellValue("value_view", TxtAmount.EditValue)
            FormBankDepositDet.GCList.RefreshDataSource()
            FormBankDepositDet.GVList.RefreshData()
            FormBankDepositDet.calculate_amount()
            Close()
        End If
    End Sub

    Private Sub BtnClearComp_Click(sender As Object, e As EventArgs) Handles BtnClearComp.Click
        TxtCustomer.Text = ""
        SLEComp.EditValue = Nothing
    End Sub
End Class