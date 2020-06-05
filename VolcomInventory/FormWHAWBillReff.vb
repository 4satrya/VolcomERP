Public Class FormWHAWBillReff
    Private Sub FormWHAWBillReff_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Sub view_store()
        If GVDOERP.RowCount > 0 Then
            SLEComp.Visible = True
            BLoad2.Visible = True
            Dim q As String = "SELECT c.id_comp,c.comp_number,c.comp_name
FROM tb_m_comp c
WHERE c.id_commerce_type=2 AND c.id_comp_cat=6 AND c.id_comp_group='" & GVDOERP.GetRowCellValue(0, "id_comp_group").ToString & "'"
            viewSearchLookupQuery(SLEComp, q, "id_comp", "comp_name", "id_comp")
        Else
            SLEComp.Visible = False
            BLoad2.Visible = False
        End If
    End Sub

    Private Sub BLoad_Click(sender As Object, e As EventArgs) Handles BLoad.Click
        load_with_reff()
    End Sub

    Sub load_with_reff()
        If TEAWBReff.Text = "" Then
            warningCustom("Please input AWB Refference")
        Else
            Try
                Dim reff As String = addSlashes(TEAWBReff.Text)

                Dim group_desc As String = reff.Split("-")(0)
                Dim order_number As String = reff.Split("-")(1)

                Dim q As String = "SELECT d.id_pl_sales_order_del, c.id_comp_group, d.pl_sales_order_del_number AS `do_no`, comb.combine_number, d.pl_sales_order_del_date AS `scan_date`, 
c.comp_number AS `store_number`,c.id_commerce_type,c.id_sub_district,IF(so.is_export_awb=1,'Exported to CSSS','Not yet exported') AS is_export_awb,IFNULL(awbh.id_awbill,'') AS collie_number,c.id_comp, c.comp_name AS `store_name`, SUM(dd.pl_sales_order_del_det_qty) AS `qty`, 'no' AS `is_check`, stt.report_status,so.shipping_city,c.id_commerce_type
FROM tb_pl_sales_order_del d
INNER JOIN tb_sales_order so ON so.id_sales_order=d.id_sales_order
LEFT JOIN tb_pl_sales_order_del_combine comb ON comb.id_combine = d.id_combine
INNER JOIN tb_m_comp_contact cc ON cc.id_comp_contact = d.id_store_contact_to
INNER JOIN tb_m_comp c ON c.id_comp = cc.id_comp
INNER JOIN tb_m_comp_group cg ON cg.`id_comp_group`=c.`id_comp_group`
LEFT JOIN tb_pl_sales_order_del_det dd ON dd.id_pl_sales_order_del = d.id_pl_sales_order_del
LEFT JOIN tb_wh_awbill_det awb ON awb.id_pl_sales_order_del = d.id_pl_sales_order_del
LEFT JOIN tb_wh_awbill awbh ON awbh.id_awbill=awb.id_awbill
INNER JOIN tb_lookup_report_status stt ON stt.id_report_status = d.id_report_status
WHERE (d.id_report_status=3 OR d.id_report_status=6) AND cg.`comp_group`='" & addSlashes(group_desc) & "' AND so.`sales_order_ol_shop_number`='" & addSlashes(order_number) & "'
GROUP BY d.id_pl_sales_order_del"
                Dim dt As DataTable = execute_query(q, -1, True, "", "", "", "")
                If dt.Rows.Count = 0 Then
                    warningCustom("Reffrence number/delivery not found")
                Else
                    GCDOERP.DataSource = dt
                    GVDOERP.BestFitColumns()
                End If
                view_store()
            Catch ex As Exception
                warningCustom("Reffrence number/delivery not found")
            End Try
        End If
    End Sub

    Private Sub BPick_Click(sender As Object, e As EventArgs) Handles BPick.Click
        'check bukan dari toko berbeda
        If GVDOERP.RowCount = 0 Then
            warningCustom("No DO found.")
        Else
            GVDOERP.ActiveFilterString = "[collie_number] = ''"
            Dim problem As Boolean = False
            If GVDOERP.RowCount = 0 Then
                warningCustom("All DO already have collie number.")
                problem = True
            Else
                For i As Integer = 0 To GVDOERP.RowCount - 1
                    If Not GVDOERP.GetRowCellValue(i, "id_comp").ToString = GVDOERP.GetRowCellValue(0, "id_comp").ToString Then
                        warningCustom("Pastikan semua tujuan toko sama.")
                        problem = True
                        Exit For
                    ElseIf GVDOERP.GetRowCellValue(i, "is_export_awb").ToString = "Not yet exported" Then
                        warningCustom("Order need export to AWB first")
                        problem = True
                        Exit For
                    End If
                Next
            End If
            '
            If Not problem Then
                FormWHAWBillDet.opt = "From DO AWB"
                FormWHAWBillDet.id_awb_type = "1"
                FormWHAWBillDet.ShowDialog()
            Else
                GVDOERP.ActiveFilterString = ""
            End If

        End If
    End Sub

    Private Sub BLoad2_Click(sender As Object, e As EventArgs) Handles BLoad2.Click
        If TEAWBReff.Text = "" Then
            warningCustom("Please input AWB Refference")
        Else
            Try
                Dim reff As String = addSlashes(TEAWBReff.Text)

                Dim group_desc As String = reff.Split("-")(0)
                Dim order_number As String = reff.Split("-")(1)

                Dim q As String = "SELECT d.id_pl_sales_order_del, c.id_comp_group, d.pl_sales_order_del_number AS `do_no`, comb.combine_number, d.pl_sales_order_del_date AS `scan_date`, 
