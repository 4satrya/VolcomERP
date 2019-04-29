<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormFGLinePlan
    Inherits DevExpress.XtraEditors.XtraForm

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
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
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormFGLinePlan))
        Me.PanelControl1 = New DevExpress.XtraEditors.PanelControl()
        Me.PanelControlNav = New DevExpress.XtraEditors.PanelControl()
        Me.SLESeason = New DevExpress.XtraEditors.SearchLookUpEdit()
        Me.SearchLookUpEdit1View = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumn6 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn8 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn3 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.LabelControl1 = New DevExpress.XtraEditors.LabelControl()
        Me.CESelectAll = New DevExpress.XtraEditors.CheckEdit()
        Me.BtnView = New DevExpress.XtraEditors.SimpleButton()
        Me.BtnImport = New DevExpress.XtraEditors.SimpleButton()
        Me.GCData = New DevExpress.XtraGrid.GridControl()
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.EditToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DeleteThisRowToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.GVData = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumnId = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnid_season = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnseason = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnid_delivery = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumndelivery = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnid_division = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumndivision = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumncategory = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnid_category = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnid_source = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnsource = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnid_class = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnClass = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnid_color = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumncolor = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumndescription = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnbenchmark = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnQty = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumntarget_cost = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumntarget_price = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnmark_up = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumntotal_cost = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumntotal_value = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnis_select = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RepositoryItemCheckEdit1 = New DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit()
        Me.GridColumnGroup = New DevExpress.XtraGrid.Columns.GridColumn()
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl1.SuspendLayout()
        CType(Me.PanelControlNav, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControlNav.SuspendLayout()
        CType(Me.SLESeason.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SearchLookUpEdit1View, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CESelectAll.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GCData, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ContextMenuStrip1.SuspendLayout()
        CType(Me.GVData, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemCheckEdit1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PanelControl1
        '
        Me.PanelControl1.Controls.Add(Me.PanelControlNav)
        Me.PanelControl1.Controls.Add(Me.CESelectAll)
        Me.PanelControl1.Controls.Add(Me.BtnView)
        Me.PanelControl1.Controls.Add(Me.BtnImport)
        Me.PanelControl1.Dock = System.Windows.Forms.DockStyle.Top
        Me.PanelControl1.Location = New System.Drawing.Point(0, 0)
        Me.PanelControl1.Name = "PanelControl1"
        Me.PanelControl1.Size = New System.Drawing.Size(847, 44)
        Me.PanelControl1.TabIndex = 1
        '
        'PanelControlNav
        '
        Me.PanelControlNav.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
        Me.PanelControlNav.Controls.Add(Me.SLESeason)
        Me.PanelControlNav.Controls.Add(Me.LabelControl1)
        Me.PanelControlNav.Dock = System.Windows.Forms.DockStyle.Right
        Me.PanelControlNav.Location = New System.Drawing.Point(345, 2)
        Me.PanelControlNav.Name = "PanelControlNav"
        Me.PanelControlNav.Size = New System.Drawing.Size(291, 40)
        Me.PanelControlNav.TabIndex = 8915
        '
        'SLESeason
        '
        Me.SLESeason.Location = New System.Drawing.Point(98, 10)
        Me.SLESeason.Name = "SLESeason"
        Me.SLESeason.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SLESeason.Properties.Appearance.Options.UseFont = True
        Me.SLESeason.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.SLESeason.Properties.ShowClearButton = False
        Me.SLESeason.Properties.View = Me.SearchLookUpEdit1View
        Me.SLESeason.Size = New System.Drawing.Size(187, 20)
        Me.SLESeason.TabIndex = 8910
        '
        'SearchLookUpEdit1View
        '
        Me.SearchLookUpEdit1View.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumn6, Me.GridColumn8, Me.GridColumn3})
        Me.SearchLookUpEdit1View.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
        Me.SearchLookUpEdit1View.Name = "SearchLookUpEdit1View"
        Me.SearchLookUpEdit1View.OptionsSelection.EnableAppearanceFocusedCell = False
        Me.SearchLookUpEdit1View.OptionsView.ShowGroupPanel = False
        '
        'GridColumn6
        '
        Me.GridColumn6.Caption = "Id Season"
        Me.GridColumn6.FieldName = "id_season"
        Me.GridColumn6.Name = "GridColumn6"
        '
        'GridColumn8
        '
        Me.GridColumn8.Caption = "Season"
        Me.GridColumn8.FieldName = "season"
        Me.GridColumn8.Name = "GridColumn8"
        Me.GridColumn8.Visible = True
        Me.GridColumn8.VisibleIndex = 1
        '
        'GridColumn3
        '
        Me.GridColumn3.Caption = "Range"
        Me.GridColumn3.FieldName = "range"
        Me.GridColumn3.Name = "GridColumn3"
        Me.GridColumn3.Visible = True
        Me.GridColumn3.VisibleIndex = 0
        '
        'LabelControl1
        '
        Me.LabelControl1.Location = New System.Drawing.Point(57, 13)
        Me.LabelControl1.Name = "LabelControl1"
        Me.LabelControl1.Size = New System.Drawing.Size(35, 13)
        Me.LabelControl1.TabIndex = 8909
        Me.LabelControl1.Text = "Season"
        '
        'CESelectAll
        '
        Me.CESelectAll.Location = New System.Drawing.Point(12, 12)
        Me.CESelectAll.Name = "CESelectAll"
        Me.CESelectAll.Properties.Caption = "Select All"
        Me.CESelectAll.Size = New System.Drawing.Size(75, 19)
        Me.CESelectAll.TabIndex = 2
        '
        'BtnView
        '
        Me.BtnView.Dock = System.Windows.Forms.DockStyle.Right
        Me.BtnView.Image = CType(resources.GetObject("BtnView.Image"), System.Drawing.Image)
        Me.BtnView.Location = New System.Drawing.Point(636, 2)
        Me.BtnView.LookAndFeel.SkinName = "Blue"
        Me.BtnView.Name = "BtnView"
        Me.BtnView.Size = New System.Drawing.Size(83, 40)
        Me.BtnView.TabIndex = 8913
        Me.BtnView.Text = "View"
        '
        'BtnImport
        '
        Me.BtnImport.Dock = System.Windows.Forms.DockStyle.Right
        Me.BtnImport.Image = CType(resources.GetObject("BtnImport.Image"), System.Drawing.Image)
        Me.BtnImport.Location = New System.Drawing.Point(719, 2)
        Me.BtnImport.Name = "BtnImport"
        Me.BtnImport.Size = New System.Drawing.Size(126, 40)
        Me.BtnImport.TabIndex = 8914
        Me.BtnImport.Text = "Import from XLS"
        '
        'GCData
        '
        Me.GCData.ContextMenuStrip = Me.ContextMenuStrip1
        Me.GCData.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCData.Location = New System.Drawing.Point(0, 44)
        Me.GCData.MainView = Me.GVData
        Me.GCData.Name = "GCData"
        Me.GCData.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.RepositoryItemCheckEdit1})
        Me.GCData.Size = New System.Drawing.Size(847, 469)
        Me.GCData.TabIndex = 2
        Me.GCData.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVData})
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.EditToolStripMenuItem, Me.DeleteThisRowToolStripMenuItem})
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(153, 48)
        '
        'EditToolStripMenuItem
        '
        Me.EditToolStripMenuItem.Name = "EditToolStripMenuItem"
        Me.EditToolStripMenuItem.Size = New System.Drawing.Size(152, 22)
        Me.EditToolStripMenuItem.Text = "Edit"
        '
        'DeleteThisRowToolStripMenuItem
        '
        Me.DeleteThisRowToolStripMenuItem.Name = "DeleteThisRowToolStripMenuItem"
        Me.DeleteThisRowToolStripMenuItem.Size = New System.Drawing.Size(152, 22)
        Me.DeleteThisRowToolStripMenuItem.Text = "Delete this row"
        '
        'GVData
        '
        Me.GVData.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumnId, Me.GridColumnid_season, Me.GridColumnseason, Me.GridColumnid_delivery, Me.GridColumndelivery, Me.GridColumnid_division, Me.GridColumndivision, Me.GridColumncategory, Me.GridColumnid_category, Me.GridColumnid_source, Me.GridColumnsource, Me.GridColumnid_class, Me.GridColumnClass, Me.GridColumnid_color, Me.GridColumncolor, Me.GridColumndescription, Me.GridColumnbenchmark, Me.GridColumnQty, Me.GridColumntarget_cost, Me.GridColumntarget_price, Me.GridColumnmark_up, Me.GridColumntotal_cost, Me.GridColumntotal_value, Me.GridColumnis_select, Me.GridColumnGroup})
        Me.GVData.GridControl = Me.GCData
        Me.GVData.GroupCount = 1
        Me.GVData.GroupSummary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "qty", Me.GridColumnQty, "{0:N0}"), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "total_cost", Me.GridColumntotal_cost, "{0:N0}"), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "total_value", Me.GridColumntotal_value, "{0:N0}")})
        Me.GVData.Name = "GVData"
        Me.GVData.OptionsBehavior.AutoExpandAllGroups = True
        Me.GVData.OptionsFind.AlwaysVisible = True
        Me.GVData.OptionsView.ColumnAutoWidth = False
        Me.GVData.OptionsView.ColumnHeaderAutoHeight = DevExpress.Utils.DefaultBoolean.[True]
        Me.GVData.OptionsView.GroupFooterShowMode = DevExpress.XtraGrid.Views.Grid.GroupFooterShowMode.VisibleAlways
        Me.GVData.OptionsView.ShowFooter = True
        Me.GVData.OptionsView.ShowGroupedColumns = True
        Me.GVData.OptionsView.ShowGroupPanel = False
        Me.GVData.SortInfo.AddRange(New DevExpress.XtraGrid.Columns.GridColumnSortInfo() {New DevExpress.XtraGrid.Columns.GridColumnSortInfo(Me.GridColumnGroup, DevExpress.Data.ColumnSortOrder.Ascending)})
        '
        'GridColumnId
        '
        Me.GridColumnId.AppearanceHeader.Options.UseTextOptions = True
        Me.GridColumnId.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
        Me.GridColumnId.Caption = "Id"
        Me.GridColumnId.FieldName = "id_fg_line_plan"
        Me.GridColumnId.Name = "GridColumnId"
        Me.GridColumnId.OptionsColumn.ReadOnly = True
        '
        'GridColumnid_season
        '
        Me.GridColumnid_season.AppearanceHeader.Options.UseTextOptions = True
        Me.GridColumnid_season.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
        Me.GridColumnid_season.Caption = "Id Season"
        Me.GridColumnid_season.FieldName = "id_season"
        Me.GridColumnid_season.Name = "GridColumnid_season"
        Me.GridColumnid_season.OptionsColumn.ReadOnly = True
        '
        'GridColumnseason
        '
        Me.GridColumnseason.AppearanceHeader.Options.UseTextOptions = True
        Me.GridColumnseason.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
        Me.GridColumnseason.Caption = "Season"
        Me.GridColumnseason.FieldName = "season"
        Me.GridColumnseason.Name = "GridColumnseason"
        Me.GridColumnseason.OptionsColumn.ReadOnly = True
        '
        'GridColumnid_delivery
        '
        Me.GridColumnid_delivery.AppearanceHeader.Options.UseTextOptions = True
        Me.GridColumnid_delivery.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
        Me.GridColumnid_delivery.Caption = "Id Del"
        Me.GridColumnid_delivery.FieldName = "id_delivery"
        Me.GridColumnid_delivery.Name = "GridColumnid_delivery"
        Me.GridColumnid_delivery.OptionsColumn.ReadOnly = True
        '
        'GridColumndelivery
        '
        Me.GridColumndelivery.AppearanceHeader.Options.UseTextOptions = True
        Me.GridColumndelivery.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
        Me.GridColumndelivery.Caption = "DEL"
        Me.GridColumndelivery.FieldName = "delivery"
        Me.GridColumndelivery.Name = "GridColumndelivery"
        Me.GridColumndelivery.OptionsColumn.ReadOnly = True
        Me.GridColumndelivery.Visible = True
        Me.GridColumndelivery.VisibleIndex = 4
        Me.GridColumndelivery.Width = 119
        '
        'GridColumnid_division
        '
        Me.GridColumnid_division.AppearanceHeader.Options.UseTextOptions = True
        Me.GridColumnid_division.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
        Me.GridColumnid_division.Caption = "Id Divisi"
        Me.GridColumnid_division.FieldName = "id_division"
        Me.GridColumnid_division.Name = "GridColumnid_division"
        Me.GridColumnid_division.OptionsColumn.ReadOnly = True
        '
        'GridColumndivision
        '
        Me.GridColumndivision.AppearanceHeader.Options.UseTextOptions = True
        Me.GridColumndivision.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
        Me.GridColumndivision.Caption = "SEX"
        Me.GridColumndivision.FieldName = "division"
        Me.GridColumndivision.Name = "GridColumndivision"
        Me.GridColumndivision.OptionsColumn.ReadOnly = True
        Me.GridColumndivision.Visible = True
        Me.GridColumndivision.VisibleIndex = 1
        Me.GridColumndivision.Width = 116
        '
        'GridColumncategory
        '
        Me.GridColumncategory.AppearanceHeader.Options.UseTextOptions = True
        Me.GridColumncategory.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
        Me.GridColumncategory.Caption = "CAT"
        Me.GridColumncategory.FieldName = "category"
        Me.GridColumncategory.Name = "GridColumncategory"
        Me.GridColumncategory.OptionsColumn.ReadOnly = True
        Me.GridColumncategory.Visible = True
        Me.GridColumncategory.VisibleIndex = 2
        Me.GridColumncategory.Width = 116
        '
        'GridColumnid_category
        '
        Me.GridColumnid_category.AppearanceHeader.Options.UseTextOptions = True
        Me.GridColumnid_category.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
        Me.GridColumnid_category.Caption = "Id CAT"
        Me.GridColumnid_category.FieldName = "id_category"
        Me.GridColumnid_category.Name = "GridColumnid_category"
        Me.GridColumnid_category.OptionsColumn.ReadOnly = True
        '
        'GridColumnid_source
        '
        Me.GridColumnid_source.AppearanceHeader.Options.UseTextOptions = True
        Me.GridColumnid_source.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
        Me.GridColumnid_source.Caption = "Id Source"
        Me.GridColumnid_source.FieldName = "id_source"
        Me.GridColumnid_source.Name = "GridColumnid_source"
        Me.GridColumnid_source.OptionsColumn.ReadOnly = True
        '
        'GridColumnsource
        '
        Me.GridColumnsource.AppearanceHeader.Options.UseTextOptions = True
        Me.GridColumnsource.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
        Me.GridColumnsource.Caption = "PROD ORIGIN"
        Me.GridColumnsource.FieldName = "source"
        Me.GridColumnsource.Name = "GridColumnsource"
        Me.GridColumnsource.OptionsColumn.ReadOnly = True
        Me.GridColumnsource.Visible = True
        Me.GridColumnsource.VisibleIndex = 3
        Me.GridColumnsource.Width = 73
        '
        'GridColumnid_class
        '
        Me.GridColumnid_class.AppearanceHeader.Options.UseTextOptions = True
        Me.GridColumnid_class.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
        Me.GridColumnid_class.Caption = "Id Class"
        Me.GridColumnid_class.FieldName = "id_class"
        Me.GridColumnid_class.Name = "GridColumnid_class"
        Me.GridColumnid_class.OptionsColumn.ReadOnly = True
        '
        'GridColumnClass
        '
        Me.GridColumnClass.AppearanceHeader.Options.UseTextOptions = True
        Me.GridColumnClass.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
        Me.GridColumnClass.Caption = "CLASS"
        Me.GridColumnClass.FieldName = "class"
        Me.GridColumnClass.Name = "GridColumnClass"
        Me.GridColumnClass.OptionsColumn.ReadOnly = True
        Me.GridColumnClass.Visible = True
        Me.GridColumnClass.VisibleIndex = 5
        Me.GridColumnClass.Width = 119
        '
        'GridColumnid_color
        '
        Me.GridColumnid_color.AppearanceHeader.Options.UseTextOptions = True
        Me.GridColumnid_color.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
        Me.GridColumnid_color.Caption = "id_color"
        Me.GridColumnid_color.FieldName = "id_color"
        Me.GridColumnid_color.Name = "GridColumnid_color"
        Me.GridColumnid_color.OptionsColumn.ReadOnly = True
        '
        'GridColumncolor
        '
        Me.GridColumncolor.AppearanceHeader.Options.UseTextOptions = True
        Me.GridColumncolor.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
        Me.GridColumncolor.Caption = "COL"
        Me.GridColumncolor.FieldName = "color"
        Me.GridColumncolor.Name = "GridColumncolor"
        Me.GridColumncolor.OptionsColumn.ReadOnly = True
        Me.GridColumncolor.Visible = True
        Me.GridColumncolor.VisibleIndex = 7
        Me.GridColumncolor.Width = 119
        '
        'GridColumndescription
        '
        Me.GridColumndescription.AppearanceHeader.Options.UseTextOptions = True
        Me.GridColumndescription.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
        Me.GridColumndescription.Caption = "DESCRIPTION"
        Me.GridColumndescription.FieldName = "description"
        Me.GridColumndescription.Name = "GridColumndescription"
        Me.GridColumndescription.OptionsColumn.ReadOnly = True
        Me.GridColumndescription.Visible = True
        Me.GridColumndescription.VisibleIndex = 6
        Me.GridColumndescription.Width = 119
        '
        'GridColumnbenchmark
        '
        Me.GridColumnbenchmark.AppearanceHeader.Options.UseTextOptions = True
        Me.GridColumnbenchmark.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
        Me.GridColumnbenchmark.Caption = "BENCHMARK"
        Me.GridColumnbenchmark.FieldName = "benchmark"
        Me.GridColumnbenchmark.Name = "GridColumnbenchmark"
        Me.GridColumnbenchmark.OptionsColumn.ReadOnly = True
        Me.GridColumnbenchmark.Visible = True
        Me.GridColumnbenchmark.VisibleIndex = 8
        Me.GridColumnbenchmark.Width = 119
        '
        'GridColumnQty
        '
        Me.GridColumnQty.AppearanceHeader.Options.UseTextOptions = True
        Me.GridColumnQty.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
        Me.GridColumnQty.Caption = "QTY"
        Me.GridColumnQty.DisplayFormat.FormatString = "N0"
        Me.GridColumnQty.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumnQty.FieldName = "qty"
        Me.GridColumnQty.Name = "GridColumnQty"
        Me.GridColumnQty.OptionsColumn.ReadOnly = True
        Me.GridColumnQty.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "qty", "{0:N0}")})
        Me.GridColumnQty.Visible = True
        Me.GridColumnQty.VisibleIndex = 9
        Me.GridColumnQty.Width = 119
        '
        'GridColumntarget_cost
        '
        Me.GridColumntarget_cost.AppearanceHeader.Options.UseTextOptions = True
        Me.GridColumntarget_cost.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
        Me.GridColumntarget_cost.Caption = "TARGET COST"
        Me.GridColumntarget_cost.DisplayFormat.FormatString = "N2"
        Me.GridColumntarget_cost.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumntarget_cost.FieldName = "target_cost"
        Me.GridColumntarget_cost.Name = "GridColumntarget_cost"
        Me.GridColumntarget_cost.OptionsColumn.ReadOnly = True
        Me.GridColumntarget_cost.UnboundExpression = "[target_price] / [mark_up]"
        Me.GridColumntarget_cost.UnboundType = DevExpress.Data.UnboundColumnType.[Decimal]
        Me.GridColumntarget_cost.Visible = True
        Me.GridColumntarget_cost.VisibleIndex = 10
        Me.GridColumntarget_cost.Width = 119
        '
        'GridColumntarget_price
        '
        Me.GridColumntarget_price.AppearanceHeader.Options.UseTextOptions = True
        Me.GridColumntarget_price.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
        Me.GridColumntarget_price.Caption = "TARGET PRICE"
        Me.GridColumntarget_price.DisplayFormat.FormatString = "N0"
        Me.GridColumntarget_price.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumntarget_price.FieldName = "target_price"
        Me.GridColumntarget_price.Name = "GridColumntarget_price"
        Me.GridColumntarget_price.OptionsColumn.ReadOnly = True
        Me.GridColumntarget_price.Visible = True
        Me.GridColumntarget_price.VisibleIndex = 12
        Me.GridColumntarget_price.Width = 119
        '
        'GridColumnmark_up
        '
        Me.GridColumnmark_up.AppearanceHeader.Options.UseTextOptions = True
        Me.GridColumnmark_up.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
        Me.GridColumnmark_up.Caption = "MARK UP"
        Me.GridColumnmark_up.DisplayFormat.FormatString = "N2"
        Me.GridColumnmark_up.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumnmark_up.FieldName = "mark_up"
        Me.GridColumnmark_up.Name = "GridColumnmark_up"
        Me.GridColumnmark_up.OptionsColumn.ReadOnly = True
        Me.GridColumnmark_up.Visible = True
        Me.GridColumnmark_up.VisibleIndex = 11
        Me.GridColumnmark_up.Width = 119
        '
        'GridColumntotal_cost
        '
        Me.GridColumntotal_cost.AppearanceHeader.Options.UseTextOptions = True
        Me.GridColumntotal_cost.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
        Me.GridColumntotal_cost.Caption = "TOTAL COST"
        Me.GridColumntotal_cost.DisplayFormat.FormatString = "N0"
        Me.GridColumntotal_cost.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumntotal_cost.FieldName = "total_cost"
        Me.GridColumntotal_cost.Name = "GridColumntotal_cost"
        Me.GridColumntotal_cost.OptionsColumn.ReadOnly = True
        Me.GridColumntotal_cost.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "total_cost", "{0:N0}")})
        Me.GridColumntotal_cost.UnboundExpression = "[qty] * [target_cost]"
        Me.GridColumntotal_cost.UnboundType = DevExpress.Data.UnboundColumnType.[Decimal]
        Me.GridColumntotal_cost.Visible = True
        Me.GridColumntotal_cost.VisibleIndex = 13
        Me.GridColumntotal_cost.Width = 119
        '
        'GridColumntotal_value
        '
        Me.GridColumntotal_value.AppearanceHeader.Options.UseTextOptions = True
        Me.GridColumntotal_value.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
        Me.GridColumntotal_value.Caption = "TOTAL VALUE"
        Me.GridColumntotal_value.DisplayFormat.FormatString = "N0"
        Me.GridColumntotal_value.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumntotal_value.FieldName = "total_value"
        Me.GridColumntotal_value.Name = "GridColumntotal_value"
        Me.GridColumntotal_value.OptionsColumn.ReadOnly = True
        Me.GridColumntotal_value.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "total_value", "{0:N0}")})
        Me.GridColumntotal_value.UnboundExpression = "[qty] * [target_price]"
        Me.GridColumntotal_value.UnboundType = DevExpress.Data.UnboundColumnType.[Decimal]
        Me.GridColumntotal_value.Visible = True
        Me.GridColumntotal_value.VisibleIndex = 14
        Me.GridColumntotal_value.Width = 137
        '
        'GridColumnis_select
        '
        Me.GridColumnis_select.AppearanceHeader.Options.UseTextOptions = True
        Me.GridColumnis_select.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridColumnis_select.Caption = "SELECT"
        Me.GridColumnis_select.ColumnEdit = Me.RepositoryItemCheckEdit1
        Me.GridColumnis_select.FieldName = "is_select"
        Me.GridColumnis_select.Name = "GridColumnis_select"
        Me.GridColumnis_select.Visible = True
        Me.GridColumnis_select.VisibleIndex = 0
        '
        'RepositoryItemCheckEdit1
        '
        Me.RepositoryItemCheckEdit1.AutoHeight = False
        Me.RepositoryItemCheckEdit1.Name = "RepositoryItemCheckEdit1"
        Me.RepositoryItemCheckEdit1.ValueChecked = "Yes"
        Me.RepositoryItemCheckEdit1.ValueUnchecked = "No"
        '
        'GridColumnGroup
        '
        Me.GridColumnGroup.Caption = "Group"
        Me.GridColumnGroup.FieldName = "group_row"
        Me.GridColumnGroup.Name = "GridColumnGroup"
        Me.GridColumnGroup.UnboundExpression = "Concat([division], '  ', [category], ' ', [class])"
        Me.GridColumnGroup.UnboundType = DevExpress.Data.UnboundColumnType.[String]
        '
        'FormFGLinePlan
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(847, 513)
        Me.Controls.Add(Me.GCData)
        Me.Controls.Add(Me.PanelControl1)
        Me.MinimizeBox = False
        Me.Name = "FormFGLinePlan"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Line Plan"
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl1.ResumeLayout(False)
        CType(Me.PanelControlNav, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControlNav.ResumeLayout(False)
        Me.PanelControlNav.PerformLayout()
        CType(Me.SLESeason.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SearchLookUpEdit1View, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CESelectAll.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GCData, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ContextMenuStrip1.ResumeLayout(False)
        CType(Me.GVData, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemCheckEdit1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents PanelControl1 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents BtnView As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents SLESeason As DevExpress.XtraEditors.SearchLookUpEdit
    Friend WithEvents SearchLookUpEdit1View As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumn6 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn8 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn3 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents LabelControl1 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents CESelectAll As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents BtnImport As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents GCData As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVData As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents PanelControlNav As DevExpress.XtraEditors.PanelControl
    Friend WithEvents GridColumnId As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnid_season As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnseason As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnid_delivery As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumndelivery As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnid_division As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumndivision As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumncategory As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnid_category As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnid_source As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnsource As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnid_class As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnClass As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnid_color As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumncolor As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumndescription As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnbenchmark As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnQty As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumntarget_cost As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumntarget_price As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnmark_up As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumntotal_cost As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumntotal_value As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnis_select As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents RepositoryItemCheckEdit1 As DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit
    Friend WithEvents GridColumnGroup As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ContextMenuStrip1 As ContextMenuStrip
    Friend WithEvents DeleteThisRowToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents EditToolStripMenuItem As ToolStripMenuItem
End Class
