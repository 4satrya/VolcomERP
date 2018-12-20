Public Class FormSalesReportTracking
    Private Sub FormSalesPOS_Activated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Activated
        FormMain.show_rb(Name)
    End Sub

    Private Sub FormSalesPOS_Deactivate(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Deactivate
        FormMain.hide_rb()
    End Sub

    Private Sub FormSalesReportTracking_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Sub load_data(ByVal id_comp As String, ByVal date_start As String, ByVal date_end As String, ByVal id_rep As String, ByVal island As String, ByVal id_comp_group As String, ByVal id_price_cat As String, ByVal id_promo As String, ByVal id_division As String, ByVal id_season As String, ByVal id_price_type As String)
        Dim query As String = "CALL sales_tracking('" & id_comp & "','" & date_start & "','" & date_end & "','" & id_rep & "','" & island & "','" & id_comp_group & "','" & id_price_cat & "','" & id_promo & "','" & id_division & "','" & id_season & "','" & id_price_type & "')"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        'Console.WriteLine(query)
        GCListDesign.DataSource = data
        BGVListDesign.BestFitColumns()
    End Sub

    Private Sub BSearch_Click(sender As Object, e As EventArgs) Handles BSearch.Click
        FormSalesReportTrackingParam.ShowDialog()
    End Sub

    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs) Handles SimpleButton1.Click
        print(GCListDesign, "Tracking List")
    End Sub
End Class