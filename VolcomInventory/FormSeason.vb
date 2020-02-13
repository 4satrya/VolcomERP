Public Class FormSeason
    Public id_season As String
    Public season As String
    Public range_season As String
    Public delivery_title As String
    Dim id_range As String
    Dim bnew_active11 As String = "1"
    Dim bedit_active11 As String = "1"
    Dim bdel_active11 As String = "1"
    Dim bnew_active12 As String = "1"
    Dim bedit_active12 As String = "1"
    Dim bdel_active12 As String = "1"
    Dim bnew_active13 As String = "1"
    Dim bedit_active13 As String = "1"
    Dim bdel_active13 As String = "1"
    Dim bnew_active21 As String = "1"
    Dim bedit_active21 As String = "1"
    Dim bdel_active21 As String = "1"
    Public quick_edit As String = "-1"
    Public is_md As String = "1"
    Public id_pop_up As String = "-1"

    Public from_menu As String = ""

    'load
    Private Sub FormSeason_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        viewRange()
        viewSeasonOrign()

        'Form Single
        If quick_edit <> "-1" Then
            PanelControlRange.Visible = True
            PanelControlSeason.Visible = True
            PanelControlDel.Visible = True
            PanelControlOrigin.Visible = True
        End If

        'form is_md
        If is_md <> "1" Then
            XTPOriginSeason.PageVisible = False
        End If

        If id_pop_up = "1" Then
            XTPSeasonTrans.PageVisible = True
            XTPOriginSeason.PageVisible = False
        ElseIf id_pop_up = "2" Then
            XTPSeasonTrans.PageVisible = False
            XTPOriginSeason.PageVisible = True
        End If

    End Sub
    'View Range
    Sub viewRange()
        Dim query As String = ""
        query += "SELECT rg.id_range, ss.id_season, rg.range, rg.description_range, ss.season, ss.season_printed_name FROM tb_range rg "
        query += "INNER JOIN tb_season ss On rg.id_range = ss.id_range "
        If is_md <> "1" Then
            query += "WHERE rg.is_md !='1' AND rg.id_departement = '" + id_departement_user + "' "
        Else
            query += "WHERE rg.is_md='1' "
        End If
        query += "ORDER BY rg.id_range DESC "
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCRange.DataSource = data
        If data.Rows.Count = 0 Then
            XTPSeason.PageEnabled = False
            bnew_active11 = "1"
            bedit_active11 = "0"
            bdel_active11 = "0"
        Else
            getSeasonInformation()
            viewDelivery(id_season)
            XTPSeason.PageEnabled = True
            bnew_active11 = "1"
            bedit_active11 = "1"
            bdel_active11 = "1"
        End If
        checkFormAccess(Name)
        button_main(bnew_active11, bedit_active11, bdel_active11)
    End Sub
    'View Season
    Sub viewSeason()
        LabelRangeContent.Text = GVRange.GetFocusedRowCellDisplayText("range").ToString
        id_range = GVRange.GetFocusedRowCellDisplayText("id_range").ToString
        Dim query As String = "Select * FROM tb_season WHERE id_range = '" + id_range + "' ORDER BY date_season_start ASC"
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCSeason.DataSource = data
        If data.Rows.Count = 0 Then
            XTPDelivery.PageEnabled = False
            bnew_active12 = "1"
            bedit_active12 = "0"
            bdel_active12 = "0"
        Else
            getSeasonInformation()
            viewDelivery(id_season)
            XTPDelivery.PageEnabled = True
            bnew_active12 = "1"
            bedit_active12 = "1"
            bdel_active12 = "1"
        End If
        checkFormAccess(Name)
        If XTCSeason.SelectedTabPageIndex = 1 Then
            button_main(bnew_active12, bedit_active12, bdel_active12)
        End If
    End Sub
    'View Delivery
    Sub viewDelivery(ByVal id_season)
        Dim query As String = String.Format("SELECT  * FROM tb_season_delivery a WHERE a.id_season='{0}' ORDER BY id_delivery ASC", id_season)
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCDelivery.DataSource = data
        LabelDeliveryContent.Text = season
        delivery_title = LabelDeliveryTitle.Text + " " + LabelDeliveryContent.Text
        If data.Rows.Count = 0 Then
            bnew_active13 = "1"
            bedit_active13 = "0"
            bdel_active13 = "0"
        Else
            bnew_active13 = "1"
            bedit_active13 = "1"
            bdel_active13 = "1"
        End If
        checkFormAccess(Name)
        If XTCSeason.SelectedTabPageIndex = 2 Then
            button_main(bnew_active13, bedit_active13, bdel_active13)
        End If
    End Sub
    'View Season orign
    Sub viewSeasonOrign()
        Dim query As String = String.Format("SELECT * FROM tb_season_orign a INNER JOIN tb_m_country b ON a.id_country = b.id_country ORDER BY a.season_orign_year ASC")
        Dim data As DataTable = execute_query(query, -1, True, "", "", "", "")
        GCOrignSeason.DataSource = data
        If data.Rows.Count = 0 Then
            bnew_active21 = "1"
            bedit_active21 = "0"
            bdel_active21 = "0"
        Else
            bnew_active21 = "1"
            bedit_active21 = "1"
            bdel_active21 = "1"
        End If
        checkFormAccess(Name)
        button_main(bnew_active21, bedit_active21, bdel_active21)
    End Sub
    'Season Information
    Sub getSeasonInformation()
        id_season = GVRange.GetFocusedRowCellDisplayText("id_season").ToString
        season = GVRange.GetFocusedRowCellDisplayText("season").ToString
        range_season = GVRange.GetFocusedRowCellDisplayText("range").ToString
    End Sub
    'Activated
    Private Sub FormSeason_Activated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Activated
        If quick_edit = "-1" Then
            FormMain.show_rb(Name)
        End If
        mainPageChanged()
    End Sub
    'Deadactivated
    Private Sub FormSeason_Deactivate(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Deactivate
        If quick_edit = "-1" Then
            FormMain.hide_rb()
        End If
    End Sub

    'Click Grid Season
    Private Sub GVSeason_RowClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Grid.RowClickEventArgs) Handles GVSeason.RowClick
        getSeasonInformation()
        viewDelivery(id_season)
    End Sub
    'Event Main Page Changed 
    Private Sub XTCMainSeason_SelectedPageChanged(ByVal sender As System.Object, ByVal e As DevExpress.XtraTab.TabPageChangedEventArgs) Handles XTCMainSeason.SelectedPageChanged
        mainPageChanged()
    End Sub
    'Main Page Changed
    Sub mainPageChanged()
        If XTCMainSeason.SelectedTabPageIndex = 0 Then 'Internal Season
            ''MsgBox("Internal Season")
            mainSubPageChanged()
        Else 'Orign Season
            ''MsgBox("Season Orign")
            checkFormAccess(Name)
            button_main(bnew_active21, bedit_active21, bdel_active21)
        End If
    End Sub
    'Main Sub Page Changed
    Sub mainSubPageChanged()
        If XTCSeason.SelectedTabPageIndex = 0 Then 'range
            ''MsgBox("Range")
            checkFormAccess(Name)
            button_main(bnew_active11, bedit_active11, bdel_active11)

            'check from menu
            If from_menu = "delivery" Then
                button_main("0", "0", "0")
            End If
        ElseIf XTCSeason.SelectedTabPageIndex = 1 Then 'season
            ''MsgBox("Season")
            checkFormAccess(Name)
            button_main(bnew_active12, bedit_active12, bdel_active12)
        ElseIf XTCSeason.SelectedTabPageIndex = 2 Then 'delivery
            '' MsgBox("Delivery")
            checkFormAccess(Name)
            button_main(bnew_active13, bedit_active13, bdel_active13)

            'check from menu
            If from_menu = "season" Then
                button_main("0", "0", "0")
            End If
        End If
    End Sub
    'Event Sub Page Changed
    Private Sub XTCSeason_SelectedPageChanged(ByVal sender As System.Object, ByVal e As DevExpress.XtraTab.TabPageChangedEventArgs) Handles XTCSeason.SelectedPageChanged
        mainSubPageChanged()
    End Sub

    Private Sub GVDelivery_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GVDelivery.DoubleClick
        editButton()
    End Sub

    Sub editButton()
        Cursor = Cursors.WaitCursor
        FormMain.but_edit()
        Cursor = Cursors.Default
    End Sub

    Private Sub GVSeason_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GVSeason.DoubleClick
        editButton()
    End Sub

    Private Sub GVRange_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GVRange.DoubleClick
        editButton()
    End Sub

    Private Sub FormSeason_FormClosed(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles MyBase.FormClosed
        If quick_edit <> "-1" Then
            FormMasterDesignSingle.viewSeason(FormMasterDesignSingle.LESeason)
            FormMasterDesignSingle.viewDelivery(FormMasterDesignSingle.LESeason.EditValue.ToString)
            FormMasterDesignSingle.viewSeasonOrign(FormMasterDesignSingle.SLESeasonOrigin)
        End If
        Dispose()
    End Sub

    Private Sub BtnAddRange_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnAddRange.Click
        Cursor = Cursors.WaitCursor
        'new range
        FormRangeSingle.action = "ins"
        FormRangeSingle.ShowDialog()
        Cursor = Cursors.Default
    End Sub

    Private Sub BtnEditRange_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnEditRange.Click
        Cursor = Cursors.WaitCursor
        'edit range
        FormRangeSingle.action = "upd"
        FormRangeSingle.id_range = GVRange.GetFocusedRowCellValue("id_range").ToString
        FormRangeSingle.TxtRange.Text = GVRange.GetFocusedRowCellValue("range").ToString
        FormRangeSingle.ShowDialog()
        Cursor = Cursors.Default
    End Sub

    Private Sub BtnDeleteRange_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnDeleteRange.Click
        Dim confirm As DialogResult
        confirm = DevExpress.XtraEditors.XtraMessageBox.Show("Are you sure want to delete this data?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
        If confirm = Windows.Forms.DialogResult.Yes Then
            Cursor = Cursors.WaitCursor
            Try
                Dim id_range As String = Me.GVRange.GetFocusedRowCellValue("id_range").ToString
                Dim query As String = String.Format("DELETE FROM tb_range WHERE id_range='{0}'", id_range)
                execute_non_query(query, True, "", "", "", "")
                logData("tb_range", 3)
                Me.viewRange()
            Catch ex As Exception
                errorDelete()
            End Try
            Cursor = Cursors.Default
        End If
    End Sub

    Private Sub BtnAddSeason_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnAddSeason.Click
        Cursor = Cursors.WaitCursor
        FormSeasonSingle.action = "ins"
        FormSeasonSingle.ShowDialog()
        Cursor = Cursors.Default
    End Sub

    Private Sub BtnEditSeason_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnEditSeason.Click
        Cursor = Cursors.WaitCursor
        FormSeasonSingle.action = "upd"
        FormSeasonSingle.id_season = Me.GVSeason.GetFocusedRowCellValue("id_season").ToString
        FormSeasonSingle.ShowDialog()
        Cursor = Cursors.Default
    End Sub


    Private Sub BtnDeleteSeason_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnDeleteSeason.Click
        Dim confirm As DialogResult
        confirm = DevExpress.XtraEditors.XtraMessageBox.Show("Are you sure want to delete this data?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
        If confirm = Windows.Forms.DialogResult.Yes Then
            Cursor = Cursors.WaitCursor
            Try
                Dim id_season As String = Me.GVSeason.GetFocusedRowCellValue("id_season").ToString
                Dim query As String = String.Format("DELETE FROM tb_season WHERE id_season='{0}'", id_season)
                execute_non_query(query, True, "", "", "", "")
                logData("tb_season", 3)
                Me.viewSeason()
            Catch ex As Exception
                errorDelete()
            End Try
            Cursor = Cursors.Default
        End If
    End Sub

    Private Sub BtnAddDel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnAddDel.Click
        Cursor = Cursors.WaitCursor
        'new delivery
        FormDeliverySingle.action = "ins"
        FormDeliverySingle.GCtrlDelivery.Text = "Range " + Me.range_season.ToString + " - Season " + Me.season.ToString
        FormDeliverySingle.ShowDialog()
        Cursor = Cursors.Default
    End Sub

    Private Sub BtnEditDel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnEditDel.Click
        Cursor = Cursors.WaitCursor
        'edit delivery
        FormDeliverySingle.action = "upd"
        FormDeliverySingle.id_delivery = Me.GVDelivery.GetFocusedRowCellValue("id_delivery").ToString
        FormDeliverySingle.GCtrlDelivery.Text = "Range " + Me.range_season.ToString + " - Season " + Me.season.ToString
        FormDeliverySingle.ShowDialog()
        Cursor = Cursors.Default
    End Sub


    Private Sub BtnDeleteDel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnDeleteDel.Click
        Dim confirm As DialogResult
        confirm = DevExpress.XtraEditors.XtraMessageBox.Show("Are you sure want to delete this data?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
        If confirm = Windows.Forms.DialogResult.Yes Then
            Cursor = Cursors.WaitCursor
            Try
                Dim id_delivery As String = Me.GVDelivery.GetFocusedRowCellDisplayText("id_delivery").ToString
                Dim query As String = String.Format("DELETE FROM tb_season_delivery WHERE id_delivery='{0}'", id_delivery)
                execute_non_query(query, True, "", "", "", "")
                logData("tb_season_delivery", 3)
                Me.viewDelivery(Me.id_season)
            Catch ex As Exception
                errorDelete()
            End Try
            Cursor = Cursors.Default
        End If
    End Sub

    Private Sub GVRange_FocusedRowChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles GVRange.FocusedRowChanged
        getSeasonInformation()
        viewDelivery(id_season)

        'check from menu
        If from_menu = "delivery" Then
            button_main("0", "0", "0")
        End If
    End Sub

    Private Sub AddOrigin_Click(sender As Object, e As EventArgs) Handles AddOrigin.Click
        FormSeasonorignSingle.action = "ins"
        FormSeasonorignSingle.ShowDialog()
    End Sub

    Private Sub EditOrigin_Click(sender As Object, e As EventArgs) Handles EditOrigin.Click
        FormSeasonorignSingle.action = "upd"
        FormSeasonorignSingle.id_season_orign = GVOrignSeason.GetFocusedRowCellDisplayText("id_season_orign").ToString
        FormSeasonorignSingle.TxtSeason.Text = GVOrignSeason.GetFocusedRowCellDisplayText("season_orign").ToString
        FormSeasonorignSingle.TxtSeasonPrintedName.Text = GVOrignSeason.GetFocusedRowCellDisplayText("season_orign_display").ToString
        'LECountry.ItemIndex = FormSeasonorignSingle.LECountry.Properties.GetDataSourceRowIndex("id_country", FormSeason.GVOrignSeason.GetFocusedRowCellDisplayText("id_country").ToString)
        FormSeasonorignSingle.id_country = GVOrignSeason.GetFocusedRowCellDisplayText("id_country").ToString
        FormSeasonorignSingle.season_orign_year = GVOrignSeason.GetFocusedRowCellDisplayText("season_orign_year").ToString
        FormSeasonorignSingle.ShowDialog()
    End Sub

    Private Sub DeleteOrigin_Click(sender As Object, e As EventArgs) Handles DeleteOrigin.Click
        Try
            Dim query As String = ""
            Dim id_season_origin As String = GVOrignSeason.GetFocusedRowCellDisplayText("id_season_orign").ToString
            query = String.Format("DELETE FROM tb_season_orign WHERE id_season_orign = '{0}'", id_season_origin)
            execute_non_query(query, True, "", "", "", "")
            logData("tb_season_orign", 3)
            viewSeasonOrign()
        Catch ex As Exception
            errorDelete()
        End Try
    End Sub
End Class