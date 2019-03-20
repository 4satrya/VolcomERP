Public Class FormDocumentScanUpload
    Public id_report As String = ""
    Public report_mark_type As String = ""

    Private Sub FormDocumentScanUpload_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        TEFilename.Text = "Scan " + Date.Parse(Now.ToString).ToString("dd MMMM yyyy hh-mm-ss")
    End Sub

    Private Sub BScan_Click(sender As Object, e As EventArgs) Handles BScan.Click
        PEScan.Image = Scanner.Scan
    End Sub

    Private zoomSpeedFactor As Single = 0.03F

    Private Sub PEScan_MouseWheel(sender As Object, e As MouseEventArgs) Handles PEScan.MouseWheel
        PEScan.Properties.ZoomPercent += e.Delta * zoomSpeedFactor
        DevExpress.Utils.DXMouseEventArgs.GetMouseArgs(e).Handled = True
    End Sub

    Private Sub BUpload_Click(sender As Object, e As EventArgs) Handles BUpload.Click
        Try
            If Not PEScan.Image Is Nothing Then
                Dim ext As String = ".jpg"
                save_image_ori(PEScan, Application.StartupPath + "\imagestemp\", "wiascanner" & ext)

                'save db
                Dim query As String = "INSERT INTO tb_doc(doc_desc,report_mark_type,id_report,datetime,ext,id_user_upload) VALUES('" & addSlashes(TEFilename.Text) & "','" & report_mark_type & "','" & id_report & "',NOW(),'" & ext & "','" & id_user & "');SELECT LAST_INSERT_ID() "
                Dim last_id As String = execute_query(query, 0, True, "", "", "", "")
                'upload
                Dim ftp_upload As String = get_setup_field("system_ftp_address")
                Dim directory_upload As String = get_setup_field("upload_dir")
                Dim user_upload As String = get_setup_field("system_ftp_user")
                Dim pass_upload As String = get_setup_field("system_ftp_pass")
                Dim path As String = directory_upload & report_mark_type & "\"
                Dim filename_upload As String = path & last_id & "_" & report_mark_type & "_" & id_report & ext
                Dim filename_temp As String = Application.StartupPath + "\imagestemp\wiascanner" & ext
                '
                Dim command As String = "/K net use " & ftp_upload & " /user:" & user_upload & " " & pass_upload & " & echo f | xcopy """ & filename_temp & """ """ & filename_upload & """ /Y & pause"
                Dim p As New ProcessStartInfo("CMD.EXE")

                p.WindowStyle = ProcessWindowStyle.Hidden
                p.CreateNoWindow = True
                p.UseShellExecute = False
                p.Arguments = command

                Process.Start(p)
                'end upload
                FormDocumentUpload.refresh_load(report_mark_type)
                '
                Close()
            Else
                errorCustom("Please scan image first.")
            End If

        Catch ex As Exception
            stopCustom(ex.ToString)
        End Try
    End Sub
End Class