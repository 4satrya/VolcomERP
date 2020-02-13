Public Class ReportSalesInvReport
    Public Shared dt As DataTable

    Private Sub ReportSalesInvReport_BeforePrint(sender As Object, e As Printing.PrintEventArgs) Handles MyBase.BeforePrint
        GCByProduct.DataSource = dt

        'printed
        Dim qpd As String = "SELECT DATE_FORMAT(NOW(), '%d-%m-%Y %H:%i') AS `printed_date`, '" + name_user + "' AS `printed_by`, UPPER(c.comp_name) AS `own_company`
        FROM tb_m_comp c
        WHERE c.id_comp IN (SELECT o.id_own_company FROM tb_opt o) "
        Dim dpd As DataTable = execute_query(qpd, -1, True, "", "", "", "")
        DataSource = dpd
    End Sub

    Private Sub GVByProduct_CustomColumnDisplayText(sender As Object, e As DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs) Handles GVByProduct.CustomColumnDisplayText
        If (e.Column.FieldName.Contains("sal_qty") Or e.Column.FieldName.Contains("inv_qty") Or e.Column.FieldName.Contains("age")) Then
            Dim qty As Decimal = Convert.ToDecimal(e.Value)
            If qty = 0 Then
                e.DisplayText = "-"
            End If
        ElseIf e.Column.FieldName = "no" Then
            Dim view As DevExpress.XtraGrid.Views.Grid.GridView = TryCast(sender, DevExpress.XtraGrid.Views.Grid.GridView)
            If view.GroupedColumns.Count <> 0 AndAlso Not e.IsForGroupRow Then
                Dim rowHandle As Integer = view.GetRowHandle(e.ListSourceRowIndex)
                e.DisplayText = (view.GetRowGroupIndexByRowHandle(rowHandle) + 1).ToString()
            End If
        End If
    End Sub
End Class