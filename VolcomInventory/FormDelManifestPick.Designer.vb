<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormDelManifestPick
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormDelManifestPick))
        Me.SBAdd = New DevExpress.XtraEditors.SimpleButton()
        Me.PanelControl2 = New DevExpress.XtraEditors.PanelControl()
        Me.SBClose = New DevExpress.XtraEditors.SimpleButton()
        Me.GridColumnDim = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnT = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnL = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnP = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnWeight = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnDestination = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnQty = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnStoreName = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RICESelect = New DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit()
        Me.GVList = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumnIsSelect = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnIdWhAwbDet = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnCreatedDate = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnCollie = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnCombinedNumber = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnDeliverySlip = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnSDO = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnStoreAccount = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnFinal = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnRemark = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GCList = New DevExpress.XtraGrid.GridControl()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.SBView = New DevExpress.XtraEditors.SimpleButton()
        Me.GCCompanyGroup = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GCIdCompGroup = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.SearchLookUpEdit1View = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.SLUECompanyGroup = New DevExpress.XtraEditors.SearchLookUpEdit()
        Me.PanelControl1 = New DevExpress.XtraEditors.PanelControl()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.DateEditCreatedDateTo = New DevExpress.XtraEditors.DateEdit()
        Me.DateEditCreatedDateFrom = New DevExpress.XtraEditors.DateEdit()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.GridColumnIdCompGroup = New DevExpress.XtraGrid.Columns.GridColumn()
        CType(Me.PanelControl2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl2.SuspendLayout()
        CType(Me.RICESelect, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVList, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GCList, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SearchLookUpEdit1View, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SLUECompanyGroup.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl1.SuspendLayout()
        CType(Me.DateEditCreatedDateTo.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DateEditCreatedDateTo.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DateEditCreatedDateFrom.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DateEditCreatedDateFrom.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'SBAdd
        '
        Me.SBAdd.Dock = System.Windows.Forms.DockStyle.Right
        Me.SBAdd.Image = CType(resources.GetObject("SBAdd.Image"), System.Drawing.Image)
        Me.SBAdd.Location = New System.Drawing.Point(692, 2)
        Me.SBAdd.Name = "SBAdd"
        Me.SBAdd.Size = New System.Drawing.Size(90, 45)
        Me.SBAdd.TabIndex = 3
        Me.SBAdd.Text = "Add"
        '
        'PanelControl2
        '
        Me.PanelControl2.Controls.Add(Me.SBClose)
        Me.PanelControl2.Controls.Add(Me.SBAdd)
        Me.PanelControl2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PanelControl2.Location = New System.Drawing.Point(0, 512)
        Me.PanelControl2.Name = "PanelControl2"
        Me.PanelControl2.Size = New System.Drawing.Size(784, 49)
        Me.PanelControl2.TabIndex = 15
        '
        'SBClose
        '
        Me.SBClose.Dock = System.Windows.Forms.DockStyle.Right
        Me.SBClose.Image = CType(resources.GetObject("SBClose.Image"), System.Drawing.Image)
        Me.SBClose.Location = New System.Drawing.Point(608, 2)
        Me.SBClose.Name = "SBClose"
        Me.SBClose.Size = New System.Drawing.Size(84, 45)
        Me.SBClose.TabIndex = 4
        Me.SBClose.Text = "Close"
        '
        'GridColumnDim
        '
        Me.GridColumnDim.Caption = "Dim"
        Me.GridColumnDim.DisplayFormat.FormatString = "N2"
        Me.GridColumnDim.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumnDim.FieldName = "volume"
        Me.GridColumnDim.Name = "GridColumnDim"
        Me.GridColumnDim.OptionsColumn.AllowEdit = False
        Me.GridColumnDim.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.[False]
        Me.GridColumnDim.Visible = True
        Me.GridColumnDim.VisibleIndex = 11
        '
        'GridColumnT
        '
        Me.GridColumnT.Caption = "T"
        Me.GridColumnT.DisplayFormat.FormatString = "N2"
        Me.GridColumnT.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumnT.FieldName = "height"
        Me.GridColumnT.Name = "GridColumnT"
        Me.GridColumnT.OptionsColumn.AllowEdit = False
        Me.GridColumnT.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.[False]
        Me.GridColumnT.Visible = True
        Me.GridColumnT.VisibleIndex = 10
        '
        'GridColumnL
        '
        Me.GridColumnL.Caption = "L"
        Me.GridColumnL.DisplayFormat.FormatString = "N2"
        Me.GridColumnL.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumnL.FieldName = "length"
        Me.GridColumnL.Name = "GridColumnL"
        Me.GridColumnL.OptionsColumn.AllowEdit = False
        Me.GridColumnL.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.[False]
        Me.GridColumnL.Visible = True
        Me.GridColumnL.VisibleIndex = 9
        '
        'GridColumnP
        '
        Me.GridColumnP.Caption = "P"
        Me.GridColumnP.DisplayFormat.FormatString = "N2"
        Me.GridColumnP.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumnP.FieldName = "width"
        Me.GridColumnP.Name = "GridColumnP"
        Me.GridColumnP.OptionsColumn.AllowEdit = False
        Me.GridColumnP.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.[False]
        Me.GridColumnP.Visible = True
        Me.GridColumnP.VisibleIndex = 8
        '
        'GridColumnWeight
        '
        Me.GridColumnWeight.Caption = "Weight"
        Me.GridColumnWeight.DisplayFormat.FormatString = "N2"
        Me.GridColumnWeight.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumnWeight.FieldName = "weight"
        Me.GridColumnWeight.Name = "GridColumnWeight"
        Me.GridColumnWeight.OptionsColumn.AllowEdit = False
        Me.GridColumnWeight.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.[False]
        Me.GridColumnWeight.Visible = True
        Me.GridColumnWeight.VisibleIndex = 7
        '
        'GridColumnDestination
        '
        Me.GridColumnDestination.Caption = "Destination"
        Me.GridColumnDestination.FieldName = "city"
        Me.GridColumnDestination.Name = "GridColumnDestination"
        Me.GridColumnDestination.OptionsColumn.AllowEdit = False
        Me.GridColumnDestination.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.[False]
        Me.GridColumnDestination.Visible = True
        Me.GridColumnDestination.VisibleIndex = 6
        '
        'GridColumnQty
        '
        Me.GridColumnQty.Caption = "Qty"
        Me.GridColumnQty.DisplayFormat.FormatString = "N0"
        Me.GridColumnQty.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumnQty.FieldName = "qty"
        Me.GridColumnQty.Name = "GridColumnQty"
        Me.GridColumnQty.OptionsColumn.AllowEdit = False
        Me.GridColumnQty.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.[False]
        Me.GridColumnQty.Visible = True
        Me.GridColumnQty.VisibleIndex = 5
        '
        'GridColumnStoreName
        '
        Me.GridColumnStoreName.Caption = "Store Name"
        Me.GridColumnStoreName.FieldName = "comp_name"
        Me.GridColumnStoreName.Name = "GridColumnStoreName"
        Me.GridColumnStoreName.OptionsColumn.AllowEdit = False
        Me.GridColumnStoreName.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.[False]
        Me.GridColumnStoreName.Visible = True
        Me.GridColumnStoreName.VisibleIndex = 4
        '
        'RICESelect
        '
        Me.RICESelect.AutoHeight = False
        Me.RICESelect.Name = "RICESelect"
        Me.RICESelect.ValueChecked = "yes"
        Me.RICESelect.ValueUnchecked = "no"
        '
        'GVList
        '
        Me.GVList.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumnIsSelect, Me.GridColumnIdWhAwbDet, Me.GridColumnIdCompGroup, Me.GridColumnCreatedDate, Me.GridColumnCollie, Me.GridColumnCombinedNumber, Me.GridColumnDeliverySlip, Me.GridColumnSDO, Me.GridColumnStoreAccount, Me.GridColumnStoreName, Me.GridColumnQty, Me.GridColumnDestination, Me.GridColumnWeight, Me.GridColumnP, Me.GridColumnL, Me.GridColumnT, Me.GridColumnDim, Me.GridColumnFinal, Me.GridColumnRemark})
        Me.GVList.GridControl = Me.GCList
        Me.GVList.Name = "GVList"
        Me.GVList.OptionsFind.AlwaysVisible = True
        Me.GVList.OptionsView.AllowCellMerge = True
        Me.GVList.OptionsView.ColumnAutoWidth = False
        Me.GVList.OptionsView.ShowFooter = True
        Me.GVList.OptionsView.ShowGroupPanel = False
        '
        'GridColumnIsSelect
        '
        Me.GridColumnIsSelect.Caption = " "
        Me.GridColumnIsSelect.ColumnEdit = Me.RICESelect
        Me.GridColumnIsSelect.FieldName = "is_select"
        Me.GridColumnIsSelect.Name = "GridColumnIsSelect"
        Me.GridColumnIsSelect.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.[False]
        Me.GridColumnIsSelect.Visible = True
        Me.GridColumnIsSelect.VisibleIndex = 0
        '
        'GridColumnIdWhAwbDet
        '
        Me.GridColumnIdWhAwbDet.FieldName = "id_wh_awb_det"
        Me.GridColumnIdWhAwbDet.Name = "GridColumnIdWhAwbDet"
        Me.GridColumnIdWhAwbDet.OptionsColumn.AllowEdit = False
        Me.GridColumnIdWhAwbDet.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.[False]
        '
        'GridColumnCreatedDate
        '
        Me.GridColumnCreatedDate.Caption = "Created Date"
        Me.GridColumnCreatedDate.DisplayFormat.FormatString = "dd MMMM yyyy"
        Me.GridColumnCreatedDate.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.GridColumnCreatedDate.FieldName = "awbill_date"
        Me.GridColumnCreatedDate.Name = "GridColumnCreatedDate"
        Me.GridColumnCreatedDate.OptionsColumn.AllowEdit = False
        Me.GridColumnCreatedDate.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.[False]
        Me.GridColumnCreatedDate.Visible = True
        Me.GridColumnCreatedDate.VisibleIndex = 13
        '
        'GridColumnCollie
        '
        Me.GridColumnCollie.Caption = "Koli"
        Me.GridColumnCollie.FieldName = "id_awbill"
        Me.GridColumnCollie.Name = "GridColumnCollie"
        Me.GridColumnCollie.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.[True]
        Me.GridColumnCollie.Visible = True
        Me.GridColumnCollie.VisibleIndex = 1
        '
        'GridColumnCombinedNumber
        '
        Me.GridColumnCombinedNumber.Caption = "Delivery Slip"
        Me.GridColumnCombinedNumber.FieldName = "combine_number"
        Me.GridColumnCombinedNumber.Name = "GridColumnCombinedNumber"
        Me.GridColumnCombinedNumber.OptionsColumn.AllowEdit = False
        Me.GridColumnCombinedNumber.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.[True]
        '
        'GridColumnDeliverySlip
        '
        Me.GridColumnDeliverySlip.Caption = "Delivery Slip"
        Me.GridColumnDeliverySlip.FieldName = "do_no"
        Me.GridColumnDeliverySlip.Name = "GridColumnDeliverySlip"
        Me.GridColumnDeliverySlip.OptionsColumn.AllowEdit = False
        Me.GridColumnDeliverySlip.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.[False]
        Me.GridColumnDeliverySlip.Visible = True
        Me.GridColumnDeliverySlip.VisibleIndex = 2
        '
        'GridColumnSDO
        '
        Me.GridColumnSDO.Caption = "No. SDO"
        Me.GridColumnSDO.FieldName = "pl_sales_order_del_number"
        Me.GridColumnSDO.Name = "GridColumnSDO"
        Me.GridColumnSDO.OptionsColumn.AllowEdit = False
        Me.GridColumnSDO.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.[False]
        '
        'GridColumnStoreAccount
        '
        Me.GridColumnStoreAccount.Caption = "Store Account"
        Me.GridColumnStoreAccount.FieldName = "comp_number"
        Me.GridColumnStoreAccount.Name = "GridColumnStoreAccount"
        Me.GridColumnStoreAccount.OptionsColumn.AllowEdit = False
        Me.GridColumnStoreAccount.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.[False]
        Me.GridColumnStoreAccount.Visible = True
        Me.GridColumnStoreAccount.VisibleIndex = 3
        Me.GridColumnStoreAccount.Width = 78
        '
        'GridColumnFinal
        '
        Me.GridColumnFinal.Caption = "Final Weight"
        Me.GridColumnFinal.DisplayFormat.FormatString = "N2"
        Me.GridColumnFinal.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumnFinal.FieldName = "c_weight"
        Me.GridColumnFinal.Name = "GridColumnFinal"
        Me.GridColumnFinal.OptionsColumn.AllowEdit = False
        Me.GridColumnFinal.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.[False]
        Me.GridColumnFinal.Visible = True
        Me.GridColumnFinal.VisibleIndex = 12
        '
        'GridColumnRemark
        '
        Me.GridColumnRemark.Caption = "Remark"
        Me.GridColumnRemark.Name = "GridColumnRemark"
        Me.GridColumnRemark.OptionsColumn.AllowEdit = False
        Me.GridColumnRemark.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.[False]
        '
        'GCList
        '
        Me.GCList.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCList.Location = New System.Drawing.Point(0, 43)
        Me.GCList.MainView = Me.GVList
        Me.GCList.Name = "GCList"
        Me.GCList.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.RICESelect})
        Me.GCList.Size = New System.Drawing.Size(784, 469)
        Me.GCList.TabIndex = 14
        Me.GCList.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVList})
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(12, 15)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(65, 13)
        Me.Label2.TabIndex = 16
        Me.Label2.Text = "Store Group"
        '
        'SBView
        '
        Me.SBView.Location = New System.Drawing.Point(656, 10)
        Me.SBView.Name = "SBView"
        Me.SBView.Size = New System.Drawing.Size(75, 23)
        Me.SBView.TabIndex = 15
        Me.SBView.Text = "View"
        '
        'GCCompanyGroup
        '
        Me.GCCompanyGroup.Caption = "Company Group"
        Me.GCCompanyGroup.FieldName = "comp_group"
        Me.GCCompanyGroup.Name = "GCCompanyGroup"
        Me.GCCompanyGroup.Visible = True
        Me.GCCompanyGroup.VisibleIndex = 0
        '
        'GCIdCompGroup
        '
        Me.GCIdCompGroup.FieldName = "id_comp_group"
        Me.GCIdCompGroup.Name = "GCIdCompGroup"
        '
        'SearchLookUpEdit1View
        '
        Me.SearchLookUpEdit1View.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GCIdCompGroup, Me.GCCompanyGroup})
        Me.SearchLookUpEdit1View.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
        Me.SearchLookUpEdit1View.Name = "SearchLookUpEdit1View"
        Me.SearchLookUpEdit1View.OptionsSelection.EnableAppearanceFocusedCell = False
        Me.SearchLookUpEdit1View.OptionsView.ShowGroupPanel = False
        '
        'SLUECompanyGroup
        '
        Me.SLUECompanyGroup.Location = New System.Drawing.Point(83, 12)
        Me.SLUECompanyGroup.Name = "SLUECompanyGroup"
        Me.SLUECompanyGroup.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.SLUECompanyGroup.Properties.View = Me.SearchLookUpEdit1View
        Me.SLUECompanyGroup.Size = New System.Drawing.Size(150, 20)
        Me.SLUECompanyGroup.TabIndex = 17
        '
        'PanelControl1
        '
        Me.PanelControl1.Controls.Add(Me.Label3)
        Me.PanelControl1.Controls.Add(Me.DateEditCreatedDateTo)
        Me.PanelControl1.Controls.Add(Me.DateEditCreatedDateFrom)
        Me.PanelControl1.Controls.Add(Me.Label1)
        Me.PanelControl1.Controls.Add(Me.SLUECompanyGroup)
        Me.PanelControl1.Controls.Add(Me.Label2)
        Me.PanelControl1.Controls.Add(Me.SBView)
        Me.PanelControl1.Dock = System.Windows.Forms.DockStyle.Top
        Me.PanelControl1.Location = New System.Drawing.Point(0, 0)
        Me.PanelControl1.Name = "PanelControl1"
        Me.PanelControl1.Size = New System.Drawing.Size(784, 43)
        Me.PanelControl1.TabIndex = 13
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(483, 15)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(11, 13)
        Me.Label3.TabIndex = 21
        Me.Label3.Text = "-"
        '
        'DateEditCreatedDateTo
        '
        Me.DateEditCreatedDateTo.EditValue = Nothing
        Me.DateEditCreatedDateTo.Location = New System.Drawing.Point(500, 12)
        Me.DateEditCreatedDateTo.Name = "DateEditCreatedDateTo"
        Me.DateEditCreatedDateTo.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.DateEditCreatedDateTo.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.DateEditCreatedDateTo.Properties.DisplayFormat.FormatString = "dd MMMM yyyy"
        Me.DateEditCreatedDateTo.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.DateEditCreatedDateTo.Properties.EditFormat.FormatString = "dd MMMM yyyy"
        Me.DateEditCreatedDateTo.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.DateEditCreatedDateTo.Properties.Mask.EditMask = "dd MMMM yyyy"
        Me.DateEditCreatedDateTo.Properties.Mask.UseMaskAsDisplayFormat = True
        Me.DateEditCreatedDateTo.Size = New System.Drawing.Size(150, 20)
        Me.DateEditCreatedDateTo.TabIndex = 20
        '
        'DateEditCreatedDateFrom
        '
        Me.DateEditCreatedDateFrom.EditValue = Nothing
        Me.DateEditCreatedDateFrom.Location = New System.Drawing.Point(327, 12)
        Me.DateEditCreatedDateFrom.Name = "DateEditCreatedDateFrom"
        Me.DateEditCreatedDateFrom.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.DateEditCreatedDateFrom.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.DateEditCreatedDateFrom.Properties.DisplayFormat.FormatString = "dd MMMM yyyy"
        Me.DateEditCreatedDateFrom.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.DateEditCreatedDateFrom.Properties.EditFormat.FormatString = "dd MMMM yyyy"
        Me.DateEditCreatedDateFrom.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.DateEditCreatedDateFrom.Properties.Mask.EditMask = "dd MMMM yyyy"
        Me.DateEditCreatedDateFrom.Properties.Mask.UseMaskAsDisplayFormat = True
        Me.DateEditCreatedDateFrom.Size = New System.Drawing.Size(150, 20)
        Me.DateEditCreatedDateFrom.TabIndex = 19
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(249, 15)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(72, 13)
        Me.Label1.TabIndex = 18
        Me.Label1.Text = "Created Date"
        '
        'GridColumnIdCompGroup
        '
        Me.GridColumnIdCompGroup.FieldName = "id_comp_group"
        Me.GridColumnIdCompGroup.Name = "GridColumnIdCompGroup"
        '
        'FormDelManifestPick
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(784, 561)
        Me.Controls.Add(Me.GCList)
        Me.Controls.Add(Me.PanelControl2)
        Me.Controls.Add(Me.PanelControl1)
        Me.Name = "FormDelManifestPick"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Outbound Delivery Manifest Pick"
        CType(Me.PanelControl2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl2.ResumeLayout(False)
        CType(Me.RICESelect, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVList, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GCList, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SearchLookUpEdit1View, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SLUECompanyGroup.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl1.ResumeLayout(False)
        Me.PanelControl1.PerformLayout()
        CType(Me.DateEditCreatedDateTo.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DateEditCreatedDateTo.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DateEditCreatedDateFrom.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DateEditCreatedDateFrom.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents SBAdd As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents PanelControl2 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents SBClose As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents GridColumnDim As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnT As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnL As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnP As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnWeight As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnDestination As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnQty As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnStoreName As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents RICESelect As DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit
    Friend WithEvents GVList As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GCList As DevExpress.XtraGrid.GridControl
    Friend WithEvents Label2 As Label
    Friend WithEvents SBView As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents GCCompanyGroup As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GCIdCompGroup As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents SearchLookUpEdit1View As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents SLUECompanyGroup As DevExpress.XtraEditors.SearchLookUpEdit
    Friend WithEvents PanelControl1 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents GridColumnIdWhAwbDet As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnDeliverySlip As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnSDO As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnFinal As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnRemark As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnIsSelect As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnStoreAccount As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents DateEditCreatedDateFrom As DevExpress.XtraEditors.DateEdit
    Friend WithEvents Label1 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents DateEditCreatedDateTo As DevExpress.XtraEditors.DateEdit
    Friend WithEvents GridColumnCreatedDate As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnCollie As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnCombinedNumber As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnIdCompGroup As DevExpress.XtraGrid.Columns.GridColumn
End Class
