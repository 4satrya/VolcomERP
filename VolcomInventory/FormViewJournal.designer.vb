<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormViewJournal
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
        Me.GCJournalDet = New DevExpress.XtraGrid.GridControl()
        Me.GVJournalDet = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumn6 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn7 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn1 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn2 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn3 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn4 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RepositoryItemTextEdit1 = New DevExpress.XtraEditors.Repository.RepositoryItemTextEdit()
        Me.GridColumn5 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RepositoryItemTextEdit2 = New DevExpress.XtraEditors.Repository.RepositoryItemTextEdit()
        Me.GridColumnIdReport = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnReportMT = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnDesc = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn10 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn9 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn8 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.PanelControl4 = New DevExpress.XtraEditors.PanelControl()
        Me.MENote = New DevExpress.XtraEditors.MemoEdit()
        Me.LabelControl3 = New DevExpress.XtraEditors.LabelControl()
        Me.PCButton = New DevExpress.XtraEditors.PanelControl()
        Me.BPrint = New DevExpress.XtraEditors.SimpleButton()
        Me.BMark = New DevExpress.XtraEditors.SimpleButton()
        Me.PCGeneralheader = New DevExpress.XtraEditors.PanelControl()
        Me.PanelControl1 = New DevExpress.XtraEditors.PanelControl()
        Me.LTransNo = New DevExpress.XtraEditors.LabelControl()
        Me.TEDate = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl2 = New DevExpress.XtraEditors.LabelControl()
        Me.TEUserEntry = New DevExpress.XtraEditors.TextEdit()
        Me.TEReffDate = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl4 = New DevExpress.XtraEditors.LabelControl()
        Me.LEBilling = New DevExpress.XtraEditors.LookUpEdit()
        Me.TENumber = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl1 = New DevExpress.XtraEditors.LabelControl()
        Me.BalanceMenu = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.SMViewTransaction = New System.Windows.Forms.ToolStripMenuItem()
        Me.PCSearch = New DevExpress.XtraEditors.PanelControl()
        Me.LabelControl5 = New DevExpress.XtraEditors.LabelControl()
        Me.TEVoucherSearch = New DevExpress.XtraEditors.TextEdit()
        Me.BViewVoucher = New DevExpress.XtraEditors.SimpleButton()
        CType(Me.GCJournalDet, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVJournalDet, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemTextEdit1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemTextEdit2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PanelControl4, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl4.SuspendLayout()
        CType(Me.MENote.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PCButton, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PCButton.SuspendLayout()
        CType(Me.PCGeneralheader, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PCGeneralheader.SuspendLayout()
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl1.SuspendLayout()
        CType(Me.TEDate.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TEUserEntry.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TEReffDate.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LEBilling.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TENumber.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.BalanceMenu.SuspendLayout()
        CType(Me.PCSearch, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PCSearch.SuspendLayout()
        CType(Me.TEVoucherSearch.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GCJournalDet
        '
        Me.GCJournalDet.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCJournalDet.Location = New System.Drawing.Point(0, 114)
        Me.GCJournalDet.MainView = Me.GVJournalDet
        Me.GCJournalDet.Name = "GCJournalDet"
        Me.GCJournalDet.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.RepositoryItemTextEdit1, Me.RepositoryItemTextEdit2})
        Me.GCJournalDet.Size = New System.Drawing.Size(834, 291)
        Me.GCJournalDet.TabIndex = 11
        Me.GCJournalDet.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVJournalDet})
        '
        'GVJournalDet
        '
        Me.GVJournalDet.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumn6, Me.GridColumn7, Me.GridColumn1, Me.GridColumn2, Me.GridColumn3, Me.GridColumn4, Me.GridColumn5, Me.GridColumnIdReport, Me.GridColumnReportMT, Me.GridColumnDesc, Me.GridColumn10, Me.GridColumn9, Me.GridColumn8})
        Me.GVJournalDet.GridControl = Me.GCJournalDet
        Me.GVJournalDet.Name = "GVJournalDet"
        Me.GVJournalDet.OptionsBehavior.AutoExpandAllGroups = True
        Me.GVJournalDet.OptionsBehavior.Editable = False
        Me.GVJournalDet.OptionsView.ShowFooter = True
        Me.GVJournalDet.OptionsView.ShowGroupPanel = False
        '
        'GridColumn6
        '
        Me.GridColumn6.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumn6.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridColumn6.AppearanceHeader.Options.UseTextOptions = True
        Me.GridColumn6.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridColumn6.Caption = "No."
        Me.GridColumn6.FieldName = "no"
        Me.GridColumn6.Name = "GridColumn6"
        Me.GridColumn6.OptionsColumn.AllowEdit = False
        Me.GridColumn6.Visible = True
        Me.GridColumn6.VisibleIndex = 0
        Me.GridColumn6.Width = 31
        '
        'GridColumn7
        '
        Me.GridColumn7.Caption = "IDAcc"
        Me.GridColumn7.FieldName = "id_acc"
        Me.GridColumn7.Name = "GridColumn7"
        Me.GridColumn7.OptionsColumn.AllowEdit = False
        '
        'GridColumn1
        '
        Me.GridColumn1.Caption = "Id Trans"
        Me.GridColumn1.FieldName = "id_acc_trans_det"
        Me.GridColumn1.Name = "GridColumn1"
        Me.GridColumn1.OptionsColumn.AllowEdit = False
        Me.GridColumn1.Width = 139
        '
        'GridColumn2
        '
        Me.GridColumn2.Caption = "Account"
        Me.GridColumn2.FieldName = "acc_name"
        Me.GridColumn2.Name = "GridColumn2"
        Me.GridColumn2.OptionsColumn.ReadOnly = True
        Me.GridColumn2.Visible = True
        Me.GridColumn2.VisibleIndex = 1
        Me.GridColumn2.Width = 79
        '
        'GridColumn3
        '
        Me.GridColumn3.Caption = "Note"
        Me.GridColumn3.FieldName = "note"
        Me.GridColumn3.Name = "GridColumn3"
        Me.GridColumn3.Visible = True
        Me.GridColumn3.VisibleIndex = 6
        Me.GridColumn3.Width = 209
        '
        'GridColumn4
        '
        Me.GridColumn4.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumn4.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumn4.AppearanceHeader.Options.UseTextOptions = True
        Me.GridColumn4.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumn4.Caption = "Debit"
        Me.GridColumn4.ColumnEdit = Me.RepositoryItemTextEdit1
        Me.GridColumn4.DisplayFormat.FormatString = "N2"
        Me.GridColumn4.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumn4.FieldName = "debit"
        Me.GridColumn4.Name = "GridColumn4"
        Me.GridColumn4.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "debit", "{0:N2}")})
        Me.GridColumn4.Visible = True
        Me.GridColumn4.VisibleIndex = 7
        Me.GridColumn4.Width = 95
        '
        'RepositoryItemTextEdit1
        '
        Me.RepositoryItemTextEdit1.AutoHeight = False
        Me.RepositoryItemTextEdit1.DisplayFormat.FormatString = "N2"
        Me.RepositoryItemTextEdit1.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.RepositoryItemTextEdit1.EditFormat.FormatString = "N2"
        Me.RepositoryItemTextEdit1.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.RepositoryItemTextEdit1.Mask.EditMask = "N2"
        Me.RepositoryItemTextEdit1.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric
        Me.RepositoryItemTextEdit1.Mask.UseMaskAsDisplayFormat = True
        Me.RepositoryItemTextEdit1.Name = "RepositoryItemTextEdit1"
        '
        'GridColumn5
        '
        Me.GridColumn5.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumn5.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumn5.AppearanceHeader.Options.UseTextOptions = True
        Me.GridColumn5.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumn5.Caption = "Credit"
        Me.GridColumn5.ColumnEdit = Me.RepositoryItemTextEdit2
        Me.GridColumn5.DisplayFormat.FormatString = "N2"
        Me.GridColumn5.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumn5.FieldName = "credit"
        Me.GridColumn5.Name = "GridColumn5"
        Me.GridColumn5.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "credit", "{0:N2}")})
        Me.GridColumn5.Visible = True
        Me.GridColumn5.VisibleIndex = 8
        Me.GridColumn5.Width = 105
        '
        'RepositoryItemTextEdit2
        '
        Me.RepositoryItemTextEdit2.AutoHeight = False
        Me.RepositoryItemTextEdit2.DisplayFormat.FormatString = "N2"
        Me.RepositoryItemTextEdit2.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.RepositoryItemTextEdit2.EditFormat.FormatString = "N2"
        Me.RepositoryItemTextEdit2.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.RepositoryItemTextEdit2.Mask.EditMask = "N2"
        Me.RepositoryItemTextEdit2.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric
        Me.RepositoryItemTextEdit2.Mask.UseMaskAsDisplayFormat = True
        Me.RepositoryItemTextEdit2.Name = "RepositoryItemTextEdit2"
        '
        'GridColumnIdReport
        '
        Me.GridColumnIdReport.Caption = "Id Report"
        Me.GridColumnIdReport.FieldName = "id_report"
        Me.GridColumnIdReport.Name = "GridColumnIdReport"
        '
        'GridColumnReportMT
        '
        Me.GridColumnReportMT.Caption = "Report Mark Type"
        Me.GridColumnReportMT.FieldName = "report_mark_type"
        Me.GridColumnReportMT.Name = "GridColumnReportMT"
        '
        'GridColumnDesc
        '
        Me.GridColumnDesc.Caption = "Account Description"
        Me.GridColumnDesc.FieldName = "acc_description"
        Me.GridColumnDesc.Name = "GridColumnDesc"
        Me.GridColumnDesc.Visible = True
        Me.GridColumnDesc.VisibleIndex = 2
        Me.GridColumnDesc.Width = 97
        '
        'GridColumn10
        '
        Me.GridColumn10.Caption = "Report Number"
        Me.GridColumn10.FieldName = "report_number"
        Me.GridColumn10.Name = "GridColumn10"
        Me.GridColumn10.Visible = True
        Me.GridColumn10.VisibleIndex = 4
        Me.GridColumn10.Width = 88
        '
        'GridColumn9
        '
        Me.GridColumn9.Caption = "Reff"
        Me.GridColumn9.FieldName = "report_number_ref"
        Me.GridColumn9.Name = "GridColumn9"
        Me.GridColumn9.Visible = True
        Me.GridColumn9.VisibleIndex = 5
        Me.GridColumn9.Width = 59
        '
        'GridColumn8
        '
        Me.GridColumn8.Caption = "CC"
        Me.GridColumn8.FieldName = "comp_number"
        Me.GridColumn8.Name = "GridColumn8"
        Me.GridColumn8.Visible = True
        Me.GridColumn8.VisibleIndex = 3
        Me.GridColumn8.Width = 53
        '
        'PanelControl4
        '
        Me.PanelControl4.Controls.Add(Me.MENote)
        Me.PanelControl4.Controls.Add(Me.LabelControl3)
        Me.PanelControl4.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PanelControl4.Location = New System.Drawing.Point(0, 405)
        Me.PanelControl4.Name = "PanelControl4"
        Me.PanelControl4.Size = New System.Drawing.Size(834, 58)
        Me.PanelControl4.TabIndex = 13
        '
        'MENote
        '
        Me.MENote.Location = New System.Drawing.Point(55, 8)
        Me.MENote.Name = "MENote"
        Me.MENote.Size = New System.Drawing.Size(673, 40)
        Me.MENote.TabIndex = 4
        '
        'LabelControl3
        '
        Me.LabelControl3.Location = New System.Drawing.Point(12, 12)
        Me.LabelControl3.Name = "LabelControl3"
        Me.LabelControl3.Size = New System.Drawing.Size(23, 13)
        Me.LabelControl3.TabIndex = 3
        Me.LabelControl3.Text = "Note"
        '
        'PCButton
        '
        Me.PCButton.Controls.Add(Me.BPrint)
        Me.PCButton.Controls.Add(Me.BMark)
        Me.PCButton.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PCButton.Location = New System.Drawing.Point(0, 463)
        Me.PCButton.Name = "PCButton"
        Me.PCButton.Size = New System.Drawing.Size(834, 60)
        Me.PCButton.TabIndex = 10
        Me.PCButton.Visible = False
        '
        'BPrint
        '
        Me.BPrint.Dock = System.Windows.Forms.DockStyle.Fill
        Me.BPrint.Location = New System.Drawing.Point(2, 2)
        Me.BPrint.Name = "BPrint"
        Me.BPrint.Size = New System.Drawing.Size(830, 27)
        Me.BPrint.TabIndex = 22
        Me.BPrint.Text = "Print"
        '
        'BMark
        '
        Me.BMark.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.BMark.Location = New System.Drawing.Point(2, 29)
        Me.BMark.Name = "BMark"
        Me.BMark.Size = New System.Drawing.Size(830, 29)
        Me.BMark.TabIndex = 21
        Me.BMark.Text = "Mark"
        '
        'PCGeneralheader
        '
        Me.PCGeneralheader.Controls.Add(Me.PanelControl1)
        Me.PCGeneralheader.Controls.Add(Me.TEReffDate)
        Me.PCGeneralheader.Controls.Add(Me.LabelControl4)
        Me.PCGeneralheader.Controls.Add(Me.LEBilling)
        Me.PCGeneralheader.Controls.Add(Me.TENumber)
        Me.PCGeneralheader.Controls.Add(Me.LabelControl1)
        Me.PCGeneralheader.Dock = System.Windows.Forms.DockStyle.Top
        Me.PCGeneralheader.Location = New System.Drawing.Point(0, 38)
        Me.PCGeneralheader.Name = "PCGeneralheader"
        Me.PCGeneralheader.Size = New System.Drawing.Size(834, 76)
        Me.PCGeneralheader.TabIndex = 9
        '
        'PanelControl1
        '
        Me.PanelControl1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
        Me.PanelControl1.Controls.Add(Me.LTransNo)
        Me.PanelControl1.Controls.Add(Me.TEDate)
        Me.PanelControl1.Controls.Add(Me.LabelControl2)
        Me.PanelControl1.Controls.Add(Me.TEUserEntry)
        Me.PanelControl1.Dock = System.Windows.Forms.DockStyle.Right
        Me.PanelControl1.Location = New System.Drawing.Point(533, 2)
        Me.PanelControl1.Name = "PanelControl1"
        Me.PanelControl1.Size = New System.Drawing.Size(299, 72)
        Me.PanelControl1.TabIndex = 9
        '
        'LTransNo
        '
        Me.LTransNo.Location = New System.Drawing.Point(17, 14)
        Me.LTransNo.Name = "LTransNo"
        Me.LTransNo.Size = New System.Drawing.Size(52, 13)
        Me.LTransNo.TabIndex = 0
        Me.LTransNo.Text = "Date Entry"
        '
        'TEDate
        '
        Me.TEDate.Enabled = False
        Me.TEDate.Location = New System.Drawing.Point(86, 11)
        Me.TEDate.Name = "TEDate"
        Me.TEDate.Size = New System.Drawing.Size(203, 20)
        Me.TEDate.TabIndex = 1
        '
        'LabelControl2
        '
        Me.LabelControl2.Location = New System.Drawing.Point(17, 40)
        Me.LabelControl2.Name = "LabelControl2"
        Me.LabelControl2.Size = New System.Drawing.Size(51, 13)
        Me.LabelControl2.TabIndex = 4
        Me.LabelControl2.Text = "User Entry"
        '
        'TEUserEntry
        '
        Me.TEUserEntry.Enabled = False
        Me.TEUserEntry.Location = New System.Drawing.Point(86, 37)
        Me.TEUserEntry.Name = "TEUserEntry"
        Me.TEUserEntry.Size = New System.Drawing.Size(203, 20)
        Me.TEUserEntry.TabIndex = 5
        '
        'TEReffDate
        '
        Me.TEReffDate.Enabled = False
        Me.TEReffDate.Location = New System.Drawing.Point(98, 38)
        Me.TEReffDate.Name = "TEReffDate"
        Me.TEReffDate.Size = New System.Drawing.Size(267, 20)
        Me.TEReffDate.TabIndex = 8
        '
        'LabelControl4
        '
        Me.LabelControl4.Location = New System.Drawing.Point(12, 41)
        Me.LabelControl4.Name = "LabelControl4"
        Me.LabelControl4.Size = New System.Drawing.Size(80, 13)
        Me.LabelControl4.TabIndex = 7
        Me.LabelControl4.Text = "Refference Date"
        '
        'LEBilling
        '
        Me.LEBilling.Enabled = False
        Me.LEBilling.Location = New System.Drawing.Point(98, 12)
        Me.LEBilling.Name = "LEBilling"
        Me.LEBilling.Properties.Appearance.Options.UseTextOptions = True
        Me.LEBilling.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
        Me.LEBilling.Properties.AppearanceDisabled.BackColor = System.Drawing.Color.WhiteSmoke
        Me.LEBilling.Properties.AppearanceDisabled.ForeColor = System.Drawing.Color.Black
        Me.LEBilling.Properties.AppearanceDisabled.Options.UseBackColor = True
        Me.LEBilling.Properties.AppearanceDisabled.Options.UseForeColor = True
        Me.LEBilling.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.LEBilling.Properties.Columns.AddRange(New DevExpress.XtraEditors.Controls.LookUpColumnInfo() {New DevExpress.XtraEditors.Controls.LookUpColumnInfo("id_bill_type", "Id Billing Type", 20, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("bill_type", "Billing Type")})
        Me.LEBilling.Properties.NullText = ""
        Me.LEBilling.Properties.ShowFooter = False
        Me.LEBilling.Size = New System.Drawing.Size(70, 20)
        Me.LEBilling.TabIndex = 6
        '
        'TENumber
        '
        Me.TENumber.Enabled = False
        Me.TENumber.Location = New System.Drawing.Point(172, 12)
        Me.TENumber.Name = "TENumber"
        Me.TENumber.Size = New System.Drawing.Size(193, 20)
        Me.TENumber.TabIndex = 3
        '
        'LabelControl1
        '
        Me.LabelControl1.Location = New System.Drawing.Point(12, 15)
        Me.LabelControl1.Name = "LabelControl1"
        Me.LabelControl1.Size = New System.Drawing.Size(24, 13)
        Me.LabelControl1.TabIndex = 2
        Me.LabelControl1.Text = "Type"
        '
        'BalanceMenu
        '
        Me.BalanceMenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.SMViewTransaction})
        Me.BalanceMenu.Name = "ContextMenuStripYM"
        Me.BalanceMenu.Size = New System.Drawing.Size(158, 26)
        '
        'SMViewTransaction
        '
        Me.SMViewTransaction.Name = "SMViewTransaction"
        Me.SMViewTransaction.Size = New System.Drawing.Size(157, 22)
        Me.SMViewTransaction.Text = "View document"
        '
        'PCSearch
        '
        Me.PCSearch.Controls.Add(Me.BViewVoucher)
        Me.PCSearch.Controls.Add(Me.LabelControl5)
        Me.PCSearch.Controls.Add(Me.TEVoucherSearch)
        Me.PCSearch.Dock = System.Windows.Forms.DockStyle.Top
        Me.PCSearch.Location = New System.Drawing.Point(0, 0)
        Me.PCSearch.Name = "PCSearch"
        Me.PCSearch.Size = New System.Drawing.Size(834, 38)
        Me.PCSearch.TabIndex = 14
        Me.PCSearch.Visible = False
        '
        'LabelControl5
        '
        Me.LabelControl5.Location = New System.Drawing.Point(12, 12)
        Me.LabelControl5.Name = "LabelControl5"
        Me.LabelControl5.Size = New System.Drawing.Size(79, 13)
        Me.LabelControl5.TabIndex = 6
        Me.LabelControl5.Text = "Voucher Number"
        '
        'TEVoucherSearch
        '
        Me.TEVoucherSearch.Location = New System.Drawing.Point(98, 9)
        Me.TEVoucherSearch.Name = "TEVoucherSearch"
        Me.TEVoucherSearch.Size = New System.Drawing.Size(267, 20)
        Me.TEVoucherSearch.TabIndex = 7
        '
        'BViewVoucher
        '
        Me.BViewVoucher.Location = New System.Drawing.Point(371, 7)
        Me.BViewVoucher.Name = "BViewVoucher"
        Me.BViewVoucher.Size = New System.Drawing.Size(69, 23)
        Me.BViewVoucher.TabIndex = 8
        Me.BViewVoucher.Text = "view"
        '
        'FormViewJournal
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(834, 523)
        Me.Controls.Add(Me.GCJournalDet)
        Me.Controls.Add(Me.PCGeneralheader)
        Me.Controls.Add(Me.PCSearch)
        Me.Controls.Add(Me.PanelControl4)
        Me.Controls.Add(Me.PCButton)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MinimizeBox = False
        Me.Name = "FormViewJournal"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "View Journal Detail"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.GCJournalDet, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVJournalDet, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemTextEdit1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemTextEdit2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PanelControl4, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl4.ResumeLayout(False)
        Me.PanelControl4.PerformLayout()
        CType(Me.MENote.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PCButton, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PCButton.ResumeLayout(False)
        CType(Me.PCGeneralheader, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PCGeneralheader.ResumeLayout(False)
        Me.PCGeneralheader.PerformLayout()
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl1.ResumeLayout(False)
        Me.PanelControl1.PerformLayout()
        CType(Me.TEDate.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TEUserEntry.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TEReffDate.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LEBilling.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TENumber.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.BalanceMenu.ResumeLayout(False)
        CType(Me.PCSearch, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PCSearch.ResumeLayout(False)
        Me.PCSearch.PerformLayout()
        CType(Me.TEVoucherSearch.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GCJournalDet As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVJournalDet As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumn6 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn7 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn1 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn2 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn3 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn4 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents RepositoryItemTextEdit1 As DevExpress.XtraEditors.Repository.RepositoryItemTextEdit
    Friend WithEvents GridColumn5 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents RepositoryItemTextEdit2 As DevExpress.XtraEditors.Repository.RepositoryItemTextEdit
    Friend WithEvents PanelControl4 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents MENote As DevExpress.XtraEditors.MemoEdit
    Friend WithEvents LabelControl3 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents PCButton As DevExpress.XtraEditors.PanelControl
    Friend WithEvents BMark As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents PCGeneralheader As DevExpress.XtraEditors.PanelControl
    Friend WithEvents TEUserEntry As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl2 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents TENumber As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl1 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents TEDate As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LTransNo As DevExpress.XtraEditors.LabelControl
    Friend WithEvents BalanceMenu As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents SMViewTransaction As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents GridColumnIdReport As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnReportMT As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents LEBilling As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents GridColumnDesc As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn8 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents BPrint As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents TEReffDate As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl4 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents GridColumn10 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn9 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents PanelControl1 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents PCSearch As DevExpress.XtraEditors.PanelControl
    Friend WithEvents BViewVoucher As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents LabelControl5 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents TEVoucherSearch As DevExpress.XtraEditors.TextEdit
End Class