c.comp_number AS `store_number`,c.id_commerce_type,c.id_sub_district,IF(so.is_export_awb=1,'Exported to CSSS','Not yet exported') AS is_export_awb,IFNULL(awbh.id_awbill,'') AS collie_number,c.id_comp, c.comp_name AS `store_name`, SUM(dd.pl_sales_order_del_det_qty) AS `qty`, 'no' AS `is_check`, stt.report_status,so.shipping_city,c.id_commerce_type
FROM tb_pl_sales_order_del d
INNER JOIN tb_sales_order so ON so.id_sales_order=d.id_sales_order
LEFT JOIN tb_pl_sales_order_del_combine comb ON comb.id_combine = d.id_combine
INNER JOIN tb_m_comp_contact cc ON cc.id_comp_contact = d.id_store_contact_to
INNER JOIN tb_m_comp c ON c.id_comp = cc.id_comp AND c.id_comp='" & SLEComp.EditValue.ToString & "'
INNER JOIN tb_m_comp_group cg ON cg.`id_comp_group`=c.`id_comp_group`
LEFT JOIN tb_pl_sales_order_del_det dd ON dd.id_pl_sales_order_del = d.id_pl_sales_order_del
LEFT JOIN tb_wh_awbill_det awb ON awb.id_pl_sales_order_del = d.id_pl_sales_order_del
LEFT JOIN tb_wh_awbill awbh ON awbh.id_awbill=awb.id_awbill
INNER JOIN tb_lookup_report_status stt ON stt.id_report_status = d.id_report_status
WHERE (d.id_report_status=3 OR d.id_report_status=6) AND cg.`comp_group`='" & addSlashes(group_desc) & "' AND so.`sales_order_ol_shop_number`='" & addSlashes(order_number) & "'
GROUP BY d.id_pl_sales_order_del"
                Dim dt As DataTable = execute_query(q, -1, True, "", "", "", "")
                If dt.Rows.Count = 0 Then
                    warningCustom("Reffrence number/delivery not found for this store")
                Else
                    GCDOERP.DataSource = dt
                    GVDOERP.BestFitColumns()
                End If
            Catch ex As Exception
                warningCustom("Reffrence number/delivery not found  for this store")
            End Try
        End If
    End Sub

    Private Sub TEAWBReff_KeyDown(sender As Object, e As KeyEventArgs) Handles TEAWBReff.KeyDown
        If e.KeyCode = Keys.Enter Then
            load_with_reff()
        End If
    End Sub
End Class