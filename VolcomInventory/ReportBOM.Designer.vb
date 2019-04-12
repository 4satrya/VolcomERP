<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class ReportBOM
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
        Me.XrLabel6 = New DevExpress.XtraReports.UI.XRLabel()
        Me.LTerm = New DevExpress.XtraReports.UI.XRLabel()
        Me.LProductName = New DevExpress.XtraReports.UI.XRLabel()
        Me.LBomName = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLabel5 = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLabel4 = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLabel3 = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLabel2 = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLabel1 = New DevExpress.XtraReports.UI.XRLabel()
        Me.TopMargin = New DevExpress.XtraReports.UI.TopMarginBand()
        Me.LVendor = New DevExpress.XtraReports.UI.XRLabel()
        Me.L2Vendor = New DevExpress.XtraReports.UI.XRLabel()
        Me.L1Vendor = New DevExpress.XtraReports.UI.XRLabel()
        Me.L2QtyOrder = New DevExpress.XtraReports.UI.XRLabel()
        Me.L1QtyOrder = New DevExpress.XtraReports.UI.XRLabel()
        Me.LQtyOrder = New DevExpress.XtraReports.UI.XRLabel()
        Me.LTitle = New DevExpress.XtraReports.UI.XRLabel()
        Me.LBomDate = New DevExpress.XtraReports.UI.XRLabel()
        Me.BottomMargin = New DevExpress.XtraReports.UI.BottomMarginBand()
        Me.XrPageInfo1 = New DevExpress.XtraReports.UI.XRPageInfo()
        Me.DetailReport = New DevExpress.XtraReports.UI.DetailReportBand()
        Me.DetBOMMat = New DevExpress.XtraReports.UI.DetailBand()
        Me.WinControlContainer1 = New DevExpress.XtraReports.UI.WinControlContainer()
        Me.GCBomMat = New DevExpress.XtraGrid.GridControl()
        Me.GridView1 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.ColCode = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.ColName = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.ColSize = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.ColQty = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.ColPrice = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.ColTotal = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.Cat = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.ColIDCat = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnisCOST = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnCurrency = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnVendPrice = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnKurs = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnQtyOrder = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnCostPerPcs = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnColor = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.XrControlStyle1 = New DevExpress.XtraReports.UI.XRControlStyle()
        Me.XrControlStyle2 = New DevExpress.XtraReports.UI.XRControlStyle()
        Me.XrControlStyle3 = New DevExpress.XtraReports.UI.XRControlStyle()
        Me.PageFooter = New DevExpress.XtraReports.UI.PageFooterBand()
        Me.XrTable1 = New DevExpress.XtraReports.UI.XRTable()
        Me.XrTableRow1 = New DevExpress.XtraReports.UI.XRTableRow()
        Me.XrTableCell1 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.XrLabel8 = New DevExpress.XtraReports.UI.XRLabel()
        CType(Me.GCBomMat, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.XrTable1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
        '
        'Detail
        '
        Me.Detail.Expanded = False
        Me.Detail.HeightF = 63.14101!
        Me.Detail.Name = "Detail"
        Me.Detail.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
        Me.Detail.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
        '
        'XrLabel6
        '
        Me.XrLabel6.Font = New System.Drawing.Font("Times New Roman", 10.0!, System.Drawing.FontStyle.Bold)
        Me.XrLabel6.LocationFloat = New DevExpress.Utils.PointFloat(126.1721!, 78.79164!)
        Me.XrLabel6.Name = "XrLabel6"
        Me.XrLabel6.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel6.SizeF = New System.Drawing.SizeF(13.54172!, 14.99999!)
        Me.XrLabel6.StyleName = "XrControlStyle2"
        Me.XrLabel6.StylePriority.UseFont = False
        Me.XrLabel6.Text = ":"
        '
        'LTerm
        '
        Me.LTerm.Font = New System.Drawing.Font("Times New Roman", 10.0!)
        Me.LTerm.LocationFloat = New DevExpress.Utils.PointFloat(139.7138!, 79.79164!)
        Me.LTerm.Name = "LTerm"
        Me.LTerm.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.LTerm.SizeF = New System.Drawing.SizeF(212.2861!, 15.0!)
        Me.LTerm.StyleName = "XrControlStyle2"
        Me.LTerm.StylePriority.UseFont = False
        Me.LTerm.Text = "BOM"
        '
        'LProductName
        '
        Me.LProductName.Font = New System.Drawing.Font("Times New Roman", 10.0!)
        Me.LProductName.LocationFloat = New DevExpress.Utils.PointFloat(139.7138!, 48.79165!)
        Me.LProductName.Name = "LProductName"
        Me.LProductName.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.LProductName.SizeF = New System.Drawing.SizeF(212.2862!, 15.0!)
        Me.LProductName.StyleName = "XrControlStyle2"
        Me.LProductName.StylePriority.UseFont = False
        Me.LProductName.Text = "BOM"
        '
        'LBomName
        '
        Me.LBomName.Font = New System.Drawing.Font("Times New Roman", 10.0!)
        Me.LBomName.LocationFloat = New DevExpress.Utils.PointFloat(139.7138!, 63.79164!)
        Me.LBomName.Name = "LBomName"
        Me.LBomName.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.LBomName.SizeF = New System.Drawing.SizeF(212.2861!, 16.00001!)
        Me.LBomName.StyleName = "XrControlStyle2"
        Me.LBomName.StylePriority.UseFont = False
        Me.LBomName.Text = "BOM"
        '
        'XrLabel5
        '
        Me.XrLabel5.Font = New System.Drawing.Font("Times New Roman", 10.0!, System.Drawing.FontStyle.Bold)
        Me.XrLabel5.LocationFloat = New DevExpress.Utils.PointFloat(126.1721!, 63.79164!)
        Me.XrLabel5.Name = "XrLabel5"
        Me.XrLabel5.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel5.SizeF = New System.Drawing.SizeF(13.54172!, 15.0!)
        Me.XrLabel5.StyleName = "XrControlStyle2"
        Me.XrLabel5.StylePriority.UseFont = False
        Me.XrLabel5.Text = ":"
        '
        'XrLabel4
        '
        Me.XrLabel4.Font = New System.Drawing.Font("Times New Roman", 10.0!, System.Drawing.FontStyle.Bold)
        Me.XrLabel4.LocationFloat = New DevExpress.Utils.PointFloat(126.1721!, 48.79165!)
        Me.XrLabel4.Name = "XrLabel4"
        Me.XrLabel4.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel4.SizeF = New System.Drawing.SizeF(13.54167!, 15.0!)
        Me.XrLabel4.StyleName = "XrControlStyle2"
        Me.XrLabel4.StylePriority.UseFont = False
        Me.XrLabel4.Text = ":"
        '
        'XrLabel3
        '
        Me.XrLabel3.Font = New System.Drawing.Font("Times New Roman", 10.0!, System.Drawing.FontStyle.Bold)
        Me.XrLabel3.LocationFloat = New DevExpress.Utils.PointFloat(0.00003178914!, 78.79164!)
        Me.XrLabel3.Name = "XrLabel3"
        Me.XrLabel3.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel3.SizeF = New System.Drawing.SizeF(126.1702!, 15.0!)
        Me.XrLabel3.StyleName = "XrControlStyle2"
        Me.XrLabel3.StylePriority.UseFont = False
        Me.XrLabel3.Text = "Term of Production"
        '
        'XrLabel2
        '
        Me.XrLabel2.Font = New System.Drawing.Font("Times New Roman", 10.0!, System.Drawing.FontStyle.Bold)
        Me.XrLabel2.LocationFloat = New DevExpress.Utils.PointFloat(0.00003178914!, 63.79164!)
        Me.XrLabel2.Name = "XrLabel2"
        Me.XrLabel2.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel2.SizeF = New System.Drawing.SizeF(126.1702!, 15.0!)
        Me.XrLabel2.StyleName = "XrControlStyle2"
        Me.XrLabel2.StylePriority.UseFont = False
        Me.XrLabel2.Text = "Method"
        '
        'XrLabel1
        '
        Me.XrLabel1.Font = New System.Drawing.Font("Times New Roman", 10.0!, System.Drawing.FontStyle.Bold)
        Me.XrLabel1.LocationFloat = New DevExpress.Utils.PointFloat(0.00003178914!, 48.79165!)
        Me.XrLabel1.Name = "XrLabel1"
        Me.XrLabel1.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel1.SizeF = New System.Drawing.SizeF(126.1702!, 15.0!)
        Me.XrLabel1.StyleName = "XrControlStyle2"
        Me.XrLabel1.StylePriority.UseFont = False
        Me.XrLabel1.Text = "Product"
        '
        'TopMargin
        '
        Me.TopMargin.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.LVendor, Me.L2Vendor, Me.L1Vendor, Me.L2QtyOrder, Me.L1QtyOrder, Me.LQtyOrder, Me.LTitle, Me.LBomDate, Me.LTerm, Me.XrLabel2, Me.XrLabel3, Me.XrLabel4, Me.XrLabel5, Me.LBomName, Me.LProductName, Me.XrLabel1, Me.XrLabel6})
        Me.TopMargin.Font = New System.Drawing.Font("Times New Roman", 9.75!)
        Me.TopMargin.HeightF = 119.0!
        Me.TopMargin.Name = "TopMargin"
        Me.TopMargin.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
        Me.TopMargin.StylePriority.UseFont = False
        Me.TopMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
        '
        'LVendor
        '
        Me.LVendor.Font = New System.Drawing.Font("Times New Roman", 10.0!)
        Me.LVendor.LocationFloat = New DevExpress.Utils.PointFloat(437.5451!, 48.79165!)
        Me.LVendor.Name = "LVendor"
        Me.LVendor.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.LVendor.SizeF = New System.Drawing.SizeF(189.4547!, 29.99999!)
        Me.LVendor.StyleName = "XrControlStyle2"
        Me.LVendor.StylePriority.UseFont = False
        Me.LVendor.Text = "BOM"
        '
        'L2Vendor
        '
        Me.L2Vendor.Font = New System.Drawing.Font("Times New Roman", 10.0!, System.Drawing.FontStyle.Bold)
        Me.L2Vendor.LocationFloat = New DevExpress.Utils.PointFloat(424.0035!, 48.79166!)
        Me.L2Vendor.Name = "L2Vendor"
        Me.L2Vendor.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.L2Vendor.SizeF = New System.Drawing.SizeF(13.54172!, 29.99998!)
        Me.L2Vendor.StyleName = "XrControlStyle2"
        Me.L2Vendor.StylePriority.UseFont = False
        Me.L2Vendor.Text = ":"
        '
        'L1Vendor
        '
        Me.L1Vendor.Font = New System.Drawing.Font("Times New Roman", 10.0!, System.Drawing.FontStyle.Bold)
        Me.L1Vendor.LocationFloat = New DevExpress.Utils.PointFloat(351.9999!, 48.79165!)
        Me.L1Vendor.Name = "L1Vendor"
        Me.L1Vendor.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.L1Vendor.SizeF = New System.Drawing.SizeF(72.00357!, 29.99998!)
        Me.L1Vendor.StyleName = "XrControlStyle2"
        Me.L1Vendor.StylePriority.UseFont = False
        Me.L1Vendor.Text = "Vendor"
        '
        'L2QtyOrder
        '
        Me.L2QtyOrder.Font = New System.Drawing.Font("Times New Roman", 10.0!, System.Drawing.FontStyle.Bold)
        Me.L2QtyOrder.LocationFloat = New DevExpress.Utils.PointFloat(424.0035!, 78.79163!)
        Me.L2QtyOrder.Name = "L2QtyOrder"
        Me.L2QtyOrder.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.L2QtyOrder.SizeF = New System.Drawing.SizeF(13.54172!, 14.99999!)
        Me.L2QtyOrder.StyleName = "XrControlStyle2"
        Me.L2QtyOrder.StylePriority.UseFont = False
        Me.L2QtyOrder.Text = ":"
        '
        'L1QtyOrder
        '
        Me.L1QtyOrder.Font = New System.Drawing.Font("Times New Roman", 10.0!, System.Drawing.FontStyle.Bold)
        Me.L1QtyOrder.LocationFloat = New DevExpress.Utils.PointFloat(351.9999!, 78.79163!)
        Me.L1QtyOrder.Name = "L1QtyOrder"
        Me.L1QtyOrder.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.L1QtyOrder.SizeF = New System.Drawing.SizeF(72.00357!, 15.0!)
        Me.L1QtyOrder.StyleName = "XrControlStyle2"
        Me.L1QtyOrder.StylePriority.UseFont = False
        Me.L1QtyOrder.Text = "Qty Order"
        '
        'LQtyOrder
        '
        Me.LQtyOrder.Font = New System.Drawing.Font("Times New Roman", 10.0!)
        Me.LQtyOrder.LocationFloat = New DevExpress.Utils.PointFloat(437.5453!, 78.79164!)
        Me.LQtyOrder.Name = "LQtyOrder"
        Me.LQtyOrder.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.LQtyOrder.SizeF = New System.Drawing.SizeF(189.4547!, 15.0!)
        Me.LQtyOrder.StyleName = "XrControlStyle2"
        Me.LQtyOrder.StylePriority.UseFont = False
        Me.LQtyOrder.Text = "BOM"
        '
        'LTitle
        '
        Me.LTitle.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold)
        Me.LTitle.LocationFloat = New DevExpress.Utils.PointFloat(0!, 0!)
        Me.LTitle.Name = "LTitle"
        Me.LTitle.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.LTitle.SizeF = New System.Drawing.SizeF(627.0!, 25.08334!)
        Me.LTitle.StyleName = "XrControlStyle1"
        Me.LTitle.StylePriority.UseFont = False
        Me.LTitle.Text = "BILL OF MATERIAL"
        '
        'LBomDate
        '
        Me.LBomDate.EvenStyleName = "XrControlStyle3"
        Me.LBomDate.Font = New System.Drawing.Font("Times New Roman", 10.0!)
        Me.LBomDate.LocationFloat = New DevExpress.Utils.PointFloat(0.00003178914!, 25.08334!)
        Me.LBomDate.Name = "LBomDate"
        Me.LBomDate.OddStyleName = "XrControlStyle3"
        Me.LBomDate.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.LBomDate.SizeF = New System.Drawing.SizeF(626.9999!, 23.00002!)
        Me.LBomDate.StyleName = "XrControlStyle3"
        Me.LBomDate.StylePriority.UseFont = False
        Me.LBomDate.Text = "Created : "
        '
        'BottomMargin
        '
        Me.BottomMargin.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.XrLabel8, Me.XrPageInfo1})
        Me.BottomMargin.HeightF = 29.41666!
        Me.BottomMargin.Name = "BottomMargin"
        Me.BottomMargin.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
        Me.BottomMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
        '
        'XrPageInfo1
        '
        Me.XrPageInfo1.Borders = DevExpress.XtraPrinting.BorderSide.None
        Me.XrPageInfo1.Font = New System.Drawing.Font("Lucida Sans", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.XrPageInfo1.Format = "Page {0} of {1}"
        Me.XrPageInfo1.LocationFloat = New DevExpress.Utils.PointFloat(476.9999!, 0!)
        Me.XrPageInfo1.Name = "XrPageInfo1"
        Me.XrPageInfo1.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrPageInfo1.SizeF = New System.Drawing.SizeF(150.0!, 16.04167!)
        Me.XrPageInfo1.StylePriority.UseBorders = False
        Me.XrPageInfo1.StylePriority.UseFont = False
        Me.XrPageInfo1.StylePriority.UseTextAlignment = False
        Me.XrPageInfo1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
        '
        'DetailReport
        '
        Me.DetailReport.Bands.AddRange(New DevExpress.XtraReports.UI.Band() {Me.DetBOMMat})
        Me.DetailReport.Level = 0
        Me.DetailReport.Name = "DetailReport"
        '
        'DetBOMMat
        '
        Me.DetBOMMat.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.WinControlContainer1})
        Me.DetBOMMat.Font = New System.Drawing.Font("Times New Roman", 9.75!)
        Me.DetBOMMat.HeightF = 156.891!
        Me.DetBOMMat.Name = "DetBOMMat"
        Me.DetBOMMat.StylePriority.UseFont = False
        '
        'WinControlContainer1
        '
        Me.WinControlContainer1.LocationFloat = New DevExpress.Utils.PointFloat(0.0001271566!, 0!)
        Me.WinControlContainer1.Name = "WinControlContainer1"
        Me.WinControlContainer1.SizeF = New System.Drawing.SizeF(626.9999!, 156.891!)
        Me.WinControlContainer1.WinControl = Me.GCBomMat
        '
        'GCBomMat
        '
        Me.GCBomMat.Location = New System.Drawing.Point(0, 0)
        Me.GCBomMat.MainView = Me.GridView1
        Me.GCBomMat.Name = "GCBomMat"
        Me.GCBomMat.Size = New System.Drawing.Size(602, 151)
        Me.GCBomMat.TabIndex = 0
        Me.GCBomMat.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridView1})
        '
        'GridView1
        '
        Me.GridView1.Appearance.Row.Font = New System.Drawing.Font("Tahoma", 7.0!)
        Me.GridView1.Appearance.Row.Options.UseFont = True
        Me.GridView1.AppearancePrint.FooterPanel.BackColor = System.Drawing.Color.White
        Me.GridView1.AppearancePrint.FooterPanel.BackColor2 = System.Drawing.Color.White
        Me.GridView1.AppearancePrint.FooterPanel.BorderColor = System.Drawing.SystemColors.ActiveBorder
        Me.GridView1.AppearancePrint.FooterPanel.Font = New System.Drawing.Font("Tahoma", 7.0!, System.Drawing.FontStyle.Bold)
        Me.GridView1.AppearancePrint.FooterPanel.ForeColor = System.Drawing.Color.Black
        Me.GridView1.AppearancePrint.FooterPanel.Options.UseBackColor = True
        Me.GridView1.AppearancePrint.FooterPanel.Options.UseBorderColor = True
        Me.GridView1.AppearancePrint.FooterPanel.Options.UseFont = True
        Me.GridView1.AppearancePrint.FooterPanel.Options.UseForeColor = True
        Me.GridView1.AppearancePrint.GroupFooter.BackColor = System.Drawing.Color.White
        Me.GridView1.AppearancePrint.GroupFooter.BackColor2 = System.Drawing.Color.White
        Me.GridView1.AppearancePrint.GroupFooter.Font = New System.Drawing.Font("Tahoma", 7.0!, System.Drawing.FontStyle.Bold)
        Me.GridView1.AppearancePrint.GroupFooter.ForeColor = System.Drawing.Color.Black
        Me.GridView1.AppearancePrint.GroupFooter.Options.UseBackColor = True
        Me.GridView1.AppearancePrint.GroupFooter.Options.UseFont = True
        Me.GridView1.AppearancePrint.GroupFooter.Options.UseForeColor = True
        Me.GridView1.AppearancePrint.GroupRow.BackColor = System.Drawing.Color.White
        Me.GridView1.AppearancePrint.GroupRow.BackColor2 = System.Drawing.Color.White
        Me.GridView1.AppearancePrint.GroupRow.BorderColor = System.Drawing.Color.Black
        Me.GridView1.AppearancePrint.GroupRow.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold)
        Me.GridView1.AppearancePrint.GroupRow.ForeColor = System.Drawing.Color.Black
        Me.GridView1.AppearancePrint.GroupRow.Options.UseBackColor = True
        Me.GridView1.AppearancePrint.GroupRow.Options.UseBorderColor = True
        Me.GridView1.AppearancePrint.GroupRow.Options.UseFont = True
        Me.GridView1.AppearancePrint.GroupRow.Options.UseForeColor = True
        Me.GridView1.AppearancePrint.HeaderPanel.BackColor = System.Drawing.Color.White
        Me.GridView1.AppearancePrint.HeaderPanel.BackColor2 = System.Drawing.Color.White
        Me.GridView1.AppearancePrint.HeaderPanel.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.GridView1.AppearancePrint.HeaderPanel.ForeColor = System.Drawing.Color.Black
        Me.GridView1.AppearancePrint.HeaderPanel.Options.UseBackColor = True
        Me.GridView1.AppearancePrint.HeaderPanel.Options.UseFont = True
        Me.GridView1.AppearancePrint.HeaderPanel.Options.UseForeColor = True
        Me.GridView1.AppearancePrint.Row.Font = New System.Drawing.Font("Tahoma", 7.0!)
        Me.GridView1.AppearancePrint.Row.Options.UseFont = True
        Me.GridView1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Office2003
        Me.GridView1.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.ColCode, Me.ColName, Me.ColSize, Me.ColQty, Me.ColPrice, Me.ColTotal, Me.Cat, Me.ColIDCat, Me.GridColumnisCOST, Me.GridColumnCurrency, Me.GridColumnVendPrice, Me.GridColumnKurs, Me.GridColumnQtyOrder, Me.GridColumnCostPerPcs, Me.GridColumnColor})
        Me.GridView1.GridControl = Me.GCBomMat
        Me.GridView1.GroupCount = 1
        Me.GridView1.GroupSummary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "total", Me.ColTotal, "{0:N2}"), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Custom, "price", Me.ColPrice, "Sub Total{0}"), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "cost_per_pcs", Me.GridColumnCostPerPcs, "{0:N2}")})
        Me.GridView1.Name = "GridView1"
        Me.GridView1.OptionsView.ShowGroupPanel = False
        Me.GridView1.OptionsView.ShowIndicator = False
        Me.GridView1.RowSeparatorHeight = 1
        Me.GridView1.SortInfo.AddRange(New DevExpress.XtraGrid.Columns.GridColumnSortInfo() {New DevExpress.XtraGrid.Columns.GridColumnSortInfo(Me.Cat, DevExpress.Data.ColumnSortOrder.Ascending)})
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
        'ColSize
        '
        Me.ColSize.AppearanceCell.Options.UseTextOptions = True
        Me.ColSize.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.ColSize.AppearanceHeader.Options.UseTextOptions = True
        Me.ColSize.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.ColSize.Caption = "Size"
        Me.ColSize.FieldName = "size"
        Me.ColSize.Name = "ColSize"
        Me.ColSize.Visible = True
        Me.ColSize.VisibleIndex = 3
        Me.ColSize.Width = 53
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
        Me.ColQty.VisibleIndex = 4
        Me.ColQty.Width = 68
        '
        'ColPrice
        '
        Me.ColPrice.AppearanceCell.Options.UseTextOptions = True
        Me.ColPrice.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.ColPrice.AppearanceHeader.Options.UseTextOptions = True
        Me.ColPrice.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.ColPrice.Caption = "Price"
        Me.ColPrice.DisplayFormat.FormatString = "N2"
        Me.ColPrice.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.ColPrice.FieldName = "price"
        Me.ColPrice.Name = "ColPrice"
        Me.ColPrice.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Custom, "price", "Total")})
        Me.ColPrice.Visible = True
        Me.ColPrice.VisibleIndex = 5
        Me.ColPrice.Width = 99
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
        Me.ColTotal.UnboundExpression = "Iif([is_cost] = 1, [qty_uom] * [price], 2)"
        Me.ColTotal.UnboundType = DevExpress.Data.UnboundColumnType.[Decimal]
        Me.ColTotal.Visible = True
        Me.ColTotal.VisibleIndex = 6
        Me.ColTotal.Width = 112
        '
        'Cat
        '
        Me.Cat.Caption = "Category"
        Me.Cat.FieldName = "component_category"
        Me.Cat.FieldNameSortGroup = "id_component_category"
        Me.Cat.Name = "Cat"
        Me.Cat.Visible = True
        Me.Cat.VisibleIndex = 0
        '
        'ColIDCat
        '
        Me.ColIDCat.Caption = "Category"
        Me.ColIDCat.FieldName = "id_component_category"
        Me.ColIDCat.Name = "ColIDCat"
        '
        'GridColumnisCOST
        '
        Me.GridColumnisCOST.Caption = "IS COST"
        Me.GridColumnisCOST.DisplayFormat.FormatString = "N2"
        Me.GridColumnisCOST.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumnisCOST.FieldName = "is_cost"
        Me.GridColumnisCOST.Name = "GridColumnisCOST"
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
        Me.GridColumnCurrency.VisibleIndex = 9
        '
        'GridColumnVendPrice
        '
        Me.GridColumnVendPrice.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumnVendPrice.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumnVendPrice.AppearanceHeader.Options.UseTextOptions = True
        Me.GridColumnVendPrice.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumnVendPrice.Caption = "Vendor Price"
        Me.GridColumnVendPrice.DisplayFormat.FormatString = "N2"
        Me.GridColumnVendPrice.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumnVendPrice.FieldName = "price"
        Me.GridColumnVendPrice.Name = "GridColumnVendPrice"
        Me.GridColumnVendPrice.Visible = True
        Me.GridColumnVendPrice.VisibleIndex = 10
        '
        'GridColumnKurs
        '
        Me.GridColumnKurs.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumnKurs.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumnKurs.AppearanceHeader.Options.UseTextOptions = True
        Me.GridColumnKurs.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumnKurs.Caption = "Kurs"
        Me.GridColumnKurs.FieldName = "kurs"
        Me.GridColumnKurs.Name = "GridColumnKurs"
        Me.GridColumnKurs.Visible = True
        Me.GridColumnKurs.VisibleIndex = 8
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
        Me.GridColumnCostPerPcs.Visible = True
        Me.GridColumnCostPerPcs.VisibleIndex = 7
        Me.GridColumnCostPerPcs.Width = 91
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
        'XrControlStyle1
        '
        Me.XrControlStyle1.Name = "XrControlStyle1"
        Me.XrControlStyle1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        '
        'XrControlStyle2
        '
        Me.XrControlStyle2.Name = "XrControlStyle2"
        Me.XrControlStyle2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
        '
        'XrControlStyle3
        '
        Me.XrControlStyle3.Name = "XrControlStyle3"
        Me.XrControlStyle3.TextAlignment = DevExpress.XtraPrinting.TextAlignment.BottomRight
        '
        'PageFooter
        '
        Me.PageFooter.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.XrTable1})
        Me.PageFooter.HeightF = 25.0!
        Me.PageFooter.Name = "PageFooter"
        '
        'XrTable1
        '
        Me.XrTable1.Font = New System.Drawing.Font("Consolas", 8.0!)
        Me.XrTable1.LocationFloat = New DevExpress.Utils.PointFloat(0.00003178914!, 0!)
        Me.XrTable1.Name = "XrTable1"
        Me.XrTable1.Rows.AddRange(New DevExpress.XtraReports.UI.XRTableRow() {Me.XrTableRow1})
        Me.XrTable1.SizeF = New System.Drawing.SizeF(626.9999!, 25.0!)
        Me.XrTable1.StylePriority.UseFont = False
        '
        'XrTableRow1
        '
        Me.XrTableRow1.Cells.AddRange(New DevExpress.XtraReports.UI.XRTableCell() {Me.XrTableCell1})
        Me.XrTableRow1.Name = "XrTableRow1"
        Me.XrTableRow1.Weight = 1.0R
        '
        'XrTableCell1
        '
        Me.XrTableCell1.Font = New System.Drawing.Font("Lucida Console", 8.0!)
        Me.XrTableCell1.Name = "XrTableCell1"
        Me.XrTableCell1.StylePriority.UseFont = False
        Me.XrTableCell1.Text = "Here Table Mark Goes, Please Ignore This"
        Me.XrTableCell1.Visible = False
        Me.XrTableCell1.Weight = 2.99999986405489R
        '
        'XrLabel8
        '
        Me.XrLabel8.Font = New System.Drawing.Font("Lucida Sans", 8.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.XrLabel8.ForeColor = System.Drawing.Color.DarkGray
        Me.XrLabel8.LocationFloat = New DevExpress.Utils.PointFloat(0!, 0!)
        Me.XrLabel8.Name = "XrLabel8"
        Me.XrLabel8.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel8.SizeF = New System.Drawing.SizeF(476.9999!, 16.04167!)
        Me.XrLabel8.StylePriority.UseBorderColor = False
        Me.XrLabel8.StylePriority.UseFont = False
        Me.XrLabel8.StylePriority.UseForeColor = False
        Me.XrLabel8.StylePriority.UseTextAlignment = False
        Me.XrLabel8.Text = "Printed from Volcom ERP ([printed_date])"
        Me.XrLabel8.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
        '
        'ReportBOM
        '
        Me.Bands.AddRange(New DevExpress.XtraReports.UI.Band() {Me.Detail, Me.TopMargin, Me.BottomMargin, Me.DetailReport, Me.PageFooter})
        Me.Margins = New System.Drawing.Printing.Margins(100, 100, 119, 29)
        Me.PageHeight = 1169
        Me.PageWidth = 827
        Me.PaperKind = System.Drawing.Printing.PaperKind.A4
        Me.StyleSheet.AddRange(New DevExpress.XtraReports.UI.XRControlStyle() {Me.XrControlStyle1, Me.XrControlStyle2, Me.XrControlStyle3})
        Me.Version = "15.1"
        CType(Me.GCBomMat, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.XrTable1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me, System.ComponentModel.ISupportInitialize).EndInit()

    End Sub
    Friend WithEvents Detail As DevExpress.XtraReports.UI.DetailBand
    Friend WithEvents TopMargin As DevExpress.XtraReports.UI.TopMarginBand
    Friend WithEvents BottomMargin As DevExpress.XtraReports.UI.BottomMarginBand
    Friend WithEvents DetailReport As DevExpress.XtraReports.UI.DetailReportBand
    Friend WithEvents DetBOMMat As DevExpress.XtraReports.UI.DetailBand
    Friend WithEvents LTitle As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrControlStyle1 As DevExpress.XtraReports.UI.XRControlStyle
    Friend WithEvents XrControlStyle2 As DevExpress.XtraReports.UI.XRControlStyle
    Friend WithEvents XrControlStyle3 As DevExpress.XtraReports.UI.XRControlStyle
    Friend WithEvents LProductName As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents LBomName As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel5 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel4 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel2 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel1 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents LBomDate As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel6 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents LTerm As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel3 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents WinControlContainer1 As DevExpress.XtraReports.UI.WinControlContainer
    Friend WithEvents GCBomMat As DevExpress.XtraGrid.GridControl
    Friend WithEvents GridView1 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents ColCode As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColName As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColSize As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColQty As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColPrice As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColTotal As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents Cat As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColIDCat As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents XrPageInfo1 As DevExpress.XtraReports.UI.XRPageInfo
    Friend WithEvents PageFooter As DevExpress.XtraReports.UI.PageFooterBand
    Friend WithEvents XrTable1 As DevExpress.XtraReports.UI.XRTable
    Friend WithEvents XrTableRow1 As DevExpress.XtraReports.UI.XRTableRow
    Friend WithEvents XrTableCell1 As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents GridColumnisCOST As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnQtyOrder As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnCostPerPcs As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents L2QtyOrder As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents L1QtyOrder As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents LQtyOrder As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents LVendor As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents L2Vendor As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents L1Vendor As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents GridColumnColor As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnVendPrice As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnKurs As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnCurrency As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents XrLabel8 As DevExpress.XtraReports.UI.XRLabel
End Class
