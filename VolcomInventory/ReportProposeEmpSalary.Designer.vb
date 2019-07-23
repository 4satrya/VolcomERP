<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Public Class ReportProposeEmpSalary
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ReportProposeEmpSalary))
        Me.Detail = New DevExpress.XtraReports.UI.DetailBand()
        Me.WinControlContainer1 = New DevExpress.XtraReports.UI.WinControlContainer()
        Me.GCEmployee = New DevExpress.XtraGrid.GridControl()
        Me.GVEmployee = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridView()
        Me.GBEmployee = New DevExpress.XtraGrid.Views.BandedGrid.GridBand()
        Me.GCEmployeeId = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.GCNIP = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.GCName = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.GCIdDepartement = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.GCDepartement = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.GCPosition = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.GCEmployeeStatus = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.GCIdEmployeeLevel = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.GCLevel = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.GCIdEmployeeStatus = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.GBSalary = New DevExpress.XtraGrid.Views.BandedGrid.GridBand()
        Me.GCBasicSalary = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.RITESalary = New DevExpress.XtraEditors.Repository.RepositoryItemTextEdit()
        Me.GCJobAllowance = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.GCMealAllowance = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.GCTransportAllowance = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.GCHouseAllowance = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.GCAttendanceAllowance = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.GCTotalSalary = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.GBComposition = New DevExpress.XtraGrid.Views.BandedGrid.GridBand()
        Me.GCFixedSalary = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.GCNonFixedSalary = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.TopMargin = New DevExpress.XtraReports.UI.TopMarginBand()
        Me.XrPictureBox1 = New DevExpress.XtraReports.UI.XRPictureBox()
        Me.XrLabel2 = New DevExpress.XtraReports.UI.XRLabel()
        Me.XLNumber = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLine1 = New DevExpress.XtraReports.UI.XRLine()
        Me.BottomMargin = New DevExpress.XtraReports.UI.BottomMarginBand()
        Me.XrPageInfo1 = New DevExpress.XtraReports.UI.XRPageInfo()
        Me.ReportHeader = New DevExpress.XtraReports.UI.ReportHeaderBand()
        Me.XLEffectiveDate = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLabel4 = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLabel3 = New DevExpress.XtraReports.UI.XRLabel()
        Me.ReportFooter = New DevExpress.XtraReports.UI.ReportFooterBand()
        Me.XrTable1 = New DevExpress.XtraReports.UI.XRTable()
        Me.XrTableRow1 = New DevExpress.XtraReports.UI.XRTableRow()
        Me.XrTableCell1 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.XLNote = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLabel7 = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLabel6 = New DevExpress.XtraReports.UI.XRLabel()
        CType(Me.GCEmployee, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVEmployee, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RITESalary, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.XrTable1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
        '
        'Detail
        '
        Me.Detail.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.WinControlContainer1})
        Me.Detail.HeightF = 228.0!
        Me.Detail.Name = "Detail"
        Me.Detail.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
        Me.Detail.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
        '
        'WinControlContainer1
        '
        Me.WinControlContainer1.LocationFloat = New DevExpress.Utils.PointFloat(0!, 10.00001!)
        Me.WinControlContainer1.Name = "WinControlContainer1"
        Me.WinControlContainer1.SizeF = New System.Drawing.SizeF(1069.0!, 208.0!)
        Me.WinControlContainer1.WinControl = Me.GCEmployee
        '
        'GCEmployee
        '
        Me.GCEmployee.Location = New System.Drawing.Point(0, 121)
        Me.GCEmployee.MainView = Me.GVEmployee
        Me.GCEmployee.Name = "GCEmployee"
        Me.GCEmployee.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.RITESalary})
        Me.GCEmployee.Size = New System.Drawing.Size(1026, 200)
        Me.GCEmployee.TabIndex = 3
        Me.GCEmployee.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVEmployee})
        '
        'GVEmployee
        '
        Me.GVEmployee.AppearancePrint.BandPanel.BackColor = System.Drawing.Color.White
        Me.GVEmployee.AppearancePrint.BandPanel.BorderColor = System.Drawing.Color.Black
        Me.GVEmployee.AppearancePrint.BandPanel.Font = New System.Drawing.Font("Tahoma", 7.25!, System.Drawing.FontStyle.Bold)
        Me.GVEmployee.AppearancePrint.BandPanel.Options.UseBackColor = True
        Me.GVEmployee.AppearancePrint.BandPanel.Options.UseBorderColor = True
        Me.GVEmployee.AppearancePrint.BandPanel.Options.UseFont = True
        Me.GVEmployee.AppearancePrint.FooterPanel.BackColor = System.Drawing.Color.White
        Me.GVEmployee.AppearancePrint.FooterPanel.BorderColor = System.Drawing.Color.Black
        Me.GVEmployee.AppearancePrint.FooterPanel.Font = New System.Drawing.Font("Tahoma", 7.25!)
        Me.GVEmployee.AppearancePrint.FooterPanel.ForeColor = System.Drawing.Color.Black
        Me.GVEmployee.AppearancePrint.FooterPanel.Options.UseBackColor = True
        Me.GVEmployee.AppearancePrint.FooterPanel.Options.UseBorderColor = True
        Me.GVEmployee.AppearancePrint.FooterPanel.Options.UseFont = True
        Me.GVEmployee.AppearancePrint.FooterPanel.Options.UseForeColor = True
        Me.GVEmployee.AppearancePrint.GroupFooter.BackColor = System.Drawing.Color.White
        Me.GVEmployee.AppearancePrint.GroupFooter.BorderColor = System.Drawing.Color.Black
        Me.GVEmployee.AppearancePrint.GroupFooter.Font = New System.Drawing.Font("Tahoma", 7.25!)
        Me.GVEmployee.AppearancePrint.GroupFooter.ForeColor = System.Drawing.Color.Black
        Me.GVEmployee.AppearancePrint.GroupFooter.Options.UseBackColor = True
        Me.GVEmployee.AppearancePrint.GroupFooter.Options.UseBorderColor = True
        Me.GVEmployee.AppearancePrint.GroupFooter.Options.UseFont = True
        Me.GVEmployee.AppearancePrint.GroupFooter.Options.UseForeColor = True
        Me.GVEmployee.AppearancePrint.GroupRow.BackColor = System.Drawing.Color.White
        Me.GVEmployee.AppearancePrint.GroupRow.BorderColor = System.Drawing.Color.Black
        Me.GVEmployee.AppearancePrint.GroupRow.Font = New System.Drawing.Font("Tahoma", 7.25!, System.Drawing.FontStyle.Bold)
        Me.GVEmployee.AppearancePrint.GroupRow.ForeColor = System.Drawing.Color.Black
        Me.GVEmployee.AppearancePrint.GroupRow.Options.UseBackColor = True
        Me.GVEmployee.AppearancePrint.GroupRow.Options.UseBorderColor = True
        Me.GVEmployee.AppearancePrint.GroupRow.Options.UseFont = True
        Me.GVEmployee.AppearancePrint.GroupRow.Options.UseForeColor = True
        Me.GVEmployee.AppearancePrint.HeaderPanel.BackColor = System.Drawing.Color.White
        Me.GVEmployee.AppearancePrint.HeaderPanel.BorderColor = System.Drawing.Color.Black
        Me.GVEmployee.AppearancePrint.HeaderPanel.Font = New System.Drawing.Font("Tahoma", 7.25!, System.Drawing.FontStyle.Bold)
        Me.GVEmployee.AppearancePrint.HeaderPanel.ForeColor = System.Drawing.Color.Black
        Me.GVEmployee.AppearancePrint.HeaderPanel.Options.UseBackColor = True
        Me.GVEmployee.AppearancePrint.HeaderPanel.Options.UseBorderColor = True
        Me.GVEmployee.AppearancePrint.HeaderPanel.Options.UseFont = True
        Me.GVEmployee.AppearancePrint.HeaderPanel.Options.UseForeColor = True
        Me.GVEmployee.AppearancePrint.Row.BackColor = System.Drawing.Color.White
        Me.GVEmployee.AppearancePrint.Row.BorderColor = System.Drawing.Color.Black
        Me.GVEmployee.AppearancePrint.Row.Font = New System.Drawing.Font("Tahoma", 7.25!)
        Me.GVEmployee.AppearancePrint.Row.ForeColor = System.Drawing.Color.Black
        Me.GVEmployee.AppearancePrint.Row.Options.UseBackColor = True
        Me.GVEmployee.AppearancePrint.Row.Options.UseBorderColor = True
        Me.GVEmployee.AppearancePrint.Row.Options.UseFont = True
        Me.GVEmployee.AppearancePrint.Row.Options.UseForeColor = True
        Me.GVEmployee.Bands.AddRange(New DevExpress.XtraGrid.Views.BandedGrid.GridBand() {Me.GBEmployee, Me.GBSalary, Me.GBComposition})
        Me.GVEmployee.ColumnPanelRowHeight = 32
        Me.GVEmployee.Columns.AddRange(New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn() {Me.GCEmployeeId, Me.GCNIP, Me.GCName, Me.GCIdDepartement, Me.GCDepartement, Me.GCPosition, Me.GCIdEmployeeLevel, Me.GCLevel, Me.GCIdEmployeeStatus, Me.GCEmployeeStatus, Me.GCBasicSalary, Me.GCJobAllowance, Me.GCMealAllowance, Me.GCTransportAllowance, Me.GCHouseAllowance, Me.GCAttendanceAllowance, Me.GCTotalSalary, Me.GCFixedSalary, Me.GCNonFixedSalary})
        Me.GVEmployee.GridControl = Me.GCEmployee
        Me.GVEmployee.GroupCount = 1
        Me.GVEmployee.GroupSummary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "basic_salary", Me.GCBasicSalary, "{0:N0}"), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "allow_job", Me.GCJobAllowance, "{0:N0}"), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "allow_meal", Me.GCMealAllowance, "{0:N0}"), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "allow_trans", Me.GCTransportAllowance, "{0:N0}"), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "allow_house", Me.GCHouseAllowance, "{0:N0}"), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "allow_car", Me.GCAttendanceAllowance, "{0:N0}"), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "total_salary", Me.GCTotalSalary, "{0:N0}")})
        Me.GVEmployee.Name = "GVEmployee"
        Me.GVEmployee.OptionsBehavior.AutoExpandAllGroups = True
        Me.GVEmployee.OptionsFind.AlwaysVisible = True
        Me.GVEmployee.OptionsPrint.AllowMultilineHeaders = True
        Me.GVEmployee.OptionsView.ColumnAutoWidth = False
        Me.GVEmployee.OptionsView.ShowFooter = True
        Me.GVEmployee.OptionsView.ShowGroupPanel = False
        Me.GVEmployee.SortInfo.AddRange(New DevExpress.XtraGrid.Columns.GridColumnSortInfo() {New DevExpress.XtraGrid.Columns.GridColumnSortInfo(Me.GCDepartement, DevExpress.Data.ColumnSortOrder.Ascending)})
        '
        'GBEmployee
        '
        Me.GBEmployee.Caption = "Employee"
        Me.GBEmployee.Columns.Add(Me.GCEmployeeId)
        Me.GBEmployee.Columns.Add(Me.GCNIP)
        Me.GBEmployee.Columns.Add(Me.GCName)
        Me.GBEmployee.Columns.Add(Me.GCIdDepartement)
        Me.GBEmployee.Columns.Add(Me.GCDepartement)
        Me.GBEmployee.Columns.Add(Me.GCPosition)
        Me.GBEmployee.Columns.Add(Me.GCEmployeeStatus)
        Me.GBEmployee.Columns.Add(Me.GCIdEmployeeLevel)
        Me.GBEmployee.Columns.Add(Me.GCLevel)
        Me.GBEmployee.Columns.Add(Me.GCIdEmployeeStatus)
        Me.GBEmployee.Name = "GBEmployee"
        Me.GBEmployee.VisibleIndex = 0
        Me.GBEmployee.Width = 425
        '
        'GCEmployeeId
        '
        Me.GCEmployeeId.FieldName = "id_employee"
        Me.GCEmployeeId.Name = "GCEmployeeId"
        Me.GCEmployeeId.OptionsColumn.AllowEdit = False
        '
        'GCNIP
        '
        Me.GCNIP.Caption = "NIP"
        Me.GCNIP.FieldName = "employee_code"
        Me.GCNIP.Name = "GCNIP"
        Me.GCNIP.OptionsColumn.AllowEdit = False
        Me.GCNIP.Visible = True
        '
        'GCName
        '
        Me.GCName.AppearanceCell.Options.UseTextOptions = True
        Me.GCName.AppearanceCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
        Me.GCName.Caption = "Name"
        Me.GCName.FieldName = "employee_name"
        Me.GCName.MinWidth = 175
        Me.GCName.Name = "GCName"
        Me.GCName.OptionsColumn.AllowEdit = False
        Me.GCName.Visible = True
        Me.GCName.Width = 175
        '
        'GCIdDepartement
        '
        Me.GCIdDepartement.FieldName = "id_departement"
        Me.GCIdDepartement.Name = "GCIdDepartement"
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
        Me.GCPosition.Caption = "Position"
        Me.GCPosition.FieldName = "employee_position"
        Me.GCPosition.Name = "GCPosition"
        Me.GCPosition.OptionsColumn.AllowEdit = False
        Me.GCPosition.Visible = True
        '
        'GCEmployeeStatus
        '
        Me.GCEmployeeStatus.AppearanceHeader.Options.UseTextOptions = True
        Me.GCEmployeeStatus.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
        Me.GCEmployeeStatus.Caption = "Employee Status"
        Me.GCEmployeeStatus.FieldName = "employee_status"
        Me.GCEmployeeStatus.Name = "GCEmployeeStatus"
        Me.GCEmployeeStatus.OptionsColumn.AllowEdit = False
        Me.GCEmployeeStatus.Visible = True
        Me.GCEmployeeStatus.Width = 100
        '
        'GCIdEmployeeLevel
        '
        Me.GCIdEmployeeLevel.FieldName = "id_employee_level"
        Me.GCIdEmployeeLevel.Name = "GCIdEmployeeLevel"
        '
        'GCLevel
        '
        Me.GCLevel.AppearanceCell.Options.UseTextOptions = True
        Me.GCLevel.AppearanceCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
        Me.GCLevel.Caption = "Level"
        Me.GCLevel.FieldName = "employee_level"
        Me.GCLevel.Name = "GCLevel"
        Me.GCLevel.OptionsColumn.AllowEdit = False
        '
        'GCIdEmployeeStatus
        '
        Me.GCIdEmployeeStatus.FieldName = "id_employee_status"
        Me.GCIdEmployeeStatus.Name = "GCIdEmployeeStatus"
        '
        'GBSalary
        '
        Me.GBSalary.Caption = "Salary"
        Me.GBSalary.Columns.Add(Me.GCBasicSalary)
        Me.GBSalary.Columns.Add(Me.GCJobAllowance)
        Me.GBSalary.Columns.Add(Me.GCMealAllowance)
        Me.GBSalary.Columns.Add(Me.GCTransportAllowance)
        Me.GBSalary.Columns.Add(Me.GCHouseAllowance)
        Me.GBSalary.Columns.Add(Me.GCAttendanceAllowance)
        Me.GBSalary.Columns.Add(Me.GCTotalSalary)
        Me.GBSalary.Name = "GBSalary"
        Me.GBSalary.VisibleIndex = 1
        Me.GBSalary.Width = 619
        '
        'GCBasicSalary
        '
        Me.GCBasicSalary.AppearanceHeader.Options.UseTextOptions = True
        Me.GCBasicSalary.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
        Me.GCBasicSalary.Caption = "Basic Salary"
        Me.GCBasicSalary.ColumnEdit = Me.RITESalary
        Me.GCBasicSalary.DisplayFormat.FormatString = "N0"
        Me.GCBasicSalary.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GCBasicSalary.FieldName = "basic_salary"
        Me.GCBasicSalary.Name = "GCBasicSalary"
        Me.GCBasicSalary.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "basic_salary", "{0:N0}")})
        Me.GCBasicSalary.Visible = True
        Me.GCBasicSalary.Width = 67
        '
        'RITESalary
        '
        Me.RITESalary.AutoHeight = False
        Me.RITESalary.Name = "RITESalary"
        '
        'GCJobAllowance
        '
        Me.GCJobAllowance.AppearanceHeader.Options.UseTextOptions = True
        Me.GCJobAllowance.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
        Me.GCJobAllowance.Caption = "Job Allowance"
        Me.GCJobAllowance.ColumnEdit = Me.RITESalary
        Me.GCJobAllowance.DisplayFormat.FormatString = "N0"
        Me.GCJobAllowance.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GCJobAllowance.FieldName = "allow_job"
        Me.GCJobAllowance.Name = "GCJobAllowance"
        Me.GCJobAllowance.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "allow_job", "{0:N0}")})
        Me.GCJobAllowance.Visible = True
        Me.GCJobAllowance.Width = 78
        '
        'GCMealAllowance
        '
        Me.GCMealAllowance.AppearanceHeader.Options.UseTextOptions = True
        Me.GCMealAllowance.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
        Me.GCMealAllowance.Caption = "Meal Allowance"
        Me.GCMealAllowance.ColumnEdit = Me.RITESalary
        Me.GCMealAllowance.DisplayFormat.FormatString = "N0"
        Me.GCMealAllowance.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GCMealAllowance.FieldName = "allow_meal"
        Me.GCMealAllowance.Name = "GCMealAllowance"
        Me.GCMealAllowance.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "allow_meal", "{0:N0}")})
        Me.GCMealAllowance.Visible = True
        Me.GCMealAllowance.Width = 83
        '
        'GCTransportAllowance
        '
        Me.GCTransportAllowance.AppearanceHeader.Options.UseTextOptions = True
        Me.GCTransportAllowance.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
        Me.GCTransportAllowance.Caption = "Transport Allowance"
        Me.GCTransportAllowance.ColumnEdit = Me.RITESalary
        Me.GCTransportAllowance.DisplayFormat.FormatString = "N0"
        Me.GCTransportAllowance.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GCTransportAllowance.FieldName = "allow_trans"
        Me.GCTransportAllowance.Name = "GCTransportAllowance"
        Me.GCTransportAllowance.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "allow_trans", "{0:N0}")})
        Me.GCTransportAllowance.Visible = True
        Me.GCTransportAllowance.Width = 108
        '
        'GCHouseAllowance
        '
        Me.GCHouseAllowance.AppearanceHeader.Options.UseTextOptions = True
        Me.GCHouseAllowance.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
        Me.GCHouseAllowance.Caption = "House Allowance"
        Me.GCHouseAllowance.ColumnEdit = Me.RITESalary
        Me.GCHouseAllowance.DisplayFormat.FormatString = "N0"
        Me.GCHouseAllowance.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GCHouseAllowance.FieldName = "allow_house"
        Me.GCHouseAllowance.Name = "GCHouseAllowance"
        Me.GCHouseAllowance.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "allow_house", "{0:N0}")})
        Me.GCHouseAllowance.Visible = True
        Me.GCHouseAllowance.Width = 91
        '
        'GCAttendanceAllowance
        '
        Me.GCAttendanceAllowance.AppearanceHeader.Options.UseTextOptions = True
        Me.GCAttendanceAllowance.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
        Me.GCAttendanceAllowance.Caption = "Attendance Allowance"
        Me.GCAttendanceAllowance.ColumnEdit = Me.RITESalary
        Me.GCAttendanceAllowance.DisplayFormat.FormatString = "N0"
        Me.GCAttendanceAllowance.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GCAttendanceAllowance.FieldName = "allow_car"
        Me.GCAttendanceAllowance.Name = "GCAttendanceAllowance"
        Me.GCAttendanceAllowance.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "allow_car", "{0:N0}")})
        Me.GCAttendanceAllowance.Visible = True
        Me.GCAttendanceAllowance.Width = 117
        '
        'GCTotalSalary
        '
        Me.GCTotalSalary.AppearanceHeader.Options.UseTextOptions = True
        Me.GCTotalSalary.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
        Me.GCTotalSalary.Caption = "Total Salary"
        Me.GCTotalSalary.DisplayFormat.FormatString = "N0"
        Me.GCTotalSalary.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GCTotalSalary.FieldName = "total_salary"
        Me.GCTotalSalary.Name = "GCTotalSalary"
        Me.GCTotalSalary.OptionsColumn.AllowEdit = False
        Me.GCTotalSalary.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "total_salary", "{0:N0}")})
        Me.GCTotalSalary.UnboundExpression = "[basic_salary] + [allow_job] + [allow_meal] + [allow_trans] + [allow_house] + [al" &
    "low_car]"
        Me.GCTotalSalary.UnboundType = DevExpress.Data.UnboundColumnType.[Integer]
        Me.GCTotalSalary.Visible = True
        '
        'GBComposition
        '
        Me.GBComposition.Caption = "Composition"
        Me.GBComposition.Columns.Add(Me.GCFixedSalary)
        Me.GBComposition.Columns.Add(Me.GCNonFixedSalary)
        Me.GBComposition.Name = "GBComposition"
        Me.GBComposition.VisibleIndex = 2
        Me.GBComposition.Width = 150
        '
        'GCFixedSalary
        '
        Me.GCFixedSalary.AppearanceCell.Options.UseTextOptions = True
        Me.GCFixedSalary.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GCFixedSalary.Caption = "Fixed Salary"
        Me.GCFixedSalary.FieldName = "fixed_salary"
        Me.GCFixedSalary.Name = "GCFixedSalary"
        Me.GCFixedSalary.Visible = True
        '
        'GCNonFixedSalary
        '
        Me.GCNonFixedSalary.AppearanceCell.Options.UseTextOptions = True
        Me.GCNonFixedSalary.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GCNonFixedSalary.Caption = "Non-fixed Salary"
        Me.GCNonFixedSalary.FieldName = "non_fixed_salary"
        Me.GCNonFixedSalary.Name = "GCNonFixedSalary"
        Me.GCNonFixedSalary.Visible = True
        '
        'TopMargin
        '
        Me.TopMargin.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.XrPictureBox1, Me.XrLabel2, Me.XLNumber, Me.XrLine1})
        Me.TopMargin.HeightF = 71.15001!
        Me.TopMargin.Name = "TopMargin"
        Me.TopMargin.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
        Me.TopMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
        '
        'XrPictureBox1
        '
        Me.XrPictureBox1.AnchorHorizontal = DevExpress.XtraReports.UI.HorizontalAnchorStyles.Left
        Me.XrPictureBox1.Image = CType(resources.GetObject("XrPictureBox1.Image"), System.Drawing.Image)
        Me.XrPictureBox1.LocationFloat = New DevExpress.Utils.PointFloat(0!, 10.0!)
        Me.XrPictureBox1.Name = "XrPictureBox1"
        Me.XrPictureBox1.SizeF = New System.Drawing.SizeF(220.0!, 41.15!)
        Me.XrPictureBox1.Sizing = DevExpress.XtraPrinting.ImageSizeMode.StretchImage
        '
        'XrLabel2
        '
        Me.XrLabel2.Font = New System.Drawing.Font("Tahoma", 12.75!, System.Drawing.FontStyle.Bold)
        Me.XrLabel2.LocationFloat = New DevExpress.Utils.PointFloat(220.0!, 20.00001!)
        Me.XrLabel2.Name = "XrLabel2"
        Me.XrLabel2.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel2.SizeF = New System.Drawing.SizeF(560.0001!, 23.0!)
        Me.XrLabel2.StylePriority.UseFont = False
        Me.XrLabel2.StylePriority.UseTextAlignment = False
        Me.XrLabel2.Text = "Propose Employee Salary"
        Me.XrLabel2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter
        '
        'XLNumber
        '
        Me.XLNumber.AnchorHorizontal = DevExpress.XtraReports.UI.HorizontalAnchorStyles.Right
        Me.XLNumber.Font = New System.Drawing.Font("Tahoma", 10.75!, System.Drawing.FontStyle.Bold)
        Me.XLNumber.LocationFloat = New DevExpress.Utils.PointFloat(849.0001!, 20.00001!)
        Me.XLNumber.Name = "XLNumber"
        Me.XLNumber.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XLNumber.SizeF = New System.Drawing.SizeF(220.0!, 23.0!)
        Me.XLNumber.StylePriority.UseFont = False
        Me.XLNumber.StylePriority.UseTextAlignment = False
        Me.XLNumber.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
        '
        'XrLine1
        '
        Me.XrLine1.LocationFloat = New DevExpress.Utils.PointFloat(0!, 51.15001!)
        Me.XrLine1.Name = "XrLine1"
        Me.XrLine1.SizeF = New System.Drawing.SizeF(1069.0!, 20.0!)
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
        Me.XrPageInfo1.Font = New System.Drawing.Font("Lucida Sans", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.XrPageInfo1.Format = "Page {0} of {1}"
        Me.XrPageInfo1.LocationFloat = New DevExpress.Utils.PointFloat(919.0!, 0!)
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
        Me.ReportHeader.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.XLEffectiveDate, Me.XrLabel4, Me.XrLabel3})
        Me.ReportHeader.HeightF = 23.41669!
        Me.ReportHeader.Name = "ReportHeader"
        '
        'XLEffectiveDate
        '
        Me.XLEffectiveDate.Font = New System.Drawing.Font("Tahoma", 8.75!)
        Me.XLEffectiveDate.LocationFloat = New DevExpress.Utils.PointFloat(969.0!, 0.2083461!)
        Me.XLEffectiveDate.Name = "XLEffectiveDate"
        Me.XLEffectiveDate.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XLEffectiveDate.SizeF = New System.Drawing.SizeF(100.0!, 23.0!)
        Me.XLEffectiveDate.StylePriority.UseFont = False
        Me.XLEffectiveDate.StylePriority.UseTextAlignment = False
        Me.XLEffectiveDate.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
        '
        'XrLabel4
        '
        Me.XrLabel4.Font = New System.Drawing.Font("Tahoma", 8.75!)
        Me.XrLabel4.LocationFloat = New DevExpress.Utils.PointFloat(954.0!, 0.2083461!)
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
        Me.XrLabel3.Font = New System.Drawing.Font("Tahoma", 8.75!)
        Me.XrLabel3.LocationFloat = New DevExpress.Utils.PointFloat(864.0001!, 0.4166921!)
        Me.XrLabel3.Name = "XrLabel3"
        Me.XrLabel3.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel3.SizeF = New System.Drawing.SizeF(90.0!, 23.0!)
        Me.XrLabel3.StylePriority.UseFont = False
        Me.XrLabel3.StylePriority.UseTextAlignment = False
        Me.XrLabel3.Text = "Effective Date"
        Me.XrLabel3.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
        '
        'ReportFooter
        '
        Me.ReportFooter.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.XrTable1, Me.XLNote, Me.XrLabel7, Me.XrLabel6})
        Me.ReportFooter.HeightF = 91.00006!
        Me.ReportFooter.Name = "ReportFooter"
        '
        'XrTable1
        '
        Me.XrTable1.Font = New System.Drawing.Font("Consolas", 8.0!)
        Me.XrTable1.LocationFloat = New DevExpress.Utils.PointFloat(0.0001271566!, 56.00001!)
        Me.XrTable1.Name = "XrTable1"
        Me.XrTable1.Rows.AddRange(New DevExpress.XtraReports.UI.XRTableRow() {Me.XrTableRow1})
        Me.XrTable1.SizeF = New System.Drawing.SizeF(1069.0!, 25.0!)
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
        'XLNote
        '
        Me.XLNote.Font = New System.Drawing.Font("Tahoma", 8.75!)
        Me.XLNote.LocationFloat = New DevExpress.Utils.PointFloat(105.0!, 0!)
        Me.XLNote.Name = "XLNote"
        Me.XLNote.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XLNote.SizeF = New System.Drawing.SizeF(964.0001!, 46.0!)
        Me.XLNote.StylePriority.UseFont = False
        Me.XLNote.StylePriority.UseTextAlignment = False
        Me.XLNote.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
        '
        'XrLabel7
        '
        Me.XrLabel7.Font = New System.Drawing.Font("Tahoma", 8.75!)
        Me.XrLabel7.LocationFloat = New DevExpress.Utils.PointFloat(89.99999!, 0!)
        Me.XrLabel7.Name = "XrLabel7"
        Me.XrLabel7.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel7.SizeF = New System.Drawing.SizeF(15.0!, 23.0!)
        Me.XrLabel7.StylePriority.UseFont = False
        Me.XrLabel7.StylePriority.UseTextAlignment = False
        Me.XrLabel7.Text = ":"
        Me.XrLabel7.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
        '
        'XrLabel6
        '
        Me.XrLabel6.Font = New System.Drawing.Font("Tahoma", 8.75!)
        Me.XrLabel6.LocationFloat = New DevExpress.Utils.PointFloat(0!, 0!)
        Me.XrLabel6.Name = "XrLabel6"
        Me.XrLabel6.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel6.SizeF = New System.Drawing.SizeF(90.0!, 23.0!)
        Me.XrLabel6.StylePriority.UseFont = False
        Me.XrLabel6.StylePriority.UseTextAlignment = False
        Me.XrLabel6.Text = "Note"
        Me.XrLabel6.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
        '
        'ReportProposeEmpSalary
        '
        Me.Bands.AddRange(New DevExpress.XtraReports.UI.Band() {Me.Detail, Me.TopMargin, Me.BottomMargin, Me.ReportHeader, Me.ReportFooter})
        Me.Font = New System.Drawing.Font("Tahoma", 9.75!)
        Me.Landscape = True
        Me.Margins = New System.Drawing.Printing.Margins(50, 50, 71, 50)
        Me.PageHeight = 827
        Me.PageWidth = 1169
        Me.PaperKind = System.Drawing.Printing.PaperKind.A4
        Me.ScriptLanguage = DevExpress.XtraReports.ScriptLanguage.VisualBasic
        Me.Version = "15.1"
        CType(Me.GCEmployee, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVEmployee, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RITESalary, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.XrTable1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me, System.ComponentModel.ISupportInitialize).EndInit()

    End Sub
    Friend WithEvents Detail As DevExpress.XtraReports.UI.DetailBand
    Friend WithEvents TopMargin As DevExpress.XtraReports.UI.TopMarginBand
    Friend WithEvents BottomMargin As DevExpress.XtraReports.UI.BottomMarginBand
    Friend WithEvents XrLabel2 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents WinControlContainer1 As DevExpress.XtraReports.UI.WinControlContainer
    Friend WithEvents GCEmployee As DevExpress.XtraGrid.GridControl
    Friend WithEvents RITESalary As DevExpress.XtraEditors.Repository.RepositoryItemTextEdit
    Friend WithEvents XLNumber As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrPictureBox1 As DevExpress.XtraReports.UI.XRPictureBox
    Friend WithEvents ReportHeader As DevExpress.XtraReports.UI.ReportHeaderBand
    Friend WithEvents XrLabel3 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLine1 As DevExpress.XtraReports.UI.XRLine
    Friend WithEvents XLEffectiveDate As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel4 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents ReportFooter As DevExpress.XtraReports.UI.ReportFooterBand
    Friend WithEvents XLNote As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel7 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel6 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrTable1 As DevExpress.XtraReports.UI.XRTable
    Friend WithEvents XrTableRow1 As DevExpress.XtraReports.UI.XRTableRow
    Friend WithEvents XrTableCell1 As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents XrPageInfo1 As DevExpress.XtraReports.UI.XRPageInfo
    Friend WithEvents GVEmployee As DevExpress.XtraGrid.Views.BandedGrid.BandedGridView
    Friend WithEvents GCEmployeeId As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents GCNIP As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents GCName As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents GCIdDepartement As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents GCDepartement As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents GCPosition As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents GCIdEmployeeLevel As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents GCLevel As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents GCIdEmployeeStatus As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents GCEmployeeStatus As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents GCBasicSalary As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents GCJobAllowance As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents GCMealAllowance As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents GCTransportAllowance As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents GCHouseAllowance As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents GCAttendanceAllowance As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents GCTotalSalary As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents GCFixedSalary As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents GCNonFixedSalary As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents GBEmployee As DevExpress.XtraGrid.Views.BandedGrid.GridBand
    Friend WithEvents GBSalary As DevExpress.XtraGrid.Views.BandedGrid.GridBand
    Friend WithEvents GBComposition As DevExpress.XtraGrid.Views.BandedGrid.GridBand
End Class
