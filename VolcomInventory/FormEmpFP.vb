Public Class FormEmpFP
    Private Sub FormEmpFP_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        viewFP()
    End Sub

    Sub viewFP()
        Dim query As String = "SELECT id_fingerprint,name,sn,ip,port,is_register, IF(is_register='1','Yes','No') AS `register` FROM tb_m_fingerprint"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCFP.DataSource = data
    End Sub

    Private Sub FormEmpFP_Activated(sender As Object, e As EventArgs) Handles MyBase.Activated
        FormMain.show_rb(Name)
        checkFormAccess(Name)
    End Sub

    Private Sub FormEmpFP_Deactivate(sender As Object, e As EventArgs) Handles MyBase.Deactivate
        FormMain.hide_rb()
    End Sub

    Private Sub FormEmpFP_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub


    Private Sub BAccept_Click(sender As Object, e As EventArgs) Handles BAccept.Click
        Dim confirm As DialogResult = DevExpress.XtraEditors.XtraMessageBox.Show("Are you sure want to sync all machine?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
        If confirm = Windows.Forms.DialogResult.Yes Then
            Dim fp As New ClassFingerPrint()
            fp.sync_all()
        End If
    End Sub

    Private Sub ToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem1.Click
        Dim confirm As DialogResult = DevExpress.XtraEditors.XtraMessageBox.Show("Are you sure want to set as register machine?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
        If confirm = Windows.Forms.DialogResult.Yes Then
            Dim query_upd As String = "UPDATE tb_m_fingerprint SET is_register='2'"
            execute_non_query(query_upd, True, "", "", "", "")
            Dim query As String = "UPDATE tb_m_fingerprint SET is_register='1' WHERE id_fingerprint='" + GVFP.GetFocusedRowCellValue("id_fingerprint").ToString + "' "
            execute_non_query(query, True, "", "", "", "")
            viewFP()
        End If
    End Sub

    Private Sub DownloadTemplateToolStripMenuItem_Click_1(sender As Object, e As EventArgs) Handles DownloadTemplateToolStripMenuItem.Click
        SplashScreenManager1.ShowWaitForm()
        Try
            FormEmpFPFinger.ip = GVFP.GetFocusedRowCellValue("ip").ToString
            FormEmpFPFinger.port = GVFP.GetFocusedRowCellValue("port").ToString
            FormEmpFPFinger.ShowDialog()
        Catch ex As Exception
            errorProcess()
        End Try
        SplashScreenManager1.CloseWaitForm()
    End Sub

    Private Sub ShowFingerTemplateToolStripMenuItem_Click_1(sender As Object, e As EventArgs) Handles ShowFingerTemplateToolStripMenuItem.Click
        Cursor = Cursors.WaitCursor
        Try
            FormEmpFPFaceNew.ip = GVFP.GetFocusedRowCellValue("ip").ToString
            FormEmpFPFaceNew.port = GVFP.GetFocusedRowCellValue("port").ToString
            FormEmpFPFaceNew.ShowDialog()
        Catch ex As Exception
            errorProcess()
        End Try
        Cursor = Cursors.Default
    End Sub

    Private Sub DownloadFingerTemplateToolStripMenuItem_Click_1(sender As Object, e As EventArgs) Handles DownloadFingerTemplateToolStripMenuItem.Click
        Dim confirm As DialogResult = DevExpress.XtraEditors.XtraMessageBox.Show("Are you sure want to download finger template to database?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
        If confirm = Windows.Forms.DialogResult.Yes Then
            SplashScreenManager1.ShowWaitForm()
            Dim fp As New ClassFingerPrint()
            fp.ip = GVFP.GetFocusedRowCellValue("ip").ToString
            fp.port = GVFP.GetFocusedRowCellValue("port").ToString
            fp.download_fp_tmp()
            infoCustom("Process completed")
            SplashScreenManager1.CloseWaitForm()
        End If
    End Sub

    Private Sub DownloadFaceTemplateToolStripMenuItem_Click_1(sender As Object, e As EventArgs) Handles DownloadFaceTemplateToolStripMenuItem.Click
        Dim confirm As DialogResult = DevExpress.XtraEditors.XtraMessageBox.Show("Are you sure want to download face template to database?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
        If confirm = Windows.Forms.DialogResult.Yes Then
            SplashScreenManager1.ShowWaitForm()
            Dim fp As New ClassFingerPrint()
            fp.ip = GVFP.GetFocusedRowCellValue("ip").ToString
            fp.port = GVFP.GetFocusedRowCellValue("port").ToString
            fp.download_face_tmp()
            infoCustom("Process completed")
            SplashScreenManager1.CloseWaitForm()
        End If
    End Sub

    Private Sub UploadFingerTemplateToolStripMenuItem_Click_1(sender As Object, e As EventArgs) Handles UploadFingerTemplateToolStripMenuItem.Click
        Dim confirm As DialogResult = DevExpress.XtraEditors.XtraMessageBox.Show("Are you sure want to upload finger template from database?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
        If confirm = Windows.Forms.DialogResult.Yes Then
            SplashScreenManager1.ShowWaitForm()
            Dim fp As New ClassFingerPrint()
            fp.ip = GVFP.GetFocusedRowCellValue("ip").ToString
            fp.port = GVFP.GetFocusedRowCellValue("port").ToString
            fp.upload_fp_temp_single("")
            infoCustom("Process completed")
            SplashScreenManager1.CloseWaitForm()
        End If
    End Sub

    Private Sub UploadFaceTemplateToolStripMenuItem_Click_1(sender As Object, e As EventArgs) Handles UploadFaceTemplateToolStripMenuItem.Click
        Dim confirm As DialogResult = DevExpress.XtraEditors.XtraMessageBox.Show("Are you sure want to upload face template from database?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
        If confirm = Windows.Forms.DialogResult.Yes Then
            SplashScreenManager1.ShowWaitForm()
            Dim fp As New ClassFingerPrint()
            fp.ip = GVFP.GetFocusedRowCellValue("ip").ToString
            fp.port = GVFP.GetFocusedRowCellValue("port").ToString
            fp.upload_face_temp_single("")
            infoCustom("Process completed")
            SplashScreenManager1.CloseWaitForm()
        End If
    End Sub

    Private Sub TestConnectionToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles TestConnectionToolStripMenuItem.Click
        Cursor = Cursors.WaitCursor
        Dim fp As New ClassFingerPrint()
        fp.ip = GVFP.GetFocusedRowCellValue("ip").ToString
        fp.port = GVFP.GetFocusedRowCellValue("port").ToString
        fp.connect()
        Dim conn As Boolean = fp.bIsConnected
        If conn Then
            infoCustom("Connection success")
        End If
        fp.disconnect()
        Cursor = Cursors.Default
    End Sub

    Private Sub RestartToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RestartToolStripMenuItem.Click
        Dim confirm As DialogResult = DevExpress.XtraEditors.XtraMessageBox.Show("Are you sure want to restart this device?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
        If confirm = Windows.Forms.DialogResult.Yes Then
            Cursor = Cursors.WaitCursor
            Dim fp As New ClassFingerPrint()
            fp.ip = GVFP.GetFocusedRowCellValue("ip").ToString
            fp.port = GVFP.GetFocusedRowCellValue("port").ToString
            fp.restart_fp()
            Cursor = Cursors.Default
        End If
    End Sub

    Private Sub TurnOffToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles TurnOffToolStripMenuItem.Click
        Dim confirm As DialogResult = DevExpress.XtraEditors.XtraMessageBox.Show("Are you sure want to turn off this device?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
        If confirm = Windows.Forms.DialogResult.Yes Then
            Cursor = Cursors.WaitCursor
            Dim fp As New ClassFingerPrint()
            fp.ip = GVFP.GetFocusedRowCellValue("ip").ToString
            fp.port = GVFP.GetFocusedRowCellValue("port").ToString
            fp.power_off()
            Cursor = Cursors.Default
        End If
    End Sub

    Private Sub UploadFingerFacespesifikToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles UploadFingerFacespesifikToolStripMenuItem.Click
        FormEmpFPSingle.ShowDialog()
    End Sub
End Class