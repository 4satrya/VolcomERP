Public Class FormProdDemandHist 

    Public id_dsg_param As String = "-1"

    Private Sub FormProdDemandHist_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim query_c As ClassProdDemand = New ClassProdDemand()
        Dim query As String = query_c.queryFindDsg(id_dsg_param)
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCProdDemand.DataSource = data
    End Sub

    Private Sub GVProdDemand_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GVProdDemand.DoubleClick
        If GVProdDemand.RowCount > 0 Then
            Cursor = Cursors.WaitCursor
            Dim id_pd_par As String = "0"
            Try
                id_pd_par = GVProdDemand.GetFocusedRowCellValue("id_prod_demand").ToString
            Catch ex As Exception
            End Try
            If id_pd_par = "0" Or id_pd_par = "" Then
                stopCustom("Document not found")
            Else
                Dim querty_c As ClassShowPopUp = New ClassShowPopUp()
                querty_c.id_report = id_pd_par
                querty_c.report_mark_type = "9"
                querty_c.show()
            End If
            Cursor = Cursors.Default
        End If
    End Sub

    Private Sub FormProdDemandHist_FormClosed(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub BtnPrint_Click(sender As Object, e As EventArgs) Handles BtnPrint.Click
        Cursor = Cursors.WaitCursor
        print(GCProdDemand, "HISTORY PD")
        Cursor = Cursors.Default
    End Sub
End Class