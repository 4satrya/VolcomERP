<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormProdDemandRevSingle
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormProdDemandRevSingle))
        Me.RepositoryItemTextEdit1 = New DevExpress.XtraEditors.Repository.RepositoryItemTextEdit()
        Me.RepositoryItemCheckEdit1 = New DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit()
        Me.PanelControl1 = New DevExpress.XtraEditors.PanelControl()
        Me.SLETypeLineList = New DevExpress.XtraEditors.SearchLookUpEdit()
        Me.GridView4 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumn2 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn3 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.LabelControl1 = New DevExpress.XtraEditors.LabelControl()
        Me.BtnDrop = New DevExpress.XtraEditors.SimpleButton()
        Me.BtnRevise = New DevExpress.XtraEditors.SimpleButton()
        Me.GCDesign = New DevExpress.XtraGrid.GridControl()
        Me.GVDesign = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumnIdProdDemandDesign = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumncode = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnName = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnOrderNumber = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnOrder = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnRevdobe = New DevExpress.XtraGrid.Columns.GridColumn()
        CType(Me.RepositoryItemTextEdit1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemCheckEdit1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl1.SuspendLayout()
        CType(Me.SLETypeLineList.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GCDesign, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVDesign, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'RepositoryItemTextEdit1
        '
        Me.RepositoryItemTextEdit1.AutoHeight = False
        Me.RepositoryItemTextEdit1.Name = "RepositoryItemTextEdit1"
        Me.RepositoryItemTextEdit1.NullText = "-"
        '
        'RepositoryItemCheckEdit1
        '
        Me.RepositoryItemCheckEdit1.AutoHeight = False
        Me.RepositoryItemCheckEdit1.Name = "RepositoryItemCheckEdit1"
        Me.RepositoryItemCheckEdit1.ValueChecked = "Yes"
        Me.RepositoryItemCheckEdit1.ValueUnchecked = "No"
        '
        'PanelControl1
        '
        Me.PanelControl1.Controls.Add(Me.SLETypeLineList)
        Me.PanelControl1.Controls.Add(Me.LabelControl1)
        Me.PanelControl1.Controls.Add(Me.BtnDrop)
        Me.PanelControl1.Controls.Add(Me.BtnRevise)
        Me.PanelControl1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PanelControl1.Location = New System.Drawing.Point(0, 326)
        Me.PanelControl1.Name = "PanelControl1"
        Me.PanelControl1.Size = New System.Drawing.Size(717, 43)
        Me.PanelControl1.TabIndex = 0
        '
        'SLETypeLineList
        '
        Me.SLETypeLineList.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.SLETypeLineList.Location = New System.Drawing.Point(92, 12)
        Me.SLETypeLineList.Name = "SLETypeLineList"
        Me.SLETypeLineList.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.SLETypeLineList.Properties.NullText = ""
        Me.SLETypeLineList.Properties.ShowFooter = False
        Me.SLETypeLineList.Properties.View = Me.GridView4
        Me.SLETypeLineList.Size = New System.Drawing.Size(238, 20)
        Me.SLETypeLineList.TabIndex = 95
        '
        'GridView4
        '
        Me.GridView4.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumn2, Me.GridColumn3})
        Me.GridView4.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
        Me.GridView4.Name = "GridView4"
        Me.GridView4.OptionsSelection.EnableAppearanceFocusedCell = False
        Me.GridView4.OptionsView.ShowGroupPanel = False
        '
        'GridColumn2
        '
        Me.GridColumn2.Caption = "Id PD TYPE"
        Me.GridColumn2.FieldName = "id_pd_type"
        Me.GridColumn2.Name = "GridColumn2"
        '
        'GridColumn3
        '
        Me.GridColumn3.Caption = "Type"
        Me.GridColumn3.FieldName = "pd_type"
        Me.GridColumn3.Name = "GridColumn3"
        Me.GridColumn3.Visible = True
        Me.GridColumn3.VisibleIndex = 0
        '
        'LabelControl1
        '
        Me.LabelControl1.Location = New System.Drawing.Point(12, 15)
        Me.LabelControl1.Name = "LabelControl1"
        Me.LabelControl1.Size = New System.Drawing.Size(74, 13)
        Me.LabelControl1.TabIndex = 94
        Me.LabelControl1.Text = "Line List Source"
        '
        'BtnDrop
        '
        Me.BtnDrop.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnDrop.Appearance.Options.UseFont = True
        Me.BtnDrop.Dock = System.Windows.Forms.DockStyle.Right
        Me.BtnDrop.Image = CType(resources.GetObject("BtnDrop.Image"), System.Drawing.Image)
        Me.BtnDrop.Location = New System.Drawing.Point(525, 2)
        Me.BtnDrop.LookAndFeel.SkinName = "Office 2007 Pink"
        Me.BtnDrop.LookAndFeel.UseDefaultLookAndFeel = False
        Me.BtnDrop.Name = "BtnDrop"
        Me.BtnDrop.Size = New System.Drawing.Size(95, 39)
        Me.BtnDrop.TabIndex = 1
        Me.BtnDrop.Text = "Drop"
        '
        'BtnRevise
        '
        Me.BtnRevise.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnRevise.Appearance.Options.UseFont = True
        Me.BtnRevise.Dock = System.Windows.Forms.DockStyle.Right
        Me.BtnRevise.Image = CType(resources.GetObject("BtnRevise.Image"), System.Drawing.Image)
        Me.BtnRevise.Location = New System.Drawing.Point(620, 2)
        Me.BtnRevise.LookAndFeel.SkinName = "Office 2007 Green"
        Me.BtnRevise.LookAndFeel.UseDefaultLookAndFeel = False
        Me.BtnRevise.Name = "BtnRevise"
        Me.BtnRevise.Size = New System.Drawing.Size(95, 39)
        Me.BtnRevise.TabIndex = 0
        Me.BtnRevise.Text = "Revise"
        '
        'GCDesign
        '
        Me.GCDesign.Location = New System.Drawing.Point(0, 0)
        Me.GCDesign.MainView = Me.GVDesign
        Me.GCDesign.Name = "GCDesign"
        Me.GCDesign.Size = New System.Drawing.Size(717, 326)
        Me.GCDesign.TabIndex = 1
        Me.GCDesign.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVDesign})
        '
        'GVDesign
        '
        Me.GVDesign.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumnIdProdDemandDesign, Me.GridColumncode, Me.GridColumnName, Me.GridColumnOrderNumber, Me.GridColumnOrder, Me.GridColumnRevdobe})
        Me.GVDesign.GridControl = Me.GCDesign
        Me.GVDesign.Name = "GVDesign"
        Me.GVDesign.OptionsBehavior.AutoExpandAllGroups = True
        Me.GVDesign.OptionsView.ShowGroupPanel = False
        '
        'GridColumnIdProdDemandDesign
        '
        Me.GridColumnIdProdDemandDesign.Caption = "Id Prod Demand Design"
        Me.GridColumnIdProdDemandDesign.FieldName = "id_prod_demand_design"
        Me.GridColumnIdProdDemandDesign.Name = "GridColumnIdProdDemandDesign"
        Me.GridColumnIdProdDemandDesign.OptionsColumn.AllowEdit = False
        '
        'GridColumncode
        '
        Me.GridColumncode.Caption = "Code"
        Me.GridColumncode.FieldName = "code"
        Me.GridColumncode.Name = "GridColumncode"
        Me.GridColumncode.OptionsColumn.AllowEdit = False
        Me.GridColumncode.Visible = True
        Me.GridColumncode.VisibleIndex = 0
        '
        'GridColumnName
        '
        Me.GridColumnName.Caption = "Description"
        Me.GridColumnName.FieldName = "name"
        Me.GridColumnName.Name = "GridColumnName"
        Me.GridColumnName.OptionsColumn.AllowEdit = False
        Me.GridColumnName.Visible = True
        Me.GridColumnName.VisibleIndex = 1
        '
        'GridColumnOrderNumber
        '
        Me.GridColumnOrderNumber.Caption = "FG PO"
        Me.GridColumnOrderNumber.ColumnEdit = Me.RepositoryItemTextEdit1
        Me.GridColumnOrderNumber.FieldName = "prod_order_number"
        Me.GridColumnOrderNumber.Name = "GridColumnOrderNumber"
        Me.GridColumnOrderNumber.OptionsColumn.AllowEdit = False
        Me.GridColumnOrderNumber.Visible = True
        Me.GridColumnOrderNumber.VisibleIndex = 2
        '
        'GridColumnOrder
        '
        Me.GridColumnOrder.Caption = "Ordered"
        Me.GridColumnOrder.DisplayFormat.FormatString = "n0"
        Me.GridColumnOrder.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumnOrder.FieldName = "ordered"
        Me.GridColumnOrder.Name = "GridColumnOrder"
        Me.GridColumnOrder.OptionsColumn.AllowEdit = False
        Me.GridColumnOrder.Visible = True
        Me.GridColumnOrder.VisibleIndex = 3
        '
        'GridColumnRevdobe
        '
        Me.GridColumnRevdobe.Caption = "Received"
        Me.GridColumnRevdobe.DisplayFormat.FormatString = "n0"
        Me.GridColumnRevdobe.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumnRevdobe.FieldName = "received"
        Me.GridColumnRevdobe.Name = "GridColumnRevdobe"
        Me.GridColumnRevdobe.OptionsColumn.AllowEdit = False
        Me.GridColumnRevdobe.Visible = True
        Me.GridColumnRevdobe.VisibleIndex = 4
        '
        'FormProdDemandRevSingle
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(717, 369)
        Me.Controls.Add(Me.GCDesign)
        Me.Controls.Add(Me.PanelControl1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FormProdDemandRevSingle"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Select article"
        CType(Me.RepositoryItemTextEdit1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemCheckEdit1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl1.ResumeLayout(False)
        Me.PanelControl1.PerformLayout()
        CType(Me.SLETypeLineList.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GCDesign, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVDesign, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents PanelControl1 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents BtnDrop As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BtnRevise As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents GCDesign As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVDesign As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumnIdProdDemandDesign As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumncode As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnName As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnOrderNumber As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnOrder As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnRevdobe As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents SLETypeLineList As DevExpress.XtraEditors.SearchLookUpEdit
    Friend WithEvents GridView4 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumn2 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn3 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents LabelControl1 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents RepositoryItemTextEdit1 As DevExpress.XtraEditors.Repository.RepositoryItemTextEdit
    Friend WithEvents RepositoryItemCheckEdit1 As DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit
End Class
