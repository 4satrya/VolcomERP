Public Class FormSuperUser

    Private Sub BtnConn_Click(sender As Object, e As EventArgs) Handles BtnConn.Click
        Close()
        FormDatabase.id_type = "1"
        FormDatabase.ShowDialog()
    End Sub

    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs) Handles SimpleButton1.Click
        barcodeaa.ShowDialog()
    End Sub

    Private Sub BtnOther_Click(sender As Object, e As EventArgs) Handles BtnOther.Click
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
        FormSuperUsersubDept.ShowDialog()
    End Sub

    Private Sub BMockMark_Click(sender As Object, e As EventArgs) Handles BMockMark.Click
        Dim report_mark_type As String = "-1"
        Dim id_report As String = "-1"

        report_mark_type = "23"
        id_report = "3997"

        Dim showpopup As ClassShowPopUp = New ClassShowPopUp()
        showpopup.report_mark_type = report_mark_type
        showpopup.id_report = id_report
        showpopup.show()
    End Sub
End Class