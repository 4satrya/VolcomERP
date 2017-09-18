Public Class ReportAttnSum
    Public Shared dt As DataTable
    Public Shared id_pre As String = "-1"

    Public Shared id_report_type As String = "-1"

    Private Sub ReportEmpAttnInd_BeforePrint(sender As Object, e As Printing.PrintEventArgs) Handles MyBase.BeforePrint
        GCSchedule.DataSource = dt
    End Sub

    Private Sub GVSchedule_RowCellStyle(sender As Object, e As DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs) Handles GVSchedule.RowCellStyle
        If id_report_type = "1" And GVSchedule.GetRowCellValue(e.RowHandle, "id_employee_active").ToString = "1" And GVSchedule.GetRowCellValue(e.RowHandle, "id_schedule_type").ToString = "1" And Date.Parse(GVSchedule.GetRowCellValue(e.RowHandle, "date").ToString).Date < Now.Date And GVSchedule.GetRowCellValue(e.RowHandle, "present").ToString = "0" And GVSchedule.GetRowCellValue(e.RowHandle, "id_leave_type").ToString = "" Then
            e.Appearance.BackColor = Color.Yellow
        End If
    End Sub
End Class