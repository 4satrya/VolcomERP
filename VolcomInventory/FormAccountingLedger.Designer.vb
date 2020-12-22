<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FormAccountingLedger
    Inherits DevExpress.XtraEditors.XtraForm

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.SLEUnit = New DevExpress.XtraEditors.SearchLookUpEdit()
        Me.GridView2 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumn25 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn26 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn27 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.LabelControl5 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl4 = New DevExpress.XtraEditors.LabelControl()
        Me.SLUETo = New DevExpress.XtraEditors.SearchLookUpEdit()
        Me.GridView1 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumn13 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn14 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn15 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.LabelControl3 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl2 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl1 = New DevExpress.XtraEditors.LabelControl()
        Me.DETo = New DevExpress.XtraEditors.DateEdit()
        Me.DEFrom = New DevExpress.XtraEditors.DateEdit()
        Me.SBView = New DevExpress.XtraEditors.SimpleButton()
        Me.SLUEFrom = New DevExpress.XtraEditors.SearchLookUpEdit()
        Me.SearchLookUpEdit1View = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumn10 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn11 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn12 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GCAccountingLedger = New DevExpress.XtraGrid.GridControl()
        Me.ViewMenu = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.ViewDetailToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ViewReffToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ViewJournalToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.GVAccountingLedger = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumn24 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn20 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn19 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn18 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn17 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn30 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn28 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn16 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn23 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn1 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn2 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn3 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn4 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn5 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn6 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn22 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn7 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn8 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn9 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn21 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumncomp_group = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn29 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.XtraScrollableControl1 = New DevExpress.XtraEditors.XtraScrollableControl()
        Me.BExportRaw = New DevExpress.XtraEditors.SimpleButton()
        Me.BSearchVoucher = New DevExpress.XtraEditors.SimpleButton()
        CType(Me.SLEUnit.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SLUETo.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DETo.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DETo.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DEFrom.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DEFrom.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SLUEFrom.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SearchLookUpEdit1View, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GCAccountingLedger, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ViewMenu.SuspendLayout()
        CType(Me.GVAccountingLedger, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.XtraScrollableControl1.SuspendLayout()
        Me.SuspendLayout()
        '
        'SLEUnit
        '
        Me.SLEUnit.Location = New System.Drawing.Point(41, 13)
        Me.SLEUnit.Name = "SLEUnit"
        Me.SLEUnit.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.SLEUnit.Properties.View = Me.GridView2
        Me.SLEUnit.Size = New System.Drawing.Size(138, 20)
        Me.SLEUnit.TabIndex = 10
        '
        'GridView2
        '
        Me.GridView2.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumn25, Me.GridColumn26, Me.GridColumn27})
        Me.GridView2.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
        Me.GridView2.Name = "GridView2"
        Me.GridView2.OptionsSelection.EnableAppearanceFocusedCell = False
        Me.GridView2.OptionsView.ShowGroupPanel = False
        '
        'GridColumn25
        '
        Me.GridColumn25.Caption = "id_coa_tag"
        Me.GridColumn25.FieldName = "id_comp"
        Me.GridColumn25.Name = "GridColumn25"
        '
        'GridColumn26
        '
        Me.GridColumn26.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumn26.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridColumn26.AppearanceHeader.Options.UseTextOptions = True
        Me.GridColumn26.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridColumn26.Caption = "Number"
        Me.GridColumn26.FieldName = "tag_code"
        Me.GridColumn26.Name = "GridColumn26"
        Me.GridColumn26.Visible = True
        Me.GridColumn26.VisibleIndex = 0
        Me.GridColumn26.Width = 281
        '
        'GridColumn27
        '
        Me.GridColumn27.Caption = "Unit"
        Me.GridColumn27.FieldName = "tag_description"
        Me.GridColumn27.Name = "GridColumn27"
        Me.GridColumn27.Visible = True
        Me.GridColumn27.VisibleIndex = 1
        Me.GridColumn27.Width = 1351
        '
        'LabelControl5
        '
        Me.LabelControl5.Location = New System.Drawing.Point(16, 16)
        Me.LabelControl5.Name = "LabelControl5"
        Me.LabelControl5.Size = New System.Drawing.Size(19, 13)
        Me.LabelControl5.TabIndex = 9
        Me.LabelControl5.Text = "Unit"
        '
        'LabelControl4
        '
        Me.LabelControl4.Location = New System.Drawing.Point(804, 16)
        Me.LabelControl4.Name = "LabelControl4"
        Me.LabelControl4.Size = New System.Drawing.Size(4, 13)
        Me.LabelControl4.TabIndex = 8
        Me.LabelControl4.Text = "-"
        '
        'SLUETo
        '
        Me.SLUETo.Location = New System.Drawing.Point(814, 13)
        Me.SLUETo.Name = "SLUETo"
        Me.SLUETo.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.SLUETo.Properties.View = Me.GridView1
        Me.SLUETo.Size = New System.Drawing.Size(200, 20)
        Me.SLUETo.TabIndex = 7
        '
        'GridView1
        '
        Me.GridView1.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumn13, Me.GridColumn14, Me.GridColumn15})
        Me.GridView1.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
        Me.GridView1.Name = "GridView1"
        Me.GridView1.OptionsSelection.EnableAppearanceFocusedCell = False
        Me.GridView1.OptionsView.ShowGroupPanel = False
        '
        'GridColumn13
        '
        Me.GridColumn13.Caption = "Account"
        Me.GridColumn13.FieldName = "acc_name"
        Me.GridColumn13.Name = "GridColumn13"
        Me.GridColumn13.Visible = True
        Me.GridColumn13.VisibleIndex = 0
        '
        'GridColumn14
        '
        Me.GridColumn14.Caption = "Acc. Description"
        Me.GridColumn14.FieldName = "acc_description"
        Me.GridColumn14.Name = "GridColumn14"
        Me.GridColumn14.Visible = True
        Me.GridColumn14.VisibleIndex = 1
        '
        'GridColumn15
        '
        Me.GridColumn15.FieldName = "acc_name_description"
        Me.GridColumn15.Name = "GridColumn15"
        '
        'LabelControl3
        '
        Me.LabelControl3.Location = New System.Drawing.Point(548, 16)
        Me.LabelControl3.Name = "LabelControl3"
        Me.LabelControl3.Size = New System.Drawing.Size(39, 13)
        Me.LabelControl3.TabIndex = 6
        Me.LabelControl3.Text = "Account"
        '
        'LabelControl2
        '
        Me.LabelControl2.Location = New System.Drawing.Point(185, 16)
        Me.LabelControl2.Name = "LabelControl2"
        Me.LabelControl2.Size = New System.Drawing.Size(30, 13)
        Me.LabelControl2.TabIndex = 5
        Me.LabelControl2.Text = "Period"
        '
        'LabelControl1
        '
        Me.LabelControl1.Location = New System.Drawing.Point(382, 16)
        Me.LabelControl1.Name = "LabelControl1"
        Me.LabelControl1.Size = New System.Drawing.Size(4, 13)
        Me.LabelControl1.TabIndex = 4
        Me.LabelControl1.Text = "-"
        '
        'DETo
        '
        Me.DETo.EditValue = Nothing
        Me.DETo.Location = New System.Drawing.Point(392, 13)
        Me.DETo.Name = "DETo"
        Me.DETo.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.DETo.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.DETo.Properties.DisplayFormat.FormatString = "dd MMMM yyyy"
        Me.DETo.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.DETo.Properties.EditFormat.FormatString = "dd MMMM yyyy"
        Me.DETo.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.DETo.Properties.Mask.EditMask = "dd MMMM yyyy"
        Me.DETo.Properties.Mask.UseMaskAsDisplayFormat = True
        Me.DETo.Size = New System.Drawing.Size(150, 20)
        Me.DETo.TabIndex = 3
        '
        'DEFrom
        '
        Me.DEFrom.EditValue = Nothing
        Me.DEFrom.Location = New System.Drawing.Point(226, 13)
        Me.DEFrom.Name = "DEFrom"
        Me.DEFrom.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.DEFrom.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.DEFrom.Properties.DisplayFormat.FormatString = "dd MMMM yyyy"
        Me.DEFrom.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.DEFrom.Properties.EditFormat.FormatString = "dd MMMM yyyy"
        Me.DEFrom.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.DEFrom.Properties.Mask.EditMask = "dd MMMM yyyy"
        Me.DEFrom.Properties.Mask.UseMaskAsDisplayFormat = True
        Me.DEFrom.Size = New System.Drawing.Size(150, 20)
        Me.DEFrom.TabIndex = 2
        '
        'SBView
        '
        Me.SBView.Location = New System.Drawing.Point(1025, 11)
        Me.SBView.Name = "SBView"
        Me.SBView.Size = New System.Drawing.Size(75, 23)
        Me.SBView.TabIndex = 1
        Me.SBView.Text = "View"
        '
        'SLUEFrom
        '
        Me.SLUEFrom.Location = New System.Drawing.Point(598, 13)
        Me.SLUEFrom.Name = "SLUEFrom"
        Me.SLUEFrom.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.SLUEFrom.Properties.View = Me.SearchLookUpEdit1View
        Me.SLUEFrom.Size = New System.Drawing.Size(200, 20)
        Me.SLUEFrom.TabIndex = 0
        '
        'SearchLookUpEdit1View
        '
        Me.SearchLookUpEdit1View.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumn10, Me.GridColumn11, Me.GridColumn12})
        Me.SearchLookUpEdit1View.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
        Me.SearchLookUpEdit1View.Name = "SearchLookUpEdit1View"
        Me.SearchLookUpEdit1View.OptionsSelection.EnableAppearanceFocusedCell = False
        Me.SearchLookUpEdit1View.OptionsView.ShowGroupPanel = False
        '
        'GridColumn10
        '
        Me.GridColumn10.Caption = "Account"
        Me.GridColumn10.FieldName = "acc_name"
        Me.GridColumn10.Name = "GridColumn10"
        Me.GridColumn10.Visible = True
        Me.GridColumn10.VisibleIndex = 0
        '
        'GridColumn11
        '
        Me.GridColumn11.Caption = "Acc. Description"
        Me.GridColumn11.FieldName = "acc_description"
        Me.GridColumn11.Name = "GridColumn11"
        Me.GridColumn11.Visible = True
        Me.GridColumn11.VisibleIndex = 1
        '
        'GridColumn12
        '
        Me.GridColumn12.FieldName = "acc_name_description"
        Me.GridColumn12.Name = "GridColumn12"
        '
        'GCAccountingLedger
        '
        Me.GCAccountingLedger.ContextMenuStrip = Me.ViewMenu
        Me.GCAccountingLedger.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCAccountingLedger.Location = New System.Drawing.Point(0, 69)
        Me.GCAccountingLedger.MainView = Me.GVAccountingLedger
        Me.GCAccountingLedger.Name = "GCAccountingLedger"
        Me.GCAccountingLedger.Size = New System.Drawing.Size(1259, 660)
        Me.GCAccountingLedger.TabIndex = 1
        Me.GCAccountingLedger.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVAccountingLedger})
        '
        'ViewMenu
        '
        Me.ViewMenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ViewDetailToolStripMenuItem, Me.ViewReffToolStripMenuItem, Me.ViewJournalToolStripMenuItem})
        Me.ViewMenu.Name = "ContextMenuStripYM"
        Me.ViewMenu.Size = New System.Drawing.Size(141, 70)
        '
        'ViewDetailToolStripMenuItem
        '
        Me.ViewDetailToolStripMenuItem.Name = "ViewDetailToolStripMenuItem"
        Me.ViewDetailToolStripMenuItem.Size = New System.Drawing.Size(140, 22)
        Me.ViewDetailToolStripMenuItem.Text = "View Report"
        '
        'ViewReffToolStripMenuItem
        '
        Me.ViewReffToolStripMenuItem.Name = "ViewReffToolStripMenuItem"
        Me.ViewReffToolStripMenuItem.Size = New System.Drawing.Size(140, 22)
        Me.ViewReffToolStripMenuItem.Text = "View Reff"
        '
        'ViewJournalToolStripMenuItem
        '
        Me.ViewJournalToolStripMenuItem.Name = "ViewJournalToolStripMenuItem"
        Me.ViewJournalToolStripMenuItem.Size = New System.Drawing.Size(140, 22)
        Me.ViewJournalToolStripMenuItem.Text = "View Journal"
        '
        'GVAccountingLedger
        '
        Me.GVAccountingLedger.AppearancePrint.FooterPanel.BackColor = System.Drawing.Color.White
        Me.GVAccountingLedger.AppearancePrint.FooterPanel.BorderColor = System.Drawing.Color.Black
        Me.GVAccountingLedger.AppearancePrint.FooterPanel.Font = New System.Drawing.Font("Tahoma", 7.25!)
        Me.GVAccountingLedger.AppearancePrint.FooterPanel.Options.UseBackColor = True
        Me.GVAccountingLedger.AppearancePrint.FooterPanel.Options.UseBorderColor = True
        Me.GVAccountingLedger.AppearancePrint.FooterPanel.Options.UseFont = True
        Me.GVAccountingLedger.AppearancePrint.GroupFooter.BackColor = System.Drawing.Color.White
        Me.GVAccountingLedger.AppearancePrint.GroupFooter.BorderColor = System.Drawing.Color.Black
        Me.GVAccountingLedger.AppearancePrint.GroupFooter.Font = New System.Drawing.Font("Tahoma", 7.25!)
        Me.GVAccountingLedger.AppearancePrint.GroupFooter.Options.UseBackColor = True
        Me.GVAccountingLedger.AppearancePrint.GroupFooter.Options.UseBorderColor = True
        Me.GVAccountingLedger.AppearancePrint.GroupFooter.Options.UseFont = True
        Me.GVAccountingLedger.AppearancePrint.GroupRow.BackColor = System.Drawing.Color.White
        Me.GVAccountingLedger.AppearancePrint.GroupRow.BorderColor = System.Drawing.Color.Black
        Me.GVAccountingLedger.AppearancePrint.GroupRow.Font = New System.Drawing.Font("Tahoma", 7.25!, System.Drawing.FontStyle.Bold)
        Me.GVAccountingLedger.AppearancePrint.GroupRow.Options.UseBackColor = True
        Me.GVAccountingLedger.AppearancePrint.GroupRow.Options.UseBorderColor = True
        Me.GVAccountingLedger.AppearancePrint.GroupRow.Options.UseFont = True
        Me.GVAccountingLedger.AppearancePrint.HeaderPanel.BackColor = System.Drawing.Color.White
        Me.GVAccountingLedger.AppearancePrint.HeaderPanel.BorderColor = System.Drawing.Color.Black
        Me.GVAccountingLedger.AppearancePrint.HeaderPanel.Font = New System.Drawing.Font("Tahoma", 7.25!, System.Drawing.FontStyle.Bold)
        Me.GVAccountingLedger.AppearancePrint.HeaderPanel.Options.UseBackColor = True
        Me.GVAccountingLedger.AppearancePrint.HeaderPanel.Options.UseBorderColor = True
        Me.GVAccountingLedger.AppearancePrint.HeaderPanel.Options.UseFont = True
        Me.GVAccountingLedger.AppearancePrint.Lines.BackColor = System.Drawing.Color.Black
        Me.GVAccountingLedger.AppearancePrint.Lines.Options.UseBackColor = True
        Me.GVAccountingLedger.AppearancePrint.Row.BackColor = System.Drawing.Color.White
        Me.GVAccountingLedger.AppearancePrint.Row.BorderColor = System.Drawing.Color.Black
        Me.GVAccountingLedger.AppearancePrint.Row.Font = New System.Drawing.Font("Tahoma", 7.25!)
        Me.GVAccountingLedger.AppearancePrint.Row.Options.UseBackColor = True
        Me.GVAccountingLedger.AppearancePrint.Row.Options.UseBorderColor = True
        Me.GVAccountingLedger.AppearancePrint.Row.Options.UseFont = True
        Me.GVAccountingLedger.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumn24, Me.GridColumn20, Me.GridColumn19, Me.GridColumn18, Me.GridColumn17, Me.GridColumn30, Me.GridColumn28, Me.GridColumn16, Me.GridColumn23, Me.GridColumn1, Me.GridColumn2, Me.GridColumn3, Me.GridColumn4, Me.GridColumn5, Me.GridColumn6, Me.GridColumn22, Me.GridColumn7, Me.GridColumn8, Me.GridColumn9, Me.GridColumn21, Me.GridColumncomp_group, Me.GridColumn29})
        Me.GVAccountingLedger.GridControl = Me.GCAccountingLedger
        Me.GVAccountingLedger.GroupCount = 3
        Me.GVAccountingLedger.GroupFormat = "[#image]{1} {2}"
        Me.GVAccountingLedger.GroupSummary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "debit", Me.GridColumn7, "{0:N2}"), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "credit", Me.GridColumn8, "{0:N2}"), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "last_balance", Me.GridColumn9, "{0:N2}"), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Custom, "acc_trans_note", Me.GridColumn6, "")})
        Me.GVAccountingLedger.LevelIndent = 0
        Me.GVAccountingLedger.Name = "GVAccountingLedger"
        Me.GVAccountingLedger.OptionsBehavior.AutoExpandAllGroups = True
        Me.GVAccountingLedger.OptionsBehavior.Editable = False
        Me.GVAccountingLedger.OptionsView.ColumnAutoWidth = False
        Me.GVAccountingLedger.OptionsView.GroupFooterShowMode = DevExpress.XtraGrid.Views.Grid.GroupFooterShowMode.VisibleAlways
        Me.GVAccountingLedger.OptionsView.ShowFooter = True
        Me.GVAccountingLedger.OptionsView.ShowGroupPanel = False
        Me.GVAccountingLedger.SortInfo.AddRange(New DevExpress.XtraGrid.Columns.GridColumnSortInfo() {New DevExpress.XtraGrid.Columns.GridColumnSortInfo(Me.GridColumn28, DevExpress.Data.ColumnSortOrder.Ascending), New DevExpress.XtraGrid.Columns.GridColumnSortInfo(Me.GridColumn23, DevExpress.Data.ColumnSortOrder.Ascending), New DevExpress.XtraGrid.Columns.GridColumnSortInfo(Me.GridColumn1, DevExpress.Data.ColumnSortOrder.Ascending)})
        '
        'GridColumn24
        '
        Me.GridColumn24.FieldName = "id_acc_trans"
        Me.GridColumn24.Name = "GridColumn24"
        '
        'GridColumn20
        '
        Me.GridColumn20.FieldName = "id_report"
        Me.GridColumn20.Name = "GridColumn20"
        '
        'GridColumn19
        '
        Me.GridColumn19.FieldName = "report_mark_type"
        Me.GridColumn19.Name = "GridColumn19"
        '
        'GridColumn18
        '
        Me.GridColumn18.FieldName = "id_report_ref"
        Me.GridColumn18.Name = "GridColumn18"
        '
        'GridColumn17
        '
        Me.GridColumn17.FieldName = "report_mark_type_ref"
        Me.GridColumn17.Name = "GridColumn17"
        '
        'GridColumn30
        '
        Me.GridColumn30.Caption = "Journal Number"
        Me.GridColumn30.FieldName = "acc_trans_number"
        Me.GridColumn30.Name = "GridColumn30"
        Me.GridColumn30.Visible = True
        Me.GridColumn30.VisibleIndex = 1
        Me.GridColumn30.Width = 96
        '
        'GridColumn28
        '
        Me.GridColumn28.Caption = "Unit"
        Me.GridColumn28.FieldName = "tag_description"
        Me.GridColumn28.Name = "GridColumn28"
        Me.GridColumn28.Visible = True
        Me.GridColumn28.VisibleIndex = 5
        '
        'GridColumn16
        '
        Me.GridColumn16.Caption = "No"
        Me.GridColumn16.FieldName = "number"
        Me.GridColumn16.Name = "GridColumn16"
        Me.GridColumn16.Visible = True
        Me.GridColumn16.VisibleIndex = 0
        '
        'GridColumn23
        '
        Me.GridColumn23.Caption = "Account"
        Me.GridColumn23.FieldName = "acc_name_1"
        Me.GridColumn23.Name = "GridColumn23"
        Me.GridColumn23.Visible = True
        Me.GridColumn23.VisibleIndex = 5
        '
        'GridColumn1
        '
        Me.GridColumn1.Caption = "Account"
        Me.GridColumn1.FieldName = "acc_name"
        Me.GridColumn1.Name = "GridColumn1"
        Me.GridColumn1.Visible = True
        Me.GridColumn1.VisibleIndex = 1
        '
        'GridColumn2
        '
        Me.GridColumn2.Caption = "Report Number"
        Me.GridColumn2.FieldName = "report_number"
        Me.GridColumn2.Name = "GridColumn2"
        Me.GridColumn2.Visible = True
        Me.GridColumn2.VisibleIndex = 2
        '
        'GridColumn3
        '
        Me.GridColumn3.Caption = "Company"
        Me.GridColumn3.FieldName = "comp_number"
        Me.GridColumn3.Name = "GridColumn3"
        Me.GridColumn3.Visible = True
        Me.GridColumn3.VisibleIndex = 3
        '
        'GridColumn4
        '
        Me.GridColumn4.Caption = "Journal Date"
        Me.GridColumn4.DisplayFormat.FormatString = "dd MMMM yyyy"
        Me.GridColumn4.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.GridColumn4.FieldName = "date_created"
        Me.GridColumn4.Name = "GridColumn4"
        Me.GridColumn4.Visible = True
        Me.GridColumn4.VisibleIndex = 6
        '
        'GridColumn5
        '
        Me.GridColumn5.Caption = "Reff"
        Me.GridColumn5.FieldName = "report_number_ref"
        Me.GridColumn5.Name = "GridColumn5"
        Me.GridColumn5.Visible = True
        Me.GridColumn5.VisibleIndex = 7
        '
        'GridColumn6
        '
        Me.GridColumn6.Caption = "Description"
        Me.GridColumn6.FieldName = "acc_trans_note"
        Me.GridColumn6.Name = "GridColumn6"
        Me.GridColumn6.Visible = True
        Me.GridColumn6.VisibleIndex = 8
        '
        'GridColumn22
        '
        Me.GridColumn22.Caption = "Qty"
        Me.GridColumn22.DisplayFormat.FormatString = "N2"
        Me.GridColumn22.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumn22.FieldName = "qty"
        Me.GridColumn22.Name = "GridColumn22"
        Me.GridColumn22.Visible = True
        Me.GridColumn22.VisibleIndex = 9
        '
        'GridColumn7
        '
        Me.GridColumn7.Caption = "Debit"
        Me.GridColumn7.DisplayFormat.FormatString = "N2"
        Me.GridColumn7.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumn7.FieldName = "debit"
        Me.GridColumn7.Name = "GridColumn7"
        Me.GridColumn7.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "debit", "{0:N2}")})
        Me.GridColumn7.Visible = True
        Me.GridColumn7.VisibleIndex = 10
        '
        'GridColumn8
        '
        Me.GridColumn8.Caption = "Credit"
        Me.GridColumn8.DisplayFormat.FormatString = "N2"
        Me.GridColumn8.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumn8.FieldName = "credit"
        Me.GridColumn8.Name = "GridColumn8"
        Me.GridColumn8.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "credit", "{0:N2}")})
        Me.GridColumn8.Visible = True
        Me.GridColumn8.VisibleIndex = 11
        '
        'GridColumn9
        '
        Me.GridColumn9.Caption = "Balance"
        Me.GridColumn9.DisplayFormat.FormatString = "N2"
        Me.GridColumn9.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumn9.FieldName = "balance"
        Me.GridColumn9.Name = "GridColumn9"
        Me.GridColumn9.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "last_balance", "{0:N2}")})
        Me.GridColumn9.Visible = True
        Me.GridColumn9.VisibleIndex = 12
        '
        'GridColumn21
        '
        Me.GridColumn21.DisplayFormat.FormatString = "N2"
        Me.GridColumn21.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumn21.FieldName = "last_balance"
        Me.GridColumn21.Name = "GridColumn21"
        '
        'GridColumncomp_group
        '
        Me.GridColumncomp_group.Caption = "Comp. Group"
        Me.GridColumncomp_group.FieldName = "comp_group"
        Me.GridColumncomp_group.Name = "GridColumncomp_group"
        Me.GridColumncomp_group.Visible = True
        Me.GridColumncomp_group.VisibleIndex = 4
        '
        'GridColumn29
        '
        Me.GridColumn29.Caption = "Vendor"
        Me.GridColumn29.FieldName = "vendor_name"
        Me.GridColumn29.Name = "GridColumn29"
        Me.GridColumn29.Visible = True
        Me.GridColumn29.VisibleIndex = 5
        '
        'XtraScrollableControl1
        '
        Me.XtraScrollableControl1.Controls.Add(Me.BSearchVoucher)
        Me.XtraScrollableControl1.Controls.Add(Me.BExportRaw)
        Me.XtraScrollableControl1.Controls.Add(Me.SLEUnit)
        Me.XtraScrollableControl1.Controls.Add(Me.LabelControl5)
        Me.XtraScrollableControl1.Controls.Add(Me.SLUEFrom)
        Me.XtraScrollableControl1.Controls.Add(Me.LabelControl4)
        Me.XtraScrollableControl1.Controls.Add(Me.SBView)
        Me.XtraScrollableControl1.Controls.Add(Me.SLUETo)
        Me.XtraScrollableControl1.Controls.Add(Me.DEFrom)
        Me.XtraScrollableControl1.Controls.Add(Me.LabelControl3)
        Me.XtraScrollableControl1.Controls.Add(Me.DETo)
        Me.XtraScrollableControl1.Controls.Add(Me.LabelControl2)
        Me.XtraScrollableControl1.Controls.Add(Me.LabelControl1)
        Me.XtraScrollableControl1.Dock = System.Windows.Forms.DockStyle.Top
        Me.XtraScrollableControl1.Location = New System.Drawing.Point(0, 0)
        Me.XtraScrollableControl1.Name = "XtraScrollableControl1"
        Me.XtraScrollableControl1.Padding = New System.Windows.Forms.Padding(5)
        Me.XtraScrollableControl1.Size = New System.Drawing.Size(1259, 69)
        Me.XtraScrollableControl1.TabIndex = 4
        '
        'BExportRaw
        '
        Me.BExportRaw.Location = New System.Drawing.Point(1106, 11)
        Me.BExportRaw.Name = "BExportRaw"
        Me.BExportRaw.Size = New System.Drawing.Size(103, 23)
        Me.BExportRaw.TabIndex = 11
        Me.BExportRaw.Text = "Export to Excel"
        '
        'BSearchVoucher
        '
        Me.BSearchVoucher.Location = New System.Drawing.Point(1215, 11)
        Me.BSearchVoucher.Name = "BSearchVoucher"
        Me.BSearchVoucher.Size = New System.Drawing.Size(100, 23)
        Me.BSearchVoucher.TabIndex = 12
        Me.BSearchVoucher.Text = "Search by number"
        '
        'FormAccountingLedger
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1259, 729)
        Me.Controls.Add(Me.GCAccountingLedger)
        Me.Controls.Add(Me.XtraScrollableControl1)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FormAccountingLedger"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Buku Besar"
        CType(Me.SLEUnit.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SLUETo.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DETo.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DETo.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DEFrom.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DEFrom.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SLUEFrom.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SearchLookUpEdit1View, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GCAccountingLedger, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ViewMenu.ResumeLayout(False)
        CType(Me.GVAccountingLedger, System.ComponentModel.ISupportInitialize).EndInit()
        Me.XtraScrollableControl1.ResumeLayout(False)
        Me.XtraScrollableControl1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GCAccountingLedger As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVAccountingLedger As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumn1 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn2 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn3 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn4 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn5 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn6 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn7 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn8 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn9 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents SLUEFrom As DevExpress.XtraEditors.SearchLookUpEdit
    Friend WithEvents SearchLookUpEdit1View As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents SBView As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents GridColumn10 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn11 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn12 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents LabelControl3 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl2 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl1 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents DETo As DevExpress.XtraEditors.DateEdit
    Friend WithEvents DEFrom As DevExpress.XtraEditors.DateEdit
    Friend WithEvents LabelControl4 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents SLUETo As DevExpress.XtraEditors.SearchLookUpEdit
    Friend WithEvents GridView1 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumn13 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn14 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn15 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn16 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ViewMenu As ContextMenuStrip
    Friend WithEvents ViewDetailToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ViewReffToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents GridColumn20 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn19 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn18 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn17 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn21 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn22 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumncomp_group As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn23 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ViewJournalToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents GridColumn24 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents SLEUnit As DevExpress.XtraEditors.SearchLookUpEdit
    Friend WithEvents GridView2 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumn25 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn26 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn27 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents LabelControl5 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents XtraScrollableControl1 As DevExpress.XtraEditors.XtraScrollableControl
    Friend WithEvents GridColumn28 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn29 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents BExportRaw As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents GridColumn30 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents BSearchVoucher As DevExpress.XtraEditors.SimpleButton
End Class
