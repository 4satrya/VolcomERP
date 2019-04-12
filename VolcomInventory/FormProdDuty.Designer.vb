<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FormProdDuty
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
        Me.GCProd = New DevExpress.XtraGrid.GridControl()
        Me.ViewMenu = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.SMEdit = New System.Windows.Forms.ToolStripMenuItem()
        Me.GVProd = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridView()
        Me.GridBand1 = New DevExpress.XtraGrid.Views.BandedGrid.GridBand()
        Me.GridColumnProdNo = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.GridColumnSeason = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.GridColumnDelivery = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.GridColumnVendorCode = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.GridColumnCompName = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumnPOVolpro = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.GridColumnDesign = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumnCode = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumnUSCode = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumnColor = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.GridColumnOrderQty = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumnQtyRec = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumnRoyPib = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumnPIBKurs = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumnFOB = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumnTotFOB = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumnFreightUSD = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumnFreightCostRP = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.GridColumnReportStatus = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.GridColumnIdReportStatus = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.GridColumnProdDate = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.GridColumnPOType = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.GridColumnTerm = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.GridColumnDesignCOP = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.GridColumnIdPO = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.gridBand3 = New DevExpress.XtraGrid.Views.BandedGrid.GridBand()
        Me.BandedGridColumnFabrication = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumnHSCode = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumnQtyPIB = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumnPIBVolume = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumnPIBUOM = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumnPIBCur = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumnCIF = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumnImportFrom = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumnDestPort = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumnLSNo = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumnLSDate = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumnPIBNo = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumnPIBDate = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumnAJU = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumnCOO = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumnPPJK = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumnPPJKInvNo = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumnSDP = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumnSRP = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumnSTP = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumnPIBPRDueDate = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumnPRProposed = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.RICEPRProposed = New DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit()
        Me.BandedGridColumnPIBDueDate = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumnDutyPaid = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.RICEDutyPaid = New DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit()
        Me.BandedGridColumnEst = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumnRevAftDisc = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumnDutyP = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumnSVATP = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumnPPHPercent = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.gridBand4 = New DevExpress.XtraGrid.Views.BandedGrid.GridBand()
        Me.BandedGridColumnEstRoyS = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumnCIFRp = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumnQtySalesEst = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumnEstRoyD = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumnBM1 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumnTotDeclareEst = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumnPPNEst = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumnPPHEst = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.gridBand6 = New DevExpress.XtraGrid.Views.BandedGrid.GridBand()
        Me.BandedGridColumnRevAfterTax = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumnQtySalesActual = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumn3 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumnAmoRoyaltySales = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumnFinalRoyS = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumnFinalRoyD = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumnCIFFinal = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumnBMFinal = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumnTotDeclareF = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumnPPNF = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumnPPHF = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.gridBand7 = New DevExpress.XtraGrid.Views.BandedGrid.GridBand()
        Me.BandedGridColumnDiffPrice = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumnDiffRoyD = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumnOutBM = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumnPPNDiff = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumnPPHDiff = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumnVPDiff = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.gridBand2 = New DevExpress.XtraGrid.Views.BandedGrid.GridBand()
        Me.BandedGridColumnFinal = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumn17 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumnRemRevAftTax = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumnTotRemaining = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumnAmoRoySalesRemaining = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumnRemCIF = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumnRemBM = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumnRemainingTotDeclare = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumnRemPPN = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumnRemPPH = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumn8 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumn1 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumn7 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumn6 = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.gridBand5 = New DevExpress.XtraGrid.Views.BandedGrid.GridBand()
        Me.BandedGridColumn100OutBM = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumn100OutPPN = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumn100OutPPH = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumn100OutTotal = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.BandedGridColumnIDCurPIB = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.GridColumnIdSeason = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.GridColumnIdDelivery = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.RIPictureEdit = New DevExpress.XtraEditors.Repository.RepositoryItemPictureEdit()
        Me.PanelControl1 = New DevExpress.XtraEditors.PanelControl()
        Me.SimpleButton1 = New DevExpress.XtraEditors.SimpleButton()
        Me.BImportExcel = New DevExpress.XtraEditors.SimpleButton()
        Me.BPrint = New DevExpress.XtraEditors.SimpleButton()
        Me.SLEVendor = New DevExpress.XtraEditors.SearchLookUpEdit()
        Me.GridView14 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumn10 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn11 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn12 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.SLESeason = New DevExpress.XtraEditors.SearchLookUpEdit()
        Me.SearchLookUpEdit1View = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumn6 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn8 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.BSearch = New DevExpress.XtraEditors.SimpleButton()
        Me.LabelControl3 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl1 = New DevExpress.XtraEditors.LabelControl()
        Me.SLEDesignStockStore = New DevExpress.XtraEditors.SearchLookUpEdit()
        Me.GVSLEDesgSearch = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumnCodeSearch = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn7 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn9 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.LabelControl9 = New DevExpress.XtraEditors.LabelControl()
        CType(Me.GCProd, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ViewMenu.SuspendLayout()
        CType(Me.GVProd, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RICEPRProposed, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RICEDutyPaid, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RIPictureEdit, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl1.SuspendLayout()
        CType(Me.SLEVendor.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView14, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SLESeason.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SearchLookUpEdit1View, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SLEDesignStockStore.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVSLEDesgSearch, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GCProd
        '
        Me.GCProd.ContextMenuStrip = Me.ViewMenu
        Me.GCProd.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCProd.Location = New System.Drawing.Point(0, 38)
        Me.GCProd.MainView = Me.GVProd
        Me.GCProd.Name = "GCProd"
        Me.GCProd.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.RIPictureEdit, Me.RICEPRProposed, Me.RICEDutyPaid})
        Me.GCProd.Size = New System.Drawing.Size(1241, 477)
        Me.GCProd.TabIndex = 4
        Me.GCProd.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVProd})
        '
        'ViewMenu
        '
        Me.ViewMenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.SMEdit})
        Me.ViewMenu.Name = "ContextMenuStripYM"
        Me.ViewMenu.Size = New System.Drawing.Size(140, 26)
        '
        'SMEdit
        '
        Me.SMEdit.Name = "SMEdit"
        Me.SMEdit.Size = New System.Drawing.Size(139, 22)
        Me.SMEdit.Text = "Edit Variable"
        '
        'GVProd
        '
        Me.GVProd.Bands.AddRange(New DevExpress.XtraGrid.Views.BandedGrid.GridBand() {Me.GridBand1, Me.gridBand3, Me.gridBand4, Me.gridBand6, Me.gridBand7, Me.gridBand2, Me.gridBand5})
        Me.GVProd.Columns.AddRange(New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn() {Me.GridColumnVendorCode, Me.GridColumnCompName, Me.BandedGridColumnCode, Me.GridColumnProdNo, Me.BandedGridColumnPOVolpro, Me.BandedGridColumnUSCode, Me.BandedGridColumnQtyRec, Me.GridColumnReportStatus, Me.GridColumnIdReportStatus, Me.GridColumnProdDate, Me.GridColumnPOType, Me.GridColumnTerm, Me.GridColumnDesignCOP, Me.GridColumnDesign, Me.BandedGridColumnQtyPIB, Me.BandedGridColumnPIBVolume, Me.BandedGridColumnPIBUOM, Me.BandedGridColumnIDCurPIB, Me.BandedGridColumnPIBCur, Me.BandedGridColumnPIBKurs, Me.BandedGridColumnFabrication, Me.BandedGridColumnCIF, Me.BandedGridColumnCIFRp, Me.BandedGridColumnHSCode, Me.BandedGridColumnColor, Me.BandedGridColumnFOB, Me.BandedGridColumnTotFOB, Me.BandedGridColumnImportFrom, Me.BandedGridColumnDestPort, Me.BandedGridColumnLSNo, Me.BandedGridColumnLSDate, Me.BandedGridColumnPIBNo, Me.BandedGridColumnAJU, Me.BandedGridColumnPIBDate, Me.BandedGridColumnCOO, Me.BandedGridColumnFreightUSD, Me.BandedGridColumnPPJK, Me.BandedGridColumnPPJKInvNo, Me.BandedGridColumnPIBDueDate, Me.BandedGridColumnPIBPRDueDate, Me.BandedGridColumnDutyPaid, Me.BandedGridColumnPRProposed, Me.BandedGridColumnDutyP, Me.BandedGridColumnSDP, Me.BandedGridColumnSVATP, Me.BandedGridColumnSRP, Me.BandedGridColumnSTP, Me.BandedGridColumnPPHPercent, Me.GridColumnOrderQty, Me.BandedGridColumnQtySalesEst, Me.BandedGridColumnEst, Me.BandedGridColumnRevAftDisc, Me.BandedGridColumnEstRoyS, Me.BandedGridColumnEstRoyD, Me.BandedGridColumnBM1, Me.BandedGridColumnTotDeclareEst, Me.BandedGridColumnPPNEst, Me.BandedGridColumnPPHEst, Me.BandedGridColumnFinal, Me.BandedGridColumnQtySalesActual, Me.BandedGridColumnRevAfterTax, Me.BandedGridColumnAmoRoyaltySales, Me.BandedGridColumnFinalRoyS, Me.BandedGridColumnCIFFinal, Me.BandedGridColumn3, Me.BandedGridColumnBMFinal, Me.BandedGridColumnFinalRoyD, Me.BandedGridColumnPPNF, Me.BandedGridColumnPPHF, Me.BandedGridColumnTotDeclareF, Me.BandedGridColumnDiffPrice, Me.BandedGridColumnDiffRoyD, Me.BandedGridColumnOutBM, Me.BandedGridColumnPPNDiff, Me.BandedGridColumnPPHDiff, Me.BandedGridColumnVPDiff, Me.BandedGridColumn17, Me.BandedGridColumnRemRevAftTax, Me.BandedGridColumnTotRemaining, Me.BandedGridColumnAmoRoySalesRemaining, Me.BandedGridColumnRemCIF, Me.BandedGridColumnRemBM, Me.BandedGridColumnRemainingTotDeclare, Me.BandedGridColumnRemPPN, Me.BandedGridColumnRemPPH, Me.BandedGridColumn8, Me.BandedGridColumn1, Me.BandedGridColumn7, Me.BandedGridColumn6, Me.GridColumnIdPO, Me.GridColumnIdSeason, Me.GridColumnSeason, Me.GridColumnIdDelivery, Me.GridColumnDelivery, Me.BandedGridColumnRoyPib, Me.BandedGridColumnFreightCostRP, Me.BandedGridColumn100OutBM, Me.BandedGridColumn100OutPPN, Me.BandedGridColumn100OutPPH, Me.BandedGridColumn100OutTotal})
        Me.GVProd.GridControl = Me.GCProd
        Me.GVProd.GroupCount = 2
        Me.GVProd.GroupSummary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "cif", Me.BandedGridColumnCIF, "{0:N4}"), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "cif_kurs", Me.BandedGridColumnCIFRp, "{0:N4}"), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "FOB", Me.BandedGridColumnFOB, "{0:N4}"), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "total_FOB_rp", Me.BandedGridColumnTotFOB, "{0:N4}"), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "freight_usd", Me.BandedGridColumnFreightUSD, "{0:N4}"), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "qty_order", Me.BandedGridColumnQtyPIB, "{0:N4}"), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "qty_order", Me.GridColumnOrderQty, "{0:N4}"), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "est_price_after_disc", Me.BandedGridColumnRevAftDisc, "{0:N2}"), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "qty_st", Me.BandedGridColumnQtySalesEst, "{0:N0}"), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "bm_pib", Me.BandedGridColumnBM1, "{0:N2}"), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "tot_pib", Me.BandedGridColumnTotDeclareEst, "{0:N2}"), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "royalty_ppn_pib", Me.BandedGridColumnPPNEst, "{0:N2}"), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "royalty_pph_pib", Me.BandedGridColumnPPHEst, "{0:N2}"), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "act_sales_qty", Me.BandedGridColumnQtySalesActual, "{0:N0}"), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "tot_freight_cost", Me.BandedGridColumnFreightCostRP, "{0:N4}"), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "royalty_pib", Me.BandedGridColumnRoyPib, "{0:N4}"), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "amount_revenue_taxed_final", Me.BandedGridColumnRevAfterTax, "{0:N2}"), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "royalty_sales_final", Me.BandedGridColumnAmoRoyaltySales, "{0:N2}"), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "cif_final", Me.BandedGridColumnCIFFinal, "{0:N2}"), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "tot_declare_final", Me.BandedGridColumnTotDeclareF, "{0:N2}"), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "bm_final", Me.BandedGridColumnBMFinal, "{0:N2}"), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "royalty_ppn_final", Me.BandedGridColumnPPNF, "{0:N2}"), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "royalty_pph_final", Me.BandedGridColumnPPHF, "{0:N2}"), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "total_outstanding", Me.BandedGridColumnVPDiff, "{0:N2}"), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "outstanding_bm", Me.BandedGridColumnOutBM, "{0:N2}"), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "outstanding_ppn", Me.BandedGridColumnPPNDiff, "{0:N2}"), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "outstanding_pph", Me.BandedGridColumnPPHDiff, "{0:N2}"), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "sales_after_tax_full", Me.BandedGridColumnRemRevAftTax, "{0:N2}"), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "amount_remaining", Me.BandedGridColumnTotRemaining, "{0:N2}"), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "royalty_sales_remaining", Me.BandedGridColumnAmoRoySalesRemaining, "{0:N2}"), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "tot_declare_remaining", Me.BandedGridColumnRemainingTotDeclare, "{0:N2}"), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "cif_remaining", Me.BandedGridColumnRemCIF, "{0:N2}"), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "bm_remaining", Me.BandedGridColumnRemBM, "{0:N2}"), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "ppn_remaining", Me.BandedGridColumnRemPPN, "{0:N2}"), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "pph_remaining", Me.BandedGridColumnRemPPH, "{0:N2}"), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "outstanding_bm_f", Me.BandedGridColumn100OutBM, "{0:N2}"), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "outstanding_ppn_f", Me.BandedGridColumn100OutPPN, "{0:N2}"), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "outstanding_pph_f", Me.BandedGridColumn100OutPPH, "{0:N2}"), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "total_outstanding_f", Me.BandedGridColumn100OutTotal, "{0:N2}")})
        Me.GVProd.Name = "GVProd"
        Me.GVProd.OptionsBehavior.Editable = False
        Me.GVProd.OptionsFind.AlwaysVisible = True
        Me.GVProd.OptionsView.ColumnAutoWidth = False
        Me.GVProd.OptionsView.ShowFooter = True
        Me.GVProd.OptionsView.ShowGroupPanel = False
        Me.GVProd.SortInfo.AddRange(New DevExpress.XtraGrid.Columns.GridColumnSortInfo() {New DevExpress.XtraGrid.Columns.GridColumnSortInfo(Me.GridColumnSeason, DevExpress.Data.ColumnSortOrder.Descending), New DevExpress.XtraGrid.Columns.GridColumnSortInfo(Me.GridColumnDelivery, DevExpress.Data.ColumnSortOrder.Descending), New DevExpress.XtraGrid.Columns.GridColumnSortInfo(Me.GridColumnIdPO, DevExpress.Data.ColumnSortOrder.Descending)})
        '
        'GridBand1
        '
        Me.GridBand1.AppearanceHeader.Options.UseTextOptions = True
        Me.GridBand1.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridBand1.Columns.Add(Me.GridColumnProdNo)
        Me.GridBand1.Columns.Add(Me.GridColumnSeason)
        Me.GridBand1.Columns.Add(Me.GridColumnDelivery)
        Me.GridBand1.Columns.Add(Me.GridColumnVendorCode)
        Me.GridBand1.Columns.Add(Me.GridColumnCompName)
        Me.GridBand1.Columns.Add(Me.BandedGridColumnPOVolpro)
        Me.GridBand1.Columns.Add(Me.GridColumnDesign)
        Me.GridBand1.Columns.Add(Me.BandedGridColumnCode)
        Me.GridBand1.Columns.Add(Me.BandedGridColumnUSCode)
        Me.GridBand1.Columns.Add(Me.BandedGridColumnColor)
        Me.GridBand1.Columns.Add(Me.GridColumnOrderQty)
        Me.GridBand1.Columns.Add(Me.BandedGridColumnQtyRec)
        Me.GridBand1.Columns.Add(Me.BandedGridColumnRoyPib)
        Me.GridBand1.Columns.Add(Me.BandedGridColumnPIBKurs)
        Me.GridBand1.Columns.Add(Me.BandedGridColumnFOB)
        Me.GridBand1.Columns.Add(Me.BandedGridColumnTotFOB)
        Me.GridBand1.Columns.Add(Me.BandedGridColumnFreightUSD)
        Me.GridBand1.Columns.Add(Me.BandedGridColumnFreightCostRP)
        Me.GridBand1.Columns.Add(Me.GridColumnReportStatus)
        Me.GridBand1.Columns.Add(Me.GridColumnIdReportStatus)
        Me.GridBand1.Columns.Add(Me.GridColumnProdDate)
        Me.GridBand1.Columns.Add(Me.GridColumnPOType)
        Me.GridBand1.Columns.Add(Me.GridColumnTerm)
        Me.GridBand1.Columns.Add(Me.GridColumnDesignCOP)
        Me.GridBand1.Columns.Add(Me.GridColumnIdPO)
        Me.GridBand1.Name = "GridBand1"
        Me.GridBand1.VisibleIndex = 0
        Me.GridBand1.Width = 994
        '
        'GridColumnProdNo
        '
        Me.GridColumnProdNo.Caption = "PO #"
        Me.GridColumnProdNo.FieldName = "prod_order_number"
        Me.GridColumnProdNo.Name = "GridColumnProdNo"
        Me.GridColumnProdNo.Width = 74
        '
        'GridColumnSeason
        '
        Me.GridColumnSeason.Caption = "Season"
        Me.GridColumnSeason.FieldName = "season"
        Me.GridColumnSeason.FieldNameSortGroup = "id_season"
        Me.GridColumnSeason.Name = "GridColumnSeason"
        Me.GridColumnSeason.Visible = True
        '
        'GridColumnDelivery
        '
        Me.GridColumnDelivery.Caption = "Delivery"
        Me.GridColumnDelivery.FieldName = "delivery"
        Me.GridColumnDelivery.FieldNameSortGroup = "id_delivery"
        Me.GridColumnDelivery.Name = "GridColumnDelivery"
        Me.GridColumnDelivery.Visible = True
        '
        'GridColumnVendorCode
        '
        Me.GridColumnVendorCode.Caption = "Vendor Code"
        Me.GridColumnVendorCode.FieldName = "comp_number"
        Me.GridColumnVendorCode.Name = "GridColumnVendorCode"
        Me.GridColumnVendorCode.Visible = True
        '
        'GridColumnCompName
        '
        Me.GridColumnCompName.Caption = "Vendor"
        Me.GridColumnCompName.FieldName = "comp_name"
        Me.GridColumnCompName.Name = "GridColumnCompName"
        Me.GridColumnCompName.Visible = True
        Me.GridColumnCompName.Width = 79
        '
        'BandedGridColumnPOVolpro
        '
        Me.BandedGridColumnPOVolpro.Caption = "PO REFF#"
        Me.BandedGridColumnPOVolpro.FieldName = "po_lama_no"
        Me.BandedGridColumnPOVolpro.Name = "BandedGridColumnPOVolpro"
        Me.BandedGridColumnPOVolpro.Visible = True
        '
        'GridColumnDesign
        '
        Me.GridColumnDesign.Caption = "Nama Desain"
        Me.GridColumnDesign.FieldName = "design_display_name"
        Me.GridColumnDesign.Name = "GridColumnDesign"
        Me.GridColumnDesign.Visible = True
        Me.GridColumnDesign.Width = 121
        '
        'BandedGridColumnCode
        '
        Me.BandedGridColumnCode.Caption = "Code"
        Me.BandedGridColumnCode.FieldName = "design_code"
        Me.BandedGridColumnCode.Name = "BandedGridColumnCode"
        '
        'BandedGridColumnUSCode
        '
        Me.BandedGridColumnUSCode.Caption = "US Code"
        Me.BandedGridColumnUSCode.FieldName = "design_code_import"
        Me.BandedGridColumnUSCode.Name = "BandedGridColumnUSCode"
        '
        'BandedGridColumnColor
        '
        Me.BandedGridColumnColor.Caption = "Warna"
        Me.BandedGridColumnColor.FieldName = "color"
        Me.BandedGridColumnColor.Name = "BandedGridColumnColor"
        Me.BandedGridColumnColor.Visible = True
        '
        'GridColumnOrderQty
        '
        Me.GridColumnOrderQty.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumnOrderQty.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumnOrderQty.AppearanceHeader.Options.UseTextOptions = True
        Me.GridColumnOrderQty.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumnOrderQty.Caption = "Total Qty Pada PO"
        Me.GridColumnOrderQty.DisplayFormat.FormatString = "N0"
        Me.GridColumnOrderQty.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumnOrderQty.FieldName = "qty_order"
        Me.GridColumnOrderQty.Name = "GridColumnOrderQty"
        Me.GridColumnOrderQty.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "qty_order", "{0:N0}")})
        Me.GridColumnOrderQty.Visible = True
        Me.GridColumnOrderQty.Width = 119
        '
        'BandedGridColumnQtyRec
        '
        Me.BandedGridColumnQtyRec.AppearanceCell.Options.UseTextOptions = True
        Me.BandedGridColumnQtyRec.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.BandedGridColumnQtyRec.AppearanceHeader.Options.UseTextOptions = True
        Me.BandedGridColumnQtyRec.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.BandedGridColumnQtyRec.Caption = "Qty Rececived"
        Me.BandedGridColumnQtyRec.DisplayFormat.FormatString = "N4"
        Me.BandedGridColumnQtyRec.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.BandedGridColumnQtyRec.FieldName = "qty_rec"
        Me.BandedGridColumnQtyRec.Name = "BandedGridColumnQtyRec"
        Me.BandedGridColumnQtyRec.Width = 87
        '
        'BandedGridColumnRoyPib
        '
        Me.BandedGridColumnRoyPib.AppearanceCell.Options.UseTextOptions = True
        Me.BandedGridColumnRoyPib.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.BandedGridColumnRoyPib.Caption = "Nilai Royalty di declare pada PIB (Rp)"
        Me.BandedGridColumnRoyPib.DisplayFormat.FormatString = "N4"
        Me.BandedGridColumnRoyPib.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.BandedGridColumnRoyPib.FieldName = "royalty_pib"
        Me.BandedGridColumnRoyPib.Name = "BandedGridColumnRoyPib"
        Me.BandedGridColumnRoyPib.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "royalty_pib", "{0:N4}")})
        Me.BandedGridColumnRoyPib.Visible = True
        '
        'BandedGridColumnPIBKurs
        '
        Me.BandedGridColumnPIBKurs.AppearanceCell.Options.UseTextOptions = True
        Me.BandedGridColumnPIBKurs.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.BandedGridColumnPIBKurs.AppearanceHeader.Options.UseTextOptions = True
        Me.BandedGridColumnPIBKurs.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.BandedGridColumnPIBKurs.Caption = "NDPBM (Kurs)"
        Me.BandedGridColumnPIBKurs.DisplayFormat.FormatString = "N4"
        Me.BandedGridColumnPIBKurs.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.BandedGridColumnPIBKurs.FieldName = "pib_kurs"
        Me.BandedGridColumnPIBKurs.Name = "BandedGridColumnPIBKurs"
        Me.BandedGridColumnPIBKurs.Visible = True
        '
        'BandedGridColumnFOB
        '
        Me.BandedGridColumnFOB.AppearanceCell.Options.UseTextOptions = True
        Me.BandedGridColumnFOB.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.BandedGridColumnFOB.AppearanceHeader.Options.UseTextOptions = True
        Me.BandedGridColumnFOB.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.BandedGridColumnFOB.Caption = "FOB Price"
        Me.BandedGridColumnFOB.DisplayFormat.FormatString = "N4"
        Me.BandedGridColumnFOB.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.BandedGridColumnFOB.FieldName = "FOB"
        Me.BandedGridColumnFOB.Name = "BandedGridColumnFOB"
        Me.BandedGridColumnFOB.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "FOB", "{0:N4}")})
        '
        'BandedGridColumnTotFOB
        '
        Me.BandedGridColumnTotFOB.AppearanceCell.Options.UseTextOptions = True
        Me.BandedGridColumnTotFOB.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.BandedGridColumnTotFOB.AppearanceHeader.Options.UseTextOptions = True
        Me.BandedGridColumnTotFOB.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.BandedGridColumnTotFOB.Caption = "FOB in Rp"
        Me.BandedGridColumnTotFOB.DisplayFormat.FormatString = "N4"
        Me.BandedGridColumnTotFOB.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.BandedGridColumnTotFOB.FieldName = "total_FOB_rp"
        Me.BandedGridColumnTotFOB.Name = "BandedGridColumnTotFOB"
        Me.BandedGridColumnTotFOB.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "total_FOB_rp", "{0:N4}")})
        Me.BandedGridColumnTotFOB.Visible = True
        '
        'BandedGridColumnFreightUSD
        '
        Me.BandedGridColumnFreightUSD.AppearanceCell.Options.UseTextOptions = True
        Me.BandedGridColumnFreightUSD.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.BandedGridColumnFreightUSD.AppearanceHeader.Options.UseTextOptions = True
        Me.BandedGridColumnFreightUSD.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.BandedGridColumnFreightUSD.Caption = "Freight (USD)"
        Me.BandedGridColumnFreightUSD.DisplayFormat.FormatString = "N4"
        Me.BandedGridColumnFreightUSD.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.BandedGridColumnFreightUSD.FieldName = "freight_usd"
        Me.BandedGridColumnFreightUSD.Name = "BandedGridColumnFreightUSD"
        Me.BandedGridColumnFreightUSD.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "freight_usd", "{0:N4}")})
        '
        'BandedGridColumnFreightCostRP
        '
        Me.BandedGridColumnFreightCostRP.AppearanceCell.Options.UseTextOptions = True
        Me.BandedGridColumnFreightCostRP.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.BandedGridColumnFreightCostRP.AppearanceHeader.Options.UseTextOptions = True
        Me.BandedGridColumnFreightCostRP.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.BandedGridColumnFreightCostRP.Caption = "Total Freight Cost (Rp)"
        Me.BandedGridColumnFreightCostRP.DisplayFormat.FormatString = "N4"
        Me.BandedGridColumnFreightCostRP.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.BandedGridColumnFreightCostRP.FieldName = "tot_freight_cost"
        Me.BandedGridColumnFreightCostRP.Name = "BandedGridColumnFreightCostRP"
        Me.BandedGridColumnFreightCostRP.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "tot_freight_cost", "{0:N4}")})
        Me.BandedGridColumnFreightCostRP.Visible = True
        '
        'GridColumnReportStatus
        '
        Me.GridColumnReportStatus.Caption = "Status"
        Me.GridColumnReportStatus.FieldName = "report_status"
        Me.GridColumnReportStatus.Name = "GridColumnReportStatus"
        Me.GridColumnReportStatus.Width = 106
        '
        'GridColumnIdReportStatus
        '
        Me.GridColumnIdReportStatus.Caption = "Id Report Status"
        Me.GridColumnIdReportStatus.FieldName = "id_report_status"
        Me.GridColumnIdReportStatus.Name = "GridColumnIdReportStatus"
        '
        'GridColumnProdDate
        '
        Me.GridColumnProdDate.Caption = "Date"
        Me.GridColumnProdDate.DisplayFormat.FormatString = "dd MMM yyyy"
        Me.GridColumnProdDate.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.GridColumnProdDate.FieldName = "prod_order_date"
        Me.GridColumnProdDate.Name = "GridColumnProdDate"
        Me.GridColumnProdDate.Width = 78
        '
        'GridColumnPOType
        '
        Me.GridColumnPOType.Caption = "PO Type"
        Me.GridColumnPOType.FieldName = "po_type"
        Me.GridColumnPOType.Name = "GridColumnPOType"
        Me.GridColumnPOType.Width = 78
        '
        'GridColumnTerm
        '
        Me.GridColumnTerm.Caption = "Term"
        Me.GridColumnTerm.FieldName = "term_production"
        Me.GridColumnTerm.Name = "GridColumnTerm"
        Me.GridColumnTerm.Width = 78
        '
        'GridColumnDesignCOP
        '
        Me.GridColumnDesignCOP.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumnDesignCOP.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumnDesignCOP.AppearanceHeader.Options.UseTextOptions = True
        Me.GridColumnDesignCOP.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumnDesignCOP.Caption = "Cost Final"
        Me.GridColumnDesignCOP.DisplayFormat.FormatString = "N2"
        Me.GridColumnDesignCOP.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumnDesignCOP.FieldName = "design_cop"
        Me.GridColumnDesignCOP.Name = "GridColumnDesignCOP"
        '
        'GridColumnIdPO
        '
        Me.GridColumnIdPO.Caption = "ID PO"
        Me.GridColumnIdPO.FieldName = "id_prod_order"
        Me.GridColumnIdPO.Name = "GridColumnIdPO"
        '
        'gridBand3
        '
        Me.gridBand3.AppearanceHeader.Options.UseTextOptions = True
        Me.gridBand3.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.gridBand3.Caption = "Import Realization"
        Me.gridBand3.Columns.Add(Me.BandedGridColumnFabrication)
        Me.gridBand3.Columns.Add(Me.BandedGridColumnHSCode)
        Me.gridBand3.Columns.Add(Me.BandedGridColumnQtyPIB)
        Me.gridBand3.Columns.Add(Me.BandedGridColumnPIBVolume)
        Me.gridBand3.Columns.Add(Me.BandedGridColumnPIBUOM)
        Me.gridBand3.Columns.Add(Me.BandedGridColumnPIBCur)
        Me.gridBand3.Columns.Add(Me.BandedGridColumnCIF)
        Me.gridBand3.Columns.Add(Me.BandedGridColumnImportFrom)
        Me.gridBand3.Columns.Add(Me.BandedGridColumnDestPort)
        Me.gridBand3.Columns.Add(Me.BandedGridColumnLSNo)
        Me.gridBand3.Columns.Add(Me.BandedGridColumnLSDate)
        Me.gridBand3.Columns.Add(Me.BandedGridColumnPIBNo)
        Me.gridBand3.Columns.Add(Me.BandedGridColumnPIBDate)
        Me.gridBand3.Columns.Add(Me.BandedGridColumnAJU)
        Me.gridBand3.Columns.Add(Me.BandedGridColumnCOO)
        Me.gridBand3.Columns.Add(Me.BandedGridColumnPPJK)
        Me.gridBand3.Columns.Add(Me.BandedGridColumnPPJKInvNo)
        Me.gridBand3.Columns.Add(Me.BandedGridColumnSDP)
        Me.gridBand3.Columns.Add(Me.BandedGridColumnSRP)
        Me.gridBand3.Columns.Add(Me.BandedGridColumnSTP)
        Me.gridBand3.Columns.Add(Me.BandedGridColumnPIBPRDueDate)
        Me.gridBand3.Columns.Add(Me.BandedGridColumnPRProposed)
        Me.gridBand3.Columns.Add(Me.BandedGridColumnPIBDueDate)
        Me.gridBand3.Columns.Add(Me.BandedGridColumnDutyPaid)
        Me.gridBand3.Columns.Add(Me.BandedGridColumnEst)
        Me.gridBand3.Columns.Add(Me.BandedGridColumnRevAftDisc)
        Me.gridBand3.Columns.Add(Me.BandedGridColumnDutyP)
        Me.gridBand3.Columns.Add(Me.BandedGridColumnSVATP)
        Me.gridBand3.Columns.Add(Me.BandedGridColumnPPHPercent)
        Me.gridBand3.Name = "gridBand3"
        Me.gridBand3.VisibleIndex = 1
        Me.gridBand3.Width = 2295
        '
        'BandedGridColumnFabrication
        '
        Me.BandedGridColumnFabrication.Caption = "Fabrication"
        Me.BandedGridColumnFabrication.FieldName = "design_fabrication"
        Me.BandedGridColumnFabrication.Name = "BandedGridColumnFabrication"
        Me.BandedGridColumnFabrication.Width = 103
        '
        'BandedGridColumnHSCode
        '
        Me.BandedGridColumnHSCode.Caption = "HS Code"
        Me.BandedGridColumnHSCode.FieldName = "hs_code"
        Me.BandedGridColumnHSCode.Name = "BandedGridColumnHSCode"
        Me.BandedGridColumnHSCode.Visible = True
        '
        'BandedGridColumnQtyPIB
        '
        Me.BandedGridColumnQtyPIB.AppearanceCell.Options.UseTextOptions = True
        Me.BandedGridColumnQtyPIB.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.BandedGridColumnQtyPIB.AppearanceHeader.Options.UseTextOptions = True
        Me.BandedGridColumnQtyPIB.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.BandedGridColumnQtyPIB.Caption = "Qty PIB"
        Me.BandedGridColumnQtyPIB.DisplayFormat.FormatString = "N4"
        Me.BandedGridColumnQtyPIB.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.BandedGridColumnQtyPIB.FieldName = "qty_order"
        Me.BandedGridColumnQtyPIB.Name = "BandedGridColumnQtyPIB"
        Me.BandedGridColumnQtyPIB.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "qty_order", "{0:N4}")})
        Me.BandedGridColumnQtyPIB.Visible = True
        '
        'BandedGridColumnPIBVolume
        '
        Me.BandedGridColumnPIBVolume.AppearanceCell.Options.UseTextOptions = True
        Me.BandedGridColumnPIBVolume.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.BandedGridColumnPIBVolume.AppearanceHeader.Options.UseTextOptions = True
        Me.BandedGridColumnPIBVolume.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.BandedGridColumnPIBVolume.Caption = "Volume"
        Me.BandedGridColumnPIBVolume.DisplayFormat.FormatString = "N4"
        Me.BandedGridColumnPIBVolume.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.BandedGridColumnPIBVolume.FieldName = "pib_volume"
        Me.BandedGridColumnPIBVolume.Name = "BandedGridColumnPIBVolume"
        Me.BandedGridColumnPIBVolume.Visible = True
        '
        'BandedGridColumnPIBUOM
        '
        Me.BandedGridColumnPIBUOM.Caption = "UOM"
        Me.BandedGridColumnPIBUOM.FieldName = "pib_uom"
        Me.BandedGridColumnPIBUOM.Name = "BandedGridColumnPIBUOM"
        Me.BandedGridColumnPIBUOM.Visible = True
        '
        'BandedGridColumnPIBCur
        '
        Me.BandedGridColumnPIBCur.Caption = "Currency"
        Me.BandedGridColumnPIBCur.FieldName = "currency"
        Me.BandedGridColumnPIBCur.Name = "BandedGridColumnPIBCur"
        Me.BandedGridColumnPIBCur.Visible = True
        '
        'BandedGridColumnCIF
        '
        Me.BandedGridColumnCIF.AppearanceCell.Options.UseTextOptions = True
        Me.BandedGridColumnCIF.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.BandedGridColumnCIF.AppearanceHeader.Options.UseTextOptions = True
        Me.BandedGridColumnCIF.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.BandedGridColumnCIF.Caption = "CIF"
        Me.BandedGridColumnCIF.DisplayFormat.FormatString = "N4"
        Me.BandedGridColumnCIF.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.BandedGridColumnCIF.FieldName = "cif"
        Me.BandedGridColumnCIF.Name = "BandedGridColumnCIF"
        Me.BandedGridColumnCIF.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "cif", "{0:N4}")})
        Me.BandedGridColumnCIF.Visible = True
        '
        'BandedGridColumnImportFrom
        '
        Me.BandedGridColumnImportFrom.Caption = "Import From"
        Me.BandedGridColumnImportFrom.FieldName = "country_source"
        Me.BandedGridColumnImportFrom.Name = "BandedGridColumnImportFrom"
        Me.BandedGridColumnImportFrom.Visible = True
        '
        'BandedGridColumnDestPort
        '
        Me.BandedGridColumnDestPort.Caption = "Destination Port"
        Me.BandedGridColumnDestPort.FieldName = "dest_port"
        Me.BandedGridColumnDestPort.Name = "BandedGridColumnDestPort"
        Me.BandedGridColumnDestPort.Visible = True
        '
        'BandedGridColumnLSNo
        '
        Me.BandedGridColumnLSNo.Caption = "L/S No#"
        Me.BandedGridColumnLSNo.FieldName = "ls_no"
        Me.BandedGridColumnLSNo.Name = "BandedGridColumnLSNo"
        Me.BandedGridColumnLSNo.Visible = True
        '
        'BandedGridColumnLSDate
        '
        Me.BandedGridColumnLSDate.Caption = "L/S Date"
        Me.BandedGridColumnLSDate.DisplayFormat.FormatString = "dd MMM yyyy"
        Me.BandedGridColumnLSDate.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.BandedGridColumnLSDate.FieldName = "ls_date"
        Me.BandedGridColumnLSDate.Name = "BandedGridColumnLSDate"
        Me.BandedGridColumnLSDate.Visible = True
        '
        'BandedGridColumnPIBNo
        '
        Me.BandedGridColumnPIBNo.Caption = "PIB#"
        Me.BandedGridColumnPIBNo.FieldName = "pib_no"
        Me.BandedGridColumnPIBNo.Name = "BandedGridColumnPIBNo"
        Me.BandedGridColumnPIBNo.Visible = True
        Me.BandedGridColumnPIBNo.Width = 85
        '
        'BandedGridColumnPIBDate
        '
        Me.BandedGridColumnPIBDate.Caption = "PIB Date"
        Me.BandedGridColumnPIBDate.DisplayFormat.FormatString = "dd MMMM yyyy"
        Me.BandedGridColumnPIBDate.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.BandedGridColumnPIBDate.FieldName = "pib_date"
        Me.BandedGridColumnPIBDate.Name = "BandedGridColumnPIBDate"
        Me.BandedGridColumnPIBDate.Visible = True
        Me.BandedGridColumnPIBDate.Width = 85
        '
        'BandedGridColumnAJU
        '
        Me.BandedGridColumnAJU.Caption = "AJU#"
        Me.BandedGridColumnAJU.FieldName = "aju_no"
        Me.BandedGridColumnAJU.Name = "BandedGridColumnAJU"
        Me.BandedGridColumnAJU.Visible = True
        '
        'BandedGridColumnCOO
        '
        Me.BandedGridColumnCOO.Caption = "COO#"
        Me.BandedGridColumnCOO.FieldName = "coo_no"
        Me.BandedGridColumnCOO.Name = "BandedGridColumnCOO"
        Me.BandedGridColumnCOO.Visible = True
        '
        'BandedGridColumnPPJK
        '
        Me.BandedGridColumnPPJK.Caption = "PPJK"
        Me.BandedGridColumnPPJK.FieldName = "ppjk"
        Me.BandedGridColumnPPJK.Name = "BandedGridColumnPPJK"
        Me.BandedGridColumnPPJK.Visible = True
        '
        'BandedGridColumnPPJKInvNo
        '
        Me.BandedGridColumnPPJKInvNo.Caption = "PPJK Inv No"
        Me.BandedGridColumnPPJKInvNo.FieldName = "ppjk_inv_no"
        Me.BandedGridColumnPPJKInvNo.Name = "BandedGridColumnPPJKInvNo"
        Me.BandedGridColumnPPJKInvNo.Visible = True
        '
        'BandedGridColumnSDP
        '
        Me.BandedGridColumnSDP.AppearanceCell.Options.UseTextOptions = True
        Me.BandedGridColumnSDP.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.BandedGridColumnSDP.AppearanceHeader.Options.UseTextOptions = True
        Me.BandedGridColumnSDP.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.BandedGridColumnSDP.Caption = "Store Discount (%)"
        Me.BandedGridColumnSDP.DisplayFormat.FormatString = "N4"
        Me.BandedGridColumnSDP.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.BandedGridColumnSDP.FieldName = "store_disc"
        Me.BandedGridColumnSDP.Name = "BandedGridColumnSDP"
        Me.BandedGridColumnSDP.Visible = True
        Me.BandedGridColumnSDP.Width = 99
        '
        'BandedGridColumnSRP
        '
        Me.BandedGridColumnSRP.AppearanceCell.Options.UseTextOptions = True
        Me.BandedGridColumnSRP.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.BandedGridColumnSRP.AppearanceHeader.Options.UseTextOptions = True
        Me.BandedGridColumnSRP.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.BandedGridColumnSRP.Caption = "Sales Royalty (%)"
        Me.BandedGridColumnSRP.DisplayFormat.FormatString = "N4"
        Me.BandedGridColumnSRP.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.BandedGridColumnSRP.FieldName = "royalty_percent"
        Me.BandedGridColumnSRP.Name = "BandedGridColumnSRP"
        Me.BandedGridColumnSRP.Visible = True
        Me.BandedGridColumnSRP.Width = 112
        '
        'BandedGridColumnSTP
        '
        Me.BandedGridColumnSTP.AppearanceCell.Options.UseTextOptions = True
        Me.BandedGridColumnSTP.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.BandedGridColumnSTP.AppearanceHeader.Options.UseTextOptions = True
        Me.BandedGridColumnSTP.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.BandedGridColumnSTP.Caption = "Sales Through (%)"
        Me.BandedGridColumnSTP.DisplayFormat.FormatString = "N4"
        Me.BandedGridColumnSTP.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.BandedGridColumnSTP.FieldName = "sales_thru"
        Me.BandedGridColumnSTP.Name = "BandedGridColumnSTP"
        Me.BandedGridColumnSTP.Visible = True
        Me.BandedGridColumnSTP.Width = 98
        '
        'BandedGridColumnPIBPRDueDate
        '
        Me.BandedGridColumnPIBPRDueDate.Caption = "VP PR Due Date"
        Me.BandedGridColumnPIBPRDueDate.DisplayFormat.FormatString = "dd MMMM yyyy"
        Me.BandedGridColumnPIBPRDueDate.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.BandedGridColumnPIBPRDueDate.FieldName = "vp_pr_due_date"
        Me.BandedGridColumnPIBPRDueDate.Name = "BandedGridColumnPIBPRDueDate"
        Me.BandedGridColumnPIBPRDueDate.Visible = True
        Me.BandedGridColumnPIBPRDueDate.Width = 102
        '
        'BandedGridColumnPRProposed
        '
        Me.BandedGridColumnPRProposed.Caption = "PR Proposed"
        Me.BandedGridColumnPRProposed.ColumnEdit = Me.RICEPRProposed
        Me.BandedGridColumnPRProposed.FieldName = "duty_is_pr_proposed"
        Me.BandedGridColumnPRProposed.Name = "BandedGridColumnPRProposed"
        Me.BandedGridColumnPRProposed.Visible = True
        Me.BandedGridColumnPRProposed.Width = 85
        '
        'RICEPRProposed
        '
        Me.RICEPRProposed.AutoHeight = False
        Me.RICEPRProposed.Name = "RICEPRProposed"
        Me.RICEPRProposed.ValueChecked = "yes"
        Me.RICEPRProposed.ValueUnchecked = "no"
        '
        'BandedGridColumnPIBDueDate
        '
        Me.BandedGridColumnPIBDueDate.Caption = "VP Due Date"
        Me.BandedGridColumnPIBDueDate.DisplayFormat.FormatString = "dd MMMM yyyy"
        Me.BandedGridColumnPIBDueDate.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.BandedGridColumnPIBDueDate.FieldName = "vp_due_date"
        Me.BandedGridColumnPIBDueDate.Name = "BandedGridColumnPIBDueDate"
        Me.BandedGridColumnPIBDueDate.Visible = True
        Me.BandedGridColumnPIBDueDate.Width = 85
        '
        'BandedGridColumnDutyPaid
        '
        Me.BandedGridColumnDutyPaid.Caption = "Payment Completed"
        Me.BandedGridColumnDutyPaid.ColumnEdit = Me.RICEDutyPaid
        Me.BandedGridColumnDutyPaid.FieldName = "duty_is_pay"
        Me.BandedGridColumnDutyPaid.Name = "BandedGridColumnDutyPaid"
        Me.BandedGridColumnDutyPaid.Visible = True
        Me.BandedGridColumnDutyPaid.Width = 104
        '
        'RICEDutyPaid
        '
        Me.RICEDutyPaid.AutoHeight = False
        Me.RICEDutyPaid.Name = "RICEDutyPaid"
        Me.RICEDutyPaid.ValueChecked = "yes"
        Me.RICEDutyPaid.ValueUnchecked = "no"
        '
        'BandedGridColumnEst
        '
        Me.BandedGridColumnEst.AppearanceCell.Options.UseTextOptions = True
        Me.BandedGridColumnEst.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.BandedGridColumnEst.AppearanceHeader.Options.UseTextOptions = True
        Me.BandedGridColumnEst.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.BandedGridColumnEst.Caption = "Est Price"
        Me.BandedGridColumnEst.DisplayFormat.FormatString = "N2"
        Me.BandedGridColumnEst.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.BandedGridColumnEst.FieldName = "est_price"
        Me.BandedGridColumnEst.Name = "BandedGridColumnEst"
        Me.BandedGridColumnEst.Visible = True
        Me.BandedGridColumnEst.Width = 78
        '
        'BandedGridColumnRevAftDisc
        '
        Me.BandedGridColumnRevAftDisc.AppearanceCell.Options.UseTextOptions = True
        Me.BandedGridColumnRevAftDisc.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.BandedGridColumnRevAftDisc.AppearanceHeader.Options.UseTextOptions = True
        Me.BandedGridColumnRevAftDisc.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.BandedGridColumnRevAftDisc.Caption = "Revenue After Discount"
        Me.BandedGridColumnRevAftDisc.DisplayFormat.FormatString = "N2"
        Me.BandedGridColumnRevAftDisc.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.BandedGridColumnRevAftDisc.FieldName = "est_price_after_disc"
        Me.BandedGridColumnRevAftDisc.Name = "BandedGridColumnRevAftDisc"
        Me.BandedGridColumnRevAftDisc.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "est_price_after_disc", "{0:N2}")})
        Me.BandedGridColumnRevAftDisc.Visible = True
        '
        'BandedGridColumnDutyP
        '
        Me.BandedGridColumnDutyP.AppearanceCell.Options.UseTextOptions = True
        Me.BandedGridColumnDutyP.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.BandedGridColumnDutyP.AppearanceHeader.Options.UseTextOptions = True
        Me.BandedGridColumnDutyP.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.BandedGridColumnDutyP.Caption = "Duty (%)"
        Me.BandedGridColumnDutyP.DisplayFormat.FormatString = "N4"
        Me.BandedGridColumnDutyP.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.BandedGridColumnDutyP.FieldName = "duty_percent"
        Me.BandedGridColumnDutyP.Name = "BandedGridColumnDutyP"
        Me.BandedGridColumnDutyP.Visible = True
        Me.BandedGridColumnDutyP.Width = 81
        '
        'BandedGridColumnSVATP
        '
        Me.BandedGridColumnSVATP.AppearanceCell.Options.UseTextOptions = True
        Me.BandedGridColumnSVATP.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.BandedGridColumnSVATP.AppearanceHeader.Options.UseTextOptions = True
        Me.BandedGridColumnSVATP.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.BandedGridColumnSVATP.Caption = "PPN (%)"
        Me.BandedGridColumnSVATP.DisplayFormat.FormatString = "N4"
        Me.BandedGridColumnSVATP.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.BandedGridColumnSVATP.FieldName = "ppn"
        Me.BandedGridColumnSVATP.Name = "BandedGridColumnSVATP"
        Me.BandedGridColumnSVATP.Visible = True
        Me.BandedGridColumnSVATP.Width = 81
        '
        'BandedGridColumnPPHPercent
        '
        Me.BandedGridColumnPPHPercent.AppearanceCell.Options.UseTextOptions = True
        Me.BandedGridColumnPPHPercent.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.BandedGridColumnPPHPercent.AppearanceHeader.Options.UseTextOptions = True
        Me.BandedGridColumnPPHPercent.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.BandedGridColumnPPHPercent.Caption = "PPH (%)"
        Me.BandedGridColumnPPHPercent.DisplayFormat.FormatString = "N4"
        Me.BandedGridColumnPPHPercent.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.BandedGridColumnPPHPercent.FieldName = "pph"
        Me.BandedGridColumnPPHPercent.Name = "BandedGridColumnPPHPercent"
        Me.BandedGridColumnPPHPercent.Visible = True
        '
        'gridBand4
        '
        Me.gridBand4.AppearanceHeader.Options.UseTextOptions = True
        Me.gridBand4.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.gridBand4.Caption = "Pembayaran PIB"
        Me.gridBand4.Columns.Add(Me.BandedGridColumnEstRoyS)
        Me.gridBand4.Columns.Add(Me.BandedGridColumnCIFRp)
        Me.gridBand4.Columns.Add(Me.BandedGridColumnQtySalesEst)
        Me.gridBand4.Columns.Add(Me.BandedGridColumnEstRoyD)
        Me.gridBand4.Columns.Add(Me.BandedGridColumnBM1)
        Me.gridBand4.Columns.Add(Me.BandedGridColumnTotDeclareEst)
        Me.gridBand4.Columns.Add(Me.BandedGridColumnPPNEst)
        Me.gridBand4.Columns.Add(Me.BandedGridColumnPPHEst)
        Me.gridBand4.Name = "gridBand4"
        Me.gridBand4.VisibleIndex = 2
        Me.gridBand4.Width = 375
        '
        'BandedGridColumnEstRoyS
        '
        Me.BandedGridColumnEstRoyS.AppearanceCell.Options.UseTextOptions = True
        Me.BandedGridColumnEstRoyS.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.BandedGridColumnEstRoyS.AppearanceHeader.Options.UseTextOptions = True
        Me.BandedGridColumnEstRoyS.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.BandedGridColumnEstRoyS.Caption = "Royalty"
        Me.BandedGridColumnEstRoyS.DisplayFormat.FormatString = "N2"
        Me.BandedGridColumnEstRoyS.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.BandedGridColumnEstRoyS.FieldName = "royalty_sales_est"
        Me.BandedGridColumnEstRoyS.Name = "BandedGridColumnEstRoyS"
        '
        'BandedGridColumnCIFRp
        '
        Me.BandedGridColumnCIFRp.AppearanceHeader.Options.UseTextOptions = True
        Me.BandedGridColumnCIFRp.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.BandedGridColumnCIFRp.Caption = "CIF (Rp)"
        Me.BandedGridColumnCIFRp.DisplayFormat.FormatString = "N4"
        Me.BandedGridColumnCIFRp.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.BandedGridColumnCIFRp.FieldName = "cif_kurs"
        Me.BandedGridColumnCIFRp.Name = "BandedGridColumnCIFRp"
        Me.BandedGridColumnCIFRp.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "cif_kurs", "{0:N4}")})
        Me.BandedGridColumnCIFRp.Visible = True
        '
        'BandedGridColumnQtySalesEst
        '
        Me.BandedGridColumnQtySalesEst.AppearanceCell.Options.UseTextOptions = True
        Me.BandedGridColumnQtySalesEst.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.BandedGridColumnQtySalesEst.AppearanceHeader.Options.UseTextOptions = True
        Me.BandedGridColumnQtySalesEst.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.BandedGridColumnQtySalesEst.Caption = "Qty Sales Est"
        Me.BandedGridColumnQtySalesEst.DisplayFormat.FormatString = "N0"
        Me.BandedGridColumnQtySalesEst.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.BandedGridColumnQtySalesEst.FieldName = "qty_st"
        Me.BandedGridColumnQtySalesEst.Name = "BandedGridColumnQtySalesEst"
        Me.BandedGridColumnQtySalesEst.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "qty_st", "{0:N0}")})
        '
        'BandedGridColumnEstRoyD
        '
        Me.BandedGridColumnEstRoyD.AppearanceCell.Options.UseTextOptions = True
        Me.BandedGridColumnEstRoyD.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.BandedGridColumnEstRoyD.AppearanceHeader.Options.UseTextOptions = True
        Me.BandedGridColumnEstRoyD.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.BandedGridColumnEstRoyD.Caption = "Royalty Duty"
        Me.BandedGridColumnEstRoyD.DisplayFormat.FormatString = "N2"
        Me.BandedGridColumnEstRoyD.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.BandedGridColumnEstRoyD.FieldName = "royalty_duty_est"
        Me.BandedGridColumnEstRoyD.Name = "BandedGridColumnEstRoyD"
        Me.BandedGridColumnEstRoyD.Width = 79
        '
        'BandedGridColumnBM1
        '
        Me.BandedGridColumnBM1.AppearanceCell.Options.UseTextOptions = True
        Me.BandedGridColumnBM1.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.BandedGridColumnBM1.AppearanceHeader.Options.UseTextOptions = True
        Me.BandedGridColumnBM1.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.BandedGridColumnBM1.Caption = "BM"
        Me.BandedGridColumnBM1.DisplayFormat.FormatString = "N2"
        Me.BandedGridColumnBM1.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.BandedGridColumnBM1.FieldName = "bm_pib"
        Me.BandedGridColumnBM1.Name = "BandedGridColumnBM1"
        Me.BandedGridColumnBM1.Visible = True
        '
        'BandedGridColumnTotDeclareEst
        '
        Me.BandedGridColumnTotDeclareEst.AppearanceCell.Options.UseTextOptions = True
        Me.BandedGridColumnTotDeclareEst.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.BandedGridColumnTotDeclareEst.AppearanceHeader.Options.UseTextOptions = True
        Me.BandedGridColumnTotDeclareEst.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.BandedGridColumnTotDeclareEst.Caption = "Total"
        Me.BandedGridColumnTotDeclareEst.DisplayFormat.FormatString = "N2"
        Me.BandedGridColumnTotDeclareEst.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.BandedGridColumnTotDeclareEst.FieldName = "tot_pib"
        Me.BandedGridColumnTotDeclareEst.Name = "BandedGridColumnTotDeclareEst"
        Me.BandedGridColumnTotDeclareEst.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "tot_pib", "{0:N2}")})
        Me.BandedGridColumnTotDeclareEst.Visible = True
        '
        'BandedGridColumnPPNEst
        '
        Me.BandedGridColumnPPNEst.AppearanceCell.Options.UseTextOptions = True
        Me.BandedGridColumnPPNEst.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.BandedGridColumnPPNEst.AppearanceHeader.Options.UseTextOptions = True
        Me.BandedGridColumnPPNEst.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.BandedGridColumnPPNEst.Caption = "PPN"
        Me.BandedGridColumnPPNEst.DisplayFormat.FormatString = "N2"
        Me.BandedGridColumnPPNEst.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.BandedGridColumnPPNEst.FieldName = "royalty_ppn_pib"
        Me.BandedGridColumnPPNEst.Name = "BandedGridColumnPPNEst"
        Me.BandedGridColumnPPNEst.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "royalty_ppn_pib", "{0:N2}")})
        Me.BandedGridColumnPPNEst.Visible = True
        '
        'BandedGridColumnPPHEst
        '
        Me.BandedGridColumnPPHEst.AppearanceCell.Options.UseTextOptions = True
        Me.BandedGridColumnPPHEst.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.BandedGridColumnPPHEst.AppearanceHeader.Options.UseTextOptions = True
        Me.BandedGridColumnPPHEst.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.BandedGridColumnPPHEst.Caption = "PPH"
        Me.BandedGridColumnPPHEst.DisplayFormat.FormatString = "N2"
        Me.BandedGridColumnPPHEst.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.BandedGridColumnPPHEst.FieldName = "royalty_pph_pib"
        Me.BandedGridColumnPPHEst.Name = "BandedGridColumnPPHEst"
        Me.BandedGridColumnPPHEst.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "royalty_pph_pib", "{0:N2}")})
        Me.BandedGridColumnPPHEst.Visible = True
        '
        'gridBand6
        '
        Me.gridBand6.AppearanceHeader.Options.UseTextOptions = True
        Me.gridBand6.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.gridBand6.Caption = "Actual Penjualan Per Cut Off Date"
        Me.gridBand6.Columns.Add(Me.BandedGridColumnRevAfterTax)
        Me.gridBand6.Columns.Add(Me.BandedGridColumnQtySalesActual)
        Me.gridBand6.Columns.Add(Me.BandedGridColumn3)
        Me.gridBand6.Columns.Add(Me.BandedGridColumnAmoRoyaltySales)
        Me.gridBand6.Columns.Add(Me.BandedGridColumnFinalRoyS)
        Me.gridBand6.Columns.Add(Me.BandedGridColumnFinalRoyD)
        Me.gridBand6.Columns.Add(Me.BandedGridColumnCIFFinal)
        Me.gridBand6.Columns.Add(Me.BandedGridColumnBMFinal)
        Me.gridBand6.Columns.Add(Me.BandedGridColumnTotDeclareF)
        Me.gridBand6.Columns.Add(Me.BandedGridColumnPPNF)
        Me.gridBand6.Columns.Add(Me.BandedGridColumnPPHF)
        Me.gridBand6.Name = "gridBand6"
        Me.gridBand6.VisibleIndex = 3
        Me.gridBand6.Width = 812
        '
        'BandedGridColumnRevAfterTax
        '
        Me.BandedGridColumnRevAfterTax.AppearanceCell.Options.UseTextOptions = True
        Me.BandedGridColumnRevAfterTax.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.BandedGridColumnRevAfterTax.AppearanceHeader.Options.UseTextOptions = True
        Me.BandedGridColumnRevAfterTax.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.BandedGridColumnRevAfterTax.Caption = "Revenue After Tax"
        Me.BandedGridColumnRevAfterTax.DisplayFormat.FormatString = "N2"
        Me.BandedGridColumnRevAfterTax.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.BandedGridColumnRevAfterTax.FieldName = "amount_revenue_taxed_final"
        Me.BandedGridColumnRevAfterTax.Name = "BandedGridColumnRevAfterTax"
        Me.BandedGridColumnRevAfterTax.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "amount_revenue_taxed_final", "{0:N2}")})
        Me.BandedGridColumnRevAfterTax.Visible = True
        '
        'BandedGridColumnQtySalesActual
        '
        Me.BandedGridColumnQtySalesActual.AppearanceCell.Options.UseTextOptions = True
        Me.BandedGridColumnQtySalesActual.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.BandedGridColumnQtySalesActual.AppearanceHeader.Options.UseTextOptions = True
        Me.BandedGridColumnQtySalesActual.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.BandedGridColumnQtySalesActual.Caption = "Qty Sales Actual"
        Me.BandedGridColumnQtySalesActual.DisplayFormat.FormatString = "N0"
        Me.BandedGridColumnQtySalesActual.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.BandedGridColumnQtySalesActual.FieldName = "act_sales_qty"
        Me.BandedGridColumnQtySalesActual.Name = "BandedGridColumnQtySalesActual"
        Me.BandedGridColumnQtySalesActual.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "act_sales_qty", "{0:N0}")})
        Me.BandedGridColumnQtySalesActual.Visible = True
        '
        'BandedGridColumn3
        '
        Me.BandedGridColumn3.AppearanceCell.Options.UseTextOptions = True
        Me.BandedGridColumn3.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.BandedGridColumn3.AppearanceHeader.Options.UseTextOptions = True
        Me.BandedGridColumn3.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.BandedGridColumn3.Caption = "%"
        Me.BandedGridColumn3.DisplayFormat.FormatString = "{0:N0}%"
        Me.BandedGridColumn3.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.BandedGridColumn3.FieldName = "sal_tru_act"
        Me.BandedGridColumn3.Name = "BandedGridColumn3"
        Me.BandedGridColumn3.Visible = True
        '
        'BandedGridColumnAmoRoyaltySales
        '
        Me.BandedGridColumnAmoRoyaltySales.AppearanceCell.Options.UseTextOptions = True
        Me.BandedGridColumnAmoRoyaltySales.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.BandedGridColumnAmoRoyaltySales.AppearanceHeader.Options.UseTextOptions = True
        Me.BandedGridColumnAmoRoyaltySales.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.BandedGridColumnAmoRoyaltySales.Caption = "Amount Royalty Sales "
        Me.BandedGridColumnAmoRoyaltySales.DisplayFormat.FormatString = "N2"
        Me.BandedGridColumnAmoRoyaltySales.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.BandedGridColumnAmoRoyaltySales.FieldName = "royalty_sales_final"
        Me.BandedGridColumnAmoRoyaltySales.Name = "BandedGridColumnAmoRoyaltySales"
        Me.BandedGridColumnAmoRoyaltySales.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "royalty_sales_final", "{0:N2}")})
        Me.BandedGridColumnAmoRoyaltySales.Visible = True
        Me.BandedGridColumnAmoRoyaltySales.Width = 192
        '
        'BandedGridColumnFinalRoyS
        '
        Me.BandedGridColumnFinalRoyS.AppearanceCell.Options.UseTextOptions = True
        Me.BandedGridColumnFinalRoyS.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.BandedGridColumnFinalRoyS.AppearanceHeader.Options.UseTextOptions = True
        Me.BandedGridColumnFinalRoyS.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.BandedGridColumnFinalRoyS.Caption = "Royalty Sales"
        Me.BandedGridColumnFinalRoyS.DisplayFormat.FormatString = "N2"
        Me.BandedGridColumnFinalRoyS.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.BandedGridColumnFinalRoyS.FieldName = "royalty_sales_final"
        Me.BandedGridColumnFinalRoyS.Name = "BandedGridColumnFinalRoyS"
        '
        'BandedGridColumnFinalRoyD
        '
        Me.BandedGridColumnFinalRoyD.AppearanceCell.Options.UseTextOptions = True
        Me.BandedGridColumnFinalRoyD.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.BandedGridColumnFinalRoyD.AppearanceHeader.Options.UseTextOptions = True
        Me.BandedGridColumnFinalRoyD.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.BandedGridColumnFinalRoyD.Caption = "Royalty Duty"
        Me.BandedGridColumnFinalRoyD.DisplayFormat.FormatString = "N2"
        Me.BandedGridColumnFinalRoyD.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.BandedGridColumnFinalRoyD.FieldName = "royalty_duty_final"
        Me.BandedGridColumnFinalRoyD.Name = "BandedGridColumnFinalRoyD"
        '
        'BandedGridColumnCIFFinal
        '
        Me.BandedGridColumnCIFFinal.AppearanceCell.Options.UseTextOptions = True
        Me.BandedGridColumnCIFFinal.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.BandedGridColumnCIFFinal.AppearanceHeader.Options.UseTextOptions = True
        Me.BandedGridColumnCIFFinal.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.BandedGridColumnCIFFinal.Caption = "CIF"
        Me.BandedGridColumnCIFFinal.DisplayFormat.FormatString = "N2"
        Me.BandedGridColumnCIFFinal.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.BandedGridColumnCIFFinal.FieldName = "cif_final"
        Me.BandedGridColumnCIFFinal.Name = "BandedGridColumnCIFFinal"
        Me.BandedGridColumnCIFFinal.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "cif_final", "{0:N2}")})
        Me.BandedGridColumnCIFFinal.Visible = True
        '
        'BandedGridColumnBMFinal
        '
        Me.BandedGridColumnBMFinal.AppearanceCell.Options.UseTextOptions = True
        Me.BandedGridColumnBMFinal.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.BandedGridColumnBMFinal.AppearanceHeader.Options.UseTextOptions = True
        Me.BandedGridColumnBMFinal.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.BandedGridColumnBMFinal.Caption = "BM"
        Me.BandedGridColumnBMFinal.DisplayFormat.FormatString = "N2"
        Me.BandedGridColumnBMFinal.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.BandedGridColumnBMFinal.FieldName = "bm_final"
        Me.BandedGridColumnBMFinal.Name = "BandedGridColumnBMFinal"
        Me.BandedGridColumnBMFinal.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "bm_final", "{0:N2}")})
        Me.BandedGridColumnBMFinal.Visible = True
        '
        'BandedGridColumnTotDeclareF
        '
        Me.BandedGridColumnTotDeclareF.AppearanceCell.Options.UseTextOptions = True
        Me.BandedGridColumnTotDeclareF.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.BandedGridColumnTotDeclareF.AppearanceHeader.Options.UseTextOptions = True
        Me.BandedGridColumnTotDeclareF.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.BandedGridColumnTotDeclareF.Caption = "Total"
        Me.BandedGridColumnTotDeclareF.DisplayFormat.FormatString = "N2"
        Me.BandedGridColumnTotDeclareF.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.BandedGridColumnTotDeclareF.FieldName = "tot_declare_final"
        Me.BandedGridColumnTotDeclareF.Name = "BandedGridColumnTotDeclareF"
        Me.BandedGridColumnTotDeclareF.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "tot_declare_final", "{0:N2}")})
        Me.BandedGridColumnTotDeclareF.Visible = True
        Me.BandedGridColumnTotDeclareF.Width = 95
        '
        'BandedGridColumnPPNF
        '
        Me.BandedGridColumnPPNF.AppearanceCell.Options.UseTextOptions = True
        Me.BandedGridColumnPPNF.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.BandedGridColumnPPNF.AppearanceHeader.Options.UseTextOptions = True
        Me.BandedGridColumnPPNF.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.BandedGridColumnPPNF.Caption = "PPN"
        Me.BandedGridColumnPPNF.DisplayFormat.FormatString = "N2"
        Me.BandedGridColumnPPNF.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.BandedGridColumnPPNF.FieldName = "royalty_ppn_final"
        Me.BandedGridColumnPPNF.Name = "BandedGridColumnPPNF"
        Me.BandedGridColumnPPNF.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "royalty_ppn_final", "{0:N2}")})
        Me.BandedGridColumnPPNF.Visible = True
        '
        'BandedGridColumnPPHF
        '
        Me.BandedGridColumnPPHF.AppearanceCell.Options.UseTextOptions = True
        Me.BandedGridColumnPPHF.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.BandedGridColumnPPHF.AppearanceHeader.Options.UseTextOptions = True
        Me.BandedGridColumnPPHF.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.BandedGridColumnPPHF.Caption = "PPH"
        Me.BandedGridColumnPPHF.DisplayFormat.FormatString = "N2"
        Me.BandedGridColumnPPHF.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.BandedGridColumnPPHF.FieldName = "royalty_pph_final"
        Me.BandedGridColumnPPHF.Name = "BandedGridColumnPPHF"
        Me.BandedGridColumnPPHF.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "royalty_pph_final", "{0:N2}")})
        Me.BandedGridColumnPPHF.Visible = True
        '
        'gridBand7
        '
        Me.gridBand7.Caption = "Selisih"
        Me.gridBand7.Columns.Add(Me.BandedGridColumnDiffPrice)
        Me.gridBand7.Columns.Add(Me.BandedGridColumnDiffRoyD)
        Me.gridBand7.Columns.Add(Me.BandedGridColumnOutBM)
        Me.gridBand7.Columns.Add(Me.BandedGridColumnPPNDiff)
        Me.gridBand7.Columns.Add(Me.BandedGridColumnPPHDiff)
        Me.gridBand7.Columns.Add(Me.BandedGridColumnVPDiff)
        Me.gridBand7.Name = "gridBand7"
        Me.gridBand7.VisibleIndex = 4
        Me.gridBand7.Width = 399
        '
        'BandedGridColumnDiffPrice
        '
        Me.BandedGridColumnDiffPrice.AppearanceCell.Options.UseTextOptions = True
        Me.BandedGridColumnDiffPrice.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.BandedGridColumnDiffPrice.AppearanceHeader.Options.UseTextOptions = True
        Me.BandedGridColumnDiffPrice.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.BandedGridColumnDiffPrice.Caption = "Price Diff"
        Me.BandedGridColumnDiffPrice.DisplayFormat.FormatString = "N2"
        Me.BandedGridColumnDiffPrice.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.BandedGridColumnDiffPrice.FieldName = "price_diff"
        Me.BandedGridColumnDiffPrice.Name = "BandedGridColumnDiffPrice"
        '
        'BandedGridColumnDiffRoyD
        '
        Me.BandedGridColumnDiffRoyD.AppearanceCell.Options.UseTextOptions = True
        Me.BandedGridColumnDiffRoyD.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.BandedGridColumnDiffRoyD.AppearanceHeader.Options.UseTextOptions = True
        Me.BandedGridColumnDiffRoyD.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.BandedGridColumnDiffRoyD.Caption = "Outstanding Royalty Duty"
        Me.BandedGridColumnDiffRoyD.DisplayFormat.FormatString = "N2"
        Me.BandedGridColumnDiffRoyD.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.BandedGridColumnDiffRoyD.FieldName = "outstanding_duty"
        Me.BandedGridColumnDiffRoyD.Name = "BandedGridColumnDiffRoyD"
        Me.BandedGridColumnDiffRoyD.Width = 137
        '
        'BandedGridColumnOutBM
        '
        Me.BandedGridColumnOutBM.AppearanceCell.Options.UseTextOptions = True
        Me.BandedGridColumnOutBM.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.BandedGridColumnOutBM.AppearanceHeader.Options.UseTextOptions = True
        Me.BandedGridColumnOutBM.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.BandedGridColumnOutBM.Caption = "Outstanding Bea Masuk"
        Me.BandedGridColumnOutBM.DisplayFormat.FormatString = "N2"
        Me.BandedGridColumnOutBM.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.BandedGridColumnOutBM.FieldName = "outstanding_bm"
        Me.BandedGridColumnOutBM.Name = "BandedGridColumnOutBM"
        Me.BandedGridColumnOutBM.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "outstanding_bm", "{0:N2}")})
        Me.BandedGridColumnOutBM.Visible = True
        Me.BandedGridColumnOutBM.Width = 120
        '
        'BandedGridColumnPPNDiff
        '
        Me.BandedGridColumnPPNDiff.AppearanceCell.Options.UseTextOptions = True
        Me.BandedGridColumnPPNDiff.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.BandedGridColumnPPNDiff.AppearanceHeader.Options.UseTextOptions = True
        Me.BandedGridColumnPPNDiff.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.BandedGridColumnPPNDiff.Caption = "Outstanding PPN"
        Me.BandedGridColumnPPNDiff.DisplayFormat.FormatString = "N2"
        Me.BandedGridColumnPPNDiff.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.BandedGridColumnPPNDiff.FieldName = "outstanding_ppn"
        Me.BandedGridColumnPPNDiff.Name = "BandedGridColumnPPNDiff"
        Me.BandedGridColumnPPNDiff.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "outstanding_ppn", "{0:N2}")})
        Me.BandedGridColumnPPNDiff.Visible = True
        Me.BandedGridColumnPPNDiff.Width = 93
        '
        'BandedGridColumnPPHDiff
        '
        Me.BandedGridColumnPPHDiff.AppearanceCell.Options.UseTextOptions = True
        Me.BandedGridColumnPPHDiff.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.BandedGridColumnPPHDiff.AppearanceHeader.Options.UseTextOptions = True
        Me.BandedGridColumnPPHDiff.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.BandedGridColumnPPHDiff.Caption = "Outstanding PPH"
        Me.BandedGridColumnPPHDiff.DisplayFormat.FormatString = "N2"
        Me.BandedGridColumnPPHDiff.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.BandedGridColumnPPHDiff.FieldName = "outstanding_pph"
        Me.BandedGridColumnPPHDiff.Name = "BandedGridColumnPPHDiff"
        Me.BandedGridColumnPPHDiff.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "outstanding_pph", "{0:N2}")})
        Me.BandedGridColumnPPHDiff.Visible = True
        Me.BandedGridColumnPPHDiff.Width = 111
        '
        'BandedGridColumnVPDiff
        '
        Me.BandedGridColumnVPDiff.AppearanceCell.Options.UseTextOptions = True
        Me.BandedGridColumnVPDiff.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.BandedGridColumnVPDiff.AppearanceHeader.Options.UseTextOptions = True
        Me.BandedGridColumnVPDiff.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.BandedGridColumnVPDiff.Caption = "Total Outstanding VP"
        Me.BandedGridColumnVPDiff.DisplayFormat.FormatString = "N2"
        Me.BandedGridColumnVPDiff.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.BandedGridColumnVPDiff.FieldName = "total_outstanding"
        Me.BandedGridColumnVPDiff.Name = "BandedGridColumnVPDiff"
        Me.BandedGridColumnVPDiff.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "total_outstanding", "{0:N2}")})
        Me.BandedGridColumnVPDiff.Visible = True
        '
        'gridBand2
        '
        Me.gridBand2.Caption = "Estimasi Sisa Kurang Bayar (Penjualan 100%)"
        Me.gridBand2.Columns.Add(Me.BandedGridColumnFinal)
        Me.gridBand2.Columns.Add(Me.BandedGridColumn17)
        Me.gridBand2.Columns.Add(Me.BandedGridColumnRemRevAftTax)
        Me.gridBand2.Columns.Add(Me.BandedGridColumnTotRemaining)
        Me.gridBand2.Columns.Add(Me.BandedGridColumnAmoRoySalesRemaining)
        Me.gridBand2.Columns.Add(Me.BandedGridColumnRemCIF)
        Me.gridBand2.Columns.Add(Me.BandedGridColumnRemBM)
        Me.gridBand2.Columns.Add(Me.BandedGridColumnRemainingTotDeclare)
        Me.gridBand2.Columns.Add(Me.BandedGridColumnRemPPN)
        Me.gridBand2.Columns.Add(Me.BandedGridColumnRemPPH)
        Me.gridBand2.Columns.Add(Me.BandedGridColumn8)
        Me.gridBand2.Columns.Add(Me.BandedGridColumn1)
        Me.gridBand2.Columns.Add(Me.BandedGridColumn7)
        Me.gridBand2.Columns.Add(Me.BandedGridColumn6)
        Me.gridBand2.Name = "gridBand2"
        Me.gridBand2.VisibleIndex = 5
        Me.gridBand2.Width = 749
        '
        'BandedGridColumnFinal
        '
        Me.BandedGridColumnFinal.AppearanceCell.Options.UseTextOptions = True
        Me.BandedGridColumnFinal.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.BandedGridColumnFinal.AppearanceHeader.Options.UseTextOptions = True
        Me.BandedGridColumnFinal.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.BandedGridColumnFinal.Caption = "Final Price (printed)"
        Me.BandedGridColumnFinal.DisplayFormat.FormatString = "N2"
        Me.BandedGridColumnFinal.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.BandedGridColumnFinal.FieldName = "final_price"
        Me.BandedGridColumnFinal.Name = "BandedGridColumnFinal"
        Me.BandedGridColumnFinal.Visible = True
        Me.BandedGridColumnFinal.Width = 121
        '
        'BandedGridColumn17
        '
        Me.BandedGridColumn17.AppearanceCell.Options.UseTextOptions = True
        Me.BandedGridColumn17.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.BandedGridColumn17.AppearanceHeader.Options.UseTextOptions = True
        Me.BandedGridColumn17.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.BandedGridColumn17.Caption = "Remaining Qty"
        Me.BandedGridColumn17.DisplayFormat.FormatString = "N2"
        Me.BandedGridColumn17.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.BandedGridColumn17.FieldName = "qty_remaining"
        Me.BandedGridColumn17.Name = "BandedGridColumn17"
        '
        'BandedGridColumnRemRevAftTax
        '
        Me.BandedGridColumnRemRevAftTax.AppearanceCell.Options.UseTextOptions = True
        Me.BandedGridColumnRemRevAftTax.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.BandedGridColumnRemRevAftTax.AppearanceHeader.Options.UseTextOptions = True
        Me.BandedGridColumnRemRevAftTax.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.BandedGridColumnRemRevAftTax.Caption = "Remaining Revenue after tax"
        Me.BandedGridColumnRemRevAftTax.DisplayFormat.FormatString = "N2"
        Me.BandedGridColumnRemRevAftTax.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.BandedGridColumnRemRevAftTax.FieldName = "sales_after_tax_full"
        Me.BandedGridColumnRemRevAftTax.Name = "BandedGridColumnRemRevAftTax"
        Me.BandedGridColumnRemRevAftTax.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "sales_after_tax_full", "{0:N2}")})
        Me.BandedGridColumnRemRevAftTax.Visible = True
        Me.BandedGridColumnRemRevAftTax.Width = 103
        '
        'BandedGridColumnTotRemaining
        '
        Me.BandedGridColumnTotRemaining.AppearanceCell.Options.UseTextOptions = True
        Me.BandedGridColumnTotRemaining.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.BandedGridColumnTotRemaining.AppearanceHeader.Options.UseTextOptions = True
        Me.BandedGridColumnTotRemaining.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.BandedGridColumnTotRemaining.Caption = "Total Remaining"
        Me.BandedGridColumnTotRemaining.DisplayFormat.FormatString = "N2"
        Me.BandedGridColumnTotRemaining.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.BandedGridColumnTotRemaining.FieldName = "amount_remaining"
        Me.BandedGridColumnTotRemaining.Name = "BandedGridColumnTotRemaining"
        Me.BandedGridColumnTotRemaining.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "amount_remaining", "{0:N2}")})
        Me.BandedGridColumnTotRemaining.Visible = True
        '
        'BandedGridColumnAmoRoySalesRemaining
        '
        Me.BandedGridColumnAmoRoySalesRemaining.AppearanceCell.Options.UseTextOptions = True
        Me.BandedGridColumnAmoRoySalesRemaining.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.BandedGridColumnAmoRoySalesRemaining.AppearanceHeader.Options.UseTextOptions = True
        Me.BandedGridColumnAmoRoySalesRemaining.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.BandedGridColumnAmoRoySalesRemaining.Caption = "Amount Royalty Sales Remaining"
        Me.BandedGridColumnAmoRoySalesRemaining.DisplayFormat.FormatString = "N2"
        Me.BandedGridColumnAmoRoySalesRemaining.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.BandedGridColumnAmoRoySalesRemaining.FieldName = "royalty_sales_remaining"
        Me.BandedGridColumnAmoRoySalesRemaining.Name = "BandedGridColumnAmoRoySalesRemaining"
        Me.BandedGridColumnAmoRoySalesRemaining.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "royalty_sales_remaining", "{0:N2}")})
        Me.BandedGridColumnAmoRoySalesRemaining.Visible = True
        '
        'BandedGridColumnRemCIF
        '
        Me.BandedGridColumnRemCIF.AppearanceCell.Options.UseTextOptions = True
        Me.BandedGridColumnRemCIF.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.BandedGridColumnRemCIF.AppearanceHeader.Options.UseTextOptions = True
        Me.BandedGridColumnRemCIF.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.BandedGridColumnRemCIF.Caption = "CIF"
        Me.BandedGridColumnRemCIF.DisplayFormat.FormatString = "N2"
        Me.BandedGridColumnRemCIF.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.BandedGridColumnRemCIF.FieldName = "cif_remaining"
        Me.BandedGridColumnRemCIF.Name = "BandedGridColumnRemCIF"
        Me.BandedGridColumnRemCIF.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "cif_remaining", "{0:N2}")})
        Me.BandedGridColumnRemCIF.Visible = True
        '
        'BandedGridColumnRemBM
        '
        Me.BandedGridColumnRemBM.AppearanceCell.Options.UseTextOptions = True
        Me.BandedGridColumnRemBM.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.BandedGridColumnRemBM.AppearanceHeader.Options.UseTextOptions = True
        Me.BandedGridColumnRemBM.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.BandedGridColumnRemBM.Caption = "BM"
        Me.BandedGridColumnRemBM.DisplayFormat.FormatString = "N2"
        Me.BandedGridColumnRemBM.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.BandedGridColumnRemBM.FieldName = "bm_remaining"
        Me.BandedGridColumnRemBM.Name = "BandedGridColumnRemBM"
        Me.BandedGridColumnRemBM.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "bm_remaining", "{0:N2}")})
        Me.BandedGridColumnRemBM.Visible = True
        '
        'BandedGridColumnRemainingTotDeclare
        '
        Me.BandedGridColumnRemainingTotDeclare.AppearanceCell.Options.UseTextOptions = True
        Me.BandedGridColumnRemainingTotDeclare.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.BandedGridColumnRemainingTotDeclare.AppearanceHeader.Options.UseTextOptions = True
        Me.BandedGridColumnRemainingTotDeclare.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.BandedGridColumnRemainingTotDeclare.Caption = "Total"
        Me.BandedGridColumnRemainingTotDeclare.DisplayFormat.FormatString = "N2"
        Me.BandedGridColumnRemainingTotDeclare.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.BandedGridColumnRemainingTotDeclare.FieldName = "tot_declare_remaining"
        Me.BandedGridColumnRemainingTotDeclare.Name = "BandedGridColumnRemainingTotDeclare"
        Me.BandedGridColumnRemainingTotDeclare.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "tot_declare_remaining", "{0:N2}")})
        Me.BandedGridColumnRemainingTotDeclare.Visible = True
        '
        'BandedGridColumnRemPPN
        '
        Me.BandedGridColumnRemPPN.AppearanceCell.Options.UseTextOptions = True
        Me.BandedGridColumnRemPPN.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.BandedGridColumnRemPPN.AppearanceHeader.Options.UseTextOptions = True
        Me.BandedGridColumnRemPPN.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.BandedGridColumnRemPPN.Caption = "PPN"
        Me.BandedGridColumnRemPPN.DisplayFormat.FormatString = "N2"
        Me.BandedGridColumnRemPPN.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.BandedGridColumnRemPPN.FieldName = "ppn_remaining"
        Me.BandedGridColumnRemPPN.Name = "BandedGridColumnRemPPN"
        Me.BandedGridColumnRemPPN.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "ppn_remaining", "{0:N2}")})
        Me.BandedGridColumnRemPPN.Visible = True
        '
        'BandedGridColumnRemPPH
        '
        Me.BandedGridColumnRemPPH.AppearanceCell.Options.UseTextOptions = True
        Me.BandedGridColumnRemPPH.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.BandedGridColumnRemPPH.AppearanceHeader.Options.UseTextOptions = True
        Me.BandedGridColumnRemPPH.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.BandedGridColumnRemPPH.Caption = "PPH"
        Me.BandedGridColumnRemPPH.DisplayFormat.FormatString = "N2"
        Me.BandedGridColumnRemPPH.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.BandedGridColumnRemPPH.FieldName = "pph_remaining"
        Me.BandedGridColumnRemPPH.Name = "BandedGridColumnRemPPH"
        Me.BandedGridColumnRemPPH.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "pph_remaining", "{0:N2}")})
        Me.BandedGridColumnRemPPH.Visible = True
        '
        'BandedGridColumn8
        '
        Me.BandedGridColumn8.AppearanceCell.Options.UseTextOptions = True
        Me.BandedGridColumn8.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.BandedGridColumn8.AppearanceHeader.Options.UseTextOptions = True
        Me.BandedGridColumn8.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.BandedGridColumn8.Caption = "Remaining (%)"
        Me.BandedGridColumn8.DisplayFormat.FormatString = "N4"
        Me.BandedGridColumn8.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.BandedGridColumn8.FieldName = "error_percentage"
        Me.BandedGridColumn8.Name = "BandedGridColumn8"
        '
        'BandedGridColumn1
        '
        Me.BandedGridColumn1.AppearanceCell.Options.UseTextOptions = True
        Me.BandedGridColumn1.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.BandedGridColumn1.AppearanceHeader.Options.UseTextOptions = True
        Me.BandedGridColumn1.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.BandedGridColumn1.Caption = "Penalty (%)"
        Me.BandedGridColumn1.DisplayFormat.FormatString = "N4"
        Me.BandedGridColumn1.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.BandedGridColumn1.FieldName = "penalty_percent"
        Me.BandedGridColumn1.Name = "BandedGridColumn1"
        '
        'BandedGridColumn7
        '
        Me.BandedGridColumn7.AppearanceCell.Options.UseTextOptions = True
        Me.BandedGridColumn7.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.BandedGridColumn7.AppearanceHeader.Options.UseTextOptions = True
        Me.BandedGridColumn7.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.BandedGridColumn7.Caption = "Penalty Amount"
        Me.BandedGridColumn7.DisplayFormat.FormatString = "N2"
        Me.BandedGridColumn7.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.BandedGridColumn7.FieldName = "penalty_amount"
        Me.BandedGridColumn7.Name = "BandedGridColumn7"
        '
        'BandedGridColumn6
        '
        Me.BandedGridColumn6.AppearanceCell.Options.UseTextOptions = True
        Me.BandedGridColumn6.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.BandedGridColumn6.AppearanceHeader.Options.UseTextOptions = True
        Me.BandedGridColumn6.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.BandedGridColumn6.Caption = "Total Amount Pay"
        Me.BandedGridColumn6.DisplayFormat.FormatString = "N2"
        Me.BandedGridColumn6.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.BandedGridColumn6.FieldName = "tot_must_pay"
        Me.BandedGridColumn6.Name = "BandedGridColumn6"
        '
        'gridBand5
        '
        Me.gridBand5.Caption = "Outstanding After 100%"
        Me.gridBand5.Columns.Add(Me.BandedGridColumn100OutBM)
        Me.gridBand5.Columns.Add(Me.BandedGridColumn100OutPPN)
        Me.gridBand5.Columns.Add(Me.BandedGridColumn100OutPPH)
        Me.gridBand5.Columns.Add(Me.BandedGridColumn100OutTotal)
        Me.gridBand5.Name = "gridBand5"
        Me.gridBand5.VisibleIndex = 6
        Me.gridBand5.Width = 300
        '
        'BandedGridColumn100OutBM
        '
        Me.BandedGridColumn100OutBM.AppearanceCell.Options.UseTextOptions = True
        Me.BandedGridColumn100OutBM.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.BandedGridColumn100OutBM.AppearanceHeader.Options.UseTextOptions = True
        Me.BandedGridColumn100OutBM.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.BandedGridColumn100OutBM.Caption = "Outstanding Bea Masuk"
        Me.BandedGridColumn100OutBM.DisplayFormat.FormatString = "N2"
        Me.BandedGridColumn100OutBM.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.BandedGridColumn100OutBM.FieldName = "outstanding_bm_f"
        Me.BandedGridColumn100OutBM.Name = "BandedGridColumn100OutBM"
        Me.BandedGridColumn100OutBM.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "outstanding_bm_f", "{0:N2}")})
        Me.BandedGridColumn100OutBM.Visible = True
        '
        'BandedGridColumn100OutPPN
        '
        Me.BandedGridColumn100OutPPN.AppearanceCell.Options.UseTextOptions = True
        Me.BandedGridColumn100OutPPN.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.BandedGridColumn100OutPPN.AppearanceHeader.Options.UseTextOptions = True
        Me.BandedGridColumn100OutPPN.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.BandedGridColumn100OutPPN.Caption = "Outstanding PPN"
        Me.BandedGridColumn100OutPPN.DisplayFormat.FormatString = "N2"
        Me.BandedGridColumn100OutPPN.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.BandedGridColumn100OutPPN.FieldName = "outstanding_ppn_f"
        Me.BandedGridColumn100OutPPN.Name = "BandedGridColumn100OutPPN"
        Me.BandedGridColumn100OutPPN.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "outstanding_ppn_f", "{0:N2}")})
        Me.BandedGridColumn100OutPPN.Visible = True
        '
        'BandedGridColumn100OutPPH
        '
        Me.BandedGridColumn100OutPPH.AppearanceCell.Options.UseTextOptions = True
        Me.BandedGridColumn100OutPPH.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.BandedGridColumn100OutPPH.AppearanceHeader.Options.UseTextOptions = True
        Me.BandedGridColumn100OutPPH.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.BandedGridColumn100OutPPH.Caption = "Outstanding PPH"
        Me.BandedGridColumn100OutPPH.DisplayFormat.FormatString = "N2"
        Me.BandedGridColumn100OutPPH.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.BandedGridColumn100OutPPH.FieldName = "outstanding_pph_f"
        Me.BandedGridColumn100OutPPH.Name = "BandedGridColumn100OutPPH"
        Me.BandedGridColumn100OutPPH.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "outstanding_pph_f", "{0:N2}")})
        Me.BandedGridColumn100OutPPH.Visible = True
        '
        'BandedGridColumn100OutTotal
        '
        Me.BandedGridColumn100OutTotal.AppearanceCell.Options.UseTextOptions = True
        Me.BandedGridColumn100OutTotal.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.BandedGridColumn100OutTotal.AppearanceHeader.Options.UseTextOptions = True
        Me.BandedGridColumn100OutTotal.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.BandedGridColumn100OutTotal.Caption = "Total Outstanding"
        Me.BandedGridColumn100OutTotal.DisplayFormat.FormatString = "N2"
        Me.BandedGridColumn100OutTotal.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.BandedGridColumn100OutTotal.FieldName = "total_outstanding_f"
        Me.BandedGridColumn100OutTotal.Name = "BandedGridColumn100OutTotal"
        Me.BandedGridColumn100OutTotal.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "total_outstanding_f", "{0:N2}")})
        Me.BandedGridColumn100OutTotal.Visible = True
        '
        'BandedGridColumnIDCurPIB
        '
        Me.BandedGridColumnIDCurPIB.Caption = "PIB Id Currency"
        Me.BandedGridColumnIDCurPIB.FieldName = "pib_id_currency"
        Me.BandedGridColumnIDCurPIB.Name = "BandedGridColumnIDCurPIB"
        '
        'GridColumnIdSeason
        '
        Me.GridColumnIdSeason.Caption = "Season"
        Me.GridColumnIdSeason.FieldName = "id_season"
        Me.GridColumnIdSeason.Name = "GridColumnIdSeason"
        '
        'GridColumnIdDelivery
        '
        Me.GridColumnIdDelivery.Caption = "Delivery"
        Me.GridColumnIdDelivery.FieldName = "id_delivery"
        Me.GridColumnIdDelivery.Name = "GridColumnIdDelivery"
        '
        'RIPictureEdit
        '
        Me.RIPictureEdit.Name = "RIPictureEdit"
        Me.RIPictureEdit.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Stretch
        '
        'PanelControl1
        '
        Me.PanelControl1.Controls.Add(Me.SimpleButton1)
        Me.PanelControl1.Controls.Add(Me.BImportExcel)
        Me.PanelControl1.Controls.Add(Me.BPrint)
        Me.PanelControl1.Controls.Add(Me.SLEVendor)
        Me.PanelControl1.Controls.Add(Me.SLESeason)
        Me.PanelControl1.Controls.Add(Me.BSearch)
        Me.PanelControl1.Controls.Add(Me.LabelControl3)
        Me.PanelControl1.Controls.Add(Me.LabelControl1)
        Me.PanelControl1.Controls.Add(Me.SLEDesignStockStore)
        Me.PanelControl1.Controls.Add(Me.LabelControl9)
        Me.PanelControl1.Dock = System.Windows.Forms.DockStyle.Top
        Me.PanelControl1.Location = New System.Drawing.Point(0, 0)
        Me.PanelControl1.Name = "PanelControl1"
        Me.PanelControl1.Size = New System.Drawing.Size(1241, 38)
        Me.PanelControl1.TabIndex = 5
        '
        'SimpleButton1
        '
        Me.SimpleButton1.Location = New System.Drawing.Point(939, 6)
        Me.SimpleButton1.Name = "SimpleButton1"
        Me.SimpleButton1.Size = New System.Drawing.Size(126, 23)
        Me.SimpleButton1.TabIndex = 8908
        Me.SimpleButton1.Text = "Import Excel Sales"
        '
        'BImportExcel
        '
        Me.BImportExcel.Location = New System.Drawing.Point(845, 6)
        Me.BImportExcel.Name = "BImportExcel"
        Me.BImportExcel.Size = New System.Drawing.Size(88, 23)
        Me.BImportExcel.TabIndex = 8907
        Me.BImportExcel.Text = "Import Excel"
        '
        'BPrint
        '
        Me.BPrint.Location = New System.Drawing.Point(780, 6)
        Me.BPrint.Name = "BPrint"
        Me.BPrint.Size = New System.Drawing.Size(59, 23)
        Me.BPrint.TabIndex = 8906
        Me.BPrint.Text = "Print"
        '
        'SLEVendor
        '
        Me.SLEVendor.Location = New System.Drawing.Point(512, 8)
        Me.SLEVendor.Name = "SLEVendor"
        Me.SLEVendor.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SLEVendor.Properties.Appearance.Options.UseFont = True
        Me.SLEVendor.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.SLEVendor.Properties.View = Me.GridView14
        Me.SLEVendor.Size = New System.Drawing.Size(197, 20)
        Me.SLEVendor.TabIndex = 8905
        '
        'GridView14
        '
        Me.GridView14.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumn10, Me.GridColumn11, Me.GridColumn12})
        Me.GridView14.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
        Me.GridView14.Name = "GridView14"
        Me.GridView14.OptionsSelection.EnableAppearanceFocusedCell = False
        Me.GridView14.OptionsView.ShowGroupPanel = False
        '
        'GridColumn10
        '
        Me.GridColumn10.Caption = "Id Comp"
        Me.GridColumn10.FieldName = "id_comp"
        Me.GridColumn10.Name = "GridColumn10"
        '
        'GridColumn11
        '
        Me.GridColumn11.Caption = "Comp Number"
        Me.GridColumn11.FieldName = "comp_number"
        Me.GridColumn11.Name = "GridColumn11"
        Me.GridColumn11.Visible = True
        Me.GridColumn11.VisibleIndex = 0
        Me.GridColumn11.Width = 188
        '
        'GridColumn12
        '
        Me.GridColumn12.Caption = "Comp Name"
        Me.GridColumn12.FieldName = "comp_name"
        Me.GridColumn12.Name = "GridColumn12"
        Me.GridColumn12.Visible = True
        Me.GridColumn12.VisibleIndex = 1
        Me.GridColumn12.Width = 504
        '
        'SLESeason
        '
        Me.SLESeason.Location = New System.Drawing.Point(303, 8)
        Me.SLESeason.Name = "SLESeason"
        Me.SLESeason.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SLESeason.Properties.Appearance.Options.UseFont = True
        Me.SLESeason.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.SLESeason.Properties.View = Me.SearchLookUpEdit1View
        Me.SLESeason.Size = New System.Drawing.Size(163, 20)
        Me.SLESeason.TabIndex = 8904
        '
        'SearchLookUpEdit1View
        '
        Me.SearchLookUpEdit1View.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumn6, Me.GridColumn8})
        Me.SearchLookUpEdit1View.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
        Me.SearchLookUpEdit1View.Name = "SearchLookUpEdit1View"
        Me.SearchLookUpEdit1View.OptionsSelection.EnableAppearanceFocusedCell = False
        Me.SearchLookUpEdit1View.OptionsView.ShowGroupPanel = False
        '
        'GridColumn6
        '
        Me.GridColumn6.Caption = "Id Season"
        Me.GridColumn6.FieldName = "id_season"
        Me.GridColumn6.Name = "GridColumn6"
        '
        'GridColumn8
        '
        Me.GridColumn8.Caption = "Season"
        Me.GridColumn8.FieldName = "season"
        Me.GridColumn8.Name = "GridColumn8"
        Me.GridColumn8.Visible = True
        Me.GridColumn8.VisibleIndex = 0
        '
        'BSearch
        '
        Me.BSearch.Location = New System.Drawing.Point(715, 6)
        Me.BSearch.Name = "BSearch"
        Me.BSearch.Size = New System.Drawing.Size(59, 23)
        Me.BSearch.TabIndex = 8903
        Me.BSearch.Text = "Search"
        '
        'LabelControl3
        '
        Me.LabelControl3.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl3.Location = New System.Drawing.Point(472, 11)
        Me.LabelControl3.Name = "LabelControl3"
        Me.LabelControl3.Size = New System.Drawing.Size(34, 13)
        Me.LabelControl3.TabIndex = 8901
        Me.LabelControl3.Text = "Vendor"
        '
        'LabelControl1
        '
        Me.LabelControl1.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl1.Location = New System.Drawing.Point(262, 11)
        Me.LabelControl1.Name = "LabelControl1"
        Me.LabelControl1.Size = New System.Drawing.Size(35, 13)
        Me.LabelControl1.TabIndex = 8897
        Me.LabelControl1.Text = "Season"
        '
        'SLEDesignStockStore
        '
        Me.SLEDesignStockStore.Location = New System.Drawing.Point(49, 8)
        Me.SLEDesignStockStore.Name = "SLEDesignStockStore"
        Me.SLEDesignStockStore.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.SLEDesignStockStore.Properties.View = Me.GVSLEDesgSearch
        Me.SLEDesignStockStore.Size = New System.Drawing.Size(195, 20)
        Me.SLEDesignStockStore.TabIndex = 8896
        '
        'GVSLEDesgSearch
        '
        Me.GVSLEDesgSearch.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumnCodeSearch, Me.GridColumn7, Me.GridColumn9})
        Me.GVSLEDesgSearch.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
        Me.GVSLEDesgSearch.Name = "GVSLEDesgSearch"
        Me.GVSLEDesgSearch.OptionsSelection.EnableAppearanceFocusedCell = False
        Me.GVSLEDesgSearch.OptionsView.ShowGroupPanel = False
        '
        'GridColumnCodeSearch
        '
        Me.GridColumnCodeSearch.Caption = "Code"
        Me.GridColumnCodeSearch.FieldName = "design_code"
        Me.GridColumnCodeSearch.Name = "GridColumnCodeSearch"
        Me.GridColumnCodeSearch.Visible = True
        Me.GridColumnCodeSearch.VisibleIndex = 0
        Me.GridColumnCodeSearch.Width = 186
        '
        'GridColumn7
        '
        Me.GridColumn7.Caption = "Description"
        Me.GridColumn7.FieldName = "display_name"
        Me.GridColumn7.Name = "GridColumn7"
        Me.GridColumn7.Visible = True
        Me.GridColumn7.VisibleIndex = 1
        Me.GridColumn7.Width = 360
        '
        'GridColumn9
        '
        Me.GridColumn9.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumn9.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridColumn9.AppearanceHeader.Options.UseTextOptions = True
        Me.GridColumn9.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridColumn9.Caption = "Color"
        Me.GridColumn9.FieldName = "color"
        Me.GridColumn9.Name = "GridColumn9"
        Me.GridColumn9.Visible = True
        Me.GridColumn9.VisibleIndex = 2
        Me.GridColumn9.Width = 146
        '
        'LabelControl9
        '
        Me.LabelControl9.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl9.Location = New System.Drawing.Point(11, 11)
        Me.LabelControl9.Name = "LabelControl9"
        Me.LabelControl9.Size = New System.Drawing.Size(32, 13)
        Me.LabelControl9.TabIndex = 8895
        Me.LabelControl9.Text = "Design"
        '
        'FormProdDuty
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1241, 515)
        Me.Controls.Add(Me.GCProd)
        Me.Controls.Add(Me.PanelControl1)
        Me.MinimizeBox = False
        Me.Name = "FormProdDuty"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Duty Report"
        CType(Me.GCProd, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ViewMenu.ResumeLayout(False)
        CType(Me.GVProd, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RICEPRProposed, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RICEDutyPaid, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RIPictureEdit, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl1.ResumeLayout(False)
        Me.PanelControl1.PerformLayout()
        CType(Me.SLEVendor.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView14, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SLESeason.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SearchLookUpEdit1View, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SLEDesignStockStore.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVSLEDesgSearch, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents GCProd As DevExpress.XtraGrid.GridControl
    Friend WithEvents RIPictureEdit As DevExpress.XtraEditors.Repository.RepositoryItemPictureEdit
    Friend WithEvents PanelControl1 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents SLEVendor As DevExpress.XtraEditors.SearchLookUpEdit
    Friend WithEvents GridView14 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumn10 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn11 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn12 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents SLESeason As DevExpress.XtraEditors.SearchLookUpEdit
    Friend WithEvents SearchLookUpEdit1View As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumn6 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn8 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents BSearch As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents LabelControl3 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl1 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents SLEDesignStockStore As DevExpress.XtraEditors.SearchLookUpEdit
    Friend WithEvents GVSLEDesgSearch As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumnCodeSearch As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn7 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn9 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents LabelControl9 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents GVProd As DevExpress.XtraGrid.Views.BandedGrid.BandedGridView
    Friend WithEvents GridColumnVendorCode As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents GridColumnCompName As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents GridColumnProdNo As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents GridColumnReportStatus As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents GridColumnIdReportStatus As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents GridColumnProdDate As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents GridColumnPOType As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents GridColumnTerm As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents GridColumnDesignCOP As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents GridColumnDesign As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents GridColumnOrderQty As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents GridColumnIdPO As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents GridColumnIdSeason As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents GridColumnSeason As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents GridColumnIdDelivery As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents GridColumnDelivery As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumnColor As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumnFOB As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumnPIBNo As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumnPIBDate As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumnDutyP As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumnSTP As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumnSDP As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumnSVATP As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumnSRP As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumnEst As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumnEstRoyS As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumnEstRoyD As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumnFinal As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumnQtySalesEst As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumnFinalRoyS As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumnFinalRoyD As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BPrint As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents ViewMenu As ContextMenuStrip
    Friend WithEvents SMEdit As ToolStripMenuItem
    Friend WithEvents BandedGridColumnDiffPrice As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumnDiffRoyD As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumnPIBDueDate As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumnPIBPRDueDate As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumnDutyPaid As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumnPRProposed As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents RICEDutyPaid As DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit
    Friend WithEvents RICEPRProposed As DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit
    Friend WithEvents BandedGridColumnPOVolpro As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumnAJU As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BImportExcel As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BandedGridColumnCode As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumnUSCode As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumnQtyRec As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumnTotFOB As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumnFabrication As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumnHSCode As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumnQtyPIB As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumnPIBVolume As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumnPIBUOM As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumnPIBCur As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumnPIBKurs As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumnCIF As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumnCIFRp As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumnImportFrom As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumnDestPort As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumnLSNo As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumnLSDate As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumnIDCurPIB As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumnCOO As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumnFreightUSD As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumnPPJK As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumnPPJKInvNo As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumnPPHPercent As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumnRevAftDisc As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumnPPNEst As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumnPPHEst As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumnTotDeclareEst As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumnQtySalesActual As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumnAmoRoyaltySales As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumnRevAfterTax As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumnPPNF As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumnPPHF As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumnTotDeclareF As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumnPPNDiff As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumnPPHDiff As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumnVPDiff As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumn17 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumnAmoRoySalesRemaining As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumnRemRevAftTax As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumnRemCIF As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumnRemBM As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumnRemPPN As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumnRemPPH As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumnRemainingTotDeclare As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumnTotRemaining As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumn8 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumn7 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumn6 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumn1 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents SimpleButton1 As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BandedGridColumnRoyPib As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumnFreightCostRP As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumnBM1 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumn3 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumnCIFFinal As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumnBMFinal As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumnOutBM As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents GridBand1 As DevExpress.XtraGrid.Views.BandedGrid.GridBand
    Friend WithEvents gridBand3 As DevExpress.XtraGrid.Views.BandedGrid.GridBand
    Friend WithEvents gridBand4 As DevExpress.XtraGrid.Views.BandedGrid.GridBand
    Friend WithEvents gridBand6 As DevExpress.XtraGrid.Views.BandedGrid.GridBand
    Friend WithEvents gridBand7 As DevExpress.XtraGrid.Views.BandedGrid.GridBand
    Friend WithEvents gridBand2 As DevExpress.XtraGrid.Views.BandedGrid.GridBand
    Friend WithEvents gridBand5 As DevExpress.XtraGrid.Views.BandedGrid.GridBand
    Friend WithEvents BandedGridColumn100OutBM As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumn100OutPPN As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumn100OutPPH As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents BandedGridColumn100OutTotal As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
End Class
