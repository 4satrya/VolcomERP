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

    Private Sub insertFinalComment(ByVal rmt As String, ByVal id_report As String, ByVal id_report_status As String, ByVal comment As String)
        If id_report_status = "6" Then
            Dim query As String = "INSERT INTO tb_report_mark_final_comment(report_mark_type, id_report, id_report_status, id_user, final_comment, final_comment_date, ip_user) VALUES "
            query += "('" + rmt + "', '" + id_report + "', '" + id_report_status + "', '143', '" + comment + "', NOW(), '192.168.1.205') "
            execute_non_query(query, True, "", "", "", "")
        End If
    End Sub

    Sub sendEmailConfirmationFinal(ByVal id_commerce_type As String, ByVal id_report As String, ByVal id_status_reportx As String)
        If id_commerce_type = "2" And id_status_reportx = "6" Then
            'only online store
            Dim query As String = "SELECT del.id_pl_sales_order_del, del.pl_sales_order_del_number AS `del_number`, 
                DATE_FORMAT(del.pl_sales_order_del_date, '%d %M %Y') AS `scan_date`, DATE_FORMAT(fcom.final_comment_date,'%d %M %Y %H:%i') AS `del_date`,
                so.sales_order_number AS `order_number`, so.sales_order_ol_shop_number AS `ol_store_order_number`, DATE_FORMAT(so.sales_order_date,'%d %M %Y') AS `order_date`, so.customer_name,
                CONCAT(s.comp_number, ' - ', s.comp_name) AS `store`, sg.comp_group AS `store_group_code`, sg.description AS `store_group`
                FROM tb_pl_sales_order_del del 
                INNER JOIN tb_m_comp_contact sc ON sc.id_comp_contact = del.id_store_contact_to
                INNER JOIN tb_m_comp s ON s.id_comp = sc.id_comp
                INNER JOIN tb_m_comp_group sg ON sg.id_comp_group = s.id_comp_group
                INNER JOIN tb_report_mark_final_comment fcom ON fcom.id_report = del.id_pl_sales_order_del AND fcom.report_mark_type=43
                INNER JOIN tb_sales_order so ON so.id_sales_order = del.id_sales_order
                WHERE del.id_pl_sales_order_del='" + id_report + "' "
            Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
            If data.Rows.Count > 0 Then
                Try
                    Dim em As New ClassSendEmail
                    em.report_mark_type = "43_confirm"
                    em.id_report = id_report
                    em.dt = data
                    em.send_email()
                Catch ex As Exception
                    Dim qerr As String = "INSERT INTO tb_error_mail(date,description, note_penyelesaian) VALUES(NOW(), 'Failed send delivery confirmation; id del:" + id_report + "; error:" + addSlashes(ex.ToString) + "', ''); "
                    execute_non_query(qerr, True, "", "", "", "")
                End Try
            End If
        End If
    End Sub

    Sub updateStatusOnlineStoreVIOS(ByVal id_commerce_type As String, ByVal id_store As String, ByVal id_report As String, ByVal id_web_order As String, ByVal id_report_status As String)
        If id_report_status = "6" Then
            'And (id_store = id_volcomstore_normal Or id_store = id_volcomstore_sale)
            If id_commerce_type = "2" Then
                Dim so As New ClassSalesOrder
                Dim shopify_comp_group As String = get_setup_field("shopify_comp_group")
                Try
                    Dim shopify_tracking_comp As String = get_setup_field("shopify_tracking_comp")
                    Dim shopify_tracking_url As String = get_setup_field("shopify_tracking_url")
                    Dim track_number As String = execute_query("SELECT m.awbill_no FROM tb_wh_awbill_det d INNER JOIN tb_wh_awbill m ON m.id_awbill = d.id_awbill WHERE d.id_pl_sales_order_del=" + id_report + "", 0, True, "", "", "", "")
                    Dim query As String = "SELECT sod.ol_store_id, CAST(SUM(sod.sales_order_det_qty) AS DECIMAL(10,0)) AS `qty`, so.id_sales_order_ol_shop AS `id_web_order`, o.shopify_location_id AS `location_id`
                FROM tb_pl_sales_order_del_det d
                INNER JOIN tb_sales_order_det sod ON sod.id_sales_order_det = d.id_sales_order_det
                INNER JOIN tb_sales_order so ON so.id_sales_order = sod.id_sales_order
                JOIN tb_opt o 
                WHERE d.id_pl_sales_order_del=" + id_report + " AND sod.is_additional=2
                GROUP BY sod.ol_store_id "
                    Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
                    Dim val As String = ""
                    Dim location_id As String = ""
                    For i As Integer = 0 To data.Rows.Count - 1
                        location_id = data.Rows(i)("location_id").ToString
                        If i > 0 Then
                            val += ","
                        End If
                        val += "{
        ""id"": " + data.Rows(i)("ol_store_id").ToString + ",
