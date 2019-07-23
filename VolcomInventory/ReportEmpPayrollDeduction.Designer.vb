<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Public Class ReportEmpPayrollDeduction
    Inherits DevExpress.XtraReports.UI.XtraReport

    'XtraReport overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ReportEmpPayrollDeduction))
        Me.Detail = New DevExpress.XtraReports.UI.DetailBand()
        Me.WinControlContainer1 = New DevExpress.XtraReports.UI.WinControlContainer()
        Me.GCDeduction = New DevExpress.XtraGrid.GridControl()
        Me.GVDeduction = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridView()
        Me.GBEmployee = New DevExpress.XtraGrid.Views.BandedGrid.GridBand()
        Me.GCDepartement = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.GCNIP = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.GCEmployee = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.GCEmployeePosition = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.GCEmployeeStatus = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.GCSubDepartement = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.TopMargin = New DevExpress.XtraReports.UI.TopMarginBand()
        Me.BottomMargin = New DevExpress.XtraReports.UI.BottomMarginBand()
        Me.XrPageInfo1 = New DevExpress.XtraReports.UI.XRPageInfo()
        Me.ReportFooter = New DevExpress.XtraReports.UI.ReportFooterBand()
        Me.XrPanel1 = New DevExpress.XtraReports.UI.XRPanel()
        Me.XrTable1 = New DevExpress.XtraReports.UI.XRTable()
        Me.XrTableRow1 = New DevExpress.XtraReports.UI.XRTableRow()
        Me.XrTableCell13 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.ReportHeader = New DevExpress.XtraReports.UI.ReportHeaderBand()
        Me.XrLabel1 = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrPictureBox1 = New DevExpress.XtraReports.UI.XRPictureBox()
        Me.XrLabel3 = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLabel4 = New DevExpress.XtraReports.UI.XRLabel()
        Me.XLPeriod = New DevExpress.XtraReports.UI.XRLabel()
        Me.XLTitle = New DevExpress.XtraReports.UI.XRLabel()
        Me.XLType = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLabel2 = New DevExpress.XtraReports.UI.XRLabel()
        Me.XLLocation = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLine1 = New DevExpress.XtraReports.UI.XRLine()
        CType(Me.GCDeduction, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVDeduction, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.XrTable1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
        '
        'Detail
        '
        Me.Detail.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.WinControlContainer1})
        Me.Detail.HeightF = 260.0!
        Me.Detail.Name = "Detail"
        Me.Detail.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
        Me.Detail.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
        '
        'WinControlContainer1
        '
        Me.WinControlContainer1.LocationFloat = New DevExpress.Utils.PointFloat(0!, 0!)
        Me.WinControlContainer1.Name = "WinControlContainer1"
        Me.WinControlContainer1.SizeF = New System.Drawing.SizeF(1119.0!, 260.0!)
        Me.WinControlContainer1.WinControl = Me.GCDeduction
        '
        'GCDeduction
        '
        Me.GCDeduction.Location = New System.Drawing.Point(0, 38)
        Me.GCDeduction.MainView = Me.GVDeduction
        Me.GCDeduction.Name = "GCDeduction"
        Me.GCDeduction.Size = New System.Drawing.Size(1074, 250)
        Me.GCDeduction.TabIndex = 1
        Me.GCDeduction.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVDeduction})
        '
        'GVDeduction
        '
        Me.GVDeduction.AppearancePrint.BandPanel.BackColor = System.Drawing.Color.White
        Me.GVDeduction.AppearancePrint.BandPanel.BorderColor = System.Drawing.Color.Black
        Me.GVDeduction.AppearancePrint.BandPanel.Font = New System.Drawing.Font("Tahoma", 7.25!, System.Drawing.FontStyle.Bold)
        Me.GVDeduction.AppearancePrint.BandPanel.Options.UseBackColor = True
        Me.GVDeduction.AppearancePrint.BandPanel.Options.UseBorderColor = True
        Me.GVDeduction.AppearancePrint.BandPanel.Options.UseFont = True
        Me.GVDeduction.AppearancePrint.FooterPanel.BackColor = System.Drawing.Color.White
        Me.GVDeduction.AppearancePrint.FooterPanel.BorderColor = System.Drawing.Color.Black
        Me.GVDeduction.AppearancePrint.FooterPanel.Font = New System.Drawing.Font("Tahoma", 7.25!)
        Me.GVDeduction.AppearancePrint.FooterPanel.Options.UseBackColor = True
        Me.GVDeduction.AppearancePrint.FooterPanel.Options.UseBorderColor = True
        Me.GVDeduction.AppearancePrint.FooterPanel.Options.UseFont = True
        Me.GVDeduction.AppearancePrint.GroupFooter.BackColor = System.Drawing.Color.White
        Me.GVDeduction.AppearancePrint.GroupFooter.BorderColor = System.Drawing.Color.Black
        Me.GVDeduction.AppearancePrint.GroupFooter.Font = New System.Drawing.Font("Tahoma", 7.25!)
        Me.GVDeduction.AppearancePrint.GroupFooter.Options.UseBackColor = True
        Me.GVDeduction.AppearancePrint.GroupFooter.Options.UseBorderColor = True
        Me.GVDeduction.AppearancePrint.GroupFooter.Options.UseFont = True
        Me.GVDeduction.AppearancePrint.GroupRow.BackColor = System.Drawing.Color.White
        Me.GVDeduction.AppearancePrint.GroupRow.BorderColor = System.Drawing.Color.Black
        Me.GVDeduction.AppearancePrint.GroupRow.Font = New System.Drawing.Font("Tahoma", 7.25!, System.Drawing.FontStyle.Bold)
        Me.GVDeduction.AppearancePrint.GroupRow.Options.UseBackColor = True
        Me.GVDeduction.AppearancePrint.GroupRow.Options.UseBorderColor = True
        Me.GVDeduction.AppearancePrint.GroupRow.Options.UseFont = True
        Me.GVDeduction.AppearancePrint.HeaderPanel.BackColor = System.Drawing.Color.White
        Me.GVDeduction.AppearancePrint.HeaderPanel.BorderColor = System.Drawing.Color.Black
        Me.GVDeduction.AppearancePrint.HeaderPanel.Font = New System.Drawing.Font("Tahoma", 7.25!, System.Drawing.FontStyle.Bold)
        Me.GVDeduction.AppearancePrint.HeaderPanel.Options.UseBackColor = True
        Me.GVDeduction.AppearancePrint.HeaderPanel.Options.UseBorderColor = True
        Me.GVDeduction.AppearancePrint.HeaderPanel.Options.UseFont = True
        Me.GVDeduction.AppearancePrint.Row.BackColor = System.Drawing.Color.White
        Me.GVDeduction.AppearancePrint.Row.BorderColor = System.Drawing.Color.Black
        Me.GVDeduction.AppearancePrint.Row.Font = New System.Drawing.Font("Tahoma", 7.25!)
        Me.GVDeduction.AppearancePrint.Row.Options.UseBackColor = True
        Me.GVDeduction.AppearancePrint.Row.Options.UseBorderColor = True
        Me.GVDeduction.AppearancePrint.Row.Options.UseFont = True
        Me.GVDeduction.BandPanelRowHeight = 16
        Me.GVDeduction.Bands.AddRange(New DevExpress.XtraGrid.Views.BandedGrid.GridBand() {Me.GBEmployee})
        Me.GVDeduction.ColumnPanelRowHeight = 32
        Me.GVDeduction.Columns.AddRange(New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn() {Me.GCDepartement, Me.GCSubDepartement, Me.GCNIP, Me.GCEmployee, Me.GCEmployeePosition, Me.GCEmployeeStatus})
        Me.GVDeduction.GridControl = Me.GCDeduction
        Me.GVDeduction.GroupCount = 2
        Me.GVDeduction.GroupFormat = "{1} {2}"
        Me.GVDeduction.Name = "GVDeduction"
        Me.GVDeduction.OptionsBehavior.AutoExpandAllGroups = True
        Me.GVDeduction.OptionsBehavior.Editable = False
        Me.GVDeduction.OptionsPrint.AllowMultilineHeaders = True
        Me.GVDeduction.OptionsView.GroupFooterShowMode = DevExpress.XtraGrid.Views.Grid.GroupFooterShowMode.VisibleAlways
        Me.GVDeduction.OptionsView.ShowFooter = True
        Me.GVDeduction.OptionsView.ShowGroupPanel = False
        Me.GVDeduction.SortInfo.AddRange(New DevExpress.XtraGrid.Columns.GridColumnSortInfo() {New DevExpress.XtraGrid.Columns.GridColumnSortInfo(Me.GCDepartement, DevExpress.Data.ColumnSortOrder.Ascending), New DevExpress.XtraGrid.Columns.GridColumnSortInfo(Me.GCSubDepartement, DevExpress.Data.ColumnSortOrder.Ascending)})
        '
        'GBEmployee
        '
        Me.GBEmployee.Caption = "Employee"
        Me.GBEmployee.Columns.Add(Me.GCDepartement)
        Me.GBEmployee.Columns.Add(Me.GCNIP)
        Me.GBEmployee.Columns.Add(Me.GCEmployee)
        Me.GBEmployee.Columns.Add(Me.GCEmployeePosition)
        Me.GBEmployee.Columns.Add(Me.GCEmployeeStatus)
        Me.GBEmployee.Name = "GBEmployee"
        Me.GBEmployee.VisibleIndex = 0
        Me.GBEmployee.Width = 1056
        '
        'GCDepartement
        '
        Me.GCDepartement.Caption = "Departement"
        Me.GCDepartement.FieldName = "Departement"
        Me.GCDepartement.Name = "GCDepartement"
        '
        'GCNIP
        '
        Me.GCNIP.Caption = "NIP"
        Me.GCNIP.FieldName = "NIP"
        Me.GCNIP.MinWidth = 65
        Me.GCNIP.Name = "GCNIP"
        Me.GCNIP.Visible = True
        Me.GCNIP.Width = 218
        '
        'GCEmployee
        '
        Me.GCEmployee.AppearanceCell.Options.UseTextOptions = True
        Me.GCEmployee.AppearanceCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
        Me.GCEmployee.Caption = "Employee"
        Me.GCEmployee.FieldName = "Employee"
        Me.GCEmployee.MinWidth = 195
        Me.GCEmployee.Name = "GCEmployee"
        Me.GCEmployee.Visible = True
        Me.GCEmployee.Width = 195
        '
        'GCEmployeePosition
        '
        Me.GCEmployeePosition.AppearanceCell.Options.UseTextOptions = True
        Me.GCEmployeePosition.AppearanceCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
        Me.GCEmployeePosition.Caption = "Employee Position"
        Me.GCEmployeePosition.FieldName = "Employee Position"
        Me.GCEmployeePosition.MinWidth = 150
        Me.GCEmployeePosition.Name = "GCEmployeePosition"
        Me.GCEmployeePosition.Visible = True
        Me.GCEmployeePosition.Width = 457
        '
        'GCEmployeeStatus
        '
        Me.GCEmployeeStatus.Caption = "Employee Status"
        Me.GCEmployeeStatus.FieldName = "Employee Status"
        Me.GCEmployeeStatus.MinWidth = 60
        Me.GCEmployeeStatus.Name = "GCEmployeeStatus"
        Me.GCEmployeeStatus.Visible = True
        Me.GCEmployeeStatus.Width = 186
        '
        'GCSubDepartement
        '
        Me.GCSubDepartement.Caption = "Sub Departement"
        Me.GCSubDepartement.FieldName = "Sub Departement"
        Me.GCSubDepartement.Name = "GCSubDepartement"
        '
        'TopMargin
        '
        Me.TopMargin.HeightF = 50.0!
        Me.TopMargin.Name = "TopMargin"
        Me.TopMargin.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
        Me.TopMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
        '
        'BottomMargin
        '
        Me.BottomMargin.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.XrPageInfo1})
        Me.BottomMargin.HeightF = 50.0!
        Me.BottomMargin.Name = "BottomMargin"
        Me.BottomMargin.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
        Me.BottomMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
        '
        'XrPageInfo1
        '
        Me.XrPageInfo1.Borders = DevExpress.XtraPrinting.BorderSide.None
        Me.XrPageInfo1.Font = New System.Drawing.Font("Tahoma", 7.25!)
        Me.XrPageInfo1.Format = "Page {0} of {1}"
        Me.XrPageInfo1.LocationFloat = New DevExpress.Utils.PointFloat(969.0001!, 0!)
        Me.XrPageInfo1.Name = "XrPageInfo1"
        Me.XrPageInfo1.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrPageInfo1.SizeF = New System.Drawing.SizeF(150.0!, 18.71793!)
        Me.XrPageInfo1.StylePriority.UseBorders = False
        Me.XrPageInfo1.StylePriority.UseFont = False
        Me.XrPageInfo1.StylePriority.UseTextAlignment = False
        Me.XrPageInfo1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
        '
        'ReportFooter
        '
        Me.ReportFooter.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.XrPanel1})
        Me.ReportFooter.HeightF = 100.0!
        Me.ReportFooter.Name = "ReportFooter"
        '
        'XrPanel1
        '
        Me.XrPanel1.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.XrTable1})
        Me.XrPanel1.LocationFloat = New DevExpress.Utils.PointFloat(0!, 0!)
        Me.XrPanel1.Name = "XrPanel1"
        Me.XrPanel1.SizeF = New System.Drawing.SizeF(1119.0!, 100.0!)
        '
        'XrTable1
        '
        Me.XrTable1.Font = New System.Drawing.Font("Tahoma", 7.25!)
        Me.XrTable1.LocationFloat = New DevExpress.Utils.PointFloat(0.00007947286!, 20.0!)
        Me.XrTable1.Name = "XrTable1"
        Me.XrTable1.Rows.AddRange(New DevExpress.XtraReports.UI.XRTableRow() {Me.XrTableRow1})
        Me.XrTable1.SizeF = New System.Drawing.SizeF(1118.999!, 25.0!)
        Me.XrTable1.StylePriority.UseFont = False
        '
        'XrTableRow1
        '
        Me.XrTableRow1.Cells.AddRange(New DevExpress.XtraReports.UI.XRTableCell() {Me.XrTableCell13})
        Me.XrTableRow1.Name = "XrTableRow1"
        Me.XrTableRow1.Weight = 1.0R
        '
        'XrTableCell13
        '
        Me.XrTableCell13.Font = New System.Drawing.Font("Tahoma", 9.75!)
        Me.XrTableCell13.Name = "XrTableCell13"
        Me.XrTableCell13.StylePriority.UseFont = False
        Me.XrTableCell13.Text = "Here Table Mark Goes, Please Ignore This"
        Me.XrTableCell13.Visible = False
        Me.XrTableCell13.Weight = 2.99999986405489R
        '
        'ReportHeader
        '
        Me.ReportHeader.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.XrLabel1, Me.XrPictureBox1, Me.XrLabel3, Me.XrLabel4, Me.XLPeriod, Me.XLTitle, Me.XLType, Me.XrLabel2, Me.XLLocation, Me.XrLine1})
        Me.ReportHeader.HeightF = 100.0!
        Me.ReportHeader.Name = "ReportHeader"
        '
        'XrLabel1
        '
        Me.XrLabel1.Font = New System.Drawing.Font("Tahoma", 9.75!)
        Me.XrLabel1.LocationFloat = New DevExpress.Utils.PointFloat(898.9992!, 33.99998!)
        Me.XrLabel1.Name = "XrLabel1"
        Me.XrLabel1.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel1.SizeF = New System.Drawing.SizeF(60.0!, 23.0!)
        Me.XrLabel1.StylePriority.UseFont = False
        Me.XrLabel1.StylePriority.UseTextAlignment = False
        Me.XrLabel1.Text = "Type"
        Me.XrLabel1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
        '
        'XrPictureBox1
        '
        Me.XrPictureBox1.AnchorHorizontal = DevExpress.XtraReports.UI.HorizontalAnchorStyles.Left
        Me.XrPictureBox1.Image = CType(resources.GetObject("XrPictureBox1.Image"), System.Drawing.Image)
        Me.XrPictureBox1.LocationFloat = New DevExpress.Utils.PointFloat(0!, 22.99999!)
        Me.XrPictureBox1.Name = "XrPictureBox1"
        Me.XrPictureBox1.SizeF = New System.Drawing.SizeF(220.0!, 41.15!)
        Me.XrPictureBox1.Sizing = DevExpress.XtraPrinting.ImageSizeMode.StretchImage
        '
        'XrLabel3
        '
        Me.XrLabel3.Font = New System.Drawing.Font("Tahoma", 9.75!)
        Me.XrLabel3.LocationFloat = New DevExpress.Utils.PointFloat(958.9999!, 33.99998!)
        Me.XrLabel3.Name = "XrLabel3"
        Me.XrLabel3.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel3.SizeF = New System.Drawing.SizeF(15.0!, 23.0!)
        Me.XrLabel3.StylePriority.UseFont = False
        Me.XrLabel3.StylePriority.UseTextAlignment = False
        Me.XrLabel3.Text = ":"
        Me.XrLabel3.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
        '
        'XrLabel4
        '
        Me.XrLabel4.Font = New System.Drawing.Font("Tahoma", 9.75!)
        Me.XrLabel4.LocationFloat = New DevExpress.Utils.PointFloat(958.9999!, 57.0!)
        Me.XrLabel4.Name = "XrLabel4"
        Me.XrLabel4.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel4.SizeF = New System.Drawing.SizeF(15.0!, 23.0!)
        Me.XrLabel4.StylePriority.UseFont = False
        Me.XrLabel4.StylePriority.UseTextAlignment = False
        Me.XrLabel4.Text = ":"
        Me.XrLabel4.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
        '
        'XLPeriod
        '
        Me.XLPeriod.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold)
        Me.XLPeriod.LocationFloat = New DevExpress.Utils.PointFloat(898.9991!, 11.0!)
        Me.XLPeriod.Name = "XLPeriod"
        Me.XLPeriod.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XLPeriod.SizeF = New System.Drawing.SizeF(220.0!, 23.0!)
        Me.XLPeriod.StylePriority.UseFont = False
        Me.XLPeriod.StylePriority.UseTextAlignment = False
        Me.XLPeriod.Text = "[period]"
        Me.XLPeriod.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
        '
        'XLTitle
        '
        Me.XLTitle.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Bold)
        Me.XLTitle.LocationFloat = New DevExpress.Utils.PointFloat(220.0!, 33.99998!)
        Me.XLTitle.Name = "XLTitle"
        Me.XLTitle.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XLTitle.SizeF = New System.Drawing.SizeF(678.9993!, 23.0!)
        Me.XLTitle.StylePriority.UseFont = False
        Me.XLTitle.StylePriority.UseTextAlignment = False
        Me.XLTitle.Text = "[title]"
        Me.XLTitle.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        '
        'XLType
        '
        Me.XLType.Font = New System.Drawing.Font("Tahoma", 9.75!)
        Me.XLType.LocationFloat = New DevExpress.Utils.PointFloat(973.9998!, 33.99998!)
        Me.XLType.Name = "XLType"
        Me.XLType.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XLType.SizeF = New System.Drawing.SizeF(145.0!, 23.0!)
        Me.XLType.StylePriority.UseFont = False
        Me.XLType.StylePriority.UseTextAlignment = False
        Me.XLType.Text = "[type]"
        Me.XLType.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
        '
        'XrLabel2
        '
        Me.XrLabel2.Font = New System.Drawing.Font("Tahoma", 9.75!)
        Me.XrLabel2.LocationFloat = New DevExpress.Utils.PointFloat(898.9991!, 57.0!)
        Me.XrLabel2.Name = "XrLabel2"
        Me.XrLabel2.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel2.SizeF = New System.Drawing.SizeF(60.0!, 23.0!)
        Me.XrLabel2.StylePriority.UseFont = False
        Me.XrLabel2.StylePriority.UseTextAlignment = False
        Me.XrLabel2.Text = "Location"
        Me.XrLabel2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
        '
        'XLLocation
        '
        Me.XLLocation.Font = New System.Drawing.Font("Tahoma", 9.75!)
        Me.XLLocation.LocationFloat = New DevExpress.Utils.PointFloat(973.9998!, 57.0!)
        Me.XLLocation.Name = "XLLocation"
        Me.XLLocation.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XLLocation.SizeF = New System.Drawing.SizeF(144.9993!, 23.0!)
        Me.XLLocation.StylePriority.UseFont = False
        Me.XLLocation.StylePriority.UseTextAlignment = False
        Me.XLLocation.Text = "[location]"
        Me.XLLocation.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
        '
        'XrLine1
        '
        Me.XrLine1.LocationFloat = New DevExpress.Utils.PointFloat(0!, 79.99998!)
        Me.XrLine1.Name = "XrLine1"
        Me.XrLine1.SizeF = New System.Drawing.SizeF(1119.0!, 20.0!)
        '
        'ReportEmpPayrollDeduction
        '
        Me.Bands.AddRange(New DevExpress.XtraReports.UI.Band() {Me.Detail, Me.TopMargin, Me.BottomMargin, Me.ReportFooter, Me.ReportHeader})
        Me.Landscape = True
        Me.Margins = New System.Drawing.Printing.Margins(25, 25, 50, 50)
        Me.PageHeight = 827
        Me.PageWidth = 1169
        Me.PaperKind = System.Drawing.Printing.PaperKind.A4
        Me.ScriptLanguage = DevExpress.XtraReports.ScriptLanguage.VisualBasic
        Me.Version = "15.1"
        CType(Me.GCDeduction, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVDeduction, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.XrTable1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me, System.ComponentModel.ISupportInitialize).EndInit()

    End Sub
    Friend WithEvents Detail As DevExpress.XtraReports.UI.DetailBand
    Friend WithEvents TopMargin As DevExpress.XtraReports.UI.TopMarginBand
    Friend WithEvents BottomMargin As DevExpress.XtraReports.UI.BottomMarginBand
    Friend WithEvents WinControlContainer1 As DevExpress.XtraReports.UI.WinControlContainer
    Friend WithEvents GCDeduction As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVDeduction As DevExpress.XtraGrid.Views.BandedGrid.BandedGridView
    Friend WithEvents GCDepartement As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents GCNIP As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents GCEmployee As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents GCEmployeePosition As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents GCEmployeeStatus As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents GBEmployee As DevExpress.XtraGrid.Views.BandedGrid.GridBand
    Friend WithEvents XrPageInfo1 As DevExpress.XtraReports.UI.XRPageInfo
    Friend WithEvents ReportFooter As DevExpress.XtraReports.UI.ReportFooterBand
    Friend WithEvents XrTable1 As DevExpress.XtraReports.UI.XRTable
    Friend WithEvents XrTableRow1 As DevExpress.XtraReports.UI.XRTableRow
    Friend WithEvents XrTableCell13 As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents ReportHeader As DevExpress.XtraReports.UI.ReportHeaderBand
    Friend WithEvents XrLabel1 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrPictureBox1 As DevExpress.XtraReports.UI.XRPictureBox
    Friend WithEvents XrLabel3 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel4 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XLPeriod As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XLTitle As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XLType As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel2 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XLLocation As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLine1 As DevExpress.XtraReports.UI.XRLine
    Friend WithEvents XrPanel1 As DevExpress.XtraReports.UI.XRPanel
    Friend WithEvents GCSubDepartement As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
End Class
