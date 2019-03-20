<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class ReportFGAdjOut
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
        Me.WinControlContainer1 = New DevExpress.XtraReports.UI.WinControlContainer()
        Me.GCDetail = New DevExpress.XtraGrid.GridControl()
        Me.GVDetail = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumnIdAdj = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnNo = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnIdWHDrawer = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnIdWHRack = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnIdWHLOcator = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnIdWH = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnIdSample = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnIdAdjSampleDet = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnCode = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnName = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnSize = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnCompName = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnWHLoactor = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnWHRack = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnWHDrawer = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnUOM = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnRemark = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnAdjPrice = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnQty = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnAmount = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.TopMargin = New DevExpress.XtraReports.UI.TopMarginBand()
        Me.LabelNo = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLabel6 = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLabel2 = New DevExpress.XtraReports.UI.XRLabel()
        Me.LabelDate = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLabel1 = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLabel11 = New DevExpress.XtraReports.UI.XRLabel()
        Me.LTitle = New DevExpress.XtraReports.UI.XRLabel()
        Me.BottomMargin = New DevExpress.XtraReports.UI.BottomMarginBand()
        Me.XrPageInfo1 = New DevExpress.XtraReports.UI.XRPageInfo()
        Me.PageFooter = New DevExpress.XtraReports.UI.PageFooterBand()
        Me.XrTable1 = New DevExpress.XtraReports.UI.XRTable()
        Me.XrTableRow1 = New DevExpress.XtraReports.UI.XRTableRow()
        Me.XrTableCell1 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.XrPanel2 = New DevExpress.XtraReports.UI.XRPanel()
        Me.LabelNote = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLabel9 = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLabel14 = New DevExpress.XtraReports.UI.XRLabel()
        CType(Me.GCDetail, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVDetail, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.XrTable1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
        '
        'Detail
        '
        Me.Detail.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.WinControlContainer1})
        Me.Detail.HeightF = 260.4167!
        Me.Detail.Name = "Detail"
        Me.Detail.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
        Me.Detail.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
        '
        'WinControlContainer1
        '
        Me.WinControlContainer1.LocationFloat = New DevExpress.Utils.PointFloat(0!, 0!)
        Me.WinControlContainer1.Name = "WinControlContainer1"
        Me.WinControlContainer1.SizeF = New System.Drawing.SizeF(784.0!, 260.4167!)
        Me.WinControlContainer1.WinControl = Me.GCDetail
        '
        'GCDetail
        '
        Me.GCDetail.Location = New System.Drawing.Point(0, 0)
        Me.GCDetail.MainView = Me.GVDetail
        Me.GCDetail.Name = "GCDetail"
        Me.GCDetail.Size = New System.Drawing.Size(753, 250)
        Me.GCDetail.TabIndex = 0
        Me.GCDetail.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVDetail})
        '
        'GVDetail
        '
        Me.GVDetail.Appearance.Row.Font = New System.Drawing.Font("Tahoma", 7.0!)
        Me.GVDetail.Appearance.Row.Options.UseFont = True
        Me.GVDetail.AppearancePrint.EvenRow.BackColor = System.Drawing.Color.White
        Me.GVDetail.AppearancePrint.EvenRow.BackColor2 = System.Drawing.Color.White
        Me.GVDetail.AppearancePrint.EvenRow.BorderColor = System.Drawing.Color.Black
        Me.GVDetail.AppearancePrint.EvenRow.Options.UseBackColor = True
        Me.GVDetail.AppearancePrint.EvenRow.Options.UseBorderColor = True
        Me.GVDetail.AppearancePrint.FilterPanel.BackColor = System.Drawing.Color.White
        Me.GVDetail.AppearancePrint.FilterPanel.BackColor2 = System.Drawing.Color.White
        Me.GVDetail.AppearancePrint.FilterPanel.BorderColor = System.Drawing.Color.Black
        Me.GVDetail.AppearancePrint.FilterPanel.Options.UseBackColor = True
        Me.GVDetail.AppearancePrint.FilterPanel.Options.UseBorderColor = True
        Me.GVDetail.AppearancePrint.FooterPanel.BackColor = System.Drawing.Color.White
        Me.GVDetail.AppearancePrint.FooterPanel.BackColor2 = System.Drawing.Color.White
        Me.GVDetail.AppearancePrint.FooterPanel.BorderColor = System.Drawing.Color.Black
        Me.GVDetail.AppearancePrint.FooterPanel.Font = New System.Drawing.Font("Tahoma", 6.0!)
        Me.GVDetail.AppearancePrint.FooterPanel.Options.UseBackColor = True
        Me.GVDetail.AppearancePrint.FooterPanel.Options.UseBorderColor = True
        Me.GVDetail.AppearancePrint.FooterPanel.Options.UseFont = True
        Me.GVDetail.AppearancePrint.GroupFooter.BackColor = System.Drawing.Color.White
        Me.GVDetail.AppearancePrint.GroupFooter.BackColor2 = System.Drawing.Color.White
        Me.GVDetail.AppearancePrint.GroupFooter.BorderColor = System.Drawing.Color.Black
        Me.GVDetail.AppearancePrint.GroupFooter.Options.UseBackColor = True
        Me.GVDetail.AppearancePrint.GroupFooter.Options.UseBorderColor = True
        Me.GVDetail.AppearancePrint.GroupRow.BackColor = System.Drawing.Color.White
        Me.GVDetail.AppearancePrint.GroupRow.BackColor2 = System.Drawing.Color.White
        Me.GVDetail.AppearancePrint.GroupRow.BorderColor = System.Drawing.Color.Black
        Me.GVDetail.AppearancePrint.GroupRow.Options.UseBackColor = True
        Me.GVDetail.AppearancePrint.GroupRow.Options.UseBorderColor = True
        Me.GVDetail.AppearancePrint.HeaderPanel.BackColor = System.Drawing.Color.White
        Me.GVDetail.AppearancePrint.HeaderPanel.BackColor2 = System.Drawing.Color.White
        Me.GVDetail.AppearancePrint.HeaderPanel.BorderColor = System.Drawing.Color.Black
        Me.GVDetail.AppearancePrint.HeaderPanel.Font = New System.Drawing.Font("Tahoma", 6.75!)
        Me.GVDetail.AppearancePrint.HeaderPanel.Options.UseBackColor = True
        Me.GVDetail.AppearancePrint.HeaderPanel.Options.UseBorderColor = True
        Me.GVDetail.AppearancePrint.HeaderPanel.Options.UseFont = True
        Me.GVDetail.AppearancePrint.Lines.BackColor = System.Drawing.Color.Black
        Me.GVDetail.AppearancePrint.Lines.BackColor2 = System.Drawing.Color.Black
        Me.GVDetail.AppearancePrint.Lines.BorderColor = System.Drawing.Color.Black
        Me.GVDetail.AppearancePrint.Lines.Options.UseBackColor = True
        Me.GVDetail.AppearancePrint.Lines.Options.UseBorderColor = True
        Me.GVDetail.AppearancePrint.OddRow.BackColor = System.Drawing.Color.White
        Me.GVDetail.AppearancePrint.OddRow.BackColor2 = System.Drawing.Color.White
        Me.GVDetail.AppearancePrint.OddRow.BorderColor = System.Drawing.Color.Black
        Me.GVDetail.AppearancePrint.OddRow.Options.UseBackColor = True
        Me.GVDetail.AppearancePrint.OddRow.Options.UseBorderColor = True
        Me.GVDetail.AppearancePrint.Preview.BackColor = System.Drawing.Color.White
        Me.GVDetail.AppearancePrint.Preview.BackColor2 = System.Drawing.Color.White
        Me.GVDetail.AppearancePrint.Preview.BorderColor = System.Drawing.Color.Black
        Me.GVDetail.AppearancePrint.Preview.Options.UseBackColor = True
        Me.GVDetail.AppearancePrint.Preview.Options.UseBorderColor = True
        Me.GVDetail.AppearancePrint.Row.BackColor = System.Drawing.Color.White
        Me.GVDetail.AppearancePrint.Row.BackColor2 = System.Drawing.Color.White
        Me.GVDetail.AppearancePrint.Row.BorderColor = System.Drawing.Color.Black
        Me.GVDetail.AppearancePrint.Row.Font = New System.Drawing.Font("Tahoma", 6.0!)
        Me.GVDetail.AppearancePrint.Row.Options.UseBackColor = True
        Me.GVDetail.AppearancePrint.Row.Options.UseBorderColor = True
        Me.GVDetail.AppearancePrint.Row.Options.UseFont = True
        Me.GVDetail.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumnIdAdj, Me.GridColumnNo, Me.GridColumnIdWHDrawer, Me.GridColumnIdWHRack, Me.GridColumnIdWHLOcator, Me.GridColumnIdWH, Me.GridColumnIdSample, Me.GridColumnIdAdjSampleDet, Me.GridColumnCode, Me.GridColumnName, Me.GridColumnSize, Me.GridColumnCompName, Me.GridColumnWHLoactor, Me.GridColumnWHRack, Me.GridColumnWHDrawer, Me.GridColumnUOM, Me.GridColumnRemark, Me.GridColumnAdjPrice, Me.GridColumnQty, Me.GridColumnAmount})
        Me.GVDetail.GridControl = Me.GCDetail
        Me.GVDetail.Name = "GVDetail"
        Me.GVDetail.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.[True]
        Me.GVDetail.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.[True]
        Me.GVDetail.OptionsBehavior.Editable = False
        Me.GVDetail.OptionsView.ShowFooter = True
        Me.GVDetail.OptionsView.ShowGroupPanel = False
        '
        'GridColumnIdAdj
        '
        Me.GridColumnIdAdj.Caption = "ID Adj"
        Me.GridColumnIdAdj.FieldName = "id_adj_out_fg"
        Me.GridColumnIdAdj.Name = "GridColumnIdAdj"
        Me.GridColumnIdAdj.OptionsColumn.AllowEdit = False
        Me.GridColumnIdAdj.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.[False]
        Me.GridColumnIdAdj.OptionsColumn.AllowShowHide = False
        Me.GridColumnIdAdj.OptionsColumn.ShowInCustomizationForm = False
        '
        'GridColumnNo
        '
        Me.GridColumnNo.Caption = "No"
        Me.GridColumnNo.FieldName = "no"
        Me.GridColumnNo.Name = "GridColumnNo"
        Me.GridColumnNo.OptionsColumn.AllowEdit = False
        Me.GridColumnNo.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.[False]
        Me.GridColumnNo.OptionsColumn.ShowInCustomizationForm = False
        Me.GridColumnNo.Visible = True
        Me.GridColumnNo.VisibleIndex = 0
        Me.GridColumnNo.Width = 30
        '
        'GridColumnIdWHDrawer
        '
        Me.GridColumnIdWHDrawer.Caption = "Id WH Drawer"
        Me.GridColumnIdWHDrawer.FieldName = "id_wh_drawer"
        Me.GridColumnIdWHDrawer.Name = "GridColumnIdWHDrawer"
        Me.GridColumnIdWHDrawer.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.[False]
        Me.GridColumnIdWHDrawer.OptionsColumn.AllowShowHide = False
        Me.GridColumnIdWHDrawer.OptionsColumn.ShowInCustomizationForm = False
        Me.GridColumnIdWHDrawer.Width = 77
        '
        'GridColumnIdWHRack
        '
        Me.GridColumnIdWHRack.Caption = "Id WH Rack"
        Me.GridColumnIdWHRack.FieldName = "id_wh_rack"
        Me.GridColumnIdWHRack.Name = "GridColumnIdWHRack"
        Me.GridColumnIdWHRack.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.[False]
        Me.GridColumnIdWHRack.OptionsColumn.AllowShowHide = False
        Me.GridColumnIdWHRack.OptionsColumn.ShowInCustomizationForm = False
        '
        'GridColumnIdWHLOcator
        '
        Me.GridColumnIdWHLOcator.Caption = "Id WH Locator"
        Me.GridColumnIdWHLOcator.FieldName = "id_wh_locator"
        Me.GridColumnIdWHLOcator.Name = "GridColumnIdWHLOcator"
        Me.GridColumnIdWHLOcator.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.[False]
        Me.GridColumnIdWHLOcator.OptionsColumn.AllowShowHide = False
        Me.GridColumnIdWHLOcator.OptionsColumn.ShowInCustomizationForm = False
        Me.GridColumnIdWHLOcator.Width = 78
        '
        'GridColumnIdWH
        '
        Me.GridColumnIdWH.Caption = "Id WH"
        Me.GridColumnIdWH.FieldName = "id_comp"
        Me.GridColumnIdWH.Name = "GridColumnIdWH"
        Me.GridColumnIdWH.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.[False]
        Me.GridColumnIdWH.OptionsColumn.AllowShowHide = False
        Me.GridColumnIdWH.OptionsColumn.ShowInCustomizationForm = False
        '
        'GridColumnIdSample
        '
        Me.GridColumnIdSample.Caption = "Id Mat Det"
        Me.GridColumnIdSample.FieldName = "id_product"
        Me.GridColumnIdSample.Name = "GridColumnIdSample"
        Me.GridColumnIdSample.OptionsColumn.AllowShowHide = False
        Me.GridColumnIdSample.OptionsColumn.ShowInCustomizationForm = False
        '
        'GridColumnIdAdjSampleDet
        '
        Me.GridColumnIdAdjSampleDet.Caption = "id adj det"
        Me.GridColumnIdAdjSampleDet.FieldName = "id_adj_out_fg_det"
        Me.GridColumnIdAdjSampleDet.Name = "GridColumnIdAdjSampleDet"
        Me.GridColumnIdAdjSampleDet.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.[False]
        Me.GridColumnIdAdjSampleDet.OptionsColumn.AllowShowHide = False
        Me.GridColumnIdAdjSampleDet.OptionsColumn.ShowInCustomizationForm = False
        '
        'GridColumnCode
        '
        Me.GridColumnCode.Caption = "Code"
        Me.GridColumnCode.FieldName = "code"
        Me.GridColumnCode.Name = "GridColumnCode"
        Me.GridColumnCode.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.[False]
        Me.GridColumnCode.OptionsColumn.ShowInCustomizationForm = False
        Me.GridColumnCode.Visible = True
        Me.GridColumnCode.VisibleIndex = 1
        Me.GridColumnCode.Width = 82
        '
        'GridColumnName
        '
        Me.GridColumnName.Caption = "Name"
        Me.GridColumnName.FieldName = "display_name"
        Me.GridColumnName.Name = "GridColumnName"
        Me.GridColumnName.OptionsColumn.AllowEdit = False
        Me.GridColumnName.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.[False]
        Me.GridColumnName.OptionsColumn.AllowShowHide = False
        Me.GridColumnName.Visible = True
        Me.GridColumnName.VisibleIndex = 2
        Me.GridColumnName.Width = 115
        '
        'GridColumnSize
        '
        Me.GridColumnSize.Caption = "Size"
        Me.GridColumnSize.FieldName = "display_size"
        Me.GridColumnSize.Name = "GridColumnSize"
        Me.GridColumnSize.OptionsColumn.AllowEdit = False
        Me.GridColumnSize.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.[False]
        Me.GridColumnSize.OptionsColumn.ShowInCustomizationForm = False
        Me.GridColumnSize.Width = 46
        '
        'GridColumnCompName
        '
        Me.GridColumnCompName.Caption = "WH"
        Me.GridColumnCompName.FieldName = "comp_name"
        Me.GridColumnCompName.Name = "GridColumnCompName"
        Me.GridColumnCompName.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.[False]
        Me.GridColumnCompName.OptionsColumn.ShowInCustomizationForm = False
        Me.GridColumnCompName.Visible = True
        Me.GridColumnCompName.VisibleIndex = 3
        Me.GridColumnCompName.Width = 115
        '
        'GridColumnWHLoactor
        '
        Me.GridColumnWHLoactor.Caption = "Locator"
        Me.GridColumnWHLoactor.FieldName = "wh_locator"
        Me.GridColumnWHLoactor.Name = "GridColumnWHLoactor"
        Me.GridColumnWHLoactor.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.[False]
        Me.GridColumnWHLoactor.Visible = True
        Me.GridColumnWHLoactor.VisibleIndex = 4
        Me.GridColumnWHLoactor.Width = 76
        '
        'GridColumnWHRack
        '
        Me.GridColumnWHRack.Caption = "Rack"
        Me.GridColumnWHRack.FieldName = "wh_rack"
        Me.GridColumnWHRack.Name = "GridColumnWHRack"
        Me.GridColumnWHRack.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.[False]
        Me.GridColumnWHRack.Visible = True
        Me.GridColumnWHRack.VisibleIndex = 5
        Me.GridColumnWHRack.Width = 76
        '
        'GridColumnWHDrawer
        '
        Me.GridColumnWHDrawer.Caption = "Drawer"
        Me.GridColumnWHDrawer.FieldName = "wh_drawer"
        Me.GridColumnWHDrawer.Name = "GridColumnWHDrawer"
        Me.GridColumnWHDrawer.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.[False]
        Me.GridColumnWHDrawer.Visible = True
        Me.GridColumnWHDrawer.VisibleIndex = 6
        Me.GridColumnWHDrawer.Width = 76
        '
        'GridColumnUOM
        '
        Me.GridColumnUOM.Caption = "UOM"
        Me.GridColumnUOM.FieldName = "uom"
        Me.GridColumnUOM.Name = "GridColumnUOM"
        Me.GridColumnUOM.OptionsColumn.AllowEdit = False
        Me.GridColumnUOM.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.[False]
        '
        'GridColumnRemark
        '
        Me.GridColumnRemark.Caption = "Remark"
        Me.GridColumnRemark.FieldName = "adj_out_fg_det_note"
        Me.GridColumnRemark.Name = "GridColumnRemark"
        Me.GridColumnRemark.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.[False]
        '
        'GridColumnAdjPrice
        '
        Me.GridColumnAdjPrice.Caption = "Price"
        Me.GridColumnAdjPrice.DisplayFormat.FormatString = "n2"
        Me.GridColumnAdjPrice.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumnAdjPrice.FieldName = "adj_out_fg_det_price"
        Me.GridColumnAdjPrice.Name = "GridColumnAdjPrice"
        Me.GridColumnAdjPrice.Visible = True
        Me.GridColumnAdjPrice.VisibleIndex = 7
        Me.GridColumnAdjPrice.Width = 59
        '
        'GridColumnQty
        '
        Me.GridColumnQty.Caption = "Qty"
        Me.GridColumnQty.DisplayFormat.FormatString = "N2"
        Me.GridColumnQty.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumnQty.FieldName = "adj_out_fg_det_qty"
        Me.GridColumnQty.Name = "GridColumnQty"
        Me.GridColumnQty.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.[False]
        Me.GridColumnQty.Visible = True
        Me.GridColumnQty.VisibleIndex = 8
        Me.GridColumnQty.Width = 44
        '
        'GridColumnAmount
        '
        Me.GridColumnAmount.Caption = "Amount"
        Me.GridColumnAmount.DisplayFormat.FormatString = "n2"
        Me.GridColumnAmount.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumnAmount.FieldName = "adj_out_fg_det_amount"
        Me.GridColumnAmount.Name = "GridColumnAmount"
        Me.GridColumnAmount.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "adj_out_fg_det_amount", "{0:n2}")})
        Me.GridColumnAmount.Visible = True
        Me.GridColumnAmount.VisibleIndex = 9
        '
        'TopMargin
        '
        Me.TopMargin.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.LabelNo, Me.XrLabel6, Me.XrLabel2, Me.LabelDate, Me.XrLabel1, Me.XrLabel11, Me.LTitle})
        Me.TopMargin.HeightF = 47.0!
        Me.TopMargin.Name = "TopMargin"
        Me.TopMargin.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
        Me.TopMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
        '
        'LabelNo
        '
        Me.LabelNo.Font = New System.Drawing.Font("Times New Roman", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelNo.LocationFloat = New DevExpress.Utils.PointFloat(680.8334!, 11.04167!)
        Me.LabelNo.Name = "LabelNo"
        Me.LabelNo.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.LabelNo.SizeF = New System.Drawing.SizeF(103.1666!, 12.49999!)
        Me.LabelNo.StylePriority.UseFont = False
        Me.LabelNo.StylePriority.UseTextAlignment = False
        Me.LabelNo.TextAlignment = DevExpress.XtraPrinting.TextAlignment.BottomLeft
        '
        'XrLabel6
        '
        Me.XrLabel6.Font = New System.Drawing.Font("Times New Roman", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.XrLabel6.LocationFloat = New DevExpress.Utils.PointFloat(618.3333!, 23.54167!)
        Me.XrLabel6.Name = "XrLabel6"
        Me.XrLabel6.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel6.SizeF = New System.Drawing.SizeF(51.04163!, 12.49999!)
        Me.XrLabel6.StylePriority.UseFont = False
        Me.XrLabel6.StylePriority.UseTextAlignment = False
        Me.XrLabel6.Text = "DATE"
        Me.XrLabel6.TextAlignment = DevExpress.XtraPrinting.TextAlignment.BottomLeft
        '
        'XrLabel2
        '
        Me.XrLabel2.Borders = DevExpress.XtraPrinting.BorderSide.None
        Me.XrLabel2.LocationFloat = New DevExpress.Utils.PointFloat(669.3749!, 23.54167!)
        Me.XrLabel2.Name = "XrLabel2"
        Me.XrLabel2.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel2.SizeF = New System.Drawing.SizeF(11.45837!, 12.49999!)
        Me.XrLabel2.StylePriority.UseBorders = False
        Me.XrLabel2.Text = ":"
        '
        'LabelDate
        '
        Me.LabelDate.Font = New System.Drawing.Font("Times New Roman", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelDate.LocationFloat = New DevExpress.Utils.PointFloat(680.8333!, 23.54167!)
        Me.LabelDate.Name = "LabelDate"
        Me.LabelDate.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.LabelDate.SizeF = New System.Drawing.SizeF(103.1667!, 12.49999!)
        Me.LabelDate.StylePriority.UseFont = False
        Me.LabelDate.StylePriority.UseTextAlignment = False
        Me.LabelDate.TextAlignment = DevExpress.XtraPrinting.TextAlignment.BottomLeft
        '
        'XrLabel1
        '
        Me.XrLabel1.Font = New System.Drawing.Font("Times New Roman", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.XrLabel1.LocationFloat = New DevExpress.Utils.PointFloat(618.3333!, 11.04167!)
        Me.XrLabel1.Name = "XrLabel1"
        Me.XrLabel1.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel1.SizeF = New System.Drawing.SizeF(51.04169!, 12.49999!)
        Me.XrLabel1.StylePriority.UseFont = False
        Me.XrLabel1.StylePriority.UseTextAlignment = False
        Me.XrLabel1.Text = "NO"
        Me.XrLabel1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.BottomLeft
        '
        'XrLabel11
        '
        Me.XrLabel11.Borders = DevExpress.XtraPrinting.BorderSide.None
        Me.XrLabel11.LocationFloat = New DevExpress.Utils.PointFloat(669.3749!, 11.04167!)
        Me.XrLabel11.Name = "XrLabel11"
        Me.XrLabel11.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel11.SizeF = New System.Drawing.SizeF(11.45837!, 12.49999!)
        Me.XrLabel11.StylePriority.UseBorders = False
        Me.XrLabel11.Text = ":"
        '
        'LTitle
        '
        Me.LTitle.Font = New System.Drawing.Font("Times New Roman", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LTitle.LocationFloat = New DevExpress.Utils.PointFloat(245.8333!, 16.04167!)
        Me.LTitle.Name = "LTitle"
        Me.LTitle.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.LTitle.SizeF = New System.Drawing.SizeF(316.6669!, 15.08334!)
        Me.LTitle.StylePriority.UseFont = False
        Me.LTitle.StylePriority.UseTextAlignment = False
        Me.LTitle.Text = "ADJUSTMENT OUT FINISHED GOODS"
        Me.LTitle.TextAlignment = DevExpress.XtraPrinting.TextAlignment.BottomCenter
        '
        'BottomMargin
        '
        Me.BottomMargin.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.XrPageInfo1})
        Me.BottomMargin.HeightF = 19.0!
        Me.BottomMargin.Name = "BottomMargin"
        Me.BottomMargin.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
        Me.BottomMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
        '
        'XrPageInfo1
        '
        Me.XrPageInfo1.Borders = DevExpress.XtraPrinting.BorderSide.None
        Me.XrPageInfo1.Font = New System.Drawing.Font("Lucida Sans", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.XrPageInfo1.Format = "Page {0} of {1}"
        Me.XrPageInfo1.LocationFloat = New DevExpress.Utils.PointFloat(633.9999!, 0!)
        Me.XrPageInfo1.Name = "XrPageInfo1"
        Me.XrPageInfo1.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrPageInfo1.SizeF = New System.Drawing.SizeF(150.0!, 18.71793!)
        Me.XrPageInfo1.StylePriority.UseBorders = False
        Me.XrPageInfo1.StylePriority.UseFont = False
        Me.XrPageInfo1.StylePriority.UseTextAlignment = False
        Me.XrPageInfo1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
        '
        'PageFooter
        '
        Me.PageFooter.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.XrTable1, Me.XrPanel2})
        Me.PageFooter.HeightF = 76.04166!
        Me.PageFooter.Name = "PageFooter"
        '
        'XrTable1
        '
        Me.XrTable1.Font = New System.Drawing.Font("Consolas", 8.0!)
        Me.XrTable1.LocationFloat = New DevExpress.Utils.PointFloat(0.9999911!, 47.29169!)
        Me.XrTable1.Name = "XrTable1"
        Me.XrTable1.Rows.AddRange(New DevExpress.XtraReports.UI.XRTableRow() {Me.XrTableRow1})
        Me.XrTable1.SizeF = New System.Drawing.SizeF(782.9999!, 27.70831!)
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
        Me.XrTableCell1.Weight = 2.9999998640548888R
        '
        'XrPanel2
        '
        Me.XrPanel2.BorderColor = System.Drawing.Color.Black
        Me.XrPanel2.Borders = CType((((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Top) _
            Or DevExpress.XtraPrinting.BorderSide.Right) _
            Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
        Me.XrPanel2.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.LabelNote, Me.XrLabel9, Me.XrLabel14})
        Me.XrPanel2.LocationFloat = New DevExpress.Utils.PointFloat(0!, 0!)
        Me.XrPanel2.Name = "XrPanel2"
        Me.XrPanel2.SizeF = New System.Drawing.SizeF(783.9999!, 47.29169!)
        Me.XrPanel2.StylePriority.UseBorderColor = False
        Me.XrPanel2.StylePriority.UseBorders = False
        '
        'LabelNote
        '
        Me.LabelNote.Borders = DevExpress.XtraPrinting.BorderSide.None
        Me.LabelNote.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelNote.LocationFloat = New DevExpress.Utils.PointFloat(63.598!, 3.833389!)
        Me.LabelNote.Name = "LabelNote"
        Me.LabelNote.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.LabelNote.SizeF = New System.Drawing.SizeF(693.3187!, 33.45833!)
        Me.LabelNote.StylePriority.UseBorders = False
        Me.LabelNote.StylePriority.UseFont = False
        '
        'XrLabel9
        '
        Me.XrLabel9.Borders = DevExpress.XtraPrinting.BorderSide.None
        Me.XrLabel9.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.XrLabel9.LocationFloat = New DevExpress.Utils.PointFloat(2.000008!, 3.833363!)
        Me.XrLabel9.Name = "XrLabel9"
        Me.XrLabel9.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel9.SizeF = New System.Drawing.SizeF(50.13963!, 13.58334!)
        Me.XrLabel9.StylePriority.UseBorders = False
        Me.XrLabel9.StylePriority.UseFont = False
        Me.XrLabel9.Text = "Note"
        '
        'XrLabel14
        '
        Me.XrLabel14.Borders = DevExpress.XtraPrinting.BorderSide.None
        Me.XrLabel14.LocationFloat = New DevExpress.Utils.PointFloat(52.13963!, 3.833359!)
        Me.XrLabel14.Name = "XrLabel14"
        Me.XrLabel14.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel14.SizeF = New System.Drawing.SizeF(11.45833!, 13.58335!)
        Me.XrLabel14.StylePriority.UseBorders = False
        Me.XrLabel14.Text = ":"
        '
        'ReportFGAdjOut
        '
        Me.Bands.AddRange(New DevExpress.XtraReports.UI.Band() {Me.Detail, Me.TopMargin, Me.BottomMargin, Me.PageFooter})
        Me.Margins = New System.Drawing.Printing.Margins(27, 38, 47, 19)
        Me.PageHeight = 500
        Me.PaperKind = System.Drawing.Printing.PaperKind.Custom
        Me.Version = "15.1"
        CType(Me.GCDetail, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVDetail, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.XrTable1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me, System.ComponentModel.ISupportInitialize).EndInit()

    End Sub
    Friend WithEvents Detail As DevExpress.XtraReports.UI.DetailBand
    Friend WithEvents TopMargin As DevExpress.XtraReports.UI.TopMarginBand
    Friend WithEvents BottomMargin As DevExpress.XtraReports.UI.BottomMarginBand
    Friend WithEvents PageFooter As DevExpress.XtraReports.UI.PageFooterBand
    Friend WithEvents XrPageInfo1 As DevExpress.XtraReports.UI.XRPageInfo
    Friend WithEvents XrTable1 As DevExpress.XtraReports.UI.XRTable
    Friend WithEvents XrTableRow1 As DevExpress.XtraReports.UI.XRTableRow
    Friend WithEvents XrTableCell1 As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents XrPanel2 As DevExpress.XtraReports.UI.XRPanel
    Friend WithEvents LabelNote As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel9 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel14 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents LTitle As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents LabelNo As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel6 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel2 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents LabelDate As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel1 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel11 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents WinControlContainer1 As DevExpress.XtraReports.UI.WinControlContainer
    Friend WithEvents GCDetail As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVDetail As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumnIdAdj As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnNo As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnIdWHDrawer As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnIdWHRack As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnIdWHLOcator As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnIdWH As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnIdSample As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnIdAdjSampleDet As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnCode As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnName As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnSize As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnCompName As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnWHLoactor As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnWHRack As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnWHDrawer As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnUOM As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnRemark As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnAdjPrice As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnQty As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnAmount As DevExpress.XtraGrid.Columns.GridColumn
End Class
