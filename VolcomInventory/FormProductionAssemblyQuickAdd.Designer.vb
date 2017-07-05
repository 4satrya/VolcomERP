<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormProductionAssemblyQuickAdd
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormProductionAssemblyQuickAdd))
        Me.PanelControl1 = New DevExpress.XtraEditors.PanelControl()
        Me.BtnCancelComp = New DevExpress.XtraEditors.SimpleButton()
        Me.BtnAddComponent = New DevExpress.XtraEditors.SimpleButton()
        Me.GCComponent = New DevExpress.XtraGrid.GridControl()
        Me.GVComponent = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumnIdCompDet = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnIdDetail = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnIdPODet = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnIdProductComp = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnCodeComp = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnNameComp = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnCompSize = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnCompQty = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnCompNo = New DevExpress.XtraGrid.Columns.GridColumn()
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl1.SuspendLayout()
        CType(Me.GCComponent, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVComponent, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PanelControl1
        '
        Me.PanelControl1.Controls.Add(Me.BtnCancelComp)
        Me.PanelControl1.Controls.Add(Me.BtnAddComponent)
        Me.PanelControl1.Dock = System.Windows.Forms.DockStyle.Top
        Me.PanelControl1.Location = New System.Drawing.Point(0, 0)
        Me.PanelControl1.Name = "PanelControl1"
        Me.PanelControl1.Size = New System.Drawing.Size(700, 37)
        Me.PanelControl1.TabIndex = 0
        '
        'BtnCancelComp
        '
        Me.BtnCancelComp.Dock = System.Windows.Forms.DockStyle.Right
        Me.BtnCancelComp.Image = CType(resources.GetObject("BtnCancelComp.Image"), System.Drawing.Image)
        Me.BtnCancelComp.Location = New System.Drawing.Point(492, 2)
        Me.BtnCancelComp.Name = "BtnCancelComp"
        Me.BtnCancelComp.Size = New System.Drawing.Size(80, 33)
        Me.BtnCancelComp.TabIndex = 2
        Me.BtnCancelComp.Text = "Cancel"
        '
        'BtnAddComponent
        '
        Me.BtnAddComponent.Dock = System.Windows.Forms.DockStyle.Right
        Me.BtnAddComponent.Image = CType(resources.GetObject("BtnAddComponent.Image"), System.Drawing.Image)
        Me.BtnAddComponent.Location = New System.Drawing.Point(572, 2)
        Me.BtnAddComponent.Name = "BtnAddComponent"
        Me.BtnAddComponent.Size = New System.Drawing.Size(126, 33)
        Me.BtnAddComponent.TabIndex = 1
        Me.BtnAddComponent.Text = "Add Component"
        '
        'GCComponent
        '
        Me.GCComponent.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCComponent.Location = New System.Drawing.Point(0, 37)
        Me.GCComponent.MainView = Me.GVComponent
        Me.GCComponent.Name = "GCComponent"
        Me.GCComponent.Size = New System.Drawing.Size(700, 305)
        Me.GCComponent.TabIndex = 2
        Me.GCComponent.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVComponent})
        '
        'GVComponent
        '
        Me.GVComponent.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumnIdCompDet, Me.GridColumnIdDetail, Me.GridColumnIdPODet, Me.GridColumnIdProductComp, Me.GridColumnCodeComp, Me.GridColumnNameComp, Me.GridColumnCompSize, Me.GridColumnCompQty, Me.GridColumnCompNo})
        Me.GVComponent.GridControl = Me.GCComponent
        Me.GVComponent.GroupSummary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "prod_ass_comp_qty_det", Me.GridColumnCompQty, "{0:n0}")})
        Me.GVComponent.Name = "GVComponent"
        Me.GVComponent.OptionsBehavior.Editable = False
        Me.GVComponent.OptionsView.ShowFooter = True
        Me.GVComponent.OptionsView.ShowGroupPanel = False
        '
        'GridColumnIdCompDet
        '
        Me.GridColumnIdCompDet.Caption = "Id Comp Det"
        Me.GridColumnIdCompDet.FieldName = "id_prod_ass_comp_det"
        Me.GridColumnIdCompDet.Name = "GridColumnIdCompDet"
        Me.GridColumnIdCompDet.OptionsColumn.ShowInCustomizationForm = False
        '
        'GridColumnIdDetail
        '
        Me.GridColumnIdDetail.Caption = "Id Detail"
        Me.GridColumnIdDetail.FieldName = "id_prod_ass_det"
        Me.GridColumnIdDetail.Name = "GridColumnIdDetail"
        Me.GridColumnIdDetail.OptionsColumn.ShowInCustomizationForm = False
        '
        'GridColumnIdPODet
        '
        Me.GridColumnIdPODet.Caption = "Id PO Det"
        Me.GridColumnIdPODet.FieldName = "id_prod_order_det"
        Me.GridColumnIdPODet.Name = "GridColumnIdPODet"
        Me.GridColumnIdPODet.OptionsColumn.ShowInCustomizationForm = False
        '
        'GridColumnIdProductComp
        '
        Me.GridColumnIdProductComp.Caption = "Id Product"
        Me.GridColumnIdProductComp.FieldName = "id_product"
        Me.GridColumnIdProductComp.Name = "GridColumnIdProductComp"
        Me.GridColumnIdProductComp.OptionsColumn.ShowInCustomizationForm = False
        '
        'GridColumnCodeComp
        '
        Me.GridColumnCodeComp.Caption = "Code"
        Me.GridColumnCodeComp.FieldName = "code"
        Me.GridColumnCodeComp.Name = "GridColumnCodeComp"
        Me.GridColumnCodeComp.Visible = True
        Me.GridColumnCodeComp.VisibleIndex = 0
        Me.GridColumnCodeComp.Width = 161
        '
        'GridColumnNameComp
        '
        Me.GridColumnNameComp.Caption = "Design"
        Me.GridColumnNameComp.FieldName = "name"
        Me.GridColumnNameComp.Name = "GridColumnNameComp"
        Me.GridColumnNameComp.Visible = True
        Me.GridColumnNameComp.VisibleIndex = 1
        Me.GridColumnNameComp.Width = 732
        '
        'GridColumnCompSize
        '
        Me.GridColumnCompSize.Caption = "Size"
        Me.GridColumnCompSize.FieldName = "size"
        Me.GridColumnCompSize.Name = "GridColumnCompSize"
        Me.GridColumnCompSize.Visible = True
        Me.GridColumnCompSize.VisibleIndex = 2
        Me.GridColumnCompSize.Width = 74
        '
        'GridColumnCompQty
        '
        Me.GridColumnCompQty.Caption = "Qty"
        Me.GridColumnCompQty.DisplayFormat.FormatString = "{0:n0}"
        Me.GridColumnCompQty.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumnCompQty.FieldName = "prod_ass_comp_qty_det"
        Me.GridColumnCompQty.Name = "GridColumnCompQty"
        Me.GridColumnCompQty.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "prod_ass_comp_qty_det", "{0:n0}")})
        Me.GridColumnCompQty.Visible = True
        Me.GridColumnCompQty.VisibleIndex = 3
        Me.GridColumnCompQty.Width = 66
        '
        'GridColumnCompNo
        '
        Me.GridColumnCompNo.Caption = "No"
        Me.GridColumnCompNo.FieldName = "no"
        Me.GridColumnCompNo.Name = "GridColumnCompNo"
        Me.GridColumnCompNo.Width = 45
        '
        'FormProductionAssemblyQuickAdd
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(700, 342)
        Me.Controls.Add(Me.GCComponent)
        Me.Controls.Add(Me.PanelControl1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FormProductionAssemblyQuickAdd"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Assembly - Quick Add Component"
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl1.ResumeLayout(False)
        CType(Me.GCComponent, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVComponent, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents PanelControl1 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents BtnCancelComp As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BtnAddComponent As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents GCComponent As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVComponent As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumnIdCompDet As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnIdDetail As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnIdPODet As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnIdProductComp As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnCodeComp As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnNameComp As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnCompSize As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnCompQty As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnCompNo As DevExpress.XtraGrid.Columns.GridColumn
End Class
