Public Class FormPurcAssetValueAdded
    Public id As String = "-1"
    Public id_parent As String = "-1"
    Public action As String = "-1"
    Public is_view As String = "-1"
    Dim id_report_status As String = "-1"

    Private Sub FormPurcAssetValueAdded_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        viewReportStatus()
        actionLoad()
    End Sub

    Sub viewReportStatus()
        Dim query As String = "SELECT * FROM tb_lookup_report_status a ORDER BY a.id_report_status "
        viewLookupQuery(LEReportStatus, query, 0, "report_status", "id_report_status")
    End Sub

    Sub actionLoad()
        Cursor = Cursors.WaitCursor
        If action = "ins" Then
            Dim a As New ClassPurcAsset()
            Dim query As String = a.queryMain("AND a.id_purc_rec_asset='" + id_parent + "' ", "1", True)
            Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
            TxtNumber.Text = data.Rows(0)("asset_number").ToString
            TxtAssetName.Text = data.Rows(0)("asset_name").ToString
            DECreated.Properties.MinValue = data.Rows(0)("acq_date")
            DECreated.Properties.MaxValue = getTimeDB()
            DECreated.EditValue = getTimeDB()
            TxtValueAdded.EditValue = 0.00
        ElseIf action = "upd" Then
            PanelControlStt.Visible = True
            Dim a As New ClassPurcAsset()
            Dim query As String = a.queryMain("AND a.id_purc_rec_asset='" + id + "' ", "1", True)
            Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
            TxtNumber.Text = data.Rows(0)("asset_number").ToString
            TxtAssetName.Text = data.Rows(0)("asset_name").ToString
            DECreated.EditValue = data.Rows(0)("acq_date")
            TxtValueAdded.EditValue = data.Rows(0)("acq_cost")
            MENote.Text = data.Rows(0)("asset_note").ToString
            id_report_status = data.Rows(0)("id_report_status").ToString
            LEReportStatus.ItemIndex = LEReportStatus.Properties.GetDataSourceRowIndex("id_report_status", data.Rows(0)("id_report_status").ToString)
            allow_status()
        End If
        Cursor = Cursors.Default
    End Sub

    Sub allow_status()
        DECreated.Enabled = False
        TxtValueAdded.Enabled = False
        MENote.Enabled = False
        BtnConfirm.Visible = False
        BtnCancell.Visible = True
        BtnMark.Visible = True

        If id_report_status = "5" Or id_report_status = "6" Then
            BtnCancell.Visible = False
        End If
    End Sub

    Private Sub FormPurcAssetValueAdded_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub TxtNumber_OpenLink(sender As Object, e As DevExpress.XtraEditors.Controls.OpenLinkEventArgs) Handles TxtNumber.OpenLink
        Cursor = Cursors.WaitCursor
        Dim p As New ClassShowPopUp()
        p.id_report = id_parent
        p.report_mark_type = "160"
        p.show()
        Cursor = Cursors.Default
    End Sub

    Private Sub BtnConfirm_Click(sender As Object, e As EventArgs) Handles BtnConfirm.Click
        If TxtValueAdded.EditValue = 0 Then
            warningCustom("Please complete all data. ")
        Else
            Dim confirm As DialogResult = DevExpress.XtraEditors.XtraMessageBox.Show("Are you sure you want to confirm this value-added ?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
            If confirm = Windows.Forms.DialogResult.Yes Then
                Cursor = Cursors.WaitCursor
                Dim acq_cost As String = decimalSQL(TxtValueAdded.EditValue.ToString)
                Dim asset_note As String = addSlashes(MENote.Text)
                Dim acq_date As String = DateTime.Parse(DECreated.EditValue.ToString).ToString("yyyy-MM-dd")

                'query
                Dim query As String = "INSERT INTO tb_purc_rec_asset (`id_parent`, id_purc_rec_det, `id_item`, `id_departement`, `id_acc_fa`, `asset_number`,`asset_name` , `asset_note`, `acq_date`, `acq_cost`, `is_non_depresiasi`,
                `useful_life`, `id_acc_dep`, `id_acc_dep_accum` , `accum_dep`, `is_confirm`, `id_report_status`, is_value_added)
                SELECT a.id_parent, a.id_purc_rec_det, a.id_item, a.id_departement, a.id_acc_fa, a.asset_number, a.asset_name, '" + asset_note + "', '" + acq_date + "', '" + acq_cost + "', a.is_non_depresiasi, 
                (a.useful_life - (PERIOD_DIFF(DATE_FORMAT('" + acq_date + "','%Y%m'),DATE_FORMAT(a.acq_date,'%Y%m')))) AS `useful_life`, 
                a.id_acc_dep, a.id_acc_dep_accum, a.accum_dep, 1, 1, 1
                FROM tb_purc_rec_asset a
                WHERE a.id_purc_rec_asset=" + id_parent + "; SELECT LAST_INSERT_ID(); "
                id = execute_query(query, 0, True, "", "", "", "")
                submit_who_prepared("169", id, id_user)
                FormPurcAssetValueAddedList.viewData()
                FormPurcAssetValueAddedList.GVData.FocusedRowHandle = find_row(FormPurcAssetValueAddedList.GVData, "id_purc_rec_asset", id)
                action = "upd"
                actionLoad()
                Cursor = Cursors.Default
            End If
        End If
    End Sub

    Private Sub BtnCancell_Click(sender As Object, e As EventArgs) Handles BtnCancell.Click
        Dim confirm As DialogResult = DevExpress.XtraEditors.XtraMessageBox.Show("Are you sure you want to cancell this process ?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
        If confirm = Windows.Forms.DialogResult.Yes Then
            Cursor = Cursors.WaitCursor
            Dim query As String = "UPDATE tb_purc_rec_asset SET id_report_status=5 WHERE id_purc_rec_asset='" + id + "'"
            execute_non_query(query, True, "", "", "", "")

            'nonaktif mark
            Dim queryrm = String.Format("UPDATE tb_report_mark SET report_mark_lead_time=NULL,report_mark_start_datetime=NULL WHERE report_mark_type='{0}' AND id_report='{1}' AND id_report_status>'1'", 169, id)
            execute_non_query(queryrm, True, "", "", "", "")

            FormPurcAssetValueAddedList.viewData()
            FormPurcAssetValueAddedList.GVData.FocusedRowHandle = find_row(FormPurcAssetValueAddedList.GVData, "id_purc_rec_asset", id)
            actionLoad()
            Cursor = Cursors.Default
        End If
    End Sub

    Private Sub BtnMark_Click(sender As Object, e As EventArgs) Handles BtnMark.Click
        Cursor = Cursors.WaitCursor
        FormReportMark.report_mark_type = "169"
        FormReportMark.id_report = id
        FormReportMark.is_view = is_view
        FormReportMark.form_origin = Name
        FormReportMark.ShowDialog()
        Cursor = Cursors.Default
    End Sub
End Class