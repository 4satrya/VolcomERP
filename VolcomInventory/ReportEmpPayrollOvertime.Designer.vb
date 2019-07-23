<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class ReportEmpPayrollOvertime
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ReportEmpPayrollOvertime))
        Me.Detail = New DevExpress.XtraReports.UI.DetailBand()
        Me.WinControlContainer1 = New DevExpress.XtraReports.UI.WinControlContainer()
        Me.GCOvertime = New DevExpress.XtraGrid.GridControl()
        Me.GVOverTime = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumn1 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn11 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn2 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn3 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn4 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn5 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn6 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn7 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn8 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn9 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn10 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.TopMargin = New DevExpress.XtraReports.UI.TopMarginBand()
        Me.BottomMargin = New DevExpress.XtraReports.UI.BottomMarginBand()
        Me.XrPageInfo1 = New DevExpress.XtraReports.UI.XRPageInfo()
        Me.ReportHeader = New DevExpress.XtraReports.UI.ReportHeaderBand()
        Me.XrLine1 = New DevExpress.XtraReports.UI.XRLine()
        Me.XLLocation = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLabel2 = New DevExpress.XtraReports.UI.XRLabel()
        Me.XLType = New DevExpress.XtraReports.UI.XRLabel()
        Me.XLTitle = New DevExpress.XtraReports.UI.XRLabel()
        Me.XLPeriod = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLabel4 = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLabel3 = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrPictureBox1 = New DevExpress.XtraReports.UI.XRPictureBox()
        Me.XrLabel1 = New DevExpress.XtraReports.UI.XRLabel()
        Me.ReportFooter = New DevExpress.XtraReports.UI.ReportFooterBand()
        Me.XrTable1 = New DevExpress.XtraReports.UI.XRTable()
        Me.XrTableRow1 = New DevExpress.XtraReports.UI.XRTableRow()
        Me.XrTableCell13 = New DevExpress.XtraReports.UI.XRTableCell()
        CType(Me.GCOvertime, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVOverTime, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.WinControlContainer1.SizeF = New System.Drawing.SizeF(1118.999!, 260.0!)
        Me.WinControlContainer1.WinControl = Me.GCOvertime
        '
        'GCOvertime
        '
        Me.GCOvertime.Location = New System.Drawing.Point(0, 40)
        Me.GCOvertime.MainView = Me.GVOverTime
        Me.GCOvertime.Name = "GCOvertime"
        Me.GCOvertime.Size = New System.Drawing.Size(1074, 250)
        Me.GCOvertime.TabIndex = 1
        Me.GCOvertime.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVOverTime})
        '
        'GVOverTime
        '
        Me.GVOverTime.AppearancePrint.FooterPanel.BackColor = System.Drawing.Color.White
        Me.GVOverTime.AppearancePrint.FooterPanel.BorderColor = System.Drawing.Color.Black
        Me.GVOverTime.AppearancePrint.FooterPanel.Font = New System.Drawing.Font("Tahoma", 7.25!)
        Me.GVOverTime.AppearancePrint.FooterPanel.Options.UseBackColor = True
        Me.GVOverTime.AppearancePrint.FooterPanel.Options.UseBorderColor = True
        Me.GVOverTime.AppearancePrint.FooterPanel.Options.UseFont = True
        Me.GVOverTime.AppearancePrint.GroupFooter.BackColor = System.Drawing.Color.White
        Me.GVOverTime.AppearancePrint.GroupFooter.BorderColor = System.Drawing.Color.Black
        Me.GVOverTime.AppearancePrint.GroupFooter.Font = New System.Drawing.Font("Tahoma", 7.25!)
        Me.GVOverTime.AppearancePrint.GroupFooter.Options.UseBackColor = True
        Me.GVOverTime.AppearancePrint.GroupFooter.Options.UseBorderColor = True
        Me.GVOverTime.AppearancePrint.GroupFooter.Options.UseFont = True
        Me.GVOverTime.AppearancePrint.GroupRow.BackColor = System.Drawing.Color.White
        Me.GVOverTime.AppearancePrint.GroupRow.BorderColor = System.Drawing.Color.Black
        Me.GVOverTime.AppearancePrint.GroupRow.Font = New System.Drawing.Font("Tahoma", 7.25!, System.Drawing.FontStyle.Bold)
        Me.GVOverTime.AppearancePrint.GroupRow.Options.UseBackColor = True
        Me.GVOverTime.AppearancePrint.GroupRow.Options.UseBorderColor = True
        Me.GVOverTime.AppearancePrint.GroupRow.Options.UseFont = True
        Me.GVOverTime.AppearancePrint.HeaderPanel.BackColor = System.Drawing.Color.White
        Me.GVOverTime.AppearancePrint.HeaderPanel.BorderColor = System.Drawing.Color.Black
        Me.GVOverTime.AppearancePrint.HeaderPanel.Font = New System.Drawing.Font("Tahoma", 7.25!, System.Drawing.FontStyle.Bold)
        Me.GVOverTime.AppearancePrint.HeaderPanel.Options.UseBackColor = True
        Me.GVOverTime.AppearancePrint.HeaderPanel.Options.UseBorderColor = True
        Me.GVOverTime.AppearancePrint.HeaderPanel.Options.UseFont = True
        Me.GVOverTime.AppearancePrint.Row.BackColor = System.Drawing.Color.White
        Me.GVOverTime.AppearancePrint.Row.BorderColor = System.Drawing.Color.Black
        Me.GVOverTime.AppearancePrint.Row.Font = New System.Drawing.Font("Tahoma", 7.25!)
        Me.GVOverTime.AppearancePrint.Row.Options.UseBackColor = True
        Me.GVOverTime.AppearancePrint.Row.Options.UseBorderColor = True
        Me.GVOverTime.AppearancePrint.Row.Options.UseFont = True
        Me.GVOverTime.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumn1, Me.GridColumn11, Me.GridColumn2, Me.GridColumn3, Me.GridColumn4, Me.GridColumn5, Me.GridColumn6, Me.GridColumn7, Me.GridColumn8, Me.GridColumn9, Me.GridColumn10})
        Me.GVOverTime.GridControl = Me.GCOvertime
        Me.GVOverTime.GroupCount = 2
        Me.GVOverTime.GroupFormat = "{1} {2}"
        Me.GVOverTime.GroupSummary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Custom, "Point Reguler", Me.GridColumn6, "{0:N1}"), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Custom, "Overtime Reguler", Me.GridColumn7, "{0:N0}"), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Custom, "Point Event", Me.GridColumn8, "{0:N1}"), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Custom, "Overtime Event", Me.GridColumn9, "{0:N0}"), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Custom, "Total Overtime", Me.GridColumn10, "{0:N0}")})
        Me.GVOverTime.Name = "GVOverTime"
        Me.GVOverTime.OptionsBehavior.AutoExpandAllGroups = True
        Me.GVOverTime.OptionsBehavior.Editable = False
        Me.GVOverTime.OptionsFind.AlwaysVisible = True
        Me.GVOverTime.OptionsView.GroupFooterShowMode = DevExpress.XtraGrid.Views.Grid.GroupFooterShowMode.VisibleAlways
        Me.GVOverTime.OptionsView.ShowFooter = True
        Me.GVOverTime.OptionsView.ShowGroupPanel = False
        Me.GVOverTime.SortInfo.AddRange(New DevExpress.XtraGrid.Columns.GridColumnSortInfo() {New DevExpress.XtraGrid.Columns.GridColumnSortInfo(Me.GridColumn1, DevExpress.Data.ColumnSortOrder.Ascending), New DevExpress.XtraGrid.Columns.GridColumnSortInfo(Me.GridColumn11, DevExpress.Data.ColumnSortOrder.Ascending)})
        '
        'GridColumn1
        '
        Me.GridColumn1.Caption = "Departement"
        Me.GridColumn1.FieldName = "Departement"
        Me.GridColumn1.Name = "GridColumn1"
        Me.GridColumn1.Visible = True
        Me.GridColumn1.VisibleIndex = 0
        '
        'GridColumn11
        '
        Me.GridColumn11.Caption = "Sub Departement"
        Me.GridColumn11.FieldName = "Sub Departement"
        Me.GridColumn11.Name = "GridColumn11"
        Me.GridColumn11.Visible = True
        Me.GridColumn11.VisibleIndex = 0
        '
        'GridColumn2
        '
        Me.GridColumn2.Caption = "NIP"
        Me.GridColumn2.FieldName = "NIP"
        Me.GridColumn2.Name = "GridColumn2"
        Me.GridColumn2.Visible = True
        Me.GridColumn2.VisibleIndex = 0
        Me.GridColumn2.Width = 86
        '
        'GridColumn3
        '
        Me.GridColumn3.Caption = "Employee"
        Me.GridColumn3.FieldName = "Employee"
        Me.GridColumn3.MinWidth = 195
        Me.GridColumn3.Name = "GridColumn3"
        Me.GridColumn3.Visible = True
        Me.GridColumn3.VisibleIndex = 1
        Me.GridColumn3.Width = 195
        '
        'GridColumn4
        '
        Me.GridColumn4.Caption = "Employee Position"
        Me.GridColumn4.FieldName = "Employee Position"
        Me.GridColumn4.MinWidth = 150
        Me.GridColumn4.Name = "GridColumn4"
        Me.GridColumn4.Visible = True
        Me.GridColumn4.VisibleIndex = 2
        Me.GridColumn4.Width = 182
        '
        'GridColumn5
        '
        Me.GridColumn5.Caption = "Employee Status"
        Me.GridColumn5.FieldName = "Employee Status"
        Me.GridColumn5.MinWidth = 100
        Me.GridColumn5.Name = "GridColumn5"
        Me.GridColumn5.Visible = True
        Me.GridColumn5.VisibleIndex = 3
        Me.GridColumn5.Width = 105
        '
        'GridColumn6
        '
        Me.GridColumn6.Caption = "Point Reguler"
        Me.GridColumn6.DisplayFormat.FormatString = "N1"
        Me.GridColumn6.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumn6.FieldName = "Point Reguler"
        Me.GridColumn6.Name = "GridColumn6"
        Me.GridColumn6.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Point Reguler", "{0:N1}")})
        Me.GridColumn6.Visible = True
        Me.GridColumn6.VisibleIndex = 4
        Me.GridColumn6.Width = 95
        '
        'GridColumn7
        '
        Me.GridColumn7.Caption = "Overtime Reguler"
        Me.GridColumn7.DisplayFormat.FormatString = "N0"
        Me.GridColumn7.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumn7.FieldName = "Overtime Reguler"
        Me.GridColumn7.Name = "GridColumn7"
        Me.GridColumn7.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Overtime Reguler", "{0:N0}")})
        Me.GridColumn7.Visible = True
        Me.GridColumn7.VisibleIndex = 5
        Me.GridColumn7.Width = 95
        '
        'GridColumn8
        '
        Me.GridColumn8.Caption = "Point Event"
        Me.GridColumn8.DisplayFormat.FormatString = "N1"
        Me.GridColumn8.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumn8.FieldName = "Point Event"
        Me.GridColumn8.Name = "GridColumn8"
        Me.GridColumn8.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Point Event", "{0:N1}")})
        Me.GridColumn8.Visible = True
        Me.GridColumn8.VisibleIndex = 6
        Me.GridColumn8.Width = 95
        '
        'GridColumn9
        '
        Me.GridColumn9.Caption = "Overtime Event"
        Me.GridColumn9.DisplayFormat.FormatString = "N0"
        Me.GridColumn9.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumn9.FieldName = "Overtime Event"
        Me.GridColumn9.Name = "GridColumn9"
        Me.GridColumn9.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Overtime Event", "{0:N0}")})
        Me.GridColumn9.Visible = True
        Me.GridColumn9.VisibleIndex = 7
        Me.GridColumn9.Width = 95
        '
        'GridColumn10
        '
        Me.GridColumn10.Caption = "Total Overtime"
        Me.GridColumn10.DisplayFormat.FormatString = "N0"
        Me.GridColumn10.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumn10.FieldName = "Total Overtime"
        Me.GridColumn10.Name = "GridColumn10"
        Me.GridColumn10.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Total Overtime", "{0:N0}")})
        Me.GridColumn10.Visible = True
        Me.GridColumn10.VisibleIndex = 8
        Me.GridColumn10.Width = 108
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
        Me.XrPageInfo1.LocationFloat = New DevExpress.Utils.PointFloat(968.9991!, 0!)
        Me.XrPageInfo1.Name = "XrPageInfo1"
        Me.XrPageInfo1.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrPageInfo1.SizeF = New System.Drawing.SizeF(150.0!, 18.71793!)
        Me.XrPageInfo1.StylePriority.UseBorders = False
        Me.XrPageInfo1.StylePriority.UseFont = False
        Me.XrPageInfo1.StylePriority.UseTextAlignment = False
        Me.XrPageInfo1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
        '
        'ReportHeader
        '
        Me.ReportHeader.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.XrLine1, Me.XLLocation, Me.XrLabel2, Me.XLType, Me.XLTitle, Me.XLPeriod, Me.XrLabel4, Me.XrLabel3, Me.XrPictureBox1, Me.XrLabel1})
        Me.ReportHeader.HeightF = 100.0!
        Me.ReportHeader.Name = "ReportHeader"
        '
        'XrLine1
        '
        Me.XrLine1.LocationFloat = New DevExpress.Utils.PointFloat(0.00003973643!, 79.99998!)
        Me.XrLine1.Name = "XrLine1"
        Me.XrLine1.SizeF = New System.Drawing.SizeF(1119.0!, 20.0!)
        '
        'XLLocation
        '
        Me.XLLocation.Font = New System.Drawing.Font("Tahoma", 9.75!)
        Me.XLLocation.LocationFloat = New DevExpress.Utils.PointFloat(973.9999!, 57.0!)
        Me.XLLocation.Name = "XLLocation"
        Me.XLLocation.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XLLocation.SizeF = New System.Drawing.SizeF(144.9993!, 23.0!)
        Me.XLLocation.StylePriority.UseFont = False
        Me.XLLocation.StylePriority.UseTextAlignment = False
        Me.XLLocation.Text = "[location]"
        Me.XLLocation.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
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
        'XLType
        '
        Me.XLType.Font = New System.Drawing.Font("Tahoma", 9.75!)
        Me.XLType.LocationFloat = New DevExpress.Utils.PointFloat(973.9999!, 33.99998!)
        Me.XLType.Name = "XLType"
        Me.XLType.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XLType.SizeF = New System.Drawing.SizeF(145.0!, 23.0!)
        Me.XLType.StylePriority.UseFont = False
        Me.XLType.StylePriority.UseTextAlignment = False
        Me.XLType.Text = "[type]"
        Me.XLType.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
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
        Me.XLTitle.Text = "Overtime"
        Me.XLTitle.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
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
        'XrPictureBox1
        '
        Me.XrPictureBox1.AnchorHorizontal = DevExpress.XtraReports.UI.HorizontalAnchorStyles.Left
        Me.XrPictureBox1.Image = CType(resources.GetObject("XrPictureBox1.Image"), System.Drawing.Image)
        Me.XrPictureBox1.LocationFloat = New DevExpress.Utils.PointFloat(0.00003973643!, 22.99999!)
        Me.XrPictureBox1.Name = "XrPictureBox1"
        Me.XrPictureBox1.SizeF = New System.Drawing.SizeF(220.0!, 41.15!)
        Me.XrPictureBox1.Sizing = DevExpress.XtraPrinting.ImageSizeMode.StretchImage
        '
        'XrLabel1
        '
        Me.XrLabel1.Font = New System.Drawing.Font("Tahoma", 9.75!)
        Me.XrLabel1.LocationFloat = New DevExpress.Utils.PointFloat(898.9993!, 33.99998!)
        Me.XrLabel1.Name = "XrLabel1"
        Me.XrLabel1.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel1.SizeF = New System.Drawing.SizeF(60.0!, 23.0!)
        Me.XrLabel1.StylePriority.UseFont = False
        Me.XrLabel1.StylePriority.UseTextAlignment = False
        Me.XrLabel1.Text = "Type"
        Me.XrLabel1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
        '
        'ReportFooter
        '
        Me.ReportFooter.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.XrTable1})
        Me.ReportFooter.HeightF = 100.0!
        Me.ReportFooter.Name = "ReportFooter"
        '
        'XrTable1
        '
        Me.XrTable1.Font = New System.Drawing.Font("Tahoma", 7.25!)
        Me.XrTable1.LocationFloat = New DevExpress.Utils.PointFloat(0!, 20.0!)
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
        'ReportEmpPayrollOvertime
        '
        Me.Bands.AddRange(New DevExpress.XtraReports.UI.Band() {Me.Detail, Me.TopMargin, Me.BottomMargin, Me.ReportHeader, Me.ReportFooter})
        Me.Landscape = True
        Me.Margins = New System.Drawing.Printing.Margins(25, 25, 50, 50)
        Me.PageHeight = 827
        Me.PageWidth = 1169
        Me.PaperKind = System.Drawing.Printing.PaperKind.A4
        Me.ScriptLanguage = DevExpress.XtraReports.ScriptLanguage.VisualBasic
        Me.Version = "15.1"
        CType(Me.GCOvertime, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVOverTime, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.XrTable1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me, System.ComponentModel.ISupportInitialize).EndInit()

    End Sub
    Friend WithEvents Detail As DevExpress.XtraReports.UI.DetailBand
    Friend WithEvents TopMargin As DevExpress.XtraReports.UI.TopMarginBand
    Friend WithEvents BottomMargin As DevExpress.XtraReports.UI.BottomMarginBand
    Friend WithEvents ReportHeader As DevExpress.XtraReports.UI.ReportHeaderBand
    Friend WithEvents ReportFooter As DevExpress.XtraReports.UI.ReportFooterBand
    Friend WithEvents XrLine1 As DevExpress.XtraReports.UI.XRLine
    Friend WithEvents XLLocation As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel2 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XLType As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XLTitle As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XLPeriod As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel4 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel3 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrPictureBox1 As DevExpress.XtraReports.UI.XRPictureBox
    Friend WithEvents XrLabel1 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrTable1 As DevExpress.XtraReports.UI.XRTable
    Friend WithEvents XrTableRow1 As DevExpress.XtraReports.UI.XRTableRow
    Friend WithEvents XrTableCell13 As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents XrPageInfo1 As DevExpress.XtraReports.UI.XRPageInfo
    Friend WithEvents WinControlContainer1 As DevExpress.XtraReports.UI.WinControlContainer
    Friend WithEvents GCOvertime As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVOverTime As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumn1 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn2 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn3 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn4 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn5 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn6 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn7 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn8 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn9 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn10 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn11 As DevExpress.XtraGrid.Columns.GridColumn
End Class
