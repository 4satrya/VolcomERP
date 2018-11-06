﻿Public Class FormMasterCompanyLegal
    Public id_comp As String = "-1"

    Public file_address As String = ""
    Public file_name As String = ""
    Public file_ext As String = ""

    Private Sub BCancel_Click(sender As Object, e As EventArgs) Handles BCancel.Click
        Close()
    End Sub

    Private Sub FormMasterCompanyLegal_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub FormMasterCompanyLegal_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        load_comp()
    End Sub

    Sub load_comp()
        Dim query As String = "SELECT comp_number,comp_name FROM tb_m_comp WHERE id_comp='" & id_comp & "'"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        If data.Rows.Count > 0 Then
            TECompNumber.Text = data.Rows(0)("comp_number").ToString
            TECompName.Text = data.Rows(0)("comp_name").ToString
        End If
    End Sub

    Private Sub BSave_Click(sender As Object, e As EventArgs) Handles BSave.Click
        If BUploadFile.Text = "" Then
            warningCustom("Please upload supporting document first")
        ElseIf TENumber.Text = "" Then
            warningCustom("Please input document number first")
        Else
            Dim date_until As String = ""
            If DEUntil.Text = "" Then
                date_until = "NULL"
            Else
                date_until = "'" & Date.Parse(DEUntil.EditValue.ToString).ToString("yyyy-MM-dd") & "'"
            End If
            '
            Dim query As String = ""
            query = "UPDATE tb_m_comp_legal SET is_default='2' WHERE id_legal_type='" & LELegalType.EditValue.ToString & "' AND id_comp='" & id_comp & "'"
            execute_non_query(query, True, "", "", "", "")
            '
            query = "INSERT INTO tb_m_comp_legal(`id_comp`,`id_legal_type`,`number`,`active_until`,`upload_datetime`,`upload_by`,`is_default`)
VALUES('" & id_comp & "','" & LELegalType.EditValue.ToString & "','" & addSlashes(TENumber.Text) & "'," & date_until & ",NOW(),'" & id_user & "','1');SELECT LAST_INSERT_ID() "
            Dim last_id As String = execute_query(query, 0, True, "", "", "", "")
            'upload
            Dim credential As Net.NetworkCredential = New Net.NetworkCredential("catur", "password", "domain")
            Dim directory_upload As String = ""
            Dim path As String = directory_upload & "\"
            If Not IO.Directory.Exists(path) Then
                System.IO.Directory.CreateDirectory(path)
            End If
            My.Computer.Network.UploadFile(file_address, path & last_id & "__" & file_ext, "", "", True, 100, True)
        End If
    End Sub

    Private Sub BUploadFile_ButtonClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraEditors.Controls.ButtonPressedEventArgs) Handles BUploadFile.ButtonClick
        Dim fd As OpenFileDialog = New OpenFileDialog()

        fd.Title = "Upload file"
        fd.InitialDirectory = "C:\"
        fd.Filter = "Pdf Files|*.pdf"

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

    Private Sub BSetNullDateUntil_Click(sender As Object, e As EventArgs) Handles BSetNullDateUntil.Click
        DEUntil.Text = ""
    End Sub
End Class