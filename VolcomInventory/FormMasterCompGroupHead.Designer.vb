<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormMasterCompGroupHead
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormMasterCompGroupHead))
        Me.PanelControl1 = New DevExpress.XtraEditors.PanelControl()
        Me.SimpleButtonRemove = New DevExpress.XtraEditors.SimpleButton()
        Me.SimpleButtonEdit = New DevExpress.XtraEditors.SimpleButton()
        Me.SimpleButtonAdd = New DevExpress.XtraEditors.SimpleButton()
        Me.GCGroupComp = New DevExpress.XtraGrid.GridControl()
        Me.GVGroupComp = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.id_company = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnGroupHeader = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn1 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.is_active_company = New DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit()
        Me.RepositoryItemCheckEdit1 = New DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit()
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl1.SuspendLayout()
        CType(Me.GCGroupComp, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVGroupComp, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.is_active_company, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemCheckEdit1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PanelControl1
        '
        Me.PanelControl1.Controls.Add(Me.SimpleButtonRemove)
        Me.PanelControl1.Controls.Add(Me.SimpleButtonEdit)
        Me.PanelControl1.Controls.Add(Me.SimpleButtonAdd)
        Me.PanelControl1.Dock = System.Windows.Forms.DockStyle.Top
        Me.PanelControl1.Location = New System.Drawing.Point(0, 0)
        Me.PanelControl1.Name = "PanelControl1"
        Me.PanelControl1.Size = New System.Drawing.Size(784, 44)
        Me.PanelControl1.TabIndex = 0
        '
        'SimpleButtonRemove
        '
        Me.SimpleButtonRemove.Dock = System.Windows.Forms.DockStyle.Right
        Me.SimpleButtonRemove.Image = CType(resources.GetObject("SimpleButtonRemove.Image"), System.Drawing.Image)
        Me.SimpleButtonRemove.Location = New System.Drawing.Point(567, 2)
        Me.SimpleButtonRemove.Name = "SimpleButtonRemove"
        Me.SimpleButtonRemove.Size = New System.Drawing.Size(81, 40)
        Me.SimpleButtonRemove.TabIndex = 2
        Me.SimpleButtonRemove.Text = "Remove"
        '
        'SimpleButtonEdit
        '
        Me.SimpleButtonEdit.Dock = System.Windows.Forms.DockStyle.Right
        Me.SimpleButtonEdit.Image = CType(resources.GetObject("SimpleButtonEdit.Image"), System.Drawing.Image)
        Me.SimpleButtonEdit.Location = New System.Drawing.Point(648, 2)
        Me.SimpleButtonEdit.Name = "SimpleButtonEdit"
        Me.SimpleButtonEdit.Size = New System.Drawing.Size(67, 40)
        Me.SimpleButtonEdit.TabIndex = 1
        Me.SimpleButtonEdit.Text = "Edit"
        '
        'SimpleButtonAdd
        '
        Me.SimpleButtonAdd.Dock = System.Windows.Forms.DockStyle.Right
        Me.SimpleButtonAdd.Image = CType(resources.GetObject("SimpleButtonAdd.Image"), System.Drawing.Image)
        Me.SimpleButtonAdd.Location = New System.Drawing.Point(715, 2)
        Me.SimpleButtonAdd.Name = "SimpleButtonAdd"
        Me.SimpleButtonAdd.Size = New System.Drawing.Size(67, 40)
        Me.SimpleButtonAdd.TabIndex = 0
        Me.SimpleButtonAdd.Text = "Add"
        '
        'GCGroupComp
        '
        Me.GCGroupComp.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCGroupComp.Location = New System.Drawing.Point(0, 44)
        Me.GCGroupComp.MainView = Me.GVGroupComp
        Me.GCGroupComp.Name = "GCGroupComp"
        Me.GCGroupComp.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.is_active_company, Me.RepositoryItemCheckEdit1})
        Me.GCGroupComp.Size = New System.Drawing.Size(784, 517)
        Me.GCGroupComp.TabIndex = 5
        Me.GCGroupComp.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVGroupComp})
        '
        'GVGroupComp
        '
        Me.GVGroupComp.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.id_company, Me.GridColumnGroupHeader, Me.GridColumn1})
        Me.GVGroupComp.GridControl = Me.GCGroupComp
        Me.GVGroupComp.Name = "GVGroupComp"
        Me.GVGroupComp.OptionsBehavior.Editable = False
        Me.GVGroupComp.OptionsFind.AlwaysVisible = True
        Me.GVGroupComp.OptionsView.ShowGroupPanel = False
        '
        'id_company
        '
        Me.id_company.Caption = "ID"
        Me.id_company.FieldName = "id_comp_group_header"
        Me.id_company.Name = "id_company"
        '
        'GridColumnGroupHeader
        '
        Me.GridColumnGroupHeader.Caption = "Company Group"
        Me.GridColumnGroupHeader.FieldName = "comp_group_header"
        Me.GridColumnGroupHeader.Name = "GridColumnGroupHeader"
        Me.GridColumnGroupHeader.Visible = True
        Me.GridColumnGroupHeader.VisibleIndex = 0
        '
        'GridColumn1
        '
        Me.GridColumn1.Caption = "Description"
        Me.GridColumn1.FieldName = "description"
        Me.GridColumn1.Name = "GridColumn1"
        Me.GridColumn1.Visible = True
        Me.GridColumn1.VisibleIndex = 1
        '
        'is_active_company
        '
        Me.is_active_company.AutoHeight = False
        Me.is_active_company.DisplayValueChecked = "1"
        Me.is_active_company.DisplayValueUnchecked = "0"
        Me.is_active_company.Name = "is_active_company"
        '
        'RepositoryItemCheckEdit1
        '
        Me.RepositoryItemCheckEdit1.AutoHeight = False
        Me.RepositoryItemCheckEdit1.Name = "RepositoryItemCheckEdit1"
        Me.RepositoryItemCheckEdit1.ValueChecked = New Decimal(New Integer() {1, 0, 0, 0})
        Me.RepositoryItemCheckEdit1.ValueUnchecked = New Decimal(New Integer() {2, 0, 0, 0})
        '
        'FormMasterCompGroupHead
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(784, 561)
        Me.Controls.Add(Me.GCGroupComp)
        Me.Controls.Add(Me.PanelControl1)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FormMasterCompGroupHead"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "FormMasterCompGroupHead"
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl1.ResumeLayout(False)
        CType(Me.GCGroupComp, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVGroupComp, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.is_active_company, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemCheckEdit1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents PanelControl1 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents GCGroupComp As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVGroupComp As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents id_company As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnGroupHeader As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn1 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents is_active_company As DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit
    Friend WithEvents RepositoryItemCheckEdit1 As DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit
    Friend WithEvents SimpleButtonEdit As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents SimpleButtonAdd As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents SimpleButtonRemove As DevExpress.XtraEditors.SimpleButton
End Class
