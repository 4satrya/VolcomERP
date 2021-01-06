<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class ReportProposeEmpSalaryCompare
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ReportProposeEmpSalaryCompare))
        Me.Detail = New DevExpress.XtraReports.UI.DetailBand()
        Me.WinControlContainer1 = New DevExpress.XtraReports.UI.WinControlContainer()
        Me.GCEmployee = New DevExpress.XtraGrid.GridControl()
        Me.GVEmployee = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GCNIP = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GCName = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GCDepartement = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GCType = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GCBasicSalary = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GCJobAllowance = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GCMealAllowance = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GCTransportAllowance = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GCHouseAllowance = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GCAttendanceAllowance = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GCTotalSalary = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RITESalary = New DevExpress.XtraEditors.Repository.RepositoryItemTextEdit()
        Me.RepositoryItemCheckEdit = New DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit()
        Me.RepositoryItemSearchLookUpEdit = New DevExpress.XtraEditors.Repository.RepositoryItemSearchLookUpEdit()
        Me.RepositoryItemSearchLookUpEdit1View = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumn1 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn2 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn3 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RITEReason = New DevExpress.XtraEditors.Repository.RepositoryItemTextEdit()
        Me.TopMargin = New DevExpress.XtraReports.UI.TopMarginBand()
        Me.BottomMargin = New DevExpress.XtraReports.UI.BottomMarginBand()
        Me.XrPageInfo1 = New DevExpress.XtraReports.UI.XRPageInfo()
        Me.ReportHeader = New DevExpress.XtraReports.UI.ReportHeaderBand()
        Me.XLNumber = New DevExpress.XtraReports.UI.XRLabel()
        Me.XLEffectiveDate = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLine2 = New DevExpress.XtraReports.UI.XRLine()
        Me.XLTitle = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrPictureBox2 = New DevExpress.XtraReports.UI.XRPictureBox()
        Me.XLType = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLabel4 = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLabel3 = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLabel1 = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLabel2 = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLabel5 = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLabel8 = New DevExpress.XtraReports.UI.XRLabel()
        Me.ReportFooter = New DevExpress.XtraReports.UI.ReportFooterBand()
        Me.XrTable1 = New DevExpress.XtraReports.UI.XRTable()
        Me.XrTableRow1 = New DevExpress.XtraReports.UI.XRTableRow()
        Me.XrTableCell1 = New DevExpress.XtraReports.UI.XRTableCell()
        CType(Me.GCEmployee, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVEmployee, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RITESalary, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemCheckEdit, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemSearchLookUpEdit, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemSearchLookUpEdit1View, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RITEReason, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.WinControlContainer1.SizeF = New System.Drawing.SizeF(1075.0!, 99.99999!)
        Me.WinControlContainer1.WinControl = Me.GCEmployee
        '
        'GCEmployee
        '
        Me.GCEmployee.Location = New System.Drawing.Point(0, 0)
        Me.GCEmployee.MainView = Me.GVEmployee
        Me.GCEmployee.Name = "GCEmployee"
        Me.GCEmployee.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.RITESalary, Me.RepositoryItemCheckEdit, Me.RepositoryItemSearchLookUpEdit, Me.RITEReason})
        Me.GCEmployee.Size = New System.Drawing.Size(1032, 96)
        Me.GCEmployee.TabIndex = 3
        Me.GCEmployee.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVEmployee})
        '
        'GVEmployee
        '
        Me.GVEmployee.AppearancePrint.FooterPanel.BackColor = System.Drawing.Color.White
        Me.GVEmployee.AppearancePrint.FooterPanel.BorderColor = System.Drawing.Color.Black
        Me.GVEmployee.AppearancePrint.FooterPanel.Font = New System.Drawing.Font("Tahoma", 7.25!)
        Me.GVEmployee.AppearancePrint.FooterPanel.Options.UseBackColor = True
        Me.GVEmployee.AppearancePrint.FooterPanel.Options.UseBorderColor = True
        Me.GVEmployee.AppearancePrint.FooterPanel.Options.UseFont = True
        Me.GVEmployee.AppearancePrint.GroupFooter.BackColor = System.Drawing.Color.White
        Me.GVEmployee.AppearancePrint.GroupFooter.BorderColor = System.Drawing.Color.Black
        Me.GVEmployee.AppearancePrint.GroupFooter.Font = New System.Drawing.Font("Tahoma", 7.25!)
        Me.GVEmployee.AppearancePrint.GroupFooter.Options.UseBackColor = True
        Me.GVEmployee.AppearancePrint.GroupFooter.Options.UseBorderColor = True
        Me.GVEmployee.AppearancePrint.GroupFooter.Options.UseFont = True
        Me.GVEmployee.AppearancePrint.GroupRow.BackColor = System.Drawing.Color.White
        Me.GVEmployee.AppearancePrint.GroupRow.BorderColor = System.Drawing.Color.Black
        Me.GVEmployee.AppearancePrint.GroupRow.Font = New System.Drawing.Font("Tahoma", 7.25!, System.Drawing.FontStyle.Bold)
        Me.GVEmployee.AppearancePrint.GroupRow.Options.UseBackColor = True
        Me.GVEmployee.AppearancePrint.GroupRow.Options.UseBorderColor = True
        Me.GVEmployee.AppearancePrint.GroupRow.Options.UseFont = True
        Me.GVEmployee.AppearancePrint.HeaderPanel.BackColor = System.Drawing.Color.White
        Me.GVEmployee.AppearancePrint.HeaderPanel.BorderColor = System.Drawing.Color.Black
        Me.GVEmployee.AppearancePrint.HeaderPanel.Font = New System.Drawing.Font("Tahoma", 7.25!, System.Drawing.FontStyle.Bold)
        Me.GVEmployee.AppearancePrint.HeaderPanel.Options.UseBackColor = True
        Me.GVEmployee.AppearancePrint.HeaderPanel.Options.UseBorderColor = True
        Me.GVEmployee.AppearancePrint.HeaderPanel.Options.UseFont = True
        Me.GVEmployee.AppearancePrint.Lines.BackColor = System.Drawing.Color.Black
        Me.GVEmployee.AppearancePrint.Lines.Options.UseBackColor = True
        Me.GVEmployee.AppearancePrint.Row.BackColor = System.Drawing.Color.White
        Me.GVEmployee.AppearancePrint.Row.BorderColor = System.Drawing.Color.Black
        Me.GVEmployee.AppearancePrint.Row.Font = New System.Drawing.Font("Tahoma", 7.25!)
        Me.GVEmployee.AppearancePrint.Row.Options.UseBackColor = True
        Me.GVEmployee.AppearancePrint.Row.Options.UseBorderColor = True
        Me.GVEmployee.AppearancePrint.Row.Options.UseFont = True
        Me.GVEmployee.AppearancePrint.Row.Options.UseTextOptions = True
        Me.GVEmployee.AppearancePrint.Row.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
        Me.GVEmployee.ColumnPanelRowHeight = 32
        Me.GVEmployee.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GCNIP, Me.GCName, Me.GCDepartement, Me.GCType, Me.GCBasicSalary, Me.GCJobAllowance, Me.GCMealAllowance, Me.GCTransportAllowance, Me.GCHouseAllowance, Me.GCAttendanceAllowance, Me.GCTotalSalary})
        Me.GVEmployee.GridControl = Me.GCEmployee
        Me.GVEmployee.GroupCount = 1
        Me.GVEmployee.LevelIndent = 0
        Me.GVEmployee.Name = "GVEmployee"
        Me.GVEmployee.OptionsBehavior.AutoExpandAllGroups = True
        Me.GVEmployee.OptionsFind.AlwaysVisible = True
        Me.GVEmployee.OptionsPrint.AllowMultilineHeaders = True
        Me.GVEmployee.OptionsView.AllowCellMerge = True
        Me.GVEmployee.OptionsView.ColumnAutoWidth = False
        Me.GVEmployee.OptionsView.ShowGroupPanel = False
        Me.GVEmployee.SortInfo.AddRange(New DevExpress.XtraGrid.Columns.GridColumnSortInfo() {New DevExpress.XtraGrid.Columns.GridColumnSortInfo(Me.GCDepartement, DevExpress.Data.ColumnSortOrder.Ascending)})
        '
        'GCNIP
        '
        Me.GCNIP.Caption = "NIP"
        Me.GCNIP.FieldName = "employee_code"
        Me.GCNIP.MaxWidth = 100
        Me.GCNIP.MinWidth = 100
        Me.GCNIP.Name = "GCNIP"
        Me.GCNIP.OptionsColumn.AllowEdit = False
        Me.GCNIP.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.[True]
        Me.GCNIP.Visible = True
        Me.GCNIP.VisibleIndex = 0
        Me.GCNIP.Width = 100
        '
        'GCName
        '
        Me.GCName.AppearanceHeader.Options.UseTextOptions = True
        Me.GCName.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
        Me.GCName.Caption = "Name"
        Me.GCName.FieldName = "employee_name"
        Me.GCName.Name = "GCName"
        Me.GCName.OptionsColumn.AllowEdit = False
        Me.GCName.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.[True]
        Me.GCName.Visible = True
        Me.GCName.VisibleIndex = 1
        '
        'GCDepartement
        '
        Me.GCDepartement.Caption = "Departement"
        Me.GCDepartement.FieldName = "departement"
        Me.GCDepartement.Name = "GCDepartement"
        Me.GCDepartement.OptionsColumn.AllowEdit = False
        Me.GCDepartement.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.[False]
        Me.GCDepartement.Visible = True
        Me.GCDepartement.VisibleIndex = 4
        '
        'GCType
        '
        Me.GCType.Caption = "Type"
        Me.GCType.FieldName = "salary_type"
        Me.GCType.MaxWidth = 100
        Me.GCType.MinWidth = 100
        Me.GCType.Name = "GCType"
        Me.GCType.OptionsColumn.AllowEdit = False
        Me.GCType.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.[False]
        Me.GCType.Visible = True
        Me.GCType.VisibleIndex = 2
        Me.GCType.Width = 100
        '
        'GCBasicSalary
        '
        Me.GCBasicSalary.Caption = "Basic Salary"
        Me.GCBasicSalary.DisplayFormat.FormatString = "N0"
        Me.GCBasicSalary.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GCBasicSalary.FieldName = "basic_salary"
        Me.GCBasicSalary.MaxWidth = 100
        Me.GCBasicSalary.MinWidth = 100
        Me.GCBasicSalary.Name = "GCBasicSalary"
        Me.GCBasicSalary.OptionsColumn.AllowEdit = False
        Me.GCBasicSalary.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.[False]
        Me.GCBasicSalary.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "basic_salary", "{0:N0}")})
        Me.GCBasicSalary.Visible = True
        Me.GCBasicSalary.VisibleIndex = 3
        Me.GCBasicSalary.Width = 100
        '
        'GCJobAllowance
        '
        Me.GCJobAllowance.Caption = "Job Allowance"
        Me.GCJobAllowance.DisplayFormat.FormatString = "N0"
        Me.GCJobAllowance.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GCJobAllowance.FieldName = "allow_job"
        Me.GCJobAllowance.MaxWidth = 100
        Me.GCJobAllowance.MinWidth = 100
        Me.GCJobAllowance.Name = "GCJobAllowance"
        Me.GCJobAllowance.OptionsColumn.AllowEdit = False
        Me.GCJobAllowance.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.[False]
        Me.GCJobAllowance.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "allow_job", "{0:N0}")})
        Me.GCJobAllowance.Visible = True
        Me.GCJobAllowance.VisibleIndex = 4
        Me.GCJobAllowance.Width = 100
        '
        'GCMealAllowance
        '
        Me.GCMealAllowance.Caption = "Meal Allowance"
        Me.GCMealAllowance.DisplayFormat.FormatString = "N0"
        Me.GCMealAllowance.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GCMealAllowance.FieldName = "allow_meal"
        Me.GCMealAllowance.MaxWidth = 100
        Me.GCMealAllowance.MinWidth = 100
        Me.GCMealAllowance.Name = "GCMealAllowance"
        Me.GCMealAllowance.OptionsColumn.AllowEdit = False
        Me.GCMealAllowance.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.[False]
        Me.GCMealAllowance.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "allow_meal", "{0:N0}")})
        Me.GCMealAllowance.Visible = True
        Me.GCMealAllowance.VisibleIndex = 5
        Me.GCMealAllowance.Width = 100
        '
        'GCTransportAllowance
        '
        Me.GCTransportAllowance.Caption = "Transport Allowance"
        Me.GCTransportAllowance.DisplayFormat.FormatString = "N0"
        Me.GCTransportAllowance.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GCTransportAllowance.FieldName = "allow_trans"
        Me.GCTransportAllowance.MaxWidth = 100
        Me.GCTransportAllowance.MinWidth = 100
        Me.GCTransportAllowance.Name = "GCTransportAllowance"
        Me.GCTransportAllowance.OptionsColumn.AllowEdit = False
        Me.GCTransportAllowance.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.[False]
        Me.GCTransportAllowance.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "allow_trans", "{0:N0}")})
        Me.GCTransportAllowance.Visible = True
        Me.GCTransportAllowance.VisibleIndex = 6
        Me.GCTransportAllowance.Width = 100
        '
        'GCHouseAllowance
        '
        Me.GCHouseAllowance.Caption = "House Allowance"
        Me.GCHouseAllowance.DisplayFormat.FormatString = "N0"
        Me.GCHouseAllowance.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GCHouseAllowance.FieldName = "allow_house"
        Me.GCHouseAllowance.MaxWidth = 100
        Me.GCHouseAllowance.MinWidth = 100
        Me.GCHouseAllowance.Name = "GCHouseAllowance"
        Me.GCHouseAllowance.OptionsColumn.AllowEdit = False
        Me.GCHouseAllowance.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.[False]
        Me.GCHouseAllowance.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "allow_house", "{0:N0}")})
        Me.GCHouseAllowance.Visible = True
        Me.GCHouseAllowance.VisibleIndex = 7
        Me.GCHouseAllowance.Width = 100
        '
        'GCAttendanceAllowance
        '
        Me.GCAttendanceAllowance.Caption = "Attendance Allowance"
        Me.GCAttendanceAllowance.DisplayFormat.FormatString = "N0"
        Me.GCAttendanceAllowance.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GCAttendanceAllowance.FieldName = "allow_car"
        Me.GCAttendanceAllowance.MaxWidth = 100
        Me.GCAttendanceAllowance.MinWidth = 100
        Me.GCAttendanceAllowance.Name = "GCAttendanceAllowance"
        Me.GCAttendanceAllowance.OptionsColumn.AllowEdit = False
        Me.GCAttendanceAllowance.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.[False]
        Me.GCAttendanceAllowance.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "allow_car", "{0:N0}")})
        Me.GCAttendanceAllowance.Visible = True
        Me.GCAttendanceAllowance.VisibleIndex = 8
        Me.GCAttendanceAllowance.Width = 100
        '
        'GCTotalSalary
        '
        Me.GCTotalSalary.Caption = "Total THP"
        Me.GCTotalSalary.DisplayFormat.FormatString = "N0"
        Me.GCTotalSalary.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GCTotalSalary.FieldName = "total_salary"
        Me.GCTotalSalary.MaxWidth = 100
        Me.GCTotalSalary.MinWidth = 100
        Me.GCTotalSalary.Name = "GCTotalSalary"
        Me.GCTotalSalary.OptionsColumn.AllowEdit = False
        Me.GCTotalSalary.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.[False]
        Me.GCTotalSalary.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "total_salary", "{0:N0}")})
        Me.GCTotalSalary.UnboundExpression = "[basic_salary] + [allow_job] + [allow_meal] + [allow_trans] + [allow_house] + [al" &
    "low_car]"
        Me.GCTotalSalary.UnboundType = DevExpress.Data.UnboundColumnType.[Integer]
        Me.GCTotalSalary.Visible = True
        Me.GCTotalSalary.VisibleIndex = 9
        Me.GCTotalSalary.Width = 100
        '
        'RITESalary
        '
        Me.RITESalary.AutoHeight = False
        Me.RITESalary.DisplayFormat.FormatString = "N0"
        Me.RITESalary.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.RITESalary.EditFormat.FormatString = "N0"
        Me.RITESalary.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.RITESalary.Mask.EditMask = "N0"
        Me.RITESalary.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric
        Me.RITESalary.Mask.UseMaskAsDisplayFormat = True
        Me.RITESalary.Name = "RITESalary"
        '
        'RepositoryItemCheckEdit
        '
        Me.RepositoryItemCheckEdit.AutoHeight = False
        Me.RepositoryItemCheckEdit.CheckStyle = DevExpress.XtraEditors.Controls.CheckStyles.UserDefined
        Me.RepositoryItemCheckEdit.Name = "RepositoryItemCheckEdit"
        Me.RepositoryItemCheckEdit.PictureChecked = CType(resources.GetObject("RepositoryItemCheckEdit.PictureChecked"), System.Drawing.Image)
        Me.RepositoryItemCheckEdit.PictureGrayed = CType(resources.GetObject("RepositoryItemCheckEdit.PictureGrayed"), System.Drawing.Image)
        Me.RepositoryItemCheckEdit.PictureUnchecked = CType(resources.GetObject("RepositoryItemCheckEdit.PictureUnchecked"), System.Drawing.Image)
        '
        'RepositoryItemSearchLookUpEdit
        '
        Me.RepositoryItemSearchLookUpEdit.AutoHeight = False
        Me.RepositoryItemSearchLookUpEdit.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.RepositoryItemSearchLookUpEdit.Name = "RepositoryItemSearchLookUpEdit"
        Me.RepositoryItemSearchLookUpEdit.View = Me.RepositoryItemSearchLookUpEdit1View
        '
        'RepositoryItemSearchLookUpEdit1View
        '
        Me.RepositoryItemSearchLookUpEdit1View.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumn1, Me.GridColumn2, Me.GridColumn3})
        Me.RepositoryItemSearchLookUpEdit1View.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
        Me.RepositoryItemSearchLookUpEdit1View.Name = "RepositoryItemSearchLookUpEdit1View"
        Me.RepositoryItemSearchLookUpEdit1View.OptionsSelection.EnableAppearanceFocusedCell = False
        Me.RepositoryItemSearchLookUpEdit1View.OptionsView.ShowGroupPanel = False
        '
        'GridColumn1
        '
        Me.GridColumn1.Caption = "GridColumn1"
        Me.GridColumn1.FieldName = "id_employee_status_det"
        Me.GridColumn1.Name = "GridColumn1"
        '
        'GridColumn2
        '
        Me.GridColumn2.Caption = "GridColumn2"
        Me.GridColumn2.FieldName = "id_employee"
        Me.GridColumn2.Name = "GridColumn2"
        '
        'GridColumn3
        '
        Me.GridColumn3.Caption = "SK / Contract"
        Me.GridColumn3.FieldName = "contract"
        Me.GridColumn3.Name = "GridColumn3"
        Me.GridColumn3.Visible = True
        Me.GridColumn3.VisibleIndex = 0
        '
        'RITEReason
        '
        Me.RITEReason.AutoHeight = False
        Me.RITEReason.Name = "RITEReason"
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
        Me.XrPageInfo1.LocationFloat = New DevExpress.Utils.PointFloat(925.0004!, 0!)
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
        Me.ReportHeader.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.XLNumber, Me.XLEffectiveDate, Me.XrLine2, Me.XLTitle, Me.XrPictureBox2, Me.XLType, Me.XrLabel4, Me.XrLabel3, Me.XrLabel1, Me.XrLabel2, Me.XrLabel5, Me.XrLabel8})
        Me.ReportHeader.HeightF = 100.0!
        Me.ReportHeader.Name = "ReportHeader"
        '
        'XLNumber
        '
        Me.XLNumber.AnchorHorizontal = DevExpress.XtraReports.UI.HorizontalAnchorStyles.Right
        Me.XLNumber.Font = New System.Drawing.Font("Tahoma", 8.75!)
        Me.XLNumber.LocationFloat = New DevExpress.Utils.PointFloat(925.0002!, 0!)
        Me.XLNumber.Name = "XLNumber"
        Me.XLNumber.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XLNumber.SizeF = New System.Drawing.SizeF(149.9998!, 23.0!)
        Me.XLNumber.StylePriority.UseFont = False
        Me.XLNumber.StylePriority.UseTextAlignment = False
        Me.XLNumber.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
        '
        'XLEffectiveDate
        '
        Me.XLEffectiveDate.Font = New System.Drawing.Font("Tahoma", 8.75!)
        Me.XLEffectiveDate.LocationFloat = New DevExpress.Utils.PointFloat(924.9999!, 45.99991!)
        Me.XLEffectiveDate.Name = "XLEffectiveDate"
        Me.XLEffectiveDate.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XLEffectiveDate.SizeF = New System.Drawing.SizeF(150.0!, 22.99999!)
        Me.XLEffectiveDate.StylePriority.UseFont = False
        Me.XLEffectiveDate.StylePriority.UseTextAlignment = False
        Me.XLEffectiveDate.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
        '
        'XrLine2
        '
        Me.XrLine2.LocationFloat = New DevExpress.Utils.PointFloat(0.0002543131!, 73.99998!)
        Me.XrLine2.Name = "XrLine2"
        Me.XrLine2.SizeF = New System.Drawing.SizeF(1075.0!, 20.0!)
        '
        'XLTitle
        '
        Me.XLTitle.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Bold)
        Me.XLTitle.LocationFloat = New DevExpress.Utils.PointFloat(305.0001!, 16.0!)
        Me.XLTitle.Multiline = True
        Me.XLTitle.Name = "XLTitle"
        Me.XLTitle.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XLTitle.SizeF = New System.Drawing.SizeF(465.0003!, 41.15001!)
        Me.XLTitle.StylePriority.UseFont = False
        Me.XLTitle.StylePriority.UseTextAlignment = False
        Me.XLTitle.Text = "Propose Employee Salary Detail"
        Me.XLTitle.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        '
        'XrPictureBox2
        '
        Me.XrPictureBox2.AnchorHorizontal = DevExpress.XtraReports.UI.HorizontalAnchorStyles.Left
        Me.XrPictureBox2.Image = CType(resources.GetObject("XrPictureBox2.Image"), System.Drawing.Image)
        Me.XrPictureBox2.LocationFloat = New DevExpress.Utils.PointFloat(0.0002543131!, 16.0!)
        Me.XrPictureBox2.Name = "XrPictureBox2"
        Me.XrPictureBox2.SizeF = New System.Drawing.SizeF(220.0!, 41.15!)
        Me.XrPictureBox2.Sizing = DevExpress.XtraPrinting.ImageSizeMode.StretchImage
        '
        'XLType
        '
        Me.XLType.Font = New System.Drawing.Font("Tahoma", 8.75!)
        Me.XLType.LocationFloat = New DevExpress.Utils.PointFloat(925.0004!, 22.99997!)
        Me.XLType.Name = "XLType"
        Me.XLType.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XLType.SizeF = New System.Drawing.SizeF(150.0!, 23.0!)
        Me.XLType.StylePriority.UseFont = False
        Me.XLType.StylePriority.UseTextAlignment = False
        Me.XLType.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
        '
        'XrLabel4
        '
        Me.XrLabel4.Font = New System.Drawing.Font("Tahoma", 8.75!)
        Me.XrLabel4.LocationFloat = New DevExpress.Utils.PointFloat(815.0002!, 45.99997!)
        Me.XrLabel4.Name = "XrLabel4"
        Me.XrLabel4.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel4.SizeF = New System.Drawing.SizeF(100.0!, 23.0!)
        Me.XrLabel4.StylePriority.UseFont = False
        Me.XrLabel4.StylePriority.UseTextAlignment = False
        Me.XrLabel4.Text = "Effective Date"
        Me.XrLabel4.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
        '
        'XrLabel3
        '
        Me.XrLabel3.Font = New System.Drawing.Font("Tahoma", 8.75!)
        Me.XrLabel3.LocationFloat = New DevExpress.Utils.PointFloat(815.0004!, 22.99997!)
        Me.XrLabel3.Name = "XrLabel3"
        Me.XrLabel3.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel3.SizeF = New System.Drawing.SizeF(100.0!, 23.0!)
        Me.XrLabel3.StylePriority.UseFont = False
        Me.XrLabel3.StylePriority.UseTextAlignment = False
        Me.XrLabel3.Text = "Type"
        Me.XrLabel3.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
        '
        'XrLabel1
        '
        Me.XrLabel1.Font = New System.Drawing.Font("Tahoma", 8.75!)
        Me.XrLabel1.LocationFloat = New DevExpress.Utils.PointFloat(914.9999!, 45.99991!)
        Me.XrLabel1.Name = "XrLabel1"
        Me.XrLabel1.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel1.SizeF = New System.Drawing.SizeF(10.0!, 23.0!)
        Me.XrLabel1.StylePriority.UseFont = False
        Me.XrLabel1.StylePriority.UseTextAlignment = False
        Me.XrLabel1.Text = ":"
        Me.XrLabel1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
        '
        'XrLabel2
        '
        Me.XrLabel2.Font = New System.Drawing.Font("Tahoma", 8.75!)
        Me.XrLabel2.LocationFloat = New DevExpress.Utils.PointFloat(915.0004!, 22.99997!)
        Me.XrLabel2.Name = "XrLabel2"
        Me.XrLabel2.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel2.SizeF = New System.Drawing.SizeF(10.0!, 23.0!)
        Me.XrLabel2.StylePriority.UseFont = False
        Me.XrLabel2.StylePriority.UseTextAlignment = False
        Me.XrLabel2.Text = ":"
        Me.XrLabel2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
        '
        'XrLabel5
        '
        Me.XrLabel5.AnchorHorizontal = DevExpress.XtraReports.UI.HorizontalAnchorStyles.Right
        Me.XrLabel5.Font = New System.Drawing.Font("Tahoma", 8.75!)
        Me.XrLabel5.LocationFloat = New DevExpress.Utils.PointFloat(915.0004!, 0!)
        Me.XrLabel5.Name = "XrLabel5"
        Me.XrLabel5.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel5.SizeF = New System.Drawing.SizeF(9.999817!, 23.0!)
        Me.XrLabel5.StylePriority.UseFont = False
        Me.XrLabel5.StylePriority.UseTextAlignment = False
        Me.XrLabel5.Text = ":"
        Me.XrLabel5.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
        '
        'XrLabel8
        '
        Me.XrLabel8.AnchorHorizontal = DevExpress.XtraReports.UI.HorizontalAnchorStyles.Right
        Me.XrLabel8.Font = New System.Drawing.Font("Tahoma", 8.75!)
        Me.XrLabel8.LocationFloat = New DevExpress.Utils.PointFloat(815.0!, 0.00001589457!)
        Me.XrLabel8.Name = "XrLabel8"
        Me.XrLabel8.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel8.SizeF = New System.Drawing.SizeF(100.0004!, 23.0!)
        Me.XrLabel8.StylePriority.UseFont = False
        Me.XrLabel8.StylePriority.UseTextAlignment = False
        Me.XrLabel8.Text = "Number"
        Me.XrLabel8.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
        '
        'ReportFooter
        '
        Me.ReportFooter.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.XrTable1})
        Me.ReportFooter.HeightF = 45.00002!
        Me.ReportFooter.Name = "ReportFooter"
        '
        'XrTable1
        '
        Me.XrTable1.Font = New System.Drawing.Font("Consolas", 8.0!)
        Me.XrTable1.LocationFloat = New DevExpress.Utils.PointFloat(0.000445048!, 20.00001!)
        Me.XrTable1.Name = "XrTable1"
        Me.XrTable1.Rows.AddRange(New DevExpress.XtraReports.UI.XRTableRow() {Me.XrTableRow1})
        Me.XrTable1.SizeF = New System.Drawing.SizeF(1075.0!, 25.0!)
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
        'ReportProposeEmpSalaryCompare
        '
        Me.Bands.AddRange(New DevExpress.XtraReports.UI.Band() {Me.Detail, Me.TopMargin, Me.BottomMargin, Me.ReportHeader, Me.ReportFooter})
        Me.Landscape = True
        Me.Margins = New System.Drawing.Printing.Margins(25, 69, 50, 50)
        Me.PageHeight = 827
        Me.PageWidth = 1169
        Me.PaperKind = System.Drawing.Printing.PaperKind.A4
        Me.ScriptLanguage = DevExpress.XtraReports.ScriptLanguage.VisualBasic
        Me.Version = "15.1"
        CType(Me.GCEmployee, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVEmployee, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RITESalary, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemCheckEdit, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemSearchLookUpEdit, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemSearchLookUpEdit1View, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RITEReason, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.XrTable1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me, System.ComponentModel.ISupportInitialize).EndInit()

    End Sub
    Friend WithEvents Detail As DevExpress.XtraReports.UI.DetailBand
    Friend WithEvents TopMargin As DevExpress.XtraReports.UI.TopMarginBand
    Friend WithEvents BottomMargin As DevExpress.XtraReports.UI.BottomMarginBand
    Friend WithEvents WinControlContainer1 As DevExpress.XtraReports.UI.WinControlContainer
    Friend WithEvents GCEmployee As DevExpress.XtraGrid.GridControl
    Friend WithEvents RITESalary As DevExpress.XtraEditors.Repository.RepositoryItemTextEdit
    Friend WithEvents RepositoryItemSearchLookUpEdit As DevExpress.XtraEditors.Repository.RepositoryItemSearchLookUpEdit
    Friend WithEvents RepositoryItemSearchLookUpEdit1View As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumn1 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn2 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn3 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents RepositoryItemCheckEdit As DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit
    Friend WithEvents RITEReason As DevExpress.XtraEditors.Repository.RepositoryItemTextEdit
    Friend WithEvents GVEmployee As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GCNIP As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GCName As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GCDepartement As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GCType As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GCBasicSalary As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GCJobAllowance As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GCMealAllowance As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GCTransportAllowance As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GCHouseAllowance As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GCAttendanceAllowance As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GCTotalSalary As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ReportHeader As DevExpress.XtraReports.UI.ReportHeaderBand
    Friend WithEvents XLNumber As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XLEffectiveDate As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLine2 As DevExpress.XtraReports.UI.XRLine
    Friend WithEvents XLTitle As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrPictureBox2 As DevExpress.XtraReports.UI.XRPictureBox
    Friend WithEvents XLType As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel4 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel3 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel1 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel2 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel5 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel8 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents ReportFooter As DevExpress.XtraReports.UI.ReportFooterBand
    Friend WithEvents XrTable1 As DevExpress.XtraReports.UI.XRTable
    Friend WithEvents XrTableRow1 As DevExpress.XtraReports.UI.XRTableRow
    Friend WithEvents XrTableCell1 As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents XrPageInfo1 As DevExpress.XtraReports.UI.XRPageInfo
End Class
