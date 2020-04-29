Imports DevExpress.XtraEditors

Public Class FormKecamatanSingle
    Public id_sub_district As String = "-1"
    Public id_city As String = "-1"
    Private Sub FormKecamatanSingle_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            If id_sub_district <> "-1" Then
                'edit
                Dim query As String = String.Format("SELECT * FROM tb_m_sub_district WHERE id_sub_district = '{0}'", id_sub_district)
                Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")

                Dim sub_district As String = data.Rows(0)("sub_district").ToString

                data.Dispose()

                TECity.Text = sub_district
            End If
        Catch ex As Exception
            XtraMessageBox.Show("Server Disconnected on viewing sub district (kecamatan). Please wait a moment.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub BSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BSave.Click
        Cursor = Cursors.WaitCursor

        Dim query As String
        Dim sub_district As String = TECity.Text

        Try
            If id_sub_district <> "-1" Then
                'update
                If Not formIsValid(EPCity) Then
                    XtraMessageBox.Show("Please check your input.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Else
                    query = String.Format("UPDATE tb_m_sub_district SET sub_district='{0}' WHERE id_sub_district='{1}'", sub_district, id_sub_district)
                    execute_non_query(query, True, "", "", "", "")
                    FormMasterArea.view_kecamatan(id_city)
                    Close()
                End If
            Else
                'insert
                If Not formIsValid(EPCity) Then
                    XtraMessageBox.Show("Please check your input.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Else
                    query = String.Format("INSERT INTO tb_m_sub_district(sub_district,id_city) VALUES('{0}','{1}')", sub_district, id_city)
                    execute_non_query(query, True, "", "", "", "")
                    FormMasterArea.view_kecamatan(id_city)
                    Close()
                End If
            End If
        Catch ex As Exception
            XtraMessageBox.Show("Server Disconnected on saving sub_district. Please wait a moment.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

        Cursor = Cursors.Default
    End Sub

    Private Sub TECity_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TECity.Validating
        EP_TE_cant_blank(EPCity, TECity)
        '
        Dim query_jml As String = String.Format("SELECT COUNT(id_sub_district) FROM tb_m_sub_district WHERE sub_district='{0}' AND id_sub_district!='{1}'", TECity.Text, id_sub_district)
        Dim jml As Integer = execute_query(query_jml, 0, True, "", "", "", "")
        If Not jml < 1 Then
            EP_TE_already_used(EPCity, TECity, "1")
        End If
    End Sub

    Private Sub FormKecamatanSingle_FormClosed(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub
End Class