Public Class ReportBOM
    Public Shared id_bom As String = "-1"
    Public Shared product_name As String = "-1"
    Public Shared bom_name As String = "-1"
    Public Shared bom_date As String = "-1"
    Public Shared bom_term As String = "-1"
    Public Shared id_pd As String = "-1"
    Public Shared qty_order As String = "1"

    Sub view_bom_mat()
        If id_pd = "-1" Then
            Try
                Dim query As String
                query = "CALL view_bom(" & id_bom & ")"
                Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
                GCBomMat.DataSource = data
            Catch ex As Exception
                errorConnection()
            End Try
            GridColumnCostPerPcs.Visible = False
            L1QtyOrder.Visible = False
            L2QtyOrder.Visible = False
            LQtyOrder.Visible = False
        Else 'from PD
            Try
                Dim query As String
                query = "CALL view_bom_design_list('" & id_pd & "','1')"
                Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
                GCBomMat.DataSource = data
                For i As Integer = 0 To data.Rows.Count - 1
                    If data.Rows(i)("is_ovh_main").ToString = "1" Then
                        LVendor.Text = data.Rows(i)("vendor").ToString
                    End If
                Next
            Catch ex As Exception
                errorConnection()
            End Try

            GridColumnCostPerPcs.Visible = True
            L1QtyOrder.Visible = True
            L2QtyOrder.Visible = True
            LQtyOrder.Visible = True
            LQtyOrder.Text = qty_order
        End If
        GridView1.ActiveFilterString = "[is_cost]=1"
        GridView1.BestFitColumns()
    End Sub

    Private Sub DetBomMat_BeforePrint(ByVal sender As System.Object, ByVal e As System.Drawing.Printing.PrintEventArgs) Handles DetBOMMat.BeforePrint
        view_bom_mat()
    End Sub

    Private Sub XtraReport1_BeforePrint(ByVal sender As System.Object, ByVal e As System.Drawing.Printing.PrintEventArgs) Handles MyBase.BeforePrint
        GridView1.OptionsPrint.UsePrintStyles = True
        LProductName.Text = product_name
        LBomName.Text = bom_name
        LBomDate.Text = "Created date : " & bom_date.ToString()
        LTerm.Text = bom_term

        load_mark_horz("8", id_bom, "2", "1", XrTable1)
        '
        'printed date & approved date
        Dim qpd As String = "SELECT DATE_FORMAT(NOW(), '%d/%M/%Y %H:%i') AS `printed_date` "
        Dim dpd As DataTable = execute_query(qpd, -1, True, "", "", "", "")
        DataSource = dpd
    End Sub
End Class