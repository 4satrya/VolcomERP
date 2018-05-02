<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FormEmpPayroll
    Inherits DevExpress.XtraEditors.XtraForm

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormEmpPayroll))
        Me.XTCPayroll = New DevExpress.XtraTab.XtraTabControl()
        Me.XTPPeriode = New DevExpress.XtraTab.XtraTabPage()
        Me.GCPayrollPeriode = New DevExpress.XtraGrid.GridControl()
        Me.GVPayrollPeriode = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumnID = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnPStart = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnPEnd = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnLastUpd = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnLastUpdBy = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnNote = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.XTPSalaryFormat = New DevExpress.XtraTab.XtraTabPage()
        Me.GCPayroll = New DevExpress.XtraGrid.GridControl()
        Me.ViewPopWorksheet = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.CMDelEmp = New System.Windows.Forms.ToolStripMenuItem()
        Me.GVPayroll = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridView()
        Me.gridBand8 = New DevExpress.XtraGrid.Views.BandedGrid.GridBand()
        Me.BandedGridColumnCheck = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.RICEPending = New DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit()
        Me.GridColumnNIP = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.GridColumnName = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.GridColumnDepartement = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.GridBand1 = New DevExpress.XtraGrid.Views.BandedGrid.GridBand()
        Me.GridColumnIDDet = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.GridColumnIDEmployee = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.GridColumnLevel = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.GridColumnPosition = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.GridColumnStatus = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.GridColumnContractEnd = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.gridBand5 = New DevExpress.XtraGrid.Views.BandedGrid.GridBand()
        Me.GridColumnWorkingDays = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumnActWorkdays = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.GridColumnTotOvertime = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.gridBand2 = New DevExpress.XtraGrid.Views.BandedGrid.GridBand()
        Me.GridColumnBasicSalary = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.GridColumnJobAllowance = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.GridColumnMealAllowance = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.GridColumnTransportAllowance = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.GridColumnHousingAllowance = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.GridColumnVehicleAttndAllowance = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.GridColumnTotTHP = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.gridBand6 = New DevExpress.XtraGrid.Views.BandedGrid.GridBand()
        Me.BandedGridColumnBonus = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumnAdjustment = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumnRapel = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumnCuti = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumnTotalAdjustment = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.gridBand3 = New DevExpress.XtraGrid.Views.BandedGrid.GridBand()
        Me.GridColumnPointRegular = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.GridColumnOTReguler = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.GridColumnPointMkt = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.GridColumnOtMkt = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.GridColumnPointIA = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.GridColumnOtIA = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.GridColumnPointSales = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.GridColumnOtSales = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.GridColumnPointProd = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.GridColumnOTProd = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.GridColumnPointGeneral = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.GridColumnOtGeneral = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumnTotalPaymentOt = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.gridBand4 = New DevExpress.XtraGrid.Views.BandedGrid.GridBand()
        Me.BandedGridColumnBPJS = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumnJHT = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumnJP = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumnTotJamsostek = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.GridColumnIuranKoperasi = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.GridColumnPinjamanKoperasi = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.GridColumnUniform = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.GridColumnWHSale = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.GridColumnKasBon = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.GridColumnREIKI = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.GridColumnSPT = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.GridColumnMissing = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.GridColumnPotLain2 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumnTotalDeduction = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.gridBand9 = New DevExpress.XtraGrid.Views.BandedGrid.GridBand()
        Me.BandedGridColumnGrandTotal = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.gridBand7 = New DevExpress.XtraGrid.Views.BandedGrid.GridBand()
        Me.BandedGridColumnPending = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.PanelControl2 = New DevExpress.XtraEditors.PanelControl()
        Me.BPrintSlip = New DevExpress.XtraEditors.SimpleButton()
        Me.LargeImageCollection = New DevExpress.Utils.ImageCollection(Me.components)
        Me.PCSelAll = New DevExpress.XtraEditors.PanelControl()
        Me.CheckEditSelAll = New DevExpress.XtraEditors.CheckEdit()
        Me.PBCLineList = New DevExpress.XtraEditors.ProgressBarControl()
        Me.BPrint = New DevExpress.XtraEditors.SimpleButton()
        Me.PanelControl1 = New DevExpress.XtraEditors.PanelControl()
        Me.BUpdateActualWorkingDays = New DevExpress.XtraEditors.SimpleButton()
        Me.BBonusAdjustment = New DevExpress.XtraEditors.SimpleButton()
        Me.BDeduction = New DevExpress.XtraEditors.SimpleButton()
        Me.BRemoveEmployee = New DevExpress.XtraEditors.SimpleButton()
        Me.BGetEmployee = New DevExpress.XtraEditors.SimpleButton()
        Me.BOvertime = New DevExpress.XtraEditors.SimpleButton()
        Me.BSetting = New DevExpress.XtraEditors.SimpleButton()
        CType(Me.XTCPayroll, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.XTCPayroll.SuspendLayout()
        Me.XTPPeriode.SuspendLayout()
        CType(Me.GCPayrollPeriode, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVPayrollPeriode, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.XTPSalaryFormat.SuspendLayout()
        CType(Me.GCPayroll, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ViewPopWorksheet.SuspendLayout()
        CType(Me.GVPayroll, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RICEPending, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PanelControl2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl2.SuspendLayout()
        CType(Me.LargeImageCollection, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PCSelAll, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PCSelAll.SuspendLayout()
        CType(Me.CheckEditSelAll.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PBCLineList.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl1.SuspendLayout()
        Me.SuspendLayout()
        '
        'XTCPayroll
        '
        Me.XTCPayroll.Dock = System.Windows.Forms.DockStyle.Fill
        Me.XTCPayroll.HeaderLocation = DevExpress.XtraTab.TabHeaderLocation.Bottom
        Me.XTCPayroll.Location = New System.Drawing.Point(0, 0)
        Me.XTCPayroll.Name = "XTCPayroll"
        Me.XTCPayroll.SelectedTabPage = Me.XTPPeriode
        Me.XTCPayroll.Size = New System.Drawing.Size(1121, 469)
        Me.XTCPayroll.TabIndex = 0
        Me.XTCPayroll.TabPages.AddRange(New DevExpress.XtraTab.XtraTabPage() {Me.XTPPeriode, Me.XTPSalaryFormat})
        '
        'XTPPeriode
        '
        Me.XTPPeriode.Controls.Add(Me.GCPayrollPeriode)
        Me.XTPPeriode.Name = "XTPPeriode"
        Me.XTPPeriode.Size = New System.Drawing.Size(1115, 441)
        Me.XTPPeriode.Text = "Periode"
        '
        'GCPayrollPeriode
        '
        Me.GCPayrollPeriode.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCPayrollPeriode.Location = New System.Drawing.Point(0, 0)
        Me.GCPayrollPeriode.MainView = Me.GVPayrollPeriode
        Me.GCPayrollPeriode.Name = "GCPayrollPeriode"
        Me.GCPayrollPeriode.Size = New System.Drawing.Size(1115, 441)
        Me.GCPayrollPeriode.TabIndex = 0
        Me.GCPayrollPeriode.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVPayrollPeriode})
        '
        'GVPayrollPeriode
        '
        Me.GVPayrollPeriode.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumnID, Me.GridColumnPStart, Me.GridColumnPEnd, Me.GridColumnLastUpd, Me.GridColumnLastUpdBy, Me.GridColumnNote})
        Me.GVPayrollPeriode.GridControl = Me.GCPayrollPeriode
        Me.GVPayrollPeriode.Name = "GVPayrollPeriode"
        Me.GVPayrollPeriode.OptionsBehavior.ReadOnly = True
        Me.GVPayrollPeriode.OptionsView.ShowGroupPanel = False
        '
        'GridColumnID
        '
        Me.GridColumnID.Caption = "ID"
        Me.GridColumnID.FieldName = "id_payroll"
        Me.GridColumnID.Name = "GridColumnID"
        '
        'GridColumnPStart
        '
        Me.GridColumnPStart.Caption = "Periode Start"
        Me.GridColumnPStart.DisplayFormat.FormatString = "dd MMM yyyy"
        Me.GridColumnPStart.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.GridColumnPStart.FieldName = "periode_start"
        Me.GridColumnPStart.Name = "GridColumnPStart"
        Me.GridColumnPStart.Visible = True
        Me.GridColumnPStart.VisibleIndex = 0
        Me.GridColumnPStart.Width = 160
        '
        'GridColumnPEnd
        '
        Me.GridColumnPEnd.Caption = "Periode End"
        Me.GridColumnPEnd.DisplayFormat.FormatString = "dd MMM yyyy"
        Me.GridColumnPEnd.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.GridColumnPEnd.FieldName = "periode_end"
        Me.GridColumnPEnd.Name = "GridColumnPEnd"
        Me.GridColumnPEnd.Visible = True
        Me.GridColumnPEnd.VisibleIndex = 1
        Me.GridColumnPEnd.Width = 136
        '
        'GridColumnLastUpd
        '
        Me.GridColumnLastUpd.Caption = "Last Update"
        Me.GridColumnLastUpd.DisplayFormat.FormatString = "dd MMM yyyy"
        Me.GridColumnLastUpd.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.GridColumnLastUpd.FieldName = "employee_name"
        Me.GridColumnLastUpd.Name = "GridColumnLastUpd"
        Me.GridColumnLastUpd.Visible = True
        Me.GridColumnLastUpd.VisibleIndex = 2
        Me.GridColumnLastUpd.Width = 199
        '
        'GridColumnLastUpdBy
        '
        Me.GridColumnLastUpdBy.Caption = "Last Update By"
        Me.GridColumnLastUpdBy.FieldName = "employee_name"
        Me.GridColumnLastUpdBy.Name = "GridColumnLastUpdBy"
        Me.GridColumnLastUpdBy.Visible = True
        Me.GridColumnLastUpdBy.VisibleIndex = 3
        Me.GridColumnLastUpdBy.Width = 162
        '
        'GridColumnNote
        '
        Me.GridColumnNote.Caption = "Note"
        Me.GridColumnNote.FieldName = "note"
        Me.GridColumnNote.Name = "GridColumnNote"
        Me.GridColumnNote.Visible = True
        Me.GridColumnNote.VisibleIndex = 4
        Me.GridColumnNote.Width = 440
        '
        'XTPSalaryFormat
        '
        Me.XTPSalaryFormat.Controls.Add(Me.GCPayroll)
        Me.XTPSalaryFormat.Controls.Add(Me.PanelControl2)
        Me.XTPSalaryFormat.Controls.Add(Me.PanelControl1)
        Me.XTPSalaryFormat.Name = "XTPSalaryFormat"
        Me.XTPSalaryFormat.Size = New System.Drawing.Size(1115, 441)
        Me.XTPSalaryFormat.Text = "Worksheet"
        '
        'GCPayroll
        '
        Me.GCPayroll.ContextMenuStrip = Me.ViewPopWorksheet
        Me.GCPayroll.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCPayroll.Location = New System.Drawing.Point(0, 39)
        Me.GCPayroll.MainView = Me.GVPayroll
        Me.GCPayroll.Name = "GCPayroll"
        Me.GCPayroll.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.RICEPending})
        Me.GCPayroll.Size = New System.Drawing.Size(1115, 363)
        Me.GCPayroll.TabIndex = 1
        Me.GCPayroll.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVPayroll})
        '
        'ViewPopWorksheet
        '
        Me.ViewPopWorksheet.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.CMDelEmp})
        Me.ViewPopWorksheet.Name = "ViewPreDel"
        Me.ViewPopWorksheet.Size = New System.Drawing.Size(173, 26)
        '
        'CMDelEmp
        '
        Me.CMDelEmp.Name = "CMDelEmp"
        Me.CMDelEmp.Size = New System.Drawing.Size(172, 22)
        Me.CMDelEmp.Text = "Remove Employee"
        '
        'GVPayroll
        '
        Me.GVPayroll.Bands.AddRange(New DevExpress.XtraGrid.Views.BandedGrid.GridBand() {Me.gridBand8, Me.GridBand1, Me.gridBand5, Me.gridBand2, Me.gridBand6, Me.gridBand3, Me.gridBand4, Me.gridBand9, Me.gridBand7})
        Me.GVPayroll.Columns.AddRange(New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn() {Me.BandedGridColumnCheck, Me.GridColumnIDDet, Me.GridColumnIDEmployee, Me.GridColumnNIP, Me.GridColumnName, Me.GridColumnDepartement, Me.GridColumnLevel, Me.GridColumnPosition, Me.GridColumnStatus, Me.GridColumnContractEnd, Me.GridColumnWorkingDays, Me.BandedGridColumnActWorkdays, Me.GridColumnTotOvertime, Me.GridColumnBasicSalary, Me.GridColumnJobAllowance, Me.GridColumnMealAllowance, Me.GridColumnTransportAllowance, Me.GridColumnHousingAllowance, Me.GridColumnVehicleAttndAllowance, Me.GridColumnTotTHP, Me.GridColumnPointRegular, Me.GridColumnOTReguler, Me.GridColumnPointMkt, Me.GridColumnOtMkt, Me.GridColumnPointIA, Me.GridColumnOtIA, Me.GridColumnPointSales, Me.GridColumnOtSales, Me.GridColumnPointProd, Me.GridColumnOTProd, Me.GridColumnPointGeneral, Me.GridColumnOtGeneral, Me.BandedGridColumnBPJS, Me.BandedGridColumnJHT, Me.BandedGridColumnJP, Me.BandedGridColumnTotJamsostek, Me.GridColumnIuranKoperasi, Me.GridColumnPinjamanKoperasi, Me.GridColumnUniform, Me.GridColumnWHSale, Me.GridColumnREIKI, Me.GridColumnKasBon, Me.GridColumnSPT, Me.GridColumnMissing, Me.GridColumnPotLain2, Me.BandedGridColumnBonus, Me.BandedGridColumnAdjustment, Me.BandedGridColumnRapel, Me.BandedGridColumnCuti, Me.BandedGridColumnPending, Me.BandedGridColumnGrandTotal, Me.BandedGridColumnTotalAdjustment, Me.BandedGridColumnTotalPaymentOt, Me.BandedGridColumnTotalDeduction})
        Me.GVPayroll.GridControl = Me.GCPayroll
        Me.GVPayroll.GroupSummary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "total_ot", Me.GridColumnTotOvertime, "{0:N1}"), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "tot_thp", Me.GridColumnTotTHP, "{0:N0}"), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "reg_total_point", Me.GridColumnPointRegular, "{0:N2}"), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "reg_total_wages", Me.GridColumnOTReguler, "{0:N2}"), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "mkt_total_point", Me.GridColumnPointMkt, "{0:N2}"), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "mkt_total_wages", Me.GridColumnOtMkt, "{0:N2}"), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "ia_total_point", Me.GridColumnPointIA, "{0:N2}"), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "ia_total_wages", Me.GridColumnOtIA, "{0:N2}"), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "prod_total_point", Me.GridColumnPointProd, "{0:N2}"), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "prod_total_wages", Me.GridColumnOTProd, "{0:N2}"), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "sales_total_point", Me.GridColumnPointSales, "{0:N2}"), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "sales_total_wages", Me.GridColumnOtSales, "{0:N2}"), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "general_total_point", Me.GridColumnPointGeneral, "{0:N2}"), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "general_total_wages", Me.GridColumnOtGeneral, "{0:N2}"), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "d_iuran_koperasi", Me.GridColumnIuranKoperasi, "{0:N0}"), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "d_uniform", Me.GridColumnUniform, "{0:N0}"), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "d_wh_sale", Me.GridColumnWHSale, "{0:N0}"), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "d_reiki", Me.GridColumnREIKI, "{0:N0}"), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "d_kasbon", Me.GridColumnKasBon, "{0:N0}"), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "d_spt", Me.GridColumnSPT, "{0:N0}"), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "d_tab_missing", Me.GridColumnMissing, "{0:N0}"), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "d_pot_lain", Me.GridColumnPotLain2, "{0:N0}"), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "d_bpjs", Me.BandedGridColumnBPJS, "{0:N0}"), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "d_jht", Me.BandedGridColumnJHT, "{0:N0}"), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "d_jp", Me.BandedGridColumnJP, "{0:N0}"), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "d_jamsostek", Me.BandedGridColumnTotJamsostek, "{0:N0}"), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "a_bonus", Me.BandedGridColumnBonus, "{0:N0}"), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "a_adjustment", Me.BandedGridColumnAdjustment, "{0:N0}"), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "a_rapel", Me.BandedGridColumnRapel, "{0:N0}"), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "a_cuti", Me.BandedGridColumnCuti, "{0:N0}"), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "grand_total", Me.BandedGridColumnGrandTotal, "{0:N2}"), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "total_ot_wages", Me.BandedGridColumnTotalPaymentOt, "{0:N2}"), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "total_adjustment", Me.BandedGridColumnTotalAdjustment, "{0:N2}"), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "total_deduction", Me.BandedGridColumnTotalDeduction, "{0:N2}"), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "d_pinjaman_koperasi", Me.GridColumnPinjamanKoperasi, "{0:N0}"), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "basic_salary", Me.GridColumnBasicSalary, "{0:N2}"), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "allow_job", Me.GridColumnJobAllowance, "{0:N2}"), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "allow_meal", Me.GridColumnMealAllowance, "{0:N2}"), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "allow_trans", Me.GridColumnTransportAllowance, "{0:N2}"), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "allow_car", Me.GridColumnVehicleAttndAllowance, "{0:N2}")})
        Me.GVPayroll.Name = "GVPayroll"
        Me.GVPayroll.OptionsView.ColumnAutoWidth = False
        Me.GVPayroll.OptionsView.GroupFooterShowMode = DevExpress.XtraGrid.Views.Grid.GroupFooterShowMode.VisibleAlways
        Me.GVPayroll.OptionsView.ShowFooter = True
        Me.GVPayroll.OptionsView.ShowGroupPanel = False
        '
        'gridBand8
        '
        Me.gridBand8.Caption = "Employee"
        Me.gridBand8.Columns.Add(Me.BandedGridColumnCheck)
        Me.gridBand8.Columns.Add(Me.GridColumnNIP)
        Me.gridBand8.Columns.Add(Me.GridColumnName)
        Me.gridBand8.Columns.Add(Me.GridColumnDepartement)
        Me.gridBand8.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left
        Me.gridBand8.Name = "gridBand8"
        Me.gridBand8.VisibleIndex = 0
        Me.gridBand8.Width = 267
        '
        'BandedGridColumnCheck
        '
        Me.BandedGridColumnCheck.AppearanceCell.Options.UseTextOptions = True
        Me.BandedGridColumnCheck.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.BandedGridColumnCheck.AppearanceHeader.Options.UseTextOptions = True
        Me.BandedGridColumnCheck.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.BandedGridColumnCheck.Caption = "*"
        Me.BandedGridColumnCheck.ColumnEdit = Me.RICEPending
        Me.BandedGridColumnCheck.FieldName = "is_check"
        Me.BandedGridColumnCheck.Name = "BandedGridColumnCheck"
        Me.BandedGridColumnCheck.Visible = True
        Me.BandedGridColumnCheck.Width = 42
        '
        'RICEPending
        '
        Me.RICEPending.AutoHeight = False
        Me.RICEPending.Name = "RICEPending"
        Me.RICEPending.ValueChecked = "yes"
        Me.RICEPending.ValueUnchecked = "no"
        '
        'GridColumnNIP
        '
        Me.GridColumnNIP.Caption = "NIP"
        Me.GridColumnNIP.FieldName = "employee_code"
        Me.GridColumnNIP.Name = "GridColumnNIP"
        Me.GridColumnNIP.OptionsColumn.ReadOnly = True
        Me.GridColumnNIP.Visible = True
        '
        'GridColumnName
        '
        Me.GridColumnName.Caption = "Name"
        Me.GridColumnName.FieldName = "employee_name"
        Me.GridColumnName.Name = "GridColumnName"
        Me.GridColumnName.OptionsColumn.ReadOnly = True
        Me.GridColumnName.Visible = True
        '
        'GridColumnDepartement
        '
        Me.GridColumnDepartement.Caption = "Departement"
        Me.GridColumnDepartement.FieldName = "departement"
        Me.GridColumnDepartement.Name = "GridColumnDepartement"
        Me.GridColumnDepartement.OptionsColumn.ReadOnly = True
        Me.GridColumnDepartement.Visible = True
        '
        'GridBand1
        '
        Me.GridBand1.AppearanceHeader.Options.UseTextOptions = True
        Me.GridBand1.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridBand1.Caption = "Employee Detail"
        Me.GridBand1.Columns.Add(Me.GridColumnIDDet)
        Me.GridBand1.Columns.Add(Me.GridColumnIDEmployee)
        Me.GridBand1.Columns.Add(Me.GridColumnLevel)
        Me.GridBand1.Columns.Add(Me.GridColumnPosition)
        Me.GridBand1.Columns.Add(Me.GridColumnStatus)
        Me.GridBand1.Columns.Add(Me.GridColumnContractEnd)
        Me.GridBand1.Name = "GridBand1"
        Me.GridBand1.VisibleIndex = 1
        Me.GridBand1.Width = 300
        '
        'GridColumnIDDet
        '
        Me.GridColumnIDDet.Caption = "ID"
        Me.GridColumnIDDet.FieldName = "id_payroll_det"
        Me.GridColumnIDDet.Name = "GridColumnIDDet"
        Me.GridColumnIDDet.OptionsColumn.ReadOnly = True
        '
        'GridColumnIDEmployee
        '
        Me.GridColumnIDEmployee.Caption = "ID Employee"
        Me.GridColumnIDEmployee.FieldName = "id_employee"
        Me.GridColumnIDEmployee.Name = "GridColumnIDEmployee"
        Me.GridColumnIDEmployee.OptionsColumn.ReadOnly = True
        '
        'GridColumnLevel
        '
        Me.GridColumnLevel.Caption = "Level"
        Me.GridColumnLevel.FieldName = "employee_level"
        Me.GridColumnLevel.Name = "GridColumnLevel"
        Me.GridColumnLevel.OptionsColumn.ReadOnly = True
        Me.GridColumnLevel.Visible = True
        '
        'GridColumnPosition
        '
        Me.GridColumnPosition.Caption = "Position"
        Me.GridColumnPosition.FieldName = "employee_position"
        Me.GridColumnPosition.Name = "GridColumnPosition"
        Me.GridColumnPosition.OptionsColumn.ReadOnly = True
        Me.GridColumnPosition.Visible = True
        '
        'GridColumnStatus
        '
        Me.GridColumnStatus.Caption = "Status"
        Me.GridColumnStatus.FieldName = "employee_status"
        Me.GridColumnStatus.Name = "GridColumnStatus"
        Me.GridColumnStatus.OptionsColumn.ReadOnly = True
        Me.GridColumnStatus.Visible = True
        '
        'GridColumnContractEnd
        '
        Me.GridColumnContractEnd.Caption = "Contract End"
        Me.GridColumnContractEnd.DisplayFormat.FormatString = "dd MMMM yyyy"
        Me.GridColumnContractEnd.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.GridColumnContractEnd.FieldName = "end_period"
        Me.GridColumnContractEnd.Name = "GridColumnContractEnd"
        Me.GridColumnContractEnd.OptionsColumn.ReadOnly = True
        Me.GridColumnContractEnd.Visible = True
        '
        'gridBand5
        '
        Me.gridBand5.AppearanceHeader.Options.UseTextOptions = True
        Me.gridBand5.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.gridBand5.Caption = "Working Time Detail"
        Me.gridBand5.Columns.Add(Me.GridColumnWorkingDays)
        Me.gridBand5.Columns.Add(Me.BandedGridColumnActWorkdays)
        Me.gridBand5.Columns.Add(Me.GridColumnTotOvertime)
        Me.gridBand5.Name = "gridBand5"
        Me.gridBand5.VisibleIndex = 2
        Me.gridBand5.Width = 225
        '
        'GridColumnWorkingDays
        '
        Me.GridColumnWorkingDays.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumnWorkingDays.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridColumnWorkingDays.AppearanceHeader.Options.UseTextOptions = True
        Me.GridColumnWorkingDays.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridColumnWorkingDays.Caption = "Working Days"
        Me.GridColumnWorkingDays.DisplayFormat.FormatString = "N1"
        Me.GridColumnWorkingDays.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumnWorkingDays.FieldName = "workdays"
        Me.GridColumnWorkingDays.Name = "GridColumnWorkingDays"
        Me.GridColumnWorkingDays.OptionsColumn.ReadOnly = True
        Me.GridColumnWorkingDays.Visible = True
        '
        'BandedGridColumnActWorkdays
        '
        Me.BandedGridColumnActWorkdays.AppearanceCell.Options.UseTextOptions = True
        Me.BandedGridColumnActWorkdays.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.BandedGridColumnActWorkdays.AppearanceHeader.Options.UseTextOptions = True
        Me.BandedGridColumnActWorkdays.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.BandedGridColumnActWorkdays.Caption = "Actual Working Days"
        Me.BandedGridColumnActWorkdays.DisplayFormat.FormatString = "N1"
        Me.BandedGridColumnActWorkdays.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.BandedGridColumnActWorkdays.FieldName = "actual_workdays"
        Me.BandedGridColumnActWorkdays.Name = "BandedGridColumnActWorkdays"
        Me.BandedGridColumnActWorkdays.Visible = True
        '
        'GridColumnTotOvertime
        '
        Me.GridColumnTotOvertime.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumnTotOvertime.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridColumnTotOvertime.AppearanceHeader.Options.UseTextOptions = True
        Me.GridColumnTotOvertime.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridColumnTotOvertime.Caption = "Overtime (hours)"
        Me.GridColumnTotOvertime.DisplayFormat.FormatString = "N1"
        Me.GridColumnTotOvertime.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumnTotOvertime.FieldName = "total_ot"
        Me.GridColumnTotOvertime.Name = "GridColumnTotOvertime"
        Me.GridColumnTotOvertime.OptionsColumn.ReadOnly = True
        Me.GridColumnTotOvertime.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "total_ot", "{0:N1}")})
        Me.GridColumnTotOvertime.Visible = True
        '
        'gridBand2
        '
        Me.gridBand2.AppearanceHeader.Options.UseTextOptions = True
        Me.gridBand2.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.gridBand2.Caption = "Salary Detail"
        Me.gridBand2.Columns.Add(Me.GridColumnBasicSalary)
        Me.gridBand2.Columns.Add(Me.GridColumnJobAllowance)
        Me.gridBand2.Columns.Add(Me.GridColumnMealAllowance)
        Me.gridBand2.Columns.Add(Me.GridColumnTransportAllowance)
        Me.gridBand2.Columns.Add(Me.GridColumnHousingAllowance)
        Me.gridBand2.Columns.Add(Me.GridColumnVehicleAttndAllowance)
        Me.gridBand2.Columns.Add(Me.GridColumnTotTHP)
        Me.gridBand2.Name = "gridBand2"
        Me.gridBand2.VisibleIndex = 3
        Me.gridBand2.Width = 525
        '
        'GridColumnBasicSalary
        '
        Me.GridColumnBasicSalary.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumnBasicSalary.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumnBasicSalary.AppearanceHeader.Options.UseTextOptions = True
        Me.GridColumnBasicSalary.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumnBasicSalary.Caption = "Basic Salary"
        Me.GridColumnBasicSalary.DisplayFormat.FormatString = "N2"
        Me.GridColumnBasicSalary.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumnBasicSalary.FieldName = "basic_salary"
        Me.GridColumnBasicSalary.Name = "GridColumnBasicSalary"
        Me.GridColumnBasicSalary.OptionsColumn.ReadOnly = True
        Me.GridColumnBasicSalary.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "basic_salary", "{0:N2}")})
        Me.GridColumnBasicSalary.Visible = True
        '
        'GridColumnJobAllowance
        '
        Me.GridColumnJobAllowance.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumnJobAllowance.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumnJobAllowance.AppearanceHeader.Options.UseTextOptions = True
        Me.GridColumnJobAllowance.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumnJobAllowance.Caption = "Job Allowance"
        Me.GridColumnJobAllowance.DisplayFormat.FormatString = "N2"
        Me.GridColumnJobAllowance.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumnJobAllowance.FieldName = "allow_job"
        Me.GridColumnJobAllowance.Name = "GridColumnJobAllowance"
        Me.GridColumnJobAllowance.OptionsColumn.ReadOnly = True
        Me.GridColumnJobAllowance.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "allow_job", "{0:N2}")})
        Me.GridColumnJobAllowance.Visible = True
        '
        'GridColumnMealAllowance
        '
        Me.GridColumnMealAllowance.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumnMealAllowance.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumnMealAllowance.AppearanceHeader.Options.UseTextOptions = True
        Me.GridColumnMealAllowance.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumnMealAllowance.Caption = "Meal Allowance"
        Me.GridColumnMealAllowance.DisplayFormat.FormatString = "N2"
        Me.GridColumnMealAllowance.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumnMealAllowance.FieldName = "allow_meal"
        Me.GridColumnMealAllowance.Name = "GridColumnMealAllowance"
        Me.GridColumnMealAllowance.OptionsColumn.ReadOnly = True
        Me.GridColumnMealAllowance.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "allow_meal", "{0:N2}")})
        Me.GridColumnMealAllowance.Visible = True
        '
        'GridColumnTransportAllowance
        '
        Me.GridColumnTransportAllowance.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumnTransportAllowance.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumnTransportAllowance.AppearanceHeader.Options.UseTextOptions = True
        Me.GridColumnTransportAllowance.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumnTransportAllowance.Caption = "Transport Allowance"
        Me.GridColumnTransportAllowance.DisplayFormat.FormatString = "N2"
        Me.GridColumnTransportAllowance.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumnTransportAllowance.FieldName = "allow_trans"
        Me.GridColumnTransportAllowance.Name = "GridColumnTransportAllowance"
        Me.GridColumnTransportAllowance.OptionsColumn.ReadOnly = True
        Me.GridColumnTransportAllowance.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "allow_trans", "{0:N2}")})
        Me.GridColumnTransportAllowance.Visible = True
        '
        'GridColumnHousingAllowance
        '
        Me.GridColumnHousingAllowance.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumnHousingAllowance.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumnHousingAllowance.AppearanceHeader.Options.UseTextOptions = True
        Me.GridColumnHousingAllowance.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumnHousingAllowance.Caption = "Housing Allowance"
        Me.GridColumnHousingAllowance.DisplayFormat.FormatString = "N2"
        Me.GridColumnHousingAllowance.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumnHousingAllowance.FieldName = "allow_house"
        Me.GridColumnHousingAllowance.Name = "GridColumnHousingAllowance"
        Me.GridColumnHousingAllowance.OptionsColumn.ReadOnly = True
        Me.GridColumnHousingAllowance.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "allow_house", "{0:N2}")})
        Me.GridColumnHousingAllowance.Visible = True
        '
        'GridColumnVehicleAttndAllowance
        '
        Me.GridColumnVehicleAttndAllowance.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumnVehicleAttndAllowance.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumnVehicleAttndAllowance.AppearanceHeader.Options.UseTextOptions = True
        Me.GridColumnVehicleAttndAllowance.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumnVehicleAttndAllowance.Caption = "Vehicle & Attnd Allowance"
        Me.GridColumnVehicleAttndAllowance.DisplayFormat.FormatString = "N2"
        Me.GridColumnVehicleAttndAllowance.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumnVehicleAttndAllowance.FieldName = "allow_car"
        Me.GridColumnVehicleAttndAllowance.Name = "GridColumnVehicleAttndAllowance"
        Me.GridColumnVehicleAttndAllowance.OptionsColumn.ReadOnly = True
        Me.GridColumnVehicleAttndAllowance.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "allow_car", "{0:N2}")})
        Me.GridColumnVehicleAttndAllowance.Visible = True
        '
        'GridColumnTotTHP
        '
        Me.GridColumnTotTHP.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumnTotTHP.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumnTotTHP.AppearanceHeader.Options.UseTextOptions = True
        Me.GridColumnTotTHP.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumnTotTHP.Caption = "THP Total"
        Me.GridColumnTotTHP.DisplayFormat.FormatString = "N0"
        Me.GridColumnTotTHP.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumnTotTHP.FieldName = "tot_thp"
        Me.GridColumnTotTHP.Name = "GridColumnTotTHP"
        Me.GridColumnTotTHP.OptionsColumn.ReadOnly = True
        Me.GridColumnTotTHP.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "tot_thp", "{0:N0}")})
        Me.GridColumnTotTHP.Visible = True
        '
        'gridBand6
        '
        Me.gridBand6.AppearanceHeader.Options.UseTextOptions = True
        Me.gridBand6.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.gridBand6.Caption = "Bonus & Adjustment"
        Me.gridBand6.Columns.Add(Me.BandedGridColumnBonus)
        Me.gridBand6.Columns.Add(Me.BandedGridColumnAdjustment)
        Me.gridBand6.Columns.Add(Me.BandedGridColumnRapel)
        Me.gridBand6.Columns.Add(Me.BandedGridColumnCuti)
        Me.gridBand6.Columns.Add(Me.BandedGridColumnTotalAdjustment)
        Me.gridBand6.Name = "gridBand6"
        Me.gridBand6.VisibleIndex = 4
        Me.gridBand6.Width = 375
        '
        'BandedGridColumnBonus
        '
        Me.BandedGridColumnBonus.AppearanceCell.Options.UseTextOptions = True
        Me.BandedGridColumnBonus.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.BandedGridColumnBonus.AppearanceHeader.Options.UseTextOptions = True
        Me.BandedGridColumnBonus.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.BandedGridColumnBonus.Caption = "Bonus"
        Me.BandedGridColumnBonus.DisplayFormat.FormatString = "N0"
        Me.BandedGridColumnBonus.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.BandedGridColumnBonus.FieldName = "a_bonus"
        Me.BandedGridColumnBonus.Name = "BandedGridColumnBonus"
        Me.BandedGridColumnBonus.OptionsColumn.ReadOnly = True
        Me.BandedGridColumnBonus.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "a_bonus", "{0:N0}")})
        Me.BandedGridColumnBonus.Visible = True
        '
        'BandedGridColumnAdjustment
        '
        Me.BandedGridColumnAdjustment.AppearanceCell.Options.UseTextOptions = True
        Me.BandedGridColumnAdjustment.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.BandedGridColumnAdjustment.AppearanceHeader.Options.UseTextOptions = True
        Me.BandedGridColumnAdjustment.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.BandedGridColumnAdjustment.Caption = "Adjustment"
        Me.BandedGridColumnAdjustment.DisplayFormat.FormatString = "N0"
        Me.BandedGridColumnAdjustment.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.BandedGridColumnAdjustment.FieldName = "a_adjustment"
        Me.BandedGridColumnAdjustment.Name = "BandedGridColumnAdjustment"
        Me.BandedGridColumnAdjustment.OptionsColumn.ReadOnly = True
        Me.BandedGridColumnAdjustment.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "a_adjustment", "{0:N0}")})
        Me.BandedGridColumnAdjustment.Visible = True
        '
        'BandedGridColumnRapel
        '
        Me.BandedGridColumnRapel.AppearanceCell.Options.UseTextOptions = True
        Me.BandedGridColumnRapel.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.BandedGridColumnRapel.AppearanceHeader.Options.UseTextOptions = True
        Me.BandedGridColumnRapel.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.BandedGridColumnRapel.Caption = "Rapel"
        Me.BandedGridColumnRapel.DisplayFormat.FormatString = "N0"
        Me.BandedGridColumnRapel.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.BandedGridColumnRapel.FieldName = "a_rapel"
        Me.BandedGridColumnRapel.Name = "BandedGridColumnRapel"
        Me.BandedGridColumnRapel.OptionsColumn.ReadOnly = True
        Me.BandedGridColumnRapel.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "a_rapel", "{0:N0}")})
        Me.BandedGridColumnRapel.Visible = True
        '
        'BandedGridColumnCuti
        '
        Me.BandedGridColumnCuti.AppearanceCell.Options.UseTextOptions = True
        Me.BandedGridColumnCuti.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.BandedGridColumnCuti.AppearanceHeader.Options.UseTextOptions = True
        Me.BandedGridColumnCuti.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.BandedGridColumnCuti.Caption = "Cuti"
        Me.BandedGridColumnCuti.DisplayFormat.FormatString = "N0"
        Me.BandedGridColumnCuti.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.BandedGridColumnCuti.FieldName = "a_cuti"
        Me.BandedGridColumnCuti.Name = "BandedGridColumnCuti"
        Me.BandedGridColumnCuti.OptionsColumn.ReadOnly = True
        Me.BandedGridColumnCuti.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "a_cuti", "{0:N0}")})
        Me.BandedGridColumnCuti.Visible = True
        '
        'BandedGridColumnTotalAdjustment
        '
        Me.BandedGridColumnTotalAdjustment.AppearanceCell.Options.UseTextOptions = True
        Me.BandedGridColumnTotalAdjustment.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.BandedGridColumnTotalAdjustment.AppearanceHeader.Options.UseTextOptions = True
        Me.BandedGridColumnTotalAdjustment.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.BandedGridColumnTotalAdjustment.Caption = "Total Bonus & Adjustment"
        Me.BandedGridColumnTotalAdjustment.DisplayFormat.FormatString = "N2"
        Me.BandedGridColumnTotalAdjustment.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.BandedGridColumnTotalAdjustment.FieldName = "total_adjustment"
        Me.BandedGridColumnTotalAdjustment.Name = "BandedGridColumnTotalAdjustment"
        Me.BandedGridColumnTotalAdjustment.OptionsColumn.ReadOnly = True
        Me.BandedGridColumnTotalAdjustment.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "total_adjustment", "{0:N2}")})
        Me.BandedGridColumnTotalAdjustment.Visible = True
        '
        'gridBand3
        '
        Me.gridBand3.AppearanceHeader.Options.UseTextOptions = True
        Me.gridBand3.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.gridBand3.Caption = "Overtime Detail"
        Me.gridBand3.Columns.Add(Me.GridColumnPointRegular)
        Me.gridBand3.Columns.Add(Me.GridColumnOTReguler)
        Me.gridBand3.Columns.Add(Me.GridColumnPointMkt)
        Me.gridBand3.Columns.Add(Me.GridColumnOtMkt)
        Me.gridBand3.Columns.Add(Me.GridColumnPointIA)
        Me.gridBand3.Columns.Add(Me.GridColumnOtIA)
        Me.gridBand3.Columns.Add(Me.GridColumnPointSales)
        Me.gridBand3.Columns.Add(Me.GridColumnOtSales)
        Me.gridBand3.Columns.Add(Me.GridColumnPointProd)
        Me.gridBand3.Columns.Add(Me.GridColumnOTProd)
        Me.gridBand3.Columns.Add(Me.GridColumnPointGeneral)
        Me.gridBand3.Columns.Add(Me.GridColumnOtGeneral)
        Me.gridBand3.Columns.Add(Me.BandedGridColumnTotalPaymentOt)
        Me.gridBand3.Name = "gridBand3"
        Me.gridBand3.VisibleIndex = 5
        Me.gridBand3.Width = 975
        '
        'GridColumnPointRegular
        '
        Me.GridColumnPointRegular.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumnPointRegular.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumnPointRegular.AppearanceHeader.Options.UseTextOptions = True
        Me.GridColumnPointRegular.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumnPointRegular.Caption = "Point Reguler"
        Me.GridColumnPointRegular.DisplayFormat.FormatString = "N2"
        Me.GridColumnPointRegular.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumnPointRegular.FieldName = "reg_total_point"
        Me.GridColumnPointRegular.Name = "GridColumnPointRegular"
        Me.GridColumnPointRegular.OptionsColumn.ReadOnly = True
        Me.GridColumnPointRegular.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "reg_total_point", "{0:N2}")})
        Me.GridColumnPointRegular.Visible = True
        '
        'GridColumnOTReguler
        '
        Me.GridColumnOTReguler.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumnOTReguler.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumnOTReguler.AppearanceHeader.Options.UseTextOptions = True
        Me.GridColumnOTReguler.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumnOTReguler.Caption = "Overtime Reguler"
        Me.GridColumnOTReguler.DisplayFormat.FormatString = "N2"
        Me.GridColumnOTReguler.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumnOTReguler.FieldName = "reg_total_wages"
        Me.GridColumnOTReguler.Name = "GridColumnOTReguler"
        Me.GridColumnOTReguler.OptionsColumn.ReadOnly = True
        Me.GridColumnOTReguler.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "reg_total_wages", "{0:N2}")})
        Me.GridColumnOTReguler.Visible = True
        '
        'GridColumnPointMkt
        '
        Me.GridColumnPointMkt.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumnPointMkt.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumnPointMkt.AppearanceHeader.Options.UseTextOptions = True
        Me.GridColumnPointMkt.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumnPointMkt.Caption = "Point Event Marketing"
        Me.GridColumnPointMkt.DisplayFormat.FormatString = "N2"
        Me.GridColumnPointMkt.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumnPointMkt.FieldName = "mkt_total_point"
        Me.GridColumnPointMkt.Name = "GridColumnPointMkt"
        Me.GridColumnPointMkt.OptionsColumn.ReadOnly = True
        Me.GridColumnPointMkt.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "mkt_total_point", "{0:N2}")})
        Me.GridColumnPointMkt.Visible = True
        '
        'GridColumnOtMkt
        '
        Me.GridColumnOtMkt.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumnOtMkt.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumnOtMkt.AppearanceHeader.Options.UseTextOptions = True
        Me.GridColumnOtMkt.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumnOtMkt.Caption = "Overtime Marketing"
        Me.GridColumnOtMkt.DisplayFormat.FormatString = "N2"
        Me.GridColumnOtMkt.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumnOtMkt.FieldName = "mkt_total_wages"
        Me.GridColumnOtMkt.Name = "GridColumnOtMkt"
        Me.GridColumnOtMkt.OptionsColumn.ReadOnly = True
        Me.GridColumnOtMkt.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "mkt_total_wages", "{0:N2}")})
        Me.GridColumnOtMkt.Visible = True
        '
        'GridColumnPointIA
        '
        Me.GridColumnPointIA.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumnPointIA.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumnPointIA.AppearanceHeader.Options.UseTextOptions = True
        Me.GridColumnPointIA.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumnPointIA.Caption = "Point Event IA"
        Me.GridColumnPointIA.DisplayFormat.FormatString = "N2"
        Me.GridColumnPointIA.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumnPointIA.FieldName = "ia_total_point"
        Me.GridColumnPointIA.Name = "GridColumnPointIA"
        Me.GridColumnPointIA.OptionsColumn.ReadOnly = True
        Me.GridColumnPointIA.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "ia_total_point", "{0:N2}")})
        Me.GridColumnPointIA.Visible = True
        '
        'GridColumnOtIA
        '
        Me.GridColumnOtIA.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumnOtIA.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumnOtIA.AppearanceHeader.Options.UseTextOptions = True
        Me.GridColumnOtIA.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumnOtIA.Caption = "Overtime IA"
        Me.GridColumnOtIA.DisplayFormat.FormatString = "N2"
        Me.GridColumnOtIA.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumnOtIA.FieldName = "ia_total_wages"
        Me.GridColumnOtIA.Name = "GridColumnOtIA"
        Me.GridColumnOtIA.OptionsColumn.ReadOnly = True
        Me.GridColumnOtIA.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "ia_total_wages", "{0:N2}")})
        Me.GridColumnOtIA.Visible = True
        '
        'GridColumnPointSales
        '
        Me.GridColumnPointSales.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumnPointSales.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumnPointSales.AppearanceHeader.Options.UseTextOptions = True
        Me.GridColumnPointSales.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumnPointSales.Caption = "Point Event Sales"
        Me.GridColumnPointSales.DisplayFormat.FormatString = "N2"
        Me.GridColumnPointSales.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumnPointSales.FieldName = "sales_total_point"
        Me.GridColumnPointSales.Name = "GridColumnPointSales"
        Me.GridColumnPointSales.OptionsColumn.ReadOnly = True
        Me.GridColumnPointSales.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "sales_total_point", "{0:N2}")})
        Me.GridColumnPointSales.Visible = True
        '
        'GridColumnOtSales
        '
        Me.GridColumnOtSales.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumnOtSales.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumnOtSales.AppearanceHeader.Options.UseTextOptions = True
        Me.GridColumnOtSales.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumnOtSales.Caption = "Overtime Sales"
        Me.GridColumnOtSales.DisplayFormat.FormatString = "N2"
        Me.GridColumnOtSales.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumnOtSales.FieldName = "sales_total_wages"
        Me.GridColumnOtSales.Name = "GridColumnOtSales"
        Me.GridColumnOtSales.OptionsColumn.ReadOnly = True
        Me.GridColumnOtSales.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "sales_total_wages", "{0:N2}")})
        Me.GridColumnOtSales.Visible = True
        '
        'GridColumnPointProd
        '
        Me.GridColumnPointProd.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumnPointProd.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumnPointProd.AppearanceHeader.Options.UseTextOptions = True
        Me.GridColumnPointProd.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumnPointProd.Caption = "Point Event Production"
        Me.GridColumnPointProd.DisplayFormat.FormatString = "N2"
        Me.GridColumnPointProd.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumnPointProd.FieldName = "prod_total_point"
        Me.GridColumnPointProd.Name = "GridColumnPointProd"
        Me.GridColumnPointProd.OptionsColumn.ReadOnly = True
        Me.GridColumnPointProd.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "prod_total_point", "{0:N2}")})
        Me.GridColumnPointProd.Visible = True
        '
        'GridColumnOTProd
        '
        Me.GridColumnOTProd.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumnOTProd.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumnOTProd.AppearanceHeader.Options.UseTextOptions = True
        Me.GridColumnOTProd.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumnOTProd.Caption = "Overtime Production"
        Me.GridColumnOTProd.DisplayFormat.FormatString = "N2"
        Me.GridColumnOTProd.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumnOTProd.FieldName = "prod_total_wages"
        Me.GridColumnOTProd.Name = "GridColumnOTProd"
        Me.GridColumnOTProd.OptionsColumn.ReadOnly = True
        Me.GridColumnOTProd.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "prod_total_wages", "{0:N2}")})
        Me.GridColumnOTProd.Visible = True
        '
        'GridColumnPointGeneral
        '
        Me.GridColumnPointGeneral.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumnPointGeneral.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumnPointGeneral.AppearanceHeader.Options.UseTextOptions = True
        Me.GridColumnPointGeneral.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumnPointGeneral.Caption = "Point Event General/Other"
        Me.GridColumnPointGeneral.DisplayFormat.FormatString = "N2"
        Me.GridColumnPointGeneral.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumnPointGeneral.FieldName = "general_total_point"
        Me.GridColumnPointGeneral.Name = "GridColumnPointGeneral"
        Me.GridColumnPointGeneral.OptionsColumn.ReadOnly = True
        Me.GridColumnPointGeneral.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "general_total_point", "{0:N2}")})
        Me.GridColumnPointGeneral.Visible = True
        '
        'GridColumnOtGeneral
        '
        Me.GridColumnOtGeneral.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumnOtGeneral.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumnOtGeneral.AppearanceHeader.Options.UseTextOptions = True
        Me.GridColumnOtGeneral.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumnOtGeneral.Caption = "Overtime General/Other"
        Me.GridColumnOtGeneral.DisplayFormat.FormatString = "N2"
        Me.GridColumnOtGeneral.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumnOtGeneral.FieldName = "general_total_wages"
        Me.GridColumnOtGeneral.Name = "GridColumnOtGeneral"
        Me.GridColumnOtGeneral.OptionsColumn.ReadOnly = True
        Me.GridColumnOtGeneral.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "general_total_wages", "{0:N2}")})
        Me.GridColumnOtGeneral.Visible = True
        '
        'BandedGridColumnTotalPaymentOt
        '
        Me.BandedGridColumnTotalPaymentOt.AppearanceCell.Options.UseTextOptions = True
        Me.BandedGridColumnTotalPaymentOt.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.BandedGridColumnTotalPaymentOt.AppearanceHeader.Options.UseTextOptions = True
        Me.BandedGridColumnTotalPaymentOt.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.BandedGridColumnTotalPaymentOt.Caption = "Total Payment Overtime"
        Me.BandedGridColumnTotalPaymentOt.DisplayFormat.FormatString = "N2"
        Me.BandedGridColumnTotalPaymentOt.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.BandedGridColumnTotalPaymentOt.FieldName = "total_ot_wages"
        Me.BandedGridColumnTotalPaymentOt.Name = "BandedGridColumnTotalPaymentOt"
        Me.BandedGridColumnTotalPaymentOt.OptionsColumn.ReadOnly = True
        Me.BandedGridColumnTotalPaymentOt.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "total_ot_wages", "{0:N2}")})
        Me.BandedGridColumnTotalPaymentOt.Visible = True
        '
        'gridBand4
        '
        Me.gridBand4.AppearanceHeader.Options.UseTextOptions = True
        Me.gridBand4.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.gridBand4.Caption = "Potongan"
        Me.gridBand4.Columns.Add(Me.BandedGridColumnBPJS)
        Me.gridBand4.Columns.Add(Me.BandedGridColumnJHT)
        Me.gridBand4.Columns.Add(Me.BandedGridColumnJP)
        Me.gridBand4.Columns.Add(Me.BandedGridColumnTotJamsostek)
        Me.gridBand4.Columns.Add(Me.GridColumnIuranKoperasi)
        Me.gridBand4.Columns.Add(Me.GridColumnPinjamanKoperasi)
        Me.gridBand4.Columns.Add(Me.GridColumnUniform)
        Me.gridBand4.Columns.Add(Me.GridColumnWHSale)
        Me.gridBand4.Columns.Add(Me.GridColumnKasBon)
        Me.gridBand4.Columns.Add(Me.GridColumnREIKI)
        Me.gridBand4.Columns.Add(Me.GridColumnSPT)
        Me.gridBand4.Columns.Add(Me.GridColumnMissing)
        Me.gridBand4.Columns.Add(Me.GridColumnPotLain2)
        Me.gridBand4.Columns.Add(Me.BandedGridColumnTotalDeduction)
        Me.gridBand4.Name = "gridBand4"
        Me.gridBand4.VisibleIndex = 6
        Me.gridBand4.Width = 1050
        '
        'BandedGridColumnBPJS
        '
        Me.BandedGridColumnBPJS.AppearanceCell.Options.UseTextOptions = True
        Me.BandedGridColumnBPJS.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.BandedGridColumnBPJS.AppearanceHeader.Options.UseTextOptions = True
        Me.BandedGridColumnBPJS.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.BandedGridColumnBPJS.Caption = "BPJS"
        Me.BandedGridColumnBPJS.DisplayFormat.FormatString = "N0"
        Me.BandedGridColumnBPJS.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.BandedGridColumnBPJS.FieldName = "d_bpjs"
        Me.BandedGridColumnBPJS.Name = "BandedGridColumnBPJS"
        Me.BandedGridColumnBPJS.OptionsColumn.ReadOnly = True
        Me.BandedGridColumnBPJS.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "d_bpjs", "{0:N0}")})
        Me.BandedGridColumnBPJS.Visible = True
        '
        'BandedGridColumnJHT
        '
        Me.BandedGridColumnJHT.AppearanceCell.Options.UseTextOptions = True
        Me.BandedGridColumnJHT.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.BandedGridColumnJHT.AppearanceHeader.Options.UseTextOptions = True
        Me.BandedGridColumnJHT.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.BandedGridColumnJHT.Caption = "JHT"
        Me.BandedGridColumnJHT.DisplayFormat.FormatString = "N0"
        Me.BandedGridColumnJHT.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.BandedGridColumnJHT.FieldName = "d_jht"
        Me.BandedGridColumnJHT.Name = "BandedGridColumnJHT"
        Me.BandedGridColumnJHT.OptionsColumn.ReadOnly = True
        Me.BandedGridColumnJHT.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "d_jht", "{0:N0}")})
        Me.BandedGridColumnJHT.Visible = True
        '
        'BandedGridColumnJP
        '
        Me.BandedGridColumnJP.AppearanceCell.Options.UseTextOptions = True
        Me.BandedGridColumnJP.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.BandedGridColumnJP.AppearanceHeader.Options.UseTextOptions = True
        Me.BandedGridColumnJP.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.BandedGridColumnJP.Caption = "JP"
        Me.BandedGridColumnJP.DisplayFormat.FormatString = "N0"
        Me.BandedGridColumnJP.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.BandedGridColumnJP.FieldName = "d_jp"
        Me.BandedGridColumnJP.Name = "BandedGridColumnJP"
        Me.BandedGridColumnJP.OptionsColumn.ReadOnly = True
        Me.BandedGridColumnJP.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "d_jp", "{0:N0}")})
        Me.BandedGridColumnJP.Visible = True
        '
        'BandedGridColumnTotJamsostek
        '
        Me.BandedGridColumnTotJamsostek.AppearanceCell.Options.UseTextOptions = True
        Me.BandedGridColumnTotJamsostek.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.BandedGridColumnTotJamsostek.AppearanceHeader.Options.UseTextOptions = True
        Me.BandedGridColumnTotJamsostek.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.BandedGridColumnTotJamsostek.Caption = "Total Jamsostek"
        Me.BandedGridColumnTotJamsostek.DisplayFormat.FormatString = "N0"
        Me.BandedGridColumnTotJamsostek.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.BandedGridColumnTotJamsostek.FieldName = "d_jamsostek"
        Me.BandedGridColumnTotJamsostek.Name = "BandedGridColumnTotJamsostek"
        Me.BandedGridColumnTotJamsostek.OptionsColumn.ReadOnly = True
        Me.BandedGridColumnTotJamsostek.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "d_jamsostek", "{0:N0}")})
        Me.BandedGridColumnTotJamsostek.Visible = True
        '
        'GridColumnIuranKoperasi
        '
        Me.GridColumnIuranKoperasi.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumnIuranKoperasi.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumnIuranKoperasi.AppearanceHeader.Options.UseTextOptions = True
        Me.GridColumnIuranKoperasi.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumnIuranKoperasi.Caption = "Iuran Koperasi"
        Me.GridColumnIuranKoperasi.DisplayFormat.FormatString = "N0"
        Me.GridColumnIuranKoperasi.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumnIuranKoperasi.FieldName = "d_iuran_koperasi"
        Me.GridColumnIuranKoperasi.Name = "GridColumnIuranKoperasi"
        Me.GridColumnIuranKoperasi.OptionsColumn.ReadOnly = True
        Me.GridColumnIuranKoperasi.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "d_iuran_koperasi", "{0:N0}")})
        Me.GridColumnIuranKoperasi.Visible = True
        '
        'GridColumnPinjamanKoperasi
        '
        Me.GridColumnPinjamanKoperasi.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumnPinjamanKoperasi.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumnPinjamanKoperasi.AppearanceHeader.Options.UseTextOptions = True
        Me.GridColumnPinjamanKoperasi.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumnPinjamanKoperasi.Caption = "Pinjaman Koperasi"
        Me.GridColumnPinjamanKoperasi.DisplayFormat.FormatString = "N0"
        Me.GridColumnPinjamanKoperasi.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumnPinjamanKoperasi.FieldName = "d_pinjaman_koperasi"
        Me.GridColumnPinjamanKoperasi.Name = "GridColumnPinjamanKoperasi"
        Me.GridColumnPinjamanKoperasi.OptionsColumn.ReadOnly = True
        Me.GridColumnPinjamanKoperasi.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "d_pinjaman_koperasi", "{0:N0}")})
        Me.GridColumnPinjamanKoperasi.Visible = True
        '
        'GridColumnUniform
        '
        Me.GridColumnUniform.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumnUniform.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumnUniform.AppearanceHeader.Options.UseTextOptions = True
        Me.GridColumnUniform.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumnUniform.Caption = "Uniform"
        Me.GridColumnUniform.DisplayFormat.FormatString = "N0"
        Me.GridColumnUniform.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumnUniform.FieldName = "d_uniform"
        Me.GridColumnUniform.Name = "GridColumnUniform"
        Me.GridColumnUniform.OptionsColumn.ReadOnly = True
        Me.GridColumnUniform.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "d_uniform", "{0:N0}")})
        Me.GridColumnUniform.Visible = True
        '
        'GridColumnWHSale
        '
        Me.GridColumnWHSale.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumnWHSale.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumnWHSale.AppearanceHeader.Options.UseTextOptions = True
        Me.GridColumnWHSale.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumnWHSale.Caption = "WH Sale"
        Me.GridColumnWHSale.DisplayFormat.FormatString = "N0"
        Me.GridColumnWHSale.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumnWHSale.FieldName = "d_wh_sale"
        Me.GridColumnWHSale.Name = "GridColumnWHSale"
        Me.GridColumnWHSale.OptionsColumn.ReadOnly = True
        Me.GridColumnWHSale.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "d_wh_sale", "{0:N0}")})
        Me.GridColumnWHSale.Visible = True
        '
        'GridColumnKasBon
        '
        Me.GridColumnKasBon.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumnKasBon.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumnKasBon.AppearanceHeader.Options.UseTextOptions = True
        Me.GridColumnKasBon.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumnKasBon.Caption = "Kas Bon"
        Me.GridColumnKasBon.DisplayFormat.FormatString = "N0"
        Me.GridColumnKasBon.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumnKasBon.FieldName = "d_kasbon"
        Me.GridColumnKasBon.Name = "GridColumnKasBon"
        Me.GridColumnKasBon.OptionsColumn.ReadOnly = True
        Me.GridColumnKasBon.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "d_kasbon", "{0:N0}")})
        Me.GridColumnKasBon.Visible = True
        '
        'GridColumnREIKI
        '
        Me.GridColumnREIKI.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumnREIKI.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumnREIKI.AppearanceHeader.Options.UseTextOptions = True
        Me.GridColumnREIKI.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumnREIKI.Caption = "REIKI"
        Me.GridColumnREIKI.DisplayFormat.FormatString = "N0"
        Me.GridColumnREIKI.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumnREIKI.FieldName = "d_reiki"
        Me.GridColumnREIKI.Name = "GridColumnREIKI"
        Me.GridColumnREIKI.OptionsColumn.ReadOnly = True
        Me.GridColumnREIKI.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "d_reiki", "{0:N0}")})
        Me.GridColumnREIKI.Visible = True
        '
        'GridColumnSPT
        '
        Me.GridColumnSPT.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumnSPT.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumnSPT.AppearanceHeader.Options.UseTextOptions = True
        Me.GridColumnSPT.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumnSPT.Caption = "SPT"
        Me.GridColumnSPT.DisplayFormat.FormatString = "N0"
        Me.GridColumnSPT.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumnSPT.FieldName = "d_spt"
        Me.GridColumnSPT.Name = "GridColumnSPT"
        Me.GridColumnSPT.OptionsColumn.ReadOnly = True
        Me.GridColumnSPT.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "d_spt", "{0:N0}")})
        Me.GridColumnSPT.Visible = True
        '
        'GridColumnMissing
        '
        Me.GridColumnMissing.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumnMissing.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumnMissing.AppearanceHeader.Options.UseTextOptions = True
        Me.GridColumnMissing.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumnMissing.Caption = "Tabungan Missing"
        Me.GridColumnMissing.DisplayFormat.FormatString = "N0"
        Me.GridColumnMissing.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumnMissing.FieldName = "d_tab_missing"
        Me.GridColumnMissing.Name = "GridColumnMissing"
        Me.GridColumnMissing.OptionsColumn.ReadOnly = True
        Me.GridColumnMissing.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "d_tab_missing", "{0:N0}")})
        Me.GridColumnMissing.Visible = True
        '
        'GridColumnPotLain2
        '
        Me.GridColumnPotLain2.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumnPotLain2.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumnPotLain2.AppearanceHeader.Options.UseTextOptions = True
        Me.GridColumnPotLain2.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumnPotLain2.Caption = "Potongan Lain-lain"
        Me.GridColumnPotLain2.DisplayFormat.FormatString = "N0"
        Me.GridColumnPotLain2.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumnPotLain2.FieldName = "d_pot_lain"
        Me.GridColumnPotLain2.Name = "GridColumnPotLain2"
        Me.GridColumnPotLain2.OptionsColumn.ReadOnly = True
        Me.GridColumnPotLain2.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "d_pot_lain", "{0:N0}")})
        Me.GridColumnPotLain2.Visible = True
        '
        'BandedGridColumnTotalDeduction
        '
        Me.BandedGridColumnTotalDeduction.AppearanceCell.Options.UseTextOptions = True
        Me.BandedGridColumnTotalDeduction.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.BandedGridColumnTotalDeduction.AppearanceHeader.Options.UseTextOptions = True
        Me.BandedGridColumnTotalDeduction.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.BandedGridColumnTotalDeduction.Caption = "Total Deduction"
        Me.BandedGridColumnTotalDeduction.DisplayFormat.FormatString = "N2"
        Me.BandedGridColumnTotalDeduction.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.BandedGridColumnTotalDeduction.FieldName = "total_deduction"
        Me.BandedGridColumnTotalDeduction.Name = "BandedGridColumnTotalDeduction"
        Me.BandedGridColumnTotalDeduction.OptionsColumn.ReadOnly = True
        Me.BandedGridColumnTotalDeduction.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "total_deduction", "{0:N2}")})
        Me.BandedGridColumnTotalDeduction.Visible = True
        '
        'gridBand9
        '
        Me.gridBand9.Caption = "Total"
        Me.gridBand9.Columns.Add(Me.BandedGridColumnGrandTotal)
        Me.gridBand9.Name = "gridBand9"
        Me.gridBand9.VisibleIndex = 7
        Me.gridBand9.Width = 75
        '
        'BandedGridColumnGrandTotal
        '
        Me.BandedGridColumnGrandTotal.AppearanceCell.Options.UseTextOptions = True
        Me.BandedGridColumnGrandTotal.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.BandedGridColumnGrandTotal.AppearanceHeader.Options.UseTextOptions = True
        Me.BandedGridColumnGrandTotal.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.BandedGridColumnGrandTotal.Caption = "Grand Total"
        Me.BandedGridColumnGrandTotal.DisplayFormat.FormatString = "N2"
        Me.BandedGridColumnGrandTotal.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.BandedGridColumnGrandTotal.FieldName = "grand_total"
        Me.BandedGridColumnGrandTotal.Name = "BandedGridColumnGrandTotal"
        Me.BandedGridColumnGrandTotal.OptionsColumn.ReadOnly = True
        Me.BandedGridColumnGrandTotal.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "grand_total", "{0:N2}")})
        Me.BandedGridColumnGrandTotal.Visible = True
        '
        'gridBand7
        '
        Me.gridBand7.Caption = "Extra Note"
        Me.gridBand7.Columns.Add(Me.BandedGridColumnPending)
        Me.gridBand7.Name = "gridBand7"
        Me.gridBand7.VisibleIndex = 8
        Me.gridBand7.Width = 75
        '
        'BandedGridColumnPending
        '
        Me.BandedGridColumnPending.Caption = "Pending"
        Me.BandedGridColumnPending.ColumnEdit = Me.RICEPending
        Me.BandedGridColumnPending.FieldName = "is_pending"
        Me.BandedGridColumnPending.Name = "BandedGridColumnPending"
        Me.BandedGridColumnPending.Visible = True
        '
        'PanelControl2
        '
        Me.PanelControl2.Controls.Add(Me.BPrintSlip)
        Me.PanelControl2.Controls.Add(Me.PCSelAll)
        Me.PanelControl2.Controls.Add(Me.PBCLineList)
        Me.PanelControl2.Controls.Add(Me.BPrint)
        Me.PanelControl2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PanelControl2.Location = New System.Drawing.Point(0, 402)
        Me.PanelControl2.Name = "PanelControl2"
        Me.PanelControl2.Size = New System.Drawing.Size(1115, 39)
        Me.PanelControl2.TabIndex = 2
        '
        'BPrintSlip
        '
        Me.BPrintSlip.Dock = System.Windows.Forms.DockStyle.Right
        Me.BPrintSlip.ImageIndex = 6
        Me.BPrintSlip.ImageList = Me.LargeImageCollection
        Me.BPrintSlip.Location = New System.Drawing.Point(907, 2)
        Me.BPrintSlip.Name = "BPrintSlip"
        Me.BPrintSlip.Size = New System.Drawing.Size(103, 35)
        Me.BPrintSlip.TabIndex = 106
        Me.BPrintSlip.Text = "Print Slip"
        '
        'LargeImageCollection
        '
        Me.LargeImageCollection.ImageSize = New System.Drawing.Size(24, 24)
        Me.LargeImageCollection.ImageStream = CType(resources.GetObject("LargeImageCollection.ImageStream"), DevExpress.Utils.ImageCollectionStreamer)
        Me.LargeImageCollection.Images.SetKeyName(0, "20_24x24.png")
        Me.LargeImageCollection.Images.SetKeyName(1, "8_24x24.png")
        Me.LargeImageCollection.Images.SetKeyName(2, "23_24x24.png")
        Me.LargeImageCollection.Images.SetKeyName(3, "arrow_refresh.png")
        Me.LargeImageCollection.Images.SetKeyName(4, "check_mark.png")
        Me.LargeImageCollection.Images.SetKeyName(5, "gnome_application_exit (1).png")
        Me.LargeImageCollection.Images.SetKeyName(6, "printer_3.png")
        Me.LargeImageCollection.Images.SetKeyName(7, "save.png")
        Me.LargeImageCollection.Images.SetKeyName(8, "31_24x24.png")
        Me.LargeImageCollection.Images.SetKeyName(9, "18_24x24.png")
        Me.LargeImageCollection.Images.SetKeyName(10, "1415351112474759854-32.png")
        Me.LargeImageCollection.Images.SetKeyName(11, "icon_merchandise_clothes32.png")
        Me.LargeImageCollection.Images.SetKeyName(12, "t_shirtgreen.png")
        Me.LargeImageCollection.Images.SetKeyName(13, "lock red.png")
        Me.LargeImageCollection.Images.SetKeyName(14, "ordering32.png")
        Me.LargeImageCollection.Images.SetKeyName(15, "kghostview.png")
        Me.LargeImageCollection.Images.SetKeyName(16, "MetroUI-Folder-OS-Configure-icon.png")
        Me.LargeImageCollection.Images.SetKeyName(17, "Setting(32).png")
        Me.LargeImageCollection.Images.SetKeyName(18, "estimate_icon32.png")
        Me.LargeImageCollection.Images.SetKeyName(19, "copy_icon.png")
        '
        'PCSelAll
        '
        Me.PCSelAll.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
        Me.PCSelAll.Controls.Add(Me.CheckEditSelAll)
        Me.PCSelAll.Dock = System.Windows.Forms.DockStyle.Left
        Me.PCSelAll.Location = New System.Drawing.Point(150, 2)
        Me.PCSelAll.Name = "PCSelAll"
        Me.PCSelAll.Size = New System.Drawing.Size(99, 35)
        Me.PCSelAll.TabIndex = 105
        '
        'CheckEditSelAll
        '
        Me.CheckEditSelAll.Location = New System.Drawing.Point(5, 7)
        Me.CheckEditSelAll.Name = "CheckEditSelAll"
        Me.CheckEditSelAll.Properties.Caption = "Select All"
        Me.CheckEditSelAll.Size = New System.Drawing.Size(92, 19)
        Me.CheckEditSelAll.TabIndex = 102
        '
        'PBCLineList
        '
        Me.PBCLineList.Dock = System.Windows.Forms.DockStyle.Left
        Me.PBCLineList.Location = New System.Drawing.Point(2, 2)
        Me.PBCLineList.Name = "PBCLineList"
        Me.PBCLineList.Properties.ShowTitle = True
        Me.PBCLineList.Size = New System.Drawing.Size(148, 35)
        Me.PBCLineList.TabIndex = 104
        Me.PBCLineList.Visible = False
        '
        'BPrint
        '
        Me.BPrint.Dock = System.Windows.Forms.DockStyle.Right
        Me.BPrint.ImageIndex = 6
        Me.BPrint.ImageList = Me.LargeImageCollection
        Me.BPrint.Location = New System.Drawing.Point(1010, 2)
        Me.BPrint.Name = "BPrint"
        Me.BPrint.Size = New System.Drawing.Size(103, 35)
        Me.BPrint.TabIndex = 0
        Me.BPrint.Text = "Print"
        Me.BPrint.Visible = False
        '
        'PanelControl1
        '
        Me.PanelControl1.Controls.Add(Me.BUpdateActualWorkingDays)
        Me.PanelControl1.Controls.Add(Me.BBonusAdjustment)
        Me.PanelControl1.Controls.Add(Me.BDeduction)
        Me.PanelControl1.Controls.Add(Me.BRemoveEmployee)
        Me.PanelControl1.Controls.Add(Me.BGetEmployee)
        Me.PanelControl1.Controls.Add(Me.BOvertime)
        Me.PanelControl1.Controls.Add(Me.BSetting)
        Me.PanelControl1.Dock = System.Windows.Forms.DockStyle.Top
        Me.PanelControl1.Location = New System.Drawing.Point(0, 0)
        Me.PanelControl1.Name = "PanelControl1"
        Me.PanelControl1.Size = New System.Drawing.Size(1115, 39)
        Me.PanelControl1.TabIndex = 0
        '
        'BUpdateActualWorkingDays
        '
        Me.BUpdateActualWorkingDays.Dock = System.Windows.Forms.DockStyle.Left
        Me.BUpdateActualWorkingDays.ImageIndex = 3
        Me.BUpdateActualWorkingDays.ImageList = Me.LargeImageCollection
        Me.BUpdateActualWorkingDays.Location = New System.Drawing.Point(271, 2)
        Me.BUpdateActualWorkingDays.Name = "BUpdateActualWorkingDays"
        Me.BUpdateActualWorkingDays.Size = New System.Drawing.Size(181, 35)
        Me.BUpdateActualWorkingDays.TabIndex = 6
        Me.BUpdateActualWorkingDays.Text = "Update Actual Working Days"
        Me.BUpdateActualWorkingDays.Visible = False
        '
        'BBonusAdjustment
        '
        Me.BBonusAdjustment.Dock = System.Windows.Forms.DockStyle.Right
        Me.BBonusAdjustment.ImageIndex = 14
        Me.BBonusAdjustment.ImageList = Me.LargeImageCollection
        Me.BBonusAdjustment.Location = New System.Drawing.Point(661, 2)
        Me.BBonusAdjustment.Name = "BBonusAdjustment"
        Me.BBonusAdjustment.Size = New System.Drawing.Size(147, 35)
        Me.BBonusAdjustment.TabIndex = 5
        Me.BBonusAdjustment.Text = "Bonus / Adjustment"
        '
        'BDeduction
        '
        Me.BDeduction.Dock = System.Windows.Forms.DockStyle.Right
        Me.BDeduction.ImageIndex = 14
        Me.BDeduction.ImageList = Me.LargeImageCollection
        Me.BDeduction.Location = New System.Drawing.Point(808, 2)
        Me.BDeduction.Name = "BDeduction"
        Me.BDeduction.Size = New System.Drawing.Size(101, 35)
        Me.BDeduction.TabIndex = 4
        Me.BDeduction.Text = "Deduction"
        '
        'BRemoveEmployee
        '
        Me.BRemoveEmployee.Dock = System.Windows.Forms.DockStyle.Left
        Me.BRemoveEmployee.ImageIndex = 1
        Me.BRemoveEmployee.ImageList = Me.LargeImageCollection
        Me.BRemoveEmployee.Location = New System.Drawing.Point(130, 2)
        Me.BRemoveEmployee.Name = "BRemoveEmployee"
        Me.BRemoveEmployee.Size = New System.Drawing.Size(141, 35)
        Me.BRemoveEmployee.TabIndex = 2
        Me.BRemoveEmployee.Text = "Remove Employee"
        '
        'BGetEmployee
        '
        Me.BGetEmployee.Dock = System.Windows.Forms.DockStyle.Left
        Me.BGetEmployee.ImageIndex = 19
        Me.BGetEmployee.ImageList = Me.LargeImageCollection
        Me.BGetEmployee.Location = New System.Drawing.Point(2, 2)
        Me.BGetEmployee.Name = "BGetEmployee"
        Me.BGetEmployee.Size = New System.Drawing.Size(128, 35)
        Me.BGetEmployee.TabIndex = 3
        Me.BGetEmployee.Text = "Insert Employee"
        '
        'BOvertime
        '
        Me.BOvertime.Dock = System.Windows.Forms.DockStyle.Right
        Me.BOvertime.ImageIndex = 18
        Me.BOvertime.ImageList = Me.LargeImageCollection
        Me.BOvertime.Location = New System.Drawing.Point(909, 2)
        Me.BOvertime.Name = "BOvertime"
        Me.BOvertime.Size = New System.Drawing.Size(101, 35)
        Me.BOvertime.TabIndex = 1
        Me.BOvertime.Text = "Overtime"
        '
        'BSetting
        '
        Me.BSetting.Dock = System.Windows.Forms.DockStyle.Right
        Me.BSetting.ImageIndex = 17
        Me.BSetting.ImageList = Me.LargeImageCollection
        Me.BSetting.Location = New System.Drawing.Point(1010, 2)
        Me.BSetting.Name = "BSetting"
        Me.BSetting.Size = New System.Drawing.Size(103, 35)
        Me.BSetting.TabIndex = 0
        Me.BSetting.Text = "Setting"
        '
        'FormEmpPayroll
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1121, 469)
        Me.Controls.Add(Me.XTCPayroll)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FormEmpPayroll"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Payroll Worksheet"
        CType(Me.XTCPayroll, System.ComponentModel.ISupportInitialize).EndInit()
        Me.XTCPayroll.ResumeLayout(False)
        Me.XTPPeriode.ResumeLayout(False)
        CType(Me.GCPayrollPeriode, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVPayrollPeriode, System.ComponentModel.ISupportInitialize).EndInit()
        Me.XTPSalaryFormat.ResumeLayout(False)
        CType(Me.GCPayroll, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ViewPopWorksheet.ResumeLayout(False)
        CType(Me.GVPayroll, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RICEPending, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PanelControl2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl2.ResumeLayout(False)
        CType(Me.LargeImageCollection, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PCSelAll, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PCSelAll.ResumeLayout(False)
        CType(Me.CheckEditSelAll.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PBCLineList.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents XTCPayroll As DevExpress.XtraTab.XtraTabControl
    Friend WithEvents XTPPeriode As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents XTPSalaryFormat As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents GCPayrollPeriode As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVPayrollPeriode As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents PanelControl1 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents BRemoveEmployee As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BOvertime As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BSetting As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents GCPayroll As DevExpress.XtraGrid.GridControl
    Friend WithEvents GridColumnID As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnPStart As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnPEnd As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnLastUpd As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnLastUpdBy As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnNote As DevExpress.XtraGrid.Columns.GridColumn
    Public WithEvents LargeImageCollection As DevExpress.Utils.ImageCollection
    Friend WithEvents BGetEmployee As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents ViewPopWorksheet As ContextMenuStrip
    Friend WithEvents CMDelEmp As ToolStripMenuItem
    Friend WithEvents BDeduction As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents GVPayroll As DevExpress.XtraGrid.Views.BandedGrid.BandedGridView
    Friend WithEvents GridColumnIDDet As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents GridColumnIDEmployee As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents GridColumnNIP As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents GridColumnName As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents GridColumnDepartement As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents GridColumnLevel As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents GridColumnPosition As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents GridColumnStatus As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents GridColumnContractEnd As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents GridColumnWorkingDays As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents GridColumnTotOvertime As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents GridColumnBasicSalary As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents GridColumnJobAllowance As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents GridColumnMealAllowance As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents GridColumnTransportAllowance As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents GridColumnHousingAllowance As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents GridColumnVehicleAttndAllowance As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents GridColumnTotTHP As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents GridColumnPointRegular As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents GridColumnOTReguler As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents GridColumnPointMkt As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents GridColumnOtMkt As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents GridColumnPointIA As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents GridColumnOtIA As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents GridColumnPointSales As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents GridColumnOtSales As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents GridColumnPointProd As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents GridColumnOTProd As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents GridColumnPointGeneral As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents GridColumnOtGeneral As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents GridColumnIuranKoperasi As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents GridColumnPinjamanKoperasi As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents GridColumnUniform As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents GridColumnWHSale As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents GridColumnREIKI As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents GridColumnKasBon As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents GridColumnSPT As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents GridColumnMissing As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents GridColumnPotLain2 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumnBPJS As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumnJHT As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumnJP As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumnTotJamsostek As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BBonusAdjustment As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BandedGridColumnBonus As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumnAdjustment As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumnRapel As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumnCuti As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumnActWorkdays As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumnPending As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents RICEPending As DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit
    Friend WithEvents BandedGridColumnGrandTotal As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumnTotalAdjustment As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumnTotalPaymentOt As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumnTotalDeduction As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumnCheck As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents PanelControl2 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents BPrint As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BPrintSlip As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents PCSelAll As DevExpress.XtraEditors.PanelControl
    Friend WithEvents CheckEditSelAll As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents PBCLineList As DevExpress.XtraEditors.ProgressBarControl
    Friend WithEvents BUpdateActualWorkingDays As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents gridBand8 As DevExpress.XtraGrid.Views.BandedGrid.GridBand
    Friend WithEvents GridBand1 As DevExpress.XtraGrid.Views.BandedGrid.GridBand
    Friend WithEvents gridBand5 As DevExpress.XtraGrid.Views.BandedGrid.GridBand
    Friend WithEvents gridBand2 As DevExpress.XtraGrid.Views.BandedGrid.GridBand
    Friend WithEvents gridBand6 As DevExpress.XtraGrid.Views.BandedGrid.GridBand
    Friend WithEvents gridBand3 As DevExpress.XtraGrid.Views.BandedGrid.GridBand
    Friend WithEvents gridBand4 As DevExpress.XtraGrid.Views.BandedGrid.GridBand
    Friend WithEvents gridBand9 As DevExpress.XtraGrid.Views.BandedGrid.GridBand
    Friend WithEvents gridBand7 As DevExpress.XtraGrid.Views.BandedGrid.GridBand
End Class
