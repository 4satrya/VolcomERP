Public Class FormDesignImagesLog
    Private cloud_image_url As String = get_setup_field("cloud_image_url").ToString

    Private Sub FormDesignImagesLog_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim query As String = "
            SELECT l.file_name, CONCAT('" + cloud_image_url + "/', l.file_name) AS url, l.created_at, e.employee_name AS created_by, '' AS image
            FROM tb_design_images_log AS l
            LEFT JOIN tb_m_user AS u ON l.created_by = u.id_user
            LEFT JOIN tb_m_employee AS e ON u.id_employee = e.id_employee
            WHERE id_design_images = " + FormDesignImages.GVImageList.GetFocusedRowCellValue("id_design_images").ToString + "
            ORDER BY l.id_design_images_log DESC
        "

        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")

        GCImageList.DataSource = data

        GVImageList.BestFitColumns()
    End Sub

    Private Sub FormDesignImagesLog_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub SBCancel_Click(sender As Object, e As EventArgs) Handles SBCancel.Click
        Close()
    End Sub

    Private Sub RepositoryItemCheckEdit_Click(sender As Object, e As EventArgs) Handles RepositoryItemCheckEdit.Click
        Cursor = Cursors.WaitCursor

        'download file
        Dim client As Net.WebClient = New Net.WebClient

        Dim file As String = GVImageList.GetFocusedRowCellValue("file_name").ToString

        Dim path As String = Application.StartupPath + "\download\"

        If Not IO.Directory.Exists(path) Then
            System.IO.Directory.CreateDirectory(path)
        End If

        client.DownloadFile(cloud_image_url + "/" + file, path + file)

        'open file
        Dim process_info As ProcessStartInfo = New ProcessStartInfo()

        process_info.FileName = path + file

        process_info.WorkingDirectory = path

        Process.Start(process_info)

        Cursor = Cursors.Default
    End Sub

    Private Sub RepositoryItemCheckEdit_MouseHover(sender As Object, e As EventArgs) Handles RepositoryItemCheckEdit.MouseHover
        Cursor = Cursors.Hand
    End Sub

    Private Sub RepositoryItemCheckEdit_MouseLeave(sender As Object, e As EventArgs) Handles RepositoryItemCheckEdit.MouseLeave
        Cursor = Cursors.Default
    End Sub

    Private Sub RepositoryItemHyperLinkEdit_Click(sender As Object, e As EventArgs) Handles RepositoryItemHyperLinkEdit.Click
        Process.Start(GVImageList.GetFocusedRowCellValue("url").ToString)
    End Sub
End Class