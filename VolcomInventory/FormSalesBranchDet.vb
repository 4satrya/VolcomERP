Public Class FormSalesBranchDet
    Public id As String = "-1"
    Public action As String = "-1"
    Public rmt As String = "254"
    Public id_report_status As String = "1"

    Private Sub FormSalesBranchDet_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        viewReportStatus()
        viewCoaTag
        actionLoad()
    End Sub

    Sub viewReportStatus()
        Dim query As String = "SELECT * FROM tb_lookup_report_status a ORDER BY a.id_report_status "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        viewLookupQuery(LEReportStatus, query, 0, "report_status", "id_report_status")
    End Sub

    Sub viewCoaTag()
        Dim query As String = "SELECT ct.id_coa_tag, ct.tag_code, ct.tag_description 
        FROM tb_coa_tag ct WHERE ct.id_coa_tag>1 ORDER BY ct.id_coa_tag ASC "
        viewSearchLookupQuery()
    End Sub

    Sub actionLoad()

    End Sub
End Class