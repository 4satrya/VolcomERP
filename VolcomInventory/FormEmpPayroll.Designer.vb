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
        Me.GCExportExcel = New DevExpress.XtraGrid.GridControl()
        Me.GVExportExcel = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumn2 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn3 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn4 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn5 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.BarManager1 = New DevExpress.XtraBars.BarManager(Me.components)
        Me.barDockControlTop = New DevExpress.XtraBars.BarDockControl()
        Me.barDockControlBottom = New DevExpress.XtraBars.BarDockControl()
        Me.barDockControlLeft = New DevExpress.XtraBars.BarDockControl()
        Me.barDockControlRight = New DevExpress.XtraBars.BarDockControl()
        Me.BBPD = New DevExpress.XtraBars.BarButtonItem()
        Me.BBProposePrice = New DevExpress.XtraBars.BarButtonItem()
        Me.BBMasterSeason = New DevExpress.XtraBars.BarButtonItem()
        Me.BBDs = New DevExpress.XtraBars.BarButtonItem()
        Me.BBPrepEstPrice = New DevExpress.XtraBars.BarButtonItem()
        Me.BtnImportEstPrice = New DevExpress.XtraBars.BarButtonItem()
        Me.BBSubEstPrice = New DevExpress.XtraBars.BarSubItem()
        Me.BBSubOther = New DevExpress.XtraBars.BarSubItem()
        Me.BarButtonItem1 = New DevExpress.XtraBars.BarButtonItem()
        Me.BarButtonItem2 = New DevExpress.XtraBars.BarButtonItem()
        Me.BarButtonItem3 = New DevExpress.XtraBars.BarButtonItem()
        Me.BBBcaFormat = New DevExpress.XtraBars.BarButtonItem()
        Me.BBIBPJSKesehatan = New DevExpress.XtraBars.BarButtonItem()
        Me.BBIBPJSTK = New DevExpress.XtraBars.BarButtonItem()
        Me.BBIPajak = New DevExpress.XtraBars.BarButtonItem()
        Me.GCPayrollPeriode = New DevExpress.XtraGrid.GridControl()
        Me.GVPayrollPeriode = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumnID = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnCheck = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RepositoryItemCheckEdit = New DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit()
        Me.GridColumnPStart = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnPEnd = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnIDPayrollType = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn1 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnLastUpd = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnLastUpdBy = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnNote = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GCStatus = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.PanelControl4 = New DevExpress.XtraEditors.PanelControl()
        Me.SBExportExcel = New DevExpress.XtraEditors.SimpleButton()
        Me.LargeImageCollection = New DevExpress.Utils.ImageCollection(Me.components)
        Me.XTPSalaryFormat = New DevExpress.XtraTab.XtraTabPage()
        Me.GCPayroll = New DevExpress.XtraGrid.GridControl()
        Me.ViewPopWorksheet = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.CMDelEmp = New System.Windows.Forms.ToolStripMenuItem()
        Me.GVPayroll = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridView()
        Me.gridBand8 = New DevExpress.XtraGrid.Views.BandedGrid.GridBand()
        Me.GridColumnGroupReport = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.GridColumnDepartement = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumnCheck = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.RICECheck = New DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit()
        Me.BandedGridColumnSent = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.RICESent = New DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit()
        Me.GridColumnNIP = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.GridColumnName = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.GridColumnPosition = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.GridColumnStatus = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.GBWorkingDays = New DevExpress.XtraGrid.Views.BandedGrid.GridBand()
        Me.GridColumnWorkingDays = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumnActWorkdays = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.RITEActWorkdays = New DevExpress.XtraEditors.Repository.RepositoryItemTextEdit()
        Me.BandedGridColumnOvertimeHours = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.GBSalary = New DevExpress.XtraGrid.Views.BandedGrid.GridBand()
        Me.GridColumnBasicSalary = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.GridColumnJobAllowance = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.GridColumnMealAllowance = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.GridColumnTransportAllowance = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumnTotFixedSalary = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.GridColumnHousingAllowance = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.GridColumnVehicleAttndAllowance = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.GridColumnTotTHP = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.GBTHR = New DevExpress.XtraGrid.Views.BandedGrid.GridBand()
        Me.BandedGridColumnActualJoinDateTHR = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumnLengthTHR = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumnTotalSalaryTHR = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.RITETotalSalaryTHR = New DevExpress.XtraEditors.Repository.RepositoryItemTextEdit()
        Me.GBDW = New DevExpress.XtraGrid.Views.BandedGrid.GridBand()
        Me.BandedGridColumnActWorkdaysDW = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.RITEActWorkdaysDW = New DevExpress.XtraEditors.Repository.RepositoryItemTextEdit()
        Me.GridColumnBasicSalaryDW = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.GridColumnTotalSalaryDW = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.GBBonusAdjustment = New DevExpress.XtraGrid.Views.BandedGrid.GridBand()
        Me.BandedGridColumnTotalAdjustment = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.GBOvertime = New DevExpress.XtraGrid.Views.BandedGrid.GridBand()
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
        Me.GBDeduction = New DevExpress.XtraGrid.Views.BandedGrid.GridBand()
        Me.BandedGridColumnTotalDeduction = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.GBTotal = New DevExpress.XtraGrid.Views.BandedGrid.GridBand()
        Me.BandedGridColumnGrandTotal = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.GBExtraNote = New DevExpress.XtraGrid.Views.BandedGrid.GridBand()
        Me.BandedGridColumnPending = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.RICEPending = New DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit()
        Me.BandedGridColumnCash = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.GridColumnIDPayroll = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.GridColumnIDEmployee = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.GCIsOfficePayroll = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumn1 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.GridColumnDepartementSub = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.PanelControl2 = New DevExpress.XtraEditors.PanelControl()
        Me.PanelControl3 = New DevExpress.XtraEditors.PanelControl()
        Me.CheckEditViewSend = New DevExpress.XtraEditors.CheckEdit()
        Me.BtnAttachment = New DevExpress.XtraEditors.SimpleButton()
        Me.BReport = New DevExpress.XtraEditors.DropDownButton()
        Me.PopupMenu1 = New DevExpress.XtraBars.PopupMenu(Me.components)
        Me.SBSendSlip = New DevExpress.XtraEditors.SimpleButton()
        Me.BPrintSlip = New DevExpress.XtraEditors.SimpleButton()
        Me.PCSelAll = New DevExpress.XtraEditors.PanelControl()
        Me.CheckEditSelAll = New DevExpress.XtraEditors.CheckEdit()
        Me.BMark = New DevExpress.XtraEditors.SimpleButton()
        Me.PBCLineList = New DevExpress.XtraEditors.ProgressBarControl()
        Me.BPrint = New DevExpress.XtraEditors.SimpleButton()
        Me.BReset = New DevExpress.XtraEditors.SimpleButton()
        Me.BSubmit = New DevExpress.XtraEditors.SimpleButton()
        Me.PanelControl1 = New DevExpress.XtraEditors.PanelControl()
        Me.BUpdateActualWorkingDays = New DevExpress.XtraEditors.SimpleButton()
        Me.BBonusAdjustment = New DevExpress.XtraEditors.SimpleButton()
        Me.BDeduction = New DevExpress.XtraEditors.SimpleButton()
        Me.BRemoveEmployee = New DevExpress.XtraEditors.SimpleButton()
        Me.BGetEmployee = New DevExpress.XtraEditors.SimpleButton()
        Me.BOvertime = New DevExpress.XtraEditors.SimpleButton()
        Me.BSetting = New DevExpress.XtraEditors.SimpleButton()
        Me.GridColumn6 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn7 = New DevExpress.XtraGrid.Columns.GridColumn()
        CType(Me.XTCPayroll, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.XTCPayroll.SuspendLayout()
        Me.XTPPeriode.SuspendLayout()
        CType(Me.GCExportExcel, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVExportExcel, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BarManager1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GCPayrollPeriode, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVPayrollPeriode, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemCheckEdit, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PanelControl4, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl4.SuspendLayout()
        CType(Me.LargeImageCollection, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.XTPSalaryFormat.SuspendLayout()
        CType(Me.GCPayroll, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ViewPopWorksheet.SuspendLayout()
        CType(Me.GVPayroll, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RICECheck, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RICESent, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RITEActWorkdays, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RITETotalSalaryTHR, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RITEActWorkdaysDW, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RICEPending, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PanelControl2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl2.SuspendLayout()
        CType(Me.PanelControl3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl3.SuspendLayout()
        CType(Me.CheckEditViewSend.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PopupMenu1, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.XTCPayroll.Size = New System.Drawing.Size(1344, 729)
        Me.XTCPayroll.TabIndex = 0
        Me.XTCPayroll.TabPages.AddRange(New DevExpress.XtraTab.XtraTabPage() {Me.XTPPeriode, Me.XTPSalaryFormat})
        '
        'XTPPeriode
        '
        Me.XTPPeriode.Controls.Add(Me.GCExportExcel)
        Me.XTPPeriode.Controls.Add(Me.GCPayrollPeriode)
        Me.XTPPeriode.Controls.Add(Me.PanelControl4)
        Me.XTPPeriode.Name = "XTPPeriode"
        Me.XTPPeriode.Size = New System.Drawing.Size(1338, 701)
        Me.XTPPeriode.Text = "Period"
        '
        'GCExportExcel
        '
        Me.GCExportExcel.Location = New System.Drawing.Point(88, 401)
        Me.GCExportExcel.MainView = Me.GVExportExcel
        Me.GCExportExcel.MenuManager = Me.BarManager1
        Me.GCExportExcel.Name = "GCExportExcel"
        Me.GCExportExcel.Size = New System.Drawing.Size(400, 200)
        Me.GCExportExcel.TabIndex = 2
        Me.GCExportExcel.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVExportExcel})
        Me.GCExportExcel.Visible = False
        '
        'GVExportExcel
        '
        Me.GVExportExcel.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumn2, Me.GridColumn3, Me.GridColumn4, Me.GridColumn5})
        Me.GVExportExcel.GridControl = Me.GCExportExcel
        Me.GVExportExcel.Name = "GVExportExcel"
        Me.GVExportExcel.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never
        Me.GVExportExcel.OptionsView.ShowGroupPanel = False
        '
        'GridColumn2
        '
        Me.GridColumn2.Caption = "NIP"
        Me.GridColumn2.FieldName = "employee_code"
        Me.GridColumn2.Name = "GridColumn2"
        Me.GridColumn2.Visible = True
        Me.GridColumn2.VisibleIndex = 0
        '
        'GridColumn3
        '
        Me.GridColumn3.Caption = "Employee"
        Me.GridColumn3.FieldName = "employee_name"
        Me.GridColumn3.Name = "GridColumn3"
        Me.GridColumn3.Visible = True
        Me.GridColumn3.VisibleIndex = 1
        '
        'GridColumn4
        '
        Me.GridColumn4.Caption = "Departement"
        Me.GridColumn4.FieldName = "departement"
        Me.GridColumn4.Name = "GridColumn4"
        Me.GridColumn4.Visible = True
        Me.GridColumn4.VisibleIndex = 2
        '
        'GridColumn5
        '
        Me.GridColumn5.Caption = "Grand Total"
        Me.GridColumn5.FieldName = "grand_total"
        Me.GridColumn5.Name = "GridColumn5"
        Me.GridColumn5.Visible = True
        Me.GridColumn5.VisibleIndex = 3
        '
        'BarManager1
        '
        Me.BarManager1.DockControls.Add(Me.barDockControlTop)
        Me.BarManager1.DockControls.Add(Me.barDockControlBottom)
        Me.BarManager1.DockControls.Add(Me.barDockControlLeft)
        Me.BarManager1.DockControls.Add(Me.barDockControlRight)
        Me.BarManager1.Form = Me
        Me.BarManager1.Items.AddRange(New DevExpress.XtraBars.BarItem() {Me.BBPD, Me.BBProposePrice, Me.BBMasterSeason, Me.BBDs, Me.BBPrepEstPrice, Me.BtnImportEstPrice, Me.BBSubEstPrice, Me.BBSubOther, Me.BarButtonItem1, Me.BarButtonItem2, Me.BarButtonItem3, Me.BBBcaFormat, Me.BBIBPJSKesehatan, Me.BBIBPJSTK, Me.BBIPajak})
        Me.BarManager1.MaxItemId = 19
        '
        'barDockControlTop
        '
        Me.barDockControlTop.CausesValidation = False
        Me.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top
        Me.barDockControlTop.Location = New System.Drawing.Point(0, 0)
        Me.barDockControlTop.Size = New System.Drawing.Size(1344, 0)
        '
        'barDockControlBottom
        '
        Me.barDockControlBottom.CausesValidation = False
        Me.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.barDockControlBottom.Location = New System.Drawing.Point(0, 729)
        Me.barDockControlBottom.Size = New System.Drawing.Size(1344, 0)
        '
        'barDockControlLeft
        '
        Me.barDockControlLeft.CausesValidation = False
        Me.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left
        Me.barDockControlLeft.Location = New System.Drawing.Point(0, 0)
        Me.barDockControlLeft.Size = New System.Drawing.Size(0, 729)
        '
        'barDockControlRight
        '
        Me.barDockControlRight.CausesValidation = False
        Me.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right
        Me.barDockControlRight.Location = New System.Drawing.Point(1344, 0)
        Me.barDockControlRight.Size = New System.Drawing.Size(0, 729)
        '
        'BBPD
        '
        Me.BBPD.Caption = "Production Demand"
        Me.BBPD.Id = 3
        Me.BBPD.Name = "BBPD"
        '
        'BBProposePrice
        '
        Me.BBProposePrice.Caption = "Propose Price"
        Me.BBProposePrice.Id = 4
        Me.BBProposePrice.Name = "BBProposePrice"
        '
        'BBMasterSeason
        '
        Me.BBMasterSeason.Caption = "Master Season"
        Me.BBMasterSeason.Id = 5
        Me.BBMasterSeason.Name = "BBMasterSeason"
        '
        'BBDs
        '
        Me.BBDs.Caption = "Distribution Scheme"
        Me.BBDs.Id = 6
        Me.BBDs.Name = "BBDs"
        '
        'BBPrepEstPrice
        '
        Me.BBPrepEstPrice.Caption = "Prepare Est Price"
        Me.BBPrepEstPrice.Id = 7
        Me.BBPrepEstPrice.Name = "BBPrepEstPrice"
        '
        'BtnImportEstPrice
        '
        Me.BtnImportEstPrice.Caption = "Import Est Price"
        Me.BtnImportEstPrice.Id = 8
        Me.BtnImportEstPrice.Name = "BtnImportEstPrice"
        '
        'BBSubEstPrice
        '
        Me.BBSubEstPrice.Border = DevExpress.XtraEditors.Controls.BorderStyles.[Default]
        Me.BBSubEstPrice.Caption = "Estimate Price"
        Me.BBSubEstPrice.Id = 9
        Me.BBSubEstPrice.LinksPersistInfo.AddRange(New DevExpress.XtraBars.LinkPersistInfo() {New DevExpress.XtraBars.LinkPersistInfo(Me.BBPrepEstPrice), New DevExpress.XtraBars.LinkPersistInfo(Me.BtnImportEstPrice)})
        Me.BBSubEstPrice.Name = "BBSubEstPrice"
        '
        'BBSubOther
        '
        Me.BBSubOther.Caption = "Other Menu"
        Me.BBSubOther.Id = 10
        Me.BBSubOther.LinksPersistInfo.AddRange(New DevExpress.XtraBars.LinkPersistInfo() {New DevExpress.XtraBars.LinkPersistInfo(Me.BBMasterSeason), New DevExpress.XtraBars.LinkPersistInfo(Me.BBDs), New DevExpress.XtraBars.LinkPersistInfo(Me.BBPD), New DevExpress.XtraBars.LinkPersistInfo(Me.BBProposePrice)})
        Me.BBSubOther.Name = "BBSubOther"
        '
        'BarButtonItem1
        '
        Me.BarButtonItem1.Caption = "Report All Departements"
        Me.BarButtonItem1.Id = 11
        Me.BarButtonItem1.Name = "BarButtonItem1"
        '
        'BarButtonItem2
        '
        Me.BarButtonItem2.Caption = "Rekap OT Event"
        Me.BarButtonItem2.Id = 12
        Me.BarButtonItem2.Name = "BarButtonItem2"
        '
        'BarButtonItem3
        '
        Me.BarButtonItem3.Caption = "Rekap Per Departement"
        Me.BarButtonItem3.Id = 13
        Me.BarButtonItem3.Name = "BarButtonItem3"
        '
        'BBBcaFormat
        '
        Me.BBBcaFormat.Caption = "Export to BCA Format"
        Me.BBBcaFormat.Id = 14
        Me.BBBcaFormat.Name = "BBBcaFormat"
        '
        'BBIBPJSKesehatan
        '
        Me.BBIBPJSKesehatan.Caption = "Report BPJS Kesehatan"
        Me.BBIBPJSKesehatan.Id = 15
        Me.BBIBPJSKesehatan.Name = "BBIBPJSKesehatan"
        '
        'BBIBPJSTK
        '
        Me.BBIBPJSTK.Caption = "Report BPJSTK"
        Me.BBIBPJSTK.Id = 16
        Me.BBIBPJSTK.Name = "BBIBPJSTK"
        '
        'BBIPajak
        '
        Me.BBIPajak.Caption = "Report Pajak"
        Me.BBIPajak.Id = 18
        Me.BBIPajak.Name = "BBIPajak"
        '
        'GCPayrollPeriode
        '
        Me.GCPayrollPeriode.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCPayrollPeriode.Location = New System.Drawing.Point(0, 0)
        Me.GCPayrollPeriode.MainView = Me.GVPayrollPeriode
        Me.GCPayrollPeriode.Name = "GCPayrollPeriode"
        Me.GCPayrollPeriode.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.RepositoryItemCheckEdit})
        Me.GCPayrollPeriode.Size = New System.Drawing.Size(1338, 662)
        Me.GCPayrollPeriode.TabIndex = 0
        Me.GCPayrollPeriode.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVPayrollPeriode})
        '
        'GVPayrollPeriode
        '
        Me.GVPayrollPeriode.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumnID, Me.GridColumnCheck, Me.GridColumnPStart, Me.GridColumnPEnd, Me.GridColumnIDPayrollType, Me.GridColumn1, Me.GridColumnLastUpd, Me.GridColumnLastUpdBy, Me.GridColumnNote, Me.GCStatus, Me.GridColumn6, Me.GridColumn7})
        Me.GVPayrollPeriode.GridControl = Me.GCPayrollPeriode
        Me.GVPayrollPeriode.Name = "GVPayrollPeriode"
        Me.GVPayrollPeriode.NewItemRowText = "edita"
        Me.GVPayrollPeriode.OptionsView.ColumnAutoWidth = False
        Me.GVPayrollPeriode.OptionsView.ShowGroupPanel = False
        '
        'GridColumnID
        '
        Me.GridColumnID.Caption = "ID"
        Me.GridColumnID.FieldName = "id_payroll"
        Me.GridColumnID.Name = "GridColumnID"
        Me.GridColumnID.OptionsColumn.AllowEdit = False
        '
        'GridColumnCheck
        '
        Me.GridColumnCheck.Caption = " "
        Me.GridColumnCheck.ColumnEdit = Me.RepositoryItemCheckEdit
        Me.GridColumnCheck.FieldName = "is_check"
        Me.GridColumnCheck.Name = "GridColumnCheck"
        '
        'RepositoryItemCheckEdit
        '
        Me.RepositoryItemCheckEdit.AutoHeight = False
        Me.RepositoryItemCheckEdit.Name = "RepositoryItemCheckEdit"
        Me.RepositoryItemCheckEdit.ValueChecked = "yes"
        Me.RepositoryItemCheckEdit.ValueUnchecked = "no"
        '
        'GridColumnPStart
        '
        Me.GridColumnPStart.Caption = "Period Start"
        Me.GridColumnPStart.DisplayFormat.FormatString = "dd MMMM yyyy"
        Me.GridColumnPStart.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.GridColumnPStart.FieldName = "periode_start"
        Me.GridColumnPStart.Name = "GridColumnPStart"
        Me.GridColumnPStart.OptionsColumn.AllowEdit = False
        Me.GridColumnPStart.Visible = True
        Me.GridColumnPStart.VisibleIndex = 0
        Me.GridColumnPStart.Width = 222
        '
        'GridColumnPEnd
        '
        Me.GridColumnPEnd.Caption = "Period End"
        Me.GridColumnPEnd.DisplayFormat.FormatString = "dd MMMM yyyy"
        Me.GridColumnPEnd.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.GridColumnPEnd.FieldName = "periode_end"
        Me.GridColumnPEnd.Name = "GridColumnPEnd"
        Me.GridColumnPEnd.OptionsColumn.AllowEdit = False
        Me.GridColumnPEnd.Visible = True
        Me.GridColumnPEnd.VisibleIndex = 1
        Me.GridColumnPEnd.Width = 189
        '
        'GridColumnIDPayrollType
        '
        Me.GridColumnIDPayrollType.Caption = "ID Payroll Type"
        Me.GridColumnIDPayrollType.FieldName = "id_payroll_type"
        Me.GridColumnIDPayrollType.Name = "GridColumnIDPayrollType"
        Me.GridColumnIDPayrollType.OptionsColumn.AllowEdit = False
        '
        'GridColumn1
        '
        Me.GridColumn1.Caption = "Payroll Type"
        Me.GridColumn1.FieldName = "payroll_type_name"
        Me.GridColumn1.Name = "GridColumn1"
        Me.GridColumn1.OptionsColumn.AllowEdit = False
        Me.GridColumn1.Visible = True
        Me.GridColumn1.VisibleIndex = 2
        Me.GridColumn1.Width = 186
        '
        'GridColumnLastUpd
        '
        Me.GridColumnLastUpd.Caption = "Last Update"
        Me.GridColumnLastUpd.DisplayFormat.FormatString = "dd MMMM yyyy"
        Me.GridColumnLastUpd.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.GridColumnLastUpd.FieldName = "employee_name"
        Me.GridColumnLastUpd.Name = "GridColumnLastUpd"
        Me.GridColumnLastUpd.OptionsColumn.AllowEdit = False
        Me.GridColumnLastUpd.Visible = True
        Me.GridColumnLastUpd.VisibleIndex = 3
        Me.GridColumnLastUpd.Width = 256
        '
        'GridColumnLastUpdBy
        '
        Me.GridColumnLastUpdBy.Caption = "Last Update By"
        Me.GridColumnLastUpdBy.FieldName = "employee_name"
        Me.GridColumnLastUpdBy.Name = "GridColumnLastUpdBy"
        Me.GridColumnLastUpdBy.OptionsColumn.AllowEdit = False
        Me.GridColumnLastUpdBy.Visible = True
        Me.GridColumnLastUpdBy.VisibleIndex = 4
        Me.GridColumnLastUpdBy.Width = 208
        '
        'GridColumnNote
        '
        Me.GridColumnNote.Caption = "Note"
        Me.GridColumnNote.FieldName = "note"
        Me.GridColumnNote.Name = "GridColumnNote"
        Me.GridColumnNote.OptionsColumn.AllowEdit = False
        Me.GridColumnNote.Visible = True
        Me.GridColumnNote.VisibleIndex = 5
        Me.GridColumnNote.Width = 571
        '
        'GCStatus
        '
        Me.GCStatus.Caption = "Status"
        Me.GCStatus.FieldName = "report_status"
        Me.GCStatus.Name = "GCStatus"
        Me.GCStatus.OptionsColumn.AllowEdit = False
        Me.GCStatus.Visible = True
        Me.GCStatus.VisibleIndex = 6
        '
        'PanelControl4
        '
        Me.PanelControl4.Controls.Add(Me.SBExportExcel)
        Me.PanelControl4.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PanelControl4.Location = New System.Drawing.Point(0, 662)
        Me.PanelControl4.Name = "PanelControl4"
        Me.PanelControl4.Size = New System.Drawing.Size(1338, 39)
        Me.PanelControl4.TabIndex = 1
        '
        'SBExportExcel
        '
        Me.SBExportExcel.Dock = System.Windows.Forms.DockStyle.Right
        Me.SBExportExcel.ImageIndex = 10
        Me.SBExportExcel.ImageList = Me.LargeImageCollection
        Me.SBExportExcel.Location = New System.Drawing.Point(1216, 2)
        Me.SBExportExcel.Name = "SBExportExcel"
        Me.SBExportExcel.Size = New System.Drawing.Size(120, 35)
        Me.SBExportExcel.TabIndex = 2
        Me.SBExportExcel.Text = "Export Excel"
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
        'XTPSalaryFormat
        '
        Me.XTPSalaryFormat.Controls.Add(Me.GCPayroll)
        Me.XTPSalaryFormat.Controls.Add(Me.PanelControl2)
        Me.XTPSalaryFormat.Controls.Add(Me.PanelControl1)
        Me.XTPSalaryFormat.Name = "XTPSalaryFormat"
        Me.XTPSalaryFormat.Size = New System.Drawing.Size(1338, 701)
        Me.XTPSalaryFormat.Text = "Worksheet"
        '
        'GCPayroll
        '
        Me.GCPayroll.ContextMenuStrip = Me.ViewPopWorksheet
        Me.GCPayroll.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCPayroll.Location = New System.Drawing.Point(0, 39)
        Me.GCPayroll.MainView = Me.GVPayroll
        Me.GCPayroll.Name = "GCPayroll"
        Me.GCPayroll.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.RICEPending, Me.RITEActWorkdaysDW, Me.RICECheck, Me.RITEActWorkdays, Me.RICESent, Me.RITETotalSalaryTHR})
        Me.GCPayroll.Size = New System.Drawing.Size(1338, 623)
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
        Me.GVPayroll.Bands.AddRange(New DevExpress.XtraGrid.Views.BandedGrid.GridBand() {Me.gridBand8, Me.GBWorkingDays, Me.GBSalary, Me.GBTHR, Me.GBDW, Me.GBBonusAdjustment, Me.GBOvertime, Me.GBDeduction, Me.GBTotal, Me.GBExtraNote})
        Me.GVPayroll.Columns.AddRange(New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn() {Me.GridColumnIDPayroll, Me.GridColumnIDEmployee, Me.GCIsOfficePayroll, Me.GridColumnGroupReport, Me.GridColumnDepartement, Me.BandedGridColumn1, Me.GridColumnDepartementSub, Me.BandedGridColumnCheck, Me.BandedGridColumnSent, Me.GridColumnNIP, Me.GridColumnName, Me.GridColumnPosition, Me.GridColumnStatus, Me.GridColumnWorkingDays, Me.BandedGridColumnActWorkdays, Me.BandedGridColumnOvertimeHours, Me.GridColumnBasicSalary, Me.GridColumnJobAllowance, Me.GridColumnMealAllowance, Me.GridColumnTransportAllowance, Me.BandedGridColumnTotFixedSalary, Me.GridColumnHousingAllowance, Me.GridColumnVehicleAttndAllowance, Me.GridColumnTotTHP, Me.BandedGridColumnTotalAdjustment, Me.BandedGridColumnTotalDeduction, Me.GridColumnPointRegular, Me.GridColumnOTReguler, Me.GridColumnPointMkt, Me.GridColumnOtMkt, Me.GridColumnPointIA, Me.GridColumnOtIA, Me.GridColumnPointSales, Me.GridColumnOtSales, Me.GridColumnPointProd, Me.GridColumnOTProd, Me.GridColumnPointGeneral, Me.GridColumnOtGeneral, Me.BandedGridColumnTotalPaymentOt, Me.BandedGridColumnActWorkdaysDW, Me.GridColumnBasicSalaryDW, Me.GridColumnTotalSalaryDW, Me.BandedGridColumnActualJoinDateTHR, Me.BandedGridColumnLengthTHR, Me.BandedGridColumnTotalSalaryTHR, Me.BandedGridColumnGrandTotal, Me.BandedGridColumnPending, Me.BandedGridColumnCash})
        Me.GVPayroll.GridControl = Me.GCPayroll
        Me.GVPayroll.GroupCount = 3
        Me.GVPayroll.GroupSummary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "basic_salary", Me.GridColumnBasicSalary, "{0:N0}"), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "allow_job", Me.GridColumnJobAllowance, "{0:N0}"), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "allow_meal", Me.GridColumnMealAllowance, "{0:N0}"), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "allow_trans", Me.GridColumnTransportAllowance, "{0:N0}"), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "allow_house", Me.GridColumnHousingAllowance, "{0:N0}"), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "allow_car", Me.GridColumnVehicleAttndAllowance, "{0:N0}"), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "tot_thp", Me.GridColumnTotTHP, "{0:N0}"), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "total_adjustment", Me.BandedGridColumnTotalAdjustment, "{0:N0}"), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "total_deduction", Me.BandedGridColumnTotalDeduction, "{0:N0}"), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "reg_total_point", Me.GridColumnPointRegular, "{0:N1}"), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "reg_total_wages", Me.GridColumnOTReguler, "{0:N0}"), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "mkt_total_point", Me.GridColumnPointMkt, "{0:N1}"), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "mkt_total_wages", Me.GridColumnOtMkt, "{0:N0}"), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "ia_total_point", Me.GridColumnPointIA, "{0:N1}"), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "ia_total_wages", Me.GridColumnOtIA, "{0:N0}"), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "prod_total_point", Me.GridColumnPointProd, "{0:N1}"), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "prod_total_wages", Me.GridColumnOTProd, "{0:N0}"), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "sales_total_point", Me.GridColumnPointSales, "{0:N1}"), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "sales_total_wages", Me.GridColumnOtSales, "{0:N0}"), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "general_total_point", Me.GridColumnPointGeneral, "{0:N1}"), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "general_total_wages", Me.GridColumnOtGeneral, "{0:N0}"), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "total_ot_wages", Me.BandedGridColumnTotalPaymentOt, "{0:N0}"), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "grand_total", Me.BandedGridColumnGrandTotal, "{0:N0}"), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Average, "id_departement_sub", Me.BandedGridColumn1, "{0}"), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "total_salary_dw", Me.GridColumnTotalSalaryDW, "{0:N0}"), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "tot_salary_basic", Me.BandedGridColumnTotFixedSalary, "{0:N0}"), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "total_salary_thr", Me.BandedGridColumnTotalSalaryTHR, "{0:N0}")})
        Me.GVPayroll.Name = "GVPayroll"
        Me.GVPayroll.OptionsBehavior.AutoExpandAllGroups = True
        Me.GVPayroll.OptionsMenu.ShowConditionalFormattingItem = True
        Me.GVPayroll.OptionsView.ColumnAutoWidth = False
        Me.GVPayroll.OptionsView.GroupFooterShowMode = DevExpress.XtraGrid.Views.Grid.GroupFooterShowMode.VisibleAlways
        Me.GVPayroll.OptionsView.ShowFooter = True
        Me.GVPayroll.OptionsView.ShowGroupExpandCollapseButtons = False
        Me.GVPayroll.OptionsView.ShowGroupPanel = False
        Me.GVPayroll.SortInfo.AddRange(New DevExpress.XtraGrid.Columns.GridColumnSortInfo() {New DevExpress.XtraGrid.Columns.GridColumnSortInfo(Me.GridColumnGroupReport, DevExpress.Data.ColumnSortOrder.Ascending), New DevExpress.XtraGrid.Columns.GridColumnSortInfo(Me.GridColumnDepartement, DevExpress.Data.ColumnSortOrder.Ascending), New DevExpress.XtraGrid.Columns.GridColumnSortInfo(Me.GridColumnDepartementSub, DevExpress.Data.ColumnSortOrder.Ascending)})
        '
        'gridBand8
        '
        Me.gridBand8.AppearanceHeader.Options.UseTextOptions = True
        Me.gridBand8.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.gridBand8.Caption = "Employee"
        Me.gridBand8.Columns.Add(Me.GridColumnGroupReport)
        Me.gridBand8.Columns.Add(Me.GridColumnDepartement)
        Me.gridBand8.Columns.Add(Me.BandedGridColumnCheck)
        Me.gridBand8.Columns.Add(Me.BandedGridColumnSent)
        Me.gridBand8.Columns.Add(Me.GridColumnNIP)
        Me.gridBand8.Columns.Add(Me.GridColumnName)
        Me.gridBand8.Columns.Add(Me.GridColumnPosition)
        Me.gridBand8.Columns.Add(Me.GridColumnStatus)
        Me.gridBand8.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left
        Me.gridBand8.Name = "gridBand8"
        Me.gridBand8.VisibleIndex = 0
        Me.gridBand8.Width = 429
        '
        'GridColumnGroupReport
        '
        Me.GridColumnGroupReport.Caption = "Group"
        Me.GridColumnGroupReport.FieldName = "group_report"
        Me.GridColumnGroupReport.Name = "GridColumnGroupReport"
        Me.GridColumnGroupReport.OptionsColumn.AllowEdit = False
        Me.GridColumnGroupReport.Width = 83
        '
        'GridColumnDepartement
        '
        Me.GridColumnDepartement.Caption = "Departement"
        Me.GridColumnDepartement.FieldName = "departement"
        Me.GridColumnDepartement.Name = "GridColumnDepartement"
        Me.GridColumnDepartement.OptionsColumn.AllowEdit = False
        Me.GridColumnDepartement.Width = 83
        '
        'BandedGridColumnCheck
        '
        Me.BandedGridColumnCheck.Caption = " "
        Me.BandedGridColumnCheck.ColumnEdit = Me.RICECheck
        Me.BandedGridColumnCheck.FieldName = "is_check"
        Me.BandedGridColumnCheck.MinWidth = 30
        Me.BandedGridColumnCheck.Name = "BandedGridColumnCheck"
        Me.BandedGridColumnCheck.Visible = True
        Me.BandedGridColumnCheck.Width = 93
        '
        'RICECheck
        '
        Me.RICECheck.AutoHeight = False
        Me.RICECheck.Name = "RICECheck"
        Me.RICECheck.ValueChecked = "yes"
        Me.RICECheck.ValueUnchecked = "no"
        '
        'BandedGridColumnSent
        '
        Me.BandedGridColumnSent.Caption = "Sent"
        Me.BandedGridColumnSent.ColumnEdit = Me.RICESent
        Me.BandedGridColumnSent.FieldName = "slip_send"
        Me.BandedGridColumnSent.Name = "BandedGridColumnSent"
        Me.BandedGridColumnSent.OptionsColumn.AllowEdit = False
        '
        'RICESent
        '
        Me.RICESent.AutoHeight = False
        Me.RICESent.CheckStyle = DevExpress.XtraEditors.Controls.CheckStyles.UserDefined
        Me.RICESent.ImageIndexChecked = 19
        Me.RICESent.Images = Me.LargeImageCollection
        Me.RICESent.Name = "RICESent"
        Me.RICESent.ValueChecked = "yes"
        Me.RICESent.ValueUnchecked = "no"
        '
        'GridColumnNIP
        '
        Me.GridColumnNIP.Caption = "NIP"
        Me.GridColumnNIP.FieldName = "employee_code"
        Me.GridColumnNIP.Name = "GridColumnNIP"
        Me.GridColumnNIP.OptionsColumn.AllowEdit = False
        Me.GridColumnNIP.Visible = True
        '
        'GridColumnName
        '
        Me.GridColumnName.Caption = "Employee"
        Me.GridColumnName.FieldName = "employee_name"
        Me.GridColumnName.Name = "GridColumnName"
        Me.GridColumnName.OptionsColumn.AllowEdit = False
        Me.GridColumnName.Visible = True
        '
        'GridColumnPosition
        '
        Me.GridColumnPosition.Caption = "Employee Position"
        Me.GridColumnPosition.FieldName = "employee_position"
        Me.GridColumnPosition.Name = "GridColumnPosition"
        Me.GridColumnPosition.OptionsColumn.AllowEdit = False
        Me.GridColumnPosition.Visible = True
        Me.GridColumnPosition.Width = 96
        '
        'GridColumnStatus
        '
        Me.GridColumnStatus.Caption = "Employee Status"
        Me.GridColumnStatus.FieldName = "employee_status"
        Me.GridColumnStatus.Name = "GridColumnStatus"
        Me.GridColumnStatus.OptionsColumn.AllowEdit = False
        Me.GridColumnStatus.Visible = True
        Me.GridColumnStatus.Width = 90
        '
        'GBWorkingDays
        '
        Me.GBWorkingDays.AppearanceHeader.Options.UseTextOptions = True
        Me.GBWorkingDays.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GBWorkingDays.Caption = "Working Days"
        Me.GBWorkingDays.Columns.Add(Me.GridColumnWorkingDays)
        Me.GBWorkingDays.Columns.Add(Me.BandedGridColumnActWorkdays)
        Me.GBWorkingDays.Columns.Add(Me.BandedGridColumnOvertimeHours)
        Me.GBWorkingDays.Name = "GBWorkingDays"
        Me.GBWorkingDays.VisibleIndex = 1
        Me.GBWorkingDays.Width = 278
        '
        'GridColumnWorkingDays
        '
        Me.GridColumnWorkingDays.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumnWorkingDays.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumnWorkingDays.Caption = "Working Days"
        Me.GridColumnWorkingDays.DisplayFormat.FormatString = "N1"
        Me.GridColumnWorkingDays.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumnWorkingDays.FieldName = "workdays"
        Me.GridColumnWorkingDays.Name = "GridColumnWorkingDays"
        Me.GridColumnWorkingDays.OptionsColumn.AllowEdit = False
        Me.GridColumnWorkingDays.Visible = True
        Me.GridColumnWorkingDays.Width = 76
        '
        'BandedGridColumnActWorkdays
        '
        Me.BandedGridColumnActWorkdays.AppearanceCell.Options.UseTextOptions = True
        Me.BandedGridColumnActWorkdays.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.BandedGridColumnActWorkdays.Caption = "Actual Working Days"
        Me.BandedGridColumnActWorkdays.ColumnEdit = Me.RITEActWorkdays
        Me.BandedGridColumnActWorkdays.DisplayFormat.FormatString = "N1"
        Me.BandedGridColumnActWorkdays.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.BandedGridColumnActWorkdays.FieldName = "actual_workdays"
        Me.BandedGridColumnActWorkdays.Name = "BandedGridColumnActWorkdays"
        Me.BandedGridColumnActWorkdays.Visible = True
        Me.BandedGridColumnActWorkdays.Width = 109
        '
        'RITEActWorkdays
        '
        Me.RITEActWorkdays.AutoHeight = False
        Me.RITEActWorkdays.DisplayFormat.FormatString = "N1"
        Me.RITEActWorkdays.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.RITEActWorkdays.Name = "RITEActWorkdays"
        '
        'BandedGridColumnOvertimeHours
        '
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
        Me.GBSalary.Caption = "Salary"
        Me.GBSalary.Columns.Add(Me.GridColumnBasicSalary)
        Me.GBSalary.Columns.Add(Me.GridColumnJobAllowance)
        Me.GBSalary.Columns.Add(Me.GridColumnMealAllowance)
        Me.GBSalary.Columns.Add(Me.GridColumnTransportAllowance)
        Me.GBSalary.Columns.Add(Me.BandedGridColumnTotFixedSalary)
        Me.GBSalary.Columns.Add(Me.GridColumnHousingAllowance)
        Me.GBSalary.Columns.Add(Me.GridColumnVehicleAttndAllowance)
        Me.GBSalary.Columns.Add(Me.GridColumnTotTHP)
        Me.GBSalary.Name = "GBSalary"
        Me.GBSalary.VisibleIndex = 2
        Me.GBSalary.Width = 702
        '
        'GridColumnBasicSalary
        '
        Me.GridColumnBasicSalary.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumnBasicSalary.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumnBasicSalary.Caption = "Basic Salary"
        Me.GridColumnBasicSalary.DisplayFormat.FormatString = "N0"
        Me.GridColumnBasicSalary.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumnBasicSalary.FieldName = "basic_salary"
        Me.GridColumnBasicSalary.Name = "GridColumnBasicSalary"
        Me.GridColumnBasicSalary.OptionsColumn.AllowEdit = False
        Me.GridColumnBasicSalary.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "basic_salary", "{0:N0}")})
        Me.GridColumnBasicSalary.Visible = True
        '
        'GridColumnJobAllowance
        '
        Me.GridColumnJobAllowance.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumnJobAllowance.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumnJobAllowance.AppearanceHeader.Options.UseTextOptions = True
        Me.GridColumnJobAllowance.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumnJobAllowance.Caption = "Job Allowance"
        Me.GridColumnJobAllowance.DisplayFormat.FormatString = "N0"
        Me.GridColumnJobAllowance.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumnJobAllowance.FieldName = "allow_job"
        Me.GridColumnJobAllowance.Name = "GridColumnJobAllowance"
        Me.GridColumnJobAllowance.OptionsColumn.AllowEdit = False
        Me.GridColumnJobAllowance.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "allow_job", "{0:N0}")})
        Me.GridColumnJobAllowance.Visible = True
        Me.GridColumnJobAllowance.Width = 78
        '
        'GridColumnMealAllowance
        '
        Me.GridColumnMealAllowance.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumnMealAllowance.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumnMealAllowance.AppearanceHeader.Options.UseTextOptions = True
        Me.GridColumnMealAllowance.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumnMealAllowance.Caption = "Meal Allowance"
        Me.GridColumnMealAllowance.DisplayFormat.FormatString = "N0"
        Me.GridColumnMealAllowance.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumnMealAllowance.FieldName = "allow_meal"
        Me.GridColumnMealAllowance.Name = "GridColumnMealAllowance"
        Me.GridColumnMealAllowance.OptionsColumn.AllowEdit = False
        Me.GridColumnMealAllowance.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "allow_meal", "{0:N0}")})
        Me.GridColumnMealAllowance.Visible = True
        Me.GridColumnMealAllowance.Width = 83
        '
        'GridColumnTransportAllowance
        '
        Me.GridColumnTransportAllowance.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumnTransportAllowance.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumnTransportAllowance.AppearanceHeader.Options.UseTextOptions = True
        Me.GridColumnTransportAllowance.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumnTransportAllowance.Caption = "Transport Allowance"
        Me.GridColumnTransportAllowance.DisplayFormat.FormatString = "N0"
        Me.GridColumnTransportAllowance.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumnTransportAllowance.FieldName = "allow_trans"
        Me.GridColumnTransportAllowance.Name = "GridColumnTransportAllowance"
        Me.GridColumnTransportAllowance.OptionsColumn.AllowEdit = False
        Me.GridColumnTransportAllowance.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "allow_trans", "{0:N0}")})
        Me.GridColumnTransportAllowance.Visible = True
        Me.GridColumnTransportAllowance.Width = 108
        '
        'BandedGridColumnTotFixedSalary
        '
        Me.BandedGridColumnTotFixedSalary.Caption = "Fixed Salary"
        Me.BandedGridColumnTotFixedSalary.DisplayFormat.FormatString = "N0"
        Me.BandedGridColumnTotFixedSalary.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.BandedGridColumnTotFixedSalary.FieldName = "tot_salary_basic"
        Me.BandedGridColumnTotFixedSalary.Name = "BandedGridColumnTotFixedSalary"
        Me.BandedGridColumnTotFixedSalary.OptionsColumn.AllowEdit = False
        Me.BandedGridColumnTotFixedSalary.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "tot_salary_basic", "{0:N0}")})
        Me.BandedGridColumnTotFixedSalary.Visible = True
        '
        'GridColumnHousingAllowance
        '
        Me.GridColumnHousingAllowance.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumnHousingAllowance.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumnHousingAllowance.AppearanceHeader.Options.UseTextOptions = True
        Me.GridColumnHousingAllowance.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumnHousingAllowance.Caption = "House Allowance"
        Me.GridColumnHousingAllowance.DisplayFormat.FormatString = "N0"
        Me.GridColumnHousingAllowance.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumnHousingAllowance.FieldName = "allow_house"
        Me.GridColumnHousingAllowance.Name = "GridColumnHousingAllowance"
        Me.GridColumnHousingAllowance.OptionsColumn.AllowEdit = False
        Me.GridColumnHousingAllowance.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "allow_house", "{0:N0}")})
        Me.GridColumnHousingAllowance.Visible = True
        Me.GridColumnHousingAllowance.Width = 91
        '
        'GridColumnVehicleAttndAllowance
        '
        Me.GridColumnVehicleAttndAllowance.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumnVehicleAttndAllowance.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumnVehicleAttndAllowance.AppearanceHeader.Options.UseTextOptions = True
        Me.GridColumnVehicleAttndAllowance.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumnVehicleAttndAllowance.Caption = "Attendance Allowance"
        Me.GridColumnVehicleAttndAllowance.DisplayFormat.FormatString = "N0"
        Me.GridColumnVehicleAttndAllowance.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumnVehicleAttndAllowance.FieldName = "allow_car"
        Me.GridColumnVehicleAttndAllowance.Name = "GridColumnVehicleAttndAllowance"
        Me.GridColumnVehicleAttndAllowance.OptionsColumn.AllowEdit = False
        Me.GridColumnVehicleAttndAllowance.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "allow_car", "{0:N0}")})
        Me.GridColumnVehicleAttndAllowance.Visible = True
        Me.GridColumnVehicleAttndAllowance.Width = 117
        '
        'GridColumnTotTHP
        '
        Me.GridColumnTotTHP.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumnTotTHP.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumnTotTHP.AppearanceHeader.Options.UseTextOptions = True
        Me.GridColumnTotTHP.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumnTotTHP.Caption = "Total THP"
        Me.GridColumnTotTHP.DisplayFormat.FormatString = "N0"
        Me.GridColumnTotTHP.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumnTotTHP.FieldName = "tot_thp"
        Me.GridColumnTotTHP.Name = "GridColumnTotTHP"
        Me.GridColumnTotTHP.OptionsColumn.AllowEdit = False
        Me.GridColumnTotTHP.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "tot_thp", "{0:N0}")})
        Me.GridColumnTotTHP.Visible = True
        '
        'GBTHR
        '
        Me.GBTHR.Columns.Add(Me.BandedGridColumnActualJoinDateTHR)
        Me.GBTHR.Columns.Add(Me.BandedGridColumnLengthTHR)
        Me.GBTHR.Columns.Add(Me.BandedGridColumnTotalSalaryTHR)
        Me.GBTHR.Name = "GBTHR"
        Me.GBTHR.VisibleIndex = 3
        Me.GBTHR.Width = 280
        '
        'BandedGridColumnActualJoinDateTHR
        '
        Me.BandedGridColumnActualJoinDateTHR.Caption = "Actual Join Date"
        Me.BandedGridColumnActualJoinDateTHR.FieldName = "employee_actual_join_date"
        Me.BandedGridColumnActualJoinDateTHR.Name = "BandedGridColumnActualJoinDateTHR"
        Me.BandedGridColumnActualJoinDateTHR.OptionsColumn.AllowEdit = False
        Me.BandedGridColumnActualJoinDateTHR.Visible = True
        Me.BandedGridColumnActualJoinDateTHR.Width = 88
        '
        'BandedGridColumnLengthTHR
        '
        Me.BandedGridColumnLengthTHR.Caption = "Length of Work (Year)"
        Me.BandedGridColumnLengthTHR.DisplayFormat.FormatString = "N2"
        Me.BandedGridColumnLengthTHR.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.BandedGridColumnLengthTHR.FieldName = "actual_workdays"
        Me.BandedGridColumnLengthTHR.Name = "BandedGridColumnLengthTHR"
        Me.BandedGridColumnLengthTHR.OptionsColumn.AllowEdit = False
        Me.BandedGridColumnLengthTHR.Visible = True
        Me.BandedGridColumnLengthTHR.Width = 117
        '
        'BandedGridColumnTotalSalaryTHR
        '
        Me.BandedGridColumnTotalSalaryTHR.Caption = "Total THR"
        Me.BandedGridColumnTotalSalaryTHR.ColumnEdit = Me.RITETotalSalaryTHR
        Me.BandedGridColumnTotalSalaryTHR.DisplayFormat.FormatString = "N0"
        Me.BandedGridColumnTotalSalaryTHR.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.BandedGridColumnTotalSalaryTHR.FieldName = "total_salary_thr"
        Me.BandedGridColumnTotalSalaryTHR.Name = "BandedGridColumnTotalSalaryTHR"
        Me.BandedGridColumnTotalSalaryTHR.OptionsColumn.AllowEdit = False
        Me.BandedGridColumnTotalSalaryTHR.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "total_salary_thr", "{0:N0}")})
        Me.BandedGridColumnTotalSalaryTHR.Visible = True
        '
        'RITETotalSalaryTHR
        '
        Me.RITETotalSalaryTHR.AutoHeight = False
        Me.RITETotalSalaryTHR.DisplayFormat.FormatString = "N0"
        Me.RITETotalSalaryTHR.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.RITETotalSalaryTHR.EditFormat.FormatString = "N0"
        Me.RITETotalSalaryTHR.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.RITETotalSalaryTHR.Mask.EditMask = "N0"
        Me.RITETotalSalaryTHR.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric
        Me.RITETotalSalaryTHR.Mask.UseMaskAsDisplayFormat = True
        Me.RITETotalSalaryTHR.Name = "RITETotalSalaryTHR"
        '
        'GBDW
        '
        Me.GBDW.Columns.Add(Me.BandedGridColumnActWorkdaysDW)
        Me.GBDW.Columns.Add(Me.GridColumnBasicSalaryDW)
        Me.GBDW.Columns.Add(Me.GridColumnTotalSalaryDW)
        Me.GBDW.Name = "GBDW"
        Me.GBDW.VisibleIndex = 4
        Me.GBDW.Width = 290
        '
        'BandedGridColumnActWorkdaysDW
        '
        Me.BandedGridColumnActWorkdaysDW.AppearanceCell.Options.UseTextOptions = True
        Me.BandedGridColumnActWorkdaysDW.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.BandedGridColumnActWorkdaysDW.Caption = "Actual Working Days"
        Me.BandedGridColumnActWorkdaysDW.ColumnEdit = Me.RITEActWorkdaysDW
        Me.BandedGridColumnActWorkdaysDW.DisplayFormat.FormatString = "N1"
        Me.BandedGridColumnActWorkdaysDW.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.BandedGridColumnActWorkdaysDW.FieldName = "actual_workdays"
        Me.BandedGridColumnActWorkdaysDW.Name = "BandedGridColumnActWorkdaysDW"
        Me.BandedGridColumnActWorkdaysDW.Visible = True
        Me.BandedGridColumnActWorkdaysDW.Width = 109
        '
        'RITEActWorkdaysDW
        '
        Me.RITEActWorkdaysDW.AutoHeight = False
        Me.RITEActWorkdaysDW.DisplayFormat.FormatString = "N1"
        Me.RITEActWorkdaysDW.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.RITEActWorkdaysDW.Name = "RITEActWorkdaysDW"
        '
        'GridColumnBasicSalaryDW
        '
        Me.GridColumnBasicSalaryDW.Caption = "Daily Salary"
        Me.GridColumnBasicSalaryDW.DisplayFormat.FormatString = "N0"
        Me.GridColumnBasicSalaryDW.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumnBasicSalaryDW.FieldName = "basic_salary"
        Me.GridColumnBasicSalaryDW.Name = "GridColumnBasicSalaryDW"
        Me.GridColumnBasicSalaryDW.OptionsColumn.AllowEdit = False
        Me.GridColumnBasicSalaryDW.Visible = True
        Me.GridColumnBasicSalaryDW.Width = 106
        '
        'GridColumnTotalSalaryDW
        '
        Me.GridColumnTotalSalaryDW.Caption = "Total Salary"
        Me.GridColumnTotalSalaryDW.DisplayFormat.FormatString = "N0"
        Me.GridColumnTotalSalaryDW.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumnTotalSalaryDW.FieldName = "total_salary_dw"
        Me.GridColumnTotalSalaryDW.Name = "GridColumnTotalSalaryDW"
        Me.GridColumnTotalSalaryDW.OptionsColumn.AllowEdit = False
        Me.GridColumnTotalSalaryDW.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "total_salary_dw", "{0:N0}")})
        Me.GridColumnTotalSalaryDW.Visible = True
        '
        'GBBonusAdjustment
        '
        Me.GBBonusAdjustment.AppearanceHeader.Options.UseTextOptions = True
        Me.GBBonusAdjustment.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GBBonusAdjustment.Caption = "Bonus / Adjustment"
        Me.GBBonusAdjustment.Columns.Add(Me.BandedGridColumnTotalAdjustment)
        Me.GBBonusAdjustment.Name = "GBBonusAdjustment"
        Me.GBBonusAdjustment.VisibleIndex = 5
        Me.GBBonusAdjustment.Width = 131
        '
        'BandedGridColumnTotalAdjustment
        '
        Me.BandedGridColumnTotalAdjustment.AppearanceCell.Options.UseTextOptions = True
        Me.BandedGridColumnTotalAdjustment.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.BandedGridColumnTotalAdjustment.AppearanceHeader.Options.UseTextOptions = True
        Me.BandedGridColumnTotalAdjustment.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.BandedGridColumnTotalAdjustment.Caption = "Total Bonus / Adjustment"
        Me.BandedGridColumnTotalAdjustment.DisplayFormat.FormatString = "N0"
        Me.BandedGridColumnTotalAdjustment.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.BandedGridColumnTotalAdjustment.FieldName = "total_adjustment"
        Me.BandedGridColumnTotalAdjustment.Name = "BandedGridColumnTotalAdjustment"
        Me.BandedGridColumnTotalAdjustment.OptionsColumn.AllowEdit = False
        Me.BandedGridColumnTotalAdjustment.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "total_adjustment", "{0:N0}")})
        Me.BandedGridColumnTotalAdjustment.Visible = True
        Me.BandedGridColumnTotalAdjustment.Width = 131
        '
        'GBOvertime
        '
        Me.GBOvertime.AppearanceHeader.Options.UseTextOptions = True
        Me.GBOvertime.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GBOvertime.Caption = "Overtime"
        Me.GBOvertime.Columns.Add(Me.GridColumnPointRegular)
        Me.GBOvertime.Columns.Add(Me.GridColumnOTReguler)
        Me.GBOvertime.Columns.Add(Me.GridColumnPointMkt)
        Me.GBOvertime.Columns.Add(Me.GridColumnOtMkt)
        Me.GBOvertime.Columns.Add(Me.GridColumnPointIA)
        Me.GBOvertime.Columns.Add(Me.GridColumnOtIA)
        Me.GBOvertime.Columns.Add(Me.GridColumnPointSales)
        Me.GBOvertime.Columns.Add(Me.GridColumnOtSales)
        Me.GBOvertime.Columns.Add(Me.GridColumnPointProd)
        Me.GBOvertime.Columns.Add(Me.GridColumnOTProd)
        Me.GBOvertime.Columns.Add(Me.GridColumnPointGeneral)
        Me.GBOvertime.Columns.Add(Me.GridColumnOtGeneral)
        Me.GBOvertime.Columns.Add(Me.BandedGridColumnTotalPaymentOt)
        Me.GBOvertime.Name = "GBOvertime"
        Me.GBOvertime.VisibleIndex = 6
        Me.GBOvertime.Width = 1288
        '
        'GridColumnPointRegular
        '
        Me.GridColumnPointRegular.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumnPointRegular.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumnPointRegular.AppearanceHeader.Options.UseTextOptions = True
        Me.GridColumnPointRegular.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumnPointRegular.Caption = "Point Reguler"
        Me.GridColumnPointRegular.DisplayFormat.FormatString = "N1"
        Me.GridColumnPointRegular.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumnPointRegular.FieldName = "reg_total_point"
        Me.GridColumnPointRegular.Name = "GridColumnPointRegular"
        Me.GridColumnPointRegular.OptionsColumn.AllowEdit = False
        Me.GridColumnPointRegular.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "reg_total_point", "{0:N1}")})
        Me.GridColumnPointRegular.Visible = True
        '
        'GridColumnOTReguler
        '
        Me.GridColumnOTReguler.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumnOTReguler.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumnOTReguler.AppearanceHeader.Options.UseTextOptions = True
        Me.GridColumnOTReguler.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumnOTReguler.Caption = "Overtime Reguler"
        Me.GridColumnOTReguler.DisplayFormat.FormatString = "N0"
        Me.GridColumnOTReguler.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumnOTReguler.FieldName = "reg_total_wages"
        Me.GridColumnOTReguler.Name = "GridColumnOTReguler"
        Me.GridColumnOTReguler.OptionsColumn.AllowEdit = False
        Me.GridColumnOTReguler.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "reg_total_wages", "{0:N0}")})
        Me.GridColumnOTReguler.Visible = True
        Me.GridColumnOTReguler.Width = 94
        '
        'GridColumnPointMkt
        '
        Me.GridColumnPointMkt.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumnPointMkt.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumnPointMkt.AppearanceHeader.Options.UseTextOptions = True
        Me.GridColumnPointMkt.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumnPointMkt.Caption = "Point Event Marketing"
        Me.GridColumnPointMkt.DisplayFormat.FormatString = "N1"
        Me.GridColumnPointMkt.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumnPointMkt.FieldName = "mkt_total_point"
        Me.GridColumnPointMkt.Name = "GridColumnPointMkt"
        Me.GridColumnPointMkt.OptionsColumn.AllowEdit = False
        Me.GridColumnPointMkt.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "mkt_total_point", "{0:N1}")})
        Me.GridColumnPointMkt.Visible = True
        Me.GridColumnPointMkt.Width = 115
        '
        'GridColumnOtMkt
        '
        Me.GridColumnOtMkt.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumnOtMkt.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumnOtMkt.AppearanceHeader.Options.UseTextOptions = True
        Me.GridColumnOtMkt.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumnOtMkt.Caption = "Overtime Marketing"
        Me.GridColumnOtMkt.DisplayFormat.FormatString = "N0"
        Me.GridColumnOtMkt.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumnOtMkt.FieldName = "mkt_total_wages"
        Me.GridColumnOtMkt.Name = "GridColumnOtMkt"
        Me.GridColumnOtMkt.OptionsColumn.AllowEdit = False
        Me.GridColumnOtMkt.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "mkt_total_wages", "{0:N0}")})
        Me.GridColumnOtMkt.Visible = True
        Me.GridColumnOtMkt.Width = 104
        '
        'GridColumnPointIA
        '
        Me.GridColumnPointIA.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumnPointIA.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumnPointIA.AppearanceHeader.Options.UseTextOptions = True
        Me.GridColumnPointIA.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumnPointIA.Caption = "Point Event IA"
        Me.GridColumnPointIA.DisplayFormat.FormatString = "N1"
        Me.GridColumnPointIA.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumnPointIA.FieldName = "ia_total_point"
        Me.GridColumnPointIA.Name = "GridColumnPointIA"
        Me.GridColumnPointIA.OptionsColumn.AllowEdit = False
        Me.GridColumnPointIA.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "ia_total_point", "{0:N1}")})
        Me.GridColumnPointIA.Visible = True
        Me.GridColumnPointIA.Width = 79
        '
        'GridColumnOtIA
        '
        Me.GridColumnOtIA.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumnOtIA.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumnOtIA.AppearanceHeader.Options.UseTextOptions = True
        Me.GridColumnOtIA.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumnOtIA.Caption = "Overtime IA"
        Me.GridColumnOtIA.DisplayFormat.FormatString = "N0"
        Me.GridColumnOtIA.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumnOtIA.FieldName = "ia_total_wages"
        Me.GridColumnOtIA.Name = "GridColumnOtIA"
        Me.GridColumnOtIA.OptionsColumn.AllowEdit = False
        Me.GridColumnOtIA.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "ia_total_wages", "{0:N0}")})
        Me.GridColumnOtIA.Visible = True
        '
        'GridColumnPointSales
        '
        Me.GridColumnPointSales.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumnPointSales.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumnPointSales.AppearanceHeader.Options.UseTextOptions = True
        Me.GridColumnPointSales.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumnPointSales.Caption = "Point Event Sales"
        Me.GridColumnPointSales.DisplayFormat.FormatString = "N1"
        Me.GridColumnPointSales.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumnPointSales.FieldName = "sales_total_point"
        Me.GridColumnPointSales.Name = "GridColumnPointSales"
        Me.GridColumnPointSales.OptionsColumn.AllowEdit = False
        Me.GridColumnPointSales.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "sales_total_point", "{0:N1}")})
        Me.GridColumnPointSales.Visible = True
        Me.GridColumnPointSales.Width = 93
        '
        'GridColumnOtSales
        '
        Me.GridColumnOtSales.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumnOtSales.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumnOtSales.AppearanceHeader.Options.UseTextOptions = True
        Me.GridColumnOtSales.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumnOtSales.Caption = "Overtime Sales"
        Me.GridColumnOtSales.DisplayFormat.FormatString = "N0"
        Me.GridColumnOtSales.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumnOtSales.FieldName = "sales_total_wages"
        Me.GridColumnOtSales.Name = "GridColumnOtSales"
        Me.GridColumnOtSales.OptionsColumn.AllowEdit = False
        Me.GridColumnOtSales.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "sales_total_wages", "{0:N0}")})
        Me.GridColumnOtSales.Visible = True
        Me.GridColumnOtSales.Width = 82
        '
        'GridColumnPointProd
        '
        Me.GridColumnPointProd.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumnPointProd.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumnPointProd.AppearanceHeader.Options.UseTextOptions = True
        Me.GridColumnPointProd.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumnPointProd.Caption = "Point Event Production"
        Me.GridColumnPointProd.DisplayFormat.FormatString = "N1"
        Me.GridColumnPointProd.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumnPointProd.FieldName = "prod_total_point"
        Me.GridColumnPointProd.Name = "GridColumnPointProd"
        Me.GridColumnPointProd.OptionsColumn.AllowEdit = False
        Me.GridColumnPointProd.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "prod_total_point", "{0:N1}")})
        Me.GridColumnPointProd.Visible = True
        Me.GridColumnPointProd.Width = 119
        '
        'GridColumnOTProd
        '
        Me.GridColumnOTProd.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumnOTProd.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumnOTProd.AppearanceHeader.Options.UseTextOptions = True
        Me.GridColumnOTProd.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumnOTProd.Caption = "Overtime Production"
        Me.GridColumnOTProd.DisplayFormat.FormatString = "N0"
        Me.GridColumnOTProd.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumnOTProd.FieldName = "prod_total_wages"
        Me.GridColumnOTProd.Name = "GridColumnOTProd"
        Me.GridColumnOTProd.OptionsColumn.AllowEdit = False
        Me.GridColumnOTProd.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "prod_total_wages", "{0:N0}")})
        Me.GridColumnOTProd.Visible = True
        Me.GridColumnOTProd.Width = 108
        '
        'GridColumnPointGeneral
        '
        Me.GridColumnPointGeneral.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumnPointGeneral.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumnPointGeneral.AppearanceHeader.Options.UseTextOptions = True
        Me.GridColumnPointGeneral.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumnPointGeneral.Caption = "Point Event General/Other"
        Me.GridColumnPointGeneral.DisplayFormat.FormatString = "N1"
        Me.GridColumnPointGeneral.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumnPointGeneral.FieldName = "general_total_point"
        Me.GridColumnPointGeneral.Name = "GridColumnPointGeneral"
        Me.GridColumnPointGeneral.OptionsColumn.AllowEdit = False
        Me.GridColumnPointGeneral.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "general_total_point", "{0:N1}")})
        Me.GridColumnPointGeneral.Visible = True
        Me.GridColumnPointGeneral.Width = 137
        '
        'GridColumnOtGeneral
        '
        Me.GridColumnOtGeneral.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumnOtGeneral.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumnOtGeneral.AppearanceHeader.Options.UseTextOptions = True
        Me.GridColumnOtGeneral.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumnOtGeneral.Caption = "Overtime General/Other"
        Me.GridColumnOtGeneral.DisplayFormat.FormatString = "N0"
        Me.GridColumnOtGeneral.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumnOtGeneral.FieldName = "general_total_wages"
        Me.GridColumnOtGeneral.Name = "GridColumnOtGeneral"
        Me.GridColumnOtGeneral.OptionsColumn.AllowEdit = False
        Me.GridColumnOtGeneral.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "general_total_wages", "{0:N0}")})
        Me.GridColumnOtGeneral.Visible = True
        Me.GridColumnOtGeneral.Width = 126
        '
        'BandedGridColumnTotalPaymentOt
        '
        Me.BandedGridColumnTotalPaymentOt.AppearanceCell.Options.UseTextOptions = True
        Me.BandedGridColumnTotalPaymentOt.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.BandedGridColumnTotalPaymentOt.AppearanceHeader.Options.UseTextOptions = True
        Me.BandedGridColumnTotalPaymentOt.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.BandedGridColumnTotalPaymentOt.Caption = "Total Overtime"
        Me.BandedGridColumnTotalPaymentOt.DisplayFormat.FormatString = "N0"
        Me.BandedGridColumnTotalPaymentOt.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.BandedGridColumnTotalPaymentOt.FieldName = "total_ot_wages"
        Me.BandedGridColumnTotalPaymentOt.Name = "BandedGridColumnTotalPaymentOt"
        Me.BandedGridColumnTotalPaymentOt.OptionsColumn.AllowEdit = False
        Me.BandedGridColumnTotalPaymentOt.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "total_ot_wages", "{0:N0}")})
        Me.BandedGridColumnTotalPaymentOt.Visible = True
        Me.BandedGridColumnTotalPaymentOt.Width = 81
        '
        'GBDeduction
        '
        Me.GBDeduction.AppearanceHeader.Options.UseTextOptions = True
        Me.GBDeduction.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GBDeduction.Caption = "Deduction"
        Me.GBDeduction.Columns.Add(Me.BandedGridColumnTotalDeduction)
        Me.GBDeduction.Name = "GBDeduction"
        Me.GBDeduction.VisibleIndex = 7
        Me.GBDeduction.Width = 90
        '
        'BandedGridColumnTotalDeduction
        '
        Me.BandedGridColumnTotalDeduction.AppearanceCell.Options.UseTextOptions = True
        Me.BandedGridColumnTotalDeduction.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.BandedGridColumnTotalDeduction.AppearanceHeader.Options.UseTextOptions = True
        Me.BandedGridColumnTotalDeduction.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.BandedGridColumnTotalDeduction.Caption = "Total Deduction"
        Me.BandedGridColumnTotalDeduction.DisplayFormat.FormatString = "N0"
        Me.BandedGridColumnTotalDeduction.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.BandedGridColumnTotalDeduction.FieldName = "total_deduction"
        Me.BandedGridColumnTotalDeduction.Name = "BandedGridColumnTotalDeduction"
        Me.BandedGridColumnTotalDeduction.OptionsColumn.AllowEdit = False
        Me.BandedGridColumnTotalDeduction.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "total_deduction", "{0:N0}")})
        Me.BandedGridColumnTotalDeduction.Visible = True
        Me.BandedGridColumnTotalDeduction.Width = 90
        '
        'GBTotal
        '
        Me.GBTotal.Columns.Add(Me.BandedGridColumnGrandTotal)
        Me.GBTotal.Name = "GBTotal"
        Me.GBTotal.VisibleIndex = 8
        Me.GBTotal.Width = 75
        '
        'BandedGridColumnGrandTotal
        '
        Me.BandedGridColumnGrandTotal.AppearanceCell.Options.UseTextOptions = True
        Me.BandedGridColumnGrandTotal.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.BandedGridColumnGrandTotal.AppearanceHeader.Options.UseTextOptions = True
        Me.BandedGridColumnGrandTotal.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.BandedGridColumnGrandTotal.Caption = "Grand Total"
        Me.BandedGridColumnGrandTotal.DisplayFormat.FormatString = "N0"
        Me.BandedGridColumnGrandTotal.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.BandedGridColumnGrandTotal.FieldName = "grand_total"
        Me.BandedGridColumnGrandTotal.Name = "BandedGridColumnGrandTotal"
        Me.BandedGridColumnGrandTotal.OptionsColumn.AllowEdit = False
        Me.BandedGridColumnGrandTotal.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "grand_total", "{0:N0}")})
        Me.BandedGridColumnGrandTotal.Visible = True
        '
        'GBExtraNote
        '
        Me.GBExtraNote.Caption = "Extra Note"
        Me.GBExtraNote.Columns.Add(Me.BandedGridColumnPending)
        Me.GBExtraNote.Columns.Add(Me.BandedGridColumnCash)
        Me.GBExtraNote.Name = "GBExtraNote"
        Me.GBExtraNote.VisibleIndex = 9
        Me.GBExtraNote.Width = 150
        '
        'BandedGridColumnPending
        '
        Me.BandedGridColumnPending.Caption = "Pending"
        Me.BandedGridColumnPending.ColumnEdit = Me.RICEPending
        Me.BandedGridColumnPending.FieldName = "is_pending"
        Me.BandedGridColumnPending.Name = "BandedGridColumnPending"
        Me.BandedGridColumnPending.Visible = True
        '
        'RICEPending
        '
        Me.RICEPending.AutoHeight = False
        Me.RICEPending.Name = "RICEPending"
        Me.RICEPending.ValueChecked = "yes"
        Me.RICEPending.ValueUnchecked = "no"
        '
        'BandedGridColumnCash
        '
        Me.BandedGridColumnCash.Caption = "Cash"
        Me.BandedGridColumnCash.ColumnEdit = Me.RICEPending
        Me.BandedGridColumnCash.FieldName = "is_cash"
        Me.BandedGridColumnCash.Name = "BandedGridColumnCash"
        Me.BandedGridColumnCash.Visible = True
        '
        'GridColumnIDPayroll
        '
        Me.GridColumnIDPayroll.FieldName = "id_payroll_det"
        Me.GridColumnIDPayroll.Name = "GridColumnIDPayroll"
        Me.GridColumnIDPayroll.OptionsColumn.AllowEdit = False
        '
        'GridColumnIDEmployee
        '
        Me.GridColumnIDEmployee.FieldName = "id_employee"
        Me.GridColumnIDEmployee.Name = "GridColumnIDEmployee"
        Me.GridColumnIDEmployee.OptionsColumn.AllowEdit = False
        '
        'GCIsOfficePayroll
        '
        Me.GCIsOfficePayroll.FieldName = "is_office_payroll"
        Me.GCIsOfficePayroll.Name = "GCIsOfficePayroll"
        Me.GCIsOfficePayroll.OptionsColumn.AllowEdit = False
        '
        'BandedGridColumn1
        '
        Me.BandedGridColumn1.FieldName = "id_departement_sub"
        Me.BandedGridColumn1.Name = "BandedGridColumn1"
        '
        'GridColumnDepartementSub
        '
        Me.GridColumnDepartementSub.Caption = "Sub Departement"
        Me.GridColumnDepartementSub.FieldName = "departement_sub"
        Me.GridColumnDepartementSub.Name = "GridColumnDepartementSub"
        Me.GridColumnDepartementSub.OptionsColumn.AllowEdit = False
        '
        'PanelControl2
        '
        Me.PanelControl2.Controls.Add(Me.PanelControl3)
        Me.PanelControl2.Controls.Add(Me.BtnAttachment)
        Me.PanelControl2.Controls.Add(Me.BReport)
        Me.PanelControl2.Controls.Add(Me.SBSendSlip)
        Me.PanelControl2.Controls.Add(Me.BPrintSlip)
        Me.PanelControl2.Controls.Add(Me.PCSelAll)
        Me.PanelControl2.Controls.Add(Me.BMark)
        Me.PanelControl2.Controls.Add(Me.PBCLineList)
        Me.PanelControl2.Controls.Add(Me.BPrint)
        Me.PanelControl2.Controls.Add(Me.BReset)
        Me.PanelControl2.Controls.Add(Me.BSubmit)
        Me.PanelControl2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PanelControl2.Location = New System.Drawing.Point(0, 662)
        Me.PanelControl2.Name = "PanelControl2"
        Me.PanelControl2.Size = New System.Drawing.Size(1338, 39)
        Me.PanelControl2.TabIndex = 2
        '
        'PanelControl3
        '
        Me.PanelControl3.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
        Me.PanelControl3.Controls.Add(Me.CheckEditViewSend)
        Me.PanelControl3.Dock = System.Windows.Forms.DockStyle.Left
        Me.PanelControl3.Location = New System.Drawing.Point(298, 2)
        Me.PanelControl3.Name = "PanelControl3"
        Me.PanelControl3.Size = New System.Drawing.Size(96, 35)
        Me.PanelControl3.TabIndex = 114
        '
        'CheckEditViewSend
        '
        Me.CheckEditViewSend.Location = New System.Drawing.Point(5, 7)
        Me.CheckEditViewSend.Name = "CheckEditViewSend"
        Me.CheckEditViewSend.Properties.Caption = "View Sent Slip"
        Me.CheckEditViewSend.Size = New System.Drawing.Size(88, 19)
        Me.CheckEditViewSend.TabIndex = 102
        '
        'BtnAttachment
        '
        Me.BtnAttachment.Dock = System.Windows.Forms.DockStyle.Right
        Me.BtnAttachment.ImageIndex = 10
        Me.BtnAttachment.ImageList = Me.LargeImageCollection
        Me.BtnAttachment.Location = New System.Drawing.Point(652, 2)
        Me.BtnAttachment.Name = "BtnAttachment"
        Me.BtnAttachment.Size = New System.Drawing.Size(103, 35)
        Me.BtnAttachment.TabIndex = 113
        Me.BtnAttachment.TabStop = False
        Me.BtnAttachment.Text = "Attachment"
        '
        'BReport
        '
        Me.BReport.Dock = System.Windows.Forms.DockStyle.Right
        Me.BReport.DropDownControl = Me.PopupMenu1
        Me.BReport.ImageIndex = 17
        Me.BReport.ImageList = Me.LargeImageCollection
        Me.BReport.Location = New System.Drawing.Point(755, 2)
        Me.BReport.Name = "BReport"
        Me.BReport.Size = New System.Drawing.Size(111, 35)
        Me.BReport.TabIndex = 108
        Me.BReport.Text = "Report"
        '
        'PopupMenu1
        '
        Me.PopupMenu1.LinksPersistInfo.AddRange(New DevExpress.XtraBars.LinkPersistInfo() {New DevExpress.XtraBars.LinkPersistInfo(Me.BarButtonItem1), New DevExpress.XtraBars.LinkPersistInfo(Me.BBIBPJSTK), New DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.None, False, Me.BBIBPJSKesehatan, False), New DevExpress.XtraBars.LinkPersistInfo(Me.BBIPajak), New DevExpress.XtraBars.LinkPersistInfo(Me.BBBcaFormat), New DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.None, False, Me.BarButtonItem2, False)})
        Me.PopupMenu1.Manager = Me.BarManager1
        Me.PopupMenu1.Name = "PopupMenu1"
        '
        'SBSendSlip
        '
        Me.SBSendSlip.Dock = System.Windows.Forms.DockStyle.Right
        Me.SBSendSlip.ImageIndex = 19
        Me.SBSendSlip.ImageList = Me.LargeImageCollection
        Me.SBSendSlip.Location = New System.Drawing.Point(866, 2)
        Me.SBSendSlip.Name = "SBSendSlip"
        Me.SBSendSlip.Size = New System.Drawing.Size(103, 35)
        Me.SBSendSlip.TabIndex = 112
        Me.SBSendSlip.Text = "Send Slip"
        '
        'BPrintSlip
        '
        Me.BPrintSlip.Dock = System.Windows.Forms.DockStyle.Right
        Me.BPrintSlip.ImageIndex = 6
        Me.BPrintSlip.ImageList = Me.LargeImageCollection
        Me.BPrintSlip.Location = New System.Drawing.Point(969, 2)
        Me.BPrintSlip.Name = "BPrintSlip"
        Me.BPrintSlip.Size = New System.Drawing.Size(97, 35)
        Me.BPrintSlip.TabIndex = 106
        Me.BPrintSlip.Text = "Print Slip"
        '
        'PCSelAll
        '
        Me.PCSelAll.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
        Me.PCSelAll.Controls.Add(Me.CheckEditSelAll)
        Me.PCSelAll.Dock = System.Windows.Forms.DockStyle.Left
        Me.PCSelAll.Location = New System.Drawing.Point(226, 2)
        Me.PCSelAll.Name = "PCSelAll"
        Me.PCSelAll.Size = New System.Drawing.Size(72, 35)
        Me.PCSelAll.TabIndex = 105
        '
        'CheckEditSelAll
        '
        Me.CheckEditSelAll.Location = New System.Drawing.Point(5, 7)
        Me.CheckEditSelAll.Name = "CheckEditSelAll"
        Me.CheckEditSelAll.Properties.Caption = "Select All"
        Me.CheckEditSelAll.Size = New System.Drawing.Size(66, 19)
        Me.CheckEditSelAll.TabIndex = 102
        '
        'BMark
        '
        Me.BMark.Dock = System.Windows.Forms.DockStyle.Left
        Me.BMark.ImageIndex = 4
        Me.BMark.ImageList = Me.LargeImageCollection
        Me.BMark.Location = New System.Drawing.Point(150, 2)
        Me.BMark.Name = "BMark"
        Me.BMark.Size = New System.Drawing.Size(76, 35)
        Me.BMark.TabIndex = 111
        Me.BMark.Text = "Mark"
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
        Me.BPrint.Location = New System.Drawing.Point(1066, 2)
        Me.BPrint.Name = "BPrint"
        Me.BPrint.Size = New System.Drawing.Size(82, 35)
        Me.BPrint.TabIndex = 0
        Me.BPrint.Text = "Print"
        '
        'BReset
        '
        Me.BReset.Dock = System.Windows.Forms.DockStyle.Right
        Me.BReset.ImageIndex = 3
        Me.BReset.ImageList = Me.LargeImageCollection
        Me.BReset.Location = New System.Drawing.Point(1148, 2)
        Me.BReset.Name = "BReset"
        Me.BReset.Size = New System.Drawing.Size(91, 35)
        Me.BReset.TabIndex = 110
        Me.BReset.Text = "Reset"
        '
        'BSubmit
        '
        Me.BSubmit.Dock = System.Windows.Forms.DockStyle.Right
        Me.BSubmit.ImageIndex = 19
        Me.BSubmit.ImageList = Me.LargeImageCollection
        Me.BSubmit.Location = New System.Drawing.Point(1239, 2)
        Me.BSubmit.Name = "BSubmit"
        Me.BSubmit.Size = New System.Drawing.Size(97, 35)
        Me.BSubmit.TabIndex = 109
        Me.BSubmit.Text = "Submit"
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
        Me.PanelControl1.Size = New System.Drawing.Size(1338, 39)
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
        Me.BBonusAdjustment.Location = New System.Drawing.Point(898, 2)
        Me.BBonusAdjustment.Name = "BBonusAdjustment"
        Me.BBonusAdjustment.Size = New System.Drawing.Size(137, 35)
        Me.BBonusAdjustment.TabIndex = 5
        Me.BBonusAdjustment.Text = "Bonus / Adjustment"
        '
        'BDeduction
        '
        Me.BDeduction.Dock = System.Windows.Forms.DockStyle.Right
        Me.BDeduction.ImageIndex = 14
        Me.BDeduction.ImageList = Me.LargeImageCollection
        Me.BDeduction.Location = New System.Drawing.Point(1035, 2)
        Me.BDeduction.Name = "BDeduction"
        Me.BDeduction.Size = New System.Drawing.Size(103, 35)
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
        Me.BOvertime.Location = New System.Drawing.Point(1138, 2)
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
        Me.BSetting.Location = New System.Drawing.Point(1239, 2)
        Me.BSetting.Name = "BSetting"
        Me.BSetting.Size = New System.Drawing.Size(97, 35)
        Me.BSetting.TabIndex = 0
        Me.BSetting.Text = "Setting"
        '
        'GridColumn6
        '
        Me.GridColumn6.FieldName = "is_thr"
        Me.GridColumn6.Name = "GridColumn6"
        '
        'GridColumn7
        '
        Me.GridColumn7.FieldName = "is_dw"
        Me.GridColumn7.Name = "GridColumn7"
        '
        'FormEmpPayroll
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1344, 729)
        Me.Controls.Add(Me.XTCPayroll)
        Me.Controls.Add(Me.barDockControlLeft)
        Me.Controls.Add(Me.barDockControlRight)
        Me.Controls.Add(Me.barDockControlBottom)
        Me.Controls.Add(Me.barDockControlTop)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FormEmpPayroll"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Payroll Worksheet"
        CType(Me.XTCPayroll, System.ComponentModel.ISupportInitialize).EndInit()
        Me.XTCPayroll.ResumeLayout(False)
        Me.XTPPeriode.ResumeLayout(False)
        CType(Me.GCExportExcel, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVExportExcel, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BarManager1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GCPayrollPeriode, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVPayrollPeriode, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemCheckEdit, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PanelControl4, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl4.ResumeLayout(False)
        CType(Me.LargeImageCollection, System.ComponentModel.ISupportInitialize).EndInit()
        Me.XTPSalaryFormat.ResumeLayout(False)
        CType(Me.GCPayroll, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ViewPopWorksheet.ResumeLayout(False)
        CType(Me.GVPayroll, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RICECheck, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RICESent, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RITEActWorkdays, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RITETotalSalaryTHR, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RITEActWorkdaysDW, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RICEPending, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PanelControl2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl2.ResumeLayout(False)
        CType(Me.PanelControl3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl3.ResumeLayout(False)
        CType(Me.CheckEditViewSend.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PopupMenu1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PCSelAll, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PCSelAll.ResumeLayout(False)
        CType(Me.CheckEditSelAll.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PBCLineList.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

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
    Friend WithEvents GridColumnIDEmployee As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents GridColumnNIP As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents GridColumnName As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents GridColumnDepartement As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents GridColumnStatus As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents GridColumnPosition As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents GridColumnWorkingDays As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
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
    Friend WithEvents BBonusAdjustment As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BandedGridColumnActWorkdays As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumnPending As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents RICEPending As DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit
    Friend WithEvents BandedGridColumnGrandTotal As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumnTotalAdjustment As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumnTotalPaymentOt As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumnTotalDeduction As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents PanelControl2 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents BPrint As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BPrintSlip As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents PCSelAll As DevExpress.XtraEditors.PanelControl
    Friend WithEvents CheckEditSelAll As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents PBCLineList As DevExpress.XtraEditors.ProgressBarControl
    Friend WithEvents BUpdateActualWorkingDays As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents PopupMenu1 As DevExpress.XtraBars.PopupMenu
    Friend WithEvents BBSubEstPrice As DevExpress.XtraBars.BarSubItem
    Friend WithEvents BBPrepEstPrice As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents BtnImportEstPrice As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents BBSubOther As DevExpress.XtraBars.BarSubItem
    Friend WithEvents BBMasterSeason As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents BBDs As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents BBPD As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents BBProposePrice As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents BarManager1 As DevExpress.XtraBars.BarManager
    Friend WithEvents barDockControlTop As DevExpress.XtraBars.BarDockControl
    Friend WithEvents barDockControlBottom As DevExpress.XtraBars.BarDockControl
    Friend WithEvents barDockControlLeft As DevExpress.XtraBars.BarDockControl
    Friend WithEvents barDockControlRight As DevExpress.XtraBars.BarDockControl
    Friend WithEvents BReport As DevExpress.XtraEditors.DropDownButton
    Friend WithEvents BarButtonItem1 As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents BarButtonItem2 As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents BarButtonItem3 As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents BandedGridColumnCash As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents GridColumn1 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents BBBcaFormat As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents GridColumnIDPayrollType As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents BSubmit As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BReset As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BMark As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents GCStatus As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnIDPayroll As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumnActWorkdaysDW As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents GridColumnBasicSalaryDW As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents RITEActWorkdaysDW As DevExpress.XtraEditors.Repository.RepositoryItemTextEdit
    Friend WithEvents BandedGridColumnCheck As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumnOvertimeHours As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BBIBPJSTK As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents BBIBPJSKesehatan As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents GCIsOfficePayroll As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents SBSendSlip As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents GridColumnGroupReport As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents GridColumnDepartementSub As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumn1 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BtnAttachment As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents RITEActWorkdays As DevExpress.XtraEditors.Repository.RepositoryItemTextEdit
    Friend WithEvents PanelControl3 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents CheckEditViewSend As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents RICECheck As DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit
    Friend WithEvents BandedGridColumnSent As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents RICESent As DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit
    Friend WithEvents GridColumnTotalSalaryDW As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BBIPajak As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents PanelControl4 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents SBExportExcel As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents GridColumnCheck As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents RepositoryItemCheckEdit As DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit
    Friend WithEvents GCExportExcel As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVExportExcel As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumn2 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn3 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn4 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn5 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents BandedGridColumnActualJoinDateTHR As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumnLengthTHR As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumnTotalSalaryTHR As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents gridBand8 As DevExpress.XtraGrid.Views.BandedGrid.GridBand
    Friend WithEvents GBWorkingDays As DevExpress.XtraGrid.Views.BandedGrid.GridBand
    Friend WithEvents GBDW As DevExpress.XtraGrid.Views.BandedGrid.GridBand
    Friend WithEvents GBTHR As DevExpress.XtraGrid.Views.BandedGrid.GridBand
    Friend WithEvents GBSalary As DevExpress.XtraGrid.Views.BandedGrid.GridBand
    Friend WithEvents BandedGridColumnTotFixedSalary As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents GBBonusAdjustment As DevExpress.XtraGrid.Views.BandedGrid.GridBand
    Friend WithEvents GBOvertime As DevExpress.XtraGrid.Views.BandedGrid.GridBand
    Friend WithEvents GBDeduction As DevExpress.XtraGrid.Views.BandedGrid.GridBand
    Friend WithEvents GBTotal As DevExpress.XtraGrid.Views.BandedGrid.GridBand
    Friend WithEvents GBExtraNote As DevExpress.XtraGrid.Views.BandedGrid.GridBand
    Friend WithEvents RITETotalSalaryTHR As DevExpress.XtraEditors.Repository.RepositoryItemTextEdit
    Friend WithEvents GridColumn6 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn7 As DevExpress.XtraGrid.Columns.GridColumn
End Class
