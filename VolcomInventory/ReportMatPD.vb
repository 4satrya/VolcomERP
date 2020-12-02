Public Class ReportMatPD
    Public dt_head As DataTable
    Public dt_det As DataTable
    '
    Public id_purc As String = "-1"
    Public is_use_bulk As Boolean = False

    Private Sub ReportMatPD_BeforePrint(sender As Object, e As Printing.PrintEventArgs) Handles MyBase.BeforePrint
        DataSource = dt_head
        '
        If is_use_bulk Then
            If dt_head.Rows(0)("moq") = 1 Then
                LNOMOQ.Visible = False
                LClassMOQ.Visible = False
                LDesignMOQ.Visible = False
                LColorMOQ.Visible = False
                LQtyMOQ.Visible = False
                LConsMOQ.Visible = False
                LTotalMOQ.Visible = False
            Else
                LNOMOQ.Visible = True
                LClassMOQ.Visible = True
                LDesignMOQ.Visible = True
                LColorMOQ.Visible = True
                LQtyMOQ.Visible = True
                LConsMOQ.Visible = True
                LTotalMOQ.Visible = True
            End If

            LNO1.Visible = True
            LNO2.Visible = True
            LNO3.Visible = True
            LNO4.Visible = True
            '
            LClass1.Visible = True
            LClass2.Visible = True
            LClass3.Visible = True
            LClass4.Visible = True
            '
            LDesign1.Visible = True
            LDesign2.Visible = True
            LDesign3.Visible = True
            LDesign4.Visible = True
            '
            LColor1.Visible = True
            LColor2.Visible = True
            LColor3.Visible = True
            LColor4.Visible = True
            '
            LQty1.Visible = True
            LQty2.Visible = True
            LQty3.Visible = True
            LQty4.Visible = True
            '
            LCons1.Visible = True
            LCons2.Visible = True
            LCons3.Visible = True
            LCons4.Visible = True
            '
            LTotal1.Visible = True
            LTotal2.Visible = True
            LTotal3.Visible = True
            LTotal4.Visible = True

            If dt_head.Rows(0)("moq") > dt_head.Rows(0)("total") Then
                LNOMOQ.BackColor = Color.LightBlue
                LClassMOQ.BackColor = Color.LightBlue
                LDesignMOQ.BackColor = Color.LightBlue
                LColorMOQ.BackColor = Color.LightBlue
                LQtyMOQ.BackColor = Color.LightBlue
                LConsMOQ.BackColor = Color.LightBlue
                LTotalMOQ.BackColor = Color.LightBlue
            Else
                LNoTot.BackColor = Color.LightBlue
                LClassTot.BackColor = Color.LightBlue
                LDesignTot.BackColor = Color.LightBlue
                LColorTot.BackColor = Color.LightBlue
                LQtyTot.BackColor = Color.LightBlue
                LConsTot.BackColor = Color.LightBlue
                LTotTot.BackColor = Color.LightBlue
            End If
        Else
            If dt_head.Rows(0)("moq") = 1 Then
                LNOMOQ.Visible = False
                LClassMOQ.Visible = False
                LDesignMOQ.Visible = False
                LColorMOQ.Visible = False
                LQtyMOQ.Visible = False
                LConsMOQ.Visible = False
                LTotalMOQ.Visible = False
            Else
                LNOMOQ.Visible = True
                LClassMOQ.Visible = True
                LDesignMOQ.Visible = True
                LColorMOQ.Visible = True
                LQtyMOQ.Visible = True
                LConsMOQ.Visible = True
                LTotalMOQ.Visible = True

                LNOMOQ.LocationF = LNO1.LocationF
                LClassMOQ.LocationF = LClass1.LocationF
                LDesignMOQ.LocationF = LDesign1.LocationF
                LColorMOQ.LocationF = LColor1.LocationF
                LQtyMOQ.LocationF = LQty1.LocationF
                LConsMOQ.LocationF = LCons1.LocationF
                LTotalMOQ.LocationF = LTotal1.LocationF
            End If
            '
            LNO1.Visible = False
            LNO2.Visible = False
            LNO3.Visible = False
            LNO4.Visible = False
            '
            LClass1.Visible = False
            LClass2.Visible = False
            LClass3.Visible = False
            LClass4.Visible = False
            '
            LDesign1.Visible = False
            LDesign2.Visible = False
            LDesign3.Visible = False
            LDesign4.Visible = False
            '
            LColor1.Visible = False
            LColor2.Visible = False
            LColor3.Visible = False
            LColor4.Visible = False
            '
            LQty1.Visible = False
            LQty2.Visible = False
            LQty3.Visible = False
            LQty4.Visible = False
            '
            LCons1.Visible = False
            LCons2.Visible = False
            LCons3.Visible = False
            LCons4.Visible = False
            '
            LTotal1.Visible = False
            LTotal2.Visible = False
            LTotal3.Visible = False
            LTotal4.Visible = False
            '
            If dt_head.Rows(0)("moq") > dt_head.Rows(0)("total") Then
                LNOMOQ.BackColor = Color.LightBlue
                LClassMOQ.BackColor = Color.LightBlue
                LDesignMOQ.BackColor = Color.LightBlue
                LColorMOQ.BackColor = Color.LightBlue
                LQtyMOQ.BackColor = Color.LightBlue
                LConsMOQ.BackColor = Color.LightBlue
                LTotalMOQ.BackColor = Color.LightBlue
            Else
                LNoTot.BackColor = Color.LightBlue
                LClassTot.BackColor = Color.LightBlue
                LDesignTot.BackColor = Color.LightBlue
                LColorTot.BackColor = Color.LightBlue
                LQtyTot.BackColor = Color.LightBlue
                LConsTot.BackColor = Color.LightBlue
                LTotTot.BackColor = Color.LightBlue
            End If
        End If
        '
        Dim po_height As Integer = 0

        For i = 0 To dt_det.Rows.Count - 1
            'column no
            Dim tb_no As New DevExpress.XtraReports.UI.XRLabel

            tb_no.Text = (i + 1).ToString
            tb_no.SizeF = New Size(30, 20)
            tb_no.LocationF = New Point(0, po_height)
            tb_no.Font = New Font("Calibri", 10)
            tb_no.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
            tb_no.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0)
            tb_no.Borders = DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Bottom

            Me.XPTableAmount.Controls.Add(tb_no)
            'column class
            Dim tb_class As New DevExpress.XtraReports.UI.XRLabel

            tb_class.Text = dt_det.Rows(i)("class").ToString
            tb_class.SizeF = New Size(50, 20)
            tb_class.LocationF = New Point(30, po_height)
            tb_class.Font = New Font("Calibri", 10)
            tb_class.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
            tb_class.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0)
            tb_class.Borders = DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Bottom

            Me.XPTableAmount.Controls.Add(tb_class)
            'column design name
            Dim tb_design As New DevExpress.XtraReports.UI.XRLabel

            tb_design.Text = dt_det.Rows(i)("design_name").ToString
            tb_design.SizeF = New Size(250, 20)
            tb_design.LocationF = New Point(80, po_height)
            tb_design.Font = New Font("Calibri", 10)
            tb_design.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
            tb_design.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0)
            tb_design.Borders = DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Bottom

            Me.XPTableAmount.Controls.Add(tb_design)
            'column color
            Dim tb_color As New DevExpress.XtraReports.UI.XRLabel

            tb_color.Text = dt_det.Rows(i)("color").ToString
            tb_color.SizeF = New Size(40, 20)
            tb_color.LocationF = New Point(330, po_height)
            tb_color.Font = New Font("Calibri", 10)
            tb_color.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
            tb_color.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0)
            tb_color.Borders = DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Bottom

            Me.XPTableAmount.Controls.Add(tb_color)
            'column qty pd
            Dim tb_qty_pd As New DevExpress.XtraReports.UI.XRLabel

            tb_qty_pd.Text = dt_det.Rows(i)("total_qty_pd").ToString
            tb_qty_pd.SizeF = New Size(55, 20)
            tb_qty_pd.LocationF = New Point(370, po_height)
            tb_qty_pd.Font = New Font("Calibri", 10)
            tb_qty_pd.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
            tb_qty_pd.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0)
            tb_qty_pd.Borders = DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Bottom

            Me.XPTableAmount.Controls.Add(tb_qty_pd)
            'column consumption
            Dim tb_cons As New DevExpress.XtraReports.UI.XRLabel

            tb_cons.Text = dt_det.Rows(i)("qty_consumption").ToString
            tb_cons.SizeF = New Size(70, 20)
            tb_cons.LocationF = New Point(425, po_height)
            tb_cons.Font = New Font("Calibri", 10)
            tb_cons.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
            tb_cons.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0)
            tb_cons.Borders = DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Bottom

            Me.XPTableAmount.Controls.Add(tb_cons)
            'column qty order
            Dim tb_qty_order As New DevExpress.XtraReports.UI.XRLabel

            tb_qty_order.Text = dt_det.Rows(i)("qty_order").ToString
            tb_qty_order.SizeF = New Size(229, 20)
            tb_qty_order.LocationF = New Point(495, po_height)
            tb_qty_order.Font = New Font("Calibri", 10)
            tb_qty_order.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
            tb_qty_order.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0)
            tb_qty_order.Borders = DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Bottom Or DevExpress.XtraPrinting.BorderSide.Right

            Me.XPTableAmount.Controls.Add(tb_qty_order)
            po_height = po_height + 20
        Next

        pre_load_mark_horz("13", id_purc, "2", "2", XrTable1)
        '

    End Sub
End Class