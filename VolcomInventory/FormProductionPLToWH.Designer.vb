<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FormProductionPLToWH
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
        Me.XTCPL = New DevExpress.XtraTab.XtraTabControl()
        Me.XTPPList = New DevExpress.XtraTab.XtraTabPage()
        Me.GCPL = New DevExpress.XtraGrid.GridControl()
        Me.GVPL = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumnNo = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnIdPLSample = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnIdContactFrom = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnIdCompContactTo = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn1 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnPLNumber = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnSRNumber = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnFrom = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnTo = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnPLDate = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnPLNote = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnSeasno = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnStatus = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnPLCategory = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnPDAlloc = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnDesignCode = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnDesignName = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnTotal = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.XTPPLInfo = New DevExpress.XtraTab.XtraTabPage()
        Me.SCCPL = New DevExpress.XtraEditors.SplitContainerControl()
        Me.GroupControlProd = New DevExpress.XtraEditors.GroupControl()
        Me.GCProd = New DevExpress.XtraGrid.GridControl()
        Me.GVProd = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumnProdNo = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnReportStatus = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnIdReportStatus = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnProdDate = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnLeadTime = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnPOType = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnTerm = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnDesign = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnCode = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnIdPO = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnSeason = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnPLCreated = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RIPictureEdit = New DevExpress.XtraEditors.Repository.RepositoryItemPictureEdit()
        Me.GroupControlListProd = New DevExpress.XtraEditors.GroupControl()
        Me.GCListProduct = New DevExpress.XtraGrid.GridControl()
        Me.GVListProduct = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.ColIdPurcDet = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.ColIdMat = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.ColNo = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.ColCode = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.ColName = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.ColPrice = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.ColQty = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnQtyPL = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.ColSubtotal = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.ColNote = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.ColColor = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.ColSize = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.ToolTipControllerNew = New DevExpress.Utils.ToolTipController(Me.components)
        CType(Me.XTCPL, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.XTCPL.SuspendLayout()
        Me.XTPPList.SuspendLayout()
        CType(Me.GCPL, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVPL, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.XTPPLInfo.SuspendLayout()
        CType(Me.SCCPL, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SCCPL.SuspendLayout()
        CType(Me.GroupControlProd, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupControlProd.SuspendLayout()
        CType(Me.GCProd, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVProd, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RIPictureEdit, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GroupControlListProd, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupControlListProd.SuspendLayout()
        CType(Me.GCListProduct, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVListProduct, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'XTCPL
        '
        Me.XTCPL.Dock = System.Windows.Forms.DockStyle.Fill
        Me.XTCPL.HeaderLocation = DevExpress.XtraTab.TabHeaderLocation.Bottom
        Me.XTCPL.Location = New System.Drawing.Point(0, 0)
        Me.XTCPL.Name = "XTCPL"
        Me.XTCPL.SelectedTabPage = Me.XTPPList
        Me.XTCPL.Size = New System.Drawing.Size(858, 492)
        Me.XTCPL.TabIndex = 0
        Me.XTCPL.TabPages.AddRange(New DevExpress.XtraTab.XtraTabPage() {Me.XTPPList, Me.XTPPLInfo})
        '
        'XTPPList
        '
        Me.XTPPList.Controls.Add(Me.GCPL)
        Me.XTPPList.Name = "XTPPList"
        Me.XTPPList.Size = New System.Drawing.Size(852, 464)
        Me.XTPPList.Text = "List Packing List"
        '
        'GCPL
        '
        Me.GCPL.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCPL.Location = New System.Drawing.Point(0, 0)
        Me.GCPL.MainView = Me.GVPL
        Me.GCPL.Name = "GCPL"
        Me.GCPL.Size = New System.Drawing.Size(852, 464)
        Me.GCPL.TabIndex = 2
        Me.GCPL.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVPL})
        '
        'GVPL
        '
        Me.GVPL.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumnNo, Me.GridColumnIdPLSample, Me.GridColumnIdContactFrom, Me.GridColumnIdCompContactTo, Me.GridColumn1, Me.GridColumnPLNumber, Me.GridColumnSRNumber, Me.GridColumnFrom, Me.GridColumnTo, Me.GridColumnPLDate, Me.GridColumnPLNote, Me.GridColumnSeasno, Me.GridColumnStatus, Me.GridColumnPLCategory, Me.GridColumnPDAlloc, Me.GridColumnDesignCode, Me.GridColumnDesignName, Me.GridColumnTotal})
        Me.GVPL.GridControl = Me.GCPL
        Me.GVPL.GroupCount = 1
        Me.GVPL.GroupSummary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "total", Me.GridColumnTotal, "{0:n0}")})
        Me.GVPL.Name = "GVPL"
        Me.GVPL.OptionsBehavior.AutoExpandAllGroups = True
        Me.GVPL.OptionsBehavior.Editable = False
        Me.GVPL.OptionsFind.AlwaysVisible = True
        Me.GVPL.OptionsView.ShowFooter = True
        Me.GVPL.OptionsView.ShowGroupPanel = False
        Me.GVPL.SortInfo.AddRange(New DevExpress.XtraGrid.Columns.GridColumnSortInfo() {New DevExpress.XtraGrid.Columns.GridColumnSortInfo(Me.GridColumnSeasno, DevExpress.Data.ColumnSortOrder.Descending), New DevExpress.XtraGrid.Columns.GridColumnSortInfo(Me.GridColumnIdPLSample, DevExpress.Data.ColumnSortOrder.Descending)})
        '
        'GridColumnNo
        '
        Me.GridColumnNo.Caption = "No"
        Me.GridColumnNo.FieldName = "no"
        Me.GridColumnNo.Name = "GridColumnNo"
        Me.GridColumnNo.OptionsColumn.ShowInCustomizationForm = False
        Me.GridColumnNo.Width = 41
        '
        'GridColumnIdPLSample
        '
        Me.GridColumnIdPLSample.Caption = "Id PL Sample"
        Me.GridColumnIdPLSample.FieldName = "id_pl_prod_order"
        Me.GridColumnIdPLSample.Name = "GridColumnIdPLSample"
        Me.GridColumnIdPLSample.OptionsColumn.ShowInCustomizationForm = False
        '
        'GridColumnIdContactFrom
        '
        Me.GridColumnIdContactFrom.Caption = "GridColumnIdContacctFrom"
        Me.GridColumnIdContactFrom.FieldName = "id_comp_contact_from"
        Me.GridColumnIdContactFrom.Name = "GridColumnIdContactFrom"
        Me.GridColumnIdContactFrom.OptionsColumn.ShowInCustomizationForm = False
        '
        'GridColumnIdCompContactTo
        '
        Me.GridColumnIdCompContactTo.Caption = "GridColumnIdCompContactTo"
        Me.GridColumnIdCompContactTo.FieldName = "id_comp_contact_to"
        Me.GridColumnIdCompContactTo.Name = "GridColumnIdCompContactTo"
        Me.GridColumnIdCompContactTo.OptionsColumn.ShowInCustomizationForm = False
        '
        'GridColumn1
        '
        Me.GridColumn1.Caption = "GridColumn1"
        Me.GridColumn1.FieldName = "id_report_status"
        Me.GridColumn1.Name = "GridColumn1"
        '
        'GridColumnPLNumber
        '
        Me.GridColumnPLNumber.Caption = "Number"
        Me.GridColumnPLNumber.FieldName = "pl_prod_order_number"
        Me.GridColumnPLNumber.Name = "GridColumnPLNumber"
        Me.GridColumnPLNumber.Visible = True
        Me.GridColumnPLNumber.VisibleIndex = 0
        Me.GridColumnPLNumber.Width = 120
        '
        'GridColumnSRNumber
        '
        Me.GridColumnSRNumber.Caption = "Order"
        Me.GridColumnSRNumber.FieldName = "prod_order_number"
        Me.GridColumnSRNumber.Name = "GridColumnSRNumber"
        Me.GridColumnSRNumber.Visible = True
        Me.GridColumnSRNumber.VisibleIndex = 1
        Me.GridColumnSRNumber.Width = 93
        '
        'GridColumnFrom
        '
        Me.GridColumnFrom.Caption = "From"
        Me.GridColumnFrom.FieldName = "comp_name_from"
        Me.GridColumnFrom.Name = "GridColumnFrom"
        Me.GridColumnFrom.Visible = True
        Me.GridColumnFrom.VisibleIndex = 4
        Me.GridColumnFrom.Width = 155
        '
        'GridColumnTo
        '
        Me.GridColumnTo.Caption = "To"
        Me.GridColumnTo.FieldName = "comp_name_to"
        Me.GridColumnTo.Name = "GridColumnTo"
        Me.GridColumnTo.Visible = True
        Me.GridColumnTo.VisibleIndex = 5
        Me.GridColumnTo.Width = 131
        '
        'GridColumnPLDate
        '
        Me.GridColumnPLDate.Caption = "Created Date"
        Me.GridColumnPLDate.DisplayFormat.FormatString = "dd MMMM yyyy"
        Me.GridColumnPLDate.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.GridColumnPLDate.FieldName = "pl_prod_order_date"
        Me.GridColumnPLDate.Name = "GridColumnPLDate"
        Me.GridColumnPLDate.Visible = True
        Me.GridColumnPLDate.VisibleIndex = 7
        Me.GridColumnPLDate.Width = 73
        '
        'GridColumnPLNote
        '
        Me.GridColumnPLNote.Caption = "Note"
        Me.GridColumnPLNote.FieldName = "pl_prod_order_note"
        Me.GridColumnPLNote.Name = "GridColumnPLNote"
        Me.GridColumnPLNote.Width = 97
        '
        'GridColumnSeasno
        '
        Me.GridColumnSeasno.Caption = "Season"
        Me.GridColumnSeasno.FieldName = "season"
        Me.GridColumnSeasno.FieldNameSortGroup = "id_season"
        Me.GridColumnSeasno.Name = "GridColumnSeasno"
        Me.GridColumnSeasno.Visible = True
        Me.GridColumnSeasno.VisibleIndex = 0
        '
        'GridColumnStatus
        '
        Me.GridColumnStatus.Caption = "Status"
        Me.GridColumnStatus.FieldName = "report_status"
        Me.GridColumnStatus.Name = "GridColumnStatus"
        Me.GridColumnStatus.Visible = True
        Me.GridColumnStatus.VisibleIndex = 9
        Me.GridColumnStatus.Width = 50
        '
        'GridColumnPLCategory
        '
        Me.GridColumnPLCategory.Caption = "PL Category"
        Me.GridColumnPLCategory.FieldName = "pl_category"
        Me.GridColumnPLCategory.Name = "GridColumnPLCategory"
        Me.GridColumnPLCategory.Visible = True
        Me.GridColumnPLCategory.VisibleIndex = 8
        Me.GridColumnPLCategory.Width = 48
        '
        'GridColumnPDAlloc
        '
        Me.GridColumnPDAlloc.Caption = "Allocation"
        Me.GridColumnPDAlloc.FieldName = "pd_alloc"
        Me.GridColumnPDAlloc.Name = "GridColumnPDAlloc"
        '
        'GridColumnDesignCode
        '
        Me.GridColumnDesignCode.Caption = "Code"
        Me.GridColumnDesignCode.FieldName = "code"
        Me.GridColumnDesignCode.Name = "GridColumnDesignCode"
        Me.GridColumnDesignCode.OptionsColumn.ReadOnly = True
        Me.GridColumnDesignCode.Visible = True
        Me.GridColumnDesignCode.VisibleIndex = 2
        Me.GridColumnDesignCode.Width = 93
        '
        'GridColumnDesignName
        '
        Me.GridColumnDesignName.Caption = "Name"
        Me.GridColumnDesignName.FieldName = "name"
        Me.GridColumnDesignName.Name = "GridColumnDesignName"
        Me.GridColumnDesignName.OptionsColumn.ReadOnly = True
        Me.GridColumnDesignName.Visible = True
        Me.GridColumnDesignName.VisibleIndex = 3
        Me.GridColumnDesignName.Width = 243
        '
        'GridColumnTotal
        '
        Me.GridColumnTotal.Caption = "Total"
        Me.GridColumnTotal.DisplayFormat.FormatString = "N0"
        Me.GridColumnTotal.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumnTotal.FieldName = "total"
        Me.GridColumnTotal.Name = "GridColumnTotal"
        Me.GridColumnTotal.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "total", "{0:N0}")})
        Me.GridColumnTotal.Visible = True
        Me.GridColumnTotal.VisibleIndex = 6
        Me.GridColumnTotal.Width = 56
        '
        'XTPPLInfo
        '
        Me.XTPPLInfo.Controls.Add(Me.SCCPL)
        Me.XTPPLInfo.Name = "XTPPLInfo"
        Me.XTPPLInfo.Size = New System.Drawing.Size(852, 464)
        Me.XTPPLInfo.Text = "Info Packing List"
        '
        'SCCPL
        '
        Me.SCCPL.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SCCPL.Horizontal = False
        Me.SCCPL.Location = New System.Drawing.Point(0, 0)
        Me.SCCPL.Name = "SCCPL"
        Me.SCCPL.Panel1.Controls.Add(Me.GroupControlProd)
        Me.SCCPL.Panel1.Text = "Panel1"
        Me.SCCPL.Panel2.Controls.Add(Me.GroupControlListProd)
        Me.SCCPL.Panel2.Text = "Panel2"
        Me.SCCPL.Size = New System.Drawing.Size(852, 464)
        Me.SCCPL.SplitterPosition = 236
        Me.SCCPL.TabIndex = 1
        Me.SCCPL.Text = "SplitContainerControl1"
        '
        'GroupControlProd
        '
        Me.GroupControlProd.Controls.Add(Me.GCProd)
        Me.GroupControlProd.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupControlProd.Location = New System.Drawing.Point(0, 0)
        Me.GroupControlProd.Name = "GroupControlProd"
        Me.GroupControlProd.Size = New System.Drawing.Size(852, 236)
        Me.GroupControlProd.TabIndex = 1
        Me.GroupControlProd.Text = "Production Order"
        '
        'GCProd
        '
        Me.GCProd.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCProd.Location = New System.Drawing.Point(2, 20)
        Me.GCProd.MainView = Me.GVProd
        Me.GCProd.Name = "GCProd"
        Me.GCProd.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.RIPictureEdit})
        Me.GCProd.Size = New System.Drawing.Size(848, 214)
        Me.GCProd.TabIndex = 3
        Me.GCProd.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVProd})
        '
        'GVProd
        '
        Me.GVProd.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumnProdNo, Me.GridColumnReportStatus, Me.GridColumnIdReportStatus, Me.GridColumnProdDate, Me.GridColumnLeadTime, Me.GridColumnPOType, Me.GridColumnTerm, Me.GridColumnDesign, Me.GridColumnCode, Me.GridColumnIdPO, Me.GridColumnSeason, Me.GridColumnPLCreated})
        Me.GVProd.GridControl = Me.GCProd
        Me.GVProd.GroupCount = 1
        Me.GVProd.Name = "GVProd"
        Me.GVProd.OptionsBehavior.Editable = False
        Me.GVProd.OptionsFind.AlwaysVisible = True
        Me.GVProd.OptionsView.ShowGroupPanel = False
        Me.GVProd.SortInfo.AddRange(New DevExpress.XtraGrid.Columns.GridColumnSortInfo() {New DevExpress.XtraGrid.Columns.GridColumnSortInfo(Me.GridColumnSeason, DevExpress.Data.ColumnSortOrder.Descending)})
        '
        'GridColumnProdNo
        '
        Me.GridColumnProdNo.Caption = "Number"
        Me.GridColumnProdNo.FieldName = "prod_order_number"
        Me.GridColumnProdNo.Name = "GridColumnProdNo"
        Me.GridColumnProdNo.Visible = True
        Me.GridColumnProdNo.VisibleIndex = 0
        Me.GridColumnProdNo.Width = 91
        '
        'GridColumnReportStatus
        '
        Me.GridColumnReportStatus.Caption = "Status"
        Me.GridColumnReportStatus.FieldName = "report_status"
        Me.GridColumnReportStatus.Name = "GridColumnReportStatus"
        Me.GridColumnReportStatus.Visible = True
        Me.GridColumnReportStatus.VisibleIndex = 7
        Me.GridColumnReportStatus.Width = 121
        '
        'GridColumnIdReportStatus
        '
        Me.GridColumnIdReportStatus.Caption = "Id Report Status"
        Me.GridColumnIdReportStatus.FieldName = "id_report_status"
        Me.GridColumnIdReportStatus.Name = "GridColumnIdReportStatus"
        Me.GridColumnIdReportStatus.Width = 89
        '
        'GridColumnProdDate
        '
        Me.GridColumnProdDate.Caption = "Date"
        Me.GridColumnProdDate.DisplayFormat.FormatString = "dd MMMM yyyy"
        Me.GridColumnProdDate.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.GridColumnProdDate.FieldName = "prod_order_date"
        Me.GridColumnProdDate.Name = "GridColumnProdDate"
        Me.GridColumnProdDate.Visible = True
        Me.GridColumnProdDate.VisibleIndex = 5
        Me.GridColumnProdDate.Width = 96
        '
        'GridColumnLeadTime
        '
        Me.GridColumnLeadTime.Caption = "Est. Rec Date"
        Me.GridColumnLeadTime.DisplayFormat.FormatString = "dd MMMM yyyy"
        Me.GridColumnLeadTime.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.GridColumnLeadTime.FieldName = "prod_order_lead_time"
        Me.GridColumnLeadTime.Name = "GridColumnLeadTime"
        Me.GridColumnLeadTime.Visible = True
        Me.GridColumnLeadTime.VisibleIndex = 6
        '
        'GridColumnPOType
        '
        Me.GridColumnPOType.Caption = "PO Type"
        Me.GridColumnPOType.FieldName = "po_type"
        Me.GridColumnPOType.Name = "GridColumnPOType"
        Me.GridColumnPOType.Visible = True
        Me.GridColumnPOType.VisibleIndex = 3
        Me.GridColumnPOType.Width = 96
        '
        'GridColumnTerm
        '
        Me.GridColumnTerm.Caption = "Term"
        Me.GridColumnTerm.FieldName = "term_production"
        Me.GridColumnTerm.Name = "GridColumnTerm"
        Me.GridColumnTerm.Visible = True
        Me.GridColumnTerm.VisibleIndex = 4
        Me.GridColumnTerm.Width = 96
        '
        'GridColumnDesign
        '
        Me.GridColumnDesign.Caption = "Design"
        Me.GridColumnDesign.FieldName = "design_display_name"
        Me.GridColumnDesign.Name = "GridColumnDesign"
        Me.GridColumnDesign.Visible = True
        Me.GridColumnDesign.VisibleIndex = 2
        Me.GridColumnDesign.Width = 148
        '
        'GridColumnCode
        '
        Me.GridColumnCode.Caption = "Design Code"
        Me.GridColumnCode.FieldName = "design_code"
        Me.GridColumnCode.Name = "GridColumnCode"
        Me.GridColumnCode.Visible = True
        Me.GridColumnCode.VisibleIndex = 1
        Me.GridColumnCode.Width = 96
        '
        'GridColumnIdPO
        '
        Me.GridColumnIdPO.Caption = "ID PO"
        Me.GridColumnIdPO.FieldName = "id_prod_order"
        Me.GridColumnIdPO.Name = "GridColumnIdPO"
        '
        'GridColumnSeason
        '
        Me.GridColumnSeason.Caption = "Season"
        Me.GridColumnSeason.FieldName = "season"
        Me.GridColumnSeason.FieldNameSortGroup = "id_season"
        Me.GridColumnSeason.Name = "GridColumnSeason"
        '
        'GridColumnPLCreated
        '
        Me.GridColumnPLCreated.Caption = "PL Created"
        Me.GridColumnPLCreated.FieldName = "pl_created"
        Me.GridColumnPLCreated.Name = "GridColumnPLCreated"
        Me.GridColumnPLCreated.Visible = True
        Me.GridColumnPLCreated.VisibleIndex = 8
        '
        'RIPictureEdit
        '
        Me.RIPictureEdit.Name = "RIPictureEdit"
        Me.RIPictureEdit.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Stretch
        '
        'GroupControlListProd
        '
        Me.GroupControlListProd.Controls.Add(Me.GCListProduct)
        Me.GroupControlListProd.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupControlListProd.Location = New System.Drawing.Point(0, 0)
        Me.GroupControlListProd.Name = "GroupControlListProd"
        Me.GroupControlListProd.Size = New System.Drawing.Size(852, 223)
        Me.GroupControlListProd.TabIndex = 2
        Me.GroupControlListProd.Text = "List Production Order"
        '
        'GCListProduct
        '
        Me.GCListProduct.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCListProduct.Location = New System.Drawing.Point(2, 20)
        Me.GCListProduct.MainView = Me.GVListProduct
        Me.GCListProduct.Margin = New System.Windows.Forms.Padding(0)
        Me.GCListProduct.Name = "GCListProduct"
        Me.GCListProduct.Size = New System.Drawing.Size(848, 201)
        Me.GCListProduct.TabIndex = 1
        Me.GCListProduct.ToolTipController = Me.ToolTipControllerNew
        Me.GCListProduct.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVListProduct})
        '
        'GVListProduct
        '
        Me.GVListProduct.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.ColIdPurcDet, Me.ColIdMat, Me.ColNo, Me.ColCode, Me.ColName, Me.ColPrice, Me.ColQty, Me.GridColumnQtyPL, Me.ColSubtotal, Me.ColNote, Me.ColColor, Me.ColSize})
        Me.GVListProduct.GridControl = Me.GCListProduct
        Me.GVListProduct.HorzScrollVisibility = DevExpress.XtraGrid.Views.Base.ScrollVisibility.Never
        Me.GVListProduct.Name = "GVListProduct"
        Me.GVListProduct.OptionsView.ShowFooter = True
        Me.GVListProduct.OptionsView.ShowGroupPanel = False
        '
        'ColIdPurcDet
        '
        Me.ColIdPurcDet.Caption = "ID Purc Det"
        Me.ColIdPurcDet.FieldName = "id_prod_order_det"
        Me.ColIdPurcDet.Name = "ColIdPurcDet"
        '
        'ColIdMat
        '
        Me.ColIdMat.Caption = "Id Mat"
        Me.ColIdMat.FieldName = "id_prod_demand_product"
        Me.ColIdMat.Name = "ColIdMat"
        '
        'ColNo
        '
        Me.ColNo.AppearanceCell.Options.UseTextOptions = True
        Me.ColNo.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.ColNo.AppearanceHeader.Options.UseTextOptions = True
        Me.ColNo.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.ColNo.Caption = "No."
        Me.ColNo.FieldName = "no"
        Me.ColNo.Name = "ColNo"
        Me.ColNo.OptionsColumn.AllowEdit = False
        Me.ColNo.Visible = True
        Me.ColNo.VisibleIndex = 0
        Me.ColNo.Width = 23
        '
        'ColCode
        '
        Me.ColCode.Caption = "Code"
        Me.ColCode.FieldName = "code"
        Me.ColCode.Name = "ColCode"
        Me.ColCode.OptionsColumn.AllowEdit = False
        Me.ColCode.Visible = True
        Me.ColCode.VisibleIndex = 1
        Me.ColCode.Width = 114
        '
        'ColName
        '
        Me.ColName.Caption = "Name"
        Me.ColName.FieldName = "name"
        Me.ColName.Name = "ColName"
        Me.ColName.OptionsColumn.AllowEdit = False
        Me.ColName.Visible = True
        Me.ColName.VisibleIndex = 2
        Me.ColName.Width = 192
        '
        'ColPrice
        '
        Me.ColPrice.AppearanceCell.Options.UseTextOptions = True
        Me.ColPrice.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.ColPrice.AppearanceHeader.Options.UseTextOptions = True
        Me.ColPrice.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.ColPrice.Caption = "Unit Cost"
        Me.ColPrice.DisplayFormat.FormatString = "N2"
        Me.ColPrice.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.ColPrice.FieldName = "estimate_cost"
        Me.ColPrice.Name = "ColPrice"
        Me.ColPrice.OptionsColumn.AllowEdit = False
        Me.ColPrice.Width = 100
        '
        'ColQty
        '
        Me.ColQty.AppearanceCell.Options.UseTextOptions = True
        Me.ColQty.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.ColQty.AppearanceHeader.Options.UseTextOptions = True
        Me.ColQty.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.ColQty.Caption = "Qty Remaining"
        Me.ColQty.DisplayFormat.FormatString = "{0:F2}"
        Me.ColQty.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.ColQty.FieldName = "qty"
        Me.ColQty.Name = "ColQty"
        Me.ColQty.OptionsColumn.AllowEdit = False
        Me.ColQty.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "qty", "{0:F2}")})
        Me.ColQty.Visible = True
        Me.ColQty.VisibleIndex = 6
        Me.ColQty.Width = 93
        '
        'GridColumnQtyPL
        '
        Me.GridColumnQtyPL.Caption = "Qty Created In PL"
        Me.GridColumnQtyPL.DisplayFormat.FormatString = "{0:F2}"
        Me.GridColumnQtyPL.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumnQtyPL.FieldName = "qty_pl"
        Me.GridColumnQtyPL.Name = "GridColumnQtyPL"
        Me.GridColumnQtyPL.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "qty_pl", "{0:F2}")})
        Me.GridColumnQtyPL.Visible = True
        Me.GridColumnQtyPL.VisibleIndex = 5
        Me.GridColumnQtyPL.Width = 100
        '
        'ColSubtotal
        '
        Me.ColSubtotal.AppearanceCell.Options.UseTextOptions = True
        Me.ColSubtotal.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.ColSubtotal.AppearanceHeader.Options.UseTextOptions = True
        Me.ColSubtotal.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.ColSubtotal.Caption = "Sub Total"
        Me.ColSubtotal.DisplayFormat.FormatString = "N2"
        Me.ColSubtotal.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.ColSubtotal.FieldName = "total_cost"
        Me.ColSubtotal.Name = "ColSubtotal"
        Me.ColSubtotal.OptionsColumn.AllowEdit = False
        Me.ColSubtotal.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "total_cost", "{0:N2}")})
        Me.ColSubtotal.Width = 88
        '
        'ColNote
        '
        Me.ColNote.Caption = "Note"
        Me.ColNote.FieldName = "note"
        Me.ColNote.Name = "ColNote"
        '
        'ColColor
        '
        Me.ColColor.AppearanceCell.Options.UseTextOptions = True
        Me.ColColor.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.ColColor.AppearanceHeader.Options.UseTextOptions = True
        Me.ColColor.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.ColColor.Caption = "Color"
        Me.ColColor.FieldName = "color"
        Me.ColColor.Name = "ColColor"
        Me.ColColor.OptionsColumn.AllowEdit = False
        Me.ColColor.Visible = True
        Me.ColColor.VisibleIndex = 3
        Me.ColColor.Width = 61
        '
        'ColSize
        '
        Me.ColSize.AppearanceCell.Options.UseTextOptions = True
        Me.ColSize.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.ColSize.AppearanceHeader.Options.UseTextOptions = True
        Me.ColSize.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.ColSize.Caption = "Size"
        Me.ColSize.FieldName = "size"
        Me.ColSize.Name = "ColSize"
        Me.ColSize.OptionsColumn.AllowEdit = False
        Me.ColSize.Visible = True
        Me.ColSize.VisibleIndex = 4
        Me.ColSize.Width = 61
        '
        'ToolTipControllerNew
        '
        Me.ToolTipControllerNew.InitialDelay = 100
        Me.ToolTipControllerNew.ReshowDelay = 50
        '
        'FormProductionPLToWH
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(858, 492)
        Me.Controls.Add(Me.XTCPL)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FormProductionPLToWH"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Packing List Finished Goods"
        CType(Me.XTCPL, System.ComponentModel.ISupportInitialize).EndInit()
        Me.XTCPL.ResumeLayout(False)
        Me.XTPPList.ResumeLayout(False)
        CType(Me.GCPL, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVPL, System.ComponentModel.ISupportInitialize).EndInit()
        Me.XTPPLInfo.ResumeLayout(False)
        CType(Me.SCCPL, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SCCPL.ResumeLayout(False)
        CType(Me.GroupControlProd, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupControlProd.ResumeLayout(False)
        CType(Me.GCProd, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVProd, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RIPictureEdit, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GroupControlListProd, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupControlListProd.ResumeLayout(False)
        CType(Me.GCListProduct, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVListProduct, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents XTCPL As DevExpress.XtraTab.XtraTabControl
    Friend WithEvents XTPPList As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents XTPPLInfo As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents GCPL As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVPL As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumnNo As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnIdPLSample As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnIdContactFrom As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnIdCompContactTo As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn1 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnPLNumber As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnSRNumber As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnFrom As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnTo As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnPLDate As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnPLNote As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnStatus As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnSeasno As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnPLCategory As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents SCCPL As DevExpress.XtraEditors.SplitContainerControl
    Friend WithEvents GroupControlProd As DevExpress.XtraEditors.GroupControl
    Friend WithEvents GCProd As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVProd As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumnProdNo As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnReportStatus As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnIdReportStatus As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnProdDate As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnLeadTime As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnPOType As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnTerm As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnDesign As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnCode As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnIdPO As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnSeason As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents RIPictureEdit As DevExpress.XtraEditors.Repository.RepositoryItemPictureEdit
    Friend WithEvents GridColumnPLCreated As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GroupControlListProd As DevExpress.XtraEditors.GroupControl
    Friend WithEvents GCListProduct As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVListProduct As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents ColIdPurcDet As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColIdMat As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColNo As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColCode As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColName As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColPrice As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColQty As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnQtyPL As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColSubtotal As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColNote As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColColor As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColSize As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ToolTipControllerNew As DevExpress.Utils.ToolTipController
    Friend WithEvents GridColumnPDAlloc As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnDesignCode As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnDesignName As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnTotal As DevExpress.XtraGrid.Columns.GridColumn
End Class
