<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FormBOM
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormBOM))
        Me.SplitContainerControl1 = New DevExpress.XtraEditors.SplitContainerControl()
        Me.SplitContainerControl2 = New DevExpress.XtraEditors.SplitContainerControl()
        Me.GroupControl1 = New DevExpress.XtraEditors.GroupControl()
        Me.GCProduct = New DevExpress.XtraGrid.GridControl()
        Me.GVProduct = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.ColIdProduct = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.ColIdDesign = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.ColIdSeason = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.ColNamaDesign = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.ColProductCode = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.ColProductname = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.ColSeason = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.ColSize = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnIDSeason = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn27 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GroupControl2 = New DevExpress.XtraEditors.GroupControl()
        Me.GCBOM = New DevExpress.XtraGrid.GridControl()
        Me.GVBOM = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.ColIdBom = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.ColBomName = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.ColTermProduction = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.ColDate = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.ColUnitPrice = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.ColIdStatus = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.ColStatus = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn8 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RCEDefault = New DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit()
        Me.GridColumn9 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn10 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.PanelControl1 = New DevExpress.XtraEditors.PanelControl()
        Me.BDefault = New DevExpress.XtraEditors.SimpleButton()
        Me.LargeImageCollection = New DevExpress.Utils.ImageCollection(Me.components)
        Me.GroupControl3 = New DevExpress.XtraEditors.GroupControl()
        Me.XtraTabControl1 = New DevExpress.XtraTab.XtraTabControl()
        Me.XTPMat = New DevExpress.XtraTab.XtraTabPage()
        Me.GCBomDetMat = New DevExpress.XtraGrid.GridControl()
        Me.GVBomDetMat = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumn1 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn6 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn3 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn2 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn4 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn5 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn7 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnIsCostSingle = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridView3 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.XTPOvh = New DevExpress.XtraTab.XtraTabPage()
        Me.GCBomDetOvh = New DevExpress.XtraGrid.GridControl()
        Me.GVBomDetOvh = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumn15 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn16 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn17 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn19 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn20 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn21 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridView5 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.XTPWip = New DevExpress.XtraTab.XtraTabPage()
        Me.GCBomDetWip = New DevExpress.XtraGrid.GridControl()
        Me.GVBomDetWip = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumn29 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn30 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn31 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn32 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn33 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn34 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn35 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridView9 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.XTCBOMSelection = New DevExpress.XtraTab.XtraTabControl()
        Me.XTPPerPD = New DevExpress.XtraTab.XtraTabPage()
        Me.SplitContainerControl3 = New DevExpress.XtraEditors.SplitContainerControl()
        Me.GCDesign = New DevExpress.XtraGrid.GridControl()
        Me.GVDesign = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumn11 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn59 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn60 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn61 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn62 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn63 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn64 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn65 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn66 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn67 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn68 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn69 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridView2 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GroupControl6 = New DevExpress.XtraEditors.GroupControl()
        Me.GCBOMDesign = New DevExpress.XtraGrid.GridControl()
        Me.GVBOMDesign = New DevExpress.XtraGrid.Views.Grid.GridView()
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
        Me.GridColumnIsCop = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.XTPPerProduct = New DevExpress.XtraTab.XtraTabPage()
        Me.XTPPerDesign = New DevExpress.XtraTab.XtraTabPage()
        Me.SplitContainerControl4 = New DevExpress.XtraEditors.SplitContainerControl()
        Me.SplitContainerControl5 = New DevExpress.XtraEditors.SplitContainerControl()
        Me.GCPerDesign = New DevExpress.XtraGrid.GridControl()
        Me.GVPerDesign = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumn28 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn36 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn37 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn38 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn39 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn40 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn41 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn42 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn43 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn44 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn45 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnUnitCost = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn52 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn55 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn56 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn57 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnStatusLineList = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridView4 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.PanelControl3 = New DevExpress.XtraEditors.PanelControl()
        Me.BtnView = New DevExpress.XtraEditors.SimpleButton()
        Me.BPrint = New DevExpress.XtraEditors.SimpleButton()
        Me.SLESeason = New DevExpress.XtraEditors.SearchLookUpEdit()
        Me.SearchLookUpEdit1View = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumn51 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnRange = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnSeason = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.LabelControl4 = New DevExpress.XtraEditors.LabelControl()
        Me.GroupControl5 = New DevExpress.XtraEditors.GroupControl()
        Me.GCBOMPerDesign = New DevExpress.XtraGrid.GridControl()
        Me.GVBOMPerDesign = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumn48 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn70 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn71 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn72 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn73 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn74 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn75 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn76 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RepositoryItemCheckEdit1 = New DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit()
        Me.GridColumn77 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn78 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnIdBOMApprove = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.PanelControl2 = New DevExpress.XtraEditors.PanelControl()
        Me.BImportExcel = New DevExpress.XtraEditors.SimpleButton()
        Me.BDefaultBOM = New DevExpress.XtraEditors.SimpleButton()
        Me.GroupControl4 = New DevExpress.XtraEditors.GroupControl()
        Me.GCCompPerDesign = New DevExpress.XtraGrid.GridControl()
        Me.GVCompPerDesign = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumnColor = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.ColCode = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.ColName = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn46 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.ColQty = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn54 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnCur = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn53 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.ColPrice = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn47 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn49 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn50 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnisCOST = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnQtyOrder = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnCostPerPcs = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn12 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn13 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnQty = New DevExpress.XtraGrid.Columns.GridColumn()
        CType(Me.SplitContainerControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainerControl1.SuspendLayout()
        CType(Me.SplitContainerControl2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainerControl2.SuspendLayout()
        CType(Me.GroupControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupControl1.SuspendLayout()
        CType(Me.GCProduct, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVProduct, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GroupControl2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupControl2.SuspendLayout()
        CType(Me.GCBOM, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVBOM, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RCEDefault, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl1.SuspendLayout()
        CType(Me.LargeImageCollection, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GroupControl3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupControl3.SuspendLayout()
        CType(Me.XtraTabControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.XtraTabControl1.SuspendLayout()
        Me.XTPMat.SuspendLayout()
        CType(Me.GCBomDetMat, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVBomDetMat, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.XTPOvh.SuspendLayout()
        CType(Me.GCBomDetOvh, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVBomDetOvh, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView5, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.XTPWip.SuspendLayout()
        CType(Me.GCBomDetWip, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVBomDetWip, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView9, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.XTCBOMSelection, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.XTCBOMSelection.SuspendLayout()
        Me.XTPPerPD.SuspendLayout()
        CType(Me.SplitContainerControl3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainerControl3.SuspendLayout()
        CType(Me.GCDesign, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVDesign, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GroupControl6, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupControl6.SuspendLayout()
        CType(Me.GCBOMDesign, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVBOMDesign, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.XTPPerProduct.SuspendLayout()
        Me.XTPPerDesign.SuspendLayout()
        CType(Me.SplitContainerControl4, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainerControl4.SuspendLayout()
        CType(Me.SplitContainerControl5, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainerControl5.SuspendLayout()
        CType(Me.GCPerDesign, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVPerDesign, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PanelControl3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl3.SuspendLayout()
        CType(Me.SLESeason.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SearchLookUpEdit1View, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GroupControl5, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupControl5.SuspendLayout()
        CType(Me.GCBOMPerDesign, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVBOMPerDesign, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemCheckEdit1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PanelControl2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl2.SuspendLayout()
        CType(Me.GroupControl4, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupControl4.SuspendLayout()
        CType(Me.GCCompPerDesign, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVCompPerDesign, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'SplitContainerControl1
        '
        Me.SplitContainerControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainerControl1.FixedPanel = DevExpress.XtraEditors.SplitFixedPanel.None
        Me.SplitContainerControl1.Horizontal = False
        Me.SplitContainerControl1.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainerControl1.Name = "SplitContainerControl1"
        Me.SplitContainerControl1.Panel1.Controls.Add(Me.SplitContainerControl2)
        Me.SplitContainerControl1.Panel1.Text = "Panel1"
        Me.SplitContainerControl1.Panel2.Controls.Add(Me.GroupControl3)
        Me.SplitContainerControl1.Panel2.Text = "Panel2"
        Me.SplitContainerControl1.Size = New System.Drawing.Size(905, 492)
        Me.SplitContainerControl1.SplitterPosition = 283
        Me.SplitContainerControl1.TabIndex = 3
        Me.SplitContainerControl1.Text = "SplitContainerControl1"
        '
        'SplitContainerControl2
        '
        Me.SplitContainerControl2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainerControl2.FixedPanel = DevExpress.XtraEditors.SplitFixedPanel.None
        Me.SplitContainerControl2.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainerControl2.Name = "SplitContainerControl2"
        Me.SplitContainerControl2.Panel1.Controls.Add(Me.GroupControl1)
        Me.SplitContainerControl2.Panel1.Text = "Panel1"
        Me.SplitContainerControl2.Panel2.Controls.Add(Me.GroupControl2)
        Me.SplitContainerControl2.Panel2.Text = "Panel2"
        Me.SplitContainerControl2.Size = New System.Drawing.Size(905, 283)
        Me.SplitContainerControl2.SplitterPosition = 451
        Me.SplitContainerControl2.TabIndex = 0
        Me.SplitContainerControl2.Text = "SplitContainerControl2"
        '
        'GroupControl1
        '
        Me.GroupControl1.Controls.Add(Me.GCProduct)
        Me.GroupControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupControl1.Location = New System.Drawing.Point(0, 0)
        Me.GroupControl1.Name = "GroupControl1"
        Me.GroupControl1.Size = New System.Drawing.Size(451, 283)
        Me.GroupControl1.TabIndex = 0
        Me.GroupControl1.Text = "Choose Product"
        '
        'GCProduct
        '
        Me.GCProduct.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCProduct.Location = New System.Drawing.Point(2, 20)
        Me.GCProduct.MainView = Me.GVProduct
        Me.GCProduct.Name = "GCProduct"
        Me.GCProduct.Size = New System.Drawing.Size(447, 261)
        Me.GCProduct.TabIndex = 0
        Me.GCProduct.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVProduct})
        '
        'GVProduct
        '
        Me.GVProduct.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.ColIdProduct, Me.ColIdDesign, Me.ColIdSeason, Me.ColNamaDesign, Me.ColProductCode, Me.ColProductname, Me.ColSeason, Me.ColSize, Me.GridColumnIDSeason, Me.GridColumn27})
        Me.GVProduct.GridControl = Me.GCProduct
        Me.GVProduct.GroupCount = 2
        Me.GVProduct.Name = "GVProduct"
        Me.GVProduct.OptionsBehavior.Editable = False
        Me.GVProduct.OptionsFind.AlwaysVisible = True
        Me.GVProduct.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never
        Me.GVProduct.OptionsView.ShowGroupPanel = False
        Me.GVProduct.SortInfo.AddRange(New DevExpress.XtraGrid.Columns.GridColumnSortInfo() {New DevExpress.XtraGrid.Columns.GridColumnSortInfo(Me.ColSeason, DevExpress.Data.ColumnSortOrder.Descending), New DevExpress.XtraGrid.Columns.GridColumnSortInfo(Me.ColNamaDesign, DevExpress.Data.ColumnSortOrder.Descending), New DevExpress.XtraGrid.Columns.GridColumnSortInfo(Me.ColIdDesign, DevExpress.Data.ColumnSortOrder.Descending)})
        '
        'ColIdProduct
        '
        Me.ColIdProduct.Caption = "ID Product"
        Me.ColIdProduct.FieldName = "id_product"
        Me.ColIdProduct.Name = "ColIdProduct"
        '
        'ColIdDesign
        '
        Me.ColIdDesign.Caption = "ID Design"
        Me.ColIdDesign.FieldName = "id_design"
        Me.ColIdDesign.Name = "ColIdDesign"
        '
        'ColIdSeason
        '
        Me.ColIdSeason.Caption = "ID Season"
        Me.ColIdSeason.FieldName = "id_season"
        Me.ColIdSeason.Name = "ColIdSeason"
        '
        'ColNamaDesign
        '
        Me.ColNamaDesign.Caption = "Design"
        Me.ColNamaDesign.FieldName = "design_name"
        Me.ColNamaDesign.FieldNameSortGroup = "id_design"
        Me.ColNamaDesign.Name = "ColNamaDesign"
        '
        'ColProductCode
        '
        Me.ColProductCode.Caption = "Code"
        Me.ColProductCode.FieldName = "product_full_code"
        Me.ColProductCode.Name = "ColProductCode"
        Me.ColProductCode.Visible = True
        Me.ColProductCode.VisibleIndex = 0
        Me.ColProductCode.Width = 386
        '
        'ColProductname
        '
        Me.ColProductname.Caption = "Product"
        Me.ColProductname.FieldName = "product_name"
        Me.ColProductname.Name = "ColProductname"
        Me.ColProductname.Visible = True
        Me.ColProductname.VisibleIndex = 1
        Me.ColProductname.Width = 422
        '
        'ColSeason
        '
        Me.ColSeason.Caption = "Season"
        Me.ColSeason.FieldName = "season"
        Me.ColSeason.FieldNameSortGroup = "id_season"
        Me.ColSeason.Name = "ColSeason"
        '
        'ColSize
        '
        Me.ColSize.AppearanceCell.Options.UseTextOptions = True
        Me.ColSize.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.ColSize.AppearanceHeader.Options.UseTextOptions = True
        Me.ColSize.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.ColSize.Caption = "Size"
        Me.ColSize.FieldName = "Size"
        Me.ColSize.Name = "ColSize"
        Me.ColSize.Visible = True
        Me.ColSize.VisibleIndex = 3
        Me.ColSize.Width = 168
        '
        'GridColumnIDSeason
        '
        Me.GridColumnIDSeason.Caption = "ID Season"
        Me.GridColumnIDSeason.FieldName = "id_season"
        Me.GridColumnIDSeason.Name = "GridColumnIDSeason"
        '
        'GridColumn27
        '
        Me.GridColumn27.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumn27.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridColumn27.AppearanceHeader.Options.UseTextOptions = True
        Me.GridColumn27.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridColumn27.Caption = "Source"
        Me.GridColumn27.FieldName = "Product Source_display"
        Me.GridColumn27.Name = "GridColumn27"
        Me.GridColumn27.Visible = True
        Me.GridColumn27.VisibleIndex = 2
        Me.GridColumn27.Width = 204
        '
        'GroupControl2
        '
        Me.GroupControl2.Controls.Add(Me.GCBOM)
        Me.GroupControl2.Controls.Add(Me.PanelControl1)
        Me.GroupControl2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupControl2.Location = New System.Drawing.Point(0, 0)
        Me.GroupControl2.Name = "GroupControl2"
        Me.GroupControl2.Size = New System.Drawing.Size(449, 283)
        Me.GroupControl2.TabIndex = 1
        Me.GroupControl2.Text = "BOM"
        '
        'GCBOM
        '
        Me.GCBOM.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCBOM.Location = New System.Drawing.Point(2, 52)
        Me.GCBOM.MainView = Me.GVBOM
        Me.GCBOM.Name = "GCBOM"
        Me.GCBOM.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.RCEDefault})
        Me.GCBOM.Size = New System.Drawing.Size(445, 229)
        Me.GCBOM.TabIndex = 1
        Me.GCBOM.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVBOM})
        '
        'GVBOM
        '
        Me.GVBOM.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.ColIdBom, Me.ColBomName, Me.ColTermProduction, Me.ColDate, Me.ColUnitPrice, Me.ColIdStatus, Me.ColStatus, Me.GridColumn8, Me.GridColumn9, Me.GridColumn10})
        Me.GVBOM.GridControl = Me.GCBOM
        Me.GVBOM.Name = "GVBOM"
        Me.GVBOM.OptionsBehavior.Editable = False
        Me.GVBOM.OptionsView.ShowGroupPanel = False
        '
        'ColIdBom
        '
        Me.ColIdBom.Caption = "Id Bom"
        Me.ColIdBom.FieldName = "id_bom"
        Me.ColIdBom.Name = "ColIdBom"
        '
        'ColBomName
        '
        Me.ColBomName.Caption = "Method"
        Me.ColBomName.FieldName = "bom_name"
        Me.ColBomName.Name = "ColBomName"
        Me.ColBomName.Visible = True
        Me.ColBomName.VisibleIndex = 1
        '
        'ColTermProduction
        '
        Me.ColTermProduction.Caption = "Term"
        Me.ColTermProduction.FieldName = "term_production"
        Me.ColTermProduction.Name = "ColTermProduction"
        Me.ColTermProduction.Visible = True
        Me.ColTermProduction.VisibleIndex = 0
        '
        'ColDate
        '
        Me.ColDate.Caption = "Date Created"
        Me.ColDate.FieldName = "bom_date_created"
        Me.ColDate.Name = "ColDate"
        Me.ColDate.Visible = True
        Me.ColDate.VisibleIndex = 4
        '
        'ColUnitPrice
        '
        Me.ColUnitPrice.AppearanceCell.Options.UseTextOptions = True
        Me.ColUnitPrice.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.ColUnitPrice.AppearanceHeader.Options.UseTextOptions = True
        Me.ColUnitPrice.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.ColUnitPrice.Caption = "Unit Price"
        Me.ColUnitPrice.DisplayFormat.FormatString = "N2"
        Me.ColUnitPrice.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.ColUnitPrice.FieldName = "bom_unit_price"
        Me.ColUnitPrice.Name = "ColUnitPrice"
        Me.ColUnitPrice.Visible = True
        Me.ColUnitPrice.VisibleIndex = 3
        '
        'ColIdStatus
        '
        Me.ColIdStatus.Caption = "GridColumn8"
        Me.ColIdStatus.FieldName = "id_report_status"
        Me.ColIdStatus.Name = "ColIdStatus"
        '
        'ColStatus
        '
        Me.ColStatus.Caption = "Status"
        Me.ColStatus.FieldName = "report_status"
        Me.ColStatus.Name = "ColStatus"
        '
        'GridColumn8
        '
        Me.GridColumn8.AppearanceHeader.Options.UseTextOptions = True
        Me.GridColumn8.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridColumn8.Caption = "Default"
        Me.GridColumn8.ColumnEdit = Me.RCEDefault
        Me.GridColumn8.FieldName = "is_default"
        Me.GridColumn8.Name = "GridColumn8"
        Me.GridColumn8.Visible = True
        Me.GridColumn8.VisibleIndex = 5
        '
        'RCEDefault
        '
        Me.RCEDefault.AutoHeight = False
        Me.RCEDefault.Name = "RCEDefault"
        Me.RCEDefault.ValueChecked = "yes"
        Me.RCEDefault.ValueUnchecked = "no"
        '
        'GridColumn9
        '
        Me.GridColumn9.Caption = "Id Currency"
        Me.GridColumn9.FieldName = "id_currency"
        Me.GridColumn9.Name = "GridColumn9"
        '
        'GridColumn10
        '
        Me.GridColumn10.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumn10.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridColumn10.AppearanceHeader.Options.UseTextOptions = True
        Me.GridColumn10.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridColumn10.Caption = "Currency"
        Me.GridColumn10.FieldName = "currency"
        Me.GridColumn10.Name = "GridColumn10"
        Me.GridColumn10.Visible = True
        Me.GridColumn10.VisibleIndex = 2
        '
        'PanelControl1
        '
        Me.PanelControl1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
        Me.PanelControl1.Controls.Add(Me.BDefault)
        Me.PanelControl1.Dock = System.Windows.Forms.DockStyle.Top
        Me.PanelControl1.Location = New System.Drawing.Point(2, 20)
        Me.PanelControl1.Name = "PanelControl1"
        Me.PanelControl1.Size = New System.Drawing.Size(445, 32)
        Me.PanelControl1.TabIndex = 2
        '
        'BDefault
        '
        Me.BDefault.Dock = System.Windows.Forms.DockStyle.Right
        Me.BDefault.ImageIndex = 2
        Me.BDefault.ImageList = Me.LargeImageCollection
        Me.BDefault.Location = New System.Drawing.Point(323, 0)
        Me.BDefault.Name = "BDefault"
        Me.BDefault.Size = New System.Drawing.Size(122, 32)
        Me.BDefault.TabIndex = 0
        Me.BDefault.Text = "Set As Default"
        '
        'LargeImageCollection
        '
        Me.LargeImageCollection.ImageSize = New System.Drawing.Size(24, 24)
        Me.LargeImageCollection.ImageStream = CType(resources.GetObject("LargeImageCollection.ImageStream"), DevExpress.Utils.ImageCollectionStreamer)
        Me.LargeImageCollection.Images.SetKeyName(0, "20_24x24.png")
        Me.LargeImageCollection.Images.SetKeyName(1, "8_24x24.png")
        Me.LargeImageCollection.Images.SetKeyName(2, "23_24x24.png")
        '
        'GroupControl3
        '
        Me.GroupControl3.Controls.Add(Me.XtraTabControl1)
        Me.GroupControl3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupControl3.Location = New System.Drawing.Point(0, 0)
        Me.GroupControl3.Name = "GroupControl3"
        Me.GroupControl3.Size = New System.Drawing.Size(905, 204)
        Me.GroupControl3.TabIndex = 1
        Me.GroupControl3.Text = "List Component"
        '
        'XtraTabControl1
        '
        Me.XtraTabControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.XtraTabControl1.Location = New System.Drawing.Point(2, 20)
        Me.XtraTabControl1.Name = "XtraTabControl1"
        Me.XtraTabControl1.SelectedTabPage = Me.XTPMat
        Me.XtraTabControl1.Size = New System.Drawing.Size(901, 182)
        Me.XtraTabControl1.TabIndex = 4
        Me.XtraTabControl1.TabPages.AddRange(New DevExpress.XtraTab.XtraTabPage() {Me.XTPMat, Me.XTPOvh, Me.XTPWip})
        '
        'XTPMat
        '
        Me.XTPMat.Controls.Add(Me.GCBomDetMat)
        Me.XTPMat.Name = "XTPMat"
        Me.XTPMat.Size = New System.Drawing.Size(895, 154)
        Me.XTPMat.Text = "Material"
        '
        'GCBomDetMat
        '
        Me.GCBomDetMat.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCBomDetMat.Location = New System.Drawing.Point(0, 0)
        Me.GCBomDetMat.MainView = Me.GVBomDetMat
        Me.GCBomDetMat.Name = "GCBomDetMat"
        Me.GCBomDetMat.Size = New System.Drawing.Size(895, 154)
        Me.GCBomDetMat.TabIndex = 12
        Me.GCBomDetMat.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVBomDetMat, Me.GridView3})
        '
        'GVBomDetMat
        '
        Me.GVBomDetMat.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumn1, Me.GridColumn6, Me.GridColumn3, Me.GridColumn2, Me.GridColumn4, Me.GridColumn5, Me.GridColumn7, Me.GridColumnIsCostSingle})
        Me.GVBomDetMat.CustomizationFormBounds = New System.Drawing.Rectangle(885, 289, 216, 178)
        Me.GVBomDetMat.GridControl = Me.GCBomDetMat
        Me.GVBomDetMat.GroupSummary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "total", Me.GridColumn7, "")})
        Me.GVBomDetMat.Name = "GVBomDetMat"
        Me.GVBomDetMat.OptionsBehavior.Editable = False
        Me.GVBomDetMat.OptionsFind.AlwaysVisible = True
        Me.GVBomDetMat.OptionsView.ShowFooter = True
        Me.GVBomDetMat.OptionsView.ShowGroupPanel = False
        '
        'GridColumn1
        '
        Me.GridColumn1.Caption = "Id Mat"
        Me.GridColumn1.FieldName = "id_mat_det"
        Me.GridColumn1.Name = "GridColumn1"
        '
        'GridColumn6
        '
        Me.GridColumn6.Caption = "Code"
        Me.GridColumn6.FieldName = "code"
        Me.GridColumn6.Name = "GridColumn6"
        Me.GridColumn6.Visible = True
        Me.GridColumn6.VisibleIndex = 0
        Me.GridColumn6.Width = 120
        '
        'GridColumn3
        '
        Me.GridColumn3.Caption = "Material"
        Me.GridColumn3.FieldName = "name"
        Me.GridColumn3.Name = "GridColumn3"
        Me.GridColumn3.Visible = True
        Me.GridColumn3.VisibleIndex = 1
        Me.GridColumn3.Width = 200
        '
        'GridColumn2
        '
        Me.GridColumn2.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumn2.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridColumn2.AppearanceHeader.Options.UseTextOptions = True
        Me.GridColumn2.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridColumn2.Caption = "Size"
        Me.GridColumn2.FieldName = "size"
        Me.GridColumn2.Name = "GridColumn2"
        Me.GridColumn2.Visible = True
        Me.GridColumn2.VisibleIndex = 2
        Me.GridColumn2.Width = 57
        '
        'GridColumn4
        '
        Me.GridColumn4.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumn4.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumn4.AppearanceHeader.Options.UseTextOptions = True
        Me.GridColumn4.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumn4.Caption = "Qty"
        Me.GridColumn4.DisplayFormat.FormatString = "N2"
        Me.GridColumn4.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumn4.FieldName = "qty_uom"
        Me.GridColumn4.Name = "GridColumn4"
        Me.GridColumn4.Visible = True
        Me.GridColumn4.VisibleIndex = 3
        Me.GridColumn4.Width = 102
        '
        'GridColumn5
        '
        Me.GridColumn5.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumn5.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumn5.AppearanceHeader.Options.UseTextOptions = True
        Me.GridColumn5.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumn5.Caption = "Unit Price"
        Me.GridColumn5.DisplayFormat.FormatString = "N2"
        Me.GridColumn5.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumn5.FieldName = "price"
        Me.GridColumn5.Name = "GridColumn5"
        Me.GridColumn5.Visible = True
        Me.GridColumn5.VisibleIndex = 4
        Me.GridColumn5.Width = 208
        '
        'GridColumn7
        '
        Me.GridColumn7.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumn7.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumn7.AppearanceHeader.Options.UseTextOptions = True
        Me.GridColumn7.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumn7.Caption = "Total"
        Me.GridColumn7.DisplayFormat.FormatString = "N2"
        Me.GridColumn7.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumn7.FieldName = "total"
        Me.GridColumn7.Name = "GridColumn7"
        Me.GridColumn7.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "total", "{0:N2}")})
        Me.GridColumn7.Visible = True
        Me.GridColumn7.VisibleIndex = 5
        Me.GridColumn7.Width = 219
        '
        'GridColumnIsCostSingle
        '
        Me.GridColumnIsCostSingle.Caption = "Is Cost"
        Me.GridColumnIsCostSingle.FieldName = "is_cost"
        Me.GridColumnIsCostSingle.Name = "GridColumnIsCostSingle"
        '
        'GridView3
        '
        Me.GridView3.GridControl = Me.GCBomDetMat
        Me.GridView3.Name = "GridView3"
        '
        'XTPOvh
        '
        Me.XTPOvh.Controls.Add(Me.GCBomDetOvh)
        Me.XTPOvh.Name = "XTPOvh"
        Me.XTPOvh.Size = New System.Drawing.Size(895, 154)
        Me.XTPOvh.Text = "Overhead"
        '
        'GCBomDetOvh
        '
        Me.GCBomDetOvh.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCBomDetOvh.Location = New System.Drawing.Point(0, 0)
        Me.GCBomDetOvh.MainView = Me.GVBomDetOvh
        Me.GCBomDetOvh.Name = "GCBomDetOvh"
        Me.GCBomDetOvh.Size = New System.Drawing.Size(895, 154)
        Me.GCBomDetOvh.TabIndex = 22
        Me.GCBomDetOvh.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVBomDetOvh, Me.GridView5})
        '
        'GVBomDetOvh
        '
        Me.GVBomDetOvh.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumn15, Me.GridColumn16, Me.GridColumn17, Me.GridColumn19, Me.GridColumn20, Me.GridColumn21})
        Me.GVBomDetOvh.CustomizationFormBounds = New System.Drawing.Rectangle(885, 289, 216, 178)
        Me.GVBomDetOvh.GridControl = Me.GCBomDetOvh
        Me.GVBomDetOvh.GroupSummary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "total", Me.GridColumn21, "")})
        Me.GVBomDetOvh.Name = "GVBomDetOvh"
        Me.GVBomDetOvh.OptionsBehavior.Editable = False
        Me.GVBomDetOvh.OptionsFind.AlwaysVisible = True
        Me.GVBomDetOvh.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never
        Me.GVBomDetOvh.OptionsView.ShowFooter = True
        Me.GVBomDetOvh.OptionsView.ShowGroupPanel = False
        '
        'GridColumn15
        '
        Me.GridColumn15.Caption = "Id Mat"
        Me.GridColumn15.FieldName = "id_bom_det"
        Me.GridColumn15.Name = "GridColumn15"
        '
        'GridColumn16
        '
        Me.GridColumn16.Caption = "Code"
        Me.GridColumn16.FieldName = "overhead_code"
        Me.GridColumn16.Name = "GridColumn16"
        Me.GridColumn16.Visible = True
        Me.GridColumn16.VisibleIndex = 0
        Me.GridColumn16.Width = 89
        '
        'GridColumn17
        '
        Me.GridColumn17.Caption = "Overhead"
        Me.GridColumn17.FieldName = "overhead"
        Me.GridColumn17.Name = "GridColumn17"
        Me.GridColumn17.Visible = True
        Me.GridColumn17.VisibleIndex = 1
        Me.GridColumn17.Width = 250
        '
        'GridColumn19
        '
        Me.GridColumn19.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumn19.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumn19.AppearanceHeader.Options.UseTextOptions = True
        Me.GridColumn19.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumn19.Caption = "Qty"
        Me.GridColumn19.DisplayFormat.FormatString = "N2"
        Me.GridColumn19.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumn19.FieldName = "qty_uom"
        Me.GridColumn19.Name = "GridColumn19"
        Me.GridColumn19.Visible = True
        Me.GridColumn19.VisibleIndex = 2
        Me.GridColumn19.Width = 58
        '
        'GridColumn20
        '
        Me.GridColumn20.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumn20.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumn20.AppearanceHeader.Options.UseTextOptions = True
        Me.GridColumn20.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumn20.Caption = "Unit Price"
        Me.GridColumn20.FieldName = "price"
        Me.GridColumn20.Name = "GridColumn20"
        Me.GridColumn20.Visible = True
        Me.GridColumn20.VisibleIndex = 3
        Me.GridColumn20.Width = 119
        '
        'GridColumn21
        '
        Me.GridColumn21.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumn21.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumn21.AppearanceHeader.Options.UseTextOptions = True
        Me.GridColumn21.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumn21.Caption = "Total"
        Me.GridColumn21.DisplayFormat.FormatString = "N2"
        Me.GridColumn21.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumn21.FieldName = "total"
        Me.GridColumn21.Name = "GridColumn21"
        Me.GridColumn21.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "total", "{0:N2}")})
        Me.GridColumn21.Visible = True
        Me.GridColumn21.VisibleIndex = 4
        Me.GridColumn21.Width = 129
        '
        'GridView5
        '
        Me.GridView5.GridControl = Me.GCBomDetOvh
        Me.GridView5.Name = "GridView5"
        '
        'XTPWip
        '
        Me.XTPWip.Controls.Add(Me.GCBomDetWip)
        Me.XTPWip.Name = "XTPWip"
        Me.XTPWip.PageVisible = False
        Me.XTPWip.Size = New System.Drawing.Size(895, 154)
        Me.XTPWip.Text = "WIP"
        '
        'GCBomDetWip
        '
        Me.GCBomDetWip.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCBomDetWip.Location = New System.Drawing.Point(0, 0)
        Me.GCBomDetWip.MainView = Me.GVBomDetWip
        Me.GCBomDetWip.Name = "GCBomDetWip"
        Me.GCBomDetWip.Size = New System.Drawing.Size(895, 154)
        Me.GCBomDetWip.TabIndex = 22
        Me.GCBomDetWip.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVBomDetWip, Me.GridView9})
        '
        'GVBomDetWip
        '
        Me.GVBomDetWip.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumn29, Me.GridColumn30, Me.GridColumn31, Me.GridColumn32, Me.GridColumn33, Me.GridColumn34, Me.GridColumn35})
        Me.GVBomDetWip.CustomizationFormBounds = New System.Drawing.Rectangle(885, 289, 216, 178)
        Me.GVBomDetWip.GridControl = Me.GCBomDetWip
        Me.GVBomDetWip.GroupSummary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "total", Me.GridColumn35, "")})
        Me.GVBomDetWip.Name = "GVBomDetWip"
        Me.GVBomDetWip.OptionsBehavior.Editable = False
        Me.GVBomDetWip.OptionsFind.AlwaysVisible = True
        Me.GVBomDetWip.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never
        Me.GVBomDetWip.OptionsView.ShowFooter = True
        Me.GVBomDetWip.OptionsView.ShowGroupPanel = False
        '
        'GridColumn29
        '
        Me.GridColumn29.Caption = "Id Mat"
        Me.GridColumn29.FieldName = "id_bom_det"
        Me.GridColumn29.Name = "GridColumn29"
        '
        'GridColumn30
        '
        Me.GridColumn30.Caption = "Code"
        Me.GridColumn30.FieldName = "code"
        Me.GridColumn30.Name = "GridColumn30"
        Me.GridColumn30.Visible = True
        Me.GridColumn30.VisibleIndex = 0
        Me.GridColumn30.Width = 89
        '
        'GridColumn31
        '
        Me.GridColumn31.Caption = "Product"
        Me.GridColumn31.FieldName = "name"
        Me.GridColumn31.Name = "GridColumn31"
        Me.GridColumn31.Visible = True
        Me.GridColumn31.VisibleIndex = 1
        Me.GridColumn31.Width = 250
        '
        'GridColumn32
        '
        Me.GridColumn32.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumn32.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridColumn32.AppearanceHeader.Options.UseTextOptions = True
        Me.GridColumn32.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridColumn32.Caption = "Size"
        Me.GridColumn32.FieldName = "size"
        Me.GridColumn32.Name = "GridColumn32"
        Me.GridColumn32.Visible = True
        Me.GridColumn32.VisibleIndex = 2
        Me.GridColumn32.Width = 32
        '
        'GridColumn33
        '
        Me.GridColumn33.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumn33.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumn33.AppearanceHeader.Options.UseTextOptions = True
        Me.GridColumn33.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumn33.Caption = "Qty"
        Me.GridColumn33.DisplayFormat.FormatString = "N2"
        Me.GridColumn33.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumn33.FieldName = "qty_uom"
        Me.GridColumn33.Name = "GridColumn33"
        Me.GridColumn33.Visible = True
        Me.GridColumn33.VisibleIndex = 3
        Me.GridColumn33.Width = 58
        '
        'GridColumn34
        '
        Me.GridColumn34.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumn34.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumn34.AppearanceHeader.Options.UseTextOptions = True
        Me.GridColumn34.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumn34.Caption = "Unit Price"
        Me.GridColumn34.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumn34.FieldName = "price"
        Me.GridColumn34.Name = "GridColumn34"
        Me.GridColumn34.Visible = True
        Me.GridColumn34.VisibleIndex = 4
        Me.GridColumn34.Width = 119
        '
        'GridColumn35
        '
        Me.GridColumn35.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumn35.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumn35.AppearanceHeader.Options.UseTextOptions = True
        Me.GridColumn35.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumn35.Caption = "Total"
        Me.GridColumn35.DisplayFormat.FormatString = "N2"
        Me.GridColumn35.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumn35.FieldName = "total"
        Me.GridColumn35.Name = "GridColumn35"
        Me.GridColumn35.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "total", "{0:N2}")})
        Me.GridColumn35.Visible = True
        Me.GridColumn35.VisibleIndex = 5
        Me.GridColumn35.Width = 129
        '
        'GridView9
        '
        Me.GridView9.GridControl = Me.GCBomDetWip
        Me.GridView9.Name = "GridView9"
        '
        'XTCBOMSelection
        '
        Me.XTCBOMSelection.Dock = System.Windows.Forms.DockStyle.Fill
        Me.XTCBOMSelection.HeaderLocation = DevExpress.XtraTab.TabHeaderLocation.Left
        Me.XTCBOMSelection.Location = New System.Drawing.Point(0, 0)
        Me.XTCBOMSelection.Name = "XTCBOMSelection"
        Me.XTCBOMSelection.SelectedTabPage = Me.XTPPerPD
        Me.XTCBOMSelection.Size = New System.Drawing.Size(934, 498)
        Me.XTCBOMSelection.TabIndex = 4
        Me.XTCBOMSelection.TabPages.AddRange(New DevExpress.XtraTab.XtraTabPage() {Me.XTPPerPD, Me.XTPPerProduct, Me.XTPPerDesign})
        '
        'XTPPerPD
        '
        Me.XTPPerPD.Controls.Add(Me.SplitContainerControl3)
        Me.XTPPerPD.Name = "XTPPerPD"
        Me.XTPPerPD.Size = New System.Drawing.Size(905, 492)
        Me.XTPPerPD.Text = "PD"
        '
        'SplitContainerControl3
        '
        Me.SplitContainerControl3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainerControl3.FixedPanel = DevExpress.XtraEditors.SplitFixedPanel.None
        Me.SplitContainerControl3.Horizontal = False
        Me.SplitContainerControl3.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainerControl3.Name = "SplitContainerControl3"
        Me.SplitContainerControl3.Panel1.Controls.Add(Me.GCDesign)
        Me.SplitContainerControl3.Panel1.Text = "Panel1"
        Me.SplitContainerControl3.Panel2.Controls.Add(Me.GroupControl6)
        Me.SplitContainerControl3.Panel2.Text = "Panel2"
        Me.SplitContainerControl3.Size = New System.Drawing.Size(905, 492)
        Me.SplitContainerControl3.SplitterPosition = 283
        Me.SplitContainerControl3.TabIndex = 4
        Me.SplitContainerControl3.Text = "SplitContainerControl3"
        '
        'GCDesign
        '
        Me.GCDesign.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCDesign.Location = New System.Drawing.Point(0, 0)
        Me.GCDesign.MainView = Me.GVDesign
        Me.GCDesign.Name = "GCDesign"
        Me.GCDesign.Size = New System.Drawing.Size(905, 283)
        Me.GCDesign.TabIndex = 4
        Me.GCDesign.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVDesign, Me.GridView2})
        '
        'GVDesign
        '
        Me.GVDesign.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumn11, Me.GridColumn59, Me.GridColumn60, Me.GridColumn61, Me.GridColumn62, Me.GridColumn63, Me.GridColumn64, Me.GridColumn65, Me.GridColumn66, Me.GridColumn67, Me.GridColumn68, Me.GridColumn69})
        Me.GVDesign.GridControl = Me.GCDesign
        Me.GVDesign.GroupCount = 1
        Me.GVDesign.Name = "GVDesign"
        Me.GVDesign.OptionsBehavior.Editable = False
        Me.GVDesign.OptionsCustomization.AllowGroup = False
        Me.GVDesign.OptionsView.ShowGroupPanel = False
        Me.GVDesign.SortInfo.AddRange(New DevExpress.XtraGrid.Columns.GridColumnSortInfo() {New DevExpress.XtraGrid.Columns.GridColumnSortInfo(Me.GridColumn62, DevExpress.Data.ColumnSortOrder.Descending), New DevExpress.XtraGrid.Columns.GridColumnSortInfo(Me.GridColumn11, DevExpress.Data.ColumnSortOrder.Descending)})
        '
        'GridColumn11
        '
        Me.GridColumn11.Caption = "Id Design"
        Me.GridColumn11.FieldName = "id_design"
        Me.GridColumn11.Name = "GridColumn11"
        '
        'GridColumn59
        '
        Me.GridColumn59.Caption = "Short Description"
        Me.GridColumn59.FieldName = "design_display_name"
        Me.GridColumn59.Name = "GridColumn59"
        Me.GridColumn59.Width = 92
        '
        'GridColumn60
        '
        Me.GridColumn60.Caption = "Description"
        Me.GridColumn60.FieldName = "design_name"
        Me.GridColumn60.Name = "GridColumn60"
        Me.GridColumn60.Visible = True
        Me.GridColumn60.VisibleIndex = 2
        Me.GridColumn60.Width = 247
        '
        'GridColumn61
        '
        Me.GridColumn61.Caption = "UOM"
        Me.GridColumn61.FieldName = "id_uom"
        Me.GridColumn61.Name = "GridColumn61"
        '
        'GridColumn62
        '
        Me.GridColumn62.Caption = "Season"
        Me.GridColumn62.FieldName = "season"
        Me.GridColumn62.FieldNameSortGroup = "id_season"
        Me.GridColumn62.Name = "GridColumn62"
        '
        'GridColumn63
        '
        Me.GridColumn63.Caption = "Code"
        Me.GridColumn63.FieldName = "design_code"
        Me.GridColumn63.Name = "GridColumn63"
        Me.GridColumn63.Visible = True
        Me.GridColumn63.VisibleIndex = 1
        Me.GridColumn63.Width = 230
        '
        'GridColumn64
        '
        Me.GridColumn64.Caption = "Design Orign"
        Me.GridColumn64.FieldName = "orign"
        Me.GridColumn64.Name = "GridColumn64"
        Me.GridColumn64.Width = 120
        '
        'GridColumn65
        '
        Me.GridColumn65.Caption = "Season"
        Me.GridColumn65.FieldName = "id_season"
        Me.GridColumn65.Name = "GridColumn65"
        '
        'GridColumn66
        '
        Me.GridColumn66.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumn66.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridColumn66.AppearanceHeader.Options.UseTextOptions = True
        Me.GridColumn66.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridColumn66.Caption = "Color"
        Me.GridColumn66.FieldName = "color"
        Me.GridColumn66.Name = "GridColumn66"
        Me.GridColumn66.Visible = True
        Me.GridColumn66.VisibleIndex = 3
        Me.GridColumn66.Width = 167
        '
        'GridColumn67
        '
        Me.GridColumn67.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumn67.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridColumn67.AppearanceHeader.Options.UseTextOptions = True
        Me.GridColumn67.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridColumn67.Caption = "Source"
        Me.GridColumn67.FieldName = "product_source"
        Me.GridColumn67.Name = "GridColumn67"
        Me.GridColumn67.Width = 69
        '
        'GridColumn68
        '
        Me.GridColumn68.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumn68.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridColumn68.AppearanceHeader.Options.UseTextOptions = True
        Me.GridColumn68.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridColumn68.Caption = "Class"
        Me.GridColumn68.FieldName = "class"
        Me.GridColumn68.Name = "GridColumn68"
        Me.GridColumn68.Visible = True
        Me.GridColumn68.VisibleIndex = 0
        Me.GridColumn68.Width = 160
        '
        'GridColumn69
        '
        Me.GridColumn69.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumn69.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumn69.AppearanceHeader.Options.UseTextOptions = True
        Me.GridColumn69.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumn69.Caption = "Qty"
        Me.GridColumn69.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumn69.FieldName = "qty"
        Me.GridColumn69.Name = "GridColumn69"
        Me.GridColumn69.Visible = True
        Me.GridColumn69.VisibleIndex = 4
        Me.GridColumn69.Width = 113
        '
        'GridView2
        '
        Me.GridView2.GridControl = Me.GCDesign
        Me.GridView2.Name = "GridView2"
        '
        'GroupControl6
        '
        Me.GroupControl6.Controls.Add(Me.GCBOMDesign)
        Me.GroupControl6.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupControl6.Location = New System.Drawing.Point(0, 0)
        Me.GroupControl6.Name = "GroupControl6"
        Me.GroupControl6.Size = New System.Drawing.Size(905, 204)
        Me.GroupControl6.TabIndex = 1
        Me.GroupControl6.Text = "BOM"
        '
        'GCBOMDesign
        '
        Me.GCBOMDesign.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCBOMDesign.Location = New System.Drawing.Point(2, 20)
        Me.GCBOMDesign.MainView = Me.GVBOMDesign
        Me.GCBOMDesign.Name = "GCBOMDesign"
        Me.GCBOMDesign.Size = New System.Drawing.Size(901, 182)
        Me.GCBOMDesign.TabIndex = 4
        Me.GCBOMDesign.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVBOMDesign})
        '
        'GVBOMDesign
        '
        Me.GVBOMDesign.AppearancePrint.FooterPanel.BackColor = System.Drawing.Color.White
        Me.GVBOMDesign.AppearancePrint.FooterPanel.BackColor2 = System.Drawing.Color.White
        Me.GVBOMDesign.AppearancePrint.FooterPanel.BorderColor = System.Drawing.Color.Transparent
        Me.GVBOMDesign.AppearancePrint.FooterPanel.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.GVBOMDesign.AppearancePrint.FooterPanel.ForeColor = System.Drawing.Color.Black
        Me.GVBOMDesign.AppearancePrint.FooterPanel.Options.UseBackColor = True
        Me.GVBOMDesign.AppearancePrint.FooterPanel.Options.UseBorderColor = True
        Me.GVBOMDesign.AppearancePrint.FooterPanel.Options.UseFont = True
        Me.GVBOMDesign.AppearancePrint.FooterPanel.Options.UseForeColor = True
        Me.GVBOMDesign.AppearancePrint.GroupFooter.BackColor = System.Drawing.Color.White
        Me.GVBOMDesign.AppearancePrint.GroupFooter.BackColor2 = System.Drawing.Color.White
        Me.GVBOMDesign.AppearancePrint.GroupFooter.BorderColor = System.Drawing.Color.Transparent
        Me.GVBOMDesign.AppearancePrint.GroupFooter.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.GVBOMDesign.AppearancePrint.GroupFooter.ForeColor = System.Drawing.Color.Black
        Me.GVBOMDesign.AppearancePrint.GroupFooter.Options.UseBackColor = True
        Me.GVBOMDesign.AppearancePrint.GroupFooter.Options.UseBorderColor = True
        Me.GVBOMDesign.AppearancePrint.GroupFooter.Options.UseFont = True
        Me.GVBOMDesign.AppearancePrint.GroupFooter.Options.UseForeColor = True
        Me.GVBOMDesign.AppearancePrint.GroupRow.BackColor = System.Drawing.Color.White
        Me.GVBOMDesign.AppearancePrint.GroupRow.BackColor2 = System.Drawing.Color.White
        Me.GVBOMDesign.AppearancePrint.GroupRow.BorderColor = System.Drawing.Color.Transparent
        Me.GVBOMDesign.AppearancePrint.GroupRow.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold)
        Me.GVBOMDesign.AppearancePrint.GroupRow.ForeColor = System.Drawing.Color.Black
        Me.GVBOMDesign.AppearancePrint.GroupRow.Options.UseBackColor = True
        Me.GVBOMDesign.AppearancePrint.GroupRow.Options.UseBorderColor = True
        Me.GVBOMDesign.AppearancePrint.GroupRow.Options.UseFont = True
        Me.GVBOMDesign.AppearancePrint.GroupRow.Options.UseForeColor = True
        Me.GVBOMDesign.AppearancePrint.HeaderPanel.BackColor = System.Drawing.Color.White
        Me.GVBOMDesign.AppearancePrint.HeaderPanel.BackColor2 = System.Drawing.Color.White
        Me.GVBOMDesign.AppearancePrint.HeaderPanel.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.GVBOMDesign.AppearancePrint.HeaderPanel.ForeColor = System.Drawing.Color.Black
        Me.GVBOMDesign.AppearancePrint.HeaderPanel.Options.UseBackColor = True
        Me.GVBOMDesign.AppearancePrint.HeaderPanel.Options.UseFont = True
        Me.GVBOMDesign.AppearancePrint.HeaderPanel.Options.UseForeColor = True
        Me.GVBOMDesign.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Office2003
        Me.GVBOMDesign.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumn14, Me.GridColumn18, Me.GridColumn22, Me.GridColumn23, Me.GridColumn24, Me.ColTotal, Me.Cat, Me.ColIDCat, Me.GridColumn25, Me.GridColumnUOM, Me.GridColumn26, Me.GridColumnIsCop})
        Me.GVBOMDesign.GridControl = Me.GCBOMDesign
        Me.GVBOMDesign.GroupCount = 1
        Me.GVBOMDesign.GroupSummary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "total", Me.ColTotal, "{0:N2}"), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Custom, "price", Me.GridColumn24, "Sub Total{0}")})
        Me.GVBOMDesign.Name = "GVBOMDesign"
        Me.GVBOMDesign.OptionsBehavior.Editable = False
        Me.GVBOMDesign.OptionsPrint.PrintVertLines = False
        Me.GVBOMDesign.OptionsView.ShowFooter = True
        Me.GVBOMDesign.OptionsView.ShowGroupPanel = False
        Me.GVBOMDesign.OptionsView.ShowIndicator = False
        Me.GVBOMDesign.SortInfo.AddRange(New DevExpress.XtraGrid.Columns.GridColumnSortInfo() {New DevExpress.XtraGrid.Columns.GridColumnSortInfo(Me.Cat, DevExpress.Data.ColumnSortOrder.Ascending)})
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
        Me.GridColumn14.Width = 128
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
        Me.GridColumn18.Width = 199
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
        Me.GridColumn22.Width = 52
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
        Me.GridColumn23.Width = 69
        '
        'GridColumn24
        '
        Me.GridColumn24.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumn24.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumn24.AppearanceHeader.Options.UseTextOptions = True
        Me.GridColumn24.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumn24.Caption = "Cost"
        Me.GridColumn24.DisplayFormat.FormatString = "N4"
        Me.GridColumn24.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumn24.FieldName = "price"
        Me.GridColumn24.Name = "GridColumn24"
        Me.GridColumn24.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Custom, "price", "Total")})
        Me.GridColumn24.Visible = True
        Me.GridColumn24.VisibleIndex = 6
        Me.GridColumn24.Width = 146
        '
        'ColTotal
        '
        Me.ColTotal.AppearanceCell.Options.UseTextOptions = True
        Me.ColTotal.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.ColTotal.AppearanceHeader.Options.UseTextOptions = True
        Me.ColTotal.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.ColTotal.Caption = "Total"
        Me.ColTotal.DisplayFormat.FormatString = "N4"
        Me.ColTotal.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.ColTotal.FieldName = "total"
        Me.ColTotal.Name = "ColTotal"
        Me.ColTotal.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "total", "{0:N2}")})
        Me.ColTotal.Visible = True
        Me.ColTotal.VisibleIndex = 7
        Me.ColTotal.Width = 171
        '
        'Cat
        '
        Me.Cat.Caption = "Category"
        Me.Cat.FieldName = "component_category"
        Me.Cat.FieldNameSortGroup = "id_component_category"
        Me.Cat.Name = "Cat"
        Me.Cat.Visible = True
        Me.Cat.VisibleIndex = 8
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
        Me.GridColumnUOM.Width = 63
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
        Me.GridColumn26.Width = 71
        '
        'GridColumnIsCop
        '
        Me.GridColumnIsCop.Caption = "Is COP"
        Me.GridColumnIsCop.FieldName = "is_cost"
        Me.GridColumnIsCop.Name = "GridColumnIsCop"
        '
        'XTPPerProduct
        '
        Me.XTPPerProduct.Controls.Add(Me.SplitContainerControl1)
        Me.XTPPerProduct.Name = "XTPPerProduct"
        Me.XTPPerProduct.PageVisible = False
        Me.XTPPerProduct.Size = New System.Drawing.Size(905, 492)
        Me.XTPPerProduct.Text = "Product"
        '
        'XTPPerDesign
        '
        Me.XTPPerDesign.Controls.Add(Me.SplitContainerControl4)
        Me.XTPPerDesign.Name = "XTPPerDesign"
        Me.XTPPerDesign.PageVisible = False
        Me.XTPPerDesign.Size = New System.Drawing.Size(905, 492)
        Me.XTPPerDesign.Text = "Design"
        '
        'SplitContainerControl4
        '
        Me.SplitContainerControl4.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainerControl4.FixedPanel = DevExpress.XtraEditors.SplitFixedPanel.None
        Me.SplitContainerControl4.Horizontal = False
        Me.SplitContainerControl4.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainerControl4.Name = "SplitContainerControl4"
        Me.SplitContainerControl4.Panel1.Controls.Add(Me.SplitContainerControl5)
        Me.SplitContainerControl4.Panel1.Text = "Panel1"
        Me.SplitContainerControl4.Panel2.Controls.Add(Me.GroupControl4)
        Me.SplitContainerControl4.Panel2.Text = "Panel2"
        Me.SplitContainerControl4.Size = New System.Drawing.Size(905, 492)
        Me.SplitContainerControl4.SplitterPosition = 283
        Me.SplitContainerControl4.TabIndex = 5
        Me.SplitContainerControl4.Text = "SplitContainerControl4"
        '
        'SplitContainerControl5
        '
        Me.SplitContainerControl5.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainerControl5.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainerControl5.Name = "SplitContainerControl5"
        Me.SplitContainerControl5.Panel1.Controls.Add(Me.GCPerDesign)
        Me.SplitContainerControl5.Panel1.Controls.Add(Me.PanelControl3)
        Me.SplitContainerControl5.Panel1.Text = "Panel1"
        Me.SplitContainerControl5.Panel2.Controls.Add(Me.GroupControl5)
        Me.SplitContainerControl5.Panel2.Text = "Panel2"
        Me.SplitContainerControl5.Size = New System.Drawing.Size(905, 283)
        Me.SplitContainerControl5.SplitterPosition = 616
        Me.SplitContainerControl5.TabIndex = 5
        Me.SplitContainerControl5.Text = "SplitContainerControl5"
        '
        'GCPerDesign
        '
        Me.GCPerDesign.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCPerDesign.Location = New System.Drawing.Point(0, 37)
        Me.GCPerDesign.MainView = Me.GVPerDesign
        Me.GCPerDesign.Name = "GCPerDesign"
        Me.GCPerDesign.Size = New System.Drawing.Size(616, 246)
        Me.GCPerDesign.TabIndex = 4
        Me.GCPerDesign.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVPerDesign, Me.GridView4})
        '
        'GVPerDesign
        '
        Me.GVPerDesign.AppearancePrint.HeaderPanel.BackColor = System.Drawing.Color.Transparent
        Me.GVPerDesign.AppearancePrint.HeaderPanel.Options.UseBackColor = True
        Me.GVPerDesign.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumn28, Me.GridColumn36, Me.GridColumn37, Me.GridColumn38, Me.GridColumn39, Me.GridColumn40, Me.GridColumn41, Me.GridColumn42, Me.GridColumn43, Me.GridColumn44, Me.GridColumn45, Me.GridColumnUnitCost, Me.GridColumn52, Me.GridColumn55, Me.GridColumn56, Me.GridColumn57, Me.GridColumnStatusLineList})
        Me.GVPerDesign.GridControl = Me.GCPerDesign
        Me.GVPerDesign.GroupCount = 1
        Me.GVPerDesign.Name = "GVPerDesign"
        Me.GVPerDesign.OptionsBehavior.Editable = False
        Me.GVPerDesign.OptionsCustomization.AllowGroup = False
        Me.GVPerDesign.OptionsView.ShowGroupPanel = False
        Me.GVPerDesign.SortInfo.AddRange(New DevExpress.XtraGrid.Columns.GridColumnSortInfo() {New DevExpress.XtraGrid.Columns.GridColumnSortInfo(Me.GridColumn39, DevExpress.Data.ColumnSortOrder.Descending), New DevExpress.XtraGrid.Columns.GridColumnSortInfo(Me.GridColumn28, DevExpress.Data.ColumnSortOrder.Descending)})
        '
        'GridColumn28
        '
        Me.GridColumn28.Caption = "Id Design"
        Me.GridColumn28.FieldName = "id_design"
        Me.GridColumn28.Name = "GridColumn28"
        '
        'GridColumn36
        '
        Me.GridColumn36.Caption = "Short Description"
        Me.GridColumn36.FieldName = "design_display_name"
        Me.GridColumn36.Name = "GridColumn36"
        Me.GridColumn36.Width = 92
        '
        'GridColumn37
        '
        Me.GridColumn37.Caption = "Description"
        Me.GridColumn37.FieldName = "design_name"
        Me.GridColumn37.Name = "GridColumn37"
        Me.GridColumn37.Visible = True
        Me.GridColumn37.VisibleIndex = 3
        Me.GridColumn37.Width = 129
        '
        'GridColumn38
        '
        Me.GridColumn38.Caption = "UOM"
        Me.GridColumn38.FieldName = "id_uom"
        Me.GridColumn38.Name = "GridColumn38"
        '
        'GridColumn39
        '
        Me.GridColumn39.Caption = "Season"
        Me.GridColumn39.FieldName = "season"
        Me.GridColumn39.FieldNameSortGroup = "id_season"
        Me.GridColumn39.Name = "GridColumn39"
        '
        'GridColumn40
        '
        Me.GridColumn40.Caption = "Code"
        Me.GridColumn40.FieldName = "design_code"
        Me.GridColumn40.Name = "GridColumn40"
        Me.GridColumn40.Visible = True
        Me.GridColumn40.VisibleIndex = 2
        Me.GridColumn40.Width = 120
        '
        'GridColumn41
        '
        Me.GridColumn41.Caption = "Design Orign"
        Me.GridColumn41.FieldName = "orign"
        Me.GridColumn41.Name = "GridColumn41"
        Me.GridColumn41.Width = 120
        '
        'GridColumn42
        '
        Me.GridColumn42.Caption = "Season"
        Me.GridColumn42.FieldName = "id_season"
        Me.GridColumn42.Name = "GridColumn42"
        '
        'GridColumn43
        '
        Me.GridColumn43.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumn43.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridColumn43.AppearanceHeader.Options.UseTextOptions = True
        Me.GridColumn43.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridColumn43.Caption = "Color"
        Me.GridColumn43.FieldName = "color_display"
        Me.GridColumn43.Name = "GridColumn43"
        Me.GridColumn43.Visible = True
        Me.GridColumn43.VisibleIndex = 4
        Me.GridColumn43.Width = 69
        '
        'GridColumn44
        '
        Me.GridColumn44.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumn44.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridColumn44.AppearanceHeader.Options.UseTextOptions = True
        Me.GridColumn44.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridColumn44.Caption = "Source"
        Me.GridColumn44.FieldName = "product_source"
        Me.GridColumn44.Name = "GridColumn44"
        Me.GridColumn44.Visible = True
        Me.GridColumn44.VisibleIndex = 0
        Me.GridColumn44.Width = 41
        '
        'GridColumn45
        '
        Me.GridColumn45.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumn45.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridColumn45.AppearanceHeader.Options.UseTextOptions = True
        Me.GridColumn45.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridColumn45.Caption = "Class"
        Me.GridColumn45.FieldName = "product_class_display"
        Me.GridColumn45.Name = "GridColumn45"
        Me.GridColumn45.Visible = True
        Me.GridColumn45.VisibleIndex = 1
        Me.GridColumn45.Width = 82
        '
        'GridColumnUnitCost
        '
        Me.GridColumnUnitCost.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumnUnitCost.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumnUnitCost.AppearanceHeader.Options.UseTextOptions = True
        Me.GridColumnUnitCost.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumnUnitCost.Caption = "ECOP BOM"
        Me.GridColumnUnitCost.DisplayFormat.FormatString = "N2"
        Me.GridColumnUnitCost.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumnUnitCost.FieldName = "prod_order_cop_bom"
        Me.GridColumnUnitCost.Name = "GridColumnUnitCost"
        Me.GridColumnUnitCost.Visible = True
        Me.GridColumnUnitCost.VisibleIndex = 5
        Me.GridColumnUnitCost.Width = 45
        '
        'GridColumn52
        '
        Me.GridColumn52.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumn52.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumn52.AppearanceHeader.Options.UseTextOptions = True
        Me.GridColumn52.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumn52.Caption = "COP Final"
        Me.GridColumn52.DisplayFormat.FormatString = "N2"
        Me.GridColumn52.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumn52.FieldName = "design_cop"
        Me.GridColumn52.Name = "GridColumn52"
        Me.GridColumn52.Visible = True
        Me.GridColumn52.VisibleIndex = 6
        Me.GridColumn52.Width = 47
        '
        'GridColumn55
        '
        Me.GridColumn55.Caption = "kurs"
        Me.GridColumn55.FieldName = "kurs_ecop"
        Me.GridColumn55.Name = "GridColumn55"
        '
        'GridColumn56
        '
        Me.GridColumn56.Caption = "currency"
        Me.GridColumn56.FieldName = "cur_ecop"
        Me.GridColumn56.Name = "GridColumn56"
        '
        'GridColumn57
        '
        Me.GridColumn57.Caption = "vendor"
        Me.GridColumn57.FieldName = "vend_ecop"
        Me.GridColumn57.Name = "GridColumn57"
        '
        'GridColumnStatusLineList
        '
        Me.GridColumnStatusLineList.Caption = "Status"
        Me.GridColumnStatusLineList.FieldName = "lookup_status_order"
        Me.GridColumnStatusLineList.Name = "GridColumnStatusLineList"
        Me.GridColumnStatusLineList.Visible = True
        Me.GridColumnStatusLineList.VisibleIndex = 7
        Me.GridColumnStatusLineList.Width = 65
        '
        'GridView4
        '
        Me.GridView4.GridControl = Me.GCPerDesign
        Me.GridView4.Name = "GridView4"
        '
        'PanelControl3
        '
        Me.PanelControl3.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
        Me.PanelControl3.Controls.Add(Me.BtnView)
        Me.PanelControl3.Controls.Add(Me.BPrint)
        Me.PanelControl3.Controls.Add(Me.SLESeason)
        Me.PanelControl3.Controls.Add(Me.LabelControl4)
        Me.PanelControl3.Dock = System.Windows.Forms.DockStyle.Top
        Me.PanelControl3.Location = New System.Drawing.Point(0, 0)
        Me.PanelControl3.Name = "PanelControl3"
        Me.PanelControl3.Size = New System.Drawing.Size(616, 37)
        Me.PanelControl3.TabIndex = 5
        '
        'BtnView
        '
        Me.BtnView.Dock = System.Windows.Forms.DockStyle.Right
        Me.BtnView.ImageIndex = 15
        Me.BtnView.ImageList = Me.LargeImageCollection
        Me.BtnView.Location = New System.Drawing.Point(422, 0)
        Me.BtnView.Name = "BtnView"
        Me.BtnView.Size = New System.Drawing.Size(83, 37)
        Me.BtnView.TabIndex = 98
        Me.BtnView.Text = "View"
        '
        'BPrint
        '
        Me.BPrint.Dock = System.Windows.Forms.DockStyle.Right
        Me.BPrint.ImageIndex = 15
        Me.BPrint.ImageList = Me.LargeImageCollection
        Me.BPrint.Location = New System.Drawing.Point(505, 0)
        Me.BPrint.Name = "BPrint"
        Me.BPrint.Size = New System.Drawing.Size(111, 37)
        Me.BPrint.TabIndex = 99
        Me.BPrint.Text = "Print Format Import"
        '
        'SLESeason
        '
        Me.SLESeason.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.SLESeason.Location = New System.Drawing.Point(51, 8)
        Me.SLESeason.Name = "SLESeason"
        Me.SLESeason.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SLESeason.Properties.Appearance.Options.UseFont = True
        Me.SLESeason.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.SLESeason.Properties.View = Me.SearchLookUpEdit1View
        Me.SLESeason.Size = New System.Drawing.Size(353, 20)
        Me.SLESeason.TabIndex = 97
        '
        'SearchLookUpEdit1View
        '
        Me.SearchLookUpEdit1View.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumn51, Me.GridColumnRange, Me.GridColumnSeason})
        Me.SearchLookUpEdit1View.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
        Me.SearchLookUpEdit1View.Name = "SearchLookUpEdit1View"
        Me.SearchLookUpEdit1View.OptionsSelection.EnableAppearanceFocusedCell = False
        Me.SearchLookUpEdit1View.OptionsView.ShowGroupPanel = False
        '
        'GridColumn51
        '
        Me.GridColumn51.Caption = "Id Season"
        Me.GridColumn51.FieldName = "id_season"
        Me.GridColumn51.Name = "GridColumn51"
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
        Me.LabelControl4.Location = New System.Drawing.Point(10, 11)
        Me.LabelControl4.Name = "LabelControl4"
        Me.LabelControl4.Size = New System.Drawing.Size(35, 13)
        Me.LabelControl4.TabIndex = 96
        Me.LabelControl4.Text = "Season"
        '
        'GroupControl5
        '
        Me.GroupControl5.Controls.Add(Me.GCBOMPerDesign)
        Me.GroupControl5.Controls.Add(Me.PanelControl2)
        Me.GroupControl5.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupControl5.Location = New System.Drawing.Point(0, 0)
        Me.GroupControl5.Name = "GroupControl5"
        Me.GroupControl5.Size = New System.Drawing.Size(284, 283)
        Me.GroupControl5.TabIndex = 2
        Me.GroupControl5.Text = "BOM"
        '
        'GCBOMPerDesign
        '
        Me.GCBOMPerDesign.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCBOMPerDesign.Location = New System.Drawing.Point(2, 52)
        Me.GCBOMPerDesign.MainView = Me.GVBOMPerDesign
        Me.GCBOMPerDesign.Name = "GCBOMPerDesign"
        Me.GCBOMPerDesign.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.RepositoryItemCheckEdit1})
        Me.GCBOMPerDesign.Size = New System.Drawing.Size(280, 229)
        Me.GCBOMPerDesign.TabIndex = 1
        Me.GCBOMPerDesign.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVBOMPerDesign})
        '
        'GVBOMPerDesign
        '
        Me.GVBOMPerDesign.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumn48, Me.GridColumn70, Me.GridColumn71, Me.GridColumn72, Me.GridColumn73, Me.GridColumn74, Me.GridColumn75, Me.GridColumn76, Me.GridColumn77, Me.GridColumn78, Me.GridColumnIdBOMApprove})
        Me.GVBOMPerDesign.GridControl = Me.GCBOMPerDesign
        Me.GVBOMPerDesign.Name = "GVBOMPerDesign"
        Me.GVBOMPerDesign.OptionsBehavior.Editable = False
        Me.GVBOMPerDesign.OptionsView.ShowGroupPanel = False
        '
        'GridColumn48
        '
        Me.GridColumn48.Caption = "Id Bom"
        Me.GridColumn48.FieldName = "id_bom"
        Me.GridColumn48.Name = "GridColumn48"
        '
        'GridColumn70
        '
        Me.GridColumn70.Caption = "Method"
        Me.GridColumn70.FieldName = "bom_name"
        Me.GridColumn70.Name = "GridColumn70"
        Me.GridColumn70.Visible = True
        Me.GridColumn70.VisibleIndex = 1
        '
        'GridColumn71
        '
        Me.GridColumn71.Caption = "Term"
        Me.GridColumn71.FieldName = "term_production"
        Me.GridColumn71.Name = "GridColumn71"
        Me.GridColumn71.Visible = True
        Me.GridColumn71.VisibleIndex = 0
        '
        'GridColumn72
        '
        Me.GridColumn72.Caption = "Date Created"
        Me.GridColumn72.FieldName = "bom_date_created"
        Me.GridColumn72.Name = "GridColumn72"
        Me.GridColumn72.Visible = True
        Me.GridColumn72.VisibleIndex = 4
        '
        'GridColumn73
        '
        Me.GridColumn73.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumn73.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumn73.AppearanceHeader.Options.UseTextOptions = True
        Me.GridColumn73.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumn73.Caption = "Unit Price"
        Me.GridColumn73.DisplayFormat.FormatString = "N2"
        Me.GridColumn73.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumn73.FieldName = "bom_unit_price"
        Me.GridColumn73.Name = "GridColumn73"
        Me.GridColumn73.Visible = True
        Me.GridColumn73.VisibleIndex = 3
        '
        'GridColumn74
        '
        Me.GridColumn74.Caption = "GridColumn8"
        Me.GridColumn74.FieldName = "id_report_status"
        Me.GridColumn74.Name = "GridColumn74"
        '
        'GridColumn75
        '
        Me.GridColumn75.Caption = "Status"
        Me.GridColumn75.FieldName = "report_status"
        Me.GridColumn75.Name = "GridColumn75"
        '
        'GridColumn76
        '
        Me.GridColumn76.AppearanceHeader.Options.UseTextOptions = True
        Me.GridColumn76.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridColumn76.Caption = "Default"
        Me.GridColumn76.ColumnEdit = Me.RepositoryItemCheckEdit1
        Me.GridColumn76.FieldName = "is_default"
        Me.GridColumn76.Name = "GridColumn76"
        Me.GridColumn76.Visible = True
        Me.GridColumn76.VisibleIndex = 5
        '
        'RepositoryItemCheckEdit1
        '
        Me.RepositoryItemCheckEdit1.AutoHeight = False
        Me.RepositoryItemCheckEdit1.Name = "RepositoryItemCheckEdit1"
        Me.RepositoryItemCheckEdit1.ValueChecked = "yes"
        Me.RepositoryItemCheckEdit1.ValueUnchecked = "no"
        '
        'GridColumn77
        '
        Me.GridColumn77.Caption = "Id Currency"
        Me.GridColumn77.FieldName = "id_currency"
        Me.GridColumn77.Name = "GridColumn77"
        '
        'GridColumn78
        '
        Me.GridColumn78.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumn78.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridColumn78.AppearanceHeader.Options.UseTextOptions = True
        Me.GridColumn78.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridColumn78.Caption = "Currency"
        Me.GridColumn78.FieldName = "currency"
        Me.GridColumn78.Name = "GridColumn78"
        Me.GridColumn78.Visible = True
        Me.GridColumn78.VisibleIndex = 2
        '
        'GridColumnIdBOMApprove
        '
        Me.GridColumnIdBOMApprove.Caption = "ID BOM Approve"
        Me.GridColumnIdBOMApprove.FieldName = "id_bom_approve"
        Me.GridColumnIdBOMApprove.Name = "GridColumnIdBOMApprove"
        '
        'PanelControl2
        '
        Me.PanelControl2.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
        Me.PanelControl2.Controls.Add(Me.BImportExcel)
        Me.PanelControl2.Controls.Add(Me.BDefaultBOM)
        Me.PanelControl2.Dock = System.Windows.Forms.DockStyle.Top
        Me.PanelControl2.Location = New System.Drawing.Point(2, 20)
        Me.PanelControl2.Name = "PanelControl2"
        Me.PanelControl2.Size = New System.Drawing.Size(280, 32)
        Me.PanelControl2.TabIndex = 2
        '
        'BImportExcel
        '
        Me.BImportExcel.Dock = System.Windows.Forms.DockStyle.Left
        Me.BImportExcel.ImageIndex = 0
        Me.BImportExcel.ImageList = Me.LargeImageCollection
        Me.BImportExcel.Location = New System.Drawing.Point(0, 0)
        Me.BImportExcel.Name = "BImportExcel"
        Me.BImportExcel.Size = New System.Drawing.Size(122, 32)
        Me.BImportExcel.TabIndex = 2
        Me.BImportExcel.Text = "Import Excel"
        '
        'BDefaultBOM
        '
        Me.BDefaultBOM.Dock = System.Windows.Forms.DockStyle.Right
        Me.BDefaultBOM.ImageIndex = 2
        Me.BDefaultBOM.ImageList = Me.LargeImageCollection
        Me.BDefaultBOM.Location = New System.Drawing.Point(158, 0)
        Me.BDefaultBOM.Name = "BDefaultBOM"
        Me.BDefaultBOM.Size = New System.Drawing.Size(122, 32)
        Me.BDefaultBOM.TabIndex = 0
        Me.BDefaultBOM.Text = "Set As Default"
        '
        'GroupControl4
        '
        Me.GroupControl4.Controls.Add(Me.GCCompPerDesign)
        Me.GroupControl4.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupControl4.Location = New System.Drawing.Point(0, 0)
        Me.GroupControl4.Name = "GroupControl4"
        Me.GroupControl4.Size = New System.Drawing.Size(905, 204)
        Me.GroupControl4.TabIndex = 1
        Me.GroupControl4.Text = "BOM"
        '
        'GCCompPerDesign
        '
        Me.GCCompPerDesign.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCCompPerDesign.Location = New System.Drawing.Point(2, 20)
        Me.GCCompPerDesign.MainView = Me.GVCompPerDesign
        Me.GCCompPerDesign.Name = "GCCompPerDesign"
        Me.GCCompPerDesign.Size = New System.Drawing.Size(901, 182)
        Me.GCCompPerDesign.TabIndex = 5
        Me.GCCompPerDesign.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVCompPerDesign})
        '
        'GVCompPerDesign
        '
        Me.GVCompPerDesign.Appearance.Row.Font = New System.Drawing.Font("Tahoma", 7.0!)
        Me.GVCompPerDesign.Appearance.Row.Options.UseFont = True
        Me.GVCompPerDesign.AppearancePrint.FooterPanel.BackColor = System.Drawing.Color.White
        Me.GVCompPerDesign.AppearancePrint.FooterPanel.BackColor2 = System.Drawing.Color.White
        Me.GVCompPerDesign.AppearancePrint.FooterPanel.BorderColor = System.Drawing.SystemColors.ActiveBorder
        Me.GVCompPerDesign.AppearancePrint.FooterPanel.Font = New System.Drawing.Font("Tahoma", 7.0!, System.Drawing.FontStyle.Bold)
        Me.GVCompPerDesign.AppearancePrint.FooterPanel.ForeColor = System.Drawing.Color.Black
        Me.GVCompPerDesign.AppearancePrint.FooterPanel.Options.UseBackColor = True
        Me.GVCompPerDesign.AppearancePrint.FooterPanel.Options.UseBorderColor = True
        Me.GVCompPerDesign.AppearancePrint.FooterPanel.Options.UseFont = True
        Me.GVCompPerDesign.AppearancePrint.FooterPanel.Options.UseForeColor = True
        Me.GVCompPerDesign.AppearancePrint.GroupFooter.BackColor = System.Drawing.Color.White
        Me.GVCompPerDesign.AppearancePrint.GroupFooter.BackColor2 = System.Drawing.Color.White
        Me.GVCompPerDesign.AppearancePrint.GroupFooter.Font = New System.Drawing.Font("Tahoma", 7.0!, System.Drawing.FontStyle.Bold)
        Me.GVCompPerDesign.AppearancePrint.GroupFooter.ForeColor = System.Drawing.Color.Black
        Me.GVCompPerDesign.AppearancePrint.GroupFooter.Options.UseBackColor = True
        Me.GVCompPerDesign.AppearancePrint.GroupFooter.Options.UseFont = True
        Me.GVCompPerDesign.AppearancePrint.GroupFooter.Options.UseForeColor = True
        Me.GVCompPerDesign.AppearancePrint.GroupRow.BackColor = System.Drawing.Color.White
        Me.GVCompPerDesign.AppearancePrint.GroupRow.BackColor2 = System.Drawing.Color.White
        Me.GVCompPerDesign.AppearancePrint.GroupRow.BorderColor = System.Drawing.Color.Black
        Me.GVCompPerDesign.AppearancePrint.GroupRow.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold)
        Me.GVCompPerDesign.AppearancePrint.GroupRow.ForeColor = System.Drawing.Color.Black
        Me.GVCompPerDesign.AppearancePrint.GroupRow.Options.UseBackColor = True
        Me.GVCompPerDesign.AppearancePrint.GroupRow.Options.UseBorderColor = True
        Me.GVCompPerDesign.AppearancePrint.GroupRow.Options.UseFont = True
        Me.GVCompPerDesign.AppearancePrint.GroupRow.Options.UseForeColor = True
        Me.GVCompPerDesign.AppearancePrint.HeaderPanel.BackColor = System.Drawing.Color.White
        Me.GVCompPerDesign.AppearancePrint.HeaderPanel.BackColor2 = System.Drawing.Color.White
        Me.GVCompPerDesign.AppearancePrint.HeaderPanel.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.GVCompPerDesign.AppearancePrint.HeaderPanel.ForeColor = System.Drawing.Color.Black
        Me.GVCompPerDesign.AppearancePrint.HeaderPanel.Options.UseBackColor = True
        Me.GVCompPerDesign.AppearancePrint.HeaderPanel.Options.UseFont = True
        Me.GVCompPerDesign.AppearancePrint.HeaderPanel.Options.UseForeColor = True
        Me.GVCompPerDesign.AppearancePrint.Row.Font = New System.Drawing.Font("Tahoma", 7.0!)
        Me.GVCompPerDesign.AppearancePrint.Row.Options.UseFont = True
        Me.GVCompPerDesign.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Office2003
        Me.GVCompPerDesign.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumnColor, Me.ColCode, Me.ColName, Me.GridColumn46, Me.ColQty, Me.GridColumn54, Me.GridColumnCur, Me.GridColumn53, Me.ColPrice, Me.GridColumn47, Me.GridColumn49, Me.GridColumn50, Me.GridColumnisCOST, Me.GridColumnQtyOrder, Me.GridColumnCostPerPcs})
        Me.GVCompPerDesign.GridControl = Me.GCCompPerDesign
        Me.GVCompPerDesign.GroupCount = 1
        Me.GVCompPerDesign.GroupSummary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "total", Me.GridColumn47, "{0:N2}"), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Custom, "price", Me.ColPrice, "Sub Total{0}"), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "cost_per_pcs", Me.GridColumnCostPerPcs, "{0:N2}")})
        Me.GVCompPerDesign.Name = "GVCompPerDesign"
        Me.GVCompPerDesign.OptionsBehavior.Editable = False
        Me.GVCompPerDesign.OptionsView.ShowFooter = True
        Me.GVCompPerDesign.OptionsView.ShowGroupPanel = False
        Me.GVCompPerDesign.OptionsView.ShowIndicator = False
        Me.GVCompPerDesign.RowSeparatorHeight = 1
        Me.GVCompPerDesign.SortInfo.AddRange(New DevExpress.XtraGrid.Columns.GridColumnSortInfo() {New DevExpress.XtraGrid.Columns.GridColumnSortInfo(Me.GridColumn49, DevExpress.Data.ColumnSortOrder.Ascending)})
        '
        'GridColumnColor
        '
        Me.GridColumnColor.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumnColor.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridColumnColor.AppearanceHeader.Options.UseTextOptions = True
        Me.GridColumnColor.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridColumnColor.Caption = "Color"
        Me.GridColumnColor.FieldName = "color"
        Me.GridColumnColor.Name = "GridColumnColor"
        Me.GridColumnColor.Visible = True
        Me.GridColumnColor.VisibleIndex = 2
        '
        'ColCode
        '
        Me.ColCode.AppearanceCell.Options.UseTextOptions = True
        Me.ColCode.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
        Me.ColCode.AppearanceHeader.Options.UseTextOptions = True
        Me.ColCode.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
        Me.ColCode.Caption = "Code"
        Me.ColCode.FieldName = "code"
        Me.ColCode.Name = "ColCode"
        Me.ColCode.Visible = True
        Me.ColCode.VisibleIndex = 0
        Me.ColCode.Width = 96
        '
        'ColName
        '
        Me.ColName.AppearanceCell.Options.UseTextOptions = True
        Me.ColName.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
        Me.ColName.AppearanceHeader.Options.UseTextOptions = True
        Me.ColName.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
        Me.ColName.Caption = "Name"
        Me.ColName.FieldName = "name"
        Me.ColName.Name = "ColName"
        Me.ColName.Visible = True
        Me.ColName.VisibleIndex = 1
        Me.ColName.Width = 189
        '
        'GridColumn46
        '
        Me.GridColumn46.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumn46.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridColumn46.AppearanceHeader.Options.UseTextOptions = True
        Me.GridColumn46.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridColumn46.Caption = "Size"
        Me.GridColumn46.FieldName = "size"
        Me.GridColumn46.Name = "GridColumn46"
        Me.GridColumn46.Visible = True
        Me.GridColumn46.VisibleIndex = 3
        Me.GridColumn46.Width = 53
        '
        'ColQty
        '
        Me.ColQty.AppearanceCell.Options.UseTextOptions = True
        Me.ColQty.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.ColQty.AppearanceHeader.Options.UseTextOptions = True
        Me.ColQty.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.ColQty.Caption = "Qty"
        Me.ColQty.DisplayFormat.FormatString = "n2"
        Me.ColQty.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.ColQty.FieldName = "qty_uom"
        Me.ColQty.Name = "ColQty"
        Me.ColQty.Visible = True
        Me.ColQty.VisibleIndex = 8
        Me.ColQty.Width = 68
        '
        'GridColumn54
        '
        Me.GridColumn54.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumn54.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumn54.AppearanceHeader.Options.UseTextOptions = True
        Me.GridColumn54.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumn54.Caption = "Kurs"
        Me.GridColumn54.DisplayFormat.FormatString = "N2"
        Me.GridColumn54.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumn54.FieldName = "kurs"
        Me.GridColumn54.Name = "GridColumn54"
        Me.GridColumn54.Visible = True
        Me.GridColumn54.VisibleIndex = 6
        '
        'GridColumnCur
        '
        Me.GridColumnCur.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumnCur.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridColumnCur.AppearanceHeader.Options.UseTextOptions = True
        Me.GridColumnCur.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridColumnCur.Caption = "Currency"
        Me.GridColumnCur.FieldName = "currency"
        Me.GridColumnCur.Name = "GridColumnCur"
        Me.GridColumnCur.Visible = True
        Me.GridColumnCur.VisibleIndex = 4
        '
        'GridColumn53
        '
        Me.GridColumn53.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumn53.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumn53.AppearanceHeader.Options.UseTextOptions = True
        Me.GridColumn53.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumn53.Caption = "Price"
        Me.GridColumn53.DisplayFormat.FormatString = "N4"
        Me.GridColumn53.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumn53.FieldName = "vend_price"
        Me.GridColumn53.Name = "GridColumn53"
        Me.GridColumn53.Visible = True
        Me.GridColumn53.VisibleIndex = 5
        '
        'ColPrice
        '
        Me.ColPrice.AppearanceCell.Options.UseTextOptions = True
        Me.ColPrice.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.ColPrice.AppearanceHeader.Options.UseTextOptions = True
        Me.ColPrice.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.ColPrice.Caption = "Price After Kurs"
        Me.ColPrice.DisplayFormat.FormatString = "N2"
        Me.ColPrice.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.ColPrice.FieldName = "price"
        Me.ColPrice.Name = "ColPrice"
        Me.ColPrice.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Custom, "price", "Total")})
        Me.ColPrice.Visible = True
        Me.ColPrice.VisibleIndex = 7
        Me.ColPrice.Width = 99
        '
        'GridColumn47
        '
        Me.GridColumn47.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumn47.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumn47.AppearanceHeader.Options.UseTextOptions = True
        Me.GridColumn47.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumn47.Caption = "Total"
        Me.GridColumn47.DisplayFormat.FormatString = "N2"
        Me.GridColumn47.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumn47.FieldName = "total"
        Me.GridColumn47.Name = "GridColumn47"
        Me.GridColumn47.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "total", "{0:N2}")})
        Me.GridColumn47.UnboundExpression = "Iif([is_cost] = 1, [qty_uom] * [price], 2)"
        Me.GridColumn47.UnboundType = DevExpress.Data.UnboundColumnType.[Decimal]
        Me.GridColumn47.Visible = True
        Me.GridColumn47.VisibleIndex = 9
        Me.GridColumn47.Width = 112
        '
        'GridColumn49
        '
        Me.GridColumn49.Caption = "Category"
        Me.GridColumn49.FieldName = "component_category"
        Me.GridColumn49.FieldNameSortGroup = "id_component_category"
        Me.GridColumn49.Name = "GridColumn49"
        Me.GridColumn49.Visible = True
        Me.GridColumn49.VisibleIndex = 0
        '
        'GridColumn50
        '
        Me.GridColumn50.Caption = "Category"
        Me.GridColumn50.FieldName = "id_component_category"
        Me.GridColumn50.Name = "GridColumn50"
        '
        'GridColumnisCOST
        '
        Me.GridColumnisCOST.Caption = "IS COST"
        Me.GridColumnisCOST.FieldName = "is_cost"
        Me.GridColumnisCOST.Name = "GridColumnisCOST"
        '
        'GridColumnQtyOrder
        '
        Me.GridColumnQtyOrder.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumnQtyOrder.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumnQtyOrder.AppearanceHeader.Options.UseTextOptions = True
        Me.GridColumnQtyOrder.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumnQtyOrder.Caption = "Qty Order"
        Me.GridColumnQtyOrder.DisplayFormat.FormatString = "N0"
        Me.GridColumnQtyOrder.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumnQtyOrder.FieldName = "qty_order"
        Me.GridColumnQtyOrder.Name = "GridColumnQtyOrder"
        '
        'GridColumnCostPerPcs
        '
        Me.GridColumnCostPerPcs.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumnCostPerPcs.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumnCostPerPcs.AppearanceHeader.Options.UseTextOptions = True
        Me.GridColumnCostPerPcs.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumnCostPerPcs.Caption = "Unit Cost"
        Me.GridColumnCostPerPcs.DisplayFormat.FormatString = "N2"
        Me.GridColumnCostPerPcs.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumnCostPerPcs.FieldName = "cost_per_pcs"
        Me.GridColumnCostPerPcs.Name = "GridColumnCostPerPcs"
        Me.GridColumnCostPerPcs.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "cost_per_pcs", "{0:N2}")})
        Me.GridColumnCostPerPcs.Width = 91
        '
        'GridColumn12
        '
        Me.GridColumn12.Caption = "Production Demand"
        Me.GridColumn12.FieldName = "prod_demand_number"
        Me.GridColumn12.Name = "GridColumn12"
        Me.GridColumn12.Width = 263
        '
        'GridColumn13
        '
        Me.GridColumn13.Caption = "Id Prod Demand"
        Me.GridColumn13.FieldName = "id_prod_demand_design"
        Me.GridColumn13.Name = "GridColumn13"
        '
        'GridColumnQty
        '
        Me.GridColumnQty.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumnQty.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumnQty.AppearanceHeader.Options.UseTextOptions = True
        Me.GridColumnQty.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumnQty.Caption = "Qty"
        Me.GridColumnQty.DisplayFormat.FormatString = "N0"
        Me.GridColumnQty.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumnQty.FieldName = "qty"
        Me.GridColumnQty.Name = "GridColumnQty"
        Me.GridColumnQty.Width = 113
        '
        'FormBOM
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(934, 498)
        Me.Controls.Add(Me.XTCBOMSelection)
        Me.MinimizeBox = False
        Me.Name = "FormBOM"
        Me.ShowInTaskbar = False
        Me.Text = " Bill Of Material"
        CType(Me.SplitContainerControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainerControl1.ResumeLayout(False)
        CType(Me.SplitContainerControl2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainerControl2.ResumeLayout(False)
        CType(Me.GroupControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupControl1.ResumeLayout(False)
        CType(Me.GCProduct, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVProduct, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GroupControl2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupControl2.ResumeLayout(False)
        CType(Me.GCBOM, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVBOM, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RCEDefault, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl1.ResumeLayout(False)
        CType(Me.LargeImageCollection, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GroupControl3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupControl3.ResumeLayout(False)
        CType(Me.XtraTabControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.XtraTabControl1.ResumeLayout(False)
        Me.XTPMat.ResumeLayout(False)
        CType(Me.GCBomDetMat, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVBomDetMat, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.XTPOvh.ResumeLayout(False)
        CType(Me.GCBomDetOvh, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVBomDetOvh, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView5, System.ComponentModel.ISupportInitialize).EndInit()
        Me.XTPWip.ResumeLayout(False)
        CType(Me.GCBomDetWip, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVBomDetWip, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView9, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.XTCBOMSelection, System.ComponentModel.ISupportInitialize).EndInit()
        Me.XTCBOMSelection.ResumeLayout(False)
        Me.XTPPerPD.ResumeLayout(False)
        CType(Me.SplitContainerControl3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainerControl3.ResumeLayout(False)
        CType(Me.GCDesign, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVDesign, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GroupControl6, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupControl6.ResumeLayout(False)
        CType(Me.GCBOMDesign, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVBOMDesign, System.ComponentModel.ISupportInitialize).EndInit()
        Me.XTPPerProduct.ResumeLayout(False)
        Me.XTPPerDesign.ResumeLayout(False)
        CType(Me.SplitContainerControl4, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainerControl4.ResumeLayout(False)
        CType(Me.SplitContainerControl5, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainerControl5.ResumeLayout(False)
        CType(Me.GCPerDesign, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVPerDesign, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PanelControl3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl3.ResumeLayout(False)
        Me.PanelControl3.PerformLayout()
        CType(Me.SLESeason.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SearchLookUpEdit1View, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GroupControl5, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupControl5.ResumeLayout(False)
        CType(Me.GCBOMPerDesign, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVBOMPerDesign, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemCheckEdit1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PanelControl2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl2.ResumeLayout(False)
        CType(Me.GroupControl4, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupControl4.ResumeLayout(False)
        CType(Me.GCCompPerDesign, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVCompPerDesign, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents SplitContainerControl1 As DevExpress.XtraEditors.SplitContainerControl
    Friend WithEvents SplitContainerControl2 As DevExpress.XtraEditors.SplitContainerControl
    Friend WithEvents GroupControl1 As DevExpress.XtraEditors.GroupControl
    Friend WithEvents GCProduct As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVProduct As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents ColIdProduct As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColIdDesign As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColIdSeason As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColNamaDesign As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColProductCode As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColProductname As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColSeason As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColSize As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GroupControl2 As DevExpress.XtraEditors.GroupControl
    Friend WithEvents GCBOM As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVBOM As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents ColIdBom As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColBomName As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColTermProduction As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColDate As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColUnitPrice As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColIdStatus As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColStatus As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GroupControl3 As DevExpress.XtraEditors.GroupControl
    Friend WithEvents XtraTabControl1 As DevExpress.XtraTab.XtraTabControl
    Friend WithEvents XTPMat As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents GCBomDetMat As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVBomDetMat As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumn1 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn6 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn3 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn2 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn4 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn5 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn7 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridView3 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents XTPOvh As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents GCBomDetOvh As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVBomDetOvh As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumn15 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn16 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn17 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn19 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn20 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn21 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridView5 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents XTPWip As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents GCBomDetWip As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVBomDetWip As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumn29 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn30 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn31 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn32 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn33 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn34 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn35 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridView9 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumnIDSeason As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn8 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents RCEDefault As DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit
    Friend WithEvents GridColumn9 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn10 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents PanelControl1 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents BDefault As DevExpress.XtraEditors.SimpleButton
    Public WithEvents LargeImageCollection As DevExpress.Utils.ImageCollection
    Friend WithEvents XTCBOMSelection As DevExpress.XtraTab.XtraTabControl
    Friend WithEvents XTPPerPD As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents XTPPerProduct As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents SplitContainerControl3 As DevExpress.XtraEditors.SplitContainerControl
    Friend WithEvents GroupControl6 As DevExpress.XtraEditors.GroupControl
    Friend WithEvents GCDesign As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVDesign As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridView2 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GCBOMDesign As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVBOMDesign As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumn14 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn18 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn22 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn23 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn24 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColTotal As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents Cat As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColIDCat As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn25 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnUOM As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn26 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn27 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents XTPPerDesign As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents SplitContainerControl4 As DevExpress.XtraEditors.SplitContainerControl
    Friend WithEvents GCPerDesign As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVPerDesign As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumn28 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn36 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn37 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn38 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn39 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn40 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn41 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn42 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn43 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn44 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn45 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridView4 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GroupControl4 As DevExpress.XtraEditors.GroupControl
    Friend WithEvents GridColumnIsCop As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnIsCostSingle As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GCCompPerDesign As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVCompPerDesign As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumn11 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn59 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn60 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn61 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn62 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn63 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn64 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn65 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn66 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn67 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn68 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn69 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn12 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn13 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnQty As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents SplitContainerControl5 As DevExpress.XtraEditors.SplitContainerControl
    Friend WithEvents GroupControl5 As DevExpress.XtraEditors.GroupControl
    Friend WithEvents GCBOMPerDesign As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVBOMPerDesign As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumn48 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn70 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn71 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn72 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn73 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn74 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn75 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn76 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents RepositoryItemCheckEdit1 As DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit
    Friend WithEvents GridColumn77 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn78 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents PanelControl2 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents BDefaultBOM As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents GridColumnIdBOMApprove As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColCode As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColName As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn46 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColQty As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColPrice As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn47 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn49 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn50 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnisCOST As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnQtyOrder As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnCostPerPcs As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnColor As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents BImportExcel As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents PanelControl3 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents SLESeason As DevExpress.XtraEditors.SearchLookUpEdit
    Friend WithEvents SearchLookUpEdit1View As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumn51 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnRange As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnSeason As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents LabelControl4 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents BtnView As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BPrint As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents GridColumnUnitCost As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn52 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn54 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn53 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnCur As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn55 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn56 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn57 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnStatusLineList As DevExpress.XtraGrid.Columns.GridColumn
End Class
