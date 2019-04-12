Public Class FormMasterEmployeeTrainingDoc
    Public id_employee_training As String = "-1"
    Public ext As String = ""

    Private Sub FormMasterEmployeeTrainingDoc_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub TxtFile_ButtonClick(sender As Object, e As DevExpress.XtraEditors.Controls.ButtonPressedEventArgs) Handles TxtFile.ButtonClick
        Dim fd As OpenFileDialog = New OpenFileDialog()

        fd.Title = "Upload file"
        fd.InitialDirectory = "C:\"
        'fd.Filter = "Pdf Files|*.pdf"
        fd.Filter = "All files (*.*)|*.*|All files (*.*)|*.*"

        fd.FilterIndex = 2
        fd.RestoreDirectory = True

        If fd.ShowDialog() = DialogResult.OK Then
            TxtFile.EditValue = fd.FileName
            ext = System.IO.Path.GetExtension(fd.SafeFileName)
        End If
    End Sub

    Private Sub BtnUpload_Click(sender As Object, e As EventArgs) Handles BtnUpload.Click
        ValidateChildren()

        If Not formIsValid(ErrorProvider1) Then
            errorInput()
        Else
            Dim query As String = "INSERT INTO tb_m_employee_training_doc(id_employee_training, description, ext, is_cancel) VALUES ('" + id_employee_training + "', '" + TxtDescription.EditValue.ToString + "', '" + ext + "', '2'); SELECT LAST_INSERT_ID();"

            Dim id_employee_training_doc As String = execute_query(query, 0, True, "", "", "", "")

            Dim path As String = get_setup_field("upload_dir") + "training\" + id_employee_training_doc + ext

            My.Computer.Network.UploadFile(TxtFile.EditValue.ToString, path, "", "", True, 100, True)

            FormMasterEmployeeTraining.load_form()

            Close()
        End If
    End Sub

    Private Sub TxtFile_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles TxtFile.Validating
        If TxtFile.EditValue Is Nothing Then
            ErrorProvider1.SetError(TxtFile, "Don't leave this field blank.")
        Else
            ErrorProvider1.SetError(TxtFile, String.Empty)
        End If
    End Sub
End Class