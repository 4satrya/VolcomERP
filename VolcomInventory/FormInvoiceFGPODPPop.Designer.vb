<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormInvoiceFGPODPPop
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormInvoiceFGPODPPop))
        Me.PanelControl7 = New DevExpress.XtraEditors.PanelControl()
        Me.BtnCancel = New DevExpress.XtraEditors.SimpleButton()
        Me.BtnSave = New DevExpress.XtraEditors.SimpleButton()
        Me.GCList = New DevExpress.XtraGrid.GridControl()
        Me.GVList = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumn1 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RICECheckDP = New DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit()
        Me.GridColumnIdRec = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn3 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn11 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnNote = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnPayment = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RITEDecimal = New DevExpress.XtraEditors.Repository.RepositoryItemTextEdit()
        Me.GridColumn9 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RICECheckReceive = New DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit()
        CType(Me.PanelControl7, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl7.SuspendLayout()
        CType(Me.GCList, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVList, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RICECheckDP, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RITEDecimal, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RICECheckReceive, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PanelControl7
        '
        Me.PanelControl7.Controls.Add(Me.BtnCancel)
        Me.PanelControl7.Controls.Add(Me.BtnSave)
        Me.PanelControl7.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PanelControl7.Location = New System.Drawing.Point(0, 398)
        Me.PanelControl7.Name = "PanelControl7"
        Me.PanelControl7.Size = New System.Drawing.Size(880, 47)
        Me.PanelControl7.TabIndex = 4
        '
        'BtnCancel
        '
        Me.BtnCancel.Dock = System.Windows.Forms.DockStyle.Right
        Me.BtnCancel.Image = CType(resources.GetObject("BtnCancel.Image"), System.Drawing.Image)
        Me.BtnCancel.ImageIndex = 5
        Me.BtnCancel.Location = New System.Drawing.Point(647, 2)
        Me.BtnCancel.Name = "BtnCancel"
        Me.BtnCancel.Size = New System.Drawing.Size(112, 43)
        Me.BtnCancel.TabIndex = 18
        Me.BtnCancel.TabStop = False
        Me.BtnCancel.Text = "Close"
        '
        'BtnSave
        '
        Me.BtnSave.Dock = System.Windows.Forms.DockStyle.Right
        Me.BtnSave.Image = CType(resources.GetObject("BtnSave.Image"), System.Drawing.Image)
        Me.BtnSave.ImageIndex = 7
        Me.BtnSave.Location = New System.Drawing.Point(759, 2)
        Me.BtnSave.Name = "BtnSave"
        Me.BtnSave.Size = New System.Drawing.Size(119, 43)
        Me.BtnSave.TabIndex = 16
        Me.BtnSave.TabStop = False
        Me.BtnSave.Text = "Choose"
        '
        'GCList
        '
        Me.GCList.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCList.Location = New System.Drawing.Point(0, 0)
        Me.GCList.MainView = Me.GVList
        Me.GCList.Name = "GCList"
        Me.GCList.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.RICECheckReceive, Me.RITEDecimal, Me.RICECheckDP})
        Me.GCList.Size = New System.Drawing.Size(880, 398)
        Me.GCList.TabIndex = 20
        Me.GCList.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVList})
        '
        'GVList
        '
        Me.GVList.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumn1, Me.GridColumnIdRec, Me.GridColumn3, Me.GridColumn11, Me.GridColumnNote, Me.GridColumnPayment, Me.GridColumn9})
        Me.GVList.GridControl = Me.GCList
        Me.GVList.Name = "GVList"
        Me.GVList.OptionsBehavior.AutoExpandAllGroups = True
        Me.GVList.OptionsView.ShowFooter = True
        Me.GVList.OptionsView.ShowGroupPanel = False
        '
        'GridColumn1
        '
        Me.GridColumn1.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumn1.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridColumn1.AppearanceHeader.Options.UseTextOptions = True
        Me.GridColumn1.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridColumn1.Caption = "*"
        Me.GridColumn1.ColumnEdit = Me.RICECheckDP
        Me.GridColumn1.FieldName = "is_check"
        Me.GridColumn1.Name = "GridColumn1"
        Me.GridColumn1.Visible = True
        Me.GridColumn1.VisibleIndex = 0
        Me.GridColumn1.Width = 44
        '
        'RICECheckDP
        '
        Me.RICECheckDP.AutoHeight = False
        Me.RICECheckDP.Name = "RICECheckDP"
        Me.RICECheckDP.ValueChecked = "yes"
        Me.RICECheckDP.ValueUnchecked = "no"
        '
        'GridColumnIdRec
        '
        Me.GridColumnIdRec.Caption = "ID Report"
        Me.GridColumnIdRec.FieldName = "id_report"
        Me.GridColumnIdRec.Name = "GridColumnIdRec"
        Me.GridColumnIdRec.OptionsColumn.AllowEdit = False
        Me.GridColumnIdRec.OptionsColumn.AllowFocus = False
        '
        'GridColumn3
        '
        Me.GridColumn3.Caption = "BPL Number"
        Me.GridColumn3.FieldName = "number"
        Me.GridColumn3.Name = "GridColumn3"
        Me.GridColumn3.OptionsColumn.AllowEdit = False
        Me.GridColumn3.OptionsColumn.AllowFocus = False
        Me.GridColumn3.Visible = True
        Me.GridColumn3.VisibleIndex = 1
        Me.GridColumn3.Width = 209
        '
        'GridColumn11
        '
        Me.GridColumn11.Caption = "Invoice Number"
        Me.GridColumn11.FieldName = "inv_number"
        Me.GridColumn11.Name = "GridColumn11"
        Me.GridColumn11.Visible = True
        Me.GridColumn11.VisibleIndex = 4
        Me.GridColumn11.Width = 122
        '
        'GridColumnNote
        '
        Me.GridColumnNote.Caption = "Note"
        Me.GridColumnNote.FieldName = "note"
        Me.GridColumnNote.Name = "GridColumnNote"
        Me.GridColumnNote.Visible = True
        Me.GridColumnNote.VisibleIndex = 5
        Me.GridColumnNote.Width = 241
        '
        'GridColumnPayment
        '
        Me.GridColumnPayment.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumnPayment.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumnPayment.AppearanceHeader.Options.UseTextOptions = True
        Me.GridColumnPayment.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumnPayment.Caption = "Amount"
        Me.GridColumnPayment.ColumnEdit = Me.RITEDecimal
        Me.GridColumnPayment.DisplayFormat.FormatString = "N2"
        Me.GridColumnPayment.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumnPayment.FieldName = "value"
        Me.GridColumnPayment.Name = "GridColumnPayment"
        Me.GridColumnPayment.OptionsColumn.AllowEdit = False
        Me.GridColumnPayment.OptionsColumn.AllowFocus = False
        Me.GridColumnPayment.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "value", "{0:N2}")})
        Me.GridColumnPayment.Visible = True
        Me.GridColumnPayment.VisibleIndex = 2
        Me.GridColumnPayment.Width = 152
        '
        'RITEDecimal
        '
        Me.RITEDecimal.AutoHeight = False
        Me.RITEDecimal.Mask.EditMask = "N2"
        Me.RITEDecimal.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric
        Me.RITEDecimal.Name = "RITEDecimal"
        '
        'GridColumn9
        '
        Me.GridColumn9.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumn9.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumn9.AppearanceHeader.Options.UseTextOptions = True
        Me.GridColumn9.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumn9.Caption = "VAT"
        Me.GridColumn9.DisplayFormat.FormatString = "N2"
        Me.GridColumn9.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumn9.FieldName = "vat"
        Me.GridColumn9.Name = "GridColumn9"
        Me.GridColumn9.OptionsColumn.AllowEdit = False
        Me.GridColumn9.OptionsColumn.AllowFocus = False
        Me.GridColumn9.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "vat", "{0:N2}")})
        Me.GridColumn9.Visible = True
        Me.GridColumn9.VisibleIndex = 3
        Me.GridColumn9.Width = 94
        '
        'RICECheckReceive
        '
        Me.RICECheckReceive.AutoHeight = False
        Me.RICECheckReceive.Name = "RICECheckReceive"
        Me.RICECheckReceive.ValueChecked = "yes"
        Me.RICECheckReceive.ValueUnchecked = "no"
        '
        'FormInvoiceFGPODPPop
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(880, 445)
        Me.Controls.Add(Me.GCList)
        Me.Controls.Add(Me.PanelControl7)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FormInvoiceFGPODPPop"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Choose DP"
        CType(Me.PanelControl7, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl7.ResumeLayout(False)
        CType(Me.GCList, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVList, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RICECheckDP, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RITEDecimal, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RICECheckReceive, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents PanelControl7 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents BtnCancel As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BtnSave As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents GCList As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVList As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumnIdRec As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn3 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn11 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnNote As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnPayment As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents RITEDecimal As DevExpress.XtraEditors.Repository.RepositoryItemTextEdit
    Friend WithEvents GridColumn9 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents RICECheckReceive As DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit
    Friend WithEvents GridColumn1 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents RICECheckDP As DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit
End Class
