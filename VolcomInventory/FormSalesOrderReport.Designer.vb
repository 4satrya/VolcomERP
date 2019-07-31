<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormSalesOrderReport
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormSalesOrderReport))
        Me.XTCSO = New DevExpress.XtraTab.XtraTabControl()
        Me.XTPNew = New DevExpress.XtraTab.XtraTabPage()
        Me.GCNew = New DevExpress.XtraGrid.GridControl()
        Me.GVNew = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumnNewid_sales_order_gen = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnNewid_so_status = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnNewsales_order_gen_reff = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnNewsales_order_gen_date = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnNewsales_order_gen_note = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnNewtotal_order = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnNew = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnNewtotal_completed = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnNewProsScan = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RepositoryItemProgressBarScan = New DevExpress.XtraEditors.Repository.RepositoryItemProgressBar()
        Me.GridColumnNewpros_completed = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GCFilter = New DevExpress.XtraEditors.GroupControl()
        Me.PanelControl1 = New DevExpress.XtraEditors.PanelControl()
        Me.DEUntil = New DevExpress.XtraEditors.DateEdit()
        Me.CEFindAllProduct = New DevExpress.XtraEditors.CheckEdit()
        Me.LabelControl3 = New DevExpress.XtraEditors.LabelControl()
        Me.TxtProduct = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl2 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl5 = New DevExpress.XtraEditors.LabelControl()
        Me.DEFrom = New DevExpress.XtraEditors.DateEdit()
        Me.BtnBrowseProduct = New DevExpress.XtraEditors.SimpleButton()
        Me.CEShowHighlight = New DevExpress.XtraEditors.CheckEdit()
        Me.BtnView = New DevExpress.XtraEditors.SimpleButton()
        Me.BHide = New DevExpress.XtraEditors.SimpleButton()
        Me.XTPAllOrder = New DevExpress.XtraTab.XtraTabPage()
        Me.GCAll = New DevExpress.XtraGrid.GridControl()
        Me.GVAll = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumnid_sales_order = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnsales_order_number = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnsales_order_gen_reff = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnsales_order_date = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnprepare_status = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnwh = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumndestination = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumntotal_order = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumntotal_scan = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumntotal_completed = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnpros_scan = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RepositoryItemProgressBar = New DevExpress.XtraEditors.Repository.RepositoryItemProgressBar()
        Me.GridColumnpros_del = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnso_status = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnfinal_date = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnfinal_comment = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnAllfinal_by_name = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RepositoryItemProgressBar1 = New DevExpress.XtraEditors.Repository.RepositoryItemProgressBar()
        Me.GroupControl1 = New DevExpress.XtraEditors.GroupControl()
        Me.PanelControl2 = New DevExpress.XtraEditors.PanelControl()
        Me.CEFindAllProductSO = New DevExpress.XtraEditors.CheckEdit()
        Me.TxtProductSO = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl8 = New DevExpress.XtraEditors.LabelControl()
        Me.DEUntilAll = New DevExpress.XtraEditors.DateEdit()
        Me.DEFromAll = New DevExpress.XtraEditors.DateEdit()
        Me.BtnBrowseProductSO = New DevExpress.XtraEditors.SimpleButton()
        Me.LabelControl1 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl4 = New DevExpress.XtraEditors.LabelControl()
        Me.BtnViewAll = New DevExpress.XtraEditors.SimpleButton()
        Me.SimpleButton2 = New DevExpress.XtraEditors.SimpleButton()
        CType(Me.XTCSO, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.XTCSO.SuspendLayout()
        Me.XTPNew.SuspendLayout()
        CType(Me.GCNew, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVNew, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemProgressBarScan, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GCFilter, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GCFilter.SuspendLayout()
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl1.SuspendLayout()
        CType(Me.DEUntil.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DEUntil.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CEFindAllProduct.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtProduct.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DEFrom.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DEFrom.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CEShowHighlight.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.XTPAllOrder.SuspendLayout()
        CType(Me.GCAll, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVAll, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemProgressBar, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemProgressBar1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GroupControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupControl1.SuspendLayout()
        CType(Me.PanelControl2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl2.SuspendLayout()
        CType(Me.CEFindAllProductSO.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtProductSO.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DEUntilAll.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DEUntilAll.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DEFromAll.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DEFromAll.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'XTCSO
        '
        Me.XTCSO.Dock = System.Windows.Forms.DockStyle.Fill
        Me.XTCSO.HeaderLocation = DevExpress.XtraTab.TabHeaderLocation.Bottom
        Me.XTCSO.Location = New System.Drawing.Point(0, 0)
        Me.XTCSO.Name = "XTCSO"
        Me.XTCSO.SelectedTabPage = Me.XTPNew
        Me.XTCSO.Size = New System.Drawing.Size(877, 489)
        Me.XTCSO.TabIndex = 0
        Me.XTCSO.TabPages.AddRange(New DevExpress.XtraTab.XtraTabPage() {Me.XTPNew, Me.XTPAllOrder})
        '
        'XTPNew
        '
        Me.XTPNew.Controls.Add(Me.GCNew)
        Me.XTPNew.Controls.Add(Me.GCFilter)
        Me.XTPNew.Name = "XTPNew"
        Me.XTPNew.Size = New System.Drawing.Size(871, 461)
        Me.XTPNew.Text = "New"
        '
        'GCNew
        '
        Me.GCNew.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCNew.Location = New System.Drawing.Point(0, 75)
        Me.GCNew.MainView = Me.GVNew
        Me.GCNew.Name = "GCNew"
        Me.GCNew.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.RepositoryItemProgressBarScan})
        Me.GCNew.Size = New System.Drawing.Size(871, 386)
        Me.GCNew.TabIndex = 5
        Me.GCNew.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVNew})
        '
        'GVNew
        '
        Me.GVNew.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumnNewid_sales_order_gen, Me.GridColumnNewid_so_status, Me.GridColumnNewsales_order_gen_reff, Me.GridColumnNewsales_order_gen_date, Me.GridColumnNewsales_order_gen_note, Me.GridColumnNewtotal_order, Me.GridColumnNew, Me.GridColumnNewtotal_completed, Me.GridColumnNewProsScan, Me.GridColumnNewpros_completed})
        Me.GVNew.GridControl = Me.GCNew
        Me.GVNew.Name = "GVNew"
        Me.GVNew.OptionsFind.AlwaysVisible = True
        Me.GVNew.OptionsSelection.EnableAppearanceFocusedRow = False
        Me.GVNew.OptionsView.ColumnAutoWidth = False
        Me.GVNew.OptionsView.ShowFooter = True
        Me.GVNew.OptionsView.ShowGroupPanel = False
        '
        'GridColumnNewid_sales_order_gen
        '
        Me.GridColumnNewid_sales_order_gen.Caption = "Id Gen"
        Me.GridColumnNewid_sales_order_gen.FieldName = "id_sales_order_gen"
        Me.GridColumnNewid_sales_order_gen.Name = "GridColumnNewid_sales_order_gen"
        '
        'GridColumnNewid_so_status
        '
        Me.GridColumnNewid_so_status.Caption = "id_so_status"
        Me.GridColumnNewid_so_status.FieldName = "id_so_status"
        Me.GridColumnNewid_so_status.Name = "GridColumnNewid_so_status"
        '
        'GridColumnNewsales_order_gen_reff
        '
        Me.GridColumnNewsales_order_gen_reff.Caption = "Reff"
        Me.GridColumnNewsales_order_gen_reff.FieldName = "sales_order_gen_reff"
        Me.GridColumnNewsales_order_gen_reff.Name = "GridColumnNewsales_order_gen_reff"
        Me.GridColumnNewsales_order_gen_reff.Visible = True
        Me.GridColumnNewsales_order_gen_reff.VisibleIndex = 0
        '
        'GridColumnNewsales_order_gen_date
        '
        Me.GridColumnNewsales_order_gen_date.Caption = "Created Date"
        Me.GridColumnNewsales_order_gen_date.DisplayFormat.FormatString = "dd MMMM yyyy"
        Me.GridColumnNewsales_order_gen_date.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.GridColumnNewsales_order_gen_date.FieldName = "sales_order_gen_date"
        Me.GridColumnNewsales_order_gen_date.Name = "GridColumnNewsales_order_gen_date"
        Me.GridColumnNewsales_order_gen_date.Visible = True
        Me.GridColumnNewsales_order_gen_date.VisibleIndex = 1
        '
        'GridColumnNewsales_order_gen_note
        '
        Me.GridColumnNewsales_order_gen_note.Caption = "Note"
        Me.GridColumnNewsales_order_gen_note.FieldName = "sales_order_gen_note"
        Me.GridColumnNewsales_order_gen_note.Name = "GridColumnNewsales_order_gen_note"
        '
        'GridColumnNewtotal_order
        '
        Me.GridColumnNewtotal_order.Caption = "Order Total"
        Me.GridColumnNewtotal_order.DisplayFormat.FormatString = "N0"
        Me.GridColumnNewtotal_order.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumnNewtotal_order.FieldName = "total_order"
        Me.GridColumnNewtotal_order.Name = "GridColumnNewtotal_order"
        Me.GridColumnNewtotal_order.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "total_order", "{0:N0}")})
        Me.GridColumnNewtotal_order.Visible = True
        Me.GridColumnNewtotal_order.VisibleIndex = 2
        Me.GridColumnNewtotal_order.Width = 113
        '
        'GridColumnNew
        '
        Me.GridColumnNew.Caption = "Scan Total"
        Me.GridColumnNew.DisplayFormat.FormatString = "N0"
        Me.GridColumnNew.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumnNew.FieldName = "total_scan"
        Me.GridColumnNew.Name = "GridColumnNew"
        Me.GridColumnNew.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "total_scan", "{0:N0}")})
        Me.GridColumnNew.Visible = True
        Me.GridColumnNew.VisibleIndex = 3
        Me.GridColumnNew.Width = 128
        '
        'GridColumnNewtotal_completed
        '
        Me.GridColumnNewtotal_completed.Caption = "Delivered Total"
        Me.GridColumnNewtotal_completed.DisplayFormat.FormatString = "N0"
        Me.GridColumnNewtotal_completed.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumnNewtotal_completed.FieldName = "total_completed"
        Me.GridColumnNewtotal_completed.Name = "GridColumnNewtotal_completed"
        Me.GridColumnNewtotal_completed.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "total_completed", "{0:N0}")})
        Me.GridColumnNewtotal_completed.Visible = True
        Me.GridColumnNewtotal_completed.VisibleIndex = 4
        Me.GridColumnNewtotal_completed.Width = 180
        '
        'GridColumnNewProsScan
        '
        Me.GridColumnNewProsScan.Caption = "Scan (%)"
        Me.GridColumnNewProsScan.ColumnEdit = Me.RepositoryItemProgressBarScan
        Me.GridColumnNewProsScan.FieldName = "pros_scan"
        Me.GridColumnNewProsScan.Name = "GridColumnNewProsScan"
        Me.GridColumnNewProsScan.UnboundExpression = "([total_scan] / [total_order]) * 100"
        Me.GridColumnNewProsScan.UnboundType = DevExpress.Data.UnboundColumnType.[Decimal]
        Me.GridColumnNewProsScan.Visible = True
        Me.GridColumnNewProsScan.VisibleIndex = 5
        '
        'RepositoryItemProgressBarScan
        '
        Me.RepositoryItemProgressBarScan.DisplayFormat.FormatString = "{0:n2}%"
        Me.RepositoryItemProgressBarScan.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.RepositoryItemProgressBarScan.Name = "RepositoryItemProgressBarScan"
        Me.RepositoryItemProgressBarScan.PercentView = False
        Me.RepositoryItemProgressBarScan.ShowTitle = True
        '
        'GridColumnNewpros_completed
        '
        Me.GridColumnNewpros_completed.Caption = "Delivered (%)"
        Me.GridColumnNewpros_completed.ColumnEdit = Me.RepositoryItemProgressBarScan
        Me.GridColumnNewpros_completed.FieldName = "pros_completed"
        Me.GridColumnNewpros_completed.Name = "GridColumnNewpros_completed"
        Me.GridColumnNewpros_completed.UnboundExpression = "([total_completed] / [total_order]) * 100"
        Me.GridColumnNewpros_completed.UnboundType = DevExpress.Data.UnboundColumnType.[Decimal]
        Me.GridColumnNewpros_completed.Visible = True
        Me.GridColumnNewpros_completed.VisibleIndex = 6
        '
        'GCFilter
        '
        Me.GCFilter.CaptionLocation = DevExpress.Utils.Locations.Left
        Me.GCFilter.Controls.Add(Me.PanelControl1)
        Me.GCFilter.Controls.Add(Me.CEShowHighlight)
        Me.GCFilter.Controls.Add(Me.BtnView)
        Me.GCFilter.Controls.Add(Me.BHide)
        Me.GCFilter.Dock = System.Windows.Forms.DockStyle.Top
        Me.GCFilter.Location = New System.Drawing.Point(0, 0)
        Me.GCFilter.Name = "GCFilter"
        Me.GCFilter.Size = New System.Drawing.Size(871, 75)
        Me.GCFilter.TabIndex = 4
        '
        'PanelControl1
        '
        Me.PanelControl1.Controls.Add(Me.DEUntil)
        Me.PanelControl1.Controls.Add(Me.CEFindAllProduct)
        Me.PanelControl1.Controls.Add(Me.LabelControl3)
        Me.PanelControl1.Controls.Add(Me.TxtProduct)
        Me.PanelControl1.Controls.Add(Me.LabelControl2)
        Me.PanelControl1.Controls.Add(Me.LabelControl5)
        Me.PanelControl1.Controls.Add(Me.DEFrom)
        Me.PanelControl1.Controls.Add(Me.BtnBrowseProduct)
        Me.PanelControl1.Dock = System.Windows.Forms.DockStyle.Left
        Me.PanelControl1.Location = New System.Drawing.Point(20, 2)
        Me.PanelControl1.Name = "PanelControl1"
        Me.PanelControl1.Size = New System.Drawing.Size(440, 71)
        Me.PanelControl1.TabIndex = 8904
        '
        'DEUntil
        '
        Me.DEUntil.EditValue = Nothing
        Me.DEUntil.Location = New System.Drawing.Point(201, 9)
        Me.DEUntil.Name = "DEUntil"
        Me.DEUntil.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.DEUntil.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.DEUntil.Properties.DisplayFormat.FormatString = "dd MMM yyyy"
        Me.DEUntil.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.DEUntil.Properties.Mask.EditMask = "dd\/MM\/yyyy"
        Me.DEUntil.Size = New System.Drawing.Size(128, 20)
        Me.DEUntil.TabIndex = 8895
        '
        'CEFindAllProduct
        '
        Me.CEFindAllProduct.EditValue = True
        Me.CEFindAllProduct.Location = New System.Drawing.Point(332, 9)
        Me.CEFindAllProduct.Name = "CEFindAllProduct"
        Me.CEFindAllProduct.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CEFindAllProduct.Properties.Appearance.Options.UseFont = True
        Me.CEFindAllProduct.Properties.Caption = "Find All Product"
        Me.CEFindAllProduct.Size = New System.Drawing.Size(98, 19)
        Me.CEFindAllProduct.TabIndex = 8903
        '
        'LabelControl3
        '
        Me.LabelControl3.Location = New System.Drawing.Point(9, 12)
        Me.LabelControl3.Name = "LabelControl3"
        Me.LabelControl3.Size = New System.Drawing.Size(24, 13)
        Me.LabelControl3.TabIndex = 8892
        Me.LabelControl3.Text = "From"
        '
        'TxtProduct
        '
        Me.TxtProduct.EditValue = ""
        Me.TxtProduct.Enabled = False
        Me.TxtProduct.Location = New System.Drawing.Point(57, 35)
        Me.TxtProduct.Name = "TxtProduct"
        Me.TxtProduct.Size = New System.Drawing.Size(336, 20)
        Me.TxtProduct.TabIndex = 8902
        '
        'LabelControl2
        '
        Me.LabelControl2.Location = New System.Drawing.Point(174, 12)
        Me.LabelControl2.Name = "LabelControl2"
        Me.LabelControl2.Size = New System.Drawing.Size(21, 13)
        Me.LabelControl2.TabIndex = 8893
        Me.LabelControl2.Text = "Until"
        '
        'LabelControl5
        '
        Me.LabelControl5.Location = New System.Drawing.Point(9, 38)
        Me.LabelControl5.Name = "LabelControl5"
        Me.LabelControl5.Size = New System.Drawing.Size(37, 13)
        Me.LabelControl5.TabIndex = 8901
        Me.LabelControl5.Text = "Product"
        '
        'DEFrom
        '
        Me.DEFrom.EditValue = Nothing
        Me.DEFrom.Location = New System.Drawing.Point(57, 9)
        Me.DEFrom.Name = "DEFrom"
        Me.DEFrom.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.DEFrom.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.DEFrom.Properties.DisplayFormat.FormatString = "dd MMM yyyy"
        Me.DEFrom.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.DEFrom.Properties.Mask.EditMask = "dd\/MM\/yyyy"
        Me.DEFrom.Size = New System.Drawing.Size(111, 20)
        Me.DEFrom.TabIndex = 8894
        '
        'BtnBrowseProduct
        '
        Me.BtnBrowseProduct.Enabled = False
        Me.BtnBrowseProduct.Image = CType(resources.GetObject("BtnBrowseProduct.Image"), System.Drawing.Image)
        Me.BtnBrowseProduct.Location = New System.Drawing.Point(397, 34)
        Me.BtnBrowseProduct.LookAndFeel.SkinName = "Blue"
        Me.BtnBrowseProduct.Name = "BtnBrowseProduct"
        Me.BtnBrowseProduct.Size = New System.Drawing.Size(26, 20)
        Me.BtnBrowseProduct.TabIndex = 8900
        Me.BtnBrowseProduct.Text = "..."
        '
        'CEShowHighlight
        '
        Me.CEShowHighlight.Enabled = False
        Me.CEShowHighlight.Location = New System.Drawing.Point(541, 27)
        Me.CEShowHighlight.Name = "CEShowHighlight"
        Me.CEShowHighlight.Properties.Caption = "show highlight"
        Me.CEShowHighlight.Size = New System.Drawing.Size(97, 19)
        Me.CEShowHighlight.TabIndex = 8899
        '
        'BtnView
        '
        Me.BtnView.Image = CType(resources.GetObject("BtnView.Image"), System.Drawing.Image)
        Me.BtnView.Location = New System.Drawing.Point(471, 26)
        Me.BtnView.LookAndFeel.SkinName = "Blue"
        Me.BtnView.Name = "BtnView"
        Me.BtnView.Size = New System.Drawing.Size(66, 20)
        Me.BtnView.TabIndex = 8896
        Me.BtnView.Text = "View"
        '
        'BHide
        '
        Me.BHide.ImageIndex = 9
        Me.BHide.Location = New System.Drawing.Point(938, 14)
        Me.BHide.Name = "BHide"
        Me.BHide.Size = New System.Drawing.Size(104, 20)
        Me.BHide.TabIndex = 8898
        Me.BHide.Text = "Hide All Detail"
        Me.BHide.Visible = False
        '
        'XTPAllOrder
        '
        Me.XTPAllOrder.Controls.Add(Me.GCAll)
        Me.XTPAllOrder.Controls.Add(Me.GroupControl1)
        Me.XTPAllOrder.Name = "XTPAllOrder"
        Me.XTPAllOrder.Size = New System.Drawing.Size(871, 461)
        Me.XTPAllOrder.Text = "All Order"
        '
        'GCAll
        '
        Me.GCAll.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCAll.Location = New System.Drawing.Point(0, 71)
        Me.GCAll.MainView = Me.GVAll
        Me.GCAll.Name = "GCAll"
        Me.GCAll.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.RepositoryItemProgressBar1, Me.RepositoryItemProgressBar})
        Me.GCAll.Size = New System.Drawing.Size(871, 390)
        Me.GCAll.TabIndex = 7
        Me.GCAll.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVAll})
        '
        'GVAll
        '
        Me.GVAll.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumnid_sales_order, Me.GridColumnsales_order_number, Me.GridColumnsales_order_gen_reff, Me.GridColumnsales_order_date, Me.GridColumnprepare_status, Me.GridColumnwh, Me.GridColumndestination, Me.GridColumntotal_order, Me.GridColumntotal_scan, Me.GridColumntotal_completed, Me.GridColumnpros_scan, Me.GridColumnpros_del, Me.GridColumnso_status, Me.GridColumnfinal_date, Me.GridColumnfinal_comment, Me.GridColumnAllfinal_by_name})
        Me.GVAll.GridControl = Me.GCAll
        Me.GVAll.GroupSummary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "total_order", Me.GridColumntotal_order, "{0:N0}"), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "total_scan", Me.GridColumntotal_scan, "{0:N0}"), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "total_completed", Me.GridColumntotal_completed, "{0:N0}")})
        Me.GVAll.Name = "GVAll"
        Me.GVAll.OptionsBehavior.ReadOnly = True
        Me.GVAll.OptionsFind.AlwaysVisible = True
        Me.GVAll.OptionsView.ColumnAutoWidth = False
        Me.GVAll.OptionsView.ShowFooter = True
        Me.GVAll.OptionsView.ShowGroupPanel = False
        '
        'GridColumnid_sales_order
        '
        Me.GridColumnid_sales_order.Caption = "Id SO"
        Me.GridColumnid_sales_order.FieldName = "id_sales_order"
        Me.GridColumnid_sales_order.Name = "GridColumnid_sales_order"
        '
        'GridColumnsales_order_number
        '
        Me.GridColumnsales_order_number.Caption = "Order Number"
        Me.GridColumnsales_order_number.FieldName = "sales_order_number"
        Me.GridColumnsales_order_number.Name = "GridColumnsales_order_number"
        Me.GridColumnsales_order_number.Visible = True
        Me.GridColumnsales_order_number.VisibleIndex = 0
        '
        'GridColumnsales_order_gen_reff
        '
        Me.GridColumnsales_order_gen_reff.Caption = "Reff"
        Me.GridColumnsales_order_gen_reff.FieldName = "sales_order_gen_reff"
        Me.GridColumnsales_order_gen_reff.Name = "GridColumnsales_order_gen_reff"
        Me.GridColumnsales_order_gen_reff.Visible = True
        Me.GridColumnsales_order_gen_reff.VisibleIndex = 1
        '
        'GridColumnsales_order_date
        '
        Me.GridColumnsales_order_date.Caption = "Order Date"
        Me.GridColumnsales_order_date.DisplayFormat.FormatString = "dd MMMM yyyy"
        Me.GridColumnsales_order_date.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.GridColumnsales_order_date.FieldName = "sales_order_date"
        Me.GridColumnsales_order_date.Name = "GridColumnsales_order_date"
        Me.GridColumnsales_order_date.Visible = True
        Me.GridColumnsales_order_date.VisibleIndex = 2
        '
        'GridColumnprepare_status
        '
        Me.GridColumnprepare_status.Caption = "Status"
        Me.GridColumnprepare_status.FieldName = "prepare_status"
        Me.GridColumnprepare_status.Name = "GridColumnprepare_status"
        Me.GridColumnprepare_status.Visible = True
        Me.GridColumnprepare_status.VisibleIndex = 11
        '
        'GridColumnwh
        '
        Me.GridColumnwh.Caption = "From"
        Me.GridColumnwh.FieldName = "wh"
        Me.GridColumnwh.Name = "GridColumnwh"
        Me.GridColumnwh.Visible = True
        Me.GridColumnwh.VisibleIndex = 4
        '
        'GridColumndestination
        '
        Me.GridColumndestination.Caption = "To"
        Me.GridColumndestination.FieldName = "destination"
        Me.GridColumndestination.Name = "GridColumndestination"
        Me.GridColumndestination.Visible = True
        Me.GridColumndestination.VisibleIndex = 5
        '
        'GridColumntotal_order
        '
        Me.GridColumntotal_order.Caption = "Order Total"
        Me.GridColumntotal_order.DisplayFormat.FormatString = "N0"
        Me.GridColumntotal_order.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumntotal_order.FieldName = "total_order"
        Me.GridColumntotal_order.Name = "GridColumntotal_order"
        Me.GridColumntotal_order.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "total_order", "{0:N0}")})
        Me.GridColumntotal_order.Visible = True
        Me.GridColumntotal_order.VisibleIndex = 6
        '
        'GridColumntotal_scan
        '
        Me.GridColumntotal_scan.Caption = "Scan Total"
        Me.GridColumntotal_scan.DisplayFormat.FormatString = "N0"
        Me.GridColumntotal_scan.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumntotal_scan.FieldName = "total_scan"
        Me.GridColumntotal_scan.Name = "GridColumntotal_scan"
        Me.GridColumntotal_scan.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "total_scan", "{0:N0}")})
        Me.GridColumntotal_scan.Visible = True
        Me.GridColumntotal_scan.VisibleIndex = 7
        '
        'GridColumntotal_completed
        '
        Me.GridColumntotal_completed.Caption = "Delivered Total"
        Me.GridColumntotal_completed.DisplayFormat.FormatString = "N0"
        Me.GridColumntotal_completed.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumntotal_completed.FieldName = "total_completed"
        Me.GridColumntotal_completed.Name = "GridColumntotal_completed"
        Me.GridColumntotal_completed.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "total_completed", "{0:N0}")})
        Me.GridColumntotal_completed.Visible = True
        Me.GridColumntotal_completed.VisibleIndex = 8
        Me.GridColumntotal_completed.Width = 141
        '
        'GridColumnpros_scan
        '
        Me.GridColumnpros_scan.Caption = "Scan (%)"
        Me.GridColumnpros_scan.ColumnEdit = Me.RepositoryItemProgressBar
        Me.GridColumnpros_scan.FieldName = "pros_scan"
        Me.GridColumnpros_scan.Name = "GridColumnpros_scan"
        Me.GridColumnpros_scan.UnboundExpression = "([total_scan]/[total_order])*100"
        Me.GridColumnpros_scan.UnboundType = DevExpress.Data.UnboundColumnType.[Decimal]
        Me.GridColumnpros_scan.Visible = True
        Me.GridColumnpros_scan.VisibleIndex = 9
        '
        'RepositoryItemProgressBar
        '
        Me.RepositoryItemProgressBar.DisplayFormat.FormatString = "{0:n2}%"
        Me.RepositoryItemProgressBar.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.RepositoryItemProgressBar.Name = "RepositoryItemProgressBar"
        Me.RepositoryItemProgressBar.PercentView = False
        Me.RepositoryItemProgressBar.ShowTitle = True
        '
        'GridColumnpros_del
        '
        Me.GridColumnpros_del.Caption = "Delivered (%)"
        Me.GridColumnpros_del.ColumnEdit = Me.RepositoryItemProgressBar
        Me.GridColumnpros_del.FieldName = "pros_del"
        Me.GridColumnpros_del.Name = "GridColumnpros_del"
        Me.GridColumnpros_del.UnboundExpression = "([total_completed]/[total_order])*100"
        Me.GridColumnpros_del.UnboundType = DevExpress.Data.UnboundColumnType.[Decimal]
        Me.GridColumnpros_del.Visible = True
        Me.GridColumnpros_del.VisibleIndex = 10
        '
        'GridColumnso_status
        '
        Me.GridColumnso_status.Caption = "Category"
        Me.GridColumnso_status.FieldName = "so_status"
        Me.GridColumnso_status.Name = "GridColumnso_status"
        Me.GridColumnso_status.Visible = True
        Me.GridColumnso_status.VisibleIndex = 3
        '
        'GridColumnfinal_date
        '
        Me.GridColumnfinal_date.Caption = "Closed Date"
        Me.GridColumnfinal_date.DisplayFormat.FormatString = "dd MMMM yyyy"
        Me.GridColumnfinal_date.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.GridColumnfinal_date.FieldName = "final_date"
        Me.GridColumnfinal_date.Name = "GridColumnfinal_date"
        Me.GridColumnfinal_date.Visible = True
        Me.GridColumnfinal_date.VisibleIndex = 13
        '
        'GridColumnfinal_comment
        '
        Me.GridColumnfinal_comment.Caption = "Closed Note"
        Me.GridColumnfinal_comment.FieldName = "final_comment"
        Me.GridColumnfinal_comment.Name = "GridColumnfinal_comment"
        Me.GridColumnfinal_comment.Visible = True
        Me.GridColumnfinal_comment.VisibleIndex = 12
        '
        'GridColumnAllfinal_by_name
        '
        Me.GridColumnAllfinal_by_name.Caption = "Closed By"
        Me.GridColumnAllfinal_by_name.FieldName = "final_by_name"
        Me.GridColumnAllfinal_by_name.Name = "GridColumnAllfinal_by_name"
        Me.GridColumnAllfinal_by_name.Visible = True
        Me.GridColumnAllfinal_by_name.VisibleIndex = 14
        '
        'RepositoryItemProgressBar1
        '
        Me.RepositoryItemProgressBar1.Name = "RepositoryItemProgressBar1"
        Me.RepositoryItemProgressBar1.ShowTitle = True
        '
        'GroupControl1
        '
        Me.GroupControl1.CaptionLocation = DevExpress.Utils.Locations.Left
        Me.GroupControl1.Controls.Add(Me.PanelControl2)
        Me.GroupControl1.Controls.Add(Me.BtnViewAll)
        Me.GroupControl1.Controls.Add(Me.SimpleButton2)
        Me.GroupControl1.Dock = System.Windows.Forms.DockStyle.Top
        Me.GroupControl1.Location = New System.Drawing.Point(0, 0)
        Me.GroupControl1.Name = "GroupControl1"
        Me.GroupControl1.Size = New System.Drawing.Size(871, 71)
        Me.GroupControl1.TabIndex = 5
        '
        'PanelControl2
        '
        Me.PanelControl2.Controls.Add(Me.CEFindAllProductSO)
        Me.PanelControl2.Controls.Add(Me.TxtProductSO)
        Me.PanelControl2.Controls.Add(Me.LabelControl8)
        Me.PanelControl2.Controls.Add(Me.DEUntilAll)
        Me.PanelControl2.Controls.Add(Me.DEFromAll)
        Me.PanelControl2.Controls.Add(Me.BtnBrowseProductSO)
        Me.PanelControl2.Controls.Add(Me.LabelControl1)
        Me.PanelControl2.Controls.Add(Me.LabelControl4)
        Me.PanelControl2.Dock = System.Windows.Forms.DockStyle.Left
        Me.PanelControl2.Location = New System.Drawing.Point(20, 2)
        Me.PanelControl2.Name = "PanelControl2"
        Me.PanelControl2.Size = New System.Drawing.Size(440, 67)
        Me.PanelControl2.TabIndex = 8905
        '
        'CEFindAllProductSO
        '
        Me.CEFindAllProductSO.EditValue = True
        Me.CEFindAllProductSO.Location = New System.Drawing.Point(325, 9)
        Me.CEFindAllProductSO.Name = "CEFindAllProductSO"
        Me.CEFindAllProductSO.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CEFindAllProductSO.Properties.Appearance.Options.UseFont = True
        Me.CEFindAllProductSO.Properties.Caption = "Find All Product"
        Me.CEFindAllProductSO.Size = New System.Drawing.Size(98, 19)
        Me.CEFindAllProductSO.TabIndex = 8903
        '
        'TxtProductSO
        '
        Me.TxtProductSO.EditValue = ""
        Me.TxtProductSO.Enabled = False
        Me.TxtProductSO.Location = New System.Drawing.Point(57, 35)
        Me.TxtProductSO.Name = "TxtProductSO"
        Me.TxtProductSO.Size = New System.Drawing.Size(336, 20)
        Me.TxtProductSO.TabIndex = 8902
        '
        'LabelControl8
        '
        Me.LabelControl8.Location = New System.Drawing.Point(9, 38)
        Me.LabelControl8.Name = "LabelControl8"
        Me.LabelControl8.Size = New System.Drawing.Size(37, 13)
        Me.LabelControl8.TabIndex = 8901
        Me.LabelControl8.Text = "Product"
        '
        'DEUntilAll
        '
        Me.DEUntilAll.EditValue = Nothing
        Me.DEUntilAll.Location = New System.Drawing.Point(201, 9)
        Me.DEUntilAll.Name = "DEUntilAll"
        Me.DEUntilAll.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.DEUntilAll.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.DEUntilAll.Properties.DisplayFormat.FormatString = "dd MMM yyyy"
        Me.DEUntilAll.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.DEUntilAll.Properties.Mask.EditMask = "dd\/MM\/yyyy"
        Me.DEUntilAll.Size = New System.Drawing.Size(118, 20)
        Me.DEUntilAll.TabIndex = 8895
        '
        'DEFromAll
        '
        Me.DEFromAll.EditValue = Nothing
        Me.DEFromAll.Location = New System.Drawing.Point(57, 9)
        Me.DEFromAll.Name = "DEFromAll"
        Me.DEFromAll.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.DEFromAll.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.DEFromAll.Properties.DisplayFormat.FormatString = "dd MMM yyyy"
        Me.DEFromAll.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.DEFromAll.Properties.Mask.EditMask = "dd\/MM\/yyyy"
        Me.DEFromAll.Size = New System.Drawing.Size(111, 20)
        Me.DEFromAll.TabIndex = 8894
        '
        'BtnBrowseProductSO
        '
        Me.BtnBrowseProductSO.Enabled = False
        Me.BtnBrowseProductSO.Image = CType(resources.GetObject("BtnBrowseProductSO.Image"), System.Drawing.Image)
        Me.BtnBrowseProductSO.Location = New System.Drawing.Point(397, 34)
        Me.BtnBrowseProductSO.LookAndFeel.SkinName = "Blue"
        Me.BtnBrowseProductSO.Name = "BtnBrowseProductSO"
        Me.BtnBrowseProductSO.Size = New System.Drawing.Size(26, 20)
        Me.BtnBrowseProductSO.TabIndex = 8900
        Me.BtnBrowseProductSO.Text = "..."
        '
        'LabelControl1
        '
        Me.LabelControl1.Location = New System.Drawing.Point(174, 12)
        Me.LabelControl1.Name = "LabelControl1"
        Me.LabelControl1.Size = New System.Drawing.Size(21, 13)
        Me.LabelControl1.TabIndex = 8893
        Me.LabelControl1.Text = "Until"
        '
        'LabelControl4
        '
        Me.LabelControl4.Location = New System.Drawing.Point(9, 12)
        Me.LabelControl4.Name = "LabelControl4"
        Me.LabelControl4.Size = New System.Drawing.Size(24, 13)
        Me.LabelControl4.TabIndex = 8892
        Me.LabelControl4.Text = "From"
        '
        'BtnViewAll
        '
        Me.BtnViewAll.Image = CType(resources.GetObject("BtnViewAll.Image"), System.Drawing.Image)
        Me.BtnViewAll.Location = New System.Drawing.Point(471, 23)
        Me.BtnViewAll.LookAndFeel.SkinName = "Blue"
        Me.BtnViewAll.Name = "BtnViewAll"
        Me.BtnViewAll.Size = New System.Drawing.Size(75, 20)
        Me.BtnViewAll.TabIndex = 8896
        Me.BtnViewAll.Text = "View"
        '
        'SimpleButton2
        '
        Me.SimpleButton2.ImageIndex = 9
        Me.SimpleButton2.Location = New System.Drawing.Point(938, 14)
        Me.SimpleButton2.Name = "SimpleButton2"
        Me.SimpleButton2.Size = New System.Drawing.Size(104, 20)
        Me.SimpleButton2.TabIndex = 8898
        Me.SimpleButton2.Text = "Hide All Detail"
        Me.SimpleButton2.Visible = False
        '
        'FormSalesOrderReport
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(877, 489)
        Me.Controls.Add(Me.XTCSO)
        Me.Name = "FormSalesOrderReport"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Prepare Order Monitoring"
        CType(Me.XTCSO, System.ComponentModel.ISupportInitialize).EndInit()
        Me.XTCSO.ResumeLayout(False)
        Me.XTPNew.ResumeLayout(False)
        CType(Me.GCNew, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVNew, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemProgressBarScan, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GCFilter, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GCFilter.ResumeLayout(False)
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl1.ResumeLayout(False)
        Me.PanelControl1.PerformLayout()
        CType(Me.DEUntil.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DEUntil.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CEFindAllProduct.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtProduct.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DEFrom.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DEFrom.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CEShowHighlight.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.XTPAllOrder.ResumeLayout(False)
        CType(Me.GCAll, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVAll, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemProgressBar, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemProgressBar1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GroupControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupControl1.ResumeLayout(False)
        CType(Me.PanelControl2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl2.ResumeLayout(False)
        Me.PanelControl2.PerformLayout()
        CType(Me.CEFindAllProductSO.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtProductSO.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DEUntilAll.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DEUntilAll.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DEFromAll.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DEFromAll.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents XTCSO As DevExpress.XtraTab.XtraTabControl
    Friend WithEvents XTPNew As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents XTPAllOrder As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents GCNew As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVNew As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GCFilter As DevExpress.XtraEditors.GroupControl
    Friend WithEvents BtnView As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BHide As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents DEUntil As DevExpress.XtraEditors.DateEdit
    Friend WithEvents DEFrom As DevExpress.XtraEditors.DateEdit
    Friend WithEvents LabelControl2 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl3 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents GridColumnNewid_sales_order_gen As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnNewid_so_status As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnNewsales_order_gen_reff As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnNewsales_order_gen_date As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnNewsales_order_gen_note As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnNewtotal_order As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnNew As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnNewtotal_completed As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnNewProsScan As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents RepositoryItemProgressBarScan As DevExpress.XtraEditors.Repository.RepositoryItemProgressBar
    Friend WithEvents GridColumnNewpros_completed As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GroupControl1 As DevExpress.XtraEditors.GroupControl
    Friend WithEvents BtnViewAll As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents SimpleButton2 As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents DEUntilAll As DevExpress.XtraEditors.DateEdit
    Friend WithEvents DEFromAll As DevExpress.XtraEditors.DateEdit
    Friend WithEvents LabelControl1 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl4 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents GCAll As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVAll As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumnid_sales_order As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnsales_order_number As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnsales_order_date As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnprepare_status As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnwh As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumndestination As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumntotal_order As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumntotal_scan As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumntotal_completed As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnpros_scan As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents RepositoryItemProgressBar As DevExpress.XtraEditors.Repository.RepositoryItemProgressBar
    Friend WithEvents GridColumnpros_del As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnso_status As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents RepositoryItemProgressBar1 As DevExpress.XtraEditors.Repository.RepositoryItemProgressBar
    Friend WithEvents GridColumnsales_order_gen_reff As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnfinal_date As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnfinal_comment As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnAllfinal_by_name As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents CEShowHighlight As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents PanelControl1 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents CEFindAllProduct As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents TxtProduct As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl5 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents BtnBrowseProduct As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents PanelControl2 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents CEFindAllProductSO As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents TxtProductSO As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl8 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents BtnBrowseProductSO As DevExpress.XtraEditors.SimpleButton
End Class
