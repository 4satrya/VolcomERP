<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormBOMSingle
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormBOMSingle))
        Me.EPBOM = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.LargeImageCollection = New DevExpress.Utils.ImageCollection(Me.components)
        Me.GroupGeneral = New DevExpress.XtraEditors.GroupControl()
        Me.TEKurs = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl6 = New DevExpress.XtraEditors.LabelControl()
        Me.LEReportStatus = New DevExpress.XtraEditors.LookUpEdit()
        Me.LabelControl21 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl5 = New DevExpress.XtraEditors.LabelControl()
        Me.LECurrency = New DevExpress.XtraEditors.LookUpEdit()
        Me.LETerm = New DevExpress.XtraEditors.LookUpEdit()
        Me.LabelControl4 = New DevExpress.XtraEditors.LabelControl()
        Me.TEName = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl3 = New DevExpress.XtraEditors.LabelControl()
        Me.GroupComponent = New DevExpress.XtraEditors.GroupControl()
        Me.TEUnitPrice = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl2 = New DevExpress.XtraEditors.LabelControl()
        Me.XTCBOM = New DevExpress.XtraTab.XtraTabControl()
        Me.XTPMat = New DevExpress.XtraTab.XtraTabPage()
        Me.BDelMat = New DevExpress.XtraEditors.SimpleButton()
        Me.BEditMat = New DevExpress.XtraEditors.SimpleButton()
        Me.BAddMat = New DevExpress.XtraEditors.SimpleButton()
        Me.BSubmitMat = New DevExpress.XtraEditors.SimpleButton()
        Me.GCBomDetMat = New DevExpress.XtraGrid.GridControl()
        Me.GVBomDetMat = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumn1 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn6 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn3 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn2 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn4 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn5 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn7 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnIncludeInCost = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RICEisCOP = New DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit()
        Me.GridColumnTotalCost = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnKursMat = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridView3 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.XTPOvh = New DevExpress.XtraTab.XtraTabPage()
        Me.BDelOVH = New DevExpress.XtraEditors.SimpleButton()
        Me.BEditOVH = New DevExpress.XtraEditors.SimpleButton()
        Me.BAddOVH = New DevExpress.XtraEditors.SimpleButton()
        Me.BSubmitOVH = New DevExpress.XtraEditors.SimpleButton()
        Me.GCBomDetOvh = New DevExpress.XtraGrid.GridControl()
        Me.GVBomDetOvh = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumn15 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn16 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnOVHCat = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn17 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn19 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnKursOVH = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnCurrency = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn8 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn20 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn21 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnOVHMain = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RCIMainVendor = New DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit()
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
        Me.BEditWip = New DevExpress.XtraEditors.SimpleButton()
        Me.BAddWip = New DevExpress.XtraEditors.SimpleButton()
        Me.BDelWip = New DevExpress.XtraEditors.SimpleButton()
        Me.PCLotTitle = New DevExpress.XtraEditors.PanelControl()
        Me.LabelPrintedName = New DevExpress.XtraEditors.LabelControl()
        Me.LSampleTitle = New DevExpress.XtraEditors.LabelControl()
        Me.PanelControl2 = New DevExpress.XtraEditors.PanelControl()
        Me.BDuplicate = New DevExpress.XtraEditors.SimpleButton()
        Me.LabelProductCode = New DevExpress.XtraEditors.LabelControl()
        Me.BMark = New DevExpress.XtraEditors.SimpleButton()
        Me.Bprint = New DevExpress.XtraEditors.SimpleButton()
        Me.BCancel = New DevExpress.XtraEditors.SimpleButton()
        Me.BSave = New DevExpress.XtraEditors.SimpleButton()
        Me.LTitleProduct = New DevExpress.XtraEditors.LabelControl()
        Me.MEBOMNote = New DevExpress.XtraEditors.MemoEdit()
        Me.LabelControl1 = New DevExpress.XtraEditors.LabelControl()
        CType(Me.EPBOM, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LargeImageCollection, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GroupGeneral, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupGeneral.SuspendLayout()
        CType(Me.TEKurs.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LEReportStatus.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LECurrency.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LETerm.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TEName.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GroupComponent, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupComponent.SuspendLayout()
        CType(Me.TEUnitPrice.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.XTCBOM, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.XTCBOM.SuspendLayout()
        Me.XTPMat.SuspendLayout()
        CType(Me.GCBomDetMat, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVBomDetMat, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RICEisCOP, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.XTPOvh.SuspendLayout()
        CType(Me.GCBomDetOvh, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVBomDetOvh, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RCIMainVendor, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView5, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.XTPWip.SuspendLayout()
        CType(Me.GCBomDetWip, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVBomDetWip, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView9, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PCLotTitle, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PCLotTitle.SuspendLayout()
        CType(Me.PanelControl2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl2.SuspendLayout()
        CType(Me.MEBOMNote.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'EPBOM
        '
        Me.EPBOM.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink
        Me.EPBOM.ContainerControl = Me
        '
        'LargeImageCollection
        '
        Me.LargeImageCollection.ImageSize = New System.Drawing.Size(24, 24)
        Me.LargeImageCollection.ImageStream = CType(resources.GetObject("LargeImageCollection.ImageStream"), DevExpress.Utils.ImageCollectionStreamer)
        Me.LargeImageCollection.Images.SetKeyName(0, "20_24x24.png")
        Me.LargeImageCollection.Images.SetKeyName(1, "8_24x24.png")
        Me.LargeImageCollection.Images.SetKeyName(2, "23_24x24.png")
        Me.LargeImageCollection.Images.SetKeyName(3, "document_32.png")
        '
        'GroupGeneral
        '
        Me.GroupGeneral.CaptionLocation = DevExpress.Utils.Locations.Left
        Me.GroupGeneral.Controls.Add(Me.LabelControl1)
        Me.GroupGeneral.Controls.Add(Me.MEBOMNote)
        Me.GroupGeneral.Controls.Add(Me.TEKurs)
        Me.GroupGeneral.Controls.Add(Me.LabelControl6)
        Me.GroupGeneral.Controls.Add(Me.LEReportStatus)
        Me.GroupGeneral.Controls.Add(Me.LabelControl21)
        Me.GroupGeneral.Controls.Add(Me.LabelControl5)
        Me.GroupGeneral.Controls.Add(Me.LECurrency)
        Me.GroupGeneral.Controls.Add(Me.LETerm)
        Me.GroupGeneral.Controls.Add(Me.LabelControl4)
        Me.GroupGeneral.Controls.Add(Me.TEName)
        Me.GroupGeneral.Controls.Add(Me.LabelControl3)
        Me.GroupGeneral.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupGeneral.Location = New System.Drawing.Point(0, 40)
        Me.GroupGeneral.Name = "GroupGeneral"
        Me.GroupGeneral.Size = New System.Drawing.Size(250, 369)
        Me.GroupGeneral.TabIndex = 24
        Me.GroupGeneral.Text = "General"
        '
        'TEKurs
        '
        Me.TEKurs.Location = New System.Drawing.Point(35, 162)
        Me.TEKurs.Name = "TEKurs"
        Me.TEKurs.Properties.Appearance.Options.UseTextOptions = True
        Me.TEKurs.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.TEKurs.Properties.DisplayFormat.FormatString = "N2"
        Me.TEKurs.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.TEKurs.Properties.EditValueChangedDelay = 1
        Me.TEKurs.Properties.Mask.EditMask = "N4"
        Me.TEKurs.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric
        Me.TEKurs.Properties.Mask.SaveLiteral = False
        Me.TEKurs.Properties.Mask.UseMaskAsDisplayFormat = True
        Me.TEKurs.Size = New System.Drawing.Size(179, 20)
        Me.TEKurs.TabIndex = 148
        '
        'LabelControl6
        '
        Me.LabelControl6.Location = New System.Drawing.Point(35, 143)
        Me.LabelControl6.Name = "LabelControl6"
        Me.LabelControl6.Size = New System.Drawing.Size(21, 13)
        Me.LabelControl6.TabIndex = 149
        Me.LabelControl6.Text = "Kurs"
        '
        'LEReportStatus
        '
        Me.LEReportStatus.Enabled = False
        Me.LEReportStatus.Location = New System.Drawing.Point(35, 207)
        Me.LEReportStatus.Name = "LEReportStatus"
        Me.LEReportStatus.Properties.Appearance.Options.UseTextOptions = True
        Me.LEReportStatus.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
        Me.LEReportStatus.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.LEReportStatus.Properties.Columns.AddRange(New DevExpress.XtraEditors.Controls.LookUpColumnInfo() {New DevExpress.XtraEditors.Controls.LookUpColumnInfo("id_report_status", "ID Report Status", 20, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("report_status", "Report Status")})
        Me.LEReportStatus.Properties.NullText = ""
        Me.LEReportStatus.Properties.ShowFooter = False
        Me.LEReportStatus.Size = New System.Drawing.Size(179, 20)
        Me.LEReportStatus.TabIndex = 147
        '
        'LabelControl21
        '
        Me.LabelControl21.Location = New System.Drawing.Point(35, 188)
        Me.LabelControl21.Name = "LabelControl21"
        Me.LabelControl21.Size = New System.Drawing.Size(31, 13)
        Me.LabelControl21.TabIndex = 146
        Me.LabelControl21.Text = "Status"
        '
        'LabelControl5
        '
        Me.LabelControl5.Appearance.Font = New System.Drawing.Font("Calibri", 10.0!)
        Me.LabelControl5.Location = New System.Drawing.Point(35, 100)
        Me.LabelControl5.Name = "LabelControl5"
        Me.LabelControl5.Size = New System.Drawing.Size(49, 15)
        Me.LabelControl5.TabIndex = 114
        Me.LabelControl5.Text = "Currency"
        '
        'LECurrency
        '
        Me.LECurrency.Location = New System.Drawing.Point(35, 117)
        Me.LECurrency.Name = "LECurrency"
        Me.LECurrency.Properties.Appearance.Options.UseTextOptions = True
        Me.LECurrency.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
        Me.LECurrency.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.LECurrency.Properties.Columns.AddRange(New DevExpress.XtraEditors.Controls.LookUpColumnInfo() {New DevExpress.XtraEditors.Controls.LookUpColumnInfo("id_currency", "Id Currency", 20, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("currency", "Currency")})
        Me.LECurrency.Properties.NullText = ""
        Me.LECurrency.Properties.ShowFooter = False
        Me.LECurrency.Size = New System.Drawing.Size(179, 20)
        Me.LECurrency.TabIndex = 113
        '
        'LETerm
        '
        Me.LETerm.Location = New System.Drawing.Point(35, 71)
        Me.LETerm.Name = "LETerm"
        Me.LETerm.Properties.Appearance.Options.UseTextOptions = True
        Me.LETerm.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
        Me.LETerm.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.LETerm.Properties.Columns.AddRange(New DevExpress.XtraEditors.Controls.LookUpColumnInfo() {New DevExpress.XtraEditors.Controls.LookUpColumnInfo("id_term_production", "id_term_production", 20, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("term_production", "Term Production")})
        Me.LETerm.Properties.NullText = ""
        Me.LETerm.Properties.ShowFooter = False
        Me.LETerm.Size = New System.Drawing.Size(179, 20)
        Me.LETerm.TabIndex = 112
        '
        'LabelControl4
        '
        Me.LabelControl4.Location = New System.Drawing.Point(35, 52)
        Me.LabelControl4.Name = "LabelControl4"
        Me.LabelControl4.Size = New System.Drawing.Size(93, 13)
        Me.LabelControl4.TabIndex = 88
        Me.LabelControl4.Text = "Term Of Production"
        '
        'TEName
        '
        Me.TEName.EditValue = ""
        Me.TEName.Location = New System.Drawing.Point(35, 25)
        Me.TEName.Name = "TEName"
        Me.TEName.Properties.EditValueChangedDelay = 1
        Me.TEName.Size = New System.Drawing.Size(179, 20)
        Me.TEName.TabIndex = 85
        '
        'LabelControl3
        '
        Me.LabelControl3.Location = New System.Drawing.Point(35, 8)
        Me.LabelControl3.Name = "LabelControl3"
        Me.LabelControl3.Size = New System.Drawing.Size(36, 13)
        Me.LabelControl3.TabIndex = 86
        Me.LabelControl3.Text = "Method"
        '
        'GroupComponent
        '
        Me.GroupComponent.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Flat
        Me.GroupComponent.CaptionLocation = DevExpress.Utils.Locations.Left
        Me.GroupComponent.Controls.Add(Me.TEUnitPrice)
        Me.GroupComponent.Controls.Add(Me.LabelControl2)
        Me.GroupComponent.Controls.Add(Me.XTCBOM)
        Me.GroupComponent.Dock = System.Windows.Forms.DockStyle.Right
        Me.GroupComponent.Enabled = False
        Me.GroupComponent.Location = New System.Drawing.Point(250, 40)
        Me.GroupComponent.Name = "GroupComponent"
        Me.GroupComponent.Size = New System.Drawing.Size(725, 369)
        Me.GroupComponent.TabIndex = 23
        Me.GroupComponent.Text = "Component"
        '
        'TEUnitPrice
        '
        Me.TEUnitPrice.Location = New System.Drawing.Point(539, 339)
        Me.TEUnitPrice.Name = "TEUnitPrice"
        Me.TEUnitPrice.Properties.Appearance.Options.UseTextOptions = True
        Me.TEUnitPrice.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.TEUnitPrice.Properties.EditValueChangedDelay = 1
        Me.TEUnitPrice.Properties.Mask.EditMask = "N2"
        Me.TEUnitPrice.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric
        Me.TEUnitPrice.Properties.Mask.SaveLiteral = False
        Me.TEUnitPrice.Properties.Mask.UseMaskAsDisplayFormat = True
        Me.TEUnitPrice.Properties.ReadOnly = True
        Me.TEUnitPrice.Size = New System.Drawing.Size(179, 20)
        Me.TEUnitPrice.TabIndex = 87
        '
        'LabelControl2
        '
        Me.LabelControl2.Location = New System.Drawing.Point(461, 342)
        Me.LabelControl2.Name = "LabelControl2"
        Me.LabelControl2.Size = New System.Drawing.Size(72, 13)
        Me.LabelControl2.TabIndex = 88
        Me.LabelControl2.Text = "Total Unit Price"
        '
        'XTCBOM
        '
        Me.XTCBOM.Dock = System.Windows.Forms.DockStyle.Top
        Me.XTCBOM.Location = New System.Drawing.Point(20, 2)
        Me.XTCBOM.Name = "XTCBOM"
        Me.XTCBOM.SelectedTabPage = Me.XTPMat
        Me.XTCBOM.Size = New System.Drawing.Size(703, 331)
        Me.XTCBOM.TabIndex = 1
        Me.XTCBOM.TabPages.AddRange(New DevExpress.XtraTab.XtraTabPage() {Me.XTPMat, Me.XTPOvh, Me.XTPWip})
        '
        'XTPMat
        '
        Me.XTPMat.Controls.Add(Me.BDelMat)
        Me.XTPMat.Controls.Add(Me.BEditMat)
        Me.XTPMat.Controls.Add(Me.BAddMat)
        Me.XTPMat.Controls.Add(Me.BSubmitMat)
        Me.XTPMat.Controls.Add(Me.GCBomDetMat)
        Me.XTPMat.Name = "XTPMat"
        Me.XTPMat.Size = New System.Drawing.Size(697, 303)
        Me.XTPMat.Text = "Material"
        '
        'BDelMat
        '
        Me.BDelMat.Dock = System.Windows.Forms.DockStyle.Right
        Me.BDelMat.ImageIndex = 1
        Me.BDelMat.ImageList = Me.LargeImageCollection
        Me.BDelMat.Location = New System.Drawing.Point(424, 0)
        Me.BDelMat.Name = "BDelMat"
        Me.BDelMat.Size = New System.Drawing.Size(91, 36)
        Me.BDelMat.TabIndex = 14
        Me.BDelMat.Text = "Delete"
        '
        'BEditMat
        '
        Me.BEditMat.Dock = System.Windows.Forms.DockStyle.Right
        Me.BEditMat.ImageIndex = 2
        Me.BEditMat.ImageList = Me.LargeImageCollection
        Me.BEditMat.Location = New System.Drawing.Point(515, 0)
        Me.BEditMat.Name = "BEditMat"
        Me.BEditMat.Size = New System.Drawing.Size(91, 36)
        Me.BEditMat.TabIndex = 16
        Me.BEditMat.Text = "Edit"
        '
        'BAddMat
        '
        Me.BAddMat.Dock = System.Windows.Forms.DockStyle.Right
        Me.BAddMat.ImageIndex = 0
        Me.BAddMat.ImageList = Me.LargeImageCollection
        Me.BAddMat.Location = New System.Drawing.Point(606, 0)
        Me.BAddMat.Name = "BAddMat"
        Me.BAddMat.Size = New System.Drawing.Size(91, 36)
        Me.BAddMat.TabIndex = 15
        Me.BAddMat.Text = "Add"
        '
        'BSubmitMat
        '
        Me.BSubmitMat.Dock = System.Windows.Forms.DockStyle.Left
        Me.BSubmitMat.ImageIndex = 3
        Me.BSubmitMat.ImageList = Me.LargeImageCollection
        Me.BSubmitMat.Location = New System.Drawing.Point(0, 0)
        Me.BSubmitMat.Name = "BSubmitMat"
        Me.BSubmitMat.Size = New System.Drawing.Size(91, 36)
        Me.BSubmitMat.TabIndex = 18
        Me.BSubmitMat.Text = "Submit"
        '
        'GCBomDetMat
        '
        Me.GCBomDetMat.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.GCBomDetMat.Location = New System.Drawing.Point(0, 36)
        Me.GCBomDetMat.MainView = Me.GVBomDetMat
        Me.GCBomDetMat.Name = "GCBomDetMat"
        Me.GCBomDetMat.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.RICEisCOP})
        Me.GCBomDetMat.Size = New System.Drawing.Size(697, 267)
        Me.GCBomDetMat.TabIndex = 17
        Me.GCBomDetMat.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVBomDetMat, Me.GridView3})
        '
        'GVBomDetMat
        '
        Me.GVBomDetMat.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumn1, Me.GridColumn6, Me.GridColumn3, Me.GridColumn2, Me.GridColumn4, Me.GridColumn5, Me.GridColumn7, Me.GridColumnIncludeInCost, Me.GridColumnTotalCost, Me.GridColumnKursMat})
        Me.GVBomDetMat.CustomizationFormBounds = New System.Drawing.Rectangle(885, 289, 216, 178)
        Me.GVBomDetMat.GridControl = Me.GCBomDetMat
        Me.GVBomDetMat.GroupSummary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "total", Me.GridColumn7, "{0:N2}")})
        Me.GVBomDetMat.Name = "GVBomDetMat"
        Me.GVBomDetMat.OptionsBehavior.Editable = False
        Me.GVBomDetMat.OptionsFind.AlwaysVisible = True
        Me.GVBomDetMat.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never
        Me.GVBomDetMat.OptionsView.ShowFooter = True
        Me.GVBomDetMat.OptionsView.ShowGroupPanel = False
        '
        'GridColumn1
        '
        Me.GridColumn1.Caption = "Id Mat"
        Me.GridColumn1.FieldName = "id_bom_det"
        Me.GridColumn1.Name = "GridColumn1"
        '
        'GridColumn6
        '
        Me.GridColumn6.Caption = "Code"
        Me.GridColumn6.FieldName = "code"
        Me.GridColumn6.Name = "GridColumn6"
        Me.GridColumn6.Visible = True
        Me.GridColumn6.VisibleIndex = 1
        Me.GridColumn6.Width = 89
        '
        'GridColumn3
        '
        Me.GridColumn3.Caption = "Material"
        Me.GridColumn3.FieldName = "name"
        Me.GridColumn3.Name = "GridColumn3"
        Me.GridColumn3.Visible = True
        Me.GridColumn3.VisibleIndex = 2
        Me.GridColumn3.Width = 250
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
        Me.GridColumn2.VisibleIndex = 3
        Me.GridColumn2.Width = 32
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
        Me.GridColumn4.VisibleIndex = 4
        Me.GridColumn4.Width = 58
        '
        'GridColumn5
        '
        Me.GridColumn5.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumn5.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumn5.AppearanceHeader.Options.UseTextOptions = True
        Me.GridColumn5.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumn5.Caption = "Unit Price"
        Me.GridColumn5.DisplayFormat.FormatString = "N4"
        Me.GridColumn5.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumn5.FieldName = "price"
        Me.GridColumn5.Name = "GridColumn5"
        Me.GridColumn5.Visible = True
        Me.GridColumn5.VisibleIndex = 5
        Me.GridColumn5.Width = 119
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
        Me.GridColumn7.Width = 129
        '
        'GridColumnIncludeInCost
        '
        Me.GridColumnIncludeInCost.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumnIncludeInCost.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridColumnIncludeInCost.AppearanceHeader.Options.UseTextOptions = True
        Me.GridColumnIncludeInCost.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridColumnIncludeInCost.Caption = "COP"
        Me.GridColumnIncludeInCost.ColumnEdit = Me.RICEisCOP
        Me.GridColumnIncludeInCost.FieldName = "is_cost"
        Me.GridColumnIncludeInCost.Name = "GridColumnIncludeInCost"
        Me.GridColumnIncludeInCost.Visible = True
        Me.GridColumnIncludeInCost.VisibleIndex = 0
        '
        'RICEisCOP
        '
        Me.RICEisCOP.AutoHeight = False
        Me.RICEisCOP.Name = "RICEisCOP"
        Me.RICEisCOP.ValueChecked = CType(1, Byte)
        Me.RICEisCOP.ValueUnchecked = CType(2, Byte)
        '
        'GridColumnTotalCost
        '
        Me.GridColumnTotalCost.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumnTotalCost.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumnTotalCost.AppearanceHeader.Options.UseTextOptions = True
        Me.GridColumnTotalCost.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumnTotalCost.Caption = "Total Cost"
        Me.GridColumnTotalCost.DisplayFormat.FormatString = "N2"
        Me.GridColumnTotalCost.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumnTotalCost.FieldName = "total_cost"
        Me.GridColumnTotalCost.Name = "GridColumnTotalCost"
        Me.GridColumnTotalCost.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "total_cost", "{0:N2}")})
        Me.GridColumnTotalCost.UnboundExpression = "Iif([is_cost] = 1, [total], 0)"
        Me.GridColumnTotalCost.UnboundType = DevExpress.Data.UnboundColumnType.[Decimal]
        Me.GridColumnTotalCost.Visible = True
        Me.GridColumnTotalCost.VisibleIndex = 6
        '
        'GridColumnKursMat
        '
        Me.GridColumnKursMat.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumnKursMat.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumnKursMat.AppearanceHeader.Options.UseTextOptions = True
        Me.GridColumnKursMat.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumnKursMat.Caption = "Kurs"
        Me.GridColumnKursMat.DisplayFormat.FormatString = "N2"
        Me.GridColumnKursMat.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumnKursMat.FieldName = "kurs"
        Me.GridColumnKursMat.Name = "GridColumnKursMat"
        '
        'GridView3
        '
        Me.GridView3.GridControl = Me.GCBomDetMat
        Me.GridView3.Name = "GridView3"
        '
        'XTPOvh
        '
        Me.XTPOvh.Controls.Add(Me.BDelOVH)
        Me.XTPOvh.Controls.Add(Me.BEditOVH)
        Me.XTPOvh.Controls.Add(Me.BAddOVH)
        Me.XTPOvh.Controls.Add(Me.BSubmitOVH)
        Me.XTPOvh.Controls.Add(Me.GCBomDetOvh)
        Me.XTPOvh.Name = "XTPOvh"
        Me.XTPOvh.Size = New System.Drawing.Size(697, 303)
        Me.XTPOvh.Text = "Overhead"
        '
        'BDelOVH
        '
        Me.BDelOVH.Dock = System.Windows.Forms.DockStyle.Right
        Me.BDelOVH.ImageIndex = 1
        Me.BDelOVH.ImageList = Me.LargeImageCollection
        Me.BDelOVH.Location = New System.Drawing.Point(424, 0)
        Me.BDelOVH.Name = "BDelOVH"
        Me.BDelOVH.Size = New System.Drawing.Size(91, 36)
        Me.BDelOVH.TabIndex = 18
        Me.BDelOVH.Text = "Delete"
        '
        'BEditOVH
        '
        Me.BEditOVH.Dock = System.Windows.Forms.DockStyle.Right
        Me.BEditOVH.ImageIndex = 2
        Me.BEditOVH.ImageList = Me.LargeImageCollection
        Me.BEditOVH.Location = New System.Drawing.Point(515, 0)
        Me.BEditOVH.Name = "BEditOVH"
        Me.BEditOVH.Size = New System.Drawing.Size(91, 36)
        Me.BEditOVH.TabIndex = 20
        Me.BEditOVH.Text = "Edit"
        '
        'BAddOVH
        '
        Me.BAddOVH.Dock = System.Windows.Forms.DockStyle.Right
        Me.BAddOVH.ImageIndex = 0
        Me.BAddOVH.ImageList = Me.LargeImageCollection
        Me.BAddOVH.Location = New System.Drawing.Point(606, 0)
        Me.BAddOVH.Name = "BAddOVH"
        Me.BAddOVH.Size = New System.Drawing.Size(91, 36)
        Me.BAddOVH.TabIndex = 19
        Me.BAddOVH.Text = "Add"
        '
        'BSubmitOVH
        '
        Me.BSubmitOVH.Dock = System.Windows.Forms.DockStyle.Left
        Me.BSubmitOVH.ImageIndex = 3
        Me.BSubmitOVH.ImageList = Me.LargeImageCollection
        Me.BSubmitOVH.Location = New System.Drawing.Point(0, 0)
        Me.BSubmitOVH.Name = "BSubmitOVH"
        Me.BSubmitOVH.Size = New System.Drawing.Size(91, 36)
        Me.BSubmitOVH.TabIndex = 22
        Me.BSubmitOVH.Text = "Submit"
        '
        'GCBomDetOvh
        '
        Me.GCBomDetOvh.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.GCBomDetOvh.Location = New System.Drawing.Point(0, 36)
        Me.GCBomDetOvh.MainView = Me.GVBomDetOvh
        Me.GCBomDetOvh.Name = "GCBomDetOvh"
        Me.GCBomDetOvh.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.RCIMainVendor})
        Me.GCBomDetOvh.Size = New System.Drawing.Size(697, 267)
        Me.GCBomDetOvh.TabIndex = 21
        Me.GCBomDetOvh.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVBomDetOvh, Me.GridView5})
        '
        'GVBomDetOvh
        '
        Me.GVBomDetOvh.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumn15, Me.GridColumn16, Me.GridColumnOVHCat, Me.GridColumn17, Me.GridColumn19, Me.GridColumnKursOVH, Me.GridColumnCurrency, Me.GridColumn8, Me.GridColumn20, Me.GridColumn21, Me.GridColumnOVHMain})
        Me.GVBomDetOvh.CustomizationFormBounds = New System.Drawing.Rectangle(885, 289, 216, 178)
        Me.GVBomDetOvh.GridControl = Me.GCBomDetOvh
        Me.GVBomDetOvh.GroupSummary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "total", Me.GridColumn21, "{0:N2}")})
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
        Me.GridColumn16.VisibleIndex = 1
        Me.GridColumn16.Width = 58
        '
        'GridColumnOVHCat
        '
        Me.GridColumnOVHCat.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumnOVHCat.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridColumnOVHCat.AppearanceHeader.Options.UseTextOptions = True
        Me.GridColumnOVHCat.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridColumnOVHCat.Caption = "Category"
        Me.GridColumnOVHCat.FieldName = "ovh_cat"
        Me.GridColumnOVHCat.Name = "GridColumnOVHCat"
        Me.GridColumnOVHCat.Visible = True
        Me.GridColumnOVHCat.VisibleIndex = 2
        Me.GridColumnOVHCat.Width = 48
        '
        'GridColumn17
        '
        Me.GridColumn17.Caption = "Overhead"
        Me.GridColumn17.FieldName = "overhead"
        Me.GridColumn17.Name = "GridColumn17"
        Me.GridColumn17.Visible = True
        Me.GridColumn17.VisibleIndex = 3
        Me.GridColumn17.Width = 164
        '
        'GridColumn19
        '
        Me.GridColumn19.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumn19.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumn19.AppearanceHeader.Options.UseTextOptions = True
        Me.GridColumn19.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumn19.Caption = "Qty"
        Me.GridColumn19.FieldName = "qty_uom"
        Me.GridColumn19.Name = "GridColumn19"
        Me.GridColumn19.Visible = True
        Me.GridColumn19.VisibleIndex = 4
        Me.GridColumn19.Width = 37
        '
        'GridColumnKursOVH
        '
        Me.GridColumnKursOVH.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumnKursOVH.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumnKursOVH.AppearanceHeader.Options.UseTextOptions = True
        Me.GridColumnKursOVH.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumnKursOVH.Caption = "Kurs"
        Me.GridColumnKursOVH.DisplayFormat.FormatString = "N2"
        Me.GridColumnKursOVH.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumnKursOVH.FieldName = "kurs"
        Me.GridColumnKursOVH.Name = "GridColumnKursOVH"
        Me.GridColumnKursOVH.Visible = True
        Me.GridColumnKursOVH.VisibleIndex = 7
        Me.GridColumnKursOVH.Width = 51
        '
        'GridColumnCurrency
        '
        Me.GridColumnCurrency.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumnCurrency.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridColumnCurrency.AppearanceHeader.Options.UseTextOptions = True
        Me.GridColumnCurrency.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridColumnCurrency.Caption = "Currency"
        Me.GridColumnCurrency.FieldName = "currency"
        Me.GridColumnCurrency.Name = "GridColumnCurrency"
        Me.GridColumnCurrency.Visible = True
        Me.GridColumnCurrency.VisibleIndex = 5
        Me.GridColumnCurrency.Width = 57
        '
        'GridColumn8
        '
        Me.GridColumn8.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumn8.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumn8.AppearanceHeader.Options.UseTextOptions = True
        Me.GridColumn8.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumn8.Caption = "Price"
        Me.GridColumn8.DisplayFormat.FormatString = "N2"
        Me.GridColumn8.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumn8.FieldName = "price"
        Me.GridColumn8.Name = "GridColumn8"
        Me.GridColumn8.Visible = True
        Me.GridColumn8.VisibleIndex = 6
        Me.GridColumn8.Width = 77
        '
        'GridColumn20
        '
        Me.GridColumn20.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumn20.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumn20.AppearanceHeader.Options.UseTextOptions = True
        Me.GridColumn20.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumn20.Caption = "Price After Kurs"
        Me.GridColumn20.DisplayFormat.FormatString = "N2"
        Me.GridColumn20.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumn20.FieldName = "unit_price"
        Me.GridColumn20.Name = "GridColumn20"
        Me.GridColumn20.Visible = True
        Me.GridColumn20.VisibleIndex = 8
        Me.GridColumn20.Width = 58
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
        Me.GridColumn21.VisibleIndex = 9
        Me.GridColumn21.Width = 87
        '
        'GridColumnOVHMain
        '
        Me.GridColumnOVHMain.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumnOVHMain.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridColumnOVHMain.AppearanceHeader.Options.UseTextOptions = True
        Me.GridColumnOVHMain.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridColumnOVHMain.Caption = "Main Vendor"
        Me.GridColumnOVHMain.ColumnEdit = Me.RCIMainVendor
        Me.GridColumnOVHMain.FieldName = "is_ovh_main"
        Me.GridColumnOVHMain.Name = "GridColumnOVHMain"
        Me.GridColumnOVHMain.Visible = True
        Me.GridColumnOVHMain.VisibleIndex = 0
        Me.GridColumnOVHMain.Width = 55
        '
        'RCIMainVendor
        '
        Me.RCIMainVendor.AutoHeight = False
        Me.RCIMainVendor.Name = "RCIMainVendor"
        Me.RCIMainVendor.ValueChecked = CType(1, Byte)
        Me.RCIMainVendor.ValueUnchecked = CType(2, Byte)
        '
        'GridView5
        '
        Me.GridView5.GridControl = Me.GCBomDetOvh
        Me.GridView5.Name = "GridView5"
        '
        'XTPWip
        '
        Me.XTPWip.Controls.Add(Me.GCBomDetWip)
        Me.XTPWip.Controls.Add(Me.BEditWip)
        Me.XTPWip.Controls.Add(Me.BAddWip)
        Me.XTPWip.Controls.Add(Me.BDelWip)
        Me.XTPWip.Name = "XTPWip"
        Me.XTPWip.PageVisible = False
        Me.XTPWip.Size = New System.Drawing.Size(697, 303)
        Me.XTPWip.Text = "WIP"
        '
        'GCBomDetWip
        '
        Me.GCBomDetWip.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.GCBomDetWip.Location = New System.Drawing.Point(0, 36)
        Me.GCBomDetWip.MainView = Me.GVBomDetWip
        Me.GCBomDetWip.Name = "GCBomDetWip"
        Me.GCBomDetWip.Size = New System.Drawing.Size(697, 267)
        Me.GCBomDetWip.TabIndex = 21
        Me.GCBomDetWip.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVBomDetWip, Me.GridView9})
        '
        'GVBomDetWip
        '
        Me.GVBomDetWip.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumn29, Me.GridColumn30, Me.GridColumn31, Me.GridColumn32, Me.GridColumn33, Me.GridColumn34, Me.GridColumn35})
        Me.GVBomDetWip.CustomizationFormBounds = New System.Drawing.Rectangle(885, 289, 216, 178)
        Me.GVBomDetWip.GridControl = Me.GCBomDetWip
        Me.GVBomDetWip.GroupSummary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "total", Me.GridColumn35, "{0:N2}")})
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
        Me.GridColumn34.DisplayFormat.FormatString = "N2"
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
        'BEditWip
        '
        Me.BEditWip.ImageIndex = 2
        Me.BEditWip.ImageList = Me.LargeImageCollection
        Me.BEditWip.Location = New System.Drawing.Point(502, 3)
        Me.BEditWip.Name = "BEditWip"
        Me.BEditWip.Size = New System.Drawing.Size(91, 29)
        Me.BEditWip.TabIndex = 20
        Me.BEditWip.Text = "Edit"
        '
        'BAddWip
        '
        Me.BAddWip.ImageIndex = 0
        Me.BAddWip.ImageList = Me.LargeImageCollection
        Me.BAddWip.Location = New System.Drawing.Point(599, 3)
        Me.BAddWip.Name = "BAddWip"
        Me.BAddWip.Size = New System.Drawing.Size(91, 29)
        Me.BAddWip.TabIndex = 19
        Me.BAddWip.Text = "Add"
        '
        'BDelWip
        '
        Me.BDelWip.ImageIndex = 1
        Me.BDelWip.ImageList = Me.LargeImageCollection
        Me.BDelWip.Location = New System.Drawing.Point(405, 3)
        Me.BDelWip.Name = "BDelWip"
        Me.BDelWip.Size = New System.Drawing.Size(91, 29)
        Me.BDelWip.TabIndex = 18
        Me.BDelWip.Text = "Delete"
        '
        'PCLotTitle
        '
        Me.PCLotTitle.Appearance.BackColor = System.Drawing.Color.White
        Me.PCLotTitle.Appearance.BackColor2 = System.Drawing.Color.Transparent
        Me.PCLotTitle.Appearance.BorderColor = System.Drawing.Color.White
        Me.PCLotTitle.Appearance.Options.UseBackColor = True
        Me.PCLotTitle.Appearance.Options.UseBorderColor = True
        Me.PCLotTitle.Controls.Add(Me.LabelPrintedName)
        Me.PCLotTitle.Controls.Add(Me.LSampleTitle)
        Me.PCLotTitle.Dock = System.Windows.Forms.DockStyle.Top
        Me.PCLotTitle.Location = New System.Drawing.Point(0, 0)
        Me.PCLotTitle.LookAndFeel.SkinName = "iMaginary"
        Me.PCLotTitle.Name = "PCLotTitle"
        Me.PCLotTitle.Size = New System.Drawing.Size(975, 40)
        Me.PCLotTitle.TabIndex = 22
        '
        'LabelPrintedName
        '
        Me.LabelPrintedName.Appearance.Font = New System.Drawing.Font("Calibri", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelPrintedName.Location = New System.Drawing.Point(94, 5)
        Me.LabelPrintedName.Name = "LabelPrintedName"
        Me.LabelPrintedName.Size = New System.Drawing.Size(6, 26)
        Me.LabelPrintedName.TabIndex = 4
        Me.LabelPrintedName.Text = "-"
        '
        'LSampleTitle
        '
        Me.LSampleTitle.Appearance.Font = New System.Drawing.Font("Calibri", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LSampleTitle.Location = New System.Drawing.Point(5, 5)
        Me.LSampleTitle.Name = "LSampleTitle"
        Me.LSampleTitle.Size = New System.Drawing.Size(84, 26)
        Me.LSampleTitle.TabIndex = 3
        Me.LSampleTitle.Text = "Method : "
        '
        'PanelControl2
        '
        Me.PanelControl2.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
        Me.PanelControl2.Controls.Add(Me.BDuplicate)
        Me.PanelControl2.Controls.Add(Me.LabelProductCode)
        Me.PanelControl2.Controls.Add(Me.BMark)
        Me.PanelControl2.Controls.Add(Me.Bprint)
        Me.PanelControl2.Controls.Add(Me.BCancel)
        Me.PanelControl2.Controls.Add(Me.BSave)
        Me.PanelControl2.Controls.Add(Me.LTitleProduct)
        Me.PanelControl2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PanelControl2.Location = New System.Drawing.Point(0, 409)
        Me.PanelControl2.Name = "PanelControl2"
        Me.PanelControl2.Size = New System.Drawing.Size(975, 39)
        Me.PanelControl2.TabIndex = 21
        '
        'BDuplicate
        '
        Me.BDuplicate.Dock = System.Windows.Forms.DockStyle.Right
        Me.BDuplicate.Location = New System.Drawing.Point(531, 0)
        Me.BDuplicate.Name = "BDuplicate"
        Me.BDuplicate.Size = New System.Drawing.Size(90, 39)
        Me.BDuplicate.TabIndex = 18
        Me.BDuplicate.Text = "Duplicate"
        '
        'LabelProductCode
        '
        Me.LabelProductCode.Appearance.Font = New System.Drawing.Font("Calibri", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelProductCode.Location = New System.Drawing.Point(94, 6)
        Me.LabelProductCode.Name = "LabelProductCode"
        Me.LabelProductCode.Size = New System.Drawing.Size(6, 26)
        Me.LabelProductCode.TabIndex = 13
        Me.LabelProductCode.Text = "-"
        '
        'BMark
        '
        Me.BMark.Dock = System.Windows.Forms.DockStyle.Right
        Me.BMark.Location = New System.Drawing.Point(621, 0)
        Me.BMark.Name = "BMark"
        Me.BMark.Size = New System.Drawing.Size(90, 39)
        Me.BMark.TabIndex = 16
        Me.BMark.Text = "Mark"
        '
        'Bprint
        '
        Me.Bprint.Dock = System.Windows.Forms.DockStyle.Right
        Me.Bprint.Location = New System.Drawing.Point(711, 0)
        Me.Bprint.Name = "Bprint"
        Me.Bprint.Size = New System.Drawing.Size(90, 39)
        Me.Bprint.TabIndex = 17
        Me.Bprint.Text = "Print"
        '
        'BCancel
        '
        Me.BCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.BCancel.Dock = System.Windows.Forms.DockStyle.Right
        Me.BCancel.Location = New System.Drawing.Point(801, 0)
        Me.BCancel.Name = "BCancel"
        Me.BCancel.Size = New System.Drawing.Size(88, 39)
        Me.BCancel.TabIndex = 11
        Me.BCancel.Text = "Close"
        '
        'BSave
        '
        Me.BSave.Dock = System.Windows.Forms.DockStyle.Right
        Me.BSave.Location = New System.Drawing.Point(889, 0)
        Me.BSave.Name = "BSave"
        Me.BSave.Size = New System.Drawing.Size(86, 39)
        Me.BSave.TabIndex = 10
        Me.BSave.Text = "Save"
        '
        'LTitleProduct
        '
        Me.LTitleProduct.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.LTitleProduct.Appearance.Font = New System.Drawing.Font("Calibri", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LTitleProduct.Location = New System.Drawing.Point(5, 6)
        Me.LTitleProduct.Name = "LTitleProduct"
        Me.LTitleProduct.Size = New System.Drawing.Size(83, 26)
        Me.LTitleProduct.TabIndex = 12
        Me.LTitleProduct.Text = "Product : "
        '
        'MEBOMNote
        '
        Me.MEBOMNote.Location = New System.Drawing.Point(35, 252)
        Me.MEBOMNote.Name = "MEBOMNote"
        Me.MEBOMNote.Size = New System.Drawing.Size(179, 103)
        Me.MEBOMNote.TabIndex = 150
        '
        'LabelControl1
        '
        Me.LabelControl1.Location = New System.Drawing.Point(35, 233)
        Me.LabelControl1.Name = "LabelControl1"
        Me.LabelControl1.Size = New System.Drawing.Size(23, 13)
        Me.LabelControl1.TabIndex = 151
        Me.LabelControl1.Text = "Note"
        '
        'FormBOMSingle
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(975, 448)
        Me.Controls.Add(Me.GroupGeneral)
        Me.Controls.Add(Me.GroupComponent)
        Me.Controls.Add(Me.PCLotTitle)
        Me.Controls.Add(Me.PanelControl2)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FormBOMSingle"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Bill Of Material"
        CType(Me.EPBOM, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LargeImageCollection, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GroupGeneral, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupGeneral.ResumeLayout(False)
        Me.GroupGeneral.PerformLayout()
        CType(Me.TEKurs.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LEReportStatus.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LECurrency.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LETerm.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TEName.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GroupComponent, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupComponent.ResumeLayout(False)
        Me.GroupComponent.PerformLayout()
        CType(Me.TEUnitPrice.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.XTCBOM, System.ComponentModel.ISupportInitialize).EndInit()
        Me.XTCBOM.ResumeLayout(False)
        Me.XTPMat.ResumeLayout(False)
        CType(Me.GCBomDetMat, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVBomDetMat, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RICEisCOP, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.XTPOvh.ResumeLayout(False)
        CType(Me.GCBomDetOvh, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVBomDetOvh, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RCIMainVendor, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView5, System.ComponentModel.ISupportInitialize).EndInit()
        Me.XTPWip.ResumeLayout(False)
        CType(Me.GCBomDetWip, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVBomDetWip, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView9, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PCLotTitle, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PCLotTitle.ResumeLayout(False)
        Me.PCLotTitle.PerformLayout()
        CType(Me.PanelControl2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl2.ResumeLayout(False)
        Me.PanelControl2.PerformLayout()
        CType(Me.MEBOMNote.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents EPBOM As System.Windows.Forms.ErrorProvider
    Public WithEvents LargeImageCollection As DevExpress.Utils.ImageCollection
    Friend WithEvents GroupGeneral As DevExpress.XtraEditors.GroupControl
    Friend WithEvents LEReportStatus As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents LabelControl21 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl5 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LECurrency As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents LETerm As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents LabelControl4 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents TEName As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl3 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents GroupComponent As DevExpress.XtraEditors.GroupControl
    Friend WithEvents TEUnitPrice As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl2 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents XTCBOM As DevExpress.XtraTab.XtraTabControl
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
    Friend WithEvents BEditMat As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BAddMat As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BDelMat As DevExpress.XtraEditors.SimpleButton
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
    Friend WithEvents BEditOVH As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BAddOVH As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BDelOVH As DevExpress.XtraEditors.SimpleButton
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
    Friend WithEvents BEditWip As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BAddWip As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BDelWip As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents PCLotTitle As DevExpress.XtraEditors.PanelControl
    Friend WithEvents LabelPrintedName As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LSampleTitle As DevExpress.XtraEditors.LabelControl
    Friend WithEvents PanelControl2 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents Bprint As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BMark As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents LabelProductCode As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LTitleProduct As DevExpress.XtraEditors.LabelControl
    Friend WithEvents BCancel As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BSave As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents TEKurs As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl6 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents GridColumnIncludeInCost As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents RICEisCOP As DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit
    Friend WithEvents GridColumnOVHCat As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents BSubmitMat As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BSubmitOVH As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents GridColumnOVHMain As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents RCIMainVendor As DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit
    Friend WithEvents GridColumnTotalCost As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents BDuplicate As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents GridColumn8 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnKursMat As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnKursOVH As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnCurrency As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents LabelControl1 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents MEBOMNote As DevExpress.XtraEditors.MemoEdit
End Class
