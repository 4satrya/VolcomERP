Public Class FormEmpShift
    Dim bnew_active As String = "1"
    Dim bedit_active As String = "1"
    Dim bdel_active As String = "1"

    Private Sub FormEmpSchedule_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub FormEmpSchedule_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        load_schedule()
    End Sub
    Sub load_schedule()
        Dim query As String = "SELECT *,IF(monday=1 AND tuesday=1 AND wednesday=1 AND thursday=1 AND friday=1 AND saturday=1 AND sunday=1,'Everyday',
                                CONCAT(If(sunday=1,'Sunday,',''),IF(monday=1,'Monday,',''),IF(tuesday=1,'Tuesday,',''),IF(wednesday=1,'Wednesday,',''),IF(thursday=1,'Thursday,',''),IF(friday=1,'Friday,',''),IF(saturday=1,'Saturday',''))) AS workday 
                                FROM tb_emp_shift "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCShift.DataSource = data
        GVShift.BestFitColumns()
    End Sub

    Private Sub FormEmpShift_Activated(sender As Object, e As EventArgs) Handles MyBase.Activated
        FormMain.show_rb(Name)
        checkFormAccess(Name)
        button_main(bnew_active, bedit_active, bdel_active)
    End Sub

    Private Sub FormEmpShift_Deactivate(sender As Object, e As EventArgs) Handles MyBase.Deactivate
        FormMain.hide_rb()
    End Sub
End Class