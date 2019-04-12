Public Class ReportEmpOvertime
    Public id As String = "0"
    Public data As DataTable = New DataTable
    Public id_pre As String = "-1"

    Private Sub ReportEmpOvertime_BeforePrint(sender As Object, e As Printing.PrintEventArgs) Handles MyBase.BeforePrint
        For i = 0 To data.Rows.Count - 1
            Dim row As New DevExpress.XtraReports.UI.XRTableRow

            'Code
            Dim code As New DevExpress.XtraReports.UI.XRTableCell

            code.WidthF = 115
            code.Text = data.Rows(i)("employee_code")
            code.Borders = DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Right Or DevExpress.XtraPrinting.BorderSide.Bottom

            row.Controls.Add(code)

            'Name
            Dim name As New DevExpress.XtraReports.UI.XRTableCell

            name.WidthF = 200
            name.Text = data.Rows(i)("employee_name")
            name.Borders = DevExpress.XtraPrinting.BorderSide.Right Or DevExpress.XtraPrinting.BorderSide.Bottom

            row.Controls.Add(name)

            'Position
            Dim position As New DevExpress.XtraReports.UI.XRTableCell

            position.WidthF = 180
            position.Text = data.Rows(i)("employee_position")
            position.Borders = DevExpress.XtraPrinting.BorderSide.Right Or DevExpress.XtraPrinting.BorderSide.Bottom

            row.Controls.Add(position)

            'Level
            Dim level As New DevExpress.XtraReports.UI.XRTableCell

            level.WidthF = 120
            level.Text = data.Rows(i)("employee_level")
            level.Borders = DevExpress.XtraPrinting.BorderSide.Right Or DevExpress.XtraPrinting.BorderSide.Bottom

            row.Controls.Add(level)

            'Type
            Dim type As New DevExpress.XtraReports.UI.XRTableCell

            type.WidthF = 112
            type.Text = If(data.Rows(i)("conversion_type").ToString = "1", "Salary", "DP")
            type.Borders = DevExpress.XtraPrinting.BorderSide.Right Or DevExpress.XtraPrinting.BorderSide.Bottom

            row.Controls.Add(type)

            XTEmployeeList.Controls.Add(row)
        Next

        If id_pre = "-1" Then
            load_mark_horz("184", id, "2", "1", XrTable1)
        Else
            pre_load_mark_horz("184", id, "2", "2", XrTable1)
        End If
    End Sub
End Class