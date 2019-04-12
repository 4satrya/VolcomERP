<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormSalesOrderSingleV2
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
        Me.PCSelAll = New DevExpress.XtraEditors.PanelControl()
        Me.CheckEditSelAll = New DevExpress.XtraEditors.CheckEdit()
        Me.BtnChoose = New DevExpress.XtraEditors.SimpleButton()
        Me.GCProdList = New DevExpress.XtraGrid.GridControl()
        Me.GVProdList = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumnIdProduct = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnIdDesignPrice = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnDesignCode = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnDesignDisplayName = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnProductCode = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnVendorCode = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnProductOrigin = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnColod = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnClass = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnDivision = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnProdSize = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnDelivery = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnPrice = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnWHStock = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnWHStockRes = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnWHStockAvailbale = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnOrder = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RepositoryItemSpinEdit1 = New DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit()
        Me.GridColumnStoreStock = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnTotalSales = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnIdDesign = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnIdSize = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnSeasonx = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnNote = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnIsSelect = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RepositoryItemCheckEdit1 = New DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit()
        Me.GridColumnPriceType = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnPriceName = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RepositoryItemTextEdit1 = New DevExpress.XtraEditors.Repository.RepositoryItemTextEdit()
        Me.RepositoryItemTextEdit2 = New DevExpress.XtraEditors.Repository.RepositoryItemTextEdit()
        Me.RepositoryItemTextEdit3 = New DevExpress.XtraEditors.Repository.RepositoryItemTextEdit()
        Me.PanelControl2 = New DevExpress.XtraEditors.PanelControl()
        Me.LabelControl2 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl1 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelTotal = New DevExpress.XtraEditors.LabelControl()
        Me.SLESeason = New DevExpress.XtraEditors.SearchLookUpEdit()
        Me.SearchLookUpEdit1View = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumnIdSeason = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnRange = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnSeason = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.LabelControl4 = New DevExpress.XtraEditors.LabelControl()
        Me.BtnView = New DevExpress.XtraEditors.SimpleButton()
        Me.PanelControl3 = New DevExpress.XtraEditors.PanelControl()
        Me.GridColumnIdDesignCat = New DevExpress.XtraGrid.Columns.GridColumn()
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl1.SuspendLayout()
        CType(Me.PCSelAll, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PCSelAll.SuspendLayout()
        CType(Me.CheckEditSelAll.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GCProdList, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVProdList, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemSpinEdit1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemCheckEdit1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemTextEdit1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemTextEdit2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemTextEdit3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PanelControl2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl2.SuspendLayout()
        CType(Me.SLESeason.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SearchLookUpEdit1View, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PanelControl3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl3.SuspendLayout()
        Me.SuspendLayout()
        '
        'PanelControl1
        '
        Me.PanelControl1.Controls.Add(Me.PCSelAll)
        Me.PanelControl1.Controls.Add(Me.BtnChoose)
        Me.PanelControl1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PanelControl1.Location = New System.Drawing.Point(0, 396)
        Me.PanelControl1.LookAndFeel.SkinName = "Blue"
        Me.PanelControl1.LookAndFeel.UseDefaultLookAndFeel = False
        Me.PanelControl1.Name = "PanelControl1"
        Me.PanelControl1.Size = New System.Drawing.Size(995, 35)
        Me.PanelControl1.TabIndex = 102
        '
        'PCSelAll
        '
        Me.PCSelAll.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
        Me.PCSelAll.Controls.Add(Me.CheckEditSelAll)
        Me.PCSelAll.Dock = System.Windows.Forms.DockStyle.Left
        Me.PCSelAll.Location = New System.Drawing.Point(2, 2)
        Me.PCSelAll.Name = "PCSelAll"
        Me.PCSelAll.Size = New System.Drawing.Size(99, 31)
        Me.PCSelAll.TabIndex = 104
        '
        'CheckEditSelAll
        '
        Me.CheckEditSelAll.Location = New System.Drawing.Point(5, 6)
        Me.CheckEditSelAll.Name = "CheckEditSelAll"
        Me.CheckEditSelAll.Properties.Caption = "Select All"
        Me.CheckEditSelAll.Size = New System.Drawing.Size(91, 19)
        Me.CheckEditSelAll.TabIndex = 102
        Me.CheckEditSelAll.Visible = False
        '
        'BtnChoose
        '
        Me.BtnChoose.Dock = System.Windows.Forms.DockStyle.Right
        Me.BtnChoose.Location = New System.Drawing.Point(918, 2)
        Me.BtnChoose.Name = "BtnChoose"
        Me.BtnChoose.Size = New System.Drawing.Size(75, 31)
        Me.BtnChoose.TabIndex = 2
        Me.BtnChoose.Text = "Choose"
        '
        'GCProdList
        '
        Me.GCProdList.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCProdList.Location = New System.Drawing.Point(0, 0)
        Me.GCProdList.MainView = Me.GVProdList
        Me.GCProdList.Name = "GCProdList"
        Me.GCProdList.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.RepositoryItemCheckEdit1, Me.RepositoryItemTextEdit1, Me.RepositoryItemTextEdit2, Me.RepositoryItemTextEdit3, Me.RepositoryItemSpinEdit1})
        Me.GCProdList.Size = New System.Drawing.Size(995, 351)
        Me.GCProdList.TabIndex = 1
        Me.GCProdList.TabStop = False
        Me.GCProdList.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVProdList})
        '
        'GVProdList
        '
        Me.GVProdList.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumnIdProduct, Me.GridColumnIdDesignPrice, Me.GridColumnDesignCode, Me.GridColumnDesignDisplayName, Me.GridColumnProductCode, Me.GridColumnVendorCode, Me.GridColumnProductOrigin, Me.GridColumnColod, Me.GridColumnClass, Me.GridColumnDivision, Me.GridColumnProdSize, Me.GridColumnDelivery, Me.GridColumnPrice, Me.GridColumnWHStock, Me.GridColumnWHStockRes, Me.GridColumnWHStockAvailbale, Me.GridColumnOrder, Me.GridColumnStoreStock, Me.GridColumnTotalSales, Me.GridColumnIdDesign, Me.GridColumnIdSize, Me.GridColumnSeasonx, Me.GridColumnNote, Me.GridColumnIsSelect, Me.GridColumnPriceType, Me.GridColumnPriceName, Me.GridColumnIdDesignCat})
        Me.GVProdList.CustomizationFormBounds = New System.Drawing.Rectangle(908, 397, 216, 178)
        Me.GVProdList.GridControl = Me.GCProdList
        Me.GVProdList.GroupCount = 3
        Me.GVProdList.GroupSummary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "total_stock", Me.GridColumnWHStock, ""), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "total_res", Me.GridColumnWHStockRes, ""), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "total_allow", Me.GridColumnWHStockAvailbale, ""), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "total_order", Me.GridColumnOrder, ""), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "total_stock_store", Me.GridColumnStoreStock, ""), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "total_sales", Me.GridColumnTotalSales, "")})
        Me.GVProdList.Name = "GVProdList"
        Me.GVProdList.OptionsView.ShowGroupPanel = False
        Me.GVProdList.SortInfo.AddRange(New DevExpress.XtraGrid.Columns.GridColumnSortInfo() {New DevExpress.XtraGrid.Columns.GridColumnSortInfo(Me.GridColumnDivision, DevExpress.Data.ColumnSortOrder.Ascending), New DevExpress.XtraGrid.Columns.GridColumnSortInfo(Me.GridColumnClass, DevExpress.Data.ColumnSortOrder.Ascending), New DevExpress.XtraGrid.Columns.GridColumnSortInfo(Me.GridColumnDesignDisplayName, DevExpress.Data.ColumnSortOrder.Ascending), New DevExpress.XtraGrid.Columns.GridColumnSortInfo(Me.GridColumnSeasonx, DevExpress.Data.ColumnSortOrder.Ascending), New DevExpress.XtraGrid.Columns.GridColumnSortInfo(Me.GridColumnIdSize, DevExpress.Data.ColumnSortOrder.Ascending), New DevExpress.XtraGrid.Columns.GridColumnSortInfo(Me.GridColumnProdSize, DevExpress.Data.ColumnSortOrder.Ascending)})
        '
        'GridColumnIdProduct
        '
        Me.GridColumnIdProduct.Caption = "Id Product"
        Me.GridColumnIdProduct.FieldName = "id_product"
        Me.GridColumnIdProduct.Name = "GridColumnIdProduct"
        Me.GridColumnIdProduct.OptionsColumn.AllowEdit = False
        Me.GridColumnIdProduct.OptionsColumn.ShowInCustomizationForm = False
        '
        'GridColumnIdDesignPrice
        '
        Me.GridColumnIdDesignPrice.Caption = "Id Design Price"
        Me.GridColumnIdDesignPrice.FieldName = "id_design_price"
        Me.GridColumnIdDesignPrice.Name = "GridColumnIdDesignPrice"
        Me.GridColumnIdDesignPrice.OptionsColumn.AllowEdit = False
        Me.GridColumnIdDesignPrice.OptionsColumn.ReadOnly = True
        Me.GridColumnIdDesignPrice.OptionsColumn.ShowInCustomizationForm = False
        Me.GridColumnIdDesignPrice.Width = 80
        '
        'GridColumnDesignCode
        '
        Me.GridColumnDesignCode.Caption = "Design Code"
        Me.GridColumnDesignCode.FieldName = "design_code"
        Me.GridColumnDesignCode.Name = "GridColumnDesignCode"
        Me.GridColumnDesignCode.OptionsColumn.AllowEdit = False
        Me.GridColumnDesignCode.OptionsColumn.ReadOnly = True
        '
        'GridColumnDesignDisplayName
        '
        Me.GridColumnDesignDisplayName.Caption = "Design"
        Me.GridColumnDesignDisplayName.FieldName = "design_display_name"
        Me.GridColumnDesignDisplayName.FieldNameSortGroup = "id_design"
        Me.GridColumnDesignDisplayName.Name = "GridColumnDesignDisplayName"
        Me.GridColumnDesignDisplayName.OptionsColumn.AllowEdit = False
        Me.GridColumnDesignDisplayName.OptionsColumn.ReadOnly = True
        '
        'GridColumnProductCode
        '
        Me.GridColumnProductCode.Caption = "Code"
        Me.GridColumnProductCode.FieldName = "product_full_code"
        Me.GridColumnProductCode.Name = "GridColumnProductCode"
        Me.GridColumnProductCode.OptionsColumn.AllowEdit = False
        Me.GridColumnProductCode.OptionsColumn.ReadOnly = True
        Me.GridColumnProductCode.Visible = True
        Me.GridColumnProductCode.VisibleIndex = 0
        Me.GridColumnProductCode.Width = 89
        '
        'GridColumnVendorCode
        '
        Me.GridColumnVendorCode.Caption = "Vendor/UPC Code"
        Me.GridColumnVendorCode.FieldName = "product_ean_code"
        Me.GridColumnVendorCode.Name = "GridColumnVendorCode"
        Me.GridColumnVendorCode.OptionsColumn.AllowEdit = False
        Me.GridColumnVendorCode.OptionsColumn.ReadOnly = True
        Me.GridColumnVendorCode.Width = 95
        '
        'GridColumnProductOrigin
        '
        Me.GridColumnProductOrigin.Caption = "Origin"
        Me.GridColumnProductOrigin.FieldName = "Product Source_display"
        Me.GridColumnProductOrigin.Name = "GridColumnProductOrigin"
        Me.GridColumnProductOrigin.OptionsColumn.AllowEdit = False
        Me.GridColumnProductOrigin.OptionsColumn.ReadOnly = True
        Me.GridColumnProductOrigin.Width = 89
        '
        'GridColumnColod
        '
        Me.GridColumnColod.Caption = "Color"
        Me.GridColumnColod.FieldName = "Color_display"
        Me.GridColumnColod.Name = "GridColumnColod"
        Me.GridColumnColod.OptionsColumn.AllowEdit = False
        Me.GridColumnColod.OptionsColumn.ReadOnly = True
        Me.GridColumnColod.Width = 89
        '
        'GridColumnClass
        '
        Me.GridColumnClass.Caption = "Class"
        Me.GridColumnClass.FieldName = "Product Class_display"
        Me.GridColumnClass.Name = "GridColumnClass"
        Me.GridColumnClass.OptionsColumn.AllowEdit = False
        '
        'GridColumnDivision
        '
        Me.GridColumnDivision.Caption = "Division"
        Me.GridColumnDivision.FieldName = "Product Division_display"
        Me.GridColumnDivision.Name = "GridColumnDivision"
        Me.GridColumnDivision.OptionsColumn.AllowEdit = False
        Me.GridColumnDivision.OptionsColumn.ReadOnly = True
        Me.GridColumnDivision.Width = 89
        '
        'GridColumnProdSize
        '
        Me.GridColumnProdSize.Caption = "Size"
        Me.GridColumnProdSize.FieldName = "Size"
        Me.GridColumnProdSize.FieldNameSortGroup = "id_size"
        Me.GridColumnProdSize.Name = "GridColumnProdSize"
        Me.GridColumnProdSize.OptionsColumn.AllowEdit = False
        Me.GridColumnProdSize.OptionsColumn.ReadOnly = True
        Me.GridColumnProdSize.Visible = True
        Me.GridColumnProdSize.VisibleIndex = 1
        Me.GridColumnProdSize.Width = 89
        '
        'GridColumnDelivery
        '
        Me.GridColumnDelivery.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumnDelivery.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
        Me.GridColumnDelivery.Caption = "Del"
        Me.GridColumnDelivery.FieldName = "delivery"
        Me.GridColumnDelivery.Name = "GridColumnDelivery"
        Me.GridColumnDelivery.OptionsColumn.AllowEdit = False
        Me.GridColumnDelivery.OptionsColumn.ReadOnly = True
        '
        'GridColumnPrice
        '
        Me.GridColumnPrice.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumnPrice.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumnPrice.AppearanceHeader.Options.UseTextOptions = True
        Me.GridColumnPrice.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumnPrice.Caption = "Price"
        Me.GridColumnPrice.DisplayFormat.FormatString = "N2"
        Me.GridColumnPrice.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumnPrice.FieldName = "design_price"
        Me.GridColumnPrice.FieldNameSortGroup = "id_design_price"
        Me.GridColumnPrice.Name = "GridColumnPrice"
        Me.GridColumnPrice.OptionsColumn.AllowEdit = False
        Me.GridColumnPrice.OptionsColumn.ReadOnly = True
        Me.GridColumnPrice.Visible = True
        Me.GridColumnPrice.VisibleIndex = 2
        Me.GridColumnPrice.Width = 89
        '
        'GridColumnWHStock
        '
        Me.GridColumnWHStock.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumnWHStock.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumnWHStock.AppearanceHeader.Options.UseTextOptions = True
        Me.GridColumnWHStock.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumnWHStock.Caption = "WH"
        Me.GridColumnWHStock.FieldName = "total_stock"
        Me.GridColumnWHStock.Name = "GridColumnWHStock"
        Me.GridColumnWHStock.OptionsColumn.AllowEdit = False
        Me.GridColumnWHStock.OptionsColumn.ReadOnly = True
        Me.GridColumnWHStock.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum)})
        Me.GridColumnWHStock.Width = 89
        '
        'GridColumnWHStockRes
        '
        Me.GridColumnWHStockRes.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumnWHStockRes.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumnWHStockRes.AppearanceHeader.Options.UseTextOptions = True
        Me.GridColumnWHStockRes.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumnWHStockRes.Caption = "Reserved"
        Me.GridColumnWHStockRes.FieldName = "total_res"
        Me.GridColumnWHStockRes.Name = "GridColumnWHStockRes"
        Me.GridColumnWHStockRes.OptionsColumn.AllowEdit = False
        Me.GridColumnWHStockRes.OptionsColumn.ReadOnly = True
        Me.GridColumnWHStockRes.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum)})
        Me.GridColumnWHStockRes.Width = 106
        '
        'GridColumnWHStockAvailbale
        '
        Me.GridColumnWHStockAvailbale.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumnWHStockAvailbale.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumnWHStockAvailbale.AppearanceHeader.Options.UseTextOptions = True
        Me.GridColumnWHStockAvailbale.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumnWHStockAvailbale.Caption = "Available"
        Me.GridColumnWHStockAvailbale.FieldName = "total_allow"
        Me.GridColumnWHStockAvailbale.Name = "GridColumnWHStockAvailbale"
        Me.GridColumnWHStockAvailbale.OptionsColumn.AllowEdit = False
        Me.GridColumnWHStockAvailbale.OptionsColumn.ReadOnly = True
        Me.GridColumnWHStockAvailbale.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum)})
        Me.GridColumnWHStockAvailbale.Visible = True
        Me.GridColumnWHStockAvailbale.VisibleIndex = 8
        Me.GridColumnWHStockAvailbale.Width = 101
        '
        'GridColumnOrder
        '
        Me.GridColumnOrder.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumnOrder.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumnOrder.AppearanceHeader.Options.UseTextOptions = True
        Me.GridColumnOrder.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumnOrder.Caption = "Order"
        Me.GridColumnOrder.ColumnEdit = Me.RepositoryItemSpinEdit1
        Me.GridColumnOrder.FieldName = "total_order"
        Me.GridColumnOrder.Name = "GridColumnOrder"
        Me.GridColumnOrder.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum)})
        Me.GridColumnOrder.Visible = True
        Me.GridColumnOrder.VisibleIndex = 9
        Me.GridColumnOrder.Width = 83
        '
        'RepositoryItemSpinEdit1
        '
        Me.RepositoryItemSpinEdit1.AutoHeight = False
        Me.RepositoryItemSpinEdit1.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.RepositoryItemSpinEdit1.IsFloatValue = False
        Me.RepositoryItemSpinEdit1.Mask.EditMask = "N00"
        Me.RepositoryItemSpinEdit1.MaxValue = New Decimal(New Integer() {1316134911, 2328, 0, 0})
        Me.RepositoryItemSpinEdit1.Name = "RepositoryItemSpinEdit1"
        '
        'GridColumnStoreStock
        '
        Me.GridColumnStoreStock.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumnStoreStock.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumnStoreStock.AppearanceHeader.Options.UseTextOptions = True
        Me.GridColumnStoreStock.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumnStoreStock.Caption = "Store"
        Me.GridColumnStoreStock.FieldName = "total_stock_store"
        Me.GridColumnStoreStock.Name = "GridColumnStoreStock"
        Me.GridColumnStoreStock.OptionsColumn.AllowEdit = False
        Me.GridColumnStoreStock.OptionsColumn.ReadOnly = True
        Me.GridColumnStoreStock.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum)})
        Me.GridColumnStoreStock.Visible = True
        Me.GridColumnStoreStock.VisibleIndex = 7
        Me.GridColumnStoreStock.Width = 89
        '
        'GridColumnTotalSales
        '
        Me.GridColumnTotalSales.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumnTotalSales.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumnTotalSales.AppearanceHeader.Options.UseTextOptions = True
        Me.GridColumnTotalSales.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumnTotalSales.Caption = "Sales"
        Me.GridColumnTotalSales.FieldName = "total_sales"
        Me.GridColumnTotalSales.Name = "GridColumnTotalSales"
        Me.GridColumnTotalSales.OptionsColumn.AllowEdit = False
        Me.GridColumnTotalSales.OptionsColumn.ReadOnly = True
        Me.GridColumnTotalSales.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum)})
        Me.GridColumnTotalSales.Visible = True
        Me.GridColumnTotalSales.VisibleIndex = 6
        Me.GridColumnTotalSales.Width = 89
        '
        'GridColumnIdDesign
        '
        Me.GridColumnIdDesign.Caption = "Id_design"
        Me.GridColumnIdDesign.FieldName = "id_design"
        Me.GridColumnIdDesign.Name = "GridColumnIdDesign"
        Me.GridColumnIdDesign.OptionsColumn.AllowEdit = False
        Me.GridColumnIdDesign.OptionsColumn.ShowInCustomizationForm = False
        '
        'GridColumnIdSize
        '
        Me.GridColumnIdSize.Caption = "GridColumn1"
        Me.GridColumnIdSize.FieldName = "id_size"
        Me.GridColumnIdSize.Name = "GridColumnIdSize"
        Me.GridColumnIdSize.OptionsColumn.AllowEdit = False
        Me.GridColumnIdSize.OptionsColumn.ShowInCustomizationForm = False
        '
        'GridColumnSeasonx
        '
        Me.GridColumnSeasonx.Caption = "Season"
        Me.GridColumnSeasonx.FieldName = "season"
        Me.GridColumnSeasonx.FieldNameSortGroup = "id_season"
        Me.GridColumnSeasonx.Name = "GridColumnSeasonx"
        Me.GridColumnSeasonx.OptionsColumn.AllowEdit = False
        Me.GridColumnSeasonx.Visible = True
        Me.GridColumnSeasonx.VisibleIndex = 5
        Me.GridColumnSeasonx.Width = 83
        '
        'GridColumnNote
        '
        Me.GridColumnNote.Caption = "Note"
        Me.GridColumnNote.FieldName = "note"
        Me.GridColumnNote.Name = "GridColumnNote"
        '
        'GridColumnIsSelect
        '
        Me.GridColumnIsSelect.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumnIsSelect.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridColumnIsSelect.AppearanceHeader.Options.UseTextOptions = True
        Me.GridColumnIsSelect.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridColumnIsSelect.Caption = "Select"
        Me.GridColumnIsSelect.ColumnEdit = Me.RepositoryItemCheckEdit1
        Me.GridColumnIsSelect.FieldName = "is_select"
        Me.GridColumnIsSelect.Name = "GridColumnIsSelect"
        Me.GridColumnIsSelect.OptionsColumn.AllowEdit = False
        Me.GridColumnIsSelect.Width = 86
        '
        'RepositoryItemCheckEdit1
        '
        Me.RepositoryItemCheckEdit1.AutoHeight = False
        Me.RepositoryItemCheckEdit1.Name = "RepositoryItemCheckEdit1"
        Me.RepositoryItemCheckEdit1.ValueChecked = "Yes"
        Me.RepositoryItemCheckEdit1.ValueUnchecked = "No"
        '
        'GridColumnPriceType
        '
        Me.GridColumnPriceType.Caption = "Price Type"
        Me.GridColumnPriceType.FieldName = "design_price_type"
        Me.GridColumnPriceType.Name = "GridColumnPriceType"
        Me.GridColumnPriceType.OptionsColumn.AllowEdit = False
        Me.GridColumnPriceType.Visible = True
        Me.GridColumnPriceType.VisibleIndex = 3
        '
        'GridColumnPriceName
        '
        Me.GridColumnPriceName.Caption = "Price Name"
        Me.GridColumnPriceName.FieldName = "design_price_name"
        Me.GridColumnPriceName.Name = "GridColumnPriceName"
        Me.GridColumnPriceName.Visible = True
        Me.GridColumnPriceName.VisibleIndex = 4
        '
        'RepositoryItemTextEdit1
        '
        Me.RepositoryItemTextEdit1.AutoHeight = False
        Me.RepositoryItemTextEdit1.DisplayFormat.FormatString = "dd MMMM yyyy"
        Me.RepositoryItemTextEdit1.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.RepositoryItemTextEdit1.Mask.EditMask = "dd MMMM yyyy"
        Me.RepositoryItemTextEdit1.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTime
        Me.RepositoryItemTextEdit1.Name = "RepositoryItemTextEdit1"
        Me.RepositoryItemTextEdit1.NullText = "-"
        Me.RepositoryItemTextEdit1.ReadOnly = True
        '
        'RepositoryItemTextEdit2
        '
        Me.RepositoryItemTextEdit2.AutoHeight = False
        Me.RepositoryItemTextEdit2.Mask.EditMask = "dd MMMM yyyy"
        Me.RepositoryItemTextEdit2.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTime
        Me.RepositoryItemTextEdit2.Name = "RepositoryItemTextEdit2"
        Me.RepositoryItemTextEdit2.NullText = "-"
        '
        'RepositoryItemTextEdit3
        '
        Me.RepositoryItemTextEdit3.AutoHeight = False
        Me.RepositoryItemTextEdit3.Mask.EditMask = "dd MMMM yyyy"
        Me.RepositoryItemTextEdit3.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTime
        Me.RepositoryItemTextEdit3.Name = "RepositoryItemTextEdit3"
        Me.RepositoryItemTextEdit3.NullText = "-"
        '
        'PanelControl2
        '
        Me.PanelControl2.Controls.Add(Me.LabelControl2)
        Me.PanelControl2.Controls.Add(Me.LabelControl1)
        Me.PanelControl2.Controls.Add(Me.LabelTotal)
        Me.PanelControl2.Controls.Add(Me.SLESeason)
        Me.PanelControl2.Controls.Add(Me.LabelControl4)
        Me.PanelControl2.Controls.Add(Me.BtnView)
        Me.PanelControl2.Dock = System.Windows.Forms.DockStyle.Top
        Me.PanelControl2.Location = New System.Drawing.Point(0, 0)
        Me.PanelControl2.Name = "PanelControl2"
        Me.PanelControl2.Size = New System.Drawing.Size(995, 45)
        Me.PanelControl2.TabIndex = 100
        '
        'LabelControl2
        '
        Me.LabelControl2.Appearance.Font = New System.Drawing.Font("Tahoma", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl2.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.LabelControl2.Dock = System.Windows.Forms.DockStyle.Right
        Me.LabelControl2.Location = New System.Drawing.Point(783, 2)
        Me.LabelControl2.Name = "LabelControl2"
        Me.LabelControl2.Padding = New System.Windows.Forms.Padding(0, 5, 5, 0)
        Me.LabelControl2.Size = New System.Drawing.Size(176, 34)
        Me.LabelControl2.TabIndex = 101
        Me.LabelControl2.Text = "TOTAL ORDER"
        '
        'LabelControl1
        '
        Me.LabelControl1.Appearance.Font = New System.Drawing.Font("Tahoma", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl1.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.LabelControl1.Dock = System.Windows.Forms.DockStyle.Right
        Me.LabelControl1.Location = New System.Drawing.Point(959, 2)
        Me.LabelControl1.Name = "LabelControl1"
        Me.LabelControl1.Padding = New System.Windows.Forms.Padding(0, 5, 5, 0)
        Me.LabelControl1.Size = New System.Drawing.Size(14, 34)
        Me.LabelControl1.TabIndex = 100
        Me.LabelControl1.Text = ":"
        '
        'LabelTotal
        '
        Me.LabelTotal.Appearance.Font = New System.Drawing.Font("Tahoma", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelTotal.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.LabelTotal.Dock = System.Windows.Forms.DockStyle.Right
        Me.LabelTotal.Location = New System.Drawing.Point(973, 2)
        Me.LabelTotal.Name = "LabelTotal"
        Me.LabelTotal.Padding = New System.Windows.Forms.Padding(0, 5, 5, 0)
        Me.LabelTotal.Size = New System.Drawing.Size(20, 34)
        Me.LabelTotal.TabIndex = 99
        Me.LabelTotal.Text = "0"
        '
        'SLESeason
        '
        Me.SLESeason.Location = New System.Drawing.Point(53, 13)
        Me.SLESeason.Name = "SLESeason"
        Me.SLESeason.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SLESeason.Properties.Appearance.Options.UseFont = True
        Me.SLESeason.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.SLESeason.Properties.View = Me.SearchLookUpEdit1View
        Me.SLESeason.Size = New System.Drawing.Size(191, 20)
        Me.SLESeason.TabIndex = 0
        '
        'SearchLookUpEdit1View
        '
        Me.SearchLookUpEdit1View.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumnIdSeason, Me.GridColumnRange, Me.GridColumnSeason})
        Me.SearchLookUpEdit1View.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
        Me.SearchLookUpEdit1View.Name = "SearchLookUpEdit1View"
        Me.SearchLookUpEdit1View.OptionsSelection.EnableAppearanceFocusedCell = False
        Me.SearchLookUpEdit1View.OptionsView.ShowGroupPanel = False
        '
        'GridColumnIdSeason
        '
        Me.GridColumnIdSeason.Caption = "Id Season"
        Me.GridColumnIdSeason.FieldName = "id_season"
        Me.GridColumnIdSeason.Name = "GridColumnIdSeason"
        '
        'GridColumnRange
        '
        Me.GridColumnRange.Caption = "Range"
        Me.GridColumnRange.FieldName = "range"
        Me.GridColumnRange.Name = "GridColumnRange"
        Me.GridColumnRange.Visible = True
        Me.GridColumnRange.VisibleIndex = 0
        '
        'GridColumnSeason
        '
        Me.GridColumnSeason.Caption = "Season"
        Me.GridColumnSeason.FieldName = "season"
        Me.GridColumnSeason.Name = "GridColumnSeason"
        Me.GridColumnSeason.Visible = True
        Me.GridColumnSeason.VisibleIndex = 1
        '
        'LabelControl4
        '
        Me.LabelControl4.Location = New System.Drawing.Point(12, 16)
        Me.LabelControl4.Name = "LabelControl4"
        Me.LabelControl4.Size = New System.Drawing.Size(35, 13)
        Me.LabelControl4.TabIndex = 96
        Me.LabelControl4.Text = "Season"
        '
        'BtnView
        '
        Me.BtnView.Location = New System.Drawing.Point(249, 13)
        Me.BtnView.Name = "BtnView"
        Me.BtnView.Size = New System.Drawing.Size(70, 20)
        Me.BtnView.TabIndex = 1
        Me.BtnView.TabStop = False
        Me.BtnView.Text = "View"
        '
        'PanelControl3
        '
        Me.PanelControl3.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
        Me.PanelControl3.Controls.Add(Me.GCProdList)
        Me.PanelControl3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PanelControl3.Location = New System.Drawing.Point(0, 45)
        Me.PanelControl3.Name = "PanelControl3"
        Me.PanelControl3.Size = New System.Drawing.Size(995, 351)
        Me.PanelControl3.TabIndex = 101
        '
        'GridColumnIdDesignCat
        '
        Me.GridColumnIdDesignCat.Caption = "Id Design Cat"
        Me.GridColumnIdDesignCat.FieldName = "id_design_cat"
        Me.GridColumnIdDesignCat.Name = "GridColumnIdDesignCat"
        Me.GridColumnIdDesignCat.OptionsColumn.AllowEdit = False
        '
        'FormSalesOrderSingleV2
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(995, 431)
        Me.Controls.Add(Me.PanelControl3)
        Me.Controls.Add(Me.PanelControl2)
        Me.Controls.Add(Me.PanelControl1)
        Me.LookAndFeel.SkinName = "Office 2010 Blue"
        Me.LookAndFeel.UseDefaultLookAndFeel = False
        Me.MinimizeBox = False
        Me.Name = "FormSalesOrderSingleV2"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Design List"
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl1.ResumeLayout(False)
        CType(Me.PCSelAll, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PCSelAll.ResumeLayout(False)
        CType(Me.CheckEditSelAll.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GCProdList, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVProdList, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemSpinEdit1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemCheckEdit1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemTextEdit1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemTextEdit2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemTextEdit3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PanelControl2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl2.ResumeLayout(False)
        Me.PanelControl2.PerformLayout()
        CType(Me.SLESeason.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SearchLookUpEdit1View, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PanelControl3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl3.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents PanelControl1 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents PCSelAll As DevExpress.XtraEditors.PanelControl
    Friend WithEvents CheckEditSelAll As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents BtnChoose As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents GCProdList As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVProdList As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumnIdDesignPrice As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnDesignCode As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnDesignDisplayName As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnProductCode As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnVendorCode As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnProductOrigin As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnDivision As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnProdSize As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents RepositoryItemTextEdit1 As DevExpress.XtraEditors.Repository.RepositoryItemTextEdit
    Friend WithEvents RepositoryItemTextEdit2 As DevExpress.XtraEditors.Repository.RepositoryItemTextEdit
    Friend WithEvents RepositoryItemTextEdit3 As DevExpress.XtraEditors.Repository.RepositoryItemTextEdit
    Friend WithEvents GridColumnColod As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnDelivery As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnPrice As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnIsSelect As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents RepositoryItemCheckEdit1 As DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit
    Friend WithEvents PanelControl2 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents BtnView As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents SLESeason As DevExpress.XtraEditors.SearchLookUpEdit
    Friend WithEvents SearchLookUpEdit1View As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumnIdSeason As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnRange As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnSeason As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents LabelControl4 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents GridColumnWHStock As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnWHStockRes As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnWHStockAvailbale As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnOrder As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnStoreStock As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnTotalSales As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnIdDesign As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnClass As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnSeasonx As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnIdSize As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents RepositoryItemSpinEdit1 As DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit
    Friend WithEvents GridColumnNote As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnIdProduct As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnPriceType As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents PanelControl3 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents GridColumnPriceName As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents LabelControl2 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl1 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelTotal As DevExpress.XtraEditors.LabelControl
    Friend WithEvents GridColumnIdDesignCat As DevExpress.XtraGrid.Columns.GridColumn
End Class
