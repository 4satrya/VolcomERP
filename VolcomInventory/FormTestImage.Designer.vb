<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormTestImage
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
        Me.PanelControl1 = New DevExpress.XtraEditors.PanelControl()
        Me.PictureEdit = New DevExpress.XtraEditors.PictureEdit()
        Me.TextName = New DevExpress.XtraEditors.TextEdit()
        Me.TextCode = New DevExpress.XtraEditors.TextEdit()
        Me.LabelName = New DevExpress.XtraEditors.LabelControl()
        Me.LabelCode = New DevExpress.XtraEditors.LabelControl()
        Me.PanelControl2 = New DevExpress.XtraEditors.PanelControl()
        Me.LCSeason = New DevExpress.XtraEditors.LabelControl()
        Me.LCType = New DevExpress.XtraEditors.LabelControl()
        Me.SLSeason = New DevExpress.XtraEditors.SearchLookUpEdit()
        Me.SearchLookUpEdit2View = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.SLType = New DevExpress.XtraEditors.SearchLookUpEdit()
        Me.SearchLookUpEdit1View = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GCList = New DevExpress.XtraGrid.GridControl()
        Me.GVList = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GCId = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GCCode = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GCName = New DevExpress.XtraGrid.Columns.GridColumn()
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl1.SuspendLayout()
        CType(Me.PictureEdit.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextName.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextCode.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PanelControl2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl2.SuspendLayout()
        CType(Me.SLSeason.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SearchLookUpEdit2View, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SLType.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SearchLookUpEdit1View, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GCList, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVList, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PanelControl1
        '
        Me.PanelControl1.Controls.Add(Me.PictureEdit)
        Me.PanelControl1.Dock = System.Windows.Forms.DockStyle.Left
        Me.PanelControl1.Location = New System.Drawing.Point(0, 0)
        Me.PanelControl1.Name = "PanelControl1"
        Me.PanelControl1.Size = New System.Drawing.Size(196, 349)
        Me.PanelControl1.TabIndex = 0
        '
        'PictureEdit
        '
        Me.PictureEdit.Location = New System.Drawing.Point(0, 63)
        Me.PictureEdit.Name = "PictureEdit"
        Me.PictureEdit.Properties.ShowCameraMenuItem = DevExpress.XtraEditors.Controls.CameraMenuItemVisibility.[Auto]
        Me.PictureEdit.Properties.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Stretch
        Me.PictureEdit.Size = New System.Drawing.Size(196, 200)
        Me.PictureEdit.TabIndex = 0
        '
        'TextName
        '
        Me.TextName.Location = New System.Drawing.Point(56, 46)
        Me.TextName.Name = "TextName"
        Me.TextName.Size = New System.Drawing.Size(136, 20)
        Me.TextName.TabIndex = 4
        '
        'TextCode
        '
        Me.TextCode.Location = New System.Drawing.Point(56, 12)
        Me.TextCode.Name = "TextCode"
        Me.TextCode.Size = New System.Drawing.Size(136, 20)
        Me.TextCode.TabIndex = 3
        '
        'LabelName
        '
        Me.LabelName.Location = New System.Drawing.Point(15, 49)
        Me.LabelName.Name = "LabelName"
        Me.LabelName.Size = New System.Drawing.Size(27, 13)
        Me.LabelName.TabIndex = 2
        Me.LabelName.Text = "Name"
        '
        'LabelCode
        '
        Me.LabelCode.Location = New System.Drawing.Point(15, 15)
        Me.LabelCode.Name = "LabelCode"
        Me.LabelCode.Size = New System.Drawing.Size(25, 13)
        Me.LabelCode.TabIndex = 1
        Me.LabelCode.Text = "Code"
        '
        'PanelControl2
        '
        Me.PanelControl2.Controls.Add(Me.LCSeason)
        Me.PanelControl2.Controls.Add(Me.LCType)
        Me.PanelControl2.Controls.Add(Me.SLSeason)
        Me.PanelControl2.Controls.Add(Me.SLType)
        Me.PanelControl2.Controls.Add(Me.LabelName)
        Me.PanelControl2.Controls.Add(Me.TextName)
        Me.PanelControl2.Controls.Add(Me.LabelCode)
        Me.PanelControl2.Controls.Add(Me.GCList)
        Me.PanelControl2.Controls.Add(Me.TextCode)
        Me.PanelControl2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PanelControl2.Location = New System.Drawing.Point(196, 0)
        Me.PanelControl2.Name = "PanelControl2"
        Me.PanelControl2.Size = New System.Drawing.Size(675, 349)
        Me.PanelControl2.TabIndex = 1
        '
        'LCSeason
        '
        Me.LCSeason.Location = New System.Drawing.Point(130, 81)
        Me.LCSeason.Name = "LCSeason"
        Me.LCSeason.Size = New System.Drawing.Size(35, 13)
        Me.LCSeason.TabIndex = 10
        Me.LCSeason.Text = "Season"
        '
        'LCType
        '
        Me.LCType.Location = New System.Drawing.Point(15, 81)
        Me.LCType.Name = "LCType"
        Me.LCType.Size = New System.Drawing.Size(24, 13)
        Me.LCType.TabIndex = 9
        Me.LCType.Text = "Type"
        '
        'SLSeason
        '
        Me.SLSeason.Location = New System.Drawing.Point(130, 100)
        Me.SLSeason.Name = "SLSeason"
        Me.SLSeason.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.SLSeason.Properties.View = Me.SearchLookUpEdit2View
        Me.SLSeason.Size = New System.Drawing.Size(100, 20)
        Me.SLSeason.TabIndex = 6
        '
        'SearchLookUpEdit2View
        '
        Me.SearchLookUpEdit2View.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
        Me.SearchLookUpEdit2View.Name = "SearchLookUpEdit2View"
        Me.SearchLookUpEdit2View.OptionsSelection.EnableAppearanceFocusedCell = False
        Me.SearchLookUpEdit2View.OptionsView.ShowGroupPanel = False
        '
        'SLType
        '
        Me.SLType.Location = New System.Drawing.Point(15, 100)
        Me.SLType.Name = "SLType"
        Me.SLType.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.SLType.Properties.View = Me.SearchLookUpEdit1View
        Me.SLType.Size = New System.Drawing.Size(100, 20)
        Me.SLType.TabIndex = 5
        '
        'SearchLookUpEdit1View
        '
        Me.SearchLookUpEdit1View.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
        Me.SearchLookUpEdit1View.Name = "SearchLookUpEdit1View"
        Me.SearchLookUpEdit1View.OptionsSelection.EnableAppearanceFocusedCell = False
        Me.SearchLookUpEdit1View.OptionsView.ShowGroupPanel = False
        '
        'GCList
        '
        Me.GCList.Location = New System.Drawing.Point(0, 138)
        Me.GCList.MainView = Me.GVList
        Me.GCList.Name = "GCList"
        Me.GCList.Size = New System.Drawing.Size(675, 211)
        Me.GCList.TabIndex = 0
        Me.GCList.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVList})
        '
        'GVList
        '
        Me.GVList.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GCId, Me.GCCode, Me.GCName})
        Me.GVList.GridControl = Me.GCList
        Me.GVList.Name = "GVList"
        '
        'GCId
        '
        Me.GCId.Caption = "Id"
        Me.GCId.FieldName = "id_design"
        Me.GCId.Name = "GCId"
        '
        'GCCode
        '
        Me.GCCode.Caption = "Code"
        Me.GCCode.FieldName = "design_code"
        Me.GCCode.Name = "GCCode"
        Me.GCCode.OptionsColumn.AllowEdit = False
        Me.GCCode.Visible = True
        Me.GCCode.VisibleIndex = 0
        '
        'GCName
        '
        Me.GCName.Caption = "Name"
        Me.GCName.FieldName = "design_name"
        Me.GCName.Name = "GCName"
        Me.GCName.OptionsColumn.AllowEdit = False
        Me.GCName.Visible = True
        Me.GCName.VisibleIndex = 1
        '
        'FormTestImage
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(871, 349)
        Me.Controls.Add(Me.PanelControl2)
        Me.Controls.Add(Me.PanelControl1)
        Me.Name = "FormTestImage"
        Me.Text = "Coba Dua"
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl1.ResumeLayout(False)
        CType(Me.PictureEdit.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextName.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextCode.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PanelControl2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl2.ResumeLayout(False)
        Me.PanelControl2.PerformLayout()
        CType(Me.SLSeason.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SearchLookUpEdit2View, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SLType.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SearchLookUpEdit1View, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GCList, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVList, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents PanelControl1 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents PanelControl2 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents PictureEdit As DevExpress.XtraEditors.PictureEdit
    Friend WithEvents GCList As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVList As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GCCode As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GCId As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GCName As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents TextName As DevExpress.XtraEditors.TextEdit
    Friend WithEvents TextCode As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelName As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelCode As DevExpress.XtraEditors.LabelControl
    Friend WithEvents SLType As DevExpress.XtraEditors.SearchLookUpEdit
    Friend WithEvents SearchLookUpEdit1View As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents LCType As DevExpress.XtraEditors.LabelControl
    Friend WithEvents SLSeason As DevExpress.XtraEditors.SearchLookUpEdit
    Friend WithEvents SearchLookUpEdit2View As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents LCSeason As DevExpress.XtraEditors.LabelControl
End Class
