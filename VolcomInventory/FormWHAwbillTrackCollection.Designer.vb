<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormWHAwbillTrackCollection
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormWHAwbillTrackCollection))
        Me.PanelControl1 = New DevExpress.XtraEditors.PanelControl()
        Me.GCCollection = New DevExpress.XtraGrid.GridControl()
        Me.GVCollection = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumn1 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn2 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn3 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn4 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn5 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.LabelControl1 = New DevExpress.XtraEditors.LabelControl()
        Me.SLECargo = New DevExpress.XtraEditors.SearchLookUpEdit()
        Me.SLVCargo = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumnIdSeason = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnRange = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.BView = New DevExpress.XtraEditors.SimpleButton()
        Me.Bimport = New DevExpress.XtraEditors.SimpleButton()
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl1.SuspendLayout()
        CType(Me.GCCollection, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVCollection, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SLECargo.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SLVCargo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PanelControl1
        '
        Me.PanelControl1.Controls.Add(Me.Bimport)
        Me.PanelControl1.Controls.Add(Me.BView)
        Me.PanelControl1.Controls.Add(Me.LabelControl1)
        Me.PanelControl1.Controls.Add(Me.SLECargo)
        Me.PanelControl1.Dock = System.Windows.Forms.DockStyle.Top
        Me.PanelControl1.Location = New System.Drawing.Point(0, 0)
        Me.PanelControl1.Name = "PanelControl1"
        Me.PanelControl1.Size = New System.Drawing.Size(961, 41)
        Me.PanelControl1.TabIndex = 0
        '
        'GCCollection
        '
        Me.GCCollection.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCCollection.Location = New System.Drawing.Point(0, 41)
        Me.GCCollection.MainView = Me.GVCollection
        Me.GCCollection.Name = "GCCollection"
        Me.GCCollection.Size = New System.Drawing.Size(961, 465)
        Me.GCCollection.TabIndex = 1
        Me.GCCollection.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVCollection})
        '
        'GVCollection
        '
        Me.GVCollection.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumn1, Me.GridColumn5, Me.GridColumn2, Me.GridColumn3, Me.GridColumn4})
        Me.GVCollection.GridControl = Me.GCCollection
        Me.GVCollection.Name = "GVCollection"
        Me.GVCollection.OptionsView.ShowGroupPanel = False
        '
        'GridColumn1
        '
        Me.GridColumn1.Caption = "ID "
        Me.GridColumn1.FieldName = "id_track_no"
        Me.GridColumn1.Name = "GridColumn1"
        '
        'GridColumn2
        '
        Me.GridColumn2.Caption = "Vendor"
        Me.GridColumn2.Name = "GridColumn2"
        Me.GridColumn2.Visible = True
        Me.GridColumn2.VisibleIndex = 0
        '
        'GridColumn3
        '
        Me.GridColumn3.Caption = "Tracking Number"
        Me.GridColumn3.Name = "GridColumn3"
        Me.GridColumn3.Visible = True
        Me.GridColumn3.VisibleIndex = 1
        '
        'GridColumn4
        '
        Me.GridColumn4.Caption = "Status"
        Me.GridColumn4.FieldName = "used"
        Me.GridColumn4.Name = "GridColumn4"
        Me.GridColumn4.Visible = True
        Me.GridColumn4.VisibleIndex = 2
        '
        'GridColumn5
        '
        Me.GridColumn5.Caption = "IS Use"
        Me.GridColumn5.FieldName = "is_use"
        Me.GridColumn5.Name = "GridColumn5"
        '
        'LabelControl1
        '
        Me.LabelControl1.Location = New System.Drawing.Point(12, 12)
        Me.LabelControl1.Name = "LabelControl1"
        Me.LabelControl1.Size = New System.Drawing.Size(34, 13)
        Me.LabelControl1.TabIndex = 11
        Me.LabelControl1.Text = "Vendor"
        '
        'SLECargo
        '
        Me.SLECargo.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.SLECargo.Location = New System.Drawing.Point(52, 9)
        Me.SLECargo.Name = "SLECargo"
        Me.SLECargo.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SLECargo.Properties.Appearance.Options.UseFont = True
        Me.SLECargo.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.SLECargo.Properties.NullText = "-"
        Me.SLECargo.Properties.View = Me.SLVCargo
        Me.SLECargo.Size = New System.Drawing.Size(199, 20)
        Me.SLECargo.TabIndex = 10
        '
        'SLVCargo
        '
        Me.SLVCargo.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumnIdSeason, Me.GridColumnRange})
        Me.SLVCargo.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
        Me.SLVCargo.Name = "SLVCargo"
        Me.SLVCargo.OptionsBehavior.ReadOnly = True
        Me.SLVCargo.OptionsSelection.EnableAppearanceFocusedCell = False
        Me.SLVCargo.OptionsView.ShowGroupPanel = False
        '
        'GridColumnIdSeason
        '
        Me.GridColumnIdSeason.Caption = "ID Cargo"
        Me.GridColumnIdSeason.FieldName = "id_cargo"
        Me.GridColumnIdSeason.Name = "GridColumnIdSeason"
        '
        'GridColumnRange
        '
        Me.GridColumnRange.Caption = "Cargo Name"
        Me.GridColumnRange.FieldName = "cargo"
        Me.GridColumnRange.Name = "GridColumnRange"
        Me.GridColumnRange.Visible = True
        Me.GridColumnRange.VisibleIndex = 0
        '
        'BView
        '
        Me.BView.Location = New System.Drawing.Point(257, 7)
        Me.BView.Name = "BView"
        Me.BView.Size = New System.Drawing.Size(48, 23)
        Me.BView.TabIndex = 12
        Me.BView.Text = "view"
        '
        'Bimport
        '
        Me.Bimport.Dock = System.Windows.Forms.DockStyle.Right
        Me.Bimport.Image = CType(resources.GetObject("Bimport.Image"), System.Drawing.Image)
        Me.Bimport.Location = New System.Drawing.Point(816, 2)
        Me.Bimport.Name = "Bimport"
        Me.Bimport.Size = New System.Drawing.Size(143, 37)
        Me.Bimport.TabIndex = 13
        Me.Bimport.Text = "Import Collection"
        '
        'FormWHAwbillTrackCollection
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(961, 506)
        Me.Controls.Add(Me.GCCollection)
        Me.Controls.Add(Me.PanelControl1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MinimizeBox = False
        Me.Name = "FormWHAwbillTrackCollection"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Tracking Number Collection"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl1.ResumeLayout(False)
        Me.PanelControl1.PerformLayout()
        CType(Me.GCCollection, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVCollection, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SLECargo.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SLVCargo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents PanelControl1 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents GCCollection As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVCollection As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumn1 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn5 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn2 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn3 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn4 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents LabelControl1 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents SLECargo As DevExpress.XtraEditors.SearchLookUpEdit
    Friend WithEvents SLVCargo As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumnIdSeason As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnRange As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents BView As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents Bimport As DevExpress.XtraEditors.SimpleButton
End Class
