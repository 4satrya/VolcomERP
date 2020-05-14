﻿Public Class FormOLStoreBrowseOrder
    Private Sub FormOLStoreBrowseOrder_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        viewBrowseOrder()
    End Sub

    Sub viewBrowseOrder()
        Cursor = Cursors.WaitCursor
        Dim query As String = "SELECT so.sales_order_ol_shop_number AS `order_number`, so.sales_order_ol_shop_date AS `order_date`, so.customer_name, a.rec_by_store_date
        FROM tb_wh_awbill a
        INNER JOIN tb_wh_awbill_det ad ON ad.id_awbill = a.id_awbill
        INNER JOIN tb_pl_sales_order_del d ON d.id_pl_sales_order_del = ad.id_pl_sales_order_del
        INNER JOIN tb_sales_order so ON so.id_sales_order = d.id_sales_order
        INNER JOIN tb_m_comp_contact cc ON cc.id_comp_contact = d.id_store_contact_to
        INNER JOIN tb_m_comp c ON c.id_comp = cc.id_comp
        WHERE c.id_commerce_type=2 AND c.id_comp_group=" + FormRequestRetOLStore.SLECompGroup.EditValue.ToString + "
        GROUP BY so.sales_order_number "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCData.DataSource = data
        Cursor = Cursors.Default
    End Sub

    Private Sub FormOLStoreBrowseOrder_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub BtnChoose_Click(sender As Object, e As EventArgs) Handles BtnChoose.Click
        MsgBox(GVData.GetFocusedRowCellValue("rec_by_store_date").ToString)
    End Sub
End Class