﻿Public Class FormSuperUser

    Private Sub BtnConn_Click(sender As Object, e As EventArgs) Handles BtnConn.Click
        Close()
        FormDatabase.id_type = "1"
        FormDatabase.ShowDialog()
    End Sub

    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs) Handles SimpleButton1.Click
        barcodeaa.ShowDialog()
    End Sub

    Public Shared Function Between(ByVal src As String, ByVal findfrom As String, ByVal findto As String) As String
        Dim start As Integer = src.IndexOf(findfrom)
        Dim [to] As Integer = src.IndexOf(findto, start + findfrom.Length)
        If start < 0 OrElse [to] < 0 Then Return ""
        Dim s As String = src.Substring(start + findfrom.Length, [to] - start - findfrom.Length)
        Return s
    End Function

    Private Sub BtnOther_Click(sender As Object, e As EventArgs) Handles BtnOther.Click
        'stock card for listed
        Dim qi As String = ""
        Dim qsi As String = ""

        'stock card
        qsi = "SELECT prd.id_purc_rec,prd.id_purc_rec_det,'148' AS report_mark_type,req.id_departement,reqd.id_item,reqd.item_detail,reqd.remark,SUM(prd.qty) AS qty,reqd.id_item
FROM tb_purc_rec_det prd
INNER JOIN tb_purc_order_det pod ON pod.`id_purc_order_det`=prd.`id_purc_order_det`
INNER JOIN tb_purc_req_det reqd ON reqd.`id_purc_req_det`=pod.`id_purc_req_det`
INNER JOIN tb_purc_req req ON req.`id_purc_req`=reqd.`id_purc_req`
INNER JOIN tb_item it ON it.id_item=reqd.id_item AND reqd.is_dep_stock_card=1
WHERE prd.`id_purc_rec`='631'
GROUP BY prd.id_purc_rec_det,reqd.`id_item`,reqd.item_detail,reqd.remark"
        Dim dtsi As DataTable = execute_query(qsi, -1, True, "", "", "", "")
        For i As Integer = 0 To dtsi.Rows.Count - 1
            Dim id_item_detail As String = ""
            'insert ignore
            qi = "SELECT id_item_detail FROM tb_stock_card_dep_item WHERE `id_item`='" & dtsi.Rows(i)("id_item").ToString & "' AND `item_detail`='" & addSlashes(dtsi.Rows(i)("item_detail").ToString) & "' AND `remark`='" & addSlashes(dtsi.Rows(i)("remark").ToString) & "'"
            Dim dti As DataTable = execute_query(qi, -1, True, "", "", "", "")

            If dti.Rows.Count > 0 Then
                id_item_detail = dti.Rows(0)("id_item_detail").ToString
            Else
                qi = "INSERT INTO tb_stock_card_dep_item(`id_item`,`item_detail`,`remark`)
VALUES('" & dtsi.Rows(i)("id_item").ToString & "','" & addSlashes(dtsi.Rows(i)("item_detail").ToString) & "','" & addSlashes(dtsi.Rows(i)("remark").ToString) & "'); SELECT LAST_INSERT_ID();"
                id_item_detail = execute_query(qi, 0, True, "", "", "", "")
            End If

            'insert qty
            qi = "INSERT INTO `tb_stock_card_dep`(`id_departement`,`id_item_detail`,`id_report`,`id_report_det`,`report_mark_type`,`qty`,storage_item_datetime)
