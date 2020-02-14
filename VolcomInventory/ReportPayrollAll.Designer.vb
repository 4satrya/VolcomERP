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
        Me.WinControlContainer2 = New DevExpress.XtraReports.UI.WinControlContainer()
        Me.GCPayrollStore = New DevExpress.XtraGrid.GridControl()
        Me.GVPayrollStore = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridView()
        Me.GBEmployeeStore = New DevExpress.XtraGrid.Views.BandedGrid.GridBand()
        Me.GCNIPStore = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.GCNameStore = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.GCDepartementStore = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.GCPositionStore = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.GCStatusStore = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.GBWorkingDaysStore = New DevExpress.XtraGrid.Views.BandedGrid.GridBand()
        Me.GCWorkingDaysStore = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.GCActualWorkingDaysStore = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.GCOvertimeHoursStore = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.GBDWStore = New DevExpress.XtraGrid.Views.BandedGrid.GridBand()
        Me.GCActualWorkingDaysDWStore = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.GCBasicSalaryDWStore = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.GCTotalSalaryDWStore = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.GBTHRStore = New DevExpress.XtraGrid.Views.BandedGrid.GridBand()
        Me.GCActualJoinDateTHRStore = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.GCLengthOfWorkTHRStore = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.GCTotalSalaryTHRStore = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.GBSalaryStore = New DevExpress.XtraGrid.Views.BandedGrid.GridBand()
        Me.GCTotalTHPStore = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.GCTotalAdjustmentStore = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.GCTotalPaymentOvertimeStore = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.GCTotalDeductionStore = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.GBGrandTotalStore = New DevExpress.XtraGrid.Views.BandedGrid.GridBand()
        Me.GCGrandTotalStore = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.GCSubDepartementStore = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.RepositoryItemCheckEdit3 = New DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit()
        Me.RITEActWorkdaysDW = New DevExpress.XtraEditors.Repository.RepositoryItemTextEdit()
        Me.RICECheck = New DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit()
        Me.RITEActWorkdays = New DevExpress.XtraEditors.Repository.RepositoryItemTextEdit()
        Me.RICESent = New DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit()
        Me.XrLabel5 = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLabel6 = New DevExpress.XtraReports.UI.XRLabel()
        Me.XLLocationStore = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLabel2 = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLabel4 = New DevExpress.XtraReports.UI.XRLabel()
        Me.XLLocationOffice = New DevExpress.XtraReports.UI.XRLabel()
        Me.WinControlContainer1 = New DevExpress.XtraReports.UI.WinControlContainer()
        Me.GCPayrollOffice = New DevExpress.XtraGrid.GridControl()
        Me.GVPayrollOffice = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridView()
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
        Me.GBDW = New DevExpress.XtraGrid.Views.BandedGrid.GridBand()
        Me.GCActualWorkingDaysDW = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.GCBasicSalaryDW = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.GCTotalSalaryDW = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.GBTHR = New DevExpress.XtraGrid.Views.BandedGrid.GridBand()
        Me.GCActualJoinDateTHR = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.GCLengthOfWorkTHR = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.GCTotalSalaryTHR = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.GBSalary = New DevExpress.XtraGrid.Views.BandedGrid.GridBand()
        Me.GCTotalTHP = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.GCTotalAdjustment = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.GCTotalPaymentOvertime = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.GCTotalDeduction = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.GBGrandTotal = New DevExpress.XtraGrid.Views.BandedGrid.GridBand()
        Me.GCGrandTotal = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.GCSubDepartement = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.RICEPending = New DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit()
        Me.RICESelect = New DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit()
        Me.XrLabel1 = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLabel3 = New DevExpress.XtraReports.UI.XRLabel()
        Me.XLType = New DevExpress.XtraReports.UI.XRLabel()
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
        Me.RepositoryItemCheckEdit1 = New DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit()
        Me.RepositoryItemCheckEdit2 = New DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit()
        Me.BandedGridView1 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridView()
        Me.GridBand1 = New DevExpress.XtraGrid.Views.BandedGrid.GridBand()
        Me.BandedGridColumn1 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumn2 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumn3 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumn4 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumn5 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.GridBand2 = New DevExpress.XtraGrid.Views.BandedGrid.GridBand()
        Me.BandedGridColumn6 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumn7 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumn8 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.GridBand3 = New DevExpress.XtraGrid.Views.BandedGrid.GridBand()
        Me.BandedGridColumn9 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumn10 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumn11 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.GridBand4 = New DevExpress.XtraGrid.Views.BandedGrid.GridBand()
        Me.BandedGridColumn12 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumn13 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumn14 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumn15 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.GridBand5 = New DevExpress.XtraGrid.Views.BandedGrid.GridBand()
        Me.BandedGridColumn16 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumn17 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.DetailReportOffice = New DevExpress.XtraReports.UI.DetailReportBand()
        Me.DetailOffice = New DevExpress.XtraReports.UI.DetailBand()
        Me.DetailReportStore = New DevExpress.XtraReports.UI.DetailReportBand()
        Me.DetailStore = New DevExpress.XtraReports.UI.DetailBand()
        CType(Me.GCPayrollStore, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVPayrollStore, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemCheckEdit3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RITEActWorkdaysDW, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RICECheck, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RITEActWorkdays, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RICESent, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GCPayrollOffice, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVPayrollOffice, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RICEPending, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RICESelect, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.XrTable1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemCheckEdit1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemCheckEdit2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BandedGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
        '
        'Detail
        '
        Me.Detail.HeightF = 0!
        Me.Detail.Name = "Detail"
        Me.Detail.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
        Me.Detail.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
        '
        'WinControlContainer2
        '
        Me.WinControlContainer2.LocationFloat = New DevExpress.Utils.PointFloat(0.0007311503!, 28.0!)
        Me.WinControlContainer2.Name = "WinControlContainer2"
        Me.WinControlContainer2.SizeF = New System.Drawing.SizeF(1075.0!, 104.0!)
        Me.WinControlContainer2.WinControl = Me.GCPayrollStore
        '
        'GCPayrollStore
        '
        Me.GCPayrollStore.Location = New System.Drawing.Point(0, 39)
        Me.GCPayrollStore.MainView = Me.GVPayrollStore
        Me.GCPayrollStore.Name = "GCPayrollStore"
        Me.GCPayrollStore.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.RepositoryItemCheckEdit3, Me.RITEActWorkdaysDW, Me.RICECheck, Me.RITEActWorkdays, Me.RICESent})
        Me.GCPayrollStore.Size = New System.Drawing.Size(1032, 100)
        Me.GCPayrollStore.TabIndex = 1
        Me.GCPayrollStore.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVPayrollStore})
        '
        'GVPayrollStore
        '
        Me.GVPayrollStore.AppearancePrint.BandPanel.BackColor = System.Drawing.Color.White
        Me.GVPayrollStore.AppearancePrint.BandPanel.BorderColor = System.Drawing.Color.Black
        Me.GVPayrollStore.AppearancePrint.BandPanel.Font = New System.Drawing.Font("Tahoma", 7.25!, System.Drawing.FontStyle.Bold)
        Me.GVPayrollStore.AppearancePrint.BandPanel.Options.UseBackColor = True
        Me.GVPayrollStore.AppearancePrint.BandPanel.Options.UseBorderColor = True
        Me.GVPayrollStore.AppearancePrint.BandPanel.Options.UseFont = True
        Me.GVPayrollStore.AppearancePrint.FooterPanel.BackColor = System.Drawing.Color.White
        Me.GVPayrollStore.AppearancePrint.FooterPanel.BorderColor = System.Drawing.Color.Black
        Me.GVPayrollStore.AppearancePrint.FooterPanel.Font = New System.Drawing.Font("Tahoma", 7.25!)
        Me.GVPayrollStore.AppearancePrint.FooterPanel.Options.UseBackColor = True
        Me.GVPayrollStore.AppearancePrint.FooterPanel.Options.UseBorderColor = True
        Me.GVPayrollStore.AppearancePrint.FooterPanel.Options.UseFont = True
        Me.GVPayrollStore.AppearancePrint.GroupFooter.BackColor = System.Drawing.Color.White
        Me.GVPayrollStore.AppearancePrint.GroupFooter.BorderColor = System.Drawing.Color.Black
        Me.GVPayrollStore.AppearancePrint.GroupFooter.Font = New System.Drawing.Font("Tahoma", 7.25!)
        Me.GVPayrollStore.AppearancePrint.GroupFooter.Options.UseBackColor = True
        Me.GVPayrollStore.AppearancePrint.GroupFooter.Options.UseBorderColor = True
        Me.GVPayrollStore.AppearancePrint.GroupFooter.Options.UseFont = True
        Me.GVPayrollStore.AppearancePrint.GroupRow.BackColor = System.Drawing.Color.White
        Me.GVPayrollStore.AppearancePrint.GroupRow.BorderColor = System.Drawing.Color.Black
        Me.GVPayrollStore.AppearancePrint.GroupRow.Font = New System.Drawing.Font("Tahoma", 7.25!, System.Drawing.FontStyle.Bold)
        Me.GVPayrollStore.AppearancePrint.GroupRow.Options.UseBackColor = True
        Me.GVPayrollStore.AppearancePrint.GroupRow.Options.UseBorderColor = True
        Me.GVPayrollStore.AppearancePrint.GroupRow.Options.UseFont = True
        Me.GVPayrollStore.AppearancePrint.HeaderPanel.BackColor = System.Drawing.Color.White
        Me.GVPayrollStore.AppearancePrint.HeaderPanel.BorderColor = System.Drawing.Color.Black
        Me.GVPayrollStore.AppearancePrint.HeaderPanel.Font = New System.Drawing.Font("Tahoma", 7.25!, System.Drawing.FontStyle.Bold)
        Me.GVPayrollStore.AppearancePrint.HeaderPanel.Options.UseBackColor = True
        Me.GVPayrollStore.AppearancePrint.HeaderPanel.Options.UseBorderColor = True
        Me.GVPayrollStore.AppearancePrint.HeaderPanel.Options.UseFont = True
        Me.GVPayrollStore.AppearancePrint.Lines.BackColor = System.Drawing.Color.Black
        Me.GVPayrollStore.AppearancePrint.Lines.Options.UseBackColor = True
        Me.GVPayrollStore.AppearancePrint.Row.BackColor = System.Drawing.Color.White
        Me.GVPayrollStore.AppearancePrint.Row.BorderColor = System.Drawing.Color.Black
        Me.GVPayrollStore.AppearancePrint.Row.Font = New System.Drawing.Font("Tahoma", 7.25!)
        Me.GVPayrollStore.AppearancePrint.Row.Options.UseBackColor = True
        Me.GVPayrollStore.AppearancePrint.Row.Options.UseBorderColor = True
        Me.GVPayrollStore.AppearancePrint.Row.Options.UseFont = True
        Me.GVPayrollStore.BandPanelRowHeight = 16
        Me.GVPayrollStore.Bands.AddRange(New DevExpress.XtraGrid.Views.BandedGrid.GridBand() {Me.GBEmployeeStore, Me.GBWorkingDaysStore, Me.GBDWStore, Me.GBTHRStore, Me.GBSalaryStore, Me.GBGrandTotalStore})
        Me.GVPayrollStore.ColumnPanelRowHeight = 32
        Me.GVPayrollStore.Columns.AddRange(New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn() {Me.GCDepartementStore, Me.GCSubDepartementStore, Me.GCNIPStore, Me.GCNameStore, Me.GCPositionStore, Me.GCStatusStore, Me.GCWorkingDaysStore, Me.GCActualWorkingDaysStore, Me.GCOvertimeHoursStore, Me.GCTotalTHPStore, Me.GCTotalAdjustmentStore, Me.GCTotalPaymentOvertimeStore, Me.GCTotalDeductionStore, Me.GCActualWorkingDaysDWStore, Me.GCBasicSalaryDWStore, Me.GCTotalSalaryDWStore, Me.GCActualJoinDateTHRStore, Me.GCLengthOfWorkTHRStore, Me.GCTotalSalaryTHRStore, Me.GCGrandTotalStore})
        Me.GVPayrollStore.GridControl = Me.GCPayrollStore
        Me.GVPayrollStore.GroupCount = 2
        Me.GVPayrollStore.GroupFormat = "{1} {2}"
        Me.GVPayrollStore.GroupSummary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Custom, "tot_thp", Me.GCTotalTHPStore, "{0:N2}"), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Custom, "total_adjustment", Me.GCTotalAdjustmentStore, "{0:N2}"), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Custom, "total_deduction", Me.GCTotalDeductionStore, "{0:N2}"), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Custom, "total_ot_wages", Me.GCTotalPaymentOvertimeStore, "{0:N2}"), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Custom, "grand_total", Me.GCGrandTotalStore, "{0:N0}"), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Custom, "total_salary_dw", Me.GCTotalSalaryDWStore, "{0:N0}"), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Custom, "employee_name", Me.GCNameStore, "", ""), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Custom, "total_salary_thr", Me.GCTotalSalaryTHRStore, "{0:N0}")})
        Me.GVPayrollStore.LevelIndent = 0
        Me.GVPayrollStore.Name = "GVPayrollStore"
        Me.GVPayrollStore.OptionsBehavior.AutoExpandAllGroups = True
        Me.GVPayrollStore.OptionsMenu.ShowConditionalFormattingItem = True
        Me.GVPayrollStore.OptionsPrint.AllowMultilineHeaders = True
        Me.GVPayrollStore.OptionsView.GroupFooterShowMode = DevExpress.XtraGrid.Views.Grid.GroupFooterShowMode.VisibleAlways
        Me.GVPayrollStore.OptionsView.ShowFooter = True
        Me.GVPayrollStore.OptionsView.ShowGroupPanel = False
        Me.GVPayrollStore.SortInfo.AddRange(New DevExpress.XtraGrid.Columns.GridColumnSortInfo() {New DevExpress.XtraGrid.Columns.GridColumnSortInfo(Me.GCDepartementStore, DevExpress.Data.ColumnSortOrder.Ascending), New DevExpress.XtraGrid.Columns.GridColumnSortInfo(Me.GCSubDepartementStore, DevExpress.Data.ColumnSortOrder.Ascending)})
        '
        'GBEmployeeStore
        '
        Me.GBEmployeeStore.Caption = "Employee"
        Me.GBEmployeeStore.Columns.Add(Me.GCNIPStore)
        Me.GBEmployeeStore.Columns.Add(Me.GCNameStore)
        Me.GBEmployeeStore.Columns.Add(Me.GCDepartementStore)
        Me.GBEmployeeStore.Columns.Add(Me.GCPositionStore)
        Me.GBEmployeeStore.Columns.Add(Me.GCStatusStore)
        Me.GBEmployeeStore.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left
        Me.GBEmployeeStore.Name = "GBEmployeeStore"
        Me.GBEmployeeStore.VisibleIndex = 0
        Me.GBEmployeeStore.Width = 512
        '
        'GCNIPStore
        '
        Me.GCNIPStore.Caption = "NIP"
        Me.GCNIPStore.FieldName = "employee_code"
        Me.GCNIPStore.MinWidth = 65
        Me.GCNIPStore.Name = "GCNIPStore"
        Me.GCNIPStore.OptionsColumn.AllowEdit = False
        Me.GCNIPStore.Visible = True
        Me.GCNIPStore.Width = 107
        '
        'GCNameStore
        '
        Me.GCNameStore.AppearanceCell.Options.UseTextOptions = True
        Me.GCNameStore.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
        Me.GCNameStore.AppearanceCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
        Me.GCNameStore.Caption = "Employee"
        Me.GCNameStore.FieldName = "employee_name"
        Me.GCNameStore.MinWidth = 195
        Me.GCNameStore.Name = "GCNameStore"
        Me.GCNameStore.OptionsColumn.AllowEdit = False
        Me.GCNameStore.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Custom)})
        Me.GCNameStore.Visible = True
        Me.GCNameStore.Width = 195
        '
        'GCDepartementStore
        '
        Me.GCDepartementStore.Caption = "Departement"
        Me.GCDepartementStore.FieldName = "departement"
        Me.GCDepartementStore.Name = "GCDepartementStore"
        Me.GCDepartementStore.OptionsColumn.AllowEdit = False
        '
        'GCPositionStore
        '
        Me.GCPositionStore.AppearanceCell.Options.UseTextOptions = True
        Me.GCPositionStore.AppearanceCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
        Me.GCPositionStore.Caption = "Employee Position"
        Me.GCPositionStore.FieldName = "employee_position"
        Me.GCPositionStore.MinWidth = 150
        Me.GCPositionStore.Name = "GCPositionStore"
        Me.GCPositionStore.OptionsColumn.AllowEdit = False
        Me.GCPositionStore.Visible = True
        Me.GCPositionStore.Width = 150
        '
        'GCStatusStore
        '
        Me.GCStatusStore.Caption = "Employee Status"
        Me.GCStatusStore.FieldName = "employee_status"
        Me.GCStatusStore.MinWidth = 60
        Me.GCStatusStore.Name = "GCStatusStore"
        Me.GCStatusStore.OptionsColumn.AllowEdit = False
        Me.GCStatusStore.Visible = True
        Me.GCStatusStore.Width = 60
        '
        'GBWorkingDaysStore
        '
        Me.GBWorkingDaysStore.AppearanceHeader.Options.UseTextOptions = True
        Me.GBWorkingDaysStore.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GBWorkingDaysStore.Caption = "Working Days (WD)"
        Me.GBWorkingDaysStore.Columns.Add(Me.GCWorkingDaysStore)
        Me.GBWorkingDaysStore.Columns.Add(Me.GCActualWorkingDaysStore)
        Me.GBWorkingDaysStore.Columns.Add(Me.GCOvertimeHoursStore)
        Me.GBWorkingDaysStore.Name = "GBWorkingDaysStore"
        Me.GBWorkingDaysStore.VisibleIndex = 1
        Me.GBWorkingDaysStore.Width = 81
        '
        'GCWorkingDaysStore
        '
        Me.GCWorkingDaysStore.AppearanceCell.Options.UseTextOptions = True
        Me.GCWorkingDaysStore.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GCWorkingDaysStore.Caption = "WD"
        Me.GCWorkingDaysStore.DisplayFormat.FormatString = "N1"
        Me.GCWorkingDaysStore.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GCWorkingDaysStore.FieldName = "workdays"
        Me.GCWorkingDaysStore.Name = "GCWorkingDaysStore"
        Me.GCWorkingDaysStore.OptionsColumn.AllowEdit = False
        Me.GCWorkingDaysStore.Width = 35
        '
        'GCActualWorkingDaysStore
        '
        Me.GCActualWorkingDaysStore.AppearanceCell.Options.UseTextOptions = True
        Me.GCActualWorkingDaysStore.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GCActualWorkingDaysStore.Caption = "Actual WD"
        Me.GCActualWorkingDaysStore.DisplayFormat.FormatString = "N1"
        Me.GCActualWorkingDaysStore.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GCActualWorkingDaysStore.FieldName = "actual_workdays"
        Me.GCActualWorkingDaysStore.Name = "GCActualWorkingDaysStore"
        Me.GCActualWorkingDaysStore.OptionsColumn.AllowEdit = False
        Me.GCActualWorkingDaysStore.Visible = True
        Me.GCActualWorkingDaysStore.Width = 35
        '
        'GCOvertimeHoursStore
        '
        Me.GCOvertimeHoursStore.AppearanceCell.Options.UseTextOptions = True
        Me.GCOvertimeHoursStore.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GCOvertimeHoursStore.Caption = "Overtime (Hours)"
        Me.GCOvertimeHoursStore.DisplayFormat.FormatString = "N1"
        Me.GCOvertimeHoursStore.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GCOvertimeHoursStore.FieldName = "total_ot_hour"
        Me.GCOvertimeHoursStore.Name = "GCOvertimeHoursStore"
        Me.GCOvertimeHoursStore.OptionsColumn.AllowEdit = False
        Me.GCOvertimeHoursStore.Visible = True
        Me.GCOvertimeHoursStore.Width = 46
        '
        'GBDWStore
        '
        Me.GBDWStore.Columns.Add(Me.GCActualWorkingDaysDWStore)
        Me.GBDWStore.Columns.Add(Me.GCBasicSalaryDWStore)
        Me.GBDWStore.Columns.Add(Me.GCTotalSalaryDWStore)
        Me.GBDWStore.Name = "GBDWStore"
        Me.GBDWStore.VisibleIndex = 2
        Me.GBDWStore.Width = 209
        '
        'GCActualWorkingDaysDWStore
        '
        Me.GCActualWorkingDaysDWStore.AppearanceCell.Options.UseTextOptions = True
        Me.GCActualWorkingDaysDWStore.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GCActualWorkingDaysDWStore.AppearanceCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
        Me.GCActualWorkingDaysDWStore.Caption = "Actual Working Days"
        Me.GCActualWorkingDaysDWStore.DisplayFormat.FormatString = "N1"
        Me.GCActualWorkingDaysDWStore.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GCActualWorkingDaysDWStore.FieldName = "actual_workdays"
        Me.GCActualWorkingDaysDWStore.Name = "GCActualWorkingDaysDWStore"
        Me.GCActualWorkingDaysDWStore.OptionsColumn.AllowEdit = False
        Me.GCActualWorkingDaysDWStore.Visible = True
        Me.GCActualWorkingDaysDWStore.Width = 66
        '
        'GCBasicSalaryDWStore
        '
        Me.GCBasicSalaryDWStore.Caption = "Daily Salary"
        Me.GCBasicSalaryDWStore.DisplayFormat.FormatString = "N0"
        Me.GCBasicSalaryDWStore.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GCBasicSalaryDWStore.FieldName = "basic_salary"
        Me.GCBasicSalaryDWStore.Name = "GCBasicSalaryDWStore"
        Me.GCBasicSalaryDWStore.OptionsColumn.AllowEdit = False
        Me.GCBasicSalaryDWStore.Visible = True
        Me.GCBasicSalaryDWStore.Width = 68
        '
        'GCTotalSalaryDWStore
        '
        Me.GCTotalSalaryDWStore.Caption = "Total Salary"
        Me.GCTotalSalaryDWStore.DisplayFormat.FormatString = "N0"
        Me.GCTotalSalaryDWStore.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GCTotalSalaryDWStore.FieldName = "total_salary_dw"
        Me.GCTotalSalaryDWStore.Name = "GCTotalSalaryDWStore"
        Me.GCTotalSalaryDWStore.OptionsColumn.AllowEdit = False
        Me.GCTotalSalaryDWStore.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "total_salary_dw", "{0:N0}")})
        Me.GCTotalSalaryDWStore.Visible = True
        '
        'GBTHRStore
        '
        Me.GBTHRStore.Columns.Add(Me.GCActualJoinDateTHRStore)
        Me.GBTHRStore.Columns.Add(Me.GCLengthOfWorkTHRStore)
        Me.GBTHRStore.Columns.Add(Me.GCTotalSalaryTHRStore)
        Me.GBTHRStore.Name = "GBTHRStore"
        Me.GBTHRStore.VisibleIndex = 3
        Me.GBTHRStore.Width = 225
        '
        'GCActualJoinDateTHRStore
        '
        Me.GCActualJoinDateTHRStore.Caption = "Actual Join Date"
        Me.GCActualJoinDateTHRStore.FieldName = "employee_actual_join_date"
        Me.GCActualJoinDateTHRStore.Name = "GCActualJoinDateTHRStore"
        Me.GCActualJoinDateTHRStore.Visible = True
        '
        'GCLengthOfWorkTHRStore
        '
        Me.GCLengthOfWorkTHRStore.Caption = "Length of Work (Year)"
        Me.GCLengthOfWorkTHRStore.DisplayFormat.FormatString = "N2"
        Me.GCLengthOfWorkTHRStore.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GCLengthOfWorkTHRStore.FieldName = "actual_workdays"
        Me.GCLengthOfWorkTHRStore.Name = "GCLengthOfWorkTHRStore"
        Me.GCLengthOfWorkTHRStore.Visible = True
        '
        'GCTotalSalaryTHRStore
        '
        Me.GCTotalSalaryTHRStore.Caption = "Total THR"
        Me.GCTotalSalaryTHRStore.DisplayFormat.FormatString = "N0"
        Me.GCTotalSalaryTHRStore.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GCTotalSalaryTHRStore.FieldName = "total_salary_thr"
        Me.GCTotalSalaryTHRStore.Name = "GCTotalSalaryTHRStore"
        Me.GCTotalSalaryTHRStore.OptionsColumn.AllowEdit = False
        Me.GCTotalSalaryTHRStore.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "total_salary_thr", "{0:N0}")})
        Me.GCTotalSalaryTHRStore.Visible = True
        '
        'GBSalaryStore
        '
        Me.GBSalaryStore.AppearanceHeader.Options.UseTextOptions = True
        Me.GBSalaryStore.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GBSalaryStore.Columns.Add(Me.GCTotalTHPStore)
        Me.GBSalaryStore.Columns.Add(Me.GCTotalAdjustmentStore)
        Me.GBSalaryStore.Columns.Add(Me.GCTotalPaymentOvertimeStore)
        Me.GBSalaryStore.Columns.Add(Me.GCTotalDeductionStore)
        Me.GBSalaryStore.Name = "GBSalaryStore"
        Me.GBSalaryStore.VisibleIndex = 4
        Me.GBSalaryStore.Width = 232
        '
        'GCTotalTHPStore
        '
        Me.GCTotalTHPStore.AppearanceCell.Options.UseTextOptions = True
        Me.GCTotalTHPStore.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GCTotalTHPStore.Caption = "Total THP"
        Me.GCTotalTHPStore.DisplayFormat.FormatString = "N2"
        Me.GCTotalTHPStore.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GCTotalTHPStore.FieldName = "tot_thp"
        Me.GCTotalTHPStore.Name = "GCTotalTHPStore"
        Me.GCTotalTHPStore.OptionsColumn.AllowEdit = False
        Me.GCTotalTHPStore.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "tot_thp", "{0:N2}")})
        Me.GCTotalTHPStore.Visible = True
        Me.GCTotalTHPStore.Width = 57
        '
        'GCTotalAdjustmentStore
        '
        Me.GCTotalAdjustmentStore.AppearanceCell.Options.UseTextOptions = True
        Me.GCTotalAdjustmentStore.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GCTotalAdjustmentStore.Caption = "Total Bonus / Adj"
        Me.GCTotalAdjustmentStore.DisplayFormat.FormatString = "N2"
        Me.GCTotalAdjustmentStore.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GCTotalAdjustmentStore.FieldName = "total_adjustment"
        Me.GCTotalAdjustmentStore.Name = "GCTotalAdjustmentStore"
        Me.GCTotalAdjustmentStore.OptionsColumn.AllowEdit = False
        Me.GCTotalAdjustmentStore.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "total_adjustment", "{0:N2}")})
        Me.GCTotalAdjustmentStore.Visible = True
        Me.GCTotalAdjustmentStore.Width = 57
        '
        'GCTotalPaymentOvertimeStore
        '
        Me.GCTotalPaymentOvertimeStore.AppearanceCell.Options.UseTextOptions = True
        Me.GCTotalPaymentOvertimeStore.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GCTotalPaymentOvertimeStore.Caption = "Total Overtime"
        Me.GCTotalPaymentOvertimeStore.DisplayFormat.FormatString = "N2"
        Me.GCTotalPaymentOvertimeStore.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GCTotalPaymentOvertimeStore.FieldName = "total_ot_wages"
        Me.GCTotalPaymentOvertimeStore.Name = "GCTotalPaymentOvertimeStore"
        Me.GCTotalPaymentOvertimeStore.OptionsColumn.AllowEdit = False
        Me.GCTotalPaymentOvertimeStore.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "total_ot_wages", "{0:N2}")})
        Me.GCTotalPaymentOvertimeStore.Visible = True
        Me.GCTotalPaymentOvertimeStore.Width = 57
        '
        'GCTotalDeductionStore
        '
        Me.GCTotalDeductionStore.AppearanceCell.Options.UseTextOptions = True
        Me.GCTotalDeductionStore.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GCTotalDeductionStore.Caption = "Total Deduction"
        Me.GCTotalDeductionStore.DisplayFormat.FormatString = "N2"
        Me.GCTotalDeductionStore.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GCTotalDeductionStore.FieldName = "total_deduction"
        Me.GCTotalDeductionStore.Name = "GCTotalDeductionStore"
        Me.GCTotalDeductionStore.OptionsColumn.AllowEdit = False
        Me.GCTotalDeductionStore.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "total_deduction", "{0:N2}")})
        Me.GCTotalDeductionStore.Visible = True
        Me.GCTotalDeductionStore.Width = 61
        '
        'GBGrandTotalStore
        '
        Me.GBGrandTotalStore.Columns.Add(Me.GCGrandTotalStore)
        Me.GBGrandTotalStore.Name = "GBGrandTotalStore"
        Me.GBGrandTotalStore.VisibleIndex = 5
        Me.GBGrandTotalStore.Width = 60
        '
        'GCGrandTotalStore
        '
        Me.GCGrandTotalStore.AppearanceCell.Options.UseTextOptions = True
        Me.GCGrandTotalStore.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GCGrandTotalStore.Caption = "Grand Total"
        Me.GCGrandTotalStore.DisplayFormat.FormatString = "N0"
        Me.GCGrandTotalStore.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GCGrandTotalStore.FieldName = "grand_total"
        Me.GCGrandTotalStore.Name = "GCGrandTotalStore"
        Me.GCGrandTotalStore.OptionsColumn.AllowEdit = False
        Me.GCGrandTotalStore.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "grand_total", "{0:N0}")})
        Me.GCGrandTotalStore.Visible = True
        Me.GCGrandTotalStore.Width = 60
        '
        'GCSubDepartementStore
        '
        Me.GCSubDepartementStore.Caption = "Sub Departement"
        Me.GCSubDepartementStore.FieldName = "departement_sub"
        Me.GCSubDepartementStore.Name = "GCSubDepartementStore"
        '
        'RepositoryItemCheckEdit3
        '
        Me.RepositoryItemCheckEdit3.AutoHeight = False
        Me.RepositoryItemCheckEdit3.Name = "RepositoryItemCheckEdit3"
        Me.RepositoryItemCheckEdit3.ValueChecked = "yes"
        Me.RepositoryItemCheckEdit3.ValueUnchecked = "no"
        '
        'RITEActWorkdaysDW
        '
        Me.RITEActWorkdaysDW.AutoHeight = False
        Me.RITEActWorkdaysDW.DisplayFormat.FormatString = "N1"
        Me.RITEActWorkdaysDW.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.RITEActWorkdaysDW.Name = "RITEActWorkdaysDW"
        '
        'RICECheck
        '
        Me.RICECheck.AutoHeight = False
        Me.RICECheck.Name = "RICECheck"
        Me.RICECheck.ValueChecked = "yes"
        Me.RICECheck.ValueUnchecked = "no"
        '
        'RITEActWorkdays
        '
        Me.RITEActWorkdays.AutoHeight = False
        Me.RITEActWorkdays.DisplayFormat.FormatString = "N1"
        Me.RITEActWorkdays.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.RITEActWorkdays.Name = "RITEActWorkdays"
        '
        'RICESent
        '
        Me.RICESent.AutoHeight = False
        Me.RICESent.CheckStyle = DevExpress.XtraEditors.Controls.CheckStyles.UserDefined
        Me.RICESent.ImageIndexChecked = 19
        Me.RICESent.Name = "RICESent"
        Me.RICESent.ValueChecked = "yes"
        Me.RICESent.ValueUnchecked = "no"
        '
        'XrLabel5
        '
        Me.XrLabel5.Font = New System.Drawing.Font("Tahoma", 9.75!)
        Me.XrLabel5.LocationFloat = New DevExpress.Utils.PointFloat(0.0007311503!, 0!)
        Me.XrLabel5.Name = "XrLabel5"
        Me.XrLabel5.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel5.SizeF = New System.Drawing.SizeF(60.0!, 23.0!)
        Me.XrLabel5.StylePriority.UseFont = False
        Me.XrLabel5.StylePriority.UseTextAlignment = False
        Me.XrLabel5.Text = "Location"
        Me.XrLabel5.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
        '
        'XrLabel6
        '
        Me.XrLabel6.Font = New System.Drawing.Font("Tahoma", 9.75!)
        Me.XrLabel6.LocationFloat = New DevExpress.Utils.PointFloat(60.00071!, 0!)
        Me.XrLabel6.Name = "XrLabel6"
        Me.XrLabel6.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel6.SizeF = New System.Drawing.SizeF(15.0!, 23.0!)
        Me.XrLabel6.StylePriority.UseFont = False
        Me.XrLabel6.StylePriority.UseTextAlignment = False
        Me.XrLabel6.Text = ":"
        Me.XrLabel6.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
        '
        'XLLocationStore
        '
        Me.XLLocationStore.Font = New System.Drawing.Font("Tahoma", 9.75!)
        Me.XLLocationStore.LocationFloat = New DevExpress.Utils.PointFloat(75.00137!, 0!)
        Me.XLLocationStore.Name = "XLLocationStore"
        Me.XLLocationStore.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XLLocationStore.SizeF = New System.Drawing.SizeF(144.9993!, 23.0!)
        Me.XLLocationStore.StylePriority.UseFont = False
        Me.XLLocationStore.StylePriority.UseTextAlignment = False
        Me.XLLocationStore.Text = "Store"
        Me.XLLocationStore.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
        '
        'XrLabel2
        '
        Me.XrLabel2.Font = New System.Drawing.Font("Tahoma", 9.75!)
        Me.XrLabel2.LocationFloat = New DevExpress.Utils.PointFloat(0!, 0!)
        Me.XrLabel2.Name = "XrLabel2"
        Me.XrLabel2.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel2.SizeF = New System.Drawing.SizeF(60.0!, 23.0!)
        Me.XrLabel2.StylePriority.UseFont = False
        Me.XrLabel2.StylePriority.UseTextAlignment = False
        Me.XrLabel2.Text = "Location"
        Me.XrLabel2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
        '
        'XrLabel4
        '
        Me.XrLabel4.Font = New System.Drawing.Font("Tahoma", 9.75!)
        Me.XrLabel4.LocationFloat = New DevExpress.Utils.PointFloat(59.99997!, 0!)
        Me.XrLabel4.Name = "XrLabel4"
        Me.XrLabel4.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel4.SizeF = New System.Drawing.SizeF(15.0!, 23.0!)
        Me.XrLabel4.StylePriority.UseFont = False
        Me.XrLabel4.StylePriority.UseTextAlignment = False
        Me.XrLabel4.Text = ":"
        Me.XrLabel4.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
        '
        'XLLocationOffice
        '
        Me.XLLocationOffice.Font = New System.Drawing.Font("Tahoma", 9.75!)
        Me.XLLocationOffice.LocationFloat = New DevExpress.Utils.PointFloat(75.00063!, 0!)
        Me.XLLocationOffice.Name = "XLLocationOffice"
        Me.XLLocationOffice.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XLLocationOffice.SizeF = New System.Drawing.SizeF(144.9993!, 23.0!)
        Me.XLLocationOffice.StylePriority.UseFont = False
        Me.XLLocationOffice.StylePriority.UseTextAlignment = False
        Me.XLLocationOffice.Text = "Office"
        Me.XLLocationOffice.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
        '
        'WinControlContainer1
        '
        Me.WinControlContainer1.LocationFloat = New DevExpress.Utils.PointFloat(0.0007311503!, 28.0!)
        Me.WinControlContainer1.Name = "WinControlContainer1"
        Me.WinControlContainer1.SizeF = New System.Drawing.SizeF(1075.0!, 104.0!)
        Me.WinControlContainer1.WinControl = Me.GCPayrollOffice
        '
        'GCPayrollOffice
        '
        Me.GCPayrollOffice.Location = New System.Drawing.Point(0, 39)
        Me.GCPayrollOffice.MainView = Me.GVPayrollOffice
        Me.GCPayrollOffice.Name = "GCPayrollOffice"
        Me.GCPayrollOffice.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.RICEPending, Me.RICESelect})
        Me.GCPayrollOffice.Size = New System.Drawing.Size(1032, 100)
        Me.GCPayrollOffice.TabIndex = 1
        Me.GCPayrollOffice.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVPayrollOffice})
        '
        'GVPayrollOffice
        '
        Me.GVPayrollOffice.AppearancePrint.BandPanel.BackColor = System.Drawing.Color.White
        Me.GVPayrollOffice.AppearancePrint.BandPanel.BorderColor = System.Drawing.Color.Black
        Me.GVPayrollOffice.AppearancePrint.BandPanel.Font = New System.Drawing.Font("Tahoma", 7.25!, System.Drawing.FontStyle.Bold)
        Me.GVPayrollOffice.AppearancePrint.BandPanel.Options.UseBackColor = True
        Me.GVPayrollOffice.AppearancePrint.BandPanel.Options.UseBorderColor = True
        Me.GVPayrollOffice.AppearancePrint.BandPanel.Options.UseFont = True
        Me.GVPayrollOffice.AppearancePrint.FooterPanel.BackColor = System.Drawing.Color.White
        Me.GVPayrollOffice.AppearancePrint.FooterPanel.BorderColor = System.Drawing.Color.Black
        Me.GVPayrollOffice.AppearancePrint.FooterPanel.Font = New System.Drawing.Font("Tahoma", 7.25!)
        Me.GVPayrollOffice.AppearancePrint.FooterPanel.Options.UseBackColor = True
        Me.GVPayrollOffice.AppearancePrint.FooterPanel.Options.UseBorderColor = True
        Me.GVPayrollOffice.AppearancePrint.FooterPanel.Options.UseFont = True
        Me.GVPayrollOffice.AppearancePrint.GroupFooter.BackColor = System.Drawing.Color.White
        Me.GVPayrollOffice.AppearancePrint.GroupFooter.BorderColor = System.Drawing.Color.Black
        Me.GVPayrollOffice.AppearancePrint.GroupFooter.Font = New System.Drawing.Font("Tahoma", 7.25!)
        Me.GVPayrollOffice.AppearancePrint.GroupFooter.Options.UseBackColor = True
        Me.GVPayrollOffice.AppearancePrint.GroupFooter.Options.UseBorderColor = True
        Me.GVPayrollOffice.AppearancePrint.GroupFooter.Options.UseFont = True
        Me.GVPayrollOffice.AppearancePrint.GroupRow.BackColor = System.Drawing.Color.White
        Me.GVPayrollOffice.AppearancePrint.GroupRow.BorderColor = System.Drawing.Color.Black
        Me.GVPayrollOffice.AppearancePrint.GroupRow.Font = New System.Drawing.Font("Tahoma", 7.25!, System.Drawing.FontStyle.Bold)
        Me.GVPayrollOffice.AppearancePrint.GroupRow.Options.UseBackColor = True
        Me.GVPayrollOffice.AppearancePrint.GroupRow.Options.UseBorderColor = True
        Me.GVPayrollOffice.AppearancePrint.GroupRow.Options.UseFont = True
        Me.GVPayrollOffice.AppearancePrint.HeaderPanel.BackColor = System.Drawing.Color.White
        Me.GVPayrollOffice.AppearancePrint.HeaderPanel.BorderColor = System.Drawing.Color.Black
        Me.GVPayrollOffice.AppearancePrint.HeaderPanel.Font = New System.Drawing.Font("Tahoma", 7.25!, System.Drawing.FontStyle.Bold)
        Me.GVPayrollOffice.AppearancePrint.HeaderPanel.Options.UseBackColor = True
        Me.GVPayrollOffice.AppearancePrint.HeaderPanel.Options.UseBorderColor = True
        Me.GVPayrollOffice.AppearancePrint.HeaderPanel.Options.UseFont = True
        Me.GVPayrollOffice.AppearancePrint.Lines.BackColor = System.Drawing.Color.Black
        Me.GVPayrollOffice.AppearancePrint.Lines.Options.UseBackColor = True
        Me.GVPayrollOffice.AppearancePrint.Row.BackColor = System.Drawing.Color.White
        Me.GVPayrollOffice.AppearancePrint.Row.BorderColor = System.Drawing.Color.Black
        Me.GVPayrollOffice.AppearancePrint.Row.Font = New System.Drawing.Font("Tahoma", 7.25!)
        Me.GVPayrollOffice.AppearancePrint.Row.Options.UseBackColor = True
        Me.GVPayrollOffice.AppearancePrint.Row.Options.UseBorderColor = True
        Me.GVPayrollOffice.AppearancePrint.Row.Options.UseFont = True
        Me.GVPayrollOffice.BandPanelRowHeight = 16
        Me.GVPayrollOffice.Bands.AddRange(New DevExpress.XtraGrid.Views.BandedGrid.GridBand() {Me.GBEmployee, Me.GBWorkingDays, Me.GBDW, Me.GBTHR, Me.GBSalary, Me.GBGrandTotal})
        Me.GVPayrollOffice.ColumnPanelRowHeight = 32
        Me.GVPayrollOffice.Columns.AddRange(New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn() {Me.GCDepartement, Me.GCSubDepartement, Me.GCNIP, Me.GCName, Me.GCPosition, Me.GCStatus, Me.GCWorkingDays, Me.GCActualWorkingDays, Me.GCOvertimeHours, Me.GCTotalTHP, Me.GCTotalAdjustment, Me.GCTotalPaymentOvertime, Me.GCTotalDeduction, Me.GCActualWorkingDaysDW, Me.GCBasicSalaryDW, Me.GCTotalSalaryDW, Me.GCActualJoinDateTHR, Me.GCLengthOfWorkTHR, Me.GCTotalSalaryTHR, Me.GCGrandTotal})
        Me.GVPayrollOffice.GridControl = Me.GCPayrollOffice
        Me.GVPayrollOffice.GroupCount = 2
        Me.GVPayrollOffice.GroupFormat = "{1} {2}"
        Me.GVPayrollOffice.GroupSummary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Custom, "tot_thp", Me.GCTotalTHP, "{0:N2}"), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Custom, "total_adjustment", Me.GCTotalAdjustment, "{0:N2}"), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Custom, "total_deduction", Me.GCTotalDeduction, "{0:N2}"), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Custom, "total_ot_wages", Me.GCTotalPaymentOvertime, "{0:N2}"), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Custom, "grand_total", Me.GCGrandTotal, "{0:N0}"), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Custom, "total_salary_dw", Me.GCTotalSalaryDW, "{0:N0}"), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Custom, "employee_name", Me.GCName, "", ""), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Custom, "total_salary_thr", Me.GCTotalSalaryTHR, "{0:N0}")})
        Me.GVPayrollOffice.LevelIndent = 0
        Me.GVPayrollOffice.Name = "GVPayrollOffice"
        Me.GVPayrollOffice.OptionsBehavior.AutoExpandAllGroups = True
        Me.GVPayrollOffice.OptionsMenu.ShowConditionalFormattingItem = True
        Me.GVPayrollOffice.OptionsPrint.AllowMultilineHeaders = True
        Me.GVPayrollOffice.OptionsView.GroupFooterShowMode = DevExpress.XtraGrid.Views.Grid.GroupFooterShowMode.VisibleAlways
        Me.GVPayrollOffice.OptionsView.ShowFooter = True
        Me.GVPayrollOffice.OptionsView.ShowGroupPanel = False
        Me.GVPayrollOffice.SortInfo.AddRange(New DevExpress.XtraGrid.Columns.GridColumnSortInfo() {New DevExpress.XtraGrid.Columns.GridColumnSortInfo(Me.GCDepartement, DevExpress.Data.ColumnSortOrder.Ascending), New DevExpress.XtraGrid.Columns.GridColumnSortInfo(Me.GCSubDepartement, DevExpress.Data.ColumnSortOrder.Ascending)})
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
        Me.GCName.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
        Me.GCName.AppearanceCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
        Me.GCName.Caption = "Employee"
        Me.GCName.FieldName = "employee_name"
        Me.GCName.MinWidth = 195
        Me.GCName.Name = "GCName"
        Me.GCName.OptionsColumn.AllowEdit = False
        Me.GCName.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Custom)})
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
        'GBDW
        '
        Me.GBDW.Columns.Add(Me.GCActualWorkingDaysDW)
        Me.GBDW.Columns.Add(Me.GCBasicSalaryDW)
        Me.GBDW.Columns.Add(Me.GCTotalSalaryDW)
        Me.GBDW.Name = "GBDW"
        Me.GBDW.VisibleIndex = 2
        Me.GBDW.Width = 209
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
        'GCTotalSalaryDW
        '
        Me.GCTotalSalaryDW.Caption = "Total Salary"
        Me.GCTotalSalaryDW.DisplayFormat.FormatString = "N0"
        Me.GCTotalSalaryDW.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GCTotalSalaryDW.FieldName = "total_salary_dw"
        Me.GCTotalSalaryDW.Name = "GCTotalSalaryDW"
        Me.GCTotalSalaryDW.OptionsColumn.AllowEdit = False
        Me.GCTotalSalaryDW.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "total_salary_dw", "{0:N0}")})
        Me.GCTotalSalaryDW.Visible = True
        '
        'GBTHR
        '
        Me.GBTHR.Columns.Add(Me.GCActualJoinDateTHR)
        Me.GBTHR.Columns.Add(Me.GCLengthOfWorkTHR)
        Me.GBTHR.Columns.Add(Me.GCTotalSalaryTHR)
        Me.GBTHR.Name = "GBTHR"
        Me.GBTHR.VisibleIndex = 3
        Me.GBTHR.Width = 225
        '
        'GCActualJoinDateTHR
        '
        Me.GCActualJoinDateTHR.Caption = "Actual Join Date"
        Me.GCActualJoinDateTHR.FieldName = "employee_actual_join_date"
        Me.GCActualJoinDateTHR.Name = "GCActualJoinDateTHR"
        Me.GCActualJoinDateTHR.OptionsColumn.AllowEdit = False
        Me.GCActualJoinDateTHR.Visible = True
        '
        'GCLengthOfWorkTHR
        '
        Me.GCLengthOfWorkTHR.Caption = "Length of Work (Year)"
        Me.GCLengthOfWorkTHR.DisplayFormat.FormatString = "N2"
        Me.GCLengthOfWorkTHR.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GCLengthOfWorkTHR.FieldName = "actual_workdays"
        Me.GCLengthOfWorkTHR.Name = "GCLengthOfWorkTHR"
        Me.GCLengthOfWorkTHR.OptionsColumn.AllowEdit = False
        Me.GCLengthOfWorkTHR.Visible = True
        '
        'GCTotalSalaryTHR
        '
        Me.GCTotalSalaryTHR.Caption = "Total THR"
        Me.GCTotalSalaryTHR.DisplayFormat.FormatString = "N0"
        Me.GCTotalSalaryTHR.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GCTotalSalaryTHR.FieldName = "total_salary_thr"
        Me.GCTotalSalaryTHR.Name = "GCTotalSalaryTHR"
        Me.GCTotalSalaryTHR.OptionsColumn.AllowEdit = False
        Me.GCTotalSalaryTHR.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "total_salary_thr", "{0:N0}")})
        Me.GCTotalSalaryTHR.Visible = True
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
        Me.GBSalary.VisibleIndex = 4
        Me.GBSalary.Width = 232
        '
        'GCTotalTHP
        '
        Me.GCTotalTHP.AppearanceCell.Options.UseTextOptions = True
        Me.GCTotalTHP.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GCTotalTHP.Caption = "Total THP"
        Me.GCTotalTHP.DisplayFormat.FormatString = "N2"
        Me.GCTotalTHP.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GCTotalTHP.FieldName = "tot_thp"
        Me.GCTotalTHP.Name = "GCTotalTHP"
        Me.GCTotalTHP.OptionsColumn.AllowEdit = False
        Me.GCTotalTHP.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "tot_thp", "{0:N2}")})
        Me.GCTotalTHP.Visible = True
        Me.GCTotalTHP.Width = 57
        '
        'GCTotalAdjustment
        '
        Me.GCTotalAdjustment.AppearanceCell.Options.UseTextOptions = True
        Me.GCTotalAdjustment.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GCTotalAdjustment.Caption = "Total Bonus / Adj"
        Me.GCTotalAdjustment.DisplayFormat.FormatString = "N2"
        Me.GCTotalAdjustment.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GCTotalAdjustment.FieldName = "total_adjustment"
        Me.GCTotalAdjustment.Name = "GCTotalAdjustment"
        Me.GCTotalAdjustment.OptionsColumn.AllowEdit = False
        Me.GCTotalAdjustment.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "total_adjustment", "{0:N2}")})
        Me.GCTotalAdjustment.Visible = True
        Me.GCTotalAdjustment.Width = 57
        '
        'GCTotalPaymentOvertime
        '
        Me.GCTotalPaymentOvertime.AppearanceCell.Options.UseTextOptions = True
        Me.GCTotalPaymentOvertime.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GCTotalPaymentOvertime.Caption = "Total Overtime"
        Me.GCTotalPaymentOvertime.DisplayFormat.FormatString = "N2"
        Me.GCTotalPaymentOvertime.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GCTotalPaymentOvertime.FieldName = "total_ot_wages"
        Me.GCTotalPaymentOvertime.Name = "GCTotalPaymentOvertime"
        Me.GCTotalPaymentOvertime.OptionsColumn.AllowEdit = False
        Me.GCTotalPaymentOvertime.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "total_ot_wages", "{0:N2}")})
        Me.GCTotalPaymentOvertime.Visible = True
        Me.GCTotalPaymentOvertime.Width = 57
        '
        'GCTotalDeduction
        '
        Me.GCTotalDeduction.AppearanceCell.Options.UseTextOptions = True
        Me.GCTotalDeduction.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GCTotalDeduction.Caption = "Total Deduction"
        Me.GCTotalDeduction.DisplayFormat.FormatString = "N2"
        Me.GCTotalDeduction.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GCTotalDeduction.FieldName = "total_deduction"
        Me.GCTotalDeduction.Name = "GCTotalDeduction"
        Me.GCTotalDeduction.OptionsColumn.AllowEdit = False
        Me.GCTotalDeduction.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "total_deduction", "{0:N2}")})
        Me.GCTotalDeduction.Visible = True
        Me.GCTotalDeduction.Width = 61
        '
        'GBGrandTotal
        '
        Me.GBGrandTotal.Columns.Add(Me.GCGrandTotal)
        Me.GBGrandTotal.Name = "GBGrandTotal"
        Me.GBGrandTotal.VisibleIndex = 5
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
        Me.XrLabel1.LocationFloat = New DevExpress.Utils.PointFloat(855.0007!, 33.99998!)
        Me.XrLabel1.Name = "XrLabel1"
        Me.XrLabel1.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel1.SizeF = New System.Drawing.SizeF(40.0!, 23.0!)
        Me.XrLabel1.StylePriority.UseFont = False
        Me.XrLabel1.StylePriority.UseTextAlignment = False
        Me.XrLabel1.Text = "Type"
        Me.XrLabel1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
        '
        'XrLabel3
        '
        Me.XrLabel3.Font = New System.Drawing.Font("Tahoma", 9.75!)
        Me.XrLabel3.LocationFloat = New DevExpress.Utils.PointFloat(895.0008!, 33.99998!)
        Me.XrLabel3.Name = "XrLabel3"
        Me.XrLabel3.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel3.SizeF = New System.Drawing.SizeF(15.0!, 23.0!)
        Me.XrLabel3.StylePriority.UseFont = False
        Me.XrLabel3.StylePriority.UseTextAlignment = False
        Me.XrLabel3.Text = ":"
        Me.XrLabel3.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
        '
        'XLType
        '
        Me.XLType.Font = New System.Drawing.Font("Tahoma", 9.75!)
        Me.XLType.LocationFloat = New DevExpress.Utils.PointFloat(910.0008!, 33.99998!)
        Me.XLType.Name = "XLType"
        Me.XLType.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XLType.SizeF = New System.Drawing.SizeF(164.9997!, 23.0!)
        Me.XLType.StylePriority.UseFont = False
        Me.XLType.StylePriority.UseTextAlignment = False
        Me.XLType.Text = "[type]"
        Me.XLType.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
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
        Me.XLTitle.SizeF = New System.Drawing.SizeF(635.0002!, 41.15001!)
        Me.XLTitle.StylePriority.UseFont = False
        Me.XLTitle.StylePriority.UseTextAlignment = False
        Me.XLTitle.Text = "Monthly Payroll"
        Me.XLTitle.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        '
        'XLPeriod
        '
        Me.XLPeriod.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold)
        Me.XLPeriod.LocationFloat = New DevExpress.Utils.PointFloat(855.0008!, 10.99998!)
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
        Me.ReportHeader.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.XrLine1, Me.XLType, Me.XLTitle, Me.XLPeriod, Me.XrLabel3, Me.XrPictureBox1, Me.XrLabel1})
        Me.ReportHeader.HeightF = 100.0!
        Me.ReportHeader.Name = "ReportHeader"
        '
        'ReportFooter
        '
        Me.ReportFooter.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.XrPanel1})
        Me.ReportFooter.HeightF = 100.0!
        Me.ReportFooter.KeepTogether = True
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
        Me.XrTable1.LocationFloat = New DevExpress.Utils.PointFloat(0!, 0!)
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
        'RepositoryItemCheckEdit1
        '
        Me.RepositoryItemCheckEdit1.AutoHeight = False
        Me.RepositoryItemCheckEdit1.Name = "RepositoryItemCheckEdit1"
        Me.RepositoryItemCheckEdit1.ValueChecked = "yes"
        Me.RepositoryItemCheckEdit1.ValueUnchecked = "no"
        '
        'RepositoryItemCheckEdit2
        '
        Me.RepositoryItemCheckEdit2.AutoHeight = False
        Me.RepositoryItemCheckEdit2.Name = "RepositoryItemCheckEdit2"
        Me.RepositoryItemCheckEdit2.ValueChecked = "yes"
        Me.RepositoryItemCheckEdit2.ValueUnchecked = "no"
        '
        'BandedGridView1
        '
        Me.BandedGridView1.AppearancePrint.BandPanel.BackColor = System.Drawing.Color.White
        Me.BandedGridView1.AppearancePrint.BandPanel.BorderColor = System.Drawing.Color.Black
        Me.BandedGridView1.AppearancePrint.BandPanel.Font = New System.Drawing.Font("Tahoma", 7.25!, System.Drawing.FontStyle.Bold)
        Me.BandedGridView1.AppearancePrint.BandPanel.Options.UseBackColor = True
        Me.BandedGridView1.AppearancePrint.BandPanel.Options.UseBorderColor = True
        Me.BandedGridView1.AppearancePrint.BandPanel.Options.UseFont = True
        Me.BandedGridView1.AppearancePrint.FooterPanel.BackColor = System.Drawing.Color.White
        Me.BandedGridView1.AppearancePrint.FooterPanel.BorderColor = System.Drawing.Color.Black
        Me.BandedGridView1.AppearancePrint.FooterPanel.Font = New System.Drawing.Font("Tahoma", 7.25!)
        Me.BandedGridView1.AppearancePrint.FooterPanel.Options.UseBackColor = True
        Me.BandedGridView1.AppearancePrint.FooterPanel.Options.UseBorderColor = True
        Me.BandedGridView1.AppearancePrint.FooterPanel.Options.UseFont = True
        Me.BandedGridView1.AppearancePrint.GroupFooter.BackColor = System.Drawing.Color.White
        Me.BandedGridView1.AppearancePrint.GroupFooter.BorderColor = System.Drawing.Color.Black
        Me.BandedGridView1.AppearancePrint.GroupFooter.Font = New System.Drawing.Font("Tahoma", 7.25!)
        Me.BandedGridView1.AppearancePrint.GroupFooter.Options.UseBackColor = True
        Me.BandedGridView1.AppearancePrint.GroupFooter.Options.UseBorderColor = True
        Me.BandedGridView1.AppearancePrint.GroupFooter.Options.UseFont = True
        Me.BandedGridView1.AppearancePrint.GroupRow.BackColor = System.Drawing.Color.White
        Me.BandedGridView1.AppearancePrint.GroupRow.BorderColor = System.Drawing.Color.Black
        Me.BandedGridView1.AppearancePrint.GroupRow.Font = New System.Drawing.Font("Tahoma", 7.25!, System.Drawing.FontStyle.Bold)
        Me.BandedGridView1.AppearancePrint.GroupRow.Options.UseBackColor = True
        Me.BandedGridView1.AppearancePrint.GroupRow.Options.UseBorderColor = True
        Me.BandedGridView1.AppearancePrint.GroupRow.Options.UseFont = True
        Me.BandedGridView1.AppearancePrint.HeaderPanel.BackColor = System.Drawing.Color.White
        Me.BandedGridView1.AppearancePrint.HeaderPanel.BorderColor = System.Drawing.Color.Black
        Me.BandedGridView1.AppearancePrint.HeaderPanel.Font = New System.Drawing.Font("Tahoma", 7.25!, System.Drawing.FontStyle.Bold)
        Me.BandedGridView1.AppearancePrint.HeaderPanel.Options.UseBackColor = True
        Me.BandedGridView1.AppearancePrint.HeaderPanel.Options.UseBorderColor = True
        Me.BandedGridView1.AppearancePrint.HeaderPanel.Options.UseFont = True
        Me.BandedGridView1.AppearancePrint.Lines.BackColor = System.Drawing.Color.Black
        Me.BandedGridView1.AppearancePrint.Lines.Options.UseBackColor = True
        Me.BandedGridView1.AppearancePrint.Row.BackColor = System.Drawing.Color.White
        Me.BandedGridView1.AppearancePrint.Row.BorderColor = System.Drawing.Color.Black
        Me.BandedGridView1.AppearancePrint.Row.Font = New System.Drawing.Font("Tahoma", 7.25!)
        Me.BandedGridView1.AppearancePrint.Row.Options.UseBackColor = True
        Me.BandedGridView1.AppearancePrint.Row.Options.UseBorderColor = True
        Me.BandedGridView1.AppearancePrint.Row.Options.UseFont = True
        Me.BandedGridView1.BandPanelRowHeight = 16
        Me.BandedGridView1.Bands.AddRange(New DevExpress.XtraGrid.Views.BandedGrid.GridBand() {Me.GridBand1, Me.GridBand2, Me.GridBand3, Me.GridBand4, Me.GridBand5})
        Me.BandedGridView1.ColumnPanelRowHeight = 32
        Me.BandedGridView1.Columns.AddRange(New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn() {Me.BandedGridColumn3, Me.BandedGridColumn17, Me.BandedGridColumn1, Me.BandedGridColumn2, Me.BandedGridColumn4, Me.BandedGridColumn5, Me.BandedGridColumn6, Me.BandedGridColumn7, Me.BandedGridColumn8, Me.BandedGridColumn12, Me.BandedGridColumn13, Me.BandedGridColumn14, Me.BandedGridColumn15, Me.BandedGridColumn9, Me.BandedGridColumn10, Me.BandedGridColumn11, Me.BandedGridColumn16})
        Me.BandedGridView1.GroupCount = 2
        Me.BandedGridView1.GroupFormat = "{1} {2}"
        Me.BandedGridView1.GroupSummary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Custom, "tot_thp", Me.BandedGridColumn12, "{0:N0}"), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Custom, "total_adjustment", Me.BandedGridColumn13, "{0:N0}"), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Custom, "total_deduction", Me.BandedGridColumn15, "{0:N0}"), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Custom, "total_ot_wages", Me.BandedGridColumn14, "{0:N0}"), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Custom, "grand_total", Me.BandedGridColumn16, "{0:N0}"), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Custom, "total_salary_dw", Me.BandedGridColumn11, "{0:N0}"), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Custom, "employee_name", Me.BandedGridColumn2, "", "")})
        Me.BandedGridView1.LevelIndent = 0
        Me.BandedGridView1.Name = "BandedGridView1"
        Me.BandedGridView1.OptionsBehavior.AutoExpandAllGroups = True
        Me.BandedGridView1.OptionsMenu.ShowConditionalFormattingItem = True
        Me.BandedGridView1.OptionsPrint.AllowMultilineHeaders = True
        Me.BandedGridView1.OptionsView.GroupFooterShowMode = DevExpress.XtraGrid.Views.Grid.GroupFooterShowMode.VisibleAlways
        Me.BandedGridView1.OptionsView.ShowFooter = True
        Me.BandedGridView1.OptionsView.ShowGroupPanel = False
        Me.BandedGridView1.SortInfo.AddRange(New DevExpress.XtraGrid.Columns.GridColumnSortInfo() {New DevExpress.XtraGrid.Columns.GridColumnSortInfo(Me.BandedGridColumn3, DevExpress.Data.ColumnSortOrder.Ascending), New DevExpress.XtraGrid.Columns.GridColumnSortInfo(Me.BandedGridColumn17, DevExpress.Data.ColumnSortOrder.Ascending)})
        '
        'GridBand1
        '
        Me.GridBand1.Caption = "Employee"
        Me.GridBand1.Columns.Add(Me.BandedGridColumn1)
        Me.GridBand1.Columns.Add(Me.BandedGridColumn2)
        Me.GridBand1.Columns.Add(Me.BandedGridColumn3)
        Me.GridBand1.Columns.Add(Me.BandedGridColumn4)
        Me.GridBand1.Columns.Add(Me.BandedGridColumn5)
        Me.GridBand1.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left
        Me.GridBand1.Name = "GridBand1"
        Me.GridBand1.VisibleIndex = 0
        Me.GridBand1.Width = 512
        '
        'BandedGridColumn1
        '
        Me.BandedGridColumn1.Caption = "NIP"
        Me.BandedGridColumn1.FieldName = "employee_code"
        Me.BandedGridColumn1.MinWidth = 65
        Me.BandedGridColumn1.Name = "BandedGridColumn1"
        Me.BandedGridColumn1.OptionsColumn.AllowEdit = False
        Me.BandedGridColumn1.Visible = True
        Me.BandedGridColumn1.Width = 107
        '
        'BandedGridColumn2
        '
        Me.BandedGridColumn2.AppearanceCell.Options.UseTextOptions = True
        Me.BandedGridColumn2.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
        Me.BandedGridColumn2.AppearanceCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
        Me.BandedGridColumn2.Caption = "Employee"
        Me.BandedGridColumn2.FieldName = "employee_name"
        Me.BandedGridColumn2.MinWidth = 195
        Me.BandedGridColumn2.Name = "BandedGridColumn2"
        Me.BandedGridColumn2.OptionsColumn.AllowEdit = False
        Me.BandedGridColumn2.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Custom)})
        Me.BandedGridColumn2.Visible = True
        Me.BandedGridColumn2.Width = 195
        '
        'BandedGridColumn3
        '
        Me.BandedGridColumn3.Caption = "Departement"
        Me.BandedGridColumn3.FieldName = "departement"
        Me.BandedGridColumn3.Name = "BandedGridColumn3"
        Me.BandedGridColumn3.OptionsColumn.AllowEdit = False
        '
        'BandedGridColumn4
        '
        Me.BandedGridColumn4.AppearanceCell.Options.UseTextOptions = True
        Me.BandedGridColumn4.AppearanceCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
        Me.BandedGridColumn4.Caption = "Employee Position"
        Me.BandedGridColumn4.FieldName = "employee_position"
        Me.BandedGridColumn4.MinWidth = 150
        Me.BandedGridColumn4.Name = "BandedGridColumn4"
        Me.BandedGridColumn4.OptionsColumn.AllowEdit = False
        Me.BandedGridColumn4.Visible = True
        Me.BandedGridColumn4.Width = 150
        '
        'BandedGridColumn5
        '
        Me.BandedGridColumn5.Caption = "Employee Status"
        Me.BandedGridColumn5.FieldName = "employee_status"
        Me.BandedGridColumn5.MinWidth = 60
        Me.BandedGridColumn5.Name = "BandedGridColumn5"
        Me.BandedGridColumn5.OptionsColumn.AllowEdit = False
        Me.BandedGridColumn5.Visible = True
        Me.BandedGridColumn5.Width = 60
        '
        'GridBand2
        '
        Me.GridBand2.AppearanceHeader.Options.UseTextOptions = True
        Me.GridBand2.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridBand2.Caption = "Working Days (WD)"
        Me.GridBand2.Columns.Add(Me.BandedGridColumn6)
        Me.GridBand2.Columns.Add(Me.BandedGridColumn7)
        Me.GridBand2.Columns.Add(Me.BandedGridColumn8)
        Me.GridBand2.Name = "GridBand2"
        Me.GridBand2.VisibleIndex = 1
        Me.GridBand2.Width = 81
        '
        'BandedGridColumn6
        '
        Me.BandedGridColumn6.AppearanceCell.Options.UseTextOptions = True
        Me.BandedGridColumn6.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.BandedGridColumn6.Caption = "WD"
        Me.BandedGridColumn6.DisplayFormat.FormatString = "N1"
        Me.BandedGridColumn6.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.BandedGridColumn6.FieldName = "workdays"
        Me.BandedGridColumn6.Name = "BandedGridColumn6"
        Me.BandedGridColumn6.OptionsColumn.AllowEdit = False
        Me.BandedGridColumn6.Width = 35
        '
        'BandedGridColumn7
        '
        Me.BandedGridColumn7.AppearanceCell.Options.UseTextOptions = True
        Me.BandedGridColumn7.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.BandedGridColumn7.Caption = "Actual WD"
        Me.BandedGridColumn7.DisplayFormat.FormatString = "N1"
        Me.BandedGridColumn7.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.BandedGridColumn7.FieldName = "actual_workdays"
        Me.BandedGridColumn7.Name = "BandedGridColumn7"
        Me.BandedGridColumn7.OptionsColumn.AllowEdit = False
        Me.BandedGridColumn7.Visible = True
        Me.BandedGridColumn7.Width = 35
        '
        'BandedGridColumn8
        '
        Me.BandedGridColumn8.AppearanceCell.Options.UseTextOptions = True
        Me.BandedGridColumn8.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.BandedGridColumn8.Caption = "Overtime (Hours)"
        Me.BandedGridColumn8.DisplayFormat.FormatString = "N1"
        Me.BandedGridColumn8.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.BandedGridColumn8.FieldName = "total_ot_hour"
        Me.BandedGridColumn8.Name = "BandedGridColumn8"
        Me.BandedGridColumn8.OptionsColumn.AllowEdit = False
        Me.BandedGridColumn8.Visible = True
        Me.BandedGridColumn8.Width = 46
        '
        'GridBand3
        '
        Me.GridBand3.Columns.Add(Me.BandedGridColumn9)
        Me.GridBand3.Columns.Add(Me.BandedGridColumn10)
        Me.GridBand3.Columns.Add(Me.BandedGridColumn11)
        Me.GridBand3.Name = "GridBand3"
        Me.GridBand3.VisibleIndex = 2
        Me.GridBand3.Width = 209
        '
        'BandedGridColumn9
        '
        Me.BandedGridColumn9.AppearanceCell.Options.UseTextOptions = True
        Me.BandedGridColumn9.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.BandedGridColumn9.AppearanceCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
        Me.BandedGridColumn9.Caption = "Actual Working Days"
        Me.BandedGridColumn9.DisplayFormat.FormatString = "N1"
        Me.BandedGridColumn9.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.BandedGridColumn9.FieldName = "actual_workdays"
        Me.BandedGridColumn9.Name = "BandedGridColumn9"
        Me.BandedGridColumn9.OptionsColumn.AllowEdit = False
        Me.BandedGridColumn9.Visible = True
        Me.BandedGridColumn9.Width = 66
        '
        'BandedGridColumn10
        '
        Me.BandedGridColumn10.Caption = "Daily Salary"
        Me.BandedGridColumn10.DisplayFormat.FormatString = "N0"
        Me.BandedGridColumn10.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.BandedGridColumn10.FieldName = "basic_salary"
        Me.BandedGridColumn10.Name = "BandedGridColumn10"
        Me.BandedGridColumn10.OptionsColumn.AllowEdit = False
        Me.BandedGridColumn10.Visible = True
        Me.BandedGridColumn10.Width = 68
        '
        'BandedGridColumn11
        '
        Me.BandedGridColumn11.Caption = "Total Salary"
        Me.BandedGridColumn11.DisplayFormat.FormatString = "N0"
        Me.BandedGridColumn11.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.BandedGridColumn11.FieldName = "total_salary_dw"
        Me.BandedGridColumn11.Name = "BandedGridColumn11"
        Me.BandedGridColumn11.OptionsColumn.AllowEdit = False
        Me.BandedGridColumn11.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "total_salary_dw", "{0:N0}")})
        Me.BandedGridColumn11.Visible = True
        '
        'GridBand4
        '
        Me.GridBand4.AppearanceHeader.Options.UseTextOptions = True
        Me.GridBand4.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridBand4.Columns.Add(Me.BandedGridColumn12)
        Me.GridBand4.Columns.Add(Me.BandedGridColumn13)
        Me.GridBand4.Columns.Add(Me.BandedGridColumn14)
        Me.GridBand4.Columns.Add(Me.BandedGridColumn15)
        Me.GridBand4.Name = "GridBand4"
        Me.GridBand4.VisibleIndex = 3
        Me.GridBand4.Width = 232
        '
        'BandedGridColumn12
        '
        Me.BandedGridColumn12.AppearanceCell.Options.UseTextOptions = True
        Me.BandedGridColumn12.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.BandedGridColumn12.Caption = "Total THP"
        Me.BandedGridColumn12.DisplayFormat.FormatString = "N0"
        Me.BandedGridColumn12.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.BandedGridColumn12.FieldName = "tot_thp"
        Me.BandedGridColumn12.Name = "BandedGridColumn12"
        Me.BandedGridColumn12.OptionsColumn.AllowEdit = False
        Me.BandedGridColumn12.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "tot_thp", "{0:N0}")})
        Me.BandedGridColumn12.Visible = True
        Me.BandedGridColumn12.Width = 57
        '
        'BandedGridColumn13
        '
        Me.BandedGridColumn13.AppearanceCell.Options.UseTextOptions = True
        Me.BandedGridColumn13.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.BandedGridColumn13.Caption = "Total Bonus / Adj"
        Me.BandedGridColumn13.DisplayFormat.FormatString = "N0"
        Me.BandedGridColumn13.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.BandedGridColumn13.FieldName = "total_adjustment"
        Me.BandedGridColumn13.Name = "BandedGridColumn13"
        Me.BandedGridColumn13.OptionsColumn.AllowEdit = False
        Me.BandedGridColumn13.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "total_adjustment", "{0:N0}")})
        Me.BandedGridColumn13.Visible = True
        Me.BandedGridColumn13.Width = 57
        '
        'BandedGridColumn14
        '
        Me.BandedGridColumn14.AppearanceCell.Options.UseTextOptions = True
        Me.BandedGridColumn14.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.BandedGridColumn14.Caption = "Total Overtime"
        Me.BandedGridColumn14.DisplayFormat.FormatString = "N0"
        Me.BandedGridColumn14.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.BandedGridColumn14.FieldName = "total_ot_wages"
        Me.BandedGridColumn14.Name = "BandedGridColumn14"
        Me.BandedGridColumn14.OptionsColumn.AllowEdit = False
        Me.BandedGridColumn14.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "total_ot_wages", "{0:N0}")})
        Me.BandedGridColumn14.Visible = True
        Me.BandedGridColumn14.Width = 57
        '
        'BandedGridColumn15
        '
        Me.BandedGridColumn15.AppearanceCell.Options.UseTextOptions = True
        Me.BandedGridColumn15.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.BandedGridColumn15.Caption = "Total Deduction"
        Me.BandedGridColumn15.DisplayFormat.FormatString = "N0"
        Me.BandedGridColumn15.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.BandedGridColumn15.FieldName = "total_deduction"
        Me.BandedGridColumn15.Name = "BandedGridColumn15"
        Me.BandedGridColumn15.OptionsColumn.AllowEdit = False
        Me.BandedGridColumn15.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "total_deduction", "{0:N0}")})
        Me.BandedGridColumn15.Visible = True
        Me.BandedGridColumn15.Width = 61
        '
        'GridBand5
        '
        Me.GridBand5.Columns.Add(Me.BandedGridColumn16)
        Me.GridBand5.Name = "GridBand5"
        Me.GridBand5.VisibleIndex = 4
        Me.GridBand5.Width = 60
        '
        'BandedGridColumn16
        '
        Me.BandedGridColumn16.AppearanceCell.Options.UseTextOptions = True
        Me.BandedGridColumn16.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.BandedGridColumn16.Caption = "Grand Total"
        Me.BandedGridColumn16.DisplayFormat.FormatString = "N0"
        Me.BandedGridColumn16.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.BandedGridColumn16.FieldName = "grand_total"
        Me.BandedGridColumn16.Name = "BandedGridColumn16"
        Me.BandedGridColumn16.OptionsColumn.AllowEdit = False
        Me.BandedGridColumn16.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "grand_total", "{0:N0}")})
        Me.BandedGridColumn16.Visible = True
        Me.BandedGridColumn16.Width = 60
        '
        'BandedGridColumn17
        '
        Me.BandedGridColumn17.Caption = "Sub Departement"
        Me.BandedGridColumn17.FieldName = "departement_sub"
        Me.BandedGridColumn17.Name = "BandedGridColumn17"
        '
        'DetailReportOffice
        '
        Me.DetailReportOffice.Bands.AddRange(New DevExpress.XtraReports.UI.Band() {Me.DetailOffice})
        Me.DetailReportOffice.Level = 0
        Me.DetailReportOffice.Name = "DetailReportOffice"
        '
        'DetailOffice
        '
        Me.DetailOffice.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.WinControlContainer1, Me.XrLabel2, Me.XrLabel4, Me.XLLocationOffice})
        Me.DetailOffice.HeightF = 152.0!
        Me.DetailOffice.Name = "DetailOffice"
        '
        'DetailReportStore
        '
        Me.DetailReportStore.Bands.AddRange(New DevExpress.XtraReports.UI.Band() {Me.DetailStore})
        Me.DetailReportStore.Level = 1
        Me.DetailReportStore.Name = "DetailReportStore"
        Me.DetailReportStore.PageBreak = DevExpress.XtraReports.UI.PageBreak.BeforeBand
        '
        'DetailStore
        '
        Me.DetailStore.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.XrLabel5, Me.XLLocationStore, Me.XrLabel6, Me.WinControlContainer2})
        Me.DetailStore.HeightF = 152.0!
        Me.DetailStore.Name = "DetailStore"
        '
        'ReportPayrollAll
        '
        Me.Bands.AddRange(New DevExpress.XtraReports.UI.Band() {Me.Detail, Me.TopMargin, Me.BottomMargin, Me.ReportHeader, Me.ReportFooter, Me.DetailReportOffice, Me.DetailReportStore})
        Me.ComponentStorage.AddRange(New System.ComponentModel.IComponent() {Me.SqlDataSource1})
        Me.Landscape = True
        Me.Margins = New System.Drawing.Printing.Margins(25, 69, 50, 50)
        Me.PageHeight = 827
        Me.PageWidth = 1169
        Me.PaperKind = System.Drawing.Printing.PaperKind.A4
        Me.ScriptLanguage = DevExpress.XtraReports.ScriptLanguage.VisualBasic
        Me.Version = "15.1"
        Me.VerticalContentSplitting = DevExpress.XtraPrinting.VerticalContentSplitting.Smart
        CType(Me.GCPayrollStore, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVPayrollStore, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemCheckEdit3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RITEActWorkdaysDW, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RICECheck, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RITEActWorkdays, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RICESent, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GCPayrollOffice, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVPayrollOffice, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RICEPending, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RICESelect, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.XrTable1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemCheckEdit1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemCheckEdit2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BandedGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me, System.ComponentModel.ISupportInitialize).EndInit()

    End Sub
    Friend WithEvents Detail As DevExpress.XtraReports.UI.DetailBand
    Friend WithEvents TopMargin As DevExpress.XtraReports.UI.TopMarginBand
    Friend WithEvents BottomMargin As DevExpress.XtraReports.UI.BottomMarginBand
    Friend WithEvents SqlDataSource1 As DevExpress.DataAccess.Sql.SqlDataSource
    Friend WithEvents WinControlContainer1 As DevExpress.XtraReports.UI.WinControlContainer
    Friend WithEvents GCPayrollOffice As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVPayrollOffice As DevExpress.XtraGrid.Views.BandedGrid.BandedGridView
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
    Friend WithEvents XLType As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel3 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel1 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents ReportHeader As DevExpress.XtraReports.UI.ReportHeaderBand
    Friend WithEvents ReportFooter As DevExpress.XtraReports.UI.ReportFooterBand
    Friend WithEvents XrPanel1 As DevExpress.XtraReports.UI.XRPanel
    Friend WithEvents XrTable1 As DevExpress.XtraReports.UI.XRTable
    Friend WithEvents XrTableRow1 As DevExpress.XtraReports.UI.XRTableRow
    Friend WithEvents XrTableCell13 As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents GCSubDepartement As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents GCTotalSalaryDW As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents XLLocationOffice As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel4 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel2 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel5 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel6 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XLLocationStore As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents RepositoryItemCheckEdit1 As DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit
    Friend WithEvents RepositoryItemCheckEdit2 As DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit
    Friend WithEvents BandedGridView1 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridView
    Friend WithEvents GridBand1 As DevExpress.XtraGrid.Views.BandedGrid.GridBand
    Friend WithEvents BandedGridColumn1 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumn2 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumn3 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumn4 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumn5 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents GridBand2 As DevExpress.XtraGrid.Views.BandedGrid.GridBand
    Friend WithEvents BandedGridColumn6 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumn7 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumn8 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents GridBand3 As DevExpress.XtraGrid.Views.BandedGrid.GridBand
    Friend WithEvents BandedGridColumn9 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumn10 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumn11 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents GridBand4 As DevExpress.XtraGrid.Views.BandedGrid.GridBand
    Friend WithEvents BandedGridColumn12 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumn13 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumn14 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumn15 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents GridBand5 As DevExpress.XtraGrid.Views.BandedGrid.GridBand
    Friend WithEvents BandedGridColumn16 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumn17 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents WinControlContainer2 As DevExpress.XtraReports.UI.WinControlContainer
    Friend WithEvents GCPayrollStore As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVPayrollStore As DevExpress.XtraGrid.Views.BandedGrid.BandedGridView
    Friend WithEvents RICECheck As DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit
    Friend WithEvents RICESent As DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit
    Friend WithEvents RITEActWorkdays As DevExpress.XtraEditors.Repository.RepositoryItemTextEdit
    Friend WithEvents RITEActWorkdaysDW As DevExpress.XtraEditors.Repository.RepositoryItemTextEdit
    Friend WithEvents RepositoryItemCheckEdit3 As DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit
    Friend WithEvents GCNIPStore As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents GCNameStore As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents GCDepartementStore As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents GCPositionStore As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents GCStatusStore As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents GCWorkingDaysStore As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents GCActualWorkingDaysStore As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents GCOvertimeHoursStore As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents GCActualWorkingDaysDWStore As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents GCBasicSalaryDWStore As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents GCTotalSalaryDWStore As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents GCTotalTHPStore As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents GCTotalAdjustmentStore As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents GCTotalPaymentOvertimeStore As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents GCTotalDeductionStore As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents GCGrandTotalStore As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents GCSubDepartementStore As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents DetailReportOffice As DevExpress.XtraReports.UI.DetailReportBand
    Friend WithEvents DetailOffice As DevExpress.XtraReports.UI.DetailBand
    Friend WithEvents DetailReportStore As DevExpress.XtraReports.UI.DetailReportBand
    Friend WithEvents DetailStore As DevExpress.XtraReports.UI.DetailBand
    Friend WithEvents GCActualJoinDateTHR As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents GCLengthOfWorkTHR As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents GCTotalSalaryTHR As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents GBEmployee As DevExpress.XtraGrid.Views.BandedGrid.GridBand
    Friend WithEvents GBWorkingDays As DevExpress.XtraGrid.Views.BandedGrid.GridBand
    Friend WithEvents GBDW As DevExpress.XtraGrid.Views.BandedGrid.GridBand
    Friend WithEvents GBTHR As DevExpress.XtraGrid.Views.BandedGrid.GridBand
    Friend WithEvents GBSalary As DevExpress.XtraGrid.Views.BandedGrid.GridBand
    Friend WithEvents GBGrandTotal As DevExpress.XtraGrid.Views.BandedGrid.GridBand
    Friend WithEvents GBEmployeeStore As DevExpress.XtraGrid.Views.BandedGrid.GridBand
    Friend WithEvents GBWorkingDaysStore As DevExpress.XtraGrid.Views.BandedGrid.GridBand
    Friend WithEvents GBDWStore As DevExpress.XtraGrid.Views.BandedGrid.GridBand
    Friend WithEvents GBTHRStore As DevExpress.XtraGrid.Views.BandedGrid.GridBand
    Friend WithEvents GCActualJoinDateTHRStore As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents GCLengthOfWorkTHRStore As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents GCTotalSalaryTHRStore As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents GBSalaryStore As DevExpress.XtraGrid.Views.BandedGrid.GridBand
    Friend WithEvents GBGrandTotalStore As DevExpress.XtraGrid.Views.BandedGrid.GridBand
End Class
