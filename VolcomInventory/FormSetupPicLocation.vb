Public Class FormSetupPicLocation
    Sub path_folder(ByVal TextEdit As DevExpress.XtraEditors.TextEdit)
        Try
            Dim fbd = New FolderBrowserDialog
            fbd.Description = "Choose folder location, example D:\picture"
            fbd.ShowDialog()
            fbd.ShowNewFolderButton = True
            TextEdit.Text = fbd.SelectedPath.ToString
        Catch ex As Exception
            errorConnection()
        End Try
    End Sub

    Private Sub BBrowseMat_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BBrowseMat.Click
        path_folder(TEPicMat)
    End Sub

    Private Sub BBrowseSample_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BBrowseSample.Click
        path_folder(TEPicSample)
    End Sub

    Private Sub BBrowseDesign_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BBrowseDesign.Click
        path_folder(TEPicDesign)
    End Sub


    Private Sub BBrowseLogo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BBrowseLogo.Click
        path_folder(TEPicLogo)
    End Sub
    Private Sub TEPicMat_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TEPicMat.Validating
        EP_TE_cant_blank(EPPicLocation, TEPicMat)
    End Sub

    Private Sub TEPicSample_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TEPicSample.Validating
        EP_TE_cant_blank(EPPicLocation, TEPicSample)
    End Sub

    Private Sub TEPicDesign_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TEPicDesign.Validating
        EP_TE_cant_blank(EPPicLocation, TEPicDesign)
    End Sub

    Private Sub TEPicLogo_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TEPicLogo.Validating
        EP_TE_cant_blank(EPPicLocation, TEPicLogo)
    End Sub
    Private Sub BSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BSave.Click
        'Try
        Dim mat_path, sample_path, design_path, logo_path As String

            '
            EP_TE_cant_blank(EPPicLocation, TEPicMat)
            EP_TE_cant_blank(EPPicLocation, TEPicSample)
            EP_TE_cant_blank(EPPicLocation, TEPicDesign)
            EP_TE_cant_blank(EPPicLocation, TEPicLogo)
            '
            If Not formIsValidInPanel(EPPicLocation, PC2) Then
                errorInput()
            Else
                If Not System.IO.File.Exists(TEPicMat.Text & "\default.jpg") Then
                    System.IO.File.Copy(My.Application.Info.DirectoryPath.ToString & "\pic_default.jpg", TEPicMat.Text & "\default.jpg", True)
                End If

                If Not System.IO.File.Exists(TEPicSample.Text & "\default.jpg") Then
                    System.IO.File.Copy(My.Application.Info.DirectoryPath.ToString & "\pic_default.jpg", TEPicSample.Text & "\default.jpg", True)
                End If

                If Not System.IO.File.Exists(TEPicDesign.Text & "\default.jpg") Then
                    System.IO.File.Copy(My.Application.Info.DirectoryPath.ToString & "\pic_default.jpg", TEPicDesign.Text & "\default.jpg", True)
                End If

                If Not System.IO.File.Exists(TEPicLogo.Text & "\default.jpg") Then
                    System.IO.File.Copy(My.Application.Info.DirectoryPath.ToString & "\pic_default.jpg", TEPicLogo.Text & "\default.jpg", True)
                End If

                mat_path = Replace(TEPicMat.Text, "\", "\\")
                sample_path = Replace(TEPicSample.Text, "\", "\\")
                design_path = Replace(TEPicDesign.Text, "\", "\\")
                logo_path = Replace(TEPicLogo.Text, "\", "\\")
                Dim query As String = String.Format("UPDATE tb_opt SET pic_path_mat='{0}', pic_path_sample='{1}', pic_path_design='{2}', pic_path_logo='{3}'", mat_path, sample_path, design_path, logo_path)
                execute_non_query(query, True, "", "", "", "")
                If id_user = "" Then
                    FormMain.LoginToolStripMenuItem.Visible = True
                End If
                loadImgPath()
                Close()
            End If
        'Catch ex As Exception
        '    errorCustom("please check your picture path or your database connection!")
        'End Try
    End Sub

    Private Sub FormSetup_FormClosed(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub FormSetupPicLocation_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            Dim query As String = String.Format("SELECT pic_path_mat,pic_path_sample,pic_path_design, pic_path_logo FROM tb_opt")
            Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
            TEPicMat.Text = data.Rows(0)("pic_path_mat").ToString
            TEPicSample.Text = data.Rows(0)("pic_path_sample").ToString
            TEPicDesign.Text = data.Rows(0)("pic_path_design").ToString
            TEPicLogo.Text = data.Rows(0)("pic_path_logo").ToString
            data.Dispose()
            '

        Catch ex As Exception
        End Try
    End Sub
End Class