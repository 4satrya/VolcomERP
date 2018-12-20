<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormItemDelReqDet
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormItemDelReqDet))
        Me.GCData = New DevExpress.XtraGrid.GridControl()
        Me.GVData = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumnNo = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnITemName = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnIdItemn = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnQty = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnRemark = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnStt = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnFinalReason = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnSattus = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnQtyDel = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnUom = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnIdPrepareStatus = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnAction = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RepositoryItemCheckEdit1 = New DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit()
        Me.GridColumnDiffQQty = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.PanelControlNav = New DevExpress.XtraEditors.PanelControl()
        Me.BtnCloseRequest = New DevExpress.XtraEditors.SimpleButton()
        Me.CESelectAll = New DevExpress.XtraEditors.CheckEdit()
        Me.XTCRequest = New DevExpress.XtraTab.XtraTabControl()
        Me.XTPSummary = New DevExpress.XtraTab.XtraTabPage()
        Me.XTPDetail = New DevExpress.XtraTab.XtraTabPage()
        Me.GCDetail = New DevExpress.XtraGrid.GridControl()
        Me.GVDetail = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumn1 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn2 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn3 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn4 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn5 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn6 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn9 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn10 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn13 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnStoreCode = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnStonreName = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RepositoryItemCheckEdit2 = New DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit()
        CType(Me.GCData, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVData, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemCheckEdit1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PanelControlNav, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControlNav.SuspendLayout()
        CType(Me.CESelectAll.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.XTCRequest, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.XTCRequest.SuspendLayout()
        Me.XTPSummary.SuspendLayout()
        Me.XTPDetail.SuspendLayout()
        CType(Me.GCDetail, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVDetail, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemCheckEdit2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GCData
        '
        Me.GCData.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCData.Location = New System.Drawing.Point(0, 0)
        Me.GCData.MainView = Me.GVData
        Me.GCData.Name = "GCData"
        Me.GCData.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.RepositoryItemCheckEdit1})
        Me.GCData.Size = New System.Drawing.Size(778, 337)
        Me.GCData.TabIndex = 16
        Me.GCData.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVData})
        '
        'GVData
        '
        Me.GVData.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumnNo, Me.GridColumnITemName, Me.GridColumnIdItemn, Me.GridColumnQty, Me.GridColumnRemark, Me.GridColumnStt, Me.GridColumnFinalReason, Me.GridColumnSattus, Me.GridColumnQtyDel, Me.GridColumnUom, Me.GridColumnIdPrepareStatus, Me.GridColumnAction, Me.GridColumnDiffQQty})
        Me.GVData.GridControl = Me.GCData
        Me.GVData.Name = "GVData"
        Me.GVData.OptionsBehavior.AutoExpandAllGroups = True
        Me.GVData.OptionsView.ShowFooter = True
        Me.GVData.OptionsView.ShowGroupPanel = False
        '
        'GridColumnNo
        '
        Me.GridColumnNo.Caption = "No"
        Me.GridColumnNo.FieldName = "no"
        Me.GridColumnNo.Name = "GridColumnNo"
        Me.GridColumnNo.OptionsColumn.AllowEdit = False
        Me.GridColumnNo.Visible = True
        Me.GridColumnNo.VisibleIndex = 0
        Me.GridColumnNo.Width = 67
        '
        'GridColumnITemName
        '
        Me.GridColumnITemName.Caption = "Item"
        Me.GridColumnITemName.FieldName = "item_desc"
        Me.GridColumnITemName.Name = "GridColumnITemName"
        Me.GridColumnITemName.OptionsColumn.AllowEdit = False
        Me.GridColumnITemName.Visible = True
        Me.GridColumnITemName.VisibleIndex = 1
        Me.GridColumnITemName.Width = 419
        '
        'GridColumnIdItemn
        '
        Me.GridColumnIdItemn.Caption = "Id Item"
        Me.GridColumnIdItemn.FieldName = "id_item"
        Me.GridColumnIdItemn.Name = "GridColumnIdItemn"
        Me.GridColumnIdItemn.OptionsColumn.AllowEdit = False
        '
        'GridColumnQty
        '
        Me.GridColumnQty.Caption = "Requested Qty"
        Me.GridColumnQty.DisplayFormat.FormatString = "N2"
        Me.GridColumnQty.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumnQty.FieldName = "qty"
        Me.GridColumnQty.Name = "GridColumnQty"
        Me.GridColumnQty.OptionsColumn.AllowEdit = False
        Me.GridColumnQty.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "qty", "{0:N2}")})
        Me.GridColumnQty.Visible = True
        Me.GridColumnQty.VisibleIndex = 3
        Me.GridColumnQty.Width = 101
        '
        'GridColumnRemark
        '
        Me.GridColumnRemark.Caption = "Request Note"
        Me.GridColumnRemark.FieldName = "remark"
        Me.GridColumnRemark.Name = "GridColumnRemark"
        Me.GridColumnRemark.OptionsColumn.AllowEdit = False
        Me.GridColumnRemark.Visible = True
        Me.GridColumnRemark.VisibleIndex = 6
        Me.GridColumnRemark.Width = 307
        '
        'GridColumnStt
        '
        Me.GridColumnStt.Caption = "Status"
        Me.GridColumnStt.FieldName = "stt"
        Me.GridColumnStt.Name = "GridColumnStt"
        Me.GridColumnStt.OptionsColumn.AllowEdit = False
        '
        'GridColumnFinalReason
        '
        Me.GridColumnFinalReason.Caption = "Note"
        Me.GridColumnFinalReason.FieldName = "final_reason"
        Me.GridColumnFinalReason.Name = "GridColumnFinalReason"
        Me.GridColumnFinalReason.OptionsColumn.AllowEdit = False
        Me.GridColumnFinalReason.Visible = True
        Me.GridColumnFinalReason.VisibleIndex = 8
        Me.GridColumnFinalReason.Width = 233
        '
        'GridColumnSattus
        '
        Me.GridColumnSattus.Caption = "Request Status"
        Me.GridColumnSattus.FieldName = "prepare_status"
        Me.GridColumnSattus.Name = "GridColumnSattus"
        Me.GridColumnSattus.OptionsColumn.AllowEdit = False
        Me.GridColumnSattus.Visible = True
        Me.GridColumnSattus.VisibleIndex = 7
        Me.GridColumnSattus.Width = 253
        '
        'GridColumnQtyDel
        '
        Me.GridColumnQtyDel.Caption = "Delivered Qty"
        Me.GridColumnQtyDel.DisplayFormat.FormatString = "N2"
        Me.GridColumnQtyDel.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumnQtyDel.FieldName = "qty_del"
        Me.GridColumnQtyDel.Name = "GridColumnQtyDel"
        Me.GridColumnQtyDel.OptionsColumn.AllowEdit = False
        Me.GridColumnQtyDel.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "qty_del", "{0:N2}")})
        Me.GridColumnQtyDel.Visible = True
        Me.GridColumnQtyDel.VisibleIndex = 4
        Me.GridColumnQtyDel.Width = 91
        '
        'GridColumnUom
        '
        Me.GridColumnUom.Caption = "UOM"
        Me.GridColumnUom.FieldName = "uom"
        Me.GridColumnUom.Name = "GridColumnUom"
        Me.GridColumnUom.OptionsColumn.AllowEdit = False
        Me.GridColumnUom.Visible = True
        Me.GridColumnUom.VisibleIndex = 2
        Me.GridColumnUom.Width = 69
        '
        'GridColumnIdPrepareStatus
        '
        Me.GridColumnIdPrepareStatus.Caption = "Id Prepare Status"
        Me.GridColumnIdPrepareStatus.FieldName = "id_prepare_status"
        Me.GridColumnIdPrepareStatus.Name = "GridColumnIdPrepareStatus"
        Me.GridColumnIdPrepareStatus.OptionsColumn.AllowEdit = False
        '
        'GridColumnAction
        '
        Me.GridColumnAction.AppearanceHeader.Options.UseTextOptions = True
        Me.GridColumnAction.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridColumnAction.Caption = "Select"
        Me.GridColumnAction.ColumnEdit = Me.RepositoryItemCheckEdit1
        Me.GridColumnAction.FieldName = "is_select"
        Me.GridColumnAction.Name = "GridColumnAction"
        Me.GridColumnAction.Visible = True
        Me.GridColumnAction.VisibleIndex = 9
        Me.GridColumnAction.Width = 92
        '
        'RepositoryItemCheckEdit1
        '
        Me.RepositoryItemCheckEdit1.AutoHeight = False
        Me.RepositoryItemCheckEdit1.Name = "RepositoryItemCheckEdit1"
        Me.RepositoryItemCheckEdit1.ValueChecked = "Yes"
        Me.RepositoryItemCheckEdit1.ValueUnchecked = "No"
        '
        'GridColumnDiffQQty
        '
        Me.GridColumnDiffQQty.Caption = "Diff Qty"
        Me.GridColumnDiffQQty.DisplayFormat.FormatString = "N2"
        Me.GridColumnDiffQQty.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumnDiffQQty.FieldName = "diff_qty"
        Me.GridColumnDiffQQty.Name = "GridColumnDiffQQty"
        Me.GridColumnDiffQQty.OptionsColumn.AllowEdit = False
        Me.GridColumnDiffQQty.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "diff_qty", "{0:N2}")})
        Me.GridColumnDiffQQty.UnboundExpression = "[qty] - [qty_del]"
        Me.GridColumnDiffQQty.UnboundType = DevExpress.Data.UnboundColumnType.[Decimal]
        Me.GridColumnDiffQQty.Visible = True
        Me.GridColumnDiffQQty.VisibleIndex = 5
        '
        'PanelControlNav
        '
        Me.PanelControlNav.Controls.Add(Me.BtnCloseRequest)
        Me.PanelControlNav.Controls.Add(Me.CESelectAll)
        Me.PanelControlNav.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PanelControlNav.Location = New System.Drawing.Point(0, 337)
        Me.PanelControlNav.Name = "PanelControlNav"
        Me.PanelControlNav.Size = New System.Drawing.Size(778, 46)
        Me.PanelControlNav.TabIndex = 17
        '
        'BtnCloseRequest
        '
        Me.BtnCloseRequest.Dock = System.Windows.Forms.DockStyle.Right
        Me.BtnCloseRequest.Image = CType(resources.GetObject("BtnCloseRequest.Image"), System.Drawing.Image)
        Me.BtnCloseRequest.Location = New System.Drawing.Point(662, 2)
        Me.BtnCloseRequest.Name = "BtnCloseRequest"
        Me.BtnCloseRequest.Size = New System.Drawing.Size(114, 42)
        Me.BtnCloseRequest.TabIndex = 1
        Me.BtnCloseRequest.Text = "Close Request"
        '
        'CESelectAll
        '
        Me.CESelectAll.Location = New System.Drawing.Point(595, 15)
        Me.CESelectAll.Name = "CESelectAll"
        Me.CESelectAll.Properties.Caption = "Select All"
        Me.CESelectAll.Size = New System.Drawing.Size(67, 19)
        Me.CESelectAll.TabIndex = 0
        '
        'XTCRequest
        '
        Me.XTCRequest.Dock = System.Windows.Forms.DockStyle.Fill
        Me.XTCRequest.Location = New System.Drawing.Point(0, 0)
        Me.XTCRequest.Name = "XTCRequest"
        Me.XTCRequest.SelectedTabPage = Me.XTPSummary
        Me.XTCRequest.Size = New System.Drawing.Size(784, 411)
        Me.XTCRequest.TabIndex = 18
        Me.XTCRequest.TabPages.AddRange(New DevExpress.XtraTab.XtraTabPage() {Me.XTPSummary, Me.XTPDetail})
        '
        'XTPSummary
        '
        Me.XTPSummary.Controls.Add(Me.GCData)
        Me.XTPSummary.Controls.Add(Me.PanelControlNav)
        Me.XTPSummary.Name = "XTPSummary"
        Me.XTPSummary.Size = New System.Drawing.Size(778, 383)
        Me.XTPSummary.Text = "Summary"
        '
        'XTPDetail
        '
        Me.XTPDetail.Controls.Add(Me.GCDetail)
        Me.XTPDetail.Name = "XTPDetail"
        Me.XTPDetail.PageVisible = False
        Me.XTPDetail.Size = New System.Drawing.Size(778, 383)
        Me.XTPDetail.Text = "Detail"
        '
        'GCDetail
        '
        Me.GCDetail.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCDetail.Location = New System.Drawing.Point(0, 0)
        Me.GCDetail.MainView = Me.GVDetail
        Me.GCDetail.Name = "GCDetail"
        Me.GCDetail.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.RepositoryItemCheckEdit2})
        Me.GCDetail.Size = New System.Drawing.Size(778, 383)
        Me.GCDetail.TabIndex = 17
        Me.GCDetail.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVDetail})
        '
        'GVDetail
        '
        Me.GVDetail.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumn1, Me.GridColumn2, Me.GridColumn3, Me.GridColumn4, Me.GridColumn5, Me.GridColumn6, Me.GridColumn9, Me.GridColumn10, Me.GridColumn13, Me.GridColumnStoreCode, Me.GridColumnStonreName})
        Me.GVDetail.GridControl = Me.GCDetail
        Me.GVDetail.Name = "GVDetail"
        Me.GVDetail.OptionsBehavior.AutoExpandAllGroups = True
        Me.GVDetail.OptionsView.ShowFooter = True
        Me.GVDetail.OptionsView.ShowGroupPanel = False
        '
        'GridColumn1
        '
        Me.GridColumn1.Caption = "No"
        Me.GridColumn1.FieldName = "no"
        Me.GridColumn1.Name = "GridColumn1"
        Me.GridColumn1.OptionsColumn.AllowEdit = False
        Me.GridColumn1.Visible = True
        Me.GridColumn1.VisibleIndex = 0
        Me.GridColumn1.Width = 30
        '
        'GridColumn2
        '
        Me.GridColumn2.Caption = "Item"
        Me.GridColumn2.FieldName = "item_desc"
        Me.GridColumn2.Name = "GridColumn2"
        Me.GridColumn2.OptionsColumn.AllowEdit = False
        Me.GridColumn2.Visible = True
        Me.GridColumn2.VisibleIndex = 3
        Me.GridColumn2.Width = 164
        '
        'GridColumn3
        '
        Me.GridColumn3.Caption = "Id Item"
        Me.GridColumn3.FieldName = "id_item"
        Me.GridColumn3.Name = "GridColumn3"
        Me.GridColumn3.OptionsColumn.AllowEdit = False
        '
        'GridColumn4
        '
        Me.GridColumn4.Caption = "Requested Qty"
        Me.GridColumn4.DisplayFormat.FormatString = "N2"
        Me.GridColumn4.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumn4.FieldName = "qty"
        Me.GridColumn4.Name = "GridColumn4"
        Me.GridColumn4.OptionsColumn.AllowEdit = False
        Me.GridColumn4.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "qty", "{0:N2}")})
        Me.GridColumn4.Visible = True
        Me.GridColumn4.VisibleIndex = 5
        Me.GridColumn4.Width = 38
        '
        'GridColumn5
        '
        Me.GridColumn5.Caption = "Request Note"
        Me.GridColumn5.FieldName = "remark"
        Me.GridColumn5.Name = "GridColumn5"
        Me.GridColumn5.OptionsColumn.AllowEdit = False
        Me.GridColumn5.Visible = True
        Me.GridColumn5.VisibleIndex = 8
        Me.GridColumn5.Width = 119
        '
        'GridColumn6
        '
        Me.GridColumn6.Caption = "Status"
        Me.GridColumn6.FieldName = "stt"
        Me.GridColumn6.Name = "GridColumn6"
        Me.GridColumn6.OptionsColumn.AllowEdit = False
        '
        'GridColumn9
        '
        Me.GridColumn9.Caption = "Delivered Qty"
        Me.GridColumn9.DisplayFormat.FormatString = "N2"
        Me.GridColumn9.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumn9.FieldName = "qty_del"
        Me.GridColumn9.Name = "GridColumn9"
        Me.GridColumn9.OptionsColumn.AllowEdit = False
        Me.GridColumn9.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "qty_del", "{0:N2}")})
        Me.GridColumn9.Visible = True
        Me.GridColumn9.VisibleIndex = 6
        Me.GridColumn9.Width = 34
        '
        'GridColumn10
        '
        Me.GridColumn10.Caption = "UOM"
        Me.GridColumn10.FieldName = "uom"
        Me.GridColumn10.Name = "GridColumn10"
        Me.GridColumn10.OptionsColumn.AllowEdit = False
        Me.GridColumn10.Visible = True
        Me.GridColumn10.VisibleIndex = 4
        Me.GridColumn10.Width = 25
        '
        'GridColumn13
        '
        Me.GridColumn13.Caption = "Diff Qty"
        Me.GridColumn13.DisplayFormat.FormatString = "N2"
        Me.GridColumn13.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumn13.FieldName = "diff_qty"
        Me.GridColumn13.Name = "GridColumn13"
        Me.GridColumn13.OptionsColumn.AllowEdit = False
        Me.GridColumn13.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "diff_qty", "{0:N2}")})
        Me.GridColumn13.UnboundExpression = "[qty] - [qty_del]"
        Me.GridColumn13.UnboundType = DevExpress.Data.UnboundColumnType.[Decimal]
        Me.GridColumn13.Visible = True
        Me.GridColumn13.VisibleIndex = 7
        Me.GridColumn13.Width = 28
        '
        'GridColumnStoreCode
        '
        Me.GridColumnStoreCode.Caption = "Store Code"
        Me.GridColumnStoreCode.FieldName = "comp_number"
        Me.GridColumnStoreCode.Name = "GridColumnStoreCode"
        Me.GridColumnStoreCode.Visible = True
        Me.GridColumnStoreCode.VisibleIndex = 1
        Me.GridColumnStoreCode.Width = 67
        '
        'GridColumnStonreName
        '
        Me.GridColumnStonreName.Caption = "Store"
        Me.GridColumnStonreName.FieldName = "comp_name"
        Me.GridColumnStonreName.Name = "GridColumnStonreName"
        Me.GridColumnStonreName.Visible = True
        Me.GridColumnStonreName.VisibleIndex = 2
        Me.GridColumnStonreName.Width = 105
        '
        'RepositoryItemCheckEdit2
        '
        Me.RepositoryItemCheckEdit2.AutoHeight = False
        Me.RepositoryItemCheckEdit2.Name = "RepositoryItemCheckEdit2"
        Me.RepositoryItemCheckEdit2.ValueChecked = "Yes"
        Me.RepositoryItemCheckEdit2.ValueUnchecked = "No"
        '
        'FormItemDelReqDet
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(784, 411)
        Me.Controls.Add(Me.XTCRequest)
        Me.MinimizeBox = False
        Me.Name = "FormItemDelReqDet"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Detail Request"
        CType(Me.GCData, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVData, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemCheckEdit1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PanelControlNav, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControlNav.ResumeLayout(False)
        CType(Me.CESelectAll.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.XTCRequest, System.ComponentModel.ISupportInitialize).EndInit()
        Me.XTCRequest.ResumeLayout(False)
        Me.XTPSummary.ResumeLayout(False)
        Me.XTPDetail.ResumeLayout(False)
        CType(Me.GCDetail, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVDetail, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemCheckEdit2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents GCData As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVData As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumnNo As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnITemName As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnIdItemn As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnQty As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnRemark As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnStt As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnFinalReason As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnSattus As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnQtyDel As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnUom As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnIdPrepareStatus As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnAction As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents RepositoryItemCheckEdit1 As DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit
    Friend WithEvents PanelControlNav As DevExpress.XtraEditors.PanelControl
    Friend WithEvents BtnCloseRequest As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents CESelectAll As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents GridColumnDiffQQty As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents XTCRequest As DevExpress.XtraTab.XtraTabControl
    Friend WithEvents XTPSummary As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents XTPDetail As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents GCDetail As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVDetail As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumn1 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn2 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn3 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn4 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn5 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn6 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn9 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn10 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn13 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnStoreCode As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnStonreName As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents RepositoryItemCheckEdit2 As DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit
End Class
