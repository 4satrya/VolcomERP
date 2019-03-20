<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormProdDemandSingle
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormProdDemandSingle))
        Me.EPProdDemand = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.LESampleDivision = New DevExpress.XtraEditors.LookUpEdit()
        Me.LabelControl4 = New DevExpress.XtraEditors.LabelControl()
        Me.BtnDelRef = New DevExpress.XtraEditors.SimpleButton()
        Me.ButtonEdit1 = New DevExpress.XtraEditors.ButtonEdit()
        Me.LabelControl3 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl1 = New DevExpress.XtraEditors.LabelControl()
        Me.LEPDType = New DevExpress.XtraEditors.LookUpEdit()
        Me.MENote = New DevExpress.XtraEditors.MemoEdit()
        Me.SLESeason = New DevExpress.XtraEditors.SearchLookUpEdit()
        Me.SearchLookUpEdit1View = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumnIdSeason = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnRange = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnSeason = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnDisplayName = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.LabelSeason = New DevExpress.XtraEditors.LabelControl()
        Me.TxtProdDemandNumber = New DevExpress.XtraEditors.TextEdit()
        Me.PCGeneralSave = New DevExpress.XtraEditors.PanelControl()
        Me.BtnAttachment = New DevExpress.XtraEditors.SimpleButton()
        Me.LargeImageCollection = New DevExpress.Utils.ImageCollection(Me.components)
        Me.BtnPrint = New DevExpress.XtraEditors.SimpleButton()
        Me.BMark = New DevExpress.XtraEditors.SimpleButton()
        Me.BtnCancel = New DevExpress.XtraEditors.SimpleButton()
        Me.BtnCancellPropose = New DevExpress.XtraEditors.SimpleButton()
        Me.BtnSave = New DevExpress.XtraEditors.SimpleButton()
        Me.BtnConfirm = New DevExpress.XtraEditors.SimpleButton()
        Me.BBom = New DevExpress.XtraEditors.SimpleButton()
        Me.BtnAdd = New DevExpress.XtraEditors.SimpleButton()
        Me.BtnEdit = New DevExpress.XtraEditors.SimpleButton()
        Me.BtnDelete = New DevExpress.XtraEditors.SimpleButton()
        Me.GroupGeneralHeader = New DevExpress.XtraEditors.GroupControl()
        Me.TxtRateCurrent = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl6 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl5 = New DevExpress.XtraEditors.LabelControl()
        Me.LEBudget = New DevExpress.XtraEditors.LookUpEdit()
        Me.SLEKind = New DevExpress.XtraEditors.SearchLookUpEdit()
        Me.GridView2 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumnIdKind = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnKind = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.LabelControl2 = New DevExpress.XtraEditors.LabelControl()
        Me.LECat = New DevExpress.XtraEditors.LookUpEdit()
        Me.LabelCategory = New DevExpress.XtraEditors.LabelControl()
        Me.PanelControl1 = New DevExpress.XtraEditors.PanelControl()
        Me.DEForm = New DevExpress.XtraEditors.DateEdit()
        Me.LabelControl12 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl11 = New DevExpress.XtraEditors.LabelControl()
        Me.GroupControl3 = New DevExpress.XtraEditors.GroupControl()
        Me.LabelControl21 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl18 = New DevExpress.XtraEditors.LabelControl()
        Me.LEReportStatus = New DevExpress.XtraEditors.LookUpEdit()
        Me.GroupControlList = New DevExpress.XtraEditors.GroupControl()
        Me.GCDesign = New VolcomMRP.MyXtraGrid.MyGridControl()
        Me.GVDesign = New VolcomMRP.MyXtraGrid.MyGridView()
        Me.GridColumnNo = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnCodeImport = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnCode = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnDel = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnSeasonOrigin = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnStyleCountry = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnProductOrigin = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnClass = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnDescription = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnColor = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnSizeChart = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnMKT = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnBuff = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnCore = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnActOrderSales = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnTotalQty = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnCostEstimate = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnAdditionalCost = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnCostEstimateNonAddition = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnRateCurrent = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnPriceEstimate = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnAdditionalPrice = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnPriceEstimateMinAdditional = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnMarkup = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnTotalCostNonAdditional = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnTOtalAmounNonAdditional = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnTotalCost = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnTotalAmount = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnFabrication = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnMoveDrop = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnSTATUS = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnQty1 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnQty2 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnQty3 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnQty4 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnQty5 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnQty6 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnQty7 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnQty8 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnQty9 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnQty10 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.PanelControlCompleted = New DevExpress.XtraEditors.PanelControl()
        Me.PanelControlCENONActive = New DevExpress.XtraEditors.PanelControl()
        Me.CheckEditShowNonActive = New DevExpress.XtraEditors.CheckEdit()
        Me.PanelControlBreakSize = New DevExpress.XtraEditors.PanelControl()
        Me.CEBreakSize = New DevExpress.XtraEditors.CheckEdit()
        Me.PanelControlNav = New DevExpress.XtraEditors.PanelControl()
        Me.BtnAddFromLineList = New DevExpress.XtraEditors.SimpleButton()
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.ViewBreakdownSizeToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.GridView1 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridBand1 = New DevExpress.XtraGrid.Views.BandedGrid.GridBand()
        Me.XTCPD = New DevExpress.XtraTab.XtraTabControl()
        Me.XTPDetail = New DevExpress.XtraTab.XtraTabPage()
        Me.XTPRevision = New DevExpress.XtraTab.XtraTabPage()
        Me.GCData = New DevExpress.XtraGrid.GridControl()
        Me.GVData = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumnIdProdDemandRev = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnIdPD = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnRevCount = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnPDNumber = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnSTT = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnDate = New DevExpress.XtraGrid.Columns.GridColumn()
        CType(Me.EPProdDemand, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LESampleDivision.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ButtonEdit1.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LEPDType.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.MENote.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SLESeason.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SearchLookUpEdit1View, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtProdDemandNumber.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PCGeneralSave, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PCGeneralSave.SuspendLayout()
        CType(Me.LargeImageCollection, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GroupGeneralHeader, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupGeneralHeader.SuspendLayout()
        CType(Me.TxtRateCurrent.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LEBudget.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SLEKind.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LECat.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl1.SuspendLayout()
        CType(Me.DEForm.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DEForm.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GroupControl3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupControl3.SuspendLayout()
        CType(Me.LEReportStatus.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GroupControlList, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupControlList.SuspendLayout()
        CType(Me.GCDesign, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVDesign, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PanelControlCompleted, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControlCompleted.SuspendLayout()
        CType(Me.PanelControlCENONActive, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControlCENONActive.SuspendLayout()
        CType(Me.CheckEditShowNonActive.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PanelControlBreakSize, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControlBreakSize.SuspendLayout()
        CType(Me.CEBreakSize.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PanelControlNav, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControlNav.SuspendLayout()
        Me.ContextMenuStrip1.SuspendLayout()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.XTCPD, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.XTCPD.SuspendLayout()
        Me.XTPDetail.SuspendLayout()
        Me.XTPRevision.SuspendLayout()
        CType(Me.GCData, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVData, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'EPProdDemand
        '
        Me.EPProdDemand.ContainerControl = Me
        '
        'LESampleDivision
        '
        Me.LESampleDivision.Location = New System.Drawing.Point(112, 112)
        Me.LESampleDivision.Name = "LESampleDivision"
        Me.LESampleDivision.Properties.Appearance.Options.UseTextOptions = True
        Me.LESampleDivision.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
        Me.LESampleDivision.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.LESampleDivision.Properties.Columns.AddRange(New DevExpress.XtraEditors.Controls.LookUpColumnInfo() {New DevExpress.XtraEditors.Controls.LookUpColumnInfo("id_code_detail", "ID Division", 20, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("display_name", "Display Name"), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("code_detail_name", "Division")})
        Me.LESampleDivision.Properties.NullText = ""
        Me.LESampleDivision.Properties.ShowFooter = False
        Me.LESampleDivision.Size = New System.Drawing.Size(316, 20)
        Me.LESampleDivision.TabIndex = 4
        '
        'LabelControl4
        '
        Me.LabelControl4.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl4.Location = New System.Drawing.Point(27, 115)
        Me.LabelControl4.Name = "LabelControl4"
        Me.LabelControl4.Size = New System.Drawing.Size(36, 13)
        Me.LabelControl4.TabIndex = 56
        Me.LabelControl4.Text = "Division"
        '
        'BtnDelRef
        '
        Me.BtnDelRef.Location = New System.Drawing.Point(354, 227)
        Me.BtnDelRef.Name = "BtnDelRef"
        Me.BtnDelRef.Size = New System.Drawing.Size(75, 23)
        Me.BtnDelRef.TabIndex = 1
        Me.BtnDelRef.Text = "Delete Ref"
        '
        'ButtonEdit1
        '
        Me.ButtonEdit1.Location = New System.Drawing.Point(94, 229)
        Me.ButtonEdit1.Name = "ButtonEdit1"
        Me.ButtonEdit1.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.ButtonEdit1.Size = New System.Drawing.Size(254, 20)
        Me.ButtonEdit1.TabIndex = 0
        '
        'LabelControl3
        '
        Me.LabelControl3.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl3.Location = New System.Drawing.Point(28, 232)
        Me.LabelControl3.Name = "LabelControl3"
        Me.LabelControl3.Size = New System.Drawing.Size(50, 13)
        Me.LabelControl3.TabIndex = 54
        Me.LabelControl3.Text = "Reference"
        '
        'LabelControl1
        '
        Me.LabelControl1.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl1.Location = New System.Drawing.Point(28, 204)
        Me.LabelControl1.Name = "LabelControl1"
        Me.LabelControl1.Size = New System.Drawing.Size(24, 13)
        Me.LabelControl1.TabIndex = 53
        Me.LabelControl1.Text = "Type"
        '
        'LEPDType
        '
        Me.LEPDType.Location = New System.Drawing.Point(94, 201)
        Me.LEPDType.Name = "LEPDType"
        Me.LEPDType.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.LEPDType.Properties.Columns.AddRange(New DevExpress.XtraEditors.Controls.LookUpColumnInfo() {New DevExpress.XtraEditors.Controls.LookUpColumnInfo("id_pd_type", "Id Pd Type", 20, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("pd_type", "Type")})
        Me.LEPDType.Size = New System.Drawing.Size(335, 20)
        Me.LEPDType.TabIndex = 3
        '
        'MENote
        '
        Me.MENote.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.MENote.Location = New System.Drawing.Point(72, 6)
        Me.MENote.Name = "MENote"
        Me.MENote.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MENote.Properties.Appearance.Options.UseFont = True
        Me.MENote.Size = New System.Drawing.Size(350, 60)
        Me.MENote.TabIndex = 2
        '
        'SLESeason
        '
        Me.SLESeason.Location = New System.Drawing.Point(112, 8)
        Me.SLESeason.Name = "SLESeason"
        Me.SLESeason.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SLESeason.Properties.Appearance.Options.UseFont = True
        Me.SLESeason.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.SLESeason.Properties.ShowClearButton = False
        Me.SLESeason.Properties.View = Me.SearchLookUpEdit1View
        Me.SLESeason.Size = New System.Drawing.Size(316, 20)
        Me.SLESeason.TabIndex = 1
        '
        'SearchLookUpEdit1View
        '
        Me.SearchLookUpEdit1View.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumnIdSeason, Me.GridColumnRange, Me.GridColumnSeason, Me.GridColumnDisplayName})
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
        'GridColumnDisplayName
        '
        Me.GridColumnDisplayName.Caption = "Short Name"
        Me.GridColumnDisplayName.FieldName = "season_printed_name"
        Me.GridColumnDisplayName.Name = "GridColumnDisplayName"
        Me.GridColumnDisplayName.Visible = True
        Me.GridColumnDisplayName.VisibleIndex = 2
        '
        'LabelSeason
        '
        Me.LabelSeason.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelSeason.Location = New System.Drawing.Point(27, 11)
        Me.LabelSeason.Name = "LabelSeason"
        Me.LabelSeason.Size = New System.Drawing.Size(35, 13)
        Me.LabelSeason.TabIndex = 49
        Me.LabelSeason.Text = "Season"
        '
        'TxtProdDemandNumber
        '
        Me.TxtProdDemandNumber.Location = New System.Drawing.Point(50, 32)
        Me.TxtProdDemandNumber.Name = "TxtProdDemandNumber"
        Me.TxtProdDemandNumber.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtProdDemandNumber.Properties.Appearance.Options.UseFont = True
        Me.TxtProdDemandNumber.Properties.MaxLength = 50
        Me.TxtProdDemandNumber.Properties.ReadOnly = True
        Me.TxtProdDemandNumber.Size = New System.Drawing.Size(195, 20)
        Me.TxtProdDemandNumber.TabIndex = 5
        Me.TxtProdDemandNumber.ToolTip = "Example : PD/R19/MENS/05/XI/2013"
        Me.TxtProdDemandNumber.ToolTipIconType = DevExpress.Utils.ToolTipIconType.Information
        Me.TxtProdDemandNumber.ToolTipTitle = "Information"
        '
        'PCGeneralSave
        '
        Me.PCGeneralSave.Controls.Add(Me.BtnAttachment)
        Me.PCGeneralSave.Controls.Add(Me.BtnPrint)
        Me.PCGeneralSave.Controls.Add(Me.BMark)
        Me.PCGeneralSave.Controls.Add(Me.BtnCancel)
        Me.PCGeneralSave.Controls.Add(Me.BtnCancellPropose)
        Me.PCGeneralSave.Controls.Add(Me.BtnSave)
        Me.PCGeneralSave.Controls.Add(Me.BtnConfirm)
        Me.PCGeneralSave.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PCGeneralSave.Location = New System.Drawing.Point(0, 563)
        Me.PCGeneralSave.LookAndFeel.SkinName = "Blue"
        Me.PCGeneralSave.LookAndFeel.UseDefaultLookAndFeel = False
        Me.PCGeneralSave.Name = "PCGeneralSave"
        Me.PCGeneralSave.Size = New System.Drawing.Size(964, 42)
        Me.PCGeneralSave.TabIndex = 4
        '
        'BtnAttachment
        '
        Me.BtnAttachment.Dock = System.Windows.Forms.DockStyle.Right
        Me.BtnAttachment.ImageIndex = 16
        Me.BtnAttachment.ImageList = Me.LargeImageCollection
        Me.BtnAttachment.Location = New System.Drawing.Point(370, 2)
        Me.BtnAttachment.Name = "BtnAttachment"
        Me.BtnAttachment.Size = New System.Drawing.Size(103, 38)
        Me.BtnAttachment.TabIndex = 13
        Me.BtnAttachment.Text = "Attachment"
        '
        'LargeImageCollection
        '
        Me.LargeImageCollection.ImageSize = New System.Drawing.Size(24, 24)
        Me.LargeImageCollection.ImageStream = CType(resources.GetObject("LargeImageCollection.ImageStream"), DevExpress.Utils.ImageCollectionStreamer)
        Me.LargeImageCollection.Images.SetKeyName(0, "20_24x24.png")
        Me.LargeImageCollection.Images.SetKeyName(1, "8_24x24.png")
        Me.LargeImageCollection.Images.SetKeyName(2, "23_24x24.png")
        Me.LargeImageCollection.Images.SetKeyName(3, "arrow_refresh.png")
        Me.LargeImageCollection.Images.SetKeyName(4, "check_mark.png")
        Me.LargeImageCollection.Images.SetKeyName(5, "gnome_application_exit (1).png")
        Me.LargeImageCollection.Images.SetKeyName(6, "printer_3.png")
        Me.LargeImageCollection.Images.SetKeyName(7, "save.png")
        Me.LargeImageCollection.Images.SetKeyName(8, "31_24x24.png")
        Me.LargeImageCollection.Images.SetKeyName(9, "18_24x24.png")
        Me.LargeImageCollection.Images.SetKeyName(10, "10_32x32.png")
        Me.LargeImageCollection.Images.SetKeyName(11, "18_32x32.png")
        Me.LargeImageCollection.Images.SetKeyName(12, "31_32x32.png")
        Me.LargeImageCollection.Images.SetKeyName(13, "folder-documents-icon.png")
        Me.LargeImageCollection.Images.SetKeyName(14, "mail_attachment.png")
        Me.LargeImageCollection.Images.SetKeyName(15, "1417618546_Blue tag.png")
        Me.LargeImageCollection.Images.SetKeyName(16, "attachment-icon.png")
        Me.LargeImageCollection.Images.SetKeyName(17, "1415351112474759854-32.png")
        Me.LargeImageCollection.Images.SetKeyName(18, "Autoship32.png")
        '
        'BtnPrint
        '
        Me.BtnPrint.Dock = System.Windows.Forms.DockStyle.Right
        Me.BtnPrint.ImageIndex = 6
        Me.BtnPrint.ImageList = Me.LargeImageCollection
        Me.BtnPrint.Location = New System.Drawing.Point(473, 2)
        Me.BtnPrint.Name = "BtnPrint"
        Me.BtnPrint.Size = New System.Drawing.Size(75, 38)
        Me.BtnPrint.TabIndex = 12
        Me.BtnPrint.Text = "Print"
        '
        'BMark
        '
        Me.BMark.Dock = System.Windows.Forms.DockStyle.Left
        Me.BMark.ImageIndex = 4
        Me.BMark.ImageList = Me.LargeImageCollection
        Me.BMark.Location = New System.Drawing.Point(2, 2)
        Me.BMark.Name = "BMark"
        Me.BMark.Size = New System.Drawing.Size(75, 38)
        Me.BMark.TabIndex = 14
        Me.BMark.Text = "Mark"
        '
        'BtnCancel
        '
        Me.BtnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.BtnCancel.Dock = System.Windows.Forms.DockStyle.Right
        Me.BtnCancel.ImageIndex = 5
        Me.BtnCancel.ImageList = Me.LargeImageCollection
        Me.BtnCancel.Location = New System.Drawing.Point(548, 2)
        Me.BtnCancel.Name = "BtnCancel"
        Me.BtnCancel.Size = New System.Drawing.Size(87, 38)
        Me.BtnCancel.TabIndex = 11
        Me.BtnCancel.Text = "Close"
        '
        'BtnCancellPropose
        '
        Me.BtnCancellPropose.Dock = System.Windows.Forms.DockStyle.Right
        Me.BtnCancellPropose.Image = CType(resources.GetObject("BtnCancellPropose.Image"), System.Drawing.Image)
        Me.BtnCancellPropose.Location = New System.Drawing.Point(635, 2)
        Me.BtnCancellPropose.Name = "BtnCancellPropose"
        Me.BtnCancellPropose.Size = New System.Drawing.Size(126, 38)
        Me.BtnCancellPropose.TabIndex = 16
        Me.BtnCancellPropose.Text = "Cancell Propose"
        Me.BtnCancellPropose.Visible = False
        '
        'BtnSave
        '
        Me.BtnSave.Dock = System.Windows.Forms.DockStyle.Right
        Me.BtnSave.ImageIndex = 7
        Me.BtnSave.ImageList = Me.LargeImageCollection
        Me.BtnSave.Location = New System.Drawing.Point(761, 2)
        Me.BtnSave.Name = "BtnSave"
        Me.BtnSave.Size = New System.Drawing.Size(105, 38)
        Me.BtnSave.TabIndex = 10
        Me.BtnSave.Text = "Create New"
        '
        'BtnConfirm
        '
        Me.BtnConfirm.Dock = System.Windows.Forms.DockStyle.Right
        Me.BtnConfirm.Image = CType(resources.GetObject("BtnConfirm.Image"), System.Drawing.Image)
        Me.BtnConfirm.ImageIndex = 16
        Me.BtnConfirm.ImageList = Me.LargeImageCollection
        Me.BtnConfirm.Location = New System.Drawing.Point(866, 2)
        Me.BtnConfirm.Name = "BtnConfirm"
        Me.BtnConfirm.Size = New System.Drawing.Size(96, 38)
        Me.BtnConfirm.TabIndex = 17
        Me.BtnConfirm.Text = "Confirm"
        Me.BtnConfirm.Visible = False
        '
        'BBom
        '
        Me.BBom.Dock = System.Windows.Forms.DockStyle.Right
        Me.BBom.ImageIndex = 17
        Me.BBom.ImageList = Me.LargeImageCollection
        Me.BBom.Location = New System.Drawing.Point(456, 0)
        Me.BBom.Name = "BBom"
        Me.BBom.Size = New System.Drawing.Size(91, 35)
        Me.BBom.TabIndex = 9
        Me.BBom.Text = "BOM"
        Me.BBom.Visible = False
        '
        'BtnAdd
        '
        Me.BtnAdd.Dock = System.Windows.Forms.DockStyle.Right
        Me.BtnAdd.ImageIndex = 0
        Me.BtnAdd.ImageList = Me.LargeImageCollection
        Me.BtnAdd.Location = New System.Drawing.Point(845, 0)
        Me.BtnAdd.Name = "BtnAdd"
        Me.BtnAdd.Size = New System.Drawing.Size(91, 35)
        Me.BtnAdd.TabIndex = 5
        Me.BtnAdd.Text = "Add"
        Me.BtnAdd.Visible = False
        '
        'BtnEdit
        '
        Me.BtnEdit.Dock = System.Windows.Forms.DockStyle.Right
        Me.BtnEdit.ImageIndex = 2
        Me.BtnEdit.ImageList = Me.LargeImageCollection
        Me.BtnEdit.Location = New System.Drawing.Point(761, 0)
        Me.BtnEdit.Name = "BtnEdit"
        Me.BtnEdit.Size = New System.Drawing.Size(84, 35)
        Me.BtnEdit.TabIndex = 6
        Me.BtnEdit.Text = "Edit"
        Me.BtnEdit.Visible = False
        '
        'BtnDelete
        '
        Me.BtnDelete.Dock = System.Windows.Forms.DockStyle.Right
        Me.BtnDelete.ImageIndex = 1
        Me.BtnDelete.ImageList = Me.LargeImageCollection
        Me.BtnDelete.Location = New System.Drawing.Point(547, 0)
        Me.BtnDelete.Name = "BtnDelete"
        Me.BtnDelete.Size = New System.Drawing.Size(91, 35)
        Me.BtnDelete.TabIndex = 8
        Me.BtnDelete.Text = "Delete"
        '
        'GroupGeneralHeader
        '
        Me.GroupGeneralHeader.CaptionLocation = DevExpress.Utils.Locations.Left
        Me.GroupGeneralHeader.Controls.Add(Me.TxtRateCurrent)
        Me.GroupGeneralHeader.Controls.Add(Me.LabelControl6)
        Me.GroupGeneralHeader.Controls.Add(Me.LabelControl5)
        Me.GroupGeneralHeader.Controls.Add(Me.LEBudget)
        Me.GroupGeneralHeader.Controls.Add(Me.SLEKind)
        Me.GroupGeneralHeader.Controls.Add(Me.LabelControl2)
        Me.GroupGeneralHeader.Controls.Add(Me.LECat)
        Me.GroupGeneralHeader.Controls.Add(Me.LabelCategory)
        Me.GroupGeneralHeader.Controls.Add(Me.PanelControl1)
        Me.GroupGeneralHeader.Controls.Add(Me.SLESeason)
        Me.GroupGeneralHeader.Controls.Add(Me.LEPDType)
        Me.GroupGeneralHeader.Controls.Add(Me.LabelSeason)
        Me.GroupGeneralHeader.Controls.Add(Me.LabelControl1)
        Me.GroupGeneralHeader.Controls.Add(Me.LESampleDivision)
        Me.GroupGeneralHeader.Controls.Add(Me.LabelControl4)
        Me.GroupGeneralHeader.Controls.Add(Me.BtnDelRef)
        Me.GroupGeneralHeader.Controls.Add(Me.ButtonEdit1)
        Me.GroupGeneralHeader.Controls.Add(Me.LabelControl3)
        Me.GroupGeneralHeader.Dock = System.Windows.Forms.DockStyle.Top
        Me.GroupGeneralHeader.Location = New System.Drawing.Point(0, 0)
        Me.GroupGeneralHeader.Name = "GroupGeneralHeader"
        Me.GroupGeneralHeader.Size = New System.Drawing.Size(964, 176)
        Me.GroupGeneralHeader.TabIndex = 185
        '
        'TxtRateCurrent
        '
        Me.TxtRateCurrent.Enabled = False
        Me.TxtRateCurrent.Location = New System.Drawing.Point(112, 138)
        Me.TxtRateCurrent.Name = "TxtRateCurrent"
        Me.TxtRateCurrent.Properties.DisplayFormat.FormatString = "N2"
        Me.TxtRateCurrent.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.TxtRateCurrent.Size = New System.Drawing.Size(317, 20)
        Me.TxtRateCurrent.TabIndex = 167
        '
        'LabelControl6
        '
        Me.LabelControl6.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl6.Location = New System.Drawing.Point(27, 141)
        Me.LabelControl6.Name = "LabelControl6"
        Me.LabelControl6.Size = New System.Drawing.Size(63, 13)
        Me.LabelControl6.TabIndex = 166
        Me.LabelControl6.Text = "Rate Current"
        '
        'LabelControl5
        '
        Me.LabelControl5.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl5.Location = New System.Drawing.Point(27, 63)
        Me.LabelControl5.Name = "LabelControl5"
        Me.LabelControl5.Size = New System.Drawing.Size(61, 13)
        Me.LabelControl5.TabIndex = 165
        Me.LabelControl5.Text = "Budget Type"
        '
        'LEBudget
        '
        Me.LEBudget.Location = New System.Drawing.Point(112, 60)
        Me.LEBudget.Name = "LEBudget"
        Me.LEBudget.Properties.Appearance.Options.UseTextOptions = True
        Me.LEBudget.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
        Me.LEBudget.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.LEBudget.Properties.Columns.AddRange(New DevExpress.XtraEditors.Controls.LookUpColumnInfo() {New DevExpress.XtraEditors.Controls.LookUpColumnInfo("id_pd_budget", "Id", 20, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("pd_budget", "Budget")})
        Me.LEBudget.Properties.NullText = ""
        Me.LEBudget.Properties.ShowFooter = False
        Me.LEBudget.Size = New System.Drawing.Size(316, 20)
        Me.LEBudget.TabIndex = 164
        '
        'SLEKind
        '
        Me.SLEKind.Location = New System.Drawing.Point(112, 34)
        Me.SLEKind.Name = "SLEKind"
        Me.SLEKind.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SLEKind.Properties.Appearance.Options.UseFont = True
        Me.SLEKind.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.SLEKind.Properties.ShowClearButton = False
        Me.SLEKind.Properties.View = Me.GridView2
        Me.SLEKind.Size = New System.Drawing.Size(316, 20)
        Me.SLEKind.TabIndex = 2
        '
        'GridView2
        '
        Me.GridView2.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumnIdKind, Me.GridColumnKind})
        Me.GridView2.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
        Me.GridView2.Name = "GridView2"
        Me.GridView2.OptionsSelection.EnableAppearanceFocusedCell = False
        Me.GridView2.OptionsView.ShowGroupPanel = False
        '
        'GridColumnIdKind
        '
        Me.GridColumnIdKind.Caption = "Id"
        Me.GridColumnIdKind.FieldName = "id_pd_kind"
        Me.GridColumnIdKind.Name = "GridColumnIdKind"
        '
        'GridColumnKind
        '
        Me.GridColumnKind.Caption = "Type"
        Me.GridColumnKind.FieldName = "pd_kind"
        Me.GridColumnKind.Name = "GridColumnKind"
        Me.GridColumnKind.Visible = True
        Me.GridColumnKind.VisibleIndex = 0
        '
        'LabelControl2
        '
        Me.LabelControl2.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl2.Location = New System.Drawing.Point(27, 37)
        Me.LabelControl2.Name = "LabelControl2"
        Me.LabelControl2.Size = New System.Drawing.Size(24, 13)
        Me.LabelControl2.TabIndex = 163
        Me.LabelControl2.Text = "Type"
        '
        'LECat
        '
        Me.LECat.Location = New System.Drawing.Point(112, 86)
        Me.LECat.Name = "LECat"
        Me.LECat.Properties.Appearance.Options.UseTextOptions = True
        Me.LECat.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
        Me.LECat.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.LECat.Properties.Columns.AddRange(New DevExpress.XtraEditors.Controls.LookUpColumnInfo() {New DevExpress.XtraEditors.Controls.LookUpColumnInfo("id_pd", "Id", 20, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("pd", "Phase")})
        Me.LECat.Properties.NullText = ""
        Me.LECat.Properties.ShowFooter = False
        Me.LECat.Size = New System.Drawing.Size(316, 20)
        Me.LECat.TabIndex = 3
        '
        'LabelCategory
        '
        Me.LabelCategory.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelCategory.Location = New System.Drawing.Point(27, 89)
        Me.LabelCategory.Name = "LabelCategory"
        Me.LabelCategory.Size = New System.Drawing.Size(29, 13)
        Me.LabelCategory.TabIndex = 162
        Me.LabelCategory.Text = "Phase"
        '
        'PanelControl1
        '
        Me.PanelControl1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
        Me.PanelControl1.Controls.Add(Me.TxtProdDemandNumber)
        Me.PanelControl1.Controls.Add(Me.DEForm)
        Me.PanelControl1.Controls.Add(Me.LabelControl12)
        Me.PanelControl1.Controls.Add(Me.LabelControl11)
        Me.PanelControl1.Dock = System.Windows.Forms.DockStyle.Right
        Me.PanelControl1.Location = New System.Drawing.Point(707, 2)
        Me.PanelControl1.Name = "PanelControl1"
        Me.PanelControl1.Size = New System.Drawing.Size(255, 172)
        Me.PanelControl1.TabIndex = 161
        '
        'DEForm
        '
        Me.DEForm.EditValue = Nothing
        Me.DEForm.Location = New System.Drawing.Point(50, 6)
        Me.DEForm.Name = "DEForm"
        Me.DEForm.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.DEForm.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.DEForm.Properties.DisplayFormat.FormatString = "dd MMMM yyyy"
        Me.DEForm.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.DEForm.Properties.ReadOnly = True
        Me.DEForm.Size = New System.Drawing.Size(195, 20)
        Me.DEForm.TabIndex = 160
        Me.DEForm.TabStop = False
        '
        'LabelControl12
        '
        Me.LabelControl12.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl12.Location = New System.Drawing.Point(7, 9)
        Me.LabelControl12.Name = "LabelControl12"
        Me.LabelControl12.Size = New System.Drawing.Size(23, 13)
        Me.LabelControl12.TabIndex = 159
        Me.LabelControl12.Text = "Date"
        '
        'LabelControl11
        '
        Me.LabelControl11.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl11.Location = New System.Drawing.Point(7, 35)
        Me.LabelControl11.Name = "LabelControl11"
        Me.LabelControl11.Size = New System.Drawing.Size(37, 13)
        Me.LabelControl11.TabIndex = 155
        Me.LabelControl11.Text = "Number"
        '
        'GroupControl3
        '
        Me.GroupControl3.CaptionLocation = DevExpress.Utils.Locations.Left
        Me.GroupControl3.Controls.Add(Me.MENote)
        Me.GroupControl3.Controls.Add(Me.LabelControl21)
        Me.GroupControl3.Controls.Add(Me.LabelControl18)
        Me.GroupControl3.Controls.Add(Me.LEReportStatus)
        Me.GroupControl3.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.GroupControl3.Location = New System.Drawing.Point(0, 459)
        Me.GroupControl3.Name = "GroupControl3"
        Me.GroupControl3.Size = New System.Drawing.Size(964, 104)
        Me.GroupControl3.TabIndex = 187
        '
        'LabelControl21
        '
        Me.LabelControl21.Location = New System.Drawing.Point(27, 79)
        Me.LabelControl21.Name = "LabelControl21"
        Me.LabelControl21.Size = New System.Drawing.Size(31, 13)
        Me.LabelControl21.TabIndex = 144
        Me.LabelControl21.Text = "Status"
        '
        'LabelControl18
        '
        Me.LabelControl18.Location = New System.Drawing.Point(27, 8)
        Me.LabelControl18.Name = "LabelControl18"
        Me.LabelControl18.Size = New System.Drawing.Size(23, 13)
        Me.LabelControl18.TabIndex = 138
        Me.LabelControl18.Text = "Note"
        '
        'LEReportStatus
        '
        Me.LEReportStatus.Enabled = False
        Me.LEReportStatus.Location = New System.Drawing.Point(72, 76)
        Me.LEReportStatus.Name = "LEReportStatus"
        Me.LEReportStatus.Properties.Appearance.Options.UseTextOptions = True
        Me.LEReportStatus.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
        Me.LEReportStatus.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.LEReportStatus.Properties.Columns.AddRange(New DevExpress.XtraEditors.Controls.LookUpColumnInfo() {New DevExpress.XtraEditors.Controls.LookUpColumnInfo("id_report_status", "ID Report Status", 20, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("report_status", "Report Status")})
        Me.LEReportStatus.Properties.NullText = ""
        Me.LEReportStatus.Properties.ShowFooter = False
        Me.LEReportStatus.Size = New System.Drawing.Size(350, 20)
        Me.LEReportStatus.TabIndex = 7
        '
        'GroupControlList
        '
        Me.GroupControlList.CaptionLocation = DevExpress.Utils.Locations.Left
        Me.GroupControlList.Controls.Add(Me.GCDesign)
        Me.GroupControlList.Controls.Add(Me.PanelControlCompleted)
        Me.GroupControlList.Controls.Add(Me.PanelControlNav)
        Me.GroupControlList.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupControlList.Enabled = False
        Me.GroupControlList.Location = New System.Drawing.Point(0, 0)
        Me.GroupControlList.Name = "GroupControlList"
        Me.GroupControlList.Size = New System.Drawing.Size(958, 255)
        Me.GroupControlList.TabIndex = 188
        '
        'GCDesign
        '
        Me.GCDesign.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCDesign.Location = New System.Drawing.Point(20, 37)
        Me.GCDesign.MainView = Me.GVDesign
        Me.GCDesign.Name = "GCDesign"
        Me.GCDesign.Size = New System.Drawing.Size(936, 184)
        Me.GCDesign.TabIndex = 42
        Me.GCDesign.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVDesign})
        '
        'GVDesign
        '
        Me.GVDesign.AppearancePrint.HeaderPanel.Options.UseTextOptions = True
        Me.GVDesign.AppearancePrint.HeaderPanel.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
        Me.GVDesign.ColumnPanelRowHeight = 30
        Me.GVDesign.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumnNo, Me.GridColumnCodeImport, Me.GridColumnCode, Me.GridColumnDel, Me.GridColumnSeasonOrigin, Me.GridColumnStyleCountry, Me.GridColumnProductOrigin, Me.GridColumnClass, Me.GridColumnDescription, Me.GridColumnColor, Me.GridColumnSizeChart, Me.GridColumnMKT, Me.GridColumnBuff, Me.GridColumnCore, Me.GridColumnActOrderSales, Me.GridColumnTotalQty, Me.GridColumnCostEstimate, Me.GridColumnAdditionalCost, Me.GridColumnCostEstimateNonAddition, Me.GridColumnRateCurrent, Me.GridColumnPriceEstimate, Me.GridColumnAdditionalPrice, Me.GridColumnPriceEstimateMinAdditional, Me.GridColumnMarkup, Me.GridColumnTotalCostNonAdditional, Me.GridColumnTOtalAmounNonAdditional, Me.GridColumnTotalCost, Me.GridColumnTotalAmount, Me.GridColumnFabrication, Me.GridColumnMoveDrop, Me.GridColumnSTATUS, Me.GridColumnQty1, Me.GridColumnQty2, Me.GridColumnQty3, Me.GridColumnQty4, Me.GridColumnQty5, Me.GridColumnQty6, Me.GridColumnQty7, Me.GridColumnQty8, Me.GridColumnQty9, Me.GridColumnQty10})
        Me.GVDesign.GridControl = Me.GCDesign
        Me.GVDesign.GroupSummary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "MARKETING_add_report_column", Nothing, "{0:N0}"), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "BUFFER STYLE_add_report_column", Me.GridColumnBuff, "{0:N0}"), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "CORE_add_report_column", Me.GridColumnCore, "{0:N0}"), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "ACT ORDER SALES_add_report_column", Me.GridColumnActOrderSales, "{0:N0}"), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "TOTAL QTY_add_report_column", Me.GridColumnTotalQty, "{0:N0}"), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "TOTAL COST NON ADDITIONAL_add_report_column", Me.GridColumnTotalCostNonAdditional, "{0:N2}"), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "TOTAL AMOUNT NON ADDITIONAL_add_report_column", Me.GridColumnTOtalAmounNonAdditional, "{0:N2}"), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "TOTAL COST_add_report_column", Me.GridColumnTotalCost, "{0:N2}"), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "TOTAL AMOUNT_add_report_column", Me.GridColumnTotalAmount, "{0:N2}"), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Custom, "MARK UP_add_report_column", Me.GridColumnMarkup, "{0:N2}", 47), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "qty1", Me.GridColumnQty1, "{0:N0}"), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "qty2", Me.GridColumnQty2, "{0:N0}"), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "qty3", Me.GridColumnQty3, "{0:N0}"), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "qty4", Me.GridColumnQty4, "{0:N0}"), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "qty5", Me.GridColumnQty5, "{0:N0}"), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "qty6", Me.GridColumnQty6, "{0:N0}"), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "qty7", Me.GridColumnQty7, "{0:N0}"), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "qty8", Me.GridColumnQty8, "{0:N0}"), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "qty9", Me.GridColumnQty9, "{0:N0}"), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "qty10", Me.GridColumnQty10, "{0:N0}")})
        Me.GVDesign.HorzScrollVisibility = DevExpress.XtraGrid.Views.Base.ScrollVisibility.Always
        Me.GVDesign.Name = "GVDesign"
        Me.GVDesign.OptionsBehavior.ReadOnly = True
        Me.GVDesign.OptionsCustomization.AllowRowSizing = True
        Me.GVDesign.OptionsPrint.AllowMultilineHeaders = True
        Me.GVDesign.OptionsView.ColumnAutoWidth = False
        Me.GVDesign.OptionsView.ColumnHeaderAutoHeight = DevExpress.Utils.DefaultBoolean.[True]
        Me.GVDesign.OptionsView.RowAutoHeight = True
        Me.GVDesign.OptionsView.ShowFooter = True
        Me.GVDesign.OptionsView.ShowGroupPanel = False
        Me.GVDesign.RowHeight = 15
        '
        'GridColumnNo
        '
        Me.GridColumnNo.AppearanceHeader.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.GridColumnNo.AppearanceHeader.Options.UseFont = True
        Me.GridColumnNo.Caption = "NO"
        Me.GridColumnNo.FieldName = "No_desc_report_column"
        Me.GridColumnNo.Name = "GridColumnNo"
        Me.GridColumnNo.Visible = True
        Me.GridColumnNo.VisibleIndex = 0
        Me.GridColumnNo.Width = 48
        '
        'GridColumnCodeImport
        '
        Me.GridColumnCodeImport.AppearanceHeader.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.GridColumnCodeImport.AppearanceHeader.Options.UseFont = True
        Me.GridColumnCodeImport.Caption = "CODE IMPORT"
        Me.GridColumnCodeImport.FieldName = "CODE IMPORT_desc_report_column"
        Me.GridColumnCodeImport.Name = "GridColumnCodeImport"
        Me.GridColumnCodeImport.Visible = True
        Me.GridColumnCodeImport.VisibleIndex = 1
        '
        'GridColumnCode
        '
        Me.GridColumnCode.AppearanceHeader.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.GridColumnCode.AppearanceHeader.Options.UseFont = True
        Me.GridColumnCode.Caption = "CODE"
        Me.GridColumnCode.FieldName = "CODE_desc_report_column"
        Me.GridColumnCode.Name = "GridColumnCode"
        Me.GridColumnCode.Visible = True
        Me.GridColumnCode.VisibleIndex = 2
        '
        'GridColumnDel
        '
        Me.GridColumnDel.AppearanceHeader.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.GridColumnDel.AppearanceHeader.Options.UseFont = True
        Me.GridColumnDel.Caption = "DEL"
        Me.GridColumnDel.FieldName = "DEL_desc_report_column"
        Me.GridColumnDel.Name = "GridColumnDel"
        Me.GridColumnDel.Visible = True
        Me.GridColumnDel.VisibleIndex = 3
        Me.GridColumnDel.Width = 43
        '
        'GridColumnSeasonOrigin
        '
        Me.GridColumnSeasonOrigin.AppearanceHeader.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.GridColumnSeasonOrigin.AppearanceHeader.Options.UseFont = True
        Me.GridColumnSeasonOrigin.Caption = "SEASON ORIGIN"
        Me.GridColumnSeasonOrigin.FieldName = "SEASON ORIGIN_desc_report_column"
        Me.GridColumnSeasonOrigin.Name = "GridColumnSeasonOrigin"
        Me.GridColumnSeasonOrigin.Visible = True
        Me.GridColumnSeasonOrigin.VisibleIndex = 4
        Me.GridColumnSeasonOrigin.Width = 65
        '
        'GridColumnStyleCountry
        '
        Me.GridColumnStyleCountry.AppearanceHeader.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.GridColumnStyleCountry.AppearanceHeader.Options.UseFont = True
        Me.GridColumnStyleCountry.Caption = "STYLE COUNTRY"
        Me.GridColumnStyleCountry.FieldName = "STYLE COUNTRY_desc_report_column"
        Me.GridColumnStyleCountry.Name = "GridColumnStyleCountry"
        Me.GridColumnStyleCountry.Visible = True
        Me.GridColumnStyleCountry.VisibleIndex = 5
        Me.GridColumnStyleCountry.Width = 72
        '
        'GridColumnProductOrigin
        '
        Me.GridColumnProductOrigin.AppearanceHeader.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.GridColumnProductOrigin.AppearanceHeader.Options.UseFont = True
        Me.GridColumnProductOrigin.Caption = "PRODUCT ORIGIN"
        Me.GridColumnProductOrigin.FieldName = "PRODUCT SOURCE_desc_report_column"
        Me.GridColumnProductOrigin.Name = "GridColumnProductOrigin"
        Me.GridColumnProductOrigin.Visible = True
        Me.GridColumnProductOrigin.VisibleIndex = 6
        Me.GridColumnProductOrigin.Width = 65
        '
        'GridColumnClass
        '
        Me.GridColumnClass.AppearanceHeader.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.GridColumnClass.AppearanceHeader.Options.UseFont = True
        Me.GridColumnClass.Caption = "CLASS"
        Me.GridColumnClass.FieldName = "CLASS_desc_report_column"
        Me.GridColumnClass.Name = "GridColumnClass"
        Me.GridColumnClass.Visible = True
        Me.GridColumnClass.VisibleIndex = 7
        Me.GridColumnClass.Width = 54
        '
        'GridColumnDescription
        '
        Me.GridColumnDescription.AppearanceCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
        Me.GridColumnDescription.AppearanceHeader.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.GridColumnDescription.AppearanceHeader.Options.UseFont = True
        Me.GridColumnDescription.Caption = "DESCRIPTION"
        Me.GridColumnDescription.FieldName = "DESCRIPTION_desc_report_column"
        Me.GridColumnDescription.Name = "GridColumnDescription"
        Me.GridColumnDescription.Visible = True
        Me.GridColumnDescription.VisibleIndex = 8
        Me.GridColumnDescription.Width = 143
        '
        'GridColumnColor
        '
        Me.GridColumnColor.AppearanceHeader.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.GridColumnColor.AppearanceHeader.Options.UseFont = True
        Me.GridColumnColor.Caption = "COLOR"
        Me.GridColumnColor.FieldName = "COLOR_desc_report_column"
        Me.GridColumnColor.Name = "GridColumnColor"
        Me.GridColumnColor.Visible = True
        Me.GridColumnColor.VisibleIndex = 9
        Me.GridColumnColor.Width = 57
        '
        'GridColumnSizeChart
        '
        Me.GridColumnSizeChart.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumnSizeChart.AppearanceCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
        Me.GridColumnSizeChart.AppearanceHeader.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.GridColumnSizeChart.AppearanceHeader.Options.UseFont = True
        Me.GridColumnSizeChart.Caption = "SIZE CHART"
        Me.GridColumnSizeChart.FieldName = "SIZE CHART_desc_report_column"
        Me.GridColumnSizeChart.Name = "GridColumnSizeChart"
        Me.GridColumnSizeChart.Visible = True
        Me.GridColumnSizeChart.VisibleIndex = 10
        Me.GridColumnSizeChart.Width = 65
        '
        'GridColumnMKT
        '
        Me.GridColumnMKT.AppearanceHeader.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.GridColumnMKT.AppearanceHeader.Options.UseFont = True
        Me.GridColumnMKT.Caption = "MKT"
        Me.GridColumnMKT.DisplayFormat.FormatString = "N0"
        Me.GridColumnMKT.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumnMKT.FieldName = "MARKETING_add_report_column"
        Me.GridColumnMKT.Name = "GridColumnMKT"
        Me.GridColumnMKT.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "MARKETING_add_report_column", "{0:N0}")})
        Me.GridColumnMKT.Visible = True
        Me.GridColumnMKT.VisibleIndex = 13
        Me.GridColumnMKT.Width = 46
        '
        'GridColumnBuff
        '
        Me.GridColumnBuff.AppearanceHeader.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.GridColumnBuff.AppearanceHeader.Options.UseFont = True
        Me.GridColumnBuff.Caption = "BUFF"
        Me.GridColumnBuff.DisplayFormat.FormatString = "N0"
        Me.GridColumnBuff.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumnBuff.FieldName = "BUFFER STYLE_add_report_column"
        Me.GridColumnBuff.Name = "GridColumnBuff"
        Me.GridColumnBuff.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "BUFFER STYLE_add_report_column", "{0:N0}")})
        Me.GridColumnBuff.Visible = True
        Me.GridColumnBuff.VisibleIndex = 14
        Me.GridColumnBuff.Width = 47
        '
        'GridColumnCore
        '
        Me.GridColumnCore.AppearanceHeader.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.GridColumnCore.AppearanceHeader.Options.UseFont = True
        Me.GridColumnCore.Caption = "CORE"
        Me.GridColumnCore.DisplayFormat.FormatString = "N0"
        Me.GridColumnCore.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumnCore.FieldName = "CORE_add_report_column"
        Me.GridColumnCore.Name = "GridColumnCore"
        Me.GridColumnCore.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "CORE_add_report_column", "{0:N0}")})
        Me.GridColumnCore.Visible = True
        Me.GridColumnCore.VisibleIndex = 15
        Me.GridColumnCore.Width = 53
        '
        'GridColumnActOrderSales
        '
        Me.GridColumnActOrderSales.AppearanceHeader.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.GridColumnActOrderSales.AppearanceHeader.Options.UseFont = True
        Me.GridColumnActOrderSales.Caption = "ACT ORDER SALES"
        Me.GridColumnActOrderSales.DisplayFormat.FormatString = "N0"
        Me.GridColumnActOrderSales.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumnActOrderSales.FieldName = "ACT ORDER SALES_add_report_column"
        Me.GridColumnActOrderSales.Name = "GridColumnActOrderSales"
        Me.GridColumnActOrderSales.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "ACT ORDER SALES_add_report_column", "{0:N0}")})
        Me.GridColumnActOrderSales.Visible = True
        Me.GridColumnActOrderSales.VisibleIndex = 16
        Me.GridColumnActOrderSales.Width = 69
        '
        'GridColumnTotalQty
        '
        Me.GridColumnTotalQty.AppearanceHeader.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.GridColumnTotalQty.AppearanceHeader.Options.UseFont = True
        Me.GridColumnTotalQty.Caption = "TOTAL QTY"
        Me.GridColumnTotalQty.DisplayFormat.FormatString = "N0"
        Me.GridColumnTotalQty.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumnTotalQty.FieldName = "TOTAL QTY_add_report_column"
        Me.GridColumnTotalQty.Name = "GridColumnTotalQty"
        Me.GridColumnTotalQty.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "TOTAL QTY_add_report_column", "{0:N0}")})
        Me.GridColumnTotalQty.Visible = True
        Me.GridColumnTotalQty.VisibleIndex = 17
        Me.GridColumnTotalQty.Width = 63
        '
        'GridColumnCostEstimate
        '
        Me.GridColumnCostEstimate.AppearanceHeader.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.GridColumnCostEstimate.AppearanceHeader.Options.UseFont = True
        Me.GridColumnCostEstimate.Caption = "COST ESTIMATE"
        Me.GridColumnCostEstimate.DisplayFormat.FormatString = "N2"
        Me.GridColumnCostEstimate.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumnCostEstimate.FieldName = "COST_add_report_column"
        Me.GridColumnCostEstimate.Name = "GridColumnCostEstimate"
        Me.GridColumnCostEstimate.Visible = True
        Me.GridColumnCostEstimate.VisibleIndex = 20
        '
        'GridColumnAdditionalCost
        '
        Me.GridColumnAdditionalCost.AppearanceHeader.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.GridColumnAdditionalCost.AppearanceHeader.Options.UseFont = True
        Me.GridColumnAdditionalCost.Caption = "ADDITIIONAL COST"
        Me.GridColumnAdditionalCost.DisplayFormat.FormatString = "N2"
        Me.GridColumnAdditionalCost.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumnAdditionalCost.FieldName = "ADDITIONAL COST_add_report_column"
        Me.GridColumnAdditionalCost.Name = "GridColumnAdditionalCost"
        Me.GridColumnAdditionalCost.Visible = True
        Me.GridColumnAdditionalCost.VisibleIndex = 18
        Me.GridColumnAdditionalCost.Width = 85
        '
        'GridColumnCostEstimateNonAddition
        '
        Me.GridColumnCostEstimateNonAddition.AppearanceHeader.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.GridColumnCostEstimateNonAddition.AppearanceHeader.Options.UseFont = True
        Me.GridColumnCostEstimateNonAddition.Caption = "COST ESTIMATE (MIN ADDITIONAL)"
        Me.GridColumnCostEstimateNonAddition.DisplayFormat.FormatString = "N2"
        Me.GridColumnCostEstimateNonAddition.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumnCostEstimateNonAddition.FieldName = "COST NON ADDITIONAL_add_report_column"
        Me.GridColumnCostEstimateNonAddition.Name = "GridColumnCostEstimateNonAddition"
        Me.GridColumnCostEstimateNonAddition.Visible = True
        Me.GridColumnCostEstimateNonAddition.VisibleIndex = 19
        '
        'GridColumnRateCurrent
        '
        Me.GridColumnRateCurrent.AppearanceHeader.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.GridColumnRateCurrent.AppearanceHeader.Options.UseFont = True
        Me.GridColumnRateCurrent.Caption = "RATE CURRENT"
        Me.GridColumnRateCurrent.DisplayFormat.FormatString = "N0"
        Me.GridColumnRateCurrent.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumnRateCurrent.FieldName = "RATE CURRENT_add_report_column"
        Me.GridColumnRateCurrent.Name = "GridColumnRateCurrent"
        '
        'GridColumnPriceEstimate
        '
        Me.GridColumnPriceEstimate.AppearanceHeader.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.GridColumnPriceEstimate.AppearanceHeader.Options.UseFont = True
        Me.GridColumnPriceEstimate.Caption = "PRICE ESTIMATE"
        Me.GridColumnPriceEstimate.DisplayFormat.FormatString = "N0"
        Me.GridColumnPriceEstimate.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumnPriceEstimate.FieldName = "PROPOSE PRICE_add_report_column"
        Me.GridColumnPriceEstimate.Name = "GridColumnPriceEstimate"
        Me.GridColumnPriceEstimate.Visible = True
        Me.GridColumnPriceEstimate.VisibleIndex = 23
        '
        'GridColumnAdditionalPrice
        '
        Me.GridColumnAdditionalPrice.AppearanceHeader.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.GridColumnAdditionalPrice.AppearanceHeader.Options.UseFont = True
        Me.GridColumnAdditionalPrice.Caption = "ADDITIONAL PRICE"
        Me.GridColumnAdditionalPrice.DisplayFormat.FormatString = "N0"
        Me.GridColumnAdditionalPrice.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumnAdditionalPrice.FieldName = "ADDITIONAL PRICE_add_report_column"
        Me.GridColumnAdditionalPrice.Name = "GridColumnAdditionalPrice"
        Me.GridColumnAdditionalPrice.Visible = True
        Me.GridColumnAdditionalPrice.VisibleIndex = 21
        '
        'GridColumnPriceEstimateMinAdditional
        '
        Me.GridColumnPriceEstimateMinAdditional.AppearanceHeader.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.GridColumnPriceEstimateMinAdditional.AppearanceHeader.Options.UseFont = True
        Me.GridColumnPriceEstimateMinAdditional.Caption = "PRICE ESTIMATE (MIN ADDITIONAL)"
        Me.GridColumnPriceEstimateMinAdditional.DisplayFormat.FormatString = "N0"
        Me.GridColumnPriceEstimateMinAdditional.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumnPriceEstimateMinAdditional.FieldName = "PROPOSE PRICE NON ADDITIONAL_add_report_column"
        Me.GridColumnPriceEstimateMinAdditional.Name = "GridColumnPriceEstimateMinAdditional"
        Me.GridColumnPriceEstimateMinAdditional.Visible = True
        Me.GridColumnPriceEstimateMinAdditional.VisibleIndex = 22
        '
        'GridColumnMarkup
        '
        Me.GridColumnMarkup.AppearanceHeader.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.GridColumnMarkup.AppearanceHeader.Options.UseFont = True
        Me.GridColumnMarkup.Caption = "MARKUP"
        Me.GridColumnMarkup.DisplayFormat.FormatString = "N2"
        Me.GridColumnMarkup.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumnMarkup.FieldName = "MARK UP_add_report_column"
        Me.GridColumnMarkup.Name = "GridColumnMarkup"
        Me.GridColumnMarkup.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Custom, "MARK UP_add_report_column", "{0:N2}", 46)})
        Me.GridColumnMarkup.Visible = True
        Me.GridColumnMarkup.VisibleIndex = 24
        '
        'GridColumnTotalCostNonAdditional
        '
        Me.GridColumnTotalCostNonAdditional.AppearanceHeader.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.GridColumnTotalCostNonAdditional.AppearanceHeader.Options.UseFont = True
        Me.GridColumnTotalCostNonAdditional.Caption = "TOTAL COST (MIN ADDITIONAL)"
        Me.GridColumnTotalCostNonAdditional.DisplayFormat.FormatString = "N2"
        Me.GridColumnTotalCostNonAdditional.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumnTotalCostNonAdditional.FieldName = "TOTAL COST NON ADDITIONAL_add_report_column"
        Me.GridColumnTotalCostNonAdditional.Name = "GridColumnTotalCostNonAdditional"
        Me.GridColumnTotalCostNonAdditional.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "TOTAL COST NON ADDITIONAL_add_report_column", "{0:N2}")})
        Me.GridColumnTotalCostNonAdditional.Visible = True
        Me.GridColumnTotalCostNonAdditional.VisibleIndex = 25
        Me.GridColumnTotalCostNonAdditional.Width = 87
        '
        'GridColumnTOtalAmounNonAdditional
        '
        Me.GridColumnTOtalAmounNonAdditional.AppearanceHeader.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.GridColumnTOtalAmounNonAdditional.AppearanceHeader.Options.UseFont = True
        Me.GridColumnTOtalAmounNonAdditional.Caption = "TOTAL AMOUNT (MIN ADDITIONAL)"
        Me.GridColumnTOtalAmounNonAdditional.DisplayFormat.FormatString = "N2"
        Me.GridColumnTOtalAmounNonAdditional.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumnTOtalAmounNonAdditional.FieldName = "TOTAL AMOUNT NON ADDITIONAL_add_report_column"
        Me.GridColumnTOtalAmounNonAdditional.Name = "GridColumnTOtalAmounNonAdditional"
        Me.GridColumnTOtalAmounNonAdditional.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "TOTAL AMOUNT NON ADDITIONAL_add_report_column", "{0:N2}")})
        Me.GridColumnTOtalAmounNonAdditional.Visible = True
        Me.GridColumnTOtalAmounNonAdditional.VisibleIndex = 26
        Me.GridColumnTOtalAmounNonAdditional.Width = 86
        '
        'GridColumnTotalCost
        '
        Me.GridColumnTotalCost.AppearanceHeader.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.GridColumnTotalCost.AppearanceHeader.Options.UseFont = True
        Me.GridColumnTotalCost.Caption = "TOTAL COST"
        Me.GridColumnTotalCost.DisplayFormat.FormatString = "N2"
        Me.GridColumnTotalCost.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumnTotalCost.FieldName = "TOTAL COST_add_report_column"
        Me.GridColumnTotalCost.Name = "GridColumnTotalCost"
        Me.GridColumnTotalCost.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "TOTAL COST_add_report_column", "{0:N2}")})
        Me.GridColumnTotalCost.Visible = True
        Me.GridColumnTotalCost.VisibleIndex = 27
        '
        'GridColumnTotalAmount
        '
        Me.GridColumnTotalAmount.AppearanceHeader.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.GridColumnTotalAmount.AppearanceHeader.Options.UseFont = True
        Me.GridColumnTotalAmount.Caption = "TOTAL AMOUNT"
        Me.GridColumnTotalAmount.DisplayFormat.FormatString = "N2"
        Me.GridColumnTotalAmount.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumnTotalAmount.FieldName = "TOTAL AMOUNT_add_report_column"
        Me.GridColumnTotalAmount.Name = "GridColumnTotalAmount"
        Me.GridColumnTotalAmount.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "TOTAL AMOUNT_add_report_column", "{0:N2}")})
        Me.GridColumnTotalAmount.Visible = True
        Me.GridColumnTotalAmount.VisibleIndex = 28
        '
        'GridColumnFabrication
        '
        Me.GridColumnFabrication.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumnFabrication.AppearanceCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
        Me.GridColumnFabrication.AppearanceHeader.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.GridColumnFabrication.AppearanceHeader.Options.UseFont = True
        Me.GridColumnFabrication.Caption = "FABRICATION"
        Me.GridColumnFabrication.FieldName = "FABRICATION_desc_report_column"
        Me.GridColumnFabrication.Name = "GridColumnFabrication"
        Me.GridColumnFabrication.Visible = True
        Me.GridColumnFabrication.VisibleIndex = 11
        Me.GridColumnFabrication.Width = 94
        '
        'GridColumnMoveDrop
        '
        Me.GridColumnMoveDrop.AppearanceHeader.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.GridColumnMoveDrop.AppearanceHeader.Options.UseFont = True
        Me.GridColumnMoveDrop.Caption = "MOVE/DROP"
        Me.GridColumnMoveDrop.FieldName = "MOVE/DROP_desc_report_column"
        Me.GridColumnMoveDrop.Name = "GridColumnMoveDrop"
        Me.GridColumnMoveDrop.Visible = True
        Me.GridColumnMoveDrop.VisibleIndex = 12
        Me.GridColumnMoveDrop.Width = 93
        '
        'GridColumnSTATUS
        '
        Me.GridColumnSTATUS.Caption = "STATUS"
        Me.GridColumnSTATUS.FieldName = "STATUS_add_report_column`"
        Me.GridColumnSTATUS.Name = "GridColumnSTATUS"
        '
        'GridColumnQty1
        '
        Me.GridColumnQty1.AppearanceHeader.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.GridColumnQty1.AppearanceHeader.Options.UseFont = True
        Me.GridColumnQty1.Caption = "Q1"
        Me.GridColumnQty1.DisplayFormat.FormatString = "N0"
        Me.GridColumnQty1.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumnQty1.FieldName = "qty1"
        Me.GridColumnQty1.Name = "GridColumnQty1"
        Me.GridColumnQty1.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "qty1", "{0:N0}")})
        Me.GridColumnQty1.Width = 40
        '
        'GridColumnQty2
        '
        Me.GridColumnQty2.AppearanceHeader.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.GridColumnQty2.AppearanceHeader.Options.UseFont = True
        Me.GridColumnQty2.Caption = "Q2"
        Me.GridColumnQty2.DisplayFormat.FormatString = "N0"
        Me.GridColumnQty2.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumnQty2.FieldName = "qty2"
        Me.GridColumnQty2.Name = "GridColumnQty2"
        Me.GridColumnQty2.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "qty2", "{0:N0}")})
        Me.GridColumnQty2.Width = 40
        '
        'GridColumnQty3
        '
        Me.GridColumnQty3.AppearanceHeader.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.GridColumnQty3.AppearanceHeader.Options.UseFont = True
        Me.GridColumnQty3.Caption = "Q3"
        Me.GridColumnQty3.DisplayFormat.FormatString = "N0"
        Me.GridColumnQty3.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumnQty3.FieldName = "qty3"
        Me.GridColumnQty3.Name = "GridColumnQty3"
        Me.GridColumnQty3.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "qty3", "{0:N0}")})
        Me.GridColumnQty3.Width = 40
        '
        'GridColumnQty4
        '
        Me.GridColumnQty4.AppearanceHeader.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.GridColumnQty4.AppearanceHeader.Options.UseFont = True
        Me.GridColumnQty4.Caption = "Q4"
        Me.GridColumnQty4.DisplayFormat.FormatString = "N0"
        Me.GridColumnQty4.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumnQty4.FieldName = "qty4"
        Me.GridColumnQty4.Name = "GridColumnQty4"
        Me.GridColumnQty4.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "qty4", "{0:N0}")})
        Me.GridColumnQty4.Width = 40
        '
        'GridColumnQty5
        '
        Me.GridColumnQty5.AppearanceHeader.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.GridColumnQty5.AppearanceHeader.Options.UseFont = True
        Me.GridColumnQty5.Caption = "Q5"
        Me.GridColumnQty5.DisplayFormat.FormatString = "N0"
        Me.GridColumnQty5.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumnQty5.FieldName = "qty5"
        Me.GridColumnQty5.Name = "GridColumnQty5"
        Me.GridColumnQty5.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "qty5", "{0:N0}")})
        Me.GridColumnQty5.Width = 40
        '
        'GridColumnQty6
        '
        Me.GridColumnQty6.AppearanceHeader.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.GridColumnQty6.AppearanceHeader.Options.UseFont = True
        Me.GridColumnQty6.Caption = "Q6"
        Me.GridColumnQty6.DisplayFormat.FormatString = "N0"
        Me.GridColumnQty6.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumnQty6.FieldName = "qty6"
        Me.GridColumnQty6.Name = "GridColumnQty6"
        Me.GridColumnQty6.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "qty6", "{0:N0}")})
        Me.GridColumnQty6.Width = 40
        '
        'GridColumnQty7
        '
        Me.GridColumnQty7.AppearanceHeader.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.GridColumnQty7.AppearanceHeader.Options.UseFont = True
        Me.GridColumnQty7.Caption = "Q7"
        Me.GridColumnQty7.DisplayFormat.FormatString = "N0"
        Me.GridColumnQty7.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumnQty7.FieldName = "qty7"
        Me.GridColumnQty7.Name = "GridColumnQty7"
        Me.GridColumnQty7.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "qty7", "{0:N0}")})
        Me.GridColumnQty7.Width = 40
        '
        'GridColumnQty8
        '
        Me.GridColumnQty8.AppearanceHeader.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.GridColumnQty8.AppearanceHeader.Options.UseFont = True
        Me.GridColumnQty8.Caption = "Q8"
        Me.GridColumnQty8.DisplayFormat.FormatString = "N0"
        Me.GridColumnQty8.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumnQty8.FieldName = "qty8"
        Me.GridColumnQty8.Name = "GridColumnQty8"
        Me.GridColumnQty8.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "qty8", "{0:N0}")})
        Me.GridColumnQty8.Width = 40
        '
        'GridColumnQty9
        '
        Me.GridColumnQty9.AppearanceHeader.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.GridColumnQty9.AppearanceHeader.Options.UseFont = True
        Me.GridColumnQty9.Caption = "Q9"
        Me.GridColumnQty9.DisplayFormat.FormatString = "N0"
        Me.GridColumnQty9.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumnQty9.FieldName = "qty9"
        Me.GridColumnQty9.Name = "GridColumnQty9"
        Me.GridColumnQty9.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "qty9", "{0:N0}")})
        Me.GridColumnQty9.Width = 40
        '
        'GridColumnQty10
        '
        Me.GridColumnQty10.AppearanceHeader.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.GridColumnQty10.AppearanceHeader.Options.UseFont = True
        Me.GridColumnQty10.Caption = "Q10"
        Me.GridColumnQty10.DisplayFormat.FormatString = "N0"
        Me.GridColumnQty10.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumnQty10.FieldName = "qty10"
        Me.GridColumnQty10.Name = "GridColumnQty10"
        Me.GridColumnQty10.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "qty10", "{0:N0}")})
        Me.GridColumnQty10.Width = 40
        '
        'PanelControlCompleted
        '
        Me.PanelControlCompleted.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
        Me.PanelControlCompleted.Controls.Add(Me.PanelControlCENONActive)
        Me.PanelControlCompleted.Controls.Add(Me.PanelControlBreakSize)
        Me.PanelControlCompleted.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PanelControlCompleted.Location = New System.Drawing.Point(20, 221)
        Me.PanelControlCompleted.Name = "PanelControlCompleted"
        Me.PanelControlCompleted.Size = New System.Drawing.Size(936, 32)
        Me.PanelControlCompleted.TabIndex = 41
        Me.PanelControlCompleted.Visible = False
        '
        'PanelControlCENONActive
        '
        Me.PanelControlCENONActive.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
        Me.PanelControlCENONActive.Controls.Add(Me.CheckEditShowNonActive)
        Me.PanelControlCENONActive.Dock = System.Windows.Forms.DockStyle.Left
        Me.PanelControlCENONActive.Location = New System.Drawing.Point(131, 0)
        Me.PanelControlCENONActive.Name = "PanelControlCENONActive"
        Me.PanelControlCENONActive.Size = New System.Drawing.Size(144, 32)
        Me.PanelControlCENONActive.TabIndex = 165
        Me.PanelControlCENONActive.Visible = False
        '
        'CheckEditShowNonActive
        '
        Me.CheckEditShowNonActive.Location = New System.Drawing.Point(4, 6)
        Me.CheckEditShowNonActive.Name = "CheckEditShowNonActive"
        Me.CheckEditShowNonActive.Properties.Caption = "show non active status"
        Me.CheckEditShowNonActive.Size = New System.Drawing.Size(132, 19)
        Me.CheckEditShowNonActive.TabIndex = 164
        '
        'PanelControlBreakSize
        '
        Me.PanelControlBreakSize.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
        Me.PanelControlBreakSize.Controls.Add(Me.CEBreakSize)
        Me.PanelControlBreakSize.Dock = System.Windows.Forms.DockStyle.Left
        Me.PanelControlBreakSize.Location = New System.Drawing.Point(0, 0)
        Me.PanelControlBreakSize.Name = "PanelControlBreakSize"
        Me.PanelControlBreakSize.Size = New System.Drawing.Size(131, 32)
        Me.PanelControlBreakSize.TabIndex = 166
        '
        'CEBreakSize
        '
        Me.CEBreakSize.Location = New System.Drawing.Point(6, 6)
        Me.CEBreakSize.Name = "CEBreakSize"
        Me.CEBreakSize.Properties.Caption = "show breakdown size"
        Me.CEBreakSize.Size = New System.Drawing.Size(123, 19)
        Me.CEBreakSize.TabIndex = 0
        '
        'PanelControlNav
        '
        Me.PanelControlNav.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
        Me.PanelControlNav.Controls.Add(Me.BBom)
        Me.PanelControlNav.Controls.Add(Me.BtnDelete)
        Me.PanelControlNav.Controls.Add(Me.BtnAddFromLineList)
        Me.PanelControlNav.Controls.Add(Me.BtnEdit)
        Me.PanelControlNav.Controls.Add(Me.BtnAdd)
        Me.PanelControlNav.Dock = System.Windows.Forms.DockStyle.Top
        Me.PanelControlNav.Location = New System.Drawing.Point(20, 2)
        Me.PanelControlNav.Name = "PanelControlNav"
        Me.PanelControlNav.Size = New System.Drawing.Size(936, 35)
        Me.PanelControlNav.TabIndex = 17
        '
        'BtnAddFromLineList
        '
        Me.BtnAddFromLineList.Dock = System.Windows.Forms.DockStyle.Right
        Me.BtnAddFromLineList.ImageIndex = 0
        Me.BtnAddFromLineList.ImageList = Me.LargeImageCollection
        Me.BtnAddFromLineList.Location = New System.Drawing.Point(638, 0)
        Me.BtnAddFromLineList.Name = "BtnAddFromLineList"
        Me.BtnAddFromLineList.Size = New System.Drawing.Size(123, 35)
        Me.BtnAddFromLineList.TabIndex = 7
        Me.BtnAddFromLineList.Text = "Add from Line List"
        Me.BtnAddFromLineList.Visible = False
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ViewBreakdownSizeToolStripMenuItem})
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(183, 26)
        '
        'ViewBreakdownSizeToolStripMenuItem
        '
        Me.ViewBreakdownSizeToolStripMenuItem.Name = "ViewBreakdownSizeToolStripMenuItem"
        Me.ViewBreakdownSizeToolStripMenuItem.Size = New System.Drawing.Size(182, 22)
        Me.ViewBreakdownSizeToolStripMenuItem.Text = "view breakdown size"
        '
        'GridView1
        '
        Me.GridView1.Name = "GridView1"
        '
        'GridBand1
        '
        Me.GridBand1.Caption = "GridBand1"
        Me.GridBand1.Name = "GridBand1"
        Me.GridBand1.VisibleIndex = -1
        '
        'XTCPD
        '
        Me.XTCPD.Dock = System.Windows.Forms.DockStyle.Fill
        Me.XTCPD.Location = New System.Drawing.Point(0, 176)
        Me.XTCPD.Name = "XTCPD"
        Me.XTCPD.SelectedTabPage = Me.XTPDetail
        Me.XTCPD.Size = New System.Drawing.Size(964, 283)
        Me.XTCPD.TabIndex = 189
        Me.XTCPD.TabPages.AddRange(New DevExpress.XtraTab.XtraTabPage() {Me.XTPDetail, Me.XTPRevision})
        '
        'XTPDetail
        '
        Me.XTPDetail.Controls.Add(Me.GroupControlList)
        Me.XTPDetail.Name = "XTPDetail"
        Me.XTPDetail.Size = New System.Drawing.Size(958, 255)
        Me.XTPDetail.Text = "Detail"
        '
        'XTPRevision
        '
        Me.XTPRevision.Controls.Add(Me.GCData)
        Me.XTPRevision.Name = "XTPRevision"
        Me.XTPRevision.PageVisible = False
        Me.XTPRevision.Size = New System.Drawing.Size(958, 255)
        Me.XTPRevision.Text = "Revision"
        '
        'GCData
        '
        Me.GCData.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCData.Location = New System.Drawing.Point(0, 0)
        Me.GCData.MainView = Me.GVData
        Me.GCData.Name = "GCData"
        Me.GCData.Size = New System.Drawing.Size(958, 255)
        Me.GCData.TabIndex = 1
        Me.GCData.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVData})
        '
        'GVData
        '
        Me.GVData.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumnIdProdDemandRev, Me.GridColumnIdPD, Me.GridColumnRevCount, Me.GridColumnPDNumber, Me.GridColumnSTT, Me.GridColumnDate})
        Me.GVData.GridControl = Me.GCData
        Me.GVData.Name = "GVData"
        Me.GVData.OptionsBehavior.AutoExpandAllGroups = True
        Me.GVData.OptionsBehavior.Editable = False
        Me.GVData.OptionsView.ShowGroupPanel = False
        '
        'GridColumnIdProdDemandRev
        '
        Me.GridColumnIdProdDemandRev.Caption = "Id"
        Me.GridColumnIdProdDemandRev.FieldName = "id_prod_demand_rev"
        Me.GridColumnIdProdDemandRev.Name = "GridColumnIdProdDemandRev"
        '
        'GridColumnIdPD
        '
        Me.GridColumnIdPD.Caption = "ID PD"
        Me.GridColumnIdPD.FieldName = "id_prod_demand"
        Me.GridColumnIdPD.Name = "GridColumnIdPD"
        '
        'GridColumnRevCount
        '
        Me.GridColumnRevCount.Caption = "Revision No."
        Me.GridColumnRevCount.FieldName = "rev_count"
        Me.GridColumnRevCount.Name = "GridColumnRevCount"
        Me.GridColumnRevCount.Visible = True
        Me.GridColumnRevCount.VisibleIndex = 1
        Me.GridColumnRevCount.Width = 157
        '
        'GridColumnPDNumber
        '
        Me.GridColumnPDNumber.Caption = "PD Number"
        Me.GridColumnPDNumber.FieldName = "prod_demand_number"
        Me.GridColumnPDNumber.Name = "GridColumnPDNumber"
        Me.GridColumnPDNumber.Visible = True
        Me.GridColumnPDNumber.VisibleIndex = 0
        Me.GridColumnPDNumber.Width = 514
        '
        'GridColumnSTT
        '
        Me.GridColumnSTT.Caption = "Status"
        Me.GridColumnSTT.FieldName = "report_status"
        Me.GridColumnSTT.Name = "GridColumnSTT"
        Me.GridColumnSTT.Visible = True
        Me.GridColumnSTT.VisibleIndex = 3
        Me.GridColumnSTT.Width = 600
        '
        'GridColumnDate
        '
        Me.GridColumnDate.Caption = "Created Date"
        Me.GridColumnDate.DisplayFormat.FormatString = "dd MMMM yyyy \/ HH:mm"
        Me.GridColumnDate.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.GridColumnDate.FieldName = "created_date"
        Me.GridColumnDate.Name = "GridColumnDate"
        Me.GridColumnDate.Visible = True
        Me.GridColumnDate.VisibleIndex = 2
        Me.GridColumnDate.Width = 345
        '
        'FormProdDemandSingle
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(964, 605)
        Me.Controls.Add(Me.XTCPD)
        Me.Controls.Add(Me.GroupControl3)
        Me.Controls.Add(Me.GroupGeneralHeader)
        Me.Controls.Add(Me.PCGeneralSave)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.LookAndFeel.SkinName = "iMaginary"
        Me.MinimizeBox = False
        Me.Name = "FormProdDemandSingle"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Production Demand"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.EPProdDemand, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LESampleDivision.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ButtonEdit1.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LEPDType.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.MENote.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SLESeason.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SearchLookUpEdit1View, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtProdDemandNumber.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PCGeneralSave, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PCGeneralSave.ResumeLayout(False)
        CType(Me.LargeImageCollection, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GroupGeneralHeader, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupGeneralHeader.ResumeLayout(False)
        Me.GroupGeneralHeader.PerformLayout()
        CType(Me.TxtRateCurrent.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LEBudget.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SLEKind.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LECat.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl1.ResumeLayout(False)
        Me.PanelControl1.PerformLayout()
        CType(Me.DEForm.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DEForm.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GroupControl3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupControl3.ResumeLayout(False)
        Me.GroupControl3.PerformLayout()
        CType(Me.LEReportStatus.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GroupControlList, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupControlList.ResumeLayout(False)
        CType(Me.GCDesign, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVDesign, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PanelControlCompleted, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControlCompleted.ResumeLayout(False)
        CType(Me.PanelControlCENONActive, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControlCENONActive.ResumeLayout(False)
        CType(Me.CheckEditShowNonActive.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PanelControlBreakSize, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControlBreakSize.ResumeLayout(False)
        CType(Me.CEBreakSize.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PanelControlNav, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControlNav.ResumeLayout(False)
        Me.ContextMenuStrip1.ResumeLayout(False)
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.XTCPD, System.ComponentModel.ISupportInitialize).EndInit()
        Me.XTCPD.ResumeLayout(False)
        Me.XTPDetail.ResumeLayout(False)
        Me.XTPRevision.ResumeLayout(False)
        CType(Me.GCData, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVData, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents EPProdDemand As System.Windows.Forms.ErrorProvider
    Friend WithEvents SLESeason As DevExpress.XtraEditors.SearchLookUpEdit
    Friend WithEvents SearchLookUpEdit1View As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumnIdSeason As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnRange As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnSeason As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents LabelSeason As DevExpress.XtraEditors.LabelControl
    Friend WithEvents TxtProdDemandNumber As DevExpress.XtraEditors.TextEdit
    Friend WithEvents PCGeneralSave As DevExpress.XtraEditors.PanelControl
    Friend WithEvents BtnCancel As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BtnSave As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BBom As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BtnAdd As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BtnEdit As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BtnDelete As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents MENote As DevExpress.XtraEditors.MemoEdit
    Friend WithEvents LabelControl1 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LEPDType As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents LabelControl3 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents ButtonEdit1 As DevExpress.XtraEditors.ButtonEdit
    Friend WithEvents BtnDelRef As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents LabelControl4 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LESampleDivision As DevExpress.XtraEditors.LookUpEdit
    Public WithEvents LargeImageCollection As DevExpress.Utils.ImageCollection
    Friend WithEvents GroupGeneralHeader As DevExpress.XtraEditors.GroupControl
    Friend WithEvents LabelControl11 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl12 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents GroupControl3 As DevExpress.XtraEditors.GroupControl
    Friend WithEvents LabelControl21 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LEReportStatus As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents LabelControl18 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents GroupControlList As DevExpress.XtraEditors.GroupControl
    Friend WithEvents PanelControlNav As DevExpress.XtraEditors.PanelControl
    Friend WithEvents GridView1 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents BMark As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BtnAttachment As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BtnPrint As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents DEForm As DevExpress.XtraEditors.DateEdit
    Friend WithEvents PanelControl1 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents BtnAddFromLineList As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents GridBand1 As DevExpress.XtraGrid.Views.BandedGrid.GridBand
    Friend WithEvents LabelCategory As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LECat As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents GridColumnDisplayName As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents SLEKind As DevExpress.XtraEditors.SearchLookUpEdit
    Friend WithEvents GridView2 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents LabelControl2 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents GridColumnIdKind As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnKind As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents PanelControlCompleted As DevExpress.XtraEditors.PanelControl
    Friend WithEvents CheckEditShowNonActive As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents XTCPD As DevExpress.XtraTab.XtraTabControl
    Friend WithEvents XTPDetail As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents XTPRevision As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents GCData As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVData As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumnIdProdDemandRev As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnIdPD As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnRevCount As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnPDNumber As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnSTT As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnDate As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ContextMenuStrip1 As ContextMenuStrip
    Friend WithEvents ViewBreakdownSizeToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents LabelControl5 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LEBudget As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents BtnCancellPropose As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents PanelControlCENONActive As DevExpress.XtraEditors.PanelControl
    Friend WithEvents PanelControlBreakSize As DevExpress.XtraEditors.PanelControl
    Friend WithEvents CEBreakSize As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents BtnConfirm As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents GCDesign As MyXtraGrid.MyGridControl
    Friend WithEvents GVDesign As MyXtraGrid.MyGridView
    Friend WithEvents GridColumnNo As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnCodeImport As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnCode As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnDel As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnSeasonOrigin As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnStyleCountry As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnProductOrigin As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnClass As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnDescription As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnColor As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnSizeChart As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnMKT As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnBuff As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnCore As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnActOrderSales As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnTotalQty As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnCostEstimate As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnAdditionalCost As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnCostEstimateNonAddition As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnRateCurrent As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnPriceEstimate As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnAdditionalPrice As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnPriceEstimateMinAdditional As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnMarkup As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnTotalCostNonAdditional As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnTOtalAmounNonAdditional As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnTotalCost As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnTotalAmount As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnFabrication As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnMoveDrop As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnSTATUS As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnQty1 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnQty2 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnQty3 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnQty4 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnQty5 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnQty6 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnQty7 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnQty8 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnQty9 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnQty10 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents TxtRateCurrent As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl6 As DevExpress.XtraEditors.LabelControl
End Class
