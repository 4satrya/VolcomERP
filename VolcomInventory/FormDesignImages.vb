Public Class FormDesignImages
    Private cloud_host As String = get_setup_field("cloud_host").ToString
    Private cloud_username As String = get_setup_field("cloud_username").ToString
    Private cloud_password As String = get_setup_field("cloud_password").ToString
    Private cloud_port As String = get_setup_field("cloud_port").ToString

    Private cloud_image_path As String = get_setup_field("cloud_image_path").ToString
    Private cloud_image_url As String = get_setup_field("cloud_image_url").ToString

    Private Sub FormDesignImages_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        view_season()
    End Sub

    Private Sub FormDesignImages_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub FormDesignImages_Activated(sender As Object, e As EventArgs) Handles MyBase.Activated
        FormMain.show_rb(Name)
        checkFormAccess(Name)
    End Sub

    Private Sub FormDesignImages_Deactivate(sender As Object, e As EventArgs) Handles MyBase.Deactivate
        FormMain.hide_rb()
    End Sub

    Sub view_images()
        Dim where_season As String = "AND d.id_season = " + SLUESeason.EditValue.ToString

        Dim query As String = "
            SELECT i.id_design_images, d.design_code, i.store, d.design_display_name, i.file_name, i.sort, CONCAT('" + cloud_image_url + "/', i.file_name) AS url, i.created_at, e.employee_name AS created_by, '' AS image
            FROM tb_design_images AS i
            LEFT JOIN tb_m_design AS d ON d.id_design = i.id_design
            LEFT JOIN tb_m_user AS u ON i.created_by = u.id_user
            LEFT JOIN tb_m_employee AS e ON u.id_employee = e.id_employee
            WHERE 1 " + where_season + "
            ORDER BY d.design_display_name ASC, i.sort ASC
        "

        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")

        GCImageList.DataSource = data

        GVImageList.BestFitColumns()
    End Sub

    Sub browse_images()
        Dim browse As FolderBrowserDialog = New FolderBrowserDialog

        browse.ShowDialog()

        If Not browse.SelectedPath = "" Then
            FormMain.SplashScreenManager1.ShowWaitForm()

            Dim data_validation As DataTable = get_validation(browse.SelectedPath)

            FormMain.SplashScreenManager1.CloseWaitForm()

            FormDesignImagesDet.data = data_validation

            FormDesignImagesDet.ShowDialog()
        End If
    End Sub

    Function get_validation(path As String) As DataTable
        Dim file() As String = IO.Directory.GetFiles(path)

        Array.Sort(file)

        Dim is_valid As Boolean = True

        Dim uploaded_image As DataTable = execute_query("SELECT store, SUBSTRING(file_name, 1, (POSITION('.' IN file_name) - 1)) AS file_name, sort FROM tb_design_images", -1, True, "", "", "", "")

        'get max sort
        Dim data_max_sort As DataTable = New DataTable

        data_max_sort.Columns.Add("store", GetType(String))
        data_max_sort.Columns.Add("file_name", GetType(String))
        data_max_sort.Columns.Add("sort", GetType(Integer))

        Dim view_uploaded_image As DataView = New DataView(uploaded_image)

        view_uploaded_image.Sort = "file_name DESC, sort DESC"

        For i = 0 To view_uploaded_image.Count - 1
            Dim array_image() As String = view_uploaded_image(i)("file_name").ToString.Split("_")

            Dim dv_max_sort As DataView = New DataView(data_max_sort)

            dv_max_sort.RowFilter = "store = '" + array_image(0) + "' And file_name = '" + array_image(1) + "'"

            If dv_max_sort.Count = 0 Then
                Dim array_name() As String = view_uploaded_image(i)("file_name").ToString.Split("_")

                data_max_sort.Rows.Add(array_name(0), array_name(1), Integer.Parse(view_uploaded_image(i)("sort").ToString))
            End If
        Next

        Dim store_code As DataTable = execute_query("SELECT id_comp_group, design_images_code FROM tb_m_comp_group WHERE design_images_code IS NOT NULL", -1, True, "", "", "", "")

        Dim design_code As DataTable = execute_query("SELECT id_design, design_code FROM tb_m_design WHERE design_code <> '' ORDER BY id_design DESC", -1, True, "", "", "", "")

        Dim code_detail As DataTable = execute_query("SELECT d.design_code, c.id_code_detail FROM tb_m_design_code AS c LEFT JOIN tb_m_design AS d ON c.id_design = d.id_design", -1, True, "", "", "", "")

        Dim data_validation As DataTable = New DataTable

        data_validation.Columns.Add("file_name", GetType(String))
        data_validation.Columns.Add("status", GetType(String))

        For i = 0 To file.Count - 1
            FormMain.SplashScreenManager1.SetWaitFormDescription("Checking file " + (i + 1).ToString + " of " + file.Count.ToString)

            data_validation.Rows.Add(file(i), "OK")

            'check already uploaded
            Dim dv_uploaded As DataView = New DataView(uploaded_image)

            dv_uploaded.RowFilter = "file_name = '" + IO.Path.GetFileNameWithoutExtension(file(i)) + "'"

            If dv_uploaded.Count = 0 Then
                Dim array_name() As String = IO.Path.GetFileNameWithoutExtension(file(i)).Split("_")

                If array_name.Length = 3 Then
                    'check store code
                    Dim dv_store As DataView = New DataView(store_code)

                    dv_store.RowFilter = "design_images_code = '" + array_name(0) + "'"

                    If dv_store.Count < 1 Then
                        is_valid = False

                        data_validation.Rows(data_validation.Rows.Count - 1)("status") = "Err: store code not found."
                    End If

                    'check design code
                    Dim dv_design As DataView = New DataView(design_code)

                    dv_design.RowFilter = "design_code = '" + array_name(1) + "'"

                    If dv_design.Count < 1 Then
                        is_valid = False

                        data_validation.Rows(data_validation.Rows.Count - 1)("status") = "Err: design code not found."
                    End If

                    'check file number
                    Try
                        Integer.Parse(array_name(2))
                    Catch ex As Exception
                        is_valid = False

                        data_validation.Rows(data_validation.Rows.Count - 1)("status") = "Err: file number is not valid."
                    End Try
                Else
                    is_valid = False

                    data_validation.Rows(data_validation.Rows.Count - 1)("status") = "Err: file name is not valid."
                End If
            Else
                is_valid = False

                data_validation.Rows(data_validation.Rows.Count - 1)("status") = "Err: already uploaded."
            End If
        Next

        'check file sort
        If is_valid Then
            Dim data_file As DataTable = New DataTable

            data_file.Columns.Add("store", GetType(String))
            data_file.Columns.Add("file_name", GetType(String))
            data_file.Columns.Add("sort", GetType(Integer))

            For i = 0 To file.Count - 1
                Dim array_name() As String = IO.Path.GetFileNameWithoutExtension(file(i)).Split("_")

                data_file.Rows.Add(array_name(0), array_name(1), Integer.Parse(array_name(2)))
            Next

            Dim view_file As DataView = New DataView(data_file)

            view_file.Sort = "store ASC, file_name ASC, sort ASC"

            Dim last_store As String = ""
            Dim last_file_name As String = ""
            Dim last_sort As String = 0

            For i = 0 To view_file.Count - 1
                If i = 0 Then
                    last_store = view_file(i)("store").ToString
                    last_file_name = view_file(i)("file_name").ToString
                    last_sort = view_file(i)("sort")

                    'check max sort
                    Dim dv_max_sort As DataView = New DataView(data_max_sort)

                    dv_max_sort.RowFilter = "store = '" + view_file(i)("store").ToString + "' And file_name = '" + view_file(i)("file_name").ToString + "'"

                    If dv_max_sort.Count > 0 Then
                        If Not (dv_max_sort(0)("sort") + 1) = view_file(i)("sort") Then
                            is_valid = False

                            Dim fl_name As String = view_file(i)("store").ToString + "_" + view_file(i)("file_name").ToString

                            For j = 0 To data_validation.Rows.Count - 1
                                If data_validation.Rows(j)("file_name").ToString.Contains(fl_name) Then
                                    data_validation.Rows(j)("status") = "Err: please start numbering from " + (dv_max_sort(0)("sort") + 1).ToString + "."
                                End If
                            Next
                        End If
                    Else
                        If Not 1 = view_file(i)("sort") Then
                            is_valid = False

                            Dim fl_name As String = view_file(i)("store").ToString + "_" + view_file(i)("file_name").ToString

                            For j = 0 To data_validation.Rows.Count - 1
                                If data_validation.Rows(j)("file_name").ToString.Contains(fl_name) Then
                                    data_validation.Rows(j)("status") = "Err: please start numbering from 1."
                                End If
                            Next
                        End If
                    End If
                End If

                If last_store = view_file(i)("store").ToString And last_file_name = view_file(i)("file_name").ToString Then
                    If i > 0 Then
                        If Not view_file(i)("sort") = (last_sort + 1) Then
                            is_valid = False

                            Dim fl_name As String = view_file(i)("store").ToString + "_" + view_file(i)("file_name").ToString

                            For j = 0 To data_validation.Rows.Count - 1
                                If data_validation.Rows(j)("file_name").ToString.Contains(fl_name) Then
                                    data_validation.Rows(j)("status") = "Err: numbering is not valid."
                                End If
                            Next
                        End If
                    End If
                End If

                'check max sort
                If Not last_store = view_file(i)("store").ToString Or Not last_file_name = view_file(i)("file_name").ToString Then
                    Dim dv_max_sort As DataView = New DataView(data_max_sort)

                    dv_max_sort.RowFilter = "store = '" + view_file(i)("store").ToString + "' And file_name = '" + view_file(i)("file_name").ToString + "'"

                    If dv_max_sort.Count > 0 Then
                        If Not (dv_max_sort(0)("sort") + 1) = view_file(i)("sort") Then
                            is_valid = False

                            Dim fl_name As String = view_file(i)("store").ToString + "_" + view_file(i)("file_name").ToString

                            For j = 0 To data_validation.Rows.Count - 1
                                If data_validation.Rows(j)("file_name").ToString.Contains(fl_name) Then
                                    data_validation.Rows(j)("status") = "Err: please start numbering from " + (dv_max_sort(0)("sort") + 1).ToString + "."
                                End If
                            Next
                        End If
                    Else
                        If Not 1 = view_file(i)("sort") Then
                            is_valid = False

                            Dim fl_name As String = view_file(i)("store").ToString + "_" + view_file(i)("file_name").ToString

                            For j = 0 To data_validation.Rows.Count - 1
                                If data_validation.Rows(j)("file_name").ToString.Contains(fl_name) Then
                                    data_validation.Rows(j)("status") = "Err: please start numbering from 1."
                                End If
                            Next
                        End If
                    End If
                End If

                last_store = view_file(i)("store").ToString
                last_file_name = view_file(i)("file_name").ToString
                last_sort = view_file(i)("sort")
            Next
        End If

        'check number of files
        If is_valid Then
            Dim data_limit As DataTable = execute_query("SELECT * FROM tb_design_images_limit", -1, True, "", "", "", "")

            Dim total_file As DataTable = New DataTable

            total_file.Columns.Add("store", GetType(String))
            total_file.Columns.Add("file_name", GetType(String))
            total_file.Columns.Add("total", GetType(Integer))

            Dim last_store As String = ""
            Dim last_file_name As String = ""

            Dim n As Integer = 0

            For i = 0 To file.Count - 1
                Dim array_name() As String = IO.Path.GetFileNameWithoutExtension(file(i)).Split("_")

                If i = 0 Then
                    last_store = array_name(0)
                    last_file_name = array_name(1)
                End If

                If Not last_store = array_name(0) Or Not last_file_name = array_name(1) Then
                    Dim array_name_before() As String = IO.Path.GetFileNameWithoutExtension(file(i - 1)).Split("_")

                    total_file.Rows.Add(array_name_before(0), array_name_before(1), n)

                    n = 0
                End If

                n = n + 1

                If i = (file.Count - 1) Then
                    total_file.Rows.Add(array_name(0), array_name(1), n)
                End If

                last_store = array_name(0)
                last_file_name = array_name(1)
            Next

            For i = 0 To total_file.Rows.Count - 1
                Dim dv_uploaded_image As DataView = New DataView(uploaded_image)

                dv_uploaded_image.RowFilter = "store = '" + total_file.Rows(i)("store").ToString + "' And file_name Like '" + total_file.Rows(i)("store").ToString + "_" + total_file.Rows(i)("file_name").ToString + "_%'"

                If dv_uploaded_image.Count = 0 Then
                    Dim limit As Integer = Integer.Parse(data_limit.Rows(0)("limit").ToString)

                    Dim dv_code_detail As DataView = New DataView(code_detail)

                    dv_code_detail.RowFilter = "design_code = '" + total_file.Rows(i)("file_name").ToString + "'"

                    For j = 0 To dv_code_detail.Count - 1
                        Dim dv_limit As DataView = New DataView(data_limit)

                        dv_limit.RowFilter = "id_code_detail = " + dv_code_detail(j)("id_code_detail").ToString

                        If dv_limit.Count > 0 Then
                            limit = Integer.Parse(dv_limit(0)("limit").ToString)
                        End If
                    Next

                    If total_file(i)("total") < limit Then
                        is_valid = False

                        Dim fl_name As String = total_file(i)("store").ToString + "_" + total_file(i)("file_name").ToString

                        For j = 0 To data_validation.Rows.Count - 1
                            If data_validation.Rows(j)("file_name").ToString.Contains(fl_name) Then
                                data_validation.Rows(j)("status") = "Err: minimum total number of image upload is " + limit.ToString + "."
                            End If
                        Next
                    End If
                End If
            Next
        End If

        Return data_validation
    End Function

    Sub delete_images()
        Dim id_design_images As String = ""
        Dim file_name As String = ""

        Try
            id_design_images = GVImageList.GetFocusedRowCellValue("id_design_images").ToString
            file_name = GVImageList.GetFocusedRowCellValue("file_name").ToString
        Catch ex As Exception
        End Try

        If Not file_name = "" Then
            Dim confirm As DialogResult = DevExpress.XtraEditors.XtraMessageBox.Show("Are you sure want to delete this image ?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)

            If confirm = DialogResult.Yes Then
                'delete from server
                Dim sftp As Renci.SshNet.SftpClient = New Renci.SshNet.SftpClient(cloud_host, cloud_username, cloud_password)

                sftp.Connect()

                If sftp.IsConnected Then
                    sftp.DeleteFile(cloud_image_path + "/" + file_name)
                End If

                'delete database
                execute_non_query("DELETE FROM tb_design_images WHERE id_design_images = " + id_design_images, True, "", "", "", "")

                view_images()
            End If
        Else
            stopCustom("No file selected.")
        End If
    End Sub

    Sub print_images()
        print(GCImageList, "Design Images")
    End Sub

    Private Sub SBView_Click(sender As Object, e As EventArgs) Handles SBView.Click
        view_images()
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

    Sub view_season()
        Dim query As String = "
            SELECT a.id_season, b.range, a.season
            FROM tb_season AS a 
            INNER JOIN tb_range b ON a.id_range = b.id_range 
            WHERE b.id_range > 0 AND b.is_md = 1 
            ORDER BY b.range DESC
        "

        viewSearchLookupQuery(SLUESeason, query, "id_season", "season", "id_season")
    End Sub

    Private Sub SLUESeason_EditValueChanged(sender As Object, e As EventArgs) Handles SLUESeason.EditValueChanged
        GCImageList.DataSource = Nothing
    End Sub
End Class