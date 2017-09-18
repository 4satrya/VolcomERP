Public Class FormMasterCargoRateAdd
    Public id_cargo_rate As String = "-1"

    Private Sub BCancel_Click(sender As Object, e As EventArgs) Handles BCancel.Click
        Close()
    End Sub

    Private Sub FormMasterCargoRateAdd_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub FormMasterCargoRateAdd_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If Not id_cargo_rate = "-1" Then 'edit
            Dim query As String = "SELECT * FROM tb_m_cargo_rate WHERE id_cargo_rate='" & id_cargo_rate & "'"
            Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")

            If data.Rows.Count > 0 Then
                TECargoCode.Text = data.Rows(0)("cargo_code").ToString
                TECargoDestination.Text = data.Rows(0)("destination").ToString
                TECargoZone.Text = data.Rows(0)("zone").ToString
            End If
        End If
    End Sub

    Private Sub BSave_Click(sender As Object, e As EventArgs) Handles BSave.Click
        Dim cargo_code As String = ""
        Dim zone As String = ""
        Dim destination As String = ""
        '
        cargo_code = addSlashes(TECargoCode.Text)
        zone = addSlashes(TECargoZone.Text)
        destination = addSlashes(TECargoDestination.Text)
        '
        If id_cargo_rate = "-1" Then 'new
            Dim query As String = "INSERT INTO tb_m_cargo_rate(cargo_code,zone,destination) VALUES('" & cargo_code & "','" & zone & "','" & destination & "'); SELECT LAST_INSERT_ID()"
            id_cargo_rate = execute_query(query, 0, True, "", "", "", "")

            FormMasterCargoRate.load_cargo_rate()
            FormMasterCargoRate.GVCargoRate.FocusedRowHandle = find_row(FormMasterCargoRate.GVCargoRate, "id_cargo_rate", id_cargo_rate)
            Close()
        Else 'edit
            Dim query As String = "UPDATE tb_m_cargo_rate SET cargo_code='" & cargo_code & "',zone='" & zone & "',destination='" & destination & "' WHERE id_cargo_rate='" & id_cargo_rate & "'"
            execute_non_query(query, True, "", "", "", "")

            FormMasterCargoRate.load_cargo_rate()
            FormMasterCargoRate.GVCargoRate.FocusedRowHandle = find_row(FormMasterCargoRate.GVCargoRate, "id_cargo_rate", id_cargo_rate)
            Close()
        End If
    End Sub
End Class