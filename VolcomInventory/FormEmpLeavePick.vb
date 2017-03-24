Public Class FormEmpLeavePick
    Public id_schedule As String = "-1"
    Public id_employee As String = "-1"

    Public opt As String = "-1"

    Private Sub BCancel_Click(sender As Object, e As EventArgs) Handles BCancel.Click
        Close()
    End Sub

    Private Sub FormEmpLeavePick_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        DEStart.EditValue = Now
        DEUntil.EditValue = Now
        '
        If opt = "1" Or opt = "2" Then 'change schedule
            BPickAll.Visible = False
            LPropose.Visible = False
            CEFullDay.Visible = False
            DEStartLeave.Visible = False
            DEUntilLeave.Visible = False
            Luntil.Visible = False
        Else 'leave
            BPickAll.Visible = True
        End If
    End Sub

    Private Sub BViewSchedule_Click(sender As Object, e As EventArgs) Handles BViewSchedule.Click
        load_schedule()
        load_total()
        load_date()
        GVSchedule.BestFitColumns()
        GVSchedule.Focus()
    End Sub

    Sub load_schedule()
        Dim query As String = ""
        Dim date_start, date_until As String

        date_start = Date.Parse(DEStart.EditValue.ToString).ToString("yyyy-MM-dd")
        date_until = Date.Parse(DEUntil.EditValue.ToString).ToString("yyyy-MM-dd")

        query = "SELECT * FROM tb_emp_schedule sch INNER JOIN tb_lookup_schedule_type scht ON scht.id_schedule_type=sch.id_schedule_type"
        query += " WHERE sch.`date`>='" & date_start & "' AND sch.`date`<='" & date_until & "' AND sch.id_employee='" & id_employee & "'"

        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCSchedule.DataSource = data
        GVSchedule.BestFitColumns()
    End Sub

    Private Sub GVSchedule_FocusedRowChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles GVSchedule.FocusedRowChanged
        load_total()
    End Sub

    Sub load_total()
        Try
            If GVSchedule.RowCount > 0 Then
                DEStartLeave.Properties.MinValue = GVSchedule.GetFocusedRowCellValue("in")
                DEStartLeave.Properties.MaxValue = GVSchedule.GetFocusedRowCellValue("out")
                DEStartLeave.EditValue = GVSchedule.GetFocusedRowCellValue("in")

                DEUntilLeave.Properties.MinValue = GVSchedule.GetFocusedRowCellValue("in")
                DEUntilLeave.Properties.MaxValue = GVSchedule.GetFocusedRowCellValue("out")
                DEUntilLeave.EditValue = GVSchedule.GetFocusedRowCellValue("out")
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub BAdd_Click(sender As Object, e As EventArgs) Handles BAdd.Click
        If DEStartLeave.Text = "" And opt = "-1" Then
            stopCustom("Pilih tanggal pengajuan cuti terlebih dahulu.")
        Else
            If opt = "1" Then ' change schedule from
                FormEmpChScheduleDet.id_sch_from = GVSchedule.GetFocusedRowCellDisplayText("id_schedule").ToString
                FormEmpChScheduleDet.load_sch("1")
                FormEmpChScheduleDet.BPickScheduleTo.Focus()
                Close()
            ElseIf opt = "2" Then ' change schedule to
                FormEmpChScheduleDet.id_sch_to = GVSchedule.GetFocusedRowCellDisplayText("id_schedule").ToString
                FormEmpChScheduleDet.load_sch("2")
                FormEmpChScheduleDet.MEChNote.Focus()
                Close()
            Else 'leave
                Dim check As Boolean = True

                For i As Integer = 0 To FormEmpLeaveDet.GVLeaveDet.RowCount - 1
                    If FormEmpLeaveDet.GVLeaveDet.GetRowCellValue(0, "id_schedule") = GVSchedule.GetFocusedRowCellDisplayText("id_schedule").ToString Then
                        check = False
                    End If
                Next

                If check = False Then
                    stopCustom("Tanggal ini sudah diajukan cuti.")
                Else
                    Dim total_min As Integer = 0

                    Dim is_full_day As String = "no"
                    Dim minute_total As TimeSpan
                    Dim date_from, date_until As Date

                    date_from = Date.Parse(DEStartLeave.EditValue.ToString)
                    date_until = Date.Parse(DEUntilLeave.EditValue.ToString)

                    If CEFullDay.Checked = False Then
                        is_full_day = "no"
                        minute_total = Date.Parse(date_until.ToString).Subtract(Date.Parse(date_from.ToString))
                        total_min = minute_total.TotalMinutes
                    Else
                        is_full_day = "yes"
                        total_min = GVSchedule.GetFocusedRowCellValue("minutes_work")
                    End If

                    Dim newRow As DataRow = (TryCast(FormEmpLeaveDet.GCLeaveDet.DataSource, DataTable)).NewRow()
                    newRow("id_schedule") = GVSchedule.GetFocusedRowCellDisplayText("id_schedule").ToString
                    newRow("datetime_start") = date_from
                    newRow("datetime_until") = date_until
                    newRow("is_full_day") = is_full_day
                    newRow("hours_total") = total_min / 60
                    newRow("minutes_total") = total_min

                    TryCast(FormEmpLeaveDet.GCLeaveDet.DataSource, DataTable).Rows.Add(newRow)
                    FormEmpLeaveDet.GCLeaveDet.RefreshDataSource()
                    FormEmpLeaveDet.load_but_calc()
                    FormEmpLeaveDet.GVLeaveDet.FocusedRowHandle = 0
                    '
                    Close()
                End If
            End If
        End If
    End Sub

    Private Sub CEFullDay_CheckedChanged(sender As Object, e As EventArgs) Handles CEFullDay.CheckedChanged
        load_date()
    End Sub

    Sub load_date()
        Try
            If CEFullDay.Checked = True Then
                If GVSchedule.RowCount > 0 Then
                    DEStartLeave.Properties.MinValue = GVSchedule.GetFocusedRowCellValue("in")
                    DEStartLeave.Properties.MaxValue = GVSchedule.GetFocusedRowCellValue("out")
                    DEStartLeave.EditValue = GVSchedule.GetFocusedRowCellValue("in")
                    '
                    DEUntilLeave.Properties.MinValue = GVSchedule.GetFocusedRowCellValue("in")
                    DEUntilLeave.Properties.MaxValue = GVSchedule.GetFocusedRowCellValue("out")
                    DEUntilLeave.EditValue = GVSchedule.GetFocusedRowCellValue("out")
                    '
                    DEStartLeave.Properties.ReadOnly = True
                    DEUntilLeave.Properties.ReadOnly = True
                    '
                End If
            Else
                DEStartLeave.Properties.ReadOnly = False
                DEUntilLeave.Properties.ReadOnly = False
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub FormEmpLeavePick_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub FormEmpLeavePick_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown
        DEStart.Focus()
    End Sub

    Private Sub DEStart_KeyDown(sender As Object, e As KeyEventArgs) Handles DEStart.KeyDown
        If e.KeyCode = Keys.Enter Then
            DEUntil.Focus()
        End If
    End Sub

    Private Sub DEUntil_KeyDown(sender As Object, e As KeyEventArgs) Handles DEUntil.KeyDown
        If e.KeyCode = Keys.Enter Then
            BViewSchedule.Focus()
        End If
    End Sub

    Private Sub GVSchedule_KeyDown(sender As Object, e As KeyEventArgs) Handles GVSchedule.KeyDown
        If e.KeyCode = Keys.Enter Then
            If opt = "1" Or opt = "2" Then
                BAdd.Focus()
            Else
                CEFullDay.Focus()
            End If
        End If
    End Sub

    Private Sub CEFullDay_KeyDown(sender As Object, e As KeyEventArgs) Handles CEFullDay.KeyDown
        If e.KeyCode = Keys.NumPad1 Then
            CEFullDay.Checked = True
        ElseIf e.KeyCode = Keys.NumPad0 Then
            CEFullDay.Checked = False
        ElseIf e.KeyCode = Keys.Enter Then
            If CEFullDay.Checked = True Then
                BAdd.Focus()
            Else
                DEStartLeave.Focus()
            End If
        End If
    End Sub

    Private Sub DEStartLeave_KeyDown(sender As Object, e As KeyEventArgs) Handles DEStartLeave.KeyDown
        If e.KeyCode = Keys.Enter Then
            DEUntilLeave.Focus()
        End If
    End Sub

    Private Sub DEUntilLeave_KeyDown(sender As Object, e As KeyEventArgs) Handles DEUntilLeave.KeyDown
        If e.KeyCode = Keys.Enter Then
            BAdd.Focus()
        End If
    End Sub

    Private Sub BPickAll_Click(sender As Object, e As EventArgs) Handles BPickAll.Click
        FormEmpLeaveDet.clear_grid()

        For i As Integer = 0 To GVSchedule.RowCount - 1
            If GVSchedule.GetRowCellValue(i, "id_schedule_type").ToString = "1" Then
                Dim total_min As Integer = 0

                Dim is_full_day As String = "no"
                Dim date_from, date_until As Date

                date_from = Date.Parse(GVSchedule.GetRowCellValue(i, "in").ToString)
                date_until = Date.Parse(GVSchedule.GetRowCellValue(i, "out").ToString)

                is_full_day = "yes"
                total_min = GVSchedule.GetRowCellValue(i, "minutes_work")

                Dim newRow As DataRow = (TryCast(FormEmpLeaveDet.GCLeaveDet.DataSource, DataTable)).NewRow()
                newRow("id_schedule") = GVSchedule.GetRowCellValue(i, "id_schedule").ToString
                newRow("datetime_start") = date_from
                newRow("datetime_until") = date_until
                newRow("is_full_day") = is_full_day
                newRow("hours_total") = total_min / 60
                newRow("minutes_total") = total_min

                TryCast(FormEmpLeaveDet.GCLeaveDet.DataSource, DataTable).Rows.Add(newRow)
                FormEmpLeaveDet.GCLeaveDet.RefreshDataSource()
                FormEmpLeaveDet.load_but_calc()
                FormEmpLeaveDet.GVLeaveDet.FocusedRowHandle = 0
            End If
        Next

        Close()
    End Sub
End Class