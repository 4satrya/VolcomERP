Public Class FormMasterEmployeeTraining
    Public id_employee As String = "-1"
    Public id_employee_training As String = "-1"

    Sub load_document()
        Dim query_doc As String = "SELECT id_employee_training_doc, description, ext, 'yes' is_download FROM tb_m_employee_training_doc WHERE id_employee_training = '" + id_employee_training + "' AND is_cancel = '2'"

        Dim data_doc As DataTable = execute_query(query_doc, -1, True, "", "", "", "")

        GCDocument.DataSource = data_doc
    End Sub

    Private Sub FormMasterEmployeeTraining_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        FormMasterEmployeeNewDet.viewEmployeeTraining()

        If id_employee_training <> "-1" Then
            FormMasterEmployeeNewDet.GVTraining.FocusedRowHandle = find_row(FormMasterEmployeeNewDet.GVTraining, "id_employee_training", id_employee_training)
        End If

        Dispose()
    End Sub

    Private Sub BtnSave_Click(sender As Object, e As EventArgs) Handles BtnSave.Click
        ValidateChildren()

        If Not formIsValid(ErrorProvider1) Then
            errorInput()
        Else
            Dim course As String = TxtCourse.EditValue.ToString
            Dim institution As String = TxtInstitution.EditValue.ToString
            Dim date_from As String = Date.Parse(TxtDateFrom.EditValue.ToString).ToString("yyyy-MM-dd")
            Dim date_until As String = Date.Parse(TxtDateUntil.EditValue.ToString).ToString("yyyy-MM-dd")

            Dim query As String = "INSERT INTO tb_m_employee_training(id_employee, course, institution, date_from, date_until, is_cancel) VALUES ('" + id_employee + "', '" + addSlashes(course) + "', '" + addSlashes(institution) + "', '" + date_from + "', '" + date_until + "', '2'); SELECT LAST_INSERT_ID();"

            id_employee_training = execute_query(query, 0, True, "", "", "", "")

            load_form()
            'Close()
        End If
    End Sub

    Private Sub TxtDateFrom_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles TxtDateFrom.Validating
        EP_DE_cant_blank(ErrorProvider1, TxtDateFrom)
    End Sub

    Private Sub TxtDateUntil_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles TxtDateUntil.Validating
        EP_DE_cant_blank(ErrorProvider1, TxtDateUntil)
    End Sub

    Private Sub TxtCourse_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles TxtCourse.Validating
        EP_TE_cant_blank(ErrorProvider1, TxtCourse)
    End Sub

    Private Sub TxtInstitution_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles TxtInstitution.Validating
        EP_TE_cant_blank(ErrorProvider1, TxtInstitution)
    End Sub

    Sub load_form()
        If id_employee_training = "-1" Then
            TxtCourse.Enabled = True
            TxtInstitution.Enabled = True
            TxtDateFrom.Enabled = True
            TxtDateUntil.Enabled = True
            BtnSave.Enabled = True

            LabelDocument.Enabled = False
            GCDocument.Enabled = False
            BtnAddDocument.Enabled = False
            BtnDelDocument.Enabled = False
        Else
            TxtCourse.Enabled = False
            TxtInstitution.Enabled = False
            TxtDateFrom.Enabled = False
            TxtDateUntil.Enabled = False
            BtnSave.Enabled = False

            LabelDocument.Enabled = True
            GCDocument.Enabled = True
            BtnAddDocument.Enabled = True
            BtnDelDocument.Enabled = True

            Dim query As String = "SELECT id_employee_training, course, institution, DATE_FORMAT(date_from, '%d %M %Y') date_from, DATE_FORMAT(date_until, '%d %M %Y') date_until FROM tb_m_employee_training WHERE id_employee_training = '" + id_employee_training + "'"

            Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")

            TxtCourse.EditValue = data.Rows(0)("course").ToString
            TxtInstitution.EditValue = data.Rows(0)("institution").ToString
            TxtDateFrom.EditValue = data.Rows(0)("date_from").ToString
            TxtDateUntil.EditValue = data.Rows(0)("date_until").ToString

            'document
            load_document()

            If GVDocument.RowCount < 1 Then
                BtnDelDocument.Enabled = False
            End If
        End If
    End Sub

    Private Sub FormMasterEmployeeTraining_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        load_form()
    End Sub

    Private Sub BtnAddDocument_Click(sender As Object, e As EventArgs) Handles BtnAddDocument.Click
        FormMasterEmployeeTrainingDoc.id_employee_training = id_employee_training
        FormMasterEmployeeTrainingDoc.ShowDialog()
    End Sub

    Private Sub BtnDelDocument_Click(sender As Object, e As EventArgs) Handles BtnDelDocument.Click
        Dim confirm As DialogResult = DevExpress.XtraEditors.XtraMessageBox.Show("Are you sure want to delete this document?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)

        Dim id_employee_training_doc As String = GVDocument.GetFocusedRowCellDisplayText("id_employee_training_doc").ToString

        If confirm = Windows.Forms.DialogResult.Yes Then
            Try
                Dim query As String = "UPDATE tb_m_employee_training_doc SET is_cancel='1' WHERE id_employee_training_doc='" + id_employee_training_doc + "'"

                execute_non_query(query, True, "", "", "", "")

                load_form()
            Catch ex As Exception
                errorDelete()
            End Try
        End If
    End Sub

    Private Sub RICE_Click(sender As Object, e As EventArgs) Handles RICE.Click
        Dim dest As String = Application.StartupPath + "\download\"

        'create directory if not exist
        If Not IO.Directory.Exists(dest) Then
            System.IO.Directory.CreateDirectory(dest)
        End If

        If GVDocument.GetFocusedRowCellValue("description").ToString <> "" Then
            dest += GVDocument.GetFocusedRowCellValue("description").ToString + "_"
        End If
        dest += GVDocument.GetFocusedRowCellValue("id_employee_training_doc").ToString
        dest += GVDocument.GetFocusedRowCellValue("ext").ToString

        Dim address As String = get_setup_field("upload_dir") + "training\" + GVDocument.GetFocusedRowCellValue("id_employee_training_doc").ToString + GVDocument.GetFocusedRowCellValue("ext").ToString

        'download
        My.Computer.Network.DownloadFile(address, dest, "", "", True, 100, True)

        'open folder
        If IO.File.Exists(dest) Then
            Dim open_folder As ProcessStartInfo = New ProcessStartInfo()
            open_folder.WindowStyle = ProcessWindowStyle.Maximized
            open_folder.FileName = "explorer.exe"
            open_folder.Arguments = "/select,""" + dest + """"
            Process.Start(open_folder)
        Else
            stopCustom("No Supporting Document !")
        End If
    End Sub

    Private Sub RICE_MouseHover(sender As Object, e As EventArgs) Handles RICE.MouseHover
        Cursor = Cursors.Hand
    End Sub

    Private Sub RICE_MouseLeave(sender As Object, e As EventArgs) Handles RICE.MouseLeave
        Cursor = Cursors.Default
    End Sub
End Class