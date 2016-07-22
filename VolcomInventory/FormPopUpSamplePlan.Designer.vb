<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormPopUpSamplePlan
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
        Me.PanelControlButton = New DevExpress.XtraEditors.PanelControl()
        Me.BCancel = New DevExpress.XtraEditors.SimpleButton()
        Me.BSave = New DevExpress.XtraEditors.SimpleButton()
        Me.SplitContainerControl1 = New DevExpress.XtraEditors.SplitContainerControl()
        Me.GroupGeneral = New DevExpress.XtraEditors.GroupControl()
        Me.GCSamplePrePO = New DevExpress.XtraGrid.GridControl()
        Me.GVSamplePrePO = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.ColIdSamplePurchase = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.ColSeason = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.ColSPNumber = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.ColSPTo = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.ColSamplePurcDate = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.ColStatus = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.ColIDStatus = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GCListPlan = New DevExpress.XtraGrid.GridControl()
        Me.GVListPlan = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.ColNo = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.ColIdSamplePlanDet = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.ColIdSample = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.ColSampleCode = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.ColSampleName = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.ColSampleSize = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.ColSamplePlanQty = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.SEQty = New DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit()
        Me.GridColumnIdPrice = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnSamplePrice = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.ColSamplePlanDetNote = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnColor = New DevExpress.XtraGrid.Columns.GridColumn()
        CType(Me.PanelControlButton, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControlButton.SuspendLayout()
        CType(Me.SplitContainerControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainerControl1.SuspendLayout()
        CType(Me.GroupGeneral, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupGeneral.SuspendLayout()
        CType(Me.GCSamplePrePO, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVSamplePrePO, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GCListPlan, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVListPlan, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SEQty, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PanelControlButton
        '
        Me.PanelControlButton.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
        Me.PanelControlButton.Controls.Add(Me.BCancel)
        Me.PanelControlButton.Controls.Add(Me.BSave)
        Me.PanelControlButton.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PanelControlButton.Location = New System.Drawing.Point(0, 370)
        Me.PanelControlButton.Name = "PanelControlButton"
        Me.PanelControlButton.Size = New System.Drawing.Size(703, 38)
        Me.PanelControlButton.TabIndex = 37
        '
        'BCancel
        '
        Me.BCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.BCancel.Dock = System.Windows.Forms.DockStyle.Right
        Me.BCancel.Location = New System.Drawing.Point(563, 0)
        Me.BCancel.Name = "BCancel"
        Me.BCancel.Size = New System.Drawing.Size(70, 38)
        Me.BCancel.TabIndex = 2
        Me.BCancel.Text = "Cancel"
        '
        'BSave
        '
        Me.BSave.Dock = System.Windows.Forms.DockStyle.Right
        Me.BSave.Location = New System.Drawing.Point(633, 0)
        Me.BSave.Name = "BSave"
        Me.BSave.Size = New System.Drawing.Size(70, 38)
        Me.BSave.TabIndex = 1
        Me.BSave.Text = "Save"
        '
        'SplitContainerControl1
        '
        Me.SplitContainerControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainerControl1.Horizontal = False
        Me.SplitContainerControl1.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainerControl1.Name = "SplitContainerControl1"
        Me.SplitContainerControl1.Panel1.Controls.Add(Me.GroupGeneral)
        Me.SplitContainerControl1.Panel1.Text = "Panel1"
        Me.SplitContainerControl1.Panel2.Controls.Add(Me.GCListPlan)
        Me.SplitContainerControl1.Panel2.Text = "Panel2"
        Me.SplitContainerControl1.Size = New System.Drawing.Size(703, 370)
        Me.SplitContainerControl1.SplitterPosition = 184
        Me.SplitContainerControl1.TabIndex = 38
        Me.SplitContainerControl1.Text = "SplitContainerControl1"
        '
        'GroupGeneral
        '
        Me.GroupGeneral.CaptionLocation = DevExpress.Utils.Locations.Top
        Me.GroupGeneral.Controls.Add(Me.GCSamplePrePO)
        Me.GroupGeneral.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupGeneral.Location = New System.Drawing.Point(0, 0)
        Me.GroupGeneral.Name = "GroupGeneral"
        Me.GroupGeneral.Size = New System.Drawing.Size(703, 184)
        Me.GroupGeneral.TabIndex = 37
        Me.GroupGeneral.Text = "Sample Plan"
        '
        'GCSamplePrePO
        '
        Me.GCSamplePrePO.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCSamplePrePO.Location = New System.Drawing.Point(2, 20)
        Me.GCSamplePrePO.MainView = Me.GVSamplePrePO
        Me.GCSamplePrePO.Name = "GCSamplePrePO"
        Me.GCSamplePrePO.Size = New System.Drawing.Size(699, 162)
        Me.GCSamplePrePO.TabIndex = 5
        Me.GCSamplePrePO.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVSamplePrePO})
        '
        'GVSamplePrePO
        '
        Me.GVSamplePrePO.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.ColIdSamplePurchase, Me.ColSeason, Me.ColSPNumber, Me.ColSPTo, Me.ColSamplePurcDate, Me.ColStatus, Me.ColIDStatus})
        Me.GVSamplePrePO.GridControl = Me.GCSamplePrePO
        Me.GVSamplePrePO.GroupCount = 1
        Me.GVSamplePrePO.Name = "GVSamplePrePO"
        Me.GVSamplePrePO.OptionsBehavior.Editable = False
        Me.GVSamplePrePO.OptionsView.ShowGroupPanel = False
        Me.GVSamplePrePO.SortInfo.AddRange(New DevExpress.XtraGrid.Columns.GridColumnSortInfo() {New DevExpress.XtraGrid.Columns.GridColumnSortInfo(Me.ColSeason, DevExpress.Data.ColumnSortOrder.Ascending)})
        '
        'ColIdSamplePurchase
        '
        Me.ColIdSamplePurchase.Caption = "ID Sample Plan"
        Me.ColIdSamplePurchase.FieldName = "id_sample_plan"
        Me.ColIdSamplePurchase.Name = "ColIdSamplePurchase"
        '
        'ColSeason
        '
        Me.ColSeason.Caption = "Season"
        Me.ColSeason.FieldName = "season_orign"
        Me.ColSeason.Name = "ColSeason"
        '
        'ColSPNumber
        '
        Me.ColSPNumber.Caption = "Number"
        Me.ColSPNumber.FieldName = "sample_plan_number"
        Me.ColSPNumber.Name = "ColSPNumber"
        Me.ColSPNumber.Visible = True
        Me.ColSPNumber.VisibleIndex = 0
        Me.ColSPNumber.Width = 73
        '
        'ColSPTo
        '
        Me.ColSPTo.Caption = "Vendor"
        Me.ColSPTo.FieldName = "comp_name_to"
        Me.ColSPTo.Name = "ColSPTo"
        Me.ColSPTo.Visible = True
        Me.ColSPTo.VisibleIndex = 1
        Me.ColSPTo.Width = 142
        '
        'ColSamplePurcDate
        '
        Me.ColSamplePurcDate.Caption = "Create Date"
        Me.ColSamplePurcDate.FieldName = "date_view"
        Me.ColSamplePurcDate.Name = "ColSamplePurcDate"
        Me.ColSamplePurcDate.Visible = True
        Me.ColSamplePurcDate.VisibleIndex = 2
        Me.ColSamplePurcDate.Width = 131
        '
        'ColStatus
        '
        Me.ColStatus.Caption = "Status"
        Me.ColStatus.FieldName = "report_status"
        Me.ColStatus.Name = "ColStatus"
        Me.ColStatus.Visible = True
        Me.ColStatus.VisibleIndex = 3
        '
        'ColIDStatus
        '
        Me.ColIDStatus.Caption = "ID Status"
        Me.ColIDStatus.FieldName = "id_report_status"
        Me.ColIDStatus.Name = "ColIDStatus"
        '
        'GCListPlan
        '
        Me.GCListPlan.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCListPlan.Location = New System.Drawing.Point(0, 0)
        Me.GCListPlan.MainView = Me.GVListPlan
        Me.GCListPlan.Name = "GCListPlan"
        Me.GCListPlan.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.SEQty})
        Me.GCListPlan.Size = New System.Drawing.Size(703, 181)
        Me.GCListPlan.TabIndex = 1
        Me.GCListPlan.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVListPlan})
        '
        'GVListPlan
        '
        Me.GVListPlan.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.ColNo, Me.ColIdSamplePlanDet, Me.ColIdSample, Me.ColSampleCode, Me.ColSampleName, Me.ColSampleSize, Me.ColSamplePlanQty, Me.GridColumnIdPrice, Me.GridColumnSamplePrice, Me.ColSamplePlanDetNote, Me.GridColumnColor})
        Me.GVListPlan.GridControl = Me.GCListPlan
        Me.GVListPlan.HorzScrollVisibility = DevExpress.XtraGrid.Views.Base.ScrollVisibility.Always
        Me.GVListPlan.Name = "GVListPlan"
        Me.GVListPlan.OptionsView.ShowGroupPanel = False
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
        Me.ColNo.Width = 50
        '
        'ColIdSamplePlanDet
        '
        Me.ColIdSamplePlanDet.Caption = "Id Sample Plan Det"
        Me.ColIdSamplePlanDet.FieldName = "id_sample_plan_det"
        Me.ColIdSamplePlanDet.Name = "ColIdSamplePlanDet"
        Me.ColIdSamplePlanDet.OptionsColumn.AllowEdit = False
        '
        'ColIdSample
        '
        Me.ColIdSample.Caption = "Id Sample"
        Me.ColIdSample.FieldName = "id_sample"
        Me.ColIdSample.Name = "ColIdSample"
        Me.ColIdSample.OptionsColumn.AllowEdit = False
        '
        'ColSampleCode
        '
        Me.ColSampleCode.Caption = "Code"
        Me.ColSampleCode.FieldName = "code"
        Me.ColSampleCode.Name = "ColSampleCode"
        Me.ColSampleCode.OptionsColumn.AllowEdit = False
        Me.ColSampleCode.Visible = True
        Me.ColSampleCode.VisibleIndex = 1
        Me.ColSampleCode.Width = 150
        '
        'ColSampleName
        '
        Me.ColSampleName.Caption = "Description"
        Me.ColSampleName.FieldName = "name"
        Me.ColSampleName.Name = "ColSampleName"
        Me.ColSampleName.OptionsColumn.AllowEdit = False
        Me.ColSampleName.Visible = True
        Me.ColSampleName.VisibleIndex = 2
        Me.ColSampleName.Width = 192
        '
        'ColSampleSize
        '
        Me.ColSampleSize.AppearanceCell.Options.UseTextOptions = True
        Me.ColSampleSize.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.ColSampleSize.AppearanceHeader.Options.UseTextOptions = True
        Me.ColSampleSize.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.ColSampleSize.Caption = "Size"
        Me.ColSampleSize.FieldName = "size"
        Me.ColSampleSize.Name = "ColSampleSize"
        Me.ColSampleSize.OptionsColumn.AllowEdit = False
        Me.ColSampleSize.Visible = True
        Me.ColSampleSize.VisibleIndex = 4
        Me.ColSampleSize.Width = 100
        '
        'ColSamplePlanQty
        '
        Me.ColSamplePlanQty.AppearanceCell.Options.UseTextOptions = True
        Me.ColSamplePlanQty.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.ColSamplePlanQty.AppearanceHeader.Options.UseTextOptions = True
        Me.ColSamplePlanQty.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.ColSamplePlanQty.Caption = "Qty"
        Me.ColSamplePlanQty.ColumnEdit = Me.SEQty
        Me.ColSamplePlanQty.FieldName = "qty"
        Me.ColSamplePlanQty.Name = "ColSamplePlanQty"
        Me.ColSamplePlanQty.Visible = True
        Me.ColSamplePlanQty.VisibleIndex = 5
        Me.ColSamplePlanQty.Width = 100
        '
        'SEQty
        '
        Me.SEQty.AutoHeight = False
        Me.SEQty.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.SEQty.Mask.EditMask = "f0"
        Me.SEQty.MaxValue = New Decimal(New Integer() {-1530494977, 232830, 0, 0})
        Me.SEQty.Name = "SEQty"
        '
        'GridColumnIdPrice
        '
        Me.GridColumnIdPrice.Caption = "Id Price"
        Me.GridColumnIdPrice.FieldName = "id_sample_price"
        Me.GridColumnIdPrice.Name = "GridColumnIdPrice"
        '
        'GridColumnSamplePrice
        '
        Me.GridColumnSamplePrice.Caption = "Price"
        Me.GridColumnSamplePrice.FieldName = "sample_price"
        Me.GridColumnSamplePrice.Name = "GridColumnSamplePrice"
        Me.GridColumnSamplePrice.Visible = True
        Me.GridColumnSamplePrice.VisibleIndex = 7
        '
        'ColSamplePlanDetNote
        '
        Me.ColSamplePlanDetNote.Caption = "Note"
        Me.ColSamplePlanDetNote.FieldName = "sample_plan_det_note"
        Me.ColSamplePlanDetNote.Name = "ColSamplePlanDetNote"
        Me.ColSamplePlanDetNote.Visible = True
        Me.ColSamplePlanDetNote.VisibleIndex = 6
        Me.ColSamplePlanDetNote.Width = 202
        '
        'GridColumnColor
        '
        Me.GridColumnColor.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumnColor.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridColumnColor.AppearanceHeader.Options.UseTextOptions = True
        Me.GridColumnColor.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridColumnColor.Caption = "Color"
        Me.GridColumnColor.FieldName = "color"
        Me.GridColumnColor.Name = "GridColumnColor"
        Me.GridColumnColor.Visible = True
        Me.GridColumnColor.VisibleIndex = 3
        '
        'FormPopUpSamplePlan
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(703, 408)
        Me.Controls.Add(Me.SplitContainerControl1)
        Me.Controls.Add(Me.PanelControlButton)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FormPopUpSamplePlan"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Sample Proforma PO List"
        CType(Me.PanelControlButton, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControlButton.ResumeLayout(False)
        CType(Me.SplitContainerControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainerControl1.ResumeLayout(False)
        CType(Me.GroupGeneral, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupGeneral.ResumeLayout(False)
        CType(Me.GCSamplePrePO, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVSamplePrePO, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GCListPlan, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVListPlan, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SEQty, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents PanelControlButton As DevExpress.XtraEditors.PanelControl
    Friend WithEvents BCancel As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BSave As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents SplitContainerControl1 As DevExpress.XtraEditors.SplitContainerControl
    Friend WithEvents GroupGeneral As DevExpress.XtraEditors.GroupControl
    Friend WithEvents GCSamplePrePO As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVSamplePrePO As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents ColIdSamplePurchase As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColSeason As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColSPNumber As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColSPTo As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColSamplePurcDate As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColStatus As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColIDStatus As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GCListPlan As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVListPlan As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents ColNo As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColIdSamplePlanDet As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColIdSample As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColSampleCode As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColSampleName As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColSampleSize As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColSamplePlanQty As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents SEQty As DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit
    Friend WithEvents ColSamplePlanDetNote As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnColor As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnIdPrice As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnSamplePrice As DevExpress.XtraGrid.Columns.GridColumn
End Class
