<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormAccessMenuSingle
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormAccessMenuSingle))
        Me.BtnCancel = New DevExpress.XtraEditors.SimpleButton()
        Me.BtnSave = New DevExpress.XtraEditors.SimpleButton()
        Me.EPRole = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.LabelControl1 = New DevExpress.XtraEditors.LabelControl()
        Me.TxtMenuName = New DevExpress.XtraEditors.TextEdit()
        Me.MEDescription = New DevExpress.XtraEditors.MemoEdit()
        Me.LabelControl2 = New DevExpress.XtraEditors.LabelControl()
        Me.PanelControl1 = New DevExpress.XtraEditors.PanelControl()
        Me.LabelControl3 = New DevExpress.XtraEditors.LabelControl()
        Me.LEGroup = New DevExpress.XtraEditors.LookUpEdit()
        Me.GroupControlGeneral = New DevExpress.XtraEditors.GroupControl()
        Me.GroupControlInvolved = New DevExpress.XtraEditors.GroupControl()
        Me.PanelControl2 = New DevExpress.XtraEditors.PanelControl()
        Me.GCInvolved = New DevExpress.XtraGrid.GridControl()
        Me.GVInvolved = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumnIdFormInvolved = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnFormNameInvolved = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnFormMenu = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RepositoryItemCheckEdit1 = New DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit()
        Me.GridColumnIdMenuInvolved = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.PanelControl3 = New DevExpress.XtraEditors.PanelControl()
        Me.BtnDelete = New DevExpress.XtraEditors.SimpleButton()
        Me.LargeImageCollection = New DevExpress.Utils.ImageCollection(Me.components)
        Me.BtnEdit = New DevExpress.XtraEditors.SimpleButton()
        Me.BtnAdd = New DevExpress.XtraEditors.SimpleButton()
        CType(Me.EPRole, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtMenuName.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.MEDescription.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl1.SuspendLayout()
        CType(Me.LEGroup.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GroupControlGeneral, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupControlGeneral.SuspendLayout()
        CType(Me.GroupControlInvolved, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupControlInvolved.SuspendLayout()
        CType(Me.PanelControl2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl2.SuspendLayout()
        CType(Me.GCInvolved, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVInvolved, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemCheckEdit1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PanelControl3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl3.SuspendLayout()
        CType(Me.LargeImageCollection, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'BtnCancel
        '
        Me.BtnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.BtnCancel.Location = New System.Drawing.Point(583, 16)
        Me.BtnCancel.Name = "BtnCancel"
        Me.BtnCancel.Size = New System.Drawing.Size(75, 23)
        Me.BtnCancel.TabIndex = 5
        Me.BtnCancel.Text = "Cancel"
        '
        'BtnSave
        '
        Me.BtnSave.Location = New System.Drawing.Point(664, 16)
        Me.BtnSave.Name = "BtnSave"
        Me.BtnSave.Size = New System.Drawing.Size(75, 23)
        Me.BtnSave.TabIndex = 4
        Me.BtnSave.Text = "Save"
        '
        'EPRole
        '
        Me.EPRole.ContainerControl = Me
        '
        'LabelControl1
        '
        Me.LabelControl1.Appearance.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl1.Location = New System.Drawing.Point(31, 14)
        Me.LabelControl1.Name = "LabelControl1"
        Me.LabelControl1.Size = New System.Drawing.Size(92, 15)
        Me.LabelControl1.TabIndex = 45
        Me.LabelControl1.Text = "Menu Item Name"
        '
        'TxtMenuName
        '
        Me.TxtMenuName.Location = New System.Drawing.Point(31, 31)
        Me.TxtMenuName.Name = "TxtMenuName"
        Me.TxtMenuName.Properties.Appearance.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtMenuName.Properties.Appearance.Options.UseFont = True
        Me.TxtMenuName.Properties.MaxLength = 50
        Me.TxtMenuName.Size = New System.Drawing.Size(302, 22)
        Me.TxtMenuName.TabIndex = 0
        Me.TxtMenuName.ToolTip = "Max : 50 character."
        Me.TxtMenuName.ToolTipIconType = DevExpress.Utils.ToolTipIconType.Information
        '
        'MEDescription
        '
        Me.MEDescription.Location = New System.Drawing.Point(31, 130)
        Me.MEDescription.Name = "MEDescription"
        Me.MEDescription.Properties.MaxLength = 100
        Me.MEDescription.Size = New System.Drawing.Size(302, 92)
        Me.MEDescription.TabIndex = 2
        Me.MEDescription.ToolTip = "Description of menu. Max : 100 character. "
        Me.MEDescription.ToolTipIconType = DevExpress.Utils.ToolTipIconType.Information
        '
        'LabelControl2
        '
        Me.LabelControl2.Appearance.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl2.Location = New System.Drawing.Point(31, 109)
        Me.LabelControl2.Name = "LabelControl2"
        Me.LabelControl2.Size = New System.Drawing.Size(64, 15)
        Me.LabelControl2.TabIndex = 50
        Me.LabelControl2.Text = "Description"
        '
        'PanelControl1
        '
        Me.PanelControl1.Controls.Add(Me.BtnSave)
        Me.PanelControl1.Controls.Add(Me.BtnCancel)
        Me.PanelControl1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PanelControl1.Location = New System.Drawing.Point(0, 294)
        Me.PanelControl1.LookAndFeel.SkinName = "Blue"
        Me.PanelControl1.LookAndFeel.UseDefaultLookAndFeel = False
        Me.PanelControl1.Name = "PanelControl1"
        Me.PanelControl1.Size = New System.Drawing.Size(749, 56)
        Me.PanelControl1.TabIndex = 51
        '
        'LabelControl3
        '
        Me.LabelControl3.Appearance.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl3.Location = New System.Drawing.Point(31, 58)
        Me.LabelControl3.Name = "LabelControl3"
        Me.LabelControl3.Size = New System.Drawing.Size(68, 15)
        Me.LabelControl3.TabIndex = 53
        Me.LabelControl3.Text = "Group Menu"
        '
        'LEGroup
        '
        Me.LEGroup.Location = New System.Drawing.Point(31, 79)
        Me.LEGroup.Name = "LEGroup"
        Me.LEGroup.Properties.Appearance.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LEGroup.Properties.Appearance.Options.UseFont = True
        Me.LEGroup.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.LEGroup.Properties.Columns.AddRange(New DevExpress.XtraEditors.Controls.LookUpColumnInfo() {New DevExpress.XtraEditors.Controls.LookUpColumnInfo("id_group_menu", "Id", 20, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("group_menu", "Group Menu")})
        Me.LEGroup.Size = New System.Drawing.Size(302, 22)
        Me.LEGroup.TabIndex = 1
        '
        'GroupControlGeneral
        '
        Me.GroupControlGeneral.CaptionLocation = DevExpress.Utils.Locations.Left
        Me.GroupControlGeneral.Controls.Add(Me.MEDescription)
        Me.GroupControlGeneral.Controls.Add(Me.TxtMenuName)
        Me.GroupControlGeneral.Controls.Add(Me.LabelControl1)
        Me.GroupControlGeneral.Controls.Add(Me.LabelControl2)
        Me.GroupControlGeneral.Controls.Add(Me.LEGroup)
        Me.GroupControlGeneral.Controls.Add(Me.LabelControl3)
        Me.GroupControlGeneral.Dock = System.Windows.Forms.DockStyle.Left
        Me.GroupControlGeneral.Location = New System.Drawing.Point(0, 0)
        Me.GroupControlGeneral.LookAndFeel.SkinName = "Office 2010 Blue"
        Me.GroupControlGeneral.LookAndFeel.UseDefaultLookAndFeel = False
        Me.GroupControlGeneral.Name = "GroupControlGeneral"
        Me.GroupControlGeneral.Size = New System.Drawing.Size(356, 294)
        Me.GroupControlGeneral.TabIndex = 59
        Me.GroupControlGeneral.Text = "General"
        '
        'GroupControlInvolved
        '
        Me.GroupControlInvolved.AppearanceCaption.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupControlInvolved.AppearanceCaption.Options.UseFont = True
        Me.GroupControlInvolved.CaptionLocation = DevExpress.Utils.Locations.Left
        Me.GroupControlInvolved.Controls.Add(Me.PanelControl2)
        Me.GroupControlInvolved.Controls.Add(Me.PanelControl3)
        Me.GroupControlInvolved.Dock = System.Windows.Forms.DockStyle.Left
        Me.GroupControlInvolved.Location = New System.Drawing.Point(356, 0)
        Me.GroupControlInvolved.LookAndFeel.SkinName = "Office 2010 Blue"
        Me.GroupControlInvolved.LookAndFeel.UseDefaultLookAndFeel = False
        Me.GroupControlInvolved.Name = "GroupControlInvolved"
        Me.GroupControlInvolved.Size = New System.Drawing.Size(747, 294)
        Me.GroupControlInvolved.TabIndex = 60
        Me.GroupControlInvolved.Text = "Involved Form"
        '
        'PanelControl2
        '
        Me.PanelControl2.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
        Me.PanelControl2.Controls.Add(Me.GCInvolved)
        Me.PanelControl2.Dock = System.Windows.Forms.DockStyle.Left
        Me.PanelControl2.Location = New System.Drawing.Point(21, 52)
        Me.PanelControl2.Name = "PanelControl2"
        Me.PanelControl2.Size = New System.Drawing.Size(371, 240)
        Me.PanelControl2.TabIndex = 1
        '
        'GCInvolved
        '
        Me.GCInvolved.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GCInvolved.Location = New System.Drawing.Point(0, 0)
        Me.GCInvolved.LookAndFeel.SkinName = "Office 2010 Blue"
        Me.GCInvolved.MainView = Me.GVInvolved
        Me.GCInvolved.Name = "GCInvolved"
        Me.GCInvolved.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.RepositoryItemCheckEdit1})
        Me.GCInvolved.Size = New System.Drawing.Size(371, 240)
        Me.GCInvolved.TabIndex = 2
        Me.GCInvolved.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVInvolved})
        '
        'GVInvolved
        '
        Me.GVInvolved.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumnIdFormInvolved, Me.GridColumnFormNameInvolved, Me.GridColumnFormMenu, Me.GridColumnIdMenuInvolved})
        Me.GVInvolved.GridControl = Me.GCInvolved
        Me.GVInvolved.Name = "GVInvolved"
        Me.GVInvolved.OptionsBehavior.Editable = False
        Me.GVInvolved.OptionsView.ShowGroupPanel = False
        '
        'GridColumnIdFormInvolved
        '
        Me.GridColumnIdFormInvolved.Caption = "IdForm"
        Me.GridColumnIdFormInvolved.FieldName = "id_form"
        Me.GridColumnIdFormInvolved.Name = "GridColumnIdFormInvolved"
        '
        'GridColumnFormNameInvolved
        '
        Me.GridColumnFormNameInvolved.Caption = "Form Name"
        Me.GridColumnFormNameInvolved.FieldName = "form_name"
        Me.GridColumnFormNameInvolved.Name = "GridColumnFormNameInvolved"
        Me.GridColumnFormNameInvolved.Visible = True
        Me.GridColumnFormNameInvolved.VisibleIndex = 0
        '
        'GridColumnFormMenu
        '
        Me.GridColumnFormMenu.AppearanceHeader.Options.UseTextOptions = True
        Me.GridColumnFormMenu.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridColumnFormMenu.Caption = "Form Menu"
        Me.GridColumnFormMenu.ColumnEdit = Me.RepositoryItemCheckEdit1
        Me.GridColumnFormMenu.FieldName = "is_view"
        Me.GridColumnFormMenu.Name = "GridColumnFormMenu"
        Me.GridColumnFormMenu.Visible = True
        Me.GridColumnFormMenu.VisibleIndex = 1
        '
        'RepositoryItemCheckEdit1
        '
        Me.RepositoryItemCheckEdit1.AutoHeight = False
        Me.RepositoryItemCheckEdit1.Name = "RepositoryItemCheckEdit1"
        Me.RepositoryItemCheckEdit1.ValueChecked = "Yes"
        Me.RepositoryItemCheckEdit1.ValueUnchecked = "No"
        '
        'GridColumnIdMenuInvolved
        '
        Me.GridColumnIdMenuInvolved.Caption = "IdMenuInvolved"
        Me.GridColumnIdMenuInvolved.FieldName = "id_menu_involved"
        Me.GridColumnIdMenuInvolved.Name = "GridColumnIdMenuInvolved"
        '
        'PanelControl3
        '
        Me.PanelControl3.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
        Me.PanelControl3.Controls.Add(Me.BtnDelete)
        Me.PanelControl3.Controls.Add(Me.BtnEdit)
        Me.PanelControl3.Controls.Add(Me.BtnAdd)
        Me.PanelControl3.Dock = System.Windows.Forms.DockStyle.Top
        Me.PanelControl3.Location = New System.Drawing.Point(21, 2)
        Me.PanelControl3.Name = "PanelControl3"
        Me.PanelControl3.Size = New System.Drawing.Size(724, 50)
        Me.PanelControl3.TabIndex = 0
        '
        'BtnDelete
        '
        Me.BtnDelete.ImageIndex = 2
        Me.BtnDelete.ImageList = Me.LargeImageCollection
        Me.BtnDelete.Location = New System.Drawing.Point(76, 10)
        Me.BtnDelete.Name = "BtnDelete"
        Me.BtnDelete.Size = New System.Drawing.Size(91, 32)
        Me.BtnDelete.TabIndex = 8
        Me.BtnDelete.Text = "Delete"
        '
        'LargeImageCollection
        '
        Me.LargeImageCollection.ImageSize = New System.Drawing.Size(24, 24)
        Me.LargeImageCollection.ImageStream = CType(resources.GetObject("LargeImageCollection.ImageStream"), DevExpress.Utils.ImageCollectionStreamer)
        Me.LargeImageCollection.Images.SetKeyName(0, "20_24x24.png")
        Me.LargeImageCollection.Images.SetKeyName(1, "23_24x24.png")
        Me.LargeImageCollection.Images.SetKeyName(2, "8_24x24.png")
        '
        'BtnEdit
        '
        Me.BtnEdit.ImageIndex = 1
        Me.BtnEdit.ImageList = Me.LargeImageCollection
        Me.BtnEdit.Location = New System.Drawing.Point(173, 10)
        Me.BtnEdit.Name = "BtnEdit"
        Me.BtnEdit.Size = New System.Drawing.Size(91, 32)
        Me.BtnEdit.TabIndex = 7
        Me.BtnEdit.Text = "Edit"
        '
        'BtnAdd
        '
        Me.BtnAdd.ImageIndex = 0
        Me.BtnAdd.ImageList = Me.LargeImageCollection
        Me.BtnAdd.Location = New System.Drawing.Point(270, 10)
        Me.BtnAdd.Name = "BtnAdd"
        Me.BtnAdd.Size = New System.Drawing.Size(91, 32)
        Me.BtnAdd.TabIndex = 6
        Me.BtnAdd.Text = "Add"
        '
        'FormAccessMenuSingle
        '
        Me.AcceptButton = Me.BtnSave
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.BtnCancel
        Me.ClientSize = New System.Drawing.Size(749, 350)
        Me.Controls.Add(Me.GroupControlInvolved)
        Me.Controls.Add(Me.GroupControlGeneral)
        Me.Controls.Add(Me.PanelControl1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FormAccessMenuSingle"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Master Menu "
        CType(Me.EPRole, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtMenuName.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.MEDescription.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl1.ResumeLayout(False)
        CType(Me.LEGroup.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GroupControlGeneral, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupControlGeneral.ResumeLayout(False)
        Me.GroupControlGeneral.PerformLayout()
        CType(Me.GroupControlInvolved, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupControlInvolved.ResumeLayout(False)
        CType(Me.PanelControl2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl2.ResumeLayout(False)
        CType(Me.GCInvolved, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVInvolved, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemCheckEdit1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PanelControl3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl3.ResumeLayout(False)
        CType(Me.LargeImageCollection, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents BtnCancel As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BtnSave As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents EPRole As System.Windows.Forms.ErrorProvider
    Friend WithEvents LabelControl2 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents MEDescription As DevExpress.XtraEditors.MemoEdit
    Friend WithEvents LabelControl1 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents TxtMenuName As DevExpress.XtraEditors.TextEdit
    Friend WithEvents PanelControl1 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents LEGroup As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents LabelControl3 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents GroupControlGeneral As DevExpress.XtraEditors.GroupControl
    Friend WithEvents GroupControlInvolved As DevExpress.XtraEditors.GroupControl
    Friend WithEvents PanelControl3 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents BtnDelete As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BtnEdit As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BtnAdd As DevExpress.XtraEditors.SimpleButton
    Public WithEvents LargeImageCollection As DevExpress.Utils.ImageCollection
    Friend WithEvents PanelControl2 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents GCInvolved As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVInvolved As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumnIdFormInvolved As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnFormNameInvolved As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnFormMenu As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents RepositoryItemCheckEdit1 As DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit
    Friend WithEvents GridColumnIdMenuInvolved As DevExpress.XtraGrid.Columns.GridColumn
End Class
