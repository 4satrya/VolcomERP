<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormMasterEmployeePosition
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
        Me.BtnSave = New DevExpress.XtraEditors.SimpleButton()
        Me.PanelControl1 = New DevExpress.XtraEditors.PanelControl()
        Me.LabelControl1 = New DevExpress.XtraEditors.LabelControl()
        Me.LEOriginDept = New DevExpress.XtraEditors.LookUpEdit()
        Me.LabelControl2 = New DevExpress.XtraEditors.LabelControl()
        Me.LEOriginLevel = New DevExpress.XtraEditors.LookUpEdit()
        Me.TxtOriginPosition = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl3 = New DevExpress.XtraEditors.LabelControl()
        Me.TxtPosition = New DevExpress.XtraEditors.TextEdit()
        Me.LELevel = New DevExpress.XtraEditors.LookUpEdit()
        Me.LEDepartement = New DevExpress.XtraEditors.LookUpEdit()
        Me.LabelControl4 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl5 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl6 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl7 = New DevExpress.XtraEditors.LabelControl()
        Me.DEDate = New DevExpress.XtraEditors.DateEdit()
        Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.LESubDeptOrign = New DevExpress.XtraEditors.LookUpEdit()
        Me.LabelControl8 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl9 = New DevExpress.XtraEditors.LabelControl()
        Me.LESubDept = New DevExpress.XtraEditors.LookUpEdit()
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl1.SuspendLayout()
        CType(Me.LEOriginDept.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LEOriginLevel.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtOriginPosition.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtPosition.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LELevel.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LEDepartement.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DEDate.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DEDate.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LESubDeptOrign.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LESubDept.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'BtnSave
        '
        Me.BtnSave.Dock = System.Windows.Forms.DockStyle.Right
        Me.BtnSave.Location = New System.Drawing.Point(415, 0)
        Me.BtnSave.Name = "BtnSave"
        Me.BtnSave.Size = New System.Drawing.Size(75, 37)
        Me.BtnSave.TabIndex = 4
        Me.BtnSave.Text = "Save"
        '
        'PanelControl1
        '
        Me.PanelControl1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
        Me.PanelControl1.Controls.Add(Me.BtnSave)
        Me.PanelControl1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PanelControl1.Location = New System.Drawing.Point(0, 251)
        Me.PanelControl1.Name = "PanelControl1"
        Me.PanelControl1.Size = New System.Drawing.Size(490, 37)
        Me.PanelControl1.TabIndex = 100
        '
        'LabelControl1
        '
        Me.LabelControl1.Location = New System.Drawing.Point(12, 15)
        Me.LabelControl1.Name = "LabelControl1"
        Me.LabelControl1.Size = New System.Drawing.Size(94, 13)
        Me.LabelControl1.TabIndex = 2
        Me.LabelControl1.Text = "Origin Departement"
        '
        'LEOriginDept
        '
        Me.LEOriginDept.Enabled = False
        Me.LEOriginDept.Location = New System.Drawing.Point(133, 12)
        Me.LEOriginDept.Name = "LEOriginDept"
        Me.LEOriginDept.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.LEOriginDept.Properties.Columns.AddRange(New DevExpress.XtraEditors.Controls.LookUpColumnInfo() {New DevExpress.XtraEditors.Controls.LookUpColumnInfo("id_departement", "ID", 20, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("departement", "Departement")})
        Me.LEOriginDept.Properties.NullText = "-"
        Me.LEOriginDept.Size = New System.Drawing.Size(339, 20)
        Me.LEOriginDept.TabIndex = 3
        Me.LEOriginDept.TabStop = False
        '
        'LabelControl2
        '
        Me.LabelControl2.Location = New System.Drawing.Point(12, 67)
        Me.LabelControl2.Name = "LabelControl2"
        Me.LabelControl2.Size = New System.Drawing.Size(56, 13)
        Me.LabelControl2.TabIndex = 4
        Me.LabelControl2.Text = "Origin Level"
        '
        'LEOriginLevel
        '
        Me.LEOriginLevel.Enabled = False
        Me.LEOriginLevel.Location = New System.Drawing.Point(133, 64)
        Me.LEOriginLevel.Name = "LEOriginLevel"
        Me.LEOriginLevel.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.LEOriginLevel.Properties.Columns.AddRange(New DevExpress.XtraEditors.Controls.LookUpColumnInfo() {New DevExpress.XtraEditors.Controls.LookUpColumnInfo("id_employee_level", "ID", 20, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("employee_level", "Level")})
        Me.LEOriginLevel.Properties.NullText = "-"
        Me.LEOriginLevel.Size = New System.Drawing.Size(339, 20)
        Me.LEOriginLevel.TabIndex = 5
        Me.LEOriginLevel.TabStop = False
        '
        'TxtOriginPosition
        '
        Me.TxtOriginPosition.Enabled = False
        Me.TxtOriginPosition.Location = New System.Drawing.Point(133, 90)
        Me.TxtOriginPosition.Name = "TxtOriginPosition"
        Me.TxtOriginPosition.Size = New System.Drawing.Size(339, 20)
        Me.TxtOriginPosition.TabIndex = 6
        Me.TxtOriginPosition.TabStop = False
        '
        'LabelControl3
        '
        Me.LabelControl3.Location = New System.Drawing.Point(12, 93)
        Me.LabelControl3.Name = "LabelControl3"
        Me.LabelControl3.Size = New System.Drawing.Size(68, 13)
        Me.LabelControl3.TabIndex = 7
        Me.LabelControl3.Text = "Origin Position"
        '
        'TxtPosition
        '
        Me.TxtPosition.Location = New System.Drawing.Point(133, 194)
        Me.TxtPosition.Name = "TxtPosition"
        Me.TxtPosition.Size = New System.Drawing.Size(339, 20)
        Me.TxtPosition.TabIndex = 2
        '
        'LELevel
        '
        Me.LELevel.Location = New System.Drawing.Point(133, 168)
        Me.LELevel.Name = "LELevel"
        Me.LELevel.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.LELevel.Properties.Columns.AddRange(New DevExpress.XtraEditors.Controls.LookUpColumnInfo() {New DevExpress.XtraEditors.Controls.LookUpColumnInfo("id_employee_level", "ID", 20, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("employee_level", "Level")})
        Me.LELevel.Properties.NullText = "-"
        Me.LELevel.Size = New System.Drawing.Size(339, 20)
        Me.LELevel.TabIndex = 1
        '
        'LEDepartement
        '
        Me.LEDepartement.Location = New System.Drawing.Point(133, 116)
        Me.LEDepartement.Name = "LEDepartement"
        Me.LEDepartement.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.LEDepartement.Properties.Columns.AddRange(New DevExpress.XtraEditors.Controls.LookUpColumnInfo() {New DevExpress.XtraEditors.Controls.LookUpColumnInfo("id_departement", "ID", 20, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("departement", "Departement")})
        Me.LEDepartement.Properties.NullText = "-"
        Me.LEDepartement.Size = New System.Drawing.Size(339, 20)
        Me.LEDepartement.TabIndex = 0
        '
        'LabelControl4
        '
        Me.LabelControl4.Location = New System.Drawing.Point(12, 197)
        Me.LabelControl4.Name = "LabelControl4"
        Me.LabelControl4.Size = New System.Drawing.Size(37, 13)
        Me.LabelControl4.TabIndex = 13
        Me.LabelControl4.Text = "Position"
        '
        'LabelControl5
        '
        Me.LabelControl5.Location = New System.Drawing.Point(12, 171)
        Me.LabelControl5.Name = "LabelControl5"
        Me.LabelControl5.Size = New System.Drawing.Size(25, 13)
        Me.LabelControl5.TabIndex = 12
        Me.LabelControl5.Text = "Level"
        '
        'LabelControl6
        '
        Me.LabelControl6.Location = New System.Drawing.Point(12, 119)
        Me.LabelControl6.Name = "LabelControl6"
        Me.LabelControl6.Size = New System.Drawing.Size(63, 13)
        Me.LabelControl6.TabIndex = 11
        Me.LabelControl6.Text = "Departement"
        '
        'LabelControl7
        '
        Me.LabelControl7.Location = New System.Drawing.Point(12, 221)
        Me.LabelControl7.Name = "LabelControl7"
        Me.LabelControl7.Size = New System.Drawing.Size(69, 13)
        Me.LabelControl7.TabIndex = 14
        Me.LabelControl7.Text = "Effective Date"
        '
        'DEDate
        '
        Me.DEDate.EditValue = Nothing
        Me.DEDate.Location = New System.Drawing.Point(133, 218)
        Me.DEDate.Name = "DEDate"
        Me.DEDate.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.[False]
        Me.DEDate.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.DEDate.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.DEDate.Properties.DisplayFormat.FormatString = "dd MMM yyyy"
        Me.DEDate.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.DEDate.Properties.Mask.EditMask = "dd\/MM\/yyyy"
        Me.DEDate.Size = New System.Drawing.Size(339, 20)
        Me.DEDate.TabIndex = 3
        '
        'ErrorProvider1
        '
        Me.ErrorProvider1.ContainerControl = Me
        '
        'LESubDeptOrign
        '
        Me.LESubDeptOrign.Enabled = False
        Me.LESubDeptOrign.Location = New System.Drawing.Point(133, 38)
        Me.LESubDeptOrign.Name = "LESubDeptOrign"
        Me.LESubDeptOrign.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.LESubDeptOrign.Properties.Columns.AddRange(New DevExpress.XtraEditors.Controls.LookUpColumnInfo() {New DevExpress.XtraEditors.Controls.LookUpColumnInfo("id_departement_sub", "ID", 20, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("departement_sub", "Departement")})
        Me.LESubDeptOrign.Properties.NullText = "-"
        Me.LESubDeptOrign.Size = New System.Drawing.Size(339, 20)
        Me.LESubDeptOrign.TabIndex = 102
        Me.LESubDeptOrign.TabStop = False
        '
        'LabelControl8
        '
        Me.LabelControl8.Location = New System.Drawing.Point(12, 41)
        Me.LabelControl8.Name = "LabelControl8"
        Me.LabelControl8.Size = New System.Drawing.Size(115, 13)
        Me.LabelControl8.TabIndex = 101
        Me.LabelControl8.Text = "Origin Sub Departement"
        '
        'LabelControl9
        '
        Me.LabelControl9.Location = New System.Drawing.Point(12, 145)
        Me.LabelControl9.Name = "LabelControl9"
        Me.LabelControl9.Size = New System.Drawing.Size(84, 13)
        Me.LabelControl9.TabIndex = 104
        Me.LabelControl9.Text = "Sub Departement"
        '
        'LESubDept
        '
        Me.LESubDept.Location = New System.Drawing.Point(133, 142)
        Me.LESubDept.Name = "LESubDept"
        Me.LESubDept.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.LESubDept.Properties.Columns.AddRange(New DevExpress.XtraEditors.Controls.LookUpColumnInfo() {New DevExpress.XtraEditors.Controls.LookUpColumnInfo("id_departement_sub", "ID", 20, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("departement_sub", "Departement")})
        Me.LESubDept.Properties.NullText = "-"
        Me.LESubDept.Size = New System.Drawing.Size(339, 20)
        Me.LESubDept.TabIndex = 103
        '
        'FormMasterEmployeePosition
        '
        Me.AcceptButton = Me.BtnSave
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(490, 288)
        Me.Controls.Add(Me.LabelControl9)
        Me.Controls.Add(Me.LESubDept)
        Me.Controls.Add(Me.LESubDeptOrign)
        Me.Controls.Add(Me.LabelControl8)
        Me.Controls.Add(Me.DEDate)
        Me.Controls.Add(Me.LabelControl7)
        Me.Controls.Add(Me.LabelControl4)
        Me.Controls.Add(Me.LabelControl5)
        Me.Controls.Add(Me.LabelControl6)
        Me.Controls.Add(Me.TxtPosition)
        Me.Controls.Add(Me.LELevel)
        Me.Controls.Add(Me.LEDepartement)
        Me.Controls.Add(Me.LabelControl3)
        Me.Controls.Add(Me.TxtOriginPosition)
        Me.Controls.Add(Me.LEOriginLevel)
        Me.Controls.Add(Me.LabelControl2)
        Me.Controls.Add(Me.LEOriginDept)
        Me.Controls.Add(Me.LabelControl1)
        Me.Controls.Add(Me.PanelControl1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FormMasterEmployeePosition"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Employee Position"
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl1.ResumeLayout(False)
        CType(Me.LEOriginDept.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LEOriginLevel.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtOriginPosition.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtPosition.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LELevel.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LEDepartement.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DEDate.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DEDate.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LESubDeptOrign.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LESubDept.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents BtnSave As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents PanelControl1 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents LabelControl1 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LEOriginDept As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents LabelControl2 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LEOriginLevel As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents TxtOriginPosition As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl3 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents TxtPosition As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LELevel As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents LEDepartement As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents LabelControl4 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl5 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl6 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl7 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents DEDate As DevExpress.XtraEditors.DateEdit
    Friend WithEvents ErrorProvider1 As ErrorProvider
    Friend WithEvents LESubDeptOrign As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents LabelControl8 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl9 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LESubDept As DevExpress.XtraEditors.LookUpEdit
End Class
