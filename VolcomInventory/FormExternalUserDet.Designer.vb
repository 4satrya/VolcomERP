<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormExternalUserDet
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
        Me.SLUEStore = New DevExpress.XtraEditors.SearchLookUpEdit()
        Me.SearchLookUpEdit1View = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumn1 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn2 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.LabelControl3 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl2 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl1 = New DevExpress.XtraEditors.LabelControl()
        Me.SBSave = New DevExpress.XtraEditors.SimpleButton()
        Me.TEPosition = New DevExpress.XtraEditors.TextEdit()
        Me.TEName = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl4 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl5 = New DevExpress.XtraEditors.LabelControl()
        Me.TEPassword = New DevExpress.XtraEditors.TextEdit()
        Me.TEUsername = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl6 = New DevExpress.XtraEditors.LabelControl()
        Me.TECode = New DevExpress.XtraEditors.TextEdit()
        CType(Me.SLUEStore.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SearchLookUpEdit1View, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TEPosition.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TEName.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TEPassword.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TEUsername.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TECode.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'SLUEStore
        '
        Me.SLUEStore.Location = New System.Drawing.Point(16, 215)
        Me.SLUEStore.Name = "SLUEStore"
        Me.SLUEStore.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.SLUEStore.Properties.View = Me.SearchLookUpEdit1View
        Me.SLUEStore.Size = New System.Drawing.Size(250, 20)
        Me.SLUEStore.TabIndex = 16
        '
        'SearchLookUpEdit1View
        '
        Me.SearchLookUpEdit1View.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumn1, Me.GridColumn2})
        Me.SearchLookUpEdit1View.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
        Me.SearchLookUpEdit1View.Name = "SearchLookUpEdit1View"
        Me.SearchLookUpEdit1View.OptionsSelection.EnableAppearanceFocusedCell = False
        Me.SearchLookUpEdit1View.OptionsView.ShowGroupPanel = False
        '
        'GridColumn1
        '
        Me.GridColumn1.Caption = "GridColumn1"
        Me.GridColumn1.FieldName = "id_store"
        Me.GridColumn1.Name = "GridColumn1"
        '
        'GridColumn2
        '
        Me.GridColumn2.Caption = "Store Name"
        Me.GridColumn2.FieldName = "store_name"
        Me.GridColumn2.Name = "GridColumn2"
        Me.GridColumn2.Visible = True
        Me.GridColumn2.VisibleIndex = 0
        '
        'LabelControl3
        '
        Me.LabelControl3.Location = New System.Drawing.Point(16, 196)
        Me.LabelControl3.Name = "LabelControl3"
        Me.LabelControl3.Size = New System.Drawing.Size(26, 13)
        Me.LabelControl3.TabIndex = 15
        Me.LabelControl3.Text = "Store"
        '
        'LabelControl2
        '
        Me.LabelControl2.Location = New System.Drawing.Point(16, 61)
        Me.LabelControl2.Name = "LabelControl2"
        Me.LabelControl2.Size = New System.Drawing.Size(37, 13)
        Me.LabelControl2.TabIndex = 14
        Me.LabelControl2.Text = "Position"
        '
        'LabelControl1
        '
        Me.LabelControl1.Location = New System.Drawing.Point(16, 16)
        Me.LabelControl1.Name = "LabelControl1"
        Me.LabelControl1.Size = New System.Drawing.Size(27, 13)
        Me.LabelControl1.TabIndex = 13
        Me.LabelControl1.Text = "Name"
        '
        'SBSave
        '
        Me.SBSave.Location = New System.Drawing.Point(191, 286)
        Me.SBSave.Name = "SBSave"
        Me.SBSave.Size = New System.Drawing.Size(75, 23)
        Me.SBSave.TabIndex = 11
        Me.SBSave.Text = "Save"
        '
        'TEPosition
        '
        Me.TEPosition.Location = New System.Drawing.Point(16, 80)
        Me.TEPosition.Name = "TEPosition"
        Me.TEPosition.Size = New System.Drawing.Size(250, 20)
        Me.TEPosition.TabIndex = 10
        '
        'TEName
        '
        Me.TEName.Location = New System.Drawing.Point(16, 35)
        Me.TEName.Name = "TEName"
        Me.TEName.Size = New System.Drawing.Size(250, 20)
        Me.TEName.TabIndex = 9
        '
        'LabelControl4
        '
        Me.LabelControl4.Location = New System.Drawing.Point(16, 151)
        Me.LabelControl4.Name = "LabelControl4"
        Me.LabelControl4.Size = New System.Drawing.Size(46, 13)
        Me.LabelControl4.TabIndex = 20
        Me.LabelControl4.Text = "Password"
        '
        'LabelControl5
        '
        Me.LabelControl5.Location = New System.Drawing.Point(16, 106)
        Me.LabelControl5.Name = "LabelControl5"
        Me.LabelControl5.Size = New System.Drawing.Size(48, 13)
        Me.LabelControl5.TabIndex = 19
        Me.LabelControl5.Text = "Username"
        '
        'TEPassword
        '
        Me.TEPassword.Location = New System.Drawing.Point(16, 170)
        Me.TEPassword.Name = "TEPassword"
        Me.TEPassword.Properties.UseSystemPasswordChar = True
        Me.TEPassword.Size = New System.Drawing.Size(250, 20)
        Me.TEPassword.TabIndex = 18
        '
        'TEUsername
        '
        Me.TEUsername.Location = New System.Drawing.Point(16, 125)
        Me.TEUsername.Name = "TEUsername"
        Me.TEUsername.Size = New System.Drawing.Size(250, 20)
        Me.TEUsername.TabIndex = 17
        '
        'LabelControl6
        '
        Me.LabelControl6.Location = New System.Drawing.Point(16, 241)
        Me.LabelControl6.Name = "LabelControl6"
        Me.LabelControl6.Size = New System.Drawing.Size(25, 13)
        Me.LabelControl6.TabIndex = 22
        Me.LabelControl6.Text = "Code"
        '
        'TECode
        '
        Me.TECode.Location = New System.Drawing.Point(16, 260)
        Me.TECode.Name = "TECode"
        Me.TECode.Size = New System.Drawing.Size(250, 20)
        Me.TECode.TabIndex = 21
        '
        'FormExternalUserDet
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(284, 324)
        Me.Controls.Add(Me.LabelControl6)
        Me.Controls.Add(Me.TECode)
        Me.Controls.Add(Me.LabelControl4)
        Me.Controls.Add(Me.LabelControl5)
        Me.Controls.Add(Me.TEPassword)
        Me.Controls.Add(Me.TEUsername)
        Me.Controls.Add(Me.SLUEStore)
        Me.Controls.Add(Me.LabelControl3)
        Me.Controls.Add(Me.LabelControl2)
        Me.Controls.Add(Me.LabelControl1)
        Me.Controls.Add(Me.SBSave)
        Me.Controls.Add(Me.TEPosition)
        Me.Controls.Add(Me.TEName)
        Me.Name = "FormExternalUserDet"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "External User Detail"
        CType(Me.SLUEStore.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SearchLookUpEdit1View, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TEPosition.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TEName.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TEPassword.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TEUsername.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TECode.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents SLUEStore As DevExpress.XtraEditors.SearchLookUpEdit
    Friend WithEvents SearchLookUpEdit1View As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents LabelControl3 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl2 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl1 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents SBSave As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents TEPosition As DevExpress.XtraEditors.TextEdit
    Friend WithEvents TEName As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl4 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl5 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents TEPassword As DevExpress.XtraEditors.TextEdit
    Friend WithEvents TEUsername As DevExpress.XtraEditors.TextEdit
    Friend WithEvents GridColumn1 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn2 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents LabelControl6 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents TECode As DevExpress.XtraEditors.TextEdit
End Class
