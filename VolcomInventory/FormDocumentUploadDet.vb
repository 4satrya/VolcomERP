Public Class FormDocumentUploadDet
    Public file_address As List(Of String) = New List(Of String)
    Public file_name As List(Of String) = New List(Of String)
    Public file_ext As List(Of String) = New List(Of String)

    Public id_report As String = "0"
    Public report_mark_type As String = "0"

    Public directory_upload As String = get_setup_field("upload_dir")
    Public is_only_pdf As Boolean = False

    Private default_height As Integer = 0

    Private panel_list As List(Of DevExpress.XtraEditors.PanelControl) = New List(Of DevExpress.XtraEditors.PanelControl)

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
        fd.Multiselect = True

        If fd.ShowDialog() = DialogResult.OK Then
            For i = 0 To panel_list.Count - 1
                Controls.Remove(panel_list(i))
            Next

            Height = default_height

            panel_list = New List(Of DevExpress.XtraEditors.PanelControl)

            file_address = New List(Of String)
            file_name = New List(Of String)
            file_ext = New List(Of String)

            If fd.FileNames.Length > 0 Then
                file_name.Add(System.IO.Path.GetFileNameWithoutExtension(fd.SafeFileNames.GetValue(0)))
                file_address.Add(fd.FileNames.GetValue(0))
                file_ext.Add(System.IO.Path.GetExtension(fd.SafeFileNames.GetValue(0)))

                BUploadFile.Text = file_address(0)
                TEFileName.Text = file_name(0)
            End If

            If fd.FileNames.Length > 1 Then
                For i = 1 To fd.FileNames.Length - 1
                    file_name.Add(System.IO.Path.GetFileNameWithoutExtension(fd.SafeFileNames.GetValue(i)))
                    file_address.Add(fd.FileNames.GetValue(i))
                    file_ext.Add(System.IO.Path.GetExtension(fd.SafeFileNames.GetValue(i)))

                    Dim panel_control As DevExpress.XtraEditors.PanelControl = New DevExpress.XtraEditors.PanelControl
                    panel_control.Dock = DockStyle.Top
                    panel_control.Height = 70
                    Controls.Add(panel_control)
                    panel_list.Add(panel_control)
                    panel_control.BringToFront()

                    Dim label_control1 As DevExpress.XtraEditors.LabelControl = New DevExpress.XtraEditors.LabelControl
                    label_control1.Text = "File"
                    label_control1.Location = New Point(12, 15)
                    panel_control.Controls.Add(label_control1)

                    Dim label_control2 As DevExpress.XtraEditors.LabelControl = New DevExpress.XtraEditors.LabelControl
                    label_control2.Text = "File Description"
                    label_control2.Location = New Point(12, 41)
                    panel_control.Controls.Add(label_control2)

                    Dim button_edit As DevExpress.XtraEditors.TextEdit = New DevExpress.XtraEditors.TextEdit
                    button_edit.Size = New Size(445, 20)
                    button_edit.Location = New Point(101, 12)
                    button_edit.Properties.ReadOnly = True
                    button_edit.Text = file_address(i)
                    button_edit.Tag = "ButtonEdit"
                    panel_control.Controls.Add(button_edit)

                    Dim text_edit As DevExpress.XtraEditors.TextEdit = New DevExpress.XtraEditors.TextEdit
                    text_edit.Size = New Size(445, 20)
                    text_edit.Location = New Point(101, 38)
                    text_edit.Text = file_name(i)
                    text_edit.Tag = "TextEdit"
                    panel_control.Controls.Add(text_edit)
                Next
            End If

            PanelControl2.BringToFront()

            CenterToScreen()
        End If
    End Sub

    Private Sub FormDocumentUploadDet_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        default_height = Height
    End Sub


    Private Sub BCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BCancel.Click
        Close()
    End Sub

    Private Sub BUpload_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BUpload.Click
        Try
            'save db
            'Dim query As String = "INSERT INTO tb_doc(doc_desc,report_mark_type,id_report,datetime,ext,id_user_upload) VALUES('" & addSlashes(TEFileName.Text) & "','" & report_mark_type & "','" & id_report & "',NOW(),'" & file_ext & "','" & id_user & "');SELECT LAST_INSERT_ID() "
            'Dim last_id As String = execute_query(query, 0, True, "", "", "", "")
            'upload
            'Dim path As String = directory_upload & report_mark_type & "\"
            'If Not IO.Directory.Exists(path) Then
            '    System.IO.Directory.CreateDirectory(path)
            'End If
            'My.Computer.Network.UploadFile(file_address, path & last_id & "_" & report_mark_type & "_" & id_report & file_ext, "", "", True, 100, True)
            '
            'FormDocumentUpload.refresh_load(report_mark_type)
            '
            'Close()
        Catch ex As Exception
            stopCustom(ex.ToString)
        End Try
    End Sub

    Private Sub FormDocumentUploadDet_FormClosed(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub BUploadenc_Click(sender As Object, e As EventArgs) Handles BUploadenc.Click
        If Not BUploadFile.Text = "" Then
            panel_list.Insert(0, PanelControl1)

            For i = 0 To panel_list.Count - 1
                Dim file_address_txt As String = ""
                Dim file_name_txt As String = ""
                Dim file_ext_txt As String = ""

                For Each c In panel_list(i).Controls
                    Dim te As Object = New Object

                    If c.GetType.ToString = "DevExpress.XtraEditors.TextEdit" Then
                        te = CType(c, DevExpress.XtraEditors.TextEdit)
                    ElseIf c.GetType.ToString = "DevExpress.XtraEditors.ButtonEdit" Then
                        te = CType(c, DevExpress.XtraEditors.ButtonEdit)
                    Else
                        Continue For
                    End If

                    If te.Tag.ToString = "ButtonEdit" Then
                        file_address_txt = te.Text
                        file_ext_txt = System.IO.Path.GetExtension(te.Text)
                    End If

                    If te.Tag.ToString = "TextEdit" Then
                        file_name_txt = te.Text
                    End If
                Next

                Try
                    'save db
                    Dim query As String = "INSERT INTO tb_doc(doc_desc,report_mark_type,id_report,datetime,ext,id_user_upload,is_encrypted) VALUES('" & addSlashes(file_name_txt) & "','" & report_mark_type & "','" & id_report & "',NOW(),'" & file_ext_txt & "','" & id_user & "','1');SELECT LAST_INSERT_ID() "
                    Dim last_id As String = execute_query(query, 0, True, "", "", "", "")
                    'upload
                    Dim path As String = directory_upload & report_mark_type & "\"
                    If Not IO.Directory.Exists(path) Then
                        System.IO.Directory.CreateDirectory(path)
                    End If
                    Dim file_path As String = path & last_id & "_" & report_mark_type & "_" & id_report & "_temp" & file_ext_txt
                    Dim file_path_enc As String = path & last_id & "_" & report_mark_type & "_" & id_report & file_ext_txt

                    My.Computer.Network.UploadFile(file_address_txt, file_path, "", "", True, 100, True)

                    CryptFile.EncryptFile(get_setup_field("en_phrase"), file_path, file_path_enc)

                    My.Computer.FileSystem.DeleteFile(file_path)

                    '
                    FormDocumentUpload.refresh_load(report_mark_type)
                    '
                    Close()
                Catch ex As Exception
                    stopCustom(ex.ToString)
                End Try
            Next

            panel_list.RemoveAt(0)
        End If
    End Sub
End Class