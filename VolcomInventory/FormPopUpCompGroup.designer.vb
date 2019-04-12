<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormPopUpCompGroup
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormPopUpCompGroup))
        Me.GCGroupComp = New DevExpress.XtraGrid.GridControl()
        Me.GVGroupComp = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.id_company = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnNo = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnGroup = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.is_active_company = New DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit()
        Me.RepositoryItemCheckEdit1 = New DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit()
        Me.LargeImageCollection = New DevExpress.Utils.ImageCollection(Me.components)
        Me.PanelControl3 = New DevExpress.XtraEditors.PanelControl()
        Me.BAddComp = New DevExpress.XtraEditors.SimpleButton()
        Me.GridColumn1 = New DevExpress.XtraGrid.Columns.GridColumn()
        CType(Me.GCGroupComp, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVGroupComp, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.is_active_company, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemCheckEdit1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LargeImageCollection, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PanelControl3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl3.SuspendLayout()
        Me.SuspendLayout()
        '
        'GCGroupComp
        '
        Me.GCGroupComp.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCGroupComp.Location = New System.Drawing.Point(0, 0)
        Me.GCGroupComp.MainView = Me.GVGroupComp
        Me.GCGroupComp.Name = "GCGroupComp"
        Me.GCGroupComp.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.is_active_company, Me.RepositoryItemCheckEdit1})
        Me.GCGroupComp.Size = New System.Drawing.Size(635, 301)
        Me.GCGroupComp.TabIndex = 4
        Me.GCGroupComp.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVGroupComp})
        '
        'GVGroupComp
        '
        Me.GVGroupComp.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.id_company, Me.GridColumnNo, Me.GridColumnGroup, Me.GridColumn1})
        Me.GVGroupComp.GridControl = Me.GCGroupComp
        Me.GVGroupComp.Name = "GVGroupComp"
        Me.GVGroupComp.OptionsBehavior.Editable = False
        Me.GVGroupComp.OptionsFind.AlwaysVisible = True
        Me.GVGroupComp.OptionsView.ShowGroupPanel = False
        '
        'id_company
        '
        Me.id_company.Caption = "ID"
        Me.id_company.FieldName = "id_comp_group"
        Me.id_company.Name = "id_company"
        '
        'GridColumnNo
        '
        Me.GridColumnNo.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumnNo.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridColumnNo.AppearanceHeader.Options.UseTextOptions = True
        Me.GridColumnNo.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridColumnNo.Caption = "No"
        Me.GridColumnNo.FieldName = "no"
        Me.GridColumnNo.Name = "GridColumnNo"
        Me.GridColumnNo.Visible = True
        Me.GridColumnNo.VisibleIndex = 0
        Me.GridColumnNo.Width = 143
        '
        'GridColumnGroup
        '
        Me.GridColumnGroup.Caption = "Company Group"
        Me.GridColumnGroup.FieldName = "comp_group"
        Me.GridColumnGroup.Name = "GridColumnGroup"
        Me.GridColumnGroup.Visible = True
        Me.GridColumnGroup.VisibleIndex = 1
        Me.GridColumnGroup.Width = 210
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
        'LargeImageCollection
        '
        Me.LargeImageCollection.ImageSize = New System.Drawing.Size(24, 24)
        Me.LargeImageCollection.ImageStream = CType(resources.GetObject("LargeImageCollection.ImageStream"), DevExpress.Utils.ImageCollectionStreamer)
        Me.LargeImageCollection.Images.SetKeyName(0, "20_24x24.png")
        Me.LargeImageCollection.Images.SetKeyName(1, "8_24x24.png")
        Me.LargeImageCollection.Images.SetKeyName(2, "23_24x24.png")
        Me.LargeImageCollection.Images.SetKeyName(3, "contact32.png")
        '
        'PanelControl3
        '
        Me.PanelControl3.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
        Me.PanelControl3.Controls.Add(Me.BAddComp)
        Me.PanelControl3.Dock = System.Windows.Forms.DockStyle.Top
        Me.PanelControl3.Location = New System.Drawing.Point(0, 0)
        Me.PanelControl3.Name = "PanelControl3"
        Me.PanelControl3.Size = New System.Drawing.Size(635, 36)
        Me.PanelControl3.TabIndex = 30
        '
        'BAddComp
        '
        Me.BAddComp.Dock = System.Windows.Forms.DockStyle.Right
        Me.BAddComp.ImageIndex = 0
        Me.BAddComp.ImageList = Me.LargeImageCollection
        Me.BAddComp.Location = New System.Drawing.Point(555, 0)
        Me.BAddComp.Name = "BAddComp"
        Me.BAddComp.Size = New System.Drawing.Size(80, 36)
        Me.BAddComp.TabIndex = 1
        Me.BAddComp.Text = "Add"
        '
        'GridColumn1
        '
        Me.GridColumn1.Caption = "Description"
        Me.GridColumn1.FieldName = "description"
        Me.GridColumn1.Name = "GridColumn1"
        Me.GridColumn1.Visible = True
        Me.GridColumn1.VisibleIndex = 2
        Me.GridColumn1.Width = 1258
        '
        'FormPopUpCompGroup
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(635, 301)
        Me.Controls.Add(Me.PanelControl3)
        Me.Controls.Add(Me.GCGroupComp)
        Me.MinimizeBox = False
        Me.Name = "FormPopUpCompGroup"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Group Company"
        CType(Me.GCGroupComp, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVGroupComp, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.is_active_company, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemCheckEdit1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LargeImageCollection, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PanelControl3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl3.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GCGroupComp As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVGroupComp As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents id_company As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents RepositoryItemCheckEdit1 As DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit
    Friend WithEvents is_active_company As DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit
    Friend WithEvents GridColumnNo As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnGroup As DevExpress.XtraGrid.Columns.GridColumn
    Public WithEvents LargeImageCollection As DevExpress.Utils.ImageCollection
    Friend WithEvents PanelControl3 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents BAddComp As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents GridColumn1 As DevExpress.XtraGrid.Columns.GridColumn
End Class
