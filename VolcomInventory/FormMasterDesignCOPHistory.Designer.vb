<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormMasterDesignCOPHistory
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
        Me.BPrint = New DevExpress.XtraEditors.SimpleButton()
        Me.GCCOPHistory = New DevExpress.XtraGrid.GridControl()
        Me.GVCOPHistory = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumn2 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn3 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn4 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn5 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn6 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn7 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn1 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.PanelControl1 = New DevExpress.XtraEditors.PanelControl()
        Me.BSearch = New DevExpress.XtraEditors.SimpleButton()
        Me.LabelControl2 = New DevExpress.XtraEditors.LabelControl()
        Me.SLESource = New DevExpress.XtraEditors.SearchLookUpEdit()
        Me.GridView1 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumn10 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn11 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn12 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.LabelControl1 = New DevExpress.XtraEditors.LabelControl()
        Me.SLEClass = New DevExpress.XtraEditors.SearchLookUpEdit()
        Me.SearchLookUpEdit1View = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumn8 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn9 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn13 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn14 = New DevExpress.XtraGrid.Columns.GridColumn()
        CType(Me.GCCOPHistory, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVCOPHistory, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl1.SuspendLayout()
        CType(Me.SLESource.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SLEClass.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SearchLookUpEdit1View, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'BPrint
        '
        Me.BPrint.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.BPrint.Location = New System.Drawing.Point(0, 540)
        Me.BPrint.Name = "BPrint"
        Me.BPrint.Size = New System.Drawing.Size(980, 31)
        Me.BPrint.TabIndex = 0
        Me.BPrint.Text = "Print"
        '
        'GCCOPHistory
        '
        Me.GCCOPHistory.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCCOPHistory.Location = New System.Drawing.Point(0, 40)
        Me.GCCOPHistory.MainView = Me.GVCOPHistory
        Me.GCCOPHistory.Name = "GCCOPHistory"
        Me.GCCOPHistory.Size = New System.Drawing.Size(980, 500)
        Me.GCCOPHistory.TabIndex = 1
        Me.GCCOPHistory.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVCOPHistory})
        '
        'GVCOPHistory
        '
        Me.GVCOPHistory.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumn2, Me.GridColumn14, Me.GridColumn3, Me.GridColumn4, Me.GridColumn5, Me.GridColumn6, Me.GridColumn7, Me.GridColumn1})
        Me.GVCOPHistory.GridControl = Me.GCCOPHistory
        Me.GVCOPHistory.Name = "GVCOPHistory"
        Me.GVCOPHistory.OptionsView.ShowGroupPanel = False
        '
        'GridColumn2
        '
        Me.GridColumn2.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumn2.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridColumn2.AppearanceHeader.Options.UseTextOptions = True
        Me.GridColumn2.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridColumn2.Caption = "Class"
        Me.GridColumn2.FieldName = "class"
        Me.GridColumn2.Name = "GridColumn2"
        Me.GridColumn2.Visible = True
        Me.GridColumn2.VisibleIndex = 0
        Me.GridColumn2.Width = 82
        '
        'GridColumn3
        '
        Me.GridColumn3.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumn3.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridColumn3.AppearanceHeader.Options.UseTextOptions = True
        Me.GridColumn3.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridColumn3.Caption = "Source"
        Me.GridColumn3.FieldName = "source"
        Me.GridColumn3.Name = "GridColumn3"
        Me.GridColumn3.Visible = True
        Me.GridColumn3.VisibleIndex = 2
        Me.GridColumn3.Width = 116
        '
        'GridColumn4
        '
        Me.GridColumn4.Caption = "Design Code"
        Me.GridColumn4.FieldName = "design_code"
        Me.GridColumn4.Name = "GridColumn4"
        Me.GridColumn4.Visible = True
        Me.GridColumn4.VisibleIndex = 3
        Me.GridColumn4.Width = 178
        '
        'GridColumn5
        '
        Me.GridColumn5.Caption = "Description"
        Me.GridColumn5.FieldName = "design_display_name"
        Me.GridColumn5.Name = "GridColumn5"
        Me.GridColumn5.Visible = True
        Me.GridColumn5.VisibleIndex = 4
        Me.GridColumn5.Width = 360
        '
        'GridColumn6
        '
        Me.GridColumn6.Caption = "Vendor"
        Me.GridColumn6.FieldName = "comp_name"
        Me.GridColumn6.Name = "GridColumn6"
        Me.GridColumn6.Visible = True
        Me.GridColumn6.VisibleIndex = 5
        Me.GridColumn6.Width = 459
        '
        'GridColumn7
        '
        Me.GridColumn7.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumn7.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumn7.AppearanceHeader.Options.UseTextOptions = True
        Me.GridColumn7.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumn7.Caption = "COP PD (Exclude additional)"
        Me.GridColumn7.DisplayFormat.FormatString = "N2"
        Me.GridColumn7.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumn7.FieldName = "cop_pd"
        Me.GridColumn7.Name = "GridColumn7"
        Me.GridColumn7.Visible = True
        Me.GridColumn7.VisibleIndex = 6
        Me.GridColumn7.Width = 199
        '
        'GridColumn1
        '
        Me.GridColumn1.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumn1.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumn1.AppearanceHeader.Options.UseTextOptions = True
        Me.GridColumn1.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.GridColumn1.Caption = "Additional Cost"
        Me.GridColumn1.DisplayFormat.FormatString = "N2"
        Me.GridColumn1.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumn1.FieldName = "cop_pd_addcost"
        Me.GridColumn1.Name = "GridColumn1"
        Me.GridColumn1.Visible = True
        Me.GridColumn1.VisibleIndex = 7
        Me.GridColumn1.Width = 142
        '
        'PanelControl1
        '
        Me.PanelControl1.Controls.Add(Me.BSearch)
        Me.PanelControl1.Controls.Add(Me.LabelControl2)
        Me.PanelControl1.Controls.Add(Me.SLESource)
        Me.PanelControl1.Controls.Add(Me.LabelControl1)
        Me.PanelControl1.Controls.Add(Me.SLEClass)
        Me.PanelControl1.Dock = System.Windows.Forms.DockStyle.Top
        Me.PanelControl1.Location = New System.Drawing.Point(0, 0)
        Me.PanelControl1.Name = "PanelControl1"
        Me.PanelControl1.Size = New System.Drawing.Size(980, 40)
        Me.PanelControl1.TabIndex = 2
        '
        'BSearch
        '
        Me.BSearch.Location = New System.Drawing.Point(570, 10)
        Me.BSearch.Name = "BSearch"
        Me.BSearch.Size = New System.Drawing.Size(56, 23)
        Me.BSearch.TabIndex = 4
        Me.BSearch.Text = "view"
        '
        'LabelControl2
        '
        Me.LabelControl2.Location = New System.Drawing.Point(287, 15)
        Me.LabelControl2.Name = "LabelControl2"
        Me.LabelControl2.Size = New System.Drawing.Size(33, 13)
        Me.LabelControl2.TabIndex = 3
        Me.LabelControl2.Text = "Source"
        '
        'SLESource
        '
        Me.SLESource.Location = New System.Drawing.Point(326, 12)
        Me.SLESource.Name = "SLESource"
        Me.SLESource.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.SLESource.Properties.View = Me.GridView1
        Me.SLESource.Size = New System.Drawing.Size(238, 20)
        Me.SLESource.TabIndex = 2
        '
        'GridView1
        '
        Me.GridView1.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumn10, Me.GridColumn11, Me.GridColumn12})
        Me.GridView1.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
        Me.GridView1.Name = "GridView1"
        Me.GridView1.OptionsSelection.EnableAppearanceFocusedCell = False
        Me.GridView1.OptionsView.ShowGroupPanel = False
        '
        'GridColumn10
        '
        Me.GridColumn10.Caption = "ID Code Detail"
        Me.GridColumn10.FieldName = "id_code_detail"
        Me.GridColumn10.Name = "GridColumn10"
        '
        'GridColumn11
        '
        Me.GridColumn11.Caption = "Detail"
        Me.GridColumn11.FieldName = "code_detail_name"
        Me.GridColumn11.Name = "GridColumn11"
        Me.GridColumn11.Visible = True
        Me.GridColumn11.VisibleIndex = 1
        Me.GridColumn11.Width = 1277
        '
        'GridColumn12
        '
        Me.GridColumn12.Caption = "Description"
        Me.GridColumn12.FieldName = "display_name"
        Me.GridColumn12.Name = "GridColumn12"
        Me.GridColumn12.Visible = True
        Me.GridColumn12.VisibleIndex = 0
        Me.GridColumn12.Width = 355
        '
        'LabelControl1
        '
        Me.LabelControl1.Location = New System.Drawing.Point(12, 15)
        Me.LabelControl1.Name = "LabelControl1"
        Me.LabelControl1.Size = New System.Drawing.Size(25, 13)
        Me.LabelControl1.TabIndex = 1
        Me.LabelControl1.Text = "Class"
        '
        'SLEClass
        '
        Me.SLEClass.Location = New System.Drawing.Point(43, 12)
        Me.SLEClass.Name = "SLEClass"
        Me.SLEClass.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.SLEClass.Properties.View = Me.SearchLookUpEdit1View
        Me.SLEClass.Size = New System.Drawing.Size(238, 20)
        Me.SLEClass.TabIndex = 0
        '
        'SearchLookUpEdit1View
        '
        Me.SearchLookUpEdit1View.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumn8, Me.GridColumn9, Me.GridColumn13})
        Me.SearchLookUpEdit1View.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
        Me.SearchLookUpEdit1View.Name = "SearchLookUpEdit1View"
        Me.SearchLookUpEdit1View.OptionsSelection.EnableAppearanceFocusedCell = False
        Me.SearchLookUpEdit1View.OptionsView.ShowGroupPanel = False
        '
        'GridColumn8
        '
        Me.GridColumn8.Caption = "ID Code Detail"
        Me.GridColumn8.FieldName = "id_code_detail"
        Me.GridColumn8.Name = "GridColumn8"
        '
        'GridColumn9
        '
        Me.GridColumn9.Caption = "Detail"
        Me.GridColumn9.FieldName = "code_detail_name"
        Me.GridColumn9.Name = "GridColumn9"
        Me.GridColumn9.Visible = True
        Me.GridColumn9.VisibleIndex = 1
        Me.GridColumn9.Width = 1316
        '
        'GridColumn13
        '
        Me.GridColumn13.Caption = "Description"
        Me.GridColumn13.FieldName = "display_name"
        Me.GridColumn13.Name = "GridColumn13"
        Me.GridColumn13.Visible = True
        Me.GridColumn13.VisibleIndex = 0
        Me.GridColumn13.Width = 316
        '
        'GridColumn14
        '
        Me.GridColumn14.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumn14.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridColumn14.AppearanceHeader.Options.UseTextOptions = True
        Me.GridColumn14.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridColumn14.Caption = "Season"
        Me.GridColumn14.FieldName = "season"
        Me.GridColumn14.Name = "GridColumn14"
        Me.GridColumn14.Visible = True
        Me.GridColumn14.VisibleIndex = 1
        Me.GridColumn14.Width = 96
        '
        'FormMasterDesignCOPHistory
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(980, 571)
        Me.Controls.Add(Me.GCCOPHistory)
        Me.Controls.Add(Me.PanelControl1)
        Me.Controls.Add(Me.BPrint)
        Me.MinimizeBox = False
        Me.Name = "FormMasterDesignCOPHistory"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Design COP History"
        CType(Me.GCCOPHistory, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVCOPHistory, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl1.ResumeLayout(False)
        Me.PanelControl1.PerformLayout()
        CType(Me.SLESource.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SLEClass.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SearchLookUpEdit1View, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents BPrint As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents GCCOPHistory As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVCOPHistory As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumn2 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn3 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn4 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn5 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn6 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn7 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents PanelControl1 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents LabelControl2 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents SLESource As DevExpress.XtraEditors.SearchLookUpEdit
    Friend WithEvents GridView1 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents LabelControl1 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents SLEClass As DevExpress.XtraEditors.SearchLookUpEdit
    Friend WithEvents SearchLookUpEdit1View As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumn1 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents BSearch As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents GridColumn8 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn9 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn10 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn11 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn12 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn13 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn14 As DevExpress.XtraGrid.Columns.GridColumn
End Class
