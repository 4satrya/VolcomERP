Public Class ReportCancelForm
    Public Shared id_report_mark_cancel As String = "-1"
    Public Shared dt As New DataTable

    Sub load_header()
        Dim query As String = "SELECT * FROM tb_report_mark_cancel WHERE id_report_mark_cancel='" & id_report_mark_cancel & "'"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        If data.Rows.Count > 0 Then
            LNumber.Text = data.Rows(0)("number").ToString()
            LDate.Text = Date.Parse(data.Rows(0)("created_datetime")).ToString("dd-MMMM-yyyy")
            LDirector.Text = get_emp(get_setup_field("id_emp_director"), "2")
            LCC.Text = get_emp(get_setup_field("id_user_cancel_management"), "3")
        End If
    End Sub

    Private Sub ReportCancelForm_BeforePrint(sender As Object, e As Printing.PrintEventArgs) Handles MyBase.BeforePrint
        load_header()
        Dim cf As New ClassShowPopUp()
        cf.id_report = id_report_mark_cancel
        cf.report_mark_type = "142"
        GCReportList.DataSource = dt
        '
        cf.apply_gv_style(GVReportList, "")
        '
        load_cancel_mark_horz("142", id_report_mark_cancel, "2", XrTable1)
    End Sub
End Class