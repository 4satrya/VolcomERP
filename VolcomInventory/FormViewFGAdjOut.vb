Public Class FormViewFGAdjOut 
    Public id_adj_out_fg As String
    Public action As String
    Public id_report_status As String
    Public total_amount As Double

    Private Sub FormViewFGAdjOut_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        viewReportStatus()
        viewCurrency()
        actionLoad()
    End Sub

    Sub actionLoad()
        GVDetail.OptionsBehavior.AutoExpandAllGroups = True

        'Fetch from db main
        Dim query As String = "SELECT *, DATE_FORMAT(a.adj_out_fg_date, '%Y-%m-%d') AS adj_out_fg_datex,
        GROUP_CONCAT(DISTINCT comp.comp_number) AS `account`
        FROM tb_adj_out_fg a 
        INNER JOIN tb_adj_out_fg_det ad ON ad.id_adj_out_fg = a.id_adj_out_fg "
        query += "INNER JOIN tb_lookup_currency b ON a.id_currency = b.id_currency "
        query += "INNER JOIN tb_lookup_report_status c ON a.id_report_status = c.id_report_status 
        INNER JOIN tb_m_wh_drawer drw ON drw.id_wh_drawer = ad.id_wh_drawer
        INNER JOIN tb_m_wh_rack rck ON rck.id_wh_rack = drw.id_wh_rack
        INNER JOIN tb_m_wh_locator loc ON loc.id_wh_locator = rck.id_wh_locator
        INNER JOIN tb_m_comp comp ON comp.id_comp = loc.id_comp "
        query += "WHERE a.id_adj_out_fg = '" + id_adj_out_fg + "'
        GROUP BY a.id_adj_out_fg  "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")

        ''tampung ke form
        id_adj_out_fg = data.Rows(0)("id_adj_out_fg").ToString
        TxtAdjNumber.Text = data.Rows(0)("adj_out_fg_number").ToString
        TxtAdjDate.Text = view_date_from(data.Rows(0)("adj_out_fg_datex").ToString, 0)
        MENote.Text = data.Rows(0)("adj_out_fg_note").ToString
        LEReportStatus.ItemIndex = LEReportStatus.Properties.GetDataSourceRowIndex("id_report_status", data.Rows(0)("id_report_status").ToString)
        LECurrency.ItemIndex = LEReportStatus.Properties.GetDataSourceRowIndex("id_currency", data.Rows(0)("id_currency").ToString)
        MEAccount.Text = data.Rows(0)("account").ToString

        'based on sttatus
        id_report_status = data.Rows(0)("id_report_status").ToString
        If check_edit_report_status(id_report_status, "42", id_adj_out_fg) Then
            BMark.Enabled = True
            MENote.Properties.ReadOnly = False
        Else
            BMark.Enabled = True
            MENote.Properties.ReadOnly = True
        End If

        'Fetch db detail
        viewDetailReturn()


        'get Total
        total_amount = Double.Parse(GVDetail.Columns("adj_out_fg_det_amount").SummaryItem.SummaryValue.ToString)
        METotSay.Text = ConvertCurrencyToEnglish(total_amount, LECurrency.EditValue.ToString)
        check_but()
    End Sub

    Sub check_but()
       
    End Sub

    Sub viewReportStatus()
        Dim query As String = "SELECT * FROM tb_lookup_report_status a ORDER BY a.id_report_status "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        viewLookupQuery(LEReportStatus, query, 0, "report_status", "id_report_status")
    End Sub

    Sub viewCurrency()
        Dim id_currency_default As String = execute_query("SELECT id_currency_default FROM tb_opt LIMIT 1", 0, True, "", "", "", "")
        Dim query As String = "SELECT * FROM tb_lookup_currency WHERE id_currency = '" + id_currency_default + "' ORDER BY id_currency ASC"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        viewLookupQuery(LECurrency, query, 0, "currency", "id_currency")
    End Sub

    Private Sub FormViewFGAdjOut_FormClosed(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub


    Sub viewDetailReturn()
        Dim query As String = ""
        query += "CALL view_fg_adj_out_less('" + id_adj_out_fg + "')"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCDetail.DataSource = data
        'GVDetail.Columns("id_product").GroupIndex = 0
    End Sub

    'Row Manipulation
    Sub focusColumnCode()
        GVDetail.FocusedColumn = GVDetail.VisibleColumns(0)
        GVDetail.ShowEditor()
    End Sub
    Sub newRows()
        GVDetail.AddNewRow()
        cantEdit()
    End Sub
    Sub deleteRows()
        GVDetail.DeleteRow(GVDetail.FocusedRowHandle)
        GCDetail.RefreshDataSource()
        GVDetail.RefreshData()
        cantEdit()
    End Sub

    Sub cantEdit()
      
    End Sub

  
    Private Sub GVDetail_FocusedRowChanged(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles GVDetail.FocusedRowChanged
        cantEdit()
    End Sub


    Private Sub GVDetail_CustomColumnDisplayText(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs) Handles GVDetail.CustomColumnDisplayText
        'If e.Column.FieldName = "id_product" Then
        '    Dim rowhandle As Integer = e.RowHandle
        '    If GVDetail.IsGroupRow(rowhandle) Then
        '        rowhandle = GVDetail.GetDataRowHandleByGroupRowHandle(rowhandle)
        '        e.DisplayText = GVDetail.GetRowCellDisplayText(rowhandle, "name")
        '    End If
        'End If
        If e.Column.FieldName = "no" Then
            e.DisplayText = (e.ListSourceRowIndex + 1).ToString()
        End If
    End Sub

    Private Sub BMark_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BMark.Click
        FormReportMark.id_report = id_adj_out_fg
        FormReportMark.report_mark_type = "42"
        FormReportMark.form_origin = Name
        FormReportMark.is_view = "1"
        FormReportMark.ShowDialog()
    End Sub

End Class