<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormMatPurchase
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormMatPurchase))
        Me.XTCPurcMat = New DevExpress.XtraTab.XtraTabControl()
        Me.XTPPurchaseMat = New DevExpress.XtraTab.XtraTabPage()
        Me.GCMatPurchase = New DevExpress.XtraGrid.GridControl()
        Me.GVMatPurchase = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.ColIdMatPurchase = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn2 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RICECheck = New DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit()
        Me.ColSeason = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.ColDelivery = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.ColPONumber = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.ColShipFrom = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.ColShipTo = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.ColSamplePurcDate = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.ColRecDate = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.ColDueDate = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.ColPayment = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.ColStatus = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.ColIDStatus = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.ColIdDelivery = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.ColIdSeason = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn5 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn1 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.PCFilterDate = New DevExpress.XtraEditors.PanelControl()
        Me.PCSelAll = New DevExpress.XtraEditors.PanelControl()
        Me.CheckEditSelAll = New DevExpress.XtraEditors.CheckEdit()
        Me.BClearFilter = New DevExpress.XtraEditors.SimpleButton()
        Me.BPrint = New DevExpress.XtraEditors.SimpleButton()
        Me.BFilter = New DevExpress.XtraEditors.SimpleButton()
        Me.LabelControl6 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl11 = New DevExpress.XtraEditors.LabelControl()
        Me.DEEnd = New DevExpress.XtraEditors.DateEdit()
        Me.DEStart = New DevExpress.XtraEditors.DateEdit()
        Me.PanelControl2 = New DevExpress.XtraEditors.PanelControl()
        Me.BShowFilterPanel = New DevExpress.XtraEditors.SimpleButton()
        Me.BSearch = New DevExpress.XtraEditors.SimpleButton()
        Me.LabelControl12 = New DevExpress.XtraEditors.LabelControl()
        Me.LESeason = New DevExpress.XtraEditors.SearchLookUpEdit()
        Me.GridView2 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumn3 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn4 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.XTPProdDemand = New DevExpress.XtraTab.XtraTabPage()
        Me.XTCListPD = New DevExpress.XtraTab.XtraTabControl()
        Me.XTPList = New DevExpress.XtraTab.XtraTabPage()
        Me.GCListMatPD = New DevExpress.XtraGrid.GridControl()
        Me.ViewMenu = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.SMMasterMat = New System.Windows.Forms.ToolStripMenuItem()
        Me.GVListMatPD = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumn17 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RICEPD = New DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit()
        Me.GridColumn8 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn9 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn24 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn10 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn28 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn25 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn26 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn27 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn11 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn13 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn22 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn19 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn21 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn18 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn23 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn20 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn14 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.PanelControl1 = New DevExpress.XtraEditors.PanelControl()
        Me.BGenerateFromPD = New DevExpress.XtraEditors.SimpleButton()
        Me.LargeImageCollection = New DevExpress.Utils.ImageCollection(Me.components)
        Me.BView = New DevExpress.XtraEditors.SimpleButton()
        Me.LabelControl1 = New DevExpress.XtraEditors.LabelControl()
        Me.SLEMatDet = New DevExpress.XtraEditors.SearchLookUpEdit()
        Me.GridView3 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumn6 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn12 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn7 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn15 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn16 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.BCreatePO = New DevExpress.XtraEditors.SimpleButton()
        Me.XTPReport = New DevExpress.XtraTab.XtraTabPage()
        Me.GCPD = New DevExpress.XtraGrid.GridControl()
        Me.ViewMenuReport = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ViewPOToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.GVPD = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumn29 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn30 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn31 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn32 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn35 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn39 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn38 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn34 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn40 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn33 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RepositoryItemCheckEdit1 = New DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit()
        Me.PanelControl3 = New DevExpress.XtraEditors.PanelControl()
        Me.BSearchReport = New DevExpress.XtraEditors.SimpleButton()
        Me.LabelControl2 = New DevExpress.XtraEditors.LabelControl()
        Me.SLEReport = New DevExpress.XtraEditors.SearchLookUpEdit()
        Me.GridView4 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumn36 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn37 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.XTPOrderConfirmation = New DevExpress.XtraTab.XtraTabPage()
        Me.GCKO = New DevExpress.XtraGrid.GridControl()
        Me.GVKO = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumn49 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn50 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn59 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn60 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn61 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RepositoryItemProgressBar2 = New DevExpress.XtraEditors.Repository.RepositoryItemProgressBar()
        Me.PanelControl5 = New DevExpress.XtraEditors.PanelControl()
        Me.BEditKO = New DevExpress.XtraEditors.SimpleButton()
        Me.SLEVendorKO = New DevExpress.XtraEditors.SearchLookUpEdit()
        Me.GridView1 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumn46 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn47 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn48 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.BViewKO = New DevExpress.XtraEditors.SimpleButton()
        Me.LabelControl10 = New DevExpress.XtraEditors.LabelControl()
        CType(Me.XTCPurcMat, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.XTCPurcMat.SuspendLayout()
        Me.XTPPurchaseMat.SuspendLayout()
        CType(Me.GCMatPurchase, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVMatPurchase, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RICECheck, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PCFilterDate, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PCFilterDate.SuspendLayout()
        CType(Me.PCSelAll, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PCSelAll.SuspendLayout()
        CType(Me.CheckEditSelAll.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DEEnd.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DEEnd.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DEStart.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DEStart.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PanelControl2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl2.SuspendLayout()
        CType(Me.LESeason.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.XTPProdDemand.SuspendLayout()
        CType(Me.XTCListPD, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.XTCListPD.SuspendLayout()
        Me.XTPList.SuspendLayout()
        CType(Me.GCListMatPD, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ViewMenu.SuspendLayout()
        CType(Me.GVListMatPD, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RICEPD, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl1.SuspendLayout()
        CType(Me.LargeImageCollection, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SLEMatDet.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.XTPReport.SuspendLayout()
        CType(Me.GCPD, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ViewMenuReport.SuspendLayout()
        CType(Me.GVPD, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemCheckEdit1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PanelControl3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl3.SuspendLayout()
        CType(Me.SLEReport.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView4, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.XTPOrderConfirmation.SuspendLayout()
        CType(Me.GCKO, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVKO, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemProgressBar2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PanelControl5, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl5.SuspendLayout()
        CType(Me.SLEVendorKO.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'XTCPurcMat
        '
        Me.XTCPurcMat.Dock = System.Windows.Forms.DockStyle.Fill
        Me.XTCPurcMat.HeaderLocation = DevExpress.XtraTab.TabHeaderLocation.Bottom
        Me.XTCPurcMat.Location = New System.Drawing.Point(0, 0)
        Me.XTCPurcMat.Name = "XTCPurcMat"
        Me.XTCPurcMat.SelectedTabPage = Me.XTPPurchaseMat
        Me.XTCPurcMat.Size = New System.Drawing.Size(796, 375)
        Me.XTCPurcMat.TabIndex = 7
        Me.XTCPurcMat.TabPages.AddRange(New DevExpress.XtraTab.XtraTabPage() {Me.XTPPurchaseMat, Me.XTPProdDemand, Me.XTPOrderConfirmation})
        '
        'XTPPurchaseMat
        '
        Me.XTPPurchaseMat.Controls.Add(Me.GCMatPurchase)
        Me.XTPPurchaseMat.Controls.Add(Me.PCFilterDate)
        Me.XTPPurchaseMat.Controls.Add(Me.PanelControl2)
        Me.XTPPurchaseMat.Name = "XTPPurchaseMat"
        Me.XTPPurchaseMat.Size = New System.Drawing.Size(790, 347)
        Me.XTPPurchaseMat.Text = "List Purchase"
        '
        'GCMatPurchase
        '
        Me.GCMatPurchase.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCMatPurchase.Location = New System.Drawing.Point(0, 44)
        Me.GCMatPurchase.MainView = Me.GVMatPurchase
        Me.GCMatPurchase.Name = "GCMatPurchase"
        Me.GCMatPurchase.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.RICECheck})
        Me.GCMatPurchase.Size = New System.Drawing.Size(790, 265)
        Me.GCMatPurchase.TabIndex = 4
        Me.GCMatPurchase.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVMatPurchase})
        '
        'GVMatPurchase
        '
        Me.GVMatPurchase.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.ColIdMatPurchase, Me.GridColumn2, Me.ColSeason, Me.ColDelivery, Me.ColPONumber, Me.ColShipFrom, Me.ColShipTo, Me.ColSamplePurcDate, Me.ColRecDate, Me.ColDueDate, Me.ColPayment, Me.ColStatus, Me.ColIDStatus, Me.ColIdDelivery, Me.ColIdSeason, Me.GridColumn5, Me.GridColumn1})
        Me.GVMatPurchase.GridControl = Me.GCMatPurchase
        Me.GVMatPurchase.GroupCount = 2
        Me.GVMatPurchase.Name = "GVMatPurchase"
        Me.GVMatPurchase.OptionsFind.AlwaysVisible = True
        Me.GVMatPurchase.OptionsView.ShowGroupPanel = False
        Me.GVMatPurchase.SortInfo.AddRange(New DevExpress.XtraGrid.Columns.GridColumnSortInfo() {New DevExpress.XtraGrid.Columns.GridColumnSortInfo(Me.ColSeason, DevExpress.Data.ColumnSortOrder.Descending), New DevExpress.XtraGrid.Columns.GridColumnSortInfo(Me.ColDelivery, DevExpress.Data.ColumnSortOrder.Descending), New DevExpress.XtraGrid.Columns.GridColumnSortInfo(Me.ColIdMatPurchase, DevExpress.Data.ColumnSortOrder.Descending)})
        '
        'ColIdMatPurchase
        '
        Me.ColIdMatPurchase.Caption = "ID Sample Purchase"
        Me.ColIdMatPurchase.FieldName = "id_mat_purc"
        Me.ColIdMatPurchase.Name = "ColIdMatPurchase"
        Me.ColIdMatPurchase.OptionsColumn.AllowEdit = False
        '
        'GridColumn2
        '
        Me.GridColumn2.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumn2.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridColumn2.AppearanceHeader.Options.UseTextOptions = True
        Me.GridColumn2.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridColumn2.Caption = "*"
        Me.GridColumn2.ColumnEdit = Me.RICECheck
        Me.GridColumn2.FieldName = "is_check"
        Me.GridColumn2.Name = "GridColumn2"
        Me.GridColumn2.Visible = True
        Me.GridColumn2.VisibleIndex = 0
        Me.GridColumn2.Width = 62
        '
        'RICECheck
        '
        Me.RICECheck.AutoHeight = False
        Me.RICECheck.Name = "RICECheck"
        Me.RICECheck.ValueChecked = "yes"
        Me.RICECheck.ValueUnchecked = "no"
        '
        'ColSeason
        '
        Me.ColSeason.Caption = "Season"
        Me.ColSeason.FieldName = "season"
        Me.ColSeason.FieldNameSortGroup = "id_season"
        Me.ColSeason.Name = "ColSeason"
        Me.ColSeason.OptionsColumn.AllowEdit = False
        Me.ColSeason.Visible = True
        Me.ColSeason.VisibleIndex = 0
        '
        'ColDelivery
        '
        Me.ColDelivery.Caption = "Delivery"
        Me.ColDelivery.FieldName = "delivery"
        Me.ColDelivery.FieldNameSortGroup = "id_delivery"
        Me.ColDelivery.Name = "ColDelivery"
        Me.ColDelivery.OptionsColumn.AllowEdit = False
        Me.ColDelivery.Visible = True
        Me.ColDelivery.VisibleIndex = 0
        '
        'ColPONumber
        '
        Me.ColPONumber.Caption = "Number"
        Me.ColPONumber.FieldName = "mat_purc_number"
        Me.ColPONumber.Name = "ColPONumber"
        Me.ColPONumber.OptionsColumn.AllowEdit = False
        Me.ColPONumber.Visible = True
        Me.ColPONumber.VisibleIndex = 1
        Me.ColPONumber.Width = 220
        '
        'ColShipFrom
        '
        Me.ColShipFrom.Caption = "To"
        Me.ColShipFrom.FieldName = "comp_name_to"
        Me.ColShipFrom.Name = "ColShipFrom"
        Me.ColShipFrom.OptionsColumn.AllowEdit = False
        Me.ColShipFrom.Visible = True
        Me.ColShipFrom.VisibleIndex = 2
        Me.ColShipFrom.Width = 196
        '
        'ColShipTo
        '
        Me.ColShipTo.Caption = "Ship To"
        Me.ColShipTo.FieldName = "comp_name_ship_to"
        Me.ColShipTo.Name = "ColShipTo"
        Me.ColShipTo.OptionsColumn.AllowEdit = False
        Me.ColShipTo.Visible = True
        Me.ColShipTo.VisibleIndex = 3
        Me.ColShipTo.Width = 196
        '
        'ColSamplePurcDate
        '
        Me.ColSamplePurcDate.Caption = "Create Date"
        Me.ColSamplePurcDate.DisplayFormat.FormatString = "dd MMM yyyy"
        Me.ColSamplePurcDate.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.ColSamplePurcDate.FieldName = "mat_purc_date"
        Me.ColSamplePurcDate.Name = "ColSamplePurcDate"
        Me.ColSamplePurcDate.OptionsColumn.AllowEdit = False
        Me.ColSamplePurcDate.Visible = True
        Me.ColSamplePurcDate.VisibleIndex = 5
        Me.ColSamplePurcDate.Width = 181
        '
        'ColRecDate
        '
        Me.ColRecDate.Caption = "Est. Receive Date"
        Me.ColRecDate.DisplayFormat.FormatString = "dd MMM yyyy"
        Me.ColRecDate.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.ColRecDate.FieldName = "mat_purc_lead_time"
        Me.ColRecDate.Name = "ColRecDate"
        Me.ColRecDate.OptionsColumn.AllowEdit = False
        Me.ColRecDate.Visible = True
        Me.ColRecDate.VisibleIndex = 6
        Me.ColRecDate.Width = 181
        '
        'ColDueDate
        '
        Me.ColDueDate.Caption = "Due Date"
        Me.ColDueDate.DisplayFormat.FormatString = "dd MMM yyyy"
        Me.ColDueDate.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.ColDueDate.FieldName = "mat_purc_top"
        Me.ColDueDate.Name = "ColDueDate"
        Me.ColDueDate.OptionsColumn.AllowEdit = False
        Me.ColDueDate.Visible = True
        Me.ColDueDate.VisibleIndex = 7
        Me.ColDueDate.Width = 199
        '
        'ColPayment
        '
        Me.ColPayment.Caption = "Payment"
        Me.ColPayment.FieldName = "payment"
        Me.ColPayment.Name = "ColPayment"
        Me.ColPayment.OptionsColumn.AllowEdit = False
        Me.ColPayment.Visible = True
        Me.ColPayment.VisibleIndex = 4
        Me.ColPayment.Width = 137
        '
        'ColStatus
        '
        Me.ColStatus.Caption = "Status"
        Me.ColStatus.FieldName = "report_status"
        Me.ColStatus.Name = "ColStatus"
        Me.ColStatus.OptionsColumn.AllowEdit = False
        Me.ColStatus.Visible = True
        Me.ColStatus.VisibleIndex = 8
        Me.ColStatus.Width = 114
        '
        'ColIDStatus
        '
        Me.ColIDStatus.Caption = "ID Status"
        Me.ColIDStatus.FieldName = "id_report_status"
        Me.ColIDStatus.Name = "ColIDStatus"
        Me.ColIDStatus.OptionsColumn.AllowEdit = False
        '
        'ColIdDelivery
        '
        Me.ColIdDelivery.Caption = "Delivery"
        Me.ColIdDelivery.FieldName = "id_delivery"
        Me.ColIdDelivery.Name = "ColIdDelivery"
        Me.ColIdDelivery.OptionsColumn.AllowEdit = False
        '
        'ColIdSeason
        '
        Me.ColIdSeason.Caption = "Season"
        Me.ColIdSeason.FieldName = "id_season"
        Me.ColIdSeason.Name = "ColIdSeason"
        Me.ColIdSeason.OptionsColumn.AllowEdit = False
        '
        'GridColumn5
        '
        Me.GridColumn5.Caption = "Vat"
        Me.GridColumn5.DisplayFormat.FormatString = "N2"
        Me.GridColumn5.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumn5.FieldName = "vat"
        Me.GridColumn5.Name = "GridColumn5"
        '
        'GridColumn1
        '
        Me.GridColumn1.Caption = "Revised From"
        Me.GridColumn1.FieldName = "mat_purc_rev_number"
        Me.GridColumn1.Name = "GridColumn1"
        Me.GridColumn1.OptionsColumn.AllowEdit = False
        Me.GridColumn1.Visible = True
        Me.GridColumn1.VisibleIndex = 9
        Me.GridColumn1.Width = 146
        '
        'PCFilterDate
        '
        Me.PCFilterDate.Controls.Add(Me.PCSelAll)
        Me.PCFilterDate.Controls.Add(Me.BClearFilter)
        Me.PCFilterDate.Controls.Add(Me.BPrint)
        Me.PCFilterDate.Controls.Add(Me.BFilter)
        Me.PCFilterDate.Controls.Add(Me.LabelControl6)
        Me.PCFilterDate.Controls.Add(Me.LabelControl11)
        Me.PCFilterDate.Controls.Add(Me.DEEnd)
        Me.PCFilterDate.Controls.Add(Me.DEStart)
        Me.PCFilterDate.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PCFilterDate.Location = New System.Drawing.Point(0, 309)
        Me.PCFilterDate.Name = "PCFilterDate"
        Me.PCFilterDate.Size = New System.Drawing.Size(790, 38)
        Me.PCFilterDate.TabIndex = 6
        Me.PCFilterDate.Visible = False
        '
        'PCSelAll
        '
        Me.PCSelAll.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
        Me.PCSelAll.Controls.Add(Me.CheckEditSelAll)
        Me.PCSelAll.Dock = System.Windows.Forms.DockStyle.Right
        Me.PCSelAll.Location = New System.Drawing.Point(689, 2)
        Me.PCSelAll.Name = "PCSelAll"
        Me.PCSelAll.Size = New System.Drawing.Size(99, 34)
        Me.PCSelAll.TabIndex = 8911
        '
        'CheckEditSelAll
        '
        Me.CheckEditSelAll.Location = New System.Drawing.Point(5, 7)
        Me.CheckEditSelAll.Name = "CheckEditSelAll"
        Me.CheckEditSelAll.Properties.Caption = "Select All"
        Me.CheckEditSelAll.Size = New System.Drawing.Size(92, 19)
        Me.CheckEditSelAll.TabIndex = 102
        '
        'BClearFilter
        '
        Me.BClearFilter.Location = New System.Drawing.Point(398, 7)
        Me.BClearFilter.Name = "BClearFilter"
        Me.BClearFilter.Size = New System.Drawing.Size(73, 23)
        Me.BClearFilter.TabIndex = 8910
        Me.BClearFilter.Text = "Clear Filter"
        '
        'BPrint
        '
        Me.BPrint.Location = New System.Drawing.Point(477, 7)
        Me.BPrint.Name = "BPrint"
        Me.BPrint.Size = New System.Drawing.Size(84, 23)
        Me.BPrint.TabIndex = 8909
        Me.BPrint.Text = "Create List"
        '
        'BFilter
        '
        Me.BFilter.Location = New System.Drawing.Point(333, 7)
        Me.BFilter.Name = "BFilter"
        Me.BFilter.Size = New System.Drawing.Size(59, 23)
        Me.BFilter.TabIndex = 8908
        Me.BFilter.Text = "Filter"
        '
        'LabelControl6
        '
        Me.LabelControl6.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl6.Location = New System.Drawing.Point(187, 12)
        Me.LabelControl6.Name = "LabelControl6"
        Me.LabelControl6.Size = New System.Drawing.Size(4, 13)
        Me.LabelControl6.TabIndex = 8907
        Me.LabelControl6.Text = "-"
        '
        'LabelControl11
        '
        Me.LabelControl11.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl11.Location = New System.Drawing.Point(11, 12)
        Me.LabelControl11.Name = "LabelControl11"
        Me.LabelControl11.Size = New System.Drawing.Size(36, 13)
        Me.LabelControl11.TabIndex = 8895
        Me.LabelControl11.Text = "Periode"
        '
        'DEEnd
        '
        Me.DEEnd.EditValue = Nothing
        Me.DEEnd.Location = New System.Drawing.Point(197, 9)
        Me.DEEnd.Name = "DEEnd"
        Me.DEEnd.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.DEEnd.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.DEEnd.Properties.DisplayFormat.FormatString = "dd MMMM yyyy"
        Me.DEEnd.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.DEEnd.Size = New System.Drawing.Size(130, 20)
        Me.DEEnd.TabIndex = 8906
        '
        'DEStart
        '
        Me.DEStart.EditValue = Nothing
        Me.DEStart.Location = New System.Drawing.Point(53, 9)
        Me.DEStart.Name = "DEStart"
        Me.DEStart.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.DEStart.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.DEStart.Properties.DisplayFormat.FormatString = "dd MMMM yyyy"
        Me.DEStart.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.DEStart.Size = New System.Drawing.Size(128, 20)
        Me.DEStart.TabIndex = 8904
        '
        'PanelControl2
        '
        Me.PanelControl2.Controls.Add(Me.BShowFilterPanel)
        Me.PanelControl2.Controls.Add(Me.BSearch)
        Me.PanelControl2.Controls.Add(Me.LabelControl12)
        Me.PanelControl2.Controls.Add(Me.LESeason)
        Me.PanelControl2.Dock = System.Windows.Forms.DockStyle.Top
        Me.PanelControl2.Location = New System.Drawing.Point(0, 0)
        Me.PanelControl2.Name = "PanelControl2"
        Me.PanelControl2.Size = New System.Drawing.Size(790, 44)
        Me.PanelControl2.TabIndex = 5
        '
        'BShowFilterPanel
        '
        Me.BShowFilterPanel.Location = New System.Drawing.Point(279, 9)
        Me.BShowFilterPanel.Name = "BShowFilterPanel"
        Me.BShowFilterPanel.Size = New System.Drawing.Size(100, 23)
        Me.BShowFilterPanel.TabIndex = 8905
        Me.BShowFilterPanel.Text = "Show Filter Panel"
        '
        'BSearch
        '
        Me.BSearch.Location = New System.Drawing.Point(214, 9)
        Me.BSearch.Name = "BSearch"
        Me.BSearch.Size = New System.Drawing.Size(59, 23)
        Me.BSearch.TabIndex = 8904
        Me.BSearch.Text = "Search"
        '
        'LabelControl12
        '
        Me.LabelControl12.Location = New System.Drawing.Point(11, 14)
        Me.LabelControl12.Name = "LabelControl12"
        Me.LabelControl12.Size = New System.Drawing.Size(35, 13)
        Me.LabelControl12.TabIndex = 141
        Me.LabelControl12.Text = "Season"
        '
        'LESeason
        '
        Me.LESeason.Location = New System.Drawing.Point(52, 11)
        Me.LESeason.Name = "LESeason"
        Me.LESeason.Properties.AppearanceReadOnly.BackColor = System.Drawing.Color.WhiteSmoke
        Me.LESeason.Properties.AppearanceReadOnly.ForeColor = System.Drawing.Color.Black
        Me.LESeason.Properties.AppearanceReadOnly.Options.UseBackColor = True
        Me.LESeason.Properties.AppearanceReadOnly.Options.UseForeColor = True
        Me.LESeason.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.LESeason.Properties.NullText = ""
        Me.LESeason.Properties.ShowFooter = False
        Me.LESeason.Properties.View = Me.GridView2
        Me.LESeason.Size = New System.Drawing.Size(156, 20)
        Me.LESeason.TabIndex = 140
        '
        'GridView2
        '
        Me.GridView2.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumn3, Me.GridColumn4})
        Me.GridView2.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
        Me.GridView2.Name = "GridView2"
        Me.GridView2.OptionsSelection.EnableAppearanceFocusedCell = False
        Me.GridView2.OptionsView.ShowGroupPanel = False
        '
        'GridColumn3
        '
        Me.GridColumn3.Caption = "Id Season"
        Me.GridColumn3.FieldName = "id_season"
        Me.GridColumn3.Name = "GridColumn3"
        '
        'GridColumn4
        '
        Me.GridColumn4.Caption = "Season"
        Me.GridColumn4.FieldName = "season"
        Me.GridColumn4.Name = "GridColumn4"
        Me.GridColumn4.Visible = True
        Me.GridColumn4.VisibleIndex = 0
        '
        'XTPProdDemand
        '
        Me.XTPProdDemand.Controls.Add(Me.XTCListPD)
        Me.XTPProdDemand.Name = "XTPProdDemand"
        Me.XTPProdDemand.Size = New System.Drawing.Size(790, 347)
        Me.XTPProdDemand.Text = "Generate From PD"
        '
        'XTCListPD
        '
        Me.XTCListPD.Dock = System.Windows.Forms.DockStyle.Fill
        Me.XTCListPD.HeaderLocation = DevExpress.XtraTab.TabHeaderLocation.Bottom
        Me.XTCListPD.Location = New System.Drawing.Point(0, 0)
        Me.XTCListPD.Name = "XTCListPD"
        Me.XTCListPD.SelectedTabPage = Me.XTPList
        Me.XTCListPD.Size = New System.Drawing.Size(790, 347)
        Me.XTCListPD.TabIndex = 8906
        Me.XTCListPD.TabPages.AddRange(New DevExpress.XtraTab.XtraTabPage() {Me.XTPList, Me.XTPReport})
        '
        'XTPList
        '
        Me.XTPList.Controls.Add(Me.GCListMatPD)
        Me.XTPList.Controls.Add(Me.PanelControl1)
        Me.XTPList.Controls.Add(Me.BCreatePO)
        Me.XTPList.Name = "XTPList"
        Me.XTPList.Size = New System.Drawing.Size(784, 319)
        Me.XTPList.Text = "Final Raw Material List"
        '
        'GCListMatPD
        '
        Me.GCListMatPD.ContextMenuStrip = Me.ViewMenu
        Me.GCListMatPD.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCListMatPD.Location = New System.Drawing.Point(0, 44)
        Me.GCListMatPD.MainView = Me.GVListMatPD
        Me.GCListMatPD.Name = "GCListMatPD"
        Me.GCListMatPD.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.RICEPD})
        Me.GCListMatPD.Size = New System.Drawing.Size(784, 241)
        Me.GCListMatPD.TabIndex = 7
        Me.GCListMatPD.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVListMatPD})
        '
        'ViewMenu
        '
        Me.ViewMenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.SMMasterMat})
        Me.ViewMenu.Name = "ContextMenuStripYM"
        Me.ViewMenu.Size = New System.Drawing.Size(157, 26)
        '
        'SMMasterMat
        '
        Me.SMMasterMat.Name = "SMMasterMat"
        Me.SMMasterMat.Size = New System.Drawing.Size(156, 22)
        Me.SMMasterMat.Text = "Master Material"
        '
        'GVListMatPD
        '
        Me.GVListMatPD.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumn17, Me.GridColumn8, Me.GridColumn9, Me.GridColumn24, Me.GridColumn10, Me.GridColumn28, Me.GridColumn25, Me.GridColumn26, Me.GridColumn27, Me.GridColumn11, Me.GridColumn13, Me.GridColumn22, Me.GridColumn19, Me.GridColumn21, Me.GridColumn18, Me.GridColumn23, Me.GridColumn20, Me.GridColumn14})
        Me.GVListMatPD.GridControl = Me.GCListMatPD
        Me.GVListMatPD.Name = "GVListMatPD"
        Me.GVListMatPD.OptionsView.ColumnAutoWidth = False
        Me.GVListMatPD.OptionsView.ShowGroupPanel = False
        Me.GVListMatPD.OptionsView.ShowHorizontalLines = DevExpress.Utils.DefaultBoolean.[True]
        '
        'GridColumn17
        '
        Me.GridColumn17.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumn17.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridColumn17.AppearanceHeader.Options.UseTextOptions = True
        Me.GridColumn17.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridColumn17.Caption = "*"
        Me.GridColumn17.ColumnEdit = Me.RICEPD
        Me.GridColumn17.FieldName = "is_check"
        Me.GridColumn17.Name = "GridColumn17"
        Me.GridColumn17.Visible = True
        Me.GridColumn17.VisibleIndex = 0
        Me.GridColumn17.Width = 51
        '
        'RICEPD
        '
        Me.RICEPD.AutoHeight = False
        Me.RICEPD.Name = "RICEPD"
        Me.RICEPD.ValueChecked = "yes"
        Me.RICEPD.ValueUnchecked = "no"
        '
        'GridColumn8
        '
        Me.GridColumn8.Caption = "ID"
        Me.GridColumn8.FieldName = "id_mat_purc_list"
        Me.GridColumn8.Name = "GridColumn8"
        Me.GridColumn8.OptionsColumn.AllowEdit = False
        Me.GridColumn8.OptionsColumn.ReadOnly = True
        '
        'GridColumn9
        '
        Me.GridColumn9.Caption = "Number"
        Me.GridColumn9.FieldName = "number"
        Me.GridColumn9.Name = "GridColumn9"
        Me.GridColumn9.OptionsColumn.AllowEdit = False
        Me.GridColumn9.OptionsColumn.ReadOnly = True
        Me.GridColumn9.Visible = True
        Me.GridColumn9.VisibleIndex = 1
        Me.GridColumn9.Width = 77
        '
        'GridColumn24
        '
        Me.GridColumn24.Caption = "Code"
        Me.GridColumn24.FieldName = "mat_det_code"
        Me.GridColumn24.Name = "GridColumn24"
        Me.GridColumn24.Visible = True
        Me.GridColumn24.VisibleIndex = 2
        Me.GridColumn24.Width = 94
        '
        'GridColumn10
        '
        Me.GridColumn10.Caption = "Material"
        Me.GridColumn10.FieldName = "mat_det_display_name"
        Me.GridColumn10.Name = "GridColumn10"
        Me.GridColumn10.OptionsColumn.AllowEdit = False
        Me.GridColumn10.OptionsColumn.ReadOnly = True
        Me.GridColumn10.Visible = True
        Me.GridColumn10.VisibleIndex = 3
        Me.GridColumn10.Width = 155
        '
        'GridColumn28
        '
        Me.GridColumn28.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumn28.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridColumn28.AppearanceHeader.Options.UseTextOptions = True
        Me.GridColumn28.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridColumn28.Caption = "Conversion"
        Me.GridColumn28.FieldName = "conversion"
        Me.GridColumn28.Name = "GridColumn28"
        Me.GridColumn28.Visible = True
        Me.GridColumn28.VisibleIndex = 5
        '
        'GridColumn25
        '
        Me.GridColumn25.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumn25.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumn25.AppearanceHeader.Options.UseTextOptions = True
        Me.GridColumn25.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumn25.Caption = "Total Qty List (Pcs)"
        Me.GridColumn25.DisplayFormat.FormatString = "N2"
        Me.GridColumn25.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumn25.FieldName = "total_qty_list"
        Me.GridColumn25.Name = "GridColumn25"
        Me.GridColumn25.Visible = True
        Me.GridColumn25.VisibleIndex = 4
        '
        'GridColumn26
        '
        Me.GridColumn26.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumn26.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumn26.AppearanceHeader.Options.UseTextOptions = True
        Me.GridColumn26.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumn26.Caption = "Total Qty List (Conversion)"
        Me.GridColumn26.DisplayFormat.FormatString = "N2"
        Me.GridColumn26.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumn26.FieldName = "total_qty_list_conv"
        Me.GridColumn26.Name = "GridColumn26"
        Me.GridColumn26.Visible = True
        Me.GridColumn26.VisibleIndex = 6
        '
        'GridColumn27
        '
        Me.GridColumn27.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumn27.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumn27.AppearanceHeader.Options.UseTextOptions = True
        Me.GridColumn27.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumn27.Caption = "Total Qty Order (Conversion)"
        Me.GridColumn27.DisplayFormat.FormatString = "N2"
        Me.GridColumn27.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumn27.FieldName = "total_qty_order_conv"
        Me.GridColumn27.Name = "GridColumn27"
        Me.GridColumn27.Visible = True
        Me.GridColumn27.VisibleIndex = 7
        '
        'GridColumn11
        '
        Me.GridColumn11.Caption = "Total Qty Order (Pcs)"
        Me.GridColumn11.DisplayFormat.FormatString = "N2"
        Me.GridColumn11.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumn11.FieldName = "total_qty_order"
        Me.GridColumn11.Name = "GridColumn11"
        Me.GridColumn11.OptionsColumn.AllowEdit = False
        Me.GridColumn11.OptionsColumn.ReadOnly = True
        Me.GridColumn11.Visible = True
        Me.GridColumn11.VisibleIndex = 8
        Me.GridColumn11.Width = 58
        '
        'GridColumn13
        '
        Me.GridColumn13.Caption = "PO Number"
        Me.GridColumn13.FieldName = "mat_purc_number"
        Me.GridColumn13.Name = "GridColumn13"
        Me.GridColumn13.OptionsColumn.AllowEdit = False
        Me.GridColumn13.OptionsColumn.ReadOnly = True
        Me.GridColumn13.Visible = True
        Me.GridColumn13.VisibleIndex = 13
        Me.GridColumn13.Width = 73
        '
        'GridColumn22
        '
        Me.GridColumn22.Caption = "ID Comp Contact"
        Me.GridColumn22.FieldName = "id_comp_contact"
        Me.GridColumn22.Name = "GridColumn22"
        '
        'GridColumn19
        '
        Me.GridColumn19.Caption = "Vendor"
        Me.GridColumn19.FieldName = "comp_name"
        Me.GridColumn19.Name = "GridColumn19"
        Me.GridColumn19.Visible = True
        Me.GridColumn19.VisibleIndex = 10
        Me.GridColumn19.Width = 88
        '
        'GridColumn21
        '
        Me.GridColumn21.Caption = "ID Currency"
        Me.GridColumn21.FieldName = "id_currency"
        Me.GridColumn21.Name = "GridColumn21"
        '
        'GridColumn18
        '
        Me.GridColumn18.Caption = "Currency"
        Me.GridColumn18.FieldName = "currency"
        Me.GridColumn18.Name = "GridColumn18"
        Me.GridColumn18.Visible = True
        Me.GridColumn18.VisibleIndex = 11
        Me.GridColumn18.Width = 34
        '
        'GridColumn23
        '
        Me.GridColumn23.Caption = "ID Price"
        Me.GridColumn23.FieldName = "id_mat_det_price"
        Me.GridColumn23.Name = "GridColumn23"
        '
        'GridColumn20
        '
        Me.GridColumn20.Caption = "Price (Default)"
        Me.GridColumn20.FieldName = "mat_det_price"
        Me.GridColumn20.Name = "GridColumn20"
        Me.GridColumn20.Visible = True
        Me.GridColumn20.VisibleIndex = 12
        Me.GridColumn20.Width = 46
        '
        'GridColumn14
        '
        Me.GridColumn14.Caption = "Status"
        Me.GridColumn14.FieldName = "status"
        Me.GridColumn14.Name = "GridColumn14"
        Me.GridColumn14.OptionsColumn.AllowEdit = False
        Me.GridColumn14.OptionsColumn.ReadOnly = True
        Me.GridColumn14.Visible = True
        Me.GridColumn14.VisibleIndex = 9
        Me.GridColumn14.Width = 96
        '
        'PanelControl1
        '
        Me.PanelControl1.Controls.Add(Me.BGenerateFromPD)
        Me.PanelControl1.Controls.Add(Me.BView)
        Me.PanelControl1.Controls.Add(Me.LabelControl1)
        Me.PanelControl1.Controls.Add(Me.SLEMatDet)
        Me.PanelControl1.Dock = System.Windows.Forms.DockStyle.Top
        Me.PanelControl1.Location = New System.Drawing.Point(0, 0)
        Me.PanelControl1.Name = "PanelControl1"
        Me.PanelControl1.Size = New System.Drawing.Size(784, 44)
        Me.PanelControl1.TabIndex = 6
        '
        'BGenerateFromPD
        '
        Me.BGenerateFromPD.Dock = System.Windows.Forms.DockStyle.Right
        Me.BGenerateFromPD.ImageIndex = 4
        Me.BGenerateFromPD.ImageList = Me.LargeImageCollection
        Me.BGenerateFromPD.Location = New System.Drawing.Point(538, 2)
        Me.BGenerateFromPD.Name = "BGenerateFromPD"
        Me.BGenerateFromPD.Size = New System.Drawing.Size(244, 40)
        Me.BGenerateFromPD.TabIndex = 8910
        Me.BGenerateFromPD.Text = "Create Final raw material list from PD"
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
        'BView
        '
        Me.BView.Location = New System.Drawing.Point(217, 9)
        Me.BView.Name = "BView"
        Me.BView.Size = New System.Drawing.Size(59, 23)
        Me.BView.TabIndex = 8904
        Me.BView.Text = "View"
        '
        'LabelControl1
        '
        Me.LabelControl1.Location = New System.Drawing.Point(11, 14)
        Me.LabelControl1.Name = "LabelControl1"
        Me.LabelControl1.Size = New System.Drawing.Size(38, 13)
        Me.LabelControl1.TabIndex = 141
        Me.LabelControl1.Text = "Material"
        '
        'SLEMatDet
        '
        Me.SLEMatDet.Location = New System.Drawing.Point(55, 11)
        Me.SLEMatDet.Name = "SLEMatDet"
        Me.SLEMatDet.Properties.AppearanceReadOnly.BackColor = System.Drawing.Color.WhiteSmoke
        Me.SLEMatDet.Properties.AppearanceReadOnly.ForeColor = System.Drawing.Color.Black
        Me.SLEMatDet.Properties.AppearanceReadOnly.Options.UseBackColor = True
        Me.SLEMatDet.Properties.AppearanceReadOnly.Options.UseForeColor = True
        Me.SLEMatDet.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.SLEMatDet.Properties.NullText = ""
        Me.SLEMatDet.Properties.ShowFooter = False
        Me.SLEMatDet.Properties.View = Me.GridView3
        Me.SLEMatDet.Size = New System.Drawing.Size(156, 20)
        Me.SLEMatDet.TabIndex = 140
        '
        'GridView3
        '
        Me.GridView3.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumn6, Me.GridColumn12, Me.GridColumn7, Me.GridColumn15, Me.GridColumn16})
        Me.GridView3.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
        Me.GridView3.Name = "GridView3"
        Me.GridView3.OptionsSelection.EnableAppearanceFocusedCell = False
        Me.GridView3.OptionsView.ShowGroupPanel = False
        '
        'GridColumn6
        '
        Me.GridColumn6.Caption = "Id"
        Me.GridColumn6.FieldName = "id_mat_det"
        Me.GridColumn6.Name = "GridColumn6"
        '
        'GridColumn12
        '
        Me.GridColumn12.Caption = "ID Mat"
        Me.GridColumn12.FieldName = "id_mat"
        Me.GridColumn12.Name = "GridColumn12"
        '
        'GridColumn7
        '
        Me.GridColumn7.Caption = "Material Code"
        Me.GridColumn7.FieldName = "mat_det_code"
        Me.GridColumn7.Name = "GridColumn7"
        Me.GridColumn7.Visible = True
        Me.GridColumn7.VisibleIndex = 0
        Me.GridColumn7.Width = 319
        '
        'GridColumn15
        '
        Me.GridColumn15.Caption = "Material"
        Me.GridColumn15.FieldName = "mat_det_display_name"
        Me.GridColumn15.Name = "GridColumn15"
        Me.GridColumn15.Visible = True
        Me.GridColumn15.VisibleIndex = 1
        Me.GridColumn15.Width = 1028
        '
        'GridColumn16
        '
        Me.GridColumn16.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumn16.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridColumn16.AppearanceHeader.Options.UseTextOptions = True
        Me.GridColumn16.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridColumn16.Caption = "UOM"
        Me.GridColumn16.FieldName = "uom"
        Me.GridColumn16.Name = "GridColumn16"
        Me.GridColumn16.Visible = True
        Me.GridColumn16.VisibleIndex = 2
        Me.GridColumn16.Width = 285
        '
        'BCreatePO
        '
        Me.BCreatePO.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.BCreatePO.Location = New System.Drawing.Point(0, 285)
        Me.BCreatePO.Name = "BCreatePO"
        Me.BCreatePO.Size = New System.Drawing.Size(784, 34)
        Me.BCreatePO.TabIndex = 8905
        Me.BCreatePO.Text = "Create PO"
        '
        'XTPReport
        '
        Me.XTPReport.Controls.Add(Me.GCPD)
        Me.XTPReport.Controls.Add(Me.PanelControl3)
        Me.XTPReport.Name = "XTPReport"
        Me.XTPReport.Size = New System.Drawing.Size(784, 319)
        Me.XTPReport.Text = "Report"
        '
        'GCPD
        '
        Me.GCPD.ContextMenuStrip = Me.ViewMenuReport
        Me.GCPD.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCPD.Location = New System.Drawing.Point(0, 44)
        Me.GCPD.MainView = Me.GVPD
        Me.GCPD.Name = "GCPD"
        Me.GCPD.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.RepositoryItemCheckEdit1})
        Me.GCPD.Size = New System.Drawing.Size(784, 275)
        Me.GCPD.TabIndex = 3
        Me.GCPD.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVPD})
        '
        'ViewMenuReport
        '
        Me.ViewMenuReport.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripMenuItem1, Me.ViewPOToolStripMenuItem})
        Me.ViewMenuReport.Name = "ContextMenuStripYM"
        Me.ViewMenuReport.Size = New System.Drawing.Size(121, 48)
        '
        'ToolStripMenuItem1
        '
        Me.ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        Me.ToolStripMenuItem1.Size = New System.Drawing.Size(120, 22)
        Me.ToolStripMenuItem1.Text = "View List"
        '
        'ViewPOToolStripMenuItem
        '
        Me.ViewPOToolStripMenuItem.Name = "ViewPOToolStripMenuItem"
        Me.ViewPOToolStripMenuItem.Size = New System.Drawing.Size(120, 22)
        Me.ViewPOToolStripMenuItem.Text = "View PO"
        '
        'GVPD
        '
        Me.GVPD.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumn29, Me.GridColumn30, Me.GridColumn31, Me.GridColumn32, Me.GridColumn35, Me.GridColumn39, Me.GridColumn38, Me.GridColumn34, Me.GridColumn40, Me.GridColumn33})
        Me.GVPD.GridControl = Me.GCPD
        Me.GVPD.Name = "GVPD"
        Me.GVPD.OptionsFind.AlwaysVisible = True
        Me.GVPD.OptionsView.ShowFooter = True
        Me.GVPD.OptionsView.ShowGroupPanel = False
        '
        'GridColumn29
        '
        Me.GridColumn29.Caption = "ID"
        Me.GridColumn29.FieldName = "id_prod_demand_design"
        Me.GridColumn29.Name = "GridColumn29"
        Me.GridColumn29.OptionsColumn.AllowEdit = False
        Me.GridColumn29.OptionsColumn.ReadOnly = True
        '
        'GridColumn30
        '
        Me.GridColumn30.Caption = "Prod Demand Number"
        Me.GridColumn30.FieldName = "prod_demand_number"
        Me.GridColumn30.Name = "GridColumn30"
        Me.GridColumn30.OptionsColumn.AllowEdit = False
        Me.GridColumn30.OptionsColumn.ReadOnly = True
        Me.GridColumn30.Visible = True
        Me.GridColumn30.VisibleIndex = 0
        Me.GridColumn30.Width = 241
        '
        'GridColumn31
        '
        Me.GridColumn31.Caption = "Design Code"
        Me.GridColumn31.FieldName = "design_code"
        Me.GridColumn31.Name = "GridColumn31"
        Me.GridColumn31.OptionsColumn.AllowEdit = False
        Me.GridColumn31.OptionsColumn.ReadOnly = True
        Me.GridColumn31.Visible = True
        Me.GridColumn31.VisibleIndex = 1
        Me.GridColumn31.Width = 254
        '
        'GridColumn32
        '
        Me.GridColumn32.Caption = "Design"
        Me.GridColumn32.FieldName = "design_display_name"
        Me.GridColumn32.Name = "GridColumn32"
        Me.GridColumn32.OptionsColumn.AllowEdit = False
        Me.GridColumn32.OptionsColumn.ReadOnly = True
        Me.GridColumn32.Visible = True
        Me.GridColumn32.VisibleIndex = 2
        Me.GridColumn32.Width = 731
        '
        'GridColumn35
        '
        Me.GridColumn35.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumn35.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumn35.AppearanceHeader.Options.UseTextOptions = True
        Me.GridColumn35.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumn35.Caption = "List Created"
        Me.GridColumn35.FieldName = "jml_list"
        Me.GridColumn35.Name = "GridColumn35"
        Me.GridColumn35.Visible = True
        Me.GridColumn35.VisibleIndex = 3
        Me.GridColumn35.Width = 210
        '
        'GridColumn39
        '
        Me.GridColumn39.Caption = "List Number"
        Me.GridColumn39.FieldName = "list_group"
        Me.GridColumn39.Name = "GridColumn39"
        Me.GridColumn39.Visible = True
        Me.GridColumn39.VisibleIndex = 4
        '
        'GridColumn38
        '
        Me.GridColumn38.Caption = "ID List Group"
        Me.GridColumn38.FieldName = "id_list_group"
        Me.GridColumn38.Name = "GridColumn38"
        '
        'GridColumn34
        '
        Me.GridColumn34.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumn34.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumn34.AppearanceHeader.Options.UseTextOptions = True
        Me.GridColumn34.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumn34.Caption = "PO Material Created"
        Me.GridColumn34.DisplayFormat.FormatString = "N0"
        Me.GridColumn34.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumn34.FieldName = "jml_po"
        Me.GridColumn34.Name = "GridColumn34"
        Me.GridColumn34.OptionsColumn.AllowEdit = False
        Me.GridColumn34.OptionsColumn.ReadOnly = True
        Me.GridColumn34.Visible = True
        Me.GridColumn34.VisibleIndex = 5
        Me.GridColumn34.Width = 196
        '
        'GridColumn40
        '
        Me.GridColumn40.Caption = "PO Number"
        Me.GridColumn40.FieldName = "po_group"
        Me.GridColumn40.Name = "GridColumn40"
        Me.GridColumn40.Visible = True
        Me.GridColumn40.VisibleIndex = 6
        '
        'GridColumn33
        '
        Me.GridColumn33.Caption = "ID PO"
        Me.GridColumn33.FieldName = "id_po_group"
        Me.GridColumn33.Name = "GridColumn33"
        '
        'RepositoryItemCheckEdit1
        '
        Me.RepositoryItemCheckEdit1.AutoHeight = False
        Me.RepositoryItemCheckEdit1.Name = "RepositoryItemCheckEdit1"
        Me.RepositoryItemCheckEdit1.ValueChecked = "yes"
        Me.RepositoryItemCheckEdit1.ValueUnchecked = "no"
        '
        'PanelControl3
        '
        Me.PanelControl3.Controls.Add(Me.BSearchReport)
        Me.PanelControl3.Controls.Add(Me.LabelControl2)
        Me.PanelControl3.Controls.Add(Me.SLEReport)
        Me.PanelControl3.Dock = System.Windows.Forms.DockStyle.Top
        Me.PanelControl3.Location = New System.Drawing.Point(0, 0)
        Me.PanelControl3.Name = "PanelControl3"
        Me.PanelControl3.Size = New System.Drawing.Size(784, 44)
        Me.PanelControl3.TabIndex = 6
        '
        'BSearchReport
        '
        Me.BSearchReport.Location = New System.Drawing.Point(214, 9)
        Me.BSearchReport.Name = "BSearchReport"
        Me.BSearchReport.Size = New System.Drawing.Size(59, 23)
        Me.BSearchReport.TabIndex = 8904
        Me.BSearchReport.Text = "Search"
        '
        'LabelControl2
        '
        Me.LabelControl2.Location = New System.Drawing.Point(11, 14)
        Me.LabelControl2.Name = "LabelControl2"
        Me.LabelControl2.Size = New System.Drawing.Size(35, 13)
        Me.LabelControl2.TabIndex = 141
        Me.LabelControl2.Text = "Season"
        '
        'SLEReport
        '
        Me.SLEReport.Location = New System.Drawing.Point(52, 11)
        Me.SLEReport.Name = "SLEReport"
        Me.SLEReport.Properties.AppearanceReadOnly.BackColor = System.Drawing.Color.WhiteSmoke
        Me.SLEReport.Properties.AppearanceReadOnly.ForeColor = System.Drawing.Color.Black
        Me.SLEReport.Properties.AppearanceReadOnly.Options.UseBackColor = True
        Me.SLEReport.Properties.AppearanceReadOnly.Options.UseForeColor = True
        Me.SLEReport.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.SLEReport.Properties.NullText = ""
        Me.SLEReport.Properties.ShowFooter = False
        Me.SLEReport.Properties.View = Me.GridView4
        Me.SLEReport.Size = New System.Drawing.Size(156, 20)
        Me.SLEReport.TabIndex = 140
        '
        'GridView4
        '
        Me.GridView4.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumn36, Me.GridColumn37})
        Me.GridView4.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
        Me.GridView4.Name = "GridView4"
        Me.GridView4.OptionsSelection.EnableAppearanceFocusedCell = False
        Me.GridView4.OptionsView.ShowGroupPanel = False
        '
        'GridColumn36
        '
        Me.GridColumn36.Caption = "Id Season"
        Me.GridColumn36.FieldName = "id_season"
        Me.GridColumn36.Name = "GridColumn36"
        '
        'GridColumn37
        '
        Me.GridColumn37.Caption = "Season"
        Me.GridColumn37.FieldName = "season"
        Me.GridColumn37.Name = "GridColumn37"
        Me.GridColumn37.Visible = True
        Me.GridColumn37.VisibleIndex = 0
        '
        'XTPOrderConfirmation
        '
        Me.XTPOrderConfirmation.Controls.Add(Me.GCKO)
        Me.XTPOrderConfirmation.Controls.Add(Me.PanelControl5)
        Me.XTPOrderConfirmation.Name = "XTPOrderConfirmation"
        Me.XTPOrderConfirmation.Size = New System.Drawing.Size(790, 347)
        Me.XTPOrderConfirmation.Text = "Order Confirmation"
        '
        'GCKO
        '
        Me.GCKO.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCKO.Location = New System.Drawing.Point(0, 38)
        Me.GCKO.MainView = Me.GVKO
        Me.GCKO.Name = "GCKO"
        Me.GCKO.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.RepositoryItemProgressBar2})
        Me.GCKO.Size = New System.Drawing.Size(790, 309)
        Me.GCKO.TabIndex = 11
        Me.GCKO.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVKO})
        '
        'GVKO
        '
        Me.GVKO.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumn49, Me.GridColumn50, Me.GridColumn59, Me.GridColumn60, Me.GridColumn61})
        Me.GVKO.GridControl = Me.GCKO
        Me.GVKO.Name = "GVKO"
        Me.GVKO.OptionsBehavior.Editable = False
        Me.GVKO.OptionsFind.AlwaysVisible = True
        Me.GVKO.OptionsView.ColumnAutoWidth = False
        Me.GVKO.OptionsView.ShowGroupPanel = False
        '
        'GridColumn49
        '
        Me.GridColumn49.Caption = "ID KO"
        Me.GridColumn49.FieldName = "id_prod_order_ko"
        Me.GridColumn49.Name = "GridColumn49"
        '
        'GridColumn50
        '
        Me.GridColumn50.Caption = "Number"
        Me.GridColumn50.FieldName = "number"
        Me.GridColumn50.Name = "GridColumn50"
        Me.GridColumn50.Visible = True
        Me.GridColumn50.VisibleIndex = 0
        '
        'GridColumn59
        '
        Me.GridColumn59.Caption = "Revision"
        Me.GridColumn59.FieldName = "revision"
        Me.GridColumn59.Name = "GridColumn59"
        Me.GridColumn59.Visible = True
        Me.GridColumn59.VisibleIndex = 1
        '
        'GridColumn60
        '
        Me.GridColumn60.Caption = "Vendor"
        Me.GridColumn60.FieldName = "comp_name"
        Me.GridColumn60.Name = "GridColumn60"
        Me.GridColumn60.Visible = True
        Me.GridColumn60.VisibleIndex = 2
        '
        'GridColumn61
        '
        Me.GridColumn61.Caption = "Created Date"
        Me.GridColumn61.DisplayFormat.FormatString = "dd MMMM yyyy"
        Me.GridColumn61.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.GridColumn61.FieldName = "date_created"
        Me.GridColumn61.Name = "GridColumn61"
        Me.GridColumn61.Visible = True
        Me.GridColumn61.VisibleIndex = 3
        '
        'RepositoryItemProgressBar2
        '
        Me.RepositoryItemProgressBar2.Appearance.BackColor = System.Drawing.Color.Lime
        Me.RepositoryItemProgressBar2.EndColor = System.Drawing.Color.Green
        Me.RepositoryItemProgressBar2.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Flat
        Me.RepositoryItemProgressBar2.LookAndFeel.UseDefaultLookAndFeel = False
        Me.RepositoryItemProgressBar2.Name = "RepositoryItemProgressBar2"
        Me.RepositoryItemProgressBar2.ProgressViewStyle = DevExpress.XtraEditors.Controls.ProgressViewStyle.Solid
        Me.RepositoryItemProgressBar2.ShowTitle = True
        Me.RepositoryItemProgressBar2.StartColor = System.Drawing.Color.Green
        Me.RepositoryItemProgressBar2.Step = 1
        '
        'PanelControl5
        '
        Me.PanelControl5.Controls.Add(Me.BEditKO)
        Me.PanelControl5.Controls.Add(Me.SLEVendorKO)
        Me.PanelControl5.Controls.Add(Me.BViewKO)
        Me.PanelControl5.Controls.Add(Me.LabelControl10)
        Me.PanelControl5.Dock = System.Windows.Forms.DockStyle.Top
        Me.PanelControl5.Location = New System.Drawing.Point(0, 0)
        Me.PanelControl5.Name = "PanelControl5"
        Me.PanelControl5.Size = New System.Drawing.Size(790, 38)
        Me.PanelControl5.TabIndex = 5
        '
        'BEditKO
        '
        Me.BEditKO.Dock = System.Windows.Forms.DockStyle.Right
        Me.BEditKO.ImageIndex = 2
        Me.BEditKO.ImageList = Me.LargeImageCollection
        Me.BEditKO.Location = New System.Drawing.Point(698, 2)
        Me.BEditKO.Name = "BEditKO"
        Me.BEditKO.Size = New System.Drawing.Size(90, 34)
        Me.BEditKO.TabIndex = 8906
        Me.BEditKO.Text = "Edit"
        Me.BEditKO.Visible = False
        '
        'SLEVendorKO
        '
        Me.SLEVendorKO.Location = New System.Drawing.Point(51, 8)
        Me.SLEVendorKO.Name = "SLEVendorKO"
        Me.SLEVendorKO.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SLEVendorKO.Properties.Appearance.Options.UseFont = True
        Me.SLEVendorKO.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.SLEVendorKO.Properties.View = Me.GridView1
        Me.SLEVendorKO.Size = New System.Drawing.Size(148, 20)
        Me.SLEVendorKO.TabIndex = 8905
        '
        'GridView1
        '
        Me.GridView1.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumn46, Me.GridColumn47, Me.GridColumn48})
        Me.GridView1.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
        Me.GridView1.Name = "GridView1"
        Me.GridView1.OptionsSelection.EnableAppearanceFocusedCell = False
        Me.GridView1.OptionsView.ShowGroupPanel = False
        '
        'GridColumn46
        '
        Me.GridColumn46.Caption = "Id Comp"
        Me.GridColumn46.FieldName = "id_comp"
        Me.GridColumn46.Name = "GridColumn46"
        '
        'GridColumn47
        '
        Me.GridColumn47.Caption = "Comp Number"
        Me.GridColumn47.FieldName = "comp_number"
        Me.GridColumn47.Name = "GridColumn47"
        Me.GridColumn47.Visible = True
        Me.GridColumn47.VisibleIndex = 0
        Me.GridColumn47.Width = 188
        '
        'GridColumn48
        '
        Me.GridColumn48.Caption = "Comp Name"
        Me.GridColumn48.FieldName = "comp_name"
        Me.GridColumn48.Name = "GridColumn48"
        Me.GridColumn48.Visible = True
        Me.GridColumn48.VisibleIndex = 1
        Me.GridColumn48.Width = 504
        '
        'BViewKO
        '
        Me.BViewKO.Location = New System.Drawing.Point(205, 6)
        Me.BViewKO.Name = "BViewKO"
        Me.BViewKO.Size = New System.Drawing.Size(59, 23)
        Me.BViewKO.TabIndex = 8903
        Me.BViewKO.Text = "Search"
        '
        'LabelControl10
        '
        Me.LabelControl10.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl10.Location = New System.Drawing.Point(11, 11)
        Me.LabelControl10.Name = "LabelControl10"
        Me.LabelControl10.Size = New System.Drawing.Size(34, 13)
        Me.LabelControl10.TabIndex = 8901
        Me.LabelControl10.Text = "Vendor"
        '
        'FormMatPurchase
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(796, 375)
        Me.Controls.Add(Me.XTCPurcMat)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FormMatPurchase"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Purchase Raw Material"
        CType(Me.XTCPurcMat, System.ComponentModel.ISupportInitialize).EndInit()
        Me.XTCPurcMat.ResumeLayout(False)
        Me.XTPPurchaseMat.ResumeLayout(False)
        CType(Me.GCMatPurchase, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVMatPurchase, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RICECheck, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PCFilterDate, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PCFilterDate.ResumeLayout(False)
        Me.PCFilterDate.PerformLayout()
        CType(Me.PCSelAll, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PCSelAll.ResumeLayout(False)
        CType(Me.CheckEditSelAll.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DEEnd.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DEEnd.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DEStart.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DEStart.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PanelControl2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl2.ResumeLayout(False)
        Me.PanelControl2.PerformLayout()
        CType(Me.LESeason.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.XTPProdDemand.ResumeLayout(False)
        CType(Me.XTCListPD, System.ComponentModel.ISupportInitialize).EndInit()
        Me.XTCListPD.ResumeLayout(False)
        Me.XTPList.ResumeLayout(False)
        CType(Me.GCListMatPD, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ViewMenu.ResumeLayout(False)
        CType(Me.GVListMatPD, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RICEPD, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl1.ResumeLayout(False)
        Me.PanelControl1.PerformLayout()
        CType(Me.LargeImageCollection, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SLEMatDet.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.XTPReport.ResumeLayout(False)
        CType(Me.GCPD, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ViewMenuReport.ResumeLayout(False)
        CType(Me.GVPD, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemCheckEdit1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PanelControl3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl3.ResumeLayout(False)
        Me.PanelControl3.PerformLayout()
        CType(Me.SLEReport.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView4, System.ComponentModel.ISupportInitialize).EndInit()
        Me.XTPOrderConfirmation.ResumeLayout(False)
        CType(Me.GCKO, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVKO, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemProgressBar2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PanelControl5, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl5.ResumeLayout(False)
        Me.PanelControl5.PerformLayout()
        CType(Me.SLEVendorKO.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents XTCPurcMat As DevExpress.XtraTab.XtraTabControl
    Friend WithEvents XTPPurchaseMat As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents GCMatPurchase As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVMatPurchase As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents ColIdMatPurchase As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColSeason As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColDelivery As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColPONumber As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColShipFrom As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColShipTo As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColSamplePurcDate As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColRecDate As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColDueDate As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColPayment As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColStatus As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColIDStatus As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColIdDelivery As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColIdSeason As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents XTPProdDemand As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents GridColumn1 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents PanelControl2 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents LabelControl12 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LESeason As DevExpress.XtraEditors.SearchLookUpEdit
    Friend WithEvents GridView2 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumn3 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn4 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents BSearch As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents PCFilterDate As DevExpress.XtraEditors.PanelControl
    Friend WithEvents PCSelAll As DevExpress.XtraEditors.PanelControl
    Friend WithEvents CheckEditSelAll As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents BClearFilter As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BPrint As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BFilter As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents LabelControl6 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl11 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents DEEnd As DevExpress.XtraEditors.DateEdit
    Friend WithEvents DEStart As DevExpress.XtraEditors.DateEdit
    Friend WithEvents GridColumn2 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents RICECheck As DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit
    Friend WithEvents GridColumn5 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents XTPOrderConfirmation As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents PanelControl5 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents BEditKO As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents SLEVendorKO As DevExpress.XtraEditors.SearchLookUpEdit
    Friend WithEvents GridView1 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumn46 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn47 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn48 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents BViewKO As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents LabelControl10 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents GCKO As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVKO As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumn49 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn50 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn59 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn60 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn61 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents RepositoryItemProgressBar2 As DevExpress.XtraEditors.Repository.RepositoryItemProgressBar
    Public WithEvents LargeImageCollection As DevExpress.Utils.ImageCollection
    Friend WithEvents PanelControl1 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents BGenerateFromPD As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BView As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents LabelControl1 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents SLEMatDet As DevExpress.XtraEditors.SearchLookUpEdit
    Friend WithEvents GridView3 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumn6 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn7 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GCListMatPD As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVListMatPD As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumn8 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn9 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn10 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn11 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn13 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn14 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn12 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn15 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn16 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn17 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents RICEPD As DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit
    Friend WithEvents BCreatePO As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents GridColumn22 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn19 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn21 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn18 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn20 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn23 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn24 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ViewMenu As ContextMenuStrip
    Friend WithEvents SMMasterMat As ToolStripMenuItem
    Friend WithEvents GridColumn28 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn25 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn26 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn27 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents XTCListPD As DevExpress.XtraTab.XtraTabControl
    Friend WithEvents XTPList As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents XTPReport As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents GCPD As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVPD As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents RepositoryItemCheckEdit1 As DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit
    Friend WithEvents GridColumn29 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn30 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn31 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn32 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn34 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents PanelControl3 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents BSearchReport As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents LabelControl2 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents SLEReport As DevExpress.XtraEditors.SearchLookUpEdit
    Friend WithEvents GridView4 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumn36 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn37 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn35 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents BShowFilterPanel As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents GridColumn38 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn33 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ViewMenuReport As ContextMenuStrip
    Friend WithEvents ToolStripMenuItem1 As ToolStripMenuItem
    Friend WithEvents ViewPOToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents GridColumn39 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn40 As DevExpress.XtraGrid.Columns.GridColumn
End Class
