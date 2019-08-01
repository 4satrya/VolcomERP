Public Class FormSampleDevelopmentDet
    Public file_address As String = ""
    Public file_name As String = ""
    Public file_ext As String = ""

    Public id_design As String = "-1"

    Public directory_upload As String = get_setup_field("upload_dir")
    Dim report_mark_type As String = "205"

    Private Sub FormSampleDevelopmentDet_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        DEStart.EditValue = Now
        DEEnd.EditValue = Now
        DEDev.EditValue = Now
        '
        view_dev()
        view_progress()
    End Sub

    Sub view_dev()
        Dim query As String = "SELECT `id_sample_dev_stage`,sample_dev_stage FROM `tb_lookup_sample_dev_stage` WHERE is_active='1'"
        viewSearchLookupQuery(SLEStatus, query, "id_sample_dev_stage", "sample_dev_stage", "id_sample_dev_stage")
    End Sub

    Sub view_progress()
        Dim query As String = "SELECT `id_sample_dev_progress`,`sample_dev_progress` FROM `tb_lookup_sample_dev_progress` WHERE is_active='1'"
        viewSearchLookupQuery(SLEProgress, query, "id_sample_dev_progress", "sample_dev_progress", "id_sample_dev_progress")
    End Sub

    Private Sub FormSampleDevelopmentDet_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub BUploadFile_ButtonClick(sender As Object, e As DevExpress.XtraEditors.Controls.ButtonPressedEventArgs) Handles BUploadFile.ButtonClick
        Dim fd As OpenFileDialog = New OpenFileDialog()

        fd.Title = "Upload file"
        fd.InitialDirectory = "C:\"

        fd.Filter = "All files (*.*)|*.*|All files (*.*)|*.*"

        fd.FilterIndex = 2
        fd.RestoreDirectory = True

        If fd.ShowDialog() = DialogResult.OK Then
            file_name = System.IO.Path.GetFileNameWithoutExtension(fd.SafeFileName)
            file_address = fd.FileName
            file_ext = System.IO.Path.GetExtension(fd.SafeFileName)
        End If

        BUploadFile.Text = file_address
    End Sub

    Private Sub BSave_Click(sender As Object, e As EventArgs) Handles BSave.Click
        If MENote.Text = "" Then
            stopCustom("Please fill the note")
        Else
            'check first if sample dev step already exceed current step
            Dim q_check As String = ""


            Dim is_attachment As String = "2"
            Dim id As String = "-1"
            '
            If Not file_address = "" Then
                is_attachment = "1"
            End If
            '
            Dim query As String = "INSERT INTO tb_sample_dev(id_design,id_sample_dev_stage,date_created,user_created,date_dev_stage,is_attachment,id_sample_dev_progress,note)
VALUES('" & id_design & "','" & SLEStatus.EditValue.ToString & "',NOW(),'" & id_user & "','" & Date.Parse(DEDev.EditValue.ToString).ToString("yyyy-MM-dd H:mm:ss") & "','" & is_attachment & "','" & SLEProgress.EditValue.ToString & "','" & addSlashes(MENote.Text) & "'); SELECT LAST_INSERT_ID(); "
            id = execute_query(query, 0, True, "", "", "", "")
            '
            If Not file_address = "" Then
                'upload attachment
                Try
                    'save db
                    query = "INSERT INTO tb_doc(doc_desc,report_mark_type,id_report,datetime,ext,id_user_upload) VALUES('" & addSlashes(file_name) & "','" & report_mark_type & "','" & id & "',NOW(),'" & file_ext & "','" & id_user & "');SELECT LAST_INSERT_ID() "
                    Dim last_id As String = execute_query(query, 0, True, "", "", "", "")
                    'upload
                    Dim path As String = directory_upload & "205" & "\"
                    If Not IO.Directory.Exists(path) Then
                        System.IO.Directory.CreateDirectory(path)
                    End If
                    My.Computer.Network.UploadFile(file_address, path & last_id & "_" & report_mark_type & "_" & id & file_ext, "", "", True, 100, True)
                    '
                Catch ex As Exception
                    stopCustom(ex.ToString)
                End Try
            End If
            infoCustom("Development sample record success")
            reset()
            show_all()
        End If
    End Sub

    Sub reset()
        DEStart.EditValue = Now
        DEEnd.EditValue = Now
        DEDev.EditValue = Now
        '
        view_dev()
        view_progress()
        '
        MENote.Text = ""
        BUploadFile.Text = ""
        file_name = ""
        file_address = ""
        file_ext = ""
    End Sub

    Private Sub BShowTimeline_Click(sender As Object, e As EventArgs) Handles BShowTimeline.Click
        showtimeline()
    End Sub

    Private Sub BShowAll_Click(sender As Object, e As EventArgs) Handles BShowAll.Click
        show_all()
    End Sub

    Sub showtimeline()
        Dim query As String = "SELECT id_sample_dev,date_dev_stage,emp.`employee_name`,sdp.`sample_dev_progress`,sds.`sample_dev_stage`,sd.`note`,IF(sd.is_attachment='1','yes','no') AS is_attachment
