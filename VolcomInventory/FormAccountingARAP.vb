Public Class FormAccountingARAP
    Public id_comp As String = "-1"

    Private Sub FormAccountingARAP_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        viewCOA()

        id_comp = FormAccounting.GVCompany.GetFocusedRowCellValue("id_comp").ToString
        TxtCompNumber.Text = FormAccounting.GVCompany.GetFocusedRowCellValue("comp_number").ToString
        TxtCompName.Text = FormAccounting.GVCompany.GetFocusedRowCellValue("comp_name").ToString
        TxtStoreDiscount.Text = FormAccounting.GVCompany.GetFocusedRowCellValue("comp_commission").ToString
        Dim id_ap As String = FormAccounting.GVCompany.GetFocusedRowCellValue("id_acc_ap").ToString
        If id_ap = "0" Then
            SLEAP.EditValue = Nothing
            TxtAPCode.Text = ""
        Else
            SLEAP.EditValue = id_ap
            TxtAPCode.Text = getAccNo(id_ap)
        End If

        Dim id_ap_cabang As String = FormAccounting.GVCompany.GetFocusedRowCellValue("id_acc_cabang_ap").ToString
        If id_ap_cabang = "0" Then
            SLEAPCabang.EditValue = Nothing
            TxtAPCodeCabang.Text = ""
        Else
            SLEAPCabang.EditValue = id_ap_cabang
            TxtAPCodeCabang.Text = getAccNo(id_ap_cabang)
        End If

        Dim id_dp As String = FormAccounting.GVCompany.GetFocusedRowCellValue("id_acc_dp").ToString
        If id_dp = "0" Then
            SLEDP.EditValue = Nothing
            TxtDPCode.Text = ""
        Else
            SLEDP.EditValue = id_dp
            TxtDPCode.Text = getAccNo(id_dp)
        End If

        Dim id_dp_cabang As String = FormAccounting.GVCompany.GetFocusedRowCellValue("id_acc_cabang_dp").ToString
        If id_dp_cabang = "0" Then
            SLEDPCabang.EditValue = Nothing
            TxtDPCodeCabang.Text = ""
        Else
            SLEDPCabang.EditValue = id_dp_cabang
            TxtDPCodeCabang.Text = getAccNo(id_dp_cabang)
        End If

        Dim id_sales As String = FormAccounting.GVCompany.GetFocusedRowCellValue("id_acc_sales").ToString
        If id_sales = "0" Then
            SLESales.EditValue = Nothing
            TxtSalesCode.Text = ""
        Else
            SLESales.EditValue = id_sales
            TxtSalesCode.Text = getAccNo(id_sales)
        End If

        Dim id_sales_return As String = FormAccounting.GVCompany.GetFocusedRowCellValue("id_acc_sales_return").ToString
        If id_sales_return = "0" Then
            SLESalesReturn.EditValue = Nothing
            TxtSalesReturnCode.Text = ""
        Else
            SLESalesReturn.EditValue = id_sales_return
            TxtSalesReturnCode.Text = getAccNo(id_sales_return)
        End If

        Dim id_ar As String = FormAccounting.GVCompany.GetFocusedRowCellValue("id_acc_ar").ToString
        If id_ar = "0" Then
            SLEAR.EditValue = Nothing
            TxtARCode.Text = ""
        Else
            SLEAR.EditValue = id_ar
            TxtARCode.Text = getAccNo(id_ar)
        End If

        Dim id_ar_cabang As String = FormAccounting.GVCompany.GetFocusedRowCellValue("id_acc_cabang_ar").ToString
        If id_ar = "0" Then
            SLEARCabang.EditValue = Nothing
            TxtARCodeCabang.Text = ""
        Else
            SLEARCabang.EditValue = id_ar_cabang
            TxtARCodeCabang.Text = getAccNo(id_ar_cabang)
        End If

        viewOtherDiscount()
    End Sub

    Private Function getAccNo(ByVal id_acc As String) As String
        Dim code As String = execute_query("SELECT acc_name FROM tb_a_acc WHERE id_acc='" + id_acc + "' ", 0, True, "", "", "", "")
        Return code
    End Function

    Sub viewOtherDiscount()
        Cursor = Cursors.WaitCursor
        Dim query As String = "SELECT d.id_comp_comm_extra, d.comp_commission, 
        d.id_acc_sales, sal.acc_name AS `acc_name_sales`, sal.acc_description AS `acc_description_sales`, 
        d.id_acc_sales_return, sal_ret.acc_name AS `acc_name_sales_ret`, sal_ret.acc_description AS `acc_description_sales_ret`,
        d.id_acc_ar, ar.acc_name AS `acc_name_ar`, ar.acc_description AS `acc_description_ar`, d.is_for_gwp,
        IF(d.is_for_gwp=1,'Yes', 'No') AS `is_for_gwp_view`
        FROM tb_m_comp_comm_extra d
        INNER JOIN tb_a_acc ar ON ar.id_acc = d.id_acc_ar
        LEFT JOIN tb_a_acc sal ON sal.id_acc = d.id_acc_sales
        LEFT JOIN tb_a_acc sal_ret ON sal_ret.id_acc = d.id_acc_sales_return
        WHERE d.id_comp=" + id_comp + " "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCOtherDiscount.DataSource = data
        GVOtherDiscount.BestFitColumns()
        Cursor = Cursors.Default
    End Sub


    Sub viewCOA()
        Dim query As String = "SELECT a.id_acc, a.acc_name, a.acc_description, a.id_acc_parent, 
        a.id_acc_parent, a.id_acc_cat, a.id_is_det, a.id_status, a.id_comp
        FROM tb_a_acc a WHERE a.id_status=1 AND a.id_is_det=2 AND a.id_coa_type='1' "
        viewSearchLookupQuery(SLESales, query, "id_acc", "acc_description", "id_acc")
        viewSearchLookupQuery(SLESalesReturn, query, "id_acc", "acc_description", "id_acc")
        viewSearchLookupQuery(SLEAR, query, "id_acc", "acc_description", "id_acc")
        viewSearchLookupQuery(SLEAP, query, "id_acc", "acc_description", "id_acc")
        viewSearchLookupQuery(SLEDP, query, "id_acc", "acc_description", "id_acc")
        'cabang
        Dim q_cabang As String = "SELECT a.id_acc, a.acc_name, a.acc_description, a.id_acc_parent, 
        a.id_acc_parent, a.id_acc_cat, a.id_is_det, a.id_status, a.id_comp
        FROM tb_a_acc a WHERE a.id_status=1 AND a.id_is_det=2 AND a.id_coa_type='2' "
        viewSearchLookupQuery(SLEARCabang, q_cabang, "id_acc", "acc_description", "id_acc")
        viewSearchLookupQuery(SLEAPCabang, q_cabang, "id_acc", "acc_description", "id_acc")
        viewSearchLookupQuery(SLEDPCabang, q_cabang, "id_acc", "acc_description", "id_acc")
    End Sub

    Private Sub BtnCancel_Click(sender As Object, e As EventArgs) Handles BtnCancel.Click
        Close()
    End Sub

    Private Sub FormAccountingARAP_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs) Handles BClearAP.Click
        SLEAP.EditValue = Nothing
        TxtAPCode.Text = ""
    End Sub

    Private Sub SimpleButton2_Click(sender As Object, e As EventArgs) Handles BClearAR.Click
        SLEAR.EditValue = Nothing
        TxtARCode.Text = ""
    End Sub

    Private Sub BClearDP_Click(sender As Object, e As EventArgs) Handles BClearDP.Click
        SLEDP.EditValue = Nothing
        TxtDPCode.Text = ""
    End Sub

    Private Sub BtnConfirm_Click(sender As Object, e As EventArgs) Handles BtnConfirm.Click
        Dim id_acc_ap As String = ""
        If SLEAP.EditValue = Nothing Then
            id_acc_ap = "NULL"
        Else
            id_acc_ap = SLEAP.EditValue.ToString
        End If

        Dim id_acc_dp As String = ""
        If SLEDP.EditValue = Nothing Then
            id_acc_dp = "NULL"
        Else
            id_acc_dp = SLEDP.EditValue.ToString
        End If

        '
        Dim id_acc_ap_cabang As String = ""
        If SLEAPCabang.EditValue = Nothing Then
            id_acc_ap_cabang = "NULL"
        Else
            id_acc_ap_cabang = SLEAPCabang.EditValue.ToString
        End If

        Dim id_acc_dp_cabang As String = ""
        If SLEDPCabang.EditValue = Nothing Then
            id_acc_dp_cabang = "NULL"
        Else
            id_acc_dp_cabang = SLEDPCabang.EditValue.ToString
        End If
        '

        Dim id_acc_sales As String = ""
        If SLESales.EditValue = Nothing Then
            id_acc_sales = "NULL"
        Else
            id_acc_sales = SLESales.EditValue.ToString
        End If

        Dim id_acc_sales_return As String = ""
        If SLESalesReturn.EditValue = Nothing Then
            id_acc_sales_return = "NULL"
        Else
            id_acc_sales_return = SLESalesReturn.EditValue.ToString
        End If

        Dim id_acc_ar As String = ""
        If SLEAR.EditValue = Nothing Then
            id_acc_ar = "NULL"
        Else
            id_acc_ar = SLEAR.EditValue.ToString
        End If

        Dim id_acc_ar_cabang As String = ""
        If SLEARCabang.EditValue = Nothing Then
            id_acc_ar_cabang = "NULL"
        Else
            id_acc_ar_cabang = SLEARCabang.EditValue.ToString
        End If

        'discount
        Dim comp_commission As String = decimalSQL(TxtStoreDiscount.EditValue.ToString)

        If id_comp = "-1" Then
            warningCustom("Store not found")
        Else
            Dim query As String = "UPDATE tb_m_comp SET id_acc_sales=" + id_acc_sales + ", id_acc_sales_return=" + id_acc_sales_return + ",id_acc_ar=" + id_acc_ar + ",id_acc_cabang_ar=" + id_acc_ar_cabang + ", id_acc_ap=" + id_acc_ap + ", id_acc_dp=" + id_acc_dp + ", id_acc_cabang_ap=" + id_acc_ap_cabang + ", id_acc_cabang_dp=" + id_acc_dp_cabang + ", comp_commission='" + comp_commission + "' WHERE id_comp='" + id_comp + "' "
            execute_non_query(query, True, "", "", "", "")
            FormAccounting.viewCompany()
            FormAccounting.GVCompany.FocusedRowHandle = find_row(FormAccounting.GVCompany, "id_comp", id_comp)
            Close()
        End If
    End Sub

    Private Sub BtnClearSales_Click(sender As Object, e As EventArgs) Handles BtnClearSales.Click
        SLESales.EditValue = Nothing
        TxtSalesCode.Text = ""
    End Sub

    Private Sub SimpleButton1_Click_1(sender As Object, e As EventArgs) Handles SimpleButton1.Click
        SLESalesReturn.EditValue = Nothing
        TxtSalesReturnCode.Text = ""
    End Sub

    Private Sub SLEAR_EditValueChanged(sender As Object, e As EventArgs) Handles SLEAR.EditValueChanged
        If SLEAR.EditValue = Nothing Then
            TxtARCode.Text = ""
        Else
            Try
                TxtARCode.Text = SLEAR.Properties.View.GetFocusedRowCellValue("acc_name").ToString
            Catch ex As Exception
            End Try
        End If
    End Sub

    Private Sub SLESales_EditValueChanged(sender As Object, e As EventArgs) Handles SLESales.EditValueChanged
        If SLESales.EditValue = Nothing Then
            TxtSalesCode.Text = ""
        Else
            Try
                TxtSalesCode.Text = SLESales.Properties.View.GetFocusedRowCellValue("acc_name").ToString
            Catch ex As Exception
            End Try
        End If
    End Sub

    Private Sub SLESalesReturn_EditValueChanged(sender As Object, e As EventArgs) Handles SLESalesReturn.EditValueChanged
        If SLESalesReturn.EditValue = Nothing Then
            TxtSalesReturnCode.Text = ""
        Else
            Try
                TxtSalesReturnCode.Text = SLESalesReturn.Properties.View.GetFocusedRowCellValue("acc_name").ToString
            Catch ex As Exception
            End Try
        End If
    End Sub

    Private Sub SLEAP_EditValueChanged(sender As Object, e As EventArgs) Handles SLEAP.EditValueChanged
        If SLEAP.EditValue = Nothing Then
            TxtAPCode.Text = ""
        Else
            Try
                TxtAPCode.Text = SLEAP.Properties.View.GetFocusedRowCellValue("acc_name").ToString
            Catch ex As Exception
            End Try
        End If
    End Sub

    Private Sub SLEDP_EditValueChanged(sender As Object, e As EventArgs) Handles SLEDP.EditValueChanged
        If SLEDP.EditValue = Nothing Then
            TxtDPCode.Text = ""
        Else
            Try
                TxtDPCode.Text = SLEDP.Properties.View.GetFocusedRowCellValue("acc_name").ToString
            Catch ex As Exception
            End Try
        End If
    End Sub

    Private Sub BtnAdd_Click(sender As Object, e As EventArgs) Handles BtnAdd.Click
        Cursor = Cursors.WaitCursor
        FormAccountingARAPOtherDiscount.id_comp = id_comp
        FormAccountingARAPOtherDiscount.ShowDialog()
        Cursor = Cursors.Default
    End Sub

    Private Sub BtnDelete_Click(sender As Object, e As EventArgs) Handles BtnDelete.Click
        If GVOtherDiscount.RowCount > 0 And GVOtherDiscount.FocusedRowHandle >= 0 Then
            Dim confirm As DialogResult = DevExpress.XtraEditors.XtraMessageBox.Show("Are you sure you want to delete this discount? ", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
            If confirm = Windows.Forms.DialogResult.Yes Then
                Dim id As String = GVOtherDiscount.GetFocusedRowCellValue("id_comp_comm_extra").ToString
                Dim query As String = "DELETE FROM tb_m_comp_comm_extra WHERE id_comp_comm_extra='" + id + "' "
                execute_non_query(query, True, "", "", "", "")
                viewOtherDiscount()
            End If
        End If
    End Sub

    Private Sub GVOtherDiscount_DoubleClick(sender As Object, e As EventArgs) Handles GVOtherDiscount.DoubleClick
        If GVOtherDiscount.RowCount > 0 And GVOtherDiscount.FocusedRowHandle >= 0 Then
            FormAccountingARAPOtherDiscount.id_comp = id_comp
            FormAccountingARAPOtherDiscount.is_for_gwp = GVOtherDiscount.GetFocusedRowCellValue("is_for_gwp").ToString
            FormAccountingARAPOtherDiscount.id_comp_comm_extra = GVOtherDiscount.GetFocusedRowCellValue("id_comp_comm_extra").ToString
            FormAccountingARAPOtherDiscount.ShowDialog()
        End If
    End Sub

    Private Sub SimpleButton2_Click_1(sender As Object, e As EventArgs) Handles BtnAddforGWP.Click
        Cursor = Cursors.WaitCursor
        FormAccountingARAPOtherDiscount.id_comp = id_comp
        FormAccountingARAPOtherDiscount.is_for_gwp = "1"
        FormAccountingARAPOtherDiscount.ShowDialog()
        Cursor = Cursors.Default
    End Sub

    Private Sub SimpleButton2_Click_2(sender As Object, e As EventArgs) Handles BClearAPCabang.Click
        SLEAPCabang.EditValue = Nothing
        TxtAPCodeCabang.Text = ""
    End Sub

    Private Sub SimpleButton3_Click(sender As Object, e As EventArgs) Handles BClearDPCabang.Click
        SLEDPCabang.EditValue = Nothing
        TxtDPCodeCabang.Text = ""
    End Sub
End Class