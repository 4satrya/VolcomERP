﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormSalesReturnQC
    Inherits DevExpress.XtraEditors.XtraForm

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
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
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.GCSalesReturnQC = New DevExpress.XtraGrid.GridControl()
        Me.GVSalesReturnQC = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumnSalesReturnQCNumber = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnSalesReturnNumber = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnStoreNameFrom = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnCreatedDate = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnQCCategory = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnReportStatus = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnCompTo = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnLastUpdate = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnLastUser = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.ViewMenu = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.SMPrePrint = New System.Windows.Forms.ToolStripMenuItem()
        Me.SMPrint = New System.Windows.Forms.ToolStripMenuItem()
        Me.XTCReturnQC = New DevExpress.XtraTab.XtraTabControl()
        Me.XTPReturnQC = New DevExpress.XtraTab.XtraTabPage()
        Me.XTPReturnList = New DevExpress.XtraTab.XtraTabPage()
        Me.SplitContainerControl1 = New DevExpress.XtraEditors.SplitContainerControl()
        Me.GroupControl1 = New DevExpress.XtraEditors.GroupControl()
        Me.GCSalesReturn = New DevExpress.XtraGrid.GridControl()
        Me.GVSalesReturn = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumnSalesTargetNumb = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn1 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnCompNameFrom = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnSalesTargetDate = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnDSalesTargetNote = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn2 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridView2 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GroupControl2 = New DevExpress.XtraEditors.GroupControl()
        Me.GCItemList = New DevExpress.XtraGrid.GridControl()
        Me.GVItemList = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumnNo = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnIdSalesTarget = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnCode = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnName = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnSize = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnUOM = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnQty = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RepositoryItemSpinEdit1 = New DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit()
        Me.GridColumnAllowedQty = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnPrice = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnAmount = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnRemark = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnIdDesign = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnIdProduct = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnIdSample = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnIdSalesOrderDet = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnProductName = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnIdDesignPrice = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnPriceType = New DevExpress.XtraGrid.Columns.GridColumn()
        CType(Me.GCSalesReturnQC, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVSalesReturnQC, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ViewMenu.SuspendLayout()
        CType(Me.XTCReturnQC, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.XTCReturnQC.SuspendLayout()
        Me.XTPReturnQC.SuspendLayout()
        Me.XTPReturnList.SuspendLayout()
        CType(Me.SplitContainerControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainerControl1.SuspendLayout()
        CType(Me.GroupControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupControl1.SuspendLayout()
        CType(Me.GCSalesReturn, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVSalesReturn, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GroupControl2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupControl2.SuspendLayout()
        CType(Me.GCItemList, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVItemList, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemSpinEdit1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GCSalesReturnQC
        '
        Me.GCSalesReturnQC.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCSalesReturnQC.Location = New System.Drawing.Point(0, 0)
        Me.GCSalesReturnQC.MainView = Me.GVSalesReturnQC
        Me.GCSalesReturnQC.Name = "GCSalesReturnQC"
        Me.GCSalesReturnQC.Size = New System.Drawing.Size(762, 481)
        Me.GCSalesReturnQC.TabIndex = 0
        Me.GCSalesReturnQC.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVSalesReturnQC})
        '
        'GVSalesReturnQC
        '
        Me.GVSalesReturnQC.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumnSalesReturnQCNumber, Me.GridColumnSalesReturnNumber, Me.GridColumnStoreNameFrom, Me.GridColumnCreatedDate, Me.GridColumnQCCategory, Me.GridColumnReportStatus, Me.GridColumnCompTo, Me.GridColumnLastUpdate, Me.GridColumnLastUser})
        Me.GVSalesReturnQC.GridControl = Me.GCSalesReturnQC
        Me.GVSalesReturnQC.Name = "GVSalesReturnQC"
        Me.GVSalesReturnQC.OptionsView.ShowGroupPanel = False
        '
        'GridColumnSalesReturnQCNumber
        '
        Me.GridColumnSalesReturnQCNumber.Caption = "Number"
        Me.GridColumnSalesReturnQCNumber.FieldName = "sales_return_qc_number"
        Me.GridColumnSalesReturnQCNumber.Name = "GridColumnSalesReturnQCNumber"
        Me.GridColumnSalesReturnQCNumber.Visible = True
        Me.GridColumnSalesReturnQCNumber.VisibleIndex = 0
        '
        'GridColumnSalesReturnNumber
        '
        Me.GridColumnSalesReturnNumber.Caption = "Return Number"
        Me.GridColumnSalesReturnNumber.FieldName = "sales_return_number"
        Me.GridColumnSalesReturnNumber.Name = "GridColumnSalesReturnNumber"
        Me.GridColumnSalesReturnNumber.Visible = True
        Me.GridColumnSalesReturnNumber.VisibleIndex = 1
        '
        'GridColumnStoreNameFrom
        '
        Me.GridColumnStoreNameFrom.Caption = "Return From"
        Me.GridColumnStoreNameFrom.FieldName = "store_name_from"
        Me.GridColumnStoreNameFrom.Name = "GridColumnStoreNameFrom"
        Me.GridColumnStoreNameFrom.Visible = True
        Me.GridColumnStoreNameFrom.VisibleIndex = 2
        '
        'GridColumnCreatedDate
        '
        Me.GridColumnCreatedDate.Caption = "Created Date"
        Me.GridColumnCreatedDate.DisplayFormat.FormatString = "dd MMMM yyyy"
        Me.GridColumnCreatedDate.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.GridColumnCreatedDate.FieldName = "sales_return_qc_date"
        Me.GridColumnCreatedDate.Name = "GridColumnCreatedDate"
        Me.GridColumnCreatedDate.Visible = True
        Me.GridColumnCreatedDate.VisibleIndex = 5
        '
        'GridColumnQCCategory
        '
        Me.GridColumnQCCategory.Caption = "QC Category"
        Me.GridColumnQCCategory.FieldName = "pl_category"
        Me.GridColumnQCCategory.Name = "GridColumnQCCategory"
        Me.GridColumnQCCategory.Visible = True
        Me.GridColumnQCCategory.VisibleIndex = 4
        '
        'GridColumnReportStatus
        '
        Me.GridColumnReportStatus.Caption = "Status"
        Me.GridColumnReportStatus.FieldName = "report_status"
        Me.GridColumnReportStatus.Name = "GridColumnReportStatus"
        Me.GridColumnReportStatus.Visible = True
        Me.GridColumnReportStatus.VisibleIndex = 8
        '
        'GridColumnCompTo
        '
        Me.GridColumnCompTo.Caption = "Destination"
        Me.GridColumnCompTo.FieldName = "comp_name_to"
        Me.GridColumnCompTo.Name = "GridColumnCompTo"
        Me.GridColumnCompTo.Visible = True
        Me.GridColumnCompTo.VisibleIndex = 3
        '
        'GridColumnLastUpdate
        '
        Me.GridColumnLastUpdate.Caption = "Last Updated"
        Me.GridColumnLastUpdate.DisplayFormat.FormatString = "dd MMMM yyyy'/'hh:mm tt"
        Me.GridColumnLastUpdate.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.GridColumnLastUpdate.FieldName = "last_update"
        Me.GridColumnLastUpdate.Name = "GridColumnLastUpdate"
        Me.GridColumnLastUpdate.Visible = True
        Me.GridColumnLastUpdate.VisibleIndex = 6
        '
        'GridColumnLastUser
        '
        Me.GridColumnLastUser.Caption = "Updated By"
        Me.GridColumnLastUser.FieldName = "last_user"
        Me.GridColumnLastUser.Name = "GridColumnLastUser"
        Me.GridColumnLastUser.Visible = True
        Me.GridColumnLastUser.VisibleIndex = 7
        '
        'ViewMenu
        '
        Me.ViewMenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.SMPrePrint, Me.SMPrint})
        Me.ViewMenu.Name = "ContextMenuStripYM"
        Me.ViewMenu.Size = New System.Drawing.Size(137, 48)
        '
        'SMPrePrint
        '
        Me.SMPrePrint.Name = "SMPrePrint"
        Me.SMPrePrint.Size = New System.Drawing.Size(136, 22)
        Me.SMPrePrint.Text = "Pre Printing"
        '
        'SMPrint
        '
        Me.SMPrint.Name = "SMPrint"
        Me.SMPrint.Size = New System.Drawing.Size(136, 22)
        Me.SMPrint.Text = "Print"
        '
        'XTCReturnQC
        '
        Me.XTCReturnQC.Dock = System.Windows.Forms.DockStyle.Fill
        Me.XTCReturnQC.HeaderLocation = DevExpress.XtraTab.TabHeaderLocation.Bottom
        Me.XTCReturnQC.Location = New System.Drawing.Point(0, 0)
        Me.XTCReturnQC.Name = "XTCReturnQC"
        Me.XTCReturnQC.SelectedTabPage = Me.XTPReturnQC
        Me.XTCReturnQC.Size = New System.Drawing.Size(768, 509)
        Me.XTCReturnQC.TabIndex = 1
        Me.XTCReturnQC.TabPages.AddRange(New DevExpress.XtraTab.XtraTabPage() {Me.XTPReturnQC, Me.XTPReturnList})
        '
        'XTPReturnQC
        '
        Me.XTPReturnQC.Controls.Add(Me.GCSalesReturnQC)
        Me.XTPReturnQC.Name = "XTPReturnQC"
        Me.XTPReturnQC.Size = New System.Drawing.Size(762, 481)
        Me.XTPReturnQC.Text = "Transaction List"
        '
        'XTPReturnList
        '
        Me.XTPReturnList.Controls.Add(Me.SplitContainerControl1)
        Me.XTPReturnList.Name = "XTPReturnList"
        Me.XTPReturnList.Size = New System.Drawing.Size(762, 481)
        Me.XTPReturnList.Text = "Return List"
        '
        'SplitContainerControl1
        '
        Me.SplitContainerControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainerControl1.Horizontal = False
        Me.SplitContainerControl1.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainerControl1.Name = "SplitContainerControl1"
        Me.SplitContainerControl1.Panel1.Controls.Add(Me.GroupControl1)
        Me.SplitContainerControl1.Panel1.Text = "Panel1"
        Me.SplitContainerControl1.Panel2.Controls.Add(Me.GroupControl2)
        Me.SplitContainerControl1.Panel2.Text = "Panel2"
        Me.SplitContainerControl1.Size = New System.Drawing.Size(762, 481)
        Me.SplitContainerControl1.SplitterPosition = 217
        Me.SplitContainerControl1.TabIndex = 0
        Me.SplitContainerControl1.Text = "SplitContainerControl1"
        '
        'GroupControl1
        '
        Me.GroupControl1.CaptionLocation = DevExpress.Utils.Locations.Left
        Me.GroupControl1.Controls.Add(Me.GCSalesReturn)
        Me.GroupControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupControl1.Location = New System.Drawing.Point(0, 0)
        Me.GroupControl1.Name = "GroupControl1"
        Me.GroupControl1.Size = New System.Drawing.Size(762, 217)
        Me.GroupControl1.TabIndex = 0
        Me.GroupControl1.Text = "Return List"
        '
        'GCSalesReturn
        '
        Me.GCSalesReturn.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCSalesReturn.Location = New System.Drawing.Point(20, 2)
        Me.GCSalesReturn.MainView = Me.GVSalesReturn
        Me.GCSalesReturn.Name = "GCSalesReturn"
        Me.GCSalesReturn.Size = New System.Drawing.Size(740, 213)
        Me.GCSalesReturn.TabIndex = 4
        Me.GCSalesReturn.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVSalesReturn, Me.GridView2})
        '
        'GVSalesReturn
        '
        Me.GVSalesReturn.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumnSalesTargetNumb, Me.GridColumn1, Me.GridColumnCompNameFrom, Me.GridColumnSalesTargetDate, Me.GridColumnDSalesTargetNote, Me.GridColumn2})
        Me.GVSalesReturn.GridControl = Me.GCSalesReturn
        Me.GVSalesReturn.Name = "GVSalesReturn"
        Me.GVSalesReturn.OptionsBehavior.ReadOnly = True
        Me.GVSalesReturn.OptionsView.ShowGroupPanel = False
        '
        'GridColumnSalesTargetNumb
        '
        Me.GridColumnSalesTargetNumb.Caption = "Number"
        Me.GridColumnSalesTargetNumb.FieldName = "sales_return_number"
        Me.GridColumnSalesTargetNumb.Name = "GridColumnSalesTargetNumb"
        Me.GridColumnSalesTargetNumb.Visible = True
        Me.GridColumnSalesTargetNumb.VisibleIndex = 0
        Me.GridColumnSalesTargetNumb.Width = 83
        '
        'GridColumn1
        '
        Me.GridColumn1.Caption = "Store"
        Me.GridColumn1.FieldName = "store_name_from"
        Me.GridColumn1.Name = "GridColumn1"
        Me.GridColumn1.Visible = True
        Me.GridColumn1.VisibleIndex = 1
        '
        'GridColumnCompNameFrom
        '
        Me.GridColumnCompNameFrom.Caption = "Destination"
        Me.GridColumnCompNameFrom.FieldName = "comp_name_to"
        Me.GridColumnCompNameFrom.Name = "GridColumnCompNameFrom"
        Me.GridColumnCompNameFrom.Visible = True
        Me.GridColumnCompNameFrom.VisibleIndex = 2
        '
        'GridColumnSalesTargetDate
        '
        Me.GridColumnSalesTargetDate.Caption = "Created Date"
        Me.GridColumnSalesTargetDate.FieldName = "sales_return_date"
        Me.GridColumnSalesTargetDate.Name = "GridColumnSalesTargetDate"
        Me.GridColumnSalesTargetDate.Visible = True
        Me.GridColumnSalesTargetDate.VisibleIndex = 3
        '
        'GridColumnDSalesTargetNote
        '
        Me.GridColumnDSalesTargetNote.Caption = "Note"
        Me.GridColumnDSalesTargetNote.FieldName = "sales_return_note"
        Me.GridColumnDSalesTargetNote.Name = "GridColumnDSalesTargetNote"
        Me.GridColumnDSalesTargetNote.Visible = True
        Me.GridColumnDSalesTargetNote.VisibleIndex = 4
        '
        'GridColumn2
        '
        Me.GridColumn2.Caption = "Status"
        Me.GridColumn2.FieldName = "report_status"
        Me.GridColumn2.Name = "GridColumn2"
        Me.GridColumn2.Visible = True
        Me.GridColumn2.VisibleIndex = 5
        '
        'GridView2
        '
        Me.GridView2.GridControl = Me.GCSalesReturn
        Me.GridView2.Name = "GridView2"
        '
        'GroupControl2
        '
        Me.GroupControl2.CaptionLocation = DevExpress.Utils.Locations.Left
        Me.GroupControl2.Controls.Add(Me.GCItemList)
        Me.GroupControl2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupControl2.Location = New System.Drawing.Point(0, 0)
        Me.GroupControl2.Name = "GroupControl2"
        Me.GroupControl2.Size = New System.Drawing.Size(762, 259)
        Me.GroupControl2.TabIndex = 1
        Me.GroupControl2.Text = "Return Detail"
        '
        'GCItemList
        '
        Me.GCItemList.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCItemList.Location = New System.Drawing.Point(20, 2)
        Me.GCItemList.LookAndFeel.SkinName = "Office 2010 Silver"
        Me.GCItemList.MainView = Me.GVItemList
        Me.GCItemList.Name = "GCItemList"
        Me.GCItemList.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.RepositoryItemSpinEdit1})
        Me.GCItemList.Size = New System.Drawing.Size(740, 255)
        Me.GCItemList.TabIndex = 4
        Me.GCItemList.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVItemList})
        '
        'GVItemList
        '
        Me.GVItemList.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumnNo, Me.GridColumnIdSalesTarget, Me.GridColumnCode, Me.GridColumnName, Me.GridColumnSize, Me.GridColumnUOM, Me.GridColumnQty, Me.GridColumnAllowedQty, Me.GridColumnPrice, Me.GridColumnAmount, Me.GridColumnRemark, Me.GridColumnIdDesign, Me.GridColumnIdProduct, Me.GridColumnIdSample, Me.GridColumnIdSalesOrderDet, Me.GridColumnProductName, Me.GridColumnIdDesignPrice, Me.GridColumnPriceType})
        Me.GVItemList.GridControl = Me.GCItemList
        Me.GVItemList.GroupCount = 1
        Me.GVItemList.GroupSummary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "sales_return_det_qty", Me.GridColumnQty, "{0:n0}"), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "sales_return_qc_det_qty_limit", Me.GridColumnAllowedQty, "{0:n0}")})
        Me.GVItemList.Name = "GVItemList"
        Me.GVItemList.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.[True]
        Me.GVItemList.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.[True]
        Me.GVItemList.OptionsBehavior.ReadOnly = True
        Me.GVItemList.OptionsCustomization.AllowQuickHideColumns = False
        Me.GVItemList.OptionsView.ShowFooter = True
        Me.GVItemList.OptionsView.ShowGroupPanel = False
        Me.GVItemList.SortInfo.AddRange(New DevExpress.XtraGrid.Columns.GridColumnSortInfo() {New DevExpress.XtraGrid.Columns.GridColumnSortInfo(Me.GridColumnName, DevExpress.Data.ColumnSortOrder.Ascending)})
        '
        'GridColumnNo
        '
        Me.GridColumnNo.Caption = "No"
        Me.GridColumnNo.FieldName = "no"
        Me.GridColumnNo.Name = "GridColumnNo"
        Me.GridColumnNo.OptionsColumn.AllowEdit = False
        Me.GridColumnNo.Visible = True
        Me.GridColumnNo.VisibleIndex = 0
        Me.GridColumnNo.Width = 41
        '
        'GridColumnIdSalesTarget
        '
        Me.GridColumnIdSalesTarget.Caption = "ID Sales Target"
        Me.GridColumnIdSalesTarget.FieldName = "id_sales_return_order"
        Me.GridColumnIdSalesTarget.Name = "GridColumnIdSalesTarget"
        Me.GridColumnIdSalesTarget.OptionsColumn.AllowEdit = False
        '
        'GridColumnCode
        '
        Me.GridColumnCode.Caption = "Code"
        Me.GridColumnCode.FieldName = "code"
        Me.GridColumnCode.Name = "GridColumnCode"
        Me.GridColumnCode.OptionsColumn.AllowEdit = False
        Me.GridColumnCode.Visible = True
        Me.GridColumnCode.VisibleIndex = 1
        Me.GridColumnCode.Width = 55
        '
        'GridColumnName
        '
        Me.GridColumnName.Caption = "Name"
        Me.GridColumnName.FieldName = "name"
        Me.GridColumnName.FieldNameSortGroup = "id_design"
        Me.GridColumnName.Name = "GridColumnName"
        Me.GridColumnName.OptionsColumn.AllowEdit = False
        Me.GridColumnName.Width = 103
        '
        'GridColumnSize
        '
        Me.GridColumnSize.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumnSize.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridColumnSize.AppearanceHeader.Options.UseTextOptions = True
        Me.GridColumnSize.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridColumnSize.Caption = "Size"
        Me.GridColumnSize.FieldName = "size"
        Me.GridColumnSize.Name = "GridColumnSize"
        Me.GridColumnSize.OptionsColumn.AllowEdit = False
        Me.GridColumnSize.Visible = True
        Me.GridColumnSize.VisibleIndex = 2
        Me.GridColumnSize.Width = 43
        '
        'GridColumnUOM
        '
        Me.GridColumnUOM.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumnUOM.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridColumnUOM.AppearanceHeader.Options.UseTextOptions = True
        Me.GridColumnUOM.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridColumnUOM.Caption = "UOM"
        Me.GridColumnUOM.FieldName = "uom"
        Me.GridColumnUOM.Name = "GridColumnUOM"
        Me.GridColumnUOM.OptionsColumn.AllowEdit = False
        Me.GridColumnUOM.Width = 71
        '
        'GridColumnQty
        '
        Me.GridColumnQty.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumnQty.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumnQty.AppearanceHeader.Options.UseTextOptions = True
        Me.GridColumnQty.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumnQty.Caption = "Return Qty"
        Me.GridColumnQty.ColumnEdit = Me.RepositoryItemSpinEdit1
        Me.GridColumnQty.DisplayFormat.FormatString = "N0"
        Me.GridColumnQty.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumnQty.FieldName = "sales_return_det_qty"
        Me.GridColumnQty.Name = "GridColumnQty"
        Me.GridColumnQty.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.[False]
        Me.GridColumnQty.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "sales_return_det_qty", "{0:N0}")})
        Me.GridColumnQty.Visible = True
        Me.GridColumnQty.VisibleIndex = 5
        Me.GridColumnQty.Width = 74
        '
        'RepositoryItemSpinEdit1
        '
        Me.RepositoryItemSpinEdit1.AutoHeight = False
        Me.RepositoryItemSpinEdit1.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.RepositoryItemSpinEdit1.Mask.EditMask = "f0"
        Me.RepositoryItemSpinEdit1.MaxValue = New Decimal(New Integer() {-1530494977, 232830, 0, 0})
        Me.RepositoryItemSpinEdit1.Name = "RepositoryItemSpinEdit1"
        '
        'GridColumnAllowedQty
        '
        Me.GridColumnAllowedQty.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumnAllowedQty.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumnAllowedQty.AppearanceHeader.Options.UseTextOptions = True
        Me.GridColumnAllowedQty.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumnAllowedQty.Caption = "Allowed Qty"
        Me.GridColumnAllowedQty.DisplayFormat.FormatString = "{0:N0}"
        Me.GridColumnAllowedQty.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumnAllowedQty.FieldName = "sales_return_qc_det_qty_limit"
        Me.GridColumnAllowedQty.Name = "GridColumnAllowedQty"
        Me.GridColumnAllowedQty.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "sales_return_qc_det_qty_limit", "{0:N0}")})
        Me.GridColumnAllowedQty.Visible = True
        Me.GridColumnAllowedQty.VisibleIndex = 6
        '
        'GridColumnPrice
        '
        Me.GridColumnPrice.Caption = "Price"
        Me.GridColumnPrice.DisplayFormat.FormatString = "{0:n2}"
        Me.GridColumnPrice.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumnPrice.FieldName = "design_price"
        Me.GridColumnPrice.Name = "GridColumnPrice"
        Me.GridColumnPrice.Visible = True
        Me.GridColumnPrice.VisibleIndex = 4
        Me.GridColumnPrice.Width = 89
        '
        'GridColumnAmount
        '
        Me.GridColumnAmount.Caption = "Amount"
        Me.GridColumnAmount.DisplayFormat.FormatString = "{0:n2}"
        Me.GridColumnAmount.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumnAmount.FieldName = "sales_return_det_amount"
        Me.GridColumnAmount.Name = "GridColumnAmount"
        Me.GridColumnAmount.Width = 103
        '
        'GridColumnRemark
        '
        Me.GridColumnRemark.Caption = "Remark"
        Me.GridColumnRemark.FieldName = "sales_return_det_note"
        Me.GridColumnRemark.Name = "GridColumnRemark"
        Me.GridColumnRemark.Width = 155
        '
        'GridColumnIdDesign
        '
        Me.GridColumnIdDesign.Caption = "id design"
        Me.GridColumnIdDesign.FieldName = "id_design"
        Me.GridColumnIdDesign.Name = "GridColumnIdDesign"
        Me.GridColumnIdDesign.OptionsColumn.ShowInCustomizationForm = False
        '
        'GridColumnIdProduct
        '
        Me.GridColumnIdProduct.Caption = "Id Product"
        Me.GridColumnIdProduct.FieldName = "id_product"
        Me.GridColumnIdProduct.Name = "GridColumnIdProduct"
        Me.GridColumnIdProduct.OptionsColumn.ShowInCustomizationForm = False
        '
        'GridColumnIdSample
        '
        Me.GridColumnIdSample.Caption = "Id Sample"
        Me.GridColumnIdSample.FieldName = "id_sample"
        Me.GridColumnIdSample.Name = "GridColumnIdSample"
        Me.GridColumnIdSample.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.[False]
        Me.GridColumnIdSample.OptionsColumn.ShowInCustomizationForm = False
        '
        'GridColumnIdSalesOrderDet
        '
        Me.GridColumnIdSalesOrderDet.Caption = "Id Sales Order Det"
        Me.GridColumnIdSalesOrderDet.FieldName = "id_sales_return_det"
        Me.GridColumnIdSalesOrderDet.Name = "GridColumnIdSalesOrderDet"
        Me.GridColumnIdSalesOrderDet.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.[False]
        Me.GridColumnIdSalesOrderDet.OptionsColumn.ShowInCustomizationForm = False
        '
        'GridColumnProductName
        '
        Me.GridColumnProductName.Caption = "Product Name"
        Me.GridColumnProductName.FieldName = "product_name"
        Me.GridColumnProductName.Name = "GridColumnProductName"
        '
        'GridColumnIdDesignPrice
        '
        Me.GridColumnIdDesignPrice.Caption = "Id Design Price"
        Me.GridColumnIdDesignPrice.FieldName = "id_design_price"
        Me.GridColumnIdDesignPrice.Name = "GridColumnIdDesignPrice"
        '
        'GridColumnPriceType
        '
        Me.GridColumnPriceType.Caption = "Price Type"
        Me.GridColumnPriceType.FieldName = "design_price_type"
        Me.GridColumnPriceType.Name = "GridColumnPriceType"
        Me.GridColumnPriceType.Visible = True
        Me.GridColumnPriceType.VisibleIndex = 3
        '
        'FormSalesReturnQC
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(768, 509)
        Me.Controls.Add(Me.XTCReturnQC)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FormSalesReturnQC"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Return Transfer"
        CType(Me.GCSalesReturnQC, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVSalesReturnQC, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ViewMenu.ResumeLayout(False)
        CType(Me.XTCReturnQC, System.ComponentModel.ISupportInitialize).EndInit()
        Me.XTCReturnQC.ResumeLayout(False)
        Me.XTPReturnQC.ResumeLayout(False)
        Me.XTPReturnList.ResumeLayout(False)
        CType(Me.SplitContainerControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainerControl1.ResumeLayout(False)
        CType(Me.GroupControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupControl1.ResumeLayout(False)
        CType(Me.GCSalesReturn, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVSalesReturn, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GroupControl2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupControl2.ResumeLayout(False)
        CType(Me.GCItemList, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVItemList, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemSpinEdit1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GCSalesReturnQC As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVSalesReturnQC As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumnSalesReturnQCNumber As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnSalesReturnNumber As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnStoreNameFrom As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnCreatedDate As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnQCCategory As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnReportStatus As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnCompTo As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ViewMenu As ContextMenuStrip
    Friend WithEvents SMPrePrint As ToolStripMenuItem
    Friend WithEvents SMPrint As ToolStripMenuItem
    Friend WithEvents GridColumnLastUpdate As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnLastUser As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents XTCReturnQC As DevExpress.XtraTab.XtraTabControl
    Friend WithEvents XTPReturnQC As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents XTPReturnList As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents SplitContainerControl1 As DevExpress.XtraEditors.SplitContainerControl
    Friend WithEvents GroupControl1 As DevExpress.XtraEditors.GroupControl
    Friend WithEvents GroupControl2 As DevExpress.XtraEditors.GroupControl
    Friend WithEvents GCSalesReturn As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVSalesReturn As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumnSalesTargetNumb As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn1 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnCompNameFrom As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnSalesTargetDate As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnDSalesTargetNote As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn2 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridView2 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GCItemList As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVItemList As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumnNo As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnIdSalesTarget As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnCode As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnName As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnSize As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnUOM As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnQty As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents RepositoryItemSpinEdit1 As DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit
    Friend WithEvents GridColumnPrice As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnAmount As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnRemark As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnIdDesign As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnIdProduct As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnIdSample As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnIdSalesOrderDet As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnProductName As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnIdDesignPrice As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnPriceType As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnAllowedQty As DevExpress.XtraGrid.Columns.GridColumn
End Class