VALUES('" & dtsi.Rows(i)("id_departement").ToString & "','" & id_item_detail & "','" & dtsi.Rows(i)("id_purc_rec").ToString & "','" & dtsi.Rows(i)("id_purc_rec_det").ToString & "','" & dtsi.Rows(i)("report_mark_type").ToString & "','" & decimalSQL(Decimal.Parse(dtsi.Rows(i)("qty").ToString)) & "',NOW())"
            execute_non_query(qi, True, "", "", "", "")
        Next

        'gen stiker
        '        Dim q As String = "SELECT so.sales_order_ol_shop_number 
        'FROM tb_sales_order so 
        'INNER JOIN tb_m_comp_contact cc ON cc.id_comp_contact = so.id_store_contact_to
        'INNER JOIN tb_m_comp c ON c.id_comp = cc.id_comp
        'WHERE c.id_comp_group=76 AND so.sales_order_date='2021-01-04'
        'GROUP BY so.id_sales_order_ol_shop
        'ORDER BY so.id_sales_order_ol_shop ASC"
        '        Dim dt As DataTable = execute_query(q, -1, True, "", "", "", "")
        '        For i As Integer = 0 To dt.Rows.Count - 1
        '            execute_non_query_long("CALL create_ol_gwp_order(76,'" + dt.Rows(i)("sales_order_ol_shop_number").ToString + "');", True, "", "", "", "")
        '        Next
        '        Dim q As String = "SELECT pos.`id_sales_pos`,pos.`report_mark_type`,pos.`sales_pos_total`,a.id_acc_trans FROM `tb_a_acc_trans` a
        'LEFT JOIN tb_a_acc_trans_det ad ON ad.`id_acc_trans`=a.`id_acc_trans`
        'INNER JOIN tb_sales_pos pos ON pos.`sales_pos_number`=a.`report_number`
        'WHERE a.`id_acc_trans`>=40855 AND ISNULL(ad.`id_acc_trans_det`)
        'AND pos.`sales_pos_total`>0"
        '        Dim dt As DataTable = execute_query(q, -1, True, "", "", "", "")
        '        For i As Integer = 0 To dt.Rows.Count - 1
        '            q = "INSERT INTO tb_a_acc_trans_det(id_acc_trans, id_acc, id_comp, qty, debit, credit, acc_trans_det_note, report_mark_type, id_report, report_number, id_status_open) 
        '	SELECT '" & dt.Rows(i)("id_acc_trans").ToString & "', d.id_acc, d.id_comp, d.qty, d.debit, d.credit, d.acc_trans_det_note, d.report_mark_type, d.id_report, d.report_number, '1'
        '	FROM tb_a_acc_trans_draft d
        '	WHERE d.report_mark_type='" & dt.Rows(i)("report_mark_type").ToString & "' AND d.id_report='" & dt.Rows(i)("id_sales_pos").ToString & "';
        '	UPDATE tb_a_acc_trans_draft SET id_status_open=2 WHERE report_mark_type='" & dt.Rows(i)("report_mark_type").ToString & "' AND id_report='" & dt.Rows(i)("id_sales_pos").ToString & "';"
        '            execute_non_query(q, True, "", "", "", "")
        '        Next

        'cek api
        'Dim bli As New ClassBliBliApi()
        'bli.get_order_list()
        'Dim za As New ClassZaloraApi()
        'Dim dt As DataTable = za.get_order_detail("3742719")
        'For d As Integer = 0 To dt.Rows.Count - 1
        '    Console.WriteLine("Item id : " + dt.Rows(d)("item_id").ToString + "; Status : " + dt.Rows(d)("status").ToString + "; Updated At : " + dt.Rows(d)("updated_at").ToString)
        'Next
        'za.getOrder2020()
        'za.setTrackingNumber("3727702")
        'za.setInvoiceNumber("3727702", "218433179")
        'za.setReadyToShip("6214692", "RPX - MARKETPLACE", "799938234220")


        'manual fullfilled
        'Dim q As String = "SELECT d.id_pl_sales_order_del AS `id_report`,c.id_commerce_type, c.id_comp AS `id_store`, so.id_sales_order_ol_shop AS `id_web_order`
        'FROM tb_pl_sales_order_del d 
        'INNER JOIN tb_sales_order so ON so.id_sales_order = d.id_sales_order
        'INNER JOIN tb_m_comp_contact cc ON cc.id_comp_contact = d.id_store_contact_to
        'INNER JOIN tb_m_comp c ON c.id_comp = cc.id_comp
        'WHERE d.pl_sales_order_del_number='" + addSlashes(TextEdit1.Text.ToString) + "' "
        'Dim data As DataTable = execute_query(q, -1, True, "", "", "", "")
        'Dim f As New FormChangeStatus()
        'f.id_pop_up = "2"
        'Dim id_volcomstore_normal As String = execute_query("SELECT v.id_store FROM tb_m_comp_volcom_ol v WHERE v.id_design_cat=1", 0, True, "", "", "", "")
        'Dim id_volcomstore_sale As String = execute_query("SELECT v.id_store FROM tb_m_comp_volcom_ol v WHERE v.id_design_cat=2", 0, True, "", "", "", "")
        'f.id_volcomstore_normal = id_volcomstore_normal
        'f.id_volcomstore_sale = id_volcomstore_sale
        'f.updateStatusOnlineStore(data.Rows(0)("id_commerce_type").ToString, data.Rows(0)("id_store").ToString, data.Rows(0)("id_report").ToString, data.Rows(0)("id_web_order").ToString)

        'create ship invoice
        'Dim shp As New ClassShipInvoice()
        'shp.id_invoice_ship = "-1"
        'shp.create("25081")

        'Dim a As New ClassShopifyApi()
        'a.get_product()

        'fulfill
        '        Dim so As New ClassSalesOrder
        '        Try
        '            Dim shopify_tracking_comp As String = get_setup_field("shopify_tracking_comp")
        '            Dim shopify_tracking_url As String = get_setup_field("shopify_tracking_url")
        '            Dim track_number As String = execute_query("SELECT m.awbill_no FROM tb_wh_awbill_det d INNER JOIN tb_wh_awbill m ON m.id_awbill = d.id_awbill WHERE d.id_pl_sales_order_del=72192", 0, True, "", "", "", "")
        '            Dim query As String = "SELECT sod.ol_store_id, CAST(SUM(sod.sales_order_det_qty) AS DECIMAL(10,0)) AS `qty`, so.id_sales_order_ol_shop AS `id_web_order`, o.shopify_location_id AS `location_id`
        '                FROM tb_pl_sales_order_del_det d
        '                INNER JOIN tb_sales_order_det sod ON sod.id_sales_order_det = d.id_sales_order_det
        '                INNER JOIN tb_sales_order so ON so.id_sales_order = sod.id_sales_order
        '                JOIN tb_opt o 
        '                WHERE d.id_pl_sales_order_del=72192 AND sod.is_additional=2
        '                GROUP BY sod.ol_store_id "
        '            Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        '            Dim val As String = ""
        '            Dim location_id As String = ""
        '            For i As Integer = 0 To data.Rows.Count - 1
        '                location_id = data.Rows(i)("location_id").ToString
        '                If i > 0 Then
        '                    val += ","
        '                End If
        '                val += "{
        '        ""id"": " + data.Rows(i)("ol_store_id").ToString + ",
        '""quantity"": " + data.Rows(i)("qty").ToString + "
        '      }"
        '            Next
        '            If val <> "" Then
        '                Dim shop As New ClassShopifyApi()
        '                shop.set_fullfill("2121944924196", location_id, track_number, val, shopify_tracking_comp, shopify_tracking_url)
        '            End If
        '        Catch ex As Exception
        '            so.insertLogWebOrder("2121944924196", "ID DEL:72192; Error Set Fullfillment:" + ex.ToString)
        '        End Try

        'FormUniqueCode.Show()
        'FormStockUniS78New.ShowDialog()
        'FormTestCheckvb.ShowDialog()
        'Dim nm As New ClassSendEmail
        'nm.par1 = TextEdit1.Text
        'nm.report_mark_type = "186"
        'nm.send_email()

        'send mail pre final
        'Dim nm As New ClassSendEmail
        'nm.par1 = "5255"
        'nm.report_mark_type = "186"
        'nm.send_email()

        'send mail final
        'Dim nm As New ClassSendEmail
        'nm.par1 = "5543"
        'nm.report_mark_type = "185"
        'nm.send_email()

        'Dim mail As ClassSendEmail = New ClassSendEmail()
        'mail.report_mark_type = "96"
        'mail.send_email_appr("96", "6978", True)

        'Dim nm As New ClassSendEmail
        'nm.report_mark_type = "test"
        'nm.send_email()

        'FormNtwainCoba.ShowDialog()
        'FormTest.ShowDialog()

        'Dim webClient As New Net.WebClient
        'Dim result As String = webClient.DownloadString("http://www.fiskal.kemenkeu.go.id/dw-kurs-db.asp")
        'Dim str_kurs_dec As String = Between(result, "Dolar Amerika Serikat (USD)</td><td class='text-right'>", " <img src='data/aimages/up.gif'>").Replace(",", "").Replace(" ", "")
        ''asset
        'Dim qa As String = "Select rd.id_item, rd.id_purc_rec_det, rd.qty, coa.id_coa_out, rq.id_departement, i.item_desc, NOW(), (pod.`value` - pod.discount) As `cost`, 2
        '        FROM tb_purc_rec_det rd
        '        INNER JOIN tb_purc_order_det pod ON pod.id_purc_order_det = rd.id_purc_order_det
        '        INNER JOIN tb_purc_req_det rqd ON rqd.id_purc_req_det = pod.id_purc_order_det
        '        INNER JOIN tb_purc_req rq ON rq.id_purc_req = rqd.id_purc_req
        '        INNER JOIN tb_item i ON i.id_item = rd.id_item
        '        INNER JOIN tb_item_cat cat ON cat.id_item_cat = i.id_item_cat
        '        INNER JOIN tb_lookup_expense_type et ON et.id_expense_type = cat.id_expense_type
        '        INNER JOIN tb_item_coa coa ON coa.id_item_cat = cat.id_item_cat AND coa.id_departement=rq.id_departement
        '        WHERE rd.id_purc_rec=" + TextEdit1.Text + " AND et.id_expense_type=2 "
        'Dim da As DataTable = execute_query(qa, -1, True, "", "", "", "")
        'If da.Rows.Count > 0 Then
        '    Dim ix As Integer = 0
        '    Dim qa_ins As String = "INSERT INTO tb_purc_rec_asset (`id_item`,`id_purc_rec_det`,`id_departement`, `id_acc_fa`,`asset_name`,`acq_date`,`acq_cost`) VALUES "
        '    For a As Integer = 0 To da.Rows.Count - 1
        '        For j As Integer = 1 To da.Rows(a)("qty")
        '            If ix > 0 Then
        '                qa_ins += ", "
        '            End If

        '            qa_ins += "('" + da.Rows(a)("id_item").ToString + "', '" + da.Rows(a)("id_purc_rec_det").ToString + "', '" + da.Rows(a)("id_departement").ToString + "', '" + da.Rows(a)("id_coa_out").ToString + "', '" + da.Rows(a)("item_desc").ToString + "', NOW(), '" + decimalSQL(da.Rows(a)("cost").ToString) + "') "
        '            ix += 1
        '        Next
        '    Next

        '    'ins 
        '    If ix > 0 Then
        '        execute_non_query(qa_ins, True, "", "", "", "")
        '    End If
        'End If

        'Dim f As New ClassFingerPrint
        'f.ip = "192.168.1.74"
        'f.port = "4370"
        'f.connect()
        'f.deleteUserInfo("1114005")
        'f.disconnect()



        'FormSetupDBStockTake.ShowDialog()
        'Dim mail As New ClassSendEmail()
        'mail.report_mark_type = "82"
        'mail.id_report = "229"
        'mail.date_string = "22 May 2018"
        'mail.comment = "PP/01/R32/MENS/19/V/18"
        'mail.send_email()
        'FormCardView.ShowDialog()
        'pushNotif("Percobaan 1", "Percobaan badge", "FormSalesOrderList", "7", "8", "225", "SO00206", "1")
        'pushNotif("Percobaan 2", "Percobaan badge", "FormSalesOrderList", "7", "8", "226", "SO00207", "1")
        'Dim query As String = "select * from tb_pl_sales_order_del_det a "
        'query += "inner join tb_m_product b on a.id_product = b.id_product "
        'query += "INNER JOIN tb_m_design c ON c.id_design = b.id_design "
        'query += "WHERE a.id_pl_sales_order_del='50' "
        'Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        'Dim stc As ClassStock = New ClassStock()
        'For i As Integer = 0 To data.Rows.Count - 1
        '    stc.prepInsStockFG("1", "2", data.Rows(i)("id_product").ToString, decimalSQL(data.Rows(i)("design_cop").ToString), "5", "50", decimalSQL(data.Rows(i)("pl_sales_order_del_det_qty").ToString), "", "1")
        'Next
        'stc.insStockFG()
        'infoCustom("berhasil")

        'Dim t As New ClassShowPopUp
        't.id_report = "5"
        't.report_mark_type = "28"
        't.show()

        'Dim t As ClassDepartement = New ClassDepartement("3")
        't.test()
        'FormFingerPrint.ShowDialog()
        'Show the report's preview. 
        'load data


        'Dim Report As New ReportEmpUni()
        '

        ' Create a data binding.
        ' Add the created binding to the binding collection of the lbUnitPrice label.
        'XrRichText1.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", dsNew, "customQuery.employee_name")})

        'Dim Tool As DevExpress.XtraReports.UI.ReportPrintTool = New DevExpress.XtraReports.UI.ReportPrintTool(Report)
        'Tool.ShowPreview()
        'Cursor = Cursors.WaitCursor
        'Dim query As String = "SELECT r.*, IFNULL(maxd.employee_name,'-') as last_mark, e.employee_name, IF(ISNULL(rm.id_report_mark),'No','Yes') AS `is_submit`
        'FROM tb_sales_return r
        'LEFT JOIN (
        ' (SELECT mark.id_report_mark,mark.id_report,emp.employee_name,maxd.report_mark_datetime,mark.report_number
        '     FROM tb_report_mark mark
        '     INNER JOIN tb_m_employee emp ON emp.`id_employee`=mark.id_employee
        '     INNER JOIN 
        '     (
        '        SELECT mark.id_report,mark.report_mark_type,MAX(report_mark_datetime) AS report_mark_datetime
        '        FROM tb_report_mark mark
        '        WHERE mark.id_mark='2' AND NOT ISNULL(report_mark_start_datetime) AND (report_mark_type='46' OR report_mark_type='113' OR report_mark_type='120' OR report_mark_type='111')
        '        GROUP BY report_mark_type,id_report
        '     ) maxd ON maxd.id_report=mark.id_report AND maxd.report_mark_type=mark.report_mark_type AND maxd.report_mark_datetime=mark.report_mark_datetime
        '     WHERE mark.id_mark='2' AND NOT ISNULL(mark.report_mark_start_datetime) AND (mark.report_mark_type='46' OR mark.report_mark_type='113' OR mark.report_mark_type='120' OR mark.report_mark_type='111')
        ' )
        ') maxd ON maxd.id_report = r.id_sales_return
        'INNER JOIN tb_m_user u ON u.id_user=r.last_update_by
        'INNER JOIN tb_m_employee e ON e.id_employee = u.id_employee
        'LEFT JOIN (
        ' SELECT rm.id_report_mark, rm.id_report
        ' FROM tb_report_mark rm
        ' WHERE (rm.report_mark_type='46' OR rm.report_mark_type='113' OR rm.report_mark_type='120' OR rm.report_mark_type='111') AND rm.id_report_status=1
        ' GROUP BY rm.id_report
        ') rm ON rm.id_report = r.id_sales_return
        'WHERE ISNULL(maxd.employee_name) AND r.id_report_status!=5 
        '-- AND r.sales_return_date='2018-03-07'
        'AND r.id_ret_type=4  "
        'Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        'For i As Integer = 0 To data.Rows.Count - 1
        '    submit_who_prepared("120", data.Rows(i)("id_sales_return").ToString, data.Rows(i)("last_update_by").ToString)
        'Next
        'Cursor = Cursors.Default
    End Sub

    Private Sub BtnDepartement_Click(sender As Object, e As EventArgs) Handles BtnDepartement.Click
        FormSuperUserDept.ShowDialog()
    End Sub

    Private Sub FormSuperUser_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub FormSuperUser_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        TxtHost.Text = app_host
        TxtDB.Text = app_database
    End Sub

    Private Sub BSendMessage_Click(sender As Object, e As EventArgs) Handles BSendMessage.Click
        FormSendMessage.ShowDialog()
    End Sub

    Private Sub BCalendar_Click(sender As Object, e As EventArgs)
        FormEmpCalendar.ShowDialog()
    End Sub

    Private Sub BtnOutlet_Click(sender As Object, e As EventArgs) Handles BtnOutlet.Click
        FormOutlet.ShowDialog()
    End Sub

    Private Sub BSubDep_Click(sender As Object, e As EventArgs) Handles BSubDep.Click
        FormSuperUserSubDept.ShowDialog()
    End Sub

    Private Sub BMockMark_Click(sender As Object, e As EventArgs) Handles BMockMark.Click
        FormSUMockMark.ShowDialog()
    End Sub

    Private Sub BtnSetupDBIA_Click(sender As Object, e As EventArgs) Handles BtnSetupDBIA.Click
        FormSetupDBStockTake.ShowDialog()
    End Sub
End Class