Public Class FormFabricTypeDet
    Public id As String = "-1"

    Private Sub FormFabricTypeDet_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub FormFabricTypeDet_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        TEAge.EditValue = 0
        If Not id = "-1" Then 'edit
            Dim q As String = "SELECT * FROM tb_m_fabric_type WHERE id_fabric_type='" & id & "'"
            Dim dt As DataTable = execute_query(q, -1, True, "", "", "", "")
            If dt.Rows.Count > 0 Then
                TEAge.EditValue = dt.Rows(0)("age")
                TEFabricType.Text = dt.Rows(0)("fabric_type_name").ToString
                TEFabrication.Text = dt.Rows(0)("fabrication").ToString
            End If
            '
            q = "SELECT * FROM tb_m_design WHERE id_fabric_type='" & id & "'"
            dt = execute_query(q, -1, True, "", "", "", "")
            If dt.Rows.Count > 0 Then
                warningCustom("This type already use on line list.")
                BSave.Visible = False
            End If
        End If
    End Sub

    Private Sub BCancel_Click(sender As Object, e As EventArgs) Handles BCancel.Click
        Close()
    End Sub

    Private Sub BSave_Click(sender As Object, e As EventArgs) Handles BSave.Click
        Dim age, fabric_type, fabrication As String
        age = TEAge.EditValue.ToString
        fabric_type = addSlashes(TEFabricType.Text)
        fabrication = addSlashes(TEFabrication.Text)

        If age = "" Or age = "0" Or fabric_type = "" Or fabrication = "" Then
            warningCustom("Please fill all field")
        Else
            If id = "-1" Then 'new
                Dim q As String = "INSERT INTO tb_m_fabric_type(fabric_type_name,fabrication,age) VALUES('" & fabric_type & "','" & fabrication & "','" & age & "')"
                execute_non_query(q, True, "", "", "", "")

                FormFabricType.load_list()
                infoCustom("Fabric type saved")
                Close()
            Else 'edit
                Dim q As String = "UPDATE tb_m_fabric_type SET fabric_type_name='" & fabric_type & "',fabrication='" & fabrication & "',age='" & age & "' WHERE id_fabric_type='" & id & "'"
                execute_non_query(q, True, "", "", "", "")

                FormFabricType.load_list()
                infoCustom("Fabric type saved")
                Close()
            End If
        End If
    End Sub
End Class