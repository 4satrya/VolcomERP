Public Class FormEmpShiftDet
    Public id_shift As String = "-1"

    Private Sub FormEmpShiftDet_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If id_shift = "-1" Then 'new
            TEMinutes.EditValue = 0
            TEEndTolerance.EditValue = 0
        Else
            Dim query As String = "SELECT * FROM tb_emp_shift WHERE id_shift='" & id_shift & "'"
            Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
            '
            TEShiftName.Text = data.Rows(0)("shift_name").ToString
            TEShiftCode.Text = data.Rows(0)("shift_code").ToString
            TEWorkStart.EditValue = data.Rows(0)("start_work")
            TEWorkEnd.EditValue = data.Rows(0)("end_work")
            TEBreakStart.EditValue = data.Rows(0)("start_break")
            TEBreakEnd.EditValue = data.Rows(0)("end_break")
            TEWorkStartTol.EditValue = data.Rows(0)("late_start_tolerance")
            '
            TEMinutes.EditValue = data.Rows(0)("minutes_work")
            TEEndTolerance.EditValue = data.Rows(0)("out_tolerance")
            '
            If data.Rows(0)("is_ignore_holiday").ToString = "1" Then
                CEHoliday.Checked = True
            Else
                CEHoliday.Checked = False
            End If
            '
            If data.Rows(0)("is_start_daybefore").ToString = "1" Then
                CEStartNext.Checked = True
            Else
                CEStartNext.Checked = False
            End If
            '
            If data.Rows(0)("is_start_tol_daybefore").ToString = "1" Then
                CETolNext.Checked = True
            Else
                CETolNext.Checked = False
            End If
            '
            If data.Rows(0)("is_end_dayafter").ToString = "1" Then
                CEEndNext.Checked = True
            Else
                CEEndNext.Checked = False
            End If
            '
            If data.Rows(0)("sunday").ToString = "1" Then
                CESunday.Checked = True
            Else
                CESunday.Checked = False
            End If
            '
            If data.Rows(0)("monday").ToString = "1" Then
                CEMonday.Checked = True
            Else
                CEMonday.Checked = False
            End If
            '
            If data.Rows(0)("tuesday").ToString = "1" Then
                CETuesday.Checked = True
            Else
                CETuesday.Checked = False
            End If
            '
            If data.Rows(0)("wednesday").ToString = "1" Then
                CEWednesday.Checked = True
            Else
                CEWednesday.Checked = False
            End If
            '
            If data.Rows(0)("thursday").ToString = "1" Then
                CEThursday.Checked = True
            Else
                CEThursday.Checked = False
            End If
            '
            If data.Rows(0)("friday").ToString = "1" Then
                CEFriday.Checked = True
            Else
                CEFriday.Checked = False
            End If
            '
            If data.Rows(0)("saturday").ToString = "1" Then
                CESaturday.Checked = True
            Else
                CESaturday.Checked = False
            End If
        End If
    End Sub

    Private Sub FormEmpShiftDet_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub BCancel_Click(sender As Object, e As EventArgs) Handles BCancel.Click
        Close()
    End Sub

    Private Sub BSave_Click(sender As Object, e As EventArgs) Handles BSave.Click
        Dim end_tolerance, shift_name, shift_code, start_work, end_work, start_break, end_break, start_tolerance, minutes_work, sun, mon, tues, wed, thurs, fri, sat, is_start_daybefore, is_start_tol_daybefore, is_end_dayafter, ignore_holiday As String

        shift_name = TEShiftName.Text
        shift_code = TEShiftCode.Text
        start_work = Date.Parse(TEWorkStart.EditValue.ToString).ToString("HH:mm:ss")
        end_work = Date.Parse(TEWorkEnd.EditValue.ToString).ToString("HH:mm:ss")
        start_break = Date.Parse(TEBreakStart.EditValue.ToString).ToString("HH:mm:ss")
        end_break = Date.Parse(TEBreakEnd.EditValue.ToString).ToString("HH:mm:ss")
        start_tolerance = Date.Parse(TEWorkStartTol.EditValue.ToString).ToString("HH:mm:ss")
        end_tolerance = TEEndTolerance.EditValue.ToString
        minutes_work = TEMinutes.EditValue.ToString
        '
        sun = If(CESunday.Checked = True, 1, 0)
        mon = If(CEMonday.Checked = True, 1, 0)
        tues = If(CETuesday.Checked = True, 1, 0)
        wed = If(CEWednesday.Checked = True, 1, 0)
        thurs = If(CEThursday.Checked = True, 1, 0)
        fri = If(CEFriday.Checked = True, 1, 0)
        sat = If(CESaturday.Checked = True, 1, 0)
        '
        If CEStartNext.Checked = True Then
            is_start_daybefore = "1"
        Else
            is_start_daybefore = "2"
        End If
        '
        If CETolNext.Checked = True Then
            is_start_tol_daybefore = "1"
        Else
            is_start_tol_daybefore = "2"
        End If
        '
        If CEEndNext.Checked = True Then
            is_end_dayafter = "1"
        Else
            is_end_dayafter = "2"
        End If
        '
        If CEHoliday.Checked = True Then
            ignore_holiday = "1"
        Else
            ignore_holiday = "2"
        End If
        '
        If id_shift = "-1" Then 'new
            Dim query As String = ""
            query = "INSERT INTO tb_emp_shift(shift_name,shift_code,start_work,late_start_tolerance,end_work,start_break,end_break,minutes_work,monday,tuesday,wednesday,thursday,friday,saturday,sunday,is_start_daybefore,is_start_tol_daybefore,is_end_dayafter,is_ignore_holiday,out_tolerance)"
            query += "VALUES('" + shift_name + "','" + shift_code + "','" + start_work + "','" + start_tolerance + "','" + end_work + "','" + start_break + "','" + end_break + "','" + minutes_work + "','" + mon + "','" + tues + "','" + wed + "','" + thurs + "','" + fri + "','" + sat + "','" + sun + "','" & is_start_daybefore & "','" & is_start_tol_daybefore & "','" & is_end_dayafter & "','" & ignore_holiday & "','" & end_tolerance & "')"
            execute_non_query(query, True, "", "", "", "")

            FormEmpShift.load_schedule()

            Close()
        Else
            Dim query As String = ""
            query = "UPDATE tb_emp_shift SET shift_name='" + shift_name + "',shift_code='" + shift_code + "',start_work='" + start_work + "',late_start_tolerance='" + start_tolerance + "',end_work='" + end_work + "',start_break='" + start_break + "',end_break='" + end_break + "',minutes_work='" + minutes_work + "',monday='" + mon + "',tuesday='" + tues + "',wednesday='" + wed + "',thursday='" + thurs + "',friday='" + fri + "',saturday='" + sat + "',sunday='" + sun + "',is_start_daybefore='" & is_start_daybefore & "',is_start_tol_daybefore='" & is_start_tol_daybefore & "',is_end_dayafter='" & is_end_dayafter & "',is_ignore_holiday='" & ignore_holiday & "',out_tolerance='" & end_tolerance & "' WHERE id_shift='" + id_shift + "'"
            execute_non_query(query, True, "", "", "", "")

            FormEmpShift.load_schedule()

            Close()
        End If
    End Sub
End Class