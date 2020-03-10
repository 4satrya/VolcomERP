Public Class FormSetKurs
    Dim bnew_active As String = "1"
    Dim bedit_active As String = "1"
    Dim bdel_active As String = "1"
    '
    Private Sub FormSetKurs_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub FormSetKurs_Deactivate(sender As Object, e As EventArgs) Handles MyBase.Deactivate
        FormMain.hide_rb()
    End Sub

    Private Sub FormPurcReq_Activated(sender As Object, e As EventArgs) Handles MyBase.Activated
        FormMain.show_rb(Name)
        check_menu()
    End Sub

    Sub check_menu()
        'hide all except new
        bnew_active = "0"
        bedit_active = "0"
        bdel_active = "0"
        checkFormAccess(Name)
        button_main(bnew_active, bedit_active, bdel_active)
    End Sub

    Private Sub FormSetKurs_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        TEKurs.EditValue = 0.00
        'get today kurs
        Dim query As String = "SELECT * FROM tb_kurs_trans WHERE DATE(DATE_ADD(created_date, INTERVAL 6 DAY)) >= DATE(NOW()) ORDER BY id_kurs_trans DESC LIMIT 1"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")

        If data.Rows.Count > 0 Then
            TEKurs.EditValue = data.Rows(0)("kurs_trans")
            TEFixFloating.EditValue = data.Rows(0)("fixed_floating")
        End If

        load_kurs()
    End Sub

    Sub load_kurs()
        Dim query As String = "
            SELECT kt.id_kurs_trans, kt.created_by, kt.created_date, kt.kurs_trans, kt.fixed_floating, (kt.kurs_trans + kt.fixed_floating) AS management_rate, IF(kt.created_by = 0, 'Automatic Get Kurs', emp.employee_name) AS employee_name
            FROM tb_kurs_trans kt 
            LEFT JOIN tb_m_user usr ON usr.id_user = kt.created_by 
            LEFT JOIN tb_m_employee emp ON emp.id_employee = usr.id_employee 
            ORDER BY kt.id_kurs_trans DESC"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCKursTrans.DataSource = data
        GVKursTrans.BestFitColumns()
    End Sub

    Private Sub BGetKurs_Click(sender As Object, e As EventArgs) Handles BGetKurs.Click
        Cursor = Cursors.WaitCursor
        Try
            Net.ServicePointManager.SecurityProtocol = DirectCast(3072, Net.SecurityProtocolType)

            Dim webClient As New Net.WebClient
            Dim result As String = webClient.DownloadString("https://fiskal.kemenkeu.go.id/dw-kurs-db.asp")
            Dim str_kurs_dec As String = Between(result, "Dolar Amerika Serikat (USD)</td><td class='text-right'>", " <img src='data/aimages").Replace(",", "").Replace(" ", "")
            '
            Dim query_sel As String = "SELECT CAST('" & str_kurs_dec & "' AS DECIMAL(13,2)) as kurs"
            Dim data_sel As DataTable = execute_query(query_sel, -1, True, "", "", "", "")
            If data_sel.Rows.Count > 0 Then
                TEKurs.EditValue = data_sel.Rows(0)("kurs")
                'get last fixed floating
                Dim q As String = "SELECT * FROM tb_kurs_trans ORDER BY id_kurs_trans DESC LIMIT 1"
                Dim dt As DataTable = execute_query(q, -1, True, "", "", "", "")
                If dt.Rows.Count > 0 Then
                    TEFixFloating.EditValue = dt.Rows(0)("fixed_floating")
                End If
            Else
                warningCustom("Connection error, please try again later.")
            End If
        Catch ex As Exception
            warningCustom("Connection error, please try again later.")
        End Try
        '
        Cursor = Cursors.Default
    End Sub

    Public Shared Function Between(ByVal src As String, ByVal findfrom As String, ByVal findto As String) As String
        Dim start As Integer = src.IndexOf(findfrom)
        Dim [to] As Integer = src.IndexOf(findto, start + findfrom.Length)
        If start < 0 OrElse [to] < 0 Then Return ""
        Dim s As String = src.Substring(start + findfrom.Length, [to] - start - findfrom.Length)
        Return s
    End Function

    Private Sub BSave_Click(sender As Object, e As EventArgs) Handles BSave.Click
        Cursor = Cursors.WaitCursor
        If TEKurs.EditValue < 0 Then
            warningCustom("Please type kurs correctly")
        Else
            Dim query As String = "INSERT INTO tb_kurs_trans(created_by,created_date,kurs_trans,fixed_floating) VALUES('" & id_user & "',NOW(),'" & decimalSQL(TEKurs.EditValue.ToString) & "','" & decimalSQL(TEFixFloating.EditValue.ToString) & "');
UPDATE tb_opt SET rate_management='" & decimalSQL((TEKurs.EditValue + TEFixFloating.EditValue).ToString) & "'"
            execute_non_query(query, True, "", "", "", "'")
            load_kurs()
        End If
        Cursor = Cursors.Default
    End Sub

    Private Sub RepositoryItemCheckEdit_Click(sender As Object, e As EventArgs) Handles RepositoryItemCheckEdit.Click
        Cursor = Cursors.WaitCursor
        FormDocumentUpload.is_no_delete = "1"
        FormDocumentUpload.id_report = GVKursTrans.GetFocusedRowCellValue("id_kurs_trans").ToString
        FormDocumentUpload.report_mark_type = "239"
        FormDocumentUpload.ShowDialog()
        Cursor = Cursors.Default
    End Sub
End Class