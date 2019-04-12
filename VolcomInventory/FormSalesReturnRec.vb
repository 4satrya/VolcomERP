Public Class FormSalesReturnRec
    Dim bnew_active As String = "1"
    Dim bedit_active As String = "1"
    Dim bdel_active As String = "1"

    Private Sub FormSalesReturnRec_Activated(sender As Object, e As EventArgs) Handles MyBase.Activated
        FormMain.show_rb(Name)
        check_menu()
    End Sub

    Private Sub FormSalesReturnRec_Deactivate(sender As Object, e As EventArgs) Handles MyBase.Deactivate
        FormMain.hide_rb()
    End Sub

    Sub check_menu()
        bnew_active = "1"
        bdel_active = "0"

        If GVList.RowCount >= 1 Then
            bedit_active = "1"
        Else
            bedit_active = "0"
        End If

        checkFormAccess(Name)
        button_main(bnew_active, bedit_active, bdel_active)
    End Sub

    Private Sub FormSalesReturnRec_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        DEFrom.EditValue = Now
        DEUntil.EditValue = Now

        load_list()
    End Sub

    Sub load_list()
        Dim dateFrom As String = ""
        Dim dateUntil As String = ""

        If DEFrom.EditValue IsNot Nothing Then
            dateFrom = Date.Parse(DEFrom.EditValue.ToString).ToString("yyyy-MM-dd")
        End If

        If DEUntil.EditValue IsNot Nothing Then
            dateUntil = Date.Parse(DEUntil.EditValue.ToString).ToString("yyyy-MM-dd")
        End If

        Dim query As String = "
            SELECT rr.id_sales_return_rec, rr.number, rr.do_number, (
                SELECT SUM(qty) qty FROM tb_sales_return_rec_det rrd WHERE rrd.id_sales_return_rec = rr.id_sales_return_rec
            ) total, DATE_FORMAT(rr.created_date, '%d %M %Y %h:%i %p') created_date, rs.report_status
            FROM tb_sales_return_rec rr 
            INNER JOIN tb_lookup_report_status rs ON rr.id_report_status = rs.id_report_status
            WHERE DATE(rr.created_date) >= '" + dateFrom + "' AND DATE(rr.created_date) <= '" + dateUntil + "'
        "

        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")

        GCList.DataSource = data

        GVList.BestFitColumns()

        check_menu()
    End Sub

    Private Sub GVList_DoubleClick(sender As Object, e As EventArgs) Handles GVList.DoubleClick
        FormSalesReturnRecDet.id = GVList.GetFocusedDataRow("id_sales_return_rec").ToString
        FormSalesReturnRecDet.ShowDialog()
    End Sub

    Private Sub SBView_Click(sender As Object, e As EventArgs) Handles SBView.Click
        load_list()
    End Sub
End Class