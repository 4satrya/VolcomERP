<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Public Class ReportPayrollAll
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ReportPayrollAll))
        Me.Detail = New DevExpress.XtraReports.UI.DetailBand()
        Me.WinControlContainer1 = New DevExpress.XtraReports.UI.WinControlContainer()
        Me.GCPayroll = New DevExpress.XtraGrid.GridControl()
        Me.GVPayroll = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridView()
        Me.GBEmployee = New DevExpress.XtraGrid.Views.BandedGrid.GridBand()
        Me.GCNIP = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.GCName = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.GCDepartement = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.GCPosition = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.GCStatus = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.GBWorkingDays = New DevExpress.XtraGrid.Views.BandedGrid.GridBand()
        Me.GCWorkingDays = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.GCActualWorkingDays = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.GCOvertimeHours = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.GBSalary = New DevExpress.XtraGrid.Views.BandedGrid.GridBand()
        Me.GCTotalTHP = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.GCTotalAdjustment = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.GCTotalPaymentOvertime = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.GCTotalDeduction = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.GBDW = New DevExpress.XtraGrid.Views.BandedGrid.GridBand()
        Me.GCActualWorkingDaysDW = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.GCBasicSalaryDW = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.GBGrandTotal = New DevExpress.XtraGrid.Views.BandedGrid.GridBand()
        Me.GCGrandTotal = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.GCSubDepartement = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.RICEPending = New DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit()
        Me.RICESelect = New DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit()
        Me.XrLabel1 = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLabel2 = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLabel3 = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLabel4 = New DevExpress.XtraReports.UI.XRLabel()
        Me.XLType = New DevExpress.XtraReports.UI.XRLabel()
        Me.XLLocation = New DevExpress.XtraReports.UI.XRLabel()
        Me.TopMargin = New DevExpress.XtraReports.UI.TopMarginBand()
        Me.XLTitle = New DevExpress.XtraReports.UI.XRLabel()
        Me.XLPeriod = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLine1 = New DevExpress.XtraReports.UI.XRLine()
        Me.XrPictureBox1 = New DevExpress.XtraReports.UI.XRPictureBox()
        Me.BottomMargin = New DevExpress.XtraReports.UI.BottomMarginBand()
        Me.XrPageInfo1 = New DevExpress.XtraReports.UI.XRPageInfo()
        Me.SqlDataSource1 = New DevExpress.DataAccess.Sql.SqlDataSource(Me.components)
        Me.ReportHeader = New DevExpress.XtraReports.UI.ReportHeaderBand()
        Me.ReportFooter = New DevExpress.XtraReports.UI.ReportFooterBand()
        Me.XrPanel1 = New DevExpress.XtraReports.UI.XRPanel()
        Me.XrTable1 = New DevExpress.XtraReports.UI.XRTable()
        Me.XrTableRow1 = New DevExpress.XtraReports.UI.XRTableRow()
        Me.XrTableCell13 = New DevExpress.XtraReports.UI.XRTableCell()
        CType(Me.GCPayroll, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVPayroll, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RICEPending, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RICESelect, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.WinControlContainer1.LocationFloat = New DevExpress.Utils.PointFloat(0.0004132589!, 0!)
        Me.WinControlContainer1.Name = "WinControlContainer1"
        Me.WinControlContainer1.SizeF = New System.Drawing.SizeF(1075.0!, 260.0!)
        Me.WinControlContainer1.WinControl = Me.GCPayroll
        '
        'GCPayroll
        '
        Me.GCPayroll.Location = New System.Drawing.Point(0, 39)
        Me.GCPayroll.MainView = Me.GVPayroll
        Me.GCPayroll.Name = "GCPayroll"
        Me.GCPayroll.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.RICEPending, Me.RICESelect})
        Me.GCPayroll.Size = New System.Drawing.Size(1032, 250)
        Me.GCPayroll.TabIndex = 1
        Me.GCPayroll.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVPayroll})
        '
        'GVPayroll
        '
        Me.GVPayroll.AppearancePrint.BandPanel.BackColor = System.Drawing.Color.White
        Me.GVPayroll.AppearancePrint.BandPanel.BorderColor = System.Drawing.Color.Black
        Me.GVPayroll.AppearancePrint.BandPanel.Font = New System.Drawing.Font("Tahoma", 7.25!, System.Drawing.FontStyle.Bold)
        Me.GVPayroll.AppearancePrint.BandPanel.Options.UseBackColor = True
        Me.GVPayroll.AppearancePrint.BandPanel.Options.UseBorderColor = True
        Me.GVPayroll.AppearancePrint.BandPanel.Options.UseFont = True
        Me.GVPayroll.AppearancePrint.FooterPanel.BackColor = System.Drawing.Color.White
        Me.GVPayroll.AppearancePrint.FooterPanel.BorderColor = System.Drawing.Color.Black
        Me.GVPayroll.AppearancePrint.FooterPanel.Font = New System.Drawing.Font("Tahoma", 7.25!)
        Me.GVPayroll.AppearancePrint.FooterPanel.Options.UseBackColor = True
        Me.GVPayroll.AppearancePrint.FooterPanel.Options.UseBorderColor = True
        Me.GVPayroll.AppearancePrint.FooterPanel.Options.UseFont = True
        Me.GVPayroll.AppearancePrint.GroupFooter.BackColor = System.Drawing.Color.White
        Me.GVPayroll.AppearancePrint.GroupFooter.BorderColor = System.Drawing.Color.Black
        Me.GVPayroll.AppearancePrint.GroupFooter.Font = New System.Drawing.Font("Tahoma", 7.25!)
        Me.GVPayroll.AppearancePrint.GroupFooter.Options.UseBackColor = True
        Me.GVPayroll.AppearancePrint.GroupFooter.Options.UseBorderColor = True
        Me.GVPayroll.AppearancePrint.GroupFooter.Options.UseFont = True
        Me.GVPayroll.AppearancePrint.GroupRow.BackColor = System.Drawing.Color.White
        Me.GVPayroll.AppearancePrint.GroupRow.BorderColor = System.Drawing.Color.Black
        Me.GVPayroll.AppearancePrint.GroupRow.Font = New System.Drawing.Font("Tahoma", 7.25!, System.Drawing.FontStyle.Bold)
        Me.GVPayroll.AppearancePrint.GroupRow.Options.UseBackColor = True
        Me.GVPayroll.AppearancePrint.GroupRow.Options.UseBorderColor = True
        Me.GVPayroll.AppearancePrint.GroupRow.Options.UseFont = True
        Me.GVPayroll.AppearancePrint.HeaderPanel.BackColor = System.Drawing.Color.White
        Me.GVPayroll.AppearancePrint.HeaderPanel.BorderColor = System.Drawing.Color.Black
        Me.GVPayroll.AppearancePrint.HeaderPanel.Font = New System.Drawing.Font("Tahoma", 7.25!, System.Drawing.FontStyle.Bold)
        Me.GVPayroll.AppearancePrint.HeaderPanel.Options.UseBackColor = True
        Me.GVPayroll.AppearancePrint.HeaderPanel.Options.UseBorderColor = True
        Me.GVPayroll.AppearancePrint.HeaderPanel.Options.UseFont = True
        Me.GVPayroll.AppearancePrint.Lines.BackColor = System.Drawing.Color.Black
        Me.GVPayroll.AppearancePrint.Lines.Options.UseBackColor = True
        Me.GVPayroll.AppearancePrint.Row.BackColor = System.Drawing.Color.White
        Me.GVPayroll.AppearancePrint.Row.BorderColor = System.Drawing.Color.Black
        Me.GVPayroll.AppearancePrint.Row.Font = New System.Drawing.Font("Tahoma", 7.25!)
        Me.GVPayroll.AppearancePrint.Row.Options.UseBackColor = True
        Me.GVPayroll.AppearancePrint.Row.Options.UseBorderColor = True
        Me.GVPayroll.AppearancePrint.Row.Options.UseFont = True
        Me.GVPayroll.BandPanelRowHeight = 16
        Me.GVPayroll.Bands.AddRange(New DevExpress.XtraGrid.Views.BandedGrid.GridBand() {Me.GBEmployee, Me.GBWorkingDays, Me.GBSalary, Me.GBDW, Me.GBGrandTotal})
        Me.GVPayroll.ColumnPanelRowHeight = 32
        Me.GVPayroll.Columns.AddRange(New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn() {Me.GCDepartement, Me.GCSubDepartement, Me.GCNIP, Me.GCName, Me.GCPosition, Me.GCStatus, Me.GCWorkingDays, Me.GCActualWorkingDays, Me.GCOvertimeHours, Me.GCTotalTHP, Me.GCTotalAdjustment, Me.GCTotalPaymentOvertime, Me.GCTotalDeduction, Me.GCActualWorkingDaysDW, Me.GCBasicSalaryDW, Me.GCGrandTotal})
        Me.GVPayroll.GridControl = Me.GCPayroll
        Me.GVPayroll.GroupCount = 2
        Me.GVPayroll.GroupFormat = "{1} {2}"
        Me.GVPayroll.GroupSummary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Custom, "tot_thp", Me.GCTotalTHP, "{0:N0}"), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Custom, "total_adjustment", Me.GCTotalAdjustment, "{0:N0}"), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Custom, "total_deduction", Me.GCTotalDeduction, "{0:N0}"), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Custom, "total_ot_wages", Me.GCTotalPaymentOvertime, "{0:N0}"), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Custom, "grand_total", Me.GCGrandTotal, "{0:N0}")})
        Me.GVPayroll.LevelIndent = 0
        Me.GVPayroll.Name = "GVPayroll"
        Me.GVPayroll.OptionsBehavior.AutoExpandAllGroups = True
        Me.GVPayroll.OptionsMenu.ShowConditionalFormattingItem = True
        Me.GVPayroll.OptionsPrint.AllowMultilineHeaders = True
        Me.GVPayroll.OptionsView.GroupFooterShowMode = DevExpress.XtraGrid.Views.Grid.GroupFooterShowMode.VisibleAlways
        Me.GVPayroll.OptionsView.ShowFooter = True
        Me.GVPayroll.OptionsView.ShowGroupPanel = False
        Me.GVPayroll.SortInfo.AddRange(New DevExpress.XtraGrid.Columns.GridColumnSortInfo() {New DevExpress.XtraGrid.Columns.GridColumnSortInfo(Me.GCDepartement, DevExpress.Data.ColumnSortOrder.Ascending), New DevExpress.XtraGrid.Columns.GridColumnSortInfo(Me.GCSubDepartement, DevExpress.Data.ColumnSortOrder.Ascending)})
        '
        'GBEmployee
        '
        Me.GBEmployee.Caption = "Employee"
        Me.GBEmployee.Columns.Add(Me.GCNIP)
        Me.GBEmployee.Columns.Add(Me.GCName)
        Me.GBEmployee.Columns.Add(Me.GCDepartement)
        Me.GBEmployee.Columns.Add(Me.GCPosition)
        Me.GBEmployee.Columns.Add(Me.GCStatus)
        Me.GBEmployee.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left
        Me.GBEmployee.Name = "GBEmployee"
        Me.GBEmployee.VisibleIndex = 0
        Me.GBEmployee.Width = 512
        '
        'GCNIP
        '
        Me.GCNIP.Caption = "NIP"
        Me.GCNIP.FieldName = "employee_code"
        Me.GCNIP.MinWidth = 65
        Me.GCNIP.Name = "GCNIP"
        Me.GCNIP.OptionsColumn.AllowEdit = False
        Me.GCNIP.Visible = True
        Me.GCNIP.Width = 107
        '
        'GCName
        '
        Me.GCName.AppearanceCell.Options.UseTextOptions = True
        Me.GCName.AppearanceCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
        Me.GCName.Caption = "Employee"
        Me.GCName.FieldName = "employee_name"
        Me.GCName.MinWidth = 195
        Me.GCName.Name = "GCName"
        Me.GCName.OptionsColumn.AllowEdit = False
        Me.GCName.Visible = True
        Me.GCName.Width = 195
        '
        'GCDepartement
        '
        Me.GCDepartement.Caption = "Departement"
        Me.GCDepartement.FieldName = "departement"
        Me.GCDepartement.Name = "GCDepartement"
        Me.GCDepartement.OptionsColumn.AllowEdit = False
        '
        'GCPosition
        '
        Me.GCPosition.AppearanceCell.Options.UseTextOptions = True
        Me.GCPosition.AppearanceCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
        Me.GCPosition.Caption = "Employee Position"
        Me.GCPosition.FieldName = "employee_position"
        Me.GCPosition.MinWidth = 150
        Me.GCPosition.Name = "GCPosition"
        Me.GCPosition.OptionsColumn.AllowEdit = False
        Me.GCPosition.Visible = True
        Me.GCPosition.Width = 150
        '
        'GCStatus
        '
        Me.GCStatus.Caption = "Employee Status"
        Me.GCStatus.FieldName = "employee_status"
        Me.GCStatus.MinWidth = 60
        Me.GCStatus.Name = "GCStatus"
        Me.GCStatus.OptionsColumn.AllowEdit = False
        Me.GCStatus.Visible = True
        Me.GCStatus.Width = 60
        '
        'GBWorkingDays
        '
        Me.GBWorkingDays.AppearanceHeader.Options.UseTextOptions = True
        Me.GBWorkingDays.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GBWorkingDays.Caption = "Working Days (WD)"
        Me.GBWorkingDays.Columns.Add(Me.GCWorkingDays)
        Me.GBWorkingDays.Columns.Add(Me.GCActualWorkingDays)
        Me.GBWorkingDays.Columns.Add(Me.GCOvertimeHours)
        Me.GBWorkingDays.Name = "GBWorkingDays"
        Me.GBWorkingDays.VisibleIndex = 1
        Me.GBWorkingDays.Width = 81
        '
        'GCWorkingDays
        '
        Me.GCWorkingDays.AppearanceCell.Options.UseTextOptions = True
        Me.GCWorkingDays.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GCWorkingDays.Caption = "WD"
        Me.GCWorkingDays.DisplayFormat.FormatString = "N1"
        Me.GCWorkingDays.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GCWorkingDays.FieldName = "workdays"
        Me.GCWorkingDays.Name = "GCWorkingDays"
        Me.GCWorkingDays.OptionsColumn.AllowEdit = False
        Me.GCWorkingDays.Width = 35
        '
        'GCActualWorkingDays
        '
        Me.GCActualWorkingDays.AppearanceCell.Options.UseTextOptions = True
        Me.GCActualWorkingDays.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GCActualWorkingDays.Caption = "Actual WD"
        Me.GCActualWorkingDays.DisplayFormat.FormatString = "N1"
        Me.GCActualWorkingDays.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GCActualWorkingDays.FieldName = "actual_workdays"
        Me.GCActualWorkingDays.Name = "GCActualWorkingDays"
        Me.GCActualWorkingDays.OptionsColumn.AllowEdit = False
        Me.GCActualWorkingDays.Visible = True
        Me.GCActualWorkingDays.Width = 35
        '
        'GCOvertimeHours
        '
        Me.GCOvertimeHours.AppearanceCell.Options.UseTextOptions = True
        Me.GCOvertimeHours.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GCOvertimeHours.Caption = "Overtime (Hours)"
        Me.GCOvertimeHours.DisplayFormat.FormatString = "N1"
        Me.GCOvertimeHours.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GCOvertimeHours.FieldName = "total_ot_hour"
        Me.GCOvertimeHours.Name = "GCOvertimeHours"
        Me.GCOvertimeHours.OptionsColumn.AllowEdit = False
        Me.GCOvertimeHours.Visible = True
        Me.GCOvertimeHours.Width = 46
        '
        'GBSalary
        '
        Me.GBSalary.AppearanceHeader.Options.UseTextOptions = True
        Me.GBSalary.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GBSalary.Columns.Add(Me.GCTotalTHP)
        Me.GBSalary.Columns.Add(Me.GCTotalAdjustment)
        Me.GBSalary.Columns.Add(Me.GCTotalPaymentOvertime)
        Me.GBSalary.Columns.Add(Me.GCTotalDeduction)
        Me.GBSalary.Name = "GBSalary"
        Me.GBSalary.VisibleIndex = 2
        Me.GBSalary.Width = 232
        '
        'GCTotalTHP
        '
        Me.GCTotalTHP.AppearanceCell.Options.UseTextOptions = True
        Me.GCTotalTHP.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GCTotalTHP.Caption = "Total THP"
        Me.GCTotalTHP.DisplayFormat.FormatString = "N0"
        Me.GCTotalTHP.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GCTotalTHP.FieldName = "tot_thp"
        Me.GCTotalTHP.Name = "GCTotalTHP"
        Me.GCTotalTHP.OptionsColumn.AllowEdit = False
        Me.GCTotalTHP.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "tot_thp", "{0:N0}")})
        Me.GCTotalTHP.Visible = True
        Me.GCTotalTHP.Width = 57
        '
        'GCTotalAdjustment
        '
        Me.GCTotalAdjustment.AppearanceCell.Options.UseTextOptions = True
        Me.GCTotalAdjustment.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GCTotalAdjustment.Caption = "Total Bonus / Adj"
        Me.GCTotalAdjustment.DisplayFormat.FormatString = "N0"
        Me.GCTotalAdjustment.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GCTotalAdjustment.FieldName = "total_adjustment"
        Me.GCTotalAdjustment.Name = "GCTotalAdjustment"
        Me.GCTotalAdjustment.OptionsColumn.AllowEdit = False
        Me.GCTotalAdjustment.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "total_adjustment", "{0:N0}")})
        Me.GCTotalAdjustment.Visible = True
        Me.GCTotalAdjustment.Width = 57
        '
        'GCTotalPaymentOvertime
        '
        Me.GCTotalPaymentOvertime.AppearanceCell.Options.UseTextOptions = True
        Me.GCTotalPaymentOvertime.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GCTotalPaymentOvertime.Caption = "Total Overtime"
        Me.GCTotalPaymentOvertime.DisplayFormat.FormatString = "N0"
        Me.GCTotalPaymentOvertime.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GCTotalPaymentOvertime.FieldName = "total_ot_wages"
        Me.GCTotalPaymentOvertime.Name = "GCTotalPaymentOvertime"
        Me.GCTotalPaymentOvertime.OptionsColumn.AllowEdit = False
        Me.GCTotalPaymentOvertime.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "total_ot_wages", "{0:N0}")})
        Me.GCTotalPaymentOvertime.Visible = True
        Me.GCTotalPaymentOvertime.Width = 57
        '
        'GCTotalDeduction
        '
        Me.GCTotalDeduction.AppearanceCell.Options.UseTextOptions = True
        Me.GCTotalDeduction.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GCTotalDeduction.Caption = "Total Deduction"
        Me.GCTotalDeduction.DisplayFormat.FormatString = "N0"
        Me.GCTotalDeduction.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GCTotalDeduction.FieldName = "total_deduction"
        Me.GCTotalDeduction.Name = "GCTotalDeduction"
        Me.GCTotalDeduction.OptionsColumn.AllowEdit = False
        Me.GCTotalDeduction.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "total_deduction", "{0:N0}")})
        Me.GCTotalDeduction.Visible = True
        Me.GCTotalDeduction.Width = 61
        '
        'GBDW
        '
        Me.GBDW.Columns.Add(Me.GCActualWorkingDaysDW)
        Me.GBDW.Columns.Add(Me.GCBasicSalaryDW)
        Me.GBDW.Name = "GBDW"
        Me.GBDW.VisibleIndex = 3
        Me.GBDW.Width = 134
        '
        'GCActualWorkingDaysDW
        '
        Me.GCActualWorkingDaysDW.AppearanceCell.Options.UseTextOptions = True
        Me.GCActualWorkingDaysDW.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GCActualWorkingDaysDW.AppearanceCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
        Me.GCActualWorkingDaysDW.Caption = "Actual Working Days"
        Me.GCActualWorkingDaysDW.DisplayFormat.FormatString = "N1"
        Me.GCActualWorkingDaysDW.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GCActualWorkingDaysDW.FieldName = "actual_workdays"
        Me.GCActualWorkingDaysDW.Name = "GCActualWorkingDaysDW"
        Me.GCActualWorkingDaysDW.OptionsColumn.AllowEdit = False
        Me.GCActualWorkingDaysDW.Visible = True
        Me.GCActualWorkingDaysDW.Width = 66
        '
        'GCBasicSalaryDW
        '
        Me.GCBasicSalaryDW.Caption = "Daily Salary"
        Me.GCBasicSalaryDW.DisplayFormat.FormatString = "N0"
        Me.GCBasicSalaryDW.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GCBasicSalaryDW.FieldName = "basic_salary"
        Me.GCBasicSalaryDW.Name = "GCBasicSalaryDW"
        Me.GCBasicSalaryDW.OptionsColumn.AllowEdit = False
        Me.GCBasicSalaryDW.Visible = True
        Me.GCBasicSalaryDW.Width = 68
        '
        'GBGrandTotal
        '
        Me.GBGrandTotal.Columns.Add(Me.GCGrandTotal)
        Me.GBGrandTotal.Name = "GBGrandTotal"
        Me.GBGrandTotal.VisibleIndex = 4
        Me.GBGrandTotal.Width = 60
        '
        'GCGrandTotal
        '
        Me.GCGrandTotal.AppearanceCell.Options.UseTextOptions = True
        Me.GCGrandTotal.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GCGrandTotal.Caption = "Grand Total"
        Me.GCGrandTotal.DisplayFormat.FormatString = "N0"
        Me.GCGrandTotal.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GCGrandTotal.FieldName = "grand_total"
        Me.GCGrandTotal.Name = "GCGrandTotal"
        Me.GCGrandTotal.OptionsColumn.AllowEdit = False
        Me.GCGrandTotal.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "grand_total", "{0:N0}")})
        Me.GCGrandTotal.Visible = True
        Me.GCGrandTotal.Width = 60
        '
        'GCSubDepartement
        '
        Me.GCSubDepartement.Caption = "Sub Departement"
        Me.GCSubDepartement.FieldName = "departement_sub"
        Me.GCSubDepartement.Name = "GCSubDepartement"
        '
        'RICEPending
        '
        Me.RICEPending.AutoHeight = False
        Me.RICEPending.Name = "RICEPending"
        Me.RICEPending.ValueChecked = "yes"
        Me.RICEPending.ValueUnchecked = "no"
        '
        'RICESelect
        '
        Me.RICESelect.AutoHeight = False
        Me.RICESelect.Name = "RICESelect"
        Me.RICESelect.ValueChecked = "yes"
        Me.RICESelect.ValueUnchecked = "no"
        '
        'XrLabel1
        '
        Me.XrLabel1.Font = New System.Drawing.Font("Tahoma", 9.75!)
        Me.XrLabel1.LocationFloat = New DevExpress.Utils.PointFloat(855.0!, 33.99998!)
        Me.XrLabel1.Name = "XrLabel1"
        Me.XrLabel1.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel1.SizeF = New System.Drawing.SizeF(60.0!, 23.0!)
        Me.XrLabel1.StylePriority.UseFont = False
        Me.XrLabel1.StylePriority.UseTextAlignment = False
        Me.XrLabel1.Text = "Type"
        Me.XrLabel1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
        '
        'XrLabel2
        '
        Me.XrLabel2.Font = New System.Drawing.Font("Tahoma", 9.75!)
        Me.XrLabel2.LocationFloat = New DevExpress.Utils.PointFloat(855.0!, 57.0!)
        Me.XrLabel2.Name = "XrLabel2"
        Me.XrLabel2.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel2.SizeF = New System.Drawing.SizeF(60.0!, 23.0!)
        Me.XrLabel2.StylePriority.UseFont = False
        Me.XrLabel2.StylePriority.UseTextAlignment = False
        Me.XrLabel2.Text = "Location"
        Me.XrLabel2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
        '
        'XrLabel3
        '
        Me.XrLabel3.Font = New System.Drawing.Font("Tahoma", 9.75!)
        Me.XrLabel3.LocationFloat = New DevExpress.Utils.PointFloat(915.0!, 33.99998!)
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
        Me.XrLabel4.LocationFloat = New DevExpress.Utils.PointFloat(915.0!, 57.0!)
        Me.XrLabel4.Name = "XrLabel4"
        Me.XrLabel4.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel4.SizeF = New System.Drawing.SizeF(15.0!, 23.0!)
        Me.XrLabel4.StylePriority.UseFont = False
        Me.XrLabel4.StylePriority.UseTextAlignment = False
        Me.XrLabel4.Text = ":"
        Me.XrLabel4.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
        '
        'XLType
        '
        Me.XLType.Font = New System.Drawing.Font("Tahoma", 9.75!)
        Me.XLType.LocationFloat = New DevExpress.Utils.PointFloat(930.0007!, 33.99998!)
        Me.XLType.Name = "XLType"
        Me.XLType.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XLType.SizeF = New System.Drawing.SizeF(145.0!, 23.0!)
        Me.XLType.StylePriority.UseFont = False
        Me.XLType.StylePriority.UseTextAlignment = False
        Me.XLType.Text = "[type]"
        Me.XLType.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
        '
        'XLLocation
        '
        Me.XLLocation.Font = New System.Drawing.Font("Tahoma", 9.75!)
        Me.XLLocation.LocationFloat = New DevExpress.Utils.PointFloat(930.0007!, 57.0!)
        Me.XLLocation.Name = "XLLocation"
        Me.XLLocation.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XLLocation.SizeF = New System.Drawing.SizeF(144.9993!, 23.0!)
        Me.XLLocation.StylePriority.UseFont = False
        Me.XLLocation.StylePriority.UseTextAlignment = False
        Me.XLLocation.Text = "[location]"
        Me.XLLocation.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
        '
        'TopMargin
        '
        Me.TopMargin.HeightF = 50.0!
        Me.TopMargin.Name = "TopMargin"
        Me.TopMargin.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
        Me.TopMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
        '
        'XLTitle
        '
        Me.XLTitle.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Bold)
        Me.XLTitle.LocationFloat = New DevExpress.Utils.PointFloat(220.0004!, 22.99999!)
        Me.XLTitle.Multiline = True
        Me.XLTitle.Name = "XLTitle"
        Me.XLTitle.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XLTitle.SizeF = New System.Drawing.SizeF(634.9996!, 41.15001!)
        Me.XLTitle.StylePriority.UseFont = False
        Me.XLTitle.StylePriority.UseTextAlignment = False
        Me.XLTitle.Text = "Monthly Payroll"
        Me.XLTitle.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        '
        'XLPeriod
        '
        Me.XLPeriod.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold)
        Me.XLPeriod.LocationFloat = New DevExpress.Utils.PointFloat(855.0!, 11.0!)
        Me.XLPeriod.Name = "XLPeriod"
        Me.XLPeriod.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XLPeriod.SizeF = New System.Drawing.SizeF(220.0!, 23.0!)
        Me.XLPeriod.StylePriority.UseFont = False
        Me.XLPeriod.StylePriority.UseTextAlignment = False
        Me.XLPeriod.Text = "[period]"
        Me.XLPeriod.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
        '
        'XrLine1
        '
        Me.XrLine1.LocationFloat = New DevExpress.Utils.PointFloat(0.0004132589!, 79.99998!)
        Me.XrLine1.Name = "XrLine1"
        Me.XrLine1.SizeF = New System.Drawing.SizeF(1075.0!, 20.0!)
        '
        'XrPictureBox1
        '
        Me.XrPictureBox1.AnchorHorizontal = DevExpress.XtraReports.UI.HorizontalAnchorStyles.Left
        Me.XrPictureBox1.Image = CType(resources.GetObject("XrPictureBox1.Image"), System.Drawing.Image)
        Me.XrPictureBox1.LocationFloat = New DevExpress.Utils.PointFloat(0.0004053116!, 22.99999!)
        Me.XrPictureBox1.Name = "XrPictureBox1"
        Me.XrPictureBox1.SizeF = New System.Drawing.SizeF(220.0!, 41.15!)
        Me.XrPictureBox1.Sizing = DevExpress.XtraPrinting.ImageSizeMode.StretchImage
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
        Me.XrPageInfo1.LocationFloat = New DevExpress.Utils.PointFloat(925.0007!, 0!)
        Me.XrPageInfo1.Name = "XrPageInfo1"
        Me.XrPageInfo1.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrPageInfo1.SizeF = New System.Drawing.SizeF(150.0!, 18.71793!)
        Me.XrPageInfo1.StylePriority.UseBorders = False
        Me.XrPageInfo1.StylePriority.UseFont = False
        Me.XrPageInfo1.StylePriority.UseTextAlignment = False
        Me.XrPageInfo1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
        '
        'SqlDataSource1
        '
        Me.SqlDataSource1.Name = "SqlDataSource1"
        '
        'ReportHeader
        '
        Me.ReportHeader.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.XrLine1, Me.XLLocation, Me.XrLabel2, Me.XLType, Me.XLTitle, Me.XLPeriod, Me.XrLabel4, Me.XrLabel3, Me.XrPictureBox1, Me.XrLabel1})
        Me.ReportHeader.HeightF = 100.0!
        Me.ReportHeader.Name = "ReportHeader"
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
        Me.XrPanel1.SizeF = New System.Drawing.SizeF(1075.0!, 100.0!)
        '
        'XrTable1
        '
        Me.XrTable1.Font = New System.Drawing.Font("Tahoma", 7.25!)
        Me.XrTable1.LocationFloat = New DevExpress.Utils.PointFloat(0.00009536743!, 19.99995!)
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
        'ReportPayrollAll
        '
        Me.Bands.AddRange(New DevExpress.XtraReports.UI.Band() {Me.Detail, Me.TopMargin, Me.BottomMargin, Me.ReportHeader, Me.ReportFooter})
        Me.ComponentStorage.AddRange(New System.ComponentModel.IComponent() {Me.SqlDataSource1})
        Me.Landscape = True
        Me.Margins = New System.Drawing.Printing.Margins(25, 69, 50, 50)
        Me.PageHeight = 827
        Me.PageWidth = 1169
        Me.PaperKind = System.Drawing.Printing.PaperKind.A4
        Me.ScriptLanguage = DevExpress.XtraReports.ScriptLanguage.VisualBasic
        Me.Version = "15.1"
        Me.VerticalContentSplitting = DevExpress.XtraPrinting.VerticalContentSplitting.Smart
        CType(Me.GCPayroll, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVPayroll, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RICEPending, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RICESelect, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.XrTable1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me, System.ComponentModel.ISupportInitialize).EndInit()

    End Sub
    Friend WithEvents Detail As DevExpress.XtraReports.UI.DetailBand
    Friend WithEvents TopMargin As DevExpress.XtraReports.UI.TopMarginBand
    Friend WithEvents BottomMargin As DevExpress.XtraReports.UI.BottomMarginBand
    Friend WithEvents SqlDataSource1 As DevExpress.DataAccess.Sql.SqlDataSource
    Friend WithEvents WinControlContainer1 As DevExpress.XtraReports.UI.WinControlContainer
    Friend WithEvents GCPayroll As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVPayroll As DevExpress.XtraGrid.Views.BandedGrid.BandedGridView
    Friend WithEvents GCNIP As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents GCName As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents GCDepartement As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents GCPosition As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents GCStatus As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents GCWorkingDays As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents GCTotalTHP As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents GCTotalAdjustment As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents GCTotalDeduction As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents GCTotalPaymentOvertime As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents GCGrandTotal As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents RICEPending As DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit
    Friend WithEvents RICESelect As DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit
    Friend WithEvents XrPictureBox1 As DevExpress.XtraReports.UI.XRPictureBox
    Friend WithEvents XLTitle As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XLPeriod As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLine1 As DevExpress.XtraReports.UI.XRLine
    Friend WithEvents GCActualWorkingDays As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents GCActualWorkingDaysDW As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents GCBasicSalaryDW As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents GCOvertimeHours As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents XrPageInfo1 As DevExpress.XtraReports.UI.XRPageInfo
    Friend WithEvents GBEmployee As DevExpress.XtraGrid.Views.BandedGrid.GridBand
    Friend WithEvents GBWorkingDays As DevExpress.XtraGrid.Views.BandedGrid.GridBand
    Friend WithEvents GBSalary As DevExpress.XtraGrid.Views.BandedGrid.GridBand
    Friend WithEvents GBDW As DevExpress.XtraGrid.Views.BandedGrid.GridBand
    Friend WithEvents GBGrandTotal As DevExpress.XtraGrid.Views.BandedGrid.GridBand
    Friend WithEvents XLType As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel4 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel3 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel2 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel1 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XLLocation As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents ReportHeader As DevExpress.XtraReports.UI.ReportHeaderBand
    Friend WithEvents ReportFooter As DevExpress.XtraReports.UI.ReportFooterBand
    Friend WithEvents XrPanel1 As DevExpress.XtraReports.UI.XRPanel
    Friend WithEvents XrTable1 As DevExpress.XtraReports.UI.XRTable
    Friend WithEvents XrTableRow1 As DevExpress.XtraReports.UI.XRTableRow
    Friend WithEvents XrTableCell13 As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents GCSubDepartement As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
End Class
