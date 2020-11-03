<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FormInvoiceFGPODPPop
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormInvoiceFGPODPPop))
        Me.PanelControl7 = New DevExpress.XtraEditors.PanelControl()
        Me.BtnCancel = New DevExpress.XtraEditors.SimpleButton()
        Me.BtnSave = New DevExpress.XtraEditors.SimpleButton()
        Me.GCList = New DevExpress.XtraGrid.GridControl()
        Me.GVList = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumn1 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RICECheckDP = New DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit()
        Me.GridColumnIdRec = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn6 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn5 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn3 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn11 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnNote = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnPayment = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RITEDecimal = New DevExpress.XtraEditors.Repository.RepositoryItemTextEdit()
        Me.GridColumn4 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn2 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn9 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RICECheckReceive = New DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit()
        Me.XtraTabControl1 = New DevExpress.XtraTab.XtraTabControl()
        Me.XTPDP = New DevExpress.XtraTab.XtraTabPage()
        Me.XTPDPKhusus = New DevExpress.XtraTab.XtraTabPage()
        Me.GCDPKhusus = New DevExpress.XtraGrid.GridControl()
        Me.GVDPKhusus = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumn7 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RepositoryItemCheckEdit = New DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit()
        Me.GridColumn8 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn13 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn14 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn15 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn16 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RepositoryItemTextEdit = New DevExpress.XtraEditors.Repository.RepositoryItemTextEdit()
        Me.GridColumn10 = New DevExpress.XtraGrid.Columns.GridColumn()
        CType(Me.PanelControl7, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl7.SuspendLayout()
        CType(Me.GCList, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVList, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RICECheckDP, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RITEDecimal, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RICECheckReceive, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.XtraTabControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.XtraTabControl1.SuspendLayout()
        Me.XTPDP.SuspendLayout()
        Me.XTPDPKhusus.SuspendLayout()
        CType(Me.GCDPKhusus, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVDPKhusus, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemCheckEdit, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemTextEdit, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.GCList.Size = New System.Drawing.Size(874, 370)
        Me.GCList.TabIndex = 20
        Me.GCList.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVList})
        '
        'GVList
        '
        Me.GVList.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumn1, Me.GridColumnIdRec, Me.GridColumn6, Me.GridColumn5, Me.GridColumn10, Me.GridColumn3, Me.GridColumn11, Me.GridColumnNote, Me.GridColumnPayment, Me.GridColumn4, Me.GridColumn2, Me.GridColumn9})
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
        Me.GridColumn1.Width = 33
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
        'GridColumn6
        '
        Me.GridColumn6.Caption = "Id Cur"
        Me.GridColumn6.FieldName = "id_currency"
        Me.GridColumn6.Name = "GridColumn6"
        '
        'GridColumn5
        '
        Me.GridColumn5.Caption = "Currency"
        Me.GridColumn5.FieldName = "currency"
        Me.GridColumn5.Name = "GridColumn5"
        Me.GridColumn5.Visible = True
        Me.GridColumn5.VisibleIndex = 2
        Me.GridColumn5.Width = 40
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
        Me.GridColumn3.Width = 161
        '
        'GridColumn11
        '
        Me.GridColumn11.Caption = "Invoice Number"
        Me.GridColumn11.FieldName = "inv_number"
        Me.GridColumn11.Name = "GridColumn11"
        Me.GridColumn11.Visible = True
        Me.GridColumn11.VisibleIndex = 8
        Me.GridColumn11.Width = 81
        '
        'GridColumnNote
        '
        Me.GridColumnNote.Caption = "Note"
        Me.GridColumnNote.FieldName = "note"
        Me.GridColumnNote.Name = "GridColumnNote"
        Me.GridColumnNote.Visible = True
        Me.GridColumnNote.VisibleIndex = 9
        Me.GridColumnNote.Width = 183
        '
        'GridColumnPayment
        '
        Me.GridColumnPayment.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumnPayment.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumnPayment.AppearanceHeader.Options.UseTextOptions = True
        Me.GridColumnPayment.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumnPayment.Caption = "Amount Before Kurs"
        Me.GridColumnPayment.ColumnEdit = Me.RITEDecimal
        Me.GridColumnPayment.DisplayFormat.FormatString = "N2"
        Me.GridColumnPayment.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumnPayment.FieldName = "value_bef_kurs"
        Me.GridColumnPayment.Name = "GridColumnPayment"
        Me.GridColumnPayment.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "value", "{0:N2}")})
        Me.GridColumnPayment.Visible = True
        Me.GridColumnPayment.VisibleIndex = 4
        Me.GridColumnPayment.Width = 110
        '
        'RITEDecimal
        '
        Me.RITEDecimal.AutoHeight = False
        Me.RITEDecimal.Mask.EditMask = "N2"
        Me.RITEDecimal.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric
        Me.RITEDecimal.Name = "RITEDecimal"
        '
        'GridColumn4
        '
        Me.GridColumn4.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumn4.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumn4.AppearanceHeader.Options.UseTextOptions = True
        Me.GridColumn4.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumn4.Caption = "Kurs"
        Me.GridColumn4.DisplayFormat.FormatString = "N2"
        Me.GridColumn4.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumn4.FieldName = "kurs"
        Me.GridColumn4.Name = "GridColumn4"
        Me.GridColumn4.Visible = True
        Me.GridColumn4.VisibleIndex = 5
        Me.GridColumn4.Width = 53
        '
        'GridColumn2
        '
        Me.GridColumn2.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumn2.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumn2.AppearanceHeader.Options.UseTextOptions = True
        Me.GridColumn2.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumn2.Caption = "Amount After Kurs"
        Me.GridColumn2.DisplayFormat.FormatString = "N2"
        Me.GridColumn2.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumn2.FieldName = "value"
        Me.GridColumn2.Name = "GridColumn2"
        Me.GridColumn2.UnboundExpression = "[value_bef_kurs] * [kurs]"
        Me.GridColumn2.UnboundType = DevExpress.Data.UnboundColumnType.[Decimal]
        Me.GridColumn2.Visible = True
        Me.GridColumn2.VisibleIndex = 6
        Me.GridColumn2.Width = 76
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
        Me.GridColumn9.VisibleIndex = 7
        Me.GridColumn9.Width = 62
        '
        'RICECheckReceive
        '
        Me.RICECheckReceive.AutoHeight = False
        Me.RICECheckReceive.Name = "RICECheckReceive"
        Me.RICECheckReceive.ValueChecked = "yes"
        Me.RICECheckReceive.ValueUnchecked = "no"
        '
        'XtraTabControl1
        '
        Me.XtraTabControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.XtraTabControl1.Location = New System.Drawing.Point(0, 0)
        Me.XtraTabControl1.Name = "XtraTabControl1"
        Me.XtraTabControl1.SelectedTabPage = Me.XTPDP
        Me.XtraTabControl1.Size = New System.Drawing.Size(880, 398)
        Me.XtraTabControl1.TabIndex = 21
        Me.XtraTabControl1.TabPages.AddRange(New DevExpress.XtraTab.XtraTabPage() {Me.XTPDP, Me.XTPDPKhusus})
        '
        'XTPDP
        '
        Me.XTPDP.Controls.Add(Me.GCList)
        Me.XTPDP.Name = "XTPDP"
        Me.XTPDP.Size = New System.Drawing.Size(874, 370)
        Me.XTPDP.Text = "DP"
        '
        'XTPDPKhusus
        '
        Me.XTPDPKhusus.Controls.Add(Me.GCDPKhusus)
        Me.XTPDPKhusus.Name = "XTPDPKhusus"
        Me.XTPDPKhusus.Size = New System.Drawing.Size(874, 370)
        Me.XTPDPKhusus.Text = "DP Khusus"
        '
        'GCDPKhusus
        '
        Me.GCDPKhusus.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCDPKhusus.Location = New System.Drawing.Point(0, 0)
        Me.GCDPKhusus.MainView = Me.GVDPKhusus
        Me.GCDPKhusus.Name = "GCDPKhusus"
        Me.GCDPKhusus.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.RepositoryItemCheckEdit, Me.RepositoryItemTextEdit})
        Me.GCDPKhusus.Size = New System.Drawing.Size(874, 370)
        Me.GCDPKhusus.TabIndex = 21
        Me.GCDPKhusus.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVDPKhusus})
        '
        'GVDPKhusus
        '
        Me.GVDPKhusus.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumn7, Me.GridColumn8, Me.GridColumn13, Me.GridColumn14, Me.GridColumn15, Me.GridColumn16})
        Me.GVDPKhusus.GridControl = Me.GCDPKhusus
        Me.GVDPKhusus.Name = "GVDPKhusus"
        Me.GVDPKhusus.OptionsBehavior.AutoExpandAllGroups = True
        Me.GVDPKhusus.OptionsView.ShowFooter = True
        Me.GVDPKhusus.OptionsView.ShowGroupPanel = False
        '
        'GridColumn7
        '
        Me.GridColumn7.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumn7.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridColumn7.AppearanceHeader.Options.UseTextOptions = True
        Me.GridColumn7.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridColumn7.Caption = "*"
        Me.GridColumn7.ColumnEdit = Me.RepositoryItemCheckEdit
        Me.GridColumn7.FieldName = "is_check"
        Me.GridColumn7.Name = "GridColumn7"
        Me.GridColumn7.Visible = True
        Me.GridColumn7.VisibleIndex = 0
        Me.GridColumn7.Width = 66
        '
        'RepositoryItemCheckEdit
        '
        Me.RepositoryItemCheckEdit.AutoHeight = False
        Me.RepositoryItemCheckEdit.Name = "RepositoryItemCheckEdit"
        Me.RepositoryItemCheckEdit.ValueChecked = "yes"
        Me.RepositoryItemCheckEdit.ValueUnchecked = "no"
        '
        'GridColumn8
        '
        Me.GridColumn8.FieldName = "id_pn_fgpo"
        Me.GridColumn8.Name = "GridColumn8"
        Me.GridColumn8.OptionsColumn.AllowEdit = False
        Me.GridColumn8.OptionsColumn.AllowFocus = False
        '
        'GridColumn13
        '
        Me.GridColumn13.Caption = "BPL Number"
        Me.GridColumn13.FieldName = "number"
        Me.GridColumn13.Name = "GridColumn13"
        Me.GridColumn13.OptionsColumn.AllowEdit = False
        Me.GridColumn13.OptionsColumn.AllowFocus = False
        Me.GridColumn13.Visible = True
        Me.GridColumn13.VisibleIndex = 1
        Me.GridColumn13.Width = 322
        '
        'GridColumn14
        '
        Me.GridColumn14.Caption = "Invoice Number"
        Me.GridColumn14.FieldName = "inv_number"
        Me.GridColumn14.Name = "GridColumn14"
        Me.GridColumn14.OptionsColumn.AllowEdit = False
        Me.GridColumn14.OptionsColumn.AllowFocus = False
        Me.GridColumn14.Visible = True
        Me.GridColumn14.VisibleIndex = 3
        Me.GridColumn14.Width = 171
        '
        'GridColumn15
        '
        Me.GridColumn15.Caption = "Note"
        Me.GridColumn15.FieldName = "note"
        Me.GridColumn15.Name = "GridColumn15"
        Me.GridColumn15.OptionsColumn.AllowEdit = False
        Me.GridColumn15.OptionsColumn.AllowFocus = False
        Me.GridColumn15.Visible = True
        Me.GridColumn15.VisibleIndex = 4
        Me.GridColumn15.Width = 359
        '
        'GridColumn16
        '
        Me.GridColumn16.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumn16.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumn16.AppearanceHeader.Options.UseTextOptions = True
        Me.GridColumn16.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumn16.Caption = "Amount"
        Me.GridColumn16.ColumnEdit = Me.RepositoryItemTextEdit
        Me.GridColumn16.DisplayFormat.FormatString = "N2"
        Me.GridColumn16.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumn16.FieldName = "amount"
        Me.GridColumn16.Name = "GridColumn16"
        Me.GridColumn16.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "amount", "{0:N2}")})
        Me.GridColumn16.Visible = True
        Me.GridColumn16.VisibleIndex = 2
        Me.GridColumn16.Width = 231
        '
        'RepositoryItemTextEdit
        '
        Me.RepositoryItemTextEdit.AutoHeight = False
        Me.RepositoryItemTextEdit.DisplayFormat.FormatString = "N2"
        Me.RepositoryItemTextEdit.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.RepositoryItemTextEdit.EditFormat.FormatString = "N2"
        Me.RepositoryItemTextEdit.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.RepositoryItemTextEdit.Mask.EditMask = "N2"
        Me.RepositoryItemTextEdit.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric
        Me.RepositoryItemTextEdit.Mask.UseMaskAsDisplayFormat = True
        Me.RepositoryItemTextEdit.Name = "RepositoryItemTextEdit"
        '
        'GridColumn10
        '
        Me.GridColumn10.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumn10.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumn10.AppearanceHeader.Options.UseTextOptions = True
        Me.GridColumn10.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumn10.Caption = "Qty"
        Me.GridColumn10.DisplayFormat.FormatString = "N0"
        Me.GridColumn10.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumn10.FieldName = "qty"
        Me.GridColumn10.Name = "GridColumn10"
        Me.GridColumn10.Visible = True
        Me.GridColumn10.VisibleIndex = 3
        Me.GridColumn10.Width = 57
        '
        'FormInvoiceFGPODPPop
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(880, 445)
        Me.Controls.Add(Me.XtraTabControl1)
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
        CType(Me.XtraTabControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.XtraTabControl1.ResumeLayout(False)
        Me.XTPDP.ResumeLayout(False)
        Me.XTPDPKhusus.ResumeLayout(False)
        CType(Me.GCDPKhusus, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVDPKhusus, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemCheckEdit, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemTextEdit, System.ComponentModel.ISupportInitialize).EndInit()
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
    Friend WithEvents GridColumn6 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn5 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn4 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn2 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents XtraTabControl1 As DevExpress.XtraTab.XtraTabControl
    Friend WithEvents XTPDP As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents XTPDPKhusus As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents GCDPKhusus As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVDPKhusus As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumn7 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents RepositoryItemCheckEdit As DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit
    Friend WithEvents GridColumn8 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn13 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn14 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn15 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn16 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents RepositoryItemTextEdit As DevExpress.XtraEditors.Repository.RepositoryItemTextEdit
    Friend WithEvents GridColumn10 As DevExpress.XtraGrid.Columns.GridColumn
End Class