""quantity"": " + data.Rows(i)("qty").ToString + "
      }"
                    Next
                    If val <> "" Then
                        Dim shop As New ClassShopifyApi()
                        shop.set_fullfill(id_web_order, location_id, track_number, val, shopify_tracking_comp, shopify_tracking_url)
                    End If
                Catch ex As Exception
                    so.insertLogWebOrder(id_web_order, "ID DEL:" + id_report + "; Error Set Fullfillment:" + ex.ToString, shopify_comp_group)
                End Try

                Try
                    'insert status 
                    Dim qstt As String = "INSERT IGNORE INTO tb_sales_order_det_status(id_sales_order_det, `status`, status_date, input_status_date)
                SELECT sod.id_sales_order_det, 'shipped', NOW(), NOW()
                FROM tb_pl_sales_order_del_det d
                INNER JOIN tb_sales_order_det sod ON sod.id_sales_order_det = d.id_sales_order_det
                INNER JOIN tb_sales_order so ON so.id_sales_order = sod.id_sales_order
                JOIN tb_opt o 
                WHERE d.id_pl_sales_order_del=" + id_report + " AND sod.is_additional=2 "
                    execute_non_query(qstt, True, "", "", "", "")
                Catch ex As Exception
                    so.insertLogWebOrder(id_web_order, "ID DEL:" + id_report + "; Error Set Status:" + ex.ToString, shopify_comp_group)
                End Try
            End If
        End If
    End Sub

    Private Sub BtnOther_Click(sender As Object, e As EventArgs) Handles BtnOther.Click
        '        Dim id_report_par As String = "97043"
        '        Dim id_status_reportx_par As String = "6"
        '        Dim qs As String = "SELECT c.id_comp,pl.`id_pl_sales_order_del`,so.`id_sales_order_ol_shop`,c.`id_commerce_type`,c.`is_use_unique_code` FROM tb_pl_sales_order_del pl
        'INNER JOIN tb_sales_order so ON so.`id_sales_order`=pl.`id_sales_order`
        'INNER JOIN tb_m_comp_contact cc ON cc.`id_comp_contact`=so.`id_store_contact_to`
        'INNER JOIN tb_m_comp c ON c.`id_comp`=cc.`id_comp`
        'WHERE pl.id_pl_sales_order_del='" + id_report_par + "'"
        '        Dim dts As DataTable = execute_query(qs, -1, True, "", "", "", "")

        '        'ini harus di uncomment nanti
        '        insertFinalComment("43", id_report_par, id_status_reportx_par, "Complete by scan security")
        '        sendEmailConfirmationFinal(dts.Rows(0)("id_commerce_type").ToString, id_report_par, id_status_reportx_par)
        '        updateStatusOnlineStoreVIOS(dts.Rows(0)("id_commerce_type").ToString, dts.Rows(0)("id_comp").ToString, id_report_par, dts.Rows(0)("id_sales_order_ol_shop").ToString, id_status_reportx_par)

        'set auto cn/ror
        'Try
        '    Dim qcr As String = "SELECT olr.id_sales_order, olr.id_sales_pos, olr.order_number
        '                        FROM tb_ol_store_return_order olr
        '                        WHERE olr.is_process=2 AND olr.is_manual_sync=2 AND !ISNULL(olr.id_sales_order) AND !ISNULL(olr.id_sales_pos)
        '                        GROUP BY olr.id_sales_order, olr.id_sales_pos
        '                        ORDER BY olr.created_date ASC "
        '    Dim dcr As DataTable = execute_query(qcr, -1, True, "", "", "", "")
        '    If Not FormMain.SplashScreenManager1.IsSplashFormVisible Then
        '        FormMain.SplashScreenManager1.ShowWaitForm()
        '    End If
        '    For c As Integer = 0 To dcr.Rows.Count - 1
        '        FormMain.SplashScreenManager1.SetWaitFormDescription((c + 1).ToString + " of " + dcr.Rows.Count.ToString)
        '        'cmos.insertLog(sch_input, "auto_cn_ror_" + dcr.Rows(c)("order_number").ToString)
        '        execute_non_query_long("CALL create_ol_store_cn_ror(" + dcr.Rows(c)("id_sales_order").ToString + ", " + dcr.Rows(c)("id_sales_pos").ToString + "); ", True, "", "", "", "")
        '    Next
        '    FormMain.SplashScreenManager1.CloseWaitForm()
        'Catch ex As Exception
        '    'cmos.insertLog(sch_input, "err_cn_ror;" + ex.ToString)
        'End Try
        'set tag promo manual
        'Dim id_report As String = "0"
        'Dim ql As String = "SELECT s.id_prod_shopify, p.id_design , m.tag,lh.`log`
        'FROM tb_ol_promo_collection_sku s
        'INNER JOIN tb_ol_promo_collection m ON m.id_ol_promo_collection = s.id_ol_promo_collection
        'INNER JOIN tb_m_product p ON p.id_product = s.id_product
        'LEFT JOIN (
        ' SELECT l.id_design, l.`log` 
        ' FROM tb_ol_promo_collection_log l 
        ' WHERE l.id_ol_promo_collection=" + id_report + "
        ' GROUP BY l.id_design
        ') lh ON lh.id_design = p.id_design
        'WHERE s.id_ol_promo_collection=" + id_report + " 
        'AND !ISNULL(lh.log) 
        'AND lh.`log`<>'OK'
        'GROUP BY s.id_prod_shopify "
        'Dim dl As DataTable = execute_query(ql, -1, True, "", "", "", "")
        '   If Not FormMain.SplashScreenManager1.IsSplashFormVisible Then
        'FormMain.SplashScreenManager1.ShowWaitForm()
        'End If
        'For l As Integer = 0 To dl.Rows.Count - 1
        '    FormMain.SplashScreenManager1.SetWaitFormDescription((l + 1).ToString + " of " + dl.Rows.Count.ToString)
        '    Dim prod_id As String = dl.Rows(l)("id_prod_shopify").ToString
        '    Dim id_design_curr As String = dl.Rows(l)("id_design").ToString
        '    Try
        '        Dim s As New ClassShopifyApi()
        '        Dim tag As String = s.get_tag(prod_id)
        '        Dim tag_save As String = ""
        '        If tag <> "" Then
        '            tag_save = tag + "," + dl.Rows(l)("tag").ToString
        '        Else
        '            tag_save = dl.Rows(l)("tag").ToString
        '        End If
        '        s.set_tag(prod_id, tag_save)
        '        execute_non_query("INSERT tb_ol_promo_collection_log(id_ol_promo_collection, type, id_design, log, log_date)
        '                VALUES('" + id_report + "', 1, '" + id_design_curr + "', 'OK', NOW()); ", True, "", "", "", "")
        '    Catch ex As Exception
        '        execute_non_query("INSERT tb_ol_promo_collection_log(id_ol_promo_collection, type, id_design, log, log_date)
        '                VALUES('" + id_report + "', 1, '" + id_design_curr + "', '" + addSlashes(ex.ToString) + "', NOW()); ", True, "", "", "", "")
        '    End Try
        'Next
        'FormMain.SplashScreenManager1.CloseWaitForm()
        'FormTempTable.ShowDialog()
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