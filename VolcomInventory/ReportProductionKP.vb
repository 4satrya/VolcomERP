﻿Public Class ReportProductionKP
    Public Shared dt_head As DataTable
    Public Shared dt_det As DataTable

    Private Sub ReportProductionKP_BeforePrint(sender As Object, e As Printing.PrintEventArgs) Handles MyBase.BeforePrint
        DataSource = dt_head
        '
        Dim po_height As Integer = 0

        For i = 0 To dt_det.Rows.Count - 1
            'column no
            Dim tb_no As New DevExpress.XtraReports.UI.XRLabel

            tb_no.Text = (i + 1).ToString
            tb_no.SizeF = New Size(34, 20)
            tb_no.LocationF = New Point(0, po_height)
            tb_no.Font = New Font("Calibri", 11, FontStyle.Bold)
            tb_no.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
            tb_no.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0)
            tb_no.Borders = DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Bottom

            Me.XPTableAmount.Controls.Add(tb_no)
            'column po no
            Dim tb_po_no As New DevExpress.XtraReports.UI.XRLabel

            tb_po_no.Text = dt_det.Rows(i)("prod_order_number").ToString
            tb_po_no.SizeF = New Size(81, 20)
            tb_po_no.LocationF = New Point(34, po_height)
            tb_po_no.Font = New Font("Calibri", 11, FontStyle.Bold)
            tb_po_no.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
            tb_po_no.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0)
            tb_po_no.Borders = DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Bottom

            Me.XPTableAmount.Controls.Add(tb_po_no)
            'column description
            Dim tb_desc As New DevExpress.XtraReports.UI.XRLabel

            tb_desc.Text = dt_det.Rows(i)("class_dsg").ToString
            tb_desc.SizeF = New Size(180, 20)
            tb_desc.LocationF = New Point(115, po_height)
            tb_desc.Font = New Font("Calibri", 11, FontStyle.Bold)
            tb_desc.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
            tb_desc.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0)
            tb_desc.Borders = DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Bottom

            Me.XPTableAmount.Controls.Add(tb_desc)
            'column color
            Dim tb_color As New DevExpress.XtraReports.UI.XRLabel

            tb_color.Text = dt_det.Rows(i)("color").ToString
            tb_color.SizeF = New Size(52, 20)
            tb_color.LocationF = New Point(295, po_height)
            tb_color.Font = New Font("Calibri", 11, FontStyle.Bold)
            tb_color.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
            tb_color.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0)
            tb_color.Borders = DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Bottom

            Me.XPTableAmount.Controls.Add(tb_color)
            'column qty order
            Dim tb_qty As New DevExpress.XtraReports.UI.XRLabel

            tb_qty.Text = Decimal.Parse(dt_det.Rows(i)("qty_order").ToString).ToString("N0")
            tb_qty.SizeF = New Size(52, 20)
            tb_qty.LocationF = New Point(347, po_height)
            tb_qty.Font = New Font("Calibri", 11, FontStyle.Bold)
            tb_qty.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
            tb_qty.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0)
            tb_qty.Borders = DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Bottom

            Me.XPTableAmount.Controls.Add(tb_qty)

            'ETA Bali
            Dim tb_unit_price As New DevExpress.XtraReports.UI.XRLabel

            tb_unit_price.Text = Date.Parse(dt_det.Rows(i)("esti_del_date").ToString).ToString("dd MMMM yyyy")
            tb_unit_price.SizeF = New Size(140, 20)
            tb_unit_price.LocationF = New Point(399, po_height)
            tb_unit_price.Font = New Font("Calibri", 11, FontStyle.Bold)
            tb_unit_price.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
            tb_unit_price.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0)
            tb_unit_price.Borders = DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Bottom

            Me.XPTableAmount.Controls.Add(tb_unit_price)

            '2nd Proto comment date
            Dim tb_amount As New DevExpress.XtraReports.UI.XRLabel

            tb_amount.Text = Date.Parse(dt_det.Rows(i)("sample_proto_2").ToString).ToString("dd MMMM yyyy")
            tb_amount.SizeF = New Size(150, 20)
            tb_amount.LocationF = New Point(539, po_height)
            tb_amount.Font = New Font("Calibri", 11, FontStyle.Bold)
            tb_amount.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
            tb_amount.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0)
            tb_amount.Borders = DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Bottom Or DevExpress.XtraPrinting.BorderSide.Right

            Me.XPTableAmount.Controls.Add(tb_amount)

            po_height = po_height + 20
        Next
    End Sub
End Class