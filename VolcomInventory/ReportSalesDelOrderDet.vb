﻿Public Class ReportSalesDelOrderDet
    Public Shared id_pl_sales_order_del As String
    Public Shared dt As DataTable
    Public Shared id_pre As String = "-1"
    Public Shared rmt As String = "43"


    Private Sub ReportSalesDelOrderDet_BeforePrint(ByVal sender As System.Object, ByVal e As System.Drawing.Printing.PrintEventArgs) Handles MyBase.BeforePrint
        GCItemList.DataSource = dt
        If id_pre = "-1" Then
            load_mark_horz(rmt, id_pl_sales_order_del, "2", "1", XrTable1)
        Else
            pre_load_mark_horz(rmt, id_pl_sales_order_del, "2", "2", XrTable1)
        End If

        If LabelUni6.Text = "" Then
            LabelUni1.Visible = False
            LabelUni2.Visible = False
            LabelUni3.Visible = False
            LabelUni4.Visible = False
            LabelUni5.Visible = False
            LabelUni6.Visible = False
        End If
    End Sub

    Private Sub GVItemList_CustomColumnDisplayText(sender As Object, e As DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs) Handles GVItemList.CustomColumnDisplayText

    End Sub
End Class