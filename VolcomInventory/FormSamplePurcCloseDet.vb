Public Class FormSamplePurcCloseDet
    Public id_close As String = "-1"
    Public is_view As String = "-1"

    Private Sub FormSamplePurcCloseDet_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        load_form()
    End Sub

    Sub load_form()
        DEDateCreated.EditValue = Now
        TENumber.Text = "[auto generate]"
        TECreatedBy.Text = "[auto generate]"
        '
        If Not id_close = "-1" Then
            'edit
            Dim query As String = "SELECT pc.`date_created`,pc.`note`,pc.`number`,pc.`id_report_status`,emp.`employee_name` FROM tb_sample_purc_close pc
INNER JOIN tb_m_user usr ON usr.`id_user`=pc.`created_by`
INNER JOIN tb_m_employee emp ON emp.`id_employee`=usr.`id_employee`
WHERE pc.`id_sample_purc_close`='" & id_close & "'"
            Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
            If data.Rows.Count > 0 Then
                TENumber.Text = data.Rows(0)("number").ToString
                DEDateCreated.EditValue = data.Rows(0)("date_created")
                TECreatedBy.Text = data.Rows(0)("employee_name")
            End If
            BtnPrint.Visible = True
            BMark.Visible = True
            BtnSave.Visible = False
            PCAddDelete.Visible = False
        Else
            BtnPrint.Visible = False
            BMark.Visible = False
            BtnSave.Visible = True
            PCAddDelete.Visible = True
        End If
        '
        load_det()
        '
        If is_view = "1" Then
            BtnPrint.Visible = False
        End If
    End Sub

    Sub load_det()
        Dim query As String = "SELECT spcd.*,sp.sample_purc_number,ms.`sample_name`,ms.`sample_us_code`,clr.code_detail_name as color,0.00 AS sub_total FROM `tb_sample_purc_close_det` spcd
INNER JOIN tb_sample_purc_det spd ON spd.`id_sample_purc_det`=spcd.`id_sample_purc_close_det`
INNER JOIN tb_sample_purc sp ON sp.`id_sample_purc`=spd.`id_sample_purc`
INNER JOIN tb_m_sample_price prc ON prc.`id_sample_price`=spd.`id_sample_price`
INNER JOIN tb_m_sample ms ON ms.`id_sample`=prc.id_sample
LEFT JOIN 
(
SELECT sc.`id_sample`,cd.`code_detail_name` FROM tb_m_sample_code sc
INNER JOIN tb_m_code_detail cd ON cd.`id_code_detail`=sc.`id_code_detail`
INNER JOIN tb_m_code c ON c.`id_code`=cd.`id_code` AND c.`id_code`='14'
) clr ON clr.id_sample=ms.`id_sample`
LEFT JOIN 
(
SELECT sc.`id_sample`,cd.`code_detail_name` FROM tb_m_sample_code sc
INNER JOIN tb_m_code_detail cd ON cd.`id_code_detail`=sc.`id_code_detail`
INNER JOIN tb_m_code c ON c.`id_code`=cd.`id_code` AND c.`id_code`='16'
) division ON division.id_sample=ms.`id_sample`
WHERE spcd.id_sample_purc_close='" & id_close & "'"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCAfter.DataSource = data
        GVAfter.BestFitColumns()
    End Sub

    Private Sub BDel_Click(sender As Object, e As EventArgs) Handles BDel.Click
        If GVAfter.RowCount > 0 And GVAfter.FocusedRowHandle >= 0 Then
            Dim confirm As DialogResult = DevExpress.XtraEditors.XtraMessageBox.Show("Are you sure want to delete this item?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
            If confirm = Windows.Forms.DialogResult.Yes Then
                Cursor = Cursors.WaitCursor
                GVAfter.DeleteRow(GVAfter.FocusedRowHandle)
                GCAfter.RefreshDataSource()
                GVAfter.RefreshData()
                calculate()
                Cursor = Cursors.Default
            End If
        End If
    End Sub

    Sub calculate()
        Dim gross_total As Double = 0.00
        Try
            gross_total = Double.Parse(GVAfter.Columns("sub_total").SummaryItem.SummaryValue.ToString)
        Catch ex As Exception
        End Try

        TEGrossTot.EditValue = gross_total
    End Sub

    Private Sub BAdd_Click(sender As Object, e As EventArgs) Handles BAdd.Click
        FormSamplePurcCloseList.ShowDialog()
    End Sub

    Private Sub BtnCancel_Click(sender As Object, e As EventArgs) Handles BtnCancel.Click
        Close()
    End Sub

    Private Sub FormSamplePurcCloseDet_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub BtnSave_Click(sender As Object, e As EventArgs) Handles BtnSave.Click
        If id_close = "-1" Then
            'new
            'header
            Dim query As String = "INSERT INTO tb_sample_purc_close(`date_created`,`created_by`,`note`,`id_report_status`) VALUES(NOW(),'" & id_user & "','" & addSlashes(MENote.Text) & "','1'); SELECT LAST_INSERT_ID(); "
            id_close = execute_query(query, 0, True, "", "", "", "")
            'detail
            query = "INSERT INTO `tb_sample_purc_close_det`(id_sample_purc_close,id_sample_purc_det,`value`,`qty`,com_value,`note`) VALUES"
            For i = 0 To GVAfter.RowCount - 1
                If Not i = 0 Then
                    query += ","
                End If
                query += "('" & id_close & "','" & GVAfter.GetRowCellValue(i, "id_sample_purc_det").ToString & "','" & decimalSQL(GVAfter.GetRowCellValue(i, "value").ToString) & "','" & decimalSQL(GVAfter.GetRowCellValue(i, "qty").ToString) & "','" & decimalSQL(GVAfter.GetRowCellValue(i, "com_value").ToString) & "','')"
            Next
            execute_non_query(query, True, "", "", "", "")

            query = "CALL gen_number('" & id_close & "','185')"
            execute_non_query(query, True, "", "", "", "")

            submit_who_prepared("185", id_close, id_user)

            infoCustom("Closing Sample Purchase submitted.")

            load_form()
        End If
    End Sub

    Private Sub BMark_Click(sender As Object, e As EventArgs) Handles BMark.Click
        FormReportMark.id_report = id_close
        FormReportMark.report_mark_type = "185"
        If is_view = "1" Then
            FormReportMark.is_view = "1"
        End If
        FormReportMark.form_origin = Name
        FormReportMark.ShowDialog()
    End Sub
End Class