﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
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
        Me.GridColumnDeliverySlip = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnSDO = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnFinal = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnRemark = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GCList = New DevExpress.XtraGrid.GridControl()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.SBView = New DevExpress.XtraEditors.SimpleButton()
        Me.GCCompany = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GCIdComp = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.SearchLookUpEdit1View = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.SLUECompany = New DevExpress.XtraEditors.SearchLookUpEdit()
        Me.PanelControl1 = New DevExpress.XtraEditors.PanelControl()
        Me.GridColumnStoreAccount = New DevExpress.XtraGrid.Columns.GridColumn()
        CType(Me.PanelControl2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl2.SuspendLayout()
        CType(Me.RICESelect, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVList, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GCList, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SearchLookUpEdit1View, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SLUECompany.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl1.SuspendLayout()
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
        Me.GridColumnDim.Visible = True
        Me.GridColumnDim.VisibleIndex = 12
        '
        'GridColumnT
        '
        Me.GridColumnT.Caption = "T"
        Me.GridColumnT.DisplayFormat.FormatString = "N2"
        Me.GridColumnT.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumnT.FieldName = "height"
        Me.GridColumnT.Name = "GridColumnT"
        Me.GridColumnT.OptionsColumn.AllowEdit = False
        Me.GridColumnT.Visible = True
        Me.GridColumnT.VisibleIndex = 11
        '
        'GridColumnL
        '
        Me.GridColumnL.Caption = "L"
        Me.GridColumnL.DisplayFormat.FormatString = "N2"
        Me.GridColumnL.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumnL.FieldName = "length"
        Me.GridColumnL.Name = "GridColumnL"
        Me.GridColumnL.OptionsColumn.AllowEdit = False
        Me.GridColumnL.Visible = True
        Me.GridColumnL.VisibleIndex = 10
        '
        'GridColumnP
        '
        Me.GridColumnP.Caption = "P"
        Me.GridColumnP.DisplayFormat.FormatString = "N2"
        Me.GridColumnP.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumnP.FieldName = "width"
        Me.GridColumnP.Name = "GridColumnP"
        Me.GridColumnP.OptionsColumn.AllowEdit = False
        Me.GridColumnP.Visible = True
        Me.GridColumnP.VisibleIndex = 9
        '
        'GridColumnWeight
        '
        Me.GridColumnWeight.Caption = "Weight"
        Me.GridColumnWeight.DisplayFormat.FormatString = "N2"
        Me.GridColumnWeight.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumnWeight.FieldName = "weight"
        Me.GridColumnWeight.Name = "GridColumnWeight"
        Me.GridColumnWeight.OptionsColumn.AllowEdit = False
        Me.GridColumnWeight.Visible = True
        Me.GridColumnWeight.VisibleIndex = 8
        '
        'GridColumnDestination
        '
        Me.GridColumnDestination.Caption = "Destination"
        Me.GridColumnDestination.FieldName = "city"
        Me.GridColumnDestination.Name = "GridColumnDestination"
        Me.GridColumnDestination.OptionsColumn.AllowEdit = False
        Me.GridColumnDestination.Visible = True
        Me.GridColumnDestination.VisibleIndex = 7
        '
        'GridColumnQty
        '
        Me.GridColumnQty.Caption = "Qty"
        Me.GridColumnQty.DisplayFormat.FormatString = "N0"
        Me.GridColumnQty.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumnQty.FieldName = "qty"
        Me.GridColumnQty.Name = "GridColumnQty"
        Me.GridColumnQty.OptionsColumn.AllowEdit = False
        Me.GridColumnQty.Visible = True
        Me.GridColumnQty.VisibleIndex = 6
        '
        'GridColumnStoreName
        '
        Me.GridColumnStoreName.Caption = "Store Name"
        Me.GridColumnStoreName.FieldName = "comp_name"
        Me.GridColumnStoreName.Name = "GridColumnStoreName"
        Me.GridColumnStoreName.OptionsColumn.AllowEdit = False
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
        Me.GVList.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumnIsSelect, Me.GridColumnIdWhAwbDet, Me.GridColumnDeliverySlip, Me.GridColumnSDO, Me.GridColumnStoreAccount, Me.GridColumnStoreName, Me.GridColumnQty, Me.GridColumnDestination, Me.GridColumnWeight, Me.GridColumnP, Me.GridColumnL, Me.GridColumnT, Me.GridColumnDim, Me.GridColumnFinal, Me.GridColumnRemark})
        Me.GVList.GridControl = Me.GCList
        Me.GVList.Name = "GVList"
        Me.GVList.OptionsFind.AlwaysVisible = True
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
        Me.GridColumnIsSelect.Visible = True
        Me.GridColumnIsSelect.VisibleIndex = 0
        '
        'GridColumnIdWhAwbDet
        '
        Me.GridColumnIdWhAwbDet.FieldName = "id_wh_awb_det"
        Me.GridColumnIdWhAwbDet.Name = "GridColumnIdWhAwbDet"
        Me.GridColumnIdWhAwbDet.OptionsColumn.AllowEdit = False
        '
        'GridColumnDeliverySlip
        '
        Me.GridColumnDeliverySlip.Caption = "Delivery Slip"
        Me.GridColumnDeliverySlip.FieldName = "do_no"
        Me.GridColumnDeliverySlip.Name = "GridColumnDeliverySlip"
        Me.GridColumnDeliverySlip.OptionsColumn.AllowEdit = False
        Me.GridColumnDeliverySlip.Visible = True
        Me.GridColumnDeliverySlip.VisibleIndex = 2
        '
        'GridColumnSDO
        '
        Me.GridColumnSDO.Caption = "No. SDO"
        Me.GridColumnSDO.FieldName = "pl_sales_order_del_number"
        Me.GridColumnSDO.Name = "GridColumnSDO"
        Me.GridColumnSDO.OptionsColumn.AllowEdit = False
        Me.GridColumnSDO.Visible = True
        Me.GridColumnSDO.VisibleIndex = 3
        '
        'GridColumnFinal
        '
        Me.GridColumnFinal.Caption = "Final Weight"
        Me.GridColumnFinal.DisplayFormat.FormatString = "N2"
        Me.GridColumnFinal.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumnFinal.FieldName = "c_weight"
        Me.GridColumnFinal.Name = "GridColumnFinal"
        Me.GridColumnFinal.OptionsColumn.AllowEdit = False
        Me.GridColumnFinal.Visible = True
        Me.GridColumnFinal.VisibleIndex = 13
        '
        'GridColumnRemark
        '
        Me.GridColumnRemark.Caption = "Remark"
        Me.GridColumnRemark.Name = "GridColumnRemark"
        Me.GridColumnRemark.OptionsColumn.AllowEdit = False
        Me.GridColumnRemark.Visible = True
        Me.GridColumnRemark.VisibleIndex = 14
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
        Me.Label2.Size = New System.Drawing.Size(33, 13)
        Me.Label2.TabIndex = 16
        Me.Label2.Text = "Store"
        '
        'SBView
        '
        Me.SBView.Location = New System.Drawing.Point(262, 10)
        Me.SBView.Name = "SBView"
        Me.SBView.Size = New System.Drawing.Size(75, 23)
        Me.SBView.TabIndex = 15
        Me.SBView.Text = "View"
        '
        'GCCompany
        '
        Me.GCCompany.Caption = "Company"
        Me.GCCompany.FieldName = "comp_name"
        Me.GCCompany.Name = "GCCompany"
        Me.GCCompany.Visible = True
        Me.GCCompany.VisibleIndex = 0
        '
        'GCIdComp
        '
        Me.GCIdComp.FieldName = "id_comp"
        Me.GCIdComp.Name = "GCIdComp"
        '
        'SearchLookUpEdit1View
        '
        Me.SearchLookUpEdit1View.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GCIdComp, Me.GCCompany})
        Me.SearchLookUpEdit1View.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
        Me.SearchLookUpEdit1View.Name = "SearchLookUpEdit1View"
        Me.SearchLookUpEdit1View.OptionsSelection.EnableAppearanceFocusedCell = False
        Me.SearchLookUpEdit1View.OptionsView.ShowGroupPanel = False
        '
        'SLUECompany
        '
        Me.SLUECompany.Location = New System.Drawing.Point(56, 12)
        Me.SLUECompany.Name = "SLUECompany"
        Me.SLUECompany.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.SLUECompany.Properties.View = Me.SearchLookUpEdit1View
        Me.SLUECompany.Size = New System.Drawing.Size(200, 20)
        Me.SLUECompany.TabIndex = 17
        '
        'PanelControl1
        '
        Me.PanelControl1.Controls.Add(Me.SLUECompany)
        Me.PanelControl1.Controls.Add(Me.Label2)
        Me.PanelControl1.Controls.Add(Me.SBView)
        Me.PanelControl1.Dock = System.Windows.Forms.DockStyle.Top
        Me.PanelControl1.Location = New System.Drawing.Point(0, 0)
        Me.PanelControl1.Name = "PanelControl1"
        Me.PanelControl1.Size = New System.Drawing.Size(784, 43)
        Me.PanelControl1.TabIndex = 13
        '
        'GridColumnStoreAccount
        '
        Me.GridColumnStoreAccount.Caption = "Store Account"
        Me.GridColumnStoreAccount.FieldName = "comp_number"
        Me.GridColumnStoreAccount.Name = "GridColumnStoreAccount"
        Me.GridColumnStoreAccount.OptionsColumn.AllowEdit = False
        Me.GridColumnStoreAccount.Visible = True
        Me.GridColumnStoreAccount.VisibleIndex = 5
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
        CType(Me.SLUECompany.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl1.ResumeLayout(False)
        Me.PanelControl1.PerformLayout()
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
    Friend WithEvents GCCompany As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GCIdComp As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents SearchLookUpEdit1View As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents SLUECompany As DevExpress.XtraEditors.SearchLookUpEdit
    Friend WithEvents PanelControl1 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents GridColumnIdWhAwbDet As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnDeliverySlip As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnSDO As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnFinal As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnRemark As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnIsSelect As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnStoreAccount As DevExpress.XtraGrid.Columns.GridColumn
End Class
