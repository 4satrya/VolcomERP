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
        'Dim nm As New ClassSendEmail
        'nm.par1 = TextEdit1.Text
        'nm.report_mark_type = "186"
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