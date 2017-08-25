<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormMarkAssignUserSingle
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
        Me.GCUser = New DevExpress.XtraGrid.GridControl()
        Me.GVUser = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.id_user = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.ColumnEmployeeCode = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.ColumnEmployeeName = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.username = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.ColumnRole = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.ColumnDepartement = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnIsChange = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.BCancel = New DevExpress.XtraEditors.SimpleButton()
        Me.BSave = New DevExpress.XtraEditors.SimpleButton()
        Me.LabelControl3 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl2 = New DevExpress.XtraEditors.LabelControl()
        Me.TEHour = New DevExpress.XtraEditors.SpinEdit()
        Me.TESec = New DevExpress.XtraEditors.SpinEdit()
        Me.LabelRange = New DevExpress.XtraEditors.LabelControl()
        Me.TEMin = New DevExpress.XtraEditors.SpinEdit()
        Me.CEHeadDept = New DevExpress.XtraEditors.CheckEdit()
        Me.CEAsstHeadDept = New DevExpress.XtraEditors.CheckEdit()
        Me.CESubHead = New DevExpress.XtraEditors.CheckEdit()
        CType(Me.GCUser, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GVUser, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TEHour.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TESec.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TEMin.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CEHeadDept.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CEAsstHeadDept.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CESubHead.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GCUser
        '
        Me.GCUser.Dock = System.Windows.Forms.DockStyle.Top
        Me.GCUser.Location = New System.Drawing.Point(0, 0)
        Me.GCUser.MainView = Me.GVUser
        Me.GCUser.Name = "GCUser"
        Me.GCUser.Size = New System.Drawing.Size(773, 300)
        Me.GCUser.TabIndex = 7
        Me.GCUser.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GVUser})
        '
        'GVUser
        '
        Me.GVUser.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.id_user, Me.ColumnEmployeeCode, Me.ColumnEmployeeName, Me.username, Me.ColumnRole, Me.ColumnDepartement, Me.GridColumnIsChange})
        Me.GVUser.GridControl = Me.GCUser
        Me.GVUser.Name = "GVUser"
        Me.GVUser.OptionsBehavior.Editable = False
        Me.GVUser.OptionsView.ShowGroupPanel = False
        '
        'id_user
        '
        Me.id_user.Caption = "ID"
        Me.id_user.FieldName = "id_user"
        Me.id_user.Name = "id_user"
        '
        'ColumnEmployeeCode
        '
        Me.ColumnEmployeeCode.Caption = "Employee Code"
        Me.ColumnEmployeeCode.FieldName = "employee_code"
        Me.ColumnEmployeeCode.Name = "ColumnEmployeeCode"
        Me.ColumnEmployeeCode.Visible = True
        Me.ColumnEmployeeCode.VisibleIndex = 0
        '
        'ColumnEmployeeName
        '
        Me.ColumnEmployeeName.Caption = "Employee Name"
        Me.ColumnEmployeeName.FieldName = "employee_name"
        Me.ColumnEmployeeName.Name = "ColumnEmployeeName"
        Me.ColumnEmployeeName.Visible = True
        Me.ColumnEmployeeName.VisibleIndex = 1
        '
        'username
        '
        Me.username.Caption = "Username"
        Me.username.FieldName = "username"
        Me.username.Name = "username"
        Me.username.Visible = True
        Me.username.VisibleIndex = 3
        Me.username.Width = 174
        '
        'ColumnRole
        '
        Me.ColumnRole.Caption = "Role"
        Me.ColumnRole.FieldName = "role"
        Me.ColumnRole.Name = "ColumnRole"
        '
        'ColumnDepartement
        '
        Me.ColumnDepartement.Caption = "Departement"
        Me.ColumnDepartement.FieldName = "departement"
        Me.ColumnDepartement.Name = "ColumnDepartement"
        Me.ColumnDepartement.Visible = True
        Me.ColumnDepartement.VisibleIndex = 2
        '
        'GridColumnIsChange
        '
        Me.GridColumnIsChange.Caption = "Change Password"
        Me.GridColumnIsChange.FieldName = "answer"
        Me.GridColumnIsChange.Name = "GridColumnIsChange"
        '
        'BCancel
        '
        Me.BCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.BCancel.Location = New System.Drawing.Point(605, 319)
        Me.BCancel.Name = "BCancel"
        Me.BCancel.Size = New System.Drawing.Size(75, 23)
        Me.BCancel.TabIndex = 160
        Me.BCancel.Text = "Cancel"
        '
        'BSave
        '
        Me.BSave.Location = New System.Drawing.Point(686, 319)
        Me.BSave.Name = "BSave"
        Me.BSave.Size = New System.Drawing.Size(75, 23)
        Me.BSave.TabIndex = 159
        Me.BSave.Text = "Pick"
        '
        'LabelControl3
        '
        Me.LabelControl3.Appearance.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl3.Location = New System.Drawing.Point(527, 323)
        Me.LabelControl3.Name = "LabelControl3"
        Me.LabelControl3.Size = New System.Drawing.Size(3, 15)
        Me.LabelControl3.TabIndex = 158
        Me.LabelControl3.Text = ":"
        '
        'LabelControl2
        '
        Me.LabelControl2.Appearance.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl2.Location = New System.Drawing.Point(450, 323)
        Me.LabelControl2.Name = "LabelControl2"
        Me.LabelControl2.Size = New System.Drawing.Size(3, 15)
        Me.LabelControl2.TabIndex = 157
        Me.LabelControl2.Text = ":"
        '
        'TEHour
        '
        Me.TEHour.EditValue = New Decimal(New Integer() {0, 0, 0, 0})
        Me.TEHour.Location = New System.Drawing.Point(383, 320)
        Me.TEHour.Name = "TEHour"
        Me.TEHour.Properties.Appearance.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TEHour.Properties.Appearance.Options.UseFont = True
        Me.TEHour.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.TEHour.Properties.IsFloatValue = False
        Me.TEHour.Properties.Mask.EditMask = "N00"
        Me.TEHour.Properties.MaxValue = New Decimal(New Integer() {838, 0, 0, 0})
        Me.TEHour.Size = New System.Drawing.Size(62, 22)
        Me.TEHour.TabIndex = 153
        '
        'TESec
        '
        Me.TESec.EditValue = New Decimal(New Integer() {0, 0, 0, 0})
        Me.TESec.Location = New System.Drawing.Point(537, 320)
        Me.TESec.Name = "TESec"
        Me.TESec.Properties.Appearance.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TESec.Properties.Appearance.Options.UseFont = True
        Me.TESec.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.TESec.Properties.IsFloatValue = False
        Me.TESec.Properties.Mask.EditMask = "N00"
        Me.TESec.Properties.MaxValue = New Decimal(New Integer() {59, 0, 0, 0})
        Me.TESec.Size = New System.Drawing.Size(62, 22)
        Me.TESec.TabIndex = 156
        '
        'LabelRange
        '
        Me.LabelRange.Appearance.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelRange.Location = New System.Drawing.Point(320, 323)
        Me.LabelRange.Name = "LabelRange"
        Me.LabelRange.Size = New System.Drawing.Size(54, 15)
        Me.LabelRange.TabIndex = 154
        Me.LabelRange.Text = "Lead Time"
        '
        'TEMin
        '
        Me.TEMin.EditValue = New Decimal(New Integer() {0, 0, 0, 0})
        Me.TEMin.Location = New System.Drawing.Point(459, 320)
        Me.TEMin.Name = "TEMin"
        Me.TEMin.Properties.Appearance.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TEMin.Properties.Appearance.Options.UseFont = True
        Me.TEMin.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.TEMin.Properties.IsFloatValue = False
        Me.TEMin.Properties.Mask.EditMask = "N00"
        Me.TEMin.Properties.MaxValue = New Decimal(New Integer() {59, 0, 0, 0})
        Me.TEMin.Size = New System.Drawing.Size(62, 22)
        Me.TEMin.TabIndex = 155
        '
        'CEHeadDept
        '
        Me.CEHeadDept.Location = New System.Drawing.Point(12, 321)
        Me.CEHeadDept.Name = "CEHeadDept"
        Me.CEHeadDept.Properties.Caption = "Head Dept."
        Me.CEHeadDept.Size = New System.Drawing.Size(89, 19)
        Me.CEHeadDept.TabIndex = 161
        '
        'CEAsstHeadDept
        '
        Me.CEAsstHeadDept.Location = New System.Drawing.Point(96, 321)
        Me.CEAsstHeadDept.Name = "CEAsstHeadDept"
        Me.CEAsstHeadDept.Properties.Caption = "Asst Head Dept"
        Me.CEAsstHeadDept.Size = New System.Drawing.Size(103, 19)
        Me.CEAsstHeadDept.TabIndex = 162
        '
        'CESubHead
        '
        Me.CESubHead.Location = New System.Drawing.Point(205, 321)
        Me.CESubHead.Name = "CESubHead"
        Me.CESubHead.Properties.Caption = "Head Sub Dept"
        Me.CESubHead.Size = New System.Drawing.Size(109, 19)
        Me.CESubHead.TabIndex = 163
        '
        'FormMarkAssignUserSingle
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(773, 354)
        Me.Controls.Add(Me.CESubHead)
        Me.Controls.Add(Me.CEAsstHeadDept)
        Me.Controls.Add(Me.CEHeadDept)
        Me.Controls.Add(Me.BCancel)
        Me.Controls.Add(Me.BSave)
        Me.Controls.Add(Me.LabelControl3)
        Me.Controls.Add(Me.LabelControl2)
        Me.Controls.Add(Me.TEHour)
        Me.Controls.Add(Me.TESec)
        Me.Controls.Add(Me.LabelRange)
        Me.Controls.Add(Me.TEMin)
        Me.Controls.Add(Me.GCUser)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FormMarkAssignUserSingle"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Pick User"
        CType(Me.GCUser, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GVUser, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TEHour.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TESec.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TEMin.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CEHeadDept.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CEAsstHeadDept.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CESubHead.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents GCUser As DevExpress.XtraGrid.GridControl
    Friend WithEvents GVUser As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents id_user As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColumnEmployeeCode As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColumnEmployeeName As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents username As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColumnRole As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColumnDepartement As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnIsChange As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents BCancel As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BSave As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents LabelControl3 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl2 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents TEHour As DevExpress.XtraEditors.SpinEdit
    Friend WithEvents TESec As DevExpress.XtraEditors.SpinEdit
    Friend WithEvents LabelRange As DevExpress.XtraEditors.LabelControl
    Friend WithEvents TEMin As DevExpress.XtraEditors.SpinEdit
    Friend WithEvents CEHeadDept As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents CEAsstHeadDept As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents CESubHead As DevExpress.XtraEditors.CheckEdit
End Class
