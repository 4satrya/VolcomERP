Public Class FormPayoutVerDet
    Public id As String = "-1"
    Dim type_ver As String = "-1"
    Dim rmt As String = "266"
    Dim is_existing_order As String = "-1"

    Private Sub FormPayoutVerDet_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        actionLoad()
    End Sub

    Sub actionLoad()
        Cursor = Cursors.WaitCursor
        'header
        Dim pv As New ClassPayoutVer()
        Dim query As String = pv.queryMain("AND v.id_list_payout_ver='" + id + "'", "1")
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        type_ver = data.Rows(0)("type_ver").ToString
        TxtOrderNumber.Text = data.Rows(0)("order_number").ToString
        TxtCheckoutId.Text = data.Rows(0)("checkout_id").ToString
        TxtNumber.Text = data.Rows(0)("number").ToString
        DECreated.EditValue = data.Rows(0)("created_date")
        TxtCreatedBy.Text = data.Rows(0)("created_by_name").ToString
        is_existing_order = data.Rows(0)("is_existing_order").ToString
        If is_existing_order = "2" Then
            TxtNumber.Properties.ReadOnly = False
            BtnUpdate.Enabled = True
        Else
            TxtNumber.Properties.ReadOnly = True
            BtnUpdate.Enabled = False
        End If

        'detail
        viewDetail()

        'check attachment
        If remindUpload() Then
            warningCustom("Please upload BAP first")
            showAttach()
        End If

        'check
        If Not allowEdit() Then
            TxtNumber.Properties.ReadOnly = True
            BtnUpdate.Enabled = False
            PanelControlNav.Visible = False
        End If
        Cursor = Cursors.Default
    End Sub

    Sub viewDetail()
        Dim qd As String = "SELECT d.id_list_payout_ver_det, d.id_list_payout_ver, d.id_acc, coa.acc_name, coa.acc_description, 
        d.id_dc, dc.dc_code, d.value 
        FROM tb_list_payout_ver_det d
        INNER JOIN tb_a_acc coa ON coa.id_acc = d.id_acc
        INNER JOIN tb_lookup_dc dc ON dc.id_dc = d.id_dc
        WHERE d.id_list_payout_ver=" + id + " 
        ORDER BY d.id_list_payout_ver_det ASC "
        Dim dd As DataTable = execute_query(qd, -1, True, "", "", "", "")
        GCData.DataSource = dd
        GVData.BestFitColumns()
    End Sub

    Function remindUpload() As Boolean
        Dim qdoc As String = "SELECT * FROM tb_doc d WHERE d.report_mark_type=" + rmt + " AND d.id_report=" + id + ""
        Dim ddoc As DataTable = execute_query(qdoc, -1, True, "", "", "", "")
        If ddoc.Rows.Count <= 0 Then
            Return True
        Else
            Return False
        End If
    End Function

    Function allowEdit() As Boolean
        If type_ver = "1" Then
            'payout
            Dim query As String = "SELECT v.* 
            FROM tb_list_payout_ver v 
            LEFT JOIN tb_list_payout_det pd ON pd.id_list_payout_ver = v.id_list_payout_ver
            LEFT JOIN tb_rec_payment bbm ON bbm.id_list_payout_trans = pd.id_list_payout_trans
            WHERE v.id_list_payout_ver=" + id + " AND ISNULL(bbm.id_list_payout_trans) "
            Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
            If data.Rows.Count > 0 Then
                Return True
            Else
                Return False
            End If
        Else
            'va
            Dim query As String = "SELECT v.* 
            FROM tb_list_payout_ver v 
            LEFT JOIN tb_virtual_acc_trans_inv pd ON pd.id_list_payout_ver = v.id_list_payout_ver
            LEFT JOIN tb_rec_payment bbm ON bbm.id_virtual_acc_trans = pd.id_virtual_acc_trans
            WHERE v.id_list_payout_ver=" + id + " AND ISNULL(bbm.id_list_payout_trans) "
            Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
            If data.Rows.Count > 0 Then
                Return True
            Else
                Return False
            End If
        End If
    End Function

    Private Sub FormPayoutVerDet_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Sub BtnClose_Click(sender As Object, e As EventArgs) Handles BtnClose.Click
        Close()
    End Sub

    Private Sub BtnAttachment_Click(sender As Object, e As EventArgs) Handles BtnAttachment.Click
        showAttach()
    End Sub

    Sub showAttach()
        Cursor = Cursors.WaitCursor
        FormDocumentUpload.id_report = id
        If Not allowEdit() Then
            FormDocumentUpload.is_view = "1"
        End If
        FormDocumentUpload.report_mark_type = rmt
        FormDocumentUpload.ShowDialog()
        Cursor = Cursors.Default
    End Sub

    Private Sub BtnAdd_Click(sender As Object, e As EventArgs) Handles BtnAdd.Click
        If remindUpload() Then
            warningCustom("Please upload BAP first")
            showAttach()
        Else
            'add
            Cursor = Cursors.WaitCursor
            actionLoad()
            If TxtNumber.Text = "0" Or TxtNumber.Text = "" Then
                stopCustom("Please input order number")
            Else
                FormPayoutVerAdd.ShowDialog()
            End If
            Cursor = Cursors.Default
        End If
    End Sub

    Private Sub BtnDelete_Click(sender As Object, e As EventArgs) Handles BtnDelete.Click
        If GVData.RowCount > 0 And GVData.FocusedRowHandle >= 0 Then
            Dim confirm As DialogResult = DevExpress.XtraEditors.XtraMessageBox.Show("Are you sure you want delete this data?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
            If confirm = Windows.Forms.DialogResult.Yes Then
                Dim query As String = "DELETE FROM tb_list_payout_ver_det where id_list_payout_ver_det='" + GVData.GetFocusedRowCellValue("id_list_payout_ver_det").ToString + "'"
                execute_non_query(query, True, "", "", "", "")
                viewDetail()
            End If
        End If
    End Sub

    Private Sub BtnUpdate_Click(sender As Object, e As EventArgs) Handles BtnUpdate.Click
        Cursor = Cursors.WaitCursor
        Dim query As String = "UPDATE tb_list_payout_ver v SET order_number='" + addSlashes(TxtOrderNumber.Text) + "' WHERE id_list_payout_ver='" + id + "' "
        execute_non_query(query, True, "", "", "", "")
        Cursor = Cursors.Default
    End Sub
End Class