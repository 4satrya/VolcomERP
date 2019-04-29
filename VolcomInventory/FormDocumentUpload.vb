Public Class FormDocumentUpload 
    Public is_view As String = "-1"
    Public id_report As String = "0"
    Public report_mark_type As String = "0"
    '
    Public is_no_delete As String = "-1"
    Public form_orign As String = ""
    '
    Public cond As String = ""

    Dim source_path As String = get_setup_field("upload_dir")
    Public is_only_pdf As Boolean = False

    Sub refresh_load(ByVal rmt As String)
        If rmt = "149" Then
            FormPurcItemDet.load_doc()
        Else
            If form_orign = "FormReportMarkDet" Then
                FormReportMarkDet.load_form()
            End If
            view_file()
        End If
    End Sub

    Private Sub FormDocumentUpload_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If is_view = "1" Then
            PCNav.Visible = False
        End If
        view_file()
        '
        If is_only_pdf = True Then
            BScanAndUpload.Visible = False
        Else
            BScanAndUpload.Visible = True
        End If
    End Sub

    Private Sub BClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BClose.Click
        Close()
    End Sub

    Private Sub Bupload_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Bupload.Click
        FormDocumentUploadDet.is_only_pdf = is_only_pdf
        FormDocumentUploadDet.id_report = id_report
        FormDocumentUploadDet.report_mark_type = report_mark_type
        FormDocumentUploadDet.ShowDialog()
    End Sub

    Sub view_file()
        Dim query As String = "SELECT doc.id_doc,doc.doc_desc,doc.datetime,'yes' as is_download,CONCAT(doc.id_doc,'_" & report_mark_type & "_" & id_report & "',doc.ext) AS filename,emp.employee_name 
                               FROM tb_doc doc
                               LEFT JOIN tb_m_user usr ON usr.id_user=doc.id_user_upload
                               LEFT JOIN tb_m_employee emp ON emp.id_employee=usr.id_employee
                               WHERE report_mark_type='" & report_mark_type & "' AND id_report='" & id_report & "' " + cond
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCFileList.DataSource = data

        If GVFileList.RowCount > 0 Then
            If is_no_delete = "1" Then
                BDelete.Visible = False
            Else
                BDelete.Visible = True
            End If
        Else
            BDelete.Visible = False
        End If
        '
        If report_mark_type = "142" Then
            FormReportMarkCancel.act_load()
        End If
    End Sub

    Private Sub GVFileList_RowClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Grid.RowClickEventArgs) Handles GVFileList.RowClick

    End Sub

    Private Sub RICE_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RICE.Click
        Try
            Dim path As String = Application.StartupPath & "\download\"
            'create directory if not exist
            If Not IO.Directory.Exists(path) Then
                System.IO.Directory.CreateDirectory(path)
            End If
            'download
            My.Computer.Network.DownloadFile(source_path & report_mark_type & "\" & GVFileList.GetFocusedRowCellValue("filename").ToString, path & GVFileList.GetFocusedRowCellValue("doc_desc").ToString & "_" & GVFileList.GetFocusedRowCellValue("filename").ToString, "", "", True, 100, True)
            'open folder
            If IO.File.Exists(path & GVFileList.GetFocusedRowCellValue("doc_desc").ToString & "_" & GVFileList.GetFocusedRowCellValue("filename").ToString) Then
                Dim open_folder As ProcessStartInfo = New ProcessStartInfo()
                open_folder.WindowStyle = ProcessWindowStyle.Maximized
                open_folder.FileName = "explorer.exe"
                open_folder.Arguments = "/select,""" & path & GVFileList.GetFocusedRowCellValue("doc_desc").ToString & "_" & GVFileList.GetFocusedRowCellValue("filename").ToString & """"
                Process.Start(open_folder)
            Else
                stopCustom("No Supporting Document !")
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub RICE_MouseHover(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RICE.MouseHover
        Cursor = Cursors.Hand
    End Sub

    Private Sub RICE_MouseLeave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RICE.MouseLeave
        Cursor = Cursors.Default
    End Sub

    Private Sub GVFileList_CustomColumnDisplayText(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs) Handles GVFileList.CustomColumnDisplayText
        If e.Column.FieldName = "no" Then
            e.DisplayText = (e.ListSourceRowIndex + 1).ToString()
        End If
    End Sub

    Private Sub BDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BDelete.Click
        Cursor = Cursors.WaitCursor
        Dim confirm As DialogResult = DevExpress.XtraEditors.XtraMessageBox.Show("Are you sure want to delete this document?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
        If confirm = Windows.Forms.DialogResult.Yes Then
            Cursor = Cursors.WaitCursor
            Try
                Dim query As String = ""
                query = String.Format("DELETE FROM tb_doc WHERE id_doc = '{0}'", GVFileList.GetFocusedRowCellValue("id_doc"))
                execute_non_query(query, True, "", "", "", "")
                If IO.File.Exists(source_path & report_mark_type & "\" & GVFileList.GetFocusedRowCellValue("filename").ToString) Then
                    IO.File.Delete(source_path & report_mark_type & "\" & GVFileList.GetFocusedRowCellValue("filename").ToString)
                End If
                view_file()
            Catch ex As Exception
                errorConnection()
            End Try
            Cursor = Cursors.Default
        End If
        Cursor = Cursors.Default
    End Sub

    Private Sub FormDocumentUpload_FormClosed(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub BScanAndUpload_Click(sender As Object, e As EventArgs) Handles BScanAndUpload.Click
        FormDocumentScanUpload.id_report = id_report
        FormDocumentScanUpload.report_mark_type = report_mark_type
        FormDocumentScanUpload.ShowDialog()
    End Sub
End Class