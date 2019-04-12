<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormPopUpMatPLInv
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
        Me.PanelControl2 = New DevExpress.XtraEditors.PanelControl()
        Me.BCancel = New DevExpress.XtraEditors.SimpleButton()
        Me.BSave = New DevExpress.XtraEditors.SimpleButton()
        Me.SplitContainerControl1 = New DevExpress.XtraEditors.SplitContainerControl()
        Me.GroupGeneral = New DevExpress.XtraEditors.GroupControl()
        Me.GCProdPL = New DevExpress.XtraGrid.GridControl()
        Me.GVProdPL = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumnIdPLSample = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnIdContactFrom = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnIdCompContactTo = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnPLIdWO = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnPLNumber = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnPLPoNumber = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnFrom = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnTo = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnPLDate = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnPLStatus = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnPLDesign = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnPLWONumber = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnPLIdPO = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnIdReportStatus = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.ColMrsNumber = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GCDetail = New DevExpress.XtraGrid.GridControl()
        Me.GVDetail = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumnCodeSample = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnSize = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnUOM = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnQtyNeed = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnQty = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RepositoryItemSpinEdit1 = New DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit()
        Me.GridColumnNote = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnName = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn10 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnPrice = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnTotalPrice = New DevExpress.XtraGrid.Columns.GridColumn()
        CType(Me.PanelControl2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl2.SuspendLayout()
        CType(Me.SplitContainerControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainerControl1.SuspendLayout()
        CType(Me.GroupGeneral, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupGeneral.SuspendLayout()
        CType(Me.GCProdPL, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVProdPL, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GCDetail, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVDetail, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemSpinEdit1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PanelControl2
        '
        Me.PanelControl2.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
        Me.PanelControl2.Controls.Add(Me.BCancel)
        Me.PanelControl2.Controls.Add(Me.BSave)
        Me.PanelControl2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PanelControl2.Location = New System.Drawing.Point(0, 415)
        Me.PanelControl2.Name = "PanelControl2"
        Me.PanelControl2.Size = New System.Drawing.Size(814, 42)
        Me.PanelControl2.TabIndex = 32
        '
        'BCancel
        '
        Me.BCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.BCancel.Location = New System.Drawing.Point(663, 10)
        Me.BCancel.Name = "BCancel"
        Me.BCancel.Size = New System.Drawing.Size(70, 23)
        Me.BCancel.TabIndex = 2
        Me.BCancel.Text = "Cancel"
        '
        'BSave
        '
        Me.BSave.Location = New System.Drawing.Point(739, 10)
        Me.BSave.Name = "BSave"
        Me.BSave.Size = New System.Drawing.Size(70, 23)
        Me.BSave.TabIndex = 1
        Me.BSave.Text = "Choose"
        '
        'SplitContainerControl1
        '
        Me.SplitContainerControl1.Dock = System.Windows.Forms.DockStyle.Top
        Me.SplitContainerControl1.Horizontal = False
        Me.SplitContainerControl1.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainerControl1.Name = "SplitContainerControl1"
        Me.SplitContainerControl1.Panel1.Controls.Add(Me.GroupGeneral)
        Me.SplitContainerControl1.Panel1.Text = "Panel1"
        Me.SplitContainerControl1.Panel2.Controls.Add(Me.GCDetail)
        Me.SplitContainerControl1.Panel2.Text = "Panel2"
        Me.SplitContainerControl1.Size = New System.Drawing.Size(814, 415)
        Me.SplitContainerControl1.SplitterPosition = 212
        Me.SplitContainerControl1.TabIndex = 31
        Me.SplitContainerControl1.Text = "SplitContainerControl1"
        '
        'GroupGeneral
        '
        Me.GroupGeneral.CaptionLocation = DevExpress.Utils.Locations.Top
        Me.GroupGeneral.Controls.Add(Me.GCProdPL)
        Me.GroupGeneral.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupGeneral.Location = New System.Drawing.Point(0, 0)
        Me.GroupGeneral.Name = "GroupGeneral"
        Me.GroupGeneral.Size = New System.Drawing.Size(814, 212)
        Me.GroupGeneral.TabIndex = 15
        Me.GroupGeneral.Text = "Packing List"
        '
        'GCProdPL
        '
        Me.GCProdPL.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCProdPL.Location = New System.Drawing.Point(2, 20)
        Me.GCProdPL.MainView = Me.GVProdPL
        Me.GCProdPL.Name = "GCProdPL"
        Me.GCProdPL.Size = New System.Drawing.Size(810, 190)
        Me.GCProdPL.TabIndex = 2
        Me.GCProdPL.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVProdPL})
        '
        'GVProdPL
        '
        Me.GVProdPL.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumnIdPLSample, Me.GridColumnIdContactFrom, Me.GridColumnIdCompContactTo, Me.GridColumnPLIdWO, Me.GridColumnPLNumber, Me.GridColumnPLPoNumber, Me.GridColumnFrom, Me.GridColumnTo, Me.GridColumnPLDate, Me.GridColumnPLStatus, Me.GridColumnPLDesign, Me.GridColumnPLWONumber, Me.GridColumnPLIdPO, Me.GridColumnIdReportStatus, Me.ColMrsNumber})
        Me.GVProdPL.GridControl = Me.GCProdPL
        Me.GVProdPL.Name = "GVProdPL"
        Me.GVProdPL.OptionsBehavior.Editable = False
        Me.GVProdPL.OptionsFind.AlwaysVisible = True
        Me.GVProdPL.OptionsView.ShowGroupPanel = False
        '
        'GridColumnIdPLSample
        '
        Me.GridColumnIdPLSample.Caption = "Id PL MRS "
        Me.GridColumnIdPLSample.FieldName = "id_pl_mrs"
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
        'GridColumnPLIdWO
        '
        Me.GridColumnPLIdWO.Caption = "GridColumnIdSamplePurc"
        Me.GridColumnPLIdWO.FieldName = "id_prod_order_wo"
        Me.GridColumnPLIdWO.Name = "GridColumnPLIdWO"
        Me.GridColumnPLIdWO.OptionsColumn.ShowInCustomizationForm = False
        '
        'GridColumnPLNumber
        '
        Me.GridColumnPLNumber.Caption = "Number"
        Me.GridColumnPLNumber.FieldName = "pl_mrs_number"
        Me.GridColumnPLNumber.Name = "GridColumnPLNumber"
        Me.GridColumnPLNumber.Visible = True
        Me.GridColumnPLNumber.VisibleIndex = 0
        '
        'GridColumnPLPoNumber
        '
        Me.GridColumnPLPoNumber.Caption = "PO Number"
        Me.GridColumnPLPoNumber.FieldName = "prod_order_number"
        Me.GridColumnPLPoNumber.Name = "GridColumnPLPoNumber"
        '
        'GridColumnFrom
        '
        Me.GridColumnFrom.Caption = "From"
        Me.GridColumnFrom.FieldName = "comp_name_from"
        Me.GridColumnFrom.Name = "GridColumnFrom"
        Me.GridColumnFrom.Visible = True
        Me.GridColumnFrom.VisibleIndex = 3
        '
        'GridColumnTo
        '
        Me.GridColumnTo.Caption = "To"
        Me.GridColumnTo.FieldName = "comp_name_to"
        Me.GridColumnTo.Name = "GridColumnTo"
        Me.GridColumnTo.Visible = True
        Me.GridColumnTo.VisibleIndex = 4
        '
        'GridColumnPLDate
        '
        Me.GridColumnPLDate.Caption = "Created Date"
        Me.GridColumnPLDate.FieldName = "pl_mrs_date"
        Me.GridColumnPLDate.Name = "GridColumnPLDate"
        Me.GridColumnPLDate.Visible = True
        Me.GridColumnPLDate.VisibleIndex = 5
        '
        'GridColumnPLStatus
        '
        Me.GridColumnPLStatus.Caption = "Status"
        Me.GridColumnPLStatus.FieldName = "report_status"
        Me.GridColumnPLStatus.Name = "GridColumnPLStatus"
        Me.GridColumnPLStatus.Visible = True
        Me.GridColumnPLStatus.VisibleIndex = 6
        '
        'GridColumnPLDesign
        '
        Me.GridColumnPLDesign.Caption = "Design"
        Me.GridColumnPLDesign.FieldName = "design_name"
        Me.GridColumnPLDesign.Name = "GridColumnPLDesign"
        Me.GridColumnPLDesign.Visible = True
        Me.GridColumnPLDesign.VisibleIndex = 2
        '
        'GridColumnPLWONumber
        '
        Me.GridColumnPLWONumber.Caption = "WO Number"
        Me.GridColumnPLWONumber.FieldName = "prod_order_wo_number"
        Me.GridColumnPLWONumber.Name = "GridColumnPLWONumber"
        '
        'GridColumnPLIdPO
        '
        Me.GridColumnPLIdPO.Caption = "Id PO"
        Me.GridColumnPLIdPO.FieldName = "id_prod_order"
        Me.GridColumnPLIdPO.Name = "GridColumnPLIdPO"
        '
        'GridColumnIdReportStatus
        '
        Me.GridColumnIdReportStatus.Caption = "Id Report Status"
        Me.GridColumnIdReportStatus.FieldName = "id_report_status"
        Me.GridColumnIdReportStatus.Name = "GridColumnIdReportStatus"
        '
        'ColMrsNumber
        '
        Me.ColMrsNumber.Caption = "MRS Number"
        Me.ColMrsNumber.FieldName = "prod_order_mrs_number"
        Me.ColMrsNumber.Name = "ColMrsNumber"
        Me.ColMrsNumber.Visible = True
        Me.ColMrsNumber.VisibleIndex = 1
        '
        'GCDetail
        '
        Me.GCDetail.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCDetail.Location = New System.Drawing.Point(0, 0)
        Me.GCDetail.LookAndFeel.SkinName = "Office 2010 Silver"
        Me.GCDetail.MainView = Me.GVDetail
        Me.GCDetail.Name = "GCDetail"
        Me.GCDetail.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.RepositoryItemSpinEdit1})
        Me.GCDetail.Size = New System.Drawing.Size(814, 198)
        Me.GCDetail.TabIndex = 24
        Me.GCDetail.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVDetail})
        '
        'GVDetail
        '
        Me.GVDetail.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumnCodeSample, Me.GridColumnSize, Me.GridColumnUOM, Me.GridColumnQtyNeed, Me.GridColumnQty, Me.GridColumnNote, Me.GridColumnName, Me.GridColumn10, Me.GridColumnPrice, Me.GridColumnTotalPrice})
        Me.GVDetail.GridControl = Me.GCDetail
        Me.GVDetail.Name = "GVDetail"
        Me.GVDetail.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.[True]
        Me.GVDetail.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.[True]
        Me.GVDetail.OptionsBehavior.AutoExpandAllGroups = True
        Me.GVDetail.OptionsNavigation.AutoFocusNewRow = True
        Me.GVDetail.OptionsView.ShowFooter = True
        Me.GVDetail.OptionsView.ShowGroupPanel = False
        '
        'GridColumnCodeSample
        '
        Me.GridColumnCodeSample.Caption = "Material Code"
        Me.GridColumnCodeSample.FieldName = "code"
        Me.GridColumnCodeSample.Name = "GridColumnCodeSample"
        Me.GridColumnCodeSample.OptionsColumn.AllowEdit = False
        Me.GridColumnCodeSample.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.[False]
        Me.GridColumnCodeSample.OptionsColumn.ShowInCustomizationForm = False
        Me.GridColumnCodeSample.Visible = True
        Me.GridColumnCodeSample.VisibleIndex = 0
        Me.GridColumnCodeSample.Width = 141
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
        Me.GridColumnSize.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.[False]
        Me.GridColumnSize.Visible = True
        Me.GridColumnSize.VisibleIndex = 2
        Me.GridColumnSize.Width = 62
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
        Me.GridColumnUOM.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.[False]
        Me.GridColumnUOM.OptionsColumn.ShowInCustomizationForm = False
        Me.GridColumnUOM.Visible = True
        Me.GridColumnUOM.VisibleIndex = 3
        Me.GridColumnUOM.Width = 62
        '
        'GridColumnQtyNeed
        '
        Me.GridColumnQtyNeed.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumnQtyNeed.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumnQtyNeed.AppearanceHeader.Options.UseTextOptions = True
        Me.GridColumnQtyNeed.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumnQtyNeed.Caption = "Qty Need"
        Me.GridColumnQtyNeed.DisplayFormat.FormatString = "N2"
        Me.GridColumnQtyNeed.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumnQtyNeed.FieldName = "prod_order_mrs_det_qty"
        Me.GridColumnQtyNeed.Name = "GridColumnQtyNeed"
        Me.GridColumnQtyNeed.OptionsColumn.AllowEdit = False
        Me.GridColumnQtyNeed.Width = 160
        '
        'GridColumnQty
        '
        Me.GridColumnQty.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumnQty.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumnQty.AppearanceHeader.Options.UseTextOptions = True
        Me.GridColumnQty.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumnQty.Caption = "Qty PL"
        Me.GridColumnQty.ColumnEdit = Me.RepositoryItemSpinEdit1
        Me.GridColumnQty.DisplayFormat.FormatString = "N2"
        Me.GridColumnQty.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumnQty.FieldName = "qty"
        Me.GridColumnQty.Name = "GridColumnQty"
        Me.GridColumnQty.OptionsColumn.AllowEdit = False
        Me.GridColumnQty.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.[False]
        Me.GridColumnQty.Visible = True
        Me.GridColumnQty.VisibleIndex = 4
        Me.GridColumnQty.Width = 104
        '
        'RepositoryItemSpinEdit1
        '
        Me.RepositoryItemSpinEdit1.AutoHeight = False
        Me.RepositoryItemSpinEdit1.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.RepositoryItemSpinEdit1.IsFloatValue = False
        Me.RepositoryItemSpinEdit1.Mask.EditMask = "f2"
        Me.RepositoryItemSpinEdit1.MaxValue = New Decimal(New Integer() {1215752092, 23, 0, 131072})
        Me.RepositoryItemSpinEdit1.Name = "RepositoryItemSpinEdit1"
        '
        'GridColumnNote
        '
        Me.GridColumnNote.Caption = "Remark"
        Me.GridColumnNote.FieldName = "pl_mrs_det_note"
        Me.GridColumnNote.Name = "GridColumnNote"
        Me.GridColumnNote.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.[False]
        Me.GridColumnNote.OptionsColumn.ShowInCustomizationForm = False
        '
        'GridColumnName
        '
        Me.GridColumnName.Caption = "Material Name"
        Me.GridColumnName.FieldName = "name"
        Me.GridColumnName.Name = "GridColumnName"
        Me.GridColumnName.OptionsColumn.AllowEdit = False
        Me.GridColumnName.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.[False]
        Me.GridColumnName.OptionsColumn.ShowInCustomizationForm = False
        Me.GridColumnName.Visible = True
        Me.GridColumnName.VisibleIndex = 1
        Me.GridColumnName.Width = 267
        '
        'GridColumn10
        '
        Me.GridColumn10.Caption = "Id Material"
        Me.GridColumn10.FieldName = "id_mat_det"
        Me.GridColumn10.Name = "GridColumn10"
        Me.GridColumn10.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.[False]
        Me.GridColumn10.OptionsColumn.ShowInCustomizationForm = False
        '
        'GridColumnPrice
        '
        Me.GridColumnPrice.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumnPrice.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumnPrice.AppearanceHeader.Options.UseTextOptions = True
        Me.GridColumnPrice.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumnPrice.Caption = "Unit Price"
        Me.GridColumnPrice.DisplayFormat.FormatString = "N2"
        Me.GridColumnPrice.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumnPrice.FieldName = "price"
        Me.GridColumnPrice.Name = "GridColumnPrice"
        Me.GridColumnPrice.Visible = True
        Me.GridColumnPrice.VisibleIndex = 5
        Me.GridColumnPrice.Width = 100
        '
        'GridColumnTotalPrice
        '
        Me.GridColumnTotalPrice.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumnTotalPrice.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumnTotalPrice.AppearanceHeader.Options.UseTextOptions = True
        Me.GridColumnTotalPrice.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumnTotalPrice.Caption = "Total Price"
        Me.GridColumnTotalPrice.DisplayFormat.FormatString = "N2"
        Me.GridColumnTotalPrice.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumnTotalPrice.FieldName = "total_price"
        Me.GridColumnTotalPrice.Name = "GridColumnTotalPrice"
        Me.GridColumnTotalPrice.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "total_price", "{0:N2}")})
        Me.GridColumnTotalPrice.Visible = True
        Me.GridColumnTotalPrice.VisibleIndex = 6
        Me.GridColumnTotalPrice.Width = 100
        '
        'FormPopUpMatPLInv
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(814, 457)
        Me.Controls.Add(Me.PanelControl2)
        Me.Controls.Add(Me.SplitContainerControl1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FormPopUpMatPLInv"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Pick Material"
        CType(Me.PanelControl2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl2.ResumeLayout(False)
        CType(Me.SplitContainerControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainerControl1.ResumeLayout(False)
        CType(Me.GroupGeneral, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupGeneral.ResumeLayout(False)
        CType(Me.GCProdPL, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVProdPL, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GCDetail, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVDetail, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemSpinEdit1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents PanelControl2 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents BCancel As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BSave As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents SplitContainerControl1 As DevExpress.XtraEditors.SplitContainerControl
    Friend WithEvents GroupGeneral As DevExpress.XtraEditors.GroupControl
    Friend WithEvents GCProdPL As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVProdPL As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumnIdPLSample As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnIdContactFrom As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnIdCompContactTo As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnPLIdWO As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnPLNumber As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnPLPoNumber As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnFrom As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnTo As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnPLDate As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnPLStatus As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnPLDesign As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnPLWONumber As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnPLIdPO As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnIdReportStatus As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColMrsNumber As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GCDetail As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVDetail As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumnCodeSample As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnSize As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnUOM As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnQtyNeed As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnQty As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents RepositoryItemSpinEdit1 As DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit
    Friend WithEvents GridColumnNote As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnName As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn10 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnPrice As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnTotalPrice As DevExpress.XtraGrid.Columns.GridColumn
End Class
