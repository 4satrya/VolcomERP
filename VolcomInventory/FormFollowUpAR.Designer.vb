<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormFollowUpAR
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormFollowUpAR))
        Me.PanelControl1 = New DevExpress.XtraEditors.PanelControl()
        Me.BtnExportToXLSTrf = New DevExpress.XtraEditors.SimpleButton()
        Me.CEPromo = New DevExpress.XtraEditors.CheckEdit()
        Me.CEShowHighlight = New DevExpress.XtraEditors.CheckEdit()
        Me.SLEStoreGroup = New DevExpress.XtraEditors.SearchLookUpEdit()
        Me.GridView3 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumnid_comp_group = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumncomp_group = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumndescription = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.BView = New DevExpress.XtraEditors.SimpleButton()
        Me.LabelControl3 = New DevExpress.XtraEditors.LabelControl()
        Me.SLEStatusInvoice = New DevExpress.XtraEditors.SearchLookUpEdit()
        Me.GridView5 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumn16 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn17 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.SLEStoreInvoice = New DevExpress.XtraEditors.SearchLookUpEdit()
        Me.GridView2 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumn13 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn14 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.LabelControl5 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl2 = New DevExpress.XtraEditors.LabelControl()
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl1.SuspendLayout()
        CType(Me.CEPromo.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CEShowHighlight.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SLEStoreGroup.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SLEStatusInvoice.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SLEStoreInvoice.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PanelControl1
        '
        Me.PanelControl1.Controls.Add(Me.BtnExportToXLSTrf)
        Me.PanelControl1.Controls.Add(Me.CEPromo)
        Me.PanelControl1.Controls.Add(Me.CEShowHighlight)
        Me.PanelControl1.Controls.Add(Me.SLEStoreGroup)
        Me.PanelControl1.Controls.Add(Me.BView)
        Me.PanelControl1.Controls.Add(Me.LabelControl3)
        Me.PanelControl1.Controls.Add(Me.SLEStatusInvoice)
        Me.PanelControl1.Controls.Add(Me.SLEStoreInvoice)
        Me.PanelControl1.Controls.Add(Me.LabelControl5)
        Me.PanelControl1.Controls.Add(Me.LabelControl2)
        Me.PanelControl1.Dock = System.Windows.Forms.DockStyle.Top
        Me.PanelControl1.Location = New System.Drawing.Point(0, 0)
        Me.PanelControl1.Name = "PanelControl1"
        Me.PanelControl1.Size = New System.Drawing.Size(1019, 43)
        Me.PanelControl1.TabIndex = 4
        '
        'BtnExportToXLSTrf
        '
        Me.BtnExportToXLSTrf.Image = CType(resources.GetObject("BtnExportToXLSTrf.Image"), System.Drawing.Image)
        Me.BtnExportToXLSTrf.Location = New System.Drawing.Point(866, 12)
        Me.BtnExportToXLSTrf.LookAndFeel.SkinName = "Blue"
        Me.BtnExportToXLSTrf.Name = "BtnExportToXLSTrf"
        Me.BtnExportToXLSTrf.Size = New System.Drawing.Size(106, 20)
        Me.BtnExportToXLSTrf.TabIndex = 8926
        Me.BtnExportToXLSTrf.Text = "Export to XLS"
        '
        'CEPromo
        '
        Me.CEPromo.Location = New System.Drawing.Point(610, 12)
        Me.CEPromo.Name = "CEPromo"
        Me.CEPromo.Properties.Caption = "Include Promo"
        Me.CEPromo.Size = New System.Drawing.Size(89, 19)
        Me.CEPromo.TabIndex = 8925
        '
        'CEShowHighlight
        '
        Me.CEShowHighlight.Location = New System.Drawing.Point(706, 12)
        Me.CEShowHighlight.Name = "CEShowHighlight"
        Me.CEShowHighlight.Properties.Caption = "Show Highlight"
        Me.CEShowHighlight.Size = New System.Drawing.Size(90, 19)
        Me.CEShowHighlight.TabIndex = 8924
        '
        'SLEStoreGroup
        '
        Me.SLEStoreGroup.Location = New System.Drawing.Point(79, 12)
        Me.SLEStoreGroup.Name = "SLEStoreGroup"
        Me.SLEStoreGroup.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.SLEStoreGroup.Properties.View = Me.GridView3
        Me.SLEStoreGroup.Size = New System.Drawing.Size(145, 20)
        Me.SLEStoreGroup.TabIndex = 8923
        '
        'GridView3
        '
        Me.GridView3.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumnid_comp_group, Me.GridColumncomp_group, Me.GridColumndescription})
        Me.GridView3.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
        Me.GridView3.Name = "GridView3"
        Me.GridView3.OptionsSelection.EnableAppearanceFocusedCell = False
        Me.GridView3.OptionsView.ShowGroupPanel = False
        '
        'GridColumnid_comp_group
        '
        Me.GridColumnid_comp_group.Caption = "id_comp_group"
        Me.GridColumnid_comp_group.FieldName = "id_comp_group"
        Me.GridColumnid_comp_group.Name = "GridColumnid_comp_group"
        '
        'GridColumncomp_group
        '
        Me.GridColumncomp_group.Caption = "Group"
        Me.GridColumncomp_group.FieldName = "comp_group"
        Me.GridColumncomp_group.Name = "GridColumncomp_group"
        Me.GridColumncomp_group.Visible = True
        Me.GridColumncomp_group.VisibleIndex = 0
        '
        'GridColumndescription
        '
        Me.GridColumndescription.Caption = "Description"
        Me.GridColumndescription.FieldName = "description"
        Me.GridColumndescription.Name = "GridColumndescription"
        Me.GridColumndescription.Visible = True
        Me.GridColumndescription.VisibleIndex = 1
        '
        'BView
        '
        Me.BView.Image = CType(resources.GetObject("BView.Image"), System.Drawing.Image)
        Me.BView.Location = New System.Drawing.Point(802, 12)
        Me.BView.Name = "BView"
        Me.BView.Size = New System.Drawing.Size(60, 20)
        Me.BView.TabIndex = 8913
        Me.BView.Text = "View"
        '
        'LabelControl3
        '
        Me.LabelControl3.Location = New System.Drawing.Point(15, 15)
        Me.LabelControl3.Name = "LabelControl3"
        Me.LabelControl3.Size = New System.Drawing.Size(58, 13)
        Me.LabelControl3.TabIndex = 8922
        Me.LabelControl3.Text = "Store Group"
        '
        'SLEStatusInvoice
        '
        Me.SLEStatusInvoice.Location = New System.Drawing.Point(481, 12)
        Me.SLEStatusInvoice.Name = "SLEStatusInvoice"
        Me.SLEStatusInvoice.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.SLEStatusInvoice.Properties.View = Me.GridView5
        Me.SLEStatusInvoice.Size = New System.Drawing.Size(123, 20)
        Me.SLEStatusInvoice.TabIndex = 8919
        '
        'GridView5
        '
        Me.GridView5.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumn16, Me.GridColumn17})
        Me.GridView5.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
        Me.GridView5.Name = "GridView5"
        Me.GridView5.OptionsSelection.EnableAppearanceFocusedCell = False
        Me.GridView5.OptionsView.ShowGroupPanel = False
        '
        'GridColumn16
        '
        Me.GridColumn16.Caption = "ID Status payment"
        Me.GridColumn16.FieldName = "id_status_payment"
        Me.GridColumn16.Name = "GridColumn16"
        '
        'GridColumn17
        '
        Me.GridColumn17.Caption = "Status"
        Me.GridColumn17.FieldName = "status_payment"
        Me.GridColumn17.Name = "GridColumn17"
        Me.GridColumn17.Visible = True
        Me.GridColumn17.VisibleIndex = 0
        '
        'SLEStoreInvoice
        '
        Me.SLEStoreInvoice.Location = New System.Drawing.Point(262, 12)
        Me.SLEStoreInvoice.Name = "SLEStoreInvoice"
        Me.SLEStoreInvoice.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.SLEStoreInvoice.Properties.View = Me.GridView2
        Me.SLEStoreInvoice.Size = New System.Drawing.Size(177, 20)
        Me.SLEStoreInvoice.TabIndex = 8912
        '
        'GridView2
        '
        Me.GridView2.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumn13, Me.GridColumn14})
        Me.GridView2.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
        Me.GridView2.Name = "GridView2"
        Me.GridView2.OptionsSelection.EnableAppearanceFocusedCell = False
        Me.GridView2.OptionsView.ShowGroupPanel = False
        '
        'GridColumn13
        '
        Me.GridColumn13.Caption = "ID Comp Contact"
        Me.GridColumn13.FieldName = "id_comp"
        Me.GridColumn13.Name = "GridColumn13"
        '
        'GridColumn14
        '
        Me.GridColumn14.Caption = "Store"
        Me.GridColumn14.FieldName = "comp_name"
        Me.GridColumn14.Name = "GridColumn14"
        Me.GridColumn14.Visible = True
        Me.GridColumn14.VisibleIndex = 0
        '
        'LabelControl5
        '
        Me.LabelControl5.Location = New System.Drawing.Point(444, 15)
        Me.LabelControl5.Name = "LabelControl5"
        Me.LabelControl5.Size = New System.Drawing.Size(31, 13)
        Me.LabelControl5.TabIndex = 8918
        Me.LabelControl5.Text = "Status"
        '
        'LabelControl2
        '
        Me.LabelControl2.Location = New System.Drawing.Point(230, 15)
        Me.LabelControl2.Name = "LabelControl2"
        Me.LabelControl2.Size = New System.Drawing.Size(26, 13)
        Me.LabelControl2.TabIndex = 8911
        Me.LabelControl2.Text = "Store"
        '
        'FormFollowUpAR
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1019, 439)
        Me.Controls.Add(Me.PanelControl1)
        Me.Name = "FormFollowUpAR"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Follow Up AR"
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl1.ResumeLayout(False)
        Me.PanelControl1.PerformLayout()
        CType(Me.CEPromo.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CEShowHighlight.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SLEStoreGroup.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SLEStatusInvoice.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SLEStoreInvoice.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents PanelControl1 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents BtnExportToXLSTrf As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents CEPromo As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents CEShowHighlight As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents SLEStoreGroup As DevExpress.XtraEditors.SearchLookUpEdit
    Friend WithEvents GridView3 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumnid_comp_group As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumncomp_group As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumndescription As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents BView As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents LabelControl3 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents SLEStatusInvoice As DevExpress.XtraEditors.SearchLookUpEdit
    Friend WithEvents GridView5 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumn16 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn17 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents SLEStoreInvoice As DevExpress.XtraEditors.SearchLookUpEdit
    Friend WithEvents GridView2 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumn13 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn14 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents LabelControl5 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl2 As DevExpress.XtraEditors.LabelControl
End Class
