<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormStockQC
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormStockQC))
        Me.XTCStock = New DevExpress.XtraTab.XtraTabControl()
        Me.XTPSOH = New DevExpress.XtraTab.XtraTabPage()
        Me.GCSOH = New DevExpress.XtraGrid.GridControl()
        Me.GVSOH = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumnid_prod_order_det = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnid_prod_order = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnvprod_order_number = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnvendor = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumncode = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnbarcode = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnname = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnsize = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnqty = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumncop = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnamount = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumncop_status = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnseason = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.PanelControl1 = New DevExpress.XtraEditors.PanelControl()
        Me.PanelControl2 = New DevExpress.XtraEditors.PanelControl()
        Me.DEDate = New DevExpress.XtraEditors.DateEdit()
        Me.LabelControl2 = New DevExpress.XtraEditors.LabelControl()
        Me.CEFindAllProduct = New DevExpress.XtraEditors.CheckEdit()
        Me.LabelControl1 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl3 = New DevExpress.XtraEditors.LabelControl()
        Me.TxtProduct = New DevExpress.XtraEditors.TextEdit()
        Me.SLESeason = New DevExpress.XtraEditors.SearchLookUpEdit()
        Me.SearchLookUpEdit1View = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumn6 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn8 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.LabelControl5 = New DevExpress.XtraEditors.LabelControl()
        Me.SLEVendor = New DevExpress.XtraEditors.SearchLookUpEdit()
        Me.GridView14 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumn10 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn11 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn12 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.BtnBrowseProduct = New DevExpress.XtraEditors.SimpleButton()
        Me.BSearch = New DevExpress.XtraEditors.SimpleButton()
        Me.XTPSC = New DevExpress.XtraTab.XtraTabPage()
        Me.GCSC = New DevExpress.XtraGrid.GridControl()
        Me.GVSC = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridView()
        Me.GridBand1 = New DevExpress.XtraGrid.Views.BandedGrid.GridBand()
        Me.GCSCSize = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.GCSCPONumber = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.GCSCNumber = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.GCSCDate = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.GCSCQTY = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.GCSCType = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.gridBand2 = New DevExpress.XtraGrid.Views.BandedGrid.GridBand()
        Me.GCSCStockQC = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.GCSCStockNormal = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.GCSCStockMinor = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.GCSCStockMajor = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.GCSCStockAfkir = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.GCSCTotal = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.GCSCIdCodeDetail = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.PanelControl3 = New DevExpress.XtraEditors.PanelControl()
        Me.PanelControl4 = New DevExpress.XtraEditors.PanelControl()
        Me.TxtDescription = New DevExpress.XtraEditors.TextEdit()
        Me.TxtCode = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl7 = New DevExpress.XtraEditors.LabelControl()
        Me.TxtVendor = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl4 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl6 = New DevExpress.XtraEditors.LabelControl()
        Me.BtnBrowsePOSC = New DevExpress.XtraEditors.SimpleButton()
        Me.TxtProductSC = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl8 = New DevExpress.XtraEditors.LabelControl()
        Me.BSearchSC = New DevExpress.XtraEditors.SimpleButton()
        Me.XTPStock = New DevExpress.XtraTab.XtraTabPage()
        Me.GroupControl6 = New DevExpress.XtraEditors.GroupControl()
        Me.GCStockReport = New DevExpress.XtraGrid.GridControl()
        Me.GVStockReport = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumn2 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn3 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn4 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn5 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn7 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn9 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn1 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn13 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn14 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn16 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn15 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn17 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GroupControl1 = New DevExpress.XtraEditors.GroupControl()
        Me.SBPrintStock = New DevExpress.XtraEditors.SimpleButton()
        Me.DEStockTo = New DevExpress.XtraEditors.DateEdit()
        Me.DEStockFrom = New DevExpress.XtraEditors.DateEdit()
        Me.LabelControl28 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl31 = New DevExpress.XtraEditors.LabelControl()
        Me.SBStockView = New DevExpress.XtraEditors.SimpleButton()
        Me.LabelControl9 = New DevExpress.XtraEditors.LabelControl()
        Me.SLEType = New DevExpress.XtraEditors.SearchLookUpEdit()
        Me.GridView1 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumn18 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn19 = New DevExpress.XtraGrid.Columns.GridColumn()
        CType(Me.XTCStock, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.XTCStock.SuspendLayout()
        Me.XTPSOH.SuspendLayout()
        CType(Me.GCSOH, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVSOH, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl1.SuspendLayout()
        CType(Me.PanelControl2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl2.SuspendLayout()
        CType(Me.DEDate.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DEDate.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CEFindAllProduct.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtProduct.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SLESeason.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SearchLookUpEdit1View, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SLEVendor.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView14, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.XTPSC.SuspendLayout()
        CType(Me.GCSC, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVSC, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PanelControl3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl3.SuspendLayout()
        CType(Me.PanelControl4, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl4.SuspendLayout()
        CType(Me.TxtDescription.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtCode.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtVendor.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtProductSC.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.XTPStock.SuspendLayout()
        CType(Me.GroupControl6, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupControl6.SuspendLayout()
        CType(Me.GCStockReport, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVStockReport, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GroupControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupControl1.SuspendLayout()
        CType(Me.DEStockTo.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DEStockTo.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DEStockFrom.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DEStockFrom.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SLEType.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'XTCStock
        '
        Me.XTCStock.Dock = System.Windows.Forms.DockStyle.Fill
        Me.XTCStock.HeaderLocation = DevExpress.XtraTab.TabHeaderLocation.Bottom
        Me.XTCStock.Location = New System.Drawing.Point(0, 0)
        Me.XTCStock.Name = "XTCStock"
        Me.XTCStock.SelectedTabPage = Me.XTPSOH
        Me.XTCStock.Size = New System.Drawing.Size(1072, 528)
        Me.XTCStock.TabIndex = 0
        Me.XTCStock.TabPages.AddRange(New DevExpress.XtraTab.XtraTabPage() {Me.XTPSOH, Me.XTPSC, Me.XTPStock})
        '
        'XTPSOH
        '
        Me.XTPSOH.Controls.Add(Me.GCSOH)
        Me.XTPSOH.Controls.Add(Me.PanelControl1)
        Me.XTPSOH.Name = "XTPSOH"
        Me.XTPSOH.Size = New System.Drawing.Size(1066, 500)
        Me.XTPSOH.Text = "Stock On Hand"
        '
        'GCSOH
        '
        Me.GCSOH.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCSOH.Location = New System.Drawing.Point(0, 81)
        Me.GCSOH.MainView = Me.GVSOH
        Me.GCSOH.Name = "GCSOH"
        Me.GCSOH.Size = New System.Drawing.Size(1066, 419)
        Me.GCSOH.TabIndex = 5
        Me.GCSOH.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVSOH})
        '
        'GVSOH
        '
        Me.GVSOH.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumnid_prod_order_det, Me.GridColumnid_prod_order, Me.GridColumnvprod_order_number, Me.GridColumnvendor, Me.GridColumncode, Me.GridColumnbarcode, Me.GridColumnname, Me.GridColumnsize, Me.GridColumnqty, Me.GridColumncop, Me.GridColumnamount, Me.GridColumncop_status, Me.GridColumnseason})
        Me.GVSOH.GridControl = Me.GCSOH
        Me.GVSOH.GroupCount = 1
        Me.GVSOH.GroupSummary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "qty", Me.GridColumnqty, "{0:N0}"), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "amount", Me.GridColumnamount, "{0:N2}")})
        Me.GVSOH.Name = "GVSOH"
        Me.GVSOH.OptionsBehavior.AutoExpandAllGroups = True
        Me.GVSOH.OptionsBehavior.ReadOnly = True
        Me.GVSOH.OptionsView.ColumnAutoWidth = False
        Me.GVSOH.OptionsView.ShowFooter = True
        Me.GVSOH.OptionsView.ShowGroupedColumns = True
        Me.GVSOH.OptionsView.ShowGroupPanel = False
        Me.GVSOH.SortInfo.AddRange(New DevExpress.XtraGrid.Columns.GridColumnSortInfo() {New DevExpress.XtraGrid.Columns.GridColumnSortInfo(Me.GridColumnvprod_order_number, DevExpress.Data.ColumnSortOrder.Ascending)})
        '
        'GridColumnid_prod_order_det
        '
        Me.GridColumnid_prod_order_det.Caption = "id_prod_order_det"
        Me.GridColumnid_prod_order_det.FieldName = "id_prod_order_det"
        Me.GridColumnid_prod_order_det.Name = "GridColumnid_prod_order_det"
        '
        'GridColumnid_prod_order
        '
        Me.GridColumnid_prod_order.Caption = "id_prod_order"
        Me.GridColumnid_prod_order.FieldName = "id_prod_order"
        Me.GridColumnid_prod_order.Name = "GridColumnid_prod_order"
        '
        'GridColumnvprod_order_number
        '
        Me.GridColumnvprod_order_number.Caption = "Order No"
        Me.GridColumnvprod_order_number.FieldName = "prod_order_number"
        Me.GridColumnvprod_order_number.Name = "GridColumnvprod_order_number"
        Me.GridColumnvprod_order_number.Visible = True
        Me.GridColumnvprod_order_number.VisibleIndex = 0
        Me.GridColumnvprod_order_number.Width = 104
        '
        'GridColumnvendor
        '
        Me.GridColumnvendor.Caption = "Vendor"
        Me.GridColumnvendor.FieldName = "vendor"
        Me.GridColumnvendor.Name = "GridColumnvendor"
        Me.GridColumnvendor.Visible = True
        Me.GridColumnvendor.VisibleIndex = 1
        Me.GridColumnvendor.Width = 88
        '
        'GridColumncode
        '
        Me.GridColumncode.Caption = "Code"
        Me.GridColumncode.FieldName = "code"
        Me.GridColumncode.Name = "GridColumncode"
        Me.GridColumncode.Visible = True
        Me.GridColumncode.VisibleIndex = 2
        Me.GridColumncode.Width = 89
        '
        'GridColumnbarcode
        '
        Me.GridColumnbarcode.Caption = "Barcode"
        Me.GridColumnbarcode.FieldName = "barcode"
        Me.GridColumnbarcode.Name = "GridColumnbarcode"
        Me.GridColumnbarcode.Visible = True
        Me.GridColumnbarcode.VisibleIndex = 3
        '
        'GridColumnname
        '
        Me.GridColumnname.Caption = "Description"
        Me.GridColumnname.FieldName = "name"
        Me.GridColumnname.Name = "GridColumnname"
        Me.GridColumnname.Visible = True
        Me.GridColumnname.VisibleIndex = 4
        Me.GridColumnname.Width = 191
        '
        'GridColumnsize
        '
        Me.GridColumnsize.Caption = "Size"
        Me.GridColumnsize.FieldName = "size"
        Me.GridColumnsize.Name = "GridColumnsize"
        Me.GridColumnsize.Visible = True
        Me.GridColumnsize.VisibleIndex = 5
        '
        'GridColumnqty
        '
        Me.GridColumnqty.Caption = "Qty"
        Me.GridColumnqty.DisplayFormat.FormatString = "N0"
        Me.GridColumnqty.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumnqty.FieldName = "qty"
        Me.GridColumnqty.Name = "GridColumnqty"
        Me.GridColumnqty.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "qty", "{0:N0}")})
        Me.GridColumnqty.Visible = True
        Me.GridColumnqty.VisibleIndex = 7
        '
        'GridColumncop
        '
        Me.GridColumncop.Caption = "COP"
        Me.GridColumncop.DisplayFormat.FormatString = "N2"
        Me.GridColumncop.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumncop.FieldName = "cop"
        Me.GridColumncop.Name = "GridColumncop"
        Me.GridColumncop.Visible = True
        Me.GridColumncop.VisibleIndex = 8
        '
        'GridColumnamount
        '
        Me.GridColumnamount.Caption = "Amount"
        Me.GridColumnamount.DisplayFormat.FormatString = "N2"
        Me.GridColumnamount.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumnamount.FieldName = "amount"
        Me.GridColumnamount.Name = "GridColumnamount"
        Me.GridColumnamount.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "amount", "{0:N2}")})
        Me.GridColumnamount.UnboundExpression = "[qty] * [cop]"
        Me.GridColumnamount.UnboundType = DevExpress.Data.UnboundColumnType.[Decimal]
        Me.GridColumnamount.Visible = True
        Me.GridColumnamount.VisibleIndex = 9
        '
        'GridColumncop_status
        '
        Me.GridColumncop_status.Caption = "COP Status"
        Me.GridColumncop_status.FieldName = "cop_status"
        Me.GridColumncop_status.Name = "GridColumncop_status"
        Me.GridColumncop_status.Visible = True
        Me.GridColumncop_status.VisibleIndex = 10
        Me.GridColumncop_status.Width = 122
        '
        'GridColumnseason
        '
        Me.GridColumnseason.Caption = "Season"
        Me.GridColumnseason.FieldName = "season"
        Me.GridColumnseason.Name = "GridColumnseason"
        Me.GridColumnseason.OptionsColumn.ReadOnly = True
        Me.GridColumnseason.Visible = True
        Me.GridColumnseason.VisibleIndex = 6
        '
        'PanelControl1
        '
        Me.PanelControl1.Controls.Add(Me.PanelControl2)
        Me.PanelControl1.Controls.Add(Me.BSearch)
        Me.PanelControl1.Dock = System.Windows.Forms.DockStyle.Top
        Me.PanelControl1.Location = New System.Drawing.Point(0, 0)
        Me.PanelControl1.Name = "PanelControl1"
        Me.PanelControl1.Size = New System.Drawing.Size(1066, 81)
        Me.PanelControl1.TabIndex = 4
        '
        'PanelControl2
        '
        Me.PanelControl2.Controls.Add(Me.DEDate)
        Me.PanelControl2.Controls.Add(Me.LabelControl2)
        Me.PanelControl2.Controls.Add(Me.CEFindAllProduct)
        Me.PanelControl2.Controls.Add(Me.LabelControl1)
        Me.PanelControl2.Controls.Add(Me.LabelControl3)
        Me.PanelControl2.Controls.Add(Me.TxtProduct)
        Me.PanelControl2.Controls.Add(Me.SLESeason)
        Me.PanelControl2.Controls.Add(Me.LabelControl5)
        Me.PanelControl2.Controls.Add(Me.SLEVendor)
        Me.PanelControl2.Controls.Add(Me.BtnBrowseProduct)
        Me.PanelControl2.Dock = System.Windows.Forms.DockStyle.Left
        Me.PanelControl2.Location = New System.Drawing.Point(2, 2)
        Me.PanelControl2.Name = "PanelControl2"
        Me.PanelControl2.Size = New System.Drawing.Size(622, 77)
        Me.PanelControl2.TabIndex = 8911
        '
        'DEDate
        '
        Me.DEDate.EditValue = Nothing
        Me.DEDate.Location = New System.Drawing.Point(443, 14)
        Me.DEDate.Name = "DEDate"
        Me.DEDate.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.[False]
        Me.DEDate.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.DEDate.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.DEDate.Properties.DisplayFormat.FormatString = "dd MMMM yyyy"
        Me.DEDate.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.DEDate.Size = New System.Drawing.Size(167, 20)
        Me.DEDate.TabIndex = 8912
        '
        'LabelControl2
        '
        Me.LabelControl2.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl2.Location = New System.Drawing.Point(414, 17)
        Me.LabelControl2.Name = "LabelControl2"
        Me.LabelControl2.Size = New System.Drawing.Size(23, 13)
        Me.LabelControl2.TabIndex = 8911
        Me.LabelControl2.Text = "Date"
        '
        'CEFindAllProduct
        '
        Me.CEFindAllProduct.EditValue = True
        Me.CEFindAllProduct.Location = New System.Drawing.Point(512, 39)
        Me.CEFindAllProduct.Name = "CEFindAllProduct"
        Me.CEFindAllProduct.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CEFindAllProduct.Properties.Appearance.Options.UseFont = True
        Me.CEFindAllProduct.Properties.Caption = "Find All Product"
        Me.CEFindAllProduct.Size = New System.Drawing.Size(98, 19)
        Me.CEFindAllProduct.TabIndex = 8910
        '
        'LabelControl1
        '
        Me.LabelControl1.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl1.Location = New System.Drawing.Point(12, 17)
        Me.LabelControl1.Name = "LabelControl1"
        Me.LabelControl1.Size = New System.Drawing.Size(35, 13)
        Me.LabelControl1.TabIndex = 8897
        Me.LabelControl1.Text = "Season"
        '
        'LabelControl3
        '
        Me.LabelControl3.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl3.Location = New System.Drawing.Point(220, 17)
        Me.LabelControl3.Name = "LabelControl3"
        Me.LabelControl3.Size = New System.Drawing.Size(34, 13)
        Me.LabelControl3.TabIndex = 8901
        Me.LabelControl3.Text = "Vendor"
        '
        'TxtProduct
        '
        Me.TxtProduct.EditValue = ""
        Me.TxtProduct.Enabled = False
        Me.TxtProduct.Location = New System.Drawing.Point(61, 39)
        Me.TxtProduct.Name = "TxtProduct"
        Me.TxtProduct.Size = New System.Drawing.Size(413, 20)
        Me.TxtProduct.TabIndex = 8908
        '
        'SLESeason
        '
        Me.SLESeason.Location = New System.Drawing.Point(61, 14)
        Me.SLESeason.Name = "SLESeason"
        Me.SLESeason.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SLESeason.Properties.Appearance.Options.UseFont = True
        Me.SLESeason.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.SLESeason.Properties.ShowClearButton = False
        Me.SLESeason.Properties.View = Me.SearchLookUpEdit1View
        Me.SLESeason.Size = New System.Drawing.Size(153, 20)
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
        'LabelControl5
        '
        Me.LabelControl5.Location = New System.Drawing.Point(12, 42)
        Me.LabelControl5.Name = "LabelControl5"
        Me.LabelControl5.Size = New System.Drawing.Size(37, 13)
        Me.LabelControl5.TabIndex = 8907
        Me.LabelControl5.Text = "Product"
        '
        'SLEVendor
        '
        Me.SLEVendor.Location = New System.Drawing.Point(260, 14)
        Me.SLEVendor.Name = "SLEVendor"
        Me.SLEVendor.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SLEVendor.Properties.Appearance.Options.UseFont = True
        Me.SLEVendor.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.SLEVendor.Properties.ShowClearButton = False
        Me.SLEVendor.Properties.View = Me.GridView14
        Me.SLEVendor.Size = New System.Drawing.Size(148, 20)
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
        'BtnBrowseProduct
        '
        Me.BtnBrowseProduct.Enabled = False
        Me.BtnBrowseProduct.Image = CType(resources.GetObject("BtnBrowseProduct.Image"), System.Drawing.Image)
        Me.BtnBrowseProduct.Location = New System.Drawing.Point(480, 39)
        Me.BtnBrowseProduct.LookAndFeel.SkinName = "Blue"
        Me.BtnBrowseProduct.Name = "BtnBrowseProduct"
        Me.BtnBrowseProduct.Size = New System.Drawing.Size(26, 20)
        Me.BtnBrowseProduct.TabIndex = 8906
        Me.BtnBrowseProduct.Text = "..."
        '
        'BSearch
        '
        Me.BSearch.Image = CType(resources.GetObject("BSearch.Image"), System.Drawing.Image)
        Me.BSearch.Location = New System.Drawing.Point(635, 29)
        Me.BSearch.Name = "BSearch"
        Me.BSearch.Size = New System.Drawing.Size(92, 23)
        Me.BSearch.TabIndex = 8903
        Me.BSearch.Text = "View Data"
        '
        'XTPSC
        '
        Me.XTPSC.Controls.Add(Me.GCSC)
        Me.XTPSC.Controls.Add(Me.PanelControl3)
        Me.XTPSC.Name = "XTPSC"
        Me.XTPSC.Size = New System.Drawing.Size(1066, 500)
        Me.XTPSC.Text = "Stock Card"
        '
        'GCSC
        '
        Me.GCSC.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCSC.Location = New System.Drawing.Point(0, 86)
        Me.GCSC.MainView = Me.GVSC
        Me.GCSC.Name = "GCSC"
        Me.GCSC.Size = New System.Drawing.Size(1066, 414)
        Me.GCSC.TabIndex = 6
        Me.GCSC.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVSC})
        '
        'GVSC
        '
        Me.GVSC.Bands.AddRange(New DevExpress.XtraGrid.Views.BandedGrid.GridBand() {Me.GridBand1, Me.gridBand2})
        Me.GVSC.Columns.AddRange(New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn() {Me.GCSCIdCodeDetail, Me.GCSCSize, Me.GCSCPONumber, Me.GCSCNumber, Me.GCSCDate, Me.GCSCQTY, Me.GCSCType, Me.GCSCStockQC, Me.GCSCStockNormal, Me.GCSCStockMinor, Me.GCSCStockMajor, Me.GCSCStockAfkir, Me.GCSCTotal})
        Me.GVSC.GridControl = Me.GCSC
        Me.GVSC.GroupCount = 1
        Me.GVSC.Name = "GVSC"
        Me.GVSC.OptionsBehavior.AutoExpandAllGroups = True
        Me.GVSC.OptionsBehavior.ReadOnly = True
        Me.GVSC.OptionsView.ColumnAutoWidth = False
        Me.GVSC.OptionsView.ShowFooter = True
        Me.GVSC.OptionsView.ShowGroupPanel = False
        Me.GVSC.SortInfo.AddRange(New DevExpress.XtraGrid.Columns.GridColumnSortInfo() {New DevExpress.XtraGrid.Columns.GridColumnSortInfo(Me.GCSCSize, DevExpress.Data.ColumnSortOrder.Ascending)})
        '
        'GridBand1
        '
        Me.GridBand1.Columns.Add(Me.GCSCSize)
        Me.GridBand1.Columns.Add(Me.GCSCPONumber)
        Me.GridBand1.Columns.Add(Me.GCSCNumber)
        Me.GridBand1.Columns.Add(Me.GCSCDate)
        Me.GridBand1.Columns.Add(Me.GCSCQTY)
        Me.GridBand1.Columns.Add(Me.GCSCType)
        Me.GridBand1.Name = "GridBand1"
        Me.GridBand1.VisibleIndex = 0
        Me.GridBand1.Width = 450
        '
        'GCSCSize
        '
        Me.GCSCSize.Caption = "Size"
        Me.GCSCSize.FieldName = "size"
        Me.GCSCSize.FieldNameSortGroup = "id_code_detail"
        Me.GCSCSize.Name = "GCSCSize"
        Me.GCSCSize.Visible = True
        '
        'GCSCPONumber
        '
        Me.GCSCPONumber.Caption = "PO Number"
        Me.GCSCPONumber.FieldName = "prod_order_number"
        Me.GCSCPONumber.Name = "GCSCPONumber"
        Me.GCSCPONumber.Visible = True
        '
        'GCSCNumber
        '
        Me.GCSCNumber.Caption = "Number"
        Me.GCSCNumber.FieldName = "number"
        Me.GCSCNumber.Name = "GCSCNumber"
        Me.GCSCNumber.Visible = True
        '
        'GCSCDate
        '
        Me.GCSCDate.Caption = "Date"
        Me.GCSCDate.DisplayFormat.FormatString = "dd MMMM yyyy"
        Me.GCSCDate.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.GCSCDate.FieldName = "date"
        Me.GCSCDate.Name = "GCSCDate"
        Me.GCSCDate.Visible = True
        '
        'GCSCQTY
        '
        Me.GCSCQTY.Caption = "QTY"
        Me.GCSCQTY.DisplayFormat.FormatString = "N0"
        Me.GCSCQTY.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GCSCQTY.FieldName = "qty"
        Me.GCSCQTY.Name = "GCSCQTY"
        Me.GCSCQTY.Visible = True
        '
        'GCSCType
        '
        Me.GCSCType.Caption = "Type"
        Me.GCSCType.FieldName = "type"
        Me.GCSCType.Name = "GCSCType"
        Me.GCSCType.Visible = True
        '
        'gridBand2
        '
        Me.gridBand2.Caption = "Stock"
        Me.gridBand2.Columns.Add(Me.GCSCStockQC)
        Me.gridBand2.Columns.Add(Me.GCSCStockNormal)
        Me.gridBand2.Columns.Add(Me.GCSCStockMinor)
        Me.gridBand2.Columns.Add(Me.GCSCStockMajor)
        Me.gridBand2.Columns.Add(Me.GCSCStockAfkir)
        Me.gridBand2.Columns.Add(Me.GCSCTotal)
        Me.gridBand2.Name = "gridBand2"
        Me.gridBand2.VisibleIndex = 1
        Me.gridBand2.Width = 450
        '
        'GCSCStockQC
        '
        Me.GCSCStockQC.Caption = "QC"
        Me.GCSCStockQC.DisplayFormat.FormatString = "N0"
        Me.GCSCStockQC.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GCSCStockQC.FieldName = "stock_qc"
        Me.GCSCStockQC.Name = "GCSCStockQC"
        Me.GCSCStockQC.Visible = True
        '
        'GCSCStockNormal
        '
        Me.GCSCStockNormal.Caption = "Normal"
        Me.GCSCStockNormal.DisplayFormat.FormatString = "N0"
        Me.GCSCStockNormal.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GCSCStockNormal.FieldName = "stock_normal"
        Me.GCSCStockNormal.Name = "GCSCStockNormal"
        Me.GCSCStockNormal.Visible = True
        '
        'GCSCStockMinor
        '
        Me.GCSCStockMinor.Caption = "Minor"
        Me.GCSCStockMinor.DisplayFormat.FormatString = "N0"
        Me.GCSCStockMinor.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GCSCStockMinor.FieldName = "stock_minor"
        Me.GCSCStockMinor.Name = "GCSCStockMinor"
        Me.GCSCStockMinor.Visible = True
        '
        'GCSCStockMajor
        '
        Me.GCSCStockMajor.Caption = "Major"
        Me.GCSCStockMajor.DisplayFormat.FormatString = "N0"
        Me.GCSCStockMajor.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GCSCStockMajor.FieldName = "stock_major"
        Me.GCSCStockMajor.Name = "GCSCStockMajor"
        Me.GCSCStockMajor.Visible = True
        '
        'GCSCStockAfkir
        '
        Me.GCSCStockAfkir.Caption = "Afkir"
        Me.GCSCStockAfkir.DisplayFormat.FormatString = "N0"
        Me.GCSCStockAfkir.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GCSCStockAfkir.FieldName = "stock_afkir"
        Me.GCSCStockAfkir.Name = "GCSCStockAfkir"
        Me.GCSCStockAfkir.Visible = True
        '
        'GCSCTotal
        '
        Me.GCSCTotal.Caption = "Total"
        Me.GCSCTotal.DisplayFormat.FormatString = "N0"
        Me.GCSCTotal.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GCSCTotal.FieldName = "total"
        Me.GCSCTotal.Name = "GCSCTotal"
        Me.GCSCTotal.Visible = True
        '
        'GCSCIdCodeDetail
        '
        Me.GCSCIdCodeDetail.FieldName = "id_code_detail"
        Me.GCSCIdCodeDetail.Name = "GCSCIdCodeDetail"
        '
        'PanelControl3
        '
        Me.PanelControl3.Controls.Add(Me.PanelControl4)
        Me.PanelControl3.Controls.Add(Me.BtnBrowsePOSC)
        Me.PanelControl3.Controls.Add(Me.TxtProductSC)
        Me.PanelControl3.Controls.Add(Me.LabelControl8)
        Me.PanelControl3.Controls.Add(Me.BSearchSC)
        Me.PanelControl3.Dock = System.Windows.Forms.DockStyle.Top
        Me.PanelControl3.Location = New System.Drawing.Point(0, 0)
        Me.PanelControl3.Name = "PanelControl3"
        Me.PanelControl3.Size = New System.Drawing.Size(1066, 86)
        Me.PanelControl3.TabIndex = 5
        '
        'PanelControl4
        '
        Me.PanelControl4.Controls.Add(Me.TxtDescription)
        Me.PanelControl4.Controls.Add(Me.TxtCode)
        Me.PanelControl4.Controls.Add(Me.LabelControl7)
        Me.PanelControl4.Controls.Add(Me.TxtVendor)
        Me.PanelControl4.Controls.Add(Me.LabelControl4)
        Me.PanelControl4.Controls.Add(Me.LabelControl6)
        Me.PanelControl4.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PanelControl4.Location = New System.Drawing.Point(2, 38)
        Me.PanelControl4.Name = "PanelControl4"
        Me.PanelControl4.Size = New System.Drawing.Size(1062, 46)
        Me.PanelControl4.TabIndex = 8914
        '
        'TxtDescription
        '
        Me.TxtDescription.EditValue = ""
        Me.TxtDescription.Enabled = False
        Me.TxtDescription.Location = New System.Drawing.Point(576, 14)
        Me.TxtDescription.Name = "TxtDescription"
        Me.TxtDescription.Size = New System.Drawing.Size(225, 20)
        Me.TxtDescription.TabIndex = 8915
        '
        'TxtCode
        '
        Me.TxtCode.EditValue = ""
        Me.TxtCode.Enabled = False
        Me.TxtCode.Location = New System.Drawing.Point(336, 14)
        Me.TxtCode.Name = "TxtCode"
        Me.TxtCode.Size = New System.Drawing.Size(160, 20)
        Me.TxtCode.TabIndex = 8914
        '
        'LabelControl7
        '
        Me.LabelControl7.Location = New System.Drawing.Point(512, 17)
        Me.LabelControl7.Name = "LabelControl7"
        Me.LabelControl7.Size = New System.Drawing.Size(53, 13)
        Me.LabelControl7.TabIndex = 8912
        Me.LabelControl7.Text = "Description"
        '
        'TxtVendor
        '
        Me.TxtVendor.EditValue = ""
        Me.TxtVendor.Enabled = False
        Me.TxtVendor.Location = New System.Drawing.Point(59, 14)
        Me.TxtVendor.Name = "TxtVendor"
        Me.TxtVendor.Size = New System.Drawing.Size(225, 20)
        Me.TxtVendor.TabIndex = 8913
        '
        'LabelControl4
        '
        Me.LabelControl4.Location = New System.Drawing.Point(14, 17)
        Me.LabelControl4.Name = "LabelControl4"
        Me.LabelControl4.Size = New System.Drawing.Size(34, 13)
        Me.LabelControl4.TabIndex = 8910
        Me.LabelControl4.Text = "Vendor"
        '
        'LabelControl6
        '
        Me.LabelControl6.Location = New System.Drawing.Point(300, 17)
        Me.LabelControl6.Name = "LabelControl6"
        Me.LabelControl6.Size = New System.Drawing.Size(25, 13)
        Me.LabelControl6.TabIndex = 8911
        Me.LabelControl6.Text = "Code"
        '
        'BtnBrowsePOSC
        '
        Me.BtnBrowsePOSC.Image = CType(resources.GetObject("BtnBrowsePOSC.Image"), System.Drawing.Image)
        Me.BtnBrowsePOSC.Location = New System.Drawing.Point(310, 9)
        Me.BtnBrowsePOSC.LookAndFeel.SkinName = "Blue"
        Me.BtnBrowsePOSC.Name = "BtnBrowsePOSC"
        Me.BtnBrowsePOSC.Size = New System.Drawing.Size(26, 23)
        Me.BtnBrowsePOSC.TabIndex = 8909
        Me.BtnBrowsePOSC.Text = "..."
        '
        'TxtProductSC
        '
        Me.TxtProductSC.EditValue = ""
        Me.TxtProductSC.Location = New System.Drawing.Point(78, 11)
        Me.TxtProductSC.Name = "TxtProductSC"
        Me.TxtProductSC.Size = New System.Drawing.Size(226, 20)
        Me.TxtProductSC.TabIndex = 8908
        '
        'LabelControl8
        '
        Me.LabelControl8.Location = New System.Drawing.Point(13, 14)
        Me.LabelControl8.Name = "LabelControl8"
        Me.LabelControl8.Size = New System.Drawing.Size(54, 13)
        Me.LabelControl8.TabIndex = 8907
        Me.LabelControl8.Text = "PO Number"
        '
        'BSearchSC
        '
        Me.BSearchSC.Image = CType(resources.GetObject("BSearchSC.Image"), System.Drawing.Image)
        Me.BSearchSC.Location = New System.Drawing.Point(342, 9)
        Me.BSearchSC.Name = "BSearchSC"
        Me.BSearchSC.Size = New System.Drawing.Size(92, 23)
        Me.BSearchSC.TabIndex = 8903
        Me.BSearchSC.Text = "View Data"
        '
        'XTPStock
        '
        Me.XTPStock.Controls.Add(Me.GroupControl6)
        Me.XTPStock.Controls.Add(Me.GroupControl1)
        Me.XTPStock.Name = "XTPStock"
        Me.XTPStock.Size = New System.Drawing.Size(1066, 500)
        Me.XTPStock.Text = "Stock Report"
        '
        'GroupControl6
        '
        Me.GroupControl6.CaptionLocation = DevExpress.Utils.Locations.Left
        Me.GroupControl6.Controls.Add(Me.GCStockReport)
        Me.GroupControl6.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupControl6.Location = New System.Drawing.Point(0, 54)
        Me.GroupControl6.Name = "GroupControl6"
        Me.GroupControl6.Size = New System.Drawing.Size(1066, 446)
        Me.GroupControl6.TabIndex = 21
        Me.GroupControl6.Text = "Product"
        '
        'GCStockReport
        '
        Me.GCStockReport.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCStockReport.Location = New System.Drawing.Point(20, 2)
        Me.GCStockReport.MainView = Me.GVStockReport
        Me.GCStockReport.Name = "GCStockReport"
        Me.GCStockReport.Size = New System.Drawing.Size(1044, 442)
        Me.GCStockReport.TabIndex = 38
        Me.GCStockReport.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVStockReport})
        '
        'GVStockReport
        '
        Me.GVStockReport.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumn2, Me.GridColumn3, Me.GridColumn4, Me.GridColumn5, Me.GridColumn7, Me.GridColumn9, Me.GridColumn1, Me.GridColumn13, Me.GridColumn14, Me.GridColumn16, Me.GridColumn15, Me.GridColumn17})
        Me.GVStockReport.GridControl = Me.GCStockReport
        Me.GVStockReport.GroupSummary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "qty_beg", Nothing, "{0:N2}"), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "amount_beg", Nothing, "{0:N2}"), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "qty_receive", Nothing, "{0:N2}"), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "amount_receive", Nothing, "{0:N2}"), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "qty_mrs", Nothing, "{0:N2}"), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "amount_mrs", Nothing, "{0:N2}"), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "qty_retur", Nothing, "{0:N2}"), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "amount_retur", Nothing, "{0:N2}"), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "qty_adj", Nothing, "{0:N2}"), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "amount_adj", Nothing, "{0:N2}"), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "qty_ending", Nothing, "{0:N2}"), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "amount_ending", Nothing, "{0:N2}")})
        Me.GVStockReport.Name = "GVStockReport"
        Me.GVStockReport.OptionsBehavior.AutoExpandAllGroups = True
        Me.GVStockReport.OptionsBehavior.ReadOnly = True
        Me.GVStockReport.OptionsView.ColumnAutoWidth = False
        Me.GVStockReport.OptionsView.ShowFooter = True
        Me.GVStockReport.OptionsView.ShowGroupPanel = False
        '
        'GridColumn2
        '
        Me.GridColumn2.Caption = "Code"
        Me.GridColumn2.FieldName = "product_full_code"
        Me.GridColumn2.Name = "GridColumn2"
        Me.GridColumn2.Visible = True
        Me.GridColumn2.VisibleIndex = 0
        '
        'GridColumn3
        '
        Me.GridColumn3.Caption = "Description"
        Me.GridColumn3.FieldName = "product_display_name"
        Me.GridColumn3.Name = "GridColumn3"
        Me.GridColumn3.Visible = True
        Me.GridColumn3.VisibleIndex = 1
        '
        'GridColumn4
        '
        Me.GridColumn4.Caption = "BEG"
        Me.GridColumn4.DisplayFormat.FormatString = "N2"
        Me.GridColumn4.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumn4.FieldName = "qty_beg"
        Me.GridColumn4.Name = "GridColumn4"
        Me.GridColumn4.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "qty_beg", "{0:N2}")})
        Me.GridColumn4.Visible = True
        Me.GridColumn4.VisibleIndex = 2
        '
        'GridColumn5
        '
        Me.GridColumn5.Caption = "REC"
        Me.GridColumn5.DisplayFormat.FormatString = "N2"
        Me.GridColumn5.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumn5.FieldName = "qty_rec"
        Me.GridColumn5.Name = "GridColumn5"
        Me.GridColumn5.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "qty_rec", "{0:N2}")})
        Me.GridColumn5.Visible = True
        Me.GridColumn5.VisibleIndex = 3
        '
        'GridColumn7
        '
        Me.GridColumn7.Caption = "PIS"
        Me.GridColumn7.DisplayFormat.FormatString = "N2"
        Me.GridColumn7.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumn7.FieldName = "qty_pis"
        Me.GridColumn7.Name = "GridColumn7"
        Me.GridColumn7.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "qty_pis", "{0:N2}")})
        Me.GridColumn7.Visible = True
        Me.GridColumn7.VisibleIndex = 4
        '
        'GridColumn9
        '
        Me.GridColumn9.Caption = "Retur (SUP)"
        Me.GridColumn9.DisplayFormat.FormatString = "N2"
        Me.GridColumn9.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumn9.FieldName = "qty_retur_sup"
        Me.GridColumn9.Name = "GridColumn9"
        Me.GridColumn9.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "qty_retur_sup", "{0:N2}")})
        Me.GridColumn9.Visible = True
        Me.GridColumn9.VisibleIndex = 5
        '
        'GridColumn1
        '
        Me.GridColumn1.Caption = "Retur (WH)"
        Me.GridColumn1.DisplayFormat.FormatString = "N2"
        Me.GridColumn1.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumn1.FieldName = "qty_retur_wh"
        Me.GridColumn1.Name = "GridColumn1"
        Me.GridColumn1.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "qty_retur_wh", "{0:N2}")})
        Me.GridColumn1.Visible = True
        Me.GridColumn1.VisibleIndex = 6
        '
        'GridColumn13
        '
        Me.GridColumn13.Caption = "ADJ"
        Me.GridColumn13.DisplayFormat.FormatString = "N2"
        Me.GridColumn13.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumn13.FieldName = "qty_adj"
        Me.GridColumn13.Name = "GridColumn13"
        Me.GridColumn13.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "qty_adj", "{0:N2}")})
        Me.GridColumn13.Visible = True
        Me.GridColumn13.VisibleIndex = 7
        '
        'GridColumn14
        '
        Me.GridColumn14.Caption = "RJK"
        Me.GridColumn14.DisplayFormat.FormatString = "N2"
        Me.GridColumn14.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumn14.FieldName = "qty_rjk"
        Me.GridColumn14.Name = "GridColumn14"
        Me.GridColumn14.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "qty_rjk", "{0:N2}")})
        Me.GridColumn14.Visible = True
        Me.GridColumn14.VisibleIndex = 8
        '
        'GridColumn16
        '
        Me.GridColumn16.Caption = "Price"
        Me.GridColumn16.DisplayFormat.FormatString = "N2"
        Me.GridColumn16.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumn16.FieldName = "design_cop"
        Me.GridColumn16.Name = "GridColumn16"
        Me.GridColumn16.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "design_cop", "{0:N2}")})
        Me.GridColumn16.Visible = True
        Me.GridColumn16.VisibleIndex = 9
        '
        'GridColumn15
        '
        Me.GridColumn15.Caption = "END"
        Me.GridColumn15.DisplayFormat.FormatString = "N2"
        Me.GridColumn15.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumn15.FieldName = "qty_end"
        Me.GridColumn15.Name = "GridColumn15"
        Me.GridColumn15.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "qty_end", "{0:N2}")})
        Me.GridColumn15.Visible = True
        Me.GridColumn15.VisibleIndex = 10
        '
        'GridColumn17
        '
        Me.GridColumn17.Caption = "Amount"
        Me.GridColumn17.DisplayFormat.FormatString = "N2"
        Me.GridColumn17.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumn17.FieldName = "amount"
        Me.GridColumn17.Name = "GridColumn17"
        Me.GridColumn17.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "amount", "{0:N2}")})
        Me.GridColumn17.Visible = True
        Me.GridColumn17.VisibleIndex = 11
        '
        'GroupControl1
        '
        Me.GroupControl1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat
        Me.GroupControl1.CaptionLocation = DevExpress.Utils.Locations.Left
        Me.GroupControl1.Controls.Add(Me.LabelControl9)
        Me.GroupControl1.Controls.Add(Me.SLEType)
        Me.GroupControl1.Controls.Add(Me.SBPrintStock)
        Me.GroupControl1.Controls.Add(Me.DEStockTo)
        Me.GroupControl1.Controls.Add(Me.DEStockFrom)
        Me.GroupControl1.Controls.Add(Me.LabelControl28)
        Me.GroupControl1.Controls.Add(Me.LabelControl31)
        Me.GroupControl1.Controls.Add(Me.SBStockView)
        Me.GroupControl1.Dock = System.Windows.Forms.DockStyle.Top
        Me.GroupControl1.Location = New System.Drawing.Point(0, 0)
        Me.GroupControl1.Name = "GroupControl1"
        Me.GroupControl1.Size = New System.Drawing.Size(1066, 54)
        Me.GroupControl1.TabIndex = 20
        Me.GroupControl1.Text = "Filter"
        '
        'SBPrintStock
        '
        Me.SBPrintStock.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SBPrintStock.Appearance.Options.UseFont = True
        Me.SBPrintStock.Location = New System.Drawing.Point(632, 26)
        Me.SBPrintStock.Name = "SBPrintStock"
        Me.SBPrintStock.Size = New System.Drawing.Size(60, 23)
        Me.SBPrintStock.TabIndex = 14
        Me.SBPrintStock.Text = "Print"
        '
        'DEStockTo
        '
        Me.DEStockTo.EditValue = Nothing
        Me.DEStockTo.Location = New System.Drawing.Point(384, 28)
        Me.DEStockTo.Name = "DEStockTo"
        Me.DEStockTo.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.[False]
        Me.DEStockTo.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.DEStockTo.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.DEStockTo.Properties.DisplayFormat.FormatString = "dd MMMM yyyy"
        Me.DEStockTo.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.DEStockTo.Properties.EditFormat.FormatString = "dd MMMM yyyy"
        Me.DEStockTo.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.DEStockTo.Properties.Mask.EditMask = "dd MMMM yyyy"
        Me.DEStockTo.Properties.Mask.UseMaskAsDisplayFormat = True
        Me.DEStockTo.Size = New System.Drawing.Size(176, 20)
        Me.DEStockTo.TabIndex = 13
        '
        'DEStockFrom
        '
        Me.DEStockFrom.EditValue = Nothing
        Me.DEStockFrom.Location = New System.Drawing.Point(191, 28)
        Me.DEStockFrom.Name = "DEStockFrom"
        Me.DEStockFrom.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.[False]
        Me.DEStockFrom.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.DEStockFrom.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.DEStockFrom.Properties.DisplayFormat.FormatString = "dd MMMM yyyy"
        Me.DEStockFrom.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.DEStockFrom.Properties.EditFormat.FormatString = "dd MMMM yyyy"
        Me.DEStockFrom.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.DEStockFrom.Properties.Mask.EditMask = "dd MMMM yyyy"
        Me.DEStockFrom.Properties.Mask.UseMaskAsDisplayFormat = True
        Me.DEStockFrom.Size = New System.Drawing.Size(176, 20)
        Me.DEStockFrom.TabIndex = 12
        '
        'LabelControl28
        '
        Me.LabelControl28.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl28.Location = New System.Drawing.Point(195, 9)
        Me.LabelControl28.Name = "LabelControl28"
        Me.LabelControl28.Size = New System.Drawing.Size(24, 13)
        Me.LabelControl28.TabIndex = 11
        Me.LabelControl28.Text = "From"
        '
        'LabelControl31
        '
        Me.LabelControl31.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl31.Location = New System.Drawing.Point(384, 9)
        Me.LabelControl31.Name = "LabelControl31"
        Me.LabelControl31.Size = New System.Drawing.Size(12, 13)
        Me.LabelControl31.TabIndex = 2
        Me.LabelControl31.Text = "To"
        '
        'SBStockView
        '
        Me.SBStockView.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SBStockView.Appearance.Options.UseFont = True
        Me.SBStockView.Location = New System.Drawing.Point(566, 26)
        Me.SBStockView.Name = "SBStockView"
        Me.SBStockView.Size = New System.Drawing.Size(60, 23)
        Me.SBStockView.TabIndex = 6
        Me.SBStockView.Text = "View"
        '
        'LabelControl9
        '
        Me.LabelControl9.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl9.Location = New System.Drawing.Point(32, 11)
        Me.LabelControl9.Name = "LabelControl9"
        Me.LabelControl9.Size = New System.Drawing.Size(31, 13)
        Me.LabelControl9.TabIndex = 8905
        Me.LabelControl9.Text = "Status"
        '
        'SLEType
        '
        Me.SLEType.Location = New System.Drawing.Point(32, 28)
        Me.SLEType.Name = "SLEType"
        Me.SLEType.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SLEType.Properties.Appearance.Options.UseFont = True
        Me.SLEType.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.SLEType.Properties.ShowClearButton = False
        Me.SLEType.Properties.View = Me.GridView1
        Me.SLEType.Size = New System.Drawing.Size(153, 20)
        Me.SLEType.TabIndex = 8906
        '
        'GridView1
        '
        Me.GridView1.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumn18, Me.GridColumn19})
        Me.GridView1.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
        Me.GridView1.Name = "GridView1"
        Me.GridView1.OptionsSelection.EnableAppearanceFocusedCell = False
        Me.GridView1.OptionsView.ShowGroupPanel = False
        '
        'GridColumn18
        '
        Me.GridColumn18.Caption = "Id Type"
        Me.GridColumn18.FieldName = "id_cop_status"
        Me.GridColumn18.Name = "GridColumn18"
        '
        'GridColumn19
        '
        Me.GridColumn19.Caption = "Type"
        Me.GridColumn19.FieldName = "cop_status"
        Me.GridColumn19.Name = "GridColumn19"
        Me.GridColumn19.Visible = True
        Me.GridColumn19.VisibleIndex = 0
        '
        'FormStockQC
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1072, 528)
        Me.Controls.Add(Me.XTCStock)
        Me.Name = "FormStockQC"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Stock"
        CType(Me.XTCStock, System.ComponentModel.ISupportInitialize).EndInit()
        Me.XTCStock.ResumeLayout(False)
        Me.XTPSOH.ResumeLayout(False)
        CType(Me.GCSOH, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVSOH, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl1.ResumeLayout(False)
        CType(Me.PanelControl2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl2.ResumeLayout(False)
        Me.PanelControl2.PerformLayout()
        CType(Me.DEDate.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DEDate.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CEFindAllProduct.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtProduct.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SLESeason.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SearchLookUpEdit1View, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SLEVendor.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView14, System.ComponentModel.ISupportInitialize).EndInit()
        Me.XTPSC.ResumeLayout(False)
        CType(Me.GCSC, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVSC, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PanelControl3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl3.ResumeLayout(False)
        Me.PanelControl3.PerformLayout()
        CType(Me.PanelControl4, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl4.ResumeLayout(False)
        Me.PanelControl4.PerformLayout()
        CType(Me.TxtDescription.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtCode.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtVendor.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtProductSC.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.XTPStock.ResumeLayout(False)
        CType(Me.GroupControl6, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupControl6.ResumeLayout(False)
        CType(Me.GCStockReport, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVStockReport, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GroupControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupControl1.ResumeLayout(False)
        Me.GroupControl1.PerformLayout()
        CType(Me.DEStockTo.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DEStockTo.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DEStockFrom.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DEStockFrom.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SLEType.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents XTCStock As DevExpress.XtraTab.XtraTabControl
    Friend WithEvents XTPSOH As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents PanelControl1 As DevExpress.XtraEditors.PanelControl
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
    Friend WithEvents GCSOH As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVSOH As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumnid_prod_order_det As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnid_prod_order As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnvprod_order_number As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnvendor As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumncode As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnbarcode As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnname As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnsize As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnqty As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumncop As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnamount As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumncop_status As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents TxtProduct As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl5 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents BtnBrowseProduct As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents PanelControl2 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents CEFindAllProduct As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents GridColumnseason As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents LabelControl2 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents DEDate As DevExpress.XtraEditors.DateEdit
    Friend WithEvents XTPSC As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents GCSC As DevExpress.XtraGrid.GridControl
    Friend WithEvents PanelControl3 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents TxtProductSC As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl8 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents BSearchSC As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents GVSC As DevExpress.XtraGrid.Views.BandedGrid.BandedGridView
    Friend WithEvents GCSCSize As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents GCSCPONumber As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents GCSCNumber As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents GCSCDate As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents GCSCQTY As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents GCSCType As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents GCSCStockQC As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents GCSCStockNormal As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents GCSCStockMinor As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents GCSCStockMajor As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents GCSCStockAfkir As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BtnBrowsePOSC As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents LabelControl4 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents PanelControl4 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents TxtDescription As DevExpress.XtraEditors.TextEdit
    Friend WithEvents TxtCode As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl7 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents TxtVendor As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl6 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents GCSCTotal As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents GridBand1 As DevExpress.XtraGrid.Views.BandedGrid.GridBand
    Friend WithEvents gridBand2 As DevExpress.XtraGrid.Views.BandedGrid.GridBand
    Friend WithEvents GCSCIdCodeDetail As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents XTPStock As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents GroupControl1 As DevExpress.XtraEditors.GroupControl
    Friend WithEvents DEStockTo As DevExpress.XtraEditors.DateEdit
    Friend WithEvents DEStockFrom As DevExpress.XtraEditors.DateEdit
    Friend WithEvents LabelControl28 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl31 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents SBStockView As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents GroupControl6 As DevExpress.XtraEditors.GroupControl
    Friend WithEvents GCStockReport As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVStockReport As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumn2 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn3 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn4 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn5 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn7 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn9 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn1 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn13 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn14 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn16 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn15 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn17 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents SBPrintStock As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents LabelControl9 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents SLEType As DevExpress.XtraEditors.SearchLookUpEdit
    Friend WithEvents GridView1 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumn18 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn19 As DevExpress.XtraGrid.Columns.GridColumn
End Class
