Public Class FormDesignImagesDet
    Public data As DataTable = New DataTable

    Private cloud_host As String = get_setup_field("cloud_host").ToString
    Private cloud_username As String = get_setup_field("cloud_username").ToString
    Private cloud_password As String = get_setup_field("cloud_password").ToString
    Private cloud_port As String = get_setup_field("cloud_port").ToString

    Private cloud_image_path As String = get_setup_field("cloud_image_path").ToString
    Private cloud_image_url As String = get_setup_field("cloud_image_url").ToString

    Private Sub FormDesignImagesDet_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        load_form()
    End Sub

    Sub load_form()
        GCList.DataSource = data

        GVList.BestFitColumns()

        'controls
        Dim is_valid As Boolean = True

        For i = 0 To data.Rows.Count - 1
            If Not data.Rows(i)("status").ToString = "OK" Then
                is_valid = False
            End If
        Next

        If is_valid Then
            SBUpload.Visible = True
            SBBrowseFolder.Visible = False
        Else
            SBUpload.Visible = False
            SBBrowseFolder.Visible = True
        End If
    End Sub

    Private Sub FormDesignImagesDet_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub GVList_RowCellStyle(sender As Object, e As DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs) Handles GVList.RowCellStyle
        If GVList.GetRowCellValue(e.RowHandle, "status").ToString = "OK" Then
            e.Appearance.BackColor = Color.White
        Else
            e.Appearance.BackColor = Color.LightPink
        End If
    End Sub

    Private Sub SBUpload_Click(sender As Object, e As EventArgs) Handles SBUpload.Click
        Dim confirm As DialogResult = DevExpress.XtraEditors.XtraMessageBox.Show("Are you sure want to upload these images ?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)

        If confirm = DialogResult.Yes Then
            FormMain.SplashScreenManager1.ShowWaitForm()

            Dim design_code As DataTable = execute_query("SELECT id_design, design_code FROM tb_m_design WHERE design_code <> '' ORDER BY id_design DESC", -1, True, "", "", "", "")

            Dim last_id_design As String = ""

            'upload
            Dim sftp As Renci.SshNet.SftpClient = New Renci.SshNet.SftpClient(cloud_host, cloud_username, cloud_password)

            sftp.Connect()

            If sftp.IsConnected Then
                For i = 0 To GVList.RowCount - 1
                    FormMain.SplashScreenManager1.SetWaitFormDescription("Uploading file " + (i + 1).ToString + " of " + GVList.RowCount.ToString)

                    Dim file_stream As IO.FileStream = New IO.FileStream(GVList.GetRowCellValue(i, "file_name").ToString, IO.FileMode.Open)

                    sftp.UploadFile(file_stream, cloud_image_path + "/" + IO.Path.GetFileName(GVList.GetRowCellValue(i, "file_name").ToString))

                    file_stream.Close()
                    file_stream.Dispose()

                    'check design code
                    Dim array_name() As String = IO.Path.GetFileNameWithoutExtension(GVList.GetRowCellValue(i, "file_name").ToString).Split("_")

                    Dim dv_design As DataView = New DataView(design_code)

                    dv_design.RowFilter = "design_code = '" + array_name(1) + "'"

                    'store database
                    execute_non_query("INSERT INTO tb_design_images (id_design, store, file_name, sort, created_at, created_by) VALUES (" + dv_design(0)("id_design").ToString + ", '" + array_name(0) + "', '" + IO.Path.GetFileName(GVList.GetRowCellValue(i, "file_name").ToString) + "', " + array_name(2) + ", NOW(), " + id_user + ")", True, "", "", "", "")

                    last_id_design = dv_design(0)("id_design").ToString
                Next
            End If

            sftp.Disconnect()
            sftp.Dispose()

            FormMain.SplashScreenManager1.CloseWaitForm()

            Close()

            FormDesignImages.SLUESeason.EditValue = execute_query("SELECT id_season FROM tb_m_design WHERE id_design = " + last_id_design, 0, True, "", "", "", "")

            FormDesignImages.view_images()
        End If
    End Sub

    Private Sub SBBrowseFolder_Click(sender As Object, e As EventArgs) Handles SBBrowseFolder.Click
        Dim browse As FolderBrowserDialog = New FolderBrowserDialog

        browse.ShowDialog()

        If Not browse.SelectedPath = "" Then
            FormMain.SplashScreenManager1.ShowWaitForm()

            Dim data_validation As DataTable = FormDesignImages.get_validation(browse.SelectedPath)

            FormMain.SplashScreenManager1.CloseWaitForm()

            data = data_validation

            load_form()
        End If
    End Sub

    Private Sub RepositoryItemCheckEdit_Click(sender As Object, e As EventArgs) Handles RepositoryItemCheckEdit.Click
        Process.Start("explorer.exe", "/select," + GVList.GetFocusedRowCellValue("file_name").ToString)
    End Sub

    Private Sub RepositoryItemCheckEdit_MouseHover(sender As Object, e As EventArgs) Handles RepositoryItemCheckEdit.MouseHover
        Cursor = Cursors.Hand
    End Sub

    Private Sub RepositoryItemCheckEdit_MouseLeave(sender As Object, e As EventArgs) Handles RepositoryItemCheckEdit.MouseLeave
        Cursor = Cursors.Default
    End Sub

    Private Sub SBCancel_Click(sender As Object, e As EventArgs) Handles SBCancel.Click
        Close()
    End Sub
End Class