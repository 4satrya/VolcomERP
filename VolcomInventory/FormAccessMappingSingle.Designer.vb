<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormAccessMappingSingle
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormAccessMappingSingle))
        Me.PCClose = New DevExpress.XtraEditors.PanelControl()
        Me.CheckEditSelAll = New DevExpress.XtraEditors.CheckEdit()
        Me.BtnClose = New DevExpress.XtraEditors.SimpleButton()
        Me.BtnSave = New DevExpress.XtraEditors.SimpleButton()
        Me.PanelControl1 = New DevExpress.XtraEditors.PanelControl()
        Me.LabelRole = New DevExpress.XtraEditors.LabelControl()
        Me.PictureMenuAccess = New DevExpress.XtraEditors.PictureEdit()
        Me.GCMenu = New DevExpress.XtraGrid.GridControl()
        Me.GVMenu = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumnIdFormControl = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnDescriptionMenuName = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnProcess = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnStatus = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RepositoryItemCheckEdit1 = New DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit()
        Me.GridColumnGroupMenu = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnIsView = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnIdForm = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnIsChanegd = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.BPrint = New DevExpress.XtraEditors.SimpleButton()
        CType(Me.PCClose, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PCClose.SuspendLayout()
        CType(Me.CheckEditSelAll.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl1.SuspendLayout()
        CType(Me.PictureMenuAccess.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GCMenu, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVMenu, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemCheckEdit1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PCClose
        '
        Me.PCClose.Controls.Add(Me.BPrint)
        Me.PCClose.Controls.Add(Me.CheckEditSelAll)
        Me.PCClose.Controls.Add(Me.BtnClose)
        Me.PCClose.Controls.Add(Me.BtnSave)
        Me.PCClose.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PCClose.Location = New System.Drawing.Point(0, 380)
        Me.PCClose.LookAndFeel.SkinName = "Blue"
        Me.PCClose.LookAndFeel.UseDefaultLookAndFeel = False
        Me.PCClose.Name = "PCClose"
        Me.PCClose.Size = New System.Drawing.Size(580, 38)
        Me.PCClose.TabIndex = 28
        '
        'CheckEditSelAll
        '
        Me.CheckEditSelAll.Location = New System.Drawing.Point(9, 10)
        Me.CheckEditSelAll.Name = "CheckEditSelAll"
        Me.CheckEditSelAll.Properties.Caption = "Select All"
        Me.CheckEditSelAll.Size = New System.Drawing.Size(75, 19)
        Me.CheckEditSelAll.TabIndex = 2
        '
        'BtnClose
        '
        Me.BtnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.BtnClose.Dock = System.Windows.Forms.DockStyle.Right
        Me.BtnClose.Location = New System.Drawing.Point(428, 2)
        Me.BtnClose.Name = "BtnClose"
        Me.BtnClose.Size = New System.Drawing.Size(75, 34)
        Me.BtnClose.TabIndex = 0
        Me.BtnClose.Text = "Close"
        '
        'BtnSave
        '
        Me.BtnSave.Dock = System.Windows.Forms.DockStyle.Right
        Me.BtnSave.Location = New System.Drawing.Point(503, 2)
        Me.BtnSave.Name = "BtnSave"
        Me.BtnSave.Size = New System.Drawing.Size(75, 34)
        Me.BtnSave.TabIndex = 1
        Me.BtnSave.Text = "Save"
        '
        'PanelControl1
        '
        Me.PanelControl1.Appearance.BackColor = System.Drawing.Color.Blue
        Me.PanelControl1.Appearance.Options.UseBackColor = True
        Me.PanelControl1.Controls.Add(Me.LabelRole)
        Me.PanelControl1.Controls.Add(Me.PictureMenuAccess)
        Me.PanelControl1.Dock = System.Windows.Forms.DockStyle.Top
        Me.PanelControl1.Location = New System.Drawing.Point(0, 0)
        Me.PanelControl1.LookAndFeel.SkinName = "Office 2010 Blue"
        Me.PanelControl1.LookAndFeel.UseDefaultLookAndFeel = False
        Me.PanelControl1.Name = "PanelControl1"
        Me.PanelControl1.Size = New System.Drawing.Size(580, 69)
        Me.PanelControl1.TabIndex = 29
        '
        'LabelRole
        '
        Me.LabelRole.Appearance.Font = New System.Drawing.Font("Calibri", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelRole.Location = New System.Drawing.Point(71, 23)
        Me.LabelRole.Name = "LabelRole"
        Me.LabelRole.Size = New System.Drawing.Size(6, 23)
        Me.LabelRole.TabIndex = 29
        Me.LabelRole.Text = "-"
        '
        'PictureMenuAccess
        '
        Me.PictureMenuAccess.EditValue = CType(resources.GetObject("PictureMenuAccess.EditValue"), Object)
        Me.PictureMenuAccess.Location = New System.Drawing.Point(0, 5)
        Me.PictureMenuAccess.Name = "PictureMenuAccess"
        Me.PictureMenuAccess.Properties.Appearance.BackColor = System.Drawing.Color.Transparent
        Me.PictureMenuAccess.Properties.Appearance.Options.UseBackColor = True
        Me.PictureMenuAccess.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
        Me.PictureMenuAccess.Properties.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Zoom
        Me.PictureMenuAccess.Size = New System.Drawing.Size(82, 64)
        Me.PictureMenuAccess.TabIndex = 27
        '
        'GCMenu
        '
        Me.GCMenu.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCMenu.Location = New System.Drawing.Point(0, 69)
        Me.GCMenu.MainView = Me.GVMenu
        Me.GCMenu.Name = "GCMenu"
        Me.GCMenu.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.RepositoryItemCheckEdit1})
        Me.GCMenu.Size = New System.Drawing.Size(580, 311)
        Me.GCMenu.TabIndex = 34
        Me.GCMenu.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVMenu})
        '
        'GVMenu
        '
        Me.GVMenu.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumnIdFormControl, Me.GridColumnDescriptionMenuName, Me.GridColumnProcess, Me.GridColumnStatus, Me.GridColumnGroupMenu, Me.GridColumnIsView, Me.GridColumnIdForm, Me.GridColumnIsChanegd})
        Me.GVMenu.GridControl = Me.GCMenu
        Me.GVMenu.GroupCount = 1
        Me.GVMenu.Name = "GVMenu"
        Me.GVMenu.OptionsBehavior.AutoExpandAllGroups = True
        Me.GVMenu.OptionsCustomization.AllowColumnMoving = False
        Me.GVMenu.OptionsCustomization.AllowGroup = False
        Me.GVMenu.OptionsCustomization.AllowQuickHideColumns = False
        Me.GVMenu.OptionsView.ShowGroupPanel = False
        Me.GVMenu.SortInfo.AddRange(New DevExpress.XtraGrid.Columns.GridColumnSortInfo() {New DevExpress.XtraGrid.Columns.GridColumnSortInfo(Me.GridColumnGroupMenu, DevExpress.Data.ColumnSortOrder.Ascending)})
        '
        'GridColumnIdFormControl
        '
        Me.GridColumnIdFormControl.Caption = "ID"
        Me.GridColumnIdFormControl.FieldName = "id_form_control"
        Me.GridColumnIdFormControl.Name = "GridColumnIdFormControl"
        '
        'GridColumnDescriptionMenuName
        '
        Me.GridColumnDescriptionMenuName.Caption = "Menu"
        Me.GridColumnDescriptionMenuName.FieldName = "description_menu_name"
        Me.GridColumnDescriptionMenuName.Name = "GridColumnDescriptionMenuName"
        Me.GridColumnDescriptionMenuName.OptionsColumn.AllowEdit = False
        Me.GridColumnDescriptionMenuName.Visible = True
        Me.GridColumnDescriptionMenuName.VisibleIndex = 0
        '
        'GridColumnProcess
        '
        Me.GridColumnProcess.Caption = "Process"
        Me.GridColumnProcess.FieldName = "description_form_control"
        Me.GridColumnProcess.Name = "GridColumnProcess"
        Me.GridColumnProcess.OptionsColumn.AllowEdit = False
        Me.GridColumnProcess.Visible = True
        Me.GridColumnProcess.VisibleIndex = 1
        '
        'GridColumnStatus
        '
        Me.GridColumnStatus.AppearanceHeader.Options.UseTextOptions = True
        Me.GridColumnStatus.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridColumnStatus.Caption = "Status"
        Me.GridColumnStatus.ColumnEdit = Me.RepositoryItemCheckEdit1
        Me.GridColumnStatus.FieldName = "is_select"
        Me.GridColumnStatus.Name = "GridColumnStatus"
        Me.GridColumnStatus.Visible = True
        Me.GridColumnStatus.VisibleIndex = 2
        '
        'RepositoryItemCheckEdit1
        '
        Me.RepositoryItemCheckEdit1.AutoHeight = False
        Me.RepositoryItemCheckEdit1.Name = "RepositoryItemCheckEdit1"
        Me.RepositoryItemCheckEdit1.ValueChecked = "Yes"
        Me.RepositoryItemCheckEdit1.ValueUnchecked = "No"
        '
        'GridColumnGroupMenu
        '
        Me.GridColumnGroupMenu.Caption = "Group Menu"
        Me.GridColumnGroupMenu.FieldName = "group_menu"
        Me.GridColumnGroupMenu.Name = "GridColumnGroupMenu"
        '
        'GridColumnIsView
        '
        Me.GridColumnIsView.Caption = "IsView"
        Me.GridColumnIsView.FieldName = "is_view"
        Me.GridColumnIsView.Name = "GridColumnIsView"
        '
        'GridColumnIdForm
        '
        Me.GridColumnIdForm.Caption = "IdForm"
        Me.GridColumnIdForm.FieldName = "id_form"
        Me.GridColumnIdForm.Name = "GridColumnIdForm"
        '
        'GridColumnIsChanegd
        '
        Me.GridColumnIsChanegd.Caption = "IsChanged"
        Me.GridColumnIsChanegd.FieldName = "is_changed"
        Me.GridColumnIsChanegd.Name = "GridColumnIsChanegd"
        '
        'BPrint
        '
        Me.BPrint.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.BPrint.Dock = System.Windows.Forms.DockStyle.Right
        Me.BPrint.Location = New System.Drawing.Point(353, 2)
        Me.BPrint.Name = "BPrint"
        Me.BPrint.Size = New System.Drawing.Size(75, 34)
        Me.BPrint.TabIndex = 3
        Me.BPrint.Text = "Print"
        '
        'FormAccessMappingSingle
        '
        Me.AcceptButton = Me.BtnSave
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.BtnClose
        Me.ClientSize = New System.Drawing.Size(580, 418)
        Me.Controls.Add(Me.GCMenu)
        Me.Controls.Add(Me.PanelControl1)
        Me.Controls.Add(Me.PCClose)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.LookAndFeel.SkinName = "Blue"
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FormAccessMappingSingle"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Mapping Access"
        CType(Me.PCClose, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PCClose.ResumeLayout(False)
        CType(Me.CheckEditSelAll.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl1.ResumeLayout(False)
        Me.PanelControl1.PerformLayout()
        CType(Me.PictureMenuAccess.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GCMenu, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVMenu, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemCheckEdit1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents PCClose As DevExpress.XtraEditors.PanelControl
    Friend WithEvents BtnClose As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BtnSave As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents PanelControl1 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents LabelRole As DevExpress.XtraEditors.LabelControl
    Friend WithEvents PictureMenuAccess As DevExpress.XtraEditors.PictureEdit
    Friend WithEvents GCMenu As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVMenu As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumnIdFormControl As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnDescriptionMenuName As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnStatus As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents RepositoryItemCheckEdit1 As DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit
    Friend WithEvents GridColumnGroupMenu As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnProcess As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnIsView As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnIdForm As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents CheckEditSelAll As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents GridColumnIsChanegd As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents BPrint As DevExpress.XtraEditors.SimpleButton
End Class
