<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormProductionClaimReturnBrowsePO
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
        Me.PanelControl1 = New DevExpress.XtraEditors.PanelControl()
        Me.BtnChoose = New DevExpress.XtraEditors.SimpleButton()
        Me.PanelControl2 = New DevExpress.XtraEditors.PanelControl()
        Me.SLEVendor = New DevExpress.XtraEditors.SearchLookUpEdit()
        Me.GridView14 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumn10 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn11 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn12 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.SLESeason = New DevExpress.XtraEditors.SearchLookUpEdit()
        Me.SearchLookUpEdit1View = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumn6 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn8 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.BSearch = New DevExpress.XtraEditors.SimpleButton()
        Me.LabelControl3 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl1 = New DevExpress.XtraEditors.LabelControl()
        Me.SLEDesignStockStore = New DevExpress.XtraEditors.SearchLookUpEdit()
        Me.GVSLEDesgSearch = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumnCodeSearch = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn7 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn9 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.LabelControl9 = New DevExpress.XtraEditors.LabelControl()
        Me.GCProd = New DevExpress.XtraGrid.GridControl()
        Me.GVProd = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumnCompName = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnProdNo = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnReportStatus = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnIdReportStatus = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnProdDate = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnPOType = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnTerm = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnDesignCOP = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnDesign = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnCode = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnOrderQty = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnRecQty = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnPLWHQty = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnIdPO = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnIdSeason = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnSeason = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnIdDelivery = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnDelivery = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn4 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RIPictureEdit = New DevExpress.XtraEditors.Repository.RepositoryItemPictureEdit()
        Me.GridColumnDiff = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn27 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn30 = New DevExpress.XtraGrid.Columns.GridColumn()
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl1.SuspendLayout()
        CType(Me.PanelControl2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl2.SuspendLayout()
        CType(Me.SLEVendor.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView14, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SLESeason.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SearchLookUpEdit1View, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SLEDesignStockStore.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVSLEDesgSearch, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GCProd, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVProd, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RIPictureEdit, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PanelControl1
        '
        Me.PanelControl1.Controls.Add(Me.BtnChoose)
        Me.PanelControl1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PanelControl1.Location = New System.Drawing.Point(0, 425)
        Me.PanelControl1.Name = "PanelControl1"
        Me.PanelControl1.Size = New System.Drawing.Size(834, 41)
        Me.PanelControl1.TabIndex = 0
        '
        'BtnChoose
        '
        Me.BtnChoose.Dock = System.Windows.Forms.DockStyle.Right
        Me.BtnChoose.Location = New System.Drawing.Point(738, 2)
        Me.BtnChoose.Name = "BtnChoose"
        Me.BtnChoose.Size = New System.Drawing.Size(94, 37)
        Me.BtnChoose.TabIndex = 1
        Me.BtnChoose.Text = "Choose"
        '
        'PanelControl2
        '
        Me.PanelControl2.Controls.Add(Me.SLEVendor)
        Me.PanelControl2.Controls.Add(Me.SLESeason)
        Me.PanelControl2.Controls.Add(Me.BSearch)
        Me.PanelControl2.Controls.Add(Me.LabelControl3)
        Me.PanelControl2.Controls.Add(Me.LabelControl1)
        Me.PanelControl2.Controls.Add(Me.SLEDesignStockStore)
        Me.PanelControl2.Controls.Add(Me.LabelControl9)
        Me.PanelControl2.Dock = System.Windows.Forms.DockStyle.Top
        Me.PanelControl2.Location = New System.Drawing.Point(0, 0)
        Me.PanelControl2.Name = "PanelControl2"
        Me.PanelControl2.Size = New System.Drawing.Size(834, 38)
        Me.PanelControl2.TabIndex = 4
        '
        'SLEVendor
        '
        Me.SLEVendor.Location = New System.Drawing.Point(502, 8)
        Me.SLEVendor.Name = "SLEVendor"
        Me.SLEVendor.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SLEVendor.Properties.Appearance.Options.UseFont = True
        Me.SLEVendor.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.SLEVendor.Properties.View = Me.GridView14
        Me.SLEVendor.Size = New System.Drawing.Size(197, 20)
        Me.SLEVendor.TabIndex = 8905
        '
        'GridView14
        '
        Me.GridView14.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumn10, Me.GridColumn11, Me.GridColumn12})
        Me.GridView14.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
        Me.GridView14.Name = "GridView14"
        Me.GridView14.OptionsSelection.EnableAppearanceFocusedCell = False
        Me.GridView14.OptionsView.ShowGroupPanel = False
        '
        'GridColumn10
        '
        Me.GridColumn10.Caption = "Id Comp"
        Me.GridColumn10.FieldName = "id_comp"
        Me.GridColumn10.Name = "GridColumn10"
        '
        'GridColumn11
        '
        Me.GridColumn11.Caption = "Comp Number"
        Me.GridColumn11.FieldName = "comp_number"
        Me.GridColumn11.Name = "GridColumn11"
        Me.GridColumn11.Visible = True
        Me.GridColumn11.VisibleIndex = 0
        Me.GridColumn11.Width = 188
        '
        'GridColumn12
        '
        Me.GridColumn12.Caption = "Comp Name"
        Me.GridColumn12.FieldName = "comp_name"
        Me.GridColumn12.Name = "GridColumn12"
        Me.GridColumn12.Visible = True
        Me.GridColumn12.VisibleIndex = 1
        Me.GridColumn12.Width = 504
        '
        'SLESeason
        '
        Me.SLESeason.Location = New System.Drawing.Point(293, 8)
        Me.SLESeason.Name = "SLESeason"
        Me.SLESeason.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SLESeason.Properties.Appearance.Options.UseFont = True
        Me.SLESeason.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.SLESeason.Properties.View = Me.SearchLookUpEdit1View
        Me.SLESeason.Size = New System.Drawing.Size(163, 20)
        Me.SLESeason.TabIndex = 8904
        '
        'SearchLookUpEdit1View
        '
        Me.SearchLookUpEdit1View.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumn6, Me.GridColumn8})
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
        Me.GridColumn8.VisibleIndex = 0
        '
        'BSearch
        '
        Me.BSearch.Location = New System.Drawing.Point(705, 6)
        Me.BSearch.Name = "BSearch"
        Me.BSearch.Size = New System.Drawing.Size(59, 23)
        Me.BSearch.TabIndex = 8903
        Me.BSearch.Text = "Search"
        '
        'LabelControl3
        '
        Me.LabelControl3.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl3.Location = New System.Drawing.Point(462, 11)
        Me.LabelControl3.Name = "LabelControl3"
        Me.LabelControl3.Size = New System.Drawing.Size(34, 13)
        Me.LabelControl3.TabIndex = 8901
        Me.LabelControl3.Text = "Vendor"
        '
        'LabelControl1
        '
        Me.LabelControl1.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl1.Location = New System.Drawing.Point(252, 11)
        Me.LabelControl1.Name = "LabelControl1"
        Me.LabelControl1.Size = New System.Drawing.Size(35, 13)
        Me.LabelControl1.TabIndex = 8897
        Me.LabelControl1.Text = "Season"
        '
        'SLEDesignStockStore
        '
        Me.SLEDesignStockStore.Location = New System.Drawing.Point(49, 8)
        Me.SLEDesignStockStore.Name = "SLEDesignStockStore"
        Me.SLEDesignStockStore.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.SLEDesignStockStore.Properties.View = Me.GVSLEDesgSearch
        Me.SLEDesignStockStore.Size = New System.Drawing.Size(195, 20)
        Me.SLEDesignStockStore.TabIndex = 8896
        '
        'GVSLEDesgSearch
        '
        Me.GVSLEDesgSearch.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumnCodeSearch, Me.GridColumn7, Me.GridColumn9})
        Me.GVSLEDesgSearch.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
        Me.GVSLEDesgSearch.Name = "GVSLEDesgSearch"
        Me.GVSLEDesgSearch.OptionsSelection.EnableAppearanceFocusedCell = False
        Me.GVSLEDesgSearch.OptionsView.ShowGroupPanel = False
        '
        'GridColumnCodeSearch
        '
        Me.GridColumnCodeSearch.Caption = "Code"
        Me.GridColumnCodeSearch.FieldName = "design_code"
        Me.GridColumnCodeSearch.Name = "GridColumnCodeSearch"
        Me.GridColumnCodeSearch.Visible = True
        Me.GridColumnCodeSearch.VisibleIndex = 0
        Me.GridColumnCodeSearch.Width = 186
        '
        'GridColumn7
        '
        Me.GridColumn7.Caption = "Description"
        Me.GridColumn7.FieldName = "display_name"
        Me.GridColumn7.Name = "GridColumn7"
        Me.GridColumn7.Visible = True
        Me.GridColumn7.VisibleIndex = 1
        Me.GridColumn7.Width = 360
        '
        'GridColumn9
        '
        Me.GridColumn9.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumn9.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridColumn9.AppearanceHeader.Options.UseTextOptions = True
        Me.GridColumn9.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridColumn9.Caption = "Color"
        Me.GridColumn9.FieldName = "color"
        Me.GridColumn9.Name = "GridColumn9"
        Me.GridColumn9.Visible = True
        Me.GridColumn9.VisibleIndex = 2
        Me.GridColumn9.Width = 146
        '
        'LabelControl9
        '
        Me.LabelControl9.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl9.Location = New System.Drawing.Point(11, 11)
        Me.LabelControl9.Name = "LabelControl9"
        Me.LabelControl9.Size = New System.Drawing.Size(32, 13)
        Me.LabelControl9.TabIndex = 8895
        Me.LabelControl9.Text = "Design"
        '
        'GCProd
        '
        Me.GCProd.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCProd.Location = New System.Drawing.Point(0, 38)
        Me.GCProd.MainView = Me.GVProd
        Me.GCProd.Name = "GCProd"
        Me.GCProd.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.RIPictureEdit})
        Me.GCProd.Size = New System.Drawing.Size(834, 387)
        Me.GCProd.TabIndex = 5
        Me.GCProd.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVProd})
        '
        'GVProd
        '
        Me.GVProd.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumnCompName, Me.GridColumnProdNo, Me.GridColumnReportStatus, Me.GridColumnIdReportStatus, Me.GridColumnProdDate, Me.GridColumnPOType, Me.GridColumnTerm, Me.GridColumnDesignCOP, Me.GridColumnDesign, Me.GridColumnCode, Me.GridColumnOrderQty, Me.GridColumnRecQty, Me.GridColumnPLWHQty, Me.GridColumnIdPO, Me.GridColumnIdSeason, Me.GridColumnSeason, Me.GridColumnIdDelivery, Me.GridColumnDelivery, Me.GridColumn4, Me.GridColumnDiff, Me.GridColumn27, Me.GridColumn30})
        Me.GVProd.GridControl = Me.GCProd
        Me.GVProd.GroupCount = 2
        Me.GVProd.Name = "GVProd"
        Me.GVProd.OptionsBehavior.Editable = False
        Me.GVProd.OptionsFind.AlwaysVisible = True
        Me.GVProd.OptionsView.ColumnAutoWidth = False
        Me.GVProd.OptionsView.ShowGroupPanel = False
        Me.GVProd.SortInfo.AddRange(New DevExpress.XtraGrid.Columns.GridColumnSortInfo() {New DevExpress.XtraGrid.Columns.GridColumnSortInfo(Me.GridColumnSeason, DevExpress.Data.ColumnSortOrder.Descending), New DevExpress.XtraGrid.Columns.GridColumnSortInfo(Me.GridColumnDelivery, DevExpress.Data.ColumnSortOrder.Descending), New DevExpress.XtraGrid.Columns.GridColumnSortInfo(Me.GridColumnIdPO, DevExpress.Data.ColumnSortOrder.Descending)})
        '
        'GridColumnCompName
        '
        Me.GridColumnCompName.Caption = "Vendor"
        Me.GridColumnCompName.FieldName = "comp_name"
        Me.GridColumnCompName.Name = "GridColumnCompName"
        Me.GridColumnCompName.Visible = True
        Me.GridColumnCompName.VisibleIndex = 0
        Me.GridColumnCompName.Width = 79
        '
        'GridColumnProdNo
        '
        Me.GridColumnProdNo.Caption = "Number"
        Me.GridColumnProdNo.FieldName = "prod_order_number"
        Me.GridColumnProdNo.Name = "GridColumnProdNo"
        Me.GridColumnProdNo.Visible = True
        Me.GridColumnProdNo.VisibleIndex = 1
        Me.GridColumnProdNo.Width = 74
        '
        'GridColumnReportStatus
        '
        Me.GridColumnReportStatus.Caption = "Status"
        Me.GridColumnReportStatus.FieldName = "report_status"
        Me.GridColumnReportStatus.Name = "GridColumnReportStatus"
        Me.GridColumnReportStatus.Visible = True
        Me.GridColumnReportStatus.VisibleIndex = 7
        Me.GridColumnReportStatus.Width = 106
        '
        'GridColumnIdReportStatus
        '
        Me.GridColumnIdReportStatus.Caption = "Id Report Status"
        Me.GridColumnIdReportStatus.FieldName = "id_report_status"
        Me.GridColumnIdReportStatus.Name = "GridColumnIdReportStatus"
        '
        'GridColumnProdDate
        '
        Me.GridColumnProdDate.Caption = "Date"
        Me.GridColumnProdDate.DisplayFormat.FormatString = "dd MMM yyyy"
        Me.GridColumnProdDate.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.GridColumnProdDate.FieldName = "prod_order_date"
        Me.GridColumnProdDate.Name = "GridColumnProdDate"
        Me.GridColumnProdDate.Visible = True
        Me.GridColumnProdDate.VisibleIndex = 6
        Me.GridColumnProdDate.Width = 78
        '
        'GridColumnPOType
        '
        Me.GridColumnPOType.Caption = "PO Type"
        Me.GridColumnPOType.FieldName = "po_type"
        Me.GridColumnPOType.Name = "GridColumnPOType"
        Me.GridColumnPOType.Visible = True
        Me.GridColumnPOType.VisibleIndex = 4
        Me.GridColumnPOType.Width = 78
        '
        'GridColumnTerm
        '
        Me.GridColumnTerm.Caption = "Term"
        Me.GridColumnTerm.FieldName = "term_production"
        Me.GridColumnTerm.Name = "GridColumnTerm"
        Me.GridColumnTerm.Visible = True
        Me.GridColumnTerm.VisibleIndex = 5
        Me.GridColumnTerm.Width = 78
        '
        'GridColumnDesignCOP
        '
        Me.GridColumnDesignCOP.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumnDesignCOP.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumnDesignCOP.AppearanceHeader.Options.UseTextOptions = True
        Me.GridColumnDesignCOP.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumnDesignCOP.Caption = "Cost Final"
        Me.GridColumnDesignCOP.DisplayFormat.FormatString = "N2"
        Me.GridColumnDesignCOP.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumnDesignCOP.FieldName = "design_cop"
        Me.GridColumnDesignCOP.Name = "GridColumnDesignCOP"
        Me.GridColumnDesignCOP.Visible = True
        Me.GridColumnDesignCOP.VisibleIndex = 12
        '
        'GridColumnDesign
        '
        Me.GridColumnDesign.Caption = "Design"
        Me.GridColumnDesign.FieldName = "design_display_name"
        Me.GridColumnDesign.Name = "GridColumnDesign"
        Me.GridColumnDesign.Visible = True
        Me.GridColumnDesign.VisibleIndex = 2
        Me.GridColumnDesign.Width = 121
        '
        'GridColumnCode
        '
        Me.GridColumnCode.Caption = "Design Code"
        Me.GridColumnCode.FieldName = "design_code"
        Me.GridColumnCode.Name = "GridColumnCode"
        Me.GridColumnCode.Visible = True
        Me.GridColumnCode.VisibleIndex = 3
        Me.GridColumnCode.Width = 78
        '
        'GridColumnOrderQty
        '
        Me.GridColumnOrderQty.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumnOrderQty.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumnOrderQty.AppearanceHeader.Options.UseTextOptions = True
        Me.GridColumnOrderQty.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumnOrderQty.Caption = "Order Qty"
        Me.GridColumnOrderQty.DisplayFormat.FormatString = "N0"
        Me.GridColumnOrderQty.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumnOrderQty.FieldName = "qty_order"
        Me.GridColumnOrderQty.Name = "GridColumnOrderQty"
        Me.GridColumnOrderQty.Visible = True
        Me.GridColumnOrderQty.VisibleIndex = 8
        Me.GridColumnOrderQty.Width = 89
        '
        'GridColumnRecQty
        '
        Me.GridColumnRecQty.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumnRecQty.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumnRecQty.AppearanceHeader.Options.UseTextOptions = True
        Me.GridColumnRecQty.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumnRecQty.Caption = "Received Qty"
        Me.GridColumnRecQty.DisplayFormat.FormatString = "N0"
        Me.GridColumnRecQty.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumnRecQty.FieldName = "qty_rec"
        Me.GridColumnRecQty.Name = "GridColumnRecQty"
        Me.GridColumnRecQty.Visible = True
        Me.GridColumnRecQty.VisibleIndex = 9
        Me.GridColumnRecQty.Width = 96
        '
        'GridColumnPLWHQty
        '
        Me.GridColumnPLWHQty.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumnPLWHQty.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumnPLWHQty.AppearanceHeader.Options.UseTextOptions = True
        Me.GridColumnPLWHQty.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumnPLWHQty.Caption = "PL To WH Qty"
        Me.GridColumnPLWHQty.DisplayFormat.FormatString = "N0"
        Me.GridColumnPLWHQty.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumnPLWHQty.FieldName = "qty_plwh"
        Me.GridColumnPLWHQty.Name = "GridColumnPLWHQty"
        Me.GridColumnPLWHQty.Visible = True
        Me.GridColumnPLWHQty.VisibleIndex = 11
        Me.GridColumnPLWHQty.Width = 85
        '
        'GridColumnIdPO
        '
        Me.GridColumnIdPO.Caption = "ID PO"
        Me.GridColumnIdPO.FieldName = "id_prod_order"
        Me.GridColumnIdPO.Name = "GridColumnIdPO"
        '
        'GridColumnIdSeason
        '
        Me.GridColumnIdSeason.Caption = "Season"
        Me.GridColumnIdSeason.FieldName = "id_season"
        Me.GridColumnIdSeason.Name = "GridColumnIdSeason"
        '
        'GridColumnSeason
        '
        Me.GridColumnSeason.Caption = "Season"
        Me.GridColumnSeason.FieldName = "season"
        Me.GridColumnSeason.FieldNameSortGroup = "id_season"
        Me.GridColumnSeason.Name = "GridColumnSeason"
        '
        'GridColumnIdDelivery
        '
        Me.GridColumnIdDelivery.Caption = "Delivery"
        Me.GridColumnIdDelivery.FieldName = "id_delivery"
        Me.GridColumnIdDelivery.Name = "GridColumnIdDelivery"
        '
        'GridColumnDelivery
        '
        Me.GridColumnDelivery.Caption = "Delivery"
        Me.GridColumnDelivery.FieldName = "delivery"
        Me.GridColumnDelivery.FieldNameSortGroup = "id_delivery"
        Me.GridColumnDelivery.Name = "GridColumnDelivery"
        '
        'GridColumn4
        '
        Me.GridColumn4.Caption = "Picture"
        Me.GridColumn4.ColumnEdit = Me.RIPictureEdit
        Me.GridColumn4.FieldName = "images"
        Me.GridColumn4.Name = "GridColumn4"
        Me.GridColumn4.Width = 100
        '
        'RIPictureEdit
        '
        Me.RIPictureEdit.Name = "RIPictureEdit"
        Me.RIPictureEdit.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Stretch
        '
        'GridColumnDiff
        '
        Me.GridColumnDiff.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumnDiff.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumnDiff.AppearanceHeader.Options.UseTextOptions = True
        Me.GridColumnDiff.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumnDiff.Caption = "Different"
        Me.GridColumnDiff.DisplayFormat.FormatString = "N0"
        Me.GridColumnDiff.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumnDiff.FieldName = "GridColumnDiff"
        Me.GridColumnDiff.Name = "GridColumnDiff"
        Me.GridColumnDiff.UnboundExpression = "[qty_rec] - [qty_order]"
        Me.GridColumnDiff.UnboundType = DevExpress.Data.UnboundColumnType.[Integer]
        Me.GridColumnDiff.Visible = True
        Me.GridColumnDiff.VisibleIndex = 10
        '
        'GridColumn27
        '
        Me.GridColumn27.Caption = "Submitted"
        Me.GridColumn27.FieldName = "is_submit"
        Me.GridColumn27.Name = "GridColumn27"
        Me.GridColumn27.Visible = True
        Me.GridColumn27.VisibleIndex = 13
        '
        'GridColumn30
        '
        Me.GridColumn30.Caption = "Last Mark"
        Me.GridColumn30.FieldName = "last_mark"
        Me.GridColumn30.Name = "GridColumn30"
        Me.GridColumn30.Visible = True
        Me.GridColumn30.VisibleIndex = 14
        '
        'FormProductionClaimReturnBrowsePO
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(834, 466)
        Me.Controls.Add(Me.GCProd)
        Me.Controls.Add(Me.PanelControl2)
        Me.Controls.Add(Me.PanelControl1)
        Me.MinimizeBox = False
        Me.Name = "FormProductionClaimReturnBrowsePO"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Select FG. PO"
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl1.ResumeLayout(False)
        CType(Me.PanelControl2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl2.ResumeLayout(False)
        Me.PanelControl2.PerformLayout()
        CType(Me.SLEVendor.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView14, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SLESeason.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SearchLookUpEdit1View, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SLEDesignStockStore.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVSLEDesgSearch, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GCProd, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVProd, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RIPictureEdit, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents PanelControl1 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents BtnChoose As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents PanelControl2 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents SLEVendor As DevExpress.XtraEditors.SearchLookUpEdit
    Friend WithEvents GridView14 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumn10 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn11 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn12 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents SLESeason As DevExpress.XtraEditors.SearchLookUpEdit
    Friend WithEvents SearchLookUpEdit1View As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumn6 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn8 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents BSearch As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents LabelControl3 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl1 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents SLEDesignStockStore As DevExpress.XtraEditors.SearchLookUpEdit
    Friend WithEvents GVSLEDesgSearch As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumnCodeSearch As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn7 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn9 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents LabelControl9 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents GCProd As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVProd As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumnCompName As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnProdNo As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnReportStatus As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnIdReportStatus As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnProdDate As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnPOType As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnTerm As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnDesignCOP As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnDesign As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnCode As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnOrderQty As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnRecQty As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnPLWHQty As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnIdPO As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnIdSeason As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnSeason As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnIdDelivery As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnDelivery As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn4 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents RIPictureEdit As DevExpress.XtraEditors.Repository.RepositoryItemPictureEdit
    Friend WithEvents GridColumnDiff As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn27 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn30 As DevExpress.XtraGrid.Columns.GridColumn
End Class
