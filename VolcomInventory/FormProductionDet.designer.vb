<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormProductionDet
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormProductionDet))
        Me.EPProdOrder = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.LargeImageCollection = New DevExpress.Utils.ImageCollection(Me.components)
        Me.XTCPageProduction = New DevExpress.XtraTab.XtraTabControl()
        Me.XTPProdOrder = New DevExpress.XtraTab.XtraTabPage()
        Me.GConListPurchase = New DevExpress.XtraEditors.GroupControl()
        Me.XTCDetailPO = New DevExpress.XtraTab.XtraTabControl()
        Me.XTPListItem = New DevExpress.XtraTab.XtraTabPage()
        Me.GCListProduct = New DevExpress.XtraGrid.GridControl()
        Me.GVListProduct = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.ColIdPurcDet = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.ColIdMat = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.ColNo = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.ColCode = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnUPC = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.ColName = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.ColPrice = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.ColQty = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.ColSubtotal = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.ColNote = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.ColColor = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.ColSize = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnBOM = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.BEBOM = New DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit()
        Me.GridColumn3 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn4 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.SLEBOMName = New DevExpress.XtraEditors.Repository.RepositoryItemSearchLookUpEdit()
        Me.RepositoryItemSearchLookUpEdit1View = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.XTPBOM = New DevExpress.XtraTab.XtraTabPage()
        Me.GCBOM = New DevExpress.XtraGrid.GridControl()
        Me.GVBOM = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumn14 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn18 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn22 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn23 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn24 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.ColTotal = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.Cat = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.ColIDCat = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn25 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnUOM = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn26 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnIsCost = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GroupGeneralFooter = New DevExpress.XtraEditors.GroupControl()
        Me.LabelControl19 = New DevExpress.XtraEditors.LabelControl()
        Me.METotSay = New DevExpress.XtraEditors.MemoEdit()
        Me.LabelControl18 = New DevExpress.XtraEditors.LabelControl()
        Me.MENote = New DevExpress.XtraEditors.MemoEdit()
        Me.GroupControl3 = New DevExpress.XtraEditors.GroupControl()
        Me.BCOP = New DevExpress.XtraEditors.SimpleButton()
        Me.ImgBut = New DevExpress.Utils.ImageCollection(Me.components)
        Me.BtnAttachment = New DevExpress.XtraEditors.SimpleButton()
        Me.DDBPrint = New DevExpress.XtraEditors.DropDownButton()
        Me.PUDD = New DevExpress.XtraBars.PopupMenu(Me.components)
        Me.BarLargeButtonItem1 = New DevExpress.XtraBars.BarLargeButtonItem()
        Me.BarButtonItem2 = New DevExpress.XtraBars.BarButtonItem()
        Me.BMDD = New DevExpress.XtraBars.BarManager(Me.components)
        Me.barDockControlTop = New DevExpress.XtraBars.BarDockControl()
        Me.barDockControlBottom = New DevExpress.XtraBars.BarDockControl()
        Me.barDockControlLeft = New DevExpress.XtraBars.BarDockControl()
        Me.barDockControlRight = New DevExpress.XtraBars.BarDockControl()
        Me.BarButtonItem1 = New DevExpress.XtraBars.BarButtonItem()
        Me.BCancel = New DevExpress.XtraEditors.SimpleButton()
        Me.BSave = New DevExpress.XtraEditors.SimpleButton()
        Me.BMark = New DevExpress.XtraEditors.SimpleButton()
        Me.BPrint = New DevExpress.XtraEditors.SimpleButton()
        Me.GroupGeneralHeader = New DevExpress.XtraEditors.GroupControl()
        Me.LabelControl15 = New DevExpress.XtraEditors.LabelControl()
        Me.TETolerance = New DevExpress.XtraEditors.SpinEdit()
        Me.LabelControl14 = New DevExpress.XtraEditors.LabelControl()
        Me.DEDate = New DevExpress.XtraEditors.DateEdit()
        Me.DERecDate = New DevExpress.XtraEditors.DateEdit()
        Me.LabelControl11 = New DevExpress.XtraEditors.LabelControl()
        Me.TELeadTime = New DevExpress.XtraEditors.SpinEdit()
        Me.LabelControl13 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl10 = New DevExpress.XtraEditors.LabelControl()
        Me.TEDesignCode = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl9 = New DevExpress.XtraEditors.LabelControl()
        Me.LECategory = New DevExpress.XtraEditors.SearchLookUpEdit()
        Me.GridView1 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumn1 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn2 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.LabelControl5 = New DevExpress.XtraEditors.LabelControl()
        Me.BPickPD = New DevExpress.XtraEditors.SimpleButton()
        Me.TEPDNo = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl8 = New DevExpress.XtraEditors.LabelControl()
        Me.TEUSCOde = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl7 = New DevExpress.XtraEditors.LabelControl()
        Me.TEDelivery = New DevExpress.XtraEditors.TextEdit()
        Me.TESeason = New DevExpress.XtraEditors.TextEdit()
        Me.TERange = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl2 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl12 = New DevExpress.XtraEditors.LabelControl()
        Me.LEPOType = New DevExpress.XtraEditors.SearchLookUpEdit()
        Me.GridView3 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.ColIdPOType = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.ColPOType = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.LabelControl6 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl1 = New DevExpress.XtraEditors.LabelControl()
        Me.BPickDesign = New DevExpress.XtraEditors.SimpleButton()
        Me.TEDesign = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl4 = New DevExpress.XtraEditors.LabelControl()
        Me.TEPONumber = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl3 = New DevExpress.XtraEditors.LabelControl()
        Me.XTPWorkOrder = New DevExpress.XtraTab.XtraTabPage()
        Me.GCProdWO = New DevExpress.XtraGrid.GridControl()
        Me.GVProdWO = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.ColIdMatPurchase = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.ColPONumber = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.ColShipFrom = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.ColShipTo = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.ColSamplePurcDate = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.ColRecDate = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.ColDueDate = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.ColPayment = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.ColStatus = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.ColIDStatus = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.ColIdWoType = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.ColWoType = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnProgress = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.PGBProg = New DevExpress.XtraEditors.Repository.RepositoryItemProgressBar()
        Me.GridColumnIsOVHMain = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RCIMainVendor = New DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit()
        Me.PanelControl2 = New DevExpress.XtraEditors.PanelControl()
        Me.Bdel = New DevExpress.XtraEditors.SimpleButton()
        Me.BEditWO = New DevExpress.XtraEditors.SimpleButton()
        Me.BAddWO = New DevExpress.XtraEditors.SimpleButton()
        Me.BProgress = New DevExpress.XtraEditors.SimpleButton()
        Me.BAccount = New DevExpress.XtraEditors.SimpleButton()
        Me.XTPMRS = New DevExpress.XtraTab.XtraTabPage()
        Me.GCMRS = New DevExpress.XtraGrid.GridControl()
        Me.GVMRS = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumnIdMRS = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnIdWO = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnIdCompReqFrom = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnCompReqFrom = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnIdCompReqTo = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnCompReqTo = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnDate = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnStatus = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnWONumber = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnMRSNumber = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnIdReportStatus = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RepositoryItemProgressBar1 = New DevExpress.XtraEditors.Repository.RepositoryItemProgressBar()
        Me.PanelControl1 = New DevExpress.XtraEditors.PanelControl()
        Me.BDeleteMRS = New DevExpress.XtraEditors.SimpleButton()
        Me.BEditMRS = New DevExpress.XtraEditors.SimpleButton()
        Me.BAddMRS = New DevExpress.XtraEditors.SimpleButton()
        Me.PanelControl3 = New DevExpress.XtraEditors.PanelControl()
        Me.MEBOMNote = New DevExpress.XtraEditors.MemoEdit()
        Me.LabelControl16 = New DevExpress.XtraEditors.LabelControl()
        CType(Me.EPProdOrder, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LargeImageCollection, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.XTCPageProduction, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.XTCPageProduction.SuspendLayout()
        Me.XTPProdOrder.SuspendLayout()
        CType(Me.GConListPurchase, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GConListPurchase.SuspendLayout()
        CType(Me.XTCDetailPO, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.XTCDetailPO.SuspendLayout()
        Me.XTPListItem.SuspendLayout()
        CType(Me.GCListProduct, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVListProduct, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BEBOM, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SLEBOMName, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemSearchLookUpEdit1View, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.XTPBOM.SuspendLayout()
        CType(Me.GCBOM, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVBOM, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GroupGeneralFooter, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupGeneralFooter.SuspendLayout()
        CType(Me.METotSay.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.MENote.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GroupControl3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupControl3.SuspendLayout()
        CType(Me.ImgBut, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PUDD, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BMDD, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GroupGeneralHeader, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupGeneralHeader.SuspendLayout()
        CType(Me.TETolerance.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DEDate.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DEDate.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DERecDate.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DERecDate.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TELeadTime.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TEDesignCode.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LECategory.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TEPDNo.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TEUSCOde.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TEDelivery.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TESeason.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TERange.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LEPOType.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TEDesign.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TEPONumber.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.XTPWorkOrder.SuspendLayout()
        CType(Me.GCProdWO, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVProdWO, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PGBProg, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RCIMainVendor, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PanelControl2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl2.SuspendLayout()
        Me.XTPMRS.SuspendLayout()
        CType(Me.GCMRS, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVMRS, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemProgressBar1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl1.SuspendLayout()
        CType(Me.PanelControl3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl3.SuspendLayout()
        CType(Me.MEBOMNote.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'EPProdOrder
        '
        Me.EPProdOrder.ContainerControl = Me
        '
        'LargeImageCollection
        '
        Me.LargeImageCollection.ImageSize = New System.Drawing.Size(24, 24)
        Me.LargeImageCollection.ImageStream = CType(resources.GetObject("LargeImageCollection.ImageStream"), DevExpress.Utils.ImageCollectionStreamer)
        Me.LargeImageCollection.Images.SetKeyName(0, "20_24x24.png")
        Me.LargeImageCollection.Images.SetKeyName(1, "8_24x24.png")
        Me.LargeImageCollection.Images.SetKeyName(2, "23_24x24.png")
        Me.LargeImageCollection.Images.SetKeyName(3, "safari (4).png")
        Me.LargeImageCollection.Images.SetKeyName(4, "31-Document_32x32.png")
        '
        'XTCPageProduction
        '
        Me.XTCPageProduction.Dock = System.Windows.Forms.DockStyle.Fill
        Me.XTCPageProduction.Location = New System.Drawing.Point(0, 0)
        Me.XTCPageProduction.Name = "XTCPageProduction"
        Me.XTCPageProduction.SelectedTabPage = Me.XTPProdOrder
        Me.XTCPageProduction.Size = New System.Drawing.Size(977, 559)
        Me.XTCPageProduction.TabIndex = 55
        Me.XTCPageProduction.TabPages.AddRange(New DevExpress.XtraTab.XtraTabPage() {Me.XTPProdOrder, Me.XTPWorkOrder, Me.XTPMRS})
        '
        'XTPProdOrder
        '
        Me.XTPProdOrder.Controls.Add(Me.GConListPurchase)
        Me.XTPProdOrder.Controls.Add(Me.GroupGeneralFooter)
        Me.XTPProdOrder.Controls.Add(Me.GroupControl3)
        Me.XTPProdOrder.Controls.Add(Me.GroupGeneralHeader)
        Me.XTPProdOrder.Name = "XTPProdOrder"
        Me.XTPProdOrder.Size = New System.Drawing.Size(971, 531)
        Me.XTPProdOrder.Text = "F. G. Purchase Order"
        '
        'GConListPurchase
        '
        Me.GConListPurchase.CaptionLocation = DevExpress.Utils.Locations.Left
        Me.GConListPurchase.Controls.Add(Me.XTCDetailPO)
        Me.GConListPurchase.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GConListPurchase.Location = New System.Drawing.Point(0, 135)
        Me.GConListPurchase.Name = "GConListPurchase"
        Me.GConListPurchase.Size = New System.Drawing.Size(971, 285)
        Me.GConListPurchase.TabIndex = 50
        Me.GConListPurchase.Text = "List Purchase"
        '
        'XTCDetailPO
        '
        Me.XTCDetailPO.Dock = System.Windows.Forms.DockStyle.Fill
        Me.XTCDetailPO.Location = New System.Drawing.Point(20, 2)
        Me.XTCDetailPO.Name = "XTCDetailPO"
        Me.XTCDetailPO.SelectedTabPage = Me.XTPListItem
        Me.XTCDetailPO.Size = New System.Drawing.Size(949, 281)
        Me.XTCDetailPO.TabIndex = 1
        Me.XTCDetailPO.TabPages.AddRange(New DevExpress.XtraTab.XtraTabPage() {Me.XTPListItem, Me.XTPBOM})
        '
        'XTPListItem
        '
        Me.XTPListItem.Controls.Add(Me.GCListProduct)
        Me.XTPListItem.Name = "XTPListItem"
        Me.XTPListItem.Size = New System.Drawing.Size(943, 253)
        Me.XTPListItem.Text = "List Item"
        '
        'GCListProduct
        '
        Me.GCListProduct.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCListProduct.Location = New System.Drawing.Point(0, 0)
        Me.GCListProduct.MainView = Me.GVListProduct
        Me.GCListProduct.Margin = New System.Windows.Forms.Padding(0)
        Me.GCListProduct.Name = "GCListProduct"
        Me.GCListProduct.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.SLEBOMName, Me.BEBOM})
        Me.GCListProduct.Size = New System.Drawing.Size(943, 253)
        Me.GCListProduct.TabIndex = 0
        Me.GCListProduct.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVListProduct})
        '
        'GVListProduct
        '
        Me.GVListProduct.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.ColIdPurcDet, Me.ColIdMat, Me.ColNo, Me.ColCode, Me.GridColumnUPC, Me.ColName, Me.ColPrice, Me.ColQty, Me.ColSubtotal, Me.ColNote, Me.ColColor, Me.ColSize, Me.GridColumnBOM, Me.GridColumn3, Me.GridColumn4})
        Me.GVListProduct.CustomizationFormBounds = New System.Drawing.Rectangle(804, 409, 216, 178)
        Me.GVListProduct.GridControl = Me.GCListProduct
        Me.GVListProduct.HorzScrollVisibility = DevExpress.XtraGrid.Views.Base.ScrollVisibility.Never
        Me.GVListProduct.Name = "GVListProduct"
        Me.GVListProduct.OptionsView.ShowFooter = True
        Me.GVListProduct.OptionsView.ShowGroupPanel = False
        '
        'ColIdPurcDet
        '
        Me.ColIdPurcDet.Caption = "ID Prod Order Det"
        Me.ColIdPurcDet.FieldName = "id_prod_order_det"
        Me.ColIdPurcDet.Name = "ColIdPurcDet"
        Me.ColIdPurcDet.OptionsColumn.AllowEdit = False
        '
        'ColIdMat
        '
        Me.ColIdMat.Caption = "Id Prod Demand Product"
        Me.ColIdMat.FieldName = "id_prod_demand_product"
        Me.ColIdMat.Name = "ColIdMat"
        Me.ColIdMat.OptionsColumn.AllowEdit = False
        '
        'ColNo
        '
        Me.ColNo.AppearanceCell.Options.UseTextOptions = True
        Me.ColNo.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.ColNo.AppearanceHeader.Options.UseTextOptions = True
        Me.ColNo.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.ColNo.Caption = "No."
        Me.ColNo.FieldName = "no"
        Me.ColNo.Name = "ColNo"
        Me.ColNo.OptionsColumn.AllowEdit = False
        Me.ColNo.Visible = True
        Me.ColNo.VisibleIndex = 0
        Me.ColNo.Width = 30
        '
        'ColCode
        '
        Me.ColCode.Caption = "Code"
        Me.ColCode.FieldName = "code"
        Me.ColCode.Name = "ColCode"
        Me.ColCode.OptionsColumn.AllowEdit = False
        Me.ColCode.Visible = True
        Me.ColCode.VisibleIndex = 1
        Me.ColCode.Width = 140
        '
        'GridColumnUPC
        '
        Me.GridColumnUPC.Caption = "UPC"
        Me.GridColumnUPC.FieldName = "ean_code"
        Me.GridColumnUPC.Name = "GridColumnUPC"
        Me.GridColumnUPC.Visible = True
        Me.GridColumnUPC.VisibleIndex = 4
        '
        'ColName
        '
        Me.ColName.Caption = "Description"
        Me.ColName.FieldName = "name"
        Me.ColName.Name = "ColName"
        Me.ColName.OptionsColumn.AllowEdit = False
        Me.ColName.Visible = True
        Me.ColName.VisibleIndex = 2
        Me.ColName.Width = 235
        '
        'ColPrice
        '
        Me.ColPrice.AppearanceCell.Options.UseTextOptions = True
        Me.ColPrice.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.ColPrice.AppearanceHeader.Options.UseTextOptions = True
        Me.ColPrice.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.ColPrice.Caption = "Unit Cost"
        Me.ColPrice.DisplayFormat.FormatString = "N2"
        Me.ColPrice.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.ColPrice.FieldName = "estimate_cost"
        Me.ColPrice.Name = "ColPrice"
        Me.ColPrice.OptionsColumn.AllowEdit = False
        Me.ColPrice.Width = 140
        '
        'ColQty
        '
        Me.ColQty.AppearanceCell.Options.UseTextOptions = True
        Me.ColQty.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.ColQty.AppearanceHeader.Options.UseTextOptions = True
        Me.ColQty.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.ColQty.Caption = "Qty"
        Me.ColQty.DisplayFormat.FormatString = "{0:N2}"
        Me.ColQty.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.ColQty.FieldName = "prod_order_qty"
        Me.ColQty.Name = "ColQty"
        Me.ColQty.OptionsColumn.AllowEdit = False
        Me.ColQty.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "prod_order_qty", "{0:N2}")})
        Me.ColQty.Visible = True
        Me.ColQty.VisibleIndex = 6
        Me.ColQty.Width = 68
        '
        'ColSubtotal
        '
        Me.ColSubtotal.AppearanceCell.Options.UseTextOptions = True
        Me.ColSubtotal.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.ColSubtotal.AppearanceHeader.Options.UseTextOptions = True
        Me.ColSubtotal.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.ColSubtotal.Caption = "Sub Total"
        Me.ColSubtotal.DisplayFormat.FormatString = "N2"
        Me.ColSubtotal.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.ColSubtotal.FieldName = "total_cost"
        Me.ColSubtotal.Name = "ColSubtotal"
        Me.ColSubtotal.OptionsColumn.AllowEdit = False
        Me.ColSubtotal.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "total_cost", "{0:N2}")})
        Me.ColSubtotal.Width = 165
        '
        'ColNote
        '
        Me.ColNote.Caption = "Note"
        Me.ColNote.FieldName = "note"
        Me.ColNote.Name = "ColNote"
        Me.ColNote.Visible = True
        Me.ColNote.VisibleIndex = 7
        '
        'ColColor
        '
        Me.ColColor.AppearanceCell.Options.UseTextOptions = True
        Me.ColColor.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.ColColor.AppearanceHeader.Options.UseTextOptions = True
        Me.ColColor.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.ColColor.Caption = "Color"
        Me.ColColor.FieldName = "color"
        Me.ColColor.Name = "ColColor"
        Me.ColColor.OptionsColumn.AllowEdit = False
        Me.ColColor.Visible = True
        Me.ColColor.VisibleIndex = 3
        '
        'ColSize
        '
        Me.ColSize.AppearanceCell.Options.UseTextOptions = True
        Me.ColSize.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.ColSize.AppearanceHeader.Options.UseTextOptions = True
        Me.ColSize.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.ColSize.Caption = "Size"
        Me.ColSize.FieldName = "size"
        Me.ColSize.Name = "ColSize"
        Me.ColSize.OptionsColumn.AllowEdit = False
        Me.ColSize.Visible = True
        Me.ColSize.VisibleIndex = 5
        '
        'GridColumnBOM
        '
        Me.GridColumnBOM.Caption = "BOM"
        Me.GridColumnBOM.ColumnEdit = Me.BEBOM
        Me.GridColumnBOM.FieldName = "bom_name"
        Me.GridColumnBOM.Name = "GridColumnBOM"
        Me.GridColumnBOM.OptionsColumn.ReadOnly = True
        '
        'BEBOM
        '
        Me.BEBOM.AutoHeight = False
        Me.BEBOM.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.BEBOM.Name = "BEBOM"
        '
        'GridColumn3
        '
        Me.GridColumn3.Caption = "Id BOM"
        Me.GridColumn3.FieldName = "id_bom"
        Me.GridColumn3.Name = "GridColumn3"
        Me.GridColumn3.OptionsColumn.ReadOnly = True
        '
        'GridColumn4
        '
        Me.GridColumn4.Caption = "Id Product"
        Me.GridColumn4.FieldName = "id_product"
        Me.GridColumn4.Name = "GridColumn4"
        Me.GridColumn4.OptionsColumn.ReadOnly = True
        '
        'SLEBOMName
        '
        Me.SLEBOMName.AutoHeight = False
        Me.SLEBOMName.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.SLEBOMName.Name = "SLEBOMName"
        Me.SLEBOMName.View = Me.RepositoryItemSearchLookUpEdit1View
        '
        'RepositoryItemSearchLookUpEdit1View
        '
        Me.RepositoryItemSearchLookUpEdit1View.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
        Me.RepositoryItemSearchLookUpEdit1View.Name = "RepositoryItemSearchLookUpEdit1View"
        Me.RepositoryItemSearchLookUpEdit1View.OptionsSelection.EnableAppearanceFocusedCell = False
        Me.RepositoryItemSearchLookUpEdit1View.OptionsView.ShowGroupPanel = False
        '
        'XTPBOM
        '
        Me.XTPBOM.Controls.Add(Me.GCBOM)
        Me.XTPBOM.Controls.Add(Me.PanelControl3)
        Me.XTPBOM.Name = "XTPBOM"
        Me.XTPBOM.Size = New System.Drawing.Size(943, 253)
        Me.XTPBOM.Text = "Bill Of Material"
        '
        'GCBOM
        '
        Me.GCBOM.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCBOM.Location = New System.Drawing.Point(0, 0)
        Me.GCBOM.MainView = Me.GVBOM
        Me.GCBOM.Name = "GCBOM"
        Me.GCBOM.Size = New System.Drawing.Size(943, 195)
        Me.GCBOM.TabIndex = 3
        Me.GCBOM.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVBOM})
        '
        'GVBOM
        '
        Me.GVBOM.AppearancePrint.FooterPanel.BackColor = System.Drawing.Color.White
        Me.GVBOM.AppearancePrint.FooterPanel.BackColor2 = System.Drawing.Color.White
        Me.GVBOM.AppearancePrint.FooterPanel.BorderColor = System.Drawing.Color.Transparent
        Me.GVBOM.AppearancePrint.FooterPanel.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.GVBOM.AppearancePrint.FooterPanel.ForeColor = System.Drawing.Color.Black
        Me.GVBOM.AppearancePrint.FooterPanel.Options.UseBackColor = True
        Me.GVBOM.AppearancePrint.FooterPanel.Options.UseBorderColor = True
        Me.GVBOM.AppearancePrint.FooterPanel.Options.UseFont = True
        Me.GVBOM.AppearancePrint.FooterPanel.Options.UseForeColor = True
        Me.GVBOM.AppearancePrint.GroupFooter.BackColor = System.Drawing.Color.White
        Me.GVBOM.AppearancePrint.GroupFooter.BackColor2 = System.Drawing.Color.White
        Me.GVBOM.AppearancePrint.GroupFooter.BorderColor = System.Drawing.Color.Transparent
        Me.GVBOM.AppearancePrint.GroupFooter.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.GVBOM.AppearancePrint.GroupFooter.ForeColor = System.Drawing.Color.Black
        Me.GVBOM.AppearancePrint.GroupFooter.Options.UseBackColor = True
        Me.GVBOM.AppearancePrint.GroupFooter.Options.UseBorderColor = True
        Me.GVBOM.AppearancePrint.GroupFooter.Options.UseFont = True
        Me.GVBOM.AppearancePrint.GroupFooter.Options.UseForeColor = True
        Me.GVBOM.AppearancePrint.GroupRow.BackColor = System.Drawing.Color.White
        Me.GVBOM.AppearancePrint.GroupRow.BackColor2 = System.Drawing.Color.White
        Me.GVBOM.AppearancePrint.GroupRow.BorderColor = System.Drawing.Color.Transparent
        Me.GVBOM.AppearancePrint.GroupRow.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold)
        Me.GVBOM.AppearancePrint.GroupRow.ForeColor = System.Drawing.Color.Black
        Me.GVBOM.AppearancePrint.GroupRow.Options.UseBackColor = True
        Me.GVBOM.AppearancePrint.GroupRow.Options.UseBorderColor = True
        Me.GVBOM.AppearancePrint.GroupRow.Options.UseFont = True
        Me.GVBOM.AppearancePrint.GroupRow.Options.UseForeColor = True
        Me.GVBOM.AppearancePrint.HeaderPanel.BackColor = System.Drawing.Color.White
        Me.GVBOM.AppearancePrint.HeaderPanel.BackColor2 = System.Drawing.Color.White
        Me.GVBOM.AppearancePrint.HeaderPanel.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.GVBOM.AppearancePrint.HeaderPanel.ForeColor = System.Drawing.Color.Black
        Me.GVBOM.AppearancePrint.HeaderPanel.Options.UseBackColor = True
        Me.GVBOM.AppearancePrint.HeaderPanel.Options.UseFont = True
        Me.GVBOM.AppearancePrint.HeaderPanel.Options.UseForeColor = True
        Me.GVBOM.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Office2003
        Me.GVBOM.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumn14, Me.GridColumn18, Me.GridColumn22, Me.GridColumn23, Me.GridColumn24, Me.ColTotal, Me.Cat, Me.ColIDCat, Me.GridColumn25, Me.GridColumnUOM, Me.GridColumn26, Me.GridColumnIsCost})
        Me.GVBOM.GridControl = Me.GCBOM
        Me.GVBOM.GroupCount = 1
        Me.GVBOM.GroupSummary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "total", Me.ColTotal, "{0:N2}"), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Custom, "price", Me.GridColumn24, "Sub Total{0}")})
        Me.GVBOM.Name = "GVBOM"
        Me.GVBOM.OptionsBehavior.Editable = False
        Me.GVBOM.OptionsPrint.PrintVertLines = False
        Me.GVBOM.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never
        Me.GVBOM.OptionsView.ShowFooter = True
        Me.GVBOM.OptionsView.ShowGroupPanel = False
        Me.GVBOM.OptionsView.ShowIndicator = False
        Me.GVBOM.SortInfo.AddRange(New DevExpress.XtraGrid.Columns.GridColumnSortInfo() {New DevExpress.XtraGrid.Columns.GridColumnSortInfo(Me.Cat, DevExpress.Data.ColumnSortOrder.Ascending)})
        '
        'GridColumn14
        '
        Me.GridColumn14.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumn14.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
        Me.GridColumn14.AppearanceHeader.Options.UseTextOptions = True
        Me.GridColumn14.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
        Me.GridColumn14.Caption = "Code"
        Me.GridColumn14.FieldName = "code"
        Me.GridColumn14.Name = "GridColumn14"
        Me.GridColumn14.Visible = True
        Me.GridColumn14.VisibleIndex = 0
        Me.GridColumn14.Width = 152
        '
        'GridColumn18
        '
        Me.GridColumn18.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumn18.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
        Me.GridColumn18.AppearanceHeader.Options.UseTextOptions = True
        Me.GridColumn18.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
        Me.GridColumn18.Caption = "Description"
        Me.GridColumn18.FieldName = "name"
        Me.GridColumn18.Name = "GridColumn18"
        Me.GridColumn18.Visible = True
        Me.GridColumn18.VisibleIndex = 1
        Me.GridColumn18.Width = 295
        '
        'GridColumn22
        '
        Me.GridColumn22.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumn22.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridColumn22.AppearanceHeader.Options.UseTextOptions = True
        Me.GridColumn22.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridColumn22.Caption = "Size"
        Me.GridColumn22.FieldName = "size"
        Me.GridColumn22.Name = "GridColumn22"
        Me.GridColumn22.Visible = True
        Me.GridColumn22.VisibleIndex = 3
        Me.GridColumn22.Width = 57
        '
        'GridColumn23
        '
        Me.GridColumn23.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumn23.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumn23.AppearanceHeader.Options.UseTextOptions = True
        Me.GridColumn23.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumn23.Caption = "Qty"
        Me.GridColumn23.DisplayFormat.FormatString = "N2"
        Me.GridColumn23.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumn23.FieldName = "qty"
        Me.GridColumn23.Name = "GridColumn23"
        Me.GridColumn23.Visible = True
        Me.GridColumn23.VisibleIndex = 4
        Me.GridColumn23.Width = 77
        '
        'GridColumn24
        '
        Me.GridColumn24.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumn24.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumn24.AppearanceHeader.Options.UseTextOptions = True
        Me.GridColumn24.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumn24.Caption = "Cost"
        Me.GridColumn24.DisplayFormat.FormatString = "N2"
        Me.GridColumn24.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumn24.FieldName = "price"
        Me.GridColumn24.Name = "GridColumn24"
        Me.GridColumn24.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Custom, "price", "Total")})
        Me.GridColumn24.Visible = True
        Me.GridColumn24.VisibleIndex = 6
        Me.GridColumn24.Width = 160
        '
        'ColTotal
        '
        Me.ColTotal.AppearanceCell.Options.UseTextOptions = True
        Me.ColTotal.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.ColTotal.AppearanceHeader.Options.UseTextOptions = True
        Me.ColTotal.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.ColTotal.Caption = "Total"
        Me.ColTotal.DisplayFormat.FormatString = "N2"
        Me.ColTotal.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.ColTotal.FieldName = "total"
        Me.ColTotal.Name = "ColTotal"
        Me.ColTotal.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "total", "{0:N2}")})
        Me.ColTotal.Visible = True
        Me.ColTotal.VisibleIndex = 7
        Me.ColTotal.Width = 178
        '
        'Cat
        '
        Me.Cat.Caption = "Category"
        Me.Cat.FieldName = "component_category"
        Me.Cat.FieldNameSortGroup = "id_component_category"
        Me.Cat.Name = "Cat"
        '
        'ColIDCat
        '
        Me.ColIDCat.Caption = "Category"
        Me.ColIDCat.FieldName = "id_component_category"
        Me.ColIDCat.Name = "ColIDCat"
        Me.ColIDCat.Width = 130
        '
        'GridColumn25
        '
        Me.GridColumn25.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumn25.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumn25.AppearanceHeader.Options.UseTextOptions = True
        Me.GridColumn25.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumn25.Caption = "In Stock"
        Me.GridColumn25.DisplayFormat.FormatString = "N2"
        Me.GridColumn25.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumn25.FieldName = "stok"
        Me.GridColumn25.Name = "GridColumn25"
        Me.GridColumn25.Width = 50
        '
        'GridColumnUOM
        '
        Me.GridColumnUOM.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumnUOM.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridColumnUOM.AppearanceHeader.Options.UseTextOptions = True
        Me.GridColumnUOM.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridColumnUOM.Caption = "UOM"
        Me.GridColumnUOM.FieldName = "uom"
        Me.GridColumnUOM.Name = "GridColumnUOM"
        Me.GridColumnUOM.Visible = True
        Me.GridColumnUOM.VisibleIndex = 5
        Me.GridColumnUOM.Width = 69
        '
        'GridColumn26
        '
        Me.GridColumn26.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumn26.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridColumn26.AppearanceHeader.Options.UseTextOptions = True
        Me.GridColumn26.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridColumn26.Caption = "Color"
        Me.GridColumn26.FieldName = "color"
        Me.GridColumn26.Name = "GridColumn26"
        Me.GridColumn26.Visible = True
        Me.GridColumn26.VisibleIndex = 2
        Me.GridColumn26.Width = 78
        '
        'GridColumnIsCost
        '
        Me.GridColumnIsCost.Caption = "COP"
        Me.GridColumnIsCost.FieldName = "is_cost"
        Me.GridColumnIsCost.Name = "GridColumnIsCost"
        '
        'GroupGeneralFooter
        '
        Me.GroupGeneralFooter.CaptionLocation = DevExpress.Utils.Locations.Left
        Me.GroupGeneralFooter.Controls.Add(Me.LabelControl19)
        Me.GroupGeneralFooter.Controls.Add(Me.METotSay)
        Me.GroupGeneralFooter.Controls.Add(Me.LabelControl18)
        Me.GroupGeneralFooter.Controls.Add(Me.MENote)
        Me.GroupGeneralFooter.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.GroupGeneralFooter.Location = New System.Drawing.Point(0, 420)
        Me.GroupGeneralFooter.Name = "GroupGeneralFooter"
        Me.GroupGeneralFooter.Size = New System.Drawing.Size(971, 75)
        Me.GroupGeneralFooter.TabIndex = 51
        '
        'LabelControl19
        '
        Me.LabelControl19.Location = New System.Drawing.Point(569, 11)
        Me.LabelControl19.Name = "LabelControl19"
        Me.LabelControl19.Size = New System.Drawing.Size(18, 13)
        Me.LabelControl19.TabIndex = 140
        Me.LabelControl19.Text = "Say"
        '
        'METotSay
        '
        Me.METotSay.Location = New System.Drawing.Point(606, 9)
        Me.METotSay.Name = "METotSay"
        Me.METotSay.Properties.MaxLength = 100
        Me.METotSay.Properties.ReadOnly = True
        Me.METotSay.Size = New System.Drawing.Size(358, 41)
        Me.METotSay.TabIndex = 139
        '
        'LabelControl18
        '
        Me.LabelControl18.Location = New System.Drawing.Point(27, 11)
        Me.LabelControl18.Name = "LabelControl18"
        Me.LabelControl18.Size = New System.Drawing.Size(23, 13)
        Me.LabelControl18.TabIndex = 138
        Me.LabelControl18.Text = "Note"
        '
        'MENote
        '
        Me.MENote.Location = New System.Drawing.Point(72, 9)
        Me.MENote.Name = "MENote"
        Me.MENote.Properties.MaxLength = 100
        Me.MENote.Size = New System.Drawing.Size(376, 41)
        Me.MENote.TabIndex = 137
        '
        'GroupControl3
        '
        Me.GroupControl3.CaptionLocation = DevExpress.Utils.Locations.Left
        Me.GroupControl3.Controls.Add(Me.BCOP)
        Me.GroupControl3.Controls.Add(Me.BtnAttachment)
        Me.GroupControl3.Controls.Add(Me.DDBPrint)
        Me.GroupControl3.Controls.Add(Me.BCancel)
        Me.GroupControl3.Controls.Add(Me.BSave)
        Me.GroupControl3.Controls.Add(Me.BMark)
        Me.GroupControl3.Controls.Add(Me.BPrint)
        Me.GroupControl3.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.GroupControl3.Location = New System.Drawing.Point(0, 495)
        Me.GroupControl3.Name = "GroupControl3"
        Me.GroupControl3.Size = New System.Drawing.Size(971, 36)
        Me.GroupControl3.TabIndex = 52
        '
        'BCOP
        '
        Me.BCOP.Dock = System.Windows.Forms.DockStyle.Right
        Me.BCOP.ImageIndex = 11
        Me.BCOP.ImageList = Me.ImgBut
        Me.BCOP.Location = New System.Drawing.Point(346, 2)
        Me.BCOP.Name = "BCOP"
        Me.BCOP.Size = New System.Drawing.Size(170, 32)
        Me.BCOP.TabIndex = 5
        Me.BCOP.Text = "Get Cost of Production"
        Me.BCOP.Visible = False
        '
        'ImgBut
        '
        Me.ImgBut.ImageSize = New System.Drawing.Size(24, 24)
        Me.ImgBut.ImageStream = CType(resources.GetObject("ImgBut.ImageStream"), DevExpress.Utils.ImageCollectionStreamer)
        Me.ImgBut.Images.SetKeyName(0, "20_24x24.png")
        Me.ImgBut.Images.SetKeyName(1, "8_24x24.png")
        Me.ImgBut.Images.SetKeyName(2, "23_24x24.png")
        Me.ImgBut.Images.SetKeyName(3, "arrow_refresh.png")
        Me.ImgBut.Images.SetKeyName(4, "check_mark.png")
        Me.ImgBut.Images.SetKeyName(5, "gnome_application_exit (1).png")
        Me.ImgBut.Images.SetKeyName(6, "printer_3.png")
        Me.ImgBut.Images.SetKeyName(7, "save.png")
        Me.ImgBut.Images.SetKeyName(8, "31_24x24.png")
        Me.ImgBut.Images.SetKeyName(9, "18_24x24.png")
        Me.ImgBut.Images.SetKeyName(10, "attachment-icon.png")
        Me.ImgBut.Images.SetKeyName(11, "document_32.png")
        '
        'BtnAttachment
        '
        Me.BtnAttachment.Dock = System.Windows.Forms.DockStyle.Right
        Me.BtnAttachment.ImageIndex = 10
        Me.BtnAttachment.ImageList = Me.ImgBut
        Me.BtnAttachment.Location = New System.Drawing.Point(516, 2)
        Me.BtnAttachment.Name = "BtnAttachment"
        Me.BtnAttachment.Size = New System.Drawing.Size(115, 32)
        Me.BtnAttachment.TabIndex = 15
        Me.BtnAttachment.Text = "Attachment"
        '
        'DDBPrint
        '
        Me.DDBPrint.Dock = System.Windows.Forms.DockStyle.Right
        Me.DDBPrint.DropDownArrowStyle = DevExpress.XtraEditors.DropDownArrowStyle.Show
        Me.DDBPrint.DropDownControl = Me.PUDD
        Me.DDBPrint.ImageIndex = 6
        Me.DDBPrint.ImageList = Me.ImgBut
        Me.DDBPrint.Location = New System.Drawing.Point(631, 2)
        Me.DDBPrint.Name = "DDBPrint"
        Me.DDBPrint.Size = New System.Drawing.Size(79, 32)
        Me.DDBPrint.TabIndex = 5
        Me.DDBPrint.Text = "Print"
        '
        'PUDD
        '
        Me.PUDD.LinksPersistInfo.AddRange(New DevExpress.XtraBars.LinkPersistInfo() {New DevExpress.XtraBars.LinkPersistInfo(Me.BarLargeButtonItem1), New DevExpress.XtraBars.LinkPersistInfo(Me.BarButtonItem2)})
        Me.PUDD.Manager = Me.BMDD
        Me.PUDD.Name = "PUDD"
        '
        'BarLargeButtonItem1
        '
        Me.BarLargeButtonItem1.Caption = "Print F. G. Purchase Order"
        Me.BarLargeButtonItem1.Id = 1
        Me.BarLargeButtonItem1.Name = "BarLargeButtonItem1"
        '
        'BarButtonItem2
        '
        Me.BarButtonItem2.Caption = "Print BOM"
        Me.BarButtonItem2.Id = 2
        Me.BarButtonItem2.Name = "BarButtonItem2"
        '
        'BMDD
        '
        Me.BMDD.DockControls.Add(Me.barDockControlTop)
        Me.BMDD.DockControls.Add(Me.barDockControlBottom)
        Me.BMDD.DockControls.Add(Me.barDockControlLeft)
        Me.BMDD.DockControls.Add(Me.barDockControlRight)
        Me.BMDD.Form = Me
        Me.BMDD.Items.AddRange(New DevExpress.XtraBars.BarItem() {Me.BarButtonItem1, Me.BarLargeButtonItem1, Me.BarButtonItem2})
        Me.BMDD.MaxItemId = 3
        '
        'barDockControlTop
        '
        Me.barDockControlTop.CausesValidation = False
        Me.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top
        Me.barDockControlTop.Location = New System.Drawing.Point(0, 0)
        Me.barDockControlTop.Size = New System.Drawing.Size(977, 0)
        '
        'barDockControlBottom
        '
        Me.barDockControlBottom.CausesValidation = False
        Me.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.barDockControlBottom.Location = New System.Drawing.Point(0, 559)
        Me.barDockControlBottom.Size = New System.Drawing.Size(977, 0)
        '
        'barDockControlLeft
        '
        Me.barDockControlLeft.CausesValidation = False
        Me.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left
        Me.barDockControlLeft.Location = New System.Drawing.Point(0, 0)
        Me.barDockControlLeft.Size = New System.Drawing.Size(0, 559)
        '
        'barDockControlRight
        '
        Me.barDockControlRight.CausesValidation = False
        Me.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right
        Me.barDockControlRight.Location = New System.Drawing.Point(977, 0)
        Me.barDockControlRight.Size = New System.Drawing.Size(0, 559)
        '
        'BarButtonItem1
        '
        Me.BarButtonItem1.Id = 0
        Me.BarButtonItem1.Name = "BarButtonItem1"
        '
        'BCancel
        '
        Me.BCancel.Dock = System.Windows.Forms.DockStyle.Right
        Me.BCancel.ImageIndex = 5
        Me.BCancel.ImageList = Me.ImgBut
        Me.BCancel.Location = New System.Drawing.Point(710, 2)
        Me.BCancel.Name = "BCancel"
        Me.BCancel.Size = New System.Drawing.Size(88, 32)
        Me.BCancel.TabIndex = 2
        Me.BCancel.Text = "Cancel"
        '
        'BSave
        '
        Me.BSave.Dock = System.Windows.Forms.DockStyle.Right
        Me.BSave.Enabled = False
        Me.BSave.ImageIndex = 7
        Me.BSave.ImageList = Me.ImgBut
        Me.BSave.Location = New System.Drawing.Point(798, 2)
        Me.BSave.Name = "BSave"
        Me.BSave.Size = New System.Drawing.Size(88, 32)
        Me.BSave.TabIndex = 1
        Me.BSave.Text = "Save"
        '
        'BMark
        '
        Me.BMark.Dock = System.Windows.Forms.DockStyle.Left
        Me.BMark.ImageIndex = 4
        Me.BMark.ImageList = Me.ImgBut
        Me.BMark.Location = New System.Drawing.Point(20, 2)
        Me.BMark.Name = "BMark"
        Me.BMark.Size = New System.Drawing.Size(85, 32)
        Me.BMark.TabIndex = 4
        Me.BMark.Text = "Mark"
        '
        'BPrint
        '
        Me.BPrint.Dock = System.Windows.Forms.DockStyle.Right
        Me.BPrint.ImageIndex = 6
        Me.BPrint.ImageList = Me.ImgBut
        Me.BPrint.Location = New System.Drawing.Point(886, 2)
        Me.BPrint.Name = "BPrint"
        Me.BPrint.Size = New System.Drawing.Size(83, 32)
        Me.BPrint.TabIndex = 3
        Me.BPrint.Text = "Print"
        Me.BPrint.Visible = False
        '
        'GroupGeneralHeader
        '
        Me.GroupGeneralHeader.CaptionLocation = DevExpress.Utils.Locations.Left
        Me.GroupGeneralHeader.Controls.Add(Me.LabelControl15)
        Me.GroupGeneralHeader.Controls.Add(Me.TETolerance)
        Me.GroupGeneralHeader.Controls.Add(Me.LabelControl14)
        Me.GroupGeneralHeader.Controls.Add(Me.DEDate)
        Me.GroupGeneralHeader.Controls.Add(Me.DERecDate)
        Me.GroupGeneralHeader.Controls.Add(Me.LabelControl11)
        Me.GroupGeneralHeader.Controls.Add(Me.TELeadTime)
        Me.GroupGeneralHeader.Controls.Add(Me.LabelControl13)
        Me.GroupGeneralHeader.Controls.Add(Me.LabelControl10)
        Me.GroupGeneralHeader.Controls.Add(Me.TEDesignCode)
        Me.GroupGeneralHeader.Controls.Add(Me.LabelControl9)
        Me.GroupGeneralHeader.Controls.Add(Me.LECategory)
        Me.GroupGeneralHeader.Controls.Add(Me.LabelControl5)
        Me.GroupGeneralHeader.Controls.Add(Me.BPickPD)
        Me.GroupGeneralHeader.Controls.Add(Me.TEPDNo)
        Me.GroupGeneralHeader.Controls.Add(Me.LabelControl8)
        Me.GroupGeneralHeader.Controls.Add(Me.TEUSCOde)
        Me.GroupGeneralHeader.Controls.Add(Me.LabelControl7)
        Me.GroupGeneralHeader.Controls.Add(Me.TEDelivery)
        Me.GroupGeneralHeader.Controls.Add(Me.TESeason)
        Me.GroupGeneralHeader.Controls.Add(Me.TERange)
        Me.GroupGeneralHeader.Controls.Add(Me.LabelControl2)
        Me.GroupGeneralHeader.Controls.Add(Me.LabelControl12)
        Me.GroupGeneralHeader.Controls.Add(Me.LEPOType)
        Me.GroupGeneralHeader.Controls.Add(Me.LabelControl6)
        Me.GroupGeneralHeader.Controls.Add(Me.LabelControl1)
        Me.GroupGeneralHeader.Controls.Add(Me.BPickDesign)
        Me.GroupGeneralHeader.Controls.Add(Me.TEDesign)
        Me.GroupGeneralHeader.Controls.Add(Me.LabelControl4)
        Me.GroupGeneralHeader.Controls.Add(Me.TEPONumber)
        Me.GroupGeneralHeader.Controls.Add(Me.LabelControl3)
        Me.GroupGeneralHeader.Dock = System.Windows.Forms.DockStyle.Top
        Me.GroupGeneralHeader.Location = New System.Drawing.Point(0, 0)
        Me.GroupGeneralHeader.Name = "GroupGeneralHeader"
        Me.GroupGeneralHeader.Size = New System.Drawing.Size(971, 135)
        Me.GroupGeneralHeader.TabIndex = 1
        '
        'LabelControl15
        '
        Me.LabelControl15.Location = New System.Drawing.Point(505, 98)
        Me.LabelControl15.Name = "LabelControl15"
        Me.LabelControl15.Size = New System.Drawing.Size(11, 13)
        Me.LabelControl15.TabIndex = 176
        Me.LabelControl15.Text = "%"
        '
        'TETolerance
        '
        Me.TETolerance.EditValue = New Decimal(New Integer() {0, 0, 0, 0})
        Me.TETolerance.Location = New System.Drawing.Point(442, 95)
        Me.TETolerance.Name = "TETolerance"
        Me.TETolerance.Properties.Appearance.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TETolerance.Properties.Appearance.Options.UseFont = True
        Me.TETolerance.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.TETolerance.Properties.IsFloatValue = False
        Me.TETolerance.Properties.Mask.EditMask = "N00"
        Me.TETolerance.Properties.MaxValue = New Decimal(New Integer() {2147483647, 0, 0, 0})
        Me.TETolerance.Size = New System.Drawing.Size(57, 22)
        Me.TETolerance.TabIndex = 176
        '
        'LabelControl14
        '
        Me.LabelControl14.Location = New System.Drawing.Point(381, 99)
        Me.LabelControl14.Name = "LabelControl14"
        Me.LabelControl14.Size = New System.Drawing.Size(47, 13)
        Me.LabelControl14.TabIndex = 175
        Me.LabelControl14.Text = "Tolerance"
        '
        'DEDate
        '
        Me.DEDate.EditValue = Nothing
        Me.DEDate.Enabled = False
        Me.DEDate.Location = New System.Drawing.Point(782, 9)
        Me.DEDate.Name = "DEDate"
        Me.DEDate.Properties.Appearance.Options.UseTextOptions = True
        Me.DEDate.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.DEDate.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.DEDate.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.DEDate.Properties.DisplayFormat.FormatString = "dd MMM yyyy"
        Me.DEDate.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.DEDate.Size = New System.Drawing.Size(169, 20)
        Me.DEDate.TabIndex = 174
        '
        'DERecDate
        '
        Me.DERecDate.EditValue = Nothing
        Me.DERecDate.Location = New System.Drawing.Point(782, 96)
        Me.DERecDate.Name = "DERecDate"
        Me.DERecDate.Properties.Appearance.Options.UseTextOptions = True
        Me.DERecDate.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.DERecDate.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.DERecDate.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.DERecDate.Properties.DisplayFormat.FormatString = "dd MMM yyyy"
        Me.DERecDate.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.DERecDate.Size = New System.Drawing.Size(169, 20)
        Me.DERecDate.TabIndex = 173
        '
        'LabelControl11
        '
        Me.LabelControl11.Location = New System.Drawing.Point(710, 99)
        Me.LabelControl11.Name = "LabelControl11"
        Me.LabelControl11.Size = New System.Drawing.Size(66, 13)
        Me.LabelControl11.TabIndex = 162
        Me.LabelControl11.Text = "Est. Rec Date"
        '
        'TELeadTime
        '
        Me.TELeadTime.EditValue = New Decimal(New Integer() {0, 0, 0, 0})
        Me.TELeadTime.Location = New System.Drawing.Point(598, 95)
        Me.TELeadTime.Name = "TELeadTime"
        Me.TELeadTime.Properties.Appearance.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TELeadTime.Properties.Appearance.Options.UseFont = True
        Me.TELeadTime.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.TELeadTime.Properties.IsFloatValue = False
        Me.TELeadTime.Properties.Mask.EditMask = "N00"
        Me.TELeadTime.Properties.MaxValue = New Decimal(New Integer() {2147483647, 0, 0, 0})
        Me.TELeadTime.Size = New System.Drawing.Size(87, 22)
        Me.TELeadTime.TabIndex = 160
        '
        'LabelControl13
        '
        Me.LabelControl13.Location = New System.Drawing.Point(535, 99)
        Me.LabelControl13.Name = "LabelControl13"
        Me.LabelControl13.Size = New System.Drawing.Size(48, 13)
        Me.LabelControl13.TabIndex = 161
        Me.LabelControl13.Text = "Lead Time"
        '
        'LabelControl10
        '
        Me.LabelControl10.Location = New System.Drawing.Point(535, 12)
        Me.LabelControl10.Name = "LabelControl10"
        Me.LabelControl10.Size = New System.Drawing.Size(39, 13)
        Me.LabelControl10.TabIndex = 158
        Me.LabelControl10.Text = "Delivery"
        '
        'TEDesignCode
        '
        Me.TEDesignCode.EditValue = ""
        Me.TEDesignCode.Location = New System.Drawing.Point(84, 70)
        Me.TEDesignCode.Name = "TEDesignCode"
        Me.TEDesignCode.Properties.EditValueChangedDelay = 1
        Me.TEDesignCode.Properties.ReadOnly = True
        Me.TEDesignCode.Size = New System.Drawing.Size(268, 20)
        Me.TEDesignCode.TabIndex = 157
        Me.TEDesignCode.TabStop = False
        '
        'LabelControl9
        '
        Me.LabelControl9.Location = New System.Drawing.Point(25, 73)
        Me.LabelControl9.Name = "LabelControl9"
        Me.LabelControl9.Size = New System.Drawing.Size(25, 13)
        Me.LabelControl9.TabIndex = 156
        Me.LabelControl9.Text = "Code"
        '
        'LECategory
        '
        Me.LECategory.Location = New System.Drawing.Point(442, 68)
        Me.LECategory.Name = "LECategory"
        Me.LECategory.Properties.AppearanceReadOnly.BackColor = System.Drawing.Color.WhiteSmoke
        Me.LECategory.Properties.AppearanceReadOnly.ForeColor = System.Drawing.Color.Black
        Me.LECategory.Properties.AppearanceReadOnly.Options.UseBackColor = True
        Me.LECategory.Properties.AppearanceReadOnly.Options.UseForeColor = True
        Me.LECategory.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.LECategory.Properties.NullText = ""
        Me.LECategory.Properties.ShowFooter = False
        Me.LECategory.Properties.View = Me.GridView1
        Me.LECategory.Size = New System.Drawing.Size(243, 20)
        Me.LECategory.TabIndex = 154
        '
        'GridView1
        '
        Me.GridView1.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumn1, Me.GridColumn2})
        Me.GridView1.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
        Me.GridView1.Name = "GridView1"
        Me.GridView1.OptionsSelection.EnableAppearanceFocusedCell = False
        Me.GridView1.OptionsView.ShowGroupPanel = False
        '
        'GridColumn1
        '
        Me.GridColumn1.Caption = "Id PO Type"
        Me.GridColumn1.FieldName = "id_term_production"
        Me.GridColumn1.Name = "GridColumn1"
        '
        'GridColumn2
        '
        Me.GridColumn2.Caption = "Term Production"
        Me.GridColumn2.FieldName = "term_production"
        Me.GridColumn2.Name = "GridColumn2"
        Me.GridColumn2.Visible = True
        Me.GridColumn2.VisibleIndex = 0
        '
        'LabelControl5
        '
        Me.LabelControl5.Location = New System.Drawing.Point(381, 71)
        Me.LabelControl5.Name = "LabelControl5"
        Me.LabelControl5.Size = New System.Drawing.Size(24, 13)
        Me.LabelControl5.TabIndex = 155
        Me.LabelControl5.Text = "Term"
        '
        'BPickPD
        '
        Me.BPickPD.Location = New System.Drawing.Point(329, 9)
        Me.BPickPD.Name = "BPickPD"
        Me.BPickPD.Size = New System.Drawing.Size(23, 20)
        Me.BPickPD.TabIndex = 152
        Me.BPickPD.Text = "..."
        '
        'TEPDNo
        '
        Me.TEPDNo.EditValue = ""
        Me.TEPDNo.Location = New System.Drawing.Point(84, 9)
        Me.TEPDNo.Name = "TEPDNo"
        Me.TEPDNo.Properties.EditValueChangedDelay = 1
        Me.TEPDNo.Properties.ReadOnly = True
        Me.TEPDNo.Size = New System.Drawing.Size(239, 20)
        Me.TEPDNo.TabIndex = 151
        Me.TEPDNo.TabStop = False
        '
        'LabelControl8
        '
        Me.LabelControl8.Location = New System.Drawing.Point(25, 12)
        Me.LabelControl8.Name = "LabelControl8"
        Me.LabelControl8.Size = New System.Drawing.Size(53, 13)
        Me.LabelControl8.TabIndex = 153
        Me.LabelControl8.Text = "PD Number"
        '
        'TEUSCOde
        '
        Me.TEUSCOde.EditValue = ""
        Me.TEUSCOde.Location = New System.Drawing.Point(84, 99)
        Me.TEUSCOde.Name = "TEUSCOde"
        Me.TEUSCOde.Properties.EditValueChangedDelay = 1
        Me.TEUSCOde.Properties.ReadOnly = True
        Me.TEUSCOde.Size = New System.Drawing.Size(268, 20)
        Me.TEUSCOde.TabIndex = 150
        Me.TEUSCOde.TabStop = False
        '
        'LabelControl7
        '
        Me.LabelControl7.Location = New System.Drawing.Point(25, 102)
        Me.LabelControl7.Name = "LabelControl7"
        Me.LabelControl7.Size = New System.Drawing.Size(41, 13)
        Me.LabelControl7.TabIndex = 149
        Me.LabelControl7.Text = "US Code"
        '
        'TEDelivery
        '
        Me.TEDelivery.EditValue = ""
        Me.TEDelivery.Location = New System.Drawing.Point(580, 9)
        Me.TEDelivery.Name = "TEDelivery"
        Me.TEDelivery.Properties.EditValueChangedDelay = 1
        Me.TEDelivery.Properties.ReadOnly = True
        Me.TEDelivery.Size = New System.Drawing.Size(105, 20)
        Me.TEDelivery.TabIndex = 148
        '
        'TESeason
        '
        Me.TESeason.EditValue = ""
        Me.TESeason.Location = New System.Drawing.Point(442, 39)
        Me.TESeason.Name = "TESeason"
        Me.TESeason.Properties.EditValueChangedDelay = 1
        Me.TESeason.Properties.ReadOnly = True
        Me.TESeason.Size = New System.Drawing.Size(243, 20)
        Me.TESeason.TabIndex = 146
        '
        'TERange
        '
        Me.TERange.EditValue = ""
        Me.TERange.Location = New System.Drawing.Point(442, 9)
        Me.TERange.Name = "TERange"
        Me.TERange.Properties.EditValueChangedDelay = 1
        Me.TERange.Properties.ReadOnly = True
        Me.TERange.Size = New System.Drawing.Size(87, 20)
        Me.TERange.TabIndex = 145
        '
        'LabelControl2
        '
        Me.LabelControl2.Location = New System.Drawing.Point(381, 12)
        Me.LabelControl2.Name = "LabelControl2"
        Me.LabelControl2.Size = New System.Drawing.Size(31, 13)
        Me.LabelControl2.TabIndex = 144
        Me.LabelControl2.Text = "Range"
        '
        'LabelControl12
        '
        Me.LabelControl12.Location = New System.Drawing.Point(381, 42)
        Me.LabelControl12.Name = "LabelControl12"
        Me.LabelControl12.Size = New System.Drawing.Size(35, 13)
        Me.LabelControl12.TabIndex = 139
        Me.LabelControl12.Text = "Season"
        '
        'LEPOType
        '
        Me.LEPOType.Location = New System.Drawing.Point(782, 68)
        Me.LEPOType.Name = "LEPOType"
        Me.LEPOType.Properties.AppearanceReadOnly.BackColor = System.Drawing.Color.WhiteSmoke
        Me.LEPOType.Properties.AppearanceReadOnly.ForeColor = System.Drawing.Color.Black
        Me.LEPOType.Properties.AppearanceReadOnly.Options.UseBackColor = True
        Me.LEPOType.Properties.AppearanceReadOnly.Options.UseForeColor = True
        Me.LEPOType.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.LEPOType.Properties.NullText = ""
        Me.LEPOType.Properties.ShowFooter = False
        Me.LEPOType.Properties.View = Me.GridView3
        Me.LEPOType.Size = New System.Drawing.Size(169, 20)
        Me.LEPOType.TabIndex = 2
        '
        'GridView3
        '
        Me.GridView3.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.ColIdPOType, Me.ColPOType})
        Me.GridView3.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
        Me.GridView3.Name = "GridView3"
        Me.GridView3.OptionsSelection.EnableAppearanceFocusedCell = False
        Me.GridView3.OptionsView.ShowGroupPanel = False
        '
        'ColIdPOType
        '
        Me.ColIdPOType.Caption = "Id PO Type"
        Me.ColIdPOType.FieldName = "id_po_type"
        Me.ColIdPOType.Name = "ColIdPOType"
        '
        'ColPOType
        '
        Me.ColPOType.Caption = "PO Type"
        Me.ColPOType.FieldName = "po_type"
        Me.ColPOType.Name = "ColPOType"
        Me.ColPOType.Visible = True
        Me.ColPOType.VisibleIndex = 0
        '
        'LabelControl6
        '
        Me.LabelControl6.Location = New System.Drawing.Point(710, 12)
        Me.LabelControl6.Name = "LabelControl6"
        Me.LabelControl6.Size = New System.Drawing.Size(23, 13)
        Me.LabelControl6.TabIndex = 124
        Me.LabelControl6.Text = "Date"
        '
        'LabelControl1
        '
        Me.LabelControl1.Location = New System.Drawing.Point(710, 71)
        Me.LabelControl1.Name = "LabelControl1"
        Me.LabelControl1.Size = New System.Drawing.Size(41, 13)
        Me.LabelControl1.TabIndex = 121
        Me.LabelControl1.Text = "PO Type"
        '
        'BPickDesign
        '
        Me.BPickDesign.Enabled = False
        Me.BPickDesign.Location = New System.Drawing.Point(329, 39)
        Me.BPickDesign.Name = "BPickDesign"
        Me.BPickDesign.Size = New System.Drawing.Size(23, 20)
        Me.BPickDesign.TabIndex = 1
        Me.BPickDesign.Text = "..."
        '
        'TEDesign
        '
        Me.TEDesign.EditValue = ""
        Me.TEDesign.Location = New System.Drawing.Point(84, 39)
        Me.TEDesign.Name = "TEDesign"
        Me.TEDesign.Properties.EditValueChangedDelay = 1
        Me.TEDesign.Properties.ReadOnly = True
        Me.TEDesign.Size = New System.Drawing.Size(239, 20)
        Me.TEDesign.TabIndex = 0
        Me.TEDesign.TabStop = False
        '
        'LabelControl4
        '
        Me.LabelControl4.Location = New System.Drawing.Point(25, 42)
        Me.LabelControl4.Name = "LabelControl4"
        Me.LabelControl4.Size = New System.Drawing.Size(32, 13)
        Me.LabelControl4.TabIndex = 88
        Me.LabelControl4.Text = "Design"
        '
        'TEPONumber
        '
        Me.TEPONumber.EditValue = ""
        Me.TEPONumber.Location = New System.Drawing.Point(782, 39)
        Me.TEPONumber.Name = "TEPONumber"
        Me.TEPONumber.Properties.EditValueChangedDelay = 1
        Me.TEPONumber.Properties.ReadOnly = True
        Me.TEPONumber.Size = New System.Drawing.Size(169, 20)
        Me.TEPONumber.TabIndex = 3
        '
        'LabelControl3
        '
        Me.LabelControl3.Location = New System.Drawing.Point(710, 42)
        Me.LabelControl3.Name = "LabelControl3"
        Me.LabelControl3.Size = New System.Drawing.Size(54, 13)
        Me.LabelControl3.TabIndex = 86
        Me.LabelControl3.Text = "PO Number"
        '
        'XTPWorkOrder
        '
        Me.XTPWorkOrder.Controls.Add(Me.GCProdWO)
        Me.XTPWorkOrder.Controls.Add(Me.PanelControl2)
        Me.XTPWorkOrder.Name = "XTPWorkOrder"
        Me.XTPWorkOrder.Size = New System.Drawing.Size(971, 531)
        Me.XTPWorkOrder.Text = "Work Order"
        '
        'GCProdWO
        '
        Me.GCProdWO.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCProdWO.Location = New System.Drawing.Point(0, 41)
        Me.GCProdWO.MainView = Me.GVProdWO
        Me.GCProdWO.Name = "GCProdWO"
        Me.GCProdWO.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.PGBProg, Me.RCIMainVendor})
        Me.GCProdWO.Size = New System.Drawing.Size(971, 490)
        Me.GCProdWO.TabIndex = 7
        Me.GCProdWO.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVProdWO})
        '
        'GVProdWO
        '
        Me.GVProdWO.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.ColIdMatPurchase, Me.ColPONumber, Me.ColShipFrom, Me.ColShipTo, Me.ColSamplePurcDate, Me.ColRecDate, Me.ColDueDate, Me.ColPayment, Me.ColStatus, Me.ColIDStatus, Me.ColIdWoType, Me.ColWoType, Me.GridColumnProgress, Me.GridColumnIsOVHMain})
        Me.GVProdWO.GridControl = Me.GCProdWO
        Me.GVProdWO.Name = "GVProdWO"
        Me.GVProdWO.OptionsBehavior.Editable = False
        Me.GVProdWO.OptionsFind.AlwaysVisible = True
        Me.GVProdWO.OptionsView.ShowGroupPanel = False
        '
        'ColIdMatPurchase
        '
        Me.ColIdMatPurchase.Caption = "ID Sample Purchase"
        Me.ColIdMatPurchase.FieldName = "id_prod_order_wo"
        Me.ColIdMatPurchase.Name = "ColIdMatPurchase"
        '
        'ColPONumber
        '
        Me.ColPONumber.Caption = "Number"
        Me.ColPONumber.FieldName = "prod_order_wo_number"
        Me.ColPONumber.Name = "ColPONumber"
        Me.ColPONumber.Visible = True
        Me.ColPONumber.VisibleIndex = 1
        Me.ColPONumber.Width = 120
        '
        'ColShipFrom
        '
        Me.ColShipFrom.Caption = "To"
        Me.ColShipFrom.FieldName = "comp_name_to"
        Me.ColShipFrom.Name = "ColShipFrom"
        Me.ColShipFrom.Visible = True
        Me.ColShipFrom.VisibleIndex = 3
        Me.ColShipFrom.Width = 107
        '
        'ColShipTo
        '
        Me.ColShipTo.Caption = "Ship To"
        Me.ColShipTo.FieldName = "comp_name_ship_to"
        Me.ColShipTo.Name = "ColShipTo"
        Me.ColShipTo.Visible = True
        Me.ColShipTo.VisibleIndex = 4
        Me.ColShipTo.Width = 107
        '
        'ColSamplePurcDate
        '
        Me.ColSamplePurcDate.Caption = "Create Date"
        Me.ColSamplePurcDate.DisplayFormat.FormatString = "dd MMM yyyy"
        Me.ColSamplePurcDate.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.ColSamplePurcDate.FieldName = "prod_order_wo_date"
        Me.ColSamplePurcDate.Name = "ColSamplePurcDate"
        Me.ColSamplePurcDate.Visible = True
        Me.ColSamplePurcDate.VisibleIndex = 5
        Me.ColSamplePurcDate.Width = 99
        '
        'ColRecDate
        '
        Me.ColRecDate.Caption = "Est. Receive Date"
        Me.ColRecDate.DisplayFormat.FormatString = "dd MMM yyyy"
        Me.ColRecDate.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.ColRecDate.FieldName = "prod_order_wo_lead_time"
        Me.ColRecDate.Name = "ColRecDate"
        Me.ColRecDate.Visible = True
        Me.ColRecDate.VisibleIndex = 6
        Me.ColRecDate.Width = 99
        '
        'ColDueDate
        '
        Me.ColDueDate.Caption = "Due Date"
        Me.ColDueDate.DisplayFormat.FormatString = "dd MMM yyyy"
        Me.ColDueDate.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.ColDueDate.FieldName = "prod_order_wo_top"
        Me.ColDueDate.Name = "ColDueDate"
        Me.ColDueDate.Width = 109
        '
        'ColPayment
        '
        Me.ColPayment.Caption = "Payment"
        Me.ColPayment.FieldName = "payment"
        Me.ColPayment.Name = "ColPayment"
        Me.ColPayment.Width = 80
        '
        'ColStatus
        '
        Me.ColStatus.Caption = "Status"
        Me.ColStatus.FieldName = "report_status"
        Me.ColStatus.Name = "ColStatus"
        Me.ColStatus.Visible = True
        Me.ColStatus.VisibleIndex = 7
        Me.ColStatus.Width = 62
        '
        'ColIDStatus
        '
        Me.ColIDStatus.Caption = "ID Status"
        Me.ColIDStatus.FieldName = "id_report_status"
        Me.ColIDStatus.Name = "ColIDStatus"
        '
        'ColIdWoType
        '
        Me.ColIdWoType.Caption = "WO Type"
        Me.ColIdWoType.FieldName = "id_ovh_price"
        Me.ColIdWoType.Name = "ColIdWoType"
        Me.ColIdWoType.Width = 80
        '
        'ColWoType
        '
        Me.ColWoType.Caption = "WO Type"
        Me.ColWoType.FieldName = "overhead"
        Me.ColWoType.Name = "ColWoType"
        Me.ColWoType.Visible = True
        Me.ColWoType.VisibleIndex = 2
        '
        'GridColumnProgress
        '
        Me.GridColumnProgress.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumnProgress.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridColumnProgress.AppearanceHeader.Options.UseTextOptions = True
        Me.GridColumnProgress.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridColumnProgress.Caption = "Progress"
        Me.GridColumnProgress.ColumnEdit = Me.PGBProg
        Me.GridColumnProgress.FieldName = "progress"
        Me.GridColumnProgress.Name = "GridColumnProgress"
        Me.GridColumnProgress.Visible = True
        Me.GridColumnProgress.VisibleIndex = 8
        '
        'PGBProg
        '
        Me.PGBProg.Appearance.BackColor = System.Drawing.Color.Lime
        Me.PGBProg.EndColor = System.Drawing.Color.Green
        Me.PGBProg.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Flat
        Me.PGBProg.LookAndFeel.UseDefaultLookAndFeel = False
        Me.PGBProg.Name = "PGBProg"
        Me.PGBProg.ProgressViewStyle = DevExpress.XtraEditors.Controls.ProgressViewStyle.Solid
        Me.PGBProg.ShowTitle = True
        Me.PGBProg.StartColor = System.Drawing.Color.Green
        Me.PGBProg.Step = 1
        '
        'GridColumnIsOVHMain
        '
        Me.GridColumnIsOVHMain.AppearanceHeader.Options.UseTextOptions = True
        Me.GridColumnIsOVHMain.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridColumnIsOVHMain.Caption = "Main Vendor"
        Me.GridColumnIsOVHMain.ColumnEdit = Me.RCIMainVendor
        Me.GridColumnIsOVHMain.FieldName = "is_main_vendor"
        Me.GridColumnIsOVHMain.Name = "GridColumnIsOVHMain"
        Me.GridColumnIsOVHMain.Visible = True
        Me.GridColumnIsOVHMain.VisibleIndex = 0
        '
        'RCIMainVendor
        '
        Me.RCIMainVendor.AutoHeight = False
        Me.RCIMainVendor.Name = "RCIMainVendor"
        Me.RCIMainVendor.ValueChecked = CType(1, Byte)
        Me.RCIMainVendor.ValueUnchecked = CType(2, Byte)
        '
        'PanelControl2
        '
        Me.PanelControl2.Controls.Add(Me.Bdel)
        Me.PanelControl2.Controls.Add(Me.BEditWO)
        Me.PanelControl2.Controls.Add(Me.BAddWO)
        Me.PanelControl2.Controls.Add(Me.BProgress)
        Me.PanelControl2.Controls.Add(Me.BAccount)
        Me.PanelControl2.Dock = System.Windows.Forms.DockStyle.Top
        Me.PanelControl2.Location = New System.Drawing.Point(0, 0)
        Me.PanelControl2.Name = "PanelControl2"
        Me.PanelControl2.Size = New System.Drawing.Size(971, 41)
        Me.PanelControl2.TabIndex = 0
        '
        'Bdel
        '
        Me.Bdel.Dock = System.Windows.Forms.DockStyle.Right
        Me.Bdel.ImageIndex = 1
        Me.Bdel.ImageList = Me.LargeImageCollection
        Me.Bdel.Location = New System.Drawing.Point(696, 2)
        Me.Bdel.Name = "Bdel"
        Me.Bdel.Size = New System.Drawing.Size(91, 37)
        Me.Bdel.TabIndex = 20
        Me.Bdel.Text = "Delete"
        '
        'BEditWO
        '
        Me.BEditWO.Dock = System.Windows.Forms.DockStyle.Right
        Me.BEditWO.ImageIndex = 2
        Me.BEditWO.ImageList = Me.LargeImageCollection
        Me.BEditWO.Location = New System.Drawing.Point(787, 2)
        Me.BEditWO.Name = "BEditWO"
        Me.BEditWO.Size = New System.Drawing.Size(91, 37)
        Me.BEditWO.TabIndex = 22
        Me.BEditWO.Text = "Edit"
        '
        'BAddWO
        '
        Me.BAddWO.Dock = System.Windows.Forms.DockStyle.Right
        Me.BAddWO.ImageIndex = 0
        Me.BAddWO.ImageList = Me.LargeImageCollection
        Me.BAddWO.Location = New System.Drawing.Point(878, 2)
        Me.BAddWO.Name = "BAddWO"
        Me.BAddWO.Size = New System.Drawing.Size(91, 37)
        Me.BAddWO.TabIndex = 21
        Me.BAddWO.Text = "Add"
        '
        'BProgress
        '
        Me.BProgress.Dock = System.Windows.Forms.DockStyle.Left
        Me.BProgress.ImageIndex = 3
        Me.BProgress.ImageList = Me.LargeImageCollection
        Me.BProgress.Location = New System.Drawing.Point(119, 2)
        Me.BProgress.Name = "BProgress"
        Me.BProgress.Size = New System.Drawing.Size(108, 37)
        Me.BProgress.TabIndex = 23
        Me.BProgress.Text = "Progress"
        '
        'BAccount
        '
        Me.BAccount.Dock = System.Windows.Forms.DockStyle.Left
        Me.BAccount.ImageIndex = 4
        Me.BAccount.ImageList = Me.LargeImageCollection
        Me.BAccount.Location = New System.Drawing.Point(2, 2)
        Me.BAccount.Name = "BAccount"
        Me.BAccount.Size = New System.Drawing.Size(117, 37)
        Me.BAccount.TabIndex = 24
        Me.BAccount.Text = "Mapping COA"
        Me.BAccount.Visible = False
        '
        'XTPMRS
        '
        Me.XTPMRS.Controls.Add(Me.GCMRS)
        Me.XTPMRS.Controls.Add(Me.PanelControl1)
        Me.XTPMRS.Name = "XTPMRS"
        Me.XTPMRS.Size = New System.Drawing.Size(971, 531)
        Me.XTPMRS.Text = "Material Requisition"
        '
        'GCMRS
        '
        Me.GCMRS.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCMRS.Location = New System.Drawing.Point(0, 41)
        Me.GCMRS.MainView = Me.GVMRS
        Me.GCMRS.Name = "GCMRS"
        Me.GCMRS.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.RepositoryItemProgressBar1})
        Me.GCMRS.Size = New System.Drawing.Size(971, 490)
        Me.GCMRS.TabIndex = 8
        Me.GCMRS.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVMRS})
        '
        'GVMRS
        '
        Me.GVMRS.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumnIdMRS, Me.GridColumnIdWO, Me.GridColumnIdCompReqFrom, Me.GridColumnCompReqFrom, Me.GridColumnIdCompReqTo, Me.GridColumnCompReqTo, Me.GridColumnDate, Me.GridColumnStatus, Me.GridColumnWONumber, Me.GridColumnMRSNumber, Me.GridColumnIdReportStatus})
        Me.GVMRS.GridControl = Me.GCMRS
        Me.GVMRS.Name = "GVMRS"
        Me.GVMRS.OptionsBehavior.Editable = False
        Me.GVMRS.OptionsFind.AlwaysVisible = True
        Me.GVMRS.OptionsView.ShowGroupPanel = False
        '
        'GridColumnIdMRS
        '
        Me.GridColumnIdMRS.Caption = "Id MRS"
        Me.GridColumnIdMRS.FieldName = "id_prod_order_mrs"
        Me.GridColumnIdMRS.Name = "GridColumnIdMRS"
        '
        'GridColumnIdWO
        '
        Me.GridColumnIdWO.Caption = "Id WO"
        Me.GridColumnIdWO.FieldName = "id_prod_order_wo"
        Me.GridColumnIdWO.Name = "GridColumnIdWO"
        '
        'GridColumnIdCompReqFrom
        '
        Me.GridColumnIdCompReqFrom.Caption = "Id Comp From"
        Me.GridColumnIdCompReqFrom.FieldName = "id_comp_name_req_from"
        Me.GridColumnIdCompReqFrom.Name = "GridColumnIdCompReqFrom"
        '
        'GridColumnCompReqFrom
        '
        Me.GridColumnCompReqFrom.Caption = "From"
        Me.GridColumnCompReqFrom.FieldName = "comp_name_req_from"
        Me.GridColumnCompReqFrom.Name = "GridColumnCompReqFrom"
        Me.GridColumnCompReqFrom.Visible = True
        Me.GridColumnCompReqFrom.VisibleIndex = 1
        Me.GridColumnCompReqFrom.Width = 214
        '
        'GridColumnIdCompReqTo
        '
        Me.GridColumnIdCompReqTo.Caption = "Id Comp To"
        Me.GridColumnIdCompReqTo.FieldName = "id_comp_name_req_to"
        Me.GridColumnIdCompReqTo.Name = "GridColumnIdCompReqTo"
        '
        'GridColumnCompReqTo
        '
        Me.GridColumnCompReqTo.Caption = "To"
        Me.GridColumnCompReqTo.FieldName = "comp_name_req_to"
        Me.GridColumnCompReqTo.Name = "GridColumnCompReqTo"
        Me.GridColumnCompReqTo.Visible = True
        Me.GridColumnCompReqTo.VisibleIndex = 2
        Me.GridColumnCompReqTo.Width = 214
        '
        'GridColumnDate
        '
        Me.GridColumnDate.Caption = "Date"
        Me.GridColumnDate.DisplayFormat.FormatString = "dd MMM yyyy"
        Me.GridColumnDate.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.GridColumnDate.FieldName = "prod_order_mrs_date"
        Me.GridColumnDate.Name = "GridColumnDate"
        Me.GridColumnDate.Visible = True
        Me.GridColumnDate.VisibleIndex = 3
        Me.GridColumnDate.Width = 129
        '
        'GridColumnStatus
        '
        Me.GridColumnStatus.Caption = "Status"
        Me.GridColumnStatus.FieldName = "report_status"
        Me.GridColumnStatus.Name = "GridColumnStatus"
        Me.GridColumnStatus.Visible = True
        Me.GridColumnStatus.VisibleIndex = 4
        Me.GridColumnStatus.Width = 96
        '
        'GridColumnWONumber
        '
        Me.GridColumnWONumber.Caption = "WO Number"
        Me.GridColumnWONumber.FieldName = "prod_order_wo_number"
        Me.GridColumnWONumber.Name = "GridColumnWONumber"
        Me.GridColumnWONumber.Width = 150
        '
        'GridColumnMRSNumber
        '
        Me.GridColumnMRSNumber.Caption = "Number"
        Me.GridColumnMRSNumber.FieldName = "prod_order_mrs_number"
        Me.GridColumnMRSNumber.Name = "GridColumnMRSNumber"
        Me.GridColumnMRSNumber.Visible = True
        Me.GridColumnMRSNumber.VisibleIndex = 0
        Me.GridColumnMRSNumber.Width = 150
        '
        'GridColumnIdReportStatus
        '
        Me.GridColumnIdReportStatus.Caption = "Id Report Status"
        Me.GridColumnIdReportStatus.FieldName = "id_report_status"
        Me.GridColumnIdReportStatus.Name = "GridColumnIdReportStatus"
        '
        'RepositoryItemProgressBar1
        '
        Me.RepositoryItemProgressBar1.Appearance.BackColor = System.Drawing.Color.Lime
        Me.RepositoryItemProgressBar1.EndColor = System.Drawing.Color.Green
        Me.RepositoryItemProgressBar1.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Flat
        Me.RepositoryItemProgressBar1.LookAndFeel.UseDefaultLookAndFeel = False
        Me.RepositoryItemProgressBar1.Name = "RepositoryItemProgressBar1"
        Me.RepositoryItemProgressBar1.ProgressViewStyle = DevExpress.XtraEditors.Controls.ProgressViewStyle.Solid
        Me.RepositoryItemProgressBar1.ShowTitle = True
        Me.RepositoryItemProgressBar1.StartColor = System.Drawing.Color.Green
        Me.RepositoryItemProgressBar1.Step = 1
        '
        'PanelControl1
        '
        Me.PanelControl1.Controls.Add(Me.BDeleteMRS)
        Me.PanelControl1.Controls.Add(Me.BEditMRS)
        Me.PanelControl1.Controls.Add(Me.BAddMRS)
        Me.PanelControl1.Dock = System.Windows.Forms.DockStyle.Top
        Me.PanelControl1.Location = New System.Drawing.Point(0, 0)
        Me.PanelControl1.Name = "PanelControl1"
        Me.PanelControl1.Size = New System.Drawing.Size(971, 41)
        Me.PanelControl1.TabIndex = 1
        '
        'BDeleteMRS
        '
        Me.BDeleteMRS.Dock = System.Windows.Forms.DockStyle.Right
        Me.BDeleteMRS.ImageIndex = 1
        Me.BDeleteMRS.ImageList = Me.LargeImageCollection
        Me.BDeleteMRS.Location = New System.Drawing.Point(696, 2)
        Me.BDeleteMRS.Name = "BDeleteMRS"
        Me.BDeleteMRS.Size = New System.Drawing.Size(91, 37)
        Me.BDeleteMRS.TabIndex = 20
        Me.BDeleteMRS.Text = "Delete"
        '
        'BEditMRS
        '
        Me.BEditMRS.Dock = System.Windows.Forms.DockStyle.Right
        Me.BEditMRS.ImageIndex = 2
        Me.BEditMRS.ImageList = Me.LargeImageCollection
        Me.BEditMRS.Location = New System.Drawing.Point(787, 2)
        Me.BEditMRS.Name = "BEditMRS"
        Me.BEditMRS.Size = New System.Drawing.Size(91, 37)
        Me.BEditMRS.TabIndex = 22
        Me.BEditMRS.Text = "Edit"
        '
        'BAddMRS
        '
        Me.BAddMRS.Dock = System.Windows.Forms.DockStyle.Right
        Me.BAddMRS.ImageIndex = 0
        Me.BAddMRS.ImageList = Me.LargeImageCollection
        Me.BAddMRS.Location = New System.Drawing.Point(878, 2)
        Me.BAddMRS.Name = "BAddMRS"
        Me.BAddMRS.Size = New System.Drawing.Size(91, 37)
        Me.BAddMRS.TabIndex = 21
        Me.BAddMRS.Text = "Add"
        '
        'PanelControl3
        '
        Me.PanelControl3.Controls.Add(Me.LabelControl16)
        Me.PanelControl3.Controls.Add(Me.MEBOMNote)
        Me.PanelControl3.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PanelControl3.Location = New System.Drawing.Point(0, 195)
        Me.PanelControl3.Name = "PanelControl3"
        Me.PanelControl3.Size = New System.Drawing.Size(943, 58)
        Me.PanelControl3.TabIndex = 4
        '
        'MEBOMNote
        '
        Me.MEBOMNote.Location = New System.Drawing.Point(81, 10)
        Me.MEBOMNote.MenuManager = Me.BMDD
        Me.MEBOMNote.Name = "MEBOMNote"
        Me.MEBOMNote.Size = New System.Drawing.Size(849, 38)
        Me.MEBOMNote.TabIndex = 0
        '
        'LabelControl16
        '
        Me.LabelControl16.Location = New System.Drawing.Point(14, 12)
        Me.LabelControl16.Name = "LabelControl16"
        Me.LabelControl16.Size = New System.Drawing.Size(58, 13)
        Me.LabelControl16.TabIndex = 139
        Me.LabelControl16.Text = "BOM Note : "
        '
        'FormProductionDet
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(977, 559)
        Me.Controls.Add(Me.XTCPageProduction)
        Me.Controls.Add(Me.barDockControlLeft)
        Me.Controls.Add(Me.barDockControlRight)
        Me.Controls.Add(Me.barDockControlBottom)
        Me.Controls.Add(Me.barDockControlTop)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FormProductionDet"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "F. G. Purchase Order"
        CType(Me.EPProdOrder, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LargeImageCollection, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.XTCPageProduction, System.ComponentModel.ISupportInitialize).EndInit()
        Me.XTCPageProduction.ResumeLayout(False)
        Me.XTPProdOrder.ResumeLayout(False)
        CType(Me.GConListPurchase, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GConListPurchase.ResumeLayout(False)
        CType(Me.XTCDetailPO, System.ComponentModel.ISupportInitialize).EndInit()
        Me.XTCDetailPO.ResumeLayout(False)
        Me.XTPListItem.ResumeLayout(False)
        CType(Me.GCListProduct, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVListProduct, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BEBOM, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SLEBOMName, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemSearchLookUpEdit1View, System.ComponentModel.ISupportInitialize).EndInit()
        Me.XTPBOM.ResumeLayout(False)
        CType(Me.GCBOM, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVBOM, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GroupGeneralFooter, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupGeneralFooter.ResumeLayout(False)
        Me.GroupGeneralFooter.PerformLayout()
        CType(Me.METotSay.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.MENote.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GroupControl3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupControl3.ResumeLayout(False)
        CType(Me.ImgBut, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PUDD, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BMDD, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GroupGeneralHeader, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupGeneralHeader.ResumeLayout(False)
        Me.GroupGeneralHeader.PerformLayout()
        CType(Me.TETolerance.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DEDate.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DEDate.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DERecDate.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DERecDate.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TELeadTime.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TEDesignCode.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LECategory.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TEPDNo.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TEUSCOde.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TEDelivery.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TESeason.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TERange.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LEPOType.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TEDesign.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TEPONumber.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.XTPWorkOrder.ResumeLayout(False)
        CType(Me.GCProdWO, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVProdWO, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PGBProg, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RCIMainVendor, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PanelControl2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl2.ResumeLayout(False)
        Me.XTPMRS.ResumeLayout(False)
        CType(Me.GCMRS, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVMRS, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemProgressBar1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl1.ResumeLayout(False)
        CType(Me.PanelControl3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl3.ResumeLayout(False)
        Me.PanelControl3.PerformLayout()
        CType(Me.MEBOMNote.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents EPProdOrder As System.Windows.Forms.ErrorProvider
    Public WithEvents LargeImageCollection As DevExpress.Utils.ImageCollection
    Friend WithEvents XTCPageProduction As DevExpress.XtraTab.XtraTabControl
    Friend WithEvents XTPProdOrder As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents GConListPurchase As DevExpress.XtraEditors.GroupControl
    Friend WithEvents XTCDetailPO As DevExpress.XtraTab.XtraTabControl
    Friend WithEvents XTPListItem As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents GCListProduct As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVListProduct As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents ColIdPurcDet As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColIdMat As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColNo As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColCode As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColName As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColPrice As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColQty As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColSubtotal As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColNote As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColColor As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColSize As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents XTPBOM As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents GCBOM As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVBOM As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumn14 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColTotal As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents Cat As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColIDCat As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnUOM As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GroupGeneralFooter As DevExpress.XtraEditors.GroupControl
    Friend WithEvents LabelControl19 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents METotSay As DevExpress.XtraEditors.MemoEdit
    Friend WithEvents LabelControl18 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents MENote As DevExpress.XtraEditors.MemoEdit
    Friend WithEvents GroupControl3 As DevExpress.XtraEditors.GroupControl
    Friend WithEvents BMark As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BPrint As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BCancel As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BSave As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents GroupGeneralHeader As DevExpress.XtraEditors.GroupControl
    Friend WithEvents LabelControl11 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents TELeadTime As DevExpress.XtraEditors.SpinEdit
    Friend WithEvents LabelControl13 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl10 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents TEDesignCode As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl9 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LECategory As DevExpress.XtraEditors.SearchLookUpEdit
    Friend WithEvents GridView1 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumn1 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn2 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents LabelControl5 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents BPickPD As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents TEPDNo As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl8 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents TEUSCOde As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl7 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents TEDelivery As DevExpress.XtraEditors.TextEdit
    Friend WithEvents TESeason As DevExpress.XtraEditors.TextEdit
    Friend WithEvents TERange As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl2 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl12 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LEPOType As DevExpress.XtraEditors.SearchLookUpEdit
    Friend WithEvents GridView3 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents ColIdPOType As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColPOType As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents LabelControl6 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl1 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents BPickDesign As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents TEDesign As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl4 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents TEPONumber As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl3 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents XTPWorkOrder As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents GCProdWO As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVProdWO As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents ColIdMatPurchase As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColPONumber As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColShipFrom As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColShipTo As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColSamplePurcDate As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColRecDate As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColDueDate As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColPayment As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColStatus As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColIDStatus As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColIdWoType As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColWoType As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnProgress As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents PGBProg As DevExpress.XtraEditors.Repository.RepositoryItemProgressBar
    Friend WithEvents PanelControl2 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents BProgress As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BEditWO As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BAddWO As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents Bdel As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents XTPMRS As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents GCMRS As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVMRS As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumnIdMRS As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnIdWO As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnIdCompReqFrom As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnCompReqFrom As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnIdCompReqTo As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnCompReqTo As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnDate As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnStatus As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnWONumber As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnMRSNumber As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents RepositoryItemProgressBar1 As DevExpress.XtraEditors.Repository.RepositoryItemProgressBar
    Friend WithEvents PanelControl1 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents BEditMRS As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BAddMRS As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BDeleteMRS As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BCOP As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents GridColumnIdReportStatus As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents BAccount As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents GridColumnBOM As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents SLEBOMName As DevExpress.XtraEditors.Repository.RepositoryItemSearchLookUpEdit
    Friend WithEvents RepositoryItemSearchLookUpEdit1View As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents BEBOM As DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit
    Friend WithEvents GridColumn3 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn4 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents DDBPrint As DevExpress.XtraEditors.DropDownButton
    Friend WithEvents barDockControlLeft As DevExpress.XtraBars.BarDockControl
    Friend WithEvents barDockControlRight As DevExpress.XtraBars.BarDockControl
    Friend WithEvents barDockControlBottom As DevExpress.XtraBars.BarDockControl
    Friend WithEvents barDockControlTop As DevExpress.XtraBars.BarDockControl
    Friend WithEvents BMDD As DevExpress.XtraBars.BarManager
    Friend WithEvents PUDD As DevExpress.XtraBars.PopupMenu
    Friend WithEvents BarLargeButtonItem1 As DevExpress.XtraBars.BarLargeButtonItem
    Friend WithEvents BarButtonItem2 As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents BarButtonItem1 As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents GridColumn18 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn22 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn23 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn24 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn25 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn26 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents BtnAttachment As DevExpress.XtraEditors.SimpleButton
    Public WithEvents ImgBut As DevExpress.Utils.ImageCollection
    Friend WithEvents GridColumnIsCost As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnIsOVHMain As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents RCIMainVendor As DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit
    Friend WithEvents GridColumnUPC As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents DERecDate As DevExpress.XtraEditors.DateEdit
    Friend WithEvents DEDate As DevExpress.XtraEditors.DateEdit
    Friend WithEvents LabelControl15 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents TETolerance As DevExpress.XtraEditors.SpinEdit
    Friend WithEvents LabelControl14 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents PanelControl3 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents LabelControl16 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents MEBOMNote As DevExpress.XtraEditors.MemoEdit
End Class
