Public Class ReportProductionSampleProto2Order
    Public Shared dt_head As DataTable
    Public Shared dt_det As DataTable

    Private Sub ReportProductionSampleProto2Order_BeforePrint(sender As Object, e As Printing.PrintEventArgs) Handles MyBase.BeforePrint
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
            tb_po_no.SizeF = New Size(138, 20)
            tb_po_no.LocationF = New Point(34, po_height)
            tb_po_no.Font = New Font("Calibri", 11, FontStyle.Bold)
            tb_po_no.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
            tb_po_no.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0)
            tb_po_no.Borders = DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Bottom

            Me.XPTableAmount.Controls.Add(tb_po_no)

            'column description
            Dim tb_desc As New DevExpress.XtraReports.UI.XRLabel

            tb_desc.Text = dt_det.Rows(i)("class_dsg").ToString
            tb_desc.SizeF = New Size(175, 20)
            tb_desc.LocationF = New Point(172, po_height)
            tb_desc.Font = New Font("Calibri", 11, FontStyle.Bold)
            tb_desc.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
            tb_desc.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0)
            tb_desc.Borders = DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Bottom

            Me.XPTableAmount.Controls.Add(tb_desc)

            'column color
            Dim tb_color As New DevExpress.XtraReports.UI.XRLabel

            tb_color.Text = dt_det.Rows(i)("color").ToString
            tb_color.SizeF = New Size(45, 20)
            tb_color.LocationF = New Point(347, po_height)
            tb_color.Font = New Font("Calibri", 11, FontStyle.Bold)
            tb_color.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
            tb_color.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0)
            tb_color.Borders = DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Bottom

            Me.XPTableAmount.Controls.Add(tb_color)

            'column Size
            Dim tb_size As New DevExpress.XtraReports.UI.XRLabel

            tb_size.Text = dt_det.Rows(i)("size").ToString
            tb_size.SizeF = New Size(45, 20)
            tb_size.LocationF = New Point(392, po_height)
            tb_size.Font = New Font("Calibri", 11, FontStyle.Bold)
            tb_size.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
            tb_size.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0)
            tb_size.Borders = DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Bottom

            Me.XPTableAmount.Controls.Add(tb_size)

            'column qty order
            Dim tb_qty As New DevExpress.XtraReports.UI.XRLabel

            tb_qty.Text = Decimal.Parse(dt_det.Rows(i)("qty_order").ToString).ToString("N0")
            tb_qty.SizeF = New Size(52, 20)
            tb_qty.LocationF = New Point(437, po_height)
            tb_qty.Font = New Font("Calibri", 11, FontStyle.Bold)
            tb_qty.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
            tb_qty.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0)
            tb_qty.Borders = DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Bottom

            Me.XPTableAmount.Controls.Add(tb_qty)

            'ETA Bali
            Dim tb_eta As New DevExpress.XtraReports.UI.XRLabel

            tb_eta.Text = Date.Parse(dt_det.Rows(i)("eta_copy_proto_2").ToString).ToString("dd MMMM yyyy")
            tb_eta.SizeF = New Size(200, 20)
            tb_eta.LocationF = New Point(489, po_height)
            tb_eta.Font = New Font("Calibri", 11, FontStyle.Bold)
            tb_eta.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
            tb_eta.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0)
            tb_eta.Borders = DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Bottom Or DevExpress.XtraPrinting.BorderSide.Right

            Me.XPTableAmount.Controls.Add(tb_eta)

            po_height = po_height + 20
        Next
    End Sub
End Class