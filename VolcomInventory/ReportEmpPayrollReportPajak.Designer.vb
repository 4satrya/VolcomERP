<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Public Class ReportEmpPayrollReportPajak
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
        Me.Detail = New DevExpress.XtraReports.UI.DetailBand()
        Me.TopMargin = New DevExpress.XtraReports.UI.TopMarginBand()
        Me.BottomMargin = New DevExpress.XtraReports.UI.BottomMarginBand()
        Me.XrPageInfo1 = New DevExpress.XtraReports.UI.XRPageInfo()
        Me.ReportHeader = New DevExpress.XtraReports.UI.ReportHeaderBand()
        Me.XLTitle = New DevExpress.XtraReports.UI.XRLabel()
        Me.XLPeriod = New DevExpress.XtraReports.UI.XRLabel()
        Me.ReportFooter = New DevExpress.XtraReports.UI.ReportFooterBand()
        Me.XrTable1 = New DevExpress.XtraReports.UI.XRTable()
        Me.XrTableRow1 = New DevExpress.XtraReports.UI.XRTableRow()
        Me.XrTableCell13 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.GCPajak = New DevExpress.XtraGrid.GridControl()
        Me.GVPajak = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridView()
        Me.gridBand8 = New DevExpress.XtraGrid.Views.BandedGrid.GridBand()
        Me.GridColumnNIP = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.GridColumnName = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumnNPWP = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumnJenisKelamin = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumnNPWPStatus = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumnDepartement = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.GridColumnPosition = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.GridColumnStatus = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.GBWorkingDays = New DevExpress.XtraGrid.Views.BandedGrid.GridBand()
        Me.BandedGridColumnActWorkdays = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumnOvertimeHours = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.GBSalary = New DevExpress.XtraGrid.Views.BandedGrid.GridBand()
        Me.GridColumnTotTHP = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumnTotalAdjustment = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumnTotalPaymentOt = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumnTotal1 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.GBTotal = New DevExpress.XtraGrid.Views.BandedGrid.GridBand()
        Me.BandedGridColumnGrandTotal = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.gridBand1 = New DevExpress.XtraGrid.Views.BandedGrid.GridBand()
        Me.BandedGridColumnTotalDeduction = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumnTotal2 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.GBTHR = New DevExpress.XtraGrid.Views.BandedGrid.GridBand()
        Me.BandedGridColumnTHR = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.gridBand3 = New DevExpress.XtraGrid.Views.BandedGrid.GridBand()
        Me.BandedGridColumnJHTK = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumnJPK = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumnBPJSKESK = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumnTotalK = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.gridBand2 = New DevExpress.XtraGrid.Views.BandedGrid.GridBand()
        Me.BandedGridColumnJHTC = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumnJKKC = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumnJKMC = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumnJPC = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumnBPJSKESC = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumnTotalC = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumnTotalBPJSC = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumnGroup = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.WinControlContainer1 = New DevExpress.XtraReports.UI.WinControlContainer()
        CType(Me.XrTable1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GCPajak, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVPajak, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
        '
        'Detail
        '
        Me.Detail.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.WinControlContainer1})
        Me.Detail.HeightF = 312.0!
        Me.Detail.Name = "Detail"
        Me.Detail.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
        Me.Detail.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
        '
        'TopMargin
        '
        Me.TopMargin.HeightF = 30.0!
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
        Me.XrPageInfo1.LocationFloat = New DevExpress.Utils.PointFloat(925.0001!, 0!)
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
        Me.ReportHeader.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.XLTitle, Me.XLPeriod})
        Me.ReportHeader.HeightF = 63.99998!
        Me.ReportHeader.Name = "ReportHeader"
        '
        'XLTitle
        '
        Me.XLTitle.Font = New System.Drawing.Font("Tahoma", 7.25!, System.Drawing.FontStyle.Bold)
        Me.XLTitle.LocationFloat = New DevExpress.Utils.PointFloat(0!, 16.0!)
        Me.XLTitle.Name = "XLTitle"
        Me.XLTitle.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XLTitle.SizeF = New System.Drawing.SizeF(350.0!, 16.0!)
        Me.XLTitle.StylePriority.UseFont = False
        Me.XLTitle.Text = "PT. VOLCOM INDONESIA"
        '
        'XLPeriod
        '
        Me.XLPeriod.Font = New System.Drawing.Font("Tahoma", 7.25!, System.Drawing.FontStyle.Bold)
        Me.XLPeriod.LocationFloat = New DevExpress.Utils.PointFloat(0!, 32.0!)
        Me.XLPeriod.Name = "XLPeriod"
        Me.XLPeriod.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XLPeriod.SizeF = New System.Drawing.SizeF(350.0!, 16.0!)
        Me.XLPeriod.StylePriority.UseFont = False
        '
        'ReportFooter
        '
        Me.ReportFooter.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.XrTable1})
        Me.ReportFooter.HeightF = 100.0!
        Me.ReportFooter.KeepTogether = True
        Me.ReportFooter.Name = "ReportFooter"
        '
        'XrTable1
        '
        Me.XrTable1.Font = New System.Drawing.Font("Tahoma", 7.25!)
        Me.XrTable1.LocationFloat = New DevExpress.Utils.PointFloat(0!, 20.0!)
        Me.XrTable1.Name = "XrTable1"
        Me.XrTable1.Rows.AddRange(New DevExpress.XtraReports.UI.XRTableRow() {Me.XrTableRow1})
        Me.XrTable1.SizeF = New System.Drawing.SizeF(1075.0!, 25.0!)
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
        'GCPajak
        '
        Me.GCPajak.Location = New System.Drawing.Point(0, 46)
        Me.GCPajak.MainView = Me.GVPajak
        Me.GCPajak.Name = "GCPajak"
        Me.GCPajak.Size = New System.Drawing.Size(1032, 300)
        Me.GCPajak.TabIndex = 6
        Me.GCPajak.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVPajak})
        '
        'GVPajak
        '
        Me.GVPajak.AppearancePrint.BandPanel.BackColor = System.Drawing.Color.White
        Me.GVPajak.AppearancePrint.BandPanel.BorderColor = System.Drawing.Color.Black
        Me.GVPajak.AppearancePrint.BandPanel.Font = New System.Drawing.Font("Tahoma", 7.25!, System.Drawing.FontStyle.Bold)
        Me.GVPajak.AppearancePrint.BandPanel.Options.UseBackColor = True
        Me.GVPajak.AppearancePrint.BandPanel.Options.UseBorderColor = True
        Me.GVPajak.AppearancePrint.BandPanel.Options.UseFont = True
        Me.GVPajak.AppearancePrint.FooterPanel.BackColor = System.Drawing.Color.White
        Me.GVPajak.AppearancePrint.FooterPanel.BorderColor = System.Drawing.Color.Black
        Me.GVPajak.AppearancePrint.FooterPanel.Font = New System.Drawing.Font("Tahoma", 7.25!)
        Me.GVPajak.AppearancePrint.FooterPanel.Options.UseBackColor = True
        Me.GVPajak.AppearancePrint.FooterPanel.Options.UseBorderColor = True
        Me.GVPajak.AppearancePrint.FooterPanel.Options.UseFont = True
        Me.GVPajak.AppearancePrint.GroupFooter.BackColor = System.Drawing.Color.White
        Me.GVPajak.AppearancePrint.GroupFooter.BorderColor = System.Drawing.Color.Black
        Me.GVPajak.AppearancePrint.GroupFooter.Font = New System.Drawing.Font("Tahoma", 7.25!)
        Me.GVPajak.AppearancePrint.GroupFooter.Options.UseBackColor = True
        Me.GVPajak.AppearancePrint.GroupFooter.Options.UseBorderColor = True
        Me.GVPajak.AppearancePrint.GroupFooter.Options.UseFont = True
        Me.GVPajak.AppearancePrint.GroupRow.BackColor = System.Drawing.Color.White
        Me.GVPajak.AppearancePrint.GroupRow.BorderColor = System.Drawing.Color.Black
        Me.GVPajak.AppearancePrint.GroupRow.Font = New System.Drawing.Font("Tahoma", 7.25!, System.Drawing.FontStyle.Bold)
        Me.GVPajak.AppearancePrint.GroupRow.Options.UseBackColor = True
        Me.GVPajak.AppearancePrint.GroupRow.Options.UseBorderColor = True
        Me.GVPajak.AppearancePrint.GroupRow.Options.UseFont = True
        Me.GVPajak.AppearancePrint.HeaderPanel.BackColor = System.Drawing.Color.White
        Me.GVPajak.AppearancePrint.HeaderPanel.BorderColor = System.Drawing.Color.Black
        Me.GVPajak.AppearancePrint.HeaderPanel.Font = New System.Drawing.Font("Tahoma", 7.25!, System.Drawing.FontStyle.Bold)
        Me.GVPajak.AppearancePrint.HeaderPanel.Options.UseBackColor = True
        Me.GVPajak.AppearancePrint.HeaderPanel.Options.UseBorderColor = True
        Me.GVPajak.AppearancePrint.HeaderPanel.Options.UseFont = True
        Me.GVPajak.AppearancePrint.Lines.BackColor = System.Drawing.Color.Black
        Me.GVPajak.AppearancePrint.Lines.Options.UseBackColor = True
        Me.GVPajak.AppearancePrint.Row.BackColor = System.Drawing.Color.White
        Me.GVPajak.AppearancePrint.Row.BorderColor = System.Drawing.Color.Black
        Me.GVPajak.AppearancePrint.Row.Font = New System.Drawing.Font("Tahoma", 7.25!)
        Me.GVPajak.AppearancePrint.Row.Options.UseBackColor = True
        Me.GVPajak.AppearancePrint.Row.Options.UseBorderColor = True
        Me.GVPajak.AppearancePrint.Row.Options.UseFont = True
        Me.GVPajak.BandPanelRowHeight = 32
        Me.GVPajak.Bands.AddRange(New DevExpress.XtraGrid.Views.BandedGrid.GridBand() {Me.gridBand8, Me.GBWorkingDays, Me.GBSalary, Me.GBTotal, Me.gridBand1, Me.GBTHR, Me.gridBand3, Me.gridBand2})
        Me.GVPajak.ColumnPanelRowHeight = 48
        Me.GVPajak.Columns.AddRange(New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn() {Me.BandedGridColumnGroup, Me.BandedGridColumnDepartement, Me.GridColumnNIP, Me.GridColumnName, Me.GridColumnPosition, Me.GridColumnStatus, Me.BandedGridColumnNPWP, Me.BandedGridColumnJenisKelamin, Me.BandedGridColumnNPWPStatus, Me.BandedGridColumnActWorkdays, Me.BandedGridColumnOvertimeHours, Me.GridColumnTotTHP, Me.BandedGridColumnTotalAdjustment, Me.BandedGridColumnTotalPaymentOt, Me.BandedGridColumnTotal1, Me.BandedGridColumnTHR, Me.BandedGridColumnTotalDeduction, Me.BandedGridColumnTotal2, Me.BandedGridColumnGrandTotal, Me.BandedGridColumnJHTK, Me.BandedGridColumnJPK, Me.BandedGridColumnBPJSKESK, Me.BandedGridColumnTotalK, Me.BandedGridColumnJHTC, Me.BandedGridColumnJKKC, Me.BandedGridColumnJKMC, Me.BandedGridColumnJPC, Me.BandedGridColumnBPJSKESC, Me.BandedGridColumnTotalC, Me.BandedGridColumnTotalBPJSC})
        Me.GVPajak.GridControl = Me.GCPajak
        Me.GVPajak.GroupCount = 2
        Me.GVPajak.GroupSummary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "tot_thp", Me.GridColumnTotTHP, "{0:N2}"), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "total_adjustment", Me.BandedGridColumnTotalAdjustment, "{0:N2}"), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "total_ot_wages", Me.BandedGridColumnTotalPaymentOt, "{0:N2}"), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "total_1", Me.BandedGridColumnTotal1, "{0:N2}"), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "total_deduction", Me.BandedGridColumnTotalDeduction, "{0:N2}"), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "total_2", Me.BandedGridColumnTotal2, "{0:N2}"), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "grand_total", Me.BandedGridColumnGrandTotal, "{0:N2}"), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "jht", Me.BandedGridColumnJHTC, "{0:N2}"), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "jkk", Me.BandedGridColumnJKKC, "{0:N2}"), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "jkm", Me.BandedGridColumnJKMC, "{0:N2}"), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "jp", Me.BandedGridColumnJPC, "{0:N2}"), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "bpjs", Me.BandedGridColumnBPJSKESC, "{0:N2}"), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "total_jamsostek1", Me.BandedGridColumnTotalC, "{0:N2}"), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "total_jamsostek2", Me.BandedGridColumnTotalBPJSC, "{0:N2}"), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Custom, "employee_name", Me.GridColumnName, ""), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "jht_k", Me.BandedGridColumnJHTK, "{0:N2}"), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "jp_k", Me.BandedGridColumnJPK, "{0:N2}"), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "bpjs_k", Me.BandedGridColumnBPJSKESK, "{0:N2}"), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "total_k", Me.BandedGridColumnTotalK, "{0:N2}"), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "total_salary_thr", Me.BandedGridColumnTHR, "{0:N2}")})
        Me.GVPajak.LevelIndent = 0
        Me.GVPajak.Name = "GVPajak"
        Me.GVPajak.OptionsBehavior.AutoExpandAllGroups = True
        Me.GVPajak.OptionsMenu.ShowConditionalFormattingItem = True
        Me.GVPajak.OptionsPrint.AllowMultilineHeaders = True
        Me.GVPajak.OptionsView.ColumnAutoWidth = False
        Me.GVPajak.OptionsView.GroupFooterShowMode = DevExpress.XtraGrid.Views.Grid.GroupFooterShowMode.VisibleAlways
        Me.GVPajak.OptionsView.ShowFooter = True
        Me.GVPajak.OptionsView.ShowGroupExpandCollapseButtons = False
        Me.GVPajak.OptionsView.ShowGroupPanel = False
        Me.GVPajak.SortInfo.AddRange(New DevExpress.XtraGrid.Columns.GridColumnSortInfo() {New DevExpress.XtraGrid.Columns.GridColumnSortInfo(Me.BandedGridColumnGroup, DevExpress.Data.ColumnSortOrder.Descending), New DevExpress.XtraGrid.Columns.GridColumnSortInfo(Me.BandedGridColumnDepartement, DevExpress.Data.ColumnSortOrder.Ascending)})
        '
        'gridBand8
        '
        Me.gridBand8.AppearanceHeader.Options.UseTextOptions = True
        Me.gridBand8.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.gridBand8.Caption = "Karyawan"
        Me.gridBand8.Columns.Add(Me.GridColumnNIP)
        Me.gridBand8.Columns.Add(Me.GridColumnName)
        Me.gridBand8.Columns.Add(Me.BandedGridColumnNPWP)
        Me.gridBand8.Columns.Add(Me.BandedGridColumnJenisKelamin)
        Me.gridBand8.Columns.Add(Me.BandedGridColumnNPWPStatus)
        Me.gridBand8.Columns.Add(Me.BandedGridColumnDepartement)
        Me.gridBand8.Columns.Add(Me.GridColumnPosition)
        Me.gridBand8.Columns.Add(Me.GridColumnStatus)
        Me.gridBand8.Name = "gridBand8"
        Me.gridBand8.VisibleIndex = 0
        Me.gridBand8.Width = 430
        '
        'GridColumnNIP
        '
        Me.GridColumnNIP.AppearanceHeader.Options.UseTextOptions = True
        Me.GridColumnNIP.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
        Me.GridColumnNIP.Caption = "NIP"
        Me.GridColumnNIP.FieldName = "employee_code"
        Me.GridColumnNIP.MinWidth = 45
        Me.GridColumnNIP.Name = "GridColumnNIP"
        Me.GridColumnNIP.OptionsColumn.AllowEdit = False
        Me.GridColumnNIP.Visible = True
        Me.GridColumnNIP.Width = 45
        '
        'GridColumnName
        '
        Me.GridColumnName.AppearanceHeader.Options.UseTextOptions = True
        Me.GridColumnName.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
        Me.GridColumnName.Caption = "Nama"
        Me.GridColumnName.FieldName = "employee_name"
        Me.GridColumnName.MinWidth = 185
        Me.GridColumnName.Name = "GridColumnName"
        Me.GridColumnName.OptionsColumn.AllowEdit = False
        Me.GridColumnName.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Custom)})
        Me.GridColumnName.Visible = True
        Me.GridColumnName.Width = 200
        '
        'BandedGridColumnNPWP
        '
        Me.BandedGridColumnNPWP.AppearanceHeader.Options.UseTextOptions = True
        Me.BandedGridColumnNPWP.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
        Me.BandedGridColumnNPWP.Caption = "NPWP"
        Me.BandedGridColumnNPWP.FieldName = "employee_npwp"
        Me.BandedGridColumnNPWP.MinWidth = 100
        Me.BandedGridColumnNPWP.Name = "BandedGridColumnNPWP"
        Me.BandedGridColumnNPWP.Visible = True
        Me.BandedGridColumnNPWP.Width = 100
        '
        'BandedGridColumnJenisKelamin
        '
        Me.BandedGridColumnJenisKelamin.AppearanceHeader.Options.UseTextOptions = True
        Me.BandedGridColumnJenisKelamin.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
        Me.BandedGridColumnJenisKelamin.Caption = "Jenis Kelamin"
        Me.BandedGridColumnJenisKelamin.FieldName = "employee_sex"
        Me.BandedGridColumnJenisKelamin.MinWidth = 45
        Me.BandedGridColumnJenisKelamin.Name = "BandedGridColumnJenisKelamin"
        Me.BandedGridColumnJenisKelamin.Visible = True
        Me.BandedGridColumnJenisKelamin.Width = 45
        '
        'BandedGridColumnNPWPStatus
        '
        Me.BandedGridColumnNPWPStatus.AppearanceHeader.Options.UseTextOptions = True
        Me.BandedGridColumnNPWPStatus.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
        Me.BandedGridColumnNPWPStatus.Caption = "Status"
        Me.BandedGridColumnNPWPStatus.FieldName = "npwp_status"
        Me.BandedGridColumnNPWPStatus.MinWidth = 40
        Me.BandedGridColumnNPWPStatus.Name = "BandedGridColumnNPWPStatus"
        Me.BandedGridColumnNPWPStatus.Visible = True
        Me.BandedGridColumnNPWPStatus.Width = 40
        '
        'BandedGridColumnDepartement
        '
        Me.BandedGridColumnDepartement.AppearanceHeader.Options.UseTextOptions = True
        Me.BandedGridColumnDepartement.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
        Me.BandedGridColumnDepartement.Caption = "Departement"
        Me.BandedGridColumnDepartement.FieldName = "departement"
        Me.BandedGridColumnDepartement.Name = "BandedGridColumnDepartement"
        Me.BandedGridColumnDepartement.OptionsColumn.AllowEdit = False
        Me.BandedGridColumnDepartement.Width = 86
        '
        'GridColumnPosition
        '
        Me.GridColumnPosition.AppearanceHeader.Options.UseTextOptions = True
        Me.GridColumnPosition.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
        Me.GridColumnPosition.Caption = "Employee Position"
        Me.GridColumnPosition.FieldName = "employee_position"
        Me.GridColumnPosition.MinWidth = 150
        Me.GridColumnPosition.Name = "GridColumnPosition"
        Me.GridColumnPosition.OptionsColumn.AllowEdit = False
        Me.GridColumnPosition.Width = 150
        '
        'GridColumnStatus
        '
        Me.GridColumnStatus.AppearanceHeader.Options.UseTextOptions = True
        Me.GridColumnStatus.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
        Me.GridColumnStatus.Caption = "Employee Status"
        Me.GridColumnStatus.FieldName = "employee_status"
        Me.GridColumnStatus.MinWidth = 60
        Me.GridColumnStatus.Name = "GridColumnStatus"
        Me.GridColumnStatus.OptionsColumn.AllowEdit = False
        Me.GridColumnStatus.Width = 90
        '
        'GBWorkingDays
        '
        Me.GBWorkingDays.AppearanceHeader.Options.UseTextOptions = True
        Me.GBWorkingDays.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GBWorkingDays.Caption = "Working Days (WD)"
        Me.GBWorkingDays.Columns.Add(Me.BandedGridColumnActWorkdays)
        Me.GBWorkingDays.Columns.Add(Me.BandedGridColumnOvertimeHours)
        Me.GBWorkingDays.Name = "GBWorkingDays"
        Me.GBWorkingDays.Visible = False
        Me.GBWorkingDays.VisibleIndex = -1
        Me.GBWorkingDays.Width = 105
        '
        'BandedGridColumnActWorkdays
        '
        Me.BandedGridColumnActWorkdays.AppearanceCell.Options.UseTextOptions = True
        Me.BandedGridColumnActWorkdays.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.BandedGridColumnActWorkdays.AppearanceHeader.Options.UseTextOptions = True
        Me.BandedGridColumnActWorkdays.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
        Me.BandedGridColumnActWorkdays.Caption = "Actual WD"
        Me.BandedGridColumnActWorkdays.DisplayFormat.FormatString = "N1"
        Me.BandedGridColumnActWorkdays.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.BandedGridColumnActWorkdays.FieldName = "actual_workdays"
        Me.BandedGridColumnActWorkdays.Name = "BandedGridColumnActWorkdays"
        Me.BandedGridColumnActWorkdays.OptionsColumn.AllowEdit = False
        Me.BandedGridColumnActWorkdays.Visible = True
        Me.BandedGridColumnActWorkdays.Width = 60
        '
        'BandedGridColumnOvertimeHours
        '
        Me.BandedGridColumnOvertimeHours.AppearanceHeader.Options.UseTextOptions = True
        Me.BandedGridColumnOvertimeHours.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
        Me.BandedGridColumnOvertimeHours.Caption = "Overtime (Hours)"
        Me.BandedGridColumnOvertimeHours.DisplayFormat.FormatString = "N1"
        Me.BandedGridColumnOvertimeHours.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.BandedGridColumnOvertimeHours.FieldName = "total_ot_hour"
        Me.BandedGridColumnOvertimeHours.Name = "BandedGridColumnOvertimeHours"
        Me.BandedGridColumnOvertimeHours.OptionsColumn.AllowEdit = False
        Me.BandedGridColumnOvertimeHours.Visible = True
        Me.BandedGridColumnOvertimeHours.Width = 93
        '
        'GBSalary
        '
        Me.GBSalary.AppearanceHeader.Options.UseTextOptions = True
        Me.GBSalary.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GBSalary.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
        Me.GBSalary.Caption = "Penghasilan Bruto"
        Me.GBSalary.Columns.Add(Me.GridColumnTotTHP)
        Me.GBSalary.Columns.Add(Me.BandedGridColumnTotalAdjustment)
        Me.GBSalary.Columns.Add(Me.BandedGridColumnTotalPaymentOt)
        Me.GBSalary.Columns.Add(Me.BandedGridColumnTotal1)
        Me.GBSalary.Name = "GBSalary"
        Me.GBSalary.VisibleIndex = 1
        Me.GBSalary.Width = 86
        '
        'GridColumnTotTHP
        '
        Me.GridColumnTotTHP.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumnTotTHP.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumnTotTHP.AppearanceHeader.Options.UseTextOptions = True
        Me.GridColumnTotTHP.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumnTotTHP.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
        Me.GridColumnTotTHP.Caption = "Total THP"
        Me.GridColumnTotTHP.DisplayFormat.FormatString = "N2"
        Me.GridColumnTotTHP.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumnTotTHP.FieldName = "tot_thp"
        Me.GridColumnTotTHP.Name = "GridColumnTotTHP"
        Me.GridColumnTotTHP.OptionsColumn.AllowEdit = False
        Me.GridColumnTotTHP.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "tot_thp", "{0:N2}")})
        '
        'BandedGridColumnTotalAdjustment
        '
        Me.BandedGridColumnTotalAdjustment.AppearanceCell.Options.UseTextOptions = True
        Me.BandedGridColumnTotalAdjustment.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.BandedGridColumnTotalAdjustment.AppearanceHeader.Options.UseTextOptions = True
        Me.BandedGridColumnTotalAdjustment.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.BandedGridColumnTotalAdjustment.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
        Me.BandedGridColumnTotalAdjustment.Caption = "Total Bonus / Adjustment"
        Me.BandedGridColumnTotalAdjustment.DisplayFormat.FormatString = "N2"
        Me.BandedGridColumnTotalAdjustment.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.BandedGridColumnTotalAdjustment.FieldName = "total_adjustment"
        Me.BandedGridColumnTotalAdjustment.Name = "BandedGridColumnTotalAdjustment"
        Me.BandedGridColumnTotalAdjustment.OptionsColumn.AllowEdit = False
        Me.BandedGridColumnTotalAdjustment.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "total_adjustment", "{0:N2}")})
        Me.BandedGridColumnTotalAdjustment.Width = 131
        '
        'BandedGridColumnTotalPaymentOt
        '
        Me.BandedGridColumnTotalPaymentOt.AppearanceCell.Options.UseTextOptions = True
        Me.BandedGridColumnTotalPaymentOt.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.BandedGridColumnTotalPaymentOt.AppearanceHeader.Options.UseTextOptions = True
        Me.BandedGridColumnTotalPaymentOt.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.BandedGridColumnTotalPaymentOt.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
        Me.BandedGridColumnTotalPaymentOt.Caption = "Total Overtime"
        Me.BandedGridColumnTotalPaymentOt.DisplayFormat.FormatString = "N2"
        Me.BandedGridColumnTotalPaymentOt.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.BandedGridColumnTotalPaymentOt.FieldName = "total_ot_wages"
        Me.BandedGridColumnTotalPaymentOt.Name = "BandedGridColumnTotalPaymentOt"
        Me.BandedGridColumnTotalPaymentOt.OptionsColumn.AllowEdit = False
        Me.BandedGridColumnTotalPaymentOt.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "total_ot_wages", "{0:N2}")})
        Me.BandedGridColumnTotalPaymentOt.Width = 81
        '
        'BandedGridColumnTotal1
        '
        Me.BandedGridColumnTotal1.AppearanceHeader.Options.UseTextOptions = True
        Me.BandedGridColumnTotal1.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
        Me.BandedGridColumnTotal1.Caption = "Total I"
        Me.BandedGridColumnTotal1.DisplayFormat.FormatString = "N2"
        Me.BandedGridColumnTotal1.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.BandedGridColumnTotal1.FieldName = "total_1"
        Me.BandedGridColumnTotal1.Name = "BandedGridColumnTotal1"
        Me.BandedGridColumnTotal1.OptionsColumn.AllowEdit = False
        Me.BandedGridColumnTotal1.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "total_1", "{0:N2}")})
        Me.BandedGridColumnTotal1.Visible = True
        Me.BandedGridColumnTotal1.Width = 86
        '
        'GBTotal
        '
        Me.GBTotal.Columns.Add(Me.BandedGridColumnGrandTotal)
        Me.GBTotal.Name = "GBTotal"
        Me.GBTotal.Visible = False
        Me.GBTotal.VisibleIndex = -1
        Me.GBTotal.Width = 75
        '
        'BandedGridColumnGrandTotal
        '
        Me.BandedGridColumnGrandTotal.AppearanceCell.Options.UseTextOptions = True
        Me.BandedGridColumnGrandTotal.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.BandedGridColumnGrandTotal.AppearanceHeader.Options.UseTextOptions = True
        Me.BandedGridColumnGrandTotal.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.BandedGridColumnGrandTotal.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
        Me.BandedGridColumnGrandTotal.Caption = "Grand Total"
        Me.BandedGridColumnGrandTotal.DisplayFormat.FormatString = "N0"
        Me.BandedGridColumnGrandTotal.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.BandedGridColumnGrandTotal.FieldName = "grand_total"
        Me.BandedGridColumnGrandTotal.Name = "BandedGridColumnGrandTotal"
        Me.BandedGridColumnGrandTotal.OptionsColumn.AllowEdit = False
        Me.BandedGridColumnGrandTotal.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "grand_total", "{0:N0}")})
        Me.BandedGridColumnGrandTotal.Visible = True
        '
        'gridBand1
        '
        Me.gridBand1.Columns.Add(Me.BandedGridColumnTotalDeduction)
        Me.gridBand1.Columns.Add(Me.BandedGridColumnTotal2)
        Me.gridBand1.Name = "gridBand1"
        Me.gridBand1.Visible = False
        Me.gridBand1.VisibleIndex = -1
        Me.gridBand1.Width = 165
        '
        'BandedGridColumnTotalDeduction
        '
        Me.BandedGridColumnTotalDeduction.AppearanceCell.Options.UseTextOptions = True
        Me.BandedGridColumnTotalDeduction.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.BandedGridColumnTotalDeduction.AppearanceHeader.Options.UseTextOptions = True
        Me.BandedGridColumnTotalDeduction.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.BandedGridColumnTotalDeduction.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
        Me.BandedGridColumnTotalDeduction.Caption = "Total Deduction"
        Me.BandedGridColumnTotalDeduction.DisplayFormat.FormatString = "N2"
        Me.BandedGridColumnTotalDeduction.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.BandedGridColumnTotalDeduction.FieldName = "total_deduction"
        Me.BandedGridColumnTotalDeduction.Name = "BandedGridColumnTotalDeduction"
        Me.BandedGridColumnTotalDeduction.OptionsColumn.AllowEdit = False
        Me.BandedGridColumnTotalDeduction.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "total_deduction", "{0:N2}")})
        Me.BandedGridColumnTotalDeduction.Visible = True
        Me.BandedGridColumnTotalDeduction.Width = 90
        '
        'BandedGridColumnTotal2
        '
        Me.BandedGridColumnTotal2.AppearanceHeader.Options.UseTextOptions = True
        Me.BandedGridColumnTotal2.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
        Me.BandedGridColumnTotal2.Caption = "Total II"
        Me.BandedGridColumnTotal2.DisplayFormat.FormatString = "N2"
        Me.BandedGridColumnTotal2.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.BandedGridColumnTotal2.FieldName = "total_2"
        Me.BandedGridColumnTotal2.Name = "BandedGridColumnTotal2"
        Me.BandedGridColumnTotal2.OptionsColumn.AllowEdit = False
        Me.BandedGridColumnTotal2.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "total_2", "{0:N2}")})
        Me.BandedGridColumnTotal2.Visible = True
        '
        'GBTHR
        '
        Me.GBTHR.AppearanceHeader.Options.UseTextOptions = True
        Me.GBTHR.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GBTHR.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
        Me.GBTHR.Caption = "Penghasilan Bruto"
        Me.GBTHR.Columns.Add(Me.BandedGridColumnTHR)
        Me.GBTHR.Name = "GBTHR"
        Me.GBTHR.VisibleIndex = 2
        Me.GBTHR.Width = 75
        '
        'BandedGridColumnTHR
        '
        Me.BandedGridColumnTHR.Caption = "Total I"
        Me.BandedGridColumnTHR.DisplayFormat.FormatString = "N2"
        Me.BandedGridColumnTHR.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.BandedGridColumnTHR.FieldName = "total_salary_thr"
        Me.BandedGridColumnTHR.Name = "BandedGridColumnTHR"
        Me.BandedGridColumnTHR.OptionsColumn.AllowEdit = False
        Me.BandedGridColumnTHR.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "total_salary_thr", "{0:N2}")})
        Me.BandedGridColumnTHR.Visible = True
        '
        'gridBand3
        '
        Me.gridBand3.AppearanceHeader.Options.UseTextOptions = True
        Me.gridBand3.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.gridBand3.Caption = "BPJS (Tanggungan Karyawan)"
        Me.gridBand3.Columns.Add(Me.BandedGridColumnJHTK)
        Me.gridBand3.Columns.Add(Me.BandedGridColumnJPK)
        Me.gridBand3.Columns.Add(Me.BandedGridColumnBPJSKESK)
        Me.gridBand3.Columns.Add(Me.BandedGridColumnTotalK)
        Me.gridBand3.Name = "gridBand3"
        Me.gridBand3.VisibleIndex = 3
        Me.gridBand3.Width = 300
        '
        'BandedGridColumnJHTK
        '
        Me.BandedGridColumnJHTK.AppearanceHeader.Options.UseTextOptions = True
        Me.BandedGridColumnJHTK.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
        Me.BandedGridColumnJHTK.Caption = "JHT 2%"
        Me.BandedGridColumnJHTK.DisplayFormat.FormatString = "N2"
        Me.BandedGridColumnJHTK.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.BandedGridColumnJHTK.FieldName = "jht_k"
        Me.BandedGridColumnJHTK.Name = "BandedGridColumnJHTK"
        Me.BandedGridColumnJHTK.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "jht_k", "{0:N2}")})
        Me.BandedGridColumnJHTK.Visible = True
        '
        'BandedGridColumnJPK
        '
        Me.BandedGridColumnJPK.AppearanceHeader.Options.UseTextOptions = True
        Me.BandedGridColumnJPK.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
        Me.BandedGridColumnJPK.Caption = "JP 1%"
        Me.BandedGridColumnJPK.DisplayFormat.FormatString = "N2"
        Me.BandedGridColumnJPK.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.BandedGridColumnJPK.FieldName = "jp_k"
        Me.BandedGridColumnJPK.Name = "BandedGridColumnJPK"
        Me.BandedGridColumnJPK.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "jp_k", "{0:N2}")})
        Me.BandedGridColumnJPK.Visible = True
        '
        'BandedGridColumnBPJSKESK
        '
        Me.BandedGridColumnBPJSKESK.AppearanceHeader.Options.UseTextOptions = True
        Me.BandedGridColumnBPJSKESK.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
        Me.BandedGridColumnBPJSKESK.Caption = "BPJSKES 1%"
        Me.BandedGridColumnBPJSKESK.DisplayFormat.FormatString = "N2"
        Me.BandedGridColumnBPJSKESK.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.BandedGridColumnBPJSKESK.FieldName = "bpjs_k"
        Me.BandedGridColumnBPJSKESK.Name = "BandedGridColumnBPJSKESK"
        Me.BandedGridColumnBPJSKESK.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "bpjs_k", "{0:N2}")})
        Me.BandedGridColumnBPJSKESK.Visible = True
        '
        'BandedGridColumnTotalK
        '
        Me.BandedGridColumnTotalK.AppearanceHeader.Options.UseTextOptions = True
        Me.BandedGridColumnTotalK.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
        Me.BandedGridColumnTotalK.Caption = "Total"
        Me.BandedGridColumnTotalK.DisplayFormat.FormatString = "N2"
        Me.BandedGridColumnTotalK.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.BandedGridColumnTotalK.FieldName = "total_k"
        Me.BandedGridColumnTotalK.Name = "BandedGridColumnTotalK"
        Me.BandedGridColumnTotalK.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "total_k", "{0:N2}")})
        Me.BandedGridColumnTotalK.Visible = True
        '
        'gridBand2
        '
        Me.gridBand2.AppearanceHeader.Options.UseTextOptions = True
        Me.gridBand2.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.gridBand2.Caption = "BPJS (Tanggungan Perusahaan)"
        Me.gridBand2.Columns.Add(Me.BandedGridColumnJHTC)
        Me.gridBand2.Columns.Add(Me.BandedGridColumnJKKC)
        Me.gridBand2.Columns.Add(Me.BandedGridColumnJKMC)
        Me.gridBand2.Columns.Add(Me.BandedGridColumnJPC)
        Me.gridBand2.Columns.Add(Me.BandedGridColumnBPJSKESC)
        Me.gridBand2.Columns.Add(Me.BandedGridColumnTotalC)
        Me.gridBand2.Columns.Add(Me.BandedGridColumnTotalBPJSC)
        Me.gridBand2.Name = "gridBand2"
        Me.gridBand2.VisibleIndex = 4
        Me.gridBand2.Width = 473
        '
        'BandedGridColumnJHTC
        '
        Me.BandedGridColumnJHTC.AppearanceHeader.Options.UseTextOptions = True
        Me.BandedGridColumnJHTC.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
        Me.BandedGridColumnJHTC.Caption = "JHT 3.7%"
        Me.BandedGridColumnJHTC.DisplayFormat.FormatString = "N2"
        Me.BandedGridColumnJHTC.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.BandedGridColumnJHTC.FieldName = "jht"
        Me.BandedGridColumnJHTC.Name = "BandedGridColumnJHTC"
        Me.BandedGridColumnJHTC.OptionsColumn.AllowEdit = False
        Me.BandedGridColumnJHTC.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "jht", "{0:N2}")})
        Me.BandedGridColumnJHTC.Visible = True
        Me.BandedGridColumnJHTC.Width = 58
        '
        'BandedGridColumnJKKC
        '
        Me.BandedGridColumnJKKC.AppearanceHeader.Options.UseTextOptions = True
        Me.BandedGridColumnJKKC.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
        Me.BandedGridColumnJKKC.Caption = "JKK 0.24%"
        Me.BandedGridColumnJKKC.DisplayFormat.FormatString = "N2"
        Me.BandedGridColumnJKKC.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.BandedGridColumnJKKC.FieldName = "jkk"
        Me.BandedGridColumnJKKC.Name = "BandedGridColumnJKKC"
        Me.BandedGridColumnJKKC.OptionsColumn.AllowEdit = False
        Me.BandedGridColumnJKKC.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "jkk", "{0:N2}")})
        Me.BandedGridColumnJKKC.Visible = True
        Me.BandedGridColumnJKKC.Width = 63
        '
        'BandedGridColumnJKMC
        '
        Me.BandedGridColumnJKMC.AppearanceHeader.Options.UseTextOptions = True
        Me.BandedGridColumnJKMC.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
        Me.BandedGridColumnJKMC.Caption = "JKM 0.3%"
        Me.BandedGridColumnJKMC.DisplayFormat.FormatString = "N2"
        Me.BandedGridColumnJKMC.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.BandedGridColumnJKMC.FieldName = "jkm"
        Me.BandedGridColumnJKMC.Name = "BandedGridColumnJKMC"
        Me.BandedGridColumnJKMC.OptionsColumn.AllowEdit = False
        Me.BandedGridColumnJKMC.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "jkm", "{0:N2}")})
        Me.BandedGridColumnJKMC.Visible = True
        Me.BandedGridColumnJKMC.Width = 59
        '
        'BandedGridColumnJPC
        '
        Me.BandedGridColumnJPC.AppearanceHeader.Options.UseTextOptions = True
        Me.BandedGridColumnJPC.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
        Me.BandedGridColumnJPC.Caption = "JP 2%"
        Me.BandedGridColumnJPC.DisplayFormat.FormatString = "N2"
        Me.BandedGridColumnJPC.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.BandedGridColumnJPC.FieldName = "jp"
        Me.BandedGridColumnJPC.Name = "BandedGridColumnJPC"
        Me.BandedGridColumnJPC.OptionsColumn.AllowEdit = False
        Me.BandedGridColumnJPC.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "jp", "{0:N2}")})
        Me.BandedGridColumnJPC.Visible = True
        Me.BandedGridColumnJPC.Width = 41
        '
        'BandedGridColumnBPJSKESC
        '
        Me.BandedGridColumnBPJSKESC.AppearanceHeader.Options.UseTextOptions = True
        Me.BandedGridColumnBPJSKESC.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
        Me.BandedGridColumnBPJSKESC.Caption = "BPJSKES 4%"
        Me.BandedGridColumnBPJSKESC.DisplayFormat.FormatString = "N2"
        Me.BandedGridColumnBPJSKESC.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.BandedGridColumnBPJSKESC.FieldName = "bpjs"
        Me.BandedGridColumnBPJSKESC.Name = "BandedGridColumnBPJSKESC"
        Me.BandedGridColumnBPJSKESC.OptionsColumn.AllowEdit = False
        Me.BandedGridColumnBPJSKESC.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "bpjs", "{0:N2}")})
        Me.BandedGridColumnBPJSKESC.Visible = True
        Me.BandedGridColumnBPJSKESC.Width = 71
        '
        'BandedGridColumnTotalC
        '
        Me.BandedGridColumnTotalC.AppearanceHeader.Options.UseTextOptions = True
        Me.BandedGridColumnTotalC.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
        Me.BandedGridColumnTotalC.Caption = "Total"
        Me.BandedGridColumnTotalC.DisplayFormat.FormatString = "N2"
        Me.BandedGridColumnTotalC.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.BandedGridColumnTotalC.FieldName = "total_jamsostek1"
        Me.BandedGridColumnTotalC.Name = "BandedGridColumnTotalC"
        Me.BandedGridColumnTotalC.OptionsColumn.AllowEdit = False
        Me.BandedGridColumnTotalC.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "total_jamsostek1", "{0:N2}")})
        Me.BandedGridColumnTotalC.Visible = True
        Me.BandedGridColumnTotalC.Width = 37
        '
        'BandedGridColumnTotalBPJSC
        '
        Me.BandedGridColumnTotalBPJSC.AppearanceHeader.Options.UseTextOptions = True
        Me.BandedGridColumnTotalBPJSC.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
        Me.BandedGridColumnTotalBPJSC.Caption = "Total BPJS (JKK, JKM, BPJSKES)"
        Me.BandedGridColumnTotalBPJSC.DisplayFormat.FormatString = "N2"
        Me.BandedGridColumnTotalBPJSC.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.BandedGridColumnTotalBPJSC.FieldName = "total_jamsostek2"
        Me.BandedGridColumnTotalBPJSC.Name = "BandedGridColumnTotalBPJSC"
        Me.BandedGridColumnTotalBPJSC.OptionsColumn.AllowEdit = False
        Me.BandedGridColumnTotalBPJSC.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "total_jamsostek2", "{0:N2}")})
        Me.BandedGridColumnTotalBPJSC.Visible = True
        Me.BandedGridColumnTotalBPJSC.Width = 144
        '
        'BandedGridColumnGroup
        '
        Me.BandedGridColumnGroup.AppearanceHeader.Options.UseTextOptions = True
        Me.BandedGridColumnGroup.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
        Me.BandedGridColumnGroup.Caption = "Group"
        Me.BandedGridColumnGroup.FieldName = "group_report"
        Me.BandedGridColumnGroup.Name = "BandedGridColumnGroup"
        Me.BandedGridColumnGroup.OptionsColumn.AllowEdit = False
        '
        'WinControlContainer1
        '
        Me.WinControlContainer1.LocationFloat = New DevExpress.Utils.PointFloat(0!, 0!)
        Me.WinControlContainer1.Name = "WinControlContainer1"
        Me.WinControlContainer1.SizeF = New System.Drawing.SizeF(1075.0!, 312.0!)
        Me.WinControlContainer1.WinControl = Me.GCPajak
        '
        'ReportEmpPayrollReportPajak
        '
        Me.Bands.AddRange(New DevExpress.XtraReports.UI.Band() {Me.Detail, Me.TopMargin, Me.BottomMargin, Me.ReportHeader, Me.ReportFooter})
        Me.Landscape = True
        Me.Margins = New System.Drawing.Printing.Margins(25, 69, 30, 50)
        Me.PageHeight = 827
        Me.PageWidth = 1169
        Me.PaperKind = System.Drawing.Printing.PaperKind.A4
        Me.ScriptLanguage = DevExpress.XtraReports.ScriptLanguage.VisualBasic
        Me.Version = "15.1"
        CType(Me.XrTable1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GCPajak, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVPajak, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me, System.ComponentModel.ISupportInitialize).EndInit()

    End Sub
    Friend WithEvents Detail As DevExpress.XtraReports.UI.DetailBand
    Friend WithEvents TopMargin As DevExpress.XtraReports.UI.TopMarginBand
    Friend WithEvents BottomMargin As DevExpress.XtraReports.UI.BottomMarginBand
    Friend WithEvents ReportHeader As DevExpress.XtraReports.UI.ReportHeaderBand
    Friend WithEvents ReportFooter As DevExpress.XtraReports.UI.ReportFooterBand
    Friend WithEvents XLTitle As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XLPeriod As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrTable1 As DevExpress.XtraReports.UI.XRTable
    Friend WithEvents XrTableRow1 As DevExpress.XtraReports.UI.XRTableRow
    Friend WithEvents XrTableCell13 As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents XrPageInfo1 As DevExpress.XtraReports.UI.XRPageInfo
    Friend WithEvents WinControlContainer1 As DevExpress.XtraReports.UI.WinControlContainer
    Friend WithEvents GCPajak As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVPajak As DevExpress.XtraGrid.Views.BandedGrid.BandedGridView
    Friend WithEvents gridBand8 As DevExpress.XtraGrid.Views.BandedGrid.GridBand
    Friend WithEvents GridColumnNIP As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents GridColumnName As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumnNPWP As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumnJenisKelamin As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumnNPWPStatus As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumnDepartement As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents GridColumnPosition As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents GridColumnStatus As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents GBWorkingDays As DevExpress.XtraGrid.Views.BandedGrid.GridBand
    Friend WithEvents BandedGridColumnActWorkdays As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumnOvertimeHours As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents GBSalary As DevExpress.XtraGrid.Views.BandedGrid.GridBand
    Friend WithEvents GridColumnTotTHP As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumnTotalAdjustment As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumnTotalPaymentOt As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumnTotal1 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents GBTotal As DevExpress.XtraGrid.Views.BandedGrid.GridBand
    Friend WithEvents BandedGridColumnGrandTotal As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents gridBand1 As DevExpress.XtraGrid.Views.BandedGrid.GridBand
    Friend WithEvents BandedGridColumnTotalDeduction As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumnTotal2 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents GBTHR As DevExpress.XtraGrid.Views.BandedGrid.GridBand
    Friend WithEvents BandedGridColumnTHR As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents gridBand3 As DevExpress.XtraGrid.Views.BandedGrid.GridBand
    Friend WithEvents BandedGridColumnJHTK As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumnJPK As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumnBPJSKESK As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumnTotalK As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents gridBand2 As DevExpress.XtraGrid.Views.BandedGrid.GridBand
    Friend WithEvents BandedGridColumnJHTC As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumnJKKC As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumnJKMC As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumnJPC As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumnBPJSKESC As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumnTotalC As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumnTotalBPJSC As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumnGroup As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
End Class
