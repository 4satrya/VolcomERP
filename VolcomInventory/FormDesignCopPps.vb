Public Class FormDesignCopPps
    Dim id_pps As String = "-1"
    Dim id_design As String = "-1"
    Dim is_production As String = "-1"
    Private Sub BtnCancel_Click(sender As Object, e As EventArgs) Handles BtnCancel.Click
        Close()
    End Sub

    Private Sub FormDesignCopPps_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub FormDesignCopPps_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim q As String = "SELECT design_code,design_display_name FROM tb_m_design where id_design='" & id_design & "'"
        Dim dt As DataTable = execute_query(q, -1, True, "", "", "", "")
        If dt.Rows.Count > 0 Then
            TEDesc.Text = dt.Rows(0)("design_display_name").ToString
            TECode.Text = dt.Rows(0)("design_code").ToString
        End If
        '
        If id_pps = "-1" Then
        Else

        End If
    End Sub

    Private Sub TEVendor_EditValueChanged(sender As Object, e As EventArgs) Handles TEVendor.EditValueChanged

    End Sub

    Private Sub BDelete_Click(sender As Object, e As EventArgs) Handles BDelete.Click

    End Sub

    Private Sub BAdd_Click(sender As Object, e As EventArgs) Handles BAdd.Click

    End Sub
End Class