<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormAccountingFakturScan
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
        Dim GridColumncomp As DevExpress.XtraGrid.Columns.GridColumn
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormAccountingFakturScan))
        Me.GCFak = New DevExpress.XtraGrid.GridControl()
        Me.GVFak = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumnId = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn2 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn1 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn3 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn4 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnUpdate = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnFakturDate = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.XTCData = New DevExpress.XtraTab.XtraTabControl()
        Me.XTPList = New DevExpress.XtraTab.XtraTabPage()
        Me.XTPInv = New DevExpress.XtraTab.XtraTabPage()
        Me.GCInv = New DevExpress.XtraGrid.GridControl()
        Me.GVInv = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumnis_select = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RepositoryItemCheckEdit1 = New DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit()
        Me.GridColumnid_sales_pos = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnsales_pos_number = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumncompinv = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnsales_pos_date = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnsales_pos_start_period = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnsales_pos_end_period = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnsales_pos_total_qty = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnsales_pos_total = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnexported_date = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnexported_by_name = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.PanelControl1 = New DevExpress.XtraEditors.PanelControl()
        Me.CESelAll = New DevExpress.XtraEditors.CheckEdit()
        Me.PanelControl2 = New DevExpress.XtraEditors.PanelControl()
        Me.DEUntil = New DevExpress.XtraEditors.DateEdit()
        Me.LabelControl1 = New DevExpress.XtraEditors.LabelControl()
        Me.SLEStore = New DevExpress.XtraEditors.SearchLookUpEdit()
        Me.SearchLookUpEdit1View = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumnid_comp = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumncomp_number = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.LabelControl3 = New DevExpress.XtraEditors.LabelControl()
        Me.DEFrom = New DevExpress.XtraEditors.DateEdit()
        Me.LabelControl2 = New DevExpress.XtraEditors.LabelControl()
        Me.BtnView = New DevExpress.XtraEditors.SimpleButton()
        Me.BtnCreateFaktur = New DevExpress.XtraEditors.SimpleButton()
        GridColumncomp = New DevExpress.XtraGrid.Columns.GridColumn()
        CType(Me.GCFak, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVFak, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.XTCData, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.XTCData.SuspendLayout()
        Me.XTPList.SuspendLayout()
        Me.XTPInv.SuspendLayout()
        CType(Me.GCInv, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVInv, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemCheckEdit1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl1.SuspendLayout()
        CType(Me.CESelAll.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PanelControl2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl2.SuspendLayout()
        CType(Me.DEUntil.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DEUntil.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SLEStore.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SearchLookUpEdit1View, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DEFrom.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DEFrom.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GridColumncomp
        '
        GridColumncomp.Caption = "Account Description"
        GridColumncomp.FieldName = "comp"
        GridColumncomp.Name = "GridColumncomp"
        GridColumncomp.Visible = True
        GridColumncomp.VisibleIndex = 1
        '
        'GCFak
        '
        Me.GCFak.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCFak.Location = New System.Drawing.Point(0, 0)
        Me.GCFak.MainView = Me.GVFak
        Me.GCFak.Name = "GCFak"
        Me.GCFak.Size = New System.Drawing.Size(1185, 434)
        Me.GCFak.TabIndex = 0
        Me.GCFak.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVFak})
        '
        'GVFak
        '
        Me.GVFak.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumnId, Me.GridColumn2, Me.GridColumn1, Me.GridColumn3, Me.GridColumn4, Me.GridColumnUpdate, Me.GridColumnFakturDate})
        Me.GVFak.GridControl = Me.GCFak
        Me.GVFak.Name = "GVFak"
        Me.GVFak.OptionsView.ShowGroupPanel = False
        Me.GVFak.SortInfo.AddRange(New DevExpress.XtraGrid.Columns.GridColumnSortInfo() {New DevExpress.XtraGrid.Columns.GridColumnSortInfo(Me.GridColumnId, DevExpress.Data.ColumnSortOrder.Descending)})
        '
        'GridColumnId
        '
        Me.GridColumnId.Caption = "Id"
        Me.GridColumnId.FieldName = "id_acc_fak_scan"
        Me.GridColumnId.Name = "GridColumnId"
        '
        'GridColumn2
        '
        Me.GridColumn2.Caption = "Period"
        Me.GridColumn2.FieldName = "acc_fak_scan_period"
        Me.GridColumn2.Name = "GridColumn2"
        Me.GridColumn2.Visible = True
        Me.GridColumn2.VisibleIndex = 1
        '
        'GridColumn1
        '
        Me.GridColumn1.Caption = "Created Date"
        Me.GridColumn1.DisplayFormat.FormatString = "dd\/MM\/yyyy"
        Me.GridColumn1.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.GridColumn1.FieldName = "acc_fak_scan_date"
        Me.GridColumn1.Name = "GridColumn1"
        Me.GridColumn1.Visible = True
        Me.GridColumn1.VisibleIndex = 4
        '
        'GridColumn3
        '
        Me.GridColumn3.Caption = "Year"
        Me.GridColumn3.FieldName = "acc_fak_scan_year"
        Me.GridColumn3.Name = "GridColumn3"
        Me.GridColumn3.Visible = True
        Me.GridColumn3.VisibleIndex = 2
        '
        'GridColumn4
        '
        Me.GridColumn4.Caption = "Type"
        Me.GridColumn4.FieldName = "faktur_type"
        Me.GridColumn4.Name = "GridColumn4"
        Me.GridColumn4.Visible = True
        Me.GridColumn4.VisibleIndex = 0
        '
        'GridColumnUpdate
        '
        Me.GridColumnUpdate.Caption = "Updated/Time"
        Me.GridColumnUpdate.DisplayFormat.FormatString = "dd\/MM\/yyyy hh:mm tt"
        Me.GridColumnUpdate.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.GridColumnUpdate.FieldName = "acc_fak_scan_trans_date"
        Me.GridColumnUpdate.Name = "GridColumnUpdate"
        Me.GridColumnUpdate.Visible = True
        Me.GridColumnUpdate.VisibleIndex = 5
        '
        'GridColumnFakturDate
        '
        Me.GridColumnFakturDate.Caption = "Faktur Date"
        Me.GridColumnFakturDate.FieldName = "faktur_date_view"
        Me.GridColumnFakturDate.Name = "GridColumnFakturDate"
        Me.GridColumnFakturDate.Visible = True
        Me.GridColumnFakturDate.VisibleIndex = 3
        '
        'XTCData
        '
        Me.XTCData.Dock = System.Windows.Forms.DockStyle.Fill
        Me.XTCData.HeaderLocation = DevExpress.XtraTab.TabHeaderLocation.Bottom
        Me.XTCData.Location = New System.Drawing.Point(0, 0)
        Me.XTCData.Name = "XTCData"
        Me.XTCData.SelectedTabPage = Me.XTPList
        Me.XTCData.Size = New System.Drawing.Size(1191, 462)
        Me.XTCData.TabIndex = 1
        Me.XTCData.TabPages.AddRange(New DevExpress.XtraTab.XtraTabPage() {Me.XTPList, Me.XTPInv})
        '
        'XTPList
        '
        Me.XTPList.Controls.Add(Me.GCFak)
        Me.XTPList.Name = "XTPList"
        Me.XTPList.Size = New System.Drawing.Size(1185, 434)
        Me.XTPList.Text = "List"
        '
        'XTPInv
        '
        Me.XTPInv.Controls.Add(Me.GCInv)
        Me.XTPInv.Controls.Add(Me.PanelControl1)
        Me.XTPInv.Name = "XTPInv"
        Me.XTPInv.Size = New System.Drawing.Size(1185, 434)
        Me.XTPInv.Text = "Sales Invoice"
        '
        'GCInv
        '
        Me.GCInv.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCInv.Location = New System.Drawing.Point(0, 45)
        Me.GCInv.MainView = Me.GVInv
        Me.GCInv.Name = "GCInv"
        Me.GCInv.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.RepositoryItemCheckEdit1})
        Me.GCInv.Size = New System.Drawing.Size(1185, 389)
        Me.GCInv.TabIndex = 0
        Me.GCInv.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVInv})
        '
        'GVInv
        '
        Me.GVInv.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumnis_select, Me.GridColumnid_sales_pos, Me.GridColumnsales_pos_number, Me.GridColumncompinv, Me.GridColumnsales_pos_date, Me.GridColumnsales_pos_start_period, Me.GridColumnsales_pos_end_period, Me.GridColumnsales_pos_total_qty, Me.GridColumnsales_pos_total, Me.GridColumnexported_date, Me.GridColumnexported_by_name})
        Me.GVInv.GridControl = Me.GCInv
        Me.GVInv.Name = "GVInv"
        Me.GVInv.OptionsBehavior.AutoExpandAllGroups = True
        Me.GVInv.OptionsFind.AlwaysVisible = True
        Me.GVInv.OptionsView.ColumnAutoWidth = False
        Me.GVInv.OptionsView.ShowFooter = True
        Me.GVInv.OptionsView.ShowGroupPanel = False
        '
        'GridColumnis_select
        '
        Me.GridColumnis_select.Caption = "Select"
        Me.GridColumnis_select.ColumnEdit = Me.RepositoryItemCheckEdit1
        Me.GridColumnis_select.FieldName = "is_select"
        Me.GridColumnis_select.Name = "GridColumnis_select"
        Me.GridColumnis_select.Visible = True
        Me.GridColumnis_select.VisibleIndex = 0
        Me.GridColumnis_select.Width = 56
        '
        'RepositoryItemCheckEdit1
        '
        Me.RepositoryItemCheckEdit1.AutoHeight = False
        Me.RepositoryItemCheckEdit1.Name = "RepositoryItemCheckEdit1"
        Me.RepositoryItemCheckEdit1.ValueChecked = "Yes"
        Me.RepositoryItemCheckEdit1.ValueUnchecked = "No"
        '
        'GridColumnid_sales_pos
        '
        Me.GridColumnid_sales_pos.Caption = "id_sales_pos"
        Me.GridColumnid_sales_pos.FieldName = "id_sales_pos"
        Me.GridColumnid_sales_pos.Name = "GridColumnid_sales_pos"
        Me.GridColumnid_sales_pos.OptionsColumn.AllowEdit = False
        Me.GridColumnid_sales_pos.OptionsColumn.ReadOnly = True
        '
        'GridColumnsales_pos_number
        '
        Me.GridColumnsales_pos_number.Caption = "Invoice#"
        Me.GridColumnsales_pos_number.FieldName = "sales_pos_number"
        Me.GridColumnsales_pos_number.Name = "GridColumnsales_pos_number"
        Me.GridColumnsales_pos_number.OptionsColumn.ReadOnly = True
        Me.GridColumnsales_pos_number.Visible = True
        Me.GridColumnsales_pos_number.VisibleIndex = 1
        Me.GridColumnsales_pos_number.Width = 104
        '
        'GridColumncompinv
        '
        Me.GridColumncompinv.Caption = "Store"
        Me.GridColumncompinv.FieldName = "comp"
        Me.GridColumncompinv.Name = "GridColumncompinv"
        Me.GridColumncompinv.OptionsColumn.ReadOnly = True
        Me.GridColumncompinv.Visible = True
        Me.GridColumncompinv.VisibleIndex = 2
        Me.GridColumncompinv.Width = 139
        '
        'GridColumnsales_pos_date
        '
        Me.GridColumnsales_pos_date.Caption = "Created Date"
        Me.GridColumnsales_pos_date.DisplayFormat.FormatString = "dd MMMM yyyy"
        Me.GridColumnsales_pos_date.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.GridColumnsales_pos_date.FieldName = "sales_pos_date"
        Me.GridColumnsales_pos_date.Name = "GridColumnsales_pos_date"
        Me.GridColumnsales_pos_date.OptionsColumn.ReadOnly = True
        Me.GridColumnsales_pos_date.Visible = True
        Me.GridColumnsales_pos_date.VisibleIndex = 3
        Me.GridColumnsales_pos_date.Width = 140
        '
        'GridColumnsales_pos_start_period
        '
        Me.GridColumnsales_pos_start_period.Caption = "Start Period"
        Me.GridColumnsales_pos_start_period.DisplayFormat.FormatString = "dd MMMM yyyy"
        Me.GridColumnsales_pos_start_period.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.GridColumnsales_pos_start_period.FieldName = "sales_pos_start_period"
        Me.GridColumnsales_pos_start_period.Name = "GridColumnsales_pos_start_period"
        Me.GridColumnsales_pos_start_period.OptionsColumn.ReadOnly = True
        Me.GridColumnsales_pos_start_period.Visible = True
        Me.GridColumnsales_pos_start_period.VisibleIndex = 4
        Me.GridColumnsales_pos_start_period.Width = 148
        '
        'GridColumnsales_pos_end_period
        '
        Me.GridColumnsales_pos_end_period.Caption = "End Period"
        Me.GridColumnsales_pos_end_period.DisplayFormat.FormatString = "dd MMMM yyyy"
        Me.GridColumnsales_pos_end_period.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.GridColumnsales_pos_end_period.FieldName = "sales_pos_end_period"
        Me.GridColumnsales_pos_end_period.Name = "GridColumnsales_pos_end_period"
        Me.GridColumnsales_pos_end_period.OptionsColumn.ReadOnly = True
        Me.GridColumnsales_pos_end_period.Visible = True
        Me.GridColumnsales_pos_end_period.VisibleIndex = 5
        Me.GridColumnsales_pos_end_period.Width = 164
        '
        'GridColumnsales_pos_total_qty
        '
        Me.GridColumnsales_pos_total_qty.Caption = "Total Qty"
        Me.GridColumnsales_pos_total_qty.DisplayFormat.FormatString = "N0"
        Me.GridColumnsales_pos_total_qty.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumnsales_pos_total_qty.FieldName = "sales_pos_total_qty"
        Me.GridColumnsales_pos_total_qty.Name = "GridColumnsales_pos_total_qty"
        Me.GridColumnsales_pos_total_qty.OptionsColumn.ReadOnly = True
        Me.GridColumnsales_pos_total_qty.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "sales_pos_total_qty", "{0:N0}")})
        Me.GridColumnsales_pos_total_qty.Visible = True
        Me.GridColumnsales_pos_total_qty.VisibleIndex = 6
        Me.GridColumnsales_pos_total_qty.Width = 865
        '
        'GridColumnsales_pos_total
        '
        Me.GridColumnsales_pos_total.Caption = "Amount"
        Me.GridColumnsales_pos_total.DisplayFormat.FormatString = "N2"
        Me.GridColumnsales_pos_total.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumnsales_pos_total.FieldName = "sales_pos_total"
        Me.GridColumnsales_pos_total.Name = "GridColumnsales_pos_total"
        Me.GridColumnsales_pos_total.OptionsColumn.ReadOnly = True
        Me.GridColumnsales_pos_total.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "sales_pos_total", "{0:N2}")})
        Me.GridColumnsales_pos_total.Visible = True
        Me.GridColumnsales_pos_total.VisibleIndex = 7
        '
        'GridColumnexported_date
        '
        Me.GridColumnexported_date.Caption = "Last Created FK"
        Me.GridColumnexported_date.DisplayFormat.FormatString = "dd MMMM yyyy HH:mm"
        Me.GridColumnexported_date.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.GridColumnexported_date.FieldName = "exported_date"
        Me.GridColumnexported_date.Name = "GridColumnexported_date"
        Me.GridColumnexported_date.Visible = True
        Me.GridColumnexported_date.VisibleIndex = 8
        '
        'GridColumnexported_by_name
        '
        Me.GridColumnexported_by_name.Caption = "Created FK by"
        Me.GridColumnexported_by_name.FieldName = "exported_by_name"
        Me.GridColumnexported_by_name.Name = "GridColumnexported_by_name"
        Me.GridColumnexported_by_name.Visible = True
        Me.GridColumnexported_by_name.VisibleIndex = 9
        '
        'PanelControl1
        '
        Me.PanelControl1.Controls.Add(Me.CESelAll)
        Me.PanelControl1.Controls.Add(Me.PanelControl2)
        Me.PanelControl1.Controls.Add(Me.BtnView)
        Me.PanelControl1.Controls.Add(Me.BtnCreateFaktur)
        Me.PanelControl1.Dock = System.Windows.Forms.DockStyle.Top
        Me.PanelControl1.Location = New System.Drawing.Point(0, 0)
        Me.PanelControl1.Name = "PanelControl1"
        Me.PanelControl1.Size = New System.Drawing.Size(1185, 45)
        Me.PanelControl1.TabIndex = 1
        '
        'CESelAll
        '
        Me.CESelAll.Location = New System.Drawing.Point(11, 13)
        Me.CESelAll.Name = "CESelAll"
        Me.CESelAll.Properties.Caption = "Select All"
        Me.CESelAll.Size = New System.Drawing.Size(75, 19)
        Me.CESelAll.TabIndex = 8903
        '
        'PanelControl2
        '
        Me.PanelControl2.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
        Me.PanelControl2.Controls.Add(Me.DEUntil)
        Me.PanelControl2.Controls.Add(Me.LabelControl1)
        Me.PanelControl2.Controls.Add(Me.SLEStore)
        Me.PanelControl2.Controls.Add(Me.LabelControl3)
        Me.PanelControl2.Controls.Add(Me.DEFrom)
        Me.PanelControl2.Controls.Add(Me.LabelControl2)
        Me.PanelControl2.Dock = System.Windows.Forms.DockStyle.Right
        Me.PanelControl2.Location = New System.Drawing.Point(320, 2)
        Me.PanelControl2.Name = "PanelControl2"
        Me.PanelControl2.Size = New System.Drawing.Size(674, 41)
        Me.PanelControl2.TabIndex = 8902
        '
        'DEUntil
        '
        Me.DEUntil.EditValue = Nothing
        Me.DEUntil.Location = New System.Drawing.Point(238, 11)
        Me.DEUntil.Name = "DEUntil"
        Me.DEUntil.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.[False]
        Me.DEUntil.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.DEUntil.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.DEUntil.Properties.DisplayFormat.FormatString = "dd MMM yyyy"
        Me.DEUntil.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.DEUntil.Properties.Mask.EditMask = "dd\/MM\/yyyy"
        Me.DEUntil.Size = New System.Drawing.Size(138, 20)
        Me.DEUntil.TabIndex = 8897
        '
        'LabelControl1
        '
        Me.LabelControl1.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl1.Location = New System.Drawing.Point(12, 14)
        Me.LabelControl1.Name = "LabelControl1"
        Me.LabelControl1.Size = New System.Drawing.Size(69, 13)
        Me.LabelControl1.TabIndex = 0
        Me.LabelControl1.Text = "Sales Period"
        '
        'SLEStore
        '
        Me.SLEStore.Location = New System.Drawing.Point(419, 11)
        Me.SLEStore.Name = "SLEStore"
        Me.SLEStore.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.SLEStore.Properties.View = Me.SearchLookUpEdit1View
        Me.SLEStore.Size = New System.Drawing.Size(245, 20)
        Me.SLEStore.TabIndex = 8899
        '
        'SearchLookUpEdit1View
        '
        Me.SearchLookUpEdit1View.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumnid_comp, Me.GridColumncomp_number, GridColumncomp})
        Me.SearchLookUpEdit1View.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
        Me.SearchLookUpEdit1View.Name = "SearchLookUpEdit1View"
        Me.SearchLookUpEdit1View.OptionsSelection.EnableAppearanceFocusedCell = False
        Me.SearchLookUpEdit1View.OptionsView.ShowGroupPanel = False
        '
        'GridColumnid_comp
        '
        Me.GridColumnid_comp.Caption = "Id Comp"
        Me.GridColumnid_comp.FieldName = "id_comp"
        Me.GridColumnid_comp.Name = "GridColumnid_comp"
        '
        'GridColumncomp_number
        '
        Me.GridColumncomp_number.Caption = "Account No."
        Me.GridColumncomp_number.FieldName = "comp_number"
        Me.GridColumncomp_number.Name = "GridColumncomp_number"
        Me.GridColumncomp_number.Visible = True
        Me.GridColumncomp_number.VisibleIndex = 0
        '
        'LabelControl3
        '
        Me.LabelControl3.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl3.Location = New System.Drawing.Point(382, 14)
        Me.LabelControl3.Name = "LabelControl3"
        Me.LabelControl3.Size = New System.Drawing.Size(31, 13)
        Me.LabelControl3.TabIndex = 8898
        Me.LabelControl3.Text = "Store"
        '
        'DEFrom
        '
        Me.DEFrom.EditValue = Nothing
        Me.DEFrom.Location = New System.Drawing.Point(91, 11)
        Me.DEFrom.Name = "DEFrom"
        Me.DEFrom.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.[False]
        Me.DEFrom.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.DEFrom.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.DEFrom.Properties.DisplayFormat.FormatString = "dd MMM yyyy"
        Me.DEFrom.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.DEFrom.Properties.Mask.EditMask = "dd\/MM\/yyyy"
        Me.DEFrom.Size = New System.Drawing.Size(138, 20)
        Me.DEFrom.TabIndex = 8895
        '
        'LabelControl2
        '
        Me.LabelControl2.Location = New System.Drawing.Point(231, 14)
        Me.LabelControl2.Name = "LabelControl2"
        Me.LabelControl2.Size = New System.Drawing.Size(4, 13)
        Me.LabelControl2.TabIndex = 8896
        Me.LabelControl2.Text = "-"
        '
        'BtnView
        '
        Me.BtnView.Dock = System.Windows.Forms.DockStyle.Right
        Me.BtnView.Image = CType(resources.GetObject("BtnView.Image"), System.Drawing.Image)
        Me.BtnView.Location = New System.Drawing.Point(994, 2)
        Me.BtnView.Name = "BtnView"
        Me.BtnView.Size = New System.Drawing.Size(91, 41)
        Me.BtnView.TabIndex = 8900
        Me.BtnView.Text = "View"
        '
        'BtnCreateFaktur
        '
        Me.BtnCreateFaktur.Dock = System.Windows.Forms.DockStyle.Right
        Me.BtnCreateFaktur.Enabled = False
        Me.BtnCreateFaktur.Image = CType(resources.GetObject("BtnCreateFaktur.Image"), System.Drawing.Image)
        Me.BtnCreateFaktur.Location = New System.Drawing.Point(1085, 2)
        Me.BtnCreateFaktur.Name = "BtnCreateFaktur"
        Me.BtnCreateFaktur.Size = New System.Drawing.Size(98, 41)
        Me.BtnCreateFaktur.TabIndex = 8901
        Me.BtnCreateFaktur.Text = "Create FK"
        '
        'FormAccountingFakturScan
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1191, 462)
        Me.Controls.Add(Me.XTCData)
        Me.Name = "FormAccountingFakturScan"
        Me.Text = "E-Faktur"
        CType(Me.GCFak, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVFak, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.XTCData, System.ComponentModel.ISupportInitialize).EndInit()
        Me.XTCData.ResumeLayout(False)
        Me.XTPList.ResumeLayout(False)
        Me.XTPInv.ResumeLayout(False)
        CType(Me.GCInv, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVInv, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemCheckEdit1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl1.ResumeLayout(False)
        CType(Me.CESelAll.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PanelControl2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl2.ResumeLayout(False)
        Me.PanelControl2.PerformLayout()
        CType(Me.DEUntil.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DEUntil.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SLEStore.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SearchLookUpEdit1View, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DEFrom.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DEFrom.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents GCFak As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVFak As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumnId As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn1 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn2 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn3 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn4 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnUpdate As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnFakturDate As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents XTCData As DevExpress.XtraTab.XtraTabControl
    Friend WithEvents XTPList As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents XTPInv As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents GCInv As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVInv As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents PanelControl1 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents LabelControl1 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents SLEStore As DevExpress.XtraEditors.SearchLookUpEdit
    Friend WithEvents SearchLookUpEdit1View As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents LabelControl3 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents DEUntil As DevExpress.XtraEditors.DateEdit
    Friend WithEvents LabelControl2 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents DEFrom As DevExpress.XtraEditors.DateEdit
    Friend WithEvents BtnCreateFaktur As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BtnView As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents GridColumnid_comp As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumncomp_number As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents CESelAll As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents PanelControl2 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents GridColumnis_select As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents RepositoryItemCheckEdit1 As DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit
    Friend WithEvents GridColumnid_sales_pos As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnsales_pos_number As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumncompinv As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnsales_pos_date As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnsales_pos_start_period As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnsales_pos_end_period As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnsales_pos_total_qty As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnsales_pos_total As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnexported_date As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnexported_by_name As DevExpress.XtraGrid.Columns.GridColumn
End Class