FROM tb_sample_Dev sd
INNER JOIN tb_m_user usr ON usr.`id_user`=sd.`user_created`
INNER JOIN tb_m_employee emp ON emp.`id_employee`=usr.`id_employee`
INNER JOIN `tb_lookup_sample_dev_progress` sdp ON sdp.`id_sample_dev_progress`=sd.`id_sample_dev_progress`
INNER JOIN `tb_lookup_sample_dev_stage` sds ON sds.`id_sample_dev_stage`=sd.`id_sample_dev_stage`
WHERE sd.id_design='" & id_design & "' AND DATE(sd.date_dev_stage)>='" & Date.Parse(DEStart.EditValue.ToString).ToString("yyyy-MM-dd") & "' AND DATE(sd.date_dev_stage)<='" & Date.Parse(DEEnd.EditValue.ToString).ToString("yyyy-MM-dd") & "'"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCList.DataSource = data
    End Sub

    Sub show_all()
        Dim query As String = "SELECT id_sample_dev,date_dev_stage,emp.`employee_name`,sdp.`sample_dev_progress`,sds.`sample_dev_stage`,sd.`note`,IF(sd.is_attachment='1','yes','no') AS is_attachment
FROM tb_sample_Dev sd
INNER JOIN tb_m_user usr ON usr.`id_user`=sd.`user_created`
INNER JOIN tb_m_employee emp ON emp.`id_employee`=usr.`id_employee`
INNER JOIN `tb_lookup_sample_dev_progress` sdp ON sdp.`id_sample_dev_progress`=sd.`id_sample_dev_progress`
INNER JOIN `tb_lookup_sample_dev_stage` sds ON sds.`id_sample_dev_stage`=sd.`id_sample_dev_stage`
WHERE sd.id_design='" & id_design & "'"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCList.DataSource = data
    End Sub

    Private Sub RICEAttachment_Click(sender As Object, e As EventArgs) Handles RICEAttachment.Click
        If GVList.RowCount > 0 Then
            MsgBox(GVList.GetFocusedRowCellValue("is_attachment").ToString)
            If GVList.GetFocusedRowCellValue("is_attachment").ToString = "yes" Then
                'download
                Dim source_path As String = get_setup_field("upload_dir")
                Dim id_report As String = GVList.GetFocusedRowCellValue("id_sample_dev").ToString
                Dim query As String = "SELECT doc.id_doc,doc.doc_desc,doc.datetime,'yes' as is_download,CONCAT(doc.id_doc,'_" & report_mark_type & "_" & id_report & "',doc.ext) AS filename,emp.employee_name 
                               FROM tb_doc doc
                               LEFT JOIN tb_m_user usr ON usr.id_user=doc.id_user_upload
                               LEFT JOIN tb_m_employee emp ON emp.id_employee=usr.id_employee
                               WHERE report_mark_type='" & report_mark_type & "' AND id_report='" & id_report & "' "
                Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
                '
                If data.Rows.Count > 0 Then
                    Try
                        Dim path As String = Application.StartupPath & "\download\"
                        'create directory if not exist
                        If Not IO.Directory.Exists(path) Then
                            System.IO.Directory.CreateDirectory(path)
                        End If
                        'download
                        My.Computer.Network.DownloadFile(source_path & report_mark_type & "\" & data.Rows(0)("filename").ToString, path & data.Rows(0)("doc_desc").ToString & "_" & data.Rows(0)("filename").ToString, "", "", True, 100, True)
                        'open folder
                        If IO.File.Exists(path & data.Rows(0)("doc_desc").ToString & "_" & data.Rows(0)("filename").ToString) Then
                            Dim open_folder As ProcessStartInfo = New ProcessStartInfo()
                            open_folder.WindowStyle = ProcessWindowStyle.Maximized
                            open_folder.FileName = "explorer.exe"
                            open_folder.Arguments = "/select,""" & path & data.Rows(0)("doc_desc").ToString & "_" & data.Rows(0)("filename").ToString & """"
                            Process.Start(open_folder)
                        Else
                            stopCustom("No Supporting Document !")
                        End If
                    Catch ex As Exception
                    End Try
                Else
                    warningCustom("File not found.")
                End If
            End If
        End If
    End Sub
End Class