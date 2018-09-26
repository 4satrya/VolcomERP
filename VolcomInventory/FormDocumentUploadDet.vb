Public Class FormDocumentUploadDet 
    Public file_address As String = ""
    Public file_name As String = ""
    Public file_ext As String = ""

    Public id_report As String = "0"
    Public report_mark_type As String = "0"

    Public directory_upload As String = get_setup_field("upload_dir")
    Public is_only_pdf As Boolean = False

    Private Sub BUploadFile_ButtonClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraEditors.Controls.ButtonPressedEventArgs) Handles BUploadFile.ButtonClick
        Dim fd As OpenFileDialog = New OpenFileDialog()

        fd.Title = "Upload file"
        fd.InitialDirectory = "C:\"
        If is_only_pdf Then
            fd.Filter = "Pdf Files|*.pdf"
        Else
            fd.Filter = "All files (*.*)|*.*|All files (*.*)|*.*"
        End If

        fd.FilterIndex = 2
        fd.RestoreDirectory = True

        If fd.ShowDialog() = DialogResult.OK Then
            file_name = System.IO.Path.GetFileNameWithoutExtension(fd.SafeFileName)
            file_address = fd.FileName
            file_ext = System.IO.Path.GetExtension(fd.SafeFileName)
        End If

        BUploadFile.Text = file_address
        TEFileName.Text = file_name
    End Sub

    Private Sub FormDocumentUploadDet_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        
    End Sub


    Private Sub BCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BCancel.Click
        Close()
    End Sub

    Private Sub BUpload_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BUpload.Click
        Try
            'save db
            Dim query As String = "INSERT INTO tb_doc(doc_desc,report_mark_type,id_report,datetime,ext,id_user_upload) VALUES('" & addSlashes(TEFileName.Text) & "','" & report_mark_type & "','" & id_report & "',NOW(),'" & file_ext & "','" & id_user & "');SELECT LAST_INSERT_ID() "
            Dim last_id As String = execute_query(query, 0, True, "", "", "", "")
            'upload
            Dim path As String = directory_upload & report_mark_type & "\"
            If Not IO.Directory.Exists(path) Then
                System.IO.Directory.CreateDirectory(path)
            End If
            My.Computer.Network.UploadFile(file_address, path & last_id & "_" & report_mark_type & "_" & id_report & file_ext, "", "", True, 100, True)
            FormDocumentUpload.view_file()
            Close()
        Catch ex As Exception
            stopCustom(ex.ToString)
        End Try
    End Sub

    Private Sub FormDocumentUploadDet_FormClosed(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub
End Class