<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FormWHAWBillReff
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormWHAWBillReff))
        Me.PanelControl1 = New DevExpress.XtraEditors.PanelControl()
        Me.SLEComp = New DevExpress.XtraEditors.SearchLookUpEdit()
        Me.GridView3 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumn24 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn29 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn25 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.BLoad2 = New DevExpress.XtraEditors.SimpleButton()
        Me.BLoad = New DevExpress.XtraEditors.SimpleButton()
        Me.TEAWBReff = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl1 = New DevExpress.XtraEditors.LabelControl()
        Me.PanelControl2 = New DevExpress.XtraEditors.PanelControl()
        Me.BPick = New DevExpress.XtraEditors.SimpleButton()
        Me.GCDOERP = New DevExpress.XtraGrid.GridControl()
        Me.GVDOERP = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumn7 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn8 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn9 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn10 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn11 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnIdDel = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumncombine_number = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnreport_status = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn1 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RepositoryItemCheckEdit1 = New DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit()
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl1.SuspendLayout()
        CType(Me.SLEComp.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TEAWBReff.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PanelControl2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl2.SuspendLayout()
        CType(Me.GCDOERP, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVDOERP, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemCheckEdit1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PanelControl1
        '
        Me.PanelControl1.Controls.Add(Me.SLEComp)
        Me.PanelControl1.Controls.Add(Me.BLoad2)
        Me.PanelControl1.Controls.Add(Me.BLoad)
        Me.PanelControl1.Controls.Add(Me.TEAWBReff)
        Me.PanelControl1.Controls.Add(Me.LabelControl1)
        Me.PanelControl1.Dock = System.Windows.Forms.DockStyle.Top
        Me.PanelControl1.Location = New System.Drawing.Point(0, 0)
        Me.PanelControl1.Name = "PanelControl1"
        Me.PanelControl1.Size = New System.Drawing.Size(857, 42)
        Me.PanelControl1.TabIndex = 0
        '
        'SLEComp
        '
        Me.SLEComp.Location = New System.Drawing.Point(386, 12)
        Me.SLEComp.Name = "SLEComp"
        Me.SLEComp.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.SLEComp.Properties.View = Me.GridView3
        Me.SLEComp.Size = New System.Drawing.Size(185, 20)
        Me.SLEComp.TabIndex = 13
        Me.SLEComp.Visible = False
        '
        'GridView3
        '
        Me.GridView3.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumn24, Me.GridColumn29, Me.GridColumn25})
        Me.GridView3.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
        Me.GridView3.Name = "GridView3"
        Me.GridView3.OptionsSelection.EnableAppearanceFocusedCell = False
        Me.GridView3.OptionsView.ShowGroupPanel = False
        '
        'GridColumn24
        '
        Me.GridColumn24.Caption = "ID Comp"
        Me.GridColumn24.FieldName = "id_comp"
        Me.GridColumn24.Name = "GridColumn24"
        '
        'GridColumn29
        '
        Me.GridColumn29.Caption = "Number"
        Me.GridColumn29.FieldName = "comp_number"
        Me.GridColumn29.Name = "GridColumn29"
        Me.GridColumn29.Visible = True
        Me.GridColumn29.VisibleIndex = 0
        Me.GridColumn29.Width = 269
        '
        'GridColumn25
        '
        Me.GridColumn25.Caption = "Store"
        Me.GridColumn25.FieldName = "comp_name"
        Me.GridColumn25.Name = "GridColumn25"
        Me.GridColumn25.Visible = True
        Me.GridColumn25.VisibleIndex = 1
        Me.GridColumn25.Width = 1363
        '
        'BLoad2
        '
        Me.BLoad2.Location = New System.Drawing.Point(577, 10)
        Me.BLoad2.Name = "BLoad2"
        Me.BLoad2.Size = New System.Drawing.Size(56, 23)
        Me.BLoad2.TabIndex = 4
        Me.BLoad2.Text = "load"
        Me.BLoad2.Visible = False
        '
        'BLoad
        '
        Me.BLoad.Location = New System.Drawing.Point(324, 10)
        Me.BLoad.Name = "BLoad"
        Me.BLoad.Size = New System.Drawing.Size(56, 23)
        Me.BLoad.TabIndex = 2
        Me.BLoad.Text = "load"
        '
        'TEAWBReff
        '
        Me.TEAWBReff.Location = New System.Drawing.Point(74, 12)
        Me.TEAWBReff.Name = "TEAWBReff"
        Me.TEAWBReff.Size = New System.Drawing.Size(244, 20)
        Me.TEAWBReff.TabIndex = 1
        '
        'LabelControl1
        '
        Me.LabelControl1.Location = New System.Drawing.Point(18, 15)
        Me.LabelControl1.Name = "LabelControl1"
        Me.LabelControl1.Size = New System.Drawing.Size(50, 13)
        Me.LabelControl1.TabIndex = 0
        Me.LabelControl1.Text = "AWB Reff "
        '
        'PanelControl2
        '
        Me.PanelControl2.Controls.Add(Me.BPick)
        Me.PanelControl2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PanelControl2.Location = New System.Drawing.Point(0, 341)
        Me.PanelControl2.Name = "PanelControl2"
        Me.PanelControl2.Size = New System.Drawing.Size(857, 42)
        Me.PanelControl2.TabIndex = 1
        '
        'BPick
        '
        Me.BPick.Dock = System.Windows.Forms.DockStyle.Right
        Me.BPick.Image = CType(resources.GetObject("BPick.Image"), System.Drawing.Image)
        Me.BPick.Location = New System.Drawing.Point(758, 2)
        Me.BPick.Name = "BPick"
        Me.BPick.Size = New System.Drawing.Size(97, 38)
        Me.BPick.TabIndex = 3
        Me.BPick.Text = "Pick"
        '
        'GCDOERP
        '
        Me.GCDOERP.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCDOERP.Location = New System.Drawing.Point(0, 42)
        Me.GCDOERP.MainView = Me.GVDOERP
        Me.GCDOERP.Name = "GCDOERP"
        Me.GCDOERP.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.RepositoryItemCheckEdit1})
        Me.GCDOERP.Size = New System.Drawing.Size(857, 299)
        Me.GCDOERP.TabIndex = 4
        Me.GCDOERP.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVDOERP})
        '
        'GVDOERP
        '
        Me.GVDOERP.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumn7, Me.GridColumn8, Me.GridColumn9, Me.GridColumn10, Me.GridColumn11, Me.GridColumnIdDel, Me.GridColumncombine_number, Me.GridColumnreport_status, Me.GridColumn1})
        Me.GVDOERP.GridControl = Me.GCDOERP
        Me.GVDOERP.Name = "GVDOERP"
        Me.GVDOERP.OptionsCustomization.AllowColumnMoving = False
        Me.GVDOERP.OptionsCustomization.AllowColumnResizing = False
        Me.GVDOERP.OptionsCustomization.AllowFilter = False
        Me.GVDOERP.OptionsCustomization.AllowGroup = False
        Me.GVDOERP.OptionsCustomization.AllowQuickHideColumns = False
        Me.GVDOERP.OptionsCustomization.AllowRowSizing = True
        Me.GVDOERP.OptionsCustomization.AllowSort = False
        Me.GVDOERP.OptionsCustomization.CustomizationFormSearchBoxVisible = True
        Me.GVDOERP.OptionsView.ShowGroupPanel = False
        '
        'GridColumn7
        '
        Me.GridColumn7.Caption = "Delivery Order Number"
        Me.GridColumn7.FieldName = "do_no"
        Me.GridColumn7.Name = "GridColumn7"
        Me.GridColumn7.OptionsColumn.AllowEdit = False
        Me.GridColumn7.OptionsColumn.AllowFocus = False
        Me.GridColumn7.Visible = True
        Me.GridColumn7.VisibleIndex = 1
        Me.GridColumn7.Width = 142
        '
        'GridColumn8
        '
        Me.GridColumn8.Caption = "Scan Date"
        Me.GridColumn8.DisplayFormat.FormatString = "dd MMMM yyyy"
        Me.GridColumn8.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.GridColumn8.FieldName = "scan_date"
        Me.GridColumn8.Name = "GridColumn8"
        Me.GridColumn8.OptionsColumn.AllowEdit = False
        Me.GridColumn8.OptionsColumn.AllowFocus = False
        Me.GridColumn8.Visible = True
        Me.GridColumn8.VisibleIndex = 3
        Me.GridColumn8.Width = 119
        '
        'GridColumn9
        '
        Me.GridColumn9.Caption = "Code"
        Me.GridColumn9.FieldName = "store_number"
        Me.GridColumn9.Name = "GridColumn9"
        Me.GridColumn9.OptionsColumn.AllowEdit = False
        Me.GridColumn9.OptionsColumn.AllowFocus = False
        Me.GridColumn9.Visible = True
        Me.GridColumn9.VisibleIndex = 4
        Me.GridColumn9.Width = 83
        '
        'GridColumn10
        '
        Me.GridColumn10.Caption = "Store Name"
        Me.GridColumn10.FieldName = "store_name"
        Me.GridColumn10.Name = "GridColumn10"
        Me.GridColumn10.OptionsColumn.AllowEdit = False
        Me.GridColumn10.OptionsColumn.AllowFocus = False
        Me.GridColumn10.Visible = True
        Me.GridColumn10.VisibleIndex = 0
        Me.GridColumn10.Width = 201
        '
        'GridColumn11
        '
        Me.GridColumn11.Caption = "Qty"
        Me.GridColumn11.FieldName = "qty"
        Me.GridColumn11.Name = "GridColumn11"
        Me.GridColumn11.OptionsColumn.AllowEdit = False
        Me.GridColumn11.OptionsColumn.AllowFocus = False
        Me.GridColumn11.Visible = True
        Me.GridColumn11.VisibleIndex = 5
        Me.GridColumn11.Width = 86
        '
        'GridColumnIdDel
        '
        Me.GridColumnIdDel.Caption = "ID Del"
        Me.GridColumnIdDel.FieldName = "id_pl_sales_order_del"
        Me.GridColumnIdDel.Name = "GridColumnIdDel"
        '
        'GridColumncombine_number
        '
        Me.GridColumncombine_number.Caption = "Combine No"
        Me.GridColumncombine_number.FieldName = "combine_number"
        Me.GridColumncombine_number.Name = "GridColumncombine_number"
        Me.GridColumncombine_number.OptionsColumn.AllowEdit = False
        Me.GridColumncombine_number.Visible = True
        Me.GridColumncombine_number.VisibleIndex = 2
        '
        'GridColumnreport_status
        '
        Me.GridColumnreport_status.Caption = "Status Export"
        Me.GridColumnreport_status.FieldName = "is_export_awb"
        Me.GridColumnreport_status.Name = "GridColumnreport_status"
        Me.GridColumnreport_status.Visible = True
        Me.GridColumnreport_status.VisibleIndex = 6
        '
        'GridColumn1
        '
        Me.GridColumn1.Caption = "Collie Number"
        Me.GridColumn1.FieldName = "collie_number"
        Me.GridColumn1.Name = "GridColumn1"
        Me.GridColumn1.Visible = True
        Me.GridColumn1.VisibleIndex = 7
        '
        'RepositoryItemCheckEdit1
        '
        Me.RepositoryItemCheckEdit1.AutoHeight = False
        Me.RepositoryItemCheckEdit1.Name = "RepositoryItemCheckEdit1"
        Me.RepositoryItemCheckEdit1.ValueChecked = "yes"
        Me.RepositoryItemCheckEdit1.ValueUnchecked = "no"
        '
        'FormWHAWBillReff
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(857, 383)
        Me.Controls.Add(Me.GCDOERP)
        Me.Controls.Add(Me.PanelControl2)
        Me.Controls.Add(Me.PanelControl1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FormWHAWBillReff"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Pick DO From Reff"
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl1.ResumeLayout(False)
        Me.PanelControl1.PerformLayout()
        CType(Me.SLEComp.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TEAWBReff.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PanelControl2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl2.ResumeLayout(False)
        CType(Me.GCDOERP, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVDOERP, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemCheckEdit1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents PanelControl1 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents PanelControl2 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents GCDOERP As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVDOERP As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumn7 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn8 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn9 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn10 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn11 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents RepositoryItemCheckEdit1 As DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit
    Friend WithEvents GridColumnIdDel As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumncombine_number As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnreport_status As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents BLoad As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents TEAWBReff As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl1 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents BPick As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents GridColumn1 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents BLoad2 As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents SLEComp As DevExpress.XtraEditors.SearchLookUpEdit
    Friend WithEvents GridView3 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumn24 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn29 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn25 As DevExpress.XtraGrid.Columns.GridColumn
End Class
