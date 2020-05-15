﻿Public Class FormOlStoreReturnListUpdate
    Private Sub FormOlStoreReturnListUpdate_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Sub load_status()
        Dim q As String = "SELECT id_ol_store_ret_stt,ol_store_ret_stt
FROM `tb_lookup_ol_store_ret_stt`
WHERE is_only_cs='1'"
        viewSearchLookupQuery(SLEStatus, q, "id_ol_store_ret_stt", "ol_store_ret_stt", "id_ol_store_ret_stt")
    End Sub

    Private Sub FormOlStoreReturnListUpdate_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        load_status()
    End Sub

    Private Sub BSetStatus_Click(sender As Object, e As EventArgs) Handles BSetStatus.Click
        FormMain.SplashScreenManager1.ShowWaitForm()

        'get hide status
        Dim stt6 As String = execute_query("SELECT ol_store_ret_stt FROM tb_lookup_ol_store_ret_stt WHERE id_ol_store_ret_stt=6", 0, True, "", "", "", "")
        Dim stt7 As String = execute_query("SELECT ol_store_ret_stt FROM tb_lookup_ol_store_ret_stt WHERE id_ol_store_ret_stt=7", 0, True, "", "", "", "")

        Dim q As String = ""
        For i As Integer = 0 To FormOlStoreReturnList.GVList.RowCount - 1
            Dim order_number As String = FormOlStoreReturnList.GVList.GetRowCellValue(i, "sales_order_ol_shop_number").ToString
            Dim id_sales_order_det As String = FormOlStoreReturnList.GVList.GetRowCellValue(i, "id_sales_order_det").ToString
            If SLEStatus.EditValue.ToString <> "2" Then
                q += "UPDATE tb_ol_store_ret_list SET id_ol_store_ret_stt='" & SLEStatus.EditValue.ToString & "',update_by='" & id_user & "',update_date=NOW() WHERE `id_ol_store_ret_list`='" & FormOlStoreReturnList.GVList.GetRowCellValue(i, "id_ol_store_ret_list").ToString & "';
                INSERT INTO tb_sales_order_det_status(id_sales_order_det, `status`, `status_date`, `input_status_date`, is_internal) VALUES 
                ('" + id_sales_order_det + "', '" + addSlashes(SLEStatus.Text.ToString) + "', NOW(), NOW(), '1');"
            Else
                'on process refund
                FormMain.SplashScreenManager1.SetWaitFormDescription("Checking invoice : " + order_number)
                Dim id_ol_store_ret_list As String = FormOlStoreReturnList.GVList.GetRowCellValue(i, "id_ol_store_ret_list").ToString
                Dim qcek As String = "SELECT * FROM tb_ol_store_ret_list l
                INNER JOIN tb_ol_store_ret_det rd ON rd.id_ol_store_ret_det = l.id_ol_store_ret_det
                INNER JOIN tb_pl_sales_order_del_det dd ON dd.id_sales_order_det = rd.id_sales_order_det
                INNER JOIN tb_sales_pos_det id ON id.id_pl_sales_order_del_det = dd.id_pl_sales_order_del_det
                INNER JOIN tb_sales_pos i ON i.id_sales_pos = id.id_sales_pos
                WHERE l.id_ol_store_ret_list=" + id_ol_store_ret_list + " AND i.id_report_status=6 "
                Dim dcek As DataTable = execute_query(qcek, -1, True, "", "", "", "")
                Dim id_stt As String = ""
                Dim name_stt As String = ""
                If dcek.Rows.Count > 0 Then
                    id_stt = "6"
                    name_stt = stt6
                Else
                    id_stt = "7"
                    name_stt = stt7
                End If
                q += "UPDATE tb_ol_store_ret_list SET id_ol_store_ret_stt='" & id_stt & "',update_by='" & id_user & "',update_date=NOW() WHERE `id_ol_store_ret_list`='" & id_ol_store_ret_list & "';
                INSERT INTO tb_sales_order_det_status(id_sales_order_det, `status`, `status_date`, `input_status_date`, is_internal) VALUES 
                ('" + id_sales_order_det + "', '" + addSlashes(name_stt) + "', NOW(), NOW(), 1);"
            End If
        Next
        'update statyus
        FormMain.SplashScreenManager1.SetWaitFormDescription("Updating status")
        execute_non_query(q, True, "", "", "", "")

        'cek refund
        If SLEStatus.EditValue.ToString = "2" Then
            'creat obj
            Dim rf As New ClassOLStoreRefund()

            'cek CN
            FormMain.SplashScreenManager1.SetWaitFormDescription("Checking credit note")
            rf.createCN()


        End If

        FormOlStoreReturnList.view_list()
        FormMain.SplashScreenManager1.CloseWaitForm()
        infoCustom("Update status completed")
        Close()
    End Sub
End Class