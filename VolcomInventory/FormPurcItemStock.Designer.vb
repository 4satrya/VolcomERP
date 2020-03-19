<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormPurcItemStock
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormPurcItemStock))
        Me.XTCStock = New DevExpress.XtraTab.XtraTabControl()
        Me.XTPSOH = New DevExpress.XtraTab.XtraTabPage()
        Me.GCSOH = New DevExpress.XtraGrid.GridControl()
        Me.GVSOH = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumnIdItem = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnItemDesc = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnIdItemCat = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnItemCat = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnQty = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnAmount = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnIdDept = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnDept = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnValue = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.PCNav = New DevExpress.XtraEditors.PanelControl()
        Me.BStockFisik = New DevExpress.XtraEditors.SimpleButton()
        Me.BtnView = New DevExpress.XtraEditors.SimpleButton()
        Me.LabelControl2 = New DevExpress.XtraEditors.LabelControl()
        Me.DESOHUntil = New DevExpress.XtraEditors.DateEdit()
        Me.LECat = New DevExpress.XtraEditors.LookUpEdit()
        Me.LEDeptSum = New DevExpress.XtraEditors.LookUpEdit()
        Me.LabelControl1 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl6 = New DevExpress.XtraEditors.LabelControl()
        Me.XTPStockCard = New DevExpress.XtraTab.XtraTabPage()
        Me.GCSC = New DevExpress.XtraGrid.GridControl()
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.ViewDocumentToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.GVSC = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumnIdReport = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnIdStorageCategory = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnRMT = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnTransNumber = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnStorageDate = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnQtySC = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnBalQty = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnStorageCat = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumntype = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnStatus = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnDeptSC = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.PanelControl1 = New DevExpress.XtraEditors.PanelControl()
        Me.BStockCardFisik = New DevExpress.XtraEditors.SimpleButton()
        Me.SLEITem = New DevExpress.XtraEditors.SearchLookUpEdit()
        Me.SearchLookUpEdit1View = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumnItemId = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnDesc = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnCat = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.DEUntilSC = New DevExpress.XtraEditors.DateEdit()
        Me.LabelControl7 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl4 = New DevExpress.XtraEditors.LabelControl()
        Me.BtnViewSC = New DevExpress.XtraEditors.SimpleButton()
        Me.LabelControl3 = New DevExpress.XtraEditors.LabelControl()
        Me.DEFromSC = New DevExpress.XtraEditors.DateEdit()
        Me.LEDeptSC = New DevExpress.XtraEditors.LookUpEdit()
        Me.LabelControl5 = New DevExpress.XtraEditors.LabelControl()
        Me.XTPUsage = New DevExpress.XtraTab.XtraTabPage()
        Me.PanelControl2 = New DevExpress.XtraEditors.PanelControl()
        Me.GCPemakaian = New DevExpress.XtraGrid.GridControl()
        Me.GVPemakaian = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridView()
        Me.GridColumn1 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.GridColumn2 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.GridColumn3 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.GridColumn4 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.GridColumn5 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.GridColumn6 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.GridColumn7 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.GridColumn8 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.GridColumn9 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.GridColumn10 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.GridColumn11 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumn1 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumn2 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumn3 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumn4 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.GridBand1 = New DevExpress.XtraGrid.Views.BandedGrid.GridBand()
        Me.gridBand2 = New DevExpress.XtraGrid.Views.BandedGrid.GridBand()
        Me.gridBand3 = New DevExpress.XtraGrid.Views.BandedGrid.GridBand()
        Me.gridBand4 = New DevExpress.XtraGrid.Views.BandedGrid.GridBand()
        Me.gridBand5 = New DevExpress.XtraGrid.Views.BandedGrid.GridBand()
        Me.DEStart = New DevExpress.XtraEditors.DateEdit()
        Me.LabelControl8 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl9 = New DevExpress.XtraEditors.LabelControl()
        Me.DEUntil = New DevExpress.XtraEditors.DateEdit()
        Me.BView = New DevExpress.XtraEditors.SimpleButton()
        Me.BPrint = New DevExpress.XtraEditors.SimpleButton()
        Me.LECatPemakaian = New DevExpress.XtraEditors.LookUpEdit()
        Me.LabelControl10 = New DevExpress.XtraEditors.LabelControl()
        CType(Me.XTCStock, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.XTCStock.SuspendLayout()
        Me.XTPSOH.SuspendLayout()
        CType(Me.GCSOH, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVSOH, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PCNav, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PCNav.SuspendLayout()
        CType(Me.DESOHUntil.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DESOHUntil.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LECat.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LEDeptSum.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.XTPStockCard.SuspendLayout()
        CType(Me.GCSC, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ContextMenuStrip1.SuspendLayout()
        CType(Me.GVSC, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl1.SuspendLayout()
        CType(Me.SLEITem.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SearchLookUpEdit1View, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DEUntilSC.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DEUntilSC.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DEFromSC.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DEFromSC.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LEDeptSC.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.XTPUsage.SuspendLayout()
        CType(Me.PanelControl2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl2.SuspendLayout()
        CType(Me.GCPemakaian, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVPemakaian, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DEStart.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DEStart.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DEUntil.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DEUntil.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LECatPemakaian.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'XTCStock
        '
        Me.XTCStock.Dock = System.Windows.Forms.DockStyle.Fill
        Me.XTCStock.HeaderLocation = DevExpress.XtraTab.TabHeaderLocation.Bottom
        Me.XTCStock.Location = New System.Drawing.Point(0, 0)
        Me.XTCStock.Name = "XTCStock"
        Me.XTCStock.SelectedTabPage = Me.XTPSOH
        Me.XTCStock.Size = New System.Drawing.Size(967, 592)
        Me.XTCStock.TabIndex = 0
        Me.XTCStock.TabPages.AddRange(New DevExpress.XtraTab.XtraTabPage() {Me.XTPSOH, Me.XTPStockCard, Me.XTPUsage})
        '
        'XTPSOH
        '
        Me.XTPSOH.Controls.Add(Me.GCSOH)
        Me.XTPSOH.Controls.Add(Me.PCNav)
        Me.XTPSOH.Name = "XTPSOH"
        Me.XTPSOH.Size = New System.Drawing.Size(961, 564)
        Me.XTPSOH.Text = "Stock On Hand"
        '
        'GCSOH
        '
        Me.GCSOH.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCSOH.Location = New System.Drawing.Point(0, 48)
        Me.GCSOH.MainView = Me.GVSOH
        Me.GCSOH.Name = "GCSOH"
        Me.GCSOH.Size = New System.Drawing.Size(961, 516)
        Me.GCSOH.TabIndex = 1
        Me.GCSOH.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVSOH})
        '
        'GVSOH
        '
        Me.GVSOH.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumnIdItem, Me.GridColumnItemDesc, Me.GridColumnIdItemCat, Me.GridColumnItemCat, Me.GridColumnQty, Me.GridColumnAmount, Me.GridColumnIdDept, Me.GridColumnDept, Me.GridColumnValue})
        Me.GVSOH.GridControl = Me.GCSOH
        Me.GVSOH.GroupCount = 1
        Me.GVSOH.GroupSummary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "qty", Me.GridColumnQty, "{0:N2}"), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "amount", Me.GridColumnAmount, "{0:N2}")})
        Me.GVSOH.Name = "GVSOH"
        Me.GVSOH.OptionsBehavior.AutoExpandAllGroups = True
        Me.GVSOH.OptionsBehavior.Editable = False
        Me.GVSOH.OptionsView.ShowFooter = True
        Me.GVSOH.OptionsView.ShowGroupPanel = False
        Me.GVSOH.SortInfo.AddRange(New DevExpress.XtraGrid.Columns.GridColumnSortInfo() {New DevExpress.XtraGrid.Columns.GridColumnSortInfo(Me.GridColumnDept, DevExpress.Data.ColumnSortOrder.Ascending)})
        '
        'GridColumnIdItem
        '
        Me.GridColumnIdItem.Caption = "Id Item"
        Me.GridColumnIdItem.FieldName = "id_item"
        Me.GridColumnIdItem.Name = "GridColumnIdItem"
        '
        'GridColumnItemDesc
        '
        Me.GridColumnItemDesc.Caption = "Description"
        Me.GridColumnItemDesc.FieldName = "item_desc"
        Me.GridColumnItemDesc.Name = "GridColumnItemDesc"
        Me.GridColumnItemDesc.Visible = True
        Me.GridColumnItemDesc.VisibleIndex = 0
        '
        'GridColumnIdItemCat
        '
        Me.GridColumnIdItemCat.Caption = "Id Cat"
        Me.GridColumnIdItemCat.FieldName = "id_item_cat"
        Me.GridColumnIdItemCat.Name = "GridColumnIdItemCat"
        '
        'GridColumnItemCat
        '
        Me.GridColumnItemCat.Caption = "Category"
        Me.GridColumnItemCat.FieldName = "item_cat"
        Me.GridColumnItemCat.Name = "GridColumnItemCat"
        Me.GridColumnItemCat.Visible = True
        Me.GridColumnItemCat.VisibleIndex = 1
        '
        'GridColumnQty
        '
        Me.GridColumnQty.Caption = "Qty"
        Me.GridColumnQty.DisplayFormat.FormatString = "N2"
        Me.GridColumnQty.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumnQty.FieldName = "qty"
        Me.GridColumnQty.Name = "GridColumnQty"
        Me.GridColumnQty.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "qty", "{0:N2}")})
        Me.GridColumnQty.Visible = True
        Me.GridColumnQty.VisibleIndex = 2
        '
        'GridColumnAmount
        '
        Me.GridColumnAmount.Caption = "Amount"
        Me.GridColumnAmount.DisplayFormat.FormatString = "N2"
        Me.GridColumnAmount.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumnAmount.FieldName = "amount"
        Me.GridColumnAmount.Name = "GridColumnAmount"
        Me.GridColumnAmount.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "amount", "{0:N2}")})
        Me.GridColumnAmount.UnboundExpression = "[qty] * [value]"
        Me.GridColumnAmount.UnboundType = DevExpress.Data.UnboundColumnType.[Decimal]
        '
        'GridColumnIdDept
        '
        Me.GridColumnIdDept.Caption = "Id Departement"
        Me.GridColumnIdDept.FieldName = "id_departement"
        Me.GridColumnIdDept.Name = "GridColumnIdDept"
        '
        'GridColumnDept
        '
        Me.GridColumnDept.Caption = "Departement"
        Me.GridColumnDept.FieldName = "departement"
        Me.GridColumnDept.Name = "GridColumnDept"
        Me.GridColumnDept.Visible = True
        Me.GridColumnDept.VisibleIndex = 0
        '
        'GridColumnValue
        '
        Me.GridColumnValue.Caption = "Cost"
        Me.GridColumnValue.DisplayFormat.FormatString = "N2"
        Me.GridColumnValue.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumnValue.FieldName = "value"
        Me.GridColumnValue.Name = "GridColumnValue"
        '
        'PCNav
        '
        Me.PCNav.Controls.Add(Me.BStockFisik)
        Me.PCNav.Controls.Add(Me.BtnView)
        Me.PCNav.Controls.Add(Me.LabelControl2)
        Me.PCNav.Controls.Add(Me.DESOHUntil)
        Me.PCNav.Controls.Add(Me.LECat)
        Me.PCNav.Controls.Add(Me.LEDeptSum)
        Me.PCNav.Controls.Add(Me.LabelControl1)
        Me.PCNav.Controls.Add(Me.LabelControl6)
        Me.PCNav.Dock = System.Windows.Forms.DockStyle.Top
        Me.PCNav.Location = New System.Drawing.Point(0, 0)
        Me.PCNav.Name = "PCNav"
        Me.PCNav.Size = New System.Drawing.Size(961, 48)
        Me.PCNav.TabIndex = 0
        '
        'BStockFisik
        '
        Me.BStockFisik.Image = CType(resources.GetObject("BStockFisik.Image"), System.Drawing.Image)
        Me.BStockFisik.Location = New System.Drawing.Point(786, 12)
        Me.BStockFisik.Name = "BStockFisik"
        Me.BStockFisik.Size = New System.Drawing.Size(91, 23)
        Me.BStockFisik.TabIndex = 25
        Me.BStockFisik.Text = "Stock Fisik"
        '
        'BtnView
        '
        Me.BtnView.Image = CType(resources.GetObject("BtnView.Image"), System.Drawing.Image)
        Me.BtnView.Location = New System.Drawing.Point(705, 12)
        Me.BtnView.Name = "BtnView"
        Me.BtnView.Size = New System.Drawing.Size(75, 23)
        Me.BtnView.TabIndex = 23
        Me.BtnView.Text = "View"
        '
        'LabelControl2
        '
        Me.LabelControl2.Location = New System.Drawing.Point(500, 17)
        Me.LabelControl2.Name = "LabelControl2"
        Me.LabelControl2.Size = New System.Drawing.Size(21, 13)
        Me.LabelControl2.TabIndex = 24
        Me.LabelControl2.Text = "Until"
        '
        'DESOHUntil
        '
        Me.DESOHUntil.EditValue = Nothing
        Me.DESOHUntil.Location = New System.Drawing.Point(527, 14)
        Me.DESOHUntil.Name = "DESOHUntil"
        Me.DESOHUntil.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.DESOHUntil.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.DESOHUntil.Properties.DisplayFormat.FormatString = "dd\/MM\/yyyy"
        Me.DESOHUntil.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.DESOHUntil.Properties.Mask.EditMask = "dd\/MM\/yyyy"
        Me.DESOHUntil.Size = New System.Drawing.Size(172, 20)
        Me.DESOHUntil.TabIndex = 23
        '
        'LECat
        '
        Me.LECat.Location = New System.Drawing.Point(319, 14)
        Me.LECat.Name = "LECat"
        Me.LECat.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.LECat.Properties.Columns.AddRange(New DevExpress.XtraEditors.Controls.LookUpColumnInfo() {New DevExpress.XtraEditors.Controls.LookUpColumnInfo("id_item_cat", "Id", 20, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("item_cat", "Category")})
        Me.LECat.Size = New System.Drawing.Size(175, 20)
        Me.LECat.TabIndex = 22
        '
        'LEDeptSum
        '
        Me.LEDeptSum.Location = New System.Drawing.Point(85, 14)
        Me.LEDeptSum.Name = "LEDeptSum"
        Me.LEDeptSum.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.LEDeptSum.Properties.Columns.AddRange(New DevExpress.XtraEditors.Controls.LookUpColumnInfo() {New DevExpress.XtraEditors.Controls.LookUpColumnInfo("id_departement", "Id Departement", 20, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("departement", "Departemen")})
        Me.LEDeptSum.Size = New System.Drawing.Size(175, 20)
        Me.LEDeptSum.TabIndex = 19
        '
        'LabelControl1
        '
        Me.LabelControl1.Location = New System.Drawing.Point(268, 17)
        Me.LabelControl1.Name = "LabelControl1"
        Me.LabelControl1.Size = New System.Drawing.Size(45, 13)
        Me.LabelControl1.TabIndex = 21
        Me.LabelControl1.Text = "Category"
        '
        'LabelControl6
        '
        Me.LabelControl6.Location = New System.Drawing.Point(16, 17)
        Me.LabelControl6.Name = "LabelControl6"
        Me.LabelControl6.Size = New System.Drawing.Size(63, 13)
        Me.LabelControl6.TabIndex = 18
        Me.LabelControl6.Text = "Departement"
        '
        'XTPStockCard
        '
        Me.XTPStockCard.Controls.Add(Me.GCSC)
        Me.XTPStockCard.Controls.Add(Me.PanelControl1)
        Me.XTPStockCard.Name = "XTPStockCard"
        Me.XTPStockCard.Size = New System.Drawing.Size(961, 564)
        Me.XTPStockCard.Text = "Stock Card"
        '
        'GCSC
        '
        Me.GCSC.ContextMenuStrip = Me.ContextMenuStrip1
        Me.GCSC.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCSC.Location = New System.Drawing.Point(0, 50)
        Me.GCSC.MainView = Me.GVSC
        Me.GCSC.Name = "GCSC"
        Me.GCSC.Size = New System.Drawing.Size(961, 514)
        Me.GCSC.TabIndex = 2
        Me.GCSC.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVSC})
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ViewDocumentToolStripMenuItem})
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(159, 26)
        '
        'ViewDocumentToolStripMenuItem
        '
        Me.ViewDocumentToolStripMenuItem.Name = "ViewDocumentToolStripMenuItem"
        Me.ViewDocumentToolStripMenuItem.Size = New System.Drawing.Size(158, 22)
        Me.ViewDocumentToolStripMenuItem.Text = "View Document"
        '
        'GVSC
        '
        Me.GVSC.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumnIdReport, Me.GridColumnIdStorageCategory, Me.GridColumnRMT, Me.GridColumnTransNumber, Me.GridColumnStorageDate, Me.GridColumnQtySC, Me.GridColumnBalQty, Me.GridColumnStorageCat, Me.GridColumntype, Me.GridColumnStatus, Me.GridColumnDeptSC})
        Me.GVSC.GridControl = Me.GCSC
        Me.GVSC.Name = "GVSC"
        Me.GVSC.OptionsBehavior.AutoExpandAllGroups = True
        Me.GVSC.OptionsBehavior.Editable = False
        Me.GVSC.OptionsCustomization.AllowSort = False
        Me.GVSC.OptionsView.ShowGroupPanel = False
        '
        'GridColumnIdReport
        '
        Me.GridColumnIdReport.Caption = "Id Report"
        Me.GridColumnIdReport.FieldName = "id_report"
        Me.GridColumnIdReport.Name = "GridColumnIdReport"
        '
        'GridColumnIdStorageCategory
        '
        Me.GridColumnIdStorageCategory.Caption = "Id Storage Category"
        Me.GridColumnIdStorageCategory.FieldName = "id_storage_category"
        Me.GridColumnIdStorageCategory.Name = "GridColumnIdStorageCategory"
        '
        'GridColumnRMT
        '
        Me.GridColumnRMT.Caption = "RMT"
        Me.GridColumnRMT.FieldName = "report_mark_type"
        Me.GridColumnRMT.Name = "GridColumnRMT"
        '
        'GridColumnTransNumber
        '
        Me.GridColumnTransNumber.Caption = "Transaction Number"
        Me.GridColumnTransNumber.FieldName = "trans_number"
        Me.GridColumnTransNumber.Name = "GridColumnTransNumber"
        Me.GridColumnTransNumber.Visible = True
        Me.GridColumnTransNumber.VisibleIndex = 2
        '
        'GridColumnStorageDate
        '
        Me.GridColumnStorageDate.Caption = "Time"
        Me.GridColumnStorageDate.DisplayFormat.FormatString = "dd MMM yyyy HH:mm"
        Me.GridColumnStorageDate.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.GridColumnStorageDate.FieldName = "storage_date"
        Me.GridColumnStorageDate.Name = "GridColumnStorageDate"
        Me.GridColumnStorageDate.Visible = True
        Me.GridColumnStorageDate.VisibleIndex = 4
        '
        'GridColumnQtySC
        '
        Me.GridColumnQtySC.Caption = "Qty"
        Me.GridColumnQtySC.DisplayFormat.FormatString = "N2"
        Me.GridColumnQtySC.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumnQtySC.FieldName = "qty"
        Me.GridColumnQtySC.Name = "GridColumnQtySC"
        Me.GridColumnQtySC.Visible = True
        Me.GridColumnQtySC.VisibleIndex = 5
        '
        'GridColumnBalQty
        '
        Me.GridColumnBalQty.Caption = "Balance"
        Me.GridColumnBalQty.DisplayFormat.FormatString = "N2"
        Me.GridColumnBalQty.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumnBalQty.FieldName = "bal_qty"
        Me.GridColumnBalQty.Name = "GridColumnBalQty"
        Me.GridColumnBalQty.Visible = True
        Me.GridColumnBalQty.VisibleIndex = 6
        '
        'GridColumnStorageCat
        '
        Me.GridColumnStorageCat.Caption = "Movement"
        Me.GridColumnStorageCat.FieldName = "storage_category"
        Me.GridColumnStorageCat.Name = "GridColumnStorageCat"
        Me.GridColumnStorageCat.Visible = True
        Me.GridColumnStorageCat.VisibleIndex = 7
        '
        'GridColumntype
        '
        Me.GridColumntype.Caption = "Transaction Type"
        Me.GridColumntype.FieldName = "type"
        Me.GridColumntype.Name = "GridColumntype"
        Me.GridColumntype.Visible = True
        Me.GridColumntype.VisibleIndex = 1
        '
        'GridColumnStatus
        '
        Me.GridColumnStatus.Caption = "Transaction Status"
        Me.GridColumnStatus.FieldName = "status"
        Me.GridColumnStatus.Name = "GridColumnStatus"
        Me.GridColumnStatus.Visible = True
        Me.GridColumnStatus.VisibleIndex = 3
        '
        'GridColumnDeptSC
        '
        Me.GridColumnDeptSC.Caption = "Department"
        Me.GridColumnDeptSC.FieldName = "departement"
        Me.GridColumnDeptSC.Name = "GridColumnDeptSC"
        Me.GridColumnDeptSC.Visible = True
        Me.GridColumnDeptSC.VisibleIndex = 0
        '
        'PanelControl1
        '
        Me.PanelControl1.Controls.Add(Me.BStockCardFisik)
        Me.PanelControl1.Controls.Add(Me.SLEITem)
        Me.PanelControl1.Controls.Add(Me.DEUntilSC)
        Me.PanelControl1.Controls.Add(Me.LabelControl7)
        Me.PanelControl1.Controls.Add(Me.LabelControl4)
        Me.PanelControl1.Controls.Add(Me.BtnViewSC)
        Me.PanelControl1.Controls.Add(Me.LabelControl3)
        Me.PanelControl1.Controls.Add(Me.DEFromSC)
        Me.PanelControl1.Controls.Add(Me.LEDeptSC)
        Me.PanelControl1.Controls.Add(Me.LabelControl5)
        Me.PanelControl1.Dock = System.Windows.Forms.DockStyle.Top
        Me.PanelControl1.Location = New System.Drawing.Point(0, 0)
        Me.PanelControl1.Name = "PanelControl1"
        Me.PanelControl1.Size = New System.Drawing.Size(961, 50)
        Me.PanelControl1.TabIndex = 1
        '
        'BStockCardFisik
        '
        Me.BStockCardFisik.Image = CType(resources.GetObject("BStockCardFisik.Image"), System.Drawing.Image)
        Me.BStockCardFisik.Location = New System.Drawing.Point(846, 13)
        Me.BStockCardFisik.Name = "BStockCardFisik"
        Me.BStockCardFisik.Size = New System.Drawing.Size(83, 23)
        Me.BStockCardFisik.TabIndex = 29
        Me.BStockCardFisik.Text = "Stock Fisik"
        '
        'SLEITem
        '
        Me.SLEITem.Location = New System.Drawing.Point(295, 15)
        Me.SLEITem.Name = "SLEITem"
        Me.SLEITem.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.SLEITem.Properties.ShowClearButton = False
        Me.SLEITem.Properties.View = Me.SearchLookUpEdit1View
        Me.SLEITem.Size = New System.Drawing.Size(177, 20)
        Me.SLEITem.TabIndex = 3
        '
        'SearchLookUpEdit1View
        '
        Me.SearchLookUpEdit1View.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumnItemId, Me.GridColumnDesc, Me.GridColumnCat})
        Me.SearchLookUpEdit1View.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
        Me.SearchLookUpEdit1View.Name = "SearchLookUpEdit1View"
        Me.SearchLookUpEdit1View.OptionsSelection.EnableAppearanceFocusedCell = False
        Me.SearchLookUpEdit1View.OptionsView.ShowGroupPanel = False
        '
        'GridColumnItemId
        '
        Me.GridColumnItemId.Caption = "id item"
        Me.GridColumnItemId.FieldName = "id_item"
        Me.GridColumnItemId.Name = "GridColumnItemId"
        '
        'GridColumnDesc
        '
        Me.GridColumnDesc.Caption = "Description"
        Me.GridColumnDesc.FieldName = "item_desc"
        Me.GridColumnDesc.Name = "GridColumnDesc"
        Me.GridColumnDesc.Visible = True
        Me.GridColumnDesc.VisibleIndex = 0
        '
        'GridColumnCat
        '
        Me.GridColumnCat.Caption = "Category"
        Me.GridColumnCat.FieldName = "item_cat"
        Me.GridColumnCat.Name = "GridColumnCat"
        Me.GridColumnCat.Visible = True
        Me.GridColumnCat.VisibleIndex = 1
        '
        'DEUntilSC
        '
        Me.DEUntilSC.EditValue = Nothing
        Me.DEUntilSC.Location = New System.Drawing.Point(649, 15)
        Me.DEUntilSC.Name = "DEUntilSC"
        Me.DEUntilSC.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.DEUntilSC.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.DEUntilSC.Properties.DisplayFormat.FormatString = "dd\/MM\/yyyy"
        Me.DEUntilSC.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.DEUntilSC.Properties.Mask.EditMask = "dd\/MM\/yyyy"
        Me.DEUntilSC.Size = New System.Drawing.Size(110, 20)
        Me.DEUntilSC.TabIndex = 28
        '
        'LabelControl7
        '
        Me.LabelControl7.Location = New System.Drawing.Point(478, 18)
        Me.LabelControl7.Name = "LabelControl7"
        Me.LabelControl7.Size = New System.Drawing.Size(24, 13)
        Me.LabelControl7.TabIndex = 27
        Me.LabelControl7.Text = "From"
        '
        'LabelControl4
        '
        Me.LabelControl4.Location = New System.Drawing.Point(267, 18)
        Me.LabelControl4.Name = "LabelControl4"
        Me.LabelControl4.Size = New System.Drawing.Size(22, 13)
        Me.LabelControl4.TabIndex = 25
        Me.LabelControl4.Text = "Item"
        '
        'BtnViewSC
        '
        Me.BtnViewSC.Image = CType(resources.GetObject("BtnViewSC.Image"), System.Drawing.Image)
        Me.BtnViewSC.Location = New System.Drawing.Point(765, 13)
        Me.BtnViewSC.Name = "BtnViewSC"
        Me.BtnViewSC.Size = New System.Drawing.Size(75, 23)
        Me.BtnViewSC.TabIndex = 23
        Me.BtnViewSC.Text = "View"
        '
        'LabelControl3
        '
        Me.LabelControl3.Location = New System.Drawing.Point(622, 18)
        Me.LabelControl3.Name = "LabelControl3"
        Me.LabelControl3.Size = New System.Drawing.Size(21, 13)
        Me.LabelControl3.TabIndex = 24
        Me.LabelControl3.Text = "Until"
        '
        'DEFromSC
        '
        Me.DEFromSC.EditValue = Nothing
        Me.DEFromSC.Location = New System.Drawing.Point(506, 15)
        Me.DEFromSC.Name = "DEFromSC"
        Me.DEFromSC.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.DEFromSC.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.DEFromSC.Properties.DisplayFormat.FormatString = "dd\/MM\/yyyy"
        Me.DEFromSC.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.DEFromSC.Properties.Mask.EditMask = "dd\/MM\/yyyy"
        Me.DEFromSC.Size = New System.Drawing.Size(110, 20)
        Me.DEFromSC.TabIndex = 23
        '
        'LEDeptSC
        '
        Me.LEDeptSC.Location = New System.Drawing.Point(84, 15)
        Me.LEDeptSC.Name = "LEDeptSC"
        Me.LEDeptSC.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.LEDeptSC.Properties.Columns.AddRange(New DevExpress.XtraEditors.Controls.LookUpColumnInfo() {New DevExpress.XtraEditors.Controls.LookUpColumnInfo("id_departement", "Id Departement", 20, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("departement", "Departemen")})
        Me.LEDeptSC.Size = New System.Drawing.Size(175, 20)
        Me.LEDeptSC.TabIndex = 19
        '
        'LabelControl5
        '
        Me.LabelControl5.Location = New System.Drawing.Point(15, 18)
        Me.LabelControl5.Name = "LabelControl5"
        Me.LabelControl5.Size = New System.Drawing.Size(63, 13)
        Me.LabelControl5.TabIndex = 18
        Me.LabelControl5.Text = "Departement"
        '
        'XTPUsage
        '
        Me.XTPUsage.Controls.Add(Me.GCPemakaian)
        Me.XTPUsage.Controls.Add(Me.PanelControl2)
        Me.XTPUsage.Name = "XTPUsage"
        Me.XTPUsage.Size = New System.Drawing.Size(961, 564)
        Me.XTPUsage.Text = "Report Pemakaian"
        '
        'PanelControl2
        '
        Me.PanelControl2.Controls.Add(Me.LECatPemakaian)
        Me.PanelControl2.Controls.Add(Me.LabelControl10)
        Me.PanelControl2.Controls.Add(Me.BPrint)
        Me.PanelControl2.Controls.Add(Me.BView)
        Me.PanelControl2.Controls.Add(Me.LabelControl9)
        Me.PanelControl2.Controls.Add(Me.DEUntil)
        Me.PanelControl2.Controls.Add(Me.LabelControl8)
        Me.PanelControl2.Controls.Add(Me.DEStart)
        Me.PanelControl2.Dock = System.Windows.Forms.DockStyle.Top
        Me.PanelControl2.Location = New System.Drawing.Point(0, 0)
        Me.PanelControl2.Name = "PanelControl2"
        Me.PanelControl2.Size = New System.Drawing.Size(961, 42)
        Me.PanelControl2.TabIndex = 0
        '
        'GCPemakaian
        '
        Me.GCPemakaian.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCPemakaian.Location = New System.Drawing.Point(0, 42)
        Me.GCPemakaian.MainView = Me.GVPemakaian
        Me.GCPemakaian.Name = "GCPemakaian"
        Me.GCPemakaian.Size = New System.Drawing.Size(961, 522)
        Me.GCPemakaian.TabIndex = 1
        Me.GCPemakaian.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVPemakaian})
        '
        'GVPemakaian
        '
        Me.GVPemakaian.Bands.AddRange(New DevExpress.XtraGrid.Views.BandedGrid.GridBand() {Me.GridBand1, Me.gridBand2, Me.gridBand3, Me.gridBand4, Me.gridBand5})
        Me.GVPemakaian.Columns.AddRange(New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn() {Me.GridColumn1, Me.GridColumn2, Me.BandedGridColumn1, Me.GridColumn3, Me.GridColumn4, Me.GridColumn5, Me.GridColumn6, Me.GridColumn7, Me.GridColumn8, Me.GridColumn9, Me.GridColumn10, Me.GridColumn11, Me.BandedGridColumn2, Me.BandedGridColumn3, Me.BandedGridColumn4})
        Me.GVPemakaian.GridControl = Me.GCPemakaian
        Me.GVPemakaian.Name = "GVPemakaian"
        Me.GVPemakaian.OptionsView.ShowFooter = True
        Me.GVPemakaian.OptionsView.ShowGroupPanel = False
        '
        'GridColumn1
        '
        Me.GridColumn1.Caption = "ID Item"
        Me.GridColumn1.FieldName = "id_item"
        Me.GridColumn1.Name = "GridColumn1"
        '
        'GridColumn2
        '
        Me.GridColumn2.Caption = "Item"
        Me.GridColumn2.FieldName = "item_desc"
        Me.GridColumn2.Name = "GridColumn2"
        Me.GridColumn2.Visible = True
        '
        'GridColumn3
        '
        Me.GridColumn3.Caption = "Stock Awal"
        Me.GridColumn3.DisplayFormat.FormatString = "N2"
        Me.GridColumn3.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumn3.FieldName = "qty_beg"
        Me.GridColumn3.Name = "GridColumn3"
        Me.GridColumn3.Visible = True
        '
        'GridColumn4
        '
        Me.GridColumn4.Caption = "Harga Satuan"
        Me.GridColumn4.DisplayFormat.FormatString = "N2"
        Me.GridColumn4.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumn4.FieldName = "harga_satuan_beg"
        Me.GridColumn4.Name = "GridColumn4"
        Me.GridColumn4.Visible = True
        '
        'GridColumn5
        '
        Me.GridColumn5.Caption = "Total"
        Me.GridColumn5.DisplayFormat.FormatString = "N2"
        Me.GridColumn5.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumn5.FieldName = "amount_beg"
        Me.GridColumn5.Name = "GridColumn5"
        Me.GridColumn5.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "amount_beg", "{0:N2}")})
        Me.GridColumn5.Visible = True
        '
        'GridColumn6
        '
        Me.GridColumn6.Caption = "Pembelian"
        Me.GridColumn6.DisplayFormat.FormatString = "N2"
        Me.GridColumn6.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumn6.FieldName = "qty_rec"
        Me.GridColumn6.Name = "GridColumn6"
        Me.GridColumn6.Visible = True
        '
        'GridColumn7
        '
        Me.GridColumn7.Caption = "Harga Satuan"
        Me.GridColumn7.DisplayFormat.FormatString = "N2"
        Me.GridColumn7.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumn7.FieldName = "harga_satuan_rec"
        Me.GridColumn7.Name = "GridColumn7"
        Me.GridColumn7.Visible = True
        '
        'GridColumn8
        '
        Me.GridColumn8.Caption = "Total"
        Me.GridColumn8.DisplayFormat.FormatString = "N2"
        Me.GridColumn8.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumn8.FieldName = "amount_rec"
        Me.GridColumn8.Name = "GridColumn8"
        Me.GridColumn8.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "amount_rec", "{0:N2}")})
        Me.GridColumn8.Visible = True
        '
        'GridColumn9
        '
        Me.GridColumn9.Caption = "Pemakaian"
        Me.GridColumn9.DisplayFormat.FormatString = "N2"
        Me.GridColumn9.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumn9.FieldName = "qty_used"
        Me.GridColumn9.Name = "GridColumn9"
        Me.GridColumn9.Visible = True
        '
        'GridColumn10
        '
        Me.GridColumn10.Caption = "Harga Satuan"
        Me.GridColumn10.DisplayFormat.FormatString = "N2"
        Me.GridColumn10.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumn10.FieldName = "harga_satuan_used"
        Me.GridColumn10.Name = "GridColumn10"
        Me.GridColumn10.Visible = True
        '
        'GridColumn11
        '
        Me.GridColumn11.Caption = "Total"
        Me.GridColumn11.DisplayFormat.FormatString = "N2"
        Me.GridColumn11.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumn11.FieldName = "amount_used"
        Me.GridColumn11.Name = "GridColumn11"
        Me.GridColumn11.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "amount_used", "{0:N2}")})
        Me.GridColumn11.Visible = True
        '
        'BandedGridColumn1
        '
        Me.BandedGridColumn1.AppearanceCell.Options.UseTextOptions = True
        Me.BandedGridColumn1.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.BandedGridColumn1.AppearanceHeader.Options.UseTextOptions = True
        Me.BandedGridColumn1.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.BandedGridColumn1.Caption = "UOM"
        Me.BandedGridColumn1.FieldName = "uom"
        Me.BandedGridColumn1.Name = "BandedGridColumn1"
        Me.BandedGridColumn1.Visible = True
        '
        'BandedGridColumn2
        '
        Me.BandedGridColumn2.Caption = "Stock Akhir"
        Me.BandedGridColumn2.DisplayFormat.FormatString = "N2"
        Me.BandedGridColumn2.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.BandedGridColumn2.FieldName = "qty_rem"
        Me.BandedGridColumn2.Name = "BandedGridColumn2"
        Me.BandedGridColumn2.Visible = True
        '
        'BandedGridColumn3
        '
        Me.BandedGridColumn3.Caption = "Harga Satuan"
        Me.BandedGridColumn3.DisplayFormat.FormatString = "N2"
        Me.BandedGridColumn3.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.BandedGridColumn3.FieldName = "harga_satuan_rem"
        Me.BandedGridColumn3.Name = "BandedGridColumn3"
        Me.BandedGridColumn3.Visible = True
        '
        'BandedGridColumn4
        '
        Me.BandedGridColumn4.Caption = "Total"
        Me.BandedGridColumn4.DisplayFormat.FormatString = "N2"
        Me.BandedGridColumn4.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.BandedGridColumn4.FieldName = "amount_rem"
        Me.BandedGridColumn4.Name = "BandedGridColumn4"
        Me.BandedGridColumn4.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "amount_rem", "{0:N2}")})
        Me.BandedGridColumn4.Visible = True
        '
        'GridBand1
        '
        Me.GridBand1.Caption = "Deskripsi"
        Me.GridBand1.Columns.Add(Me.GridColumn1)
        Me.GridBand1.Columns.Add(Me.GridColumn2)
        Me.GridBand1.Columns.Add(Me.BandedGridColumn1)
        Me.GridBand1.Name = "GridBand1"
        Me.GridBand1.VisibleIndex = 0
        Me.GridBand1.Width = 150
        '
        'gridBand2
        '
        Me.gridBand2.Caption = "Stock Awal"
        Me.gridBand2.Columns.Add(Me.GridColumn3)
        Me.gridBand2.Columns.Add(Me.GridColumn4)
        Me.gridBand2.Columns.Add(Me.GridColumn5)
        Me.gridBand2.Name = "gridBand2"
        Me.gridBand2.VisibleIndex = 1
        Me.gridBand2.Width = 225
        '
        'gridBand3
        '
        Me.gridBand3.Caption = "Pembelian"
        Me.gridBand3.Columns.Add(Me.GridColumn6)
        Me.gridBand3.Columns.Add(Me.GridColumn7)
        Me.gridBand3.Columns.Add(Me.GridColumn8)
        Me.gridBand3.Name = "gridBand3"
        Me.gridBand3.VisibleIndex = 2
        Me.gridBand3.Width = 225
        '
        'gridBand4
        '
        Me.gridBand4.Caption = "Pemakaian"
        Me.gridBand4.Columns.Add(Me.GridColumn9)
        Me.gridBand4.Columns.Add(Me.GridColumn10)
        Me.gridBand4.Columns.Add(Me.GridColumn11)
        Me.gridBand4.Name = "gridBand4"
        Me.gridBand4.VisibleIndex = 3
        Me.gridBand4.Width = 225
        '
        'gridBand5
        '
        Me.gridBand5.Caption = "Stock Akhir"
        Me.gridBand5.Columns.Add(Me.BandedGridColumn2)
        Me.gridBand5.Columns.Add(Me.BandedGridColumn3)
        Me.gridBand5.Columns.Add(Me.BandedGridColumn4)
        Me.gridBand5.Name = "gridBand5"
        Me.gridBand5.VisibleIndex = 4
        Me.gridBand5.Width = 225
        '
        'DEStart
        '
        Me.DEStart.EditValue = Nothing
        Me.DEStart.Location = New System.Drawing.Point(238, 11)
        Me.DEStart.Name = "DEStart"
        Me.DEStart.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.DEStart.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.DEStart.Properties.DisplayFormat.FormatString = "dd MMMM yyyy"
        Me.DEStart.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.DEStart.Size = New System.Drawing.Size(165, 20)
        Me.DEStart.TabIndex = 0
        '
        'LabelControl8
        '
        Me.LabelControl8.Location = New System.Drawing.Point(208, 14)
        Me.LabelControl8.Name = "LabelControl8"
        Me.LabelControl8.Size = New System.Drawing.Size(24, 13)
        Me.LabelControl8.TabIndex = 1
        Me.LabelControl8.Text = "From"
        '
        'LabelControl9
        '
        Me.LabelControl9.Location = New System.Drawing.Point(409, 14)
        Me.LabelControl9.Name = "LabelControl9"
        Me.LabelControl9.Size = New System.Drawing.Size(21, 13)
        Me.LabelControl9.TabIndex = 3
        Me.LabelControl9.Text = "Until"
        '
        'DEUntil
        '
        Me.DEUntil.EditValue = Nothing
        Me.DEUntil.Location = New System.Drawing.Point(439, 11)
        Me.DEUntil.Name = "DEUntil"
        Me.DEUntil.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.DEUntil.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.DEUntil.Properties.DisplayFormat.FormatString = "dd MMMM yyyy"
        Me.DEUntil.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.DEUntil.Size = New System.Drawing.Size(165, 20)
        Me.DEUntil.TabIndex = 2
        '
        'BView
        '
        Me.BView.Location = New System.Drawing.Point(610, 9)
        Me.BView.Name = "BView"
        Me.BView.Size = New System.Drawing.Size(56, 23)
        Me.BView.TabIndex = 4
        Me.BView.Text = "view"
        '
        'BPrint
        '
        Me.BPrint.Location = New System.Drawing.Point(672, 9)
        Me.BPrint.Name = "BPrint"
        Me.BPrint.Size = New System.Drawing.Size(56, 23)
        Me.BPrint.TabIndex = 5
        Me.BPrint.Text = "print"
        '
        'LECatPemakaian
        '
        Me.LECatPemakaian.Location = New System.Drawing.Point(62, 11)
        Me.LECatPemakaian.Name = "LECatPemakaian"
        Me.LECatPemakaian.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.LECatPemakaian.Properties.Columns.AddRange(New DevExpress.XtraEditors.Controls.LookUpColumnInfo() {New DevExpress.XtraEditors.Controls.LookUpColumnInfo("id_item_cat", "Id", 20, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("item_cat", "Category")})
        Me.LECatPemakaian.Size = New System.Drawing.Size(140, 20)
        Me.LECatPemakaian.TabIndex = 24
        '
        'LabelControl10
        '
        Me.LabelControl10.Location = New System.Drawing.Point(11, 14)
        Me.LabelControl10.Name = "LabelControl10"
        Me.LabelControl10.Size = New System.Drawing.Size(45, 13)
        Me.LabelControl10.TabIndex = 23
        Me.LabelControl10.Text = "Category"
        '
        'FormPurcItemStock
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(967, 592)
        Me.Controls.Add(Me.XTCStock)
        Me.MinimizeBox = False
        Me.Name = "FormPurcItemStock"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Items Stock"
        CType(Me.XTCStock, System.ComponentModel.ISupportInitialize).EndInit()
        Me.XTCStock.ResumeLayout(False)
        Me.XTPSOH.ResumeLayout(False)
        CType(Me.GCSOH, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVSOH, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PCNav, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PCNav.ResumeLayout(False)
        Me.PCNav.PerformLayout()
        CType(Me.DESOHUntil.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DESOHUntil.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LECat.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LEDeptSum.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.XTPStockCard.ResumeLayout(False)
        CType(Me.GCSC, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ContextMenuStrip1.ResumeLayout(False)
        CType(Me.GVSC, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl1.ResumeLayout(False)
        Me.PanelControl1.PerformLayout()
        CType(Me.SLEITem.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SearchLookUpEdit1View, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DEUntilSC.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DEUntilSC.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DEFromSC.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DEFromSC.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LEDeptSC.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.XTPUsage.ResumeLayout(False)
        CType(Me.PanelControl2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl2.ResumeLayout(False)
        Me.PanelControl2.PerformLayout()
        CType(Me.GCPemakaian, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVPemakaian, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DEStart.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DEStart.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DEUntil.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DEUntil.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LECatPemakaian.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents XTCStock As DevExpress.XtraTab.XtraTabControl
    Friend WithEvents XTPSOH As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents XTPStockCard As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents PCNav As DevExpress.XtraEditors.PanelControl
    Friend WithEvents LEDeptSum As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents LabelControl6 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents BtnView As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents LabelControl2 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents DESOHUntil As DevExpress.XtraEditors.DateEdit
    Friend WithEvents LECat As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents LabelControl1 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents GCSOH As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVSOH As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumnIdItem As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnItemDesc As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnIdItemCat As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnItemCat As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnQty As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnAmount As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnIdDept As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnDept As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents PanelControl1 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents DEUntilSC As DevExpress.XtraEditors.DateEdit
    Friend WithEvents LabelControl7 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl4 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents BtnViewSC As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents LabelControl3 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents DEFromSC As DevExpress.XtraEditors.DateEdit
    Friend WithEvents LEDeptSC As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents LabelControl5 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents GCSC As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVSC As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents SLEITem As DevExpress.XtraEditors.SearchLookUpEdit
    Friend WithEvents SearchLookUpEdit1View As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumnItemId As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnDesc As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnCat As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ContextMenuStrip1 As ContextMenuStrip
    Friend WithEvents ViewDocumentToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents GridColumnIdReport As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnIdStorageCategory As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnRMT As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnTransNumber As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnStorageDate As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnQtySC As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnBalQty As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnStorageCat As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnValue As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumntype As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnStatus As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnDeptSC As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents BStockFisik As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BStockCardFisik As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents XTPUsage As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents GCPemakaian As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVPemakaian As DevExpress.XtraGrid.Views.BandedGrid.BandedGridView
    Friend WithEvents GridBand1 As DevExpress.XtraGrid.Views.BandedGrid.GridBand
    Friend WithEvents GridColumn1 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents GridColumn2 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumn1 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents gridBand2 As DevExpress.XtraGrid.Views.BandedGrid.GridBand
    Friend WithEvents GridColumn3 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents GridColumn4 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents GridColumn5 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents gridBand3 As DevExpress.XtraGrid.Views.BandedGrid.GridBand
    Friend WithEvents GridColumn6 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents GridColumn7 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents GridColumn8 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents gridBand4 As DevExpress.XtraGrid.Views.BandedGrid.GridBand
    Friend WithEvents GridColumn9 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents GridColumn10 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents GridColumn11 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents gridBand5 As DevExpress.XtraGrid.Views.BandedGrid.GridBand
    Friend WithEvents BandedGridColumn2 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumn3 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumn4 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents PanelControl2 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents BView As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents LabelControl9 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents DEUntil As DevExpress.XtraEditors.DateEdit
    Friend WithEvents LabelControl8 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents DEStart As DevExpress.XtraEditors.DateEdit
    Friend WithEvents BPrint As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents LECatPemakaian As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents LabelControl10 As DevExpress.XtraEditors.LabelControl
End Class
