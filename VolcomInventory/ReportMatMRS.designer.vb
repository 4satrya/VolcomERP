<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class ReportMatMRS
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
        Me.GCMat = New DevExpress.XtraGrid.GridControl()
        Me.GVMat = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.ColIdPurcDet = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.ColIdMat = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.ColIdMatDetPrice = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.ColNo = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.ColCode = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.ColName = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.ColQty = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.SEQty = New DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit()
        Me.ColNote = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn1 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.ColSize = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnQtyOnHand = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.ColUOM = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.TopMargin = New DevExpress.XtraReports.UI.TopMarginBand()
        Me.XrLabel1 = New DevExpress.XtraReports.UI.XRLabel()
        Me.LMRSNumber = New DevExpress.XtraReports.UI.XRLabel()
        Me.LTitle = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLabel6 = New DevExpress.XtraReports.UI.XRLabel()
        Me.zxc = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLabel12 = New DevExpress.XtraReports.UI.XRLabel()
        Me.LMRSDate = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrPanel1 = New DevExpress.XtraReports.UI.XRPanel()
        Me.LLMRSType = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLabel4 = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLabel2 = New DevExpress.XtraReports.UI.XRLabel()
        Me.LWONo = New DevExpress.XtraReports.UI.XRLabel()
        Me.LTWONo = New DevExpress.XtraReports.UI.XRLabel()
        Me.LLWONo = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLabel11 = New DevExpress.XtraReports.UI.XRLabel()
        Me.LToName = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLabel3 = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLabel21 = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLabel13 = New DevExpress.XtraReports.UI.XRLabel()
        Me.LReqFromName = New DevExpress.XtraReports.UI.XRLabel()
        Me.BottomMargin = New DevExpress.XtraReports.UI.BottomMarginBand()
        Me.XrPageInfo1 = New DevExpress.XtraReports.UI.XRPageInfo()
        Me.PageFooter = New DevExpress.XtraReports.UI.PageFooterBand()
        Me.XrLabel14 = New DevExpress.XtraReports.UI.XRLabel()
        Me.LNote = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrTable1 = New DevExpress.XtraReports.UI.XRTable()
        Me.XrTableRow1 = New DevExpress.XtraReports.UI.XRTableRow()
        Me.XrTableCell1 = New DevExpress.XtraReports.UI.XRTableCell()
        CType(Me.GCMat, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVMat, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SEQty, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.XrTable1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
        '
        'Detail
        '
        Me.Detail.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.WinControlContainer1})
        Me.Detail.HeightF = 139.5833!
        Me.Detail.Name = "Detail"
        Me.Detail.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
        Me.Detail.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
        '
        'WinControlContainer1
        '
        Me.WinControlContainer1.LocationFloat = New DevExpress.Utils.PointFloat(0.00009536743!, 0!)
        Me.WinControlContainer1.Name = "WinControlContainer1"
        Me.WinControlContainer1.SizeF = New System.Drawing.SizeF(789.9999!, 139.5833!)
        Me.WinControlContainer1.WinControl = Me.GCMat
        '
        'GCMat
        '
        Me.GCMat.Location = New System.Drawing.Point(0, 0)
        Me.GCMat.MainView = Me.GVMat
        Me.GCMat.Margin = New System.Windows.Forms.Padding(0)
        Me.GCMat.Name = "GCMat"
        Me.GCMat.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.SEQty})
        Me.GCMat.Size = New System.Drawing.Size(758, 134)
        Me.GCMat.TabIndex = 2
        Me.GCMat.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVMat})
        '
        'GVMat
        '
        Me.GVMat.AppearancePrint.FooterPanel.BackColor = System.Drawing.Color.Transparent
        Me.GVMat.AppearancePrint.FooterPanel.ForeColor = System.Drawing.Color.Black
        Me.GVMat.AppearancePrint.FooterPanel.Options.UseBackColor = True
        Me.GVMat.AppearancePrint.FooterPanel.Options.UseForeColor = True
        Me.GVMat.AppearancePrint.HeaderPanel.BackColor = System.Drawing.Color.Transparent
        Me.GVMat.AppearancePrint.HeaderPanel.ForeColor = System.Drawing.Color.Black
        Me.GVMat.AppearancePrint.HeaderPanel.Options.UseBackColor = True
        Me.GVMat.AppearancePrint.HeaderPanel.Options.UseForeColor = True
        Me.GVMat.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.ColIdPurcDet, Me.ColIdMat, Me.ColIdMatDetPrice, Me.ColNo, Me.ColCode, Me.ColName, Me.ColQty, Me.ColNote, Me.GridColumn1, Me.ColSize, Me.GridColumnQtyOnHand, Me.ColUOM})
        Me.GVMat.GridControl = Me.GCMat
        Me.GVMat.HorzScrollVisibility = DevExpress.XtraGrid.Views.Base.ScrollVisibility.Never
        Me.GVMat.Name = "GVMat"
        Me.GVMat.OptionsPrint.PrintFooter = False
        Me.GVMat.OptionsView.ShowFooter = True
        Me.GVMat.OptionsView.ShowGroupPanel = False
        '
        'ColIdPurcDet
        '
        Me.ColIdPurcDet.Caption = "ID Purc Det"
        Me.ColIdPurcDet.FieldName = "id_prod_order_mrs_det"
        Me.ColIdPurcDet.Name = "ColIdPurcDet"
        '
        'ColIdMat
        '
        Me.ColIdMat.Caption = "Id Mat"
        Me.ColIdMat.FieldName = "id_mat_det"
        Me.ColIdMat.Name = "ColIdMat"
        '
        'ColIdMatDetPrice
        '
        Me.ColIdMatDetPrice.Caption = "ID Mat Det Price"
        Me.ColIdMatDetPrice.FieldName = "id_mat_det_price"
        Me.ColIdMatDetPrice.Name = "ColIdMatDetPrice"
        '
        'ColNo
        '
        Me.ColNo.AppearanceCell.Options.UseTextOptions = True
        Me.ColNo.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.ColNo.AppearanceHeader.Options.UseTextOptions = True
        Me.ColNo.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.ColNo.Caption = "No."
        Me.ColNo.FieldName = "no"
        Me.ColNo.Name = "ColNo"
        Me.ColNo.OptionsColumn.AllowEdit = False
        Me.ColNo.Visible = True
        Me.ColNo.VisibleIndex = 0
        Me.ColNo.Width = 21
        '
        'ColCode
        '
        Me.ColCode.Caption = "Code"
        Me.ColCode.FieldName = "code"
        Me.ColCode.Name = "ColCode"
        Me.ColCode.OptionsColumn.AllowEdit = False
        Me.ColCode.Visible = True
        Me.ColCode.VisibleIndex = 1
        Me.ColCode.Width = 100
        '
        'ColName
        '
        Me.ColName.Caption = "Name"
        Me.ColName.FieldName = "name"
        Me.ColName.Name = "ColName"
        Me.ColName.OptionsColumn.AllowEdit = False
        Me.ColName.Visible = True
        Me.ColName.VisibleIndex = 2
        Me.ColName.Width = 167
        '
        'ColQty
        '
        Me.ColQty.AppearanceCell.Options.UseTextOptions = True
        Me.ColQty.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.ColQty.AppearanceHeader.Options.UseTextOptions = True
        Me.ColQty.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.ColQty.Caption = "Qty"
        Me.ColQty.ColumnEdit = Me.SEQty
        Me.ColQty.DisplayFormat.FormatString = "{0:N2}"
        Me.ColQty.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.ColQty.FieldName = "qty"
        Me.ColQty.Name = "ColQty"
        Me.ColQty.OptionsColumn.AllowEdit = False
        Me.ColQty.Visible = True
        Me.ColQty.VisibleIndex = 5
        Me.ColQty.Width = 48
        '
        'SEQty
        '
        Me.SEQty.AutoHeight = False
        Me.SEQty.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.SEQty.DisplayFormat.FormatString = "N2"
        Me.SEQty.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.SEQty.Increment = New Decimal(New Integer() {1, 0, 0, 131072})
        Me.SEQty.Mask.EditMask = "N2"
        Me.SEQty.MaxValue = New Decimal(New Integer() {10000000, 0, 0, 0})
        Me.SEQty.MinValue = New Decimal(New Integer() {1, 0, 0, 0})
        Me.SEQty.Name = "SEQty"
        '
        'ColNote
        '
        Me.ColNote.Caption = "Note"
        Me.ColNote.FieldName = "note"
        Me.ColNote.Name = "ColNote"
        Me.ColNote.Visible = True
        Me.ColNote.VisibleIndex = 7
        Me.ColNote.Width = 45
        '
        'GridColumn1
        '
        Me.GridColumn1.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumn1.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridColumn1.AppearanceHeader.Options.UseTextOptions = True
        Me.GridColumn1.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridColumn1.Caption = "Color"
        Me.GridColumn1.FieldName = "color"
        Me.GridColumn1.Name = "GridColumn1"
        Me.GridColumn1.OptionsColumn.AllowEdit = False
        Me.GridColumn1.Visible = True
        Me.GridColumn1.VisibleIndex = 3
        Me.GridColumn1.Width = 53
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
        Me.ColSize.OptionsColumn.AllowEdit = False
        Me.ColSize.Visible = True
        Me.ColSize.VisibleIndex = 4
        Me.ColSize.Width = 53
        '
        'GridColumnQtyOnHand
        '
        Me.GridColumnQtyOnHand.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumnQtyOnHand.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumnQtyOnHand.AppearanceHeader.Options.UseTextOptions = True
        Me.GridColumnQtyOnHand.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumnQtyOnHand.Caption = "Qty Free"
        Me.GridColumnQtyOnHand.DisplayFormat.FormatString = "N2"
        Me.GridColumnQtyOnHand.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumnQtyOnHand.FieldName = "qty_left"
        Me.GridColumnQtyOnHand.Name = "GridColumnQtyOnHand"
        Me.GridColumnQtyOnHand.OptionsColumn.AllowEdit = False
        Me.GridColumnQtyOnHand.Width = 80
        '
        'ColUOM
        '
        Me.ColUOM.AppearanceCell.Options.UseTextOptions = True
        Me.ColUOM.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.ColUOM.AppearanceHeader.Options.UseTextOptions = True
        Me.ColUOM.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.ColUOM.Caption = "UOM"
        Me.ColUOM.FieldName = "uom"
        Me.ColUOM.Name = "ColUOM"
        Me.ColUOM.Visible = True
        Me.ColUOM.VisibleIndex = 6
        Me.ColUOM.Width = 39
        '
        'TopMargin
        '
        Me.TopMargin.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.XrLabel1, Me.LMRSNumber, Me.LTitle, Me.XrLabel6, Me.zxc, Me.XrLabel12, Me.LMRSDate, Me.XrPanel1})
        Me.TopMargin.HeightF = 118.3334!
        Me.TopMargin.Name = "TopMargin"
        Me.TopMargin.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
        Me.TopMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
        '
        'XrLabel1
        '
        Me.XrLabel1.Font = New System.Drawing.Font("Times New Roman", 10.0!)
        Me.XrLabel1.LocationFloat = New DevExpress.Utils.PointFloat(0!, 20.83333!)
        Me.XrLabel1.Name = "XrLabel1"
        Me.XrLabel1.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel1.SizeF = New System.Drawing.SizeF(69.7085!, 25.08334!)
        Me.XrLabel1.StylePriority.UseFont = False
        Me.XrLabel1.StylePriority.UseTextAlignment = False
        Me.XrLabel1.Text = "NO"
        Me.XrLabel1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.BottomLeft
        '
        'LMRSNumber
        '
        Me.LMRSNumber.Borders = DevExpress.XtraPrinting.BorderSide.None
        Me.LMRSNumber.Font = New System.Drawing.Font("Times New Roman", 10.0!)
        Me.LMRSNumber.LocationFloat = New DevExpress.Utils.PointFloat(81.16719!, 20.83333!)
        Me.LMRSNumber.Name = "LMRSNumber"
        Me.LMRSNumber.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.LMRSNumber.SizeF = New System.Drawing.SizeF(118.8328!, 25.08334!)
        Me.LMRSNumber.StylePriority.UseBorders = False
        Me.LMRSNumber.StylePriority.UseFont = False
        Me.LMRSNumber.StylePriority.UseTextAlignment = False
        Me.LMRSNumber.TextAlignment = DevExpress.XtraPrinting.TextAlignment.BottomLeft
        '
        'LTitle
        '
        Me.LTitle.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold)
        Me.LTitle.LocationFloat = New DevExpress.Utils.PointFloat(200.0!, 20.83333!)
        Me.LTitle.Name = "LTitle"
        Me.LTitle.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.LTitle.SizeF = New System.Drawing.SizeF(388.9586!, 25.08334!)
        Me.LTitle.StylePriority.UseFont = False
        Me.LTitle.StylePriority.UseTextAlignment = False
        Me.LTitle.Text = "MATERIAL REQUISITION SLIP"
        Me.LTitle.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        '
        'XrLabel6
        '
        Me.XrLabel6.Font = New System.Drawing.Font("Times New Roman", 10.0!)
        Me.XrLabel6.LocationFloat = New DevExpress.Utils.PointFloat(632.9167!, 20.83333!)
        Me.XrLabel6.Name = "XrLabel6"
        Me.XrLabel6.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel6.SizeF = New System.Drawing.SizeF(11.45844!, 25.08334!)
        Me.XrLabel6.StylePriority.UseFont = False
        Me.XrLabel6.StylePriority.UseTextAlignment = False
        Me.XrLabel6.Text = ":"
        Me.XrLabel6.TextAlignment = DevExpress.XtraPrinting.TextAlignment.BottomLeft
        '
        'zxc
        '
        Me.zxc.Font = New System.Drawing.Font("Times New Roman", 10.0!)
        Me.zxc.LocationFloat = New DevExpress.Utils.PointFloat(588.9586!, 20.83333!)
        Me.zxc.Name = "zxc"
        Me.zxc.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.zxc.SizeF = New System.Drawing.SizeF(43.95813!, 25.08334!)
        Me.zxc.StylePriority.UseFont = False
        Me.zxc.StylePriority.UseTextAlignment = False
        Me.zxc.Text = "DATE"
        Me.zxc.TextAlignment = DevExpress.XtraPrinting.TextAlignment.BottomRight
        '
        'XrLabel12
        '
        Me.XrLabel12.Borders = DevExpress.XtraPrinting.BorderSide.None
        Me.XrLabel12.Font = New System.Drawing.Font("Times New Roman", 10.0!)
        Me.XrLabel12.LocationFloat = New DevExpress.Utils.PointFloat(69.7085!, 20.83333!)
        Me.XrLabel12.Name = "XrLabel12"
        Me.XrLabel12.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel12.SizeF = New System.Drawing.SizeF(11.45835!, 25.08334!)
        Me.XrLabel12.StylePriority.UseBorders = False
        Me.XrLabel12.StylePriority.UseFont = False
        Me.XrLabel12.StylePriority.UseTextAlignment = False
        Me.XrLabel12.Text = ":"
        Me.XrLabel12.TextAlignment = DevExpress.XtraPrinting.TextAlignment.BottomLeft
        '
        'LMRSDate
        '
        Me.LMRSDate.Font = New System.Drawing.Font("Times New Roman", 10.0!)
        Me.LMRSDate.LocationFloat = New DevExpress.Utils.PointFloat(644.3752!, 20.83333!)
        Me.LMRSDate.Name = "LMRSDate"
        Me.LMRSDate.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.LMRSDate.SizeF = New System.Drawing.SizeF(145.6248!, 25.08334!)
        Me.LMRSDate.StylePriority.UseFont = False
        Me.LMRSDate.StylePriority.UseTextAlignment = False
        Me.LMRSDate.TextAlignment = DevExpress.XtraPrinting.TextAlignment.BottomLeft
        '
        'XrPanel1
        '
        Me.XrPanel1.Borders = CType(((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Top) _
            Or DevExpress.XtraPrinting.BorderSide.Right), DevExpress.XtraPrinting.BorderSide)
        Me.XrPanel1.CanGrow = False
        Me.XrPanel1.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.LLMRSType, Me.XrLabel4, Me.XrLabel2, Me.LWONo, Me.LTWONo, Me.LLWONo, Me.XrLabel11, Me.LToName, Me.XrLabel3, Me.XrLabel21, Me.XrLabel13, Me.LReqFromName})
        Me.XrPanel1.LocationFloat = New DevExpress.Utils.PointFloat(0.00009536743!, 45.91667!)
        Me.XrPanel1.Name = "XrPanel1"
        Me.XrPanel1.SizeF = New System.Drawing.SizeF(789.9999!, 72.41673!)
        Me.XrPanel1.StylePriority.UseBorders = False
        '
        'LLMRSType
        '
        Me.LLMRSType.Borders = DevExpress.XtraPrinting.BorderSide.None
        Me.LLMRSType.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold)
        Me.LLMRSType.LocationFloat = New DevExpress.Utils.PointFloat(106.1251!, 37.37502!)
        Me.LLMRSType.Name = "LLMRSType"
        Me.LLMRSType.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.LLMRSType.SizeF = New System.Drawing.SizeF(287.5002!, 13.58338!)
        Me.LLMRSType.StylePriority.UseBorders = False
        Me.LLMRSType.StylePriority.UseFont = False
        Me.LLMRSType.Text = "Material Work Order"
        '
        'XrLabel4
        '
        Me.XrLabel4.Borders = DevExpress.XtraPrinting.BorderSide.None
        Me.XrLabel4.LocationFloat = New DevExpress.Utils.PointFloat(94.66669!, 37.37505!)
        Me.XrLabel4.Name = "XrLabel4"
        Me.XrLabel4.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel4.SizeF = New System.Drawing.SizeF(11.45837!, 13.58337!)
        Me.XrLabel4.StylePriority.UseBorders = False
        Me.XrLabel4.Text = ":"
        '
        'XrLabel2
        '
        Me.XrLabel2.Borders = DevExpress.XtraPrinting.BorderSide.None
        Me.XrLabel2.LocationFloat = New DevExpress.Utils.PointFloat(2.999973!, 37.37505!)
        Me.XrLabel2.Name = "XrLabel2"
        Me.XrLabel2.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel2.SizeF = New System.Drawing.SizeF(91.66672!, 13.58337!)
        Me.XrLabel2.StylePriority.UseBorders = False
        Me.XrLabel2.Text = "MRS Type"
        '
        'LWONo
        '
        Me.LWONo.Borders = DevExpress.XtraPrinting.BorderSide.None
        Me.LWONo.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold)
        Me.LWONo.LocationFloat = New DevExpress.Utils.PointFloat(552.0835!, 2.000046!)
        Me.LWONo.Name = "LWONo"
        Me.LWONo.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.LWONo.SizeF = New System.Drawing.SizeF(214.5835!, 13.58335!)
        Me.LWONo.StylePriority.UseBorders = False
        Me.LWONo.StylePriority.UseFont = False
        Me.LWONo.StylePriority.UseTextAlignment = False
        Me.LWONo.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
        '
        'LTWONo
        '
        Me.LTWONo.Borders = DevExpress.XtraPrinting.BorderSide.None
        Me.LTWONo.LocationFloat = New DevExpress.Utils.PointFloat(540.6252!, 2.000046!)
        Me.LTWONo.Name = "LTWONo"
        Me.LTWONo.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.LTWONo.SizeF = New System.Drawing.SizeF(11.45833!, 13.58335!)
        Me.LTWONo.StylePriority.UseBorders = False
        Me.LTWONo.StylePriority.UseTextAlignment = False
        Me.LTWONo.Text = ":"
        Me.LTWONo.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
        '
        'LLWONo
        '
        Me.LLWONo.Borders = DevExpress.XtraPrinting.BorderSide.None
        Me.LLWONo.LocationFloat = New DevExpress.Utils.PointFloat(448.9585!, 2.000046!)
        Me.LLWONo.Name = "LLWONo"
        Me.LLWONo.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.LLWONo.SizeF = New System.Drawing.SizeF(91.66673!, 13.58335!)
        Me.LLWONo.StylePriority.UseBorders = False
        Me.LLWONo.StylePriority.UseTextAlignment = False
        Me.LLWONo.Text = "WO No"
        Me.LLWONo.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
        '
        'XrLabel11
        '
        Me.XrLabel11.Borders = DevExpress.XtraPrinting.BorderSide.None
        Me.XrLabel11.LocationFloat = New DevExpress.Utils.PointFloat(94.66673!, 2.000032!)
        Me.XrLabel11.Name = "XrLabel11"
        Me.XrLabel11.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel11.SizeF = New System.Drawing.SizeF(11.45833!, 13.58335!)
        Me.XrLabel11.StylePriority.UseBorders = False
        Me.XrLabel11.Text = ":"
        '
        'LToName
        '
        Me.LToName.Borders = DevExpress.XtraPrinting.BorderSide.None
        Me.LToName.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold)
        Me.LToName.LocationFloat = New DevExpress.Utils.PointFloat(106.1251!, 2.000031!)
        Me.LToName.Name = "LToName"
        Me.LToName.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.LToName.SizeF = New System.Drawing.SizeF(287.5002!, 13.58335!)
        Me.LToName.StylePriority.UseBorders = False
        Me.LToName.StylePriority.UseFont = False
        '
        'XrLabel3
        '
        Me.XrLabel3.Borders = DevExpress.XtraPrinting.BorderSide.None
        Me.XrLabel3.LocationFloat = New DevExpress.Utils.PointFloat(2.999985!, 2.000047!)
        Me.XrLabel3.Name = "XrLabel3"
        Me.XrLabel3.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel3.SizeF = New System.Drawing.SizeF(91.66675!, 13.58335!)
        Me.XrLabel3.StylePriority.UseBorders = False
        Me.XrLabel3.Text = "To"
        '
        'XrLabel21
        '
        Me.XrLabel21.Borders = DevExpress.XtraPrinting.BorderSide.None
        Me.XrLabel21.LocationFloat = New DevExpress.Utils.PointFloat(3.000005!, 15.5834!)
        Me.XrLabel21.Name = "XrLabel21"
        Me.XrLabel21.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel21.SizeF = New System.Drawing.SizeF(91.66672!, 13.58337!)
        Me.XrLabel21.StylePriority.UseBorders = False
        Me.XrLabel21.Text = "Request From"
        '
        'XrLabel13
        '
        Me.XrLabel13.Borders = DevExpress.XtraPrinting.BorderSide.None
        Me.XrLabel13.LocationFloat = New DevExpress.Utils.PointFloat(94.66673!, 15.58339!)
        Me.XrLabel13.Name = "XrLabel13"
        Me.XrLabel13.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel13.SizeF = New System.Drawing.SizeF(11.45837!, 13.58337!)
        Me.XrLabel13.StylePriority.UseBorders = False
        Me.XrLabel13.Text = ":"
        '
        'LReqFromName
        '
        Me.LReqFromName.Borders = DevExpress.XtraPrinting.BorderSide.None
        Me.LReqFromName.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold)
        Me.LReqFromName.LocationFloat = New DevExpress.Utils.PointFloat(106.1251!, 15.58339!)
        Me.LReqFromName.Name = "LReqFromName"
        Me.LReqFromName.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.LReqFromName.SizeF = New System.Drawing.SizeF(287.5002!, 13.58337!)
        Me.LReqFromName.StylePriority.UseBorders = False
        Me.LReqFromName.StylePriority.UseFont = False
        '
        'BottomMargin
        '
        Me.BottomMargin.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.XrPageInfo1})
        Me.BottomMargin.HeightF = 22.99999!
        Me.BottomMargin.Name = "BottomMargin"
        Me.BottomMargin.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
        Me.BottomMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
        '
        'XrPageInfo1
        '
        Me.XrPageInfo1.BorderColor = System.Drawing.Color.DimGray
        Me.XrPageInfo1.Borders = DevExpress.XtraPrinting.BorderSide.None
        Me.XrPageInfo1.Format = "Page {0} of {1}"
        Me.XrPageInfo1.LocationFloat = New DevExpress.Utils.PointFloat(0!, 0!)
        Me.XrPageInfo1.Name = "XrPageInfo1"
        Me.XrPageInfo1.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrPageInfo1.SizeF = New System.Drawing.SizeF(789.9999!, 22.99999!)
        Me.XrPageInfo1.StylePriority.UseBorderColor = False
        Me.XrPageInfo1.StylePriority.UseBorders = False
        Me.XrPageInfo1.StylePriority.UseTextAlignment = False
        Me.XrPageInfo1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
        '
        'PageFooter
        '
        Me.PageFooter.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.XrLabel14, Me.LNote, Me.XrTable1})
        Me.PageFooter.HeightF = 71.95832!
        Me.PageFooter.Name = "PageFooter"
        '
        'XrLabel14
        '
        Me.XrLabel14.BorderColor = System.Drawing.Color.DimGray
        Me.XrLabel14.Borders = CType(((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Top) _
            Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
        Me.XrLabel14.LocationFloat = New DevExpress.Utils.PointFloat(0.00009536743!, 0!)
        Me.XrLabel14.Name = "XrLabel14"
        Me.XrLabel14.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel14.SizeF = New System.Drawing.SizeF(43.66681!, 46.95832!)
        Me.XrLabel14.StylePriority.UseBorderColor = False
        Me.XrLabel14.StylePriority.UseBorders = False
        Me.XrLabel14.StylePriority.UseTextAlignment = False
        Me.XrLabel14.Text = "Note :"
        Me.XrLabel14.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
        '
        'LNote
        '
        Me.LNote.BorderColor = System.Drawing.Color.DimGray
        Me.LNote.Borders = CType(((DevExpress.XtraPrinting.BorderSide.Top Or DevExpress.XtraPrinting.BorderSide.Right) _
            Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
        Me.LNote.LocationFloat = New DevExpress.Utils.PointFloat(43.66681!, 0!)
        Me.LNote.Name = "LNote"
        Me.LNote.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.LNote.SizeF = New System.Drawing.SizeF(746.3332!, 46.95832!)
        Me.LNote.StylePriority.UseBorderColor = False
        Me.LNote.StylePriority.UseBorders = False
        Me.LNote.StylePriority.UseTextAlignment = False
        Me.LNote.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
        '
        'XrTable1
        '
        Me.XrTable1.Font = New System.Drawing.Font("Consolas", 8.0!)
        Me.XrTable1.LocationFloat = New DevExpress.Utils.PointFloat(0!, 46.95832!)
        Me.XrTable1.Name = "XrTable1"
        Me.XrTable1.Rows.AddRange(New DevExpress.XtraReports.UI.XRTableRow() {Me.XrTableRow1})
        Me.XrTable1.SizeF = New System.Drawing.SizeF(790.0!, 25.0!)
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
        'ReportMatMRS
        '
        Me.Bands.AddRange(New DevExpress.XtraReports.UI.Band() {Me.Detail, Me.TopMargin, Me.BottomMargin, Me.PageFooter})
        Me.Margins = New System.Drawing.Printing.Margins(11, 49, 118, 23)
        Me.PageHeight = 550
        Me.PaperKind = System.Drawing.Printing.PaperKind.Custom
        Me.Version = "15.1"
        CType(Me.GCMat, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVMat, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SEQty, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.XrTable1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me, System.ComponentModel.ISupportInitialize).EndInit()

    End Sub
    Friend WithEvents Detail As DevExpress.XtraReports.UI.DetailBand
    Friend WithEvents TopMargin As DevExpress.XtraReports.UI.TopMarginBand
    Friend WithEvents BottomMargin As DevExpress.XtraReports.UI.BottomMarginBand
    Friend WithEvents PageFooter As DevExpress.XtraReports.UI.PageFooterBand
    Friend WithEvents XrLabel1 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents LMRSNumber As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents LTitle As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel6 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents zxc As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel12 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents LMRSDate As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrPanel1 As DevExpress.XtraReports.UI.XRPanel
    Friend WithEvents LLMRSType As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel4 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel2 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents LWONo As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents LTWONo As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents LLWONo As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel11 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents LToName As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel3 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel21 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel13 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents LReqFromName As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents WinControlContainer1 As DevExpress.XtraReports.UI.WinControlContainer
    Friend WithEvents GCMat As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVMat As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents ColIdPurcDet As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColIdMat As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColIdMatDetPrice As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColNo As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColCode As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColName As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColQty As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents SEQty As DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit
    Friend WithEvents ColNote As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn1 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColSize As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnQtyOnHand As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColUOM As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents XrLabel14 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents LNote As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrTable1 As DevExpress.XtraReports.UI.XRTable
    Friend WithEvents XrTableRow1 As DevExpress.XtraReports.UI.XRTableRow
    Friend WithEvents XrTableCell1 As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents XrPageInfo1 As DevExpress.XtraReports.UI.XRPageInfo
End Class
