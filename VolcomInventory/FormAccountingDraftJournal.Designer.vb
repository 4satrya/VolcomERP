<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FormAccountingDraftJournal
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormAccountingDraftJournal))
        Me.PanelControlNav = New DevExpress.XtraEditors.PanelControl()
        Me.LEJournalType = New DevExpress.XtraEditors.LookUpEdit()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.BtnDelete = New DevExpress.XtraEditors.SimpleButton()
        Me.BtnAdd = New DevExpress.XtraEditors.SimpleButton()
        Me.SimpleButton1 = New DevExpress.XtraEditors.SimpleButton()
        Me.GCData = New DevExpress.XtraGrid.GridControl()
        Me.GVData = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumnNo = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnAcc = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RSLEAcc = New DevExpress.XtraEditors.Repository.RepositoryItemSearchLookUpEdit()
        Me.RepositoryItemSearchLookUpEdit1View = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumnIdAcc = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnAccName = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnAccDesc2 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnParent = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnCat = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnIsDet = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnAccDesc = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnReportNumber = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnCompName = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RSLEComp = New DevExpress.XtraEditors.Repository.RepositoryItemSearchLookUpEdit()
        Me.GridView1 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumnIdComp = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnCompNumber = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnDebit = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.REValue = New DevExpress.XtraEditors.Repository.RepositoryItemTextEdit()
        Me.GridColumnCredit = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnNote = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnIdDraft = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnIdBillType = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.PBC = New DevExpress.XtraEditors.ProgressBarControl()
        Me.GridColumnQty = New DevExpress.XtraGrid.Columns.GridColumn()
        CType(Me.PanelControlNav, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControlNav.SuspendLayout()
        CType(Me.LEJournalType.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GCData, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVData, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RSLEAcc, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemSearchLookUpEdit1View, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RSLEComp, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.REValue, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PBC.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PanelControlNav
        '
        Me.PanelControlNav.Controls.Add(Me.LEJournalType)
        Me.PanelControlNav.Controls.Add(Me.Label1)
        Me.PanelControlNav.Controls.Add(Me.BtnDelete)
        Me.PanelControlNav.Controls.Add(Me.BtnAdd)
        Me.PanelControlNav.Dock = System.Windows.Forms.DockStyle.Top
        Me.PanelControlNav.Location = New System.Drawing.Point(0, 0)
        Me.PanelControlNav.Name = "PanelControlNav"
        Me.PanelControlNav.Size = New System.Drawing.Size(983, 41)
        Me.PanelControlNav.TabIndex = 0
        '
        'LEJournalType
        '
        Me.LEJournalType.Location = New System.Drawing.Point(87, 11)
        Me.LEJournalType.Name = "LEJournalType"
        Me.LEJournalType.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.LEJournalType.Properties.Columns.AddRange(New DevExpress.XtraEditors.Controls.LookUpColumnInfo() {New DevExpress.XtraEditors.Controls.LookUpColumnInfo("id_bill_type", "Id", 20, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("bill_type", "Type"), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("bill_desc", "Description")})
        Me.LEJournalType.Size = New System.Drawing.Size(163, 20)
        Me.LEJournalType.TabIndex = 5
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 14)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(69, 13)
        Me.Label1.TabIndex = 4
        Me.Label1.Text = "Journal Type"
        '
        'BtnDelete
        '
        Me.BtnDelete.Dock = System.Windows.Forms.DockStyle.Right
        Me.BtnDelete.Image = CType(resources.GetObject("BtnDelete.Image"), System.Drawing.Image)
        Me.BtnDelete.Location = New System.Drawing.Point(819, 2)
        Me.BtnDelete.Name = "BtnDelete"
        Me.BtnDelete.Size = New System.Drawing.Size(81, 37)
        Me.BtnDelete.TabIndex = 3
        Me.BtnDelete.Text = "Delete"
        '
        'BtnAdd
        '
        Me.BtnAdd.Dock = System.Windows.Forms.DockStyle.Right
        Me.BtnAdd.Image = CType(resources.GetObject("BtnAdd.Image"), System.Drawing.Image)
        Me.BtnAdd.Location = New System.Drawing.Point(900, 2)
        Me.BtnAdd.Name = "BtnAdd"
        Me.BtnAdd.Size = New System.Drawing.Size(81, 37)
        Me.BtnAdd.TabIndex = 2
        Me.BtnAdd.Text = "Add"
        '
        'SimpleButton1
        '
        Me.SimpleButton1.Appearance.BackColor = System.Drawing.Color.MediumSlateBlue
        Me.SimpleButton1.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SimpleButton1.Appearance.ForeColor = System.Drawing.Color.White
        Me.SimpleButton1.Appearance.Options.UseBackColor = True
        Me.SimpleButton1.Appearance.Options.UseFont = True
        Me.SimpleButton1.Appearance.Options.UseForeColor = True
        Me.SimpleButton1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.SimpleButton1.Location = New System.Drawing.Point(0, 445)
        Me.SimpleButton1.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.UltraFlat
        Me.SimpleButton1.LookAndFeel.UseDefaultLookAndFeel = False
        Me.SimpleButton1.Name = "SimpleButton1"
        Me.SimpleButton1.Size = New System.Drawing.Size(983, 37)
        Me.SimpleButton1.TabIndex = 4
        Me.SimpleButton1.Text = "Save"
        '
        'GCData
        '
        Me.GCData.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCData.Location = New System.Drawing.Point(0, 46)
        Me.GCData.MainView = Me.GVData
        Me.GCData.Name = "GCData"
        Me.GCData.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.RSLEAcc, Me.RSLEComp, Me.REValue})
        Me.GCData.Size = New System.Drawing.Size(983, 399)
        Me.GCData.TabIndex = 1
        Me.GCData.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVData})
        '
        'GVData
        '
        Me.GVData.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumnNo, Me.GridColumnAcc, Me.GridColumnAccDesc, Me.GridColumnReportNumber, Me.GridColumnCompName, Me.GridColumnDebit, Me.GridColumnCredit, Me.GridColumnNote, Me.GridColumnIdDraft, Me.GridColumnIdBillType, Me.GridColumnQty})
        Me.GVData.GridControl = Me.GCData
        Me.GVData.Name = "GVData"
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
        Me.GridColumnNo.Width = 58
        '
        'GridColumnAcc
        '
        Me.GridColumnAcc.Caption = "Account"
        Me.GridColumnAcc.ColumnEdit = Me.RSLEAcc
        Me.GridColumnAcc.FieldName = "id_acc"
        Me.GridColumnAcc.Name = "GridColumnAcc"
        Me.GridColumnAcc.Visible = True
        Me.GridColumnAcc.VisibleIndex = 1
        Me.GridColumnAcc.Width = 160
        '
        'RSLEAcc
        '
        Me.RSLEAcc.AutoHeight = False
        Me.RSLEAcc.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.RSLEAcc.Name = "RSLEAcc"
        Me.RSLEAcc.ShowClearButton = False
        Me.RSLEAcc.View = Me.RepositoryItemSearchLookUpEdit1View
        '
        'RepositoryItemSearchLookUpEdit1View
        '
        Me.RepositoryItemSearchLookUpEdit1View.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumnIdAcc, Me.GridColumnAccName, Me.GridColumnAccDesc2, Me.GridColumnParent, Me.GridColumnCat, Me.GridColumnIsDet})
        Me.RepositoryItemSearchLookUpEdit1View.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
        Me.RepositoryItemSearchLookUpEdit1View.Name = "RepositoryItemSearchLookUpEdit1View"
        Me.RepositoryItemSearchLookUpEdit1View.OptionsSelection.EnableAppearanceFocusedCell = False
        Me.RepositoryItemSearchLookUpEdit1View.OptionsView.ShowGroupPanel = False
        '
        'GridColumnIdAcc
        '
        Me.GridColumnIdAcc.Caption = "Id Acc"
        Me.GridColumnIdAcc.FieldName = "id_acc"
        Me.GridColumnIdAcc.Name = "GridColumnIdAcc"
        '
        'GridColumnAccName
        '
        Me.GridColumnAccName.Caption = "Account"
        Me.GridColumnAccName.FieldName = "acc_name"
        Me.GridColumnAccName.Name = "GridColumnAccName"
        Me.GridColumnAccName.Visible = True
        Me.GridColumnAccName.VisibleIndex = 0
        Me.GridColumnAccName.Width = 309
        '
        'GridColumnAccDesc2
        '
        Me.GridColumnAccDesc2.Caption = "Description"
        Me.GridColumnAccDesc2.FieldName = "acc_description"
        Me.GridColumnAccDesc2.Name = "GridColumnAccDesc2"
        Me.GridColumnAccDesc2.Visible = True
        Me.GridColumnAccDesc2.VisibleIndex = 1
        Me.GridColumnAccDesc2.Width = 735
        '
        'GridColumnParent
        '
        Me.GridColumnParent.Caption = "Parent"
        Me.GridColumnParent.FieldName = "parent"
        Me.GridColumnParent.Name = "GridColumnParent"
        Me.GridColumnParent.Visible = True
        Me.GridColumnParent.VisibleIndex = 2
        Me.GridColumnParent.Width = 390
        '
        'GridColumnCat
        '
        Me.GridColumnCat.Caption = "Category"
        Me.GridColumnCat.FieldName = "acc_cat"
        Me.GridColumnCat.Name = "GridColumnCat"
        Me.GridColumnCat.Visible = True
        Me.GridColumnCat.VisibleIndex = 3
        Me.GridColumnCat.Width = 103
        '
        'GridColumnIsDet
        '
        Me.GridColumnIsDet.Caption = "Type"
        Me.GridColumnIsDet.FieldName = "is_det"
        Me.GridColumnIsDet.Name = "GridColumnIsDet"
        Me.GridColumnIsDet.Visible = True
        Me.GridColumnIsDet.VisibleIndex = 4
        Me.GridColumnIsDet.Width = 95
        '
        'GridColumnAccDesc
        '
        Me.GridColumnAccDesc.Caption = "Account Description"
        Me.GridColumnAccDesc.FieldName = "acc_description"
        Me.GridColumnAccDesc.Name = "GridColumnAccDesc"
        Me.GridColumnAccDesc.OptionsColumn.AllowEdit = False
        Me.GridColumnAccDesc.Visible = True
        Me.GridColumnAccDesc.VisibleIndex = 2
        Me.GridColumnAccDesc.Width = 340
        '
        'GridColumnReportNumber
        '
        Me.GridColumnReportNumber.Caption = "Ref."
        Me.GridColumnReportNumber.FieldName = "report_number"
        Me.GridColumnReportNumber.Name = "GridColumnReportNumber"
        Me.GridColumnReportNumber.OptionsColumn.AllowEdit = False
        Me.GridColumnReportNumber.Visible = True
        Me.GridColumnReportNumber.VisibleIndex = 3
        Me.GridColumnReportNumber.Width = 102
        '
        'GridColumnCompName
        '
        Me.GridColumnCompName.Caption = "Supplier/Customer"
        Me.GridColumnCompName.ColumnEdit = Me.RSLEComp
        Me.GridColumnCompName.FieldName = "id_comp"
        Me.GridColumnCompName.Name = "GridColumnCompName"
        Me.GridColumnCompName.Visible = True
        Me.GridColumnCompName.VisibleIndex = 5
        Me.GridColumnCompName.Width = 139
        '
        'RSLEComp
        '
        Me.RSLEComp.AutoHeight = False
        Me.RSLEComp.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.RSLEComp.Name = "RSLEComp"
        Me.RSLEComp.NullText = "-"
        Me.RSLEComp.View = Me.GridView1
        '
        'GridView1
        '
        Me.GridView1.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumnIdComp, Me.GridColumnCompNumber})
        Me.GridView1.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
        Me.GridView1.Name = "GridView1"
        Me.GridView1.OptionsSelection.EnableAppearanceFocusedCell = False
        Me.GridView1.OptionsView.ShowGroupPanel = False
        '
        'GridColumnIdComp
        '
        Me.GridColumnIdComp.Caption = "Id"
        Me.GridColumnIdComp.FieldName = "id_comp"
        Me.GridColumnIdComp.Name = "GridColumnIdComp"
        '
        'GridColumnCompNumber
        '
        Me.GridColumnCompNumber.Caption = "Supplier / Vendor"
        Me.GridColumnCompNumber.FieldName = "comp"
        Me.GridColumnCompNumber.Name = "GridColumnCompNumber"
        Me.GridColumnCompNumber.Visible = True
        Me.GridColumnCompNumber.VisibleIndex = 0
        '
        'GridColumnDebit
        '
        Me.GridColumnDebit.Caption = "Debit"
        Me.GridColumnDebit.ColumnEdit = Me.REValue
        Me.GridColumnDebit.DisplayFormat.FormatString = "N2"
        Me.GridColumnDebit.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumnDebit.FieldName = "debit"
        Me.GridColumnDebit.Name = "GridColumnDebit"
        Me.GridColumnDebit.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "debit", "{0:N2}")})
        Me.GridColumnDebit.Visible = True
        Me.GridColumnDebit.VisibleIndex = 7
        Me.GridColumnDebit.Width = 218
        '
        'REValue
        '
        Me.REValue.AutoHeight = False
        Me.REValue.Mask.EditMask = "n2"
        Me.REValue.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric
        Me.REValue.Name = "REValue"
        '
        'GridColumnCredit
        '
        Me.GridColumnCredit.Caption = "Credit"
        Me.GridColumnCredit.ColumnEdit = Me.REValue
        Me.GridColumnCredit.DisplayFormat.FormatString = "N2"
        Me.GridColumnCredit.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumnCredit.FieldName = "credit"
        Me.GridColumnCredit.Name = "GridColumnCredit"
        Me.GridColumnCredit.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "credit", "{0:N2}")})
        Me.GridColumnCredit.Visible = True
        Me.GridColumnCredit.VisibleIndex = 8
        Me.GridColumnCredit.Width = 266
        '
        'GridColumnNote
        '
        Me.GridColumnNote.Caption = "Note"
        Me.GridColumnNote.FieldName = "acc_trans_det_note"
        Me.GridColumnNote.Name = "GridColumnNote"
        Me.GridColumnNote.Visible = True
        Me.GridColumnNote.VisibleIndex = 4
        Me.GridColumnNote.Width = 333
        '
        'GridColumnIdDraft
        '
        Me.GridColumnIdDraft.Caption = "Id Draft"
        Me.GridColumnIdDraft.FieldName = "id_acc_trans_draft"
        Me.GridColumnIdDraft.Name = "GridColumnIdDraft"
        Me.GridColumnIdDraft.OptionsColumn.AllowEdit = False
        '
        'GridColumnIdBillType
        '
        Me.GridColumnIdBillType.Caption = "Id Bill type"
        Me.GridColumnIdBillType.FieldName = "id_bill_type"
        Me.GridColumnIdBillType.Name = "GridColumnIdBillType"
        Me.GridColumnIdBillType.OptionsColumn.AllowEdit = False
        '
        'PBC
        '
        Me.PBC.Dock = System.Windows.Forms.DockStyle.Top
        Me.PBC.Location = New System.Drawing.Point(0, 41)
        Me.PBC.Name = "PBC"
        Me.PBC.Size = New System.Drawing.Size(983, 5)
        Me.PBC.TabIndex = 92
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
        'FormAccountingDraftJournal
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(983, 482)
        Me.Controls.Add(Me.GCData)
        Me.Controls.Add(Me.SimpleButton1)
        Me.Controls.Add(Me.PBC)
        Me.Controls.Add(Me.PanelControlNav)
        Me.MinimizeBox = False
        Me.Name = "FormAccountingDraftJournal"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Draft Journal"
        CType(Me.PanelControlNav, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControlNav.ResumeLayout(False)
        Me.PanelControlNav.PerformLayout()
        CType(Me.LEJournalType.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GCData, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVData, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RSLEAcc, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemSearchLookUpEdit1View, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RSLEComp, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.REValue, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PBC.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents PanelControlNav As DevExpress.XtraEditors.PanelControl
    Friend WithEvents GCData As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVData As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumnNo As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnAcc As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnAccDesc As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnReportNumber As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnCompName As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnDebit As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnCredit As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnNote As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents BtnDelete As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BtnAdd As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents GridColumnIdDraft As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents RSLEAcc As DevExpress.XtraEditors.Repository.RepositoryItemSearchLookUpEdit
    Friend WithEvents RepositoryItemSearchLookUpEdit1View As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumnIdAcc As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnAccName As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnAccDesc2 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnParent As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnCat As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnIsDet As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents SimpleButton1 As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents RSLEComp As DevExpress.XtraEditors.Repository.RepositoryItemSearchLookUpEdit
    Friend WithEvents GridView1 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumnIdComp As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnCompNumber As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents REValue As DevExpress.XtraEditors.Repository.RepositoryItemTextEdit
    Friend WithEvents PBC As DevExpress.XtraEditors.ProgressBarControl
    Friend WithEvents LEJournalType As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents Label1 As Label
    Friend WithEvents GridColumnIdBillType As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnQty As DevExpress.XtraGrid.Columns.GridColumn
End Class
