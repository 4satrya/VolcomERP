<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class ReportSampleBudget
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ReportSampleBudget))
        Me.Detail = New DevExpress.XtraReports.UI.DetailBand()
        Me.WinControlContainer1 = New DevExpress.XtraReports.UI.WinControlContainer()
        Me.GCReportBudgetSample = New DevExpress.XtraGrid.GridControl()
        Me.GVReportBudgetSample = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridView()
        Me.GBBefore = New DevExpress.XtraGrid.Views.BandedGrid.GridBand()
        Me.BandedGridColumnDescBefore = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumnCatBefore = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumn5 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumn4 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumn3 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumn7 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumn8 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.GridColumn9 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.GBProposed = New DevExpress.XtraGrid.Views.BandedGrid.GridBand()
        Me.GridColumn11 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.GridColumnDescAfter = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.GridColumnCatAfter = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.GridColumn15 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.GridColumn14 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.GridColumn13 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumn6 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumn9 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.RepositoryItemCheckEdit2 = New DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit()
        Me.RepositoryItemDateEdit2 = New DevExpress.XtraEditors.Repository.RepositoryItemDateEdit()
        Me.TopMargin = New DevExpress.XtraReports.UI.TopMarginBand()
        Me.XrPictureBox1 = New DevExpress.XtraReports.UI.XRPictureBox()
        Me.LTitle = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLine1 = New DevExpress.XtraReports.UI.XRLine()
        Me.LPoNumber = New DevExpress.XtraReports.UI.XRLabel()
        Me.BottomMargin = New DevExpress.XtraReports.UI.BottomMarginBand()
        Me.PageHeader = New DevExpress.XtraReports.UI.PageHeaderBand()
        Me.XrLabel8 = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLabel9 = New DevExpress.XtraReports.UI.XRLabel()
        Me.LTypePropose = New DevExpress.XtraReports.UI.XRLabel()
        Me.LCreatedDate = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLabel6 = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLabel7 = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLabel1 = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLabel2 = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLabel3 = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLabel4 = New DevExpress.XtraReports.UI.XRLabel()
        Me.LNumber = New DevExpress.XtraReports.UI.XRLabel()
        Me.LPrroposedBy = New DevExpress.XtraReports.UI.XRLabel()
        Me.ReportFooter = New DevExpress.XtraReports.UI.ReportFooterBand()
        Me.LNote = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLabel10 = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLabel11 = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrTable1 = New DevExpress.XtraReports.UI.XRTable()
        Me.XrTableRow1 = New DevExpress.XtraReports.UI.XRTableRow()
        Me.XrTableCell1 = New DevExpress.XtraReports.UI.XRTableCell()
        CType(Me.GCReportBudgetSample, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVReportBudgetSample, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemCheckEdit2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemDateEdit2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemDateEdit2.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.XrTable1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
        '
        'Detail
        '
        Me.Detail.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.WinControlContainer1})
        Me.Detail.HeightF = 100.0!
        Me.Detail.Name = "Detail"
        Me.Detail.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
        Me.Detail.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
        '
        'WinControlContainer1
        '
        Me.WinControlContainer1.LocationFloat = New DevExpress.Utils.PointFloat(0!, 0!)
        Me.WinControlContainer1.Name = "WinControlContainer1"
        Me.WinControlContainer1.SizeF = New System.Drawing.SizeF(968.9999!, 100.0!)
        Me.WinControlContainer1.WinControl = Me.GCReportBudgetSample
        '
        'GCReportBudgetSample
        '
        Me.GCReportBudgetSample.Location = New System.Drawing.Point(2, 2)
        Me.GCReportBudgetSample.MainView = Me.GVReportBudgetSample
        Me.GCReportBudgetSample.Name = "GCReportBudgetSample"
        Me.GCReportBudgetSample.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.RepositoryItemCheckEdit2, Me.RepositoryItemDateEdit2})
        Me.GCReportBudgetSample.Size = New System.Drawing.Size(930, 96)
        Me.GCReportBudgetSample.TabIndex = 8937
        Me.GCReportBudgetSample.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVReportBudgetSample})
        '
        'GVReportBudgetSample
        '
        Me.GVReportBudgetSample.Bands.AddRange(New DevExpress.XtraGrid.Views.BandedGrid.GridBand() {Me.GBBefore, Me.GBProposed})
        Me.GVReportBudgetSample.Columns.AddRange(New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn() {Me.GridColumn9, Me.GridColumnDescAfter, Me.GridColumn11, Me.GridColumnCatAfter, Me.BandedGridColumn6, Me.GridColumn13, Me.GridColumn14, Me.BandedGridColumn9, Me.GridColumn15, Me.BandedGridColumnDescBefore, Me.BandedGridColumnCatBefore, Me.BandedGridColumn3, Me.BandedGridColumn7, Me.BandedGridColumn4, Me.BandedGridColumn5, Me.BandedGridColumn8})
        Me.GVReportBudgetSample.GridControl = Me.GCReportBudgetSample
        Me.GVReportBudgetSample.Name = "GVReportBudgetSample"
        Me.GVReportBudgetSample.OptionsView.ShowGroupPanel = False
        Me.GVReportBudgetSample.RowHeight = 30
        '
        'GBBefore
        '
        Me.GBBefore.AppearanceHeader.Options.UseTextOptions = True
        Me.GBBefore.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GBBefore.Caption = "Before"
        Me.GBBefore.Columns.Add(Me.BandedGridColumnDescBefore)
        Me.GBBefore.Columns.Add(Me.BandedGridColumnCatBefore)
        Me.GBBefore.Columns.Add(Me.BandedGridColumn5)
        Me.GBBefore.Columns.Add(Me.BandedGridColumn4)
        Me.GBBefore.Columns.Add(Me.BandedGridColumn3)
        Me.GBBefore.Columns.Add(Me.BandedGridColumn7)
        Me.GBBefore.Columns.Add(Me.BandedGridColumn8)
        Me.GBBefore.Columns.Add(Me.GridColumn9)
        Me.GBBefore.Name = "GBBefore"
        Me.GBBefore.VisibleIndex = 0
        Me.GBBefore.Width = 623
        '
        'BandedGridColumnDescBefore
        '
        Me.BandedGridColumnDescBefore.AppearanceCell.Options.UseTextOptions = True
        Me.BandedGridColumnDescBefore.AppearanceCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
        Me.BandedGridColumnDescBefore.Caption = "Description"
        Me.BandedGridColumnDescBefore.FieldName = "description_before"
        Me.BandedGridColumnDescBefore.Name = "BandedGridColumnDescBefore"
        Me.BandedGridColumnDescBefore.Visible = True
        Me.BandedGridColumnDescBefore.Width = 211
        '
        'BandedGridColumnCatBefore
        '
        Me.BandedGridColumnCatBefore.AppearanceCell.Options.UseTextOptions = True
        Me.BandedGridColumnCatBefore.AppearanceCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
        Me.BandedGridColumnCatBefore.Caption = "Category"
        Me.BandedGridColumnCatBefore.FieldName = "division_before"
        Me.BandedGridColumnCatBefore.Name = "BandedGridColumnCatBefore"
        Me.BandedGridColumnCatBefore.Visible = True
        Me.BandedGridColumnCatBefore.Width = 189
        '
        'BandedGridColumn5
        '
        Me.BandedGridColumn5.AppearanceCell.Options.UseTextOptions = True
        Me.BandedGridColumn5.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.BandedGridColumn5.AppearanceHeader.Options.UseTextOptions = True
        Me.BandedGridColumn5.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.BandedGridColumn5.Caption = "Year "
        Me.BandedGridColumn5.FieldName = "year_before"
        Me.BandedGridColumn5.Name = "BandedGridColumn5"
        Me.BandedGridColumn5.Visible = True
        Me.BandedGridColumn5.Width = 59
        '
        'BandedGridColumn4
        '
        Me.BandedGridColumn4.AppearanceCell.Options.UseTextOptions = True
        Me.BandedGridColumn4.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.BandedGridColumn4.AppearanceHeader.Options.UseTextOptions = True
        Me.BandedGridColumn4.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.BandedGridColumn4.Caption = "Value Rp "
        Me.BandedGridColumn4.DisplayFormat.FormatString = "N2"
        Me.BandedGridColumn4.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.BandedGridColumn4.FieldName = "value_rp_before"
        Me.BandedGridColumn4.Name = "BandedGridColumn4"
        Me.BandedGridColumn4.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "value_rp_before", "{0:N2}")})
        Me.BandedGridColumn4.Visible = True
        Me.BandedGridColumn4.Width = 82
        '
        'BandedGridColumn3
        '
        Me.BandedGridColumn3.AppearanceCell.Options.UseTextOptions = True
        Me.BandedGridColumn3.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.BandedGridColumn3.AppearanceHeader.Options.UseTextOptions = True
        Me.BandedGridColumn3.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.BandedGridColumn3.Caption = "Value USD "
        Me.BandedGridColumn3.DisplayFormat.FormatString = "N2"
        Me.BandedGridColumn3.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.BandedGridColumn3.FieldName = "value_usd_before"
        Me.BandedGridColumn3.Name = "BandedGridColumn3"
        Me.BandedGridColumn3.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "value_usd_before", "{0:N2}")})
        Me.BandedGridColumn3.Visible = True
        Me.BandedGridColumn3.Width = 82
        '
        'BandedGridColumn7
        '
        Me.BandedGridColumn7.AppearanceCell.Options.UseTextOptions = True
        Me.BandedGridColumn7.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.BandedGridColumn7.AppearanceHeader.Options.UseTextOptions = True
        Me.BandedGridColumn7.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.BandedGridColumn7.Caption = "Kurs "
        Me.BandedGridColumn7.DisplayFormat.FormatString = "N2"
        Me.BandedGridColumn7.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.BandedGridColumn7.FieldName = "kurs_before"
        Me.BandedGridColumn7.Name = "BandedGridColumn7"
        Me.BandedGridColumn7.Width = 82
        '
        'BandedGridColumn8
        '
        Me.BandedGridColumn8.AppearanceCell.Options.UseTextOptions = True
        Me.BandedGridColumn8.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.BandedGridColumn8.AppearanceHeader.Options.UseTextOptions = True
        Me.BandedGridColumn8.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.BandedGridColumn8.Caption = "Total Amount (Rp)"
        Me.BandedGridColumn8.DisplayFormat.FormatString = "N2"
        Me.BandedGridColumn8.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.BandedGridColumn8.FieldName = "tot_amo_before"
        Me.BandedGridColumn8.Name = "BandedGridColumn8"
        Me.BandedGridColumn8.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "tot_amo_before", "{0:N2}")})
        Me.BandedGridColumn8.UnboundExpression = "[value_rp_before] + [value_usd_before] * [kurs_before]"
        Me.BandedGridColumn8.UnboundType = DevExpress.Data.UnboundColumnType.[Decimal]
        Me.BandedGridColumn8.Width = 136
        '
        'GridColumn9
        '
        Me.GridColumn9.Caption = "Id"
        Me.GridColumn9.FieldName = "id_sample_purc_budget"
        Me.GridColumn9.Name = "GridColumn9"
        '
        'GBProposed
        '
        Me.GBProposed.AppearanceHeader.Options.UseTextOptions = True
        Me.GBProposed.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GBProposed.Caption = "Proposed"
        Me.GBProposed.Columns.Add(Me.GridColumn11)
        Me.GBProposed.Columns.Add(Me.GridColumnDescAfter)
        Me.GBProposed.Columns.Add(Me.GridColumnCatAfter)
        Me.GBProposed.Columns.Add(Me.GridColumn15)
        Me.GBProposed.Columns.Add(Me.GridColumn14)
        Me.GBProposed.Columns.Add(Me.GridColumn13)
        Me.GBProposed.Columns.Add(Me.BandedGridColumn6)
        Me.GBProposed.Columns.Add(Me.BandedGridColumn9)
        Me.GBProposed.Name = "GBProposed"
        Me.GBProposed.VisibleIndex = 1
        Me.GBProposed.Width = 603
        '
        'GridColumn11
        '
        Me.GridColumn11.Caption = "ID Division"
        Me.GridColumn11.FieldName = "id_division_after"
        Me.GridColumn11.Name = "GridColumn11"
        '
        'GridColumnDescAfter
        '
        Me.GridColumnDescAfter.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumnDescAfter.AppearanceCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
        Me.GridColumnDescAfter.Caption = "Description"
        Me.GridColumnDescAfter.FieldName = "description_after"
        Me.GridColumnDescAfter.Name = "GridColumnDescAfter"
        Me.GridColumnDescAfter.Visible = True
        Me.GridColumnDescAfter.Width = 172
        '
        'GridColumnCatAfter
        '
        Me.GridColumnCatAfter.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumnCatAfter.AppearanceCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
        Me.GridColumnCatAfter.Caption = "Category"
        Me.GridColumnCatAfter.FieldName = "division_after"
        Me.GridColumnCatAfter.Name = "GridColumnCatAfter"
        Me.GridColumnCatAfter.Visible = True
        Me.GridColumnCatAfter.Width = 180
        '
        'GridColumn15
        '
        Me.GridColumn15.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumn15.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridColumn15.AppearanceHeader.Options.UseTextOptions = True
        Me.GridColumn15.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridColumn15.Caption = "Year"
        Me.GridColumn15.FieldName = "year_after"
        Me.GridColumn15.Name = "GridColumn15"
        Me.GridColumn15.Visible = True
        Me.GridColumn15.Width = 60
        '
        'GridColumn14
        '
        Me.GridColumn14.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumn14.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumn14.AppearanceHeader.Options.UseTextOptions = True
        Me.GridColumn14.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumn14.Caption = "Value Rp"
        Me.GridColumn14.DisplayFormat.FormatString = "N2"
        Me.GridColumn14.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumn14.FieldName = "value_rp_after"
        Me.GridColumn14.Name = "GridColumn14"
        Me.GridColumn14.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "value_rp_after", "{0:N2}")})
        Me.GridColumn14.Visible = True
        Me.GridColumn14.Width = 99
        '
        'GridColumn13
        '
        Me.GridColumn13.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumn13.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumn13.AppearanceHeader.Options.UseTextOptions = True
        Me.GridColumn13.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumn13.Caption = "Value USD"
        Me.GridColumn13.DisplayFormat.FormatString = "N2"
        Me.GridColumn13.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumn13.FieldName = "value_usd_after"
        Me.GridColumn13.Name = "GridColumn13"
        Me.GridColumn13.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "value_usd_after", "{0:N2}")})
        Me.GridColumn13.Visible = True
        Me.GridColumn13.Width = 92
        '
        'BandedGridColumn6
        '
        Me.BandedGridColumn6.AppearanceCell.Options.UseTextOptions = True
        Me.BandedGridColumn6.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.BandedGridColumn6.AppearanceHeader.Options.UseTextOptions = True
        Me.BandedGridColumn6.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.BandedGridColumn6.Caption = "Kurs"
        Me.BandedGridColumn6.DisplayFormat.FormatString = "N2"
        Me.BandedGridColumn6.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.BandedGridColumn6.FieldName = "kurs_after"
        Me.BandedGridColumn6.Name = "BandedGridColumn6"
        Me.BandedGridColumn6.Width = 76
        '
        'BandedGridColumn9
        '
        Me.BandedGridColumn9.AppearanceCell.Options.UseTextOptions = True
        Me.BandedGridColumn9.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.BandedGridColumn9.AppearanceHeader.Options.UseTextOptions = True
        Me.BandedGridColumn9.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.BandedGridColumn9.Caption = "Total Amount (Rp)"
        Me.BandedGridColumn9.DisplayFormat.FormatString = "N2"
        Me.BandedGridColumn9.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.BandedGridColumn9.FieldName = "tot_amo_before"
        Me.BandedGridColumn9.Name = "BandedGridColumn9"
        Me.BandedGridColumn9.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "tot_amo_before", "{0:N2}")})
        Me.BandedGridColumn9.UnboundExpression = "[value_rp_after] + [value_usd_after] * [kurs_after]"
        Me.BandedGridColumn9.UnboundType = DevExpress.Data.UnboundColumnType.[Decimal]
        Me.BandedGridColumn9.Width = 128
        '
        'RepositoryItemCheckEdit2
        '
        Me.RepositoryItemCheckEdit2.AutoHeight = False
        Me.RepositoryItemCheckEdit2.Name = "RepositoryItemCheckEdit2"
        Me.RepositoryItemCheckEdit2.ValueChecked = "yes"
        Me.RepositoryItemCheckEdit2.ValueUnchecked = "no"
        '
        'RepositoryItemDateEdit2
        '
        Me.RepositoryItemDateEdit2.AutoHeight = False
        Me.RepositoryItemDateEdit2.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.RepositoryItemDateEdit2.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.RepositoryItemDateEdit2.CalendarView = DevExpress.XtraEditors.Repository.CalendarView.Vista
        Me.RepositoryItemDateEdit2.DisplayFormat.FormatString = "yyyy"
        Me.RepositoryItemDateEdit2.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.RepositoryItemDateEdit2.EditFormat.FormatString = "yyyy"
        Me.RepositoryItemDateEdit2.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.RepositoryItemDateEdit2.Mask.EditMask = "yyyy"
        Me.RepositoryItemDateEdit2.Mask.UseMaskAsDisplayFormat = True
        Me.RepositoryItemDateEdit2.Name = "RepositoryItemDateEdit2"
        Me.RepositoryItemDateEdit2.VistaCalendarInitialViewStyle = DevExpress.XtraEditors.VistaCalendarInitialViewStyle.YearsGroupView
        Me.RepositoryItemDateEdit2.VistaCalendarViewStyle = DevExpress.XtraEditors.VistaCalendarViewStyle.YearsGroupView
        Me.RepositoryItemDateEdit2.VistaDisplayMode = DevExpress.Utils.DefaultBoolean.[True]
        '
        'TopMargin
        '
        Me.TopMargin.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.XrPictureBox1, Me.LTitle, Me.XrLine1, Me.LPoNumber})
        Me.TopMargin.HeightF = 74.72919!
        Me.TopMargin.Name = "TopMargin"
        Me.TopMargin.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
        Me.TopMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
        '
        'XrPictureBox1
        '
        Me.XrPictureBox1.Image = CType(resources.GetObject("XrPictureBox1.Image"), System.Drawing.Image)
        Me.XrPictureBox1.LocationFloat = New DevExpress.Utils.PointFloat(0!, 25.68752!)
        Me.XrPictureBox1.Name = "XrPictureBox1"
        Me.XrPictureBox1.SizeF = New System.Drawing.SizeF(210.4167!, 39.58334!)
        Me.XrPictureBox1.Sizing = DevExpress.XtraPrinting.ImageSizeMode.StretchImage
        '
        'LTitle
        '
        Me.LTitle.Font = New System.Drawing.Font("Franklin Gothic Demi", 14.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LTitle.LocationFloat = New DevExpress.Utils.PointFloat(602.4166!, 25.27081!)
        Me.LTitle.Name = "LTitle"
        Me.LTitle.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.LTitle.SizeF = New System.Drawing.SizeF(366.5834!, 26.4167!)
        Me.LTitle.StylePriority.UseFont = False
        Me.LTitle.StylePriority.UseTextAlignment = False
        Me.LTitle.Text = "Pengajuan Budget Pembelian Sample"
        Me.LTitle.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
        '
        'XrLine1
        '
        Me.XrLine1.LocationFloat = New DevExpress.Utils.PointFloat(0.00009791054!, 65.27086!)
        Me.XrLine1.Name = "XrLine1"
        Me.XrLine1.SizeF = New System.Drawing.SizeF(968.9998!, 9.458332!)
        '
        'LPoNumber
        '
        Me.LPoNumber.Borders = DevExpress.XtraPrinting.BorderSide.Top
        Me.LPoNumber.Font = New System.Drawing.Font("Segoe UI", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LPoNumber.LocationFloat = New DevExpress.Utils.PointFloat(531.4998!, 51.68753!)
        Me.LPoNumber.Name = "LPoNumber"
        Me.LPoNumber.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.LPoNumber.SizeF = New System.Drawing.SizeF(437.5001!, 13.58335!)
        Me.LPoNumber.StylePriority.UseBorders = False
        Me.LPoNumber.StylePriority.UseFont = False
        '
        'BottomMargin
        '
        Me.BottomMargin.HeightF = 22.91667!
        Me.BottomMargin.Name = "BottomMargin"
        Me.BottomMargin.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
        Me.BottomMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
        '
        'PageHeader
        '
        Me.PageHeader.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.XrLabel8, Me.XrLabel9, Me.LTypePropose, Me.LCreatedDate, Me.XrLabel6, Me.XrLabel7, Me.XrLabel1, Me.XrLabel2, Me.XrLabel3, Me.XrLabel4, Me.LNumber, Me.LPrroposedBy})
        Me.PageHeader.HeightF = 100.7084!
        Me.PageHeader.Name = "PageHeader"
        '
        'XrLabel8
        '
        Me.XrLabel8.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.XrLabel8.LocationFloat = New DevExpress.Utils.PointFloat(0.00009536743!, 62.24998!)
        Me.XrLabel8.Name = "XrLabel8"
        Me.XrLabel8.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel8.SizeF = New System.Drawing.SizeF(82.12502!, 20.75!)
        Me.XrLabel8.StylePriority.UseFont = False
        Me.XrLabel8.StylePriority.UseTextAlignment = False
        Me.XrLabel8.Text = "Type"
        Me.XrLabel8.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
        '
        'XrLabel9
        '
        Me.XrLabel9.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.XrLabel9.LocationFloat = New DevExpress.Utils.PointFloat(82.12512!, 62.25001!)
        Me.XrLabel9.Name = "XrLabel9"
        Me.XrLabel9.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel9.SizeF = New System.Drawing.SizeF(10.33336!, 20.75!)
        Me.XrLabel9.StylePriority.UseFont = False
        Me.XrLabel9.StylePriority.UseTextAlignment = False
        Me.XrLabel9.Text = ":"
        Me.XrLabel9.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
        '
        'LTypePropose
        '
        Me.LTypePropose.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.LTypePropose.LocationFloat = New DevExpress.Utils.PointFloat(92.45847!, 62.25001!)
        Me.LTypePropose.Name = "LTypePropose"
        Me.LTypePropose.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.LTypePropose.SizeF = New System.Drawing.SizeF(876.5414!, 20.75!)
        Me.LTypePropose.StylePriority.UseFont = False
        Me.LTypePropose.StylePriority.UseTextAlignment = False
        Me.LTypePropose.Text = "Created Date"
        Me.LTypePropose.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
        '
        'LCreatedDate
        '
        Me.LCreatedDate.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.LCreatedDate.LocationFloat = New DevExpress.Utils.PointFloat(92.45872!, 41.50003!)
        Me.LCreatedDate.Name = "LCreatedDate"
        Me.LCreatedDate.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.LCreatedDate.SizeF = New System.Drawing.SizeF(876.5414!, 20.75!)
        Me.LCreatedDate.StylePriority.UseFont = False
        Me.LCreatedDate.StylePriority.UseTextAlignment = False
        Me.LCreatedDate.Text = "Created Date"
        Me.LCreatedDate.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
        '
        'XrLabel6
        '
        Me.XrLabel6.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.XrLabel6.LocationFloat = New DevExpress.Utils.PointFloat(82.12538!, 41.50003!)
        Me.XrLabel6.Name = "XrLabel6"
        Me.XrLabel6.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel6.SizeF = New System.Drawing.SizeF(10.33336!, 20.75!)
        Me.XrLabel6.StylePriority.UseFont = False
        Me.XrLabel6.StylePriority.UseTextAlignment = False
        Me.XrLabel6.Text = ":"
        Me.XrLabel6.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
        '
        'XrLabel7
        '
        Me.XrLabel7.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.XrLabel7.LocationFloat = New DevExpress.Utils.PointFloat(0.0003496806!, 41.5!)
        Me.XrLabel7.Name = "XrLabel7"
        Me.XrLabel7.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel7.SizeF = New System.Drawing.SizeF(82.12502!, 20.75!)
        Me.XrLabel7.StylePriority.UseFont = False
        Me.XrLabel7.StylePriority.UseTextAlignment = False
        Me.XrLabel7.Text = "Created Date"
        Me.XrLabel7.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
        '
        'XrLabel1
        '
        Me.XrLabel1.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.XrLabel1.LocationFloat = New DevExpress.Utils.PointFloat(0.00009536743!, 0!)
        Me.XrLabel1.Name = "XrLabel1"
        Me.XrLabel1.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel1.SizeF = New System.Drawing.SizeF(82.125!, 20.75!)
        Me.XrLabel1.StylePriority.UseFont = False
        Me.XrLabel1.StylePriority.UseTextAlignment = False
        Me.XrLabel1.Text = "Number"
        Me.XrLabel1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
        '
        'XrLabel2
        '
        Me.XrLabel2.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.XrLabel2.LocationFloat = New DevExpress.Utils.PointFloat(0.00009536743!, 20.74998!)
        Me.XrLabel2.Name = "XrLabel2"
        Me.XrLabel2.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel2.SizeF = New System.Drawing.SizeF(82.12502!, 20.75!)
        Me.XrLabel2.StylePriority.UseFont = False
        Me.XrLabel2.StylePriority.UseTextAlignment = False
        Me.XrLabel2.Text = "Proposed By"
        Me.XrLabel2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
        '
        'XrLabel3
        '
        Me.XrLabel3.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.XrLabel3.LocationFloat = New DevExpress.Utils.PointFloat(82.12512!, 0!)
        Me.XrLabel3.Name = "XrLabel3"
        Me.XrLabel3.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel3.SizeF = New System.Drawing.SizeF(10.33334!, 20.75!)
        Me.XrLabel3.StylePriority.UseFont = False
        Me.XrLabel3.StylePriority.UseTextAlignment = False
        Me.XrLabel3.Text = ":"
        Me.XrLabel3.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
        '
        'XrLabel4
        '
        Me.XrLabel4.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.XrLabel4.LocationFloat = New DevExpress.Utils.PointFloat(82.12512!, 20.75001!)
        Me.XrLabel4.Name = "XrLabel4"
        Me.XrLabel4.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel4.SizeF = New System.Drawing.SizeF(10.33336!, 20.75!)
        Me.XrLabel4.StylePriority.UseFont = False
        Me.XrLabel4.StylePriority.UseTextAlignment = False
        Me.XrLabel4.Text = ":"
        Me.XrLabel4.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
        '
        'LNumber
        '
        Me.LNumber.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.LNumber.LocationFloat = New DevExpress.Utils.PointFloat(92.45847!, 0!)
        Me.LNumber.Name = "LNumber"
        Me.LNumber.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.LNumber.SizeF = New System.Drawing.SizeF(876.5415!, 20.75!)
        Me.LNumber.StylePriority.UseFont = False
        Me.LNumber.StylePriority.UseTextAlignment = False
        Me.LNumber.Text = "Number"
        Me.LNumber.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
        '
        'LPrroposedBy
        '
        Me.LPrroposedBy.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.LPrroposedBy.LocationFloat = New DevExpress.Utils.PointFloat(92.45847!, 20.75001!)
        Me.LPrroposedBy.Name = "LPrroposedBy"
        Me.LPrroposedBy.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.LPrroposedBy.SizeF = New System.Drawing.SizeF(876.5414!, 20.75!)
        Me.LPrroposedBy.StylePriority.UseFont = False
        Me.LPrroposedBy.StylePriority.UseTextAlignment = False
        Me.LPrroposedBy.Text = "Proposed By"
        Me.LPrroposedBy.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
        '
        'ReportFooter
        '
        Me.ReportFooter.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.LNote, Me.XrLabel10, Me.XrLabel11, Me.XrTable1})
        Me.ReportFooter.HeightF = 106.25!
        Me.ReportFooter.Name = "ReportFooter"
        '
        'LNote
        '
        Me.LNote.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.LNote.LocationFloat = New DevExpress.Utils.PointFloat(92.45908!, 6.999969!)
        Me.LNote.Name = "LNote"
        Me.LNote.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.LNote.SizeF = New System.Drawing.SizeF(876.5414!, 74.24997!)
        Me.LNote.StylePriority.UseFont = False
        Me.LNote.StylePriority.UseTextAlignment = False
        Me.LNote.Text = "Created Date"
        Me.LNote.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
        '
        'XrLabel10
        '
        Me.XrLabel10.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.XrLabel10.LocationFloat = New DevExpress.Utils.PointFloat(82.12509!, 7.0!)
        Me.XrLabel10.Name = "XrLabel10"
        Me.XrLabel10.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel10.SizeF = New System.Drawing.SizeF(10.33336!, 20.75!)
        Me.XrLabel10.StylePriority.UseFont = False
        Me.XrLabel10.StylePriority.UseTextAlignment = False
        Me.XrLabel10.Text = ":"
        Me.XrLabel10.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
        '
        'XrLabel11
        '
        Me.XrLabel11.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.XrLabel11.LocationFloat = New DevExpress.Utils.PointFloat(0.0003496806!, 7.0!)
        Me.XrLabel11.Name = "XrLabel11"
        Me.XrLabel11.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel11.SizeF = New System.Drawing.SizeF(82.12502!, 20.75!)
        Me.XrLabel11.StylePriority.UseFont = False
        Me.XrLabel11.StylePriority.UseTextAlignment = False
        Me.XrLabel11.Text = "Note"
        Me.XrLabel11.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
        '
        'XrTable1
        '
        Me.XrTable1.Font = New System.Drawing.Font("Lucida Sans", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.XrTable1.LocationFloat = New DevExpress.Utils.PointFloat(0.0003496806!, 81.25!)
        Me.XrTable1.Name = "XrTable1"
        Me.XrTable1.Rows.AddRange(New DevExpress.XtraReports.UI.XRTableRow() {Me.XrTableRow1})
        Me.XrTable1.SizeF = New System.Drawing.SizeF(969.0001!, 25.0!)
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
        'ReportSampleBudget
        '
        Me.Bands.AddRange(New DevExpress.XtraReports.UI.Band() {Me.Detail, Me.TopMargin, Me.BottomMargin, Me.PageHeader, Me.ReportFooter})
        Me.Landscape = True
        Me.Margins = New System.Drawing.Printing.Margins(100, 100, 75, 23)
        Me.PageHeight = 827
        Me.PageWidth = 1169
        Me.PaperKind = System.Drawing.Printing.PaperKind.A4
        Me.ScriptLanguage = DevExpress.XtraReports.ScriptLanguage.VisualBasic
        Me.Version = "15.1"
        CType(Me.GCReportBudgetSample, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVReportBudgetSample, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemCheckEdit2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemDateEdit2.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemDateEdit2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.XrTable1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me, System.ComponentModel.ISupportInitialize).EndInit()

    End Sub
    Friend WithEvents Detail As DevExpress.XtraReports.UI.DetailBand
    Friend WithEvents TopMargin As DevExpress.XtraReports.UI.TopMarginBand
    Friend WithEvents BottomMargin As DevExpress.XtraReports.UI.BottomMarginBand
    Friend WithEvents XrPictureBox1 As DevExpress.XtraReports.UI.XRPictureBox
    Friend WithEvents LTitle As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLine1 As DevExpress.XtraReports.UI.XRLine
    Friend WithEvents LPoNumber As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents PageHeader As DevExpress.XtraReports.UI.PageHeaderBand
    Friend WithEvents ReportFooter As DevExpress.XtraReports.UI.ReportFooterBand
    Friend WithEvents XrTable1 As DevExpress.XtraReports.UI.XRTable
    Friend WithEvents XrTableRow1 As DevExpress.XtraReports.UI.XRTableRow
    Friend WithEvents XrTableCell1 As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents XrLabel8 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel9 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents LTypePropose As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents LCreatedDate As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel6 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel7 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel1 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel2 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel3 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel4 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents LNumber As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents LPrroposedBy As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents WinControlContainer1 As DevExpress.XtraReports.UI.WinControlContainer
    Friend WithEvents GCReportBudgetSample As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVReportBudgetSample As DevExpress.XtraGrid.Views.BandedGrid.BandedGridView
    Friend WithEvents BandedGridColumnDescBefore As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumnCatBefore As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumn5 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumn4 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumn3 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents GridColumn9 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents GridColumn11 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents GridColumnDescAfter As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents GridColumnCatAfter As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents GridColumn15 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents GridColumn14 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents GridColumn13 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents RepositoryItemCheckEdit2 As DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit
    Friend WithEvents RepositoryItemDateEdit2 As DevExpress.XtraEditors.Repository.RepositoryItemDateEdit
    Friend WithEvents LNote As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel10 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel11 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents BandedGridColumn7 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumn8 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumn6 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumn9 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents GBBefore As DevExpress.XtraGrid.Views.BandedGrid.GridBand
    Friend WithEvents GBProposed As DevExpress.XtraGrid.Views.BandedGrid.GridBand
End Class
