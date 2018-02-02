﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
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
        Me.GVPayroll = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridView()
        Me.GridColumnIDDet = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.GridColumnIDEmployee = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.GridColumnNIP = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.GridColumnName = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.GridColumnDepartement = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.GridColumnLevel = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.GridColumnPosition = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.GridColumnStatus = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.GridColumnContractEnd = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.GridColumnWorkingDays = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.GridColumnTotOvertime = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
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
        Me.GridColumnBasicSalary = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.GridColumnJobAllowance = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.GridColumnMealAllowance = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.GridColumnTransportAllowance = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.GridColumnHousingAllowance = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.GridColumnVehicleAttndAllowance = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.GridColumnTotTHP = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.GridColumnIuranKoperasi = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.GridColumnPinjamanKoperasi = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.GridColumnUniform = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.GridColumnWHSale = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.GridColumnKasBon = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.GridColumnREIKI = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.GridColumnSPT = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.GridColumnMissing = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.GridColumnPotLain2 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.PanelControl1 = New DevExpress.XtraEditors.PanelControl()
        Me.BDeduction = New DevExpress.XtraEditors.SimpleButton()
        Me.LargeImageCollection = New DevExpress.Utils.ImageCollection(Me.components)
        Me.SimpleButton3 = New DevExpress.XtraEditors.SimpleButton()
        Me.BGetEmployee = New DevExpress.XtraEditors.SimpleButton()
        Me.BOvertime = New DevExpress.XtraEditors.SimpleButton()
        Me.SimpleButton1 = New DevExpress.XtraEditors.SimpleButton()
        Me.ViewPopWorksheet = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.CMDelEmp = New System.Windows.Forms.ToolStripMenuItem()
        Me.BandedGridColumnTotJamsostek = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumnJP = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumnJHT = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumnBPJS = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.GridBand1 = New DevExpress.XtraGrid.Views.BandedGrid.GridBand()
        Me.gridBand5 = New DevExpress.XtraGrid.Views.BandedGrid.GridBand()
        Me.gridBand3 = New DevExpress.XtraGrid.Views.BandedGrid.GridBand()
        Me.gridBand2 = New DevExpress.XtraGrid.Views.BandedGrid.GridBand()
        Me.gridBand4 = New DevExpress.XtraGrid.Views.BandedGrid.GridBand()
        CType(Me.XTCPayroll, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.XTCPayroll.SuspendLayout()
        Me.XTPPeriode.SuspendLayout()
        CType(Me.GCPayrollPeriode, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVPayrollPeriode, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.XTPSalaryFormat.SuspendLayout()
        CType(Me.GCPayroll, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVPayroll, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl1.SuspendLayout()
        CType(Me.LargeImageCollection, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ViewPopWorksheet.SuspendLayout()
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
        Me.XTPSalaryFormat.Controls.Add(Me.PanelControl1)
        Me.XTPSalaryFormat.Name = "XTPSalaryFormat"
        Me.XTPSalaryFormat.Size = New System.Drawing.Size(1115, 441)
        Me.XTPSalaryFormat.Text = "Worksheet"
        '
        'GCPayroll
        '
        Me.GCPayroll.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCPayroll.Location = New System.Drawing.Point(0, 39)
        Me.GCPayroll.MainView = Me.GVPayroll
        Me.GCPayroll.Name = "GCPayroll"
        Me.GCPayroll.Size = New System.Drawing.Size(1115, 402)
        Me.GCPayroll.TabIndex = 1
        Me.GCPayroll.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVPayroll})
        '
        'GVPayroll
        '
        Me.GVPayroll.Bands.AddRange(New DevExpress.XtraGrid.Views.BandedGrid.GridBand() {Me.GridBand1, Me.gridBand5, Me.gridBand3, Me.gridBand2, Me.gridBand4})
        Me.GVPayroll.Columns.AddRange(New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn() {Me.GridColumnIDDet, Me.GridColumnIDEmployee, Me.GridColumnNIP, Me.GridColumnName, Me.GridColumnDepartement, Me.GridColumnLevel, Me.GridColumnPosition, Me.GridColumnStatus, Me.GridColumnContractEnd, Me.GridColumnWorkingDays, Me.GridColumnTotOvertime, Me.GridColumnBasicSalary, Me.GridColumnJobAllowance, Me.GridColumnMealAllowance, Me.GridColumnTransportAllowance, Me.GridColumnHousingAllowance, Me.GridColumnVehicleAttndAllowance, Me.GridColumnTotTHP, Me.GridColumnPointRegular, Me.GridColumnOTReguler, Me.GridColumnPointMkt, Me.GridColumnOtMkt, Me.GridColumnPointIA, Me.GridColumnOtIA, Me.GridColumnPointSales, Me.GridColumnOtSales, Me.GridColumnPointProd, Me.GridColumnOTProd, Me.GridColumnPointGeneral, Me.GridColumnOtGeneral, Me.BandedGridColumnBPJS, Me.BandedGridColumnJHT, Me.BandedGridColumnJP, Me.BandedGridColumnTotJamsostek, Me.GridColumnIuranKoperasi, Me.GridColumnPinjamanKoperasi, Me.GridColumnUniform, Me.GridColumnWHSale, Me.GridColumnREIKI, Me.GridColumnKasBon, Me.GridColumnSPT, Me.GridColumnMissing, Me.GridColumnPotLain2})
        Me.GVPayroll.GridControl = Me.GCPayroll
        Me.GVPayroll.GroupSummary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "total_ot", Me.GridColumnTotOvertime, "{0:N1}"), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "tot_thp", Me.GridColumnTotTHP, "{0:N0}"), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "reg_total_point", Me.GridColumnPointRegular, "{0:N2}"), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "reg_total_wages", Me.GridColumnOTReguler, "{0:N2}"), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "mkt_total_point", Me.GridColumnPointMkt, "{0:N2}"), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "mkt_total_wages", Me.GridColumnOtMkt, "{0:N2}"), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "ia_total_point", Me.GridColumnPointIA, "{0:N2}"), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "ia_total_wages", Me.GridColumnOtIA, "{0:N2}"), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "prod_total_point", Me.GridColumnPointProd, "{0:N2}"), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "prod_total_wages", Me.GridColumnOTProd, "{0:N2}"), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "sales_total_point", Me.GridColumnPointSales, "{0:N2}"), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "sales_total_wages", Me.GridColumnOtSales, "{0:N2}"), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "general_total_point", Me.GridColumnPointGeneral, "{0:N2}"), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "general_total_wages", Me.GridColumnOtGeneral, "{0:N2}"), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "d_iuran_koperasi", Me.GridColumnIuranKoperasi, "{0:N0}"), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "d_uniform", Me.GridColumnUniform, "{0:N0}"), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "d_wh_sale", Me.GridColumnWHSale, "{0:N0}"), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "d_reiki", Me.GridColumnREIKI, "{0:N0}"), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "d_kasbon", Me.GridColumnKasBon, "{0:N0}"), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "d_spt", Me.GridColumnSPT, "{0:N0}"), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "d_tab_missing", Me.GridColumnMissing, "{0:N0}"), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "d_pot_lain", Me.GridColumnPotLain2, "{0:N0}"), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "d_bpjs", Me.BandedGridColumnBPJS, "{0:N0}"), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "d_jht", Me.BandedGridColumnJHT, "{0:N0}"), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "d_jp", Me.BandedGridColumnJP, "{0:N0}"), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "d_jamsostek", Me.BandedGridColumnTotJamsostek, "{0:N0}")})
        Me.GVPayroll.Name = "GVPayroll"
        Me.GVPayroll.OptionsView.ColumnAutoWidth = False
        Me.GVPayroll.OptionsView.GroupFooterShowMode = DevExpress.XtraGrid.Views.Grid.GroupFooterShowMode.VisibleAlways
        Me.GVPayroll.OptionsView.ShowFooter = True
        Me.GVPayroll.OptionsView.ShowGroupPanel = False
        '
        'GridColumnIDDet
        '
        Me.GridColumnIDDet.Caption = "ID"
        Me.GridColumnIDDet.FieldName = "id_payroll_det"
        Me.GridColumnIDDet.Name = "GridColumnIDDet"
        '
        'GridColumnIDEmployee
        '
        Me.GridColumnIDEmployee.Caption = "ID Employee"
        Me.GridColumnIDEmployee.FieldName = "id_employee"
        Me.GridColumnIDEmployee.Name = "GridColumnIDEmployee"
        '
        'GridColumnNIP
        '
        Me.GridColumnNIP.Caption = "NIP"
        Me.GridColumnNIP.FieldName = "employee_code"
        Me.GridColumnNIP.Name = "GridColumnNIP"
        Me.GridColumnNIP.Visible = True
        '
        'GridColumnName
        '
        Me.GridColumnName.Caption = "Name"
        Me.GridColumnName.FieldName = "employee_name"
        Me.GridColumnName.Name = "GridColumnName"
        Me.GridColumnName.Visible = True
        '
        'GridColumnDepartement
        '
        Me.GridColumnDepartement.Caption = "Departement"
        Me.GridColumnDepartement.FieldName = "departement"
        Me.GridColumnDepartement.Name = "GridColumnDepartement"
        Me.GridColumnDepartement.Visible = True
        '
        'GridColumnLevel
        '
        Me.GridColumnLevel.Caption = "Level"
        Me.GridColumnLevel.FieldName = "employee_level"
        Me.GridColumnLevel.Name = "GridColumnLevel"
        Me.GridColumnLevel.Visible = True
        '
        'GridColumnPosition
        '
        Me.GridColumnPosition.Caption = "Position"
        Me.GridColumnPosition.FieldName = "employee_position"
        Me.GridColumnPosition.Name = "GridColumnPosition"
        Me.GridColumnPosition.Visible = True
        '
        'GridColumnStatus
        '
        Me.GridColumnStatus.Caption = "Status"
        Me.GridColumnStatus.FieldName = "employee_status"
        Me.GridColumnStatus.Name = "GridColumnStatus"
        Me.GridColumnStatus.Visible = True
        '
        'GridColumnContractEnd
        '
        Me.GridColumnContractEnd.Caption = "Contract End"
        Me.GridColumnContractEnd.DisplayFormat.FormatString = "dd MMMM yyyy"
        Me.GridColumnContractEnd.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.GridColumnContractEnd.FieldName = "end_period"
        Me.GridColumnContractEnd.Name = "GridColumnContractEnd"
        Me.GridColumnContractEnd.Visible = True
        '
        'GridColumnWorkingDays
        '
        Me.GridColumnWorkingDays.Caption = "Working Days"
        Me.GridColumnWorkingDays.FieldName = "working_days"
        Me.GridColumnWorkingDays.Name = "GridColumnWorkingDays"
        Me.GridColumnWorkingDays.Visible = True
        '
        'GridColumnTotOvertime
        '
        Me.GridColumnTotOvertime.Caption = "Overtime (hours)"
        Me.GridColumnTotOvertime.DisplayFormat.FormatString = "N1"
        Me.GridColumnTotOvertime.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumnTotOvertime.FieldName = "total_ot"
        Me.GridColumnTotOvertime.Name = "GridColumnTotOvertime"
        Me.GridColumnTotOvertime.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "total_ot", "{0:N1}")})
        Me.GridColumnTotOvertime.Visible = True
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
        Me.GridColumnOtGeneral.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "general_total_wages", "{0:N2}")})
        Me.GridColumnOtGeneral.Visible = True
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
        Me.GridColumnTotTHP.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "tot_thp", "{0:N0}")})
        Me.GridColumnTotTHP.Visible = True
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
        Me.GridColumnPotLain2.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "d_pot_lain", "{0:N0}")})
        Me.GridColumnPotLain2.Visible = True
        '
        'PanelControl1
        '
        Me.PanelControl1.Controls.Add(Me.BDeduction)
        Me.PanelControl1.Controls.Add(Me.SimpleButton3)
        Me.PanelControl1.Controls.Add(Me.BGetEmployee)
        Me.PanelControl1.Controls.Add(Me.BOvertime)
        Me.PanelControl1.Controls.Add(Me.SimpleButton1)
        Me.PanelControl1.Dock = System.Windows.Forms.DockStyle.Top
        Me.PanelControl1.Location = New System.Drawing.Point(0, 0)
        Me.PanelControl1.Name = "PanelControl1"
        Me.PanelControl1.Size = New System.Drawing.Size(1115, 39)
        Me.PanelControl1.TabIndex = 0
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
        'SimpleButton3
        '
        Me.SimpleButton3.Dock = System.Windows.Forms.DockStyle.Left
        Me.SimpleButton3.ImageIndex = 6
        Me.SimpleButton3.ImageList = Me.LargeImageCollection
        Me.SimpleButton3.Location = New System.Drawing.Point(130, 2)
        Me.SimpleButton3.Name = "SimpleButton3"
        Me.SimpleButton3.Size = New System.Drawing.Size(86, 35)
        Me.SimpleButton3.TabIndex = 2
        Me.SimpleButton3.Text = "Print"
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
        'SimpleButton1
        '
        Me.SimpleButton1.Dock = System.Windows.Forms.DockStyle.Right
        Me.SimpleButton1.ImageIndex = 17
        Me.SimpleButton1.ImageList = Me.LargeImageCollection
        Me.SimpleButton1.Location = New System.Drawing.Point(1010, 2)
        Me.SimpleButton1.Name = "SimpleButton1"
        Me.SimpleButton1.Size = New System.Drawing.Size(103, 35)
        Me.SimpleButton1.TabIndex = 0
        Me.SimpleButton1.Text = "Setting"
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
        Me.BandedGridColumnTotJamsostek.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "d_jamsostek", "{0:N0}")})
        Me.BandedGridColumnTotJamsostek.Visible = True
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
        Me.BandedGridColumnJP.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "d_jp", "{0:N0}")})
        Me.BandedGridColumnJP.Visible = True
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
        Me.BandedGridColumnJHT.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "d_jht", "{0:N0}")})
        Me.BandedGridColumnJHT.Visible = True
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
        Me.BandedGridColumnBPJS.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "d_bpjs", "{0:N0}")})
        Me.BandedGridColumnBPJS.Visible = True
        '
        'GridBand1
        '
        Me.GridBand1.AppearanceHeader.Options.UseTextOptions = True
        Me.GridBand1.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridBand1.Caption = "Employee Detail"
        Me.GridBand1.Columns.Add(Me.GridColumnIDDet)
        Me.GridBand1.Columns.Add(Me.GridColumnIDEmployee)
        Me.GridBand1.Columns.Add(Me.GridColumnNIP)
        Me.GridBand1.Columns.Add(Me.GridColumnName)
        Me.GridBand1.Columns.Add(Me.GridColumnDepartement)
        Me.GridBand1.Columns.Add(Me.GridColumnLevel)
        Me.GridBand1.Columns.Add(Me.GridColumnPosition)
        Me.GridBand1.Columns.Add(Me.GridColumnStatus)
        Me.GridBand1.Columns.Add(Me.GridColumnContractEnd)
        Me.GridBand1.Name = "GridBand1"
        Me.GridBand1.VisibleIndex = 0
        Me.GridBand1.Width = 525
        '
        'gridBand5
        '
        Me.gridBand5.AppearanceHeader.Options.UseTextOptions = True
        Me.gridBand5.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.gridBand5.Caption = "Working Time Detail"
        Me.gridBand5.Columns.Add(Me.GridColumnWorkingDays)
        Me.gridBand5.Columns.Add(Me.GridColumnTotOvertime)
        Me.gridBand5.Name = "gridBand5"
        Me.gridBand5.VisibleIndex = 1
        Me.gridBand5.Width = 150
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
        Me.gridBand3.Name = "gridBand3"
        Me.gridBand3.VisibleIndex = 2
        Me.gridBand3.Width = 900
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
        Me.gridBand4.Name = "gridBand4"
        Me.gridBand4.VisibleIndex = 4
        Me.gridBand4.Width = 975
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
        CType(Me.GVPayroll, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl1.ResumeLayout(False)
        CType(Me.LargeImageCollection, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ViewPopWorksheet.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents XTCPayroll As DevExpress.XtraTab.XtraTabControl
    Friend WithEvents XTPPeriode As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents XTPSalaryFormat As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents GCPayrollPeriode As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVPayrollPeriode As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents PanelControl1 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents SimpleButton3 As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BOvertime As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents SimpleButton1 As DevExpress.XtraEditors.SimpleButton
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
    Friend WithEvents GridBand1 As DevExpress.XtraGrid.Views.BandedGrid.GridBand
    Friend WithEvents gridBand5 As DevExpress.XtraGrid.Views.BandedGrid.GridBand
    Friend WithEvents gridBand3 As DevExpress.XtraGrid.Views.BandedGrid.GridBand
    Friend WithEvents gridBand2 As DevExpress.XtraGrid.Views.BandedGrid.GridBand
    Friend WithEvents gridBand4 As DevExpress.XtraGrid.Views.BandedGrid.GridBand
    Friend WithEvents BandedGridColumnBPJS As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumnJHT As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumnJP As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumnTotJamsostek As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
End Class
