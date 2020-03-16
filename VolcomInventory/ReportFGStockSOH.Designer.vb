<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class ReportFGStockSOH
    Inherits DevExpress.XtraReports.UI.XtraReport

    'XtraReport overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Designer
    'It can be modified using the Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.Detail = New DevExpress.XtraReports.UI.DetailBand()
        Me.TopMargin = New DevExpress.XtraReports.UI.TopMarginBand()
        Me.XrLabel2 = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLabel6 = New DevExpress.XtraReports.UI.XRLabel()
        Me.LabelUnit = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLabel5 = New DevExpress.XtraReports.UI.XRLabel()
        Me.LabelAccount = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLabel8 = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLabel7 = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLabeltitle = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLabel4 = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLabel3 = New DevExpress.XtraReports.UI.XRLabel()
        Me.LabelDesign = New DevExpress.XtraReports.UI.XRLabel()
        Me.BottomMargin = New DevExpress.XtraReports.UI.BottomMarginBand()
        Me.BackgroundWorker1 = New System.ComponentModel.BackgroundWorker()
        Me.DetailReportSize = New DevExpress.XtraReports.UI.DetailReportBand()
        Me.Detail1 = New DevExpress.XtraReports.UI.DetailBand()
        Me.WinControlContainer1 = New DevExpress.XtraReports.UI.WinControlContainer()
        Me.GCSOH = New DevExpress.XtraGrid.GridControl()
        Me.GVSOH = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumnid_product = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumncode_soh = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnname = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnmain_code = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnsize_soh = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnid_class = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnclass = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnid_design_cat = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumndesign_cat = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnstt = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnid_comp = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumncomp_number = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumncomp_name = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumngroup_store = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumngroup_store_desc = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnqty_avl = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnqty_rsv = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnqty_ttl = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnunit_price = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnunit_cost = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnamount = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnamount_cost = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnnormal_price = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnamount_normal = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.WinControlContainer2 = New DevExpress.XtraReports.UI.WinControlContainer()
        Me.GCSOHCode = New DevExpress.XtraGrid.GridControl()
        Me.GVSOHCode = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridView()
        Me.GridBand5 = New DevExpress.XtraGrid.Views.BandedGrid.GridBand()
        Me.BandedGridColumncode = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumnname = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.gridBand6 = New DevExpress.XtraGrid.Views.BandedGrid.GridBand()
        Me.BandedGridColumnclass = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumnstt = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumncomp_number = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumncomp_name = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumngroup_store = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumnsize_type = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.gridBand7 = New DevExpress.XtraGrid.Views.BandedGrid.GridBand()
        Me.BandedGridColumnavl_qty1 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumnavl_qty2 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumnavl_qty3 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumnavl_qty4 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumnavl_qty5 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumnavl_qty6 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumnavl_qty7 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumnavl_qty8 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumnavl_qty9 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumnavl_qty0 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumnavl_qty = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.gridBand8 = New DevExpress.XtraGrid.Views.BandedGrid.GridBand()
        Me.BandedGridColumnrsv_qty1 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumnrsv_qty2 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumnrsv_qty3 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumnrsv_qty4 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumnrsv_qty5 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumnrsv_qty6 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumnrsv_qty7 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumnrsv_qty8 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumnrsv_qty9 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumnrsv_qty0 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumnrsv_qty = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.gridBandTotal = New DevExpress.XtraGrid.Views.BandedGrid.GridBand()
        Me.BandedGridColumnttl_qty1 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumnttl_qty2 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumnttl_qty3 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumnttl_qty4 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumnttl_qty5 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumnttl_qty6 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumnttl_qty7 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumnttl_qty8 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumnttl_qty9 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumnttl_qty0 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumnttl_qty = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumnunit_price = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumnamount = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumnid_design = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumnid_class = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumnid_design_cat = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumndesign_cat = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumnid_comp = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumngroup_store_desc = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumnnormal_price = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumnunit_cost = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumnamount_normal = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumnamount_cost = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.DetailReportCode = New DevExpress.XtraReports.UI.DetailReportBand()
        Me.Detail3 = New DevExpress.XtraReports.UI.DetailBand()
        Me.XrPageInfo1 = New DevExpress.XtraReports.UI.XRPageInfo()
        CType(Me.GCSOH, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVSOH, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GCSOHCode, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVSOHCode, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
        '
        'Detail
        '
        Me.Detail.HeightF = 0!
        Me.Detail.Name = "Detail"
        Me.Detail.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
        Me.Detail.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
        '
        'TopMargin
        '
        Me.TopMargin.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.XrLabel2, Me.XrLabel6, Me.LabelUnit, Me.XrLabel5, Me.LabelAccount, Me.XrLabel8, Me.XrLabel7, Me.XrLabeltitle, Me.XrLabel4, Me.XrLabel3, Me.LabelDesign})
        Me.TopMargin.HeightF = 108.4155!
        Me.TopMargin.Name = "TopMargin"
        Me.TopMargin.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
        Me.TopMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
        '
        'XrLabel2
        '
        Me.XrLabel2.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.XrLabel2.LocationFloat = New DevExpress.Utils.PointFloat(0!, 72.22859!)
        Me.XrLabel2.Name = "XrLabel2"
        Me.XrLabel2.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel2.SizeF = New System.Drawing.SizeF(99.99999!, 16.18692!)
        Me.XrLabel2.StylePriority.UseFont = False
        Me.XrLabel2.StylePriority.UseTextAlignment = False
        Me.XrLabel2.Text = "UNIT"
        Me.XrLabel2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
        '
        'XrLabel6
        '
        Me.XrLabel6.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.XrLabel6.LocationFloat = New DevExpress.Utils.PointFloat(100.0!, 72.22859!)
        Me.XrLabel6.Name = "XrLabel6"
        Me.XrLabel6.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel6.SizeF = New System.Drawing.SizeF(12.49999!, 16.18693!)
        Me.XrLabel6.StylePriority.UseFont = False
        Me.XrLabel6.StylePriority.UseTextAlignment = False
        Me.XrLabel6.Text = ":"
        Me.XrLabel6.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
        '
        'LabelUnit
        '
        Me.LabelUnit.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelUnit.LocationFloat = New DevExpress.Utils.PointFloat(112.5!, 72.22862!)
        Me.LabelUnit.Name = "LabelUnit"
        Me.LabelUnit.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.LabelUnit.SizeF = New System.Drawing.SizeF(452.0833!, 16.18691!)
        Me.LabelUnit.StylePriority.UseFont = False
        Me.LabelUnit.StylePriority.UseTextAlignment = False
        Me.LabelUnit.Text = "-"
        Me.LabelUnit.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
        '
        'XrLabel5
        '
        Me.XrLabel5.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.XrLabel5.LocationFloat = New DevExpress.Utils.PointFloat(748.2499!, 16.85475!)
        Me.XrLabel5.Name = "XrLabel5"
        Me.XrLabel5.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel5.SizeF = New System.Drawing.SizeF(368.7501!, 22.99999!)
        Me.XrLabel5.StylePriority.UseFont = False
        Me.XrLabel5.StylePriority.UseTextAlignment = False
        Me.XrLabel5.Text = "PT VOLCOM INDONESIA"
        Me.XrLabel5.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
        '
        'LabelAccount
        '
        Me.LabelAccount.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelAccount.LocationFloat = New DevExpress.Utils.PointFloat(112.5!, 56.0417!)
        Me.LabelAccount.Name = "LabelAccount"
        Me.LabelAccount.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.LabelAccount.SizeF = New System.Drawing.SizeF(452.0833!, 16.18691!)
        Me.LabelAccount.StylePriority.UseFont = False
        Me.LabelAccount.StylePriority.UseTextAlignment = False
        Me.LabelAccount.Text = "-"
        Me.LabelAccount.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
        '
        'XrLabel8
        '
        Me.XrLabel8.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.XrLabel8.LocationFloat = New DevExpress.Utils.PointFloat(100.0!, 56.04167!)
        Me.XrLabel8.Name = "XrLabel8"
        Me.XrLabel8.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel8.SizeF = New System.Drawing.SizeF(12.49999!, 16.18693!)
        Me.XrLabel8.StylePriority.UseFont = False
        Me.XrLabel8.StylePriority.UseTextAlignment = False
        Me.XrLabel8.Text = ":"
        Me.XrLabel8.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
        '
        'XrLabel7
        '
        Me.XrLabel7.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.XrLabel7.LocationFloat = New DevExpress.Utils.PointFloat(0!, 56.04167!)
        Me.XrLabel7.Name = "XrLabel7"
        Me.XrLabel7.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel7.SizeF = New System.Drawing.SizeF(99.99999!, 16.18692!)
        Me.XrLabel7.StylePriority.UseFont = False
        Me.XrLabel7.StylePriority.UseTextAlignment = False
        Me.XrLabel7.Text = "ACCOUNT"
        Me.XrLabel7.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
        '
        'XrLabeltitle
        '
        Me.XrLabeltitle.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.XrLabeltitle.LocationFloat = New DevExpress.Utils.PointFloat(0!, 14.7714!)
        Me.XrLabeltitle.Name = "XrLabeltitle"
        Me.XrLabeltitle.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabeltitle.SizeF = New System.Drawing.SizeF(564.5833!, 25.08334!)
        Me.XrLabeltitle.StylePriority.UseFont = False
        Me.XrLabeltitle.StylePriority.UseTextAlignment = False
        Me.XrLabeltitle.Text = "STOCK ON HAND"
        Me.XrLabeltitle.TextAlignment = DevExpress.XtraPrinting.TextAlignment.BottomLeft
        '
        'XrLabel4
        '
        Me.XrLabel4.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.XrLabel4.LocationFloat = New DevExpress.Utils.PointFloat(0!, 39.85473!)
        Me.XrLabel4.Name = "XrLabel4"
        Me.XrLabel4.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel4.SizeF = New System.Drawing.SizeF(99.99999!, 16.18692!)
        Me.XrLabel4.StylePriority.UseFont = False
        Me.XrLabel4.StylePriority.UseTextAlignment = False
        Me.XrLabel4.Text = "DESIGN"
        Me.XrLabel4.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
        '
        'XrLabel3
        '
        Me.XrLabel3.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.XrLabel3.LocationFloat = New DevExpress.Utils.PointFloat(100.0!, 39.85473!)
        Me.XrLabel3.Name = "XrLabel3"
        Me.XrLabel3.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel3.SizeF = New System.Drawing.SizeF(12.49999!, 16.18693!)
        Me.XrLabel3.StylePriority.UseFont = False
        Me.XrLabel3.StylePriority.UseTextAlignment = False
        Me.XrLabel3.Text = ":"
        Me.XrLabel3.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
        '
        'LabelDesign
        '
        Me.LabelDesign.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelDesign.LocationFloat = New DevExpress.Utils.PointFloat(112.5!, 39.85479!)
        Me.LabelDesign.Name = "LabelDesign"
        Me.LabelDesign.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.LabelDesign.SizeF = New System.Drawing.SizeF(452.0833!, 16.18691!)
        Me.LabelDesign.StylePriority.UseFont = False
        Me.LabelDesign.StylePriority.UseTextAlignment = False
        Me.LabelDesign.Text = "-"
        Me.LabelDesign.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
        '
        'BottomMargin
        '
        Me.BottomMargin.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.XrPageInfo1})
        Me.BottomMargin.HeightF = 20.00001!
        Me.BottomMargin.Name = "BottomMargin"
        Me.BottomMargin.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
        Me.BottomMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
        '
        'DetailReportSize
        '
        Me.DetailReportSize.Bands.AddRange(New DevExpress.XtraReports.UI.Band() {Me.Detail1})
        Me.DetailReportSize.Level = 0
        Me.DetailReportSize.Name = "DetailReportSize"
        '
        'Detail1
        '
        Me.Detail1.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.WinControlContainer1})
        Me.Detail1.HeightF = 156.0!
        Me.Detail1.Name = "Detail1"
        '
        'WinControlContainer1
        '
        Me.WinControlContainer1.LocationFloat = New DevExpress.Utils.PointFloat(0!, 0!)
        Me.WinControlContainer1.Name = "WinControlContainer1"
        Me.WinControlContainer1.SizeF = New System.Drawing.SizeF(1117.0!, 156.0!)
        Me.WinControlContainer1.WinControl = Me.GCSOH
        '
        'GCSOH
        '
        Me.GCSOH.Location = New System.Drawing.Point(0, 0)
        Me.GCSOH.MainView = Me.GVSOH
        Me.GCSOH.Name = "GCSOH"
        Me.GCSOH.Size = New System.Drawing.Size(1072, 150)
        Me.GCSOH.TabIndex = 0
        Me.GCSOH.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVSOH})
        '
        'GVSOH
        '
        Me.GVSOH.ColumnPanelRowHeight = 30
        Me.GVSOH.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumnid_product, Me.GridColumncode_soh, Me.GridColumnname, Me.GridColumnmain_code, Me.GridColumnsize_soh, Me.GridColumnid_class, Me.GridColumnclass, Me.GridColumnid_design_cat, Me.GridColumndesign_cat, Me.GridColumnstt, Me.GridColumnid_comp, Me.GridColumncomp_number, Me.GridColumncomp_name, Me.GridColumngroup_store, Me.GridColumngroup_store_desc, Me.GridColumnqty_avl, Me.GridColumnqty_rsv, Me.GridColumnqty_ttl, Me.GridColumnunit_price, Me.GridColumnunit_cost, Me.GridColumnamount, Me.GridColumnamount_cost, Me.GridColumnnormal_price, Me.GridColumnamount_normal})
        Me.GVSOH.GridControl = Me.GCSOH
        Me.GVSOH.GroupSummary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "qty_avl", Me.GridColumnqty_avl, "{0:N0}"), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "qty_rsv", Me.GridColumnqty_rsv, "{0:N0}"), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "qty_ttl", Me.GridColumnqty_ttl, "{0:N0}"), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "amount", Me.GridColumnamount, "{0:N0}"), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "amount_normal", Me.GridColumnamount_normal, "{0:N0}"), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "amount_cost", Me.GridColumnamount_cost, "{0:N2}")})
        Me.GVSOH.Name = "GVSOH"
        Me.GVSOH.OptionsBehavior.ReadOnly = True
        Me.GVSOH.OptionsFind.AlwaysVisible = True
        Me.GVSOH.OptionsView.ColumnAutoWidth = False
        Me.GVSOH.OptionsView.ShowFooter = True
        Me.GVSOH.OptionsView.ShowGroupPanel = False
        '
        'GridColumnid_product
        '
        Me.GridColumnid_product.Caption = "id_product"
        Me.GridColumnid_product.FieldName = "id_product"
        Me.GridColumnid_product.Name = "GridColumnid_product"
        '
        'GridColumncode_soh
        '
        Me.GridColumncode_soh.Caption = "Code"
        Me.GridColumncode_soh.FieldName = "code"
        Me.GridColumncode_soh.Name = "GridColumncode_soh"
        Me.GridColumncode_soh.Visible = True
        Me.GridColumncode_soh.VisibleIndex = 0
        Me.GridColumncode_soh.Width = 98
        '
        'GridColumnname
        '
        Me.GridColumnname.Caption = "Description"
        Me.GridColumnname.FieldName = "name"
        Me.GridColumnname.Name = "GridColumnname"
        Me.GridColumnname.Visible = True
        Me.GridColumnname.VisibleIndex = 2
        Me.GridColumnname.Width = 157
        '
        'GridColumnmain_code
        '
        Me.GridColumnmain_code.Caption = "Main Code"
        Me.GridColumnmain_code.FieldName = "main_code"
        Me.GridColumnmain_code.Name = "GridColumnmain_code"
        Me.GridColumnmain_code.Visible = True
        Me.GridColumnmain_code.VisibleIndex = 1
        Me.GridColumnmain_code.Width = 84
        '
        'GridColumnsize_soh
        '
        Me.GridColumnsize_soh.Caption = "Size"
        Me.GridColumnsize_soh.FieldName = "size"
        Me.GridColumnsize_soh.Name = "GridColumnsize_soh"
        Me.GridColumnsize_soh.Visible = True
        Me.GridColumnsize_soh.VisibleIndex = 3
        Me.GridColumnsize_soh.Width = 48
        '
        'GridColumnid_class
        '
        Me.GridColumnid_class.Caption = "id class"
        Me.GridColumnid_class.FieldName = "id_class"
        Me.GridColumnid_class.Name = "GridColumnid_class"
        '
        'GridColumnclass
        '
        Me.GridColumnclass.Caption = "Class"
        Me.GridColumnclass.FieldName = "class"
        Me.GridColumnclass.Name = "GridColumnclass"
        Me.GridColumnclass.Visible = True
        Me.GridColumnclass.VisibleIndex = 4
        Me.GridColumnclass.Width = 50
        '
        'GridColumnid_design_cat
        '
        Me.GridColumnid_design_cat.Caption = "id_design_cat"
        Me.GridColumnid_design_cat.FieldName = "id_design_cat"
        Me.GridColumnid_design_cat.Name = "GridColumnid_design_cat"
        '
        'GridColumndesign_cat
        '
        Me.GridColumndesign_cat.Caption = "design_cat"
        Me.GridColumndesign_cat.FieldName = "design_cat"
        Me.GridColumndesign_cat.Name = "GridColumndesign_cat"
        '
        'GridColumnstt
        '
        Me.GridColumnstt.Caption = "Status"
        Me.GridColumnstt.FieldName = "stt"
        Me.GridColumnstt.Name = "GridColumnstt"
        Me.GridColumnstt.Visible = True
        Me.GridColumnstt.VisibleIndex = 5
        Me.GridColumnstt.Width = 46
        '
        'GridColumnid_comp
        '
        Me.GridColumnid_comp.Caption = "id_comp"
        Me.GridColumnid_comp.FieldName = "id_comp"
        Me.GridColumnid_comp.Name = "GridColumnid_comp"
        '
        'GridColumncomp_number
        '
        Me.GridColumncomp_number.Caption = "Account"
        Me.GridColumncomp_number.FieldName = "comp_number"
        Me.GridColumncomp_number.Name = "GridColumncomp_number"
        Me.GridColumncomp_number.Visible = True
        Me.GridColumncomp_number.VisibleIndex = 6
        Me.GridColumncomp_number.Width = 50
        '
        'GridColumncomp_name
        '
        Me.GridColumncomp_name.Caption = "Acc Description"
        Me.GridColumncomp_name.FieldName = "comp_name"
        Me.GridColumncomp_name.Name = "GridColumncomp_name"
        Me.GridColumncomp_name.Visible = True
        Me.GridColumncomp_name.VisibleIndex = 7
        Me.GridColumncomp_name.Width = 105
        '
        'GridColumngroup_store
        '
        Me.GridColumngroup_store.Caption = "Group"
        Me.GridColumngroup_store.FieldName = "group_store"
        Me.GridColumngroup_store.Name = "GridColumngroup_store"
        Me.GridColumngroup_store.Visible = True
        Me.GridColumngroup_store.VisibleIndex = 8
        Me.GridColumngroup_store.Width = 55
        '
        'GridColumngroup_store_desc
        '
        Me.GridColumngroup_store_desc.Caption = "Group Desc"
        Me.GridColumngroup_store_desc.FieldName = "group_store_desc"
        Me.GridColumngroup_store_desc.Name = "GridColumngroup_store_desc"
        '
        'GridColumnqty_avl
        '
        Me.GridColumnqty_avl.Caption = "Available"
        Me.GridColumnqty_avl.DisplayFormat.FormatString = "N0"
        Me.GridColumnqty_avl.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumnqty_avl.FieldName = "qty_avl"
        Me.GridColumnqty_avl.Name = "GridColumnqty_avl"
        Me.GridColumnqty_avl.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "qty_avl", "{0:N0}")})
        Me.GridColumnqty_avl.Visible = True
        Me.GridColumnqty_avl.VisibleIndex = 9
        '
        'GridColumnqty_rsv
        '
        Me.GridColumnqty_rsv.Caption = "Reserved"
        Me.GridColumnqty_rsv.DisplayFormat.FormatString = "N0"
        Me.GridColumnqty_rsv.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumnqty_rsv.FieldName = "qty_rsv"
        Me.GridColumnqty_rsv.Name = "GridColumnqty_rsv"
        Me.GridColumnqty_rsv.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "qty_rsv", "{0:N0}")})
        Me.GridColumnqty_rsv.Visible = True
        Me.GridColumnqty_rsv.VisibleIndex = 10
        '
        'GridColumnqty_ttl
        '
        Me.GridColumnqty_ttl.Caption = "Total Qty"
        Me.GridColumnqty_ttl.DisplayFormat.FormatString = "N0"
        Me.GridColumnqty_ttl.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumnqty_ttl.FieldName = "qty_ttl"
        Me.GridColumnqty_ttl.Name = "GridColumnqty_ttl"
        Me.GridColumnqty_ttl.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "qty_ttl", "{0:N0}")})
        Me.GridColumnqty_ttl.Visible = True
        Me.GridColumnqty_ttl.VisibleIndex = 11
        '
        'GridColumnunit_price
        '
        Me.GridColumnunit_price.Caption = "Unit Price"
        Me.GridColumnunit_price.DisplayFormat.FormatString = "N0"
        Me.GridColumnunit_price.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumnunit_price.FieldName = "unit_price"
        Me.GridColumnunit_price.Name = "GridColumnunit_price"
        Me.GridColumnunit_price.Visible = True
        Me.GridColumnunit_price.VisibleIndex = 12
        Me.GridColumnunit_price.Width = 54
        '
        'GridColumnunit_cost
        '
        Me.GridColumnunit_cost.Caption = "Unit Cost"
        Me.GridColumnunit_cost.DisplayFormat.FormatString = "N2"
        Me.GridColumnunit_cost.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumnunit_cost.FieldName = "unit_cost"
        Me.GridColumnunit_cost.Name = "GridColumnunit_cost"
        Me.GridColumnunit_cost.OptionsColumn.ShowInCustomizationForm = False
        '
        'GridColumnamount
        '
        Me.GridColumnamount.Caption = "Amount"
        Me.GridColumnamount.DisplayFormat.FormatString = "N0"
        Me.GridColumnamount.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumnamount.FieldName = "amount"
        Me.GridColumnamount.Name = "GridColumnamount"
        Me.GridColumnamount.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "amount", "{0:N0}")})
        Me.GridColumnamount.Visible = True
        Me.GridColumnamount.VisibleIndex = 13
        '
        'GridColumnamount_cost
        '
        Me.GridColumnamount_cost.Caption = "Amount Cost"
        Me.GridColumnamount_cost.DisplayFormat.FormatString = "N2"
        Me.GridColumnamount_cost.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumnamount_cost.FieldName = "amount_cost"
        Me.GridColumnamount_cost.Name = "GridColumnamount_cost"
        Me.GridColumnamount_cost.OptionsColumn.ShowInCustomizationForm = False
        Me.GridColumnamount_cost.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "amount_cost", "{0:N2}")})
        '
        'GridColumnnormal_price
        '
        Me.GridColumnnormal_price.Caption = "Normal Price"
        Me.GridColumnnormal_price.DisplayFormat.FormatString = "N0"
        Me.GridColumnnormal_price.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumnnormal_price.FieldName = "normal_price"
        Me.GridColumnnormal_price.Name = "GridColumnnormal_price"
        '
        'GridColumnamount_normal
        '
        Me.GridColumnamount_normal.Caption = "Amount Normal"
        Me.GridColumnamount_normal.DisplayFormat.FormatString = "N0"
        Me.GridColumnamount_normal.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumnamount_normal.FieldName = "amount_normal"
        Me.GridColumnamount_normal.Name = "GridColumnamount_normal"
        Me.GridColumnamount_normal.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "amount_normal", "{0:N0}")})
        '
        'WinControlContainer2
        '
        Me.WinControlContainer2.LocationFloat = New DevExpress.Utils.PointFloat(0.00003973643!, 0!)
        Me.WinControlContainer2.Name = "WinControlContainer2"
        Me.WinControlContainer2.SizeF = New System.Drawing.SizeF(1117.0!, 156.0!)
        Me.WinControlContainer2.WinControl = Me.GCSOHCode
        '
        'GCSOHCode
        '
        Me.GCSOHCode.Location = New System.Drawing.Point(0, 0)
        Me.GCSOHCode.MainView = Me.GVSOHCode
        Me.GCSOHCode.Name = "GCSOHCode"
        Me.GCSOHCode.Size = New System.Drawing.Size(1072, 150)
        Me.GCSOHCode.TabIndex = 0
        Me.GCSOHCode.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVSOHCode})
        '
        'GVSOHCode
        '
        Me.GVSOHCode.Bands.AddRange(New DevExpress.XtraGrid.Views.BandedGrid.GridBand() {Me.GridBand5, Me.gridBand6, Me.gridBand7, Me.gridBand8, Me.gridBandTotal})
        Me.GVSOHCode.ColumnPanelRowHeight = 35
        Me.GVSOHCode.Columns.AddRange(New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn() {Me.BandedGridColumnid_design, Me.BandedGridColumncode, Me.BandedGridColumnname, Me.BandedGridColumnid_class, Me.BandedGridColumnclass, Me.BandedGridColumnid_design_cat, Me.BandedGridColumndesign_cat, Me.BandedGridColumnstt, Me.BandedGridColumnid_comp, Me.BandedGridColumncomp_number, Me.BandedGridColumncomp_name, Me.BandedGridColumngroup_store, Me.BandedGridColumngroup_store_desc, Me.BandedGridColumnsize_type, Me.BandedGridColumnavl_qty1, Me.BandedGridColumnavl_qty2, Me.BandedGridColumnavl_qty3, Me.BandedGridColumnavl_qty4, Me.BandedGridColumnavl_qty5, Me.BandedGridColumnavl_qty6, Me.BandedGridColumnavl_qty7, Me.BandedGridColumnavl_qty8, Me.BandedGridColumnavl_qty9, Me.BandedGridColumnavl_qty0, Me.BandedGridColumnavl_qty, Me.BandedGridColumnrsv_qty1, Me.BandedGridColumnrsv_qty2, Me.BandedGridColumnrsv_qty3, Me.BandedGridColumnrsv_qty4, Me.BandedGridColumnrsv_qty5, Me.BandedGridColumnrsv_qty6, Me.BandedGridColumnrsv_qty7, Me.BandedGridColumnrsv_qty8, Me.BandedGridColumnrsv_qty9, Me.BandedGridColumnrsv_qty0, Me.BandedGridColumnrsv_qty, Me.BandedGridColumnttl_qty1, Me.BandedGridColumnttl_qty2, Me.BandedGridColumnttl_qty3, Me.BandedGridColumnttl_qty4, Me.BandedGridColumnttl_qty5, Me.BandedGridColumnttl_qty6, Me.BandedGridColumnttl_qty7, Me.BandedGridColumnttl_qty8, Me.BandedGridColumnttl_qty9, Me.BandedGridColumnttl_qty0, Me.BandedGridColumnttl_qty, Me.BandedGridColumnnormal_price, Me.BandedGridColumnunit_price, Me.BandedGridColumnunit_cost, Me.BandedGridColumnamount_normal, Me.BandedGridColumnamount, Me.BandedGridColumnamount_cost})
        Me.GVSOHCode.GridControl = Me.GCSOHCode
        Me.GVSOHCode.GroupSummary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "avl_qty1", Me.BandedGridColumnavl_qty1, "{0:N0}"), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "avl_qty2", Me.BandedGridColumnavl_qty2, "{0:N0}"), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "avl_qty3", Me.BandedGridColumnavl_qty3, "{0:N0}"), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "avl_qty4", Me.BandedGridColumnavl_qty4, "{0:N0}"), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "avl_qty5", Me.BandedGridColumnavl_qty5, "{0:N0}"), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "avl_qty6", Me.BandedGridColumnavl_qty6, "{0:N0}"), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "avl_qty7", Me.BandedGridColumnavl_qty7, "{0:N0}"), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "avl_qty8", Me.BandedGridColumnavl_qty8, "{0:N0}"), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "avl_qty9", Me.BandedGridColumnavl_qty9, "{0:N0}"), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "avl_qty0", Me.BandedGridColumnavl_qty0, "{0:N0}"), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "avl_qty", Me.BandedGridColumnavl_qty, "{0:N0}"), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "rsv_qty1", Me.BandedGridColumnrsv_qty1, "{0:N0}"), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "rsv_qty2", Me.BandedGridColumnrsv_qty2, "{0:N0}"), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "rsv_qty3", Me.BandedGridColumnrsv_qty3, "{0:N0}"), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "rsv_qty4", Me.BandedGridColumnrsv_qty4, "{0:N0}"), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "rsv_qty5", Me.BandedGridColumnrsv_qty5, "{0:N0}"), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "rsv_qty6", Me.BandedGridColumnrsv_qty6, "{0:N0}"), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "rsv_qty7", Me.BandedGridColumnrsv_qty7, "{0:N0}"), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "rsv_qty8", Me.BandedGridColumnrsv_qty8, "{0:N0}"), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "rsv_qty9", Me.BandedGridColumnrsv_qty9, "{0:N0}"), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "rsv_qty0", Me.BandedGridColumnrsv_qty0, "{0:N0}"), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "rsv_qty", Me.BandedGridColumnrsv_qty, "{0:N0}"), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "ttl_qty1", Me.BandedGridColumnttl_qty1, "{0:N0})"), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "ttl_qty2", Me.BandedGridColumnttl_qty2, "{0:N0}"), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "ttl_qty3", Me.BandedGridColumnttl_qty3, "{0:N0}"), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "ttl_qty4", Me.BandedGridColumnttl_qty4, "{0:N0}"), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "ttl_qty5", Me.BandedGridColumnttl_qty5, "{0:N0}"), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "ttl_qty6", Me.BandedGridColumnttl_qty6, "{0:N0}"), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "ttl_qty7", Me.BandedGridColumnttl_qty7, "{0:N0}"), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "ttl_qty8", Me.BandedGridColumnttl_qty8, "{0:N0}"), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "ttl_qty9", Me.BandedGridColumnttl_qty9, "{0:N0}"), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "ttl_qty0", Me.BandedGridColumnttl_qty0, "{0:N0}"), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "ttl_qty", Me.BandedGridColumnttl_qty, "{0:N0}"), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "amount_normal", Me.BandedGridColumnamount_normal, "{0:N0}")})
        Me.GVSOHCode.Name = "GVSOHCode"
        Me.GVSOHCode.OptionsBehavior.ReadOnly = True
        Me.GVSOHCode.OptionsFind.AlwaysVisible = True
        Me.GVSOHCode.OptionsPrint.AllowMultilineHeaders = True
        Me.GVSOHCode.OptionsView.ColumnAutoWidth = False
        Me.GVSOHCode.OptionsView.ShowFooter = True
        Me.GVSOHCode.OptionsView.ShowGroupPanel = False
        '
        'GridBand5
        '
        Me.GridBand5.Columns.Add(Me.BandedGridColumncode)
        Me.GridBand5.Columns.Add(Me.BandedGridColumnname)
        Me.GridBand5.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left
        Me.GridBand5.Name = "GridBand5"
        Me.GridBand5.VisibleIndex = 0
        Me.GridBand5.Width = 241
        '
        'BandedGridColumncode
        '
        Me.BandedGridColumncode.Caption = "Code"
        Me.BandedGridColumncode.FieldName = "code"
        Me.BandedGridColumncode.Name = "BandedGridColumncode"
        Me.BandedGridColumncode.Visible = True
        Me.BandedGridColumncode.Width = 77
        '
        'BandedGridColumnname
        '
        Me.BandedGridColumnname.Caption = "Description"
        Me.BandedGridColumnname.FieldName = "name"
        Me.BandedGridColumnname.Name = "BandedGridColumnname"
        Me.BandedGridColumnname.Visible = True
        Me.BandedGridColumnname.Width = 164
        '
        'gridBand6
        '
        Me.gridBand6.Columns.Add(Me.BandedGridColumnclass)
        Me.gridBand6.Columns.Add(Me.BandedGridColumnstt)
        Me.gridBand6.Columns.Add(Me.BandedGridColumncomp_number)
        Me.gridBand6.Columns.Add(Me.BandedGridColumncomp_name)
        Me.gridBand6.Columns.Add(Me.BandedGridColumngroup_store)
        Me.gridBand6.Columns.Add(Me.BandedGridColumnsize_type)
        Me.gridBand6.Name = "gridBand6"
        Me.gridBand6.VisibleIndex = 1
        Me.gridBand6.Width = 472
        '
        'BandedGridColumnclass
        '
        Me.BandedGridColumnclass.Caption = "Class"
        Me.BandedGridColumnclass.FieldName = "class"
        Me.BandedGridColumnclass.Name = "BandedGridColumnclass"
        Me.BandedGridColumnclass.Visible = True
        Me.BandedGridColumnclass.Width = 70
        '
        'BandedGridColumnstt
        '
        Me.BandedGridColumnstt.Caption = "Status"
        Me.BandedGridColumnstt.FieldName = "stt"
        Me.BandedGridColumnstt.Name = "BandedGridColumnstt"
        Me.BandedGridColumnstt.Visible = True
        Me.BandedGridColumnstt.Width = 59
        '
        'BandedGridColumncomp_number
        '
        Me.BandedGridColumncomp_number.Caption = "Account"
        Me.BandedGridColumncomp_number.FieldName = "comp_number"
        Me.BandedGridColumncomp_number.Name = "BandedGridColumncomp_number"
        Me.BandedGridColumncomp_number.Visible = True
        Me.BandedGridColumncomp_number.Width = 65
        '
        'BandedGridColumncomp_name
        '
        Me.BandedGridColumncomp_name.Caption = "Acc Description"
        Me.BandedGridColumncomp_name.FieldName = "comp_name"
        Me.BandedGridColumncomp_name.Name = "BandedGridColumncomp_name"
        Me.BandedGridColumncomp_name.Visible = True
        Me.BandedGridColumncomp_name.Width = 130
        '
        'BandedGridColumngroup_store
        '
        Me.BandedGridColumngroup_store.Caption = "Store Group"
        Me.BandedGridColumngroup_store.FieldName = "group_store"
        Me.BandedGridColumngroup_store.Name = "BandedGridColumngroup_store"
        Me.BandedGridColumngroup_store.Visible = True
        Me.BandedGridColumngroup_store.Width = 73
        '
        'BandedGridColumnsize_type
        '
        Me.BandedGridColumnsize_type.Caption = "Sizetype"
        Me.BandedGridColumnsize_type.FieldName = "size_type"
        Me.BandedGridColumnsize_type.Name = "BandedGridColumnsize_type"
        Me.BandedGridColumnsize_type.Visible = True
        '
        'gridBand7
        '
        Me.gridBand7.Caption = "AVAILABLE"
        Me.gridBand7.Columns.Add(Me.BandedGridColumnavl_qty1)
        Me.gridBand7.Columns.Add(Me.BandedGridColumnavl_qty2)
        Me.gridBand7.Columns.Add(Me.BandedGridColumnavl_qty3)
        Me.gridBand7.Columns.Add(Me.BandedGridColumnavl_qty4)
        Me.gridBand7.Columns.Add(Me.BandedGridColumnavl_qty5)
        Me.gridBand7.Columns.Add(Me.BandedGridColumnavl_qty6)
        Me.gridBand7.Columns.Add(Me.BandedGridColumnavl_qty7)
        Me.gridBand7.Columns.Add(Me.BandedGridColumnavl_qty8)
        Me.gridBand7.Columns.Add(Me.BandedGridColumnavl_qty9)
        Me.gridBand7.Columns.Add(Me.BandedGridColumnavl_qty0)
        Me.gridBand7.Columns.Add(Me.BandedGridColumnavl_qty)
        Me.gridBand7.Name = "gridBand7"
        Me.gridBand7.VisibleIndex = 2
        Me.gridBand7.Width = 825
        '
        'BandedGridColumnavl_qty1
        '
        Me.BandedGridColumnavl_qty1.Caption = "avl_qty1"
        Me.BandedGridColumnavl_qty1.DisplayFormat.FormatString = "N0"
        Me.BandedGridColumnavl_qty1.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.BandedGridColumnavl_qty1.FieldName = "avl_qty1"
        Me.BandedGridColumnavl_qty1.Name = "BandedGridColumnavl_qty1"
        Me.BandedGridColumnavl_qty1.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "avl_qty1", "{0:N0}")})
        Me.BandedGridColumnavl_qty1.Visible = True
        '
        'BandedGridColumnavl_qty2
        '
        Me.BandedGridColumnavl_qty2.Caption = "avl_qty2"
        Me.BandedGridColumnavl_qty2.DisplayFormat.FormatString = "N0"
        Me.BandedGridColumnavl_qty2.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.BandedGridColumnavl_qty2.FieldName = "avl_qty2"
        Me.BandedGridColumnavl_qty2.Name = "BandedGridColumnavl_qty2"
        Me.BandedGridColumnavl_qty2.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "avl_qty2", "{0:N0}")})
        Me.BandedGridColumnavl_qty2.Visible = True
        '
        'BandedGridColumnavl_qty3
        '
        Me.BandedGridColumnavl_qty3.Caption = "avl_qty3"
        Me.BandedGridColumnavl_qty3.DisplayFormat.FormatString = "N0"
        Me.BandedGridColumnavl_qty3.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.BandedGridColumnavl_qty3.FieldName = "avl_qty3"
        Me.BandedGridColumnavl_qty3.Name = "BandedGridColumnavl_qty3"
        Me.BandedGridColumnavl_qty3.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "avl_qty3", "{0:N0}")})
        Me.BandedGridColumnavl_qty3.Visible = True
        '
        'BandedGridColumnavl_qty4
        '
        Me.BandedGridColumnavl_qty4.Caption = "avl_qty4"
        Me.BandedGridColumnavl_qty4.DisplayFormat.FormatString = "N0"
        Me.BandedGridColumnavl_qty4.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.BandedGridColumnavl_qty4.FieldName = "avl_qty4"
        Me.BandedGridColumnavl_qty4.Name = "BandedGridColumnavl_qty4"
        Me.BandedGridColumnavl_qty4.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "avl_qty4", "{0:N0}")})
        Me.BandedGridColumnavl_qty4.Visible = True
        '
        'BandedGridColumnavl_qty5
        '
        Me.BandedGridColumnavl_qty5.Caption = "avl_qty5"
        Me.BandedGridColumnavl_qty5.DisplayFormat.FormatString = "N0"
        Me.BandedGridColumnavl_qty5.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.BandedGridColumnavl_qty5.FieldName = "avl_qty5"
        Me.BandedGridColumnavl_qty5.Name = "BandedGridColumnavl_qty5"
        Me.BandedGridColumnavl_qty5.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "avl_qty5", "{0:N0}")})
        Me.BandedGridColumnavl_qty5.Visible = True
        '
        'BandedGridColumnavl_qty6
        '
        Me.BandedGridColumnavl_qty6.Caption = "avl_qty6"
        Me.BandedGridColumnavl_qty6.DisplayFormat.FormatString = "N0"
        Me.BandedGridColumnavl_qty6.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.BandedGridColumnavl_qty6.FieldName = "avl_qty6"
        Me.BandedGridColumnavl_qty6.Name = "BandedGridColumnavl_qty6"
        Me.BandedGridColumnavl_qty6.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "avl_qty6", "{0:N0}")})
        Me.BandedGridColumnavl_qty6.Visible = True
        '
        'BandedGridColumnavl_qty7
        '
        Me.BandedGridColumnavl_qty7.Caption = "avl_qty7"
        Me.BandedGridColumnavl_qty7.DisplayFormat.FormatString = "N0"
        Me.BandedGridColumnavl_qty7.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.BandedGridColumnavl_qty7.FieldName = "avl_qty7"
        Me.BandedGridColumnavl_qty7.Name = "BandedGridColumnavl_qty7"
        Me.BandedGridColumnavl_qty7.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "avl_qty7", "{0:N0}")})
        Me.BandedGridColumnavl_qty7.Visible = True
        '
        'BandedGridColumnavl_qty8
        '
        Me.BandedGridColumnavl_qty8.Caption = "avl_qty8"
        Me.BandedGridColumnavl_qty8.DisplayFormat.FormatString = "N0"
        Me.BandedGridColumnavl_qty8.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.BandedGridColumnavl_qty8.FieldName = "avl_qty8"
        Me.BandedGridColumnavl_qty8.Name = "BandedGridColumnavl_qty8"
        Me.BandedGridColumnavl_qty8.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "avl_qty8", "{0:N0}")})
        Me.BandedGridColumnavl_qty8.Visible = True
        '
        'BandedGridColumnavl_qty9
        '
        Me.BandedGridColumnavl_qty9.Caption = "avl_qty9"
        Me.BandedGridColumnavl_qty9.DisplayFormat.FormatString = "N0"
        Me.BandedGridColumnavl_qty9.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.BandedGridColumnavl_qty9.FieldName = "avl_qty9"
        Me.BandedGridColumnavl_qty9.Name = "BandedGridColumnavl_qty9"
        Me.BandedGridColumnavl_qty9.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "avl_qty9", "{0:N0}")})
        Me.BandedGridColumnavl_qty9.Visible = True
        '
        'BandedGridColumnavl_qty0
        '
        Me.BandedGridColumnavl_qty0.Caption = "avl_qty0"
        Me.BandedGridColumnavl_qty0.DisplayFormat.FormatString = "N0"
        Me.BandedGridColumnavl_qty0.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.BandedGridColumnavl_qty0.FieldName = "avl_qty0"
        Me.BandedGridColumnavl_qty0.Name = "BandedGridColumnavl_qty0"
        Me.BandedGridColumnavl_qty0.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "avl_qty0", "{0:N0}")})
        Me.BandedGridColumnavl_qty0.Visible = True
        '
        'BandedGridColumnavl_qty
        '
        Me.BandedGridColumnavl_qty.Caption = "Total"
        Me.BandedGridColumnavl_qty.DisplayFormat.FormatString = "N0"
        Me.BandedGridColumnavl_qty.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.BandedGridColumnavl_qty.FieldName = "avl_qty"
        Me.BandedGridColumnavl_qty.Name = "BandedGridColumnavl_qty"
        Me.BandedGridColumnavl_qty.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "avl_qty", "{0:N0}")})
        Me.BandedGridColumnavl_qty.Visible = True
        '
        'gridBand8
        '
        Me.gridBand8.Caption = "RESERVED"
        Me.gridBand8.Columns.Add(Me.BandedGridColumnrsv_qty1)
        Me.gridBand8.Columns.Add(Me.BandedGridColumnrsv_qty2)
        Me.gridBand8.Columns.Add(Me.BandedGridColumnrsv_qty3)
        Me.gridBand8.Columns.Add(Me.BandedGridColumnrsv_qty4)
        Me.gridBand8.Columns.Add(Me.BandedGridColumnrsv_qty5)
        Me.gridBand8.Columns.Add(Me.BandedGridColumnrsv_qty6)
        Me.gridBand8.Columns.Add(Me.BandedGridColumnrsv_qty7)
        Me.gridBand8.Columns.Add(Me.BandedGridColumnrsv_qty8)
        Me.gridBand8.Columns.Add(Me.BandedGridColumnrsv_qty9)
        Me.gridBand8.Columns.Add(Me.BandedGridColumnrsv_qty0)
        Me.gridBand8.Columns.Add(Me.BandedGridColumnrsv_qty)
        Me.gridBand8.Name = "gridBand8"
        Me.gridBand8.VisibleIndex = 3
        Me.gridBand8.Width = 825
        '
        'BandedGridColumnrsv_qty1
        '
        Me.BandedGridColumnrsv_qty1.Caption = "rsv_qty1"
        Me.BandedGridColumnrsv_qty1.DisplayFormat.FormatString = "N0"
        Me.BandedGridColumnrsv_qty1.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.BandedGridColumnrsv_qty1.FieldName = "rsv_qty1"
        Me.BandedGridColumnrsv_qty1.Name = "BandedGridColumnrsv_qty1"
        Me.BandedGridColumnrsv_qty1.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "rsv_qty1", "{0:N0}")})
        Me.BandedGridColumnrsv_qty1.Visible = True
        '
        'BandedGridColumnrsv_qty2
        '
        Me.BandedGridColumnrsv_qty2.Caption = "rsv_qty2"
        Me.BandedGridColumnrsv_qty2.DisplayFormat.FormatString = "N0"
        Me.BandedGridColumnrsv_qty2.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.BandedGridColumnrsv_qty2.FieldName = "rsv_qty2"
        Me.BandedGridColumnrsv_qty2.Name = "BandedGridColumnrsv_qty2"
        Me.BandedGridColumnrsv_qty2.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "rsv_qty2", "{0:N0}")})
        Me.BandedGridColumnrsv_qty2.Visible = True
        '
        'BandedGridColumnrsv_qty3
        '
        Me.BandedGridColumnrsv_qty3.Caption = "rsv_qty3"
        Me.BandedGridColumnrsv_qty3.DisplayFormat.FormatString = "N0"
        Me.BandedGridColumnrsv_qty3.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.BandedGridColumnrsv_qty3.FieldName = "rsv_qty3"
        Me.BandedGridColumnrsv_qty3.Name = "BandedGridColumnrsv_qty3"
        Me.BandedGridColumnrsv_qty3.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "rsv_qty3", "{0:N0}")})
        Me.BandedGridColumnrsv_qty3.Visible = True
        '
        'BandedGridColumnrsv_qty4
        '
        Me.BandedGridColumnrsv_qty4.Caption = "rsv_qty4"
        Me.BandedGridColumnrsv_qty4.DisplayFormat.FormatString = "N0"
        Me.BandedGridColumnrsv_qty4.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.BandedGridColumnrsv_qty4.FieldName = "rsv_qty4"
        Me.BandedGridColumnrsv_qty4.Name = "BandedGridColumnrsv_qty4"
        Me.BandedGridColumnrsv_qty4.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "rsv_qty4", "{0:N0}")})
        Me.BandedGridColumnrsv_qty4.Visible = True
        '
        'BandedGridColumnrsv_qty5
        '
        Me.BandedGridColumnrsv_qty5.Caption = "rsv_qty5"
        Me.BandedGridColumnrsv_qty5.DisplayFormat.FormatString = "N0"
        Me.BandedGridColumnrsv_qty5.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.BandedGridColumnrsv_qty5.FieldName = "rsv_qty5"
        Me.BandedGridColumnrsv_qty5.Name = "BandedGridColumnrsv_qty5"
        Me.BandedGridColumnrsv_qty5.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "rsv_qty5", "{0:N0}")})
        Me.BandedGridColumnrsv_qty5.Visible = True
        '
        'BandedGridColumnrsv_qty6
        '
        Me.BandedGridColumnrsv_qty6.Caption = "rsv_qty6"
        Me.BandedGridColumnrsv_qty6.DisplayFormat.FormatString = "N0"
        Me.BandedGridColumnrsv_qty6.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.BandedGridColumnrsv_qty6.FieldName = "rsv_qty6"
        Me.BandedGridColumnrsv_qty6.Name = "BandedGridColumnrsv_qty6"
        Me.BandedGridColumnrsv_qty6.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "rsv_qty6", "{0:N0}")})
        Me.BandedGridColumnrsv_qty6.Visible = True
        '
        'BandedGridColumnrsv_qty7
        '
        Me.BandedGridColumnrsv_qty7.Caption = "rsv_qty7"
        Me.BandedGridColumnrsv_qty7.DisplayFormat.FormatString = "N0"
        Me.BandedGridColumnrsv_qty7.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.BandedGridColumnrsv_qty7.FieldName = "rsv_qty7"
        Me.BandedGridColumnrsv_qty7.Name = "BandedGridColumnrsv_qty7"
        Me.BandedGridColumnrsv_qty7.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "rsv_qty7", "{0:N0}")})
        Me.BandedGridColumnrsv_qty7.Visible = True
        '
        'BandedGridColumnrsv_qty8
        '
        Me.BandedGridColumnrsv_qty8.Caption = "rsv_qty8"
        Me.BandedGridColumnrsv_qty8.DisplayFormat.FormatString = "N0"
        Me.BandedGridColumnrsv_qty8.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.BandedGridColumnrsv_qty8.FieldName = "rsv_qty8"
        Me.BandedGridColumnrsv_qty8.Name = "BandedGridColumnrsv_qty8"
        Me.BandedGridColumnrsv_qty8.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "rsv_qty8", "{0:N0}")})
        Me.BandedGridColumnrsv_qty8.Visible = True
        '
        'BandedGridColumnrsv_qty9
        '
        Me.BandedGridColumnrsv_qty9.Caption = "rsv_qty9"
        Me.BandedGridColumnrsv_qty9.DisplayFormat.FormatString = "N0"
        Me.BandedGridColumnrsv_qty9.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.BandedGridColumnrsv_qty9.FieldName = "rsv_qty9"
        Me.BandedGridColumnrsv_qty9.Name = "BandedGridColumnrsv_qty9"
        Me.BandedGridColumnrsv_qty9.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "rsv_qty9", "{0:N0}")})
        Me.BandedGridColumnrsv_qty9.Visible = True
        '
        'BandedGridColumnrsv_qty0
        '
        Me.BandedGridColumnrsv_qty0.Caption = "rsv_qty0"
        Me.BandedGridColumnrsv_qty0.DisplayFormat.FormatString = "N0"
        Me.BandedGridColumnrsv_qty0.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.BandedGridColumnrsv_qty0.FieldName = "rsv_qty0"
        Me.BandedGridColumnrsv_qty0.Name = "BandedGridColumnrsv_qty0"
        Me.BandedGridColumnrsv_qty0.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "rsv_qty0", "{0:N0}")})
        Me.BandedGridColumnrsv_qty0.Visible = True
        '
        'BandedGridColumnrsv_qty
        '
        Me.BandedGridColumnrsv_qty.Caption = "Total"
        Me.BandedGridColumnrsv_qty.DisplayFormat.FormatString = "N0"
        Me.BandedGridColumnrsv_qty.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.BandedGridColumnrsv_qty.FieldName = "rsv_qty"
        Me.BandedGridColumnrsv_qty.Name = "BandedGridColumnrsv_qty"
        Me.BandedGridColumnrsv_qty.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "rsv_qty", "{0:N0}")})
        Me.BandedGridColumnrsv_qty.Visible = True
        '
        'gridBandTotal
        '
        Me.gridBandTotal.Caption = "TOTAL"
        Me.gridBandTotal.Columns.Add(Me.BandedGridColumnttl_qty1)
        Me.gridBandTotal.Columns.Add(Me.BandedGridColumnttl_qty2)
        Me.gridBandTotal.Columns.Add(Me.BandedGridColumnttl_qty3)
        Me.gridBandTotal.Columns.Add(Me.BandedGridColumnttl_qty4)
        Me.gridBandTotal.Columns.Add(Me.BandedGridColumnttl_qty5)
        Me.gridBandTotal.Columns.Add(Me.BandedGridColumnttl_qty6)
        Me.gridBandTotal.Columns.Add(Me.BandedGridColumnttl_qty7)
        Me.gridBandTotal.Columns.Add(Me.BandedGridColumnttl_qty8)
        Me.gridBandTotal.Columns.Add(Me.BandedGridColumnttl_qty9)
        Me.gridBandTotal.Columns.Add(Me.BandedGridColumnttl_qty0)
        Me.gridBandTotal.Columns.Add(Me.BandedGridColumnttl_qty)
        Me.gridBandTotal.Columns.Add(Me.BandedGridColumnunit_price)
        Me.gridBandTotal.Columns.Add(Me.BandedGridColumnamount)
        Me.gridBandTotal.Name = "gridBandTotal"
        Me.gridBandTotal.VisibleIndex = 4
        Me.gridBandTotal.Width = 975
        '
        'BandedGridColumnttl_qty1
        '
        Me.BandedGridColumnttl_qty1.Caption = "ttl_qty1"
        Me.BandedGridColumnttl_qty1.DisplayFormat.FormatString = "N0"
        Me.BandedGridColumnttl_qty1.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.BandedGridColumnttl_qty1.FieldName = "ttl_qty1"
        Me.BandedGridColumnttl_qty1.Name = "BandedGridColumnttl_qty1"
        Me.BandedGridColumnttl_qty1.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "ttl_qty1", "{0:N0}")})
        Me.BandedGridColumnttl_qty1.Visible = True
        '
        'BandedGridColumnttl_qty2
        '
        Me.BandedGridColumnttl_qty2.Caption = "ttl_qty2"
        Me.BandedGridColumnttl_qty2.DisplayFormat.FormatString = "N0"
        Me.BandedGridColumnttl_qty2.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.BandedGridColumnttl_qty2.FieldName = "ttl_qty2"
        Me.BandedGridColumnttl_qty2.Name = "BandedGridColumnttl_qty2"
        Me.BandedGridColumnttl_qty2.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "ttl_qty2", "{0:N0}")})
        Me.BandedGridColumnttl_qty2.Visible = True
        '
        'BandedGridColumnttl_qty3
        '
        Me.BandedGridColumnttl_qty3.Caption = "ttl_qty3"
        Me.BandedGridColumnttl_qty3.DisplayFormat.FormatString = "N0"
        Me.BandedGridColumnttl_qty3.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.BandedGridColumnttl_qty3.FieldName = "ttl_qty3"
        Me.BandedGridColumnttl_qty3.Name = "BandedGridColumnttl_qty3"
        Me.BandedGridColumnttl_qty3.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "ttl_qty3", "{0:N0}")})
        Me.BandedGridColumnttl_qty3.Visible = True
        '
        'BandedGridColumnttl_qty4
        '
        Me.BandedGridColumnttl_qty4.Caption = "ttl_qty4"
        Me.BandedGridColumnttl_qty4.DisplayFormat.FormatString = "N0"
        Me.BandedGridColumnttl_qty4.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.BandedGridColumnttl_qty4.FieldName = "ttl_qty4"
        Me.BandedGridColumnttl_qty4.Name = "BandedGridColumnttl_qty4"
        Me.BandedGridColumnttl_qty4.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "ttl_qty4", "{0:N0}")})
        Me.BandedGridColumnttl_qty4.Visible = True
        '
        'BandedGridColumnttl_qty5
        '
        Me.BandedGridColumnttl_qty5.Caption = "ttl_qty5"
        Me.BandedGridColumnttl_qty5.DisplayFormat.FormatString = "N0"
        Me.BandedGridColumnttl_qty5.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.BandedGridColumnttl_qty5.FieldName = "ttl_qty5"
        Me.BandedGridColumnttl_qty5.Name = "BandedGridColumnttl_qty5"
        Me.BandedGridColumnttl_qty5.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "ttl_qty5", "{0:N0}")})
        Me.BandedGridColumnttl_qty5.Visible = True
        '
        'BandedGridColumnttl_qty6
        '
        Me.BandedGridColumnttl_qty6.Caption = "ttl_qty6"
        Me.BandedGridColumnttl_qty6.DisplayFormat.FormatString = "N0"
        Me.BandedGridColumnttl_qty6.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.BandedGridColumnttl_qty6.FieldName = "ttl_qty6"
        Me.BandedGridColumnttl_qty6.Name = "BandedGridColumnttl_qty6"
        Me.BandedGridColumnttl_qty6.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "ttl_qty6", "{0:N0}")})
        Me.BandedGridColumnttl_qty6.Visible = True
        '
        'BandedGridColumnttl_qty7
        '
        Me.BandedGridColumnttl_qty7.Caption = "ttl_qty7"
        Me.BandedGridColumnttl_qty7.DisplayFormat.FormatString = "N0"
        Me.BandedGridColumnttl_qty7.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.BandedGridColumnttl_qty7.FieldName = "ttl_qty7"
        Me.BandedGridColumnttl_qty7.Name = "BandedGridColumnttl_qty7"
        Me.BandedGridColumnttl_qty7.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "ttl_qty7", "{0:N0}")})
        Me.BandedGridColumnttl_qty7.Visible = True
        '
        'BandedGridColumnttl_qty8
        '
        Me.BandedGridColumnttl_qty8.Caption = "ttl_qty8"
        Me.BandedGridColumnttl_qty8.DisplayFormat.FormatString = "N0"
        Me.BandedGridColumnttl_qty8.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.BandedGridColumnttl_qty8.FieldName = "ttl_qty8"
        Me.BandedGridColumnttl_qty8.Name = "BandedGridColumnttl_qty8"
        Me.BandedGridColumnttl_qty8.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "ttl_qty8", "{0:N0}")})
        Me.BandedGridColumnttl_qty8.Visible = True
        '
        'BandedGridColumnttl_qty9
        '
        Me.BandedGridColumnttl_qty9.Caption = "ttl_qty9"
        Me.BandedGridColumnttl_qty9.DisplayFormat.FormatString = "N0"
        Me.BandedGridColumnttl_qty9.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.BandedGridColumnttl_qty9.FieldName = "ttl_qty9"
        Me.BandedGridColumnttl_qty9.Name = "BandedGridColumnttl_qty9"
        Me.BandedGridColumnttl_qty9.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "ttl_qty9", "{0:N0}")})
        Me.BandedGridColumnttl_qty9.Visible = True
        '
        'BandedGridColumnttl_qty0
        '
        Me.BandedGridColumnttl_qty0.Caption = "ttl_qty0"
        Me.BandedGridColumnttl_qty0.DisplayFormat.FormatString = "N0"
        Me.BandedGridColumnttl_qty0.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.BandedGridColumnttl_qty0.FieldName = "ttl_qty0"
        Me.BandedGridColumnttl_qty0.Name = "BandedGridColumnttl_qty0"
        Me.BandedGridColumnttl_qty0.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "ttl_qty0", "{0:N0}")})
        Me.BandedGridColumnttl_qty0.Visible = True
        '
        'BandedGridColumnttl_qty
        '
        Me.BandedGridColumnttl_qty.Caption = "Total"
        Me.BandedGridColumnttl_qty.DisplayFormat.FormatString = "N0"
        Me.BandedGridColumnttl_qty.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.BandedGridColumnttl_qty.FieldName = "ttl_qty"
        Me.BandedGridColumnttl_qty.Name = "BandedGridColumnttl_qty"
        Me.BandedGridColumnttl_qty.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "ttl_qty", "{0:N0}")})
        Me.BandedGridColumnttl_qty.Visible = True
        '
        'BandedGridColumnunit_price
        '
        Me.BandedGridColumnunit_price.Caption = "Unit Price"
        Me.BandedGridColumnunit_price.DisplayFormat.FormatString = "N0"
        Me.BandedGridColumnunit_price.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.BandedGridColumnunit_price.FieldName = "unit_price"
        Me.BandedGridColumnunit_price.Name = "BandedGridColumnunit_price"
        Me.BandedGridColumnunit_price.Visible = True
        '
        'BandedGridColumnamount
        '
        Me.BandedGridColumnamount.Caption = "Amount"
        Me.BandedGridColumnamount.DisplayFormat.FormatString = "N0"
        Me.BandedGridColumnamount.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.BandedGridColumnamount.FieldName = "amount"
        Me.BandedGridColumnamount.Name = "BandedGridColumnamount"
        Me.BandedGridColumnamount.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "amount", "{0:N0}")})
        Me.BandedGridColumnamount.Visible = True
        '
        'BandedGridColumnid_design
        '
        Me.BandedGridColumnid_design.Caption = "id_design"
        Me.BandedGridColumnid_design.FieldName = "id_design"
        Me.BandedGridColumnid_design.Name = "BandedGridColumnid_design"
        '
        'BandedGridColumnid_class
        '
        Me.BandedGridColumnid_class.Caption = "id_class"
        Me.BandedGridColumnid_class.FieldName = "id_class"
        Me.BandedGridColumnid_class.Name = "BandedGridColumnid_class"
        '
        'BandedGridColumnid_design_cat
        '
        Me.BandedGridColumnid_design_cat.Caption = "id_design_cat"
        Me.BandedGridColumnid_design_cat.FieldName = "id_design_cat"
        Me.BandedGridColumnid_design_cat.Name = "BandedGridColumnid_design_cat"
        '
        'BandedGridColumndesign_cat
        '
        Me.BandedGridColumndesign_cat.Caption = "design_cat"
        Me.BandedGridColumndesign_cat.FieldName = "design_cat"
        Me.BandedGridColumndesign_cat.Name = "BandedGridColumndesign_cat"
        '
        'BandedGridColumnid_comp
        '
        Me.BandedGridColumnid_comp.Caption = "id_comp"
        Me.BandedGridColumnid_comp.FieldName = "id_comp"
        Me.BandedGridColumnid_comp.Name = "BandedGridColumnid_comp"
        '
        'BandedGridColumngroup_store_desc
        '
        Me.BandedGridColumngroup_store_desc.Caption = "Store Group Desc"
        Me.BandedGridColumngroup_store_desc.FieldName = "group_store_desc"
        Me.BandedGridColumngroup_store_desc.Name = "BandedGridColumngroup_store_desc"
        '
        'BandedGridColumnnormal_price
        '
        Me.BandedGridColumnnormal_price.Caption = "Normal Price"
        Me.BandedGridColumnnormal_price.DisplayFormat.FormatString = "N0"
        Me.BandedGridColumnnormal_price.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.BandedGridColumnnormal_price.FieldName = "normal_price"
        Me.BandedGridColumnnormal_price.Name = "BandedGridColumnnormal_price"
        Me.BandedGridColumnnormal_price.Visible = True
        '
        'BandedGridColumnunit_cost
        '
        Me.BandedGridColumnunit_cost.Caption = "Unit Cost"
        Me.BandedGridColumnunit_cost.DisplayFormat.FormatString = "N2"
        Me.BandedGridColumnunit_cost.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.BandedGridColumnunit_cost.FieldName = "unit_cost"
        Me.BandedGridColumnunit_cost.Name = "BandedGridColumnunit_cost"
        Me.BandedGridColumnunit_cost.OptionsColumn.ShowInCustomizationForm = False
        '
        'BandedGridColumnamount_normal
        '
        Me.BandedGridColumnamount_normal.Caption = "Amount Normal"
        Me.BandedGridColumnamount_normal.DisplayFormat.FormatString = "N0"
        Me.BandedGridColumnamount_normal.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.BandedGridColumnamount_normal.FieldName = "amount_normal"
        Me.BandedGridColumnamount_normal.Name = "BandedGridColumnamount_normal"
        Me.BandedGridColumnamount_normal.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "amount_normal", "{0:N0}")})
        '
        'BandedGridColumnamount_cost
        '
        Me.BandedGridColumnamount_cost.Caption = "Amount Cost"
        Me.BandedGridColumnamount_cost.DisplayFormat.FormatString = "N2"
        Me.BandedGridColumnamount_cost.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.BandedGridColumnamount_cost.FieldName = "amount_cost"
        Me.BandedGridColumnamount_cost.Name = "BandedGridColumnamount_cost"
        Me.BandedGridColumnamount_cost.OptionsColumn.ShowInCustomizationForm = False
        Me.BandedGridColumnamount_cost.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "amount_cost", "{0:N2}")})
        '
        'DetailReportCode
        '
        Me.DetailReportCode.Bands.AddRange(New DevExpress.XtraReports.UI.Band() {Me.Detail3})
        Me.DetailReportCode.Level = 1
        Me.DetailReportCode.Name = "DetailReportCode"
        '
        'Detail3
        '
        Me.Detail3.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.WinControlContainer2})
        Me.Detail3.HeightF = 156.0!
        Me.Detail3.Name = "Detail3"
        '
        'XrPageInfo1
        '
        Me.XrPageInfo1.Borders = DevExpress.XtraPrinting.BorderSide.None
        Me.XrPageInfo1.Font = New System.Drawing.Font("Lucida Sans", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.XrPageInfo1.Format = "Page {0} of {1}"
        Me.XrPageInfo1.LocationFloat = New DevExpress.Utils.PointFloat(966.9999!, 0!)
        Me.XrPageInfo1.Name = "XrPageInfo1"
        Me.XrPageInfo1.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrPageInfo1.SizeF = New System.Drawing.SizeF(150.0!, 18.71793!)
        Me.XrPageInfo1.StylePriority.UseBorders = False
        Me.XrPageInfo1.StylePriority.UseFont = False
        Me.XrPageInfo1.StylePriority.UseTextAlignment = False
        Me.XrPageInfo1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
        '
        'ReportFGStockSOH
        '
        Me.Bands.AddRange(New DevExpress.XtraReports.UI.Band() {Me.Detail, Me.TopMargin, Me.BottomMargin, Me.DetailReportSize, Me.DetailReportCode})
        Me.Landscape = True
        Me.Margins = New System.Drawing.Printing.Margins(26, 26, 108, 20)
        Me.PageHeight = 827
        Me.PageWidth = 1169
        Me.PaperKind = System.Drawing.Printing.PaperKind.A4
        Me.ScriptLanguage = DevExpress.XtraReports.ScriptLanguage.VisualBasic
        Me.Version = "15.1"
        CType(Me.GCSOH, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVSOH, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GCSOHCode, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVSOHCode, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me, System.ComponentModel.ISupportInitialize).EndInit()

    End Sub
    Friend WithEvents Detail As DevExpress.XtraReports.UI.DetailBand
    Friend WithEvents TopMargin As DevExpress.XtraReports.UI.TopMarginBand
    Friend WithEvents BottomMargin As DevExpress.XtraReports.UI.BottomMarginBand
    Friend WithEvents XrLabel5 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents LabelAccount As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel8 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel7 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabeltitle As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel4 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel3 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents LabelDesign As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel2 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel6 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents LabelUnit As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents BackgroundWorker1 As System.ComponentModel.BackgroundWorker
    Friend WithEvents DetailReportSize As DevExpress.XtraReports.UI.DetailReportBand
    Friend WithEvents Detail1 As DevExpress.XtraReports.UI.DetailBand
    Friend WithEvents WinControlContainer1 As DevExpress.XtraReports.UI.WinControlContainer
    Friend WithEvents GCSOH As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVSOH As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumnid_product As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumncode_soh As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnname As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnmain_code As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnsize_soh As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnid_class As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnclass As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnid_design_cat As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumndesign_cat As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnstt As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnid_comp As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumncomp_number As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumncomp_name As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumngroup_store As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumngroup_store_desc As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnqty_avl As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnqty_rsv As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnqty_ttl As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnunit_price As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnunit_cost As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnamount As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnamount_cost As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnnormal_price As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnamount_normal As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents WinControlContainer2 As DevExpress.XtraReports.UI.WinControlContainer
    Friend WithEvents GCSOHCode As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVSOHCode As DevExpress.XtraGrid.Views.BandedGrid.BandedGridView
    Friend WithEvents GridBand5 As DevExpress.XtraGrid.Views.BandedGrid.GridBand
    Friend WithEvents BandedGridColumncode As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumnname As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents gridBand6 As DevExpress.XtraGrid.Views.BandedGrid.GridBand
    Friend WithEvents BandedGridColumnclass As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumnstt As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumncomp_number As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumncomp_name As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumngroup_store As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumnsize_type As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents gridBand7 As DevExpress.XtraGrid.Views.BandedGrid.GridBand
    Friend WithEvents BandedGridColumnavl_qty1 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumnavl_qty2 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumnavl_qty3 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumnavl_qty4 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumnavl_qty5 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumnavl_qty6 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumnavl_qty7 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumnavl_qty8 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumnavl_qty9 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumnavl_qty0 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumnavl_qty As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents gridBand8 As DevExpress.XtraGrid.Views.BandedGrid.GridBand
    Friend WithEvents BandedGridColumnrsv_qty1 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumnrsv_qty2 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumnrsv_qty3 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumnrsv_qty4 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumnrsv_qty5 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumnrsv_qty6 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumnrsv_qty7 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumnrsv_qty8 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumnrsv_qty9 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumnrsv_qty0 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumnrsv_qty As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents gridBandTotal As DevExpress.XtraGrid.Views.BandedGrid.GridBand
    Friend WithEvents BandedGridColumnttl_qty1 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumnttl_qty2 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumnttl_qty3 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumnttl_qty4 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumnttl_qty5 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumnttl_qty6 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumnttl_qty7 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumnttl_qty8 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumnttl_qty9 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumnttl_qty0 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumnttl_qty As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumnunit_price As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumnamount As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumnid_design As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumnid_class As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumnid_design_cat As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumndesign_cat As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumnid_comp As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumngroup_store_desc As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumnnormal_price As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumnunit_cost As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumnamount_normal As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumnamount_cost As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents DetailReportCode As DevExpress.XtraReports.UI.DetailReportBand
    Friend WithEvents Detail3 As DevExpress.XtraReports.UI.DetailBand
    Friend WithEvents XrPageInfo1 As DevExpress.XtraReports.UI.XRPageInfo
End Class
