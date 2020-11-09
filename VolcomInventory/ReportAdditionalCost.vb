Public Class ReportAdditionalCost
    Public id_pre As String
    Public id_report As String
    Public data_design As DataTable
    Public data_cost As DataTable
    Public report_mark_type As String

    Private Sub ReportAdditionalCost_BeforePrint(sender As Object, e As Printing.PrintEventArgs) Handles MyBase.BeforePrint
        Dim row As DevExpress.XtraReports.UI.XRTableRow = New DevExpress.XtraReports.UI.XRTableRow

        Dim tot_qty_order As Decimal = 0
        Dim tot_qty_sampling As Decimal = 0
        Dim total As Decimal = 0

        For i = 0 To data_design.Rows.Count - 1
            If i = 0 Then
                row = XTableDesign.InsertRowBelow(XTRow)

                row.HeightF = 16
            Else
                row = XTableDesign.InsertRowBelow(row)
            End If

            'no
            Dim no As DevExpress.XtraReports.UI.XRTableCell = row.Cells.Item(0)

            no.Text = i + 1
            no.Borders = DevExpress.XtraPrinting.BorderSide.Top Or DevExpress.XtraPrinting.BorderSide.Left
            no.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter
            no.BackColor = Color.Transparent

            'design code
            Dim design_code As DevExpress.XtraReports.UI.XRTableCell = row.Cells.Item(1)

            design_code.Text = data_design.Rows(i)("design_code").ToString
            design_code.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter
            design_code.Borders = DevExpress.XtraPrinting.BorderSide.Top Or DevExpress.XtraPrinting.BorderSide.Left
            design_code.BackColor = Color.Transparent

            'design name
            Dim design_name As DevExpress.XtraReports.UI.XRTableCell = row.Cells.Item(2)

            design_name.Text = data_design.Rows(i)("design_display_name").ToString
            design_name.Borders = DevExpress.XtraPrinting.BorderSide.Top Or DevExpress.XtraPrinting.BorderSide.Left
            design_name.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            design_name.BackColor = Color.Transparent

            'qty order
            Dim qty_order As DevExpress.XtraReports.UI.XRTableCell = row.Cells.Item(3)

            qty_order.Text = Format(data_design.Rows(i)("qty"), "##,##0")
            qty_order.Borders = DevExpress.XtraPrinting.BorderSide.Top Or DevExpress.XtraPrinting.BorderSide.Left
            qty_order.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter
            qty_order.BackColor = Color.Transparent

            'qty sampling
            Dim qty_sampling As DevExpress.XtraReports.UI.XRTableCell = row.Cells.Item(4)

            qty_sampling.Text = Format(data_design.Rows(i)("qty_sampling"), "##,##0")
            qty_sampling.Borders = DevExpress.XtraPrinting.BorderSide.Top Or DevExpress.XtraPrinting.BorderSide.Left
            qty_sampling.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter
            qty_sampling.BackColor = Color.Transparent

            'ECOP
            Dim employee_contribution As DevExpress.XtraReports.UI.XRTableCell = row.Cells.Item(5)

            employee_contribution.Text = Format(data_design.Rows(i)("prod_order_cop_pd"), "##,##0.00")
            employee_contribution.Borders = DevExpress.XtraPrinting.BorderSide.Top Or DevExpress.XtraPrinting.BorderSide.Left
            employee_contribution.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            employee_contribution.BackColor = Color.Transparent

            'Amount
            Dim total_contribution As DevExpress.XtraReports.UI.XRTableCell = row.Cells.Item(6)

            total_contribution.Text = Format(data_design.Rows(i)("prod_order_cop_pd") * data_design.Rows(i)("qty_sampling"), "##,##0.00")
            total_contribution.Borders = DevExpress.XtraPrinting.BorderSide.Top Or DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Right
            total_contribution.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            total_contribution.BackColor = Color.Transparent

            'calculate total
            '*uncomment if, if total all sogo include
            tot_qty_order += data_design.Rows(i)("qty")
            tot_qty_sampling += data_design.Rows(i)("qty_sampling")
            total += data_design.Rows(i)("prod_order_cop_pd") * data_design.Rows(i)("qty_sampling")
        Next
        '==================================================================================================================
        Dim row2 As DevExpress.XtraReports.UI.XRTableRow = New DevExpress.XtraReports.UI.XRTableRow

        Dim sub_total As Decimal = 0

        For i = 0 To data_cost.Rows.Count - 1
            If i = 0 Then
                row2 = XrTableCop.InsertRowBelow(XTRowCost)

                row2.HeightF = 16
            Else
                row2 = XrTableCop.InsertRowBelow(row2)
            End If

            'no
            Dim no As DevExpress.XtraReports.UI.XRTableCell = row2.Cells.Item(0)

            no.Text = i + 1
            no.Borders = DevExpress.XtraPrinting.BorderSide.Top Or DevExpress.XtraPrinting.BorderSide.Left
            no.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter
            no.BackColor = Color.Transparent

            'description
            Dim description As DevExpress.XtraReports.UI.XRTableCell = row2.Cells.Item(1)

            description.Text = data_cost.Rows(i)("description").ToString
            description.Borders = DevExpress.XtraPrinting.BorderSide.Top Or DevExpress.XtraPrinting.BorderSide.Left
            description.BackColor = Color.Transparent

            'qty
            Dim design_name As DevExpress.XtraReports.UI.XRTableCell = row2.Cells.Item(2)

            design_name.Text = Format(data_cost.Rows(i)("qty"), "##,##0")
            design_name.Borders = DevExpress.XtraPrinting.BorderSide.Top Or DevExpress.XtraPrinting.BorderSide.Left
            design_name.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            design_name.BackColor = Color.Transparent

            'price
            Dim qty_order As DevExpress.XtraReports.UI.XRTableCell = row2.Cells.Item(3)

            qty_order.Text = Format(data_cost.Rows(i)("value"), "##,##0.00")
            qty_order.Borders = DevExpress.XtraPrinting.BorderSide.Top Or DevExpress.XtraPrinting.BorderSide.Left
            qty_order.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            qty_order.BackColor = Color.Transparent

            'Sub Total
            Dim total_contribution As DevExpress.XtraReports.UI.XRTableCell = row2.Cells.Item(4)

            total_contribution.Text = Format(data_cost.Rows(i)("qty") * data_cost.Rows(i)("value"), "##,##0.00")
            total_contribution.Borders = DevExpress.XtraPrinting.BorderSide.Top Or DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Right
            total_contribution.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            total_contribution.BackColor = Color.Transparent

            'calculate total
            '*uncomment if, if total all sogo include
            sub_total += data_cost.Rows(i)("qty") * data_cost.Rows(i)("value")
        Next
    End Sub
End Class